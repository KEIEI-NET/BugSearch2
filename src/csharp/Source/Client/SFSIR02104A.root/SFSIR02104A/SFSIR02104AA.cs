using System;
using System.Data;
using System.Text;
using System.Collections;
using System.Collections.Generic;

using Broadleaf.Library.Text;
using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Library.Globarization;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;
// --- ADD 2012/09/07 ---------->>>>>
using Broadleaf.Application.Resources;
// --- ADD 2012/09/07 ----------<<<<<
namespace Broadleaf.Application.Controller
{
	/// <summary>
	/// �x�������A�N�Z�X�N���X
	/// </summary>
	/// <remarks>
	/// <br>Note		: �x�����̌������s���A�N�Z�X�N���X�ł��B</br>
	/// <br>Programmer	: 22024 ����@�_�u</br>
	/// <br>Date		: 2006.05.24</br>
	/// <br></br>
    /// <br>UpdateNote  : 2006.12.22 �ؑ� ����</br>
    /// <br>              �g��.NS�p�ɃC���Z���e�B�u�i���x�[�g�x���z�j��ǉ�</br>
    /// <br>UpdateNote  : 2007.08.01 �ؑ� ���� �������ߏ����`�F�b�N��ǉ�</br>
    /// <br>UpdateNote  : 2007.09.05 �D�c �E�l DC.NS�p�ɕύX</br>
    /// <br>UpdateNote  : 2008/07/08 �E �K�j DC.NS�p�ɕύX</br>
    /// <br>Update Note : 2009/12/20 杍^ �o�l�D�m�r�ێ�˗��C</br>
    /// <br>                �E���쐫/���͑��x����̂��߂Ɉȉ��̉��ǂ��s��</br>
    /// <br>                �E�d������͌�ɓ����ꗗ�������\�����Ȃ��悤�ɕύX�̑Ή�</br>
    /// <br>UpdateNote  : 2010/03/26 �H�� MANTIS�Ή�[15200]�F0�~�x���ۑ����ɢ�����ʣ��\�����A�I����ɓo�^�֕ύX</br>
    /// <br>UpdateNote  : 2010/03/26 �H�� MANTIS�Ή�[15201]�F�x���ꗗ��ʂɢ���͒S���ң��\���֕ύX</br>
    /// <br>Update Note : 2010.04.27 gejun</br>
    /// <br>              M1007A-�x����`�f�[�^�X�V�ǉ�</br>
    /// <br>UpdateNote  : 2012/09/07 FSI��k�c �G�� �d�������Ή�</br> 
    /// <br></br>
    /// <br>Update Note : 2012/12/24 ���N</br>
    /// <br>�Ǘ��ԍ�    : 10806793-00 2013/03/13�z�M��</br>
    /// <br>              Redmine#33741�̒ǉ��Ή�</br>
    /// <br>Update Note : 2013/02/21 �e�c ���V</br>
    /// <br>�Ǘ��ԍ�    : 10806793-00 2013/03/13�z�M��</br>
    /// <br>              �x���`�[�폜���A��`�f�[�^�R�t�������Ή�</br>
    /// <br>Update Note : 2013/02/22 �e�c ���V</br>
    /// <br>�Ǘ��ԍ�    : 10806793-00 2013/03/13�z�M��</br>
    /// <br>              �o�^�ς݂̎x���`�[��ύX�����A��`��ʂŊm����</br>
    /// <br>              �ۑ������s����ƒ��ߓ`�[�ɂȂ��Q�Ή�</br>
    /// <br>Update Note : 2013/03/01 ���N</br>
    /// <br>�Ǘ��ԍ�    : 10806793-00 2013/03/13�z�M��</br>
    /// <br>              Redmine#33741�̒ǉ��Ή�</br>
    //----------------------------------------------------------------------------//
    /// <br></br>
    /// </remarks>
	public class PaymentSlpSearch
	{

		#region PrivateMember
		// �������������������������������������������������������������������� //
		// �@�@�@�@�A�N�Z�X�N���X�n
		// �������������������������������������������������������������������� //
		// �x���`�[�A�N�Z�X�N���X
		private PaymentSlpAcs _paymentSlpAcs;
		// �x���`�[�����A�N�Z�X�N���X
		private SearchPaymentAcs _searchPaymentAcs;

        // �� 20070519 18322 d MK.NS�ł͎g�p���Ȃ����ߍ폜
		//// �x��KINGET�A�N�Z�X�N���X
		//private KingetSuplierPayAcs _kingetSuplierPayAcs;
		//// �����X�V�A�N�Z�X�N���X
		//private CAddUpHisAcs _cAddUpHisAcs;
        // �� 20070519 18322 d

        // �� 20070519 18322 a
        // ���Ӑ��񌟍�
        //private CustomerInfoAcs _customerInfoAcs = new CustomerInfoAcs();
        // �� 20070519 18322 a

        // �� 20070529 18322 a
        // �x�������������̃����[�g�I�u�W�F�N�g
        private ISuplierPayDB _iSuplierPayDB = null;
        // �� 20070529 18322 a

        //// �� 20070801 18322 a
        //// �������ߏ����̃����[�g�I�u�W�F�N�g
        //private IMonthlyAddUpDB _iMonthlyAddUpDB = null;

        //// �ŏI�������ߓ��t
        //private MonthlyAddUpHisWork _lastMonthlyAddUpHis = null;
        //// �� 20070801 18322 a

        // --- ADD 2008/07/08 --------------------------------------------------------------------->>>>>
        // �d�����A�N�Z�X�N���X
        private SupplierAcs _suppliAcs = null;
        // --- ADD 2008/07/08 ---------------------------------------------------------------------<<<<<

		// �������������������������������������������������������������������� //
		// �@�@�@�@�f�[�^�N���X�n
		// �������������������������������������������������������������������� //
		// �d������
		private SearchCustSuppliRet _searchCustSuppliRet = new SearchCustSuppliRet();
		// �x�����z���
		private SearchSuplierPayRet _searchSuplierPayRet = new SearchSuplierPayRet();
		// ���o���ʂ̎x���`�[�}�X�^
		private Hashtable _paymentSlpHashTable;

		// �������������������������������������������������������������������� //
		// �@�@�@�@���̑�
		// �������������������������������������������������������������������� //
		// �x����� DataTable
		private DataTable _dtPaymentInfo = new DataTable();
        // ----- ADD ���N 2012/12/24 Redmine#33741 ------ >>>>>
        // �x���K�C�h��� DataTable
        private DataTable _dtPaymentInfoUH = new DataTable();
        // ----- ADD ���N 2012/12/24 Redmine#33741 ------ <<<<<
        //// �O�����
        //private int _cAddUpUpDate;

        // �O����ߓ�
        private DateTime _lastAddUpDay;
        // �O�񌎎�����
        private DateTime _lastMonthlyAddUpDay;

        /// <summary>�����Z�o���W���[��</summary>
        private TotalDayCalculator _totalDayCalculator;

		// �G���[���b�Z�[�W
		private string _errorMessage;

        // --- ADD 2012/09/07 ---------->>>>>
        // �d�������I�v�V�����t���O
        private bool _supplierSummary;
        // --- ADD 2012/09/07 ----------<<<<<

		#endregion

		#region Const
		// ������ �x����� ������
		/// <summary>�x���`�[�ꗗ�e�[�u������</summary>
		public const string TBL_PAYMENTSLP = "PaymentSlp";
        // ---- ADD ���N 2012/12/24 Redmine#33741 ----- >>>>>
        public const string TBL_PAYMENTSLPG = "PaymentSlpG"; // �x���`�[�ꗗ�e�[�u������(�d���`�[�����K�C�h�p)
        // ---- ADD ���N 2012/12/24 Redmine#33741 ----- <<<<<
		/// <summary>�x���`�[�ԍ�</summary>
		public const string COL_PAYMENTSLP_PAYMENTSLIPNO		= "PaymentSlipNo";
		/// <summary>�x�����t</summary>
		public const string COL_PAYMENTSLP_PAYMENTDATE			= "PaymentDate";
        /// <summary>�v����t</summary>
        public const string COL_PAYMENTSLP_ADDUPADATE           = "AddUpADate";   // 2007.09.05 add
        /// <summary>�x�����햼��</summary>
		public const string COL_PAYMENTSLP_PAYMENTMONEYKINDNAME	= "PaymentMoneyKindName";
		/// <summary>�x�����z</summary>
		public const string COL_PAYMENTSLP_PAYMENT				= "Payment";
		/// <summary>�x�����z�v</summary>
		public const string COL_PAYMENTSLP_PAYMENTTOTAL			= "PaymentTotal";
		/// <summary>�l���x���z</summary>
		public const string COL_PAYMENTSLP_DISCOUNTPAYMENT		= "DiscountPayment";
		/// <summary>�萔���x���z</summary>
		public const string COL_PAYMENTSLP_FEEPAYMENT			= "FeePayment";
        // �� 20061222 18322 a
        ///// <summary>�C���Z���e�B�u�i���x�[�g�x���z�j</summary>
        //public const string COL_PAYMENTSLP_REBATEPAYMENT        = "RebatePayment";  // 2007.09.05 hikita del
        /// <summary>�ԓ`�敪</summary>
        public const string COL_PAYMENTSLP_DEBITNOTEDIV         = "DebitNoteDiv";
        // �� 20061222 18322 a
        /// <summary>�`�[�E�v</summary>
        public const string COL_PAYMENTSLP_OUTLINE				= "Outline";
		/// <summary>���ς݃t���O</summary>
		public const string COL_PAYMENTSLP_FINISHEDFLG			= "FinishedFlg";

        // ADD 2010/03/26 MANTIS�Ή�[15201]�F�x���ꗗ��ʂɢ���͒S���ң��\���֕ύX ---------->>>>>
        /// <summary>�x�����͎Җ���</summary>
        public const string COL_PAYMENT_INPUT_AGENT_NM = "PaymentInputAgentNm";
        // ADD 2010/03/26 MANTIS�Ή�[15201]�F�x���ꗗ��ʂɢ���͒S���ң��\���֕ύX ----------<<<<<
        // ----- ADD ���N 2012/12/24 Redmine#33741----->>>>>
        /// <summary>�d����R�[�h</summary>
        public const string COL_PAYMENTSLP_SUPPLIERCDRF = "SupplierCd";
        /// <summary>�d���於</summary>
        public const string COL_PAYMENTSLP_SUPPLIERNAME = "SupplierNm";
        // ----- ADD ���N 2012/12/24 Redmine#33741-----<<<<<
		#endregion

		#region Property
		/// <summary>�G���[���b�Z�[�W</summary>
		public string ErrorMessage
		{
			get { return _errorMessage; }
		}
		#endregion

		#region Constructor
		/// <summary>
		/// �R���X�g���N�^
		/// </summary>
		public PaymentSlpSearch()
		{
			// �x���`�[�A�N�Z�X�N���X
			_paymentSlpAcs = new PaymentSlpAcs();
			// �x���`�[�����A�N�Z�X�N���X
			_searchPaymentAcs = new SearchPaymentAcs();

            // --- ADD 2008/07/08 --------------------------------------------------------------------->>>>>
            // �d�����A�N�Z�X�N���X
            this._suppliAcs = new SupplierAcs();
            // --- ADD 2008/07/08 ---------------------------------------------------------------------<<<<<

            // �� 20070519 18322 d MK.NS�ł͎g�p���Ȃ����ߍ폜
			//// �x��KINGET�A�N�Z�X�N���X
			//_kingetSuplierPayAcs = new KingetSuplierPayAcs();
            //
			///// �����X�V�A�N�Z�X�N���X
			//_cAddUpHisAcs = new CAddUpHisAcs();
            // �� 20070519 18322 d

            // �� 20070529 18322 a �x�������������̃����[�g���擾
            this._iSuplierPayDB = (ISuplierPayDB)MediationSuplierPayDB.GetSuplierPayDB();
            // �� 20070529 18322 a

            //// �� 20070801 18322 a
            //// �������ߏ����̃����[�g�I�u�W�F�N�g
            //this._iMonthlyAddUpDB = (IMonthlyAddUpDB)MediationMonthlyAddUpDB.GetCustMonthlyAddUpDB();

            //this._lastMonthlyAddUpHis = null;
            //// �� 20070801 18322 a

			// �f�[�^�e�[�u���쐬
			_dtPaymentInfo = CreatePaymentInfoDataTable(TBL_PAYMENTSLP);
            // ----- ADD ���N 2012/12/24 Redmine#33741 ----->>>>>
            // �K�C�h�f�[�^�e�[�u���쐬
            _dtPaymentInfoUH = CreatePaymentInfoDataTableUH(TBL_PAYMENTSLPG);
            // ----- ADD ���N 2012/12/24 Redmine#33741 ----->>>>>

			// �x���`�[�}�X�^�ێ��p
			_paymentSlpHashTable = new Hashtable();

            _totalDayCalculator = TotalDayCalculator.GetInstance();

            // --- ADD 2012/09/07 ---------->>>>>
            // �d�������I�v�V�����t���O�擾
            this.CacheOptionInfo();
            // --- ADD 2012/09/07 ----------<<<<<

		}
		#endregion

		#region PublicMethod
        public void ClearPaymentDataTable()
        {
            this._dtPaymentInfo.Clear();

            this._paymentSlpHashTable.Clear();
        }

		/// <summary>
		/// �x�����f�[�^�e�[�u���擾����
		/// </summary>
		/// <returns></returns>
		/// <remarks>
		/// <br>Note		: �x�����f�[�^�e�[�u�����擾���܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2006.05.24</br>
		/// </remarks>
		public DataTable GetPaymentInfoDataTable()
		{
			return _dtPaymentInfo;
		}

        // ----- ADD ���N 2012/12/24 Redmine#33741 ----- >>>>>
        /// <summary>
        /// �K�C�h�ptableclear
        /// </summary>
        ///<remarks>
        /// <br>Update Note : 2012/12/24 ���N</br>
        /// <br>�Ǘ��ԍ�    : 10806793-00 2013/03/13�z�M��</br>
        /// <br>              Redmine#33741�̒ǉ��Ή�</br>
        /// </remarks>
        public void ClearPaymentDataTableUH()
        {
            this._dtPaymentInfo.Clear();
        }

        /// <summary>
        /// �K�C�h�x�����f�[�^�e�[�u���폜����
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note		: �K�C�h�x�����f�[�^�e�[�u�����폜���܂��B</br>
        /// <br>Programmer	: ���N</br>
        /// <br>�Ǘ��ԍ�    : 10806793-00 2013/03/13�z�M��</br>
        /// <br>              Redmine#33741�̒ǉ��Ή�</br>
        /// <br>Update Note : 2013/03/01 ���N</br>
        /// <br>�Ǘ��ԍ�    : 10806793-00 2013/03/13�z�M��</br>
        /// <br>              Redmine#33741�̒ǉ��Ή�</br>
        /// </remarks>
        public void ClearPaymentGdDataTable()
        {
            this._dtPaymentInfoUH.Clear();

            //this._paymentSlpHashTable.Clear();// DEL ���N�@2013/03/01 Redmine#33741 
        }
        /// <summary>
        /// �x���K�C�h���f�[�^�e�[�u���擾����
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note		: �x���K�C�h���f�[�^�e�[�u�����擾���܂��B</br>
        /// <br>Programmer	: ���N</br>
        /// <br>�Ǘ��ԍ�    : 10806793-00 2013/03/13�z�M��</br>
        /// <br>              Redmine#33741�̒ǉ��Ή�</br>
        /// </remarks>
        public DataTable GetPaymentInfoDataTableH()
        {
            return _dtPaymentInfoUH;
        }
        // ----- ADD ���N�@2012/12/24 Redmine#33741 ----- <<<<< 

		/// <summary>
		/// �O������擾����
		/// </summary>
		/// <returns></returns>
		/// <remarks>
		/// <br>Note		: �O��������擾���܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2006.05.24</br>
		/// </remarks>
		public int GetCAddUpUpDate()
		{
			return TDateTime.DateTimeToLongDate(this._lastAddUpDay);
		}

		/// <summary>
		/// �ŏI�������ߓ��擾����
		/// </summary>
		/// <returns></returns>
		/// <remarks>
		/// <br>Note		: �ŏI�������ߓ����擾���܂��B</br>
		/// <br>Programmer	: 18322 �ؑ� ����</br>
		/// <br>Date		: 2007.08.01</br>
		/// </remarks>
		public int GetLastMonthlyDate()
		{
            int result = 0;

            if (this._lastMonthlyAddUpDay != null)
            {
                result = TDateTime.DateTimeToLongDate(this._lastMonthlyAddUpDay);
            }

			return result;
		}

		/// <summary>
		/// �x���`�[�擾����
		/// </summary>
		/// <param name="paymentSlp">�x���`�[�}�X�^</param>
		/// <param name="paymentSlipNo">�x���`�[�ԍ�</param>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note		: �w��x���`�[�ԍ��̎x���`�[�}�X�^���擾���܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2006.05.24</br>
		/// </remarks>
		public int GetPaymentSlp(out PaymentSlp paymentSlp, int paymentSlipNo)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			paymentSlp = null;
			if (_paymentSlpHashTable.ContainsKey(paymentSlipNo))
			{
				paymentSlp = (PaymentSlp)_paymentSlpHashTable[paymentSlipNo];
			}
			else
			{
				status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
			}
			return status;
		}

        // �O�񌎎��X�V���擾
        public DateTime GetHisTotalDayMonthlyAccPay(string sectionCode)
        {
            DateTime lastMonthlyAddUpDay;

            this._totalDayCalculator.ClearCache();
            this._totalDayCalculator.InitializeHisMonthlyAccPay();

            int status = this._totalDayCalculator.GetHisTotalDayMonthlyAccPay(sectionCode, out lastMonthlyAddUpDay);
            if (status != 0)
            {
                lastMonthlyAddUpDay = new DateTime();
            }

            return lastMonthlyAddUpDay;
        }

        // �O��x�������擾
        public DateTime GetTotalDayPayment(string sectionCode, int payeeCode)
        {
            DateTime prevTotalDay;

            this._totalDayCalculator.ClearCache();

            int status = this._totalDayCalculator.GetTotalDayPayment(sectionCode, payeeCode, out prevTotalDay);
            if (status != 0)
            {
                prevTotalDay = new DateTime();
            }

            return prevTotalDay;
        }

        public DateTime GetCurrentTotalDayPayment(string sectionCode, int payeeCode)
        {
            DateTime prevTotalDay;
            DateTime currentDay;

            this._totalDayCalculator.ClearCache();

            int status = this._totalDayCalculator.GetTotalDayPayment(sectionCode, payeeCode, out prevTotalDay, out currentDay);
            if (status != 0)
            {
                currentDay = new DateTime();
            }

            return currentDay;
        }

        /// <summary>
        /// �x�����f�[�^��������
        /// </summary>
        /// <param name="searchPaymentParameter">���������p�����[�^</param>
        /// <param name="custSuppli">�d������}�X�^</param>
        /// <param name="suplierPayParam">�x�����z���}�X�^</param>
        /// <param name="searchPaySlpInfoParameter">�x����񌟍��p�����[�^�N���X</param>
        /// <param name="detailsShowFlg">�x���ꗗ��񌟍��t���O</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note		: �x�������ꊇ���Č������܂��B</br>
        /// <br>Programmer	: 30414 �E �K�j</br>
        /// <br>Date		: 2008/07/08</br>
        /// <br>Update Note : 2009/12/20 杍^ �o�l�D�m�r�ێ�˗��C</br> 
        /// <br>                �E���쐫/���͑��x����̂��߂Ɉȉ��̉��ǂ��s��</br>
        /// <br>                �E�d������͌�ɓ����ꗗ�������\�����Ȃ��悤�ɕύX�̑Ή�</br>
        /// </remarks>
        public int SearchPaymentInfo(SearchPaymentParameter searchPaymentParameter, 
                                     SearchPaySlpInfoParameter searchPaySlpInfoParameter, 
                                     out SearchCustSuppliRet custSuppli, 
                                     out SearchSuplierPayRet suplierPayParam,
                                     bool detailsShowFlg)            // ADD 2009/12/20
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            int cAddUpUpDate = 0;

            custSuppli = new SearchCustSuppliRet();
            suplierPayParam = new SearchSuplierPayRet();

            try
            {
                // �d�������X�V�����擾
                this._lastMonthlyAddUpDay = GetHisTotalDayMonthlyAccPay(searchPaymentParameter.AddUpSecCode);

                // �d�������������擾
                this._lastAddUpDay = GetTotalDayPayment(searchPaymentParameter.AddUpSecCode, searchPaymentParameter.PayeeCode);

                // �d������/�x�����z���擾����
                if (searchPaymentParameter.PayeeCode != 0)
                {
                    status = this.GetCustomPaymentInfo1(searchPaymentParameter, out custSuppli, out suplierPayParam);
                    switch (status)
                    {
                        case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                            {
                                // �x�����������Ŏ擾�����O��̒��ߓ��X�V�N������ݒ肷��
                                cAddUpUpDate = TDateTime.DateTimeToLongDate(suplierPayParam.LastCAddUpUpdDate);

                                break;
                            }
                        default:
                            {
                                return (status);
                            }
                    }
                }

                //SearchParaPaymentRead searchParaPaymentRead = CopyToSearchParaPaymentReadFromSearchPaySlpInfoParameter(searchPaySlpInfoParameter);  // DEL 2009/12/20
                this._paymentSlpHashTable = new Hashtable();
                this._dtPaymentInfo.Rows.Clear();

                // ADD 2009/12/20 ----->>>>>
                if (detailsShowFlg)
                {
                    SearchParaPaymentRead searchParaPaymentRead = CopyToSearchParaPaymentReadFromSearchPaySlpInfoParameter(searchPaySlpInfoParameter);

                    // �x���`�[���擾����
                    ArrayList retList;
                    ArrayList paymentSlpList = new ArrayList();
                    status = this._searchPaymentAcs.Search(searchParaPaymentRead, out retList);
                    switch (status)
                    {
                        case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                            {
                                // �����p�x���`�[�}�X�^���x���`�[�}�X�^�փR�s�[
                                foreach (SearchPaymentSlp searchPaymentSlp in retList)
                                {
                                    paymentSlpList.Add(CopyToPaymentSlpFromSearchPaymentSlp(searchPaymentSlp));
                                }

                                SearchPaymentParameter searchPaymentParametar2 = new SearchPaymentParameter();
                                searchPaymentParametar2.EnterpriseCode = searchPaymentParameter.EnterpriseCode;
                                searchPaymentParametar2.SupplierCode = searchPaymentParameter.SupplierCode;
                                searchPaymentParametar2.PayeeCode = searchPaymentParameter.PayeeCode;
                                searchPaymentParametar2.AddUpSecCode = searchPaymentParameter.AddUpSecCode;
                                searchPaymentParametar2.AddUpADate = searchPaymentParameter.AddUpADate;

                                // �ŏI�v����t���擾
                                foreach (PaymentSlp paymentSlp in paymentSlpList)
                                {
                                    if (paymentSlp.PayeeCode != searchPaymentParametar2.PayeeCode)
                                    {
                                        continue;
                                    }

                                    if (searchPaymentParametar2.SupplierCode == 0)
                                    {
                                        // �x���`�[�̓��Ӑ�Ŏx�������擾
                                        searchPaymentParametar2.SupplierCode = paymentSlp.SupplierCd;
                                        searchPaymentParametar2.PayeeCode = paymentSlp.PayeeCode;
                                        status = this.GetCustomPaymentInfo1(searchPaymentParametar2, out custSuppli, out suplierPayParam);
                                        cAddUpUpDate = TDateTime.DateTimeToLongDate(this._lastAddUpDay);
                                    }

                                    // �ŏI�v����t��ݒ�
                                    paymentSlp.CAddUpUpdDate = cAddUpUpDate;

                                    // �x���`�[�ꗗDataRow�쐬
                                    SetPaymentDataToDataTable(paymentSlp);
                                }

                                break;
                            }
                        case (int)ConstantManagement.DB_Status.ctDB_EOF:
                            {
                                if (searchPaymentParameter.SupplierCode == 0)
                                {
                                    this._errorMessage = "�w�肵�������ŁA�x���`�[�͑��݂��܂���ł����B";
                                }
                                else
                                {
                                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                                }
                                break;
                            }
                        default:
                            {
                                this._errorMessage = this._searchPaymentAcs.ErrorMessage;
                                return (status);
                            }
                    }
                }
                // ADD 2009/12/20 -----<<<<<

                #region DEL 2009/12/20
                // DEL 2009/12/20 ----->>>>>
                //// �x���`�[���擾����
                //ArrayList retList;
                //ArrayList paymentSlpList = new ArrayList();
                //status = this._searchPaymentAcs.Search(searchParaPaymentRead, out retList);
                //switch (status)
                //{
                //    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                //        {
                //            // �����p�x���`�[�}�X�^���x���`�[�}�X�^�փR�s�[
                //            foreach (SearchPaymentSlp searchPaymentSlp in retList)
                //            {
                //                paymentSlpList.Add(CopyToPaymentSlpFromSearchPaymentSlp(searchPaymentSlp));
                //            }

                //            SearchPaymentParameter searchPaymentParametar2 = new SearchPaymentParameter();
                //            searchPaymentParametar2.EnterpriseCode = searchPaymentParameter.EnterpriseCode;
                //            searchPaymentParametar2.SupplierCode = searchPaymentParameter.SupplierCode;
                //            searchPaymentParametar2.PayeeCode = searchPaymentParameter.PayeeCode;
                //            searchPaymentParametar2.AddUpSecCode = searchPaymentParameter.AddUpSecCode;
                //            searchPaymentParametar2.AddUpADate = searchPaymentParameter.AddUpADate;

                //            // �ŏI�v����t���擾
                //            foreach (PaymentSlp paymentSlp in paymentSlpList)
                //            {
                //                if (paymentSlp.PayeeCode != searchPaymentParametar2.PayeeCode)
                //                {
                //                    continue;
                //                }

                //                if (searchPaymentParametar2.SupplierCode == 0)
                //                {
                //                    // �x���`�[�̓��Ӑ�Ŏx�������擾
                //                    searchPaymentParametar2.SupplierCode = paymentSlp.SupplierCd;
                //                    searchPaymentParametar2.PayeeCode = paymentSlp.PayeeCode;

                //                    status = this.GetCustomPaymentInfo1(searchPaymentParametar2, out custSuppli, out suplierPayParam);
                //                    cAddUpUpDate = TDateTime.DateTimeToLongDate(this._lastAddUpDay);
                //                }

                //                // �ŏI�v����t��ݒ�
                //                paymentSlp.CAddUpUpdDate = cAddUpUpDate;

                //                // �x���`�[�ꗗDataRow�쐬
                //                SetPaymentDataToDataTable(paymentSlp);
                //            }

                //            break;
                //        }
                //    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                //        {
                //            if (searchPaymentParameter.SupplierCode == 0)
                //            {
                //                this._errorMessage = "�w�肵�������ŁA�x���`�[�͑��݂��܂���ł����B";
                //            }
                //            else
                //            {
                //                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                //            }
                //            break;
                //        }
                //    default:
                //        {
                //            this._errorMessage = this._searchPaymentAcs.ErrorMessage;
                //            return (status);
                //        }
                //}
                // DEL 2009/12/20 -----<<<<<
                #endregion
            }
            catch (Exception ex)
            {
                this._errorMessage = ex.Message;
                status = -1;
            }

            return status;
        }

        // ----- ADD ���N 2012/12/24 Redmine#33741 ----------->>>>>
        /// <summary>
        /// �x�����f�[�^��������(�x���`�[�ԍ��������[�h)
        /// </summary>
        /// <param name="searchPaymentParameter">���������p�����[�^</param>
        /// <param name="custSuppli">�d������}�X�^</param>
        /// <param name="suplierPayParam">�x�����z���}�X�^</param>
        /// <param name="searchPaySlpInfoParameter">�x����񌟍��p�����[�^�N���X</param>
        /// <param name="detailsShowFlg">�x���ꗗ��񌟍��t���O</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note		: �x�������ꊇ���Č������܂��B</br>
        /// <br>Programmer	: ���N</br>
        /// <br>�Ǘ��ԍ�    : 10806793-00 2013/03/13�z�M��</br>
        /// <br>Date		: 2012/12/24</br>
        /// </remarks>
        public int SearchPaymentInfoUG(SearchPaymentParameter searchPaymentParameter,
                                     SearchPaySlpInfoParameter searchPaySlpInfoParameter,
                                     out SearchCustSuppliRet custSuppli,
                                     out SearchSuplierPayRet suplierPayParam,
                                     bool detailsShowFlg)            
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            int cAddUpUpDate = 0;
            custSuppli = new SearchCustSuppliRet();
            suplierPayParam = new SearchSuplierPayRet();

            try
            {
                // �d�������X�V�����擾
                this._lastMonthlyAddUpDay = GetHisTotalDayMonthlyAccPay(searchPaymentParameter.AddUpSecCode);

                // �d�������������擾
                this._lastAddUpDay = GetTotalDayPayment(searchPaymentParameter.AddUpSecCode, searchPaymentParameter.PayeeCode);

                // �d������/�x�����z���擾����
                if (searchPaymentParameter.PayeeCode != 0)
                {
                    status = this.GetCustomPaymentInfo1(searchPaymentParameter, out custSuppli, out suplierPayParam);
                    switch (status)
                    {
                        case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                            {
                                // �x�����������Ŏ擾�����O��̒��ߓ��X�V�N������ݒ肷��
                                cAddUpUpDate = TDateTime.DateTimeToLongDate(suplierPayParam.LastCAddUpUpdDate);

                                break;
                            }
                        default:
                            {
                                return (status);
                            }
                    }
                } 
                #endregion
            }
            catch (Exception ex)
            {
                this._errorMessage = ex.Message;
                status = -1;
            }

            return status;
        }

        /// <summary>
        /// �x���`�[���f�[�^��������(�x���`�[�ԍ��������[�h)
        /// </summary>
        /// <param name="searchPaySlpInfoParameter">���������p�����[�^</param>
        /// <param name="totalDay">�x����</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note		: �x���`�[�����ꊇ���Č������܂��B</br>
        /// <br>Programmer	: ���N</br>
        /// <br>�Ǘ��ԍ�    : 10806793-00 2013/03/13�z�M��</br>
        /// <br>Date		: 2012/12/24</br>
        /// </remarks>
        public int SearchPaySlpInfoUG(SearchPaySlpInfoParameter searchPaySlpInfoParameter, int totalDay)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            try
            {
                SearchParaPaymentRead searchParaPaymentRead = CopyToSearchParaPaymentReadFromSearchPaySlpInfoParameter(searchPaySlpInfoParameter);
                this._paymentSlpHashTable = new Hashtable();
                this._dtPaymentInfo.Rows.Clear();

                // �x���`�[���擾����
                ArrayList retList;
                ArrayList paymentSlpList = new ArrayList();
                status = this._searchPaymentAcs.Search(searchParaPaymentRead, out retList);
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        {
                            // �d�������X�V�����擾
                            this._lastMonthlyAddUpDay = GetHisTotalDayMonthlyAccPay(searchParaPaymentRead.AddUpSecCode);

                            // �d�������������擾
                            this._lastAddUpDay = GetTotalDayPayment(searchParaPaymentRead.AddUpSecCode, searchParaPaymentRead.SupplierCd);

                            // �����p�x���`�[�}�X�^���x���`�[�}�X�^�փR�s�[
                            foreach (SearchPaymentSlp searchPaymentSlp in retList)
                            {
                                paymentSlpList.Add(CopyToPaymentSlpFromSearchPaymentSlp(searchPaymentSlp));
                            }

                            foreach (PaymentSlp paymentSlp in paymentSlpList)
                            {
                                paymentSlp.CAddUpUpdDate = TDateTime.DateTimeToLongDate(this._lastAddUpDay);

                                // �x���`�[�ꗗDataRow�쐬
                                SetPaymentDataToDataTable(paymentSlp);
                            }

                            break;
                        }
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        {
                            this._errorMessage = "�w�肳�ꂽ�����ŁA�x���`�[�͑��݂��܂���ł����B";
                            break;
                        }
                    default:
                        {
                            this._errorMessage = this._searchPaymentAcs.ErrorMessage;
                            return status;
                        }
                }
            }
            catch (Exception ex)
            {
                this._errorMessage = ex.Message;
            }

            return status;
        }

        /// <summary>
        /// �x���`�[���f�[�^��������(�x���`�[�ԍ��������[�h)
        /// </summary>
        /// <param name="searchPaySlpInfoParameter">���������p�����[�^</param>
        /// <param name="totalDay">�x����</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note		: �x���`�[�����ꊇ���Č������܂��B</br>
        /// <br>Programmer	: ���N</br>
        /// <br>�Ǘ��ԍ�    : 10806793-00 2013/03/13�z�M��</br>
        /// <br>Date		: 2012/12/24</br>
        /// </remarks>
        public int SearchPaySlpInfoUH(SearchPaySlpInfoParameter searchPaySlpInfoParameter, int totalDay)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            //DataSet������
            this.ClearPaymentGdDataTable();

            try
            {
                SearchParaPaymentRead searchParaPaymentRead = CopyToSearchParaPaymentReadFromSearchPaySlpInfoParameter(searchPaySlpInfoParameter);
                this._paymentSlpHashTable = new Hashtable();

                // �x���`�[���擾����
                ArrayList retList;
                ArrayList paymentSlpList = new ArrayList();

                // �d�������X�V�����擾
                this._lastMonthlyAddUpDay = GetHisTotalDayMonthlyAccPay(searchParaPaymentRead.AddUpSecCode);

                // �d�������������擾
                this._lastAddUpDay = GetTotalDayPayment(searchParaPaymentRead.AddUpSecCode, searchParaPaymentRead.SupplierCd);

                if (searchPaySlpInfoParameter.SupplierCode == 0)
                {
                    searchParaPaymentRead.PaymentCallMonthsStart = this._lastMonthlyAddUpDay.AddDays(1);
                }
                else
                {
                    if (this._lastMonthlyAddUpDay > this._lastAddUpDay)
                    {
                        searchParaPaymentRead.PaymentCallMonthsStart = this._lastMonthlyAddUpDay.AddDays(1);
                    }
                    else
                    {
                        searchParaPaymentRead.PaymentCallMonthsStart = this._lastAddUpDay.AddDays(1);
                    }
                }
                status = this._searchPaymentAcs.Search(searchParaPaymentRead, out retList);
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        {
                            // �����p�x���`�[�}�X�^���x���`�[�}�X�^�փR�s�[
                            foreach (SearchPaymentSlp searchPaymentSlp in retList)
                            {
                                paymentSlpList.Add(CopyToPaymentSlpFromSearchPaymentSlp(searchPaymentSlp));
                            }

                            foreach (PaymentSlp paymentSlp in paymentSlpList)
                            {
                                paymentSlp.CAddUpUpdDate = TDateTime.DateTimeToLongDate(this._lastAddUpDay);

                                // �x���`�[�ꗗDataRow�쐬
                                SetPaymentDataToDataTableUH(paymentSlp);
                            }
                            this._dtPaymentInfoUH.DefaultView.Sort = "PaymentSlipNo asc";                 
                            break;
                        }
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        {
                            this._errorMessage = "�w�肳�ꂽ�����ŁA�x���`�[�͑��݂��܂���ł����B";
                            break;
                        }
                    default:
                        {
                            this._errorMessage = this._searchPaymentAcs.ErrorMessage;
                            return status;
                        }
                }
            }
            catch (Exception ex)
            {
                this._errorMessage = ex.Message;
            }

            return status;
        }

        // ----- ADD ���N 2012/12/24 Redmine#33741 -----------<<<<<

        /// <summary>
        /// �N���X�����o�R�s�[����
        /// </summary>
        /// <param name="searchPaySlpInfoParameter"></param>
        /// <returns></returns>
        private SearchParaPaymentRead CopyToSearchParaPaymentReadFromSearchPaySlpInfoParameter(SearchPaySlpInfoParameter searchPaySlpInfoParameter)
        {
            SearchParaPaymentRead searchParaPaymentRead = new SearchParaPaymentRead();

            searchParaPaymentRead.AddUpSecCode = searchPaySlpInfoParameter.AddUpSecCode;
            searchParaPaymentRead.AutoPayment = searchPaySlpInfoParameter.AutoPayment;
            searchParaPaymentRead.EnterpriseCode = searchPaySlpInfoParameter.EnterpriseCode;
            searchParaPaymentRead.PaymentCallMonthsEnd = searchPaySlpInfoParameter.PaymentCallMonthsEnd;
            searchParaPaymentRead.PaymentCallMonthsStart = searchPaySlpInfoParameter.PaymentCallMonthsStart;
            searchParaPaymentRead.PaymentSlipNo = searchPaySlpInfoParameter.PaymentSlipNo;
            searchParaPaymentRead.SupplierCd = searchPaySlpInfoParameter.SupplierCode;
            searchParaPaymentRead.SupplierCd = searchPaySlpInfoParameter.SupplierCode;


            return searchParaPaymentRead;
        }

        /// <summary>
        /// �x���`�[���f�[�^��������
        /// </summary>
        /// <param name="searchPaySlpInfoParameter">���������p�����[�^</param>
        /// <param name="totalDay">�x����</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note		: �x���`�[�����ꊇ���Č������܂��B</br>
        /// <br>Programmer	: 30414 �E �K�j</br>
        /// <br>Date		: 2008/07/08</br>
        /// </remarks>
        public int SearchPaySlpInfo(SearchPaySlpInfoParameter searchPaySlpInfoParameter, int totalDay)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            try
            {
                SearchParaPaymentRead searchParaPaymentRead = CopyToSearchParaPaymentReadFromSearchPaySlpInfoParameter(searchPaySlpInfoParameter);
                this._paymentSlpHashTable = new Hashtable();
                this._dtPaymentInfo.Rows.Clear();

                // �x���`�[���擾����
                ArrayList retList;
                ArrayList paymentSlpList = new ArrayList();
                status = this._searchPaymentAcs.Search(searchParaPaymentRead, out retList);
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        {
                            // �d�������X�V�����擾
                            this._lastMonthlyAddUpDay = GetHisTotalDayMonthlyAccPay(searchParaPaymentRead.AddUpSecCode);

                            // �d�������������擾
                            this._lastAddUpDay = GetTotalDayPayment(searchParaPaymentRead.AddUpSecCode, searchParaPaymentRead.SupplierCd);

                            // �����p�x���`�[�}�X�^���x���`�[�}�X�^�փR�s�[
                            foreach (SearchPaymentSlp searchPaymentSlp in retList)
                            {
                                if (searchPaymentSlp.PayeeCode != searchPaySlpInfoParameter.PayeeCode)
                                {
                                    continue;
                                }

                                paymentSlpList.Add(CopyToPaymentSlpFromSearchPaymentSlp(searchPaymentSlp));
                            }

                            foreach (PaymentSlp paymentSlp in paymentSlpList)
                            {
                                paymentSlp.CAddUpUpdDate = TDateTime.DateTimeToLongDate(this._lastAddUpDay);

                                // �x���`�[�ꗗDataRow�쐬
                                SetPaymentDataToDataTable(paymentSlp);
                            }
                            
                            break;
                        }
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        {
                            this._errorMessage = "�w�肳�ꂽ�����ŁA�x���`�[�͑��݂��܂���ł����B";
                            break;
                        }
                    default:
                        {
                            this._errorMessage = this._searchPaymentAcs.ErrorMessage;
                            return status;
                        }
                }
            }
            catch (Exception ex)
            {
                this._errorMessage = ex.Message;
            }

            return status;
        }

        #region DEL 2008/07/08 Partsman�p�ɕύX
        /* --- DEL 2008/07/08 --------------------------------------------------------------------->>>>>
		/// <summary>
		/// �x�����f�[�^��������
		/// </summary>
		/// <param name="searchPaymentParameter">���������p�����[�^</param>
		/// <param name="custSuppli">�d������}�X�^</param>
		/// <param name="suplierPayParam">�x�����z���}�X�^</param>
		/// <param name="searchPaySlpInfoParameter">�x����񌟍��p�����[�^�N���X</param>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note		: �x�������ꊇ���Č������܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2006.05.24</br>
		/// </remarks>
		public int SearchPaymentInfo(SearchPaymentParameter searchPaymentParameter, SearchPaySlpInfoParameter searchPaySlpInfoParameter, out SearchCustSuppliRet custSuppli, out SearchSuplierPayRet suplierPayParam)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			int cAddUpUpDate = 0;
			custSuppli = null;
			suplierPayParam	= null;

			try
			{
                // �� 20070801 18322 a �ǉ�
                if (this._lastMonthlyAddUpHis == null)
                {
                    // �ŏI�������ߓ����擾
                    MonthlyAddUpHisWork monthlyAddUpHisWork = new MonthlyAddUpHisWork();
                    monthlyAddUpHisWork.EnterpriseCode = searchPaymentParameter.EnterpriseCode;
                    monthlyAddUpHisWork.AddUpSecCode   = searchPaymentParameter.AddUpSecCode;

                    string retMsg;
                    object retObj = monthlyAddUpHisWork;
                    status = this._iMonthlyAddUpDB.ReadHis(ref retObj, out retMsg);
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
                // �� 20070801 18322 a �ǉ�

				// �d������/�x�����z���擾����
				if (searchPaymentParameter.CustomerCode != 0)
				{
					status = this.GetCustomPaymentInfo1(searchPaymentParameter, out custSuppli, out suplierPayParam);
					switch (status)
					{
						case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
						{
                            // �� 20070520 18322 c �x�����������Ŏ擾����ׁA�폜
							//// �ŏI�v����t���擾
							//GetCAddUpHisInfo(searchPaySlpInfoParameter.EnterpriseCode, custSuppli.TotalDay, out cAddUpUpDate);

                            // �x�����������Ŏ擾�����O��̒��ߓ��X�V�N������ݒ肷��
                            cAddUpUpDate = TDateTime.DateTimeToLongDate(suplierPayParam.LastCAddUpUpdDate);
                            // �� 20070520 18322 c

							break;
						}
						default:
						{
							return status;
						}
					}
                }

				SearchParaPaymentRead searchParaPaymentRead
					= (SearchParaPaymentRead)DBAndXMLDataMergeParts.CopyPropertyInClass(searchPaySlpInfoParameter, typeof(SearchParaPaymentRead));

				_paymentSlpHashTable = new Hashtable();
				_dtPaymentInfo.Rows.Clear();

				ArrayList retList;
				// �x���`�[���擾����
				status = _searchPaymentAcs.Search(searchParaPaymentRead, out retList);
				switch (status)
				{
					case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
					{
						// �����p�x���`�[�}�X�^���x���`�[�}�X�^�փR�s�[
						retList = DBAndXMLDataMergeParts.CopyPropertyInList(retList, typeof(PaymentSlp));

                        // �� 20070519 18322 a �x�����������̋@�\���ł�����u�������镔��
                        SearchPaymentParameter searchPaymentParametar2 = new SearchPaymentParameter();
                        searchPaymentParametar2.EnterpriseCode = searchPaymentParameter.EnterpriseCode;
                        searchPaymentParametar2.CustomerCode   = searchPaymentParameter.CustomerCode;
                        searchPaymentParametar2.PayeeCode      = searchPaymentParameter.PayeeCode;
                        searchPaymentParametar2.AddUpSecCode   = searchPaymentParameter.AddUpSecCode;
                        searchPaymentParametar2.AddUpADate     = searchPaymentParameter.AddUpADate;

						// �ŏI�v����t���擾
						for (int ix = 0 ; ix != retList.Count ; ix++)
						{
							PaymentSlp paymentSlp = (PaymentSlp)retList[ix];

                            if (searchPaymentParametar2.CustomerCode == 0)
                            {
                                // �x���`�[�̓��Ӑ�Ŏx�������擾
                                searchPaymentParametar2.CustomerCode = paymentSlp.CustomerCode;
                                searchPaymentParametar2.PayeeCode = paymentSlp.PayeeCode;

                                status = this.GetCustomPaymentInfo1(searchPaymentParametar2, out custSuppli, out suplierPayParam);
                                cAddUpUpDate = this._cAddUpUpDate;
                            }

                            // �ŏI�v����t��ݒ�
							paymentSlp.CAddUpUpdDate = cAddUpUpDate;


							SetPaymentDataToDataTable(paymentSlp);
                        }
                        // �� 20070519 18322 a

                        // �� 20070519 18322 d �x�����������̋@�\�𗘗p����׍폜
                        #region �d������/�x�����z���擾����
                        //// �d������/�x�����z���擾����
						//if (searchPaymentParameter.CustomerCode == 0)
						//{
						//	PaymentSlp wkPaymentSlp = (PaymentSlp)retList[0];
						//	searchPaymentParameter.CustomerCode = wkPaymentSlp.CustomerCode;
						//	status = this.GetCustomPaymentInfo1(searchPaymentParameter, out custSuppli, out suplierPayParam);
						//	switch (status)
						//	{
						//		case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
						//		{
						//			// �ŏI�v����t���擾
						//			GetCAddUpHisInfo(searchPaySlpInfoParameter.EnterpriseCode, custSuppli.TotalDay, out cAddUpUpDate);
						//			break;
						//		}
						//		default:
						//		{
						//			return status;
						//		}
						//	}
						//}
						//
						//// �ŏI�v����t���擾
						//for (int ix = 0 ; ix != retList.Count ; ix++)
						//{
						//	PaymentSlp paymentSlp = (PaymentSlp)retList[ix];
						//	paymentSlp.CAddUpUpdDate = cAddUpUpDate;
						//
						//	SetPaymentDataToDataTable(paymentSlp);
                        //}
                        #endregion
                        // �� 20070519 18322 d

                        break;
					}
					case (int)ConstantManagement.DB_Status.ctDB_EOF:
					{
						if (searchPaymentParameter.CustomerCode == 0)
						{
							_errorMessage = "�w�肵�������ŁA�x���`�[�͑��݂��܂���ł����B";
						}
						else
						{
							status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
						}
						break;
					}
					default:
					{
						_errorMessage = _searchPaymentAcs.ErrorMessage;
						return status;
					}
				}
			}
			catch (Exception ex)
			{
				_errorMessage = ex.Message;
				status = -1;
			}

			return status;
		}

        /// <summary>
		/// �x���`�[���f�[�^��������
		/// </summary>
		/// <param name="searchPaySlpInfoParameter">���������p�����[�^</param>
		/// <param name="totalDay">�x����</param>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note		: �x���`�[�����ꊇ���Č������܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2006.05.24</br>
		/// </remarks>
		public int SearchPaySlpInfo(SearchPaySlpInfoParameter searchPaySlpInfoParameter, int totalDay)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

			try
			{
				SearchParaPaymentRead searchParaPaymentRead
					= (SearchParaPaymentRead)DBAndXMLDataMergeParts.CopyPropertyInClass(searchPaySlpInfoParameter, typeof(SearchParaPaymentRead));

				_paymentSlpHashTable = new Hashtable();
				_dtPaymentInfo.Rows.Clear();

				ArrayList retList;
				// �x���`�[���擾����
				status = _searchPaymentAcs.Search(searchParaPaymentRead, out retList);
				switch (status)
				{
					case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
					{
						// �����p�x���`�[�}�X�^���x���`�[�}�X�^�փR�s�[
						retList = DBAndXMLDataMergeParts.CopyPropertyInList(retList, typeof(PaymentSlp));

                        // �� 20070519 18322 a
    					for (int ix = 0 ; ix != retList.Count ; ix++)
						{
							PaymentSlp paymentSlp = (PaymentSlp)retList[ix];
	    					paymentSlp.CAddUpUpdDate = this._cAddUpUpDate;
                            SetPaymentDataToDataTable(paymentSlp);
						}
                        // �� 20070519 18322 a

                        // �� 20070519 18322 d �x�����������̋@�\��
                        #region �ŏI�v����t���擾
                        //// �ŏI�v����t���擾
						//int cAddUpUpDate = 0;
						//status = GetCAddUpHisInfo(searchPaySlpInfoParameter.EnterpriseCode, totalDay, out cAddUpUpDate);
						//switch (status)
						//{
						//	case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
						//	case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
						//	{
						//		for (int ix = 0 ; ix != retList.Count ; ix++)
						//		{
						//			PaymentSlp paymentSlp = (PaymentSlp)retList[ix];
						//			paymentSlp.CAddUpUpdDate = cAddUpUpDate;
						//
						//			SetPaymentDataToDataTable(paymentSlp);
						//		}
						//		status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
						//		break;
						//	}
						//}
                        #endregion
						break;
					}
					case (int)ConstantManagement.DB_Status.ctDB_EOF:
					{
						_errorMessage = "�w�肳�ꂽ�����ŁA�x���`�[�͑��݂��܂���ł����B";
						break;
					}
					default:
					{
						_errorMessage = _searchPaymentAcs.ErrorMessage;
						return status;
					}
				}
			}
			catch (Exception ex)
			{
				_errorMessage = ex.Message;
			}

			return status;
		}
           --- DEL 2008/07/08 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/07/08 Partsman�p�ɕύX
        
        /// <summary>
		/// �x���`�[�X�V����
		/// </summary>
		/// <param name="paymentSlp">�x���`�[�}�X�^</param>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note		: �x���`�[�}�X�^��o�^���܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2006.05.24</br>
		/// </remarks>
		public int SavePaymentData(ref PaymentSlp paymentSlp)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			_errorMessage = "";

			status = _paymentSlpAcs.Write(ref paymentSlp);
			if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
                // �x���`�[�ꗗDataRow�쐬
				SetPaymentDataToDataTable(paymentSlp);
			}
			else
			{
				_errorMessage = _paymentSlpAcs.ErrorMessage;
			}

			return status;
		}

        // --- ADD 2008/07/08 --------------------------------------------------------------------->>>>>
        // --------------- ADD START 2010.04.27 gejun FOR M1007A-�x����`�f�[�^�X�V�ǉ�-------->>>>
        /// <summary>
        /// �x���`�[�X�V����(�x����`�f�[�^���A���)
        /// </summary>
        /// <param name="paymentSlp">�x���`�[�}�X�^</param>
        /// <param name="payDraftData">�x����`�f�[�^</param>
        /// <param name="payDraftDataDel">�x����`�f�[�^(�폜�p)</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note		: �x���`�[�}�X�^��o�^�A�X�V�A�폜���܂��B</br>
        /// <br>Programmer	: gejun</br>
        /// <br>Date		: 2019.04.27</br>
        /// </remarks>
        public int SavePaymentDataWithDraft(ref PaymentSlp paymentSlp, PayDraftData payDraftData, PayDraftData payDraftDataDel)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            _errorMessage = "";

            status = _paymentSlpAcs.WriteWithPayDraft(ref paymentSlp, payDraftData, payDraftDataDel);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // �x���`�[�ꗗDataRow�쐬
                SetPaymentDataToDataTable(paymentSlp);
            }
            else
            {
                _errorMessage = _paymentSlpAcs.ErrorMessage;
            }

            return status;
        }
        // --- ADD 2012/10/18 -------------------------------------------------->>>>>
        /// <summary>
        /// �x���`�[�X�V����(�x����`�E����`�f�[�^���A���)
        /// </summary>
        /// <param name="paymentSlp">�x���`�[�}�X�^</param>
        /// <param name="payDraftData">�x����`�f�[�^</param>
        /// <param name="payDraftDataDel">�x����`�f�[�^(�폜�p)</param>
        /// <param name="rcvDraftData">����`�f�[�^</param>
        /// <param name="rcvDraftDataDel">����`�f�[�^(�폜�p)</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note		: �x���`�[�}�X�^��o�^�A�X�V�A�폜���܂��B</br>
        /// <br>Programmer	: �{�{</br>
        /// <br>Date		: 2012/10/18</br>
        /// </remarks>
        // --- UPD 2013/02/22 Y.Wakita ---------->>>>>
        //public int SavePaymentDataWithDraftAll(ref PaymentSlp paymentSlp, PayDraftData payDraftData, PayDraftData payDraftDataDel
        //                                                                , RcvDraftData rcvDraftData, RcvDraftData rcvDraftDataDel)
        public int SavePaymentDataWithDraftAll(ref PaymentSlp paymentSlp, PayDraftData payDraftData, PayDraftData payDraftDataDel
                                                                        , RcvDraftData rcvDraftData, RcvDraftData rcvDraftDataDel
                                                                        , bool payUpdFlg)
        // --- UPD 2013/02/22 Y.Wakita ----------<<<<<
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            _errorMessage = "";

            // --- ADD 2013/02/22 Y.Wakita ---------->>>>>
            DateTime addUpADateBk = new DateTime();
            if (payUpdFlg == false)
            {
                //�x���`�[���X�V���Ȃ��ׁA���t�𑀍삷��B
                addUpADateBk = paymentSlp.AddUpADate;
                paymentSlp.AddUpADate = DateTime.MinValue;
            }
            // --- ADD 2013/02/22 Y.Wakita ----------<<<<<
            status = _paymentSlpAcs.WriteWithDraft(ref paymentSlp, payDraftData, payDraftDataDel, rcvDraftData, rcvDraftDataDel);
            // --- ADD 2013/02/22 Y.Wakita ---------->>>>>
            if (payUpdFlg == false)
            {
                //���t�����ɖ߂�
                paymentSlp.AddUpADate = addUpADateBk;
            }
            // --- ADD 2013/02/22 Y.Wakita ----------<<<<<
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // �x���`�[�ꗗDataRow�쐬
                SetPaymentDataToDataTable(paymentSlp);
            }
            else
            {
                _errorMessage = _paymentSlpAcs.ErrorMessage;
            }

            return status;
        }
        // --- ADD 2012/10/18 --------------------------------------------------<<<<<

        // --------------- ADD END 2010.04.27 gejun FOR M1007A-�x����`�f�[�^�X�V�ǉ�-------->>>>
		/// <summary>
		/// �x���`�[�폜����
		/// </summary>
		/// <param name="paymentSlp">�x���`�[�}�X�^</param>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note		: �x���`�[�}�X�^���폜���܂��B</br>
		/// <br>Programmer	: 30414 �E �K�j</br>
		/// <br>Date		: 2008/07/08</br>
		/// </remarks>
        // --- UPD 2013/02/21 Y.Wakita ---------->>>>>
        //public int DeletePaymentData(PaymentSlp paymentSlp)
        public int DeletePaymentData(PaymentSlp paymentSlp, PayDraftData payDraftData)
        // --- UPD 2013/02/21 Y.Wakita ----------<<<<<
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			_errorMessage = "";

            PaymentDataWork paymentDataWork;

            // --- UPD 2013/02/21 Y.Wakita ---------->>>>>
            //status = _paymentSlpAcs.Delete(paymentSlp.EnterpriseCode, paymentSlp.PaymentSlipNo, out paymentDataWork);
            status = _paymentSlpAcs.Delete(paymentSlp.EnterpriseCode, paymentSlp.PaymentSlipNo, payDraftData, out paymentDataWork);
            // --- UPD 2013/02/21 Y.Wakita ----------<<<<<
			switch (status)
			{
				case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
				{
					RemovePaymentDataFromDataTable(paymentSlp);

                    if (paymentDataWork != null)
                    {
                        // �����E�ςݍ��`�����`�ɖ߂�
                        SetPaymentDataToDataTable(CopyToPaymentSlpFromPaymentSlpWork(paymentDataWork));
                    }
					break;
				}
				default:
				{
					_errorMessage = _paymentSlpAcs.ErrorMessage;
					break;
				}
			}

			return status;
        }

        /// <summary>
        /// �x���`�[�ԓ`�쐬����
        /// </summary>
        /// <param name="mode">�ԓ`�쐬���[�h 0:�ԓ����쐬</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="updateSecCd">�X�V���_�R�[�h</param>
        /// <param name="paymentAgentCode">�x���S���҃R�[�h</param>
        /// <param name="paymentAgentNm">�x���S���Җ�</param>
        /// <param name="addUpADate">�v���</param>
        /// <param name="paymentSlp">�x���`�[�}�X�^(�ԓ`�ɕύX���鍕�`)</param>
        /// <param name="akaPaymentShipNo">�x���`�[�ԍ�(�ԓ`)</param>
        /// <param name="message">�G���[���������b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note		: �x���`�[�̐ԓ`���쐬�����܂��B</br>
        /// <br>Programmer	: 30414 �E �K�j</br>
        /// <br>Date		: 2008/07/08</br>
        /// </remarks>
        public int RedCreatePaymentSlp(int mode, 
                                       string enterpriseCode, 
                                       string updateSecCd, 
                                       string paymentAgentCode, 
                                       string paymentAgentNm, 
                                       int addUpADate, 
                                       PaymentSlp paymentSlp, 
                                       out int akaPaymentShipNo, 
                                       out string message)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            akaPaymentShipNo = 0;
            message = "";

            try
            {
                //=====================================
                // �ԓ����쐬����
                //=====================================
                ArrayList paymentDataWorkList;
                status = _paymentSlpAcs.RedCreate(mode,
                                                  enterpriseCode,
                                                  updateSecCd,
                                                  paymentAgentCode,
                                                  paymentAgentNm,
                                                  TDateTime.LongDateToDateTime(addUpADate),
                                                  paymentSlp.PaymentSlipNo,
                                                  out paymentDataWorkList);

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // �G���[����
                    message = _paymentSlpAcs.ErrorMessage;
                    return status;
                }

                //=====================================
                // �x���`�[�ꗗ�X�V����
                //=====================================
                foreach (PaymentDataWork paymentDataWork in paymentDataWorkList)
                {
                    // �ԓ`���̍��`�Ɛԓ`�����X�g�ɓo�^�E�X�V
                    SetPaymentDataToDataTable(CopyToPaymentSlpFromPaymentSlpWork(paymentDataWork));
                    if (paymentDataWork.DebitNoteDiv == 1)
                    {
                        // �ԓ`�̎x���`�[�ԍ����擾
                        akaPaymentShipNo = paymentDataWork.PaymentSlipNo;
                    }
                }
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                message = ex.Message;
            }

            return status;
        }
        // --- ADD 2008/07/08 ---------------------------------------------------------------------<<<<<

        #region DEL 2008/07/08 Partsman�p�ɕύX
        /* --- DEL 2008/07/08 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// �x���`�[�폜����
        /// </summary>
        /// <param name="paymentSlp">�x���`�[�}�X�^</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note		: �x���`�[�}�X�^���폜���܂��B</br>
        /// <br>Programmer	: 22024 ����@�_�u</br>
        /// <br>Date		: 2006.05.24</br>
        /// </remarks>
        public int DeletePaymentData(PaymentSlp paymentSlp)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            _errorMessage = "";

            // �� 20070213 18322 c MA.NS�p�ɕύX
            //status = _paymentSlpAcs.Delete(paymentSlp.EnterpriseCode, paymentSlp.PaymentSlipNo);

            PaymentSlpWork paymentSlpWork;

            status = _paymentSlpAcs.Delete(paymentSlp.EnterpriseCode, paymentSlp.PaymentSlipNo, out paymentSlpWork);
            // �� 20070213 18322 c
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        RemovePaymentDataFromDataTable(paymentSlp);

                        // �� 20070213 18322 c MA.NS�p�ɕύX
                        if (paymentSlpWork != null)
                        {
                            // �����E�ςݍ��`�����`�ɖ߂�
                            SetPaymentDataToDataTable(CopyToPaymentSlpFromPaymentSlpWork(paymentSlpWork));
                        }
                        // �� 20070213 18322 c
                        break;
                    }
                default:
                    {
                        _errorMessage = _paymentSlpAcs.ErrorMessage;
                        break;
                    }
            }

            return status;
        }

        /// <summary>
        /// �x���`�[�ԓ`�쐬����
        /// </summary>
        /// <param name="mode">�ԓ`�쐬���[�h 0:�ԓ����쐬</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="updateSecCd">�X�V���_�R�[�h</param>
        /// <param name="paymentAgentCode">�x���S���҃R�[�h</param>
        /// <param name="paymentAgentNm">�x���S���Җ�</param>
        /// <param name="addUpADate">�v���</param>
        /// <param name="paymentSlp">�x���`�[�}�X�^(�ԓ`�ɕύX���鍕�`)</param>
        /// <param name="akaPaymentShipNo">�x���`�[�ԍ�(�ԓ`)</param>
        /// <param name="message">�G���[���������b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note		: �x���`�[�̐ԓ`���쐬�����܂��B</br>
        /// <br>Programmer	: 18322 �ؑ� ����</br>
        /// <br>Date		: 2006.12.22</br>
        /// </remarks>
        public int RedCreatePaymentSlp(int mode, string enterpriseCode, string updateSecCd, string paymentAgentCode, string paymentAgentNm, int addUpADate, PaymentSlp paymentSlp, out int akaPaymentShipNo, out string message)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            akaPaymentShipNo = 0;
            message = "";

            try
            {
                //=====================================
                // �ԓ����쐬����
                //=====================================
                ArrayList paymentSlpWorkList;
                status = _paymentSlpAcs.RedCreate(mode,
                                                  enterpriseCode,
                                                  updateSecCd,
                                                  paymentAgentCode,
                                                  paymentAgentNm,
                                                  TDateTime.LongDateToDateTime(addUpADate),
                                                  paymentSlp.PaymentSlipNo,
                                                  out paymentSlpWorkList);
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // �G���[����
                    message = _paymentSlpAcs.ErrorMessage;
                    return status;
                }

                //=====================================
                // �x���`�[�ꗗ�X�V����
                //=====================================
                foreach (PaymentSlpWork paymentSlpWork in paymentSlpWorkList)
				{
                    // �ԓ`���̍��`�Ɛԓ`�����X�g�ɓo�^�E�X�V

                    SetPaymentDataToDataTable(CopyToPaymentSlpFromPaymentSlpWork(paymentSlpWork));
                    if (paymentSlpWork.DebitNoteDiv == 1)
                    {
                        // �ԓ`�̎x���`�[�ԍ����擾
                        akaPaymentShipNo = paymentSlpWork.PaymentSlipNo;
                    }
                }
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                message = ex.Message;
            }

            return status;
        }
           --- DEL 2008/07/08 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/07/08 Partsman�p�ɕύX
        
        /// <summary>
		/// �x���f�[�^�Ǎ�����
		/// </summary>
		/// <param name="paymentSlp">�x���`�[�}�X�^</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="paymentSlipNo">�x���`�[�ԍ�</param>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note		: �x���`�[�}�X�^��ǂݍ��݂܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2006.05.24</br>
		/// </remarks>
		public int ReadPaymentData(out PaymentSlp paymentSlp, string enterpriseCode, int paymentSlipNo)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			_errorMessage = "";

			status = _paymentSlpAcs.Read(out paymentSlp, enterpriseCode, paymentSlipNo);
			switch (status)
			{
				case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
				case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
				{
					break;
				}
				default:
				{
					_errorMessage = _paymentSlpAcs.ErrorMessage;
					break;
				}
			}

			return status;
		}

		/// <summary>
		/// �x�����z���擾����
		/// </summary>
		/// <param name="searchPaymentParameter">�����p�����[�^</param>
		/// <param name="suplierPayParam">�x�����z���}�X�^</param>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note		: �x�����z�����擾���܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2006.05.24</br>
		/// </remarks>
		public int ReadCustomPaymentInfo(SearchPaymentParameter searchPaymentParameter, out SearchSuplierPayRet suplierPayParam)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			suplierPayParam = null;
			try
			{
				// �d������/�x�����z���擾����
				status = this.GetCustomPaymentInfo2(searchPaymentParameter, out suplierPayParam);
			}
			catch (Exception ex)
			{
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
				_errorMessage = ex.Message;
			}

			return status;
		}

        /// <summary>
        /// �d�����擾����
        /// </summary>
        /// <param name="supplier">�d�����</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="supplierCode">�d����R�[�h</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note		: �w�蓾�Ӑ�̎d�������擾���܂��B</br>
        /// <br>Programmer	: 30414 �E �K�j</br>
        /// <br>Date		: 2008/07/08</br>
        /// </remarks>
        public int GetCustSuppli(out Supplier supplier, string enterpriseCode, int supplierCode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            supplier = new Supplier();

            try
            {
                status = this._suppliAcs.Read(out supplier, enterpriseCode, supplierCode);
            }
            catch
            {
                status = -1;
            }

            return (status);
        }

        #region DEL 2008/07/08 Partsman�p�ɕύX
        /* --- DEL 2008/07/08 --------------------------------------------------------------------->>>>>
		/// <summary>
		/// ���Ӑ�擾����
		/// </summary>
        /// <param name="customerInfo">���Ӑ���</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="customerCode">���Ӑ�R�[�h</param>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note		: �w�蓾�Ӑ�̓��Ӑ�����擾���܂��B</br>
		/// <br>Programmer	: 18322 T.Kimura</br>
		/// <br>Date		: 2007.07.25</br>
		/// </remarks>
		public int GetCustomerInfo(out CustomerInfo customerInfo, string enterpriseCode, int customerCode)
		{
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            customerInfo = null;
            CustSuppli   customerSuppli;
            status = this._customerInfoAcs.ReadStaticMemoryData(out customerInfo
                                                               ,out customerSuppli
                                                               ,    enterpriseCode
                                                               ,    customerCode);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
            {
                // �f�[�^�����̏ꍇ�́ADB����ǂݍ���
                status = this._customerInfoAcs.ReadDBDataWithCustSuppli(    ConstantManagement.LogicalMode.GetData0
                                                                       ,    enterpriseCode
                                                                       ,    customerCode
                                                                       ,    true
                                                                       ,out customerInfo
                                                                       ,out customerSuppli);

            }

			return status;
		}
           --- DEL 2008/07/08 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/07/08 Partsman�p�ɕύX

        #region PrivateMethod
        /// <summary>
		/// �x���`�[�ꗗDataTable�쐬����
		/// </summary>
		/// <param name="tableNm">�f�[�^�e�[�u��</param>
		/// <remarks>
		/// <br>Note		: �x���`�[�ꗗ�p�̃f�[�^�e�[�u���X�L�[�}���쐬���܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2006.05.24</br>
        /// <br>UpdateNote  : 2006.12.22 �ؑ� ����</br>
        /// <br>              �g��.NS�p�ɃC���Z���e�B�u�i���x�[�g�x���z�j��ǉ�</br>
        /// <br>UpdateNote  : 2012/12/24 ���N</br>
        /// <br>�Ǘ��ԍ�    : 10806793-00 2013/03/13�z�M��</br>
        /// <br>              Redmine#33741�̑Ή�</br>
		/// </remarks>
		private DataTable CreatePaymentInfoDataTable(string tableNm)
		{
			// �f�[�^�e�[�u���̗��`
			DataTable dt = new DataTable(tableNm);

			dt.Columns.Add(COL_PAYMENTSLP_PAYMENTSLIPNO,		typeof(string));	// �x���`�[�ԍ�
			dt.Columns.Add(COL_PAYMENTSLP_PAYMENTDATE,			typeof(string));	// �x�����t
            dt.Columns.Add(COL_PAYMENTSLP_ADDUPADATE,           typeof(string));	// �v����t     // 2007.09.05 add
            dt.Columns.Add(COL_PAYMENTSLP_PAYMENTMONEYKINDNAME,	typeof(string));	// �x�����햼��
			dt.Columns.Add(COL_PAYMENTSLP_PAYMENT,				typeof(long));		// �x�����z
			dt.Columns.Add(COL_PAYMENTSLP_FEEPAYMENT,			typeof(long));		// �萔���x���z
			dt.Columns.Add(COL_PAYMENTSLP_DISCOUNTPAYMENT,		typeof(long));		// �l���x���z
            // �� 20061222 18322 a �g��.NS�p�ɃC���Z���e�B�u��ǉ�
            //dt.Columns.Add(COL_PAYMENTSLP_REBATEPAYMENT,        typeof(long));      // �C���Z���e�B�u�i���x�[�g�x���z�j // 2007.09.05 hikita del
            // �� 20061222 18322 a
			dt.Columns.Add(COL_PAYMENTSLP_PAYMENTTOTAL,			typeof(long));		// �x�����z�v
			dt.Columns.Add(COL_PAYMENTSLP_OUTLINE,				typeof(string));	// �`�[�E�v
			dt.Columns.Add(COL_PAYMENTSLP_FINISHEDFLG,			typeof(string));	// ���ς݃t���O
            // �� 20061222 18322 a �g��.NS�p�ɐԓ`�敪��ǉ�
            dt.Columns.Add(COL_PAYMENTSLP_DEBITNOTEDIV,         typeof(int));       // �ԓ`
            // �� 20061222 18322 a

            // ADD 2010/03/26 MANTIS�Ή�[15201]�F�x���ꗗ��ʂɢ���͒S���ң��\���֕ύX ---------->>>>>
            dt.Columns.Add(COL_PAYMENT_INPUT_AGENT_NM, typeof(string)); // �x�����͎Җ���
            // ADD 2010/03/26 MANTIS�Ή�[15201]�F�x���ꗗ��ʂɢ���͒S���ң��\���֕ύX ----------<<<<<
            // ----- ADD ���N 2012/12/24 Redmine#33741 ----->>>>>
            dt.Columns.Add(COL_PAYMENTSLP_SUPPLIERCDRF, typeof(int));
            dt.Columns.Add(COL_PAYMENTSLP_SUPPLIERNAME, typeof(string));
            // ------ ADD ���N 2012/12/24 Redmine#33741 -----<<<<<
			return dt;
		}

        // ----- ADD ���N 2012/12/24 Redmine#33741 ----- >>>>>
        /// <summary>
        /// �x���`�[�ꗗDataTable�쐬����(�x���`�[�����K�C�h�ꗗ�p)
        /// </summary>
        /// <param name="tableNm">�f�[�^�e�[�u��</param>
        /// <remarks>
        /// <br>Note		: �x���`�[�ꗗ�p�̃f�[�^�e�[�u���X�L�[�}���쐬���܂��B</br>
        /// <br>Programmer	: ���N</br>
        /// <br>Date		: 2012/12/24</br>
        /// <br>�Ǘ��ԍ�    : 10806793-00 2013/03/13�z�M��</br>
        /// <br>              Redmine#33741�̑Ή�</br>
        /// </remarks>
        private DataTable CreatePaymentInfoDataTableUH(string tableNm)
        {
            // �f�[�^�e�[�u���̗��`
            DataTable dt = new DataTable(tableNm);

            dt.Columns.Add(COL_PAYMENTSLP_PAYMENTSLIPNO, typeof(string));	// �x���`�[�ԍ�
            dt.Columns.Add(COL_PAYMENTSLP_PAYMENTDATE, typeof(string));	// �x�����t
            dt.Columns.Add(COL_PAYMENTSLP_ADDUPADATE, typeof(string));	// �v����t     // 2007.09.05 add
            dt.Columns.Add(COL_PAYMENTSLP_PAYMENTMONEYKINDNAME, typeof(string));	// �x�����햼��
            dt.Columns.Add(COL_PAYMENTSLP_PAYMENT, typeof(long));		// �x�����z
            dt.Columns.Add(COL_PAYMENTSLP_FEEPAYMENT, typeof(long));		// �萔���x���z
            dt.Columns.Add(COL_PAYMENTSLP_DISCOUNTPAYMENT, typeof(long));		// �l���x���z
            dt.Columns.Add(COL_PAYMENTSLP_PAYMENTTOTAL, typeof(long));		// �x�����z�v
            dt.Columns.Add(COL_PAYMENTSLP_OUTLINE, typeof(string));	// �`�[�E�v
            dt.Columns.Add(COL_PAYMENTSLP_FINISHEDFLG, typeof(string));	// ���ς݃t���O
            dt.Columns.Add(COL_PAYMENTSLP_DEBITNOTEDIV, typeof(int));       // �ԓ`
            dt.Columns.Add(COL_PAYMENT_INPUT_AGENT_NM, typeof(string)); // �x�����͎Җ���
            dt.Columns.Add(COL_PAYMENTSLP_SUPPLIERCDRF, typeof(int));//�d����R�[�h
            dt.Columns.Add(COL_PAYMENTSLP_SUPPLIERNAME, typeof(string));//�d���於
            return dt;
        }

        /// <summary>
        /// �x���`�[�ꗗDataRow�쐬����(�`�[�����K�C�h�p)
        /// </summary>
        /// <param name="paymentSlp">�x���`�[�}�X�^</param>
        /// <remarks>
        /// <br>Note		: �x���`�[�ꗗ�p�̍s���쐬�E�ǉ����܂��B</br>
        /// <br>Programmer	: ���N</br>
        /// <br>Date		: 2012/12/24</br>
        /// <br>�Ǘ��ԍ�    : 10806793-00 2013/03/13�z�M��</br>
        /// <br>              Redmine#33741�̑Ή�</br>
        /// </remarks>
        private void SetPaymentDataToDataTableUH(PaymentSlp paymentSlp)
        {
            // �x���`�[�}�X�^��HashTable�Ɋm��
            _paymentSlpHashTable[paymentSlp.PaymentSlipNo] = paymentSlp;

            DataRow dr = null;
            foreach (DataRow wkRow in _dtPaymentInfoUH.Rows)
            {
                int paymentSlipNo = TStrConv.StrToIntDef(wkRow[COL_PAYMENTSLP_PAYMENTSLIPNO].ToString(), -1);
                if (paymentSlp.PaymentSlipNo == paymentSlipNo)
                {
                    dr = wkRow;
                    break;
                }
            }
            if (dr == null)
            {
                dr = _dtPaymentInfoUH.NewRow();
                _dtPaymentInfoUH.Rows.Add(dr);
            }

            // �x���`�[�ԍ�
            dr[PaymentSlpSearch.COL_PAYMENTSLP_PAYMENTSLIPNO] = paymentSlp.PaymentSlipNo.ToString("000000000");
            // �x�����t
            dr[PaymentSlpSearch.COL_PAYMENTSLP_PAYMENTDATE] = paymentSlp.PaymentDate.ToString("yyyy/MM/dd");
            // �v����t
            dr[PaymentSlpSearch.COL_PAYMENTSLP_ADDUPADATE] = paymentSlp.AddUpADate.ToString("yyyy/MM/dd");  

            List<string> moneyKindNameList = new List<string>();
            for (int index = 0; index < paymentSlp.PaymentDtl.Length; index++)
            {
                if (!string.IsNullOrEmpty(paymentSlp.MoneyKindNameDtl[index]))
                {
                    moneyKindNameList.Add(paymentSlp.MoneyKindNameDtl[index]);
                }
            }
            switch (moneyKindNameList.Count)
            {
                case 0:
                    dr[PaymentSlpSearch.COL_PAYMENTSLP_PAYMENTMONEYKINDNAME] = "";
                    break;
                case 1:
                    dr[PaymentSlpSearch.COL_PAYMENTSLP_PAYMENTMONEYKINDNAME] = moneyKindNameList[0];
                    break;
                case 2:
                    dr[PaymentSlpSearch.COL_PAYMENTSLP_PAYMENTMONEYKINDNAME] = moneyKindNameList[0] + "�E" + moneyKindNameList[1];
                    break;
                default:
                    dr[PaymentSlpSearch.COL_PAYMENTSLP_PAYMENTMONEYKINDNAME] = moneyKindNameList[0] + "�E" + moneyKindNameList[1] + "�ق�";
                    break;
            }
            // �x�����z
            dr[PaymentSlpSearch.COL_PAYMENTSLP_PAYMENT] = paymentSlp.Payment;
            // �萔���x���z
            dr[PaymentSlpSearch.COL_PAYMENTSLP_FEEPAYMENT] = paymentSlp.FeePayment;
            // �l���x���z
            dr[PaymentSlpSearch.COL_PAYMENTSLP_DISCOUNTPAYMENT] = paymentSlp.DiscountPayment;
            // �ԓ`
            dr[PaymentSlpSearch.COL_PAYMENTSLP_DEBITNOTEDIV] = paymentSlp.DebitNoteDiv;
            // �x�����z�v
            dr[PaymentSlpSearch.COL_PAYMENTSLP_PAYMENTTOTAL] = paymentSlp.PaymentTotal;
            // �`�[�E�v
            dr[PaymentSlpSearch.COL_PAYMENTSLP_OUTLINE] = paymentSlp.Outline;
            // �x���`�[�}�X�^
            if (TDateTime.DateTimeToLongDate(paymentSlp.AddUpADate) > paymentSlp.CAddUpUpdDate)
            {
                dr[PaymentSlpSearch.COL_PAYMENTSLP_FINISHEDFLG] = "";
            }
            else
            {
                dr[PaymentSlpSearch.COL_PAYMENTSLP_FINISHEDFLG] = "�Y";
            }

            // �� 20070801 18322 �����Y��ǉ�
            if (paymentSlp.AddUpADate < this._lastMonthlyAddUpDay)
            {
                // �ŏI�����X�V���ȑO�̎x�����̂Ƃ�
                dr[PaymentSlpSearch.COL_PAYMENTSLP_FINISHEDFLG] = "�Y";
            }
            // FIXME:�x�����͎Җ���
            dr[PaymentSlpSearch.COL_PAYMENT_INPUT_AGENT_NM] = paymentSlp.PaymentAgentName;
            dr[PaymentSlpSearch.COL_PAYMENTSLP_SUPPLIERCDRF] = paymentSlp.SupplierCd; // �d����R�[�h
            dr[PaymentSlpSearch.COL_PAYMENTSLP_SUPPLIERNAME] = paymentSlp.SupplierSnm;// �d���於
        }
        // ----- ADD ���N 2012/12/24 Redmine#33741 ----- <<<<<

		/// <summary>
		/// �x���`�[�ꗗDataRow�쐬����
		/// </summary>
		/// <param name="paymentSlp">�x���`�[�}�X�^</param>
		/// <remarks>
		/// <br>Note		: �x���`�[�ꗗ�p�̍s���쐬�E�ǉ����܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2006.05.24</br>
        /// <br>UpdateNote  : 2006.12.22 �ؑ� ����</br>
        /// <br>              �g��.NS�p�ɃC���Z���e�B�u�i���x�[�g�x���z�j��ǉ�</br>
        /// <br>UpdateNote  : 2012/12/24 ���N</br>
        /// <br>�Ǘ��ԍ�    : 10806793-00 2013/03/13�z�M��</br>
        /// <br>              Redmine#33741�̑Ή�</br>
        /// </remarks>
		private void SetPaymentDataToDataTable(PaymentSlp paymentSlp)
		{
			// �x���`�[�}�X�^��HashTable�Ɋm��
			_paymentSlpHashTable[paymentSlp.PaymentSlipNo] = paymentSlp;

			DataRow dr = null;
			foreach (DataRow wkRow in _dtPaymentInfo.Rows)
			{
				int paymentSlipNo = TStrConv.StrToIntDef(wkRow[COL_PAYMENTSLP_PAYMENTSLIPNO].ToString(), -1);
				if (paymentSlp.PaymentSlipNo == paymentSlipNo)
				{
					dr = wkRow;
					break;
				}
			}
			if (dr == null)
			{
				dr = _dtPaymentInfo.NewRow();
				_dtPaymentInfo.Rows.Add(dr);
			}

			// �x���`�[�ԍ�
			dr[PaymentSlpSearch.COL_PAYMENTSLP_PAYMENTSLIPNO]		= paymentSlp.PaymentSlipNo.ToString("000000000");
			// �x�����t
			dr[PaymentSlpSearch.COL_PAYMENTSLP_PAYMENTDATE]			= paymentSlp.PaymentDate.ToString("yyyy/MM/dd");
            // �v����t
            dr[PaymentSlpSearch.COL_PAYMENTSLP_ADDUPADATE]          = paymentSlp.AddUpADate.ToString("yyyy/MM/dd");    // 2007.09.05 add

            // �x�����햼��
            // --- CHG 2008/07/08 --------------------------------------------------------------------->>>>>
            //if (paymentSlp.AutoPayment == 0)  // �ʏ�x��   //2007.09.05 add
            //{
            //    dr[PaymentSlpSearch.COL_PAYMENTSLP_PAYMENTMONEYKINDNAME] = paymentSlp.PaymentMoneyKindName;
            //}
            //// 2007.09.05 add start -------------------------------->>
            //else
            //{
            //    dr[PaymentSlpSearch.COL_PAYMENTSLP_PAYMENTMONEYKINDNAME] = paymentSlp.PaymentMoneyKindName + "(����)";
            //}
            List<string> moneyKindNameList = new List<string>();
            for (int index = 0; index < paymentSlp.PaymentDtl.Length; index++)
            {
                // DEL 2010/03/26 MANTIS�Ή�[15200]�F0�~�x���ۑ����ɢ�����ʣ��\�����A�I����ɓo�^�֕ύX ---------->>>>>
                //if (paymentSlp.PaymentDtl[index] != 0)
                // DEL 2010/03/26 MANTIS�Ή�[15200]�F0�~�x���ۑ����ɢ�����ʣ��\�����A�I����ɓo�^�֕ύX ----------<<<<<
                // ADD 2010/03/26 MANTIS�Ή�[15200]�F0�~�x���ۑ����ɢ�����ʣ��\�����A�I����ɓo�^�֕ύX ---------->>>>>
                if (!string.IsNullOrEmpty(paymentSlp.MoneyKindNameDtl[index]))
                // ADD 2010/03/26 MANTIS�Ή�[15200]�F0�~�x���ۑ����ɢ�����ʣ��\�����A�I����ɓo�^�֕ύX ----------<<<<<
                {
                    moneyKindNameList.Add(paymentSlp.MoneyKindNameDtl[index]);
                }
            }
            switch (moneyKindNameList.Count)
            {
                case 0:
                    dr[PaymentSlpSearch.COL_PAYMENTSLP_PAYMENTMONEYKINDNAME] = "";
                    break;
                case 1:
                    dr[PaymentSlpSearch.COL_PAYMENTSLP_PAYMENTMONEYKINDNAME] = moneyKindNameList[0];
                    break;
                case 2:
                    dr[PaymentSlpSearch.COL_PAYMENTSLP_PAYMENTMONEYKINDNAME] = moneyKindNameList[0] + "�E" + moneyKindNameList[1];
                    break;
                default:
                    dr[PaymentSlpSearch.COL_PAYMENTSLP_PAYMENTMONEYKINDNAME] = moneyKindNameList[0] + "�E" + moneyKindNameList[1] + "�ق�";
                    break;
            }
            // --- CHG 2008/07/08 ---------------------------------------------------------------------<<<<<

            // 2007.09.05 add end ----------------------------------<<
			// �x�����z
			dr[PaymentSlpSearch.COL_PAYMENTSLP_PAYMENT]				= paymentSlp.Payment;
			// �萔���x���z
			dr[PaymentSlpSearch.COL_PAYMENTSLP_FEEPAYMENT]			= paymentSlp.FeePayment;
			// �l���x���z
			dr[PaymentSlpSearch.COL_PAYMENTSLP_DISCOUNTPAYMENT]		= paymentSlp.DiscountPayment;
            // �� 20061222 18322 a 
            // �C���Z���e�B�u(���x�[�g�x���z)
            //dr[PaymentSlpSearch.COL_PAYMENTSLP_REBATEPAYMENT] = paymentSlp.RebatePayment;  // 2007.09.05 hikita del
            // �ԓ`
            dr[PaymentSlpSearch.COL_PAYMENTSLP_DEBITNOTEDIV] = paymentSlp.DebitNoteDiv;
            // �� 20061222 18322 a
			// �x�����z�v
			dr[PaymentSlpSearch.COL_PAYMENTSLP_PAYMENTTOTAL]		= paymentSlp.PaymentTotal;
			// �`�[�E�v
            dr[PaymentSlpSearch.COL_PAYMENTSLP_OUTLINE] = paymentSlp.Outline;
			// �x���`�[�}�X�^
			if (TDateTime.DateTimeToLongDate(paymentSlp.AddUpADate) > paymentSlp.CAddUpUpdDate)
			{
				dr[PaymentSlpSearch.COL_PAYMENTSLP_FINISHEDFLG] = "";
			}
			else
			{
				dr[PaymentSlpSearch.COL_PAYMENTSLP_FINISHEDFLG] = "�Y";
			}

            // �� 20070801 18322 �����Y��ǉ�
            if (paymentSlp.AddUpADate < this._lastMonthlyAddUpDay)
            {
                // �ŏI�����X�V���ȑO�̎x�����̂Ƃ�
                dr[PaymentSlpSearch.COL_PAYMENTSLP_FINISHEDFLG] = "�Y";
            }
            // �� 20070801 18322 �����Y��ǉ�

            // ADD 2010/03/26 MANTIS�Ή�[15201]�F�x���ꗗ��ʂɢ���͒S���ң��\���֕ύX ---------->>>>>
            // FIXME:�x�����͎Җ���
            dr[PaymentSlpSearch.COL_PAYMENT_INPUT_AGENT_NM] = paymentSlp.PaymentAgentName;
            // ADD 2010/03/26 MANTIS�Ή�[15201]�F�x���ꗗ��ʂɢ���͒S���ң��\���֕ύX ----------<<<<<
            // ----- ADD ���N 2012/12/24 Redmine#33741 ----->>>>>
            dr[PaymentSlpSearch.COL_PAYMENTSLP_SUPPLIERCDRF] = paymentSlp.SupplierCd;
            dr[PaymentSlpSearch.COL_PAYMENTSLP_SUPPLIERNAME] = paymentSlp.SupplierSnm;
            // ----- ADD ���N 2012/12/24 Redmine#33741 -----<<<<<
        }

		/// <summary>
		/// �x���`�[�ꗗDataRow�폜����
		/// </summary>
		/// <param name="paymentSlp">�x���`�[�}�X�^</param>
		/// <remarks>
		/// <br>Note		: �x���`�[�ꗗ�p�̍s���폜���܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2006.05.24</br>
		/// </remarks>
		private void RemovePaymentDataFromDataTable(PaymentSlp paymentSlp)
		{
			// �x���`�[�}�X�^��HashTable����폜
			if (_paymentSlpHashTable.ContainsKey(paymentSlp.PaymentSlipNo))
			{
				_paymentSlpHashTable.Remove(paymentSlp.PaymentSlipNo);
			}
			for (int ix = 0 ; ix != _dtPaymentInfo.Rows.Count ; ix++)
			{
				DataRow wkRow = _dtPaymentInfo.Rows[ix];
				int paymentSlipNo = TStrConv.StrToIntDef(wkRow[PaymentSlpSearch.COL_PAYMENTSLP_PAYMENTSLIPNO].ToString(), 0);
				if (paymentSlp.PaymentSlipNo == paymentSlipNo)
				{
					_dtPaymentInfo.Rows.RemoveAt(ix);
					break;
				}
			}
        }

        #region DEL 2008/07/08 Partsman�p�ɕύX
        /* --- DEL 2008/07/08 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// �d������^�x�����z���擾����
        /// </summary>
        /// <param name="searchPaymentParameter">�����p�����[�^</param>
        /// <param name="custSuppli">�d������}�X�^</param>
        /// <param name="suplierPayParam">�x�����z���}�X�^</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note		: �d������Ǝx�����z�����擾���܂��B</br>
        /// <br>Programmer	: 22024 ����@�_�u</br>
        /// <br>Date		: 2006.05.24</br>
        /// </remarks>
        private int GetCustomPaymentInfo1(SearchPaymentParameter searchPaymentParameter, out SearchCustSuppliRet custSuppli, out SearchSuplierPayRet suplierPayParam)
        {
            // �� 20070520 18322 a MK.NS�p�ɕύX
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            custSuppli = null;
            suplierPayParam = null;

            //==========================
            // ���Ӑ���擾
            //==========================
            CustomerInfo customerInfo;
            CustSuppli customerSuppli;
            status = this._customerInfoAcs.ReadStaticMemoryData(out customerInfo
                                                               , out customerSuppli
                                                               , searchPaymentParameter.EnterpriseCode
                                                               , searchPaymentParameter.CustomerCode);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
            {
                // �f�[�^�����̏ꍇ�́ADB����ǂݍ���
                status = this._customerInfoAcs.ReadDBDataWithCustSuppli(ConstantManagement.LogicalMode.GetData0
                                                                       , searchPaymentParameter.EnterpriseCode
                                                                       , searchPaymentParameter.CustomerCode
                                                                       , true
                                                                       , out customerInfo
                                                                       , out customerSuppli);

            }

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    if (_searchCustSuppliRet == null)
                    {
                        _searchCustSuppliRet = new SearchCustSuppliRet();
                    }

                    // ���Ӑ�R�[�h
                    _searchCustSuppliRet.CustomerCode = customerInfo.CustomerCode;
                    // ����2
                    _searchCustSuppliRet.Name = customerInfo.Name;
                    // ����2
                    _searchCustSuppliRet.Name2 = customerInfo.Name2;
                    // �J�i
                    _searchCustSuppliRet.Kana = customerInfo.Kana;
                    // ����
                    _searchCustSuppliRet.SNm = customerInfo.CustomerSnm;

                    // ��A����敪
                    _searchCustSuppliRet.MainContactCode = customerInfo.MainContactCode;
                    // FAX�ԍ��i����j
                    _searchCustSuppliRet.HomeFaxNo = customerInfo.HomeFaxNo;
                    // �d�b�ԍ��i����j
                    _searchCustSuppliRet.HomeTelNo = customerInfo.HomeTelNo;
                    // FAX�ԍ��i�Ζ���j
                    _searchCustSuppliRet.OfficeFaxNo = customerInfo.OfficeFaxNo;
                    // �d�b�ԍ��i�Ζ���j
                    _searchCustSuppliRet.OfficeTelNo = customerInfo.OfficeTelNo;
                    // �d�b�ԍ��i���̑��j
                    _searchCustSuppliRet.OthersTelNo = customerInfo.OthersTelNo;
                    // �d�b�ԍ��i�g�сj
                    _searchCustSuppliRet.PortableTelNo = customerInfo.PortableTelNo;

                    // �O���d����敪
                    _searchCustSuppliRet.OsrcSupplierDivCd = 0;
                    // �x���� 
                    _searchCustSuppliRet.PaymentDay = customerSuppli.PaymentDay;
                    // �x�����敪
                    _searchCustSuppliRet.PaymentMonthCode = customerSuppli.PaymentMonthCode;
                    // �x��������
                    _searchCustSuppliRet.PaymentMonthName = customerSuppli.PaymentMonthName;

                    // �d�������œ]�ŕ�������
                    _searchCustSuppliRet.SuppCTaxLayMethodNm = customerSuppli.SuppCTaxLayMethodNm;
                    // ����
                    _searchCustSuppliRet.TotalDay = customerInfo.TotalDay;

                    // �x����R�[�h
                    _searchCustSuppliRet.PayeeCode = customerSuppli.PayeeCode;

                    // �x����̏����擾
                    status = this._customerInfoAcs.ReadDBDataWithCustSuppli(ConstantManagement.LogicalMode.GetData0
                                                                           , searchPaymentParameter.EnterpriseCode
                                                                           , customerSuppli.PayeeCode
                                                                           , true
                                                                           , out customerInfo
                                                                           , out customerSuppli);
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        _searchCustSuppliRet.PName = customerInfo.Name;
                        _searchCustSuppliRet.PName2 = customerInfo.Name2;
                        _searchCustSuppliRet.PSNm = customerInfo.CustomerSnm;
                    }

                    custSuppli = _searchCustSuppliRet.Clone();

                    status = GetCustomPaymentInfo2(searchPaymentParameter, out suplierPayParam);
                    if ((status == (int)ConstantManagement.DB_Status.ctDB_EOF) ||
                        (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND))
                    {
                        // �d������͑��݂���̂Ő���I���Ƃ���
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }

                    _searchSuplierPayRet = suplierPayParam.Clone();

                    // �x�����ԁi�J�n�j�A�x�����ԁi�I���j
                    _searchCustSuppliRet.StartDateSpan = suplierPayParam.StartDateSpan;
                    _searchCustSuppliRet.EndDateSpan = suplierPayParam.EndDateSpan;

                    custSuppli.StartDateSpan = suplierPayParam.StartDateSpan;
                    custSuppli.EndDateSpan = suplierPayParam.EndDateSpan;

                    break;
                case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                    _searchCustSuppliRet = null;
                    _searchSuplierPayRet = null;
                    custSuppli = _searchCustSuppliRet;
                    suplierPayParam = _searchSuplierPayRet;
                    this._errorMessage = "�w�肳�ꂽ�����ŁA�d����͑��݂��܂���ł����B";
                    break;
                default:
                    this._errorMessage = "�d������̎擾�Ɏ��s���܂����B";
                    break;
            }
            // �� 20070520 18322 a 

            // �� 20070520 18322 d �x�����������̋@�\�Ŏd�����z�E�x�����z�̏W�v�����s����
            //                     �@�\��ύX
            #region �I���W�i���@�\
            //// �p�����[�^������
            //KingetSuplierPayWork kingetSuplierPayWork;
            //custSuppli		= null;
            //suplierPayParam = null;
            //
            //// �x��KINGET����
            //int status = _kingetSuplierPayAcs.Read(
            //	out kingetSuplierPayWork, searchPaymentParameter.EnterpriseCode,
            //	searchPaymentParameter.AddUpSecCode, searchPaymentParameter.CustomerCode, TDateTime.DateTimeToLongDate(searchPaymentParameter.AddUpADate));
            //
            //switch (status)
            //{
            //	case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
            //	{
            //		// �N���X�����o�[�R�s�[�����iKINGET�p�d����x�����z���[�N�N���X�ˎd������N���X�j
            //		_searchCustSuppliRet = (SearchCustSuppliRet)DBAndXMLDataMergeParts.CopyPropertyInClass(kingetSuplierPayWork, typeof(SearchCustSuppliRet)); 
            //		// �N���X�����o�[�R�s�[�����iKINGET�p�d����x�����z���[�N�N���X�ˎx�����z���N���X�j
            //		_searchSuplierPayRet = (SearchSuplierPayRet)DBAndXMLDataMergeParts.CopyPropertyInClass(kingetSuplierPayWork, typeof(SearchSuplierPayRet));
            //	
            //        // �� 20070519 18322 a �O����ߓ���ݒ�
            //        this._cAddUpUpDate = _searchCustSuppliRet.StartDateSpan;
            //        // �� 20070519 18322 a
            //
            //		custSuppli		= _searchCustSuppliRet.Clone();
            //		suplierPayParam = _searchSuplierPayRet.Clone();
            //		break;
            //	}
            //	case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
            //	case (int)ConstantManagement.DB_Status.ctDB_EOF:
            //	{
            //		_searchCustSuppliRet= null;
            //		_searchSuplierPayRet= null;
            //		custSuppli		= _searchCustSuppliRet;
            //		suplierPayParam	= _searchSuplierPayRet;
            //		_errorMessage = "�w�肳�ꂽ�����ŁA�d����͑��݂��܂���ł����B";
            //		break;
            //	}
            //	default:
            //	{
            //		_errorMessage = "�d������̎擾�Ɏ��s���܂����B";
            //		break;
            //	}
            //}
            #endregion
            // �� 20070520 18322 d

            return status;
        }
           --- DEL 2008/07/08 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/07/08 Partsman�p�ɕύX

        /// <summary>
		/// �d������^�x�����z���擾����
		/// </summary>
		/// <param name="searchPaymentParameter">�����p�����[�^</param>
		/// <param name="custSuppli">�d������}�X�^</param>
		/// <param name="suplierPayParam">�x�����z���}�X�^</param>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note		: �d������Ǝx�����z�����擾���܂��B</br>
		/// <br>Programmer	: 30414 �E �K�j</br>
		/// <br>Date		: 2008/07/08</br>
		/// </remarks>
		private int GetCustomPaymentInfo1(SearchPaymentParameter searchPaymentParameter, out SearchCustSuppliRet custSuppli, out SearchSuplierPayRet suplierPayParam)
		{
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            custSuppli = new SearchCustSuppliRet();
            suplierPayParam = new SearchSuplierPayRet();

            //==========================
            // �d������擾
            //==========================
            Supplier supplier;
            
            status = GetCustSuppli(out supplier,
                                     searchPaymentParameter.EnterpriseCode, 
                                     searchPaymentParameter.PayeeCode);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                    {
                        this._searchCustSuppliRet = null;
                        this._searchSuplierPayRet = null;
                        custSuppli = _searchCustSuppliRet;
                        suplierPayParam = _searchSuplierPayRet;
                        this._errorMessage = "�w�肳�ꂽ�����ŁA�d����͑��݂��܂���ł����B";
                        return (status);
                    }
                default:
                    {
                        this._errorMessage = "�d������̎擾�Ɏ��s���܂����B";
                        return (status);
                    }
            }

            if (this._searchCustSuppliRet == null)
            {
                this._searchCustSuppliRet = new SearchCustSuppliRet();
            }

            this._searchCustSuppliRet.SupplierCode = supplier.SupplierCd;                                           // ���Ӑ�R�[�h
            this._searchCustSuppliRet.Name = supplier.SupplierNm1;                                                  // ����1
            this._searchCustSuppliRet.Name2 = supplier.SupplierNm2;                                                 // ����2
            this._searchCustSuppliRet.Kana = supplier.SupplierKana;                                                 // �J�i
            this._searchCustSuppliRet.SNm = supplier.SupplierSnm;                                                   // ����
            this._searchCustSuppliRet.OsrcSupplierDivCd = 0;                                                        // �O���d����敪
            this._searchCustSuppliRet.PaymentDay = supplier.PaymentDay;                                             // �x���� 
            this._searchCustSuppliRet.PaymentMonthCode = supplier.PaymentMonthCode;                                 // �x�����敪
            this._searchCustSuppliRet.PaymentMonthName = supplier.PaymentMonthName;                                 // �x��������
            this._searchCustSuppliRet.SuppCTaxLayMethodNm = Supplier.GetSuppCTaxLayCdName(supplier.SuppCTaxLayCd);  // �d�������œ]�ŕ�������
            this._searchCustSuppliRet.TotalDay = supplier.PaymentTotalDay;                                          // ����
            this._searchCustSuppliRet.PayeeCode = supplier.PayeeCode;                                               // �x����R�[�h
            this._searchCustSuppliRet.PName = supplier.PayeeName;
            this._searchCustSuppliRet.PName2 = supplier.PayeeName2;
            this._searchCustSuppliRet.PSNm = supplier.PayeeSnm;

            custSuppli = this._searchCustSuppliRet.Clone();

            // �x�����z���擾
            status = GetCustomPaymentInfo2(searchPaymentParameter, out suplierPayParam);
            if ((status == (int)ConstantManagement.DB_Status.ctDB_EOF) ||
                (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND))
            {
                // �d������͑��݂���̂Ő���I���Ƃ���
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }

            this._searchSuplierPayRet = suplierPayParam.Clone();

            // �x�����ԁi�J�n�j�A�x�����ԁi�I���j
            this._searchCustSuppliRet.StartDateSpan = suplierPayParam.StartDateSpan;
            this._searchCustSuppliRet.EndDateSpan = suplierPayParam.EndDateSpan;

            custSuppli.StartDateSpan = suplierPayParam.StartDateSpan;
            custSuppli.EndDateSpan = suplierPayParam.EndDateSpan;

            return (status);
		}

		/// <summary>
		/// �x�����z���擾����
		/// </summary>
		/// <param name="searchPaymentParameter">�����p�����[�^</param>
		/// <param name="suplierPayParam">�x�����z���}�X�^</param>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note		: �x�����z�����擾���܂��B</br>
		/// <br>Programmer	: 30414 �E �K�j</br>
		/// <br>Date		: 2006.05.24</br>
        /// <br>UpdateNote  : 2012/09/07 FSI��k�c �G�� �d�������Ή�</br> 
		/// </remarks>
		private int GetCustomPaymentInfo2(SearchPaymentParameter searchPaymentParameter, out SearchSuplierPayRet suplierPayParam)
		{
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            suplierPayParam = new SearchSuplierPayRet();

            string retMsg;

            // �d����x�����z�}�X�^����
            SuplierPayWork suplierPayWork = new SuplierPayWork();
            suplierPayWork.EnterpriseCode = searchPaymentParameter.EnterpriseCode;
            suplierPayWork.AddUpSecCode   = searchPaymentParameter.AddUpSecCode;
            suplierPayWork.PayeeCode      = searchPaymentParameter.PayeeCode;
            //suplierPayWork.SupplierCd = searchPaymentParameter.SupplierCode;
            suplierPayWork.SupplierCd = searchPaymentParameter.PayeeCode;

            suplierPayWork.AddUpDate = GetCurrentTotalDayPayment(searchPaymentParameter.AddUpSecCode, searchPaymentParameter.PayeeCode);
            if (suplierPayWork.AddUpDate == DateTime.MinValue)
            {
                suplierPayWork.AddUpDate = searchPaymentParameter.AddUpADate;
            }

            // �w�肵���x����̎x���������ʂ��擾
            object paraSuplierPayWork = (object)suplierPayWork;
            // --- DEL 2012/09/07 ----------------------------------------->>>>>
            //status = this._iSuplierPayDB.ReadSuplierPay(ref paraSuplierPayWork, out retMsg);
            // --- DEL 2012/09/07 -----------------------------------------<<<<<
            // --- ADD 2012/09/07 ----------------------------------------->>>>>
            if (_supplierSummary)
            {
                // �d�������I�v�V�������L���̏ꍇ
                status = this._iSuplierPayDB.ReadSuplierPayByAddUpSecCode(ref paraSuplierPayWork, out retMsg);
            }
            else
            {
                // �d�������I�v�V�����������̏ꍇ
                status = this._iSuplierPayDB.ReadSuplierPay(ref paraSuplierPayWork, out retMsg);
            }
            // --- ADD 2012/09/07 -----------------------------------------<<<<<



            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // �߂�l�ƃG���[���b�Z�[�W��Ԃ��B
                suplierPayParam = new SearchSuplierPayRet();
                this._errorMessage = retMsg ;
                return (status);
            }

            // �߂�l��ϊ�
            suplierPayWork = paraSuplierPayWork as SuplierPayWork;
            if (suplierPayWork == null)
            {
                suplierPayParam = new SearchSuplierPayRet();
                this._errorMessage = "�w�肳�ꂽ�����ŁA�x�����z���͑��݂��܂���ł����B";
                return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            }

            // �N���X�����o�[�R�s�[����(�x�����z���}�X�^���[�N���x�����z���}�X�^)
            suplierPayParam = new SearchSuplierPayRet();
            suplierPayParam = CopyToSearchSuplierPayRetFromSuplierPayWork(suplierPayWork);

			return (status);
		}

        /// <summary>
        /// �N���X�����o�[�R�s�[�����i�x���`�[�}�X�^���[�N�ˎx���`�[�}�X�^�j
        /// </summary>
        /// <param name="paymentSlpWork">�x���`�[�}�X�^���[�N�N���X</param>
        /// <returns>�x���`�[�}�X�^�N���X</returns>
        /// <remarks>
        /// <br>Note       : �x���`�[�}�X�^���[�N�N���X����x���`�[�}�X�^�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/07/08</br>
        /// </remarks>
        private PaymentSlp CopyToPaymentSlpFromPaymentSlpWork(PaymentDataWork paymentDataWork)
        {
            PaymentSlp paymentSlp = new PaymentSlp();

            paymentSlp.CreateDateTime = paymentDataWork.CreateDateTime;              // �쐬���t
            paymentSlp.UpdateDateTime = paymentDataWork.UpdateDateTime;              // �X�V���t
            paymentSlp.EnterpriseCode = paymentDataWork.EnterpriseCode;              // ��ƃR�[�h
            paymentSlp.FileHeaderGuid = paymentDataWork.FileHeaderGuid;              // GUID
            paymentSlp.UpdEmployeeCode = paymentDataWork.UpdEmployeeCode;            // �X�V�]�ƈ��R�[�h
            paymentSlp.UpdAssemblyId1 = paymentDataWork.UpdAssemblyId1;              // �X�V�A�Z���u��ID1
            paymentSlp.UpdAssemblyId2 = paymentDataWork.UpdAssemblyId2;              // �X�V�A�Z���u��ID2
            paymentSlp.LogicalDeleteCode = paymentDataWork.LogicalDeleteCode;        // �_���폜�敪
            paymentSlp.DebitNoteDiv = paymentDataWork.DebitNoteDiv;                  // �ԓ`�敪
            paymentSlp.PaymentSlipNo = paymentDataWork.PaymentSlipNo;                // �x���`�[�ԍ�
            paymentSlp.SupplierCd = paymentDataWork.SupplierCd;                      // �d����R�[�h
            paymentSlp.SupplierNm1 = paymentDataWork.SupplierNm1;                    // �d���於1
            paymentSlp.SupplierNm2 = paymentDataWork.SupplierNm2;                    // �d���於2
            paymentSlp.SupplierSnm = paymentDataWork.SupplierSnm;                    // �d���旪��
            paymentSlp.PayeeCode = paymentDataWork.PayeeCode;                        // �x����R�[�h
            paymentSlp.PayeeName = paymentDataWork.PayeeName;                        // �x���於��
            paymentSlp.PayeeName2 = paymentDataWork.PayeeName2;                      // �x���於��2
            paymentSlp.PayeeSnm = paymentDataWork.PayeeSnm;                          // �x���旪��
            paymentSlp.PaymentInpSectionCd = paymentDataWork.PaymentInpSectionCd;    // �x�����͋��_�R�[�h
            paymentSlp.AddUpSecCode = paymentDataWork.AddUpSecCode;                  // �v�㋒�_�R�[�h
            paymentSlp.UpdateSecCd = paymentDataWork.UpdateSecCd;                    // �X�V���_�R�[�h
            paymentSlp.PaymentDate = paymentDataWork.PaymentDate;                    // �x�����t
            paymentSlp.AddUpADate = paymentDataWork.AddUpADate;                      // �v����t
            paymentSlp.PaymentTotal = paymentDataWork.PaymentTotal;                  // �x���v
            paymentSlp.Payment = paymentDataWork.Payment;                            // �x�����z
            paymentSlp.FeePayment = paymentDataWork.FeePayment;                      // �萔���x���z
            paymentSlp.DiscountPayment = paymentDataWork.DiscountPayment;            // �l���x���z
            paymentSlp.AutoPayment = paymentDataWork.AutoPayment;                    // �����x���敪
            paymentSlp.DraftDrawingDate = paymentDataWork.DraftDrawingDate;          // ��`�U�o��
            paymentSlp.DebitNoteLinkPayNo = paymentDataWork.DebitNoteLinkPayNo;      // �ԍ��x���A���ԍ�
            paymentSlp.PaymentAgentCode = paymentDataWork.PaymentAgentCode;          // �x���S���҃R�[�h
            paymentSlp.PaymentAgentName = paymentDataWork.PaymentAgentName;          // �x���S���Җ���
            paymentSlp.Outline = paymentDataWork.Outline;                            // �`�[�E�v
            paymentSlp.DraftKind = paymentDataWork.DraftKind;                        // ��`���
            paymentSlp.DraftKindName = paymentDataWork.DraftKindName;                // ��`��ޖ���
            paymentSlp.DraftDivide = paymentDataWork.DraftDivide;                    // ��`�敪
            paymentSlp.DraftDivideName = paymentDataWork.DraftDivideName;            // ��`�敪����
            paymentSlp.DraftNo = paymentDataWork.DraftNo;                            // ��`�ԍ�
            paymentSlp.BankCode = paymentDataWork.BankCode;                          // ��s�R�[�h
            paymentSlp.BankName = paymentDataWork.BankName;                          // ��s����
            paymentSlp.CAddUpUpdDate = TDateTime.DateTimeToLongDate(this._lastAddUpDay);                           // �����v����t
            paymentSlp.PaymentRowNoDtl = new int[10];
            paymentSlp.PaymentRowNoDtl[0] = paymentDataWork.PaymentRowNo1;
            paymentSlp.PaymentRowNoDtl[1] = paymentDataWork.PaymentRowNo2;
            paymentSlp.PaymentRowNoDtl[2] = paymentDataWork.PaymentRowNo3;
            paymentSlp.PaymentRowNoDtl[3] = paymentDataWork.PaymentRowNo4;
            paymentSlp.PaymentRowNoDtl[4] = paymentDataWork.PaymentRowNo5;
            paymentSlp.PaymentRowNoDtl[5] = paymentDataWork.PaymentRowNo6;
            paymentSlp.PaymentRowNoDtl[6] = paymentDataWork.PaymentRowNo7;
            paymentSlp.PaymentRowNoDtl[7] = paymentDataWork.PaymentRowNo8;
            paymentSlp.PaymentRowNoDtl[8] = paymentDataWork.PaymentRowNo9;
            paymentSlp.PaymentRowNoDtl[9] = paymentDataWork.PaymentRowNo10;
            paymentSlp.MoneyKindCodeDtl = new int[10];
            paymentSlp.MoneyKindCodeDtl[0] = paymentDataWork.MoneyKindCode1;
            paymentSlp.MoneyKindCodeDtl[1] = paymentDataWork.MoneyKindCode2;
            paymentSlp.MoneyKindCodeDtl[2] = paymentDataWork.MoneyKindCode3;
            paymentSlp.MoneyKindCodeDtl[3] = paymentDataWork.MoneyKindCode4;
            paymentSlp.MoneyKindCodeDtl[4] = paymentDataWork.MoneyKindCode5;
            paymentSlp.MoneyKindCodeDtl[5] = paymentDataWork.MoneyKindCode6;
            paymentSlp.MoneyKindCodeDtl[6] = paymentDataWork.MoneyKindCode7;
            paymentSlp.MoneyKindCodeDtl[7] = paymentDataWork.MoneyKindCode8;
            paymentSlp.MoneyKindCodeDtl[8] = paymentDataWork.MoneyKindCode9;
            paymentSlp.MoneyKindCodeDtl[9] = paymentDataWork.MoneyKindCode10;
            paymentSlp.MoneyKindNameDtl = new string[10];
            paymentSlp.MoneyKindNameDtl[0] = paymentDataWork.MoneyKindName1;
            paymentSlp.MoneyKindNameDtl[1] = paymentDataWork.MoneyKindName2;
            paymentSlp.MoneyKindNameDtl[2] = paymentDataWork.MoneyKindName3;
            paymentSlp.MoneyKindNameDtl[3] = paymentDataWork.MoneyKindName4;
            paymentSlp.MoneyKindNameDtl[4] = paymentDataWork.MoneyKindName5;
            paymentSlp.MoneyKindNameDtl[5] = paymentDataWork.MoneyKindName6;
            paymentSlp.MoneyKindNameDtl[6] = paymentDataWork.MoneyKindName7;
            paymentSlp.MoneyKindNameDtl[7] = paymentDataWork.MoneyKindName8;
            paymentSlp.MoneyKindNameDtl[8] = paymentDataWork.MoneyKindName9;
            paymentSlp.MoneyKindNameDtl[9] = paymentDataWork.MoneyKindName10;
            paymentSlp.MoneyKindDivDtl = new int[10];
            paymentSlp.MoneyKindDivDtl[0] = paymentDataWork.MoneyKindDiv1;
            paymentSlp.MoneyKindDivDtl[1] = paymentDataWork.MoneyKindDiv2;
            paymentSlp.MoneyKindDivDtl[2] = paymentDataWork.MoneyKindDiv3;
            paymentSlp.MoneyKindDivDtl[3] = paymentDataWork.MoneyKindDiv4;
            paymentSlp.MoneyKindDivDtl[4] = paymentDataWork.MoneyKindDiv5;
            paymentSlp.MoneyKindDivDtl[5] = paymentDataWork.MoneyKindDiv6;
            paymentSlp.MoneyKindDivDtl[6] = paymentDataWork.MoneyKindDiv7;
            paymentSlp.MoneyKindDivDtl[7] = paymentDataWork.MoneyKindDiv8;
            paymentSlp.MoneyKindDivDtl[8] = paymentDataWork.MoneyKindDiv9;
            paymentSlp.MoneyKindDivDtl[9] = paymentDataWork.MoneyKindDiv10;
            paymentSlp.PaymentDtl = new long[10];
            paymentSlp.PaymentDtl[0] = paymentDataWork.Payment1;
            paymentSlp.PaymentDtl[1] = paymentDataWork.Payment2;
            paymentSlp.PaymentDtl[2] = paymentDataWork.Payment3;
            paymentSlp.PaymentDtl[3] = paymentDataWork.Payment4;
            paymentSlp.PaymentDtl[4] = paymentDataWork.Payment5;
            paymentSlp.PaymentDtl[5] = paymentDataWork.Payment6;
            paymentSlp.PaymentDtl[6] = paymentDataWork.Payment7;
            paymentSlp.PaymentDtl[7] = paymentDataWork.Payment8;
            paymentSlp.PaymentDtl[8] = paymentDataWork.Payment9;
            paymentSlp.PaymentDtl[9] = paymentDataWork.Payment10;
            paymentSlp.ValidityTermDtl = new DateTime[10];
            paymentSlp.ValidityTermDtl[0] = paymentDataWork.ValidityTerm1;
            paymentSlp.ValidityTermDtl[1] = paymentDataWork.ValidityTerm2;
            paymentSlp.ValidityTermDtl[2] = paymentDataWork.ValidityTerm3;
            paymentSlp.ValidityTermDtl[3] = paymentDataWork.ValidityTerm4;
            paymentSlp.ValidityTermDtl[4] = paymentDataWork.ValidityTerm5;
            paymentSlp.ValidityTermDtl[5] = paymentDataWork.ValidityTerm6;
            paymentSlp.ValidityTermDtl[6] = paymentDataWork.ValidityTerm7;
            paymentSlp.ValidityTermDtl[7] = paymentDataWork.ValidityTerm8;
            paymentSlp.ValidityTermDtl[8] = paymentDataWork.ValidityTerm9;
            paymentSlp.ValidityTermDtl[9] = paymentDataWork.ValidityTerm10;

            return paymentSlp;
        }

        /// <summary>
        /// �N���X�����o�[�R�s�[�����i�x���`�[�}�X�^�����N���X�ˎx���`�[�}�X�^�N���X�j
        /// </summary>
        /// <param name="searchPaymentSlp">�x���`�[�}�X�^�����N���X</param>
        /// <returns>�x���`�[�}�X�^�N���X</returns>
        /// <remarks>
        /// <br>Note       : �x���`�[�}�X�^�����N���X����x���`�[�}�X�^�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/07/08</br>
        /// </remarks>
        private PaymentSlp CopyToPaymentSlpFromSearchPaymentSlp(SearchPaymentSlp searchPaymentSlp)
        {
            PaymentSlp paymentSlp = new PaymentSlp();

            paymentSlp.CreateDateTime = searchPaymentSlp.CreateDateTime;              // �쐬���t
            paymentSlp.UpdateDateTime = searchPaymentSlp.UpdateDateTime;              // �X�V���t
            paymentSlp.EnterpriseCode = searchPaymentSlp.EnterpriseCode;              // ��ƃR�[�h
            paymentSlp.FileHeaderGuid = searchPaymentSlp.FileHeaderGuid;              // GUID
            paymentSlp.UpdEmployeeCode = searchPaymentSlp.UpdEmployeeCode;            // �X�V�]�ƈ��R�[�h
            paymentSlp.UpdAssemblyId1 = searchPaymentSlp.UpdAssemblyId1;              // �X�V�A�Z���u��ID1
            paymentSlp.UpdAssemblyId2 = searchPaymentSlp.UpdAssemblyId2;              // �X�V�A�Z���u��ID2
            paymentSlp.LogicalDeleteCode = searchPaymentSlp.LogicalDeleteCode;        // �_���폜�敪
            paymentSlp.DebitNoteDiv = searchPaymentSlp.DebitNoteDiv;                  // �ԓ`�敪
            paymentSlp.PaymentSlipNo = searchPaymentSlp.PaymentSlipNo;                // �x���`�[�ԍ�
            paymentSlp.SupplierCd = searchPaymentSlp.SupplierCd;                      // �d����R�[�h
            paymentSlp.SupplierNm1 = searchPaymentSlp.SupplierNm1;                    // �d���於1
            paymentSlp.SupplierNm2 = searchPaymentSlp.SupplierNm2;                    // �d���於2
            paymentSlp.SupplierSnm = searchPaymentSlp.SupplierSnm;                    // �d���旪��
            paymentSlp.PayeeCode = searchPaymentSlp.PayeeCode;                        // �x����R�[�h
            paymentSlp.PayeeName = searchPaymentSlp.PayeeName;                        // �x���於��
            paymentSlp.PayeeName2 = searchPaymentSlp.PayeeName2;                      // �x���於��2
            paymentSlp.PayeeSnm = searchPaymentSlp.PayeeSnm;                          // �x���旪��
            paymentSlp.PaymentInpSectionCd = searchPaymentSlp.PaymentInpSectionCd;    // �x�����͋��_�R�[�h
            paymentSlp.AddUpSecCode = searchPaymentSlp.AddUpSecCode;                  // �v�㋒�_�R�[�h
            paymentSlp.UpdateSecCd = searchPaymentSlp.UpdateSecCd;                    // �X�V���_�R�[�h
            paymentSlp.PaymentDate = searchPaymentSlp.PaymentDate;                    // �x�����t
            paymentSlp.AddUpADate = searchPaymentSlp.AddUpADate;                      // �v����t
            paymentSlp.PaymentTotal = searchPaymentSlp.PaymentTotal;                  // �x���v
            paymentSlp.Payment = searchPaymentSlp.Payment;                            // �x�����z
            paymentSlp.FeePayment = searchPaymentSlp.FeePayment;                      // �萔���x���z
            paymentSlp.DiscountPayment = searchPaymentSlp.DiscountPayment;            // �l���x���z
            paymentSlp.AutoPayment = searchPaymentSlp.AutoPayment;                    // �����x���敪
            paymentSlp.DraftDrawingDate = searchPaymentSlp.DraftDrawingDate;          // ��`�U�o��
            paymentSlp.DebitNoteLinkPayNo = searchPaymentSlp.DebitNoteLinkPayNo;      // �ԍ��x���A���ԍ�
            paymentSlp.PaymentAgentCode = searchPaymentSlp.PaymentAgentCode;          // �x���S���҃R�[�h
            paymentSlp.PaymentAgentName = searchPaymentSlp.PaymentAgentName;          // �x���S���Җ���
            paymentSlp.Outline = searchPaymentSlp.Outline;                            // �`�[�E�v
            paymentSlp.DraftKind = searchPaymentSlp.DraftKind;                        // ��`���
            paymentSlp.DraftKindName = searchPaymentSlp.DraftKindName;                // ��`��ޖ���
            paymentSlp.DraftDivide = searchPaymentSlp.DraftDivide;                    // ��`�敪
            paymentSlp.DraftDivideName = searchPaymentSlp.DraftDivideName;            // ��`�敪����
            paymentSlp.DraftNo = searchPaymentSlp.DraftNo;                            // ��`�ԍ�
            paymentSlp.BankCode = searchPaymentSlp.BankCode;                          // ��s�R�[�h
            paymentSlp.BankName = searchPaymentSlp.BankName;                          // ��s����
            paymentSlp.CAddUpUpdDate = TDateTime.DateTimeToLongDate(this._lastAddUpDay);                           // �����v����t
            paymentSlp.PaymentRowNoDtl = new int[10];
            paymentSlp.PaymentRowNoDtl[0] = searchPaymentSlp.PaymentRowNoDtl[0];
            paymentSlp.PaymentRowNoDtl[1] = searchPaymentSlp.PaymentRowNoDtl[1];
            paymentSlp.PaymentRowNoDtl[2] = searchPaymentSlp.PaymentRowNoDtl[2];
            paymentSlp.PaymentRowNoDtl[3] = searchPaymentSlp.PaymentRowNoDtl[3];
            paymentSlp.PaymentRowNoDtl[4] = searchPaymentSlp.PaymentRowNoDtl[4];
            paymentSlp.PaymentRowNoDtl[5] = searchPaymentSlp.PaymentRowNoDtl[5];
            paymentSlp.PaymentRowNoDtl[6] = searchPaymentSlp.PaymentRowNoDtl[6];
            paymentSlp.PaymentRowNoDtl[7] = searchPaymentSlp.PaymentRowNoDtl[7];
            paymentSlp.PaymentRowNoDtl[8] = searchPaymentSlp.PaymentRowNoDtl[8];
            paymentSlp.PaymentRowNoDtl[9] = searchPaymentSlp.PaymentRowNoDtl[9];
            paymentSlp.MoneyKindCodeDtl = new int[10];
            paymentSlp.MoneyKindCodeDtl[0] = searchPaymentSlp.MoneyKindCodeDtl[0];
            paymentSlp.MoneyKindCodeDtl[1] = searchPaymentSlp.MoneyKindCodeDtl[1];
            paymentSlp.MoneyKindCodeDtl[2] = searchPaymentSlp.MoneyKindCodeDtl[2];
            paymentSlp.MoneyKindCodeDtl[3] = searchPaymentSlp.MoneyKindCodeDtl[3];
            paymentSlp.MoneyKindCodeDtl[4] = searchPaymentSlp.MoneyKindCodeDtl[4];
            paymentSlp.MoneyKindCodeDtl[5] = searchPaymentSlp.MoneyKindCodeDtl[5];
            paymentSlp.MoneyKindCodeDtl[6] = searchPaymentSlp.MoneyKindCodeDtl[6];
            paymentSlp.MoneyKindCodeDtl[7] = searchPaymentSlp.MoneyKindCodeDtl[7];
            paymentSlp.MoneyKindCodeDtl[8] = searchPaymentSlp.MoneyKindCodeDtl[8];
            paymentSlp.MoneyKindCodeDtl[9] = searchPaymentSlp.MoneyKindCodeDtl[9];
            paymentSlp.MoneyKindNameDtl = new string[10];
            paymentSlp.MoneyKindNameDtl[0] = searchPaymentSlp.MoneyKindNameDtl[0];
            paymentSlp.MoneyKindNameDtl[1] = searchPaymentSlp.MoneyKindNameDtl[1];
            paymentSlp.MoneyKindNameDtl[2] = searchPaymentSlp.MoneyKindNameDtl[2];
            paymentSlp.MoneyKindNameDtl[3] = searchPaymentSlp.MoneyKindNameDtl[3];
            paymentSlp.MoneyKindNameDtl[4] = searchPaymentSlp.MoneyKindNameDtl[4];
            paymentSlp.MoneyKindNameDtl[5] = searchPaymentSlp.MoneyKindNameDtl[5];
            paymentSlp.MoneyKindNameDtl[6] = searchPaymentSlp.MoneyKindNameDtl[6];
            paymentSlp.MoneyKindNameDtl[7] = searchPaymentSlp.MoneyKindNameDtl[7];
            paymentSlp.MoneyKindNameDtl[8] = searchPaymentSlp.MoneyKindNameDtl[8];
            paymentSlp.MoneyKindNameDtl[9] = searchPaymentSlp.MoneyKindNameDtl[9];
            paymentSlp.MoneyKindDivDtl = new int[10];
            paymentSlp.MoneyKindDivDtl[0] = searchPaymentSlp.MoneyKindDivDtl[0];
            paymentSlp.MoneyKindDivDtl[1] = searchPaymentSlp.MoneyKindDivDtl[1];
            paymentSlp.MoneyKindDivDtl[2] = searchPaymentSlp.MoneyKindDivDtl[2];
            paymentSlp.MoneyKindDivDtl[3] = searchPaymentSlp.MoneyKindDivDtl[3];
            paymentSlp.MoneyKindDivDtl[4] = searchPaymentSlp.MoneyKindDivDtl[4];
            paymentSlp.MoneyKindDivDtl[5] = searchPaymentSlp.MoneyKindDivDtl[5];
            paymentSlp.MoneyKindDivDtl[6] = searchPaymentSlp.MoneyKindDivDtl[6];
            paymentSlp.MoneyKindDivDtl[7] = searchPaymentSlp.MoneyKindDivDtl[7];
            paymentSlp.MoneyKindDivDtl[8] = searchPaymentSlp.MoneyKindDivDtl[8];
            paymentSlp.MoneyKindDivDtl[9] = searchPaymentSlp.MoneyKindDivDtl[9];
            paymentSlp.PaymentDtl = new long[10];
            paymentSlp.PaymentDtl[0] = searchPaymentSlp.PaymentDtl[0];
            paymentSlp.PaymentDtl[1] = searchPaymentSlp.PaymentDtl[1];
            paymentSlp.PaymentDtl[2] = searchPaymentSlp.PaymentDtl[2];
            paymentSlp.PaymentDtl[3] = searchPaymentSlp.PaymentDtl[3];
            paymentSlp.PaymentDtl[4] = searchPaymentSlp.PaymentDtl[4];
            paymentSlp.PaymentDtl[5] = searchPaymentSlp.PaymentDtl[5];
            paymentSlp.PaymentDtl[6] = searchPaymentSlp.PaymentDtl[6];
            paymentSlp.PaymentDtl[7] = searchPaymentSlp.PaymentDtl[7];
            paymentSlp.PaymentDtl[8] = searchPaymentSlp.PaymentDtl[8];
            paymentSlp.PaymentDtl[9] = searchPaymentSlp.PaymentDtl[9];
            paymentSlp.ValidityTermDtl = new DateTime[10];
            paymentSlp.ValidityTermDtl[0] = searchPaymentSlp.ValidityTermDtl[0];
            paymentSlp.ValidityTermDtl[1] = searchPaymentSlp.ValidityTermDtl[1];
            paymentSlp.ValidityTermDtl[2] = searchPaymentSlp.ValidityTermDtl[2];
            paymentSlp.ValidityTermDtl[3] = searchPaymentSlp.ValidityTermDtl[3];
            paymentSlp.ValidityTermDtl[4] = searchPaymentSlp.ValidityTermDtl[4];
            paymentSlp.ValidityTermDtl[5] = searchPaymentSlp.ValidityTermDtl[5];
            paymentSlp.ValidityTermDtl[6] = searchPaymentSlp.ValidityTermDtl[6];
            paymentSlp.ValidityTermDtl[7] = searchPaymentSlp.ValidityTermDtl[7];
            paymentSlp.ValidityTermDtl[8] = searchPaymentSlp.ValidityTermDtl[8];
            paymentSlp.ValidityTermDtl[9] = searchPaymentSlp.ValidityTermDtl[9];
            
            return paymentSlp;
        }

        /// <summary>
        /// �N���X�����o�[�R�s�[�����i�x�����z���}�X�^���[�N�ˎx�����z���}�X�^�j
        /// </summary>
        /// <param name="suplierPayWork">�x�����z���}�X�^���[�N�N���X</param>
        /// <returns>�x�����z���}�X�^�N���X</returns>
        /// <remarks>
        /// <br>Note       : �x�����z���}�X�^���[�N�N���X����x�����z���}�X�^�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/07/08</br>
        /// </remarks>
        private SearchSuplierPayRet CopyToSearchSuplierPayRetFromSuplierPayWork(SuplierPayWork suplierPayWork)
        {
            SearchSuplierPayRet searchSuplierPayRet = new SearchSuplierPayRet();

            searchSuplierPayRet.CreateDateTime = suplierPayWork.CreateDateTime;             // �쐬����
            searchSuplierPayRet.UpdateDateTime = suplierPayWork.UpdateDateTime;             // �X�V����
            searchSuplierPayRet.EnterpriseCode = suplierPayWork.EnterpriseCode;             // ��ƃR�[�h
            searchSuplierPayRet.FileHeaderGuid = suplierPayWork.FileHeaderGuid;             // GUID
            searchSuplierPayRet.UpdEmployeeCode = suplierPayWork.UpdEmployeeCode;           // �X�V�]�ƈ��R�[�h
            searchSuplierPayRet.UpdAssemblyId1 = suplierPayWork.UpdAssemblyId1;             // �X�V�A�Z���u��ID1
            searchSuplierPayRet.UpdAssemblyId2 = suplierPayWork.UpdAssemblyId2;             // �X�V�A�Z���u��ID2
            searchSuplierPayRet.LogicalDeleteCode = suplierPayWork.LogicalDeleteCode;       // �_���폜�敪
            searchSuplierPayRet.SupplierCode = suplierPayWork.SupplierCd;                   // �d����R�[�h
            searchSuplierPayRet.SupplierName = suplierPayWork.SupplierNm1;                  // �d���於1
            searchSuplierPayRet.SupplierName2 = suplierPayWork.SupplierNm2;                 // �d���於2
            searchSuplierPayRet.SupplierSnm = suplierPayWork.SupplierSnm;                   // �d���旪��
            searchSuplierPayRet.PayeeCode = suplierPayWork.PayeeCode;                       // �x����R�[�h
            searchSuplierPayRet.PayeeName = suplierPayWork.PayeeName;                       // �x���於��
            searchSuplierPayRet.PayeeName2 = suplierPayWork.PayeeName2;                     // �x���於��2
            searchSuplierPayRet.PayeeSnm = suplierPayWork.PayeeSnm;                         // �x���旪��
            searchSuplierPayRet.AddUpDate = suplierPayWork.AddUpDate;                       // �v��N����
            searchSuplierPayRet.AddUpYearMonth = suplierPayWork.AddUpYearMonth;             // �v��N��
            searchSuplierPayRet.LastTimePayment = suplierPayWork.LastTimePayment;           // �O��x�����z
            searchSuplierPayRet.ThisTimePayNrml = suplierPayWork.ThisTimePayNrml;           // ����x�����z�i�ʏ�x���j
            searchSuplierPayRet.ThisTimeFeePayNrml = suplierPayWork.ThisTimeFeePayNrml;     // ����萔���z�i�ʏ�x���j
            searchSuplierPayRet.ThisTimeDisPayNrml = suplierPayWork.ThisTimeDisPayNrml;     // ����l���z�i�ʏ�x���j
            searchSuplierPayRet.ThisTimeTtlBlcPay = suplierPayWork.ThisTimeTtlBlcPay;       // ����J�z�c���i�x���v�j
            searchSuplierPayRet.ItdedOffsetOutTax = suplierPayWork.ItdedOffsetOutTax;       // ���E��O�őΏۊz
            searchSuplierPayRet.ItdedOffsetInTax = suplierPayWork.ItdedOffsetInTax;         // ���E����őΏۊz
            searchSuplierPayRet.ItdedOffsetTaxFree = suplierPayWork.ItdedOffsetTaxFree;     // ���E���ېőΏۊz
            searchSuplierPayRet.OffsetOutTax = suplierPayWork.OffsetOutTax;                 // ���E��O�ŏ����
            searchSuplierPayRet.OffsetInTax = suplierPayWork.OffsetInTax;                   // ���E����ŏ����
            searchSuplierPayRet.ThisTimeStockPrice = suplierPayWork.ThisTimeStockPrice;     // ����d�����z
            searchSuplierPayRet.ThisStcPrcTax = suplierPayWork.ThisStcPrcTax;               // ����d�������
            searchSuplierPayRet.TtlItdedStcOutTax = suplierPayWork.TtlItdedStcOutTax;       // �d���O�őΏۊz���v
            searchSuplierPayRet.TtlItdedStcInTax = suplierPayWork.TtlItdedStcInTax;         // �d�����őΏۊz���v
            searchSuplierPayRet.TtlItdedStcTaxFree = suplierPayWork.TtlItdedStcTaxFree;     // �d����ېőΏۊz���v
            searchSuplierPayRet.TtlStockOuterTax = suplierPayWork.TtlStockOuterTax;         // �d���O�Ŋz���v
            searchSuplierPayRet.TtlStockInnerTax = suplierPayWork.TtlStockInnerTax;         // �d�����Ŋz���v
            searchSuplierPayRet.ThisStckPricRgds = suplierPayWork.ThisStckPricRgds;         // ����ԕi���z
            searchSuplierPayRet.ThisStcPrcTaxRgds = suplierPayWork.ThisStcPrcTaxRgds;       // ����ԕi�����
            searchSuplierPayRet.TtlItdedRetOutTax = suplierPayWork.TtlItdedRetOutTax;       // �ԕi�O�őΏۊz���v
            searchSuplierPayRet.TtlItdedRetInTax = suplierPayWork.TtlItdedRetInTax;         // �ԕi���őΏۊz���v
            searchSuplierPayRet.TtlItdedRetTaxFree = suplierPayWork.TtlItdedRetTaxFree;     // �ԕi��ېőΏۊz���v
            searchSuplierPayRet.TtlRetOuterTax = suplierPayWork.TtlRetOuterTax;             // �ԕi�O�Ŋz���v
            searchSuplierPayRet.TtlRetInnerTax = suplierPayWork.TtlRetInnerTax;             // �ԕi���Ŋz���v
            searchSuplierPayRet.SuppCTaxLayCd = suplierPayWork.SuppCTaxLayCd;               // �d�������œ]�ŕ����R�[�h
            searchSuplierPayRet.SupplierConsTaxRate = suplierPayWork.SupplierConsTaxRate;   // �d�������Őŗ�
            searchSuplierPayRet.FractionProcCd = suplierPayWork.FractionProcCd;             // �[�������敪
            searchSuplierPayRet.StockTotalPayBalance = suplierPayWork.StockTotalPayBalance; // �d�����v�c���i�x���v�j
            searchSuplierPayRet.StockTtl2TmBfBlPay = suplierPayWork.StockTtl2TmBfBlPay;     // �d��2��O�c���i�x���v�j  
            searchSuplierPayRet.StockTtl3TmBfBlPay = suplierPayWork.StockTtl3TmBfBlPay;     // �d��3��O�c���i�x���v�j
            searchSuplierPayRet.CAddUpUpdExecDate = suplierPayWork.CAddUpUpdExecDate;       // �����X�V���s�N����
            searchSuplierPayRet.StartCAddUpUpdDate = suplierPayWork.StartCAddUpUpdDate;     // �����X�V�J�n�N����
            searchSuplierPayRet.LastCAddUpUpdDate = suplierPayWork.LastCAddUpUpdDate;       // �O������X�V�N����
            searchSuplierPayRet.OfsThisTimeStock = suplierPayWork.OfsThisTimeStock;       // ���E�㍡��d�����z
            searchSuplierPayRet.OfsThisStockTax = suplierPayWork.OfsThisStockTax;       // ���E�㍡��d������Ŋz

            if (searchSuplierPayRet.LastCAddUpUpdDate == DateTime.MinValue)
            {
                // ���t�͈́i�J�n�j
                searchSuplierPayRet.StartDateSpan = TDateTime.DateTimeToLongDate(DateTime.MinValue);

                /* --- DEL 2008/07/08 --------------------------------------------------------------------->>>>>
                // ���t�͈́i�I���j
                Int32 endDateSpan = TDateTime.DateTimeToLongDate(suplierPayWork.AddUpDate);

                if (suplierPayWork.AddUpDate.Day > suplierPayWork.CustomerTotalDay)
                {
                    endDateSpan = TDateTime.DateTimeToLongDate(suplierPayWork.AddUpDate.AddMonths(1));
                }
                endDateSpan = endDateSpan - suplierPayWork.AddUpDate.Day + suplierPayWork.CustomerTotalDay;
                
                searchSuplierPayRet.EndDateSpan = endDateSpan;
                   --- DEL 2008/07/08 ---------------------------------------------------------------------<<<<<*/
            }
            else
            {
                // ���t�͈́i�J�n�j
                searchSuplierPayRet.StartDateSpan = TDateTime.DateTimeToLongDate(suplierPayWork.StartCAddUpUpdDate);

                // ���t�͈́i�I���j
                if (DateTime.DaysInMonth(suplierPayWork.LastCAddUpUpdDate.Year, suplierPayWork.LastCAddUpUpdDate.Month) == suplierPayWork.LastCAddUpUpdDate.Day)
                {
                    // �O�񌎖��Œ��ߏ��������Ƃ��́A����������ɂ���B
                    DateTime dt = suplierPayWork.LastCAddUpUpdDate.AddMonths(1);
                    searchSuplierPayRet.EndDateSpan = TDateTime.DateTimeToLongDate(dt);
                    searchSuplierPayRet.EndDateSpan = Convert.ToInt32(Math.Truncate(Convert.ToDouble(searchSuplierPayRet.EndDateSpan / 100)));
                    searchSuplierPayRet.EndDateSpan = searchSuplierPayRet.EndDateSpan * 100;
                    searchSuplierPayRet.EndDateSpan += DateTime.DaysInMonth(dt.Year, dt.Month);
                }
                else
                {
                    // �����ȊO�Œ��ߏ���
                    searchSuplierPayRet.EndDateSpan = TDateTime.DateTimeToLongDate(suplierPayWork.LastCAddUpUpdDate.AddMonths(1));
                }
            }

            // ����x���v �� ����x�����z�i�ʏ�x���j�{����萔���z�i�ʏ�x���j
            //            �{ ����l���z�i�ʏ�x���j  �{���񃊃x�[�g�z�i�ʏ�x���j
            searchSuplierPayRet.ThisTimePaymentMeter = suplierPayWork.ThisTimePayNrml
                                                 + suplierPayWork.ThisTimeFeePayNrml
                                                 + suplierPayWork.ThisTimeDisPayNrml;

            // ���E��d���v �� ���E��O�őΏۊz�{���E����őΏۊz�{���E���ېőΏۊz
            searchSuplierPayRet.StcMtrAfOffset = suplierPayWork.ItdedOffsetOutTax
                                           + suplierPayWork.ItdedOffsetInTax
                                           + suplierPayWork.ItdedOffsetTaxFree;

            // ���E��d������Ōv �� ���E��O�ŏ���Ł{���E����ŏ����
            searchSuplierPayRet.StcConsTaxMtrAfOffset = suplierPayWork.OffsetOutTax
                                                  + suplierPayWork.OffsetInTax;

            //// �O�������ݒ�
            //this._cAddUpUpDate = TDateTime.DateTimeToLongDate(suplierPayWork.LastCAddUpUpdDate);

            // �c�����v
            searchSuplierPayRet.BlnceTtl = suplierPayWork.StockTtl3TmBfBlPay
                                     + suplierPayWork.StockTtl2TmBfBlPay
                                     + suplierPayWork.StockTotalPayBalance;
            // �����c��
            searchSuplierPayRet.Balance = suplierPayWork.StockTtl3TmBfBlPay
                                    + suplierPayWork.StockTtl2TmBfBlPay
                                    + suplierPayWork.StockTotalPayBalance
                                    + suplierPayWork.ThisTimePayNrml; 

            return searchSuplierPayRet;
        }

        // �� 20070519 18322 d MK.NS�ł͎g�p���Ȃ����ߍ폜
        #region �O������X�V�N�����擾����
        ///// <summary>
		///// �O������X�V�N�����擾����
		///// </summary>
		///// <param name="enterpriseCode">��ƃR�[�h</param>
		///// <param name="totalDay">����</param>
		///// <param name="cAddUpUpDate">�����X�V�N����</param>
		///// <returns>�X�e�[�^�X</returns>
		///// <remarks>
		///// <br>Note		: �w�肷������ɑ΂�������X�V�N�������擾���܂��B</br>
		///// <br>Programmer	: 22024 ����@�_�u</br>
		///// <br>Date		: 2006.05.24</br>
		///// </remarks>
		//private int GetCAddUpHisInfo(string enterpriseCode, int totalDay, out int cAddUpUpDate)
		//{
		//	CAddUpHis[] cAddUpHis;
		//	cAddUpUpDate = 0;
		//
		//	// �����X�V�����擾����
		//	int status = _cAddUpHisAcs.SearchLastCAddUpHis(out cAddUpHis, enterpriseCode, totalDay, 0);
		//
		//	switch (status)
		//	{
		//		case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
		//		{
		//			// �����X�V�N�����擾
		//			cAddUpUpDate = TDateTime.DateTimeToLongDate(cAddUpHis[0].CAddUpUpdDate);
		//			break;
		//		}
		//		case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
		//		case (int)ConstantManagement.DB_Status.ctDB_EOF:
		//		{
		//			// �����X�V�N�����擾
		//			cAddUpUpDate = 0;
		//			break;
		//		}
		//		default:
		//		{
		//			_errorMessage = "�����X�V�����̎擾�Ɏ��s���܂����B";
		//			break;
		//		}
		//	}
		//	_cAddUpUpDate = cAddUpUpDate;
		//
		//	return status;
		//}
        #endregion
        // �� 20070519 18322 d

        #region DEL 2008/07/08 Partsman�p�ɕύX
        /* --- DEL 2008/07/08 --------------------------------------------------------------------->>>>>
		/// <summary>
        /// �N���X�����o�[�R�s�[�����i�x���`�[�}�X�^���[�N�N���X�ˎx���`�[�}�X�^�N���X�j
		/// </summary>
        /// <param name="paymentSlpWork">�x���`�[�}�X�^���[�N�N���X</param>
        /// <returns>�x���`�[�}�X�^�N���X</returns>
		/// <remarks>
        /// <br>Note       : �x���`�[�}�X�^���[�N�N���X����x���`�[�}�X�^�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
		/// <br>Programmer : 18322 �ؑ� ����</br>
		/// <br>Date       : 2006.12.22</br>
		/// </remarks>
        private PaymentSlp CopyToPaymentSlpFromPaymentSlpWork(PaymentSlpWork paymentSlpWork)
        {
            PaymentSlp ret = new PaymentSlp();

            ret.CreateDateTime = paymentSlpWork.CreateDateTime;
            ret.UpdateDateTime = paymentSlpWork.UpdateDateTime;
            ret.EnterpriseCode = paymentSlpWork.EnterpriseCode;
            ret.FileHeaderGuid = paymentSlpWork.FileHeaderGuid;
            ret.UpdEmployeeCode = paymentSlpWork.UpdEmployeeCode;
            ret.UpdAssemblyId1 = paymentSlpWork.UpdAssemblyId1;
            ret.UpdAssemblyId2 = paymentSlpWork.UpdAssemblyId2;
            ret.LogicalDeleteCode = paymentSlpWork.LogicalDeleteCode;
            ret.DebitNoteDiv = paymentSlpWork.DebitNoteDiv;
            ret.PaymentSlipNo = paymentSlpWork.PaymentSlipNo;
            ret.CustomerCode = paymentSlpWork.CustomerCode;
            ret.CustomerName = paymentSlpWork.CustomerName;
            ret.CustomerName2 = paymentSlpWork.CustomerName2;
            ret.CustomerSnm = paymentSlpWork.CustomerSnm;
            ret.PayeeCode = paymentSlpWork.PayeeCode;
            ret.PayeeName = paymentSlpWork.PayeeName;
            ret.PayeeName2 = paymentSlpWork.PayeeName2;
            ret.PayeeSnm = paymentSlpWork.PayeeSnm;
            ret.PaymentInpSectionCd = paymentSlpWork.PaymentInpSectionCd;
            ret.AddUpSecCode = paymentSlpWork.AddUpSecCode;
            ret.UpdateSecCd = paymentSlpWork.UpdateSecCd;
            ret.PaymentDate = paymentSlpWork.PaymentDate;
            ret.AddUpADate = paymentSlpWork.AddUpADate;
            ret.PaymentMoneyKindCode = paymentSlpWork.PaymentMoneyKindCode;
            ret.PaymentMoneyKindName = paymentSlpWork.PaymentMoneyKindName;
            ret.PaymentMoneyKindDiv = paymentSlpWork.PaymentMoneyKindDiv;
            ret.PaymentTotal = paymentSlpWork.PaymentTotal;
            ret.Payment = paymentSlpWork.Payment;
            ret.FeePayment = paymentSlpWork.FeePayment;
            ret.DiscountPayment = paymentSlpWork.DiscountPayment;
            ret.RebatePayment = paymentSlpWork.RebatePayment;
            ret.AutoPayment = paymentSlpWork.AutoPayment;
            ret.CreditOrLoanCd = paymentSlpWork.CreditOrLoanCd;
            ret.CreditCompanyCode = paymentSlpWork.CreditCompanyCode;
            ret.DraftDrawingDate = paymentSlpWork.DraftDrawingDate;
            ret.DraftPayTimeLimit = paymentSlpWork.DraftPayTimeLimit;
            ret.DebitNoteLinkPayNo = paymentSlpWork.DebitNoteLinkPayNo;
            ret.PaymentAgentCode = paymentSlpWork.PaymentAgentCode;
            ret.PaymentAgentName = paymentSlpWork.PaymentAgentName;
            ret.Outline = paymentSlpWork.Outline;

            ret.CAddUpUpdDate = this._cAddUpUpDate;

            // 2007.09.05 hikita add start ------------------------------->>
            ret.DraftKind = paymentSlpWork.DraftKind;
            ret.DraftKindName = paymentSlpWork.DraftKindName;
            ret.DraftDivide = paymentSlpWork.DraftDivide;
            ret.DraftDivideName = paymentSlpWork.DraftDivideName;
            ret.DraftNo = paymentSlpWork.DraftNo;
            ret.BankCode = paymentSlpWork.BankCode;
            ret.BankName = paymentSlpWork.BankName;
            // 2007.09.05 hikita add end ---------------------------------<<

            return ret;
        }
           --- DEL 2008/07/08 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/07/08 Partsman�p�ɕύX

        // --- ADD 2012/09/07 ----------------------------------------->>>>>
        /// <summary>
        /// �I�v�V�������L���b�V��
        /// </summary>
        /// <remarks>
        /// <br>Note       : �I�v�V������񐧌䏈���B</br>
        /// <br>Programmer : FSI��k�c �G��</br>
        /// <br>Date       : 2012/09/07</br>
        /// </remarks>
        private void CacheOptionInfo()
        {
            Broadleaf.Application.Remoting.ParamData.PurchaseStatus ps;

            #region ���d���摍���I�v�V����
            ps = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_SuppSumFunc);
            if (ps == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
            {
                this._supplierSummary = true;
            }
            else
            {
                this._supplierSummary = false;
            }
            #endregion
        }
        // --- ADD 2012/09/07 -----------------------------------------<<<<<

        #endregion
    }
}

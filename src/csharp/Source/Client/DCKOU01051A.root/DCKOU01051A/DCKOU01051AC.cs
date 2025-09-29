# region ��using
using System;
using System.Collections;
using System.Windows.Forms;
using System.Data;
using System.Collections.Generic;

using Broadleaf.Library.Resources;
using Broadleaf.Library.Collections;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Xml.Serialization;
//using Broadleaf.Windows.Forms;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Globarization;
# endregion

namespace Broadleaf.Application.Controller
{
	/// <summary>
	/// ������m�F�A�N�Z�X�N���X
	/// </summary>
	/// <remarks>
	/// <br>Note		: �����m�F��ʗp�̃f�[�^���������s���܂��B</br>
	/// <br>Programmer	: 21024�@���X�� ��</br>
	/// <br>Date		: 2007.09.28</br>
    /// <br></br>
    /// <br>Update Note : 2008.04.24 20056 ���n ���</br>
    ///	<br>			�EPM.NS ���ʏC�� ���Ӑ�E�d���敪���Ή�</br>
    ///	<br>			�EPM.NS ���ʏC�� ���_����ݒ�}�X�^�폜�Ή�</br>
	/// <br></br>
	/// <br>Update Note : 2008.05.29 21024 ���X�� ��</br>
	///	<br>			�E�N�����ɃG���[���o��̂ŏC��</br>
	/// <br></br>
	/// <br>Update Note : 2008.07.07 21024 ���X�� ��</br>
	///	<br>			�E�S�̐ݒ�}�X�^�n�̓ǂݍ��݂��C��</br>
    /// <br></br>
    /// <br>Update Note : 2008.09.05 21024 ���X�� ��</br>
    ///	<br>			�E�d�b�ԍ��AFAX�ԍ���\���ł���悤�ɏC��</br>
    /// <br></br>
    /// <br>Update Note : 2009.01.31 21024 ���X�� ��</br>
    ///	<br>			�E�d�����z�����敪�ݒ�A������z�����敪�ݒ�}�X�^�̓ǂݍ��ݕ��@���C��</br>
    /// </remarks>
	public class CustomerClaimConfAcs
	{
		# region ��Private Member

		private string _enterpriseCode;						// ��ƃR�[�h
		private string _loginSectionCode;					// �����_�R�[�h

		private CustomerClaimConf _customerClaimConf;		// �����m�F��ʃf�[�^�N���X
        //private StockProcMoney _stockProcMoney;				// �d�����z�����敪�ݒ�(����ŗp)   // 2009.01.31 Del
        private TaxRateSet _taxRateSet;						// �ŗ��ݒ�
		private AllDefSet _allDefSet;						// �S�̏����l�ݒ�
		private StockTtlSt _stockTtlSt;						// �d���S�̐ݒ�
        //private SalesProcMoney _salesProcMoney;				// ������z�����敪�ݒ�(����ŗp)   // 2009.01.31 Del
		private CustomerChange _customerChange;				// ���Ӑ�ϓ����
        private AlItmDspNm _alItmDspNm;                     // �S�̍��ڕ\�����̃}�X�^

		private PaymentSlpSearch _paymentSlpSearch;			// �x����񌟍��A�N�Z�X�N���X
		private InputDepositNormalTypeAcs _inputDepositNormalTypeAcs;	// �����A�N�Z�X�N���X
        private CustomerInfoAcs _customerInfoAcs;			// ���Ӑ�A�N�Z�X�N���X // ADD 2008.04.24
        private SupplierAcs _supplierAcs;                   // �d����A�N�Z�X�N���X
		private CustomerChangeAcs _customerChangeAcs;		// ���Ӑ�ϓ����A�N�Z�X�N���X
        private AlItmDspNmAcs _alItmDspNmAcs;               // �S�̍��ڕ\�����̃A�N�Z�X�N���X     // 2008.09.05 Add
		private static SecInfoAcs _secInfoAcs;				// ���_�A�N�Z�X�N���X
        // 2009.01.31 Add >>>
        private StockProcMoneyAcs _stockProcMoneyAcs;       // �d�����z�����敪�ݒ�}�X�^�A�N�Z�X�N���X
        private SalesProcMoneyAcs _salesProcMoneyAcs;       // ������z�����敪�ݒ�}�X�^�A�N�Z�X�N���X
        private ClaimConfDataSet _claimConfDataSet;         // ���z�����敪�ݒ�}�X�^�L���b�V���p�f�[�^�Z�b�g
        // 2009.01.31 Add <<<
        // 2008.05.29 Update >>>
		//private bool _isLocalDBRead = true;
		private bool _isLocalDBRead = false;

		// 2008.05.29 Update <<<

        bool _readPaymentInitData = false;
        bool _readClaimInitData = false;

		private GuideType _guideType = GuideType.Claim;		// �K�C�h���[�h

		private const string MESSAGE_NONOWNSECTION = "�����_��񂪎擾�ł��܂���ł����B���_�ݒ���s���Ă���N�����Ă��������B";
		private const string ctSection_All = "00";			// �S�Аݒ�p���_�R�[�h  2008.07.07 Add
		
		# endregion

		#region ��Enums
		/// <summary>
		/// �N���^�C�v
		/// </summary>
		public enum GuideType : int
		{
			/// <summary>����</summary>
			Claim = 1,
			/// <summary>�x��</summary>
			Payment = 2
		}
		#endregion

		# region ��Constracter
		/// <summary>
		/// �����m�F��ʃA�N�Z�X�N���X �R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : �����m�F��ʃA�N�Z�X�N���X�̐V�����C���X�^���X�����������܂��B</br>
		/// <br>Programmer : 21024�@���X�� ��</br>
		/// <br>Date       : 2007.09.28</br>
		/// </remarks>
		public CustomerClaimConfAcs()
		{
			// ��ƃR�[�h���擾����
			this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
			// �����_�R�[�h���擾����
			this._loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;

			// �e�A�N�Z�X�N���X�̃C���X�^���X��
			this._customerInfoAcs = new CustomerInfoAcs();
            this._supplierAcs = new SupplierAcs(); // ADD 2008.04.24
			this._customerClaimConf = new CustomerClaimConf();
			this._paymentSlpSearch = new PaymentSlpSearch();
			this._inputDepositNormalTypeAcs = new InputDepositNormalTypeAcs();
			this._customerChangeAcs = new CustomerChangeAcs();
            this._alItmDspNmAcs = new AlItmDspNmAcs(); // 2008.09.05 Add
            // 2009.01.31 Add >>>
            this._salesProcMoneyAcs = new SalesProcMoneyAcs();
            this._stockProcMoneyAcs = new StockProcMoneyAcs();
            this._claimConfDataSet = new ClaimConfDataSet();
            // 2009.01.31 Add <<<

			// �e����̏�����(�����ςݔ��f�Ɏg�p����̂ŃC���X�^���X�����Ȃ�)
			this._stockTtlSt = null;
            //this._stockProcMoney = null;  // 2009.01.31 Del
			this._taxRateSet = null;
			this._allDefSet = null;
            //this._salesProcMoney = null;  // 2009.01.31 Del
			this._customerChange = null;
            this._alItmDspNm = null;
		}
		# endregion

		#region��Properies
		/// <summary>�K�C�h���[�h�v���p�e�B</summary>
		public GuideType Mode
		{
			set { this._guideType = value; }
			get { return this._guideType; }
		}

		/// <summary>�����m�F��ʃf�[�^�I�u�W�F�N�g�v���p�e�B</summary>
		public CustomerClaimConf CustomerClaimConf
		{
			set { this._customerClaimConf = value; }
			get { return this._customerClaimConf; }
		}

		/// <summary>���Ӑ�ϓ����f�[�^�I�u�W�F�N�g�v���p�e�B</summary>
		public CustomerChange CustomerChange
		{
			set { this._customerChange = value; }
			get { return this._customerChange; }
		}

		/// <summary>���[�J��DB�ǂݍ��݃��[�h�v���p�e�B</summary>
		public bool IsLocalDBRead
		{
			// 2008.05.29 Update >>>
			//set { this._isLocalDBRead = true; }
			set { this._isLocalDBRead = value; }
			// 2008.05.29 Update <<<
			get { return this._isLocalDBRead; }
		}
		#endregion

		#region��Public Method
        // UPD 2008.04.24 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        ///// <summary>
        ///// ���Ӑ�ǂݍ��ݏ���
        ///// </summary>
        ///// <param name="customerCode">���Ӑ�R�[�h</param>
        ///// <param name="customerInfo">���Ӑ���I�u�W�F�N�g</param>
        ///// <param name="custSuppli">���Ӑ�d�����I�u�W�F�N�g</param>
        ///// <param name="customerChange">���Ӑ�ϓ����I�u�W�F�N�g</param>
        ///// <returns>�ǂݍ��݃X�e�[�^�X</returns>
        //public int ReadCustomer(int customerCode, out CustomerInfo customerInfo, out CustSuppli custSuppli, out CustomerChange customerChange)
        //{
        //    return this.ReadCustomerProc(customerCode, out customerInfo, out custSuppli, out customerChange);
        //}
        /// <summary>
        /// ���Ӑ�ǂݍ��ݏ���
        /// </summary>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <param name="customerInfo">���Ӑ���I�u�W�F�N�g</param>
        /// <param name="customerChange">���Ӑ�ϓ����I�u�W�F�N�g</param>
        /// <returns>�ǂݍ��݃X�e�[�^�X</returns>
        public int ReadCustomer(int customerCode, out CustomerInfo customerInfo, out CustomerChange customerChange)
        {
            return this.ReadCustomerProc(customerCode, out customerInfo, out customerChange);
        }
        // UPD 2008.04.24 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

        // ADD 2008.04.24 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// �d����ǂݍ��ݏ���
        /// </summary>
        /// <param name="supplierCode"></param>
        /// <param name="supplier"></param>
        /// <returns></returns>
        public int ReadSupplier(int supplierCode, out Supplier supplier)
        {
            return this.ReadSupplierProc(supplierCode, out supplier);
        }
        // ADD 2008.04.24 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

        // UPD 2008.04.24 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        ///// <summary>
        ///// �f�[�^�L���b�V������
        ///// </summary>
        ///// <param name="customerInfo">���Ӑ���I�u�W�F�N�g</param>
        ///// <param name="custSuppli">���Ӑ�d�����I�u�W�F�N�g</param>
        ///// <param name="customerChange">���Ӑ�ϓ����I�u�W�F�N�g</param>
        ///// <param name="salesDate">�����</param>
        ///// <param name="addUpdate">�v����t</param>
        ///// <param name="delayPaymentDiv">�����敪</param>
        ///// <param name="reCalcAddUpDate">True:�v������Čv�Z����</param>
        //public void Cache( CustomerInfo customerInfo, CustSuppli custSuppli, CustomerChange customerChange, DateTime salesDate, DateTime addUpdate, int delayPaymentDiv, bool reCalcAddUpDate )
        //{
        //    this.cacheProc(customerInfo, custSuppli, customerChange, salesDate, addUpdate, delayPaymentDiv, reCalcAddUpDate);
        //}
        /// <summary>
        /// ���Ӑ���f�[�^�L���b�V������
        /// </summary>
        /// <param name="customerInfo">���Ӑ���I�u�W�F�N�g</param>
        /// <param name="customerChange">���Ӑ�ϓ����I�u�W�F�N�g</param>
        /// <param name="salesDate">�����</param>
        /// <param name="addUpdate">�v����t</param>
        /// <param name="delayPaymentDiv">�����敪</param>
        /// <param name="reCalcAddUpDate">True:�v������Čv�Z����</param>
        public void CacheCustomer(CustomerInfo customerInfo, CustomerChange customerChange, DateTime salesDate, DateTime addUpdate, int delayPaymentDiv, bool reCalcAddUpDate)
        {
            this.CacheCustomerProc(customerInfo, customerChange, salesDate, addUpdate, delayPaymentDiv, reCalcAddUpDate);
        }
        // UPD 2008.04.24 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

        // ADD 2008.04.24 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// �d������f�[�^�L���b�V������
        /// </summary>
        /// <param name="supplier">�d������I�u�W�F�N�g</param>
        /// <param name="stockDate">�d����</param>
        /// <param name="addUpdate">�v���</param>
        /// <param name="delayPaymentDiv">�����敪</param>
        /// <param name="reCalcAddUpDate">�v������Čv�Z����</param>
        public void CacheSupplier(Supplier supplier, DateTime stockDate, DateTime addUpdate, int delayPaymentDiv, bool reCalcAddUpDate)
        {
            this.CacheSupplierProc(supplier, stockDate, addUpdate, delayPaymentDiv, reCalcAddUpDate);
        }
        // ADD 2008.04.24 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

		/// <summary>
		/// �����f�[�^�擾����
		/// </summary>
		public void InitialSearch()
		{
			switch (this._guideType)
			{
				case GuideType.Claim:  // ����
					{
						this.ReadClaimInitData();
						break;
					}
				case GuideType.Payment: // �x��
					{
						this.ReadPaymentInitData();
						break;
					}
			}
            this.ReadAlItmDspNmAcs();   // 2008.09.05 Add
		}

      
		# endregion

		#region ��Private Method

		/// <summary>
		/// ���_����A�N�Z�X�N���X�C���X�^���X������
		/// </summary>
		private void CreateSecInfoAcs()
		{
			if (_secInfoAcs == null)
			{
				_secInfoAcs = ( this._isLocalDBRead ) ? new SecInfoAcs((int)SecInfoAcs.SearchMode.Local) : new SecInfoAcs((int)SecInfoAcs.SearchMode.Remote);
			}

			// ���O�C���S�����_���̎擾
			if (_secInfoAcs.SecInfoSet == null)
			{
				throw new ApplicationException(MESSAGE_NONOWNSECTION);
			}
		}

        // DEL 2008.04.24 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        ///// <summary>
        ///// ����@�\���_�擾����
        ///// <br>SecInfoAcs.CtrlFuncCode(SFKTN01210A)�̏ڍׂ͈ȉ��̒ʂ�B</br>
        ///// <br>�EOwnSecSetting = �����_�ݒ�</br>
        ///// <br>�EDemandAddUpSecCd = �����v�㋒�_</br>
        ///// <br>�EResultsAddUpSecCd = ���ьv�㋒�_</br>
        ///// <br>�EBillSettingSecCd = �����ݒ苒�_</br>
        ///// <br>�EBalanceDispSecCd = �c���\�����_</br>
        ///// <br>�EPayAddUpSecCd = �x���v�㋒�_</br>
        ///// <br>�EPayAddUpSetSecCd = �x���ݒ苒�_</br>
        ///// <br>�EPayBlcDispSecCd = �x���c���\�����_</br>
        ///// <br>�EStockUpdateSecCd = �݌ɍX�V���_</br>
        ///// </summary>
        ///// <param name="sectionCode">�Ώۋ��_�R�[�h</param>
        ///// <param name="ctrlFuncCode">�擾���鐧��@�\�R�[�h</param>
        ///// <param name="ctrlSectionCode">�Ώې��䋒�_�R�[�h</param>
        ///// <param name="ctrlSectionName">�Ώې��䋒�_����</param>
        //private int GetOwnSeCtrlCode( string sectionCode, SecInfoAcs.CtrlFuncCode ctrlFuncCode, out string ctrlSectionCode, out string ctrlSectionName )
        //{
        //    // ���_����A�N�Z�X�N���X�C���X�^���X������
        //    this.CreateSecInfoAcs();

        //    // �Ώې��䋒�_�̏����l�̓��O�C���S�����_
        //    ctrlSectionCode = sectionCode.TrimEnd();
        //    ctrlSectionName = "";

        //    SecInfoSet secInfoSet;
        //    int status = _secInfoAcs.GetSecInfo(sectionCode, ctrlFuncCode, out secInfoSet);

        //    switch (status)
        //    {
        //        case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
        //            {
        //                if (secInfoSet != null)
        //                {
        //                    ctrlSectionCode = secInfoSet.SectionCode.Trim();
        //                    ctrlSectionName = secInfoSet.SectionGuideNm.Trim();
        //                }
        //                else
        //                {
        //                    // ���_����ݒ肪����Ă��Ȃ�
        //                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
        //                }
        //                break;
        //            }
        //        default:
        //            {
        //                break;
        //            }
        //    }

        //    return status;
        //}
        // DEL 2008.04.24 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

        // 2008.09.05 Add >>>
        /// <summary>
        /// �S�̍��ڕ\�����̃}�X�^��ǂݍ��݂܂�
        /// </summary>
        private void ReadAlItmDspNmAcs()
        {
            this._alItmDspNmAcs.Read(out this._alItmDspNm, this._enterpriseCode);
        }
        // 2008.09.05 Add <<<

		/// <summary>
		/// �x�����[�h�p�����f�[�^�ǂݍ��ݏ���
		/// </summary>
		private void ReadPaymentInitData()
		{
            if (_readPaymentInitData) return;

			int status;		// 2008.07.07 Add
			// �d���S�̐ݒ�
			if (this._stockTtlSt == null)
			{
				StockTtlStAcs stockTtlStAcs = new StockTtlStAcs();

				// 2008.07.07 Update >>>
				//stockTtlStAcs.Read(out this._stockTtlSt, this._enterpriseCode);

				ArrayList retStockTtlStList;
				status = stockTtlStAcs.SearchAll(out retStockTtlStList, this._enterpriseCode);
				if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
				{
					StockTtlSt secStockTtlSt = null;
					StockTtlSt allSecStockTtlSt = null;
					foreach (StockTtlSt stockTtlSt in retStockTtlStList)
					{
						if (stockTtlSt.SectionCode.Trim() == this._loginSectionCode.Trim())
						{
							secStockTtlSt = stockTtlSt;
							break;
						}
						else if (stockTtlSt.SectionCode.Trim() == ctSection_All)
						{
							allSecStockTtlSt = stockTtlSt;
						}
					}
					if (allSecStockTtlSt != null) this._stockTtlSt = allSecStockTtlSt; 
					if (secStockTtlSt != null) this._stockTtlSt = secStockTtlSt;
				}
				// 2008.07.07 Update <<<
			}

			// �d�����z�����敪
            // 2009.01.31 Del >>>
            //if (this._stockProcMoney == null)
            //{
            //    StockProcMoneyAcs stockProcMoneyAcs = new StockProcMoneyAcs();
            //    stockProcMoneyAcs.Read(out this._stockProcMoney, this._enterpriseCode, 1, 0, 999999999);
            //}
            this.SearchStockProckMoney();
            // 2009.01.31 Del <<<

            // 2008.05.29 Add >>>
			// �ŗ��ݒ�}�X�^�ǂݍ���
			if (this._taxRateSet == null)
			{
				TaxRateSetAcs taxRateSetAcs = new TaxRateSetAcs();

				TaxRateSetAcs.SearchMode taxRateSearchMode = ( this._isLocalDBRead ) ? TaxRateSetAcs.SearchMode.Local : TaxRateSetAcs.SearchMode.Remote;
				taxRateSetAcs.Read(out this._taxRateSet, this._enterpriseCode, 0, taxRateSearchMode);
			}

			// �S�̏����l�ݒ�
			if (this._allDefSet == null)
			{
				AllDefSetAcs allDefSetAcs = new AllDefSetAcs();
				AllDefSetAcs.SearchMode allDefSetSearchMode = ( this._isLocalDBRead ) ? AllDefSetAcs.SearchMode.Local : AllDefSetAcs.SearchMode.Remote;
				// 2008.07.07 Update >>>
				//allDefSetAcs.Read(out this._allDefSet, this._enterpriseCode, this._loginSectionCode, allDefSetSearchMode);

				ArrayList retAllDefSetList;
				status = allDefSetAcs.Search(out retAllDefSetList, this._enterpriseCode);
				if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
				{
					AllDefSet secAllDefSet = null;
					AllDefSet allSecAllDefSet = null;
					foreach (AllDefSet allDefSet in retAllDefSetList)
					{
						if (allDefSet.SectionCode.Trim() == this._loginSectionCode.Trim())
						{
							secAllDefSet = allDefSet;
							break;
						}
						else if (allDefSet.SectionCode.Trim() == ctSection_All)
						{
							allSecAllDefSet = allDefSet;
						}
					}
					if (allSecAllDefSet != null) this._allDefSet = allSecAllDefSet;
					if (secAllDefSet != null) this._allDefSet = secAllDefSet;
				}
				// 2008.07.07 Update <<<
			}
			// 2008.05.29 Add <<<

            this._readPaymentInitData = true;// 2009.01.31 Add
		}

		/// <summary>
		/// �������[�h�p�����f�[�^�ǂݍ��ݏ���
		/// </summary>
		private void ReadClaimInitData()
		{
            if (this._readClaimInitData) return;    // 2009.01.31 Add
			int status = 0;		// 2008.07.07 Add
			// �ŗ��ݒ�}�X�^�ǂݍ���
			if (this._taxRateSet == null)
			{
				TaxRateSetAcs taxRateSetAcs = new TaxRateSetAcs();

				TaxRateSetAcs.SearchMode taxRateSearchMode = ( this._isLocalDBRead ) ? TaxRateSetAcs.SearchMode.Local : TaxRateSetAcs.SearchMode.Remote;
				taxRateSetAcs.Read(out this._taxRateSet, this._enterpriseCode, 0, taxRateSearchMode);
			}

			// �S�̏����l�ݒ�
			if (this._allDefSet == null)
			{
				AllDefSetAcs allDefSetAcs = new AllDefSetAcs();
				AllDefSetAcs.SearchMode allDefSetSearchMode = ( this._isLocalDBRead ) ? AllDefSetAcs.SearchMode.Local : AllDefSetAcs.SearchMode.Remote;

				// 2008.07.07 Update >>>
				//allDefSetAcs.Read(out this._allDefSet, this._enterpriseCode, this._loginSectionCode, allDefSetSearchMode);

				ArrayList retAllDefSetList;
				status = allDefSetAcs.Search(out retAllDefSetList, this._enterpriseCode);
				if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
				{
					AllDefSet secAllDefSet = null;
					AllDefSet allSecAllDefSet = null;
					foreach (AllDefSet allDefSet in retAllDefSetList)
					{
						if (allDefSet.SectionCode.Trim() == this._loginSectionCode.Trim())
						{
							secAllDefSet = allDefSet;
							break;
						}
						else if (allDefSet.SectionCode.Trim() == ctSection_All)
						{
							allSecAllDefSet = allDefSet;
						}
					}
					if (allSecAllDefSet != null) this._allDefSet = allSecAllDefSet;
					if (secAllDefSet != null) this._allDefSet = secAllDefSet;
				}
				// 2008.07.07 Update <<<
			}

            // 2009.01.31 >>>
            //// ������z�����敪�ݒ�
            //if (this._salesProcMoney == null)
            //{
            //    SalesProcMoneyAcs salesProcMoneyAcs = new SalesProcMoneyAcs();
            //    salesProcMoneyAcs.IsLocalDBRead = this._isLocalDBRead;
            //    salesProcMoneyAcs.Read(out this._salesProcMoney, this._enterpriseCode, 1, 0, 999999999);
            //}

            this.SearchSalesProckMoney();

            this._readClaimInitData = true; 
            // 2009.01.31 <<<
        }

        // UPD 2008.04.24 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        ///// <summary>
        ///// ���Ӑ�E���Ӑ�d�����ǂݍ��ݏ���
        ///// </summary>
        ///// <param name="customerCode">���Ӑ�R�[�h</param>
        ///// <param name="customerInfo">���Ӑ���</param>
        ///// <param name="custSuppli">���Ӑ�d�����</param>
        ///// <param name="customerChange">���Ӑ�ϓ����</param>
        ///// <returns></returns>
        //private int ReadCustomerProc( int customerCode, out CustomerInfo customerInfo, out CustSuppli custSuppli, out CustomerChange customerChange )
        //{
        //    custSuppli = null;
        //    customerInfo = null;
        //    customerChange = null;
        //    if (customerCode == 0)
        //    {
        //        return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        //    }
        //    switch (this.Mode)
        //    {
        //        case GuideType.Claim:
        //            {
        //                this.ReadClaimInitData();
        //                int status = this._customerInfoAcs.ReadDBData(ConstantManagement.LogicalMode.GetData0, this._enterpriseCode, customerCode, out customerInfo);

        //                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
        //                {
        //                    return status;
        //                }
        //                // �Ɣ̐�ȊO�͓��Ӑ�����N���A����
        //                if (customerInfo.AcceptWholeSale != 1)
        //                {
        //                    customerInfo = null;
        //                }

        //                if (customerInfo.CreditMngCode != 0)
        //                {
        //                    this._customerChangeAcs.Read(out customerChange, this._enterpriseCode, customerCode);
        //                }

        //                break;
        //            }
        //        case GuideType.Payment:
        //            {
        //                this.ReadPaymentInitData();
        //                int status = this._customerInfoAcs.ReadDBDataWithCustSuppli(ConstantManagement.LogicalMode.GetData0, this._enterpriseCode, customerCode, true, out customerInfo, out custSuppli);
        //                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
        //                {
        //                    return status;
        //                }
        //                break;
        //            }
        //    }

        //    return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        //}
        /// <summary>
        /// ���Ӑ�E���Ӑ�d�����ǂݍ��ݏ���
        /// </summary>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <param name="customerInfo">���Ӑ���</param>
        /// <param name="customerChange">���Ӑ�ϓ����</param>
        /// <returns></returns>
        private int ReadCustomerProc(int customerCode, out CustomerInfo customerInfo, out CustomerChange customerChange)
        {
            customerInfo = null;
            customerChange = null;
            if (customerCode == 0)
            {
                return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            switch (this.Mode)
            {
                case GuideType.Claim:
                    {
                        this.ReadClaimInitData();
                        int status = this._customerInfoAcs.ReadDBData(ConstantManagement.LogicalMode.GetData0, this._enterpriseCode, customerCode, out customerInfo);

                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            return status;
                        }
                        // �Ɣ̐�ȊO�͓��Ӑ�����N���A����
                        if (customerInfo.AcceptWholeSale != 1)
                        {
                            customerInfo = null;
                        }

                        if (customerInfo.CreditMngCode != 0)
                        {
                            this._customerChangeAcs.Read(out customerChange, this._enterpriseCode, customerCode);
                        }

                        break;
                    }
                case GuideType.Payment:
                    {
                        break;
                    }
            }

            return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        }
        // UPD 2008.04.24 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

        // ADD 2008.04.24 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// �d������ǂݍ��ݏ���
        /// </summary>
        /// <param name="supplierCode">�d����R�[�h</param>
        /// <param name="supplier">�d������</param>
        /// <returns></returns>
        private int ReadSupplierProc(int supplierCode, out Supplier supplier)
        {
            supplier = null;
            if (supplierCode == 0) return (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            switch (this.Mode)
            {
                case GuideType.Claim:
                    {
                        break;
                    }
                case GuideType.Payment:
                    {
                        this.ReadPaymentInitData();
                        int status = this._supplierAcs.Read(out supplier, this._enterpriseCode, supplierCode);
                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) return status;
                        break;
                    }
            }

            return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        }
        // ADD 2008.04.24 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

        // UPD 2008.04.24 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
#if false
        ///// <summary>
        ///// �f�[�^�L���b�V������
        ///// </summary>
        ///// <param name="customerInfo">���Ӑ���N���X</param>
        ///// <param name="custSuppli">���Ӑ�d�����N���X</param>
        ///// <param name="customerChange">���Ӑ�ϓ����</param>
        ///// <param name="salesDate">������t</param>
        ///// <param name="addUpdate">�v����t</param>
        ///// <param name="delayPaymentDiv">�����敪</param>
        ///// <param name="reCalcAddUpDate">�v������Čv�Z����</param>
        //private void cacheProc( CustomerInfo customerInfo, CustSuppli custSuppli, CustomerChange customerChange, DateTime salesDate, DateTime addUpdate, int delayPaymentDiv, bool reCalcAddUpDate )
        //{

        //    this._customerChange = ( customerChange == null ) ? new CustomerChange() : customerChange.Clone();

        //    switch (this.Mode)
        //    {
        //        case GuideType.Claim:
        //            {
        //                if (customerInfo == null)
        //                {
        //                    this._customerClaimConf = new CustomerClaimConf();
        //                    return;
        //                }

        //                // ���Ӑ���N���X����̃Z�b�g(���ʍ���)
        //                this.SetCustomerClaimConfFromCustomerInfo_Common(ref this._customerClaimConf, customerInfo);

        //                this._customerClaimConf.TotalDay = customerInfo.TotalDay;
        //                this._customerClaimConf.NTimeCalcStDate = customerInfo.NTimeCalcStDate;

        //                // ���Ӑ�}�X�^�̏���œ]�ŕ����Q�Ƌ敪��
        //                // �1:�d����Q�Ɓv�̏ꍇ�͓��Ӑ�}�X�^�́u����œ]�ŕ����v��ݒ肷��
        //                // �0:�S�̐ݒ�Q�Ɓv�̏ꍇ�͐ŗ��ݒ�}�X�^�́u����œ]�ŕ����v��ݒ肷��
        //                if (customerInfo.CustCTaXLayRefCd == 1)
        //                {
        //                    this._customerClaimConf.ConsTaxLayMethod = customerInfo.ConsTaxLayMethod;
        //                }
        //                else
        //                {
        //                    this._customerClaimConf.ConsTaxLayMethod = this._taxRateSet.ConsTaxLayMethod;
        //                }

        //                // ���Ӑ�}�X�^�̑��z�\�����@�Q�Ƌ敪��
        //                // �1:���Ӑ�Q�Ɓv�̏ꍇ�͓��Ӑ�}�X�^�́u���z�\�����@�敪�v��ݒ肷��
        //                // �0:�S�̐ݒ�Q�Ɓv�̏ꍇ�͑S�̏����l�ݒ�}�X�^�́u���z�\�����@�敪�v��ݒ肷��
        //                if (customerInfo.TotalAmntDspWayRef == 1)
        //                {
        //                    this._customerClaimConf.TotalAmountDispWayCd = customerInfo.TotalAmountDispWayCd;
        //                }
        //                else
        //                {
        //                    this._customerClaimConf.TotalAmountDispWayCd = this._allDefSet.TotalAmountDispWayCd;
        //                }

        //                // ����ł̏����敪�͔�����z�����敪�ݒ�}�X�^���擾
        //                this._customerClaimConf.TaxFractionProcCd = this._salesProcMoney.FractionProcCd;

        //                //// �����v�㋒�_�̎擾
        //                //string addUpSectionCode;
        //                //string addUpSectionName;
        //                //this.GetOwnSeCtrlCode(this._customerClaimConf.MngSectionCode, SecInfoAcs.CtrlFuncCode.DemandAddUpSecCd, out addUpSectionCode, out addUpSectionName);
        //                //this._customerClaimConf.AddUpSectionCode = addUpSectionCode;

        //                // �O��x�����̎擾
        //                long lastStockTotalPayBalance;
        //                DateTime lastAddUpDate;
        //                this.GetDemandAddUpLastInfo(this._enterpriseCode, this._customerClaimConf.AddUpSectionCode, customerInfo.CustomerCode, out lastStockTotalPayBalance, out lastAddUpDate);

        //                this._customerClaimConf.LastCAddUpUpdDate = lastAddUpDate;
        //                this._customerClaimConf.LastTimeDemand = lastStockTotalPayBalance;

        //                break;
        //            }
        //        case GuideType.Payment:
        //            {
        //                if (( customerInfo == null ) || ( custSuppli == null ))
        //                {
        //                    this._customerClaimConf = new CustomerClaimConf();
        //                    return;
        //                }

        //                // ���Ӑ���N���X����̃Z�b�g(���ʍ���)
        //                this.SetCustomerClaimConfFromCustomerInfo_Common(ref this._customerClaimConf, customerInfo);

        //                this._customerClaimConf.TotalDay = custSuppli.PaymentTotalDay;
        //                this._customerClaimConf.NTimeCalcStDate = custSuppli.NTimeCalcStDate;

        //                // ���Ӑ�d�����}�X�^�̎d�������œ]�ŕ����Q�Ƌ敪��
        //                // �1:�d����Q�Ɓv�̏ꍇ�͓��Ӑ�d�����}�X�^�́u�d�������œ]�ŕ����v��ݒ肷��
        //                // �0:�S�̐ݒ�Q�Ɓv�̏ꍇ�͎d���݌ɑS�̐ݒ�}�X�^�́u�d�������œ]�ŕ����v��ݒ肷��
        //                if (custSuppli.SuppCTaxLayRefCd == 1)
        //                {
        //                    this._customerClaimConf.ConsTaxLayMethod = custSuppli.SuppCTaxLayCd;
        //                }
        //                else
        //                {
        //                    this._customerClaimConf.ConsTaxLayMethod = this._stockTtlSt.SuppCTaxLayCd;
        //                }

        //                // ���Ӑ�d�����}�X�^�̎d���摍�z�\�����@�Q�Ƌ敪��
        //                // �1:�d����Q�Ɓv�̏ꍇ�͓��Ӑ�d�����}�X�^�́u�d���摍�z�\�����@�敪�v��ݒ肷��
        //                // �0:�S�̐ݒ�Q�Ɓv�̏ꍇ�͑S�̏����l�ݒ�}�X�^�́u���z�\�����@�敪�v��ݒ肷��
        //                if (custSuppli.StckTtlAmntDspWayRef == 1)
        //                {
        //                    this._customerClaimConf.TotalAmountDispWayCd = custSuppli.SuppTtlAmntDspWayCd;
        //                }
        //                else
        //                {
        //                    this._customerClaimConf.TotalAmountDispWayCd = this._allDefSet.TotalAmountDispWayCd;
        //                }

        //                // ����ł̏����敪�͎d�����z�����敪�ݒ�}�X�^���擾
        //                this._customerClaimConf.TaxFractionProcCd = this._stockProcMoney.FractionProcCd;

        //                //// �x���v�㋒�_�̎擾
        //                //string addUpSectionCode;
        //                //string addUpSectionName;
        //                //this.GetOwnSeCtrlCode(this._customerClaimConf.MngSectionCode, SecInfoAcs.CtrlFuncCode.PayAddUpSecCd, out addUpSectionCode, out addUpSectionName);
        //                //this._customerClaimConf.AddUpSectionCode = addUpSectionCode;

        //                // �O��x�����̎擾
        //                long lastStockTotalPayBalance;
        //                DateTime lastAddUpDate;
        //                this.GetPaymentAddUpLastInfo(this._enterpriseCode, this._customerClaimConf.AddUpSectionCode, customerInfo.CustomerCode, out lastStockTotalPayBalance, out lastAddUpDate);

        //                this._customerClaimConf.LastCAddUpUpdDate = lastAddUpDate;
        //                this._customerClaimConf.LastTimeDemand = lastStockTotalPayBalance;
        //                break;
        //            }
        //    }
        //    if (reCalcAddUpDate)
        //    {
        //        CustomerClaimConfAcs.CalcAddUpDate(salesDate, this._customerClaimConf.TotalDay, this._customerClaimConf.NTimeCalcStDate, out addUpdate, out delayPaymentDiv);
        //    }
        //    this._customerClaimConf.AddUpADate = addUpdate;
        //    this._customerClaimConf.CollectMoneyCode = delayPaymentDiv;
        //}
#endif
        /// <summary>
        /// �f�[�^�L���b�V������
        /// </summary>
        /// <param name="customerInfo">���Ӑ���N���X</param>
        /// <param name="customerChange">���Ӑ�ϓ����</param>
        /// <param name="salesDate">������t</param>
        /// <param name="addUpdate">�v����t</param>
        /// <param name="delayPaymentDiv">�����敪</param>
        /// <param name="reCalcAddUpDate">�v������Čv�Z����</param>
        private void CacheCustomerProc(CustomerInfo customerInfo, CustomerChange customerChange, DateTime salesDate, DateTime addUpdate, int delayPaymentDiv, bool reCalcAddUpDate)
        {

            this._customerChange = (customerChange == null) ? new CustomerChange() : customerChange.Clone();

            switch (this.Mode)
            {
                case GuideType.Claim:
                    {
                        if (customerInfo == null)
                        {
                            this._customerClaimConf = new CustomerClaimConf();
                            return;
                        }

                        // ���Ӑ���N���X����̃Z�b�g(���ʍ���)
                        this._customerClaimConf.CustomerCode = customerInfo.CustomerCode;
                        this._customerClaimConf.Name = customerInfo.Name;
                        this._customerClaimConf.Name2 = customerInfo.Name2;
                        this._customerClaimConf.CustomerSnm = customerInfo.CustomerSnm;
                        this._customerClaimConf.MngSectionCode = customerInfo.MngSectionCode;
                        this._customerClaimConf.OfficeFaxNo = customerInfo.OfficeFaxNo;
                        //this._customerClaimConf.OfficeFaxNoDspName = customerInfo.OfficeFaxNoDspName;     // 2008.09.05 Del
                        this._customerClaimConf.OfficeTelNo = customerInfo.OfficeTelNo;
                        //this._customerClaimConf.OfficeTelNoDspName = customerInfo.OfficeTelNoDspName;     // 2008.09.05 Del
                        this._customerClaimConf.CreditMngCode = customerInfo.CreditMngCode;
                        this._customerClaimConf.CustomerAgent = customerInfo.CustomerAgentNm;

                        this._customerClaimConf.TotalDay = customerInfo.TotalDay;
                        this._customerClaimConf.NTimeCalcStDate = customerInfo.NTimeCalcStDate;

                        // ���Ӑ�}�X�^�̏���œ]�ŕ����Q�Ƌ敪��
                        // �1:�d����Q�Ɓv�̏ꍇ�͓��Ӑ�}�X�^�́u����œ]�ŕ����v��ݒ肷��
                        // �0:�S�̐ݒ�Q�Ɓv�̏ꍇ�͐ŗ��ݒ�}�X�^�́u����œ]�ŕ����v��ݒ肷��
                        if (customerInfo.CustCTaXLayRefCd == 1)
                        {
                            this._customerClaimConf.ConsTaxLayMethod = customerInfo.ConsTaxLayMethod;
                        }
                        else
                        {
                            this._customerClaimConf.ConsTaxLayMethod = this._taxRateSet.ConsTaxLayMethod;
                        }

                        // ���Ӑ�}�X�^�̑��z�\�����@�Q�Ƌ敪��
                        // �1:���Ӑ�Q�Ɓv�̏ꍇ�͓��Ӑ�}�X�^�́u���z�\�����@�敪�v��ݒ肷��
                        // �0:�S�̐ݒ�Q�Ɓv�̏ꍇ�͑S�̏����l�ݒ�}�X�^�́u���z�\�����@�敪�v��ݒ肷��
                        if (customerInfo.TotalAmntDspWayRef == 1)
                        {
                            this._customerClaimConf.TotalAmountDispWayCd = customerInfo.TotalAmountDispWayCd;
                        }
                        else
                        {
                            this._customerClaimConf.TotalAmountDispWayCd = this._allDefSet.TotalAmountDispWayCd;
                        }

                        // 2009.01.31 >>>
                        //// ����ł̏����敪�͔�����z�����敪�ݒ�}�X�^���擾
                        //this._customerClaimConf.TaxFractionProcCd = this._salesProcMoney.FractionProcCd;
                        double fractionProcUnit;
                        int fractionProcCd;
                        this.GetSalesFractionInfo(1, customerInfo.SalesCnsTaxFrcProcCd, 999999999, out fractionProcUnit, out fractionProcCd);
                        this._customerClaimConf.TaxFractionProcCd = fractionProcCd;
                        // 2009.01.31 <<<

                        //// �����v�㋒�_�̎擾
                        //string addUpSectionCode;
                        //string addUpSectionName;
                        //this.GetOwnSeCtrlCode(this._customerClaimConf.MngSectionCode, SecInfoAcs.CtrlFuncCode.DemandAddUpSecCd, out addUpSectionCode, out addUpSectionName);
                        //this._customerClaimConf.AddUpSectionCode = addUpSectionCode;

                        // �O��x�����̎擾
                        long lastStockTotalPayBalance;
                        DateTime lastAddUpDate;
                        this.GetDemandAddUpLastInfo(this._enterpriseCode, this._customerClaimConf.AddUpSectionCode, customerInfo.CustomerCode, out lastStockTotalPayBalance, out lastAddUpDate);

                        this._customerClaimConf.LastCAddUpUpdDate = lastAddUpDate;
                        this._customerClaimConf.LastTimeDemand = lastStockTotalPayBalance;

                        break;
                    }
                case GuideType.Payment:
                    {
                        break;
                    }
            }

            // 2008.09.05 Add >>>
            if (this._alItmDspNm != null)
            {
                this._customerClaimConf.OfficeTelNoDspName = this._alItmDspNm.OfficeTelNoDspName;
                this._customerClaimConf.OfficeFaxNoDspName = this._alItmDspNm.OfficeFaxNoDspName;
            }
            // 2008.09.05 Add <<<

            if (reCalcAddUpDate)
            {
                CustomerClaimConfAcs.CalcAddUpDate(salesDate, this._customerClaimConf.TotalDay, this._customerClaimConf.NTimeCalcStDate, out addUpdate, out delayPaymentDiv);
            }
            this._customerClaimConf.AddUpADate = addUpdate;
            this._customerClaimConf.CollectMoneyCode = delayPaymentDiv;
        }
        // UPD 2008.04.24 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

        // ADD 2008.04.24 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// �f�[�^�L���b�V������
        /// </summary>
		/// <param name="supplier">�d������N���X</param>
        /// <param name="stockDate">�d����</param>
        /// <param name="addUpdate">�v���</param>
        /// <param name="delayPaymentDiv">�����敪</param>
        /// <param name="reCalcAddUpDate">�v������Čv�Z����</param>
        private void CacheSupplierProc(Supplier supplier, DateTime stockDate, DateTime addUpdate, int delayPaymentDiv, bool reCalcAddUpDate)
        {
            switch (this.Mode)
            {
                case GuideType.Claim:
                    {
                        break;
                    }
                case GuideType.Payment:
                    {
                        if (supplier == null)
                        {
                            this._customerClaimConf = new CustomerClaimConf();
                            return;
                        }

                        this._customerClaimConf.CustomerCode = supplier.SupplierCd;
                        this._customerClaimConf.Name = supplier.SupplierNm1;
                        this._customerClaimConf.Name2 = supplier.SupplierNm2;
                        this._customerClaimConf.CustomerSnm = supplier.SupplierSnm;
                        this._customerClaimConf.MngSectionCode = supplier.MngSectionCode;
                        this._customerClaimConf.OfficeFaxNo = supplier.SupplierTelNo2;
                        this._customerClaimConf.OfficeTelNo = supplier.SupplierTelNo;
                        this._customerClaimConf.CustomerAgent = supplier.StockAgentName;

                        this._customerClaimConf.TotalDay = supplier.PaymentTotalDay;
                        this._customerClaimConf.NTimeCalcStDate = supplier.NTimeCalcStDate;

                        // ���Ӑ�d�����}�X�^�̎d�������œ]�ŕ����Q�Ƌ敪��
                        // �1:�d����Q�Ɓv�̏ꍇ�͓��Ӑ�d�����}�X�^�́u�d�������œ]�ŕ����v��ݒ肷��
                        // �0:�S�̐ݒ�Q�Ɓv�̏ꍇ�͐ŗ��ݒ�}�X�^�́u�d�������œ]�ŕ����v��ݒ肷��
                        if (supplier.SuppCTaxLayRefCd == 1)
                        {
                            this._customerClaimConf.ConsTaxLayMethod = supplier.SuppCTaxLayCd;
                        }
                        else
                        {
							// 2008.07.07 Update >>>
							//this._customerClaimConf.ConsTaxLayMethod = this._stockTtlSt.SuppCTaxLayCd;
							this._customerClaimConf.ConsTaxLayMethod = this._taxRateSet.ConsTaxLayMethod;
							// 2008.07.07 Update <<<
                        }

                        // ���Ӑ�d�����}�X�^�̎d���摍�z�\�����@�Q�Ƌ敪��
                        // �1:�d����Q�Ɓv�̏ꍇ�͓��Ӑ�d�����}�X�^�́u�d���摍�z�\�����@�敪�v��ݒ肷��
                        // �0:�S�̐ݒ�Q�Ɓv�̏ꍇ�͑S�̏����l�ݒ�}�X�^�́u���z�\�����@�敪�v��ݒ肷��
                        if (supplier.StckTtlAmntDspWayRef == 1)
                        {
                            this._customerClaimConf.TotalAmountDispWayCd = supplier.SuppTtlAmntDspWayCd;
                        }
                        else
                        {
                            this._customerClaimConf.TotalAmountDispWayCd = this._allDefSet.TotalAmountDispWayCd;
                        }

                        // 2009.01.31 >>>
                        //// ����ł̏����敪�͎d�����z�����敪�ݒ�}�X�^���擾
                        //this._customerClaimConf.TaxFractionProcCd = this._stockProcMoney.FractionProcCd;

                        double fractionProcUnit;
                        int fractionProcCd;
                        this.GetStockFractionInfo(1, supplier.StockCnsTaxFrcProcCd, 999999999, out fractionProcUnit, out fractionProcCd);
                        this._customerClaimConf.TaxFractionProcCd = fractionProcCd;

                        // 2009.01.31 <<<

                        // �O��x�����̎擾
                        long lastStockTotalPayBalance;
                        DateTime lastAddUpDate;
                        this.GetPaymentAddUpLastInfo(this._enterpriseCode, this._customerClaimConf.AddUpSectionCode, supplier.SupplierCd, out lastStockTotalPayBalance, out lastAddUpDate);

                        this._customerClaimConf.LastCAddUpUpdDate = lastAddUpDate;
                        this._customerClaimConf.LastTimeDemand = lastStockTotalPayBalance;

                        // 2008.09.05 Add >>>
                        if (this._alItmDspNm!=null)
                        {
                            this._customerClaimConf.OfficeTelNoDspName = this._alItmDspNm.OfficeTelNoDspName;
                            this._customerClaimConf.OfficeFaxNoDspName = this._alItmDspNm.OfficeFaxNoDspName;
                        }
                        // 2008.09.05 Add <<<
                        break;
                    }
            }
            if (reCalcAddUpDate)
            {
                CustomerClaimConfAcs.CalcAddUpDate(stockDate, this._customerClaimConf.TotalDay, this._customerClaimConf.NTimeCalcStDate, out addUpdate, out delayPaymentDiv);
            }
            this._customerClaimConf.AddUpADate = addUpdate;
            this._customerClaimConf.CollectMoneyCode = delayPaymentDiv;
        }
        // ADD 2008.04.27 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

        // DEL 2008.04.24 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        ///// <summary>
        ///// ���Ӑ���N���X�������m�F��ʃN���X���ڃZ�b�g(�����E�x������)
        ///// </summary>
        ///// <param name="customerClaimConf"></param>
        ///// <param name="customerInfo"></param>
        //private void SetCustomerClaimConfFromCustomerInfo_Common( ref CustomerClaimConf customerClaimConf, CustomerInfo customerInfo )
        //{
        //    customerClaimConf.CustomerCode = customerInfo.CustomerCode;
        //    customerClaimConf.Name = customerInfo.Name;
        //    customerClaimConf.Name2 = customerInfo.Name2;
        //    customerClaimConf.CustomerSnm = customerInfo.CustomerSnm;
        //    customerClaimConf.MngSectionCode = customerInfo.MngSectionCode;
        //    customerClaimConf.OfficeFaxNo = customerInfo.OfficeFaxNo;
        //    customerClaimConf.OfficeFaxNoDspName = customerInfo.OfficeFaxNoDspName;
        //    customerClaimConf.OfficeTelNo = customerInfo.OfficeTelNo;
        //    customerClaimConf.OfficeTelNoDspName = customerInfo.OfficeTelNoDspName;
        //    customerClaimConf.CreditMngCode = customerInfo.CreditMngCode;
        //    customerClaimConf.CustomerAgent = customerInfo.CustomerAgent;
        //}
        // DEL 2008.04.24 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

		/// <summary>
		/// �O�񐿋����擾����
		/// </summary>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="addUpSectionCode">�v�㋒�_�R�[�h</param>
		/// <param name="customerCode">���Ӑ�R�[�h</param>
		/// <param name="lastTotalPayBalance">�O�񐿋����z</param>
		/// <param name="lastAddUpDate">�O�񐿋�����</param>
		private void GetDemandAddUpLastInfo( string enterpriseCode, string addUpSectionCode, int customerCode, out long lastTotalPayBalance, out DateTime lastAddUpDate )
		{
			lastTotalPayBalance = 0;
			lastAddUpDate = DateTime.MinValue;
			InputDepositNormalTypeAcs.SearchCustomerParameter searchCustomerParameter = new InputDepositNormalTypeAcs.SearchCustomerParameter();
			searchCustomerParameter.EnterpriseCode = enterpriseCode;
			searchCustomerParameter.AddUpSecCod = addUpSectionCode;
			searchCustomerParameter.CustomerCode = customerCode;
			searchCustomerParameter.AddUpADate = TDateTime.DateTimeToLongDate(DateTime.Today);
			string msg="";

			DepositCustDmdPrc depositCustDmdPrc;

			int status = this._inputDepositNormalTypeAcs.ReadCustomDemandInfo(searchCustomerParameter, out depositCustDmdPrc, out msg);

			if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				lastTotalPayBalance = depositCustDmdPrc.ThisTimeTtlBlcDmd;
				lastAddUpDate = depositCustDmdPrc.LastCAddUpUpdDate;
			}
		}

		/// <summary>
		/// �O��x�����擾����
		/// </summary>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="addUpSectionCode">�v�㋒�_�R�[�h</param>
		/// <param name="customerCode">���Ӑ�R�[�h</param>
		/// <param name="lastStockTotalPayBalance">�O��x�����z</param>
		/// <param name="lastAddUpDate">�O��x������</param>
		private void GetPaymentAddUpLastInfo( string enterpriseCode, string addUpSectionCode, int customerCode, out long lastStockTotalPayBalance, out DateTime lastAddUpDate )
		{
			lastStockTotalPayBalance = 0;
			lastAddUpDate = DateTime.MinValue;
			SearchPaymentParameter searchPaymentParameter = new SearchPaymentParameter();
			searchPaymentParameter.EnterpriseCode = enterpriseCode;
			searchPaymentParameter.AddUpSecCode = addUpSectionCode;
			searchPaymentParameter.PayeeCode = customerCode;
			searchPaymentParameter.AddUpADate = DateTime.Today;

			SearchSuplierPayRet searchSuplierPayRet;

			int status = this._paymentSlpSearch.ReadCustomPaymentInfo(searchPaymentParameter, out searchSuplierPayRet);

			if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
                lastStockTotalPayBalance = searchSuplierPayRet.StockTtl3TmBfBlPay + searchSuplierPayRet.StockTtl2TmBfBlPay + searchSuplierPayRet.LastTimePayment;
				lastAddUpDate = searchSuplierPayRet.LastCAddUpUpdDate;
			}
		}

        /// <summary>
        /// �d�����z�����敪�ݒ�}�X�^�̌���
        /// </summary>
        private void SearchStockProckMoney()
        {
            ArrayList al;
            this._claimConfDataSet.StockProcMoney.Rows.Clear();

            int status = this._stockProcMoneyAcs.Search(out al, this._enterpriseCode);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                foreach (StockProcMoney stockProckMoney in al)
                {
                    ClaimConfDataSet.StockProcMoneyRow row = this._claimConfDataSet.StockProcMoney.NewStockProcMoneyRow();
                    row.FracProcMoneyDiv = stockProckMoney.FracProcMoneyDiv;
                    row.FractionProcCode = stockProckMoney.FractionProcCode;
                    row.UpperLimitPrice = stockProckMoney.UpperLimitPrice;
                    row.FractionProcUnit = stockProckMoney.FractionProcUnit;
                    row.FractionProcCd = stockProckMoney.FractionProcCd;
                    this._claimConfDataSet.StockProcMoney.AddStockProcMoneyRow(row);
                }
            }
        }

        /// <summary>
        /// �d�����z�����敪�ݒ���擾
        /// </summary>
        /// <param name="fracProcMoneyDiv"></param>
        /// <param name="fractionProcCode"></param>
        /// <param name="upperLimitPrice"></param>
        /// <param name="fractionProcUnit"></param>
        /// <param name="fractionProcCd"></param>
        private void GetStockFractionInfo(int fracProcMoneyDiv, int fractionProcCode, double upperLimitPrice, out double fractionProcUnit, out int fractionProcCd)
        {
            fractionProcUnit = 0;
            fractionProcCd = 0;
            ClaimConfDataSet.StockProcMoneyRow row = this._claimConfDataSet.StockProcMoney.FindByUpperLimitPriceFractionProcCodeFracProcMoneyDiv(upperLimitPrice, fractionProcCode, fracProcMoneyDiv);

            if (row != null)
            {
                fractionProcUnit = row.FractionProcUnit;
                fractionProcCd = row.FractionProcCd;
            }
        }

        /// <summary>
        /// ������z�����敪�ݒ�}�X�^�̌���
        /// </summary>
        private void SearchSalesProckMoney()
        {
            ArrayList al;
            this._claimConfDataSet.SalesProcMoney.Rows.Clear();

            int status = this._salesProcMoneyAcs.Search(out al, this._enterpriseCode);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                foreach (SalesProcMoney salesProcMoney in al)
                {
                    ClaimConfDataSet.SalesProcMoneyRow row = this._claimConfDataSet.SalesProcMoney.NewSalesProcMoneyRow();
                    row.FracProcMoneyDiv = salesProcMoney.FracProcMoneyDiv;
                    row.FractionProcCode = salesProcMoney.FractionProcCode;
                    row.UpperLimitPrice = salesProcMoney.UpperLimitPrice;
                    row.FractionProcUnit = salesProcMoney.FractionProcUnit;
                    row.FractionProcCd = salesProcMoney.FractionProcCd;
                    this._claimConfDataSet.SalesProcMoney.AddSalesProcMoneyRow(row);
                }
            }
        }

        /// <summary>
        /// ������z�����敪�ݒ���擾
        /// </summary>
        /// <param name="fracProcMoneyDiv"></param>
        /// <param name="fractionProcCode"></param>
        /// <param name="upperLimitPrice"></param>
        /// <param name="fractionProcUnit"></param>
        /// <param name="fractionProcCd"></param>
        private void GetSalesFractionInfo(int fracProcMoneyDiv, int fractionProcCode, double upperLimitPrice, out double fractionProcUnit, out int fractionProcCd)
        {
            fractionProcUnit = 0;
            fractionProcCd = 0;
            ClaimConfDataSet.SalesProcMoneyRow row = this._claimConfDataSet.SalesProcMoney.FindByFracProcMoneyDivFractionProcCodeUpperLimitPrice(fracProcMoneyDiv, fractionProcCode, upperLimitPrice);

            if (row != null)
            {
                fractionProcUnit = row.FractionProcUnit;
                fractionProcCd = row.FractionProcCd;
            }
        }
		#endregion

		#region ��Static Method

		/// <summary>
		/// �v����v�Z����
		/// </summary>
		/// <param name="targetDate">�Ώۓ�</param>
		/// <param name="totalDay">����</param>
		/// <param name="nTimeCalcStDate">��������J�n��</param>
		/// <param name="addUpADate">�v���(�Z�o����)</param>
		/// <param name="delayPaymentDiv">�����敪(�Z�o	����)</param>
		public static void CalcAddUpDate( DateTime targetDate, int totalDay, int nTimeCalcStDate, out DateTime addUpADate, out int delayPaymentDiv )
		{
			DateTime thisTimeAddUpDate = CustomerClaimConfAcs.GetNextTotalDate(0, targetDate, totalDay);
			// ���������̏ꍇ�́A���񐿋����̗������v���
			DateTime nextTimeAddUpDate = thisTimeAddUpDate.AddDays(1);
			// ��{�I�ɑΏۓ����v����œ�������
			addUpADate = targetDate;
			delayPaymentDiv = 0;

			// ��������J�n�����ݒ肳��Ă��Ȃ��ꍇ�͂��̂܂܏I��
			if (nTimeCalcStDate == 0)
				return;

			// ��������J�n�� �� ����
			if (nTimeCalcStDate <= totalDay)
			{
				// �Ώۓ��̓��t����������J�n���`�����̏ꍇ�ɗ�������
				if (( nTimeCalcStDate <= targetDate.Day ) && ( targetDate.Day <= totalDay ))
				{
					addUpADate = nextTimeAddUpDate;
					delayPaymentDiv = 1;
				}
			}
			// ��������J�n�� �� ����
			else
			{
				// �Ώۓ��̓��t��1���`�����A��������J�n���`�����̏ꍇ�ɗ�������
				if (( 1 <= targetDate.Day ) && ( targetDate.Day <= totalDay ) ||
					( nTimeCalcStDate <= targetDate.Day ))
				{
					addUpADate = nextTimeAddUpDate;
					delayPaymentDiv = 1;
				}
			}
		}

		/// <summary>
		/// ��ƂȂ������A�����E�����E���X���̒��ΏۂƂȂ�v������擾���܂��B
		/// </summary>
		/// <param name="collectMoneyMonth">0:����,1:����,2:���X��...</param>
		/// <param name="totalDay">����</param>
		/// <param name="baseDate">��ƂȂ��</param>
		/// <returns>�v���</returns>
		public static DateTime CalcAddUpDate( int collectMoneyMonth, int totalDay, DateTime baseDate )
		{
			return ( collectMoneyMonth == 0 ) ? baseDate : (DateTime)GetNextTotalDate(collectMoneyMonth - 1, baseDate, totalDay).AddDays(1);
		}

		/// <summary>
		/// �v�������A���ΏۂƂȂ�Ώی��̋敪�l���擾���܂�
		/// </summary>
		/// <param name="totalDay">����</param>
		/// <param name="baseDate">��ƂȂ��</param>
		/// <param name="targetDate">�v���</param>
		/// <returns>0:����,1:����,2:���X��...</returns>
		public static int CalcCollectMoneyCode( int totalDay, DateTime baseDate, DateTime targetDate )
		{
			const int collectMoneyMonthMax = 99;
			if (targetDate <= baseDate)
			{
				return 0;
			}

			for (int cnt = 0; cnt < collectMoneyMonthMax; cnt++)
			{
				if ((DateTime)GetNextTotalDate(cnt, baseDate, totalDay).AddDays(1) > targetDate)
				{
					return cnt;
				}
			}
			return collectMoneyMonthMax;
		}

		/// <summary>
		/// �w����t�̎���ȍ~�̒������Z�o���܂��B
		/// </summary>
		/// <param name="loopCnt">0:����,1:����,2:���X��...</param>
		/// <param name="targetdate">�Ώۓ�</param>
		/// <param name="totalDay">����</param>
		/// <returns></returns>
		private static DateTime GetNextTotalDate( int loopCnt, DateTime targetdate, int totalDay )
		{

			DateTime retDate = targetdate;

			// �Ώی��̎��ۂ̒������擾
			int totalDayR = GetRealTotalDay(retDate, totalDay);

			// �Ώۓ������ۂ̒������傫���ꍇ��1�������Z
			if (targetdate.Day > totalDayR)
			{
				retDate = retDate.AddMonths(1);

				totalDayR = GetRealTotalDay(retDate, totalDay);
			}
			retDate = new DateTime(retDate.Year, retDate.Month, totalDayR);

			return ( loopCnt == 0 ) ? retDate : GetNextTotalDate(loopCnt - 1, retDate.AddDays(1), totalDay);
		}

		/// <summary>
		/// �Ώ۔N�����A��������A���ۂɒ��ΏۂƂȂ���t���Z�o���܂��B
		/// </summary>
		/// <param name="targetDate">�Ώ۔N����</param>
		/// <param name="totalDay">�ݒ��̒���</param>
		/// <returns>�Ώی��̎��ۂ̒���</returns>
		private static int GetRealTotalDay( DateTime targetDate, int totalDay )
		{
			int retValue = totalDay;
			// �Ώی��̖����擾
			int lastDayofMonth = DateTime.DaysInMonth(targetDate.Year, targetDate.Month);

			if (lastDayofMonth < totalDay) retValue = lastDayofMonth;

			return retValue;
		}

		#endregion
	}
}

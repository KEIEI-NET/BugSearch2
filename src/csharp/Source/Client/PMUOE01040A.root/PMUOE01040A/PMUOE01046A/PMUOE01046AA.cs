//****************************************************************************//
// �V�X�e��         : PM.NS�V���[�Y
// �v���O��������   : �t�n�d�����f�[�^�A�N�Z�X�N���X
// �v���O�����T�v   : �t�n�d�����f�[�^�A�N�Z�X������s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10402071-00 �쐬�S�� : ���� �T��
// �� �� ��  2009/05/25  �C�����e : �z���_ UOE WEB�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  XXXXXXXX-00 �쐬�S�� : ���� ���n
// �� �� ��  2011/10/27  �C�����e : 22008 ���� ���n �`�[���גǉ����Z�b�g�s��̏C��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� : yangmj
// �� �� ��  2012/09/20  �C�����e : redmine#32404�̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : chenw
// �� �� ��  2013/03/07  �C�����e : 2013/04/03�z�M��
//                                  Redmine#34989�̑Ή� ���YUOEWEB�̉���(�n�o�d�m���i�Ή�)
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� : pengjie
// �� �� ��  2013/03/14  �C�����e : redmine#34986�̑Ή� �t�n�d�����f�[�^�̌��������ɁA�^�C���A�E�g�G���[���b�Z�[�W�ǉ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10902931-00 �쐬�S�� : 杍^
// �� �� ��  2013/08/15  �C�����e : ��������(����)�����̒ǉ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ������
// �� �� ��  2014/01/24  �C�����e : Redmine#41551�̑Ή� UOE����őΉ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11001634-00  �쐬�S�� : ���N�n��
// �� �� ��  K2014/05/26  �C�����e : ���������G���[���b�Z�[�W���o���Ȃ��悤�ɏC���ƃG���[���O�̍X�V
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using System.Windows.Forms;

using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Globarization;
using Broadleaf.Application.Common;
using Broadleaf.Library.Collections;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Windows.Forms;
using System.Threading;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Controller
{
	/// <summary>
	/// �t�n�d�����f�[�^�A�N�Z�X�N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : �t�n�d�����f�[�^�A�N�Z�X�N���X</br>
	/// <br>Programmer : 96186 ���ԗT��</br>
	/// <br>Date       : 2008.05.26</br>
	/// <br></br>
	/// <br>UpDate</br>
	/// <br>2008.05.26 men �V�K�쐬</br>
    /// <br>Update Note  : 2009/05/25 96186 ���� �T��</br>
    /// <br>              �E�z���_ UOE WEB�Ή�</br>
    /// <br>Update Note: 2012/09/20 yangmj redmine#23404�̑Ή�</br>
    /// <br>Update Note: 2014/01/24 ������ Redmine#41551�̑Ή� UOE����őΉ�</br>
    /// <br>Update Note : K2014/05/26 ���N�n��</br>
    /// <br>              ���������G���[���b�Z�[�W���o���Ȃ��悤�ɏC���ƃG���[���O�̍X�V</br>
    /// </remarks>
	public partial class UOEOrderDtlAcs
	{
		// ===================================================================================== //
		// �R���X�g���N�^
		// ===================================================================================== //
		# region Constructors
		public UOEOrderDtlAcs()
		{
            // ---- ADD 2013/08/15 杍^ ---- >>>>>
            //OPT-CPM0110�F�t�^�oUOE�I�v�V�����i�ʁj
            fuTaBaPs = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_CPM_FutabaUOECtl);
            if (fuTaBaPs == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
            {
                this._opt_FuTaBa = (int)Option.ON;
            }
            else
            {
                this._opt_FuTaBa = (int)Option.OFF;
            }
            // ---- ADD 2013/08/15 杍^ ---- <<<<<

            int status = 0;

			//��ƃR�[�h���擾����
			this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

			//���O�C�����_�R�[�h
			this._loginSectionCd = LoginInfoAcquisition.Employee.BelongSectionCode;

            //UOE�����f�[�^�E�d�����׃f�[�^�X�V�����[�g�I�u�W�F�N�g
            this._iIOWriteControlDB = (IIOWriteControlDB)MediationIOWriteControlDB.GetIOWriteControlDB();

            //UOE�����f�[�^ �����[�g�I�u�W�F�N�g
            this._iIOWriteUOEOdrDtlDB = (IIOWriteUOEOdrDtlDB)MediationIOWriteUOEOdrDtlDB.GetIOWriteUOEOdrDtlDB();

            this._StockProcMoney = new StockInputInitialDataSet.StockProcMoneyDataTable();

            this._taxRateSetAcs = new TaxRateSetAcs();

            //-----------------------------------------------------------
            // �ŗ��ݒ�}�X�^
            //-----------------------------------------------------------
            ArrayList returnTaxRateSet;
            TaxRateSetAcs.SearchMode taxRateSetSearchMode = (ctIsLocalDBRead) ? TaxRateSetAcs.SearchMode.Local : TaxRateSetAcs.SearchMode.Remote;
            status = _taxRateSetAcs.Search(out returnTaxRateSet, _enterpriseCode, taxRateSetSearchMode);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                this.CacheTaxRateSet((TaxRateSet)returnTaxRateSet[0]);
            }
            else
            {
                this._taxRateSet = null;
            }

            //-----------------------------------------------------------
            // �d�����z�����敪�ݒ�}�X�^
            //-----------------------------------------------------------
            _stockProcMoneyAcs = new StockProcMoneyAcs();

            ArrayList returnStockProcMoney;
            StockProcMoneyWork paraStockProcMoneyWork = new StockProcMoneyWork();
            paraStockProcMoneyWork.EnterpriseCode = _enterpriseCode;
            paraStockProcMoneyWork.FracProcMoneyDiv = -1;

            status = _stockProcMoneyAcs.Search(out returnStockProcMoney, _enterpriseCode);

            this._stockProcMoneyList = new List<StockProcMoney>();
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                foreach (StockProcMoney stockProcMoney in (ArrayList)returnStockProcMoney)
                {
                    this.CacheStockProcMoney(stockProcMoney);
                    this._stockProcMoneyList.Add(stockProcMoney.Clone());
                }
            }

            //-----------------------------------------------------------
            //�d�����z�v�Z�N���X
            //-----------------------------------------------------------
            _stockPriceCalculate = new StockPriceCalculate();
            _stockPriceCalculate.CacheStockProcMoneyList(_stockProcMoneyList);

            //-----------------------------------------------------------
            //������z�v�Z�N���X
            //-----------------------------------------------------------
            _salesPriceCalculate = new SalesPriceCalculate();
        }

        /// <summary>
        /// �A�N�Z�X�N���X �C���X�^���X�擾����
        /// </summary>
        /// <returns></returns>
        public static UOEOrderDtlAcs GetInstance()
        {
            if (_uOEOrderDtlAcs == null)
            {
                _uOEOrderDtlAcs = new UOEOrderDtlAcs();
            }
            return _uOEOrderDtlAcs;
        }
        # endregion

		// ===================================================================================== //
		// �v���C�x�[�g�ϐ�
		// ===================================================================================== //
		# region Private Members
        //�A�N�Z�X�N���X �C���X�^���X
        private static UOEOrderDtlAcs _uOEOrderDtlAcs = null;

		//��ƃR�[�h
		private string _enterpriseCode = "";

		//���O�C�����_�R�[�h
		private string _loginSectionCd = "";

        //UOE�����f�[�^�E�d�����׃f�[�^�X�V�����[�g
        private IIOWriteControlDB _iIOWriteControlDB = null;

        //UOE�����f�[�^ �����[�g�I�u�W�F�N�g
        private IIOWriteUOEOdrDtlDB _iIOWriteUOEOdrDtlDB = null;

        // �ŗ� �A�N�Z�X�N���X
        private TaxRateSetAcs _taxRateSetAcs = null;

        //�ŗ��N���X
        private TaxRateSet _taxRateSet = null   ;

        //�d�����z�����敪�A�N�Z�X�N���X
        private StockProcMoneyAcs _stockProcMoneyAcs = null;

        private StockInputInitialDataSet.StockProcMoneyDataTable _StockProcMoney = null;

        //������z�����敪�A�N�Z�X�N���X
        //private SalesProcMoneyAcs _salesProcMoneyAcs = null;

        //�d�����z�v�Z�A�N�Z�X�N���X
        private StockPriceCalculate _stockPriceCalculate = null;

        //������z�v�Z�A�N�Z�X�N���X
        private SalesPriceCalculate _salesPriceCalculate = null;

        //�d�����z�����敪���X�g
        private List<StockProcMoney> _stockProcMoneyList = null;

        //������z�����敪���X�g
        //private List<SalesProcMoney> _salesProcMoneyList = null;

        // ---- 2013/08/15 杍^ ---- >>>>>
        //Thread���A���b�Z�[�W�֌W
        private const string MSGSHOWSOLT = "MSGSHOWSOLT";
        private LocalDataStoreSlot msgShowSolt = null;

        #region ���񋓑�
        /// <summary>
        /// �I�v�V�����L���L��
        /// </summary>
        public enum Option : int
        {
            /// <summary>�������[�U</summary>
            OFF = 0,
            /// <summary>�L�����[�U</summary>
            ON = 1,
        }
        #endregion

        /// <summary>�e�L�X�g�o�̓I�v�V�������</summary>
        private int _opt_FuTaBa;//OPT-CPM0110�F�t�^�oUOE�I�v�V�����i�ʁj

        //��pUSB�p
        Broadleaf.Application.Remoting.ParamData.PurchaseStatus fuTaBaPs;
        // ---- 2013/08/15 杍^ ---- <<<<<
        # endregion

		// ===================================================================================== //
		// �萔�Q
		// ===================================================================================== //
		#region Public Const Member

        /// <summary>�[�������Ώۋ��z�敪�i���z�j</summary>
        public const int ctFracProcMoneyDiv_Price = 0;
        /// <summary>�[�������Ώۋ��z�敪�i����Łj</summary>
        public const int ctFracProcMoneyDiv_Tax = 1;
        /// <summary>�[�������Ώۋ��z�敪�i�P���j</summary>
        public const int ctFracProcMoneyDiv_UnitPrice = 2;
        /// <summary>�[�������Ώۋ��z�敪�i�����P���j</summary>
        public const int ctFracProcMoneyDiv_UnitCost = 3;
        /// <summary>�[�������Ώۋ��z�敪�i�����j</summary>
        public const int ctFracProcMoneyDiv_Cost = 4;

        /// <summary>���[�J��DB�ǂݍ��݃��[�h</summary>
        //public static readonly bool ctIsLocalDBRead = true;
        public static readonly bool ctIsLocalDBRead = false;

		// ���b�Z�[�W
		private const string MESSAGE_NoResult = "�����Ɉ�v����f�[�^�͑��݂��܂���B";
        // private const string MESSAGE_ErrResult = "�f�[�^�̎擾�Ɏ��s���܂����B";  //DEL pengjie 2013/03/14 REDMINE#34986
        private const string MESSAGE_ErrResult = "�����f�[�^�̒��o�����s���܂����B"; //ADD pengjie 2013/03/14 REDMINE#34986
		private const string MESSAGE_NotFound = "�����Ώۂ̃f�[�^�����݂��܂���B";
        private const string OPENFLAG = "OPEN���i"; // ADD chenw 2013/03/07 Redmine#34989
        private const string MESSAGE_TimeOut = "���������������ݍ����Ă��邽�߁A���΂炭��ɍēx���s���Ă��������B";   //ADD pengjie 2013/03/14 REDMINE#34986

		# endregion

		// ===================================================================================== //
		// �f���Q�[�g
		// ===================================================================================== //
		# region Delegate
		# endregion

		// ===================================================================================== //
		// �C�x���g
		// ===================================================================================== //
		# region Event
		# endregion

		// ===================================================================================== //
		// �v���p�e�B
		// ===================================================================================== //
		# region Properties
        # region �ŗ��ݒ�}�X�^�I�u�W�F�N�g�擾
        /// <summary>
        /// �ŗ��ݒ�}�X�^�I�u�W�F�N�g�擾
        /// </summary>
        /// <returns>�ŗ��ݒ�}�X�^�I�u�W�F�N�g</returns>
        public TaxRateSet taxRateSet
        {
            get { return this._taxRateSet; }
            set { this._taxRateSet = value; }
        }
        # endregion

        # region �d�����z�����敪�ݒ胊�X�g
        /// <summary>�d�����z�����敪�ݒ胊�X�g</summary>
        public List<StockProcMoney> StockProcMoneyList
        {
            get { return this._stockProcMoneyList; }
        }
        # endregion

        # region �d�����z�v�Z�A�N�Z�X�N���X
        /// <summary>�d�����z�v�Z�A�N�Z�X�N���X</summary>
        public StockPriceCalculate stockPriceCalculate
        {
            get { return this._stockPriceCalculate; }
        }
        # endregion

        # region ������z�v�Z�A�N�Z�X�N���X
        /// <summary>������z�v�Z�A�N�Z�X�N���X</summary>
        public SalesPriceCalculate salesPriceCalculate

        {
            get { return this._salesPriceCalculate; }
        }
        # endregion
        # endregion

		// ===================================================================================== //
		// �p�u���b�N���\�b�h
		// ===================================================================================== //
		# region Public Methods
        # region ���d�����z�����敪�ݒ�}�X�^�L���b�V�����䏈��
        /// <summary>
        /// �d�����z�����敪�ݒ�}�X�^�L���b�V������
        /// </summary>
        /// <param name="stockProcMoney">�d�����z�����敪�ݒ�}�X�^���[�N�N���X</param>
        internal void CacheStockProcMoney(StockProcMoney stockProcMoney)
        {
            try
            {
                _StockProcMoney.AddStockProcMoneyRow(this.RowFromUIData(stockProcMoney));
            }
            catch (ConstraintException)
            {
                StockInputInitialDataSet.StockProcMoneyRow row = this._StockProcMoney.FindByFracProcMoneyDivFractionProcCodeUpperLimitPrice(stockProcMoney.FracProcMoneyDiv, stockProcMoney.FractionProcCode, stockProcMoney.UpperLimitPrice);
                this.SetRowFromUIData(ref row, stockProcMoney);
            }
        }
        
        /// <summary>
        /// �d�����z�����敪�ݒ�}�X�^���[�N�N���X�̎擾
        /// </summary>
        /// <param name="fracProcMoneyDiv">�[�������Ώۋ��z�敪</param>
        /// <param name="fractionProcCode">�[�������R�[�h</param>
        /// <param name="upperLimitPrice">������z</param>
        /// <returns></returns>
        public StockProcMoney GetStockProcMoney(int fracProcMoneyDiv, int fractionProcCode, double upperLimitPrice)
        {
            StockProcMoney stockProcMoney = null;

            try
            {
                StockInputInitialDataSet.StockProcMoneyRow row = this._StockProcMoney.FindByFracProcMoneyDivFractionProcCodeUpperLimitPrice(
                                                                    fracProcMoneyDiv,
                                                                    fractionProcCode,
                                                                    upperLimitPrice);
                stockProcMoney = GetStockProcMoneyFromRow(row);
            }
            catch (ConstraintException)
            {
                stockProcMoney = null;
            }

            return (stockProcMoney);
        }

        /// <summary>
        /// �d�����z�����敪�ݒ�}�X�^�I�u�W�F�N�g���d�����z�����敪�ݒ�}�X�^�s�I�u�W�F�N�g�ݒ菈��
        /// </summary>
        /// <param name="row">�d�����z�����敪�ݒ�}�X�^�s�N���X</param>
        /// <param name="stockProcMoney">�d�����z�����敪�ݒ�}�X�^���[�N�N���X</param>
        internal void SetRowFromUIData(ref StockInputInitialDataSet.StockProcMoneyRow row, StockProcMoney stockProcMoney)
        {
            // �[�������Ώۋ��z�敪
            row.FracProcMoneyDiv = stockProcMoney.FracProcMoneyDiv;

            // �[�������R�[�h
            row.FractionProcCode = stockProcMoney.FractionProcCode;

            // ������z
            row.UpperLimitPrice = stockProcMoney.UpperLimitPrice;

            // �[�������P��
            row.FractionProcUnit = stockProcMoney.FractionProcUnit;

            // �[�������敪
            row.FractionProcCd = stockProcMoney.FractionProcCd;
        }

        /// <summary>
        /// �d�����z�����敪�ݒ�}�X�^���[�N�N���X�̎擾
        /// </summary>
        /// <param name="row">�d�����z�����敪�ݒ�}�X�^�s�N���X</param>
        /// <returns>�d�����z�����敪�ݒ�}�X�^���[�N�N���X</returns>
        internal StockProcMoney GetStockProcMoneyFromRow(StockInputInitialDataSet.StockProcMoneyRow row)
        {

            StockProcMoney stockProcMoney = new StockProcMoney();

            if (row != null)
            {
                // �[�������Ώۋ��z�敪
                stockProcMoney.FracProcMoneyDiv = (int)row.FracProcMoneyDiv;

                // �[�������R�[�h
                stockProcMoney.FractionProcCode = (int)row.FractionProcCode;

                // ������z
                stockProcMoney.UpperLimitPrice = (double)row.UpperLimitPrice;

                // �[�������P��
                stockProcMoney.FractionProcUnit = (double)row.FractionProcUnit;

                // �[�������敪
                stockProcMoney.FractionProcCd = (int)row.FractionProcCd;
            }

            return (stockProcMoney);
        }

        /// <summary>
        /// �d�����z�����敪�ݒ�}�X�^�I�u�W�F�N�g���d�����z�����敪�ݒ�}�X�^�s�I�u�W�F�N�g�ϊ�����
        /// </summary>
        /// <param name="stockProcMoney">�d�����z�����敪�ݒ�}�X�^�I�u�W�F�N�g</param>
        /// <returns>�d�����z�����敪�ݒ�}�X�^�s�I�u�W�F�N�g</returns>
        internal StockInputInitialDataSet.StockProcMoneyRow RowFromUIData(StockProcMoney stockProcMoney)
        {
            StockInputInitialDataSet.StockProcMoneyRow row = _StockProcMoney.NewStockProcMoneyRow();

            this.SetRowFromUIData(ref row, stockProcMoney);
            return row;
        }
        # endregion

        # region �d�����z���v�Z���܂��B
        /// <summary>
        /// �d�����z���v�Z���܂��B
        /// </summary>
        /// <param name="stockCount">�d����</param>
        /// <param name="stockUnitPrice">�d���P��</param>
        /// <param name="taxationCode">�ېŋ敪</param>
        /// <param name="stockMoneyFrcProcCd">�d�����z�[�������R�[�h</param>
        /// <param name="taxFracProcCode">����Œ[�������敪</param>
        /// <param name="stockPriceTaxInc">�d�����z�i�ō��݁j</param>
        /// <param name="stockPriceTaxExc">�d�����z�i�Ŕ����j</param>
        /// <param name="stockPriceConsTax">�d�������</param>
        /// <returns></returns>
        public bool CalculationStockPrice(double stockCount, double stockUnitPrice, int taxationCode, int stockMoneyFrcProcCd, int taxFracProcCode, out long stockPriceTaxInc, out long stockPriceTaxExc, out long stockPriceConsTax)
        {
            double taxFracProcUnit;
            int taxFracProcCd;
            double taxRate = GetTaxRate(DateTime.Now);

            GetFractionProcInfo(StockSlipInputInitDataAcs.ctFracProcMoneyDiv_Tax, taxFracProcCode, 0, out taxFracProcUnit, out taxFracProcCd);

            stockPriceTaxInc = 0;
            stockPriceTaxExc = 0;
            stockPriceConsTax = 0;

            // �d������0�܂��͎d���P����0�̏ꍇ�͂��ׂ�0�ŏI��
            if ((stockCount == 0) || (stockUnitPrice == 0)) return true;

            // �O�ł̏ꍇ
            if (taxationCode == (int)CalculateTax.TaxationCode.TaxExc)
            {
                double unitPriceExc = stockUnitPrice;     // �P���i�Ŕ����j
                double unitPriceInc;�@�@�@�@�@�@�@�@�@�@�@// �P���i�ō��݁j
                double unitPriceTax;�@�@�@�@�@�@�@�@�@�@�@// �P���i����Łj
                long priceExc = 0;�@�@�@�@�@�@�@�@�@�@�@�@// ���i�i�Ŕ����j
                long priceInc;�@�@�@�@�@�@�@�@�@�@�@�@�@�@// ���i�i�ō��݁j
                long priceTax;�@�@�@�@�@�@�@�@�@�@�@�@�@�@// ���i�i����Łj

                this._stockPriceCalculate.CalcTaxIncFromTaxExc((int)CalculateTax.TaxationCode.TaxExc, stockCount, ref unitPriceExc, out unitPriceInc, out unitPriceTax, ref priceExc, out priceInc, out priceTax, stockMoneyFrcProcCd, taxRate, taxFracProcUnit, taxFracProcCd);

                stockPriceTaxInc = priceInc;			// �d�����z�i�ō��݁j
                stockPriceTaxExc = priceExc;			// �d�����z�i�Ŕ����j
                stockPriceConsTax = priceTax;			// �d�������
            }
            // ���ł̏ꍇ
            else if (taxationCode == (int)CalculateTax.TaxationCode.TaxInc)
            {
                double unitPriceExc;�@�@�@�@�@�@�@�@�@�@�@�@// �P���i�Ŕ����j
                double unitPriceInc = stockUnitPrice;�@�@ �@// �P���i�ō��݁j
                double unitPriceTax;�@�@�@�@�@�@�@�@�@�@�@�@// �P���i����Łj
                long priceExc;�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@// ���i�i�Ŕ����j
                long priceInc = 0;�@�@�@�@�@�@�@�@�@�@�@�@�@// ���i�i�ō��݁j
                long priceTax;�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@// ���i�i����Łj

                this._stockPriceCalculate.CalcTaxExcFromTaxInc((int)CalculateTax.TaxationCode.TaxInc, stockCount, out unitPriceExc, ref unitPriceInc, out unitPriceTax, out priceExc, ref priceInc, out priceTax, stockMoneyFrcProcCd, taxRate, taxFracProcUnit, taxFracProcCd);

                stockPriceTaxInc = priceInc;		// �d�����z�i�ō��݁j
                stockPriceTaxExc = priceExc;		// �d�����z�i�Ŕ����j
                stockPriceConsTax = priceTax;		// �d�������
            }
            // ��ېł̏ꍇ
            else if (taxationCode == (int)CalculateTax.TaxationCode.TaxNone)
            {
                double unitPriceExc = stockUnitPrice;       // �P���i�Ŕ����j
                double unitPriceInc;                        // �P���i�ō��݁j
                double unitPriceTax;                        // �P���i����Łj
                long priceExc = 0;                          // ���i�i�Ŕ����j
                long priceInc;                              // ���i�i�ō��݁j
                long priceTax;                              // ���i�i����Łj

                this._stockPriceCalculate.CalcTaxIncFromTaxExc((int)CalculateTax.TaxationCode.TaxNone, stockCount, ref unitPriceExc, out unitPriceInc, out unitPriceTax, ref priceExc, out priceInc, out priceTax, stockMoneyFrcProcCd, taxRate, taxFracProcUnit, taxFracProcCd);

                stockPriceTaxInc = priceExc;                // �d�����z�i�ō��݁j
                stockPriceTaxExc = priceExc;                // �d�����z�i�ō��݁j
                stockPriceConsTax = priceTax;               // �d�������
            }

            return true;
        }
        #endregion

        #region �d�����z�����敪�ݒ�}�X�^ �f�[�^�擾�����֘A
        /// <summary>
        /// �[�������P�ʁA�[�������敪�擾����
        /// </summary>
        /// <param name="fracProcMoneyDiv">�[�������Ώۋ��z�敪</param>
        /// <param name="fractionProcCode">�[�������R�[�h</param>
        /// <param name="targetPrice">�Ώۋ��z</param>
        /// <param name="fractionProcUnit">�[�������P��</param>
        /// <param name="fractionProcCd">�[�������敪</param>
        /// 
        public void GetFractionProcInfo(int fracProcMoneyDiv, int fractionProcCode, double targetPrice, out double fractionProcUnit, out int fractionProcCd)
        {
            //�f�t�H���g
            switch (fracProcMoneyDiv)
            {
                case ctFracProcMoneyDiv_UnitPrice: // �P����0.01�~�P��
                    fractionProcUnit = 0.01;
                    break;
                default:
                    fractionProcUnit = 1;               // �P���ȊO��1�~�P��
                    break;
            }
            fractionProcCd = 1;     // �؎̂�

            // �[�������Ώۋ��z�敪�A�[�������R�[�h����v����f�[�^�������Ɏ擾
            DataRow[] dr = this._StockProcMoney.Select(string.Format("{0} = {1} AND {2} = {3}", this._StockProcMoney.FracProcMoneyDivColumn.ColumnName,
                                                                                                        fracProcMoneyDiv,
                                                                                                        this._StockProcMoney.FractionProcCodeColumn, fractionProcCode,
                                                                                                        fractionProcCode),
                                                               string.Format("{0} DESC", this._StockProcMoney.UpperLimitPriceColumn.ColumnName));

            foreach (StockInputInitialDataSet.StockProcMoneyRow stockProcMoneyRow in dr)
            {
                if (stockProcMoneyRow.UpperLimitPrice < targetPrice)
                {
                    break;
                }
                fractionProcUnit = stockProcMoneyRow.FractionProcUnit;
                fractionProcCd = stockProcMoneyRow.FractionProcCd;
            }
        }
        #endregion


        # region �ŗ��ݒ�}�X�^�L���b�V������
        /// <summary>
        /// �ŗ��ݒ�}�X�^�L���b�V������
        /// </summary>
        /// <param name="taxRateSet">�ŗ��ݒ�}�X�^�I�u�W�F�N�g</param>
        internal void CacheTaxRateSet(TaxRateSet taxRateSet)
        {
            this._taxRateSet = taxRateSet;
        }

        /// <summary>
        /// �ŗ��ݒ�}�X�^�I�u�W�F�N�g�擾
        /// </summary>
        /// <returns>�ŗ��ݒ�}�X�^�I�u�W�F�N�g</returns>
        public TaxRateSet GetTaxRateSet()
        {
            return this._taxRateSet;
        }

        /// <summary>
        /// �ŗ��ݒ�}�X�^�œo�^����Ă������ŗ����擾���܂��B
        /// </summary>
        /// <param name="addUpDate">�v���</param>
        /// <returns>����ŗ�</returns>
        public double GetTaxRate(DateTime addUpDate)
        {
            return TaxRateSetAcs.GetTaxRate(this.GetTaxRateSet(), addUpDate);
        }

        /// <summary>
        /// �ŗ��ݒ�}�X�^�ɐݒ肳��Ă������Ŗ��̂��擾���܂��B
        /// </summary>
        /// <returns>����ŕ\������</returns>
        public string GetTaxRateName()
        {
            string result = "";
            TaxRateSet taxRateSet = this.GetTaxRateSet();

            if (taxRateSet == null) return result;

            return taxRateSet.TaxRateName;
        }
        # endregion

        # region �d���ō����z�̎擾(double)
        /// <summary>
        /// �d���ō����z�̎擾(double)
        /// </summary>
        /// <param name="targetPrice">�Ώۋ��z</param>
        /// <param name="taxationCode">�ېŋ敪</param>
        /// <param name="stockCnsTaxFrcProcCd">�d������Œ[�������R�[�h</param>
        /// <returns>�ō��݋��z</returns>
        public double GetStockPriceTaxInc(double targetPrice, int taxationCode, int stockCnsTaxFrcProcCd)
        {
            double priceTaxExc = 0;     //�Ŕ������z
            double priceTaxInc = 0;     //�ō��݋��z
            double priceConsTax = 0;    //����ŋ��z
            double taxFracProcUnit = 0; //����Œ[�������P��
            int taxFracProcCd = 0;      //����Œ[�������敪

            double taxRate = GetTaxRate(DateTime.Now);

            stockPriceCalculate.CalculatePrice(
                                        taxationCode,        //�ېŋ敪
                                        targetPrice,         //�Ώۋ��z
                                        taxRate,             //�ŗ�
                                        stockCnsTaxFrcProcCd,//�d������Œ[�������R�[�h
                                        out priceTaxExc,     //�Ŕ������z
                                        out priceTaxInc,     //�ō��݋��z
                                        out priceConsTax,    //����ŋ��z
                                        out taxFracProcUnit, //����Œ[�������P��
                                        out taxFracProcCd ); //����Œ[�������敪
            return(priceTaxInc);
        }
        #endregion

        # region �d���ō����z�̎擾(long)
        /// <summary>
        /// �d���ō����z�̎擾(long)
        /// </summary>
        /// <param name="targetPrice">�Ώۋ��z</param>
        /// <param name="taxationCode">�ېŋ敪</param>
        /// <param name="stockCnsTaxFrcProcCd">�d������Œ[�������R�[�h</param>
        /// <returns>�ō��݋��z</returns>
        public long GetStockPriceTaxInc(long targetPrice, int taxationCode, int stockCnsTaxFrcProcCd)
        {
            long priceTaxExc = 0;       //�Ŕ������z
            long priceTaxInc = 0;       //�ō��݋��z
            long priceConsTax = 0;      //����ŋ��z
            double taxFracProcUnit = 0; //����Œ[�������P��
            int taxFracProcCd = 0;      //����Œ[�������敪

            double taxRate = GetTaxRate(DateTime.Now);
    
            stockPriceCalculate.CalculatePrice(
                                        taxationCode,        //�ېŋ敪
                                        targetPrice,         //�Ώۋ��z
                                        taxRate,             //�ŗ�
                                        stockCnsTaxFrcProcCd,//�d������Œ[�������R�[�h
                                        out priceTaxExc,     //�Ŕ������z
                                        out priceTaxInc,     //�ō��݋��z
                                        out priceConsTax,    //����ŋ��z
                                        out taxFracProcUnit, //����Œ[�������P��
                                        out taxFracProcCd ); //����Œ[�������敪
            return(priceTaxInc);
        }
        #endregion

        # region ����ō����z�̎擾(double)
        /// <summary>
        /// ����ō����z�̎擾(double)
        /// </summary>
        /// <param name="targetPrice">�Ώۋ��z</param>
        /// <param name="taxationCode">�ېŋ敪</param>
        /// <param name="salesCnsTaxFrcProcCd">�d������Œ[�������R�[�h</param>
        /// <returns>�ō��݋��z</returns>
        public double GetSalesPriceTaxInc(double targetPrice, int taxationCode, int salesCnsTaxFrcProcCd)
        {
            double priceTaxExc = 0;     //�Ŕ������z
            double priceTaxInc = 0;     //�ō��݋��z
            double priceConsTax = 0;    //����ŋ��z
            double taxFracProcUnit = 0; //����Œ[�������P��
            int taxFracProcCd = 0;      //����Œ[�������敪

            double taxRate = GetTaxRate(DateTime.Now);

            salesPriceCalculate.CalculatePrice(
                                        taxationCode,        //�ېŋ敪
                                        targetPrice,         //�Ώۋ��z
                                        taxRate,             //�ŗ�
                                        salesCnsTaxFrcProcCd,//�������Œ[�������R�[�h
                                        out priceTaxExc,     //�Ŕ������z
                                        out priceTaxInc,     //�ō��݋��z
                                        out priceConsTax,    //����ŋ��z
                                        out taxFracProcUnit, //����Œ[�������P��
                                        out taxFracProcCd); //����Œ[�������敪
            return (priceTaxInc);
        }
        #endregion

        # region ����ō����z�̎擾(long)
        /// <summary>
        /// ����ō����z�̎擾(long)
        /// </summary>
        /// <param name="targetPrice">�Ώۋ��z</param>
        /// <param name="taxationCode">�ېŋ敪</param>
        /// <param name="stockCnsTaxFrcProcCd">�d������Œ[�������R�[�h</param>
        /// <returns>�ō��݋��z</returns>
        public long GetSalesPriceTaxInc(long targetPrice, int taxationCode, int salesCnsTaxFrcProcCd)
        {
            long priceTaxExc = 0;       //�Ŕ������z
            long priceTaxInc = 0;       //�ō��݋��z
            long priceConsTax = 0;      //����ŋ��z
            double taxFracProcUnit = 0; //����Œ[�������P��
            int taxFracProcCd = 0;      //����Œ[�������敪

            double taxRate = GetTaxRate(DateTime.Now);

            stockPriceCalculate.CalculatePrice(
                                        taxationCode,        //�ېŋ敪
                                        targetPrice,         //�Ώۋ��z
                                        taxRate,             //�ŗ�
                                        salesCnsTaxFrcProcCd,//�������Œ[�������R�[�h
                                        out priceTaxExc,     //�Ŕ������z
                                        out priceTaxInc,     //�ō��݋��z
                                        out priceConsTax,    //����ŋ��z
                                        out taxFracProcUnit, //����Œ[�������P��
                                        out taxFracProcCd); //����Œ[�������敪
            return (priceTaxInc);
        }
        #endregion

        # region �t�n�d�����f�[�^�E�d�����ׂ̍쐬����
        /// <summary>
        /// �t�n�d�����f�[�^�E�d�����ׂ̍쐬����
        /// </summary>
        /// <param name="uOEOrderDtlWorkList">�t�n�d�����v�n�q�j���X�g</param>
        /// <param name="StockDetailWorkList">�d�����ׂv�n�q�j���X�g</param>
        /// <param name="message">�G���[���b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        public int WriteUOEOrderDtl(
            ref List<UOEOrderDtlWork> uOEOrderDtlWorkList,
            ref List<StockDetailWork> stockDetailWorkList,
            out string message)
        {
            IOWriteCtrlOptWork iOWriteCtrlOptWork = new IOWriteCtrlOptWork();
            List<SlipDetailAddInfoWork> slipDetailAddInfoWorkList = new List<SlipDetailAddInfoWork>();

            return (WriteUOEOrderDtl(
                ref iOWriteCtrlOptWork,
                ref slipDetailAddInfoWorkList,
                ref uOEOrderDtlWorkList,
                ref stockDetailWorkList,
                out message));
        }
		# endregion

        # region �t�n�d�����f�[�^�E�d�����ׂ̍쐬����
        /// <summary>
        /// �t�n�d�����f�[�^�E�d�����ׂ̍쐬����
        /// </summary>
        /// <param name="iOWriteCtrlOptWork">����E�d������I�v�V����</param>
        /// <param name="slipDetailAddInfoWorkList">�`�[���גǉ����f�[�^���X�g</param>
        /// <param name="uOEOrderDtlWorkList">�t�n�d�����v�n�q�j���X�g</param>
        /// <param name="StockDetailWorkList">�d�����ׂv�n�q�j���X�g</param>
        /// <param name="message">�G���[���b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        public int WriteUOEOrderDtl(
            ref IOWriteCtrlOptWork iOWriteCtrlOptWork,
            ref List<SlipDetailAddInfoWork> slipDetailAddInfoWorkList,
            ref List<UOEOrderDtlWork> uOEOrderDtlWorkList,
            ref List<StockDetailWork> stockDetailWorkList,
            out string message)
        {
            // ---- ADD 2013/08/15 杍^ ---- >>>>>
            //�t�^�oUSB��p�ł���ꍇ�AThread���A���b�Z�[�W�̒l���擾
            if (this._opt_FuTaBa == (int)Option.ON)
            {
                msgShowSolt = Thread.GetNamedDataSlot(MSGSHOWSOLT);
            }
            // ---- ADD 2013/08/15 杍^ ---- <<<<<
           
            # region �ϐ��̏�����
			//�ϐ��̏�����
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			message = "";

            //�߂�l�̏�����

            //ArrayList�̏�����
            ArrayList slipDetailAddInfoWorkArry = null;
            ArrayList uOEOrderDtlWorkArry = null;
            ArrayList stockDetailWorkArry = null;
            # endregion

			try
			{
                # region �t�n�d�����f�[�^���X�g���e�탊�X�g���擾
                status = GetOrderWorkFromUOEOrderDtl(
                    uOEOrderDtlWorkList,
                    stockDetailWorkList,
                    out uOEOrderDtlWorkArry,
                    out stockDetailWorkArry,
                    out slipDetailAddInfoWorkArry,
                    out message);

                if(status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    return(status);
                }
                # endregion

                # region �����[�g�����̃p�����[�^�ݒ�
                //����E�d������I�v�V�����̐ݒ�
                IOWriteCtrlOptWork iOWriteCtrlOptWorkClass = new IOWriteCtrlOptWork();

                iOWriteCtrlOptWorkClass.CtrlStartingPoint = 1;              //����N�_
                iOWriteCtrlOptWorkClass.AcpOdrrAddUpRemDiv = 0;             //�󒍃f�[�^�v��c�敪
                iOWriteCtrlOptWorkClass.ShipmAddUpRemDiv = 0;               //�o�׃f�[�^�v��c�敪
                iOWriteCtrlOptWorkClass.RetGoodsStockEtyDiv = 0;            //�ԕi���݌ɓo�^�敪
                iOWriteCtrlOptWorkClass.SupplierSlipDelDiv = 0;             //�d���`�[�폜�敪
                iOWriteCtrlOptWorkClass.RemainCntMngDiv = 0;                //�c���Ǘ��敪
                iOWriteCtrlOptWorkClass.EnterpriseCode = _enterpriseCode;   //��ƃR�[�h
                iOWriteCtrlOptWorkClass.CarMngDivCd = 0;                    //�ԗ��Ǘ��敪
                
                //�����[�g�����̃p�����[�^�ݒ�
                CustomSerializeArrayList paraList = new CustomSerializeArrayList();
                CustomSerializeArrayList paraUoeDetailList = new CustomSerializeArrayList();
                CustomSerializeArrayList paraStockList = new CustomSerializeArrayList();

                object objUOEOrderDtlWorkList = (object)uOEOrderDtlWorkArry;
                object objStockDetailWorkList = (object)stockDetailWorkArry;
                object objIOWriteCtrlOptWorkClass = (object)iOWriteCtrlOptWorkClass;
                object objSlipDetailAddInfoWorkList = (object)slipDetailAddInfoWorkArry;


                paraUoeDetailList.Add(objUOEOrderDtlWorkList);
                paraList.Add(paraUoeDetailList);

                paraStockList.Add(objSlipDetailAddInfoWorkList);
                paraStockList.Add(objStockDetailWorkList);

                paraList.Add(paraStockList);
                paraList.Add(objIOWriteCtrlOptWorkClass);

                object objParaList = (object)paraList;
                # endregion

                # region �����[�g�����̌Ăяo��
                //�����[�g�����̌Ăяo��
                string retItemInfo = "";
                do
                {
                    status = _iIOWriteControlDB.Write(ref objParaList, out message, out retItemInfo);
                    if ((status == 850) || (status == 851) || (status == 852))
                    {
                        // ---- DEL 2013/08/15 杍^ --- >>>>>
                        //TMsgDisp.Show(
                        //    //this,
                        //    emErrorLevel.ERR_LEVEL_STOP,
                        //    "",
                        //    "�V�F�A�`�F�b�N�G���[�i���_���b�N�j�ł��B\r"
                        //    + "���������A���������ݍ����Ă��邽�߃^�C���A�E�g���܂����B\r"
                        //    + "�Ď��s���邩�A���΂炭�҂��Ă���ēx�������s���Ă��������B\r",
                        //    status,
                        //    MessageBoxButtons.OK);
                        // ---- DEL 2013/08/15 杍^ --- <<<<<

                        // ---- ADD 2013/08/15 杍^ --- >>>>>
                        //�t�^�o��pUSB�ł͂Ȃ�
                        //��������(�蓮)�Ɣ�������(����)�ł͂Ȃ�
                        //��������(�蓮)�ł���ꍇ
                        if (this._opt_FuTaBa == (int)Option.OFF 
                             || Thread.GetData(msgShowSolt) == null
                             || (Thread.GetData(msgShowSolt) != null && (Int32)Thread.GetData(msgShowSolt) == 2))
                        {
                            TMsgDisp.Show(
                                //this,
                                emErrorLevel.ERR_LEVEL_STOP,
                                "",
                                "�V�F�A�`�F�b�N�G���[�i���_���b�N�j�ł��B\r"
                                + "���������A���������ݍ����Ă��邽�߃^�C���A�E�g���܂����B\r"
                                + "�Ď��s���邩�A���΂炭�҂��Ă���ēx�������s���Ă��������B\r",
                                status,
                                MessageBoxButtons.OK);
                        }
                        else
                        {

                            message = "�V�F�A�`�F�b�N�G���[�i���_���b�N�j�ł��B\r\n"
                            + "���������A���������ݍ����Ă��邽�߃^�C���A�E�g���܂����B\r";

                            return (status);
                        }
                        // ---- ADD 2013/08/15 杍^ --- <<<<<


                    }
                } while ((status == 850) || (status == 851) || (status == 852));

                if(status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    return(status);
                }
                # endregion

                # region �߂�l�̐ݒ�
                //�߂�l�̐ݒ�
                iOWriteCtrlOptWork = new IOWriteCtrlOptWork();
                slipDetailAddInfoWorkList = new List<SlipDetailAddInfoWork>();
                uOEOrderDtlWorkList = new List<UOEOrderDtlWork>();
                stockDetailWorkList = new List<StockDetailWork>();

                CustomSerializeArrayListForAfterWrite(
                    objParaList,
                    ref iOWriteCtrlOptWork,
                    ref slipDetailAddInfoWorkList,
                    ref uOEOrderDtlWorkList,
                    ref stockDetailWorkList);
                # endregion
			}
			catch (Exception ex)
			{
				status = -1;
				message = ex.Message;
			}
			return (status);
        }
        # endregion

        # region �t�n�d�����񓚍X�V����
        /// <summary>
        /// �t�n�d�����񓚍X�V����
        /// </summary>
        /// <param name="stockSlipGrpList">�t�n�d�񓚏��m��p �d���w�b�_�E���׏���`</param>
        /// <param name="uOEOrderDtlWorkList">�t�n�d�����f�[�^��`���X�g</param>
        /// <param name="message">�G���[���b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        public int Write(ref List<StockSlipGrp> stockSlipGrpList, ref List<UOEOrderDtlWork> uOEOrderDtlWorkList, out string message)
		{
			//�ϐ��̏�����
			int status = (int)EnumUoeConst.Status.ct_NORMAL;
			message = "";

			try
			{
				//�p�����[�^�N���X�쐬
                CustomSerializeArrayList csAry = ToCustomSerializeFromStockSlipGrpList(stockSlipGrpList, uOEOrderDtlWorkList);
				object setObj = (object)csAry;

                do
                {
                    status = this._iIOWriteUOEOdrDtlDB.OrderFixation(ref setObj);
                    if ((status == 850) || (status == 851) || (status == 852))
                    {

                        // ---DEL K2014/05/26 ���N�n�� Redmine 42571 --------------------------------------->>>>>
                        //TMsgDisp.Show(
                        //    //this,
                        //    emErrorLevel.ERR_LEVEL_STOP,
                        //    "",
                        //    "�V�F�A�`�F�b�N�G���[�i���_���b�N�j�ł��B\r"
                        //    + "���������A���������ݍ����Ă��邽�߃^�C���A�E�g���܂����B\r"
                        //    + "�Ď��s���邩�A���΂炭�҂��Ă���ēx�������s���Ă��������B\r",
                        //    status,
                        //    MessageBoxButtons.OK);
                        // ---DEL K2014/05/26 ���N�n�� Redmine 42571 ---------------------------------------<<<<<

                        // ---ADD K2014/05/26 ���N�n�� Redmine 42571 --------------------------------------->>>>>
                        //�t�^�o��pUSB�ł͂Ȃ�
                        //��������(�蓮)�Ɣ�������(����)�ł͂Ȃ�
                        //��������(�蓮)�ł���ꍇ
                        if (this._opt_FuTaBa == (int)Option.OFF
                             || Thread.GetData(msgShowSolt) == null
                             || (Thread.GetData(msgShowSolt) != null && (Int32)Thread.GetData(msgShowSolt) == 2))
                        {
                        TMsgDisp.Show(
                            //this,
                            emErrorLevel.ERR_LEVEL_STOP,
                            "",
                            "�V�F�A�`�F�b�N�G���[�i���_���b�N�j�ł��B\r"
                            + "���������A���������ݍ����Ă��邽�߃^�C���A�E�g���܂����B\r"
                            + "�Ď��s���邩�A���΂炭�҂��Ă���ēx�������s���Ă��������B\r",
                            status,
                            MessageBoxButtons.OK);
                    }
                        else
                        {

                            message = "�V�F�A�`�F�b�N�G���[�i���_���b�N�j�ł��B\r\n"
                            + "���������A���������ݍ����Ă��邽�߃^�C���A�E�g���܂����B\r";

                            return (status);
                        }
                        // ---ADD K2014/05/26 ���N�n�� Redmine 42571 ---------------------------------------<<<<<


                    }
                } while ((status == 850) || (status == 851) || (status == 852));

				if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) && (setObj is ArrayList))
				{
                    DivisionCustomSerializeArrayList((CustomSerializeArrayList)setObj, ref stockSlipGrpList, ref uOEOrderDtlWorkList);
				}
				else if ((status == (int)ConstantManagement.DB_Status.ctDB_EOF) ||
						 (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND))
				{
					message = MESSAGE_NoResult;
				}
				else
				{
					message = MESSAGE_NoResult;
				}
			}
			catch (Exception ex)
			{
				status = -1;
				message = ex.Message;
			}
			return (status);
		}
		# endregion

        # region �t�n�d�����f�[�^�̌�������
        /// <summary>
        /// �t�n�d�����f�[�^�̌�������
        /// </summary>
        /// <param name="para">�����p�����[�^</param>
        /// <param name="uOEOrderDtlWorkList">UOE�������[�N</param>
        /// <param name="stockDetailWorkList">�d�����׃��[�N</param>
        /// <param name="message">�G���[���b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        public int Search(UOESendProcCndtnPara para, out List<UOEOrderDtlWork> uOEOrderDtlWorkList, out List<StockDetailWork> stockDetailWorkList, out string message)
		{
			//�ϐ��̏�����
			int status = (int)EnumUoeConst.Status.ct_NORMAL;
            uOEOrderDtlWorkList = new List<UOEOrderDtlWork>();
            stockDetailWorkList = new List<StockDetailWork>();
			message = "";

			try
			{
                UOESendProcCndtnWork uOESendProcCndtnWork = ToUOESendProcCndtnWorkFromPara(para);

                ArrayList uOEOrderDtlWorkAry = new ArrayList(); 
                ArrayList stockDetailWorkAry = new ArrayList();

                object uOESendProcCndtnWorkObj = uOESendProcCndtnWork;
                object uOEOrderDtlWorkAryObj = uOEOrderDtlWorkAry;
                object stockDetailWorkAryObj = stockDetailWorkAry;

                status = this._iIOWriteUOEOdrDtlDB.Search(  uOESendProcCndtnWorkObj,
                                                            ref uOEOrderDtlWorkAryObj,
                                                            ref stockDetailWorkAryObj,
                                                            0,
                                                            ConstantManagement.LogicalMode.GetData0);

                if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                && (uOEOrderDtlWorkAryObj is ArrayList)
                && (stockDetailWorkAryObj is ArrayList))
				{
					ArrayList retUOEOrderDtlWorkAry = (ArrayList)uOEOrderDtlWorkAryObj;
                    ArrayList retStockDetailWorkAry = (ArrayList)stockDetailWorkAryObj;

                    uOEOrderDtlWorkList.AddRange((UOEOrderDtlWork[])retUOEOrderDtlWorkAry.ToArray(typeof(UOEOrderDtlWork)));
                    stockDetailWorkList.AddRange((StockDetailWork[])retStockDetailWorkAry.ToArray(typeof(StockDetailWork)));
				}
				else if ((status == (int)ConstantManagement.DB_Status.ctDB_EOF) ||
						 (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND))
				{
					message = MESSAGE_NoResult;
                    uOEOrderDtlWorkList = null;
                    stockDetailWorkList = null;
                }
                //-----ADD pengjie 2013/03/14 REDMINE#34986 ----->>>>>
                else if (status == (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT || status == (int)ConstantManagement.DB_Status.ctDB_CONCT_TIMEOUT)
                {
                    message = MESSAGE_TimeOut;
                }
                //-----ADD pengjie 2013/03/14 REDMINE#34986 -----<<<<<
				else
				{
					message = MESSAGE_NoResult;
				}
			}
            //catch (Exception ex)// DEL pengjie 2013/03/14 REDMINE#34986
            catch (Exception)// ADD pengjie 2013/03/14 REDMINE#34986
			{
                uOEOrderDtlWorkList = null;
                stockDetailWorkList = null;
				status = -1;
                // message = ex.Message;  // DEL pengjie 2013/03/14 REDMINE#34986
                message = MESSAGE_ErrResult + "ST=" + status; // ADD pengjie 2013/03/14 REDMINE#34986
			}
			return (status);
		}
		# endregion

		# region �t�n�d�����f�[�^�̍폜����
		/// <summary>
		/// �t�n�d�����f�[�^�̍폜����
		/// </summary>
		/// <param name="list">�t�n�d�����f�[�^</param>
		/// <param name="message">���b�Z�[�W</param>
		/// <returns></returns>
		public int Delete(List<UOEOrderDtlWork> list, out string message)
		{
			//�ϐ��̏�����
			int status = (int)EnumUoeConst.Status.ct_NORMAL;
			message = "";

			try
			{
				if (list == null)
				{
					message = MESSAGE_NotFound;
					status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
					return (status);
				}
				if (list.Count == 0)
				{
					message = MESSAGE_NotFound;
					status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
					return (status);
				}

                //�p�����[�^�̐ݒ�
                ArrayList registList = new ArrayList();
                registList.AddRange(list);
				object uoeOrderDtlList = (object)registList;

                status = this._iIOWriteUOEOdrDtlDB.LogicalDelete(ref uoeOrderDtlList);
			}
			catch (Exception ex)
			{
				status = -1;
				message = ex.Message;
			}
			return (status);
		}
		# endregion

		# endregion

		// ===================================================================================== //
		// �v���C�x�[�g���\�b�h
		// ===================================================================================== //
		# region Private Methods
        # region �t�n�d�����m��p�p�����[�^�[�쐬
        /// <summary>
        /// �t�n�d�����m��p�p�����[�^�[�쐬
        /// </summary>
        /// <param name="stockSlipGrpList">�t�n�d�񓚏��m��p �d���w�b�_�E���׏���`</param>
        /// <param name="uOEOrderDtlWorkList">�t�n�d�����f�[�^��`���X�g</param>
        /// <returns>�t�n�d�����m��p�p�����[�^�[</returns>
        private CustomSerializeArrayList ToCustomSerializeFromStockSlipGrpList(List<StockSlipGrp> stockSlipGrpList, List<UOEOrderDtlWork> uOEOrderDtlWorkList)
        {
            //------------------------------------------------------------------------------------
            // csAry�\��
            //------------------------------------------------------------------------------------
            //  CustomSerializeArrayList            �������X�g
            //      --ArrayList                     UOE�����f�[�^���X�g
            //          --UOEOrderDtlWork           UOE�����f�[�^
            //      --CustomSerializeArrayList      �d���f�[�^���X�g
            //          --StockSlipWork             �d���w�b�_�N���X
            //          --ArrayList                 �d�����׃��X�g
            //              --StockDetailWork       �d�����׃N���X
            //------------------------------------------------------------------------------------
            CustomSerializeArrayList csAry = new CustomSerializeArrayList();

            try
            {
                // 2009/05/25 START >>>>>>
                ////UOE�����f�[�^�i�[����
                //ArrayList uOEOrderDtlWorkAry = new ArrayList();
                //uOEOrderDtlWorkAry.AddRange(uOEOrderDtlWorkList);
                //
                ////CustomSerializeArrayList�֐ݒ�
                //csAry.Add(uOEOrderDtlWorkAry);

                if ((uOEOrderDtlWorkList == null)
                || (uOEOrderDtlWorkList.Count == 0))
                {
                }
                else
                {
                    //UOE�����f�[�^�i�[����
                    ArrayList uOEOrderDtlWorkAry = new ArrayList();
                    uOEOrderDtlWorkAry.AddRange(uOEOrderDtlWorkList);

                    //CustomSerializeArrayList�֐ݒ�
                    csAry.Add(uOEOrderDtlWorkAry);
                }
                // 2009/05/25 END   <<<<<<

                //�d�����i�[����
                foreach (StockSlipGrp stockSlipGrp in stockSlipGrpList)
                {
                    CustomSerializeArrayList stockGrpAry = new CustomSerializeArrayList();

                    //�d���w�b�_�N���X
                    stockGrpAry.Add(stockSlipGrp.stockSlipWork);

                    //�d�����׃N���X
                    ArrayList dtl = new ArrayList();
                    dtl.AddRange(stockSlipGrp.stockDetailWorkList);
                    stockGrpAry.Add(dtl);

                    //CustomSerializeArrayList�֐ݒ�
                    csAry.Add(stockGrpAry);
                }

            }
            catch (Exception)
            {
                csAry = null;
            }
            return (csAry);
        }
        # endregion

        # region CustomSerializeArrayList���e��f�[�^�I�u�W�F�N�g�֕���
        /// <summary>
        /// CustomSerializeArrayList���e��f�[�^�I�u�W�F�N�g�֕���
        /// </summary>
        /// <param name="paraList">�J�X�^���V���A���C�Y���X�g�I�u�W�F�N�g</param>
        /// <param name="stockSlipGrpList">�t�n�d�񓚏��m��p �d���w�b�_�E���׏���`</param>
        /// <param name="uOEOrderDtlWorkList">�t�n�d�����f�[�^��`���X�g</param>
        private void DivisionCustomSerializeArrayList(CustomSerializeArrayList paraList, ref List<StockSlipGrp> stockSlipGrpList, ref List<UOEOrderDtlWork> uOEOrderDtlWorkList)
        {
            List<UOEOrderDtlWork> returnUOEOrderDtlWorkList = new List<UOEOrderDtlWork>();
            List<StockSlipGrp> returnStockSlipGrpList = new List<StockSlipGrp>();

            try
            {
                //------------------------------------------------------------------------------------
                // csAry�\��
                //------------------------------------------------------------------------------------
                //  CustomSerializeArrayList            �������X�g
                //      --ArrayList                     UOE�����f�[�^���X�g
                //          --UOEOrderDtlWork           UOE�����f�[�^
                //      --CustomSerializeArrayList      �d���f�[�^���X�g
                //          --StockSlipWork             �d���w�b�_�N���X
                //          --ArrayList                 �d�����׃��X�g
                //              --StockDetailWork       �d�����׃N���X
                //------------------------------------------------------------------------------------


                for (int i = 0; i < paraList.Count; i++)
                {
                    if (paraList[i] is ArrayList)
                    {
                        ArrayList list = (ArrayList)paraList[i];
                        if (list.Count == 0) continue;

                        //UOE�����f�[�^
                        if (list[0] is UOEOrderDtlWork)
                        {
                            foreach (UOEOrderDtlWork work in list)
                            {
                                returnUOEOrderDtlWorkList.Add(work);
                            }
                        }
                        //�d�����
                        else if((list[0] is ArrayList) || (list[0] is StockSlipWork))
                        {
                            StockSlipGrp stockSlipGrp = new StockSlipGrp();
                            for (int j = 0; j < list.Count; j++)
                            {
                                //�d���w�b�_�[
                                if (list[j] is StockSlipWork)
                                {
                                    stockSlipGrp.stockSlipWork = (StockSlipWork)list[j];
                                }
                                //�d������
                                else if (list[j] is ArrayList)
                                {
                                    ArrayList dtlList = (ArrayList)list[j];
                                    if (dtlList[0] is StockDetailWork)
                                    {
                                        foreach (StockDetailWork work in dtlList)
                                        {
                                            stockSlipGrp.stockDetailWorkList.Add(work);
                                        }
                                    }
                                }
                            }
                            returnStockSlipGrpList.Add(stockSlipGrp);
                        }
                    }
                }
            }
            catch (Exception)
            {
                returnStockSlipGrpList = null;
                returnUOEOrderDtlWorkList = null;
            }

            //�߂�l�ݒ�
            stockSlipGrpList = returnStockSlipGrpList;
            uOEOrderDtlWorkList = returnUOEOrderDtlWorkList;
        }
        # endregion

        # region UOE�����f�[�^���o�����ϊ�(para��Work)
        /// <summary>
        /// UOE�����f�[�^���o�����ϊ�(para��Work)
        /// </summary>
        /// <param name="para">UOE�����f�[�^���o�����p�����[�^</param>
        /// <returns>UOE�����f�[�^���o����Work</returns>
        /// <br>Update Note: 2012/09/20 yangmj redmine#23404�̑Ή�</br>
        private UOESendProcCndtnWork ToUOESendProcCndtnWorkFromPara(UOESendProcCndtnPara para)
        {
            UOESendProcCndtnWork returnUOESendProcCndtnWork = new UOESendProcCndtnWork();

   			try
			{
                returnUOESendProcCndtnWork.CashRegisterNo = para.CashRegisterNo;
                returnUOESendProcCndtnWork.CustomerCode = para.CustomerCode;
                returnUOESendProcCndtnWork.EnterpriseCode = para.EnterpriseCode;
                returnUOESendProcCndtnWork.St_InputDay = para.St_InputDay;
                returnUOESendProcCndtnWork.Ed_InputDay = para.Ed_InputDay;
                returnUOESendProcCndtnWork.SystemDivCd = para.SystemDivCd;
                returnUOESendProcCndtnWork.St_UOESalesOrderNo = para.St_UOESalesOrderNo;
                returnUOESendProcCndtnWork.Ed_UOESalesOrderNo = para.Ed_UOESalesOrderNo;
                returnUOESendProcCndtnWork.UOESupplierCd = para.UOESupplierCd;
                returnUOESendProcCndtnWork.St_OnlineNo = para.St_OnlineNo;
                returnUOESendProcCndtnWork.Ed_OnlineNo = para.Ed_OnlineNo;
                returnUOESendProcCndtnWork.DataSendCodes = para.DataSendCodes;
                //-----ADD YANGMJ 2012/09/20 REDMINE#32404 ----->>>>>
                returnUOESendProcCndtnWork.SectionCode = para.SectionCode;
                //-----ADD YANGMJ 2012/09/20 REDMINE#32404 -----<<<<<
			}
			catch (Exception)
			{
                returnUOESendProcCndtnWork = new UOESendProcCndtnWork();;
			}
			return (returnUOESendProcCndtnWork);
        }
		# endregion

        # region �t�n�d�����f�[�^���X�g���t�n�d�����v�n�q�j���X�g�E�d�����ׂv�n�q�j���X�g���擾
        /// <summary>
        /// �t�n�d�����f�[�^���X�g���t�n�d�����v�n�q�j���X�g�E�d�����ׂv�n�q�j���X�g���擾
        /// </summary>
        /// <param name="uOEOrderDtlWorkList">�t�n�d�����v�n�q�j���X�g</param>
        /// <param name="stockDetailWorkList">�d�����ׂv�n�q�j���X�g</param>
        /// <param name="uOEOrderDtlWorkArry">�t�n�d�����v�n�q�j���X�g</param>
        /// <param name="stockDetailWorkArry">�d�����ׂv�n�q�j���X�g</param>
        /// <param name="slipDetailAddInfoWorkArry">�`�[���גǉ����f�[�^���X�g</param>
        /// <param name="message">�G���[���b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        private int GetOrderWorkFromUOEOrderDtl(List<UOEOrderDtlWork> uOEOrderDtlWorkList,
                                                List<StockDetailWork> stockDetailWorkList,
                                                out ArrayList uOEOrderDtlWorkArry,
                                                out ArrayList stockDetailWorkArry,
                                                out ArrayList slipDetailAddInfoWorkArry,
                                                out string message)
        {
            # region �ϐ��̏�����
            //�ϐ��̏�����
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            uOEOrderDtlWorkArry = null;
            stockDetailWorkArry = null;
            slipDetailAddInfoWorkArry = null;
            message = "";

            ArrayList returnUOEOrderDtlWorkArry = new ArrayList();
            ArrayList returnStockDetailWorkArry = new ArrayList();
            ArrayList returnSlipDetailAddInfoWorkArry = new ArrayList();

            //SlipDetailAddInfoWork slipDetailAddInfoWork = new SlipDetailAddInfoWork();  // DEL 2011/10/27
            int slipDtlRegOrder = 0;    //�`�[�E���ׂ̓o�^���ʂ�ݒ�  // ADD 2011/10/27
            #endregion

            try
            {
                for (int i = 0; i < uOEOrderDtlWorkList.Count; i++)
                {
                    //Guid�l�擾
                    Guid guid = Guid.NewGuid();

                    # region �t�n�d�����f�[�^���t�n�d�����v�n�q�j���擾
                    //�t�n�d�����f�[�^���t�n�d�����v�n�q�j���擾
                    UOEOrderDtlWork uOEOrderDtlWork = uOEOrderDtlWorkList[i];
                    uOEOrderDtlWork.DtlRelationGuid = guid;
                    #endregion

                    # region �t�n�d�����f�[�^���d�����ׂv�n�q�j���擾
                    //�t�n�d�����f�[�^���d�����ׂv�n�q�j���擾
                    StockDetailWork stockDetailWork = stockDetailWorkList[i];
                    stockDetailWork.DtlRelationGuid = guid;
                    //--- ADD chenw 2013/03/07 Redmine#34989�@--------->>>>>
                    if (OPENFLAG.Equals(uOEOrderDtlWork.LineErrorMassage.Trim()))
                    {
                        stockDetailWork.OpenPriceDiv = 1;
                    }
                    //--- ADD chenw 2013/03/07 Redmine#34989�@---------<<<<<
                    #endregion

                    # region �`�[���גǉ����f�[�^�ݒ�
                    SlipDetailAddInfoWork slipDetailAddInfoWork = new SlipDetailAddInfoWork();  // ADD 2011/10/27
                    //�`�[���גǉ����f�[�^
                    slipDetailAddInfoWork.DtlRelationGuid = guid;               //���׊֘A�t��GUID
                    slipDetailAddInfoWork.GoodsEntryDiv = 0;                    //���i�o�^�敪
                    slipDetailAddInfoWork.GoodsOfferDate = DateTime.MinValue;   //���i�񋟓��t
                    slipDetailAddInfoWork.PriceUpdateDiv = 0;                   //���i�X�V�敪
                    slipDetailAddInfoWork.PriceStartDate = DateTime.MinValue;   //���i�J�n���t
                    slipDetailAddInfoWork.PriceOfferDate = DateTime.MinValue;   //���i�񋟓��t
                    slipDetailAddInfoWork.CarRelationGuid = Guid.Empty;         //�ԗ��֘A�t��GUID
                    // -- ADD 2011/10/27 ------------------------>>>
                    slipDtlRegOrder++;
                    slipDetailAddInfoWork.SlipDtlRegOrder = slipDtlRegOrder;    //�`�[�o�^�D�揇��
                    // -- ADD 2011/10/27 ------------------------<<<
                    #endregion

                    # region ���X�g�ǉ�����
                    //���X�g�ǉ�����
                    returnUOEOrderDtlWorkArry.Add(uOEOrderDtlWork);
                    returnStockDetailWorkArry.Add(stockDetailWork);
                    returnSlipDetailAddInfoWorkArry.Add(slipDetailAddInfoWork);
                    #endregion
                }

                //���ʂ̊i�[
                uOEOrderDtlWorkArry = returnUOEOrderDtlWorkArry;
                stockDetailWorkArry  = returnStockDetailWorkArry;
                slipDetailAddInfoWorkArry = returnSlipDetailAddInfoWorkArry;
            }
            catch (Exception ex)
            {
                status = -1;
                message = ex.Message;
            }
            return (status);
        }

		# endregion

        #region �J�X�^���V���A���C�Y�A���C���X�g��������
        /// <summary>
        /// �J�X�^���V���A���C�Y�A���C���X�g��������
        /// </summary>
        /// <param name="paraList">�J�X�^���V���A���C�Y�A���C���X�g</param>
        /// <param name="iOWriteCtrlOptWork">����E�d������I�v�V����</param>
        /// <param name="slipDetailAddInfoWorkList">�`�[���גǉ����f�[�^���X�g</param>
        /// <param name="uOEOrderDtlWorkList">�t�n�d�����v�n�q�j���X�g</param>
        /// <param name="stockDetailWorkList">�d�����ׂv�n�q�j���X�g</param>
        private void CustomSerializeArrayListForAfterWrite(object paraList,
            ref IOWriteCtrlOptWork iOWriteCtrlOptWork,
            ref List<SlipDetailAddInfoWork> slipDetailAddInfoWorkList,
            ref List<UOEOrderDtlWork> uOEOrderDtlWorkList,
            ref List<StockDetailWork> stockDetailWorkList)
        {
            foreach (object tempObj in (CustomSerializeArrayList)paraList)
            {
                if (tempObj is IOWriteCtrlOptWork)
                {
                    # region ����E�d������I�v�V����
                    //����E�d������I�v�V����
                    iOWriteCtrlOptWork = (IOWriteCtrlOptWork)tempObj;
                    # endregion
                }
                else if(tempObj is ArrayList)
                {
                    ArrayList tempAry = (ArrayList)tempObj;
                    if(tempAry.Count == 0)  continue;

                    foreach(object tempObj2 in tempAry)
                    {
                        if(tempObj2 is ArrayList)
                        {
                            ArrayList tempAry2 = (ArrayList)tempObj2;

                            if(tempAry2[0] is SlipDetailAddInfoWork)
                            {
                                # region �`�[���גǉ����f�[�^���X�g
                                //�`�[���גǉ����f�[�^���X�g
                                foreach(SlipDetailAddInfoWork work in tempAry2)
                                {
                                    slipDetailAddInfoWorkList.Add(work);
                                }
                                # endregion
                            }
                            else if(tempAry2[0] is UOEOrderDtlWork)
                            {
                                # region �t�n�d�����v�n�q�j���X�g
                                //�t�n�d�����v�n�q�j���X�g
                                foreach (UOEOrderDtlWork work in tempAry2)
                                {
                                    uOEOrderDtlWorkList.Add(work);
                                }
                                # endregion
                            }
                            else if(tempAry2[0] is StockDetailWork)
                            {
                                # region �d�����ׂv�n�q�j���X�g
                                //�d�����ׂv�n�q�j���X�g
                                foreach (StockDetailWork work in tempAry2)
                                {
                                    stockDetailWorkList.Add(work);
                                }
                                # endregion
                            }
                        }

                    }
                }
            }
        }
        # endregion
        # endregion

        // --------- ADD ������ 2014/01/24 for Redmine#41551 -------------- >>>>>>>
        # region �d���ō����z�̎擾(double)

        /// <summary>
        /// �d���ō����z�̎擾(double)
        /// </summary>
        /// <param name="targetPrice">�Ώۋ��z</param>
        /// <param name="taxationCode">�ېŋ敪</param>
        /// <param name="stockCnsTaxFrcProcCd">�d������Œ[�������R�[�h</param>
        /// <param name="stockDate">�d����</param>
        /// <returns>�ō��݋��z</returns>
        public double GetStockPriceTaxInc(double targetPrice, int taxationCode, int stockCnsTaxFrcProcCd, DateTime stockDate)
        {

            double priceTaxExc = 0;     //�Ŕ������z
            double priceTaxInc = 0;     //�ō��݋��z
            double priceConsTax = 0;    //����ŋ��z
            double taxFracProcUnit = 0; //����Œ[�������P��
            int taxFracProcCd = 0;      //����Œ[�������敪

            double taxRate = GetTaxRate(stockDate);

            stockPriceCalculate.CalculatePrice(
                                        taxationCode,        //�ېŋ敪
                                        targetPrice,         //�Ώۋ��z
                                        taxRate,             //�ŗ�
                                        stockCnsTaxFrcProcCd,//�d������Œ[�������R�[�h
                                        out priceTaxExc,     //�Ŕ������z
                                        out priceTaxInc,     //�ō��݋��z
                                        out priceConsTax,    //����ŋ��z
                                        out taxFracProcUnit, //����Œ[�������P��
                                        out taxFracProcCd); //����Œ[�������敪

            return (priceTaxInc);

        }

        #endregion

        # region �d�����z���v�Z���܂��B
        /// <summary>
        /// �d�����z���v�Z���܂��B
        /// </summary>
        /// <param name="stockCount">�d����</param>
        /// <param name="stockUnitPrice">�d���P��</param>
        /// <param name="taxationCode">�ېŋ敪</param>
        /// <param name="stockMoneyFrcProcCd">�d�����z�[�������R�[�h</param>
        /// <param name="taxFracProcCode">����Œ[�������敪</param>
        /// <param name="stockDate">�d����</param>
        /// <param name="stockPriceTaxInc">�d�����z�i�ō��݁j</param>
        /// <param name="stockPriceTaxExc">�d�����z�i�Ŕ����j</param>
        /// <param name="stockPriceConsTax">�d�������</param>
        /// <returns></returns>
        public bool CalculationStockPrice(double stockCount, double stockUnitPrice, int taxationCode, int stockMoneyFrcProcCd, int taxFracProcCode, DateTime stockDate, out long stockPriceTaxInc, out long stockPriceTaxExc, out long stockPriceConsTax)
        {

            double taxFracProcUnit;
            int taxFracProcCd;
            double taxRate = GetTaxRate(stockDate);
            GetFractionProcInfo(StockSlipInputInitDataAcs.ctFracProcMoneyDiv_Tax, taxFracProcCode, 0, out taxFracProcUnit, out taxFracProcCd);

            stockPriceTaxInc = 0;
            stockPriceTaxExc = 0;
            stockPriceConsTax = 0;

            // �d�������܂��͎d���P�����̏ꍇ�͂��ׂĂŏI��
            if ((stockCount == 0) || (stockUnitPrice == 0)) return true;

            // �O�ł̏ꍇ
            if (taxationCode == (int)CalculateTax.TaxationCode.TaxExc)
            {
                double unitPriceExc = stockUnitPrice;     // �P���i�Ŕ����j
                double unitPriceInc;�@�@�@�@�@�@�@�@�@�@�@// �P���i�ō��݁j
                double unitPriceTax;�@�@�@�@�@�@�@�@�@�@�@// �P���i����Łj
                long priceExc = 0;�@�@�@�@�@�@�@�@�@�@�@�@// ���i�i�Ŕ����j
                long priceInc;�@�@�@�@�@�@�@�@�@�@�@�@�@�@// ���i�i�ō��݁j
                long priceTax;�@�@�@�@�@�@�@�@�@�@�@�@�@�@// ���i�i����Łj

                this._stockPriceCalculate.CalcTaxIncFromTaxExc((int)CalculateTax.TaxationCode.TaxExc, stockCount, ref unitPriceExc, out unitPriceInc, out unitPriceTax, ref priceExc, out priceInc, out priceTax, stockMoneyFrcProcCd, taxRate, taxFracProcUnit, taxFracProcCd);

                stockPriceTaxInc = priceInc;                    // �d�����z�i�ō��݁j
                stockPriceTaxExc = priceExc;                    // �d�����z�i�Ŕ����j
                stockPriceConsTax = priceTax;                   // �d�������

            }
            // ���ł̏ꍇ
            else if (taxationCode == (int)CalculateTax.TaxationCode.TaxInc)
            {
                double unitPriceExc;�@�@�@�@�@�@�@�@�@�@�@�@// �P���i�Ŕ����j
                double unitPriceInc = stockUnitPrice;�@�@�@// �P���i�ō��݁j
                double unitPriceTax;�@�@�@�@�@�@�@�@�@�@�@�@// �P���i����Łj
                long priceExc;�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@// ���i�i�Ŕ����j
                long priceInc = 0;�@�@�@�@�@�@�@�@�@�@�@�@�@// ���i�i�ō��݁j
                long priceTax;�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@// ���i�i����Łj

                this._stockPriceCalculate.CalcTaxExcFromTaxInc((int)CalculateTax.TaxationCode.TaxInc, stockCount, out unitPriceExc, ref unitPriceInc, out unitPriceTax, out priceExc, ref priceInc, out priceTax, stockMoneyFrcProcCd, taxRate, taxFracProcUnit, taxFracProcCd);

                stockPriceTaxInc = priceInc;            // �d�����z�i�ō��݁j
                stockPriceTaxExc = priceExc;            // �d�����z�i�Ŕ����j
                stockPriceConsTax = priceTax;           // �d�������
            }
            // ��ېł̏ꍇ
            else if (taxationCode == (int)CalculateTax.TaxationCode.TaxNone)
            {
                double unitPriceExc = stockUnitPrice;       // �P���i�Ŕ����j
                double unitPriceInc;                        // �P���i�ō��݁j
                double unitPriceTax;                        // �P���i����Łj
                long priceExc = 0;                          // ���i�i�Ŕ����j
                long priceInc;                              // ���i�i�ō��݁j
                long priceTax;                              // ���i�i����Łj

                this._stockPriceCalculate.CalcTaxIncFromTaxExc((int)CalculateTax.TaxationCode.TaxNone, stockCount, ref unitPriceExc, out unitPriceInc, out unitPriceTax, ref priceExc, out priceInc, out priceTax, stockMoneyFrcProcCd, taxRate, taxFracProcUnit, taxFracProcCd);

                stockPriceTaxInc = priceExc;                // �d�����z�i�ō��݁j
                stockPriceTaxExc = priceExc;                // �d�����z�i�ō��݁j
                stockPriceConsTax = priceTax;               // �d�������

            }
            return true;

        }

        #endregion
        // --------- ADD ������ 2014/01/24 for Redmine#41551 -------------- <<<<<<
    }
}

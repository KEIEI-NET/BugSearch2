//****************************************************************************//
// �V�X�e��         : PM.NS�V���[�Y
// �v���O��������   : ����E�d���f�[�^�A�N�Z�X�N���X
// �v���O�����T�v   : ����E�d���f�[�^�A�N�Z�X���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10402071-00 �쐬�S�� : ���� �T��
// �� �� ��  2008/05/26  �C�����e : �V�K�쐬
//           2009/05/25  �C�����e : 96186 ���� �T�� �z���_ UOE WEB�Ή�
//           2010/05/10  �C�����e : #7146 PM1007C �O�HUOE-WEB�Ή��ɔ����d�l�ǉ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30517 �Ė� �x��
// �� �� ��  2010/07/05  �C�����e : Mantis.15654�@SCM�ł͂Ȃ����Ӑ�ő��M�����������ꍇ�ł�SCM���M��ʂ��\������Ă��܂����̏C��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���R
// �� �� ��  2011/07/28  �C�����e : �����񓚋敪�ǉ��Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ����
// �� �� ��  2011/11/08  �C�����e : Redmine#26275 UOE�d���f�[�^�쐬�����@�񓚃f�[�^�ɓ`�[�ԍ����Z�b�g����Ă��Ȃ��f�[�^�ɂ��Ă̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 22008 ���� ���n
// �� �� ��  2011/12/02  �C�����e : �[���`�̏ꍇ�Ɍ������Z�b�g����A�e�����s���ƂȂ錻�ۂ̏C��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10707327-00 �쐬�S�� : shij
// �� �� ��  K2011/12/31 �C�����e : 2012/01/25�z�M���Ή� Redmine#27558 UOE���M����/�[���`�̈�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10707327-00 �쐬�S�� : ���N�n
// �� �� ��  2012/02/10  �C�����e : 2012/03/28�z�M���ARedmine#28406 �������M��̃f�[�^�쐬�s��ɂ��Ă̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10802197-00 �쐬�S�� : 30517 �Ė� �x��
// �� �� ��  K2012/06/20 �C�����e : �R�`���i�ʑΉ�
//                                  ����͔����̏ꍇ�A�d���f�[�^���쐬���Ȃ��l�ɏC��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10802197-01 �쐬�S�� : FSI���X�� �M�p
// �� �� ��  K2012/12/11 �C�����e : �R�`���i�ʑΉ�
//                                  �R�`���i���S�ʃI�v�V��������ǉ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10802197-01 �쐬�S�� : �� �B
// �� �� ��  2013/03/01  �C�����e : �P���Z�o���ɔ�����z�����敪���������Q�Ƃł���悤�ɏC��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : chenw
// �� �� ��  2013/03/07  �C�����e : 2013/04/03�z�M��
//                                  Redmine#34989�̑Ή� ���YUOEWEB�̉���(�n�o�d�m���i�Ή�)
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 杍^
// �� �� ��  2013/12/16  �C�����e : Redmine#41551�̑Ή� �����8%���łɔ����āA�������ꂽ��Q�̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ������
// �� �� ��  2014/01/24  �C�����e : Redmine#41551�̑Ή� UOE����őΉ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11070149-00 �쐬�S�� : xupz
// �� �� ��  2014/09/02  �C�����e : Redmine#43365�̑Ή� UOE���M���� �i���J�i�ɑ΂��ĉ񓚌��ʂ̕i�����Z�b�g����Ȃ���
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11100068-00 �쐬�S�� : ���O
// �� �� ��  2015/07/24  �C�����e : Redmine#46880�̑Ή� e-Parts���[�J�[�t�H���[��������d���A�g����Ȃ���Q�̉���
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11670305-00 �쐬�S�� : ���O
// �� �� ��  2020/11/20  �C�����e : PMKOBETSU-4097 TSP�C�����C���@�\�ǉ��Ή�
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
// ADD K2012/12/11 START >>>>>>
using Broadleaf.Application.Resources;
// ADD K2012/12/11 END <<<<<<

namespace Broadleaf.Application.Controller
{
	/// <summary>
	/// ����E�d���f�[�^�A�N�Z�X�N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : ����E�d���f�[�^�A�N�Z�X�N���X</br>
	/// <br>Programmer : 96186 ���ԗT��</br>
	/// <br>Date       : 2008.05.26</br>
	/// <br></br>
	/// <br>UpDate</br>
	/// <br>2008.05.26 men �V�K�쐬</br>
	/// </remarks>
	public partial class UOESalesStockAcs
	{
		// ===================================================================================== //
		// �R���X�g���N�^
		// ===================================================================================== //
		# region Constructors
		public UOESalesStockAcs()
		{
			//��ƃR�[�h���擾����
			this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

			//���O�C�����_�R�[�h
			this._loginSectionCd = LoginInfoAcquisition.Employee.BelongSectionCode;

			//�t�n�d����M�i�m�k�A�N�Z�X�N���X
			this._uoeSndRcvJnlAcs = UoeSndRcvJnlAcs.GetInstance();

            //�A�N�Z�X�N���X �C���X�^���X
            this._uOEOrderDtlAcs = UOEOrderDtlAcs.GetInstance();

            //�����Z�o���W���[���A�N�Z�X�N���X
            this._totalDayCalculator = TotalDayCalculator.GetInstance();

            //�t�n�d����M���䏉�����N���X
            this._uoeSndRcvCtlInitAcs = UoeSndRcvCtlInitAcs.GetInstance();

			//����E�d������A�N�Z�X�N���X
			this._iIOWriteControlDB = (IIOWriteControlDB)MediationIOWriteControlDB.GetIOWriteControlDB();

			//�d������A�N�Z�X�N���X
			this._customerInfoAcs = new CustomerInfoAcs();
			//this._customerInfoAcs.IsLocalDBRead = SalesSlipInputInitDataAcs.ctIsLocalDBRead;

            //����E�d���X�V�A�N�Z�X�N���X
            this._uOESalesStockDataAcs = new UOESalesStockDataAcs();

            // ���ʓ`�[�ԍ���Dictionary
            this._commonSlipNoDictionary = new Dictionary<string, StockSlipWork>();

            //HONDA��pBO�����pDictionary
            this._hondaSlipNoDictionary = new Dictionary<string, string>();

            // ����d���A�g��Dictionary
            // OnlineNo(9)+OnlineRowNo(4)+BOSlipNo
            this._linkSalesStockDictionary = new Dictionary<string,Guid>();

            // (������z�����ݒ�)
            this._salesProcMoneyAcs = new SalesProcMoneyAcs();
            this.CacheSalesProcMoney();

            // (������z�Z�o���W���[��)
            this._salesPriceCalculate = new SalesPriceCalculate();
            _salesPriceCalculate.CacheSalesProcMoneyList(_salesProcMoneyList);

            this._stockPriceCalculate = new StockPriceCalculate();

            this._unitPriceCalculation = new UnitPriceCalculation();
            // --- ADD 2013/03/01 T.Nishi ---------->>>>>
            this._unitPriceCalculation.CacheSalesProcMoneyList(_salesProcMoneyList);
            // --- ADD 2013/03/01 T.Nishi ----------<<<<<
            this._supplierAcs = new SupplierAcs();

            this._salesSlipInputInitDataAcs = SalesSlipInputInitDataAcs.GetInstance();

            // ---ADD ���O 2020/11/20 PMKOBETSU-4097�̑Ή� ------>>>>
            #region ��TSP�I�v�V����
            Broadleaf.Application.Remoting.ParamData.PurchaseStatus ps;
            ps = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_PM_Tsp);
            if (ps == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
            {
                _uOESalesStockDataAcs.Opt_TSP = (int)Broadleaf.Application.Controller.UOEOrderDtlAcs.Option.ON;
            }
            else
            {
                _uOESalesStockDataAcs.Opt_TSP = (int)Broadleaf.Application.Controller.UOEOrderDtlAcs.Option.OFF;
            }
            #endregion
        }
		# endregion

		// ===================================================================================== //
		// �v���C�x�[�g�ϐ�
		// ===================================================================================== //
		# region Private Members
		//��ƃR�[�h
		private string _enterpriseCode = "";

		//���O�C�����_�R�[�h
		private string _loginSectionCd = "";

		//�t�n�d����M�i�m�k�A�N�Z�X�N���X
		private UoeSndRcvJnlAcs _uoeSndRcvJnlAcs = null;

        //�A�N�Z�X�N���X �C���X�^���X
        private UOEOrderDtlAcs _uOEOrderDtlAcs = null;

        //�t�n�d����M���䏉�����N���X
        private UoeSndRcvCtlInitAcs _uoeSndRcvCtlInitAcs = null;

        private UOESalesStockDataAcs _uOESalesStockDataAcs = null;

		//����E�d������A�N�Z�X�N���X
		private IIOWriteControlDB _iIOWriteControlDB = null;

		//�d������A�N�Z�X�N���X
		private CustomerInfoAcs _customerInfoAcs;

		// �d���`�[�폜�敪
		private int _supplierSlipDelDiv;

        // ���ʓ`�[�ԍ���Dictionary
        private Dictionary<string, StockSlipWork> _commonSlipNoDictionary;

        // HONDA��pBO�����pDictionary
        private Dictionary<string, string> _hondaSlipNoDictionary;

        // ���ʓ`�[�ԍ���Dictionary
        // OnlineNo(9)+OnlineRowNo(4)+BOSlipNo
        private Dictionary<string, Guid> _linkSalesStockDictionary;

        // �t�n�d���M��������N���X
        private UoeSndRcvCtlPara _uoeSndRcvCtlPara = null;

        // �����Z�o���W���[��
        private TotalDayCalculator _totalDayCalculator = null;

        private SalesProcMoneyAcs _salesProcMoneyAcs = null;

        private SalesPriceCalculate _salesPriceCalculate;

        private List<SalesProcMoney> _salesProcMoneyList;

        private UnitPriceCalculation _unitPriceCalculation;

        private StockPriceCalculate _stockPriceCalculate;

        private SupplierAcs _supplierAcs;

        private SalesSlipInputInitDataAcs _salesSlipInputInitDataAcs;
        # endregion

		// ===================================================================================== //
		// �萔�Q
		// ===================================================================================== //
		#region Public Const Member
		// ���b�Z�[�W
		private const string MESSAGE_NoResult = "�����Ɉ�v����f�[�^�͑��݂��܂���B";
		private const string MESSAGE_ErrResult = "�f�[�^�̎擾�Ɏ��s���܂����B";
		private const string MESSAGE_NotFound = "�����Ώۂ̃f�[�^�����݂��܂���B";
        private const string OPENFLAG = "OPEN���i"; // ADD chenw 2013/03/07 Redmine#34989

        //�`�[�o�͋敪�̃`�F�b�N�̃p�����[�^
        private const int ctZeroSlip = 0;   //�[���`�[
        private const int ctZeroDtl = 1;    //�[������
        private const int ctAddingUp = 2;   //���Z

        //-----------------------------------------------------------
        // �[�������Ώۋ��z�敪
        //-----------------------------------------------------------
        # region �[�������Ώۋ��z�敪
        /// <summary>�[�������Ώۋ��z�敪�i������z�j</summary>
        internal const int ctFracProcMoneyDiv_SalesMoney = 0;
        /// <summary>�[�������Ώۋ��z�敪�i����Łj</summary>
        internal const int ctFracProcMoneyDiv_Tax = 1;
        /// <summary>�[�������Ώۋ��z�敪�i����P���j</summary>
        internal const int ctFracProcMoneyDiv_SalesUnitPrice = 2;
        ///// <summary>�[�������Ώۋ��z�敪�i�����P���j</summary>
        //internal const int ctFracProcMoneyDiv_SalesUnitCost = 3;
        ///// <summary>�[�������Ώۋ��z�敪�i�������z�j</summary>
        //internal const int ctFracProcMoneyDiv_Cost = 4;
        # endregion

        /// <summary>
        /// ���i�敪
        /// </summary>
        public enum SalesGoodsCd : int
        {
            /// <summary>���i</summary>
            Goods = 0,
            /// <summary>���i�O</summary>
            NonGoods = 1,
            /// <summary>����Œ���</summary>
            ConsTaxAdjust = 2,
            /// <summary>�c������</summary>
            BalanceAdjust = 3,
            /// <summary>���|�p����Œ���</summary>
            AccRecConsTaxAdjust = 4,
            /// <summary>���|�p�c������</summary>
            AccRecBalanceAdjust = 5,
        }

        /// <summary>
        /// ����P�����̓��[�h�񋓌^
        /// </summary>
        public enum SalesUnitPriceInputType : int
        {
            /// <summary>����P���i�Ŕ����j����</summary>
            SalesUnitPrice = 0,
            /// <summary>����P���i�ō��݁j����</summary>
            SalesUnitTaxPrice = 1,
            /// <summary>����P���i�\���p�j����</summary>
            SalesUnitPriceDisplay = 2,
        }

        /// <summary>
        /// ���z�\�����@�敪
        /// </summary>
        internal enum TotalAmountDispWayCd : int
        {
            /// <summary>���z�\�����Ȃ�</summary>
            NoTotalAmount = 0,
            /// <summary>���z�\������</summary>
            TotalAmount = 1,
        }

        /// <summary>
        /// ����œ]�ŕ���
        /// </summary>
        internal enum ConsTaxLayMethod : int
        {
            /// <summary>�`�[�]��</summary>
            SlipLay = 0,
            /// <summary>���ד]��</summary>
            DetailLay = 1,
            /// <summary>�����e</summary>
            DemandParentLay = 2,
            /// <summary>�����q</summary>
            DemandChildLay = 3,
            /// <summary>��ې�</summary>
            TaxExempt = 9,
        }

        /// <summary>
        /// ����`�[�敪�i���ׁj
        /// </summary>
        internal enum SalesSlipCdDtl : int
        {
            /// <summary>����</summary>
            Sales = 0,
            /// <summary>�ԕi</summary>
            RetGoods = 1,
            /// <summary>�l��</summary>
            Discount = 2,
            /// <summary>����</summary>
            Annotation = 3,
            /// <summary>���v</summary>
            Subtotal = 4,
            /// <summary>���</summary>
            Work = 5,
        }

        /// <summary>
        /// ����`�[�敪
        /// </summary>
        public enum SalesSlipCd : int
        {
            /// <summary>����</summary>
            Sales = 0,
            /// <summary>�ԕi</summary>
            RetGoods = 1,
        }

        // 2010/07/05 Add SCM�̓��Ӑ悪���邩�̃`�F�b�N >>>
        public bool scmFlg = false;
        // 2010/07/05 Add <<<

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
        # region �d���`�[�폜�敪
        /// <summary>�d���`�[�폜�敪</summary>
		public int SupplierSlipDelDiv
		{
			set { this._supplierSlipDelDiv = value; }
			get { return this._supplierSlipDelDiv; }
		}
        # endregion

        # region ����M�i�m�k��DataSet��
        /// <summary>
        /// ����M�i�m�k��DataSet��
        /// </summary>
        public DataSet UoeJnlDataSet
        {
            get { return this._uoeSndRcvJnlAcs.UoeJnlDataSet; }
        }
        # endregion

        # region ����M�i�m�k(����)��DataTable��
        /// <summary>
        /// ����M�i�m�k(����)��DataTable��
        /// </summary>
        public DataTable OrderTable
        {
            get { return UoeJnlDataSet.Tables[OrderSndRcvJnlSchema.CT_OrderSndRcvJnlDataTable]; }
        }
        # endregion

        # region �d���f�[�^��DataTable��
        /// <summary>
        /// �d���f�[�^��DataTable��
        /// </summary>
        public DataTable StockSlipTable
        {
            get { return this.UoeJnlDataSet.Tables[StockSlipSchema.CT_StockSlipDataTable]; }
        }
        # endregion

        # region �d�����ׁ�DataTable��
        /// <summary>
        /// �d�����ׁ�DataTable��
        /// </summary>
        public DataTable StockDetailTable
        {
            get { return this.UoeJnlDataSet.Tables[StockDetailSchema.CT_StockDetailDataTable]; }
        }
        # endregion

        # region ����f�[�^��DataTable��
        /// <summary>
        /// ����f�[�^��DataTable��
        /// </summary>
        public DataTable SalesSlipTable
        {
            get { return this.UoeJnlDataSet.Tables[SalesSlipSchema.CT_SalesSlipDataTable]; }
        }
        # endregion

        # region ���㖾�ׁ�DataTable��
        /// <summary>
        /// ���㖾�ׁ�DataTable��
        /// </summary>
        public DataTable SalesDetailTable
        {
            get { return this.UoeJnlDataSet.Tables[SalesDetailSchema.CT_SalesDetailDataTable]; }
        }
        # endregion

        # region �󒍃f�[�^��DataTable��
        /// <summary>
        /// �󒍃f�[�^��DataTable��
        /// </summary>
        public DataTable AcptSlipTable
        {
            get { return this.UoeJnlDataSet.Tables[SalesSlipSchema.CT_AcptSlipDataTable]; }
        }
        # endregion

        # region �󒍖��ׁ�DataTable��
        /// <summary>
        /// �󒍖��ׁ�DataTable��
        /// </summary>
        public DataTable AcptDetailTable
        {
            get { return this.UoeJnlDataSet.Tables[SalesDetailSchema.CT_AcptDetailDataTable]; }
        }
        # endregion

        # region Uoe�d���f�[�^��DataTable��
        /// <summary>
        /// Uoe�d���f�[�^��DataTable��
        /// </summary>
        public DataTable UoeStockSlipTable
        {
            get { return this.UoeJnlDataSet.Tables[StockSlipSchema.CT_UoeStockSlipDataTable]; }
        }
        # endregion

        # region Uoe�d�����ׁ�DataTable��
        /// <summary>
        /// Uoe�d�����ׁ�DataTable��
        /// </summary>
        public DataTable UoeStockDetailTable
        {
            get { return this.UoeJnlDataSet.Tables[StockDetailSchema.CT_UoeStockDetailDataTable]; }
        }
        # endregion

        # region ���i�}�X�^ �A�N�Z�X�N���X
        /// <summary>
        /// ���i�}�X�^ �A�N�Z�X�N���X
        /// </summary>
        public GoodsAcs _goodsAcs
        {
            get { return _uoeSndRcvJnlAcs.goodsAcs; }
            set { _uoeSndRcvJnlAcs.goodsAcs = value; }
        }
        # endregion
        # endregion

        // ===================================================================================== //
		// �p�u���b�N���\�b�h
		// ===================================================================================== //
		# region Public Methods
        # region ����E�d���f�[�^�̍X�V����
		/// <summary>
		/// ����E�d���f�[�^�X�V����
		/// </summary>
        /// <param name="uoeSndRcvCtlPara">�t�n�d���M��������N���X</param>
        /// <param name="message">�G���[���b�Z�[�W</param>
		/// <returns>0:���� 0�ȊO:�G���[</returns>
        public int UpDtSalesStock(UoeSndRcvCtlPara uoeSndRcvCtlPara, out List<UoeSales> uoeSalesList, out string message)
		{
			//�ϐ��̏�����
			int status = (int)EnumUoeConst.Status.ct_NORMAL;
			message = "";
            uoeSalesList = null;

			try
			{
                // ����d���A�g��Dictionary�̏�����
                _linkSalesStockDictionary.Clear();

                // �t�n�d���M��������N���X�̕ۑ�
                _uoeSndRcvCtlPara = uoeSndRcvCtlPara;

                // �f�[�^�e�[�u���̏�����
                this.SalesSlipTable.Clear();
                this.SalesDetailTable.Clear();
                this.AcptSlipTable.Clear();
                this.AcptDetailTable.Clear();
                this.UoeStockSlipTable.Clear();
                this.UoeStockDetailTable.Clear();

                // ����E�d���f�[�^�X�V����
                status = UpDtSalesStockProc(out message);
                if (status == (int)EnumUoeConst.Status.ct_NORMAL)
                {
                    // UOE����`�[�N���X�̍쐬
                    status = UoeSalesFromTableCreate(out uoeSalesList, out message);
                }
			}
			catch (Exception ex)
			{
                uoeSalesList = null;
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
        #region UOE����`�[�N���X�̍쐬
        /// <summary>
        /// UOE����`�[�N���X�̍쐬
        /// </summary>
        /// <param name="uoeSalesList">UOE����`�[�N���X</param>
        /// <param name="message">�G���[���b�Z�[�W</param>
        /// <br>Update Note: 2011/12/31 shij</br>
        /// <br>�Ǘ��ԍ�   �F10707327-00 2012/01/25�z�M���Ή�</br>
        /// <br>             Redmine#27558   UOE���M����/�[���`�̈󎚂̏C��</br>
        /// <returns>�X�e�[�^�X</returns>
        private int UoeSalesFromTableCreate(out List<UoeSales> uoeSalesList, out string message)
        {
            //�ϐ��̏�����
            int status = (int)EnumUoeConst.Status.ct_NORMAL;
            message = "";
            uoeSalesList = new List<UoeSales>();

            try
            {
                //�`���̂ݓ���
                if (_uoeSndRcvCtlPara.SystemDivCd != (int)EnumUoeConst.ctSystemDivCd.ct_Slip)
                {
                    return (status);
                }

                # region ����f�[�^DataView�̍쐬
                Int32 acptAnOdrStatus = 30;   //10:����,20:��,30:����,40:�o�ׁi�󒍃X�e�[�^�X�j

                string rowFilterText = "";
                // UOE���Аݒ�Ͻ���Ұ��̫۰�v��敪������̏ꍇ�ɂ́A�d�n�`�[�E���[�J�[�t�H���[�`�[�Ώ�
                if (_uoeSndRcvJnlAcs.uOESetting.MakerFollowAddUpDiv != (int)EnumUoeConst.ctMakerFollowAddUpDiv.ct_Order)
                {
                    //�[���`�[�������
                    if (CheckZeroSlip() == true)
                    {
                        rowFilterText = string.Format("{0} = {1}",
                                                        SalesSlipSchema.ct_Col_AcptAnOdrStatus, acptAnOdrStatus);
                    }
                    //�[���`�[����Ȃ�
                    else
                    {
                        rowFilterText = string.Format("{0} = {1} AND {2} <> {3}",
                                                        SalesSlipSchema.ct_Col_AcptAnOdrStatus, acptAnOdrStatus,
                                                        SalesSlipSchema.ct_Col_SlipCd, (int)UoeSales.ctSlipCd.ct_Zero);
                    }
                }
                // UOE���Аݒ�Ͻ���Ұ��̫۰�v��敪���󒍂̏ꍇ�ɂ́A�d�n�`�[�E���[�J�[�t�H���[�`�[�ΏۊO
                else
                {
                    /* --------------- DEL 2011.12.31 shij FOR Redmine#27558-------->>>>
                    //�[���`�[����Ȃ�
                    rowFilterText = string.Format("{0} = {1} AND {2} <> {3} AND {4} <> {5} AND {6} <> {7}",
                                                    SalesSlipSchema.ct_Col_AcptAnOdrStatus, acptAnOdrStatus,
                                                    SalesSlipSchema.ct_Col_SlipCd, (int)UoeSales.ctSlipCd.ct_EO,
                                                    SalesSlipSchema.ct_Col_SlipCd, (int)UoeSales.ctSlipCd.ct_Maker,
                                                    SalesSlipSchema.ct_Col_SlipCd, (int)UoeSales.ctSlipCd.ct_Zero);
                    --------------- DEL 2011.12.31 shij FOR Redmine#27558----------<<<<*/
                    // --------------- ADD START 2011.12.31 shij FOR Redmine#27558 -------->>>>
                    //�[���`�[�������
                    if (CheckZeroSlip() == true)
                    {
                        rowFilterText = string.Format("{0} = {1} AND {2} <> {3} AND {4} <> {5}",
                                                        SalesSlipSchema.ct_Col_AcptAnOdrStatus, acptAnOdrStatus,
                                                        SalesSlipSchema.ct_Col_SlipCd, (int)UoeSales.ctSlipCd.ct_EO,
                                                        SalesSlipSchema.ct_Col_SlipCd, (int)UoeSales.ctSlipCd.ct_Maker);
                    }
                    //�[���`�[����Ȃ�
                    else
                    {
                        rowFilterText = string.Format("{0} = {1} AND {2} <> {3} AND {4} <> {5} AND {6} <> {7}",
                                                        SalesSlipSchema.ct_Col_AcptAnOdrStatus, acptAnOdrStatus,
                                                        SalesSlipSchema.ct_Col_SlipCd, (int)UoeSales.ctSlipCd.ct_EO,
                                                        SalesSlipSchema.ct_Col_SlipCd, (int)UoeSales.ctSlipCd.ct_Maker,
                                                        SalesSlipSchema.ct_Col_SlipCd, (int)UoeSales.ctSlipCd.ct_Zero);
                    }
                    // --------------- ADD END 2011.12.31 shij FOR Redmine#27558 ----------<<<<
                }
                string sortText = string.Format("{0}, {1}",
                                                SalesSlipSchema.ct_Col_AcptAnOdrStatus,
                                                SalesSlipSchema.ct_Col_TempSalesSlipNum);
                DataView viewSalesSlip = new DataView(SalesSlipTable);
                viewSalesSlip.Sort = sortText;
                viewSalesSlip.RowFilter = rowFilterText;

                if (viewSalesSlip == null) return (-1);
                if (viewSalesSlip.Count == 0) return (-1);
                # endregion

                foreach (DataRowView rowUoeSalesSlip in viewSalesSlip)
                {
                    //-----------------------------------------------------------
                    // �`�[�N���X�̖��쐬����
                    //-----------------------------------------------------------
                    # region �`�[�N���X�̖��쐬����
                    // �[���`�[�Ȃ��̏ꍇ�A�`�[�N���X���쐬���Ȃ�
                    if ((CheckZeroSlip() != true)
                    && ((Int32)rowUoeSalesSlip[SalesSlipSchema.ct_Col_SlipCd] == (Int32)UoeSales.ctSlipCd.ct_Zero))
                    {
                        continue;
                    }

                    // �m�F�`�[�ŁA����`�[�ԍ������ݒ�̏ꍇ�́A����N���X���쐬���Ȃ�
                    if (((string)rowUoeSalesSlip[SalesSlipSchema.ct_Col_SalesSlipNum] == "")
                    && ((Int32)rowUoeSalesSlip[SalesSlipSchema.ct_Col_SlipCd] == (Int32)UoeSales.ctSlipCd.ct_Section))
                    {
                        continue;
                    }
                    # endregion

                    //-----------------------------------------------------------
                    // ����f�[�^�N���X�̎擾
                    //-----------------------------------------------------------
                    # region ����f�[�^�N���X�̎擾
                    SalesSlipWork salesSlipWork = _uoeSndRcvJnlAcs.CreateSalesSlipWorkFromSchema(rowUoeSalesSlip.Row);
                    string tempSalesSlipNum = (string)rowUoeSalesSlip[SalesSlipSchema.ct_Col_TempSalesSlipNum];
                    # endregion

                    //------------------------------------------------------
                    // ���㖾�׃f�[�^�ɍs�ԍ���ݒ�
                    //------------------------------------------------------
                    # region ���㖾�׃f�[�^�ɍs�ԍ���ݒ�
                    _uoeSndRcvJnlAcs.SetRowNoFromSalesDetail(
                                                    salesSlipWork.AcptAnOdrStatus,
                                                    tempSalesSlipNum,
                                                    0,
                                                    out message
                                                    );
                    # endregion

                    //-----------------------------------------------------------
                    // ���㖾�׃N���X�̎擾
                    //-----------------------------------------------------------
                    # region ���㖾�׃N���X�̎擾
                    List<UoeSalesDetail> uoeSalesDetailList = _uoeSndRcvJnlAcs.SearchUoeSalesDetailDataTable(
                                                    SalesDetailTable,
                                                    salesSlipWork.AcptAnOdrStatus,
                                                    tempSalesSlipNum,
                                                    (int)PrtSalesDetail.ctDetailCd.ct_Normal
                                                    );
                    if (uoeSalesDetailList == null) continue;
                    if (uoeSalesDetailList.Count == 0) continue;
                    # endregion

                    //-----------------------------------------------------------
                    // UOE����`�[�N���X�̊i�[
                    //-----------------------------------------------------------
                    #region UOE����`�[�N���X�̊i�[
                    UoeSales uoeSales = new UoeSales();

                    // UOE���㖾�׃N���X�̐ݒ�
                    int slipDtlZeroMode = 0; //0:�[�����וs�� 1:�[�����׉�
                    if(((Int32)rowUoeSalesSlip[SalesSlipSchema.ct_Col_SlipCd] == (Int32)UoeSales.ctSlipCd.ct_Section)
                    || ((Int32)rowUoeSalesSlip[SalesSlipSchema.ct_Col_SlipCd] == (Int32)UoeSales.ctSlipCd.ct_Zero))
                    {
                        slipDtlZeroMode = 1; //1:�[�����׉�
                    }

                    foreach (UoeSalesDetail uoeSalesDetail in uoeSalesDetailList)
                    {
                        //�[�����ׂ��쐬���Ȃ�����
                        //  �[�����ׂȂ��̐ݒ�
                        //  �[���`�[�ł͂Ȃ�
                        //  �[�����ׂł͂Ȃ�
                        //  �[�����׉�(�m�F�`�[�E�[���`�[�̏ꍇ)
                        PrtSalesDetail prtSalesDetail = uoeSalesDetail.prtSalesDetail;
                        if((CheckZeroDtl() != true)
                        && ((Int32)rowUoeSalesSlip[SalesSlipSchema.ct_Col_SlipCd] != (Int32)UoeSales.ctSlipCd.ct_Zero)
                        && (slipDtlZeroMode == 1)
                        && (prtSalesDetail.detailCd == (int)PrtSalesDetail.ctDetailCd.ct_Zero))
                        {
                            continue;
                        }
                        uoeSales.uoeSalesDetailList.Add(uoeSalesDetail);
                    }

                    //����f�[�^�N���X�̐ݒ�
                    uoeSales.salesSlipWork = salesSlipWork;
                    uoeSales.salesSlipWork.DetailRowCount = uoeSales.uoeSalesDetailList.Count;  //���׍s��

                    //UOE����`�[�N���X�E�����̐ݒ�
                    uoeSales.totalCnt = (int)rowUoeSalesSlip[SalesSlipSchema.ct_Col_TotalCnt];                  //�o�ɐ����v
                    uoeSales.slipCd = (Int32)rowUoeSalesSlip[SalesSlipSchema.ct_Col_SlipCd];                    //UOE�`�[���
                    uoeSalesList.Add(uoeSales);
            		# endregion
                }
            }
            catch (Exception ex)
            {
                uoeSalesList = null;
                status = -1;
                message = ex.Message;
            }
            return (status);
        }
		# endregion

        #region ����E�d���f�[�^�X�V���C������
        /// <summary>
        /// ����E�d���f�[�^�X�V���C������
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        /// <remarks>
        /// <br></br>
        /// <br>Update Note: �R�`���i���S�ʃI�v�V��������ǉ�</br>
        /// <br>Programmer : FSI���X�� �M�p</br>
        /// <br>Date       : K2012/12/11 </br>
        /// <br>Update Note: 2020/11/20 ���O</br>
        /// <br>�Ǘ��ԍ�   : 11670305-00</br>
        /// <br>           : PMKOBETSU-4097 TSP�C�����C���@�\�ǉ��Ή�</br>
        /// </remarks>
        private int UpDtSalesStockProc(out string message)
        {
            //�ϐ��̏�����
            int status = (int)EnumUoeConst.Status.ct_NORMAL;
            message = "";

            try
            {
                //����f�[�^�X�V
                status = UpDtSalesProc(out message);
                if (status != (int)EnumUoeConst.Status.ct_NORMAL)
                {
                    return (status);
                }

                //�d���f�[�^�X�V
                int systemDivCd = 0;    // add K2012/06/20
                // upd K2012/06/20 >>>
                //status = UpDtStockProc(out message);
                status = UpDtStockProc(out message, ref systemDivCd);
                // upd K2012/06/20 <<<
                if (status != (int)EnumUoeConst.Status.ct_NORMAL)
                {
                    return (status);
                }

                //����E�d���f�[�^�ۑ�
                // add K2012/06/20 >>>
                // DEL K2012/12/11 START >>>>>>
                //// ����͔����̏ꍇ�͎d���f�[�^���쐬���Ȃ�
                //if (systemDivCd == (int)EnumUoeConst.ctSystemDivCd.ct_Input)
                // DEL K2012/12/11 END <<<<<<
                // ADD K2012/12/11 START >>>>>>
                // �R�`���i���S�ʃI�v�V��������
                PurchaseStatus ps = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(
                    ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_YamagataCustomControl);

                // �R�`���i���S�ʃI�v�V�������L���ŁA������͔����̏ꍇ�͎d���f�[�^���쐬���Ȃ�
                if ((PurchaseStatus.Contract == ps ) && (systemDivCd == (int)EnumUoeConst.ctSystemDivCd.ct_Input))
                // ADD K2012/12/11 END <<<<<<
                {
                    return (status);
                }
                // add K2012/06/20 <<<

                // ---ADD ���O 2020/11/20 PMKOBETSU-4097�̑Ή� ------>>>>
                // TSP�C�����C���I�v�V�����������Ă��鎞
                if (_uOESalesStockDataAcs.Opt_TSP == (int)Broadleaf.Application.Controller.UOEOrderDtlAcs.Option.ON)
                {
                    _uOESalesStockDataAcs.UoeSndRcvCtlPara = _uoeSndRcvCtlPara;
                }
                // ---ADD ���O 2020/11/20 PMKOBETSU-4097�̑Ή� ------<<<<
                status = _uOESalesStockDataAcs.SaveDBData(out message);
            }
            catch (Exception ex)
            {
                status = -1;
                message = ex.Message;
            }
            return (status);
        }
        #endregion

        #region ����f�[�^�X�V����
        /// <summary>
        /// ����f�[�^�X�V����
        /// </summary>
        /// <param name="message">�G���[���b�Z�[�W</param>
        /// <returns>0:���� 0�ȊO:�G���[</returns>
        /// <br>Update Note: 2012/02/10 ���N�n��</br>
        /// <br>�Ǘ��ԍ�   : 10707327-00 2012/03/28�z�M��</br>
        /// <br>             Redmine#28406 �������M��̃f�[�^�쐬�s��ɂ��Ă̑Ή�</br>
        private int UpDtSalesProc(out string message)
        {
            //�ϐ��̏�����
            int status = (int)EnumUoeConst.Status.ct_NORMAL;
            message = "";

            try
            {
                //�`���̂ݓ���
                if (_uoeSndRcvCtlPara.SystemDivCd != (int)EnumUoeConst.ctSystemDivCd.ct_Slip)
                {
                    return (status);
                }

                //------------------------------------------------------
                // �󒍃f�[�^�̎擾
                //------------------------------------------------------
                # region �󒍃f�[�^�̎擾
                status = _uOESalesStockDataAcs.GetAcptProc(out message);
                if (status != (int)EnumUoeConst.Status.ct_NORMAL)
                {
                    return (status);
                }
                // 2010/07/05 Add >>>
                this.scmFlg = _uOESalesStockDataAcs.scmFlg;
                // 2010/07/05 Add <<<
                # endregion

                //------------------------------------------------------
                // ����MJNL��DataView�̍쐬
                //------------------------------------------------------
                # region ����MJNL��DataView�̍쐬
                //����MJNL��DataView�̍쐬
                //�f�[�^���M�敪�u9:����I���v
                //�V�X�e���敪 0:����� 1:�`�� 2:����
                string rowFilterText = string.Format("{0} = {1} AND {2} = {3}",
                                                OrderSndRcvJnlSchema.ct_Col_DataSendCode, (int)EnumUoeConst.ctDataSendCode.ct_OK,
                                                OrderSndRcvJnlSchema.ct_Col_SystemDivCd, (int)EnumUoeConst.ctSystemDivCd.ct_Slip);

                //�\�[�g�F�I�����C���ԍ��E�I�����C���s�ԍ�
                string sortText = string.Format("{0}, {1}",
                                                OrderSndRcvJnlSchema.ct_Col_OnlineNo,
                                                OrderSndRcvJnlSchema.ct_Col_OnlineRowNo);

                DataView viewOrder = new DataView(OrderTable);
                viewOrder.Sort = sortText;
                viewOrder.RowFilter = rowFilterText;

                if (viewOrder == null) return (-1);
                if (viewOrder.Count == 0) return (-1);
                # endregion

                //------------------------------------------------------
                // �ϐ��̏�����
                //------------------------------------------------------
                #region �ϐ��̏�����
                int savOnlineNo = 0;            //���ݏ������̃I�����C���ԍ�
                Int64 tempSalesSlipDtlNum = 1;  //���㖾�גʔԁi���j
                _hondaSlipNoDictionary.Clear(); // HONDA��pBO�����pDictionary�N���A
                #endregion

                foreach (DataRowView rowOrder in viewOrder)
                {
                    //DataRow �� OrderSndRcvJnl�֕ϊ�
                    OrderSndRcvJnl jnl = _uoeSndRcvJnlAcs.CreateOrderJnlFromSchema(rowOrder.Row);

                    //------------------------------------------------------
                    // ������}�X�^�擾
                    //------------------------------------------------------
                    #region ������}�X�^�l�̎擾�̃`�F�b�N
                    UOESupplier uOESupplier = _uoeSndRcvJnlAcs.SearchUOESupplier(jnl.UOESupplierCd);
                    if (uOESupplier == null) continue;
                    string commAssemblyId = uOESupplier.CommAssemblyId;		//�ʐM�A�Z���u��ID
                    #endregion

                    //------------------------------------------------------
                    // �I�����C���ԍ��̕ω�������
                    //------------------------------------------------------
                    #region UOE����N���X�̊i�[����
                    if (savOnlineNo != jnl.OnlineNo)
                    {
                        #region �t���O������
                        //���ݏ�������UOE�����ԍ���ۑ�
                        savOnlineNo = jnl.OnlineNo;
                        tempSalesSlipDtlNum = 1;

                        _hondaSlipNoDictionary.Clear(); // HONDA��pBO�����pDictionary�N���A
                        #endregion
                    }
                    #endregion

                    //------------------------------------------------------
                    // ����f�[�^��������
                    //------------------------------------------------------
                    #region ����f�[�^��������
                    // �`�[�o�͌`�[�i���Z�j�� 3 or 6
                    if (CheckAddingUp() == true)
                    {
                        status = slipOutPutAddCalculate(jnl, ref tempSalesSlipDtlNum, out message);
                    }
                    // �t�H���[(���Z)
                    else if (_uoeSndRcvJnlAcs.uOESetting.FollowSlipOutputDiv == (int)EnumUoeConst.ctFollowSlipOutputDiv.ct_Add)
                    {
                        status = salesSlipAddCalculate(jnl, ref tempSalesSlipDtlNum, out message);
                    }
                    // �t�H���[(�ʁX)
                    else
                    {
                        //�z���_��p
                        // 2009/05/25 START >>>>>>
                        //if (uOESupplier.CommAssemblyId == (string)EnumUoeConst.ctCommAssemblyId_0501)

                        if((uOESupplier.CommAssemblyId == (string)EnumUoeConst.ctCommAssemblyId_0501)
                        || (uOESupplier.CommAssemblyId == (string)EnumUoeConst.ctCommAssemblyId_0502))
                        // 2009/05/25 END   <<<<<<
                        {
                            //status = salesSlipSeparateForHonda(jnl, ref tempSalesSlipDtlNum, out message);// DEL 2015/07/24 ���O For Redmine #46880
                            status = salesSlipSeparateForHonda(jnl, ref tempSalesSlipDtlNum, out message, uOESupplier);// ADD 2015/07/24 ���O For Redmine #46880
                        }
                        //����
                        else
                        {
                            status = salesSlipSeparate(jnl, ref tempSalesSlipDtlNum, out message);
                        }
                    }
                    //---ADD ���N�n�� 2012/02/10 Redmine#28406------>>>>>
                    if (status != (int)EnumUoeConst.Status.ct_NORMAL)
                    {
                        return (status);
                    }
                    //---ADD ���N�n�� 2012/02/10 Redmine#28406------<<<<<

                    #endregion
                }

                //------------------------------------------------------
                // ���㖾�׃f�[�^�ɍs�ԍ���ݒ�
                //------------------------------------------------------
                # region ���㖾�׃f�[�^�ɍs�ԍ���ݒ�
                status = SettingRowNoFromSales(out message);
                if (status != (int)EnumUoeConst.Status.ct_NORMAL)
                {
                    return (status);
                }
                # endregion
            }
            catch (Exception ex)
            {
                status = -1;
                message = ex.Message;
            }
            return (status);
        }
        #endregion

        # region ���㖾�׃f�[�^�ɍs�ԍ���ݒ�
        /// <summary>
        /// ���㖾�׃f�[�^�ɍs�ԍ���ݒ�
        /// </summary>
        /// <param name="message">�G���[���b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        private int SettingRowNoFromSales(out string message)
        {
            //�ϐ��̏�����
            int status = (int)EnumUoeConst.Status.ct_NORMAL;
            message = "";

            try
            {
                //------------------------------------------------------
                // ����f�[�^DataView�̍쐬
                //------------------------------------------------------
                # region ����f�[�^DataView�̍쐬
                Int32 acptAnOdrStatus = 30;   //10:����,20:��,30:����,40:�o�ׁi�󒍃X�e�[�^�X�j

                string rowFilterText = string.Format("{0} = {1}",
                                                        SalesSlipSchema.ct_Col_AcptAnOdrStatus, acptAnOdrStatus);
                string sortText = string.Format("{0}, {1}",
                                                SalesSlipSchema.ct_Col_AcptAnOdrStatus,
                                                SalesSlipSchema.ct_Col_SalesSlipNum);
                DataView viewSalesSlip = new DataView(SalesSlipTable);
                viewSalesSlip.Sort = sortText;
                viewSalesSlip.RowFilter = rowFilterText;

                if (viewSalesSlip == null) return (status);
                if (viewSalesSlip.Count == 0) return (status);
                # endregion

                foreach (DataRowView rowUoeSalesSlip in viewSalesSlip)
                {
                    //------------------------------------------------------
                    // ����f�[�^���v���z�ݒ菈��
                    //------------------------------------------------------
                    # region ���v���z�ݒ菈��
                    //����f�[�^�N���X�̎擾
                    SalesSlipWork salesSlipWork = _uoeSndRcvJnlAcs.CreateSalesSlipWorkFromSchema(rowUoeSalesSlip.Row);

                    //------------------------------------------------------
                    // ���㖾�׃f�[�^�ɍs�ԍ���ݒ�
                    //------------------------------------------------------
                    string tempSalesSlipNum = (string)rowUoeSalesSlip[SalesSlipSchema.ct_Col_TempSalesSlipNum];
                    _uoeSndRcvJnlAcs.SetRowNoFromSalesDetail(
                                                    salesSlipWork.AcptAnOdrStatus,
                                                    tempSalesSlipNum,
                                                    1,
                                                    out message
                                                    );

                    //------------------------------------------------------
                    // ���㖾�׃N���X�̎擾
                    //------------------------------------------------------
                    List<UoeSalesDetail> uoeSalesDetailList = _uoeSndRcvJnlAcs.SearchUoeSalesDetailDataTable(
                                                    SalesDetailTable,
                                                    salesSlipWork.AcptAnOdrStatus,
                                                    tempSalesSlipNum,
                                                    (int)PrtSalesDetail.ctDetailCd.ct_Normal
                                                    );
                    if (uoeSalesDetailList == null) continue;
                    if (uoeSalesDetailList.Count == 0) continue;


                    List<SalesDetailWork> salesDetailList = new List<SalesDetailWork>();

                    foreach (UoeSalesDetail uoeSalesDetail in uoeSalesDetailList)
                    {
                        salesDetailList.Add(uoeSalesDetail.salesDetailWork);
                    }

                    TotalPriceSetting(ref salesSlipWork, salesDetailList);
                    # endregion

                    //------------------------------------------------------
                    // ����f�[�^�ݒ菈��
                    //------------------------------------------------------
                    # region ����f�[�^�ݒ菈��
                    _uoeSndRcvJnlAcs.UpdateTableFromSalesSlipWork(SalesSlipTable, salesSlipWork, tempSalesSlipNum, out message);

                    # endregion
                }

            }
            catch (Exception ex)
            {
                status = -1;
                message = ex.Message;
            }
            return (status);
        }
        #endregion

        # region ����f�[�^���v���z�ݒ菈��
        /// <summary>
        /// ���v���z�ݒ菈��
        /// </summary>
        /// <param name="salesSlip">����f�[�^�I�u�W�F�N�g</param>
        /// <param name="salesDetailList">���㖾�׃f�[�^���X�g</param>
        private void TotalPriceSetting(ref SalesSlipWork salesSlip, List<SalesDetailWork> salesDetailList)
        {
            if (salesSlip == null) return;
            int salesTaxFrcProcCd = this._customerInfoAcs.GetSalesFractionProcCd(this._enterpriseCode, salesSlip.CustomerCode, CustomerInfoAcs.FracProcMoneyDiv.CnsTaxFrcProcCd);		// ����Œ[�������R�[�h

            long salesTotalTaxInc = 0;      // ����`�[���v�i�ō��j
            long salesTotalTaxExc = 0;      // ����`�[���v�i�Ŕ��j
            long salesSubtotalTax = 0;      // ���㏬�v�i�Łj
            long itdedSalesOutTax = 0;      // ����O�őΏۊz
            long itdedSalesInTax = 0;       // ������őΏۊz
            long salSubttlSubToTaxFre = 0;  // ���㏬�v��ېőΏۊz
            long salesOutTax = 0;           // ������z����Ŋz�i�O�Łj
            long salAmntConsTaxInclu = 0;   // ������z����Ŋz�i���Łj
            long salesDisTtlTaxExc = 0;     // ����l�����z�v�i�Ŕ��j
            long itdedSalesDisOutTax = 0;   // ����l���O�őΏۊz���v
            long itdedSalesDisInTax = 0;    // ����l�����őΏۊz���v
            long itdedSalesDisTaxFre = 0;   // ����l����ېőΏۊz���v
            long salesDisOutTax = 0;        // ����l������Ŋz�i�O�Łj
            long salesDisTtlTaxInclu = 0;   // ����l������Ŋz�i���Łj
            long totalCost = 0;             // �������z�v
            long stockGoodsTtlTaxExc = 0;   // �݌ɏ��i���v���z�i�Ŕ��j
            long pureGoodsTtlTaxExc = 0;    // �������i���v���z�i�Ŕ��j
            long taxAdjust = 0;             // ����Œ����z
            long balanceAdjust = 0;         // �c�������z
            long salesPrtSubttlInc = 0;     // ���㕔�i���v�i�ō��j
            long salesPrtSubttlExc = 0;     // ���㕔�i���v�i�Ŕ��j
            long salesWorkSubttlInc = 0;    // �����Ə��v�i�ō��j
            long salesWorkSubttlExc = 0;    // �����Ə��v�i�Ŕ��j
            long itdedPartsDisInTax = 0;    // ���i�l���Ώۊz���v�i�ō��j
            long itdedPartsDisOutTax = 0;   // ���i�l���Ώۊz���v�i�Ŕ��j
            long itdedWorkDisInTax = 0;     // ��ƒl���Ώۊz���v�i�ō��j
            long itdedWorkDisOutTax = 0;    // ��ƒl���Ώۊz���v�i�Ŕ��j
            long totalMoneyForGrossProfit = 0; // �e���v�Z�p������z

            this.CalculationSalesTotalPrice(
                salesDetailList,
                salesSlip.ConsTaxRate,
                salesTaxFrcProcCd,
                salesSlip.TotalAmountDispWayCd,
                salesSlip.ConsTaxLayMethod,
                out salesTotalTaxInc,
                out salesTotalTaxExc,
                out salesSubtotalTax,
                out itdedSalesOutTax,
                out itdedSalesInTax,
                out salSubttlSubToTaxFre,
                out salesOutTax,
                out salAmntConsTaxInclu,
                out salesDisTtlTaxExc,
                out itdedSalesDisOutTax,
                out itdedSalesDisInTax,
                out itdedSalesDisTaxFre,
                out salesDisOutTax,
                out salesDisTtlTaxInclu,
                out totalCost,
                out stockGoodsTtlTaxExc,
                out pureGoodsTtlTaxExc,
                out balanceAdjust,
                out taxAdjust,
                out salesPrtSubttlInc,
                out salesPrtSubttlExc,
                out salesWorkSubttlInc,
                out salesWorkSubttlExc,
                out itdedPartsDisInTax,
                out itdedPartsDisOutTax,
                out itdedWorkDisInTax,
                out itdedWorkDisOutTax,
                out totalMoneyForGrossProfit);


            salesSlip.SalesSubtotalTaxInc = salesTotalTaxInc;       // ���㏬�v�i�ō��j
            salesSlip.SalesSubtotalTaxExc = salesTotalTaxExc;       // ���㏬�v�i�Ŕ��j
            salesSlip.SalesSubtotalTax = salesSubtotalTax;          // ���㏬�v�i�Łj
            salesSlip.ItdedSalesOutTax = itdedSalesOutTax;          // ����O�őΏۊz
            salesSlip.ItdedSalesInTax = itdedSalesInTax;            // ������őΏۊz
            salesSlip.SalSubttlSubToTaxFre = salSubttlSubToTaxFre;  // ���㏬�v��ېőΏۊz
            salesSlip.SalesOutTax = salesOutTax;                    // ������z����Ŋz�i�O�Łj
            salesSlip.SalAmntConsTaxInclu = salAmntConsTaxInclu;    // ������z����Ŋz�i���Łj
            salesSlip.SalesDisTtlTaxExc = salesDisTtlTaxExc;        // ����l�����z�v�i�Ŕ��j
            salesSlip.ItdedSalesDisOutTax = itdedSalesDisOutTax;    // ����l���O�őΏۊz���v
            salesSlip.ItdedSalesDisInTax = itdedSalesDisInTax;      // ����l�����őΏۊz���v
            salesSlip.ItdedSalesDisTaxFre = itdedSalesDisTaxFre;    // ����l����ېőΏۊz���v
            salesSlip.SalesDisOutTax = salesDisOutTax;              // ����l������Ŋz�i�O�Łj
            salesSlip.SalesDisTtlTaxInclu = salesDisTtlTaxInclu;    // ����l������Ŋz�i���Łj
            salesSlip.TotalCost = totalCost;                        // �������z�v
            salesSlip.StockGoodsTtlTaxExc = stockGoodsTtlTaxExc;    // �݌ɏ��i���v���z�i�Ŕ��j
            salesSlip.PureGoodsTtlTaxExc = pureGoodsTtlTaxExc;      // �������i���v���z�i�Ŕ��j
            salesSlip.SalesPrtSubttlInc = salesPrtSubttlInc;                // ���㕔�i���v�i�ō��j
            salesSlip.SalesPrtSubttlExc = salesPrtSubttlExc;                // ���㕔�i���v�i�Ŕ��j
            salesSlip.SalesWorkSubttlInc = salesWorkSubttlInc;              // �����Ə��v�i�ō��j
            salesSlip.SalesWorkSubttlExc = salesWorkSubttlExc;              // �����Ə��v�i�Ŕ��j
            salesSlip.ItdedPartsDisInTax = itdedPartsDisInTax;              // ���i�l���Ώۊz���v�i�ō��j
            salesSlip.ItdedPartsDisOutTax = itdedPartsDisOutTax;            // ���i�l���Ώۊz���v�i�Ŕ��j
            salesSlip.ItdedWorkDisInTax = itdedWorkDisInTax;                // ��ƒl���Ώۊz���v�i�ō��j
            salesSlip.ItdedWorkDisOutTax = itdedWorkDisOutTax;              // ��ƒl���Ώۊz���v�i�Ŕ��j
            //salesSlip.TotalMoneyForGrossProfit = totalMoneyForGrossProfit; // �e���v�Z�p������z

            salesSlip.SalesTotalTaxInc = salesTotalTaxInc + salSubttlSubToTaxFre;                   // ����`�[���v�i�ō��j= ����`�[���v�i�ō��j + ���㏬�v��ېőΏۊz
            salesSlip.SalesTotalTaxExc = salesTotalTaxExc + salSubttlSubToTaxFre;                   // ����`�[���v�i�Ŕ��j= ����`�[���v�i�Ŕ��j + ���㏬�v��ېőΏۊz
            salesSlip.SalesNetPrice = itdedSalesOutTax + itdedSalesInTax + salSubttlSubToTaxFre;    // ���㐳�����z = ����O�őΏۊz + ������őΏۊz + ���㏬�v��ېőΏۊz
            salesSlip.AccRecConsTax = salesSubtotalTax;                                             // ���|�����
            salesSlip.SalesPrtTotalTaxInc = salesPrtSubttlInc + itdedPartsDisInTax;                 // ���㕔�i���v�i�ō��j
            salesSlip.SalesPrtTotalTaxExc = salesPrtSubttlExc + itdedPartsDisOutTax;                // ���㕔�i���v�i�Ŕ��j
            salesSlip.SalesWorkTotalTaxInc = salesWorkSubttlInc + itdedWorkDisInTax;                // �����ƍ��v�i�ō��j
            salesSlip.SalesWorkTotalTaxExc = salesWorkSubttlExc + itdedWorkDisOutTax;               // �����ƍ��v�i�Ŕ��j
        }

        /// <summary>
        /// ������z�̍��v���v�Z���܂��B
        /// </summary>
        /// <param name="salesDetailList">���㖾�׃f�[�^���X�g</param>
        /// <param name="pureGoodsTtlTaxExc">�������i���v���z(�Ŕ�)</param>
        /// <param name="stockGoodsTtlTaxExc">�݌ɏ��i���v���z(�Ŕ�)</param>
        /// <param name="consTaxRate">����Őŗ�</param>
        /// <param name="salesTaxFrcProcCd">����Œ[�������R�[�h</param>
        /// <param name="totalAmountDispWayCd">���z�\�����@�敪</param>
        /// <param name="consTaxLayMethod">����œ]�ŕ���</param>
        /// <param name="salesTotalTaxInc">����`�[���v�i�ō��j</param>
        /// <param name="salesTotalTaxExc">����`�[���v�i�Ŕ��j</param>
        /// <param name="salesSubtotalTax">���㏬�v�i�Łj</param>
        /// <param name="itdedSalesOutTax">����O�őΏۊz</param>
        /// <param name="itdedSalesInTax">������őΏۊz</param>
        /// <param name="salSubttlSubToTaxFre">���㏬�v��ېőΏۊz</param>
        /// <param name="salesOutTax">������z����Ŋz�i�O�Łj</param>
        /// <param name="salAmntConsTaxInclu">������z����Ŋz�i���Łj</param>
        /// <param name="salesDisTtlTaxExc">����l�����z�v�i�Ŕ��j</param>
        /// <param name="itdedSalesDisOutTax">����l���O�őΏۊz���v</param>
        /// <param name="itdedSalesDisInTax">����l�����őΏۊz���v</param>
        /// <param name="itdedSalesDisTaxFre">����l����ېőΏۊz���v</param>
        /// <param name="salesDisOutTax">����l������Ŋz�i�O�Łj</param>
        /// <param name="salesDisTtlTaxInclu">����l������Ŋz�i���Łj</param>
        /// <param name="totalCost">�������z�v</param>
        /// <param name="balanceAdjust">����Œ����z</param>
        /// <param name="taxAdjust">�c�������z</param>
        /// <param name="salesPrtSubttlInc">���㕔�i���v�i�ō��j</param>
        /// <param name="salesPrtSubttlExc">���㕔�i���v�i�Ŕ��j</param>
        /// <param name="salesWorkSubttlInc">�����Ə��v�i�ō��j</param>
        /// <param name="salesWorkSubttlExc">�����Ə��v�i�Ŕ��j</param>
        /// <param name="itdedPartsDisInTax">���i�l���Ώۊz���v�i�ō��j</param>
        /// <param name="itdedPartsDisOutTax">���i�l���Ώۊz���v�i�Ŕ��j</param>
        /// <param name="itdedWorkDisInTax">��ƒl���Ώۊz���v�i�ō��j</param>
        /// <param name="itdedWorkDisOutTax">��ƒl���Ώۊz���v�i�Ŕ��j</param>
        /// <param name="totalMoneyForGrossProfit">�e���v�Z�p������z</param>
        private void CalculationSalesTotalPrice(List<SalesDetailWork> salesDetailList, double consTaxRate, int salesTaxFrcProcCd, int totalAmountDispWayCd, int consTaxLayMethod, out long salesTotalTaxInc, out long salesTotalTaxExc, out long salesSubtotalTax, out long itdedSalesOutTax, out long itdedSalesInTax, out long salSubttlSubToTaxFre, out long salesOutTax, out long salAmntConsTaxInclu, out long salesDisTtlTaxExc, out long itdedSalesDisOutTax, out long itdedSalesDisInTax, out long itdedSalesDisTaxFre, out long salesDisOutTax, out long salesDisTtlTaxInclu, out long totalCost, out long stockGoodsTtlTaxExc, out long pureGoodsTtlTaxExc, out long balanceAdjust, out long taxAdjust, out long salesPrtSubttlInc, out long salesPrtSubttlExc, out long salesWorkSubttlInc, out long salesWorkSubttlExc, out long itdedPartsDisInTax, out long itdedPartsDisOutTax, out long itdedWorkDisInTax, out long itdedWorkDisOutTax, out long totalMoneyForGrossProfit)
        {
            // ����Œ[�������P�ʁA�[�������敪���擾
            int taxFracProcCd = 0;
            double taxFracProcUnit = 0;
            //this.GetFractionProcInfo(ctFracProcMoneyDiv_Tax, salesTaxFrcProcCd, 0, out taxFracProcUnit, out taxFracProcCd);
            this.GetSalesFractionProcInfo(ctFracProcMoneyDiv_Tax, salesTaxFrcProcCd, 0, out taxFracProcUnit, out taxFracProcCd);

            salesTotalTaxInc = 0;       // ����`�[���v�i�ō��j
            salesTotalTaxExc = 0;       // ����`�[���v�i�Ŕ��j
            salesSubtotalTax = 0;       // ���㏬�v�i�Łj
            itdedSalesOutTax = 0;       // ����O�őΏۊz
            itdedSalesInTax = 0;        // ������őΏۊz
            salSubttlSubToTaxFre = 0;   // ���㏬�v��ېőΏۊz
            salesOutTax = 0;            // ������z����Ŋz�i�O�Łj
            salAmntConsTaxInclu = 0;    // ������z����Ŋz�i���Łj
            salesDisTtlTaxExc = 0;      // ����l�����z�v�i�Ŕ��j
            itdedSalesDisOutTax = 0;    // ����l���O�őΏۊz���v
            itdedSalesDisInTax = 0;     // ����l�����őΏۊz���v
            itdedSalesDisTaxFre = 0;    // ����l����ېőΏۊz���v
            salesDisOutTax = 0;         // ����l������Ŋz�i�O�Łj
            salesDisTtlTaxInclu = 0;    // ����l������Ŋz�i���Łj
            stockGoodsTtlTaxExc = 0;    // �݌ɏ��i���v���z�i�Ŕ��j
            pureGoodsTtlTaxExc = 0;     // �������i���v���z�i�Ŕ��j
            totalCost = 0;              // �������z�v
            taxAdjust = 0;              // ����Œ����z
            balanceAdjust = 0;          // �c�������z
            salesPrtSubttlInc = 0;      // ���㕔�i���v�i�ō��j
            salesPrtSubttlExc = 0;      // ���㕔�i���v�i�Ŕ��j
            salesWorkSubttlInc = 0;     // �����Ə��v�i�ō��j
            salesWorkSubttlExc = 0;     // �����Ə��v�i�Ŕ��j
            itdedPartsDisInTax = 0;     // ���i�l���Ώۊz���v�i�ō��j
            itdedPartsDisOutTax = 0;    // ���i�l���Ώۊz���v�i�Ŕ��j
            itdedWorkDisInTax = 0;      // ��ƒl���Ώۊz���v�i�ō��j
            itdedWorkDisOutTax = 0;     // ��ƒl���Ώۊz���v�i�Ŕ��j
            totalMoneyForGrossProfit = 0; // �e���v�Z�p������z

            long itdedSalesInTax_TaxInc = 0;    // ������őΏۊz�i�ō��j
            long itdedSalesDisInTax_TaxInc = 0; // ����l�����őΏۊz���v�i�ō��j
            long totalMoney_TaxInc_ForGrossProfitMoney = 0;     // �e���v�Z�p������z�v�i���ŏ��i���j
            long totalMoney_TaxExc_ForGrossProfitMoney = 0;     // �e���v�Z�p������z�v�i�O�ŏ��i���j
            long totalMoney_TaxNone_ForGrossProfitMoney = 0;    // �e���v�Z�p������z�v�i��ېŏ��i���j
            long stockGoodsTtlTaxExc_TaxInc = 0;                // �݌ɏ��i���v���z�i�Ŕ��j�i���ŏ��i���j
            long stockGoodsTtlTaxExc_TaxExc = 0;                // �݌ɏ��i���v���z�i�Ŕ��j�i�O�ŏ��i���j
            long stockGoodsTtlTaxExc_TaxNone = 0;               // �݌ɏ��i���v���z�i�Ŕ��j�i��ېŏ��i���j
            long pureGoodsTtlTaxExc_TaxInc = 0;                 // �������i���v���z�i�Ŕ��j�i���ŏ��i���j
            long pureGoodsTtlTaxExc_TaxExc = 0;                 // �������i���v���z�i�Ŕ��j�i�O�ŏ��i���j
            long pureGoodsTtlTaxExc_TaxNone = 0;                // �������i���v���z�i�Ŕ��j�i��ېŏ��i���j

            //-----------------------------------------------------------------------------
            // �v�Z�ɕK�v�ȋ��z�̌v�Z
            //-----------------------------------------------------------------------------
            #region ���v�Z�ɕK�v�ȋ��z�̌v�Z

            foreach (SalesDetailWork salesDetail in salesDetailList)
            {
                // ����`�[�敪�i���ׁj�ɂ���ďW�v���@���ς�镪
                switch (salesDetail.SalesSlipCdDtl)
                {
                    // ����A�ԕi
                    case (int)SalesSlipInputAcs.SalesSlipCdDtl.Sales:
                    case (int)SalesSlipInputAcs.SalesSlipCdDtl.RetGoods:
                        {
                            // �ŋ敪�F�O��
                            if (salesDetail.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxExc)
                            {
                                // ����O�őΏۊz
                                itdedSalesOutTax += salesDetail.SalesMoneyTaxExc;

                                // ������z����Ŋz�i�O�Łj
                                salesOutTax += salesDetail.SalesPriceConsTax;

                                // �݌ɏ��i���v���z�i�Ŕ��j�i�O�ŏ��i���j
                                if (salesDetail.SalesOrderDivCd == (int)SalesSlipInputAcs.SalesOrderDivCd.Stock)
                                    stockGoodsTtlTaxExc_TaxExc += salesDetail.SalesMoneyTaxExc;

                                // �������i���v���z�i�Ŕ��j�i�O�ŏ��i���j
                                if (salesDetail.GoodsKindCode == 0)
                                    pureGoodsTtlTaxExc_TaxExc += salesDetail.SalesMoneyTaxExc;
                            }
                            // �ŋ敪�F����
                            if (salesDetail.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxInc)
                            {
                                // ������őΏۊz
                                itdedSalesInTax += salesDetail.SalesMoneyTaxExc;

                                // ������őΏۊz�i�ō��j
                                itdedSalesInTax_TaxInc += salesDetail.SalesMoneyTaxInc;

                                // ������z����Ŋz�i���Łj
                                salAmntConsTaxInclu += salesDetail.SalesPriceConsTax;

                                // �݌ɏ��i���v���z�i�Ŕ��j�i���ŏ��i���j
                                if (salesDetail.SalesOrderDivCd == (int)SalesSlipInputAcs.SalesOrderDivCd.Stock)
                                    stockGoodsTtlTaxExc_TaxInc += salesDetail.SalesMoneyTaxExc;

                                // �������i���v���z�i�Ŕ��j�i���ŏ��i���j
                                if (salesDetail.GoodsKindCode == 0)
                                    pureGoodsTtlTaxExc_TaxInc += salesDetail.SalesMoneyTaxExc;

                            }
                            // �ŋ敪�F��ې�
                            if (salesDetail.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxNone)
                            {
                                // ���㏬�v��ېőΏۊz
                                salSubttlSubToTaxFre += salesDetail.SalesMoneyTaxInc;

                                // �݌ɏ��i���v���z�i�Ŕ��j�i��ېŏ��i���j
                                if (salesDetail.SalesOrderDivCd == (int)SalesSlipInputAcs.SalesOrderDivCd.Stock)
                                    stockGoodsTtlTaxExc_TaxNone += salesDetail.SalesMoneyTaxExc;

                                // �������i���v���z�i�Ŕ��j�i��ېŏ��i���j
                                if (salesDetail.GoodsKindCode == 0)
                                    pureGoodsTtlTaxExc_TaxNone += salesDetail.SalesMoneyTaxExc;
                            }

                            // ���㕔�i���v�i�ō��j
                            salesPrtSubttlInc += salesDetail.SalesMoneyTaxInc;
                            // ���㕔�i���v�i�Ŕ��j
                            salesPrtSubttlExc += salesDetail.SalesMoneyTaxExc;

                            // �������z�v
                            totalCost += salesDetail.Cost;

                            // �e���v�Z�p������z�v�i���ŏ��i���j
                            if (salesDetail.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxInc)
                            {
                                totalMoney_TaxInc_ForGrossProfitMoney += salesDetail.SalesMoneyTaxInc;
                            }

                            // �e���v�Z�p������z�v�i�O�ŏ��i���j
                            if (salesDetail.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxExc)
                            {
                                totalMoney_TaxExc_ForGrossProfitMoney += salesDetail.SalesMoneyTaxExc;
                            }

                            // �e���v�Z�p������z�v�i��ېŏ��i���j
                            if (salesDetail.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxNone)
                            {
                                totalMoney_TaxNone_ForGrossProfitMoney += salesDetail.SalesMoneyTaxExc;
                            }

                            break;
                        }
                    // �l����
                    case (int)SalesSlipInputAcs.SalesSlipCdDtl.Discount:
                        {
                            // �ŋ敪�F�O��
                            if (salesDetail.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxExc)
                            {
                                // ����l���O�őΏۊz���v
                                itdedSalesDisOutTax += salesDetail.SalesMoneyTaxExc;
                                // ����l������Ŋz�i�O�Łj
                                salesDisOutTax += salesDetail.SalesPriceConsTax;

                                // ���i�l�����̏ꍇ
                                if (salesDetail.ShipmentCnt != 0)
                                {
                                    // �݌ɏ��i���v���z�i�Ŕ��j�i�O�ŏ��i���j
                                    if (salesDetail.SalesOrderDivCd == (int)SalesSlipInputAcs.SalesOrderDivCd.Stock)
                                        stockGoodsTtlTaxExc_TaxExc += salesDetail.SalesMoneyTaxExc;

                                    // �������i���v���z�i�Ŕ��j�i�O�ŏ��i���j
                                    if (salesDetail.GoodsKindCode == 0)
                                        pureGoodsTtlTaxExc_TaxExc += salesDetail.SalesMoneyTaxExc;
                                }
                            }
                            // �ŋ敪�F����
                            if (salesDetail.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxInc)
                            {
                                // ����l�����őΏۊz���v
                                itdedSalesDisInTax += salesDetail.SalesMoneyTaxExc;
                                // ����l�����őΏۊz���v�i�ō��j
                                itdedSalesDisInTax_TaxInc += salesDetail.SalesMoneyTaxInc;
                                // ����l������Ŋz�i���Łj
                                salesDisTtlTaxInclu += salesDetail.SalesPriceConsTax;

                                // ���i�l�����̏ꍇ
                                if (salesDetail.ShipmentCnt != 0)
                                {
                                    // �݌ɏ��i���v���z�i�Ŕ��j�i���ŏ��i���j
                                    if (salesDetail.SalesOrderDivCd == (int)SalesSlipInputAcs.SalesOrderDivCd.Stock)
                                        stockGoodsTtlTaxExc_TaxInc += salesDetail.SalesMoneyTaxExc;

                                    // �������i���v���z�i�Ŕ��j�i���ŏ��i���j
                                    if (salesDetail.GoodsKindCode == 0)
                                        pureGoodsTtlTaxExc_TaxInc += salesDetail.SalesMoneyTaxExc;
                                }
                            }
                            // �ŋ敪�F��ې�
                            if (salesDetail.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxNone)
                            {
                                // ����l����ېőΏۊz���v
                                itdedSalesDisTaxFre += salesDetail.SalesMoneyTaxInc;

                                // ���i�l�����̏ꍇ
                                if (salesDetail.ShipmentCnt != 0)
                                {
                                    // �݌ɏ��i���v���z�i�Ŕ��j�i��ېŏ��i���j
                                    if (salesDetail.SalesOrderDivCd == (int)SalesSlipInputAcs.SalesOrderDivCd.Stock)
                                        stockGoodsTtlTaxExc_TaxNone += salesDetail.SalesMoneyTaxExc;

                                    // �������i���v���z�i�Ŕ��j�i��ېŏ��i���j
                                    if (salesDetail.GoodsKindCode == 0)
                                        pureGoodsTtlTaxExc_TaxNone += salesDetail.SalesMoneyTaxExc;

                                }
                            }

                            // ���i�l���Ώۊz���v�i�ō��j
                            itdedPartsDisInTax += salesDetail.SalesMoneyTaxInc;

                            // ���i�l���Ώۊz���v�i�Ŕ��j
                            itdedPartsDisOutTax += salesDetail.SalesMoneyTaxExc;

                            // �������z�v
                            totalCost += salesDetail.Cost;

                            // �e���v�Z�p������z�v�i���ŏ��i���j
                            if (salesDetail.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxInc)
                            {
                                totalMoney_TaxInc_ForGrossProfitMoney += salesDetail.SalesMoneyTaxInc;
                            }

                            // �e���v�Z�p������z�v�i�O�ŏ��i���j
                            if (salesDetail.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxExc)
                            {
                                totalMoney_TaxExc_ForGrossProfitMoney += salesDetail.SalesMoneyTaxExc;
                            }

                            // �e���v�Z�p������z�v�i��ېŏ��i���j
                            if (salesDetail.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxNone)
                            {
                                totalMoney_TaxNone_ForGrossProfitMoney += salesDetail.SalesMoneyTaxExc;
                            }

                            break;
                        }
                    // ����
                    case (int)SalesSlipInputAcs.SalesSlipCdDtl.Annotation:
                        {
                            break;
                        }
                    // ���
                    case (int)SalesSlipInputAcs.SalesSlipCdDtl.Work:
                        {
                            // �������z�v
                            totalCost += salesDetail.Cost;

                            // �e���v�Z�p������z�v�i���ŏ��i���j
                            if (salesDetail.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxInc)
                            {
                                totalMoney_TaxInc_ForGrossProfitMoney += salesDetail.SalesMoneyTaxInc;
                            }

                            // �e���v�Z�p������z�v�i�O�ŏ��i���j
                            if (salesDetail.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxExc)
                            {
                                totalMoney_TaxExc_ForGrossProfitMoney += salesDetail.SalesMoneyTaxExc;
                            }

                            // �e���v�Z�p������z�v�i��ېŏ��i���j
                            if (salesDetail.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxNone)
                            {
                                totalMoney_TaxNone_ForGrossProfitMoney += salesDetail.SalesMoneyTaxExc;
                            }
                            break;
                        }
                    // ���v
                    case (int)SalesSlipInputAcs.SalesSlipCdDtl.Subtotal:
                        {
                            break;
                        }
                }

                if (salesDetail.SalesSlipCdDtl != (int)SalesSlipInputAcs.SalesSlipCdDtl.Subtotal)
                {
                    // �c�������z
                    if ((salesDetail.SalesGoodsCd == (int)SalesSlipInputAcs.SalesGoodsCd.BalanceAdjust) ||
                        (salesDetail.SalesGoodsCd == (int)SalesSlipInputAcs.SalesGoodsCd.AccRecBalanceAdjust))
                    {
                        balanceAdjust += salesDetail.SalesMoneyTaxInc;
                    }

                    // ����Œ����z
                    if ((salesDetail.SalesGoodsCd == (int)SalesSlipInputAcs.SalesGoodsCd.ConsTaxAdjust) ||
                        (salesDetail.SalesGoodsCd == (int)SalesSlipInputAcs.SalesGoodsCd.AccRecConsTaxAdjust))
                    {
                        taxAdjust += salesDetail.SalesPriceConsTax;
                    }
                }

            }

            // ����l�����z�v�i�Ŕ��j
            salesDisTtlTaxExc = itdedSalesDisOutTax + itdedSalesDisInTax + itdedSalesDisTaxFre;

            // �e���v�Z�p������z�v
            totalMoneyForGrossProfit = totalMoney_TaxExc_ForGrossProfitMoney + totalMoney_TaxInc_ForGrossProfitMoney + totalMoney_TaxNone_ForGrossProfitMoney;

            // �݌ɏ��i���v���z�i�Ŕ��j
            stockGoodsTtlTaxExc = stockGoodsTtlTaxExc_TaxInc + stockGoodsTtlTaxExc_TaxExc + stockGoodsTtlTaxExc_TaxNone;

            // �������i���v���z�i�Ŕ��j
            pureGoodsTtlTaxExc = pureGoodsTtlTaxExc_TaxInc + pureGoodsTtlTaxExc_TaxExc + pureGoodsTtlTaxExc_TaxNone;

            #endregion

            #region ���]�ŕ����F��ېł̏ꍇ�ɋ��z�𒲐�����
            //-----------------------------------------------------------------------------
            // �]�ŕ����F��ېł̏ꍇ�ɋ��z�𒲐�����
            //-----------------------------------------------------------------------------
            if (consTaxLayMethod == 9)
            {
                // ������z����Ŋz�i�O�Łj
                salesOutTax = 0;

                // ������z����Ŋz�i���Łj
                salAmntConsTaxInclu = 0;

                // ���㏬�v��ېőΏۊz
                salSubttlSubToTaxFre += itdedSalesOutTax + itdedSalesInTax;

                // ����O�őΏۊz
                itdedSalesOutTax = 0;

                // ������őΏۊz
                itdedSalesInTax = 0;

                // ������őΏۊz�i�ō��j
                itdedSalesInTax_TaxInc = 0;

                // ����l������Ŋz�i�O�Łj
                salesDisOutTax = 0;

                // ����l������Ŋz�i���Łj
                salesDisTtlTaxInclu = 0;

                // ����l����ېőΏۊz���v
                itdedSalesDisTaxFre += itdedSalesDisOutTax + itdedSalesDisInTax;

                // ����l���O�őΏۊz���v
                itdedSalesDisOutTax = 0;

                // ����l�����őΏۊz���v
                itdedSalesDisInTax = 0;

                // ����l�����őΏۊz���v�i�ō��j
                itdedSalesDisInTax_TaxInc = 0;

                // ����l�����z�v�i�Ŕ��j
                salesDisTtlTaxExc = itdedSalesDisOutTax + itdedSalesDisInTax + itdedSalesDisTaxFre;
            }
            #endregion

            #region ���e����z�Z�o
            //-----------------------------------------------------------------------------
            // �e����z�Z�o
            //-----------------------------------------------------------------------------

            // ���ד]�ňȊO
            if (consTaxLayMethod != 1)
            {
                //-----------------------------------------------------------------------------
                // �@ ����`�[���v�i�Ŕ��j�F����O�őΏۊz + ������őΏۊz + ����l���O�őΏۊz���v + ����l�����őΏۊz���v + ����l����ېőΏۊz���v
                //-----------------------------------------------------------------------------
                salesTotalTaxExc = itdedSalesOutTax + itdedSalesInTax + itdedSalesDisOutTax + itdedSalesDisInTax + itdedSalesDisTaxFre;

                //-----------------------------------------------------------------------------
                // �A ����`�[���v�i�ō��j�F ������őΏۊz�i�ō��j + ����O�őΏۊz + ����l�����őΏۊz���v�i�ō��j + ����l���O�őΏۊz���v + ����l����ېőΏۊz���v + (����O�őΏۊz + ����l���O�őΏۊz���v)�~�ŗ�)
                //-----------------------------------------------------------------------------
                salesTotalTaxInc = itdedSalesInTax_TaxInc + itdedSalesOutTax + itdedSalesDisInTax_TaxInc + itdedSalesDisOutTax + itdedSalesDisTaxFre + CalculateTax.GetTaxFromPriceExc(consTaxRate, taxFracProcUnit, taxFracProcCd, itdedSalesOutTax + itdedSalesDisOutTax);

                //-----------------------------------------------------------------------------
                // �B ���㏬�v�i�Łj�F�A - �@
                //-----------------------------------------------------------------------------
                salesSubtotalTax = salesTotalTaxInc - salesTotalTaxExc;

                //-----------------------------------------------------------------------------
                // �C ������z����Ŋz�i�O�Łj�F����O�őΏۊz �~ �ŗ�
                //-----------------------------------------------------------------------------
                salesOutTax = CalculateTax.GetTaxFromPriceExc(consTaxRate, taxFracProcUnit, taxFracProcCd, itdedSalesOutTax);

                //-----------------------------------------------------------------------------
                // �D ������z����Ŋz�i�O�Łj(�Ŕ��A�l�����܂�) �F(����O�őΏۊz + ����l���O�őΏۊz���v) �~ �ŗ�
                //-----------------------------------------------------------------------------
                long salesOutTax_All = CalculateTax.GetTaxFromPriceExc(consTaxRate, taxFracProcUnit, taxFracProcCd, itdedSalesOutTax + itdedSalesDisOutTax);

                //-----------------------------------------------------------------------------
                // �E ����l������Ŋz�i�O�Łj�F�C - �D
                //-----------------------------------------------------------------------------
                salesDisOutTax = salesOutTax_All - salesOutTax;
            }
            // ���ד]��
            else
            {
                //-----------------------------------------------------------------------------
                // �@ ���㏬�v�i�Łj�F������z����Ŋz�i�O�Łj + ������z����Ŋz�i���Łj +  ����l������Ŋz�i�O�Łj + ����l������Ŋz�i���Łj
                //-----------------------------------------------------------------------------
                salesSubtotalTax = salesOutTax + salAmntConsTaxInclu + salesDisOutTax + salesDisTtlTaxInclu;

                //-----------------------------------------------------------------------------
                // �A ����`�[���v�i�Ŕ��j�F����O�őΏۊz + ������őΏۊz + ����l���O�őΏۊz���v + ����l�����őΏۊz���v
                //-----------------------------------------------------------------------------
                salesTotalTaxExc = itdedSalesOutTax + itdedSalesInTax + itdedSalesDisOutTax + itdedSalesDisInTax;

                //-----------------------------------------------------------------------------
                // �B ����`�[���v�i�ō��j�F�@ + �A
                //-----------------------------------------------------------------------------
                salesTotalTaxInc = salesTotalTaxExc + salesSubtotalTax;
            }
            #endregion
        }
        # endregion

        # region �[�������P�ʁA�[�������敪�擾����
        /// <summary>
        /// �[�������P�ʁA�[�������敪�擾����
        /// </summary>
        /// <param name="fracProcMoneyDiv">�[�������Ώۋ��z�敪</param>
        /// <param name="fractionProcCode">�[�������R�[�h</param>
        /// <param name="targetPrice">�Ώۋ��z</param>
        /// <param name="fractionProcUnit">�[�������P��</param>
        /// <param name="fractionProcCd">�[�������敪</param>
        public void GetSalesFractionProcInfo(int fracProcMoneyDiv, int fractionProcCode, double targetPrice, out double fractionProcUnit, out int fractionProcCd)
        {
            //-----------------------------------------------------------------------------
            // �����l
            //-----------------------------------------------------------------------------
            switch (fracProcMoneyDiv)
            {
                case ctFracProcMoneyDiv_SalesUnitPrice: // �P����0.01�~�P��
                    fractionProcUnit = 0.01;
                    break;
                default:
                    fractionProcUnit = 1;               // �P���ȊO��1�~�P��
                    break;
            }
            fractionProcCd = 1;     // �؎̂�

            //-----------------------------------------------------------------------------
            // �R�[�h�Y�����R�[�h�擾
            //-----------------------------------------------------------------------------
            List<SalesProcMoney> salesProcMoneyList = this._salesProcMoneyList.FindAll(
                delegate(SalesProcMoney sProcMoney)
                {
                    if ((sProcMoney.FracProcMoneyDiv == fracProcMoneyDiv) &&
                        (sProcMoney.FractionProcCode == fractionProcCode))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            );

            //-----------------------------------------------------------------------------
            // �\�[�g�i������z�i�����j�j
            //-----------------------------------------------------------------------------
            salesProcMoneyList.Sort(new SalesProcMoneyComparer());

            //-----------------------------------------------------------------------------
            // ������z�Y�����R�[�h�擾
            //-----------------------------------------------------------------------------
            SalesProcMoney salesProcMoney = salesProcMoneyList.Find(
                delegate(SalesProcMoney spm)
                {
                    if (spm.UpperLimitPrice >= targetPrice)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            );

            //-----------------------------------------------------------------------------
            // �߂�l�ݒ�
            //-----------------------------------------------------------------------------
            if (salesProcMoney != null)
            {
                fractionProcUnit = salesProcMoney.FractionProcUnit;
                fractionProcCd = salesProcMoney.FractionProcCd;
            }
        }

        /// <summary>
        /// ������z�����敪�}�X�^��r�N���X(������z(�~��))
        /// </summary>
        private class SalesProcMoneyComparer : Comparer<SalesProcMoney>
        {
            public override int Compare(SalesProcMoney x, SalesProcMoney y)
            {
                int result = y.UpperLimitPrice.CompareTo(x.UpperLimitPrice);
                return result;
            }
        }

        /// <summary>
        /// ������z�����敪�ݒ�}�X�^�L���b�V������
        /// </summary>
        private void CacheSalesProcMoney()
        {
            _salesProcMoneyList = null;
            ArrayList al = null;
            int status = this._salesProcMoneyAcs.Search(out al, _enterpriseCode);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (al != null)
                {
                    _salesProcMoneyList = new List<SalesProcMoney>((SalesProcMoney[])al.ToArray(typeof(SalesProcMoney)));
                }
            }
        }

        /// <summary>
        /// ������z���v�Z���܂��B�i���ו����z�j�i�I�[�o�[���[�h�j
        /// </summary>
        /// <param name="salesSlip"></param>
        /// <param name="salesDetailRow"></param>
        /// <param name="salesMoneyTaxInc"></param>
        /// <param name="salesMoneyTaxExc"></param>
        /// <param name="salesMoneyDisplay"></param>
        /// <returns></returns>
        public bool CalculationSalesMoney(SalesSlipWork salesSlip, SalesDetailWork salesDetail, out long salesMoneyTaxInc, out long salesMoneyTaxExc, out long salesMoneyDisplay, out int fractionProcCd)
        {
            fractionProcCd = -1;

            // ������z���Z��
            double taxRate = salesSlip.ConsTaxRate;

            // ������z�[�������R�[�h(���Ӑ�}�X�^���擾)
            int salesMoneyFrcProcCode = this._customerInfoAcs.GetSalesFractionProcCd(this._enterpriseCode, salesSlip.CustomerCode, CustomerInfoAcs.FracProcMoneyDiv.MoneyFrcProcCd);

            // ����Œ[�������R�[�h(���Ӑ�}�X�^���擾)
            int salesCnsTaxFrcProcCd = this._customerInfoAcs.GetSalesFractionProcCd(this._enterpriseCode, salesSlip.CustomerCode, CustomerInfoAcs.FracProcMoneyDiv.CnsTaxFrcProcCd);
            // ����Œ[�������P�ʁA�敪�擾
            int taxFracProcCd = 0;
            double taxFracProcUnit = 0;
            this.GetSalesFractionProcInfo(ctFracProcMoneyDiv_Tax, salesCnsTaxFrcProcCd, 0, out taxFracProcUnit, out taxFracProcCd);
            salesSlip.FractionProcCd = taxFracProcCd;

            // �ېŋ敪
            int taxationCode = salesDetail.TaxationDivCd;

            double salesUnPrc = 0;// ����P��(�Ŕ�)
            if ((salesDetail.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxInc) || // ����
                (salesSlip.TotalAmountDispWayCd == (int)TotalAmountDispWayCd.TotalAmount)) // ���z�\������(���z�\������ꍇ�A���Ōv�Z���s��)
            {
                // ����
                salesUnPrc = salesDetail.SalesUnPrcTaxIncFl;
            }
            else
            {
                // �O��/��ې�
                salesUnPrc = salesDetail.SalesUnPrcTaxExcFl;
            }

            // ��ې�
            if (salesSlip.ConsTaxLayMethod == (int)ConsTaxLayMethod.TaxExempt)
            {
                taxationCode = (int)CalculateTax.TaxationCode.TaxNone;
            }
            // ���z�\�����͓��łŌv�Z����
            else if (salesSlip.TotalAmountDispWayCd == (int)SalesSlipInputAcs.TotalAmountDispWayCd.TotalAmount)
            {
                // ���z�\������
                if (salesDetail.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxExc)
                {
                    taxationCode = (int)CalculateTax.TaxationCode.TaxInc;
                }
            }
            bool ret = true;
            if (((salesDetail.SalesSlipCdDtl == (int)SalesSlipCdDtl.Discount) && (salesDetail.ShipmentCnt == 0))) // �s�l����
            {
                salesMoneyTaxInc = salesDetail.SalesMoneyTaxInc;
                salesMoneyTaxExc = salesDetail.SalesMoneyTaxExc;
            }
            else
            {
                ret = this.CalculationSalesMoney(
                    salesSlip,
                    salesDetail.ShipmentCnt,
                    salesUnPrc,
                    taxationCode,
                    taxRate,
                    salesMoneyFrcProcCode,
                    salesCnsTaxFrcProcCd,
                    out salesMoneyTaxInc,
                    out salesMoneyTaxExc,
                    out fractionProcCd);
            }

            if ((salesDetail.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxInc) ||
                (salesSlip.TotalAmountDispWayCd == (int)TotalAmountDispWayCd.TotalAmount))
            {
                salesMoneyDisplay = salesMoneyTaxInc; // �\�����z���ō�
            }
            else
            {
                salesMoneyDisplay = salesMoneyTaxExc; // �\�����z���Ŕ�
            }

            return ret;
        }

        /// <summary>
        /// ������z���v�Z���܂��B
        /// </summary>
        /// <param name="salesSlip"></param>
        /// <param name="shipmentCnt">����</param>
        /// <param name="salesUnPrcTaxExcFl">���P��</param>
        /// <param name="taxationCode">�ېŋ敪</param>
        /// <param name="taxRate">����ŗ�</param>
        /// <param name="salesMoneyFrcProcCd">����[�������敪(����*�P���Ɏg�p)</param>
        /// <param name="taxFrac">����Œ[�������敪</param>
        /// <param name="salesMoneyTaxInc">������z�i�ō��݁j</param>
        /// <param name="salesMoneyTaxExc">������z�i�Ŕ����j</param>
        /// <returns>true:�Z�芮�� false:�Z�莸�s</returns>
        /// <remarks>
        /// <br>Call�F���i�����^�艿�^���P���^�������^���P���^�������^������z �ύX��</br>
        /// </remarks>
        private bool CalculationSalesMoney(SalesSlipWork salesSlip, double shipmentCnt, double salesUnPrcTaxExcFl, int taxationCode, double taxRate, int salesMoneyFrcProcCd, int taxFrac, out long salesMoneyTaxInc, out long salesMoneyTaxExc, out int fractionProcCd)
        {
            fractionProcCd = -1;

            salesMoneyTaxInc = 0;
            salesMoneyTaxExc = 0;

            double unitPriceExc = 0;    // �P���i�Ŕ����j
            double unitPriceInc = 0;	// �P���i�ō��݁j
            double unitPriceTax = 0;	// �P���i����Łj
            long priceExc = 0;			// ���i�i�Ŕ����j
            long priceInc = 0;			// ���i�i�ō��݁j
            long priceTax = 0;			// ���i�i����Łj

            // ����Œ[�������P�ʁA�敪�擾
            int taxFracProcCd = 0;
            double taxFracProcUnit = 0;

            // �o�א���0�܂��͔���P����0�̏ꍇ�͂��ׂ�0�ŏI��
            if ((shipmentCnt == 0) || (salesUnPrcTaxExcFl == 0)) return true;

            switch ((CalculateTax.TaxationCode)taxationCode)
            {
                case CalculateTax.TaxationCode.TaxExc:
                    //---------------------------------
                    // �O��
                    //---------------------------------
                    unitPriceExc = salesUnPrcTaxExcFl;	// �P���i�Ŕ����j
                    priceExc = 0;					        // ���i�i�Ŕ����j

                    this._salesPriceCalculate.CalcTaxIncFromTaxExc(taxationCode, shipmentCnt, ref unitPriceExc, out unitPriceInc, out unitPriceTax, ref priceExc, out priceInc, out priceTax, salesMoneyFrcProcCd, taxFrac, taxRate, out taxFracProcUnit, out taxFracProcCd);

                    salesMoneyTaxInc = priceInc;		        // ������z�i�ō��݁j
                    salesMoneyTaxExc = priceExc;		        // ������z�i�Ŕ����j		
                    break;
                case CalculateTax.TaxationCode.TaxInc:
                    //---------------------------------
                    // ����
                    //---------------------------------
                    unitPriceInc = salesUnPrcTaxExcFl;	// �P���i�ō��݁j
                    priceInc = 0;					        // ���i�i�ō��݁j

                    this._salesPriceCalculate.CalcTaxExcFromTaxInc(taxationCode, shipmentCnt, out unitPriceExc, ref unitPriceInc, out unitPriceTax, out priceExc, ref priceInc, out priceTax, salesMoneyFrcProcCd, taxFrac, taxRate, out taxFracProcUnit, out taxFracProcCd);

                    salesMoneyTaxInc = priceInc;		        // ������z�i�ō��݁j
                    salesMoneyTaxExc = priceExc;		        // ������z�i�Ŕ����j
                    break;
                case CalculateTax.TaxationCode.TaxNone:
                    //---------------------------------
                    // ��ې�
                    //---------------------------------
                    unitPriceExc = salesUnPrcTaxExcFl;	// �P���i�Ŕ����j
                    priceExc = 0;					        // ���i�i�Ŕ����j

                    this._salesPriceCalculate.CalcTaxIncFromTaxExc(taxationCode, shipmentCnt, ref unitPriceExc, out unitPriceInc, out unitPriceTax, ref priceExc, out priceInc, out priceTax, salesMoneyFrcProcCd, taxFrac, taxRate, out taxFracProcUnit, out taxFracProcCd);

                    salesMoneyTaxInc = priceExc;		// ������z�i�ō��݁j
                    salesMoneyTaxExc = priceExc;		// ������z�i�ō��݁j
                    break;
            }

            fractionProcCd = taxFracProcCd;
            return true;
        }

        # endregion

        # region ����f�[�^�̐ݒ�
        /// <summary>
        /// ����f�[�^�̐ݒ�
        /// </summary>
        /// <param name="jnl">����MJNL�N���X</param>
        /// <param name="tempSalesSlipNum">����`�[�ԍ��i���j</param>
        /// <param name="prtShipmentCnt">�o�ɐ����Z</param>
        /// <param name="slipCd">UOE�`�[���</param>
        /// <param name="message">�G���[���b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        private int WriteDtTblSalesSlip(OrderSndRcvJnl jnl, string tempSalesSlipNum, Int32 prtShipmentCnt, Int32 slipCd, out string message)
        {
            //�ϐ��̏�����
            int status = (int)EnumUoeConst.Status.ct_NORMAL;
            message = "";

            try
            {
                //------------------------------------------------------
                // ����f�[�^�̎擾
                //------------------------------------------------------
                #region ����f�[�^�̎擾
                Int32 acptAnOdrStatus = 30;
                DataRow salesSlipDr = _uoeSndRcvJnlAcs.ReadSalesSlipDataTable(acptAnOdrStatus, tempSalesSlipNum);

                //����f�[�^�X�V����
                if (salesSlipDr != null)
                {
                    //�o�ɐ����v
                    salesSlipDr[SalesSlipSchema.ct_Col_TotalCnt] = (Int32)salesSlipDr[SalesSlipSchema.ct_Col_TotalCnt] + prtShipmentCnt;
                    
                    //���׍s��
                    salesSlipDr[SalesSlipSchema.ct_Col_DetailRowCount] = (Int32)salesSlipDr[SalesSlipSchema.ct_Col_DetailRowCount] + 1;

                    return(status);
                }
                #endregion

                //------------------------------------------------------
                // �󒍃f�[�^�̎擾
                //------------------------------------------------------
                #region �󒍃f�[�^�̎擾
                status = (int)EnumUoeConst.Status.ct_NORMAL;
                acptAnOdrStatus = 20;
                SalesSlipWork salesSlipWork = _uoeSndRcvJnlAcs.ReadAcptSlipDataTable(acptAnOdrStatus, jnl.SalesSlipNum);
                #endregion

                //------------------------------------------------------
                // ����f�[�^�̐ݒ�
                //------------------------------------------------------
                #region ����f�[�^�̐ݒ�
                //�w�b�_�[���ڏ�����
                salesSlipWork.CreateDateTime = DateTime.MinValue;
                salesSlipWork.UpdateDateTime = DateTime.MinValue;
                salesSlipWork.FileHeaderGuid = Guid.Empty;
                salesSlipWork.UpdEmployeeCode = "";
                salesSlipWork.UpdAssemblyId1 = "";
                salesSlipWork.UpdAssemblyId2 = "";
                salesSlipWork.LogicalDeleteCode = 0;

                salesSlipWork.AcptAnOdrStatus = 30;                 //�󒍃X�e�[�^�X
                salesSlipWork.SalesSlipNum = String.Empty;          //����`�[�ԍ�
                salesSlipWork.DetailRowCount = 1;                   //���׍s��

                //������t
                //UOE���Аݒ�Ͻ��̌v����t�敪:�V�X�e�����t
                if (_uoeSndRcvJnlAcs.uOESetting.AddUpADateDiv == (int)EnumUoeConst.ctAddUpADateDiv.ct_System)
                {
                    salesSlipWork.SalesDate = DateTime.Now;
                }
                //UOE���Аݒ�Ͻ��̌v����t�敪:������t
                else
                {
                    salesSlipWork.SalesDate = jnl.SalesDate;
                }

                // --------- ADD 杍^ 2013/12/16 -------------- >>>>>>>
                //�d�������Őŗ�
                salesSlipWork.ConsTaxRate = this._uOEOrderDtlAcs.GetTaxRate(salesSlipWork.SalesDate);
                // --------- ADD 杍^ 2013/12/16 -------------- <<<<<<<

                //������R�[�h�ɂĔ��㌎���y�є�������̒����`�F�b�N����
                //��������̒����擾����
                if ((salesSlipWork.ResultsAddUpSecCd.Trim() != "") && (salesSlipWork.ClaimCode != 0))
                {
                    if (_totalDayCalculator.CheckDmdC(salesSlipWork.ResultsAddUpSecCd, salesSlipWork.ClaimCode, salesSlipWork.SalesDate) != false)
                    {
                        DateTime prevTotalDay = DateTime.MinValue;
                        DateTime currentTotalDay = DateTime.MinValue;

                        if (_totalDayCalculator.GetTotalDayDmdC(salesSlipWork.ResultsAddUpSecCd, salesSlipWork.ClaimCode, out prevTotalDay, out currentTotalDay) == 0)
                        {
                            DateTime setDateTime = prevTotalDay.AddDays(1);
                            salesSlipWork.SalesDate = setDateTime;
                        }
                    }

                    //���㌎���̒����擾����
                    if (_totalDayCalculator.CheckMonthlyAccRec(salesSlipWork.ResultsAddUpSecCd, salesSlipWork.ClaimCode, salesSlipWork.SalesDate) != false)
                    {
                        DateTime prevTotalDay = DateTime.MinValue;
                        DateTime currentTotalDay = DateTime.MinValue;

                        if (_totalDayCalculator.GetTotalDayMonthlyAccRec(salesSlipWork.ResultsAddUpSecCd, salesSlipWork.ClaimCode, out prevTotalDay, out currentTotalDay) == 0)
                        {
                            DateTime setDateTime = prevTotalDay.AddDays(1);
                            salesSlipWork.SalesDate = setDateTime;
                        }
                    }
                }

                //�v����t
                salesSlipWork.AddUpADate = salesSlipWork.SalesDate;

                //���}�[�N
                salesSlipWork.UoeRemark1 = jnl.UoeRemark1;
                salesSlipWork.UoeRemark2 = jnl.UoeRemark2;
                #endregion

                //------------------------------------------------------
                // ����f�[�^�̒ǉ�����
                //------------------------------------------------------
                #region ����f�[�^�̒ǉ�����
                status = _uoeSndRcvJnlAcs.InsertSalesSlipDataTable(salesSlipWork, tempSalesSlipNum, prtShipmentCnt, slipCd, out message);
                #endregion
            }
            catch (Exception ex)
            {
                status = -1;
                message = ex.Message;
            }
            return (status);
        }

        /// <summary>
        /// �w�肵�����P���̒l�����ɔ��㖾�׍s�I�u�W�F�N�g�̒P������ݒ肵�܂�
        /// </summary>
        /// <param name="salesRowNo">����s�ԍ�</param>
        /// <param name="salesUnitPriceInputType">����P�����̓��[�h</param>
        /// <param name="salesUnitPrice">���P��</param>
        /// <param name="salesDetailDataTable">���㖾�׃f�[�^�e�[�u���I�u�W�F�N�g</param>
        /// <param name="salesDetailAcceptAnOrderDataTable">�󒍖��׃f�[�^�e�[�u���I�u�W�F�N�g</param>
        public void SalesDetailRowSalesUnitPriceSetting(ref SalesDetailWork salesDetailWork, SalesSlipWork salesSlip, SalesUnitPriceInputType salesUnitPriceInputType, double salesUnitPrice)
        {

            #region ����������
            // ����Œ[�������R�[�h(���Ӑ�}�X�^���擾)
            int salesCnsTaxFrcProcCd = this._customerInfoAcs.GetSalesFractionProcCd(this._enterpriseCode, salesSlip.CustomerCode, CustomerInfoAcs.FracProcMoneyDiv.CnsTaxFrcProcCd);
            int taxFracProcCd = 0;
            double taxFracProcUnit = 0;
            this.GetSalesFractionProcInfo(SalesSlipInputInitDataAcs.ctFracProcMoneyDiv_Tax, salesCnsTaxFrcProcCd, 0, out taxFracProcUnit, out taxFracProcCd);
            salesSlip.FractionProcCd = taxFracProcCd;

            // �ύX�O���ێ�
            double svUnitPriceTaxInc = salesDetailWork.SalesUnPrcTaxIncFl;
            double svUnitPriceTaxExc = salesDetailWork.SalesUnPrcTaxExcFl;
            #endregion

            #region ��������
            if (salesDetailWork != null)
            {
                // ��ې�
                int taxationDivCd = salesDetailWork.TaxationDivCd;
                if (salesSlip.ConsTaxLayMethod == (int)ConsTaxLayMethod.TaxExempt) taxationDivCd = (int)CalculateTax.TaxationCode.TaxNone;

                switch (salesUnitPriceInputType)
                {
                    // ���P��(�Ŕ���)--->>>���������͂��瑍�z�\�����Ȃ����̂݃R�[��
                    case SalesUnitPriceInputType.SalesUnitPrice:
                        {
                            switch ((CalculateTax.TaxationCode)taxationDivCd)
                            {
                                case CalculateTax.TaxationCode.TaxExc:
                                    //salesDetailWork.SalesUnPrcDisplay = salesUnitPrice;
                                    salesDetailWork.SalesUnPrcTaxExcFl = salesUnitPrice;
                                    salesDetailWork.SalesUnPrcTaxIncFl = salesUnitPrice + CalculateTax.GetTaxFromPriceExc(salesSlip.ConsTaxRate, taxFracProcUnit, taxFracProcCd, salesUnitPrice);
                                    break;
                                case CalculateTax.TaxationCode.TaxInc:
                                    //salesDetailWork.SalesUnPrcDisplay = salesUnitPrice;
                                    salesDetailWork.SalesUnPrcTaxExcFl = salesUnitPrice - CalculateTax.GetTaxFromPriceInc(salesSlip.ConsTaxRate, taxFracProcUnit, taxFracProcCd, salesUnitPrice);
                                    salesDetailWork.SalesUnPrcTaxIncFl = salesUnitPrice;
                                    break;
                                case CalculateTax.TaxationCode.TaxNone:
                                    //salesDetailWork.SalesUnPrcDisplay = salesUnitPrice; // ���P��(�Ŕ�)�\��
                                    salesDetailWork.SalesUnPrcTaxExcFl = salesUnitPrice;// ���P���P��(�Ŕ�)
                                    salesDetailWork.SalesUnPrcTaxIncFl = salesUnitPrice;// ���P���P��(�ō�)
                                    break;
                            }
                            break;
                        }
                    // ���P��(�ō���)--->>>���������͂��瑍�z�\�����鎞�̂݃R�[��
                    case SalesUnitPriceInputType.SalesUnitTaxPrice:
                        {
                            switch ((CalculateTax.TaxationCode)taxationDivCd)
                            {
                                case CalculateTax.TaxationCode.TaxExc:
                                case CalculateTax.TaxationCode.TaxInc:
                                    //salesDetailWork.SalesUnPrcDisplay = salesUnitPrice;
                                    salesDetailWork.SalesUnPrcTaxExcFl = salesUnitPrice - CalculateTax.GetTaxFromPriceInc(salesSlip.ConsTaxRate, taxFracProcUnit, taxFracProcCd, salesUnitPrice);
                                    salesDetailWork.SalesUnPrcTaxIncFl = salesUnitPrice;
                                    break;
                                case CalculateTax.TaxationCode.TaxNone:
                                    //salesDetailWork.SalesUnPrcDisplay = salesUnitPrice;
                                    salesDetailWork.SalesUnPrcTaxExcFl = salesUnitPrice;
                                    salesDetailWork.SalesUnPrcTaxIncFl = salesUnitPrice;
                                    break;
                            }
                            break;
                        }
                    // ���P��(�\���p)
                    case SalesUnitPriceInputType.SalesUnitPriceDisplay:
                        {

                            if (salesSlip.TotalAmountDispWayCd == (int)TotalAmountDispWayCd.NoTotalAmount)
                            {
                                //-----------------------------------------------------
                                // ���z�\�����Ȃ�
                                //-----------------------------------------------------
                                switch ((CalculateTax.TaxationCode)taxationDivCd)
                                {
                                    case CalculateTax.TaxationCode.TaxExc:
                                        salesDetailWork.SalesUnPrcTaxExcFl = salesUnitPrice;
                                        salesDetailWork.SalesUnPrcTaxIncFl = salesUnitPrice + CalculateTax.GetTaxFromPriceExc(salesSlip.ConsTaxRate, taxFracProcUnit, taxFracProcCd, salesUnitPrice);
                                        break;
                                    case CalculateTax.TaxationCode.TaxInc:
                                        salesDetailWork.SalesUnPrcTaxExcFl = salesUnitPrice - CalculateTax.GetTaxFromPriceInc(salesSlip.ConsTaxRate, taxFracProcUnit, taxFracProcCd, salesUnitPrice);
                                        salesDetailWork.SalesUnPrcTaxIncFl = salesUnitPrice;
                                        break;
                                    case CalculateTax.TaxationCode.TaxNone:
                                        salesDetailWork.SalesUnPrcTaxExcFl = salesUnitPrice;
                                        salesDetailWork.SalesUnPrcTaxIncFl = salesUnitPrice;
                                        break;
                                    default:
                                        break;
                                }
                            }
                            else
                            {
                                //-----------------------------------------------------
                                // ���z�\������
                                //-----------------------------------------------------
                                switch ((CalculateTax.TaxationCode)taxationDivCd)
                                {
                                    case CalculateTax.TaxationCode.TaxExc:
                                        salesDetailWork.SalesUnPrcTaxExcFl = salesUnitPrice - CalculateTax.GetTaxFromPriceInc(salesSlip.ConsTaxRate, taxFracProcUnit, taxFracProcCd, salesUnitPrice);
                                        salesDetailWork.SalesUnPrcTaxIncFl = salesUnitPrice;
                                        break;
                                    case CalculateTax.TaxationCode.TaxInc:
                                        salesDetailWork.SalesUnPrcTaxExcFl = salesUnitPrice - CalculateTax.GetTaxFromPriceInc(salesSlip.ConsTaxRate, taxFracProcUnit, taxFracProcCd, salesUnitPrice);
                                        salesDetailWork.SalesUnPrcTaxIncFl = salesUnitPrice;
                                        break;
                                    case CalculateTax.TaxationCode.TaxNone:
                                        salesDetailWork.SalesUnPrcTaxExcFl = salesUnitPrice;
                                        salesDetailWork.SalesUnPrcTaxIncFl = salesUnitPrice;
                                        break;
                                }
                            }
                            break;
                        }
                }

                // ����P���ύX�敪�ݒ�
                if (salesDetailWork.SalesUnPrcTaxExcFl != salesDetailWork.BfSalesUnitPrice)
                {
                    salesDetailWork.SalesUnPrcChngCd = 1; // �ύX����
                }
                else
                {
                    salesDetailWork.SalesUnPrcChngCd = 0; // �ύX�Ȃ�
                }
            }
            #endregion

        }


        /// <summary>
        /// �|�����N���A����
        /// </summary>
        /// <param name="row"></param>
        /// <param name="unitPriceKind"></param>
        private void ClearRateInfo(ref SalesDetailWork salesDetailWork, string unitPriceKind)
        {
            // �艿���
            if (unitPriceKind == UnitPriceCalculation.ctUnitPriceKind_ListPrice)
            {
                salesDetailWork.RateSectPriceUnPrc = string.Empty;
                salesDetailWork.RateDivLPrice = string.Empty;
                salesDetailWork.UnPrcCalcCdLPrice = 0;
                salesDetailWork.PriceCdLPrice = 0;
                salesDetailWork.StdUnPrcLPrice = 0;
                salesDetailWork.FracProcUnitLPrice = 0;
                salesDetailWork.FracProcLPrice = 0;

                salesDetailWork.BfListPrice = 0;
            }
            // �������
            if (unitPriceKind == UnitPriceCalculation.ctUnitPriceKind_UnitCost)
            {
                salesDetailWork.RateSectCstUnPrc = string.Empty;
                salesDetailWork.RateDivUnCst = string.Empty;
                salesDetailWork.UnPrcCalcCdUnCst = 0;
                salesDetailWork.PriceCdUnCst = 0;
                salesDetailWork.StdUnPrcUnCst = 0;
                salesDetailWork.FracProcUnitUnCst = 0;
                salesDetailWork.FracProcUnCst = 0;

                salesDetailWork.BfUnitCost = 0;
            }
            // �������
            if (unitPriceKind == UnitPriceCalculation.ctUnitPriceKind_SalesUnitPrice)
            {
                salesDetailWork.RateSectSalUnPrc = string.Empty;
                salesDetailWork.RateDivSalUnPrc = string.Empty;
                salesDetailWork.UnPrcCalcCdSalUnPrc = 0;
                salesDetailWork.PriceCdSalUnPrc = 0;
                salesDetailWork.StdUnPrcSalUnPrc = 0;
                salesDetailWork.FracProcUnitSalUnPrc = 0;
                salesDetailWork.FracProcSalUnPrc = 0;

                salesDetailWork.BfSalesUnitPrice = 0;
            }
        }

        /// <summary>
        /// �w�肵���������̒l�����ɔ��㖾�׍s�I�u�W�F�N�g�̔��P������ݒ肵�܂��B
        /// </summary>
        /// <param name="salesRowNo">����s�ԍ�</param>
        /// <param name="salesRate">������</param>
        /// <param name="clearCalculateUnitInfoFlg">�|���Z�o���N���A�t���O(true:�N���A���� false:�N���A���Ȃ�)</param>
        /// <remarks>
        /// <br>Call�F�艿�^������ �ύX��</br>
        /// </remarks>
        public void SalesDetailRowSalesUnitPriceSettingbyRate(ref SalesDetailWork salesDetailWork, SalesSlipWork salesSlip, double salesRate, bool clearCalculateUnitInfoFlg)
        {
            double salesUnPrcTaxExcFl;
            double salesUnPrcTaxIncFl;
            double salesUnPrcDisplay;

            #region ��������
            if (salesDetailWork == null) return;

            salesDetailWork.SalesRate = salesRate;

            if (clearCalculateUnitInfoFlg == true)
            {
                // �|���Z�o���N���A
                this.ClearRateInfo(ref salesDetailWork, UnitPriceCalculation.ctUnitPriceKind_SalesUnitPrice);
            }
            this.CalclateSalesUnitPrice(ref salesDetailWork, salesSlip, out salesUnPrcDisplay, out salesUnPrcTaxIncFl, out salesUnPrcTaxExcFl);

            salesDetailWork.SalesUnPrcTaxExcFl = salesUnPrcTaxExcFl;
            salesDetailWork.SalesUnPrcTaxIncFl = salesUnPrcTaxIncFl;
            #endregion
        }

        /// <summary>
        /// ���������g�p���Ē艿���甄�P�������Z�o���܂��B
        /// </summary>
        /// <param name="row">���㖾�׍s�I�u�W�F�N�g</param>
        /// <param name="unitPriceDisplay">���P��(�\��)</param>
        /// <param name="unitPriceTaxInc">���P��(�ō�)</param>
        /// <param name="unitPriceTaxExc">���P��(�Ŕ�)</param>
        private void CalclateSalesUnitPrice(ref SalesDetailWork salesDetailWork, SalesSlipWork salesSlip, out double unitPriceDisplay, out double unitPriceTaxInc, out double unitPriceTaxExc)
        {
            unitPriceDisplay = 0;
            unitPriceTaxInc = 0;
            unitPriceTaxExc = 0;
            int salesCnsTaxFrcProcCd = this._customerInfoAcs.GetSalesFractionProcCd(this._enterpriseCode, salesSlip.CustomerCode, CustomerInfoAcs.FracProcMoneyDiv.CnsTaxFrcProcCd); // �������Œ[�������R�[�h
            int taxFracProcCd = 0;
            double taxFracProcUnit = 0;
            this.GetSalesFractionProcInfo(SalesSlipInputInitDataAcs.ctFracProcMoneyDiv_Tax, salesCnsTaxFrcProcCd, 0, out taxFracProcUnit, out taxFracProcCd);

            this.CalculateUnitPriceByRate(ref salesDetailWork, salesSlip, UnitPriceCalculation.UnitPriceKind.SalesUnitPrice, out unitPriceTaxInc, out unitPriceTaxExc, out unitPriceDisplay);
        }
        #endregion

        /// <summary>
        /// �|�����g�p���ĒP�����Z�o���܂��B
        /// </summary>
        /// <param name="row"></param>
        /// <param name="unitPriceKind"></param>
        /// <param name="unitPriceTaxInc"></param>
        /// <param name="unitPriceTaxExc"></param>
        /// <param name="unitPriceDisplay"></param>
        private void CalculateUnitPriceByRate(ref SalesDetailWork salesDetailWork, SalesSlipWork salesSlip, UnitPriceCalculation.UnitPriceKind unitPriceKind, out double unitPriceTaxInc, out double unitPriceTaxExc, out double unitPriceDisplay)
        {
            int frcProcCd = 0;          // �[�������R�[�h
            int fracProcDiv = 0;        // �[�������敪
            double fracProcUnit = 0;    // �[�������P��
            double rate = 0;            // �|��
            double price = 0;           // ����i

            // ����Œ[�������R�[�h(���Ӑ�}�X�^���擾)
            int salesCnsTaxFrcProcCd = this._customerInfoAcs.GetSalesFractionProcCd(this._enterpriseCode, salesSlip.CustomerCode, CustomerInfoAcs.FracProcMoneyDiv.CnsTaxFrcProcCd);
            int taxFracProcCd = 0;
            double taxFracProcUnit = 0;
            this.GetSalesFractionProcInfo(SalesSlipInputInitDataAcs.ctFracProcMoneyDiv_Tax, salesCnsTaxFrcProcCd, 0, out taxFracProcUnit, out taxFracProcCd);
            salesSlip.FractionProcCd = taxFracProcCd;

            switch ((UnitPriceCalculation.UnitPriceKind)unitPriceKind)
            {
                #region �����P��
                //------------------------------------------------------
                // ���P��
                //------------------------------------------------------
                case UnitPriceCalculation.UnitPriceKind.UnitCost:
                    //------------------------------------------------------
                    // ����i�~�|��
                    //------------------------------------------------------
                    switch ((UnitPriceCalculation.UnitPrcCalcDiv)salesDetailWork.UnPrcCalcCdUnCst)
                    {
                        //------------------------------------------------------
                        // ����i�~�|��
                        //------------------------------------------------------
                        case UnitPriceCalculation.UnitPrcCalcDiv.RateVal:
                            frcProcCd = this._supplierAcs.GetStockFractionProcCd(this._enterpriseCode, salesDetailWork.SupplierCd, SupplierAcs.StockFracProcMoneyDiv.UnPrcFrcProcCd);
                            fracProcUnit = salesDetailWork.FracProcUnitUnCst;
                            fracProcDiv = salesDetailWork.FracProcUnCst;
                            rate = salesDetailWork.CostRate;
                            price = salesDetailWork.StdUnPrcUnCst;
                            break;
                        default:
                            frcProcCd = this._supplierAcs.GetStockFractionProcCd(this._enterpriseCode, salesDetailWork.SupplierCd, SupplierAcs.StockFracProcMoneyDiv.UnPrcFrcProcCd);
                            this._salesSlipInputInitDataAcs.GetStockFractionProcInfo(SalesSlipInputInitDataAcs.ctFracProcMoneyDiv_SalesUnitCost, frcProcCd, 0, out fracProcUnit, out fracProcDiv);
                            rate = salesDetailWork.CostRate;
                            switch ((CalculateTax.TaxationCode)salesDetailWork.TaxationDivCd)
                            {
                                //------------------------------------------------------
                                // �O��
                                //------------------------------------------------------
                                case CalculateTax.TaxationCode.TaxExc:
                                    price = salesDetailWork.ListPriceTaxExcFl;
                                    break;
                                //------------------------------------------------------
                                // ����
                                //------------------------------------------------------
                                case CalculateTax.TaxationCode.TaxInc:
                                    price = salesDetailWork.ListPriceTaxIncFl;
                                    break;
                                //------------------------------------------------------
                                // ��ې�
                                //------------------------------------------------------
                                case CalculateTax.TaxationCode.TaxNone:
                                    price = salesDetailWork.ListPriceTaxExcFl;
                                    break;
                            }
                            break;
                    }
                    break;
                #endregion

                #region �����P��
                //------------------------------------------------------
                // ���P��
                //------------------------------------------------------
                case UnitPriceCalculation.UnitPriceKind.SalesUnitPrice:
                    switch ((UnitPriceCalculation.UnitPrcCalcDiv)salesDetailWork.UnPrcCalcCdSalUnPrc)
                    {
                        //------------------------------------------------------
                        // ����i�~�|��
                        //------------------------------------------------------
                        case UnitPriceCalculation.UnitPrcCalcDiv.RateVal:
                            frcProcCd = this._customerInfoAcs.GetSalesFractionProcCd(this._enterpriseCode, salesSlip.CustomerCode, CustomerInfoAcs.FracProcMoneyDiv.UnPrcFrcProcCd);
                            fracProcUnit = salesDetailWork.FracProcUnitSalUnPrc;
                            fracProcDiv = salesDetailWork.FracProcSalUnPrc;
                            rate = salesDetailWork.SalesRate;
                            price = salesDetailWork.StdUnPrcSalUnPrc;
                            break;
                        //------------------------------------------------------
                        // ���P���~�����t�o��
                        //------------------------------------------------------
                        case UnitPriceCalculation.UnitPrcCalcDiv.UpRate:
                            frcProcCd = this._customerInfoAcs.GetSalesFractionProcCd(this._enterpriseCode, salesSlip.CustomerCode, CustomerInfoAcs.FracProcMoneyDiv.UnPrcFrcProcCd);
                            fracProcUnit = salesDetailWork.FracProcUnitSalUnPrc;
                            fracProcDiv = salesDetailWork.FracProcSalUnPrc;
                            //rate = salesDetailWork.CostUpRate;
                            price = salesDetailWork.StdUnPrcSalUnPrc;
                            break;
                        //------------------------------------------------------
                        // ���P���~(�P�|�e����)
                        //------------------------------------------------------
                        case UnitPriceCalculation.UnitPrcCalcDiv.GrsProfitSecureRate:
                            frcProcCd = this._customerInfoAcs.GetSalesFractionProcCd(this._enterpriseCode, salesSlip.CustomerCode, CustomerInfoAcs.FracProcMoneyDiv.UnPrcFrcProcCd);
                            fracProcUnit = salesDetailWork.FracProcUnitSalUnPrc;
                            fracProcDiv = salesDetailWork.FracProcSalUnPrc;
                            //rate = salesDetailWork.GrossProfitSecureRate;
                            price = salesDetailWork.StdUnPrcSalUnPrc;
                            break;
                        //------------------------------------------------------
                        // �P�����ڎw��
                        //------------------------------------------------------
                        case UnitPriceCalculation.UnitPrcCalcDiv.Price:
                            //    frcProcCd = this._customerInfoAcs.GetSalesFractionProcCd(this._enterpriseCode, salesSlip.CustomerCode, CustomerInfoAcs.FracProcMoneyDiv.UnPrcFrcProcCd);
                            //    fracProcUnit = row.FracProcUnitSalUnPrc;
                            //    fracProcDiv = row.FracProcSalUnPrc;
                            //    rate = 0;
                            //    price = 0;
                            //    break;
                            //default:
                            frcProcCd = this._customerInfoAcs.GetSalesFractionProcCd(this._enterpriseCode, salesSlip.CustomerCode, CustomerInfoAcs.FracProcMoneyDiv.UnPrcFrcProcCd);
                            fracProcUnit = salesDetailWork.FracProcUnitSalUnPrc;
                            fracProcDiv = salesDetailWork.FracProcSalUnPrc;
                            rate = salesDetailWork.SalesRate;
                            switch ((CalculateTax.TaxationCode)salesDetailWork.TaxationDivCd)
                            {
                                //------------------------------------------------------
                                // �O��
                                //------------------------------------------------------
                                case CalculateTax.TaxationCode.TaxExc:
                                    price = salesDetailWork.ListPriceTaxExcFl;
                                    break;
                                //------------------------------------------------------
                                // ����
                                //------------------------------------------------------
                                case CalculateTax.TaxationCode.TaxInc:
                                    price = salesDetailWork.ListPriceTaxIncFl;
                                    break;
                                //------------------------------------------------------
                                // ��ې�
                                //------------------------------------------------------
                                case CalculateTax.TaxationCode.TaxNone:
                                    price = salesDetailWork.ListPriceTaxExcFl;
                                    break;
                            }
                            break;
                    }
                    break;
                #endregion
            }

            // ��ې�
            int taxationDivCd = salesDetailWork.TaxationDivCd;
            if (salesSlip.ConsTaxLayMethod == (int)ConsTaxLayMethod.TaxExempt) taxationDivCd = (int)CalculateTax.TaxationCode.TaxNone;

            int unPrcCalcCd = 0;
            switch ((UnitPriceCalculation.UnitPriceKind)unitPriceKind)
            {
                case UnitPriceCalculation.UnitPriceKind.UnitCost:
                    unPrcCalcCd = salesDetailWork.UnPrcCalcCdUnCst;
                    break;
                case UnitPriceCalculation.UnitPriceKind.SalesUnitPrice:
                    unPrcCalcCd = salesDetailWork.UnPrcCalcCdSalUnPrc;
                    break;
            }

            if (unPrcCalcCd != (int)UnitPriceCalculation.UnitPrcCalcDiv.GrsProfitSecureRate)
            {
                this._unitPriceCalculation.CalculateUnitPriceByRate(unitPriceKind,
                                                                    (UnitPriceCalculation.UnitPrcCalcDiv)salesDetailWork.UnPrcCalcCdSalUnPrc,
                                                                    salesSlip.TotalAmountDispWayCd,
                                                                    0,
                                                                    frcProcCd,
                                                                    taxationDivCd,
                                                                    price,
                                                                    salesSlip.ConsTaxRate,
                                                                    taxFracProcUnit,
                                                                    taxFracProcCd,
                                                                    rate,
                                                                    ref fracProcUnit,
                                                                    ref fracProcDiv,
                                                                    out unitPriceTaxExc,
                                                                    out unitPriceTaxInc);
            }
            else
            {
                this._unitPriceCalculation.CalculateUnitPriceByMarginRate(unitPriceKind,
                    //(UnitPriceCalculation.UnitPrcCalcDiv)row.UnPrcCalcCdSalUnPrc,
                                                                    salesSlip.TotalAmountDispWayCd,
                                                                    0,
                                                                    frcProcCd,
                                                                    taxationDivCd,
                                                                    price,
                                                                    salesSlip.ConsTaxRate,
                                                                    taxFracProcUnit,
                                                                    taxFracProcCd,
                                                                    rate,
                                                                    ref fracProcUnit,
                                                                    ref fracProcDiv,
                                                                    out unitPriceTaxExc,
                                                                    out unitPriceTaxInc);
            }
            if ((UnitPriceCalculation.UnitPriceKind)unitPriceKind != UnitPriceCalculation.UnitPriceKind.UnitCost)
            {
                // �u���z�\������v���A�u���ŏ��i�v�̏ꍇ�͐ō��ݒP����\���P���ɐݒ�
                if ((salesSlip.TotalAmountDispWayCd == (int)TotalAmountDispWayCd.TotalAmount) || (taxationDivCd == (int)CalculateTax.TaxationCode.TaxInc))
                {
                    unitPriceDisplay = unitPriceTaxInc;
                }
                else
                {
                    unitPriceDisplay = unitPriceTaxExc;
                }
            }
            else
            {
                if (taxationDivCd == (int)CalculateTax.TaxationCode.TaxInc)
                {
                    unitPriceDisplay = unitPriceTaxInc;
                }
                else
                {
                    unitPriceDisplay = unitPriceTaxExc;
                }
            }
        }


        /// <summary>
        /// �|�����g�p���ĒP�����Z�o���܂��B
        /// </summary>
        /// <param name="row"></param>
        /// <param name="unitPriceKind"></param>
        /// <param name="fracProcDiv"></param>
        /// <param name="fracProcUnit"></param>
        /// <param name="unitPriceTaxInc"></param>
        /// <param name="unitPriceTaxExc"></param>
        /// <param name="unitPriceDisplay"></param>
        private void CalculateUnitPriceByRate(ref SalesDetailWork salesDetailWork, SalesSlipWork salesSlip, UnitPriceCalculation.UnitPriceKind unitPriceKind, ref int fracProcDiv, ref double fracProcUnit, out double unitPriceTaxInc, out double unitPriceTaxExc, out double unitPriceDisplay)
        {
            int frcProcCd = 0;          // �[�������R�[�h
            double rate = 0;            // �|��
            double price = 0;           // ����i

            // ����Œ[�������R�[�h(���Ӑ�}�X�^���擾)
            int salesCnsTaxFrcProcCd = this._customerInfoAcs.GetSalesFractionProcCd(this._enterpriseCode, salesSlip.CustomerCode, CustomerInfoAcs.FracProcMoneyDiv.CnsTaxFrcProcCd);
            int taxFracProcCd = 0;
            double taxFracProcUnit = 0;
            this.GetSalesFractionProcInfo(SalesSlipInputInitDataAcs.ctFracProcMoneyDiv_Tax, salesCnsTaxFrcProcCd, 0, out taxFracProcUnit, out taxFracProcCd);
            salesSlip.FractionProcCd = taxFracProcCd;

            switch ((UnitPriceCalculation.UnitPriceKind)unitPriceKind)
            {
                #region �����P��
                //------------------------------------------------------
                // ���P��
                //------------------------------------------------------
                case UnitPriceCalculation.UnitPriceKind.UnitCost:
                    //------------------------------------------------------
                    // �[�������敪�A�P�ʎ擾
                    //------------------------------------------------------
                    frcProcCd = this._supplierAcs.GetStockFractionProcCd(this._enterpriseCode, salesDetailWork.SupplierCd, SupplierAcs.StockFracProcMoneyDiv.UnPrcFrcProcCd);
                    //------------------------------------------------------
                    // ����i�~�|��
                    //------------------------------------------------------
                    switch ((UnitPriceCalculation.UnitPrcCalcDiv)salesDetailWork.UnPrcCalcCdUnCst)
                    {
                        //------------------------------------------------------
                        // ����i�~�|��
                        //------------------------------------------------------
                        case UnitPriceCalculation.UnitPrcCalcDiv.RateVal:
                            rate = salesDetailWork.CostRate;
                            price = salesDetailWork.StdUnPrcUnCst;
                            break;
                        default:
                            rate = salesDetailWork.CostRate;
                            price = salesDetailWork.ListPriceTaxExcFl;
                            break;
                    }
                    break;
                #endregion

                #region �����P��
                //------------------------------------------------------
                // ���P��
                //------------------------------------------------------
                case UnitPriceCalculation.UnitPriceKind.SalesUnitPrice:
                    //------------------------------------------------------
                    // �[�������敪�A�P�ʎ擾
                    //------------------------------------------------------
                    frcProcCd = this._customerInfoAcs.GetSalesFractionProcCd(this._enterpriseCode, salesSlip.CustomerCode, CustomerInfoAcs.FracProcMoneyDiv.UnPrcFrcProcCd);
                    switch ((UnitPriceCalculation.UnitPrcCalcDiv)salesDetailWork.UnPrcCalcCdSalUnPrc)
                    {
                        //------------------------------------------------------
                        // ����i�~�|��
                        //------------------------------------------------------
                        case UnitPriceCalculation.UnitPrcCalcDiv.RateVal:
                            rate = salesDetailWork.SalesRate;
                            price = salesDetailWork.StdUnPrcSalUnPrc;
                            break;
                        //------------------------------------------------------
                        // ���P���~�����t�o��
                        //------------------------------------------------------
                        case UnitPriceCalculation.UnitPrcCalcDiv.UpRate:
                            //rate = salesDetailWork.CostUpRate;
                            price = salesDetailWork.StdUnPrcSalUnPrc;
                            break;
                        //------------------------------------------------------
                        // ���P���~(�P�|�e����)
                        //------------------------------------------------------
                        case UnitPriceCalculation.UnitPrcCalcDiv.GrsProfitSecureRate:
                            //rate = salesDetailWork.GrossProfitSecureRate;
                            price = salesDetailWork.StdUnPrcSalUnPrc;
                            break;
                        //------------------------------------------------------
                        // �P�����ڎw��
                        //------------------------------------------------------
                        case UnitPriceCalculation.UnitPrcCalcDiv.Price:
                            //    rate = 0;
                            //    price = 0;
                            //    break;
                            //default:
                            rate = salesDetailWork.SalesRate;
                            switch ((CalculateTax.TaxationCode)salesDetailWork.TaxationDivCd)
                            {
                                //------------------------------------------------------
                                // �O��
                                //------------------------------------------------------
                                case CalculateTax.TaxationCode.TaxExc:
                                    price = salesDetailWork.ListPriceTaxExcFl;
                                    break;
                                //------------------------------------------------------
                                // ����
                                //------------------------------------------------------
                                case CalculateTax.TaxationCode.TaxInc:
                                    price = salesDetailWork.ListPriceTaxIncFl;
                                    break;
                                //------------------------------------------------------
                                // ��ې�
                                //------------------------------------------------------
                                case CalculateTax.TaxationCode.TaxNone:
                                    price = salesDetailWork.ListPriceTaxExcFl;
                                    break;
                            }
                            break;
                    }
                    break;
                #endregion
            }

            // ��ې�
            int taxationDivCd = salesDetailWork.TaxationDivCd;
            if (salesSlip.ConsTaxLayMethod == (int)ConsTaxLayMethod.TaxExempt) taxationDivCd = (int)CalculateTax.TaxationCode.TaxNone;

            int unPrcCalcCd = 0;
            switch ((UnitPriceCalculation.UnitPriceKind)unitPriceKind)
            {
                case UnitPriceCalculation.UnitPriceKind.UnitCost:
                    unPrcCalcCd = salesDetailWork.UnPrcCalcCdUnCst;
                    break;
                case UnitPriceCalculation.UnitPriceKind.SalesUnitPrice:
                    unPrcCalcCd = salesDetailWork.UnPrcCalcCdSalUnPrc;
                    break;
            }

            if (unPrcCalcCd != (int)UnitPriceCalculation.UnitPrcCalcDiv.GrsProfitSecureRate)
            {
                this._unitPriceCalculation.CalculateUnitPriceByRate(unitPriceKind,
                                                                    (UnitPriceCalculation.UnitPrcCalcDiv)salesDetailWork.UnPrcCalcCdSalUnPrc,
                                                                    salesSlip.TotalAmountDispWayCd,
                                                                    0,
                                                                    frcProcCd,
                                                                    taxationDivCd,
                                                                    price,
                                                                    salesSlip.ConsTaxRate,
                                                                    taxFracProcUnit,
                                                                    taxFracProcCd,
                                                                    rate,
                                                                    ref fracProcUnit,
                                                                    ref fracProcDiv,
                                                                    out unitPriceTaxExc,
                                                                    out unitPriceTaxInc);
            }
            else
            {
                this._unitPriceCalculation.CalculateUnitPriceByMarginRate(unitPriceKind,
                    //(UnitPriceCalculation.UnitPrcCalcDiv)row.UnPrcCalcCdSalUnPrc,
                                                                    salesSlip.TotalAmountDispWayCd,
                                                                    0,
                                                                    frcProcCd,
                                                                    taxationDivCd,
                                                                    price,
                                                                    salesSlip.ConsTaxRate,
                                                                    taxFracProcUnit,
                                                                    taxFracProcCd,
                                                                    rate,
                                                                    ref fracProcUnit,
                                                                    ref fracProcDiv,
                                                                    out unitPriceTaxExc,
                                                                    out unitPriceTaxInc);
            }

            // �u���z�\������v���A�u���ŏ��i�v�̏ꍇ�͐ō��ݒP����\���P���ɐݒ�
            if ((salesSlip.TotalAmountDispWayCd == 1) || (taxationDivCd == (int)CalculateTax.TaxationCode.TaxInc))
            {
                unitPriceDisplay = unitPriceTaxInc;
            }
            else
            {
                unitPriceDisplay = unitPriceTaxExc;
            }
        }

        /// <summary>
        /// �w�肵���艿�̒l�����ɔ��㖾�׍s�I�u�W�F�N�g�̒艿����ݒ肵�܂�
        /// </summary>
        /// <param name="salesRowNo">����s�ԍ�</param>
        /// <param name="salesUnitPriceInputType">����P�����̓��[�h</param>
        /// <param name="listPrice">�艿</param>
        /// <param name="salesDetailDataTable">���㖾�׃f�[�^�e�[�u���I�u�W�F�N�g</param>
        private void SalesDetailRowListPriceSetting(ref SalesDetailWork salesDetailWork, SalesSlipWork salesSlip, SalesUnitPriceInputType salesUnitPriceInputType, double listPrice)
        {
            #region ����������
            // ����Œ[�������R�[�h(�[���Œ�)
            int salesCnsTaxFrcProcCd = 0;

            // ����Œ[�������P�ʁA�敪�擾
            int taxFracProcCd = 0;
            double taxFracProcUnit = 0;
            //this._salesSlipInputInitDataAcs.GetSalesFractionProcInfo(SalesSlipInputInitDataAcs.ctFracProcMoneyDiv_Tax, salesCnsTaxFrcProcCd, 0, out taxFracProcUnit, out taxFracProcCd);
            this.GetSalesFractionProcInfo(SalesSlipInputInitDataAcs.ctFracProcMoneyDiv_Tax, salesCnsTaxFrcProcCd, 0, out taxFracProcUnit, out taxFracProcCd);

            double svListPriceTaxInc = salesDetailWork.ListPriceTaxIncFl;
            double svListPriceTaxExc = salesDetailWork.ListPriceTaxExcFl;
            #endregion

            #region ��������
            if (salesDetailWork != null)
            {
                switch (salesUnitPriceInputType)
                {
                    // ���P��(�Ŕ���)
                    case SalesUnitPriceInputType.SalesUnitPrice:
                        {
                            switch ((CalculateTax.TaxationCode)salesDetailWork.TaxationDivCd)
                            {
                                case CalculateTax.TaxationCode.TaxExc:
                                    //salesDetailWork.ListPriceDisplay = listPrice;      // �艿�\��
                                    salesDetailWork.ListPriceTaxExcFl = listPrice;     // �艿(�Ŕ�)
                                    salesDetailWork.ListPriceTaxIncFl = listPrice + CalculateTax.GetTaxFromPriceExc(salesSlip.ConsTaxRate, taxFracProcUnit, taxFracProcCd, listPrice);     // �艿(�ō�)
                                    break;
                                case CalculateTax.TaxationCode.TaxInc:
                                    //salesDetailWork.ListPriceDisplay = listPrice;      // �艿�\��
                                    salesDetailWork.ListPriceTaxExcFl = listPrice - CalculateTax.GetTaxFromPriceInc(salesSlip.ConsTaxRate, taxFracProcUnit, taxFracProcCd, listPrice);     // �艿(�Ŕ�)
                                    salesDetailWork.ListPriceTaxIncFl = listPrice;     // �艿(�ō�)
                                    break;
                                case CalculateTax.TaxationCode.TaxNone:
                                    //salesDetailWork.ListPriceDisplay = listPrice;      // �艿�\��
                                    salesDetailWork.ListPriceTaxExcFl = listPrice;     // �艿(�Ŕ�)
                                    salesDetailWork.ListPriceTaxIncFl = listPrice;     // �艿(�ō�)
                                    break;
                            }
                            break;
                        }
                    // ���P��(�ō���)
                    case SalesUnitPriceInputType.SalesUnitTaxPrice:
                        {
                            switch ((CalculateTax.TaxationCode)salesDetailWork.TaxationDivCd)
                            {
                                case CalculateTax.TaxationCode.TaxExc:
                                    //salesDetailWork.ListPriceDisplay = listPrice;      // �艿�\��
                                    salesDetailWork.ListPriceTaxExcFl = listPrice;     // �艿(�Ŕ�)
                                    salesDetailWork.ListPriceTaxIncFl = listPrice;     // �艿(�ō�)
                                    break;
                                case CalculateTax.TaxationCode.TaxInc:
                                    //salesDetailWork.ListPriceDisplay = listPrice;      // �艿�\��
                                    salesDetailWork.ListPriceTaxExcFl = listPrice - CalculateTax.GetTaxFromPriceInc(salesSlip.ConsTaxRate, taxFracProcUnit, taxFracProcCd, listPrice);     // �艿(�Ŕ�)
                                    salesDetailWork.ListPriceTaxIncFl = listPrice;     // �艿(�ō�)
                                    break;
                                case CalculateTax.TaxationCode.TaxNone:
                                    //salesDetailWork.ListPriceDisplay = listPrice;      // �艿�\��
                                    salesDetailWork.ListPriceTaxExcFl = listPrice - CalculateTax.GetTaxFromPriceInc(salesSlip.ConsTaxRate, taxFracProcUnit, taxFracProcCd, listPrice);     // �艿(�Ŕ�)
                                    salesDetailWork.ListPriceTaxIncFl = listPrice;     // �艿(�ō�)
                                    break;
                            }
                            break;
                        }
                    // ���P��(�\���p)
                    case SalesUnitPriceInputType.SalesUnitPriceDisplay:
                        {

                            if (salesSlip.TotalAmountDispWayCd == 0)
                            {
                                //-----------------------------------------------------
                                // ���z�\�����Ȃ�
                                //-----------------------------------------------------
                                switch ((CalculateTax.TaxationCode)salesDetailWork.TaxationDivCd)
                                {
                                    case CalculateTax.TaxationCode.TaxExc:
                                        salesDetailWork.ListPriceTaxExcFl = listPrice;     // �艿(�Ŕ�)
                                        salesDetailWork.ListPriceTaxIncFl = listPrice + CalculateTax.GetTaxFromPriceExc(salesSlip.ConsTaxRate, taxFracProcUnit, taxFracProcCd, listPrice);     // �艿(�ō�)
                                        break;
                                    case CalculateTax.TaxationCode.TaxInc:
                                        salesDetailWork.ListPriceTaxExcFl = listPrice - CalculateTax.GetTaxFromPriceInc(salesSlip.ConsTaxRate, taxFracProcUnit, taxFracProcCd, listPrice);     // �艿(�Ŕ�)
                                        salesDetailWork.ListPriceTaxIncFl = listPrice;     // �艿(�ō�)
                                        break;
                                    case CalculateTax.TaxationCode.TaxNone:
                                        salesDetailWork.ListPriceTaxExcFl = listPrice;     // �艿(�Ŕ�)
                                        salesDetailWork.ListPriceTaxIncFl = listPrice;     // �艿(�ō�)
                                        break;
                                }
                            }
                            else
                            {
                                //-----------------------------------------------------
                                // ���z�\������
                                //-----------------------------------------------------
                                switch ((CalculateTax.TaxationCode)salesDetailWork.TaxationDivCd)
                                {
                                    case CalculateTax.TaxationCode.TaxExc:
                                        salesDetailWork.ListPriceTaxExcFl = listPrice - CalculateTax.GetTaxFromPriceInc(salesSlip.ConsTaxRate, taxFracProcUnit, taxFracProcCd, listPrice);     // �艿(�Ŕ�)
                                        salesDetailWork.ListPriceTaxIncFl = listPrice;     // �艿(�ō�)
                                        break;
                                    case CalculateTax.TaxationCode.TaxInc:
                                        salesDetailWork.ListPriceTaxExcFl = listPrice - CalculateTax.GetTaxFromPriceInc(salesSlip.ConsTaxRate, taxFracProcUnit, taxFracProcCd, listPrice);     // �艿(�Ŕ�)
                                        salesDetailWork.ListPriceTaxIncFl = listPrice;     // �艿(�ō�)
                                        break;
                                    case CalculateTax.TaxationCode.TaxNone:
                                        salesDetailWork.ListPriceTaxExcFl = listPrice;     // �艿(�Ŕ�)
                                        salesDetailWork.ListPriceTaxIncFl = listPrice;     // �艿(�ō�)
                                        break;
                                }
                            }
                            break;
                        }
                }

                // ��P��(�艿)�ݒ�
                switch ((UnitPriceCalculation.UnitPrcCalcDiv)salesDetailWork.UnPrcCalcCdLPrice)
                {
                    // �|��
                    case UnitPriceCalculation.UnitPrcCalcDiv.RateVal:
                        salesDetailWork.StdUnPrcLPrice = listPrice;
                        break;
                    // �����t�o��
                    case UnitPriceCalculation.UnitPrcCalcDiv.UpRate:
                        break;
                    // �e���m�ۗ�
                    case UnitPriceCalculation.UnitPrcCalcDiv.GrsProfitSecureRate:
                        break;
                    // �P�������or��ʎ����
                    case UnitPriceCalculation.UnitPrcCalcDiv.Price:
                        salesDetailWork.StdUnPrcLPrice = 0;
                        break;
                }

                // ��P��(����P��)�ݒ�
                switch ((UnitPriceCalculation.UnitPrcCalcDiv)salesDetailWork.UnPrcCalcCdSalUnPrc)
                {
                    // �|��
                    case UnitPriceCalculation.UnitPrcCalcDiv.RateVal:
                        salesDetailWork.StdUnPrcSalUnPrc = listPrice;
                        break;
                    // �����t�o��
                    case UnitPriceCalculation.UnitPrcCalcDiv.UpRate:
                        break;
                    // �e���m�ۗ�
                    case UnitPriceCalculation.UnitPrcCalcDiv.GrsProfitSecureRate:
                        break;
                    // �P�������or��ʎ����
                    case UnitPriceCalculation.UnitPrcCalcDiv.Price:
                        salesDetailWork.StdUnPrcSalUnPrc = 0;
                        break;
                }

                // ��P��(�����P��)�ݒ�
                switch ((UnitPriceCalculation.UnitPrcCalcDiv)salesDetailWork.UnPrcCalcCdUnCst)
                {
                    // �|��
                    case UnitPriceCalculation.UnitPrcCalcDiv.RateVal:
                        salesDetailWork.StdUnPrcUnCst = listPrice;
                        break;
                    // �����t�o��
                    case UnitPriceCalculation.UnitPrcCalcDiv.UpRate:
                        break;
                    // �e���m�ۗ�
                    case UnitPriceCalculation.UnitPrcCalcDiv.GrsProfitSecureRate:
                        break;
                    // �P�������or��ʎ����
                    case UnitPriceCalculation.UnitPrcCalcDiv.Price:
                        salesDetailWork.StdUnPrcUnCst = 0;
                        break;
                }

                // �艿�ύX�敪�ݒ�
                if (salesDetailWork.ListPriceTaxExcFl != salesDetailWork.BfListPrice)
                {
                    salesDetailWork.ListPriceChngCd = 1; // �ύX����
                }
                else
                {
                    salesDetailWork.ListPriceChngCd = 0; // �ύX�Ȃ�
                }

            }
            #endregion
        }

        /// <summary>
        /// �������z���v�Z���܂��B
        /// </summary>
        /// <param name="salesDetailWork">���㖾�׃f�[�^�I�u�W�F�N�g</param>
        /// <param name="salesSlip">����f�[�^�I�u�W�F�N�g</param>
        private void CalculationCost(ref SalesDetailWork salesDetailWork, SalesSlipWork salesSlip)
        {
            #region ����������
            if (salesSlip == null) return;
            #endregion

            #region �����z�Z��
            switch ((SalesGoodsCd)salesDetailWork.SalesGoodsCd)
            {
                // ���i
                case SalesGoodsCd.Goods:

                    // �������z���Z��
                    long costTaxInc;
                    long costTaxExc;
                    long costDisplay;
                    double taxRate = salesSlip.ConsTaxRate;

                    // �ېŋ敪
                    int taxationCode = salesDetailWork.TaxationDivCd;

                    double salesUnitCost = salesDetailWork.SalesUnitCost;

                    //switch ((CalculateTax.TaxationCode)salesDetailWork.TaxationDivCd)
                    //{
                    //    case CalculateTax.TaxationCode.TaxExc:
                    //        salesUnitCost = salesDetailWork.SalesUnitCostTaxExc;
                    //        break;
                    //    case CalculateTax.TaxationCode.TaxInc:
                    //        salesUnitCost = salesDetailWork.SalesUnitCostTaxInc;
                    //        break;
                    //    case CalculateTax.TaxationCode.TaxNone:
                    //        salesUnitCost = salesDetailWork.SalesUnitCostTaxExc;
                    //        break;
                    //}

                    // ��ې�
                    if (salesSlip.ConsTaxLayMethod == (int)ConsTaxLayMethod.TaxExempt)
                    {
                        taxationCode = (int)CalculateTax.TaxationCode.TaxNone;
                    }
                    // ����
                    else if ((taxationCode != (int)CalculateTax.TaxationCode.TaxNone) &&
                             (salesSlip.TotalAmountDispWayCd == (int)TotalAmountDispWayCd.TotalAmount))
                    {
                        taxationCode = (int)CalculateTax.TaxationCode.TaxInc;
                    }

                    #region ��������
                    int sign = (salesSlip.SalesSlipCd == (int)SalesSlipCd.RetGoods) ? -1 : 1;
                    if (this.CalculationCost(
                        ref salesDetailWork,
                        salesDetailWork.ShipmentCnt * sign,
                        salesUnitCost,
                        taxationCode,
                        taxRate,
                        out costTaxInc,
                        out costTaxExc,
                        out costDisplay))
                    {
                        //salesDetailWork.CostTaxExc = costTaxExc;        // �O��
                        //salesDetailWork.CostTaxInc = costTaxInc;        // ����
                        salesDetailWork.Cost = costDisplay;
                    }
                    #endregion

                    break;
                // ����Œ���
                // �c������
                case SalesGoodsCd.ConsTaxAdjust:
                case SalesGoodsCd.AccRecConsTaxAdjust:
                case SalesGoodsCd.BalanceAdjust:
                case SalesGoodsCd.AccRecBalanceAdjust:
                    break;
            }
            #endregion
        }

        /// <summary>
        /// �������z���v�Z���܂��B
        /// </summary>
        /// <param name="salesRowNo">����s�ԍ�</param>
        /// <param name="shipmentCnt">����</param>
        /// <param name="SalesUnitCostTaxExc">�����P��</param>
        /// <param name="taxationCode">�ېŋ敪</param>
        /// <param name="taxRate">����ŗ�</param>
        /// <param name="costTaxInc">�������z�i�ō��݁j</param>
        /// <param name="costTaxExc">�������z�i�Ŕ����j</param>
        /// <param name="costDisplay">�������z�i�\���j</param>
        /// <returns>true:�Z�芮�� false:�Z�莸�s</returns>
        /// <remarks>
        /// <br>Call�F���i�����^�艿�^���P���^�������^���P���^�������^������z �ύX��</br>
        /// </remarks>
        private bool CalculationCost(ref SalesDetailWork salesDetailWork, double shipmentCnt, double SalesUnitCostTaxExc, int taxationCode, double taxRate, out long costInc, out long costExc, out long costDisplay)
        {
            costInc = 0;
            costExc = 0;
            costDisplay = 0;
            double unitPriceExc = 0;	                // �P���i�Ŕ����j
            double unitPriceInc = 0;				    // �P���i�ō��݁j
            double unitPriceTax = 0;					// �P���i����Łj
            long priceExc = 0;					        // ���i�i�Ŕ����j
            long priceInc = 0;						    // ���i�i�ō��݁j
            long priceTax = 0;						    // ���i�i����Łj

            // �������z�[�������R�[�h
            int costFrcProcCd = this._supplierAcs.GetStockFractionProcCd(this._enterpriseCode, salesDetailWork.SupplierCd, SupplierAcs.StockFracProcMoneyDiv.MoneyFrcProcCd);

            // ����Œ[�������P�ʁA�敪�擾
            int taxFrac = this._supplierAcs.GetStockFractionProcCd(this._enterpriseCode, salesDetailWork.SupplierCd, SupplierAcs.StockFracProcMoneyDiv.CnsTaxFrcProcCd);
            int taxFracProcCd = 0;
            double taxFracProcUnit = 0;

            // �o�א���0�܂��͔���P����0�̏ꍇ�͂��ׂ�0�ŏI��
            if ((shipmentCnt == 0) || (SalesUnitCostTaxExc == 0)) return true;

            switch ((CalculateTax.TaxationCode)taxationCode)
            {
                case CalculateTax.TaxationCode.TaxExc:
                    //---------------------------------
                    // �O��
                    //---------------------------------
                    unitPriceExc = SalesUnitCostTaxExc;	    // �P���i�Ŕ����j
                    priceExc = 0;					        // ���i�i�Ŕ����j

                    //this._salesPriceCalculate.CalcTaxIncFromTaxExc(taxationCode, shipmentCnt, ref unitPriceExc, out unitPriceInc, out unitPriceTax, ref priceExc, out priceInc, out priceTax, costFrcProcCd, taxFrac, taxRate, out taxFracProcUnit, out taxFracProcCd);
                    this._stockPriceCalculate.CalcTaxIncFromTaxExc(taxationCode, shipmentCnt, ref unitPriceExc, out unitPriceInc, out unitPriceTax, ref priceExc, out priceInc, out priceTax, costFrcProcCd, taxRate, taxFrac, out taxFracProcUnit, out taxFracProcCd);
                    costInc = priceInc;		        // ������z�i�ō��݁j
                    costExc = priceExc;		        // ������z�i�Ŕ����j		
                    break;
                case CalculateTax.TaxationCode.TaxInc:
                    //---------------------------------
                    // ����
                    //---------------------------------
                    unitPriceInc = SalesUnitCostTaxExc;	    // �P���i�ō��݁j
                    priceInc = 0;					        // ���i�i�ō��݁j

                    //this._salesPriceCalculate.CalcTaxExcFromTaxInc(taxationCode, shipmentCnt, out unitPriceExc, ref unitPriceInc, out unitPriceTax, out priceExc, ref priceInc, out priceTax, costFrcProcCd, taxFrac, taxRate, out taxFracProcUnit, out taxFracProcCd);
                    this._stockPriceCalculate.CalcTaxExcFromTaxInc(taxationCode, shipmentCnt, out unitPriceExc, ref unitPriceInc, out unitPriceTax, out priceExc, ref priceInc, out priceTax, costFrcProcCd, taxFrac, taxRate, out taxFracProcUnit, out taxFracProcCd);

                    costInc = priceInc;		        // ������z�i�ō��݁j
                    costExc = priceExc;		        // ������z�i�Ŕ����j
                    break;
                case CalculateTax.TaxationCode.TaxNone:
                    //---------------------------------
                    // ��ې�
                    //---------------------------------
                    unitPriceExc = SalesUnitCostTaxExc;	    // �P���i�Ŕ����j
                    priceExc = 0;					        // ���i�i�Ŕ����j

                    //this._salesPriceCalculate.CalcTaxIncFromTaxExc(taxationCode, shipmentCnt, ref unitPriceExc, out unitPriceInc, out unitPriceTax, ref priceExc, out priceInc, out priceTax, costFrcProcCd, taxFrac, taxRate, out taxFracProcUnit, out taxFracProcCd);
                    this._stockPriceCalculate.CalcTaxIncFromTaxExc(taxationCode, shipmentCnt, ref unitPriceExc, out unitPriceInc, out unitPriceTax, ref priceExc, out priceInc, out priceTax, costFrcProcCd, taxRate, taxFrac, out taxFracProcUnit, out taxFracProcCd);

                    costInc = priceExc;		// ������z�i�ō��݁j
                    costExc = priceExc;		// ������z�i�ō��݁j
                    break;
            }

            if (taxationCode == (int)CalculateTax.TaxationCode.TaxInc) // �ېŋ敪 // �����͑��z�\���敪�ɂ��Ȃ�
            {
                costDisplay = costInc;
            }
            else
            {
                costDisplay = costExc;
            }

            return true;
        }

        # region ���㖾�ׂ̐ݒ�
        /// <summary>
        /// ���㖾�ׂ̐ݒ�
        /// </summary>
        /// <param name="jnl">����MJNL�N���X</param>
        /// <param name="tempSalesSlipNum">����`�[�ԍ��i���j</param>
        /// <param name="tempSalesSlipDtlNum">���㖾�גʔԁi���j</param>
        /// <param name="prtSalesDetail">(����p)UOE���㖾�׃N���X</param>
        /// <param name="message">�G���[���b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        private int WriteDtTblSalesDetail(OrderSndRcvJnl jnl, string tempSalesSlipNum, Int64 tempSalesSlipDtlNum, string partySaleSlipNum, PrtSalesDetail prtSalesDetail, out string message)
        {
            //�ϐ��̏�����
            int status = (int)EnumUoeConst.Status.ct_NORMAL;
            message = "";

            try
            {
                //------------------------------------------------------
                // UOE������}�X�^�̎擾
                //------------------------------------------------------
                #region UOE������}�X�^�̎擾
                UOESupplier uOESupplier = _uoeSndRcvJnlAcs.SearchUOESupplier(jnl.UOESupplierCd);
                if (uOESupplier == null)
                {
                    message = "UOE������}�X�^�̓ǂݍ��݂Ɏ��s���܂����B";
                    return (-1);
                }
                #endregion

                //------------------------------------------------------
                // �󒍖��ׂ̎擾
                //------------------------------------------------------
                #region �󒍖��ׂ̎擾
                //�󒍃f�[�^�̎擾
	            Int32 acptAnOdrStatus = 20;
                SalesSlipWork salesSlipWork = _uoeSndRcvJnlAcs.ReadAcptSlipDataTable(acptAnOdrStatus, jnl.SalesSlipNum);

	            //�󒍖��ׂ̎擾
	            SalesDetailWork salesDetailWork = _uoeSndRcvJnlAcs.ReadSalesDetailDataTable(acptAnOdrStatus, jnl.SalesSlipDtlNum);
                #endregion

                //------------------------------------------------------
                // ���㖾�ׂ̐ݒ�
                //------------------------------------------------------
                #region ���㖾�ׂ̐ݒ�
                    
                //------------------------------------------------------
                // �����[�g���ڂ̐ݒ�
                //------------------------------------------------------
                #region �����[�g���ڂ̐ݒ�
                //�w�b�_�[���ڏ�����
                salesDetailWork.CreateDateTime = DateTime.MinValue;
                salesDetailWork.UpdateDateTime = DateTime.MinValue;
                salesDetailWork.FileHeaderGuid = Guid.Empty;
  
                salesDetailWork.UpdEmployeeCode = "";
                salesDetailWork.UpdAssemblyId1 = "";
                salesDetailWork.UpdAssemblyId2 = "";
                salesDetailWork.LogicalDeleteCode = 0;

                //�o�א�
                salesDetailWork.ShipmentCnt = (double)prtSalesDetail.prtShipmentCnt;

                //�󒍐���
                salesDetailWork.AcceptAnOrderCnt = prtSalesDetail.prtAcceptAnOrderCnt;

                //�󒍒�����
                salesDetailWork.AcptAnOdrAdjustCnt = 0;

                //�󒍎c��
                salesDetailWork.AcptAnOdrRemainCnt =  salesDetailWork.AcceptAnOrderCnt
                                                    + salesDetailWork.AcptAnOdrAdjustCnt
                                                    - salesDetailWork.ShipmentCnt;
                //�󒍃X�e�[�^�X�i���j
                salesDetailWork.AcptAnOdrStatusSrc = salesDetailWork.AcptAnOdrStatus;

                //���㖾�גʔԁi���j
                salesDetailWork.SalesSlipDtlNumSrc = salesDetailWork.SalesSlipDtlNum;

                //�d���`���i�����j
                salesDetailWork.SupplierFormalSync = 0;
                
                //�d�����גʔԁi�����j
                salesDetailWork.StockSlipDtlNumSync = 0;

                //���׊֘A�t��GUID
                if (this._uoeSndRcvCtlInitAcs.GetSalesTtlSt().SalesStockDiv != 0)
                {
                    salesDetailWork.DtlRelationGuid = SetGuidSalesStock(jnl.OnlineNo, jnl.OnlineRowNo, partySaleSlipNum, prtSalesDetail.detailCd);
                }
                else
                {
                    salesDetailWork.DtlRelationGuid = Guid.NewGuid();
                }

                salesDetailWork.AcptAnOdrStatus = 30;           //�󒍃X�e�[�^�X
                salesDetailWork.SalesSlipNum = String.Empty;    //����`�[�ԍ�
                salesDetailWork.SalesRowNo = 0;                 //����s�ԍ�
                salesDetailWork.SalesRowDerivNo = 0;            //����s�ԍ��}��
                salesDetailWork.SalesSlipDtlNum = 0;            //���㖾�גʔ�
                //add 2011/07/28
                CustomerInfo customerInfo;
                status = this._customerInfoAcs.ReadStaticMemoryData(out customerInfo, this._enterpriseCode, salesSlipWork.CustomerCode);
                if (status != (int)EnumUoeConst.Status.ct_NORMAL)
                {
                    status = this._customerInfoAcs.ReadDBData(this._enterpriseCode, salesSlipWork.CustomerCode, out customerInfo);
                }
                if (status == (int)EnumUoeConst.Status.ct_NORMAL)
                {
                    // PCC�A�g�L��
                    if (customerInfo.OnlineKindDiv != 0)
                    {
                        salesDetailWork.AutoAnswerDivSCM = 1;           //�����񓚋敪(SCM) 
                    }
                    else
                    {
                        salesDetailWork.AutoAnswerDivSCM = 0;           //�ʏ�
                    }
                }
                //add 2011/07/28
                #endregion

                //-----------------------------------------------------------
                // ������t
                //-----------------------------------------------------------
                #region ������t
                //UOE���Аݒ�Ͻ��̌v����t�敪:�V�X�e�����t
                if (_uoeSndRcvJnlAcs.uOESetting.AddUpADateDiv == (int)EnumUoeConst.ctAddUpADateDiv.ct_System)
                {
                    salesDetailWork.SalesDate = DateTime.Now;
                }
                //UOE���Аݒ�Ͻ��̌v����t�敪:������t
                else
                {
                    salesDetailWork.SalesDate = jnl.SalesDate;
                }

                // --------- ADD 杍^ 2013/12/16 -------------- >>>>>>>
                //�d�������Őŗ�
                salesSlipWork.ConsTaxRate = this._uOEOrderDtlAcs.GetTaxRate(salesDetailWork.SalesDate);
                // --------- ADD 杍^ 2013/12/16 -------------- <<<<<<<

                //������R�[�h�ɂĔ��㌎���y�є�������̒����`�F�b�N����
                //��������̒����擾����
                if ((salesSlipWork.ResultsAddUpSecCd.Trim() != "") && (salesSlipWork.ClaimCode != 0))
                {
                    if (_totalDayCalculator.CheckDmdC(salesSlipWork.ResultsAddUpSecCd, salesSlipWork.ClaimCode, salesDetailWork.SalesDate) != false)
                    {
                        DateTime prevTotalDay = DateTime.MinValue;
                        DateTime currentTotalDay = DateTime.MinValue;

                        if (_totalDayCalculator.GetTotalDayDmdC(salesSlipWork.ResultsAddUpSecCd, salesSlipWork.ClaimCode, out prevTotalDay, out currentTotalDay) == 0)
                        {
                            DateTime setDateTime = prevTotalDay.AddDays(1);
                            salesDetailWork.SalesDate = setDateTime;
                        }
                    }

                    //���㌎���̒����擾����
                    if (_totalDayCalculator.CheckMonthlyAccRec(salesSlipWork.ResultsAddUpSecCd, salesSlipWork.ClaimCode, salesDetailWork.SalesDate) != false)
                    {
                        DateTime prevTotalDay = DateTime.MinValue;
                        DateTime currentTotalDay = DateTime.MinValue;

                        if (_totalDayCalculator.GetTotalDayMonthlyAccRec(salesSlipWork.ResultsAddUpSecCd, salesSlipWork.ClaimCode, out prevTotalDay, out currentTotalDay) == 0)
                        {
                            DateTime setDateTime = prevTotalDay.AddDays(1);
                            salesDetailWork.SalesDate = setDateTime;
                        }
                    }
                }
                #endregion

                //-----------------------------------------------------------
                // �艿�̎Z�o
                //-----------------------------------------------------------
                #region �艿�̎Z�o
                double dstPrice = 0;
                double srcPrice = salesDetailWork.ListPriceTaxExcFl;
                switch (uOESupplier.ListPriceUseDiv)
                {
                    //0:������
                    case (int)EnumUoeConst.ctListPriceUseDiv.ct_Hight:
                        dstPrice = jnl.AnswerListPrice <= srcPrice ? srcPrice : jnl.AnswerListPrice;
                        break;
                    //1:���͗D��
                    case (int)EnumUoeConst.ctListPriceUseDiv.ct_Input:
                        dstPrice = srcPrice;
                        break;
                    //2:�I�����C���D��
                    default:
                        dstPrice = jnl.AnswerListPrice;
                        break;
                }

                //����MJNL��̒艿���̗p
                if (dstPrice != srcPrice)
                {
                    SalesDetailRowListPriceSetting(ref salesDetailWork, salesSlipWork, SalesUnitPriceInputType.SalesUnitPrice, dstPrice);

                    //�N���A����
                    salesDetailWork.RateSectPriceUnPrc = string.Empty;
                    salesDetailWork.RateDivLPrice = string.Empty;
                    salesDetailWork.UnPrcCalcCdLPrice = 0;
                    salesDetailWork.PriceCdLPrice = 0;
                    salesDetailWork.StdUnPrcLPrice = 0;
                    //salesDetailWork.FracProcUnitLPrice = 0;
                    //salesDetailWork.FracProcLPrice = 0;
                }
                #endregion

                //-----------------------------------------------------------
                // �����̎Z�o
                //-----------------------------------------------------------
                #region �����̎Z�o
                // -- UPD 2011/12/02 ------------------------>>>>>
                //if (jnl.AnswerSalesUnitCost != 0)
                if (jnl.AnswerSalesUnitCost != 0 || salesDetailWork.ShipmentCnt == 0)
                // -- UPD 2011/12/02 ------------------------<<<<<
                {
                    //�����P��
                    salesDetailWork.SalesUnitCost = jnl.AnswerSalesUnitCost;

                    //������
                    salesDetailWork.CostRate = 0;

                    //����
                    CalculationCost(ref salesDetailWork, salesSlipWork);

                    //�d���P���ύX�敪
                    if (salesDetailWork.BfUnitCost != jnl.AnswerSalesUnitCost)
                    {
                        salesDetailWork.SalesUnitCostChngDiv = 1;   //1:�ύX����
                    }

                    //�N���A����
                    salesDetailWork.RateSectCstUnPrc = string.Empty;
                    salesDetailWork.RateDivUnCst = string.Empty;
                    salesDetailWork.UnPrcCalcCdUnCst = 0;
                    salesDetailWork.PriceCdUnCst = 0;
                    salesDetailWork.StdUnPrcUnCst = 0;
                    //salesDetailWork.FracProcUnitUnCst = 0;
                    //salesDetailWork.FracProcUnCst = 0;
                }  
                #endregion

                //-----------------------------------------------------------
                // �����̎Z�o
                //-----------------------------------------------------------
                #region �����̎Z�o
                if ((dstPrice != srcPrice) && (salesDetailWork.SalesRate != 0))
                {
                    SalesDetailRowSalesUnitPriceSetting(ref salesDetailWork, salesSlipWork, SalesUnitPriceInputType.SalesUnitPrice, dstPrice);

                    SalesDetailRowSalesUnitPriceSettingbyRate(ref salesDetailWork, salesSlipWork, salesDetailWork.SalesRate, true);

                    //�N���A����
                    salesDetailWork.RateSectSalUnPrc = string.Empty;
                    salesDetailWork.RateDivSalUnPrc = string.Empty;
                    salesDetailWork.UnPrcCalcCdSalUnPrc = 0;
                    salesDetailWork.PriceCdSalUnPrc = 0;
                    salesDetailWork.StdUnPrcSalUnPrc = 0;
                    //salesDetailWork.FracProcUnitSalUnPrc = 0;
                    //salesDetailWork.FracProcSalUnPrc = 0;
                }
                #endregion

                //-----------------------------------------------------------
                // ������z�̎Z�o
                //-----------------------------------------------------------
                #region ������z�̎Z�o
                //������z�i�Ŕ����j
                salesDetailWork.SalesMoneyTaxExc = (long)(salesDetailWork.SalesUnPrcTaxExcFl * salesDetailWork.ShipmentCnt);

                // ������z�Čv�Z
                long salesMoneyTaxExc;
                long salesMoneyTaxInc;
                long salesMoneyDisplay;
                int fractionProcCd;
                this.CalculationSalesMoney(salesSlipWork, salesDetailWork, out salesMoneyTaxInc, out salesMoneyTaxExc, out salesMoneyDisplay, out fractionProcCd);

                //������z�i�Ŕ����j
                salesDetailWork.SalesMoneyTaxExc = salesMoneyTaxExc;

                //������z�i�ō��݁j
                salesDetailWork.SalesMoneyTaxInc = salesMoneyTaxInc;

                //������z����Ŋz
                salesDetailWork.SalesPriceConsTax = salesMoneyTaxInc - salesMoneyTaxExc;
                #endregion

                //-----------------------------------------------------------
                // ����i�Ԃ̎Z�o
                //-----------------------------------------------------------
                #region ����i�Ԃ̎Z�o
                if ((uOESupplier.PartsNoPrtCd == (int)EnumUoeConst.ctSubstPartsNoDiv.ct_SubstParts)
                && (jnl.SubstPartsNo.Trim() != ""))
                {
                    salesDetailWork.PrtGoodsNo = jnl.SubstPartsNo;  //����p�i��

                    MakerUMnt makerUMnt = null;
                    status = this._uoeSndRcvCtlInitAcs.GetMakerInf(jnl.AnswerMakerCd, out makerUMnt);
                    if (status == 0)
                    {
                        salesDetailWork.PrtMakerCode = makerUMnt.GoodsMakerCd;    //����p���[�J�[�R�[�h
                        salesDetailWork.PrtMakerName = makerUMnt.MakerKanaName;   //����p���[�J�[����
                    }
                    else
                    {
                        salesDetailWork.PrtMakerCode = 0;    //����p���[�J�[�R�[�h
                        salesDetailWork.PrtMakerName = "";   //����p���[�J�[����
                    }
                }
                //�����i�ԍ̗p
                else
                {
                    salesDetailWork.PrtGoodsNo = salesDetailWork.GoodsNo;       //����p�i��
                    salesDetailWork.PrtMakerCode = salesDetailWork.GoodsMakerCd;//����p���[�J�[�R�[�h
                    salesDetailWork.PrtMakerName = salesDetailWork.MakerName;   //����p���[�J�[����
                }
                #endregion

                //-----------------------------------------------------------
                // �i�Ԃ̎Z�o
                //-----------------------------------------------------------
                #region �i�Ԃ̎Z�o
                //��֕i�ԍ̗p
                if((uOESupplier.SubstPartsNoDiv == (int)EnumUoeConst.ctSubstPartsNoDiv.ct_SubstParts)
                && (jnl.SubstPartsNo.Trim() != ""))
                {
                    salesDetailWork.GoodsNo = jnl.SubstPartsNo;     //�i��
                    salesDetailWork.GoodsMakerCd = jnl.AnswerMakerCd;	// �񓚃��[�J�[�R�[�h

                    MakerUMnt makerUMnt = null;
                    status = this._uoeSndRcvCtlInitAcs.GetMakerInf(jnl.AnswerMakerCd, out makerUMnt);
                    if (status == 0)
                    {
                        salesDetailWork.MakerName = makerUMnt.MakerName;          //���[�J�[����
                        salesDetailWork.MakerKanaName = makerUMnt.MakerKanaName;  //���[�J�[�J�i����
                    }
                    else
                    {
                        salesDetailWork.MakerName = "";      //���[�J�[����
                        salesDetailWork.MakerKanaName = "";  //���[�J�[�J�i����
                    }
                }
                #endregion

                //-----------------------------------------------------------
                // �i���̎Z�o
                //-----------------------------------------------------------
                #region �i��
                if ((salesDetailWork.GoodsName.Trim() == "*") && (jnl.AnswerPartsName.Trim() != ""))
                {
                    salesDetailWork.GoodsName = jnl.AnswerPartsName;
                    //---ADD xupz 2014/09/02 Redmine#43365 UOE���M���� �i���J�i�ɑ΂��ĉ񓚌��ʂ̕i�����Z�b�g����Ȃ���---->>>>>
                    string goodsNameKana = GetKanaString(jnl.AnswerPartsName);
                    // �K(1����)�˶�(2����)�̂悤�ȕϊ�������̂ŁA�������`�F�b�N����B
                    // �i��MAX����40
                    if (goodsNameKana.Length > 40)
                    {
                        goodsNameKana = goodsNameKana.Substring(0, 40);
                    }
                    salesDetailWork.GoodsNameKana = goodsNameKana;
                    //---ADD xupz 2014/09/02 Redmine#43365 UOE���M���� �i���J�i�ɑ΂��ĉ񓚌��ʂ̕i�����Z�b�g����Ȃ���----<<<<<
                }

                // --- ADD chenw 2013/03/07 Redmine#34989 ------------>>>>>
                //-----------------------------------------------------------
                // �I�[�v�����i�敪
                //-----------------------------------------------------------
                if (OPENFLAG.Equals(jnl.LineErrorMassage.Trim()))
                {
                    salesDetailWork.OpenPriceDiv = 1;
                }
                // --- ADD chenw 2013/03/07 Redmine#34989 ------------<<<<<
                #endregion
                #endregion

                //------------------------------------------------------
                // ���㖾�ׂ̒ǉ�����
                //------------------------------------------------------
                #region ���㖾�ׂ̒ǉ�����
                status = _uoeSndRcvJnlAcs.InsertSalesDetailDataTable(salesDetailWork, tempSalesSlipNum, tempSalesSlipDtlNum, prtSalesDetail, out message);
                if (status != (int)EnumUoeConst.Status.ct_NORMAL)
                {
                    return (status);
                }
                #endregion

            }
            catch (Exception ex)
            {
                status = -1;
                message = ex.Message;
            }
            return (status);
        }
        #endregion

        //---ADD xupz 2014/09/02 Redmine#43365 UOE���M���� �i���J�i�ɑ΂��ĉ񓚌��ʂ̕i�����Z�b�g����Ȃ���---->>>>>
        #region �S�p�˔��p�ϊ�
        /// <summary>
        /// �S�p�˔��p�ϊ�
        /// </summary>
        /// <param name="orgString"></param>
        /// <returns></returns>
        private string GetKanaString(string orgString)
        {
            // �S�p�˔��p�ϊ��i�r���Ɋ܂܂��ϊ��ł��Ȃ������͂��̂܂܁j
            return Microsoft.VisualBasic.Strings.StrConv(orgString, Microsoft.VisualBasic.VbStrConv.Narrow, 0);
        }
        #endregion
        //---ADD xupz 2014/09/02 Redmine#43365 UOE���M���� �i���J�i�ɑ΂��ĉ񓚌��ʂ̕i�����Z�b�g����Ȃ���----<<<<<

        # region �`�[���Z
        /// <summary>
        /// �`�[���Z
        /// </summary>
        /// <param name="jnl">����MJNL</param>
        /// <param name="tempSalesSlipDtlNum">���㖾�גʔԁi���j</param>
        /// <param name="message">���b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        private int slipOutPutAddCalculate(OrderSndRcvJnl jnl, ref Int64 tempSalesSlipDtlNum, out string message)
        {
            //�ϐ��̏�����
            int status = (int)EnumUoeConst.Status.ct_NORMAL;
            message = "";

            try
            {
                //------------------------------------------------------
                // �j�d�x���ڒl�̎Z�o
                //------------------------------------------------------
                # region �j�d�x���ڒl�̎Z�o
                //����`�[�ԍ��i���j�� <jnl>����`�[�ԍ�
                string tempSalesSlipNum = jnl.SalesSlipNum;

                //�����`�[�ԍ�
                string partySaleSlipNum = jnl.UOESectionSlipNo;
                #endregion

                //------------------------------------------------------
                // ����f�[�^��(�ǉ�����)�̎Z�o
                //------------------------------------------------------
                # region ����f�[�^��(�ǉ�����)�̎Z�o
                //UOE�`�[���
                Int32 slipCd = (Int32)UoeSales.ctSlipCd.ct_Section; //0:�m�F�`�[
                #endregion

                //------------------------------------------------------
                // ���㖾�ו�(�ǉ�����)�̎Z�o
                //------------------------------------------------------
                # region ���㖾�ו�(�ǉ�����)�̎Z�o
                //BO�o�ɐ����v
                int bOShipmentCnt = GetBOShipmentCnt(jnl);

                PrtSalesDetail prtSalesDetail = new PrtSalesDetail();

                //(����p)��M����
                prtSalesDetail.prtReceiveTime = jnl.ReceiveTime;

                //(����p)BO�敪
                prtSalesDetail.prtBoCode = jnl.BoCode;

                //(����p)UOE�[�i�敪
                prtSalesDetail.prtUOEDeliGoodsDiv = jnl.UOEDeliGoodsDiv;

                // (����p)�[�i�敪����
                prtSalesDetail.prtDeliveredGoodsDivNm = jnl.DeliveredGoodsDivNm;

                // (����p)�t�H���[�[�i�敪
                prtSalesDetail.prtFollowDeliGoodsDiv = jnl.FollowDeliGoodsDiv;

                // (����p)�t�H���[�[�i�敪����
                prtSalesDetail.prtFollowDeliGoodsDivNm = jnl.FollowDeliGoodsDivNm;

                //(����p)�󒍐�
                prtSalesDetail.prtAcceptAnOrderCnt = jnl.AcceptAnOrderCnt;

                //(����p)���_�o�ɐ�
                prtSalesDetail.prtUOESectOutGoodsCnt = jnl.UOESectOutGoodsCnt;

                //(����p)BO�o�ɐ�
                prtSalesDetail.prtBOShipmentCnt = bOShipmentCnt;

                //(����p)�o�ɐ�
                prtSalesDetail.prtShipmentCnt = jnl.UOESectOutGoodsCnt + bOShipmentCnt;

                //���׎��
                prtSalesDetail.detailCd = prtSalesDetail.prtShipmentCnt == 0 ? (int)PrtSalesDetail.ctDetailCd.ct_Zero : (int)PrtSalesDetail.ctDetailCd.ct_Normal;
                #endregion

                //------------------------------------------------------
                // ���㖾�ׂ̐ݒ�
                //------------------------------------------------------
                # region ���㖾�ׂ̐ݒ�
                //���㖾�ׂ̍X�V����
                status = WriteDtTblSalesDetail(
                                jnl,                //����MJNL�N���X
                                tempSalesSlipNum,   //����`�[�ԍ��i���j
                                tempSalesSlipDtlNum,//���㖾�גʔԁi���j
                                partySaleSlipNum,   //�����`�[�ԍ�
                                prtSalesDetail,     //(����p)UOE���㖾�׃N���X
                                out message);

                if(status != (int)EnumUoeConst.Status.ct_NORMAL)
                {
                    return(status);
                }
                #endregion

                //------------------------------------------------------
                // ����f�[�^�̐ݒ�
                //------------------------------------------------------
                # region ����f�[�^�̐ݒ�
                //����f�[�^�̍X�V����
                status = WriteDtTblSalesSlip(
                                jnl,                //����MJNL�N���X
                                tempSalesSlipNum,   //����`�[�ԍ��i���j
                                prtSalesDetail.prtShipmentCnt,        //�o�ɐ����v
                                slipCd,             //UOE�`�[���
                                out message);
                if(status != (int)EnumUoeConst.Status.ct_NORMAL)
                {
                    return(status);
                }
                #endregion

                //���㖾�גʔԁi���j�̃C���N�������g
                tempSalesSlipDtlNum++;
            }
            catch (Exception ex)
            {
                status = -1;
                message = ex.Message;
            }
            return (status);
        }
        #endregion

        # region �t�H���[(���Z)
        /// <summary>
        /// �t�H���[(���Z)
        /// </summary>
        /// <param name="jnl">����MJNL</param>
        /// <param name="tempSalesSlipDtlNum">���㖾�גʔԁi���j</param>
        /// <param name="message">���b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        private int salesSlipAddCalculate(OrderSndRcvJnl jnl, ref Int64 tempSalesSlipDtlNum, out string message)
        {
            //�ϐ��̏�����
            int status = (int)EnumUoeConst.Status.ct_NORMAL;
            message = "";

            try
            {
                //BO�o�ɐ����v
                int bOShipmentCnt = GetBOShipmentCnt(jnl);

                //�󒍐�
                double acceptAnOrderCnt = jnl.AcceptAnOrderCnt;

                //�m�F�`�[�E�t�H���[���Z�E�[���`�[
                for(int i=0; i<3; i++)
                {
                    # region �ϐ��̏�����
                    //�ϐ��̏�����
                    string tempSalesSlipNum = "";   //����`�[�ԍ��i���j
                    string partySaleSlipNum = "";   //�����`�[�ԍ�
                    Int32 slipCd = 0;               //UOE�`�[���

                    PrtSalesDetail prtSalesDetail = new PrtSalesDetail();
                    //(����p)��M����
                    prtSalesDetail.prtReceiveTime = jnl.ReceiveTime;

                    //(����p)BO�敪
                    prtSalesDetail.prtBoCode = jnl.BoCode;

                    //(����p)UOE�[�i�敪
                    prtSalesDetail.prtUOEDeliGoodsDiv = jnl.UOEDeliGoodsDiv;

                    // (����p)�[�i�敪����
                    prtSalesDetail.prtDeliveredGoodsDivNm = jnl.DeliveredGoodsDivNm;

                    // (����p)�t�H���[�[�i�敪
                    prtSalesDetail.prtFollowDeliGoodsDiv = jnl.FollowDeliGoodsDiv;

                    // (����p)�t�H���[�[�i�敪����
                    prtSalesDetail.prtFollowDeliGoodsDivNm = jnl.FollowDeliGoodsDivNm;
                    #endregion

                    switch(i)
                    {
                        //------------------------------------------------------
                        // �m�F�`�[
                        //------------------------------------------------------
                        case 0:
                            # region �m�F�`�[ 
                            //------------------------------------------------------
                            // �j�d�x���ڒl�̎Z�o
                            //------------------------------------------------------
                            # region �j�d�x���ڒl�̎Z�o
                            //����`�[�ԍ��i���j�� <jnl>����`�[�ԍ�
                            tempSalesSlipNum = jnl.SalesSlipNum + (string)UoeSales.ct_strSection;

                            //�����`�[�ԍ�
                            partySaleSlipNum = jnl.UOESectionSlipNo;
                            #endregion

                            //------------------------------------------------------
                            // ����f�[�^��(�ǉ�����)�̎Z�o
                            //------------------------------------------------------
                            # region ����f�[�^��(�ǉ�����)�̎Z�o
                            //UOE�`�[���
                            slipCd = (Int32)UoeSales.ctSlipCd.ct_Section; //0:�m�F�`�[
                            #endregion

                            //------------------------------------------------------
                            // ���㖾�ו�(�ǉ�����)�̎Z�o
                            //------------------------------------------------------
                            # region ���㖾�ו�(�ǉ�����)�̎Z�o
                            //(����p)�󒍐�
                            prtSalesDetail.prtAcceptAnOrderCnt = acceptAnOrderCnt;

                            //(����p)���_�o�ɐ�
                            prtSalesDetail.prtUOESectOutGoodsCnt = jnl.UOESectOutGoodsCnt;

                            //(����p)BO�o�ɐ�
                            prtSalesDetail.prtBOShipmentCnt = bOShipmentCnt;

                            //(����p)�o�ɐ�
                            prtSalesDetail.prtShipmentCnt = jnl.UOESectOutGoodsCnt;

                            //���׎��
                            prtSalesDetail.detailCd = prtSalesDetail.prtShipmentCnt == 0 ? (int)PrtSalesDetail.ctDetailCd.ct_Zero : (int)PrtSalesDetail.ctDetailCd.ct_Normal;
                            #endregion

                            #endregion
                            break;

                        //------------------------------------------------------
                        // �t�H���[���Z
                        //------------------------------------------------------
                        case 1:
                            # region �t�H���[���Z
                            //------------------------------------------------------
                            // �t�H���[���Z�̖��쐬����
                            //------------------------------------------------------
                            # region �t�H���[���Z�̖��쐬����
                            if (bOShipmentCnt == 0)
                            {
                                continue;
                            }
                            #endregion

                            //------------------------------------------------------
                            // �j�d�x���ڒl�̎Z�o
                            //------------------------------------------------------
                            # region �j�d�x���ڒl�̎Z�o
                            //����`�[�ԍ��i���j�� <jnl>����`�[�ԍ�
                            tempSalesSlipNum = jnl.SalesSlipNum + (string)UoeSales.ct_strBO1;

                            //�����`�[�ԍ�
                            partySaleSlipNum = jnl.BOSlipNo1;
                            #endregion

                            //------------------------------------------------------
                            // ����f�[�^��(�ǉ�����)�̎Z�o
                            //------------------------------------------------------
                            # region ����f�[�^��(�ǉ�����)�̎Z�o
                            //UOE�`�[���
                            slipCd = (Int32)UoeSales.ctSlipCd.ct_BO1; //1:BO1�`�[
                            #endregion

                            //------------------------------------------------------
                            // ���㖾�ו�(�ǉ�����)�̎Z�o
                            //------------------------------------------------------
                            # region ���㖾�ו�(�ǉ�����)�̎Z�o
                            //(����p)�󒍐�
                            prtSalesDetail.prtAcceptAnOrderCnt = acceptAnOrderCnt;

                            //(����p)���_�o�ɐ�
                            prtSalesDetail.prtUOESectOutGoodsCnt = jnl.UOESectOutGoodsCnt;

                            //(����p)BO�o�ɐ�
                            prtSalesDetail.prtBOShipmentCnt = bOShipmentCnt;

                            //(����p)�o�ɐ�
                            prtSalesDetail.prtShipmentCnt = bOShipmentCnt;

                            //���׎��
                            prtSalesDetail.detailCd = prtSalesDetail.prtShipmentCnt == 0 ? (int)PrtSalesDetail.ctDetailCd.ct_Zero: (int)PrtSalesDetail.ctDetailCd.ct_Normal;
                            #endregion
                            #endregion
                            break;

                        //------------------------------------------------------
                        // �[���`�[
                        //------------------------------------------------------
                        case 2:
                            # region �[���`�[
                            //------------------------------------------------------
                            // �[���`�[�̖��쐬����
                            //------------------------------------------------------
                            # region �[���`�[�̖��쐬����
                            if ((CheckZeroSlip() != true)
                            || (bOShipmentCnt != 0)
                            || (jnl.UOESectOutGoodsCnt != 0))
                            {
                                continue;
                            }
                            #endregion

                            //------------------------------------------------------
                            // �j�d�x���ڒl�̎Z�o
                            //------------------------------------------------------
                            # region �j�d�x���ڒl�̎Z�o
                            //����`�[�ԍ��i���j�� <jnl>����`�[�ԍ�
                            tempSalesSlipNum = jnl.SalesSlipNum + (string)UoeSales.ct_strZero;

                            //�����`�[�ԍ�
                            partySaleSlipNum = "";
                            #endregion

                            //------------------------------------------------------
                            // ����f�[�^��(�ǉ�����)�̎Z�o
                            //------------------------------------------------------
                            # region ����f�[�^��(�ǉ�����)�̎Z�o
                            //UOE�`�[���
                            slipCd = (Int32)UoeSales.ctSlipCd.ct_Zero; //9:�[���`�[
                            #endregion

                            //------------------------------------------------------
                            // ���㖾�ו�(�ǉ�����)�̎Z�o
                            //------------------------------------------------------
                            # region ���㖾�ו�(�ǉ�����)�̎Z�o
                            //(����p)�󒍐�
                            prtSalesDetail.prtAcceptAnOrderCnt = jnl.AcceptAnOrderCnt;

                            //(����p)���_�o�ɐ�
                            prtSalesDetail.prtUOESectOutGoodsCnt = 0;

                            //(����p)BO�o�ɐ�
                            prtSalesDetail.prtBOShipmentCnt = 0;

                            //(����p)�o�ɐ�
                            prtSalesDetail.prtShipmentCnt = 0;

                            //���׎��
                            prtSalesDetail.detailCd = (int)PrtSalesDetail.ctDetailCd.ct_Zero;
                            #endregion
                            #endregion
                            break;
                    }

                    //------------------------------------------------------
                    // ���㖾�ׂ̐ݒ�
                    //------------------------------------------------------
                    # region ���㖾�ׂ̐ݒ�
                    //���㖾�ׂ̍X�V����
                    status = WriteDtTblSalesDetail(
                                    jnl,                //����MJNL�N���X
                                    tempSalesSlipNum,   //����`�[�ԍ��i���j
                                    tempSalesSlipDtlNum,//���㖾�גʔԁi���j
                                    partySaleSlipNum,   //�����`�[�ԍ�
                                    prtSalesDetail,     //(����p)UOE���㖾�׃N���X
                                    out message);
                    if(status != (int)EnumUoeConst.Status.ct_NORMAL)
                    {
                        return(status);
                    }
                    #endregion

                    //------------------------------------------------------
                    // ����f�[�^�̐ݒ�
                    //------------------------------------------------------
                    # region ����f�[�^�̐ݒ�
                    //����f�[�^�̍X�V����
                    status = WriteDtTblSalesSlip(
                                    jnl,                //����MJNL�N���X
                                    tempSalesSlipNum,   //����`�[�ԍ��i���j
                                    prtSalesDetail.prtShipmentCnt,        //�o�ɐ����v
                                    slipCd,             //UOE�`�[���
                                    out message);
                    if(status != (int)EnumUoeConst.Status.ct_NORMAL)
                    {
                        return(status);
                    }
                    #endregion

                    //���㖾�גʔԁi���j�̃C���N�������g
                    tempSalesSlipDtlNum++;

                    //�󒍐��̎Z�o
                    acceptAnOrderCnt = acceptAnOrderCnt - prtSalesDetail.prtShipmentCnt;
                }
            }
            catch (Exception ex)
            {
                status = -1;
                message = ex.Message;
            }
            return (status);
        }
        #endregion

        # region �t�H���[(�ʁX)
        /// <summary>
        /// �t�H���[(�ʁX)
        /// </summary>
        /// <param name="jnl">����MJNL</param>
        /// <param name="tempSalesSlipDtlNum">���㖾�גʔԁi���j</param>
        /// <param name="message">���b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        private int salesSlipSeparate(OrderSndRcvJnl jnl, ref Int64 tempSalesSlipDtlNum, out string message)
        {
            //�ϐ��̏�����
            int status = (int)EnumUoeConst.Status.ct_NORMAL;
            message = "";

            try
            {
                //BO�o�ɐ����v
                int bOShipmentCnt = GetBOShipmentCnt(jnl);

                //�󒍐�
                double acceptAnOrderCnt = jnl.AcceptAnOrderCnt;

                //�m�F�`�[�E�t�H���[�ʁX�E�[���`�[
                for (int i = 0; i < 7; i++)
                {
                    # region �ϐ��̏�����
                    //�ϐ��̏�����
                    string tempSalesSlipNum = "";   //����`�[�ԍ��i���j
                    string partySaleSlipNum = "";   //�����`�[�ԍ�
                    Int32 slipCd = 0;               //UOE�`�[���

                    PrtSalesDetail prtSalesDetail = new PrtSalesDetail();
                    //(����p)��M����
                    prtSalesDetail.prtReceiveTime = jnl.ReceiveTime;

                    //(����p)BO�敪
                    prtSalesDetail.prtBoCode = jnl.BoCode;

                    //(����p)UOE�[�i�敪
                    prtSalesDetail.prtUOEDeliGoodsDiv = jnl.UOEDeliGoodsDiv;

                    // (����p)�[�i�敪����
                    prtSalesDetail.prtDeliveredGoodsDivNm = jnl.DeliveredGoodsDivNm;

                    // (����p)�t�H���[�[�i�敪
                    prtSalesDetail.prtFollowDeliGoodsDiv = jnl.FollowDeliGoodsDiv;

                    // (����p)�t�H���[�[�i�敪����
                    prtSalesDetail.prtFollowDeliGoodsDivNm = jnl.FollowDeliGoodsDivNm;
                    #endregion

                    switch (i)
                    {
                        //------------------------------------------------------
                        // �m�F�`�[
                        //------------------------------------------------------
                        case 0:
                            # region �m�F�`�[
                            //------------------------------------------------------
                            // �j�d�x���ڒl�̎Z�o
                            //------------------------------------------------------
                            # region �j�d�x���ڒl�̎Z�o
                            //����`�[�ԍ��i���j�� <jnl>����`�[�ԍ�
                            tempSalesSlipNum = jnl.SalesSlipNum + (string)UoeSales.ct_strSection;

                            //�����`�[�ԍ�
                            partySaleSlipNum = jnl.UOESectionSlipNo;
                            #endregion

                            //------------------------------------------------------
                            // ����f�[�^��(�ǉ�����)�̎Z�o
                            //------------------------------------------------------
                            # region ����f�[�^��(�ǉ�����)�̎Z�o
                            //UOE�`�[���
                            slipCd = (Int32)UoeSales.ctSlipCd.ct_Section; //0:�m�F�`�[
                            #endregion

                            //------------------------------------------------------
                            // ���㖾�ו�(�ǉ�����)�̎Z�o
                            //------------------------------------------------------
                            # region ���㖾�ו�(�ǉ�����)�̎Z�o
                            //(����p)�󒍐�
                            prtSalesDetail.prtAcceptAnOrderCnt = acceptAnOrderCnt;

                            //(����p)���_�o�ɐ�
                            prtSalesDetail.prtUOESectOutGoodsCnt = jnl.UOESectOutGoodsCnt;

                            //(����p)BO�o�ɐ�
                            prtSalesDetail.prtBOShipmentCnt = GetBOShipmentCnt(jnl);

                            //(����p)�o�ɐ�
                            prtSalesDetail.prtShipmentCnt = jnl.UOESectOutGoodsCnt;

                            //���׎��
                            prtSalesDetail.detailCd = prtSalesDetail.prtShipmentCnt == 0 ? (int)PrtSalesDetail.ctDetailCd.ct_Zero : (int)PrtSalesDetail.ctDetailCd.ct_Normal;
                            #endregion

                            #endregion
                            break;

                        //------------------------------------------------------
                        // BO1�`�[
                        //------------------------------------------------------
                        case 1:
                            # region BO1�`�[
                            //------------------------------------------------------
                            // BO1�`�[�̖��쐬����
                            //------------------------------------------------------
                            # region BO1�`�[�̖��쐬����
                            if (jnl.BOShipmentCnt1 == 0)
                            {
                                continue;
                            }
                            #endregion

                            //------------------------------------------------------
                            // �j�d�x���ڒl�̎Z�o
                            //------------------------------------------------------
                            # region �j�d�x���ڒl�̎Z�o
                            //����`�[�ԍ��i���j�� <jnl>����`�[�ԍ�
                            tempSalesSlipNum = jnl.SalesSlipNum + (string)UoeSales.ct_strBO1;

                            //�����`�[�ԍ�
                            partySaleSlipNum = jnl.BOSlipNo1;
                            #endregion

                            //------------------------------------------------------
                            // ����f�[�^��(�ǉ�����)�̎Z�o
                            //------------------------------------------------------
                            # region ����f�[�^��(�ǉ�����)�̎Z�o
                            //UOE�`�[���
                            slipCd = (Int32)UoeSales.ctSlipCd.ct_BO1; //1:BO1�`�[
                            #endregion

                            //------------------------------------------------------
                            // ���㖾�ו�(�ǉ�����)�̎Z�o
                            //------------------------------------------------------
                            # region ���㖾�ו�(�ǉ�����)�̎Z�o
                            //(����p)�󒍐�
                            prtSalesDetail.prtAcceptAnOrderCnt = acceptAnOrderCnt;

                            //(����p)���_�o�ɐ�
                            prtSalesDetail.prtUOESectOutGoodsCnt = jnl.UOESectOutGoodsCnt;

                            //(����p)BO�o�ɐ�
                            prtSalesDetail.prtBOShipmentCnt = jnl.BOShipmentCnt1;

                            //(����p)�o�ɐ�
                            prtSalesDetail.prtShipmentCnt = jnl.BOShipmentCnt1;

                            //���׎��
                            prtSalesDetail.detailCd = prtSalesDetail.prtShipmentCnt == 0 ? (int)PrtSalesDetail.ctDetailCd.ct_Zero : (int)PrtSalesDetail.ctDetailCd.ct_Normal;
                            #endregion
                            #endregion
                            break;

                        //------------------------------------------------------
                        // BO2�`�[
                        //------------------------------------------------------
                        case 2:
                            # region BO2�`�[
                            //------------------------------------------------------
                            // BO2�`�[�̖��쐬����
                            //------------------------------------------------------
                            # region BO2�`�[�̖��쐬����
                            if (jnl.BOShipmentCnt2 == 0)
                            {
                                continue;
                            }
                            #endregion

                            //------------------------------------------------------
                            // �j�d�x���ڒl�̎Z�o
                            //------------------------------------------------------
                            # region �j�d�x���ڒl�̎Z�o
                            //����`�[�ԍ��i���j�� <jnl>����`�[�ԍ�
                            tempSalesSlipNum = jnl.SalesSlipNum + (string)UoeSales.ct_strBO2;

                            //�����`�[�ԍ�
                            partySaleSlipNum = jnl.BOSlipNo2;
                            #endregion

                            //------------------------------------------------------
                            // ����f�[�^��(�ǉ�����)�̎Z�o
                            //------------------------------------------------------
                            # region ����f�[�^��(�ǉ�����)�̎Z�o
                            //UOE�`�[���
                            slipCd = (Int32)UoeSales.ctSlipCd.ct_BO2; //2:BO2�`�[
                            #endregion

                            //------------------------------------------------------
                            // ���㖾�ו�(�ǉ�����)�̎Z�o
                            //------------------------------------------------------
                            # region ���㖾�ו�(�ǉ�����)�̎Z�o
                            //(����p)�󒍐�
                            prtSalesDetail.prtAcceptAnOrderCnt = acceptAnOrderCnt;

                            //(����p)���_�o�ɐ�
                            prtSalesDetail.prtUOESectOutGoodsCnt = jnl.UOESectOutGoodsCnt;

                            //(����p)BO�o�ɐ�
                            prtSalesDetail.prtBOShipmentCnt = jnl.BOShipmentCnt2;

                            //(����p)�o�ɐ�
                            prtSalesDetail.prtShipmentCnt = jnl.BOShipmentCnt2;

                            //���׎��
                            prtSalesDetail.detailCd = prtSalesDetail.prtShipmentCnt == 0 ? (int)PrtSalesDetail.ctDetailCd.ct_Zero : (int)PrtSalesDetail.ctDetailCd.ct_Normal;
                            #endregion
                            #endregion
                            break;

                        //------------------------------------------------------
                        // BO3�`�[
                        //------------------------------------------------------
                        case 3:
                            # region BO3�`�[
                            //------------------------------------------------------
                            // BO3�`�[�̖��쐬����
                            //------------------------------------------------------
                            # region BO3�`�[�̖��쐬����
                            if (jnl.BOShipmentCnt3 == 0)
                            {
                                continue;
                            }
                            #endregion

                            //------------------------------------------------------
                            // �j�d�x���ڒl�̎Z�o
                            //------------------------------------------------------
                            # region �j�d�x���ڒl�̎Z�o
                            //����`�[�ԍ��i���j�� <jnl>����`�[�ԍ�
                            tempSalesSlipNum = jnl.SalesSlipNum + (string)UoeSales.ct_strBO3;

                            //�����`�[�ԍ�
                            partySaleSlipNum = jnl.BOSlipNo3;
                            #endregion

                            //------------------------------------------------------
                            // ����f�[�^��(�ǉ�����)�̎Z�o
                            //------------------------------------------------------
                            # region ����f�[�^��(�ǉ�����)�̎Z�o
                            //UOE�`�[���
                            slipCd = (Int32)UoeSales.ctSlipCd.ct_BO3; //3:BO3�`�[
                            #endregion

                            //------------------------------------------------------
                            // ���㖾�ו�(�ǉ�����)�̎Z�o
                            //------------------------------------------------------
                            # region ���㖾�ו�(�ǉ�����)�̎Z�o
                            //(����p)�󒍐�
                            prtSalesDetail.prtAcceptAnOrderCnt = acceptAnOrderCnt;

                            //(����p)���_�o�ɐ�
                            prtSalesDetail.prtUOESectOutGoodsCnt = jnl.UOESectOutGoodsCnt;

                            //(����p)BO�o�ɐ�
                            prtSalesDetail.prtBOShipmentCnt = jnl.BOShipmentCnt3;

                            //(����p)�o�ɐ�
                            prtSalesDetail.prtShipmentCnt = jnl.BOShipmentCnt3;

                            //���׎��
                            prtSalesDetail.detailCd = prtSalesDetail.prtShipmentCnt == 0 ? (int)PrtSalesDetail.ctDetailCd.ct_Zero : (int)PrtSalesDetail.ctDetailCd.ct_Normal;
                            #endregion
                            #endregion
                            break;

                        //------------------------------------------------------
                        // EO�`�[
                        //------------------------------------------------------
                        case 4:
                            # region EO�`�[
                            //------------------------------------------------------
                            // EO�`�[�̖��쐬����
                            //------------------------------------------------------
                            # region EO�`�[�̖��쐬����
                            if (jnl.EOAlwcCount == 0)
                            {
                                continue;
                            }
                            #endregion

                            //------------------------------------------------------
                            // UOE���Аݒ�Ͻ���Ұ��̫۰�v��敪���󒍂̏ꍇ�ɂ͑ΏۊO
                            //------------------------------------------------------
                            # region UOE���Аݒ�Ͻ���Ұ��̫۰�v��敪���󒍂̏ꍇ�ɂ͑ΏۊO
                            if (_uoeSndRcvJnlAcs.uOESetting.MakerFollowAddUpDiv == (int)EnumUoeConst.ctMakerFollowAddUpDiv.ct_Order)
                            {
                                continue;
                            }
                            #endregion

                            //------------------------------------------------------
                            // �j�d�x���ڒl�̎Z�o
                            //------------------------------------------------------
                            # region �j�d�x���ڒl�̎Z�o
                            //����`�[�ԍ��i���j�� <jnl>����`�[�ԍ�
                            tempSalesSlipNum = jnl.SalesSlipNum + (string)UoeSales.ct_strEO;

                            //�����`�[�ԍ�
                            partySaleSlipNum = "";
                            #endregion

                            //------------------------------------------------------
                            // ����f�[�^��(�ǉ�����)�̎Z�o
                            //------------------------------------------------------
                            # region ����f�[�^��(�ǉ�����)�̎Z�o
                            //UOE�`�[���
                            slipCd = (Int32)UoeSales.ctSlipCd.ct_EO; //4:EO�`�[
                            #endregion

                            //------------------------------------------------------
                            // ���㖾�ו�(�ǉ�����)�̎Z�o
                            //------------------------------------------------------
                            # region ���㖾�ו�(�ǉ�����)�̎Z�o
                            //(����p)�󒍐�
                            prtSalesDetail.prtAcceptAnOrderCnt = acceptAnOrderCnt;

                            //(����p)���_�o�ɐ�
                            prtSalesDetail.prtUOESectOutGoodsCnt = jnl.UOESectOutGoodsCnt;

                            //(����p)BO�o�ɐ�
                            prtSalesDetail.prtBOShipmentCnt = jnl.EOAlwcCount;

                            //(����p)�o�ɐ�
                            prtSalesDetail.prtShipmentCnt = jnl.EOAlwcCount;

                            //���׎��
                            prtSalesDetail.detailCd = prtSalesDetail.prtShipmentCnt == 0 ? (int)PrtSalesDetail.ctDetailCd.ct_Zero : (int)PrtSalesDetail.ctDetailCd.ct_Normal;
                            #endregion
                            #endregion
                            break;

                        //------------------------------------------------------
                        // ���[�J�[�t�H���[�`�[
                        //------------------------------------------------------
                        case 5:
                            # region ���[�J�[�t�H���[�`�[
                            //------------------------------------------------------
                            // ���[�J�[�t�H���[�`�[�̖��쐬����
                            //------------------------------------------------------
                            # region ���[�J�[�t�H���[�`�[�̖��쐬����
                            if (jnl.MakerFollowCnt == 0)
                            {
                                continue;
                            }
                            #endregion

                            //------------------------------------------------------
                            // UOE���Аݒ�Ͻ���Ұ��̫۰�v��敪���󒍂̏ꍇ�ɂ͑ΏۊO
                            //------------------------------------------------------
                            # region UOE���Аݒ�Ͻ���Ұ��̫۰�v��敪���󒍂̏ꍇ�ɂ͑ΏۊO
                            if (_uoeSndRcvJnlAcs.uOESetting.MakerFollowAddUpDiv == (int)EnumUoeConst.ctMakerFollowAddUpDiv.ct_Order)
                            {
                                continue;
                            }
                            #endregion

                            //------------------------------------------------------
                            // �j�d�x���ڒl�̎Z�o
                            //------------------------------------------------------
                            # region �j�d�x���ڒl�̎Z�o
                            //����`�[�ԍ��i���j�� <jnl>����`�[�ԍ�
                            tempSalesSlipNum = jnl.SalesSlipNum + (string)UoeSales.ct_strMaker;

                            //�����`�[�ԍ�
                            partySaleSlipNum = "";
                            #endregion

                            //------------------------------------------------------
                            // ����f�[�^��(�ǉ�����)�̎Z�o
                            //------------------------------------------------------
                            # region ����f�[�^��(�ǉ�����)�̎Z�o
                            //UOE�`�[���
                            slipCd = (Int32)UoeSales.ctSlipCd.ct_Maker; //5:���[�J�[�t�H���[�`�[
                            #endregion

                            //------------------------------------------------------
                            // ���㖾�ו�(�ǉ�����)�̎Z�o
                            //------------------------------------------------------
                            # region ���㖾�ו�(�ǉ�����)�̎Z�o
                            //(����p)�󒍐�
                            prtSalesDetail.prtAcceptAnOrderCnt = acceptAnOrderCnt;

                            //(����p)���_�o�ɐ�
                            prtSalesDetail.prtUOESectOutGoodsCnt = jnl.UOESectOutGoodsCnt;

                            //(����p)BO�o�ɐ�
                            prtSalesDetail.prtBOShipmentCnt = jnl.MakerFollowCnt;

                            //(����p)�o�ɐ�
                            prtSalesDetail.prtShipmentCnt = jnl.MakerFollowCnt;

                            //���׎��
                            prtSalesDetail.detailCd = prtSalesDetail.prtShipmentCnt == 0 ? (int)PrtSalesDetail.ctDetailCd.ct_Zero : (int)PrtSalesDetail.ctDetailCd.ct_Normal;
                            #endregion
                            #endregion
                            break;

                        //------------------------------------------------------
                        // �[���`�[
                        //------------------------------------------------------
                        case 6:
                            # region �[���`�[
                            //------------------------------------------------------
                            // �[���`�[�̖��쐬����
                            //------------------------------------------------------
                            # region �[���`�[�̖��쐬����
                            if ((CheckZeroSlip() != true)
                            || (bOShipmentCnt != 0)
                            || (jnl.UOESectOutGoodsCnt != 0))
                            {
                                continue;
                            }
                            #endregion

                            //------------------------------------------------------
                            // �j�d�x���ڒl�̎Z�o
                            //------------------------------------------------------
                            # region �j�d�x���ڒl�̎Z�o
                            //����`�[�ԍ��i���j�� <jnl>����`�[�ԍ�
                            tempSalesSlipNum = jnl.SalesSlipNum + (string)UoeSales.ct_strZero;

                            //�����`�[�ԍ�
                            partySaleSlipNum = "";
                            #endregion

                            //------------------------------------------------------
                            // ����f�[�^��(�ǉ�����)�̎Z�o
                            //------------------------------------------------------
                            # region ����f�[�^��(�ǉ�����)�̎Z�o
                            //UOE�`�[���
                            slipCd = (Int32)UoeSales.ctSlipCd.ct_Zero; //9:�[���`�[
                            #endregion

                            //------------------------------------------------------
                            // ���㖾�ו�(�ǉ�����)�̎Z�o
                            //------------------------------------------------------
                            # region ���㖾�ו�(�ǉ�����)�̎Z�o
                            //(����p)�󒍐�
                            prtSalesDetail.prtAcceptAnOrderCnt = jnl.AcceptAnOrderCnt;

                            //(����p)���_�o�ɐ�
                            prtSalesDetail.prtUOESectOutGoodsCnt = 0;

                            //(����p)BO�o�ɐ�
                            prtSalesDetail.prtBOShipmentCnt = 0;

                            //(����p)�o�ɐ�
                            prtSalesDetail.prtShipmentCnt = 0;

                            //���׎��
                            prtSalesDetail.detailCd = (int)PrtSalesDetail.ctDetailCd.ct_Zero;
                            #endregion
                            #endregion
                            break;
                    }

                    //------------------------------------------------------
                    // ���㖾�ׂ̐ݒ�
                    //------------------------------------------------------
                    # region ���㖾�ׂ̐ݒ�
                    //���㖾�ׂ̍X�V����
                    status = WriteDtTblSalesDetail(
                                    jnl,                //����MJNL�N���X
                                    tempSalesSlipNum,   //����`�[�ԍ��i���j
                                    tempSalesSlipDtlNum,//���㖾�גʔԁi���j
                                    partySaleSlipNum,   //�����`�[�ԍ�
                                    prtSalesDetail,     //(����p)UOE���㖾�׃N���X
                                    out message);
                    if (status != (int)EnumUoeConst.Status.ct_NORMAL)
                    {
                        return (status);
                    }
                    #endregion

                    //------------------------------------------------------
                    // ����f�[�^�̐ݒ�
                    //------------------------------------------------------
                    # region ����f�[�^�̐ݒ�
                    //����f�[�^�̍X�V����
                    status = WriteDtTblSalesSlip(
                                    jnl,                //����MJNL�N���X
                                    tempSalesSlipNum,   //����`�[�ԍ��i���j
                                    prtSalesDetail.prtShipmentCnt,        //�o�ɐ����v
                                    slipCd,             //UOE�`�[���
                                    out message);
                    if (status != (int)EnumUoeConst.Status.ct_NORMAL)
                    {
                        return (status);
                    }
                    #endregion

                    //���㖾�גʔԁi���j�̃C���N�������g
                    tempSalesSlipDtlNum++;

                    //�󒍐��̎Z�o
                    acceptAnOrderCnt = acceptAnOrderCnt - prtSalesDetail.prtShipmentCnt;
                }
            }
            catch (Exception ex)
            {
                status = -1;
                message = ex.Message;
            }
            return (status);
        }
        #endregion

        # region ���z���_��p���t�H���[(�ʁX)
        /// <summary>
        /// ���z���_��p���t�H���[(�ʁX)
        /// </summary>
        /// <param name="jnl">����MJNL</param>
        /// <param name="tempSalesSlipDtlNum">���㖾�גʔԁi���j</param>
        /// <param name="message">���b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Update Note: e-Parts�Ŕ�������ۂɁA���[�J�[�t�H���[�̏ꍇ�͑����`�[�ԍ��P�Ɂu-F�v��t�����B</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2015/07/24</br>
        /// </remarks>
        //private int salesSlipSeparateForHonda(OrderSndRcvJnl jnl, ref Int64 tempSalesSlipDtlNum, out string message)// DEL 2015/07/24 ���O For Redmine #46880
        private int salesSlipSeparateForHonda(OrderSndRcvJnl jnl, ref Int64 tempSalesSlipDtlNum, out string message, UOESupplier uOESupplier)// ADD 2015/07/24 ���O For Redmine #46880
        {
            //�ϐ��̏�����
            int status = (int)EnumUoeConst.Status.ct_NORMAL;
            message = "";

            try
            {
                //BO�o�ɐ����v
                int bOShipmentCnt = GetBOShipmentCnt(jnl);

                //�󒍐�
                double acceptAnOrderCnt = jnl.AcceptAnOrderCnt;

                //�m�F�`�[�E�t�H���[�ʁX�E�[���`�[
                for (int i = 0; i < 3; i++)
                {
                    # region �ϐ��̏�����
                    //�ϐ��̏�����
                    string tempSalesSlipNum = "";   //����`�[�ԍ��i���j
                    string partySaleSlipNum = "";   //�����`�[�ԍ�
                    Int32 slipCd = 0;               //UOE�`�[���

                    PrtSalesDetail prtSalesDetail = new PrtSalesDetail();
                    //(����p)��M����
                    prtSalesDetail.prtReceiveTime = jnl.ReceiveTime;

                    //(����p)BO�敪
                    prtSalesDetail.prtBoCode = jnl.BoCode;

                    //(����p)UOE�[�i�敪
                    prtSalesDetail.prtUOEDeliGoodsDiv = jnl.UOEDeliGoodsDiv;

                    // (����p)�[�i�敪����
                    prtSalesDetail.prtDeliveredGoodsDivNm = jnl.DeliveredGoodsDivNm;

                    // (����p)�t�H���[�[�i�敪
                    prtSalesDetail.prtFollowDeliGoodsDiv = jnl.FollowDeliGoodsDiv;

                    // (����p)�t�H���[�[�i�敪����
                    prtSalesDetail.prtFollowDeliGoodsDivNm = jnl.FollowDeliGoodsDivNm;
                    #endregion

                    switch (i)
                    {
                        //------------------------------------------------------
                        // �m�F�`�[
                        //------------------------------------------------------
                        case 0:
                            # region �m�F�`�[
                            //------------------------------------------------------
                            // �j�d�x���ڒl�̎Z�o
                            //------------------------------------------------------
                            # region �j�d�x���ڒl�̎Z�o
                            //����`�[�ԍ��i���j�� <jnl>����`�[�ԍ�
                            tempSalesSlipNum = jnl.SalesSlipNum + (string)UoeSales.ct_strSection;

                            //�����`�[�ԍ�
                            partySaleSlipNum = jnl.UOESectionSlipNo;
                            #endregion

                            //------------------------------------------------------
                            // ����f�[�^��(�ǉ�����)�̎Z�o
                            //------------------------------------------------------
                            # region ����f�[�^��(�ǉ�����)�̎Z�o
                            //UOE�`�[���
                            slipCd = (Int32)UoeSales.ctSlipCd.ct_Section; //0:�m�F�`�[
                            #endregion

                            //------------------------------------------------------
                            // ���㖾�ו�(�ǉ�����)�̎Z�o
                            //------------------------------------------------------
                            # region ���㖾�ו�(�ǉ�����)�̎Z�o
                            //(����p)�󒍐�
                            prtSalesDetail.prtAcceptAnOrderCnt = acceptAnOrderCnt;

                            //(����p)���_�o�ɐ�
                            prtSalesDetail.prtUOESectOutGoodsCnt = jnl.UOESectOutGoodsCnt;

                            //(����p)BO�o�ɐ�
                            prtSalesDetail.prtBOShipmentCnt = GetBOShipmentCnt(jnl);

                            //(����p)�o�ɐ�
                            prtSalesDetail.prtShipmentCnt = jnl.UOESectOutGoodsCnt;

                            //���׎��
                            prtSalesDetail.detailCd = prtSalesDetail.prtShipmentCnt == 0 ? (int)PrtSalesDetail.ctDetailCd.ct_Zero : (int)PrtSalesDetail.ctDetailCd.ct_Normal;
                            #endregion

                            #endregion
                            break;

                        //------------------------------------------------------
                        // BO1-3�`�[
                        //------------------------------------------------------
                        case 1:
                            # region BO1-3�`�[
                            //------------------------------------------------------
                            // BO1�`�[�̖��쐬����
                            //------------------------------------------------------
                            # region BO�`�[�̖��쐬����
                            if (jnl.BOShipmentCnt1 == 0)
                            {
                                continue;
                            }
                            #endregion

                            //------------------------------------------------------
                            // �j�d�x���ڒl�̎Z�o
                            //------------------------------------------------------
                            # region �j�d�x���ڒl�̎Z�o
                            //����`�[�ԍ��i���j�� <jnl>����`�[�ԍ�
                            string slipCdString = GetHondaBoSlipString(jnl.SourceShipment);
                            tempSalesSlipNum = jnl.SalesSlipNum + slipCdString;

                            //�����`�[�ԍ�
                            partySaleSlipNum = jnl.BOSlipNo1;
                            // ADD 2015/07/24 ���O For Redmine #46880---------------------->>>>>
                            // e-Parts�Ŕ�������ۂɁA���[�J�[�t�H���[�̏ꍇ�͑����`�[�ԍ��P�Ɂu-F�v��t�����B
                            if (uOESupplier.CommAssemblyId == (string)EnumUoeConst.ctCommAssemblyId_0502
                                && !string.IsNullOrEmpty(jnl.BOSlipNo1))
                            {
                                partySaleSlipNum = jnl.BOSlipNo1 + "-F";
                            }
                            // ADD 2015/07/24 ���O For Redmine #46880----------------------<<<<<

                            #endregion

                            //------------------------------------------------------
                            // ����f�[�^��(�ǉ�����)�̎Z�o
                            //------------------------------------------------------
                            # region ����f�[�^��(�ǉ�����)�̎Z�o
                            //UOE�`�[���
                            slipCd = GetSlipCdFromBoSlipString(slipCdString);
                            #endregion

                            //------------------------------------------------------
                            // ���㖾�ו�(�ǉ�����)�̎Z�o
                            //------------------------------------------------------
                            # region ���㖾�ו�(�ǉ�����)�̎Z�o
                            //(����p)�󒍐�
                            prtSalesDetail.prtAcceptAnOrderCnt = acceptAnOrderCnt;

                            //(����p)���_�o�ɐ�
                            prtSalesDetail.prtUOESectOutGoodsCnt = jnl.UOESectOutGoodsCnt;

                            //(����p)BO�o�ɐ�
                            prtSalesDetail.prtBOShipmentCnt = jnl.BOShipmentCnt1;

                            //(����p)�o�ɐ�
                            prtSalesDetail.prtShipmentCnt = jnl.BOShipmentCnt1;

                            //���׎��
                            prtSalesDetail.detailCd = prtSalesDetail.prtShipmentCnt == 0 ? (int)PrtSalesDetail.ctDetailCd.ct_Zero : (int)PrtSalesDetail.ctDetailCd.ct_Normal;
                            #endregion
                            #endregion
                            break;

                        //------------------------------------------------------
                        // �[���`�[
                        //------------------------------------------------------
                        case 2:
                            # region �[���`�[
                            //------------------------------------------------------
                            // �[���`�[�̖��쐬����
                            //------------------------------------------------------
                            # region �[���`�[�̖��쐬����
                            if ((CheckZeroSlip() != true)
                            || (bOShipmentCnt != 0)
                            || (jnl.UOESectOutGoodsCnt != 0))
                            {
                                continue;
                            }
                            #endregion

                            //------------------------------------------------------
                            // �j�d�x���ڒl�̎Z�o
                            //------------------------------------------------------
                            # region �j�d�x���ڒl�̎Z�o
                            //����`�[�ԍ��i���j�� <jnl>����`�[�ԍ�
                            tempSalesSlipNum = jnl.SalesSlipNum + (string)UoeSales.ct_strZero;

                            //�����`�[�ԍ�
                            partySaleSlipNum = "";
                            #endregion

                            //------------------------------------------------------
                            // ����f�[�^��(�ǉ�����)�̎Z�o
                            //------------------------------------------------------
                            # region ����f�[�^��(�ǉ�����)�̎Z�o
                            //UOE�`�[���
                            slipCd = (Int32)UoeSales.ctSlipCd.ct_Zero; //9:�[���`�[
                            #endregion

                            //------------------------------------------------------
                            // ���㖾�ו�(�ǉ�����)�̎Z�o
                            //------------------------------------------------------
                            # region ���㖾�ו�(�ǉ�����)�̎Z�o
                            //(����p)�󒍐�
                            prtSalesDetail.prtAcceptAnOrderCnt = jnl.AcceptAnOrderCnt;

                            //(����p)���_�o�ɐ�
                            prtSalesDetail.prtUOESectOutGoodsCnt = 0;

                            //(����p)BO�o�ɐ�
                            prtSalesDetail.prtBOShipmentCnt = 0;

                            //(����p)�o�ɐ�
                            prtSalesDetail.prtShipmentCnt = 0;

                            //���׎��
                            prtSalesDetail.detailCd = (int)PrtSalesDetail.ctDetailCd.ct_Zero;
                            #endregion
                            #endregion
                            break;
                    }

                    //------------------------------------------------------
                    // ���㖾�ׂ̐ݒ�
                    //------------------------------------------------------
                    # region ���㖾�ׂ̐ݒ�
                    //���㖾�ׂ̍X�V����
                    status = WriteDtTblSalesDetail(
                                    jnl,                //����MJNL�N���X
                                    tempSalesSlipNum,   //����`�[�ԍ��i���j
                                    tempSalesSlipDtlNum,//���㖾�גʔԁi���j
                                    partySaleSlipNum,   //�����`�[�ԍ�
                                    prtSalesDetail,     //(����p)UOE���㖾�׃N���X
                                    out message);
                    if (status != (int)EnumUoeConst.Status.ct_NORMAL)
                    {
                        return (status);
                    }
                    #endregion

                    //------------------------------------------------------
                    // ����f�[�^�̐ݒ�
                    //------------------------------------------------------
                    # region ����f�[�^�̐ݒ�
                    //����f�[�^�̍X�V����
                    status = WriteDtTblSalesSlip(
                                    jnl,                //����MJNL�N���X
                                    tempSalesSlipNum,   //����`�[�ԍ��i���j
                                    prtSalesDetail.prtShipmentCnt,        //�o�ɐ����v
                                    slipCd,             //UOE�`�[���
                                    out message);
                    if (status != (int)EnumUoeConst.Status.ct_NORMAL)
                    {
                        return (status);
                    }
                    #endregion

                    //���㖾�גʔԁi���j�̃C���N�������g
                    tempSalesSlipDtlNum++;

                    //�󒍐��̎Z�o
                    acceptAnOrderCnt = acceptAnOrderCnt - prtSalesDetail.prtShipmentCnt;
                }
            }
            catch (Exception ex)
            {
                status = -1;
                message = ex.Message;
            }
            return (status);
        }
        #endregion

        # region (�g�n�m�c�`�p)�a�n�`�[�敪�擾����
        /// <summary>
        /// (�g�n�m�c�`�p)�a�n�`�[�敪�擾����
        /// </summary>
        /// <param name="sourceShipment">�o�׌�</param>
        /// <returns>BO1,BO2,BO3,���o�׌�������</returns>
        private string GetHondaBoSlipString(string sourceShipment)
        {
            string returnString = "";

            //(�����p)�d���f�[�^��Dictionary�ǉ�
            if (_hondaSlipNoDictionary.ContainsKey(sourceShipment) == true)
            {
                returnString = _hondaSlipNoDictionary[sourceShipment];
            }
            else
            {
                switch (_hondaSlipNoDictionary.Count)
                {
                    case 0:
                        returnString = (string)UoeSales.ct_strBO1;
                        break;
                    case 1:
                        returnString = (string)UoeSales.ct_strBO2;
                        break;
                    case 2:
                        returnString = (string)UoeSales.ct_strBO3;
                        break;
                    default:
                        returnString = sourceShipment;
                        break;
                }
                _hondaSlipNoDictionary.Add(sourceShipment, returnString);
            }
            return (returnString);
        }
        #endregion

        # region UOE�`�[��ʕ�����̎擾
        /// <summary>
        /// UOE�`�[��ʕ�����̎擾
        /// </summary>
        /// <param name="cd"></param>
        /// <returns></returns>
        private string GetSlipString(int cd)
        {
            string returnString = "";

            switch (cd)
            {
                case (int)UoeSales.ctSlipCd.ct_Section: //�m�F�`�[
                    returnString = (string)UoeSales.ct_strSection;
                    break;
                case (int)UoeSales.ctSlipCd.ct_BO1:     //BO1�`�[
                    returnString = (string)UoeSales.ct_strBO1;
                    break;
                case (int)UoeSales.ctSlipCd.ct_BO2:     //BO2�`�[
                    returnString = (string)UoeSales.ct_strBO2;
                    break;
                case (int)UoeSales.ctSlipCd.ct_BO3:     //BO3�`�[
                    returnString = (string)UoeSales.ct_strBO3;
                    break;
                case (int)UoeSales.ctSlipCd.ct_EO:      //EO�`�[
                    returnString = (string)UoeSales.ct_strEO;
                    break;
                case (int)UoeSales.ctSlipCd.ct_Maker:   //���[�J�[�t�H���[�`�[
                    returnString = (string)UoeSales.ct_strMaker;
                    break;
                case (int)UoeSales.ctSlipCd.ct_OtherBO: //��BO�`�[
                    returnString = (string)UoeSales.ct_strOtherBO;
                    break;
                case (int)UoeSales.ctSlipCd.ct_Zero:    //�[���`�[
                    returnString = (string)UoeSales.ct_strZero;
                    break;
                default:
                    returnString = "";
                    break;
            }
            return (returnString);
        }
        #endregion

        # region UOE�`�[��ʎ擾
        /// <summary>
        /// UOE�`�[��ʎ擾
        /// </summary>
        /// <param name="slipCdString">BO1,BO2,BO3</param>
        /// <returns>UOE�`�[���</returns>
        private int GetSlipCdFromBoSlipString(string slipCdString)
        {
            int cd = (int)UoeSales.ctSlipCd.ct_Section;

            switch (slipCdString)
            {
                case (string)UoeSales.ct_strSection:
                    cd = (int)UoeSales.ctSlipCd.ct_Section;
                    break;
                case (string)UoeSales.ct_strBO1:
                    cd = (int)UoeSales.ctSlipCd.ct_BO1;
                    break;
                case (string)UoeSales.ct_strBO2:
                    cd = (int)UoeSales.ctSlipCd.ct_BO2;
                    break;
                case (string)UoeSales.ct_strBO3:
                    cd = (int)UoeSales.ctSlipCd.ct_BO3;
                    break;
                case (string)UoeSales.ct_strEO:
                    cd = (int)UoeSales.ctSlipCd.ct_EO;
                    break;
                case (string)UoeSales.ct_strMaker:
                    cd = (int)UoeSales.ctSlipCd.ct_Maker;
                    break;
                case (string)UoeSales.ct_strZero:
                    cd = (int)UoeSales.ctSlipCd.ct_Zero;
                    break;
                default:
                    cd = (int)UoeSales.ctSlipCd.ct_OtherBO;
                    break;
            }
            return (cd);
        }
        #endregion

        # region �`�[�o�͋敪�̃`�F�b�N
        /// <summary>
        /// �[���`�[�`�F�b�N
        /// </summary>
        /// <returns>true:���� false:�Ȃ�</returns>
        private bool CheckZeroSlip()
        {
            return (CheckSlipOutputDivCd(0));
        }

        /// <summary>
        /// �[�����׃`�F�b�N
        /// </summary>
        /// <returns>true:���� false:�Ȃ�</returns>
        private bool CheckZeroDtl()
        {
            return (CheckSlipOutputDivCd(1));
        }
        /// <summary>
        /// ���Z�`�F�b�N
        /// </summary>
        /// <returns>true:���� false:�Ȃ�</returns>
        private bool CheckAddingUp()
        {
            return (CheckSlipOutputDivCd(2));
        }

        /// <summary>
        /// �`�[�o�͋敪�̃`�F�b�N
        /// </summary>
        /// <param name="cd">0:�[���`�[ 1:�[������ 2:���Z</param>
        /// <returns>true:���� false:�Ȃ�</returns>
        private bool CheckSlipOutputDivCd(int cd)
        {
            # region �ϐ��̏�����
            //�ϐ��̏�����
            bool returnBool = true;
            bool zeroSlip = true;
            bool zeroDtl = true;
            bool AddingUp = true;
            #endregion

            # region �`�[�o�͋敪
            //�`�[�o�͋敪
            switch (_uoeSndRcvJnlAcs.uOESetting.SlipOutputDivCd)
            {
                //1:�m�F�`�[�E̫۰�`�[�E��ۓ`�[�L��
                case 1:
                    zeroSlip = true;
                    zeroDtl = true;
                    AddingUp = false;
                    break;
                //2:�m�F�`�[�E̫۰�`�[�L��
                case 2:
                    zeroSlip = false;
                    zeroDtl = true;
                    AddingUp = false;
                    break;
                //3:�m�F�`�[�E̫۰�`�[(���Z�j
                case 3:
                    zeroSlip = false;
                    zeroDtl = true;
                    AddingUp = true;
                    break;
                //4:�m�F�`�[(��ۖ��׈󎚂Ȃ�)�E̫۰�`�[�E��ۓ`�[�L��
                case 4:
                    zeroSlip = true;
                    zeroDtl = false;
                    AddingUp = false;
                    break;
                //5:�m�F�`�[(��ۖ��׈󎚂Ȃ�)�E̫۰�`�[�L��
                case 5:
                    zeroSlip = false;
                    zeroDtl = false;
                    AddingUp = false;
                    break;
                //6:�m�F�`�[(��ۖ��׈󎚂Ȃ�)�E̫۰�`�[�i���Z�j
                case 6:
                    zeroSlip = false;
                    zeroDtl = false;
                    AddingUp = true;
                    break;
            }
            #endregion

            # region �߂�l�̐ݒ�
            //�߂�l�̐ݒ�
            switch (cd)
            {
                //�[���`�[
                case 0:
                    returnBool = zeroSlip;
                    break;
                //�[������
                case 1:
                    returnBool = zeroDtl;
                    break;
                //���Z
                case 2:
                    returnBool = AddingUp;
                    break;
            }
            #endregion

            return (returnBool);
        }
        #endregion

        # region �a�n���v���̎Z�o
        /// <summary>
        /// �a�n���v���̎Z�o
        /// </summary>
        /// <param name="jnl">����M�i�m�k�N���X</param>
        /// <returns>�a�n���v��</returns>
        private int GetBOShipmentCnt(OrderSndRcvJnl jnl)
        {
            int returnCount = 
                  jnl.BOShipmentCnt1
                + jnl.BOShipmentCnt2
                + jnl.BOShipmentCnt3;

            //UOE���Аݒ�Ͻ���Ұ��̫۰�v��敪���󒍂̏ꍇ�ɂ͉��Z���Ȃ�
            if (_uoeSndRcvJnlAcs.uOESetting.MakerFollowAddUpDiv != (int)EnumUoeConst.ctMakerFollowAddUpDiv.ct_Order)
            {
                returnCount = returnCount + jnl.EOAlwcCount + jnl.MakerFollowCnt;
            }

            return (returnCount);
        }
        #endregion

        # region �� �d���֘A�ݒ菈��
        #region �d���f�[�^�̍X�V�ݒ菈��
        /// <summary>
        /// �d���f�[�^�̍X�V�ݒ菈��
        /// </summary>
        /// <param name="message">�G���[���b�Z�[�W</param>
        /// <returns></returns>
        // upd K2012/06/20 >>>
        //private int UpDtStockProc(out string message)
        private int UpDtStockProc(out string message, ref int systemDivCd)
        // upd K2012/06/20 <<<
        {
            //�ϐ��̏�����
            int status = (int)EnumUoeConst.Status.ct_NORMAL;
            message = "";

            try
            {
                //-----------------------------------------------------------
                // �t���O������
                //-----------------------------------------------------------
                #region �t���O������
                //���ݏ������̃I�����C���ԍ�
                int savOnlineNo = 0;

                //���ʓ`�[�ԍ�Dictionary�̃N���A
                _commonSlipNoDictionary.Clear();

                //���ʓ`�[�s�ԍ�
                int commonSlipRowNo = 0;
                #endregion

                //-----------------------------------------------------------
                // ����MJNL�̏����Ώۃ��R�[�h�̍i������
                //-----------------------------------------------------------
                #region ����MJNL�̏����Ώۃ��R�[�h�̍i������
                //����MJNL�̏����Ώۃ��R�[�h�̍i������
                //����MJNL��̑��MFLG��"9:����I��"��ں��ނ������Ώ�
                string filterString = "DataSendCode = '9'";
                string sortString = "OnlineNo ASC, OnlineRowNo ASC";

                DataRow[] rows = OrderTable.Select(filterString, sortString);
                #endregion

                foreach (DataRow dataRow in rows)
                {
                    //-----------------------------------------------------------
                    // �X�V�Ώۂ̃`�F�b�N
                    //-----------------------------------------------------------
                    #region �X�V�Ώۂ̃`�F�b�N
                    //DataRow �� OrderSndRcvJnl�̎擾
                    OrderSndRcvJnl jnl = _uoeSndRcvJnlAcs.CreateOrderJnlFromSchema(dataRow);

                    systemDivCd = jnl.SystemDivCd;  // add K2012/06/20

                    //�V�X�e���敪 0:����� 1:�`�� 2:����
                    //���
                    if ((jnl.SystemDivCd == (int)EnumUoeConst.ctSystemDivCd.ct_Slip)
                    || ((jnl.SystemDivCd == (int)EnumUoeConst.ctSystemDivCd.ct_Input) && (jnl.WarehouseCode == ""))
                    || ((jnl.SystemDivCd == (int)EnumUoeConst.ctSystemDivCd.ct_Search) && (jnl.WarehouseCode == "")))
                    {
                    }
                    else
                    {
                        continue;
                    }
                    //�f�[�^���M�敪�u9:����I���v�ł͂Ȃ�
                    if (jnl.DataSendCode != (int)EnumUoeConst.ctDataSendCode.ct_OK) continue;

                    //������}�X�^�l�̎擾
                    UOESupplier uOESupplier = _uoeSndRcvJnlAcs.SearchUOESupplier(jnl.UOESupplierCd);
                    if (uOESupplier == null) continue;
                    string commAssemblyId = uOESupplier.CommAssemblyId;		//�ʐM�A�Z���u��ID

                    //�����Y�Ƃ̔���
                    if (_uoeSndRcvJnlAcs.ChkMeiji(jnl.UOESupplierCd) == true) continue;
                    #endregion

                    //-----------------------------------------------------------
                    // (�W�J��)�d�����̎擾
                    //-----------------------------------------------------------
                    #region (�W�J��)�d�����̎擾
                    //(�W�J��)�d�����ׂ̎擾
                    int supplierFormal = 2;
                    Guid dtlRelationGuid = jnl.DtlRelationGuid;
                    StockDetailWork stockDetailWork = null;
                    string commonSlipNo = "";

                    status = _uoeSndRcvJnlAcs.ReadStockDetailWork(StockDetailTable, supplierFormal, dtlRelationGuid, out stockDetailWork, out commonSlipNo, out message);
                    if((status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    || (stockDetailWork == null)
                    || (commonSlipNo == ""))
                    {
                        continue;
                    }

                    //(�W�J��)�d���f�[�^�̎擾
                    StockSlipWork srcStockSlipWork = _uoeSndRcvJnlAcs.ReadStockSlipWork(StockSlipTable, supplierFormal, commonSlipNo, out message);
                    if (srcStockSlipWork == null)
                    {
                        continue;
                    }
                    #endregion

                    #region �I�����C���ԍ����ύX���ꂽ�ꍇ
                    //UOE�����ԍ����ύX���ꂽ�ꍇ
                    if (savOnlineNo != jnl.OnlineNo)
                    {
                        #region (�����p)�d���f�[�^�̒ǉ��쐬
                        //(�����p)�d���f�[�^�̒ǉ��쐬
                        status = uoeStockSlipCreate(out message);
                        if(status != (int)EnumUoeConst.Status.ct_NORMAL)
                        {
                            return(status);
                        }
                        #endregion

                        #region �t���O������
                        //���ݏ������̃I�����C���ԍ���ۑ�
                        savOnlineNo = jnl.OnlineNo;

                        //���ʓ`�[�ԍ�Dictionary�̃N���A
                        _commonSlipNoDictionary.Clear();

                        //���ʓ`�[�s�ԍ��̃N���A
                        commonSlipRowNo = 0;
                        #endregion
                    }
                    #endregion

                    //-----------------------------------------------------------
                    // ���_�`�[�E�a�n�`�[����
                    //-----------------------------------------------------------
                    #region ���_�`�[�E�a�n�`�[����
                    string keyPartySaleSlipNum = "";    //�����`�[�ԍ��j�d�x���

                    //�����Ώۓ`�[�ő吔�̐ݒ�
                    int loopMax = 0;
                    // 2009/05/25 START >>>>>>
                    //if (uOESupplier.CommAssemblyId == (string)EnumUoeConst.ctCommAssemblyId_0501) loopMax = 2;//�z���_��p����
                    //else                                                                            loopMax = 4;//���ʏ���(�z���_�ȊO)

                    if((uOESupplier.CommAssemblyId == (string)EnumUoeConst.ctCommAssemblyId_0501)
                    || (uOESupplier.CommAssemblyId == (string)EnumUoeConst.ctCommAssemblyId_0502))
                    {
                        loopMax = 2;//�z���_��p����
                    }
                    else
                    {
                        loopMax = 4;//���ʏ���(�z���_�ȊO)
                    }
                    // 2009/05/25 END   <<<<<<
                    
                    //���_�`�[�E�a�n�`�[����
                    //boDiv:BO�敪 0:���_�o�� 1:BO1 2:BO2 3:BO3
                    for (int boDiv = 0; boDiv < loopMax; boDiv++)
                    {
                        #region �o�ɐ����菈��
                        //�o�ɐ����菈��
                        //�z���_��p����
                        // 2009/05/25 START >>>>>>
                        //if (uOESupplier.CommAssemblyId == (string)EnumUoeConst.ctCommAssemblyId_0501)

                        if ((uOESupplier.CommAssemblyId == (string)EnumUoeConst.ctCommAssemblyId_0501)
                        || (uOESupplier.CommAssemblyId == (string)EnumUoeConst.ctCommAssemblyId_0502))
                        // 2009/05/25 END   <<<<<<
                        {
                            #region �o�ɐ�����(�z���_��p����)
                            //�o�ɐ�����
                            switch (boDiv)
                            {
                                //���_�o�ɕ�
                                case 0:
                                    if (jnl.UOESectOutGoodsCnt == 0) continue;
                                    // 2009/05/25 START >>>>>>
                                    //keyPartySaleSlipNum = jnl.UOESectionSlipNo + "-" + uOESupplier.HondaSectionCode;

                                    if (uOESupplier.CommAssemblyId == (string)EnumUoeConst.ctCommAssemblyId_0502)
                                    {
                                        keyPartySaleSlipNum = jnl.UOESectionSlipNo;
                                    }
                                    else
                                    {
                                        keyPartySaleSlipNum = jnl.UOESectionSlipNo + "-" + uOESupplier.HondaSectionCode;
                                    }
                                    // 2009/05/25 END   <<<<<<
                                    break;
                                //�a�n�o�ɕ�
                                case 1:
                                    if (jnl.BOShipmentCnt1 == 0) continue;
                                    string sourceShipment = jnl.SourceShipment.Trim() == "" ? "F" : jnl.SourceShipment;

                                    // 2009/05/25 START >>>>>>
                                    if (uOESupplier.CommAssemblyId == (string)EnumUoeConst.ctCommAssemblyId_0502)
                                    {
                                        sourceShipment = "F";
                                    }
                                    // 2009/05/25 END   <<<<<<
                                    //---ADD 2011/11/08 ---------------------->>>>>
                                    if (!string.IsNullOrEmpty(jnl.BOSlipNo1))
                                    {
                                        keyPartySaleSlipNum = jnl.BOSlipNo1 + "-" + sourceShipment;
                                    }
                                    //---ADD 2011/11/08 ----------------------<<<<
                                    //keyPartySaleSlipNum = jnl.BOSlipNo1 + "-" + sourceShipment; // DEL 2011/11/08
                                    break;
                                default:
                                    continue;
                            }
                            #endregion
                        }
                        //���ʏ���(�z���_�ȊO)
                        else
                        {
                            #region �o�ɐ�����(�z���_�ȊO�̋��ʏ���)
                            //�o�ɐ�����
                            switch (boDiv)
                            {
                                //���_�o�ɕ�
                                case 0:
                                    if (jnl.UOESectOutGoodsCnt == 0) continue;
                                    // ----- ADD 2010/05/10 --------------------------->>>>>
                                    if (string.IsNullOrEmpty(jnl.UOESectionSlipNo)) continue;
                                    if (jnl.UOESectionSlipNo.Trim() == string.Empty) continue;
                                    // ----- ADD 2010/05/10 ---------------------------<<<<<
                                    keyPartySaleSlipNum = jnl.UOESectionSlipNo;
                                    break;
                                //BO1�o�ɕ�
                                case 1:
                                    if (jnl.BOShipmentCnt1 == 0) continue;
                                    // ----- ADD 2010/05/10 --------------------------->>>>>
                                    if (string.IsNullOrEmpty(jnl.BOSlipNo1)) continue;
                                    if (jnl.BOSlipNo1.Trim() == string.Empty) continue;
                                    // ----- ADD 2010/05/10 ---------------------------<<<<<
                                    keyPartySaleSlipNum = jnl.BOSlipNo1;
                                    break;
                                //BO2�o�ɕ�
                                case 2:
                                    if (jnl.BOShipmentCnt2 == 0) continue;
                                    // ----- ADD 2010/05/10 --------------------------->>>>>
                                    if (string.IsNullOrEmpty(jnl.BOSlipNo2)) continue;
                                    if (jnl.BOSlipNo2.Trim() == string.Empty) continue;
                                    // ----- ADD 2010/05/10 ---------------------------<<<<<
                                    keyPartySaleSlipNum = jnl.BOSlipNo2;
                                    break;
                                //BO3�o�ɕ�
                                case 3:
                                    if (jnl.BOShipmentCnt3 == 0) continue;
                                    // ----- ADD 2010/05/10 --------------------------->>>>>
                                    if (string.IsNullOrEmpty(jnl.BOSlipNo3)) continue;
                                    if (jnl.BOSlipNo3.Trim() == string.Empty) continue;
                                    // ----- ADD 2010/05/10 ---------------------------<<<<<
                                    keyPartySaleSlipNum = jnl.BOSlipNo3;
                                    break;
                                default:
                                    continue;
                            }
                            #endregion
                        }
                        #endregion

                        //-----------------------------------------------------------
                        // (�����p)�d�����ׂ̒ǉ��쐬
                        //-----------------------------------------------------------
                        #region (�����p)�d�����ׂ̒ǉ��쐬
                        //�X�V�N���X�̎Z�o
                        StockDetailWork uoeStockDetailWork = GetStockDetailWork(
                                                                    stockDetailWork,
                                                                    jnl,
                                                                    boDiv,
                                                                    uOESupplier,
                                                                    keyPartySaleSlipNum);

                        //�d�����ׂ̒ǉ���StockDetailWork���f�[�^�[�e�[�u����
                        string uoeCommonSlipNo = jnl.OnlineNo.ToString("d9") + keyPartySaleSlipNum;
                        commonSlipRowNo++;

                        status = _uoeSndRcvJnlAcs.InsertTableFromStockDetailWork(
                                                UoeStockDetailTable,
                                                uoeStockDetailWork,
                                                uoeCommonSlipNo,
                                                commonSlipRowNo,
                                                out message);
                        #endregion

                        # region (�����p)�d���f�[�^��Dictionary�ǉ�
                        //(�����p)�d���f�[�^��Dictionary�ǉ�
                        if (_commonSlipNoDictionary.ContainsKey(uoeCommonSlipNo) != true)
                        {
                            StockSlipWork stockSlipWork = srcStockSlipWork.Clone();
                            SetStockSlip(ref stockSlipWork, jnl, keyPartySaleSlipNum);
                            _commonSlipNoDictionary.Add(uoeCommonSlipNo, stockSlipWork);
                        }
                        #endregion
                    }
                    #endregion
                }

                //-----------------------------------------------------------
                // (�����p)�d���f�[�^�̒ǉ��쐬
                //-----------------------------------------------------------
                #region (�����p)�d���f�[�^�̒ǉ��쐬
                status = uoeStockSlipCreate(out message);
                if (status != (int)EnumUoeConst.Status.ct_NORMAL)
                {
                    return (status);
                }
                #endregion

                //-----------------------------------------------------------
                // �d�����׃f�[�^�ɍs�ԍ���ݒ�
                //-----------------------------------------------------------
                #region �d�����׃f�[�^�ɍs�ԍ���ݒ�
                status = SettingRowNoFromStock(out message);
                if (status != (int)EnumUoeConst.Status.ct_NORMAL)
                {
                    return (status);
                }
                #endregion
            }
            catch (Exception ex)
            {
                status = -1;
                message = ex.Message;
            }
            return (status);
        }
        #endregion

        # region �d�����׃f�[�^�ɍs�ԍ���ݒ�
        /// <summary>
        /// �d�����׃f�[�^�ɍs�ԍ���ݒ�
        /// </summary>
        /// <param name="message">�G���[���b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        private int SettingRowNoFromStock(out string message)
        {
            //�ϐ��̏�����
            int status = (int)EnumUoeConst.Status.ct_NORMAL;
            message = "";

            try
            {
                //-----------------------------------------------------------
                // �d���f�[�^DataView�̍쐬
                //-----------------------------------------------------------
                # region �d���f�[�^DataView�̍쐬
                Int32 supplierFormal = 0;   //0:�d��,1:����,2:�����@�i�󒍃X�e�[�^�X�j
                string rowFilterText = string.Format("{0} = {1}",
                                                StockSlipSchema.ct_Col_SupplierFormal, supplierFormal);
                string sortText = string.Format("{0}, {1}",
                                                StockSlipSchema.ct_Col_SupplierFormal,
                                                StockSlipSchema.ct_Col_CommonSlipNo
                                                );
                DataView viewUoeStockSlip = new DataView(UoeStockSlipTable);
                viewUoeStockSlip.Sort = sortText;
                viewUoeStockSlip.RowFilter = rowFilterText;

                if (viewUoeStockSlip == null) return (status);
                if (viewUoeStockSlip.Count == 0) return (status);
                # endregion

                //------------------------------------------------------
                // �d�����׃f�[�^�ɍs�ԍ���ݒ�
                //------------------------------------------------------
                # region �d�����׃f�[�^�ɍs�ԍ���ݒ�
                foreach (DataRowView rowUoeStockSlip in viewUoeStockSlip)
                {
                    string commonSlipNo = (string)rowUoeStockSlip[StockSlipSchema.ct_Col_CommonSlipNo];
                    status = _uoeSndRcvJnlAcs.SetRowNoFromStockDetail(UoeStockDetailTable, supplierFormal, commonSlipNo, out message);
                    if (status != (int)EnumUoeConst.Status.ct_NORMAL)
                    {
                        return (status);
                    }
                }
                # endregion
            }
            catch (Exception ex)
            {
                status = -1;
                message = ex.Message;
            }
            return (status);
        }
        #endregion

        # region (�����p)�d���f�[�^�̒ǉ��쐬����
        /// <summary>
        /// (�����p)�d���f�[�^�̒ǉ��쐬����
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Update Note : 2014/01/24  ������</br>
        /// <br>              Redmine#41551�̑Ή� UOE����őΉ�</br>
        /// </remarks>
        private int uoeStockSlipCreate(out string message)
        {
            //�ϐ��̏�����
            int status = (int)EnumUoeConst.Status.ct_NORMAL;
            message = "";

            try
            {
                if (_commonSlipNoDictionary.Count == 0)
                {
                    return(status);
                }

                foreach (KeyValuePair<string, StockSlipWork> item in _commonSlipNoDictionary)
                {
                    //-----------------------------------------------------------
                    // �d���擾
                    //-----------------------------------------------------------
                    string commonSlipNo = item.Key;
                    StockSlipWork stockSlipWork = item.Value;
                    Int32 supplierFormal = stockSlipWork.SupplierFormal;

                    Supplier supplier = _uoeSndRcvCtlInitAcs.GetSupplier(stockSlipWork.SupplierCd);

                    //�d���[�������敪
                    //1:�؎̂�,2:�l�̌ܓ�,3:�؏グ�@�i����Łj
                    //�[�������P��
                    StockProcMoney stockProcMoney = this._uOEOrderDtlAcs.GetStockProcMoney(
                                                                1,
                                                                supplier.StockCnsTaxFrcProcCd,
                                                                999999999);

                    stockSlipWork.StockFractionProcCd = stockProcMoney.FractionProcCd;
                    
                    //-----------------------------------------------------------
                    // �d�����׎擾
                    //-----------------------------------------------------------
                    //ArrayList uoeStockDetailWorkAry = _uoeSndRcvJnlAcs.SearchStockDetailDataTable(UoeStockDetailTable, supplierFormal, commonSlipNo);//DEL ������ 2014/01/24 for Redmine#41551 
                    ArrayList uoeStockDetailWorkAry = CalculateDetailPrice(UoeStockDetailTable, supplierFormal, commonSlipNo, stockSlipWork); //ADD ������ 2014/01/24 for Redmine#41551 
                    List<StockDetailWork> uoeStockDetailWorkList = new List<StockDetailWork>();
                    foreach (StockDetailWork stockDetailWork in uoeStockDetailWorkAry)
                    {
                        uoeStockDetailWorkList.Add(stockDetailWork);
                    }

                    //-----------------------------------------------------------
                    // �d���f�[�^�̏��Z�o
                    //-----------------------------------------------------------
                    StockSlipPriceCalculator.TotalPriceSetting(
                                                ref stockSlipWork,
                                                uoeStockDetailWorkList,
                                                stockProcMoney.FractionProcUnit,
                                                stockProcMoney.FractionProcCd);

                    //���׍s��
                    stockSlipWork.DetailRowCount = uoeStockDetailWorkAry.Count;

                    //-----------------------------------------------------------
                    // �d���f�[�^�e�[�u���̍X�V����
                    //-----------------------------------------------------------
                    status = _uoeSndRcvJnlAcs.InsertTableFromStockSlipWork(UoeStockSlipTable, stockSlipWork, commonSlipNo, out message);
                    if (status != (int)EnumUoeConst.Status.ct_NORMAL)
                    {
                        return (status);
                    }
                }
            }
            catch (Exception ex)
            {
                status = -1;
                message = ex.Message;
            }
            return (status);
        }
        #endregion

        // --------- ADD ������ 2014/01/24 for Redmine#41551 -------------- >>>>>>>
        # region �d�����׃��X�g�̎擾�FArrayList<StockDetailWork>
        /// <summary>
        /// �d�����׃��X�g�̎擾�FArrayList
        /// </summary>
        /// <param name="tbl">�f�[�^�e�[�u��</param>
        /// <param name="supplierFormal">�d���`��</param>
        /// <param name="commonSlipNo">�d���`�[�ԍ�</param>
        /// <param name="stockSlipWork">�d��Work</param>
        /// <returns></returns>
        public ArrayList CalculateDetailPrice(DataTable tbl, Int32 supplierFormal, string commonSlipNo, StockSlipWork stockSlipWork)
        {
            ArrayList returnStockDetailAry = new ArrayList();
            try
            {
                string rowFilterText = string.Format("{0} = {1} AND {2} = '{3}'",
                                                StockDetailSchema.ct_Col_SupplierFormal, supplierFormal,
                                                StockDetailSchema.ct_Col_CommonSlipNo, commonSlipNo);

                string sortText = string.Format("{0}, {1}, {2}, {3}",
                    StockDetailSchema.ct_Col_EnterpriseCode,
                    StockDetailSchema.ct_Col_SupplierFormal,
                    StockDetailSchema.ct_Col_CommonSlipNo,
                    StockDetailSchema.ct_Col_CommonSlipRowNo);

                DataView viewStockDetail = new DataView(tbl);
                viewStockDetail.Sort = sortText;
                viewStockDetail.RowFilter = rowFilterText;

                if (viewStockDetail.Count > 0)
                {
                    foreach (DataRowView rowStockDetail in viewStockDetail)
                    {
                        CalculatePrice(stockSlipWork, rowStockDetail);

                        StockDetailWork stockDetailWork = _uoeSndRcvJnlAcs.CreateStockDetailWorkFromSchema(rowStockDetail.Row);
                        returnStockDetailAry.Add(stockDetailWork);
                    }
                }
            }
            catch (Exception)
            {
                returnStockDetailAry = null;
            }
            return (returnStockDetailAry);
        }
        # endregion

        # region
        /// <summary>
        /// �d�����ׂ̐ō����i�Čv�Z
        /// </summary>
        /// <param name="stockSlipWork">�d��Work</param>
        /// <param name="rowStockDetail">�d������Detail</param>
        /// <returns></returns>
        private void CalculatePrice(StockSlipWork stockSlipWork, DataRowView rowStockDetail)
        {   //-----------------------------------------------------------
            // �艿�̎Z�o
            //-----------------------------------------------------------
            //�ō���
            rowStockDetail.Row[StockDetailSchema.ct_Col_ListPriceTaxIncFl] = _uOEOrderDtlAcs.GetStockPriceTaxInc(
                (double)rowStockDetail.Row[StockDetailSchema.ct_Col_ListPriceTaxExcFl],
                (Int32)rowStockDetail.Row[StockDetailSchema.ct_Col_TaxationCode],
                (Int32)rowStockDetail.Row[StockDetailSchema.ct_Col_FracProcStckUnPrc],
                stockSlipWork.StockDate);

            //-----------------------------------------------------------
            // �d���P���̎Z�o
            //----------------------------------------------------------- 
            #region �d���P��

            //�d���P���i�ō��C�����j 
            rowStockDetail.Row[StockDetailSchema.ct_Col_StockUnitTaxPriceFl] = _uOEOrderDtlAcs.GetStockPriceTaxInc(
                (double)rowStockDetail.Row[StockDetailSchema.ct_Col_StockUnitPriceFl],
                (Int32)rowStockDetail.Row[StockDetailSchema.ct_Col_TaxationCode],
                (Int32)rowStockDetail.Row[StockDetailSchema.ct_Col_FracProcStckUnPrc],
                stockSlipWork.StockDate);
            #endregion

            //-----------------------------------------------------------
            // �d�����z�̎Z�o
            //-----------------------------------------------------------
            #region �d�����z
            long stockPriceTaxInc = 0;
            long stockPriceTaxExc = 0;
            long stockPriceConsTax = 0;
            bool bStatus = _uOEOrderDtlAcs.CalculationStockPrice(
                (double)rowStockDetail.Row[StockDetailSchema.ct_Col_StockCount],
                (double)rowStockDetail.Row[StockDetailSchema.ct_Col_StockUnitPriceFl],
                (Int32)rowStockDetail.Row[StockDetailSchema.ct_Col_TaxationCode],
                stockSlipWork.StockFractionProcCd,
                (Int32)rowStockDetail.Row[StockDetailSchema.ct_Col_FracProcStckUnPrc],
                stockSlipWork.StockDate,
                out stockPriceTaxInc,
                out stockPriceTaxExc,
                out stockPriceConsTax);

            if (bStatus == true)
            {
                //�d�����z�i�Ŕ����j
                rowStockDetail.Row[StockDetailSchema.ct_Col_StockPriceTaxExc] = stockPriceTaxExc;

                //�d�����z�i�ō��݁j
                rowStockDetail.Row[StockDetailSchema.ct_Col_StockPriceTaxInc] = stockPriceTaxInc;
            }
            else
            {
                rowStockDetail.Row[StockDetailSchema.ct_Col_StockPriceTaxExc] = 0;
                rowStockDetail.Row[StockDetailSchema.ct_Col_StockPriceTaxInc] = 0;
            }
            #endregion

            //-----------------------------------------------------------
            // ����ł̎Z�o
            //-----------------------------------------------------------
            #region �����
            //�d�����z����Ŋz
            rowStockDetail.Row[StockDetailSchema.ct_Col_StockPriceConsTax] =
                (long)rowStockDetail.Row[StockDetailSchema.ct_Col_StockPriceTaxInc] -
                (long)rowStockDetail.Row[StockDetailSchema.ct_Col_StockPriceTaxExc];
            #endregion
        }
        # endregion
        // --------- ADD ������ 2014/01/24 for Redmine#41551 -------------- <<<<<<

        # region ����M�i�m�k���d���f�[�^�N���X���擾����(����M�i�m�k���d���N���X)
        /// <summary>
        /// ����M�i�m�k���d���N���X���擾����(����M�i�m�k���d���N���X)
        /// </summary>
        /// <param name="stockSlipWork">�d���f�[�^</param>
        /// <param name="jnl">����M�i�m�k</param>
        /// <param name="partySaleSlipNum">�����`�[�ԍ�</param>
        /// <remarks>
        /// <br>Update Note : 2014/01/24  ������</br>
        /// <br>              Redmine#41551�̑Ή� UOE����őΉ�</br>
        /// </remarks>
        private void SetStockSlip(ref StockSlipWork stockSlipWork, OrderSndRcvJnl jnl, string partySaleSlipNum)
        {
            //-----------------------------------------------------------
            // �d���f�[�^�j�d�x���ڂ̐ݒ�
            //-----------------------------------------------------------
            # region �d���f�[�^�j�d�x���ڂ̐ݒ�
            stockSlipWork.SupplierFormal = 0;   //�d���`�� 0:�d��,1:����,2:�����@�i�󒍃X�e�[�^�X�j
            stockSlipWork.SupplierSlipNo = 0;   //�d���`�[�ԍ�

            //�w�b�_�[���ڏ�����
            stockSlipWork.CreateDateTime = DateTime.MinValue;
            stockSlipWork.UpdateDateTime = DateTime.MinValue;
            stockSlipWork.FileHeaderGuid = Guid.Empty;
            stockSlipWork.UpdEmployeeCode = "";
            stockSlipWork.UpdAssemblyId1 = "";
            stockSlipWork.UpdAssemblyId2 = "";
            stockSlipWork.LogicalDeleteCode = 0;
            # endregion

            //-----------------------------------------------------------
            // �d���v����t
            //-----------------------------------------------------------
            #region �d���v����t
            stockSlipWork.InputDay = DateTime.Now;          //���͓�
            stockSlipWork.ArrivalGoodsDay = DateTime.Now;   //���ד�

            //����́E����
            //UOE���Аݒ�Ͻ��̌v����t�敪:�V�X�e�����t
            if((_uoeSndRcvJnlAcs.uOESetting.AddUpADateDiv == (int)EnumUoeConst.ctAddUpADateDiv.ct_System)
            || (jnl.SystemDivCd == (int)EnumUoeConst.ctSystemDivCd.ct_Search)
            || (jnl.SystemDivCd == (int)EnumUoeConst.ctSystemDivCd.ct_Input))
            {
                stockSlipWork.StockDate = DateTime.Now;
            }
            //�`��
            //UOE���Аݒ�Ͻ��̌v����t�敪:������t
            else
            {
                stockSlipWork.StockDate = jnl.SalesDate;
            }

            //�x����R�[�h�ɂĎd�������y�юd�������̒����`�F�b�N
            //���ς̏ꍇ�ɂ͍����������+1����Ă���
            //�d�������̒����擾����
            if ((stockSlipWork.StockAddUpSectionCd.Trim() != "") && (stockSlipWork.PayeeCode != 0))
            {
                if (_totalDayCalculator.CheckPayment(stockSlipWork.StockAddUpSectionCd, stockSlipWork.PayeeCode, stockSlipWork.StockDate) != false)
                {
                    DateTime prevTotalDay = DateTime.MinValue;
                    DateTime currentTotalDay = DateTime.MinValue;

                    if (_totalDayCalculator.GetTotalDayPayment(stockSlipWork.StockAddUpSectionCd, stockSlipWork.PayeeCode, out prevTotalDay, out currentTotalDay) == 0)
                    {
                        DateTime setDateTime = prevTotalDay.AddDays(1);
                        stockSlipWork.StockDate = setDateTime;
                    }
                }

                //�d�������̒����擾����
                if (_totalDayCalculator.CheckMonthlyAccPay(stockSlipWork.StockAddUpSectionCd, stockSlipWork.PayeeCode, stockSlipWork.StockDate) != false)
                {
                    DateTime prevTotalDay = DateTime.MinValue;
                    DateTime currentTotalDay = DateTime.MinValue;

                    if (_totalDayCalculator.GetTotalDayMonthlyAccPay(stockSlipWork.StockAddUpSectionCd, stockSlipWork.PayeeCode, out prevTotalDay, out currentTotalDay) == 0)
                    {
                        DateTime setDateTime = prevTotalDay.AddDays(1);
                        stockSlipWork.StockDate = setDateTime;
                    }
                }
            }

            //�d���v����t
            stockSlipWork.StockAddUpADate = stockSlipWork.StockDate;
            #endregion

            //-----------------------------------------------------------
            // �d������̐ݒ�
            //-----------------------------------------------------------
            #region �d������̐ݒ�
            Supplier supplier = _uoeSndRcvCtlInitAcs.GetSupplier(jnl.SupplierCd);

            stockSlipWork.SupplierCd = jnl.SupplierCd;
            if(supplier == null)
            {
                stockSlipWork.SupplierNm1 = "";
                stockSlipWork.SupplierNm2 = "";
                stockSlipWork.SupplierSnm = "";
                stockSlipWork.SuppCTaxLayCd = 0;
                stockSlipWork.SuppTtlAmntDspWayCd = 0;
            }
            else
            {
                //�d���於��
                stockSlipWork.SupplierNm1 = supplier.SupplierNm1;
                stockSlipWork.SupplierNm2 = supplier.SupplierNm2;
                stockSlipWork.SupplierSnm = supplier.SupplierSnm;

                //�d�������œ]�ŕ����R�[�h
                //0:�`�[�P��1:���גP��2:�x���e 3:�x���q 9:��ې�
                stockSlipWork.SuppCTaxLayCd = supplier.SuppCTaxLayCd;

                //�d���摍�z�\�����@�敪
                //0:���z�\�����Ȃ��i�Ŕ����j,1:���z�\������i�ō��݁j
                stockSlipWork.SuppTtlAmntDspWayCd = supplier.SuppTtlAmntDspWayCd;
            }
            #endregion

            //�d�������Őŗ�
            //stockSlipWork.SupplierConsTaxRate = this._uOEOrderDtlAcs.GetTaxRate(DateTime.Now);// DEL ������ 2014/01/24 for Redmine#41551 

            stockSlipWork.SupplierConsTaxRate = this._uOEOrderDtlAcs.GetTaxRate(stockSlipWork.StockAddUpADate);// ADD ������ 2014/01/24 for Redmine#41551 

            //�d�����i�敪
            //0:���i,1:���i�O,2:����Œ���,3:�c������,4:���|�p����Œ���,
            //5:���|�p�c������,6:���v����,10:���p����Œ���(����),11:���E,12:���E(����)
            stockSlipWork.StockGoodsCd = 0;

            //-----------------------------------------------------------
            // �����`�[�ԍ�
            //-----------------------------------------------------------
            #region �����`�[�ԍ�
            stockSlipWork.PartySaleSlipNum = partySaleSlipNum;
            #endregion
        }
        #endregion

        # region ����M�i�m�k���d�����׃N���X���擾����(����M�i�m�k���d�����׃N���X)
        /// <summary>
        /// �d�����׃N���X���擾����(����M�i�m�k���d�����׃N���X)
        /// </summary>
        /// <param name="jnl">����M�i�m�k</param>
        /// <param name="boDiv">�a�n�敪 0:���_�o�� 1:BO1�o�� 2:BO2�o�� 3:BO3�o��</param>
        /// <param name="uOESupplier">������}�X�^</param>
        /// <param name="tempSalesSlipNum">�`�[�ԍ�</param>
        /// <returns>�d�����׃N���X</returns>
        private StockDetailWork GetStockDetailWork(StockDetailWork srcStockDetailWork, OrderSndRcvJnl jnl, int boDiv, UOESupplier uOESupplier, string partySaleSlipNum)
        {
            StockDetailWork dstStockDetailWork = srcStockDetailWork.Clone();

            //-----------------------------------------------------------
            // �d�����ׂj�d�x���ڂ̐ݒ�
            //-----------------------------------------------------------
            #region �d�����ׂj�d�x���ڂ̐ݒ�
            //�d���`���i���j0:�d��,1:����,2:�����@�i�󒍃X�e�[�^�X�j
            dstStockDetailWork.SupplierFormalSrc = dstStockDetailWork.SupplierFormal;

            //�d�����גʔԁi���j
            dstStockDetailWork.StockSlipDtlNumSrc = dstStockDetailWork.StockSlipDtlNum;

            //�d���`�� 0:�d��,1:����,2:�����@�i�󒍃X�e�[�^�X�j
            dstStockDetailWork.SupplierFormal = 0;

            //�d���`�[�ԍ�
            dstStockDetailWork.SupplierSlipNo = 0;

            //�d�����גʔ�
            dstStockDetailWork.StockSlipDtlNum = 0;

            //���������s�ϋ敪
            dstStockDetailWork.OrderFormIssuedDiv = 0;

            //�󒍃X�e�[�^�X�i�����j
            dstStockDetailWork.AcptAnOdrStatusSync = 30;

            //���㖾�גʔԁi�����j
            dstStockDetailWork.SalesSlipDtlNumSync = 0;

            //���׊֘A�t��GUID
            //if (this._uoeSndRcvCtlInitAcs.GetSalesTtlSt().SalesStockDiv != 0)
            //{
                dstStockDetailWork.DtlRelationGuid = GetLinkGuidSalesStock(jnl.OnlineNo, jnl.OnlineRowNo, partySaleSlipNum);
            //}

            //�w�b�_�[���ڏ�����
            dstStockDetailWork.CreateDateTime = DateTime.MinValue;
            dstStockDetailWork.UpdateDateTime = DateTime.MinValue;
            dstStockDetailWork.FileHeaderGuid = Guid.Empty;
            dstStockDetailWork.UpdEmployeeCode = "";
            dstStockDetailWork.UpdAssemblyId1 = "";
            dstStockDetailWork.UpdAssemblyId2 = "";
            dstStockDetailWork.LogicalDeleteCode = 0;
            #endregion
            
            //-----------------------------------------------------------
            // �d������̐ݒ�
            //-----------------------------------------------------------
            #region �d������̐ݒ�
            Supplier supplier = _uoeSndRcvCtlInitAcs.GetSupplier(jnl.SupplierCd);
            dstStockDetailWork.SupplierCd = jnl.SupplierCd;
            dstStockDetailWork.SupplierSnm = jnl.SupplierSnm;
            #endregion

            //-----------------------------------------------------------
            // �i�Ԃ̎Z�o
            //-----------------------------------------------------------
            #region �i��
            //��֕i�ԍ̗p
            if((uOESupplier.SubstPartsNoDiv == (int)EnumUoeConst.ctSubstPartsNoDiv.ct_SubstParts)
            && (jnl.SubstPartsNo.Trim() != ""))
            {
                dstStockDetailWork.GoodsNo = jnl.SubstPartsNo;
                dstStockDetailWork.GoodsMakerCd = jnl.AnswerMakerCd;	// �񓚃��[�J�[�R�[�h

                //���[�J�[����
                MakerUMnt makerUMnt = new MakerUMnt();
                int status = this._uoeSndRcvCtlInitAcs.GetMakerInf(jnl.AnswerMakerCd, out makerUMnt);
                if(status == 0)
                {
                    dstStockDetailWork.MakerName = makerUMnt.MakerName;             //���[�J�[����
                    dstStockDetailWork.MakerKanaName = makerUMnt.MakerKanaName;     //���[�J�[�J�i����
                    dstStockDetailWork.CmpltMakerKanaName = "";                     //���[�J�[�J�i���́i�ꎮ�j

                    //�i�Ԍ���
                    List<GoodsUnitData> list = null;

                    status = this._uoeSndRcvCtlInitAcs.SearchPartsFromGoodsNoForMstInf(
                        dstStockDetailWork.GoodsMakerCd,
                        dstStockDetailWork.GoodsNo,
                        out list);

                    if ((status == 0) && (list != null))
                    {
                        dstStockDetailWork.GoodsNameKana = list[0].GoodsNameKana;               //���i���̃J�i
                        dstStockDetailWork.GoodsLGroup = list[0].GoodsLGroup;                   //���i�啪�ރR�[�h
                        dstStockDetailWork.GoodsLGroupName = list[0].GoodsLGroupName;           //���i�啪�ޖ���
                        dstStockDetailWork.GoodsMGroup = list[0].GoodsMGroup;                   //���i�����ރR�[�h
                        dstStockDetailWork.GoodsMGroupName = list[0].GoodsMGroupName;           //���i�����ޖ���
                        dstStockDetailWork.BLGroupCode = list[0].BLGroupCode;                   //BL�O���[�v�R�[�h
                        dstStockDetailWork.BLGroupName = list[0].BLGroupName;                   //BL�O���[�v�R�[�h����
                        dstStockDetailWork.BLGoodsCode = list[0].BLGoodsCode;                   //BL���i�R�[�h
                        dstStockDetailWork.BLGoodsFullName = list[0].BLGoodsFullName;           //BL���i�R�[�h���́i�S�p�j

                        dstStockDetailWork.EnterpriseGanreCode = list[0].EnterpriseGanreCode;   //���Е��ރR�[�h
                        dstStockDetailWork.EnterpriseGanreName = list[0].EnterpriseGanreName;   //���Е��ޖ���
                        dstStockDetailWork.TaxationCode = list[0].TaxationDivCd;
                    }
                    else
                    {
                        dstStockDetailWork.GoodsNameKana = "";        //���i���̃J�i
                        dstStockDetailWork.GoodsLGroup = 0;           //���i�啪�ރR�[�h
                        dstStockDetailWork.GoodsLGroupName = "";      //���i�啪�ޖ���
                        dstStockDetailWork.GoodsMGroup = 0;           //���i�����ރR�[�h
                        dstStockDetailWork.GoodsMGroupName = "";      //���i�����ޖ���
                        dstStockDetailWork.BLGroupCode = 0;           //BL�O���[�v�R�[�h
                        dstStockDetailWork.BLGroupName = "";          //BL�O���[�v�R�[�h����
                        dstStockDetailWork.BLGoodsCode = 0;           //BL���i�R�[�h
                        dstStockDetailWork.BLGoodsFullName = "";      //BL���i�R�[�h���́i�S�p�j
                        dstStockDetailWork.EnterpriseGanreCode = 0;   //���Е��ރR�[�h
                        dstStockDetailWork.EnterpriseGanreName = "";  //���Е��ޖ���
                    }
                }
                else
                {
                    dstStockDetailWork.MakerName = "";            //���[�J�[����
                    dstStockDetailWork.MakerKanaName = "";        //���[�J�[�J�i����

                    dstStockDetailWork.GoodsNameKana = "";        //���i���̃J�i
                    dstStockDetailWork.GoodsLGroup = 0;           //���i�啪�ރR�[�h
                    dstStockDetailWork.GoodsLGroupName = "";      //���i�啪�ޖ���
                    dstStockDetailWork.GoodsMGroup = 0;           //���i�����ރR�[�h
                    dstStockDetailWork.GoodsMGroupName = "";      //���i�����ޖ���
                    dstStockDetailWork.BLGroupCode = 0;           //BL�O���[�v�R�[�h
                    dstStockDetailWork.BLGroupName = "";          //BL�O���[�v�R�[�h����
                    dstStockDetailWork.BLGoodsCode = 0;           //BL���i�R�[�h
                    dstStockDetailWork.BLGoodsFullName = "";      //BL���i�R�[�h���́i�S�p�j
                    dstStockDetailWork.EnterpriseGanreCode = 0;   //���Е��ރR�[�h
                    dstStockDetailWork.EnterpriseGanreName = "";  //���Е��ޖ���
                }
            }
            //�����i�ԍ̗p
            else
            {
                dstStockDetailWork.GoodsNo = jnl.GoodsNo;
            }
            #endregion

            //-----------------------------------------------------------
            // �i���̎Z�o
            //-----------------------------------------------------------
            #region �i��
            if ((jnl.GoodsName.Trim() == "*") && (jnl.AnswerPartsName.Trim() != ""))
            {
                dstStockDetailWork.GoodsName = jnl.AnswerPartsName;
            }
            #endregion

            //-----------------------------------------------------------
            // �o�ɐ��̎Z�o
            //-----------------------------------------------------------
            #region �o�ɐ��̎Z�o
            int count = 0;  //(�Z�o�p)�o�ɐ�
            switch (boDiv)
            {
                //���_�o��
                case 0:
                    count = jnl.UOESectOutGoodsCnt;
                    break;
                //�a�n�P�o��
                case 1:
                    count = jnl.BOShipmentCnt1;
                    break;
                //�a�n�Q�o��
                case 2:
                    count = jnl.BOShipmentCnt2;
                    break;
                //�a�n�R�o��
                case 3:
                    count = jnl.BOShipmentCnt3;
                    break;
            }

            //�d����
            dstStockDetailWork.StockCount = count;

            //��������
            dstStockDetailWork.OrderCnt = count;

            //�����c��
            dstStockDetailWork.OrderRemainCnt = count;
            #endregion

            //-----------------------------------------------------------
            // �ېŋ敪�̎Z�o(0:�ې�,1:��ې�,2:�ېŁi���Łj)
            //-----------------------------------------------------------
            #region �ېŋ敪�̎Z�o
            int taxationCode = dstStockDetailWork.TaxationCode;

            if ((supplier.SuppCTaxLayCd == 9)
            || (supplier.SuppCTaxationCd == 1)
            || (dstStockDetailWork.TaxationCode == (int)CalculateTax.TaxationCode.TaxNone))
            {
                taxationCode = (int)CalculateTax.TaxationCode.TaxNone;
            }
            #endregion

            //-----------------------------------------------------------
            // �艿�̎Z�o
            //-----------------------------------------------------------
            #region �艿�̎Z�o
            double dstPrice = 0;
            double srcPrice = jnl.ListPrice;

            switch(uOESupplier.ListPriceUseDiv)
            {
                //0:������
                case (int)EnumUoeConst.ctListPriceUseDiv.ct_Hight:
                    dstPrice = jnl.AnswerListPrice <= srcPrice ? srcPrice : jnl.AnswerListPrice; 
                    break;
                //1:���͗D��
                case (int)EnumUoeConst.ctListPriceUseDiv.ct_Input:
                    dstPrice = srcPrice;
                    break;
                //2:�I�����C���D��
                default:
                    dstPrice = jnl.AnswerListPrice;
                    break;
            }

            //�Ŕ���
            dstStockDetailWork.ListPriceTaxExcFl = dstPrice;

            //�ō���
            dstStockDetailWork.ListPriceTaxIncFl = _uOEOrderDtlAcs.GetStockPriceTaxInc(dstPrice, taxationCode, supplier.StockCnsTaxFrcProcCd);
            #endregion

            //-----------------------------------------------------------
            // �d���P���̎Z�o
            //-----------------------------------------------------------
            #region �d���P���ύX�敪
            //�d���P���ύX�敪
            //�ύX�O�����Ɖ񓚌������قȂ�
            if(dstStockDetailWork.BfStockUnitPriceFl != jnl.AnswerSalesUnitCost)
            {
                dstStockDetailWork.StockUnitChngDiv = 1;
            }
            //�ύX�O�����Ɖ񓚌���������
            else
            {
                dstStockDetailWork.StockUnitChngDiv = 0;
            }
            #endregion

            #region �d���P��
            //�d���P���i�Ŕ��C�����j
            dstStockDetailWork.StockUnitPriceFl = jnl.AnswerSalesUnitCost;

            //�d���P���i�ō��C�����j
            dstStockDetailWork.StockUnitTaxPriceFl = _uOEOrderDtlAcs.GetStockPriceTaxInc(jnl.AnswerSalesUnitCost, taxationCode, supplier.StockCnsTaxFrcProcCd);
            #endregion

            //-----------------------------------------------------------
            // �d�����z�̎Z�o
            //-----------------------------------------------------------
            #region �d�����z
            long stockPriceTaxInc = 0;
            long stockPriceTaxExc = 0;
            long stockPriceConsTax = 0;

            bool bStatus = _uOEOrderDtlAcs.CalculationStockPrice(
                (double)count,
                dstStockDetailWork.StockUnitPriceFl,
                taxationCode,
                supplier.StockMoneyFrcProcCd,
                supplier.StockCnsTaxFrcProcCd,
                out stockPriceTaxInc,
                out stockPriceTaxExc,
                out stockPriceConsTax);

            if(bStatus == true)
            {
                //�d�����z�i�Ŕ����j
                dstStockDetailWork.StockPriceTaxExc = stockPriceTaxExc;

                //�d�����z�i�ō��݁j
                dstStockDetailWork.StockPriceTaxInc = stockPriceTaxInc;
            }
            else
            {
                dstStockDetailWork.StockPriceTaxExc = 0;
                dstStockDetailWork.StockPriceTaxInc = 0;
            }
            #endregion

            //-----------------------------------------------------------
            // ����ł̎Z�o
            //-----------------------------------------------------------
            #region �����
            //�d�����z����Ŋz
            dstStockDetailWork.StockPriceConsTax = dstStockDetailWork.StockPriceTaxInc - dstStockDetailWork.StockPriceTaxExc;
            #endregion

            //-----------------------------------------------------------
            // �N���A����
            //-----------------------------------------------------------
            #region �N���A����
            dstStockDetailWork.RateSectStckUnPrc = "";      // �|���ݒ苒�_�i�d���P���j
            dstStockDetailWork.RateDivStckUnPrc = "";       // �|���ݒ�敪�i�d���P���j
            dstStockDetailWork.UnPrcCalcCdStckUnPrc = 0;    // �P���Z�o�敪�i�d���P���j
            dstStockDetailWork.PriceCdStckUnPrc = 0;        // ���i�敪�i�d���P���j
            dstStockDetailWork.StdUnPrcStckUnPrc = 0;       // ��P���i�d���P���j
            //dstStockDetailWork.FracProcUnitStcUnPrc = 0;    // �[�������P�ʁi�d���P���j
            //dstStockDetailWork.FracProcStckUnPrc = 0;       // �[�������i�d���P���j

            dstStockDetailWork.RateBLGoodsCode = 0;         // BL���i�R�[�h�i�|���j
            dstStockDetailWork.RateBLGoodsName = "";        // BL���i�R�[�h���́i�|���j
            dstStockDetailWork.RateGoodsRateGrpCd = 0;      // ���i�|���O���[�v�R�[�h�i�|���j
            dstStockDetailWork.RateGoodsRateGrpNm = "";     // ���i�|���O���[�v���́i�|���j
            dstStockDetailWork.RateBLGroupCode = 0;         // BL�O���[�v�R�[�h�i�|���j
            dstStockDetailWork.RateBLGroupName = "";        // BL�O���[�v���́i�|���j
            #endregion

            return (dstStockDetailWork);
        }
        #endregion
        #endregion

        # region ����d���A���pGUID�̎擾
        /// <summary>
        /// ����d���A���pGUID�̎擾
        /// </summary>
        /// <param name="no">�I�����C���ԍ�</param>
        /// <param name="rowNo">�I�����C���s�ԍ�</param>
        /// <param name="partySaleSlipNum">�����`�[�ԍ�</param>
        /// <returns>Guid</returns>
        private Guid GetLinkGuidSalesStock(Int32 no, Int32 rowNo, string partySaleSlipNum)
        {
            Guid guid = Guid.NewGuid();

            //�`�[���Z�E�t�H���[�`�[���Z
            if ((_uoeSndRcvJnlAcs.uOESetting.FollowSlipOutputDiv == (int)EnumUoeConst.ctFollowSlipOutputDiv.ct_Add)
            || (CheckAddingUp() == true)
            || (partySaleSlipNum.Trim() == ""))
            {
            }
            else
            {
                string keyNo = no.ToString("d9") + rowNo.ToString("d4") + partySaleSlipNum.Trim();
                if (_linkSalesStockDictionary.ContainsKey(keyNo) == true)
                {
                    guid = _linkSalesStockDictionary[keyNo];
                }
            }
            return (guid);
        }
        # endregion

        # region ����d���A���pGUID�̐ݒ�
        /// <summary>
        /// ����d���A���pGUID�̐ݒ�E�擾
        /// </summary>
        /// <param name="no">�I�����C���ԍ�</param>
        /// <param name="rowNo">�I�����C���s�ԍ�</param>
        /// <param name="partySaleSlipNum">�����`�[�ԍ�</param>
        /// <param name="detailCd">���׎�ʁ@0:�ʏ햾�� 9;�[������</param>
        /// <returns>Guid</returns>
        private Guid SetGuidSalesStock(Int32 no, Int32 rowNo, string partySaleSlipNum, int detailCd)
        {
            Guid guid = Guid.NewGuid();

            //�`�[���Z�E�t�H���[�`�[���Z�E�[�����ׁE�[���`�[�E���[�J�[�t�H���[�E�d�n�̏ꍇ
            if ((_uoeSndRcvJnlAcs.uOESetting.FollowSlipOutputDiv == (int)EnumUoeConst.ctFollowSlipOutputDiv.ct_Add)
            || (CheckAddingUp() == true)
            || (detailCd == (int)PrtSalesDetail.ctDetailCd.ct_Zero)
            || (partySaleSlipNum.Trim() == ""))
            {
            }
            //�ʏ햾�ׂ̏ꍇ
            else
            {
                string keyNo = no.ToString("d9") + rowNo.ToString("d4") + partySaleSlipNum.Trim();

                if (_linkSalesStockDictionary.ContainsKey(keyNo) != true)
                {
                    _linkSalesStockDictionary.Add(keyNo, guid);
                }
            }
            return(guid);
        }
        # endregion

        # endregion
    }

}

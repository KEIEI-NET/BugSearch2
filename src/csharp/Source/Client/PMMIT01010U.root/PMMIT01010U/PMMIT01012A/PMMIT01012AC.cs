using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using System.IO;

using Broadleaf.Application.UIData;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using System.Windows.Forms;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;
//using Broadleaf.Application.LocalAccess;

namespace Broadleaf.Application.Controller
{
	/// <summary>
	/// �������ϗp�����l�擾�A�N�Z�X�N���X
	/// </summary>
	/// <remarks>
    /// <br>Note       : �������ς̏����l�擾�f�[�^������s���܂��B</br>
	/// <br>Programmer : 21024�@���X�� ��</br>
	/// <br>Date       : 2008.05.21</br>
	/// <br></br>
	/// <br>UpDate</br>
	/// <br>2008.05.21 men �V�K�쐬</br>
    /// <br>2009.07.16 22018 ��� ���b MANTIS[0013802] �a�k�R�[�h�K�C�h�̏����\�����[�h��ݒ�\�ɕύX�B</br>
    /// <br></br>
    /// <br>Update Note: 2009/10/22 ������</br>
    /// <br>             PM.NS-3-A�EPM.NS�ێ�˗��A</br>
    /// <br>             �ێ�˗��A�̒ǉ�</br>
    /// <br>Update Note: 2010/05/17 �H��</br>
    /// <br>             �i���\���Ή�</br>
    /// <br>Update Note: 2010/06/08�@�����@��Q���ǑΉ��i�V�������[�X���j�̑Ή�</br>
    /// <br>             �@���Ϗ�������̃G���[�Ή�</br>
    /// /// <br>UpdateNote : 2011/02/14 liyp</br>
    /// <br>            �Y���̕��i��񂪖����Ă��s�a�n������\������悤�ɕύX�iMANTIS : 16624�j</br>
    /// </remarks>
	public partial class EstimateInputInitDataAcs
	{
		# region ���R���X�g���N�^
		/// <summary>
		/// �f�t�H���g�R���X�g���N�^�iSingleton�f�U�C���p�^�[�����̗p���Ă���ׁAprivate�Ƃ���j
		/// </summary>
		private EstimateInputInitDataAcs()
		{
            // �i�ԕK�{���[�h
            this._inputMode = ctINPUTMODE_GoodsNoNecessary;
        }

		/// <summary>
        /// �������ϗp�����l�擾�A�N�Z�X�N���X �C���X�^���X�擾����
		/// </summary>
        /// <returns>�������ϗp�����l�擾�A�N�Z�X�N���X �C���X�^���X</returns>
		public static EstimateInputInitDataAcs GetInstance()
		{
			if (_stockSlipInputInitDataAcs == null)
			{
				_stockSlipInputInitDataAcs = new EstimateInputInitDataAcs();
			}

			return _stockSlipInputInitDataAcs;
		}
		# endregion

		# region ���v���C�x�[�g�ϐ�
		private static EstimateInputInitDataAcs _stockSlipInputInitDataAcs;

		private List<StockProcMoney> _stockProcMoneyList;
		private List<SalesProcMoney> _salesProcMoneyList;
        private List<SlipPrtSet> _slipPrtSetList;
        private List<CustSlipMng> _custSlipMngList;
        private List<Employee> _employeeList;
        private List<EmployeeDtl> _employeeDtlList;
        private List<Warehouse> _warehouseList;
        private List<MakerUMnt> _makerUMntList;
        private List<BLGoodsCdUMnt> _blGoodsCdUMntList;
        private List<SubSection> _subSectionList;
        private List<UOEGuideName> _uoeEGuideNameList;
        private SalesTtlSt _salesTtlSt;

		private GoodsAcs _goodsAcs;
		private TaxRateSet _taxRateSet;
		private AllDefSet _allDefSet;
		//private AcptAnOdrTtlSt _acptAnOdrTtlSt;
		//private StockTtlSt _stockTtlSt;
		private EstimateDefSet _estimateDefSet;
        private PosTerminalMg _posTerminalMg;
        private CompanyInf _companyInf;
        private UOESetting _uoeSetting;

        /// <summary>�I�v�V�������</summary>
        private bool _opt_CarMng;
        private bool _opt_FreeSearch;
        private bool _opt_UOE;

        /// <summary>�v���O����ID</summary>
		private static string ctPGID = "PMMIT01012A";

        /// <summary> ���̓��[�h</summary>
        private int _inputMode;

        private bool _readInitialData = false;
        private bool _readInitialData2 = false;

        //------------ADD 2009/10/22-------->>>>>
        private ArrayList _custRateGrpCodeList;
        private List<PriceSelectSet> _displayDivList;
        //------------ADD 2009/10/22--------<<<<<
		# endregion

		#region ���萔

        /// <summary>�[�������Ώۋ��z�敪�i���z�j</summary>
        public const int ctFracProcMoneyDiv_Price = 0;
        /// <summary>�[�������Ώۋ��z�敪�i����Łj</summary>
        public const int ctFracProcMoneyDiv_Tax = 1;
        /// <summary>�[�������Ώۋ��z�敪�i�P���j</summary>
        public const int ctFracProcMoneyDiv_UnitPrice = 2;

        /// <summary>UOE�K�C�h�敪�i�a�n�j</summary>
        public const int ctUOEGuideDivCd_BoCode = 1;
        /// <summary>UOE�K�C�h�敪�i�[�i�敪�j</summary>
        public const int ctUOEGuideDivCd_DeliveredGoodsDiv = 2;
        /// <summary>UOE�K�C�h�敪�i�w�苒�_�j</summary>
        public const int ctUOEGuideDivCd_UOEResvdSection = 3;


		/// <summary>���_�R�[�h(�S�Ћ���)</summary>
		private const string ctSectionCode_Common = "00";

		#endregion 

		#region ���f���Q�[�g

		/// <summary>�d�����z�����敪�ݒ�L���b�V���f���Q�[�g</summary>
		public delegate void CacheStockProcMoneyListEventHandler( List<StockProcMoney> stockProcMoneyList );

		/// <summary>������z�����敪�ݒ�L���b�V���f���Q�[�g</summary>
		public delegate void CacheSalesProcMoneyListEventHandler( List<SalesProcMoney> salesProcMoneyList );

		#endregion

		#region ���C�x���g
		/// <summary>�d�����z�����敪�ݒ�Z�b�g�C�x���g</summary>
		public event CacheStockProcMoneyListEventHandler CacheStockProcMoneyList;
		/// <summary>������z�����敪�ݒ�L���b�V���C�x���g</summary>
		public event CacheSalesProcMoneyListEventHandler CacheSalesProcMoneyList;
		#endregion

		# region ���p�u���b�N�ϐ�
		/// <summary>���[�U�[�K�C�h�敪�R�[�h�i�ԕi���R�j</summary>
		public static readonly int ctDIVCODE_UserGuideDivCd_RetGoodsReason = 91;

        /// <summary>���l�K�C�h�敪�R�[�h�i���l�P�j</summary>
        public static readonly int ctDIVCODE_NoteGuid_StockSlipNote1 = 103;
        /// <summary>���l�K�C�h�敪�R�[�h�i���l�Q�j</summary>
        public static readonly int ctDIVCODE_NoteGuid_StockSlipNote2 = 104;

        /// <summary>�i�ԕK�{���[�h</summary>
        public static readonly int ctINPUTMODE_GoodsNoNecessary = 1;

		# endregion

		#region ���v���p�e�B

		/// <summary>
		/// ���̓��[�h
		/// </summary>
		public int InputMode
		{
			get { return this._inputMode; }
		}

		/// <summary>�d�����z�����敪�ݒ胊�X�g</summary>
		public List<StockProcMoney> StockProcMoneyList
		{
			get { return this._stockProcMoneyList; }
		}

		/// <summary>������z�����敪�ݒ胊�X�g</summary>
		public List<SalesProcMoney> SalesProcMoneyList
		{
			get { return this._salesProcMoneyList; }

		}

        /// <summary>�`�[����ݒ�}�X�^���X�g</summary>
        public List<SlipPrtSet> SlipPrintSetList
        {
            get { return _slipPrtSetList; }
            set { _slipPrtSetList = value; }
        }

        /// <summary>���Ӑ�}�X�^�i�`�[�Ǘ��j���X�g</summary>
        public List<CustSlipMng> CustSlipMngList
        {
            get { return _custSlipMngList; }
            set { _custSlipMngList = value; }
        }

        /// <summary>�ԗ��Ǘ��I�v�V����</summary>
        public bool Opt_CarMng
        {
            get { return this._opt_CarMng; }
            set { this._opt_CarMng = value; }
        }

        /// <summary>���R�����I�v�V����</summary>
        public bool Opt_FreeSearch
        {
            get { return this._opt_FreeSearch; }
            set { this._opt_FreeSearch = value; }
        }
        /// <summary>�t�n�d�I�v�V����</summary>
        public bool Opt_UOE
        {
            get { return this._opt_UOE; }
            set { this._opt_UOE = value; }
        }

		#endregion

        #region ���񋓑�
       
        #endregion


		# region ���p�u���b�N���\�b�h

		/// <summary>
        /// �������ςŎg�p���鏉���f�[�^���c�a���擾���܂��B
		/// </summary>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="sectionCode">���_�R�[�h</param>
		/// <returns>STATUS</returns>
		public int ReadInitData(string enterpriseCode, string sectionCode)
		{
            //if (this._readInitialData) return 0;

            LogWrite("EstimateInputInitDataAcs", "ReadInitData", "�J�n");
            // �ϐ�������
            this._employeeList = new List<Employee>();
            this._employeeDtlList = new List<EmployeeDtl>();
            this._warehouseList = new List<Warehouse>();
            this._uoeEGuideNameList = new List<UOEGuideName>();
            this._stockProcMoneyList = new List<StockProcMoney>();
            this._salesProcMoneyList = new List<SalesProcMoney>();
            //------------ADD 2009/10/22-------->>>>>
            this._custRateGrpCodeList = new ArrayList();
            this._displayDivList = new List<PriceSelectSet>();
            //------------ADD 2009/10/22--------<<<<<
            try
			{
				int status;

                #region ���]�ƈ��A�]�ƈ��ڍ׃}�X�^�擾
                //-----------------------------------------------------------
				// �]�ƈ��A�]�ƈ��ڍ׃}�X�^�擾
				//-----------------------------------------------------------
                LogWrite("EstimateInputInitDataAcs", "ReadInitData", "�S�]�ƈ������擾");
				EmployeeAcs employeeAcs = new EmployeeAcs();
			
				EmployeeWork paraEmployee = new EmployeeWork();
				paraEmployee.EnterpriseCode = enterpriseCode;

				ArrayList employeeList;
				ArrayList employeeDtlList;
				status = employeeAcs.Search(out employeeList, out employeeDtlList, enterpriseCode);
				if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
				{
                    this._employeeList = new List<Employee>((Employee[])employeeList.ToArray(typeof(Employee)));
                    this._employeeDtlList = new List<EmployeeDtl>((EmployeeDtl[])employeeDtlList.ToArray(typeof(EmployeeDtl)));
                }
                #endregion

                #region ���q�Ƀ}�X�^�擾
                //-----------------------------------------------------------
				// �q�Ƀ}�X�^�擾
				//-----------------------------------------------------------
                LogWrite("EstimateInputInitDataAcs", "ReadInitData", "�q�ɂ��擾");
				ArrayList returnWarehouse;
				WarehouseAcs warehouseAcs = new WarehouseAcs();

				WarehouseWork paraWarehouse = new WarehouseWork();
				paraWarehouse.EnterpriseCode = enterpriseCode;

				status = warehouseAcs.Search(out returnWarehouse, enterpriseCode);

				if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
				{
                    this._warehouseList = new List<Warehouse>((Warehouse[])returnWarehouse.ToArray(typeof(Warehouse)));
                }
                #endregion

                #region ���d�����z�����敪�ݒ�}�X�^
                //-----------------------------------------------------------
				// �d�����z�����敪�ݒ�}�X�^
				//-----------------------------------------------------------
                LogWrite("EstimateInputInitDataAcs", "ReadInitData", "�d�����z�����敪�ݒ���擾");
				StockProcMoneyAcs stockProcMoneyAcs = new StockProcMoneyAcs();

				ArrayList retStockProcMoney;
                StockProcMoneyWork paraStockProcMoneyWork = new StockProcMoneyWork();
                paraStockProcMoneyWork.EnterpriseCode = enterpriseCode;
                paraStockProcMoneyWork.FracProcMoneyDiv = -1;

				status = stockProcMoneyAcs.Search(out retStockProcMoney, enterpriseCode);

				this._stockProcMoneyList = new List<StockProcMoney>();
				if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
				{
                    this._stockProcMoneyList = new List<StockProcMoney>((StockProcMoney[])retStockProcMoney.ToArray(typeof(StockProcMoney)));
                    this._stockProcMoneyList.Sort(new StockProcMoneyComparer());
                }
                #endregion

                #region ��������z�����敪�ݒ�}�X�^
                //-----------------------------------------------------------
				// ������z�����敪�ݒ�}�X�^
				//-----------------------------------------------------------
                LogWrite("EstimateInputInitDataAcs", "ReadInitData", "������z�����敪�ݒ���擾");
				SalesProcMoneyAcs salesProcMoneyAcs = new SalesProcMoneyAcs();
				ArrayList retSalesProcMoney;
				status = salesProcMoneyAcs.Search(out retSalesProcMoney, enterpriseCode);

				if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
				{
                    this._salesProcMoneyList = new List<SalesProcMoney>((SalesProcMoney[])retSalesProcMoney.ToArray(typeof(SalesProcMoney)));
                    this._salesProcMoneyList.Sort(new SalesProcMoneyComparer());
                }
                #endregion

                #region ���S�̏����l�ݒ�}�X�^
                //-----------------------------------------------------------
				// �S�̏����l�ݒ�}�X�^
				//-----------------------------------------------------------
                LogWrite("EstimateInputInitDataAcs", "ReadInitData", "�S�̏����l�ݒ���擾");
				AllDefSetAcs allDefSetAcs = new AllDefSetAcs();
				AllDefSetAcs.SearchMode allDefSetSearchMode = AllDefSetAcs.SearchMode.Remote;
				ArrayList retAllDefSetList;
				status = allDefSetAcs.Search(out retAllDefSetList, enterpriseCode, allDefSetSearchMode);

				if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
				{
					// ���O�C���S���҂̏������_�������͑S�Аݒ���擾
					this._allDefSet = this.GetAllDefSetFromList(LoginInfoAcquisition.Employee.BelongSectionCode, retAllDefSetList);

					if (this._allDefSet != null)
					{
						//this._inputMode = this._allDefSet.GoodsNoInpDiv;
					}
				}
				else
				{
					this._allDefSet = null;
                }
                #endregion

                #region ���ŗ��ݒ�}�X�^
                //-----------------------------------------------------------
				// �ŗ��ݒ�}�X�^
				//-----------------------------------------------------------
                LogWrite("EstimateInputInitDataAcs", "ReadInitData", "����ł��擾");
				ArrayList returnTaxRateSet;

				TaxRateSetAcs taxRateSetAcs = new TaxRateSetAcs();

				TaxRateSetAcs.SearchMode taxRateSetSearchMode = TaxRateSetAcs.SearchMode.Remote;
				status = taxRateSetAcs.Search(out returnTaxRateSet, enterpriseCode, taxRateSetSearchMode);

				if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
				{
					this.CacheTaxRateSet((TaxRateSet)returnTaxRateSet[0]);
				}
				else
				{
					this._taxRateSet = null;
                }
                #endregion

                #region ������S�̐ݒ�}�X�^
                //-----------------------------------------------------------
				// ����S�̐ݒ�}�X�^
				//-----------------------------------------------------------
                LogWrite("EstimateInputInitDataAcs", "ReadInitData", "����S�̐ݒ���擾");
				ArrayList retSalesTtlSt;
				SalesTtlStAcs salesTtlStAcs = new SalesTtlStAcs();

				status = salesTtlStAcs.Search(out retSalesTtlSt, enterpriseCode);

				if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
				{
                    this._salesTtlSt = this.GetSalesTtlStFromList(sectionCode, retSalesTtlSt);
                }
                #endregion

                #region �����Ϗ����l�ݒ�}�X�^
                //-----------------------------------------------------------
				// ���Ϗ����l�ݒ�}�X�^
				//-----------------------------------------------------------
                LogWrite("EstimateInputInitDataAcs", "ReadInitData", "���Ϗ����l�ݒ���擾");
				ArrayList retEstimateDefSet;
				EstimateDefSetAcs estimateDefSetAcs = new EstimateDefSetAcs();

				status = estimateDefSetAcs.Search(out retEstimateDefSet, enterpriseCode);

				if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
				{
                    this._estimateDefSet = this.GetEstimateDefSetFromList(sectionCode, retEstimateDefSet);
                }
                #endregion

                #region ���`�[����ݒ�}�X�^
                //-----------------------------------------------------------
                // �`�[����ݒ�}�X�^
                //-----------------------------------------------------------
                LogWrite("EstimateInputInitDataAcs", "ReadInitData", "�`�[����ݒ�}�X�^���X�g���擾");
                SlipPrtSetAcs slipPrtSetAcs = new SlipPrtSetAcs();
                ArrayList retSlipPrtSet;
                status = slipPrtSetAcs.SearchSlipPrtSet(out retSlipPrtSet, enterpriseCode);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    this._slipPrtSetList = new List<SlipPrtSet>((SlipPrtSet[])retSlipPrtSet.ToArray(typeof(SlipPrtSet)));
                }
                #endregion

                #region ���t�n�d�K�C�h���̃}�X�^
                //-----------------------------------------------------------
                // �t�n�d�K�C�h���̃}�X�^
                //-----------------------------------------------------------
                LogWrite("EstimateInputInitDataAcs", "ReadInitData", "�t�n�d�K�C�h���̃}�X�^���X�g���擾");
                UOEGuideName uOEGuideName = new UOEGuideName();
                uOEGuideName.EnterpriseCode = enterpriseCode;
                uOEGuideName.SectionCode = sectionCode;

                UOEGuideNameAcs uOEGuideNameAcs = new UOEGuideNameAcs();
                ArrayList retUOEGuideNameList;
                status = uOEGuideNameAcs.Search(out retUOEGuideNameList, uOEGuideName);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    this._uoeEGuideNameList = new List<UOEGuideName>((UOEGuideName[])retUOEGuideNameList.ToArray(typeof(UOEGuideName)));

                    this._uoeEGuideNameList.Sort(new UOEGuideNameComparer());
                }
                #endregion

                #region �����Џ��ݒ�ݒ�}�X�^
                //-----------------------------------------------------------
                // ���Џ��ݒ�ݒ�}�X�^
                //-----------------------------------------------------------
                LogWrite("EstimateInputInitDataAcs", "ReadInitData", "���Џ��ݒ�ݒ���擾");
                CompanyInfAcs companyInfAcs = new CompanyInfAcs();
                companyInfAcs.Read(out this._companyInf, enterpriseCode);
                #endregion


                #region �����Ӑ�}�X�^�i�`�[�Ǘ��j
                //-----------------------------------------------------------
                // ���Ӑ�}�X�^�i�`�[�Ǘ��j
                //-----------------------------------------------------------
                LogWrite("EstimateInputInitDataAcs", "ReadInitData", "���Ӑ�}�X�^�i�`�[�Ǘ��j���X�g���擾");
                int count = 0;
                CustSlipMngAcs custSlipMngAcs = new CustSlipMngAcs();
                status = custSlipMngAcs.SearchOnlyCustSlipMng(out count, enterpriseCode);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    this._custSlipMngList = new List<CustSlipMng>((CustSlipMng[])custSlipMngAcs.CustSlipMngList.ToArray(typeof(CustSlipMng)));
                }
                #endregion

                #region ���I�v�V�������
                LogWrite("EstimateInputInitDataAcs", "ReadInitData", "�I�v�V���������擾");
                this.CacheOptionInfo();
                #endregion

                #region ���t�n�d���Ѓ}�X�^
                LogWrite("EstimateInputInitDataAcs", "ReadInitData", "UOE���Ѓ}�X�^���擾");
                UOESettingAcs uOESettingAcs = new UOESettingAcs();
                uOESettingAcs.Read(out this._uoeSetting, enterpriseCode, sectionCode);
                #endregion

                //-----------ADD 2009/10/22--------->>>>>
                #region �����Ӑ�|���O���[�v�R�[�h�}�X�^�擾
                //-----------------------------------------------------------
                // ���Ӑ�|���O���[�v�R�[�h�}�X�^�擾
                //-----------------------------------------------------------
                LogWrite("EstimateInputInitDataAcs", "ReadInitData", "���Ӑ�|���O���[�v�R�[�h�}�X�^�����擾");
                CustRateGroupAcs custRateGroupAcs = new CustRateGroupAcs();
                status = custRateGroupAcs.Search(out this._custRateGrpCodeList, enterpriseCode, ConstantManagement.LogicalMode.GetData0);
                #endregion

                #region ���W�����i�I��ݒ�}�X�^�擾
                //-----------------------------------------------------------
                // �W�����i�I��ݒ�}�X�^�擾
                //-----------------------------------------------------------
                LogWrite("EstimateInputInitDataAcs", "ReadInitData", "�W�����i�I��ݒ�}�X�^�����擾");
                PriceSelectSetAcs priceSelectSetAcs = new PriceSelectSetAcs();
                ArrayList displayDivList;
                status = priceSelectSetAcs.Search(out displayDivList, enterpriseCode);
                this._displayDivList = new List<PriceSelectSet>((PriceSelectSet[])displayDivList.ToArray(typeof(PriceSelectSet)));

#endregion
                //-----------ADD 2009/10/22---------<<<<<
            }
			finally
			{
			}
            LogWrite("EstimateInputInitDataAcs", "ReadInitData", "�I��");

            this._readInitialData = true;

			return 0;
		}

        /// <summary>
        /// ������͂Ŏg�p���鏉���f�[�^���c�a���擾���܂��B
        /// </summary>
        /// <param name="enterpriseCode"></param>
        /// <param name="sectionCode"></param>
        /// <returns></returns>
        public int ReadInitData2(string enterpriseCode, string sectionCode)
        {
            //if (_readInitialData2) return 0;

            this._goodsAcs = new GoodsAcs();

            // �ϐ�������
            this._makerUMntList = new List<MakerUMnt>();
            this._blGoodsCdUMntList = new List<BLGoodsCdUMnt>();
            this._subSectionList = new List<SubSection>();

            ArrayList al = new ArrayList();

            //-----------------------------------------------------------
            // ���i�A�N�Z�X�N���X��������
            //-----------------------------------------------------------
            LogWrite("EstimateInputInitDataAcs", "ReadInitData2", "���i�A�N�Z�X�N���X��������");
            string retMessage;
            this._goodsAcs.SearchInitial(enterpriseCode, sectionCode, out retMessage);

            //-----------------------------------------------------------
            // ���[�J�[�}�X�^
            //-----------------------------------------------------------
            LogWrite("EstimateInputInitDataAcs", "ReadInitData2", "���[�J�[���X�g���擾");
            int status = this._goodsAcs.GetAllMaker(enterpriseCode, out this._makerUMntList);
            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL || this._makerUMntList == null)
            {
                this._makerUMntList = new List<MakerUMnt>();
            }

            //-----------------------------------------------------------
            // BL�R�[�h�}�X�^
            //-----------------------------------------------------------
            LogWrite("EstimateInputInitDataAcs", "ReadInitData2", "BL�R�[�h���X�g���擾");
            status = this._goodsAcs.GetAllBLGoodsCd(enterpriseCode, out this._blGoodsCdUMntList);

            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL || this._blGoodsCdUMntList == null)
            {
                this._blGoodsCdUMntList = new List<BLGoodsCdUMnt>();
            }

            #region ������}�X�^�擾
            //-----------------------------------------------------------
            // ����}�X�^�擾
            //-----------------------------------------------------------
            LogWrite("EstimateInputInitDataAcs", "ReadInitData", "������擾");
            SubSectionAcs subSectionAcs = new SubSectionAcs();
            ArrayList returnSubSection;
            status = subSectionAcs.Search(out returnSubSection, enterpriseCode);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                this._subSectionList = new List<SubSection>((SubSection[])returnSubSection.ToArray(typeof(SubSection)));
            }

            #endregion

            #region ���[���Ǘ��}�X�^
            //-----------------------------------------------------------
            // �[���Ǘ��}�X�^
            //-----------------------------------------------------------
            LogWrite("EstimateInputInitDataAcs", "ReadInitData", "�[���Ǘ��}�X�^���擾");
            PosTerminalMgAcs posTerminalMgAcs = new PosTerminalMgAcs();
            posTerminalMgAcs.Search(out this._posTerminalMg, enterpriseCode);
            #endregion


            _readInitialData2 = true;
            return 0;
        }

        /// <summary>
        /// �L���b�V���C�x���g�R�[��
        /// </summary>
        public void CacheEventCall()
        {
            this.CacheStockProcMoneyListCall();
            this.CacheSalesProcMoneyListCall();
        }

		/// <summary>
		/// ���������f�[�^�̃`�F�b�N
		/// </summary>
		/// <param name="msg"></param>
		/// <returns></returns>
		public bool InitialReadDataCheck( out string msg )
		{
			msg = "";

			if (this.GetTaxRateSet() == null)
			{
				msg = "�ŗ��ݒ�}�X�^�̓o�^���s���Ă��������B";
			}
			else if (this.GetAllDefSet() == null)
			{
				msg = "�S�̏����l�ݒ�}�X�^�̓o�^���s���Ă��������B";
			}
            //else if (this.GetAcptAnOdrTtlSt() == null)
            //{
            //    msg = "�󔭒��Ǘ��S�̐ݒ�}�X�^�̓o�^���s���Ă��������B";
            //}
			//else if (this.GetStockMngTtlSt() == null)
			//{
			//    msg = "�݌ɊǗ��S�̐ݒ�}�X�^�̓o�^���s���Ă��������B";
			//}
            //else if (this.GetStockTtlSt() == null)
            //{
            //    msg = "�d���݌ɑS�̐ݒ�}�X�^�̓o�^���s���Ă��������B";
            //}
			else if (this.GetSalesTtlSt() == null)
			{
				msg = "����S�̐ݒ�}�X�^�̓o�^���s���Ă��������B";
			}
			else if (this.GetEstimateDefSet() == null)
			{
				msg = "���Ϗ����l�ݒ�}�X�^�̓o�^���s���Ă��������B";
			}
            else if (this._posTerminalMg == null)
            {
                msg = "�[���Ǘ��ݒ�}�X�^�̓o�^���s���Ă��������B";
            }

			return msg == "";
		}

		# endregion

		# region ���]�ƈ��}�X�^�L���b�V�����䏈��

		/// <summary>
		/// �]�ƈ����̎擾����
		/// </summary>
		/// <param name="employeeCode">�]�ƈ��R�[�h</param>
		/// <returns>�]�ƈ�����</returns>
        public string GetName_FromEmployee(string employeeCode)
        {
            Employee employee = this.GetEmployeeFromCache(employeeCode);
            return ( employee == null ) ? string.Empty : employee.Name;
        }

		/// <summary>
		/// �]�ƈ��������擾
		/// </summary>
		/// <param name="employeeCode">�]�ƈ��R�[�h</param>
		/// <param name="belongSectionCode">�������_�R�[�h</param>
		/// <param name="belongSubSectionCode">��������R�[�h</param>
        public void GetBelongInfo_FromEmployee(string employeeCode, out string belongSectionCode, out int belongSubSectionCode)
        {
            Employee employee = this.GetEmployeeFromCache(employeeCode);
            EmployeeDtl employeeDtl = this.GetEmployeeDtlFromCache(employeeCode);

            belongSectionCode = ( employee == null ) ? string.Empty : employee.BelongSectionCode;
            belongSubSectionCode = ( employeeDtl == null ) ? 0 : employeeDtl.BelongSubSectionCode;
        }

        /// <summary>
        /// �]�ƈ����擾
        /// </summary>
        /// <param name="employeeCode">�]�ƈ��R�[�h</param>
        /// <returns></returns>
        private Employee GetEmployeeFromCache(string employeeCode)
        {
            return this._employeeList.Find(
                        delegate(Employee employee)
                        {
                            if (employee.EmployeeCode.Trim() == employeeCode.Trim())
                            {
                                return true;
                            }

                            return false;
                        });

        }
		# endregion

		#region ���]�ƈ��ڍ׃}�X�^�L���b�V�����䏈��

        /// <summary>
        /// ��������擾����
        /// </summary>
        /// <param name="employeeCode">�]�ƈ��R�[�h</param>
        /// <param name="subSectionCode">����R�[�h</param>
        public void GetSubSection_FromEmployeeDtl(string employeeCode, out int subSectionCode)
        {
            EmployeeDtl employeeDtl = this.GetEmployeeDtlFromCache(employeeCode);

            subSectionCode = ( employeeDtl == null ) ? 0 : employeeDtl.BelongSubSectionCode;
        }

        /// <summary>
        /// �]�ƈ��ڍ׏��擾
        /// </summary>
        /// <param name="employeeCode">�]�ƈ��R�[�h</param>
        /// <returns></returns>
        private EmployeeDtl GetEmployeeDtlFromCache(string employeeCode)
        {
            return this._employeeDtlList.Find(
                        delegate(EmployeeDtl employeeDtl)
                        {
                            if (employeeDtl.EmployeeCode.Trim() == employeeCode.Trim())
                            {
                                return true;
                            }

                            return false;
                        });

        }
        #endregion

		# region ���q�Ƀ}�X�^�L���b�V�����䏈��
		
		/// <summary>
		/// �q�ɖ��̎擾����
		/// </summary>
		/// <param name="warehouseCode">�q�ɃR�[�h</param>
		/// <returns>�q�ɖ���</returns>
		public string GetName_FromWarehouse(string warehouseCode)
		{
            Warehouse warehouse = this.GetWarehouseFromCache(warehouseCode);

            return ( warehouse == null ) ? string.Empty : warehouse.WarehouseName;
		}

        /// <summary>
        /// �q�ɏ��擾
        /// </summary>
        /// <param name="warehouseCode">�q�ɃR�[�h</param>
        /// <returns></returns>
        private Warehouse GetWarehouseFromCache(string warehouseCode)
        {
            return this._warehouseList.Find(
                        delegate(Warehouse warehouse)
                        {
                            if (warehouse.WarehouseCode.Trim() == warehouseCode.Trim())
                            {
                                return true;
                            }

                            return false;
                        });

        }
		# endregion

		# region ������}�X�^�L���b�V�����䏈��

		/// <summary>
		/// ���喼�̎擾����
		/// </summary>
		/// <param name="subSectionCode">����R�[�h</param>
		/// <returns>���喼��</returns>
		public string GetName_FromSubSection( int subSectionCode)
		{
            SubSection subSection = this.GetSubSectionFromCache(subSectionCode);

            return ( subSection == null ) ? string.Empty : subSection.SubSectionName;
		}
        
        /// <summary>
        /// ������擾
        /// </summary>
        /// <param name="subSectionCode">����R�[�h</param>
        /// <returns></returns>
        private SubSection GetSubSectionFromCache(int subSectionCode)
        {
            return this._subSectionList.Find(
                        delegate(SubSection subSection)
                        {
                            if (subSection.SubSectionCode == subSectionCode)
                            {
                                return true;
                            }

                            return false;
                        });

        }		
        # endregion

		# region ���d���݌ɑS�̐ݒ�}�X�^�L���b�V�����䏈��
#if false
		/// <summary>
		/// �d���S�̐ݒ�}�X�^�̃��X�g������A�w�肵�����_�̐ݒ���擾���܂��B
		/// </summary>
		/// <param name="sectionCode">���_�R�[�h</param>
		/// <param name="stockTtlStArrayList">�d���S�̐ݒ�}�X�^�I�u�W�F�N�g���X�g</param>
		/// <returns>�d���S�̐ݒ�}�X�^�I�u�W�F�N�g</returns>
		private StockTtlSt GetStockTtlStFromList( string sectionCode, ArrayList stockTtlStArrayList )
		{
			StockTtlSt allSecStockTtlSt = null;

			foreach (StockTtlSt stockTtlSt in stockTtlStArrayList)
			{
				if (stockTtlSt.SectionCode.Trim() == sectionCode.Trim())
				{
					return stockTtlSt;
				}
				else if (stockTtlSt.SectionCode.Trim() == ctSectionCode_Common.Trim())
				{
					allSecStockTtlSt = stockTtlSt;
				}
			}

			return allSecStockTtlSt;
		}

		/// <summary>
		/// �d���݌ɑS�̐ݒ�}�X�^�擾����
		/// </summary>
		/// <returns>�d���݌ɑS�̐ݒ�}�X�^�I�u�W�F�N�g</returns>
		public StockTtlSt GetStockTtlSt()
		{
			return this._stockTtlSt;
		}
#endif		
		# endregion

		#region ���󔭒��Ǘ��S�̐ݒ�}�X�^�L���b�V������֘A�i�R�����g�A�E�g�j
#if false
		/// <summary>
		/// �󔭒��Ǘ��S�̐ݒ�}�X�^�̃��X�g������A�w�肵�����_�Ŏg�p����ݒ���擾���܂��B(���_�R�[�h��������ΑS�Аݒ�j
		/// </summary>
		/// <param name="sectionCode">���_�R�[�h</param>
		/// <param name="acptAnOdrTtlStArrayList">�󔭒��Ǘ��S�̐ݒ�}�X�^�I�u�W�F�N�g���X�g</param>
		/// <returns>�󔭒��Ǘ��S�̐ݒ�}�X�^�I�u�W�F�N�g</returns>
		internal AcptAnOdrTtlSt GetAcptAnOdrTtlStFromList( string sectionCode, ArrayList acptAnOdrTtlStArrayList )
		{
			AcptAnOdrTtlSt allSecAcptAnOdrTtlSt = null;

			foreach (AcptAnOdrTtlSt acptAnOdrTtlSt in acptAnOdrTtlStArrayList)
			{
				if (acptAnOdrTtlSt.SectionCode.Trim() == sectionCode.Trim())
				{
					return acptAnOdrTtlSt;
				}
				else if (acptAnOdrTtlSt.SectionCode.Trim() == ctSectionCode_Common.Trim())
				{
					allSecAcptAnOdrTtlSt = acptAnOdrTtlSt;
				}
			}

			return allSecAcptAnOdrTtlSt;
		}

		/// <summary>
		/// �󔭒��Ǘ��S�̐ݒ�}�X�^�擾����
		/// </summary>
		/// <returns>�󔭒��Ǘ��S�̐ݒ�}�X�^�I�u�W�F�N�g</returns>
		public AcptAnOdrTtlSt GetAcptAnOdrTtlSt()
		{
			return this._acptAnOdrTtlSt;
		}
#endif
		#endregion

		# region ���S�̏����l�ݒ�}�X�^�L���b�V�����䏈��

		/// <summary>
		/// �S�̏����l�ݒ�}�X�^��������
		/// </summary>
		/// <returns>�S�̏����l�ݒ�}�X�^�I�u�W�F�N�g</returns>
		public AllDefSet GetAllDefSet()
		{
			return this._allDefSet;
		}

		/// <summary>
		/// �S�̏����l�ݒ�}�X�^�̃��X�g������A�w�肵�����_�Ŏg�p����ݒ���擾���܂��B(���_�R�[�h��������ΑS�Аݒ�j
		/// </summary>
		/// <param name="sectionCode">���_�R�[�h</param>
		/// <param name="allDefSetArrayList">�S�̏����l�ݒ�}�X�^�I�u�W�F�N�g���X�g</param>
		/// <returns>�S�̏����l�ݒ�}�X�^�I�u�W�F�N�g</returns>
		private AllDefSet GetAllDefSetFromList( string sectionCode, ArrayList allDefSetArrayList )
		{
			AllDefSet allSecAllDefSet = null;

			foreach (AllDefSet allDefSet in allDefSetArrayList)
			{
				if (allDefSet.SectionCode.Trim() == sectionCode.Trim())
				{
					return allDefSet;
				}
				else if (allDefSet.SectionCode.Trim() == ctSectionCode_Common.Trim())
				{
					allSecAllDefSet = allDefSet;
				}
			}

			return allSecAllDefSet;
		}

		# endregion

        #region �����Џ��ݒ�}�X�^�L���b�V������֘A

        /// <summary>
        /// ���Џ��ݒ�}�X�^�擾����
        /// </summary>
        /// <returns>���Џ��ݒ�}�X�^�I�u�W�F�N�g</returns>
        public CompanyInf GetCompanyInf()
        {
            return this._companyInf;
        }

        #endregion

		#region ������S�̐ݒ�}�X�^�L���b�V������֘A

		/// <summary>
		/// ����S�̐ݒ�}�X�^�̃��X�g������A�w�肵�����_�̐ݒ���擾���܂��B
		/// </summary>
		/// <param name="sectionCode">���_�R�[�h</param>
		/// <param name="salesTtlStStArrayList">����S�̐ݒ�}�X�^�I�u�W�F�N�g���X�g</param>
		/// <returns>����S�̐ݒ�}�X�^�I�u�W�F�N�g</returns>
		private SalesTtlSt GetSalesTtlStFromList( string sectionCode, ArrayList salesTtlStStArrayList )
		{
			SalesTtlSt allSecSalesTtlSt = null;

			foreach (SalesTtlSt salesTtlSt in salesTtlStStArrayList)
			{
				if (salesTtlSt.SectionCode.Trim() == sectionCode.Trim())
				{
					return salesTtlSt;
				}
				else if (salesTtlSt.SectionCode.Trim() == ctSectionCode_Common.Trim())
				{
					allSecSalesTtlSt = salesTtlSt;
				}
			}

			return allSecSalesTtlSt;
		}

		/// <summary>
		/// ����S�̐ݒ�}�X�^��������
		/// </summary>
		/// <returns>����S�̐ݒ�}�X�^�I�u�W�F�N�g</returns>
		public SalesTtlSt GetSalesTtlSt()
		{
			return this._salesTtlSt;
		}

		#endregion

		# region ���ŗ��ݒ�}�X�^�L���b�V������
		/// <summary>
		/// �ŗ��ݒ�}�X�^�L���b�V������
		/// </summary>
		/// <param name="taxRateSet">�ŗ��ݒ�}�X�^�I�u�W�F�N�g</param>
		internal void CacheTaxRateSet( TaxRateSet taxRateSet )
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
		public double GetTaxRate( DateTime addUpDate )
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

        #region ���[���Ǘ��}�X�^

        /// <summary>
        /// �[���Ǘ��}�X�^���擾���܂��B
        /// </summary>
        /// <returns></returns>
        public PosTerminalMg GetPosTerminalMg()
        {
            return this._posTerminalMg;
        }

        #endregion

		# region �����Ϗ����l�ݒ�}�X�^�L���b�V�����䏈��

		/// <summary>
		/// ���Ϗ����l�ݒ�}�X�^�̃��X�g������A�w�肵�����_�̐ݒ���擾���܂��B
		/// </summary>
		/// <param name="sectionCode">���_�R�[�h</param>
		/// <param name="estimateDefSetArrayList">���Ϗ����l�ݒ�}�X�^�I�u�W�F�N�g���X�g</param>
		/// <returns>���Ϗ����l�ݒ�}�X�^�I�u�W�F�N�g</returns>
		private EstimateDefSet GetEstimateDefSetFromList( string sectionCode, ArrayList estimateDefSetArrayList )
		{
			EstimateDefSet allEstimateDefSet = null;

			foreach (EstimateDefSet estimateDefSet in estimateDefSetArrayList)
			{
				if (estimateDefSet.SectionCode.Trim() == sectionCode.Trim())
				{
					return estimateDefSet;
				}
				else if (estimateDefSet.SectionCode.Trim() == ctSectionCode_Common.Trim())
				{
					allEstimateDefSet = estimateDefSet;
				}
			}

			return allEstimateDefSet;
		}


		/// <summary>
		/// ���Ϗ����l�ݒ�}�X�^��������
		/// </summary>
		/// <returns>���Ϗ����l�ݒ�}�X�^�I�u�W�F�N�g</returns>
		public EstimateDefSet GetEstimateDefSet()
		{
			return this._estimateDefSet;
		}
		# endregion

		# region �����[�J�[�}�X�^�L���b�V�����䏈��

        /// <summary>
        /// ���[�J�[���̎擾����
        /// </summary>
        /// <param name="makerCode">���[�J�[�R�[�h</param>
        /// <param name="makerName">���[�J�[����</param>
        /// <param name="makerKanaName">���[�J�[���̃J�i</param>
        public bool GetName_FromMaker( int makerCode, out string makerName, out string makerKanaName )
        {
            MakerUMnt makerUMnt = this.GetMakerUMntFromCache(makerCode);

            if (makerUMnt == null)
            {
                makerName = string.Empty;
                makerKanaName = string.Empty;
                return false;
            }
            else
            {
                makerName = makerUMnt.MakerName;
                makerKanaName = makerUMnt.MakerKanaName;
                return true;
            }
        }

        /// <summary>
        /// ���[�J�[���擾
        /// </summary>
        /// <param name="makerCode">���[�J�[�R�[�h</param>
        /// <returns></returns>
        private MakerUMnt GetMakerUMntFromCache(int makerCode)
        {
            return this._makerUMntList.Find(
                        delegate(MakerUMnt makerUMnt)
                        {
                            if (makerUMnt.GoodsMakerCd == makerCode)
                            {
                                return true;
                            }

                            return false;
                        });

        }
        # endregion

		# region ��BL�R�[�h�}�X�^�L���b�V�����䏈��
		
        /// <summary>
        /// BL�R�[�h���̎擾����
        /// </summary>
        /// <param name="blGoodsCode">BL�R�[�h</param>
        /// <param name="blGoodsFullName">BL�R�[�h����</param>
        /// <param name="bLGoodsHalfName">BL�R�[�h����(�J�i)</param>
        public void GetName_FromBLGoods( int blGoodsCode, out string blGoodsFullName, out string bLGoodsHalfName )
        {
            BLGoodsCdUMnt blGoodsCdUMnt = this.GetBLGoodsCdUMntFromCache(blGoodsCode);
            blGoodsFullName = ( blGoodsCdUMnt == null ) ? string.Empty : blGoodsCdUMnt.BLGoodsFullName;
            bLGoodsHalfName = ( blGoodsCdUMnt == null ) ? string.Empty : blGoodsCdUMnt.BLGoodsHalfName;
        }

        /// <summary>
        /// BL�R�[�h���擾
        /// </summary>
        /// <param name="blGoodsCode">BL�R�[�h</param>
        /// <returns></returns>
        // DEL 2010/05/17 �i���\���Ή� ---------->>>>>
        //private BLGoodsCdUMnt GetBLGoodsCdUMntFromCache(int blGoodsCode)
        // DEL 2010/05/17 �i���\���Ή� ----------<<<<<
        // ADD 2010/05/17 �i���\���Ή� ---------->>>>>
        internal BLGoodsCdUMnt GetBLGoodsCdUMntFromCache(int blGoodsCode)
        // ADD 2010/05/17 �i���\���Ή� ----------<<<<<
        {
            return this._blGoodsCdUMntList.Find(
                        delegate(BLGoodsCdUMnt blGoodsCdUMnt)
                        {
                            if (blGoodsCdUMnt.BLGoodsCode == blGoodsCode)
                            {
                                return true;
                            }

                            return false;
                        });
        }

        # endregion

        #region ��UOE���Ѓ}�X�^�L���b�V������֘A

        /// <summary>
        /// UOE���Ѓ}�X�^�擾����
        /// </summary>
        /// <returns>���Џ��ݒ�}�X�^�I�u�W�F�N�g</returns>
        public UOESetting GetUOESetting()
        {
            return this._uoeSetting;
        }

        #endregion

        # region ���t�n�d�K�C�h���̃}�X�^�L���b�V�����䏈��

        /// <summary>
		/// �t�n�d�K�C�h���̎擾����
		/// </summary>
        /// <param name="uoeGuideDivCd">�t�n�d�K�C�h�敪</param>
        /// <param name="uoeSupplierCd">�t�n�d������R�[�h</param>
        /// <param name="uoeGuideCode">�t�n�d�K�C�h�R�[�h</param>
        public string GetName_FromUOEGuideName(int uoeGuideDivCd, int uoeSupplierCd, string uoeGuideCode)
		{
            UOEGuideName uoeGuideName = this.GetUOEGuideNameFromCache(uoeGuideDivCd, uoeSupplierCd, uoeGuideCode);

            return ( uoeGuideName == null ) ? string.Empty : uoeGuideName.UOEGuideNm;
		}

        /// <summary>
        /// �t�n�d�K�C�h���̍ŏ��R�[�h�擾����
        /// </summary>
        /// <param name="uoeGuideDivCd">�t�n�d�K�C�h�敪</param>
        /// <param name="uoeSupplierCd">�t�n�d������R�[�h</param>
        /// <param name="uoeGuideCode">�t�n�d�K�C�h�R�[�h</param>
        /// <param name="uoeGuideName">�t�n�d�K�C�h����</param>
        public void GetMinElementFromUOEGuideName(int uoeGuideDivCd, int uoeSupplierCd, out string uoeGuideCode, out string uoeGuideName)
        {
            UOEGuideName findUOEGuideName = this.GetUOEGuideNameFromCache(uoeGuideDivCd, uoeSupplierCd);

            if (findUOEGuideName == null)
            {
                uoeGuideCode = string.Empty;
                uoeGuideName = string.Empty;
            }
            else
            {
                uoeGuideCode = findUOEGuideName.UOEGuideCode;
                uoeGuideName = findUOEGuideName.UOEGuideNm;
            }
        }

        /// <summary>
        /// �t�n�d�K�C�h���̍ŏ��R�[�h�擾����
        /// </summary>
        /// <param name="uoeGuideDivCd">�t�n�d�K�C�h�敪</param>
        /// <param name="uoeSupplierCd">�t�n�d������R�[�h</param>
        public List<UOEGuideName> GetUOEGuideNameListFromCache(int uoeGuideDivCd, int uoeSupplierCd)
        {
            return this._uoeEGuideNameList.FindAll(
                        delegate(UOEGuideName uoeGuideName)
                        {
                            if (( uoeGuideName.UOEGuideDivCd == uoeGuideDivCd ) &&
                                ( uoeGuideName.UOESupplierCd == uoeSupplierCd ))
                            {
                                return true;
                            }

                            return false;
                        });
        }


        /// <summary>
        /// �t�n�d�K�C�h���̏��擾
        /// </summary>
        /// <param name="uoeGuideDivCd">�t�n�d�K�C�h�敪</param>
        /// <param name="uoeSupplierCd">�t�n�d������R�[�h</param>
        /// <returns></returns>
        private UOEGuideName GetUOEGuideNameFromCache(int uoeGuideDivCd, int uoeSupplierCd)
        {
            return this._uoeEGuideNameList.Find(
                        delegate(UOEGuideName uoeGuideName)
                        {
                            if (( uoeGuideName.UOEGuideDivCd == uoeGuideDivCd ) &&
                                ( uoeGuideName.UOESupplierCd == uoeSupplierCd ))
                            {
                                return true;
                            }

                            return false;
                        });
        }

        /// <summary>
        /// �t�n�d�K�C�h���̏��擾
        /// </summary>
        /// <param name="uoeGuideDivCd">�t�n�d������R�[�h</param>
        /// <param name="uoeSupplierCd">�t�n�d�K�C�h�R�[�h</param>
        /// <param name="uoeGuideCode">�t�n�d�K�C�h�敪</param>
        /// <returns></returns>
        private UOEGuideName GetUOEGuideNameFromCache(int uoeGuideDivCd, int uoeSupplierCd, string uoeGuideCode)
        {
            return this._uoeEGuideNameList.Find(
                        delegate(UOEGuideName uoeGuideName)
                        {
                            if (( uoeGuideName.UOEGuideDivCd == uoeGuideDivCd ) &&
                                ( uoeGuideName.UOESupplierCd == uoeSupplierCd ) &&
                                ( uoeGuideName.UOEGuideCode == uoeGuideCode ))
                            {
                                return true;
                            }

                            return false;
                        });
        }
        # endregion

        # region ���d�����z�����敪�ݒ�}�X�^�L���b�V�����䏈��
        
        /// <summary>
        /// �d�����z�����敪�ݒ�L���b�V���f���Q�[�g �R�[������
        /// </summary>
        private void CacheStockProcMoneyListCall()
        {
            if (this.CacheStockProcMoneyList != null)
            {
                this.CacheStockProcMoneyList(this._stockProcMoneyList);
            }
        }

        # endregion

        #region ���d�����z�����敪�ݒ�}�X�^ �f�[�^�擾�����֘A
        /// <summary>
        /// �d�����z�����敪�ݒ�}�X�^���A�Ώۋ��z�ɊY������[�������P�ʁA�[�������R�[�h���擾���܂��B
        /// </summary>
        /// <param name="fracProcMoneyDiv">�[�������Ώۋ��z�敪</param>
        /// <param name="fractionProcCode">�[�������R�[�h</param>
        /// <param name="price">�Ώۋ��z</param>
        /// <param name="fractionProcUnit">�[�������P��</param>
        /// <param name="fractionProcCd">�[�������敪</param>
        public void GetStockFractionProcInfo(int fracProcMoneyDiv, int fractionProcCode, double price, out double fractionProcUnit, out int fractionProcCd)
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

            if (_stockProcMoneyList == null || _stockProcMoneyList.Count == 0) return;

            List<StockProcMoney> stockProcMoneyList = _stockProcMoneyList.FindAll(
                                        delegate(StockProcMoney stockProcMoney)
                                        {
                                            if (( stockProcMoney.FracProcMoneyDiv == fracProcMoneyDiv ) &&
                                                ( stockProcMoney.FractionProcCode == fractionProcCode ) &&
                                                ( stockProcMoney.UpperLimitPrice >= price ))
                                            {
                                                return true;
                                            }
                                            else
                                            {
                                                return false;
                                            }
                                        });
            if (stockProcMoneyList != null && stockProcMoneyList.Count > 0)
            {
                fractionProcUnit = stockProcMoneyList[0].FractionProcUnit;
                fractionProcCd = stockProcMoneyList[0].FractionProcCd;
            }
        }
        #endregion

        # region ��������z�����敪�ݒ�}�X�^�L���b�V�����䏈��
        
        /// <summary>
        /// ������z�����敪�ݒ�L���b�V���f���Q�[�g �R�[������
        /// </summary>
        private void CacheSalesProcMoneyListCall()
        {
            if (this.CacheSalesProcMoneyList != null)
            {
                this.CacheSalesProcMoneyList(this._salesProcMoneyList);
            }
        }


        # endregion

        #region ��������z�����敪�ݒ�}�X�^ �f�[�^�擾�����֘A

        /// <summary>
        /// ������z�����敪�ݒ�}�X�^���A�Ώۋ��z�ɊY������[�������P�ʁA�[�������R�[�h���擾���܂��B
        /// </summary>
        /// <param name="fracProcMoneyDiv">�[�������Ώۋ��z�敪</param>
        /// <param name="fractionProcCode">�[�������R�[�h</param>
        /// <param name="price">�Ώۋ��z</param>
        /// <param name="fractionProcUnit">�[�������P��</param>
        /// <param name="fractionProcCd">�[�������敪</param>
        public void GetSalesFractionProcInfo(int fracProcMoneyDiv, int fractionProcCode, double price, out double fractionProcUnit, out int fractionProcCd)
        {
            //�f�t�H���g
            switch (fracProcMoneyDiv)
            {
                case ctFracProcMoneyDiv_UnitPrice:	// �P��
                    fractionProcUnit = 0.01;
                    break;
                default:
                    fractionProcUnit = 1;			// �P���ȊO��1�~�P��
                    break;
            }
            fractionProcCd = 1;     // �؎̂�

            if (_salesProcMoneyList == null || _salesProcMoneyList.Count == 0) return;

            List<SalesProcMoney> salesProcMoneyList = _salesProcMoneyList.FindAll(
                                        delegate(SalesProcMoney salesProcMoney)
                                        {
                                            if (( salesProcMoney.FracProcMoneyDiv == fracProcMoneyDiv ) &&
                                                ( salesProcMoney.FractionProcCode == fractionProcCode ) &&
                                                ( salesProcMoney.UpperLimitPrice >= price ))
                                            {
                                                return true;
                                            }
                                            else
                                            {
                                                return false;
                                            }
                                        });
            if (salesProcMoneyList != null && salesProcMoneyList.Count > 0)
            {
                fractionProcUnit = salesProcMoneyList[0].FractionProcUnit;
                fractionProcCd = salesProcMoneyList[0].FractionProcCd;
            }
        }
        #endregion

        # region �����i�֘A����
        /// <summary>
        /// ���i�f�[�^���X�g��������
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="makerCodeList">���[�J�[�R�[�h���X�g</param>
        /// <param name="goodsCodeList">���i�R�[�h���X�g</param>
        /// <returns>���i�f�[�^���X�g</returns>
        public List<GoodsUnitData> CreateGoodsUnitDataList(string enterpriseCode, string sectionCode, List<int> makerCodeList, List<string> goodsCodeList)
        {
            List<GoodsUnitData> goodsUnitDataList = new List<GoodsUnitData>();

            for (int i = 0; i < makerCodeList.Count; i++)
            {
                GoodsUnitData goodsUnitData;
                int status = this._goodsAcs.Read(enterpriseCode, sectionCode, makerCodeList[i], goodsCodeList[i], out goodsUnitData);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    goodsUnitDataList.Add(goodsUnitData);
                }
            }

            return goodsUnitDataList;
        }

        /// <summary>
        /// �����^�C�v�擾����
        /// </summary>
        /// <param name="inputCode">���͂��ꂽ�R�[�h</param>
        /// <param name="searchCode">�����p�R�[�h�i*�������j</param>
        /// <returns>0:���S��v���� 1:�O����v���� 2:�����v���� 3:�B������</returns>
        public static int GetSearchType(string inputCode, out string searchCode)
        {
            searchCode = inputCode;
            if (String.IsNullOrEmpty(inputCode)) return 0;

            if (inputCode.Contains("*"))
            {
                searchCode = inputCode.Replace("*", "");
                string firstString = inputCode.Substring(0, 1);
                string lastString = inputCode.Substring(inputCode.Length - 1, 1);

                if (( firstString == "*" ) && ( lastString == "*" ))
                {
                    return 3;
                }
                else if (firstString == "*")
                {
                    return 2;
                }
                else if (lastString == "*")
                {
                    return 1;
                }
                else
                {
                    return 3;
                }
            }
            // *�����A-�L��͊��S��v����
            else if (inputCode.Contains("-"))
            {
                return 0;
            }
            // *�����A-�����̓n�C�t�������i�Ԍ���
            else
            {

                return 4;
            }
        }

        /// <summary>
        /// �w�肵�����i�R�[�h�����ɏ��i�����擾���܂��B
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="makerCode">���[�J�[�R�[�h</param>
        /// <param name="goodsCode">���i�R�[�h</param>
        /// <param name="goodsUnitData">���i���I�u�W�F�N�g�iout�j</param>
        /// <returns>STATUS</returns>
        public int GetGoodsUnitData(string enterpriseCode, string sectionCode, int makerCode, string goodsCode, out GoodsUnitData goodsUnitData)
        {
            return this._goodsAcs.Read(enterpriseCode, sectionCode, makerCode, goodsCode, out goodsUnitData);
        }

        /// <summary>
        /// �w�肵�����i�R�[�h�����ɏ��i�����擾���܂��B�i�I�[�o�[���[�h�j
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="goodsCode">���i�R�[�h</param>
        /// <param name="goodsUnitDataList">���i���I�u�W�F�N�g���X�g</param>
        /// <returns>STATUS</returns>
        public int GetGoodsUnitData(string enterpriseCode, string sectionCode, string goodsCode, out List<GoodsUnitData> goodsUnitDataList)
        {
            return this._goodsAcs.Read(enterpriseCode, sectionCode, goodsCode, out goodsUnitDataList);
        }

        /// <summary>
        /// �i�Ԍ���
        /// </summary>
        /// <param name="owner"></param>
        /// <param name="goodsCndtn"></param>
        /// <param name="partsInfoDataSet"></param>
        /// <param name="goodsUnitDataList"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public int SearchParts(IWin32Window owner, GoodsCndtn goodsCndtn, out PartsInfoDataSet partsInfoDataSet, out List<GoodsUnitData> goodsUnitDataList, out string msg)
        {
            this._goodsAcs.Owner = owner;
            return this._goodsAcs.SearchPartsFromGoodsNo(goodsCndtn, out partsInfoDataSet, out goodsUnitDataList, out msg);
        }

        /// <summary>
        /// BL�R�[�h���i����
        /// </summary>
        /// <param name="owner"></param>
        /// <param name="goodsCndtn">��������</param>
        /// <param name="partsInfoDataSet">���i�����f�[�^�Z�b�g</param>
        /// <param name="goodsUnitDataList">���i���I�u�W�F�N�g���X�g</param>
        /// <param name="msg"></param>
        /// <returns>STATUS</returns>
        public int BLPartsSearch(IWin32Window owner, GoodsCndtn goodsCndtn, out PartsInfoDataSet partsInfoDataSet, out List<GoodsUnitData> goodsUnitDataList, out string msg)
        {
            this._goodsAcs.Owner = owner;
            return this._goodsAcs.SearchPartsFromBLCode(goodsCndtn, out partsInfoDataSet, out goodsUnitDataList, out msg);
        }

        /// <summary>
        /// ���i�A���f�[�^�s�����ݒ�
        /// </summary>
        /// <param name="goodsUnitDataList">���i�A���f�[�^�I�u�W�F�N�g���X�g</param>
        /// <param name="isSettingSupplier">True:�d����Z�b�g����</param>
        /// <returns></returns>
        public void SettingGoodsUnitDataListFromVariousMst(ref List<GoodsUnitData> goodsUnitDataList, bool isSettingSupplier)
        {
            List<GoodsUnitData> retGoodsUnitDataList = new List<GoodsUnitData>();
            foreach (GoodsUnitData goodsUnitData in goodsUnitDataList)
            {
                GoodsUnitData retGoodsUnitData = goodsUnitData.Clone();
                this.SettingGoodsUnitDataListFromVariousMst(ref retGoodsUnitData, isSettingSupplier);
                retGoodsUnitDataList.Add(retGoodsUnitData);
            }
            goodsUnitDataList = retGoodsUnitDataList;
        }

        /// <summary>
        /// ���i�A���f�[�^�s�����ݒ�
        /// </summary>
        /// <param name="goodsUnitData">���i�A���f�[�^�I�u�W�F�N�g</param>
        /// <param name="isSettingSupplier">�d����擾�L��</param>
        /// <returns></returns>
        public void SettingGoodsUnitDataListFromVariousMst(ref GoodsUnitData goodsUnitData, bool isSettingSupplier)
        {
            this._goodsAcs.SettingGoodsUnitDataFromVariousMst(ref goodsUnitData, ( isSettingSupplier ) ? 0 : 1);
        }

        /// <summary>
        /// TBO����
        /// </summary>
        /// <param name="owner"></param>
        /// <param name="cndtn">���i�������o�����N���X</param>
        /// <param name="partsInfoDataSet">���i�����f�[�^�Z�b�g</param>
        /// <param name="goodsUnitDataList">���i�A���f�[�^�I�u�W�F�N�g���X�g</param>
        /// <param name="msg">�G���[���b�Z�[�W</param>
        /// <br>UpdateNote : 2011/02/11 liyp</br>
        /// <br>            �Y���̕��i��񂪖����Ă��s�a�n������\������悤�ɕύX�iMANTIS : 16624�j</br>
        /// <returns></returns>           
        public int SearchTBO(IWin32Window owner, GoodsCndtn cndtn, out PartsInfoDataSet partsInfoDataSet, out List<GoodsUnitData> goodsUnitDataList, out string msg)
        {
            this._goodsAcs.Owner = owner;
            // return this._goodsAcs.SearchTBO(cndtn, out partsInfoDataSet, out  goodsUnitDataList, out msg); // DEL 2011/02/14
            return this._goodsAcs.SearchTBOForButton(cndtn, out partsInfoDataSet, out  goodsUnitDataList, out msg); // ADD 2011/02/14
        }

        /// <summary>
        /// BL�R�[�h�K�C�h�N��
        /// </summary>
        /// <param name="owner"></param>
        /// <param name="bLGoodsCdUMntList"></param>
        /// <param name="searchCarInfo"></param>
        /// <returns></returns>
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.07.16 DEL
        //public int ExecuteBLGoodsCd(IWin32Window owner, out List<BLGoodsCdUMnt> bLGoodsCdUMntList, PMKEN01010E searchCarInfo)
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.07.16 DEL
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.07.16 ADD
        public int ExecuteBLGoodsCd(IWin32Window owner, out List<BLGoodsCdUMnt> bLGoodsCdUMntList, PMKEN01010E searchCarInfo, string sectionCode, int customerCode, GoodsAcs.BLGuideMode blGuideMode )
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.07.16 ADD
        {
            this._goodsAcs.Owner = owner;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.07.16 DEL
            //return this._goodsAcs.ExecuteBLGoodsCd(out bLGoodsCdUMntList, searchCarInfo, LoginInfoAcquisition.Employee.BelongSectionCode);
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.07.16 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.07.16 ADD
            return this._goodsAcs.ExecuteBLGoodsCd( out bLGoodsCdUMntList, searchCarInfo, sectionCode, customerCode, blGuideMode );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.07.16 ADD
        }

        /// <summary>
        /// �i�Ԍ���(���i���ꊇ�擾)
        /// </summary>
        /// <param name="goodsCndtnList">���i���������I�u�W�F�N�g���X�g</param>
        /// <param name="goodsUnitDataListList">���i�A���f�[�^�I�u�W�F�N�g���X�g���X�g</param>
        /// <param name="msg">���b�Z�[�W</param>
        /// <returns>�����߂�l</returns>
        /// <remarks>
        /// <br>Update Note: 2010/06/08�@�����@���Ϗ�������̃G���[�Ή�</br>
        /// </remarks>
        public int SearchPartsFromGoodsNoNonVariousSearchWholeWord(List<GoodsCndtn> goodsCndtnList, out List<List<GoodsUnitData>> goodsUnitDataListList, out String msg)
        {
            // --- ADD 2010/06/08 ---------->>>>>
            if (goodsCndtnList == null || goodsCndtnList.Count == 0)
            {
                goodsUnitDataListList = new List<List<GoodsUnitData>>();
                msg = string.Empty;
                return (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
            }
            else
            {
                return this._goodsAcs.SearchPartsFromGoodsNoNonVariousSearchWholeWord(goodsCndtnList, out goodsUnitDataListList, out msg);
            }
            //return this._goodsAcs.SearchPartsFromGoodsNoNonVariousSearchWholeWord(goodsCndtnList, out goodsUnitDataListList, out msg);
            // --- ADD 2010/06/08 ----------<<<<<
        }

        /// <summary>
        /// �i�Ԍ���(���i���ꊇ�擾)�����������L��
        /// </summary>
        /// <param name="goodsCndtnList">���i���������I�u�W�F�N�g���X�g</param>
        /// <param name="partsInfoDataSetList">���i�����f�[�^�Z�b�g���X�g</param>
        /// <param name="goodsUnitDataListList">���i�A���f�[�^�I�u�W�F�N�g���X�g���X�g</param>
        /// <param name="msg">���b�Z�[�W</param>
        /// <returns></returns>
        public int SearchPartsFromGoodsNoWholeWord(List<GoodsCndtn> goodsCndtnList, out List<PartsInfoDataSet> partsInfoDataSetList, out List<List<GoodsUnitData>> goodsUnitDataListList, out String msg)
        {
            return this._goodsAcs.SearchPartsFromGoodsNoWholeWord(goodsCndtnList, out partsInfoDataSetList, out goodsUnitDataListList, out msg);
        }

        /// <summary>
        /// ���i�A���f�[�^�̏��i���i���X�g����A�Ώۓ��̏��i���i�����擾���܂��B
        /// </summary>
        /// <param name="targetDate">�Ώۓ��t</param>
        /// <param name="goodsUnitData">���i�A���f�[�^</param>
        /// <returns>���i���i�f�[�^</returns>
        internal GoodsPrice GetGoodsPrice(DateTime targetDate, GoodsUnitData goodsUnitData)
        {
            return this._goodsAcs.GetGoodsPriceFromGoodsPriceList(targetDate, goodsUnitData.GoodsPriceList);
        }

        /// <summary>
        /// ���i��񂩂�w��q�ɂ̍݌ɏ����擾���܂��B
        /// </summary>
        /// <param name="goodsUnitData">���i���I�u�W�F�N�g</param>
        /// <param name="warehouseCdArray">�q�ɔz��</param>
        /// <returns>�݌ɃI�u�W�F�N�g</returns>
        public Stock GetStockFromGoodsUnitData(GoodsUnitData goodsUnitData, string[] warehouseCdArray)
        {
            Stock retStock = null;

            if (( goodsUnitData != null ) && ( goodsUnitData.StockList != null ))
            {
                foreach (string warehouseCode in warehouseCdArray)
                {
                    if (!string.IsNullOrEmpty(warehouseCode.Trim()))
                    {
                        retStock = this._goodsAcs.GetStockFromStockList(warehouseCode, goodsUnitData.GoodsMakerCd, goodsUnitData.GoodsNo, goodsUnitData.StockList);

                        if (retStock != null)
                        {
                            break;
                        }
                    }
                }
            }

            return retStock;
        }

        /// <summary>
        /// BL�R�[�h�ɘA������BL�R�[�h�}�X�^���ABL�O���[�v�R�[�h���A���i�����ޏ��A���i�啪�ޏ����擾���܂��B
        /// </summary>
        /// <param name="bLGoodsCode">BL�R�[�h</param>
        /// <param name="bLGoodsCdUMnt">BL�R�[�h�}�X�^</param>
        /// <param name="bLGroupU">�O���[�v�R�[�h�}�X�^</param>
        /// <param name="goodsGroupU">���i�����ރ}�X�^</param>
        /// <param name="userGdBdU">���i�啪�ރ}�X�^�i���[�U�[�K�C�h�j</param>
        /// <returns>True:�擾����</returns>
        public bool GetBLGoodsRelation(int bLGoodsCode, out BLGoodsCdUMnt bLGoodsCdUMnt, out BLGroupU bLGroupU, out GoodsGroupU goodsGroupU, out UserGdBdU userGdBdU)
        {
            this._goodsAcs.GetBLGoodsRelation(bLGoodsCode, out bLGoodsCdUMnt, out bLGroupU, out goodsGroupU, out userGdBdU);

            return !( ( bLGoodsCdUMnt.BLGoodsCode == 0 ) && ( string.IsNullOrEmpty(bLGoodsCdUMnt.BLGoodsName) ) );
        }

        # endregion


        #region Sort�p�N���X

        /// <summary>
        /// UOE�K�C�h���̃}�X�^��r�N���X(UOE�K�C�h�敪(����)�AUOE������R�[�h(����)�AUOE�K�C�h�R�[�h(����))
        /// </summary>
        /// <remarks></remarks>
        public class UOEGuideNameComparer : Comparer<UOEGuideName>
        {
            /// <summary>
            /// 
            /// </summary>
            /// <param name="x"></param>
            /// <param name="y"></param>
            /// <returns></returns>
            public override int Compare(UOEGuideName x, UOEGuideName y)
            {
                int result = x.UOEGuideDivCd.CompareTo(y.UOEGuideDivCd);
                if (result != 0) return result;

                result = x.UOESupplierCd.CompareTo(y.UOESupplierCd);
                if (result != 0) return result;

                result = x.UOEGuideCode.CompareTo(y.UOEGuideCode);
                return result;
            }
        }

        /// <summary>
        /// �d�����z�����敪�}�X�^�f�[�^��r�N���X(�[�������Ώۋ��z(����)�A�[�������R�[�h(����)�A������z(����))
        /// </summary>
        /// <remarks></remarks>
        internal class StockProcMoneyComparer : Comparer<StockProcMoney>
        {

            public override int Compare(StockProcMoney x, StockProcMoney y)
            {
                int result = x.FracProcMoneyDiv.CompareTo(y.FracProcMoneyDiv);
                if (result != 0) return result;

                result = x.FractionProcCode.CompareTo(y.FractionProcCode);
                if (result != 0) return result;

                result = x.UpperLimitPrice.CompareTo(y.UpperLimitPrice);
                return result;
            }
        }

        /// <summary>
        /// ������z�����敪�}�X�^�f�[�^��r�N���X(�[�������Ώۋ��z(����)�A�[�������R�[�h(����)�A������z(����))
        /// </summary>
        /// <remarks></remarks>
        internal class SalesProcMoneyComparer : Comparer<SalesProcMoney>
        {

            public override int Compare(SalesProcMoney x, SalesProcMoney y)
            {
                int result = x.FracProcMoneyDiv.CompareTo(y.FracProcMoneyDiv);
                if (result != 0) return result;

                result = x.FractionProcCode.CompareTo(y.FractionProcCode);
                if (result != 0) return result;

                result = x.UpperLimitPrice.CompareTo(y.UpperLimitPrice);
                return result;
            }
        }


        #endregion


        #region ���I�v�V������񐧌䏈��
        /// <summary>
        /// �I�v�V�������L���b�V��
        /// </summary>
        private void CacheOptionInfo()
        {
            Broadleaf.Application.Remoting.ParamData.PurchaseStatus ps;

            #region ���ԗ��Ǘ��I�v�V����
            ps = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_PM_CarMng);
            this._opt_CarMng = ( ps == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract );
            #endregion

            #region �����R�����I�v�V����
            ps = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_PM_FreeSearch);
            this._opt_FreeSearch = ( ps == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract );
            #endregion

            #region ���t�n�d�I�v�V����
            ps = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_PM_UOE);
            this._opt_UOE = ( ps == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract );
            #endregion
        }
        #endregion

        #region ���f�o�b�O�p���O�o��
        /// <summary>
		/// ���O�o��(DEBUG)����
		/// </summary>
		/// <param name="pMsg">���b�Z�[�W</param>
		public static void LogWrite(string pMsg)
		{
			#if DEBUG
			System.IO.FileStream _fs;										// �t�@�C���X�g���[��
			System.IO.StreamWriter _sw;										// �X�g���[��writer
				_fs = new FileStream("PMMIT01010.Log", FileMode.Append, FileAccess.Write, FileShare.Write);
			_sw = new System.IO.StreamWriter(_fs, System.Text.Encoding.GetEncoding("shift_jis"));
			DateTime edt = DateTime.Now;
			//yyyy/MM/dd hh:mm:ss
			_sw.WriteLine(string.Format("{0,-19} {1,-5} ==> {2}", edt, edt.Millisecond, pMsg));
			if (_sw != null)
				_sw.Close();
			if (_fs != null)
				_fs.Close();
			#endif
		}
        
        /// <summary>
        /// ���O�o��(DEBUG)����
        /// </summary>
        /// <param name="className"></param>
        /// <param name="methodName"></param>
        /// <param name="pMsg">���b�Z�[�W</param>
        public static void LogWrite(string className, string methodName, string pMsg)
        {
#if DEBUG
            try
            {
                System.IO.FileStream _fs;										// �t�@�C���X�g���[��
                System.IO.StreamWriter _sw;										// �X�g���[��writer
                _fs = new FileStream("PMMIT01010.Log", FileMode.Append, FileAccess.Write, FileShare.Write);
                _sw = new System.IO.StreamWriter(_fs, System.Text.Encoding.GetEncoding("shift_jis"));
                DateTime edt = DateTime.Now;
                //yyyy/MM/dd hh:mm:ss
                _sw.WriteLine(string.Format("{0,-19} {1,-5} ==> {2,-40} {3}", edt, edt.Millisecond, className + "." + methodName, pMsg));
                if (_sw != null)
                    _sw.Close();
                if (_fs != null)
                    _fs.Close();
            }
            catch (Exception ex)
            {
            }

#endif
        }
        #endregion

    }
}

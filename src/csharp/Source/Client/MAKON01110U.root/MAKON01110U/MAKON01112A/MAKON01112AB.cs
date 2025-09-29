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
//using Broadleaf.Application.LocalAccess;

namespace Broadleaf.Application.Controller
{
	/// <summary>
	/// �d�����͗p�����l�擾�A�N�Z�X�N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : �d�����͂̏����l�擾�f�[�^������s���܂��B</br>
	/// <br>Programmer : 21024�@���X�� ��</br>
	/// <br>Date       : 2008.05.21</br>
	/// <br></br>
	/// <br>UpDate</br>
	/// <br>2008.05.21 men �V�K�쐬</br>
    /// <br>UpdateNote  : 2017/08/11 杍^  </br>
    /// <br>�Ǘ��ԍ�    : 11370074-00</br>
    /// <br>              �n���f�B�^�[�~�i���݌Ɏd���o�^�̑Ή�</br> 
    /// <br>Update Note : 2020/02/24 �c����</br>
    /// <br>�Ǘ��ԍ�    : 11570208-00</br>
    /// <br>            : PMKOBETSU-2912����Őŗ��@�\�ǉ��Ή�</br>
    /// <br>Update Note: 2021/10/26 杍^</br>
    /// <br>�Ǘ��ԍ�   : 11601223-00</br>
    /// <br>           : BLINCIDENT-3114 �������i�Ԃ̍݌ɏ��擾�s��̑Ή�</br> 
	/// </remarks>
	public partial class StockSlipInputInitDataAcs
	{
        // ===================================================================================== //
        // �R���X�g���N�^
        // ===================================================================================== //
        # region ��Constructor
		/// <summary>
		/// �f�t�H���g�R���X�g���N�^�iSingleton�f�U�C���p�^�[�����̗p���Ă���ׁAprivate�Ƃ���j
		/// </summary>
        private StockSlipInputInitDataAcs()
        {
            _stockProcMoneyList = new List<StockProcMoney>();
            _salesProcMoneyList = new List<SalesProcMoney>();
            _employeeList = new List<Employee>();
            _employeeDtlList = new List<EmployeeDtl>();
            _warehouseList = new List<Warehouse>();
            _makerUMntList = new List<MakerUMnt>();
            _subSectionList = new List<SubSection>();
        }

		/// <summary>
		/// �d�����͗p�����l�擾�A�N�Z�X�N���X �C���X�^���X�擾����
		/// </summary>
		/// <returns>�d�����͗p�����l�擾�A�N�Z�X�N���X �C���X�^���X</returns>
		public static StockSlipInputInitDataAcs GetInstance()
		{
            if (_stockSlipInputInitDataAcs == null)
            {
                _stockSlipInputInitDataAcs = new StockSlipInputInitDataAcs();
            }

			return _stockSlipInputInitDataAcs;
		}
		# endregion

        // ===================================================================================== //
        // �v���C�x�[�g�ϐ�
        // ===================================================================================== //
        # region ��Private Members

		private static StockSlipInputInitDataAcs _stockSlipInputInitDataAcs;


		private List<StockProcMoney> _stockProcMoneyList;
        private List<SalesProcMoney> _salesProcMoneyList = null;
        private List<Employee> _employeeList;
        private List<EmployeeDtl> _employeeDtlList;
        private List<Warehouse> _warehouseList;
        private List<MakerUMnt> _makerUMntList;
        private List<SubSection> _subSectionList;
        private SalesTtlSt _salesTtlSt = null;

        private GoodsAcs _goodsAcs;
		private TaxRateSet _taxRateSet;
		private AllDefSet _allDefSet;
		private StockTtlSt _stockTtlSt;
		private StockMngTtlSt _stockMngTtlSt;
        private CompanyInf _companyInf;
        private IWin32Window _owner = null;
        private double _taxRateValue = 0;// ADD �c���� 2020/02/24 PMKOBETSU-2912�̑Ή�
        private List<NoteGuidBd> _noteGuidList = null;              // ���l�K�C�h�S�����X�g   // ADD 2011/11/30 gezh redmine#8383


		/// <summary>���_�R�[�h(�S�Ћ���)</summary>
		private const string ctSectionCode_Common = "00";

        /// <summary> ���̓��[�h</summary>
        private int _inputMode = ctINPUTMODE_GoodsNoNecessary;      // �i�ԕK�{���[�h

		# endregion

        // ===================================================================================== //
        // �v���C�x�[�g�ϐ�
        // ===================================================================================== //
        #region ���萔

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

		#endregion 

        // ===================================================================================== //
        // �f���Q�[�g
        // ===================================================================================== //
        #region ��delegate

		/// <summary>�d�����z�����敪�ݒ�L���b�V���f���Q�[�g</summary>
		public delegate void CacheStockProcMoneyListEventHandler( List<StockProcMoney> stockProcMoneyList );

		/// <summary>������z�����敪�ݒ�L���b�V���f���Q�[�g</summary>
		public delegate void CacheSalesProcMoneyListEventHandler( List<SalesProcMoney> salesProcMoneyList );

		#endregion

        // ===================================================================================== //
        // �C�x���g
        // ===================================================================================== //
        #region ��Events
		/// <summary>�d�����z�����敪�ݒ�Z�b�g�C�x���g</summary>
		public event CacheStockProcMoneyListEventHandler CacheStockProcMoneyList;
		/// <summary>������z�����敪�ݒ�L���b�V���C�x���g</summary>
		public event CacheSalesProcMoneyListEventHandler CacheSalesProcMoneyList;
		#endregion

        // ===================================================================================== //
        // �p�u���b�N�ϐ�
        // ===================================================================================== //
        # region ��Public Members
		/// <summary>���[�U�[�K�C�h�敪�R�[�h�i�ԕi���R�j</summary>
		public static readonly int ctDIVCODE_UserGuideDivCd_RetGoodsReason = 91;

        /// <summary>���l�K�C�h�敪�R�[�h�i���l�P�j</summary>
        public static readonly int ctDIVCODE_NoteGuid_StockSlipNote1 = 103;
        /// <summary>���l�K�C�h�敪�R�[�h�i���l�Q�j</summary>
        public static readonly int ctDIVCODE_NoteGuid_StockSlipNote2 = 104;

        /// <summary>�i�ԕK�{���[�h</summary>
        public static readonly int ctINPUTMODE_GoodsNoNecessary = 1;

#if DEBUG
		/// <summary>���[�J��DB�ǂݍ��݃��[�h</summary>
		public static readonly bool ctIsLocalDBRead = false;
#else
		/// <summary>���[�J��DB�ǂݍ��݃��[�h</summary>
		public static readonly bool ctIsLocalDBRead = false;
#endif

		# endregion

        // ===================================================================================== //
        // �v���p�e�B
        // ===================================================================================== //
        #region ��Properties

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

        /// <summary>�I�[�i�[�t�H�[��</summary>
        public IWin32Window Owner
        {
            get { return _owner; }
            set { _owner = value; }
        }

        // ----- ADD �c���� 2020/02/24 PMKOBETSU-2912�̑Ή� ----->>>>>
        /// <summary>�ŗ��ݒ�l</summary>
        public double TaxRateValue
        {
            get { return _taxRateValue; }
            set { _taxRateValue = value; }
        }
        // ----- ADD �c���� 2020/02/24 PMKOBETSU-2912�̑Ή� -----<<<<<

		#endregion

        // ===================================================================================== //
        // �p�u���b�N���\�b�h
        // ===================================================================================== //
        # region ��Public Methods

		/// <summary>
		/// �d�����͂Ŏg�p���鏉���f�[�^���c�a���擾���܂��B
		/// </summary>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="sectionCode">���_�R�[�h</param>
		/// <returns>STATUS</returns>
		public int ReadInitData(string enterpriseCode, string sectionCode)
		{
            LogWrite("StockSlipInputInitDataAcs", "ReadInitData", "�J�n");

            try
            {
                int status;
                ArrayList aList;  //ADD 2011/11/30 gezh redmine#8383

                #region ���]�ƈ��A�]�ƈ��ڍ׃}�X�^
                //-----------------------------------------------------------
                // �]�ƈ��A�]�ƈ��ڍ׃}�X�^
                //-----------------------------------------------------------
                LogWrite("StockSlipInputInitDataAcs", "ReadInitData", "�S�]�ƈ������擾");

                EmployeeAcs employeeAcs = new EmployeeAcs();

                ArrayList employeeList;
                ArrayList employeeDtlList;
                status = employeeAcs.Search(out employeeList, out employeeDtlList, enterpriseCode);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    this._employeeList = new List<Employee>((Employee[])employeeList.ToArray(typeof(Employee)));
                    this._employeeDtlList = new List<EmployeeDtl>((EmployeeDtl[])employeeDtlList.ToArray(typeof(EmployeeDtl)));
                }
                else
                {
                    this._employeeList = new List<Employee>();
                    this._employeeDtlList = new List<EmployeeDtl>();
                }
                #endregion

   
                #region ���q�Ƀ}�X�^
                //-----------------------------------------------------------
                // �q�Ƀ}�X�^
                //-----------------------------------------------------------
                LogWrite("StockSlipInputInitDataAcs", "ReadInitData", "�q�ɂ��擾");

                ArrayList returnWarehouse;
                WarehouseAcs warehouseAcs = new WarehouseAcs();

                WarehouseWork paraWarehouse = new WarehouseWork();
                paraWarehouse.EnterpriseCode = enterpriseCode;

                status = warehouseAcs.Search(out returnWarehouse, enterpriseCode);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    this._warehouseList = new List<Warehouse>((Warehouse[])returnWarehouse.ToArray(typeof(Warehouse)));
                }
                else
                {
                    this._warehouseList = new List<Warehouse>();
                }
                #endregion

                #region ���d���S�̐ݒ�}�X�^
                //-----------------------------------------------------------
                // �d���S�̐ݒ�}�X�^
                //-----------------------------------------------------------
                LogWrite("StockSlipInputInitDataAcs", "ReadInitData", "�d���S�̐ݒ���擾");

                StockTtlStAcs stockTtlStAcs = new StockTtlStAcs();
                ArrayList retStockTtlStArrayList;
                status = stockTtlStAcs.Search(out retStockTtlStArrayList, enterpriseCode);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    this._stockTtlSt = this.GetStockTtlStFromList(LoginInfoAcquisition.Employee.BelongSectionCode, retStockTtlStArrayList);
                }
                else
                {
                    this._stockTtlSt = null;
                }
                #endregion

                #region ���d���S�̐ݒ�}�X�^
                //-----------------------------------------------------------
                // �݌ɊǗ��S�̐ݒ�}�X�^
                //-----------------------------------------------------------
                LogWrite("StockSlipInputInitDataAcs", "ReadInitData", "�݌ɊǗ��S�̂��擾");

                ArrayList retStockMngTtlSt;
                StockMngTtlStAcs stockMngTtlStAcs = new StockMngTtlStAcs();
                status = stockMngTtlStAcs.Search(out retStockMngTtlSt, enterpriseCode);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    this._stockMngTtlSt = this.GetStockMngTtlStFromList(LoginInfoAcquisition.Employee.BelongSectionCode, retStockMngTtlSt);
                }
                else
                {
                    this._stockMngTtlSt = null;
                }
                #endregion

                #region ���d�����z�����敪�ݒ�}�X�^
                //-----------------------------------------------------------
                // �d�����z�����敪�ݒ�}�X�^
                //-----------------------------------------------------------
                LogWrite("StockSlipInputInitDataAcs", "ReadInitData", "�d�����z�����敪�ݒ���擾");

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
                else
                {
                    this._stockProcMoneyList = new List<StockProcMoney>();
                }

                #endregion

                #region ��������z�����敪�ݒ�}�X�^�i�ǂݍ��ݖ���)
                ////-----------------------------------------------------------
                //// ������z�����敪�ݒ�}�X�^
                ////-----------------------------------------------------------
                //LogWrite("������z�����敪�ݒ���擾");
                //SalesProcMoneyAcs salesProcMoneyAcs = new SalesProcMoneyAcs();
                //salesProcMoneyAcs.IsLocalDBRead = StockSlipInputInitDataAcs.ctIsLocalDBRead;

                //ArrayList returnSalesProcMoney;
                //status = salesProcMoneyAcs.Search(out returnSalesProcMoney, enterpriseCode);

                //this._salesProcMoneyList = new List<SalesProcMoney>();

                //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                //{
                //    foreach(SalesProcMoney salesProcMoney in returnSalesProcMoney)
                //    {
                //        this._salesProcMoneyList.Add(salesProcMoney);
                //        this.CacheSalesProcMoney(salesProcMoney);
                //    }
                //}
                //this.CacheSalesProcMoneyListCall();
                #endregion

                #region ���S�̏����l�ݒ�}�X�^
                //-----------------------------------------------------------
                // �S�̏����l�ݒ�}�X�^
                //-----------------------------------------------------------
                LogWrite("StockSlipInputInitDataAcs", "ReadInitData", "�S�̏����l�ݒ���擾");
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
                        this._inputMode = this._allDefSet.GoodsNoInpDiv;
                    }
                }
                else
                {
                    this._allDefSet = null;
                }
                #endregion

                #region �����Џ��ݒ�ݒ�}�X�^
                //-----------------------------------------------------------
                // ���Џ��ݒ�ݒ�}�X�^
                //-----------------------------------------------------------
                LogWrite("StockSlipInputInitDataAcs", "ReadInitData", "���Џ��ݒ�ݒ���擾");
                CompanyInfAcs companyInfAcs = new CompanyInfAcs();
                companyInfAcs.Read(out this._companyInf, enterpriseCode);
                #endregion

                #region ���ŗ��ݒ�}�X�^
                //-----------------------------------------------------------
                // �ŗ��ݒ�}�X�^
                //-----------------------------------------------------------
                LogWrite("StockSlipInputInitDataAcs", "ReadInitData", "����ł��擾");
                ArrayList returnTaxRateSet;

                TaxRateSetAcs taxRateSetAcs = new TaxRateSetAcs();

                TaxRateSetAcs.SearchMode taxRateSetSearchMode = ( StockSlipInputInitDataAcs.ctIsLocalDBRead ) ? TaxRateSetAcs.SearchMode.Local : TaxRateSetAcs.SearchMode.Remote;
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

                #region ������}�X�^
                //-----------------------------------------------------------
                // ����}�X�^
                //-----------------------------------------------------------
                LogWrite("StockSlipInputInitDataAcs", "ReadInitData", "������擾");
                SubSectionAcs subSectionAcs = new SubSectionAcs();
                ArrayList returnSubSection;
                status = subSectionAcs.Search(out returnSubSection, enterpriseCode);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    this._subSectionList = new List<SubSection>((SubSection[])returnSubSection.ToArray(typeof(SubSection)));
                }
                else
                {
                    this._subSectionList = new List<SubSection>();
                }

                #endregion

                #region �����i�֘A

                this._goodsAcs = new GoodsAcs();
                // �ǂݍ��݃��[�h�̐ݒ�
                this._goodsAcs.IsLocalDBRead = StockSlipInputInitDataAcs.ctIsLocalDBRead;

                //-----------------------------------------------------------
                // ���i�A�N�Z�X�N���X��������
                //-----------------------------------------------------------
                LogWrite("StockSlipInputInitDataAcs", "ReadInitData2", "���i�A�N�Z�X�N���X��������");
                string retMessage;
                this._goodsAcs.SearchInitial(enterpriseCode, sectionCode, out retMessage);

                //-----------------------------------------------------------
                // ���[�J�[�}�X�^
                //-----------------------------------------------------------
                LogWrite("StockSlipInputInitDataAcs", "ReadInitData2", "���[�J�[���X�g���擾");
                status = this._goodsAcs.GetAllMaker(enterpriseCode, out this._makerUMntList);
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL || this._makerUMntList == null)
                {
                    this._makerUMntList = new List<MakerUMnt>();
                }
                #endregion
                // ADD 2011/11/30 gezh redmine#8383 ---------->>>>>
                #region �����l�K�C�h�}�X�^�A�N�Z�X�N���X SFTOK09402A
                LogWrite("���l�K�C�h�S�����擾");
                NoteGuidAcs noteGuidAcs = new NoteGuidAcs();
                noteGuidAcs.IsLocalDBRead = ctIsLocalDBRead;
                status = noteGuidAcs.SearchBody(out aList, enterpriseCode);
                this._noteGuidList = new List<NoteGuidBd>();
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    if (aList != null) this._noteGuidList = new List<NoteGuidBd>((NoteGuidBd[])aList.ToArray(typeof(NoteGuidBd)));
                }
                #endregion

                // ADD 2011/11/30 gezh redmine#8383 ----------<<<<<
#if false
				//-----------------------------------------------------------
				// ����S�̐ݒ�}�X�^
				//-----------------------------------------------------------
				LogWrite("����S�̐ݒ���擾");

				ArrayList retSalesTtlSt;
				SalesTtlStAcs salesTtlStAcs = new SalesTtlStAcs();

				status = salesTtlStAcs.SearchAll(out retSalesTtlSt, enterpriseCode);

				if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
				{
					this._salesTtlSt = this.GetSalesTtlStFromList(LoginInfoAcquisition.Employee.BelongSectionCode, retSalesTtlSt);
				}

#endif
            }
            finally
            {
            }

            LogWrite("StockSlipInputInitDataAcs", "ReadInitData", "�I��");
            return 0;
		}

#if false
        /// <summary>
        /// �����f�[�^���c�a���擾���܂��B
        /// </summary>
        /// <param name="enterpriseCode"></param>
        /// <param name="sectionCode"></param>
        /// <returns></returns>
        public int ReadInitData2(string enterpriseCode, string sectionCode)
        {
            try
            {
                #region ������}�X�^
                //-----------------------------------------------------------
                // ����}�X�^
                //-----------------------------------------------------------
                LogWrite("StockSlipInputInitDataAcs", "ReadInitData", "������擾");
                SubSectionAcs subSectionAcs = new SubSectionAcs();
                ArrayList returnSubSection;
                int status = subSectionAcs.Search(out returnSubSection, enterpriseCode);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    this._subSectionList = new List<SubSection>((SubSection[])returnSubSection.ToArray(typeof(SubSection)));
                }
                else
                {
                    this._subSectionList = new List<SubSection>();
                }

                #endregion

                #region �����i�֘A

                this._goodsAcs = new GoodsAcs();
                // �ǂݍ��݃��[�h�̐ݒ�
                this._goodsAcs.IsLocalDBRead = StockSlipInputInitDataAcs.ctIsLocalDBRead;

                //-----------------------------------------------------------
                // ���i�A�N�Z�X�N���X��������
                //-----------------------------------------------------------
                LogWrite("StockSlipInputInitDataAcs", "ReadInitData2", "���i�A�N�Z�X�N���X��������");
                string retMessage;
                this._goodsAcs.SearchInitial(enterpriseCode, sectionCode, out retMessage);

                //-----------------------------------------------------------
                // ���[�J�[�}�X�^
                //-----------------------------------------------------------
                LogWrite("StockSlipInputInitDataAcs", "ReadInitData2", "���[�J�[���X�g���擾");
                status = this._goodsAcs.GetAllMaker(enterpriseCode, out this._makerUMntList);
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL || this._makerUMntList == null)
                {
                    this._makerUMntList = new List<MakerUMnt>();
                }
                #endregion
            }
            finally
            {
            }

            return 0;
        }
#endif

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
                msg = "�ŗ��ݒ�}�X�^�̓o�^���s���ĉ������B";
			}
			else if (this.GetAllDefSet() == null)
			{
                msg = "�S�̏����l�ݒ�}�X�^�̓o�^���s���ĉ������B";
			}
			else if (this.GetStockMngTtlSt() == null)
			{
                msg = "�݌ɊǗ��S�̐ݒ�}�X�^�̓o�^���s���ĉ������B";
			}
			else if (this.GetStockMngTtlSt() == null)
			{
                msg = "�d���݌ɑS�̐ݒ�}�X�^�̓o�^���s���ĉ������B";
			}
#if false
			else if (this.GetSalesTtlSt() == null)
			{
				msg = "����S�̐ݒ�}�X�^�̓o�^���s���ĉ������B";
			}
#endif

            return msg == "";
		}

		# endregion

        // ===================================================================================== //
        // �e��}�X�^����
        // ===================================================================================== //
        #region ���e��}�X�^����

        # region ���]�ƈ��}�X�^�L���b�V�����䏈��
        
		/// <summary>
		/// �]�ƈ��R�[�h�}�X�^���݃`�F�b�N
		/// </summary>
		/// <param name="employeeCode"></param>
		/// <returns></returns>
		public bool CodeExist_Employee( string employeeCode )
		{
            return ( this.GetEmployeeFromCache(employeeCode) != null );
		}

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

        //ADD 2011/11/30 gezh redmine#8383 ---------->>>>>
        # region ���w����l��񐧌䏈��
        /// <summary>
        /// ���l�K�C�h���̎擾����
        /// </summary>
        /// <param name="noteGuideDivCode">���l�K�C�h�敪</param>
        /// <param name="noteGuideCode">���l�K�C�h�R�[�h</param>
        /// <param name="noteGuideName">���l�K�C�h����</param>
        /// <returns>status</returns>
        /// <remarks>
        /// </remarks>
        public int GetName_NoteGuidBd(int noteGuideDivCode, int noteGuideCode, out string noteGuideName)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            noteGuideName = string.Empty;

            NoteGuidBd noteGuidBd = this._noteGuidList.Find(
                delegate(NoteGuidBd noteGuid)
                {
                    return (noteGuid.NoteGuideDivCode == noteGuideDivCode && noteGuid.NoteGuideCode == noteGuideCode) ? true : false;
                }
            );

            if (noteGuidBd != null)
            {
                noteGuideName = noteGuidBd.NoteGuideName;
            }
            else
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
            }

            return status;
        }

        # endregion
        //ADD 2011/11/30 gezh redmine#8383 ----------<<<<<
		# region ������}�X�^�L���b�V�����䏈��
        /// <summary>
        /// ���喼�̎擾����
        /// </summary>
        /// <param name="subSectionCode">����R�[�h</param>
        /// <returns>���喼��</returns>
        public string GetName_FromSubSection(int subSectionCode)
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

		# region ���d���݌ɑS�̐ݒ�}�X�^�L���b�V�����䏈��

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
		
		# endregion

		# region ���S�̏����l�ݒ�}�X�^�L���b�V�����䏈��

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


		/// <summary>
		/// �S�̏����l�ݒ�}�X�^��������
		/// </summary>
		/// <returns>�S�̏����l�ݒ�}�X�^�I�u�W�F�N�g</returns>
		public AllDefSet GetAllDefSet()
		{
			return this._allDefSet;
		}

		# endregion

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

		# region ���݌ɊǗ��S�̐ݒ�}�X�^�L���b�V�����䏈��

		/// <summary>
		/// �݌ɊǗ��S�̐ݒ�}�X�^�̃��X�g������A�w�肵�����_�̐ݒ���擾���܂��B
		/// </summary>
		/// <param name="sectionCode">���_�R�[�h</param>
		/// <param name="stockMngTtlStArrayList">�݌ɊǗ��S�̐ݒ�}�X�^�I�u�W�F�N�g���X�g</param>
		/// <returns>�݌ɊǗ��S�̐ݒ�}�X�^�I�u�W�F�N�g</returns>
		private StockMngTtlSt GetStockMngTtlStFromList( string sectionCode, ArrayList stockMngTtlStArrayList )
		{
			StockMngTtlSt allSecStockMngTtlSt = null;

			foreach (StockMngTtlSt stockMngTtlSt in stockMngTtlStArrayList)
			{
				if (stockMngTtlSt.SectionCode.Trim() == sectionCode.Trim())
				{
					return stockMngTtlSt;
				}
				else if (stockMngTtlSt.SectionCode.Trim() == ctSectionCode_Common.Trim())
				{
                    allSecStockMngTtlSt = stockMngTtlSt;
				}
			}

			return allSecStockMngTtlSt;
		}

		/// <summary>
		/// �݌ɊǗ��S�̐ݒ�}�X�^�L���b�V������
		/// </summary>
		/// <param name="stockMngTtlSt">�݌ɊǗ��S�̐ݒ�}�X�^�I�u�W�F�N�g</param>
		internal void CacheStockMngTtlSt(StockMngTtlSt stockMngTtlSt)
		{
			this._stockMngTtlSt = stockMngTtlSt;
		}

		/// <summary>
		/// �݌ɊǗ��S�̐ݒ�}�X�^��������
		/// </summary>
		/// <returns>�݌ɊǗ��S�̐ݒ�}�X�^�I�u�W�F�N�g</returns>
		public StockMngTtlSt GetStockMngTtlSt()
		{
			return this._stockMngTtlSt;
		}
		# endregion

		# region �����i�֘A����
		/// <summary>
		/// ���i�f�[�^���X�g��������
		/// </summary>
        /// <param name="goodsCndtnList">���i�����������X�g</param>
        /// <param name="goodsUnitDataList">���i���X�g</param>
        /// <param name="message">���_�R�[�h</param>
        /// <returns>�����X�e�[�^�X(ConstantManagement.MethodResult)</returns>
        public int GetGoodsUnitDataList( List<GoodsCndtn> goodsCndtnList, out List<GoodsUnitData> goodsUnitDataList, out string message )
        {
            message = string.Empty;

            goodsUnitDataList = new List<GoodsUnitData>();

            List<List<GoodsUnitData>> goodsUnitDataListRet;

            int status = this._goodsAcs.SearchPartsFromGoodsNoNonVariousSearchWholeWord(goodsCndtnList, out goodsUnitDataListRet, out message);

            if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {

                foreach (GoodsCndtn goodsCndtn in goodsCndtnList)
                {
                    foreach (List<GoodsUnitData> goodsUnitDataListWk in goodsUnitDataListRet)
                    {
                        bool findGoods = false;
                        foreach (GoodsUnitData goodsUnitData in goodsUnitDataListWk)
                        {
                            if (( goodsCndtn.GoodsNo == goodsUnitData.GoodsNo ) &&
                                ( goodsCndtn.GoodsMakerCd == goodsUnitData.GoodsMakerCd ))
                            {
                                goodsUnitDataList.Add(goodsUnitData);
                                findGoods = true;
                                break;
                            }
                        }
                        if (findGoods) break;
                    }
                }
            }
            return status;
        }

		/// <summary>
		/// �w�肵�����i�R�[�h�����ɏ��i�����擾���܂��B
		/// </summary>
        /// <param name="goodsCndtn">���i��������</param>
        /// <param name="goodsUnitData">���i���I�u�W�F�N�g�iout�j</param>
        /// <param name="message">���b�Z�[�W(out)</param>
        /// <returns>STATUS</returns>
        public int GetGoodsUnitData(GoodsCndtn goodsCndtn, out GoodsUnitData goodsUnitData, out string message)
        {

            List<GoodsUnitData> goodsUnitDataList;

            this._goodsAcs.Owner = this._owner;

            int status = _goodsAcs.SearchPartsFromGoodsNoNonVariousSearch(goodsCndtn, out goodsUnitDataList, out message);

            if (( goodsUnitDataList != null ) && ( goodsUnitDataList.Count > 0 ))
            {
                goodsUnitData = goodsUnitDataList[0];
            }
            else
            {
                goodsUnitData = null;
            }
            return status;
        }

        //--- ADD 杍^ 2021/10/26 BLINCIDENT-3114 �������i�Ԃ̍݌ɏ��擾�s��̑Ή� ----->>>>>
        /// <summary>
        /// �w�肵�����i�R�[�h+���[�J�[�R�[�h�����Ƀ��[�U�[�����i�����擾���܂��B
        /// </summary>
        /// <param name="goodsCndtn">���i��������</param>
        /// <param name="goodsUnitData">���i���I�u�W�F�N�g</param>
        /// <param name="goodsUnitDataCk">���i���I�u�W�F�N�g(out)</param>
        /// <returns>STATUS</returns>        /// 
        /// <remarks>
        /// <br>Note       : 2021/10/26 杍^</br>
        /// <br>�Ǘ��ԍ�   : 11601223-00</br>
        /// <br>           : BLINCIDENT-3114 �������i�Ԃ̍݌ɏ��擾�s��̑Ή�</br> 
        /// </remarks>
        public int ReadGoodsUnitData(GoodsCndtn goodsCndtn, GoodsUnitData goodsUnitData, out GoodsUnitData goodsUnitDataCk)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            status = _goodsAcs.Read(goodsCndtn.EnterpriseCode, goodsCndtn.SectionCode, goodsUnitData.GoodsMakerCd, goodsUnitData.GoodsNo, out goodsUnitDataCk);

            return status;
        }
        //--- ADD 杍^ 2021/10/26 BLINCIDENT-3114 �������i�Ԃ̍݌ɏ��擾�s��̑Ή� -----<<<<<

        /// <summary>
        /// ���i�A���f�[�^�̏��i���i���X�g����A�Ώۓ��̏��i���i�����擾���܂��B
        /// </summary>
        /// <param name="targetDate">�Ώۓ��t</param>
        /// <param name="goodsUnitData">���i�A���f�[�^</param>
        /// <returns>���i���i�f�[�^</returns>
        internal GoodsPrice GetGoodsPrice( DateTime targetDate, GoodsUnitData goodsUnitData )
        {
            return this._goodsAcs.GetGoodsPriceFromGoodsPriceList(targetDate, goodsUnitData.GoodsPriceList);
        }

        /// <summary>
        /// ���i��񂩂�w��q�ɂ̍݌ɏ����擾���܂��B
        /// </summary>
        /// <param name="goodsUnitData">���i���I�u�W�F�N�g</param>
        /// <param name="warehouseCdArray">�q�ɔz��</param>
        /// <returns>�݌ɃI�u�W�F�N�g</returns>
        public Stock GetStockFromGoodsUnitData( GoodsUnitData goodsUnitData, string[] warehouseCdArray )
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

        // 2009.04.03 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// �݌Ƀ��X�g���݌ɏ��擾
        /// </summary>
        /// <param name="goodsUnitData"></param>
        /// <returns></returns>
        public Stock GetStock(GoodsUnitData goodsUnitData, string warehouseCode)
        {
            if ((goodsUnitData != null) &&
                (goodsUnitData.StockList != null))
            {
                Stock retStock = new Stock();
                retStock = this._goodsAcs.GetStockFromStockList(warehouseCode, goodsUnitData.GoodsMakerCd, goodsUnitData.GoodsNo, goodsUnitData.StockList);
                if (retStock != null) return retStock;
            }
            return null;
        }
        // 2009.04.03 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

		/// <summary>
		/// JAN�R�[�h�ɂď��i�����擾���܂��B
		/// </summary>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="sectionCode">���_�R�[�h</param>
		/// <param name="jan">JAN�R�[�h</param>
        /// <param name="goodsUnitData">���i���N���X</param>
		/// <returns>STATUS</returns>
		public int ReadGoodsFromJan( string enterpriseCode, string sectionCode, string jan, out GoodsUnitData goodsUnitData )
		{
			return this._goodsAcs.ReadJan(enterpriseCode, sectionCode, jan, out goodsUnitData);
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
        public bool GetBLGoodsRelation( int bLGoodsCode, out BLGoodsCdUMnt bLGoodsCdUMnt, out BLGroupU bLGroupU, out GoodsGroupU goodsGroupU, out UserGdBdU userGdBdU )
        {
            this._goodsAcs.GetBLGoodsRelation(bLGoodsCode, out bLGoodsCdUMnt, out bLGroupU, out goodsGroupU, out userGdBdU);

            return !( ( bLGoodsCdUMnt.BLGoodsCode == 0 ) && ( string.IsNullOrEmpty(bLGoodsCdUMnt.BLGoodsName) ) );
        }

		# endregion

		# region �����[�J�[�}�X�^�L���b�V�����䏈��
        /// <summary>
        /// ���[�J�[���̎擾����
        /// </summary>
        /// <param name="makerCode">���[�J�[�R�[�h</param>
        /// <param name="makerName">���[�J�[����</param>
        /// <param name="makerKanaName">���[�J�[���̃J�i</param>
        public bool GetName_FromMaker(int makerCode, out string makerName, out string makerKanaName)
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

        /// <summary>
        /// �L���b�V���C�x���g�̃R�[��
        /// </summary>
        public void CacheEventCall()
        {
            this.CacheStockProcMoneyListCall();
            this.CacheSalesProcMoneyListCall();
        }

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

        #region �\�[�g�p�̃N���X

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


        #endregion

        #endregion

        /// <summary>
		/// ���O�o��(DEBUG)����
		/// </summary>
		/// <param name="pMsg">���b�Z�[�W</param>
		public static void LogWrite(string pMsg)
		{
#if DEBUG
            try
            {
                System.IO.FileStream _fs;										// �t�@�C���X�g���[��
                System.IO.StreamWriter _sw;										// �X�g���[��writer
                _fs = new FileStream("MAKON01101.Log", FileMode.Append, FileAccess.Write, FileShare.Write);
                _sw = new System.IO.StreamWriter(_fs, System.Text.Encoding.GetEncoding("shift_jis"));
                DateTime edt = DateTime.Now;
                //yyyy/MM/dd hh:mm:ss
                _sw.WriteLine(string.Format("{0,-19} {1,-5} ==> {2}", edt, edt.Millisecond, pMsg));
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
                _fs = new FileStream("MAKON01101.Log", FileMode.Append, FileAccess.Write, FileShare.Write);
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

        // ------ ADD 2017/08/11 杍^ �n���f�B�^�[�~�i���񎟊J�� --------- >>>>
        #region ���n���f�B�^�[�~�i���݌Ɏd���o�^�̑Ή�
        // ===================================================================================== //
        // �R���X�g���N�^�i�n���f�B�^�[�~�i���p�j
        // ===================================================================================== //
        # region ��Constracter
        /// <summary>
        /// �R���X�g���N�^�i�n���f�B�^�[�~�i���p�j
        /// </summary>
        /// <param name="status">�������X�e�[�^�X�u0�F����  0�ȊO�F���s�v</param>
        /// <remarks>
        /// <br>Note       : �N���X�̐V�����C���X�^���X�����������܂��B�i�n���f�B�^�[�~�i���p�j</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2017/08/11</br>
        /// </remarks>
        public StockSlipInputInitDataAcs(out int status)
        {
            status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                _stockProcMoneyList = new List<StockProcMoney>();
                _salesProcMoneyList = new List<SalesProcMoney>();
                _employeeList = new List<Employee>();
                _employeeDtlList = new List<EmployeeDtl>();
                _warehouseList = new List<Warehouse>();
                _makerUMntList = new List<MakerUMnt>();
                _subSectionList = new List<SubSection>();

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
        }
        #endregion

        /// <summary>
        /// �d�����͂Ŏg�p���鏉���f�[�^���c�a���擾���܂��B
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <returns>STATUS</returns>
        public int ReadInitDataForHandy(string enterpriseCode, string sectionCode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                ArrayList aList;

                #region ���]�ƈ��A�]�ƈ��ڍ׃}�X�^
                //-----------------------------------------------------------
                // �]�ƈ��A�]�ƈ��ڍ׃}�X�^
                //-----------------------------------------------------------
                EmployeeAcs employeeAcs = new EmployeeAcs();

                ArrayList employeeList;
                ArrayList employeeDtlList;
                status = employeeAcs.Search(out employeeList, out employeeDtlList, enterpriseCode);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    this._employeeList = new List<Employee>((Employee[])employeeList.ToArray(typeof(Employee)));
                    this._employeeDtlList = new List<EmployeeDtl>((EmployeeDtl[])employeeDtlList.ToArray(typeof(EmployeeDtl)));
                }
                else
                {
                    this._employeeList = new List<Employee>();
                    this._employeeDtlList = new List<EmployeeDtl>();
                }
                #endregion


                #region ���q�Ƀ}�X�^
                //-----------------------------------------------------------
                // �q�Ƀ}�X�^
                //-----------------------------------------------------------
                ArrayList returnWarehouse;
                WarehouseAcs warehouseAcs = new WarehouseAcs();

                WarehouseWork paraWarehouse = new WarehouseWork();
                paraWarehouse.EnterpriseCode = enterpriseCode;

                status = warehouseAcs.Search(out returnWarehouse, enterpriseCode);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    this._warehouseList = new List<Warehouse>((Warehouse[])returnWarehouse.ToArray(typeof(Warehouse)));
                }
                else
                {
                    this._warehouseList = new List<Warehouse>();
                }
                #endregion

                #region ���d���S�̐ݒ�}�X�^
                //-----------------------------------------------------------
                // �d���S�̐ݒ�}�X�^
                //-----------------------------------------------------------
                StockTtlStAcs stockTtlStAcs = new StockTtlStAcs();
                ArrayList retStockTtlStArrayList;
                status = stockTtlStAcs.Search(out retStockTtlStArrayList, enterpriseCode);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    this._stockTtlSt = this.GetStockTtlStFromList(sectionCode, retStockTtlStArrayList);
                }
                else
                {
                    this._stockTtlSt = null;
                }
                #endregion

                #region ���d���S�̐ݒ�}�X�^
                //-----------------------------------------------------------
                // �݌ɊǗ��S�̐ݒ�}�X�^
                //-----------------------------------------------------------
                ArrayList retStockMngTtlSt;
                StockMngTtlStAcs stockMngTtlStAcs = new StockMngTtlStAcs();
                status = stockMngTtlStAcs.Search(out retStockMngTtlSt, enterpriseCode);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    this._stockMngTtlSt = this.GetStockMngTtlStFromList(sectionCode, retStockMngTtlSt);
                }
                else
                {
                    this._stockMngTtlSt = null;
                }
                #endregion

                #region ���d�����z�����敪�ݒ�}�X�^
                //-----------------------------------------------------------
                // �d�����z�����敪�ݒ�}�X�^
                //-----------------------------------------------------------
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
                else
                {
                    this._stockProcMoneyList = new List<StockProcMoney>();
                }

                #endregion

                #region ���S�̏����l�ݒ�}�X�^
                //-----------------------------------------------------------
                // �S�̏����l�ݒ�}�X�^
                //-----------------------------------------------------------
                AllDefSetAcs allDefSetAcs = new AllDefSetAcs();
                AllDefSetAcs.SearchMode allDefSetSearchMode = AllDefSetAcs.SearchMode.Remote;
                ArrayList retAllDefSetList;
                status = allDefSetAcs.Search(out retAllDefSetList, enterpriseCode, allDefSetSearchMode);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // ���O�C���S���҂̏������_�������͑S�Аݒ���擾
                    this._allDefSet = this.GetAllDefSetFromList(sectionCode, retAllDefSetList);

                    if (this._allDefSet != null)
                    {
                        this._inputMode = this._allDefSet.GoodsNoInpDiv;
                    }
                }
                else
                {
                    this._allDefSet = null;
                }
                #endregion

                #region �����Џ��ݒ�ݒ�}�X�^
                //-----------------------------------------------------------
                // ���Џ��ݒ�ݒ�}�X�^
                //-----------------------------------------------------------
                CompanyInfAcs companyInfAcs = new CompanyInfAcs();
                companyInfAcs.Read(out this._companyInf, enterpriseCode);
                #endregion

                #region ���ŗ��ݒ�}�X�^
                //-----------------------------------------------------------
                // �ŗ��ݒ�}�X�^
                //-----------------------------------------------------------
                ArrayList returnTaxRateSet;

                TaxRateSetAcs taxRateSetAcs = new TaxRateSetAcs();

                TaxRateSetAcs.SearchMode taxRateSetSearchMode = (StockSlipInputInitDataAcs.ctIsLocalDBRead) ? TaxRateSetAcs.SearchMode.Local : TaxRateSetAcs.SearchMode.Remote;
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

                #region ������}�X�^
                //-----------------------------------------------------------
                // ����}�X�^
                //-----------------------------------------------------------
                SubSectionAcs subSectionAcs = new SubSectionAcs();
                ArrayList returnSubSection;
                status = subSectionAcs.Search(out returnSubSection, enterpriseCode);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    this._subSectionList = new List<SubSection>((SubSection[])returnSubSection.ToArray(typeof(SubSection)));
                }
                else
                {
                    this._subSectionList = new List<SubSection>();
                }

                #endregion

                #region �����i�֘A

                this._goodsAcs = new GoodsAcs();
                // �ǂݍ��݃��[�h�̐ݒ�
                this._goodsAcs.IsLocalDBRead = StockSlipInputInitDataAcs.ctIsLocalDBRead;

                //-----------------------------------------------------------
                // ���i�A�N�Z�X�N���X��������
                //-----------------------------------------------------------
                string retMessage;
                this._goodsAcs.SearchInitial(enterpriseCode, sectionCode, out retMessage);

                //-----------------------------------------------------------
                // ���[�J�[�}�X�^
                //-----------------------------------------------------------
                status = this._goodsAcs.GetAllMaker(enterpriseCode, out this._makerUMntList);
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL || this._makerUMntList == null)
                {
                    this._makerUMntList = new List<MakerUMnt>();
                }
                #endregion

                #region �����l�K�C�h�}�X�^�A�N�Z�X�N���X SFTOK09402A
                NoteGuidAcs noteGuidAcs = new NoteGuidAcs();
                noteGuidAcs.IsLocalDBRead = ctIsLocalDBRead;
                status = noteGuidAcs.SearchBody(out aList, enterpriseCode);
                this._noteGuidList = new List<NoteGuidBd>();
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    if (aList != null) this._noteGuidList = new List<NoteGuidBd>((NoteGuidBd[])aList.ToArray(typeof(NoteGuidBd)));
                }
                #endregion

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;
        }
        #endregion
        // ------ ADD 2017/08/11 杍^ �n���f�B�^�[�~�i���񎟊J�� --------- <<<<
	}
}

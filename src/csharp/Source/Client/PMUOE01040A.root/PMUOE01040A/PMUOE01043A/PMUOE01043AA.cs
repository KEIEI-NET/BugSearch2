//****************************************************************************//
// �V�X�e��         : PM.NS�V���[�Y
// �v���O��������   : �t�n�d����M�i�m�k�A�N�Z�X�N���X
// �v���O�����T�v   : �t�n�d����M�i�m�k�A�N�Z�X���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10402071-00 �쐬�S�� : ���� �T��
// �� �� ��  2008/05/26  �C�����e : �V�K�쐬
//           2009/05/25  �C�����e : 96186 ���� �T�� �z���_ UOE WEB�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : FSI���X�� �M�p
// �� �� ��  2012/10/03  �C�����e : �d���悪�D�ǂ̏ꍇ�̎�M�G���[��
//                                  ���M�G���[�Ƃ��ď��������s��Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10902931-00 �쐬�S�� : 杍^
// �� �� ��  2013/08/15  �C�����e : ��������(����)�����̒ǉ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10902931-00 �쐬�S�� : 杍^
// �� �� ��  2014/03/24  �C�����e : �������_�̔������Ď擾�̑Ή�
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using System.Windows.Forms;
using System.Threading;
using Broadleaf.Application.Remoting.ParamData;

using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Globarization;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Controller
{
	/// <summary>
	/// �t�n�d����M�i�m�k�A�N�Z�X�N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : �t�n�d���M�ҏW�A�N�Z�X�N���X</br>
	/// <br>Programmer : 96186 ���ԗT��</br>
	/// <br>Date       : 2008.05.26</br>
	/// <br></br>
	/// <br>UpDate</br>
	/// <br>2008.05.26 men �V�K�쐬</br>
    /// <br>Update Note  : 2009/05/25 96186 ���� �T��</br>
    /// <br>              �E�z���_ UOE WEB�Ή�</br>
    /// <br></br>
    /// <br>Update Note  : 2012/10/03 FSI���X�� �M�p</br>
    /// <br>              �E�d���悪�D�ǂ̏ꍇ�̎�M�G���[��</br>
    /// <br>                ���M�G���[�Ƃ��ď��������s��Ή�</br>
    /// </remarks>
	public partial class UoeSndRcvJnlAcs
	{
		// ===================================================================================== //
		// �R���X�g���N�^
		// ===================================================================================== //
		# region Constructors
		public UoeSndRcvJnlAcs()
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

			//��ƃR�[�h���擾����
			this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

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

             //�t�^�oUSB��p
            if (this._opt_FuTaBa == (int)Option.ON)
            {
                sectionSolt = Thread.GetNamedDataSlot(SECTIONSOLT);
                //Thread�ŁA���_������ꍇ�AThread�̋��_���g�p
                if (Thread.GetData(sectionSolt) != null)
                {
                    this._sectionCode = ((string)Thread.GetData(Thread.GetNamedDataSlot(SECTIONSOLT))).Trim();
                }
                else
                {
                    this._sectionCode = LoginInfoAcquisition.Employee.BelongSectionCode.Trim();
                }
            }
            else
            {
			    this._sectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;
            }
            // ---- ADD 2013/08/15 杍^ ---- <<<<<

            //this._sectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;// DEL 2013/08/15 杍^

			//����S�̐ݒ�}�X�^���擾
			this._salesTtlStAcs = new SalesTtlStAcs();
			_salesTtlSt = new SalesTtlSt();
			SalesTtlSt returnSalesTtlSt = new SalesTtlSt();

            status = this._salesTtlStAcs.Read(out returnSalesTtlSt, _enterpriseCode, _sectionCode);
			if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				_salesTtlSt = returnSalesTtlSt;
			}
            // �S�Гǂݍ���
            else
            {
                status = this._salesTtlStAcs.Read(out returnSalesTtlSt, _enterpriseCode, "00");
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    _salesTtlSt = returnSalesTtlSt;
                }
            }

			//������}�X�^�̎擾
			GetUOESupplier();

			//UOE���Аݒ�}�X�^���擾
			this._uOESettingAcs = new UOESettingAcs();
			_uOESetting = new UOESetting();
			UOESetting returnUOESetting = new UOESetting();
            status = this._uOESettingAcs.Read(out returnUOESetting, _enterpriseCode, _sectionCode);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                _uOESetting = returnUOESetting;
            }

			//�[���Ǘ��ݒ�̎擾
			this._posTerminalMgAcs = new PosTerminalMgAcs();
			status = this._posTerminalMgAcs.GetCashRegisterNo(out _cashRegisterNo, _enterpriseCode);
			if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				_cashRegisterNo = 0;
			}

            // 2009/05/25 START >>>>>>
            //-----------------------------------------------------------
            //���_���擾
            //-----------------------------------------------------------
            this._secInfoSetAcs = new SecInfoSetAcs();
            SecInfoSet returnSecInfoSet = new SecInfoSet();
            status = this._secInfoSetAcs.Read(out returnSecInfoSet, _enterpriseCode, _sectionCode);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                _secInfoSet = returnSecInfoSet;
            }
            // 2009/05/25 END   <<<<<<


			//���i�}�X�^ �A�N�Z�X�N���X�������l�f�[�^�擾��
			this._goodsAcs = new GoodsAcs();
			string msg = "";
			_goodsAcs.SearchInitial(_enterpriseCode, _sectionCode, out msg);

			//DataSet������
			_uoeJnlDataSet = new DataSet();

			//�f�[�^�[�e�[�u���̏�����
			SchemaClear();
		}

        // ------------- ADD 杍^ 2014/03/24 -------- >>>>>>>>
        /// <summary>
        /// �������񋒓_�̏ꍇ�A�V���_�̏ꍇ�A�L���b�V���[�����Ď擾����
        /// </summary>
        /// <returns></returns>
        public void UoeSndRcvJnlAcsForMoreSection()
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            //��ƃR�[�h���擾����
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

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

            //�t�^�oUSB��p
            if (this._opt_FuTaBa == (int)Option.ON)
            {
                sectionSolt = Thread.GetNamedDataSlot(SECTIONSOLT);
                //Thread�ŁA���_������ꍇ�AThread�̋��_���g�p
                if (Thread.GetData(sectionSolt) != null)
                {
                    this._sectionCode = ((string)Thread.GetData(Thread.GetNamedDataSlot(SECTIONSOLT))).Trim();
                }
                else
                {
                    this._sectionCode = LoginInfoAcquisition.Employee.BelongSectionCode.Trim();
                }
            }
            else
            {
                this._sectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;
            }
            // ---- ADD 2013/08/15 杍^ ---- <<<<<

            //this._sectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;// DEL 2013/08/15 杍^

            //����S�̐ݒ�}�X�^���擾
            this._salesTtlStAcs = new SalesTtlStAcs();
            _salesTtlSt = new SalesTtlSt();
            SalesTtlSt returnSalesTtlSt = new SalesTtlSt();

            status = this._salesTtlStAcs.Read(out returnSalesTtlSt, _enterpriseCode, _sectionCode);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                _salesTtlSt = returnSalesTtlSt;
            }
            // �S�Гǂݍ���
            else
            {
                status = this._salesTtlStAcs.Read(out returnSalesTtlSt, _enterpriseCode, "00");
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    _salesTtlSt = returnSalesTtlSt;
                }
            }

            //������}�X�^�̎擾
            GetUOESupplierForMoreSection();

            //UOE���Аݒ�}�X�^���擾
            this._uOESettingAcs = new UOESettingAcs();
            _uOESetting = new UOESetting();
            UOESetting returnUOESetting = new UOESetting();
            status = this._uOESettingAcs.Read(out returnUOESetting, _enterpriseCode, _sectionCode);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                _uOESetting = returnUOESetting;
            }

            //�[���Ǘ��ݒ�̎擾
            this._posTerminalMgAcs = new PosTerminalMgAcs();
            status = this._posTerminalMgAcs.GetCashRegisterNo(out _cashRegisterNo, _enterpriseCode);
            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                _cashRegisterNo = 0;
            }

            // 2009/05/25 START >>>>>>
            //-----------------------------------------------------------
            //���_���擾
            //-----------------------------------------------------------
            this._secInfoSetAcs = new SecInfoSetAcs();
            SecInfoSet returnSecInfoSet = new SecInfoSet();
            status = this._secInfoSetAcs.Read(out returnSecInfoSet, _enterpriseCode, _sectionCode);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                _secInfoSet = returnSecInfoSet;
            }
            // 2009/05/25 END   <<<<<<


            //���i�}�X�^ �A�N�Z�X�N���X�������l�f�[�^�擾��
            this._goodsAcs = new GoodsAcs();
            string msg = "";
            _goodsAcs.SearchInitial(_enterpriseCode, _sectionCode, out msg);

            //DataSet������
            _uoeJnlDataSet = new DataSet();

            //�f�[�^�[�e�[�u���̏�����
            SchemaClear();
        }
        // ------------- ADD 杍^ 2014/03/24 -------- <<<<<<<<<<

		/// <summary>
		/// �A�N�Z�X�N���X �C���X�^���X�擾����
		/// </summary>
		/// <returns></returns>
		public static UoeSndRcvJnlAcs GetInstance()
		{
			if (_uoeSndRcvJnlAcs == null)
			{
				_uoeSndRcvJnlAcs = new UoeSndRcvJnlAcs();
			}
			return _uoeSndRcvJnlAcs;
		}
		# endregion

		// ===================================================================================== //
		// �v���C�x�[�g�ϐ�
		// ===================================================================================== //
		# region Private Members

        // ---- ADD 2013/08/15 杍^ ---- >>>>>
        //���_�R�[�h
        private const string SECTIONSOLT = "SECTIONSOLT";
        private LocalDataStoreSlot sectionSolt = null;

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
        // ---- ADD 2013/08/15 杍^ ---- <<<<<

		//��ƃR�[�h
		private string _enterpriseCode = "";

		//���_�R�[�h
		public string _sectionCode = "";
		
		//�A�N�Z�X�N���X �C���X�^���X
		private static UoeSndRcvJnlAcs _uoeSndRcvJnlAcs = null;

		//������}�X�^�A�N�Z�X�N���X
        private UOESupplierAcs _uOESupplierAcs = new UOESupplierAcs();

		// UOE���Аݒ�}�X�^ �A�N�Z�X�N���X
		private UOESettingAcs _uOESettingAcs = null;

		//����S�̐ݒ�}�X�^ �A�N�Z�X�N���X
		private SalesTtlStAcs _salesTtlStAcs = null;

		// �[���Ǘ��ݒ� �A�N�Z�X�N���X
		private PosTerminalMgAcs _posTerminalMgAcs = null;

		// ���i�}�X�^ �A�N�Z�X�N���X
		private GoodsAcs _goodsAcs = null;

		//������Dictionary�������p��
		private static Dictionary<Int32, UOESupplier> _uoeOrderSearchDictionary;

        //������\���[�J�[Dictionary�������p��
        private static Dictionary<String, String> _uoeOrderMakerSearchDictionary;

		//���엚�����O�f�[�^���X�g
		private List<OprtnHisLog> _oprtnHisLogList = new List<OprtnHisLog>();

		//UOE���Аݒ�}�X�^
		private UOESetting _uOESetting = null;

		//����S�̐ݒ�}�X�^
		private SalesTtlSt _salesTtlSt = null;

		//���[���R�[�h
		private int _cashRegisterNo = 0;

		//�t�n�d�i�m�k�f�[�^�Z�b�g
		private DataSet _uoeJnlDataSet = new DataSet();

        // 2009/05/25 START >>>>>>
        // ���_�ݒ� �A�N�Z�X�N���X
        private SecInfoSetAcs _secInfoSetAcs = null;
        //���_�ݒ�}�X�^
        private SecInfoSet _secInfoSet = null;
        // 2009/05/25 END   <<<<<<
		# endregion

		// ===================================================================================== //
		// �萔
		// ===================================================================================== //
		# region Const Members
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
        # region UOE������}�X�^�A�N�Z�X�N���X
        /// <summary>
        /// UOE������}�X�^�A�N�Z�X�N���X
        /// </summary>
        public UOESupplierAcs uOESupplierAcs
        {
            get { return _uOESupplierAcs; }
        }
		# endregion

		# region UOE���Аݒ�}�X�^
		/// <summary>
		/// UOE���Аݒ�}�X�^
		/// </summary>
		public UOESetting uOESetting
		{
			get { return _uOESetting; }
			set { _uOESetting = value; }
		}
		# endregion

		# region ����S�̐ݒ�}�X�^
		/// <summary>
		/// ����S�̐ݒ�}�X�^
		/// </summary>
		public SalesTtlSt salesTtlSt
		{
			get { return _salesTtlSt; }
			set { _salesTtlSt = value; }
		}
		# endregion

		# region ���i�}�X�^ �A�N�Z�X�N���X
		/// <summary>
		/// ���i�}�X�^ �A�N�Z�X�N���X
		/// </summary>
		public GoodsAcs goodsAcs
		{
			get { return this._goodsAcs; }
			set { this._goodsAcs = value; }
		}
		# endregion

		# region ���[���R�[�h
		/// <summary>
		/// ���[���R�[�h
		/// </summary>
		public int cashRegisterNo
		{
			get { return _cashRegisterNo; }
			set { _cashRegisterNo = value; }
		}
		# endregion

		# region ������}�X�^
		/// <summary>
		/// ������}�X�^
		/// </summary>
		public Dictionary<Int32, UOESupplier> uoeOrderSearchDictionary
		{
			get { return _uoeOrderSearchDictionary; }
			set { _uoeOrderSearchDictionary = value; }
		}
		# endregion

        # region ������\���[�J�[
        /// <summary>
        /// ������\���[�J�[
        /// </summary>
        public Dictionary<String, String> uoeOrderMakerSearchDictionary
        {
            get { return _uoeOrderMakerSearchDictionary; }
            set { _uoeOrderMakerSearchDictionary = value; }
        }
        # endregion

		# region ��DataSet��
		/// <summary>
		/// ��DataSet��
		/// </summary>
		public DataSet UoeJnlDataSet
		{
			get { return this._uoeJnlDataSet; }
		}
		# endregion

		# region ��DataTable��
		# region ������DataTable��
		/// <summary>
		/// ������DataTable��
		/// </summary>
		public DataTable OrderTable
		{
			get { return this._uoeJnlDataSet.Tables[OrderSndRcvJnlSchema.CT_OrderSndRcvJnlDataTable]; }
		}
		# endregion

		# region ���ρ�DataTable��
		/// <summary>
		/// ���ρ�DataTable��
		/// </summary>
		public DataTable EstmtTable
		{
			get { return this._uoeJnlDataSet.Tables[EstmtSndRcvJnlSchema.CT_EstmtSndRcvJnlDataTable]; }
		}
		# endregion

		# region �݌Ɂ�DataTable��
		/// <summary>
		/// �݌Ɂ�DataTable��
		/// </summary>
		public DataTable StockTable
		{
			get { return this._uoeJnlDataSet.Tables[StockSndRcvJnlSchema.CT_StockSndRcvJnlDataTable]; }
		}
		# endregion

        # region UOE������DataTable��
        /// <summary>
        /// UOE������DataTable��
        /// </summary>
        public DataTable UOEOrderDtlTable
        {
            get { return this._uoeJnlDataSet.Tables[UOEOrderDtlSchema.CT_UOEOrderDtlDataTable]; }
        }
        # endregion

        # region �d���f�[�^��DataTable��
        /// <summary>
        /// �d���f�[�^��DataTable��
        /// </summary>
        public DataTable StockSlipTable
        {
            get { return this._uoeJnlDataSet.Tables[StockSlipSchema.CT_StockSlipDataTable]; }
        }
        # endregion

        # region �d�����ׁ�DataTable��
        /// <summary>
        /// �d�����ׁ�DataTable��
        /// </summary>
        public DataTable StockDetailTable
        {
            get { return this._uoeJnlDataSet.Tables[StockDetailSchema.CT_StockDetailDataTable]; }
        }
        # endregion

        # region ����f�[�^��DataTable��
        /// <summary>
        /// ����f�[�^��DataTable��
        /// </summary>
        public DataTable SalesSlipTable
        {
            get { return this._uoeJnlDataSet.Tables[SalesSlipSchema.CT_SalesSlipDataTable]; }
        }
        # endregion

        # region ���㖾�ׁ�DataTable��
        /// <summary>
        /// ���㖾�ׁ�DataTable��
        /// </summary>
        public DataTable SalesDetailTable
        {
            get { return this._uoeJnlDataSet.Tables[SalesDetailSchema.CT_SalesDetailDataTable]; }
        }
        # endregion



        # region Uoe�d���f�[�^��DataTable��
        /// <summary>
        /// Uoe�d���f�[�^��DataTable��
        /// </summary>
        public DataTable UoeStockSlipTable
        {
            get { return this._uoeJnlDataSet.Tables[StockSlipSchema.CT_UoeStockSlipDataTable]; }
        }
        # endregion

        # region Uoe�d�����ׁ�DataTable��
        /// <summary>
        /// Uoe�d�����ׁ�DataTable��
        /// </summary>
        public DataTable UoeStockDetailTable
        {
            get { return this._uoeJnlDataSet.Tables[StockDetailSchema.CT_UoeStockDetailDataTable]; }
        }
        # endregion

        # region �󒍃f�[�^��DataTable��
        /// <summary>
        /// �󒍃f�[�^��DataTable��
        /// </summary>
        public DataTable AcptSlipTable
        {
            get { return this._uoeJnlDataSet.Tables[SalesSlipSchema.CT_AcptSlipDataTable]; }
        }
        # endregion

        # region �󒍖��ׁ�DataTable��
        /// <summary>
        /// �󒍖��ׁ�DataTable��
        /// </summary>
        public DataTable AcptDetailTable
        {
            get { return this._uoeJnlDataSet.Tables[SalesDetailSchema.CT_AcptDetailDataTable]; }
        }
        # endregion

        // 2009/05/25 START >>>>>>
        # region �����ꗗ����(�����)��DataTable��
        /// <summary>
        /// �����ꗗ����(�����)��DataTable��
        /// </summary>
        public DataTable OrderLstInputDtlTable
        {
            get { return this._uoeJnlDataSet.Tables[OrderLstInputDtlSchema.CT_OrderLstInputDtlDataTable]; }
        }
        # endregion

        # region ����ꗗ���ׁ�DataTable��
        /// <summary>
        /// ����ꗗ���ׁ�DataTable��
        /// </summary>
        public DataTable BuyOutLstDtlTable
        {
            get { return this._uoeJnlDataSet.Tables[BuyOutLstDtlSchema.CT_BuyOutLstDtlDataTable]; }
        }
        # endregion

        # region ���_�ݒ�}�X�^
        /// <summary>
        /// ���_�ݒ�}�X�^
        /// </summary>
        public SecInfoSet secInfoSet
        {
            get { return this._secInfoSet; }
        }
        # endregion
        // 2009/05/25 END   <<<<<<

        # endregion

		# endregion

		// ===================================================================================== //
		// �p�u���b�N���\�b�h
		// ===================================================================================== //
		# region Public Methods
		# region ����M�i�m�k�����������t�n�d�����f�[�^�X�V�N���X�쐬
		/// <summary>
		/// ����M�i�m�k�����������t�n�d�����f�[�^�X�V�N���X�쐬
		/// </summary>
		/// <param name="para">����M�i�m�k��������</param>
		/// <returns>�t�n�d�����f�[�^</returns>
		public List<UOEOrderDtlWork> GetToOrderDtlFromOrder(List<OrderSndRcvJnl> para)
		{
			List<UOEOrderDtlWork> list = new List<UOEOrderDtlWork>();

			try
			{
				foreach (OrderSndRcvJnl orderSndRcvJnl in para)
				{
					UOEOrderDtlWork dtl = new UOEOrderDtlWork();


					list.Add(dtl);
				}
			}
			catch (Exception)
			{
				list.Clear();
			}
			return list;
		}
		# endregion

		# region ���f�[�^�e�[�u���̏�����
		/// <summary>
		/// �f�[�^�e�[�u���̏�����
		/// </summary>
		public void SchemaClear()
		{
			OrderSndRcvJnlSchema.SettingDataSet(ref _uoeJnlDataSet);    //����MJNL�i�����j
            EstmtSndRcvJnlSchema.SettingDataSet(ref _uoeJnlDataSet);    //����MJNL�i���ρj
            StockSndRcvJnlSchema.SettingDataSet(ref _uoeJnlDataSet);    //����MJNL�i�݌Ɂj
            UOEOrderDtlSchema.SettingDataSet(ref _uoeJnlDataSet);       //UOE�����f�[�^

            StockSlipSchema.SettingDataSet(ref _uoeJnlDataSet, StockSlipSchema.CT_StockSlipDataTable);      //�d���f�[�^
            StockSlipSchema.SettingDataSet(ref _uoeJnlDataSet, StockSlipSchema.CT_UoeStockSlipDataTable);   //�d���f�[�^(����d���X�V�p)

            StockDetailSchema.SettingDataSet(ref _uoeJnlDataSet, StockDetailSchema.CT_StockDetailDataTable);    //�d������
            StockDetailSchema.SettingDataSet(ref _uoeJnlDataSet, StockDetailSchema.CT_UoeStockDetailDataTable); //�d������(����d���X�V�p)

            SalesSlipSchema.SettingDataSet(ref _uoeJnlDataSet, SalesSlipSchema.CT_SalesSlipDataTable);  //����f�[�^
            SalesSlipSchema.SettingDataSet(ref _uoeJnlDataSet, SalesSlipSchema.CT_AcptSlipDataTable);   //�󒍃f�[�^

            SalesDetailSchema.SettingDataSet(ref _uoeJnlDataSet, SalesDetailSchema.CT_SalesDetailDataTable);    //���㖾��
            SalesDetailSchema.SettingDataSet(ref _uoeJnlDataSet, SalesDetailSchema.CT_AcptDetailDataTable);     //�󒍖���

            // 2009/05/25 START >>>>>>
            OrderLstInputDtlSchema.SettingDataSet(ref _uoeJnlDataSet, OrderLstInputDtlSchema.CT_OrderLstInputDtlDataTable);  //�����ꗗ����(�����)
            BuyOutLstDtlSchema.SettingDataSet(ref _uoeJnlDataSet, BuyOutLstDtlSchema.CT_BuyOutLstDtlDataTable);  //����ꗗ����
            // 2009/05/25 END   <<<<<<
        
        }
		# endregion

        # region ���t�n�d����M�f�[�^�e�[�u���̓Ǎ�
		# region �t�n�d����M�f�[�^�e�[�u�����������̓Ǎ�
		/// <summary>
		/// �t�n�d����M�f�[�^�e�[�u�����������̓Ǎ�
		/// </summary>
		/// <param name="uOESupplierCd">������</param>
		/// <param name="uOESalesOrderNo">�����ԍ�</param>
		/// <param name="uOESalesOrderRowNo">�����s�ԍ�</param>
		/// <returns></returns>
		public DataRow JnlOrderTblRead(int uOESupplierCd, int uOESalesOrderNo, int uOESalesOrderRowNo)
		{
			//�ϐ��̏�����
			DataRow row = null;
			
			try
			{
				object[] objFind = new object[4];
				objFind[0] = (object)_enterpriseCode;
				objFind[1] = (object)uOESupplierCd;
				objFind[2] = (object)uOESalesOrderNo;
				objFind[3] = (object)uOESalesOrderRowNo;
				row = this.OrderTable.Rows.Find(objFind);
			}
			catch
			{
				row = null;
			}
			return (row);
		}
		# endregion

		# region �t�n�d����M�f�[�^�e�[�u�������ρ��̓Ǎ�
		/// <summary>
		/// �t�n�d����M�f�[�^�e�[�u�������ρ��̓Ǎ�
		/// </summary>
		/// <param name="uOESupplierCd">������</param>
		/// <param name="uOESalesOrderNo">�����ԍ�</param>
		/// <param name="uOESalesOrderRowNo">�����s�ԍ�</param>
		/// <returns></returns>
		public DataRow JnlEstmtTblRead(int uOESupplierCd, int uOESalesOrderNo, int uOESalesOrderRowNo)
		{
			//�ϐ��̏�����
			DataRow row = null;

			try
			{
				object[] objFind = new object[4];
				objFind[0] = (object)_enterpriseCode;
				objFind[1] = (object)uOESupplierCd;
				objFind[2] = (object)uOESalesOrderNo;
				objFind[3] = (object)uOESalesOrderRowNo;
				row = this.EstmtTable.Rows.Find(objFind);
			}
			catch
			{
				row = null;
			}
			return (row);
		}
		# endregion

		# region �t�n�d����M�f�[�^�e�[�u�����݌Ɂ��̓Ǎ�
		/// <summary>
		///	�t�n�d����M�f�[�^�e�[�u�����݌Ɂ��̓Ǎ�
		/// </summary>
		/// <param name="uOESupplierCd">������</param>
		/// <param name="uOESalesOrderNo">�����ԍ�</param>
		/// <param name="uOESalesOrderRowNo">�����s�ԍ�</param>
		/// <returns></returns>
		public DataRow JnlStockTblRead(int uOESupplierCd, int uOESalesOrderNo, int uOESalesOrderRowNo)
		{
			//�ϐ��̏�����
			DataRow row = null;

			try
			{
				object[] objFind = new object[4];
				objFind[0] = (object)_enterpriseCode;
				objFind[1] = (object)uOESupplierCd;
				objFind[2] = (object)uOESalesOrderNo;
				objFind[3] = (object)uOESalesOrderRowNo;
				row = this.StockTable.Rows.Find(objFind);
			}
			catch
			{
				row = null;
			}
			return (row);
		}
		# endregion

		# region ��������P�ʁ��t�n�d����M�f�[�^�e�[�u�����������̓Ǎ�
        /// <summary>
        /// ����M�i�m�k���������̓Ǎ�
        /// </summary>
        /// <param name="uOESupplierCdList">UOE������</param>
        /// <param name="dataRecoverDiv">�����t���O</param>
        /// <returns>����M�i�m�k���������I�u�W�F�N�g</returns>
        public List<OrderSndRcvJnl> GetOrderSndRcvJnlList(List<int> uOESupplierCdList, int dataRecoverDiv)
        {
            List<int> dataRecoverDivList = new List<int>();
            dataRecoverDivList.Add(dataRecoverDiv);
            return (GetOrderSndRcvJnlList(uOESupplierCdList, dataRecoverDivList));
        }

        /// <summary>
        /// ����M�i�m�k���������̓Ǎ�
        /// </summary>
        /// <param name="uOESupplierCdList">UOE������</param>
        /// <returns>����M�i�m�k���������I�u�W�F�N�g</returns>
        public List<OrderSndRcvJnl> GetOrderSndRcvJnlList(List<int> uOESupplierCdList)
        {
            List<int> dataRecoverDivList = new List<int>();
            dataRecoverDivList.Add((int)EnumUoeConst.ctDataRecoverDiv.ct_YES);
            dataRecoverDivList.Add((int)EnumUoeConst.ctDataRecoverDiv.ct_NO);
            dataRecoverDivList.Add((int)EnumUoeConst.ctDataRecoverDiv.ct_NonProcess);
            return (GetOrderSndRcvJnlList(uOESupplierCdList, dataRecoverDivList));
        }

        /// <summary>
        /// ����M�i�m�k���������̓Ǎ�
        /// </summary>
        /// <param name="uOESupplierCdList">UOE������</param>
        /// <param name="dataRecoverDivList">�����t���O</param>
        /// <returns>����M�i�m�k���������I�u�W�F�N�g</returns>
        public List<OrderSndRcvJnl> GetOrderSndRcvJnlList(List<int> uOESupplierCdList, List<int> dataRecoverDivList)
        {
            //�ϐ��̏�����
            List<OrderSndRcvJnl> returnList = new List<OrderSndRcvJnl>();

            try
            {
                DataView dv = new DataView(OrderTable);

                //-----------------------------------------------------------
                // RowFilter�����̐ݒ�
                //-----------------------------------------------------------
                //�����t���O
                string filinf = "";
                string linkString = "( {0} = ";
                foreach (int dataRecoverDiv in dataRecoverDivList)
                {
                    filinf = filinf + linkString + dataRecoverDiv;
                    linkString = " OR {0} = ";
                }
                
                //UOE������
                linkString = " ) AND ( {1} = ";
                foreach (int uOESupplierCd in uOESupplierCdList)
                {
                    filinf = filinf + linkString + uOESupplierCd;
                    linkString = " OR {1} = ";
                }
                filinf = filinf + " )";

                dv.RowFilter = String.Format(filinf,
                                                OrderSndRcvJnlSchema.ct_Col_DataRecoverDiv,
                                                OrderSndRcvJnlSchema.ct_Col_UOESupplierCd);

                //-----------------------------------------------------------
                // Sort�����̐ݒ�
                //-----------------------------------------------------------
                dv.Sort = OrderSndRcvJnlSchema.ct_Col_SupplierCd + ", "
                        + OrderSndRcvJnlSchema.ct_Col_UOESalesOrderNo + ", "
                        + OrderSndRcvJnlSchema.ct_Col_UOESalesOrderRowNo;

                //����M�i�m�k�i�����j��DataRow �� �N���X���i�[����
                if (dv.Count > 0)
                {
                    for (int i = 0; i < dv.Count; i++)
                    {
                        DataRow dr = dv[i].Row;
                        OrderSndRcvJnl jnl = CreateOrderJnlFromSchema(dr);
                        returnList.Add(jnl);
                    }
                }
            }
            catch (Exception)
            {
                returnList = new List<OrderSndRcvJnl>();
            }
            return (returnList);
        }

		# endregion

		# region ��������P�ʁ��t�n�d����M�f�[�^�e�[�u�������ρ��̓Ǎ�
        /// <summary>
        /// ����M�i�m�k�����ρ��̓Ǎ�
        /// </summary>
        /// <param name="uOESupplierCdList">UOE������</param>
        /// <param name="dataRecoverDiv">�����t���O</param>
        /// <returns>����M�i�m�k�����ρ��I�u�W�F�N�g</returns>
        public List<EstmtSndRcvJnl> GetEstmtSndRcvJnlList(List<int> uOESupplierCdList, int dataRecoverDiv)
        {
            List<int> dataRecoverDivList = new List<int>();
            dataRecoverDivList.Add(dataRecoverDiv);
            return (GetEstmtSndRcvJnlList(uOESupplierCdList, dataRecoverDivList));
        }

        /// <summary>
        /// ����M�i�m�k�����ρ��̓Ǎ�
        /// </summary>
        /// <param name="uOESupplierCdList">UOE������</param>
        /// <returns>����M�i�m�k�����ρ��I�u�W�F�N�g</returns>
        public List<EstmtSndRcvJnl> GetEstmtSndRcvJnlList(List<int> uOESupplierCdList)
        {
            List<int> dataRecoverDivList = new List<int>();
            dataRecoverDivList.Add((int)EnumUoeConst.ctDataRecoverDiv.ct_YES);
            dataRecoverDivList.Add((int)EnumUoeConst.ctDataRecoverDiv.ct_NO);
            dataRecoverDivList.Add((int)EnumUoeConst.ctDataRecoverDiv.ct_NonProcess);
            return (GetEstmtSndRcvJnlList(uOESupplierCdList, dataRecoverDivList));
        }

        /// <summary>
        /// ����M�i�m�k�����ρ��̓Ǎ�
        /// </summary>
        /// <param name="uOESupplierCdList">UOE������</param>
        /// <param name="dataRecoverDivList">�����t���O</param>
        /// <returns>����M�i�m�k�����ρ��I�u�W�F�N�g</returns>
        public List<EstmtSndRcvJnl> GetEstmtSndRcvJnlList(List<int> uOESupplierCdList, List<int> dataRecoverDivList)
        {
            //�ϐ��̏�����
            List<EstmtSndRcvJnl> returnList = new List<EstmtSndRcvJnl>();

            try
            {
                DataView dv = new DataView(EstmtTable);

                //-----------------------------------------------------------
                // RowFilter�����̐ݒ�
                //-----------------------------------------------------------
                //�����t���O
                string filinf = "";
                string linkString = "( {0} = ";
                foreach (int dataRecoverDiv in dataRecoverDivList)
                {
                    filinf = filinf + linkString + dataRecoverDiv;
                    linkString = " OR {0} = ";
                }

                //UOE������
                linkString = " ) AND ( {1} = ";
                foreach (int uOESupplierCd in uOESupplierCdList)
                {
                    filinf = filinf + linkString + uOESupplierCd;
                    linkString = " OR {1} = ";
                }
                filinf = filinf + " )";

                dv.RowFilter = String.Format(filinf,
                                                EstmtSndRcvJnlSchema.ct_Col_DataRecoverDiv,
                                                EstmtSndRcvJnlSchema.ct_Col_UOESupplierCd);

                //-----------------------------------------------------------
                // Sort�����̐ݒ�
                //-----------------------------------------------------------
                dv.Sort = EstmtSndRcvJnlSchema.ct_Col_SupplierCd + ", "
                        + EstmtSndRcvJnlSchema.ct_Col_UOESalesOrderNo + ", "
                        + EstmtSndRcvJnlSchema.ct_Col_UOESalesOrderRowNo;

                //����M�i�m�k�i���ρj��DataRow �� �N���X���i�[����
                if (dv.Count > 0)
                {
                    for (int i = 0; i < dv.Count; i++)
                    {
                        DataRow dr = dv[i].Row;
                        EstmtSndRcvJnl jnl = CreateEstmtJnlFromSchema(ref dr);
                        returnList.Add(jnl);
                    }
                }
            }
            catch (Exception)
            {
                returnList = new List<EstmtSndRcvJnl>();
            }
            return (returnList);
        }

		# endregion

		# region ��������P�ʁ��t�n�d����M�f�[�^�e�[�u�����݌Ɂ��̓Ǎ�
        /// <summary>
        /// ����M�i�m�k���݌Ɂ��̓Ǎ�
        /// </summary>
        /// <param name="uOESupplierCdList">UOE������</param>
        /// <param name="dataRecoverDiv">�����t���O</param>
        /// <returns>����M�i�m�k���݌Ɂ��I�u�W�F�N�g</returns>
        public List<StockSndRcvJnl> GetStockSndRcvJnlList(List<int> uOESupplierCdList, int dataRecoverDiv)
        {
            List<int> dataRecoverDivList = new List<int>();
            dataRecoverDivList.Add(dataRecoverDiv);
            return (GetStockSndRcvJnlList(uOESupplierCdList, dataRecoverDivList));
        }

        /// <summary>
        /// ����M�i�m�k���݌Ɂ��̓Ǎ�
        /// </summary>
        /// <param name="uOESupplierCdList">UOE������</param>
        /// <returns>����M�i�m�k���݌Ɂ��I�u�W�F�N�g</returns>
        public List<StockSndRcvJnl> GetStockSndRcvJnlList(List<int> uOESupplierCdList)
        {
            List<int> dataRecoverDivList = new List<int>();
            dataRecoverDivList.Add((int)EnumUoeConst.ctDataRecoverDiv.ct_YES);
            dataRecoverDivList.Add((int)EnumUoeConst.ctDataRecoverDiv.ct_NO);
            dataRecoverDivList.Add((int)EnumUoeConst.ctDataRecoverDiv.ct_NonProcess);
            return (GetStockSndRcvJnlList(uOESupplierCdList, dataRecoverDivList));
        }

        /// <summary>
        /// ����M�i�m�k���݌Ɂ��̓Ǎ�
        /// </summary>
        /// <param name="uOESupplierCdList">UOE������</param>
        /// <param name="dataRecoverDivList">�����t���O</param>
        /// <returns>����M�i�m�k���݌Ɂ��I�u�W�F�N�g</returns>
        public List<StockSndRcvJnl> GetStockSndRcvJnlList(List<int> uOESupplierCdList, List<int> dataRecoverDivList)
        {
            //�ϐ��̏�����
            List<StockSndRcvJnl> returnList = new List<StockSndRcvJnl>();

            try
            {
                DataView dv = new DataView(StockTable);

                //-----------------------------------------------------------
                // RowFilter�����̐ݒ�
                //-----------------------------------------------------------
                //�����t���O
                string filinf = "";
                string linkString = "( {0} = ";
                foreach (int dataRecoverDiv in dataRecoverDivList)
                {
                    filinf = filinf + linkString + dataRecoverDiv;
                    linkString = " OR {0} = ";
                }

                //UOE������
                linkString = " ) AND ( {1} = ";
                foreach (int uOESupplierCd in uOESupplierCdList)
                {
                    filinf = filinf + linkString + uOESupplierCd;
                    linkString = " OR {1} = ";
                }
                filinf = filinf + " )";

                dv.RowFilter = String.Format(filinf,
                                                StockSndRcvJnlSchema.ct_Col_DataRecoverDiv,
                                                StockSndRcvJnlSchema.ct_Col_UOESupplierCd);

                //-----------------------------------------------------------
                // Sort�����̐ݒ�
                //-----------------------------------------------------------
                dv.Sort = StockSndRcvJnlSchema.ct_Col_SupplierCd + ", "
                        + StockSndRcvJnlSchema.ct_Col_UOESalesOrderNo + ", "
                        + StockSndRcvJnlSchema.ct_Col_UOESalesOrderRowNo;

                //����M�i�m�k�i�݌Ɂj��DataRow �� �N���X���i�[����
                if (dv.Count > 0)
                {
                    for (int i = 0; i < dv.Count; i++)
                    {
                        DataRow dr = dv[i].Row;
                        StockSndRcvJnl jnl = CreateStockJnlFromSchema(ref dr);
                        returnList.Add(jnl);
                    }
                }
            }
            catch (Exception)
            {
                returnList = new List<StockSndRcvJnl>();
            }
            return (returnList);
        }

		# endregion
		# endregion

        # region �����M�t���O�E�����t���O�̍X�V
        # region ���������t�n�d����M�f�[�^�e�[�u�������M�t���O�E�����t���O���̍X�V
        /// <summary>
		/// ���������t�n�d����M�f�[�^�e�[�u�������M�t���O�E�����t���O���̍X�V
		/// </summary>
		/// <param name="uOESupplierCd">������R�[�h</param>
		/// <param name="SrcDataSendCode">���M�t���O(���o�Ώ�)</param>
		/// <param name="SrcDataRecoverDiv">�����t���O(���o�Ώ�)</param>
		/// <param name="DstDataSendCode">���M�t���O(�ύX���e)</param>
		/// <param name="DstDataRecoverDiv">�����t���O(�ύX���e)</param>
		public void JnlOrderTblFlgUpdt(int uOESupplierCd, int SrcDataSendCode, int SrcDataRecoverDiv, int DstDataSendCode, int DstDataRecoverDiv)
		{
			DataView dv = new DataView(OrderTable);
			string filinf = "{0} = '" + _enterpriseCode + "'"
					 + " AND {1} = " + uOESupplierCd
					 + " AND {2} = " + SrcDataSendCode
					 + " AND {3} = " + SrcDataRecoverDiv;
			dv.RowFilter = String.Format(filinf,
											OrderSndRcvJnlSchema.ct_Col_EnterpriseCode,
											OrderSndRcvJnlSchema.ct_Col_UOESupplierCd,
											OrderSndRcvJnlSchema.ct_Col_DataSendCode,
											OrderSndRcvJnlSchema.ct_Col_DataRecoverDiv);
			dv.Sort = "";

			//�Y���f�[�^�Ȃ�
            int dvMax = dv.Count;
            if (dvMax == 0)
			{
				return;
			}

			//����M�i�m�k�i�����j��DataRow �� �N���X���i�[����
            foreach (DataRowView rowDv in dv)
            {
                rowDv[OrderSndRcvJnlSchema.ct_Col_DataSendCode] = DstDataSendCode;
                rowDv[OrderSndRcvJnlSchema.ct_Col_DataRecoverDiv] = DstDataRecoverDiv;
            }
        }

        // --- ADD 2012/10/03 ----------->>>>>
        /// <summary>
        /// ���������t�n�d����M�f�[�^�e�[�u�������M�t���O�E�����t���O���̍X�V(�D��)
        /// </summary>
        /// <param name="uOESupplierCd">������R�[�h</param>
        /// <param name="srcDataSendCode">���M�t���O(���o�Ώ�)</param>
        /// <param name="srcDataRecoverDiv">�����t���O(���o�Ώ�)</param>
        /// <param name="dstDataSendCode">���M�t���O(�ύX���e)</param>
        /// <param name="dstDataRecoverDiv">�����t���O(�ύX���e)</param>
        /// <remarks>
        /// <br></br>
        /// <br>Note       : �t�n�d����M�f�[�^�̑��M�t���O�E�����t���O���X�V���܂�(�D��)</br>
        /// <br>Programmer : FSI���X�� �M�p</br>
        /// <br>Date       : 2012/10/03</br>
        /// </remarks>
        public void JnlOrderTblFlgUpdt1001(int uOESupplierCd, int srcDataSendCode, int srcDataRecoverDiv, int dstDataSendCode, int dstDataRecoverDiv)
        {
            DataView dv = new DataView(OrderTable);
            string filinf = "{0} = '" + _enterpriseCode + "'"
                     + " AND {1} = " + uOESupplierCd
                     + " AND {2} = " + dstDataSendCode
                     + " AND {3} = " + dstDataRecoverDiv;

            // ���ɑ��M�t���O����M�G���[�ƂȂ��Ă��閾�ׂ����݂��邩�ۂ�
            dv.RowFilter = String.Format(filinf,
                OrderSndRcvJnlSchema.ct_Col_EnterpriseCode,
                OrderSndRcvJnlSchema.ct_Col_UOESupplierCd,
                OrderSndRcvJnlSchema.ct_Col_DataSendCode,
                OrderSndRcvJnlSchema.ct_Col_DataRecoverDiv);
            if (dv.Count > 0)
            {
                // ���ɑ��M�t���O����M�G���[�ƂȂ��Ă��閾�ׂ����݂���ꍇ�A�����𒆒f����
                return;
            }

            // ���M�t���O���������ł��閾�ׂ��擾����
            filinf = "{0} = '" + _enterpriseCode + "'"
                     + " AND {1} = " + uOESupplierCd
                     + " AND {2} = " + srcDataSendCode
                     + " AND {3} = " + srcDataRecoverDiv;
            dv.RowFilter = String.Format(filinf,
                                            OrderSndRcvJnlSchema.ct_Col_EnterpriseCode,
                                            OrderSndRcvJnlSchema.ct_Col_UOESupplierCd,
                                            OrderSndRcvJnlSchema.ct_Col_DataSendCode,
                                            OrderSndRcvJnlSchema.ct_Col_DataRecoverDiv);
            dv.Sort = String.Format("{0}", OrderSndRcvJnlSchema.ct_Col_OnlineRowNo);

            //�Y���f�[�^�Ȃ�
            int dvMax = dv.Count;
            if (dvMax == 0)
            {
                return;
            }

            // ���M�t���O���������ŁA���הԍ�����ԏ����Ȗ��ׂƓ���UOE�����ԍ��������ׂ��擾����
            dv.RowFilter = dv.RowFilter
                + string.Format(" AND {0} = {1}", OrderSndRcvJnlSchema.ct_Col_UOESalesOrderNo, dv[0][OrderSndRcvJnlSchema.ct_Col_UOESalesOrderNo]);

            //����M�i�m�k�i�����j��DataRow �� �N���X���i�[����
            foreach( DataRowView rowDv in dv )
            {
                rowDv[OrderSndRcvJnlSchema.ct_Col_DataSendCode] = dstDataSendCode;
                rowDv[OrderSndRcvJnlSchema.ct_Col_DataRecoverDiv] = dstDataRecoverDiv;
            }
        }
        // --- ADD 2012/10/03 -----------<<<<<
        # endregion

        # region �����ρ��t�n�d����M�f�[�^�e�[�u�������M�t���O�E�����t���O���̍X�V
		/// <summary>
		/// �����ρ��t�n�d����M�f�[�^�e�[�u�������M�t���O�E�����t���O���̍X�V
		/// </summary>
		/// <param name="uOESupplierCd">������R�[�h</param>
		/// <param name="SrcDataSendCode">���M�t���O(���o�Ώ�)</param>
		/// <param name="SrcDataRecoverDiv">�����t���O(���o�Ώ�)</param>
		/// <param name="DstDataSendCode">���M�t���O(�ύX���e)</param>
		/// <param name="DstDataRecoverDiv">�����t���O(�ύX���e)</param>
		public void JnlEstmtTblFlgUpdt(int uOESupplierCd, int SrcDataSendCode, int SrcDataRecoverDiv, int DstDataSendCode, int DstDataRecoverDiv)
		{
			DataView dv = new DataView(EstmtTable);
			string filinf = "{0} = '" + _enterpriseCode + "'"
					 + " AND {1} = " + uOESupplierCd
					 + " AND {2} = " + SrcDataSendCode
					 + " AND {3} = " + SrcDataRecoverDiv;
			dv.RowFilter = String.Format(filinf,
											EstmtSndRcvJnlSchema.ct_Col_EnterpriseCode,
											EstmtSndRcvJnlSchema.ct_Col_UOESupplierCd,
											EstmtSndRcvJnlSchema.ct_Col_DataSendCode,
											EstmtSndRcvJnlSchema.ct_Col_DataRecoverDiv);
			dv.Sort = "";

            //�Y���f�[�^�Ȃ�
            int dvMax = dv.Count;
            if (dvMax == 0)
            {
                return;
            }

            //����M�i�m�k�i���ρj��DataRow �� �N���X���i�[����
            foreach (DataRowView rowDv in dv)
            {
                rowDv[EstmtSndRcvJnlSchema.ct_Col_DataSendCode] = DstDataSendCode;
                rowDv[EstmtSndRcvJnlSchema.ct_Col_DataRecoverDiv] = DstDataRecoverDiv;
            }
		}


        # endregion

        # region ���݌Ɂ��t�n�d����M�f�[�^�e�[�u�������M�t���O�E�����t���O���̍X�V
		/// <summary>
		/// ���݌Ɂ��t�n�d����M�f�[�^�e�[�u�������M�t���O�E�����t���O���̍X�V
		/// </summary>
		/// <param name="uOESupplierCd">������R�[�h</param>
		/// <param name="SrcDataSendCode">���M�t���O(���o�Ώ�)</param>
		/// <param name="SrcDataRecoverDiv">�����t���O(���o�Ώ�)</param>
		/// <param name="DstDataSendCode">���M�t���O(�ύX���e)</param>
		/// <param name="DstDataRecoverDiv">�����t���O(�ύX���e)</param>
		public void JnlStockTblFlgUpdt(int uOESupplierCd, int SrcDataSendCode, int SrcDataRecoverDiv, int DstDataSendCode, int DstDataRecoverDiv)
		{
			DataView dv = new DataView(StockTable);
			string filinf = "{0} = '" + _enterpriseCode + "'"
					 + " AND {1} = " + uOESupplierCd
					 + " AND {2} = " + SrcDataSendCode
					 + " AND {3} = " + SrcDataRecoverDiv;
			dv.RowFilter = String.Format(filinf,
											StockSndRcvJnlSchema.ct_Col_EnterpriseCode,
											StockSndRcvJnlSchema.ct_Col_UOESupplierCd,
											StockSndRcvJnlSchema.ct_Col_DataSendCode,
											StockSndRcvJnlSchema.ct_Col_DataRecoverDiv);
			dv.Sort = "";

			//�Y���f�[�^�Ȃ�
            //�Y���f�[�^�Ȃ�
            int dvMax = dv.Count;
            if (dvMax == 0)
            {
                return;
            }

            //����M�i�m�k�i�݌Ɂj��DataRow �� �N���X���i�[����
            foreach (DataRowView rowDv in dv)
            {
                rowDv[StockSndRcvJnlSchema.ct_Col_DataSendCode] = DstDataSendCode;
                rowDv[StockSndRcvJnlSchema.ct_Col_DataRecoverDiv] = DstDataRecoverDiv;
            }
		}
        # endregion
        # endregion
        # endregion

        // ===================================================================================== //
		// �v���C�x�[�g���\�b�h
		// ===================================================================================== //
		# region Private Methods
		# region ���t�n�d�����f�[�^������M�i�m�k�X�V�N���X�쐬
        # region �t�n�d�����f�[�^������M�i�m�k�����ρ��X�V�N���X�쐬
		/// <summary>
		/// �t�n�d�����f�[�^������M�i�m�k�����ρ��X�V�N���X�쐬
		/// </summary>
		/// <param name="para">�t�n�d�����f�[�^�N���X List<UOEOrderDtlWork></param>
		/// <returns>����M�i�m�k�����ρ��N���X List<EstmtSndRcvJnl></returns>
		private List<EstmtSndRcvJnl> GetToEstmtFromOrderDtl(List<UOEOrderDtlWork> para)
		{
			List<EstmtSndRcvJnl> list = new List<EstmtSndRcvJnl>();

			try
			{
				foreach (UOEOrderDtlWork uOEOrderDtlRet in para)
				{
					EstmtSndRcvJnl jnl = new EstmtSndRcvJnl();

					//jnl.CreateDateTime = uOEOrderDtlRet.CreateDateTime; // �쐬����
					//jnl.UpdateDateTime = uOEOrderDtlRet.UpdateDateTime; // �X�V����
					jnl.EnterpriseCode = uOEOrderDtlRet.EnterpriseCode; // ��ƃR�[�h
					//jnl.FileHeaderGuid = uOEOrderDtlRet.FileHeaderGuid; // GUID
					//jnl.UpdEmployeeCode = uOEOrderDtlRet.UpdEmployeeCode; // �X�V�]�ƈ��R�[�h
					//jnl.UpdAssemblyId1 = uOEOrderDtlRet.UpdAssemblyId1; // �X�V�A�Z���u��ID1
					//jnl.UpdAssemblyId2 = uOEOrderDtlRet.UpdAssemblyId2; // �X�V�A�Z���u��ID2
					//jnl.LogicalDeleteCode = uOEOrderDtlRet.LogicalDeleteCode; // �_���폜�敪
					jnl.SystemDivCd = uOEOrderDtlRet.SystemDivCd; // �V�X�e���敪
					jnl.UOESalesOrderNo = uOEOrderDtlRet.UOESalesOrderNo; // UOE�����ԍ�
					jnl.UOESalesOrderRowNo = uOEOrderDtlRet.UOESalesOrderRowNo; // UOE�����s�ԍ�
					jnl.SendTerminalNo = uOEOrderDtlRet.SendTerminalNo; // ���M�[���ԍ�
					jnl.UOESupplierCd = uOEOrderDtlRet.UOESupplierCd; // UOE������R�[�h
					jnl.UOESupplierName = uOEOrderDtlRet.UOESupplierName; // UOE�����於��
					jnl.OnlineNo = uOEOrderDtlRet.OnlineNo; // �I�����C���ԍ�
					jnl.OnlineRowNo = uOEOrderDtlRet.OnlineRowNo; // �I�����C���s�ԍ�
					jnl.SalesDate = uOEOrderDtlRet.SalesDate; // ������t
					//jnl.SalesTime = uOEOrderDtlRet.SalesTime; // ���㎞��
					jnl.SalesSlipNum = uOEOrderDtlRet.SalesSlipNum; // ����`�[�ԍ�
					//jnl.DetailRowCount = uOEOrderDtlRet.DetailRowCount; // ���׍s��
					jnl.CustomerCode = uOEOrderDtlRet.CustomerCode; // ���Ӑ�R�[�h
					//jnl.CustomerName = uOEOrderDtlRet.CustomerName; // ���Ӑ於��
					jnl.CashRegisterNo = uOEOrderDtlRet.CashRegisterNo; // ���W�ԍ�
					jnl.CommonSeqNo = uOEOrderDtlRet.CommonSeqNo; // ���ʒʔ�
					//jnl.SlipDtlNum = uOEOrderDtlRet.SlipDtlNum; // ���גʔ�
					//jnl.SlipDtlNumDerivNo = uOEOrderDtlRet.SlipDtlNumDerivNo; // ���גʔԎ}��
					jnl.BoCode = uOEOrderDtlRet.BoCode; // BO�敪
                    jnl.UOEDeliGoodsDiv = uOEOrderDtlRet.UOEDeliGoodsDiv; // �[�i�敪
					jnl.DeliveredGoodsDivNm = uOEOrderDtlRet.DeliveredGoodsDivNm; // �[�i�敪����
					jnl.FollowDeliGoodsDiv = uOEOrderDtlRet.FollowDeliGoodsDiv; // �t�H���[�[�i�敪
					jnl.FollowDeliGoodsDivNm = uOEOrderDtlRet.FollowDeliGoodsDivNm; // �t�H���[�[�i�敪����
					jnl.UOEResvdSection = uOEOrderDtlRet.UOEResvdSection; // UOE�w�苒�_
					jnl.UOEResvdSectionNm = uOEOrderDtlRet.UOEResvdSectionNm; // UOE�w�苒�_����
					jnl.EmployeeCode = uOEOrderDtlRet.EmployeeCode; // �]�ƈ��R�[�h
					jnl.EmployeeName = uOEOrderDtlRet.EmployeeName; // �]�ƈ�����
					jnl.GoodsMakerCd = uOEOrderDtlRet.GoodsMakerCd; // ���i���[�J�[�R�[�h
					jnl.MakerName = uOEOrderDtlRet.MakerName; // ���[�J�[����
					jnl.GoodsNo = uOEOrderDtlRet.GoodsNo; // ���i�ԍ�
					jnl.GoodsNoNoneHyphen = uOEOrderDtlRet.GoodsNoNoneHyphen; // �n�C�t�������i�ԍ�
					jnl.GoodsName = uOEOrderDtlRet.GoodsName; // ���i����
					jnl.AcceptAnOrderCnt = uOEOrderDtlRet.AcceptAnOrderCnt; // �󒍐���
					jnl.SupplierCd = uOEOrderDtlRet.SupplierCd; // �d����R�[�h
					jnl.SupplierSnm = uOEOrderDtlRet.SupplierSnm; // �d���旪��
					jnl.UoeRemark1 = uOEOrderDtlRet.UoeRemark1; // �t�n�d���}�[�N�P
					jnl.UoeRemark2 = uOEOrderDtlRet.UoeRemark2; // �t�n�d���}�[�N�Q
					//jnl.EstimateRate = uOEOrderDtlRet.EstimateRate; // ���σ��[�g
					//jnl.SelectCode = uOEOrderDtlRet.SelectCode; // �I���R�[�h
					jnl.ReceiveDate = uOEOrderDtlRet.ReceiveDate; // ��M���t
					jnl.ReceiveTime = uOEOrderDtlRet.ReceiveTime; // ��M����
					jnl.AnswerMakerCd = uOEOrderDtlRet.AnswerMakerCd; // �񓚃��[�J�[�R�[�h
					jnl.AnswerPartsNo = uOEOrderDtlRet.AnswerPartsNo; // �񓚕i��
					jnl.AnswerPartsName = uOEOrderDtlRet.AnswerPartsName; // �񓚕i��
					jnl.SubstPartsNo = uOEOrderDtlRet.SubstPartsNo; // ��֕i��
					jnl.ListPrice = uOEOrderDtlRet.ListPrice; // �艿
					//jnl.SalesUnPrcTaxExcFl = uOEOrderDtlRet.SalesUnPrcTaxExcFl; // ����P���i�Ŕ��C�����j
					//jnl.HeadQtrsStock = uOEOrderDtlRet.HeadQtrsStock; // �{���݌�
					//jnl.BranchStock = uOEOrderDtlRet.BranchStock; // ���_�݌�
					//jnl.SectionStock = uOEOrderDtlRet.SectionStock; // �x�X�݌�
					//jnl.UOESectionCode1 = uOEOrderDtlRet.UOESectionCode1; // UOE���_�R�[�h�P
					//jnl.UOESectionCode2 = uOEOrderDtlRet.UOESectionCode2; // UOE���_�R�[�h�Q
					//jnl.UOESectionCode3 = uOEOrderDtlRet.UOESectionCode3; // UOE���_�R�[�h�R
					//jnl.UOESectionStock1 = uOEOrderDtlRet.UOESectionStock1; // UOE���_�݌ɐ��P
					//jnl.UOESectionStock2 = uOEOrderDtlRet.UOESectionStock2; // UOE���_�݌ɐ��Q
					//jnl.UOESectionStock3 = uOEOrderDtlRet.UOESectionStock3; // UOE���_�݌ɐ��R
					//jnl.UOEDelivDateCd = uOEOrderDtlRet.UOEDelivDateCd; // UOE�[���R�[�h
					//jnl.UOESubstCode = uOEOrderDtlRet.UOESubstCode; // UOE��փR�[�h
					//jnl.UOEPriceCode = uOEOrderDtlRet.UOEPriceCode; // UOE���i�R�[�h
					jnl.SalesUnitCost = uOEOrderDtlRet.SalesUnitCost; // �����P��
					jnl.PartsLayerCd = uOEOrderDtlRet.PartsLayerCd; // �w�ʃR�[�h
					jnl.HeadErrorMassage = uOEOrderDtlRet.HeadErrorMassage; // �w�b�h�G���[���b�Z�[�W
					jnl.LineErrorMassage = uOEOrderDtlRet.LineErrorMassage; // ���C���G���[���b�Z�[�W
					jnl.DataSendCode = uOEOrderDtlRet.DataSendCode; // �f�[�^���M�敪
					jnl.DataRecoverDiv = uOEOrderDtlRet.DataRecoverDiv; // �f�[�^�����敪

					list.Add(jnl);
				}
			}
			catch (Exception)
			{
				list.Clear();
			}
			return list;
		}
		# endregion

		# region �t�n�d�����f�[�^������M�i�m�k���݌Ɂ��X�V�N���X�쐬
		/// <summary>
		/// �t�n�d�����f�[�^������M�i�m�k���݌Ɂ��X�V�N���X�쐬
		/// </summary>
		/// <param name="para">�t�n�d�����f�[�^�N���X List<UOEOrderDtlWork></param>
		/// <returns>����M�i�m�k�����ρ��N���X List<StockSndRcvJnl></returns>
		private List<StockSndRcvJnl> GetToStockFromOrderDtl(List<UOEOrderDtlWork> para)
		{
			List<StockSndRcvJnl> list = new List<StockSndRcvJnl>();

			try
			{
				foreach (UOEOrderDtlWork uOEOrderDtlRet in para)
				{
					StockSndRcvJnl jnl = new StockSndRcvJnl();

					//jnl.CreateDateTime = uOEOrderDtlRet.CreateDateTime; // �쐬����
					//jnl.UpdateDateTime = uOEOrderDtlRet.UpdateDateTime; // �X�V����
					jnl.EnterpriseCode = uOEOrderDtlRet.EnterpriseCode; // ��ƃR�[�h
					//jnl.FileHeaderGuid = uOEOrderDtlRet.FileHeaderGuid; // GUID
					//jnl.UpdEmployeeCode = uOEOrderDtlRet.UpdEmployeeCode; // �X�V�]�ƈ��R�[�h
					//jnl.UpdAssemblyId1 = uOEOrderDtlRet.UpdAssemblyId1; // �X�V�A�Z���u��ID1
					//jnl.UpdAssemblyId2 = uOEOrderDtlRet.UpdAssemblyId2; // �X�V�A�Z���u��ID2
					//jnl.LogicalDeleteCode = uOEOrderDtlRet.LogicalDeleteCode; // �_���폜�敪

					jnl.SystemDivCd = uOEOrderDtlRet.SystemDivCd; // �V�X�e���敪
					jnl.UOESalesOrderNo = uOEOrderDtlRet.UOESalesOrderNo; // UOE�����ԍ�
					jnl.UOESalesOrderRowNo = uOEOrderDtlRet.UOESalesOrderRowNo; // UOE�����s�ԍ�
					jnl.SendTerminalNo = uOEOrderDtlRet.SendTerminalNo; // ���M�[���ԍ�
					jnl.UOESupplierCd = uOEOrderDtlRet.UOESupplierCd; // UOE������R�[�h
					jnl.UOESupplierName = uOEOrderDtlRet.UOESupplierName; // UOE�����於��
					jnl.OnlineNo = uOEOrderDtlRet.OnlineNo; // �I�����C���ԍ�
					jnl.OnlineRowNo = uOEOrderDtlRet.OnlineRowNo; // �I�����C���s�ԍ�
					jnl.SalesSlipNum = uOEOrderDtlRet.SalesSlipNum; // ����`�[�ԍ�
					//jnl.DetailRowCount = uOEOrderDtlRet.DetailRowCount; // ���׍s��
					jnl.SalesDate = uOEOrderDtlRet.SalesDate; // ������t
					//jnl.SalesTime = uOEOrderDtlRet.SalesTime; // ���㎞��
					jnl.CustomerCode = uOEOrderDtlRet.CustomerCode; // ���Ӑ�R�[�h
					//jnl.CustomerName = uOEOrderDtlRet.CustomerName; // ���Ӑ於��
					jnl.CashRegisterNo = uOEOrderDtlRet.CashRegisterNo; // ���W�ԍ�
					jnl.CommonSeqNo = uOEOrderDtlRet.CommonSeqNo; // ���ʒʔ�
					//jnl.SlipDtlNum = uOEOrderDtlRet.SlipDtlNum; // ���גʔ�
					//jnl.SlipDtlNumDerivNo = uOEOrderDtlRet.SlipDtlNumDerivNo; // ���גʔԎ}��
					jnl.BoCode = uOEOrderDtlRet.BoCode; // BO�敪
                    jnl.UOEDeliGoodsDiv = uOEOrderDtlRet.UOEDeliGoodsDiv; // �[�i�敪
					jnl.DeliveredGoodsDivNm = uOEOrderDtlRet.DeliveredGoodsDivNm; // �[�i�敪����
					jnl.FollowDeliGoodsDiv = uOEOrderDtlRet.FollowDeliGoodsDiv; // �t�H���[�[�i�敪
					jnl.FollowDeliGoodsDivNm = uOEOrderDtlRet.FollowDeliGoodsDivNm; // �t�H���[�[�i�敪����
					jnl.UOEResvdSection = uOEOrderDtlRet.UOEResvdSection; // UOE�w�苒�_
					jnl.UOEResvdSectionNm = uOEOrderDtlRet.UOEResvdSectionNm; // UOE�w�苒�_����
					jnl.EmployeeCode = uOEOrderDtlRet.EmployeeCode; // �]�ƈ��R�[�h
					jnl.EmployeeName = uOEOrderDtlRet.EmployeeName; // �]�ƈ�����
					jnl.GoodsMakerCd = uOEOrderDtlRet.GoodsMakerCd; // ���i���[�J�[�R�[�h
					jnl.MakerName = uOEOrderDtlRet.MakerName; // ���[�J�[����
					jnl.GoodsNo = uOEOrderDtlRet.GoodsNo; // ���i�ԍ�
					jnl.GoodsNoNoneHyphen = uOEOrderDtlRet.GoodsNoNoneHyphen; // �n�C�t�������i�ԍ�
					jnl.GoodsName = uOEOrderDtlRet.GoodsName; // ���i����
					jnl.AcceptAnOrderCnt = uOEOrderDtlRet.AcceptAnOrderCnt; // �󒍐���
					jnl.SupplierCd = uOEOrderDtlRet.SupplierCd; // �d����R�[�h
					jnl.SupplierSnm = uOEOrderDtlRet.SupplierSnm; // �d���旪��
					jnl.UoeRemark1 = uOEOrderDtlRet.UoeRemark1; // �t�n�d���}�[�N�P
					jnl.UoeRemark2 = uOEOrderDtlRet.UoeRemark2; // �t�n�d���}�[�N�Q
					jnl.ReceiveDate = uOEOrderDtlRet.ReceiveDate; // ��M���t
					jnl.ReceiveTime = uOEOrderDtlRet.ReceiveTime; // ��M����
					jnl.AnswerMakerCd = uOEOrderDtlRet.AnswerMakerCd; // �񓚃��[�J�[�R�[�h
					jnl.AnswerPartsNo = uOEOrderDtlRet.AnswerPartsNo; // �񓚕i��
					jnl.AnswerPartsName = uOEOrderDtlRet.AnswerPartsName; // �񓚕i��
					jnl.SubstPartsNo = uOEOrderDtlRet.SubstPartsNo; // ��֕i��
					//jnl.CenterSubstPartsNo = uOEOrderDtlRet.CenterSubstPartsNo; // ��֕i�ԁi�Z���^�[�j
					jnl.ListPrice = uOEOrderDtlRet.ListPrice; // �艿
					jnl.SalesUnitCost = uOEOrderDtlRet.SalesUnitCost; // �����P��
					//jnl.GoodsAPrice = uOEOrderDtlRet.GoodsAPrice; // ���i�`���i
					//jnl.UOEStopCd = uOEOrderDtlRet.UOEStopCd; // UOE���~�R�[�h
					//jnl.UOESubstCode = uOEOrderDtlRet.UOESubstCode; // UOE��փR�[�h
					//jnl.UOEDelivDateCd = uOEOrderDtlRet.UOEDelivDateCd; // UOE�[���R�[�h
					jnl.PartsLayerCd = uOEOrderDtlRet.PartsLayerCd; // �w�ʃR�[�h
					//jnl.ShopStUnitPrice = uOEOrderDtlRet.ShopStUnitPrice; // �̔��X�d���P��
					//jnl.UOESectionCode1 = uOEOrderDtlRet.UOESectionCode1; // UOE���_�R�[�h�P
					//jnl.UOESectionCode2 = uOEOrderDtlRet.UOESectionCode2; // UOE���_�R�[�h�Q
					//jnl.UOESectionCode3 = uOEOrderDtlRet.UOESectionCode3; // UOE���_�R�[�h�R
					//jnl.UOESectionCode4 = uOEOrderDtlRet.UOESectionCode4; // UOE���_�R�[�h�S
					//jnl.UOESectionCode5 = uOEOrderDtlRet.UOESectionCode5; // UOE���_�R�[�h�T
					//jnl.UOESectionCode6 = uOEOrderDtlRet.UOESectionCode6; // UOE���_�R�[�h�U
					//jnl.UOESectionCode7 = uOEOrderDtlRet.UOESectionCode7; // UOE���_�R�[�h�V
					//jnl.UOESectionCode8 = uOEOrderDtlRet.UOESectionCode8; // UOE���_�R�[�h�W
					//jnl.UOESectionStock1 = uOEOrderDtlRet.UOESectionStock1; // UOE���_�݌ɐ��P
					//jnl.UOESectionStock2 = uOEOrderDtlRet.UOESectionStock2; // UOE���_�݌ɐ��Q
					//jnl.UOESectionStock3 = uOEOrderDtlRet.UOESectionStock3; // UOE���_�݌ɐ��R
					//jnl.UOESectionStock4 = uOEOrderDtlRet.UOESectionStock4; // UOE���_�݌ɐ��S
					//jnl.UOESectionStock5 = uOEOrderDtlRet.UOESectionStock5; // UOE���_�݌ɐ��T
					//jnl.UOESectionStock6 = uOEOrderDtlRet.UOESectionStock6; // UOE���_�݌ɐ��U
					//jnl.UOESectionStock7 = uOEOrderDtlRet.UOESectionStock7; // UOE���_�݌ɐ��V
					//jnl.UOESectionStock8 = uOEOrderDtlRet.UOESectionStock8; // UOE���_�݌ɐ��W
					//jnl.UOESectionStock9 = uOEOrderDtlRet.UOESectionStock9; // UOE���_�݌ɐ��X
					//jnl.UOESectionStock10 = uOEOrderDtlRet.UOESectionStock10; // UOE���_�݌ɐ��P�O
					//jnl.UOESectionStock11 = uOEOrderDtlRet.UOESectionStock11; // UOE���_�݌ɐ��P�P
					//jnl.UOESectionStock12 = uOEOrderDtlRet.UOESectionStock12; // UOE���_�݌ɐ��P�Q
					//jnl.UOESectionStock13 = uOEOrderDtlRet.UOESectionStock13; // UOE���_�݌ɐ��P�R
					//jnl.UOESectionStock14 = uOEOrderDtlRet.UOESectionStock14; // UOE���_�݌ɐ��P�S
					//jnl.UOESectionStock15 = uOEOrderDtlRet.UOESectionStock15; // UOE���_�݌ɐ��P�T
					//jnl.UOESectionStock16 = uOEOrderDtlRet.UOESectionStock16; // UOE���_�݌ɐ��P�U
					//jnl.UOESectionStock17 = uOEOrderDtlRet.UOESectionStock17; // UOE���_�݌ɐ��P�V
					////jnl.UOESectionStock18 = uOEOrderDtlRet.UOESectionStock18; // UOE���_�݌ɐ��P�W
					//jnl.UOESectionStock19 = uOEOrderDtlRet.UOESectionStock19; // UOE���_�݌ɐ��P�X
					//jnl.UOESectionStock20 = uOEOrderDtlRet.UOESectionStock20; // UOE���_�݌ɐ��Q�O
					//jnl.UOESectionStock21 = uOEOrderDtlRet.UOESectionStock21; // UOE���_�݌ɐ��Q�P
					//jnl.UOESectionStock22 = uOEOrderDtlRet.UOESectionStock22; // UOE���_�݌ɐ��Q�Q
					//jnl.UOESectionStock23 = uOEOrderDtlRet.UOESectionStock23; // UOE���_�݌ɐ��Q�R
					//jnl.UOESectionStock24 = uOEOrderDtlRet.UOESectionStock24; // UOE���_�݌ɐ��Q�S
					//jnl.UOESectionStock25 = uOEOrderDtlRet.UOESectionStock25; // UOE���_�݌ɐ��Q�T
					//jnl.UOESectionStock26 = uOEOrderDtlRet.UOESectionStock26; // UOE���_�݌ɐ��Q�U
					//jnl.UOESectionStock27 = uOEOrderDtlRet.UOESectionStock27; // UOE���_�݌ɐ��Q�V
					//jnl.UOESectionStock28 = uOEOrderDtlRet.UOESectionStock28; // UOE���_�݌ɐ��Q�W
					//jnl.UOESectionStock29 = uOEOrderDtlRet.UOESectionStock29; // UOE���_�݌ɐ��Q�X
					//jnl.UOESectionStock30 = uOEOrderDtlRet.UOESectionStock30; // UOE���_�݌ɐ��R�O
					//jnl.UOESectionStock31 = uOEOrderDtlRet.UOESectionStock31; // UOE���_�݌ɐ��R�P
					//jnl.UOESectionStock32 = uOEOrderDtlRet.UOESectionStock32; // UOE���_�݌ɐ��R�Q
					//jnl.UOESectionStock33 = uOEOrderDtlRet.UOESectionStock33; // UOE���_�݌ɐ��R�R
					//jnl.UOESectionStock34 = uOEOrderDtlRet.UOESectionStock34; // UOE���_�݌ɐ��R�S
					//jnl.UOESectionStock35 = uOEOrderDtlRet.UOESectionStock35; // UOE���_�݌ɐ��R�T
					jnl.HeadErrorMassage = uOEOrderDtlRet.HeadErrorMassage; // �w�b�h�G���[���b�Z�[�W
					jnl.LineErrorMassage = uOEOrderDtlRet.LineErrorMassage; // ���C���G���[���b�Z�[�W
					jnl.DataSendCode = uOEOrderDtlRet.DataSendCode; // �f�[�^���M�敪
					jnl.DataRecoverDiv = uOEOrderDtlRet.DataRecoverDiv; // �f�[�^�����敪

					list.Add(jnl);
				}
			}
			catch (Exception)
			{
				list.Clear();
			}
			return list;
		}
		# endregion

		# region �t�n�d�����f�[�^������M�i�m�k���������X�V�N���X�쐬
		/// <summary>
		/// �t�n�d�����f�[�^������M�i�m�k���������X�V�N���X�쐬
		/// </summary>
		/// <param name="para">�t�n�d�����f�[�^�N���X List<UOEOrderDtlWork></param>
		/// <returns>����M�i�m�k�����ρ��N���X List<OrderSndRcvJnl></returns>
		private List<OrderSndRcvJnl> GetToOrderFromOrderDtl(List<UOEOrderDtlWork> para)
		{
			List<OrderSndRcvJnl> list = new List<OrderSndRcvJnl>();

			try
			{
                foreach (UOEOrderDtlWork rst in para)
				{
					OrderSndRcvJnl jnl = new OrderSndRcvJnl();

                    jnl.CreateDateTime = rst.CreateDateTime;	// �쐬����
                    jnl.UpdateDateTime = rst.UpdateDateTime;	// �X�V����
                    jnl.EnterpriseCode = rst.EnterpriseCode;	// ��ƃR�[�h
                    jnl.FileHeaderGuid = rst.FileHeaderGuid;	// GUID
                    jnl.UpdEmployeeCode = rst.UpdEmployeeCode;	// �X�V�]�ƈ��R�[�h
                    jnl.UpdAssemblyId1 = rst.UpdAssemblyId1;	// �X�V�A�Z���u��ID1
                    jnl.UpdAssemblyId2 = rst.UpdAssemblyId2;	// �X�V�A�Z���u��ID2
                    jnl.LogicalDeleteCode = rst.LogicalDeleteCode;	// �_���폜�敪
                    jnl.SystemDivCd = rst.SystemDivCd;	// �V�X�e���敪
                    jnl.UOESalesOrderNo = rst.UOESalesOrderNo;	// UOE�����ԍ�
                    jnl.UOESalesOrderRowNo = rst.UOESalesOrderRowNo;	// UOE�����s�ԍ�
                    jnl.SendTerminalNo = rst.SendTerminalNo;	// ���M�[���ԍ�
                    jnl.UOESupplierCd = rst.UOESupplierCd;	// UOE������R�[�h
                    jnl.UOESupplierName = rst.UOESupplierName;	// UOE�����於��
                    jnl.CommAssemblyId = rst.CommAssemblyId;	// �ʐM�A�Z���u��ID
                    jnl.OnlineNo = rst.OnlineNo;	// �I�����C���ԍ�
                    jnl.OnlineRowNo = rst.OnlineRowNo;	// �I�����C���s�ԍ�
                    jnl.SalesDate = rst.SalesDate;	// ������t
                    jnl.InputDay = rst.InputDay;	// ���͓�
                    jnl.DataUpdateDateTime = rst.DataUpdateDateTime;	// �f�[�^�X�V����
                    jnl.UOEKind = rst.UOEKind;	// UOE���
                    jnl.SalesSlipNum = rst.SalesSlipNum;	// ����`�[�ԍ�
                    jnl.AcptAnOdrStatus = rst.AcptAnOdrStatus;	// �󒍃X�e�[�^�X
                    jnl.SalesSlipDtlNum = rst.SalesSlipDtlNum;	// ���㖾�גʔ�
                    jnl.SectionCode = rst.SectionCode;	// ���_�R�[�h
                    jnl.SubSectionCode = rst.SubSectionCode;	// ����R�[�h
                    jnl.CustomerCode = rst.CustomerCode;	// ���Ӑ�R�[�h
                    jnl.CustomerSnm = rst.CustomerSnm;	// ���Ӑ旪��
                    jnl.CashRegisterNo = rst.CashRegisterNo;	// ���W�ԍ�
                    jnl.CommonSeqNo = rst.CommonSeqNo;	// ���ʒʔ�
                    jnl.SupplierFormal = rst.SupplierFormal;	// �d���`��
                    jnl.SupplierSlipNo = rst.SupplierSlipNo;	// �d���`�[�ԍ�
                    jnl.StockSlipDtlNum = rst.StockSlipDtlNum;	// �d�����גʔ�
                    jnl.BoCode = rst.BoCode;	// BO�敪
                    jnl.UOEDeliGoodsDiv = rst.UOEDeliGoodsDiv;	// �[�i�敪
                    jnl.DeliveredGoodsDivNm = rst.DeliveredGoodsDivNm;	// �[�i�敪����
                    jnl.FollowDeliGoodsDiv = rst.FollowDeliGoodsDiv;	// �t�H���[�[�i�敪
                    jnl.FollowDeliGoodsDivNm = rst.FollowDeliGoodsDivNm;	// �t�H���[�[�i�敪����
                    jnl.UOEResvdSection = rst.UOEResvdSection;	// UOE�w�苒�_
                    jnl.UOEResvdSectionNm = rst.UOEResvdSectionNm;	// UOE�w�苒�_����
                    jnl.EmployeeCode = rst.EmployeeCode;	// �]�ƈ��R�[�h
                    jnl.EmployeeName = rst.EmployeeName;	// �]�ƈ�����
                    jnl.GoodsMakerCd = rst.GoodsMakerCd;	// ���i���[�J�[�R�[�h
                    jnl.MakerName = rst.MakerName;	// ���[�J�[����
                    jnl.GoodsNo = rst.GoodsNo;	// ���i�ԍ�
                    jnl.GoodsNoNoneHyphen = rst.GoodsNoNoneHyphen;	// �n�C�t�������i�ԍ�
                    jnl.GoodsName = rst.GoodsName;	// ���i����
                    jnl.WarehouseCode = rst.WarehouseCode;	// �q�ɃR�[�h
                    jnl.WarehouseName = rst.WarehouseName;	// �q�ɖ���
                    jnl.WarehouseShelfNo = rst.WarehouseShelfNo;	// �q�ɒI��
                    jnl.AcceptAnOrderCnt = rst.AcceptAnOrderCnt;	// �󒍐���
                    jnl.ListPrice = rst.ListPrice;	// �艿�i�����j
                    jnl.SalesUnitCost = rst.SalesUnitCost;	// �����P��
                    jnl.SupplierCd = rst.SupplierCd;	// �d����R�[�h
                    jnl.SupplierSnm = rst.SupplierSnm;	// �d���旪��
                    jnl.UoeRemark1 = rst.UoeRemark1;	// �t�n�d���}�[�N�P
                    jnl.UoeRemark2 = rst.UoeRemark2;	// �t�n�d���}�[�N�Q
                    jnl.ReceiveDate = rst.ReceiveDate;	// ��M���t
                    jnl.ReceiveTime = rst.ReceiveTime;	// ��M����
                    jnl.AnswerMakerCd = rst.AnswerMakerCd;	// �񓚃��[�J�[�R�[�h
                    jnl.AnswerPartsNo = rst.AnswerPartsNo;	// �񓚕i��
                    jnl.AnswerPartsName = rst.AnswerPartsName;	// �񓚕i��
                    jnl.SubstPartsNo = rst.SubstPartsNo;	// ��֕i��
                    jnl.UOESectOutGoodsCnt = rst.UOESectOutGoodsCnt;	// UOE���_�o�ɐ�
                    jnl.BOShipmentCnt1 = rst.BOShipmentCnt1;	// BO�o�ɐ�1
                    jnl.BOShipmentCnt2 = rst.BOShipmentCnt2;	// BO�o�ɐ�2
                    jnl.BOShipmentCnt3 = rst.BOShipmentCnt3;	// BO�o�ɐ�3
                    jnl.MakerFollowCnt = rst.MakerFollowCnt;	// ���[�J�[�t�H���[��
                    jnl.NonShipmentCnt = rst.NonShipmentCnt;	// ���o�ɐ�
                    jnl.UOESectStockCnt = rst.UOESectStockCnt;	// UOE���_�݌ɐ�
                    jnl.BOStockCount1 = rst.BOStockCount1;	// BO�݌ɐ�1
                    jnl.BOStockCount2 = rst.BOStockCount2;	// BO�݌ɐ�2
                    jnl.BOStockCount3 = rst.BOStockCount3;	// BO�݌ɐ�3
                    jnl.UOESectionSlipNo = rst.UOESectionSlipNo;	// UOE���_�`�[�ԍ�
                    jnl.BOSlipNo1 = rst.BOSlipNo1;	// BO�`�[�ԍ��P
                    jnl.BOSlipNo2 = rst.BOSlipNo2;	// BO�`�[�ԍ��Q
                    jnl.BOSlipNo3 = rst.BOSlipNo3;	// BO�`�[�ԍ��R
                    jnl.EOAlwcCount = rst.EOAlwcCount;	// EO������
                    jnl.BOManagementNo = rst.BOManagementNo;	// BO�Ǘ��ԍ�
                    jnl.AnswerListPrice = rst.AnswerListPrice;	// �񓚒艿
                    jnl.AnswerSalesUnitCost = rst.AnswerSalesUnitCost;	// �񓚌����P��
                    jnl.UOESubstMark = rst.UOESubstMark;	// UOE��փ}�[�N
                    jnl.UOEStockMark = rst.UOEStockMark;	// UOE�݌Ƀ}�[�N
                    jnl.PartsLayerCd = rst.PartsLayerCd;	// �w�ʃR�[�h
                    jnl.MazdaUOEShipSectCd1 = rst.MazdaUOEShipSectCd1;	// UOE�o�׋��_�R�[�h�P�i�}�c�_�j
                    jnl.MazdaUOEShipSectCd2 = rst.MazdaUOEShipSectCd2;	// UOE�o�׋��_�R�[�h�Q�i�}�c�_�j
                    jnl.MazdaUOEShipSectCd3 = rst.MazdaUOEShipSectCd3;	// UOE�o�׋��_�R�[�h�R�i�}�c�_�j
                    jnl.MazdaUOESectCd1 = rst.MazdaUOESectCd1;	// UOE���_�R�[�h�P�i�}�c�_�j
                    jnl.MazdaUOESectCd2 = rst.MazdaUOESectCd2;	// UOE���_�R�[�h�Q�i�}�c�_�j
                    jnl.MazdaUOESectCd3 = rst.MazdaUOESectCd3;	// UOE���_�R�[�h�R�i�}�c�_�j
                    jnl.MazdaUOESectCd4 = rst.MazdaUOESectCd4;	// UOE���_�R�[�h�S�i�}�c�_�j
                    jnl.MazdaUOESectCd5 = rst.MazdaUOESectCd5;	// UOE���_�R�[�h�T�i�}�c�_�j
                    jnl.MazdaUOESectCd6 = rst.MazdaUOESectCd6;	// UOE���_�R�[�h�U�i�}�c�_�j
                    jnl.MazdaUOESectCd7 = rst.MazdaUOESectCd7;	// UOE���_�R�[�h�V�i�}�c�_�j
                    jnl.MazdaUOEStockCnt1 = rst.MazdaUOEStockCnt1;	// UOE�݌ɐ��P�i�}�c�_�j
                    jnl.MazdaUOEStockCnt2 = rst.MazdaUOEStockCnt2;	// UOE�݌ɐ��Q�i�}�c�_�j
                    jnl.MazdaUOEStockCnt3 = rst.MazdaUOEStockCnt3;	// UOE�݌ɐ��R�i�}�c�_�j
                    jnl.MazdaUOEStockCnt4 = rst.MazdaUOEStockCnt4;	// UOE�݌ɐ��S�i�}�c�_�j
                    jnl.MazdaUOEStockCnt5 = rst.MazdaUOEStockCnt5;	// UOE�݌ɐ��T�i�}�c�_�j
                    jnl.MazdaUOEStockCnt6 = rst.MazdaUOEStockCnt6;	// UOE�݌ɐ��U�i�}�c�_�j
                    jnl.MazdaUOEStockCnt7 = rst.MazdaUOEStockCnt7;	// UOE�݌ɐ��V�i�}�c�_�j
                    jnl.UOEDistributionCd = rst.UOEDistributionCd;	// UOE���R�[�h
                    jnl.UOEOtherCd = rst.UOEOtherCd;	// UOE���R�[�h
                    jnl.UOEHMCd = rst.UOEHMCd;	// UOE�g�l�R�[�h
                    jnl.BOCount = rst.BOCount;	// �a�n��
                    jnl.UOEMarkCode = rst.UOEMarkCode;	// UOE�}�[�N�R�[�h
                    jnl.SourceShipment = rst.SourceShipment;	// �o�׌�
                    jnl.ItemCode = rst.ItemCode;	// �A�C�e���R�[�h
                    jnl.UOECheckCode = rst.UOECheckCode;	// UOE�`�F�b�N�R�[�h
                    jnl.HeadErrorMassage = rst.HeadErrorMassage;	// �w�b�h�G���[���b�Z�[�W
                    jnl.LineErrorMassage = rst.LineErrorMassage;	// ���C���G���[���b�Z�[�W
                    jnl.DataSendCode = rst.DataSendCode;	// �f�[�^���M�敪
                    jnl.DataRecoverDiv = rst.DataRecoverDiv;	// �f�[�^�����敪
                    jnl.EnterUpdDivSec = rst.EnterUpdDivSec;	// ���ɍX�V�敪�i���_�j
                    jnl.EnterUpdDivBO1 = rst.EnterUpdDivBO1;	// ���ɍX�V�敪�iBO1�j
                    jnl.EnterUpdDivBO2 = rst.EnterUpdDivBO2;	// ���ɍX�V�敪�iBO2�j
                    jnl.EnterUpdDivBO3 = rst.EnterUpdDivBO3;	// ���ɍX�V�敪�iBO3�j
                    jnl.EnterUpdDivMaker = rst.EnterUpdDivMaker;	// ���ɍX�V�敪�iҰ���j
                    jnl.EnterUpdDivEO = rst.EnterUpdDivEO;	// ���ɍX�V�敪�iEO�j
                    jnl.DtlRelationGuid = rst.DtlRelationGuid;	// ���׊֘A�t��GUID

					list.Add(jnl);
				}
			}
			catch (Exception)
			{
				list.Clear();
			}
			return list;
		}
		# endregion
		# endregion
		# endregion
	}
}

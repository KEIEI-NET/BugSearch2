using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
//using System.Windows.Forms;

using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Collections;
using Broadleaf.Windows.Forms;
using Broadleaf.Library.Globarization;
using Broadleaf.Application.Controller.Facade;
// ------ ADD 2020/06/22 ���O PMKOBETSU-4017�̑Ή� --------- >>>>
using System.IO;
using Broadleaf.Library.Windows.Forms;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Microsoft.VisualBasic.FileIO;
// ------ ADD 2020/06/22 ���O PMKOBETSU-4017�̑Ή� --------- <<<<

namespace Broadleaf.Application.Controller
{
	/// <summary>
	/// �d�����̓A�N�Z�X�N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : �d�����͂̐���S�ʂ��s���܂��B</br>
	/// <br>Programmer : 21024�@���X�� ��</br>
	/// <br>Date       : 2008.05.21</br>
	/// <br></br>
	/// <br>UpDate</br>
    /// <br>2008.05.21 men �V�K�쐬</br>
    /// <br>2009.03.27 20056 ���n ��� MANTIS[0012812] ���i�����X�V�敪�̍X�V����ύX</br>
    /// <br>2009.03.31 20056 ���n ��� MANTIS[0007759] BL���ޓ��͎��̕i���ĕ\������ǉ�</br>
    /// <br>2009.04.03 20056 ���n ��� MANTIS[0013065] �i�Ԍ������A�I�����ꂽ�q�ɺ��ނ���ʔ��f����</br>
    /// <br>2009.04.13 20056 ���n ��� MANTIS[0013170] �c�������̖��דW�J�̕s���Ή�</br>
    /// <br>2009.05.12 20056 ���n ��� MANTIS[0013236] �d���`�[�Ɖ��̃R�[�����l������</br>
    /// <br>2009.06.17 21024 ���X�� �� MANTIS[0013506] ���v���͎��A���z����͂��Ă��Ȃ��ꍇ�̃��b�Z�[�W���C��</br>
    /// <br>2010.05.04 gaoyh 1007E �Z�L�����e�B�Ǘ��u���ʃ}�C�i�X�v�u���i�l���v�̒ǉ��i�U�����ǁj</br>
    /// <br>2010/09/15 20056 ���n ��� ���i�����o�^�����ŏ��i�}�X�^���o�^�i�̉��i���X�V���悤�Ƃ���ƃG���[�ɂȂ錏�̑Ή�</br>
    /// <br>2010/10/27 ����� ����ŕύX���ɕs���ɃZ�b�g������Q�̏C��</br>
    /// <br>2010/11/12 22018 ��� ���b ���i�����o�^�̉��i�J�n����O�񌎎��X�V���{�P�ɕύX</br>
    /// <br>2010/12/03 yangmj ��Q���ǑΉ�</br>
    /// <br>2011/07/18 ������ MANTIS[17500] �A��1028�ARedmine22936</br>
    /// <br>              �d����=1�ƕ\������d���O�̌��݌���\���A�s�ړ���Ɍ��݌����ĕ\�������</br>
    /// <br>Update Note: 2011/07/25 杍^ �A��No.16 �|���ݒ�Ɋւ��āA00�S�Ћ��� �� ���_�̊|���̗D�揇�ʂ̓������iWAN�^�p�j�̑Ή�</br>
    /// <br>Update Note : 2011/12/27 ����</br>
    /// <br>�Ǘ��ԍ�    : 10707327-00 2012/01/25�z�M��</br>
    /// <br>              redmine#27374 �d���`�[����/���ς̃`�F�b�N�̑Ή�</br>
    /// <br>Update Note : 2012/03/13 ���N�n��</br>
    /// <br>�Ǘ��ԍ�    : 10707327-00 2012/03/28�z�M��</br>
    /// <br>              Redmine#27374 �d���`�[���͂ŃK�C�h����ďo�����ꍇ�폜�ŃG���[�ɂȂ錏�̑Ή�</br>
    /// <br>Update Note : 2012/06/15 tianjw</br>
    /// <br>�Ǘ��ԍ�    : 10801804-00 2012/07/25�z�M��</br>
    /// <br>              Redmine#30517 �i�������͍s�̕s��̑Ή�</br>
    //----------------------------------------------------------------------------//
    // �Ǘ��ԍ�              �쐬�S�� : FSI��c �W�v
    // �C �� ��  2013/01/07  �C�����e : �d���ԕi�\��@�\�Ή�
    //----------------------------------------------------------------------------//
    /// <br>Update Note : 2013/01/08 �A����</br>
    /// <br>�Ǘ��ԍ�    : 10801804-00 2013/03/13�z�M��</br>
    /// <br>            : redmine#31984 �d���`�[���͂̑���֗��̑Ή�</br>
    /// <br>Update Note: 2014/01/07 杍^</br>
    /// <br>�Ǘ��ԍ�   : 10904597-00</br>
    /// <br>           : Redmine#41771 �d���`�[���͏����8%���őΉ�</br>
    /// <br>Update Note : 2014/09/01 �q����</br>
    /// <br>�Ǘ��ԍ�    : 11070149-00</br>
    /// <br>            : redmine #43374 �d���`�[����(�ۑ��ネ�S�\������)</br>
    /// <br>Update Note : 2015/03/25 �����M</br>
    /// <br>�Ǘ��ԍ�    : 11175104-00</br>
    /// <br>            : Redmine#45073 �{�c�����ԏ��� �d���`�[���͂Ŏd���`�[�ԍ����󔒂̃f�[�^���쐬�����̕s��̑Ή�</br>
    /// <br>UpdateNote  : 2017/08/11 杍^  </br>
    /// <br>�Ǘ��ԍ�    : 11370074-00</br>
    /// <br>              �n���f�B�^�[�~�i���݌Ɏd���o�^�̑Ή�</br> 
    /// <br>Update Note: 2020/06/22 ���O</br>
    /// <br>�Ǘ��ԍ�   : 11670231-00</br>
    /// <br>           : PMKOBETSU-4017 11600575_���M�ԗ��T�[�r�X(�d���f�[�^�e�L�X�g����)</br>
    /// <br>Update Note : 2021/12/19 ���O</br>
    /// <br>�Ǘ��ԍ�    : 11770181-00</br>
    /// <br>            : PMKOBETSU-4200 �ݒ�t�@�C���̕ۑ��ꏊ�Ǎ����Ԃ����ǑΉ�</br>
    /// </remarks>
	public class StockSlipInputAcs
	{ 
		// ===================================================================================== //
		// �R���X�g���N�^
		// ===================================================================================== //
		# region ��Constructor
		/// <summary>
		/// �f�t�H���g�R���X�g���N�^�iSingleton�f�U�C���p�^�[�����̗p���Ă���ׁAprivate�Ƃ���j
		/// </summary>
		private StockSlipInputAcs()
		{
			// �ϐ�������
			this._dataSet = new StockInputDataSet();
			this._stockDetailDataTable = this._dataSet.StockDetail;
			this._addUpSrcDetailDataTable = this._dataSet.AddUpSrcDetail;
			this._salesTempDataTable = this._dataSet.SalesTemp;
			this._addUpSrcSalesSlipDataTable = this._dataSet.AddUpSrcSalesSlip;
			this._addUpSrcSalesDetailDataTable = this._dataSet.AddUpSrcSalesDetail;
			this._stockInfoDataTable = this._dataSet.StockInfo;
			this._stockSlip = new StockSlip();
			this._stockSlipDBData = new StockSlip();
			this._stockDetailDBDataList = new List<StockDetail>();
			this._unitPriceCalculation = new UnitPriceCalculation();
			//this._unitPriceCalculation.IsLocalDBRead = StockSlipInputInitDataAcs.ctIsLocalDBRead;
			this._stockPriceCalculate = new StockPriceCalculate();
			this._stockSlipInputInitDataAcs = StockSlipInputInitDataAcs.GetInstance();
			this._stockSlipInputInitDataAcs.CacheStockProcMoneyList += new StockSlipInputInitDataAcs.CacheStockProcMoneyListEventHandler(this._stockPriceCalculate.CacheStockProcMoneyList);
			this._stockSlipInputInitDataAcs.CacheStockProcMoneyList += new StockSlipInputInitDataAcs.CacheStockProcMoneyListEventHandler(this._unitPriceCalculation.CacheStockProcMoneyList);

			this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            this._paymentSlp = new PaymentSlp();
            this._paymentDtlList = new List<PaymentDtl>();
			//this._salesTempInputAcs = SalesTempInputAcs.GetInstance();
			//this._salesTempInputAcs.CacheSalesTemp += new SalesTempInputAcs.CacheSalesTempEventHandler(this.CacheSalesTemp);
			this._stockInputConstructionAcs = StockSlipInputConstructionAcs.GetInstance();
            this._stockSlipInputConstructionAcsLog = StockSlipInputConstructionAcsLog.GetInstance(); // ADD �q���� 2014/09/01�@For redmine #43374 �d���`�[����(�ۑ��ネ�S�\������)
            this._goodsDictionary = new Dictionary<string, GoodsUnitData>();

			this._stockDetailDataView = new DataView(this._stockDetailDataTable);
        }

        // ---------- ADD 2010/05/04 ----------------->>>>>
        // ���쌠���̐���I�u�W�F�N�g�ۗ̕L
        /// <summary>
        /// ���쌠���̐���I�u�W�F�N�g���擾���܂��B
        /// </summary>
        /// <value>���쌠���̐���I�u�W�F�N�g</value>
        private IOperationAuthority MyOpeCtrl
        {
            get
            {
                if (_operationAuthority == null)
                {
                    _operationAuthority = OpeAuthCtrlFacade.CreateEntryOperationAuthority("MAKON01100U", this);
                }
                return _operationAuthority;
            }
        }
        // ---------- ADD 2010/05/04 -----------------<<<<<

		/// <summary>
		/// �d�����̓A�N�Z�X�N���X �C���X�^���X�擾����
		/// </summary>
		/// <returns>�d�����̓A�N�Z�X�N���X �C���X�^���X</returns>
        public static StockSlipInputAcs GetInstance()
		{
			if (_stockSlipInputAcs == null)
			{
                _stockSlipInputAcs = new StockSlipInputAcs();
			}

			return _stockSlipInputAcs;
        }
		# endregion

        // ------ ADD 2017/08/11 杍^ �n���f�B�^�[�~�i���񎟊J�� --------- >>>>
        #region ���萔�i�n���f�B�^�[�~�i���p�j
        
        /// <summary>�n���f�B�^�[�~�i���R���X�g���N�^�̃��[�h</summary>
        private const string ConstructorsModeHandy = "Handy";

        /// <summary>�n���f�B�^�[�~�i���݌Ɏd���i���ɍX�V�j���[�N�v���O����ID</summary>
        private const string AssemblyIdPmhnd01114d = "PMHND01114D";
        /// <summary>�n���f�B�^�[�~�i���݌Ɏd���i���ɍX�V�j���[�N�v���O����ID�̃N���X��</summary>
        private const string AssemblyIdPmhnd01114dClassName = "Broadleaf.Application.Remoting.ParamData.HandyNonUOEInspectParamWork";

        /// <summary>�d���`���u0:�d���v</summary>
        private const int SupplierFormalSupplier = 0;
        /// <summary>���|�敪�u1:���|�v</summary>
        private const int AccPayDivCdNone = 1;
        /// <summary>���i�敪�u0:���i�v</summary>
        private const int StockGoodsCdGoods = 0;

        /// <summary>�d�����גʔ�</summary>
        private const string StockSlipDtlNum = "StockSlipDtlNum";
        /// <summary>�X�V�敪</summary>
        private const string PartySaleSlipNum = "PartySaleSlipNum";
        /// <summary>���i��</summary>
        private const string InspectCnt = "InspectCnt";
        #endregion
        // ------ ADD 2017/08/11 杍^ �n���f�B�^�[�~�i���񎟊J�� --------- <<<<

        // ------ ADD 2020/06/22 ���O PMKOBETSU-4017�̑Ή� --------- >>>>
        // �`�F�b�N�G���[���
        private const string CT_ERROR_MEASSSAGE00 = "���ڐ��s��";
        private const string CT_ERROR_MEASSSAGE01 = "�󒍔ԍ��s��";
        private const string CT_ERROR_MEASSSAGE02 = "���i�R�[�h�s��";
        private const string CT_ERROR_MEASSSAGE03 = "���i���o�^";
        private const string CT_ERROR_MEASSSAGE04 = "�݌ɖ��o�^";
        private const string CT_ERROR_MEASSSAGE05 = "�o�א��ʕs��";
        private const string CT_ERROR_MEASSSAGE06 = "�󒍒P���s��";
        private const string CT_ERROR_MEASSSAGE07 = "�`�[�ԍ��s��";
        private const string CT_ERROR_MEASSSAGE08 = "��(�V�X�e��)���t�s��";
        private const string CT_ERROR_MEASSSAGE09 = "�ėp�w�l�ķ�ق�ݒ肵�Ă��������B";
        private const string CT_ERROR_MEASSSAGE10 = "�ėp�w�l�ķ�ق̎d�����ݒ肵�Ă��������B";
        private const string CT_ERROR_MEASSSAGE11 = "�捞�Ɏ��s���܂����B";
        private const string CT_ERROR_MEASSSAGE12 = "�捞���J�n���܂����H";
        private const string CT_ERROR_MEASSSAGE13 = "�ėp�w�l�ķ�ق̎d���悪�s���ł��B";
        private const string CT_ERROR_MEASSSAGE14 = "�捞�f�[�^��99���ȉ��ɂ��Ă��������B";
        private const string CT_ERROR_MEASSSAGE15 = "�捞�������͍s���ݒ�l�𒴂��Ă��܂��B";
        private const string CT_ERROR_MEASSSAGE16 = "�Y������f�[�^������܂���B";
        private const string CT_ERROR_MEASSSAGE17 = "�i�ԕs��";
        private const string CT_ERROR_MEASSSAGE18 = "�d����s��";

        /// <summary>�捞�ő�s��</summary>
        private const int InPutMaxLength = 100; // 99�͎d���`�[���ׂɓo�^�ł��閾�א��̏���l
        /// <summary>�`�[�敪�F�d��</summary>
        private const string StockDiv = "10";
        /// <summary>�`�[�敪�F�ԕi</summary>
        private const string ReturnDiv = "20";

        // �G���[�f�[�^�o�͗p�e�[�u��
        DataTable ErrDataTable;

        /// <summary>XML�t�@�C��</summary>
        private const string XmlFileName = "StockDefaultDataInputText.xml";

        #region �� �e�[�u���̃J����
        /// <summary> �󒍔ԍ� </summary>
        private const string CT_Col_AcceptAnOrderNo = "AcceptAnOrderNo";
        /// <summary> ���i�R�[�h </summary>
        private const string CT_Col_GoodsCode = "GoodsCode";
        /// <summary> �o�א��ʇ@ </summary>
        private const string CT_Col_ShipmentCnt1 = "ShipmentCnt1";
        /// <summary> �󒍒P�� </summary>
        private const string CT_Col_AcceptAnOrderUnCst = "AcceptAnOrderUnCst";
        /// <summary> ��(�V�X�e��)���t </summary>
        private const string CT_Col_SysDate = "SysDate";
        /// <summary> �G���[���e </summary>
        private const string CT_Col_ErrContent = "ErrContent";
        /// <summary> �d���� </summary>
        private const string CT_Col_SupplierCd = "SupplierCd";
        /// <summary> �d���`�[�ԍ� </summary>
        private const string CT_Col_SupplierSlipNo = "SupplierSlipNo";
        /// <summary> �i�� </summary>
        private const string CT_Col_GoodsNo = "GoodsNo";

        #endregion
        // ------ ADD 2020/06/22 ���O PMKOBETSU-4017�̑Ή� --------- <<<<

        // ===================================================================================== //
		// �v���C�x�[�g�ϐ�2
		// ===================================================================================== //
		# region ��Private Members
		private static StockSlipInputAcs _stockSlipInputAcs;
		private StockSlipInputInitDataAcs _stockSlipInputInitDataAcs;
		//private SalesTempInputAcs _salesTempInputAcs;
		private StockPriceCalculate _stockPriceCalculate;
		private StockInputDataSet _dataSet;
		private StockSlip _stockSlip;
		private StockSlip _stockSlipDBData;
		private int _currentSupplierSlipNo = 0;
		private StockInputDataSet.StockDetailDataTable _stockDetailDataTable;
		private StockInputDataSet.AddUpSrcDetailDataTable _addUpSrcDetailDataTable;
		private StockInputDataSet.SalesTempDataTable _salesTempDataTable;
		private StockInputDataSet.AddUpSrcSalesSlipDataTable _addUpSrcSalesSlipDataTable;
		private StockInputDataSet.AddUpSrcSalesDetailDataTable _addUpSrcSalesDetailDataTable;
		private StockInputDataSet.StockInfoDataTable _stockInfoDataTable;
        private List<StockDetail> _stockDetailDBDataList;
        private IIOWriteControlDB _iIOWriteControlDB;
		private IStockSlipDB _iStockSlipDB;
		private string _enterpriseCode;
		private bool _isDataCanged = false;
		private CustomerInfoAcs _customerInfoAcs;
		private SupplierAcs _supplierAcs;
		private SearchStockAcs _searchStockAcs;
		private UnitPriceCalculation _unitPriceCalculation;                         // �P���Z�o���i
		private PaymentSlp _paymentSlp;                                             // �x���f�[�^
        private List<PaymentDtl> _paymentDtlList;                                   // �x�����׃f�[�^
        private TotalDayCalculator _totalDayCalculator;                             // �����`�F�b�N���i
        // --- ADD m.suzuki 2010/11/12 ---------->>>>>
        private DateGetAcs _dateGetAcs; // ���t�擾���i
        // --- ADD m.suzuki 2010/11/12 ----------<<<<<
        private StockSlipInputConstructionAcs _stockInputConstructionAcs;
        private StockSlipInputConstructionAcsLog _stockSlipInputConstructionAcsLog;�@// ADD �q���� 2014/09/01�@For redmine #43374 �d���`�[����(�ۑ��ネ�S�\������)
		private DataView _stockDetailDataView;
        private Dictionary<string, GoodsUnitData> _goodsDictionary;

		private readonly string cRelation_Detail_AddUpSrcDetail = "Detail_AddUpSrcDetail";
		private readonly string cRelation_Detail_SalesTemp = "StockDetail_SalesTemp";
        private IOperationAuthority _operationAuthority;    // ���쌠���̐���I�u�W�F�N�g�@// ADD 2010/05/04
        // ---ADD 2011/07/18----------->>>>>
        private bool _hasStockInfo = false;
        private int _stockRowNo = 0;
        private bool _isShipmentChange = false;
        // ---ADD 2011/07/18-----------<<<<<
        //add 2011/12/27 ���� Redmine #27374----->>>>>
        private List<StockDetail> _stockDetailList = null;
        private List<StockDetail> _addUpSrcDetailList = null;
        private List<StockWork> _stockWorkList = null;
        //add 2011/12/27 ���� Redmine #27374-----<<<<<
        //ADD 2012/03/13 ���N�n�� Redmine #27374----->>>>>
        private StockSlip _deleteStockSlip = null;
        private List<StockDetail> _deleteStockDetailList = null;
        private List<StockDetail> _deleteAddUpSrcDetailList = null;
        private PaymentSlp _deletePaymentSlp = null;
        private List<PaymentDtl> _deletePaymentDtlList = null;
        private List<StockWork> _deleteStockWorkList = null;
        private bool _isCannotModify = false;
        //ADD 2012/03/13 ���N�n�� Redmine #27374-----<<<<<
        // ------ ADD 2020/06/22 ���O PMKOBETSU-4017�̑Ή� --------- >>>>
        // �G���[����
        private int ErrStockCount = 0;
        // �d����ʂɓW�J�ł���f�[�^
        private List<InitDataItem> CanDoStockDataWorkList = new List<InitDataItem>();
        // �G���[���O�t�@�C��
        private string ErrFileName = string.Empty;
        // �捞�t�@�C��
        private string FileName = string.Empty;
        // ���_�ݒ�̑q�Ƀ��X�g
        private Dictionary<string, string> WarehouseDictionary = new Dictionary<string, string>();
        // 0:���M�ԗ��l�A1:���M�ԗ��l�ȊO
        private int UserDiv = 0;
        // �P�s�ڃ��R�[�h
        private InitDataItem FirstInitData = new InitDataItem();
        // ------ ADD 2020/06/22 ���O PMKOBETSU-4017�̑Ή� --------- <<<<

		# endregion

		// ===================================================================================== //
		// �O���ɒ񋟂���萔�Q
		// ===================================================================================== //
		# region ��Public Readonly Members
		/// <summary>�s�X�e�[�^�X�i�ʏ�s�j</summary>
		public static readonly int ctROWSTATUS_NORMAL = 0;

		/// <summary>�s�X�e�[�^�X�i�R�s�[�s�j</summary>
		public static readonly int ctROWSTATUS_COPY = 1;

		/// <summary>�s�X�e�[�^�X�i�J�b�g�s�j</summary>
		public static readonly int ctROWSTATUS_CUT = 2;

		/// <summary>�s�ҏW�X�e�[�^�X�i�S���ڕҏW�\�j</summary>
		public static readonly int ctEDITSTATUS_AllOK = 0;

		/// <summary>�s�ҏW�X�e�[�^�X�i�d�����ʂ̂ݕҏW�\�j</summary>
		public static readonly int ctEDITSTATUS_StockCountOnly = 1;

		/// <summary>�s�ҏW�X�e�[�^�X�i�S���ږ����j</summary>
		public static readonly int ctEDITSTATUS_AllDisable = 2;

		/// <summary>�s�ҏW�X�e�[�^�X�i�S���ڎQ�Ƃ̂݁j</summary>
		public static readonly int ctEDITSTATUS_AllReadOnly = 3;

		/// <summary>�s�ҏW�X�e�[�^�X�i���׌v��V�K�^�d�����ʁA�P���A���l�̂ݕҏW�\�j</summary>
		public static readonly int ctEDITSTATUS_ArrivalAddUpNew = 4;

		/// <summary>�s�ҏW�X�e�[�^�X�i���׌v��ҏW�^�P���̂ݕҏW�\�j</summary>
		public static readonly int ctEDITSTATUS_ArrivalAddUpEdit = 5;

        /// <summary>�s�ҏW�X�e�[�^�X�i�s�l�����^�d�����z�̂ݕҏW�\�j</summary>
        public static readonly int ctEDITSTATUS_RowDiscount = 6;

		/// <summary>�s�ҏW�X�e�[�^�X�i���i�l�����j</summary>
		public static readonly int ctEDITSTATUS_GoodsDiscount = 7;

		/// <summary>���̓��[�h�i�ʏ�j</summary>
		public static readonly int ctINPUTMODE_StockSlip_Normal = 0;

		/// <summary>���̓��[�h�i�ԕi�j</summary>
		public static readonly int ctINPUTMODE_StockSlip_Return = 1;

		/// <summary>���̓��[�h�i�ԓ`�j</summary>
		public static readonly int ctINPUTMODE_StockSlip_Red = 2;

		/// <summary>���̓��[�h�i���׌v��j</summary>
		public static readonly int ctINPUTMODE_StockSlip_ArrivalAddUp = 3;

		/// <summary>���̓��[�h�i���ߍς݁j</summary>
		public static readonly int ctINPUTMODE_StockSlip_AddUp = 4;

		/// <summary>���̓��[�h�i�ǂݎ���p�j</summary>
		public static readonly int ctINPUTMODE_StockSlip_ReadOnly = 5;

		/// <summary>�ő�d������</summary>
		public static readonly double ctMAXVALUE_StockCount = 9999999.99;
		/// <summary>�ő�d������(����)</summary>
		public static readonly double ctMAXVALUE_StockCountDetail = 9999999.99;
		/// <summary>�ő���z</summary>
		public static readonly long ctMAXVALUE_StockPrice = 9999999999;
		/// <summary>�ő���z(����)</summary>
		public static readonly long ctMAXVALUE_StockPriceDetail = 999999999;
		/// <summary>�ő�P��</summary>
		public static readonly double ctMAXVALUE_StockUnitPrice = 99999999.99;

        # endregion

		// ===================================================================================== //
		// �C�x���g
		// ===================================================================================== //
		# region ��Events
		/// <summary>�f�[�^�ύX�㔭���C�x���g</summary>
		public event EventHandler DataChanged;
		# endregion

		// ===================================================================================== //
		// �񋓑�
		// ===================================================================================== //
		# region ��Enums
		/// <summary>
		/// ���i���̓��[�h�񋓌^
		/// </summary>
		public enum PriceInputType : int
		{
			/// <summary>�Ŕ������i����</summary>
			PriceTaxExc = 0,
            /// <summary>�ō��݉��i����</summary>
			PriceTaxInc = 1,
            /// <summary>�\�����i����</summary>
			PriceDisplay = 2
		}

		/// <summary>
		/// �t�H�[�J�X�ړ����@(�ʏ�R���g���[��)
		/// </summary>
		public enum MoveMethod : int
		{
			/// <summary>�ォ�牺��</summary>
			NextMove = 0,
			/// <summary>��������</summary>
			PrevMove = 1,
		}

		/// <summary>
		/// �������ʋ敪�i��������R�s�[�A�v�シ��ۂɃ����𕡎ʂ��邩�ݒ�j
		/// </summary>
		public enum MemoMoveDiv : int
		{
			/// <summary>�S��</summary>
			All = 0,
			/// <summary>�`�[�����̂�</summary>
			SlipMemoOnly = 1,
			/// <summary>���Ȃ�</summary>
			None = 2
		}

		/// <summary>
		/// ���׃f�[�^�W�J���@�i�e�헚������̖��דW�J���Ɏg�p�j
		/// </summary>
		public enum WayToDetailExpand : int
		{
			/// <summary>�ʏ�i���ׂ̃R�s�[�j</summary>
			Normal = 0,
            /// <summary>�v��i�������͂͑ΏۊO�j</summary>
            AddUp = 1,
            // 2009.04.13 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            /// <summary>�v��i�c�����j</summary>
            AddUpRemainder = 2,
            // 2009.04.13 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
        }

        /// <summary>
        /// �`�F�b�N�߂�l
        /// </summary>
        public enum CheckResult : int
        {
            /// <summary>OK</summary>
            Ok = 0,
            /// <summary>�G���[</summary>
            Error = 1,
            /// <summary>�x��</summary>
            Warning = 2,
            /// <summary>�m�F</summary>
            Confirm = 3
        }

        // ------ ADD 2010/05/04 ------------------>>>>>
        /// <summary>
        /// �I�y���[�V�����R�[�h
        /// </summary>
        public enum OperationCode : int
        {
            /// <summary>�`�[�l��</summary>
            Discount = 15,
            /// <summary>���ʃ}�C�i�X</summary>
            QuantityMinus = 16
        }
        // ------ ADD 2010/05/04 ------------------<<<<<
		#endregion

		// ===================================================================================== //
		// �v���p�e�B
		// ===================================================================================== //
		# region ��Properties
		/// <summary>
		/// �d�����׃f�[�^�e�[�u���I�u�W�F�N�g���擾���܂��B
		/// </summary>
		public StockInputDataSet.StockDetailDataTable StockDetailDataTable
		{
			get { return _stockDetailDataTable; }
		}

#if DEBUG
		/// <summary>
		/// �����N�p�d�����׃f�[�^�e�[�u���I�u�W�F�N�g���擾���܂��B
		/// </summary>
		public StockInputDataSet.AddUpSrcDetailDataTable LnkStockDetailDataTable
		{
			get { return _addUpSrcDetailDataTable; }
		}
#endif

		/// <summary>�f�[�^�ύX�t���O�̎擾�A�ݒ���s���܂��B�itrue:�ύX���� false:�ύX�Ȃ��j</summary>
		public bool IsDataChanged
		{
			get
			{
				return this._isDataCanged;
			}
			set
			{
				this._isDataCanged = value;

				if (this.DataChanged != null)
				{
					this.DataChanged(this, new EventArgs());
				}
			}
		}

        /// <summary>�d���f�[�^(�ǎ��p)</summary>
		public StockSlip StockSlip
		{
			get
			{
				return this._stockSlip;
			}
		}
		/// <summary>�x���f�[�^(�ǎ��p)</summary>
        public PaymentSlp PaymentSlp
		{
			get
			{
                return this._paymentSlp;
			}
		}

        /// <summary>�x�����׃f�[�^���X�g(�ǎ��p)</summary>
        public List<PaymentDtl> PaymentDtlList
        {
            get
            {
                return this._paymentDtlList;
            }
        }
        // ------ ADD 2020/06/22 ���O PMKOBETSU-4017�̑Ή� --------- >>>>
        /// <summary>�t�@�C���d���f�[�^(�ǎ��p)</summary>
        public List<InitDataItem> StockDataWorkList
        {
            get
            {
                return CanDoStockDataWorkList;
            }

        }

        /// <summary>�G���[����(�ǎ��p)</summary>
        public int ErrorStockCount
        {
            get
            {
                return ErrStockCount;
            }

        }

        /// <summary>�捞�t�@�C��(�ǎ��p)</summary>
        public string StockFileName
        {
            get
            {
                return FileName;
            }
        }

        /// <summary>�G���[���O�t�@�C��(�ǎ��p)</summary>
        public string ErrStockFileName
        {
            get
            {
                return ErrFileName;
            }
        }

        /// <summary>0:���M�ԗ��l�A1:���M�ԗ��l�ȊO</summary>
        public int UserDivForForm
        {
            get
            {
                return UserDiv;
            }

        }

        /// <summary>�P�s�ڃ��R�[�h</summary>
        public InitDataItem FirstInitDataForForm
        {
            get
            {
                return FirstInitData;
            }

        }
        // ------ ADD 2020/06/22 ���O PMKOBETSU-4017�̑Ή� --------- <<<<

        // ---ADD 2011/07/18-------------->>>>>
        /// <summary>
        /// �݌ɏ�񑶍݃t���O
        /// </summary>
        public bool HasStockInfo
        {
            get { return _hasStockInfo; }
            set { _hasStockInfo = value; }
        }
        /// <summary>
        /// �s�ԍ��t���O
        /// </summary>
        public int StockRowNo
        {
            get { return _stockRowNo; }
            set { _stockRowNo = value; }
        }
        /// <summary>
        /// ���ʕύX�t���O
        /// </summary>
        public bool IsShipmentChange
        {
            get { return _isShipmentChange; }
            set { _isShipmentChange = value; }
        }
        //add 2011/12/27 ���� Redmine #27374----->>>>>
        /// <summary>
        /// �d�����׃f�[�^�I�u�W�F�N�g���X�g(�ǎ��p)
        /// </summary>
	    public List<StockDetail> StockDetailList
	    {
            get { return _stockDetailList; }
	    }
        /// <summary>
        /// �v�㌳�d�����׃f�[�^�I�u�W�F�N�g���X�g(�ǎ��p)
        /// </summary>
	    public List<StockDetail> AddUpSrcDetailList
	    {
            get { return _addUpSrcDetailList; }
	    }
        /// <summary>
        /// �݌Ƀ��[�N�I�u�W�F�N�g���X�g(�ǎ��p)
        /// </summary>
	    public List<StockWork> StockWorkList
	    {
            get { return _stockWorkList; }
	    }
        //add 2011/12/27 ���� Redmine #27374-----<<<<<
	    // ---ADD 2011/07/18--------------<<<<<

        //ADD 2012/03/13 ���N�n�� Redmine #27374----->>>>>

        /// <summary>
        /// �폜�d���f�[�^�I�u�W�F�N�g
        /// </summary>
        public StockSlip DeleteStockSlip
        {
            get { return _deleteStockSlip; }
            set { _deleteStockSlip = value; }
        }

        /// <summary>
        /// �폜�d�����׃f�[�^�I�u�W�F�N�g���X�g
        /// </summary>
        public List<StockDetail>  DeleteStockDetailList
        {
            get { return _deleteStockDetailList; }
            set { _deleteStockDetailList = value; }
        }

        /// <summary>
        /// �폜�v�㌳�d�����׃f�[�^�I�u�W�F�N�g���X�g
        /// </summary>
        public List<StockDetail> DeleteAddUpSrcDetailList
        {
            get { return _deleteAddUpSrcDetailList; }
            set { _deleteAddUpSrcDetailList = value; }
        }

        /// <summary>
        /// �폜�x���f�[�^�I�u�W�F�N�g
        /// </summary>
        public PaymentSlp DeletePaymentSlp
        {
            get { return _deletePaymentSlp; }
            set { _deletePaymentSlp = value; }
        }

        /// <summary>
        /// �폜�x�����׃f�[�^���X�g
        /// </summary>
        public List<PaymentDtl> DeletePaymentDtlList
        {
            get { return _deletePaymentDtlList; }
            set { _deletePaymentDtlList = value; }
        }

        /// <summary>
        /// �폜�݌Ƀ��[�N�I�u�W�F�N�g���X�g
        /// </summary>
        public List<StockWork> DeleteStockWorkList
        {
            get { return _deleteStockWorkList; }
            set { _deleteStockWorkList = value; }
        }

        /// <summary>
        /// Modify�t���O
        /// </summary>
        public bool IsCannotModify
        {
            get { return _isCannotModify; }
            set { _isCannotModify = value; }
        }
        //ADD 2012/03/13 ���N�n�� Redmine #27374-----<<<<<
		# endregion

        // ===================================================================================== //
        // �\����
        // ===================================================================================== //
        #region ��Struct

        #endregion

        // ===================================================================================== //
		// DB�f�[�^�A�N�Z�X����
		// ===================================================================================== //
		# region ��DataBase Access Methods
		/// <summary>
		/// �d���f�[�^�̕ۑ����s���܂��B
		/// </summary>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="supplierSlipNo">�d���`�[�ԍ�</param>
		/// <param name="retMessage">���b�Z�[�W�iout�j</param>
		/// <returns>STATUS</returns>
		public int SaveDBData(string enterpriseCode, int supplierSlipNo, out string retMessage)
		{
			List<StockDetail> stockDetailList;
			List<StockDetail> addUpSrcDetailList = new List<StockDetail>();
			List<SalesTemp> salesTempList = new List<SalesTemp>();
			List<SalesTemp> savedSalesTempList = new List<SalesTemp>();
			PaymentSlp paymentSlp = null;
            List<PaymentDtl> paymentDtlList = null;

			this.GetCurrentStockDetail(out stockDetailList, out salesTempList, out savedSalesTempList);

            this.ClearGoodsCacheInfo();
            this.ReSearchGoods();

            this.GetCurrentPaymentData(this._stockSlip, out paymentSlp, out paymentDtlList);

            retMessage = string.Empty;
            return this.SaveDBData(this._stockSlip, stockDetailList, addUpSrcDetailList, paymentSlp, paymentDtlList, salesTempList, savedSalesTempList, out retMessage);
        }

		/// <summary>
		/// �d���f�[�^�̕ۑ����s���܂��B�i�I�[�o�[���[�h�j
		/// </summary>
		/// <param name="stockSlip">�d���f�[�^�I�u�W�F�N�g</param>
		/// <param name="stockDetailList">�d�����׃f�[�^���X�g�I�u�W�F�N�g</param>
		/// <param name="addUpSrcDetailList">�v�㌳�d�����׃f�[�^���X�g�I�u�W�F�N�g</param>
		/// <param name="paymentSlp">�x���f�[�^�I�u�W�F�N�g</param>
        /// <param name="paymentDtlList">�x�����׃f�[�^�I�u�W�F�N�g���X�g</param>
		/// <param name="salesTempList">��������f�[�^���X�g</param>
		/// <param name="savedSalesTempList">�ۑ��ς݂̓�������f�[�^�I�u�W�F�N�g</param>
		/// <param name="retMessage">���b�Z�[�W�iout�j</param>
		/// <returns>STATUS</returns>
        /// <br>Update Note : 2013/01/08 �A����</br>
        /// <br>�Ǘ��ԍ�    : 10801804-00 2013/03/13�z�M��</br>
        /// <br>            : redmine#31984 �d���`�[���͂̑���֗��̑Ή�</br>
		private int SaveDBData( StockSlip stockSlip, List<StockDetail> stockDetailList, List<StockDetail> addUpSrcDetailList, PaymentSlp paymentSlp,List<PaymentDtl> paymentDtlList, List<SalesTemp> salesTempList, List<SalesTemp> savedSalesTempList, out string retMessage )
		{
			//------------------------------------------------------------------------------------
			// �������ݎ���CustomSerializeArrayList�̍\��
			//------------------------------------------------------------------------------------
			//  CustomSerializeArrayList            �������݃p�����[�^���X�g
			//      --IOWriteCtrlOptWork			IOWrite���䃏�[�N�I�u�W�F�N�g
			//      --CustomSerializeArrayList      �d�����X�g
			//          --SalesSlipWork             �d���f�[�^�I�u�W�F�N�g
			//          --ArrayList                 �d�����׃��X�g
			//              --SalesDetailWork       �d�����׃f�[�^�I�u�W�F�N�g
			//          --DepsitMainWork            �x���f�[�^�I�u�W�F�N�g
			//      --CustomSerializeArrayList      ����������
			//          --SalesTempWork             �������͔���f�[�^�I�u�W�F�N�g
			//------------------------------------------------------------------------------------
			CustomSerializeArrayList dataList = new CustomSerializeArrayList();

			IOWriteCtrlOptWork iOWriteCtrlOptWork = this.GetIOWriteCtrlOptWork();

			//==========<< �d�����X�g�̃Z�b�g >>==========//
			CustomSerializeArrayList stockSlipDataList = new CustomSerializeArrayList();

			// �@�d���f�[�^�̕␳
			stockSlip.EnterpriseCode = this._enterpriseCode;
			stockSlip.SectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;
			stockSlip.InputDay = DateTime.Today;
            stockSlip.StockSlipUpdateCd = ( stockSlip.SupplierSlipNo == 0 ) ? 0 : 1;    // �d���`�[�X�V�敪
			stockSlip.DetailRowCount = stockDetailList.Count;

			// �ԕi�`�[�̏ꍇ�̓`�[���s�敪
			if (( stockSlip.SupplierFormal == 0 ) &&
				( stockSlip.SupplierSlipCd == 20 ) &&
				( this._stockSlipInputInitDataAcs.GetStockTtlSt().RgdsSlipPrtDiv == 1 ))
			{
				stockSlip.SlipPrintDivCd = 1;
			}

            if (( paymentSlp != null ) && ( paymentDtlList != null ) && ( paymentDtlList.Count > 0 ))
                stockSlip.AutoPayment = 1;

			// �A�d�����׃f�[�^���[�N�N���X���X�g�A����
			ArrayList stockDetailArrayList = new ArrayList();
			ArrayList slipDetailAddInfoWorkList = new ArrayList();
			
			foreach (StockDetail stockDetail in stockDetailList)
			{
				stockDetail.EnterpriseCode = this._enterpriseCode;
				stockDetail.SectionCode = stockSlip.SectionCode;
				stockDetail.SupplierFormal = stockSlip.SupplierFormal;
				stockDetail.SupplierSlipNo = stockSlip.SupplierSlipNo;
				stockDetail.DtlRelationGuid = Guid.NewGuid();

				// �d���݌Ɏ�񂹋敪
                stockDetail.StockOrderDivCd = ( string.IsNullOrEmpty(stockDetail.WarehouseCode.Trim()) ) ? 0 : 1;
				if (stockDetail.StockSlipDtlNumSrc == 0) stockDetail.SupplierFormalSrc = -1;

				stockDetailArrayList.Add(ConvertStockSlip.ParamDataFromUIData(stockDetail));

				// ���גǉ����
				SlipDetailAddInfoWork slipDetailAddInfoWork = new SlipDetailAddInfoWork();
				slipDetailAddInfoWork.DtlRelationGuid = stockDetail.DtlRelationGuid;		// ���׊֘A�t��GUID

                // �i�ԁE���[�J�[�����͂���Ă��āA�d���s�̏ꍇ
                if (( !string.IsNullOrEmpty(stockDetail.GoodsNo) && ( stockDetail.GoodsMakerCd != 0 ) ) && ( stockDetail.StockSlipCdDtl == 0 ))
                {
                    GoodsUnitData goodsUnitData = this.GetGoodsUnitDataFromCache(stockDetail.GoodsNo, stockDetail.GoodsMakerCd);

                    // 2009.03.27 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                    //// ���i�����o�^�F����
                    //if (this._stockSlipInputInitDataAcs.GetStockTtlSt().AutoEntryGoodsDivCd == 1)
                    //{
                    //    if (( goodsUnitData == null ) || ( goodsUnitData.OfferKubun >= 3 ))
                    //    {
                    //        if (goodsUnitData == null) goodsUnitData = new GoodsUnitData();

                    //        slipDetailAddInfoWork.GoodsEntryDiv = 1;                            // ���i�o�^�敪
                    //        slipDetailAddInfoWork.GoodsOfferDate = goodsUnitData.OfferDate;     // ���i�񋟓�

                    //        GoodsPrice goodsPrice = this._stockSlipInputInitDataAcs.GetGoodsPrice(( stockSlip.SupplierFormal == 0 ) ? stockSlip.StockDate : stockSlip.ArrivalGoodsDay, goodsUnitData);
                    //        if (goodsPrice != null)
                    //        {
                    //            slipDetailAddInfoWork.PriceOfferDate = goodsPrice.OfferDate;    // ���i�񋟓�
                    //        }
                    //        slipDetailAddInfoWork.PriceStartDate = ( stockSlip.SupplierFormal == 0 ) ? stockSlip.StockDate : stockSlip.ArrivalGoodsDay; // ���i�J�n��
                    //        slipDetailAddInfoWork.PriceUpdateDiv = 1;
                    //    }
                    //}
                    //else
                    //{
                    //    if (( goodsUnitData != null ) && ( goodsUnitData.OfferKubun <= 2 ))
                    //    {
                    //        GoodsPrice goodsPrice = this._stockSlipInputInitDataAcs.GetGoodsPrice(( stockSlip.SupplierFormal == 0 ) ? stockSlip.StockDate : stockSlip.ArrivalGoodsDay, goodsUnitData);

                    //        // ���i�����o�^���u���Ȃ��v�ꍇ�̂݁A���i�X�V�敪��ݒ�
                    //        slipDetailAddInfoWork.PriceUpdateDiv = stockSlip.PriceCostUpdtDiv;			// ���i�X�V�敪

                    //        if (goodsPrice != null)
                    //        {
                    //            slipDetailAddInfoWork.PriceStartDate = goodsPrice.PriceStartDate;       // ���i�J�n��
                    //            slipDetailAddInfoWork.PriceOfferDate = goodsPrice.OfferDate;			// ���i�񋟓�
                    //        }
                    //        else
                    //        {
                    //            slipDetailAddInfoWork.PriceStartDate = ( stockSlip.SupplierFormal == 0 ) ? stockSlip.StockDate : stockSlip.ArrivalGoodsDay; // ���i�J�n��
                    //        }
                    //    }
                    //}

                    // ���i�����o�^�F����
                    if ((this._stockSlipInputInitDataAcs.GetStockTtlSt().AutoEntryGoodsDivCd == 1) &&
                        ((goodsUnitData == null) || (goodsUnitData.OfferKubun >= 3)))
                    {
                        if (goodsUnitData == null) goodsUnitData = new GoodsUnitData();

                        slipDetailAddInfoWork.GoodsEntryDiv = 1;                            // ���i�o�^�敪
                        slipDetailAddInfoWork.GoodsOfferDate = goodsUnitData.OfferDate;     // ���i�񋟓�

                        GoodsPrice goodsPrice = this._stockSlipInputInitDataAcs.GetGoodsPrice((stockSlip.SupplierFormal == 0) ? stockSlip.StockDate : stockSlip.ArrivalGoodsDay, goodsUnitData);
                        if (goodsPrice != null)
                        {
                            slipDetailAddInfoWork.PriceOfferDate = goodsPrice.OfferDate;    // ���i�񋟓�
                        }
                        // --- UPD m.suzuki 2010/11/12 ---------->>>>>
                        //slipDetailAddInfoWork.PriceStartDate = (stockSlip.SupplierFormal == 0) ? stockSlip.StockDate : stockSlip.ArrivalGoodsDay; // ���i�J�n��
                        slipDetailAddInfoWork.PriceStartDate = GetPriceStartDate( stockSlip ); // ���i�J�n��
                        // --- UPD m.suzuki 2010/11/12 ----------<<<<<
                        slipDetailAddInfoWork.PriceUpdateDiv = 1;
                    }
                    else
                    {
                        //>>>2010/09/15
                        //if (goodsUnitData != null)
                        if ((goodsUnitData != null) && (goodsUnitData.OfferKubun < 3))
                        //<<<2010/09/15
                        {
                            GoodsPrice goodsPrice = this._stockSlipInputInitDataAcs.GetGoodsPrice((stockSlip.SupplierFormal == 0) ? stockSlip.StockDate : stockSlip.ArrivalGoodsDay, goodsUnitData);

                            slipDetailAddInfoWork.PriceUpdateDiv = stockSlip.PriceCostUpdtDiv;			// ���i�X�V�敪
                            if (goodsPrice != null)
                            {
                                slipDetailAddInfoWork.PriceStartDate = goodsPrice.PriceStartDate;       // ���i�J�n��
                                slipDetailAddInfoWork.PriceOfferDate = goodsPrice.OfferDate;			// ���i�񋟓�
                            }
                            else
                            {
                                // --- UPD m.suzuki 2010/11/12 ---------->>>>>
                                //slipDetailAddInfoWork.PriceStartDate = (stockSlip.SupplierFormal == 0) ? stockSlip.StockDate : stockSlip.ArrivalGoodsDay; // ���i�J�n��
                                slipDetailAddInfoWork.PriceStartDate = GetPriceStartDate( stockSlip );
                                // --- UPD m.suzuki 2010/11/12 ----------<<<<<
                            }
                        }
                    }
                    // 2009.03.27 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                }

				slipDetailAddInfoWorkList.Add(slipDetailAddInfoWork);
			}

            // --- ADD 杍^ 2014/01/07 ------------ >>>>>>
            // stockSlip.SupplierSlipCd �� 20:�ԕi�̏ꍇ�AstockSlip.DebitNoteDiv �� 1:�ԓ`�̏ꍇ�A
            if (stockSlip.DebitNoteDiv == 1 || 
                (stockSlip.SupplierSlipCd == 20 && stockDetailArrayList.Count > 0 && ((StockDetailWork)stockDetailArrayList[0]).StockSlipDtlNumSrc != 0))
            {
                // ����œ]�ŕ����ҏW���f���\�b�h�̕Ԓl��true�̏ꍇ�A
                if (CheckConsTaxLayMethod(stockSlip))
                {
                    // �d���f�[�^(StockSlipRf).�d�������œ]�ŕ���(SuppCTaxLayCdRF)���O�F�`�[�P��
                    stockSlip.SuppCTaxLayCd = 0;
                }
            }
            // --- ADD 杍^ 2014/01/07 ------------ <<<<<<

			stockSlipDataList.Add(ConvertStockSlip.ParamDataFromUIData(stockSlip));

			if (stockDetailArrayList.Count > 0) stockSlipDataList.Add(stockDetailArrayList);

			if (slipDetailAddInfoWorkList.Count > 0) stockSlipDataList.Add(slipDetailAddInfoWorkList);

			// �B�����x����񃏁[�N�N���X�Z�b�g
            if (( paymentSlp != null ) && ( paymentDtlList != null ) && ( paymentDtlList.Count > 0 ))
			{
                stockSlipDataList.Add(this.CreatePaymentDataWork(paymentSlp, paymentDtlList));
			}

			//==========<< �������͔��ナ�X�g >>==========//
			CustomSerializeArrayList salesTempDataList = new CustomSerializeArrayList();

			ArrayList salesTempArrayList = new ArrayList();
			foreach (SalesTemp salesTemp in salesTempList)
			{
				salesTemp.EnterpriseCode = this._enterpriseCode;
				salesTemp.SectionCode = stockSlip.SectionCode;
				salesTemp.SalesOrderDivCd = ( !string.IsNullOrEmpty(salesTemp.WarehouseCode.Trim()) ) ? 1 : 0;
				salesTempDataList.Add(ConvertStockSlip.ParamDataFromUIData(salesTemp));
			}


			// �������݃p�����[�^�̃Z�b�g
			dataList.Add(iOWriteCtrlOptWork);
			dataList.Add(stockSlipDataList);
			if (salesTempDataList.Count > 0) dataList.Add(salesTempDataList);

			object dataObj = (object)dataList;

            retMessage = string.Empty;
			string retItemInfo;
			int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

			if (stockSlip.DebitNoteDiv == 1)
			{
				// �ԓ`�̏ꍇ�A�����̃f�[�^���擾����
				StockSlip nLnkStockSlip = new StockSlip();
                StockSlip nLnkBaseStockSlip; // 2009.03.25
				List<StockDetail> nLnkStockDetailList;
				List<StockDetail> nLnkaddUpSrcDetailList;
                PaymentSlp nLnkPaymentSlp;
                List<PaymentDtl> nLnkPaymentDtlList;
				List<SalesTemp> nLnkSalesTempList;
				List<StockWork> nLnkStockWorkList;

                //status = this.ReadDBData(stockSlip.EnterpriseCode, stockSlip.SupplierFormal, stockSlip.DebitNLnkSuppSlipNo, false, out nLnkStockSlip, out nLnkStockDetailList, out nLnkaddUpSrcDetailList, out nLnkPaymentSlp, out nLnkPaymentDtlList, out nLnkSalesTempList, out nLnkStockWorkList); // 2009.03.25
                status = this.ReadDBData(stockSlip.EnterpriseCode, stockSlip.SupplierFormal, stockSlip.DebitNLnkSuppSlipNo, false, out nLnkStockSlip, out nLnkBaseStockSlip, out nLnkStockDetailList, out nLnkaddUpSrcDetailList, out nLnkPaymentSlp, out nLnkPaymentDtlList, out nLnkSalesTempList, out nLnkStockWorkList); // 2009.03.25

				if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
				{
					CustomSerializeArrayList originDataList = new CustomSerializeArrayList();

					originDataList.Add(ConvertStockSlip.ParamDataFromUIData(nLnkStockSlip));

					object originDataObj = (object)originDataList;

                    if (this._iIOWriteControlDB == null) this._iIOWriteControlDB = (IIOWriteControlDB)MediationIOWriteControlDB.GetIOWriteControlDB();
					status = this._iIOWriteControlDB.RedWrite(ref originDataObj, ref dataObj, out retMessage, out retItemInfo);
				}
			}
			else
			{
                if (this._iIOWriteControlDB == null) this._iIOWriteControlDB = (IIOWriteControlDB)MediationIOWriteControlDB.GetIOWriteControlDB();
				status = this._iIOWriteControlDB.Write(ref dataObj, out retMessage, out retItemInfo);
			}

			if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				dataList = (CustomSerializeArrayList)dataObj;
				StockSlipWork stockSlipWork;
				StockDetailWork[] stockDetailWorkArray;
                AddUpOrgStockDetailWork[] addUpOrgStockDetailWorkArray;
				PaymentDataWork paymentDataWork;
				StockWork[] stockWorkArray;
				SalesTempWork[] salesTempWorkArray;
				List<StockWork> stockWorkList = new List<StockWork>();

				// CustomSerializeArrayList��������
                DivisionStockSlipCustomSerializeArrayList.DivisionCustomSerializeArrayListForWritingResult(dataList, out stockSlipWork, out stockDetailWorkArray, out addUpOrgStockDetailWorkArray, out paymentDataWork, out stockWorkArray, out salesTempWorkArray);

				stockSlip = ConvertStockSlip.UIDataFromParamData(stockSlipWork);
				stockDetailList = ConvertStockSlip.UIDataFromParamData(stockDetailWorkArray);
				addUpSrcDetailList = ConvertStockSlip.UIDataFromParamData(addUpOrgStockDetailWorkArray);

                this.DivisionPaymentDataWork(paymentDataWork, out paymentSlp, out paymentDtlList);

				salesTempList = ConvertStockSlip.UIDataFromParamData(salesTempWorkArray);
				if (( stockWorkArray != null ) && ( stockWorkArray.Length > 0 ))
					stockWorkList.AddRange(stockWorkArray);

				// �������͕��̏C���f�[�^�́ASave���\�b�h�ōX�V���Ȃ��̂ŁA�ǂݍ��ޑO�̏������̂܂܎g�p����
				if (( savedSalesTempList != null ) && ( savedSalesTempList.Count > 0 ))
				{
					if (salesTempList == null) salesTempList = new List<SalesTemp>();

					salesTempList.AddRange(savedSalesTempList);
				}

                if (paymentDataWork != null)
                {
                }

                this.AdjustStockSaveDBData(ref stockSlip, ref stockDetailList);

				// ���̓��[�h�ݒ菈��
				this.SettingInputMode(stockSlip);

                //----ADD  2013/01/08 Readmine#31984  �A����  ----->>>>>
                //�ݒ��ʂ̕ۑ���̏��������u���Ȃ��v�ɐݒ肵���ꍇ�A
                //���׃O���b�h�ɑO�񔭍s�����d���`�[�̎d�����׃f�[�^�����������邽�߂ɁA
                //�d�����׃f�[�^�̎d�����גʔԂ��N���A���鏈����ǉ�����
                //�N���A�����͈͂͐ԓ`�ȊO
                if (this._stockInputConstructionAcs.ClearAfterSaveValue == StockSlipInputConstructionAcs.ClearAfterSave_OFF && stockSlip.DebitNoteDiv!=1)
                {
                    foreach (StockDetail stockDetail in stockDetailList)
                    {
                        stockDetail.AcceptAnOrderNo = 0;                   //�󒍔ԍ�
                        stockDetail.CommonSeqNo = 0;                       //���ʒʔ�
                        stockDetail.StockSlipDtlNum = 0;                   //�d�����גʔ�
                    }
                }
                //----ADD  2013/01/08 Readmine#31984  �A����  -----<<<<<

				// �d���f�[�^�L���b�V��
                this.Cache(stockSlip, stockSlip, stockDetailList, addUpSrcDetailList, paymentSlp, paymentDtlList, salesTempList, stockWorkList);
			}
			else if (status == (int)ConstantManagement.DB_Status.ctDB_DUPLICATE)
			{
				dataList = (CustomSerializeArrayList)dataObj;
				StockSlipWork stockSlipWork;
				StockDetailWork[] stockDetailWorkArray;
                AddUpOrgStockDetailWork[] addUppOrgStockDetailWork;
				StockWork[] stockWorkArray;
				PaymentDataWork paymentDataWork;
				SalesTempWork[] salesTempWorkArray;

				// CustomSerializeArrayList��������
                DivisionStockSlipCustomSerializeArrayList.DivisionCustomSerializeArrayListForWritingResult(dataList, out stockSlipWork, out stockDetailWorkArray, out addUppOrgStockDetailWork, out paymentDataWork, out stockWorkArray, out salesTempWorkArray);

				stockSlip = ConvertStockSlip.UIDataFromParamData(stockSlipWork);
				stockDetailList = ConvertStockSlip.UIDataFromParamData(stockDetailWorkArray);
				addUpSrcDetailList = ConvertStockSlip.UIDataFromParamData(addUppOrgStockDetailWork);

                this.DivisionPaymentDataWork(paymentDataWork, out paymentSlp, out paymentDtlList);

                this.AdjustStockSaveDBData(ref stockSlip, ref stockDetailList);

				salesTempList = ConvertStockSlip.UIDataFromParamData(salesTempWorkArray);

				// �d�����׍s�����s���ǉ�����
				this.AddStockDetailRowInitialRowCount();
			}

			return status;
		}
        // --- ADD m.suzuki 2010/11/12 ---------->>>>>
        /// <summary>
        /// ���i�J�n���擾����
        /// </summary>
        /// <param name="stockSlip"></param>
        /// <returns></returns>
        private DateTime GetPriceStartDate( StockSlip stockSlip )
        {
            try
            {
                //--------------------------------------------------
                // �ʏ�́A�O�񌎎��X�V���̗���
                //--------------------------------------------------
                DateTime prevTotalDay = GetHisTotalDayMonthly();
                if ( prevTotalDay != DateTime.MinValue )
                {
                    // �O�񌎎��X�V���̗���
                    return prevTotalDay.AddDays( 1 );
                }

                //--------------------------------------------------
                // �i���V�K�������Ĉ�x�������X�V�����Ă��Ȃ��悤�ȏꍇ�j����.�����
                //--------------------------------------------------
                if ( _dateGetAcs == null )
                {
                    _dateGetAcs = DateGetAcs.GetInstance();
                }
                else
                {
                    _dateGetAcs.ReloadCompanyInf(); // �K���Ď擾����
                }
                List<DateTime> startMonthDateList;
                List<DateTime> endMonthDateList;

                CompanyInf companyInf = _dateGetAcs.GetCompanyInf();
                if ( companyInf != null && companyInf.CompanyBiginDate != 0 )
                {
                    _dateGetAcs.GetFinancialYearTable( out startMonthDateList, out endMonthDateList );
                    if ( startMonthDateList != null && startMonthDateList.Count > 0 )
                    {
                        // ��������ŏ��̌��̊J�n��
                        return startMonthDateList[0];
                    }
                }
            }
            catch
            {
            }

            //--------------------------------------------------
            // ���ʏ�͔������Ȃ����O�񌎎��X�V������������擾�ł��Ȃ��ꍇ�́A
            // �@�d�l�ύX�O�Ɠ��l�ɁA�d����or���ד����Z�b�g����B
            //--------------------------------------------------
            return (stockSlip.SupplierFormal == 0) ? stockSlip.StockDate : stockSlip.ArrivalGoodsDay;
        }
        /// <summary>
        /// �O�񌎎��X�V���擾
        /// </summary>
        /// <returns></returns>
        private DateTime GetHisTotalDayMonthly()
        {
            if ( _totalDayCalculator == null ) this._totalDayCalculator = TotalDayCalculator.GetInstance();

            int status;
            DateTime prevTotalDay;

            // �����Z�o���W���[���̃L���b�V���N���A
            this._totalDayCalculator.ClearCache();

            // ���|�I�v�V��������
            PurchaseStatus ps;
            ps = LoginInfoAcquisition.SoftwarePurchasedCheckForCompany( ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_StockingPayment );
            if ( ps == PurchaseStatus.Contract )
            {
                // ���|�I�v�V��������
                // ���㌎���������A�d�������������̌Â��N���擾
                this._totalDayCalculator.InitializeHisMonthly();
                status = this._totalDayCalculator.GetHisTotalDayMonthly( string.Empty, out prevTotalDay );
                if ( prevTotalDay == DateTime.MinValue )
                {
                    // ���㌎���������擾
                    status = this._totalDayCalculator.GetHisTotalDayMonthlyAccRec( string.Empty, out prevTotalDay );
                    if ( prevTotalDay == DateTime.MinValue )
                    {
                        // �d�������������擾
                        status = this._totalDayCalculator.GetHisTotalDayMonthlyAccPay( string.Empty, out prevTotalDay );
                    }
                }
            }
            else
            {
                // ���|�I�v�V�����Ȃ�
                // ���㌎���������擾
                this._totalDayCalculator.InitializeHisMonthlyAccRec();
                status = this._totalDayCalculator.GetHisTotalDayMonthlyAccRec( string.Empty, out prevTotalDay );
            }

            return prevTotalDay;
        }
        // --- ADD m.suzuki 2010/11/12 ----------<<<<<

        // --- ADD 杍^ 2014/01/07 ---------->>>>>
        /// <summary>
        /// ����œ]�ŕ����ҏW���f���\�b�h
        /// </summary>
        /// <param name="stockSlip">�d���f�[�^</param>
        /// <remarks>
        /// <br>Note       : ����œ]�ŕ����ҏW���f���s���܂��B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2014/01/07</br>
        /// </remarks>
        /// <returns>true:���݂��� false:���݂��Ȃ�</returns>
        private bool CheckConsTaxLayMethod(StockSlip stockSlip)
        {
            bool consTaxLayMethodFlg = false;

            // �@�����̏���œ]�ŕ������A�����e���͐����q�̏ꍇ�A
            if (stockSlip.SuppCTaxLayCd == 2 || stockSlip.SuppCTaxLayCd == 3)
            {
                // �A�ŗ��ݒ肪�Q���ȏ゠��ꍇ�A
                if (this._stockSlipInputInitDataAcs.GetTaxRateSet().TaxRateStartDate2 != DateTime.MinValue
                    || this._stockSlipInputInitDataAcs.GetTaxRateSet().TaxRateStartDate3 != DateTime.MinValue)
                {
                    double taxRate = this._stockSlipInputInitDataAcs.GetTaxRate(stockSlip.StockDate);

                    // �B����������t�Ɛԓ`������t�ŁA�ŗ����Ⴄ�ꍇ�A
                    if (stockSlip.SupplierConsTaxRate != taxRate)
                    {
                        consTaxLayMethodFlg = true;
                    }
                }
            }

            return consTaxLayMethodFlg;
        }
        // --- ADD 杍^ 2014/01/07 ----------<<<<<

		/// <summary>
		/// �d���f�[�^�̍폜���s���܂��B
		/// </summary>
		/// <param name="stockSlip">�d���f�[�^�I�u�W�F�N�g</param>
        /// <param name="stockDetailList">�d�����׃f�[�^�I�u�W�F�N�g���X�g</param>
		/// <param name="paymentSlp">�x���f�[�^�I�u�W�F�N�g</param>
        /// <param name="paymentDtlList">�x�����׃f�[�^�I�u�W�F�N�g���X�g</param>
		/// <param name="retMessage">���b�Z�[�W</param>
		/// <returns>STATUS</returns>
        public int DeleteDBData(StockSlip stockSlip, PaymentSlp paymentSlp, List<PaymentDtl> paymentDtlList, out string retMessage)
		{
			IOWriteCtrlOptWork iOWriteCtrlOptWork = this.GetIOWriteCtrlOptWork();

			IOWriteMASIRDeleteWork deleteWork = new IOWriteMASIRDeleteWork();
			deleteWork.EnterpriseCode = stockSlip.EnterpriseCode;
			deleteWork.UpdateDateTime = stockSlip.UpdateDateTime;
			deleteWork.SupplierFormal = stockSlip.SupplierFormal;
			deleteWork.SupplierSlipNo = stockSlip.SupplierSlipNo;
			deleteWork.DebitNoteDiv = stockSlip.DebitNoteDiv;

			CustomSerializeArrayList dataList = new CustomSerializeArrayList();

			dataList.Add(iOWriteCtrlOptWork);
			dataList.Add(deleteWork);

			if (( stockSlip.AutoPayment != 0 ) && ( stockSlip.AutoPaySlipNum != 0 ))
			{
                dataList.Add(this.CreatePaymentDataWork(paymentSlp, paymentDtlList));
			}

            CustomSerializeArrayList stockDetailCustomArrayList = new CustomSerializeArrayList();
            foreach (StockDetail stockDetail in this._stockDetailDBDataList)
            {
                stockDetailCustomArrayList.Add(ConvertStockSlip.ParamDataFromUIData(stockDetail));
            }

            dataList.Add(stockDetailCustomArrayList);

			object dataObj = (object)dataList;

            retMessage = string.Empty;
			string retItemInfo;
            if (this._iIOWriteControlDB == null) this._iIOWriteControlDB = (IIOWriteControlDB)MediationIOWriteControlDB.GetIOWriteControlDB();
			int status = this._iIOWriteControlDB.Delete(ref dataObj, out retMessage, out retItemInfo);

            //// �d�����׍s�����s���ǉ�����
            //this.AddStockDetailRowInitialRowCount();

			return status;
		}

		/// <summary>
		/// �d���f�[�^�̃��[�h���s���܂��B
		/// </summary>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="supplierFormal">�d���`��</param>
		/// <param name="supplierSlipNo">�d���`�[�ԍ�</param>
        /// <param name="baseStockSlip">�␳�O�d���f�[�^�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        //public int ReadDBData(string enterpriseCode, int supplierFormal, int supplierSlipNo) // 2009.03.25
        public int ReadDBData(string enterpriseCode, int supplierFormal, int supplierSlipNo, out StockSlip baseStockSlip) // 2009.03.25
        {
			StockSlip stockSlip;
			List<StockDetail> stockDetailList;
			List<StockDetail> addUpSrcDetailList;
            PaymentSlp paymentSlp;
            List<PaymentDtl> paymentDtlList;
            List<SalesTemp> salesTempList;
			List<StockWork> stockWorkList;

            //return this.ReadDBData(enterpriseCode, supplierFormal, supplierSlipNo, true, out stockSlip, out stockDetailList, out addUpSrcDetailList, out paymentSlp, out paymentDtlList, out salesTempList, out stockWorkList); // 2009.03.25
            return this.ReadDBData(enterpriseCode, supplierFormal, supplierSlipNo, true, out stockSlip, out baseStockSlip, out stockDetailList, out addUpSrcDetailList, out paymentSlp, out paymentDtlList, out salesTempList, out stockWorkList); // 2009.03.25
        }

		/// <summary>
		/// �d���f�[�^�̃��[�h���s���܂��B
		/// </summary>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="supplierFormal">�d���`��</param>
		/// <param name="supplierSlipNo">�d���`�[�ԍ�</param>
		/// <param name="stockSlip">�d���f�[�^�I�u�W�F�N�g</param>
		/// <param name="stockDetailList">�d�����׃f�[�^�I�u�W�F�N�g���X�g</param>
		/// <param name="stockDetailDataTable">�d�����׃e�[�u��</param>
		/// <returns>STATUS</returns>
        public int ReadDBData(string enterpriseCode, int supplierFormal, int supplierSlipNo, out StockSlip stockSlip, out List<StockDetail> stockDetailList, out StockInputDataSet.StockDetailDataTable stockDetailDataTable)
        {
            // ���̃��\�b�h�́A�d���`�[�Ɖ�Ŏg�p����Ă���ׁA�����Ȃ��ŉ������B
            List<StockDetail> addUpSrcDetailList;
            PaymentSlp paymentSlp;
            List<PaymentDtl> paymentDtlList;
            List<SalesTemp> salesTempList;
            StockSlip baseStockSlip; // 2009.03.25

            //return this.ReadDBData(ConstantManagement.LogicalMode.GetData0, enterpriseCode, supplierFormal, supplierSlipNo, out stockSlip, out stockDetailList, out addUpSrcDetailList, out paymentSlp, out paymentDtlList, out salesTempList, out stockDetailDataTable); // 2009.03.25
            return this.ReadDBData(ConstantManagement.LogicalMode.GetData0, enterpriseCode, supplierFormal, supplierSlipNo, out stockSlip, out baseStockSlip, out stockDetailList, out addUpSrcDetailList, out paymentSlp, out paymentDtlList, out salesTempList, out stockDetailDataTable); // 2009.03.25
        }


		/// <summary>
		/// �d���f�[�^�̃��[�h���s���܂��B�i�I�[�o�[���[�h�j
		/// </summary>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="supplierFormal">�d���`��</param>
		/// <param name="supplierSlipNo">�d���`�[�ԍ�</param>
		/// <param name="isCache">�L���b�V���L��</param>
        /// <param name="stockSlip">�d���f�[�^�I�u�W�F�N�g</param>
        /// <param name="baseStockSlip">�␳�O�d���f�[�^�I�u�W�F�N�g</param>
        /// <param name="stockDetailList">�d�����׃f�[�^�I�u�W�F�N�g���X�g</param>
		/// <param name="addUpSrcDetailList">�v�㌳�d�����׃f�[�^�I�u�W�F�N�g���X�g</param>
		/// <param name="paymentSlp">�x���f�[�^�I�u�W�F�N�g</param>
        /// <param name="paymentDtlList">�x�����׃f�[�^�I�u�W�F�N�g���X�g</param>
		/// <param name="salesTempList">����f�[�^(�d�������v��)�I�u�W�F�N�g���X�g</param>
		/// <param name="stockWorkList">�݌Ƀ��[�N�I�u�W�F�N�g���X�g</param>
		/// <returns>STATUS</returns>
        /// <br>Update Note : 2011/12/27 ����</br>
        /// <br>�Ǘ��ԍ�    : 10707327-00 2012/01/25�z�M��</br>
        /// <br>              redmine#27374 �d���`�[����/���ς̃`�F�b�N�̑Ή�</br>
        /// <br>Update Note : 2012/03/13 ���N�n��</br>
        /// <br>�Ǘ��ԍ�    : 10707327-00 2012/03/28�z�M��</br>
        /// <br>              Redmine#27374 �d���`�[���͂ŃK�C�h����ďo�����ꍇ�폜�ŃG���[�ɂȂ錏�̑Ή�</br>
        //public int ReadDBData( string enterpriseCode, int supplierFormal, int supplierSlipNo, bool isCache, out StockSlip stockSlip, out List<StockDetail> stockDetailList, out List<StockDetail> addUpSrcDetailList, out PaymentSlp paymentSlp, out List<PaymentDtl> paymentDtlList, out List<SalesTemp> salesTempList, out List<StockWork> stockWorkList ) // 2009.03.25
        public int ReadDBData(string enterpriseCode, int supplierFormal, int supplierSlipNo, bool isCache, out StockSlip stockSlip, out StockSlip baseStockSlip, out List<StockDetail> stockDetailList, out List<StockDetail> addUpSrcDetailList, out PaymentSlp paymentSlp, out List<PaymentDtl> paymentDtlList, out List<SalesTemp> salesTempList, out List<StockWork> stockWorkList) // 2009.03.25
        {
            //int status = this.ReadDBDataProc(ConstantManagement.LogicalMode.GetData0, enterpriseCode, supplierFormal, supplierSlipNo, out stockSlip, out stockDetailList, out addUpSrcDetailList, out paymentSlp, out paymentDtlList, out salesTempList, out stockWorkList); // 2009.03.25
            int status = this.ReadDBDataProc(ConstantManagement.LogicalMode.GetData0, enterpriseCode, supplierFormal, supplierSlipNo, out stockSlip, out baseStockSlip, out stockDetailList, out addUpSrcDetailList, out paymentSlp, out paymentDtlList, out salesTempList, out stockWorkList); // 2009.03.25

            //add 2011/12/27 ���� Redmine #27374----->>>>>
            this._stockDetailList = stockDetailList;
            this._paymentSlp = paymentSlp;
            this._paymentDtlList = paymentDtlList;
            this._addUpSrcDetailList = addUpSrcDetailList;
            this._stockWorkList = stockWorkList;
            //add 2011/12/27 ���� Redmine #27374-----<<<<<

          

			if (( isCache ) && ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL ))
			{
                //add 2012/03/13 ���N�n�� Redmine #27374----->>>>>
                stockSlip.PreStockDate = stockSlip.StockDate;
                _deleteStockSlip = stockSlip;
                _deleteStockDetailList = stockDetailList;
                _deleteAddUpSrcDetailList = addUpSrcDetailList;
                _deletePaymentSlp = paymentSlp;
                _deletePaymentDtlList = paymentDtlList;
                _deleteStockWorkList = stockWorkList;
                //add 2012/03/13 ���N�n�� Redmine #27374-----<<<<<

				// ���̓��[�h�ݒ菈��
				this.SettingInputMode(stockSlip);

				// �d���f�[�^�L���b�V������
                this.Cache(stockSlip, stockSlip, stockDetailList, addUpSrcDetailList, paymentSlp, paymentDtlList, salesTempList, stockWorkList);
			}

			return status;
		}

		/// <summary>
		/// �d���f�[�^�̃��[�h���s���܂��B�i�I�[�o�[���[�h�j
		/// </summary>
		/// <param name="logicalMode">�_���폜�敪</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="supplierFormal">�d���`��</param>
		/// <param name="supplierSlipNo">�d���`�[�ԍ�</param>
        /// <param name="stockSlip">�d���f�[�^�I�u�W�F�N�g</param>
        /// <param name="baseStockSlip">�␳�O�d���f�[�^�I�u�W�F�N�g</param>
        /// <param name="stockDetailList">�d�����׃f�[�^�I�u�W�F�N�g���X�g</param>
		/// <param name="addUpSrcDetailList">�v�㌳�d�����׃f�[�^�I�u�W�F�N�g���X�g</param>
		/// <param name="paymentSlp">�����x���f�[�^�I�u�W�F�N�g</param>
        /// <param name="paymentDtlList">�����x�����׃f�[�^�I�u�W�F�N�g���X�g</param>
		/// <param name="salesTempList">�d���f�[�^(���㓯���v��)�I�u�W�F�N�g���X�g</param>
		/// <param name="stockDetailDataTable">�d�����׃f�[�^�e�[�u���I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
        //public int ReadDBData( ConstantManagement.LogicalMode logicalMode, string enterpriseCode, int supplierFormal, int supplierSlipNo, out StockSlip stockSlip, out List<StockDetail> stockDetailList, out List<StockDetail> addUpSrcDetailList, out PaymentSlp paymentSlp, out List<PaymentDtl> paymentDtlList, out List<SalesTemp> salesTempList, out StockInputDataSet.StockDetailDataTable stockDetailDataTable ) // 2009.03.25
        public int ReadDBData(ConstantManagement.LogicalMode logicalMode, string enterpriseCode, int supplierFormal, int supplierSlipNo, out StockSlip stockSlip, out StockSlip baseStockSlip, out List<StockDetail> stockDetailList, out List<StockDetail> addUpSrcDetailList, out PaymentSlp paymentSlp, out List<PaymentDtl> paymentDtlList, out List<SalesTemp> salesTempList, out StockInputDataSet.StockDetailDataTable stockDetailDataTable) // 2009.03.25
        {
			stockDetailList = null;
			stockDetailDataTable = null;
			addUpSrcDetailList = null;
			paymentSlp = null;
			List<StockWork> stockWorkList;

            //int status = this.ReadDBDataProc(logicalMode, enterpriseCode, supplierFormal, supplierSlipNo, out stockSlip, out stockDetailList, out addUpSrcDetailList, out paymentSlp, out paymentDtlList, out salesTempList, out stockWorkList); // 2009.03.25
            int status = this.ReadDBDataProc(logicalMode, enterpriseCode, supplierFormal, supplierSlipNo, out stockSlip, out baseStockSlip, out stockDetailList, out addUpSrcDetailList, out paymentSlp, out paymentDtlList, out salesTempList, out stockWorkList); // 2009.03.25

			if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				stockDetailDataTable = this.CreateStockDetailDataTable(stockSlip, stockDetailList, addUpSrcDetailList);
			}

			return status;
		}

		/// <summary>
		/// �d���f�[�^�̃��[�h���s���܂��B�i�I�[�o�[���[�h�j
		/// </summary>
		/// <param name="logicalMode">�_���폜�敪</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="supplierFormal">�d���`��</param>
		/// <param name="supplierSlipNo">�d���`�[�ԍ�</param>
        /// <param name="stockSlip">�d���f�[�^�I�u�W�F�N�g</param>
        /// <param name="baseStockSlip">�␳�O�d���f�[�^�I�u�W�F�N�g</param>
        /// <param name="stockDetailList">�d�����׃f�[�^�I�u�W�F�N�g���X�g</param>
		/// <param name="addUpSrcDetailList">�v�㌳�d�����׃f�[�^�I�u�W�F�N�g���X�g</param>
		/// <param name="paymentSlp">�����x���f�[�^�I�u�W�F�N�g</param>
        /// <param name="paymentDtlList">�����x�����׃f�[�^�I�u�W�F�N�g���X�g</param>
		/// <param name="salesTempList">����f�[�^(�d�������v��)�I�u�W�F�N�g���X�g</param>
		/// <param name="stockWorkList">�݌Ƀ��[�N�I�u�W�F�N�g���X�g</param>
		/// <returns>STATUS</returns>
        //public int ReadDBData( ConstantManagement.LogicalMode logicalMode, string enterpriseCode, int supplierFormal, int supplierSlipNo, out StockSlip stockSlip, out List<StockDetail> stockDetailList, out List<StockDetail> addUpSrcDetailList, out PaymentSlp paymentSlp, out List<PaymentDtl> paymentDtlList, out List<SalesTemp> salesTempList, out List<StockWork> stockWorkList ) // 2009.03.25
        public int ReadDBData( ConstantManagement.LogicalMode logicalMode, string enterpriseCode, int supplierFormal, int supplierSlipNo, out StockSlip stockSlip, out StockSlip baseStockSlip, out List<StockDetail> stockDetailList, out List<StockDetail> addUpSrcDetailList, out PaymentSlp paymentSlp, out List<PaymentDtl> paymentDtlList, out List<SalesTemp> salesTempList, out List<StockWork> stockWorkList ) // 2009.03.25
        {
            //return this.ReadDBDataProc(logicalMode, enterpriseCode, supplierFormal, supplierSlipNo, out stockSlip, out stockDetailList, out addUpSrcDetailList, out paymentSlp, out paymentDtlList, out salesTempList, out stockWorkList); // 2009.03.25
            return this.ReadDBDataProc(logicalMode, enterpriseCode, supplierFormal, supplierSlipNo, out stockSlip, out baseStockSlip, out stockDetailList, out addUpSrcDetailList, out paymentSlp, out paymentDtlList, out salesTempList, out stockWorkList); //2009.03.25
        }

		/// <summary>
		/// �d���f�[�^�̃��[�h���s���܂��B�i�I�[�o�[���[�h�j
		/// </summary>
		/// <param name="logicalMode">�_���폜�敪</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="supplierFormal">�d���`��</param>
		/// <param name="supplierSlipNo">�d���`�[�ԍ�</param>
        /// <param name="stockSlip">�d���f�[�^�I�u�W�F�N�g</param>
        /// <param name="baseStockSlip">�␳�O�d���f�[�^�I�u�W�F�N�g</param>
        /// <param name="stockDetailList">�d�����׃f�[�^�I�u�W�F�N�g���X�g</param>
		/// <param name="addUpSrcDetailList">�v�㌳���׃f�[�^�I�u�W�F�N�g���X�g</param>
        /// <param name="paymentSlp">�x���f�[�^�I�u�W�F�N�g</param>
        /// <param name="paymentDtlList">�x�����׃f�[�^�I�u�W�F�N�g���X�g</param>
		/// <param name="salesTempList">����f�[�^(�d������)�I�u�W�F�N�g���X�g</param>
		/// <param name="stockWorkList">�݌Ƀ��[�N�I�u�W�F�N�g���X�g</param>
		/// <returns>STATUS</returns>
        //private int ReadDBDataProc(ConstantManagement.LogicalMode logicalMode, string enterpriseCode, int supplierFormal, int supplierSlipNo, out StockSlip stockSlip, out List<StockDetail> stockDetailList, out List<StockDetail> addUpSrcDetailList, out PaymentSlp paymentSlp, out List<PaymentDtl> paymentDtlList, out List<SalesTemp> salesTempList, out List<StockWork> stockWorkList)
        private int ReadDBDataProc( ConstantManagement.LogicalMode logicalMode, string enterpriseCode, int supplierFormal, int supplierSlipNo, out StockSlip stockSlip, out StockSlip baseStockSlip, out List<StockDetail> stockDetailList, out List<StockDetail> addUpSrcDetailList, out PaymentSlp paymentSlp, out List<PaymentDtl> paymentDtlList, out List<SalesTemp> salesTempList, out List<StockWork> stockWorkList )
        {
			int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			stockSlip = null;
            baseStockSlip = null; //2009.03.25
			stockDetailList = null;
			addUpSrcDetailList = null;
			paymentSlp = null;
            paymentDtlList = null;
			salesTempList = null;
			stockWorkList = null;

			IOWriteCtrlOptWork iOWriteCtrlOptWork = this.GetIOWriteCtrlOptWork();

			IOWriteMASIRReadWork readPara = new IOWriteMASIRReadWork();
			readPara.EnterpriseCode = enterpriseCode;
			readPara.SupplierFormal = supplierFormal;
			readPara.SupplierSlipNo = supplierSlipNo;

			CustomSerializeArrayList paraList = new CustomSerializeArrayList();
			paraList.Add(iOWriteCtrlOptWork);
			paraList.Add(readPara);

			object paraObj = (object)paraList;
			object retObj;
			object retObj2;

            if (this._iIOWriteControlDB == null) this._iIOWriteControlDB = (IIOWriteControlDB)MediationIOWriteControlDB.GetIOWriteControlDB();
			status = this._iIOWriteControlDB.Read(ref paraObj, out retObj, out retObj2);

			CustomSerializeArrayList retList = (CustomSerializeArrayList)retObj;
			CustomSerializeArrayList retList2 = (CustomSerializeArrayList)retObj2;

			if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				StockSlipWork stockSlipWork;
				StockDetailWork[] stockDetailWorkArray;
                AddUpOrgStockDetailWork[] addUpOrgStockDetailWorkArray;
				StockWork[] stockWorkArray;
				List<SalesSlipWork> salesSlipWorkListTemp;
				List<SalesDetailWork> salesDetailWorkListTemp;
				PaymentDataWork paymentDataWork;
				SalesTempWork[] salesTempWorkArray;

				// CustomSerializeArrayList��������
                DivisionStockSlipCustomSerializeArrayList.DivisionCustomSerializeArrayListForReadingResult(
					retList,
					retList2,
					out stockSlipWork,
					out stockDetailWorkArray,
					out addUpOrgStockDetailWorkArray,
                    out paymentDataWork,
					out stockWorkArray,
					out salesSlipWorkListTemp,
					out salesDetailWorkListTemp,
					out salesTempWorkArray);

                stockSlip = ConvertStockSlip.UIDataFromParamData(stockSlipWork);
                baseStockSlip = ConvertStockSlip.UIDataFromParamData(stockSlipWork); // 2009.03.25
                stockDetailList = ConvertStockSlip.UIDataFromParamData(stockDetailWorkArray);
                stockDetailList.Sort(new StockDetail.StockDetailComparer());
				addUpSrcDetailList = ConvertStockSlip.UIDataFromParamData(addUpOrgStockDetailWorkArray);
				salesTempList = ConvertStockSlip.UIDataFromParamData(salesTempWorkArray);
				if (( stockWorkArray != null ) && ( stockWorkArray.Length > 0 ))
				{
                    if (stockWorkList == null) stockWorkList = new List<StockWork>();
					stockWorkList.AddRange(stockWorkArray);
				}

				// ����f�[�^���[�N�I�u�W�F�N�g���X�g�A���㖾�׃f�[�^���[�N�I�u�W�F�N�g���X�g���甄��f�[�^(�d�������v��)�I�u�W�F�N�g���X�g�𐶐�
				List<SalesTemp> salesTempList2 = ConvertStockSlip.UIDataFromParamData(stockDetailList, salesSlipWorkListTemp, salesDetailWorkListTemp);
				if (( salesTempList2 != null ) && ( salesTempList2.Count > 0 ))
				{
					if (salesTempList == null)
					{
						salesTempList = new List<SalesTemp>();
					}
					salesTempList.AddRange(salesTempList2);
				}

                // �x���f�[�^���w�b�_�A���ׂɕ�����
                if (paymentDataWork != null)
                {
                    PaymentSlpWork paymentSlpWork;
                    PaymentDtlWork[] paymentDtlWorkArray;
                    PaymentDataUtil.Division(paymentDataWork, out paymentSlpWork, out paymentDtlWorkArray);

                    paymentSlp = ( paymentSlpWork != null ) ? (PaymentSlp)DBAndXMLDataMergeParts.CopyPropertyInClass(paymentSlpWork, typeof(PaymentSlp)) : new PaymentSlp();

                    paymentDtlList = new List<PaymentDtl>();
                    if (( paymentDtlWorkArray != null ) && ( paymentDtlWorkArray.Length > 0 ))
                    {
                        foreach (PaymentDtlWork paymentDtlWork in paymentDtlWorkArray)
                        {
                            paymentDtlList.Add((PaymentDtl)DBAndXMLDataMergeParts.CopyPropertyInClass(paymentDtlWork, typeof(PaymentDtl)));
                        }
                    }
                }
			}

			if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				// �Ǎ��p�d���f�[�^��������
				this.AdjustStockReadDBData(ref stockSlip, ref stockDetailList);
			}

			return status;
		}

		/// <summary>
		/// �c�a����擾�����f�[�^���f�[�^�e�[�u���ɃL���b�V�����܂��B
		/// </summary>
		/// <param name="stockSlip">�d���f�[�^�I�u�W�F�N�g</param>
		/// <param name="baseStockSlip">�������d���f�[�^�I�u�W�F�N�g</param>
		/// <param name="stockDetailList">�d�����׃f�[�^�I�u�W�F�N�g���X�g</param>
		/// <param name="addUpSrcDetailList">�v�㌳�d�����׃f�[�^�I�u�W�F�N�g���X�g</param>
		/// <param name="paymentSlp">�x���f�[�^�I�u�W�F�N�g</param>
        /// <param name="paymentDtlList">�x�����׃f�[�^���X�g</param>
		/// <param name="salesTempList">����f�[�^(�d�������v��)�I�u�W�F�N�g���X�g</param>
		/// <param name="stockWorkList">�݌Ƀ��[�N�I�u�W�F�N�g���X�g</param>
        public void Cache( StockSlip stockSlip, StockSlip baseStockSlip, List<StockDetail> stockDetailList, List<StockDetail> addUpSrcDetailList, PaymentSlp paymentSlp, List<PaymentDtl> paymentDtlList, List<SalesTemp> salesTempList, List<StockWork> stockWorkList )
		{
			// �f�[�^�e�[�u���N���A����
			this.ClearDetailTables();

			// �d���f�[�^�L���b�V������
			this.Cache(stockSlip);

			// �d���f�[�^�L���b�V�������iDB�Ǎ��f�[�^�j
			this.CacheDBData(stockSlip);

			// �d�����׃f�[�^�L���b�V������
			this.CacheStockDetail(stockSlip, baseStockSlip, stockDetailList, addUpSrcDetailList, this._stockDetailDataTable);

			// �݌Ƀf�[�^�L���b�V������
			this.CacheStockInfo(stockWorkList);

			// �݌ɒ���
            this.StockDetailStockInfoAdjust();

			// �d�����׃f�[�^�L���b�V�������iDB�Ǎ��f�[�^�j
			this.CacheStockDetailDBData(stockDetailList);

			// �d�����׍s�����s���ǉ�����
			this.AddStockDetailRowInitialRowCount();

			// �x���f�[�^�L���b�V������
            this.Cache(paymentSlp, paymentDtlList);

			// ����f�[�^(�d�������v��)�L���b�V������
			this.CacheSalesTemp(salesTempList);

            //// ���i�Č���
            //List<GoodsUnitData> goodsUnitDataList;
            //this.ReSearchGoods(this._stockDetailDataTable, out goodsUnitDataList);

            //// ���i���L���b�V��
            //this.CacheGoodsUnitData(goodsUnitDataList);

			// �f�[�^�ύX�t���O�v���p�e�B��false�ɂ���
			this.IsDataChanged = false;

		}

		/// <summary>
		/// �݌ɏ����L���b�V�����܂��B
		/// </summary>
		/// <param name="stockWorkList">�݌Ƀ��[�N�I�u�W�F�N�g���X�g</param>
		public void CacheStockInfo( List<StockWork> stockWorkList )
		{
			if (( stockWorkList != null ) && ( stockWorkList.Count > 0 ))
			{
				foreach (StockWork stockWork in stockWorkList)
				{
                    StockInputDataSet.StockInfoRow row = this._stockInfoDataTable.FindByWarehouseCodeGoodsNoGoodsMakerCd(stockWork.WarehouseCode.Trim(), stockWork.GoodsNo.Trim(), stockWork.GoodsMakerCd);
					if (row == null)
					{
						row = this._stockInfoDataTable.NewStockInfoRow();
						row.WarehouseCode = stockWork.WarehouseCode.Trim();
						row.GoodsNo = stockWork.GoodsNo.Trim();
						row.GoodsMakerCd = stockWork.GoodsMakerCd;
                        this._stockInfoDataTable.AddStockInfoRow(row);
                    }
					row.WarehouseName = stockWork.WarehouseName;
					row.WarehouseShelfNo = stockWork.WarehouseShelfNo.Trim();
					row.ShipmentPosCnt = stockWork.ShipmentPosCnt;
				}
			}
		}

		/// <summary>
		/// �݌ɏ����L���b�V�����܂��B
		/// </summary>
		/// <param name="stock">�݌ɏ��I�u�W�F�N�g</param>
        private void CacheStockInfo( Stock stock )
		{
			if (stock != null)
			{
				StockInputDataSet.StockInfoRow row = this._stockInfoDataTable.FindByWarehouseCodeGoodsNoGoodsMakerCd(stock.WarehouseCode.Trim(), stock.GoodsNo.Trim(), stock.GoodsMakerCd);
				if (row == null)
				{
					row = this._stockInfoDataTable.NewStockInfoRow();
					row.WarehouseCode = stock.WarehouseCode.Trim();
					row.GoodsNo = stock.GoodsNo.Trim();
					row.GoodsMakerCd = stock.GoodsMakerCd;
                    this._stockInfoDataTable.AddStockInfoRow(row);
				}
				row.WarehouseName = stock.WarehouseName;
				row.WarehouseShelfNo = stock.WarehouseShelfNo.Trim();
				row.ShipmentPosCnt = stock.ShipmentPosCnt;
			}
		}

        /// <summary>
        /// �݌ɏ��ɒ��������Z�b�g���܂��B
        /// </summary>
        /// <param name="warehouseCode">�q�ɃR�[�h</param>
        /// <param name="goodsNo">���i�R�[�h</param>
        /// <param name="goodsMakerCd">���[�J�[�R�[�h</param>
        /// <param name="adjustCount">������</param>
        private void StockInfoAdjustCountSetting( string warehouseCode, string goodsNo, int goodsMakerCd, double adjustCount )
        {
            StockInputDataSet.StockInfoRow row = this._stockInfoDataTable.FindByWarehouseCodeGoodsNoGoodsMakerCd(warehouseCode, goodsNo, goodsMakerCd);

            if (row != null)
            {
                row.AdjustCnt += adjustCount;
            }
        }


		/// <summary>
		/// �d�����׃f�[�^�I�u�W�F�N�g���X�g�̌��݌ɐ��𒲐����܂��B
		/// </summary>
		public void StockDetailStockInfoAdjust( )
		{
            if (this._stockInfoDataTable.Rows.Count > 0)
			{
                try
                {
                    this._stockDetailDataTable.AcceptChanges();
                    this._stockDetailDataTable.BeginLoadData();

                    List<string> stockKeyList = new List<string>();

                    foreach (StockInputDataSet.StockDetailRow stockDetailRow in this._stockDetailDataTable)
                    {
                        if (!string.IsNullOrEmpty(stockDetailRow.WarehouseCode.Trim()))
                        {
                            string stockKey = string.Format("{0,-6}{1,-40}{2,6}", stockDetailRow.WarehouseCode.Trim(), stockDetailRow.GoodsNo, stockDetailRow.GoodsMakerCd);
                            if (!stockKeyList.Contains(stockKey))
                            {
                                this.StockDetailStockInfoAdjust(stockDetailRow.WarehouseCode, stockDetailRow.GoodsNo, stockDetailRow.GoodsMakerCd);
                                stockKeyList.Add(stockKey);
                            }
                        }
                    }
                }
                finally
                {
                    this._stockDetailDataTable.EndLoadData();
                }
			}
		}

		/// <summary>
		/// �d�����׃f�[�^�I�u�W�F�N�g���X�g�̌��݌ɐ��𒲐����܂��B
		/// </summary>
		/// <param name="warehouseCode">�q�ɃR�[�h</param>
		/// <param name="goodsNo">���i�R�[�h</param>
		/// <param name="goodsMakerCode">���[�J�[�R�[�h</param>
		public void StockDetailStockInfoAdjust( string warehouseCode, string goodsNo, int goodsMakerCode )
		{
			if (( string.IsNullOrEmpty(warehouseCode) ) || ( string.IsNullOrEmpty(goodsNo) ) || ( goodsMakerCode == 0 )) return;

			StockInputDataSet.StockInfoRow stockInfoTableRow = this._stockInfoDataTable.FindByWarehouseCodeGoodsNoGoodsMakerCd(warehouseCode, goodsNo, goodsMakerCode);

			if (stockInfoTableRow != null)
			{
				//this._stockDetailDataTable.BeginLoadData();

				string defaultRowFilter = this._stockDetailDataView.RowFilter;
				string defaultSort = this._stockDetailDataView.Sort;

				try
				{
					StockInputDataSet.StockDetailRow stockDetailRow;
					// �݌Ƀ}�X�^��̌��݌ɂ��擾����
                    double shipmentPosCnt = (double)( (decimal)stockInfoTableRow.ShipmentPosCnt + (decimal)stockInfoTableRow.AdjustCnt );

					string selectString = string.Format("{0}='{1}' AND {2}='{3}' AND {4}={5}",
												this._stockDetailDataTable.WarehouseCodeColumn.ColumnName,
												stockInfoTableRow.WarehouseCode.Trim(),
												this._stockDetailDataTable.GoodsNoColumn.ColumnName,
												stockInfoTableRow.GoodsNo,
												this._stockDetailDataTable.GoodsMakerCdColumn.ColumnName,
												stockInfoTableRow.GoodsMakerCd);

					this._stockDetailDataView.Sort = string.Format("{0}", this._stockDetailDataTable.StockRowNoColumn);

					// ��U�A�C�����̐��ʂ��������������݌ɐ����v�Z����(�S���ׂ��폜���ꂽ�ꍇ�̌��݌ɐ����Z�o)
					this._stockDetailDataView.RowFilter = string.Format("{0} AND {1} <> 0", selectString, this._stockDetailDataTable.StockSlipDtlNumColumn.ColumnName);

					if (this._stockDetailDataView.Count > 0)
					{
						foreach (DataRowView drv in this._stockDetailDataView)
						{
                            stockDetailRow = this._stockDetailDataTable.FindBySupplierSlipNoStockRowNo((int)drv[this._stockDetailDataTable.SupplierSlipNoColumn.ColumnName], (int)drv[this._stockDetailDataTable.StockRowNoColumn.ColumnName]);
							bool shipmentCntChange = this.SupplierStockCountChangeCheck(stockDetailRow);

							// ���݌ɐ����ς��ꍇ�͌��̐��ʕ���������
							if (shipmentCntChange == true)
							{
                                if (stockDetailRow.StockCountDefault != 0)
                                {
                                    shipmentPosCnt = (double)( (decimal)shipmentPosCnt - (decimal)stockDetailRow.StockCountDefault );
                                }
                                else
                                {
                                    shipmentPosCnt = (double)( (decimal)shipmentPosCnt - (decimal)stockDetailRow.StockCount );
                                }
							}
						}
					}

					// �擪���ׂ��猻�݌ɐ����Čv�Z����
					this._stockDetailDataView.RowFilter = selectString;

					foreach (DataRowView drv in this._stockDetailDataView)
					{
                        stockDetailRow = this._stockDetailDataTable.FindBySupplierSlipNoStockRowNo((int)drv[this._stockDetailDataTable.SupplierSlipNoColumn.ColumnName], (int)drv[this._stockDetailDataTable.StockRowNoColumn.ColumnName]);
						bool shipmentCntChange = this.SupplierStockCountChangeCheck(stockDetailRow);

						stockDetailRow.ShipmentPosCnt = shipmentPosCnt;
                        // ---UPD 2011/07/18------------>>>>>
						// ���݌ɐ����ς��ꍇ�͉��Z
                        //if (shipmentCntChange == true)
                        //{
                        //    shipmentPosCnt = (double)( (decimal)shipmentPosCnt + (decimal)stockDetailRow.StockCount );
                        //}

                        if (this._stockSlipInputInitDataAcs.GetAllDefSet().DtlCalcStckCntDsp == 0)
                        {
                            // ���݌ɐ����ς��ꍇ�͉��Z
                            if (shipmentCntChange == true)
                            {
                                shipmentPosCnt = (double)((decimal)shipmentPosCnt + (decimal)stockDetailRow.StockCount);
                            }
                        }
                        else
                        {
                            if (this.HasStockInfo == false)
                            {
                                // ���݌ɐ����ς��ꍇ�͉��Z
                                if (shipmentCntChange == true)
                                {
                                    shipmentPosCnt = (double)((decimal)shipmentPosCnt + (decimal)stockDetailRow.StockCount);
                                }
                            }
                            else
                            {
                                if (this.StockRowNo == stockDetailRow.StockRowNo)
                                {
                                    //�Ȃ��B
                                }
                                else
                                {
                                    // ���݌ɐ����ς��ꍇ�͉��Z
                                    if (shipmentCntChange == true)
                                    {
                                        shipmentPosCnt = (double)((decimal)shipmentPosCnt + (decimal)stockDetailRow.StockCount);
                                    }
                                }
                            }
                        }
                        // ---UPD 2011/07/18------------<<<<<
                        // ---UPD 2011/07/18------------>>>>>
                        //stockDetailRow.ShipmentPosCntDisplay = shipmentPosCnt;

                        if (this.HasStockInfo == true && this.IsShipmentChange == true)
                        {
                            //�Ȃ��B
                        }
                        else
                        {
                            stockDetailRow.ShipmentPosCntDisplay = shipmentPosCnt;
                        }
                        // ---UPD 2011/07/18------------<<<<<
                        stockDetailRow.WarehouseShelfNo = stockInfoTableRow.WarehouseShelfNo;
					}

                    // ---ADD 2011/07/18------------->>>>>
                    if (this.HasStockInfo == true)
                    {
                        this.HasStockInfo = false;
                    }
                    if (this.IsShipmentChange == true)
                    {
                        this.IsShipmentChange = false;
                    }
                    // ---ADD 2011/07/18-------------<<<<<

				}
				finally
				{
					this._stockDetailDataView.RowFilter = defaultRowFilter;
					this._stockDetailDataView.Sort = defaultSort;
					//this._stockDetailDataTable.EndLoadData();
				}
			}
		}

        /// <summary>
        /// ���ׂ̋��z�A�P���̃f�t�H���g�l��ޔ����܂��B
        /// </summary>
        public void CacheStockPrice()
        {
            foreach (StockInputDataSet.StockDetailRow row in this._stockDetailDataTable)
            {
                // �P���A���z�̏����l
                row.StockUnitPriceDefault = row.StockUnitPriceFl;
                row.StockUnitTaxPriceDefault = row.StockUnitTaxPriceFl;
                row.StockPriceTaxExcDefault = row.StockPriceTaxExc;
                row.StockPriceTaxIncDefault = row.StockPriceTaxInc;
            }
        }


		/// <summary>
		/// �c�a����擾�����f�[�^���f�[�^�e�[�u���ɃL���b�V�����܂��B
		/// </summary>
		/// <param name="stockSlip">�d���f�[�^�I�u�W�F�N�g</param>
		/// <param name="baseStockSlip">�������d���f�[�^�I�u�W�F�N�g</param>
		/// <param name="stockDetailList">�d�����׃f�[�^�I�u�W�F�N�g���X�g</param>
		/// <param name="addUpSrcDetailList">�v�㌳�d�����׃f�[�^�I�u�W�F�N�g���X�g</param>
        /// <param name="stockWorkList">�݌Ƀ��X�g</param>
        public void Cache( StockSlip stockSlip, StockSlip baseStockSlip, List<StockDetail> stockDetailList, List<StockDetail> addUpSrcDetailList, List<StockWork> stockWorkList )
		{
            this.Cache(stockSlip, baseStockSlip, stockDetailList, addUpSrcDetailList, null, null, null, stockWorkList);
		}

		/// <summary>
		/// �c�a����擾�����f�[�^���f�[�^�e�[�u���ɃL���b�V�����܂��B
		/// </summary>
		/// <param name="stockSlip">�d���f�[�^�I�u�W�F�N�g</param>
		/// <param name="baseStockSlip">�������d���f�[�^�I�u�W�F�N�g</param>
		/// <param name="stockDetailList">�d�����׃f�[�^�I�u�W�F�N�g���X�g</param>
		/// <param name="addUpSrcDetailList">�v�㌳�d�����׃f�[�^�I�u�W�F�N�g���X�g</param>
		/// <param name="paymentSlp">�x���f�[�^�I�u�W�F�N�g</param>
        /// <param name="paymentDtlList">�x�����׃f�[�^�I�u�W�F�N�g���X�g</param>
        public void Cache( StockSlip stockSlip, StockSlip baseStockSlip, List<StockDetail> stockDetailList, List<StockDetail> addUpSrcDetailList, PaymentSlp paymentSlp, List<PaymentDtl> paymentDtlList )
        {
            this.Cache(stockSlip, baseStockSlip, stockDetailList, addUpSrcDetailList, paymentSlp, paymentDtlList, null, null);
        }

		/// <summary>
		/// �c�a����擾�����f�[�^���f�[�^�e�[�u���ɃL���b�V�����܂��B
		/// </summary>
		/// <param name="stockSlip">�d���f�[�^�I�u�W�F�N�g</param>
		/// <param name="baseStockSlip">�������d���f�[�^�I�u�W�F�N�g</param>
		/// <param name="stockDetailList">�d�����׃f�[�^�I�u�W�F�N�g���X�g</param>
        /// <param name="stockWorkList">�݌Ƀ��[�N���X�g</param>
        public void Cache( StockSlip stockSlip, StockSlip baseStockSlip, List<StockDetail> stockDetailList, List<StockWork> stockWorkList )
		{
            this.Cache(stockSlip, baseStockSlip, stockDetailList, null, null, null, null, stockWorkList);
		}

		/// <summary>
		/// �����`�[�ԍ����g�p���Ďd���f�[�^���������܂��B
		/// </summary>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="supplierFormal">�d���`��</param>
		/// <param name="partySalesSlipNum">�����`�[�ԍ�</param>
		/// <param name="partySalesSlipNumSearchMode">�����`�Ԃ̌������[�h(0:���S��v,1:�O����v)</param>
		/// <param name="stockSlipList">�d���f�[�^���X�g</param>
		/// <returns>STATUS</returns>
		public int ReadStockSlip( string enterpriseCode, int supplierFormal, string partySalesSlipNum, int partySalesSlipNumSearchMode, out List<StockSlip> stockSlipList )
		{
            return this.ReadStockSlip(enterpriseCode, supplierFormal, string.Empty, partySalesSlipNum, DateTime.MinValue, 0, partySalesSlipNumSearchMode, out stockSlipList);
		}

		/// <summary>
		/// �d���f�[�^���������܂��B
		/// </summary>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="supplierFormal">�d���`��</param>
		/// <param name="partySalesSlipNum">�����`�[�ԍ�</param>
		/// <param name="sectionCode">���_�R�[�h</param>
		/// <param name="targetDate">�Ώۓ�</param>
        /// <param name="supplierCd">�d����R�[�h</param>
		/// <param name="partySalesSlipNumSearchMode">�����`�Ԃ̌������[�h(0:���S��v,1:�O����v)</param>
		/// <param name="stockSlipList">�d���f�[�^���X�g</param>
		/// <returns>STATUS</returns>
		private int ReadStockSlip( string enterpriseCode, int supplierFormal, string sectionCode, string partySalesSlipNum, DateTime targetDate,int supplierCd, int partySalesSlipNumSearchMode, out List<StockSlip> stockSlipList )
		{
			StockSlipWork paraStockSlipWork = new StockSlipWork();
			paraStockSlipWork.EnterpriseCode = enterpriseCode;
			paraStockSlipWork.SupplierFormal = supplierFormal;
			paraStockSlipWork.StockSectionCd= sectionCode;
            paraStockSlipWork.SupplierCd = supplierCd;
			paraStockSlipWork.PartySaleSlipNum = partySalesSlipNum;

			if (supplierFormal == 0)
			{
				paraStockSlipWork.StockDate = targetDate;
			}
			else
			{
				paraStockSlipWork.ArrivalGoodsDay = targetDate;
			}
			return this.ReadStockSlipProc(paraStockSlipWork, partySalesSlipNumSearchMode, out stockSlipList);
		}

		/// <summary>
		/// �d���f�[�^���������܂��B
		/// </summary>
		/// <param name="stockSlipWork">�����p�����[�^(�d�����[�N�I�u�W�F�N�g)</param>
        /// <param name="readMode">�����`�Ԃ̌������[�h</param>
		/// <param name="stockSlipList">�d���f�[�^���X�g</param>
		/// <returns>STATUS</returns>
		private int ReadStockSlipProc( StockSlipWork stockSlipWork, int readMode, out List<StockSlip> stockSlipList )
		{
			stockSlipList = null;
            CustomSerializeArrayList retList = new CustomSerializeArrayList();

            object retObj = (object)retList;
			object paraObj;

			paraObj = (object)stockSlipWork;

            if (this._iStockSlipDB == null) this._iStockSlipDB = (IStockSlipDB)MediationStockSlipDB.GetStockSlipDB();
            int status = this._iStockSlipDB.SearchPartySaleSlipNum(ref retObj, paraObj, readMode);

			if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				CustomSerializeArrayList retCustomSerializeArrayList = (CustomSerializeArrayList)retObj;

				stockSlipList = new List<StockSlip>();
				for (int i = 0; i < retCustomSerializeArrayList.Count; i++)
				{
					if (retCustomSerializeArrayList[i] is StockSlipWork)
					{
						stockSlipList.Add(ConvertStockSlip.UIDataFromParamData((StockSlipWork)retCustomSerializeArrayList[i]));
					}
				}
			}
			return status;
		}

		# endregion

		// ===================================================================================== //
		// �p�u���b�N���\�b�h
		// ===================================================================================== //
		# region ��Public Methods

		#region �`�F�b�N�����֘A
		/// <summary>
		/// �ۑ��p�f�[�^�̃`�F�b�N���s���܂��B
		/// </summary>
		/// <param name="mainMessage">���b�Z�[�W�iout�j</param>
		/// <param name="itemNameList">���ږ��̃��X�g</param>
		/// <param name="itemList">���ڃ��X�g</param>
        /// <param name="errorRowNoList">�G���[�s�ԍ����X�g</param>
        /// <returns>true:�ۑ��� false:�ۑ��s��</returns>
        /// <remarks>
        /// <br>Update Note : 2012/06/15 tianjw</br>
        /// <br>�Ǘ��ԍ�    : 10801804-00 2012/07/25�z�M��</br>
        /// <br>              Redmine#30517 �i�������͍s�̕s��̑Ή�</br>
        /// <br>Update Note : 2015/03/25 �����M</br>
        /// <br>�Ǘ��ԍ�    : 11175104-00</br>
        /// <br>              Redmine#45073 �{�c�����ԏ���@�d���`�[���͂Ŏd���`�[�ԍ����󔒂̃f�[�^���쐬�����̕s��̑Ή�</br>
        /// </remarks>
		public bool CheckSaveData( out string mainMessage, out List<string> itemNameList, out List<string> itemList,out List<int> errorRowNoList )
		{
            mainMessage = string.Empty;
			itemNameList = new List<string>();
			itemList = new List<string>();
            errorRowNoList = new List<int>();
            bool insufficiency = false;
			bool overFlow = false;
			bool stockCountError = false;
			bool noConfirmed = false;
			bool shipmentCountError = false;
			bool customerUnmatch = false;
			bool salesDateError = false;
			bool shipmentDayError = false;
            bool dishonestValue = false;

			DateTime targetDate;
			if (this.StockSlip.SupplierFormal == 0)
			{
				targetDate = this.StockSlip.StockDate;
			}
			else
			{
				targetDate = this.StockSlip.ArrivalGoodsDay;
			}

            if (string.IsNullOrEmpty(this.StockSlip.StockSectionCd.Trim()))
            {
                itemNameList.Add("���_");
                itemList.Add("StockSectionCd");
                insufficiency = true;
            }
			if (string.IsNullOrEmpty(this.StockSlip.StockAgentCode.Trim()))
			{
				itemNameList.Add("�S����");
				itemList.Add("StockAgentCode");
				insufficiency = true;
			}

            //if (string.IsNullOrEmpty(this.StockSlip.PartySaleSlipNum))// DEL �����M 2015/03/25 Redmine#45073 �{�c�����ԏ��� �d���`�[���͂Ŏd���`�[�ԍ����󔒂̃f�[�^���쐬�����̕s��̑Ή�
            if (string.IsNullOrEmpty(this.StockSlip.PartySaleSlipNum.Trim()))// ADD �����M 2015/03/25 Redmine#45073 �{�c�����ԏ��� �d���`�[���͂Ŏd���`�[�ԍ����󔒂̃f�[�^���쐬�����̕s��̑Ή�
			{
				itemNameList.Add("�`�[�ԍ�");
                itemList.Add("PartySaleSlipNum");
				insufficiency = true;
			}

			if (this.StockSlip.SupplierCd == 0)
			{
				itemNameList.Add("�d����");
				itemList.Add("SupplierCd");
				insufficiency = true;
			}


			if (this.StockSlip.ArrivalGoodsDay == DateTime.MinValue)
			{
				itemNameList.Add("���ד�");
				itemList.Add("ArrivalGoodsDay");
				insufficiency = true;
			}

			if (this.StockSlip.SupplierFormal == 0)
			{
				if ( this.StockSlip.StockDate == DateTime.MinValue )
				{
					itemNameList.Add("�d����");
					itemList.Add("StockAddUpDate");
					insufficiency = true;
				}
				else if (this.StockSlip.StockDate < this.StockSlip.ArrivalGoodsDay)
				{
					itemNameList.Add("�d���������ד����O�ɂȂ��Ă��܂��B");
					itemList.Add("StockDate");
                    dishonestValue = true;
				}
			}

			if (!this.ExistStockDetailData())
			{
                // 2009.06.17 >>>
                if (this.StockSlip.StockGoodsCd == 6)
                {
                    itemNameList.Add("�d�����z");
                    itemList.Add("StockTotalPrice");
                }
                else
                {
                    itemNameList.Add("�d������");
                    itemList.Add("StockDetail");
                }
                // 2009.06.17 <<<
                insufficiency = true;
			}

			foreach (StockInputDataSet.StockDetailRow row in this._stockDetailDataTable)
			{
				// ���͍ςݍs�ɑ΂��Ẵ`�F�b�N
                //if (this.ExistStockDetailInput(row)) // DEL 2012/06/19 tianjw Redmine#30517
                if (this.ExistStockDetailInput(row) || row.StockSlipCdDtl == 2) // ADD 2012/06/19 tianjw Redmine#30517
				{
                    if (( row.StockGoodsCd == 0 ) || ( row.StockGoodsCd == 1 ))
                    {
                        //if (string.IsNullOrEmpty(row.GoodsName)) // DEL 2012/07/11 tianjw Redmine#30517
                        if (string.IsNullOrEmpty(row.GoodsName.Trim())) // ADD 2012/07/11 tianjw Redmine#30517
                        {
                            itemNameList.Add("�i��");
                            itemList.Add(string.Format("{0},{1}", this._stockDetailDataTable.TableName, this._stockDetailDataTable.GoodsNameColumn.ColumnName));
                            if (!errorRowNoList.Contains(row.StockRowNo)) errorRowNoList.Add(row.StockRowNo);
                            insufficiency = true;
                        }

                        // �d���`�[
                        if (( row.StockSlipCdDtl != 2 ) || ( ( row.StockSlipCdDtl == 2 )&&(row.StockCountDisplay != 0) ))
                        {
                            if (row.StockCountDisplay == 0)
                            {

                                // ----------ADD 2013/01/07----------->>>>>
                                // �X�V�� �P�� �� 0 AND ���z �� 0 �̏ꍇ�A�G���[�ɂ��Ȃ�
                                if (row.StockSlipDtlNum != 0 &&
                                    row.StockUnitPriceDisplay == 0 && 
                                    row.StockPriceDisplay != 0 )
                                {
                                    // �`�F�b�NOK
                                }
                                else
                                {
                                // ----------ADD 2013/01/07-----------<<<<<

                                    itemNameList.Add("����");
                                    itemList.Add(string.Format("{0},{1}", this._stockDetailDataTable.TableName, this._stockDetailDataTable.StockCountDisplayColumn.ColumnName));
                                    //itemList.Add("StockDetail,StockCountDisplay");
                                    if (!errorRowNoList.Contains(row.StockRowNo)) errorRowNoList.Add(row.StockRowNo);
                                    insufficiency = true;

                                } // ADD 2013/01/07
                            }
                            // ----- ADD 2010/05/04 ------------------>>>>>
                            else if (MyOpeCtrl.Disabled((int)OperationCode.QuantityMinus) && row.StockCountDisplay < 0)
                            {
                                itemNameList.Add(string.Format("{0}�s�ڂ̐��ʂ��}�C�i�X�ł��B", row.StockRowNo));
                                itemList.Add(string.Format("{0},{1}", this._stockDetailDataTable.TableName, this._stockDetailDataTable.StockCountDisplayColumn.ColumnName));
                                if (!errorRowNoList.Contains(row.StockRowNo)) errorRowNoList.Add(row.StockRowNo);
                                dishonestValue = true;
                            }
                            // ----- ADD 2010/05/04 ------------------<<<<<
                            if (Math.Abs(row.StockCount) > ctMAXVALUE_StockCountDetail)
                            {
                                itemNameList.Add(string.Format("{0}�s�̐��ʂ�{1:###,##0.00}�`{2:###,##0.00}�ɂ��ĉ������B", row.StockRowNo, ctMAXVALUE_StockCountDetail, ctMAXVALUE_StockCountDetail * -1));
                                itemList.Add(string.Format("{0},{1}", this._stockDetailDataTable.TableName, this._stockDetailDataTable.StockCountDisplayColumn.ColumnName));
                                //itemList.Add("StockDetail,StockCountDisplay");
                                if (!errorRowNoList.Contains(row.StockRowNo)) errorRowNoList.Add(row.StockRowNo);
                                overFlow = true;
                            }
                            // �P���`�F�b�N
                            if (Math.Abs(row.StockUnitPriceDisplay) > ctMAXVALUE_StockUnitPrice)
                            {
                                itemNameList.Add(string.Format("{0}�s�ڂ̒P����{1:###,##0.00}�𒴂��Ă��܂��B", row.StockRowNo, ctMAXVALUE_StockUnitPrice));
                                itemList.Add(string.Format("{0},{1}", this._stockDetailDataTable.TableName, this._stockDetailDataTable.StockUnitPriceDisplayColumn.ColumnName));
                                //itemList.Add("StockDetail,StockUnitPriceDisplay");
                                if (!errorRowNoList.Contains(row.StockRowNo)) errorRowNoList.Add(row.StockRowNo);
                                overFlow = true;
                            }

                            // ���׋��z�`�F�b�N
                            if (Math.Abs(row.StockPriceDisplay) > ctMAXVALUE_StockPriceDetail)
                            {
                                itemNameList.Add(string.Format("{0}�s�ڂ̋��z��{1:###,##0.00}�`{2:###,##0.00}���ɂ��ĉ������B", row.StockRowNo, ctMAXVALUE_StockPriceDetail, ctMAXVALUE_StockPriceDetail * -1));
                                itemList.Add(string.Format("{0},{1}", this._stockDetailDataTable.TableName, this._stockDetailDataTable.StockPriceDisplayColumn.ColumnName));
                                //itemList.Add("StockDetail,StockPriceDisplay");
                                if (!errorRowNoList.Contains(row.StockRowNo)) errorRowNoList.Add(row.StockRowNo);
                                overFlow = true;
                            }
                        }
                    }
				}
			}
            errorRowNoList.Sort();

			if (itemNameList.Count > 0)
			{
				if (insufficiency)
				{
					mainMessage = "�����͂̍���";
				}

                if (dishonestValue)
                {
                    if (!string.IsNullOrEmpty(mainMessage)) mainMessage += "�A";
                    mainMessage += "�s���Ȓl";
                }

				if (overFlow)
				{
					if (!string.IsNullOrEmpty(mainMessage)) mainMessage += "�A";
					mainMessage += "�L�������𒴂��鍀��";
				}

				if (stockCountError)
				{
					if (!string.IsNullOrEmpty(mainMessage)) mainMessage += "�A";
					mainMessage += "���ʂ����݌ɂ����鏤�i";
				}
				if (shipmentCountError)
				{
					if (!string.IsNullOrEmpty(mainMessage)) mainMessage += "�A";
					mainMessage += "���ʂ���������̐��ʂ������s";
				}
				if (noConfirmed)
				{
					if (!string.IsNullOrEmpty(mainMessage)) mainMessage += "�A";
					mainMessage += "���㖾�ׂ��m�F���Ă��Ȃ��s";
				}
				if (customerUnmatch)
				{
					if (!string.IsNullOrEmpty(mainMessage)) mainMessage += "�A";
					mainMessage += "���Ӑ悪�قȂ�s";
				}
				if (shipmentDayError)
				{
					if (!string.IsNullOrEmpty(mainMessage)) mainMessage += "�A";
					mainMessage += "������̏o�ד��̓��͂Ɍ�肪����s";
				}
				if (salesDateError)
				{
					if (!string.IsNullOrEmpty(mainMessage)) mainMessage += "�A";
					mainMessage += "������̔�����̓��͂Ɍ�肪����s";
				}

				mainMessage += "�����݂��邽�߁A�o�^�ł��܂���B" + "\r\n" + "\r\n";
				return false;
			}
			else if (this.StockSlip.StockTotalPrice > ctMAXVALUE_StockPrice)
			{
				mainMessage = string.Format("�d�����z���v��{0:###,##0}�𒴂��Ă���ׁA�o�^�ł��܂���B", ctMAXVALUE_StockPrice) + "\r\n" + "\r\n";
				itemNameList.Add("�d�����z");
				itemList.Add("StockDetail");
				return false;
			}
			if (this.StockSlip.SupplierFormal == 0)
            {
				string retMessage;
				bool isAddUp = this.CheckAddUp(this.StockSlip, 0, out retMessage);

				if (isAddUp)
				{
					itemList.Add("StockAddUpDate");
					mainMessage = retMessage;
					return false;
				}

                if (( this.StockSlip.SupplierSlipNo != 0 ) && ( this._stockSlipDBData != null ))
                {
                    isAddUp = this.CheckAddUp(this._stockSlipDBData, 2, out retMessage);

                    if (isAddUp)
                    {
                        itemList.Add("StockAddUpDate");
                        mainMessage = retMessage;
                        return false;
                    }
                }
                else if (( this.StockSlip.DebitNoteDiv == 1 ) && ( this._stockSlipDBData != null ))
                {
                    isAddUp = this.CheckAddUp(this._stockSlipDBData, 3, out retMessage);

                    if (isAddUp)
                    {
                        itemList.Add("StockAddUpDate");
                        mainMessage = retMessage;
                        return false;
                    }
                }
			}

            if (this.StockSlip.DebitNoteDiv != 1)
            {
                string retMessage;
                bool isDuplicateRet = this.CheckPartySaleSlipNumDuplicate(this.StockSlip.SupplierFormal, this.StockSlip.StockSectionCd, this.StockSlip.PartySaleSlipNum, targetDate, this.StockSlip.SupplierSlipNo, this.StockSlip.SupplierCd, out retMessage);

                if (!isDuplicateRet)
                {
                    mainMessage = retMessage;
                    //itemNameList.Add("�`�[�ԍ�");
                    itemList.Add("PartySaleSlipNum");
                    return false;
                }
            }

			return true;
		}

		/// <summary>
		/// �Y������d���`�[�����ߍς݂��ǂ������`�F�b�N���܂��B
		/// </summary>
		/// <param name="stockSlip">�d���`�[�I�u�W�F�N�g</param>
		/// <param name="mode">0:�o�^�����[�h 1:�ďo�����[�h</param>
		/// <param name="message">���b�Z�[�W</param>
		/// <returns>true:���ߍς� false:������</returns>
		public bool CheckAddUp(StockSlip stockSlip, int mode, out string message)
		{
            message = string.Empty;
			if (stockSlip.SupplierFormal == 0)
            {
                DateTime prevTotalDay;

                if (!this.CheckPayment(stockSlip.PayeeCode, stockSlip.StockAddUpADate, out prevTotalDay))
				{
					if (mode == 0)
					{
                        message = "�v������O��x�������ȑO�ɂȂ��Ă���ׁA�o�^�ł��܂���B" + Environment.NewLine + Environment.NewLine +
                            string.Format("�@�O��x������ �F {0}", prevTotalDay.ToString("yyyy�NMM��dd��")) + Environment.NewLine + Environment.NewLine +
                            "���v����́A�x����m�F���ύX���\�ł��B"; 
					}
                    else if (mode == 2)
                    {
                        message = "�C���O�̓`�[�������W�v�����ςׁ݂̈A�o�^�ł��܂���B" + Environment.NewLine + Environment.NewLine +
                            string.Format("�@�C���O�v��� �F {0}", stockSlip.StockAddUpADate.ToString("yyyy�NMM��dd��")) + Environment.NewLine +
                            string.Format("�@�O��x������ �F {0}", prevTotalDay.ToString("yyyy�NMM��dd��"));
                    }
                    else if (mode == 3)
                    {
                        message = "���`�[�������W�v�����ςׁ݂̈A�o�^�ł��܂���B" + Environment.NewLine + Environment.NewLine +
                            string.Format("�@���`�[�v��� �F {0}", stockSlip.StockAddUpADate.ToString("yyyy�NMM��dd��")) + Environment.NewLine +
                            string.Format("�@�O��x������ �F {0}", prevTotalDay.ToString("yyyy�NMM��dd��"));
                    }
                    else
					{
                        message = "�v������O��x�������ȑO�ɂȂ��Ă���ׁA�ҏW�ł��܂���B" + Environment.NewLine + Environment.NewLine +
                            string.Format("�@�O��x������ �F {0}", prevTotalDay.ToString("yyyy�NMM��dd��")) + Environment.NewLine + Environment.NewLine +
                            "���v����́A�x����m�F���ύX���\�ł��B";
					}
					return true;
				}

                if (!this.CheckMonthlyAccPayment(stockSlip.PayeeCode, stockSlip.StockAddUpADate, out prevTotalDay))
                {
                    if (mode == 0)
                    {
                        message = "�v������O�񌎎��X�V���ȑO�ɂȂ��Ă���ׁA�o�^�ł��܂���B" + Environment.NewLine + Environment.NewLine +
                            string.Format("�@�O�񌎎��X�V�� �F {0}", prevTotalDay.ToString("yyyy�NMM��dd��")) + Environment.NewLine + Environment.NewLine +
                            "���v����́A�x����m�F���ύX���\�ł��B";
                    }
                    else if (mode == 2)
                    {
                        message = "�C���O�̓`�[�������X�V�����ςׁ݂̈A�o�^�ł��܂���B" + Environment.NewLine + Environment.NewLine +
                            string.Format("�@�C���O�v��� �@�F {0}", stockSlip.StockAddUpADate.ToString("yyyy�NMM��dd��")) + Environment.NewLine +
                            string.Format("�@�O�񌎎��X�V�� �F {0}", prevTotalDay.ToString("yyyy�NMM��dd��"));
                    }
                    else if (mode == 3)
                    {
                        message = "���`�[�������X�V�����ςׁ݂̈A�o�^�ł��܂���B" + Environment.NewLine + Environment.NewLine +
                            string.Format("�@���`�[�v��� �@�F {0}", stockSlip.StockAddUpADate.ToString("yyyy�NMM��dd��")) + Environment.NewLine +
                            string.Format("�@�O�񌎎��X�V�� �F {0}", prevTotalDay.ToString("yyyy�NMM��dd��"));
                    }
                    else
                    {
                        message = "�v������O�񌎎��X�V���ȑO�ɂȂ��Ă���ׁA�ҏW�ł��܂���B" + Environment.NewLine + Environment.NewLine +
                            string.Format("�@�O�񌎎��X�V�� �F {0}", prevTotalDay.ToString("yyyy�NMM��dd��")) + Environment.NewLine + Environment.NewLine +
                            "���v����́A�x����m�F���ύX���\�ł��B";
                    }
                    return true;
                }
            }

			return false;
		}

		/// <summary>
		/// �Ώۓ����d�������X�V�ς݂��`�F�b�N���܂��B
		/// </summary>
        /// <param name="supplierCd">�x����</param>
        /// <param name="stockAddUpDate">�v���</param>
        /// <param name="prevTotalDay">�O�����</param>
        /// <returns>true:OK false:NG</returns>
		public bool CheckPayment(int supplierCd, DateTime stockAddUpDate,out DateTime prevTotalDay)
		{
            if (_totalDayCalculator == null) this._totalDayCalculator = TotalDayCalculator.GetInstance();

            return !this._totalDayCalculator.CheckPayment(supplierCd, stockAddUpDate, out prevTotalDay);
		}

		/// <summary>
		/// �Ώۓ����d�������X�V�ς݂��`�F�b�N���܂��B
		/// </summary>
        /// <param name="supplierCd">�x����</param>
        /// <param name="stockAddUpDate">�v���</param>
        /// <param name="prevTotalDay">�O�񌎎��X�V��</param>
		/// <returns>true:OK false:NG</returns>
        public bool CheckMonthlyAccPayment(int supplierCd, DateTime stockAddUpDate, out DateTime prevTotalDay)
		{
            if (_totalDayCalculator == null) this._totalDayCalculator = TotalDayCalculator.GetInstance();

            return !this._totalDayCalculator.CheckMonthlyAccPay(supplierCd, stockAddUpDate, out prevTotalDay);
		}

        /// <summary>
        /// �d���`�[�ԍ��̏d���`�F�b�N
        /// </summary>
        /// <returns>False:�d��</returns>
        public bool CheckPartySaleSlipNumDuplicate( int supplierFormal, string sectionCode, string partySalesSlipNum, DateTime targetDate,int supplierSlipNo, int supplierCd, out string message )
        {
            message = string.Empty;
            bool ret = true;
            List<StockSlip> stockSlipList;

            int status = this.ReadStockSlip(this._enterpriseCode, supplierFormal, sectionCode, partySalesSlipNum, targetDate, supplierCd, 0, out stockSlipList);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (stockSlipList.Count > 0)
                {
                    if (supplierSlipNo == 0)
                    {
                        message = "���̓`�[�ԍ��͊��ɓo�^����Ă��܂��B" + Environment.NewLine + string.Format("�d��SEQ�ԍ��F{0:D9}", stockSlipList[0].SupplierSlipNo);
                        return false;
                    }
                    else
                    {
                        foreach (StockSlip stockslip in stockSlipList)
                        {
                            if (stockslip.SupplierSlipNo != supplierSlipNo)
                            {
                                message = "���̓`�[�ԍ��͊��ɓo�^����Ă��܂��B" + Environment.NewLine + string.Format("�d��SEQ�ԍ��F{0:D9}", stockslip.SupplierSlipNo);
                                return false;
                            }
                        }
                    }
                }
            }
            return ret;
        }

		/// <summary>
		/// �d���f�[�^�̍폜�`�F�b�N���s���܂��B
		/// </summary>
		/// <param name="stockSlip">�d���f�[�^�I�u�W�F�N�g</param>
		/// <param name="mainMessage">���C�����b�Z�[�W�iout�j</param>
		/// <param name="itemNameList">���ږ��̃��X�g�iout�j</param>
		/// <param name="itemList">���ڃ��X�g�iout�j</param>
		/// <returns>true:�폜�� false:�폜�s��</returns>
		public bool CheckDeleteData( StockSlip stockSlip, out string mainMessage, out List<string> itemNameList, out List<string> itemList )
		{
			itemList = new List<string>();
			itemNameList = new List<string>();
			mainMessage = string.Empty;
			bool canDelete = true;

			if (canDelete)
			{
				// �ԓ`�敪�u0:���`�v
				if (stockSlip.DebitNoteDiv == 0)
				{
					foreach (StockInputDataSet.StockDetailRow row in this._stockDetailDataTable)
					{
						if (( row.EditStatus == ctEDITSTATUS_AllReadOnly ) || ( row.EditStatus == ctEDITSTATUS_AllDisable ))
						{
							mainMessage = "�ҏW�s�\�Ȗ��׍s�����݂���ׁA�폜�ł��܂���B";
							canDelete = false;
							break;
						}
						else if (row.StockCountMin != 0)
						{
							mainMessage = "�ԕi�������͌v��`�[�����͂���Ă���ׁA�폜�ł��܂���B";
							canDelete = false;
							break;
						}
					}
				}
				// �ԓ`�敪�u1:�ԓ`�v
				else if (stockSlip.DebitNoteDiv == 1)
				{
				}
				// �ԓ`�敪�u2:�����v
				else if (stockSlip.DebitNoteDiv == 2)
				{
					mainMessage = "�Y������d���f�[�^�́u�����`�[�v�ׁ̈A�폜�ł��܂���B";
					canDelete = false;
				}
			}

			return canDelete;
		}

        /// <summary>
        /// �����`�F�b�N
        /// </summary>
        /// <param name="stockRowNo">�s�ԍ�</param>
        /// <param name="checkType">����^�C�v�i0:�d���P���A1:�d�����j</param>
        /// <param name="message">�G���[���b�Z�[�W</param>
        /// <returns>���茋��</returns>
        public CheckResult StockUnitPriceCheck( int stockRowNo,int checkType, out string message )
        {
            CheckResult checkReslt = CheckResult.Ok;

            message = string.Empty;

            // �艿<�����`�F�b�N�p
            string unPrcOvrChkMsg = string.Empty;
            CheckResult unPrcOvrChkRes = CheckResult.Ok;
            // �P���ύX�`�F�b�N�p
            string unPrcChgChkMsg = string.Empty;
            CheckResult unPrcChgChkRes = CheckResult.Ok;


            StockInputDataSet.StockDetailRow row = this.GetStockDetailRow(stockRowNo);

            if (row != null)
            {
                double stockUnitPriceDisplay = row.StockUnitPriceDisplay;

                if (checkType == 1)
                {
                    double stockUnitPriceTaxExc;
                    double stockUnitPriceTaxInc;
                    double fracProcUnitStcUnPrc = row.FracProcUnitStcUnPrc;
                    int fracProcStckUnPrc = row.FracProcStckUnPrc;

                    this.CalculateStockUnitPriceByRate(row, out stockUnitPriceTaxExc, out stockUnitPriceTaxInc, out stockUnitPriceDisplay, ref fracProcUnitStcUnPrc, ref fracProcStckUnPrc);
                }

                // �艿�������`�F�b�N
                unPrcOvrChkRes = this.UnitPriceOverCheck(row.ListPriceDisplay, stockUnitPriceDisplay, out unPrcOvrChkMsg);

                // �P���ύX�`�F�b�N
                unPrcChgChkRes = this.UnitPriceChangeCheck(stockUnitPriceDisplay, row.BfStockUnitPriceFl, row.RateDivStckUnPrc, row.TaxationCode, out unPrcChgChkMsg);

                // �P���ύX�G���[
                if (unPrcChgChkRes == CheckResult.Error)
                {
                    message = unPrcChgChkMsg;
                    return unPrcChgChkRes;
                }
                // �P�����艿�G���[
                else if (unPrcOvrChkRes == CheckResult.Error)
                {
                    message = unPrcOvrChkMsg;
                    return unPrcOvrChkRes;
                }
                // �P�����艿�x��
                else if (unPrcOvrChkRes == CheckResult.Warning)
                {
                    message = unPrcOvrChkMsg;
                    return unPrcOvrChkRes;
                }
                // �P���ύX�x��
                else if (unPrcChgChkRes == CheckResult.Warning)
                {
                    message = unPrcChgChkMsg;
                    return unPrcChgChkRes;
                }
                else
                {
                    // �d�����z�`�F�b�N
                    string stockPrcOvrChkMsg;
                    CheckResult stockPrcOvrChkRes = this.StockPriceOverFlowCheck(row.StockCount, stockUnitPriceDisplay, row.TaxationCode, out stockPrcOvrChkMsg);
                    if (stockPrcOvrChkRes == CheckResult.Error)
                    {
                        message = stockPrcOvrChkMsg;
                        return stockPrcOvrChkRes;
                    }
                }
            }

            return checkReslt;
        }

        /// <summary>
        /// �艿�`�F�b�N
        /// </summary>
        /// <param name="stockRowNo">�s�ԍ�</param>
        /// <param name="message">�G���[���b�Z�[�W</param>
        /// <returns>���茋��</returns>
        public CheckResult ListPriceCheck( int stockRowNo, out string message )
        {
            CheckResult checkReslt = CheckResult.Ok;

            message = string.Empty;

            string unPrcOvrChkMsg = string.Empty;
            CheckResult unPrcOvrChkRes = CheckResult.Ok;

            StockInputDataSet.StockDetailRow row = this.GetStockDetailRow(stockRowNo);

            if (row != null)
            {
                // �艿�������`�F�b�N
                unPrcOvrChkMsg = string.Empty;
                unPrcOvrChkRes = this.UnitPriceOverCheck(row.ListPriceDisplay,row.StockUnitPriceDisplay, out unPrcOvrChkMsg);

                if (( unPrcOvrChkRes == CheckResult.Error ) || ( ( unPrcOvrChkRes == CheckResult.Warning ) ))
                {
                    message = unPrcOvrChkMsg;
                    return unPrcOvrChkRes;
                }
                else
                {
                    // �d�����z�`�F�b�N
                    string stockPrcOvrChkMsg;
                    CheckResult stockPrcOvrChkRes = this.StockPriceOverFlowCheck(row.StockCount, row.StockUnitPriceDisplay, row.TaxationCode, out stockPrcOvrChkMsg);
                    if (stockPrcOvrChkRes == CheckResult.Error)
                    {
                        message = stockPrcOvrChkMsg;
                        return stockPrcOvrChkRes;
                    }
                }
            }

            return checkReslt;
        }

        /// <summary>
        /// ���ʃ`�F�b�N
        /// </summary>
        /// <param name="stockRowNo"></param>
        /// <param name="message"></param>
        /// <param name="wbeforeStockCount"></param>                                                        // ADD 2013/01/07
        /// <returns></returns>
        //public CheckResult StockCountCheck( int stockRowNo, out string message )                          // DEL 2013/01/07
        public CheckResult StockCountCheck(int stockRowNo, out string message, double wbeforeStockCount)    // ADD 2013/01/07
        {
            CheckResult checkReslt = CheckResult.Ok;

            message = string.Empty;

            StockInputDataSet.StockDetailRow row = this.GetStockDetailRow(stockRowNo);
            if (row != null)
            {
                // ���ʃ`�F�b�N�p
                string stkCntBscChkMsg = string.Empty;
                CheckResult stkCntBscChkRes = CheckResult.Ok;

                // ���ʃ`�F�b�N
                //stkCntBscChkRes = this.StockCountBasicCheck(row, out stkCntBscChkMsg);                    // DEL 2013/01/07 
                stkCntBscChkRes = this.StockCountBasicCheck(row, out stkCntBscChkMsg, wbeforeStockCount);   // ADD 2013/01/07

                if (stkCntBscChkRes != CheckResult.Ok)
                {
                    message = stkCntBscChkMsg;
                    return stkCntBscChkRes;
                }

                // �d�����z�`�F�b�N
                string stockPrcOvrChkMsg;
                CheckResult stockPrcOvrChkRes = this.StockPriceOverFlowCheck(row.StockCountDisplay, row.StockUnitPriceDisplay, row.TaxationCode, out stockPrcOvrChkMsg);
                if (stockPrcOvrChkRes == CheckResult.Error)
                {
                    message = stockPrcOvrChkMsg;
                    return stockPrcOvrChkRes;
                }

                // �d�����z�����`�F�b�N
                string stockPriceSignChkMsg;
                CheckResult stockPriceSignChkRes = this.StockPriceSignChk(row, this._stockDetailDataTable.StockCountDisplayColumn.ColumnName, out stockPriceSignChkMsg);
                if (stockPriceSignChkRes != CheckResult.Ok)
                {
                    if (!string.IsNullOrEmpty(message))
                    {
                        message += Environment.NewLine;
                    }
                    message += stockPriceSignChkMsg;

                    return stockPriceSignChkRes;
                }
            }
            return checkReslt;
        }


        /// <summary>
        /// �艿�E�P���`�F�b�N�i�d���݌ɑS�̐ݒ�}�X�^�̒艿�`�F�b�N�敪���Q��)
        /// </summary>
        /// <param name="listPriceDisplay">�\���艿</param>
        /// <param name="stockUnitPriceDisplay">�\���P��</param>
        /// <param name="message">���b�Z�[�W</param>
        /// <returns>���茋��</returns>
        private CheckResult UnitPriceOverCheck( double listPriceDisplay, double stockUnitPriceDisplay, out string message )
        {
            message = string.Empty;

            if (listPriceDisplay == 0) return CheckResult.Ok;

            CheckResult checkReturn = CheckResult.Ok;

            // �艿�`�F�b�N�敪�ɂ��艿�E�P���`�F�b�N
            switch (this._stockSlipInputInitDataAcs.GetStockTtlSt().PriceCheckDivCd)
            {
                // ����
                case 0:
                    {
                        break;
                    }
                // �x��+�ē���
                case 1:
                    {
                        checkReturn = CheckResult.Error;
                        break;
                    }
                // �x��
                case 2:
                    {
                        checkReturn = CheckResult.Warning;
                        break;
                    }
            }

            // �`�F�b�N�������A�艿�������ł����OK
            if (( checkReturn == CheckResult.Ok ) || ( listPriceDisplay >= stockUnitPriceDisplay ))
            {
                checkReturn = CheckResult.Ok;
            }

            message = ( checkReturn == CheckResult.Ok ) ? string.Empty : string.Format("{0}��{1}�𒴂��Ă��܂��B", this._stockDetailDataTable.StockUnitPriceDisplayColumn.Caption, this._stockDetailDataTable.ListPriceDisplayColumn.Caption);

            return checkReturn;
        }

        /// <summary>
        /// �P���ύX�`�F�b�N�i�d���݌ɑS�̐ݒ�}�X�^�̒P���`�F�b�N�敪���Q��)
        /// </summary>
        /// <param name="bfStockUnitPriceFl">�ύX�O�P��</param>
        /// <param name="stockUnitPriceDisplay">�\���P��</param>
        /// <param name="rateDivStckUnPrc">�|���ݒ�敪�i�d���P���j</param>
        /// <param name="taxationCode">�ېŕ���</param>
        /// <param name="message">���b�Z�[�W</param>
        /// <returns>���茋��</returns>
        private CheckResult UnitPriceChangeCheck( double stockUnitPriceDisplay, double bfStockUnitPriceFl, string rateDivStckUnPrc, int taxationCode, out string message )
        {
            message = string.Empty;

            // �ύX�O�P�����[���A�|���ݒ�敪���󔒂łȂ���΃`�F�b�N���Ȃ�
            if (( bfStockUnitPriceFl == 0 ) || ( !string.IsNullOrEmpty(rateDivStckUnPrc.Trim()) )) return CheckResult.Ok;

            CheckResult checkReturn = CheckResult.Ok;

            // �艿�`�F�b�N�敪�ɂ��艿�E�P���`�F�b�N
            switch (this._stockSlipInputInitDataAcs.GetStockTtlSt().StockUnitChgDivCd)
            {
                // ����
                case 0:
                    {
                        break;
                    }
                // �x��+�ē���
                case 1:
                    {
                        checkReturn = CheckResult.Error;
                        break;
                    }
                // �x��
                case 2:
                    {
                        checkReturn = CheckResult.Warning;
                        break;
                    }
            }

            if (checkReturn != CheckResult.Ok)
            {
                // �\���P������A�Ŕ����P�����Z�o����
                if (this._supplierAcs == null) this._supplierAcs = new SupplierAcs();
                int stockTaxFrcProcCd = this._supplierAcs.GetStockFractionProcCd(this._enterpriseCode, this._stockSlip.SupplierCd, SupplierAcs.StockFracProcMoneyDiv.CnsTaxFrcProcCd);		// �d������Œ[�������R�[�h
                double unitPriceTaxExc;
                double unitPriceTaxInc;
                double unitPriceDisplay;

                this.CalculatePrice(PriceInputType.PriceDisplay, stockUnitPriceDisplay, taxationCode, this._stockSlip.SuppTtlAmntDspWayCd, this._stockSlip.SuppCTaxLayCd, this._stockSlip.SupplierConsTaxRate, stockTaxFrcProcCd, out unitPriceTaxExc, out unitPriceTaxInc, out unitPriceDisplay);

                // �u�ύX�O�P���v�Ɓu�v�Z�����\���P������v�Z�����Ŕ����P���v���r����
                if (unitPriceTaxExc == bfStockUnitPriceFl)
                {
                    checkReturn = CheckResult.Ok;
                }
                else
                {
                }
            }

            switch (checkReturn)
            {
                case CheckResult.Ok:
                    break;
                case CheckResult.Error:
                    message = string.Format("{0}�͕ύX�ł��܂���B", this._stockDetailDataTable.StockUnitPriceDisplayColumn.Caption);
                    break;
                case CheckResult.Warning:
                    message = string.Format("{0}���ύX����Ă��܂��B", this._stockDetailDataTable.StockUnitPriceDisplayColumn.Caption);
                    break;
                case CheckResult.Confirm:
                    break;
            }

            return checkReturn;
        }

        /// <summary>
        /// �d�����z�����`�F�b�N
        /// </summary>
        /// <param name="stockUnitPriceDisplay">�d���P��</param>
        /// <param name="stockCount">�d����</param>
        /// <param name="taxationCode">�ېŋ敪</param>
        /// <param name="message">���b�Z�[�W</param>
        /// <returns>���茋��</returns>
        private CheckResult StockPriceOverFlowCheck(double stockUnitPriceDisplay, double stockCount, int taxationCode, out string message)
        {
            message = string.Empty;
            // �d�����z���Z��
            long stockPriceTaxInc;
            long stockPriceTaxExc;
            long stockPriceConsTax;

            double stockUnitPrice = stockUnitPriceDisplay;

            // �]�ŕ����u��ېŁv���͐Ŕ����Ōv�Z
            if (this._stockSlip.SuppCTaxLayCd == 9)
            {
                taxationCode = (int)CalculateTax.TaxationCode.TaxNone;
            }
            // ���z�\�����͓��łŌv�Z����
            else if (( taxationCode != (int)CalculateTax.TaxationCode.TaxNone ) && ( this._stockSlip.SuppTtlAmntDspWayCd == 1 ))
                taxationCode = (int)CalculateTax.TaxationCode.TaxInc;

            this.CalculateStockPrice(stockCount, stockUnitPrice, taxationCode, out stockPriceTaxInc, out stockPriceTaxExc, out stockPriceConsTax);

            long stockPriceDisplay = ( ( taxationCode == (int)CalculateTax.TaxationCode.TaxInc ) || ( this._stockSlip.SuppTtlAmntDspWayCd == 1 ) ) ? stockPriceTaxInc : stockPriceTaxExc;

            if (Math.Abs(stockPriceDisplay) > Math.Abs(ctMAXVALUE_StockPriceDetail))
            {
                message = "�d�����z���ő包���𒴂���ׁA���͂ł��܂���B" + Environment.NewLine + string.Format("�d�����z���u{0} �` {1}�v�͈͓̔��ɂȂ�悤�ɓ��͂��ĉ������B", Math.Abs(ctMAXVALUE_StockPriceDetail) * -1, Math.Abs(ctMAXVALUE_StockPriceDetail));
                return CheckResult.Error;
            }
            return CheckResult.Ok;
        }

        /// <summary>
        /// ���ʂ̊�{�`�F�b�N
        /// </summary>
        /// <param name="row"></param>
        /// <param name="message"></param>
        /// <param name="wbeforeStockCount"></param>                                                                                   // ADD 2013/01/07
        /// <returns></returns>
        //private CheckResult StockCountBasicCheck(StockInputDataSet.StockDetailRow row,out string message)                            // DEL 2013/01/07
        private CheckResult StockCountBasicCheck(StockInputDataSet.StockDetailRow row, out string message, double wbeforeStockCount)   // ADD 2013/01/07
        {
            message = string.Empty;

            double beforeStockCount = row.StockCountDefault;
            double stockCountMax = row.StockCountMax;
            double stockCountMin = row.StockCountMin;
            double stockCount = 0;
            int sign = 1;
            double stockCountRealValue = 0; // �f�[�^�̖{���̒l

            stockCount = row.StockCountDisplay;
            stockCountRealValue = stockCount;
            if (this._stockSlip.SupplierSlipCd == 20)
            {
                stockCountRealValue *= -1;	// �ԕi���̓}�C�i�X�ň���
                sign = -1;
            }

            // �[�����̓`�F�b�N
            if (stockCount == 0)
            {
                // ----------ADD 2013/01/07----------->>>>>
                // �X�V�� �P�� �� 0 AND ���z �� 0 AND �O�񐔗� �� 0 �̏ꍇ�A�G���[�ɂ��Ȃ�
                if (row.StockSlipDtlNum != 0 &&
                    row.StockUnitPriceDisplay == 0 &&
                    row.StockPriceDisplay != 0 &&
                    wbeforeStockCount == 0 )
                {
                    // �`�F�b�NOK
                }
                else
                {

                // ----------ADD 2013/01/07-----------<<<<<

                    message="���ʂ����͂���Ă��܂���B";
                    return CheckResult.Error;

                } // ADD 2013/01/07
            }
            // ----- ADD 2010/05/04 --------------->>>>>
            else if (MyOpeCtrl.Disabled((int)OperationCode.QuantityMinus)
                && stockCount < 0)
            {
                message = "�}�C�i�X�l�̓��͂͂ł��܂���B";
                return CheckResult.Error;
            }
            // ----- ADD 2010/05/04 ---------------<<<<<
            // �����ӂ�`�F�b�N
            else if (Math.Abs(stockCount) > Math.Abs(ctMAXVALUE_StockCountDetail))
            {
                message = "���ʂ��ő包���𒴂���ׁA���͂ł��܂���B" + Environment.NewLine + Environment.NewLine + string.Format("�u{0:#,##0.00} �` {1:#,##0.00}�v�̒l����͂��ĉ������B", Math.Abs(StockSlipInputAcs.ctMAXVALUE_StockCountDetail) * -1, Math.Abs(StockSlipInputAcs.ctMAXVALUE_StockCountDetail));
                return CheckResult.Error;
            }
            // ���ד`�[�ł̃}�C�i�X�}��
            if (this._stockSlip.SupplierFormal == 1)
            {
                if (stockCount < 0)
                {
                    message = "���ד`�[�̓}�C�i�X�l����͂ł��܂���B";
                    return CheckResult.Error;
                }
            }
            // �ԕi�`�[�̃`�F�b�N
            if (this._stockSlip.SupplierSlipCd == 20)
            {
                // �v��`�[�̏ꍇ
                if (stockCountMax != 0)
                {
                    // �v�㌳���v���X���ʂ̏ꍇ�̓}�C�i�X���͕s��
                    if (( stockCountMax > 0 ) && ( stockCountRealValue < 0 ))
                    {
                        message = "�ԕi���̐��ʂ��}�C�i�X�Ȃ̂ŁA�v���X�l�͓��͂ł��܂���B";
                        return CheckResult.Error;
                    }
                    // �v�㌳���}�C�i�X���ʂ̏ꍇ�̓v���X���͕s��
                    else if (( stockCountMax < 0 ) && ( stockCountRealValue > 0 ))
                    {
                        message = "�ԕi���̐��ʂ��v���X�Ȃ̂ŁA�}�C�i�X�l�͓��͂ł��܂���B";
                        return CheckResult.Error;
                    }
                    //// ���`�L��̕ԕi�`�[�ŁA���ʂ��v���X�̏ꍇ
                    //if (( stockCountMax != 0 ) && ( stockCountRealValue > 0 ))
                    //{
                    //    message = "���`�[������ׁA�v���X�l�̓��͂͂ł��܂���B";
                    //    return CheckResult.Error;
                    //}

                }
                if (( stockCountMax != 0 ) && ( Math.Abs(stockCountMax) < Math.Abs(stockCountRealValue) ))
                {
                    int sign2 = ( stockCountMax < 0 ) ? -1 : 1;
                    message = "�ԕi�\�Ȑ��ʂ𒴂��Ă��܂��B" + Environment.NewLine + Environment.NewLine + string.Format("{0:#,##0.00} �` {1:#,##0.00} ����͂��ĉ������B", 0.01 * sign * sign2, stockCountMax * sign);
                    return CheckResult.Error;
                }
            }
            else
            {
                // �v��`�[�̏ꍇ
                if (stockCountMax != 0)
                {
                    // �v�㌳���v���X���ʂ̏ꍇ�̓}�C�i�X���͕s��
                    if (( stockCountMax > 0 ) && ( stockCountRealValue < 0 ))
                    {
                        message = "�v�㌳�̐��ʂ��v���X�Ȃ̂ŁA�}�C�i�X�l�͓��͂ł��܂���B";
                        return CheckResult.Error;
                    }
                    // �v�㌳���}�C�i�X���ʂ̏ꍇ�̓v���X���͕s��
                    else if (( stockCountMax < 0 ) && ( stockCountRealValue > 0 ))
                    {
                        message = "�v�㌳�̐��ʂ��}�C�i�X�Ȃ̂ŁA�v���X�l�͓��͂ł��܂���B";
                        return CheckResult.Error;
                    }
                }
                // �v��A�ԕi�ςݓ`�[������ꍇ
                if (stockCountMin != 0)
                {
                    if (( stockCountMin > 0 ) && ( stockCountRealValue < 0 ))
                    {
                        message = "�����ς݂Ȃ̂ŁA�}�C�i�X�l�͓��͂ł��܂���B";
                        return CheckResult.Error;
                    }
                    else if (( stockCountMin < 0 ) && ( stockCountRealValue > 0 ))
                    {
                        message = "�����ς݂Ȃ̂ŁA�v���X�l�͓��͂ł��܂���B";
                        return CheckResult.Error;
                    }
                    // �����ςݐ��ʈȉ��͓��͕s��(��Βl�Ŕ��f)
                    if (( stockCountMin != 0 ) && ( Math.Abs(stockCount) < Math.Abs(stockCountMin) ))
                    {
                        string addMsg = string.Empty;
                        if (stockCountMax == 0)
                        {
                            string flgMsg = ( stockCountMin < 0 ) ? "�ȉ�" : "�ȏ�";

                            addMsg = string.Format("{0:#,##0.00} {1}����͂��ĉ������B", stockCountMin, flgMsg);
                        }
                        else
                        {
                            addMsg = string.Format("{0:#,##0.00} �` {1:#,##0.00} ����͂��ĉ������B", stockCountMin, stockCountMax);
                        }

                        message = "���ʂ������ς݂̐��ʂ�������Ă��܂��B" + Environment.NewLine + Environment.NewLine + addMsg;
                        return CheckResult.Error;
                    }
                }
                // �v�㖾�ׂ̏ꍇ�͎c���`�F�b�N
                if (row.EditStatus == StockSlipInputAcs.ctEDITSTATUS_ArrivalAddUpNew)
                {
                    if (Math.Abs(stockCountMax) < Math.Abs(stockCount))
                    {
                        message = "���ʂ��c���ʂ𒴂��Ă��܂��B" + Environment.NewLine + Environment.NewLine + string.Format("{0:#,##0.00} �` {1:#,##0.00} ����͂��ĉ������B", ( ( stockCountMin == 0 ) ? 0.01 : stockCountMin ) * sign, stockCountMax * sign);
                        return CheckResult.Error;
                    }
                }
            }

            return CheckResult.Ok;
        }

        /// <summary>
        /// �d�����z�����`�F�b�N
        /// </summary>
        /// <param name="row"></param>
        /// <param name="colKey"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public CheckResult StockPriceSignChk(StockInputDataSet.StockDetailRow row, string colKey, out string message)
        {
            CheckResult checkReslt = CheckResult.Ok;

            message = string.Empty;
            
            // ���ʃ[���ȊO�i�s�l�����̓`�F�b�N�ΏۊO�j
            if (row.StockCountDisplay != 0)
            {
                bool isCheck = false;
                // ���ʂ���`�F�b�N����ꍇ
                if (colKey == this._stockDetailDataTable.StockCountDisplayColumn.ColumnName)
                {
                    // �P�����[���ŁA���z���[���ȊO�̏ꍇ�̂݃`�F�b�N�Ώ�
                    isCheck = ( ( row.StockUnitTaxPriceFl == 0 ) && ( row.StockUnitPriceFl == 0 ) && ( row.StockPriceTaxExc != 0 ) && ( row.StockPriceTaxInc != 0 ) );

                }
                else
                {
                    isCheck = true;
                }
                if (isCheck)
                {
                    int sign = ( this._stockSlip.SupplierSlipCd == 20 ) ? -1 : 1;

                    double stockCountRealValue = row.StockCountDisplay * sign;
                    long stockPriceRealValue = row.StockPriceDisplay * sign;

                    if (( ( stockCountRealValue > 0 ) && ( stockPriceRealValue < 0 ) ) ||
                        ( ( stockCountRealValue < 0 ) && ( stockPriceRealValue > 0 ) ))
                    {
                        if (colKey == this._stockDetailDataTable.StockCountDisplayColumn.ColumnName)
                        {
                            checkReslt = CheckResult.Confirm;
                            message = "���ʂƎd�����z�̕������قȂ�ׁA�d�����z�𒲐����܂��B";
                        }
                        else
                        {
                            checkReslt = CheckResult.Error;
                            message = ( row.StockCount * sign > 0 ) ? "���ʂ��v���X�Ȃ̂ŁA�}�C�i�X�̋��z�͓��͂ł��܂���B" : "���ʂ��}�C�i�X�Ȃ̂ŁA�v���X�̋��z�͓��͂ł��܂���B";
                        }
                    }
                }
            }
        
            return checkReslt;
        }

        /// <summary>
        /// �d�����z�`�F�b�N
        /// </summary>
        /// <param name="stockRowNo"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public CheckResult StockPriceCheck(int stockRowNo, out string message)
        {
            CheckResult checkReslt = CheckResult.Ok;

            message = string.Empty;

            StockInputDataSet.StockDetailRow row = this.GetStockDetailRow(stockRowNo);
            if (row != null)
            {
                checkReslt = this.StockPriceSignChk(row, this._stockDetailDataTable.StockPriceDisplayColumn.ColumnName, out message);
            }
            return checkReslt;
        }
        //add 2011/12/27 ���� Redmine #27374----->>>>>
        /// <summary>
        /// �ۑ��p�f�[�^�̒��ς̃`�F�b�N���s���܂��B
        /// </summary>
        /// <remarks>
        /// <param name="mainMessage">���b�Z�[�W�iout�j</param>
        /// <returns>true:�ۑ��� false:�ۑ��s��</returns>
        /// <br>Note       : �ۑ��p�f�[�^�̒��ς̃`�F�b�N</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/12/27</br>
        /// <br>�Ǘ��ԍ�   : 10707327-00 2012/01/25�z�M��</br>
        /// <br>             redmine#27374 �d���`�[����/���ς̃`�F�b�N�̑Ή�</br>
        /// </remarks>
        public bool CheckStockAddUpDate(out string mainMessage)
        {
            mainMessage = string.Empty;
            if (this.StockSlip.SupplierFormal == 0)
            {
                string retMessage;
                bool isAddUp = this.CheckAddUp(this.StockSlip, 0, out retMessage);
                if (isAddUp)
                {
                    mainMessage = retMessage;
                    return false;
                }
                if ((this.StockSlip.SupplierSlipNo != 0) && (this._stockSlipDBData != null))
                {
                    isAddUp = this.CheckAddUp(this._stockSlipDBData, 2, out retMessage);
                    if (isAddUp)
                    {
                        mainMessage = retMessage;
                        return false;
                    }
                }
                else if ((this.StockSlip.DebitNoteDiv == 1) && (this._stockSlipDBData != null))
                {
                    isAddUp = this.CheckAddUp(this._stockSlipDBData, 3, out retMessage);
                    if (isAddUp)
                    {
                        mainMessage = retMessage;
                        return false;
                    }
                }
            }
            return true;
        }
        //add 2011/12/27 ���� Redmine #27374-----<<<<<
		#endregion


        // ----  ADD 2011/07/25 ------>>>>
        /// <summary>
        /// �|���D��敪���Z�b�g���܂��B
        /// </summary>
        /// <remarks>�|���D��敪���Z�b�g���܂��B</remarks>
        public void SetUnitPriceCalculation()
        {
            if (this._stockSlipInputInitDataAcs.GetCompanyInf() != null)
            {
                this._unitPriceCalculation.RatePriorityDiv = this._stockSlipInputInitDataAcs.GetCompanyInf().RatePriorityDiv;
            }
        }
        // ----  ADD 2011/07/25 ------<<<<

		/// <summary>
		/// �d���f�[�^�̏����C���X�^���X�𐶐����܂��B
		/// </summary>
		/// <param name="supplierFormal">�d���`��</param>
		/// <param name="accPayDivCd">���|�敪</param>
		/// <param name="stockGoodsCd">���i�敪</param>
		/// <param name="keepDate">true:���t�ێ�����</param>
		public void CreateStockSlipInitialData( int supplierFormal, int accPayDivCd, int stockGoodsCd, bool keepDate )
		{
			string msg;
			if (!this._stockSlipInputInitDataAcs.InitialReadDataCheck(out msg))
			{
				throw new ApplicationException(msg);
			}

			StockTtlSt stockTtlSt = this._stockSlipInputInitDataAcs.GetStockTtlSt();

			AllDefSet allDefSet = this._stockSlipInputInitDataAcs.GetAllDefSet();
			//if (stockTtlSt == null)
			//{
            //    throw new ApplicationException("�d���݌ɑS�̐ݒ�}�X�^�̓o�^���s���ĉ������B");
			//}
			
			DateTime keepArrivalGoodsDay = this._stockSlip.ArrivalGoodsDay;
            DateTime keepStockDate = ( this._stockSlip.SupplierFormal == 0 ) ? this._stockSlip.StockDate : this._stockSlip.ArrivalGoodsDay;

			StockSlip stockSlip = new StockSlip();

			stockSlip.SupplierFormal = supplierFormal;
			stockSlip.StockSectionCd = LoginInfoAcquisition.Employee.BelongSectionCode.Trim();
			SecInfoSet secInfoSet = this._stockSlipInputInitDataAcs.GetSecInfo(LoginInfoAcquisition.Employee.BelongSectionCode.Trim());
			if (secInfoSet != null)
			{
                stockSlip.StockSectionNm = secInfoSet.SectionGuideNm;
			}

			stockSlip.StockAgentCode = LoginInfoAcquisition.Employee.EmployeeCode.Trim();								// �d���S���҃R�[�h[���O�C���S��]
			stockSlip.StockAgentName = this._stockSlipInputInitDataAcs.GetName_FromEmployee(stockSlip.StockAgentCode);	// �d���S���Җ���[���O�C���S��]
			if (stockSlip.StockAgentName.Length > 16)
			{
				stockSlip.StockAgentName = stockSlip.StockAgentName.Substring(0, 16);
			}

			int subSectionCode;
			this._stockSlipInputInitDataAcs.GetSubSection_FromEmployeeDtl(stockSlip.StockAgentCode, out subSectionCode);
			stockSlip.SubSectionCode = subSectionCode;																	// ����R�[�h
			stockSlip.SubSectionName=	this._stockSlipInputInitDataAcs.GetName_FromSubSection(subSectionCode);			// ���喼��
			stockSlip.StockInputCode = LoginInfoAcquisition.Employee.EmployeeCode.Trim();								// �d���S���҃R�[�h[���O�C���S��]
			stockSlip.StockInputName = this._stockSlipInputInitDataAcs.GetName_FromEmployee(stockSlip.StockInputCode);	// �d���S���Җ���[���O�C���S��]
			if (stockSlip.StockInputName.Length > 16)
			{
				stockSlip.StockInputName = stockSlip.StockInputName.Substring(0, 16);
			}

			stockSlip.SupplierSlipCd = 10;															// �d���`�[�敪[10:�d��]

			stockSlip.InputDay = DateTime.Today;													// ���͓�

			stockSlip.ArrivalGoodsDay = ( keepDate ) ? keepArrivalGoodsDay : DateTime.Today;		// ���ד�:���t��ێ����Ȃ��ꍇ�͍�����ݒ�

			if (stockSlip.SupplierFormal == 0)
			{
				stockSlip.StockDate = ( keepDate ) ? keepStockDate : DateTime.Today;				// �d����:���t��ێ����Ȃ��ꍇ�͍�����ݒ�

				stockSlip.StockAddUpADate = stockSlip.StockDate;									// �d���v����t[�d����]
				stockSlip.AccPayDivCd = accPayDivCd;												// ���|�敪
				stockSlip.StockGoodsCd = stockGoodsCd;												// ���i�敪
			}
			else if (stockSlip.SupplierFormal == 1)
			{
				stockSlip.StockAddUpADate = DateTime.MinValue;										// �d���v����t
				stockSlip.StockDate = stockSlip.StockAddUpADate;									// �d���� �� �d���v���
				stockSlip.AccPayDivCd = 1;															// ���|�敪���u���|�v�Ƃ���
				stockSlip.StockGoodsCd = 0;															// ���i�敪���u���i�v�Ƃ���
			}

			stockSlip.DelayPaymentDiv = 0;															// �����敪 = ����

			// ��ʗp�`�[�敪�Đݒ�
			StockSlipInputAcs.SetDisplayFromSlipCdAndAccPayDivCd(ref stockSlip);

			//StockSlip.SuppTtlAmntDspWayCd = stockTtlSt.TotalAmountDispWayCd;						// ���z�\�����@�敪
			stockSlip.SuppTtlAmntDspWayCd = allDefSet.TotalAmountDispWayCd;							// ���z�\�����@�敪
			stockSlip.TtlAmntDispRateApy = allDefSet.TtlAmntDspRateDivCd;							// ���z�\���|���K�p�敪

			stockSlip.PriceCostUpdtDiv = ( stockTtlSt.PriceCostUpdtDiv == 1 ) ? 1 : 0;				// �艿�����X�V�敪

			// �d���f�[�^�L���b�V������
			this.Cache(stockSlip);

			// �d���f�[�^�L���b�V������
            this.Cache(new PaymentSlp(), new List<PaymentDtl>());

			// DB�Ǎ����d���f�[�^�L���b�V������
			this.CacheDBData(stockSlip);
		}


		#region �ԕi�����֘A

		/// <summary>
		/// �ԕi�p�̎d���f�[�^�I�u�W�F�N�g�𐶐����܂��B
		/// </summary>
		/// <param name="stockSlip">�d���f�[�^�I�u�W�F�N�g�iref�j</param>
		public void CreateReturnSlipInfo(ref StockSlip stockSlip)
		{
			if (stockSlip == null) return;

			stockSlip.CreateDateTime = DateTime.MinValue;
			stockSlip.UpdateDateTime = DateTime.MinValue;
			stockSlip.SupplierSlipCd = 20;										// �d���`�[�敪 �� 20:�ԕi
			stockSlip.InputMode = ctINPUTMODE_StockSlip_Return;					// ���̓��[�h �� �ԕi���̓��[�h
			stockSlip.SupplierSlipNo = 0;										// �d���`�[�ԍ� �� 0
		}

		/// <summary>
		/// �ԕi�p�̎d�����׃f�[�^�e�[�u���𐶐����܂��B
		/// </summary>
		/// <param name="stockWorkList">�݌Ƀ��[�N�I�u�W�F�N�g���X�g</param>
		public void CreateReturnSlipDetailInfo( List<StockWork> stockWorkList )
		{
			this.CreateReturnSlipDetailInfo(stockWorkList, this._stockDetailDataTable);
		}

		/// <summary>
		/// �ԕi�p�̎d�����׃f�[�^�e�[�u���𐶐����܂��B�i�I�[�o�[���[�h�j
		/// </summary>
		/// <param name="stockWorkList">�݌Ƀ��[�N�I�u�W�F�N�g���X�g</param>
		/// <param name="stockDetailDataTable">�d�����׃f�[�^�e�[�u���I�u�W�F�N�g</param>
		public void CreateReturnSlipDetailInfo(List<StockWork>stockWorkList,StockInputDataSet.StockDetailDataTable stockDetailDataTable)
		{
			for (int i = 0; i < stockDetailDataTable.Count; i++)
			{
				int sign = -1;
				StockInputDataSet.StockDetailRow row = stockDetailDataTable[i];

				row.SupplierFormalSrc = row.SupplierFormal;		// �d���`��(��) �� �ďo�`�[�̎d���`��
				row.StockSlipDtlNumSrc = row.StockSlipDtlNum;	// ���גʔ�(��) �� �ďo�`�[�̖��גʔ�
				row.SupplierSlipNo = 0;							// �d���`�[�ԍ� �� 0
				//row.CommonSeqNo = 0;							// ���ʒʔ� �� 0
				row.StockSlipDtlNum = 0;						// ���גʔ� �� 0
				row.AcptAnOdrStatusSync = 0;					// �󒍃X�e�[�^�X(����) �� 0
				row.SalesSlipDtlNumSync = 0;					// ���㖾�גʔ�(����) �� 0
				row.StockCountMax = 0;							// �v��\�� �� 0
				row.StockCountMin = 0;							// �v��ϐ��� �� 0

                row.StockPriceDisplay = row.StockPriceDisplay * sign;

				if (row.StockCount != 0)
				{
                    row.StockCount = row.OrderRemainCnt * sign;			// �d���� �� ���`�[�̔����c * -1
					row.StockCountDefault = Math.Abs(row.StockCount);	// ����(�����l) �� ���`�[�̔����c 
					row.StockCountDisplay = row.StockCount * sign;		// ����(�\��) �� ���`�[�̔����c 
					//row.StockCountMax = Math.Abs(row.StockCount);		// ����(�ő�) �� ���`�[�̔����c
                    row.StockCountMax = row.StockCount;                 // ����(�ő�) �� ���`�[�̔����c

                    //row.StockPriceDisplay *= sign;
                    row.StockPriceTaxExc *= sign;
                    row.StockPriceTaxInc *= sign;
                    row.StockPriceConsTax *= sign;


					row.OrderCnt = row.StockCount;					// ������ �� 0
					row.OrderAdjustCnt = 0;							// ���������� �� 0
					row.OrderRemainCnt = 0;							// �����c �� 0

					//row.EditStatus = ctEDITSTATUS_StockCountOnly;
					row.EditStatus = ctEDITSTATUS_ArrivalAddUpNew;
					row.CanTaxDivChange = false;
				}

				// ������񒲐�
				this.MemoInfoAdjust(ref row);
			}
			this.StockDetailStockInfoAdjust();
		}

		/// <summary>
		/// �w�肳�ꂽ�d���f�[�^�ɑ΂��ĕԕi���s�����Ƃ��o���邩�ǂ������`�F�b�N���܂��B
		/// </summary>
		/// <param name="stockSlip">�d���f�[�^</param>
		/// <param name="stockDetailList">�d�����׃f�[�^���X�g</param>
		/// <param name="message">���b�Z�[�W�iout�j</param>
		/// <returns>true:�ԕi�`�[��񐶐��� false:�ԕi�`�[��񐶐��s��</returns>
		public bool CanCreateReturnSlipInfo( StockSlip stockSlip, List<StockDetail> stockDetailList, out string message )
		{
            message = string.Empty;

			// �d���`�[�敪���u20:�ԕi�v�̏ꍇ
			if (stockSlip.SupplierSlipCd == 20)
			{
				message = "�Y������d���f�[�^�́u�ԕi�`�[�v�ׁ̈A�I���ł��܂���B";
				return false;
			}

			if (stockSlip.DebitNoteDiv == 1)
			{
				message = "�Y������d���f�[�^�́u�ԓ`�v�ׁ̈A�ԕi�������s���܂���B";
				return false;
			}
			else if (stockSlip.DebitNoteDiv == 2)
			{
				message = "�Y������d���f�[�^�͂��łɁu�ԓ`�v�����s����Ă���ׁA�ԕi�������s���܂���B";
				return false;
			}

			if (( stockSlip.StockGoodsCd == 2 ) || ( stockSlip.StockGoodsCd == 4 ))
			{
				message = "�Y������d���f�[�^�́u����Œ����`�[�v�ׁ̈A�ԕi�������s���܂���B";
				return false;
			}
			else if (( stockSlip.StockGoodsCd == 3 ) || ( stockSlip.StockGoodsCd == 5 ))
			{
				message = "�Y������d���f�[�^�́u�c�������`�[�v�ׁ̈A�ԕi�������s���܂���B";
				return false;
			}

			if (stockDetailList != null)
			{
				bool isTrust = false;

				foreach (StockDetail stockDetail in stockDetailList)
				{
					if (stockDetail.OrderRemainCnt != 0)
					{
						isTrust = true;
						break;
					}
				}

				if (!isTrust)
				{
					message = "�Y������d���f�[�^�͑S�āu�ԕi�v�������́u�v��v���������Ă���ׁA�I���ł��܂���B";
					return false;
				}
			}

			return true;
		}

		#endregion

		#region �ԓ`�����֘A
		/// <summary>
		/// �ԓ`�p�̎d���f�[�^�I�u�W�F�N�g�𐶐����܂��B
		/// </summary>
		/// <param name="stockSlip">�d���f�[�^�I�u�W�F�N�g�iref�j</param>
		public void CreateRedSlipInfo(ref StockSlip stockSlip)
		{
			if (stockSlip == null) return;

			stockSlip.CreateDateTime = DateTime.MinValue;
			stockSlip.UpdateDateTime = DateTime.MinValue;
			stockSlip.SupplierSlipCd = 10;										// �d���`�[�敪 �� 10:�d��
			stockSlip.InputMode = ctINPUTMODE_StockSlip_Red;					// ���̓��[�h �� �ԓ`���̓��[�h
			stockSlip.DebitNLnkSuppSlipNo = stockSlip.SupplierSlipNo;			// �ԍ��A���d���`�[�ԍ� �� �����̎d���`�[�ԍ�
			stockSlip.SupplierSlipNo = 0;										// �d���`�[�ԍ� �� 0
			stockSlip.DebitNoteDiv = 1;											// �ԓ`�敪 �� �ԓ`
		}

		/// <summary>
		/// �ԓ`�p�̎x���f�[�^�I�u�W�F�N�g�𐶐����܂��B
		/// </summary>
		/// <param name="paymentSlp">�x���f�[�^�I�u�W�F�N�g�iref�j</param>
		public void CreateRedSlipInfo( ref PaymentSlp paymentSlp )
		{
			if (paymentSlp == null) return;

			paymentSlp.CreateDateTime = DateTime.MinValue;
			paymentSlp.UpdateDateTime = DateTime.MinValue;
			paymentSlp.FileHeaderGuid = Guid.Empty;
			paymentSlp.UpdAssemblyId1 = string.Empty;
			paymentSlp.UpdAssemblyId2 = string.Empty;
			paymentSlp.PaymentSlipNo = 0;
			paymentSlp.SupplierSlipNo = 0;
		}

		/// <summary>
		/// �ԓ`�p�̎d�����׃f�[�^�e�[�u���𐶐����܂��B
		/// </summary>
		public void CreateRedSlipDetailInfo( List<StockWork> stockWorkList )
		{
			this.CreateRedSlipDetailInfo(stockWorkList, this._stockDetailDataTable);
		}

		/// <summary>
		/// �ԓ`�p�̎d�����׃f�[�^�e�[�u���𐶐����܂��B�i�I�[�o�[���[�h�j
		/// </summary>
		/// <param name="stockWorkList">�݌Ƀ��[�N�I�u�W�F�N�g���X�g</param>
		/// <param name="stockDetailDataTable">�d�����׃f�[�^�e�[�u���I�u�W�F�N�g</param>
		public void CreateRedSlipDetailInfo( List<StockWork> stockWorkList, StockInputDataSet.StockDetailDataTable stockDetailDataTable )
		{
			for (int i = 0; i < stockDetailDataTable.Count; i++)
			{
				int sign = -1;
				StockInputDataSet.StockDetailRow row = stockDetailDataTable[i];
				row.SupplierFormalSrc = row.SupplierFormal;		// �d���`��(��) �� �ďo�`�[�̎d���`��
				row.StockSlipDtlNumSrc = row.StockSlipDtlNum;	// ���גʔ�(��) �� �ďo�`�[�̖��גʔ�
				row.SupplierSlipNo = 0;							// �d���`�[�ԍ� �� 0
				//salesTempRow.CommonSeqNo = 0;							// ���ʒʔ� �� 0
				row.StockSlipDtlNum = 0;						// ���גʔ� �� 0
				row.AcptAnOdrStatusSync = 0;					// �󒍃X�e�[�^�X(����) �� 0
				row.SalesSlipDtlNumSync = 0;					// ���㖾�גʔ�(����) �� 0
				row.StockCountMin = 0;							// �v��ϐ��� �� 0

                if (row.StockCount != 0)
                {
                    row.StockCount *= sign;		// �d���� �� �d�����~-1
                    row.StockPriceDisplay *= sign;
                    row.StockPriceTaxExc *= sign;
                    row.StockPriceTaxInc *= sign;
                    row.StockPriceConsTax *= sign;
                    row.StockCountMax = row.StockCount;
                    row.StockCountDisplay = row.StockCount;
                    row.StockCountDefault = row.StockCount;
                    row.OrderCnt = row.StockCount;				// ������ �� �d����
                    row.OrderAdjustCnt = 0;						// ���������� �� 0
                    row.OrderRemainCnt = 0;						// �����c �� 0

                    row.EditStatus = ctEDITSTATUS_AllDisable;
                    row.CanTaxDivChange = false;
                }
                else if (row.StockSlipCdDtl == 2 )
                {
                    row.StockPriceDisplay *= sign;
                    row.StockPriceTaxExc *= sign;
                    row.StockPriceTaxInc *= sign;
                    row.StockPriceConsTax *= sign;
                }

				// ������񒲐�
				this.MemoInfoAdjust(ref row);

			}
			this.StockDetailStockInfoAdjust();
		}

		/// <summary>
		/// �w�肳�ꂽ�d���f�[�^�ɑ΂��Đԓ`���s�����Ƃ��o���邩�ǂ������`�F�b�N���܂��B
		/// </summary>
		/// <param name="stockSlip">�d���f�[�^�I�u�W�F�N�g</param>
		/// <param name="stockDetailList">�d�����׃f�[�^�N���X���X�g</param>
		/// <param name="message">���b�Z�[�W�iout�j</param>
		/// <returns>true:�ԓ`�[��񐶐��� false:�ԓ`�[��񐶐��s��</returns>
		public bool CanCreateRedSlipInfo( StockSlip stockSlip, List<StockDetail> stockDetailList, out string message )
		{
            message = string.Empty;

			// �d���`�[�敪���u20:�ԕi�v�̏ꍇ
			if (stockSlip.SupplierSlipCd == 20)
			{
				message = "�Y������d���f�[�^�́u�ԕi�`�[�v�ׁ̈A�ԓ`�������s���܂���B";
				return false;
			}

			if (stockSlip.DebitNoteDiv == 1)
			{
				message = "�Y������d���f�[�^�́u�ԓ`�v�ׁ̈A�I���ł��܂���B";
				return false;
			}
			else if (stockSlip.DebitNoteDiv == 2)
			{
				message = "�Y������d���f�[�^�͂��łɁu�ԓ`�v�����s����Ă���ׁA�I���ł��܂���B";
				return false;
			}

			if (( stockSlip.StockGoodsCd == 2 ) || ( stockSlip.StockGoodsCd == 4 ))
			{
				message = "�Y������d���f�[�^�́u����Œ����`�[�v�ׁ̈A�ԓ`�������s���܂���B";
				return false;
			}
			else if (( stockSlip.StockGoodsCd == 3 ) || ( stockSlip.StockGoodsCd == 5 ))
			{
				message = "�Y������d���f�[�^�́u�c�������`�[�v�ׁ̈A�ԓ`�������s���܂���B";
				return false;
			}
			if (stockSlip.SupplierFormal == 1)
			{
				message = "�Y������d���f�[�^�́u���ד`�[�v�ׁ̈A�ԓ`�������s���܂���B";
				return false;
			}
			else if (stockSlip.SupplierFormal == 2)
			{
				message = "�Y������d���f�[�^�́u�����f�[�^�v�ׁ̈A�ԓ`�������s���܂���B";
				return false;
			}

			if (stockDetailList != null)
			{
				bool isTrust = false;

				foreach (StockDetail stockDetail in stockDetailList)
				{
					if (stockDetail.StockCount != stockDetail.OrderRemainCnt)
					{
						isTrust = true;
						break;
					}
				}

				if (isTrust)
				{
					message = "�Y������d���f�[�^�́u�ԕi�v�������́u���׌v��v���������Ă���ׁA�I���ł��܂���B";
					return false;
				}
			}

			return true;
		}
		#endregion

		#region ���׌v��֘A

		/// <summary>
		/// ���׌v��p�̎d���f�[�^�I�u�W�F�N�g�𐶐����܂��B
		/// </summary>
		/// <param name="stockSlip">�d���f�[�^�I�u�W�F�N�g</param>
		public void CreateArrivalAppropriateInfo(ref StockSlip stockSlip)
		{
			if (stockSlip == null) return;

			stockSlip.CreateDateTime = DateTime.MinValue;
			stockSlip.UpdateDateTime = DateTime.MinValue;
			stockSlip.SupplierSlipNo = 0;								// �d���`�[�ԍ� �� 0
			stockSlip.SupplierFormal = 0;								// �d���`�� �� 0:�d��
			stockSlip.StockAddUpADate = DateTime.Today;					// �d���v����t[�V�X�e�����t]
			stockSlip.StockDate = stockSlip.StockAddUpADate;			// �d���� �� �d���v���
			//stockSlip.TrustAddUpSpCd = 1;								// ���׌v��d���敪 �� 1:���׌v��d��
			stockSlip.AccPayDivCd = 1;									// ���|�敪 �� 1:���|
			stockSlip.InputMode = ctINPUTMODE_StockSlip_ArrivalAddUp;	// ���̓��[�h �� ���׌v����̓��[�h
		}

		/// <summary>
        /// ���׌v��p�̎d�����׃f�[�^�e�[�u���𐶐����܂��B
		/// </summary>
        public void CreateArrivalAppropriateDetailInfo()
        {
            this.CreateArrivalAppropriateDetailInfo(this._stockDetailDataTable);

            this._stockDetailDataTable.AcceptChanges();
            // �݌ɐ�����
            this.StockDetailStockInfoAdjust();
        }

		/// <summary>
        /// ���׌v��p�̎d�����׃f�[�^�e�[�u���𐶐����܂��B�i�I�[�o�[���[�h�j
		/// </summary>
		/// <param name="stockDetailDataTable">�d�����׃f�[�^�e�[�u���I�u�W�F�N�g</param>
        public void CreateArrivalAppropriateDetailInfo( StockInputDataSet.StockDetailDataTable stockDetailDataTable )
        {
            for (int i = 0; i < stockDetailDataTable.Count; i++)
            {
                StockInputDataSet.StockDetailRow row = stockDetailDataTable[i];

                row.SupplierFormalSrc = row.SupplierFormal;		// �d���`��(��) �� �ďo�`�[�̎d���`��
                row.StockSlipDtlNumSrc = row.StockSlipDtlNum;	// ���גʔ�(��) �� �ďo�`�[�̖��גʔ�
                row.SupplierSlipNo = 0;							// �d���`�[�ԍ� �� 0
                //row.CommonSeqNo = 0;							// ���ʒʔ� �� 0
                row.StockSlipDtlNum = 0;						// ���גʔ� �� 0
                row.AcptAnOdrStatusSync = 0;					// �󒍃X�e�[�^�X(����) �� 0
                row.SalesSlipDtlNumSync = 0;					// ���㖾�גʔ�(����) �� 0

                if (row.OrderRemainCnt != row.StockCount)
                {
                    row.StockPriceDiectInput = false;
                }

                row.StockCount = row.OrderRemainCnt;			// �d���� �� �����c


                row.StockCountDisplay = row.StockCount;			// ���� �� �����c
                row.StockCountDefault = row.StockCount;			// ���ʏ����l �� �����c
                row.StockCountMax = row.StockCount;				// �v��\�� �� �����c
                row.StockCountMin = 0;							// �v��ςݐ��� �� 0
                row.OrderCnt = row.StockCount;					// ������ �� �d����
                row.OrderAdjustCnt = 0;							// ���������� �� 0
                row.OrderRemainCnt = 0;							// �����c �� 0

                row.SupplierCd = 0;
                row.SupplierSnm = string.Empty;
                row.AddresseeCode = 0;
                row.AddresseeName = string.Empty;
                row.DirectSendingCd = 0;
                row.OrderNumber = string.Empty;
                row.WayToOrder = 0;
                row.DeliGdsCmpltDueDate = DateTime.MinValue;
                row.ExpectDeliveryDate = DateTime.MinValue;
                row.OrderDataCreateDiv = 0;
                row.OrderDataCreateDate = DateTime.MinValue;
                row.OrderFormIssuedDiv = 0;

                row.EditStatus = ctEDITSTATUS_ArrivalAddUpNew;

                // ������񒲐�
                this.MemoInfoAdjust(ref row);
            }
        }

		/// <summary>
		/// ���׌v����N���A����
		/// </summary>
		public void ClearArrivalAppropriateInfo()
		{
			foreach (StockInputDataSet.StockDetailRow stockDetailRow in this._stockDetailDataTable.Rows)
			{
				// �d���`��(��)�����ׁA�d�����גʔ�(��)���Z�b�g����Ă���f�[�^�̂ݑΏ�
				if (( stockDetailRow.SupplierFormalSrc == 1 ) && ( stockDetailRow.StockSlipDtlNumSrc != 0 ))
				{
					DataRow[] dataRows = stockDetailRow.GetChildRows(cRelation_Detail_AddUpSrcDetail);

					if (( dataRows != null ) && ( dataRows.Length > 0 ))
					{
						foreach(StockInputDataSet.AddUpSrcDetailRow addUpSrcDetailRow in dataRows)
						{
							this._addUpSrcDetailDataTable.RemoveAddUpSrcDetailRow(addUpSrcDetailRow);
						}
					}
					stockDetailRow.SupplierFormalSrc = 0;
					stockDetailRow.StockSlipDtlNumSrc = 0;
					stockDetailRow.StockCountMin = 0;
					stockDetailRow.StockCountMax = 0;
					stockDetailRow.StockCountDefault = 0;
					stockDetailRow.EditStatus = ctEDITSTATUS_AllOK;
				}
			}
			this.StockDetailStockInfoAdjust();
		}
      
		/// <summary>
		/// �w�肳�ꂽ���׃f�[�^�ɑ΂��ē��׌v����s�����Ƃ��o���邩�ǂ������`�F�b�N���܂��B
		/// </summary>
		/// <param name="stockSlip">�d���f�[�^�I�u�W�F�N�g</param>
		/// <param name="stockDetailList">�d�����׃f�[�^���X�g</param>
		/// <param name="message">���b�Z�[�W�iout�j</param>
		/// <returns>true:���׌v���񐶐��� false:���׌v�㐶���s��</returns>
		public bool CanCreateArrivalAddUpInfo( StockSlip stockSlip, List<StockDetail> stockDetailList, out string message )
		{
            message = string.Empty;

			// �d���`�[�敪���u20:�ԕi�v�̏ꍇ
			if (stockSlip.SupplierSlipCd == 20)
			{
				message = "�Y������f�[�^�́u�ԕi�`�[�v�ׁ̈A���׌v�㏈�����s���܂���B";
				return false;
			}

			if (stockSlip.DebitNoteDiv == 1)
			{
				message = "�Y������f�[�^�́u�ԓ`�v�ׁ̈A���׌v�㏈�����s���܂���B";
				return false;
			}
			else if (stockSlip.DebitNoteDiv == 2)
			{
				message = "�Y������f�[�^�͂��łɁu�ԓ`�v�����s����Ă���ׁA���׌v�㏈�����s���܂���B";
				return false;
			}

			if (stockDetailList != null)
			{
				bool isTrust = false;

				foreach (StockDetail stockDetail in stockDetailList)
				{
					if (stockDetail.OrderRemainCnt != 0)
					{
						isTrust = true;
						break;
					}
				}

				if (!isTrust)
				{
					message = "�Y������d���f�[�^�͑S�āu�ԕi�v�������́u���׌v��v����Ă���ׁA�I���ł��܂���B";
					return false;
				}
			}

			return true;
		}
		#endregion

		#region �`�[���ʊ֘A
		/// <summary>
        /// ���ʓ`�[�̎d���f�[�^�I�u�W�F�N�g�𐶐����܂��B
        /// </summary>
        /// <param name="stockSlip">�d���f�[�^�I�u�W�F�N�g�iref�j</param>
        public void CreateSlipCopyInfo( ref StockSlip stockSlip )
        {
            if (stockSlip == null) return;

            stockSlip.CreateDateTime = DateTime.MinValue;
            stockSlip.UpdateDateTime = DateTime.MinValue;
            stockSlip.InputMode = ctINPUTMODE_StockSlip_Normal;					// ���̓��[�h �� �ʏ탂�[�h
            stockSlip.DebitNLnkSuppSlipNo = 0;                      			// �ԍ��A���d���`�[�ԍ� �� 0
            stockSlip.DebitNoteDiv = 0;                      			        // �ԓ`�敪 �� 0

            stockSlip.SupplierSlipNo = 0;										// �d���`�[�ԍ� �� 0
        }

        /// <summary>
        /// ���ʓ`�[�̎d�����׃f�[�^�e�[�u���𐶐����܂��B
        /// </summary>
		/// <param name="stockWorkList">�݌Ƀ��[�N�I�u�W�F�N�g���X�g</param>
		public void CreateSlipCopyDetailInfo( List<StockWork> stockWorkList )
        {
			this.CreateSlipCopyDetailInfo(stockWorkList, this._stockDetailDataTable);
        }

        /// <summary>
        /// ���ʓ`�[�̎d�����׃f�[�^�e�[�u���𐶐����܂��B�i�I�[�o�[���[�h�j
        /// </summary>
		/// <param name="stockWorkList">�݌Ƀ��[�N�I�u�W�F�N�g���X�g</param>
        /// <param name="stockDetailDataTable">�d�����׃f�[�^�e�[�u���I�u�W�F�N�g</param>
		public void CreateSlipCopyDetailInfo( List<StockWork> stockWorkList, StockInputDataSet.StockDetailDataTable stockDetailDataTable )
		{
			int sign = ( this._stockSlip.SupplierSlipCd == 20 ) ? -1 : 1;
			for (int i = 0; i < stockDetailDataTable.Count; i++)
			{
				StockInputDataSet.StockDetailRow row = stockDetailDataTable[i];
				row.SupplierSlipNo = 0;						// �d���`�[�ԍ� �� 0
				row.AcceptAnOrderNo = 0;					// �󒍔ԍ� �� 0
				row.CommonSeqNo = 0;						// ���ʒʔ� �� 0
				row.StockSlipDtlNum = 0;					// ���גʔ� �� 0
				row.SupplierFormalSrc = 0;					// �d���`��(��) �� �ďo�`�[�̎d���`��
				row.StockSlipDtlNumSrc = 0;					// ���גʔ�(��) �� �ďo�`�[�̖��גʔ�
				row.AcptAnOdrStatusSync = 0;				// �󒍃X�e�[�^�X(����) �� 0
				row.SalesSlipDtlNumSync = 0;				// ���㖾�גʔ�(����) �� 0

				row.SalesCustomerCode = 0;
                row.SalesCustomerSnm = string.Empty;
				row.SupplierCd = 0;
                row.SupplierSnm = string.Empty;
				row.AddresseeCode = 0;
                row.AddresseeName = string.Empty;
				row.RemainCntUpdDate = DateTime.MinValue;
				row.DirectSendingCd = 0;
                row.OrderNumber = string.Empty;
				row.WayToOrder = 0;
				row.DeliGdsCmpltDueDate = DateTime.MinValue;
				row.ExpectDeliveryDate = DateTime.MinValue;
				row.OrderCnt = row.StockCount;
				row.OrderAdjustCnt = 0;
				row.OrderRemainCnt = 0;
				row.OrderDataCreateDiv = 0;
				row.OrderDataCreateDate = DateTime.MinValue;
				row.OrderFormIssuedDiv = 0;

				row.StockCountMin = 0;
				row.StockCountMax = 0;

				row.StockCountDisplay = row.StockCount * sign;

                if (row.StockCount != 0)
                {
                    //salesTempRow.StockCountDefault = salesTempRow.StockCountDisplay;

                    if (row.StockSlipCdDtl == 2)
                    {
                        row.EditStatus = ctEDITSTATUS_GoodsDiscount;
                        row.CanTaxDivChange = false;
                    }
                    else
                    {
                        row.EditStatus = ctEDITSTATUS_AllOK;
                        row.CanTaxDivChange = true;
                    }
                }
                else
                {
                    if (row.StockSlipCdDtl == 2)
                    {
                        row.EditStatus = ctEDITSTATUS_RowDiscount;
                        row.CanTaxDivChange = false;
                    }
                }

				// ������񒲐�
				this.MemoInfoAdjust(ref row);
			}
			this.StockDetailStockInfoAdjust();
		}
		#endregion

		/// <summary>
		/// �d���`���R�[�h���A�d���`�����̂��擾���܂��B
		/// </summary>
		/// <param name="stockSlip">�d���f�[�^�I�u�W�F�N�g</param>
		/// <returns>�d���`������</returns>
		public string GetSupplierFormalName(StockSlip stockSlip)
		{
			return this.GetSupplierFormalName(stockSlip.SupplierFormal);
		}

		/// <summary>
		/// �d���`���R�[�h���A�d���`�����̂��擾���܂��B
		/// </summary>
		/// <param name="supplierFormal">�d���`���R�[�h</param>
		/// <returns>�d���`������</returns>
		public string GetSupplierFormalName( int supplierFormal )
		{
            string supplierFormalName = string.Empty;

			if (supplierFormal == 1)
			{
				supplierFormalName = "����";
			}
			else
			{
				supplierFormalName = "�d��";
			}
			return supplierFormalName;
		}

		/// <summary>
		/// �d���f�[�^�I�u�W�F�N�g���C���X�^���X�ϐ��ɃL���b�V�����܂��B
		/// </summary>
		/// <param name="source">�d���f�[�^�I�u�W�F�N�g</param>
		public void Cache( StockSlip source )
		{
			this._stockSlip = source.Clone();
			this._currentSupplierSlipNo = source.SupplierSlipNo;
		}

		/// <summary>
        /// �x���f�[�^�A�x�����׃f�[�^���X�g���C���X�^���X�ϐ��ɃL���b�V�����܂��B
		/// </summary>
        /// <param name="paymentSlp">�x���f�[�^</param>
        /// <param name="paymentDtlList">�x�����׃f�[�^���X�g</param>
        public void Cache( PaymentSlp paymentSlp, List<PaymentDtl> paymentDtlList )
        {
            this._paymentSlp = ( paymentSlp == null ) ? new PaymentSlp() : paymentSlp.Clone();

            this._paymentDtlList = new List<PaymentDtl>();
            if (paymentDtlList != null)
            {
                foreach (PaymentDtl paymentDtl in paymentDtlList)
                {
                    this._paymentDtlList.Add(paymentDtl.Clone());
                }
            }
        }

		/// <summary>
		/// �d���f�[�^�ɓ��Ӑ�i�d����j�̏���ݒ肵�܂��B
		/// </summary>
		/// <param name="stockSlip">�d���f�[�^�I�u�W�F�N�g�iref�j</param>
		/// <param name="supplier">�d����}�X�^�I�u�W�F�N�g</param>
		public void DataSettingStockSlip( ref StockSlip stockSlip, Supplier supplier )
		{
			//if ((stockSlip == null) || (custSuppli == null))
			if ( supplier == null )
			{
				stockSlip.SupplierCd = 0;                       // �R�[�h
                stockSlip.SupplierNm1 = string.Empty;           // ���̂P
                stockSlip.SupplierNm2 = string.Empty;           // ���̂Q
                stockSlip.SupplierSnm = string.Empty;           // ����
				stockSlip.BusinessTypeCode = 0;                 // �Ǝ�R�[�h
                stockSlip.BusinessTypeName = string.Empty;      // �Ǝ햼��
				stockSlip.SalesAreaCode = 0;                    // �̔��G���A�R�[�h
                stockSlip.SalesAreaName = string.Empty;         // �̔��G���A����
				stockSlip.SuppRateGrpCode = 0;                  // �d����|���O���[�v�R�[�h
                stockSlip.StockAddUpSectionCd = string.Empty;   // �v�㋒�_
                stockSlip.StockAddUpSectionNm = string.Empty;   // �v�㋒�_����
				stockSlip.SuppCTaxLayCd = 0;                    // ����œ]�ŕ���
				stockSlip.SuppTtlAmntDspWayCd = 0;              // ���z�\���敪
				stockSlip.TtlAmntDispRateApy = 0;               // ���z�\���|���K�p�敪
			}
			else
			{
				if (supplier == null) supplier = new Supplier();

				// �x������擾
				//CustomerInfo payeeCustomerInfo;
				//CustSuppli payeeCustSuppli;
				//int status = this._customerInfoAcs.ReadDBDataWithCustSuppli(ConstantManagement.LogicalMode.GetData0, customerInfo.EnterpriseCode, custSuppli.PayeeCode, true, out payeeCustomerInfo, out payeeCustSuppli);
				Supplier payeeSupplier;
                if (this._supplierAcs == null) this._supplierAcs = new SupplierAcs();
				int status = this._supplierAcs.Read(out payeeSupplier, supplier.EnterpriseCode, supplier.PayeeCode);

				if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
				{
					payeeSupplier = new Supplier(); 
				}


				// ���Ӑ���
				stockSlip.SupplierCd = supplier.SupplierCd;					// �R�[�h
				stockSlip.SupplierNm1 = supplier.SupplierNm1;				// ���̂P
				stockSlip.SupplierNm2 = supplier.SupplierNm2;				// ���̂Q
				stockSlip.SupplierSnm = supplier.SupplierSnm;				// ����
				stockSlip.BusinessTypeCode = supplier.BusinessTypeCode;		// �Ǝ�R�[�h
				stockSlip.BusinessTypeName = supplier.BusinessTypeName;		// �Ǝ햼��
				stockSlip.SalesAreaCode = supplier.SalesAreaCode;			// �̔��G���A�R�[�h
				stockSlip.SalesAreaName = supplier.SalesAreaName;			// �̔��G���A����
				//stockSlip.SuppRateGrpCode = custSuppli.SuppRateGrpCode;			// �d����|���O���[�v�R�[�h

				// �d���v�㋒�_
                stockSlip.StockAddUpSectionCd = supplier.PaymentSectionCode;
                stockSlip.StockAddUpSectionNm = supplier.PaymentSectionName;

				// ���_�\���敪���u0:�W���v�A�u2:�\�������v�̏ꍇ�́A�d����̊Ǘ����_���Z�b�g
				if (( this._stockSlipInputInitDataAcs.GetStockTtlSt().SectDspDivCd == 0 ) || ( this._stockSlipInputInitDataAcs.GetStockTtlSt().SectDspDivCd == 2 ))
				{
					stockSlip.StockSectionCd = supplier.MngSectionCode.Trim();
					stockSlip.StockSectionNm = supplier.MngSectionName.Trim();
				}

                if (this._stockInputConstructionAcs.UseStockAgentValue == StockSlipInputConstructionAcs.UseStockAgent_ON)
                {
                    // �}�X�^��̎d���S���҂����݂����ꍇ�Ɏd���S���҂�����������
                    if (this._stockSlipInputInitDataAcs.CodeExist_Employee(supplier.StockAgentCode))
                    {
                        if (stockSlip.StockAgentCode != supplier.StockAgentCode)
                        {
                            stockSlip.StockAgentCode = supplier.StockAgentCode;
                            stockSlip.StockAgentName = supplier.StockAgentName;

                            if (stockSlip.StockAgentName.Length > 16)
                            {
                                stockSlip.StockAgentName = stockSlip.StockAgentName.Substring(0, 16);
                            }
                            this.StockAgentBelongInfoSetting(ref stockSlip);
                        }
                    }
                }

				// ����ł̒[�������敪
                double fractionProcUnit;
                int fractionProcCd;
				this._stockSlipInputInitDataAcs.GetStockFractionProcInfo(StockSlipInputInitDataAcs.ctFracProcMoneyDiv_Tax, supplier.StockCnsTaxFrcProcCd, 999999999, out fractionProcUnit, out fractionProcCd);
                stockSlip.StockFractionProcCd = fractionProcCd;

				// �ȉ��A�x������
				stockSlip.PayeeCode = payeeSupplier.SupplierCd;
				stockSlip.PayeeSnm = payeeSupplier.SupplierSnm;
				stockSlip.PayeeName = payeeSupplier.SupplierNm1;
				stockSlip.PayeeName2 = payeeSupplier.SupplierNm2;
				stockSlip.PaymentTotalDay = payeeSupplier.PaymentTotalDay;
				stockSlip.NTimeCalcStDate = payeeSupplier.NTimeCalcStDate;

				// �v����̍ăZ�b�g
				this.SettingAddUpDate(ref stockSlip);

				// �d���݌ɑS�̐ݒ�}�X�^���擾
				StockTtlSt stockTtlSt = this._stockSlipInputInitDataAcs.GetStockTtlSt();

				// �S�̏����l�ݒ�}�X�^���擾
				AllDefSet allDefSet = this._stockSlipInputInitDataAcs.GetAllDefSet();

				if (stockTtlSt == null) stockTtlSt = new StockTtlSt();

				// ���Ӑ�d�����}�X�^�̎d�������œ]�ŕ����Q�Ƌ敪��
				// �u1:�d����Q�Ɓv�̏ꍇ�͓��Ӑ�d�����}�X�^�́u�d�������œ]�ŕ����R�[�h�v��ݒ肷��
				// �u0:�d���݌ɑS�̐ݒ�Q�Ɓv�̏ꍇ�͎d���݌ɑS�̐ݒ�}�X�^�́u�d�������œ]�ŕ����R�[�h�v��ݒ肷��
				stockSlip.SuppCTaxLayCd = ( payeeSupplier.SuppCTaxLayRefCd == 1 ) ? payeeSupplier.SuppCTaxLayCd : this._stockSlipInputInitDataAcs.GetTaxRateSet().ConsTaxLayMethod;

				// ���Ӑ�d�����}�X�^�̎d���摍�z�\�����@�Q�Ƌ敪��
				// �1:�d����Q�Ɓv�̏ꍇ�͓��Ӑ�d�����}�X�^�́u�d���摍�z�\�����@�敪�v��ݒ肷��
				// �0:�S�̐ݒ�Q�Ɓv�̏ꍇ�͑S�̏����l�ݒ�}�X�^�́u���z�\�����@�敪�v��ݒ肷��
				stockSlip.SuppTtlAmntDspWayCd = ( supplier.StckTtlAmntDspWayRef == 1 ) ? supplier.SuppTtlAmntDspWayCd : allDefSet.TotalAmountDispWayCd;

				// ���z�\���|���K�p�敪
				stockSlip.TtlAmntDispRateApy = allDefSet.TtlAmntDspRateDivCd;
			}
		}

		/// <summary>
		/// �v�����ݒ肵�܂��B
		/// </summary>
		/// <param name="stockSlip">�d���f�[�^�I�u�W�F�N�g</param>
		public void SettingAddUpDate( ref StockSlip stockSlip )
		{
			DateTime addUpDate;
			int delayPaymentDiv;
			StockSlipInputAcs.CalcAddUpDate(stockSlip.StockDate, stockSlip.PaymentTotalDay, stockSlip.NTimeCalcStDate, out addUpDate, out delayPaymentDiv);

			stockSlip.StockAddUpADate = addUpDate;
			stockSlip.DelayPaymentDiv = delayPaymentDiv;
		}

        // 2009.07.10 Add >>>
        /// <summary>
        /// �v������f�t�H���g�l���`�F�b�N
        /// </summary>
        /// <param name="stockSlip">�d���f�[�^�I�u�W�F�N�g</param>
        /// <returns></returns>
        public bool CheckDefaultAddUpDate(StockSlip stockSlip)
        {
            DateTime addUpDate;
            int delayPaymentDiv;
            StockSlipInputAcs.CalcAddUpDate(stockSlip.StockDate, stockSlip.PaymentTotalDay, stockSlip.NTimeCalcStDate, out addUpDate, out delayPaymentDiv);

            return ( stockSlip.StockAddUpADate == addUpDate );
        }
        // 2009.07.10 Add <<<

		/// <summary>
		/// �������ݒ菈��
		/// </summary>
		/// <param name="stockSlip">�d���f�[�^�I�u�W�F�N�g</param>
		public void StockAgentBelongInfoSetting( ref StockSlip stockSlip )
		{
			string belongSecCd;
			int belongSubSecCd;
			this._stockSlipInputInitDataAcs.GetBelongInfo_FromEmployee(stockSlip.StockAgentCode, out belongSecCd, out belongSubSecCd);

			stockSlip.SubSectionCode = belongSubSecCd;
			stockSlip.SubSectionName = this._stockSlipInputInitDataAcs.GetName_FromSubSection(belongSubSecCd);
		}

		/// <summary>
		/// �w�肳�ꂽ�d���f�[�^�̏�Ԃ����ɓ��̓��[�h�̐ݒ���s���܂��B
		/// </summary>
		/// <param name="stockSlip">�d���f�[�^�I�u�W�F�N�g</param>
		public void SettingInputMode(StockSlip stockSlip)
		{
			bool isAddUp = false;
			if (stockSlip.SupplierFormal == 0)
			{
				string message;
				isAddUp = this.CheckAddUp(stockSlip, 1, out message);

				if (isAddUp)
				{
					stockSlip.InputMode = ctINPUTMODE_StockSlip_AddUp;
				}
			}

			if (!isAddUp)
			{
				if (stockSlip.DebitNoteDiv == 1)
				{
					// �ԓ`
					stockSlip.InputMode = ctINPUTMODE_StockSlip_Red;
				}
				else if (stockSlip.DebitNoteDiv == 2)
				{
					// ����
					stockSlip.InputMode = ctINPUTMODE_StockSlip_ReadOnly;
				}
				else
				{
					stockSlip.InputMode = ctINPUTMODE_StockSlip_Normal;
				}
			}
		}

		/// <summary>
		/// ���݂̎d�����׃f�[�^�I�u�W�F�N�g�̃��X�g���d�����׃f�[�^�e�[�u�����擾���܂��B
		/// </summary>
		/// <param name="stockDetailList">�d�����׃f�[�^�I�u�W�F�N�g���X�g</param>
		/// <param name="salesTempList">����f�[�^(�d�������v��)�I�u�W�F�N�g���X�g</param>
		/// <param name="savedSalesTempList">����f�[�^(�d�������v��)�I�u�W�F�N�g���X�g�i�ۑ��ς�)</param>
		public void GetCurrentStockDetail( out List<StockDetail> stockDetailList, out List<SalesTemp> salesTempList, out List<SalesTemp> savedSalesTempList )
		{
			this.GetUIDataFromTable(this._stockDetailDataTable, out stockDetailList, out salesTempList, out savedSalesTempList);
		}

		/// <summary>
		/// ���݂̎d�����׃f�[�^�I�u�W�F�N�g�̃��X�g���d�����׃f�[�^�e�[�u�����擾���܂��B
		/// </summary>
		/// <returns>�d�����׃f�[�^�I�u�W�F�N�g���X�g</returns>
        public void GetCurrentPaymentData( StockSlip stockSlip, out PaymentSlp paymentSlp, out List<PaymentDtl> paymentDtlList )
		{
            if (( this._stockSlipInputInitDataAcs.GetStockTtlSt().AutoPayment == 1 ) &&                                         // �����x��
                ( stockSlip.SupplierFormal == 0 ) &&                                                                            // �d���`��:�d��
                ( stockSlip.AccPayDivCd == 0 ) &&                                                                               // ���|����
                ( ( StockSlip.StockGoodsCd == 0 ) || ( StockSlip.StockGoodsCd == 1 ) || ( StockSlip.StockGoodsCd == 6 ) ))      // ���i�敪:���i�A���i�O�A���v
			{
                paymentSlp = new PaymentSlp();
                paymentDtlList = new List<PaymentDtl>();
                PaymentDtl paymentDtl = new PaymentDtl();
                paymentDtl.PaymentRowNo = 1;                                                                       // �s�ԍ�(1�Œ�)
                paymentDtl.MoneyKindCode = this._stockSlipInputInitDataAcs.GetStockTtlSt().AutoPayMoneyKindCode;   // �x������R�[�h
                paymentDtl.MoneyKindName = this._stockSlipInputInitDataAcs.GetStockTtlSt().AutoPayMoneyKindName;   // �x�����햼��
                paymentDtl.MoneyKindDiv = this._stockSlipInputInitDataAcs.GetStockTtlSt().AutoPayMoneyKindDiv;     // �x������敪

                if (stockSlip.SupplierSlipNo != 0)
                {
                    paymentSlp = this._paymentSlp.Clone();
                    paymentSlp.PayeeName = stockSlip.PayeeName;												// �x���於��
                    paymentSlp.PayeeName2 = stockSlip.PayeeName2;											// �x���於��2

                    if (this._paymentDtlList.Count > 0)
                    {
                        paymentDtl.MoneyKindCode = this._paymentDtlList[0].MoneyKindCode;
                        paymentDtl.MoneyKindName = this._paymentDtlList[0].MoneyKindName;
                        paymentDtl.MoneyKindDiv = this._paymentDtlList[0].MoneyKindDiv;
                    }
                        
                }
                else
                {
                    paymentSlp.PayeeName = stockSlip.PayeeName;												// �x���於��
                    paymentSlp.PayeeName2 = stockSlip.PayeeName2;											// �x���於��2
                }

                paymentDtlList.Add(paymentDtl);
			}
			else
			{
                paymentSlp = null;
                paymentDtlList = null;
			}
		}

		#region ���㓯�����͊֘A

		/// <summary>
		/// ��������V�K���͍s���݃`�F�b�N
		/// </summary>
		/// <returns></returns>
		public bool SalesTempNewInputExist()
		{
			bool ret = false;

			foreach (StockInputDataSet.StockDetailRow stockDetailRow in this._stockDetailDataTable.Rows)
			{
				StockInputDataSet.SalesTempRow salesTempRow = this.GetSalesTempRow(stockDetailRow);

				if (( salesTempRow != null ) && ( salesTempRow.SalesSlipDtlNum == 0 ) && ( salesTempRow.CustomerCode != 0 ))
				{
					ret = true;
					break;
				}
			}

			return ret;
		}

		/// <summary>
		/// ���㑶�݃`�F�b�N
		/// </summary>
		/// <param name="stockRowNo">�Ώۍs</param>
		/// <returns></returns>
		public bool SalesTempExist( int stockRowNo )
		{
			bool ret = false;

			StockInputDataSet.StockDetailRow row = this._stockDetailDataTable.FindBySupplierSlipNoStockRowNo(this._stockSlip.SupplierSlipNo, stockRowNo);

			if (row != null)
			{
				StockInputDataSet.SalesTempRow salesTempRow = this.GetSalesTempRow(row);

				if (( salesTempRow != null ) && ( salesTempRow.CustomerCode != 0 ))
				{
					ret = true;
				}
			}

			return ret;
		}

		/// <summary>
		/// ����f�[�^(�d�������v��)�I�u�W�F�N�g���X�g���L���b�V�����܂��B�i�I�[�o�[���[�h�j
		/// </summary>
		/// <param name="salesTempList">����f�[�^(�d�������v��)�I�u�W�F�N�g���X�g</param>
		public void CacheSalesTemp( List<SalesTemp> salesTempList )
		{
			if (( salesTempList != null ) && ( salesTempList.Count > 0 ))
			{
				foreach (SalesTemp salesTemp in salesTempList)
				{
					foreach (StockInputDataSet.StockDetailRow stockDetailRow in this._stockDetailDataTable)
					{
						if ((salesTemp.SupplierFormalSync == stockDetailRow.SupplierFormal)&&
							( salesTemp.StockSlipDtlNumSync == stockDetailRow.StockSlipDtlNum ))
						{
							this.SalesTempAddRow(this._currentSupplierSlipNo, stockDetailRow.StockRowNo);
							this.CacheSalesTemp(stockDetailRow.StockRowNo, salesTemp);
						}
					}
				}
			}
		}

		/// <summary>
		/// ����f�[�^(�d�������v��)�s�I�u�W�F�N�g���d�����ׂɍ��킹�Ē������܂��B
		/// </summary>
		/// <param name="stockRowNo"></param>
		public void SalesTempRowAdjust( int stockRowNo )
		{
			// ���i�ŁA�ʏ�̍��`�̂ݑΏ�
			if (( this._stockSlip.StockGoodsCd == 0 ) && ( this._stockSlip.SupplierSlipCd == 10 ) && ( this._stockSlip.DebitNoteDiv == 0 ))
			{
                StockInputDataSet.StockDetailRow stockDetailRow = this.GetStockDetailRow(stockRowNo);

				// ���i���͍ς݂̍s�̂ݑΏ�
				if (( stockDetailRow != null ) && 
					( stockDetailRow.StockSlipCdDtl == 0 ) && 
					( stockDetailRow.SalesSlipDtlNumSync == 0 ) && 
					( ( !string.IsNullOrEmpty(stockDetailRow.GoodsNo) ) || ( !string.IsNullOrEmpty(stockDetailRow.GoodsName) ) ))
				{
					StockInputDataSet.SalesTempRow salesTempRow = this.GetSalesTempRow(stockDetailRow);

					if (( salesTempRow != null ) && ( salesTempRow.CustomerCode != 0 ))
					{
						salesTempRow.GoodsName = stockDetailRow.GoodsName;
						salesTempRow.BLGoodsCode = stockDetailRow.BLGoodsCode;
						salesTempRow.BLGoodsFullName = stockDetailRow.BLGoodsFullName;

						salesTempRow.WarehouseCode = stockDetailRow.WarehouseCode;
						salesTempRow.WarehouseName = stockDetailRow.WarehouseName;
						salesTempRow.WarehouseShelfNo = stockDetailRow.WarehouseShelfNo;
					}
				}
			}
		}

		/// <summary>
		/// ���㓯���v��e�[�u���s�ǉ�
		/// </summary>
		/// <param name="supplierSlipNo"></param>
		/// <param name="stockRowNo"></param>
		/// <returns>�ǉ��������㓯���v��I�u�W�F�N�g</returns>
		private StockInputDataSet.SalesTempRow SalesTempAddRow( int supplierSlipNo, int stockRowNo )
		{
			// �d�����L�[�Z�b�g
			StockInputDataSet.StockDetailRow stockDetailRow = this._stockDetailDataTable.FindBySupplierSlipNoStockRowNo(supplierSlipNo, stockRowNo);

			if (( stockDetailRow.DtlRelationGuid == null ) || ( stockDetailRow.DtlRelationGuid == Guid.Empty ))
			{
				stockDetailRow.DtlRelationGuid = Guid.NewGuid();
			}

			// ���㓯���v��L�[�Z�b�g
			StockInputDataSet.SalesTempRow row = this._salesTempDataTable.NewSalesTempRow();
			row.DtlRelationGuid = stockDetailRow.DtlRelationGuid;

			this._salesTempDataTable.AddSalesTempRow(row);
			return row;
		}

		/// <summary>
		/// ����f�[�^(�d�������v��)�d�����ݒ菈��
		/// </summary>
		/// <param name="reCalcMoney">True:���z�Čv�Z����</param>
		public void SalesTempSupplierSetting( bool reCalcMoney )
		{
#if false
			foreach (StockInputDataSet.StockDetailRow stockDetailRow in this._stockDetailDataTable.Rows)
			{
				if (!string.IsNullOrEmpty(stockDetailRow.GoodsNo) || ( !string.IsNullOrEmpty(stockDetailRow.GoodsName) ))
				{
					SalesTemp salesTemp = this.GetSelesTemp(stockDetailRow.StockRowNo);

					if (( salesTemp != null ) && ( salesTemp.SalesSlipDtlNum == 0 ))
					{
						salesTemp.SupplierCd = this._stockSlip.SupplierCd;
						salesTemp.SupplierSnm = this._stockSlip.SupplierSnm;
						salesTemp.SuppRateGrpCode = this._stockSlip.SuppRateGrpCode;

						if (reCalcMoney)
						{
							// �P���Z�o
							this._salesTempInputAcs.CalclationUnitPrice(ref salesTemp);
							// ������z�Čv�Z
							this._salesTempInputAcs.CalculationSalesMoney(ref salesTemp);
							// ���㌴���Čv�Z
							this._salesTempInputAcs.CalculationCost(ref salesTemp);
							// �e���`�F�b�N�敪�ݒ�
							this._salesTempInputAcs.GrsProfitChkDivSetting(ref salesTemp);
							// �L���b�V��
							this.CacheSalesTemp(stockDetailRow.StockRowNo, salesTemp);
						}
					}
				}
			}
#endif
		}
		
		/// <summary>
		/// ���㓯���v��e�[�u���폜
		/// </summary>
		/// <param name="stockRowNoList"></param>
		private void DeleteSalesTempRow( List<int> stockRowNoList )
		{
			foreach (int stockRowNo in stockRowNoList)
			{
				this.DeleteSalesTempRow(this._currentSupplierSlipNo, stockRowNo);
			}
		}

		/// <summary>
		/// ���㓯���v��e�[�u���폜
		/// </summary>
		/// <param name="supplierSlipNo"></param>
		/// <param name="stockRowNo"></param>
		private void DeleteSalesTempRow( int supplierSlipNo, int stockRowNo )
		{
			StockInputDataSet.StockDetailRow targetStockDetailRow = this._stockDetailDataTable.FindBySupplierSlipNoStockRowNo(supplierSlipNo, stockRowNo);
			if (( targetStockDetailRow.DtlRelationGuid != null ) && ( targetStockDetailRow.DtlRelationGuid != Guid.Empty ))
			{
				StockInputDataSet.SalesTempRow targetRow = this._salesTempDataTable.FindByDtlRelationGuid(targetStockDetailRow.DtlRelationGuid);
				if (targetRow == null) return;
				this._salesTempDataTable.RemoveSalesTempRow(targetRow);
			}
		}

		/// <summary>
		/// ���㓯���v��e�[�u���폜
		/// </summary>
		/// <param name="dtlRelationGuid">�����[�V�����pGUID</param>
		private void DeleteSalesTempRow( System.Guid dtlRelationGuid )
		{
			if (( dtlRelationGuid == null ) || ( dtlRelationGuid == Guid.Empty ))
				return;
			StockInputDataSet.SalesTempRow targetRow = this._salesTempDataTable.FindByDtlRelationGuid(dtlRelationGuid);
			if (targetRow == null) return;
			this._salesTempDataTable.RemoveSalesTempRow(targetRow);
		}

		/// <summary>
		/// ���㓯���v��I�u�W�F�N�g�̃N���A���s���܂��B
		/// </summary>
		/// <param name="stockRowNoList">�N���A�Ώێd���s�ԍ����X�g</param>
		public void ClearSalesTempRow( List<int> stockRowNoList )
		{
			foreach (int stockRowNo in stockRowNoList)
			{
				// ���㓯���v�㖾�׍s�N���A����
				this.ClearSalesTempRow(stockRowNo);
			}
		}

		/// <summary>
		/// ���㓯���v��I�u�W�F�N�g�̃N���A���s���܂��B�i�I�[�o�[���[�h�j
		/// </summary>
		/// <param name="row">���㖾�׍s�I�u�W�F�N�g</param>
		private void ClearSalesTempRow( StockInputDataSet.SalesTempRow row )
		{
			if (row == null) return;

			#region �����ڃZ�b�g

			row.CreateDateTime = DateTime.MinValue;			// �쐬����
			row.UpdateDateTime = DateTime.MinValue;			// �X�V����
			row.EnterpriseCode = "";						// ��ƃR�[�h
			//salesTempRow.FileHeaderGuid = 0;						// GUID
			row.UpdEmployeeCode = "";						// �X�V�]�ƈ��R�[�h
			//salesTempRow.UpdAssemblyId1 = "";						// �X�V�A�Z���u��ID1
			//salesTempRow.UpdAssemblyId2 = "";						// �X�V�A�Z���u��ID2
			//salesTempRow.LogicalDeleteCode = 0;					// �_���폜�敪
			row.AcptAnOdrStatus = 0;						// �󒍃X�e�[�^�X
			row.SalesSlipNum = "";							// ����`�[�ԍ�
			row.SectionCode = "";							// ���_�R�[�h
			row.SubSectionCode = 0;							// ����R�[�h
			row.MinSectionCode = 0;							// �ۃR�[�h
			row.DebitNoteDiv = 0;							// �ԓ`�敪
			row.DebitNLnkSalesSlNum = 0;					// �ԍ��A������`�[�ԍ�
			row.SalesSlipCd = 0;							// ����`�[�敪
			row.AccRecDivCd = 0;							// ���|�敪
			row.SalesInpSecCd = "";							// ������͋��_�R�[�h
			row.DemandAddUpSecCd = "";						// �����v�㋒�_�R�[�h
			row.ResultsAddUpSecCd = "";						// ���ьv�㋒�_�R�[�h
			row.UpdateSecCd = "";							// �X�V���_�R�[�h
			row.SearchSlipDate = DateTime.MinValue;			// �`�[�������t
			row.ShipmentDay = DateTime.MinValue;			// �o�ד��t
			row.SalesDate = DateTime.MinValue;				// ������t
			row.AddUpADate = DateTime.MinValue;				// �v����t
			row.DelayPaymentDiv = 0;						// �����敪
			row.ClaimCode = 0;								// ������R�[�h
			row.ClaimSnm = "";								// �����旪��
			row.CustomerCode = 0;							// ���Ӑ�R�[�h
			row.CustomerName = "";							// ���Ӑ於��
			row.CustomerName2 = "";							// ���Ӑ於��2
			row.CustomerSnm = "";							// ���Ӑ旪��
			row.HonorificTitle = "";						// �h��
			row.OutputNameCode = 0;							// �����R�[�h
			row.BusinessTypeCode = 0;						// �Ǝ�R�[�h
			row.BusinessTypeName = "";						// �Ǝ햼��
			row.SalesAreaCode = 0;							// �̔��G���A�R�[�h
			row.SalesAreaName = "";							// �̔��G���A����
			row.SalesInputCode = "";						// ������͎҃R�[�h
			row.SalesInputName = "";						// ������͎Җ���
			row.FrontEmployeeCd = "";						// ��t�]�ƈ��R�[�h
			row.FrontEmployeeNm = "";						// ��t�]�ƈ�����
			row.SalesEmployeeCd = "";						// �̔��]�ƈ��R�[�h
			row.SalesEmployeeNm = "";						// �̔��]�ƈ�����
			row.TotalAmountDispWayCd = 0;					// ���z�\�����@�敪
			row.TtlAmntDispRateApy = 0;						// ���z�\���|���K�p�敪
			row.ConsTaxLayMethod = 0;						// ����œ]�ŕ���
			row.ConsTaxRate = 0;							// ����Őŗ�
			row.FractionProcCd = 0;							// �[�������敪
			row.AccRecConsTax = 0;							// ���|�����
			row.AutoDepositCd = 0;							// ���������敪
			row.AutoDepoSlipNum = 0;						// ���������`�[�ԍ�
			row.DepositAllowanceTtl = 0;					// �����������v�z
			row.DepositAlwcBlnce = 0;						// ���������c��
			row.SlipAddressDiv = 0;							// �`�[�Z���敪
			row.AddresseeCode = 0;							// �[�i��R�[�h
			row.AddresseeName = "";							// �[�i�於��
			row.AddresseeName2 = "";						// �[�i�於��2
			row.AddresseePostNo = "";						// �[�i��X�֔ԍ�
			row.AddresseeAddr1 = "";						// �[�i��Z��1(�s���{���s��S�E�����E��)
			row.AddresseeAddr2 = 0;							// �[�i��Z��2(����)
			row.AddresseeAddr3 = "";						// �[�i��Z��3(�Ԓn)
			row.AddresseeAddr4 = "";						// �[�i��Z��4(�A�p�[�g����)
			row.AddresseeTelNo = "";						// �[�i��d�b�ԍ�
			row.AddresseeFaxNo = "";						// �[�i��FAX�ԍ�
			row.PartySaleSlipNum = "";						// �����`�[�ԍ�
			row.SlipNote = "";								// �`�[���l
			row.SlipNote2 = "";								// �`�[���l�Q
			row.RetGoodsReasonDiv = 0;						// �ԕi���R�R�[�h
			row.RetGoodsReason = "";						// �ԕi���R
			row.DetailRowCount = 0;							// ���׍s��
			row.DeliveredGoodsDiv = 0;						// �[�i�敪
			row.DeliveredGoodsDivNm = "";					// �[�i�敪����
			row.ReconcileFlag = 0;							// �����t���O
			row.SlipPrtSetPaperId = "";						// �`�[����ݒ�p���[ID
			row.CompleteCd = 0;								// �ꎮ�`�[�敪
			row.ClaimType = 0;								// ������敪
			row.SalesPriceFracProcCd = 0;					// ������z�[�������敪
			row.ListPricePrintDiv = 0;						// �艿����敪
			row.EraNameDispCd1 = 0;							// �����\���敪�P
			row.CommonSeqNo = 0;							// ���ʒʔ�
			row.SalesSlipDtlNum = 0;						// ���㖾�גʔ�
			row.AcptAnOdrStatusSrc = 0;						// �󒍃X�e�[�^�X�i���j
			row.SalesSlipDtlNumSrc = 0;						// ���㖾�גʔԁi���j
			row.SupplierFormalSync = 0;						// �d���`���i�����j
			row.StockSlipDtlNumSync = 0;					// �d�����גʔԁi�����j
			row.SalesSlipCdDtl = 0;							// ����`�[�敪�i���ׁj
			row.StockMngExistCd = 0;						// �݌ɊǗ��L���敪
			row.DeliGdsCmpltDueDate = DateTime.MinValue;	// �[�i�����\���
			row.GoodsKindCode = 0;							// ���i����
			row.GoodsMakerCd = 0;							// ���i���[�J�[�R�[�h
			row.MakerName = "";								// ���[�J�[����
			row.GoodsNo = "";								// ���i�ԍ�
			row.GoodsName = "";								// ���i����
			row.GoodsShortName = "";						// ���i���̗���
			row.GoodsSetDivCd = 0;							// �Z�b�g���i�敪
			row.LargeGoodsGanreCode = "";					// ���i�敪�O���[�v�R�[�h
			row.LargeGoodsGanreName = "";					// ���i�敪�O���[�v����
			row.MediumGoodsGanreCode = "";					// ���i�敪�R�[�h
			row.MediumGoodsGanreName = "";					// ���i�敪����
			row.DetailGoodsGanreCode = "";					// ���i�敪�ڍ׃R�[�h
			row.DetailGoodsGanreName = "";					// ���i�敪�ڍז���
			row.BLGoodsCode = 0;							// BL���i�R�[�h
			row.BLGoodsFullName = "";						// BL���i�R�[�h���́i�S�p�j
			row.EnterpriseGanreCode = 0;					// ���Е��ރR�[�h
			row.EnterpriseGanreName = "";					// ���Е��ޖ���
			row.WarehouseCode = "";							// �q�ɃR�[�h
			row.WarehouseName = "";							// �q�ɖ���
			row.WarehouseShelfNo = "";						// �q�ɒI��
			row.SalesOrderDivCd = 0;						// ����݌Ɏ�񂹋敪
			row.GoodsRateRank = "";							// ���i�|�������N
			row.CustRateGrpCode = 0;						// ���Ӑ�|���O���[�v�R�[�h
			row.SuppRateGrpCode = 0;						// �d����|���O���[�v�R�[�h
			row.ListPriceRate = 0;							// �艿��
			row.RateSectPriceUnPrc = "";					// �|���ݒ苒�_�i�艿�j
			row.RateDivLPrice = "";							// �|���ݒ�敪�i�艿�j
			row.UnPrcCalcCdLPrice = 0;						// �P���Z�o�敪�i�艿�j
			row.PriceCdLPrice = 0;							// ���i�敪�i�艿�j
			row.StdUnPrcLPrice = 0;							// ��P���i�艿�j
			row.FracProcUnitLPrice = 0;						// �[�������P�ʁi�艿�j
			row.FracProcLPrice = 0;							// �[�������i�艿�j
			row.ListPriceTaxIncFl = 0;						// �艿�i�ō��C�����j
			row.ListPriceTaxExcFl = 0;						// �艿�i�Ŕ��C�����j
			row.ListPriceChngCd = 0;						// �艿�ύX�敪
			row.SalesRate = 0;								// ������
			row.RateSectSalUnPrc = "";						// �|���ݒ苒�_�i����P���j
			row.RateDivSalUnPrc = "";						// �|���ݒ�敪�i����P���j
			row.UnPrcCalcCdSalUnPrc = 0;					// �P���Z�o�敪�i����P���j
			row.PriceCdSalUnPrc = 0;						// ���i�敪�i����P���j
			row.StdUnPrcSalUnPrc = 0;						// ��P���i����P���j
			row.FracProcUnitSalUnPrc = 0;					// �[�������P�ʁi����P���j
			row.FracProcSalUnPrc = 0;						// �[�������i����P���j
			row.SalesUnPrcTaxIncFl = 0;						// ����P���i�ō��C�����j
			row.SalesUnPrcTaxExcFl = 0;						// ����P���i�Ŕ��C�����j
			row.SalesUnPrcChngCd = 0;						// ����P���ύX�敪
			row.CostRate = 0;								// ������
			row.RateSectCstUnPrc = "";						// �|���ݒ苒�_�i�����P���j
			row.RateDivUnCst = "";							// �|���ݒ�敪�i�����P���j
			row.UnPrcCalcCdUnCst = 0;						// �P���Z�o�敪�i�����P���j
			row.PriceCdUnCst = 0;							// ���i�敪�i�����P���j
			row.StdUnPrcUnCst = 0;							// ��P���i�����P���j
			row.FracProcUnitUnCst = 0;						// �[�������P�ʁi�����P���j
			row.FracProcUnCst = 0;							// �[�������i�����P���j
			row.SalesUnitCost = 0;							// �����P��
			row.SalesUnitCostChngDiv = 0;					// �����P���ύX�敪
			row.RateBLGoodsCode = 0;						// BL���i�R�[�h�i�|���j
			row.RateBLGoodsName = "";						// BL���i�R�[�h���́i�|���j
			row.ShipmentCnt = 0;							// �o�א�
			row.SalesMoneyTaxInc = 0;						// ������z�i�ō��݁j
			row.SalesMoneyTaxExc = 0;						// ������z�i�Ŕ����j
			row.Cost = 0;									// ����
			row.GrsProfitChkDiv = 0;						// �e���`�F�b�N�敪
			row.SalesGoodsCd = 0;							// ���㏤�i�敪
			row.SalsePriceConsTax = 0;						// ������z����Ŋz
			row.TaxationDivCd = 0;							// �ېŋ敪
			row.PartySlipNumDtl = "";						// �����`�[�ԍ��i���ׁj
			row.DtlNote = "";								// ���ה��l
			row.SupplierCd = 0;								// �d����R�[�h
			row.SupplierSnm = "";							// �d���旪��
			row.SlipMemo1 = "";								// �`�[�����P
			row.SlipMemo2 = "";								// �`�[�����Q
			row.SlipMemo3 = "";								// �`�[�����R
			row.SlipMemo4 = "";								// �`�[�����S
			row.SlipMemo5 = "";								// �`�[�����T
			row.SlipMemo6 = "";								// �`�[�����U
			row.InsideMemo1 = "";							// �Г������P
			row.InsideMemo2 = "";							// �Г������Q
			row.InsideMemo3 = "";							// �Г������R
			row.InsideMemo4 = "";							// �Г������S
			row.InsideMemo5 = "";							// �Г������T
			row.InsideMemo6 = "";							// �Г������U
			row.BfListPrice = 0;							// �ύX�O�艿
			row.BfSalesUnitPrice = 0;						// �ύX�O����
			row.BfUnitCost = 0;								// �ύX�O����
			row.PrtGoodsNo = "";							// ����p���i�ԍ�
			row.PrtGoodsName = "";							// ����p���i����
			row.PrtGoodsMakerCd = 0;						// ����p���i���[�J�[�R�[�h
			row.PrtGoodsMakerNm = "";						// ����p���i���[�J�[����
			row.SupplierSlipCd = 0;							// �d���`�[�敪
			row.ConfirmedDiv = false;						// �m�F�敪

			#endregion
		}

		/// <summary>
		/// ���㓯���v��I�u�W�F�N�g�̃N���A���s���܂��B�i�I�[�o�[���[�h�j
		/// </summary>
		/// <param name="stockRowNo">�N���A�Ώ۔���s�ԍ�</param>
		public void ClearSalesTempRow( int stockRowNo )
		{
			StockInputDataSet.StockDetailRow stockDetailRow = this._stockDetailDataTable.FindBySupplierSlipNoStockRowNo(this.StockSlip.SupplierSlipNo, stockRowNo);
			if (( stockDetailRow.DtlRelationGuid == null ) || ( stockDetailRow.DtlRelationGuid == Guid.Empty ))
			{
				StockInputDataSet.SalesTempRow row = this._salesTempDataTable.FindByDtlRelationGuid(stockDetailRow.DtlRelationGuid);

				if (row != null)
				{
					this.ClearSalesTempRow(row);
				}
			}
		}

		/// <summary>
		/// �Ώۍs�̔��㓯���v����擾���܂��i�I�[�o�[���[�h�j
		/// </summary>
		/// <param name="stockDetailRow">�d�����׃f�[�^�I�u�W�F�N�g</param>
		/// <returns>��������f�[�^�I�u�W�F�N�g</returns>
		public StockInputDataSet.SalesTempRow GetSalesTempRow( StockInputDataSet.StockDetailRow stockDetailRow )
		{
			StockInputDataSet.SalesTempRow retSalesTempRow = null;
			if (( stockDetailRow != null ) && ( ( !string.IsNullOrEmpty(stockDetailRow.GoodsNo.Trim()) ) || ( !string.IsNullOrEmpty(stockDetailRow.GoodsName.Trim()) ) ))
			{

				DataRow[] dataRows = stockDetailRow.GetChildRows(cRelation_Detail_SalesTemp);

				foreach (StockInputDataSet.SalesTempRow salesTempRow in dataRows)
				{
					retSalesTempRow = salesTempRow;
					break;
				}

				// ���݂��Ȃ������ꍇ�͒ǉ�����
				if (retSalesTempRow == null)
				{
					retSalesTempRow = this.SalesTempAddRow(this._currentSupplierSlipNo, stockDetailRow.StockRowNo);
				}
			}
			return retSalesTempRow;
		}


		/// <summary>
		/// �Ώۍs�̔��㓯���v����擾���܂��i�I�[�o�[���[�h�j
		/// </summary>
		/// <param name="stockRowNo">�s�ԍ�</param>
		/// <returns>��������f�[�^�I�u�W�F�N�g</returns>
		public StockInputDataSet.SalesTempRow GetSalesTempRow( int stockRowNo )
		{
            return this.GetSalesTempRow(this.GetStockDetailRow(stockRowNo));
		}

		/// <summary>
		/// �Ώێd�����׍s�̓�����������擾���܂��B
		/// </summary>
		/// <param name="stockRowNo">�d�����׍s�ԍ�</param>
		public void SettingSalesTempInfo( int stockRowNo )
		{

			SalesTemp salesTemp = null;
			StockInputDataSet.StockDetailRow stockDetailRow = this.GetStockDetailRow(stockRowNo);

			if (stockDetailRow != null)
			{
				if (( ( !string.IsNullOrEmpty(stockDetailRow.GoodsNo) ) || ( !string.IsNullOrEmpty(stockDetailRow.GoodsName) ) ) && ( this._stockSlip.StockGoodsCd == 0 ))
				{
					salesTemp = this.GetSelesTemp(stockRowNo);
				}
			}
			//this._salesTempInputAcs.SettingSalesTemp(stockRowNo, salesTemp, stockDetailRow);
		}

		/// <summary>
		/// ���㓯���v������擾���܂��B
		/// </summary>
		/// <param name="stockRowNo">���㓯���v��f�[�^�s�I�u�W�F�N�g</param>
		/// <returns>���㓯���f�[�^�I�u�W�F�N�g</returns>
		public SalesTemp GetSelesTemp( int stockRowNo )
		{
			StockInputDataSet.StockDetailRow stockDetailRow = this.GetStockDetailRow(stockRowNo);
			StockInputDataSet.SalesTempRow salesTempRow = this.GetSalesTempRow(stockDetailRow);
			SalesTemp salesTemp = null;

			if (salesTempRow != null)
			{
				if (( stockDetailRow.StockSlipCdDtl != 2 ) && ( this._stockSlip.StockGoodsCd == 0 ))
				{
					if (( stockDetailRow.GoodsNo != salesTempRow.GoodsNo ) || ( stockDetailRow.GoodsMakerCd != salesTempRow.GoodsMakerCd ) || ( salesTempRow.CustomerCode == 0 ))
					{
						this.SalesTempRowDefaultSetting(stockDetailRow, ref salesTempRow);
					}

					salesTempRow.SupplierSlipCd = this._stockSlip.SupplierSlipCd;

					this.GetUIDataFromRow(salesTempRow, out salesTemp);
				}
			}

			return salesTemp;
		}

		/// <summary>
		/// ���㓯���f�[�^�s�I�u�W�F�N�g���A���㓯���f�[�^�I�u�W�F�N�g���擾���܂��B
		/// </summary>
		/// <param name="row">���㓯���f�[�^�s�I�u�W�F�N�g</param>
		/// <param name="salesTemp">���㓯���f�[�^�I�u�W�F�N�g</param>
		private void GetUIDataFromRow( StockInputDataSet.SalesTempRow row, out SalesTemp salesTemp )
		{
			salesTemp = GetUIDataFromRow(row);
		}

		/// <summary>
		/// ���㓯���f�[�^�s�I�u�W�F�N�g��蔄�㓯���f�[�^�I�u�W�F�N�g���擾���܂��B
		/// </summary>
		/// <param name="row">���㓯���f�[�^�s�I�u�W�F�N�g</param>
		/// <returns>���㓯���f�[�^�I�u�W�F�N�g</returns>
		private SalesTemp GetUIDataFromRow( StockInputDataSet.SalesTempRow row )
		{
			SalesTemp salesTemp = new SalesTemp();

			#region �����ڃZ�b�g

			salesTemp.CreateDateTime = row.CreateDateTime;				// �쐬����
			salesTemp.UpdateDateTime = row.UpdateDateTime;				// �X�V����
			salesTemp.EnterpriseCode = row.EnterpriseCode;				// ��ƃR�[�h
			//salesTempRow.FileHeaderGuid = salesTempRow.FileHeaderGuid;				// GUID
			salesTemp.UpdEmployeeCode = row.UpdEmployeeCode;			// �X�V�]�ƈ��R�[�h
			//salesTempRow.UpdAssemblyId1 = salesTempRow.UpdAssemblyId1;				// �X�V�A�Z���u��ID1
			//salesTempRow.UpdAssemblyId2 = salesTempRow.UpdAssemblyId2;				// �X�V�A�Z���u��ID2
			salesTemp.LogicalDeleteCode = row.LogicalDeleteCode;		// �_���폜�敪
			salesTemp.AcptAnOdrStatus = row.AcptAnOdrStatus;			// �󒍃X�e�[�^�X
			//salesTempRow.SalesSlipNum = salesTempRow.SalesSlipNum;					// ����`�[�ԍ�
			salesTemp.SectionCode = row.SectionCode;					// ���_�R�[�h
			salesTemp.SubSectionCode = row.SubSectionCode;				// ����R�[�h
			salesTemp.MinSectionCode = row.MinSectionCode;				// �ۃR�[�h
			salesTemp.DebitNoteDiv = row.DebitNoteDiv;					// �ԓ`�敪
			//salesTempRow.DebitNLnkSalesSlNum = salesTempRow.DebitNLnkSalesSlNum;	// �ԍ��A������`�[�ԍ�
			salesTemp.SalesSlipCd = row.SalesSlipCd;					// ����`�[�敪
			salesTemp.AccRecDivCd = row.AccRecDivCd;					// ���|�敪
			salesTemp.SalesInpSecCd = row.SalesInpSecCd;				// ������͋��_�R�[�h
			salesTemp.DemandAddUpSecCd = row.DemandAddUpSecCd;			// �����v�㋒�_�R�[�h
			salesTemp.ResultsAddUpSecCd = row.ResultsAddUpSecCd;		// ���ьv�㋒�_�R�[�h
			salesTemp.UpdateSecCd = row.UpdateSecCd;					// �X�V���_�R�[�h
			salesTemp.SearchSlipDate = row.SearchSlipDate;				// �`�[�������t
			salesTemp.ShipmentDay = row.ShipmentDay;					// �o�ד��t
			salesTemp.SalesDate = row.SalesDate;						// ������t
			salesTemp.AddUpADate = row.AddUpADate;						// �v����t
			salesTemp.DelayPaymentDiv = row.DelayPaymentDiv;			// �����敪
			salesTemp.ClaimCode = row.ClaimCode;						// ������R�[�h
			salesTemp.ClaimSnm = row.ClaimSnm;							// �����旪��
			salesTemp.CustomerCode = row.CustomerCode;					// ���Ӑ�R�[�h
			salesTemp.CustomerName = row.CustomerName;					// ���Ӑ於��
			salesTemp.CustomerName2 = row.CustomerName2;				// ���Ӑ於��2
			salesTemp.CustomerSnm = row.CustomerSnm;					// ���Ӑ旪��
			salesTemp.HonorificTitle = row.HonorificTitle;				// �h��
			salesTemp.OutputNameCode = row.OutputNameCode;				// �����R�[�h
			salesTemp.BusinessTypeCode = row.BusinessTypeCode;			// �Ǝ�R�[�h
			salesTemp.BusinessTypeName = row.BusinessTypeName;			// �Ǝ햼��
			salesTemp.SalesAreaCode = row.SalesAreaCode;				// �̔��G���A�R�[�h
			salesTemp.SalesAreaName = row.SalesAreaName;				// �̔��G���A����
			salesTemp.SalesInputCode = row.SalesInputCode;				// ������͎҃R�[�h
			salesTemp.SalesInputName = row.SalesInputName;				// ������͎Җ���
			salesTemp.FrontEmployeeCd = row.FrontEmployeeCd;			// ��t�]�ƈ��R�[�h
			salesTemp.FrontEmployeeNm = row.FrontEmployeeNm;			// ��t�]�ƈ�����
			salesTemp.SalesEmployeeCd = row.SalesEmployeeCd;			// �̔��]�ƈ��R�[�h
			salesTemp.SalesEmployeeNm = row.SalesEmployeeNm;			// �̔��]�ƈ�����
			salesTemp.TotalAmountDispWayCd = row.TotalAmountDispWayCd;	// ���z�\�����@�敪
			salesTemp.TtlAmntDispRateApy = row.TtlAmntDispRateApy;		// ���z�\���|���K�p�敪
			salesTemp.ConsTaxLayMethod = row.ConsTaxLayMethod;			// ����œ]�ŕ���
			salesTemp.ConsTaxRate = row.ConsTaxRate;					// ����Őŗ�
			salesTemp.FractionProcCd = row.FractionProcCd;				// �[�������敪
			//salesTempRow.AccRecConsTax = salesTempRow.AccRecConsTax;				// ���|�����
			salesTemp.AutoDepositCd = row.AutoDepositCd;				// ���������敪
			salesTemp.AutoDepoSlipNum = row.AutoDepoSlipNum;			// ���������`�[�ԍ�
			//salesTempRow.DepositAllowanceTtl = salesTempRow.DepositAllowanceTtl;	// �����������v�z
			//salesTempRow.DepositAlwcBlnce = salesTempRow.DepositAlwcBlnce;			// ���������c��
			salesTemp.SlipAddressDiv = row.SlipAddressDiv;				// �`�[�Z���敪
			salesTemp.AddresseeCode = row.AddresseeCode;				// �[�i��R�[�h
			salesTemp.AddresseeName = row.AddresseeName;				// �[�i�於��
			salesTemp.AddresseeName2 = row.AddresseeName2;				// �[�i�於��2
			salesTemp.AddresseePostNo = row.AddresseePostNo;			// �[�i��X�֔ԍ�
			salesTemp.AddresseeAddr1 = row.AddresseeAddr1;				// �[�i��Z��1(�s���{���s��S�E�����E��)
			salesTemp.AddresseeAddr2 = row.AddresseeAddr2;				// �[�i��Z��2(����)
			salesTemp.AddresseeAddr3 = row.AddresseeAddr3;				// �[�i��Z��3(�Ԓn)
			salesTemp.AddresseeAddr4 = row.AddresseeAddr4;				// �[�i��Z��4(�A�p�[�g����)
			salesTemp.AddresseeTelNo = row.AddresseeTelNo;				// �[�i��d�b�ԍ�
			salesTemp.AddresseeFaxNo = row.AddresseeFaxNo;				// �[�i��FAX�ԍ�
			salesTemp.PartySaleSlipNum = row.PartySaleSlipNum;			// �����`�[�ԍ�
			salesTemp.SlipNote = row.SlipNote;							// �`�[���l
			salesTemp.SlipNote2 = row.SlipNote2;						// �`�[���l�Q
			salesTemp.RetGoodsReasonDiv = row.RetGoodsReasonDiv;		// �ԕi���R�R�[�h
			salesTemp.RetGoodsReason = row.RetGoodsReason;				// �ԕi���R
			salesTemp.DetailRowCount = row.DetailRowCount;				// ���׍s��
			salesTemp.DeliveredGoodsDiv = row.DeliveredGoodsDiv;		// �[�i�敪
			salesTemp.DeliveredGoodsDivNm = row.DeliveredGoodsDivNm;	// �[�i�敪����
			salesTemp.ReconcileFlag = row.ReconcileFlag;				// �����t���O
			salesTemp.SlipPrtSetPaperId = row.SlipPrtSetPaperId;		// �`�[����ݒ�p���[ID
			salesTemp.CompleteCd = row.CompleteCd;						// �ꎮ�`�[�敪
			salesTemp.ClaimType = row.ClaimType;						// ������敪
			salesTemp.SalesPriceFracProcCd = row.SalesPriceFracProcCd;	// ������z�[�������敪
			salesTemp.ListPricePrintDiv = row.ListPricePrintDiv;		// �艿����敪
			salesTemp.EraNameDispCd1 = row.EraNameDispCd1;				// �����\���敪�P
			salesTemp.CommonSeqNo = row.CommonSeqNo;					// ���ʒʔ�
			salesTemp.SalesSlipDtlNum = row.SalesSlipDtlNum;			// ���㖾�גʔ�
			salesTemp.AcptAnOdrStatusSrc = row.AcptAnOdrStatusSrc;		// �󒍃X�e�[�^�X�i���j
			salesTemp.SalesSlipDtlNumSrc = row.SalesSlipDtlNumSrc;		// ���㖾�גʔԁi���j
			salesTemp.SupplierFormalSync = row.SupplierFormalSync;		// �d���`���i�����j
			salesTemp.StockSlipDtlNumSync = row.StockSlipDtlNumSync;	// �d�����גʔԁi�����j
			salesTemp.SalesSlipCdDtl = row.SalesSlipCdDtl;				// ����`�[�敪�i���ׁj
			salesTemp.StockMngExistCd = row.StockMngExistCd;			// �݌ɊǗ��L���敪
			salesTemp.DeliGdsCmpltDueDate = row.DeliGdsCmpltDueDate;	// �[�i�����\���
			salesTemp.GoodsKindCode = row.GoodsKindCode;				// ���i����
			salesTemp.GoodsMakerCd = row.GoodsMakerCd;					// ���i���[�J�[�R�[�h
			salesTemp.MakerName = row.MakerName;						// ���[�J�[����
			salesTemp.GoodsNo = row.GoodsNo;							// ���i�ԍ�
			salesTemp.GoodsName = row.GoodsName;						// ���i����
			salesTemp.GoodsShortName = row.GoodsShortName;				// ���i���̗���
			salesTemp.GoodsSetDivCd = row.GoodsSetDivCd;				// �Z�b�g���i�敪
			salesTemp.LargeGoodsGanreCode = row.LargeGoodsGanreCode;	// ���i�敪�O���[�v�R�[�h
			salesTemp.LargeGoodsGanreName = row.LargeGoodsGanreName;	// ���i�敪�O���[�v����
			salesTemp.MediumGoodsGanreCode = row.MediumGoodsGanreCode;	// ���i�敪�R�[�h
			salesTemp.MediumGoodsGanreName = row.MediumGoodsGanreName;	// ���i�敪����
			salesTemp.DetailGoodsGanreCode = row.DetailGoodsGanreCode;	// ���i�敪�ڍ׃R�[�h
			salesTemp.DetailGoodsGanreName = row.DetailGoodsGanreName;	// ���i�敪�ڍז���
			salesTemp.BLGoodsCode = row.BLGoodsCode;					// BL���i�R�[�h
			salesTemp.BLGoodsFullName = row.BLGoodsFullName;			// BL���i�R�[�h���́i�S�p�j
			salesTemp.EnterpriseGanreCode = row.EnterpriseGanreCode;	// ���Е��ރR�[�h
			salesTemp.EnterpriseGanreName = row.EnterpriseGanreName;	// ���Е��ޖ���
			salesTemp.WarehouseCode = row.WarehouseCode;				// �q�ɃR�[�h
			salesTemp.WarehouseName = row.WarehouseName;				// �q�ɖ���
			salesTemp.WarehouseShelfNo = row.WarehouseShelfNo;			// �q�ɒI��
			salesTemp.SalesOrderDivCd = row.SalesOrderDivCd;			// ����݌Ɏ�񂹋敪
			salesTemp.GoodsRateRank = row.GoodsRateRank;				// ���i�|�������N
			salesTemp.CustRateGrpCode = row.CustRateGrpCode;			// ���Ӑ�|���O���[�v�R�[�h
			salesTemp.SuppRateGrpCode = row.SuppRateGrpCode;			// �d����|���O���[�v�R�[�h
			salesTemp.ListPriceRate = row.ListPriceRate;				// �艿��
			salesTemp.RateSectPriceUnPrc = row.RateSectPriceUnPrc;		// �|���ݒ苒�_�i�艿�j
			salesTemp.RateDivLPrice = row.RateDivLPrice;				// �|���ݒ�敪�i�艿�j
			salesTemp.UnPrcCalcCdLPrice = row.UnPrcCalcCdLPrice;		// �P���Z�o�敪�i�艿�j
			salesTemp.PriceCdLPrice = row.PriceCdLPrice;				// ���i�敪�i�艿�j
			salesTemp.StdUnPrcLPrice = row.StdUnPrcLPrice;				// ��P���i�艿�j
			salesTemp.FracProcUnitLPrice = row.FracProcUnitLPrice;		// �[�������P�ʁi�艿�j
			salesTemp.FracProcLPrice = row.FracProcLPrice;				// �[�������i�艿�j
			salesTemp.ListPriceTaxIncFl = row.ListPriceTaxIncFl;		// �艿�i�ō��C�����j
			salesTemp.ListPriceTaxExcFl = row.ListPriceTaxExcFl;		// �艿�i�Ŕ��C�����j
			salesTemp.ListPriceChngCd = row.ListPriceChngCd;			// �艿�ύX�敪
			salesTemp.SalesRate = row.SalesRate;						// ������
			salesTemp.RateSectSalUnPrc = row.RateSectSalUnPrc;			// �|���ݒ苒�_�i����P���j
			salesTemp.RateDivSalUnPrc = row.RateDivSalUnPrc;			// �|���ݒ�敪�i����P���j
			salesTemp.UnPrcCalcCdSalUnPrc = row.UnPrcCalcCdSalUnPrc;	// �P���Z�o�敪�i����P���j
			salesTemp.PriceCdSalUnPrc = row.PriceCdSalUnPrc;			// ���i�敪�i����P���j
			salesTemp.StdUnPrcSalUnPrc = row.StdUnPrcSalUnPrc;			// ��P���i����P���j
			salesTemp.FracProcUnitSalUnPrc = row.FracProcUnitSalUnPrc;	// �[�������P�ʁi����P���j
			salesTemp.FracProcSalUnPrc = row.FracProcSalUnPrc;			// �[�������i����P���j
			salesTemp.SalesUnPrcTaxIncFl = row.SalesUnPrcTaxIncFl;		// ����P���i�ō��C�����j
			salesTemp.SalesUnPrcTaxExcFl = row.SalesUnPrcTaxExcFl;		// ����P���i�Ŕ��C�����j
			salesTemp.SalesUnPrcChngCd = row.SalesUnPrcChngCd;			// ����P���ύX�敪
			salesTemp.CostRate = row.CostRate;							// ������
			salesTemp.RateSectCstUnPrc = row.RateSectCstUnPrc;			// �|���ݒ苒�_�i�����P���j
			salesTemp.RateDivUnCst = row.RateDivUnCst;					// �|���ݒ�敪�i�����P���j
			salesTemp.UnPrcCalcCdUnCst = row.UnPrcCalcCdUnCst;			// �P���Z�o�敪�i�����P���j
			salesTemp.PriceCdUnCst = row.PriceCdUnCst;					// ���i�敪�i�����P���j
			salesTemp.StdUnPrcUnCst = row.StdUnPrcUnCst;				// ��P���i�����P���j
			salesTemp.FracProcUnitUnCst = row.FracProcUnitUnCst;		// �[�������P�ʁi�����P���j
			salesTemp.FracProcUnCst = row.FracProcUnCst;				// �[�������i�����P���j
			salesTemp.SalesUnitCost = row.SalesUnitCost;				// �����P��
			salesTemp.SalesUnitCostChngDiv = row.SalesUnitCostChngDiv;	// �����P���ύX�敪
			salesTemp.RateBLGoodsCode = row.RateBLGoodsCode;			// BL���i�R�[�h�i�|���j
			salesTemp.RateBLGoodsName = row.RateBLGoodsName;			// BL���i�R�[�h���́i�|���j
			salesTemp.ShipmentCnt = row.ShipmentCnt;					// �o�א�
			salesTemp.AcptAnOdrRemainCnt = row.AcceptAnOrderCnt;		// �󒍎c
			salesTemp.SalesMoneyTaxInc = row.SalesMoneyTaxInc;			// ������z�i�ō��݁j
			salesTemp.SalesMoneyTaxExc = row.SalesMoneyTaxExc;			// ������z�i�Ŕ����j
			salesTemp.Cost = row.Cost;									// ����
			salesTemp.GrsProfitChkDiv = row.GrsProfitChkDiv;			// �e���`�F�b�N�敪
			salesTemp.SalesGoodsCd = row.SalesGoodsCd;					// ���㏤�i�敪
			salesTemp.SalsePriceConsTax = row.SalsePriceConsTax;		// ������z����Ŋz
			salesTemp.TaxationDivCd = row.TaxationDivCd;				// �ېŋ敪
			salesTemp.PartySlipNumDtl = row.PartySlipNumDtl;			// �����`�[�ԍ��i���ׁj
			salesTemp.DtlNote = row.DtlNote;							// ���ה��l
			salesTemp.SupplierCd = row.SupplierCd;						// �d����R�[�h
			salesTemp.SupplierSnm = row.SupplierSnm;					// �d���旪��
			salesTemp.SlipMemo1 = row.SlipMemo1;						// �`�[�����P
			salesTemp.SlipMemo2 = row.SlipMemo2;						// �`�[�����Q
			salesTemp.SlipMemo3 = row.SlipMemo3;						// �`�[�����R
			salesTemp.SlipMemo4 = row.SlipMemo4;						// �`�[�����S
			salesTemp.SlipMemo5 = row.SlipMemo5;						// �`�[�����T
			salesTemp.SlipMemo6 = row.SlipMemo6;						// �`�[�����U
			salesTemp.InsideMemo1 = row.InsideMemo1;					// �Г������P
			salesTemp.InsideMemo2 = row.InsideMemo2;					// �Г������Q
			salesTemp.InsideMemo3 = row.InsideMemo3;					// �Г������R
			salesTemp.InsideMemo4 = row.InsideMemo4;					// �Г������S
			salesTemp.InsideMemo5 = row.InsideMemo5;					// �Г������T
			salesTemp.InsideMemo6 = row.InsideMemo6;					// �Г������U
			salesTemp.BfListPrice = row.BfListPrice;					// �ύX�O�艿
			salesTemp.BfSalesUnitPrice = row.BfSalesUnitPrice;			// �ύX�O����
			salesTemp.BfUnitCost = row.BfUnitCost;						// �ύX�O����
			salesTemp.PrtGoodsNo = row.PrtGoodsNo;						// ����p���i�ԍ�
			salesTemp.PrtGoodsName = row.PrtGoodsName;					// ����p���i����
			salesTemp.PrtGoodsMakerCd = row.PrtGoodsMakerCd;			// ����p���i���[�J�[�R�[�h
			salesTemp.PrtGoodsMakerNm = row.PrtGoodsMakerNm;			// ����p���i���[�J�[����
			salesTemp.SupplierSlipCd = row.SupplierSlipCd;				// �d���`�[																																								�敪
			salesTemp.ConfirmedDiv = row.ConfirmedDiv;					// �m�F�敪

			#endregion

			if (salesTemp.GoodsShortName.Length > 15)
			{
				salesTemp.GoodsShortName = salesTemp.GoodsShortName.Substring(0, 15);
			}

			return salesTemp;
		}

		/// <summary>
		/// ���㓯���v���񏉊��l�ݒ�
		/// </summary>
		/// <param name="stockDetailRow"></param>
		/// <param name="salesTempRow"></param>
		private void SalesTempRowDefaultSetting( StockInputDataSet.StockDetailRow stockDetailRow, ref StockInputDataSet.SalesTempRow salesTempRow )
		{
			//salesTempRow = new StockInputDataSet.SalesTempRow();

			this.ClearSalesTempRow(salesTempRow);

			#region �����ڃZ�b�g

			//salesTempRow.AcptAnOdrStatus = 30;												// �󒍃X�e�[�^�X
            //salesTempRow.AcptAnOdrStatus = ( this._stockSlipInputInitDataAcs.GetSalesTtlSt().SalesFormalIn == 0 ) ? 30 : 40;	// �󒍃X�e�[�^�X�͔���S�̐ݒ�ɏ]���ăZ�b�g
			salesTempRow.SectionCode = LoginInfoAcquisition.Employee.BelongSectionCode.Trim();	// ���_�R�[�h
			salesTempRow.SubSectionCode = this._stockSlip.SubSectionCode;						// ����R�[�h
			//salesTempRow.MinSectionCode = this._stockSlip.MinSectionCode;						// �ۃR�[�h
			
			//salesTempRow.DebitNoteDiv = this._stockSlip.DebitNoteDiv;						// �ԓ`�敪
			//salesTempRow.DebitNLnkAcptAnOdr = salesTempRow.DebitNLnkAcptAnOdr;						// �ԍ��A���󒍔ԍ�
			salesTempRow.SalesSlipCd = ( this._stockSlip.SupplierSlipCd == 10 ) ? 0 : 1;		// ����`�[�敪
			salesTempRow.AccRecDivCd = this._stockSlip.AccPayDivCd;							// ���|�敪
			salesTempRow.SupplierFormalSync = this._stockSlip.SupplierFormal;					// �d���`���i�����j
			//salesTempRow.ServiceSlipCd = salesTempRow.ServiceSlipCd;									// �T�[�r�X�`�[�敪
			salesTempRow.SalesInpSecCd = this._stockSlip.StockSectionCd.Trim();				// ������͋��_�R�[�h
			salesTempRow.DemandAddUpSecCd = this._stockSlip.StockAddUpSectionCd.Trim();		// �����v�㋒�_�R�[�h
			salesTempRow.ResultsAddUpSecCd = this._stockSlip.StockSectionCd.Trim();			// ���ьv�㋒�_�R�[�h
			salesTempRow.UpdateSecCd = this._stockSlip.SectionCode.Trim();						// �X�V���_�R�[�h
			salesTempRow.SearchSlipDate = DateTime.Today;										// �`�[�������t
			salesTempRow.ShipmentDay = this._stockSlip.ArrivalGoodsDay;						// �o�ד��t
			salesTempRow.SalesDate = ( this._stockSlip.SupplierFormal == 0 ) ? this._stockSlip.StockDate : this._stockSlip.ArrivalGoodsDay;	// ������t
			salesTempRow.AddUpADate = ( this._stockSlip.SupplierFormal == 0 ) ? this._stockSlip.StockDate : this._stockSlip.ArrivalGoodsDay;	// �v����t
			salesTempRow.DelayPaymentDiv = 0;													// �����敪
			salesTempRow.SalesInputCode = this._stockSlip.StockInputCode.Trim();				// ������͎҃R�[�h
			salesTempRow.SalesInputName = this._stockSlip.StockInputName.Trim();				// ������͎Җ���
			//salesTempRow.FrontEmployeeCd = salesTempRow.FrontEmployeeCd;								// ��t�]�ƈ��R�[�h
			//salesTempRow.FrontEmployeeNm = salesTempRow.FrontEmployeeNm;								// ��t�]�ƈ�����
			salesTempRow.SalesEmployeeCd = this._stockSlip.StockAgentCode.Trim();				// �̔��]�ƈ��R�[�h
			salesTempRow.SalesEmployeeNm = this._stockSlip.StockAgentName.Trim();				// �̔��]�ƈ�����
			//salesTempRow.TotalAmountDispWayCd = 0;											// ���z�\�����@�敪
			//salesTempRow.TtlAmntDispRateApy = 0;												// ���z�\���|���K�p�敪
			//salesTempRow.ConsTaxLayMethod = 0;												// ����œ]�ŕ���
			salesTempRow.ConsTaxRate = this._stockSlipInputInitDataAcs.GetTaxRate(( this._stockSlip.SupplierFormal == 0 ) ? this._stockSlip.StockDate : this._stockSlip.ArrivalGoodsDay); // ����Őŗ�
			//salesTempRow.FractionProcCd = 0;													// �[�������敪
			//salesTempRow.AutoDepositCd = 0;													// ���������敪
			//salesTempRow.ClaimCode = stockDetailRow.ClaimCode;								// ������R�[�h
			//salesTempRow.ClaimSnm = stockDetailRow.ClaimSnm;									// �����旪��
			//salesTempRow.CustomerCode = stockDetailRow.CustomerCode;							// ���Ӑ�R�[�h
			//salesTempRow.CustomerName = stockDetailRow.CustomerName;							// ���Ӑ於��
			//salesTempRow.CustomerName2 = stockDetailRow.CustomerName2;						// ���Ӑ於��2
			//salesTempRow.CustomerSnm = stockDetailRow.CustomerSnm;							// ���Ӑ旪��
			//salesTempRow.HonorificTitle = stockDetailRow.HonorificTitle;						// �h��
			//salesTempRow.OutputNameCode = stockDetailRow.OutputNameCode;						// �����R�[�h
			//salesTempRow.SlipAddressDiv = stockDetailRow.SlipAddressDiv;						// �`�[�Z���敪
			//salesTempRow.AddresseeCode = stockDetailRow.AddresseeCode;						// �[�i��R�[�h
			//salesTempRow.AddresseeName = stockDetailRow.AddresseeName;						// �[�i�於��
			//salesTempRow.AddresseeName2 = stockDetailRow.AddresseeName2;						// �[�i�於��2
			//salesTempRow.PostNo = stockDetailRow.PostNo;										// �X�֔ԍ�
			//salesTempRow.AddresseeAddr1 = stockDetailRow.AddresseeAddr1;						// �[�i��Z��1(�s���{���s��S�E�����E��)
			//salesTempRow.AddresseeAddr2 = stockDetailRow.AddresseeAddr2;						// �[�i��Z��2(����)
			//salesTempRow.AddresseeAddr3 = stockDetailRow.AddresseeAddr3;						// �[�i��Z��3(�Ԓn)
			//salesTempRow.AddresseeAddr4 = stockDetailRow.AddresseeAddr4;						// �[�i��Z��4(�A�p�[�g����)
			//salesTempRow.AddresseeTelNo = stockDetailRow.AddresseeTelNo;						// �[�i��d�b�ԍ�
			//salesTempRow.OfficeFaxNo = stockDetailRow.OfficeFaxNo;							// FAX�ԍ��i�Ζ���j
			//salesTempRow.PartySaleSlipNum = stockDetailRow.PartySaleSlipNum;					// �����`�[�ԍ�
			//salesTempRow.SlipNote = stockDetailRow.SlipNote;									// �`�[���l
			//salesTempRow.SlipNote2 = stockDetailRow.SlipNote2;								// �`�[���l�Q
			//salesTempRow.RetGoodsReasonDiv = stockDetailRow.RetGoodsReasonDiv;				// �ԕi���R�R�[�h
			//salesTempRow.RetGoodsReason = stockDetailRow.RetGoodsReason;						// �ԕi���R
			//salesTempRow.CashRegisterNo = stockDetailRow.CashRegisterNo;						// ���W�ԍ�
			//salesTempRow.DetailRowCount = stockDetailRow.DetailRowCount;						// ���׍s��
			//salesTempRow.BusinessTypeCode = stockDetailRow.BusinessTypeCode;					// �Ǝ�R�[�h
			//salesTempRow.BusinessTypeName = stockDetailRow.BusinessTypeName;					// �Ǝ햼��
			//salesTempRow.DeliveredGoodsDiv = stockDetailRow.DeliveredGoodsDiv;				// �[�i�敪
			//salesTempRow.DeliveredGoodsDivNm = stockDetailRow.DeliveredGoodsDivNm;			// �[�i�敪����
			//salesTempRow.SalesAreaCode = stockDetailRow.SalesAreaCode;						// �̔��G���A�R�[�h
			//salesTempRow.SalesAreaName = stockDetailRow.SalesAreaName;						// �̔��G���A����
			//salesTempRow.ReconcileFlag = stockDetailRow.ReconcileFlag;						// �����t���O
			//salesTempRow.SlipPrtSetPaperId = stockDetailRow.SlipPrtSetPaperId;				// �`�[����ݒ�p���[ID
			//salesTempRow.CompleteCd = stockDetailRow.CompleteCd;								// �ꎮ�`�[�敪
			//salesTempRow.ClaimType = stockDetailRow.ClaimType;								// ������敪
			//salesTempRow.SalesPriceFracProcCd = stockDetailRow.SalesPriceFracProcCd;			// ������z�[�������敪
			//salesTempRow.ListPricePrintDiv = stockDetailRow.ListPricePrintDiv;				// �艿����敪
			//salesTempRow.EraNameDispCd1 = stockDetailRow.EraNameDispCd1;						// �����\���敪�P
			//salesTempRow.SalesSlipCdDtl = stockDetailRow.SalesSlipCdDtl;						// ����`�[�敪�i���ׁj
			//salesTempRow.SalesDepositsDiv = stockDetailRow.SalesDepositsDiv;					// ����a����敪
			//salesTempRow.DeliGdsCmpltDueDate = stockDetailRow.DeliGdsCmpltDueDate;			// �[�i�����\���
			salesTempRow.GoodsKindCode = stockDetailRow.GoodsKindCode;							// ���i����
			salesTempRow.GoodsMakerCd = stockDetailRow.GoodsMakerCd;							//  ���i���[�J�[�R�[�h
			salesTempRow.MakerName = stockDetailRow.MakerName;									// ���[�J�[����
			salesTempRow.GoodsNo = stockDetailRow.GoodsNo;										// ���i�ԍ�
			salesTempRow.GoodsName = stockDetailRow.GoodsName;									// ���i����
			//salesTempRow.GoodsSetDivCd = stockDetailRow.GoodsSetDivCd;						// �Z�b�g���i�敪
			//salesTempRow.LargeGoodsGanreCode = stockDetailRow.LargeGoodsGanreCode;				// ���i�敪�O���[�v�R�[�h
			//salesTempRow.LargeGoodsGanreName = stockDetailRow.LargeGoodsGanreName;				// ���i�敪�O���[�v����
			//salesTempRow.MediumGoodsGanreCode = stockDetailRow.MediumGoodsGanreCode;			// ���i�敪�R�[�h
			//salesTempRow.MediumGoodsGanreName = stockDetailRow.MediumGoodsGanreName;			// ���i�敪����
			//salesTempRow.DetailGoodsGanreCode = stockDetailRow.DetailGoodsGanreCode;			// ���i�敪�ڍ׃R�[�h
			//salesTempRow.DetailGoodsGanreName = stockDetailRow.DetailGoodsGanreName;			// ���i�敪�ڍז���
			salesTempRow.BLGoodsCode = stockDetailRow.BLGoodsCode;								// BL���i�R�[�h
			salesTempRow.BLGoodsFullName = stockDetailRow.BLGoodsFullName;						// BL���i�R�[�h���́i�S�p�j
			salesTempRow.RateBLGoodsCode = stockDetailRow.RateBLGoodsCode;						// BL���i�R�[�h(�|��)
			salesTempRow.RateBLGoodsName = stockDetailRow.RateBLGoodsName;						// BL���i�R�[�h����(�|��)
			salesTempRow.EnterpriseGanreCode = stockDetailRow.EnterpriseGanreCode;				// ���Е��ރR�[�h
			salesTempRow.EnterpriseGanreName = stockDetailRow.EnterpriseGanreName;				// ���Е��ޖ���
			salesTempRow.WarehouseCode = stockDetailRow.WarehouseCode;							// �q�ɃR�[�h
			salesTempRow.WarehouseName = stockDetailRow.WarehouseName;							// �q�ɖ���
			salesTempRow.WarehouseShelfNo = stockDetailRow.WarehouseShelfNo;					// �q�ɒI��
			//salesTempRow.SalesOrderDivCd = stockDetailRow.SalesOrderDivCd;					// ����݌Ɏ�񂹋敪
			//salesTempRow.UnitCode = stockDetailRow.UnitCode;									// �P�ʃR�[�h
			//salesTempRow.UnitName = stockDetailRow.UnitName;									// �P�ʖ���
			salesTempRow.GoodsRateRank = stockDetailRow.GoodsRateRank;							// ���i�|�������N
			salesTempRow.CustRateGrpCode = stockDetailRow.CustRateGrpCode;						// ���Ӑ�|���O���[�v�R�[�h
			//salesTempRow.SuppRateGrpCode = stockDetailRow.SuppRateGrpCode;						// �d����|���O���[�v�R�[�h
			salesTempRow.SuppRateGrpCode = this._stockSlip.SuppRateGrpCode;					// �d����|���O���[�v�R�[�h
			//salesTempRow.ListPriceRate = stockDetailRow.ListPriceRate;						// �艿��
			//salesTempRow.RateDivLPrice = stockDetailRow.RateDivLPrice;						// �|���ݒ�敪�i�艿�j
			//salesTempRow.UnPrcCalcCdLPrice = stockDetailRow.UnPrcCalcCdLPrice;				// �P���Z�o�敪�i�艿�j
			//salesTempRow.PriceCdLPrice = stockDetailRow.PriceCdLPrice;						// ���i�敪�i�艿�j
			//salesTempRow.StdUnPrcLPrice = stockDetailRow.StdUnPrcLPrice;						// ��P���i�艿�j
			//salesTempRow.FracProcUnitLPrice = stockDetailRow.FracProcUnitLPrice;				// �[�������P�ʁi�艿�j
			//salesTempRow.FracProcLPrice = stockDetailRow.FracProcLPrice;						// �[�������i�艿�j
			//salesTempRow.ListPriceTaxIncFl = stockDetailRow.ListPriceTaxIncFl;				// �艿�i�ō��C�����j
			//salesTempRow.ListPriceTaxExcFl = stockDetailRow.ListPriceTaxExcFl;				// �艿�i�Ŕ��C�����j
			//salesTempRow.ListPriceChngCd = stockDetailRow.ListPriceChngCd;					// �艿�ύX�敪
			//salesTempRow.SalesRate = stockDetailRow.SalesRate;								// ������
			//salesTempRow.RateDivSalUnPrc = stockDetailRow.RateDivSalUnPrc;					// �|���ݒ�敪�i����P���j
			//salesTempRow.UnPrcCalcCdSalUnPrc = stockDetailRow.UnPrcCalcCdSalUnPrc;			// �P���Z�o�敪�i����P���j
			//salesTempRow.PriceCdSalUnPrc = stockDetailRow.PriceCdSalUnPrc;					// ���i�敪�i����P���j
			//salesTempRow.StdUnPrcSalUnPrc = stockDetailRow.StdUnPrcSalUnPrc;					// ��P���i����P���j
			//salesTempRow.FracProcUnitSalUnPrc = stockDetailRow.FracProcUnitSalUnPrc;			// �[�������P�ʁi����P���j
			//salesTempRow.FracProcSalUnPrc = stockDetailRow.FracProcSalUnPrc;					// �[�������i����P���j
			//salesTempRow.SalesUnPrcTaxIncFl = stockDetailRow.SalesUnPrcTaxIncFl;				// ����P���i�ō��C�����j
			//salesTempRow.SalesUnPrcTaxExcFl = stockDetailRow.SalesUnPrcTaxExcFl;				// ����P���i�Ŕ��C�����j
			//salesTempRow.SalesUnPrcChngCd = stockDetailRow.SalesUnPrcChngCd;					// ����P���ύX�敪
			//salesTempRow.CostRate = stockDetailRow.CostRate;									// ������
			//salesTempRow.RateDivUnCst = stockDetailRow.RateDivUnCst;							// �|���ݒ�敪�i�����P���j
			//salesTempRow.UnPrcCalcCdUnCst = stockDetailRow.UnPrcCalcCdUnCst;					// �P���Z�o�敪�i�����P���j
			//salesTempRow.PriceCdUnCst = stockDetailRow.PriceCdUnCst;							// ���i�敪�i�����P���j
			//salesTempRow.StdUnPrcUnCst = stockDetailRow.StdUnPrcUnCst;						// ��P���i�����P���j
			//salesTempRow.FracProcUnitUnCst = stockDetailRow.FracProcUnitUnCst;				// �[�������P�ʁi�����P���j
			//salesTempRow.FracProcUnCst = stockDetailRow.FracProcUnCst;						// �[�������i�����P���j
			//salesTempRow.SalesUnitCost = stockDetailRow.SalesUnitCost;						// �����P��
			//salesTempRow.SalesUnitCostChngDiv = stockDetailRow.SalesUnitCostChngDiv;			// �����P���ύX�敪
			//salesTempRow.BargainCd = stockDetailRow.BargainCd;									// �����敪�R�[�h
			//salesTempRow.BargainNm = stockDetailRow.BargainNm;									// �����敪����
			salesTempRow.ShipmentCnt = stockDetailRow.StockCountDisplay;						// �o�א�
			//salesTempRow.SalesMoneyTaxInc = stockDetailRow.SalesMoneyTaxInc;					// ������z�i�ō��݁j
			//salesTempRow.SalesMoneyTaxExc = stockDetailRow.SalesMoneyTaxExc;					// ������z�i�Ŕ����j
			//salesTempRow.Cost = stockDetailRow.Cost;											// ����
			//salesTempRow.GrsProfitChkDiv = stockDetailRow.GrsProfitChkDiv;					// �e���`�F�b�N�敪
			salesTempRow.TaxationDivCd = stockDetailRow.TaxationCode;							// �ېŋ敪
			//salesTempRow.SalesGoodsCd = stockDetailRow.SalesGoodsCd;							// ���㏤�i�敪
			//salesTempRow.PartySlipNumDtl = stockDetailRow.PartySlipNumDtl;					// �����`�[�ԍ��i���ׁj
			//salesTempRow.DtlNote = stockDetailRow.DtlNote;									// ���ה��l
			//salesTempRow.SupplierCd = stockDetailRow.SupplierCd;								// �d����R�[�h
			salesTempRow.SupplierCd = this._stockSlip.SupplierCd;								// �d����R�[�h
			//salesTempRow.SupplierSnm = stockDetailRow.SupplierSnm;								// �d���旪��
			salesTempRow.SupplierSnm = this._stockSlip.SupplierSnm;								// �d���旪��
			salesTempRow.OrderNumber = stockDetailRow.OrderNumber;								// �����ԍ�
			//salesTempRow.AcceptAnOrderCnt = stockDetailRow.AcceptAnOrderCnt;					// �󒍐���
			//salesTempRow.AcptAnOdrAdjustCnt = stockDetailRow.AcptAnOdrAdjustCnt;				// �󒍒�����
			//salesTempRow.AcptAnOdrRemainCnt = stockDetailRow.AcptAnOdrRemainCnt;				// �󒍎c��
			//salesTempRow.SlipMemo1 = stockDetailRow.SlipMemo1;								// �`�[�����P
			//salesTempRow.SlipMemo2 = stockDetailRow.SlipMemo2;								// �`�[�����Q
			//salesTempRow.SlipMemo3 = stockDetailRow.SlipMemo3;								// �`�[�����R
			//salesTempRow.SlipMemo4 = stockDetailRow.SlipMemo4;								// �`�[�����S
			//salesTempRow.SlipMemo5 = stockDetailRow.SlipMemo5;								// �`�[�����T
			//salesTempRow.SlipMemo6 = stockDetailRow.SlipMemo6;								// �`�[�����U
			//salesTempRow.InsideMemo1 = stockDetailRow.InsideMemo1;							// �Г������P
			//salesTempRow.InsideMemo2 = stockDetailRow.InsideMemo2;							// �Г������Q
			//salesTempRow.InsideMemo3 = stockDetailRow.InsideMemo3;							// �Г������R
			//salesTempRow.InsideMemo4 = stockDetailRow.InsideMemo4;							// �Г������S
			//salesTempRow.InsideMemo5 = stockDetailRow.InsideMemo5;							// �Г������T
			//salesTempRow.InsideMemo6 = stockDetailRow.InsideMemo6;							// �Г������U
			//salesTempRow.BfListPrice = stockDetailRow.BfListPrice;							// �ύX�O�艿
			//salesTempRow.BfSalesUnitPrice = stockDetailRow.BfSalesUnitPrice;					// �ύX�O����
			//salesTempRow.BfUnitCost = stockDetailRow.BfUnitCost;								// �ύX�O����
			//salesTempRow.PrtGoodsNo = stockDetailRow.PrtGoodsNo;								// ����p���i�ԍ�
			//salesTempRow.PrtGoodsName = stockDetailRow.PrtGoodsName;							// ����p���i����
			salesTempRow.PrtGoodsMakerCd = stockDetailRow.GoodsMakerCd;						// ����p���i���[�J�[�R�[�h
			salesTempRow.PrtGoodsMakerNm = stockDetailRow.GoodsName;							// ����p���i���[�J�[����
			salesTempRow.ConfirmedDiv = false;

			#endregion
		}

		/// <summary>
		/// ������������L���b�V�����܂��B�i�I�[�o�[���[�h�j
		/// </summary>
		/// <param name="stockRowNo">�s�ԍ�</param>
		/// <param name="salesTemp">���㓯���f�[�^�I�u�W�F�N�g</param>
		private void CacheSalesTemp( int stockRowNo, SalesTemp salesTemp )
		{
			StockInputDataSet.SalesTempRow salesTempRow = this.GetSalesTempRow(stockRowNo);

			#region �����ڃZ�b�g

			salesTempRow.CreateDateTime = salesTemp.CreateDateTime;				// �쐬����
			salesTempRow.UpdateDateTime = salesTemp.UpdateDateTime;				// �X�V����
			salesTempRow.EnterpriseCode = salesTemp.EnterpriseCode;				// ��ƃR�[�h
			//salesTempRow.FileHeaderGuid = salesTempRow.FileHeaderGuid;				// GUID
			salesTempRow.UpdEmployeeCode = salesTemp.UpdEmployeeCode;			// �X�V�]�ƈ��R�[�h
			//salesTempRow.UpdAssemblyId1 = salesTempRow.UpdAssemblyId1;				// �X�V�A�Z���u��ID1
			//salesTempRow.UpdAssemblyId2 = salesTempRow.UpdAssemblyId2;				// �X�V�A�Z���u��ID2
			salesTempRow.LogicalDeleteCode = salesTemp.LogicalDeleteCode;		// �_���폜�敪
			salesTempRow.AcptAnOdrStatus = salesTemp.AcptAnOdrStatus;			// �󒍃X�e�[�^�X
			//salesTempRow.SalesSlipNum = salesTempRow.SalesSlipNum;					// ����`�[�ԍ�
			salesTempRow.SectionCode = salesTemp.SectionCode;					// ���_�R�[�h
			salesTempRow.SubSectionCode = salesTemp.SubSectionCode;				// ����R�[�h
			salesTempRow.MinSectionCode = salesTemp.MinSectionCode;				// �ۃR�[�h
			salesTempRow.DebitNoteDiv = salesTemp.DebitNoteDiv;					// �ԓ`�敪
			//salesTempRow.DebitNLnkSalesSlNum = salesTempRow.DebitNLnkSalesSlNum;	// �ԍ��A������`�[�ԍ�
			salesTempRow.SalesSlipCd = salesTemp.SalesSlipCd;					// ����`�[�敪
			salesTempRow.AccRecDivCd = salesTemp.AccRecDivCd;					// ���|�敪
			salesTempRow.SalesInpSecCd = salesTemp.SalesInpSecCd;				// ������͋��_�R�[�h
			salesTempRow.DemandAddUpSecCd = salesTemp.DemandAddUpSecCd;			// �����v�㋒�_�R�[�h
			salesTempRow.ResultsAddUpSecCd = salesTemp.ResultsAddUpSecCd;		// ���ьv�㋒�_�R�[�h
			salesTempRow.UpdateSecCd = salesTemp.UpdateSecCd;					// �X�V���_�R�[�h
			salesTempRow.SearchSlipDate = salesTemp.SearchSlipDate;				// �`�[�������t
			salesTempRow.ShipmentDay = salesTemp.ShipmentDay;					// �o�ד��t
			salesTempRow.SalesDate = salesTemp.SalesDate;						// ������t
			salesTempRow.AddUpADate = salesTemp.AddUpADate;						// �v����t
			salesTempRow.DelayPaymentDiv = salesTemp.DelayPaymentDiv;			// �����敪
			salesTempRow.ClaimCode = salesTemp.ClaimCode;						// ������R�[�h
			salesTempRow.ClaimSnm = salesTemp.ClaimSnm;							// �����旪��
			salesTempRow.CustomerCode = salesTemp.CustomerCode;					// ���Ӑ�R�[�h
			salesTempRow.CustomerName = salesTemp.CustomerName;					// ���Ӑ於��
			salesTempRow.CustomerName2 = salesTemp.CustomerName2;				// ���Ӑ於��2
			salesTempRow.CustomerSnm = salesTemp.CustomerSnm;					// ���Ӑ旪��
			salesTempRow.HonorificTitle = salesTemp.HonorificTitle;				// �h��
			salesTempRow.OutputNameCode = salesTemp.OutputNameCode;				// �����R�[�h
			salesTempRow.BusinessTypeCode = salesTemp.BusinessTypeCode;			// �Ǝ�R�[�h
			salesTempRow.BusinessTypeName = salesTemp.BusinessTypeName;			// �Ǝ햼��
			salesTempRow.SalesAreaCode = salesTemp.SalesAreaCode;				// �̔��G���A�R�[�h
			salesTempRow.SalesAreaName = salesTemp.SalesAreaName;				// �̔��G���A����
			salesTempRow.SalesInputCode = salesTemp.SalesInputCode;				// ������͎҃R�[�h
			salesTempRow.SalesInputName = salesTemp.SalesInputName;				// ������͎Җ���
			salesTempRow.FrontEmployeeCd = salesTemp.FrontEmployeeCd;			// ��t�]�ƈ��R�[�h
			salesTempRow.FrontEmployeeNm = salesTemp.FrontEmployeeNm;			// ��t�]�ƈ�����
			salesTempRow.SalesEmployeeCd = salesTemp.SalesEmployeeCd;			// �̔��]�ƈ��R�[�h
			salesTempRow.SalesEmployeeNm = salesTemp.SalesEmployeeNm;			// �̔��]�ƈ�����
			salesTempRow.TotalAmountDispWayCd = salesTemp.TotalAmountDispWayCd;	// ���z�\�����@�敪
			salesTempRow.TtlAmntDispRateApy = salesTemp.TtlAmntDispRateApy;		// ���z�\���|���K�p�敪
			salesTempRow.ConsTaxLayMethod = salesTemp.ConsTaxLayMethod;			// ����œ]�ŕ���
			salesTempRow.ConsTaxRate = salesTemp.ConsTaxRate;					// ����Őŗ�
			salesTempRow.FractionProcCd = salesTemp.FractionProcCd;				// �[�������敪
			//salesTempRow.AccRecConsTax = salesTempRow.AccRecConsTax;				// ���|�����
			salesTempRow.AutoDepositCd = salesTemp.AutoDepositCd;				// ���������敪
			salesTempRow.AutoDepoSlipNum = salesTemp.AutoDepoSlipNum;			// ���������`�[�ԍ�
			//salesTempRow.DepositAllowanceTtl = salesTempRow.DepositAllowanceTtl;	// �����������v�z
			//salesTempRow.DepositAlwcBlnce = salesTempRow.DepositAlwcBlnce;			// ���������c��
			salesTempRow.SlipAddressDiv = salesTemp.SlipAddressDiv;				// �`�[�Z���敪
			salesTempRow.AddresseeCode = salesTemp.AddresseeCode;				// �[�i��R�[�h
			salesTempRow.AddresseeName = salesTemp.AddresseeName;				// �[�i�於��
			salesTempRow.AddresseeName2 = salesTemp.AddresseeName2;				// �[�i�於��2
			salesTempRow.AddresseePostNo = salesTemp.AddresseePostNo;			// �[�i��X�֔ԍ�
			salesTempRow.AddresseeAddr1 = salesTemp.AddresseeAddr1;				// �[�i��Z��1(�s���{���s��S�E�����E��)
			salesTempRow.AddresseeAddr2 = salesTemp.AddresseeAddr2;				// �[�i��Z��2(����)
			salesTempRow.AddresseeAddr3 = salesTemp.AddresseeAddr3;				// �[�i��Z��3(�Ԓn)
			salesTempRow.AddresseeAddr4 = salesTemp.AddresseeAddr4;				// �[�i��Z��4(�A�p�[�g����)
			salesTempRow.AddresseeTelNo = salesTemp.AddresseeTelNo;				// �[�i��d�b�ԍ�
			salesTempRow.AddresseeFaxNo = salesTemp.AddresseeFaxNo;				// �[�i��FAX�ԍ�
			salesTempRow.PartySaleSlipNum = salesTemp.PartySaleSlipNum;			// �����`�[�ԍ�
			salesTempRow.SlipNote = salesTemp.SlipNote;							// �`�[���l
			salesTempRow.SlipNote2 = salesTemp.SlipNote2;						// �`�[���l�Q
			salesTempRow.RetGoodsReasonDiv = salesTemp.RetGoodsReasonDiv;		// �ԕi���R�R�[�h
			salesTempRow.RetGoodsReason = salesTemp.RetGoodsReason;				// �ԕi���R
			salesTempRow.DetailRowCount = salesTemp.DetailRowCount;				// ���׍s��
			salesTempRow.DeliveredGoodsDiv = salesTemp.DeliveredGoodsDiv;		// �[�i�敪
			salesTempRow.DeliveredGoodsDivNm = salesTemp.DeliveredGoodsDivNm;	// �[�i�敪����
			salesTempRow.ReconcileFlag = salesTemp.ReconcileFlag;				// �����t���O
			salesTempRow.SlipPrtSetPaperId = salesTemp.SlipPrtSetPaperId;		// �`�[����ݒ�p���[ID
			salesTempRow.CompleteCd = salesTemp.CompleteCd;						// �ꎮ�`�[�敪
			salesTempRow.ClaimType = salesTemp.ClaimType;						// ������敪
			salesTempRow.SalesPriceFracProcCd = salesTemp.SalesPriceFracProcCd;	// ������z�[�������敪
			salesTempRow.ListPricePrintDiv = salesTemp.ListPricePrintDiv;		// �艿����敪
			salesTempRow.EraNameDispCd1 = salesTemp.EraNameDispCd1;				// �����\���敪�P
			salesTempRow.CommonSeqNo = salesTemp.CommonSeqNo;					// ���ʒʔ�
			salesTempRow.SalesSlipDtlNum = salesTemp.SalesSlipDtlNum;			// ���㖾�גʔ�
			salesTempRow.AcptAnOdrStatusSrc = salesTemp.AcptAnOdrStatusSrc;		// �󒍃X�e�[�^�X�i���j
			salesTempRow.SalesSlipDtlNumSrc = salesTemp.SalesSlipDtlNumSrc;		// ���㖾�גʔԁi���j
			salesTempRow.SupplierFormalSync = salesTemp.SupplierFormalSync;		// �d���`���i�����j
			salesTempRow.StockSlipDtlNumSync = salesTemp.StockSlipDtlNumSync;	// �d�����גʔԁi�����j
			salesTempRow.SalesSlipCdDtl = salesTemp.SalesSlipCdDtl;				// ����`�[�敪�i���ׁj
			salesTempRow.StockMngExistCd = salesTemp.StockMngExistCd;			// �݌ɊǗ��L���敪
			salesTempRow.DeliGdsCmpltDueDate = salesTemp.DeliGdsCmpltDueDate;	// �[�i�����\���
			salesTempRow.GoodsKindCode = salesTemp.GoodsKindCode;				// ���i����
			salesTempRow.GoodsMakerCd = salesTemp.GoodsMakerCd;					// ���i���[�J�[�R�[�h
			salesTempRow.MakerName = salesTemp.MakerName;						// ���[�J�[����
			salesTempRow.GoodsNo = salesTemp.GoodsNo;							// ���i�ԍ�
			salesTempRow.GoodsName = salesTemp.GoodsName;						// ���i����
			salesTempRow.GoodsShortName = salesTemp.GoodsShortName;				// ���i���̗���
			salesTempRow.GoodsSetDivCd = salesTemp.GoodsSetDivCd;				// �Z�b�g���i�敪
			salesTempRow.LargeGoodsGanreCode = salesTemp.LargeGoodsGanreCode;	// ���i�敪�O���[�v�R�[�h
			salesTempRow.LargeGoodsGanreName = salesTemp.LargeGoodsGanreName;	// ���i�敪�O���[�v����
			salesTempRow.MediumGoodsGanreCode = salesTemp.MediumGoodsGanreCode;	// ���i�敪�R�[�h
			salesTempRow.MediumGoodsGanreName = salesTemp.MediumGoodsGanreName;	// ���i�敪����
			salesTempRow.DetailGoodsGanreCode = salesTemp.DetailGoodsGanreCode;	// ���i�敪�ڍ׃R�[�h
			salesTempRow.DetailGoodsGanreName = salesTemp.DetailGoodsGanreName;	// ���i�敪�ڍז���
			salesTempRow.BLGoodsCode = salesTemp.BLGoodsCode;					// BL���i�R�[�h
			salesTempRow.BLGoodsFullName = salesTemp.BLGoodsFullName;			// BL���i�R�[�h���́i�S�p�j
			salesTempRow.EnterpriseGanreCode = salesTemp.EnterpriseGanreCode;	// ���Е��ރR�[�h
			salesTempRow.EnterpriseGanreName = salesTemp.EnterpriseGanreName;	// ���Е��ޖ���
			salesTempRow.WarehouseCode = salesTemp.WarehouseCode;				// �q�ɃR�[�h
			salesTempRow.WarehouseName = salesTemp.WarehouseName;				// �q�ɖ���
			salesTempRow.WarehouseShelfNo = salesTemp.WarehouseShelfNo;			// �q�ɒI��
			salesTempRow.SalesOrderDivCd = salesTemp.SalesOrderDivCd;			// ����݌Ɏ�񂹋敪
			salesTempRow.GoodsRateRank = salesTemp.GoodsRateRank;				// ���i�|�������N
			salesTempRow.CustRateGrpCode = salesTemp.CustRateGrpCode;			// ���Ӑ�|���O���[�v�R�[�h
			salesTempRow.SuppRateGrpCode = salesTemp.SuppRateGrpCode;			// �d����|���O���[�v�R�[�h
			salesTempRow.ListPriceRate = salesTemp.ListPriceRate;				// �艿��
			salesTempRow.RateSectPriceUnPrc = salesTemp.RateSectPriceUnPrc;		// �|���ݒ苒�_�i�艿�j
			salesTempRow.RateDivLPrice = salesTemp.RateDivLPrice;				// �|���ݒ�敪�i�艿�j
			salesTempRow.UnPrcCalcCdLPrice = salesTemp.UnPrcCalcCdLPrice;		// �P���Z�o�敪�i�艿�j
			salesTempRow.PriceCdLPrice = salesTemp.PriceCdLPrice;				// ���i�敪�i�艿�j
			salesTempRow.StdUnPrcLPrice = salesTemp.StdUnPrcLPrice;				// ��P���i�艿�j
			salesTempRow.FracProcUnitLPrice = salesTemp.FracProcUnitLPrice;		// �[�������P�ʁi�艿�j
			salesTempRow.FracProcLPrice = salesTemp.FracProcLPrice;				// �[�������i�艿�j
			salesTempRow.ListPriceTaxIncFl = salesTemp.ListPriceTaxIncFl;		// �艿�i�ō��C�����j
			salesTempRow.ListPriceTaxExcFl = salesTemp.ListPriceTaxExcFl;		// �艿�i�Ŕ��C�����j
			salesTempRow.ListPriceChngCd = salesTemp.ListPriceChngCd;			// �艿�ύX�敪
			salesTempRow.SalesRate = salesTemp.SalesRate;						// ������
			salesTempRow.RateSectSalUnPrc = salesTemp.RateSectSalUnPrc;			// �|���ݒ苒�_�i����P���j
			salesTempRow.RateDivSalUnPrc = salesTemp.RateDivSalUnPrc;			// �|���ݒ�敪�i����P���j
			salesTempRow.UnPrcCalcCdSalUnPrc = salesTemp.UnPrcCalcCdSalUnPrc;	// �P���Z�o�敪�i����P���j
			salesTempRow.PriceCdSalUnPrc = salesTemp.PriceCdSalUnPrc;			// ���i�敪�i����P���j
			salesTempRow.StdUnPrcSalUnPrc = salesTemp.StdUnPrcSalUnPrc;			// ��P���i����P���j
			salesTempRow.FracProcUnitSalUnPrc = salesTemp.FracProcUnitSalUnPrc;	// �[�������P�ʁi����P���j
			salesTempRow.FracProcSalUnPrc = salesTemp.FracProcSalUnPrc;			// �[�������i����P���j
			salesTempRow.SalesUnPrcTaxIncFl = salesTemp.SalesUnPrcTaxIncFl;		// ����P���i�ō��C�����j
			salesTempRow.SalesUnPrcTaxExcFl = salesTemp.SalesUnPrcTaxExcFl;		// ����P���i�Ŕ��C�����j
			salesTempRow.SalesUnPrcChngCd = salesTemp.SalesUnPrcChngCd;			// ����P���ύX�敪
			salesTempRow.CostRate = salesTemp.CostRate;							// ������
			salesTempRow.RateSectCstUnPrc = salesTemp.RateSectCstUnPrc;			// �|���ݒ苒�_�i�����P���j
			salesTempRow.RateDivUnCst = salesTemp.RateDivUnCst;					// �|���ݒ�敪�i�����P���j
			salesTempRow.UnPrcCalcCdUnCst = salesTemp.UnPrcCalcCdUnCst;			// �P���Z�o�敪�i�����P���j
			salesTempRow.PriceCdUnCst = salesTemp.PriceCdUnCst;					// ���i�敪�i�����P���j
			salesTempRow.StdUnPrcUnCst = salesTemp.StdUnPrcUnCst;				// ��P���i�����P���j
			salesTempRow.FracProcUnitUnCst = salesTemp.FracProcUnitUnCst;		// �[�������P�ʁi�����P���j
			salesTempRow.FracProcUnCst = salesTemp.FracProcUnCst;				// �[�������i�����P���j
			salesTempRow.SalesUnitCost = salesTemp.SalesUnitCost;				// �����P��
			salesTempRow.SalesUnitCostChngDiv = salesTemp.SalesUnitCostChngDiv;	// �����P���ύX�敪
			salesTempRow.RateBLGoodsCode = salesTemp.RateBLGoodsCode;			// BL���i�R�[�h�i�|���j
			salesTempRow.RateBLGoodsName = salesTemp.RateBLGoodsName;			// BL���i�R�[�h���́i�|���j
			salesTempRow.ShipmentCnt = salesTemp.ShipmentCnt;					// �o�א�
			salesTempRow.AcceptAnOrderCnt = salesTemp.AcptAnOdrRemainCnt;		// �󒍎c
			salesTempRow.SalesMoneyTaxInc = salesTemp.SalesMoneyTaxInc;			// ������z�i�ō��݁j
			salesTempRow.SalesMoneyTaxExc = salesTemp.SalesMoneyTaxExc;			// ������z�i�Ŕ����j
			salesTempRow.Cost = salesTemp.Cost;									// ����
			salesTempRow.GrsProfitChkDiv = salesTemp.GrsProfitChkDiv;			// �e���`�F�b�N�敪
			salesTempRow.SalesGoodsCd = salesTemp.SalesGoodsCd;					// ���㏤�i�敪
			salesTempRow.SalsePriceConsTax = salesTemp.SalsePriceConsTax;		// ������z����Ŋz
			salesTempRow.TaxationDivCd = salesTemp.TaxationDivCd;				// �ېŋ敪
			salesTempRow.PartySlipNumDtl = salesTemp.PartySlipNumDtl;			// �����`�[�ԍ��i���ׁj
			salesTempRow.DtlNote = salesTemp.DtlNote;							// ���ה��l
			salesTempRow.SupplierCd = salesTemp.SupplierCd;						// �d����R�[�h
			salesTempRow.SupplierSnm = salesTemp.SupplierSnm;					// �d���旪��
			salesTempRow.SlipMemo1 = salesTemp.SlipMemo1;						// �`�[�����P
			salesTempRow.SlipMemo2 = salesTemp.SlipMemo2;						// �`�[�����Q
			salesTempRow.SlipMemo3 = salesTemp.SlipMemo3;						// �`�[�����R
			salesTempRow.SlipMemo4 = salesTemp.SlipMemo4;						// �`�[�����S
			salesTempRow.SlipMemo5 = salesTemp.SlipMemo5;						// �`�[�����T
			salesTempRow.SlipMemo6 = salesTemp.SlipMemo6;						// �`�[�����U
			salesTempRow.InsideMemo1 = salesTemp.InsideMemo1;					// �Г������P
			salesTempRow.InsideMemo2 = salesTemp.InsideMemo2;					// �Г������Q
			salesTempRow.InsideMemo3 = salesTemp.InsideMemo3;					// �Г������R
			salesTempRow.InsideMemo4 = salesTemp.InsideMemo4;					// �Г������S
			salesTempRow.InsideMemo5 = salesTemp.InsideMemo5;					// �Г������T
			salesTempRow.InsideMemo6 = salesTemp.InsideMemo6;					// �Г������U
			salesTempRow.BfListPrice = salesTemp.BfListPrice;					// �ύX�O�艿
			salesTempRow.BfSalesUnitPrice = salesTemp.BfSalesUnitPrice;			// �ύX�O����
			salesTempRow.BfUnitCost = salesTemp.BfUnitCost;						// �ύX�O����
			salesTempRow.PrtGoodsNo = salesTemp.PrtGoodsNo;						// ����p���i�ԍ�
			salesTempRow.PrtGoodsName = salesTemp.PrtGoodsName;					// ����p���i����
			salesTempRow.PrtGoodsMakerCd = salesTemp.PrtGoodsMakerCd;			// ����p���i���[�J�[�R�[�h
			salesTempRow.PrtGoodsMakerNm = salesTemp.PrtGoodsMakerNm;			// ����p���i���[�J�[����
			salesTempRow.SupplierSlipCd = salesTemp.SupplierSlipCd;				// �d���`�[�敪
			salesTempRow.ConfirmedDiv = salesTemp.ConfirmedDiv;					// �m�F�敪

			#endregion
		}

		#endregion

		/// <summary>
		/// �d�����׃f�[�^�e�[�u���̏����ݒ���s���܂��B
		/// </summary>
		/// <param name="defaultRowCount">�����s��</param>
		public void StockDetailRowInitialSetting(int defaultRowCount)
		{
			this._stockDetailDataTable.BeginLoadData();
			//this._stockDetailDataTable.Rows.Clear();
			this.ClearDetailTables();
			this._stockDetailDBDataList.Clear();

			for (int i = 1; i <= defaultRowCount; i++)
			{
				StockInputDataSet.StockDetailRow row = this._stockDetailDataTable.NewStockDetailRow();
				row.SupplierSlipNo = this._currentSupplierSlipNo;
				row.DtlRelationGuid = Guid.Empty;
				row.StockRowNo = i;

				this._stockDetailDataTable.AddStockDetailRow(row);
			}
			this._stockDetailDataTable.EndLoadData();
		}

        /// <summary>
        /// �d�����׃f�[�^�̖����f�[�^���폜���܂��B
        /// </summary>
        public void DeleteIinvalidStockDetailRow()
        {
            List<int> deleteStockRowNoList = new List<int>();
            foreach (StockInputDataSet.StockDetailRow row in this._stockDetailDataTable)
            {
                if (string.IsNullOrEmpty(row.GoodsName))
                {
                    deleteStockRowNoList.Add(row.StockRowNo);
                }
            }

            // �d�����׍s�폜����
            this.DeleteStockDetailRow(deleteStockRowNoList, true);

        }

		/// <summary>
		/// �c�a�ɕۑ�����d���f�[�^�𒲐����܂��B
		/// </summary>
		public void AdjustStockSaveData()
		{
            this.DeleteIinvalidStockDetailRow();

			// ���z�\���̏ꍇ�A�`�[���v����łƖ��ׂ̏���ō��v�̍��ق𒲐�����
			if (( this._stockSlip.SuppTtlAmntDspWayCd == 1 ) && ( ( this._stockSlip.StockGoodsCd == 0 ) || ( this._stockSlip.StockGoodsCd == 1 ) || ( this._stockSlip.StockGoodsCd == 6 ) ))
			{
				long stockTtlPricTaxInc = 0;	// �d�����z�v�i�ō��݁j
				long stockTtlPricTaxExc = 0;	// �d�����z�v�i�Ŕ����j
				long stockPriceConsTax = 0;		// �d�����z����Ŋz
				long ttlItdedStcOutTax = 0;		// �d���O�őΏۊz���v
				long ttlItdedStcInTax = 0;		// �d�����őΏۊz���v
				long ttlItdedStcTaxFree = 0;	// �d����ېőΏۊz���v
				long stockOutTax = 0;			// �d�����z����Ŋz�i�O�Łj
				long stckPrcConsTaxInclu = 0;	// �d�����z����Ŋz�i���Łj
				long stckDisTtlTaxExc = 0;		// �d���l�����z�v�i�Ŕ����j
				long itdedStockDisOutTax = 0;	// �d���l���O�őΏۊz���v
				long itdedStockDisInTax = 0;	// �d���l�����őΏۊz���v
				long itdedStockDisTaxFre = 0;	// �d���l����ېőΏۊz���v
				long stockDisOutTax = 0;		// �d���l������Ŋz�i�O�Łj
				long stckDisTtlTaxInclu = 0;	// �d���l������Ŋz�i���Łj
				long balanceAdjust = 0;			// �c�������z
				long taxAdjust = 0;				// ����ō��v�z

				//int stockTaxFrcProcCd = this._customerInfoAcs.GetStockFractionProcCd(this._enterpriseCode, this._stockSlip.CustomerCode, CustomerInfoAcs.FracProcMoneyDiv.CnsTaxFrcProcCd);		// �d������Œ[�������R�[�h
                if (this._supplierAcs == null) this._supplierAcs = new SupplierAcs();
				int stockTaxFrcProcCd = this._supplierAcs.GetStockFractionProcCd(this._enterpriseCode, this._stockSlip.SupplierCd, SupplierAcs.StockFracProcMoneyDiv.CnsTaxFrcProcCd);		// �d������Œ[�������R�[�h

				this.CalculateStockTotalPrice(this._stockSlip.SupplierConsTaxRate, stockTaxFrcProcCd, this._stockSlip.SuppTtlAmntDspWayCd, this._stockSlip.SuppCTaxLayCd, out stockTtlPricTaxInc, out stockTtlPricTaxExc, out stockPriceConsTax, out ttlItdedStcOutTax, out ttlItdedStcInTax, out ttlItdedStcTaxFree, out stockOutTax, out stckPrcConsTaxInclu, out stckDisTtlTaxExc, out itdedStockDisOutTax, out itdedStockDisInTax, out itdedStockDisTaxFre, out stockDisOutTax, out stckDisTtlTaxInclu, out balanceAdjust, out taxAdjust);

				// ����ł̍��ق��v�Z�F�d�����z����Ŋz�i�O�Łj+ �d�����z����Ŋz�i���Łj+ �d���l������Ŋz�i�O�Łj+ �d���l������Ŋz�i���Łj- �d�����z����Ŋz
				long differenceTax = stockOutTax + stckPrcConsTaxInclu + stockDisOutTax + stckDisTtlTaxInclu - stockPriceConsTax;

				if (differenceTax != 0)
				{
					int targetRowCount = this.SelectStockDetailRows(string.Format("{0}<>{1}", this._stockDetailDataTable.TaxationCodeColumn.ColumnName, (int)CalculateTax.TaxationCode.TaxNone), this._stockDetailDataTable).Length;
					if (targetRowCount == 0) return;

					// ���ς��ĐU�蕪���镪
					long av = differenceTax / targetRowCount;

					// �擪�s����1�~���U�蕪����s
					long adjustCount = Math.Abs(differenceTax % targetRowCount);

					int sign = ( differenceTax > 0 ) ? 1 : -1;

					foreach (StockInputDataSet.StockDetailRow row in this._stockDetailDataTable)
					{
						if (row.TaxationCode != (int)CalculateTax.TaxationCode.TaxNone)
						{
							row.StockPriceConsTax -= ( av + ( ( adjustCount > 0 ) ? sign : 0 ) );
							row.StockPriceTaxExc += ( av + ( ( adjustCount > 0 ) ? sign : 0 ) );
							adjustCount--;
						}
					}
					// ���v���z�̍Đݒ�
					this.TotalPriceSetting(ref this._stockSlip, true);
				}
			}
		}

		#region ���׏��ݒ�

		#region ���i�E�݌Ɋ֘A
		/// <summary>
		/// �w�肵�����i�A�݌ɏ��̃��X�g�����ɁA�d�����׃f�[�^�s�I�u�W�F�N�g�ɏ��i�A�݌ɏ����ꊇ�ݒ肵�܂��B�i�݌Ƀx�[�X�j
		/// </summary>
		/// <param name="stockRowNo">�d���s�ԍ�</param>
		/// <param name="stockList">���i���I�u�W�F�N�g���X�g</param>
		/// <param name="goodsUnitDataList">�݌ɏ��I�u�W�F�N�g���X�g</param>
		/// <param name="settingStockRowNoList">�ݒ肵���d���s�ԍ��̃��X�g</param>
        /// <param name="overWriteRow">true:�s�㏑������ false:�s�㏑���Ȃ�</param>
        public void StockDetailRowGoodsSettingBasedOnStock( int stockRowNo, List<GoodsUnitData> goodsUnitDataList, List<Stock> stockList, out List<int> settingStockRowNoList, bool overWriteRow )
		{
			settingStockRowNoList = new List<int>();
			List<int> deletingStockRowNoList = new List<int>();

            int addRowCnt = goodsUnitDataList.Count;
            int stockRowNoWk = stockRowNo;
            while (addRowCnt > 0)
            {
                StockInputDataSet.StockDetailRow row = this.GetStockDetailRow(stockRowNoWk);

                try
                {
                    // �s�����݂��Ȃ��ꍇ�͐V�K�ɒǉ�����
                    if (row == null)
                    {
                        this.AddStockDetailRow();

                        row = this.GetStockDetailRow(stockRowNoWk);
                    }
                    else
                    {
                        if (!overWriteRow)
                        {
                            if (this.ExistStockDetailInput(row))
                            {
                                continue;
                            }
                        }
                    }

                    settingStockRowNoList.Add(row.StockRowNo);

                    deletingStockRowNoList.Add(row.StockRowNo);

                    row.AcceptChanges();

                    addRowCnt--;
                }
                finally
                {
                    stockRowNoWk++;
                }
            }

			// �d�����׍s�폜����
			this.ClearStockDetailRow(deletingStockRowNoList);
			GoodsUnitData goodsUnitData = new GoodsUnitData();
            Stock stock = new Stock();
			for (int i = 0; i < stockList.Count; i++)
			{
				stock = stockList[i];
				int targetStockRowNo = settingStockRowNoList[i];
				goodsUnitData = this.GetGoodsUnitDataFromList(stock.GoodsNo, stock.GoodsMakerCd, goodsUnitDataList);

				// ���i�A�݌ɏ��ݒ菈��
                this.StockDetailRowGoodsSetting(targetStockRowNo, goodsUnitData, stock);
			}
        }

		/// <summary>
		/// �w�肵�����i�A�݌ɏ��̃��X�g�����ɁA�d�����׃f�[�^�s�I�u�W�F�N�g�ɏ��i�A�݌ɏ����ꊇ�ݒ肵�܂��B�i���i�x�[�X�j
		/// </summary>
		/// <param name="stockRowNo">�d���s�ԍ�</param>
		/// <param name="goodsUnitDataList">���i���I�u�W�F�N�g���X�g</param>
		/// <param name="settingStockRowNoList">�ݒ肵���d���s�ԍ��̃��X�g</param>
        /// <param name="overWriteRow">true:�s�㏑������ false:�s�㏑���Ȃ�</param>
        public void StockDetailRowGoodsSettingBasedOnGoodsUnitData( int stockRowNo, List<GoodsUnitData> goodsUnitDataList, out List<int> settingStockRowNoList, bool overWriteRow )
		{
			settingStockRowNoList = new List<int>();
			List<int> deletingStockRowNoList = new List<int>();
			List<int> goodsDiscountRowList = new List<int>();

            int addRowCnt = goodsUnitDataList.Count;
            int stockRowNoWk = stockRowNo;
            while (addRowCnt > 0)
            {
                StockInputDataSet.StockDetailRow row = this.GetStockDetailRow(stockRowNoWk);

                try
                {
                    // �s�����݂��Ȃ��ꍇ�͐V�K�ɒǉ�����
                    if (row == null)
                    {
                        this.AddStockDetailRow();

                        row = this.GetStockDetailRow(stockRowNoWk);
                    }
                    else
                    {
                        if (!overWriteRow)
                        {
                            if (this.ExistStockDetailInput(row))
                            {
                                continue;
                            }
                        }
                    }

                    settingStockRowNoList.Add(row.StockRowNo);

                    deletingStockRowNoList.Add(row.StockRowNo);

                    if (row.StockSlipCdDtl == 2) goodsDiscountRowList.Add(row.StockRowNo);

                    row.AcceptChanges();

                    addRowCnt--;
                }
                finally
                {
                    stockRowNoWk++;
                }
            }

            // �����Ώۑq�ɔz����擾
            string[] warehouseCodeArray = this.GetSearchWarehouseArray();

			// �d�����׍s�폜����
			this.ClearStockDetailRow(deletingStockRowNoList);
			GoodsUnitData goodsUnitData = new GoodsUnitData();
            Stock stock = new Stock();
			for (int i = 0; i < goodsUnitDataList.Count; i++)
			{
				goodsUnitData = goodsUnitDataList[i];

                // 2009.04.03 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                //stock = ( ( warehouseCodeArray != null ) && ( warehouseCodeArray.Length > 0 ) ) ? this._stockSlipInputInitDataAcs.GetStockFromGoodsUnitData(goodsUnitData, warehouseCodeArray) : null;
                if (goodsUnitData.SelectedWarehouseCode != null)
                {
                    stock = this._stockSlipInputInitDataAcs.GetStock(goodsUnitData, goodsUnitData.SelectedWarehouseCode.Trim());
                }
                else
                {
                    stock = ((warehouseCodeArray != null) && (warehouseCodeArray.Length > 0)) ? this._stockSlipInputInitDataAcs.GetStockFromGoodsUnitData(goodsUnitData, warehouseCodeArray) : null;
                }
                // 2009.04.03 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

                int targetStockRowNo = settingStockRowNoList[i];

				int stockSlipCdDtl = ( goodsDiscountRowList.Contains(settingStockRowNoList[i]) ) ? 2 : 0;

				// ���i�A�݌ɏ��ݒ菈��
                this.StockDetailRowGoodsSetting(targetStockRowNo, goodsUnitData, stock, stockSlipCdDtl);
			}
		}

		/// <summary>
		/// �w�肵�����i���I�u�W�F�N�g�����ɁA�d�����׃f�[�^�s�I�u�W�F�N�g�ɏ��i����ݒ肵�܂��B
		/// </summary>
		/// <param name="stockRowNo">�d���s�ԍ�</param>
		/// <param name="goodsUnitData">���i���I�u�W�F�N�g</param>
		public void StockDetailRowGoodsSetting( int stockRowNo, GoodsUnitData goodsUnitData)
		{
			this.StockDetailRowGoodsSetting(stockRowNo, goodsUnitData, null);
		}

		/// <summary>
		/// �w�肵�����i���I�u�W�F�N�g�����ɁA�d�����׃f�[�^�s�I�u�W�F�N�g�ɏ��i����ݒ肵�܂��B
		/// </summary>
		/// <param name="stockRowNo">�d���s�ԍ�</param>
		/// <param name="goodsUnitData">���i���I�u�W�F�N�g</param>
		/// <param name="stock">�݌ɏ��I�u�W�F�N�g</param>
		/// <param name="stockSlipCdDtl">�d���`�[�敪(����)</param>
        private void StockDetailRowGoodsSetting( int stockRowNo, GoodsUnitData goodsUnitData, Stock stock, int stockSlipCdDtl )
		{
            StockInputDataSet.StockDetailRow row = this.GetStockDetailRow(stockRowNo);
			List<int> deleteRowNoList = new List<int>();

            if (row != null)
            {
                this.ClearStockDetailRow(row);

                row.StockSlipCdDtl = stockSlipCdDtl;

                if (goodsUnitData == null)
                {
                    //
                }
                else
                {
                    row.GoodsNo = goodsUnitData.GoodsNo;                                // �i��
                    row.GoodsMakerCd = goodsUnitData.GoodsMakerCd;                      // ���[�J�[�R�[�h
                    row.MakerName = goodsUnitData.MakerName;                            // ���[�J�[����
                    row.MakerKanaName = goodsUnitData.MakerKanaName;                    // ���[�J�[���̃J�i
                    row.GoodsName = goodsUnitData.GoodsName;                            // �i��
                    row.GoodsNameKana = goodsUnitData.GoodsNameKana;                    // �i���J�i
                    row.GoodsKindCode = goodsUnitData.GoodsKindCode;                    // ���i����
                    row.GoodsLGroup = goodsUnitData.GoodsLGroup;                        // ���i�啪�ޖ���
                    row.GoodsLGroupName = goodsUnitData.GoodsLGroupName;                // ���i�啪�ރR�[�h
                    row.GoodsMGroup = goodsUnitData.GoodsMGroup;                        // ���i�����ރR�[�h
                    row.GoodsMGroupName = goodsUnitData.GoodsMGroupName;                // ���i�����ޖ���
                    row.BLGroupCode = goodsUnitData.BLGroupCode;                        // BL�O���[�v�R�[�h
                    row.BLGroupName = goodsUnitData.BLGroupName;                        // BL�O���[�v�R�[�h����
                    row.BLGoodsCode = goodsUnitData.BLGoodsCode;                        // BL���i�R�[�h
                    row.BLGoodsFullName = goodsUnitData.BLGoodsFullName;                // BL���i�R�[�h���́i�S�p�j
                    row.EnterpriseGanreCode = goodsUnitData.EnterpriseGanreCode;        // ���Е��ރR�[�h
                    row.EnterpriseGanreName = goodsUnitData.EnterpriseGanreName;        // ���Е��ޖ���
                    row.GoodsRateRank = goodsUnitData.GoodsRateRank;                    // ���i�|�������N
                    row.RateBLGoodsCode = goodsUnitData.BLGoodsCode;                    // BL���i�R�[�h�i�|���j
                    row.RateBLGoodsName = goodsUnitData.BLGoodsFullName;                // BL���i�R�[�h���́i�|���j
                    row.RateGoodsRateGrpCd = goodsUnitData.GoodsRateGrpCode;            // ���i�|���O���[�v�R�[�h�i�|���j
                    row.RateGoodsRateGrpNm = goodsUnitData.GoodsRateGrpName;            // ���i�|���O���[�v���́i�|���j
                    row.RateBLGroupCode = goodsUnitData.BLGroupCode;                    // BL�O���[�v�R�[�h�i�|���j
                    row.RateBLGroupName = goodsUnitData.BLGroupName;                    // BL�O���[�v���́i�|���j
                    row.TaxationCode = goodsUnitData.TaxationDivCd;                     // �ېŋ敪
                    row.GoodsOfferDate = goodsUnitData.OfferDate;                       // �񋟓�
                    row.TaxDiv = row.TaxationCode;                                      // �ېŋ敪�i�\���j

                    if (row.StockSlipCdDtl == 2)
                    {
                        row.EditStatus = ctEDITSTATUS_GoodsDiscount;                    // �ύX�\�X�e�[�^�X
                    }
                    else
                    {
                        row.EditStatus = ctEDITSTATUS_AllOK;                            // �ύX�\�X�e�[�^�X
                    }

                    int sign = ( row.StockSlipCdDtl == 2 ) ? -1 : 1;
                    row.StockCountDisplay = 1 * sign;
                    sign = ( this._stockSlip.SupplierSlipCd == 20 ) ? -1 : 1;
                    row.StockCount = row.StockCountDisplay * sign;
                    row.OrderCnt = row.StockCount;

                    row.OrderRemainCnt = ( this._stockSlip.SupplierFormal == 0 ) ? 0 : row.StockCountDisplay;

                    // �݌ɏ��
                    if (stock != null)
                    {
                        this.CacheStockInfo(stock);

                        row.WarehouseCode = stock.WarehouseCode.Trim();
                        row.WarehouseName = stock.WarehouseName;
                        row.WarehouseShelfNo = stock.WarehouseShelfNo;
                    }
                    else
                    {
                        row.ShipmentPosCnt = 0;
                        row.ShipmentPosCntDisplay = row.ShipmentPosCnt;
                    }

                    // �i�ԁA���[�J�[�������Ă���ꍇ�͒P���Z�o���W���[���Ō����v�Z
                    if (( goodsUnitData.GoodsMakerCd != 0 ) && ( !string.IsNullOrEmpty(goodsUnitData.GoodsNo) ))
                    {
                        this.StockDetailRowGoodsPriceSetting(row, goodsUnitData);
                    }

                    // ���i���L���b�V��
                    this.CacheGoodsUnitData(goodsUnitData);

                    //if (( goodsUnitData.GoodsOfferCd == 0 ) && ( goodsUnitData.CreateDateTime != DateTime.MinValue ))
                    //{
                    //    row.CanTaxDivChange = false;		// �ېŔ�ېŋ敪�ύX�\�t���O
                    //}
                    //else
                    //{
                    //    row.CanTaxDivChange = true;			// �ېŔ�ېŋ敪�ύX�\�t���O
                    //}
                }
            }

			// �Z�b�g�e���i�̏ꍇ�͎q���i�s���N���A����
			if (deleteRowNoList.Count > 0)
			{
				this.DeleteStockDetailRow(deleteRowNoList, true);
			}
		}

		/// <summary>
		/// �w�肵�����i���I�u�W�F�N�g�����ɁA�d�����׃f�[�^�s�I�u�W�F�N�g�ɏ��i����ݒ肵�܂��B
		/// </summary>
		/// <param name="stockRowNo">�d���s�ԍ�</param>
		/// <param name="goodsUnitData">���i���I�u�W�F�N�g</param>
		/// <param name="stock">�݌ɏ��I�u�W�F�N�g</param>
        private void StockDetailRowGoodsSetting( int stockRowNo, GoodsUnitData goodsUnitData, Stock stock )
        {
            this.StockDetailRowGoodsSetting(stockRowNo, goodsUnitData, stock, 0);
        }

		/// <summary>
		/// �w�肵���P������ʂ̌��ʏ������ɁA�d�����׃f�[�^�s�I�u�W�F�N�g�ɒP������ݒ肵�܂��B
		/// </summary>
		/// <param name="stockRowNo">�s�ԍ�</param>
		/// <param name="unPrcInfoConfRet">�P�����m�F��ʌ��ʃI�u�W�F�N�g</param>
		public void StockDetailRowUnPrcInfoSetting( int stockRowNo, UnPrcInfoConfRet unPrcInfoConfRet )
		{
            StockInputDataSet.StockDetailRow row = this.GetStockDetailRow(stockRowNo);

			if (row != null)
			{
				row.UnPrcCalcCdStckUnPrc = unPrcInfoConfRet.UnitPrcCalcDiv;		// �P���Z�o�敪
				//row.PriceCdStckUnPrc = unPrcInfoConfRet.PriceDiv;				// ���i�敪
				row.StockRate = unPrcInfoConfRet.RateVal;						// �|��
				row.FracProcUnitStcUnPrc = unPrcInfoConfRet.UnPrcFracProcUnit;	// �P���[�������P��
				row.FracProcStckUnPrc = unPrcInfoConfRet.UnPrcFracProcDiv;		// �P���[�������敪
				row.StdUnPrcStckUnPrc = unPrcInfoConfRet.StdUnitPrice;			// ��P��
				//row.PriceDisplay = unPrcInfoConfRet.UnitPriceFl;		// �P���i�����j
				this.StockDetailRowListPriceSetting(row, null);
                this.StockDetailRowStockUnitPriceSetting(row, PriceInputType.PriceDisplay, row.StockUnitPriceDisplay);
			}
		}

		/// <summary>
		/// �w�肵���݌ɏ��I�u�W�F�N�g�����ɁA�d�����׃f�[�^�s�I�u�W�F�N�g�ɍ݌ɏ���ݒ肵�܂��B
		/// </summary>
		/// <param name="stockRowNo">�s�ԍ�</param>
		/// <param name="stockList">�݌Ƀ��X�g</param>
        public void StockDetailRowStockSetting( int stockRowNo, List<Stock> stockList )
		{

            StockInputDataSet.StockDetailRow row = this.GetStockDetailRow(stockRowNo);

            if (row != null)
            {
                Stock stock = null;

                foreach (Stock stockWk in stockList)
                {
                    if (row.WarehouseCode.Trim() == stockWk.WarehouseCode.Trim())
                    {
                        stock = stockWk;
                        break;
                    }
                }

                this.StockDetailRowStockSetting(row, stock);
            }
		}

        /// <summary>
        /// �w�肵���݌ɏ��I�u�W�F�N�g�����ɁA�d�����׃f�[�^�s�I�u�W�F�N�g�ɍ݌ɏ���ݒ肵�܂��B
        /// </summary>
        /// <param name="stockRowNo">�s�ԍ�</param>
        /// <param name="stock">�݌ɃI�u�W�F�N�g</param>
        public void StockDetailRowStockSetting( int stockRowNo, Stock stock )
        {
            StockInputDataSet.StockDetailRow row = this.GetStockDetailRow(stockRowNo);

            if (row != null)
            {
                this.StockDetailRowStockSetting(row, stock);
            }
        }

        /// <summary>
        /// �w�肵���݌ɏ��I�u�W�F�N�g�����ɁA�d�����׃f�[�^�s�I�u�W�F�N�g�ɍ݌ɏ���ݒ肵�܂��B
        /// </summary>
        /// <param name="row">�d�����׍s�I�u�W�F�N�g</param>
        /// <param name="stock">�݌ɃI�u�W�F�N�g</param>
        private void StockDetailRowStockSetting( StockInputDataSet.StockDetailRow row, Stock stock )
        {
            if (row != null)
            {
                if (stock != null)
                {
                    // �݌ɂ̃L���b�V��
                    this.CacheStockInfo(stock);

                    row.WarehouseCode = stock.WarehouseCode.Trim();
                    row.WarehouseName = stock.WarehouseName;
                    row.WarehouseShelfNo = stock.WarehouseShelfNo.Trim();

                    this.StockDetailStockInfoAdjust(row.WarehouseCode, row.GoodsNo, row.GoodsMakerCd);
                }
                else
                {
                    row.WarehouseCode = string.Empty;
                    row.WarehouseName = string.Empty;
                    row.WarehouseShelfNo = string.Empty;
                    row.ShipmentPosCnt = 0;
                    row.ShipmentPosCntDisplay = 0;
                }
            }
        }

		/// <summary>
		/// �w�肵���s�̍݌ɏ����N���A���܂��B
		/// </summary>
		/// <param name="stockRowNo">�s�ԍ�</param>
		public void StockDetailRowClearStockInfo( int stockRowNo )
		{
            StockInputDataSet.StockDetailRow row = this.GetStockDetailRow(stockRowNo);

			if (row != null)
			{
				string goodsNo = row.GoodsNo;
				string warehouseCode = row.WarehouseCode.Trim();
				int goodsmakerCode = row.GoodsMakerCd;

				row.WarehouseCode = string.Empty;
				row.WarehouseName = string.Empty;
				row.WarehouseShelfNo = string.Empty;
				row.ShipmentPosCnt = 0;
				row.ShipmentPosCntDisplay = 0;

				if (( !string.IsNullOrEmpty(warehouseCode) ) && ( !string.IsNullOrEmpty(goodsNo) ) && ( goodsmakerCode != 0 ))
				{
					this.StockDetailStockInfoAdjust(warehouseCode, goodsNo, goodsmakerCode);
				}
			}
		}

		/// <summary>
		/// �󏤕i���ݒ�
		/// </summary>
		/// <param name="goodsNo">���i�R�[�h</param>
		/// <param name="goodsName">���i����</param>
		/// <param name="goodsMakerCd">���[�J�[�R�[�h</param>
		public GoodsUnitData CreateEmptyGoods( string goodsNo, string goodsName, int goodsMakerCd )
		{
			GoodsUnitData retGoodsUnitData = new GoodsUnitData();
			retGoodsUnitData.GoodsNo = goodsNo;
			retGoodsUnitData.GoodsName = goodsName;
			retGoodsUnitData.GoodsMakerCd = goodsMakerCd;

            string makerName, makerKanaName;
            this._stockSlipInputInitDataAcs.GetName_FromMaker(goodsMakerCd, out makerName, out makerKanaName);
            retGoodsUnitData.MakerName = makerName;
            retGoodsUnitData.MakerKanaName = makerKanaName;

			return retGoodsUnitData;
		}
		#endregion

		/// <summary>
		/// �d�������Ɖ�[�N�I�u�W�F�N�g���X�g�����ɁA�d�����׃f�[�^�s�I�u�W�F�N�g�ɏ��i�A�݌ɏ��A������������ꊇ�ݒ肵�܂��B
		/// </summary>
		/// <param name="stockRowNo">�d���s�ԍ�</param>
		/// <param name="stcHisRefDataWorkList">�d�������Ɖ�[�N�I�u�W�F�N�g���X�g</param>
		/// <param name="wayToDetailExpand">���דW�J���@</param>
		/// <param name="memoMoveDiv">�������ʋ敪</param>
		/// <param name="settingRowNoList">�ݒ�s���X�g</param>
		/// <returns>�ǂݍ��݃X�e�[�^�X</returns>
		public int StockDetailRowSettingFromstcHisRefDataWorkList( int stockRowNo, List<StcHisRefDataWork> stcHisRefDataWorkList, WayToDetailExpand wayToDetailExpand, MemoMoveDiv memoMoveDiv, out List<int> settingRowNoList )
		{
			ArrayList arrayList = new ArrayList();
			settingRowNoList = new List<int>();

			IOWriteCtrlOptWork iOWriteCtrlOptWork = this.GetIOWriteCtrlOptWork();

			CustomSerializeArrayList paraList = new CustomSerializeArrayList();

			paraList.Add(iOWriteCtrlOptWork);

			foreach (StcHisRefDataWork stcHisRefDataWork in stcHisRefDataWorkList)
			{
				StockDetailWork stockDetailWork = new StockDetailWork();
				stockDetailWork.EnterpriseCode = stcHisRefDataWork.EnterpriseCode;
				stockDetailWork.SupplierFormal = stcHisRefDataWork.SupplierFormal;
				stockDetailWork.StockSlipDtlNum = stcHisRefDataWork.StockSlipDtlNum;
				paraList.Add(stockDetailWork);
			}

			object paraObj = (object)paraList;
			object retObj = null;
			object retObj2 = null;

            if (this._iIOWriteControlDB == null) this._iIOWriteControlDB = (IIOWriteControlDB)MediationIOWriteControlDB.GetIOWriteControlDB();
			int status = this._iIOWriteControlDB.ReadDetail(ref paraObj, out retObj, out retObj2);

			CustomSerializeArrayList retList = ( ( retObj != null ) && ( retObj is CustomSerializeArrayList ) ) ? (CustomSerializeArrayList)retObj : null;
			CustomSerializeArrayList retList2 = ( ( retObj2 != null ) && ( retObj2 is CustomSerializeArrayList ) ) ? (CustomSerializeArrayList)retObj2 : null;

            if (( status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND ) && ( retList2 == null ))
            {
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }

			if (( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL ) ||
				( status == -999 ))
			{
				StockDetailWork[] stockDetailWorkArray;
				SalesSlipWork[] salesSlipWorkArray = null;
				SalesDetailWork[] salesDetailWorkArray = null;

                DivisionStockSlipCustomSerializeArrayList.DivisionCustomSerializeArrayListForDetailsReadingResult(retList, retList2, out stockDetailWorkArray, out salesSlipWorkArray, out salesDetailWorkArray);

				this.StockDetailRowSettingFromStockDetailWorkArray(stockRowNo, stockDetailWorkArray, salesSlipWorkArray, salesDetailWorkArray, wayToDetailExpand, memoMoveDiv, out settingRowNoList);
			}
			return status;
		}

		/// <summary>
		/// �����c�Ɖ�[�N�I�u�W�F�N�g���X�g�����ɁA�d�����׃f�[�^�s�I�u�W�F�N�g�ɏ��i�A�݌ɏ��A������������ꊇ�ݒ肵�܂��B
		/// </summary>
		/// <param name="stockRowNo">�d���s�ԍ�</param>
		/// <param name="orderListResultWorkList">�����c�Ɖ�[�N�I�u�W�F�N�g���X�g</param>
		/// <param name="wayToDetailExpand">���דW�J���@</param>
		/// <param name="memoMoveDiv">�������ʋ敪</param>
		/// <param name="settingStockRowNoList">�ݒ肵���d�����׍s���X�g</param>
		/// <returns>�ǂݍ��݃X�e�[�^�X</returns>
		public int StockDetailRowSettingFromOrderListResultWorkList( int stockRowNo, List<OrderListResultWork> orderListResultWorkList, WayToDetailExpand wayToDetailExpand, MemoMoveDiv memoMoveDiv, out List<int> settingStockRowNoList )
		{
			ArrayList arrayList = new ArrayList();
			settingStockRowNoList = new List<int>();

			IOWriteCtrlOptWork iOWriteCtrlOptWork = this.GetIOWriteCtrlOptWork();

			CustomSerializeArrayList paraList = new CustomSerializeArrayList();

			paraList.Add(iOWriteCtrlOptWork);

			foreach (OrderListResultWork orderListResultWork in orderListResultWorkList)
			{
				StockDetailWork stockDetailWork = new StockDetailWork();
				stockDetailWork.EnterpriseCode = this._enterpriseCode;
				stockDetailWork.SupplierFormal = orderListResultWork.SupplierFormal;
				stockDetailWork.StockSlipDtlNum = orderListResultWork.StockSlipDtlNum;
				paraList.Add(stockDetailWork);
			}

			object paraObj = (object)paraList;
			object retObj = null;
			object retObj2 = null;

            if (this._iIOWriteControlDB == null) this._iIOWriteControlDB = (IIOWriteControlDB)MediationIOWriteControlDB.GetIOWriteControlDB();
			int status = this._iIOWriteControlDB.ReadDetail(ref paraObj, out retObj, out retObj2);

			CustomSerializeArrayList retList = ( ( retObj != null ) && ( retObj is CustomSerializeArrayList ) ) ? (CustomSerializeArrayList)retObj : null;
			CustomSerializeArrayList retList2 = ( ( retObj2 != null ) && ( retObj2 is CustomSerializeArrayList ) ) ? (CustomSerializeArrayList)retObj2 : null;

            if (( status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND ) && ( retList2 == null ))
            {
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }

			if (( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL ) ||
				(status == -999))
			{

				StockDetailWork[] stockDetailWorkArray;
				SalesSlipWork[] salesSlipWorkArray = null;
				SalesDetailWork[] salesDetailWorkArray = null;

                DivisionStockSlipCustomSerializeArrayList.DivisionCustomSerializeArrayListForDetailsReadingResult(retList, retList2, out stockDetailWorkArray, out salesSlipWorkArray, out salesDetailWorkArray);

				this.StockDetailRowSettingFromStockDetailWorkArray(stockRowNo, stockDetailWorkArray, salesSlipWorkArray, salesDetailWorkArray, wayToDetailExpand, memoMoveDiv, out settingStockRowNoList);
			}

			return status;
		}

		/// <summary>
		/// �d�����׃��[�N�I�u�W�F�N�g�z������ɁA�d�����׃f�[�^�s�I�u�W�F�N�g�ɏ��i�A�݌ɏ����ꊇ�ݒ肵�܂��B
		/// </summary>
		/// <param name="stockRowNo">�d���s�ԍ�</param>
		/// <param name="stockDetailWorkArray">�d�����׃��[�N�I�u�W�F�N�g�z��</param>
		/// <param name="salesSlipWorkArray">����f�[�^�I�u�W�F�N�g�z��</param>
		/// <param name="salesDetailWorkArray">���㖾�׃��[�N�I�u�W�F�N�g�z��</param>
		/// <param name="wayToDetailExpand">���דW�J���@</param>
		/// <param name="memoMoveDiv">�������ʋ敪</param>
		/// <param name="settingStockRowNoList">�ݒ肵���d�����׍s�ԍ����X�g</param>
        public void StockDetailRowSettingFromStockDetailWorkArray(int stockRowNo, StockDetailWork[] stockDetailWorkArray, SalesSlipWork[] salesSlipWorkArray, SalesDetailWork[] salesDetailWorkArray, WayToDetailExpand wayToDetailExpand, MemoMoveDiv memoMoveDiv, out List<int> settingStockRowNoList)
		{
			settingStockRowNoList = new List<int>();

			List<StockDetail> stockDetailList = ConvertStockSlip.UIDataFromParamData(stockDetailWorkArray);

            List<Stock> stockList = this.SearchStock(stockDetailList);

			List<int> deletingStockRowNoList = new List<int>();

			bool isAddUp = ( wayToDetailExpand != WayToDetailExpand.Normal );

            //stockRowNo = 1; // 2009.04.13
            int addRowCnt = stockDetailList.Count;

            for (int index = 0; index < this._stockDetailDataTable.Rows.Count; index++)
            {
                // 2009.04.13 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                //StockInputDataSet.StockDetailRow row = this._stockDetailDataTable[index];
                //if (this.ExistStockDetailInput(row))
                //{
                //    continue;
                //}
                StockInputDataSet.StockDetailRow row = null;
                if (wayToDetailExpand != WayToDetailExpand.AddUpRemainder)
                {
                    row = this._stockDetailDataTable[index];
                    if (this.ExistStockDetailInput(row)) continue;
                }
                else
                {
                    // �c�����͓��͈ʒu�ɓW�J
                    row = this._stockDetailDataTable[stockRowNo - 1 + index];
                    // �c�������͕i�ԓ��͂���Ă���
                    if (!string.IsNullOrEmpty(row.GoodsName)) continue;
                }
                // 2009.04.13 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                settingStockRowNoList.Add(row.StockRowNo);

                deletingStockRowNoList.Add(row.StockRowNo);

                row.AcceptChanges();

                addRowCnt--;
                if (addRowCnt == 0) break;
            }

			// �d�����׍s�폜����
			this.ClearStockDetailRow(deletingStockRowNoList);

			GoodsUnitData goodsUnitData = new GoodsUnitData();
            Stock stock = new Stock();

			for (int i = 0; i < stockDetailList.Count; i++)
			{
				stock = null;
                foreach (Stock stockWk in stockList)
				{
					if (( stockDetailList[i].GoodsNo == stockWk.GoodsNo ) &&
						( stockDetailList[i].GoodsMakerCd == stockWk.GoodsMakerCd ) &&
						( stockDetailList[i].WarehouseCode.Trim() == stockWk.WarehouseCode.Trim() ))
					{
						stock = stockWk;
						break;
					}

				}
				int targetStockRowNo = settingStockRowNoList[i];

				// ���׏��ݒ菈��
				this.StockDetailRowSettingFromStockDetail(targetStockRowNo, stockDetailList[i], stock, isAddUp, memoMoveDiv);
                this.CacheStockInfo(stock);
#if false
				// �������̓f�[�^�̓W�J
				if (wayToDetailExpand == WayToDetailExpand.AddUpAndSync)
				{
					if (( ( stockDetailList[i].SalesSlipDtlNumSync != 0 ) && ( stockDetailList[i].AcptAnOdrStatusSync != 0 ) ) &&
						( ( salesSlipWorkArray != null ) && ( salesDetailWorkArray != null ) ))
					{
						SalesSlipWork addUpOrgSalesSlipWork = null;
						SalesDetailWork addUpOrgSalesDetailWork = null;

						foreach (SalesDetailWork salesDetailWork in salesDetailWorkArray)
						{
							// �󒍃X�e�[�^�X(����),���㖾�גʔ�(����)�������f�[�^�𒊏o����
							if (( stockDetailList[i].AcptAnOdrStatusSync == salesDetailWork.AcptAnOdrStatus ) &&
								( stockDetailList[i].SalesSlipDtlNumSync == salesDetailWork.SalesSlipDtlNum ))
							{
								addUpOrgSalesDetailWork = salesDetailWork;
								break;
							}
						}

						if (addUpOrgSalesDetailWork != null)
						{
							foreach (SalesSlipWork salesSlipWork in salesSlipWorkArray)
							{
								if (( addUpOrgSalesDetailWork.SalesSlipNum == salesSlipWork.SalesSlipNum ) &&
									( addUpOrgSalesDetailWork.AcptAnOdrStatus == salesSlipWork.AcptAnOdrStatus ))
								{
									addUpOrgSalesSlipWork = salesSlipWork;
									break;
								}
							}
						}

						if (( addUpOrgSalesSlipWork != null ) && ( addUpOrgSalesDetailWork != null ))
						{
							this.SyncSalesInfoSetting(targetStockRowNo, addUpOrgSalesSlipWork, addUpOrgSalesDetailWork, memoMoveDiv);
						}
					}
				}
#endif
			}
		}

		/// <summary>
		/// ����������ݒ菈��
		/// </summary>
		/// <param name="stockRowNo">�d���s�ԍ�</param>
		/// <param name="salesSlipWork">����f�[�^���[�N�I�u�W�F�N�g</param>
		/// <param name="salesDetailWork">���㖾�׃��[�N�I�u�W�F�N�g</param>
		/// <param name="memoMoveDiv">�������ʋ敪</param>
		private void SyncSalesInfoSetting( int stockRowNo, SalesSlipWork salesSlipWork, SalesDetailWork salesDetailWork, MemoMoveDiv memoMoveDiv )
		{
			// �󒍎c���[���̃f�[�^�͖������őΏۊO
			if (salesDetailWork.AcptAnOdrRemainCnt == 0)
			{
				return;
			}

            StockInputDataSet.StockDetailRow stockDetailRow = this.GetStockDetailRow(stockRowNo);
			stockDetailRow.SalesCustomerCode = salesSlipWork.CustomerCode;
			stockDetailRow.SalesCustomerSnm = salesSlipWork.CustomerSnm;
			
			if (stockDetailRow!= null)
			{
				#region ������f�[�^(�d�������v��)�ւ̍��ڃZ�b�g

				SalesTemp salesTemp = ConvertStockSlip.UIDataFromParamData(salesSlipWork, salesDetailWork);

				// ����������擾����
				salesTemp.CreateDateTime = DateTime.MinValue;
				salesTemp.UpdateDateTime = DateTime.MinValue;
				salesTemp.FileHeaderGuid = Guid.Empty;
				salesTemp.LogicalDeleteCode = 0;

                //salesTemp.AcptAnOdrStatus = ( this._stockSlipInputInitDataAcs.GetSalesTtlSt().SalesFormalIn == 0 ) ? 30 : 40;	// �󒍃X�e�[�^�X�͔���S�̐ݒ�ɏ]���ăZ�b�g
				salesTemp.SalesSlipDtlNum = 0;

				salesTemp.SectionCode = LoginInfoAcquisition.Employee.BelongSectionCode.Trim(); // ���_�R�[�h
				salesTemp.SubSectionCode = this._stockSlip.SubSectionCode;                      // ����R�[�h
				salesTemp.SupplierFormalSync = 0;                                               // �d���`��(��������)
				salesTemp.StockSlipDtlNumSync = 0;                                              // �d�����גʔ�(��������)
				salesTemp.AcptAnOdrStatusSrc = salesDetailWork.AcptAnOdrStatus;                 // �󒍃X�e�[�^�X(�v�㌳)
				salesTemp.SalesSlipDtlNumSrc = salesDetailWork.SalesSlipDtlNum;                 // ���㖾�גʔ�(�v�㌳)
				salesTemp.CommonSeqNo = salesDetailWork.CommonSeqNo;                            // ���ʒʔ�
				salesTemp.AcceptAnOrderNo = salesDetailWork.AcceptAnOrderNo;                    // �󒍔ԍ�
				salesTemp.SupplierSlipCd = this._stockSlip.SupplierSlipCd;                      // �d���`�[�敪

				salesTemp.DebitNoteDiv = this._stockSlip.DebitNoteDiv;                          // �ԓ`�敪
				salesTemp.DebitNLnkAcptAnOdr = 0;                                               // �ԍ��A���󒍔ԍ�
				salesTemp.SalesSlipCd = ( this._stockSlip.SupplierSlipCd == 10 ) ? 0 : 1;       // ����`�[�敪
				salesTemp.AccRecDivCd = this._stockSlip.AccPayDivCd;                            // ���|�敪
				salesTemp.SupplierFormalSync = this._stockSlip.SupplierFormal;                  // �d���`���i�����j
				//salesTemp.ServiceSlipCd = 0;                                                  // �T�[�r�X�`�[�敪
				salesTemp.PartySaleSlipNum = string.Empty;
				salesTemp.SalesInpSecCd = this._stockSlip.StockSectionCd.Trim();                // ������͋��_�R�[�h
				salesTemp.DemandAddUpSecCd = this._stockSlip.StockAddUpSectionCd.Trim();        // �����v�㋒�_�R�[�h
				salesTemp.ResultsAddUpSecCd = this._stockSlip.StockSectionCd.Trim();            // ���ьv�㋒�_�R�[�h
				salesTemp.UpdateSecCd = this._stockSlip.SectionCode.Trim();                     // �X�V���_�R�[�h
				salesTemp.SearchSlipDate = DateTime.Today;                                      // �`�[�������t
				salesTemp.ShipmentDay = this._stockSlip.ArrivalGoodsDay;                        // �o�ד��t
				if (salesTemp.AcptAnOdrStatus == 30)
				{
					salesTemp.SalesDate = ( this._stockSlip.SupplierFormal == 0 ) ? this._stockSlip.StockDate : this._stockSlip.ArrivalGoodsDay;    // ������t
				}
				else
				{
					salesTemp.SalesDate = DateTime.MinValue;
				}
				salesTemp.ConsTaxRate = this._stockSlipInputInitDataAcs.GetTaxRate(( this._stockSlip.SupplierFormal == 0 ) ? this._stockSlip.StockDate : this._stockSlip.ArrivalGoodsDay); // ����Őŗ�

				salesTemp.SalesInputCode = this._stockSlip.StockInputCode.Trim();               // ������͎҃R�[�h
				salesTemp.SalesInputName = this._stockSlip.StockInputName.Trim();               // ������͎Җ���
				salesTemp.SalesEmployeeCd = this._stockSlip.StockAgentCode.Trim();              // �̔��]�ƈ��R�[�h
				salesTemp.SalesEmployeeNm = this._stockSlip.StockAgentName.Trim();              // �̔��]�ƈ�����
				salesTemp.AutoDepositCd = 0;                                                    // ���������敪
				salesTemp.SlipNote = string.Empty;                                              // �`�[���l
                salesTemp.SlipNote2 = string.Empty;                                             // �`�[���l�Q
				salesTemp.ReconcileFlag = 0;                                                    // �����t���O
                salesTemp.SlipPrtSetPaperId = string.Empty;                                     // �`�[����ݒ�p���[ID
				salesTemp.CompleteCd = 0;                                                       // �ꎮ�`�[�敪
				//salesTemp.SalesPriceFracProcCd = stockDetailRow.SalesPriceFracProcCd;         // ������z�[�������敪
				salesTemp.ShipmentCnt = salesDetailWork.AcptAnOdrRemainCnt;                     // �o�א��i = �󒍎c�j
				salesTemp.AcptAnOdrRemainCnt = salesDetailWork.AcptAnOdrRemainCnt;              // �󒍎c
				salesTemp.GrsProfitChkDiv = 0;                                                  // �e���`�F�b�N�敪
                salesTemp.PartySlipNumDtl = string.Empty;                                       // �����`�[�ԍ��i���ׁj
				//salesTemp.DtlNote = stockDetailRow.DtlNote;                                   // ���ה��l
                salesTemp.OrderNumber = string.Empty;                                           // �����ԍ�

				switch (memoMoveDiv)
				{
					case MemoMoveDiv.All:
						break;
					case MemoMoveDiv.None:
						{
                            salesTemp.SlipMemo1 = string.Empty;                 // �`�[�����P
                            salesTemp.SlipMemo2 = string.Empty;                 // �`�[�����Q
                            salesTemp.SlipMemo3 = string.Empty;                 // �`�[�����R
                            salesTemp.SlipMemo4 = string.Empty;                 // �`�[�����S
                            salesTemp.SlipMemo5 = string.Empty;                 // �`�[�����T
                            salesTemp.SlipMemo6 = string.Empty;                 // �`�[�����U
                            salesTemp.InsideMemo1 = string.Empty;               // �Г������P
                            salesTemp.InsideMemo2 = string.Empty;               // �Г������Q
                            salesTemp.InsideMemo3 = string.Empty;               // �Г������R
                            salesTemp.InsideMemo4 = string.Empty;               // �Г������S
                            salesTemp.InsideMemo5 = string.Empty;               // �Г������T
                            salesTemp.InsideMemo6 = string.Empty;               // �Г������U
							break;
						}
					case MemoMoveDiv.SlipMemoOnly:
						{
                            salesTemp.InsideMemo1 = string.Empty;               // �Г������P
                            salesTemp.InsideMemo2 = string.Empty;               // �Г������Q
                            salesTemp.InsideMemo3 = string.Empty;               // �Г������R
                            salesTemp.InsideMemo4 = string.Empty;               // �Г������S
                            salesTemp.InsideMemo5 = string.Empty;               // �Г������T
                            salesTemp.InsideMemo6 = string.Empty;               // �Г������U
							break;
						}
				}

				CustomerInfo claim;
                if (this._customerInfoAcs == null) this._customerInfoAcs = new CustomerInfoAcs();
				int status = this._customerInfoAcs.ReadDBData(this._enterpriseCode, salesTemp.ClaimCode, true, out claim);
				if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
				{
					claim = new CustomerInfo();
				}

				salesTemp.TotalDay = claim.TotalDay;				// ����
				salesTemp.NTimeCalcStDate = claim.NTimeCalcStDate;	// ���񊨒�J�n��

                //// �v����A�����敪�̍ăZ�b�g
                //this._salesTempInputAcs.SettingAddUpDate(ref salesTemp);

                //// ������z�Čv�Z
                //this._salesTempInputAcs.CalculationSalesMoney(ref salesTemp);

                //// ���㌴���Čv�Z
                //this._salesTempInputAcs.CalculationCost(ref salesTemp);

                //// �e���`�F�b�N�敪�ݒ�
                //this._salesTempInputAcs.GrsProfitChkDivSetting(ref salesTemp);

				this.CacheSalesTemp(stockRowNo, salesTemp);

				#endregion
			}
		}

		/// <summary>
		/// �d�����׍s�I�u�W�F�N�g�ɃR�s�[�����ׁA�݌ɂ�薾�׏����ꊇ�ݒ肵�܂��B
		/// </summary>
		/// <param name="stockRowNo">�s�ԍ�</param>
		/// <param name="stockDetail">�R�s�[�����׃I�u�W�F�N�g</param>
		/// <param name="stock">�݌ɏ��I�u�W�F�N�g</param>
		/// <param name="isAddUp">true:���׌v��(�����c����ݒ�) false:���׃R�s�[</param>
		/// <param name="memoMoveDiv">�������ʋ敪</param>
        public void StockDetailRowSettingFromStockDetail( int stockRowNo, StockDetail stockDetail, Stock stock, bool isAddUp, MemoMoveDiv memoMoveDiv )
		{
            StockInputDataSet.StockDetailRow row = this.GetStockDetailRow(stockRowNo);

			if (row != null)
			{
				this.ClearStockDetailRow(row);

				if (stockDetail != null)
				{
					int sign = ( this._stockSlip.SupplierSlipCd == 20 ) ? -1 : 1;

					#region �����ڂ̃Z�b�g

                    #region ���̂܂܃Z�b�g���鍀��
                    row.StockSlipCdDtl = stockDetail.StockSlipCdDtl;                    // �d���`�[�敪�i���ׁj
                    row.GoodsKindCode = stockDetail.GoodsKindCode;                      // ���i����
                    row.GoodsMakerCd = stockDetail.GoodsMakerCd;                        // ���i���[�J�[�R�[�h
                    row.MakerName = stockDetail.MakerName;                              // ���[�J�[����
                    row.MakerKanaName = stockDetail.MakerKanaName;                      // ���[�J�[�J�i����
                    row.CmpltMakerKanaName = stockDetail.CmpltMakerKanaName;            // ���[�J�[�J�i���́i�ꎮ�j
                    row.GoodsNo = stockDetail.GoodsNo;                                  // ���i�ԍ�
                    row.GoodsName = stockDetail.GoodsName;                              // ���i����
                    row.GoodsNameKana = stockDetail.GoodsNameKana;                      // ���i���̃J�i
                    row.GoodsLGroup = stockDetail.GoodsLGroup;                          // ���i�啪�ރR�[�h
                    row.GoodsLGroupName = stockDetail.GoodsLGroupName;                  // ���i�啪�ޖ���
                    row.GoodsMGroup = stockDetail.GoodsMGroup;                          // ���i�����ރR�[�h
                    row.GoodsMGroupName = stockDetail.GoodsMGroupName;                  // ���i�����ޖ���
                    row.BLGroupCode = stockDetail.BLGroupCode;                          // BL�O���[�v�R�[�h
                    row.BLGroupName = stockDetail.BLGroupName;                          // BL�O���[�v�R�[�h����
                    row.BLGoodsCode = stockDetail.BLGoodsCode;                          // BL���i�R�[�h
                    row.BLGoodsFullName = stockDetail.BLGoodsFullName;                  // BL���i�R�[�h���́i�S�p�j
                    row.EnterpriseGanreCode = stockDetail.EnterpriseGanreCode;          // ���Е��ރR�[�h
                    row.EnterpriseGanreName = stockDetail.EnterpriseGanreName;          // ���Е��ޖ���
                    row.OpenPriceDiv = stockDetail.OpenPriceDiv;                        // �I�[�v�����i�敪
                    row.GoodsRateRank = stockDetail.GoodsRateRank;                      // ���i�|�������N
                    row.CustRateGrpCode = stockDetail.CustRateGrpCode;                  // ���Ӑ�|���O���[�v�R�[�h
                    row.SuppRateGrpCode = stockDetail.SuppRateGrpCode;                  // �d����|���O���[�v�R�[�h
                    row.ListPriceTaxExcFl = stockDetail.ListPriceTaxExcFl;              // �艿�i�Ŕ��C�����j
                    row.ListPriceTaxIncFl = stockDetail.ListPriceTaxIncFl;              // �艿�i�ō��C�����j
                    row.StockRate = stockDetail.StockRate;                              // �d����
                    //row.RateSectStckUnPrc = stockDetail.RateSectStckUnPrc;              // �|���ݒ苒�_�i�d���P���j
                    //row.RateDivStckUnPrc = stockDetail.RateDivStckUnPrc;                // �|���ݒ�敪�i�d���P���j
                    row.UnPrcCalcCdStckUnPrc = stockDetail.UnPrcCalcCdStckUnPrc;        // �P���Z�o�敪�i�d���P���j
                    row.PriceCdStckUnPrc = stockDetail.PriceCdStckUnPrc;                // ���i�敪�i�d���P���j
                    row.StdUnPrcStckUnPrc = stockDetail.StdUnPrcStckUnPrc;              // ��P���i�d���P���j
                    row.FracProcUnitStcUnPrc = stockDetail.FracProcUnitStcUnPrc;        // �[�������P�ʁi�d���P���j
                    row.FracProcStckUnPrc = stockDetail.FracProcStckUnPrc;              // �[�������i�d���P���j
                    row.StockUnitPriceFl = stockDetail.StockUnitPriceFl;                // �d���P���i�Ŕ��C�����j
                    row.StockUnitTaxPriceFl = stockDetail.StockUnitTaxPriceFl;          // �d���P���i�ō��C�����j
                    //row.StockUnitChngDiv = stockDetail.StockUnitChngDiv;                // �d���P���ύX�敪
                    row.BfStockUnitPriceFl = stockDetail.BfStockUnitPriceFl;            // �ύX�O�d���P���i�����j
                    row.BfListPrice = stockDetail.BfListPrice;                          // �ύX�O�艿
                    row.RateBLGoodsCode = stockDetail.RateBLGoodsCode;                  // BL���i�R�[�h�i�|���j
                    row.RateBLGoodsName = stockDetail.RateBLGoodsName;                  // BL���i�R�[�h���́i�|���j
                    row.StockCount = stockDetail.StockCount;                            // �d����
                    row.StockPriceTaxExc = stockDetail.StockPriceTaxExc;                // �d�����z�i�Ŕ����j
                    row.StockPriceTaxInc = stockDetail.StockPriceTaxInc;                // �d�����z�i�ō��݁j
                    row.StockGoodsCd = stockDetail.StockGoodsCd;                        // �d�����i�敪
                    row.StockPriceConsTax = stockDetail.StockPriceConsTax;              // �d�����z����Ŋz
                    row.TaxationCode = stockDetail.TaxationCode;                        // �ېŋ敪
                    row.StockDtiSlipNote1 = stockDetail.StockDtiSlipNote1;              // �d���`�[���ה��l1
                    row.SalesCustomerCode = stockDetail.SalesCustomerCode;              // �̔���R�[�h
                    row.SalesCustomerSnm = stockDetail.SalesCustomerSnm;                // �̔��旪��

                    #endregion

                    row.OrderRemainCnt = ( this._stockSlip.SupplierFormal == 0 ) ? 0 : row.StockCount;  // �����c
                    row.TaxDiv = row.TaxationCode;
                    row.CanTaxDivChange = false;                                                        // �ېŔ�ېŋ敪�ύX�\�t���O

                    // �����̓������ʋ敪�ɏ]���ăR�s�[����
                    switch (memoMoveDiv)
                    {
                        // �S��
                        case MemoMoveDiv.All:
                            {
                                row.SlipMemo1 = stockDetail.SlipMemo1;                  // �`�[�����P
                                row.SlipMemo2 = stockDetail.SlipMemo2;                  // �`�[�����Q
                                row.SlipMemo3 = stockDetail.SlipMemo3;                  // �`�[�����R
                                row.InsideMemo1 = stockDetail.InsideMemo1;              // �Г������P
                                row.InsideMemo2 = stockDetail.InsideMemo2;              // �Г������Q
                                row.InsideMemo3 = stockDetail.InsideMemo3;              // �Г������R
                                break;
                            }
                        // �ЊO�����̂�
                        case MemoMoveDiv.SlipMemoOnly:
                            {
                                row.SlipMemo1 = stockDetail.SlipMemo1;                  // �`�[�����P
                                row.SlipMemo2 = stockDetail.SlipMemo2;                  // �`�[�����Q
                                row.SlipMemo3 = stockDetail.SlipMemo3;                  // �`�[�����R
                                break;
                            }
                        // ���Ȃ�
                        case MemoMoveDiv.None:
                            break;
                    }

                    row.TaxationCode = stockDetail.TaxationCode;

                    // �\���p�艿�A�\���p�P���A�\���p�d�����z�i�]�ŕ����A���z�\���ɂ�蕪��j
                    if (this._stockSlip.SuppCTaxLayCd == 9)
                    {
                        row.StockUnitPriceDisplay = stockDetail.StockUnitPriceFl;
                        row.StockPriceDisplay = stockDetail.StockPriceTaxExc * sign;
                        row.ListPriceDisplay = stockDetail.ListPriceTaxExcFl;
                    }
                    else if (this._stockSlip.SuppTtlAmntDspWayCd == 1)
                    {
                        // ���z�\�����Ă���ꍇ�͐ō��݉��i��\������
                        row.StockUnitPriceDisplay = stockDetail.StockUnitTaxPriceFl;
                        row.StockPriceDisplay = stockDetail.StockPriceTaxInc * sign;
                        row.ListPriceDisplay = stockDetail.ListPriceTaxIncFl;
                    }
                    else
                    {
                        // �ېŕ����ɂ�蕪��
                        if (stockDetail.TaxationCode == (int)CalculateTax.TaxationCode.TaxInc)
                        {
                            row.StockUnitPriceDisplay = stockDetail.StockUnitTaxPriceFl;
                            row.StockPriceDisplay = stockDetail.StockPriceTaxInc * sign;
                            row.ListPriceDisplay = stockDetail.ListPriceTaxIncFl;
                        }
                        if (( stockDetail.TaxationCode == (int)CalculateTax.TaxationCode.TaxExc ) ||
                            ( stockDetail.TaxationCode == (int)CalculateTax.TaxationCode.TaxNone ))
                        {
                            row.StockUnitPriceDisplay = stockDetail.StockUnitPriceFl;
                            row.StockPriceDisplay = stockDetail.StockPriceTaxExc * sign;
                            row.ListPriceDisplay = stockDetail.ListPriceTaxExcFl;
                        }
                    }

                    // �s�l�����̏ꍇ
                    if ( stockDetail.StockSlipCdDtl == 2 )
                    {
                        // �d�������O�͍s�l����
                        if (stockDetail.StockCount == 0)
                        {
                            row.StockUnitPriceDisplay = 0;	// �P���͔�\��
                            row.EditStatus = StockSlipInputAcs.ctEDITSTATUS_RowDiscount;
                        }
                        else
                        {
                            row.EditStatus = StockSlipInputAcs.ctEDITSTATUS_GoodsDiscount;
                        }
                    }
                    else
                    {
                        row.EditStatus = StockSlipInputAcs.ctEDITSTATUS_AllOK;
                    }

                    // �݌ɏ��
                    if (stock != null)
                    {
                        this.CacheStockInfo(stock);

                        row.WarehouseCode = stock.WarehouseCode.Trim();
                        row.WarehouseName = stock.WarehouseName;
                        row.WarehouseShelfNo = stock.WarehouseShelfNo;
                        row.StockOrderDivCd = 1;
                    }
                    else
                    {
                        row.StockOrderDivCd = 0;
                    }

                    row.StockPriceDiectInput = ( ( row.StockUnitPriceDisplay == 0 ) && ( row.StockPriceDisplay != 0 ) );

                    // �v�㏈���̏ꍇ�̕␳����
                    if (isAddUp)
                    {
                        row.EditStatus = StockSlipInputAcs.ctEDITSTATUS_ArrivalAddUpNew;
                        row.StockCount = stockDetail.OrderRemainCnt;
                        row.OrderCnt = stockDetail.OrderRemainCnt;					// ������
                        row.StockCountDefault = stockDetail.OrderRemainCnt;			// ����(�����\��)���v�㌳���ׂ̔����c
                        row.StockCountMax = stockDetail.OrderRemainCnt;				// �v��\�����v�㌳���ׂ̔����c
                        row.StockCountMin = 0;										// �v��ςݐ��ʁ�0
                        row.SupplierFormalSrc = stockDetail.SupplierFormal;			// �v�㌳�d���`��
                        row.StockSlipDtlNumSrc = stockDetail.StockSlipDtlNum;		// �v�㌳���גʔ�
                        row.CommonSeqNo = stockDetail.CommonSeqNo;					// ���ʒʔ�
                        row.AcceptAnOrderNo = stockDetail.AcceptAnOrderNo;			// �󒍔ԍ�

                        if (( row.StockPriceDiectInput ) && ( stockDetail.OrderRemainCnt == stockDetail.StockCount ))
                        {
                        }
                        else
                        {
                            row.StockPriceDiectInput = false;
                            this.CalculateStockPrice(row);
                        }

                        this.LnkStockDetailRowSettingFromStockDetail(stockDetail);

                        // �����ԍ��͔����v�㎞�̂݃R�s�[����
                        if (stockDetail.SupplierFormal == 2)
                        {
                            row.OrderNumber = stockDetail.OrderNumber;              // �����ԍ�
                        }
                    }

                    row.StockUnitChngDiv = ( row.BfStockUnitPriceFl != row.StockUnitPriceFl ) ? 1 : 0;  // �P���ύX�敪

                    // ���z�����l�֌W
                    row.StockUnitPriceDefault = row.StockUnitPriceFl;
                    row.StockUnitTaxPriceDefault = row.StockUnitTaxPriceFl;
                    row.StockPriceTaxExcDefault = row.StockPriceTaxExc;
                    row.StockPriceTaxIncDefault = row.StockPriceTaxInc;

                    row.StockCountDisplay = row.StockCount * sign;			// ����(�\��)


					#endregion
				}
			}
		}

		/// <summary>
		/// �v�㌳�d�����׍s�I�u�W�F�N�g�ɃR�s�[�����ׂ�薾�׏���ݒ肵�܂��B
		/// </summary>
		/// <param name="stockDetail"></param>
		private void LnkStockDetailRowSettingFromStockDetail( StockDetail stockDetail )
		{
			CacheAddUpSrcStockDetailDataTable(stockDetail, this._addUpSrcDetailDataTable);
		}


		/// <summary>
		/// �d�����׃f�[�^�s�I�u�W�F�N�g�ɍs�l������ݒ肵�܂��B
		/// </summary>
		/// <param name="stockRowNo">�d���s�ԍ�</param>
        public void StockDetailRowDiscountSetting(int stockRowNo)
        {
            StockInputDataSet.StockDetailRow row = this.GetStockDetailRow(stockRowNo);

            if (row != null)
            {
                this.ClearStockDetailRow(row);

                row.EditStatus = ctEDITSTATUS_RowDiscount;      // �s�l���X�e�[�^�X
                row.GoodsName = this._stockSlipInputInitDataAcs.GetStockTtlSt().StockDiscountName;		// ���i����
                //row.GoodsShortName= this._stockSlipInputInitDataAcs.GetStockTtlSt().StockDiscountName;	// ���i���̗���
                row.StockSlipCdDtl = 2;                         // �d���`�[�敪(����)

                // ���z�\������ꍇ�͓��ŁA���z�\�����Ȃ��ꍇ�͊O��
                row.TaxationCode = ( this._stockSlip.SuppTtlAmntDspWayCd == 0 ) ? (int)CalculateTax.TaxationCode.TaxExc : (int)CalculateTax.TaxationCode.TaxInc;
                row.TaxDiv = row.TaxationCode;
                row.CanTaxDivChange = false;
            }
        }

		/// <summary>
		/// �d�����׃f�[�^�s�I�u�W�F�N�g�ɏ��i�l������ݒ肵�܂��B
		/// </summary>
		/// <param name="stockRowNo">�d���s�ԍ�</param>
		public void StockDetailGoodsDiscountSetting( int stockRowNo )
		{
            StockInputDataSet.StockDetailRow row = this.GetStockDetailRow(stockRowNo);

			if (row != null)
			{

			    this.ClearStockDetailRow(row);

				row.StockSlipCdDtl = 2;							// �d���`�[�敪(����)
				row.EditStatus = ctEDITSTATUS_GoodsDiscount;	// ���i�l���X�e�[�^�X
				row.StockCountDisplay = -1;
				row.StockCount = ( this._stockSlip.SupplierSlipCd == 20 ) ? -1 : 1;

			    // ���z�\������ꍇ�͓��ŁA���z�\�����Ȃ��ꍇ�͊O��
                if (this._stockSlip.SuppCTaxLayCd == 9)
                {
                    row.TaxationCode = (int)CalculateTax.TaxationCode.TaxNone;
                }
                else if (this._stockSlip.SuppTtlAmntDspWayCd == 0)
                {
                    row.TaxationCode = (int)CalculateTax.TaxationCode.TaxExc;
                }
                else
                {
                    row.TaxationCode = (int)CalculateTax.TaxationCode.TaxInc;
                }
			    row.TaxDiv = row.TaxationCode;
			    row.CanTaxDivChange = false;
			}
		}

		/// <summary>
		/// �p�i���͏��ݒ菈��
		/// </summary>
		/// <param name="stockRowNo"></param>
		public void StockDetailRowUtensilsInput(int stockRowNo)
		{
            StockInputDataSet.StockDetailRow row = this.GetStockDetailRow(stockRowNo);

			if (row != null)
			{
				string goodsName = row.GoodsName;

				int stockSlipCdDtl = row.StockSlipCdDtl;
				this.ClearStockDetailRow(row);

				row.GoodsName = goodsName;		// �i��

				if (stockSlipCdDtl == 2)
				{
					row.StockCountDisplay = -1;
					row.StockSlipCdDtl = stockSlipCdDtl;

                    // �s�l�����̏ꍇ�͂��̂܂�
                    if (row.EditStatus == ctEDITSTATUS_RowDiscount)
                    {
                        row.EditStatus = ctEDITSTATUS_GoodsDiscount;
                    }
				}
				else
				{
					row.StockCountDisplay = 1;
					row.EditStatus = ctEDITSTATUS_AllOK; // �s�l���X�e�[�^�X
				}


				int sign = ( this._stockSlip.SupplierSlipCd == 20 ) ? -1 : 1;


				row.StockCount = sign * row.StockCountDisplay;

				row.TaxDiv = ( this._stockSlip.SuppTtlAmntDspWayCd == 0 ) ? (int)CalculateTax.TaxationCode.TaxExc : row.TaxationCode = (int)CalculateTax.TaxationCode.TaxInc;
					
				row.CanTaxDivChange = true;
			}
		}

		#region �e���ڂ̓��͐ݒ�(���i�E�݌ɂ�����)

		/// <summary>
		/// �d�����׍s�I�u�W�F�N�g�ɑq�ɖ��́A�q�ɃR�[�h��ݒ肵�܂��B�i�I�[�o�[���[�h�j
		/// </summary>
		/// <param name="stockRowNo">�d�����׍s�ԍ�</param>
		/// <param name="warehouseCode">�q�ɃR�[�h</param>
		/// <param name="warehouseName">�q�ɖ���</param>
		public void StockDetialWarehouseInfoSetting( int stockRowNo, string warehouseCode, string warehouseName)
		{
            StockInputDataSet.StockDetailRow row = this.GetStockDetailRow(stockRowNo);
			if (row == null) return;

			row.WarehouseCode = warehouseCode.Trim();
			row.WarehouseName = warehouseName;

			if (String.IsNullOrEmpty(warehouseCode.Trim()))
			{
                row.WarehouseShelfNo = string.Empty;
				row.ShipmentPosCnt = 0;
				row.ShipmentPosCntDisplay = 0;
			}
            row.AcceptChanges();
		}

        /// <summary>
		/// �d�����׍s�I�u�W�F�N�g�Ƀ��[�J�[�R�[�h�ƃ��[�J�[���̂�ݒ肵�܂��B
		/// </summary>
		/// <param name="stockRowNo">�d�����׍s�ԍ�</param>
		/// <param name="goodsMakerCd">���[�J�[�R�[�h</param>
		/// <param name="makerName">���[�J�[����</param>
        /// <param name="makerKanaName">���[�J�[���̃J�i</param>
        public void StockDetailMakerInfoSetting( int stockRowNo, int goodsMakerCd, string makerName, string makerKanaName )
        {
            bool isMakerChanged;
            this.StockDetailMakerInfoSetting(stockRowNo, goodsMakerCd, makerName, makerKanaName, out isMakerChanged);
        }

		/// <summary>
		/// �d�����׍s�I�u�W�F�N�g�Ƀ��[�J�[�R�[�h�ƃ��[�J�[���̂�ݒ肵�܂��B
		/// </summary>
		/// <param name="stockRowNo">�d�����׍s�ԍ�</param>
		/// <param name="goodsMakerCd">���[�J�[�R�[�h</param>
		/// <param name="makerName">���[�J�[����</param>
        /// <param name="makerKanaName">���[�J�[���̃J�i</param>
        /// <param name="isMakerChanged">���[�J�[�ύX�L��</param>
        public void StockDetailMakerInfoSetting( int stockRowNo, int goodsMakerCd, string makerName,string makerKanaName, out bool isMakerChanged )
        {
            StockInputDataSet.StockDetailRow row = this.GetStockDetailRow(stockRowNo);

            isMakerChanged = ( row.GoodsMakerCd != goodsMakerCd );
            row.GoodsMakerCd = goodsMakerCd;
            row.MakerName = makerName;
            row.MakerKanaName = makerKanaName;
        }

		/// <summary>
		/// �d�����׍s�I�u�W�F�N�g�ɔ̔������ݒ肵�܂��B�i�I�[�o�[���[�h�j
		/// </summary>
		/// <param name="stockRowNo">�d�����׍s�ԍ�</param>
        /// <param name="customerInfo">���Ӑ�}�X�^�I�u�W�F�N�g</param>
		public void StockDetailSalesCustomerInfoSetting( int stockRowNo, CustomerInfo customerInfo )
		{
            StockInputDataSet.StockDetailRow row = this.GetStockDetailRow(stockRowNo);

            row.SalesCustomerCode = customerInfo.CustomerCode;
            row.SalesCustomerSnm = customerInfo.CustomerSnm;
		}

        /// <summary>
        /// �d�����׍s�I�u�W�F�N�g��BL�R�[�h�֘A�̏���ݒ肵�܂��B�i�I�[�o�[���[�h�j
        /// </summary>
        /// <param name="stockRowNo">�d�����׍s�ԍ�</param>
        /// <param name="blCode">BL�R�[�h</param>
        /// <returns>False:BL�R�[�h�}�X�^�擾���s</returns>
        public bool StockDetailBLGoodsInfoSetting( int stockRowNo, int blCode )
        {
            BLGoodsCdUMnt bLGoodsCdUMnt = new BLGoodsCdUMnt();
            BLGroupU bLGroupU = new BLGroupU();
            GoodsGroupU goodsGroupU = new GoodsGroupU();
            UserGdBdU userGdBdU = new UserGdBdU();

            if (blCode != 0)
            {
                // BL�O���[�v�A�����ށA�啪�ޏ����擾
                if (!this._stockSlipInputInitDataAcs.GetBLGoodsRelation(blCode, out bLGoodsCdUMnt, out bLGroupU, out goodsGroupU, out userGdBdU))
                {
                    // ���s����
                    return false;
                }
            }

            // 2009.03.31 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //this.StockDetailBLGoodsInfoSetting(stockRowNo, bLGoodsCdUMnt, bLGroupU, goodsGroupU, userGdBdU, true);

            StockInputDataSet.StockDetailRow stockDetailRow = this.GetStockDetailRow(stockRowNo);

            bool changeGoodsName = false;
            if (blCode != 0)
            {
                if ((this._stockSlipInputInitDataAcs.GetStockTtlSt().GoodsNmReDispDivCd == 1) ||
                    ((this._stockSlipInputInitDataAcs.GetStockTtlSt().GoodsNmReDispDivCd == 0) &&
                     (string.IsNullOrEmpty(stockDetailRow.GoodsName)))) changeGoodsName = true; // �i���ĕ\���敪 0:���Ȃ� 1:����
            }

            this.StockDetailBLGoodsInfoSetting(stockRowNo, bLGoodsCdUMnt, bLGroupU, goodsGroupU, userGdBdU, changeGoodsName);
            // 2009.03.31 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<            

            return true;
        }

        /// <summary>
        /// �d�����׍s�I�u�W�F�N�g��BL�R�[�h�֘A�̏���ݒ肵�܂��B�i�I�[�o�[���[�h�j
        /// </summary>
        /// <param name="stockRowNo">�d�����׍s�ԍ�</param>
        /// <param name="bLGoodsCdUMnt">BL�R�[�h�}�X�^</param>
        public void StockDetailBLGoodsInfoSetting(int stockRowNo, BLGoodsCdUMnt bLGoodsCdUMnt)
        {
            BLGoodsCdUMnt bLGoodsCdUMntWk = new BLGoodsCdUMnt();
            BLGroupU bLGroupU = new BLGroupU();
            GoodsGroupU goodsGroupU = new GoodsGroupU();
            UserGdBdU userGdBdU = new UserGdBdU();

            // BL�O���[�v�A�����ށA�啪�ޏ����擾
            this._stockSlipInputInitDataAcs.GetBLGoodsRelation(bLGoodsCdUMnt.BLGoodsCode, out bLGoodsCdUMntWk, out bLGroupU, out goodsGroupU, out userGdBdU);

            // 2009.03.31 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //this.StockDetailBLGoodsInfoSetting(stockRowNo, bLGoodsCdUMnt, bLGroupU, goodsGroupU, userGdBdU, true);

            StockInputDataSet.StockDetailRow stockDetailRow = this.GetStockDetailRow(stockRowNo);

            bool changeGoodsName = false;
            if ((this._stockSlipInputInitDataAcs.GetStockTtlSt().GoodsNmReDispDivCd == 1) ||
                ((this._stockSlipInputInitDataAcs.GetStockTtlSt().GoodsNmReDispDivCd == 0) &&
                 (string.IsNullOrEmpty(stockDetailRow.GoodsName)))) changeGoodsName = true; // �i���ĕ\���敪 0:���Ȃ� 1:����

            this.StockDetailBLGoodsInfoSetting(stockRowNo, bLGoodsCdUMnt, bLGroupU, goodsGroupU, userGdBdU, changeGoodsName);
            // 2009.03.31 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<   
        }

        /// <summary>
        /// �d�����׍s�I�u�W�F�N�g��BL�R�[�h�֘A�̏����N���A���܂��B
        /// </summary>
        /// <param name="stockRowNo">�d�����׍s�I�u�W�F�N�g</param>
        /// <returns></returns>
        public void StockDetailBLGoodsInfoClear( int stockRowNo )
        {
            this.StockDetailBLGoodsInfoSetting(stockRowNo, new BLGoodsCdUMnt(), new BLGroupU(), new GoodsGroupU(), new UserGdBdU(), false);
        }

        /// <summary>
        /// �d�����׍s�I�u�W�F�N�g��BL�R�[�h�֘A�̏���ݒ肵�܂��B
        /// </summary>
        /// <param name="stockRowNo">�d�����׍s�ԍ�</param>
        /// <param name="bLGoodsCdUMnt">BL�R�[�h�}�X�^</param>
        /// <param name="bLGroupU">�O���[�v�R�[�h�}�X�^</param>
        /// <param name="goodsGroupU">�����ރ}�X�^</param>
        /// <param name="userGdBdU">���[�U�[�K�C�h�}�X�^�i�啪�ޏ��j</param>
        /// <param name="changeGoodsName">True:�i����ύX����</param>
        private void StockDetailBLGoodsInfoSetting( int stockRowNo, BLGoodsCdUMnt bLGoodsCdUMnt, BLGroupU bLGroupU, GoodsGroupU goodsGroupU, UserGdBdU userGdBdU, bool changeGoodsName )
        {
            StockInputDataSet.StockDetailRow row = this.GetStockDetailRow(stockRowNo);

            if (row != null)
            {
                row.BLGoodsCode = bLGoodsCdUMnt.BLGoodsCode;
                row.BLGoodsFullName = bLGoodsCdUMnt.BLGoodsFullName;

                row.BLGroupCode = bLGroupU.BLGroupCode;
                row.BLGroupName = bLGroupU.BLGroupName;

                row.GoodsMGroup = goodsGroupU.GoodsMGroup;
                row.GoodsMGroupName = goodsGroupU.GoodsMGroupName;

                row.GoodsLGroup = userGdBdU.GuideCode;
                row.GoodsLGroupName = userGdBdU.GuideName;

                if (changeGoodsName)
                {
                    row.GoodsName = bLGoodsCdUMnt.BLGoodsFullName;
                    row.GoodsNameKana = bLGoodsCdUMnt.BLGoodsHalfName;
                }
            }
        }

		#endregion


		#endregion

        /// <summary>
        /// �d�����׃e�[�u���̊|�������N���A���܂��B
        /// </summary>
        public void StockDetailTableClearRateInfo()
        {
            this.StockDetailTableClearRateInfo(this._stockDetailDataTable);
        }

        /// <summary>
        /// �d�����׃e�[�u���̊|�������N���A���܂��B
        /// </summary>
        private void StockDetailTableClearRateInfo( StockInputDataSet.StockDetailDataTable stockDetailDataTable )
        {
            stockDetailDataTable.BeginLoadData();
            foreach (StockInputDataSet.StockDetailRow row in stockDetailDataTable)
            {
                row.RateSectStckUnPrc = string.Empty;           // �|���ݒ苒�_�i�d���P���j
                row.RateDivStckUnPrc = string.Empty;            // �|���ݒ�敪�i�d���P���j
                //row.UnPrcCalcCdStckUnPrc = 0;                   // �P���Z�o�敪�i�d���P���j
                //row.BfStockUnitPriceFl = 0;                     // �ύX�O�P��
                row.StockUnitChngDiv = ( row.BfStockUnitPriceFl != row.StockUnitPriceFl ) ? 1 : 0;
            }
            stockDetailDataTable.EndLoadData();
        }

		/// <summary>
        /// �d�����׃e�[�u���̏��i���i�̍Đݒ���s���܂��B
		/// </summary>
		public void StockDetailTableGoodsPriceReSetting()
		{
			this.StockDetailTableGoodsPriceReSetting(this._stockDetailDataTable);
		}

        /// <summary>
        /// ���i�Č�������
        /// </summary>
        /// <returns></returns>
        private int ReSearchGoods()
        {
            List<StockInputDataSet.StockDetailRow> targetRowList;
            List<GoodsUnitData> goodsUnitDataList;
            return this.ReSearchGoods(this._stockDetailDataTable, true, out targetRowList, out goodsUnitDataList);
        }

        /// <summary>
        /// ���i�Č�������
        /// </summary>
        /// <param name="stockDetailDataTable">�d�����׃e�[�u��</param>
        /// <param name="isCache">True:�L���b�V������</param>
        /// <param name="targetRowList">�Ώۍs�I�u�W�F�N�g���X�g</param>
        /// <param name="goodsUnitDataList">���i�A���f�[�^���X�g</param>
        private int ReSearchGoods(StockInputDataSet.StockDetailDataTable stockDetailDataTable, bool isCache, out List<StockInputDataSet.StockDetailRow> targetRowList, out  List<GoodsUnitData> goodsUnitDataList)
        {
            int status = -1;
            List<GoodsCndtn> goodsCndtnList = new List<GoodsCndtn>();
            goodsUnitDataList = null;
            targetRowList = new List<StockInputDataSet.StockDetailRow>();

            // ���i�����������X�g�𐶐�����
            foreach (StockInputDataSet.StockDetailRow row in stockDetailDataTable)
            {
                if (( ( row.EditStatus == ctEDITSTATUS_AllOK ) || ( row.EditStatus == ctEDITSTATUS_ArrivalAddUpEdit ) || ( row.EditStatus == ctEDITSTATUS_ArrivalAddUpNew ) ) && ( ( !string.IsNullOrEmpty(row.GoodsNo) && ( row.GoodsMakerCd != 0 ) ) ))
                {
                    GoodsCndtn goodsCndtn = new GoodsCndtn();
                    goodsCndtn.EnterpriseCode = this._enterpriseCode;
                    goodsCndtn.GoodsNo = row.GoodsNo;
                    goodsCndtn.GoodsMakerCd = row.GoodsMakerCd;
                    goodsCndtn.SectionCode = this._stockSlip.StockSectionCd;
                    goodsCndtn.IsSettingSupplier = 1;

                    goodsCndtnList.Add(goodsCndtn);
                    targetRowList.Add(row);
                }
            }
            if (goodsCndtnList.Count > 0)
            {
                // ���i�������s���A�P���Z�o�̃p�����[�^���쐬����
                string message;

                status = this._stockSlipInputInitDataAcs.GetGoodsUnitDataList(goodsCndtnList, out goodsUnitDataList, out message);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    if (isCache)
                    {
                        this.ClearGoodsCacheInfo();
                        this.CacheGoodsUnitData(goodsUnitDataList);
                    }
                }
            }
            return status;
        }

		/// <summary>
        /// �d�����׃e�[�u���̏��i���i�̍Đݒ���s���܂��B
		/// </summary>
		/// <param name="stockDetailDataTable">�d�����׃f�[�^�e�[�u���I�u�W�F�N�g</param>
        private void StockDetailTableGoodsPriceReSetting( StockInputDataSet.StockDetailDataTable stockDetailDataTable )
        {
            List<GoodsCndtn> goodsCndtnList = new List<GoodsCndtn>();

            List<StockInputDataSet.StockDetailRow> targetRowList = new List<StockInputDataSet.StockDetailRow>();
            List<GoodsUnitData> goodsUnitDataList;

            int status = this.ReSearchGoods(stockDetailDataTable, true, out targetRowList, out goodsUnitDataList);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // ���i�������s���A�P���Z�o�̃p�����[�^���쐬����
                List<UnitPriceCalcParam> unitPriceCalcParamList = new List<UnitPriceCalcParam>();

                foreach (StockInputDataSet.StockDetailRow row in targetRowList)
                {

                    GoodsUnitData goodsUnitData = this.GetGoodsUnitDataFromCache(row.GoodsNo, row.GoodsMakerCd);

                    if (goodsUnitData != null)
                    {
                        unitPriceCalcParamList.Add(this.CreateUnitPriceCalcParam(row, goodsUnitData));
                    }
                }

                // �P���Z�o���W���[���ŒP���ꊇ�v�Z�i�����[�g�P��ŏ�������j
                List<UnitPriceCalcRet> unitPriceCalcRetList = this.CalculateStockUnitPrice(unitPriceCalcParamList, goodsUnitDataList);

                // ���ʂ𖾍ׂɔ��f
                foreach (StockInputDataSet.StockDetailRow row in targetRowList)
                {
                    GoodsUnitData goodsUnitData = this.GetGoodsUnitDataFromCache(row.GoodsNo, row.GoodsMakerCd);
                    UnitPriceCalcRet unitPriceCalcRet = null;

                    foreach (UnitPriceCalcRet unitPriceCalcRetWk in unitPriceCalcRetList)
                    {
                        if (( unitPriceCalcRetWk.GoodsNo == row.GoodsNo ) &&
                            ( unitPriceCalcRetWk.GoodsMakerCd == row.GoodsMakerCd ))
                        {
                            unitPriceCalcRet = unitPriceCalcRetWk;
                            break;
                        }
                    }

                    double stockRate = row.StockRate;
                    double stockUnitPriceTaxExc = row.StockUnitPriceFl;
                    double stockUnitPriceTaxInc = row.StockUnitTaxPriceFl;

                    this.ClearStockDetailRateInfo(row, true);

                    // ���i�����Ɏ��s�����ꍇ
                    if (( goodsUnitData == null ) || ( unitPriceCalcRet == null ))
                    {
                        this.StockDetailRowListPriceSetting(row, goodsUnitData);
                        if (goodsUnitData != null)
                        {
                            row.RateBLGoodsCode = goodsUnitData.BLGoodsCode;
                            row.RateBLGoodsName = goodsUnitData.BLGoodsName;
                        }

                        if (stockRate != 0)
                        {
                            row.StockRate = stockRate;
                            double stockUnitPriceDisplay;
                            double fracProcUnitStcUnPrc = 0;
                            int fracProcStckUnPrc = 0;
                            this.CalculateStockUnitPriceByRate(row, out stockUnitPriceTaxExc, out stockUnitPriceTaxInc, out stockUnitPriceDisplay, ref fracProcUnitStcUnPrc, ref fracProcStckUnPrc);

                            row.UnPrcCalcCdStckUnPrc = (int)UnitPriceCalculation.UnitPrcCalcDiv.RateVal;    
                            row.StdUnPrcStckUnPrc = row.ListPriceTaxExcFl;
                            row.FracProcUnitStcUnPrc = fracProcUnitStcUnPrc;
                            row.FracProcStckUnPrc = fracProcStckUnPrc;
                        }
                        row.StockUnitPriceFl = stockUnitPriceTaxExc;
                        row.StockUnitTaxPriceFl = stockUnitPriceTaxInc;
                        row.BfStockUnitPriceFl = 0;
                        row.StockUnitChngDiv = ( row.BfStockUnitPriceFl != row.StockUnitPriceFl ) ? 1 : 0;
                        row.StockPriceDiectInput = ( ( row.StockUnitPriceFl == 0 ) && ( row.StockPriceTaxExc != 0 ) );
                    }
                    // ���i����OK�A�P���Z�oOK
                    else
                    {
                        this.StockDetailRowGoodsPriceSettingFromUnitPriceCalcRet(row, goodsUnitData, unitPriceCalcRet);
                        row.StockPriceDiectInput = false;
                    }
                    this.CalculateStockPrice(row);
                    this.StockDetailRowTaxationCodeSetting(this._stockSlip.SuppCTaxLayCd, this._stockSlip.SuppTtlAmntDspWayCd, row);
                }
            }
        }
        
        /// <summary>
        /// �w�肵���d���P���̒l�����Ɏd�����׍s�I�u�W�F�N�g�̒P������ݒ肵�܂��B
        /// </summary>
        /// <param name="row">�d�����׍s�I�u�W�F�N�g</param>
        /// <param name="priceInputType">���z���̓��[�h</param>
        /// <param name="stockUnitPrice">�P��</param>
        private void StockDetailRowStockUnitPriceSetting(StockInputDataSet.StockDetailRow row, PriceInputType priceInputType, double stockUnitPrice)
        {
            if (row != null)
            {
                if (this._supplierAcs == null) this._supplierAcs = new SupplierAcs();
                int stockTaxFrcProcCd = this._supplierAcs.GetStockFractionProcCd(this._enterpriseCode, this._stockSlip.SupplierCd, SupplierAcs.StockFracProcMoneyDiv.CnsTaxFrcProcCd);	// �d������Œ[�������R�[�h

                int taxFracProcCd = 0;
                double taxFracProcUnit = 0;
                this._stockSlipInputInitDataAcs.GetStockFractionProcInfo(StockSlipInputInitDataAcs.ctFracProcMoneyDiv_Tax, stockTaxFrcProcCd, 0, out taxFracProcUnit, out taxFracProcCd);

                double stockUnitPriceFl;
                double stockUnitTaxPriceFl;
                double stockUnitPriceDisplay;

                this.CalculatePrice(priceInputType, stockUnitPrice, row.TaxationCode, this._stockSlip.SuppTtlAmntDspWayCd, this._stockSlip.SuppCTaxLayCd, this._stockSlip.SupplierConsTaxRate, stockTaxFrcProcCd, out  stockUnitPriceFl, out stockUnitTaxPriceFl, out stockUnitPriceDisplay);

                row.StockUnitPriceFl = stockUnitPriceFl;
                row.StockUnitTaxPriceFl = stockUnitTaxPriceFl;
                row.StockUnitPriceDisplay = stockUnitPriceDisplay;
                row.StockPriceDiectInput = false;

                // �d�����������Ă���ꍇ�͒P�����r����
                if (row.StockRate != 0)
                {
                    double stockUnitPriceDisplayWk;
                    double stockUnitPriceTaxExcWk;
                    double stockUnitPriceTaxIncWk;
                    double fracProcUnitStcUnPrc = row.FracProcUnitStcUnPrc;
                    int fracProcStckUnPrc = row.FracProcStckUnPrc;
                    this.CalculateStockUnitPriceByRate(row, out stockUnitPriceTaxExcWk, out stockUnitPriceTaxIncWk, out stockUnitPriceDisplayWk, ref fracProcUnitStcUnPrc, ref fracProcStckUnPrc);

                    switch (row.TaxationCode)
                    {
                        case (int)CalculateTax.TaxationCode.TaxInc:
                            {
                                if (row.StockUnitTaxPriceFl != stockUnitPriceTaxIncWk)
                                {
                                    row.StockRate = 0;
                                }
                                break;
                            }
                        case (int)CalculateTax.TaxationCode.TaxExc:
                        case (int)CalculateTax.TaxationCode.TaxNone:
                            {
                                if (row.StockUnitPriceFl != stockUnitPriceTaxExcWk)
                                {
                                    row.StockRate = 0;
                                }
                                break;
                            }
                    }
                }

            }

            // �ύX�O�P���ƈقȂ�ꍇ�͒P���ύX�敪��1���Z�b�g
            row.StockUnitChngDiv = ( row.StockUnitPriceFl != row.BfStockUnitPriceFl ) ? 1 : 0;
            //row.StockPriceDiectInput = false;
        }

        /// <summary>
        /// �w�肵���艿�����Ɏd�����׍s�I�u�W�F�N�g�̒艿����ݒ肵�܂��B�i�I�[�o�[���[�h�j
        /// </summary>
        /// <param name="stockRowNo">�d���s�ԍ�</param>
        /// <param name="priceInputType">�d���P�����̓��[�h</param>
        /// <param name="listPrice">�P��</param>
        /// <param name="stockDetailDataTable">�d�����׃f�[�^�e�[�u���I�u�W�F�N�g</param>
        public void StockDetailRowListPriceSetting(int stockRowNo, PriceInputType priceInputType, double listPrice, StockInputDataSet.StockDetailDataTable stockDetailDataTable)
        {
            StockInputDataSet.StockDetailRow row = stockDetailDataTable.FindBySupplierSlipNoStockRowNo(this._currentSupplierSlipNo, stockRowNo);

            this.StockDetailRowListPriceSetting(row, priceInputType, listPrice);
        }

		/// <summary>
        /// �w�肵���艿�����Ɏd�����׍s�I�u�W�F�N�g�̒艿����ݒ肵�܂��B�i�I�[�o�[���[�h�j
		/// </summary>
        /// <param name="row">�d�����׍s�I�u�W�F�N�g</param>
		/// <param name="priceInputType">�d���P�����̓��[�h</param>
		/// <param name="listPrice">�P��</param>
        private void StockDetailRowListPriceSetting(StockInputDataSet.StockDetailRow row, PriceInputType priceInputType, double listPrice)
        {
            // TODO
            if (row != null)
            {
                if (this._supplierAcs == null) this._supplierAcs = new SupplierAcs();
                int stockTaxFrcProcCd = this._supplierAcs.GetStockFractionProcCd(this._enterpriseCode, this._stockSlip.SupplierCd, SupplierAcs.StockFracProcMoneyDiv.CnsTaxFrcProcCd);		// �d������Œ[�������R�[�h

                double listPriceDisplay;
                double listPriceTaxExcFl;
                double listPriceTaxIncFl;

                this.CalculatePrice(priceInputType, listPrice, row.TaxationCode, this._stockSlip.SuppTtlAmntDspWayCd, this._stockSlip.SuppCTaxLayCd, this._stockSlip.SupplierConsTaxRate, stockTaxFrcProcCd, out listPriceTaxExcFl, out listPriceTaxIncFl, out listPriceDisplay);

                row.ListPriceTaxExcFl = listPriceTaxExcFl;
                row.ListPriceTaxIncFl = listPriceTaxIncFl;
                row.ListPriceDisplay = listPriceDisplay;

                if (( ( row.TaxationCode == (int)CalculateTax.TaxationCode.TaxInc ) && ( row.StdUnPrcStckUnPrc != row.ListPriceTaxIncFl ) ) ||
                    ( ( row.TaxationCode != (int)CalculateTax.TaxationCode.TaxInc ) && ( row.StdUnPrcStckUnPrc != row.ListPriceTaxExcFl ) ))
                {
                    if (row.StockRate != 0)
                    {
                        row.PriceCdStckUnPrc = 0;
                        row.UnPrcCalcCdStckUnPrc = 1;
                        row.StdUnPrcStckUnPrc = ( row.TaxationCode == (int)CalculateTax.TaxationCode.TaxInc ) ? row.ListPriceTaxIncFl : row.ListPriceTaxExcFl;
                    }
                }
            }
        }

		/// <summary>
		/// ���͂����d���P���̒l�����Ɏd�����׍s�I�u�W�F�N�g�̒P������ݒ肵�܂��B�i�I�[�o�[���[�h�j
		/// </summary>
		/// <param name="stockRowNo">�d���s�ԍ�</param>
		/// <param name="stockUnitPrice">�P��</param>
		public void StockDetailRowStockUnitPriceSetting( int stockRowNo, double stockUnitPrice )
		{
			StockInputDataSet.StockDetailRow row = this.GetStockDetailRow(stockRowNo);
            this.ClearStockDetailRateInfo(row, false);
            this.StockDetailRowStockUnitPriceSetting(row, PriceInputType.PriceDisplay, stockUnitPrice);
		}

		/// <summary>
		/// �w�肵���艿�̒l�����Ɏd�����׍s�I�u�W�F�N�g�̒艿����ݒ肵�܂��B�i�I�[�o�[���[�h�j
		/// </summary>
		/// <param name="stockRowNo">�d���s�ԍ�</param>
        /// <param name="stockUnitPriceInputType">�d���P�����̓��[�h</param>
		/// <param name="listPrice">�P��</param>
		public void StockDetailListPriceSetting( int stockRowNo, PriceInputType stockUnitPriceInputType, double listPrice )
		{
			this.StockDetailRowListPriceSetting(stockRowNo, stockUnitPriceInputType, listPrice, this._stockDetailDataTable);
		}

		/// <summary>
		/// �w�肵�����z�����Ɏd�����׍s�I�u�W�F�N�g�̎d�����z��ݒ肵�܂��B�i�I�[�o�[���[�h�j
		/// </summary>
		/// <param name="stockRowNo">�d���s�ԍ�</param>
		/// <param name="stockPrice">�d�����z</param>
		public void StockDetailStockPriceSetting(int stockRowNo, long stockPrice )
		{
            StockInputDataSet.StockDetailRow row = this.GetStockDetailRow(stockRowNo);
			if (row != null)
			{
                row.StockPriceDisplay = stockPrice;
				this.StockDetailRowStockGoodsCdSetting(stockRowNo, this._stockSlip.StockGoodsCd);
			}
		}


		/// <summary>
		/// �w�肵������ł����Ɏd�����׍s�I�u�W�F�N�g�̎d�����z����ݒ肵�܂��B�i�I�[�o�[���[�h�j
		/// </summary>
        /// <param name="stockSlip">�d���f�[�^</param>
		/// <param name="stockRowNo">�d���s�ԍ�</param>
		/// <param name="taxPrice">����ŋ��z</param>
		public void StockDetailTaxPriceSetting( StockSlip stockSlip,int stockRowNo, long taxPrice )
		{
            StockInputDataSet.StockDetailRow row = this.GetStockDetailRow(stockRowNo);
			if (row != null)
			{
                int sign = ( stockSlip.SupplierSlipCd == 20 ) ? -1 : 1;
				// ���z�\�����Ȃ�
				if (this._stockSlip.SuppTtlAmntDspWayCd == 0)
				{
                    row.StockPriceTaxInc = (long)( ((decimal)( row.StockPriceDisplay ) + (decimal)( taxPrice )) * sign );
				}
				// ���z�\��
				else
				{
                    row.StockPriceTaxExc = (long)( ((decimal)row.StockPriceTaxInc - (decimal)( taxPrice )) * sign );
				}
                row.StockPriceConsTax = taxPrice * sign;
				row.StockUnitPriceFl = 0;
				row.StockUnitTaxPriceFl = 0;
			}
		}


        /// <summary>
        /// �w�肵���d�����̒l�����Ɏd�����׍s�I�u�W�F�N�g�̒P������ݒ肵�܂��B�i�I�[�o�[���[�h�j
        /// </summary>
        /// <param name="stockRowNo">�d���s�ԍ�</param>
        /// <param name="stockRate">�d����</param>
        public void StockDetailRowStockUnitPriceSettingbyRate( int stockRowNo, double stockRate )
        {
            StockInputDataSet.StockDetailRow row = this.GetStockDetailRow(stockRowNo);

            this.ClearStockDetailRateInfo(row, false);

			row.StockRate = stockRate;

			double stockUnitPriceTaxExc;
			double stockUnitPriceTaxInc;
			double stockUnitPriceDisplay;
			double fracProcUnitStcUnPrc = 0;
			int fracProcStckUnPrc = 0;

			this.CalculateStockUnitPriceByRate(row, out stockUnitPriceDisplay, out stockUnitPriceTaxInc, out stockUnitPriceTaxExc, ref fracProcUnitStcUnPrc, ref fracProcStckUnPrc);

			row.StockUnitPriceDisplay = stockUnitPriceDisplay;
			row.StockUnitPriceFl = stockUnitPriceTaxExc;
			row.StockUnitTaxPriceFl = stockUnitPriceTaxInc;

			if (( ( row.TaxationCode == (int)CalculateTax.TaxationCode.TaxInc ) && ( row.StdUnPrcStckUnPrc != row.ListPriceTaxIncFl ) ) ||
				( ( row.TaxationCode != (int)CalculateTax.TaxationCode.TaxInc ) && ( row.StdUnPrcStckUnPrc != row.ListPriceTaxExcFl ) ))
			{
				row.PriceCdStckUnPrc = 0;
				row.UnPrcCalcCdStckUnPrc = 1;
				row.StdUnPrcStckUnPrc = ( row.TaxationCode == (int)CalculateTax.TaxationCode.TaxInc ) ? row.ListPriceTaxIncFl : row.ListPriceTaxExcFl;
			}

			row.FracProcUnitStcUnPrc = fracProcUnitStcUnPrc;
			row.FracProcStckUnPrc = fracProcStckUnPrc;
            row.StockPriceDiectInput = false;
        }

		/// <summary>
		/// ����ŗ���ېŋ敪���ύX���ꂽ�ꍇ�Ɏd�����׃f�[�^�e�[�u���̒P���̒������s���܂��B
		/// </summary>
		public void StockDetailRowPriceAdjust()
		{
			this.StockDetailRowPriceAdjust(this._stockDetailDataTable);
		}

		/// <summary>
		/// ����ŗ���ېŋ敪���ύX���ꂽ�ꍇ�Ɏd�����׃f�[�^�s�I�u�W�F�N�g�̒P���̒������s���܂��B�i�I�[�o�[���[�h�j
		/// </summary>
		/// <param name="stockRowNo">�d���s�ԍ�</param>
		public void StockDetailRowPriceAdjust(int stockRowNo)
		{
            StockInputDataSet.StockDetailRow row = this.GetStockDetailRow(stockRowNo);
            this.StockDetailRowPriceAdjust(row);
		}

		/// <summary>
		/// ����ŗ���ېŋ敪���ύX���ꂽ�ꍇ�Ɏd�����׃f�[�^�e�[�u���̒P���̒������s���܂��B�i�I�[�o�[���[�h�j
		/// </summary>
		/// <param name="stockDetailDataTable">�d�����׃f�[�^�e�[�u���I�u�W�F�N�g</param>
		private void StockDetailRowPriceAdjust(StockInputDataSet.StockDetailDataTable stockDetailDataTable)
		{
			foreach (StockInputDataSet.StockDetailRow row in stockDetailDataTable.Rows)
			{
				// �d�����׃f�[�^�Z�b�e�B���O�����i�P�������j
                this.StockDetailRowPriceAdjust(row);
			}
		}

		/// <summary>
		/// ����ŗ���ېŋ敪���ύX���ꂽ�ꍇ�Ɏd�����׃f�[�^�s�I�u�W�F�N�g�̋��z�𒲐����܂��B�i�I�[�o�[���[�h�j
		/// </summary>
        /// <param name="row">�d�����׃f�[�^�e�[�u���s�I�u�W�F�N�g</param>
        public void StockDetailRowPriceAdjust(StockInputDataSet.StockDetailRow row)
		{
            if (row != null)
            {
                //// �]�ŕ����F��ېł������͉ېŋ敪�F��ې�
                //if ( this._stockSlip.SuppCTaxLayCd == 9 )
                //{
                //    // �d�����׃f�[�^�P���ݒ菈��
                //    this.StockDetailRowStockUnitPriceSetting(row, PriceInputType.PriceTaxExc, row.StockUnitPriceFl);

                //    // �d�����׃f�[�^�艿�ݒ菈��
                //    this.StockDetailRowListPriceSetting(row, PriceInputType.PriceTaxExc, row.ListPriceTaxExcFl);
                //}
                // �ېŋ敪�F�u�O�Łv
                if (row.TaxationCode == (int)CalculateTax.TaxationCode.TaxExc)
                {
                    // �d�����׃f�[�^�艿�ݒ菈��
                    this.StockDetailRowListPriceSetting(row, PriceInputType.PriceTaxExc, row.ListPriceTaxExcFl);

                    if (row.StockUnitPriceFl != 0 || row.StockUnitTaxPriceFl != 0)
                    {
                        // �d�����׃f�[�^�P���ݒ菈��
                        this.StockDetailRowStockUnitPriceSetting(row, PriceInputType.PriceTaxExc, row.StockUnitPriceFl);
                    }
                }
                // �ېŋ敪�F�u���Łv
                else if (row.TaxationCode == (int)CalculateTax.TaxationCode.TaxInc)
                {
                    // �d�����׃f�[�^�艿�ݒ菈��
                    this.StockDetailRowListPriceSetting(row, PriceInputType.PriceTaxInc, row.ListPriceTaxIncFl);

                    if (row.StockUnitPriceFl != 0 || row.StockUnitTaxPriceFl != 0)
                    {
                        // �d�����׃f�[�^�P���ݒ菈��
                        this.StockDetailRowStockUnitPriceSetting(row, PriceInputType.PriceTaxInc, row.StockUnitTaxPriceFl);
                    }
                }
                // �ېŋ敪�F�u��ېŁv
                else
                {
                    // �d���摍�z�\�����@�敪���u���z�\�����Ȃ��v�̏ꍇ
                    if (this._stockSlip.SuppTtlAmntDspWayCd == 0)
                    {
                        // �d�����׃f�[�^�艿�ݒ菈��
                        this.StockDetailRowListPriceSetting(row, PriceInputType.PriceTaxExc, row.ListPriceTaxExcFl);

                        if (row.StockUnitPriceFl != 0 || row.StockUnitTaxPriceFl != 0)
                        {
                            // �d�����׃f�[�^�P���ݒ菈��
                            this.StockDetailRowStockUnitPriceSetting(row, PriceInputType.PriceTaxExc, row.StockUnitPriceFl);
                        }
                    }
                    // �d���摍�z�\�����@�敪���u���z�\������v�̏ꍇ
                    else if (this._stockSlip.SuppTtlAmntDspWayCd == 1)
                    {
                        // �d�����׃f�[�^�艿�ݒ菈��
                        this.StockDetailRowListPriceSetting(row, PriceInputType.PriceTaxInc, row.ListPriceTaxIncFl);

                        if (row.StockUnitPriceFl != 0 || row.StockUnitTaxPriceFl != 0)
                        {
                            // �d�����׃f�[�^�P���ݒ菈��
                            this.StockDetailRowStockUnitPriceSetting(row, PriceInputType.PriceTaxInc, row.StockUnitTaxPriceFl);
                        }

                    }
                }
            }
		}

		/// <summary>
		/// �w�肵���d�����i�敪�����ɁA�d�����׃f�[�^�s�I�u�W�F�N�g�Ɋ֘A���鍀�ڂ�ݒ肵�܂��B
		/// </summary>
		/// <param name="stockRowNo">�d���s�ԍ�</param>
		/// <param name="stockGoodsCd">�d�����i�敪</param>
		public void StockDetailRowStockGoodsCdSetting(int stockRowNo, int stockGoodsCd)
		{
            StockInputDataSet.StockDetailRow row = this.GetStockDetailRow(stockRowNo);
            if (this._supplierAcs == null) this._supplierAcs = new SupplierAcs();
			int stockTaxFrcProcCd = this._supplierAcs.GetStockFractionProcCd(this._enterpriseCode, this._stockSlip.SupplierCd, SupplierAcs.StockFracProcMoneyDiv.CnsTaxFrcProcCd);		// �d������Œ[�������R�[�h
			int taxFracProcCd = 0;
			double taxFracProcUnit = 0;
            this._stockSlipInputInitDataAcs.GetStockFractionProcInfo(StockSlipInputInitDataAcs.ctFracProcMoneyDiv_Tax, stockTaxFrcProcCd, 0, out taxFracProcUnit, out taxFracProcCd);

			if (row != null)
			{
				switch (stockGoodsCd)
				{
					#region �����i
					// �d�����i�敪 = 0:���i
					case 0:
						{
							if (( row.StockSlipCdDtl == 2 ) && ( row.StockCountDisplay == 0 ))    // �s�l����
							{
								//row.StockCountDisplay = 1;
								//row.StockCount = 1;
								// ���z�\�����Ȃ�
								if (this._stockSlip.SuppTtlAmntDspWayCd == 0)
								{
									row.StockPriceTaxExc = row.StockPriceDisplay;
									row.StockPriceTaxInc = row.StockPriceDisplay + CalculateTax.GetTaxFromPriceExc(this._stockSlip.SupplierConsTaxRate, taxFracProcUnit, taxFracProcCd, row.StockPriceDisplay);
								}
								// ���z�\��
								else
								{
									row.StockPriceTaxExc = row.StockPriceDisplay - CalculateTax.GetTaxFromPriceInc(this._stockSlip.SupplierConsTaxRate, taxFracProcUnit, taxFracProcCd, row.StockPriceDisplay);
									row.StockPriceTaxInc = row.StockPriceDisplay;
								}
								row.StockPriceConsTax = (long)( (decimal)row.StockPriceTaxInc - (decimal)row.StockPriceTaxExc );
								//row.StockUnitPriceFl = row.StockPriceTaxExc;
								//row.StockUnitTaxPriceFl = row.StockPriceTaxInc;
								row.StockGoodsCd = stockGoodsCd;
								row.CanTaxDivChange = false;
								row.EditStatus = ctEDITSTATUS_RowDiscount;
							}
							// ��{����
							else
							{
								int sign = ( this._stockSlip.SupplierSlipCd == 20 ) ? -1 : 1;
								long stockPriceRealValue = row.StockPriceDisplay * sign;

								// ���z�\�����Ȃ�
								if (this._stockSlip.SuppTtlAmntDspWayCd == 0)
								{
									switch (row.TaxationCode)
									{
										case (int)CalculateTax.TaxationCode.TaxInc:
											row.StockPriceTaxExc = stockPriceRealValue - CalculateTax.GetTaxFromPriceInc(this._stockSlip.SupplierConsTaxRate, taxFracProcUnit, taxFracProcCd, stockPriceRealValue);
											row.StockPriceTaxInc = stockPriceRealValue;
											break;
										case (int)CalculateTax.TaxationCode.TaxExc:
											row.StockPriceTaxExc = stockPriceRealValue;
											row.StockPriceTaxInc = stockPriceRealValue + CalculateTax.GetTaxFromPriceExc(this._stockSlip.SupplierConsTaxRate, taxFracProcUnit, taxFracProcCd, stockPriceRealValue);
											break;
										case (int)CalculateTax.TaxationCode.TaxNone:
											row.StockPriceTaxExc = stockPriceRealValue;
											row.StockPriceTaxInc = stockPriceRealValue;
											break;
									}
								}
								// ���z�\��
								else
								{
									row.StockPriceTaxExc = stockPriceRealValue - CalculateTax.GetTaxFromPriceInc(this._stockSlip.SupplierConsTaxRate, taxFracProcUnit, taxFracProcCd, stockPriceRealValue);
									row.StockPriceTaxInc = stockPriceRealValue;
								}
								row.StockPriceConsTax = (long)( (decimal)row.StockPriceTaxInc - (decimal)row.StockPriceTaxExc );
								row.StockUnitPriceDisplay = 0;
                                this.ClearStockDetailRateInfo(row, false);
								row.StockUnitPriceFl = 0;
								row.StockUnitTaxPriceFl = 0;
								row.StockRate = 0;
                                // �ύX�O�P���ƈقȂ�ꍇ�͒P���ύX�敪��1���Z�b�g
                                row.StockUnitChngDiv = ( row.StockUnitPriceFl != row.BfStockUnitPriceFl ) ? 1 : 0;
                                row.StockPriceDiectInput = true;
                            }
							break;
						}
					#endregion

					#region �����i�O
					// �d�����i�敪 = 1:���i�O
					case 1:								
						{
                            if (string.IsNullOrEmpty(row.GoodsName))
                            {
                                this.ClearStockDetailRow(row.StockRowNo);
                            }
                            else
                            {
                                if (this._stockSlip.SuppTtlAmntDspWayCd == 0)
                                {
                                    row.TaxationCode = (int)CalculateTax.TaxationCode.TaxExc;
                                }
                                else
                                {
                                    row.TaxationCode = (int)CalculateTax.TaxationCode.TaxInc;
                                }

                                row.StockGoodsCd = stockGoodsCd;
                                row.EditStatus = ctEDITSTATUS_AllOK;
                                row.CanTaxDivChange = true;
                            }

							break;
						}
					#endregion

					#region ������Œ����A���|�p����Œ���
					case 2:	// �d�����i�敪 = 2:����Œ���
					case 4:	// �d�����i�敪 = 4:���|�p����Œ���
						{
							if (row.StockPriceDisplay == 0)
							{
								this.ClearStockDetailRow(row.StockRowNo);
							}
							else
							{
								row.GoodsName = "����Œ���";
								row.TaxationCode = (int)CalculateTax.TaxationCode.TaxNone;
								if (this._stockSlip.SupplierSlipCd == 20)
								{
									row.StockCount = -1;
								}
								else
								{
									row.StockCount = 1;
								}
								row.StockCountDisplay = 1;
								row.StockGoodsCd = stockGoodsCd;
								row.StockUnitTaxPriceFl = 0;
								row.StockPriceTaxInc = 0;
								//salesTempRow.TaxAdjust = salesTempRow.StockPriceDisplay;
								row.StockPriceConsTax = row.StockPriceDisplay;
								row.CanTaxDivChange = false;
								row.EditStatus = ctEDITSTATUS_AllOK;
							}
							break;
						}
					#endregion

					#region ���c�������A���|�p�c������
					case 3:								// �d�����i�敪 = 3:�c������
					case 5:								// �d�����i�敪 = 5:���|�p�c������
						{
							if (row.StockPriceDisplay == 0)
							{
								this.ClearStockDetailRow(row.StockRowNo);
							}
							else
							{
								row.GoodsName = "�c������";
								if (this._stockSlip.SupplierSlipCd == 20)
								{
									row.StockCount = -1;
								}
								else
								{
									row.StockCount = 1;
								}
								row.StockCountDisplay = 1;
								row.StockUnitPriceFl = 0;
								row.StockUnitTaxPriceFl = 0;
								row.StockPriceTaxExc = 0;
								row.StockPriceTaxInc = row.StockPriceDisplay;
								row.StockGoodsCd = stockGoodsCd;
								//salesTempRow.BalanceAdjust = salesTempRow.StockPriceDisplay;
								row.TaxationCode = (int)CalculateTax.TaxationCode.TaxExc;
								row.CanTaxDivChange = false;
								row.EditStatus = ctEDITSTATUS_AllOK;
							}
							break;
						}
					#endregion

					#region �����v����
					// �d�����i�敪 = 6:���v����
					case 6:                                     
						if (row.StockPriceDisplay == 0)
						{
							this.ClearStockDetailRow(row.StockRowNo);
						}
						else
						{
                            int sign = ( this._stockSlip.SupplierSlipCd == 20 ) ? -1 : 1;

							row.GoodsName = "���v����";

							// ����(�ʏ��1,�ԕi����-1)
                            row.StockCountDisplay = sign;
							row.StockCount = row.StockCountDisplay;

                            long stockPriceDisplayRealValue = row.StockPriceDisplay * sign;

                            // ��ېł̎d����͔�ېň���
                            if (this._stockSlip.SuppCTaxLayCd == 9)
                            {
                                row.TaxationCode = (int)CalculateTax.TaxationCode.TaxNone;
                                row.StockPriceTaxExc = stockPriceDisplayRealValue;
                                row.StockPriceTaxInc = stockPriceDisplayRealValue;
                                row.StockPriceDisplay = row.StockPriceTaxExc;
                            }
                            // ���z�\�����Ȃ��ꍇ�A�O�ň���
							else if (this._stockSlip.SuppTtlAmntDspWayCd == 0)
							{
								row.TaxationCode = (int)CalculateTax.TaxationCode.TaxExc;
                                row.StockPriceTaxExc = stockPriceDisplayRealValue;
                                row.StockPriceTaxInc = stockPriceDisplayRealValue + CalculateTax.GetTaxFromPriceExc(this._stockSlip.SupplierConsTaxRate, taxFracProcUnit, taxFracProcCd, stockPriceDisplayRealValue);
                                row.StockPriceDisplay = row.StockPriceTaxExc;
							}
							// ���z�\������ꍇ�A���ň���
							else
							{
								row.TaxationCode = (int)CalculateTax.TaxationCode.TaxInc;
                                row.StockPriceTaxExc = stockPriceDisplayRealValue - CalculateTax.GetTaxFromPriceInc(this._stockSlip.SupplierConsTaxRate, taxFracProcUnit, taxFracProcCd, stockPriceDisplayRealValue);
                                row.StockPriceTaxInc = stockPriceDisplayRealValue;
                                row.StockPriceDisplay = row.StockPriceTaxInc;
                            }
							row.StockPriceConsTax = (long)( (decimal)row.StockPriceTaxInc - (decimal)row.StockPriceTaxExc );
                            row.StockPriceDisplay = row.StockPriceDisplay * sign;

							row.StockUnitPriceFl = 0;
							row.StockUnitTaxPriceFl = 0;
							row.StockUnitPriceDisplay = 0;
							row.StockGoodsCd = stockGoodsCd;
                            // �ύX�O�P���ƈقȂ�ꍇ�͒P���ύX�敪��1���Z�b�g
                            row.StockUnitChngDiv = ( row.StockUnitPriceFl != row.BfStockUnitPriceFl ) ? 1 : 0;
                            row.CanTaxDivChange = false;
							row.EditStatus = ctEDITSTATUS_AllOK;
						}
						break;
					#endregion
				}
			}
		}

		/// <summary>
		/// �d�����׍s�I�u�W�F�N�g�̔����c���̒l��ݒ肵�܂��B
		/// </summary>
		/// <param name="stockRowNo">�d���s�ԍ�</param>
		public void StockDetailRowOrderRemainCntSetting(int stockRowNo)
		{
            StockInputDataSet.StockDetailRow row = this.GetStockDetailRow(stockRowNo);
			if (row == null) return;

			row.OrderRemainCnt = ( this._stockSlip.SupplierFormal == 0 ) ? 0 : row.StockCountDisplay;
		}

		/// <summary>
		/// �d�����׍s�I�u�W�F�N�g�̐��ʂ�ݒ肵�܂��B
		/// </summary>
		/// <param name="stockRowNo">�d���s�ԍ�</param>
		public void StockDetailRowStockCountSetting( int stockRowNo )
		{
            StockInputDataSet.StockDetailRow row = this.GetStockDetailRow(stockRowNo);
			if (row == null) return;

			double stockCountRealValue = row.StockCountDisplay;
			if (this._stockSlip.SupplierSlipCd == 20)
			{
				stockCountRealValue *= -1;
			}

			double adjustCnt;

			// �V�K�o�^�s�̏ꍇ
			if (row.StockSlipDtlNum == 0)
			{
				adjustCnt = stockCountRealValue;
				row.StockCount = adjustCnt;					// �d��������ʎd����
				row.OrderAdjustCnt = 0;						// ��������0
				row.OrderCnt = adjustCnt;					// ����������ʎd����
				row.OrderRemainCnt = adjustCnt;				// �����c����ʎd����
			}
			// �C���s�̏ꍇ
			else
			{
				//adjustCnt = row.StockCountDisplay - row.StockCount;			// ���͑O�Ƃ̍������v�Z����
				adjustCnt = stockCountRealValue - row.StockCount;			// ���͑O�Ƃ̍������v�Z����
				row.StockCount = stockCountRealValue;						// �d��������ʎd����
                row.OrderAdjustCnt = row.OrderAdjustCnt + adjustCnt;		// ��������������+����
				row.OrderRemainCnt = row.OrderRemainCnt + adjustCnt;		// �����c�������c+����
			}

            // �݌ɕi�̏ꍇ�͐��ʒ���
			if (!( string.IsNullOrEmpty(row.WarehouseCode.Trim()) ))
			{
                this.StockDetailStockInfoAdjust(row.WarehouseCode.Trim(), row.GoodsNo.Trim(), row.GoodsMakerCd);
			}
		}

		/// <summary>
		/// �d���`���A�v�㌳��񂩂�A�\�����Ă��錻�݌ɐ����A�݌Ƀ}�X�^��̌��݌ɐ��ƕς�邩�`�F�b�N���܂��B
		/// </summary>
		/// <param name="stockDetailRow"></param>
		/// <returns></returns>
		public bool SupplierStockCountChangeCheck( StockInputDataSet.StockDetailRow stockDetailRow )
		{
			bool ret = true;

            // �l�����f�[�^�͔��f�����Ȃ�
            if (stockDetailRow.StockSlipCdDtl == 2)
            {
                ret = false;
            }
			// �v�㌳�̖��ׂ������ꍇ�͒P���ɐ��ʂ𔽉f������i�V�K�d��(�ԕi�܂�)�A�V�K����(�ԕi�܂�))
			else if ( stockDetailRow.StockSlipDtlNumSrc == 0 )
			{
				ret = true;
			}
			else
			{
				StockInputDataSet.AddUpSrcDetailRow addUpSrcDetailRow = this.GetAddUpSrcDataRow(stockDetailRow);

				if (addUpSrcDetailRow != null)
				{
					// �d���`�����v�㌳���ׂƓ����ꍇ(���`�L��̕ԕi�A�ԓ`)
					if (this._stockSlip.SupplierFormal == addUpSrcDetailRow.SupplierFormal)
					{
						// ���׌v��ɑ΂���ԓ`�A�ԕi�́A�݌ɐ��͍݌ɂ���擾�����l�̂܂�
						if (( addUpSrcDetailRow.StockSlipDtlNumSrc != 0 ) && ( addUpSrcDetailRow.SupplierFormalSrc == 1 ))
						{
							ret = false;
						}
					}
					// �v��A�����̏ꍇ
					else
					{
						// ���׌v��̏ꍇ�A�݌ɐ��͍݌ɂ���擾�����l�̂܂�
						if (addUpSrcDetailRow.SupplierFormal == 1)
						{
							ret = false;
						}
					}
				}
			}

			return ret;
		}

		/// <summary>
		/// �d�����׍s�I�u�W�F�N�g�̌v��\���ʂ̒l��ݒ肵�܂��B
		/// </summary>
		public void StockDetailRowAddUpEnableCountSetting()
		{
			if (this._stockSlip.DebitNoteDiv != 0)
			{
				return;
			}
            int sign = ( this._stockSlip.SupplierSlipCd == 20 ) ? -1 : 1;
			foreach (StockInputDataSet.StockDetailRow row in this._stockDetailDataTable.Rows)
			{
				row.StockCountMin = (double)((decimal)row.StockCount - (decimal)row.OrderRemainCnt);	// �v��ςݐ��� = ���ׂ̎d������ - �����c

				if (row.StockSlipDtlNumSrc == 0) continue;

				StockInputDataSet.AddUpSrcDetailRow addUpSrcDetailRow = this.GetAddUpSrcDataRow(row);

				if (addUpSrcDetailRow != null)
				{
                    row.StockCountMax = (double)( (decimal)( row.StockCount * sign ) + (decimal)addUpSrcDetailRow.OrderRemainCnt ) * sign; // �v��\���� = ���ׂ̎d����(��Βl) + �v�㌳�̔����c
				}
				else
				{
					row.StockCountMax = row.StockCount;										// �v��\���� = ���ׂ̎d����(��Βl)
				}
			}
		}

		/// <summary>
		/// �w�肵���d�����z�\�����@�敪�����ɁA�d�����׃f�[�^�I�u�W�F�N�g�̉ېŋ敪��ݒ肵�܂��B
		/// </summary>
        /// <param name="suppCTaxLayCd">�d�������œ]�ŕ����R�[�h</param>
		/// <param name="suppTtlAmntDspWayCd">�d���摍�z�\�����@�敪</param>
        public void StockDetailRowTaxationCodeSetting(int suppCTaxLayCd, int suppTtlAmntDspWayCd)
        {
            for (int i = 0; i < this._stockDetailDataTable.Rows.Count; i++)
            {
                StockInputDataSet.StockDetailRow row = (StockInputDataSet.StockDetailRow)this._stockDetailDataTable.Rows[i];

                
                // �s�l�������̉ېŋ敪��␳
                //if (( row.StockSlipCdDtl == 2 ) && ( row.StockCountDisplay == 0 ))
                //if (( row.StockSlipCdDtl == 2 ) && ( row.StockCountDisplay == 0 ))
                if (( row.StockCountDisplay == 0 ) && ( row.StockPriceDisplay != 0 ))
                {
                    // ��ېł̎d����͒l��������ېłɂ���
                    if (suppCTaxLayCd == 9)
                    {
                        row.TaxationCode = (int)CalculateTax.TaxationCode.TaxNone;
                    }
                    else
                    {
                        // ���z�\�����Ȃ��ꍇ�͊O�ŁA���z�\������ꍇ�͓���
                        row.TaxationCode = ( suppTtlAmntDspWayCd == 0 ) ? (int)CalculateTax.TaxationCode.TaxExc : (int)CalculateTax.TaxationCode.TaxInc;
                    }
                }

                row.TaxDiv = row.TaxationCode;
                this.StockDetailRowTaxationCodeSetting(suppCTaxLayCd, suppTtlAmntDspWayCd, row);

                // �s�l�����̏ꍇ�͒P���[��
                if (( row.StockSlipCdDtl == 2 ) && ( row.StockCountDisplay == 0 ))
                {
                    row.StockUnitPriceDisplay = 0;
                }
            }
        }

        /// <summary>
        /// �w�肵���]�ŕ����A�d�����z�\�����@�敪�����ɁA�d�����׃f�[�^�I�u�W�F�N�g�̉ېŋ敪��ݒ肵�܂��B
        /// </summary>
        /// <param name="suppCTaxLayCd">�d�������œ]�ŕ����R�[�h</param>
        /// <param name="suppTtlAmntDspWayCd">���z�\���敪</param>
        /// <param name="row">�d�����׍s�I�u�W�F�N�g</param>
        private void StockDetailRowTaxationCodeSetting(int suppCTaxLayCd, int suppTtlAmntDspWayCd, StockInputDataSet.StockDetailRow row)
        {
            if (suppCTaxLayCd == 9)
            {
                row.StockUnitPriceDisplay = row.StockUnitPriceFl;
                row.ListPriceDisplay = row.ListPriceTaxExcFl;
                row.StockPriceDisplay = row.StockPriceTaxExc;
            }
            else if (suppTtlAmntDspWayCd == 0)
            {
                switch (row.TaxationCode)
                {
                    case (int)CalculateTax.TaxationCode.TaxExc:
                    case (int)CalculateTax.TaxationCode.TaxNone:
                        {
                            row.StockUnitPriceDisplay = row.StockUnitPriceFl;
                            row.ListPriceDisplay = row.ListPriceTaxExcFl;
                            row.StockPriceDisplay = row.StockPriceTaxExc;
                            break;
                        }
                    case (int)CalculateTax.TaxationCode.TaxInc:
                        {
                            row.StockUnitPriceDisplay = row.StockUnitTaxPriceFl;
                            row.ListPriceDisplay = row.ListPriceTaxIncFl;
                            row.StockPriceDisplay = row.StockPriceTaxInc;
                            break;
                        }
                }
            }
            else
            {
                row.StockUnitPriceDisplay = row.StockUnitTaxPriceFl;
                row.ListPriceDisplay = row.ListPriceTaxIncFl;
                row.StockPriceDisplay = row.StockPriceTaxInc;
            }
        }

		/// <summary>
		/// �w�肵������ŗ������Ɏd�����׃f�[�^�s�I�u�W�F�N�g�̋��z�����X�V���܂��B
		/// </summary>
		/// <param name="taxRate">����ŗ�</param>
        /// <param name="suppCTaxLayCd">�d�������œ]�ŕ����R�[�h</param>
        public void StockDetailRowTaxRateChanged(double taxRate, int suppCTaxLayCd)
		{
			// �d�����z�[�������R�[�h
            if (this._supplierAcs == null) this._supplierAcs = new SupplierAcs();
			int stockMoneyFrcProcCd = this._supplierAcs.GetStockFractionProcCd(this._enterpriseCode, this._stockSlip.SupplierCd, SupplierAcs.StockFracProcMoneyDiv.MoneyFrcProcCd); 
			// ����Œ[�������敪
			int taxFracProcCode = this._supplierAcs.GetStockFractionProcCd(this._enterpriseCode, this._stockSlip.SupplierCd, SupplierAcs.StockFracProcMoneyDiv.CnsTaxFrcProcCd); 

			for (int i = 0; i < this._stockDetailDataTable.Rows.Count; i++)
			{
				StockInputDataSet.StockDetailRow row = (StockInputDataSet.StockDetailRow)this._stockDetailDataTable.Rows[i];

                // ��ېŎ��͐ō����z���Ŕ������z
                if (suppCTaxLayCd == 9)
                {
                    row.StockPriceTaxInc = row.StockPriceTaxExc;
                    row.StockUnitTaxPriceFl = row.StockUnitPriceFl;
                }
				else if (row.StockGoodsCd == 6)
				{
					this.CalculateStockPrice(row);
				}
				else
				{
                    // �ېŋ敪���u�O�Łv�̏ꍇ
                    if (row.TaxationCode == (int)CalculateTax.TaxationCode.TaxExc)
                    {
                        long stockPriceTaxInc;
                        long stockPriceTaxExc;
                        long stockPriceConsTax;
                        double stockUnitPrice = row.StockUnitPriceFl;

                        if (this.CalculateStockPrice(
                            row.StockCountDisplay,
                            stockUnitPrice,
                            row.TaxationCode,
                            taxRate,
                            stockMoneyFrcProcCd,
                            taxFracProcCode,
                            out stockPriceTaxInc,
                            out stockPriceTaxExc,
                            out stockPriceConsTax))
                        {
                            if (row.StockGoodsCd <= 1)
                            {
                                row.StockPriceTaxInc = stockPriceTaxInc;
                            }
                        }
                    }
                    // �ېŋ敪���u���Łv�̏ꍇ
                    else if (row.TaxationCode == (int)CalculateTax.TaxationCode.TaxInc)
                    {
                        long stockPriceTaxInc;
                        long stockPriceTaxExc;
                        long stockPriceConsTax;
                        double stockUnitPrice = row.StockUnitPriceFl;

                        if (this.CalculateStockPrice(
                            row.StockCountDisplay,
                            stockUnitPrice,
                            row.TaxationCode,
                            taxRate,
                            stockMoneyFrcProcCd,
                            taxFracProcCode,
                            out stockPriceTaxInc,
                            out stockPriceTaxExc,
                            out stockPriceConsTax))
                        {
                            if (row.StockGoodsCd <= 1)
                            {
                                row.StockPriceTaxExc = stockPriceTaxExc;
                            }
                        }
                    }
				}
			}
		}

		/// <summary>
		/// �d�����׃f�[�^�e�[�u���̎d���s�ԍ����������i�č̔ԁj���܂��B
		/// </summary>
		public void InitializeStockDetailStockRowNoColumn()
		{
			this._stockDetailDataTable.BeginLoadData();
			for (int i = 0; i < this._stockDetailDataTable.Rows.Count; i++)
			{
                int oldStockRowNo = this._stockDetailDataTable[i].StockRowNo;
				this._stockDetailDataTable[i].StockRowNo = i + 1;
            }
			this._stockDetailDataTable.EndLoadData();
        }

		/// <summary>
		/// �d�����׃f�[�^�e�[�u���̍s�X�e�[�^�X��̒l�����������܂��B
		/// </summary>
		public void InitializeStockDetailRowStatusColumn()
		{
			StockInputDataSet.StockDetailRow[] rows = (StockInputDataSet.StockDetailRow[])this._stockDetailDataTable.Select(this._stockDetailDataTable.RowStatusColumn.ColumnName + " <> " + ctROWSTATUS_NORMAL.ToString());

			this._stockDetailDataTable.BeginLoadData();
			foreach (StockInputDataSet.StockDetailRow row in rows)
			{
				row.RowStatus = 0;
			}
			this._stockDetailDataTable.EndLoadData();
		}

		/// <summary>
		/// �w�肵���d���s�ԍ��̃��X�g�����ɁA�Y������d�����׍s�I�u�W�F�N�g�̍s�X�e�[�^�X�ɒl��ݒ肵�܂��B
		/// </summary>
		/// <param name="stockRowNoList">�d�����׍s�ԍ����X�g</param>
		/// <param name="rowStatus">RowStatus�l</param>
		public void SetStockDetailRowStatusColumn(List<int> stockRowNoList, int rowStatus)
		{
			this._stockDetailDataTable.BeginLoadData();
			foreach (int stockRowNo in stockRowNoList)
			{
                StockInputDataSet.StockDetailRow row = this.GetStockDetailRow(stockRowNo);

                if (( string.IsNullOrEmpty(row.GoodsName) ) && ( string.IsNullOrEmpty(row.GoodsNo) )) continue;

				row.RowStatus = rowStatus;
			}
			this._stockDetailDataTable.EndLoadData();
		}

		/// <summary>
		/// �d�����׃f�[�^�e�[�u���ɃR�s�[�s�����݂��邩�ǂ������`�F�b�N���܂��B
		/// </summary>
		/// <returns>true:�R�s�[�f�[�^�����݂��� false:���݂��Ȃ�</returns>
		public bool ExistCopyStockDetailRow()
		{
			object value = this._stockDetailDataTable.Compute("COUNT(" + this._stockDetailDataTable.RowStatusColumn.ColumnName + ")", this._stockDetailDataTable.RowStatusColumn.ColumnName + " <> " + ctROWSTATUS_NORMAL.ToString());
			if (value is System.DBNull) return false;

			int count = (int)value;

			if (count > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// �d�����׃f�[�^�e�[�u���ɃR�s�[�s�̎d���s�ԍ����X�g���擾���܂��B
		/// </summary>
		/// <returns>�d���s�ԍ����X�g</returns>
		public List<int> GetCopyStockDetailRowNo()
		{
			StockInputDataSet.StockDetailRow[] rows = (StockInputDataSet.StockDetailRow[])this._stockDetailDataTable.Select(this._stockDetailDataTable.RowStatusColumn.ColumnName + " <> " + ctROWSTATUS_NORMAL.ToString());

			if ((rows != null) && (rows.Length > 0))
			{
				List<int> stockRowNoList = new List<int>();
				foreach (StockInputDataSet.StockDetailRow row in rows)
				{
					stockRowNoList.Add(row.StockRowNo);
				}

				return stockRowNoList;
			}
			else
			{
				return null;
			}
		}

		/// <summary>
		/// �w�肵���C���f�b�N�X�̎d�����׃f�[�^�s�ɑ΂��čs�\��t�����s���ہA�m�F���K�v���ǂ������`�F�b�N���܂��B
		/// </summary>
		/// <param name="copyStockRowNoList">�R�s�[�s�d���s�ԍ����X�g</param>
		/// <param name="pasteIndex">�\��t���sIndex</param>
		/// <returns>0:�`�F�b�N�s�v 1:�`�F�b�N�K�v 2:�\��t���s��</returns>
		public int CheckPasteStockDetailRow(List<int> copyStockRowNoList, int pasteIndex)
		{
			int check = 0;
			int pasteStockRowNo = this._stockDetailDataTable[pasteIndex].StockRowNo;

			for (int i = 0; i < copyStockRowNoList.Count; i++)
			{
				StockInputDataSet.StockDetailRow sourceRow = this._stockDetailDataTable.FindBySupplierSlipNoStockRowNo(this._stockSlip.SupplierSlipNo, copyStockRowNoList[i]);

				if (sourceRow == null)
				{
					continue;
				}

				StockInputDataSet.StockDetailRow row = this._stockDetailDataTable.FindBySupplierSlipNoStockRowNo(this._stockSlip.SupplierSlipNo, pasteStockRowNo + i);

				if (row != null)
				{
					if (( row.EditStatus != ctEDITSTATUS_AllOK ) && ( row.EditStatus != ctEDITSTATUS_RowDiscount ) && ( row.EditStatus != ctEDITSTATUS_GoodsDiscount ))
					{
						check = 2;
						break;
					}
                    else if (this.ExistStockDetailInput(row))
                    {
                        check = 1;
                    }
				}
			}
			
			return check;
		}

		/// <summary>
		/// �d�����׃f�[�^�s�I�u�W�F�N�g�̓\��t�����s���܂��B
		/// </summary>
		/// <param name="copyStockRowNoList">�R�s�[�s�d���s�ԍ����X�g</param>
		/// <param name="pasteIndex">�\��t���sIndex</param>
		public void PasteStockDetailRow(List<int> copyStockRowNoList, int pasteIndex)
		{
			int pasteTargetStockRowNo = this._stockDetailDataTable[pasteIndex].StockRowNo;

			this._stockDetailDataTable.BeginLoadData();
			List<int> cutStockRowNoList = new List<int>();
			List<int> pasteStockRowNoList = new List<int>();
			List<int> deleteStockRowNoList = new List<int>();
			List<StockInputDataSet.StockDetailRow> copyStockRowList = new List<StockInputDataSet.StockDetailRow>();

			foreach (int stockRowNo in copyStockRowNoList)
			{
                StockInputDataSet.StockDetailRow row = this.GetStockDetailRow(stockRowNo);

				if (row != null)
				{
					copyStockRowList.Add(this.CloneStockDetailRow(row));

					if (row.RowStatus == ctROWSTATUS_CUT)
					{
						cutStockRowNoList.Add(row.StockRowNo);
                    }
				}
			}

			if (cutStockRowNoList.Count > 0)
			{
				// �d�����׍s�N���A����
				for (int i = 0; i < cutStockRowNoList.Count; i++)
				{
                    this.ClearStockDetailRow(this.GetStockDetailRow(cutStockRowNoList[i]));
				}
			}

			for (int i = 0; i < copyStockRowList.Count; i++)
			{
				StockInputDataSet.StockDetailRow sourceRow = copyStockRowList[i];
				StockInputDataSet.StockDetailRow targetRow = null;

				//this.AddStockDetailRow();
				if (( pasteIndex + i ) < this._stockDetailDataTable.Count)
				{


					targetRow = this._stockDetailDataTable[pasteIndex + i];

					this.CopyStockDetailRow(sourceRow, targetRow);

					// �R�s�[���y�[�X�g�̏ꍇ�A�v����A�������͖��׏����N���A����
					if (!cutStockRowNoList.Contains(copyStockRowList[i].StockRowNo))
					{
						targetRow.CommonSeqNo = 0;			// ���ʒʔ�
						targetRow.StockSlipDtlNum = 0;		// ���גʔ�
						targetRow.SupplierFormalSrc = 0;	// �d���`���i���j
						targetRow.StockSlipDtlNumSrc = 0;	// �d�����גʔԁi���j
						targetRow.AcptAnOdrStatusSync = 0;	// �󒍃X�e�[�^�X�i�����j
						targetRow.SalesSlipDtlNumSync = 0;	// ���㖾�גʔԁi�����j
						//targetRow.StockSlipCdDtl = 0;		// �d���`�[�敪�i���ׁj
						targetRow.StockCountDefault = 0;
						targetRow.StockCountMax = 0;
						targetRow.StockCountMin = 0;
						targetRow.DtlRelationGuid = Guid.Empty;
						targetRow.EditStatus = ( targetRow.StockSlipCdDtl == 2 ) ? ctEDITSTATUS_RowDiscount : ctEDITSTATUS_AllOK;

						this.MemoInfoAdjust(ref targetRow);
					}

					pasteStockRowNoList.Add(targetRow.StockRowNo);
				}
			}
			this._stockDetailDataTable.EndLoadData();

			// �s�v�ȍs���폜����
			this.DeleteStockDetailRow(deleteStockRowNoList, true);

            //// �ŏI�s�ɏ��i���̂��ݒ肳��Ă���ꍇ�͂P�s�ǉ�
            //if (this.ExistStockDetailInput(this._stockDetailDataTable[this._stockDetailDataTable.Count - 1]))
            //{
            //    this.AddStockDetailRow();
            //}
		}

        /// <summary>
        /// �d�����׍s�ɍs�}���\���ǂ����`�F�b�N���܂��B
        /// </summary>
        /// <param name="message"></param>
        /// <returns>true:�}���\ false:�}���s��</returns>
        public bool InsertStockDetailRowCheck(out string message)
        {
            message = string.Empty;
            StockInputDataSet.StockDetailRow row = (StockInputDataSet.StockDetailRow)this._stockDetailDataTable.Rows[this._stockDetailDataTable.Rows.Count - 1];

            if (row != null)
            {
                if (this.ExistStockDetailInput(row))
                {
                    message = "�ŏI�s�����͍ςׁ݂̈A�s�}���ł��܂���B";
                    return false;
                }
            }
            return true;
        }

		/// <summary>
		/// �폜���悤�Ƃ���d�����׍s�I�u�W�F�N�g���폜�\���ǂ������`�F�b�N���܂��B
		/// </summary>
		/// <param name="stockRowNoList">�폜�Ώێd���s�ԍ����X�g</param>
		/// <param name="message">���b�Z�[�W�iout�j</param>
		/// <returns>true:�폜�\ false:�폜�s��</returns>
		public bool DeleteStockDetailRowCheck(List<int> stockRowNoList, out string message)
		{
			bool canDelete = true;
			bool exist = false;
			message = string.Empty;

			// �폜�s�̑��݃`�F�b�N
			int lastInputStockRowNo = this.GetLastInputStockRowNo();

			foreach (int stockRowNo in stockRowNoList)
			{
				if (stockRowNo < lastInputStockRowNo)
				{
					exist = true;
					break;
				}
			}

            if (!exist)
            {
                foreach (int stockRowNo in stockRowNoList)
                {
                    StockInputDataSet.StockDetailRow row = this._dataSet.StockDetail.FindBySupplierSlipNoStockRowNo(this._stockSlip.SupplierSlipNo, stockRowNo);

                    if (( row != null ) && ( ( !string.IsNullOrEmpty(row.GoodsName.Trim()) ) || ( !string.IsNullOrEmpty(row.GoodsNo.Trim()) ) || ( row.EditStatus == ctEDITSTATUS_GoodsDiscount ) ))
                    {
                        exist = true;
                        break;
                    }
                }
            }

			if (!exist)
			{
				message = "�폜�Ώۍs�����݂��܂���B";
				canDelete = false;
			}

			// �폜�s�s���܂܂�Ă��邩�ǂ������`�F�b�N����B
			if (canDelete)
			{
				foreach (int stockRowNo in stockRowNoList)
				{
					StockInputDataSet.StockDetailRow row = this._stockDetailDataTable.FindBySupplierSlipNoStockRowNo(this._stockSlip.SupplierSlipNo, stockRowNo);

					if ((row != null) && (row.EditStatus == StockSlipInputAcs.ctEDITSTATUS_AllReadOnly))
					{
						message = "�폜�s�s�����݂���ׁA�폜�ł��܂���B";
						canDelete = false;
						break;
					}

					if ((row != null) && (row.StockCountMin != 0))
					{
						message = "�u�ԕi�v�������́u�v��v����Ă���ׁA�폜�ł��܂���B";
						canDelete = false;
						break;
					}
				}
			}

			return canDelete;
		}

		/// <summary>
		/// �d�����׍s�I�u�W�F�N�g�̍폜���s���܂��B
		/// </summary>
		/// <param name="stockRowNoList">�폜�sStockRowNo���X�g</param>
		public void DeleteStockDetailRow(List<int> stockRowNoList)
		{
			this.DeleteStockDetailRow(stockRowNoList, false);
		}

		/// <summary>
		/// �d�����׍s�I�u�W�F�N�g�̍폜���s���܂��B�i�I�[�o�[���[�h�j
		/// </summary>
		/// <param name="stockRowNoList">�폜�sStockRowNo���X�g</param>
		/// <param name="changeRowCount">true:�s����ύX���� false:�s����ύX����͕ύX���Ȃ�</param>
		public void DeleteStockDetailRow(List<int> stockRowNoList, bool changeRowCount)
		{
			if (stockRowNoList.Count == 0) return;

			this._stockDetailDataTable.BeginLoadData();
			foreach (int stockRowNo in stockRowNoList)
			{
                StockInputDataSet.StockDetailRow targetRow = this.GetStockDetailRow(stockRowNo);

				if (targetRow == null) continue;

                // �݌ɍs�̏ꍇ
                if (!string.IsNullOrEmpty(targetRow.WarehouseCode))
                {
                    if (targetRow.StockSlipDtlNum != 0)
                    {
                        if (this.SupplierStockCountChangeCheck(targetRow))
                        {
                            this.StockInfoAdjustCountSetting(targetRow.WarehouseCode, targetRow.GoodsNo, targetRow.GoodsMakerCd, ( ( targetRow.StockCountDefault != 0 ) ? targetRow.StockCountDefault : targetRow.StockCount ) * -1);
                        }
                    }
                }

				// ���㓯���v����폜
				this.DeleteSalesTempRow(targetRow.DtlRelationGuid);

				// �v�㌳���׃I�u�W�F�N�g���폜
				this.DeleteAddUpSrcDetail(targetRow);

				this._stockDetailDataTable.RemoveStockDetailRow(targetRow);
			}

			// �d�����׃f�[�^�e�[�u��StockRowNo�񏉊�������
			this.InitializeStockDetailStockRowNoColumn();

			if (!changeRowCount)
			{
				// �폜�����������V�K�ɍs��ǉ�����
				for (int i = 0; i < stockRowNoList.Count; i++)
				{
					this.AddStockDetailRow();
				}
			}
			this._stockDetailDataTable.EndLoadData();
        }

		/// <summary>
		/// �d�����׍s�I�u�W�F�N�g�ɘA������v�㌳�d�����׍s�I�u�W�F�N�g���擾���܂��B
		/// </summary>
		/// <param name="stockDetailRow">�d�����׍s�I�u�W�F�N�g</param>
		private StockInputDataSet.AddUpSrcDetailRow GetAddUpSrcDataRow( StockInputDataSet.StockDetailRow stockDetailRow )
		{
			DataRow[] dataRows = stockDetailRow.GetChildRows(cRelation_Detail_AddUpSrcDetail);
			if (dataRows == null) return null;

			foreach (StockInputDataSet.AddUpSrcDetailRow row in dataRows)
			{
				return row;
			}

			return null;
		}

		/// <summary>
		/// �d�����׍s�I�u�W�F�N�g�ɘA������v�㌳���׍s�I�u�W�F�N�g��S�č폜���܂��B
		/// </summary>
		/// <param name="stockDetailRow">�d�����׍s�I�u�W�F�N�g</param>
		private void DeleteAddUpSrcDetail( StockInputDataSet.StockDetailRow stockDetailRow )
		{

			DataRow[] dataRows = stockDetailRow.GetChildRows(cRelation_Detail_AddUpSrcDetail);
			if (dataRows == null) return;

			foreach (StockInputDataSet.AddUpSrcDetailRow row in dataRows)
			{
				this._addUpSrcDetailDataTable.RemoveAddUpSrcDetailRow(row);
			}
		}

		/// <summary>
		/// �d�����׍s�I�u�W�F�N�g�̒ǉ����s���܂��B
		/// </summary>
		public void AddStockDetailRow()
		{
			int rowCount = this._stockDetailDataTable.Rows.Count;

			StockInputDataSet.StockDetailRow row = this._stockDetailDataTable.NewStockDetailRow();
			row.SupplierSlipNo = this._currentSupplierSlipNo;
			row.StockRowNo = rowCount + 1;
			row.DtlRelationGuid = Guid.Empty;
			this._stockDetailDataTable.AddStockDetailRow(row);
		}

        /// <summary>
        /// �d�����׃f�[�^�e�[�u���ɏ����\���s�����̍s��ǉ����܂��B
        /// </summary>
        public void AddStockDetailRowInitialRowCount()
		{
            StockInputDataSet.StockDetailRow[] stockDetailRowArray = this.SelectStockDetailRows(string.Empty, this._stockDetailDataTable);

			int count = 1;
			if ((stockDetailRowArray != null) && (stockDetailRowArray.Length > 0))
			{
				count = stockDetailRowArray.Length;
			}

			StockSlipInputConstructionAcs stockSlipInputConstructionAcs = StockSlipInputConstructionAcs.GetInstance();

			if (count < stockSlipInputConstructionAcs.DataInputCountValue)
			{
				for (int i = count; i < stockSlipInputConstructionAcs.DataInputCountValue; i++)
				{
					this.AddStockDetailRow();
				}
			}
			else
			{
				//this.AddStockDetailRow();
			}
		}


		/// <summary>
		/// �\���p�̎d���s�ԍ����č̔Ԃ��܂��B
		/// </summary>
		public void AdjustRowNo()
		{
			int no = 1;
			foreach (StockInputDataSet.StockDetailRow row in this._stockDetailDataTable)
			{
                if ( row != null )
                {
                    row.StockRowNoDisplay = no;
                    no++;
                }
            }
		}

		/// <summary>
		/// �d�����׍s�I�u�W�F�N�g�̑}�����s���܂��B
		/// </summary>
		/// <param name="insertIndex">�}���sIndex</param>
		public void InsertStockDetailRow(int insertIndex)
		{
            this.InsertStockDetailRow(insertIndex, 1);
		}

		/// <summary>
		/// �d�����׍s�I�u�W�F�N�g�̑}�����s���܂��B�i�I�[�o�[���[�h�j
		/// </summary>
		/// <param name="insertIndex">�}���sIndex</param>
		/// <param name="line">�}���i��</param>
        public void InsertStockDetailRow( int insertIndex, int line )
        {
            if (line == 0) return;

            this._stockDetailDataTable.BeginLoadData();
            int lastRowIndex = this._stockDetailDataTable.Rows.Count - 1;
            int stockRowNo = this._stockDetailDataTable[insertIndex].StockRowNo;

            StockSlipInputConstructionAcs stockSlipInputConstructionAcs = StockSlipInputConstructionAcs.GetInstance();

            // �d�����׍s�ǉ�����
            for (int i = 0; i < line; i++)
            {
                if (this._stockDetailDataTable.Rows.Count < stockSlipInputConstructionAcs.DataInputCountValue)
                {
                    this.AddStockDetailRow();
                }
            }

            // �ŏI�s����}���Ώۍs�܂ł̍s�����w��i�����ɃR�s�[����
            for (int i = lastRowIndex; i >= insertIndex; i--)
            {
                if (( i + line ) < this._stockDetailDataTable.Rows.Count)
                {
                    StockInputDataSet.StockDetailRow sourceRow = this.GetStockDetailRow(this._stockDetailDataTable[i].StockRowNo);
                    StockInputDataSet.StockDetailRow targetRow = this.GetStockDetailRow(this._stockDetailDataTable[i + line].StockRowNo);

                    this.CopyStockDetailRow(sourceRow, targetRow);
                }
            }

            // �}���Ώۍs���N���A����
            StockInputDataSet.StockDetailRow clearRow = this.GetStockDetailRow(this._stockDetailDataTable[insertIndex].StockRowNo);
            this.ClearStockDetailRow(clearRow);
            this._stockDetailDataTable.EndLoadData();
        }

		/// <summary>
		/// �s�擾����
		/// </summary>
		/// <param name="stockRowNo"></param>
		/// <returns></returns>
        /// <br>Update Note : 2013/01/08 �A����</br>
        /// <br>�Ǘ��ԍ�    : 10801804-00 2013/03/13�z�M��</br>
        /// <br>            : redmine#31984 �d���`�[���͂̑���֗��̑Ή�</br>
		public StockInputDataSet.StockDetailRow GetStockDetailRow( int stockRowNo )
		{
            //----ADD  2013/01/08 Readmine#31984  �A����  ----->>>>>
            //�ݒ��ʂ̕ۑ���̏��������u���Ȃ��v�ɐݒ肵���ꍇ�A���׃O���b�h�ɑO�񔭍s�����d���`�[�̎d��SEQ�ԍ��̃N���A������ǉ�����
            //�N���A�����͈͂͐ԓ`�ȊO
            if (this._stockInputConstructionAcs.ClearAfterSaveValue == StockSlipInputConstructionAcs.ClearAfterSave_OFF && this._stockSlip.SupplierSlipNo == 0 && this._stockSlip.DebitNoteDiv!=1)
            {
                foreach (DataRow row in this._stockDetailDataTable)
                {
                    row[this._stockDetailDataTable.SupplierSlipNoColumn] = 0;
                }
            }
            //----ADD  2013/01/08 Readmine#31984  �A����  -----<<<<<
			return this._stockDetailDataTable.FindBySupplierSlipNoStockRowNo(this._currentSupplierSlipNo, stockRowNo);
		}

		/// <summary>
		/// ���i���̂����͂���Ă���d�����׍s�I�u�W�F�N�g�����݂��邩�ǂ������`�F�b�N���܂��B
		/// </summary>
		/// <returns>true:���݂��� false:���݂��Ȃ�</returns>
		public bool ExistStockDetailData()
		{
			bool exist = false;

			foreach (StockInputDataSet.StockDetailRow row in this._stockDetailDataTable)
			{
                if (this.ExistStockDetailInput(row))
                {
                    exist = true;
                    break;
                }
			}

			return exist;
		}

        // ----ADD 2010/12/03----->>>>>
        /// <summary>
        /// �����ꂩ�̖��׍s�ɐ��ʂ̃}�C�i�X���͂����݂��邩�ǂ������`�F�b�N���܂��B
        /// </summary>
        /// <returns>true:���݂��� false:���݂��Ȃ�</returns>
        public bool ExistStockMaitasuData()
        {
            bool exist = false;

            foreach (StockInputDataSet.StockDetailRow row in this._stockDetailDataTable)
            {
                if (row.StockCountDisplay < 0)
                {
                    exist = true;
                    break;
                }
            }

            return exist;
        }
        // ----ADD 2010/12/03-----<<<<<

        /// <summary>
        /// �d�����׍s���f�[�^���͍ς݂��`�F�b�N���܂��B
        /// </summary>
        /// <returns></returns>
        public bool ExistStockDetailInput(StockInputDataSet.StockDetailRow row)
        {
            return ( ( !string.IsNullOrEmpty(row.GoodsName) ) || ( !string.IsNullOrEmpty(row.GoodsNo) ) );
        }

		/// <summary>
		/// ���׌v��Ώۂ̎d�����׍s�I�u�W�F�N�g�����݂��邩�ǂ������`�F�b�N���܂��B
		/// </summary>
		/// <returns>true:���݂��� false:���݂��Ȃ�</returns>
		public bool ExistArrivalAppropriateDetail()
		{
            //bool exist = false;

            StockInputDataSet.StockDetailRow[] rows = this.SelectStockDetailRows(string.Format("{0}=1 AND {1}<>0",
                this._stockDetailDataTable.SupplierFormalSrcColumn.ColumnName,
                this._stockDetailDataTable.StockSlipDtlNumSrcColumn.ColumnName), this._stockDetailDataTable);


            return ( ( rows != null ) && ( rows.Length > 0 ) );
            //foreach (StockInputDataSet.StockDetailRow row in this._stockDetailDataTable)
            //{
            //    if (( row.SupplierFormalSrc == 1 ) && ( row.StockSlipDtlNumSrc != 0 ))
            //    {
            //        exist = true;
            //        break;
            //    }
            //}

            //return exist;
		}

        /// <summary>
        /// �v��i�����ׂ�����j�s�̑��݃`�F�b�N���s���܂��B
        /// </summary>
        /// <returns>true:���݂��� false:���݂��Ȃ�</returns>
        public bool ExistAddUpDetail()
        {
            StockInputDataSet.StockDetailRow[] rows = this.SelectStockDetailRows(string.Format("{0}<>0", 
                this._stockDetailDataTable.StockSlipDtlNumSrcColumn.ColumnName), this._stockDetailDataTable);

            return ( ( rows != null ) && ( rows.Length > 0 ) );
        }


		/// <summary>
		/// �l�����s���d�����׍s�I�u�W�F�N�g�����݂��邩�ǂ������`�F�b�N���܂��B
		/// </summary>
		/// <returns>true:���݂��� false:���݂��Ȃ�</returns>
		public bool ExistStockDetailDiscountData()
		{
			bool exist = false;

			foreach (StockInputDataSet.StockDetailRow row in this._stockDetailDataTable)
			{
                if (( !string.IsNullOrEmpty(row.GoodsName) ) && ( row.StockSlipCdDtl == 2 ))
                {
                    exist = true;
                    break;
                }
			}

			return exist;
		}

		/// <summary>
		/// ���i���i�̍Đݒ���s���K�v�����鏤�i�����͂���Ă���d�����׍s�I�u�W�F�N�g�����݂��邩�ǂ������`�F�b�N���܂��B
		/// </summary>
		/// <returns>true:���݂��� false:���݂��Ȃ�</returns>
		public bool ExistStockDetailCanGoodsPriceReSettingData()
		{
			bool exist = false;

            foreach (StockInputDataSet.StockDetailRow row in this._stockDetailDataTable)
            {
                if (( ( row.EditStatus == ctEDITSTATUS_AllOK ) || ( row.EditStatus == ctEDITSTATUS_ArrivalAddUpEdit ) || ( row.EditStatus == ctEDITSTATUS_ArrivalAddUpNew ) ) &&
                    ( !string.IsNullOrEmpty(row.GoodsNo) ))
                {
                    exist = true;
                    break;
                }
            }

			return exist;
		}


        /// <summary>
        /// �P���ύX�s���݃`�F�b�N
        /// </summary>
        /// <param name="stockRowNoList">�P���ύX�s���X�g</param>
        /// <returns>True:�P���ύX�s�L��</returns>
        public bool ExistStockUnitPriceChangedRows(out List<int> stockRowNoList)
        {
            stockRowNoList = new List<int>();
            if (this._stockSlip.StockGoodsCd != 0) return false;

            // �l�����A���z����͍s�ȊO�𒊏o
            StockInputDataSet.StockDetailRow[] rows = this.SelectStockDetailRows(string.Format("{0}<>{1} AND NOT({2}={3} AND {4}<>{5})",
                this._stockDetailDataTable.StockSlipCdDtlColumn.ColumnName, 2,
                this._stockDetailDataTable.StockUnitPriceFlColumn.ColumnName, 0,
                this._stockDetailDataTable.StockPriceTaxExcColumn.ColumnName, 0), this._stockDetailDataTable);

            if (( rows == null ) || ( rows.Length == 0 )) return false;

            foreach (StockInputDataSet.StockDetailRow row in rows)
            {
                // �P���̏����l���[���̏ꍇ
                if (( row.StockUnitPriceDefault == 0 ) && ( row.StockUnitTaxPriceDefault == 0 ))
                {
                    // �P���ύX�敪��1�̃f�[�^���ύX�f�[�^
                    if (row.StockUnitChngDiv == 1)
                    {
                        stockRowNoList.Add(row.StockRowNo);
                    }
                }
                // �P���̏����l���[���Ŗ����ꍇ�͏����l����ύX����Ă���f�[�^���Ώۃf�[�^
                else
                {
                    // ���z�\���A���ŕi�͐ō����z�Ŕ��f
                    if (( this._stockSlip.SuppTtlAmntDspWayCd == 0 ) ||
                        ( row.TaxationCode == (int)CalculateTax.TaxationCode.TaxInc ))
                    {
                        if (row.StockUnitTaxPriceDefault != row.StockUnitTaxPriceFl)
                        {
                            stockRowNoList.Add(row.StockRowNo);
                        }
                    }
                    else
                    {
                        if (row.StockUnitPriceDefault != row.StockUnitPriceFl)
                        {
                            stockRowNoList.Add(row.StockRowNo);
                        }
                    }
                }
            }

            return ( stockRowNoList.Count > 0 );
        }

        /// <summary>
        /// ���z�ύX�s���݃`�F�b�N
        /// </summary>
        /// <param name="stockRowNoList">���z�ύX�s���X�g</param>
        /// <returns>True:���z�ύX�s�L��</returns>
        public bool ExistStockPriceChangedRows(out List<int> stockRowNoList)
        {
            stockRowNoList = new List<int>();
            if (this._stockSlip.StockGoodsCd != 0) return false;

            // �l�����A�P�����͍s�ȊO�𒊏o
            StockInputDataSet.StockDetailRow[] rows = this.SelectStockDetailRows(string.Format("{0}<>{1} AND {2}={3} AND {4}<>{5}",
                this._stockDetailDataTable.StockSlipCdDtlColumn.ColumnName, 2,
                this._stockDetailDataTable.StockUnitPriceFlColumn.ColumnName, 0,
                this._stockDetailDataTable.StockPriceTaxExcColumn.ColumnName, 0), this._stockDetailDataTable);

            if (( rows == null ) || ( rows.Length == 0 )) return false;

            foreach (StockInputDataSet.StockDetailRow row in rows)
            {
                // ���z�̏����l���[���̏ꍇ
                if (( row.StockPriceTaxExcDefault == 0 ) && ( row.StockPriceTaxIncDefault == 0 ))
                {
                    // �������őΏ�
                    stockRowNoList.Add(row.StockRowNo);
                }
                // �P���̏����l���[���Ŗ����ꍇ�͏����l����ύX����Ă���f�[�^���Ώۃf�[�^
                else
                {
                    // ���z�\���A���ŕi�͐ō����z�Ŕ��f
                    if (( this._stockSlip.SuppTtlAmntDspWayCd == 0 ) ||
                        ( row.TaxationCode == (int)CalculateTax.TaxationCode.TaxInc ))
                    {
                        if (row.StockPriceTaxIncDefault != row.StockPriceTaxInc)
                        {
                            stockRowNoList.Add(row.StockRowNo);
                        }
                    }
                    else
                    {
                        if (row.StockPriceTaxExcDefault != row.StockPriceTaxExc)
                        {
                            stockRowNoList.Add(row.StockRowNo);
                        }
                    }
                }
            }

            return ( stockRowNoList.Count > 0 );
        }

		/// <summary>
		/// �w�肵���t�B���^��������g�p���Ďd�����׃f�[�^�e�[�u���̑I�����s���A�Y������d�����׍s�I�u�W�F�N�g�z����擾���܂��B
		/// </summary>
		/// <param name="filterExpression">�t�B���^�������邽�߂̊�ƂȂ镶����</param>
		/// <param name="stockDetailDataTable">�d�����׃f�[�^�e�[�u���I�u�W�F�N�g</param>
		/// <returns>�d�����׍s�I�u�W�F�N�g�z��</returns>
		public StockInputDataSet.StockDetailRow[] SelectStockDetailRows(string filterExpression, StockInputDataSet.StockDetailDataTable stockDetailDataTable)
		{
			StockInputDataSet.StockDetailRow[] stockDetailRowArray = null;

			try
			{
				DataRow[] rowArray = stockDetailDataTable.Select(filterExpression);

				if (rowArray != null)
				{
					stockDetailRowArray = (StockInputDataSet.StockDetailRow[])rowArray;
				}
			}
			catch { }

			return stockDetailRowArray;
		}

		/// <summary>
		/// ���i�����͂���Ă���ŏI�s�̎d���s�ԍ����擾���܂��B
		/// </summary>
		/// <returns>���i�����͂���Ă���ŏI�s�̎d���s�ԍ�</returns>
		public int GetLastInputStockRowNo()
		{
			DataRow[] rows = this._stockDetailDataTable.Select(this._stockDetailDataTable.GoodsNameColumn.ColumnName + " <> " + "''", this._stockDetailDataTable.StockRowNoColumn.ColumnName + " ASC");

			if ((rows == null) || (rows.Length == 0))
			{
				return 0;
			}
			else
			{
				StockInputDataSet.StockDetailRow row = (StockInputDataSet.StockDetailRow)rows[rows.Length - 1];
				return row.StockRowNo;
			}
		}

		/// <summary>
		/// �d�����׍s�I�u�W�F�N�g�̃N���A���s���܂��B
		/// </summary>
		/// <param name="stockRowNoList">�N���A�Ώێd���s�ԍ����X�g</param>
		public void ClearStockDetailRow(List<int> stockRowNoList)
		{
			foreach (int stockRowNo in stockRowNoList)
			{
				this.StockDetailRowClearStockInfo(stockRowNo);

				// �d�����׍s�N���A����
				this.ClearStockDetailRow(stockRowNo);

			}
		}

		/// <summary>
		/// �d�����׍s�I�u�W�F�N�g�̃N���A���s���܂��B�i�I�[�o�[���[�h�j
		/// </summary>
		/// <param name="stockRowNo">�N���A�Ώێd���s�ԍ�</param>
		public void ClearStockDetailRow(int stockRowNo)
		{
			StockInputDataSet.StockDetailRow row = this.StockDetailDataTable.FindBySupplierSlipNoStockRowNo(this.StockSlip.SupplierSlipNo, stockRowNo);

			if (row != null)
			{
				this.ClearStockDetailRow(row);
			}
		}

        /// <summary>
        /// ���͉\���ʏ��c�[���`�b�v������𐶐����܂��B
        /// </summary>
        /// <param name="stockRowNo">�d���s�ԍ�</param>
        /// <returns>���͉\���ʏ��c�[���`�b�v������</returns>
		public string CreateStockCountInfoString( int stockRowNo )
		{
			StockInputDataSet.StockDetailRow stockDetailRow = this._stockDetailDataTable.FindBySupplierSlipNoStockRowNo(this._stockSlip.SupplierSlipNo, stockRowNo);
            if (( stockDetailRow == null ) ||
                ( string.IsNullOrEmpty(stockDetailRow.GoodsName) ) ||
                ( stockDetailRow.StockSlipCdDtl == 2 ) ||
                ( string.IsNullOrEmpty(stockDetailRow.GoodsNo) ) ||
                ( stockDetailRow.GoodsMakerCd == 0 )) return string.Empty;

			int totalWidth = 5;

			StringBuilder toolTip = new StringBuilder();

            int sign = ( this._stockSlip.SupplierSlipCd == 20 ) ? -1 : 1;

			if (( stockDetailRow.StockSlipDtlNumSrc != 0 ) && ( stockDetailRow.StockCountMax != 0 ))
			{
				toolTip.Append("�@");
				toolTip.Append("\r\n");

				string name = string.Empty;
				if (this._stockSlip.SupplierSlipCd == 20)
				{
					name = "�ԕi�\��";
				}
				else if (stockDetailRow.SupplierFormalSrc == 1)
				{
					name = "���׎c";
				}
				else
				{
					name = "�����c";
				}

                toolTip.Append(string.Format("{0}�F{1:#,##0.00}", name.PadRight(totalWidth, '�@'), stockDetailRow.StockCountMax * sign));
				toolTip.Append("\r\n");
			}

			if (stockDetailRow.StockCountMin != 0)
			{
				if (String.IsNullOrEmpty(toolTip.ToString().Trim()))
				{
					toolTip.Append("�@");
					toolTip.Append("\r\n");
				}
                toolTip.Append(string.Format("{0}�F{1:#,##0.00}", "�Œ���͐�".PadRight(totalWidth, '�@'), stockDetailRow.StockCountMin * sign));
			}

			return toolTip.ToString();
        }

        /// <summary>
		/// �ǂݎ���p�s�̑��݃`�F�b�N���s���܂��B
		/// </summary>
		/// <returns>true:���݂��� false:���݂��Ȃ�</returns>
		public bool ExistAllReadonlyRow()
		{
			object value = this._stockDetailDataTable.Compute(
							"COUNT(" + this._stockDetailDataTable.RowStatusColumn.ColumnName + ")",
							this._stockDetailDataTable.EditStatusColumn.ColumnName + " = " + ctEDITSTATUS_AllReadOnly
							);

			if (value is System.DBNull) return false;

			int count = (int)value;

			if (count > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// �d�����׃f�[�^�e�[�u�����Ŏd�����ʂ��O�̎d�����׍s�I�u�W�F�N�g�̎d���s�ԍ����X�g���擾���܂��B
		/// </summary>
		/// <returns>�d���s�ԍ����X�g</returns>
		public List<int> GetStockCountZeroStockRowNoList()
		{
			List<int> deleteStockRowNoList = new List<int>();

			DataRow[] rows = this._stockDetailDataTable.Select(
                this._stockDetailDataTable.StockCountDisplayColumn.ColumnName + " = 0");

			if ((rows != null) && (rows.Length > 0))
			{
				StockInputDataSet.StockDetailRow[] stockDetailRows = (StockInputDataSet.StockDetailRow[])rows;

				foreach (StockInputDataSet.StockDetailRow row in stockDetailRows)
				{   
					deleteStockRowNoList.Add(row.StockRowNo);
				}
			}

			return deleteStockRowNoList;
		}

		/// <summary>
		/// �d�����׃f�[�^�e�[�u�����Ŕ����c���ʂ��O�̎d�����׍s�I�u�W�F�N�g�̎d���s�ԍ����X�g���擾���܂��B
		/// </summary>
		/// <returns>�d���s�ԍ����X�g</returns>
		public List<int> GetOrderRemainCountZeroStockRowNoList()
		{
			List<int> deleteStockRowNoList = new List<int>();
			DataRow[] rows = this._stockDetailDataTable.Select(
				this._stockDetailDataTable.OrderRemainCntColumn.ColumnName + " = 0");

			if (( rows != null ) && ( rows.Length > 0 ))
			{
				StockInputDataSet.StockDetailRow[] stockDetailRows = (StockInputDataSet.StockDetailRow[])rows;

				foreach (StockInputDataSet.StockDetailRow row in stockDetailRows)
				{
					deleteStockRowNoList.Add(row.StockRowNo);
				}
			}

			return deleteStockRowNoList;
		}

        /// <summary>
        /// �d�����׃f�[�^�e�[�u�����œ��͍ς݂̍s�����擾���܂��B
        /// </summary>
        /// <returns>�d���s�ԍ����X�g</returns>
        public int GetAlreadyInputRowCount()
        {
            int cnt = 0;

            StockInputDataSet.StockDetailRow[] stockDetailRows = this.SelectStockDetailRows(string.Format("{0}<>'' OR {1}<>''", this._stockDetailDataTable.GoodsNameColumn.ColumnName, this._stockDetailDataTable.GoodsNoColumn.ColumnName), this._stockDetailDataTable);
            if (( stockDetailRows != null ) && ( stockDetailRows.Length > 0 )) cnt = stockDetailRows.Length;

            return cnt;
        }

		/// <summary>
		/// �d�����׃f�[�^�e�[�u�����ŏ��i���̂��󔒂̎d�����׍s�I�u�W�F�N�g�̎d���s�ԍ����X�g���擾���܂��B
		/// </summary>
		/// <returns>�d���s�ԍ����X�g</returns>
		public List<int> GetEmptyStockRowNoList()
		{
			List<int> deleteStockRowNoList = new List<int>();

			DataRow[] rows = this._stockDetailDataTable.Select(
				this._stockDetailDataTable.GoodsNameColumn.ColumnName + " = ''");

			if ((rows != null) && (rows.Length > 0))
			{
				StockInputDataSet.StockDetailRow[] stockDetailRows = (StockInputDataSet.StockDetailRow[])rows;

				foreach (StockInputDataSet.StockDetailRow row in stockDetailRows)
				{
					deleteStockRowNoList.Add(row.StockRowNo);
				}
			}

			return deleteStockRowNoList;
		}

        // 2009.07.10 Add >>>
        /// <summary>
        /// �v��̖��׍s�ԍ����X�g���擾���܂��B
        /// </summary>
        /// <returns></returns>
        public List<int> GetAddUpDetailRowNoList()
        {
            List<int> rowNoList = new List<int>();
            string select = string.Format("{0} <> 0 AND {1}<>{2}", this._stockDetailDataTable.StockSlipDtlNumSrcColumn.ColumnName, this._stockDetailDataTable.SupplierFormalSrcColumn.ColumnName, this._stockSlip.SupplierFormal);
            DataRow[] rows = this._stockDetailDataTable.Select(select);

            if (rows != null && rows.Length > 0)
            {
                StockInputDataSet.StockDetailRow[] stockDetailRows = (StockInputDataSet.StockDetailRow[])rows;

                foreach (StockInputDataSet.StockDetailRow row in stockDetailRows)
                {
                    rowNoList.Add(row.StockRowNo);
                }
            }
            return rowNoList;
        }
        // 2009.07.10 Add <<<

		/// <summary>
		/// �d�����v���z�ݒ菈��
		/// </summary>
		/// <param name="stockSlip">�d���f�[�^�I�u�W�F�N�g</param>
		/// <param name="clearTaxAdjust">����Œ����z�N���A</param>
		public void TotalPriceSetting( ref StockSlip stockSlip, bool clearTaxAdjust )
		{
			if (stockSlip == null) return;
            if (this._supplierAcs == null) this._supplierAcs = new SupplierAcs();
			int stockTaxFrcProcCd = this._supplierAcs.GetStockFractionProcCd(this._enterpriseCode, stockSlip.SupplierCd, SupplierAcs.StockFracProcMoneyDiv.CnsTaxFrcProcCd);		// �d������Œ[�������R�[�h

			long stockTtlPricTaxInc = 0;	// �d�����z�v�i�ō��݁j
			long stockTtlPricTaxExc = 0;	// �d�����z�v�i�Ŕ����j
			long stockPriceConsTax = 0;		// �d�����z����Ŋz
			long ttlItdedStcOutTax = 0;		// �d���O�őΏۊz���v
			long ttlItdedStcInTax = 0;		// �d�����őΏۊz���v
			long ttlItdedStcTaxFree = 0;	// �d����ېőΏۊz���v
			long stockOutTax = 0;			// �d�����z����Ŋz�i�O�Łj
			long stckPrcConsTaxInclu = 0;	// �d�����z����Ŋz�i���Łj
			long stckDisTtlTaxExc = 0;		// �d���l�����z�v�i�Ŕ����j
			long itdedStockDisOutTax = 0;	// �d���l���O�őΏۊz���v
			long itdedStockDisInTax = 0;	// �d���l�����őΏۊz���v
			long itdedStockDisTaxFre = 0;	// �d���l����ېőΏۊz���v
			long stockDisOutTax = 0;		// �d���l������Ŋz�i�O�Łj
			long stckDisTtlTaxInclu = 0;	// �d���l������Ŋz�i���Łj
			long balanceAdjust = 0;			// �c�������z
			long taxAdjust = 0;				// ����Œ����z

			this.CalculateStockTotalPrice(stockSlip.SupplierConsTaxRate, stockTaxFrcProcCd, stockSlip.SuppTtlAmntDspWayCd, stockSlip.SuppCTaxLayCd, out stockTtlPricTaxInc, out stockTtlPricTaxExc, out stockPriceConsTax, out ttlItdedStcOutTax, out ttlItdedStcInTax, out ttlItdedStcTaxFree, out stockOutTax, out stckPrcConsTaxInclu, out stckDisTtlTaxExc, out itdedStockDisOutTax, out itdedStockDisInTax, out itdedStockDisTaxFre, out stockDisOutTax, out stckDisTtlTaxInclu, out balanceAdjust, out taxAdjust);

			switch (stockSlip.StockGoodsCd)
			{
				case 2:	// ����Œ���
				case 4: // ���|�p����Œ���
					{
						stockSlip.StockTtlPricTaxInc = 0;		// �d�����z�v�i�ō��݁j
						stockSlip.StockTtlPricTaxExc = 0;		// �d�����z�v�i�Ŕ����j
						stockSlip.StockPriceConsTax = taxAdjust;// �d�����z����Ŋz
						stockSlip.TtlItdedStcOutTax = 0;		// �d���O�őΏۊz���v
						stockSlip.TtlItdedStcInTax = 0;			// �d�����őΏۊz���v
						stockSlip.TtlItdedStcTaxFree = 0;		// �d����ېőΏۊz���v
						stockSlip.StockOutTax = 0;				// �d�����z����Ŋz�i�O�Łj
						stockSlip.StckPrcConsTaxInclu = 0;		// �d�����z����Ŋz�i���Łj
						stockSlip.StckDisTtlTaxExc = 0;			// �d���l�����z�v�i�Ŕ����j
						stockSlip.ItdedStockDisOutTax = 0;		// �d���l���O�őΏۊz���v
						stockSlip.ItdedStockDisInTax = 0;		// �d���l�����őΏۊz���v
						stockSlip.ItdedStockDisTaxFre = 0;		// �d���l����ېőΏۊz���v
						stockSlip.StockDisOutTax = 0;			// �d���l������Ŋz�i�O�Łj
						stockSlip.StckDisTtlTaxInclu = 0;		// �d���l������Ŋz�i���Łj
						stockSlip.StockNetPrice = 0;			// �d���������z = �O�őΏۋ��z + ���őΏۋ��z + ��ېőΏۋ��z
						stockSlip.StockTotalPrice = 0;			// �d�����z���v
						stockSlip.StockSubttlPrice = 0;			// �d�����z���v
						stockSlip.AccPayConsTax = taxAdjust;	// ���|�����
						break;
					}
				case 3: // �c������
				case 5: // ���|�p�c������
					{
						stockSlip.StockTtlPricTaxInc = 0;		// �d�����z�v�i�ō��݁j
						stockSlip.StockTtlPricTaxExc = 0;		// �d�����z�v�i�Ŕ����j
						stockSlip.StockPriceConsTax = 0;        // �d�����z����Ŋz
						stockSlip.TtlItdedStcOutTax = 0;		// �d���O�őΏۊz���v
						stockSlip.TtlItdedStcInTax = 0;			// �d�����őΏۊz���v
						stockSlip.TtlItdedStcTaxFree = 0;		// �d����ېőΏۊz���v
						stockSlip.StockOutTax = 0;				// �d�����z����Ŋz�i�O�Łj
						stockSlip.StckPrcConsTaxInclu = 0;		// �d�����z����Ŋz�i���Łj
						stockSlip.StckDisTtlTaxExc = 0;			// �d���l�����z�v�i�Ŕ����j
						stockSlip.ItdedStockDisOutTax = 0;		// �d���l���O�őΏۊz���v
						stockSlip.ItdedStockDisInTax = 0;		// �d���l�����őΏۊz���v
						stockSlip.ItdedStockDisTaxFre = 0;		// �d���l����ېőΏۊz���v
						stockSlip.StockDisOutTax = 0;			// �d���l������Ŋz�i�O�Łj
						stockSlip.StckDisTtlTaxInclu = 0;		// �d���l������Ŋz�i���Łj
						stockSlip.StockNetPrice = 0;			// �d���������z = �O�őΏۋ��z + ���őΏۋ��z + ��ېőΏۋ��z
						stockSlip.StockTotalPrice = balanceAdjust;	// �d�����z���v
						stockSlip.StockSubttlPrice = 0;			// �d�����z���v
						stockSlip.AccPayConsTax = 0;			// ���|�����
						break;
					}
				default:
					{
						if (clearTaxAdjust)
						{
							stockSlip.TaxAdjust = 0;
							stockSlip.BalanceAdjust = 0;
						}

                        // --- UPD 2010/10/27 ---------->>>>>
                        //stockSlip.StockTtlPricTaxInc = stockTtlPricTaxInc;		// �d�����z�v�i�ō��݁j
                        stockSlip.StockTtlPricTaxInc = stockTtlPricTaxInc + stockSlip.TaxAdjust;		// �d�����z�v�i�ō��݁j
                        // --- UPD 2010/10/27 ----------<<<<<
						stockSlip.StockTtlPricTaxExc = stockTtlPricTaxExc;		// �d�����z�v�i�Ŕ����j
						stockSlip.StockPriceConsTax = stockPriceConsTax + stockSlip.TaxAdjust;		// �d�����z����Ŋz + ����Œ����z
						stockSlip.TtlItdedStcOutTax = ttlItdedStcOutTax;		// �d���O�őΏۊz���v
						stockSlip.TtlItdedStcInTax = ttlItdedStcInTax;			// �d�����őΏۊz���v
						stockSlip.TtlItdedStcTaxFree = ttlItdedStcTaxFree;		// �d����ېőΏۊz���v
                        // --- UPD 2010/10/27 ---------->>>>>
						//stockSlip.StockOutTax = stockOutTax;					// �d�����z����Ŋz�i�O�Łj
                        stockSlip.StockOutTax = stockOutTax + stockSlip.TaxAdjust;
                        // --- UPD 2010/10/27 ----------<<<<<
						stockSlip.StckPrcConsTaxInclu = stckPrcConsTaxInclu;	// �d�����z����Ŋz�i���Łj
						stockSlip.StckDisTtlTaxExc = stckDisTtlTaxExc;			// �d���l�����z�v�i�Ŕ����j
						stockSlip.ItdedStockDisOutTax = itdedStockDisOutTax;	// �d���l���O�őΏۊz���v
						stockSlip.ItdedStockDisInTax = itdedStockDisInTax;		// �d���l�����őΏۊz���v
						stockSlip.ItdedStockDisTaxFre = itdedStockDisTaxFre;	// �d���l����ېőΏۊz���v
						stockSlip.StockDisOutTax = stockDisOutTax;				// �d���l������Ŋz�i�O�Łj
						stockSlip.StckDisTtlTaxInclu = stckDisTtlTaxInclu;		// �d���l������Ŋz�i���Łj
						stockSlip.StockNetPrice = ttlItdedStcOutTax + ttlItdedStcInTax + ttlItdedStcTaxFree;	// �d���������z = �O�őΏۋ��z + ���őΏۋ��z + ��ېőΏۋ��z
                        stockSlip.StockTotalPrice = stockTtlPricTaxInc + ttlItdedStcTaxFree + itdedStockDisTaxFre + stockSlip.TaxAdjust + stockSlip.BalanceAdjust;		// �d�����z���v = �d�����z�v�i�ō��݁j+ �d����ېőΏۊz���v + �d����ېőΏۊz���v + ����Œ����z + �c�������z
                        stockSlip.StockSubttlPrice = stockTtlPricTaxExc + ttlItdedStcTaxFree + itdedStockDisTaxFre;					// �d�����z���v = �d�����z�v�i�Ŕ����j+ �d����ېőΏۊz���v + �d����ېőΏۊz���v
						stockSlip.AccPayConsTax = stockOutTax + stckPrcConsTaxInclu + stockDisOutTax + stckDisTtlTaxInclu + stockSlip.TaxAdjust;// ���|����� = �d�����z����Ŋz�i�O�Łj+ �d�����z����Ŋz�i���Łj+ �d���l������Ŋz�i�O�Łj+ �d���l������Ŋz�i���Łj+ ����Œ����z
						break; 
					}
			}
        }

        #region �����v���z�W�v

        /// <summary>
		/// �d�����z�̍��v���v�Z���܂��B
		/// </summary>
		/// <param name="supplierConsTaxRate">�d�������Őŗ�</param>
		/// <param name="stockTaxFractionProcCode">�d������Œ[�������R�[�h</param>
		/// <param name="suppTtlAmntDspWayCd">�d���摍�z�\�����@�敪</param>
		/// <param name="suppCTaxLayCd">����œ]�ŕ���</param>
		/// <param name="stockTtlPricTaxInc">�d�����z�v�i�ō��݁j</param>
		/// <param name="stockTtlPricTaxExc">�d�����z�v�i�Ŕ����j</param>
		/// <param name="stockPriceConsTax">�d�����z����Ŋz</param>
		/// <param name="ttlItdedStcOutTax">�d���O�őΏۊz���v</param>
		/// <param name="ttlItdedStcInTax">�d�����őΏۊz���v</param>
		/// <param name="ttlItdedStcTaxFree">�d����ېőΏۊz���v</param>
		/// <param name="stockOutTax">�d�����z����Ŋz�i�O�Łj</param>
		/// <param name="stckPrcConsTaxInclu">�d�����z����Ŋz�i���Łj</param>
		/// <param name="stckDisTtlTaxExc">�d���l�����z�v�i�Ŕ����j</param>
		/// <param name="itdedStockDisOutTax">�d���l���O�őΏۊz���v</param>
		/// <param name="itdedStockDisInTax">�d���l�����őΏۊz���v</param>
		/// <param name="itdedStockDisTaxFre">�d���l����ېőΏۊz���v</param>
		/// <param name="stockDisOutTax">�d���l������Ŋz�i�O�Łj</param>
		/// <param name="stckDisTtlTaxInclu">�d���l������Ŋz�i���Łj</param>
		/// <param name="balanceAdjust">�c���������v�z</param>
		/// <param name="taxAdjust">����ō��v�z</param>
		public void CalculateStockTotalPrice( double supplierConsTaxRate, int stockTaxFractionProcCode, int suppTtlAmntDspWayCd, int suppCTaxLayCd, out long stockTtlPricTaxInc, out long stockTtlPricTaxExc, out long stockPriceConsTax, out long ttlItdedStcOutTax, out long ttlItdedStcInTax, out long ttlItdedStcTaxFree, out long stockOutTax, out long stckPrcConsTaxInclu, out long stckDisTtlTaxExc, out long itdedStockDisOutTax, out long itdedStockDisInTax, out long itdedStockDisTaxFre, out long stockDisOutTax, out long stckDisTtlTaxInclu, out long balanceAdjust, out long taxAdjust )
		{
			// �d������Œ[�������P�ʁA�[�������敪���擾
			int taxFracProcCd = 0;
			double taxFracProcUnit = 0;
            this._stockSlipInputInitDataAcs.GetStockFractionProcInfo(StockSlipInputInitDataAcs.ctFracProcMoneyDiv_Tax, stockTaxFractionProcCode, 0, out taxFracProcUnit, out taxFracProcCd);

			// �f�[�^�e�[�u���̕ύX���R�~�b�g������
			this._stockDetailDataTable.AcceptChanges();

			stockTtlPricTaxInc = 0;		// �d�����z�v�i�ō��݁j
			stockTtlPricTaxExc = 0;		// �d�����z�v�i�Ŕ����j
			stockPriceConsTax = 0;		// �d�����z����Ŋz
			ttlItdedStcOutTax = 0;		// �d���O�őΏۊz���v
			ttlItdedStcInTax = 0;		// �d�����őΏۊz���v
			ttlItdedStcTaxFree = 0;		// �d����ېőΏۊz���v
			stockOutTax = 0;			// �d�����z����Ŋz�i�O�Łj
			stckPrcConsTaxInclu = 0;	// �d�����z����Ŋz�i���Łj
			stckDisTtlTaxExc = 0;		// �d���l�����z�v�i�Ŕ����j
			itdedStockDisOutTax = 0;	// �d���l���O�őΏۊz���v
			itdedStockDisInTax = 0;		// �d���l�����őΏۊz���v
			itdedStockDisTaxFre = 0;	// �d���l����ېőΏۊz���v
			stockDisOutTax = 0;			// �d���l������Ŋz�i�O�Łj
			stckDisTtlTaxInclu = 0;		// �d���l������Ŋz�i���Łj
			balanceAdjust = 0;			// �c�������z
			taxAdjust = 0;				// ����Œ����z

			object value = null;

			//--------------------------------------------------
			// �v�Z�ɕK�v�ȋ��z�̌v�Z
			//--------------------------------------------------
			#region �v�Z�ɕK�v�ȋ��z�̌v�Z
			// �d���O�őΏۊz���v
			value = this._stockDetailDataTable.Compute(
				string.Format("SUM({0})", this._stockDetailDataTable.StockPriceTaxExcColumn.ColumnName),
				string.Format("{0}={1} AND {2}<>{3}", this._stockDetailDataTable.TaxationCodeColumn.ColumnName, (int)CalculateTax.TaxationCode.TaxExc, this._stockDetailDataTable.StockSlipCdDtlColumn.ColumnName, 2));
			ttlItdedStcOutTax = ( value is System.DBNull ) ? 0 : (long)value;

			// �d�����z����Ŋz�i�O�Łj
			value = this._stockDetailDataTable.Compute(
				string.Format("SUM({0})", this._stockDetailDataTable.StockPriceConsTaxColumn.ColumnName),
				string.Format("{0}={1} AND {2}<>{3}", this._stockDetailDataTable.TaxationCodeColumn.ColumnName, (int)CalculateTax.TaxationCode.TaxExc, this._stockDetailDataTable.StockSlipCdDtlColumn.ColumnName, 2));
			stockOutTax = ( value is System.DBNull ) ? 0 : (long)value;

			// �d�����őΏۊz���v
			value = this._stockDetailDataTable.Compute(
				string.Format("SUM({0})", this._stockDetailDataTable.StockPriceTaxExcColumn.ColumnName),
				string.Format("{0}={1} AND {2}<>{3}", this._stockDetailDataTable.TaxationCodeColumn.ColumnName, (int)CalculateTax.TaxationCode.TaxInc, this._stockDetailDataTable.StockSlipCdDtlColumn.ColumnName, 2));
			ttlItdedStcInTax = ( value is System.DBNull ) ? 0 : (long)value;

			// �d�����őΏۊz���v�i�ō��j
			value = this._stockDetailDataTable.Compute(
				string.Format("SUM({0})", this._stockDetailDataTable.StockPriceTaxIncColumn.ColumnName),
				string.Format("{0}={1} AND {2}<>{3}", this._stockDetailDataTable.TaxationCodeColumn.ColumnName, (int)CalculateTax.TaxationCode.TaxInc, this._stockDetailDataTable.StockSlipCdDtlColumn.ColumnName, 2));
			long ttlItdedStcInTax_TaxInc = ( value is System.DBNull ) ? 0 : (long)value;

			// �d�����z����Ŋz�i���Łj
			value = this._stockDetailDataTable.Compute(
				string.Format("SUM({0})", this._stockDetailDataTable.StockPriceConsTaxColumn.ColumnName),
				string.Format("{0}={1} AND {2}<>{3}", this._stockDetailDataTable.TaxationCodeColumn.ColumnName, (int)CalculateTax.TaxationCode.TaxInc, this._stockDetailDataTable.StockSlipCdDtlColumn.ColumnName, 2));
			stckPrcConsTaxInclu = ( value is System.DBNull ) ? 0 : (long)value;
			
			// �d����ېőΏۊz���v
			value = this._stockDetailDataTable.Compute(
				string.Format("SUM({0})", this._stockDetailDataTable.StockPriceTaxIncColumn.ColumnName),
				string.Format("{0}={1} AND {2}<>{3}", this._stockDetailDataTable.TaxationCodeColumn.ColumnName, (int)CalculateTax.TaxationCode.TaxNone, this._stockDetailDataTable.StockSlipCdDtlColumn.ColumnName, 2));
			ttlItdedStcTaxFree = ( value is System.DBNull ) ? 0 : (long)value;

			// �d���l���O�őΏۊz���v
			value = this._stockDetailDataTable.Compute(
				string.Format("SUM({0})", this._stockDetailDataTable.StockPriceTaxExcColumn.ColumnName),
				string.Format("{0}={1} AND {2}={3}", this._stockDetailDataTable.TaxationCodeColumn.ColumnName, (int)CalculateTax.TaxationCode.TaxExc, this._stockDetailDataTable.StockSlipCdDtlColumn.ColumnName, 2));
			itdedStockDisOutTax = ( value is System.DBNull ) ? 0 : (long)value;

			// �d���l������Ŋz�i�O�Łj
			value = this._stockDetailDataTable.Compute(
				string.Format("SUM({0})", this._stockDetailDataTable.StockPriceConsTaxColumn.ColumnName),
				string.Format("{0}={1} AND {2}={3}", this._stockDetailDataTable.TaxationCodeColumn.ColumnName, (int)CalculateTax.TaxationCode.TaxExc, this._stockDetailDataTable.StockSlipCdDtlColumn.ColumnName, 2));
			stockDisOutTax = ( value is System.DBNull ) ? 0 : (long)value;

			// �d���l�����őΏۊz���v
			value = this._stockDetailDataTable.Compute(
				string.Format("SUM({0})", this._stockDetailDataTable.StockPriceTaxExcColumn.ColumnName),
				string.Format("{0}={1} AND {2}={3}", this._stockDetailDataTable.TaxationCodeColumn.ColumnName, (int)CalculateTax.TaxationCode.TaxInc, this._stockDetailDataTable.StockSlipCdDtlColumn.ColumnName, 2));
			itdedStockDisInTax = ( value is System.DBNull ) ? 0 : (long)value;

			// �l�����őΏۋ��z���v(�ō���)
			value = this._stockDetailDataTable.Compute(
				string.Format("SUM({0})", this._stockDetailDataTable.StockPriceTaxIncColumn.ColumnName),
				string.Format("{0}={1} AND {2}={3}", this._stockDetailDataTable.TaxationCodeColumn.ColumnName, (int)CalculateTax.TaxationCode.TaxInc, this._stockDetailDataTable.StockSlipCdDtlColumn.ColumnName, 2));
			long itdedStockDisInTax_TaxInc = ( value is System.DBNull ) ? 0 : (long)value;

			// �d���l������Ŋz�i���Łj
			value = this._stockDetailDataTable.Compute(
				string.Format("SUM({0})", this._stockDetailDataTable.StockPriceConsTaxColumn.ColumnName),
				string.Format("{0}={1} AND {2}={3}", this._stockDetailDataTable.TaxationCodeColumn.ColumnName, (int)CalculateTax.TaxationCode.TaxInc, this._stockDetailDataTable.StockSlipCdDtlColumn.ColumnName, 2));
			stckDisTtlTaxInclu = ( value is System.DBNull ) ? 0 : (long)value;
			
			// �d���l����ېőΏۊz���v
			value = this._stockDetailDataTable.Compute(
				string.Format("SUM({0})", this._stockDetailDataTable.StockPriceTaxIncColumn.ColumnName),
				string.Format("{0}={1} AND {2}={3}", this._stockDetailDataTable.TaxationCodeColumn.ColumnName, (int)CalculateTax.TaxationCode.TaxNone, this._stockDetailDataTable.StockSlipCdDtlColumn.ColumnName, 2));
			itdedStockDisTaxFre = ( value is System.DBNull ) ? 0 : (long)value;

			// �c�������z
			value = this._stockDetailDataTable.Compute(
				string.Format("SUM({0})", this._stockDetailDataTable.StockPriceTaxIncColumn.ColumnName),
				string.Format("{0}={1} OR {2}={3}", this._stockDetailDataTable.StockGoodsCdColumn.ColumnName, 3, this._stockDetailDataTable.StockGoodsCdColumn.ColumnName, 5));
			balanceAdjust = ( value is System.DBNull ) ? 0 : (long)value;

			// ����Œ����z
			value = this._stockDetailDataTable.Compute(
				string.Format("SUM({0})", this._stockDetailDataTable.StockPriceConsTaxColumn.ColumnName),
				string.Format("{0}={1} OR {2}={3}", this._stockDetailDataTable.StockGoodsCdColumn.ColumnName, 2, this._stockDetailDataTable.StockGoodsCdColumn.ColumnName, 4));
			taxAdjust = ( value is System.DBNull ) ? 0 : (long)value;

			// �d���l�����z�v�i�Ŕ����j = �d���l���O�őΏۊz���v + �d���l�����őΏۊz���v + �d���l����ېőΏۊz���v
			stckDisTtlTaxExc = itdedStockDisOutTax + itdedStockDisInTax + itdedStockDisTaxFre;

			#endregion

			if (this._stockSlip.StockGoodsCd == 6)
			{
				// ���z�\��
				if (suppTtlAmntDspWayCd == 1)
				{
					//--------------------------------------------------
                    // �@ �d�����z�v�i�ō��݁j�F�d���O�őΏۊz���v + �d�����z����Ŋz�i�O�Łj+ �d���l���O�őΏۊz���v + �d���l������Ŋz�i�O�Łj + �d�����őΏۊz���v�i�ō��j +  �l�����őΏۋ��z���v(�ō���)
					//--------------------------------------------------
                    stockTtlPricTaxInc = ttlItdedStcOutTax + stockOutTax + itdedStockDisOutTax + stockDisOutTax + ttlItdedStcInTax_TaxInc + itdedStockDisInTax_TaxInc;

					//--------------------------------------------------
					// �A �d�����z����Ŋz�F�����(����) + �����(�O��)
					//--------------------------------------------------
					stockPriceConsTax = stckPrcConsTaxInclu + stockOutTax;

					//--------------------------------------------------
					// �B �d�����z�v�i�Ŕ����j�F�@ - �A
					//--------------------------------------------------
					stockTtlPricTaxExc = stockTtlPricTaxInc - stockPriceConsTax;
				}
				else
				{
					//--------------------------------------------------
                    // �@ �d�����z�v(�Ŕ���)�F�d���O�őΏۊz���v + �d�����őΏۊz���v + �l���O�őΏۋ��z���v + �l�����őΏۋ��z���v
					//--------------------------------------------------
                    stockTtlPricTaxExc = ttlItdedStcOutTax + ttlItdedStcInTax + itdedStockDisOutTax + itdedStockDisInTax;

					//--------------------------------------------------
					// �A �d�����z����Ŋz�F�����(����) + �����(�O��)
					//--------------------------------------------------
					stockPriceConsTax = stockOutTax + stckPrcConsTaxInclu;

					//--------------------------------------------------
					// �B �d�����z�v�i�ō��j�F�@ + �A
					//--------------------------------------------------
					stockTtlPricTaxInc = stockTtlPricTaxExc + stockPriceConsTax;
				}
			}
			else
			{

                //// ���z�\������
                //if (suppTtlAmntDspWayCd == 1)
                //{
                //    //--------------------------------------------------
                //    // �@ �d�����z�v�i�ō��݁j�F�d���O�őΏۊz���v + �d�����z����Ŋz�i�O�Łj+ �d���l���O�őΏۊz���v + �d���l������Ŋz�i�O�Łj + �d�����őΏۊz���v�i�ō��j +  �l�����őΏۋ��z���v(�ō���)
                //    //--------------------------------------------------
                //    stockTtlPricTaxInc = ttlItdedStcOutTax + stockOutTax + itdedStockDisOutTax + stockDisOutTax + ttlItdedStcInTax_TaxInc + itdedStockDisInTax_TaxInc;

                //    //--------------------------------------------------
                //    // �A �d�����z����Ŋz�F�@������ł��v�Z
                //    //--------------------------------------------------
                //    stockPriceConsTax = CalculateTax.GetTaxFromPriceInc(supplierConsTaxRate, taxFracProcUnit, taxFracProcCd, stockTtlPricTaxInc);

                //    //--------------------------------------------------
                //    // �B �d�����z�v�i�Ŕ����j�F�A - �@
                //    //--------------------------------------------------
                //    stockTtlPricTaxExc = stockTtlPricTaxInc - stockPriceConsTax;
                //}
                // �]�ŕ����F��ېł̏ꍇ�ɋ��z�𒲐�����
                if (suppCTaxLayCd == 9)
                {
                    // �d�����z����Ŋz�i�O�Łj
                    stockOutTax = 0;

                    // �d�����z����Ŋz�i���Łj
                    stckPrcConsTaxInclu = 0;

                    // �d����ېőΏۊz���v = �d����ېőΏۊz���v + �d���O�őΏۊz���v + �d�����őΏۊz���v
                    ttlItdedStcTaxFree += ttlItdedStcOutTax + ttlItdedStcInTax;

                    // �d���O�őΏۊz���v
                    ttlItdedStcOutTax = 0;

                    // �d�����őΏۊz���v
                    ttlItdedStcInTax = 0;

                    // �d�����őΏۊz���v�i�ō��j
                    ttlItdedStcInTax_TaxInc = 0;

                    // �d���l������Ŋz�i�O�Łj
                    stockDisOutTax = 0;

                    // �d���l������Ŋz�i���Łj
                    stckDisTtlTaxInclu = 0;

                    // �d���l����ېőΏۊz���v = �d���l����ېőΏۊz���v + �d���l���O�őΏۊz���v + �d���l�����őΏۊz���v
                    itdedStockDisTaxFre += itdedStockDisOutTax + itdedStockDisInTax;

                    // �d���l���O�őΏۊz���v
                    itdedStockDisOutTax = 0;

                    // �d���l�����őΏۊz���v
                    itdedStockDisInTax = 0;

                    // �d���l�����őΏۊz���v�i�ō�)
                    itdedStockDisInTax_TaxInc = 0;

                    // �d���l�����z�v�i�Ŕ����j = �d���l���O�őΏۊz���v + �d���l�����őΏۊz���v + �d���l����ېőΏۊz���v
                    stckDisTtlTaxExc = itdedStockDisOutTax + itdedStockDisInTax + itdedStockDisTaxFre;
                }

                // ���ד]�ňȊO
				if (suppCTaxLayCd != 1)
				{
                    //--------------------------------------------------
                    // �@ �d�����z�v(�Ŕ���)�F�d���O�őΏۊz���v + �d�����őΏۊz���v + �l���O�őΏۋ��z���v + �l�����őΏۋ��z���v 
                    //--------------------------------------------------
                    stockTtlPricTaxExc = ttlItdedStcOutTax + ttlItdedStcInTax + itdedStockDisOutTax + itdedStockDisInTax;

                    //--------------------------------------------------
                    // �A �d�����z�v(�ō���)�F�d�����őΏۊz���v(�ō���) + �l�����őΏۊz���v(�ō���) + �d���O�őΏۊz���v + �l���O�őΏۋ��z���v �{ (�d���O�őΏۊz���v + �l���O�őΏۋ��z���v)�~�ŗ�)
                    //--------------------------------------------------
                    stockTtlPricTaxInc = ttlItdedStcInTax_TaxInc + itdedStockDisInTax_TaxInc + ttlItdedStcOutTax + itdedStockDisOutTax + CalculateTax.GetTaxFromPriceExc(supplierConsTaxRate, taxFracProcUnit, taxFracProcCd, ttlItdedStcOutTax + itdedStockDisOutTax);

                    //--------------------------------------------------
                    // �B ����ō��v�F�A - �@
                    //--------------------------------------------------
                    stockPriceConsTax = stockTtlPricTaxInc - stockTtlPricTaxExc;

                    //--------------------------------------------------
                    // �C �d�����z����Ŋz�i�O�Łj�F�d���O�őΏۊz���v �~ �ŗ�
                    //--------------------------------------------------
                    stockOutTax = CalculateTax.GetTaxFromPriceExc(supplierConsTaxRate, taxFracProcUnit, taxFracProcCd, ttlItdedStcOutTax);

                    //--------------------------------------------------
                    // �D �O�őΏۏ����(�Ŕ����A�l�����܂�) �F(�d���O�őΏۊz���v + �d���l���O�őΏۊz���v) �~ �ŗ�
                    //--------------------------------------------------
                    long stockOutTax_All = CalculateTax.GetTaxFromPriceExc(supplierConsTaxRate, taxFracProcUnit, taxFracProcCd, ttlItdedStcOutTax + itdedStockDisOutTax);

                    //--------------------------------------------------
                    // �E �l���O�ŏ���ō��v�F�C - �D
                    //--------------------------------------------------
                    stockDisOutTax = stockOutTax_All - stockOutTax;
				}
				// ���ד]��
				else
				{
                    //--------------------------------------------------
                    // �@ �d�����z����Ŋz�F�d�����z����Ŋz�i�O�Łj + �d�����z����Ŋz�i���Łj +  �d���l������Ŋz�i�O�Łj + �d���l������Ŋz�i���Łj
                    //--------------------------------------------------
                    stockPriceConsTax = stockOutTax + stckPrcConsTaxInclu + stockDisOutTax + stckDisTtlTaxInclu;

                    //--------------------------------------------------
                    // �A �d�����z�v(�Ŕ���)�F�d���O�őΏۊz���v + �d�����őΏۊz���v + �l���O�őΏۋ��z���v + �l�����őΏۋ��z���v
                    //--------------------------------------------------
                    stockTtlPricTaxExc = ttlItdedStcOutTax + ttlItdedStcInTax + itdedStockDisOutTax + itdedStockDisInTax;

                    //--------------------------------------------------
                    // �B �d�����z�v(�ō���)�F�@ + �A
                    //--------------------------------------------------
                    stockTtlPricTaxInc = stockTtlPricTaxExc + stockPriceConsTax;
				}
			}
        }

        #endregion

        /// <summary>
		/// �d�����z���v�Z���܂��B
		/// </summary>
		/// <param name="stockCount">�d����</param>
		/// <param name="stockUnitPrice">�d���P��</param>
		/// <param name="taxationCode">�ېŋ敪</param>
		/// <param name="taxRate">����ŗ�</param>
		/// <param name="stockMoneyFrcProcCd">�d�����z�[�������R�[�h</param>
		/// <param name="taxFracProcCode">����Œ[�������敪</param>
		/// <param name="stockPriceTaxInc">�d�����z�i�ō��݁j</param>
		/// <param name="stockPriceTaxExc">�d�����z�i�Ŕ����j</param>
		/// <param name="stockPriceConsTax">�d�������</param>
		/// <returns></returns>
		private bool CalculateStockPrice( double stockCount, double stockUnitPrice, int taxationCode, double taxRate, int stockMoneyFrcProcCd, int taxFracProcCode,
			out long stockPriceTaxInc, out long stockPriceTaxExc, out long stockPriceConsTax )
		{
			double taxFracProcUnit;
			int taxFracProcCd;
            this._stockSlipInputInitDataAcs.GetStockFractionProcInfo(StockSlipInputInitDataAcs.ctFracProcMoneyDiv_Tax, taxFracProcCode, 0, out taxFracProcUnit, out taxFracProcCd);

			stockPriceTaxInc = 0;
			stockPriceTaxExc = 0;
			stockPriceConsTax = 0;

			// �d������0�܂��͎d���P����0�̏ꍇ�͂��ׂ�0�ŏI��
			if (( stockCount == 0 ) || ( stockUnitPrice == 0 )) return true;

			// �O�ł̏ꍇ
			if (taxationCode == (int)CalculateTax.TaxationCode.TaxExc)
			{
				double unitPriceExc = stockUnitPrice;	// �P���i�Ŕ����j
				double unitPriceInc;					// �P���i�ō��݁j
				double unitPriceTax;					// �P���i����Łj
				long priceExc = 0;						// ���i�i�Ŕ����j
				long priceInc;							// ���i�i�ō��݁j
				long priceTax;							// ���i�i����Łj

				this._stockPriceCalculate.CalcTaxIncFromTaxExc((int)CalculateTax.TaxationCode.TaxExc, stockCount, ref unitPriceExc, out unitPriceInc, out unitPriceTax, ref priceExc, out priceInc, out priceTax, stockMoneyFrcProcCd, taxRate, taxFracProcUnit, taxFracProcCd);

				stockPriceTaxInc = priceInc;			// �d�����z�i�ō��݁j
				stockPriceTaxExc = priceExc;			// �d�����z�i�Ŕ����j		
				stockPriceConsTax = priceTax;			// �d�������
			}
			// ���ł̏ꍇ
			else if (taxationCode == (int)CalculateTax.TaxationCode.TaxInc)
			{
				double unitPriceExc;					// �P���i�Ŕ����j
				double unitPriceInc = stockUnitPrice;	// �P���i�ō��݁j
				double unitPriceTax;					// �P���i����Łj
				long priceExc;							// ���i�i�Ŕ����j
				long priceInc = 0;						// ���i�i�ō��݁j
				long priceTax;							// ���i�i����Łj

				this._stockPriceCalculate.CalcTaxExcFromTaxInc((int)CalculateTax.TaxationCode.TaxInc, stockCount, out unitPriceExc, ref unitPriceInc, out unitPriceTax, out priceExc, ref priceInc, out priceTax, stockMoneyFrcProcCd, taxRate, taxFracProcUnit, taxFracProcCd);

				stockPriceTaxInc = priceInc;			// �d�����z�i�ō��݁j
				stockPriceTaxExc = priceExc;			// �d�����z�i�Ŕ����j
				stockPriceConsTax = priceTax;			// �d�������
			}
			// ��ېł̏ꍇ
			else if (taxationCode == (int)CalculateTax.TaxationCode.TaxNone)
			{
				double unitPriceExc = stockUnitPrice;	// �P���i�Ŕ����j
				double unitPriceInc;					// �P���i�ō��݁j
				double unitPriceTax;					// �P���i����Łj
				long priceExc = 0;						// ���i�i�Ŕ����j
				long priceInc;							// ���i�i�ō��݁j
				long priceTax;							// ���i�i����Łj

				this._stockPriceCalculate.CalcTaxIncFromTaxExc((int)CalculateTax.TaxationCode.TaxNone, stockCount, ref unitPriceExc, out unitPriceInc, out unitPriceTax, ref priceExc, out priceInc, out priceTax, stockMoneyFrcProcCd, taxRate, taxFracProcUnit, taxFracProcCd);

				stockPriceTaxInc = priceExc;			// �d�����z�i�ō��݁j
				stockPriceTaxExc = priceExc;			// �d�����z�i�ō��݁j
				stockPriceConsTax = priceTax;			// �d�������
			}

			return true;
		}

		/// <summary>
		/// �d�����z���v�Z���܂��B
		/// </summary>
		/// <param name="stockPrice">�d�����z</param>
		/// <param name="taxationCode">�ېŋ敪</param>
		/// <param name="taxRate">����ŗ�</param>
        /// <param name="stockCnsTaxFrcProcCd">����Œ[�������R�[�h</param>
		/// <param name="stockPriceTaxInc">�d�����z�i�ō��݁j</param>
		/// <param name="stockPriceTaxExc">�d�����z�i�Ŕ����j</param>
		/// <param name="stockPriceConsTax">�d�������</param>
		/// <returns></returns>
        private bool CalculateStockPrice( long stockPrice, int taxationCode, double taxRate, int stockCnsTaxFrcProcCd, out long stockPriceTaxInc, out long stockPriceTaxExc, out long stockPriceConsTax )
		{
			double taxFracProcUnit;
			int taxFracProcCd;

            this._stockPriceCalculate.CalculatePrice(taxationCode, stockPrice, taxRate, stockCnsTaxFrcProcCd, out stockPriceTaxExc, out stockPriceTaxInc, out stockPriceConsTax, out taxFracProcUnit, out taxFracProcCd);

			return true;
		}

		/// <summary>
		/// �d�����z���v�Z���܂��B
		/// </summary>
		/// <param name="rowIndex">�ΏۍsIndex</param>
		/// <param name="stockDetailDataTable">�d�����׃f�[�^�e�[�u���I�u�W�F�N�g</param>
		public void CalculateStockPrice(int rowIndex, StockInputDataSet.StockDetailDataTable stockDetailDataTable)
		{
			StockInputDataSet.StockDetailRow row = stockDetailDataTable[rowIndex];
			if (row != null)
			{
				this.CalculateStockPrice(row);
			}
		}

		/// <summary>
		/// �d�����z���v�Z���܂��B
		/// </summary>
		/// <param name="row">�d�����׃f�[�^�e�[�u���I�u�W�F�N�g</param>
		public void CalculateStockPrice( StockInputDataSet.StockDetailRow row )
		{
            if (( string.IsNullOrEmpty(row.GoodsName) ) && ( string.IsNullOrEmpty(row.GoodsNo) ))
                return;

			StockSlip stockSlip = this.StockSlip;
			if (stockSlip == null) return;
			int sign = ( stockSlip.SupplierSlipCd == 20 ) ? -1 : 1;

			switch (stockSlip.StockGoodsCd)
			{
				case 2: // ����Œ���
				case 4: // ���|�p����Œ���
					{
						row.StockPriceDisplay = row.StockPriceConsTax * sign;
						break;
					}
				case 3: // �c������
				case 5: // ���|�p�c������
					{
						row.StockPriceDisplay = row.StockPriceTaxInc * sign;
						break;
					}

                case 6: // ���v����
                    {
                        this.StockDetailStockPriceSetting(row.StockRowNo,row.StockPriceDisplay);
                        //row.StockPriceDisplay=
                        //    //this.StockDetailRowStockGoodsCdSetting(
                        //// �d�����z���Z��
                        //long stockPriceTaxInc;
                        //long stockPriceTaxExc;
                        //long stockPriceDisplay;
                        //long stockPriceConsTax;

                        //int taxationCode = row.TaxationCode;

                        //double stockUnitPrice = 0;
                        //if (stockSlip.SuppCTaxLayCd == 9)
                        //{
                        //    stockUnitPrice = row.StockUnitPriceFl;
                        //    stockPriceTaxExc = row.StockPriceTaxExc;
                        //    stockPriceDisplay = row.StockPriceDisplay * sign;
                        //    taxationCode = (int)CalculateTax.TaxationCode.TaxNone;
                        //}
                        //else if (( row.TaxationCode == (int)CalculateTax.TaxationCode.TaxInc ) || ( stockSlip.SuppTtlAmntDspWayCd == 1 ))
                        //{
                        //    stockUnitPrice = row.StockUnitTaxPriceFl;
                        //    stockPriceTaxInc = row.StockPriceTaxInc;
                        //    //stockPriceDisplay = stockPriceTaxInc * sign;
                        //    stockPriceDisplay = row.StockPriceDisplay * sign;
                        //}
                        //else
                        //{
                        //    stockUnitPrice = row.StockUnitPriceFl;
                        //    stockPriceTaxExc = row.StockPriceTaxExc;
                        //    //stockPriceDisplay = stockPriceTaxExc * sign;
                        //    stockPriceDisplay = row.StockPriceDisplay * sign;
                        //}

                        //// ���z�\�����͓��łŌv�Z����
                        //if (( taxationCode != (int)CalculateTax.TaxationCode.TaxNone ) && ( stockSlip.SuppTtlAmntDspWayCd == 1 ))
                        //    taxationCode = (int)CalculateTax.TaxationCode.TaxInc;

                        //bool stockPriceCalculated = false;

                        //stockPriceCalculated = this.CalculateStockPrice(stockPriceDisplay, taxationCode, out stockPriceTaxInc, out stockPriceTaxExc, out stockPriceConsTax);

                        //if (stockPriceCalculated)
                        //{
                        //    row.StockPriceTaxExc = stockPriceTaxExc;
                        //    row.StockPriceTaxInc = stockPriceTaxInc;
                        //    row.StockPriceConsTax = stockPriceConsTax;

                        //    // ��ېł̏ꍇ�͐Ŕ������i��\��
                        //    if (stockSlip.SuppCTaxLayCd == 9)
                        //    {
                        //        row.StockPriceDisplay = stockPriceTaxExc * sign;
                        //    }
                        //    // ���z�\������������͓��ŏ��i�͐ō����i��\������
                        //    else if (( stockSlip.SuppTtlAmntDspWayCd == 1 ) || ( row.TaxationCode == (int)CalculateTax.TaxationCode.TaxInc ))
                        //    {
                        //        row.StockPriceDisplay = stockPriceTaxInc * sign;
                        //    }
                        //    else
                        //    {
                        //        row.StockPriceDisplay = stockPriceTaxExc * sign;
                        //    }
                        //}
                        break;
                    }
				default:
					{
						// �d�����z���Z��
						long stockPriceTaxInc;
						long stockPriceTaxExc;
						long stockPriceDisplay;
						long stockPriceConsTax;

						int taxationCode = row.TaxationCode;

						double stockUnitPrice = 0;
                        if (stockSlip.SuppCTaxLayCd == 9)
                        {
                            stockUnitPrice = row.StockUnitPriceFl;
                            stockPriceTaxExc = row.StockPriceTaxExc;
                            stockPriceDisplay = row.StockPriceDisplay * sign;
                            taxationCode = (int)CalculateTax.TaxationCode.TaxNone;
                        }
                        else if (( row.TaxationCode == (int)CalculateTax.TaxationCode.TaxInc ) || ( stockSlip.SuppTtlAmntDspWayCd == 1 ))
                        {
                            stockUnitPrice = row.StockUnitTaxPriceFl;
                            stockPriceTaxInc = row.StockPriceTaxInc;
                            //stockPriceDisplay = stockPriceTaxInc * sign;
                            stockPriceDisplay = row.StockPriceDisplay * sign;
                        }
                        else
                        {
                            stockUnitPrice = row.StockUnitPriceFl;
                            stockPriceTaxExc = row.StockPriceTaxExc;
                            //stockPriceDisplay = stockPriceTaxExc * sign;
                            stockPriceDisplay = row.StockPriceDisplay * sign;
                        }

						// ���z�\�����͓��łŌv�Z����
                        if (( taxationCode != (int)CalculateTax.TaxationCode.TaxNone ) && ( stockSlip.SuppTtlAmntDspWayCd == 1 )) 
                            taxationCode = (int)CalculateTax.TaxationCode.TaxInc;

                        bool stockPriceCalculated = false;

						// ���z����͕��A�l�����Ő��ʃ[���́A�\���d�����z���x�[�X�ɍČv�Z����
                        if (( row.StockPriceDiectInput ) ||
                            ( ( row.StockSlipCdDtl == 2 ) && ( row.StockCountDisplay == 0 ) ))
                        {
                            stockPriceCalculated = this.CalculateStockPrice(stockPriceDisplay, taxationCode, out stockPriceTaxInc, out stockPriceTaxExc, out stockPriceConsTax);
                        }
                        else
                        {
                            stockPriceCalculated = this.CalculateStockPrice(row.StockCount, stockUnitPrice, taxationCode, out stockPriceTaxInc, out stockPriceTaxExc, out stockPriceConsTax);
                        }

                        if (stockPriceCalculated)
                        {
                            row.StockPriceTaxExc = stockPriceTaxExc;
                            row.StockPriceTaxInc = stockPriceTaxInc;
                            row.StockPriceConsTax = stockPriceConsTax;

                            // ��ېł̏ꍇ�͐Ŕ������i��\��
                            if (stockSlip.SuppCTaxLayCd == 9)
                            {
                                row.StockPriceDisplay = stockPriceTaxExc * sign;
                            }
                            // ���z�\������������͓��ŏ��i�͐ō����i��\������
                            else if (( stockSlip.SuppTtlAmntDspWayCd == 1 ) || ( row.TaxationCode == (int)CalculateTax.TaxationCode.TaxInc ))
                            {
                                row.StockPriceDisplay = stockPriceTaxInc * sign;
                            }
                            else
                            {
                                row.StockPriceDisplay = stockPriceTaxExc * sign;
                            }
                        }
						break;
					}
			}

		}

        /// <summary>
        /// �d�����z���v�Z���܂��B
        /// </summary>
        /// <param name="stockPriceDisplay">�d�����z</param>
        /// <param name="taxationCode">�ېŋ敪</param>
        /// <param name="stockPriceTaxInc">�d�����z(�ō�)</param>
        /// <param name="stockPriceTaxExc">�d�����z(�Ŕ�)</param>
        /// <param name="stockPriceConsTax">�d������ŋ��z</param>
        private bool CalculateStockPrice( long stockPriceDisplay, int taxationCode, out long stockPriceTaxInc, out long stockPriceTaxExc, out long stockPriceConsTax )
        {
            double taxRate = this._stockSlip.SupplierConsTaxRate;
            if (this._supplierAcs == null) this._supplierAcs = new SupplierAcs();
            int stockMoneyFrcProcCd = this._supplierAcs.GetStockFractionProcCd(this._enterpriseCode, this._stockSlip.SupplierCd, SupplierAcs.StockFracProcMoneyDiv.MoneyFrcProcCd);   // �d�����z�[�������R�[�h
            int taxFrcProcCd = this._supplierAcs.GetStockFractionProcCd(this._enterpriseCode, this._stockSlip.SupplierCd, SupplierAcs.StockFracProcMoneyDiv.CnsTaxFrcProcCd);         // �d������Œ[�������R�[�h

            return this.CalculateStockPrice(stockPriceDisplay, taxationCode, taxRate, taxFrcProcCd, out stockPriceTaxInc, out stockPriceTaxExc, out stockPriceConsTax);
        }


        /// <summary>
        /// �d�����z���v�Z���܂��B
        /// </summary>
        /// <param name="stockCount">����</param>
        /// <param name="stockUnitPrice">�P��</param>
        /// <param name="taxationCode">�ېŋ敪</param>
        /// <param name="stockPriceTaxInc">�d�����z(�ō�)</param>
        /// <param name="stockPriceTaxExc">�d�����z(�Ŕ�)</param>
        /// <param name="stockPriceConsTax">�d������ŋ��z</param>
        private bool CalculateStockPrice(double stockCount, double stockUnitPrice,int taxationCode, out long stockPriceTaxInc, out long stockPriceTaxExc, out long stockPriceConsTax )
        {
            double taxRate = this._stockSlip.SupplierConsTaxRate;
            if (this._supplierAcs == null) this._supplierAcs = new SupplierAcs();
            int stockMoneyFrcProcCd = this._supplierAcs.GetStockFractionProcCd(this._enterpriseCode, this._stockSlip.SupplierCd, SupplierAcs.StockFracProcMoneyDiv.MoneyFrcProcCd);   // �d�����z�[�������R�[�h
            int taxFrcProcCd = this._supplierAcs.GetStockFractionProcCd(this._enterpriseCode, this._stockSlip.SupplierCd, SupplierAcs.StockFracProcMoneyDiv.CnsTaxFrcProcCd);         // �d������Œ[�������R�[�h

            return this.CalculateStockPrice(stockCount, stockUnitPrice, taxationCode, taxRate, stockMoneyFrcProcCd, taxFrcProcCd, out stockPriceTaxInc, out stockPriceTaxExc, out stockPriceConsTax);
        }

        /// <summary>
        /// �d�����z�̕����𒲐����܂��B
        /// </summary>
        /// <param name="rowIndex">�s�C���f�b�N�X</param>
        public void AdjustStockPriceSignBasedOnRowIndex(int rowIndex)
        {
            StockInputDataSet.StockDetailRow row = this._stockDetailDataTable[rowIndex];

            if (row != null)
            {
                this.AdjustStockPriceSign(row);
            }
        }

        /// <summary>
        /// �d�����z�̕����𒲐����܂��B
        /// </summary>
        /// <param name="row"></param>
        private void AdjustStockPriceSign(StockInputDataSet.StockDetailRow row)
        {
            if (row.StockCount != 0)
            {
                // �P�����[���̏ꍇ�̂ݑΏ�
                if (( row.StockUnitPriceFl == 0 ) &&
                    ( row.StockUnitTaxPriceFl == 0 ))
                {
                    int displaySign = ( this._stockSlip.SupplierSlipCd == 20 ) ? -1 : 1;

                    int sign = ( row.StockCount < 0 ) ? -1 : 1;
                    row.StockPriceTaxExc = Math.Abs(row.StockPriceTaxExc) * sign;
                    row.StockPriceTaxInc = Math.Abs(row.StockPriceTaxInc) * sign;

                    if (( row.TaxationCode == (int)CalculateTax.TaxationCode.TaxNone ) ||
                       ( this._stockSlip.SuppCTaxLayCd == 9 ))
                    {
                        row.StockPriceDisplay = row.StockPriceTaxExc * displaySign;
                    }
                    else if (( this._stockSlip.SuppTtlAmntDspWayCd == 1 ) ||
                        ( row.TaxationCode == (int)CalculateTax.TaxationCode.TaxInc ))
                    {
                        row.StockPriceDisplay = row.StockPriceTaxInc * displaySign;
                    }
                    else
                    {
                        row.StockPriceDisplay = row.StockPriceTaxExc * displaySign;
                    }
                }
            }
        }

		/// <summary>
		/// �d�����z���v�Z���܂��B
		/// </summary>
		/// <param name="rowIndex">�ΏۍsIndex</param>
		public void CalculateStockPriceBasedOnRowIndex(int rowIndex)
		{
            
			this.CalculateStockPrice(rowIndex, this._stockDetailDataTable);
		}

		/// <summary>
		/// �d�����׍s�ԍ����w�肵�Ďd�����z���v�Z���܂��B
		/// </summary>
		/// <param name="stockRowNo"></param>
		public void CalculateStockPriceBasedOnStockRowNo( int stockRowNo )
		{
            StockInputDataSet.StockDetailRow row = this.GetStockDetailRow(stockRowNo);

			if (row != null)
			{
				this.CalculateStockPrice(row);
			}
		}

		#region �݌Ɍ���

        /// <summary>
        /// �����p�q�ɃR�[�h�z����擾���܂��B
        /// </summary>
        /// <returns>�q�ɃR�[�h�z��</returns>
        public string[] GetSearchWarehouseArray()
        {
            List<string> warehouseList = new List<string>();

            warehouseList.Add(this._stockSlip.WarehouseCode.Trim());

            if (this._stockSlipInputInitDataAcs.GetStockTtlSt().StockSearchDiv == 0)
            {
                SecInfoSet secInfoSet = this._stockSlipInputInitDataAcs.GetSecInfo(this._stockSlip.StockSectionCd);
                if (secInfoSet != null)
                {
                    if (!string.IsNullOrEmpty(secInfoSet.SectWarehouseCd1.Trim())) warehouseList.Add(secInfoSet.SectWarehouseCd1.Trim());
                    if (!string.IsNullOrEmpty(secInfoSet.SectWarehouseCd2.Trim())) warehouseList.Add(secInfoSet.SectWarehouseCd2.Trim());
                    if (!string.IsNullOrEmpty(secInfoSet.SectWarehouseCd3.Trim())) warehouseList.Add(secInfoSet.SectWarehouseCd3.Trim());
                }
            }

            return warehouseList.ToArray();
        }

        /// <summary>
        /// ���׏�񃊃X�g���݌Ƀ}�X�^���������A�݌Ƀ��X�g���擾���܂��B
        /// </summary>
		/// <param name="stockDetailList">���׏�񃊃X�g</param>
        public List<Stock> SearchStock( List<StockDetail> stockDetailList )
        {
            if (( stockDetailList == null ) || ( stockDetailList.Count == 0 )) return new List<Stock>(); 

			string[] goodsNos = new string[stockDetailList.Count];
			int[] goodsMakerCds = new int[stockDetailList.Count];
			string[] warehouseCodes = new string[stockDetailList.Count];


			// �p�����[�^�ݒ�
			for (int cnt = 0; cnt < stockDetailList.Count; cnt++)
            {
				goodsNos[cnt] = stockDetailList[cnt].GoodsNo;
				goodsMakerCds[cnt] = stockDetailList[cnt].GoodsMakerCd;
				warehouseCodes[cnt] = stockDetailList[cnt].WarehouseCode;
            }
			
            StockSearchPara stockSearchPara = new StockSearchPara();
            stockSearchPara.EnterpriseCode = this._enterpriseCode;
			//stockSearchPara.SectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;
            stockSearchPara.GoodsNos = goodsNos;
            stockSearchPara.GoodsMakerCds = goodsMakerCds;
            stockSearchPara.WarehouseCodes = warehouseCodes;

			return SearchStock(stockSearchPara);
		}

		/// <summary>
		/// �q�ɃR�[�h�A���i�R�[�h�A���[�J�[�R�[�h���݌Ƀ}�X�^���������A�݌Ƀ��X�g���擾���܂��B
		/// </summary>
		/// <param name="warehosueCode">�q�ɃR�[�h</param>
		/// <param name="goodsNo">���i�R�[�h</param>
		/// <param name="goodsMakerCd">���[�J�[�R�[�h</param>
        public List<Stock> SearchStock( string warehosueCode, string goodsNo, int goodsMakerCd )
		{
			StockSearchPara stockSearchPara = new StockSearchPara();
			stockSearchPara.EnterpriseCode = this._enterpriseCode;
			stockSearchPara.GoodsNo = goodsNo;
			stockSearchPara.GoodsMakerCd = goodsMakerCd;
			stockSearchPara.WarehouseCode = warehosueCode;

			return SearchStock(stockSearchPara);
		}

		/// <summary>
		/// �݌Ɍ����p�����[�^���݌Ɍ������s���A�݌Ƀ��X�g���擾���܂��B
		/// </summary>
		/// <param name="stockSearchPara">�݌Ɍ����p�����[�^</param>
		/// <returns>�݌Ƀ��X�g</returns>
        private List<Stock> SearchStock( StockSearchPara stockSearchPara )
		{
            List<Stock> retStockList=new List<Stock>();

			string msg;
            if (this._searchStockAcs == null) this._searchStockAcs = new SearchStockAcs();
			int status = this._searchStockAcs.Search(stockSearchPara, out retStockList, out msg);
			if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
                retStockList = new List<Stock>();
			}

			return retStockList;
		}

		#endregion

		/// <summary>
		/// �������݃`�F�b�N
		/// </summary>
		/// <param name="stockRowNo">�Ώۍs</param>
		/// <returns></returns>
		public bool MemoExist( int stockRowNo )
		{
			bool ret = false;

			StockInputDataSet.StockDetailRow row = this._stockDetailDataTable.FindBySupplierSlipNoStockRowNo(this._stockSlip.SupplierSlipNo, stockRowNo);

			if (row != null)
			{
                if (( !string.IsNullOrEmpty(row.SlipMemo1) ) || ( !string.IsNullOrEmpty(row.SlipMemo2) ) || ( !string.IsNullOrEmpty(row.SlipMemo3) ) ||
                    ( !string.IsNullOrEmpty(row.InsideMemo1) ) || ( !string.IsNullOrEmpty(row.InsideMemo2) ) || ( !string.IsNullOrEmpty(row.InsideMemo3) ))
                {
                    ret = true;
                }
			}

			return ret;
		}

		
		/// <summary>
		/// �P�����m�F�p�I�u�W�F�N�g�擾
		/// </summary>
		/// <param name="stockRowNo">�s�ԍ�</param>
		/// <returns>�P�����m�F�p�I�u�W�F�N�g</returns>
		public UnPrcInfoConf GetUnitPriceInfoConf( int stockRowNo )
		{
			UnPrcInfoConf unPrcInfoConf = new UnPrcInfoConf();

			StockInputDataSet.StockDetailRow row = this._stockDetailDataTable.FindBySupplierSlipNoStockRowNo(this._stockSlip.SupplierSlipNo, stockRowNo);

			if (row != null)
			{
                // �d������Œ[�������P�ʁA�[�������敪���擾
                if (this._supplierAcs == null) this._supplierAcs = new SupplierAcs();
                int stockTaxFrcProcCd = this._supplierAcs.GetStockFractionProcCd(this._enterpriseCode, this._stockSlip.SupplierCd, SupplierAcs.StockFracProcMoneyDiv.CnsTaxFrcProcCd);		// �d������Œ[�������R�[�h
                
                int taxFracProcCd = 0;
                double taxFracProcUnit = 0;
                this._stockSlipInputInitDataAcs.GetStockFractionProcInfo(StockSlipInputInitDataAcs.ctFracProcMoneyDiv_Tax, stockTaxFrcProcCd, 0, out taxFracProcUnit, out taxFracProcCd);

                unPrcInfoConf.RateSettingDivide = row.RateDivStckUnPrc;                         // �|���ݒ�敪
                unPrcInfoConf.SectionCode = row.RateSectStckUnPrc;                              // ���_�R�[�h
                //unPrcInfoConf.CustomerCode = row.CustomerCode;                                // ���Ӑ�R�[�h
                //unPrcInfoConf.CustomerSnm = row.CustomerSnm;                                  // ���Ӑ旪��
                unPrcInfoConf.SupplierCd = this._stockSlip.SupplierCd;                          // �d����R�[�h
                unPrcInfoConf.SupplierSnm = this._stockSlip.SupplierSnm;                        // �d���旪��
                //unPrcInfoConf.CustRateGrpCode = row.CustRateGrpCode;                          // ���Ӑ�|���O���[�v�R�[�h
                unPrcInfoConf.GoodsMakerCd = row.GoodsMakerCd;                                  // ���i���[�J�[�R�[�h
                unPrcInfoConf.MakerName = row.MakerName;                                        // ���[�J�[����
                unPrcInfoConf.GoodsNo = row.GoodsNo;                                            // ���i�ԍ�
                unPrcInfoConf.GoodsName = row.GoodsName;                                        // ���i����
                unPrcInfoConf.GoodsRateRank = row.GoodsRateRank;                                // ���i�|�������N
                unPrcInfoConf.GoodsRateGrpCode = row.RateGoodsRateGrpCd;                        // ���i�|���O���[�v�R�[�h
                unPrcInfoConf.GoodsRateGrpCodeNm = row.RateGoodsRateGrpNm;                      // ���i�|���O���[�v�R�[�h����
                unPrcInfoConf.BLGroupCode = row.RateBLGroupCode;                                // BL�O���[�v�R�[�h
                unPrcInfoConf.BLGroupName = row.RateBLGroupName;                                // BL�O���[�v�R�[�h����
                unPrcInfoConf.BLGoodsCode = row.RateBLGoodsCode;                                // BL���i�R�[�h
                unPrcInfoConf.BLGoodsFullName = row.RateBLGoodsName;                            // BL���i�R�[�h���́i�S�p�j
                unPrcInfoConf.PriceApplyDate = ( this._stockSlip.SupplierFormal == 0 ) ? this._stockSlip.StockAddUpADate : this._stockSlip.ArrivalGoodsDay;	// ���i�K�p��
                unPrcInfoConf.CountFl = row.StockCountDisplay;                                  // ����
                unPrcInfoConf.UnitPrcCalcDiv = row.UnPrcCalcCdStckUnPrc;                        // �P���Z�o�敪
                unPrcInfoConf.RateVal = row.StockRate;                                          // �|��
                unPrcInfoConf.UnPrcFracProcUnit = row.FracProcUnitStcUnPrc;                     // �P���[�������P��
                unPrcInfoConf.UnPrcFracProcDiv = row.FracProcStckUnPrc;                         // �P���[�������敪
                unPrcInfoConf.StdUnitPrice = row.StdUnPrcStckUnPrc;                             // ��P��
                unPrcInfoConf.UnitPriceTaxExcFl = row.StockUnitPriceFl;                         // �P���i�Ŕ��C�����j
                unPrcInfoConf.UnitPriceTaxIncFl = row.StockUnitTaxPriceFl;                      // �P���i�ō��C�����j
                unPrcInfoConf.ListPriceTaxIncFl = row.ListPriceTaxIncFl;                        // �艿�i�ō��C�����j
                unPrcInfoConf.ListPriceTaxExcFl = row.ListPriceTaxExcFl;                        // �艿�i�Ŕ��C�����j
                //unPrcInfoConf.SalesUnitCostTaxIncFl = row.SalesUnitCostTaxIncFl;              // �����P���i�ō��C�����j
                //unPrcInfoConf.SalesUnitCostTaxExcFl = row.SalesUnitCostTaxExcFl;              // �����P���i�Ŕ��C�����j
                unPrcInfoConf.TaxationDivCd = row.TaxationCode;                                 // �ېŋ敪
                unPrcInfoConf.TaxFractionProcUnit = taxFracProcUnit;                            // ����Œ[�������P��
                unPrcInfoConf.TaxFractionProcCd = taxFracProcCd;                                // ����Œ[�������敪
                unPrcInfoConf.TaxRate = this._stockSlip.SupplierConsTaxRate;                    // �ŗ�
                unPrcInfoConf.TotalAmountDispWayCd = this._stockSlip.SuppTtlAmntDspWayCd;       // ���z�\�����@�敪
                unPrcInfoConf.TtlAmntDspRateDivCd = this._stockSlip.TtlAmntDispRateApy;         // ���z�\���|���K�p�敪

			}

			return unPrcInfoConf;
		}
		
        # endregion

        // ===================================================================================== //
        // �X�^�e�B�b�N���\�b�h
        // ===================================================================================== //
        # region ��Static Method
        /// <summary>
        /// �\���p�d���`�[�敪�����A�f�[�^�p�̎d���`�[�敪�A���|�敪���Z�b�g���܂�
        /// </summary>
        /// <param name="stockSlip">�d���I�u�W�F�N�g</param>
        static public void SetSlipCdAndAccPayDivCdFromDisplay( ref StockSlip stockSlip )
        {
            int supplierSlipCd;
            int accPayDivCd;

            GetSlipCdAndAccPayDivCdFromSupplierSlipDisplay(stockSlip.SupplierSlipDisplay, out supplierSlipCd, out accPayDivCd);

            stockSlip.SupplierSlipCd = supplierSlipCd;
            stockSlip.AccPayDivCd = accPayDivCd;
        }

        /// <summary>
        /// �艿�����X�V�敪�̐ݒ�
        /// </summary>
        /// <param name="stockSlip"></param>
        /// <param name="priceCostUpdtDiv"></param>
        static public void SetPriceCostUpdtDiv(ref StockSlip stockSlip, int priceCostUpdtDiv)
        {
            if (priceCostUpdtDiv == 0)
            {
                stockSlip.PriceCostUpdtDiv = 0;
            }
            else
            {
                // �d���A���`�A���i�敪�u���i�v�̏ꍇ
                if (( stockSlip.SupplierSlipCd == 10 ) && ( stockSlip.DebitNoteDiv == 0 ) && ( stockSlip.StockGoodsCd == 0 ))
                {
                    // �������X�V�̏ꍇ�͍X�V����ɐݒ�
                    if (priceCostUpdtDiv == 1)
                    {
                        stockSlip.PriceCostUpdtDiv = 1;
                    }
                }
                // ��L�����ȊO
                else
                {
                    // �X�V���Ȃ�
                    stockSlip.PriceCostUpdtDiv = 0;
                }
            }
        }

        /// <summary>
        /// �艿�����X�V�敪�̕ύX��
        /// </summary>
        /// <param name="stockSlip">�d���f�[�^</param>
        /// <param name="priceCostUpdtDiv">�艿�����X�V�敪(�d���݌ɑS�̐ݒ�}�X�^�j</param>
        static public bool CanChangePriceCostUpdtDiv(StockSlip stockSlip, int priceCostUpdtDiv)
        {
            bool canChange = false;

            // �m�F�X�V�̏ꍇ�̂�
            if (priceCostUpdtDiv == 2)
            {
                // �d���A���`�A���i�敪�u���i�v�̏ꍇ
                if (( stockSlip.SupplierSlipCd == 10 ) && ( stockSlip.DebitNoteDiv == 0 ) && ( stockSlip.StockGoodsCd == 0 ))
                {
                    canChange = true;
                }
            }

            return canChange;
        }

        /// <summary>
        /// �\���p�d���`�[�敪���A�d���`�[�敪�A���|�敪���擾���܂��B
        /// </summary>
        /// <param name="supplierSlipDisplay">�\���p�d���`�[�敪</param>
        /// <param name="supplierSlipCd">�d���`�[�敪</param>
        /// <param name="accPayDivCd">���|�敪</param>
        static public void GetSlipCdAndAccPayDivCdFromSupplierSlipDisplay( int supplierSlipDisplay, out int supplierSlipCd, out int accPayDivCd )
        {
            // �����l�͊|�d��
            supplierSlipCd = 10;
            accPayDivCd = 1;
            switch (supplierSlipDisplay)
            {
                case 10:                                    // �|�d��
                    {
                        supplierSlipCd = 10;
                        accPayDivCd = 1;
                        break;
                    }
                case 20:                                    // �|�ԕi
                    {
                        supplierSlipCd = 20;
                        accPayDivCd = 1;
                        break;
                    }
                case 30:                                    // �����d��
                    {
                        supplierSlipCd = 10;
                        accPayDivCd = 0;
                        break;
                    }
                case 40:                                    // �����ԕi
                    {
                        supplierSlipCd = 20;
                        accPayDivCd = 0;
                        break;
                    }
            }
        }

        /// <summary>
        /// �f�[�^�̎d���`�[�敪�A���|�敪���A�\���p�d���`�[�敪���Z�b�g���܂��B
        /// </summary>
        /// <param name="stockSlip">�d���I�u�W�F�N�g</param>
        static public void SetDisplayFromSlipCdAndAccPayDivCd( ref StockSlip stockSlip )
        {
            stockSlip.SupplierSlipDisplay = GetSupplierSlipDisplayFromSlipCdAndAccPayDivCd(stockSlip.SupplierSlipCd, stockSlip.AccPayDivCd);
        }

        /// <summary>
        /// �d���`�[�敪�A���|�敪���A�\���p�d���`�[�敪���܂��B
        /// </summary>
        /// <param name="supplierSlipCd">�d���`�[�敪</param>
        /// <param name="accPayDivCd">���|�敪</param>
        /// <returns>�\���p�d���`�[�敪</returns>
        static public int GetSupplierSlipDisplayFromSlipCdAndAccPayDivCd( int supplierSlipCd, int accPayDivCd )
        {
            int value = 0;
            switch (supplierSlipCd)
            {
                case 10:
                    {
                        value = 10;
                        break;
                    }
                case 20:
                    {
                        value = 20;
                        break;
                    }
            }
            switch (accPayDivCd)
            {
                case 0:
                    {
                        value += 20;
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
            return value;
		}

		#region �������v�Z�֘A
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
			// ��{�I�ɑΏۓ����v����œ�������
			addUpADate = targetDate;
			delayPaymentDiv = 0;

			// �����A��������J�n�����ݒ肳��Ă��Ȃ��ꍇ�͂��̂܂܏I��
			if (( totalDay == 0 ) || ( nTimeCalcStDate == 0 ) || ( targetDate == DateTime.MinValue ))
			{
				return;
			}

			DateTime thisTimeAddUpDate = StockSlipInputAcs.GetNextTotalDate(0, targetDate, totalDay);
			// ���������̏ꍇ�́A���񐿋����̗������v���
			DateTime nextTimeAddUpDate = thisTimeAddUpDate.AddDays(1);


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

        #endregion

        // ===================================================================================== //
		// �v���C�x�[�g���\�b�h
		// ===================================================================================== //
		# region ��Private Methods

        /// <summary>
        /// IOWriter����I�v�V�������[�N�擾����
        /// </summary>
        /// <returns></returns>
        private IOWriteCtrlOptWork GetIOWriteCtrlOptWork()
        {
            IOWriteCtrlOptWork iOWriteCtrlOptWork = new IOWriteCtrlOptWork();

            iOWriteCtrlOptWork.CtrlStartingPoint = (int)IOWriteCtrlOptCtrlStartingPoint.Purchase;							// ����N�_�F�d��
            if (this._stockSlipInputInitDataAcs.GetSalesTtlSt() != null)
            {
                iOWriteCtrlOptWork.ShipmAddUpRemDiv = this._stockSlipInputInitDataAcs.GetSalesTtlSt().ShipmAddUpRemDiv;			// �o�׃f�[�^�v��c�敪(����S�̐ݒ�}�X�^���)
            }

            if (this._stockSlipInputInitDataAcs.GetSalesTtlSt() != null)
            {
                iOWriteCtrlOptWork.AcpOdrrAddUpRemDiv = this._stockSlipInputInitDataAcs.GetSalesTtlSt().AcpOdrrAddUpRemDiv;		// �󒍃f�[�^�v��c�敪(����S�̐ݒ�}�X�^���)
            }

            // �c���Ǘ��敪�́u����v�Œ�
            iOWriteCtrlOptWork.RemainCntMngDiv = 0;
            //if (this._stockSlipInputInitDataAcs.GetAllDefSet() != null)
            //{
            //    iOWriteCtrlOptWork.RemainCntMngDiv = this._stockSlipInputInitDataAcs.GetAllDefSet().RemainCntMngDiv;			// �c���Ǘ��敪(�S�̏����l�ݒ���)
            //}

            return iOWriteCtrlOptWork;
        }


		/// <summary>
		/// �d�������g�p���Ē艿����d���P�����Z�o���܂��B
		/// </summary>
		/// <param name="row"></param>
        /// <param name="unitPriceTaxExc"></param>
        /// <param name="unitPriceTaxInc"></param>
        /// <param name="unitPriceDisplay"></param>
        /// <param name="fracProcUnitStcUnPrc"></param>
		/// <param name="fracProcStckUnPrc"></param>
        private void CalculateStockUnitPriceByRate( StockInputDataSet.StockDetailRow row, out double unitPriceTaxExc, out double unitPriceTaxInc, out double unitPriceDisplay, ref double fracProcUnitStcUnPrc, ref int fracProcStckUnPrc )
		{
            if (this._supplierAcs == null) this._supplierAcs = new SupplierAcs();
			int stockUnPrcFrcProcCd = this._supplierAcs.GetStockFractionProcCd(this._enterpriseCode, this._stockSlip.SupplierCd, SupplierAcs.StockFracProcMoneyDiv.UnPrcFrcProcCd);	// �d���P���[�������R�[�h
			int stockTaxFrcProcCd = this._supplierAcs.GetStockFractionProcCd(this._enterpriseCode, this._stockSlip.SupplierCd, SupplierAcs.StockFracProcMoneyDiv.CnsTaxFrcProcCd);		// �d������Œ[�������R�[�h

            double stdPrice = ( ( row.TaxationCode == (int)CalculateTax.TaxationCode.TaxInc ) && ( ( this._stockSlip.SuppCTaxLayCd != 9 ) ) ) ? row.ListPriceTaxIncFl : row.ListPriceTaxExcFl;

            this.CalculateStockUnitPriceByRate(
                stdPrice,
                row.StockRate,
                row.TaxationCode,
                this._stockSlip.SuppTtlAmntDspWayCd,
                this._stockSlip.TtlAmntDispRateApy,
                this._stockSlip.SuppCTaxLayCd,
                this._stockSlip.SupplierConsTaxRate,
                stockUnPrcFrcProcCd,
                stockTaxFrcProcCd,
                out unitPriceTaxExc,
                out unitPriceTaxInc,
                out unitPriceDisplay,
                ref fracProcUnitStcUnPrc,
                ref fracProcStckUnPrc);
		}

        /// <summary>
        /// �d�������g�p���Ē艿����d���P�����Z�o���܂��B�i�I�[�o�[���[�h�j
        /// </summary>
        /// <param name="listPrice">�艿</param>
        /// <param name="stockRate">�d����</param>
        /// <param name="taxationCode">�ېŋ敪</param>
        /// <param name="totalAmountDispWayCd">���z�\���敪</param>
        /// <param name="ttlAmntDspRateDivCd">���z�\���|���K�p�敪</param>
        /// <param name="suppCTaxLayCd">�d�������œ]�ŕ����R�[�h</param>
        /// <param name="taxRate">�ŗ�</param>
        /// <param name="stockUnPrcFrcProcCd">�P���[�������R�[�h</param>
        /// <param name="stockTaxFrcProcCd">����Œ[�������R�[�h</param>
        /// <param name="unitPriceTaxExc">�Ŕ��P��</param>
        /// <param name="unitPriceTaxInc">�ō��P��</param>
        /// <param name="unitPriceDisplay">�\���P��</param>
        /// <param name="fracProcUnitStcUnPrc">�[�������P��</param>
        /// <param name="fracProcStckUnPrc">�[�������敪</param>
        private void CalculateStockUnitPriceByRate(double listPrice, double stockRate, int taxationCode, int totalAmountDispWayCd, int ttlAmntDspRateDivCd, int suppCTaxLayCd, double taxRate, int stockUnPrcFrcProcCd, int stockTaxFrcProcCd, out double unitPriceTaxExc, out double unitPriceTaxInc, out double unitPriceDisplay, ref double fracProcUnitStcUnPrc, ref int fracProcStckUnPrc)
        {
			int taxFracProcCd = 0;
			double taxFracProcUnit = 0;
            this._stockSlipInputInitDataAcs.GetStockFractionProcInfo(StockSlipInputInitDataAcs.ctFracProcMoneyDiv_Tax, stockTaxFrcProcCd, 0, out taxFracProcUnit, out taxFracProcCd);

            // �]�ŕ����u��ېŁv���͋����I�ɔ�ېŌv�Z����
            if (suppCTaxLayCd == 9) taxationCode = (int)CalculateTax.TaxationCode.TaxNone;

            this._unitPriceCalculation.CalculateUnitPriceByRate(
                UnitPriceCalculation.UnitPriceKind.UnitCost,
                UnitPriceCalculation.UnitPrcCalcDiv.RateVal,
                totalAmountDispWayCd,
                ttlAmntDspRateDivCd,
                stockUnPrcFrcProcCd,
                taxationCode,
                listPrice,
                taxRate,
                taxFracProcUnit,
                taxFracProcCd,
                stockRate,
                ref fracProcUnitStcUnPrc,
                ref fracProcStckUnPrc,
                out unitPriceTaxExc,
                out unitPriceTaxInc);


            // �u���z�\������v���A�u���ŏ��i�v�̏ꍇ�͐ō��ݒP����\���P���ɐݒ�
            if (( totalAmountDispWayCd == 1 ) || ( taxationCode == (int)CalculateTax.TaxationCode.TaxInc ))
            {
                unitPriceDisplay = unitPriceTaxInc;
            }
            else
            {
                unitPriceDisplay = unitPriceTaxExc;
            }
        }

		/// <summary>
		/// �w�肵�����i���i�������ɁA�d�����׃f�[�^�s�I�u�W�F�N�g�ɒ艿��ݒ肵�܂��B
		/// </summary>
		/// <param name="row">�d�����׍s�I�u�W�F�N�g</param>
		/// <param name="goodsUnitData">���i���i���X�g</param>
		private void StockDetailRowListPriceSetting( StockInputDataSet.StockDetailRow row, GoodsUnitData goodsUnitData )
		{
			int taxationCode = row.TaxationCode;

			double listPrice = 0;
			bool getListPrice = false;

            //// �|���Z�o�����ꍇ�A����i���ݒ肳��Ă���ꍇ�͊�P�����艿�ƂȂ�
            //if (( !string.IsNullOrEmpty(row.RateDivStckUnPrc.Trim()) ) || ( row.StdUnPrcStckUnPrc != 0 ) || ( row.UnPrcCalcCdStckUnPrc > 0 ))
            //{
            //    listPrice = row.StdUnPrcStckUnPrc;	// �|���Z�o�����ꍇ�͊���i���艿
            //    getListPrice = true;
            //}
            // ���i���X�g���艿��\������
            if (( goodsUnitData != null ) && ( !string.IsNullOrEmpty(goodsUnitData.GoodsNo) ))// && ( row.StockRate == 0 ))
            {
                DateTime targetDate = ( this._stockSlip.SupplierFormal == 1 ) ? this._stockSlip.ArrivalGoodsDay : this._stockSlip.StockDate;
                GoodsPrice goodsPrice = this._stockSlipInputInitDataAcs.GetGoodsPrice(targetDate, goodsUnitData);

                if (goodsPrice != null)
                {
                    listPrice = goodsPrice.ListPrice;
                    row.OpenPriceDiv = goodsPrice.OpenPriceDiv;

                    getListPrice = true;
                }
            }

            if (getListPrice)
            {
                if (listPrice != 0)
                {
                    if (this._supplierAcs == null) this._supplierAcs = new SupplierAcs();
                    int stockTaxFrcProcCd = this._supplierAcs.GetStockFractionProcCd(this._enterpriseCode, this._stockSlip.SupplierCd, SupplierAcs.StockFracProcMoneyDiv.CnsTaxFrcProcCd);		// �d������Œ[�������R�[�h
                    int taxFracProcCd = 0;
                    double taxFracProcUnit = 0;
                    this._stockSlipInputInitDataAcs.GetStockFractionProcInfo(StockSlipInputInitDataAcs.ctFracProcMoneyDiv_Tax, stockTaxFrcProcCd, 0, out taxFracProcUnit, out taxFracProcCd);

                    // �Ŕ������i�A�ō��݉��i�̌v�Z
                    // ���i���i�ېŋ敪�u���Łv
                    if (taxationCode == (int)CalculateTax.TaxationCode.TaxInc)
                    {
                        row.ListPriceTaxIncFl = listPrice;
                        row.ListPriceTaxExcFl = listPrice - CalculateTax.GetTaxFromPriceInc(this._stockSlip.SupplierConsTaxRate, taxFracProcUnit, taxFracProcCd, listPrice);
                    }
                    // ���i���i�ېŋ敪�u�O�Łv
                    else if (taxationCode == (int)CalculateTax.TaxationCode.TaxExc)
                    {
                        row.ListPriceTaxIncFl = listPrice + CalculateTax.GetTaxFromPriceExc(this._stockSlip.SupplierConsTaxRate, taxFracProcUnit, taxFracProcCd, listPrice);
                        row.ListPriceTaxExcFl = listPrice;
                    }
                    // ���i���i�ېŋ敪�u��ېŁv
                    else if (taxationCode == (int)CalculateTax.TaxationCode.TaxNone)
                    {
                        row.ListPriceTaxExcFl = listPrice;
                        row.ListPriceTaxIncFl = listPrice;
                    }

                    // �A�\���艿�̌���
                    // ��ې�
                    if (this._stockSlip.SuppCTaxLayCd == 9)
                    {
                        // �ō��ݒ艿���Ŕ����艿
                        row.ListPriceTaxIncFl = row.ListPriceTaxExcFl;
                        row.ListPriceDisplay = row.ListPriceTaxExcFl;
                    }
                    // ���z�\�����Ȃ�
                    else if (this._stockSlip.SuppTtlAmntDspWayCd == 0)
                    {
                        // ���ŏ��i�͐ō��݉��i��\�����A����ȊO�͐Ŕ������i��\������
                        row.ListPriceDisplay = ( taxationCode == (int)CalculateTax.TaxationCode.TaxInc ) ? row.ListPriceTaxIncFl : row.ListPriceTaxExcFl;
                    }
                    // ���z�\������
                    else
                    {
                        // �ō��݉��i��\��
                        row.ListPriceDisplay = row.ListPriceTaxIncFl;
                    }
                }
                else
                {
                    row.ListPriceDisplay = 0;
                    row.ListPriceTaxExcFl = 0;
                    row.ListPriceTaxIncFl = 0;
                }
                row.BfListPrice = row.ListPriceTaxExcFl;
            }
            else
            {
                row.BfListPrice = 0;
            }
        }

        /// <summary>
        /// �Ώۉ��i����A�Ŕ����z�A�ō����z�A�\�����z���v�Z���܂�
        /// </summary>
        /// <param name="priceInputType">���i���̓��[�h</param>
        /// <param name="unitPrice">�Ώۉ��i</param>
        /// <param name="taxationCode">�ېŋ敪</param>
        /// <param name="totalAmountDispWayCd">���z�\���敪</param>
        /// <param name="suppCTaxLayCd">�d�������œ]�ŕ����R�[�h</param>
        /// <param name="taxRate">�ŗ�</param>
        /// <param name="stockTaxFrcProcCd">�d������Œ[�������R�[�h</param>
        /// <param name="unitPriceTaxExc">�Ŕ����z</param>
        /// <param name="unitPriceTaxInc">�ō����z</param>
        /// <param name="unitPriceDisplay">�\�����z</param>
        private void CalculatePrice(PriceInputType priceInputType, double unitPrice, int taxationCode, int totalAmountDispWayCd, int suppCTaxLayCd, double taxRate, int stockTaxFrcProcCd, out  double unitPriceTaxExc, out  double unitPriceTaxInc, out  double unitPriceDisplay)
        {
            unitPriceTaxExc = 0;
            unitPriceTaxInc = 0;
            unitPriceDisplay = 0;

            if (unitPrice == 0) return;

            int taxFracProcCd = 0;
            double taxFracProcUnit = 0;
            this._stockSlipInputInitDataAcs.GetStockFractionProcInfo(StockSlipInputInitDataAcs.ctFracProcMoneyDiv_Tax, stockTaxFrcProcCd, 0, out taxFracProcUnit, out taxFracProcCd);

            // ���̓^�C�v
            switch (priceInputType)
            {
                // �Ŕ������i
                case PriceInputType.PriceTaxExc:
                    {
                        if (( taxationCode == (int)CalculateTax.TaxationCode.TaxNone ) || ( suppCTaxLayCd == 9 ))
                        {
                            unitPriceTaxExc = unitPrice;
                            unitPriceTaxInc = unitPrice;
                        }
                        else
                        {
                            unitPriceTaxExc = unitPrice;
                            unitPriceTaxInc = unitPrice + CalculateTax.GetTaxFromPriceExc(taxRate, taxFracProcUnit, taxFracProcCd, unitPrice);
                        }

                        break;
                    }
                // �ō��݉��i
                case PriceInputType.PriceTaxInc:
                    {
                        if (( taxationCode == (int)CalculateTax.TaxationCode.TaxNone ) || ( suppCTaxLayCd == 9 ))
                        {
                            unitPriceTaxExc = unitPrice;
                            unitPriceTaxInc = unitPrice;
                        }
                        else
                        {
                            unitPriceTaxExc = unitPrice - CalculateTax.GetTaxFromPriceInc(taxRate, taxFracProcUnit, taxFracProcCd, unitPrice);
                            unitPriceTaxInc = unitPrice;
                        }

                        break;
                    }
                // �\�����i
                case PriceInputType.PriceDisplay:
                    {
                        if (suppCTaxLayCd == 9)
                        {
                            unitPriceTaxExc = unitPrice;
                            unitPriceTaxInc = unitPrice;
                        }
                        // ���z�\�����Ȃ�
                        else if (totalAmountDispWayCd == 0)
                        {
                            // �ېŋ敪���u�ېŁi���Łj�v�̏ꍇ
                            if (taxationCode == (int)CalculateTax.TaxationCode.TaxInc)
                            {
                                unitPriceTaxExc = unitPrice - CalculateTax.GetTaxFromPriceInc(taxRate, taxFracProcUnit, taxFracProcCd, unitPrice);
                                unitPriceTaxInc = unitPrice;
                            }
                            // �ېŋ敪���u�ېŁv�̏ꍇ
                            else if (taxationCode == (int)CalculateTax.TaxationCode.TaxExc)
                            {
                                unitPriceTaxExc = unitPrice;
                                unitPriceTaxInc = unitPrice + CalculateTax.GetTaxFromPriceExc(taxRate, taxFracProcUnit, taxFracProcCd, unitPrice);
                            }
                            // �ېŋ敪���u��ېŁv�̏ꍇ
                            else
                            {
                                unitPriceTaxExc = unitPrice;
                                unitPriceTaxInc = unitPrice;
                            }
                        }
                        // ���z�\������
                        else
                        {
                            // �ېŋ敪���u�ېŁi���Łj�v�̏ꍇ
                            if (taxationCode == (int)CalculateTax.TaxationCode.TaxInc)
                            {
                                unitPriceTaxExc = unitPrice - CalculateTax.GetTaxFromPriceInc(taxRate, taxFracProcUnit, taxFracProcCd, unitPrice);
                                unitPriceTaxInc = unitPrice;
                            }
                            // �ېŋ敪���u�ېŁv�̏ꍇ
                            else if (taxationCode == (int)CalculateTax.TaxationCode.TaxExc)
                            {
                                unitPriceTaxExc = unitPrice - CalculateTax.GetTaxFromPriceInc(taxRate, taxFracProcUnit, taxFracProcCd, unitPrice);
                                unitPriceTaxInc = unitPrice;
                            }
                            // �ېŋ敪���u��ېŁv�̏ꍇ
                            else
                            {
                                unitPriceTaxExc = unitPrice;
                                unitPriceTaxInc = unitPrice;
                            }
                        }
                        break;
                    }
            }

            // ��ېł̎d����͐Ŕ������z��\������
            if (suppCTaxLayCd == 9)
            {
                unitPriceDisplay = unitPriceTaxExc;
            }
            // ���z�\�������ł͐ō��݋��z��\������
            else if (( totalAmountDispWayCd == 1 ) || ( taxationCode == (int)CalculateTax.TaxationCode.TaxInc ))
            {
                unitPriceDisplay = unitPriceTaxInc;
            }
            else
            {
                unitPriceDisplay = unitPriceTaxExc;
            }
        }

        /// <summary>
        /// �P���Z�o���ʁA���i�A���f�[�^���A�����P���A�艿��ݒ肵�܂��B
        /// </summary>
        /// <param name="row">�d�����׍s�I�u�W�F�N�g</param>
        /// <param name="goodsUnitData">���i�A���f�[�^�I�u�W�F�N�g</param>
        /// <param name="unitPriceCalcRet">�P���Z�o���ʃI�u�W�F�N�g</param>
        private void StockDetailRowGoodsPriceSettingFromUnitPriceCalcRet( StockInputDataSet.StockDetailRow row, GoodsUnitData goodsUnitData, UnitPriceCalcRet unitPriceCalcRet )
        {
            this.ClearStockDetailRateInfo(row, true);

            if (unitPriceCalcRet != null)
            {
                row.RateSectStckUnPrc = unitPriceCalcRet.SectionCode.Trim();	// �|���ݒ苒�_�i�d���P���j
                row.RateDivStckUnPrc = unitPriceCalcRet.RateSettingDivide;		// �|���ݒ�敪�i�d���P���j
                row.UnPrcCalcCdStckUnPrc = unitPriceCalcRet.UnitPrcCalcDiv;		// �P���Z�o�敪�i�d���P���j
                row.StdUnPrcStckUnPrc = unitPriceCalcRet.StdUnitPrice;			// ��P���i�d���P���j
                row.FracProcUnitStcUnPrc = unitPriceCalcRet.UnPrcFracProcUnit;	// �P���[�������P��
                row.FracProcStckUnPrc = unitPriceCalcRet.UnPrcFracProcDiv;		// �[�������i�d���P���j
                row.PriceCdStckUnPrc = unitPriceCalcRet.PriceDiv;				// ���i�敪
                row.StockRate = unitPriceCalcRet.RateVal;						// �d����
                row.StdUnPrcStckUnPrc = unitPriceCalcRet.StdUnitPrice;			// ��P���i�d���P���j
                row.StockUnitPriceFl = unitPriceCalcRet.UnitPriceTaxExcFl;		// �d���P���i�Ŕ��C�����j
                row.StockUnitTaxPriceFl = unitPriceCalcRet.UnitPriceTaxIncFl;	// �d���P���i�ō��C�����j
                row.BfStockUnitPriceFl = unitPriceCalcRet.UnitPriceTaxExcFl;    // �ύX�O�P���i�Ŕ����j
                row.StockUnitChngDiv = 0;										// �d���P���ύX�敪

                // ��ېŕi�͐Ŕ����P����\��
                if (this._stockSlip.SuppCTaxLayCd == 9)
                {
                    row.StockUnitPriceDisplay = row.StockUnitPriceFl;
                }
                else if (this._stockSlip.SuppTtlAmntDspWayCd == 0)
                {
                    // ���i���i�ېŋ敪�u���Łv
                    if (row.TaxationCode == (int)CalculateTax.TaxationCode.TaxInc)
                    {
                        row.StockUnitPriceDisplay = row.StockUnitTaxPriceFl;
                    }
                    else if (row.TaxationCode == (int)CalculateTax.TaxationCode.TaxExc)
                    {
                        row.StockUnitPriceDisplay = row.StockUnitPriceFl;
                    }
                    else if (row.TaxationCode == (int)CalculateTax.TaxationCode.TaxNone)
                    {
                        row.StockUnitPriceDisplay = row.StockUnitPriceFl;
                    }
                }
                else if (this._stockSlip.SuppTtlAmntDspWayCd == 1)
                {
                    // ���i���i�ېŋ敪�u���Łv
                    if (row.TaxationCode == (int)CalculateTax.TaxationCode.TaxInc)
                    {
                        row.StockUnitPriceDisplay = row.StockUnitTaxPriceFl;
                    }
                    else if (row.TaxationCode == (int)CalculateTax.TaxationCode.TaxExc)
                    {
                        row.StockUnitPriceDisplay = row.StockUnitTaxPriceFl;
                    }
                    else if (row.TaxationCode == (int)CalculateTax.TaxationCode.TaxNone)
                    {
                        row.StockUnitPriceDisplay = row.StockUnitTaxPriceFl;
                    }
                }
            }
            else
            {
            }
            this.StockDetailRowListPriceSetting(row, goodsUnitData);
        }

        /// <summary>
        /// �d�����ׂ̊|���Ɋ֘A���鍀�ڂ��N���A���܂��B
        /// </summary>
        /// <param name="row">�d�����׍s�I�u�W�F�N�g</param>
        /// <param name="claerBfStockUnitPrice">True;�ύX�O�����N���A����</param>
        private void ClearStockDetailRateInfo( StockInputDataSet.StockDetailRow row, bool claerBfStockUnitPrice )
        {
            row.RateSectStckUnPrc = string.Empty;           // �|���ݒ苒�_�i�d���P���j
            row.RateDivStckUnPrc = string.Empty;            // �|���ݒ�敪�i�d���P���j
            row.UnPrcCalcCdStckUnPrc = 0;                   // �P���Z�o�敪�i�d���P���j
            row.PriceCdStckUnPrc = 0;                       // ���i�敪
            row.StockRate = 0;                              // �d����
            row.FracProcUnitStcUnPrc = 0;                   // �P���[�������P��
            row.FracProcStckUnPrc = 0;                      // �[�������i�d���P���j
            row.StdUnPrcStckUnPrc = 0;                      // ��P���i�d���P���j
            row.StockUnitPriceFl = 0;                       // �d���P���i�Ŕ��C�����j
            row.StockUnitTaxPriceFl = 0;                    // �d���P���i�ō��C�����j
            if (claerBfStockUnitPrice)
            {
                row.BfStockUnitPriceFl = 0;                     // �ύX�O�d���P���i�����j
            }

            row.StockUnitChngDiv = ( row.StockUnitPriceFl != row.BfStockUnitPriceFl ) ? 1 : 0; // �d���P���ύX�敪

        }

		/// <summary>
		/// �w�肵�����i���I�u�W�F�N�g�����ɒP���Z�o���i��菤�i���i���擾���A�d�����׃f�[�^�s�I�u�W�F�N�g�ɏ��i���i����ݒ肵�܂��B
		/// </summary>
		/// <param name="row">�d�����׍s�I�u�W�F�N�g</param>
		/// <param name="goodsUnitData">���i�A���f�[�^�I�u�W�F�N�g</param>
		private void StockDetailRowGoodsPriceSetting( StockInputDataSet.StockDetailRow row, GoodsUnitData goodsUnitData )
		{
            UnitPriceCalcRet unitPriceCalcRet = this.CalculateStockUnitPrice(this.CreateUnitPriceCalcParam(row, goodsUnitData), goodsUnitData);

            this.StockDetailRowGoodsPriceSettingFromUnitPriceCalcRet(row, goodsUnitData, unitPriceCalcRet);
		}

        /// <summary>
        /// �Ώۍs�̒P���Z�o�p�����[�^�𐶐����܂��B
        /// </summary>
        /// <param name="row">�d�����׍s�I�u�W�F�N�g</param>
        /// <param name="goodsUnitData">���i�A���f�[�^</param>
        /// <returns>�P���Z�o�p�����[�^</returns>
        private UnitPriceCalcParam CreateUnitPriceCalcParam( StockInputDataSet.StockDetailRow row, GoodsUnitData goodsUnitData )
        {
            if (this._supplierAcs == null) this._supplierAcs = new SupplierAcs();
            int stockUnPrcFrcProcCd = this._supplierAcs.GetStockFractionProcCd(this._enterpriseCode, this._stockSlip.SupplierCd, SupplierAcs.StockFracProcMoneyDiv.UnPrcFrcProcCd);		// �d���P���[�������R�[�h
            int stockcnsTaxFrcProcCd = this._supplierAcs.GetStockFractionProcCd(this._enterpriseCode, this._stockSlip.SupplierCd, SupplierAcs.StockFracProcMoneyDiv.CnsTaxFrcProcCd);	// �d������Œ[�������R�[�h

            UnitPriceCalcParam unitPriceCalcParam = new UnitPriceCalcParam();

            unitPriceCalcParam.SectionCode = this._stockSlip.StockSectionCd.Trim();                     // ���_�R�[�h
            unitPriceCalcParam.GoodsMakerCd = goodsUnitData.GoodsMakerCd;                               // ���i���[�J�[�R�[�h
            unitPriceCalcParam.GoodsNo = goodsUnitData.GoodsNo;                                         // ���i�ԍ�
            unitPriceCalcParam.GoodsRateRank = goodsUnitData.GoodsRateRank;                             // ���i�|�������N
            unitPriceCalcParam.GoodsRateGrpCode = goodsUnitData.GoodsRateGrpCode;                       // ���i�|���O���[�v�R�[�h
            unitPriceCalcParam.BLGroupCode = goodsUnitData.BLGroupCode;                                 // BL�O���[�v�R�[�h
            unitPriceCalcParam.BLGoodsCode = goodsUnitData.BLGoodsCode;                                 // BL���i�R�[�h
            unitPriceCalcParam.CustomerCode = row.SalesCustomerCode;                                    // ���Ӑ�R�[�h
            unitPriceCalcParam.CustRateGrpCode = row.CustRateGrpCode;                                   // ���Ӑ�|���O���[�v�R�[�h
            unitPriceCalcParam.SupplierCd = this._stockSlip.SupplierCd;                                 // �d����R�[�h
            unitPriceCalcParam.PriceApplyDate = ( this._stockSlip.SupplierFormal == 0 ) ? this._stockSlip.StockDate : this._stockSlip.ArrivalGoodsDay;  // ���i�K�p��
            unitPriceCalcParam.CountFl = Math.Abs(row.StockCountDisplay);                               // ����
            unitPriceCalcParam.TaxationDivCd = goodsUnitData.TaxationDivCd;                             // �ېŋ敪
            unitPriceCalcParam.TaxRate = this._stockSlip.SupplierConsTaxRate;                           // �ŗ�
            unitPriceCalcParam.StockCnsTaxFrcProcCd = stockcnsTaxFrcProcCd;                             // �d������Œ[�������R�[�h
            unitPriceCalcParam.TotalAmountDispWayCd = this._stockSlip.SuppTtlAmntDspWayCd;              // ���z�\�����@�敪
            unitPriceCalcParam.TtlAmntDspRateDivCd = this._stockSlip.TtlAmntDispRateApy;                // ���z�\���|���K�p�敪
            unitPriceCalcParam.StockUnPrcFrcProcCd = stockUnPrcFrcProcCd;                               // �d���P���[�������R�[�h
            unitPriceCalcParam.ConsTaxLayMethod = this._stockSlip.SuppCTaxLayCd;                        // �d�������œ]�ŕ����R�[�h

            return unitPriceCalcParam;
        }

        /// <summary>
        /// �P���Z�o���W���[�����g�p���Ďd���P�����v�Z���܂��B
        /// </summary>
        /// <param name="unitPriceCalcParam">�P���Z�o�p�����[�^</param>
        /// <param name="goodsUnitData">���i�A���f�[�^</param>
        /// <returns>�P���Z�o����</returns>
        private UnitPriceCalcRet CalculateStockUnitPrice( UnitPriceCalcParam unitPriceCalcParam, GoodsUnitData goodsUnitData )
        {
            List<UnitPriceCalcParam> unitPriceCalcParamList = new List<UnitPriceCalcParam>();
            unitPriceCalcParamList.Add(unitPriceCalcParam);
            List<GoodsUnitData> goodsUnitDataList = new List<GoodsUnitData>();
            goodsUnitDataList.Add(goodsUnitData);

            List<UnitPriceCalcRet> unitPriceCalcRetList = this.CalculateStockUnitPrice(unitPriceCalcParamList, goodsUnitDataList);

            if (( unitPriceCalcRetList != null ) && ( unitPriceCalcRetList.Count > 0 ))
            {
                foreach (UnitPriceCalcRet unitPriceCalcRet in unitPriceCalcRetList)
                {
                    if (( goodsUnitData.GoodsNo == unitPriceCalcRet.GoodsNo ) &&
                        ( goodsUnitData.GoodsMakerCd == unitPriceCalcRet.GoodsMakerCd ))
                    {
                        return unitPriceCalcRet;
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// �P���Z�o���W���[�����g�p���Ďd���P�����v�Z���܂��B
        /// </summary>
        /// <param name="unitPriceCalcParamList">�P���Z�o�p�����[�^���X�g</param>
        /// <param name="goodsUnitDataList">���i�A���f�[�^���X�g</param>
        /// <returns>�P���Z�o���ʃ��X�g</returns>
        private List<UnitPriceCalcRet> CalculateStockUnitPrice( List<UnitPriceCalcParam> unitPriceCalcParamList, List<GoodsUnitData> goodsUnitDataList )
        {
            List<UnitPriceCalcRet> returnUnitPriceCalcRetList = new List<UnitPriceCalcRet>();

            List<UnitPriceCalcRet> unitPriceCalcRetList;

            this._unitPriceCalculation.CalculateUnitCost(unitPriceCalcParamList, goodsUnitDataList, out unitPriceCalcRetList);

            foreach (UnitPriceCalcRet unitPriceCalcRetWk in unitPriceCalcRetList)
            {
                if (unitPriceCalcRetWk.UnitPriceKind == UnitPriceCalculation.ctUnitPriceKind_UnitCost)
                {
                    returnUnitPriceCalcRetList.Add(unitPriceCalcRetWk);
                }
            }
            return returnUnitPriceCalcRetList;
        }

		/// <summary>
		/// �d�����׍s�I�u�W�F�N�g�̃R�s�[���s���܂��B
		/// </summary>
		/// <param name="sourceRow">�R�s�[���d�����׍s�I�u�W�F�N�g</param>
		/// <param name="targetRow">�R�s�[��d�����׍s�I�u�W�F�N�g</param>
		private void CopyStockDetailRow(StockInputDataSet.StockDetailRow sourceRow, StockInputDataSet.StockDetailRow targetRow)
		{
			if ((sourceRow == null) || (targetRow == null)) return;

			#region �����ڃZ�b�g

            //targetRow.CreateDateTime = sourceRow.CreateDateTime;                    // �쐬����
            //targetRow.UpdateDateTime = sourceRow.UpdateDateTime;                    // �X�V����
            //targetRow.EnterpriseCode = sourceRow.EnterpriseCode;                    // ��ƃR�[�h
            //targetRow.FileHeaderGuid = sourceRow.FileHeaderGuid;                    // GUID
            //targetRow.UpdEmployeeCode = sourceRow.UpdEmployeeCode;                  // �X�V�]�ƈ��R�[�h
            //targetRow.UpdAssemblyId1 = sourceRow.UpdAssemblyId1;                    // �X�V�A�Z���u��ID1
            //targetRow.UpdAssemblyId2 = sourceRow.UpdAssemblyId2;                    // �X�V�A�Z���u��ID2
            //targetRow.LogicalDeleteCode = sourceRow.LogicalDeleteCode;              // �_���폜�敪
            targetRow.AcceptAnOrderNo = sourceRow.AcceptAnOrderNo;                  // �󒍔ԍ�
            targetRow.SupplierFormal = sourceRow.SupplierFormal;                    // �d���`��
            targetRow.SupplierSlipNo = sourceRow.SupplierSlipNo;                    // �d���`�[�ԍ�
            //targetRow.StockRowNo = sourceRow.StockRowNo;                            // �d���s�ԍ�
            //targetRow.SectionCode = sourceRow.SectionCode;                          // ���_�R�[�h
            //targetRow.SubSectionCode = sourceRow.SubSectionCode;                    // ����R�[�h
            targetRow.CommonSeqNo = sourceRow.CommonSeqNo;                          // ���ʒʔ�
            targetRow.StockSlipDtlNum = sourceRow.StockSlipDtlNum;                  // �d�����גʔ�
            targetRow.SupplierFormalSrc = sourceRow.SupplierFormalSrc;              // �d���`���i���j
            targetRow.StockSlipDtlNumSrc = sourceRow.StockSlipDtlNumSrc;            // �d�����גʔԁi���j
            targetRow.AcptAnOdrStatusSync = sourceRow.AcptAnOdrStatusSync;          // �󒍃X�e�[�^�X�i�����j
            targetRow.SalesSlipDtlNumSync = sourceRow.SalesSlipDtlNumSync;          // ���㖾�גʔԁi�����j
            targetRow.StockSlipCdDtl = sourceRow.StockSlipCdDtl;                    // �d���`�[�敪�i���ׁj
            //targetRow.StockInputCode = sourceRow.StockInputCode;                    // �d�����͎҃R�[�h
            //targetRow.StockInputName = sourceRow.StockInputName;                    // �d�����͎Җ���
            //targetRow.StockAgentCode = sourceRow.StockAgentCode;                    // �d���S���҃R�[�h
            //targetRow.StockAgentName = sourceRow.StockAgentName;                    // �d���S���Җ���
            targetRow.GoodsKindCode = sourceRow.GoodsKindCode;                      // ���i����
            targetRow.GoodsMakerCd = sourceRow.GoodsMakerCd;                        // ���i���[�J�[�R�[�h
            targetRow.MakerName = sourceRow.MakerName;                              // ���[�J�[����
            targetRow.MakerKanaName = sourceRow.MakerKanaName;                      // ���[�J�[�J�i����
            targetRow.CmpltMakerKanaName = sourceRow.CmpltMakerKanaName;            // ���[�J�[�J�i���́i�ꎮ�j
            targetRow.GoodsNo = sourceRow.GoodsNo;                                  // ���i�ԍ�
            targetRow.GoodsName = sourceRow.GoodsName;                              // ���i����
            targetRow.GoodsNameKana = sourceRow.GoodsNameKana;                      // ���i���̃J�i
            targetRow.GoodsLGroup = sourceRow.GoodsLGroup;                          // ���i�啪�ރR�[�h
            targetRow.GoodsLGroupName = sourceRow.GoodsLGroupName;                  // ���i�啪�ޖ���
            targetRow.GoodsMGroup = sourceRow.GoodsMGroup;                          // ���i�����ރR�[�h
            targetRow.GoodsMGroupName = sourceRow.GoodsMGroupName;                  // ���i�����ޖ���
            targetRow.BLGroupCode = sourceRow.BLGroupCode;                          // BL�O���[�v�R�[�h
            targetRow.BLGroupName = sourceRow.BLGroupName;                          // BL�O���[�v�R�[�h����
            targetRow.BLGoodsCode = sourceRow.BLGoodsCode;                          // BL���i�R�[�h
            targetRow.BLGoodsFullName = sourceRow.BLGoodsFullName;                  // BL���i�R�[�h���́i�S�p�j
            targetRow.EnterpriseGanreCode = sourceRow.EnterpriseGanreCode;          // ���Е��ރR�[�h
            targetRow.EnterpriseGanreName = sourceRow.EnterpriseGanreName;          // ���Е��ޖ���
            targetRow.WarehouseCode = sourceRow.WarehouseCode;                      // �q�ɃR�[�h
            targetRow.WarehouseName = sourceRow.WarehouseName;                      // �q�ɖ���
            targetRow.WarehouseShelfNo = sourceRow.WarehouseShelfNo;                // �q�ɒI��
            targetRow.StockOrderDivCd = sourceRow.StockOrderDivCd;                  // �d���݌Ɏ�񂹋敪
            targetRow.OpenPriceDiv = sourceRow.OpenPriceDiv;                        // �I�[�v�����i�敪
            targetRow.GoodsRateRank = sourceRow.GoodsRateRank;                      // ���i�|�������N
            targetRow.CustRateGrpCode = sourceRow.CustRateGrpCode;                  // ���Ӑ�|���O���[�v�R�[�h
            targetRow.SuppRateGrpCode = sourceRow.SuppRateGrpCode;                  // �d����|���O���[�v�R�[�h
            targetRow.ListPriceTaxExcFl = sourceRow.ListPriceTaxExcFl;              // �艿�i�Ŕ��C�����j
            targetRow.ListPriceTaxIncFl = sourceRow.ListPriceTaxIncFl;              // �艿�i�ō��C�����j
            targetRow.StockRate = sourceRow.StockRate;                              // �d����
            targetRow.RateSectStckUnPrc = sourceRow.RateSectStckUnPrc;              // �|���ݒ苒�_�i�d���P���j
            targetRow.RateDivStckUnPrc = sourceRow.RateDivStckUnPrc;                // �|���ݒ�敪�i�d���P���j
            targetRow.UnPrcCalcCdStckUnPrc = sourceRow.UnPrcCalcCdStckUnPrc;        // �P���Z�o�敪�i�d���P���j
            targetRow.PriceCdStckUnPrc = sourceRow.PriceCdStckUnPrc;                // ���i�敪�i�d���P���j
            targetRow.StdUnPrcStckUnPrc = sourceRow.StdUnPrcStckUnPrc;              // ��P���i�d���P���j
            targetRow.FracProcUnitStcUnPrc = sourceRow.FracProcUnitStcUnPrc;        // �[�������P�ʁi�d���P���j
            targetRow.FracProcStckUnPrc = sourceRow.FracProcStckUnPrc;              // �[�������i�d���P���j
            targetRow.StockUnitPriceFl = sourceRow.StockUnitPriceFl;                // �d���P���i�Ŕ��C�����j
            targetRow.StockUnitTaxPriceFl = sourceRow.StockUnitTaxPriceFl;          // �d���P���i�ō��C�����j
            targetRow.StockUnitChngDiv = sourceRow.StockUnitChngDiv;                // �d���P���ύX�敪
            targetRow.BfStockUnitPriceFl = sourceRow.BfStockUnitPriceFl;            // �ύX�O�d���P���i�����j
            targetRow.BfListPrice = sourceRow.BfListPrice;                          // �ύX�O�艿
            targetRow.RateBLGoodsCode = sourceRow.RateBLGoodsCode;                  // BL���i�R�[�h�i�|���j
            targetRow.RateBLGoodsName = sourceRow.RateBLGoodsName;                  // BL���i�R�[�h���́i�|���j
            targetRow.RateGoodsRateGrpCd = sourceRow.RateGoodsRateGrpCd;            // ���i�|���O���[�v�R�[�h�i�|���j
            targetRow.RateGoodsRateGrpNm = sourceRow.RateGoodsRateGrpNm;            // ���i�|���O���[�v���́i�|���j
            targetRow.RateBLGroupCode = sourceRow.RateBLGroupCode;                  // BL�O���[�v�R�[�h�i�|���j
            targetRow.RateBLGroupName = sourceRow.RateBLGroupName;                  // BL�O���[�v���́i�|���j
            targetRow.StockCount = sourceRow.StockCount;                            // �d����
            targetRow.OrderCnt = sourceRow.OrderCnt;                                // ��������
            targetRow.OrderAdjustCnt = sourceRow.OrderAdjustCnt;                    // ����������
            targetRow.OrderRemainCnt = sourceRow.OrderRemainCnt;                    // �����c��
            targetRow.RemainCntUpdDate = sourceRow.RemainCntUpdDate;                // �c���X�V��
            targetRow.StockPriceTaxExc = sourceRow.StockPriceTaxExc;                // �d�����z�i�Ŕ����j
            targetRow.StockPriceTaxInc = sourceRow.StockPriceTaxInc;                // �d�����z�i�ō��݁j
            targetRow.StockGoodsCd = sourceRow.StockGoodsCd;                        // �d�����i�敪
            targetRow.StockPriceConsTax = sourceRow.StockPriceConsTax;              // �d�����z����Ŋz
            targetRow.TaxationCode = sourceRow.TaxationCode;                        // �ېŋ敪
            targetRow.StockDtiSlipNote1 = sourceRow.StockDtiSlipNote1;              // �d���`�[���ה��l1
            targetRow.SalesCustomerCode = sourceRow.SalesCustomerCode;              // �̔���R�[�h
            targetRow.SalesCustomerSnm = sourceRow.SalesCustomerSnm;                // �̔��旪��
            targetRow.SlipMemo1 = sourceRow.SlipMemo1;                              // �`�[�����P
            targetRow.SlipMemo2 = sourceRow.SlipMemo2;                              // �`�[�����Q
            targetRow.SlipMemo3 = sourceRow.SlipMemo3;                              // �`�[�����R
            targetRow.InsideMemo1 = sourceRow.InsideMemo1;                          // �Г������P
            targetRow.InsideMemo2 = sourceRow.InsideMemo2;                          // �Г������Q
            targetRow.InsideMemo3 = sourceRow.InsideMemo3;                          // �Г������R
            targetRow.SupplierCd = sourceRow.SupplierCd;                            // �d����R�[�h
            targetRow.SupplierSnm = sourceRow.SupplierSnm;                          // �d���旪��
            targetRow.AddresseeCode = sourceRow.AddresseeCode;                      // �[�i��R�[�h
            targetRow.AddresseeName = sourceRow.AddresseeName;                      // �[�i�於��
            targetRow.DirectSendingCd = sourceRow.DirectSendingCd;                  // �����敪
            targetRow.OrderNumber = sourceRow.OrderNumber;                          // �����ԍ�
            targetRow.WayToOrder = sourceRow.WayToOrder;                            // �������@
            targetRow.DeliGdsCmpltDueDate = sourceRow.DeliGdsCmpltDueDate;          // �[�i�����\���
            targetRow.ExpectDeliveryDate = sourceRow.ExpectDeliveryDate;            // ��]�[��
            targetRow.OrderDataCreateDiv = sourceRow.OrderDataCreateDiv;            // �����f�[�^�쐬�敪
            targetRow.OrderDataCreateDate = sourceRow.OrderDataCreateDate;          // �����f�[�^�쐬��
            targetRow.OrderFormIssuedDiv = sourceRow.OrderFormIssuedDiv;            // ���������s�ϋ敪
            targetRow.DtlRelationGuid = sourceRow.DtlRelationGuid;                  // ���׊֘A�t��GUID
            targetRow.GoodsOfferDate = sourceRow.GoodsOfferDate;                    // ���i�񋟓��t
            targetRow.PriceStartDate = sourceRow.PriceStartDate;                    // ���i�J�n���t
            targetRow.PriceOfferDate = sourceRow.PriceOfferDate;                    // ���i�񋟓��t

            targetRow.ShipmentPosCnt = sourceRow.ShipmentPosCnt;
            targetRow.ShipmentPosCntDisplay = sourceRow.ShipmentPosCntDisplay;
            targetRow.ListPriceDisplay = sourceRow.ListPriceDisplay;
            targetRow.StockUnitPriceDisplay = sourceRow.StockUnitPriceDisplay;
            targetRow.StockCountMin = sourceRow.StockCountMin;
            targetRow.StockCountDefault = sourceRow.StockCountDefault;
            targetRow.StockCountDisplay = sourceRow.StockCountDisplay;
            targetRow.StockCountMax = sourceRow.StockCountMax;
            targetRow.StockPriceDisplay = sourceRow.StockPriceDisplay;
            targetRow.TaxDiv = sourceRow.TaxDiv;
            targetRow.CanTaxDivChange = sourceRow.CanTaxDivChange;
            targetRow.StockPriceDiectInput = sourceRow.StockPriceDiectInput;


            targetRow.EditStatus = sourceRow.EditStatus;
            targetRow.RowStatus = ctROWSTATUS_NORMAL;

			#endregion
		}

		/// <summary>
		/// �c�a����ǂݍ��񂾎d���f�[�^�I�u�W�F�N�g���C���X�^���X�ϐ��ɃL���b�V�����܂��B
		/// </summary>
		/// <param name="source">�d���f�[�^�I�u�W�F�N�g</param>
		private void CacheDBData(StockSlip source)
		{
			this._stockSlipDBData = source.Clone();
		}

		/// <summary>
		/// �d�����ׁA�v�㌳�d�����ׁA����f�[�^(�d�������v��)�e�[�u�����N���A���܂��B
		/// </summary>
		private void ClearDetailTables()
		{
			this._stockDetailDataTable.Rows.Clear();
			this._salesTempDataTable.Rows.Clear();
			this._addUpSrcSalesSlipDataTable.Rows.Clear();
			this._addUpSrcSalesDetailDataTable.Rows.Clear();
			this._addUpSrcDetailDataTable.Rows.Clear();
			this._stockInfoDataTable.Rows.Clear();
            this.ClearGoodsCacheInfo();
		}

		/// <summary>
		/// �d�����׃f�[�^�ƌv�㌳�d�����׃f�[�^���e�f�[�^�e�[�u���ɃL���b�V�����܂��B
		/// </summary>
		/// <param name="stockSlip">�d���f�[�^�I�u�W�F�N�g</param>
		/// <param name="baseStockSlip">�������d���f�[�^�I�u�W�F�N�g</param>
		/// <param name="stockDetailList">�d�����׃f�[�^�I�u�W�F�N�g���X�g</param>
		/// <param name="addUpSrcDetailList">�v�㌳�d�����׃f�[�^�I�u�W�F�N�g���X�g</param>
		/// <param name="stockDetailDataTable">�d�����׃f�[�^�e�[�u���I�u�W�F�N�g</param>
		private void CacheStockDetail( StockSlip stockSlip, StockSlip baseStockSlip, List<StockDetail> stockDetailList, List<StockDetail> addUpSrcDetailList, StockInputDataSet.StockDetailDataTable stockDetailDataTable )
		{
			if (addUpSrcDetailList != null)
			{
				// �v�㌳�d�����׃f�[�^���L���b�V��
				foreach (StockDetail stockDetail in addUpSrcDetailList)
				{
					this.CacheAddUpSrcStockDetailDataTable(stockDetail, this._addUpSrcDetailDataTable);
				}
			}

			// �d�����׃f�[�^���L���b�V��
			foreach (StockDetail stockDetail in stockDetailList)
			{
				this.CacheStockDetailDataTable(stockSlip, stockDetail, stockDetailDataTable);
			}

			// �d�����׍s�I�u�W�F�N�g�̓��׎c���̒l��ݒ肷��B
			this.StockDetailRowAddUpEnableCountSetting();

            stockDetailDataTable.AcceptChanges();
		}

		/// <summary>
		/// �c�a����擾�����d�����׃f�[�^���f�[�^�e�[�u���ɃL���b�V�����܂��B
		/// </summary>
		/// <param name="stockDetailList">�d�����׃f�[�^�I�u�W�F�N�g���X�g</param>
		private void CacheStockDetailDBData(List<StockDetail> stockDetailList)
		{
			this._stockDetailDBDataList.Clear();

			foreach (StockDetail stockDetail in stockDetailList)
			{
				this._stockDetailDBDataList.Add(stockDetail.Clone());
			}
		}

		/// <summary>
		/// �c�a����擾�����d���f�[�^�𒲐����܂��B
		/// </summary>
		/// <param name="stockSlip">�d���f�[�^�I�u�W�F�N�g</param>
		/// <param name="stockDetailList">�d�����׃f�[�^�I�u�W�F�N�g���X�g</param>
		private void AdjustStockReadDBData( ref StockSlip stockSlip, ref List<StockDetail> stockDetailList)
        {
            #region �d������̒���

            // �d���悩��̏��𒲐�
            Supplier supplier;
            if (this._supplierAcs == null) this._supplierAcs = new SupplierAcs();
            int status = this._supplierAcs.Read(out supplier, stockSlip.EnterpriseCode, stockSlip.SupplierCd);

            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                return;
            }

            // �x����̏��𒲐�
            status = this._supplierAcs.Read(out supplier, stockSlip.EnterpriseCode, stockSlip.PayeeCode);

            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                return;
            }

            stockSlip.PayeeName = supplier.SupplierNm1;
            stockSlip.PayeeName2 = supplier.SupplierNm2;
            stockSlip.PaymentTotalDay = supplier.PaymentTotalDay;
            stockSlip.NTimeCalcStDate = supplier.NTimeCalcStDate;
            // 2009.05.12 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //stockSlip.SuppCTaxLayCd = (supplier.SuppCTaxLayRefCd == 1) ? supplier.SuppCTaxLayCd : this._stockSlipInputInitDataAcs.GetTaxRateSet().ConsTaxLayMethod; // 2009.03.25
            if (this._stockSlipInputInitDataAcs.GetTaxRateSet() == null)
            {
                stockSlip.SuppCTaxLayCd = supplier.SuppCTaxLayCd;
            }
            else
            {
                stockSlip.SuppCTaxLayCd = (supplier.SuppCTaxLayRefCd == 1) ? supplier.SuppCTaxLayCd : this._stockSlipInputInitDataAcs.GetTaxRateSet().ConsTaxLayMethod; // 2009.03.25
            }
            // 2009.05.12 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

            #endregion

            #region ���_���̒���

            SecInfoSet secInfoSet = this._stockSlipInputInitDataAcs.GetSecInfo(stockSlip.StockSectionCd);
            if (secInfoSet != null)
            {
                stockSlip.StockSectionNm = secInfoSet.SectionGuideNm;
            }

            if (stockSlip.SubSectionCode != 0)
            {
                stockSlip.SubSectionName = this._stockSlipInputInitDataAcs.GetName_FromSubSection(stockSlip.SubSectionCode);
            }

            #endregion
        }

        /// <summary>
        /// �c�a�ɏ������񂾎d���f�[�^�𒲐����܂��B
        /// </summary>
        /// <param name="stockSlip">�d���f�[�^�I�u�W�F�N�g</param>
        /// <param name="stockDetailList">�d�����׃f�[�^�I�u�W�F�N�g���X�g</param>
        private void AdjustStockSaveDBData(ref StockSlip stockSlip, ref List<StockDetail> stockDetailList)
        {
            #region ���_���̒���

            SecInfoSet secInfoSet = this._stockSlipInputInitDataAcs.GetSecInfo(stockSlip.StockSectionCd);
            if (secInfoSet != null)
            {
                stockSlip.StockSectionNm = secInfoSet.SectionGuideNm;
            }

            if (stockSlip.SubSectionCode != 0)
            {
                stockSlip.SubSectionName = this._stockSlipInputInitDataAcs.GetName_FromSubSection(stockSlip.SubSectionCode);
            }
            #endregion
        }

		/// <summary>
		/// �d�����׃f�[�^�I�u�W�F�N�g���f�[�^�e�[�u���ɃL���b�V�����܂��B
		/// </summary>
		/// <param name="stockSlip">�d���f�[�^�I�u�W�F�N�g</param>
		/// <param name="stockDetail">�d�����׃f�[�^�I�u�W�F�N�g</param>
		/// <param name="stockDetailDataTable">�d�����׃f�[�^�e�[�u���I�u�W�F�N�g</param>
		private void CacheStockDetailDataTable( StockSlip stockSlip, StockDetail stockDetail, StockInputDataSet.StockDetailDataTable stockDetailDataTable )
		{
			try
			{
				stockDetailDataTable.AddStockDetailRow(this.CreateRowFromUIData(stockSlip, stockDetail, stockDetailDataTable));
			}
			catch (ConstraintException)
			{
				StockInputDataSet.StockDetailRow row = stockDetailDataTable.FindBySupplierSlipNoStockRowNo(stockDetail.SupplierSlipNo, stockDetail.StockRowNo);
				this.SetRowFromUIData(ref row, stockSlip, stockDetail);
			}
		}

		/// <summary>
		/// �d�����׃f�[�^�e�[�u���𐶐����A�f�[�^���L���b�V�����܂��B
		/// </summary>
		/// <param name="stockSlip">�d���f�[�^�I�u�W�F�N�g</param>
		/// <param name="stockDetailList">�d�����׃f�[�^�I�u�W�F�N�g���X�g</param>
		/// <param name="addUpSrcDetailList">�v�㌳�d�����׃f�[�^�I�u�W�F�N�g���X�g</param>
		private StockInputDataSet.StockDetailDataTable CreateStockDetailDataTable( StockSlip stockSlip, List<StockDetail> stockDetailList, List<StockDetail> addUpSrcDetailList )
		{
			StockInputDataSet.StockDetailDataTable stockDetailDataTable = new StockInputDataSet.StockDetailDataTable();
			this.CacheStockDetail(stockSlip, stockSlip, stockDetailList, addUpSrcDetailList, stockDetailDataTable);
			return stockDetailDataTable;
		}

		/// <summary>
		/// �d�����׃f�[�^�I�u�W�F�N�g����d�����׃f�[�^�s�I�u�W�F�N�g�ɍ��ڂ�ݒ肵�܂��B
		/// </summary>
		/// <param name="row">�d�����׃f�[�^�s�I�u�W�F�N�g</param>
		/// <param name="stockSlip">�d���f�[�^�I�u�W�F�N�g</param>
		/// <param name="stockDetail">�d�����׃f�[�^�I�u�W�F�N�g</param>
		private void SetRowFromUIData( ref StockInputDataSet.StockDetailRow row, StockSlip stockSlip, StockDetail stockDetail )
		{
			#region �����ڃZ�b�g�i���̂܂܃Z�b�g���鍀�ځj

            //row.CreateDateTime = stockDetail.CreateDateTime;                    // �쐬����
            //row.UpdateDateTime = stockDetail.UpdateDateTime;                    // �X�V����
            //row.EnterpriseCode = stockDetail.EnterpriseCode;                    // ��ƃR�[�h
            //row.FileHeaderGuid = stockDetail.FileHeaderGuid;                    // GUID
            //row.UpdEmployeeCode = stockDetail.UpdEmployeeCode;                  // �X�V�]�ƈ��R�[�h
            //row.UpdAssemblyId1 = stockDetail.UpdAssemblyId1;                    // �X�V�A�Z���u��ID1
            //row.UpdAssemblyId2 = stockDetail.UpdAssemblyId2;                    // �X�V�A�Z���u��ID2
            //row.LogicalDeleteCode = stockDetail.LogicalDeleteCode;              // �_���폜�敪
            row.AcceptAnOrderNo = stockDetail.AcceptAnOrderNo;                  // �󒍔ԍ�
            row.SupplierFormal = stockDetail.SupplierFormal;                    // �d���`��
            row.SupplierSlipNo = stockDetail.SupplierSlipNo;                    // �d���`�[�ԍ�
            row.StockRowNo = stockDetail.StockRowNo;                            // �d���s�ԍ�
            //row.SectionCode = stockDetail.SectionCode;                          // ���_�R�[�h
            //row.SubSectionCode = stockDetail.SubSectionCode;                    // ����R�[�h
            row.CommonSeqNo = stockDetail.CommonSeqNo;                          // ���ʒʔ�
            row.StockSlipDtlNum = stockDetail.StockSlipDtlNum;                  // �d�����גʔ�
            row.SupplierFormalSrc = stockDetail.SupplierFormalSrc;              // �d���`���i���j
            row.StockSlipDtlNumSrc = stockDetail.StockSlipDtlNumSrc;            // �d�����גʔԁi���j
            row.AcptAnOdrStatusSync = stockDetail.AcptAnOdrStatusSync;          // �󒍃X�e�[�^�X�i�����j
            row.SalesSlipDtlNumSync = stockDetail.SalesSlipDtlNumSync;          // ���㖾�גʔԁi�����j
            row.StockSlipCdDtl = stockDetail.StockSlipCdDtl;                    // �d���`�[�敪�i���ׁj
            //row.StockInputCode = stockDetail.StockInputCode;                    // �d�����͎҃R�[�h
            //row.StockInputName = stockDetail.StockInputName;                    // �d�����͎Җ���
            //row.StockAgentCode = stockDetail.StockAgentCode;                    // �d���S���҃R�[�h
            //row.StockAgentName = stockDetail.StockAgentName;                    // �d���S���Җ���
            row.GoodsKindCode = stockDetail.GoodsKindCode;                      // ���i����
            row.GoodsMakerCd = stockDetail.GoodsMakerCd;                        // ���i���[�J�[�R�[�h
            row.MakerName = stockDetail.MakerName;                              // ���[�J�[����
            row.MakerKanaName = stockDetail.MakerKanaName;                      // ���[�J�[�J�i����
            row.CmpltMakerKanaName = stockDetail.CmpltMakerKanaName;            // ���[�J�[�J�i���́i�ꎮ�j
            row.GoodsNo = stockDetail.GoodsNo;                                  // ���i�ԍ�
            row.GoodsName = stockDetail.GoodsName;                              // ���i����
            row.GoodsNameKana = stockDetail.GoodsNameKana;                      // ���i���̃J�i
            row.GoodsLGroup = stockDetail.GoodsLGroup;                          // ���i�啪�ރR�[�h
            row.GoodsLGroupName = stockDetail.GoodsLGroupName;                  // ���i�啪�ޖ���
            row.GoodsMGroup = stockDetail.GoodsMGroup;                          // ���i�����ރR�[�h
            row.GoodsMGroupName = stockDetail.GoodsMGroupName;                  // ���i�����ޖ���
            row.BLGroupCode = stockDetail.BLGroupCode;                          // BL�O���[�v�R�[�h
            row.BLGroupName = stockDetail.BLGroupName;                          // BL�O���[�v�R�[�h����
            row.BLGoodsCode = stockDetail.BLGoodsCode;                          // BL���i�R�[�h
            row.BLGoodsFullName = stockDetail.BLGoodsFullName;                  // BL���i�R�[�h���́i�S�p�j
            row.EnterpriseGanreCode = stockDetail.EnterpriseGanreCode;          // ���Е��ރR�[�h
            row.EnterpriseGanreName = stockDetail.EnterpriseGanreName;          // ���Е��ޖ���
            row.WarehouseCode = stockDetail.WarehouseCode;                      // �q�ɃR�[�h
            row.WarehouseName = stockDetail.WarehouseName;                      // �q�ɖ���
            row.WarehouseShelfNo = stockDetail.WarehouseShelfNo;                // �q�ɒI��
            row.StockOrderDivCd = stockDetail.StockOrderDivCd;                  // �d���݌Ɏ�񂹋敪
            row.OpenPriceDiv = stockDetail.OpenPriceDiv;                        // �I�[�v�����i�敪
            row.GoodsRateRank = stockDetail.GoodsRateRank;                      // ���i�|�������N
            row.CustRateGrpCode = stockDetail.CustRateGrpCode;                  // ���Ӑ�|���O���[�v�R�[�h
            row.SuppRateGrpCode = stockDetail.SuppRateGrpCode;                  // �d����|���O���[�v�R�[�h
            row.ListPriceTaxExcFl = stockDetail.ListPriceTaxExcFl;              // �艿�i�Ŕ��C�����j
            row.ListPriceTaxIncFl = stockDetail.ListPriceTaxIncFl;              // �艿�i�ō��C�����j
            row.StockRate = stockDetail.StockRate;                              // �d����
            row.RateSectStckUnPrc = stockDetail.RateSectStckUnPrc;              // �|���ݒ苒�_�i�d���P���j
            row.RateDivStckUnPrc = stockDetail.RateDivStckUnPrc;                // �|���ݒ�敪�i�d���P���j
            row.UnPrcCalcCdStckUnPrc = stockDetail.UnPrcCalcCdStckUnPrc;        // �P���Z�o�敪�i�d���P���j
            row.PriceCdStckUnPrc = stockDetail.PriceCdStckUnPrc;                // ���i�敪�i�d���P���j
            row.StdUnPrcStckUnPrc = stockDetail.StdUnPrcStckUnPrc;              // ��P���i�d���P���j
            row.FracProcUnitStcUnPrc = stockDetail.FracProcUnitStcUnPrc;        // �[�������P�ʁi�d���P���j
            row.FracProcStckUnPrc = stockDetail.FracProcStckUnPrc;              // �[�������i�d���P���j
            row.StockUnitPriceFl = stockDetail.StockUnitPriceFl;                // �d���P���i�Ŕ��C�����j
            row.StockUnitTaxPriceFl = stockDetail.StockUnitTaxPriceFl;          // �d���P���i�ō��C�����j
            row.StockUnitChngDiv = stockDetail.StockUnitChngDiv;                // �d���P���ύX�敪
            row.BfStockUnitPriceFl = stockDetail.BfStockUnitPriceFl;            // �ύX�O�d���P���i�����j
            row.BfListPrice = stockDetail.BfListPrice;                          // �ύX�O�艿
            row.RateBLGoodsCode = stockDetail.RateBLGoodsCode;                  // BL���i�R�[�h�i�|���j
            row.RateBLGoodsName = stockDetail.RateBLGoodsName;                  // BL���i�R�[�h���́i�|���j
            row.RateGoodsRateGrpCd = stockDetail.RateGoodsRateGrpCd;            // ���i�|���O���[�v�R�[�h�i�|���j
            row.RateGoodsRateGrpNm = stockDetail.RateGoodsRateGrpNm;            // ���i�|���O���[�v���́i�|���j
            row.RateBLGroupCode = stockDetail.RateBLGroupCode;                  // BL�O���[�v�R�[�h�i�|���j
            row.RateBLGroupName = stockDetail.RateBLGroupName;                  // BL�O���[�v���́i�|���j
            row.StockCount = stockDetail.StockCount;                            // �d����
            row.OrderCnt = stockDetail.OrderCnt;                                // ��������
            row.OrderAdjustCnt = stockDetail.OrderAdjustCnt;                    // ����������
            row.OrderRemainCnt = stockDetail.OrderRemainCnt;                    // �����c��
            row.RemainCntUpdDate = stockDetail.RemainCntUpdDate;                // �c���X�V��
            row.StockPriceTaxExc = stockDetail.StockPriceTaxExc;                // �d�����z�i�Ŕ����j
            row.StockPriceTaxInc = stockDetail.StockPriceTaxInc;                // �d�����z�i�ō��݁j
            row.StockGoodsCd = stockDetail.StockGoodsCd;                        // �d�����i�敪
            row.StockPriceConsTax = stockDetail.StockPriceConsTax;              // �d�����z����Ŋz
            row.TaxationCode = stockDetail.TaxationCode;                        // �ېŋ敪
            row.StockDtiSlipNote1 = stockDetail.StockDtiSlipNote1;              // �d���`�[���ה��l1
            row.SalesCustomerCode = stockDetail.SalesCustomerCode;              // �̔���R�[�h
            row.SalesCustomerSnm = stockDetail.SalesCustomerSnm;                // �̔��旪��
            row.SlipMemo1 = stockDetail.SlipMemo1;                              // �`�[�����P
            row.SlipMemo2 = stockDetail.SlipMemo2;                              // �`�[�����Q
            row.SlipMemo3 = stockDetail.SlipMemo3;                              // �`�[�����R
            row.InsideMemo1 = stockDetail.InsideMemo1;                          // �Г������P
            row.InsideMemo2 = stockDetail.InsideMemo2;                          // �Г������Q
            row.InsideMemo3 = stockDetail.InsideMemo3;                          // �Г������R
            row.SupplierCd = stockDetail.SupplierCd;                            // �d����R�[�h
            row.SupplierSnm = stockDetail.SupplierSnm;                          // �d���旪��
            row.AddresseeCode = stockDetail.AddresseeCode;                      // �[�i��R�[�h
            row.AddresseeName = stockDetail.AddresseeName;                      // �[�i�於��
            row.DirectSendingCd = stockDetail.DirectSendingCd;                  // �����敪
            row.OrderNumber = stockDetail.OrderNumber;                          // �����ԍ�
            row.WayToOrder = stockDetail.WayToOrder;                            // �������@
            row.DeliGdsCmpltDueDate = stockDetail.DeliGdsCmpltDueDate;          // �[�i�����\���
            row.ExpectDeliveryDate = stockDetail.ExpectDeliveryDate;            // ��]�[��
            row.OrderDataCreateDiv = stockDetail.OrderDataCreateDiv;            // �����f�[�^�쐬�敪
            row.OrderDataCreateDate = stockDetail.OrderDataCreateDate;          // �����f�[�^�쐬��
            row.OrderFormIssuedDiv = stockDetail.OrderFormIssuedDiv;            // ���������s�ϋ敪
            //row.DtlRelationGuid = stockDetail.DtlRelationGuid;                  // ���׊֘A�t��GUID
            row.GoodsOfferDate = stockDetail.GoodsOfferDate;                    // ���i�񋟓��t
            row.PriceStartDate = stockDetail.PriceStartDate;                    // ���i�J�n���t
            row.PriceOfferDate = stockDetail.PriceOfferDate;                    // ���i�񋟓��t

			#endregion

			row.DtlRelationGuid = Guid.Empty;								// ���׊֘A�t��GUID

			int sign = ( stockSlip.SupplierSlipCd == 20 ) ? -1 : 1;

            row.StockCountDisplay = row.StockCount * sign;                  // ����(�\��)

			// �l�����s�̏ꍇ�͍s�X�e�[�^�X��ύX����
            if (stockDetail.StockSlipCdDtl == 2)
            {
                row.EditStatus = ( stockDetail.StockCount == 0 ) ? ctEDITSTATUS_RowDiscount : ctEDITSTATUS_GoodsDiscount;
            }
			// �v�㌳���גʔԂ������Ă��Ďd���`�����v�㌳�ƈقȂ�ꍇ�͌v�㖾��
			else if (( stockDetail.StockSlipDtlNumSrc != 0 ) && ( stockDetail.SupplierFormalSrc != stockDetail.SupplierFormal ))
			{
                if (stockDetail.StockSlipDtlNum != 0)
                {
                    row.EditStatus = ctEDITSTATUS_ArrivalAddUpEdit;
                }
                else
                {
                    row.EditStatus = ctEDITSTATUS_ArrivalAddUpNew;
                }
			}
			else
			{
				row.EditStatus = ctEDITSTATUS_AllOK;
			}
            row.RowStatus = ctROWSTATUS_NORMAL;

			//---<< �d���P���A�艿�i�\���p�j�̃Z�b�g >>---//
            if (stockSlip.SuppCTaxLayCd == 9)
            {
                row.StockUnitPriceDisplay = stockDetail.StockUnitPriceFl;
                row.ListPriceDisplay = stockDetail.ListPriceTaxExcFl;
            }
			// ���z�\�����Ȃ�
			else if (stockSlip.SuppTtlAmntDspWayCd == 0)
			{
				switch (stockDetail.TaxationCode)
				{
					// �ې�
					case (int)CalculateTax.TaxationCode.TaxExc:
						row.StockUnitPriceDisplay = stockDetail.StockUnitPriceFl;
						row.ListPriceDisplay = stockDetail.ListPriceTaxExcFl;
						break;
					// ��ې�
					case (int)CalculateTax.TaxationCode.TaxNone:
						row.StockUnitPriceDisplay = stockDetail.StockUnitPriceFl;
						row.ListPriceDisplay = stockDetail.ListPriceTaxExcFl;
						break;
					// �ېŁi���Łj
					case (int)CalculateTax.TaxationCode.TaxInc:
						row.StockUnitPriceDisplay = stockDetail.StockUnitTaxPriceFl;
						row.ListPriceDisplay = stockDetail.ListPriceTaxIncFl;
						break;
				}
			}
			// ���z�\������
			else
			{
				row.StockUnitPriceDisplay = stockDetail.StockUnitTaxPriceFl;
				row.ListPriceDisplay = stockDetail.ListPriceTaxIncFl;
			}


			//---<< �d�����z�i�\���p�j�̃Z�b�g >>---//
			switch (stockDetail.StockGoodsCd)
			{
				// ���i�A���i�O�A���v����
				case 0:
				case 1:
                case 6:
				{
                    // �]�ŕ����F��ې�
                    if (stockSlip.SuppCTaxLayCd == 9)
                    {
                        row.StockPriceDisplay = stockDetail.StockPriceTaxExc * sign;
                    }
					// ���z�\�����Ȃ�
					else if (stockSlip.SuppTtlAmntDspWayCd == 0)
					{
						switch (stockDetail.TaxationCode)
						{
							case (int)CalculateTax.TaxationCode.TaxExc:
								row.StockPriceDisplay = stockDetail.StockPriceTaxExc * sign;
								break;
							case (int)CalculateTax.TaxationCode.TaxNone:
								row.StockPriceDisplay = stockDetail.StockPriceTaxExc * sign;
								break;
							case (int)CalculateTax.TaxationCode.TaxInc:
								row.StockPriceDisplay = stockDetail.StockPriceTaxInc * sign;
								break;
						}
					}
					// ���z�\������
					else
					{
						row.StockPriceDisplay = stockDetail.StockPriceTaxInc * sign;
					}
					break;
				}
				// ����Œ���
				case 2:
				case 4:
				{
					row.StockPriceDisplay = row.StockPriceConsTax * sign;
					break;
				}
				// �c������
				case 3:
				case 5:
				{
					row.StockPriceDisplay = stockDetail.StockPriceTaxInc * sign;
					break;
				}
			}

			row.TaxDiv = stockDetail.TaxationCode;

			row.StockCountDefault = row.StockCount;

            // ���z���ړ��͋敪
            row.StockPriceDiectInput = ( ( row.StockUnitPriceDisplay == 0 ) && ( row.StockPriceDisplay != 0 ) );

            // �P���A���z�̏����l
            row.StockUnitPriceDefault = row.StockUnitPriceFl;
            row.StockUnitTaxPriceDefault = row.StockUnitTaxPriceFl;
            row.StockPriceTaxExcDefault = row.StockPriceTaxExc;
            row.StockPriceTaxIncDefault = row.StockPriceTaxInc;

			// �ېŔ�ېŋ敪�ύX�\�t���O
			if (stockDetail.StockGoodsCd == 1)
			{
				row.CanTaxDivChange = true;
			}
			else
			{
				row.CanTaxDivChange = false;
			}
		}

		/// <summary>
		/// �d�����׃f�[�^�e�[�u�����d�����׃f�[�^�I�u�W�F�N�g���X�g���擾���܂��B
		/// </summary>
		/// <param name="stockDetailDataTable">�d�����׃f�[�^�e�[�u���I�u�W�F�N�g</param>
		/// <param name="stockDetailList">�d�����׃f�[�^�I�u�W�F�N�g���X�g</param>
		/// <param name="salesTempList">��������f�[�^�I�u�W�F�N�g���X�g</param>
		/// <param name="savedSalesTempList">�ۑ��ςݔ���f�[�^(�d�������v��)�I�u�W�F�N�g���X�g</param>
		private void GetUIDataFromTable( StockInputDataSet.StockDetailDataTable stockDetailDataTable, out List<StockDetail> stockDetailList, out List<SalesTemp> salesTempList, out List<SalesTemp> savedSalesTempList )
		{
			stockDetailList = new List<StockDetail>();
			salesTempList = new List<SalesTemp>();
			savedSalesTempList = new List<SalesTemp>();

			foreach (StockInputDataSet.StockDetailRow row in stockDetailDataTable)
			{
				StockDetail stockDetail;

				// ���׃f�[�^�擾
				GetUIDataFromRow(row, out stockDetail);

				if (stockDetail != null)
				{
					// �l�����ȊO�ŁA����������͍ς�
					if (( stockDetail.StockSlipCdDtl != 2 ) &&
						( ( row.DtlRelationGuid != null ) && ( row.DtlRelationGuid != Guid.Empty ) ))
					{
						StockInputDataSet.SalesTempRow salesTempRow = this.GetSalesTempRow(row);

						if (salesTempRow != null)
						{
							// ���Ӑ���͍ς�
							if (salesTempRow.CustomerCode != 0)
							{
								SalesTemp salesTemp = this.GetUIDataFromRow(stockDetail, salesTempRow);
								if (salesTemp != null)
								{
									// �����ɍ쐬���锄������d�����ׂɃZ�b�g
									// �V�K���͂̏ꍇ�͓o�^�p���X�g�ɒǉ�
									if (( stockDetail.AcptAnOdrStatusSync == 0 ) && ( stockDetail.SalesSlipDtlNumSync == 0 ))
									{
										stockDetail.AcptAnOdrStatusSync = salesTemp.AcptAnOdrStatus;
										stockDetail.SalesSlipDtlNumSync = salesTemp.SalesSlipDtlNum;

										salesTempList.Add(salesTemp);
									}
									else
									{
										savedSalesTempList.Add(salesTemp);
									}
								}
							}
						}
					}
					stockDetailList.Add(stockDetail);
				}
			}
		}

		/// <summary>
		/// �d�����׃f�[�^�s�I�u�W�F�N�g���A�d�����׃f�[�^�I�u�W�F�N�g���擾���܂��B
		/// </summary>
		/// <param name="row">�d�����׃f�[�^�s�I�u�W�F�N�g</param>
		/// <param name="stockDetail">�d�����׃f�[�^�I�u�W�F�N�g</param>
		private void GetUIDataFromRow( StockInputDataSet.StockDetailRow row, out StockDetail stockDetail )
		{
			stockDetail = GetUIDataFromRow(row);
		}

		/// <summary>
		/// �d�����׃f�[�^�s�I�u�W�F�N�g���d�����׃f�[�^�I�u�W�F�N�g���擾���܂��B
		/// </summary>
		/// <param name="row">�d�����׃f�[�^�s�I�u�W�F�N�g</param>
		/// <returns>�d�����׃f�[�^�I�u�W�F�N�g</returns>
		private StockDetail GetUIDataFromRow(StockInputDataSet.StockDetailRow row)
		{

			StockDetail stockDetail = new StockDetail();


            // �d���f�[�^���
			stockDetail.SectionCode = this._stockSlip.SectionCode;			// ���_�R�[�h
			stockDetail.SubSectionCode = this._stockSlip.SubSectionCode;	// ����R�[�h
			stockDetail.SupplierFormal = this._stockSlip.SupplierFormal;	// �d���`��
			stockDetail.SupplierSlipNo = this._stockSlip.SupplierSlipNo;	// �d���`�[�ԍ�
			stockDetail.StockGoodsCd = this._stockSlip.StockGoodsCd;		// �d�����i�敪
			stockDetail.StockInputCode = this._stockSlip.StockInputCode;	// �d�����͎҃R�[�h
			stockDetail.StockInputName = this._stockSlip.StockInputName;	// �d�����͎Җ���
			stockDetail.StockAgentCode = this._stockSlip.StockAgentCode;	// �d���S���҃R�[�h
			stockDetail.StockAgentName = this._stockSlip.StockAgentName;	// �d���S���Җ���

            // ��ʂ��
            //stockDetail.CreateDateTime = row.CreateDateTime;                    // �쐬����
            //stockDetail.UpdateDateTime = row.UpdateDateTime;                    // �X�V����
            //stockDetail.EnterpriseCode = row.EnterpriseCode;                    // ��ƃR�[�h
            //stockDetail.FileHeaderGuid = row.FileHeaderGuid;                    // GUID
            //stockDetail.UpdEmployeeCode = row.UpdEmployeeCode;                  // �X�V�]�ƈ��R�[�h
            //stockDetail.UpdAssemblyId1 = row.UpdAssemblyId1;                    // �X�V�A�Z���u��ID1
            //stockDetail.UpdAssemblyId2 = row.UpdAssemblyId2;                    // �X�V�A�Z���u��ID2
            //stockDetail.LogicalDeleteCode = row.LogicalDeleteCode;              // �_���폜�敪
            stockDetail.AcceptAnOrderNo = row.AcceptAnOrderNo;                  // �󒍔ԍ�
            stockDetail.SupplierFormal = row.SupplierFormal;                    // �d���`��
            stockDetail.SupplierSlipNo = row.SupplierSlipNo;                    // �d���`�[�ԍ�
            stockDetail.StockRowNo = row.StockRowNo;                            // �d���s�ԍ�
            stockDetail.SectionCode = row.SectionCode;                          // ���_�R�[�h
            stockDetail.SubSectionCode = row.SubSectionCode;                    // ����R�[�h
            stockDetail.CommonSeqNo = row.CommonSeqNo;                          // ���ʒʔ�
            stockDetail.StockSlipDtlNum = row.StockSlipDtlNum;                  // �d�����גʔ�
            stockDetail.SupplierFormalSrc = row.SupplierFormalSrc;              // �d���`���i���j
            stockDetail.StockSlipDtlNumSrc = row.StockSlipDtlNumSrc;            // �d�����גʔԁi���j
            stockDetail.AcptAnOdrStatusSync = row.AcptAnOdrStatusSync;          // �󒍃X�e�[�^�X�i�����j
            stockDetail.SalesSlipDtlNumSync = row.SalesSlipDtlNumSync;          // ���㖾�גʔԁi�����j
            stockDetail.StockSlipCdDtl = row.StockSlipCdDtl;                    // �d���`�[�敪�i���ׁj
            //stockDetail.StockInputCode = row.StockInputCode;                    // �d�����͎҃R�[�h
            //stockDetail.StockInputName = row.StockInputName;                    // �d�����͎Җ���
            //stockDetail.StockAgentCode = row.StockAgentCode;                    // �d���S���҃R�[�h
            //stockDetail.StockAgentName = row.StockAgentName;                    // �d���S���Җ���
            stockDetail.GoodsKindCode = row.GoodsKindCode;                      // ���i����
            stockDetail.GoodsMakerCd = row.GoodsMakerCd;                        // ���i���[�J�[�R�[�h
            stockDetail.MakerName = row.MakerName;                              // ���[�J�[����
            stockDetail.MakerKanaName = row.MakerKanaName;                      // ���[�J�[�J�i����
            stockDetail.CmpltMakerKanaName = row.CmpltMakerKanaName;            // ���[�J�[�J�i���́i�ꎮ�j
            stockDetail.GoodsNo = row.GoodsNo;                                  // ���i�ԍ�
            stockDetail.GoodsName = row.GoodsName;                              // ���i����
            stockDetail.GoodsNameKana = row.GoodsNameKana;                      // ���i���̃J�i
            stockDetail.GoodsLGroup = row.GoodsLGroup;                          // ���i�啪�ރR�[�h
            stockDetail.GoodsLGroupName = row.GoodsLGroupName;                  // ���i�啪�ޖ���
            stockDetail.GoodsMGroup = row.GoodsMGroup;                          // ���i�����ރR�[�h
            stockDetail.GoodsMGroupName = row.GoodsMGroupName;                  // ���i�����ޖ���
            stockDetail.BLGroupCode = row.BLGroupCode;                          // BL�O���[�v�R�[�h
            stockDetail.BLGroupName = row.BLGroupName;                          // BL�O���[�v�R�[�h����
            stockDetail.BLGoodsCode = row.BLGoodsCode;                          // BL���i�R�[�h
            stockDetail.BLGoodsFullName = row.BLGoodsFullName;                  // BL���i�R�[�h���́i�S�p�j
            stockDetail.EnterpriseGanreCode = row.EnterpriseGanreCode;          // ���Е��ރR�[�h
            stockDetail.EnterpriseGanreName = row.EnterpriseGanreName;          // ���Е��ޖ���
            stockDetail.WarehouseCode = row.WarehouseCode;                      // �q�ɃR�[�h
            stockDetail.WarehouseName = row.WarehouseName;                      // �q�ɖ���
            stockDetail.WarehouseShelfNo = row.WarehouseShelfNo;                // �q�ɒI��
            stockDetail.StockOrderDivCd = row.StockOrderDivCd;                  // �d���݌Ɏ�񂹋敪
            stockDetail.OpenPriceDiv = row.OpenPriceDiv;                        // �I�[�v�����i�敪
            stockDetail.GoodsRateRank = row.GoodsRateRank;                      // ���i�|�������N
            stockDetail.CustRateGrpCode = row.CustRateGrpCode;                  // ���Ӑ�|���O���[�v�R�[�h
            stockDetail.SuppRateGrpCode = row.SuppRateGrpCode;                  // �d����|���O���[�v�R�[�h
            stockDetail.ListPriceTaxExcFl = row.ListPriceTaxExcFl;              // �艿�i�Ŕ��C�����j
            stockDetail.ListPriceTaxIncFl = row.ListPriceTaxIncFl;              // �艿�i�ō��C�����j
            stockDetail.StockRate = row.StockRate;                              // �d����
            stockDetail.RateSectStckUnPrc = row.RateSectStckUnPrc;              // �|���ݒ苒�_�i�d���P���j
            stockDetail.RateDivStckUnPrc = row.RateDivStckUnPrc;                // �|���ݒ�敪�i�d���P���j
            stockDetail.UnPrcCalcCdStckUnPrc = row.UnPrcCalcCdStckUnPrc;        // �P���Z�o�敪�i�d���P���j
            stockDetail.PriceCdStckUnPrc = row.PriceCdStckUnPrc;                // ���i�敪�i�d���P���j
            stockDetail.StdUnPrcStckUnPrc = row.StdUnPrcStckUnPrc;              // ��P���i�d���P���j
            stockDetail.FracProcUnitStcUnPrc = row.FracProcUnitStcUnPrc;        // �[�������P�ʁi�d���P���j
            stockDetail.FracProcStckUnPrc = row.FracProcStckUnPrc;              // �[�������i�d���P���j
            stockDetail.StockUnitPriceFl = row.StockUnitPriceFl;                // �d���P���i�Ŕ��C�����j
            stockDetail.StockUnitTaxPriceFl = row.StockUnitTaxPriceFl;          // �d���P���i�ō��C�����j
            stockDetail.StockUnitChngDiv = row.StockUnitChngDiv;                // �d���P���ύX�敪
            stockDetail.BfStockUnitPriceFl = row.BfStockUnitPriceFl;            // �ύX�O�d���P���i�����j
            stockDetail.BfListPrice = row.BfListPrice;                          // �ύX�O�艿
            stockDetail.RateBLGoodsCode = row.RateBLGoodsCode;                  // BL���i�R�[�h�i�|���j
            stockDetail.RateBLGoodsName = row.RateBLGoodsName;                  // BL���i�R�[�h���́i�|���j
            stockDetail.RateGoodsRateGrpCd = row.RateGoodsRateGrpCd;            // ���i�|���O���[�v�R�[�h�i�|���j
            stockDetail.RateGoodsRateGrpNm = row.RateGoodsRateGrpNm;            // ���i�|���O���[�v���́i�|���j
            stockDetail.RateBLGroupCode = row.RateBLGroupCode;                  // BL�O���[�v�R�[�h�i�|���j
            stockDetail.RateBLGroupName = row.RateBLGroupName;                  // BL�O���[�v���́i�|���j
            stockDetail.StockCount = row.StockCount;                            // �d����
            stockDetail.OrderCnt = row.OrderCnt;                                // ��������
            stockDetail.OrderAdjustCnt = row.OrderAdjustCnt;                    // ����������
            stockDetail.OrderRemainCnt = row.OrderRemainCnt;                    // �����c��
            stockDetail.RemainCntUpdDate = row.RemainCntUpdDate;                // �c���X�V��
            stockDetail.StockPriceTaxExc = row.StockPriceTaxExc;                // �d�����z�i�Ŕ����j
            stockDetail.StockPriceTaxInc = row.StockPriceTaxInc;                // �d�����z�i�ō��݁j
            stockDetail.StockGoodsCd = row.StockGoodsCd;                        // �d�����i�敪
            stockDetail.StockPriceConsTax = row.StockPriceConsTax;              // �d�����z����Ŋz
            stockDetail.TaxationCode = row.TaxationCode;                        // �ېŋ敪
            stockDetail.StockDtiSlipNote1 = row.StockDtiSlipNote1;              // �d���`�[���ה��l1
            stockDetail.SalesCustomerCode = row.SalesCustomerCode;              // �̔���R�[�h
            stockDetail.SalesCustomerSnm = row.SalesCustomerSnm;                // �̔��旪��
            stockDetail.SlipMemo1 = row.SlipMemo1;                              // �`�[�����P
            stockDetail.SlipMemo2 = row.SlipMemo2;                              // �`�[�����Q
            stockDetail.SlipMemo3 = row.SlipMemo3;                              // �`�[�����R
            stockDetail.InsideMemo1 = row.InsideMemo1;                          // �Г������P
            stockDetail.InsideMemo2 = row.InsideMemo2;                          // �Г������Q
            stockDetail.InsideMemo3 = row.InsideMemo3;                          // �Г������R
            //stockDetail.SupplierCd = row.SupplierCd;                            // �d����R�[�h
            //stockDetail.SupplierSnm = row.SupplierSnm;                          // �d���旪��
            //stockDetail.AddresseeCode = row.AddresseeCode;                      // �[�i��R�[�h
            //stockDetail.AddresseeName = row.AddresseeName;                      // �[�i�於��
            //stockDetail.DirectSendingCd = row.DirectSendingCd;                  // �����敪
            stockDetail.OrderNumber = row.OrderNumber;                          // �����ԍ�
            //stockDetail.WayToOrder = row.WayToOrder;                            // �������@
            //stockDetail.DeliGdsCmpltDueDate = row.DeliGdsCmpltDueDate;          // �[�i�����\���
            //stockDetail.ExpectDeliveryDate = row.ExpectDeliveryDate;            // ��]�[��
            //stockDetail.OrderDataCreateDiv = row.OrderDataCreateDiv;            // �����f�[�^�쐬�敪
            //stockDetail.OrderDataCreateDate = row.OrderDataCreateDate;          // �����f�[�^�쐬��
            //stockDetail.OrderFormIssuedDiv = row.OrderFormIssuedDiv;            // ���������s�ϋ敪
            stockDetail.DtlRelationGuid = row.DtlRelationGuid;                  // ���׊֘A�t��GUID
            stockDetail.GoodsOfferDate = row.GoodsOfferDate;                    // ���i�񋟓��t
            stockDetail.PriceStartDate = row.PriceStartDate;                    // ���i�J�n���t
            stockDetail.PriceOfferDate = row.PriceOfferDate;                    // ���i�񋟓��t

			// �V�K�`�[�̏ꍇ�͔������Ɏd�������Z�b�g
			if (stockDetail.StockSlipDtlNum == 0)
			{
				stockDetail.OrderCnt = stockDetail.StockCount;
			}

			// ���ݒ蕪
			//stockDetail.SupplierCd = row.SupplierCd;							// �d����R�[�h
			//stockDetail.SupplierSnm = row.SupplierSnm;							// �d���旪��
			//stockDetail.AddresseeCode = row.AddresseeCode;						// �[�i��R�[�h
			//stockDetail.AddresseeName = row.AddresseeName;						// �[�i�於��
			//stockDetail.DirectSendingCd = row.DirectSendingCd;					// �����敪
			stockDetail.OrderNumber = row.OrderNumber;							// �����ԍ�
			//stockDetail.WayToOrder = row.WayToOrder;							// �������@
			//stockDetail.DeliGdsCmpltDueDate = row.DeliGdsCmpltDueDate;			// �[�i�����\���
			//stockDetail.ExpectDeliveryDate = row.ExpectDeliveryDate;			// ��]�[��
			//stockDetail.OrderDataCreateDiv = row.OrderDataCreateDiv;			// �����f�[�^�쐬�敪
			//stockDetail.OrderDataCreateDate = row.OrderDataCreateDate;			// �����f�[�^�쐬��
			//stockDetail.OrderFormIssuedDiv = row.OrderFormIssuedDiv;			// ���������s�ϋ敪


            // �␳��
            if ((stockDetail.StockSlipCdDtl == 0) && (this._stockSlip.SupplierSlipCd == 20))
            {
                stockDetail.StockSlipCdDtl = 1;
            }

            return stockDetail;
		}

		/// <summary>
		/// ��������f�[�^�s�I�u�W�F�N�g��蓯������f�[�^�I�u�W�F�N�g���擾���܂��B
		/// </summary>
		/// <param name="stockDetail">�d�����׃f�[�^�I�u�W�F�N�g</param>
		/// <param name="row">��������f�[�^�s�I�u�W�F�N�g</param>
		/// <returns>��������f�[�^�I�u�W�F�N�g</returns>
		private SalesTemp GetUIDataFromRow( StockDetail stockDetail, StockInputDataSet.SalesTempRow row )
		{
			SalesTemp salesTemp = new SalesTemp();

			#region �����ڃZ�b�g

			//salesTempRow.CreateDateTime = salesTempRow.CreateDateTime;				// �쐬����
			//salesTempRow.UpdateDateTime = salesTempRow.UpdateDateTime;				// �X�V����
			//salesTempRow.EnterpriseCode = salesTempRow.EnterpriseCode;				// ��ƃR�[�h
			//salesTempRow.FileHeaderGuid = salesTempRow.FileHeaderGuid;				// GUID
			//salesTempRow.UpdEmployeeCode = salesTempRow.UpdEmployeeCode;			// �X�V�]�ƈ��R�[�h
			//salesTempRow.UpdAssemblyId1 = salesTempRow.UpdAssemblyId1;				// �X�V�A�Z���u��ID1
			//salesTempRow.UpdAssemblyId2 = salesTempRow.UpdAssemblyId2;				// �X�V�A�Z���u��ID2
			//salesTempRow.LogicalDeleteCode = salesTempRow.LogicalDeleteCode;		// �_���폜�敪
			salesTemp.AcptAnOdrStatus = row.AcptAnOdrStatus;			// �󒍃X�e�[�^�X
			//salesTempRow.SalesSlipNum = salesTempRow.SalesSlipNum;					// ����`�[�ԍ�
			salesTemp.SectionCode = row.SectionCode;					// ���_�R�[�h
			salesTemp.SubSectionCode = row.SubSectionCode;				// ����R�[�h
			salesTemp.MinSectionCode = row.MinSectionCode;				// �ۃR�[�h
			salesTemp.DebitNoteDiv = row.DebitNoteDiv;					// �ԓ`�敪
			//salesTempRow.DebitNLnkSalesSlNum = salesTempRow.DebitNLnkSalesSlNum;	// �ԍ��A������`�[�ԍ�
			salesTemp.SalesSlipCd = row.SalesSlipCd;					// ����`�[�敪
			salesTemp.AccRecDivCd = row.AccRecDivCd;					// ���|�敪
			salesTemp.SalesInpSecCd = row.SalesInpSecCd;				// ������͋��_�R�[�h
			salesTemp.DemandAddUpSecCd = row.DemandAddUpSecCd;			// �����v�㋒�_�R�[�h
			salesTemp.ResultsAddUpSecCd = row.ResultsAddUpSecCd;		// ���ьv�㋒�_�R�[�h
			salesTemp.UpdateSecCd = row.UpdateSecCd;					// �X�V���_�R�[�h
			salesTemp.SearchSlipDate = row.SearchSlipDate;				// �`�[�������t
			salesTemp.ShipmentDay = row.ShipmentDay;					// �o�ד��t
			salesTemp.SalesDate = row.SalesDate;						// ������t
			salesTemp.AddUpADate = row.AddUpADate;						// �v����t
			salesTemp.DelayPaymentDiv = row.DelayPaymentDiv;			// �����敪
			salesTemp.ClaimCode = row.ClaimCode;						// ������R�[�h
			salesTemp.ClaimSnm = row.ClaimSnm;							// �����旪��
			salesTemp.CustomerCode = row.CustomerCode;					// ���Ӑ�R�[�h
			salesTemp.CustomerName = row.CustomerName;					// ���Ӑ於��
			salesTemp.CustomerName2 = row.CustomerName2;				// ���Ӑ於��2
			salesTemp.CustomerSnm = row.CustomerSnm;					// ���Ӑ旪��
			salesTemp.HonorificTitle = row.HonorificTitle;				// �h��
			salesTemp.OutputNameCode = row.OutputNameCode;				// �����R�[�h
			salesTemp.BusinessTypeCode = row.BusinessTypeCode;			// �Ǝ�R�[�h
			salesTemp.BusinessTypeName = row.BusinessTypeName;			// �Ǝ햼��
			salesTemp.SalesAreaCode = row.SalesAreaCode;				// �̔��G���A�R�[�h
			salesTemp.SalesAreaName = row.SalesAreaName;				// �̔��G���A����
			salesTemp.SalesInputCode = row.SalesInputCode;				// ������͎҃R�[�h
			salesTemp.SalesInputName = row.SalesInputName;				// ������͎Җ���
			salesTemp.FrontEmployeeCd = row.FrontEmployeeCd;			// ��t�]�ƈ��R�[�h
			salesTemp.FrontEmployeeNm = row.FrontEmployeeNm;			// ��t�]�ƈ�����
			salesTemp.SalesEmployeeCd = row.SalesEmployeeCd;			// �̔��]�ƈ��R�[�h
			salesTemp.SalesEmployeeNm = row.SalesEmployeeNm;			// �̔��]�ƈ�����
			salesTemp.TotalAmountDispWayCd = row.TotalAmountDispWayCd;	// ���z�\�����@�敪
			salesTemp.TtlAmntDispRateApy = row.TtlAmntDispRateApy;		// ���z�\���|���K�p�敪
			salesTemp.ConsTaxLayMethod = row.ConsTaxLayMethod;			// ����œ]�ŕ���
			salesTemp.ConsTaxRate = row.ConsTaxRate;					// ����Őŗ�
			salesTemp.FractionProcCd = row.FractionProcCd;				// �[�������敪
			//salesTempRow.AccRecConsTax = salesTempRow.AccRecConsTax;				// ���|�����
			salesTemp.AutoDepositCd = row.AutoDepositCd;				// ���������敪
			salesTemp.AutoDepoSlipNum = row.AutoDepoSlipNum;			// ���������`�[�ԍ�
			//salesTempRow.DepositAllowanceTtl = salesTempRow.DepositAllowanceTtl;	// �����������v�z
			//salesTempRow.DepositAlwcBlnce = salesTempRow.DepositAlwcBlnce;			// ���������c��
			salesTemp.SlipAddressDiv = row.SlipAddressDiv;				// �`�[�Z���敪
			salesTemp.AddresseeCode = row.AddresseeCode;				// �[�i��R�[�h
			salesTemp.AddresseeName = row.AddresseeName;				// �[�i�於��
			salesTemp.AddresseeName2 = row.AddresseeName2;				// �[�i�於��2
			salesTemp.AddresseePostNo = row.AddresseePostNo;			// �[�i��X�֔ԍ�
			salesTemp.AddresseeAddr1 = row.AddresseeAddr1;				// �[�i��Z��1(�s���{���s��S�E�����E��)
			salesTemp.AddresseeAddr2 = row.AddresseeAddr2;				// �[�i��Z��2(����)
			salesTemp.AddresseeAddr3 = row.AddresseeAddr3;				// �[�i��Z��3(�Ԓn)
			salesTemp.AddresseeAddr4 = row.AddresseeAddr4;				// �[�i��Z��4(�A�p�[�g����)
			salesTemp.AddresseeTelNo = row.AddresseeTelNo;				// �[�i��d�b�ԍ�
			salesTemp.AddresseeFaxNo = row.AddresseeFaxNo;				// �[�i��FAX�ԍ�
			salesTemp.PartySaleSlipNum = row.PartySaleSlipNum;			// �����`�[�ԍ�
			salesTemp.SlipNote = row.SlipNote;							// �`�[���l
			salesTemp.SlipNote2 = row.SlipNote2;						// �`�[���l�Q
			salesTemp.RetGoodsReasonDiv = row.RetGoodsReasonDiv;		// �ԕi���R�R�[�h
			salesTemp.RetGoodsReason = row.RetGoodsReason;				// �ԕi���R
			salesTemp.DetailRowCount = row.DetailRowCount;				// ���׍s��
			salesTemp.DeliveredGoodsDiv = row.DeliveredGoodsDiv;		// �[�i�敪
			salesTemp.DeliveredGoodsDivNm = row.DeliveredGoodsDivNm;	// �[�i�敪����
			salesTemp.ReconcileFlag = row.ReconcileFlag;				// �����t���O
			salesTemp.SlipPrtSetPaperId = row.SlipPrtSetPaperId;		// �`�[����ݒ�p���[ID
			salesTemp.CompleteCd = row.CompleteCd;						// �ꎮ�`�[�敪
			salesTemp.ClaimType = row.ClaimType;						// ������敪
			salesTemp.SalesPriceFracProcCd = row.SalesPriceFracProcCd;	// ������z�[�������敪
			salesTemp.ListPricePrintDiv = row.ListPricePrintDiv;		// �艿����敪
			salesTemp.EraNameDispCd1 = row.EraNameDispCd1;				// �����\���敪�P
			salesTemp.CommonSeqNo = row.CommonSeqNo;					// ���ʒʔ�
			salesTemp.SalesSlipDtlNum = row.SalesSlipDtlNum;			// ���㖾�גʔ�
			salesTemp.AcptAnOdrStatusSrc = row.AcptAnOdrStatusSrc;		// �󒍃X�e�[�^�X�i���j
			salesTemp.SalesSlipDtlNumSrc = row.SalesSlipDtlNumSrc;		// ���㖾�גʔԁi���j
			salesTemp.SalesSlipCdDtl = row.SalesSlipCdDtl;				// ����`�[�敪�i���ׁj
			salesTemp.StockMngExistCd = row.StockMngExistCd;			// �݌ɊǗ��L���敪
			salesTemp.DeliGdsCmpltDueDate = row.DeliGdsCmpltDueDate;	// �[�i�����\���
			salesTemp.GoodsKindCode = row.GoodsKindCode;				// ���i����
			salesTemp.GoodsMakerCd = row.GoodsMakerCd;					// ���i���[�J�[�R�[�h
			salesTemp.MakerName = row.MakerName;						// ���[�J�[����
			salesTemp.GoodsNo = row.GoodsNo;							// ���i�ԍ�
			salesTemp.GoodsName = row.GoodsName;						// ���i����
			salesTemp.GoodsShortName = row.GoodsShortName;				// ���i���̗���
			salesTemp.GoodsSetDivCd = row.GoodsSetDivCd;				// �Z�b�g���i�敪
			salesTemp.LargeGoodsGanreCode = row.LargeGoodsGanreCode;	// ���i�敪�O���[�v�R�[�h
			salesTemp.LargeGoodsGanreName = row.LargeGoodsGanreName;	// ���i�敪�O���[�v����
			salesTemp.MediumGoodsGanreCode = row.MediumGoodsGanreCode;	// ���i�敪�R�[�h
			salesTemp.MediumGoodsGanreName = row.MediumGoodsGanreName;	// ���i�敪����
			salesTemp.DetailGoodsGanreCode = row.DetailGoodsGanreCode;	// ���i�敪�ڍ׃R�[�h
			salesTemp.DetailGoodsGanreName = row.DetailGoodsGanreName;	// ���i�敪�ڍז���
			salesTemp.BLGoodsCode = row.BLGoodsCode;					// BL���i�R�[�h
			salesTemp.BLGoodsFullName = row.BLGoodsFullName;			// BL���i�R�[�h���́i�S�p�j
			salesTemp.EnterpriseGanreCode = row.EnterpriseGanreCode;	// ���Е��ރR�[�h
			salesTemp.EnterpriseGanreName = row.EnterpriseGanreName;	// ���Е��ޖ���
			salesTemp.WarehouseCode = row.WarehouseCode;				// �q�ɃR�[�h
			salesTemp.WarehouseName = row.WarehouseName;				// �q�ɖ���
			salesTemp.WarehouseShelfNo = row.WarehouseShelfNo;			// �q�ɒI��
			salesTemp.SalesOrderDivCd = row.SalesOrderDivCd;			// ����݌Ɏ�񂹋敪
			salesTemp.GoodsRateRank = row.GoodsRateRank;				// ���i�|�������N
			salesTemp.CustRateGrpCode = row.CustRateGrpCode;			// ���Ӑ�|���O���[�v�R�[�h
			salesTemp.SuppRateGrpCode = row.SuppRateGrpCode;			// �d����|���O���[�v�R�[�h
			salesTemp.ListPriceRate = row.ListPriceRate;				// �艿��
			salesTemp.RateSectPriceUnPrc = row.RateSectPriceUnPrc;		// �|���ݒ苒�_�i�艿�j
			salesTemp.RateDivLPrice = row.RateDivLPrice;				// �|���ݒ�敪�i�艿�j
			salesTemp.UnPrcCalcCdLPrice = row.UnPrcCalcCdLPrice;		// �P���Z�o�敪�i�艿�j
			salesTemp.PriceCdLPrice = row.PriceCdLPrice;				// ���i�敪�i�艿�j
			salesTemp.StdUnPrcLPrice = row.StdUnPrcLPrice;				// ��P���i�艿�j
			salesTemp.FracProcUnitLPrice = row.FracProcUnitLPrice;		// �[�������P�ʁi�艿�j
			salesTemp.FracProcLPrice = row.FracProcLPrice;				// �[�������i�艿�j
			salesTemp.ListPriceTaxIncFl = row.ListPriceTaxIncFl;		// �艿�i�ō��C�����j
			salesTemp.ListPriceTaxExcFl = row.ListPriceTaxExcFl;		// �艿�i�Ŕ��C�����j
			salesTemp.ListPriceChngCd = row.ListPriceChngCd;			// �艿�ύX�敪
			salesTemp.SalesRate = row.SalesRate;						// ������
			salesTemp.RateSectSalUnPrc = row.RateSectSalUnPrc;			// �|���ݒ苒�_�i����P���j
			salesTemp.RateDivSalUnPrc = row.RateDivSalUnPrc;			// �|���ݒ�敪�i����P���j
			salesTemp.UnPrcCalcCdSalUnPrc = row.UnPrcCalcCdSalUnPrc;	// �P���Z�o�敪�i����P���j
			salesTemp.PriceCdSalUnPrc = row.PriceCdSalUnPrc;			// ���i�敪�i����P���j
			salesTemp.StdUnPrcSalUnPrc = row.StdUnPrcSalUnPrc;			// ��P���i����P���j
			salesTemp.FracProcUnitSalUnPrc = row.FracProcUnitSalUnPrc;	// �[�������P�ʁi����P���j
			salesTemp.FracProcSalUnPrc = row.FracProcSalUnPrc;			// �[�������i����P���j
			salesTemp.SalesUnPrcTaxIncFl = row.SalesUnPrcTaxIncFl;		// ����P���i�ō��C�����j
			salesTemp.SalesUnPrcTaxExcFl = row.SalesUnPrcTaxExcFl;		// ����P���i�Ŕ��C�����j
			salesTemp.SalesUnPrcChngCd = row.SalesUnPrcChngCd;			// ����P���ύX�敪
			salesTemp.CostRate = row.CostRate;							// ������
			salesTemp.RateSectCstUnPrc = row.RateSectCstUnPrc;			// �|���ݒ苒�_�i�����P���j
			salesTemp.RateDivUnCst = row.RateDivUnCst;					// �|���ݒ�敪�i�����P���j
			salesTemp.UnPrcCalcCdUnCst = row.UnPrcCalcCdUnCst;			// �P���Z�o�敪�i�����P���j
			salesTemp.PriceCdUnCst = row.PriceCdUnCst;					// ���i�敪�i�����P���j
			salesTemp.StdUnPrcUnCst = row.StdUnPrcUnCst;				// ��P���i�����P���j
			salesTemp.FracProcUnitUnCst = row.FracProcUnitUnCst;		// �[�������P�ʁi�����P���j
			salesTemp.FracProcUnCst = row.FracProcUnCst;				// �[�������i�����P���j
			salesTemp.SalesUnitCost = row.SalesUnitCost;				// �����P��
			salesTemp.SalesUnitCostChngDiv = row.SalesUnitCostChngDiv;	// �����P���ύX�敪
			salesTemp.RateBLGoodsCode = row.RateBLGoodsCode;			// BL���i�R�[�h�i�|���j
			salesTemp.RateBLGoodsName = row.RateBLGoodsName;			// BL���i�R�[�h���́i�|���j
			salesTemp.ShipmentCnt = row.ShipmentCnt;					// �o�א�
			salesTemp.AcptAnOdrRemainCnt = row.AcceptAnOrderCnt;		// �󒍎c
			salesTemp.SalesMoneyTaxInc = row.SalesMoneyTaxInc;			// ������z�i�ō��݁j
			salesTemp.SalesMoneyTaxExc = row.SalesMoneyTaxExc;			// ������z�i�Ŕ����j
			salesTemp.Cost = row.Cost;									// ����
			salesTemp.GrsProfitChkDiv = row.GrsProfitChkDiv;			// �e���`�F�b�N�敪
			salesTemp.SalesGoodsCd = row.SalesGoodsCd;					// ���㏤�i�敪
			salesTemp.SalsePriceConsTax = row.SalsePriceConsTax;		// ������z����Ŋz
			salesTemp.TaxationDivCd = row.TaxationDivCd;				// �ېŋ敪
			salesTemp.PartySlipNumDtl = row.PartySlipNumDtl;			// �����`�[�ԍ��i���ׁj
			salesTemp.DtlNote = row.DtlNote;							// ���ה��l
			salesTemp.SupplierCd = row.SupplierCd;						// �d����R�[�h
			salesTemp.SupplierSnm = row.SupplierSnm;					// �d���旪��
			salesTemp.SlipMemo1 = row.SlipMemo1;						// �`�[�����P
			salesTemp.SlipMemo2 = row.SlipMemo2;						// �`�[�����Q
			salesTemp.SlipMemo3 = row.SlipMemo3;						// �`�[�����R
			salesTemp.SlipMemo4 = row.SlipMemo4;						// �`�[�����S
			salesTemp.SlipMemo5 = row.SlipMemo5;						// �`�[�����T
			salesTemp.SlipMemo6 = row.SlipMemo6;						// �`�[�����U
			salesTemp.InsideMemo1 = row.InsideMemo1;					// �Г������P
			salesTemp.InsideMemo2 = row.InsideMemo2;					// �Г������Q
			salesTemp.InsideMemo3 = row.InsideMemo3;					// �Г������R
			salesTemp.InsideMemo4 = row.InsideMemo4;					// �Г������S
			salesTemp.InsideMemo5 = row.InsideMemo5;					// �Г������T
			salesTemp.InsideMemo6 = row.InsideMemo6;					// �Г������U
			salesTemp.BfListPrice = row.BfListPrice;					// �ύX�O�艿
			salesTemp.BfSalesUnitPrice = row.BfSalesUnitPrice;			// �ύX�O����
			salesTemp.BfUnitCost = row.BfUnitCost;						// �ύX�O����
			salesTemp.PrtGoodsNo = row.PrtGoodsNo;						// ����p���i�ԍ�
			salesTemp.PrtGoodsName = row.PrtGoodsName;					// ����p���i����
			salesTemp.PrtGoodsMakerCd = row.PrtGoodsMakerCd;			// ����p���i���[�J�[�R�[�h
			salesTemp.PrtGoodsMakerNm = row.PrtGoodsMakerNm;			// ����p���i���[�J�[����
			salesTemp.DtlRelationGuid = row.DtlRelationGuid;			// ���׊֘A�t��GUID

			#endregion

			// �d�����׃f�[�^���
			salesTemp.SupplierFormalSync = stockDetail.SupplierFormal;		// �d���`���i�����j
			salesTemp.StockSlipDtlNumSync = stockDetail.StockSlipDtlNum;	// �d�����גʔԁi�����j

			return salesTemp;
		}

		/// <summary>
		/// �w�肵���d�����׃f�[�^�����Ɏd�����׃f�[�^�e�[�u���s�I�u�W�F�N�g�𐶐����܂��B
		/// </summary>
		/// <param name="stockSlip">�d���f�[�^�I�u�W�F�N�g</param>
		/// <param name="stockDetail">�d�����׃f�[�^�I�u�W�F�N�g</param>
		/// <param name="stockDetailDataTable">�d�����׃f�[�^�e�[�u���I�u�W�F�N�g</param>
		/// <returns>�d�����׃f�[�^�s�I�u�W�F�N�g</returns>
		private StockInputDataSet.StockDetailRow CreateRowFromUIData( StockSlip stockSlip, StockDetail stockDetail, StockInputDataSet.StockDetailDataTable stockDetailDataTable )
		{
			StockInputDataSet.StockDetailRow row = stockDetailDataTable.NewStockDetailRow();

			this.SetRowFromUIData(ref row, stockSlip, stockDetail);
			return row;
		}

		/// <summary>
		/// �w�肵���d�����׃f�[�^�����Ɍv�㌳�d�����׃f�[�^�e�[�u���s�I�u�W�F�N�g�𐶐����܂��B
		/// </summary>
		/// <param name="stockDetail">�d�����׃f�[�^�I�u�W�F�N�g</param>
		/// <param name="addUpSrcDetailDataTable">�v�㌳�d�����׃f�[�^�e�[�u���I�u�W�F�N�g</param>
		/// <returns>�d�����׃f�[�^�s�I�u�W�F�N�g</returns>
		private StockInputDataSet.AddUpSrcDetailRow CreateRowFromUIData( StockDetail stockDetail, StockInputDataSet.AddUpSrcDetailDataTable addUpSrcDetailDataTable )
		{
			StockInputDataSet.AddUpSrcDetailRow row = addUpSrcDetailDataTable.NewAddUpSrcDetailRow();

			this.SetRowFromUIData(ref row, stockDetail);
			return row;
		}

		/// <summary>
		/// �d�����׃f�[�^�I�u�W�F�N�g���v�㌳�d�����׃f�[�^�e�[�u���ɃL���b�V�����܂��B
		/// </summary>
		/// <param name="stockDetail">�d�����׃f�[�^�I�u�W�F�N�g</param>
		/// <param name="addUpSrcDetailDataTable">�v�㌳�d�����׃f�[�^�e�[�u���I�u�W�F�N�g</param>
		private void CacheAddUpSrcStockDetailDataTable( StockDetail stockDetail, StockInputDataSet.AddUpSrcDetailDataTable addUpSrcDetailDataTable )
		{
			try
			{
				addUpSrcDetailDataTable.AddAddUpSrcDetailRow(this.CreateRowFromUIData(stockDetail, addUpSrcDetailDataTable));
			}
			catch (ConstraintException)
			{
				StockInputDataSet.AddUpSrcDetailRow row = addUpSrcDetailDataTable.FindBySupplierFormalStockSlipDtlNum(stockDetail.SupplierFormal, stockDetail.StockSlipDtlNum);
				this.SetRowFromUIData(ref row, stockDetail);
			}
		}

		/// <summary>
		/// �d�����׃f�[�^�I�u�W�F�N�g���烊���N�p�d�����׃f�[�^�s�I�u�W�F�N�g�ɍ��ڂ�ݒ肵�܂��B
		/// </summary>
		/// <param name="row">�d�����׃f�[�^�s�I�u�W�F�N�g</param>
		/// <param name="stockDetail">�d�����׃f�[�^�I�u�W�F�N�g</param>
		private void SetRowFromUIData( ref StockInputDataSet.AddUpSrcDetailRow row, StockDetail stockDetail)
		{
			#region �����ڃZ�b�g

            //row.CreateDateTime = stockDetail.CreateDateTime;                    // �쐬����
            //row.UpdateDateTime = stockDetail.UpdateDateTime;                    // �X�V����
            //row.EnterpriseCode = stockDetail.EnterpriseCode;                    // ��ƃR�[�h
            //row.FileHeaderGuid = stockDetail.FileHeaderGuid;                    // GUID
            //row.UpdEmployeeCode = stockDetail.UpdEmployeeCode;                  // �X�V�]�ƈ��R�[�h
            //row.UpdAssemblyId1 = stockDetail.UpdAssemblyId1;                    // �X�V�A�Z���u��ID1
            //row.UpdAssemblyId2 = stockDetail.UpdAssemblyId2;                    // �X�V�A�Z���u��ID2
            //row.LogicalDeleteCode = stockDetail.LogicalDeleteCode;              // �_���폜�敪
            row.AcceptAnOrderNo = stockDetail.AcceptAnOrderNo;                  // �󒍔ԍ�
            row.SupplierFormal = stockDetail.SupplierFormal;                    // �d���`��
            row.SupplierSlipNo = stockDetail.SupplierSlipNo;                    // �d���`�[�ԍ�
            row.StockRowNo = stockDetail.StockRowNo;                            // �d���s�ԍ�
            row.SectionCode = stockDetail.SectionCode;                          // ���_�R�[�h
            row.SubSectionCode = stockDetail.SubSectionCode;                    // ����R�[�h
            row.CommonSeqNo = stockDetail.CommonSeqNo;                          // ���ʒʔ�
            row.StockSlipDtlNum = stockDetail.StockSlipDtlNum;                  // �d�����גʔ�
            row.SupplierFormalSrc = stockDetail.SupplierFormalSrc;              // �d���`���i���j
            row.StockSlipDtlNumSrc = stockDetail.StockSlipDtlNumSrc;            // �d�����גʔԁi���j
            row.AcptAnOdrStatusSync = stockDetail.AcptAnOdrStatusSync;          // �󒍃X�e�[�^�X�i�����j
            row.SalesSlipDtlNumSync = stockDetail.SalesSlipDtlNumSync;          // ���㖾�גʔԁi�����j
            row.StockSlipCdDtl = stockDetail.StockSlipCdDtl;                    // �d���`�[�敪�i���ׁj
            //row.StockInputCode = stockDetail.StockInputCode;                    // �d�����͎҃R�[�h
            //row.StockInputName = stockDetail.StockInputName;                    // �d�����͎Җ���
            //row.StockAgentCode = stockDetail.StockAgentCode;                    // �d���S���҃R�[�h
            //row.StockAgentName = stockDetail.StockAgentName;                    // �d���S���Җ���
            row.GoodsKindCode = stockDetail.GoodsKindCode;                      // ���i����
            row.GoodsMakerCd = stockDetail.GoodsMakerCd;                        // ���i���[�J�[�R�[�h
            row.MakerName = stockDetail.MakerName;                              // ���[�J�[����
            row.MakerKanaName = stockDetail.MakerKanaName;                      // ���[�J�[�J�i����
            row.CmpltMakerKanaName = stockDetail.CmpltMakerKanaName;            // ���[�J�[�J�i���́i�ꎮ�j
            row.GoodsNo = stockDetail.GoodsNo;                                  // ���i�ԍ�
            row.GoodsName = stockDetail.GoodsName;                              // ���i����
            row.GoodsNameKana = stockDetail.GoodsNameKana;                      // ���i���̃J�i
            row.GoodsLGroup = stockDetail.GoodsLGroup;                          // ���i�啪�ރR�[�h
            row.GoodsLGroupName = stockDetail.GoodsLGroupName;                  // ���i�啪�ޖ���
            row.GoodsMGroup = stockDetail.GoodsMGroup;                          // ���i�����ރR�[�h
            row.GoodsMGroupName = stockDetail.GoodsMGroupName;                  // ���i�����ޖ���
            row.BLGroupCode = stockDetail.BLGroupCode;                          // BL�O���[�v�R�[�h
            row.BLGroupName = stockDetail.BLGroupName;                          // BL�O���[�v�R�[�h����
            row.BLGoodsCode = stockDetail.BLGoodsCode;                          // BL���i�R�[�h
            row.BLGoodsFullName = stockDetail.BLGoodsFullName;                  // BL���i�R�[�h���́i�S�p�j
            row.EnterpriseGanreCode = stockDetail.EnterpriseGanreCode;          // ���Е��ރR�[�h
            row.EnterpriseGanreName = stockDetail.EnterpriseGanreName;          // ���Е��ޖ���
            row.WarehouseCode = stockDetail.WarehouseCode;                      // �q�ɃR�[�h
            row.WarehouseName = stockDetail.WarehouseName;                      // �q�ɖ���
            row.WarehouseShelfNo = stockDetail.WarehouseShelfNo;                // �q�ɒI��
            row.StockOrderDivCd = stockDetail.StockOrderDivCd;                  // �d���݌Ɏ�񂹋敪
            row.OpenPriceDiv = stockDetail.OpenPriceDiv;                        // �I�[�v�����i�敪
            row.GoodsRateRank = stockDetail.GoodsRateRank;                      // ���i�|�������N
            row.CustRateGrpCode = stockDetail.CustRateGrpCode;                  // ���Ӑ�|���O���[�v�R�[�h
            row.SuppRateGrpCode = stockDetail.SuppRateGrpCode;                  // �d����|���O���[�v�R�[�h
            row.ListPriceTaxExcFl = stockDetail.ListPriceTaxExcFl;              // �艿�i�Ŕ��C�����j
            row.ListPriceTaxIncFl = stockDetail.ListPriceTaxIncFl;              // �艿�i�ō��C�����j
            row.StockRate = stockDetail.StockRate;                              // �d����
            row.RateSectStckUnPrc = stockDetail.RateSectStckUnPrc;              // �|���ݒ苒�_�i�d���P���j
            row.RateDivStckUnPrc = stockDetail.RateDivStckUnPrc;                // �|���ݒ�敪�i�d���P���j
            row.UnPrcCalcCdStckUnPrc = stockDetail.UnPrcCalcCdStckUnPrc;        // �P���Z�o�敪�i�d���P���j
            row.PriceCdStckUnPrc = stockDetail.PriceCdStckUnPrc;                // ���i�敪�i�d���P���j
            row.StdUnPrcStckUnPrc = stockDetail.StdUnPrcStckUnPrc;              // ��P���i�d���P���j
            row.FracProcUnitStcUnPrc = stockDetail.FracProcUnitStcUnPrc;        // �[�������P�ʁi�d���P���j
            row.FracProcStckUnPrc = stockDetail.FracProcStckUnPrc;              // �[�������i�d���P���j
            row.StockUnitPriceFl = stockDetail.StockUnitPriceFl;                // �d���P���i�Ŕ��C�����j
            row.StockUnitTaxPriceFl = stockDetail.StockUnitTaxPriceFl;          // �d���P���i�ō��C�����j
            row.StockUnitChngDiv = stockDetail.StockUnitChngDiv;                // �d���P���ύX�敪
            row.BfStockUnitPriceFl = stockDetail.BfStockUnitPriceFl;            // �ύX�O�d���P���i�����j
            row.BfListPrice = stockDetail.BfListPrice;                          // �ύX�O�艿
            row.RateBLGoodsCode = stockDetail.RateBLGoodsCode;                  // BL���i�R�[�h�i�|���j
            row.RateBLGoodsName = stockDetail.RateBLGoodsName;                  // BL���i�R�[�h���́i�|���j
            row.RateGoodsRateGrpCd = stockDetail.RateGoodsRateGrpCd;            // ���i�|���O���[�v�R�[�h�i�|���j
            row.RateGoodsRateGrpNm = stockDetail.RateGoodsRateGrpNm;            // ���i�|���O���[�v���́i�|���j
            row.RateBLGroupCode = stockDetail.RateBLGroupCode;                  // BL�O���[�v�R�[�h�i�|���j
            row.RateBLGroupName = stockDetail.RateBLGroupName;                  // BL�O���[�v���́i�|���j
            row.StockCount = stockDetail.StockCount;                            // �d����
            row.OrderCnt = stockDetail.OrderCnt;                                // ��������
            row.OrderAdjustCnt = stockDetail.OrderAdjustCnt;                    // ����������
            row.OrderRemainCnt = stockDetail.OrderRemainCnt;                    // �����c��
            row.RemainCntUpdDate = stockDetail.RemainCntUpdDate;                // �c���X�V��
            row.StockPriceTaxExc = stockDetail.StockPriceTaxExc;                // �d�����z�i�Ŕ����j
            row.StockPriceTaxInc = stockDetail.StockPriceTaxInc;                // �d�����z�i�ō��݁j
            row.StockGoodsCd = stockDetail.StockGoodsCd;                        // �d�����i�敪
            row.StockPriceConsTax = stockDetail.StockPriceConsTax;              // �d�����z����Ŋz
            row.TaxationCode = stockDetail.TaxationCode;                        // �ېŋ敪
            row.StockDtiSlipNote1 = stockDetail.StockDtiSlipNote1;              // �d���`�[���ה��l1
            row.SalesCustomerCode = stockDetail.SalesCustomerCode;              // �̔���R�[�h
            row.SalesCustomerSnm = stockDetail.SalesCustomerSnm;                // �̔��旪��
            row.SlipMemo1 = stockDetail.SlipMemo1;                              // �`�[�����P
            row.SlipMemo2 = stockDetail.SlipMemo2;                              // �`�[�����Q
            row.SlipMemo3 = stockDetail.SlipMemo3;                              // �`�[�����R
            row.InsideMemo1 = stockDetail.InsideMemo1;                          // �Г������P
            row.InsideMemo2 = stockDetail.InsideMemo2;                          // �Г������Q
            row.InsideMemo3 = stockDetail.InsideMemo3;                          // �Г������R
            row.SupplierCd = stockDetail.SupplierCd;                            // �d����R�[�h
            row.SupplierSnm = stockDetail.SupplierSnm;                          // �d���旪��
            row.AddresseeCode = stockDetail.AddresseeCode;                      // �[�i��R�[�h
            row.AddresseeName = stockDetail.AddresseeName;                      // �[�i�於��
            row.DirectSendingCd = stockDetail.DirectSendingCd;                  // �����敪
            row.OrderNumber = stockDetail.OrderNumber;                          // �����ԍ�
            row.WayToOrder = stockDetail.WayToOrder;                            // �������@
            row.DeliGdsCmpltDueDate = stockDetail.DeliGdsCmpltDueDate;          // �[�i�����\���
            row.ExpectDeliveryDate = stockDetail.ExpectDeliveryDate;            // ��]�[��
            row.OrderDataCreateDiv = stockDetail.OrderDataCreateDiv;            // �����f�[�^�쐬�敪
            row.OrderDataCreateDate = stockDetail.OrderDataCreateDate;          // �����f�[�^�쐬��
            row.OrderFormIssuedDiv = stockDetail.OrderFormIssuedDiv;            // ���������s�ϋ敪

			#endregion
		}

		/// <summary>
		/// �d�����׍s�I�u�W�F�N�g�̃N���A���s���܂��B�i�I�[�o�[���[�h�j
		/// </summary>
		/// <param name="row">�d�����׍s�I�u�W�F�N�g</param>
		private void ClearStockDetailRow(StockInputDataSet.StockDetailRow row)
		{
			if (row == null) return;

			#region �����ڃN���A

            row.AcceptAnOrderNo = 0;                        // �󒍔ԍ�
            row.SupplierFormal = 0;                         // �d���`��
            //row.SupplierSlipNo = 0;                         // �d���`�[�ԍ�
            //row.StockRowNo = 0;                             // �d���s�ԍ�
            row.SectionCode = string.Empty;                 // ���_�R�[�h
            row.SubSectionCode = 0;                         // ����R�[�h
            row.CommonSeqNo = 0;                            // ���ʒʔ�
            row.StockSlipDtlNum = 0;                        // �d�����גʔ�
            row.SupplierFormalSrc = 0;                      // �d���`���i���j
            row.StockSlipDtlNumSrc = 0;                     // �d�����גʔԁi���j
            row.AcptAnOdrStatusSync = 0;                    // �󒍃X�e�[�^�X�i�����j
            row.SalesSlipDtlNumSync = 0;                    // ���㖾�גʔԁi�����j
            row.StockSlipCdDtl = 0;                         // �d���`�[�敪�i���ׁj
            row.StockInputCode = string.Empty;              // �d�����͎҃R�[�h
            row.StockInputName = string.Empty;              // �d�����͎Җ���
            row.StockAgentCode = string.Empty;              // �d���S���҃R�[�h
            row.StockAgentName = string.Empty;              // �d���S���Җ���
            row.GoodsKindCode = 0;                          // ���i����
            row.GoodsMakerCd = 0;                           // ���i���[�J�[�R�[�h
            row.MakerName = string.Empty;                   // ���[�J�[����
            row.MakerKanaName = string.Empty;               // ���[�J�[�J�i����
            row.CmpltMakerKanaName = string.Empty;          // ���[�J�[�J�i���́i�ꎮ�j
            row.GoodsNo = string.Empty;                     // ���i�ԍ�
            row.GoodsName = string.Empty;                   // ���i����
            row.GoodsNameKana = string.Empty;               // ���i���̃J�i
            row.GoodsLGroup = 0;                            // ���i�啪�ރR�[�h
            row.GoodsLGroupName = string.Empty;             // ���i�啪�ޖ���
            row.GoodsMGroup = 0;                            // ���i�����ރR�[�h
            row.GoodsMGroupName = string.Empty;             // ���i�����ޖ���
            row.BLGroupCode = 0;                            // BL�O���[�v�R�[�h
            row.BLGroupName = string.Empty;                 // BL�O���[�v�R�[�h����
            row.BLGoodsCode = 0;                            // BL���i�R�[�h
            row.BLGoodsFullName = string.Empty;             // BL���i�R�[�h���́i�S�p�j
            row.EnterpriseGanreCode = 0;                    // ���Е��ރR�[�h
            row.EnterpriseGanreName = string.Empty;         // ���Е��ޖ���
            row.WarehouseCode = string.Empty;               // �q�ɃR�[�h
            row.WarehouseName = string.Empty;               // �q�ɖ���
            row.WarehouseShelfNo = string.Empty;            // �q�ɒI��
            row.StockOrderDivCd = 0;                        // �d���݌Ɏ�񂹋敪
            row.OpenPriceDiv = 0;                           // �I�[�v�����i�敪
            row.GoodsRateRank = string.Empty;               // ���i�|�������N
            row.CustRateGrpCode = 0;                        // ���Ӑ�|���O���[�v�R�[�h
            row.SuppRateGrpCode = 0;                        // �d����|���O���[�v�R�[�h
            row.ListPriceTaxExcFl = 0;                      // �艿�i�Ŕ��C�����j
            row.ListPriceTaxIncFl = 0;                      // �艿�i�ō��C�����j
            row.StockRate = 0;                              // �d����
            row.RateSectStckUnPrc = string.Empty;           // �|���ݒ苒�_�i�d���P���j
            row.RateDivStckUnPrc = string.Empty;            // �|���ݒ�敪�i�d���P���j
            row.UnPrcCalcCdStckUnPrc = 0;                   // �P���Z�o�敪�i�d���P���j
            row.PriceCdStckUnPrc = 0;                       // ���i�敪�i�d���P���j
            row.StdUnPrcStckUnPrc = 0;                      // ��P���i�d���P���j
            row.FracProcUnitStcUnPrc = 0;                   // �[�������P�ʁi�d���P���j
            row.FracProcStckUnPrc = 0;                      // �[�������i�d���P���j
            row.StockUnitPriceFl = 0;                       // �d���P���i�Ŕ��C�����j
            row.StockUnitTaxPriceFl = 0;                    // �d���P���i�ō��C�����j
            row.StockUnitChngDiv = 0;                       // �d���P���ύX�敪
            row.BfStockUnitPriceFl = 0;                     // �ύX�O�d���P���i�����j
            row.BfListPrice = 0;                            // �ύX�O�艿
            row.RateBLGoodsCode = 0;                        // BL���i�R�[�h�i�|���j
            row.RateBLGoodsName = string.Empty;             // BL���i�R�[�h���́i�|���j
            row.RateGoodsRateGrpCd = 0;                     // ���i�|���O���[�v�R�[�h�i�|���j
            row.RateGoodsRateGrpNm = string.Empty;          // ���i�|���O���[�v���́i�|���j
            row.RateBLGroupCode = 0;                        // BL�O���[�v�R�[�h�i�|���j
            row.RateBLGroupName = string.Empty;             // BL�O���[�v���́i�|���j
            row.StockCount = 0;                             // �d����
            row.OrderCnt = 0;                               // ��������
            row.OrderAdjustCnt = 0;                         // ����������
            row.OrderRemainCnt = 0;                         // �����c��
            row.RemainCntUpdDate = DateTime.MinValue;       // �c���X�V��
            row.StockPriceTaxExc = 0;                       // �d�����z�i�Ŕ����j
            row.StockPriceTaxInc = 0;                       // �d�����z�i�ō��݁j
            row.StockGoodsCd = 0;                           // �d�����i�敪
            row.StockPriceConsTax = 0;                      // �d�����z����Ŋz
            row.TaxationCode = 0;                           // �ېŋ敪
            row.StockDtiSlipNote1 = string.Empty;           // �d���`�[���ה��l1
            row.SalesCustomerCode = 0;                      // �̔���R�[�h
            row.SalesCustomerSnm = string.Empty;            // �̔��旪��
            row.SlipMemo1 = string.Empty;                   // �`�[�����P
            row.SlipMemo2 = string.Empty;                   // �`�[�����Q
            row.SlipMemo3 = string.Empty;                   // �`�[�����R
            row.InsideMemo1 = string.Empty;                 // �Г������P
            row.InsideMemo2 = string.Empty;                 // �Г������Q
            row.InsideMemo3 = string.Empty;                 // �Г������R
            row.SupplierCd = 0;                             // �d����R�[�h
            row.SupplierSnm = string.Empty;                 // �d���旪��
            row.AddresseeCode = 0;                          // �[�i��R�[�h
            row.AddresseeName = string.Empty;               // �[�i�於��
            row.DirectSendingCd = 0;                        // �����敪
            row.OrderNumber = string.Empty;                 // �����ԍ�
            row.WayToOrder = 0;                             // �������@
            row.DeliGdsCmpltDueDate = DateTime.MinValue;    // �[�i�����\���
            row.ExpectDeliveryDate = DateTime.MinValue;     // ��]�[��
            row.OrderDataCreateDiv = 0;                     // �����f�[�^�쐬�敪
            row.OrderDataCreateDate = DateTime.MinValue;    // �����f�[�^�쐬��
            row.OrderFormIssuedDiv = 0;                     // ���������s�ϋ敪
            row.DtlRelationGuid = Guid.Empty;               // ���׊֘A�t��GUID
            row.GoodsOfferDate = DateTime.MinValue;         // ���i�񋟓��t
            row.PriceStartDate = DateTime.MinValue;         // ���i�J�n���t
            row.PriceOfferDate = DateTime.MinValue;         // ���i�񋟓��t

			row.ShipmentPosCnt = 0;
			row.ShipmentPosCntDisplay = 0;
			row.StockPriceDisplay = 0;
			row.ListPriceDisplay = 0;
			row.StockUnitPriceDisplay = 0;
			row.StockCountDisplay = 0;
			row.StockCountDefault = 0;
			row.StockCountMax = 0;
			row.StockCountMin = 0;
			row.TaxDiv = 0;
			row.CanTaxDivChange = true;
            row.StockPriceDiectInput = false;
            row.StockUnitPriceDefault = 0;
            row.StockUnitTaxPriceDefault = 0;
            row.StockPriceTaxExcDefault = 0;
            row.StockPriceTaxIncDefault = 0;

            row.EditStatus = ctEDITSTATUS_AllOK;
            row.RowStatus = ctROWSTATUS_NORMAL;

			#endregion
		}

		/// <summary>
		/// �d�����׍s�I�u�W�F�N�g�𕡐����܂��B
		/// </summary>
		/// <param name="sourceRow">�d�����׍s�I�u�W�F�N�g</param>
		/// <returns>������d�����׍s�I�u�W�F�N�g</returns>
		private StockInputDataSet.StockDetailRow CloneStockDetailRow(StockInputDataSet.StockDetailRow sourceRow)
		{
			StockInputDataSet.StockDetailRow targetRow = this._stockDetailDataTable.NewStockDetailRow();

			#region �����ڃZ�b�g
			
			targetRow.SupplierFormal = sourceRow.SupplierFormal;				// �d���`��
			targetRow.SupplierSlipNo = sourceRow.SupplierSlipNo;				// �d���`�[�ԍ�
			targetRow.StockRowNo = sourceRow.StockRowNo;						// �d���s�ԍ�
			targetRow.SectionCode = sourceRow.SectionCode;						// ���_�R�[�h
			targetRow.SubSectionCode = sourceRow.SubSectionCode;				// ����R�[�h
			targetRow.CommonSeqNo = sourceRow.CommonSeqNo;						// ���ʒʔ�
			targetRow.StockSlipDtlNum = sourceRow.StockSlipDtlNum;				// �d�����גʔ�
			targetRow.SupplierFormalSrc = sourceRow.SupplierFormalSrc;			// �d���`���i���j
			targetRow.StockSlipDtlNumSrc = sourceRow.StockSlipDtlNumSrc;		// �d�����גʔԁi���j
			targetRow.AcptAnOdrStatusSync = sourceRow.AcptAnOdrStatusSync;		// �󒍃X�e�[�^�X�i�����j
			targetRow.SalesSlipDtlNumSync = sourceRow.SalesSlipDtlNumSync;		// ���㖾�גʔԁi�����j
			targetRow.StockSlipCdDtl = sourceRow.StockSlipCdDtl;				// �d���`�[�敪�i���ׁj
			targetRow.StockInputCode = sourceRow.StockInputCode;				// �d�����͎҃R�[�h
			targetRow.StockInputName = sourceRow.StockInputName;				// �d�����͎Җ���
			targetRow.StockAgentCode = sourceRow.StockAgentCode;				// �d���S���҃R�[�h
			targetRow.StockAgentName = sourceRow.StockAgentName;				// �d���S���Җ���
			targetRow.GoodsKindCode = sourceRow.GoodsKindCode;					// ���i����
			targetRow.GoodsMakerCd = sourceRow.GoodsMakerCd;					// ���i���[�J�[�R�[�h
			targetRow.MakerName = sourceRow.MakerName;							// ���[�J�[����
			targetRow.MakerKanaName = sourceRow.MakerKanaName;					// ���[�J�[�J�i����
			targetRow.CmpltMakerKanaName = sourceRow.CmpltMakerKanaName;		// ���[�J�[�J�i���́i�ꎮ�j
			targetRow.GoodsNo = sourceRow.GoodsNo;								// ���i�ԍ�
			targetRow.GoodsName = sourceRow.GoodsName;							// ���i����
			targetRow.GoodsNameKana = sourceRow.GoodsNameKana;					// ���i���̃J�i
			targetRow.GoodsLGroup = sourceRow.GoodsLGroup;						// ���i�啪�ރR�[�h
			targetRow.GoodsLGroupName = sourceRow.GoodsLGroupName;				// ���i�啪�ޖ���
			targetRow.GoodsMGroup = sourceRow.GoodsMGroup;						// ���i�����ރR�[�h
			targetRow.GoodsMGroupName = sourceRow.GoodsMGroupName;				// ���i�����ޖ���
			targetRow.BLGroupCode = sourceRow.BLGroupCode;						// BL�O���[�v�R�[�h
			targetRow.BLGroupName = sourceRow.BLGroupName;						// BL�O���[�v�R�[�h����
			targetRow.BLGoodsCode = sourceRow.BLGoodsCode;						// BL���i�R�[�h
			targetRow.BLGoodsFullName = sourceRow.BLGoodsFullName;				// BL���i�R�[�h���́i�S�p�j
			targetRow.EnterpriseGanreCode = sourceRow.EnterpriseGanreCode;		// ���Е��ރR�[�h
			targetRow.EnterpriseGanreName = sourceRow.EnterpriseGanreName;		// ���Е��ޖ���
			targetRow.WarehouseCode = sourceRow.WarehouseCode;					// �q�ɃR�[�h
			targetRow.WarehouseName = sourceRow.WarehouseName;					// �q�ɖ���
			targetRow.WarehouseShelfNo = sourceRow.WarehouseShelfNo;			// �q�ɒI��
			targetRow.StockOrderDivCd = sourceRow.StockOrderDivCd;				// �d���݌Ɏ�񂹋敪
			targetRow.OpenPriceDiv = sourceRow.OpenPriceDiv;					// �I�[�v�����i�敪
			targetRow.GoodsRateRank = sourceRow.GoodsRateRank;					// ���i�|�������N
			targetRow.CustRateGrpCode = sourceRow.CustRateGrpCode;				// ���Ӑ�|���O���[�v�R�[�h
			targetRow.SuppRateGrpCode = sourceRow.SuppRateGrpCode;				// �d����|���O���[�v�R�[�h
			targetRow.ListPriceTaxExcFl = sourceRow.ListPriceTaxExcFl;			// �艿�i�Ŕ��C�����j
			targetRow.ListPriceTaxIncFl = sourceRow.ListPriceTaxIncFl;			// �艿�i�ō��C�����j
			targetRow.StockRate = sourceRow.StockRate;							// �d����
			targetRow.RateSectStckUnPrc = sourceRow.RateSectStckUnPrc;			// �|���ݒ苒�_�i�d���P���j
			targetRow.RateDivStckUnPrc = sourceRow.RateDivStckUnPrc;			// �|���ݒ�敪�i�d���P���j
			targetRow.UnPrcCalcCdStckUnPrc = sourceRow.UnPrcCalcCdStckUnPrc;	// �P���Z�o�敪�i�d���P���j
			targetRow.PriceCdStckUnPrc = sourceRow.PriceCdStckUnPrc;			// ���i�敪�i�d���P���j
			targetRow.StdUnPrcStckUnPrc = sourceRow.StdUnPrcStckUnPrc;			// ��P���i�d���P���j
			targetRow.FracProcUnitStcUnPrc = sourceRow.FracProcUnitStcUnPrc;	// �[�������P�ʁi�d���P���j
			targetRow.FracProcStckUnPrc = sourceRow.FracProcStckUnPrc;			// �[�������i�d���P���j
			targetRow.StockUnitPriceFl = sourceRow.StockUnitPriceFl;			// �d���P���i�Ŕ��C�����j
			targetRow.StockUnitTaxPriceFl = sourceRow.StockUnitTaxPriceFl;		// �d���P���i�ō��C�����j
			targetRow.StockUnitChngDiv = sourceRow.StockUnitChngDiv;			// �d���P���ύX�敪
			targetRow.BfStockUnitPriceFl = sourceRow.BfStockUnitPriceFl;		// �ύX�O�d���P���i�����j
			targetRow.BfListPrice = sourceRow.BfListPrice;						// �ύX�O�艿
			targetRow.RateBLGoodsCode = sourceRow.RateBLGoodsCode;				// BL���i�R�[�h�i�|���j
			targetRow.RateBLGoodsName = sourceRow.RateBLGoodsName;				// BL���i�R�[�h���́i�|���j
            targetRow.RateGoodsRateGrpCd = sourceRow.RateGoodsRateGrpCd;        // ���i�|���O���[�v�R�[�h�i�|���j
            targetRow.RateGoodsRateGrpNm = sourceRow.RateGoodsRateGrpNm;        // ���i�|���O���[�v���́i�|���j
            targetRow.RateBLGroupCode = sourceRow.RateBLGroupCode;              // BL�O���[�v�R�[�h�i�|���j
            targetRow.RateBLGroupName = sourceRow.RateBLGroupName;              // BL�O���[�v���́i�|���j
			targetRow.StockCount = sourceRow.StockCount;						// �d����
			targetRow.OrderCnt = sourceRow.OrderCnt;							// ��������
			targetRow.OrderAdjustCnt = sourceRow.OrderAdjustCnt;				// ����������
			targetRow.OrderRemainCnt = sourceRow.OrderRemainCnt;				// �����c��
			targetRow.RemainCntUpdDate = sourceRow.RemainCntUpdDate;			// �c���X�V��
			targetRow.StockPriceTaxExc = sourceRow.StockPriceTaxExc;			// �d�����z�i�Ŕ����j
			targetRow.StockPriceTaxInc = sourceRow.StockPriceTaxInc;			// �d�����z�i�ō��݁j
			targetRow.StockGoodsCd = sourceRow.StockGoodsCd;					// �d�����i�敪
			targetRow.StockPriceConsTax = sourceRow.StockPriceConsTax;			// �d�����z����Ŋz
			targetRow.TaxationCode = sourceRow.TaxationCode;					// �ېŋ敪
			targetRow.StockDtiSlipNote1 = sourceRow.StockDtiSlipNote1;			// �d���`�[���ה��l1
			targetRow.SalesCustomerCode = sourceRow.SalesCustomerCode;			// �̔���R�[�h
			targetRow.SalesCustomerSnm = sourceRow.SalesCustomerSnm;			// �̔��旪��
			targetRow.SlipMemo1 = sourceRow.SlipMemo1;							// �`�[�����P
			targetRow.SlipMemo2 = sourceRow.SlipMemo2;							// �`�[�����Q
			targetRow.SlipMemo3 = sourceRow.SlipMemo3;							// �`�[�����R
			targetRow.InsideMemo1 = sourceRow.InsideMemo1;						// �Г������P
			targetRow.InsideMemo2 = sourceRow.InsideMemo2;						// �Г������Q
			targetRow.InsideMemo3 = sourceRow.InsideMemo3;						// �Г������R
			targetRow.SupplierCd = sourceRow.SupplierCd;						// �d����R�[�h
			targetRow.SupplierSnm = sourceRow.SupplierSnm;						// �d���旪��
			targetRow.AddresseeCode = sourceRow.AddresseeCode;					// �[�i��R�[�h
			targetRow.AddresseeName = sourceRow.AddresseeName;					// �[�i�於��
			targetRow.DirectSendingCd = sourceRow.DirectSendingCd;				// �����敪
			targetRow.OrderNumber = sourceRow.OrderNumber;						// �����ԍ�
			targetRow.WayToOrder = sourceRow.WayToOrder;						// �������@
			targetRow.DeliGdsCmpltDueDate = sourceRow.DeliGdsCmpltDueDate;		// �[�i�����\���
			targetRow.ExpectDeliveryDate = sourceRow.ExpectDeliveryDate;		// ��]�[��
			targetRow.OrderDataCreateDiv = sourceRow.OrderDataCreateDiv;		// �����f�[�^�쐬�敪
			targetRow.OrderDataCreateDate = sourceRow.OrderDataCreateDate;		// �����f�[�^�쐬��
			targetRow.OrderFormIssuedDiv = sourceRow.OrderFormIssuedDiv;		// ���������s�ϋ敪
			targetRow.DtlRelationGuid = sourceRow.DtlRelationGuid;				// ���׊֘A�t��GUID
			targetRow.GoodsOfferDate = sourceRow.GoodsOfferDate;				// ���i�񋟓��t
			targetRow.PriceStartDate = sourceRow.PriceStartDate;				// ���i�J�n���t
			targetRow.PriceOfferDate = sourceRow.PriceOfferDate;				// ���i�񋟓��t

			targetRow.ShipmentPosCnt = sourceRow.ShipmentPosCnt;
			targetRow.ShipmentPosCntDisplay = sourceRow.ShipmentPosCntDisplay;
			targetRow.ListPriceDisplay = sourceRow.ListPriceDisplay;
			targetRow.StockUnitPriceDisplay = sourceRow.StockUnitPriceDisplay;
			targetRow.StockCountDefault = sourceRow.StockCountDefault;
			targetRow.StockCountDisplay = sourceRow.StockCountDisplay;
			targetRow.StockCountMax = sourceRow.StockCountMax;
			targetRow.StockCountMin = sourceRow.StockCountMin;
			targetRow.StockPriceDisplay = sourceRow.StockPriceDisplay;
			targetRow.TaxDiv = sourceRow.TaxDiv;
			targetRow.CanTaxDivChange = sourceRow.CanTaxDivChange;
            targetRow.StockPriceDiectInput = sourceRow.StockPriceDiectInput;


            targetRow.EditStatus = sourceRow.EditStatus;
            targetRow.RowStatus = ctROWSTATUS_NORMAL;

			#endregion

			return targetRow;
		}

        #region �x���f�[�^����֘A
        /// <summary>
        /// �x���f�[�^�A�x�����׃f�[�^����A�x���f�[�^(�o�^�p)�𐶐����܂��B
        /// </summary>
        /// <param name="paymentSlp">�x���f�[�^</param>
        /// <param name="paymentDtlList">�x�����׃f�[�^</param>
        /// <returns>�x���f�[�^(�o�^�p)</returns>
        private PaymentDataWork CreatePaymentDataWork( PaymentSlp paymentSlp, List<PaymentDtl> paymentDtlList)
        {
            PaymentDataWork paymentDataWork = new PaymentDataWork();

            PaymentSlpWork paymentSlpWork = (PaymentSlpWork)DBAndXMLDataMergeParts.CopyPropertyInClass(paymentSlp, typeof(PaymentSlpWork));

            List<PaymentDtlWork> paymentDtlWorkList = new List<PaymentDtlWork>();
            foreach (PaymentDtl paymentDtl in paymentDtlList)
            {
                paymentDtlWorkList.Add((PaymentDtlWork)DBAndXMLDataMergeParts.CopyPropertyInClass(paymentDtl, typeof(PaymentDtlWork)));
            }
            PaymentDtlWork[] paymentDtlWorkArray = paymentDtlWorkList.ToArray();
            PaymentDataUtil.Union(out paymentDataWork, paymentSlpWork, paymentDtlWorkArray);

            return paymentDataWork;
        }

        /// <summary>
        /// �x���f�[�^(�o�^�p)�𕪊����A�x���f�[�^�A�x�����׃f�[�^�𐶐����܂��B
        /// </summary>
        /// <param name="paymentDataWork">�x���f�[�^</param>
        /// <param name="paymentSlp">�x���f�[�^</param>
        /// <param name="paymentDtlList">�x�����׃��X�g</param>
        private void DivisionPaymentDataWork( PaymentDataWork paymentDataWork, out PaymentSlp paymentSlp, out List<PaymentDtl> paymentDtlList )
        {
            paymentSlp = new PaymentSlp();
            paymentDtlList = new List<PaymentDtl>();

            if (paymentDataWork == null) return;

            PaymentSlpWork paymentSlpWork;
            PaymentDtlWork[] paymentDtlWorkArray;
            PaymentDataUtil.Division(paymentDataWork, out paymentSlpWork, out paymentDtlWorkArray);

            paymentSlp = ( paymentSlpWork != null ) ? (PaymentSlp)DBAndXMLDataMergeParts.CopyPropertyInClass(paymentSlpWork, typeof(PaymentSlp)) : new PaymentSlp();

            if (( paymentDtlWorkArray != null ) && ( paymentDtlWorkArray.Length > 0 ))
            {
                foreach (PaymentDtlWork paymentDtlWork in paymentDtlWorkArray)
                {
                    paymentDtlList.Add((PaymentDtl)DBAndXMLDataMergeParts.CopyPropertyInClass(paymentDtlWork, typeof(PaymentDtl)));
                }
            }

        }
        #endregion

        /// <summary>
        /// ���i�A���f�[�^���X�g���A�w�肳�ꂽ���i�̏����擾���܂��B
        /// </summary>
        /// <param name="goodsNo">���i�R�[�h</param>
        /// <param name="goodsMakerCd">���[�J�[�R�[�h</param>
        /// <param name="goodsUnitDataList">���i���f�[�^���X�g</param>
        /// <returns>���i���f�[�^</returns>
        private GoodsUnitData GetGoodsUnitDataFromList( string goodsNo, int goodsMakerCd, List<GoodsUnitData> goodsUnitDataList )
        {
            foreach (GoodsUnitData goodsUnitData in goodsUnitDataList)
            {
                if (( goodsUnitData.GoodsMakerCd == goodsMakerCd ) && ( goodsUnitData.GoodsNo == goodsNo ))
                {
                    return goodsUnitData;
                }
            }
            return null;
		}

		/// <summary>
		/// �������ʋ敪�ɏ]���āA���������N���A���܂��B
		/// </summary>
		/// <param name="row"></param>
		private void MemoInfoAdjust( ref StockInputDataSet.StockDetailRow row )
		{
			// �������ʋ敪�ɂ���ď�������
			switch (this._stockSlipInputInitDataAcs.GetAllDefSet().MemoMoveDiv)
			{
				// �S��
				case (int)MemoMoveDiv.All:
					{
						break;
					}
				// �`�[�����̂�
				case (int)MemoMoveDiv.SlipMemoOnly:
					{
						row.InsideMemo1 = string.Empty;
                        row.InsideMemo2 = string.Empty;
                        row.InsideMemo3 = string.Empty;
						break;
					}
				// ���Ȃ�
				case (int)MemoMoveDiv.None:
					{
                        row.InsideMemo1 = string.Empty;
                        row.InsideMemo2 = string.Empty;
                        row.InsideMemo3 = string.Empty;
                        row.SlipMemo1 = string.Empty;
                        row.SlipMemo2 = string.Empty;
                        row.SlipMemo3 = string.Empty;
						break;
					}
			}
		}
        # endregion

        #region �����i�f�B�N�V���i���̑���

        /// <summary>
        /// ���i�L���b�V�����N���A
        /// </summary>
        private void ClearGoodsCacheInfo()
        {
            this._goodsDictionary.Clear();
        }

        /// <summary>
        /// ���i���L���b�V������
        /// </summary>
        /// <param name="goodsUnitData">���i�A���f�[�^</param>
        private void CacheGoodsUnitData(GoodsUnitData goodsUnitData)
        {
            string goodsKey = string.Format("{0,-40}{1,6}", goodsUnitData.GoodsNo, goodsUnitData.GoodsMakerCd);

            if (this._goodsDictionary.ContainsKey(goodsKey))
            {
                this._goodsDictionary[goodsKey] = goodsUnitData.Clone();
            }
            else
            {
                this._goodsDictionary.Add(goodsKey, goodsUnitData.Clone());
            }
        }

        /// <summary>
        /// ���i���L���b�V������
        /// </summary>
        /// <param name="goodsUnitDataList"></param>
        private void CacheGoodsUnitData(List<GoodsUnitData> goodsUnitDataList)
        {
            foreach (GoodsUnitData goodsUnitData in goodsUnitDataList)
            {
                this.CacheGoodsUnitData(goodsUnitData);
            }
        }

        /// <summary>
        /// ���i�L���b�V�����폜
        /// </summary>
        /// <param name="goodsUnitData">���i�A���f�[�^</param>
        private void DeleteGoodsCacheInfo(GoodsUnitData goodsUnitData)
        {
            string goodsKey = string.Format("{0,-40}{1,6}", goodsUnitData.GoodsNo, goodsUnitData.GoodsMakerCd);
            if (this._goodsDictionary.ContainsKey(goodsKey))
            {
                this._goodsDictionary.Remove(goodsKey);
            }
        }

        /// <summary>
        /// ���i���擾
        /// </summary>
        /// <param name="goodsNo"></param>
        /// <param name="goodsMakerCd"></param>
        /// <returns></returns>
        private GoodsUnitData GetGoodsUnitDataFromCache(string goodsNo, int goodsMakerCd)
        {
            string goodsKey = string.Format("{0,-40}{1,6}", goodsNo, goodsMakerCd);
            return ( this._goodsDictionary.ContainsKey(goodsKey) ) ? this._goodsDictionary[goodsKey] : null;
        }

        #endregion

        // ------ ADD 2017/08/11 杍^ �n���f�B�^�[�~�i���񎟊J�� --------- >>>>
        #region ���n���f�B�^�[�~�i���݌Ɏd���o�^�̑Ή�
        // ===================================================================================== //
        // �R���X�g���N�^�i�n���f�B�^�[�~�i���p�j
        // ===================================================================================== //
        # region ��Constracter
        /// <summary>
        /// �R���X�g���N�^�i�n���f�B�^�[�~�i���p�j
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="count">�d���f�[�^����</param>
        /// <param name="status">�������X�e�[�^�X�u0�F����  0�ȊO�F���s�v</param>
        /// <remarks>
        /// <br>Note       : �N���X�̐V�����C���X�^���X�����������܂��B�i�n���f�B�^�[�~�i���p�j</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2017/08/11</br>
        /// </remarks>
        public StockSlipInputAcs(string enterpriseCode, string sectionCode, int count, out int status)
        {
            status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            try
            {
                // �ϐ�������
                this._dataSet = new StockInputDataSet();
                this._stockDetailDataTable = this._dataSet.StockDetail;
                this._addUpSrcDetailDataTable = this._dataSet.AddUpSrcDetail;
                this._salesTempDataTable = this._dataSet.SalesTemp;
                this._addUpSrcSalesSlipDataTable = this._dataSet.AddUpSrcSalesSlip;
                this._addUpSrcSalesDetailDataTable = this._dataSet.AddUpSrcSalesDetail;
                this._stockInfoDataTable = this._dataSet.StockInfo;
                this._stockSlip = new StockSlip();
                this._stockSlipDBData = new StockSlip();
                this._stockDetailDBDataList = new List<StockDetail>();
                this._unitPriceCalculation = new UnitPriceCalculation();

                this._stockPriceCalculate = new StockPriceCalculate();
                this._stockSlipInputInitDataAcs = new StockSlipInputInitDataAcs(out status);
                // �d�����͗p�����l�擾�A�N�Z�X�N���X���������s�ꍇ
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    return;
                }

                status = this._stockSlipInputInitDataAcs.ReadInitDataForHandy(enterpriseCode, sectionCode);
                // �d�����͗p�����l��}�X�^�f�[�^�擾���s�ꍇ
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    return;
                }

                this._stockSlipInputInitDataAcs.CacheStockProcMoneyList += new StockSlipInputInitDataAcs.CacheStockProcMoneyListEventHandler(this._stockPriceCalculate.CacheStockProcMoneyList);
                this._stockSlipInputInitDataAcs.CacheStockProcMoneyList += new StockSlipInputInitDataAcs.CacheStockProcMoneyListEventHandler(this._unitPriceCalculation.CacheStockProcMoneyList);

                this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
                this._paymentSlp = new PaymentSlp();
                this._paymentDtlList = new List<PaymentDtl>();
                // �d�����͗p���[�U�[�ݒ�N���X������
                this._stockInputConstructionAcs = new StockSlipInputConstructionAcs(ConstructorsModeHandy);
                this._goodsDictionary = new Dictionary<string, GoodsUnitData>();

                this._stockDetailDataView = new DataView(this._stockDetailDataTable);

                this.StockDetailRowInitialSetting(count);

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            
        }
        #endregion

        /// <summary>
        /// �d����`�[�ԍ��̏d���`�F�b�N�i�n���f�B�^�[�~�i���p�j
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="supplierSlipNo">�d����`�[�ԍ�</param>
        /// <param name="supplierCd">�d����R�[�h</param>
        /// <returns>�`�F�b�N���ʃX�e�[�^�X�u0�F�d��  4�F�d���Ȃ�  810�F�^�C���A�E�g  ��L�ȊO�F�G���[�v</returns>
        /// <remarks>
        /// <br>Note       : �d����`�[�ԍ����d���`�F�b�N���܂��B�i�n���f�B�^�[�~�i���p�j</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2017/08/11</br>
        /// </remarks>
        public int ReadStockSlipForHandy(string enterpriseCode, string sectionCode, string supplierSlipNo, int supplierCd)
        {
            List<StockSlip> stockSlipList = null;
            // �p�����[�^�����F��ƃR�[�h�A�d���`��(0�Œ�)�A���_�R�[�h�A�d����`�[�ԍ��A�Ώۓ�(�V�X�e�����t)�A�d����R�[�h�A�����`�Ԃ̌������[�h(0�Œ�)
            return this.ReadStockSlip(enterpriseCode, 0, sectionCode, supplierSlipNo, DateTime.Today, supplierCd, 0, out stockSlipList);
        }

        /// <summary>
        /// �����c�Ɖ�[�N�I�u�W�F�N�g���X�g�����ɁA�d�����׃f�[�^�s�I�u�W�F�N�g�ɏ��i�A�݌ɏ��A������������ꊇ�ݒ肵�܂��B
        /// </summary>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="addOrderListResultWorkList">�����c�Ɖ�[�N���X�g</param>
        /// <returns>�ݒ茋�ʃX�e�[�^�X�u0�F����  0�ȊO�F���s�v</returns>
        /// <remarks>
        /// <br>Note       : �N���X�̐V�����C���X�^���X�����������܂��B�i�n���f�B�^�[�~�i���p�j</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2017/08/11</br>
        /// </remarks>
        public int StockDetailRowSettingFromOrderListResultWorkListForHandy(string sectionCode, List<OrderListResultWork> addOrderListResultWorkList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            // �d���f�[�^�����C���X�^���X�擾����
            this.CreateStockSlipInitialData(SupplierFormalSupplier, AccPayDivCdNone, StockGoodsCdGoods, false);

            Supplier supplier;
            if (this._supplierAcs == null) this._supplierAcs = new SupplierAcs();
            status = this._supplierAcs.Read(out supplier, this._enterpriseCode, ((OrderListResultWork)addOrderListResultWorkList[0]).SupplierCd);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (supplier != null)
                {
                    // ���Ӑ�i�d����j���ݒ菈��
                    this.DataSettingStockSlip(ref this._stockSlip, supplier);

                    // �d�����׃f�[�^�Z�b�e�B���O�����i�ېŋ敪�ݒ�j
                    this.StockDetailRowTaxationCodeSetting(this._stockSlip.SuppCTaxLayCd, this._stockSlip.SuppTtlAmntDspWayCd);
                }
            }

            // �ŗ����擾���܂��B
            this._stockSlip.SupplierConsTaxRate = this._stockSlipInputInitDataAcs.GetTaxRate(DateTime.Today);

            List<int> settingStockRowNoList = new List<int>();
            status = this.StockDetailRowSettingFromOrderListResultWorkList(1, addOrderListResultWorkList, StockSlipInputAcs.WayToDetailExpand.AddUp, (StockSlipInputAcs.MemoMoveDiv)this._stockSlipInputInitDataAcs.GetAllDefSet().MemoMoveDiv, out settingStockRowNoList);

            return status;
        }


        #endregion

        /// <summary>
        /// UOE�����f�[�^�̕␳�i�n���f�B�^�[�~�i���p�j
        /// </summary>
        /// <param name="inspectDataAddList">���i�o�^�f�[�^</param>
        /// <returns>�␳�X�e�[�^�X�u0�F����  0�ȊO�F���s�v</returns>
        /// <remarks>
        /// <br>Note       : UOE�����f�[�^�̍X�V�敪�A���i����␳���܂��B�i�n���f�B�^�[�~�i���p�j</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2017/08/11</br>
        /// </remarks>
        public int SetInspectDataForHandy(ArrayList inspectDataAddList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                // ���i�o�^�f�[�^���Ȃ��ꍇ
                if (inspectDataAddList == null || inspectDataAddList.Count == 0)
                {
                    return status;
                }

                string errMessage = string.Empty;
                object searchObj = LoadAssembly(AssemblyIdPmhnd01114d, AssemblyIdPmhnd01114dClassName, out errMessage);
                // ���i�o�^�����I�u�W�F�N�g���Ȃ��ꍇ
                if (searchObj == null)
                {
                    return status;
                }

                Type searchType = searchObj.GetType();

                // �d�����גʔ�
                string partySaleSlipNum = (string)searchType.GetProperty(PartySaleSlipNum).GetValue(inspectDataAddList[0], null);
                this._stockSlip.PartySaleSlipNum = partySaleSlipNum;

                // ���i�o�^���[�N�^�C�v���擾���܂��B
                for (int i = 0; i < inspectDataAddList.Count; i++)
                {
                    // �d�����גʔ�
                    long stockSlipDtlNum = (long)searchType.GetProperty(StockSlipDtlNum).GetValue(inspectDataAddList[i], null);
                    // ���i��
                    double inspectCnt = (double)searchType.GetProperty(InspectCnt).GetValue(inspectDataAddList[i], null);

                    string filter = string.Format("{0}={1}",
                                this._stockDetailDataTable.StockSlipDtlNumSrcColumn, stockSlipDtlNum);

                    StockInputDataSet.StockDetailRow[] stockDetailRow =
                        (StockInputDataSet.StockDetailRow[])this._stockDetailDataTable.Select(filter);

                    if (stockDetailRow.Length > 0)
                    {
                        // _gridMainTable.DivCd�Ɉ���.�X�V�敪���Z�b�g����B
                        stockDetailRow[0].StockCount = inspectCnt;
                        stockDetailRow[0].OrderCnt = inspectCnt;
                        stockDetailRow[0].OrderRemainCnt = inspectCnt;
                        stockDetailRow[0].StockCountDisplay = inspectCnt;
                        // _gridMainTable.InputEnterCnt�Ɉ���.���i�����Z�b�g����B
                        stockDetailRow[0].ShipmentPosCntDisplay = stockDetailRow[0].ShipmentPosCnt + inspectCnt;
                        // �d�����׋��z�ݒ菈��
                        this.CalculateStockPrice(stockDetailRow[0]);
                    }
                }

                // �d�����v���z�ݒ菈��
                this.TotalPriceSetting(ref this._stockSlip, true);

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            return status;
        }

        /// <summary>
        /// �d���ۑ��p�f�[�^�̍쐬����
        /// </summary>
        /// <param name="employeeCode">�]�ƈ��R�[�h</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="saveDataObj">�d���ۑ��p�f�[�^�I�u�W�F�N�g</param>
        /// <returns>�쐬���ʃX�e�[�^�X�u0�F����  0�ȊO�F���s�v</returns>
        /// <remarks>
        /// <br>Note       : �d���ۑ��p�f�[�^���쐬���܂��B�i�n���f�B�^�[�~�i���p�j</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2017/08/11</br>
        /// </remarks>
        public int GetSaveDataForHandy(string employeeCode, string sectionCode, out object saveDataObj)
        {
            List<StockDetail> stockDetailList;
            List<StockDetail> addUpSrcDetailList = new List<StockDetail>();
            List<SalesTemp> salesTempList = new List<SalesTemp>();
            List<SalesTemp> savedSalesTempList = new List<SalesTemp>();
            PaymentSlp paymentSlp = null;
            List<PaymentDtl> paymentDtlList = null;

            this.GetCurrentStockDetail(out stockDetailList, out salesTempList, out savedSalesTempList);

            this.ClearGoodsCacheInfo();
            this.ReSearchGoods();

            this.GetCurrentPaymentData(this._stockSlip, out paymentSlp, out paymentDtlList);

            return this.GetSaveDataForHandyProc(sectionCode, employeeCode, this._stockSlip, stockDetailList, addUpSrcDetailList, paymentSlp, paymentDtlList, salesTempList, savedSalesTempList, out saveDataObj);
        }

        /// <summary>
        /// �d���ۑ��p�f�[�^�̍쐬�̏ڍ׏���
        /// </summary>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="employeeCode">�]�ƈ��R�[�h</param>
        /// <param name="stockSlip">�d���f�[�^�I�u�W�F�N�g</param>
        /// <param name="stockDetailList">�d�����׃f�[�^���X�g�I�u�W�F�N�g</param>
        /// <param name="addUpSrcDetailList">�v�㌳�d�����׃f�[�^���X�g�I�u�W�F�N�g</param>
        /// <param name="paymentSlp">�x���f�[�^�I�u�W�F�N�g</param>
        /// <param name="paymentDtlList">�x�����׃f�[�^�I�u�W�F�N�g���X�g</param>
        /// <param name="salesTempList">��������f�[�^���X�g</param>
        /// <param name="savedSalesTempList">�ۑ��ς݂̓�������f�[�^�I�u�W�F�N�g</param>
        /// <param name="dataObj">�d���ۑ��p�f�[�^�I�u�W�F�N�g</param>
        /// <returns>�쐬���ʃX�e�[�^�X�u0�F����  0�ȊO�F���s�v</returns>
        /// <remarks>
        /// <br>Note       : �d���ۑ��p�f�[�^���쐬���܂��B�i�n���f�B�^�[�~�i���p�j</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2017/08/11</br>
        /// </remarks>
        private int GetSaveDataForHandyProc(string sectionCode, string employeeCode, StockSlip stockSlip, List<StockDetail> stockDetailList, List<StockDetail> addUpSrcDetailList, PaymentSlp paymentSlp, List<PaymentDtl> paymentDtlList, List<SalesTemp> salesTempList, List<SalesTemp> savedSalesTempList, out object dataObj)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            dataObj = null;

            try
            {
                //------------------------------------------------------------------------------------
                // �������ݎ���CustomSerializeArrayList�̍\��
                //------------------------------------------------------------------------------------
                //  CustomSerializeArrayList            �������݃p�����[�^���X�g
                //      --IOWriteCtrlOptWork			IOWrite���䃏�[�N�I�u�W�F�N�g
                //      --CustomSerializeArrayList      �d�����X�g
                //          --SalesSlipWork             �d���f�[�^�I�u�W�F�N�g
                //          --ArrayList                 �d�����׃��X�g
                //              --SalesDetailWork       �d�����׃f�[�^�I�u�W�F�N�g
                //          --DepsitMainWork            �x���f�[�^�I�u�W�F�N�g
                //      --CustomSerializeArrayList      ����������
                //          --SalesTempWork             �������͔���f�[�^�I�u�W�F�N�g
                //------------------------------------------------------------------------------------
                CustomSerializeArrayList dataList = new CustomSerializeArrayList();

                IOWriteCtrlOptWork iOWriteCtrlOptWork = this.GetIOWriteCtrlOptWork();

                //==========<< �d�����X�g�̃Z�b�g >>==========//
                CustomSerializeArrayList stockSlipDataList = new CustomSerializeArrayList();

                // �@�d���f�[�^�̕␳
                stockSlip.EnterpriseCode = this._enterpriseCode;
                stockSlip.SectionCode = sectionCode;
                stockSlip.InputDay = DateTime.Today;
                stockSlip.StockSlipUpdateCd = (stockSlip.SupplierSlipNo == 0) ? 0 : 1;    // �d���`�[�X�V�敪
                stockSlip.DetailRowCount = stockDetailList.Count;
                stockSlip.StockInputCode = employeeCode;
                stockSlip.StockInputName = this._stockSlipInputInitDataAcs.GetName_FromEmployee(employeeCode);
                stockSlip.StockAgentCode = employeeCode;
                stockSlip.StockAgentName = stockSlip.StockInputName;

                if ((paymentSlp != null) && (paymentDtlList != null) && (paymentDtlList.Count > 0))
                    stockSlip.AutoPayment = 1;

                // �A�d�����׃f�[�^���[�N�N���X���X�g�A����
                ArrayList stockDetailArrayList = new ArrayList();
                ArrayList slipDetailAddInfoWorkList = new ArrayList();

                foreach (StockDetail stockDetail in stockDetailList)
                {
                    stockDetail.EnterpriseCode = this._enterpriseCode;
                    stockDetail.SectionCode = stockSlip.SectionCode;
                    stockDetail.SupplierFormal = stockSlip.SupplierFormal;
                    stockDetail.SupplierSlipNo = stockSlip.SupplierSlipNo;
                    stockDetail.DtlRelationGuid = Guid.NewGuid();

                    stockDetail.StockInputCode = stockSlip.StockInputCode;
                    stockDetail.StockInputName = stockSlip.StockInputName;
                    stockDetail.StockAgentCode = stockSlip.StockAgentCode;
                    stockDetail.StockAgentName = stockSlip.StockAgentName;

                    // �d���݌Ɏ�񂹋敪
                    stockDetail.StockOrderDivCd = (string.IsNullOrEmpty(stockDetail.WarehouseCode.Trim())) ? 0 : 1;
                    if (stockDetail.StockSlipDtlNumSrc == 0) stockDetail.SupplierFormalSrc = -1;

                    stockDetailArrayList.Add(ConvertStockSlip.ParamDataFromUIData(stockDetail));

                    // ���גǉ����
                    SlipDetailAddInfoWork slipDetailAddInfoWork = new SlipDetailAddInfoWork();
                    slipDetailAddInfoWork.DtlRelationGuid = stockDetail.DtlRelationGuid;		// ���׊֘A�t��GUID

                    // �i�ԁE���[�J�[�����͂���Ă��āA�d���s�̏ꍇ
                    if ((!string.IsNullOrEmpty(stockDetail.GoodsNo) && (stockDetail.GoodsMakerCd != 0)) && (stockDetail.StockSlipCdDtl == 0))
                    {
                        GoodsUnitData goodsUnitData = this.GetGoodsUnitDataFromCache(stockDetail.GoodsNo, stockDetail.GoodsMakerCd);

                        // ���i�����o�^�F����
                        if ((this._stockSlipInputInitDataAcs.GetStockTtlSt().AutoEntryGoodsDivCd == 1) &&
                            ((goodsUnitData == null) || (goodsUnitData.OfferKubun >= 3)))
                        {
                            if (goodsUnitData == null) goodsUnitData = new GoodsUnitData();

                            slipDetailAddInfoWork.GoodsEntryDiv = 1;                            // ���i�o�^�敪
                            slipDetailAddInfoWork.GoodsOfferDate = goodsUnitData.OfferDate;     // ���i�񋟓�

                            GoodsPrice goodsPrice = this._stockSlipInputInitDataAcs.GetGoodsPrice((stockSlip.SupplierFormal == 0) ? stockSlip.StockDate : stockSlip.ArrivalGoodsDay, goodsUnitData);
                            if (goodsPrice != null)
                            {
                                slipDetailAddInfoWork.PriceOfferDate = goodsPrice.OfferDate;    // ���i�񋟓�
                            }
                            slipDetailAddInfoWork.PriceStartDate = GetPriceStartDate(stockSlip); // ���i�J�n��
                            slipDetailAddInfoWork.PriceUpdateDiv = 1;
                        }
                        else
                        {
                            if ((goodsUnitData != null) && (goodsUnitData.OfferKubun < 3))
                            {
                                GoodsPrice goodsPrice = this._stockSlipInputInitDataAcs.GetGoodsPrice((stockSlip.SupplierFormal == 0) ? stockSlip.StockDate : stockSlip.ArrivalGoodsDay, goodsUnitData);

                                slipDetailAddInfoWork.PriceUpdateDiv = stockSlip.PriceCostUpdtDiv;			// ���i�X�V�敪
                                if (goodsPrice != null)
                                {
                                    slipDetailAddInfoWork.PriceStartDate = goodsPrice.PriceStartDate;       // ���i�J�n��
                                    slipDetailAddInfoWork.PriceOfferDate = goodsPrice.OfferDate;			// ���i�񋟓�
                                }
                                else
                                {
                                    slipDetailAddInfoWork.PriceStartDate = GetPriceStartDate(stockSlip);
                                }
                            }
                        }
                    }

                    slipDetailAddInfoWorkList.Add(slipDetailAddInfoWork);
                }

                stockSlipDataList.Add(ConvertStockSlip.ParamDataFromUIData(stockSlip));

                if (stockDetailArrayList.Count > 0) stockSlipDataList.Add(stockDetailArrayList);

                if (slipDetailAddInfoWorkList.Count > 0) stockSlipDataList.Add(slipDetailAddInfoWorkList);

                // �B�����x����񃏁[�N�N���X�Z�b�g
                if ((paymentSlp != null) && (paymentDtlList != null) && (paymentDtlList.Count > 0))
                {
                    stockSlipDataList.Add(this.CreatePaymentDataWork(paymentSlp, paymentDtlList));
                }

                //==========<< �������͔��ナ�X�g >>==========//
                CustomSerializeArrayList salesTempDataList = new CustomSerializeArrayList();

                ArrayList salesTempArrayList = new ArrayList();
                foreach (SalesTemp salesTemp in salesTempList)
                {
                    salesTemp.EnterpriseCode = this._enterpriseCode;
                    salesTemp.SectionCode = stockSlip.SectionCode;
                    salesTemp.SalesOrderDivCd = (!string.IsNullOrEmpty(salesTemp.WarehouseCode.Trim())) ? 1 : 0;
                    salesTempDataList.Add(ConvertStockSlip.ParamDataFromUIData(salesTemp));
                }


                // �������݃p�����[�^�̃Z�b�g
                dataList.Add(iOWriteCtrlOptWork);
                dataList.Add(stockSlipDataList);
                if (salesTempDataList.Count > 0) dataList.Add(salesTempDataList);

                dataObj = (object)dataList;
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            return status;
        }

        /// <summary>
        /// �A�Z���u���C���X�^���X��
        /// </summary>
        /// <param name="asmname">�A�Z���u������</param>
        /// <param name="classname">�N���X����</param>
        /// <param name="errMessage">�G���[���b�Z�[�W</param>
        /// <returns>�C���X�^���X�����ꂽ�N���X</returns>
        /// <remarks>
        /// <br>Note       : �w�肳�ꂽ�A�Z���u���y�уN���X�����A�N���X���C���X�^���X�����܂��B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2017/08/11</br>
        /// </remarks>
        private object LoadAssembly(string asmname, string classname, out string errMessage)
        {
            object obj = null;
            errMessage = string.Empty;

            try
            {
                System.Reflection.Assembly asm = System.Reflection.Assembly.Load(asmname);
                Type objType = asm.GetType(classname);
                // �C���X�^���X�^�C�v������ꍇ�A�C���X�^���X�I�u�W�F�N�g�𐶐����܂��B
                if (objType != null)
                {
                    obj = Activator.CreateInstance(objType);
                }
            }
            catch (Exception ex)
            {
                errMessage = ex.Message;
            }
            return obj;
        }
        // ------ ADD 2017/08/11 杍^ �n���f�B�^�[�~�i���񎟊J�� --------- <<<<

        // ------ ADD 2020/06/22 ���O PMKOBETSU-4017�̑Ή� --------- >>>>
        /// <summary>
        /// �d���捞�ݏ���
        /// </summary>
        /// <param name="stockFileName">�捞�t�@�C���p�X</param>
        /// <param name="errorNum">�G���[����</param>
        /// <param name="readNum">�Ǎ�����</param>
        /// <param name="logFileName">�G���[�t�@�C��</param>
        /// <param name="errMsg">�`�F�b�N�G���[���e</param>
        /// <param name="exErrMsg">��O�G���[���e</param>
        /// <returns>��������</returns>
        /// <remarks>
        /// <br>Note        : �f�[�^�X�V���X�g��������B</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2020/06/22</br>
        /// <br></br>
        /// </remarks>
        public int SearchStockData(string stockFileName, out int errorNum, out int readNum, out string logFileName, out string errMsg, out string exErrMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            // �G���[�t�@�C����
            logFileName = string.Empty;

            // �G���[���e
            errMsg = string.Empty;
            // ��O���b�Z�[�W
            exErrMsg = string.Empty;
            // �捞����
            readNum = 0;
            // �`�F�b�N�G���[����
            errorNum = 0;

            try
            {
                // �G���[����
                errorNum = 0;
                // �Ǎ�����
                readNum = 0;

                // �捞�t�@�C���̃t�H���_
                string folderName = System.IO.Path.GetDirectoryName(stockFileName);
                // �G���[�t�@�C����
                string newFileName = "�捞�t�@�C���G���[���X�g" + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".txt";
                logFileName = Path.Combine(folderName, newFileName);
                this.ErrFileName = logFileName;
                this.FileName = stockFileName;

                // �d���f�[�^�Ǎ�����
                status = SearchStockDataPro(stockFileName, out errorNum, out readNum, out errMsg, out exErrMsg);
            }
            catch (Exception ex)
            {
                // �G���[����
                errorNum = 0;
                // �Ǎ�����
                readNum = 0;
                exErrMsg = ex.Message.ToString();
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }

            return status;
        }

        /// <summary>
        /// �d���捞�ݏ���
        /// </summary>
        /// <param name="stockFileName">�捞�t�@�C���p�X</param>
        /// <param name="errorNum">�G���[����</param>
        /// <param name="readNum">�Ǎ�����</param>
        /// <param name="errMsg">�`�F�b�N�G���[���e</param>
        /// <param name="exErrMsg">��O�G���[���e</param>
        /// <returns>��������</returns>
        /// <remarks>
        /// <br>Note        : �f�[�^�X�V���X�g��������B</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2020/06/22</br>
        /// <br></br>
        /// </remarks>
        private int SearchStockDataPro(string stockFileName, out int errorNum, out int readNum, out string errMsg, out string exErrMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            // �G���[���e
            errMsg = string.Empty;
            // ��O���b�Z�[�W
            exErrMsg = string.Empty;
            // �捞����
            readNum = 0;
            // �`�F�b�N�G���[����
            errorNum = 0;

            try
            {
                // �Ǎ��f�[�^�t�@�C���`�F�b�N
                status = GetFileData(stockFileName, out errorNum, out readNum, out errMsg, out exErrMsg);
                if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    return status;
                }
            }
            catch (Exception e)
            {
                exErrMsg = e.Message;
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }

            return status;
        }

        /// <summary>
        /// �f�[�^�`�F�b�N����
        /// </summary>
        /// <param name="stockFileName">�捞�t�@�C���p�X</param>
        /// <param name="errorNum">�G���[����</param>
        /// <param name="readNum">�Ǎ�����</param>
        /// <param name="errMsg">�`�F�b�N�G���[���e</param>
        /// <param name="exErrMsg">��O�G���[���e</param>
        /// <returns>��������</returns>
        /// <remarks>
        /// <br>Note        : �f�[�^�`�F�b�N��������B</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2020/06/22</br>
        /// <br></br>
        /// </remarks>
        private int GetFileData(string stockFileName, out int errorNum, out int readNum, out string errMsg, out string exErrMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            // �G���[�f�[�^���X�g
            List<ErrTxtgetWork> errWorkList =new List<ErrTxtgetWork>();
            // �����捞�f�[�^
            CanDoStockDataWorkList = new List<InitDataItem>();

            // �G���[���e
            errMsg = string.Empty;
            // ��O���b�Z�[�W
            exErrMsg = string.Empty;
            // �捞����
            readNum = 0;
            // �`�F�b�N�G���[����
            errorNum = 0;
            bool firstLine = true;
            try
            {
                // �捞�f�[�^
                List<string[]> csvDataList = new List<string[]>();
                TextFieldParser parser = new TextFieldParser(stockFileName, Encoding.GetEncoding("Shift_JIS"));

                // ���[�U�[�敪������
                UserDiv = 0;

                // �捞�����J�n
                using (parser)
                {
                    parser.TextFieldType = FieldType.Delimited;
                    // ��؂蕶���̓R���}
                    parser.SetDelimiters(",");

                    //���C����CSV�̍s�̃f�[�^��ǂ�
                    while (!parser.EndOfData)
                    {
                        string[] row = parser.ReadFields(); // 1�s�ǂݍ���
                        csvDataList.Add(row);

                        // �P���R�[�h�ڂ̎󒍔ԍ���蓌�M�ԗ� OR ���̃��[�U�[�𔻒�
                        if (firstLine)
                        {
                            string acceptAnOrderNo = row[0].Trim();
                            firstLine = false;

                            // 1���R�[�h�ڂ̎󒍔ԍ����󗓂̏ꍇ�A���M�ȊO
                            if (string.IsNullOrEmpty(acceptAnOrderNo))
                            {
                                // 1:���M�ȊO
                                UserDiv = 1;
                            }
                        }
                    }
                }

                // �ėp�t�@�C����荞��
                InitDataItem initDataInfo = new InitDataItem();
                status = GetXmlDataInfo(ref initDataInfo, out errMsg);
                // XML�t�@�C���捞���s
                if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL && !string.IsNullOrEmpty(errMsg))
                {
                    return status;
                }
                else
                {
                    status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                }

                // �捞�f�[�^������99�̏ꍇ
                if (csvDataList.Count >= InPutMaxLength)
                {
                    status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                    errMsg = CT_ERROR_MEASSSAGE14;
                    return status;
                }
                // �捞�t�@�C�����̖��א����ݒ�̏���l(���[�U�[�ݒ���.���͍s��)�𒴂���ꍇ
                else if (csvDataList.Count > this._stockInputConstructionAcs.DataInputCountValue)
                {
                    status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                    errMsg = CT_ERROR_MEASSSAGE15;
                    return status;
                }
                else if (csvDataList.Count == 0)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                    errMsg = CT_ERROR_MEASSSAGE16;
                    return status;
                }

                // �捞����
                readNum = csvDataList.Count;

                // �捞�t�@�C���`�F�b�NOK��A�f�[�^�������s��
                if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    // �f�[�^�`�F�b�N
                    // [�͂�]�{�^��
                    if (TMsgDisp.Show(emErrorLevel.ERR_LEVEL_QUESTION, "MAKON01112AA", CT_ERROR_MEASSSAGE12, 0, MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        status = this.CheckData(csvDataList, ref errWorkList, initDataInfo, errMsg);
                    }
                    //�u�������v�{�^��
                    else
                    {
                        status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
                    }
                }

                // �`�F�b�N�G���[����
                errorNum = errWorkList.Count;
                this.ErrStockCount = errorNum;

                // �捞���s�̏ꍇ
                if (status == (int)ConstantManagement.MethodResult.ctFNC_ERROR)
                {
                    this.CanDoStockDataWorkList.Clear();
                }

                // �G���[�t�@�C���o��
                if (errWorkList.Count != 0)
                {
                    status = WriteErrorMsg(errWorkList, out exErrMsg);
                }
            }
            catch(Exception ex)
            {
                exErrMsg = ex.Message;
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }

            return status;
        }

        /// <summary>
        /// ���MDataTable��Columns��ǉ�����
        /// </summary>
        /// <param name="dataTable">����DataTable</param>
        /// <remarks>
        /// <br>Note        : DataTable��Columns��ǉ�����B</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2020/06/22</br>
        /// </remarks>
        private void CreateDataTableAnnual(ref DataTable dataTable)
        {
            dataTable = new DataTable();
            // �󒍔ԍ�
            dataTable.Columns.Add(CT_Col_AcceptAnOrderNo, typeof(string));
            dataTable.Columns[CT_Col_AcceptAnOrderNo].Caption = "�󒍔ԍ�";
            // ���i�R�[�h
            dataTable.Columns.Add(CT_Col_GoodsCode, typeof(string));
            dataTable.Columns[CT_Col_GoodsCode].Caption = "���i�R�[�h";
            // �o�א��ʇ@
            dataTable.Columns.Add(CT_Col_ShipmentCnt1, typeof(string));
            dataTable.Columns[CT_Col_ShipmentCnt1].Caption = "�o�א���";
            // �󒍒P��
            dataTable.Columns.Add(CT_Col_AcceptAnOrderUnCst, typeof(string));
            dataTable.Columns[CT_Col_AcceptAnOrderUnCst].Caption = "�󒍒P��";
            // ��(�V�X�e��)���t
            dataTable.Columns.Add(CT_Col_SysDate, typeof(string));
            dataTable.Columns[CT_Col_SysDate].Caption = "��(�V�X�e��)���t";
            // �G���[���e
            dataTable.Columns.Add(CT_Col_ErrContent, typeof(string));
            dataTable.Columns[CT_Col_ErrContent].Caption = "�G���[���e";
        }

        /// <summary>
        /// ���M�ȊO��DataTable��Columns��ǉ�����
        /// </summary>
        /// <param name="dataTable">����DataTable</param>
        /// <remarks>
        /// <br>Note        : DataTable��Columns��ǉ�����B</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2020/06/22</br>
        /// </remarks>
        private void CreateDataTable(ref DataTable dataTable)
        {
            dataTable = new DataTable();
            // �o�א��ʇ@
            dataTable.Columns.Add(CT_Col_ShipmentCnt1, typeof(string));
            dataTable.Columns[CT_Col_ShipmentCnt1].Caption = "�o�א���";
            // �󒍒P��
            dataTable.Columns.Add(CT_Col_AcceptAnOrderUnCst, typeof(string));
            dataTable.Columns[CT_Col_AcceptAnOrderUnCst].Caption = "�󒍒P��";
            // �d����
            dataTable.Columns.Add(CT_Col_SupplierCd, typeof(string));
            dataTable.Columns[CT_Col_SupplierCd].Caption = "�d����";
            // �d���`�[�ԍ�
            dataTable.Columns.Add(CT_Col_SupplierSlipNo, typeof(string));
            dataTable.Columns[CT_Col_SupplierSlipNo].Caption = "�`�[�ԍ�";
            // �i��
            dataTable.Columns.Add(CT_Col_GoodsNo, typeof(string));
            dataTable.Columns[CT_Col_GoodsNo].Caption = "�i��";
            // �G���[���e
            dataTable.Columns.Add(CT_Col_ErrContent, typeof(string));
            dataTable.Columns[CT_Col_ErrContent].Caption = "�G���[���e";
        }

        /// <summary>
        /// �G���[�f�[�^���t�@�C���ɏ�������
        /// </summary>
        /// <param name="errWorkList">�G���[�f�[�^</param>
        /// <param name="exErrMsg">��O���b�Z�[�W</param>
        /// <remarks>
        /// <br>Note        : �G���[�f�[�^���t�@�C���ɏ�������</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2020/06/22</br>
        /// </remarks>
        public int WriteErrorMsg(List<ErrTxtgetWork> errWorkList, out string exErrMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            exErrMsg = string.Empty;

            // �G���[�f�[�^�o�͗pDataTable��Columns��ǉ�����
            // ���M�ԗ��l
            if (UserDiv == 0)
            {
                this.CreateDataTableAnnual(ref ErrDataTable);
            }
            // ���M�ԗ��l�ȊO
            else
            {
                this.CreateDataTable(ref ErrDataTable);
            }

            // �o�͂��ꂽ��
            bool writeCheck = false;

            try
            {
                //�G���[�t�@�C���Ȃ�
                if (File.Exists(this.ErrFileName))
                {
                    writeCheck = true;
                }

                // �G���[���e
                string errContentStr = string.Empty;

                // �G���[�f�[�^���[�v
                foreach (ErrTxtgetWork errWork in errWorkList)
                {
                    DataRow dataRow = ErrDataTable.NewRow();
                    // ���M�ԗ��l
                    if (UserDiv == 0)
                    {
                        // �󒍔ԍ�
                        dataRow[CT_Col_AcceptAnOrderNo] = errWork.AcceptAnOrderNo;
                        // ���i�R�[�h
                        dataRow[CT_Col_GoodsCode] = errWork.GoodsCode;
                        // ��(�V�X�e��)���t
                        dataRow[CT_Col_SysDate] = errWork.SysDate;
                    }
                    // ���M�ԗ��l�ȊO
                    else
                    {
                        // �d����
                        dataRow[CT_Col_SupplierCd] = errWork.SupplierCd;
                        // �d���`�[�ԍ�
                        dataRow[CT_Col_SupplierSlipNo] = errWork.SupplierSlipNo;
                        // �i��
                        dataRow[CT_Col_GoodsNo] = errWork.GoodsNo;

                    }
                    // �o�א��ʇ@
                    dataRow[CT_Col_ShipmentCnt1] = errWork.ShipmentCnt1;
                    // �󒍒P��
                    dataRow[CT_Col_AcceptAnOrderUnCst] = errWork.AcceptAnOrderUnCst;
                    // �G���[���e
                    errContentStr = string.Empty;
                    foreach (string errMsg in errWork.Errormessage)
                    {
                        errContentStr += errMsg + ",";
                    }
                    dataRow[CT_Col_ErrContent] = errContentStr.Remove(errContentStr.LastIndexOf(","), 1);

                    ErrDataTable.Rows.Add(dataRow);
                }

                // CSV�o�͏�񏈗�
                FormattedTextWriter printInfo = new FormattedTextWriter();
                Object paraInfo = (object)printInfo;
                this.GetCSVInfo(ref paraInfo, ErrDataTable, this.ErrFileName, writeCheck);

                // �G���[�f�[�^�o��
                int TotalCount = 0;
                status = printInfo.TextOut(out TotalCount);
            }
            catch (Exception ex)
            {
                exErrMsg = ex.ToString();
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }

            return status;
        }

        /// <summary>
        /// CSV�o�͏�񏈗�
        /// </summary>
        /// <param name="parameter">�p�����[�^</param>
        /// <param name="dt">�f�[�^</param>
        /// <param name="outPutFileName">�o�̓p�[�X</param>
        /// <param name="outPutMode">�V�K���������f�t���O</param>
        /// <remarks>
        /// <br>Note        : �O���b�h�Ƀo�C���h������f�[�^�Z�b�g���擾���܂��B</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2020/06/22</br>
        /// </remarks>
        private void GetCSVInfo(ref object parameter, DataTable dt, string outPutFileName, bool outPutMode)
        {
            List<string> schemeList = new List<string>();
            // ���M�ԗ��̏ꍇ
            if (UserDiv == 0)
            {
                // �󒍔ԍ�
                schemeList.Add(CT_Col_AcceptAnOrderNo);
                // ���i�R�[�h
                schemeList.Add(CT_Col_GoodsCode);
                // �o�א��ʇ@
                schemeList.Add(CT_Col_ShipmentCnt1);
                // �󒍒P��
                schemeList.Add(CT_Col_AcceptAnOrderUnCst);
                // ��(�V�X�e��)���t
                schemeList.Add(CT_Col_SysDate);
            }
            // ���M�ԗ��ȊO�̏ꍇ
            else
            {
                // �o�א��ʇ@
                schemeList.Add(CT_Col_ShipmentCnt1);
                // �󒍒P��
                schemeList.Add(CT_Col_AcceptAnOrderUnCst);
                // �d����
                schemeList.Add(CT_Col_SupplierCd);
                // �d���`�[�ԍ�
                schemeList.Add(CT_Col_SupplierSlipNo);
                // �i��
                schemeList.Add(CT_Col_GoodsNo);
            }
            // �G���[���e
            schemeList.Add(CT_Col_ErrContent);

            Dictionary<string, int> maxLengthList = new Dictionary<string, int>();
             // ���M�ԗ��l
            if (UserDiv == 0)
            {
                maxLengthList.Add(CT_Col_AcceptAnOrderNo, 10);
                maxLengthList.Add(CT_Col_GoodsCode, 30);
                maxLengthList.Add(CT_Col_AcceptAnOrderUnCst, 12);
            }
            maxLengthList.Add(CT_Col_ShipmentCnt1, 12);
            // ���M�ԗ��l�ȊO
            if (UserDiv == 1)
            {
                // �d����
                maxLengthList.Add(CT_Col_SupplierCd, 6);
                // �d���`�[�ԍ�
                maxLengthList.Add(CT_Col_SupplierSlipNo,20);
                // �i��
                maxLengthList.Add(CT_Col_GoodsNo,30);
            }
            maxLengthList.Add(CT_Col_ErrContent, 50);

            List<Type> enclosingTypeList = new List<Type>();
            enclosingTypeList.Add("".GetType());
            enclosingTypeList.Add(typeof(System.Int32));
            enclosingTypeList.Add(typeof(System.Int64));
            enclosingTypeList.Add(typeof(System.Double));

            FormattedTextWriter formattedTextWriter = parameter as FormattedTextWriter;
            formattedTextWriter.DataSource = dt;
            formattedTextWriter.DataMember = String.Empty;
            //�e�L�X�g�t�@�C���o�̓p�X�̎擾
            formattedTextWriter.OutputFileName = outPutFileName;
            //�e�L�X�g�o�͂��鍀�ږ��̃��X�g
            formattedTextWriter.SchemeList = schemeList;
            formattedTextWriter.Splitter = ",";
            formattedTextWriter.Encloser = "\"";
            formattedTextWriter.EnclosingTypeList = enclosingTypeList;
            if (outPutMode)
            {
                formattedTextWriter.CaptionOutput = false;
                formattedTextWriter.OutputMode = true;
            }
            else
            {
                formattedTextWriter.CaptionOutput = true;
                formattedTextWriter.OutputMode = false;
            }
            formattedTextWriter.FixedLength = false;
            formattedTextWriter.ReplaceList = null;
            formattedTextWriter.FormatList = null;
            formattedTextWriter.MaxLengthList = maxLengthList;
        }

        /// <summary>
        /// �d���f�[�^����G���[�f�[�^�ɕϊ�
        /// </summary>
        /// <param name="initData">�d���f�[�^</param>
        /// <param name="errornote">�G���[���b�Z�[�W</param>
        /// <remarks>
        /// <br>Note        : �G���[�f�[�^�ɕϊ�����B</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2020/06/22</br>
        /// </remarks>
        public ErrTxtgetWork GetErrTxtWork(InitDataItem initData,List<string> errornote)
        {
            ErrTxtgetWork errwork = new ErrTxtgetWork();

            // �󒍔ԍ�
            errwork.AcceptAnOrderNo = initData.AcceptAnOrderNo;
            // ���i�R�[�h
            errwork.GoodsCode = initData.GoodsCode;
            // ����
            errwork.ShipmentCnt1 = initData.ShipmentCnt1;
            // �󒍒P��
            errwork.AcceptAnOrderUnCst = initData.AcceptAnOrderUnCst;
            // ��(�V�X�e��)���t
            errwork.SysDate = initData.SysDate;
            // �d����
            errwork.SupplierCd = initData.SupplierCd;
            // �i��
            errwork.GoodsNo = initData.GoodsNo;
            // �d���`�[�ԍ�
            errwork.SupplierSlipNo = initData.SupplierSlipNo;
            // �G���[���e
            errwork.Errormessage = errornote;

            return errwork;
        }

        /// <summary>
        /// XML�Ńf�[�^�̎擾
        /// </summary>
        /// <param name="initDataInfo">XML�f�[�^</param>
        /// <param name=" errMsg">�G���[���b�Z�[�W</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note        : XML�Ńf�[�^�̎擾���܂��B</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2020/06/22</br>
        /// <br>Update Note : 2021/12/19 ���O</br>
        /// <br>�Ǘ��ԍ�    : 11770181-00</br>
        /// <br>            : PMKOBETSU-4200 �ݒ�t�@�C���̕ۑ��ꏊ�Ǎ����Ԃ����ǑΉ�</br>
        /// </remarks>
        private int GetXmlDataInfo(ref InitDataItem initDataInfo, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            // �G���[���b�Z�[�W
            errMsg = string.Empty;
            // ------ ADD 2021/12/19 ���O PMKOBETSU-4200�̑Ή� --------- >>>>>
            string�@fileDir = ConstantManagement_ClientDirectory.NSCurrentDirectory;
            bool fileExist = false;
            // XML�t�@�C�����݃`�F�b�N
            if (UserSettingController.ExistUserSetting(Path.Combine(ConstantManagement_ClientDirectory.NSCurrentDirectory, XmlFileName)))
            {
                fileExist = true;
            }
            else if (UserSettingController.ExistUserSetting(Path.Combine(ConstantManagement_ClientDirectory.UISettings, XmlFileName)))
            {
                fileExist = true;
                fileDir = ConstantManagement_ClientDirectory.UISettings;
            }
            // ------ ADD 2021/12/19 ���O PMKOBETSU-4200�̑Ή� --------- <<<<<

            // XML�t�@�C�����݃`�F�b�N
            // ------ UPD 2021/12/19 ���O PMKOBETSU-4200�̑Ή� --------- >>>>>
            //if (UserSettingController.ExistUserSetting(Path.Combine(ConstantManagement_ClientDirectory.NSCurrentDirectory, XmlFileName)))
            if (fileExist)
            // ------ UPD 2021/12/19 ���O PMKOBETSU-4200�̑Ή� --------- <<<<<
            {
                try
                {
                    // ------ UPD 2021/12/19 ���O PMKOBETSU-4200�̑Ή� --------- >>>>>
                    //initDataInfo = UserSettingController.DeserializeUserSetting<InitDataItem>(Path.Combine(ConstantManagement_ClientDirectory.NSCurrentDirectory, XmlFileName));
                    initDataInfo = UserSettingController.DeserializeUserSetting<InitDataItem>(Path.Combine(fileDir, XmlFileName));
                    // ------ UPD 2021/12/19 ���O PMKOBETSU-4200�̑Ή� --------- <<<<<
                    // �d����R�[�h��荞�ݎ��s
                    if (string.IsNullOrEmpty(initDataInfo.SupplierCd))
                    {
                        // ��ʂɎd����R�[�h��ݒ肵�Ă��Ȃ��ꍇ
                        if (this._stockSlip.SupplierCd == 0)
                        {
                            // ���M�ԗ��̏ꍇ
                            if (UserDiv == 0)
                            {
                                errMsg = CT_ERROR_MEASSSAGE10;
                            }
                            status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                        }
                        // ��ʂɎd����R�[�h��ݒ肵�Ă���ꍇ
                        else
                        {
                            status = SetSecWarehouse(this._stockSlip.SupplierCd);
                            initDataInfo.SupplierCd = this._stockSlip.SupplierCd.ToString();
                        }
                    }
                    else
                    {
                        // �d����R�[�h
                        int supplierCdInt = 0;

                        // �����Őݒ肵�Ă���ꍇ
                        if (Int32.TryParse(initDataInfo.SupplierCd, out supplierCdInt))
                        {
                            status = SetSecWarehouse(supplierCdInt);

                            // �ėp�t�@�C���ɐݒ肳��Ă���d���悪�s���̏ꍇ
                            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                // ��ʂɎd����R�[�h��ݒ肵�Ă��Ȃ��ꍇ
                                if (this._stockSlip.SupplierCd == 0)
                                {
                                    // ���M�ԗ��̏ꍇ
                                    if (UserDiv == 0)
                                    {
                                        errMsg = CT_ERROR_MEASSSAGE13;
                                    }
                                    status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                                }
                                // ��ʂɎd����R�[�h��ݒ肵�Ă���ꍇ
                                else
                                {
                                    status = SetSecWarehouse(this._stockSlip.SupplierCd);
                                    initDataInfo.SupplierCd = this._stockSlip.SupplierCd.ToString();
                                }
                            }
                            else
                            {
                                // ����
                            }
                        }
                        else
                        {
                            // ��ʂɎd����R�[�h��ݒ肵�Ă��Ȃ��ꍇ
                            if (this._stockSlip.SupplierCd == 0)
                            {
                                // ���M�ԗ��̏ꍇ
                                if (UserDiv == 0)
                                {
                                    errMsg = CT_ERROR_MEASSSAGE13;
                                }
                                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                            }
                            // ��ʂɎd����R�[�h��ݒ肵�Ă���ꍇ
                            else
                            {
                                status = SetSecWarehouse(this._stockSlip.SupplierCd);
                                initDataInfo.SupplierCd = this._stockSlip.SupplierCd.ToString();
                            }
                        }
                    }
                }
                catch
                {
                    initDataInfo = new InitDataItem();
                    errMsg = CT_ERROR_MEASSSAGE11;
                    status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                }
            }
            else
            {
                errMsg = CT_ERROR_MEASSSAGE09;
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            return status;
        }

        /// <summary>
        /// �d����̊Ǘ����_�̑q�Ƀ��X�g�擾����
        /// </summary>
        /// <param name="supplierCdInt">�d����R�[�h</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note        : �d����̊Ǘ����_�̑q�Ƀ��X�g�擾�������s��</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2020/06/22</br>
        /// </remarks>
        private int SetSecWarehouse(int supplierCdInt)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

            // �d������
            Supplier supplier;
            if (this._supplierAcs == null) this._supplierAcs = new SupplierAcs();

            // �d������擾
            status = this._supplierAcs.Read(out supplier, this._enterpriseCode, supplierCdInt);

            // �d����ݒ�s���̏ꍇ
            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL ||
                (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && supplier.LogicalDeleteCode != 0))
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            else
            {
                // ���_�R�[�h
                string sectionCodeStr = string.Empty;

                // ��ʂɂĎd����R�[�h���͂��Ă��Ȃ��ꍇ
                if (this._stockSlip.SupplierCd == 0)
                {
                    // �d����̊Ǘ����_�ō݌Ƀ`�F�b�N���s��
                    sectionCodeStr = supplier.MngSectionCode;
                }
                // ��ʂɂĎd����R�[�h���͂��Ă���ꍇ
                else
                {
                    // ��ʂɂċ��_����͂��Ă��Ȃ��ꍇ
                    if (string.IsNullOrEmpty(this._stockSlip.StockSectionCd.Trim()))
                    {
                        // �d����̊Ǘ����_�ō݌Ƀ`�F�b�N���s��
                        sectionCodeStr = supplier.MngSectionCode;
                    }
                    else
                    {
                        // ��ʂ̋��_�ō݌Ƀ`�F�b�N���s��
                        sectionCodeStr = this._stockSlip.StockSectionCd.Trim();
                    }
                }

                // �d����̊Ǘ����_�̑q�Ƀ��X�g�擾
                SecInfoSet secInfoSet = this._stockSlipInputInitDataAcs.GetSecInfo(sectionCodeStr);
                if (secInfoSet != null)
                {
                    WarehouseDictionary = new Dictionary<string, string>();
                    if (!string.IsNullOrEmpty(secInfoSet.SectWarehouseCd1.Trim())) WarehouseDictionary.Add(secInfoSet.SectWarehouseCd1.Trim(), secInfoSet.SectWarehouseCd1.Trim());
                    if (!string.IsNullOrEmpty(secInfoSet.SectWarehouseCd2.Trim())) WarehouseDictionary.Add(secInfoSet.SectWarehouseCd2.Trim(), secInfoSet.SectWarehouseCd2.Trim());
                    if (!string.IsNullOrEmpty(secInfoSet.SectWarehouseCd3.Trim())) WarehouseDictionary.Add(secInfoSet.SectWarehouseCd3.Trim(), secInfoSet.SectWarehouseCd3.Trim());
                }

                status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            }

            return status;
        }

        /// <summary>
        /// �f�[�^�`�F�b�N����
        /// </summary>
        /// <param name="csvDataList">�捞�t�@�C��</param>
        /// <param name="errWorkList">�G���[�f�[�^���X�g</param>
        /// <param name="initDataInfo">XML�t�@�C���̃f�[�^</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>��������</returns>
        /// <remarks>
        /// <br>Note        : �f�[�^�`�F�b�N��������B</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2020/06/22</br>
        /// <br></br>
        /// </remarks>
        private int CheckData(List<string[]> csvDataList, ref List<ErrTxtgetWork> errWorkList, InitDataItem initDataInfo, string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

            SFCMN00299CA msgForm = new SFCMN00299CA();
            // �G���[���b�Z�[�W
            List<string> errorNote = null;
            // �e�L�X�g�捞�������X�g
            List<InitDataItem> initDataList = new List<InitDataItem>();
            int count = 0;

            try
            {
                msgForm.Title = "�f�[�^�捞��";
                msgForm.Show();
                msgForm.Message = "���݁A�f�[�^���捞���ł��B";

                // �捞�f�[�^
                FirstInitData = new InitDataItem();

                foreach(string[] arryLine in csvDataList)
                {
                    count++;

                    // �G���[���X�g
                    errorNote = new List<string>();
                    // �捞�f�[�^
                    InitDataItem initData = new InitDataItem();
                    // �G���[���O�o�͗p���[�N
                    ErrTxtgetWork errdata = new ErrTxtgetWork();

                    // ���ڐ��s���`�F�b�N
                    // ���M�ԗ��̏ꍇ
                    if ((arryLine.Length != 17 && UserDiv == 0) ||
                        // ���M�ԗ��ȊO�̏ꍇ
                        (arryLine.Length != 32 && UserDiv == 1))
                    {
                        errorNote.Add(CT_ERROR_MEASSSAGE00);
                        errdata.AcceptAnOrderNo = string.Empty;
                        errdata.GoodsCode = string.Empty;
                        errdata.ShipmentCnt1 = string.Empty;
                        errdata.AcceptAnOrderUnCst = string.Empty;
                        errdata.SysDate = string.Empty;
                        errdata.GoodsNo = string.Empty;
                        errdata.SupplierCd = string.Empty;
                        errdata.SupplierSlipNo = string.Empty;
                        errdata.Errormessage = errorNote;

                        errWorkList.Add(errdata);
                    }
                    else
                    {
                        // ���M�ԗ��̏ꍇ
                        if (UserDiv == 0)
                        {
                            #region �󒍔ԍ�
                            string acceptAnOrderNo = arryLine[0].Trim();
                            // �P���R�[�h�ڂ����������`�F�b�N���s��
                            if (count == 1)
                            {
                                initData.AcceptAnOrderNo = acceptAnOrderNo;
                                // ��������
                                if (initData.AcceptAnOrderNo.Length > 19)
                                {
                                    errorNote.Add(CT_ERROR_MEASSSAGE01);
                                }
                            }
                            else
                            {
                                initData.AcceptAnOrderNo = acceptAnOrderNo;
                            }
                            #endregion

                            #region ���i�R�[�h
                            string goodsCode = arryLine[2].Trim();
                            if (!string.IsNullOrEmpty(goodsCode))
                            {
                                initData.GoodsCode = goodsCode;
                            }
                            //�e�L�X�g�t�@�C���f�[�^�Ȃ� xml�t�@�C���̕��i�R�[�h����
                            else if (!string.IsNullOrEmpty(initDataInfo.GoodsCode))
                            {
                                initData.GoodsCode = initDataInfo.GoodsCode;
                            }
                            //xml�t�@�C���̕��i�R�[�h�Ȃ� xml�t�@�C���̕i�Ԃ���
                            else if (!string.IsNullOrEmpty(initDataInfo.GoodsNo))
                            {
                                initData.GoodsCode = initDataInfo.GoodsNo;
                            }
                            //�e�L�X�g�t�@�C���f�[�^�̕��i�R�[�h�Ȃ��Axml�t�@�C���̕��i�R�[�h�ƕi�ԂȂ�
                            else
                            {
                                errorNote.Add(CT_ERROR_MEASSSAGE02);
                            }
                            // ��������
                            if (initData.GoodsCode.Length > 24)
                            {
                                errorNote.Add(CT_ERROR_MEASSSAGE02);
                            }
                            //���p�`�F�b�N
                            else if (!HalfCheck(initData.GoodsCode))
                            {
                                errorNote.Add(CT_ERROR_MEASSSAGE02);
                            }
                            #endregion
                        }
                        // ���M�ԗ��ȊO�̏ꍇ
                        else
                        {
                            #region ���ד�
                            // ���t
                            DateTime dt = DateTime.MinValue;
                            // ���ד�
                            string arrivalGoodsDay = arryLine[20].Trim();
                            // �捞���R�[�h�̓��ד��ݒ肳��邩
                            bool inPutArrivalGoodsDayFlag = true;

                            try
                            {
                                dt = DateTime.ParseExact(arrivalGoodsDay, "yyyyMMdd", System.Globalization.CultureInfo.CurrentCulture);
                                // �捞���R�[�h�̓��ד��ݒ肳���ꍇ
                                initData.ArrivalGoodsDay = arrivalGoodsDay;
                            }
                            catch
                            {
                                // �捞���R�[�h�̓��ד��ݒ肳��Ȃ��ꍇ
                                inPutArrivalGoodsDayFlag = false;
                            }

                            // �捞���R�[�h�̓��ד��ݒ肳��Ȃ��ꍇ
                            if (!inPutArrivalGoodsDayFlag)
                            {
                                arrivalGoodsDay = initDataInfo.ArrivalGoodsDay;

                                try
                                {
                                    dt = DateTime.ParseExact(arrivalGoodsDay, "yyyyMMdd", System.Globalization.CultureInfo.CurrentCulture);
                                    // �ėpXML�t�@�C���̓��ד��ݒ肳���ꍇ
                                    initData.ArrivalGoodsDay = arrivalGoodsDay;
                                }
                                catch
                                {
                                    // �ėpXML�t�@�C���̓��ד��ݒ肳��Ȃ��ꍇ
                                    initData.ArrivalGoodsDay = DateTime.Now.ToString("yyyyMMdd"); ;
                                }
                            }
                            #endregion

                            #region �d����
                            // ���t
                            dt = DateTime.MinValue;
                            // �d����
                            string stockDate = arryLine[21].Trim();
                            // �捞���R�[�h�̎d�����ݒ肳��邩
                            bool inPutstockDateFlag = true;

                            try
                            {
                                dt = DateTime.ParseExact(stockDate, "yyyyMMdd", System.Globalization.CultureInfo.CurrentCulture);
                                // �捞���R�[�h�̎d�����ݒ肳���ꍇ
                                initData.StockDate = stockDate;
                            }
                            catch
                            {
                                // �捞���R�[�h�̎d�����ݒ肳��Ȃ��ꍇ
                                inPutstockDateFlag = false;
                            }

                            // �捞���R�[�h�̎d�����ݒ肳��Ȃ��ꍇ
                            if (!inPutstockDateFlag)
                            {
                                stockDate = initDataInfo.StockDate;

                                try
                                {
                                    dt = DateTime.ParseExact(stockDate, "yyyyMMdd", System.Globalization.CultureInfo.CurrentCulture);
                                    // �ėpXML�t�@�C���̎d�����ݒ肳���ꍇ
                                    initData.StockDate = stockDate;
                                }
                                catch
                                {
                                    // �ėpXML�t�@�C���̎d�����ݒ肳��Ȃ��ꍇ
                                    initData.StockDate = DateTime.Now.ToString("yyyyMMdd"); ;
                                }
                            }
                            #endregion

                            #region ���ה��l
                            // ���ה��l
                            initData.StockDtlSlipNote = arryLine[25].Trim();
                            if (!string.IsNullOrEmpty(initData.StockDtlSlipNote))
                            {
                                // ���ה��l
                                if (initData.StockDtlSlipNote.Length > 30)
                                {
                                    // ���ה��l
                                    initData.StockDtlSlipNote = initData.StockDtlSlipNote.Substring(0, 30);
                                }
                            }
                            else
                            {
                                // ���ה��l
                                if (initDataInfo.StockDtlSlipNote.Length > 30)
                                {
                                    // ���ה��l
                                    initData.StockDtlSlipNote = initDataInfo.StockDtlSlipNote.Substring(0, 30);
                                }
                                else
                                {
                                    // ���ה��l
                                    initData.StockDtlSlipNote = initDataInfo.StockDtlSlipNote;
                                }
                            }
                            #endregion

                            #region ����
                            // �Г������P
                            initData.InsideMemo1 = arryLine[26].Trim();
                            // �Г������Q
                            initData.InsideMemo2 = arryLine[27].Trim();
                            // �Г������R
                            initData.InsideMemo3 = arryLine[28].Trim();
                            // �ЊO�����P
                            initData.SlipMemo1 = arryLine[29].Trim();
                            // �ЊO�����Q
                            initData.SlipMemo2 = arryLine[30].Trim();
                            // �ЊO�����R
                            initData.SlipMemo3 = arryLine[31].Trim();
                            #endregion
                        }

                        #region �o�א��ʇ@
                        double doublenum = 0;
                        string shipmentCnt1 = arryLine[5].Trim();
                        if (!string.IsNullOrEmpty(shipmentCnt1))
                        {
                            initData.ShipmentCnt1 = shipmentCnt1;
                            // �_�u���^�f�[�^�`�F�b�N
                            if (Double.TryParse(shipmentCnt1, out doublenum))
                            {
                                // 0�̏ꍇ
                                if (doublenum == 0)
                                {
                                    errorNote.Add(CT_ERROR_MEASSSAGE05);
                                }
                            }
                            else
                            {
                                errorNote.Add(CT_ERROR_MEASSSAGE05);
                            }
                        }
                        // �e�L�X�g�t�@�C���f�[�^�Ȃ� XML�t�@�C���̏o�א��ʇ@����
                        else if (!string.IsNullOrEmpty(initDataInfo.ShipmentCnt1))
                        {
                            initData.ShipmentCnt1 = initDataInfo.ShipmentCnt1;
                            // �_�u���^�f�[�^�`�F�b�N
                            if (Double.TryParse(initDataInfo.ShipmentCnt1, out doublenum))
                            {
                                // 0�̏ꍇ
                                if (doublenum == 0)
                                {
                                    errorNote.Add(CT_ERROR_MEASSSAGE05);
                                }
                            }
                            else
                            {
                                errorNote.Add(CT_ERROR_MEASSSAGE05);
                            }

                        }
                        // �e�L�X�g�t�@�C���f�[�^�̏o�א��ʇ@�Ȃ��Axml�t�@�C���̏o�א��ʇ@�Ȃ�
                        else
                        {
                            doublenum = 0;
                            errorNote.Add(CT_ERROR_MEASSSAGE05);
                        }

                        // ��������
                        if (doublenum.ToString().Length > 10)
                        {
                            errorNote.Add(CT_ERROR_MEASSSAGE05);
                        }
                        // �͈̓`�F�b�N
                        else if (doublenum < -9999999.9 || doublenum > 9999999.9)
                        {
                            errorNote.Add(CT_ERROR_MEASSSAGE05);
                        }
                        #endregion

                        #region �󒍒P��
                        doublenum = 0;
                        string acceptAnOrderUnCst = arryLine[8].Trim();
                        // �e�L�X�g�t�@�C���f�[�^����
                        if (!string.IsNullOrEmpty(acceptAnOrderUnCst))
                        {
                            initData.AcceptAnOrderUnCst = acceptAnOrderUnCst;
                            // �_�u���^�f�[�^�`�F�b�N
                            if (!Double.TryParse(acceptAnOrderUnCst, out doublenum))
                            {
                                errorNote.Add(CT_ERROR_MEASSSAGE06);
                            }
                        }
                        else if (!string.IsNullOrEmpty(initDataInfo.AcceptAnOrderUnCst))
                        {
                            initData.AcceptAnOrderUnCst = initDataInfo.AcceptAnOrderUnCst;
                            // �_�u���^�f�[�^�`�F�b�N
                            if (!Double.TryParse(initDataInfo.AcceptAnOrderUnCst, out doublenum))
                            {
                                errorNote.Add(CT_ERROR_MEASSSAGE06);
                            }
                        }
                        else
                        {
                            doublenum = 0;
                            errorNote.Add(CT_ERROR_MEASSSAGE06);
                        }

                        // ��������
                        if (doublenum.ToString().Length > 10)
                        {
                            errorNote.Add(CT_ERROR_MEASSSAGE06);
                        }
                        // �͈̓`�F�b�N
                        else if (doublenum > 99999999.9 || doublenum < 0)
                        {
                            errorNote.Add(CT_ERROR_MEASSSAGE06);
                        }
                        #endregion

                        // ���M�ԗ��̏ꍇ
                        if (UserDiv == 0)
                        {
                            #region ��(�V�X�e��)���t
                            DateTime dt = DateTime.MinValue;
                            string sysDate = arryLine[11].Trim();

                            // �P���R�[�h�ڂ̏ꍇ
                            if (count == 1)
                            {
                                // �捞�t�@�C���Ɋ�(�V�X�e��)���t��ݒ肷��ꍇ
                                if (!string.IsNullOrEmpty(sysDate))
                                {
                                    initData.SysDate = sysDate;
                                    try
                                    {
                                        dt = DateTime.ParseExact(sysDate, "yyyyMMdd", System.Globalization.CultureInfo.CurrentCulture);
                                        initData.ArrivalGoodsDay = sysDate;
                                        initData.StockDate = sysDate;
                                    }
                                    catch
                                    {
                                        errorNote.Add(CT_ERROR_MEASSSAGE08);
                                    }
                                }
                                // �ėpXML�t�@�C���Ɋ�(�V�X�e��)���t��ݒ肷��ꍇ
                                else if (!string.IsNullOrEmpty(initDataInfo.SysDate))
                                {
                                    initData.SysDate = initDataInfo.SysDate;
                                    try
                                    {
                                        dt = DateTime.ParseExact(initDataInfo.SysDate, "yyyyMMdd", System.Globalization.CultureInfo.CurrentCulture);
                                        initData.ArrivalGoodsDay = initDataInfo.SysDate;
                                        initData.StockDate = initDataInfo.SysDate;
                                    }
                                    catch
                                    {
                                        errorNote.Add(CT_ERROR_MEASSSAGE08);
                                    }
                                }
                                else
                                {

                                    try
                                    {
                                        dt = DateTime.ParseExact(initDataInfo.ArrivalGoodsDay, "yyyyMMdd", System.Globalization.CultureInfo.CurrentCulture);
                                        // �ėpXML�t�@�C���ɓ��ד���ݒ肷��ꍇ
                                        initData.ArrivalGoodsDay = initDataInfo.ArrivalGoodsDay;
                                    }
                                    catch
                                    {
                                        initData.ArrivalGoodsDay = DateTime.Now.ToString("yyyyMMdd");
                                    }

                                    try
                                    {
                                        dt = DateTime.ParseExact(initDataInfo.StockDate, "yyyyMMdd", System.Globalization.CultureInfo.CurrentCulture);
                                        // �ėpXML�t�@�C���Ɏd������ݒ肷��ꍇ
                                        initData.StockDate = initDataInfo.StockDate;
                                    }
                                    catch
                                    {
                                        initData.StockDate = DateTime.Now.ToString("yyyyMMdd");
                                    }
                                }
                            }
                            else
                            {
                                initData.SysDate = FirstInitData.SysDate;
                                initData.ArrivalGoodsDay = FirstInitData.ArrivalGoodsDay;
                                initData.StockDate = FirstInitData.StockDate;
                            }
                            #endregion
                        }

                        // �P���R�[�h�ڂ݂̂̏ꍇ
                        if (count == 1)
                        {
                            #region �S����
                            // �S����
                            string stockAgentCode = string.Empty;
                            string stockAgentName = string.Empty;

                            // ���M�ԗ��̏ꍇ
                            if (UserDiv == 0)
                            {
                                // �S����
                                stockAgentCode = initDataInfo.StockAgentCode.Trim();
                                // �S���Җ���
                                stockAgentName = this._stockSlipInputInitDataAcs.GetName_FromEmployee(stockAgentCode);

                                // �ėpXML�̒S���ҕs���̏ꍇ
                                // ���O�C���]�ƈ����g�p
                                if (string.IsNullOrEmpty(stockAgentName))
                                {
                                    initData.StockAgentCode = LoginInfoAcquisition.Employee.EmployeeCode.Trim();
                                }
                                // �ėpXML�̒S���҂��g�p
                                else
                                {
                                    initData.StockAgentCode = stockAgentCode;
                                }
                            }
                            // ���M�ԗ��ȊO�̏ꍇ
                            else
                            {
                                // �S����
                                stockAgentCode = arryLine[17].Trim();
                                // �S���Җ���
                                stockAgentName = this._stockSlipInputInitDataAcs.GetName_FromEmployee(stockAgentCode);

                                // �P���R�[�h�ڂ̒S���ҕs���̏ꍇ
                                // �ėpXML�̒S���҂��g�p
                                if (string.IsNullOrEmpty(stockAgentName))
                                {
                                    // �S����
                                    stockAgentCode = initDataInfo.StockAgentCode.Trim();
                                    // �S���Җ���
                                    stockAgentName = this._stockSlipInputInitDataAcs.GetName_FromEmployee(stockAgentCode);

                                    // �ėpXML�̒S���ҕs���̏ꍇ
                                    // ���O�C���]�ƈ����g�p
                                    if (string.IsNullOrEmpty(stockAgentName))
                                    {
                                        initData.StockAgentCode = LoginInfoAcquisition.Employee.EmployeeCode.Trim();
                                    }
                                    // �ėpXML�̒S���҂��g�p
                                    else
                                    {
                                        initData.StockAgentCode = stockAgentCode;
                                    }
                                }
                                // �P���R�[�h�ڂ̒S���҂��g�p
                                else
                                {
                                    initData.StockAgentCode = stockAgentCode;
                                }
                            }
                            #endregion

                            #region �d����
                            // �d����
                            string supplierCdStr = string.Empty;
                            int supplierCdInt = 0;

                            // ���M�ԗ��̏ꍇ
                            if (UserDiv == 0)
                            {
                                initData.SupplierCd = initDataInfo.SupplierCd;
                            }
                            // ���M�ԗ��ȊO�̏ꍇ
                            else
                            {
                                initData.SupplierCd = arryLine[18].Trim();
                                int supplierCdStatus = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

                                // �P���R�[�h�ڂ̎d���悪�����̏ꍇ
                                if (Int32.TryParse(initData.SupplierCd, out supplierCdInt))
                                {
                                    // �d���悪���݂��邩
                                    supplierCdStatus = SetSecWarehouse(supplierCdInt);

                                    // ���Y�d���悪���݂��Ă��Ȃ��ꍇ
                                    if (supplierCdStatus != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                                    {
                                        initData.SupplierCd = initDataInfo.SupplierCd;

                                        // �ėpXML�܂��͉�ʂɎd���悪�����̏ꍇ
                                        if (Int32.TryParse(initDataInfo.SupplierCd, out supplierCdInt))
                                        {
                                            // �d���悪���݂��邩
                                            supplierCdStatus = SetSecWarehouse(supplierCdInt);

                                            // ���Y�d���悪���݂��Ă��Ȃ��ꍇ
                                            if (supplierCdStatus != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                                            {
                                                errorNote.Add(CT_ERROR_MEASSSAGE18);
                                            }
                                            // ���Y�d���悪���݂���ꍇ
                                            else
                                            {
                                                // ����
                                            }
                                        }
                                        else
                                        {
                                            errorNote.Add(CT_ERROR_MEASSSAGE18);
                                        }
                                    }
                                    // ���Y�d���悪���݂���ꍇ
                                    else
                                    {
                                        // ����
                                    }
                                }
                                // �P���R�[�h�ڂ̎d���悪�����ȊO�̏ꍇ
                                else
                                {
                                    initData.SupplierCd = initDataInfo.SupplierCd;

                                    // �ėpXML�܂��͉�ʂɎd���悪�����̏ꍇ
                                    if (Int32.TryParse(initDataInfo.SupplierCd, out supplierCdInt))
                                    {
                                        // �d���悪���݂��邩
                                        supplierCdStatus = SetSecWarehouse(supplierCdInt);

                                        // ���Y�d���悪���݂��Ă��Ȃ��ꍇ
                                        if (supplierCdStatus != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                                        {
                                            errorNote.Add(CT_ERROR_MEASSSAGE18);
                                        }
                                        // ���Y�d���悪���݂���ꍇ
                                        else
                                        {
                                            // ����
                                        }
                                    }
                                    else
                                    {
                                        errorNote.Add(CT_ERROR_MEASSSAGE18);
                                    }
                                }
                            }
                            #endregion

                            #region �`�[�敪
                            // �`�[�敪
                            string supplierSlipCd = string.Empty;

                            // ���M�ԗ��̏ꍇ
                            if (UserDiv == 0)
                            {
                                initData.SupplierSlipCd = StockDiv;
                            }
                            // ���M�ԗ��ȊO�̏ꍇ
                            else
                            {
                                // �`�[�敪
                                supplierSlipCd = arryLine[19].Trim();

                                // �P���R�[�h�ڂ̓`�[�敪���d���܂��͕ԕi�Őݒ肵�Ă���ꍇ
                                if (StockDiv.Equals(supplierSlipCd) || ReturnDiv.Equals(supplierSlipCd))
                                {
                                    initData.SupplierSlipCd = supplierSlipCd;
                                }
                                else
                                {
                                    // �ėpXML�t�@�C���̓`�[�敪
                                    supplierSlipCd = initDataInfo.SupplierSlipCd.Trim();

                                    // �ėpXML�t�@�C���̓`�[�敪���d���܂��͕ԕi�Őݒ肵�Ă���ꍇ
                                    if (StockDiv.Equals(supplierSlipCd) || ReturnDiv.Equals(supplierSlipCd))
                                    {
                                        initData.SupplierSlipCd = supplierSlipCd;
                                    }
                                    else
                                    {
                                        initData.SupplierSlipCd = StockDiv;
                                    }
                                }
                            }
                            #endregion
                        }
                        else
                        {
                            // ���M�ԗ��ȊO�̏ꍇ
                            if (UserDiv != 0)
                            {
                                // �d����
                                initData.SupplierCd = arryLine[18].Trim();
                            }
                        }

                        // ���M�ԗ��ȊO�̏ꍇ
                        if (UserDiv != 0)
                        {
                            #region �`�[�ԍ�
                            // �`�[�ԍ�
                            string supplierSlipNo = arryLine[22].Trim();

                            // �P���R�[�h�ڂ����������`�F�b�N���s��
                            if (count == 1)
                            {
                                // �`�[�ԍ�
                                if (!string.IsNullOrEmpty(supplierSlipNo))
                                {
                                    initData.SupplierSlipNo = supplierSlipNo;
                                }
                                // �捞�t�@�C���f�[�^�Ȃ� �ėpXML�t�@�C���̎d���`�[�ԍ����p����
                                else if (!string.IsNullOrEmpty(initDataInfo.SupplierSlipNo))
                                {
                                    initData.SupplierSlipNo = initDataInfo.SupplierSlipNo;
                                }
                                else
                                {
                                    errorNote.Add(CT_ERROR_MEASSSAGE07);
                                }
                                // ��������
                                if (initData.SupplierSlipNo.Length > 19)
                                {
                                    errorNote.Add(CT_ERROR_MEASSSAGE07);
                                }
                            }
                            else
                            {
                                initData.SupplierSlipNo = supplierSlipNo;
                            }
                            #endregion
                        }

                        #region �i��
                        // ���M�ԗ��l
                        if (UserDiv == 0)
                        {
                            initData.GoodsNo = initDataInfo.GoodsNo;
                        }
                        // ���M�ԗ��l�ȊO
                        else
                        {
                            string goodsNo = arryLine[23].Trim();
                            if (!string.IsNullOrEmpty(goodsNo))
                            {
                                initData.GoodsNo = goodsNo;
                                // ��������
                                if (initData.GoodsNo.Length > 24)
                                {
                                    errorNote.Add(CT_ERROR_MEASSSAGE17);
                                }
                                //���p�`�F�b�N
                                else if (!HalfCheck(initData.GoodsNo))
                                {
                                    errorNote.Add(CT_ERROR_MEASSSAGE17);
                                }
                            }
                            //�e�L�X�g�t�@�C���f�[�^�Ȃ� xml�t�@�C���̕i�Ԃ���
                            else if (!string.IsNullOrEmpty(initDataInfo.GoodsNo))
                            {
                                initData.GoodsNo = initDataInfo.GoodsNo;
                                // ��������
                                if (initData.GoodsNo.Length > 24)
                                {
                                    errorNote.Add(CT_ERROR_MEASSSAGE17);
                                }
                                //���p�`�F�b�N
                                else if (!HalfCheck(initData.GoodsNo))
                                {
                                    errorNote.Add(CT_ERROR_MEASSSAGE17);
                                }
                            }
                            else
                            {
                                errorNote.Add(CT_ERROR_MEASSSAGE17);
                            }
                            
                        }
                        #endregion

                        #region ���[�J�[
                        // ���M�ԗ��̏ꍇ
                        if (UserDiv == 0)
                        {
                            initData.GoodsMakerCd = initDataInfo.GoodsMakerCd;
                        }
                        // ���M�ԗ��ȊO�̏ꍇ
                        else
                        {
                            // ���[�J�[
                            string goodsMakerCdStr = arryLine[24].Trim();
                            int goodsMakerCdInt = 0;

                            // �P���R�[�h�ڂ̃��[�J�[���ݒ肳��Ă���ꍇ
                            if (Int32.TryParse(goodsMakerCdStr, out goodsMakerCdInt))
                            {
                                initData.GoodsMakerCd = goodsMakerCdStr;
                            }
                            // �P���R�[�h�ڂ̃��[�J�[���ݒ肳��Ă��Ȃ��ꍇ
                            else
                            {
                                initData.GoodsMakerCd = initDataInfo.GoodsMakerCd;
                            }
                        }
                        #endregion

                        #region ����
                        // �Г������P
                        if (!string.IsNullOrEmpty(initData.InsideMemo1))
                        {
                            if (initData.InsideMemo1.Length > 20)
                            {
                                // �Г������P
                                initData.InsideMemo1 = initData.InsideMemo1.Substring(0, 20);
                            }
                        }
                        else
                        {
                            // �ėpXML�̎Г������P���g�p
                            if (initDataInfo.InsideMemo1.Length > 20)
                            {
                                // �Г������P
                                initData.InsideMemo1 = initDataInfo.InsideMemo1.Substring(0, 20);
                            }
                            else
                            {
                                // �Г������P
                                initData.InsideMemo1 = initDataInfo.InsideMemo1;
                            }
                        }

                        // �Г������Q
                        if (!string.IsNullOrEmpty(initData.InsideMemo2))
                        {
                            if (initData.InsideMemo2.Length > 20)
                            {
                                // �Г������Q
                                initData.InsideMemo2 = initData.InsideMemo2.Substring(0, 20);
                            }
                        }
                        else
                        {
                            // �ėpXML�̎Г������Q���g�p
                            if (initDataInfo.InsideMemo2.Length > 20)
                            {
                                // �Г������Q
                                initData.InsideMemo2 = initDataInfo.InsideMemo2.Substring(0, 20);
                            }
                            else
                            {
                                // �Г������Q
                                initData.InsideMemo2 = initDataInfo.InsideMemo2;
                            }
                        }
                        // �Г������R
                        if (!string.IsNullOrEmpty(initData.InsideMemo3))
                        {
                            if (initData.InsideMemo3.Length > 20)
                            {
                                // �Г������R
                                initData.InsideMemo3 = initData.InsideMemo3.Substring(0, 20);
                            }
                        }
                        else
                        {
                            // �ėpXML�̎Г������R���g�p
                            if (initDataInfo.InsideMemo3.Length > 20)
                            {
                                // �Г������R
                                initData.InsideMemo3 = initDataInfo.InsideMemo3.Substring(0, 20);
                            }
                            else
                            {
                                // �Г������R
                                initData.InsideMemo3 = initDataInfo.InsideMemo3;
                            }
                        }

                        // �ЊO�����P
                        if (!string.IsNullOrEmpty(initData.SlipMemo1))
                        {
                            if (initData.SlipMemo1.Length > 20)
                            {
                                // �ЊO�����P
                                initData.SlipMemo1 = initData.SlipMemo1.Substring(0, 20);
                            }
                        }
                        else
                        {
                            // �ėpXML�̎ЊO�����P���g�p
                            if (initDataInfo.SlipMemo1.Length > 20)
                            {
                                // �ЊO�����P
                                initData.SlipMemo1 = initDataInfo.SlipMemo1.Substring(0, 20);
                            }
                            else
                            {
                                // �ЊO�����P
                                initData.SlipMemo1 = initDataInfo.SlipMemo1;
                            }
                        }

                        // �ЊO�����Q
                        if (!string.IsNullOrEmpty(initData.SlipMemo2))
                        {
                            if (initData.SlipMemo2.Length > 20)
                            {
                                // �ЊO�����Q
                                initData.SlipMemo2 = initData.SlipMemo2.Substring(0, 20);
                            }
                        }
                        else
                        {
                            // �ėpXML�̎ЊO�����Q���g�p
                            if (initDataInfo.SlipMemo2.Length > 20)
                            {
                                // �ЊO�����Q
                                initData.SlipMemo2 = initDataInfo.SlipMemo2.Substring(0, 20);
                            }
                            else
                            {
                                // �ЊO�����Q
                                initData.SlipMemo2 = initDataInfo.SlipMemo2;
                            }
                        }

                        // �ЊO�����R
                        if (!string.IsNullOrEmpty(initData.SlipMemo3))
                        {
                            if (initData.SlipMemo3.Length > 20)
                            {
                                // �ЊO�����R
                                initData.SlipMemo3 = initData.SlipMemo3.Substring(0, 20);
                            }
                        }
                        else
                        {
                            // �ėpXML�̎ЊO�����R���g�p
                            if (initDataInfo.SlipMemo3.Length > 20)
                            {
                                // �ЊO�����R
                                initData.SlipMemo3 = initDataInfo.SlipMemo3.Substring(0, 20);
                            }
                            else
                            {
                                // �ЊO�����R
                                initData.SlipMemo3 = initDataInfo.SlipMemo3;
                            }
                        }
                        #endregion

                        // �G���[�f�[�^������A�G���[���X�g�ɓY��
                        if (errorNote.Count != 0)
                        {
                            errWorkList.Add(GetErrTxtWork(initData, errorNote));
                        }
                        else
                        {
                            initDataList.Add(initData);
                        }
                    }

                    // �P���R�[�h�ڂ݂̂̏ꍇ
                    if (count == 1)
                    {
                        FirstInitData = initData;
                    }
                }
                
                // ���ڃt�H�[�}�b�g�`�F�b�N��OK�̏ꍇ
                if (errWorkList.Count == 0)
                {
                    // �ėpXML���[�J�[�R�[�h
                    int goodsMakerCdInitData = 0;
                    Int32.TryParse(initDataInfo.GoodsMakerCd, out goodsMakerCdInitData);

                    // �捞�t�@�C�����[�J�[�R�[�h
                    int goodsMakerCdInPutData = 0;

                    // �݌Ƀ��X�g
                    List<Stock> stockList = null;

                    // ���i���݁E�݌Ƀ`�F�b�N
                    foreach (InitDataItem initdata in initDataList)
                    {
                        //�G���[���b�Z�[�W���X�g
                        errorNote = new List<string>();
                        // ���i����
                        GoodsCndtn condition = new GoodsCndtn();
                        condition.EnterpriseCode = this._enterpriseCode;

                        if (UserDiv == 0)
                        {
                            condition.GoodsNo = initdata.GoodsCode;
                        }
                        else
                        {
                            condition.GoodsNo = initdata.GoodsNo;
                        }
                        condition.GoodsNoSrchTyp = 0;
                        condition.GoodsKindCode = 9;
                        // �捞���R�[�h�̃��[�J�[�������̏ꍇ�A�捞���R�[�h�̃��[�J�[���g�p
                        if (Int32.TryParse(initdata.GoodsMakerCd, out goodsMakerCdInPutData))
                        {
                            condition.GoodsMakerCd = goodsMakerCdInPutData;
                        }
                        // �捞���R�[�h�̃��[�J�[�������ȊO�̏ꍇ�A�ėpXML�t�@�C���̃��[�J�[���g�p
                        else
                        {
                            condition.GoodsMakerCd = goodsMakerCdInitData;
                        }

                        // �݌Ƀ��X�g
                        stockList = new List<Stock>();
                        // ���i��������
                        status = this.SearchGoods(condition, ref stockList);

                        // ���i�}�X�^���o�^
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                        {
                            errorNote.Add(CT_ERROR_MEASSSAGE03);
                        }
                        // ���i�}�X�^�����ُ�
                        else if (status == (int)ConstantManagement.DB_Status.ctDB_ERROR)
                        {
                            errMsg = CT_ERROR_MEASSSAGE11;
                        }

                        // ���i���݂���ꍇ�A�݌Ƀ`�F�b�N���s��
                        if (errorNote.Count == 0)
                        {
                            // �݌ɔ���t���O
                            bool checkstock = false;

                            foreach (Stock stock in stockList)
                            {
                                // �q�ɂ��_���폜����Ȃ��āA�d����̊Ǘ����_�ɂĐݒ肳���ꍇ�A�݌ɂ���Ƃ���
                                if (!(string.IsNullOrEmpty(stock.WarehouseCode) || stock.LogicalDeleteCode != 0) &&
                                    WarehouseDictionary.ContainsKey(stock.WarehouseCode.Trim()))
                                {
                                    checkstock = true;
                                    break;
                                }
                            }

                            // �݌ɖ����ꍇ
                            if (checkstock == false)
                            {
                                errorNote.Add(CT_ERROR_MEASSSAGE04);
                            }
                        }

                        // �G���[���b�Z�[�W����
                        if (errorNote.Count != 0)
                        {
                            ErrTxtgetWork errWork = new ErrTxtgetWork();
                            errWork = GetErrTxtWork(initdata, errorNote);
                            errWorkList.Add(errWork);
                        }
                        // �G���[���b�Z�[�W�Ȃ�
                        else 
                        {
                            status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                            this.CanDoStockDataWorkList.Add(initdata);
                        }
                    }

                    // ��ʂɓW�J�ł���f�[�^������ꍇ
                    if (this.CanDoStockDataWorkList != null && this.CanDoStockDataWorkList.Count > 0)
                    {
                        status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                    }
                }
                // ���ڃt�H�[�}�b�g�`�F�b�N��NG�̏ꍇ
                else
                {
                    status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                }
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                msgForm.Close();
                msgForm = null;

                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            finally
            {
                if (msgForm != null) msgForm.Close();
            }

            return status;
        }

        /// <summary>
        /// ���p�`�F�b�N
        /// </summary>
        /// <param name="str">�`�F�b�N������</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note        : ���p�`�F�b�N</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2020/06/22</br>
        /// <br></br>
        /// </remarks>
        private bool HalfCheck(string str)
        {
            if (str.Length == Encoding.Default.GetByteCount(str))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// ���i��������
        /// </summary>
        /// <param name="goodsCndtn">��������</param>
        /// <param name="stockList">�݌Ƀ��X�g</param>
        /// <remarks>
        /// <br>Note        : ���i��������</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2020/06/22</br>
        /// <br></br>
        /// </remarks>
        private int SearchGoods(GoodsCndtn goodsCndtn, ref List<Stock> stockList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            try
            {
                string msg;
                // ���i�Ǘ����}�X�^�擾�p
                GoodsAcs goodsAcs = new GoodsAcs();
                // ���i�}�X�^
                List<GoodsUnitData> goodsUnitDataList = new List<GoodsUnitData>();
                string retMsg;
                goodsAcs.SearchInitial(this._enterpriseCode, LoginInfoAcquisition.Employee.BelongSectionCode, out retMsg);
                // ���i�������s��
                status = goodsAcs.Search(goodsCndtn, ConstantManagement.LogicalMode.GetData0, out goodsUnitDataList, out msg);

                switch (status)
                {
                    // �������ʂ�����ꍇ
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        {
                            foreach (GoodsUnitData goods in goodsUnitDataList)
                            {
                                stockList.AddRange(goods.StockList);
                            }
                            break;
                        }
                    // �������ʂ��Ȃ��ꍇ
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                            break;
                        }
                    // �����ُ�ꍇ
                    default:
                        {
                            break;
                        }
                }

                // �������ʂ��Ȃ��ꍇ
                if (goodsUnitDataList.Count == 0)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;
        }

        /// <summary>
        /// �w�肵�����i�A�݌ɏ��̃��X�g�����ɁA�d�����׃f�[�^�s�I�u�W�F�N�g�ɏ��i�A�݌ɏ����ꊇ�ݒ肵�܂��B�i���i�x�[�X�j
        /// </summary>
        /// <param name="stockRowNo">�d���s�ԍ�</param>
        /// <param name="goodsUnitDataList">���i���I�u�W�F�N�g���X�g</param>
        /// <param name="settingStockRowNoList">�ݒ肵���d���s�ԍ��̃��X�g</param>
        /// <param name="overWriteRow">true:�s�㏑������ false:�s�㏑���Ȃ�</param>
        /// <param name="stockCount">�o�א��ʇ@</param>
        /// <param name="initData">�ėp�d���f�[�^</param>
        /// <remarks>
        /// <br>Note        : �w�肵�����i�A�݌ɏ��̃��X�g�����ɁA�d�����׃f�[�^�s�I�u�W�F�N�g�ɏ��i�A�݌ɏ����ꊇ�ݒ肵�܂��B�i���i�x�[�X�j</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2020/06/22</br>
        /// </remarks>
        public void StockDetailRowGoodsSettingBasedOnGoodsUnitData(int stockRowNo, List<GoodsUnitData> goodsUnitDataList, out List<int> settingStockRowNoList, bool overWriteRow, double stockCount, InitDataItem initData)
        {
            // �ݒ肵�����׍s�ԍ����X�g
            settingStockRowNoList = new List<int>();
            // �폜���׍s�ԍ����X�g
            List<int> deletingStockRowNoList = new List<int>();
            // �l���s�ԍ����X�g
            List<int> goodsDiscountRowList = new List<int>();

            // ���i����
            int addRowCnt = goodsUnitDataList.Count;
            // ���׍s�ԍ�
            int stockRowNoWk = stockRowNo;

            while (addRowCnt > 0)
            {
                // �d�����׍s�擾
                StockInputDataSet.StockDetailRow row = this.GetStockDetailRow(stockRowNoWk);

                try
                {
                    // �s�����݂��Ȃ��ꍇ�͐V�K�ɒǉ�����
                    if (row == null)
                    {
                        this.AddStockDetailRow();

                        row = this.GetStockDetailRow(stockRowNoWk);
                    }
                    // �s�����݂���ꍇ�͍X�V����
                    else
                    {
                        if (!overWriteRow)
                        {
                            if (this.ExistStockDetailInput(row))
                            {
                                continue;
                            }
                        }
                    }

                    // �ݒ肵�����׍s�ԍ��ǉ�
                    settingStockRowNoList.Add(row.StockRowNo);
                    // �폜���׍s�ԍ��ǉ�
                    deletingStockRowNoList.Add(row.StockRowNo);
                    // �l���s�ԍ��ǉ�
                    if (row.StockSlipCdDtl == 2)
                    {
                        goodsDiscountRowList.Add(row.StockRowNo);
                    }

                    // ���׍s�X�V
                    row.AcceptChanges();

                    addRowCnt--;
                }
                finally
                {
                    stockRowNoWk++;
                }
            }

            // �����Ώۑq�ɔz����擾
            string[] warehouseCodeArray = this.GetSearchWarehouseArray();

            // �d�����׍s�폜����
            this.ClearStockDetailRow(deletingStockRowNoList);
            GoodsUnitData goodsUnitData = new GoodsUnitData();
            Stock stock = new Stock();

            // ���i���
            for (int i = 0; i < goodsUnitDataList.Count; i++)
            {
                goodsUnitData = goodsUnitDataList[i];

                // �q�ɂ�I������ꍇ
                if (goodsUnitData.SelectedWarehouseCode != null)
                {
                    stock = this._stockSlipInputInitDataAcs.GetStock(goodsUnitData, goodsUnitData.SelectedWarehouseCode.Trim());
                }
                // �q�ɂ�I�����Ȃ��ꍇ
                else
                {
                    stock = ((warehouseCodeArray != null) && (warehouseCodeArray.Length > 0)) ? this._stockSlipInputInitDataAcs.GetStockFromGoodsUnitData(goodsUnitData, warehouseCodeArray) : null;
                }

                int targetStockRowNo = settingStockRowNoList[i];

                int stockSlipCdDtl = (goodsDiscountRowList.Contains(settingStockRowNoList[i])) ? 2 : 0;

                // ���i�A�݌ɏ��ݒ菈��
                this.StockDetailRowGoodsSetting(targetStockRowNo, goodsUnitData, stock, stockSlipCdDtl, stockCount, initData);
            }
        }

        /// <summary>
        /// �w�肵�����i���I�u�W�F�N�g�����ɁA�d�����׃f�[�^�s�I�u�W�F�N�g�ɏ��i����ݒ肵�܂��B
        /// </summary>
        /// <param name="stockRowNo">�d���s�ԍ�</param>
        /// <param name="goodsUnitData">���i���I�u�W�F�N�g</param>
        /// <param name="stock">�݌ɏ��I�u�W�F�N�g</param>
        /// <param name="stockSlipCdDtl">�d���`�[�敪(����)</param>
        /// <param name="stockCount">�o�א��ʇ@</param>
        /// <param name="initData">�ėp�d���f�[�^</param>
        /// <remarks>
        /// <br>Note        : �w�肵�����i���I�u�W�F�N�g�����ɁA�d�����׃f�[�^�s�I�u�W�F�N�g�ɏ��i����ݒ肵�܂�</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2020/06/22</br>
        /// </remarks>
        private void StockDetailRowGoodsSetting(int stockRowNo, GoodsUnitData goodsUnitData, Stock stock, int stockSlipCdDtl, double stockCount, InitDataItem initData)
        {
            StockInputDataSet.StockDetailRow row = this.GetStockDetailRow(stockRowNo);
            List<int> deleteRowNoList = new List<int>();

            if (row != null)
            {
                // ���׍s������
                this.ClearStockDetailRow(row);

                // �d���`�[�敪�i���ׁj
                row.StockSlipCdDtl = stockSlipCdDtl;

                // ���i��񂪂Ȃ��ꍇ
                if (goodsUnitData == null)
                {
                    // ����
                }
                else
                {
                    row.GoodsNo = goodsUnitData.GoodsNo;                                // �i��
                    row.GoodsMakerCd = goodsUnitData.GoodsMakerCd;                      // ���[�J�[�R�[�h
                    row.MakerName = goodsUnitData.MakerName;                            // ���[�J�[����
                    row.MakerKanaName = goodsUnitData.MakerKanaName;                    // ���[�J�[���̃J�i
                    row.GoodsName = goodsUnitData.GoodsName;                            // �i��
                    row.GoodsNameKana = goodsUnitData.GoodsNameKana;                    // �i���J�i
                    row.GoodsKindCode = goodsUnitData.GoodsKindCode;                    // ���i����
                    row.GoodsLGroup = goodsUnitData.GoodsLGroup;                        // ���i�啪�ޖ���
                    row.GoodsLGroupName = goodsUnitData.GoodsLGroupName;                // ���i�啪�ރR�[�h
                    row.GoodsMGroup = goodsUnitData.GoodsMGroup;                        // ���i�����ރR�[�h
                    row.GoodsMGroupName = goodsUnitData.GoodsMGroupName;                // ���i�����ޖ���
                    row.BLGroupCode = goodsUnitData.BLGroupCode;                        // BL�O���[�v�R�[�h
                    row.BLGroupName = goodsUnitData.BLGroupName;                        // BL�O���[�v�R�[�h����
                    row.BLGoodsCode = goodsUnitData.BLGoodsCode;                        // BL���i�R�[�h
                    row.BLGoodsFullName = goodsUnitData.BLGoodsFullName;                // BL���i�R�[�h���́i�S�p�j
                    row.EnterpriseGanreCode = goodsUnitData.EnterpriseGanreCode;        // ���Е��ރR�[�h
                    row.EnterpriseGanreName = goodsUnitData.EnterpriseGanreName;        // ���Е��ޖ���
                    row.GoodsRateRank = goodsUnitData.GoodsRateRank;                    // ���i�|�������N
                    row.RateBLGoodsCode = goodsUnitData.BLGoodsCode;                    // BL���i�R�[�h�i�|���j
                    row.RateBLGoodsName = goodsUnitData.BLGoodsFullName;                // BL���i�R�[�h���́i�|���j
                    row.RateGoodsRateGrpCd = goodsUnitData.GoodsRateGrpCode;            // ���i�|���O���[�v�R�[�h�i�|���j
                    row.RateGoodsRateGrpNm = goodsUnitData.GoodsRateGrpName;            // ���i�|���O���[�v���́i�|���j
                    row.RateBLGroupCode = goodsUnitData.BLGroupCode;                    // BL�O���[�v�R�[�h�i�|���j
                    row.RateBLGroupName = goodsUnitData.BLGroupName;                    // BL�O���[�v���́i�|���j
                    row.TaxationCode = goodsUnitData.TaxationDivCd;                     // �ېŋ敪
                    row.GoodsOfferDate = goodsUnitData.OfferDate;                       // �񋟓�
                    row.TaxDiv = row.TaxationCode;                                      // �ېŋ敪�i�\���j
                    // ���M�ԗ��̏ꍇ
                    if (UserDiv == 0)
                    {
                        row.StockDtiSlipNote1 = initData.AcceptAnOrderNo;               // �d���`�[���ה��l1
                    }
                    // ���M�ԗ��ȊO�̏ꍇ
                    else
                    {
                        row.StockDtiSlipNote1 = initData.StockDtlSlipNote;               // �d���`�[���ה��l1
                    }

                    if (row.StockSlipCdDtl == 2)
                    {
                        row.EditStatus = ctEDITSTATUS_GoodsDiscount;                    // �ύX�\�X�e�[�^�X
                    }
                    else
                    {
                        row.EditStatus = ctEDITSTATUS_AllOK;                            // �ύX�\�X�e�[�^�X
                    }

                    int sign = (row.StockSlipCdDtl == 2) ? -1 : 1;
                    row.StockCountDisplay = stockCount * sign;
                    sign = (this._stockSlip.SupplierSlipCd == 20) ? -1 : 1;
                    row.StockCount = row.StockCountDisplay * sign;
                    row.OrderCnt = row.StockCount;

                    row.OrderRemainCnt = (this._stockSlip.SupplierFormal == 0) ? 0 : row.StockCountDisplay;

                    // �݌ɏ��
                    if (stock != null)
                    {
                        this.CacheStockInfo(stock);

                        row.WarehouseCode = stock.WarehouseCode.Trim();
                        row.WarehouseName = stock.WarehouseName;
                        row.WarehouseShelfNo = stock.WarehouseShelfNo;
                    }
                    else
                    {
                        row.ShipmentPosCnt = 0;
                        row.ShipmentPosCntDisplay = row.ShipmentPosCnt;
                    }

                    // �����ݒ�
                    row.SlipMemo1 = initData.SlipMemo1;
                    row.SlipMemo2 = initData.SlipMemo2;
                    row.SlipMemo3 = initData.SlipMemo3;
                    row.InsideMemo1 = initData.InsideMemo1;
                    row.InsideMemo2 = initData.InsideMemo2;
                    row.InsideMemo3 = initData.InsideMemo3;

                    // �i�ԁA���[�J�[�������Ă���ꍇ�͒P���Z�o���W���[���Ō����v�Z
                    if ((goodsUnitData.GoodsMakerCd != 0) && (!string.IsNullOrEmpty(goodsUnitData.GoodsNo)))
                    {
                        this.StockDetailRowGoodsPriceSetting(row, goodsUnitData);
                    }

                    // ���i���L���b�V��
                    this.CacheGoodsUnitData(goodsUnitData);
                }
            }

            // �Z�b�g�e���i�̏ꍇ�͎q���i�s���N���A����
            if (deleteRowNoList.Count > 0)
            {
                this.DeleteStockDetailRow(deleteRowNoList, true);
            }
        }
        // ------ ADD 2020/06/22 ���O PMKOBETSU-4017�̑Ή� --------- <<<<

    }
    // ------ ADD 2020/06/22 ���O PMKOBETSU-4017�̑Ή� --------- >>>>
    /// <summary>
    /// �G���[�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note        : �G���[�N���X</br>
    /// <br>Programmer  : ���O</br>
    /// <br>Date        : 2020/06/22</br>
    /// </remarks>
    public class ErrTxtgetWork 
    {
        /// <summary>�󒍔ԍ�</summary>
        private string _acceptAnOrderNo = "";

        /// <summary>���i�R�[�h</summary>
        private string _goodsCode = "";

        /// <summary>�o�א��ʇ@</summary>
        private string _shipmentCnt1 = "";

        /// <summary>�󒍒P��</summary>
        private string _acceptAnOrderUnCst = "";

        /// <summary>��(�V�X�e��)���t�iYYYYMMDD�j</summary>
        private string _sysDate = "";

        /// <summary>�d����R�[�h</summary>
        private string _supplierCd = "";

        /// <summary>�d���`�[�ԍ�</summary>
        private string _supplierSlipNo = "";

        /// <summary>�i��</summary>
        private string _goodsNo = "";

        /// <summary>�G���[���b�Z�[�W</summary>
        private List<string> errormessage;

        /// <summary>�G���[���b�Z�[�W</summary>
        public List<string> Errormessage
        {
            get { return errormessage; }
            set { errormessage = value; }
        }

        /// <summary>�󒍔ԍ��v���p�e�B</summary>
        public string AcceptAnOrderNo
        {
            get { return _acceptAnOrderNo; }
            set { _acceptAnOrderNo = value; }
        }

        /// <summary>���i�R�[�h�v���p�e�B</summary>
        public string GoodsCode
        {
            get { return _goodsCode; }
            set { _goodsCode = value; }
        }

        /// <summary>�o�א��ʇ@�v���p�e�B</summary>
        public string ShipmentCnt1
        {
            get { return _shipmentCnt1; }
            set { _shipmentCnt1 = value; }
        }

        /// <summary>�󒍒P���v���p�e�B</summary>
        public string AcceptAnOrderUnCst
        {
            get { return _acceptAnOrderUnCst; }
            set { _acceptAnOrderUnCst = value; }
        }

        /// <summary>��(�V�X�e��)���t�iYYYYMMDD�j�v���p�e�B</summary>
        public string SysDate
        {
            get { return _sysDate; }
            set { _sysDate = value; }
        }

        /// public propaty name  :  SupplierCd
        /// <summary>�d����R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d����R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SupplierCd
        {
            get { return _supplierCd; }
            set { _supplierCd = value; }
        }

        /// public propaty name  :  SupplierSlipNo
        /// <summary>�d���`�[�ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���`�[�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SupplierSlipNo
        {
            get { return _supplierSlipNo; }
            set { _supplierSlipNo = value; }
        }

        /// public propaty name  :  GoodsNo
        /// <summary>�i�ԃv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �i�ԃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GoodsNo
        {
            get { return _goodsNo; }
            set { _goodsNo = value; }
        }

    }
    // ------ ADD 2020/06/22 ���O PMKOBETSU-4017�̑Ή� --------- <<<<
}
	
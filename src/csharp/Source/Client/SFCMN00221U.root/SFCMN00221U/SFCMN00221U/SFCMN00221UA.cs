using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Collections.Generic;
using System.IO;
using System.Text;

using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Resources;
using Broadleaf.Windows.Forms;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Collections;
using Broadleaf.Xml.Serialization;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// �X�[�p�[�X���C�_�[�N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : �X���C�_�[�ɂē��Ӑ��d���`�[�̌����E�I���⑼PG�N�������s���܂��B</br>
	/// <br>Programmer : 980076�@�Ȓ��@����Y</br>
	/// <br>Date       : 2006.03.07</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// <br>2006.03.28 men �T���v���Ή�</br>
	/// <br>2006.04.05 men �`�[�ԍ������̔ԕ��i�g�ݍ��ݑΉ�(SFCMN00221UI)</br>
	/// <br>2006.04.18 men Visual Studio 2005 �Ή�</br>
	/// <br>2006.11.17 men ����ăV�[�g�N�� �Ή�</br>
	/// <br>2007.10.12 21024 �g�єł�DC.NS�łɕύX</br>
    /// <br></br>
    /// <br>Update Note: 2008.04.24 20056 ���n ���</br>
    ///	<br>		   : PM.NS ���ʏC�� ���Ӑ�E�d���敪���Ή�</br>
	/// <br></br>
	/// <br>Update Note: 2008.05.22 21024 ���X�� ��</br>
	///	<br>		   : ���Ӑ�E�d���敪���Ή�</br>
    /// <br></br>
    /// <br>Update Note: 2008.09.18 21024 ���X�� ��</br>
    ///	<br>		   : �d���`�[�V�K�쐬�����̒ǉ�</br>
    /// <br></br>
    /// <br>Update Note: 2008.11.06 21024 ���X�� ��</br>
    ///	<br>		   : PM.NS�p�ɉ�ʂ�ύX�i�R�����g�����j</br>
    /// <br></br>
    /// <br>Update Note: 2014/11/01 杍^</br>
    /// <br>�Ǘ��ԍ�   : 11070149-00</br>
    /// <br>           : �d�|�ꗗ��2200 redmine #43864 �ǉ��Ή�</br>
    /// <br>           : �n���h���G���[���o���Q�̏C��</br>
    /// <br>Update Note: 2015/02/04 杍^</br>
    /// <br>�Ǘ��ԍ�   : 11070149-00</br>
    /// <br>           : �d�|�ꗗ��2200 redmine #43864 �ǉ��Ή�</br>
    /// <br>           : �n���h���G���[���o���Q�̍ďC��</br>
    /// <br></br>
    /// <br>Update Note: 2015/02/06 30757 ���X�� �M�p</br>
    /// <br>�Ǘ��ԍ�   : 11070149-00</br>
    /// <br>           : �d�|�ꗗ��2200 redmine #43864 �ǉ��Ή�</br>
    /// <br>           : ����e�X�g��Q�Ή��@�F�V�K�{�^���������ɍŋߎg�����d���悪�N���A�����s��Ή�</br>
    /// <br>           : ����e�X�g��Q�Ή��A�F�^�X�N���j���[�y�C���̖߂�/�i�ރ{�^���J�ڕs���Ή�</br>
    /// <br></br>
    /// <br>Update Note: 2015/02/26 30940 �͌��� �ꐶ</br>
    /// <br>�Ǘ��ԍ�   : 11070149-00</br>
    /// <br>           : �d�|�ꗗ��2200 �^�X�N���j���[�\���s���Ή�</br>
    /// <br></br>
    /// </remarks>
	public partial class SFCMN00221UA : System.Windows.Forms.Form
	{
		// ===================================================================================== //
		// �X�[�p�[�X���C�_�[�N���X�̃f�t�H���g�R���X�g���N�^
		// ===================================================================================== //
		# region Constructor
		/// <summary>
		/// �X�[�p�[�X���C�_�[�N���X�R���X�g���N�^
		/// </summary>
		public SFCMN00221UA()
		{
			// Windows �t�H�[�� �f�U�C�i �T�|�[�g�ɕK�v�ł��B
			InitializeComponent();

			// �ϐ�������(SFCMN00221UF��SFCMN00221UI�̂݃R���X�g���N�^���ŏ���������j
			this._customerSearchRet = new CustomerSearchRet();							// ���Ӑ挟�����ʃN���X
			this._searchRetStockSlip = new SearchRetStockSlip();						// �d���`�[�������ʃN���X
			this._param = new SFCMN00221UAParam();
			this._controlScreenSkin = new ControlScreenSkin();
			this._controlScreenSkin.LoadSkin();

			this._topMenuForm = new SFCMN00221UF(this._controlScreenSkin);
			this._stockSlipSearchForm = new SFCMN00221UI(this._controlScreenSkin);
			_commonLib = new SliderCommonLib(Encoding.GetEncoding("Shift_JIS"));

			this._controlScreenSkin.SettingScreenSkin(this);
			//this._controlScreenSkin.SettingScreenSkin(this._topMenuForm);
			//this._controlScreenSkin.SettingScreenSkin(this._stockSlipSearchForm);
		}

		/// <summary>
		/// �X�[�p�[�X���C�_�[�R���X�g���N�^
		/// </summary>
		/// <param name="param">�N���p�����[�^</param>
		public SFCMN00221UA(SFCMN00221UAParam param) : this()
		{
			// �ϐ�������
			this._param = param;
		}

        // --- ADD 杍^ 2015/02/04 ------ >>>
        /// <summary>
        /// ���������b�\�h�i�R���|�|�l���g�����j
        /// </summary>
        /// <remarks>
        /// <br>Note       : �d�|�ꗗ��2200 redmine #43864 �ǉ��Ή�</br>
        /// <br>             �R���|�[�l���g�n���h�������G���[�Ή��i�āj</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2015/02/04 </br>
        /// <br></br>
        /// <br>Update Note: 2015/02/06 30757 ���X�� �M�p</br>
        /// <br>�Ǘ��ԍ�   : 11070149-00</br>
        /// <br>           : �d�|�ꗗ��2200 redmine #43864 �ǉ��Ή�</br>
        /// <br>           : ����e�X�g��Q�Ή��@�F�V�K�{�^���������ɍŋߎg�����d���悪�N���A�����s��Ή�</br>
        /// <br>           : ����e�X�g��Q�Ή��A�F�^�X�N���j���[�y�C���̖߂�/�i�ރ{�^���J�ڕs���Ή�</br>
        /// <br></br>
        /// </remarks>
        public void InitForNoComponent()
        {
            this._topMenuForm.InitForNoComponent();
            this._stockSlipSearchForm.InitForNoComponent();

            // --- DEL 30757 ���X�� �M�p 2015/02/06 ����e�X�g��Q�Ή��@�F�V�K�{�^���������ɍŋߎg�����d���悪�N���A�����s��Ή�------ >>>
            //this._customerSearchRetRecordList = new List<CustomerSearchRet>();
            //this._supplierSearchRetRecordList = new List<Supplier>();							// 2008.05.22 Add
            //this._stockSlipRecordList = new List<SearchRetStockSlip>();
            // --- DEL 30757 ���X�� �M�p 2015/02/06 ����e�X�g��Q�Ή��@�F�V�K�{�^���������ɍŋߎg�����d���悪�N���A�����s��Ή�------ <<<
            // --- ADD 30757 ���X�� �M�p 2015/02/06 ����e�X�g��Q�Ή��@�F�V�K�{�^���������ɍŋߎg�����d���悪�N���A�����s��Ή�------ >>>
            if (null == this._customerSearchRetRecordList)
            {
                this._customerSearchRetRecordList = new List<CustomerSearchRet>();
            }
            if (null == this._supplierSearchRetRecordList)
            {
                this._supplierSearchRetRecordList = new List<Supplier>();
            }
            if (null == this._stockSlipRecordList)
            {
                this._stockSlipRecordList = new List<SearchRetStockSlip>();
            }
            // --- ADD 30757 ���X�� �M�p 2015/02/06 ����e�X�g��Q�Ή��@�F�V�K�{�^���������ɍŋߎg�����d���悪�N���A�����s��Ή�------ <<<
            // --- DEL 30757 ���X�� �M�p 2015/02/06 ����e�X�g��Q�Ή��A�F�^�X�N���j���[�y�C���̖߂�/�i�ރ{�^���J�ڕs���Ή�------ >>>
            //this._panelChangeRecordList = new List<PanelChangeRecord>();
            //this._panelChangeRecordListIndex = 0;
            // --- DEL 30757 ���X�� �M�p 2015/02/06 ����e�X�g��Q�Ή��A�F�^�X�N���j���[�y�C���̖߂�/�i�ރ{�^���J�ڕs���Ή�------ <<<
            // --- ADD 30757 ���X�� �M�p 2015/02/06 ����e�X�g��Q�Ή��A�F�^�X�N���j���[�y�C���̖߂�/�i�ރ{�^���J�ڕs���Ή�------ >>>
            if (null == this._panelChangeRecordList)
            {
                this._panelChangeRecordList = new List<PanelChangeRecord>();
                this._panelChangeRecordListIndex = 0;
            }
            // --- ADD 30757 ���X�� �M�p 2015/02/06 ����e�X�g��Q�Ή��A�F�^�X�N���j���[�y�C���̖߂�/�i�ރ{�^���J�ڕs���Ή�------ <<<
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;							// ��ƃR�[�h���擾

            // --- DEL 30940 �͌��� �ꐶ 2015/02/26 �^�X�N���j���[�̕\���s���Ή� -----------------------------<<<<<<<
            // ��������(�����l�ݒ�XML�ǂݍ��ݓ�)
            //this.LoadInitialData();
            // --- DEL 30940 �͌��� �ꐶ 2015/02/26 �^�X�N���j���[�̕\���s���Ή� ----------------------------->>>>>>>

            this._topMenuForm.CustomerSearchRetRecordList = this._customerSearchRetRecordList;					// �ŋߑI���������Ӑ�ԗ����
            this._topMenuForm.SupplierSearchRetRecordList = this._supplierSearchRetRecordList;					// �ŋߑI�������d����ԗ����
            this._topMenuForm.StockSlipRecordList = this._stockSlipRecordList;									// �ŋߑI�������d���`�[���
            this._topMenuForm.LuncherTopMenuInfoArray = this._luncherTopMenuInfoArray;							// �����`���[�g�b�v���j���[���
            this._customerMenuForm.LuncherStartAssemblyInfoArray = this._luncherStartAssemblyInfoArray;			// �����`���[�\���A�Z���u�����(���Ӑ�ԗ�����)
            this._stockSlipMenuForm.OdrLuncherStartAssemblyInfoArray = this._odrLuncherStartAssemblyInfoArray;	// �����`���[�\���A�Z���u�����(�d���`�[����)
        }
        // --- ADD 杍^ 2015/02/04 ------ <<<
		# endregion

		// ===================================================================================== //
		// �C���i�[�N���X
		// ===================================================================================== //
		# region Inner Class
		/// <summary>
		/// �p�l���\�������N���X
		/// </summary>
		private class PanelChangeRecord
		{
			private int _dispNo;

			/// <summary>
			/// �p�l���\�������N���X�R���X�g���N�^
			/// </summary>
			/// <param name="dispNo">�p�l���\���ԍ�</param>
			public PanelChangeRecord(int dispNo)
			{
				this._dispNo = dispNo;
			}

			/// <summary�p�l���\���ԍ�</summary>
			public int DispNo
			{
				get
				{
					return this._dispNo;
				}
				set
				{
					this._dispNo = value;
				}
			}
		}
		# endregion

		// ===================================================================================== //
		// �v���C�x�[�g�ϐ�
		// ===================================================================================== //
		# region Private Members
		private string _xmlNoString = "";
		private int _xmlNo = 0;
		private List<CustomerSearchRet> _customerSearchRetRecordList;					// �ŋߑI���������Ӑ���
		// 2008.05.22 Update >>>
		//private List<CustomerSearchRet> _supplierSearchRetRecordList;					// �ŋߑI�������d������
		private List<Supplier> _supplierSearchRetRecordList;							// �ŋߑI�������d������
		// 2008.05.22 Update <<<
		private List<SearchRetStockSlip> _stockSlipRecordList;							// �ŋߑI�������d���`�[���
		private LuncherTopMenuInfo[] _luncherTopMenuInfoArray;							// �����`���[�g�b�v���j���[���
		private LuncherStartAssemblyInfo[] _luncherStartAssemblyInfoArray;				// �����`���[�\���A�Z���u�����(���Ӑ挟��)
		private LuncherStartAssemblyInfo[] _odrLuncherStartAssemblyInfoArray;			// �����`���[�\���A�Z���u�����(�d���`�[����)
		private SFCMN00221UF _topMenuForm;												// �g�b�v���j���[�t�H�[��
		private SFCMN00221UI _stockSlipSearchForm;										// �d���`�[�����t�H�[��
		private SFCMN00221UJ _customerMenuForm;											// ���Ӑ���\���t�H�[��
		private SFCMN00221UK _stockSlipMenuForm;										// �d���`�[���\���t�H�[��
		private SFCMN00221UM _customerSearchForm;										// ���Ӑ挟���t�H�[��
		private SFCMN00221UQ _supplierSearchForm;										// �d���挟���t�H�[�� 2008.05.22 Add
		private List<PanelChangeRecord> _panelChangeRecordList;							// ��ʕ\�������N���X���X�g
		private int _panelChangeRecordListIndex;										// ��ʕ\�������N���X���X�g�ʒu
		private Panel _displayPanel;													// �\�����p�l��
		private string _enterpriseCode = "";											// ��ƃR�[�h
		private CustomerSearchRet _customerSearchRet;									// ���Ӑ挟�����ʃN���X
		private Supplier _supplierSearchRet;											// �d����}�X�^�N���X 2008.05.22 Add
		private SearchRetStockSlip _searchRetStockSlip;									// �d���`�[�������ʃN���X
		private static AlItmDspNm _alItmDspNm;											// �S�̍��ڕ\���ݒ�N���X
		private SFCMN00221UAParam _param;												// �X�[�p�[�X���C�_�[�N���p�����[�^
		private string _customerInitialDataFilePath = Path.Combine(ConstantManagement_ClientDirectory.Temp_UserTemp, DATFILE_INITIALDATA_CUSTOMER);
		private string _supplierInitialDataFilePath = Path.Combine(ConstantManagement_ClientDirectory.Temp_UserTemp, DATFILE_INITIALDATA_SUPPLIER);
		private string _stockSlipInitialDataFilePath = Path.Combine(ConstantManagement_ClientDirectory.Temp_UserTemp, DATFILE_INITIALDATA_STOCKSLIP);
		private static SliderCommonLib _commonLib;
		private ControlScreenSkin _controlScreenSkin;
		# endregion

		// ===================================================================================== //
		// �����Ŏg�p����萔�S
		// ===================================================================================== //
		# region const
		private const string RECORD_KEY_CUSTOMERCAR = "CustomerRecord";
		private const string RECORD_KEY_ACCEPTORDER = "AcceptOrderRecord";
		private const string DATFILE_INITIALDATA_CUSTOMER = "SFCMN00221U_CustomerData.DAT";
		private const string DATFILE_INITIALDATA_SUPPLIER = "SFCMN00221U_SupplierData.DAT";
		private const string DATFILE_INITIALDATA_STOCKSLIP = "SFCMN00221U_StockSlipData.DAT";
		private const string XML_FILE_TOPMENU_INFO = "SFCMN00221U_TopMenuInfo";
		private const string XML_FILE_EXTENSION = ".XML";
		private const string XML_FILE_ASSEMBLY_INFO = "SFCMN00221U_StartAssemblyInfo";
		private const string XML_FILE_STOCKSLIP_LUNCHER_INFO = "SFCMN00221U_StockSlipLuncherInfo";

		internal const int FORM_STATUS_Top = 0;								// TOP���j���[
		internal const int FORM_STATUS_FindCustomer = 1;					// ���Ӑ挟�����
		internal const int FORM_STATUS_CustomerLuncher = 2;					// ���Ӑ惉���`���[���
		internal const int FORM_STATUS_StockSlipLuncher = 3;				// �d���`�[�����`���[���
		internal const int FORM_STATUS_FindSupplier = 4;					// �d���挟�����
		internal const int FORM_STATUS_FindStockSlip = 5;					// �d���`�[�������
		internal const int FORM_STATUS_FindReceiptSlip = 6;					// ���ד`�[�������

		// �����`���[���[�h�萔��`
		internal const int LuncherMode_CustomerChange = 1;
		internal const int LuncherMode_SupplierChange = 2;					// �d����̏C�� 2008.05.22 Add
		internal const int LuncherMode_SlipSetCustomer = 4;					// ���Ӑ��`�[�ɔ��f����
		internal const int LuncherMode_StockSlipSearch = 5;
		internal const int LuncherMode_CustomerView = 6;
		internal const int LuncherMode_CustomerNew = 8;
		internal const int LuncherMode_ModifyStockSlip = 10;
		internal const int LuncherMode_SlipAbuild = 11;						// �ԍ쐬
		internal const int LuncherMode_TrustAppropriate = 12;				// ���׌v��
		internal const int LuncherMode_SlipCopy = 25;						// �`�[�R�s�[
		internal const int LuncherMode_NewSlipSetSupplier = 41;				// �I�𒆂̎d����œ`�[��V�K�쐬����
		internal const int LuncherMode_SlipSetSupplier = 42;				// �I�𒆂̎d�����`�[�ɔ��f����
		internal const int LuncherMode_Blank = 98;							// �󔒍s
		internal const int LuncherMode_Separator = 99;						// �Z�p���[�^

		public const int TOP_MODE_CustomerSearch = 1;			// ���Ӑ挟��
		public const int TOP_MODE_SupplierSearch = 2;			// �d���挟��
		public const int TOP_MODE_NewSlip = 3;					// �V�K�`�[�쐬
		public const int TOP_MODE_SelectCustomer = 4;			// ���Ӑ�̑I��
		public const int TOP_MODE_SelectStockSlip = 5;			// �d���`�[�̑I��		
		public const int TOP_MODE_NewCustomer = 6;				// ���Ӑ�̐V�K�쐬
		public const int TOP_MODE_StockSlipSearch = 7;			// �d���`�[����
        public const int TOP_MODE_NewStockSlip = 8;             // �d���`�[�V�K�쐬�@   // 2008.09.18 Add
	

		internal const string MESSAGE_CONDITION_CLEAR = "�E�N���b�N�ŃN���A���邱�Ƃ��o���܂�";
		# endregion

		// ===================================================================================== //
		// �v���p�e�B
		// ===================================================================================== //
		# region Priperties
		/// <summary>
		/// �ŋߎQ�Ƃ������Ӑ�\���v���p�e�B
		/// </summary>
		public bool CustomerListShow
		{
			get
			{
				return this._topMenuForm.CustomerListShow;
			}
			set
			{
				this._topMenuForm.CustomerListShow = value;
			}
		}

		/// <summary>
		/// �ŋߎQ�Ƃ����d���`�[�\���v���p�e�B
		/// </summary>
		public bool StockSlipListShow
		{
			get
			{
				return this._topMenuForm.StockSlipListShow;
			}
			set
			{
				this._topMenuForm.StockSlipListShow = value;
			}
		}

		/// <summary>
		/// �X���C�_�[�p���ʃ��C�u�����N���X�v���p�e�B
		/// </summary>
		internal static SliderCommonLib CommonLib
		{
			get { return SFCMN00221UA._commonLib; }
		}
		# endregion

		// ===================================================================================== //
		// �C�x���g
		// ===================================================================================== //
		# region Event
		public event CreateNewSlipHandler CreateNewSlip;
		public event CreateNewSlipUsedSupplierHandler CreateNewSlipUsedSupplier;	// 2008.05.22 Add
		public event ModifyStockSlipHandler ModifyStockSlip;
		public event SelectedCustomerHandler SelectedCustomer;
		public event SelectedSupplierHandler SelectedSupplier;						// 2008.05.22 Add
		public event ModifyStockSlipHandler RedWriteStockSlip;
		public event ModifyStockSlipHandler TrustAppropriateStockSlip;
		// 2007.10.12 sasaki >>
		public event ModifyStockSlipHandler SlipCopy;
		// 2007.10.12 sasaki <<
		# endregion

		// ===================================================================================== //
		// �p�u���b�N���\�b�h
		// ===================================================================================== //
		# region Public Methods
		/// <summary>
		/// ���C���p�l���擾����(�����lXML�w��^�C�v)
		/// </summary>
		/// <param name="dataInputSystem">�N�����[�h�F 0:�S�V�X�e�� 1:�����̂� 2:����̂� 3:�Ԕ̂̂�</param>
		/// <param name="xmlno">�����lXML�̔ԍ��F �w�肵���ԍ���XML�������l�pXML�Ƃ��Ďg�p���܂�</param>
		/// <returns>�\���p�l���F���̃p�l�����h�b�L���O�G���A�̃p�l���ɐݒ肵�Ă�������</returns>
		/// <remarks>
		/// <br>Note       : �`�惁�C���p�l�����擾���܂��B�����������ɂP��̂ݍs���Ă��������B</br>
		/// <br>           : ��Q�p�����[�^���w�肷�邱�Ƃŏ����lXML���w�肷�邱�Ƃ��\�ł��B</br>
		/// <br>Programmer : 980076�@�Ȓ��@����Y</br>
		/// <br>Date       : 2006.03.07</br>
		/// </remarks>
		public Panel GetMainPanel(int dataInputSystem)
		{
			return this.GetMainPanel(dataInputSystem, 0);
		}

		/// <summary>
		/// ���C���p�l���擾����(�����lXML�w��^�C�v)
		/// </summary>
		/// <param name="mode">�N�����[�h�F ���ݖ��g�p</param>
		/// <param name="xmlno">�����lXML�̔ԍ��F �w�肵���ԍ���XML�������l�pXML�Ƃ��Ďg�p���܂�</param>
		/// <returns>�\���p�l���F���̃p�l�����h�b�L���O�G���A�̃p�l���ɐݒ肵�Ă�������</returns>
		/// <remarks>
		/// <br>Note       : �`�惁�C���p�l�����擾���܂��B�����������ɂP��̂ݍs���Ă��������B</br>
		/// <br>           : ��Q�p�����[�^���w�肷�邱�Ƃŏ����lXML���w�肷�邱�Ƃ��\�ł��B</br>
		/// <br>Programmer : 980076�@�Ȓ��@����Y</br>
		/// <br>Date       : 2006.03.07</br>
		/// </remarks>
		public Panel GetMainPanel(int mode, int xmlNo)
		{
			this._param.XmlNo = xmlNo;
			return this.GetMainPanel();
		}

		/// <summary>
		/// ���C���p�l���擾����
		/// </summary>
		public Panel GetMainPanel()
		{
			// XML�t�@�C���ԍ��ݒ�
			if (this._param.XmlNo == 0)
			{
				this._xmlNoString = "";
			}
			else
			{
				this._xmlNoString = this._param.XmlNo.ToString();
			}

			// XML�ԍ���ޔ�
			this._xmlNo = this._param.XmlNo;

			this.timer_Initial.Enabled = true;

			this.panel_Main.Enabled = true;

			return this.panel_Main;
		}

		/// <summary>
		/// ������ʏI������
		/// </summary>
		/// <remarks>
		/// <br>Note       : ������ʏI�����ɌĂяo���Ă��������B�f�[�^�̕ۑ������s���܂�</br>
		/// <br>Programmer : 980076�@�Ȓ��@����Y</br>
		/// <br>Date       : 2006.03.07</br>
		/// </remarks>
		public void ClosePanel()
		{
			// �����l����ۑ�����
			this.SaveInitialData();
		}

        // --- DEL 杍^ 2015/02/04 ------ >>>
        // --- ADD 杍^ 2014/11/01 ------ >>>
        /// <summary>
        /// �����[�X����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �����[�X�������s���܂�</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2014/11/01</br>
        /// </remarks>
        //public void DisposeForm()
        //{
        //    this._topMenuForm.Dispose();
        //    this._topMenuForm = null;

        //    this._stockSlipSearchForm.DisposeForm();
        //    this._stockSlipSearchForm.Dispose();
        //    this._stockSlipSearchForm = null;
        //}
        // --- ADD 杍^ 2014/11/01 ------ <<<
        // --- DEL 杍^ 2015/02/04 ------ <<<
		# endregion

		// ===================================================================================== //
		// �C���^�[�i�����\�b�h
		// ===================================================================================== //
		# region Internal Methods
		/// <summary>
		/// �S�̍��ڕ\�����̃}�X�^�擾����
		/// </summary>
		/// <param name="alItmDspNm">�S�̍��ڕ\�����̃}�X�^</param>
		/// <returns>�X�e�[�^�X</returns>
		internal static int GetAlItmDspNm(out AlItmDspNm alItmDspNm)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

			if (_alItmDspNm != null)
			{
				alItmDspNm = _alItmDspNm;
				return status;
			}

			//alItmDspNm = EntryCommonInitDataAcs.AlItmDspNm;	// ��
			alItmDspNm = null;									// ��

			if (alItmDspNm == null)
			{
				// �\�����̐ݒ�
				AlItmDspNmAcs alItmDspNmAcs = new AlItmDspNmAcs();
				status = alItmDspNmAcs.ReadStatic(out alItmDspNm, LoginInfoAcquisition.EnterpriseCode);

				if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
				{
					status = alItmDspNmAcs.Read(out alItmDspNm, LoginInfoAcquisition.EnterpriseCode);
				}
			}

			if (alItmDspNm == null) status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

			_alItmDspNm = alItmDspNm;

			return status;
		}

		/// <summary>
		/// �ǉ����\�����̎擾����
		/// </summary>
		/// <param name="no">��</param>
		/// <returns>�ǉ����\������</returns>
		internal static string GetAddInfoDspName(int no)
		{
			string addInfoDspName = "";

			AlItmDspNm alItmDspNm;
			if (GetAlItmDspNm(out alItmDspNm) == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				switch (no)
				{
					case 1:
					{
						addInfoDspName = alItmDspNm.AddInfo1DspName;
						break;
					}
					case 2:
					{
						addInfoDspName = alItmDspNm.AddInfo2DspName;
						break;
					}
					case 3:
					{
						addInfoDspName = alItmDspNm.AddInfo3DspName;
						break;
					}
				}
			}

			return addInfoDspName;
		}

		/// <summary>
		/// �d�b�ԍ��\�����̎擾����
		/// </summary>
		/// <param name="no">��</param>
		/// <returns>�d�b�ԍ��\������</returns>
		internal static string GetTelNoDspName(int no)
		{
			string telNoDspName = "";

			AlItmDspNm alItmDspNm;
			if (GetAlItmDspNm(out alItmDspNm) == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				switch (no)
				{
					case 0:
					{
						telNoDspName = alItmDspNm.HomeTelNoDspName;
						break;
					}
					case 1:
					{
						telNoDspName = alItmDspNm.OfficeTelNoDspName;
						break;
					}
					case 2:
					{
						telNoDspName = alItmDspNm.MobileTelNoDspName;
						break;
					}
					case 3:
					{
						telNoDspName = alItmDspNm.HomeFaxNoDspName;
						break;
					}
					case 4:
					{
						telNoDspName = alItmDspNm.OfficeFaxNoDspName;
						break;
					}
					case 5:
					{
						telNoDspName = alItmDspNm.OtherTelNoDspName;
						break;
					}
				}
			}

			return telNoDspName;
		}

		/// <summary>
		/// �I�v�V���������`�F�b�N����
		/// </summary>
		/// <param name="softwareCode">�I�v�V�����R�[�h</param>
		/// <returns>true:�����ς� false:������</returns>
		internal static bool OptionCheckForUSB(string softwareCode)
		{
			if ((int)LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(softwareCode) > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		# endregion

		// ===================================================================================== //
		// �v���C�x�[�g���\�b�h
		// ===================================================================================== //
		# region Private Methods
		/// <summary>
		/// �ϐ�����������
		/// </summary>
		private void InitializeMembers()
		{
			this._customerMenuForm = new SFCMN00221UJ(this._controlScreenSkin);
			this._stockSlipMenuForm = new SFCMN00221UK(this._controlScreenSkin);
			this._customerSearchForm = new SFCMN00221UM(this._controlScreenSkin);
			this._supplierSearchForm = new SFCMN00221UQ(this._controlScreenSkin);				// 2008.05.22 Add
			this._customerSearchRetRecordList = new List<CustomerSearchRet>();
			this._supplierSearchRetRecordList = new List<Supplier>();							// 2008.05.22 Add
			this._stockSlipRecordList = new List<SearchRetStockSlip>();
			this._panelChangeRecordList = new List<PanelChangeRecord>();
			this._panelChangeRecordListIndex = 0;
			this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;							// ��ƃR�[�h���擾

			this._topMenuForm.PanelChange += new PanelChangeEventHandler(this.ChildForm_PanelChange);
			this._topMenuForm.TopMenuSelect += new TopMenuSelectEventHandler(this.TopMenuForm_TopMenuSelect);
			this._topMenuForm.CustomerSelected += new CustomerSelectedHandler(this.CustomerSearchForm_CustomerSelected);
			this._topMenuForm.SupplierSelected += new SupplierSelectedHandler(this.SupplierSearchForm_SupplierSelected);	// 2008.05.22 Add
			this._topMenuForm.StockSlipSelected += new SearchRetStockSlipSelectedHandler(this.StockSlipSearchForm_searchRetStockSlipSelected);

			this._customerSearchForm.PanelChange += new PanelChangeEventHandler(this.ChildForm_PanelChange);
			this._customerSearchForm.CustomerSelected += new CustomerSelectedHandler(this.CustomerSearchForm_CustomerSelected);

			// 2008.05.22 Add >>>
			this._supplierSearchForm.PanelChange += new PanelChangeEventHandler(this.ChildForm_PanelChange);
			this._supplierSearchForm.SupplierSelected += new SupplierSelectedHandler(this.SupplierSearchForm_SupplierSelected);
			// 2008.05.22 Add <<<

			this._stockSlipSearchForm.PanelChange += new PanelChangeEventHandler(this.ChildForm_PanelChange);
			this._stockSlipSearchForm.SearchRetStockSlipSelected += new SearchRetStockSlipSelectedHandler(this.StockSlipSearchForm_searchRetStockSlipSelected);

			this._customerMenuForm.LuncherStart += new LuncherStartEventHandler(this.MenuForm_LuncherStart);
			this._stockSlipMenuForm.LuncherStart += new LuncherStartEventHandler(this.MenuForm_LuncherStart);

			//this._controlScreenSkin.SettingScreenSkin(this._customerMenuForm);
			//this._controlScreenSkin.SettingScreenSkin(this._stockSlipMenuForm);
			//this._controlScreenSkin.SettingScreenSkin(this._customerSearchForm);
		}

		/// <summary>
		/// ��������(�����l�ݒ�XML�ǂݍ��ݓ�)
		/// </summary>
		private void LoadInitialData()
		{
			// �ŋߎQ�Ƃ������Ӑ�t�@�C���̓Ǎ���(XML)
			try
			{
				CustomerSearchRet[] customerSearchRetArray = new CustomerSearchRet[0];

				if (UserSettingController.ExistUserSetting(this._customerInitialDataFilePath))
				{
					customerSearchRetArray = UserSettingController.DecryptionDeserializeUserSetting<CustomerSearchRet[]>(this._customerInitialDataFilePath, new string[] { this.GetType().FullName, DATFILE_INITIALDATA_CUSTOMER });
				}

				this._customerSearchRetRecordList.AddRange(customerSearchRetArray);
			}
			catch
			{
				try
				{
					UserSettingController.DeleteUserSetting(this._customerInitialDataFilePath);
				}
				catch { }
			}

			// �ŋߎQ�Ƃ����d����t�@�C���̓Ǎ���(XML)
			try
			{
				// 2008.05.22 Update >>>
				//CustomerSearchRet[] supplierSearchRetArray = new CustomerSearchRet[0];

				//if (UserSettingController.ExistUserSetting(this._supplierInitialDataFilePath))
				//{
				//    supplierSearchRetArray = UserSettingController.DecryptionDeserializeUserSetting<CustomerSearchRet[]>(this._supplierInitialDataFilePath, new string[] { this.GetType().FullName, DATFILE_INITIALDATA_SUPPLIER });
				//}

				//this._supplierSearchRetRecordList.AddRange(supplierSearchRetArray);

				Supplier[] supplierSearchRetArray = new Supplier[0];

				if (UserSettingController.ExistUserSetting(this._supplierInitialDataFilePath))
				{
					supplierSearchRetArray = UserSettingController.DecryptionDeserializeUserSetting<Supplier[]>(this._supplierInitialDataFilePath, new string[] { this.GetType().FullName, DATFILE_INITIALDATA_SUPPLIER });
				}

				this._supplierSearchRetRecordList.AddRange(supplierSearchRetArray);

				// 2008.05.22 Update <<<
			}
			catch
			{
				try
				{
					UserSettingController.DeleteUserSetting(this._supplierInitialDataFilePath);
				}
				catch { }
			}

			// �ŋߎQ�Ƃ����d���`�[�t�@�C���̓Ǎ���(XML)
			try
			{
				SearchRetStockSlip[] stockSlipArray = new SearchRetStockSlip[0];

				if (UserSettingController.ExistUserSetting(this._stockSlipInitialDataFilePath))
				{
					stockSlipArray = UserSettingController.DecryptionDeserializeUserSetting<SearchRetStockSlip[]>(this._stockSlipInitialDataFilePath, new string[] { this.GetType().FullName, DATFILE_INITIALDATA_STOCKSLIP });
				}

				this._stockSlipRecordList.AddRange(stockSlipArray);
			}
			catch
			{
				try
				{
					UserSettingController.DeleteUserSetting(this._stockSlipInitialDataFilePath);
				}
				catch { }
			}

			// TOP���j���[����XML���ǂݏo��
			// �^�u�ǉ��A�Z���u����`�t�@�C���̓Ǎ���(XML)
			try
			{
				System.IO.FileStream fs = new System.IO.FileStream(XML_FILE_TOPMENU_INFO + this._xmlNoString + XML_FILE_EXTENSION, System.IO.FileMode.Open, System.IO.FileAccess.Read);
				System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(LuncherTopMenuInfo[]));
				this._luncherTopMenuInfoArray = (LuncherTopMenuInfo[])serializer.Deserialize(fs);
				fs.Close();
			}
			catch (Exception e)
			{
				TMsgDisp.Show(
					Form.ActiveForm,
					emErrorLevel.ERR_LEVEL_STOPDISP,
					this.Name,
					e.Message,
					-1,
					MessageBoxButtons.OK);
			}

			// �����`���[���j���[����XML���ǂݏo��
			// �^�u�ǉ��A�Z���u����`�t�@�C���̓Ǎ���(XML)
			try
			{
				System.IO.FileStream fs = new System.IO.FileStream(XML_FILE_ASSEMBLY_INFO + this._xmlNoString + XML_FILE_EXTENSION, System.IO.FileMode.Open, System.IO.FileAccess.Read);
				System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(LuncherStartAssemblyInfo[]));
				this._luncherStartAssemblyInfoArray = (LuncherStartAssemblyInfo[])serializer.Deserialize(fs);
				fs.Close();
			}
			catch(Exception e)
			{
				TMsgDisp.Show(
					Form.ActiveForm,
					emErrorLevel.ERR_LEVEL_STOPDISP,
					this.Name,
					e.Message,
					-1,
					MessageBoxButtons.OK);
			}

			// �����`���[���j���[����XML���ǂݏo��
			// �^�u�ǉ��A�Z���u����`�t�@�C���̓Ǎ���(XML)
			try
			{
				System.IO.FileStream fs = new System.IO.FileStream(XML_FILE_STOCKSLIP_LUNCHER_INFO + this._xmlNoString + XML_FILE_EXTENSION, System.IO.FileMode.Open, System.IO.FileAccess.Read);
				System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(LuncherStartAssemblyInfo[]));
				this._odrLuncherStartAssemblyInfoArray = (LuncherStartAssemblyInfo[])serializer.Deserialize(fs);
				fs.Close();
			}
			catch(Exception)
			{
				/*
				TMsgDisp.Show(
					Form.ActiveForm,
					emErrorLevel.ERR_LEVEL_STOPDISP,
					this.Name,
					e.Message,
					-1,
					MessageBoxButtons.OK);
				*/
			}
		}

		/// <summary>
		/// �����\���pXML�i�ŐV�̓��Ӑ���j�ۑ�����
		/// </summary>
		private void SaveInitialData()
		{
			// �N�������f�[�^XML��������
			try
			{
				// �ŋߎQ�Ƃ������Ӑ�t�@�C���̏�������(XML)
				if (this._customerSearchRetRecordList != null)
				{
					CustomerSearchRet[] customerSearchRetArray = this._customerSearchRetRecordList.ToArray();
					UserSettingController.EncryptionSerializeUserSetting(customerSearchRetArray, this._customerInitialDataFilePath, new string[] { this.GetType().FullName, DATFILE_INITIALDATA_CUSTOMER });
				}

				// �ŋߎQ�Ƃ����d����t�@�C���̏�������(XML)
				if (this._supplierSearchRetRecordList != null)
				{
					// 2008.05.22 Update >>>
					//CustomerSearchRet[] supplierSearchRetArray = this._supplierSearchRetRecordList.ToArray();
					Supplier[] supplierSearchRetArray = this._supplierSearchRetRecordList.ToArray();
					// 2008.05.22 Update <<<
					UserSettingController.EncryptionSerializeUserSetting(supplierSearchRetArray, this._supplierInitialDataFilePath, new string[] { this.GetType().FullName, DATFILE_INITIALDATA_SUPPLIER });
				}

				// �ŋߎQ�Ƃ����d���`�[�t�@�C���̏�������(XML)
				if (this._stockSlipRecordList != null)
				{
					SearchRetStockSlip[] searchRetStockSlipArray = this._stockSlipRecordList.ToArray();
					UserSettingController.EncryptionSerializeUserSetting(searchRetStockSlipArray, this._stockSlipInitialDataFilePath, new string[] { this.GetType().FullName, DATFILE_INITIALDATA_STOCKSLIP });
				}

				// �d���`�[�����̗�\����ԃN���X�ۑ�����
                if (this._stockSlipSearchForm != null)
                {
                    this._stockSlipSearchForm.SaveColDisplayStatus();
                }

				// ���Ӑ挟���̗�\����ԃN���X�ۑ�����
                if (this._customerSearchForm != null)
                {
                    this._customerSearchForm.SaveColDisplayStatus();
                }

				// 2008.05.22 Add >>>
				// �d���挟���̗�\����ԃN���X�ۑ�����
                if (this._supplierSearchForm != null)
                {
                    this._supplierSearchForm.SaveColDisplayStatus();
                }
				// 2008.05.22 Add <<<
			}
			catch(Exception ex)
			{
				TMsgDisp.Show(
					Form.ActiveForm,
					emErrorLevel.ERR_LEVEL_STOPDISP,
					this.Name,
					ex.Message,
					-1,
					MessageBoxButtons.OK);
			}
		}

		/// <summary>
		/// ��ʏ����\���ݒ菈��
		/// </summary>
		private void DisplayInitialSetting()
		{
			// �C���[�W�A�C�R���ݒ菈��
			ImageList imglist = IconResourceManagement.ImageList16;
			this.uButton_Before.Appearance.Image = imglist.Images[(int)Size16_Index.BEFORE];		// �O�փ{�^��
			this.uButton_Next.Appearance.Image	= imglist.Images[(int)Size16_Index.NEXT];			// ���փ{�^��
			this.uButton_Home.Appearance.Image	= imglist.Images[(int)Size16_Index.MAIN];			// �z�[���{�^��

			this._topMenuForm.CustomerListShow = this._param.ShowCustomerList;
			this._topMenuForm.StockSlipListShow = this._param.ShowStockSlipList;
		}

		/// <summary>
		/// �ŋߑI���������Ӑ��񃊃X�g�ǉ�����
		/// </summary>
		/// <param name="customerSearchRet">���Ӑ挟�����ʃN���X</param>
		private void CustomerSearchRetRecordListAdd(CustomerSearchRet settingInfo)
		{
			if (settingInfo.CustomerCode == 0) return;

			if (this._param.SupplierDiv == 1)
			{
				for (int i = 0; i < this._supplierSearchRetRecordList.Count; i++)
				{
					CustomerSearchRet customerSearchRet = this._customerSearchRetRecordList[i];

					if (settingInfo.CustomerCode == customerSearchRet.CustomerCode)
					{
						this._supplierSearchRetRecordList.RemoveAt(i);
						break;
					}
				}

				this._customerSearchRetRecordList.Add(settingInfo.Clone());

				// �ŋ߂̂T���̂ݎc��
				if (this._supplierSearchRetRecordList.Count > 5)
				{
					this._supplierSearchRetRecordList.RemoveAt(0);
				}
			}
			else
			{
				for (int i = 0; i < this._customerSearchRetRecordList.Count; i++)
				{
					CustomerSearchRet customerSearchRet = this._customerSearchRetRecordList[i];

					if (settingInfo.CustomerCode == customerSearchRet.CustomerCode)
					{
						this._customerSearchRetRecordList.RemoveAt(i);
						break;
					}
				}

				this._customerSearchRetRecordList.Add(settingInfo.Clone());

				// �ŋ߂̂T���̂ݎc��
				if (this._customerSearchRetRecordList.Count > 5)
				{
					this._customerSearchRetRecordList.RemoveAt(0);
				}
			}
		}

		// 2008.05.22 Add >>>
		/// <summary>
		/// �ŋߑI�������d�����񃊃X�g�ǉ�����
		/// </summary>
		/// <param name="customerSearchRet">�d���挟�����ʃN���X</param>
		private void SupplierSearchRetRecordListAdd( Supplier settingInfo )
		{
			if (settingInfo.SupplierCd == 0) return;

			if (this._param.SupplierDiv == 1)
			{
				for (int i = 0; i < this._supplierSearchRetRecordList.Count; i++)
				{
					Supplier supplierSearchRet = this._supplierSearchRetRecordList[i];

					if (settingInfo.SupplierCd == supplierSearchRet.SupplierCd)
					{
						this._supplierSearchRetRecordList.RemoveAt(i);
						break;
					}
				}

				this._supplierSearchRetRecordList.Add(settingInfo.Clone());

				// �ŋ߂̂T���̂ݎc��
				if (this._supplierSearchRetRecordList.Count > 5)
				{
					this._supplierSearchRetRecordList.RemoveAt(0);
				}
			}
			else
			{
				for (int i = 0; i < this._supplierSearchRetRecordList.Count; i++)
				{
					Supplier supplierSearchRet = this._supplierSearchRetRecordList[i];

					if (settingInfo.SupplierCd == supplierSearchRet.SupplierCd)
					{
						this._supplierSearchRetRecordList.RemoveAt(i);
						break;
					}
				}

				this._supplierSearchRetRecordList.Add(settingInfo.Clone());

				// �ŋ߂̂T���̂ݎc��
				if (this._supplierSearchRetRecordList.Count > 5)
				{
					this._supplierSearchRetRecordList.RemoveAt(0);
				}
			}
		}		
		// 2008.05.22 Add <<<

		/// <summary>
		/// �ŋߑI�������d���`�[��񃊃X�g�ǉ�����
		/// </summary>
		/// <param name="stockSlip">�d���`�[���ʃN���X</param>
		private void StockSlipRecordListAdd(SearchRetStockSlip settingInfo)
		{
			if (settingInfo.SupplierSlipNo == 0) return;

			for (int i = 0; i < this._stockSlipRecordList.Count; i++)
			{
				SearchRetStockSlip searchRetStockSlip = this._stockSlipRecordList[i];

				if (settingInfo.SupplierSlipNo == searchRetStockSlip.SupplierSlipNo)
				{
					this._stockSlipRecordList.RemoveAt(i);
					break;
				}
			}

			this._stockSlipRecordList.Add(settingInfo);

			// �e�V�X�e���P�ʂɍő�T���c��
			List<int> indexList = new List<int>();
			for (int i = 0; i < this._stockSlipRecordList.Count; i++)
			{
				indexList.Add(i);
			}

			if (indexList.Count > 5)
			{
				this._stockSlipRecordList.RemoveAt(indexList[0]);
			}
		}

		/// <summary>
		/// �q�t�H�[���p�l���ύX�C�x���g�p���\�b�h
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^�N���X</param>
		private void ChildForm_PanelChange(object sender, PanelChangeEventArgs e)
		{
			if ((e.DispNo == FORM_STATUS_FindCustomer) ||
				(e.DispNo == FORM_STATUS_FindSupplier)) 
			{
				if (!LoginInfoAcquisition.OnlineFlag)
				{
					TMsgDisp.Show(
						Form.ActiveForm,
						emErrorLevel.ERR_LEVEL_INFO,
						this.Name,
						"�I�t���C�����[�h�ׁ̈A�������s���܂���B",
						0,
						MessageBoxButtons.OK);

					return;
				}
			}

			// ��ʕ\�������̍X�V����
			if (e.RecodeUpdateMode == PanelChangeEventArgs.MODE_UPDATE)
			{
				if (this._panelChangeRecordList.Count > 0 && this._panelChangeRecordListIndex < this._panelChangeRecordList.Count)
				{
					this._panelChangeRecordList.RemoveRange(this._panelChangeRecordListIndex, this._panelChangeRecordList.Count - this._panelChangeRecordListIndex);
				}

				PanelChangeRecord panelChangeRecord = new PanelChangeRecord(e.DispNo);
				this._panelChangeRecordList.Add(panelChangeRecord);
				this._panelChangeRecordListIndex++;
			}

			// ���փ{�^���ƑO�փ{�^���̕\���E��\��
			if (this._panelChangeRecordListIndex > 1)
			{
				this.uButton_Before.Enabled = true;
			}
			else
			{
				this.uButton_Before.Enabled = false;
			}

			if (this._panelChangeRecordList.Count > this._panelChangeRecordListIndex)
			{
				this.uButton_Next.Enabled = true;
			}
			else
			{
				this.uButton_Next.Enabled = false;
			}

			if (this._displayPanel != null)
			{
				this.panel_Frame.Controls.Remove(this._displayPanel);
			}

			if (e.DispNo == FORM_STATUS_FindCustomer)
			{
				// ���Ӑ挟����ʂ�
				this._displayPanel = this._customerSearchForm.panel_Main;

				// �d����w��̃v���p�e�B��������
				SFCMN00221UAParam param = this._param.Clone();
				param.SupplierDiv = 0;

				this._customerSearchForm.InitialSetting(param);
				this._customerSearchForm.PanelActivated();
			}
			else if (e.DispNo == FORM_STATUS_FindSupplier)
			{
				// 2008.05.22 Update >>>
				//// ���Ӑ挟����ʁi�d����w��j��
				//this._displayPanel = this._customerSearchForm.panel_Main;

				//// �d����w��̃v���p�e�B��ݒ�
				//SFCMN00221UAParam param = this._param.Clone();
				//param.SupplierDiv = 1;
				//this._customerSearchForm.InitialSetting(param);

				//this._customerSearchForm.PanelActivated();

				// �d���挟����ʂ�
				this._displayPanel = this._supplierSearchForm.panel_Main;

				// �d����w��̃v���p�e�B��ݒ�
				SFCMN00221UAParam param = this._param.Clone();
				param.SupplierDiv = 1;
				this._supplierSearchForm.InitialSetting(param);

				this._supplierSearchForm.PanelActivated();
				// 2008.05.22 Update <<<

			}
			else if (e.DispNo == FORM_STATUS_FindStockSlip)
			{
				// �d���`�[������ʂ�
				this._displayPanel = this._stockSlipSearchForm.panel_Main;
				this._stockSlipSearchForm.PanelActivated();
			}
			else if (e.DispNo == FORM_STATUS_CustomerLuncher)
			{
				// 2008.05.22 Update >>>
				// �I�𓾈Ӑ�\����ʂ�
				this._displayPanel = this._customerMenuForm.panel_Main;

				// 2008.05.22 Update >>>
				//// �ŋߑI���������Ӑ��񃊃X�g�ǉ�����
				//this.CustomerSearchRetRecordListAdd(this._customerSearchRet);

				//this._customerMenuForm.CustomerSearchRet_Data = this._customerSearchRet;

				if (this._param.SupplierDiv == 1)
				{
					// �ŋߑI�������d�����񃊃X�g�ǉ�����
					this.SupplierSearchRetRecordListAdd(this._supplierSearchRet);

					this._customerMenuForm.SupplierSearchRet_Data = this._supplierSearchRet;
				}
				else
				{
					// �ŋߑI���������Ӑ��񃊃X�g�ǉ�����
					this.CustomerSearchRetRecordListAdd(this._customerSearchRet);

					this._customerMenuForm.CustomerSearchRet_Data = this._customerSearchRet;
				}
				// 2008.05.22 Update <<<

				this._customerMenuForm.InitialSetting(this._param);
			}
			else if (e.DispNo == FORM_STATUS_StockSlipLuncher)
			{
				// �I���d���`�[�\����ʂ�
				this._displayPanel = this._stockSlipMenuForm.panel_Main;

				// �ŋߑI�������d���`�[��񃊃X�g�ǉ�����
				this.StockSlipRecordListAdd(this._searchRetStockSlip);

				this._stockSlipMenuForm.SearchRetStockSlip_Data = this._searchRetStockSlip;
				this._stockSlipMenuForm.InitialSetting(this._param);
			}
			else
			{
				// TOP��ʂ�
				this._displayPanel = this._topMenuForm.panel_Main;

				// ��������
				this._topMenuForm.InitialSetting(this._param);
			}

			this._displayPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel_Frame.Controls.Add(this._displayPanel);
		}

		/// <summary>
		/// ���Ӑ�I���C�x���g�p���\�b�h
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="customerSearchRet">���Ӑ挟�����ʃN���X</param>
		private void CustomerSearchForm_CustomerSelected(object sender, CustomerSearchRet customerSearchRet)
		{
			this._customerSearchRet = customerSearchRet.Clone();
		}

		// 2008.05.22 Add >>>
		/// <summary>
		/// �d����I���C�x���g�p���\�b�h
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="customerSearchRet">�d����}�X�^�N���X</param>
		private void SupplierSearchForm_SupplierSelected( object sender, Supplier supplierSearchRet )
		{
			this._supplierSearchRet = supplierSearchRet.Clone();
		}
		// 2008.05.22 Add <<<

		/// <summary>
		/// �d���`�[�I���C�x���g�p���\�b�h
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="searchRetStockSlip">���Ӑ挟�����ʃN���X</param>
		private void StockSlipSearchForm_searchRetStockSlipSelected(object sender, SearchRetStockSlip searchRetStockSlip)
		{
			this._searchRetStockSlip = searchRetStockSlip;
		}

		/// <summary>
		/// ���j���[�t�H�[�������`���[�N���C�x���g�p���\�b�h
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^�N���X</param>
		private void MenuForm_LuncherStart(object sender, LuncherStartEventArgs e)
		{
			int customerCode = 0;
			int supplierSlipNo = 0;

			switch (e.DispNo)
			{
				case FORM_STATUS_CustomerLuncher:
				{
					// 2008.05.22 Update >>>
					//customerCode = this._customerSearchRet.CustomerCode;
					customerCode = ( this._param.SupplierDiv == 1 ) ? this._supplierSearchRet.SupplierCd : this._customerSearchRet.CustomerCode;
					// 2008.05.22 Update <<<

					break;
				}
				case FORM_STATUS_StockSlipLuncher:
				{
                    // UPD 2008.04.24 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                    //customerCode = this._searchRetStockSlip.CustomerCode;
                    customerCode = this._searchRetStockSlip.SupplierCd;
                    // UPD 2008.04.24 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
					supplierSlipNo = this._searchRetStockSlip.SupplierSlipNo;

					break;
				}
			}

			switch (e.LuncherStartAssemblyInfoData.Mode)
			{
				// ���Ӑ�ύX:1
				case LuncherMode_CustomerChange:
				{
					if (LoginInfoAcquisition.OnlineFlag)
					{
						if (customerCode == 0)
						{
							TMsgDisp.Show(
								Form.ActiveForm,
								emErrorLevel.ERR_LEVEL_INFO,
								this.Name,
								"���Ӑ��񂪑��݂��Ȃ��ׁA�������s���܂���B",
								0,
								MessageBoxButtons.OK);
						}
						else
						{
							// ���Ӑ�R�[�h�w��N��
							object objForm = this.LoadAssemblyFrom(
								e.LuncherStartAssemblyInfoData.AssemblyName,
								e.LuncherStartAssemblyInfoData.ClassName,
								typeof(Form),
								e.LuncherStartAssemblyInfoData.Mode,
								customerCode,
								0);

							if ((objForm != null) && (objForm is Form))
							{
								((Form)objForm).Show();
							}
						}
					}
					else
					{
						TMsgDisp.Show(
							Form.ActiveForm,
							emErrorLevel.ERR_LEVEL_INFO,
							this.Name,
							"�I�t���C�����[�h�ׁ̈A�������s���܂���B",
							0,
							MessageBoxButtons.OK);
					}

					break;
				}
				// 2008.05.22 Add >>>
				case LuncherMode_SupplierChange:
				{
					if (customerCode == 0)
						{
							TMsgDisp.Show(
								Form.ActiveForm,
								emErrorLevel.ERR_LEVEL_INFO,
								this.Name,
								"�d�����񂪑��݂��Ȃ��ׁA�������s���܂���B",
								0,
								MessageBoxButtons.OK);
						}
						else
						{
							// ���Ӑ�R�[�h�w��N��
							object objForm = this.LoadAssemblyFrom(
								e.LuncherStartAssemblyInfoData.AssemblyName,
								e.LuncherStartAssemblyInfoData.ClassName,
								typeof(Form),
								e.LuncherStartAssemblyInfoData.Mode,
								customerCode,
								0);

							if ((objForm != null) && (objForm is Form))
							{
								((Form)objForm).Show();
							}
						}
					break;
				}
				// 2008.05.22 Add <<<
				// ���Ӑ�Q��:6
				case LuncherMode_CustomerView:
				{
					if (customerCode == 0)
					{
						TMsgDisp.Show(
							Form.ActiveForm,
							emErrorLevel.ERR_LEVEL_INFO,
							this.Name,
							"���Ӑ��񂪑��݂��Ȃ��ׁA�������s���܂���B",
							0,
							MessageBoxButtons.OK);
					}
					else
					{
						// �d����R�[�h�w��N��
						object objForm = this.LoadAssemblyFrom(
							e.LuncherStartAssemblyInfoData.AssemblyName,
							e.LuncherStartAssemblyInfoData.ClassName,
							typeof(Form),
							e.LuncherStartAssemblyInfoData.Mode,
							customerCode,
							0);

						if ((objForm != null) && (objForm is Form))
						{
							((Form)objForm).Show();
						}
					}

					break;
				}
				// ���Ӑ�V�K:8
				case LuncherMode_CustomerNew:
				{
					if (LoginInfoAcquisition.OnlineFlag)
					{
						object objForm = this.LoadAssemblyFrom(
							e.LuncherStartAssemblyInfoData.AssemblyName,
							e.LuncherStartAssemblyInfoData.ClassName,
							typeof(Form),
							e.LuncherStartAssemblyInfoData.Mode,
							0,
							0);

						if ((objForm != null) && (objForm is Form))
						{
							((Form)objForm).Show();
						}
					}
					else
					{
						TMsgDisp.Show(
							Form.ActiveForm,
							emErrorLevel.ERR_LEVEL_INFO,
							this.Name,
							"�I�t���C�����[�h�ׁ̈A�������s���܂���B",
							0,
							MessageBoxButtons.OK);
					}

					break;
				}
				// ���Ӑ��`�[�ɔ��f����
				case LuncherMode_SlipSetCustomer:
				{
					if (LoginInfoAcquisition.OnlineFlag)
					{
						if (this.SelectedCustomer != null)
						{
							//this._customerSearchRet.SearchMode = e.LuncherStartAssemblyInfoData.Mode;
							this.SelectedCustomer(this._customerSearchRet);		// �e�Ɂu���Ӑ�I���v�w��
						}
					}
					else
					{
						TMsgDisp.Show(
							Form.ActiveForm,
							emErrorLevel.ERR_LEVEL_INFO,
							this.Name,
							"�I�t���C�����[�h�ׁ̈A�������s���܂���B",
							0,
							MessageBoxButtons.OK);
					}

					break;
				}
				// �d������g�p���Ă̓`�[�V�K:41
				case LuncherMode_NewSlipSetSupplier:
				{
					// 2008.05.22 Del >>>
					//if (this._customerSearchRet.SupplierDiv == 0)
					//{
					//    TMsgDisp.Show(
					//        Form.ActiveForm,
					//        emErrorLevel.ERR_LEVEL_INFO,
					//        this.Name,
					//        "�I�𒆂̓��Ӑ�͎d����ł͂Ȃ��ׁA�������s���܂���B",
					//        0,
					//        MessageBoxButtons.OK);

					//    return;
					//}
					// 2008.05.22 Del <<<

					if (LoginInfoAcquisition.OnlineFlag)
					{
						// 2008.05.22 Update >>>
						//if (this.CreateNewSlip != null)
						//{
						//    CustomerSearchRet setData = this._customerSearchRet.Clone();
						//    this.CreateNewSlip(setData);			// �e�Ɂu�V�K�`�[�쐬�v�w��
						//}

						if (this.CreateNewSlipUsedSupplier != null)
						{
							Supplier setData = this._supplierSearchRet.Clone();
							this.CreateNewSlipUsedSupplier(setData);			// �e�Ɂu�V�K�`�[�쐬�v�w��
						}

						// 2008.05.22 Update <<<
					}
					else
					{
						TMsgDisp.Show(
							Form.ActiveForm,
							emErrorLevel.ERR_LEVEL_INFO,
							this.Name,
							"�I�t���C�����[�h�ׁ̈A�������s���܂���B",
							0,
							MessageBoxButtons.OK);
					}

					break;
				}
				// �I�𒆂̎d�����`�[�ɔ��f����:42
				case LuncherMode_SlipSetSupplier:
				{
					// 2008.05.22 Del >>>
					//if (this._customerSearchRet.SupplierDiv == 0)
					//{
					//    TMsgDisp.Show(
					//        Form.ActiveForm,
					//        emErrorLevel.ERR_LEVEL_INFO,
					//        this.Name,
					//        "�I�𒆂̓��Ӑ�͎d����ł͂Ȃ��ׁA�������s���܂���B",
					//        0,
					//        MessageBoxButtons.OK);

					//    return;
					//}
					// 2008.05.22 Del <<<

					if (LoginInfoAcquisition.OnlineFlag)
					{
						// 2008.05.22 Update >>>
						//if (this.SelectedCustomer != null)
						//{
						//    //this._customerSearchRet.SearchMode = e.LuncherStartAssemblyInfoData.Mode;
						//    this.Selectedsupp(this._customerSearchRet);		// �e�Ɂu���Ӑ�I���v�w��
						//}

						if (this.SelectedSupplier != null)
						{
							this.SelectedSupplier(this._supplierSearchRet);		// �e�Ɂu�d����I���v�w��
						}
						// 2008.05.22 Update <<<
					}
					else
					{
						TMsgDisp.Show(
							Form.ActiveForm,
							emErrorLevel.ERR_LEVEL_INFO,
							this.Name,
							"�I�t���C�����[�h�ׁ̈A�������s���܂���B",
							0,
							MessageBoxButtons.OK);
					}

					break;
				}
				// �d���`�[����:5
				case LuncherMode_StockSlipSearch:
				{
					// �d���`�[��ʂɑJ�ڂ��A���Ӑ�R�[�h�������Z�b�g�E�`�[�������������s����
					PanelChangeEventArgs ea = new PanelChangeEventArgs(PanelChangeEventArgs.MODE_UPDATE, FORM_STATUS_FindStockSlip);
					this.ChildForm_PanelChange(this, ea);

                    // 2008.09.05 Update >>>
					//this._stockSlipSearchForm.AutoSearch(this._customerSearchRet.CustomerCode);
                    this._stockSlipSearchForm.AutoSearch(this._supplierSearchRet.SupplierCd, this._supplierSearchRet.SupplierNm1 + " " + this._supplierSearchRet.SupplierNm2);
                    // 2008.09.05 Update <<<

					break;
				}
				// �`�[�C��:10
				case LuncherMode_ModifyStockSlip:
				{
					if (this.ModifyStockSlip != null)
					{
						this.ModifyStockSlip(this._searchRetStockSlip);				// �e�Ɂu�`�[�Ăяo���쐬�v�w��
					}

					break;
				}
				// �ԓ`�쐬:11
				case LuncherMode_SlipAbuild:
				{
					if (this.RedWriteStockSlip != null)
					{
						this.RedWriteStockSlip(this._searchRetStockSlip);			// �e�Ɂu�ԓ`�쐬�v�w��
					}
					break;
				}
				// ���׌v��:12
				case LuncherMode_TrustAppropriate:
				{
					if (this.TrustAppropriateStockSlip != null)
					{
						this.TrustAppropriateStockSlip(this._searchRetStockSlip);	// �e�Ɂu���׌v��v�w��
					}
					break;
				}
				// �`�[�R�s�[:25
				case LuncherMode_SlipCopy:
				{
					// 2007.10.12 sasaki >>
					if (this.SlipCopy != null)
					{
						this.SlipCopy(this._searchRetStockSlip);					// �e�Ɂu�`�[�R�s�[�v�w��
					}
					// 2007.10.12 sasaki <<

					/*
					if ((LoginInfoAcquisition.OnlineFlag) && (!this._stockSlip.OfflineDataFlg))
					{
						SFMIT01235U sfmit01235u = new SFMIT01235U();
						CustomSerializeArrayList blackWorkList = new CustomSerializeArrayList();
						int nStatus = sfmit01235u.CopyAcceptOdr(this, 0, _stockSlip, out blackWorkList);
						switch (nStatus)
						{
							case 1:	// �ҏW
							if (this.ModifyOrderWithData != null) this.ModifyOrderWithData(blackWorkList);
							break;
						}
					}
					else if (this._stockSlip.OfflineDataFlg)
					{
						TMsgDisp.Show(
							Form.ActiveForm,
							emErrorLevel.ERR_LEVEL_INFO,
							this.Name,
							"���[�J���ۑ��f�[�^�ׁ̈A�������s���܂���B",
							0,
							MessageBoxButtons.OK);
					}
					else
					{
						TMsgDisp.Show(
							Form.ActiveForm,
							emErrorLevel.ERR_LEVEL_INFO,
							this.Name,
							"�I�t���C�����[�h�ׁ̈A�������s���܂���B",
							0,
							MessageBoxButtons.OK);
					}
					*/
					break;
				}
			}
		}

		/// <summary>
		/// �g�b�v���j���[�I���C�x���g���\�b�h
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="luncherTopMenuInfo">�g�b�v���j���[�����`���[���N���X</param>
		private void TopMenuForm_TopMenuSelect(object sender, LuncherTopMenuInfo luncherTopMenuInfo)
		{
			switch (luncherTopMenuInfo.Mode)
			{
				// ���Ӑ挟��:1
				case TOP_MODE_CustomerSearch:
				{
					break;
				}
				// �d���`�[����:2
				case TOP_MODE_StockSlipSearch:
				{
					break;
				}
				// �V�K�`�[�쐬:3
				case TOP_MODE_NewSlip:
				{
					// �ڋq�����N���A
					CustomerSearchRet customerSearchRet = new CustomerSearchRet();

					if (this.CreateNewSlip != null)
					{
						this.CreateNewSlip(customerSearchRet);		// �e�Ɂu�V�K�`�[�쐬�v�w��
					}

					break;
				}
                // 2008.09.18 Add >>>
                // �V�K�d���`�[�쐬:8
                case TOP_MODE_NewStockSlip:
                {
                    // �ڋq�����N���A
                    Supplier supplier = new Supplier();

                    if (this.CreateNewSlipUsedSupplier != null)
                    {
                        this.CreateNewSlipUsedSupplier(supplier);		// �e�Ɂu�V�K�`�[�쐬�v�w��
                    }

                    break;
                }
                // 2008.09.18 Add <<<

				// ���Ӑ�̐V�K�쐬:6
				case TOP_MODE_NewCustomer:
				{
					LuncherStartAssemblyInfo luncherStartAssemblyInfo  = new LuncherStartAssemblyInfo();
					luncherStartAssemblyInfo.AssemblyName = luncherTopMenuInfo.AssemblyName;
					luncherStartAssemblyInfo.ClassName = luncherTopMenuInfo.ClassName;
					luncherStartAssemblyInfo.DispName = luncherTopMenuInfo.DispName;
					luncherStartAssemblyInfo.ImageNo = luncherTopMenuInfo.ImageNo;
					luncherStartAssemblyInfo.Mode = LuncherMode_CustomerNew;

					LuncherStartEventArgs e = new LuncherStartEventArgs(luncherStartAssemblyInfo, FORM_STATUS_Top);
					this.MenuForm_LuncherStart(this, e);
					break;
				}
			}
		}

		/// <summary>
		/// �A�Z���u�����[�h�E�C���X�^���X������
		/// </summary>
		/// <param name="asmname">�A�Z���u������</param>
		/// <param name="classname">�N���X����</param>
		/// <param name="type">��������N���X�^</param>
		/// <param name="mode">�N���p�^�[��</param>
		/// <param name="customerCode">���Ӑ�R�[�h</param>
		/// <param name="supplierSlipNo">�d���`�[�`�[�ԍ�</param>
		/// <returns>�C���X�^���X�����ꂽ�N���X</returns>
		private object LoadAssemblyFrom(string asmname, string classname, Type type, int mode, int customerCode, int supplierSlipNo)
		{
			object	obj	= null;
			try
			{
				System.Reflection.Assembly	asm	= System.Reflection.Assembly.Load(asmname);
				Type	objType	= asm.GetType(classname);
				if (objType != null)
				{
					if ((objType == type) || (objType.IsSubclassOf(type) == true) || (objType.GetInterface(type.Name).Name == type.Name))
					{
						// �p�����[�^��n��
						if (mode == LuncherMode_CustomerChange)												// ���Ӑ�C��
						{
							// ���Ӑ�R�[�h�w��N��
							object [] args = {1, this._enterpriseCode, customerCode};
							obj = Activator.CreateInstance(objType, args);
						}
						// 2008.05.22 Add >>>
						else if (mode == LuncherMode_SupplierChange)										// �d����C��
						{
							// �d����R�[�h�w��N��
							object[] args = { 1, this._enterpriseCode, customerCode };
							obj = Activator.CreateInstance(objType, args);
						}
						// 2008.05.22 Add <<<
						else if (mode == LuncherMode_CustomerView)											// ���Ӑ�Q�Ǝ�
						{
							// ���Ӑ�R�[�h�w��N��
							object[] args = { 2, this._enterpriseCode, customerCode };
							obj = Activator.CreateInstance(objType, args);
						}
						else
						{
							// �p�����[�^�Ȃ��N��
							obj = Activator.CreateInstance(objType);
						}
					}
				}
			}
			catch(System.Exception er)
			{
				TMsgDisp.Show(
					Form.ActiveForm,
					emErrorLevel.ERR_LEVEL_STOPDISP,
					this.Name,
					er.Message,
					-1,
					MessageBoxButtons.OK);

			}

			return obj;
		}

		/// <summary>
		/// �A�Z���u�����[�h�E�C���X�^���X�������i�I�[�o�[���[�h�j
		/// </summary>
		/// <param name="asmname">�A�Z���u������</param>
		/// <param name="classname">�N���X����</param>
		/// <param name="type">��������N���X�^</param>
		/// <returns>�C���X�^���X�����ꂽ�N���X</returns>
		private	object LoadAssemblyFrom(string asmname, string classname, Type type)
		{
			object	obj	= null;
			try
			{

				System.Reflection.Assembly	asm	= System.Reflection.Assembly.Load(asmname);
				Type	objType	= asm.GetType(classname);
				if (objType != null)
				{
					if ((objType == type) || (objType.IsSubclassOf(type) == true) || (objType.GetInterface(type.Name).Name == type.Name))
					{
						// �p�����[�^�Ȃ��N��
						obj = Activator.CreateInstance(objType);
					}
				}
			}
			catch(System.Exception er)
			{
				TMsgDisp.Show(
					Form.ActiveForm,
					emErrorLevel.ERR_LEVEL_STOPDISP,
					this.Name,
					er.Message,
					-1,
					MessageBoxButtons.OK);
			}

			return obj;
		}

		/// <summary>
		/// �I�𓾈Ӑ楎d���`�[���N���X�����Ӑ挟�����ʃN���X�ڍ�����
		/// </summary>
		/// <param name="selectCustomerStockSlip">�I�𓾈Ӑ楎d���`�[���N���X</param>
		/// <returns>���Ӑ�ԗ��������ʃN���X</returns>
		internal static CustomerSearchRet CopyToCustomerSearchRet(SliderSelectedData sliderSelectedData)
		{
			CustomerSearchRet customerSearchRet = new CustomerSearchRet();

			customerSearchRet.EnterpriseCode = sliderSelectedData.EnterpriseCode;
			customerSearchRet.CustomerCode = sliderSelectedData.CustomerCode;
			customerSearchRet.CustomerSubCode = sliderSelectedData.CustomerSubCode;
			customerSearchRet.Name = sliderSelectedData.Name;
			customerSearchRet.Name2 = sliderSelectedData.Name2;

			return customerSearchRet;
		}

		/// <summary>
		/// �I�𓾈Ӑ楎d���`�[���N���X���d���`�[�������ʃN���X�ڍ�����
		/// </summary>
		/// <param name="selectCustomerStockSlip">�I�𓾈Ӑ�d���`�[���N���X</param>
		/// <returns>�d���`�[�������ʃN���X</returns>
		internal static SearchRetStockSlip searchRetStockSlipFromSelectCustomerOrder(SliderSelectedData sliderSelectedData)
		{
			SearchRetStockSlip searchRetStockSlip = new SearchRetStockSlip();

			searchRetStockSlip.EnterpriseCode = sliderSelectedData.EnterpriseCode;
			searchRetStockSlip.SupplierSlipNo = sliderSelectedData.SupplierSlipNo;
			searchRetStockSlip.SupplierFormal = sliderSelectedData.SupplierFormal;

			return searchRetStockSlip;
		}

		/// <summary>
		/// �v���Z�X�X�^�[�g����
		/// </summary>
		/// <param name="programPath">�v���O�����p�X</param>
		/// <param name="arguments">����</param>
		private void ProcessStart(string programPath, string arguments)
		{
			System.Diagnostics.Process extProcess = new System.Diagnostics.Process();
			extProcess.StartInfo.FileName = programPath;
			extProcess.StartInfo.Arguments = arguments;
			extProcess.Start();
		}

		/// <summary>
		/// ���O�C���p�����[�^�擾����
		/// </summary>
		/// <returns></returns>
		private string GerLoginArguments()
		{
			System.Text.StringBuilder arguments = new System.Text.StringBuilder();
			// ���O�C���p�����[�^����ݒ�
			ApplicationStartControl applicationStartControl = new ApplicationStartControl();
			string[] loginArguments = applicationStartControl.Parameters;
			foreach (string argument in loginArguments)
			{
				if (argument.Trim() != "")
				{
					arguments.Append(argument + " ");
				}
			}

			return arguments.ToString();
		}

		# endregion

		// ===================================================================================== //
		// �e�R���g���[���C�x���g����
		// ===================================================================================== //
		# region Event Methods
		/// <summary>
		/// �t�H�[�����[�h�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^�N���X</param>
		private void SFCMN00221UA_Load(object sender, System.EventArgs e)
		{
		}

		/// <summary>
		/// ���������^�C�}�[�N���C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^�N���X</param>
		private void timer_Initial_Tick(object sender, System.EventArgs e)
		{
			this.timer_Initial.Enabled = false;

			// �ϐ�������
			this.InitializeMembers();

			// ��ʏ����\���ݒ菈��
			this.DisplayInitialSetting();

			// ��������(�����l�ݒ�XML�ǂݍ��ݓ�)
			this.LoadInitialData();

			this._topMenuForm.CustomerSearchRetRecordList = this._customerSearchRetRecordList;					// �ŋߑI���������Ӑ�ԗ����
			this._topMenuForm.SupplierSearchRetRecordList = this._supplierSearchRetRecordList;					// �ŋߑI�������d����ԗ����
			this._topMenuForm.StockSlipRecordList = this._stockSlipRecordList;									// �ŋߑI�������d���`�[���
			this._topMenuForm.LuncherTopMenuInfoArray = this._luncherTopMenuInfoArray;							// �����`���[�g�b�v���j���[���
			this._customerMenuForm.LuncherStartAssemblyInfoArray = this._luncherStartAssemblyInfoArray;			// �����`���[�\���A�Z���u�����(���Ӑ�ԗ�����)
			this._stockSlipMenuForm.OdrLuncherStartAssemblyInfoArray = this._odrLuncherStartAssemblyInfoArray;	// �����`���[�\���A�Z���u�����(�d���`�[����)

			// �g�b�v���j���[�t�H�[���^�����ݒ菈��
			PanelChangeEventArgs pe = new PanelChangeEventArgs(PanelChangeEventArgs.MODE_UPDATE, FORM_STATUS_Top);
			this.ChildForm_PanelChange(this, pe);

			// ���Ӑ挟���t�H�[���^�����ݒ菈��
			this._customerSearchForm.InitialSetting(this._param);

			// 2008.05.22 Add >>>
			// �d���挟���t�H�[���^�����ݒ菈��
			this._supplierSearchForm.InitialSetting(this._param);
			// 2008.05.22 Add <<<

			// �d���`�[�����t�H�[���^�����ݒ菈��
			this._stockSlipSearchForm.InitialSetting(this._param);
		}

		/// <summary>
		/// �z�[���{�^���N���b�N�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^�N���X</param>
		private void uButton_Home_Click(object sender, System.EventArgs e)
		{
			this._panelChangeRecordListIndex = 1;

			PanelChangeEventArgs ea = new PanelChangeEventArgs(1, FORM_STATUS_Top);
			this.ChildForm_PanelChange(sender, ea);
		}

		/// <summary>
		/// �߂�{�^���N���b�N�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^�N���X</param>
		private void uButton_Before_Click(object sender, System.EventArgs e)
		{
			this.uButton_Home.Focus();

			if (this._panelChangeRecordListIndex > 1)
			{
				this._panelChangeRecordListIndex--;

				PanelChangeRecord panelChangeRecord = this._panelChangeRecordList[this._panelChangeRecordListIndex - 1];
				
				PanelChangeEventArgs ea = new PanelChangeEventArgs(1, panelChangeRecord.DispNo);
				this.ChildForm_PanelChange(sender, ea);
			}
		}

		/// <summary>
		/// ���փ{�^���N���b�N�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^�N���X</param>
		private void uButton_Next_Click(object sender, System.EventArgs e)
		{
			this.uButton_Home.Focus();

			if (this._panelChangeRecordList.Count > this._panelChangeRecordListIndex)
			{
				this._panelChangeRecordListIndex++;

				PanelChangeRecord panelChangeRecord = this._panelChangeRecordList[this._panelChangeRecordListIndex - 1];
				
				PanelChangeEventArgs ea = new PanelChangeEventArgs(1, panelChangeRecord.DispNo);
				this.ChildForm_PanelChange(sender, ea);
			}

		}
		# endregion
	}

	# region Internal Delegate
	/// <summary>���Ӑ�I����f���Q�[�g</summary>
	internal delegate void CustomerSelectedHandler(object sender, CustomerSearchRet customerSearchRet);

	// 2008.05.22 Add >>>
	/// <summary>�d����I����f���Q�[�g</summary>
	internal delegate void SupplierSelectedHandler( object sender, Supplier supplierSearchRet );
	// 2008.05.22 Add <<<

	/// <summary>�d���`�[�I����f���Q�[�g</summary>
	internal delegate void SearchRetStockSlipSelectedHandler(object sender, SearchRetStockSlip searchRetStockSlip);
	# endregion

	# region Public Delegate
	/// <summary>���Ӑ�I���f���Q�[�g</summary>
	/// <remarks>�������Ӑ��I�����ɔ�������f���Q�[�g�ł��B��M�҂̓p�����[�^����֘A�����擾���Ă��������B</remarks>
	public delegate void SelectedCustomerHandler(CustomerSearchRet seldata);

	// 2008.05.22 Add >>>
	/// <summary>�d����I���f���Q�[�g</summary>
	/// <remarks>�����d�����I�����ɔ�������f���Q�[�g�ł��B��M�҂̓p�����[�^����֘A�����擾���Ă��������B</remarks>
	public delegate void SelectedSupplierHandler( Supplier seldata );
	// 2008.05.22 Add <<<

	/// <summary>�V�K�`�[�쐬�w���f���Q�[�g</summary>
	/// <remarks>�V�K�`�[�쐬�I�����ɔ�������f���Q�[�g�ł��B��M�҂̓p�����[�^����֘A�����擾���Ă��������B</remarks>
	public delegate void CreateNewSlipHandler(CustomerSearchRet seldata);

	// 2008.05.22 Add >>>
	/// <summary>�V�K�`�[�쐬�w���f���Q�[�g</summary>
	/// <remarks>�d������g�p���ĐV�K�`�[�쐬�I�����ɔ�������f���Q�[�g�ł��B��M�҂̓p�����[�^����֘A�����擾���Ă��������B</remarks>
	public delegate void CreateNewSlipUsedSupplierHandler( Supplier seldata );
	// 2008.05.22 Add <<<
	
	/// <summary>�`�[�Ăяo���w���f���Q�[�g</summary>
	/// <remarks>�`�[�Ăяo���I�����ɔ�������f���Q�[�g�ł��B��M�҂̓p�����[�^����֘A�����擾���Ă��������B</remarks>
	public delegate void ModifyStockSlipHandler(SearchRetStockSlip seldata);

	// 2007.10.12 sasaki >>
	/// <summary>�`�[�R�s�[�w���f���Q�[�g</summary>
	/// <remarks>�`�[�R�s�[�I�����ɔ�������f���Q�[�g�ł��B��M�҂̓p�����[�^����֘A�����擾���Ă��������B</remarks>
	public delegate void ModifySlipCopyHandler( CustomerSearchRet seldata );
	// 2007.10.12 sasaki <<
	# endregion
}

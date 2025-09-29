using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;

using Infragistics.Win.UltraWinExplorerBar;
using Infragistics.Win.UltraWinGrid;
using System.Collections;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// ����ڕW�ݒ�(����)���
	/// </summary>
	/// <remarks>
	/// <br>Note		: ����ڕW�ݒ�(����)���s����ʂł��B</br>
	/// <br>Programmer	: NEPCO</br>
	/// <br>Date		: 2007.03.29</br>
    /// <br></br>
    /// <br>UpdateNote: 2007.10.01 ��� ���b
    /// <br>            ����.NS�p�ɕύX</br>
	/// </remarks>
	public partial class MAMOK01110UA : Form, ISalesMonTargetMDIChild
	{
		# region Private Constants

        // ��ʏ�ԕۑ��p�t�@�C����
        private const string XML_FILE_INITIAL_DATA = "MAMOK01110U.dat";

		// PG����
        private const string ctPGNM = "����ڕW�ݒ�(����)";

		private const string COL_SALESTARGET_HEADER = "SalesTargetHeader";

		// Grid���KEY��� (Header��width���ƂȂ�܂�)
        private const int WIDTH_SALESTARGET_TITLE = 150;
        private const int WIDTH_SALESTARGET = 115;

		// Grid���KEY��� (Header��Title���ƂȂ�܂�)
		private const string VIEW_SALESTARGET_CLEAR = "�N���A";
		private const string VIEW_SALESTARGET_MONTH = "�K�p��";
		private const string VIEW_SALESTARGET_MONEY = "����ڕW(�~/��)";
        private const string VIEW_SALESTARGET_PROFIT = "�e���ڕW(�~/��)";
        private const string VIEW_SALESTARGET_COUNT = "���ʖڕW(��/��)";
        private const string VIEW_SALESTARGET_MONEY_SUNDAY = "���j����ڕW(�~/��)";
        private const string VIEW_SALESTARGET_PROFIT_SUNDAY = "���j�e���ڕW(�~/��)";
        private const string VIEW_SALESTARGET_COUNT_SUNDAY = "���j���ʖڕW(��/��)";
        private const string VIEW_SALESTARGET_MONEY_MONDAY = "���j����ڕW(�~/��)";
        private const string VIEW_SALESTARGET_PROFIT_MONDAY = "���j�e���ڕW(�~/��)";
        private const string VIEW_SALESTARGET_COUNT_MONDAY = "���j���ʖڕW(��/��)";
        private const string VIEW_SALESTARGET_MONEY_TUESDAY = "�Ηj����ڕW(�~/��)";
        private const string VIEW_SALESTARGET_PROFIT_TUESWDAY = "�Ηj�e���ڕW(�~/��)";
        private const string VIEW_SALESTARGET_COUNT_TUESDAY = "�Ηj���ʖڕW(��/��)";
        private const string VIEW_SALESTARGET_MONEY_WEDNESDAY = "���j����ڕW(�~/��)";
        private const string VIEW_SALESTARGET_PROFIT_WEDNESDAY = "���j�e���ڕW(�~/��)";
        private const string VIEW_SALESTARGET_COUNT_WEDNESDAY = "���j���ʖڕW(��/��)";
        private const string VIEW_SALESTARGET_MONEY_THURSDAY = "�ؗj����ڕW(�~/��)";
        private const string VIEW_SALESTARGET_PROFIT_THURSDAY = "�ؗj�e���ڕW(�~/��)";
        private const string VIEW_SALESTARGET_COUNT_THURSDAY = "�ؗj���ʖڕW(��/��)";
        private const string VIEW_SALESTARGET_MONEY_FRIDAY = "���j����ڕW(�~/��)";
        private const string VIEW_SALESTARGET_PROFIT_FRIDAY = "���j�e���ڕW(�~/��)";
        private const string VIEW_SALESTARGET_COUNT_FRIDAY = "���j���ʖڕW(��/��)";
        private const string VIEW_SALESTARGET_MONEY_SATURDAY = "�y�j����ڕW(�~/��)";
        private const string VIEW_SALESTARGET_PROFIT_SATURDAY = "�y�j�e���ڕW(�~/��)";
        private const string VIEW_SALESTARGET_COUNT_SATURDAY = "�y�j���ʖڕW(��/��)";
        private const string VIEW_SALESTARGET_MONEY_HOLIDAY = "�j�Փ�����ڕW(�~/��)";
        private const string VIEW_SALESTARGET_PROFIT_HOLIDAY = "�j�Փ��e���ڕW(�~/��)";
        private const string VIEW_SALESTARGET_COUNT_HOLIDAY = "�j�Փ����ʖڕW(��/��)";

        // Grid�s��KEY��� (�s�̃C���f�b�N�X�ƂȂ�܂�)
        private const int ROW_CLEAR = 0;
        private const int ROW_DATE = 1;
        private const int ROW_SALESTARGETMONEY = 2;
        private const int ROW_SALESTARGETPROFIT = 3;
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        //private const int ROW_SALESTARGETCOUNT = 4;
        //private const int ROW_SALESTARGET_MONEY_SUNDAY = 5;
        //private const int ROW_SALESTARGET_PROFIT_SUNDAY = 6;
        //private const int ROW_SALESTARGET_COUNT_SUNDAY = 7;
        //private const int ROW_SALESTARGET_MONEY_MONDAY = 8;
        //private const int ROW_SALESTARGET_PROFIT_MONDAY = 9;
        //private const int ROW_SALESTARGET_COUNT_MONDAY = 10;
        //private const int ROW_SALESTARGET_MONEY_TUESDAY = 11;
        //private const int ROW_SALESTARGET_PROFIT_TUESWDAY = 12;
        //private const int ROW_SALESTARGET_COUNT_TUESDAY = 13;
        //private const int ROW_SALESTARGET_MONEY_WEDNESDAY = 14;
        //private const int ROW_SALESTARGET_PROFIT_WEDNESDAY = 15;
        //private const int ROW_SALESTARGET_COUNT_WEDNESDAY = 16;
        //private const int ROW_SALESTARGET_MONEY_THURSDAY = 17;
        //private const int ROW_SALESTARGET_PROFIT_THURSDAY = 18;
        //private const int ROW_SALESTARGET_COUNT_THURSDAY = 19;
        //private const int ROW_SALESTARGET_MONEY_FRIDAY = 20;
        //private const int ROW_SALESTARGET_PROFIT_FRIDAY = 21;
        //private const int ROW_SALESTARGET_COUNT_FRIDAY = 22;
        //private const int ROW_SALESTARGET_MONEY_SATURDAY = 23;
        //private const int ROW_SALESTARGET_PROFIT_SATURDAY = 24;
        //private const int ROW_SALESTARGET_COUNT_SATURDAY = 25;
        //private const int ROW_SALESTARGET_MONEY_HOLIDAY = 26;
        //private const int ROW_SALESTARGET_PROFIT_HOLIDAY = 27;
        //private const int ROW_SALESTARGET_COUNT_HOLIDAY = 28;
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

		private const string RATIO = "1.00";
        private const string FORMAT_NUM = "###,###";
        private const string FORMAT_NUM_ZERO = "###,##0";
        private const string FORMAT_NUM_DECIMAL = "N1";

        private const int HEIGHT_EXPLORERBAR = 223;
        private const int HEIGHT_PANEL = 191;

        // ���_�ڕW�p�]�ƈ��R�[�h
        private const string EMPLOYEECODE_SECTION = "SECTION";

		private readonly Color COLOR_BACKCOLOR = Color.FromArgb(89, 135, 214);
		private readonly Color COLOR_BACKCOLOR2 = Color.FromArgb(7, 59, 150);

        # endregion Private Constants

        # region Private Members

        // �^�C�g��
		private readonly string _title;
		// �ۑ��{�^��
		private bool _saveButton;
		// �䗦����v�Z�{�^��
		private bool _calcFromRatioButton;
        // ���ɖ߂��{�^��
        private bool _undoButton;
        // �N�x�ڕW�{�^��
        private bool _yearTargetButton;

		// ��ƃR�[�h
		private string _enterpriseCode;
		// ���_�R�[�h
		private string _sectionCode;
		// ���_��
		private string _sectionName;
        // ����
        private int _companyBiginMonth;

		//�R���g���[���̔z��
		private Infragistics.Win.Misc.UltraLabel[] _ratioMonth_uLabel;
		private Broadleaf.Library.Windows.Forms.TNedit[] _ratioMonth_tNedit;

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.23 TOKUNAGA ADD START
        // ���_�A�N�Z�X�N���X
        private SecInfoSetAcs _secInfoSetAcs = null;
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.23 TOKUNAGA ADD END

        // �ڕW�}�X�^�A�N�Z�X�N���X
        private SalesTargetAcs _salesTargetAcs;
        // �ڕW�f�[�^���X�g
        private List<SalesTarget> _salesTargetList;
        // ��������
        private ExtrInfo_MAMOK09197EA _extrInfo;

        // �x�Ɠ��ݒ�}�X�^
        private Dictionary<SectionAndDate, HolidaySetting> _holidaySettingDic;

        // ���n�v�Z�䗦���X�g
        private List<LdgCalcRatioMng> _ldgCalcRatioMngList;

        // �O���b�h�ݒ萧��N���X
        private GridStateController _gridStateController;

        /// <summary>��ʃf�U�C���ύX�N���X</summary>
        private ControlScreenSkin _controlScreenSkin = new ControlScreenSkin();

        // ���ԁi�J�n�j
		private DateTime _targetDateSt;
        // ���ԁi�I���j
        private DateTime _targetDateEd;
        // �ҏW�s
		private int _editRowIndex;
		// �ҏW��
        private int _editColumnIndex;

        // �����t���O
        private bool _searchFlag;

        private bool _closing;

        private bool _cancelFlag;

        # endregion Private Members

        # region Constructor

        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        public MAMOK01110UA()
		{
			this._saveButton = true;
			this._calcFromRatioButton = true;
            this._undoButton = true;
            this._yearTargetButton = true;

			InitializeComponent();

            this._title = ctPGNM;

			// ��ƃR�[�h���擾
			this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

			// ���_���擾
			SecInfoSet secInfoSet;
			SecInfoAcs secInfoAcs = new SecInfoAcs();
			secInfoAcs.GetSecInfo(SecInfoAcs.CompanyNameCd.CompanyNameCd1, out secInfoSet);
			this._sectionCode = secInfoSet.SectionCode.TrimEnd();
			this._sectionName = secInfoSet.SectionGuideNm.TrimEnd();

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.23 TOKUNAGA ADD START
            this._secInfoSetAcs = new SecInfoSetAcs();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.23 TOKUNAGA ADD END

            this._gridStateController = new GridStateController();

            this._salesTargetAcs = new SalesTargetAcs();
            this._salesTargetList = new List<SalesTarget>();

			// �A�C�R���摜�̐ݒ�
			// �����{�^��
			this.Search_Button.Appearance.Image
				= IconResourceManagement.ImageList16.Images[(int)Size16_Index.SEARCH];
            // �N���A�{�^��
            this.Clear_Button.Appearance.Image
                = IconResourceManagement.ImageList16.Images[(int)Size16_Index.RETRY];
        }

        # endregion Constructor

        # region ISalesMonTargetMDIChild �����o

        /// <summary>
		/// �^�C�g��
		/// </summary>
		public string Title
		{
			get
			{
				return (_title);
			}
		}
		/// <summary>
		/// �ۑ��{�^��
		/// </summary>
		public bool SaveButton
		{
			get
			{
				return (_saveButton);
			}
		}
		/// <summary>
		/// �䗦����v�Z�{�^��
		/// </summary>
		public bool CalcFromRatioButton
		{
			get
			{
				return (_calcFromRatioButton);
			}
		}
        /// <summary>
        /// ���ɖ߂��{�^��
        /// </summary>
        public bool UndoButton
        {
            get
            {
                return (_undoButton);
            }
        }
        /// <summary>
        /// �N�x�ڕW�{�^��
        /// </summary>
        public bool YearTargetButton
        {
            get
            {
                return (_yearTargetButton);
            }
        }

		/// <summary>
		/// �I�����_�擾�C�x���g
		/// </summary>
		/// <remarks>
		/// <br>Note		: �t���[���ɂđI������Ă��鋒�_�R�[�h���擾���܂��B</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.03.29</br>
		/// </remarks>
        //public event GetSalesMonTargetSelectSectionCodeEventHandler GetSelectSectionCodeEvent;

		/// <summary>
		/// �c�[���o�[�{�^������C�x���g
		/// </summary>
		/// <remarks>
		/// <br>Note		: �t���[���̃{�^���L������������������ꍇ�ɔ��������܂��B
		///					  (IPaymentInputMDIChild�C���^�[�t�F�[�X�̎���)</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.03.29</br>
		/// </remarks>
		public event ParentToolbarSalesMonTargetSettingEventHandler ParentToolbarSettingEvent;

		/// <summary>
		/// ���_�ύX�㏈��
		/// </summary>
		/// <remarks>
		/// <br>Note		: �t���[���̋��_��ύX��ɏ�������܂��B</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.03.29</br>
		/// </remarks>
		public void AfterSectionChange()
		{

		}

		/// <summary>
		/// �I���O����
		/// </summary>
		/// <param name="parameter">�p�����[�^</param>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note		: ��ʂ����O�ɏ�������܂��B</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.03.29</br>
		/// </remarks>
		public int BeforeClose(object parameter)
		{
			bool status = CloseSalesTarget();
			if (!status)
			{
				return (1);
			}

            // ��ʏ�Ԃ�ۑ�
            SaveStateXmlData();

            this._closing = true;

			return (0);
		}

		/// <summary>
		/// ���_�ύX�O����
		/// </summary>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note		: �t���[���ɂċ��_���ύX�����O�ɏ�������܂��B</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.03.29</br>
		/// </remarks>
		public int BeforeSectionChange()
		{
			return (0);
		}

		/// <summary>
		/// �^�u�֑ؑO����
		/// </summary>
		/// <param name="parameter">�p�����[�^</param>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note		: �t���[���ɂă^�u���؂�ւ�����O�ɏ�������܂��B</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.03.29</br>
		/// </remarks>
		public int BeforeTabChange(object parameter)
		{
			return (0);
		}

        /// <summary>
        /// �t�H�[������������
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note		: �t���[���ɂăt�H�[�������������O�ɏ�������܂��B</br>
        /// <br>Programmer	: NEPCO</br>
        /// <br>Date		: 2007.06.11</br>
        /// </remarks>
        public int InitializeForm()
        {
            int status = LoadMasterTable();
            if (status != 0)
            {
                // �c�[���o�[������
                this._saveButton = false;
                this._calcFromRatioButton = false;
                this._undoButton = false;
                this._yearTargetButton = false;
                if (ParentToolbarSettingEvent != null) this.ParentToolbarSettingEvent(this);
            }

            return (status);

        }

		/// <summary>
		/// ���[�h���X�\�������i�p�����[�^�L��j
		/// </summary>
		/// <param name="parameter">�p�����[�^</param>
		/// <remarks>
		/// <br>Note		: �ʏ�N�����Ƀt���[������Ăяo����܂��B</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.03.29</br>
		/// </remarks>
		public void Show(object parameter)
		{
			this.Show();
		}

		/// <summary>
		/// �ۑ�����
		/// </summary>
		/// <remarks>
		/// <br>Note		: �ۑ��{�^�����N���b�N���ꂽ���ɔ������܂��B</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.03.29</br>
		/// </remarks>
		public void SaveSalesMonTargetProc()
		{
            bool retResult;

            if (this._editRowIndex >= ROW_SALESTARGETMONEY &&
                this._editColumnIndex > 0)
            {
                retResult = CheckEditCharacter();
                if (!retResult)
                {
                    return;
                }
            }

            retResult = BeforeSaveSalesTarget();
            if (!retResult)
            {
                return;
            }

            List<SalesTarget> salesTargetList;
            List<SalesTarget> deleteSalesTargetList;

            // �C����̋ΑӃf�[�^���o�b�t�@�Ɏ擾
            ScreenToSalesTarget(out salesTargetList, out deleteSalesTargetList);

            // �ڕW�f�[�^�ۑ�
            retResult = SaveSalesTarget(ref salesTargetList);
            if (!retResult)
            {
                return;
            }

            // �ڕW�f�[�^�폜
            retResult = DeleteSalesTarget(deleteSalesTargetList);
            if (!retResult)
            {
                return;
            }

            this._salesTargetList = salesTargetList;

            // �O���b�h�\��
            DispScreen(this._salesTargetList);
            // �O���b�h���C�A�E�g�ݒ�
            SetLayout_SalesTarget_uGrid();

		}

		/// <summary>
		/// �䗦����v�Z����
		/// </summary>
		/// <remarks>
		/// <br>Note		: �䗦����v�Z�{�^�����N���b�N���ꂽ���ɔ������܂��B</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.03.29</br>
		/// </remarks>
		public void CalcFromRatioSalesMonTargetProc()
		{
            if (this._searchFlag == false)
            {
                return;
            }

            bool retResult;

            if (this._editRowIndex >= ROW_SALESTARGETMONEY &&
                this._editColumnIndex > 0)
            {
                retResult = CheckEditCharacter();
                if (!retResult)
                {
                    return;
                }
            }

			// �v�Z�����`�F�b�N����
            retResult = CheckCalcCondition();
            if (!retResult)
			{
				return;
			}

            // �䗦�v�Z�O����
            BeforeCalcFromRatio();
        }

        /// <summary>
        /// ���ɖ߂�����
        /// </summary>
        /// <remarks>
        /// <br>Note		: ���ɖ߂��{�^�����N���b�N���ꂽ���ɔ������܂��B</br>
        /// <br>Programmer	: NEPCO</br>
        /// <br>Date		: 2007.03.29</br>
        /// </remarks>
        public void UndoSalesMonTargetProc()
        {
            bool retResult;

            if (this._editRowIndex >= ROW_SALESTARGETMONEY &&
                this._editColumnIndex > 0)
            {
                retResult = CheckEditCharacter();
                if (!retResult)
                {
                    return;
                }
            }

            // ��ʏ�񏉊���
            UndoScreenInfo();
        }

        /// <summary>
        /// �N�x�ڕW�K�C�h����
        /// </summary>
        /// <remarks>
        /// <br>Note		: �N�x�ڕW�{�^�����N���b�N���ꂽ���ɔ������܂��B</br>
        /// <br>Programmer	: NEPCO</br>
        /// <br>Date		: 2007.03.29</br>
        /// </remarks>
        public void YearTargetSalesMonTargetProc()
        {
            bool retResult;

            if (this._editRowIndex >= ROW_SALESTARGETMONEY &&
                this._editColumnIndex > 0)
            {
                retResult = CheckEditCharacter();
                if (!retResult)
                {
                    return;
                }
            }

            // �N�x�ڕW�K�C�h�\��
            ShowYearSalesTarget();
        }

        # endregion ISalesMonTargetMDIChild �����o

        # region Private Methods

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �}�X�^�Ǎ�����
        /// </summary>
        /// <remarks>
        /// <br>Note		: �e�}�X�^��ǂݍ��݂܂��B</br>
        /// <br>Programmer	: NEPCO</br>
        /// <br>Date		: 2007.04.25</br>
        /// </remarks>
        private int LoadMasterTable()
        {
            int status;

            // ���Џ��}�X�^
            status = LoadCompanyInfTable();
            if (status != 0)
            {
                return (status);
            }

            // �x�Ɠ��ݒ�}�X�^
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //status = LoadHolidaySettingTable(this._sectionCode);
            //if (status != 0)
            //{
            //    return (status);
            //}

            //// ���n�v�Z�䗦�Ǘ��}�X�^
            //status = LoadLdgCalcRatioMngTable(this._sectionCode);
            //if (status != 0)
            //{
            //    return (status);
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            
            return (0);
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// ���Џ��}�X�^�ǂݍ��ݏ���
        /// </summary>
        /// <remarks>
        /// <br>Note		: ���Џ��}�X�^��ǂݍ��݁A���񌎂��擾���܂��B</br>
        /// <br>Programmer	: NEPCO</br>
        /// <br>Date		: 2007.04.25</br>
        /// </remarks>
        private int LoadCompanyInfTable()
        {
            int status;

            // ���Џ��}�X�^������񌎂��擾
            CompanyInfAcs companyInfAcs = new CompanyInfAcs();
            CompanyInf companyInf;

            status = companyInfAcs.Read(out companyInf, this._enterpriseCode);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                    break;
                default:
                    TMsgDisp.Show(
                        this,										// �e�E�B���h�E�t�H�[��
                        emErrorLevel.ERR_LEVEL_STOP,				// �G���[���x��
                        this.Name,									// �A�Z���u��ID
                        ctPGNM,  �@�@								// �v���O��������
                        "LoadCompanyInfTable",				   // ��������
                        TMsgDisp.OPE_GET,							// �I�y���[�V����
                        "���Џ��}�X�^�̓ǂݍ��݂Ɏ��s���܂���",					// �\�����郁�b�Z�[�W
                        status,										// �X�e�[�^�X�l
                        companyInfAcs,									// �G���[�����������I�u�W�F�N�g
                        MessageBoxButtons.OK,			  			// �\������{�^��
                        MessageBoxDefaultButton.Button1);			// �����\���{�^��
                    return (status);
            }

            // ���񌎐ݒ�
            this._companyBiginMonth = companyInf.CompanyBiginMonth;

            return (0);
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �x�Ɠ��ݒ�}�X�^�ǂݍ��ݏ���
        /// </summary>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <remarks>
        /// <br>Note		: �x�Ɠ��ݒ�}�X�^��ǂݍ��݋x�Ɠ��K�p�敪���擾���܂��B</br>
        /// <br>Programmer	: NEPCO</br>
        /// <br>Date		: 2007.07.11</br>
        /// </remarks>
        private int LoadHolidaySettingTable(string sectionCode)
        {
            int status;
            ArrayList retList;

            _holidaySettingDic = new Dictionary<SectionAndDate, HolidaySetting>();

            // �x�Ɠ��ݒ�}�X�^����f�[�^���擾
            HolidaySettingAcs holidaySettingAcs = new HolidaySettingAcs();
            status = holidaySettingAcs.Search(
                out retList,
                this._enterpriseCode,
                sectionCode,
                DateTime.MinValue,
                DateTime.MaxValue);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                    break;
                default:
                    TMsgDisp.Show(
                        this,										// �e�E�B���h�E�t�H�[��
                        emErrorLevel.ERR_LEVEL_STOP,				// �G���[���x��
                        this.Name,									// �A�Z���u��ID
                        ctPGNM,  �@�@								// �v���O��������
                        "LoadHolidaySettingTable",					// ��������
                        TMsgDisp.OPE_GET,							// �I�y���[�V����
                        "�x�Ɠ��ݒ�}�X�^�̓ǂݍ��݂Ɏ��s���܂���",					// �\�����郁�b�Z�[�W
                        status,										// �X�e�[�^�X�l
                        holidaySettingAcs,							// �G���[�����������I�u�W�F�N�g
                        MessageBoxButtons.OK,			  			// �\������{�^��
                        MessageBoxDefaultButton.Button1);			// �����\���{�^��
                    return (status);
            }

            // ���X�g�쐬
            SectionAndDate sectionAndDate;
            foreach (HolidaySetting holidaySetting in retList)
            {
                sectionAndDate.SectionCode = holidaySetting.SectionCode;
                sectionAndDate.Date = holidaySetting.ApplyDate;
                _holidaySettingDic.Add(sectionAndDate, holidaySetting);
            }

            return (0);

        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// ���n�v�Z�䗦�Ǘ��}�X�^�ǂݍ��ݏ���
        /// </summary>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <remarks>
        /// <br>Note		: ���n�v�Z�䗦�Ǘ��}�X�^��ǂݍ��݊e�j���̔䗦���擾���܂��B</br>
        /// <br>Programmer	: NEPCO</br>
        /// <br>Date		: 2007.07.12</br>
        /// </remarks>
        private int LoadLdgCalcRatioMngTable(string sectionCode)
        {
            LdgCalcRatioMngAcs ldgCalcRatioMngAcs = new LdgCalcRatioMngAcs();
            this._ldgCalcRatioMngList = new List<LdgCalcRatioMng>();

            string[] sectionCodeList = new string[1];
            sectionCodeList[0] = sectionCode;

            // ���n�v�Z�䗦�Ǘ��}�X�^�擾
            int status = ldgCalcRatioMngAcs.Search(out this._ldgCalcRatioMngList, this._enterpriseCode, sectionCodeList);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                    // ����
                    break;
                default:
                    // �G���[
                    return (status);
            }

            return (0);
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �N�x�ڕW�K�C�h�\������
        /// </summary>
        /// <remarks>
        /// <br>Note		: �N�x�ڕW�K�C�h��\�����܂��B</br>
        /// <br>Programmer	: NEPCO</br>
        /// <br>Date		: 2007.04.25</br>
        /// </remarks>
        private void ShowYearSalesTarget()
        {
            DateTime applyStaDate;
            DateTime applyEndDate;

            MAMOK04110UA yearSalesTarget = new MAMOK04110UA();
            DialogResult dialogResult = yearSalesTarget.ShowGuide(this, out applyStaDate, out applyEndDate);

            if (dialogResult == DialogResult.OK)
            {
                // �����O
                if (this._searchFlag == false)
                {
                    this.ApplyStaMonth_tDateEdit.SetDateTime(applyStaDate);
                    this.ApplyEndMonth_tDateEdit.SetDateTime(applyEndDate);

                    // �ڕW�f�[�^��ʕ\������
                    DispScreenSalesTarget();
                    return;
                }

                List<SalesTarget> salesTargetList;
                List<SalesTarget> deleteSalesTargetList;

                // �C����̋ΑӃf�[�^���o�b�t�@�ɕۑ�
                ScreenToSalesTarget(out salesTargetList, out deleteSalesTargetList);

                bool retResult;

                // �C���ڕW�f�[�^��r
                retResult = CompareSalesTarget(salesTargetList);
                if (retResult)
                {
                    this.ApplyStaMonth_tDateEdit.SetDateTime(applyStaDate);
                    this.ApplyEndMonth_tDateEdit.SetDateTime(applyEndDate);

                    // �ڕW�f�[�^��ʕ\������
                    DispScreenSalesTarget();

                    return;
                }

                // �ۑ��m�F
                DialogResult res = TMsgDisp.Show(
                    this, 							        // �e�E�B���h�E�t�H�[��
                    emErrorLevel.ERR_LEVEL_SAVECONFIRM, 	// �G���[���x��
                    this.Name,						        // �A�Z���u��ID
                    "", 						            // �\�����郁�b�Z�[�W
                    0,								        // �X�e�[�^�X�l
                    MessageBoxButtons.YesNoCancel);		    // �\������{�^��
                switch (res)
                {
                    case DialogResult.Yes:
                        // �ۑ��O�`�F�b�N
                        retResult = CheckSaveData();
                        if (!retResult)
                        {
                            return;
                        }

                        // �ڕW�f�[�^�ۑ�
                        retResult = SaveSalesTarget(ref salesTargetList);
                        if (!retResult)
                        {
                            return;
                        }

                        // �ڕW�f�[�^�폜
                        retResult = DeleteSalesTarget(deleteSalesTargetList);
                        if (!retResult)
                        {
                            return;
                        }

                        this._salesTargetList = salesTargetList;

                        break;
                    case DialogResult.No:
                        break;
                    case DialogResult.Cancel:
                        return;
                }

                this.ApplyStaMonth_tDateEdit.SetDateTime(applyStaDate);
                this.ApplyEndMonth_tDateEdit.SetDateTime(applyEndDate);

                // �ڕW�f�[�^��ʕ\������
                DispScreenSalesTarget();
            }

        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �w�l�k�f�[�^�̕ۑ�����
        /// </summary>
        /// <remarks>
        /// <br>Note		: ��ʏ�ԕێ��p�̂w�l�k�̕ۑ��������s���܂��B</br>
        /// <br>Programmer	: NEPCO</br>
        /// <br>Date		: 2007.04.27</br>
        /// </remarks>
        private void SaveStateXmlData()
        {
            if (this.uceAutoFitCol.Checked)
            {
                this.SalesTarget_uGrid.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns;
            }
            else
            {
                this.SalesTarget_uGrid.DisplayLayout.AutoFitStyle = AutoFitStyle.None;
            }
            // �O���b�h����ۑ�
            _gridStateController.SaveGridState(XML_FILE_INITIAL_DATA, ref this.SalesTarget_uGrid);
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �w�l�k�f�[�^�̓Ǎ�����
        /// </summary>
        /// <remarks>
        /// <br>Note		: ��ʏ�ԕێ��p�̂w�l�k�̓Ǎ��������s���܂��B</br>
        /// <br>Programmer	: NEPCO</br>
        /// <br>Date		: 2007.04.27</br>
        /// </remarks>
        private void LoadStateXmlData()
        {
            int status = _gridStateController.LoadGridState(XML_FILE_INITIAL_DATA, ref this.SalesTarget_uGrid);
            if (status == 0)
            {
                GridStateController.GridStateInfo gridStateInfo = _gridStateController.GetGridStateInfo(ref this.SalesTarget_uGrid);
                if (gridStateInfo != null)
                {
                    // �t�H���g�T�C�Y
                    this.cmbFontSize.Value = (int)gridStateInfo.FontSize;
                    // ��̎�������
                    this.uceAutoFitCol.Checked = gridStateInfo.AutoFit;
                }
                else
                {
                    status = 4;
                }
            }
            if (status != 0)
            {
                // �t�H���g�T�C�Y
                this.cmbFontSize.Value = 10;
                // ��̎�������
                this.uceAutoFitCol.Checked = false;
            }
        }

        /*----------------------------------------------------------------------------------*/
		/// <summary>
		/// �R���g���[���z�񉻏���
		/// </summary>
		/// <remarks>
		/// <br>Note		: RatioMonth_uLabel��RatioMonth_tNedit��z�񉻂��܂��B</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.03.29</br>
		/// </remarks>
		private void InitRatioMonthControl()
		{
			this._ratioMonth_uLabel = new Infragistics.Win.Misc.UltraLabel[12];

			this._ratioMonth_uLabel[0] = this.RatioMonth_uLabel1;
			this._ratioMonth_uLabel[1] = this.RatioMonth_uLabel2;
			this._ratioMonth_uLabel[2] = this.RatioMonth_uLabel3;
			this._ratioMonth_uLabel[3] = this.RatioMonth_uLabel4;
			this._ratioMonth_uLabel[4] = this.RatioMonth_uLabel5;
			this._ratioMonth_uLabel[5] = this.RatioMonth_uLabel6;
			this._ratioMonth_uLabel[6] = this.RatioMonth_uLabel7;
			this._ratioMonth_uLabel[7] = this.RatioMonth_uLabel8;
			this._ratioMonth_uLabel[8] = this.RatioMonth_uLabel9;
			this._ratioMonth_uLabel[9] = this.RatioMonth_uLabel10;
			this._ratioMonth_uLabel[10] = this.RatioMonth_uLabel11;
			this._ratioMonth_uLabel[11] = this.RatioMonth_uLabel12;

			this._ratioMonth_tNedit = new TNedit[12];

			this._ratioMonth_tNedit[0] = this.RatioMonth_tNedit;
			this._ratioMonth_tNedit[1] = this.RatioMonth_tNedit2;
			this._ratioMonth_tNedit[2] = this.RatioMonth_tNedit3;
			this._ratioMonth_tNedit[3] = this.RatioMonth_tNedit4;
			this._ratioMonth_tNedit[4] = this.RatioMonth_tNedit5;
			this._ratioMonth_tNedit[5] = this.RatioMonth_tNedit6;
			this._ratioMonth_tNedit[6] = this.RatioMonth_tNedit7;
			this._ratioMonth_tNedit[7] = this.RatioMonth_tNedit8;
			this._ratioMonth_tNedit[8] = this.RatioMonth_tNedit9;
			this._ratioMonth_tNedit[9] = this.RatioMonth_tNedit10;
			this._ratioMonth_tNedit[10] = this.RatioMonth_tNedit11;
			this._ratioMonth_tNedit[11] = this.RatioMonth_tNedit12;
		}

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// ��ʏ�񏉊�������
        /// </summary>
        /// <remarks>
        /// <br>Note		: ��ʏ������������܂��B</br>
        /// <br>Programmer	: NEPCO</br>
        /// <br>Date		: 2007.04.25</br>
        /// </remarks>
        private void UndoScreenInfo()
        {
            if (this._searchFlag == false)
            {
                return;
            }

            List<SalesTarget> salesTargetList;
            List<SalesTarget> deleteSalesTargetList;

            // �C����̋ΑӃf�[�^���o�b�t�@�ɕۑ�
            ScreenToSalesTarget(out salesTargetList, out deleteSalesTargetList);

            bool retResult;

            // �C���ڕW�f�[�^��r
            retResult = CompareSalesTarget(salesTargetList);
            if (!retResult)
            {
                //
                // �ύX����
                //
                // �ۑ��m�F
                DialogResult dialogResult = TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,
                    this.Name,
                    "���݁A�ҏW���̃f�[�^�����݂��܂�" + "\r\n" + "\r\n" +
                    "������Ԃɖ߂��܂����H",
                    0,
                    MessageBoxButtons.YesNo,
                    MessageBoxDefaultButton.Button1);
                if (dialogResult != DialogResult.Yes)
                {
                    return;
                }
            }

            // �R���g���[��������
            ClearScreen();

        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �C���ڕW�f�[�^��r����
        /// </summary>
        /// <param name="salesTargetList">�ڕW�f�[�^���X�g</param>
        /// <remarks>
        /// Note	   : �C���ڕW�f�[�^���r���܂��B<br />
        /// Programmer : NEPCO<br />
        /// Date	   : 2007.05.08<br />
        /// </remarks>
        private bool CompareSalesTarget(List<SalesTarget> salesTargetList)
        {
            // �ڕW�f�[�^��r
            if (salesTargetList.Count != this._salesTargetList.Count)
            {
                return (false);
            }
            else
            {
                for (int i = 0; i < salesTargetList.Count; i++)
                {
                    if (!salesTargetList[i].Equals(this._salesTargetList[i]))
                    {
                        return (false);
                    }
                }
            }
            return (true);
        }

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// �I���O����
		/// </summary>
		/// <remarks>
		/// <br>Note		: ��ʂ����O�ɁA�ڕW�f�[�^�̃`�F�b�N�ƕۑ����s���܂��B</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.03.29</br>
		/// </remarks>
		private bool CloseSalesTarget()
		{
			if (this._searchFlag == false)
			{
				return (true);
			}

            List<SalesTarget> salesTargetList;
            List<SalesTarget> deleteSalesTargetList;

			// �C����̋ΑӃf�[�^���o�b�t�@�ɕۑ�
			ScreenToSalesTarget(out salesTargetList, out deleteSalesTargetList);

            bool retResult;

            // �C���ڕW�f�[�^��r
            retResult = CompareSalesTarget(salesTargetList);
            if (retResult)
            {
                // �ύX�Ȃ�
                return (true);
            }

            // �ۑ��m�F
            DialogResult res = TMsgDisp.Show(
                this, 							        // �e�E�B���h�E�t�H�[��
                emErrorLevel.ERR_LEVEL_SAVECONFIRM, 	// �G���[���x��
                this.Name,						        // �A�Z���u��ID
                "", 						            // �\�����郁�b�Z�[�W
                0,								        // �X�e�[�^�X�l
                MessageBoxButtons.YesNoCancel);		    // �\������{�^��
            switch (res)
            {
                case DialogResult.Yes:
                    break;
                case DialogResult.No:
                    return (true);
                case DialogResult.Cancel:
                    return (false);
            }

            // ���͒l�����̔��p�������`�F�b�N
            retResult = CheckEditCharacter();
            if (!retResult)
            {
                return (false);
            }

            // �ۑ��O�`�F�b�N
            retResult = CheckSaveData();
            if (!retResult)
            {
                return (false);
            }

            // �ڕW�f�[�^�ۑ�
            retResult = SaveSalesTarget(ref salesTargetList);
            if (!retResult)
            {
                return (false);
            }

            // �ڕW�f�[�^�폜
            retResult = DeleteSalesTarget(deleteSalesTargetList);
            if (!retResult)
            {
                return (false);
            }

            this._salesTargetList = salesTargetList;

			return (true);

		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// �ڕW�f�[�^�ۑ��O����
		/// </summary>
		/// <remarks>
		/// Note	   : �C���ڕW�f�[�^��ۑ��O�ɏ������܂��B<br />
		/// Programmer : NEPCO<br />
		/// Date	   : 2007.04.09<br />
		/// </remarks>
		private bool BeforeSaveSalesTarget()
		{
            // �����`�F�b�N
            bool retResult = CheckSearchFlag();
            if (!retResult)
            {
                return (false);
            }

            // �ۑ��O�`�F�b�N
            retResult = CheckSaveData();
            if (!retResult)
            {
                return (false);
            }

			return (true);

		}

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �ڕW�f�[�^�폜����
        /// </summary>
        /// <param name="deleteSalesTargetList">�폜�p�ڕW�f�[�^���X�g</param>
        /// <remarks>
        /// Note	   : �ڕW�f�[�^���폜���܂��B<br />
        /// Programmer : NEPCO<br />
        /// Date	   : 2007.05.08<br />
        /// </remarks>
        private bool DeleteSalesTarget(List<SalesTarget> deleteSalesTargetList)
        {
            List<SalesTarget> deleteList = new List<SalesTarget>();
            SalesTarget salesTargetComp;
            int targetIndex;

            foreach (SalesTarget salesTarget in deleteSalesTargetList)
            {
                salesTargetComp = new SalesTarget();
                salesTargetComp.ApplyStaDate = salesTarget.ApplyStaDate;
                targetIndex = this._salesTargetList.BinarySearch(salesTargetComp, new SalesTargetCompApplyStaDate());
                if (targetIndex >= 0)
                {
                    deleteList.Add(salesTarget);
                }
            }

            if (deleteList.Count == 0)
            {
                return (true);
            }

            // �ڕW�f�[�^�X�V
            int status = this._salesTargetAcs.Delete(deleteList);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    break;
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    TMsgDisp.Show(
                        this, 						                // �e�E�B���h�E�t�H�[��
                        emErrorLevel.ERR_LEVEL_EXCLAMATION, 	    // �G���[���x��
                        this.Name,								    // �A�Z���u��ID
                        "���ɑ��[�����X�V����Ă��܂�",           // �\�����郁�b�Z�[�W
                        status,									    // �X�e�[�^�X�l
                        MessageBoxButtons.OK);					    // �\������{�^��
                    return (false);
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    TMsgDisp.Show(
                        this, 						                // �e�E�B���h�E�t�H�[��
                        emErrorLevel.ERR_LEVEL_EXCLAMATION, 	    // �G���[���x��
                        this.Name,								    // �A�Z���u��ID
                        "���ɑ��[�����폜����Ă��܂�",		    // �\�����郁�b�Z�[�W
                        status,									    // �X�e�[�^�X�l
                        MessageBoxButtons.OK);					    // �\������{�^��
                    return (false);
                default:
                    TMsgDisp.Show(
                        this, 						                // �e�E�B���h�E�t�H�[��
                        emErrorLevel.ERR_LEVEL_STOP,			    // �G���[���x��
                        this.Name,								    // �A�Z���u��ID
                        ctPGNM, 		  �@�@					    // �v���O��������
                        "DeleteSalesTarget",						            // ��������
                        TMsgDisp.OPE_DELETE,					    // �I�y���[�V����
                        "�ڕW�f�[�^�C�����ɃG���[���������܂���",	// �\�����郁�b�Z�[�W
                        status,									    // �X�e�[�^�X�l
                        this._salesTargetAcs,					    // �G���[�����������I�u�W�F�N�g
                        MessageBoxButtons.OK,			  		    // �\������{�^��
                        MessageBoxDefaultButton.Button1);		    // �����\���{�^��
                    return (false);
            }

            return (true);
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �ڕW�f�[�^�ۑ�����
        /// </summary>
        /// <param name="salesTargetList">�ڕW�f�[�^���X�g</param>
        /// <remarks>
        /// Note	   : �ڕW�f�[�^��ۑ����܂��B<br />
        /// Programmer : NEPCO<br />
        /// Date	   : 2007.05.08<br />
        /// </remarks>
        private bool SaveSalesTarget(ref List<SalesTarget> salesTargetList)
        {
            // �ڕW�f�[�^�X�V
            int status = this._salesTargetAcs.Write(ref salesTargetList);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    break;
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    TMsgDisp.Show(
                        this, 						                // �e�E�B���h�E�t�H�[��
                        emErrorLevel.ERR_LEVEL_EXCLAMATION, 	    // �G���[���x��
                        this.Name,								    // �A�Z���u��ID
                        "���ɑ��[�����X�V����Ă��܂�",           // �\�����郁�b�Z�[�W
                        status,									    // �X�e�[�^�X�l
                        MessageBoxButtons.OK);					    // �\������{�^��
                    return (false);
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    TMsgDisp.Show(
                        this, 						                // �e�E�B���h�E�t�H�[��
                        emErrorLevel.ERR_LEVEL_EXCLAMATION, 	    // �G���[���x��
                        this.Name,								    // �A�Z���u��ID
                        "���ɑ��[�����폜����Ă��܂�",		    // �\�����郁�b�Z�[�W
                        status,									    // �X�e�[�^�X�l
                        MessageBoxButtons.OK);					    // �\������{�^��
                    return (false);
                default:
                    TMsgDisp.Show(
                        this, 						                // �e�E�B���h�E�t�H�[��
                        emErrorLevel.ERR_LEVEL_STOP,			    // �G���[���x��
                        this.Name,								    // �A�Z���u��ID
                        ctPGNM, 		  �@�@					    // �v���O��������
                        "SaveSalesTarget",						            // ��������
                        TMsgDisp.OPE_UPDATE,					    // �I�y���[�V����
                        "�ڕW�f�[�^�C�����ɃG���[���������܂���",	// �\�����郁�b�Z�[�W
                        status,									    // �X�e�[�^�X�l
                        this._salesTargetAcs,					    // �G���[�����������I�u�W�F�N�g
                        MessageBoxButtons.OK,			  		    // �\������{�^��
                        MessageBoxDefaultButton.Button1);		    // �����\���{�^��
                    return (false);
            }

            SaveCompletionDialog dialog = new SaveCompletionDialog();
            dialog.ShowDialog(2);

            return (true);
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �ۑ��O�`�F�b�N����
        /// </summary>
        /// <remarks>
        /// Note	   : �ڕW�f�[�^�̕ۑ��O�`�F�b�N�����܂��B<br />
        /// Programmer : NEPCO<br />
        /// Date	   : 2007.05.08<br />
        /// </remarks>
        private bool CheckSaveData()
        {
            // ���̓`�F�b�N
            bool retResult = CheckInputData();
            if (!retResult)
            {
                return (false);
            }

            // ���͍��Z�l�`�F�b�N
            retResult = CheckSalesTarget();
            if (!retResult)
            {
                return (false);
            }

            return (true);
        }

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// �C���ڕW�f�[�^�o�b�t�@�ۑ�����
		/// </summary>
        /// <param name="newSalesTargetList">�ۑ��p�ڕW�f�[�^���X�g</param>
        /// <param name="deleteSalesTargetList">�폜�p�ڕW�f�[�^���X�g</param>
		/// <remarks>
		/// Note	   : �C���Ώۂ̖ڕW�f�[�^���o�b�t�@�ɕۑ����܂��B<br />
		/// Programmer : NEPCO<br />
		/// Date	   : 2007.04.09<br />
		/// </remarks>
		private void ScreenToSalesTarget(out List<SalesTarget> newSalesTargetList, out List<SalesTarget> deleteSalesTargetList)
		{
			newSalesTargetList = new List<SalesTarget>();
            deleteSalesTargetList = new List<SalesTarget>();

			SalesTarget salesTargetNew;
			SalesTarget salesTargetComp;

            string columnName;
			string targetText;
			string retText;
			int targetIndex;
            long longWork;
            double doubleWork;

			for (DateTime targetDate = this._targetDateSt; targetDate <= this._targetDateEd; targetDate = targetDate.AddMonths(1))
			{
                columnName = targetDate.Year.ToString() + targetDate.Month.ToString("00");

				salesTargetComp = new SalesTarget();
				salesTargetComp.ApplyStaDate = targetDate;
                // �ۑ��f�[�^������
				targetIndex = this._salesTargetList.BinarySearch(salesTargetComp, new SalesTargetCompApplyStaDate());

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                //if (this.SalesTarget_uGrid.Rows[ROW_SALESTARGETMONEY].Cells[columnName].Text == "" &&
                //    this.SalesTarget_uGrid.Rows[ROW_SALESTARGETPROFIT].Cells[columnName].Text == "" &&
                //    this.SalesTarget_uGrid.Rows[ROW_SALESTARGETCOUNT].Cells[columnName].Text == "")
                if ( this.SalesTarget_uGrid.Rows[ROW_SALESTARGETMONEY].Cells[columnName].Text == "" &&
                     this.SalesTarget_uGrid.Rows[ROW_SALESTARGETPROFIT].Cells[columnName].Text == "")
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
                {
                    //
                    // �f�[�^���ݒ�̏ꍇ
                    //
                    if (targetIndex >= 0)
                    {
                        // �폜���X�g�ɒǉ�
                        deleteSalesTargetList.Add(this._salesTargetList[targetIndex].Clone());
                    }
                    continue;
                }
                else
                {
                    //
                    // �f�[�^���ݒ肳��Ă���ꍇ
                    //
                    if (targetIndex < 0)
                    {
                        // �V�K
                        salesTargetNew = CreateSalesTarget(targetDate);
                    }
                    else
                    {
                        // ����
                        salesTargetNew = this._salesTargetList[targetIndex].Clone();

                    }

                    // ����ڕW
                    if (this.SalesTarget_uGrid.Rows[ROW_SALESTARGETMONEY].Cells[columnName].Text != "")
                    {
                        targetText = this.SalesTarget_uGrid.Rows[ROW_SALESTARGETMONEY].Cells[columnName].Text;
                        RemoveComma(targetText, out retText);

                        long.TryParse(retText, out longWork);
                        salesTargetNew.SalesTargetMoney = longWork;
                    }
                    else
                    {
                        salesTargetNew.SalesTargetMoney = 0;
                    }

                    // �e���ڕW
                    if (this.SalesTarget_uGrid.Rows[ROW_SALESTARGETPROFIT].Cells[columnName].Text != "")
                    {
                        targetText = this.SalesTarget_uGrid.Rows[ROW_SALESTARGETPROFIT].Cells[columnName].Text;
                        RemoveComma(targetText, out retText);
                        //salesTargetNew.SalesTargetProfit = long.Parse(retText);

                        long.TryParse(retText, out longWork);
                        salesTargetNew.SalesTargetProfit = longWork;
                    }
                    else
                    {
                        salesTargetNew.SalesTargetProfit = 0;
                    }

                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                    //// ���ʖڕW
                    //if (this.SalesTarget_uGrid.Rows[ROW_SALESTARGETCOUNT].Cells[columnName].Text != "")
                    //{
                    //    targetText = this.SalesTarget_uGrid.Rows[ROW_SALESTARGETCOUNT].Cells[columnName].Text;
                    //    RemoveComma(targetText, out retText);
                    //    //salesTargetNew.SalesTargetCount = double.Parse(retText);

                    //    double.TryParse(retText, out doubleWork);
                    //    salesTargetNew.SalesTargetCount = doubleWork;
                    //}
                    //else
                    //{
                    //    salesTargetNew.SalesTargetCount = 0;
                    //}
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
                }

				newSalesTargetList.Add(salesTargetNew);
			}
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// �ڕW�f�[�^�V�K�쐬����
		/// </summary>
        /// <param name="targetDate">�K�p�N��</param>
		/// <remarks>
		/// Note	   : �ڕW�f�[�^��V�K�쐬���܂��B<br />
		/// Programmer : NEPCO<br />
		/// Date	   : 2007.04.09<br />
		/// </remarks>
		private SalesTarget CreateSalesTarget(DateTime targetDate)
		{
			SalesTarget salesTarget = new SalesTarget();

            // ��ƃR�[�h
            salesTarget.EnterpriseCode = this._enterpriseCode;
			// ���_�R�[�h
            salesTarget.SectionCode = this._sectionCode;
			// �ڕW�ݒ�敪
			salesTarget.TargetSetCd = 10;
			// �ڕW�Δ�敪
            salesTarget.TargetContrastCd = (int)SalesTarget.ConstrastCd.Section;
			// �ڕW�敪�R�[�h
			salesTarget.TargetDivideCode = targetDate.Year.ToString("0000") + targetDate.Month.ToString("00");
			// �ڕW�敪����
			salesTarget.TargetDivideName = "";
			// ���ԁi�J�n�j
			salesTarget.ApplyStaDate = targetDate.Date;
			// ���ԁi�I���j
			int days = DateTime.DaysInMonth(targetDate.Year, targetDate.Month);
            salesTarget.ApplyEndDate = new DateTime(targetDate.Year, targetDate.Month, days);
            // �]�ƈ��R�[�h
            salesTarget.EmployeeCode = EMPLOYEECODE_SECTION;

            return (salesTarget);
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// ���͍��Z�l�v�Z����
		/// </summary>
        /// <param name="inputSalesTarget">���̓e�L�X�g</param>
        /// <param name="rowIndex">�s�C���f�b�N�X</param>
		/// <remarks>
		/// <br>Note		: �O���b�h������͍��Z�l�����߂܂��B</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.03.29</br>
		/// </remarks>
		private void CalcInputSalesTarget(out double inputSalesTarget, int rowIndex)
		{
			inputSalesTarget = 0;
            string columnName;

			// �ҏW�����s�̓��͍��Z�l�����߂܂�
			for (DateTime targetDate = this._targetDateSt; targetDate <= this._targetDateEd; targetDate = targetDate.AddMonths(1))
			{
                columnName = targetDate.Year.ToString() + targetDate.Month.ToString("00");

                if (this.SalesTarget_uGrid.Rows[rowIndex].Cells[columnName].Text != "")
				{
                    inputSalesTarget += double.Parse(this.SalesTarget_uGrid.Rows[rowIndex].Cells[columnName].Text);
				}
			}
		}

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �䗦�v�Z�O����
        /// </summary>
        /// <remarks>
        /// <br>Note		: �䗦����ڕW���v�Z���܂��B</br>
        /// <br>Programmer	: NEPCO</br>
        /// <br>Date		: 2007.03.29</br>
        /// </remarks>
        private void BeforeCalcFromRatio()
        {
            // �䗦�v�Z�i���ʁj
            CalcFromRatioSalesMon();

            string targetText;
            int columnIndex = 1;
            for (DateTime targetDate = this._targetDateSt; targetDate <= this._targetDateEd; targetDate = targetDate.AddMonths(1))
            {
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                //// �䗦�v�Z�i���ʁj
                //CalcFromRatioSalesDay(targetDate);
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                //for (int rowIndex = ROW_SALESTARGETMONEY; rowIndex <= ROW_SALESTARGETCOUNT; rowIndex++)
                for ( int rowIndex = ROW_SALESTARGETMONEY; rowIndex <= ROW_SALESTARGETPROFIT; rowIndex++ )
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
                {
                    targetText = this.SalesTarget_uGrid.Rows[rowIndex].Cells[columnIndex].Text;
                    // �e�L�X�g�F�ύX
                    SetEditTextColor(targetText, rowIndex, columnIndex);
                }
                columnIndex++;
            }
        }

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// �䗦�v�Z���ʕ\�������i���ʁj
		/// </summary>
		/// <remarks>
		/// <br>Note		: �䗦����ڕW�i���ʁj���v�Z���\�����܂��B</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.03.29</br>
		/// </remarks>
		private void CalcFromRatioSalesMon()
		{
			double ratio = 0;
			int index = 0;

			// �䗦���v
			for (DateTime targetDate = this._targetDateSt; targetDate <= this._targetDateEd; targetDate = targetDate.AddMonths(1))
			{
                if (this._ratioMonth_tNedit[index].DataText == "")
                {
                    ratio += 0;
                }
                else
                {
                    ratio += double.Parse(this._ratioMonth_tNedit[index].DataText);
                }
				index++;
			}

			// ���ԖڕW
			double salesTargetMoney = 0;
			double salesTargetProfit = 0;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //double salesTargetCount = 0;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

			double targetMoney = 0;
			double targetProfit = 0;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //double targetCount = 0;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            long salesMoney = 0;
            long salesProfit = 0;

			// ���͍��Z�l
			double inputSalesTarget = 0;
			double inputSalesTargetProfit = 0;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //double inputSalesTargetCount = 0;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

			// �ڕW��䗦����v�Z���A�O���b�h�ɕ\��
            if (this.SalesTargetMoney_tNedit.DataText != "")
            {
                salesTargetMoney = double.Parse(this.SalesTargetMoney_tNedit.DataText);
            }
            if (this.SalesTargetProfit_tNedit.DataText != "")
            {
                salesTargetProfit = double.Parse(this.SalesTargetProfit_tNedit.DataText);
            }
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //if (this.SalesTargetCount_tNedit.DataText != "")
            //{
            //    salesTargetCount = double.Parse(this.SalesTargetCount_tNedit.DataText);
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            // �J�����̃L�[���
            string columnName = "";
			index = 0;
            int columnIndex = 1;
			for (DateTime targetDate = this._targetDateSt; targetDate <= this._targetDateEd; targetDate = targetDate.AddMonths(1))
			{
                columnName = targetDate.Year.ToString() + targetDate.Month.ToString("00");

                // ����ڕW�i�~�j
                if (this.SalesTargetMoney_tNedit.DataText != "")
                {
                    if (this._ratioMonth_tNedit[index].DataText == "")
                    {
                        targetMoney = 0;
                    }
                    else
                    {
                        targetMoney = salesTargetMoney * double.Parse(this._ratioMonth_tNedit[index].DataText) / ratio;
                    }
                    salesMoney = (long)Math.Round(targetMoney, MidpointRounding.AwayFromZero);
                    inputSalesTarget += salesMoney;

                    if ((int)salesMoney == 0)
                    {
                        this.SalesTarget_uGrid.Rows[ROW_SALESTARGETMONEY].Cells[columnName].Value = null;
                    }
                    else
                    {
                        this.SalesTarget_uGrid.Rows[ROW_SALESTARGETMONEY].Cells[columnName].Value = salesMoney.ToString(FORMAT_NUM);
                    }
                }
                else
                {
                    this.SalesTarget_uGrid.Rows[ROW_SALESTARGETMONEY].Cells[columnName].Value = null;
                }
                // �e���ڕW�i�~�j
                if (this.SalesTargetProfit_tNedit.DataText != "")
                {
                    if (this._ratioMonth_tNedit[index].DataText == "")
                    {
                        targetProfit = 0;
                    }
                    else
                    {
                        targetProfit = salesTargetProfit * double.Parse(this._ratioMonth_tNedit[index].DataText) / ratio;
                    }
                    salesProfit = (long)Math.Round(targetProfit, MidpointRounding.AwayFromZero);
                    inputSalesTargetProfit += salesProfit;

                    if ((int)salesProfit == 0)
                    {
                        this.SalesTarget_uGrid.Rows[ROW_SALESTARGETPROFIT].Cells[columnName].Value = null;
                    }
                    else
                    {
                        this.SalesTarget_uGrid.Rows[ROW_SALESTARGETPROFIT].Cells[columnName].Value = salesProfit.ToString(FORMAT_NUM);
                    }
                }
                else
                {
                    this.SalesTarget_uGrid.Rows[ROW_SALESTARGETPROFIT].Cells[columnName].Value = null;
                }
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                //// ���ʖڕW�i�j
                //if (this.SalesTargetCount_tNedit.DataText != "")
                //{
                //    if (this._ratioMonth_tNedit[index].DataText == "")
                //    {
                //        targetCount = 0;
                //    }
                //    else
                //    {
                //        targetCount = salesTargetCount * double.Parse(this._ratioMonth_tNedit[index].DataText) / ratio;
                //    }
                //    targetCount = Math.Round(targetCount, MidpointRounding.AwayFromZero);
                //    inputSalesTargetCount += targetCount;

                //    if ((int)targetCount == 0)
                //    {
                //        this.SalesTarget_uGrid.Rows[ROW_SALESTARGETCOUNT].Cells[columnName].Value = null;
                //    }
                //    else
                //    {
                //        //this.SalesTarget_uGrid.Rows[ROW_SALESTARGETCOUNT].Cells[columnName].Value = targetCount.ToString(FORMAT_NUM);
                //        this.SalesTarget_uGrid.Rows[ROW_SALESTARGETCOUNT].Cells[columnName].Value = targetCount.ToString(FORMAT_NUM_DECIMAL);
                //    }
                //}
                //else
                //{
                //    this.SalesTarget_uGrid.Rows[ROW_SALESTARGETCOUNT].Cells[columnName].Value = null;
                //}
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
				index++;
                columnIndex++;
			}

            //
			// ���ԖڕW�Ɠ��͍��Z�l�̐��������Ƃ�܂�
			//
            if (this.SalesTargetMoney_tNedit.DataText != "")
            {
                // ����ڕW�i�~�j
                salesMoney += (long)(salesTargetMoney - inputSalesTarget);
                this.SalesTarget_uGrid.Rows[ROW_SALESTARGETMONEY].Cells[columnName].Value = salesMoney.ToString(FORMAT_NUM);
            }
            if (this.SalesTargetProfit_tNedit.DataText != "")
            {
                // �e���ڕW�i�~�j
                salesProfit += (long)(salesTargetProfit - inputSalesTargetProfit);
                this.SalesTarget_uGrid.Rows[ROW_SALESTARGETPROFIT].Cells[columnName].Value = salesProfit.ToString(FORMAT_NUM);
            }
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //if (this.SalesTargetCount_tNedit.DataText != "")
            //{
            //    // ���ʖڕW�i�j
            //    targetCount += (salesTargetCount - inputSalesTargetCount);
            //    //this.SalesTarget_uGrid.Rows[ROW_SALESTARGETCOUNT].Cells[columnName].Value = targetCount.ToString(FORMAT_NUM);
            //    this.SalesTarget_uGrid.Rows[ROW_SALESTARGETCOUNT].Cells[columnName].Value = targetCount.ToString(FORMAT_NUM_DECIMAL);
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

			this.InputSalesTargetMoney_tNedit.DataText = this.SalesTargetMoney_tNedit.DataText;
			this.InputSalesTargetProfit_tNedit.DataText = this.SalesTargetProfit_tNedit.DataText;
			// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //this.InputSalesTargetCount_tNedit.DataText = this.SalesTargetCount_tNedit.DataText;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
		}

        /*----------------------------------------------------------------------------------*/
        ///// <summary>
        ///// �䗦�v�Z���ʕ\�������i���ʁj
        ///// </summary>
        ///// <param name="targetDate">�K�p�N��</param>
        ///// <param name="weekdayRatio">�����䗦</param>
        ///// <param name="satSunRatio">�y���䗦</param>
        ///// <remarks>
        ///// <br>Note		: �䗦����ڕW�i���ʁj���v�Z���\�����܂��B</br>
        ///// <br>Programmer	: NEPCO</br>
        ///// <br>Date		: 2007.03.29</br>
        ///// </remarks>
        //private void CalcFromRatioSalesDay(DateTime targetDate)
        //{
        //    double[] salesTargetDayOfWeek;
        //    double salesTarget = 0;

        //    string columnName = targetDate.Year.ToString() + targetDate.Month.ToString("00");

        //    // �����擾
        //    int iDaysInMonth = DateTime.DaysInMonth(targetDate.Year, targetDate.Month);
        //    // �����擾
        //    DateTime endDate = new DateTime(targetDate.Year, targetDate.Month, iDaysInMonth);

        //    // ����i�~�j
        //    if (this.SalesTarget_uGrid.Rows[ROW_SALESTARGETMONEY].Cells[columnName].Text != "")
        //    {
        //        salesTarget = double.Parse(this.SalesTarget_uGrid.Rows[ROW_SALESTARGETMONEY].Cells[columnName].Text);
        //        // �䗦�v�Z
        //        SalesLandingAcs.CalcDaySalesTargetFromRatio(
        //            out salesTargetDayOfWeek,
        //            salesTarget,
        //            0,
        //            targetDate,
        //            endDate,
        //            this._sectionCode,
        //            this._ldgCalcRatioMngList,
        //            this._holidaySettingDic);

        //        // ���j����
        //        this.SalesTarget_uGrid.Rows[ROW_SALESTARGET_MONEY_SUNDAY].Cells[columnName].Value = salesTargetDayOfWeek[0].ToString(FORMAT_NUM_ZERO);
        //        // ���j����
        //        this.SalesTarget_uGrid.Rows[ROW_SALESTARGET_MONEY_MONDAY].Cells[columnName].Value = salesTargetDayOfWeek[1].ToString(FORMAT_NUM_ZERO);
        //        // �Ηj����
        //        this.SalesTarget_uGrid.Rows[ROW_SALESTARGET_MONEY_TUESDAY].Cells[columnName].Value = salesTargetDayOfWeek[2].ToString(FORMAT_NUM_ZERO);
        //        // ���j����
        //        this.SalesTarget_uGrid.Rows[ROW_SALESTARGET_MONEY_WEDNESDAY].Cells[columnName].Value = salesTargetDayOfWeek[3].ToString(FORMAT_NUM_ZERO);
        //        // �ؗj����
        //        this.SalesTarget_uGrid.Rows[ROW_SALESTARGET_MONEY_THURSDAY].Cells[columnName].Value = salesTargetDayOfWeek[4].ToString(FORMAT_NUM_ZERO);
        //        // ���j����
        //        this.SalesTarget_uGrid.Rows[ROW_SALESTARGET_MONEY_FRIDAY].Cells[columnName].Value = salesTargetDayOfWeek[5].ToString(FORMAT_NUM_ZERO);
        //        // �y�j����
        //        this.SalesTarget_uGrid.Rows[ROW_SALESTARGET_MONEY_SATURDAY].Cells[columnName].Value = salesTargetDayOfWeek[6].ToString(FORMAT_NUM_ZERO);
        //        // �j�Փ�����
        //        this.SalesTarget_uGrid.Rows[ROW_SALESTARGET_MONEY_HOLIDAY].Cells[columnName].Value = salesTargetDayOfWeek[7].ToString(FORMAT_NUM_ZERO);
        //    }
        //    else
        //    {
        //        // ���j����
        //        this.SalesTarget_uGrid.Rows[ROW_SALESTARGET_MONEY_SUNDAY].Cells[columnName].Value = null;
        //        // ���j����
        //        this.SalesTarget_uGrid.Rows[ROW_SALESTARGET_MONEY_MONDAY].Cells[columnName].Value = null;
        //        // �Ηj����
        //        this.SalesTarget_uGrid.Rows[ROW_SALESTARGET_MONEY_TUESDAY].Cells[columnName].Value = null;
        //        // ���j����
        //        this.SalesTarget_uGrid.Rows[ROW_SALESTARGET_MONEY_WEDNESDAY].Cells[columnName].Value = null;
        //        // �ؗj����
        //        this.SalesTarget_uGrid.Rows[ROW_SALESTARGET_MONEY_THURSDAY].Cells[columnName].Value = null;
        //        // ���j����
        //        this.SalesTarget_uGrid.Rows[ROW_SALESTARGET_MONEY_FRIDAY].Cells[columnName].Value = null;
        //        // �y�j����
        //        this.SalesTarget_uGrid.Rows[ROW_SALESTARGET_MONEY_SATURDAY].Cells[columnName].Value = null;
        //        // �j�Փ�����
        //        this.SalesTarget_uGrid.Rows[ROW_SALESTARGET_MONEY_HOLIDAY].Cells[columnName].Value = null;
        //    }
        //    // �e���i�~�j
        //    if (this.SalesTarget_uGrid.Rows[ROW_SALESTARGETPROFIT].Cells[columnName].Text != "")
        //    {
        //        salesTarget = double.Parse(this.SalesTarget_uGrid.Rows[ROW_SALESTARGETPROFIT].Cells[columnName].Text);
        //        // �䗦�v�Z
        //        SalesLandingAcs.CalcDaySalesTargetFromRatio(
        //            out salesTargetDayOfWeek,
        //            salesTarget,
        //            0,
        //            targetDate,
        //            endDate,
        //            this._sectionCode,
        //            this._ldgCalcRatioMngList,
        //            this._holidaySettingDic);

        //        // ���j�e��
        //        this.SalesTarget_uGrid.Rows[ROW_SALESTARGET_PROFIT_SUNDAY].Cells[columnName].Value = salesTargetDayOfWeek[0].ToString(FORMAT_NUM_ZERO);
        //        // ���j�e��
        //        this.SalesTarget_uGrid.Rows[ROW_SALESTARGET_PROFIT_MONDAY].Cells[columnName].Value = salesTargetDayOfWeek[1].ToString(FORMAT_NUM_ZERO);
        //        // �Ηj�e��
        //        this.SalesTarget_uGrid.Rows[ROW_SALESTARGET_PROFIT_TUESWDAY].Cells[columnName].Value = salesTargetDayOfWeek[2].ToString(FORMAT_NUM_ZERO);
        //        // ���j�e��
        //        this.SalesTarget_uGrid.Rows[ROW_SALESTARGET_PROFIT_WEDNESDAY].Cells[columnName].Value = salesTargetDayOfWeek[3].ToString(FORMAT_NUM_ZERO);
        //        // �ؗj�e��
        //        this.SalesTarget_uGrid.Rows[ROW_SALESTARGET_PROFIT_THURSDAY].Cells[columnName].Value = salesTargetDayOfWeek[4].ToString(FORMAT_NUM_ZERO);
        //        // ���j�e��
        //        this.SalesTarget_uGrid.Rows[ROW_SALESTARGET_PROFIT_FRIDAY].Cells[columnName].Value = salesTargetDayOfWeek[5].ToString(FORMAT_NUM_ZERO);
        //        // �y�j�e��
        //        this.SalesTarget_uGrid.Rows[ROW_SALESTARGET_PROFIT_SATURDAY].Cells[columnName].Value = salesTargetDayOfWeek[6].ToString(FORMAT_NUM_ZERO);
        //        // �j�Փ��e��
        //        this.SalesTarget_uGrid.Rows[ROW_SALESTARGET_PROFIT_HOLIDAY].Cells[columnName].Value = salesTargetDayOfWeek[7].ToString(FORMAT_NUM_ZERO);
        //    }
        //    else
        //    {
        //        // ���j�e��
        //        this.SalesTarget_uGrid.Rows[ROW_SALESTARGET_PROFIT_SUNDAY].Cells[columnName].Value = null;
        //        // ���j�e��
        //        this.SalesTarget_uGrid.Rows[ROW_SALESTARGET_PROFIT_MONDAY].Cells[columnName].Value = null;
        //        // �Ηj�e��
        //        this.SalesTarget_uGrid.Rows[ROW_SALESTARGET_PROFIT_TUESWDAY].Cells[columnName].Value = null;
        //        // ���j�e��
        //        this.SalesTarget_uGrid.Rows[ROW_SALESTARGET_PROFIT_WEDNESDAY].Cells[columnName].Value = null;
        //        // �ؗj�e��
        //        this.SalesTarget_uGrid.Rows[ROW_SALESTARGET_PROFIT_THURSDAY].Cells[columnName].Value = null;
        //        // ���j�e��
        //        this.SalesTarget_uGrid.Rows[ROW_SALESTARGET_PROFIT_FRIDAY].Cells[columnName].Value = null;
        //        // �y�j�e��
        //        this.SalesTarget_uGrid.Rows[ROW_SALESTARGET_PROFIT_SATURDAY].Cells[columnName].Value = null;
        //        // �j�Փ��e��
        //        this.SalesTarget_uGrid.Rows[ROW_SALESTARGET_PROFIT_HOLIDAY].Cells[columnName].Value = null;
        //    }
        //    // ���ʁi�j
        //    if (this.SalesTarget_uGrid.Rows[ROW_SALESTARGETCOUNT].Cells[columnName].Text != "")
        //    {
        //        salesTarget = double.Parse(this.SalesTarget_uGrid.Rows[ROW_SALESTARGETCOUNT].Cells[columnName].Text);
        //        // �䗦�v�Z
        //        SalesLandingAcs.CalcDaySalesTargetFromRatio(
        //            out salesTargetDayOfWeek,
        //            salesTarget,
        //            1,
        //            targetDate,
        //            endDate,
        //            this._sectionCode,
        //            this._ldgCalcRatioMngList,
        //            this._holidaySettingDic);

        //        // ���j����
        //        this.SalesTarget_uGrid.Rows[ROW_SALESTARGET_COUNT_SUNDAY].Cells[columnName].Value = salesTargetDayOfWeek[0].ToString(FORMAT_NUM_DECIMAL);
        //        // ���j����
        //        this.SalesTarget_uGrid.Rows[ROW_SALESTARGET_COUNT_MONDAY].Cells[columnName].Value = salesTargetDayOfWeek[1].ToString(FORMAT_NUM_DECIMAL);
        //        // �Ηj����
        //        this.SalesTarget_uGrid.Rows[ROW_SALESTARGET_COUNT_TUESDAY].Cells[columnName].Value = salesTargetDayOfWeek[2].ToString(FORMAT_NUM_DECIMAL);
        //        // ���j����
        //        this.SalesTarget_uGrid.Rows[ROW_SALESTARGET_COUNT_WEDNESDAY].Cells[columnName].Value = salesTargetDayOfWeek[3].ToString(FORMAT_NUM_DECIMAL);
        //        // �ؗj����
        //        this.SalesTarget_uGrid.Rows[ROW_SALESTARGET_COUNT_THURSDAY].Cells[columnName].Value = salesTargetDayOfWeek[4].ToString(FORMAT_NUM_DECIMAL);
        //        // ���j����
        //        this.SalesTarget_uGrid.Rows[ROW_SALESTARGET_COUNT_FRIDAY].Cells[columnName].Value = salesTargetDayOfWeek[5].ToString(FORMAT_NUM_DECIMAL);
        //        // �y�j����
        //        this.SalesTarget_uGrid.Rows[ROW_SALESTARGET_COUNT_SATURDAY].Cells[columnName].Value = salesTargetDayOfWeek[6].ToString(FORMAT_NUM_DECIMAL);
        //        // �j�Փ�����
        //        this.SalesTarget_uGrid.Rows[ROW_SALESTARGET_COUNT_HOLIDAY].Cells[columnName].Value = salesTargetDayOfWeek[7].ToString(FORMAT_NUM_DECIMAL);
        //    }
        //    else
        //    {
        //        // ���j����
        //        this.SalesTarget_uGrid.Rows[ROW_SALESTARGET_COUNT_SUNDAY].Cells[columnName].Value = null;
        //        // ���j����
        //        this.SalesTarget_uGrid.Rows[ROW_SALESTARGET_COUNT_MONDAY].Cells[columnName].Value = null;
        //        // �Ηj����
        //        this.SalesTarget_uGrid.Rows[ROW_SALESTARGET_COUNT_TUESDAY].Cells[columnName].Value = null;
        //        // ���j����
        //        this.SalesTarget_uGrid.Rows[ROW_SALESTARGET_COUNT_WEDNESDAY].Cells[columnName].Value = null;
        //        // �ؗj����
        //        this.SalesTarget_uGrid.Rows[ROW_SALESTARGET_COUNT_THURSDAY].Cells[columnName].Value = null;
        //        // ���j����
        //        this.SalesTarget_uGrid.Rows[ROW_SALESTARGET_COUNT_FRIDAY].Cells[columnName].Value = null;
        //        // �y�j����
        //        this.SalesTarget_uGrid.Rows[ROW_SALESTARGET_COUNT_SATURDAY].Cells[columnName].Value = null;
        //        // �j�Փ�����
        //        this.SalesTarget_uGrid.Rows[ROW_SALESTARGET_COUNT_HOLIDAY].Cells[columnName].Value = null;
        //    }
        //}

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �e�L�X�g�F�ύX����
        /// </summary>
        /// <param name="targetText">�Ώۃe�L�X�g</param>
        /// <param name="rowIndex">�s�C���f�b�N�X</param>
        /// <param name="columnIndex">�J�����C���f�b�N�X</param>
        /// <remarks>
        /// <br>Note		: �C�������ڕW�̃e�L�X�g�F��ύX���܂��B</br>
        /// <br>Programmer	: NEPCO</br>
        /// <br>Date		: 2007.05.14</br>
        /// </remarks>
        private void SetEditTextColor(string targetText, int rowIndex, int columnIndex)
        {
            if (targetText == "")
            {
                return;
            }
            
            bool targetFlag = false;
            string targetDivideCode = this.SalesTarget_uGrid.Rows[ROW_DATE].Cells[columnIndex].Text;
            targetDivideCode = targetDivideCode.Substring(0, 4) + targetDivideCode.Substring(5, 2);

            // �J���}�폜
            RemoveComma(targetText, out targetText);
            switch (rowIndex)
            {
                // ����
                case ROW_SALESTARGETMONEY:
                    long salesTargetMoney = long.Parse(targetText);
                    foreach (SalesTarget salesTarget in this._salesTargetList)
                    {
                        if (salesTarget.TargetDivideCode.TrimEnd() == targetDivideCode.TrimEnd())
                        {
                            if (salesTarget.SalesTargetMoney != salesTargetMoney)
                            {
                                this.SalesTarget_uGrid.Rows[rowIndex].Cells[columnIndex].Appearance.ForeColor = Color.Red;
                            }
                            else
                            {
                                this.SalesTarget_uGrid.Rows[rowIndex].Cells[columnIndex].Appearance.ForeColor = Color.Black;
                            }
                            targetFlag = true;
                        }
                    }
                    break;
                // �e��
                case ROW_SALESTARGETPROFIT:
                    long salesTargetProfit = long.Parse(targetText);
                    foreach (SalesTarget salesTarget in this._salesTargetList)
                    {
                        if (salesTarget.TargetDivideCode.TrimEnd() == targetDivideCode.TrimEnd())
                        {
                            if (salesTarget.SalesTargetProfit != salesTargetProfit)
                            {
                                this.SalesTarget_uGrid.Rows[rowIndex].Cells[columnIndex].Appearance.ForeColor = Color.Red;
                            }
                            else
                            {
                                this.SalesTarget_uGrid.Rows[rowIndex].Cells[columnIndex].Appearance.ForeColor = Color.Black;
                            }
                            targetFlag = true;
                        }
                    }
                    break;
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                //// ����
                //case ROW_SALESTARGETCOUNT:
                //    double salesTargetCount = double.Parse(targetText);
                //    foreach (SalesTarget salesTarget in this._salesTargetList)
                //    {
                //        if (salesTarget.TargetDivideCode.TrimEnd() == targetDivideCode.TrimEnd())
                //        {
                //            if (salesTarget.SalesTargetCount != salesTargetCount)
                //            {
                //                this.SalesTarget_uGrid.Rows[rowIndex].Cells[columnIndex].Appearance.ForeColor = Color.Red;
                //            }
                //            else
                //            {
                //                this.SalesTarget_uGrid.Rows[rowIndex].Cells[columnIndex].Appearance.ForeColor = Color.Black;
                //            }
                //            targetFlag = true;
                //        }
                //    }
                //    break;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            }
            if (targetFlag != true)
            {
                this.SalesTarget_uGrid.Rows[rowIndex].Cells[columnIndex].Appearance.ForeColor = Color.Red;
            }

        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �Z�����擾����
        /// </summary>
        /// <param name="fontSize">�t�H���g�T�C�Y</param>
        /// <remarks>
        /// <br>Note		: �O���b�h�̌��o���̃Z�������擾���܂��B</br>
        /// <br>Programmer	: NEPCO</br>
        /// <br>Date		: 2007.06.20</br>
        /// </remarks>
        private int GetCellWidth(int fontSize)
        {
            int cellWidth;

            switch (fontSize)
            {
                case 6:
                    cellWidth = 100;
                    break;
                case 8:
                    cellWidth = 125;
                    break;
                case 9:
                    cellWidth = 140;
                    break;
                case 10:
                    cellWidth = 155;
                    break;
                case 11:
                    cellWidth = 170;
                    break;
                case 12:
                    cellWidth = 185;
                    break;
                case 14:
                    cellWidth = 215;
                    break;
                default:
                    cellWidth = 155;
                    break;
            }

            return cellWidth;
        }

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// �O���b�h���C�A�E�g�ݒ菈��
		/// </summary>
		/// <remarks>
		/// <br>Note		: �O���b�h�̃��C�A�E�g�ݒ���s���܂��B</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.03.29</br>
		/// </remarks>
		private void SetLayout_SalesTarget_uGrid()
		{
			this.SalesTarget_uGrid.DisplayLayout.UseFixedHeaders = true;

			this.SalesTarget_uGrid.DisplayLayout.Bands[0].ColHeadersVisible = false;

            // ��X�^�C���ݒ�iHeader�j
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_HEADER].Header.Fixed = true;
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_HEADER].Width = GetCellWidth((int)this.cmbFontSize.Value);
			this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_HEADER].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
			this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_HEADER].CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
			this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_HEADER].CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
			this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_HEADER].CellAppearance.BackColor = COLOR_BACKCOLOR;
			this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_HEADER].CellAppearance.BackColor2 = COLOR_BACKCOLOR2;
			this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_HEADER].CellAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
			this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_HEADER].CellAppearance.ForeColor = Color.White;
			this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_HEADER].CellAppearance.ForeColorDisabled = Color.White;

            // �s�Œ�
            this.SalesTarget_uGrid.DisplayLayout.Rows[ROW_CLEAR].Fixed = true;
            this.SalesTarget_uGrid.DisplayLayout.Rows[ROW_DATE].Fixed = true;

			// ���o���ݒ�
            this.SalesTarget_uGrid.Rows[ROW_CLEAR].Cells[COL_SALESTARGET_HEADER].Value = VIEW_SALESTARGET_CLEAR;
            this.SalesTarget_uGrid.Rows[ROW_DATE].Cells[COL_SALESTARGET_HEADER].Value = VIEW_SALESTARGET_MONTH;
            this.SalesTarget_uGrid.Rows[ROW_SALESTARGETMONEY].Cells[COL_SALESTARGET_HEADER].Value = VIEW_SALESTARGET_MONEY;
            this.SalesTarget_uGrid.Rows[ROW_SALESTARGETPROFIT].Cells[COL_SALESTARGET_HEADER].Value = VIEW_SALESTARGET_PROFIT;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //this.SalesTarget_uGrid.Rows[ROW_SALESTARGETCOUNT].Cells[COL_SALESTARGET_HEADER].Value = VIEW_SALESTARGET_COUNT;

            //this.SalesTarget_uGrid.Rows[ROW_SALESTARGET_MONEY_SUNDAY].Cells[COL_SALESTARGET_HEADER].Value = VIEW_SALESTARGET_MONEY_SUNDAY;
            //this.SalesTarget_uGrid.Rows[ROW_SALESTARGET_PROFIT_SUNDAY].Cells[COL_SALESTARGET_HEADER].Value = VIEW_SALESTARGET_PROFIT_SUNDAY;
            //this.SalesTarget_uGrid.Rows[ROW_SALESTARGET_COUNT_SUNDAY].Cells[COL_SALESTARGET_HEADER].Value = VIEW_SALESTARGET_COUNT_SUNDAY;
            //this.SalesTarget_uGrid.Rows[ROW_SALESTARGET_MONEY_MONDAY].Cells[COL_SALESTARGET_HEADER].Value = VIEW_SALESTARGET_MONEY_MONDAY;
            //this.SalesTarget_uGrid.Rows[ROW_SALESTARGET_PROFIT_MONDAY].Cells[COL_SALESTARGET_HEADER].Value = VIEW_SALESTARGET_PROFIT_MONDAY;
            //this.SalesTarget_uGrid.Rows[ROW_SALESTARGET_COUNT_MONDAY].Cells[COL_SALESTARGET_HEADER].Value = VIEW_SALESTARGET_COUNT_MONDAY;
            //this.SalesTarget_uGrid.Rows[ROW_SALESTARGET_MONEY_TUESDAY].Cells[COL_SALESTARGET_HEADER].Value = VIEW_SALESTARGET_MONEY_TUESDAY;
            //this.SalesTarget_uGrid.Rows[ROW_SALESTARGET_PROFIT_TUESWDAY].Cells[COL_SALESTARGET_HEADER].Value = VIEW_SALESTARGET_PROFIT_TUESWDAY;
            //this.SalesTarget_uGrid.Rows[ROW_SALESTARGET_COUNT_TUESDAY].Cells[COL_SALESTARGET_HEADER].Value = VIEW_SALESTARGET_COUNT_TUESDAY;
            //this.SalesTarget_uGrid.Rows[ROW_SALESTARGET_MONEY_WEDNESDAY].Cells[COL_SALESTARGET_HEADER].Value = VIEW_SALESTARGET_MONEY_WEDNESDAY;
            //this.SalesTarget_uGrid.Rows[ROW_SALESTARGET_PROFIT_WEDNESDAY].Cells[COL_SALESTARGET_HEADER].Value = VIEW_SALESTARGET_PROFIT_WEDNESDAY;
            //this.SalesTarget_uGrid.Rows[ROW_SALESTARGET_COUNT_WEDNESDAY].Cells[COL_SALESTARGET_HEADER].Value = VIEW_SALESTARGET_COUNT_WEDNESDAY;
            //this.SalesTarget_uGrid.Rows[ROW_SALESTARGET_MONEY_THURSDAY].Cells[COL_SALESTARGET_HEADER].Value = VIEW_SALESTARGET_MONEY_THURSDAY;
            //this.SalesTarget_uGrid.Rows[ROW_SALESTARGET_PROFIT_THURSDAY].Cells[COL_SALESTARGET_HEADER].Value = VIEW_SALESTARGET_PROFIT_THURSDAY;
            //this.SalesTarget_uGrid.Rows[ROW_SALESTARGET_COUNT_THURSDAY].Cells[COL_SALESTARGET_HEADER].Value = VIEW_SALESTARGET_COUNT_THURSDAY;
            //this.SalesTarget_uGrid.Rows[ROW_SALESTARGET_MONEY_FRIDAY].Cells[COL_SALESTARGET_HEADER].Value = VIEW_SALESTARGET_MONEY_FRIDAY;
            //this.SalesTarget_uGrid.Rows[ROW_SALESTARGET_PROFIT_FRIDAY].Cells[COL_SALESTARGET_HEADER].Value = VIEW_SALESTARGET_PROFIT_FRIDAY;
            //this.SalesTarget_uGrid.Rows[ROW_SALESTARGET_COUNT_FRIDAY].Cells[COL_SALESTARGET_HEADER].Value = VIEW_SALESTARGET_COUNT_FRIDAY;
            //this.SalesTarget_uGrid.Rows[ROW_SALESTARGET_MONEY_SATURDAY].Cells[COL_SALESTARGET_HEADER].Value = VIEW_SALESTARGET_MONEY_SATURDAY;
            //this.SalesTarget_uGrid.Rows[ROW_SALESTARGET_PROFIT_SATURDAY].Cells[COL_SALESTARGET_HEADER].Value = VIEW_SALESTARGET_PROFIT_SATURDAY;
            //this.SalesTarget_uGrid.Rows[ROW_SALESTARGET_COUNT_SATURDAY].Cells[COL_SALESTARGET_HEADER].Value = VIEW_SALESTARGET_COUNT_SATURDAY;
            //this.SalesTarget_uGrid.Rows[ROW_SALESTARGET_MONEY_HOLIDAY].Cells[COL_SALESTARGET_HEADER].Value = VIEW_SALESTARGET_MONEY_HOLIDAY;
            //this.SalesTarget_uGrid.Rows[ROW_SALESTARGET_PROFIT_HOLIDAY].Cells[COL_SALESTARGET_HEADER].Value = VIEW_SALESTARGET_PROFIT_HOLIDAY;
            //this.SalesTarget_uGrid.Rows[ROW_SALESTARGET_COUNT_HOLIDAY].Cells[COL_SALESTARGET_HEADER].Value = VIEW_SALESTARGET_COUNT_HOLIDAY;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
			if (this._searchFlag == false)
			{
				return;
			}

            // �J�����̃L�[���
            string columnName = "";
            int count = 0;

            // ���I�J�����X�^�C���ݒ�
			for (DateTime targetDate = this._targetDateSt; targetDate <= this._targetDateEd; targetDate = targetDate.AddMonths(1))
			{
                count++;

                columnName = targetDate.Year.ToString() + targetDate.Month.ToString("00");

                this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[columnName].Width = WIDTH_SALESTARGET;
				this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[columnName].CellAppearance.ForeColorDisabled = Color.Black;
				this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[columnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
				this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[columnName].CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
				this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[columnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;

				this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[columnName].MaxLength = 12;

				// �N���A�s�ݒ�
                this.SalesTarget_uGrid.Rows[ROW_CLEAR].Cells[columnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button;
                this.SalesTarget_uGrid.Rows[ROW_CLEAR].Cells[columnName].Activation = Activation.ActivateOnly;
				this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[columnName].ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always;
                this.SalesTarget_uGrid.Rows[ROW_CLEAR].Cells[columnName].ButtonAppearance.Image = IconResourceManagement.ImageList32.Images[(int)Size32_Index.RETRY];
                this.SalesTarget_uGrid.Rows[ROW_CLEAR].Cells[columnName].ButtonAppearance.ImageHAlign = Infragistics.Win.HAlign.Center;
                this.SalesTarget_uGrid.Rows[ROW_CLEAR].Cells[columnName].ButtonAppearance.ImageVAlign = Infragistics.Win.VAlign.Middle;

				// �N��
                this.SalesTarget_uGrid.DisplayLayout.Rows[ROW_DATE].Cells[columnName].Appearance.BackColor = COLOR_BACKCOLOR;
                this.SalesTarget_uGrid.DisplayLayout.Rows[ROW_DATE].Cells[columnName].Appearance.BackColor2 = COLOR_BACKCOLOR2;
                this.SalesTarget_uGrid.DisplayLayout.Rows[ROW_DATE].Cells[columnName].Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
                this.SalesTarget_uGrid.DisplayLayout.Rows[ROW_DATE].Cells[columnName].Appearance.ForeColor = Color.White;
                this.SalesTarget_uGrid.DisplayLayout.Rows[ROW_DATE].Cells[columnName].Appearance.ForeColorDisabled = Color.White;
                this.SalesTarget_uGrid.DisplayLayout.Rows[ROW_DATE].Cells[columnName].Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                this.SalesTarget_uGrid.DisplayLayout.Rows[ROW_DATE].Cells[columnName].Appearance.TextVAlign = Infragistics.Win.VAlign.Middle;
                this.SalesTarget_uGrid.DisplayLayout.Rows[ROW_DATE].Cells[columnName].Activation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
                this.SalesTarget_uGrid.DisplayLayout.Rows[ROW_DATE].Cells[columnName].Value = targetDate.Year.ToString() + "/" + targetDate.Month.ToString("00");
			}

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //// �u���j����v�`�u�j�Փ����ʁv
            //for (int rowIndex = ROW_SALESTARGET_MONEY_SUNDAY; rowIndex <= ROW_SALESTARGET_COUNT_HOLIDAY; rowIndex++)
            //{
            //    // �Z������ݒ�i�䗦�����j
            //    this.SalesTarget_uGrid.DisplayLayout.Rows[rowIndex].Activation = Infragistics.Win.UltraWinGrid.Activation.Disabled;

            //    for (DateTime targetDate = this._targetDateSt; targetDate <= this._targetDateEd; targetDate = targetDate.AddMonths(1))
            //    {
            //        columnName = targetDate.Year.ToString() + targetDate.Month.ToString("00");

            //        // �Z���w�i�F�ݒ�i�䗦�����j
            //        this.SalesTarget_uGrid.DisplayLayout.Rows[rowIndex].Cells[columnName].Appearance.BackColor = Color.FromName("control");
            //    }
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// �O���b�h�쐬����
		/// </summary>
        /// <param name="salesTargetList">�ڕW�f�[�^���X�g</param>
		/// <remarks>
		/// <br>Note		: �O���b�h���쐬���܂��B</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.03.29</br>
		/// </remarks>
		private void DispScreen(List<SalesTarget> salesTargetList)
		{
			// �f�[�^�ǉ��p
			DataRow dataRow;

			// �e�[�u���̒�`
			DataTable dataTable = new DataTable();

			// �J�����쐬
			dataTable.Columns.Add(COL_SALESTARGET_HEADER, typeof(string));

            // �J�����̃L�[���
            string columnName = "";

			if (this._searchFlag == true)
			{
                for (DateTime targetDate = this._targetDateSt; targetDate <= this._targetDateEd; targetDate = targetDate.AddMonths(1))
                {
                    columnName = targetDate.Year.ToString() + targetDate.Month.ToString("00");

                    dataTable.Columns.Add(columnName, typeof(string));
                }
			}

			// �f�[�^�s�쐬
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //for ( int index = ROW_CLEAR; index <= ROW_SALESTARGET_COUNT_HOLIDAY; index++ )
            for ( int index = ROW_CLEAR; index <= ROW_SALESTARGETPROFIT; index++ )
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
			{
				dataRow = dataTable.NewRow();

				dataRow[COL_SALESTARGET_HEADER] = "";

				if (this._searchFlag == true)
				{
					for (DateTime targetDate = this._targetDateSt; targetDate <= this._targetDateEd; targetDate = targetDate.AddMonths(1))
					{
                        columnName = targetDate.Year.ToString() + targetDate.Month.ToString("00");

                        dataRow[columnName] = DBNull.Value;
					}
				}
				dataTable.Rows.Add(dataRow);
			}

			this.SalesTarget_uGrid.DataSource = dataTable;
			this.SalesTarget_uGrid.DataBind();
			
			if (this._searchFlag == false)
			{
				return;
			}

            // �f�[�^�ݒ�
			for (DateTime targetDate = this._targetDateSt; targetDate <= this._targetDateEd; targetDate = targetDate.AddMonths(1))
			{
                columnName = targetDate.Year.ToString() + targetDate.Month.ToString("00");

				foreach (SalesTarget salesTarget in salesTargetList)
				{
					if (salesTarget.ApplyStaDate.Date == targetDate.Date)
					{
                        this.SalesTarget_uGrid.Rows[ROW_SALESTARGETMONEY].Cells[columnName].Value = salesTarget.SalesTargetMoney.ToString(FORMAT_NUM);
                        this.SalesTarget_uGrid.Rows[ROW_SALESTARGETPROFIT].Cells[columnName].Value = salesTarget.SalesTargetProfit.ToString(FORMAT_NUM);
                        
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                        ////this.SalesTarget_uGrid.Rows[ROW_SALESTARGETCOUNT].Cells[columnName].Value = salesTarget.SalesTargetCount.ToString(FORMAT_NUM);
                        //if (salesTarget.SalesTargetCount == 0)
                        //{
                        //    this.SalesTarget_uGrid.Rows[ROW_SALESTARGETCOUNT].Cells[columnName].Value = salesTarget.SalesTargetCount.ToString(FORMAT_NUM);
                        //}
                        //else
                        //{
                        //    this.SalesTarget_uGrid.Rows[ROW_SALESTARGETCOUNT].Cells[columnName].Value = salesTarget.SalesTargetCount.ToString(FORMAT_NUM_DECIMAL);
                        //}

                        //// �䗦�v�Z�i���ʁj
                        //CalcFromRatioSalesDay(targetDate);
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
					}
				}
			}
		}

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �����`�F�b�N����
        /// </summary>
        /// <remarks>
        /// Note	   : �ڕW�������ς݂��ǂ����`�F�b�N���܂��B<br />
        /// Programmer : NEPCO<br />
        /// Date	   : 2007.04.27<br />
        /// </remarks>
        private bool CheckSearchFlag()
        {
            string errMsg = "";

            try
            {
                if (this._searchFlag == false)
                {
                    errMsg = "�ڕW�����͂���Ă��܂���";
                    this.Search_Button.Focus();
                    return (false);
                }
            }
            finally
            {
                if (errMsg.Length > 0)
                {
                    TMsgDisp.Show(
                            this, 							// �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_INFO, 	// �G���[���x��
                            this.Name,						// �A�Z���u��ID
                            errMsg, 						// �\�����郁�b�Z�[�W
                            0,								// �X�e�[�^�X�l
                            MessageBoxButtons.OK);			// �\������{�^��
                }
            }
            return (true);
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// ���͍��Z�l�`�F�b�N����
        /// </summary>
        /// <remarks>
        /// Note	   : ���͍��Z�l�Ɗ��ԖڕW�̒l���r���܂��B<br />
        /// Programmer : NEPCO<br />
        /// Date	   : 2007.04.09<br />
        /// </remarks>
        private bool CheckSalesTarget()
        {
            bool checkDialog = false;

            if (this.SalesTargetMoney_tNedit.DataText != "")
            {
                if (this.SalesTargetMoney_tNedit.DataText != this.InputSalesTargetMoney_tNedit.DataText)
                {
                    checkDialog = true;
                }
            }
            if (this.SalesTargetProfit_tNedit.DataText != "")
            {
                if (this.SalesTargetProfit_tNedit.DataText != this.InputSalesTargetProfit_tNedit.DataText)
                {
                    checkDialog = true;
                }
            }
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //if (this.SalesTargetCount_tNedit.DataText != "")
            //{
            //    if (this.SalesTargetCount_tNedit.DataText != this.InputSalesTargetCount_tNedit.DataText)
            //    {
            //        checkDialog = true;
            //    }
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            if (checkDialog)
            {
                DialogResult res = TMsgDisp.Show(
                        this, 							// �e�E�B���h�E�t�H�[��
                        emErrorLevel.ERR_LEVEL_INFO, 	// �G���[���x��
                        this.Name,						// �A�Z���u��ID
                        "���ԖڕW�Ɠ��͍��Z�l���Ⴂ�܂����ۑ����܂����H", 						// �\�����郁�b�Z�[�W
                        0,								// �X�e�[�^�X�l
                        MessageBoxButtons.OKCancel);			// �\������{�^��

                switch (res)
                {
                    case DialogResult.OK:
                        {
                            return (true);
                        }
                    case DialogResult.Cancel:
                        {
                            return (false);
                        }
                }
            }

            return (true);
        }

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// �C���ڕW�f�[�^�`�F�b�N����
		/// </summary>
		/// <remarks>
		/// Note	   : �C���ڕW�f�[�^���`�F�b�N���܂��B<br />
		/// Programmer : NEPCO<br />
		/// Date	   : 2007.04.09<br />
		/// </remarks>
		private bool CheckInputData()
		{
            string columnName = "";

            // �ڕW���̓`�F�b�N
            for (DateTime targetYearMonth = this._targetDateSt; targetYearMonth <= this._targetDateEd; targetYearMonth = targetYearMonth.AddMonths(1))
            {
                columnName = targetYearMonth.Year.ToString() + targetYearMonth.Month.ToString("00");

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                //if (this.SalesTarget_uGrid.Rows[ROW_SALESTARGETMONEY].Cells[columnName].Text == "" &&
                //    this.SalesTarget_uGrid.Rows[ROW_SALESTARGETPROFIT].Cells[columnName].Text == "" &&
                //    this.SalesTarget_uGrid.Rows[ROW_SALESTARGETCOUNT].Cells[columnName].Text == "")
                if ( this.SalesTarget_uGrid.Rows[ROW_SALESTARGETMONEY].Cells[columnName].Text == "" &&
                    this.SalesTarget_uGrid.Rows[ROW_SALESTARGETPROFIT].Cells[columnName].Text == "")
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
                {
                    TMsgDisp.Show(
                            this, 							// �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_INFO, 	// �G���[���x��
                            this.Name,						// �A�Z���u��ID
                            "�ڕW����͂��Ă�������", 						// �\�����郁�b�Z�[�W
                            0,								// �X�e�[�^�X�l
                            MessageBoxButtons.OK);			// �\������{�^��

                    this.SalesTarget_uGrid.Rows[ROW_SALESTARGETMONEY].Cells[columnName].Activate();
                    this.SalesTarget_uGrid.PerformAction(UltraGridAction.EnterEditMode, false, false);
                    return (false);
                }

                double inputSalesTarget = 0;
                double inputSalesTargetProfit = 0;
                double inputSalesTargetCount = 0;
                if (this.SalesTarget_uGrid.Rows[ROW_SALESTARGETMONEY].Cells[columnName].Text != "")
                {
                    inputSalesTarget = double.Parse(this.SalesTarget_uGrid.Rows[ROW_SALESTARGETMONEY].Cells[columnName].Text);
                }
                if (this.SalesTarget_uGrid.Rows[ROW_SALESTARGETPROFIT].Cells[columnName].Text != "")
                {
                    inputSalesTargetProfit = double.Parse(this.SalesTarget_uGrid.Rows[ROW_SALESTARGETPROFIT].Cells[columnName].Text);
                }
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                //if (this.SalesTarget_uGrid.Rows[ROW_SALESTARGETCOUNT].Cells[columnName].Text != "")
                //{
                //    inputSalesTargetCount = double.Parse(this.SalesTarget_uGrid.Rows[ROW_SALESTARGETCOUNT].Cells[columnName].Text);
                //}
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
                if (inputSalesTarget == 0 && inputSalesTargetProfit == 0 && inputSalesTargetCount == 0)
                {
                    TMsgDisp.Show(
                            this, 							// �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_INFO, 	// �G���[���x��
                            this.Name,						// �A�Z���u��ID
                            "�ڕW����͂��Ă�������", 						// �\�����郁�b�Z�[�W
                            0,								// �X�e�[�^�X�l
                            MessageBoxButtons.OK);			// �\������{�^��

                    this.SalesTarget_uGrid.Rows[ROW_SALESTARGETMONEY].Cells[columnName].Activate();
                    this.SalesTarget_uGrid.PerformAction(UltraGridAction.EnterEditMode, false, false);
                    return (false);
                }
            }

            return (true);
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// ���������`�F�b�N����
		/// </summary>
		/// <remarks>
		/// <br>Note		: ���������̓��̓`�F�b�N���s���܂��B</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.03.29</br>
		/// </remarks>
		private bool CheckSearchCondition()
		{
			string errMsg = "";
			
			try
			{
                // �K�p��(�J�n�j
                if (this.ApplyStaMonth_tDateEdit.GetDateYear() == 0 ||
                    this.ApplyStaMonth_tDateEdit.GetDateMonth() == 0)
                {
                    errMsg = "���t����͂��Ă�������";
                    this.ApplyStaMonth_tDateEdit.Focus();
                    return (false);
                }
                if (this.ApplyStaMonth_tDateEdit.GetDateYear() != 0 &&
                    this.ApplyStaMonth_tDateEdit.GetDateMonth() != 0)
                {
                    try
                    {
                        DateTime dummyDateTime = new DateTime(
                            this.ApplyStaMonth_tDateEdit.GetDateYear(),
                            this.ApplyStaMonth_tDateEdit.GetDateMonth(),
                            1);
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        errMsg = "���t�𐳂������͂��Ă�������";
                        this.ApplyStaMonth_tDateEdit.Focus();
                        return (false);
                    }
                }

                // �K�p��(�I��)
                if (this.ApplyEndMonth_tDateEdit.GetDateYear() == 0 ||
                    this.ApplyEndMonth_tDateEdit.GetDateMonth() == 0)
                {
                    errMsg = "���t����͂��Ă�������";
                    this.ApplyEndMonth_tDateEdit.Focus();
                    return (false);
                }
                if (this.ApplyEndMonth_tDateEdit.GetDateYear() != 0 &&
                    this.ApplyEndMonth_tDateEdit.GetDateMonth() != 0)
                {
                    try
                    {
                        DateTime dummyDateTime = new DateTime(
                            this.ApplyEndMonth_tDateEdit.GetDateYear(),
                            this.ApplyEndMonth_tDateEdit.GetDateMonth(),
                            1);
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        errMsg = "���t�𐳂������͂��Ă�������";
                        this.ApplyEndMonth_tDateEdit.Focus();
                        return (false);
                    }
                }

				int salesTargetYmSt = this.ApplyStaMonth_tDateEdit.GetDateYear() * 100 + this.ApplyStaMonth_tDateEdit.GetDateMonth();
				int salesTargetYmEd = this.ApplyEndMonth_tDateEdit.GetDateYear() * 100 + this.ApplyEndMonth_tDateEdit.GetDateMonth();

				if (salesTargetYmSt > salesTargetYmEd)
				{
					errMsg = "�J�n�@<=  �I���Ŏw�肵�Ă�������";
					this.ApplyStaMonth_tDateEdit.Focus();
					return (false);
				}
				if (salesTargetYmSt + 100 <= salesTargetYmEd)
				{
					errMsg = "���Ԃ�12�����ȓ��Ŏw�肵�Ă�������";
					this.ApplyStaMonth_tDateEdit.Focus();
					return (false);
				}
			}
			finally
			{
				if (errMsg.Length > 0)
				{
					TMsgDisp.Show(
							this, 							        // �e�E�B���h�E�t�H�[��
							emErrorLevel.ERR_LEVEL_EXCLAMATION, 	// �G���[���x��
							this.Name,						        // �A�Z���u��ID
							errMsg, 						        // �\�����郁�b�Z�[�W
							0,								        // �X�e�[�^�X�l
							MessageBoxButtons.OK);			        // �\������{�^��
				}
			}

			return (true);
		}

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// ���������ݒ菈��
        /// </summary>
        /// <param name="extrInfo">��������</param>
        /// <remarks>
        /// <br>Note		: �ڕW�f�[�^�̌���������ݒ肵�܂��B</br>
        /// <br>Programmer	: NEPCO</br>
        /// <br>Date		: 2007.04.23</br>
        /// </remarks>
        private void GetExtrInfo(out ExtrInfo_MAMOK09197EA extrInfo)
        {
            extrInfo = new ExtrInfo_MAMOK09197EA();

            // ��ƃR�[�h
            extrInfo.EnterpriseCode = this._enterpriseCode;
            // ���_�R�[�h
            extrInfo.SelectSectCd = new string[1];
            extrInfo.SelectSectCd[0] = this._sectionCode;
            // �ڕW�ݒ�敪
            extrInfo.TargetSetCd = 10;
            // �ڕW�Δ�敪
            extrInfo.TargetContrastCd = (int)SalesTarget.ConstrastCd.Section;

            int days;

            // �K�p�J�n���i�J�n�j
            extrInfo.ApplyStaDateSt = this._targetDateSt.Date;
            // �K�p�J�n���i�I���j
            extrInfo.ApplyStaDateEd = DateTime.MinValue;
            // �K�p�I�����i�J�n�j
            extrInfo.ApplyEndDateSt = DateTime.MinValue;
            // �K�p�I�����i�I���j
            days = DateTime.DaysInMonth(this._targetDateEd.Year, this._targetDateEd.Month);
            extrInfo.ApplyEndDateEd = new DateTime(this._targetDateEd.Year, this._targetDateEd.Month, days);

        }

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// �v�Z�����`�F�b�N����
		/// </summary>
		/// <remarks>
		/// <br>Note		: �䗦����v�Z���邽�߂̓��̓`�F�b�N���s���܂��B</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.03.29</br>
		/// </remarks>
		private bool CheckCalcCondition()
		{
			string errMsg = "";

			try
			{
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                //if (this.SalesTargetMoney_tNedit.DataText == "" &&
                //    this.SalesTargetProfit_tNedit.DataText == "" &&
                //    this.SalesTargetCount_tNedit.DataText == "")
                if ( this.SalesTargetMoney_tNedit.DataText == "" &&
                    this.SalesTargetProfit_tNedit.DataText == "" )
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
                {
                    errMsg = "�ڕW���z�܂��͐��ʂ���͂��Ă�������";
                    this.SalesTargetMoney_tNedit.Focus();
                    return (false);
                }

                bool ratioFlag = true;
				int index = 0;
                for (DateTime targetDate = this._targetDateSt; targetDate <= this._targetDateEd; targetDate = targetDate.AddMonths(1))
                {
                    if (this._ratioMonth_tNedit[index].Value == null || double.Parse(this._ratioMonth_tNedit[index].DataText) == 0)
                    {
                        ratioFlag = false;
                    }
                    else
                    {
                        ratioFlag = true;
                        break;
                    }
                    index++;
                }
                if (ratioFlag == false)
                {
                    errMsg = "���ʂ̔䗦����͂��Ă�������";
                    this._ratioMonth_tNedit[0].Focus();
                    return (false);
                }
			}
			finally
			{
				if (errMsg.Length > 0)
				{
					TMsgDisp.Show(
							this, 							// �e�E�B���h�E�t�H�[��
							emErrorLevel.ERR_LEVEL_INFO, 	// �G���[���x��
							this.Name,						// �A�Z���u��ID
							errMsg, 						// �\�����郁�b�Z�[�W
							0,								// �X�e�[�^�X�l
							MessageBoxButtons.OK);			// �\������{�^��
				}
			}
			return (true);
		}
		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// ���͒l�`�F�b�N����
		/// </summary>
		/// <remarks>
		/// <br>Note		: ���͒l�����̔��p�������ǂ����`�F�b�N���s���܂��B</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.03.29</br>
		/// </remarks>
		private bool CheckEditCharacter()
		{
            if (!this._searchFlag)
            {
                return (true);
            }
            if (this._editRowIndex < ROW_SALESTARGETMONEY)
            {
                return (true);
            }
            if (this._editColumnIndex < 1)
            {
                return (true);
            }
			if (this.SalesTarget_uGrid.Rows[this._editRowIndex].Cells[this._editColumnIndex].Text == "")
			{
				return (true);
			}

			string errMsg = "";
			string checkText = "";
			double num;

			checkText = this.SalesTarget_uGrid.Rows[this._editRowIndex].Cells[this._editColumnIndex].Text;

            try
            {
                if (!double.TryParse(checkText, out num) ||
                    checkText.Substring(0, 1) == "-")
                {
                    errMsg = "���̐��l����͂��Ă�������";
                    this.SalesTarget_uGrid.Rows[this._editRowIndex].Cells[this._editColumnIndex].Activate();
                    return (false);
                }
            }
            finally
            {
                if (errMsg.Length > 0)
                {
                    TMsgDisp.Show(
                            this, 							// �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_INFO, 	// �G���[���x��
                            this.Name,						// �A�Z���u��ID
                            errMsg, 						// �\�����郁�b�Z�[�W
                            0,								// �X�e�[�^�X�l
                            MessageBoxButtons.OK);			// �\������{�^��
                }
            }

            return (true);
		}

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// ���͓��t�`�F�b�N����
        /// </summary>
        /// <remarks>
        /// <br>Note		: ���͂��ꂽ���t���`�F�b�N���܂��B</br>
        /// <br>Programmer	: NEPCO</br>
        /// <br>Date		: 2007.04.23</br>
        /// </remarks>
        private bool CheckInputDate(TDateEdit tDateEdit)
        {
            string errMsg = "";

            try
            {
                if (tDateEdit.GetDateYear() != 0 &&
                    tDateEdit.GetDateMonth() != 0)
                {
                    try
                    {
                        DateTime dummyDateTime = new DateTime(
                            tDateEdit.GetDateYear(),
                            tDateEdit.GetDateMonth(),
                            1);
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        errMsg = "���t�𐳂������͂��Ă�������";
                        tDateEdit.Focus();
                        return (false);
                    }

                    if (tDateEdit.GetDateYear() == 1 &&
                    tDateEdit.GetDateMonth() == 1)
                    {
                        errMsg = "���t�𐳂������͂��Ă�������";
                        tDateEdit.Focus();
                        return (false);
                    }

                    if (tDateEdit.GetDateYear() < 1900)
                    {
                        errMsg = "���t�𐳂������͂��Ă�������";
                        tDateEdit.Focus();
                        return (false);
                    }
                }
            }
            finally
            {
                if (errMsg.Length > 0)
                {
                    TMsgDisp.Show(
                                    this, 							// �e�E�B���h�E�t�H�[��
                                    emErrorLevel.ERR_LEVEL_INFO, 	// �G���[���x��
                                    this.Name,						// �A�Z���u��ID
                                    errMsg, 						// �\�����郁�b�Z�[�W
                                    0,								// �X�e�[�^�X�l
                                    MessageBoxButtons.OK);			// �\������{�^��
                }
            }
            return (true);
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// ��f�[�^�폜�`�F�b�N����
        /// </summary>
        /// <param name="columnIndex">�J�����C���f�b�N�X</param>
        /// <remarks>
        /// <br>Note		: ��f�[�^���폜����O�Ƀ_�C�A���O�m�F���s���܂��B</br>
        /// <br>Programmer	: NEPCO</br>
        /// <br>Date		: 2007.03.30</br>
        /// </remarks>
        private void ClearTargetColumnData(int columnIndex)
        {
            string msg = "";

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //// �u����ڕW�v�`�u���ʖڕW�v
            //for (int rowIndex = ROW_SALESTARGETMONEY; rowIndex <= ROW_SALESTARGETCOUNT; rowIndex++)
            // �u����ڕW�v�`�u�e���ڕW�v
            for ( int rowIndex = ROW_SALESTARGETMONEY; rowIndex <= ROW_SALESTARGETPROFIT; rowIndex++ )
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            {
                if (this.SalesTarget_uGrid.Rows[rowIndex].Cells[columnIndex].Text != "")
                {
                    DateTime targetMonth = this._targetDateSt.AddMonths(columnIndex - 1);
                    msg = targetMonth.Year.ToString("0000") + "�N" + targetMonth.Month.ToString("00") + "���̖ڕW�f�[�^���N���A���܂����A��낵���ł����H";

                    break;
                }
            }
            if (msg.Length <= 0)
            {
                return;
            }

            DialogResult res = TMsgDisp.Show(
                                    this, 							// �e�E�B���h�E�t�H�[��
                                    emErrorLevel.ERR_LEVEL_INFO, 	// �G���[���x��
                                    this.Name,						// �A�Z���u��ID
                                    msg, 						    // �\�����郁�b�Z�[�W
                                    0,								// �X�e�[�^�X�l
                                    MessageBoxButtons.OKCancel);	// �\������{�^��
            if (res != DialogResult.OK)
            {
                return;
            }

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //// �u����ڕW�v�`�u�j�Փ����ʁv
            //for (int rowIndex = ROW_SALESTARGETMONEY; rowIndex <= ROW_SALESTARGET_COUNT_HOLIDAY; rowIndex++)
            // �u����ڕW�v�`�u�e���ڕW�v
            for ( int rowIndex = ROW_SALESTARGETMONEY; rowIndex <= ROW_SALESTARGETPROFIT; rowIndex++ )
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            {
                // ���͒l�̏�����
                this.SalesTarget_uGrid.Rows[rowIndex].Cells[columnIndex].Value = "";

                // ���͍��Z�l�\��
                SetInputSalesTarget(rowIndex);
            }
        }

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// �J���}�폜����
		/// </summary>
        /// <param name="targetText">�J���}�폜�O�e�L�X�g</param>
        /// <param name="retText">�J���}�폜�ς݃e�L�X�g</param>
		/// <remarks>
		/// <br>Note		: �Ώۂ̃e�L�X�g����J���}���폜���܂��B</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.03.30</br>
		/// </remarks>
		private void RemoveComma(string targetText, out string retText)
		{
			retText = "";

			// �Z���l�ҏW�p�ɃJ���}�폜
            for (int i = targetText.Length - 1; i >= 0; i--)
            {
                if (targetText[i].ToString() == ",")
                {
                    targetText = targetText.Remove(i, 1);
                }
            }

			retText = targetText;
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// �R���g���[���T�C�Y�ݒ菈��
		/// </summary>
		/// <remarks>
		/// <br>Note		: �R���g���[���T�C�Y�̐ݒ���s���܂��B</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.03.29</br>
		/// </remarks>
		private void SetControlSize()
		{
			// �R���g���[���T�C�Y�ݒ�
			this.SalesTargetMoney_tNedit.Size = new Size(155, 24);
			this.SalesTargetProfit_tNedit.Size = new Size(155, 24);
			// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //this.SalesTargetCount_tNedit.Size = new Size(131, 24);
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
			this.InputSalesTargetMoney_tNedit.Size = new Size(155, 24);
			this.InputSalesTargetProfit_tNedit.Size = new Size(155, 24);
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //this.InputSalesTargetCount_tNedit.Size = new Size(131, 24);
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //this.RatioSunday_tNedit.Size = new Size(66, 22);
            //this.RatioMonth_tNedit.Size = new Size(66, 22);
            //this.RatioTuesday_tNedit.Size = new Size(66, 22);
            //this.RatioWednesday_tNedit.Size = new Size(66, 22);
            //this.RatioThursday_tNedit.Size = new Size(66, 22);
            //this.RatioFriday_tNedit.Size = new Size(66, 22);
            //this.RatioSaturday_tNedit.Size = new Size(66, 22);
            //this.RatioHoliday_tNedit.Size = new Size(66, 22);
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
		}

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// Nedit�X�^�C���ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note		: Nedit�̃X�^�C����ݒ肵�܂��B</br>
        /// <br>Programmer	: NEPCO</br>
        /// <br>Date		: 2007.04.20</br>
        /// </remarks>
        private void SetNeditStyle()
        {
            this.SalesTargetMoney_tNedit.NumEdit.CommaEdit = true;
            this.SalesTargetMoney_tNedit.NumEdit.ZeroSupp = emZeroSupp.zsON;
            this.SalesTargetMoney_tNedit.NumEdit.MinusSupp = true;
            this.SalesTargetProfit_tNedit.NumEdit.CommaEdit = true;
            this.SalesTargetProfit_tNedit.NumEdit.ZeroSupp = emZeroSupp.zsON;
            this.SalesTargetProfit_tNedit.NumEdit.MinusSupp = true;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //this.SalesTargetCount_tNedit.NumEdit.CommaEdit = true;
            //this.SalesTargetCount_tNedit.NumEdit.ZeroSupp = emZeroSupp.zsON;
            //this.SalesTargetCount_tNedit.NumEdit.MinusSupp = true;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            this.InputSalesTargetMoney_tNedit.NumEdit.CommaEdit = true;
            this.InputSalesTargetProfit_tNedit.NumEdit.CommaEdit = true;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //this.InputSalesTargetCount_tNedit.NumEdit.CommaEdit = true;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            for (int index = 0; index < 12; index++)
            {
                this._ratioMonth_tNedit[index].NumEdit.DecLen = 2;
                this._ratioMonth_tNedit[index].NumEdit.ZeroSupp = emZeroSupp.zsON;
                this._ratioMonth_tNedit[index].NumEdit.MinusSupp = true;
            }

            this.SalesTargetMoney_tNedit.ExtEdit.Column = 15;
            this.SalesTargetProfit_tNedit.ExtEdit.Column = 15;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //this.SalesTargetCount_tNedit.ExtEdit.Column = 10;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            this.InputSalesTargetMoney_tNedit.ExtEdit.Column = 15;
            this.InputSalesTargetProfit_tNedit.ExtEdit.Column = 15;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //this.InputSalesTargetCount_tNedit.ExtEdit.Column = 10;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //this.RatioSunday_tNedit.NumEdit.DecLen = 2;
            //this.RatioSunday_tNedit.NumEdit.ZeroSupp = emZeroSupp.zsON;
            //this.RatioSunday_tNedit.NumEdit.MinusSupp = true;
            //this.RatioSunday_tNedit.ExtEdit.Column = 6;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            this.RatioMonth_tNedit.NumEdit.DecLen = 2;
            this.RatioMonth_tNedit.NumEdit.ZeroSupp = emZeroSupp.zsON;
            this.RatioMonth_tNedit.NumEdit.MinusSupp = true;
            this.RatioMonth_tNedit.ExtEdit.Column = 6;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //this.RatioTuesday_tNedit.NumEdit.DecLen = 2;
            //this.RatioTuesday_tNedit.NumEdit.ZeroSupp = emZeroSupp.zsON;
            //this.RatioTuesday_tNedit.NumEdit.MinusSupp = true;
            //this.RatioTuesday_tNedit.ExtEdit.Column = 6;
            //this.RatioWednesday_tNedit.NumEdit.DecLen = 2;
            //this.RatioWednesday_tNedit.NumEdit.ZeroSupp = emZeroSupp.zsON;
            //this.RatioWednesday_tNedit.NumEdit.MinusSupp = true;
            //this.RatioWednesday_tNedit.ExtEdit.Column = 6;
            //this.RatioThursday_tNedit.NumEdit.DecLen = 2;
            //this.RatioThursday_tNedit.NumEdit.ZeroSupp = emZeroSupp.zsON;
            //this.RatioThursday_tNedit.NumEdit.MinusSupp = true;
            //this.RatioThursday_tNedit.ExtEdit.Column = 6;
            //this.RatioFriday_tNedit.NumEdit.DecLen = 2;
            //this.RatioFriday_tNedit.NumEdit.ZeroSupp = emZeroSupp.zsON;
            //this.RatioFriday_tNedit.NumEdit.MinusSupp = true;
            //this.RatioFriday_tNedit.ExtEdit.Column = 6;
            //this.RatioSaturday_tNedit.NumEdit.DecLen = 2;
            //this.RatioSaturday_tNedit.NumEdit.ZeroSupp = emZeroSupp.zsON;
            //this.RatioSaturday_tNedit.NumEdit.MinusSupp = true;
            //this.RatioSaturday_tNedit.ExtEdit.Column = 6;
            //this.RatioHoliday_tNedit.NumEdit.DecLen = 2;
            //this.RatioHoliday_tNedit.NumEdit.ZeroSupp = emZeroSupp.zsON;
            //this.RatioHoliday_tNedit.NumEdit.MinusSupp = true;
            //this.RatioHoliday_tNedit.ExtEdit.Column = 6;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            for (int index = 0; index < 12; index++)
            {
                this._ratioMonth_tNedit[index].ExtEdit.Column = 6;
            }
        }

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// �ڕW�f�[�^��������
		/// </summary>
		/// <remarks>
		/// <br>Note		: �O���b�h�ɕ\������ڕW�f�[�^��ݒ肵�܂��B</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.04.09</br>
		/// </remarks>
		private bool SearchSalesTarget()
		{
			int status;
			ExtrInfo_MAMOK09197EA extrInfo;

            // ���������ݒ�
            GetExtrInfo(out extrInfo);

			status = this._salesTargetAcs.Search(out this._salesTargetList, extrInfo, ConstantManagement.LogicalMode.GetData0);
			switch (status)
			{
				case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
					break;
				default:
					TMsgDisp.Show(this, 						// �e�E�B���h�E�t�H�[��
						emErrorLevel.ERR_LEVEL_STOP,			// �G���[���x��
						this.Name,								// �A�Z���u��ID
						ctPGNM, 			 �@�@				// �v���O��������
						"Search",								// ��������
						TMsgDisp.OPE_GET,						// �I�y���[�V����
						"�ڕW�f�[�^�̓ǂݍ��݂Ɏ��s���܂���", // �\�����郁�b�Z�[�W
						status,									// �X�e�[�^�X�l
						this._salesTargetAcs,					// �G���[�����������I�u�W�F�N�g
						MessageBoxButtons.OK,					// �\������{�^��
						MessageBoxDefaultButton.Button1);		// �����\���{�^��
					return (false);
			}

			this._extrInfo = extrInfo;

			return (true);
		}

        /*----------------------------------------------------------------------------------*/
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        ///// <summary>
        ///// �j���ʔ䗦�\������
        ///// </summary>
        ///// <remarks>
        ///// <br>Note		: �j���ʂ̔䗦����ʂɕ\�����܂��B</br>
        ///// <br>Programmer	: NEPCO</br>
        ///// <br>Date		: 2007.07.12</br>
        ///// </remarks>
        //private void DispRatioDayOfWeek()
        //{
        //    // �䗦�����������܂�
        //    this.RatioSunday_tNedit.Value = RATIO;
        //    this.RatioMonday_tNedit.Value = RATIO;
        //    this.RatioTuesday_tNedit.Value = RATIO;
        //    this.RatioWednesday_tNedit.Value = RATIO;
        //    this.RatioThursday_tNedit.Value = RATIO;
        //    this.RatioFriday_tNedit.Value = RATIO;
        //    this.RatioSaturday_tNedit.Value = RATIO;
        //    this.RatioHoliday_tNedit.Value = RATIO;

        //    foreach (LdgCalcRatioMng ldgCalcRatioMng in this._ldgCalcRatioMngList)
        //    {
        //        if (ldgCalcRatioMng.SectionCode == this._sectionCode)
        //        {
        //            switch (ldgCalcRatioMng.DivisionAtDate)
        //            {
        //                case 0:
        //                    // ���j
        //                    this.RatioSunday_tNedit.Value = ldgCalcRatioMng.Ratio.ToString("F");
        //                    break;
        //                case 1:
        //                    // ���j
        //                    this.RatioMonday_tNedit.Value = ldgCalcRatioMng.Ratio.ToString("F");
        //                    break;
        //                case 2:
        //                    // �Ηj
        //                    this.RatioTuesday_tNedit.Value = ldgCalcRatioMng.Ratio.ToString("F");
        //                    break;
        //                case 3:
        //                    // ���j
        //                    this.RatioWednesday_tNedit.Value = ldgCalcRatioMng.Ratio.ToString("F");
        //                    break;
        //                case 4:
        //                    // �ؗj
        //                    this.RatioThursday_tNedit.Value = ldgCalcRatioMng.Ratio.ToString("F");
        //                    break;
        //                case 5:
        //                    // ���j
        //                    this.RatioFriday_tNedit.Value = ldgCalcRatioMng.Ratio.ToString("F");
        //                    break;
        //                case 6:
        //                    // �y�j
        //                    this.RatioSaturday_tNedit.Value = ldgCalcRatioMng.Ratio.ToString("F");
        //                    break;
        //                case 7:
        //                    // �j�Փ�
        //                    this.RatioHoliday_tNedit.Value = ldgCalcRatioMng.Ratio.ToString("F");
        //                    break;
        //            }
        //        }
        //    }
        //}
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �ڕW�f�[�^��ʕ\������
        /// </summary>
        /// <remarks>
        /// <br>Note		: �ڕW�f�[�^��\�����܂��B</br>
        /// <br>Programmer	: NEPCO</br>
        /// <br>Date		: 2007.04.09</br>
        /// </remarks>
        private void DispScreenSalesTarget()
        {
            // ���������`�F�b�N����
            bool bStatus = CheckSearchCondition();
            if (!bStatus)
            {
                return;
            }

            // �����Ώۊ��Ԃ��擾
            this._targetDateSt = new DateTime(this.ApplyStaMonth_tDateEdit.GetDateYear(), this.ApplyStaMonth_tDateEdit.GetDateMonth(), 1);
            this._targetDateEd = new DateTime(this.ApplyEndMonth_tDateEdit.GetDateYear(), this.ApplyEndMonth_tDateEdit.GetDateMonth(), 1);

            // �ڕW�f�[�^����
            bStatus = SearchSalesTarget();
            if (!bStatus)
            {
                return;
            }

            // �����t���O
            this._searchFlag = true;

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //// �e�j���̔䗦�擾
            //DispRatioDayOfWeek();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            // �䗦�R���g���[���\��
            ShowRatioControl();

            // �O���b�h�쐬
            DispScreen(this._salesTargetList);
            // �O���b�h���C�A�E�g�ݒ�
            SetLayout_SalesTarget_uGrid();

            // ���͍��Z�l�擾
            // ����
            SetInputSalesTarget(ROW_SALESTARGETMONEY);
            this.SalesTargetMoney_tNedit.DataText = this.InputSalesTargetMoney_tNedit.DataText;

            // �e��
            SetInputSalesTarget(ROW_SALESTARGETPROFIT);
            this.SalesTargetProfit_tNedit.DataText = this.InputSalesTargetProfit_tNedit.DataText;

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //// ����
            //SetInputSalesTarget(ROW_SALESTARGETCOUNT);
            //this.SalesTargetCount_tNedit.DataText = InputSalesTargetCount_tNedit.DataText;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            // �R���g���[������
            SetControlEnabled();
            
            // ��T�C�Y��������
            ChangeAutoFitStyle();
        }

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// ��ʏ��N���A����
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�n���h��</param>
		/// <remarks>
		/// <br>Note		: ��ʏ����N���A���܂��B</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.04.09</br>
		/// </remarks>
		private void ClearScreen()
		{
            // �����t���O
            this._searchFlag = false;

            // �R���g���[���T�C�Y�ݒ�
            SetControlSize();

            // Nedit �X�^�C���ݒ�
            SetNeditStyle();

            // �R���g���[������
            SetControlEnabled();

			// ����ڕW�̏�����
			this.SalesTargetMoney_tNedit.DataText = "";
			this.SalesTargetProfit_tNedit.DataText = "";
			// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //this.SalesTargetCount_tNedit.DataText = "";
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

			// ���͍��Z�l�̏�����
            this.InputSalesTargetMoney_tNedit.DataText = "";
            this.InputSalesTargetProfit_tNedit.DataText = "";
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //this.InputSalesTargetCount_tNedit.DataText = "";
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //// �j���ʔ䗦
            //this.RatioSunday_tNedit.Value = "";
            //this.RatioMonday_tNedit.Value = "";
            //this.RatioTuesday_tNedit.Value = "";
            //this.RatioWednesday_tNedit.Value = "";
            //this.RatioThursday_tNedit.Value = "";
            //this.RatioFriday_tNedit.Value = "";
            //this.RatioSaturday_tNedit.Value = "";
            //this.RatioHoliday_tNedit.Value = "";
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

			for (int index = 0; index < 12; index++)
			{
				this._ratioMonth_uLabel[index].Visible = true;
				this._ratioMonth_tNedit[index].Visible = true;
                this._ratioMonth_tNedit[index].Enabled = false;
                this._ratioMonth_uLabel[index].Text = "";
                this._ratioMonth_tNedit[index].DataText = "";
			}

            this._salesTargetList = new List<SalesTarget>();

            this._targetDateSt = DateTime.MinValue;
            this._targetDateEd = DateTime.MinValue;

            // �O���b�h�\��
            DispScreen(this._salesTargetList);
            // �O���b�h���C�A�E�g�ݒ�
            SetLayout_SalesTarget_uGrid();

            // ��T�C�Y��������
            ChangeAutoFitStyle();

        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �R���g���[�����䏈��
        /// </summary>
        /// <remarks>
        /// <br>Note		: �R���g���[���̐�����s���܂��B</br>
        /// <br>Programmer	: NEPCO</br>
        /// <br>Date		: 2007.04.20</br>
        /// </remarks>
        private void SetControlEnabled()
        {
            // ������
            if (this._searchFlag == true)
            {
                this.Search_Button.Enabled = true;
                this.Clear_Button.Enabled = false;
                this.ApplyStaMonth_tDateEdit.Enabled = false;
                this.ApplyEndMonth_tDateEdit.Enabled = false;

                this.SalesTargetMoney_tNedit.Enabled = true;
                this.SalesTargetProfit_tNedit.Enabled = true;
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                //this.SalesTargetCount_tNedit.Enabled = true;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            }
            // �����O
            else
            {
                this.Search_Button.Enabled = true;
                this.Clear_Button.Enabled = true;
                this.ApplyStaMonth_tDateEdit.Enabled = true;
                this.ApplyEndMonth_tDateEdit.Enabled = true;

                this.SalesTargetMoney_tNedit.Enabled = false;
                this.SalesTargetProfit_tNedit.Enabled = false;
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                //this.SalesTargetCount_tNedit.Enabled = false;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            }
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �䗦�R���g���[���\������
        /// </summary>
        /// <remarks>
        /// <br>Note		: �䗦�R���g���[���𓮓I�ɕ\�����܂��B</br>
        /// <br>Programmer	: NEPCO</br>
        /// <br>Date		: 2007.04.20</br>
        /// </remarks>
        private void ShowRatioControl()
        {
            int index = 0;
            // �������Ԃ̔䗦�R���g���[����\�����܂��B
            for (DateTime targetDate = this._targetDateSt; targetDate <= this._targetDateEd; targetDate = targetDate.AddMonths(1))
            {
                this._ratioMonth_uLabel[index].Visible = true;
                this._ratioMonth_tNedit[index].Visible = true;
                this._ratioMonth_tNedit[index].Enabled = true;

                // �ڕW�f�[�^���P���ȏ゠��ꍇ
                if (this._salesTargetList.Count > 0)
                {
                    this._ratioMonth_tNedit[index].Value = "";
                }
                // �ڕW�f�[�^���P�����Ȃ��ꍇ
                else
                {
                    this._ratioMonth_tNedit[index].Value = RATIO;
                }

                this._ratioMonth_uLabel[index].Text = targetDate.Year.ToString() + "/" + targetDate.Month.ToString("00");

                index++;
            }
            // �������Ԃ��Ђƌ��̏ꍇ�A�䗦�R���g���[����ύX�s�ɂ��܂��B
            if (index == 1)
            {
                this._ratioMonth_tNedit[index - 1].Value = RATIO;
                this._ratioMonth_tNedit[index - 1].Enabled = false;
            }
            // �������ԊO�̔䗦�R���g���[�����\���ɂ��܂��B
            for (int i = index; i < 12; i++)
            {
                this._ratioMonth_uLabel[i].Visible = false;
                this._ratioMonth_tNedit[i].Visible = false;
            }
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// ���͍��Z�l�\������
        /// </summary>
        /// <param name="rowIndex">�s�C���f�b�N�X</param>
        /// <remarks>
        /// <br>Note		: ���͍��Z�l���v�Z���A�R���g���[���ɕ\�����܂��B</br>
        /// <br>Programmer	: NEPCO</br>
        /// <br>Date		: 2007.05.08</br>
        /// </remarks>
        private void SetInputSalesTarget(int rowIndex)
        {
            double inputSalesTarget;

            // ����ڕW�i�~�j�̓��͍��Z�l
            if (rowIndex == ROW_SALESTARGETMONEY)
            {
                CalcInputSalesTarget(out inputSalesTarget, rowIndex);
                this.InputSalesTargetMoney_tNedit.DataText = inputSalesTarget.ToString();
            }
            // �e���ڕW�i�~�j�̓��͍��Z�l
            else if (rowIndex == ROW_SALESTARGETPROFIT)
            {
                CalcInputSalesTarget(out inputSalesTarget, rowIndex);
                this.InputSalesTargetProfit_tNedit.DataText = inputSalesTarget.ToString();
            }
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //// ���ʖڕW�i�j�̓��͍��Z�l
            //else if (rowIndex == ROW_SALESTARGETCOUNT)
            //{
            //    CalcInputSalesTarget(out inputSalesTarget, rowIndex);
            //    this.InputSalesTargetCount_tNedit.DataText = inputSalesTarget.ToString();
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// ��T�C�Y������������
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note		: �`�F�b�N�{�b�N�X�̃`�F�b�N��Ԃɂ���ė�T�C�Y�̎��������𐧌䂵�܂��B</br>
        /// <br>Programmer	: NEPCO</br>
        /// <br>Date		: 2007.07.26</br>
        /// </remarks>
        private void ChangeAutoFitStyle()
        {
            string columnName = "";

            if (this.SalesTarget_uGrid.DataSource == null ||
                this._salesTargetList == null ||
                this._salesTargetList.Count <= 0)
            {
                this.SalesTarget_uGrid.DisplayLayout.AutoFitStyle = AutoFitStyle.None;
                return;
            }

            if (this.uceAutoFitCol.Checked)
            {
                this.SalesTarget_uGrid.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns;
            }
            else
            {
                this.SalesTarget_uGrid.DisplayLayout.AutoFitStyle = AutoFitStyle.None;
                // �O���b�h�̌��o���̕��ݒ�
                this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_HEADER].Width = GetCellWidth((int)this.cmbFontSize.Value);

                for (DateTime targetDate = this._targetDateSt; targetDate <= this._targetDateEd; targetDate = targetDate.AddMonths(1))
                {
                    columnName = targetDate.Year.ToString() + targetDate.Month.ToString("00");
                    this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[columnName].Width = WIDTH_SALESTARGET;
                }
            }
        }

        # endregion Private Methods

        # region Control Events

        /*----------------------------------------------------------------------------------*/
		/// <summary>
		/// Form_Load �C�x���g����(MAMOK01110UA)
		/// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
		/// <remarks>
		/// <br>Note		: �t�H�[�����[�h�������s���܂��B</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.03.29</br>
		/// </remarks>
		private void MAMOK01110UA_Load(object sender, EventArgs e)
		{
            // ��ʃX�L���t�@�C���̓Ǎ�(�f�t�H���g�X�L���w��)
            this._controlScreenSkin.LoadSkin();

            // ��ʃX�L���ύX
            this._controlScreenSkin.SettingScreenSkin(this);

			// �R���g���[���z��
			InitRatioMonthControl();

            // ��ʃN���A
            ClearScreen();

            this.ApplyStaMonth_tDateEdit.Focus();

            this.SalesTarget_uGrid.ActiveRow = null;

            // ���񌎐ݒ�
            int year = DateTime.Now.Year;
            DateTime targetDateSt = new DateTime(year, this._companyBiginMonth, 1);
            this.ApplyStaMonth_tDateEdit.SetDateTime(targetDateSt);
            this.ApplyEndMonth_tDateEdit.SetDateTime(targetDateSt.AddMonths(11));

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.23 TOKUNAGA ADD START
            // ���_���擾 ��ʏ�ɃZ�b�g
            this.SectionCode_tNedit.DataText = this._sectionCode.TrimEnd();
            this.SectionName_tEdit.DataText = this._sectionName.TrimEnd();

            // ���_�R�[�h�K�C�h�{�^��
            this.SectionCodeGuide_ultraButton.Appearance.Image = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.23 TOKUNAGA ADD END

            // XML�f�[�^�Ǎ�
            LoadStateXmlData();

            // ���C���t���[���Ƀc�[���o�[�ݒ�ʒm
            if (ParentToolbarSettingEvent != null) this.ParentToolbarSettingEvent(this);
        }

        /// <summary>
        /// ��ʃA�N�e�B�u�C�x���g
        /// </summary>
        /// <param name="sender">�C�x���g�I�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : ��ʂ��A�N�e�B�u�ɂȂ����Ƃ��̃C�x���g�����ł��B</br>
        /// <br>Programer  : NEPCO</br>
        /// <br>Date       : 2007.05.08</br>
        /// </remarks>
        private void MAMOK01110UA_Activated(object sender, EventArgs e)
        {
            // ���C���t���[���Ƀc�[���o�[�ݒ�ʒm
            if (ParentToolbarSettingEvent != null) this.ParentToolbarSettingEvent(this);
        }

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// Button_Click �C�x���g����(Search_Button)
		/// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
		/// <remarks>
		/// <br>Note		: �����{�^�����N���b�N���ꂽ���ɔ������܂��B</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.03.29</br>
		/// </remarks>
		private void Search_Button_Click(object sender, EventArgs e)
		{
            // �Č����̏ꍇ
            if (this._searchFlag == true)
            {
                string errMsg = "�ҏW���̃f�[�^�͔j������܂����A��낵���ł����H";
                DialogResult res = TMsgDisp.Show(
                                this, 							// �e�E�B���h�E�t�H�[��
                                emErrorLevel.ERR_LEVEL_INFO, 	// �G���[���x��
                                this.Name,						// �A�Z���u��ID
                                errMsg, 						// �\�����郁�b�Z�[�W
                                0,								// �X�e�[�^�X�l
                                MessageBoxButtons.OKCancel);	// �\������{�^��
                switch (res)
                {
                    case DialogResult.OK:
                        break;
                    case DialogResult.Cancel:
                        return;
                }
            }

            // �ڕW�f�[�^��ʕ\������
            DispScreenSalesTarget();
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// Button_Click �C�x���g����(Clear_Button)
		/// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
		/// <remarks>
		/// <br>Note		: �N���A�{�^�����N���b�N���ꂽ���ɔ������܂��B</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.04.09</br>
		/// </remarks>
		private void Clear_Button_Click(object sender, EventArgs e)
		{
            this.ApplyStaMonth_tDateEdit.SetDateTime(new DateTime());
            this.ApplyEndMonth_tDateEdit.SetDateTime(new DateTime());
		}

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// Leave �C�x���g(ApplyStaMonth_tDateEdit)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note		: �R���g���[������t�H�[�J�X�����ꂽ���ɔ������܂��B</br>
        /// <br>Programmer	: NEPCO</br>
        /// <br>Date		: 2007.04.17</br>
        /// </remarks>
        private void ApplyStaMonth_tDateEdit_Leave(object sender, EventArgs e)
        {
            if (this.ApplyStaMonth_tDateEdit.GetDateYear() == 0 ||
                this.ApplyStaMonth_tDateEdit.GetDateMonth() == 0)
            {
                return;
            }

            // ���͓��t�`�F�b�N
            bool bStatus = CheckInputDate(this.ApplyStaMonth_tDateEdit);
            if (!bStatus)
            {
                return;
            }

            this.ApplyStaMonth_tDateEdit.SetDateTime(new DateTime(ApplyStaMonth_tDateEdit.GetDateYear(), ApplyStaMonth_tDateEdit.GetDateMonth(), 1));
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// Leave �C�x���g(ApplyEndMonth_tDateEdit)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note		: �R���g���[������t�H�[�J�X�����ꂽ���ɔ������܂��B</br>
        /// <br>Programmer	: NEPCO</br>
        /// <br>Date		: 2007.04.17</br>
        /// </remarks>
        private void ApplyEndMonth_tDateEdit_Leave(object sender, EventArgs e)
        {
            if (this.ApplyEndMonth_tDateEdit.GetDateYear() == 0 ||
                this.ApplyEndMonth_tDateEdit.GetDateMonth() == 0)
            {
                return;
            }

            // ���͓��t�`�F�b�N
            bool bStatus = CheckInputDate(this.ApplyEndMonth_tDateEdit);
            if (!bStatus)
            {
                return;
            }

            this.ApplyEndMonth_tDateEdit.SetDateTime(new DateTime(ApplyEndMonth_tDateEdit.GetDateYear(), ApplyEndMonth_tDateEdit.GetDateMonth(), 1));
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// Leave �C�x���g(SalesTarget_uGrid)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note		: �R���g���[������t�H�[�J�X�����ꂽ���ɔ������܂��B</br>
        /// <br>Programmer	: NEPCO</br>
        /// <br>Date		: 2007.04.17</br>
        /// </remarks>
        private void SalesTarget_uGrid_Leave(object sender, EventArgs e)
        {
            if (this._closing)
            {
                return;
            }

            this.SalesTarget_uGrid.ActiveCell = null;
        }

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// �Z���ҏW�O�C�x���g
		/// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
		/// <remarks>
		/// <br>Note		: �Z�����ҏW���[�h�ɂȂ������ɔ������܂��B</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.03.30</br>
		/// </remarks>
		private void SalesTarget_uGrid_AfterEnterEditMode(object sender, EventArgs e)
		{
            // �ҏW����s���擾
            this._editRowIndex = this.SalesTarget_uGrid.ActiveRow.Index;
            this._editColumnIndex = this.SalesTarget_uGrid.ActiveCell.Column.Index;

            if (this.SalesTarget_uGrid.Rows[this._editRowIndex].Cells[this._editColumnIndex].Text == "")
            {
                return;
            }
            double salesTarget = double.Parse(this.SalesTarget_uGrid.Rows[this._editRowIndex].Cells[this._editColumnIndex].Text);
            //string targetText = this.SalesTarget_uGrid.Rows[this._editRowIndex].Cells[this._editColumnIndex].Text;
            string targetText = salesTarget.ToString(FORMAT_NUM);
            string retText;

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //if (this._editRowIndex <= ROW_SALESTARGETCOUNT)
            if ( this._editRowIndex <= ROW_SALESTARGETPROFIT )
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            {
                // �J���}�폜����
                RemoveComma(targetText, out retText);
            }
            else
            {
                retText = targetText;
            }

            this.SalesTarget_uGrid.Rows[this._editRowIndex].Cells[this._editColumnIndex].Value = retText;
            this.SalesTarget_uGrid.Rows[this._editRowIndex].Cells[this._editColumnIndex].SelStart = 0;
            this.SalesTarget_uGrid.Rows[this._editRowIndex].Cells[this._editColumnIndex].SelLength = retText.Length;
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// �Z���ҏW�I���O�C�x���g
		/// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
		/// <remarks>
		/// <br>Note		: �Z���̕ҏW���I������O�ɔ������܂��B</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.03.29</br>
		/// </remarks>
		private void SalesTarget_uGrid_BeforeExitEditMode(object sender, BeforeExitEditModeEventArgs e)
		{
            if (this._closing)
            {
                return;
            }

			// ���͒l�����̔��p�������`�F�b�N
            bool status = CheckEditCharacter();
            if (!status)
            {
                e.Cancel = true;
                this._cancelFlag = true;
                return;
            }
            string targetText = this.SalesTarget_uGrid.Rows[this._editRowIndex].Cells[this._editColumnIndex].Text;

            // �e�L�X�g�F�ύX
            SetEditTextColor(targetText, this._editRowIndex, this._editColumnIndex);

            this._cancelFlag = false;
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// �Z���ҏW��C�x���g
		/// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
		/// <remarks>
		/// <br>Note		: �Z���̕ҏW���I��������ɔ������܂��B</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.03.29</br>
		/// </remarks>
		private void SalesTarget_uGrid_AfterExitEditMode(object sender, EventArgs e)
		{
            if (!this._searchFlag)
            {
                return;
            }

            if (this._closing)
            {
                return;
            }

			double inputSalesTarget;

            // ���͍��Z�l�\��
            SetInputSalesTarget(this._editRowIndex);

            // �Z���ɒl������ꍇ
            if (this.SalesTarget_uGrid.Rows[this._editRowIndex].Cells[this._editColumnIndex].Text != "")
            {
                // �Z���l�̏����ϊ�
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                //if (this._editRowIndex < ROW_SALESTARGETCOUNT)
                if ( this._editRowIndex <= ROW_SALESTARGETPROFIT )
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
                {
                    inputSalesTarget = double.Parse(this.SalesTarget_uGrid.Rows[this._editRowIndex].Cells[this._editColumnIndex].Text);
                    this.SalesTarget_uGrid.Rows[this._editRowIndex].Cells[this._editColumnIndex].Value = inputSalesTarget.ToString(FORMAT_NUM);
                }
                else
                {
                    inputSalesTarget = double.Parse(this.SalesTarget_uGrid.Rows[this._editRowIndex].Cells[this._editColumnIndex].Text);
                    //this.SalesTarget_uGrid.Rows[this._editRowIndex].Cells[this._editColumnIndex].Value = inputSalesTarget.ToString(FORMAT_NUM);
                    if (inputSalesTarget == 0)
                    {
                        this.SalesTarget_uGrid.Rows[this._editRowIndex].Cells[this._editColumnIndex].Value = inputSalesTarget.ToString(FORMAT_NUM);
                    }
                    else
                    {
                        this.SalesTarget_uGrid.Rows[this._editRowIndex].Cells[this._editColumnIndex].Value = inputSalesTarget.ToString(FORMAT_NUM_DECIMAL);
                    }
                }
            }

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //// �Z���̒l�����������ꍇ
            //if (this.SalesTarget_uGrid.Rows[this._editRowIndex].Cells[this._editColumnIndex].Text == "")
            //{
            //    // ����
            //    if (this._editRowIndex == ROW_SALESTARGETMONEY)
            //    {
            //        this.SalesTarget_uGrid.Rows[ROW_SALESTARGET_MONEY_SUNDAY].Cells[this._editColumnIndex].Value = "";
            //        this.SalesTarget_uGrid.Rows[ROW_SALESTARGET_MONEY_MONDAY].Cells[this._editColumnIndex].Value = "";
            //        this.SalesTarget_uGrid.Rows[ROW_SALESTARGET_MONEY_TUESDAY].Cells[this._editColumnIndex].Value = "";
            //        this.SalesTarget_uGrid.Rows[ROW_SALESTARGET_MONEY_WEDNESDAY].Cells[this._editColumnIndex].Value = "";
            //        this.SalesTarget_uGrid.Rows[ROW_SALESTARGET_MONEY_THURSDAY].Cells[this._editColumnIndex].Value = "";
            //        this.SalesTarget_uGrid.Rows[ROW_SALESTARGET_MONEY_FRIDAY].Cells[this._editColumnIndex].Value = "";
            //        this.SalesTarget_uGrid.Rows[ROW_SALESTARGET_MONEY_SATURDAY].Cells[this._editColumnIndex].Value = "";
            //        this.SalesTarget_uGrid.Rows[ROW_SALESTARGET_MONEY_HOLIDAY].Cells[this._editColumnIndex].Value = "";
            //    }
            //    // �e��
            //    else if (this._editRowIndex == ROW_SALESTARGETPROFIT)
            //    {
            //        this.SalesTarget_uGrid.Rows[ROW_SALESTARGET_PROFIT_SUNDAY].Cells[this._editColumnIndex].Value = "";
            //        this.SalesTarget_uGrid.Rows[ROW_SALESTARGET_PROFIT_MONDAY].Cells[this._editColumnIndex].Value = "";
            //        this.SalesTarget_uGrid.Rows[ROW_SALESTARGET_PROFIT_TUESWDAY].Cells[this._editColumnIndex].Value = "";
            //        this.SalesTarget_uGrid.Rows[ROW_SALESTARGET_PROFIT_WEDNESDAY].Cells[this._editColumnIndex].Value = "";
            //        this.SalesTarget_uGrid.Rows[ROW_SALESTARGET_PROFIT_THURSDAY].Cells[this._editColumnIndex].Value = "";
            //        this.SalesTarget_uGrid.Rows[ROW_SALESTARGET_PROFIT_FRIDAY].Cells[this._editColumnIndex].Value = "";
            //        this.SalesTarget_uGrid.Rows[ROW_SALESTARGET_PROFIT_SATURDAY].Cells[this._editColumnIndex].Value = "";
            //        this.SalesTarget_uGrid.Rows[ROW_SALESTARGET_PROFIT_HOLIDAY].Cells[this._editColumnIndex].Value = "";
            //    }
            //    // ����
            //    else if (this._editRowIndex == ROW_SALESTARGETCOUNT)
            //    {
            //        this.SalesTarget_uGrid.Rows[ROW_SALESTARGET_COUNT_SUNDAY].Cells[this._editColumnIndex].Value = "";
            //        this.SalesTarget_uGrid.Rows[ROW_SALESTARGET_COUNT_MONDAY].Cells[this._editColumnIndex].Value = "";
            //        this.SalesTarget_uGrid.Rows[ROW_SALESTARGET_COUNT_TUESDAY].Cells[this._editColumnIndex].Value = "";
            //        this.SalesTarget_uGrid.Rows[ROW_SALESTARGET_COUNT_WEDNESDAY].Cells[this._editColumnIndex].Value = "";
            //        this.SalesTarget_uGrid.Rows[ROW_SALESTARGET_COUNT_THURSDAY].Cells[this._editColumnIndex].Value = "";
            //        this.SalesTarget_uGrid.Rows[ROW_SALESTARGET_COUNT_FRIDAY].Cells[this._editColumnIndex].Value = "";
            //        this.SalesTarget_uGrid.Rows[ROW_SALESTARGET_COUNT_SATURDAY].Cells[this._editColumnIndex].Value = "";
            //        this.SalesTarget_uGrid.Rows[ROW_SALESTARGET_COUNT_HOLIDAY].Cells[this._editColumnIndex].Value = "";
            //    }
            //    return;
            //}

            //// �䗦�v�Z
            //CalcFromRatioSalesDay(this._targetDateSt.AddMonths(this._editColumnIndex - 1));
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
        /// ClickCellButton �C�x���g(SalesTarget_uGrid)
		/// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
		/// <remarks>
		/// <br>Note		: �N���A�{�^�����N���b�N�������ɔ������܂��B</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.03.29</br>
		/// </remarks>
		private void SalesTarget_uGrid_ClickCellButton(object sender, Infragistics.Win.UltraWinGrid.CellEventArgs e)
		{
            if (this._cancelFlag)
            {
                return;
            }
            int columnIndex = this.SalesTarget_uGrid.ActiveCell.Column.Index;

            // ��f�[�^�폜�`�F�b�N����
            ClearTargetColumnData(columnIndex);
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// �t�H���g�T�C�Y�ύX�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�n���h��</param>
		/// <remarks>
		/// <br>Note		: �t�H���g�T�C�Y�̒l���ύX���ꂽ��ɔ������܂��B</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.03.30</br>
		/// </remarks>
		private void cmbFontSize_ValueChanged(object sender, EventArgs e)
		{
			// �t�H���g�T�C�Y��ύX
			this.SalesTarget_uGrid.DisplayLayout.Appearance.FontData.SizeInPoints
				= (int)cmbFontSize.Value;

            // �O���b�h�̌��o���̕��ݒ�
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_HEADER].Width = GetCellWidth((int)this.cmbFontSize.Value);
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// ��T�C�Y�̎��������`�F�b�N�`�F���W�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�n���h��</param>
		/// <remarks>
		/// <br>Note		: �`�F�b�N�{�b�N�X�̃`�F�b�N��Ԃ��ύX���ꂽ�^�C�~���O�Ŕ������܂��B</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.03.30</br>
		/// </remarks>
		private void uceAutoFitCol_CheckedChanged(object sender, EventArgs e)
		{
            // ��T�C�Y������������
            ChangeAutoFitStyle();   
        }

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// tArrowKeyControlChangeFocus�C�x���g
		/// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
		/// <remarks>
		/// <br>Note		: �R���g���[���̃t�H�[�J�X���ς��^�C�~���O�Ŕ������܂��B</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.04.05</br>
		/// </remarks>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            int rowCount = this.SalesTarget_uGrid.Rows.Count;
            int columnCount = this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns.Count;

            // Next�t�H�[�J�X���O���b�h�̏ꍇ
            if (e.NextCtrl == this.SalesTarget_uGrid)
            {
                // ������
                if (this._searchFlag == true)
                {
                    if (e.Key == Keys.Down)
                    {
                        e.NextCtrl = null;
                        this.SalesTarget_uGrid.Rows[ROW_SALESTARGETMONEY].Cells[1].Activate();
                        this.SalesTarget_uGrid.PerformAction(UltraGridAction.EnterEditMode, false, false);
                    }
                    else if (e.Key == Keys.Up)
                    {
                        e.NextCtrl = null;
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                        //this.SalesTarget_uGrid.Rows[ROW_SALESTARGETCOUNT].Cells[1].Activate();
                        this.SalesTarget_uGrid.Rows[ROW_SALESTARGETPROFIT].Cells[1].Activate();
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
                        this.SalesTarget_uGrid.PerformAction(UltraGridAction.EnterEditMode, false, false);
                    }
                    else if (e.Key == Keys.Tab || e.Key == Keys.Enter)
                    {
                        e.NextCtrl = null;
                        this.SalesTarget_uGrid.Rows[ROW_SALESTARGETMONEY].Cells[1].Activate();
                        this.SalesTarget_uGrid.PerformAction(UltraGridAction.EnterEditMode, false, false);
                    }
                    return;
                }
                // �����O
                else
                {
                    if (e.Key == Keys.Up)
                    {
                        e.NextCtrl = this.Search_Button;
                    }
                    else if (e.Key == Keys.Down)
                    {
                        e.NextCtrl = this.cmbFontSize;
                    }
                    else if (e.Key == Keys.Tab || e.Key == Keys.Enter)
                    {
                        e.NextCtrl = this.cmbFontSize;
                    }
                }
            }
            if (e.PrevCtrl == this.SalesTarget_uGrid)
            {
                // ���͒l�����̔��p�������`�F�b�N
                bool status = CheckEditCharacter();
                if (!status)
                {
                    e.NextCtrl = null;
                    return;
                }
            }
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// KeyDown �C�x���g(SalesTarget_uGrid)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note		: �J�[�\���{�^�������������ɔ������܂��B</br>
        /// <br>Programmer	: NEPCO</br>
        /// <br>Date		: 2007.05.28</br>
        /// </remarks>
        private void SalesTarget_uGrid_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.SalesTarget_uGrid.Rows.Count < 1)
            {
                return;
            }

            if (this.SalesTarget_uGrid.ActiveCell == null)
            {
                return;
            }

            int rowIndex = this.SalesTarget_uGrid.ActiveRow.Index;
            int rowCount = this.SalesTarget_uGrid.Rows.Count;
            int columnIndex = this.SalesTarget_uGrid.ActiveCell.Column.Index;
            int columnCount = this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns.Count;

            if (e.KeyCode == Keys.Up)
            {
                if (rowIndex == ROW_CLEAR)
                {
                    this.RatioMonth_tNedit.Focus();
                }
                else if (rowIndex > ROW_CLEAR && rowIndex <= ROW_SALESTARGETMONEY)
                {
                    this.SalesTarget_uGrid.Rows[ROW_CLEAR].Cells[columnIndex].Activate();
                    e.Handled = true;
                    return;
                }
                else if (rowIndex > ROW_SALESTARGETMONEY)
                {
                    this.SalesTarget_uGrid.Rows[rowIndex - 1].Cells[columnIndex].Activate();
                    this.SalesTarget_uGrid.PerformAction(UltraGridAction.EnterEditMode, true, false);
                    e.Handled = true;
                    return;
                }
            }
            else if (e.KeyCode == Keys.Down)
            {
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                //if (rowIndex != ROW_SALESTARGETCOUNT)
                if ( rowIndex != ROW_SALESTARGETPROFIT )
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
                {
                    if (rowIndex == ROW_CLEAR)
                    {
                        this.SalesTarget_uGrid.Rows[rowIndex + 2].Cells[columnIndex].Activate();
                    }
                    else
                    {
                        this.SalesTarget_uGrid.Rows[rowIndex + 1].Cells[columnIndex].Activate();
                    }
                    this.SalesTarget_uGrid.PerformAction(UltraGridAction.EnterEditMode, true, false);
                    e.Handled = true;
                    return;
                }
                else
                {
                    this.cmbFontSize.Focus();
                }
            }
            else if (e.KeyCode == Keys.Right)
            {
                if (columnIndex + 1 != columnCount)
                {
                    this.SalesTarget_uGrid.Rows[rowIndex].Cells[columnIndex + 1].Activate();
                    this.SalesTarget_uGrid.PerformAction(UltraGridAction.EnterEditMode, true, false);
                    e.Handled = true;
                    return;
                }
                else
                {
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                    //if (rowIndex != ROW_SALESTARGETCOUNT)
                    if ( rowIndex != ROW_SALESTARGETPROFIT )
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
                    {
                        if (rowIndex == ROW_CLEAR)
                        {
                            this.SalesTarget_uGrid.Rows[rowIndex + 2].Cells[1].Activate();
                        }
                        else
                        {
                            this.SalesTarget_uGrid.Rows[rowIndex + 1].Cells[1].Activate();
                        }
                        
                        this.SalesTarget_uGrid.PerformAction(UltraGridAction.EnterEditMode, true, false);
                        e.Handled = true;
                        return;
                    }
                    else
                    {
                        this.cmbFontSize.Focus();
                    }
                }
            }
            else if (e.KeyCode == Keys.Left)
            {
                if (columnIndex != 1)
                {
                    this.SalesTarget_uGrid.Rows[rowIndex].Cells[columnIndex - 1].Activate();
                    this.SalesTarget_uGrid.PerformAction(UltraGridAction.EnterEditMode, true, false);
                    e.Handled = true;
                    return;
                }
                else
                {
                    if (rowIndex == ROW_CLEAR)
                    {
                        this.RatioMonth_tNedit.Focus();
                    }
                    else if (rowIndex > ROW_CLEAR && rowIndex <= ROW_SALESTARGETMONEY)
                    {
                        this.SalesTarget_uGrid.Rows[ROW_CLEAR].Cells[columnCount - 1].Activate();
                        e.Handled = true;
                        return;
                    }
                    else if (rowIndex > ROW_SALESTARGETMONEY)
                    {
                        this.SalesTarget_uGrid.Rows[rowIndex - 1].Cells[columnCount - 1].Activate();
                        this.SalesTarget_uGrid.PerformAction(UltraGridAction.EnterEditMode, true, false);
                        e.Handled = true;
                        return;
                    }
                }
            }
            else if (e.KeyCode == Keys.Space)
            {
                if (rowIndex == ROW_CLEAR)
                {
                    // ��f�[�^�폜�`�F�b�N����
                    ClearTargetColumnData(columnIndex);
                }
            }
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// KeyPress �C�x���g(SalesTarget_uGrid)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note		: �L�[�������ꂽ���ɔ������܂��B</br>
        /// <br>Programmer	: NEPCO</br>
        /// <br>Date		: 2007.06.19</br>
        /// </remarks>
        private void SalesTarget_uGrid_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (this.SalesTarget_uGrid.ActiveCell == null)
            {
                return;
            }

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //if (!this.Main_ultraExplorerBar.Groups[4].Expanded)
            if ( !this.Main_ultraExplorerBar.Groups[this.Main_ultraExplorerBar.Groups.Count-1].Expanded )
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            {
                return;
            }

            int activeRowIndex = this.SalesTarget_uGrid.ActiveRow.Index;

            if (activeRowIndex == ROW_DATE)
            {
                return;
            }
            
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //if (activeRowIndex > ROW_SALESTARGETCOUNT)
            if ( activeRowIndex > ROW_SALESTARGETPROFIT )
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            {
                return;
            }

            string targetText = this.SalesTarget_uGrid.ActiveCell.Text;

            // �uBackspace�v�L�[�������ꂽ��
            if ((byte)e.KeyChar == (byte)'\b')
            {
                return;
            }
            string retText;
            switch (activeRowIndex)
            {
                case ROW_CLEAR:
                    //if ((byte)e.KeyChar != (byte)' ')
                    //{
                    //    e.KeyChar = '\0';
                    //}
                    break;
                // �ڕW���z
                case ROW_SALESTARGETMONEY:
                case ROW_SALESTARGETPROFIT:
                    this.SalesTarget_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                    // �Z���̃e�L�X�g���I������Ă���ꍇ
                    if (this.SalesTarget_uGrid.ActiveCell.SelText == targetText)
                    {
                        // ���l�̂ݓ��͉�
                        if ((byte)e.KeyChar < (byte)'0' || (byte)'9' < (byte)e.KeyChar)
                        {
                            e.KeyChar = '\0';
                        }
                    }
                    else
                    {
                        RemoveComma(targetText, out retText);
                        // ���������P�Q��������������͕s��
                        if (retText.Length == 12)
                        {
                            e.KeyChar = '\0';
                        }
                        else
                        {
                            // ���l�ȊO�̎�
                            if ((byte)e.KeyChar < (byte)'0' || (byte)'9' < (byte)e.KeyChar)
                            {
                                // ���͒l��1�����ڂ́u,�v�s��
                                if (targetText == "")
                                {
                                    e.KeyChar = '\0';
                                }
                                else
                                {
                                    // �u,�v�͓��͉�
                                    if ((byte)e.KeyChar != ',')
                                    {
                                        e.KeyChar = '\0';
                                    }
                                }
                            }
                        }
                    }
                    break;
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                //case ROW_SALESTARGETCOUNT:
                //    this.SalesTarget_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                //    // �Z���̃e�L�X�g���I������Ă���ꍇ
                //    if (this.SalesTarget_uGrid.ActiveCell.SelText == targetText)
                //    {
                //        // ���l�̂ݓ��͉�
                //        if ((byte)e.KeyChar < (byte)'0' || (byte)'9' < (byte)e.KeyChar)
                //        {
                //            e.KeyChar = '\0';
                //        }
                //    }
                //    else
                //    {
                //        RemoveComma(targetText, out retText);
                //        // ���������X��������������͕s��
                //        if (retText.Length == 9)
                //        {
                //            e.KeyChar = '\0';
                //        }
                //        else
                //        {
                //            // ���l�ȊO�̎�
                //            if ((byte)e.KeyChar < (byte)'0' || (byte)'9' < (byte)e.KeyChar)
                //            {
                //                // ���͒l��1�����ڂ́u,�v�s��
                //                if (targetText == "")
                //                {
                //                    e.KeyChar = '\0';
                //                }
                //                else
                //                {
                //                    // �u,�v�͓��͉�
                //                    if ((byte)e.KeyChar != ',')
                //                    {
                //                        e.KeyChar = '\0';
                //                    }
                //                }
                //            }
                //        }
                //    }
                //    break;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            }
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// GroupClick �C�x���g(Main_ultraExplorerBar)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note		: ExplorerBar�̃w�b�_�[���N���b�N���ꂽ���ɔ������܂��B</br>
        /// <br>Programmer	: NEPCO</br>
        /// <br>Date		: 2007.07.12</br>
        /// </remarks>
        private void Main_ultraExplorerBar_GroupClick(object sender, Infragistics.Win.UltraWinExplorerBar.GroupEventArgs e)
        {
            UltraExplorerBar explorerBar = (UltraExplorerBar)sender;

            // �����݂̃N���C�A���g�T�C�Y
            int clientHeight = explorerBar.ClientSize.Height;
            // �w�b�_�[�̍������v
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //int headerHeight = 165;
            int headerHeight = 33 * explorerBar.Groups.Count;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            int height = 0;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //for (int index = 0; index < 4; index++)
            for ( int index = 0; index < (explorerBar.Groups.Count) -1; index++ )
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            {
                if (explorerBar.Groups[index].Expanded)
                {
                    height += explorerBar.Groups[index].Settings.ContainerHeight;
                }
                else
                {
                    height -= 3;
                }
            }

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            int containerHeight = clientHeight - headerHeight - height;
            if ( containerHeight < 0 ) {
                containerHeight = 0;
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            // �O���b�h�̃O���[�v�̃T�C�Y�𓮓I�ɕύX���܂�
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //explorerBar.Groups[4].Settings.ContainerHeight = clientHeight - headerHeight - height;
            explorerBar.Groups[explorerBar.Groups.Count - 1].Settings.ContainerHeight = containerHeight;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki



        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// ClientSizeChanged �C�x���g(Main_ultraExplorerBar)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note		: ExplorerBar�̃N���C���g�T�C�Y���ύX���ꂽ���ɔ������܂��B</br>
        /// <br>Programmer	: NEPCO</br>
        /// <br>Date		: 2007.07.13</br>
        /// </remarks>
        private void Main_ultraExplorerBar_ClientSizeChanged(object sender, EventArgs e)
        {
            
            UltraExplorerBar explorerBar = (UltraExplorerBar)sender;

            // �����݂̃N���C�A���g�T�C�Y
            int clientHeight = explorerBar.ClientSize.Height;

            // �w�b�_�[�̍������v
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //int headerHeight = 165;
            int headerHeight = 33 * explorerBar.Groups.Count;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            int height = 0;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //for (int index = 0; index < 4; index++)
            for ( int index = 0; index < (explorerBar.Groups.Count) - 1; index++ )
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            {
                if (this.Main_ultraExplorerBar.Groups[index].Expanded)
                {
                    height += this.Main_ultraExplorerBar.Groups[index].Settings.ContainerHeight;
                }
                else
                {
                    height -= 3;
                }
            }

            int containerHeight = clientHeight - headerHeight - height;
            if (containerHeight < 0) {
                containerHeight = 0;
            }

            // �O���b�h�̃O���[�v�̃T�C�Y�𓮓I�ɕύX���܂�
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //explorerBar.Groups[4].Settings.ContainerHeight = containerHeight;
            explorerBar.Groups[explorerBar.Groups.Count-1].Settings.ContainerHeight = containerHeight;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
        }


        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.23 TOKUNAGA ADD START

        /// <summary>
        /// ���_�R�[�h���͗�Leave����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note		: ���_�R�[�h���͗���Leave�������ɔ������܂��B</br>
        /// <br>Programmer	: ���i �r��</br>
        /// <br>Date		: 2008.07.03</br>
        /// </remarks>
        private void SectionCode_tNedit_Leave(object sender, EventArgs e)
        {
            string sectionCode = this.SectionCode_tNedit.Text;

            if (!String.IsNullOrEmpty(sectionCode))
            {
                SecInfoSet sectionInfo;
                int status = this._secInfoSetAcs.Read(out sectionInfo, this._enterpriseCode, sectionCode);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    this.SectionName_tEdit.DataText = sectionInfo.SectionGuideNm.TrimEnd();

                    // ���ʕϐ��ɕۑ�
                    this._sectionCode = sectionInfo.SectionCode.TrimEnd();
                    this._sectionName = sectionInfo.SectionGuideNm.TrimEnd();

                }
            }
        }

        /// <summary>
        /// ���_�K�C�h�{�^���N���b�N����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note		: ���_�K�C�h�{�^�����N���b�N���ꂽ���ɔ������܂��B</br>
        /// <br>Programmer	: ���i �r��</br>
        /// <br>Date		: 2008.07.03</br>
        /// </remarks>
        private void SectionCodeGuide_ultraButton_Click(object sender, EventArgs e)
        {
            SecInfoSet sectionInfo;
            int status = this._secInfoSetAcs.ExecuteGuid(this._enterpriseCode, false, out sectionInfo);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                this.SectionCode_tNedit.DataText = sectionInfo.SectionCode.TrimEnd();
                this.SectionName_tEdit.DataText = sectionInfo.SectionGuideNm.TrimEnd();

                // ���ʕϐ��ɕۑ�
                this._sectionCode = sectionInfo.SectionCode.TrimEnd();
                this._sectionName = sectionInfo.SectionGuideNm.TrimEnd();
            }
        }

        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.23 TOKUNAGA ADD END

        # endregion Control Events

    }

	/// <summary>
	/// �ڕW�f�[�^��r�N���X
	/// </summary>
	/// <remarks>
	/// <br>Note		: �ڕW�f�[�^�̔�r���s���܂��B</br>
	/// <br>Programmer	: NEPCO</br>
	/// <br>Date		: 2007.01.30</br>
	/// </remarks>
	public class SalesTargetCompApplyStaDate : IComparer<SalesTarget>
	{
		#region IComparer<SalesTarget> �����o

		/// <summary>
		/// �ڕW�f�[�^��r����
		/// </summary>
        /// <param name="x">��r�p�ڕW�f�[�^</param>
        /// <param name="y">��r�p�ڕW�f�[�^</param>
		/// <remarks>
		/// <br>Note		: �ڕW�f�[�^�̓��t�̔�r���s���܂��B</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.03.30</br>
		/// </remarks>
		public int Compare(SalesTarget x, SalesTarget y)
		{
			if (x.ApplyStaDate.Date == y.ApplyStaDate.Date)
			{
				return (0);
			}
			else if (x.ApplyStaDate.Date > y.ApplyStaDate.Date)
			{
				return (1);
			}
			else
			{
				return (-1);
			}
		}

		#endregion
	}
}
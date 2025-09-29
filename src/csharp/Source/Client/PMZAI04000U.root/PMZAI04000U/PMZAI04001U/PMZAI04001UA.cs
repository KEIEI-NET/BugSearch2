//****************************************************************************//
// �V�X�e��         : .NS�V���[�Y
// �v���O��������   : �݌Ɏd���`�[�Ɖ�
// �v���O�����T�v   : �݌Ɏd���`�[�Ɖ�t�H�[���N���X
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ��� ���b
// �� �� ��  2008/09/02  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �Ɠc �M�u
// �C �� ��  2008/11/17  �C�����e : �o�O�C���A�d�l�ύX�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �Ɠc �M�u
// �C �� ��  2009/02/05  �C�����e : �s��Ή�[10681]
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �E �K�j
// �C �� ��  2009/03/12  �C�����e : �s��Ή�[12294]
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ��� �r��
// �C �� ��  2009/04/02  �C�����e : �s��Ή�[13064]
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �Ɠc �M�u
// �C �� ��  2009/04/03  �C�����e : �s��Ή�[12857]
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �Ɠc �M�u
// �C �� ��  2009/04/13  �C�����e : ��� �r��[13113]
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.UIData;
using Broadleaf.Windows.Forms;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// �݌Ɏd���`�[�Ɖ�t�H�[���N���X�i�`�[���j
    /// </summary>
    /// <remarks>
    /// Note       : �݌Ɏd���`�[�̈ꗗ�\�����s���t�H�[���N���X�ł��B<br />
    /// Programmer : 22018 ��� ���b<br />
    /// Date       : 2008.09.02<br />
    /// <br />
    /// Update Note: 2008/11/17 �Ɠc �M�u�@�o�O�C���A�d�l�ύX�Ή�<br />
    /// <br>         2009/02/05 �Ɠc �M�u�@�s��Ή�[10681]</br>
    /// <br>         2009/03/12 �E �K�j�@�s��Ή�[12294]</br>
    /// <br>         2009/04/02 ��� �r���@�s��Ή�[13064]</br>
    /// <br>         2009/04/03 �Ɠc �M�u�@�s��Ή�[12857]</br>
    /// <br>         2009/04/13 ��� �r���@�s��Ή�[13113]</br>
    /// </remarks>
	public partial class PMZAI04001UA : Form
    {
        # region [private�t�B�[���h]
        private StockAdjRefAcs _searchSlipAcs;
        private StockAdjDataSet _dataSet;
        private PMZAI04001UB _inputDetails;
        private StockAdjRefSearchParaWork _paraStockSlipCache_Display;
        private SecInfoSetAcs _secInfoSetAcs;
		private WarehouseAcs _warehouseAcs;
        private MakerAcs _makerAcs;
        private EmployeeAcs _employeeAcs;

        // �����Z�o���W���[��
        private TotalDayCalculator _totalDayCalculator;     //ADD 2008/11/17

        private string _enterpriseCode;             // ��ƃR�[�h
        private string _loginSectionCode;           // �����_�R�[�h
        private bool _optSection;                   // ���_�I�v�V�����L���t���O
        private bool _mainOfficeFunc;               // �{��/���_���f�t���O
        private ImageList _imageList16 = null;									// �C���[�W���X�g
        private Infragistics.Win.UltraWinToolbars.ButtonTool _closeButton;		// �I���{�^��
		private Infragistics.Win.UltraWinToolbars.ButtonTool _decisionButton;	// �m��{�^��
		private Infragistics.Win.UltraWinToolbars.ButtonTool _undoButton;		// ����{�^��
        private Infragistics.Win.UltraWinToolbars.ButtonTool _searchButton;		// �����{�^��
        private ControlScreenSkin _controlScreenSkin;
        private DialogResult _dialogRes = DialogResult.Cancel;
        # endregion

        # region [private const]
        private const string MESSAGE_StartEndError = "�J�n���I���ƂȂ�悤�ݒ肵�Ă��������B";
        private const string MESSAGE_NoInput = "�K�{���͍��ڂł��B";
        private const string MESSAGE_InvalidDate = "�L���ȓ��t�ł͂���܂���B";

        // 2009.01.06 add [9633]
        /// <summary> �S�ЃR�[�h [00] </summary>
        private const string WHOLE_SECTION_CODE = "00";
        /// <summary> �S�Ж��� [�S��] </summary>
        private const string WHOLE_SECTION_NAME = "�S��";
        // 2009.01.06 add [9633]
        # endregion

        # region [public �v���p�e�B]
        /// <summary>
        /// �I��`�[�f�[�^�擾�v���p�e�B
        /// </summary>
        public StockAdjRefSearchRetWork StockAdjRefSearchRetWork
        {
            get { return this._inputDetails._stockAdjRefSearchRetWork; }
        }

        ///// <summary>
        ///// �v���p�e�B
        ///// </summary>
        //public bool TComboEditor_SupplierFormal
        //{
        //    get {return this.tComboEditor_SupplierFormal.Enabled; }
        //    set {this.tComboEditor_SupplierFormal.Enabled = value;}
        //}
        # endregion


        # region [�R���X�g���N�^]
        /// <summary>
        /// �f�t�H���g�R���X�g���N�^
        /// </summary>
        public PMZAI04001UA()
        {
            InitializeComponent();

            // �ϐ�������
            this._searchSlipAcs = StockAdjRefAcs.GetInstance();
            this._dataSet = _searchSlipAcs.DataSet;
            this._imageList16 = IconResourceManagement.ImageList16;
            this._closeButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Close"];
            this._decisionButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Decision"];
            this._undoButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Undo"];
            this._searchButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Search"];
            this._controlScreenSkin = new ControlScreenSkin();

            this._paraStockSlipCache_Display = new StockAdjRefSearchParaWork();
            if ( this._searchSlipAcs.GetParaStockSlipCache() != null )
            {
                this._paraStockSlipCache_Display = this._searchSlipAcs.GetParaStockSlipCache();
            }

            this._inputDetails = new PMZAI04001UB();
            this._inputDetails.StatusBarMessageSetting += new PMZAI04001UB.SettingStatusBarMessageEventHandler( this.SetStatusBarMessage );
            this._searchSlipAcs.StatusBarMessageSetting += new StockAdjRefAcs.SettingStatusBarMessageEventHandler( this.SetStatusBarMessage );
            this._inputDetails.CloseMain += new PMZAI04001UB.CloseMainEventHandler( this.CloseForm );
            this._inputDetails.SetMainDialogResult += new PMZAI04001UB.SetDialogResEventHandler( this.SetDialogRes );
            this._inputDetails.DecisionButtonEnableSet += new PMZAI04001UB.SettingDecisionButtonEnableEventHandler( this.ChangeDecisionButtonEnable );
            this._searchSlipAcs.GetNameList += new StockAdjRefAcs.GetNameListEventHandler( this.GetDisplayNameList );
        }
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        /// <param name="startMovment"></param>
        /// <remarks>
        /// <br>�Ɖ�EXE����P�ƋN������ꍇ�͈���=1��^���Đ��䂵�܂��B</br>
        /// </remarks>
        public PMZAI04001UA( int startMovment )
            : this()
        {
            this._inputDetails.StartMovment = startMovment;
            if ( this._inputDetails.StartMovment == 0 )
            {
                //------------------------------------------------
                // �G���g������̏Ɖ�Ăяo��
                //------------------------------------------------
                // �`�[�敪���G���g���u���͕��v�ŌŒ�ɂ���
                tComboEditor_AcPaySlipCd.Value = 13;
                tComboEditor_AcPaySlipCd.Enabled = false;
            }
            else
            {
                //------------------------------------------------
                // startMovment=1 �͏Ɖ�EXE����̋N��(�I���@�\�Ȃ�)
                //------------------------------------------------
                // �m��{�^�����B��
                ChangeDecisionButtonEnable( false );
                ChangeDecisionButtonVisible( false );
            }
        }
        # endregion


        # region [����������]
        /// <summary>
        /// ��ʏ������ݒ菈��
        /// </summary>
        private void SetInitialInput()
        {
            StockAdjDataSet.StockAdjustDataTable stockDatail = this._searchSlipAcs.GetStockSlipTableCache();

            // �����Z�o���W���[��
            _totalDayCalculator = TotalDayCalculator.GetInstance();         //ADD 2008/11/17

            // ���_���\���ؑ�
            if (this._optSection == false)
            {
                // ���_�I�v�V��������
                ChangeSectionDisplay(false,false);
            }
            else
            {
                if (this._mainOfficeFunc == false)
                {
                    // ���_�ݒ�
                    ChangeSectionDisplay(true, false);
                }
                else
                {
                    // �{�Аݒ�
                    ChangeSectionDisplay(true, true);
                }
            }

            // �O�񌟍����L�����f
            if ((stockDatail == null) ||
                (stockDatail.Count == 0))
            {
                // �O���b�h���N���A
                this._searchSlipAcs.ClearStockAdjustDataTable();

                // �w�b�_���N���A����
                this.ClearDisplayHeader();

                // �w�b�_�����\������
                this.SetDisplayHeaderInfo();
            }
            else
            {
                // �O��N���w�b�_���ݒ菈��
                this.SetPrevHeader();

                // �O���b�h�ɏ����t�H�[�J�X��ݒ�
                this._inputDetails.timer_GridSetFocus.Enabled = true;
            }
        }
		
        /// <summary>
        /// ��ʃw�b�_�N���A����
        /// </summary>
        private void ClearDisplayHeader()
        {
            // ���_
            this.tEdit_SectionCode.Text = string.Empty;
            this.uLabel_SectionName.Text = string.Empty;

            // �q��
            this.tEdit_WarehouseCode.Text = string.Empty;
            this.uLabel_WarehouseName.Text = string.Empty;

            // �󕥌��`�[�敪
            this.tComboEditor_AcPaySlipCd.SelectedIndex = 0;

            // ���͓�
            this.tDateEdit_St_InputDay.Clear();
            this.tDateEdit_Ed_InputDay.Clear();

            // �쐬��
            /* --- DEL 2008/11/17 �����l�ύX -------------------------->>>>>
            this.tDateEdit_St_AdjustDate.SetDateTime( DateTime.Today );
            this.tDateEdit_Ed_AdjustDate.SetDateTime( DateTime.Today );
               --- DEL 2008/11/17 -------------------------------------<<<<< */
            // --- ADD 2008/11/17 ------------------------------------->>>>>
            this.tDateEdit_St_AdjustDate.SetDateTime(this.GetPrevTotalDayNextDay(LoginInfoAcquisition.Employee.BelongSectionCode));
            this.tDateEdit_Ed_AdjustDate.SetDateTime(DateTime.Today);
            // --- ADD 2008/11/17 -------------------------------------<<<<<

            // �`�[�ԍ�
            this.tNedit_SupplierSlipNo_St.Clear();
            this.tNedit_SupplierSlipNo_Ed.Clear();

            // �S����
            this.tEdit_StockAgentCode.Text = string.Empty;
            this.uLabel_StockAgentName.Text = string.Empty;

            // ���[�J�[
            this.tNedit_GoodsMakerCd.Clear();
            this.uLabel_MakerName.Text = string.Empty;

            // �i��
            this.tEdit_GoodsNo.Text = string.Empty;
            // �i��
            this.tEdit_GoodsName.Text = string.Empty;
            // �I��
            this.tEdit_WarehouseShelfNo.Text = string.Empty;


            this.ChangeDecisionButtonEnable( false );
            this.timer_InitialSetFocus.Enabled = true;
        }

        // --- ADD 2008/11/17 -------------------------------------------------------------------------------->>>>>
        /// <summary>
        /// �O�񌎎����������擾
        /// </summary>
        /// <returns></returns>
        private DateTime GetPrevTotalDayNextDay(string sectionCode)
        {
            DateTime prevTotalDay;
            int status = _totalDayCalculator.GetHisTotalDayMonthlyAccRec(sectionCode.Trim(), out prevTotalDay);

            // �擾�����s���ȏꍇ�͂R�����O���Z�b�g
            if (status != 0 || prevTotalDay == DateTime.MinValue || prevTotalDay > DateTime.Today)
            {
                prevTotalDay = DateTime.Today.AddMonths(-3);
            }
            // �����擾
            prevTotalDay = prevTotalDay.AddDays(1);

            return prevTotalDay;
        }
        // --- ADD 2008/11/17 --------------------------------------------------------------------------------<<<<<

        /// <summary>
        /// ��ʃw�b�_�\������
        /// </summary>
        private void SetDisplayHeaderInfo()
        {
            // �R���{�{�b�N�X���ڏ����\��
            this.tComboEditor_AcPaySlipCd.SelectedIndex = 0;

            if ( this._inputDetails.StartMovment == 0 )
            {
                //------------------------------------------------
                // �G���g������̏Ɖ�Ăяo��
                //------------------------------------------------
                // �`�[�敪���G���g���u���͕��v�ŌŒ�ɂ���
                tComboEditor_AcPaySlipCd.Value = 13;
                tComboEditor_AcPaySlipCd.Enabled = false;
            }
            else
            {
                //------------------------------------------------
                // �Ɖ�EXE����̋N��(�I���@�\�Ȃ�)
                //------------------------------------------------
                // �m��{�^�����B��
                ChangeDecisionButtonEnable( false );
                ChangeDecisionButtonVisible( false );
                tComboEditor_AcPaySlipCd.Enabled = true;
            }

            // ���t���ڏ����\��
            this.tDateEdit_St_InputDay.Clear();
            this.tDateEdit_Ed_InputDay.Clear();
            /* --- DEL 2008/11/17 �����l�ύX ------------------------------------------------------------------------------->>>>>
            this.tDateEdit_St_AdjustDate.SetDateTime( DateTime.Today );
			this.tDateEdit_Ed_AdjustDate.SetDateTime( DateTime.Today );
               --- DEL 2008/11/17 ------------------------------------------------------------------------------------------<<<<< */
            // --- ADD 2008/11/17 ------------------------------------------------------------------------------------------>>>>>
            this.tDateEdit_St_AdjustDate.SetDateTime(this.GetPrevTotalDayNextDay(LoginInfoAcquisition.Employee.BelongSectionCode));
            this.tDateEdit_Ed_AdjustDate.SetDateTime(DateTime.Today);
            // --- ADD 2008/11/17 ------------------------------------------------------------------------------------------<<<<<


            // ���_�ݒ�
            this.tEdit_SectionCode.Text = this._loginSectionCode;
            this._paraStockSlipCache_Display.SectionCode = this._loginSectionCode;

            if ( _secInfoSetAcs == null )
            {
                _secInfoSetAcs = new SecInfoSetAcs();
            }

            SecInfoSet secInfoSet;
			int status = this._secInfoSetAcs.Read(out secInfoSet, this._enterpriseCode, this._loginSectionCode);
			if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				this.uLabel_SectionName.Text = secInfoSet.SectionGuideNm;
			}
        }

        /// <summary>
        /// �{�^�������ݒ菈��
        /// </summary>
        private void ButtonInitialSetting()
        {
            this.tToolbarsManager_MainMenu.ImageListSmall = this._imageList16;
            this._closeButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;
            this._decisionButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.DECISION;
            this._undoButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.ALLCANCEL;
            this._searchButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SEARCH;

            this.uButton_SectionGuide.ImageList = this._imageList16;
            this.uButton_WarehouseGuide.ImageList = this._imageList16;
            this.uButton_EmployeeGuide.ImageList = this._imageList16;
            this.uButton_GoodsMakerGuide.ImageList = this._imageList16;

            this.uButton_SectionGuide.Appearance.Image = (int)Size16_Index.STAR1;
            this.uButton_WarehouseGuide.Appearance.Image = (int)Size16_Index.STAR1;
            this.uButton_EmployeeGuide.Appearance.Image = (int)Size16_Index.STAR1;
            this.uButton_GoodsMakerGuide.Appearance.Image = (int)Size16_Index.STAR1;
        }
        /// <summary>
        /// ���_ �\���ؑ֏���
        /// </summary>
        private void ChangeSectionDisplay( bool visible, bool enabled )
        {
            this.uLabel_SectionTitle.Visible = visible;
            this.tEdit_SectionCode.Visible = visible;
            this.uLabel_SectionName.Visible = visible;
            this.uButton_SectionGuide.Visible = visible;

            this.uLabel_SectionTitle.Enabled = enabled;
            this.tEdit_SectionCode.Enabled = enabled;
            this.uLabel_SectionName.Enabled = enabled;
            this.uButton_SectionGuide.Enabled = enabled;
        }

        /// <summary>
        /// �O��N���w�b�_���ݒ菈��
        /// </summary>
        private void SetPrevHeader()
        {
            StockAdjRefSearchParaWork stockAdjRefSearchParaWork = this._searchSlipAcs.GetParaStockSlipCache();

            if(stockAdjRefSearchParaWork == null)
            {
                return;
            }

            SortedList nameList = this._searchSlipAcs.GetCacheNmaeList();

			if (nameList == null)
			{
				return;
			}

            // ���_
            this.tEdit_SectionCode.Text = stockAdjRefSearchParaWork.SectionCode;
            this.uLabel_SectionName.Text = nameList["SectionName"].ToString();
            // �q��
            this.tEdit_WarehouseCode.Text = stockAdjRefSearchParaWork.WarehouseCode;
            this.uLabel_WarehouseName.Text = nameList["WarehouseName"].ToString();
            // �`�[�敪
            this.tComboEditor_AcPaySlipCd.Value = stockAdjRefSearchParaWork.AcPaySlipCd;
            // ���͓�
            this.tDateEdit_St_InputDay.SetLongDate( stockAdjRefSearchParaWork.St_InputDay );
            this.tDateEdit_Ed_InputDay.SetLongDate( stockAdjRefSearchParaWork.Ed_InputDay );
            // �쐬��
            this.tDateEdit_St_AdjustDate.SetLongDate( stockAdjRefSearchParaWork.St_AdjustDate );
            this.tDateEdit_Ed_AdjustDate.SetLongDate( stockAdjRefSearchParaWork.St_AdjustDate );
            // �`�[�ԍ�
            this.tNedit_SupplierSlipNo_St.SetInt( stockAdjRefSearchParaWork.St_StockAdjustSlipNo );
            this.tNedit_SupplierSlipNo_Ed.SetInt( stockAdjRefSearchParaWork.Ed_StockAdjustSlipNo );
            // �S����
            this.tEdit_StockAgentCode.Text = stockAdjRefSearchParaWork.StockAgentCode;
            this.uLabel_StockAgentName.Text = nameList["StockAgentName"].ToString();
            // ���[�J�[
            this.tNedit_GoodsMakerCd.SetInt( stockAdjRefSearchParaWork.GoodsMakerCd );
            this.uLabel_MakerName.Text = nameList["MakerName"].ToString();
            // �i��
            this.tEdit_GoodsNo.Text = GetSearchTextOrigin( stockAdjRefSearchParaWork.GoodsNo, stockAdjRefSearchParaWork.GoodsNoTyp );
            // �i��
            this.tEdit_GoodsName.Text = GetSearchTextOrigin( stockAdjRefSearchParaWork.GoodsName, stockAdjRefSearchParaWork.GoodsNameTyp );
            // �I��
            this.tEdit_WarehouseShelfNo.Text = GetSearchTextOrigin( stockAdjRefSearchParaWork.WarehouseShelfNo, stockAdjRefSearchParaWork.WarehouseShelfNoTyp );
        }

        # endregion

        # region [�ǂݍ��ݏ���]

        /// <summary>
        /// �Ǎ������p�����[�^�ݒ菈��
        /// </summary>
        /// </return> �Ǎ������p�����[�^�N���X
        public void SetReadPara(out StockAdjRefSearchParaWork stockAdjRefSearchParaWork)
        {
            stockAdjRefSearchParaWork = new StockAdjRefSearchParaWork();

			//��ƃR�[�h
            stockAdjRefSearchParaWork.EnterpriseCode = this._enterpriseCode;

            // ���_�R�[�h
            //stockAdjRefSearchParaWork.SectionCode = tEdit_SectionCode.Text;       //DEL 2009/02/05 �s��Ή�[10681]
            // ---ADD 2009/02/05 �s��Ή�[10681] -------------------------------------------------------------->>>>>
            if (tEdit_SectionCode.Text == "00")
            {
                stockAdjRefSearchParaWork.SectionCode = string.Empty;
            }
            else
            {
                stockAdjRefSearchParaWork.SectionCode = tEdit_SectionCode.Text;
            }
            // ---ADD 2009/02/05 �s��Ή�[10681] --------------------------------------------------------------<<<<<

            // �q�ɃR�[�h
            stockAdjRefSearchParaWork.WarehouseCode = tEdit_WarehouseCode.Text;
            
            // �󕥌��`�[�敪
            stockAdjRefSearchParaWork.AcPaySlipCd = (int)tComboEditor_AcPaySlipCd.Value;

            // �󕥌�����敪
            stockAdjRefSearchParaWork.AcPayTransCd = 0; // 0:���w��

            // �J�n���͓��t
            stockAdjRefSearchParaWork.St_InputDay = tDateEdit_St_InputDay.GetLongDate();
            
            // �I�����͓��t
            stockAdjRefSearchParaWork.Ed_InputDay = tDateEdit_Ed_InputDay.GetLongDate();
            
            // �J�n�������t
            stockAdjRefSearchParaWork.St_AdjustDate = tDateEdit_St_AdjustDate.GetLongDate();
            
            // �I���������t
            stockAdjRefSearchParaWork.Ed_AdjustDate = tDateEdit_Ed_AdjustDate.GetLongDate();
            
            // �J�n�݌ɒ����`�[�ԍ�
            stockAdjRefSearchParaWork.St_StockAdjustSlipNo = tNedit_SupplierSlipNo_St.GetInt();
            
            // �I���݌ɒ����`�[�ԍ�
            stockAdjRefSearchParaWork.Ed_StockAdjustSlipNo = tNedit_SupplierSlipNo_Ed.GetInt();
            
            // �d���S���҃R�[�h
            stockAdjRefSearchParaWork.StockAgentCode = tEdit_StockAgentCode.Text;
            
            // ���i���[�J�[�R�[�h
            stockAdjRefSearchParaWork.GoodsMakerCd = tNedit_GoodsMakerCd.GetInt();


            string searchText;
            int searchType;

            // ���i�ԍ��E���i�ԍ������^�C�v
            GetSearchType( tEdit_GoodsNo.Text, out searchText, out searchType );
            stockAdjRefSearchParaWork.GoodsNo = searchText;
            stockAdjRefSearchParaWork.GoodsNoTyp = searchType;

            // ���i���́E���i���̌����^�C�v
            GetSearchType( tEdit_GoodsName.Text, out searchText, out searchType );
            stockAdjRefSearchParaWork.GoodsName = searchText;
            stockAdjRefSearchParaWork.GoodsNameTyp = searchType;

            // �q�ɒI�ԁE�q�ɒI�Ԍ����^�C�v
            GetSearchType( tEdit_WarehouseShelfNo.Text, out searchText, out searchType );
            stockAdjRefSearchParaWork.WarehouseShelfNo = searchText;
            stockAdjRefSearchParaWork.WarehouseShelfNoTyp = searchType;


			this._inputDetails._stockAdjRefSearchParaWork = stockAdjRefSearchParaWork;
			this._inputDetails.DisplayModeSetting();
        }

        /// <summary>
        /// �O��/���񌟍�������r����
        /// </summary>
        /// <param name="">���������N���X(�������)</param>
        /// <returns>true:��v�Afalse:�s��v</returns>
        private bool CheckSearchParam(StockAdjRefSearchParaWork stockAdjRefSearchParaWork)
        {
            // �O�񌟍������̎擾
            StockAdjRefSearchParaWork prevStockAdjRefSearchParaWork = this._searchSlipAcs.GetParaStockSlipCache();
            if (prevStockAdjRefSearchParaWork == null)
            {
                return false;
            }

            // ���_
            if ( stockAdjRefSearchParaWork.SectionCode != prevStockAdjRefSearchParaWork.SectionCode )
            {
                return false;
            }
            // �q��
            if ( stockAdjRefSearchParaWork.WarehouseCode != prevStockAdjRefSearchParaWork.WarehouseCode )
            {
                return false;
            }
            // �`�[�敪
            if ( stockAdjRefSearchParaWork.AcPaySlipCd != prevStockAdjRefSearchParaWork.AcPaySlipCd )
            {
                return false;
            }
            // ���͓�
            if ( stockAdjRefSearchParaWork.St_InputDay != prevStockAdjRefSearchParaWork.St_InputDay )
            {
                return false;
            }
            if ( stockAdjRefSearchParaWork.Ed_InputDay != prevStockAdjRefSearchParaWork.Ed_InputDay )
            {
                return false;
            }
            // �쐬��
            if ( stockAdjRefSearchParaWork.St_AdjustDate != prevStockAdjRefSearchParaWork.St_AdjustDate )
            {
                return false;
            }
            if ( stockAdjRefSearchParaWork.Ed_AdjustDate != prevStockAdjRefSearchParaWork.Ed_AdjustDate )
            {
                return false;
            }
            // �`�[�ԍ�
            if ( stockAdjRefSearchParaWork.St_StockAdjustSlipNo != prevStockAdjRefSearchParaWork.St_StockAdjustSlipNo )
            {
                return false;
            }
            if ( stockAdjRefSearchParaWork.Ed_StockAdjustSlipNo != prevStockAdjRefSearchParaWork.Ed_StockAdjustSlipNo )
            {
                return false;
            }
            // �S����
            if ( stockAdjRefSearchParaWork.StockAgentCode != prevStockAdjRefSearchParaWork.StockAgentCode )
            {
                return false;
            }
            // ���[�J�[
            if ( stockAdjRefSearchParaWork.GoodsMakerCd != prevStockAdjRefSearchParaWork.GoodsMakerCd )
            {
                return false;
            }
            // �i��
            if ( stockAdjRefSearchParaWork.GoodsNo != prevStockAdjRefSearchParaWork.GoodsNo )
            {
                return false;
            }
            if ( stockAdjRefSearchParaWork.GoodsNoTyp != prevStockAdjRefSearchParaWork.GoodsNoTyp )
            {
                return false;
            }
            // �i��
            if ( stockAdjRefSearchParaWork.GoodsName != prevStockAdjRefSearchParaWork.GoodsName )
            {
                return false;
            }
            if ( stockAdjRefSearchParaWork.GoodsNameTyp != prevStockAdjRefSearchParaWork.GoodsNameTyp )
            {
                return false;
            }
            // �I��
            if ( stockAdjRefSearchParaWork.WarehouseShelfNo != prevStockAdjRefSearchParaWork.WarehouseShelfNo )
            {
                return false;
            }
            if ( stockAdjRefSearchParaWork.WarehouseShelfNoTyp != prevStockAdjRefSearchParaWork.WarehouseShelfNoTyp )
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// �I�����ڒl�����ݒ菈��(TDateEdit)
        /// </summary>
        /// <param name="startDate">�J�n���t����TDateEdit</param>
        /// <param name="endDate">�I�����t����TDateEdit</param>
        private void AutoSetEndValue( TDateEdit startDate, TDateEdit endDate )
        {
            // �I���������͂Ȃ�΁A�I�����ɊJ�n���Ɠ����l���Z�b�g����
            if ( endDate.LongDate == 0 )
            {
                endDate.SetLongDate( startDate.LongDate );
            }
        }

        /// <summary>
        /// �����񂠂��܂��������擾
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        private void GetSearchType( string originText, out string searchText, out int searchType )
        {
            searchText = originText;
            bool stLike = originText.StartsWith( "*" );
            bool edLike = originText.EndsWith( "*" );

            if ( stLike )
            {
                // �擪�� * ����菜��
                searchText = searchText.Substring( 1 );
            }
            if ( edLike )
            {
                // ������ * ����菜��
                searchText = searchText.Substring( 0, searchText.Length - 1 );
            }

            // �擪��������*����菜���Ă��܂�*������ꍇ��3:�����܂�
            if ( searchText.Contains( "*" ) )
            {
                searchText = searchText.Replace( "*", "%" );
                searchType = 3;
                return;
            }


            // �����^�C�v�̔���
            if ( stLike )
            {
                if ( edLike )
                {
                    // 3:�����܂�
                    searchType = 3;
                }
                else
                {
                    // 2:�����v
                    searchType = 2;
                }
            }
            else
            {
                if ( edLike )
                {
                    // 1:�O����v
                    searchType = 1;
                }
                else
                {
                    // 0:���S��v
                    searchType = 0;
                }
            }
        }
        /// <summary>
        /// �����e�L�X�g�擾����(���������͂��ꂽ���X�̕�����𕜌�����)
        /// </summary>
        /// <param name="p"></param>
        /// <param name="p_2"></param>
        /// <returns></returns>
        private string GetSearchTextOrigin( string searchText, int searchType )
        {
            switch ( searchType )
            {
                case 0:
                    // ���S��v
                    return string.Format( "{0}", searchText.Trim().Replace( "%", "*" ) );
                case 1:
                    // �O����v
                    return string.Format( "{0}*", searchText.Trim().Replace( "%", "*" ) );
                case 2:
                    // �����v
                    return string.Format( "*{0}", searchText.Trim().Replace( "%", "*" ) );
                case 3:
                default:
                    // �����܂�
                    return string.Format( "*{0}*", searchText.Trim().Replace( "%", "*" ) );
            }
        }

        # endregion

        # region [���̓`�F�b�N]
        /// <summary>
        /// ���͍��ڃ`�F�b�N����
        /// </summary>
        private Control CheckInputPara()
        {
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/09 DEL
            //// ���͓��t
            //if ( !CheckDate( ref tDateEdit_St_InputDay ) )
            //{
            //    SetStatusBarMessage( this, "�J�n���͓����s���ł��B" );
            //    tDateEdit_St_InputDay.Focus();
            //    return tDateEdit_St_InputDay;
            //}
            //if ( !CheckDate( ref tDateEdit_Ed_InputDay ) )
            //{
            //    SetStatusBarMessage( this, "�I�����͓����s���ł��B" );
            //    tDateEdit_Ed_InputDay.Focus();
            //    return tDateEdit_Ed_InputDay;
            //}
            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki m.suzuki 2008/09/30 DEL
            ////if (this.tDateEdit_St_InputDay.LongDate > this.tDateEdit_Ed_InputDay.LongDate)
            //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki m.suzuki 2008/09/30 DEL
            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki m.suzuki 2008/09/30 ADD
            //if ( tDateEdit_St_InputDay.LongDate != 0 &&
            //     tDateEdit_Ed_InputDay.LongDate != 0 &&
            //     (this.tDateEdit_St_InputDay.LongDate > this.tDateEdit_Ed_InputDay.LongDate) )
            //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki m.suzuki 2008/09/30 ADD
            //{
            //    this.tDateEdit_St_InputDay.Focus();
            //    SetStatusBarMessage( this, MESSAGE_StartEndError );
            //    return tDateEdit_St_InputDay;
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/09 DEL

            // --- DEL 2009/04/02 -------------------------------->>>>>
            // �쐬��
            //// �i�R�����͈̓`�F�b�N�j
            //DateGetAcs.CheckDateRangeResult cdrResult;
            //if ( !CheckDateRange( out cdrResult, ref tDateEdit_St_AdjustDate, ref tDateEdit_Ed_AdjustDate ) )
            //{
            //    Control retControl = tDateEdit_St_AdjustDate;
            //    switch ( cdrResult )
            //    {
            //        case DateGetAcs.CheckDateRangeResult.ErrorOfStartInvalid:
            //        case DateGetAcs.CheckDateRangeResult.ErrorOfStartNoInput:
            //            {
            //                // �J�n�s��
            //                retControl = tDateEdit_St_AdjustDate;
            //                //SetStatusBarMessage( this, "�J�n�쐬�����s���ł��B" );        //DEL 2008/11/17 ���b�Z�[�W�{�b�N�X�\��
            //                // --- ADD 2008/11/17 --------------------------------------------------------------------------->>>>>
            //                TMsgDisp.Show(
            //                            this,
            //                            emErrorLevel.ERR_LEVEL_INFO,
            //                            this.Name,
            //                            "�J�n�쐬�����s���ł��B",
            //                            0,
            //                            MessageBoxButtons.OK);
            //                // --- ADD 2008/11/17 ---------------------------------------------------------------------------<<<<<
            //            }
            //            break;
            //        case DateGetAcs.CheckDateRangeResult.ErrorOfEndInvalid:
            //        case DateGetAcs.CheckDateRangeResult.ErrorOfEndNoInput:
            //            {
            //                // �I���s��
            //                retControl = tDateEdit_Ed_AdjustDate;
            //                //SetStatusBarMessage( this, "�I���쐬�����s���ł��B" );        //DEL 2008/11/17 ���b�Z�[�W�{�b�N�X�\��
            //                // --- ADD 2008/11/17 --------------------------------------------------------------------------->>>>>
            //                TMsgDisp.Show(
            //                            this,
            //                            emErrorLevel.ERR_LEVEL_INFO,
            //                            this.Name,
            //                            "�I���쐬�����s���ł��B",
            //                            0,
            //                            MessageBoxButtons.OK);
            //                // --- ADD 2008/11/17 ---------------------------------------------------------------------------<<<<<
            //            }
            //            break;
            //        case DateGetAcs.CheckDateRangeResult.ErrorOfRangeOver:
            //            {
            //                // �͈͊O
            //                retControl = tDateEdit_St_AdjustDate;
            //                //SetStatusBarMessage( this, "�쐬���͂R�����͈͓̔��œ��͂��ĉ������B" );      //DEL 2008/11/17 ���b�Z�[�W�{�b�N�X�\��
            //                // --- ADD 2008/11/17 --------------------------------------------------------------------------->>>>>
            //                TMsgDisp.Show(
            //                            this,
            //                            emErrorLevel.ERR_LEVEL_INFO,
            //                            this.Name,
            //                            "�쐬���͂R�����͈͓̔��œ��͂��ĉ������B",
            //                            0,
            //                            MessageBoxButtons.OK);
            //                // --- ADD 2008/11/17 ---------------------------------------------------------------------------<<<<<
            //            }
            //            break;
            //        case DateGetAcs.CheckDateRangeResult.ErrorOfReverse:
            //            {
            //                // �召�t�]
            //                retControl = tDateEdit_St_AdjustDate;
            //                //SetStatusBarMessage( this, MESSAGE_StartEndError );           //DEL 2008/11/17 ���b�Z�[�W�{�b�N�X�\��
            //                // --- ADD 2008/11/17 --------------------------------------------------------------------------->>>>>
            //                TMsgDisp.Show(
            //                            this,
            //                            emErrorLevel.ERR_LEVEL_INFO,
            //                            this.Name,
            //                            MESSAGE_StartEndError,
            //                            0,
            //                            MessageBoxButtons.OK);
            //                // --- ADD 2008/11/17 ---------------------------------------------------------------------------<<<<<
            //            }
            //            break;
            //    }
            //    retControl.Focus();
            //    return retControl;
            //}
            // --- DEL 2009/04/02 --------------------------------<<<<<
            // --- ADD 2009/04/02 -------------------------------->>>>>
            // �쐬��
            if (!CheckDate(ref tDateEdit_St_AdjustDate))
            {
                TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_INFO,
                            this.Name,
                            //"�J�n�쐬�����s���ł��B",         //DEL 2009/04/03 �s��Ή�[12857]
                            "�J�n�d�������s���ł��B",           //ADD 2009/04/03 �s��Ή�[12857]
                            0,
                            MessageBoxButtons.OK);
                tDateEdit_St_AdjustDate.Focus();
                return tDateEdit_St_AdjustDate;
            }

            if (!CheckDate(ref tDateEdit_Ed_AdjustDate))
            {
                TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_INFO,
                            this.Name,
                            //"�I���쐬�����s���ł��B",         //DEL 2009/04/03 �s��Ή�[12857]
                            "�I���d�������s���ł��B",           //ADD 2009/04/03 �s��Ή�[12857]
                            0,
                            MessageBoxButtons.OK);

                tDateEdit_Ed_AdjustDate.Focus();
                return tDateEdit_Ed_AdjustDate;
            }

            if (tDateEdit_St_AdjustDate.LongDate != 0 &&
                 tDateEdit_Ed_AdjustDate.LongDate != 0 &&
                 (this.tDateEdit_St_AdjustDate.LongDate > this.tDateEdit_Ed_AdjustDate.LongDate))
            {
                this.tDateEdit_St_AdjustDate.Focus();

                TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_INFO,
                            this.Name,
                            MESSAGE_StartEndError,
                            0,
                            MessageBoxButtons.OK);

                return tDateEdit_St_AdjustDate;
            }
            // --- ADD 2009/04/02 --------------------------------<<<<<

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/09 ADD
            // ���͓��t
            if ( !CheckDate( ref tDateEdit_St_InputDay ) )
            {
                //SetStatusBarMessage( this, "�J�n���͓����s���ł��B" );        //DEL 2008/11/17 ���b�Z�[�W�{�b�N�X�\��
                // --- ADD 2008/11/17 --------------------------------------------------------------------------->>>>>
                TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_INFO,
                            this.Name,
                            "�J�n���͓����s���ł��B",
                            0,
                            MessageBoxButtons.OK);
                // --- ADD 2008/11/17 ---------------------------------------------------------------------------<<<<<
                tDateEdit_St_InputDay.Focus();
                return tDateEdit_St_InputDay;
            }
            if ( !CheckDate( ref tDateEdit_Ed_InputDay ) )
            {
                //SetStatusBarMessage( this, "�I�����͓����s���ł��B" );        //DEL 2008/11/17 ���b�Z�[�W�{�b�N�X�\��
                // --- ADD 2008/11/17 --------------------------------------------------------------------------->>>>>
                TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_INFO,
                            this.Name,
                            "�I�����͓����s���ł��B",
                            0,
                            MessageBoxButtons.OK);
                // --- ADD 2008/11/17 ---------------------------------------------------------------------------<<<<<
                tDateEdit_Ed_InputDay.Focus();
                return tDateEdit_Ed_InputDay;
            }
            if ( tDateEdit_St_InputDay.LongDate != 0 &&
                 tDateEdit_Ed_InputDay.LongDate != 0 &&
                 (this.tDateEdit_St_InputDay.LongDate > this.tDateEdit_Ed_InputDay.LongDate) )
            {
                this.tDateEdit_St_InputDay.Focus();
                //SetStatusBarMessage( this, MESSAGE_StartEndError );           //DEL 2008/11/17 ���b�Z�[�W�{�b�N�X�\��
                // --- ADD 2008/11/17 --------------------------------------------------------------------------->>>>>
                TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_INFO,
                            this.Name,
                            MESSAGE_StartEndError,
                            0,
                            MessageBoxButtons.OK);
                // --- ADD 2008/11/17 ---------------------------------------------------------------------------<<<<<
                return tDateEdit_St_InputDay;
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/09 ADD


            // �`�[�ԍ��召�`�F�b�N
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki m.suzuki 2008/09/30 DEL
            //if ( tNedit_SupplierSlipNo_St.GetInt() > tNedit_SupplierSlipNo_Ed.GetInt() )
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki m.suzuki 2008/09/30 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki m.suzuki 2008/09/30 ADD
            if (tNedit_SupplierSlipNo_St.GetInt() > 0 &&
                tNedit_SupplierSlipNo_Ed.GetInt() > 0 &&
                �@tNedit_SupplierSlipNo_St.GetInt() > tNedit_SupplierSlipNo_Ed.GetInt() )
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki m.suzuki 2008/09/30 ADD
            {
                //SetStatusBarMessage( this, MESSAGE_StartEndError );           //DEL 2008/11/17 ���b�Z�[�W�{�b�N�X�\�� 
                // --- ADD 2008/11/17 --------------------------------------------------------------------------->>>>>
                TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_INFO,
                            this.Name,
                            MESSAGE_StartEndError,
                            0,
                            MessageBoxButtons.OK);
                // --- ADD 2008/11/17 ---------------------------------------------------------------------------<<<<<
                tNedit_SupplierSlipNo_St.Focus();
                return tNedit_SupplierSlipNo_St;
            }

            return null;
        }

        /// <summary>
        /// ���t�`�F�b�N�P��
        /// </summary>
        /// <param name="tDateEdit_St_AdjustDate"></param>
        /// <returns></returns>
        private bool CheckDate( ref TDateEdit tDateEdit_St_AdjustDate )
        {
            DateGetAcs dateGetAcs = DateGetAcs.GetInstance();

            DateGetAcs.CheckDateResult result;
            result = dateGetAcs.CheckDate( ref tDateEdit_St_AdjustDate, true );
            return (result == DateGetAcs.CheckDateResult.OK);
        }

        /// <summary>
        /// ���t�R�����͈̓`�F�b�N
        /// </summary>
        /// <param name="cdrResult"></param>
        /// <param name="stDate"></param>
        /// <param name="edDate"></param>
        /// <returns></returns>
        private bool CheckDateRange( out DateGetAcs.CheckDateRangeResult cdrResult, ref TDateEdit stDate, ref TDateEdit edDate )
        {
            DateGetAcs dateGetAcs = DateGetAcs.GetInstance();
            cdrResult = dateGetAcs.CheckDateRange( DateGetAcs.YmdType.YearMonth, 3, ref stDate, ref edDate, false );
            return (cdrResult == DateGetAcs.CheckDateRangeResult.OK);
        }
        # endregion


        # region [����]
        /// <summary>
        /// �`�[�������s����
        /// </summary>
        private Control SearchSlip()
        {
            // ���͍��ڃ`�F�b�N����
            Control control = this.CheckInputPara();
            
			if (control != null)
			{
                return control;
            }

            StockAdjRefSearchParaWork stockAdjRefSearchParaWork = new StockAdjRefSearchParaWork();
            bool setEnable = false;

            // �Ǎ������p�����[�^�N���X�ݒ菈��
            this.SetReadPara(out stockAdjRefSearchParaWork);

			// �`�[���Ǎ��E�f�[�^�Z�b�g�i�[����
			this._searchSlipAcs.SetSearchData(stockAdjRefSearchParaWork);
			
			setEnable = this._inputDetails.SetGridEnable();
            if (setEnable == true)
            {
                // 2009.01.06 add [9675]
                // ���׏��{�^���E�m��{�^����Enable�����Grid��Enter�C�x���g��
                // �s���Ă��邽�߁AGrid�Ƀt�H�[�J�X�������Ă͂����Ȃ�
                if (this._inputDetails.uGrid_Details.Focused)
                {
                    this.uButton_SectionGuide.Focus();
                }
                // 2009.01.06 add [9675]
                this._inputDetails.uGrid_Details.Focus();
                this._inputDetails.timer_GridSetFocus.Enabled = true;
            }
            else
            {
                this._inputDetails.uButton_StockSearch.Enabled = false;
            }

			return null;
        }
        # endregion


        # region �e�R���g���[���C�x���g����

        /// <summary>
        /// �c�[���o�[�{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        private void tToolbarsManager_MainMenu_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                case "ButtonTool_Close":
                    {
                        this.SetDialogRes(DialogResult.Cancel);
                        // �I������
                        this.CloseForm();
                        break;
                    }
                case "ButtonTool_Decision":
                    {
                        // �m�菈��
                        if (_inputDetails.ReturnSelectData())
                        {
                            this.SetDialogRes(DialogResult.OK);
                            this.CloseForm();
                        }
                        break;
                    }
                case "ButtonTool_Undo":
                    {
                        // ���ɖ߂�����
                        // 2009.01.06 add [9676]
                        // ���׃{�^����Enable�����Grid��Leave�C�x���g�ōs����
                        // ���邽�߁A�t�H�[�J�X�𓖂ĂĂ����K�v������
                        if (!this._inputDetails.uGrid_Details.Focused)
                        {
                            this._inputDetails.uGrid_Details.Focus();
                        }
                        // 2009.01.06 add [9676]
                        this.ClearDisplayHeader();
                        this.SetDisplayHeaderInfo();
                        this._searchSlipAcs.ClearStockAdjustDataTable();

                        // �����t�H�[�J�X
                        this.SetInitFocus( this );

                        break;
                    }
                case "ButtonTool_Search":
                    {
                        // ��������
                        SearchSlip();

                        break;
                    }
            }
        }

        /// <summary>
        /// �����{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        private void Search_Button_Click(object sender, EventArgs e)
        {
            SearchSlip();
        }

        /// <summary>
        /// �X�e�[�^�X�o�[���b�Z�[�W�\���C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="message">���b�Z�[�W</param>
        private void SetStatusBarMessage(object sender, string message)
        {
            this.uStatusBar_Main.Panels[0].Text = message;
        }

        # region [�t�H�[���E�C�x���g]
        /// <summary>
        /// �t�H�[�����[�h�E�C�x���g����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load( object sender, EventArgs e )
        {
            // ��ʃX�L���t�@�C���̓Ǎ�(�f�t�H���g�X�L���w��)
            this._controlScreenSkin.LoadSkin();

            // �X�L���ύX���O�ݒ�
            List<string> excCtrlNm = new List<string>();
            excCtrlNm.Add( this.Standard_UGroupBox.Name );
            excCtrlNm.Add( this.Detail_UGroupBox.Name );
            this._controlScreenSkin.SetExceptionCtrl( excCtrlNm );

            // ��ʃX�L���ύX
            this._controlScreenSkin.SettingScreenSkin( this );
            this._controlScreenSkin.SettingScreenSkin( this._inputDetails );

            // PMZAI04001UB ���Apanel_Detail��e�Ƃ����R���g���[���ɂ���
            this.panel_Detail.Controls.Add( this._inputDetails );
            this._inputDetails.Dock = DockStyle.Fill;

            //�@��ƃR�[�h���擾����
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            // �����_�R�[�h���擾����
            this._loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode.TrimEnd();
            // ���_�I�v�V�����L�����擾����
            this._optSection = ((int)LoginInfoAcquisition.SoftwarePurchasedCheckForCompany( ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_SECTION ) > 0);
            // �{��/���_�����擾����
            // 2008.12.25 [9573]
            //this._mainOfficeFunc = this._searchSlipAcs.IsMainOfficeFunc();
            this._mainOfficeFunc = true;
            // 2008.12.25 [9573]

            // �{�^�������ݒ菈��
            this.ButtonInitialSetting();

            // ��ʏ������ݒ菈��
            this.SetInitialInput();

            // ���ɖ߂�����
            this.ClearDisplayHeader();
            this.SetDisplayHeaderInfo();
            this._searchSlipAcs.ClearStockAdjustDataTable();
        }


        /// <summary>
        /// �t�H�[���I���C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        private void PMZAI04001UA_FormClosed(object sender, FormClosedEventArgs e)
        {
            DialogResult = _dialogRes;
        }
        /// <summary>
        /// �t�H�[������\���C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PMZAI04001UA_Shown( object sender, EventArgs e )
        {
            this.SetInitFocus( this );
        }

        # endregion

        # region [ChangeFocus]

        /// <summary>
        /// Enter�L�[�ł̃t�H�[�J�X�ړ��C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        private void tRetKeyControl1_ChangeFocus( object sender, Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e )
        {
            // PMZAI04001UB�̃O���b�h�ł�Enter�L�[���������ŁAPMZAI04001UA��tRetKeyControl�ɐ����D���邽��
            // �C�x���g���������Ȃ��Ȃ錻�ۂ̉����
            if ( e.PrevCtrl == this._inputDetails.uGrid_Details )
            {
                // �O���b�h��ł�Enter�L�[�����ł́A���R���g���[���Ƀt�H�[�J�X���ڂ��Ȃ�
                e.NextCtrl = e.PrevCtrl;
                // �O���b�h�s�I�������^�C�}�[����
                this._inputDetails.timer_SelectRow.Enabled = true;
            }

            if ( e.NextCtrl.Parent == this.panel_Detail )
            {
                Control control = SearchSlip();

                if ( (this._inputDetails.uGrid_Details.Rows.Count > 0) &&
                   (this._inputDetails.uGrid_Details.Enabled == true) )
                {
                    e.NextCtrl = this._inputDetails.uGrid_Details;
                }
                else
                {
                    if ( control == null )
                    {
                        e.NextCtrl = e.PrevCtrl;
                    }
                    else
                    {
                        e.NextCtrl = control;
                    }
                }
            }
        }

        /// <summary>
        /// ���L�[�ł̃t�H�[�J�X�ړ��C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        private void tArrowKeyControl1_ChangeFocus( object sender, Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e )
        {
            if ( e.PrevCtrl == null || e.NextCtrl == null ) return;

            SetStatusBarMessage( this, "" );


            // �t�H�[�J�X���� ============================================ //
            # region [�t�H�[�J�X����]
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //if (
            //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //    //(e.PrevCtrl == this.tEdit_PartySaleSlipNum) ||
            //    //(e.PrevCtrl == this.tComboEditor_StockGoodsCd) ||
            //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            //    (e.PrevCtrl == this.tEdit_SectionCode) ||
            //    (e.PrevCtrl == this.uButton_SectionGuide))
            //{
            //    if (e.Key == Keys.Down)
            //    {
            //        if (Detail_UGroupBox.Expanded == true)
            //        {
            //            e.NextCtrl = this.tNedit_GoodsMakerCd;
            //        }
            //        else
            //        {
            //            e.NextCtrl = this._inputDetails.uGrid_Details; ;
            //        }
            //    }
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //if (((e.PrevCtrl.Parent.Parent == this.Standard_UGroupBox) ||
            //    (e.PrevCtrl.Parent.Parent == this.Detail_UGroupBox) 
            //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //    //|| (e.PrevCtrl.Parent.Parent == this.Select_UGroupBox) 
            //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            //    ) &&
            //    ((e.NextCtrl.Parent == this.panel_Detail) ||
            //     (e.NextCtrl == this._inputDetails.uGrid_Details)))
            //{
            //    Control control = SearchSlip();
            //    if ((this._inputDetails.uGrid_Details.Rows.Count > 0) &&
            //       (this._inputDetails.uGrid_Details.Enabled == true))
            //    {
            //        e.NextCtrl = this._inputDetails.uGrid_Details;
            //    }
            //    else
            //    {
            //        if (control == null)
            //        {
            //            e.NextCtrl = e.PrevCtrl;
            //        }
            //        else
            //        {
            //            e.NextCtrl = control;
            //        }
            //    }
            //}
            //else if (e.PrevCtrl == this._inputDetails.uButton_StockSearch)
            //{
            //    switch (e.Key)
            //    {
            //        case Keys.Up:
            //            {
            //                if (this.Detail_UGroupBox.Expanded == true)
            //                {
            //                    e.NextCtrl = this.tEdit_GoodsName;
            //                }
            //                else
            //                {
            //                    e.NextCtrl = this.SetInitFocus(this);
            //                }

            //                break;
            //            }
            //        case Keys.Left:
            //            {
            //                e.NextCtrl = e.PrevCtrl;

            //                break;
            //            }
            //        case Keys.Right:
            //        case Keys.Return:
            //        case Keys.Tab:
            //            {
            //                e.NextCtrl = this._inputDetails.uGrid_Details;
            //                break;
            //            }
            //    }
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            # endregion

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki m.suzuki 2008/09/30 DEL
            //// ���͎x�� ============================================ //
            //# region [���͎x��]
            //// ���ד�
            //if ( (e.PrevCtrl == this.tDateEdit_St_AdjustDate) ||
            //    (e.PrevCtrl == this.tDateEdit_Ed_AdjustDate) )
            //{
            //    AutoSetEndValue( this.tDateEdit_St_AdjustDate, this.tDateEdit_Ed_AdjustDate );
            //}
            //// �v���
            //if ( (e.PrevCtrl == this.tDateEdit_St_InputDay) ||
            //    (e.PrevCtrl == this.tDateEdit_Ed_InputDay) )
            //{
            //    AutoSetEndValue( this.tDateEdit_St_InputDay, this.tDateEdit_Ed_InputDay );
            //}
            //# endregion
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki m.suzuki 2008/09/30 DEL

            // ���̎擾 ============================================ //
            # region [���̎擾]
            switch ( e.PrevCtrl.Name )
            {
                //-----------------------------------------------------
                // ���_
                //-----------------------------------------------------
                case "tEdit_SectionCode":
                    {
                        # region [���_]

                        bool status;

                        if ( tEdit_SectionCode.Text == _paraStockSlipCache_Display.SectionCode )
                        {
                            status = true;
                        }
                        else
                        {
                            string code;
                            string name;

                            // ���_�ǂݍ���
                            status = ReadSection( tEdit_SectionCode.Text, out code, out name );

                            // �R�[�h�E���̂��X�V
                            tEdit_SectionCode.Text = code.TrimEnd();
                            _paraStockSlipCache_Display.SectionCode = code.TrimEnd();
                            uLabel_SectionName.Text = name;
                        }

                        if ( status == true )
                        {
                            if ( !e.ShiftKey )
                            {
                                // NextCtrl����
                                switch ( e.Key )
                                {
                                    case Keys.Return:
                                    case Keys.Tab:
                                        {
                                            if ( _paraStockSlipCache_Display.SectionCode == string.Empty )
                                            {
                                                e.NextCtrl = this.uButton_SectionGuide;
                                            }
                                            else
                                            {
                                                e.NextCtrl = this.tEdit_WarehouseCode;
                                            }
                                            break;
                                        }
                                }
                            }
                        }
                        else
                        {
                            e.NextCtrl = e.PrevCtrl;
                            TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_INFO,
                                this.Name,
                                "���_�����݂��܂���B",
                                -1,
                                MessageBoxButtons.OK );
                        }
                        # endregion
                    }
                    break;
                //-----------------------------------------------------
                // �q��
                //-----------------------------------------------------
                case "tEdit_WarehouseCode":
                    {
                        # region [�q��]

                        bool status;

                        if ( tEdit_WarehouseCode.Text == _paraStockSlipCache_Display.WarehouseCode )
                        {
                            status = true;
                        }
                        else
                        {
                            string code;
                            string name;

                            // �ǂݍ���
                            status = ReadWarehouse( tEdit_WarehouseCode.Text, out code, out name );

                            // �R�[�h�E���̂��X�V
                            tEdit_WarehouseCode.Text = code.TrimEnd();
                            _paraStockSlipCache_Display.WarehouseCode = code.TrimEnd();
                            uLabel_WarehouseName.Text = name;
                        }

                        if ( status == true )
                        {
                            if ( !e.ShiftKey )
                            {
                                // NextCtrl����
                                switch ( e.Key )
                                {
                                    case Keys.Return:
                                    case Keys.Tab:
                                        {
                                            if ( _paraStockSlipCache_Display.WarehouseCode == string.Empty )
                                            {
                                                e.NextCtrl = this.uButton_WarehouseGuide;
                                            }
                                            else
                                            {
                                                e.NextCtrl = this.tComboEditor_AcPaySlipCd;
                                            }
                                            break;
                                        }
                                }
                            }
                        }
                        else
                        {
                            e.NextCtrl = e.PrevCtrl;
                            TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_INFO,
                                this.Name,
                                "�q�ɂ����݂��܂���B",
                                -1,
                                MessageBoxButtons.OK );
                        }

                        # endregion
                    }
                    break;
                //-----------------------------------------------------
                // �S����
                //-----------------------------------------------------
                case "tEdit_StockAgentCode":
                    {
                        # region [�S����]
                        bool status;

                        if ( tEdit_StockAgentCode.Text == _paraStockSlipCache_Display.StockAgentCode )
                        {
                            status = true;
                        }
                        else
                        {
                            string code;
                            string name;

                            // �ǂݍ���
                            status = ReadEmployee( tEdit_StockAgentCode.Text, out code, out name );

                            // �R�[�h�E���̂��X�V
                            tEdit_StockAgentCode.Text = code.TrimEnd();
                            _paraStockSlipCache_Display.StockAgentCode = code.TrimEnd();
                            uLabel_StockAgentName.Text = name;
                        }

                        if ( status == true )
                        {
                            if ( !e.ShiftKey )
                            {
                                // NextCtrl����
                                switch ( e.Key )
                                {
                                    case Keys.Return:
                                    case Keys.Tab:
                                        {
                                            if ( _paraStockSlipCache_Display.StockAgentCode == string.Empty )
                                            {
                                                e.NextCtrl = this.uButton_EmployeeGuide;
                                            }
                                            else
                                            {
                                                if ( Detail_UGroupBox.Expanded == true )
                                                {
                                                    e.NextCtrl = this.tNedit_GoodsMakerCd;
                                                }
                                                else
                                                {
                                                    e.NextCtrl = this._inputDetails;
                                                }
                                            }
                                            break;
                                        }
                                }
                            }
                        }
                        else
                        {
                            e.NextCtrl = e.PrevCtrl;
                            TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_INFO,
                                this.Name,
                                "�]�ƈ������݂��܂���B",
                                -1,
                                MessageBoxButtons.OK );
                        }
                        # endregion
                    }
                    break;
                //-----------------------------------------------------
                // ���[�J�[
                //-----------------------------------------------------
                case "tNedit_GoodsMakerCd":
                    {
                        # region [���[�J�[]
                        bool status;

                        if ( tNedit_GoodsMakerCd.GetInt() == _paraStockSlipCache_Display.GoodsMakerCd )
                        {
                            status = true;
                        }
                        else
                        {
                            int code;
                            string name;

                            // �ǂݍ���
                            status = ReadGoodsMaker( tNedit_GoodsMakerCd.GetInt(), out code, out name );

                            // �R�[�h�E���̂��X�V
                            tNedit_GoodsMakerCd.SetInt( code );
                            _paraStockSlipCache_Display.GoodsMakerCd = code;
                            uLabel_MakerName.Text = name;
                        }

                        if ( status == true )
                        {
                            if ( !e.ShiftKey )
                            {
                                // NextCtrl����
                                switch ( e.Key )
                                {
                                    case Keys.Return:
                                    case Keys.Tab:
                                        {
                                            if ( _paraStockSlipCache_Display.GoodsMakerCd == 0 )
                                            {
                                                e.NextCtrl = this.uButton_GoodsMakerGuide;
                                            }
                                            else
                                            {
                                                e.NextCtrl = this.tEdit_GoodsNo;
                                            }
                                            break;
                                        }
                                }
                            }
                        }
                        else
                        {
                            e.NextCtrl = e.PrevCtrl;
                            TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_INFO,
                                this.Name,
                                "���[�J�[�����݂��܂���B",
                                -1,
                                MessageBoxButtons.OK );
                        }

                        # endregion
                    }
                    break;
                //-----------------------------------------------------
                // �I��
                //-----------------------------------------------------
                case "tEdit_WarehouseShelfNo":
                    {
                        # region [�t�H�[�J�X����]
                        // �t�H�[�J�X����
                        if ( !e.ShiftKey )
                        {
                            // NextCtrl����
                            switch ( e.Key )
                            {
                                case Keys.Return:
                                case Keys.Tab:
                                    {
                                        // �ړ����Ȃ�
                                        e.NextCtrl = this._inputDetails;
                                        break;
                                    }
                            }
                        }
                        # endregion
                    }
                    break;
            }
            # endregion

            // RetKeyControl�p����
            if ( (e.Key == Keys.Return) ||
                (e.Key == Keys.Tab) )
            {
                // PMZAI04001UB�̃O���b�h�ł�Enter�L�[���������ŁAPMZAI04001UA��tRetKeyControl�ɐ����D���邽��
                // �C�x���g���������Ȃ��Ȃ錻�ۂ̉����
                if ( e.PrevCtrl == this._inputDetails.uGrid_Details )
                {
                    // �O���b�h��ł�Enter�L�[�����ł́A���R���g���[���Ƀt�H�[�J�X���ڂ��Ȃ�
                    e.NextCtrl = e.PrevCtrl;
                    // �O���b�h�s�I�������^�C�}�[����
                    //this._inputDetails.timer_SelectRow.Enabled = true;
                }

                //if (e.PrevCtrl == this.tEdit_PartySaleSlipNum)
                //{
                //    e.NextCtrl = this.tEdit_GoodsCode;
                //}
                else
                    if ( e.NextCtrl.Parent == this.panel_Detail )
                    {
                        Control control = SearchSlip();

                        if ( (this._inputDetails.uGrid_Details.Rows.Count > 0) &&
                           (this._inputDetails.uGrid_Details.Enabled == true) )
                        {
                            e.NextCtrl = this._inputDetails.uGrid_Details;
                        }
                        else
                        {
                            if ( control == null )
                            {
                                e.NextCtrl = e.PrevCtrl;
                            }
                            else
                            {
                                e.NextCtrl = control;
                            }
                        }
                    }
            }
        }

        # region [ChangeFocus����Read����]
        /// <summary>
        /// ���_Read
        /// </summary>
        /// <param name="sectionCode"></param>
        /// <param name="code"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        private bool ReadSection( string sectionCode, out string code, out string name )
        {
            bool result = false;

            // �����͔���
            if ( sectionCode != string.Empty && sectionCode != WHOLE_SECTION_CODE ) // 2009.01.06 add [9693]
            {
                // �ǂݍ���
                if ( _secInfoSetAcs == null )
                {
                    _secInfoSetAcs = new SecInfoSetAcs();
                }
                SecInfoSet secInfoSet;
                int status = _secInfoSetAcs.Read( out secInfoSet, this._enterpriseCode, sectionCode );

                if ( status == 0 && secInfoSet != null )
                {
                    // �Y�����聨�\��
                    code = secInfoSet.SectionCode.TrimEnd();
                    name = secInfoSet.SectionGuideNm;

                    result = true;
                }
                else
                {
                    // �Y���Ȃ����N���A
                    // 2009.01.06 modify [9693]
                    //code = string.Empty;
                    //name = string.Empty;
                    code = WHOLE_SECTION_CODE;
                    name = WHOLE_SECTION_NAME;
                    // 2009.01.06 modify [9693]

                    // �m�f�ɂ���
                    result = false;
                }
            }
            else
            {
                // �����́��N���A
                // 2009.01.06 modify [9633]
                //code = string.Empty;
                //name = string.Empty;
                code = WHOLE_SECTION_CODE;
                name = WHOLE_SECTION_NAME;
                // 2009.01.06 modify [9633]

                result = true;
            }

            return result;
        }
        /// <summary>
        /// �q��Read
        /// </summary>
        /// <param name="p"></param>
        /// <param name="code"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        private bool ReadWarehouse( string warehouseCode, out string code, out string name )
        {
            bool result = false;

            // �����͔���
            if ( warehouseCode != string.Empty )
            {
                // �ǂݍ���
                if ( _warehouseAcs == null )
                {
                    _warehouseAcs = new WarehouseAcs();
                }
                Warehouse warehouse;
                int status = _warehouseAcs.Read( out warehouse, this._enterpriseCode, string.Empty, warehouseCode );

                if ( status == 0 && warehouse != null )
                {
                    // �Y�����聨�\��
                    code = warehouse.WarehouseCode.TrimEnd();
                    name = warehouse.WarehouseName;

                    result = true;
                }
                else
                {
                    // �Y���Ȃ����N���A
                    code = string.Empty;
                    name = string.Empty;

                    // �m�f�ɂ���
                    result = false;
                }
            }
            else
            {
                // �����́��N���A
                code = string.Empty;
                name = string.Empty;

                result = true;
            }

            return result;
        }
        /// <summary>
        /// �]�ƈ�Read
        /// </summary>
        /// <param name="employeeCode"></param>
        /// <param name="code"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        private bool ReadEmployee( string employeeCode, out string code, out string name )
        {
            bool result = false;

            // �����͔���
            if ( employeeCode != string.Empty )
            {
                // �ǂݍ���
                if ( _employeeAcs == null )
                {
                    _employeeAcs = new EmployeeAcs();
                }
                Employee employee;
                int status = _employeeAcs.Read( out employee, this._enterpriseCode, employeeCode );

                if ( status == 0 && employee != null )
                {
                    // �Y�����聨�\��
                    code = employee.EmployeeCode.TrimEnd();
                    name = employee.Name;

                    result = true;
                }
                else
                {
                    // �Y���Ȃ����N���A
                    code = string.Empty;
                    name = string.Empty;

                    // �m�f�ɂ���
                    result = false;
                }
            }
            else
            {
                // �����́��N���A
                code = string.Empty;
                name = string.Empty;

                result = true;
            }

            return result;
        }
        /// <summary>
        /// ���i���[�J�[Read
        /// </summary>
        /// <param name="goodsMakerCd"></param>
        /// <param name="code"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        private bool ReadGoodsMaker( int goodsMakerCd, out int code, out string name )
        {
            bool result = false;

            // �����͔���
            if ( goodsMakerCd != 0 )
            {
                // �ǂݍ���
                if ( _makerAcs == null )
                {
                    _makerAcs = new MakerAcs();
                }
                MakerUMnt maker;
                int status = _makerAcs.Read( out maker, this._enterpriseCode, goodsMakerCd );

                if ( status == 0 && maker != null )
                {
                    // �Y�����聨�\��
                    code = maker.GoodsMakerCd;
                    name = maker.MakerName;

                    result = true;
                }
                else
                {
                    // �Y���Ȃ����N���A
                    code = 0;
                    name = string.Empty;

                    // �m�f�ɂ���
                    result = false;
                }
            }
            else
            {
                // �����́��N���A
                code = 0;
                name = string.Empty;

                result = true;
            }

            return result;
        }
        # endregion

        # endregion

        # region [�K�C�h�{�^���N���b�N]
        /// <summary>
        /// ���_�K�C�h�{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        private void uButton_SectionGuide_Click(object sender, EventArgs e)
        {
            if ( _secInfoSetAcs == null )
            {
                _secInfoSetAcs = new SecInfoSetAcs();
            }
           
            SecInfoSet secInfoSet;
            int status = _secInfoSetAcs.ExecuteGuid( this._enterpriseCode, false, out secInfoSet );

            if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL )
            {
                tEdit_SectionCode.Text = secInfoSet.SectionCode.Trim();
                uLabel_SectionName.Text = secInfoSet.SectionGuideNm.Trim();
                this._paraStockSlipCache_Display.SectionCode = secInfoSet.SectionCode.Trim();

                // �t�H�[�J�X�ړ�
                tEdit_WarehouseCode.Focus();
            }
        }

        /// <summary>
        /// �]�ƈ��K�C�h�{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        private void uButton_EmployeeGuide_Click(object sender, EventArgs e)
        {
            if ( _employeeAcs == null )
            {
                _employeeAcs = new EmployeeAcs();
            }
            
            Employee employee;
            int status = _employeeAcs.ExecuteGuid(this._enterpriseCode, true, out employee);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                tEdit_StockAgentCode.Text = employee.EmployeeCode.Trim();
                uLabel_StockAgentName.Text = employee.Name.Trim();
                this._paraStockSlipCache_Display.StockAgentCode = employee.EmployeeCode.Trim();

                // �t�H�[�J�X�ړ�
                if ( Detail_UGroupBox.Expanded == true )
                {
                    tNedit_GoodsMakerCd.Focus();
                }
                else
                {
                    this._inputDetails.Focus();
                }
            }
        }

		/// <summary>
		/// ���[�J�[�K�C�h�{�^���N���b�N�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^�N���X</param>
		private void uButton_GoodsMakerGuide_Click(object sender, EventArgs e)
		{
            if ( _makerAcs == null )
            {
                _makerAcs = new MakerAcs();
            }
			
			MakerUMnt makerUMnt;
			int status = _makerAcs.ExecuteGuid(this._enterpriseCode, out makerUMnt);

			if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
                tNedit_GoodsMakerCd.SetInt( makerUMnt.GoodsMakerCd );
				uLabel_MakerName.Text = makerUMnt.MakerName.Trim();
				this._paraStockSlipCache_Display.GoodsMakerCd = makerUMnt.GoodsMakerCd;

                // �t�H�[�J�X�ړ�
                tEdit_GoodsNo.Focus();
			}
		}
        /// <summary>
        /// �q�ɃK�C�h�{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        private void uButton_WarehouseGuide_Click( object sender, EventArgs e )
        {
            if ( _warehouseAcs == null )
            {
                _warehouseAcs = new WarehouseAcs();
            }

            Warehouse warehouse;
            int status = _warehouseAcs.ExecuteGuid( out warehouse, this._enterpriseCode, this.tEdit_SectionCode.Text );

            if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL )
            {
                tEdit_WarehouseCode.Text = warehouse.WarehouseCode.TrimEnd();
                uLabel_WarehouseName.Text = warehouse.WarehouseName.TrimEnd();
                this._paraStockSlipCache_Display.WarehouseCode = warehouse.WarehouseCode.TrimEnd();

                // �t�H�[�J�X�ړ�
                tComboEditor_AcPaySlipCd.Focus();
            }
        }
        # endregion

        #region [�I�ԓ��͐���]
        // --- ADD 2009/04/13 -------------------------------->>>>>
        /// <summary>
        /// tEdit_WarehouseShelfNo_KeyPress�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tEdit_WarehouseShelfNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsControl(e.KeyChar))
            {
                string prevStr = this.tEdit_WarehouseShelfNo.Text;
                string resultStr = prevStr.Substring(0, this.tEdit_WarehouseShelfNo.SelectionStart) // �I��O�̕���
                                 + e.KeyChar.ToString() // �I�𕔂����̓L�[�ɒu������镔��
                                 + prevStr.Substring(this.tEdit_WarehouseShelfNo.SelectionStart + this.tEdit_WarehouseShelfNo.SelectionLength,
                                                      this.tEdit_WarehouseShelfNo.Text.Length - (this.tEdit_WarehouseShelfNo.SelectionStart + this.tEdit_WarehouseShelfNo.SelectionLength)); // �I����̕���

                Encoding sjis = Encoding.GetEncoding("Shift_JIS");

                int byteLength = sjis.GetByteCount(resultStr);

                // 8�o�C�g(���p8���A�S�p4��)�܂œ��͉�
                if (byteLength > 8)
                {
                    e.Handled = true;
                    return;
                }
            }
        }
        // --- ADD 2009/04/13 --------------------------------<<<<<
        #endregion

        # endregion


        # region [�m��{�^������]
        /// <summary>
        /// �u�m��v�{�^���L�������ύX����
        /// </summary>
        /// <param name="enable">�\���ݒ�(true:�L���Afalse:����)</param>
        private void ChangeDecisionButtonEnable( bool enabled )
        {
            if ( this._inputDetails.StartMovment != 0 )
            {
                // StartMovment �� 0�ŋN������Ă���ꍇ�́A���false
                enabled = false;
            }
            this._decisionButton.SharedProps.Enabled = enabled;
        }
        /// <summary>
        /// �u�m��v�{�^���\���L���ύX����
        /// </summary>
        /// <param name="visible">�\���ݒ�(true:�L���Afalse:����)</param>
        private void ChangeDecisionButtonVisible( bool visible )
        {
            if ( this._inputDetails.StartMovment != 0 )
            {
                // StartMovment �� 0�ŋN������Ă���ꍇ�́A���false
                visible = false;
            }
            this._decisionButton.SharedProps.Visible = visible;
        }
        # endregion

        # region [���̑��̏���]
        /// <summary>
        /// ��ʖ��̃��X�g�擾����
        /// </summary>
        /// <returns>��ʖ��̒l���X�g</returns>
        private SortedList GetDisplayNameList()
        {
            // �y���ږ����\���̒l�z���擾����SortedList (�A�N�Z�X�N���X�ɓn��)
            SortedList nameList = new SortedList();

            nameList.Add( "SectionName", this.uLabel_SectionName.Text );
            nameList.Add( "WarehouseName", this.uLabel_WarehouseName.Text );
            nameList.Add( "MakerName", this.uLabel_MakerName.Text );
            nameList.Add( "StockAgentName", this.uLabel_StockAgentName.Text );

            return nameList;
        }

        /// <summary>
        /// �����t�H�[�J�X�ݒ菈��
        /// </summary>
        public Control SetInitFocus( object sender )
        {
            this.tEdit_SectionCode.Focus();
            this.tEdit_SectionCode.SelectAll();
            return this.tEdit_SectionCode;
        }

        /// <summary>
        /// ��ʏI������
        /// </summary>
        public void CloseForm()
        {
            this.Close();
        }

        /// <summary>
        /// �_�C�A���O���U���g�ݒ菈��
        /// </summary>
        /// <param name="dialogRes">�_�C�A���O���U���g</param>
        public void SetDialogRes( DialogResult dialogRes )
        {
            _dialogRes = dialogRes;
        }
        # endregion

        
    }
}
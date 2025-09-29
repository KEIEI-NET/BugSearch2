//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �|���ݒ�}�X�^�����i�|���D��Ǘ��p�^�[���j�i���i�|����ٰ�ߎw��j
// �v���O�����T�v   : �|���ݒ�}�X�^�����i�|���D��Ǘ��p�^�[���j�i���i�|����ٰ�ߎw��j�̏������s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ����
// �� �� ��  2010/08/19  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ������
// �C �� ��  2010/08/31  �C�����e : Redmine#14030�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : hanby
// �C �� ��  2010/09/09  �C�����e : Redmine#14492�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ������
// �C �� ��  2010/09/26  �C�����e : Redmine#14492�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ����
// �C �� ��  2010/09/30  �C�����e : Redmine#15703�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���|��
// �C �� ��  2011/11/21  �C�����e : Redmine#7867�Ή�
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Infragistics.Win.Misc;
using System.Collections;
using Infragistics.Win;
using Broadleaf.Library.Resources;
using Infragistics.Win.UltraWinToolbars;
using Broadleaf.Library.Windows.Forms;
using Infragistics.Win.UltraWinGrid;
using System.Net.NetworkInformation;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// �|���ݒ�}�X�^�����t�H�[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �|���ݒ�}�X�^�����̃t�H�[���N���X�ł��B</br>
    /// <br>Programmer	: ����</br>
    /// <br>Date		: 2010/08/19</br>
    /// <br>Update Note : 2010/08/31 ������</br>
    /// <br>            : Redmine#14030�Ή�</br>
    /// <br>Update Note : 2010/09/09 hanby</br>
    /// <br>            : Redmine#14492�Ή�</br>
    /// <br>Update Note : 2010/09/26 ������</br>
    /// <br>            : Redmine#14492�Ή�</br>
    /// <br>Update Note : 2010/09/30 ����</br>
    /// <br>            : Redmine#15703�Ή�</br>
    /// <br>Update Note : 2011/11/21 ���|��</br>
    /// <br>            : Redmine#7867�Ή�</br>
    /// </remarks>
    public partial class PMKHN09475UA : Form
    {

        #region Private Members
        private bool _cusotmerGuideSelected;                // ���Ӑ�K�C�h�I���t���O

        // �O��l�ێ��p�ϐ�
        private int _prevCustomerCode;
        private int _prevSupplierCode;
        private int _prevMakerCode;
        private int _prevCustRateGrpCode;

        // ��ƃR�[�h�擾�p
        private string _enterpriseCode;
        // ���O�C�����_(�����_)
        private string _loginSectionCode;

        private CustomerInfoAcs _customerInfoAcs = null;    // ���Ӑ�A�N�Z�X�N���X
        private SupplierAcs _supplierAcs = null;            // �d����A�N�Z�X�N���X
        private MakerAcs _makerAcs = null;					// ���[�J�[�A�N�Z�X�N���X
        private UserGuideAcs _userGuideAcs = null;			// ���[�U�[�K�C�h�A�N�Z�X�N���X
        private SecInfoAcs _secInfoAcs; // ���_�A�N�Z�X�N���X
        private RateProtyMngBlCdConstructionAcs _rateProtyMngBlCdConstructionAcs;
        private Dictionary<int, string> _custRateGrpDic;

        private RateProtyMng _rateProtyMng;// �|���D��Ǘ��}�X�^
        private RateProtyMngPatternAcs _rateProtyMngPatternAcs;// �|���ݒ�}�X�^�����i�|���D��Ǘ��p�^�[���j�A�N�Z�X
        private RateProtyMngPatternDataSet _rateProtyMngPatternDataSet;// �|���}�X�^�f�[�^�Z�b�g

        /// <summary>�O���b�h�ŏ�ʍs�L�[�_�E���C�x���g</summary>
        internal event EventHandler GridKeyDownTopRow;

        private ControlScreenSkin _controlScreenSkin;

        private Dictionary<int, Supplier> _supplierDic;
        private Dictionary<int, MakerUMnt> _makerUMntDic;

        private RateProtyMngPatternWork _rateProtyMngPatternWorkClone;// ��ʒ��o������Compare�p

        private object _initFocus;
        private object _endFocus;
        private object _endButtonFocus;
        private int _cellMove;

        // ---ADD 2010/09/09---------------------->>>
        private GoodsGroupUAcs _goodsGroupUAcs = null;      // ���i�|���f�A�N�Z�X�N���X

        private int _preRowIndex;
        private int _preColumnIndex;
        private string _preMakerCd;
        private string masterCode = "GoodsRateGrpCode"; // ADD 2010/09/25
        private bool _gridGuideFlg = false; // ADD 2010/09/25
        // ---ADD 2010/09/09----------------------<<<

        #endregion Private Members

        #region Const
        // �ҏW���[�h
        private const string INSERT_MODE = "�V�K";
        private const string UPDATE_MODE = "�X�V";

        // ---UPD 2010/09/09---------------------->>>
        //private const string UNPRCFRACPROCDIV_1 = "�؎̂�";
        //private const string UNPRCFRACPROCDIV_2 = "�l�̌ܓ�";
        //private const string UNPRCFRACPROCDIV_3 = "�؏グ";
        private const string UNPRCFRACPROCDIV_1 = "1:�؎̂�";
        private const string UNPRCFRACPROCDIV_2 = "2:�l�̌ܓ�";
        private const string UNPRCFRACPROCDIV_3 = "3:�؏グ";
        // ---UPD 2010/09/09----------------------<<<
        // �A�Z���u��ID
        private const string CT_PGID = "PMKHN09475U";
        private const string CT_PGNM = "�|���ݒ�}�X�^����";

        private const string TOOLBAR_CLOSEBUTTON_KEY = "ButtonTool_Close";						// �I��
        private const string TOOLBAR_CLEARBUTTON_KEY = "ButtonTool_Clear";						// �N���A
        private const string TOOLBAR_SETBUTTON_KEY = "ButtonTool_Set";						    // �ݒ�
        private const string TOOLBAR_SEARCHBUTTON_KEY = "ButtonTool_Search";					// ����
        private const string TOOLBAR_SAVEBUTTON_KEY = "ButtonTool_Save";						// �ۑ�
        private const string TOOLBAR_SECTIONTITLELABEL_KEY = "LabelTool_SectionTitle";			// ���O�C�����_
        private const string TOOLBAR_SECTIONNAMELABEL_KEY = "LabelTool_SectionName";			// ���O�C�����_����
        private const string TOOLBAR_ROWDELETE_KEY = "ButtonTool_DelRow";                       // �s�폜
        private const string TOOLBAR_LOGINTITLELABEL_KEY = "LabelTool_LoginTitle";				// ���O�C���S���҃^�C�g��
        private const string TOOLBAR_LOGINNAMELABEL_KEY = "LabelTool_LoginName";		     // ���O�C���S���Җ���
        // �\���`���̂����Ŏg�p
        //private const string FORMAT_CURRENCY = "#,##0.00";
        private const string FORMAT_FRACTION = "#,##0.00;-#,##0.00;''";
        private const string FORMAT_CODE = "#0;-#0;''"; // ADD 2010/09/25

        // �w��Ȃ�
        private const string RATEMNGCUSTCD_NONE = "6";
        // --------ADD 2010/09/09-------->>>>>
        private const string TOOLBAR_GUIDEBUTTON_KEY = "ButtonTool_Guide";		                // �K�C�h
        private const string TOOLBAR_ALLROWDELETE_KEY = "ButtonTool_DelAllRow";                 // �S�폜
        private const string UnitPriceKindNM_1 = "�����ݒ�";
        private const string UnitPriceKindNM_2 = "�����ݒ�";
        private const string UnitPriceKindNM_3 = "���i�ݒ�";
        private bool _errorFlg = false;
        private bool _searchFlg = false;
        private int _prevGoodsRateGrpCode;
        private UltraGridCell _preUnPrcFracProcDivNmCell = null;
        private Dictionary<int, GoodsGroupU> _goodsGroupUDic;
        private bool _guidFlg = false;
        private int _guidCd = 0;

        private bool _delBu = false;
        private bool _deleteButtonFlag = false;
        private bool _initFocusFlag = false;
        private bool _checkEmptyFlg = false;
        private bool _checkInputScreenErr = false;

        // �O��l�ێ��p�ϐ�(�ۑ��̏������s������A���������p)
        private int _prevCustomerCd;
        private int _prevSupplierCd;
        private int _prevMakerCd;
        private int _prevCustRateGrpCd;

        // ���������O�A�t�H�[�J�X�����
        private int _prevIndexRow = -1;
        private int _prevIndexColumn = -1;

        private bool _closeFlg = false;
        private bool _checkScreanInput = false;
        private bool _isCancelFlg = false;
        private bool _isError = false;

        private int _prevIndexRow2 = -1;
        private int _prevIndexColumn2 = -1;
        private bool _errorFlg2 = false;
        // --------ADD 2010/09/09--------<<<<<
        #endregion Const

        #region Constructor
        /// <summary>
        /// �|���ݒ�}�X�^�����i�|���D��Ǘ��p�^�[���j�i���i�|����ٰ�ߎw��j�t�H�[���N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note        : �|���ݒ�}�X�^�����i�|���D��Ǘ��p�^�[���j�i���i�|����ٰ�ߎw��j�t�H�[���N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer	: ����</br>
        /// <br>Date		: 2010/08/19</br>
        /// <br>Update Note : 2010/09/09 hanby</br>
        /// <br>            : Redmine#14492�Ή�</br>
        /// </remarks>
        public PMKHN09475UA(RateProtyMng rateProtyMng)
        {
            InitializeComponent();
            this._controlScreenSkin = new ControlScreenSkin();

            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            this._loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;
            this._customerInfoAcs = new CustomerInfoAcs();
            this._supplierAcs = new SupplierAcs();
            this._secInfoAcs = new SecInfoAcs();
            this._makerAcs = new MakerAcs();
            this._userGuideAcs = new UserGuideAcs();
            this._goodsGroupUAcs = new GoodsGroupUAcs(); // ADD 2010/09/09
            this._rateProtyMngBlCdConstructionAcs = new RateProtyMngBlCdConstructionAcs();
            this._rateProtyMng = rateProtyMng;
            this._rateProtyMngPatternAcs = RateProtyMngPatternAcs.GetInstance();
            this._rateProtyMngPatternDataSet = this._rateProtyMngPatternAcs.RateProtyMngPatternDataSet;
            this.Detail_uGrid.DataSource = this._rateProtyMngPatternDataSet.RateProtyMngPattern;
            this._rateProtyMngPatternWorkClone = new RateProtyMngPatternWork();
            GridKeyDownTopRow += new EventHandler(this.Detail_uGrid_GridKeyDownTopRow);

        }

        #endregion Constructor

        #region Event
        /// <summary>
        /// �t�H�[�����[�h�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note		: �t�H�[�����ǂݍ��܂ꂽ���ɔ������܂��B</br>
        /// <br>Programmer	: ����</br>
        /// <br>Date		: 2010/08/19</br>
        /// <br>Update Note : 2010/09/09 hanby</br>
        /// <br>            : Redmine#14492�Ή�</br>
        /// </remarks>
        private void PMKHN09475UA_Load(object sender, EventArgs e)
        {
            // �A�C�R���ݒ�
            SetIcon();

            // ��ʓ��͋�����
            ScreenInputEnable();

            // ��ʃN���A
            ScreenClear();
            this._cellMove = this._rateProtyMngBlCdConstructionAcs.CellMove;
            this.Detail_uGrid.DataSource = this._rateProtyMngPatternAcs.RateProtyMngPatternDataSet;
            // ----------ADD 2010/09/09----------->>>>>
            // �X�L���ύX���O�ݒ�
            List<string> excCtrlNm = new List<string>();
            excCtrlNm.Add(this.ultraExpandableGroupBox_Condition.Name);
            this._controlScreenSkin.SetExceptionCtrl(excCtrlNm);
            // ----------ADD 2010/09/09-----------<<<<<
            this._controlScreenSkin.LoadSkin();
            this._controlScreenSkin.SettingScreenSkin(this);
            this.Delete_Button.Enabled = false; // ADD 2010/09/09
            this.DeleteAll_Button.Enabled = false; // ADD 2010/09/09
        }

        /// <summary>
        /// �c�[���o�[�N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�C�x���g�I�u�W�F�N�g</param>
        /// <param name="e">�C�x���g���</param>
        /// <remarks>
        /// <br>Note		: �c�[���o�[��̃c�[�����N���b�N���ꂽ���ɔ������܂��B</br>
        /// <br>Programmer	: ����</br>
        /// <br>Date		: 2010/08/19</br>
        /// <br>Update Note : 2010/09/09 hanby</br>
        /// <br>            : Redmine#14492�Ή�</br>
        /// <br>Update Note : 2010/09/30</br>
        /// <br>            : Redmine#15703�Ή�</br>
        /// </remarks>
        private void tToolbarsManager_MainMenu_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {

            switch (e.Tool.Key)
            {
                // -------------------------------------------------------------------------------
                // �I��
                // -------------------------------------------------------------------------------
                case TOOLBAR_CLOSEBUTTON_KEY:
                    {
                        #region �I��
                        if (this.CloseCheck())
                        {
                            this.Close();
                        }
                        else
                        {
                            DialogResult dr = TMsgDisp.Show(
                                emErrorLevel.ERR_LEVEL_QUESTION,
                                CT_PGID,
                                "���݁A�ҏW���̃f�[�^�����݂��܂�\n\n" + "�o�^���Ă���낵���ł����H",
                                0,
                                MessageBoxButtons.YesNoCancel);

                            switch (dr)
                            {
                                case DialogResult.No:
                                    _closeFlg = true;
                                    this.Close();
                                    break;
                                case DialogResult.Yes:
                                    if (this.SaveProc())
                                    {
                                        this.Close();
                                    }
                                    break;
                                case DialogResult.Ignore:
                                    break;
                                // ---ADD 2010/09/09---------------------->>>
                                case DialogResult.Cancel:
                                    if (this.Detail_uGrid.ActiveCell != null)
                                    {
                                        this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode); // ADD 2010/09/09
                                    }
                                    break;
                                // ---ADD 2010/09/09----------------------<<<
                            }
                        }
                        #endregion
                        break;
                    }
                // -------------------------------------------------------------------------------
                // �ۑ�
                // -------------------------------------------------------------------------------
                case TOOLBAR_SAVEBUTTON_KEY:
                    {
                        // ---ADD 2010/09/09---------------------->>>
                        if (this._isError == true)
                        {
                            this._isError = false;
                            return;
                        }
                        // ---ADD 2010/09/09----------------------<<<

                        #region �ۑ�
                        //this.SaveProc(); // DEL 2010/09/09
                        // ---ADD 2010/09/09---------------------->>>
                        if ((this.SaveProc() || this._checkEmptyFlg) && (this.Detail_uGrid.Rows.Count != 0))
                        {
                            this._checkEmptyFlg = false;
                            if (this.Mode_Label.Text == INSERT_MODE)
                            {
                                if (!this._initFocusFlag)
                                {
                                    this.Detail_uGrid.Focus();
                                    this.Detail_uGrid.ActiveRow = this.Detail_uGrid.Rows[0];
                                    //this.Detail_uGrid.Rows[0].Cells["MasterNm"].Activate(); // DEL 2010/09/25
                                    this.Detail_uGrid.Rows[0].Cells[masterCode].Activate(); // ADD 2010/09/25
                                    this.InitGridFocus(0, 0);
                                }
                                else
                                {
                                    this._initFocusFlag = false;
                                }
                            }
                            else
                            {
                                this.Detail_uGrid.Focus();
                                this.Detail_uGrid.ActiveRow = this.Detail_uGrid.Rows[0];
                                //this.Detail_uGrid.Rows[0].Cells["MasterNm"].Activate(); // DEL 2010/09/25
                                this.Detail_uGrid.Rows[0].Cells[masterCode].Activate(); // ADD 2010/09/25
                                ChangeFocusEventArgs evt = new ChangeFocusEventArgs(false, false, false, Keys.Tab, this.Detail_uGrid, this.Detail_uGrid);
                                this.SetGridTabFocus(ref evt);
                            }
                        }
                        else
                        {
                            this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                            //this.Delete_Button.Enabled = false; // DEL 2010/09/25
                            //this.DeleteAll_Button.Enabled = false; // DEL 2010/09/25
                            return;
                        }
                        // ---ADD 2010/09/09----------------------<<<
                        #endregion
                        break;
                    }
                // -------------------------------------------------------------------------------
                // �N���A
                // -------------------------------------------------------------------------------
                case TOOLBAR_CLEARBUTTON_KEY:
                    {
                        #region �N���A
                        if (this.CloseCheck())
                        {
                            this.ScreenClear();
                        }
                        else
                        {
                            DialogResult dr = TMsgDisp.Show(
                                            emErrorLevel.ERR_LEVEL_QUESTION,
                                            CT_PGID,
                                            "���݁A�ҏW���̃f�[�^�����݂��܂�\n\n" + "�o�^���Ă���낵���ł����H",
                                            0,
                                            MessageBoxButtons.YesNoCancel);

                            switch (dr)
                            {
                                case DialogResult.No:
                                    this.ScreenClear();
                                    break;
                                case DialogResult.Yes:
                                    if (this.SaveProc())
                                    {
                                        this.ScreenClear();
                                    }
                                    break;
                                case DialogResult.Ignore:
                                    break;
                                // ---ADD 2010/09/09---------------------->>>
                                case DialogResult.Cancel:
                                    if (this.Detail_uGrid.ActiveCell != null)
                                    {
                                        this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode); // ADD 2010/09/09
                                    }
                                    break;
                                // ---ADD 2010/09/09----------------------<<<
                            }
                        }
                        #endregion
                        break;
                    }
                // -------------------------------------------------------------------------------
                // ����
                // -------------------------------------------------------------------------------
                case TOOLBAR_SEARCHBUTTON_KEY:
                    {
                        // ---ADD 2010/09/09---------------------->>>
                        #region ���������O�A�t�H�[�J�X�����
                        if (this.Detail_uGrid.ActiveCell != null)
                        {
                            this._prevIndexRow = this.Detail_uGrid.ActiveCell.Row.Index;
                            this._prevIndexColumn = this.Detail_uGrid.ActiveCell.Column.Index;
                        }
                        #endregion

                        // ���������O�A�����������`�F�b�N
                        CheckBeforeSearch();

                        if (this._isError == true)
                        {
                            this._isError = false;
                            return;
                        }
                        // ---ADD 2010/09/09----------------------<<<
                        #region ����
                        //SearchRateData(); // DEL 2010/09/09
                        this.Search(); // ADD 2010/09/09
                        // ---ADD 2010/09/26---------------------->>>
                        // �����������L�����Z�����ꂽ�ꍇ
                        if (this._isCancelFlg)
                        {
                            // �Ȃ�
                        }
                        else if (this.Detail_uGrid.Rows.Count != 0 && this._checkInputScreenErr == false)
                        {
                            if (this.Mode_Label.Text == INSERT_MODE)
                            {
                                if (!this._initFocusFlag)
                                {
                                    this.Detail_uGrid.Focus();
                                    this.Detail_uGrid.ActiveRow = this.Detail_uGrid.Rows[0];
                                    this.Detail_uGrid.Rows[0].Cells[masterCode].Activate();
                                    this.InitGridFocus(0, 0);
                                }
                                else
                                {
                                    this._initFocusFlag = false;
                                }
                            }
                            else
                            {
                                this.Detail_uGrid.Focus();
                                this.Detail_uGrid.ActiveRow = this.Detail_uGrid.Rows[0];
                                this.Detail_uGrid.Rows[0].Cells[masterCode].Activate();
                                ChangeFocusEventArgs evt = new ChangeFocusEventArgs(false, false, false, Keys.Tab, this.Detail_uGrid, this.Detail_uGrid);
                                this.SetGridTabFocus(ref evt);
                            }
                        }
                        this._isCancelFlg = false;
                        this._checkInputScreenErr = false;
                        // ---ADD 2010/09/26----------------------<<<
                        #endregion
                        break;
                    }
                // -------------------------------------------------------------------------------
                // �ݒ�
                // -------------------------------------------------------------------------------
                case TOOLBAR_SETBUTTON_KEY:
                    {
                        #region �ݒ�
                        this.SetUp();
                        #endregion �ݒ�
                        break;
                    }

                // -------------------------------------------------------------------------------
                // �s�폜
                // -------------------------------------------------------------------------------
                case TOOLBAR_ROWDELETE_KEY:
                    {
                        // ---UPD 2010/09/25---------------------->>>
                        // ---ADD 2010/09/10---------------------->>>
                        int rowIndex = 0;
                        //if (this.Detail_uGrid.ActiveCell != null) // DEL 2010/09/30 �d�l�A�� #15703
                        if (this.Detail_uGrid.ActiveRow != null) // ADD 2010/09/30 �d�l�A�� #15703
                        {
                            //rowIndex = this.Detail_uGrid.ActiveCell.Row.Index; // DEL 2010/09/30 �d�l�A�� #15703
                            rowIndex = this.Detail_uGrid.ActiveRow.Index; // ADD 2010/09/30 �d�l�A�� #15703
                        }
                        else
                        {
                            if (this.Detail_uGrid.Rows.Count > 0)
                            {
                                RowDelete();
                                if (!this.AllDeleteCheck())
                                {
                                    this.Delete_Button.Focus();
                                }
                            }
                            else
                            {
                                return;
                            }
                        }
                        // ---ADD 2010/09/10----------------------<<<
                        this._deleteButtonFlag = true;// ADD 2010/09/10
                        //this.Detail_uGrid.PerformAction(UltraGridAction.ExitEditMode);  // ADD 2010/09/10 // DEL 2010/09/30 �d�l�A�� #15703
                        // ---ADD 2010/09/10---------------------->>>
                        if (this._errorFlg)
                        {
                            ((RateProtyMngPatternDataSet.RateProtyMngPatternRow)this._rateProtyMngPatternDataSet.RateProtyMngPattern.Rows[rowIndex]).MasterNm = string.Empty;
                            ((RateProtyMngPatternDataSet.RateProtyMngPatternRow)this._rateProtyMngPatternDataSet.RateProtyMngPattern.Rows[rowIndex]).GoodsRateGrpCode = string.Empty; // ADD 2010/09/25
                            this._errorFlg = false;
                        }
                        RowDelete();
                        if (!this.AllDeleteCheck())
                        {
                            this.Delete_Button.Focus();
                            break;
                        }

                        // --- DEL 2010/09/30 �d�l�A�� #15703 ---------->>>>>
                        //if (!CatchSelectedRow(rowIndex))
                        //{
                        //    ChangeFocusEventArgs evt = new ChangeFocusEventArgs(false, false, false, Keys.Tab, this.Detail_uGrid, this.Detail_uGrid);
                        //    this.Detail_uGrid.ActiveRow = this.Detail_uGrid.Rows[SelectedRow()];
                        //    //this.Detail_uGrid.Rows[SelectedRow()].Cells["MasterNm"].Activate(); // DEL 2010/09/25
                        //    this.Detail_uGrid.Rows[SelectedRow()].Cells[masterCode].Activate(); // ADD 2010/09/25
                        //    //this.SetGridTabFocus(ref evt);
                        //    this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                        //}
                        //else
                        //{
                        //    //this.Detail_uGrid_KeyDown(this.Detail_uGrid, new KeyEventArgs(Keys.Right)); // ADD 2010/09/25
                        //}
                        // --- DEL 2010/09/30 �d�l�A�� #15703 ----------<<<<<

                        // ---ADD 2010/09/10----------------------<<<
                        this._deleteButtonFlag = false;// ADD 2010/09/10
                        break;
                        //// ---ADD 2010/09/10----------------------<<<
                        //this._deleteButtonFlag = false;// ADD 2010/09/10
                        //break;

                        //RowDelete();
                        //break;
                        // ---UPD 2010/09/25----------------------<<<
                    }

                // ---ADD 2010/09/09---------------------->>>
                // -------------------------------------------------------------------------------
                // �S�폜
                // -------------------------------------------------------------------------------
                case TOOLBAR_ALLROWDELETE_KEY:
                    {
                        int rowIndex = 0;
                        if (this.Detail_uGrid.ActiveCell != null)
                        {
                            rowIndex = this.Detail_uGrid.ActiveCell.Row.Index;
                        }
                        this._deleteButtonFlag = true;
                        this.Detail_uGrid.PerformAction(UltraGridAction.ExitEditMode);
                        this._deleteButtonFlag = false;
                        if (this.AllDeleteEnabledCheck())
                        {
                            if (this._errorFlg)
                            {
                                ((RateProtyMngPatternDataSet.RateProtyMngPatternRow)this._rateProtyMngPatternDataSet.RateProtyMngPattern.Rows[rowIndex]).MasterNm = string.Empty;
                                ((RateProtyMngPatternDataSet.RateProtyMngPatternRow)this._rateProtyMngPatternDataSet.RateProtyMngPattern.Rows[rowIndex]).GoodsRateGrpCode = string.Empty; // ADD 2010/09/25
                            }
                            AllRowDelete();

                            if (!this._errorFlg)
                            {
                                ChangeFocusEventArgs evt = new ChangeFocusEventArgs(false, false, false, Keys.Tab, this.Detail_uGrid, this.Detail_uGrid);
                                this.Detail_uGrid.ActiveRow = this.Detail_uGrid.Rows[SelectedRow()];
                                //this.Detail_uGrid.Rows[SelectedRow()].Cells["MasterNm"].Activate(); // DEL 2010/09/25
                                this.Detail_uGrid.Rows[SelectedRow()].Cells[masterCode].Activate(); // ADD 2010/09/25
                                //this.SetGridTabFocus(ref evt);
                                this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                //this.Detail_uGrid_KeyDown(this.Detail_uGrid, new KeyEventArgs(Keys.Right));
                                break;

                            }
                            else
                            {
                                this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);

                            }
                            this._errorFlg = false;

                            if (!CatchSelectedRow(rowIndex))
                            {
                                ChangeFocusEventArgs evt = new ChangeFocusEventArgs(false, false, false, Keys.Tab, this.Detail_uGrid, this.Detail_uGrid);
                                //this.Detail_uGrid.ActiveRow = this.Detail_uGrid.Rows[SelectedRow()]; // DEL 2010/09/25
                                //this.Detail_uGrid.Rows[SelectedRow()].Cells["MasterNm"].Activate(); // DEL 2010/09/25
                                //this.SetGridTabFocus(ref evt); // DEL 2010/09/25
                                this.Detail_uGrid.Rows[GetGridInitRowNo()].Cells[GetGridInitColumKey()].Activate(); // ADD 2010/09/25
                                this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode); // ADD 2010/09/25
                            }
                        }
                        else
                        {
                            this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                            return;
                        }
                        break;
                    }
                // -------------------------------------------------------------------------------
                // �K�C�h
                // -------------------------------------------------------------------------------
                case TOOLBAR_GUIDEBUTTON_KEY:
                    {
                        // ���Ӑ�R�[�h�K�C�h���N��
                        if (this.tNedit_CustomerCode.Focused)
                        {
                            this.CustomerGuide_Button_Click(this.tNedit_CustomerCode, new EventArgs());
                        }
                        // ���Ӑ�|��G�K�C�h���N��
                        else if (this.tNedit_CustRateGrpCodeZero.Focused)
                        {
                            this.CustRateGrpGuide_Button_Click(this.tNedit_CustRateGrpCodeZero, new EventArgs());
                        }
                        // �d����R�[�h�K�C�h���N��
                        else if (this.tNedit_SupplierCd.Focused)
                        {
                            this.SupplierGuide_Button_Click(this.tNedit_SupplierCd, new EventArgs());
                        }
                        // ���[�J�[�R�[�h�K�C�h���N��
                        // --------ADD 2010/09/09-------->>>>>
                        else if (this.tNedit_GoodsMakerCd.Focused)
                        {
                            this.MakerGuide_Button_Click(this.tNedit_GoodsMakerCd, new EventArgs());
                        }
                        // --------ADD 2010/09/09--------<<<<<
                        else
                        {
                            //if ((this.Detail_uGrid.ActiveCell != null) && this.Detail_uGrid.ActiveCell.Column.Key.Equals("MasterNm")) // DEL 2010/09/25
                            if ((this.Detail_uGrid.ActiveCell != null) && this.Detail_uGrid.ActiveCell.Column.Key.Equals(masterCode)) // ADD 2010/09/25
                            {
                                if (ExcuteGuide())
                                {
                                    // �t�H�[�J�X����
                                    ChangeFocusEventArgs ent = new ChangeFocusEventArgs(false, false, false, Keys.Tab, this.Detail_uGrid, this.Detail_uGrid);
                                    SetGridTabFocus(ref ent);
                                }
                            }
                        }

                        break;
                    }
                // ---ADD 2010/09/09----------------------<<<
            }
            // ---ADD 2010/09/09---------------------->>>
            //#region ���s�폜�{�^���L�������̐ݒ�
            //if (this.Detail_uGrid.ActiveCell != null)
            //{
            //    this.Delete_Button.Enabled = true;
            //}
            //else
            //{
            //    this.Delete_Button.Enabled = false;
            //}
            //#endregion

            //#region ���S�폜�{�^���L�������̐ݒ�
            //if (this.AllDeleteEnabledCheck())
            //{
            //    this.DeleteAll_Button.Enabled = true;
            //}
            //else
            //{
            //    this.DeleteAll_Button.Enabled = false;
            //}
            //#endregion
            #region ���s�폜/�S�폜�{�^���L�������̐ݒ�
            if (this.Detail_uGrid.Rows.Count != 0)
            {
                this.Delete_Button.Enabled = true;
                this.DeleteAll_Button.Enabled = true;
            }
            else
            {
                this.Delete_Button.Enabled = false;
                this.DeleteAll_Button.Enabled = false;
            }
            #endregion
            // ---ADD 2010/09/09----------------------<<<
        }

        /// <summary>
        /// ChangeFocus �C�x���g(tArrowKeyControl1)
        /// </summary>
        /// <param name="sender">�C�x���g�I�u�W�F�N�g</param>
        /// <param name="e">�C�x���g���</param>
        /// <remarks>
        /// <br>Note		: �e�R���g���[������t�H�[�J�X�����ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer  : ����</br>
        /// <br>Date        : 2010/08/19</br>
        /// <br>Update Note : 2010/09/09 hanby</br>
        /// <br>            : Redmine#14492�Ή�</br>
        /// <br>Update Note : 2010/09/26 ������</br>
        /// <br>            : Redmine#14492�Ή�</br>
        /// </remarks>
        private void tArrowKeyControl1_ChangeFocus(object sender, Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null || e.NextCtrl == null) return;
            switch (e.PrevCtrl.Name)
            {
                case "Delete_Button":
                    {
                        if (e.NextCtrl != Detail_uGrid)
                        {
                            this.Detail_uGrid.ActiveCell = null;
                            this.Detail_uGrid.ActiveRow = null;
                        }
                        break;
                    }
                //-----------------------------------------------------
                // ���Ӑ�
                //-----------------------------------------------------
                case "tNedit_CustomerCode":
                    {
                        # region [���Ӑ�]
                        int inputValue = this.tNedit_CustomerCode.GetInt();

                        // �O��l�ƈ�v���Ȃ��ꍇ
                        if (_prevCustomerCode != inputValue)
                        {
                            // ���͖���
                            if (this.tNedit_CustomerCode.GetInt() == 0)
                            {
                                this.CustomerCodeNm_tEdit.Clear();
                                this.tNedit_CustomerCode.Clear();
                                this._prevCustomerCode = 0;
                            }
                            else
                            {
                                string name = string.Empty;
                                bool check = GetCustomerName(inputValue, out name);
                                if (check)
                                {
                                    this.CustomerCodeNm_tEdit.Text = name;
                                    this._prevCustomerCode = inputValue;
                                }
                                else
                                {
                                    // �G���[��
                                    TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_INFO,
                                        this.Name,
                                        "���Ӑ悪���݂��܂���B",
                                        -1,
                                        MessageBoxButtons.OK);

                                    // �R�[�h�߂�
                                    this.tNedit_CustomerCode.SetInt(this._prevCustomerCode);
                                    this.tNedit_CustomerCode.SelectAll();
                                    e.NextCtrl = e.PrevCtrl;
                                    return;
                                }
                            }
                        }
                        # endregion [���Ӑ�]

                        #region [�t�H�[�J�X����]
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                // ---ADD 2010/09/25---------------------->>>
                                case Keys.Left:
                                    {
                                        e.NextCtrl = null;
                                        break;
                                    }
                                // ---ADD 2010/09/25----------------------<<<
                                case Keys.LButton:
                                    {
                                        if (e.NextCtrl == this.Detail_uGrid)
                                        {
                                            this._delBu = true;
                                        }
                                        break;
                                    }
                                case Keys.Tab:
                                case Keys.Return:
                                    {
                                        if (this.tNedit_CustomerCode.GetInt() == 0)
                                        {
                                            e.NextCtrl = this.CustomerGuide_Button;
                                        }
                                        else
                                        {
                                            e.NextCtrl = null;
                                            bool status = SetFocus(3);
                                            if (status == false)
                                            {
                                                //SearchRateData(); // DEL 2010/09/09
                                                this.Search(); // ADD 2010/09/09
                                                e.NextCtrl = null;
                                                // ---ADD 2010/09/26---------------------->>>
                                                // �����������L�����Z�����ꂽ�ꍇ
                                                if (this._isCancelFlg)
                                                {
                                                    // �Ȃ�
                                                }
                                                else
                                                // ---ADD 2010/09/26----------------------<<<
                                                // ---ADD 2010/09/09---------------------->>>
                                                if (this.Detail_uGrid.Rows.Count != 0 && this._checkInputScreenErr == false)
                                                {
                                                    if (this.Mode_Label.Text == INSERT_MODE)
                                                    {
                                                        if (!this._initFocusFlag)
                                                        {
                                                            this.Detail_uGrid.Focus();
                                                            this.Detail_uGrid.ActiveRow = this.Detail_uGrid.Rows[0];
                                                            //this.Detail_uGrid.Rows[0].Cells["MasterNm"].Activate(); // DEL 2010/09/25
                                                            this.Detail_uGrid.Rows[0].Cells[masterCode].Activate(); // ADD 2010/09/25
                                                            this.InitGridFocus(0, 0);
                                                        }
                                                        else
                                                        {
                                                            this._initFocusFlag = false;
                                                        }
                                                    }
                                                    else
                                                    {
                                                        this.Detail_uGrid.Focus();
                                                        this.Detail_uGrid.ActiveRow = this.Detail_uGrid.Rows[0];
                                                        //this.Detail_uGrid.Rows[0].Cells["MasterNm"].Activate(); // DEL 2010/09/25
                                                        this.Detail_uGrid.Rows[0].Cells[masterCode].Activate(); // ADD 2010/09/25
                                                        this.SetGridTabFocus(ref e);
                                                    }
                                                }
                                                this._isCancelFlg = false; // ADD 2010/09/26
                                                this._checkInputScreenErr = false; // ADD 2010/09/26
                                                // ---ADD 2010/09/09----------------------<<<
                                            }
                                        }
                                    }
                                    break;
                                case Keys.Down:
                                    {
                                        if (!this.tNedit_CustRateGrpCodeZero.Enabled && !this.tNedit_SupplierCd.Enabled && this.Detail_uGrid.Rows.Count != 0)
                                        {
                                            // ---UPD 2010/09/25---------------------->>>
                                            //this.Detail_uGrid.Rows[0].Cells[GetGridInitColumKey()].Activate();
                                            //this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                            e.NextCtrl = null;
                                            // ---ADD 2010/09/09---------------------->>>
                                            //if (this.Mode_Label.Text == INSERT_MODE)
                                            //{
                                            //    if (!this._initFocusFlag)
                                            //    {
                                            //        this.Detail_uGrid.Focus();
                                            //        this.Detail_uGrid.ActiveRow = this.Detail_uGrid.Rows[0];
                                            //        //this.Detail_uGrid.Rows[0].Cells["MasterNm"].Activate(); // DEL 2010/09/25
                                            //        this.Detail_uGrid.Rows[0].Cells[masterCode].Activate(); // ADD 2010/09/25
                                            //        this.InitGridFocus(0, 0);
                                            //    }
                                            //    else
                                            //    {
                                            //        this._initFocusFlag = false;
                                            //    }
                                            //}
                                            //else
                                            //{
                                            //    this.Detail_uGrid.Focus();
                                            //    this.Detail_uGrid.ActiveRow = this.Detail_uGrid.Rows[0];
                                            //    //this.Detail_uGrid.Rows[0].Cells["MasterNm"].Activate(); // DEL 2010/09/25
                                            //    this.Detail_uGrid.Rows[0].Cells[masterCode].Activate(); // ADD 2010/09/25
                                            //    this.SetGridTabFocus(ref e);
                                            //}
                                            // ---ADD 2010/09/09----------------------<<<

                                            this.Detail_uGrid.Rows[GetGridInitRowNo()].Cells[GetGridInitColumKey()].Activate();
                                            this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                            // ---UPD 2010/09/25----------------------<<<
                                        }
                                        else if (!this.tNedit_CustRateGrpCodeZero.Enabled && !this.tNedit_SupplierCd.Enabled && this.Detail_uGrid.Rows.Count == 0)
                                        {
                                            e.NextCtrl = null;
                                        }
                                    }
                                    break;
                                // ---ADD 2010/09/09---------------------->>>
                                case Keys.Up:
                                    {
                                        e.NextCtrl = null;
                                    }
                                    break;
                                // ---ADD 2010/09/09----------------------<<<
                            }
                        }
                        else
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Enter: // ADD 2010/09/09
                                    {
                                        e.NextCtrl = null;
                                    }
                                    break;
                            }
                        }
                        #endregion [�t�H�[�J�X����]
                        break;
                    }
                //-----------------------------------------------------
                // ���Ӑ�{�^��
                //-----------------------------------------------------
                case "CustomerGuide_Button":
                    {
                        #region [�t�H�[�J�X����]
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                // ---ADD 2010/09/25---------------------->>>
                                case Keys.Right:
                                    {
                                        if (!this.tNedit_GoodsMakerCd.Enabled)
                                        {
                                            e.NextCtrl = null;
                                        }
                                        break;
                                    }
                                // ---ADD 2010/09/25----------------------<<<
                                case Keys.LButton:
                                    {
                                        if (e.NextCtrl == this.Detail_uGrid)
                                        {
                                            this._delBu = true;

                                        }
                                        break;
                                    }
                                case Keys.Tab:
                                case Keys.Return:
                                    {
                                        e.NextCtrl = null;
                                        bool status = SetFocus(3);
                                        if (status == false)
                                        {
                                            if (e.Key == Keys.Return)
                                            {
                                                //SearchRateData();
                                                this.Search(); // ADD 2010/09/09
                                                e.NextCtrl = null;
                                                // ---ADD 2010/09/26---------------------->>>
                                                // �����������L�����Z�����ꂽ�ꍇ
                                                if (this._isCancelFlg)
                                                {
                                                    // �Ȃ�
                                                }
                                                else
                                                // ---ADD 2010/09/26----------------------<<<
                                                // ---ADD 2010/09/09---------------------->>>
                                                //if (this.Detail_uGrid.Rows.Count > 0) // DEL 2010/09/26
                                                if (this.Detail_uGrid.Rows.Count > 0 && this._checkInputScreenErr == false) // ADD 2010/09/26
                                                {
                                                    if (this.Mode_Label.Text == INSERT_MODE)
                                                    {
                                                        if (!this._initFocusFlag)
                                                        {
                                                            this.Detail_uGrid.Focus();
                                                            this.Detail_uGrid.ActiveRow = this.Detail_uGrid.Rows[0];
                                                            //this.Detail_uGrid.Rows[0].Cells["MasterNm"].Activate(); // DEL 2010/09/25
                                                            this.Detail_uGrid.Rows[0].Cells[masterCode].Activate(); // ADD 2010/09/25
                                                            this.InitGridFocus(0, 0);
                                                        }
                                                        else
                                                        {
                                                            this._initFocusFlag = false;
                                                        }
                                                    }
                                                    else
                                                    {
                                                        this.Detail_uGrid.Focus();
                                                        this.Detail_uGrid.ActiveRow = this.Detail_uGrid.Rows[0];
                                                        //this.Detail_uGrid.Rows[0].Cells["MasterNm"].Activate(); // DEL 2010/09/25
                                                        this.Detail_uGrid.Rows[0].Cells[masterCode].Activate(); // ADD 2010/09/25
                                                        this.SetGridTabFocus(ref e);
                                                    }
                                                }
                                                this._isCancelFlg = false; // ADD 2010/09/26
                                                this._checkInputScreenErr = false; // ADD 2010/09/26
                                                // ---ADD 2010/09/09----------------------<<<
                                            }
                                            else
                                            {
                                                if (this.Detail_uGrid.Rows.Count != 0)
                                                {
                                                    this.Detail_uGrid.Rows[0].Cells[GetGridInitColumKey()].Activate();
                                                    this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                                    e.NextCtrl = null;
                                                    // ---ADD 2010/09/09---------------------->>>
                                                    if (this.Detail_uGrid.Rows.Count > 0)
                                                    {
                                                        if (this.Mode_Label.Text == INSERT_MODE)
                                                        {
                                                            if (!this._initFocusFlag)
                                                            {
                                                                this.Detail_uGrid.Focus();
                                                                this.Detail_uGrid.ActiveRow = this.Detail_uGrid.Rows[0];
                                                                //this.Detail_uGrid.Rows[0].Cells["MasterNm"].Activate(); // DEL 2010/09/25
                                                                this.Detail_uGrid.Rows[0].Cells[masterCode].Activate(); // ADD 2010/09/25
                                                                this.InitGridFocus(0, 0);
                                                            }
                                                            else
                                                            {
                                                                this._initFocusFlag = false;
                                                            }
                                                        }
                                                        else
                                                        {
                                                            this.Detail_uGrid.Focus();
                                                            this.Detail_uGrid.ActiveRow = this.Detail_uGrid.Rows[0];
                                                            //this.Detail_uGrid.Rows[0].Cells["MasterNm"].Activate(); // DEL 2010/09/25
                                                            this.Detail_uGrid.Rows[0].Cells[masterCode].Activate(); // ADD 2010/09/25
                                                            this.SetGridTabFocus(ref e);
                                                        }
                                                    }
                                                    // ---ADD 2010/09/09----------------------<<<
                                                }
                                                else
                                                {
                                                    e.NextCtrl = null;
                                                }
                                            }
                                        }
                                    }
                                    break;
                                case Keys.Down:
                                    {
                                        if (!this.CustRateGrpGuide_Button.Enabled && !this.SupplierGuide_Button.Enabled && this.Detail_uGrid.Rows.Count != 0)
                                        {
                                            // ---UPD 2010/09/25---------------------->>>
                                            //this.Detail_uGrid.Rows[0].Cells[GetGridInitColumKey()].Activate();
                                            //this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                            e.NextCtrl = null;
                                            // ---ADD 2010/09/09---------------------->>>
                                            //if (this.Detail_uGrid.Rows.Count > 0)
                                            //{
                                            //    if (this.Mode_Label.Text == INSERT_MODE)
                                            //    {
                                            //        if (!this._initFocusFlag)
                                            //        {
                                            //            this.Detail_uGrid.Focus();
                                            //            this.Detail_uGrid.ActiveRow = this.Detail_uGrid.Rows[0];
                                            //            //this.Detail_uGrid.Rows[0].Cells["MasterNm"].Activate(); // DEL 2010/09/25
                                            //            this.Detail_uGrid.Rows[0].Cells[masterCode].Activate(); // ADD 2010/09/25
                                            //            this.InitGridFocus(0, 0);
                                            //        }
                                            //        else
                                            //        {
                                            //            this._initFocusFlag = false;
                                            //        }
                                            //    }
                                            //    else
                                            //    {
                                            //        this.Detail_uGrid.Focus();
                                            //        this.Detail_uGrid.ActiveRow = this.Detail_uGrid.Rows[0];
                                            //        //this.Detail_uGrid.Rows[0].Cells["MasterNm"].Activate(); // DEL 2010/09/25
                                            //        this.Detail_uGrid.Rows[0].Cells[masterCode].Activate(); // ADD 2010/09/25
                                            //        this.SetGridTabFocus(ref e);
                                            //    }
                                            //}
                                            // ---ADD 2010/09/09----------------------<<<

                                            this.Detail_uGrid.Rows[GetGridInitRowNo()].Cells[GetGridInitColumKey()].Activate();
                                            this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);

                                            this.tToolbarsManager_MainMenu.Tools[TOOLBAR_GUIDEBUTTON_KEY].SharedProps.Enabled = false;
                                            // ---UPD 2010/09/25----------------------<<<
                                        }
                                        else if (!this.CustRateGrpGuide_Button.Enabled && !this.SupplierGuide_Button.Enabled && this.Detail_uGrid.Rows.Count == 0)
                                        {
                                            e.NextCtrl = null;
                                        }
                                    }
                                    break;
                                // ---ADD 2010/09/09---------------------->>>
                                case Keys.Up:
                                    {
                                        e.NextCtrl = null;
                                    }
                                    break;
                                // ---ADD 2010/09/09----------------------<<<
                            }
                        }
                        #endregion [�t�H�[�J�X����]
                        break;

                    }
                //-----------------------------------------------------
                // ���Ӑ�|����ٰ��
                //-----------------------------------------------------
                case "tNedit_CustRateGrpCodeZero":
                    {
                        # region [���Ӑ�|����ٰ��]
                        int inputValue = this.tNedit_CustRateGrpCodeZero.GetInt();

                        // ���͖���
                        if (this.tNedit_CustRateGrpCodeZero.DataText.Trim() == "")
                        {
                            this.tEdit_CustRateGrpNm.Clear();
                            this.tNedit_CustRateGrpCodeZero.Clear();
                            this._prevCustRateGrpCode = -1;
                            // ---ADD 2010/09/25----------------------<<<
                            if (!e.ShiftKey)
                            {
                                switch (e.Key)
                                {
                                    case Keys.Up:
                                        {
                                            if (!this.tNedit_CustomerCode.Enabled)
                                            {
                                                e.NextCtrl = null;
                                            }
                                            else
                                            {
                                                this.tNedit_CustomerCode.Focus();
                                            }
                                            break;
                                        }
                                    case Keys.Down:
                                        {
                                            if (!this.tNedit_SupplierCd.Enabled)
                                            {
                                                e.NextCtrl = null;
                                                if (this.Detail_uGrid.Rows.Count != 0)
                                                {
                                                    this.Detail_uGrid.Rows[GetGridInitRowNo()].Cells[GetGridInitColumKey()].Activate();
                                                    this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                                }
                                            }
                                            else
                                            {
                                                this.tNedit_SupplierCd.Focus();
                                            }
                                            break;
                                        }
                                    case Keys.Right:
                                        {
                                            this.CustRateGrpGuide_Button.Focus();
                                            this.tToolbarsManager_MainMenu.Tools[TOOLBAR_GUIDEBUTTON_KEY].SharedProps.Enabled = false;
                                            break;
                                        }
                                    case Keys.Left:
                                        {
                                            e.NextCtrl = null;
                                            break;
                                        }
                                }
                            }
                            if (e.NextCtrl != null)
                            {
                                switch (e.NextCtrl.Name)
                                {
                                    case "tNedit_CustomerCode":
                                    case "tNedit_CustRateGrpCodeZero":
                                    case "tNedit_SupplierCd":
                                    case "tNedit_GoodsMakerCd":
                                        this.tToolbarsManager_MainMenu.Tools["ButtonTool_Guide"].SharedProps.Enabled = true;
                                        break;
                                    case "Detail_uGrid":
                                        {
                                            if ((this.Detail_uGrid.ActiveCell != null) && (this.Detail_uGrid.ActiveCell.Column.Key.Equals(masterCode)))
                                            {
                                                this.tToolbarsManager_MainMenu.Tools["ButtonTool_Guide"].SharedProps.Enabled = true;
                                            }
                                            break;
                                        }
                                    default:
                                        this.tToolbarsManager_MainMenu.Tools["ButtonTool_Guide"].SharedProps.Enabled = false;
                                        break;
                                }
                            }
                            // ---ADD 2010/09/25----------------------<<<
                            return;
                        }
                        else
                        {
                            // ---UPD 2010/09/25---------------------->>>
                            //this.tNedit_CustRateGrpCodeZero.DataText = inputValue.ToString("D4");
                            if (!e.ShiftKey)
                            {
                                switch (e.Key)
                                {
                                    case Keys.Left:
                                        {
                                            break;
                                        }
                                    default:
                                        {
                                            this.tNedit_CustRateGrpCodeZero.DataText = inputValue.ToString("D4");
                                            break;
                                        }
                                }
                            }
                            // ---UPD 2010/09/25----------------------<<<
                        }
                        // �O��l�ƈ�v���Ȃ��ꍇ
                        if (inputValue != this._prevCustRateGrpCode)
                        {
                            string name = string.Empty;
                            bool check = GetCustRateGrpName(inputValue, out name);
                            if (check)
                            {
                                this.tNedit_CustRateGrpCodeZero.DataText = inputValue.ToString("D4");
                                this.tEdit_CustRateGrpNm.Text = name;
                                this._prevCustRateGrpCode = inputValue;
                            }
                            else
                            {
                                // �G���[��
                                TMsgDisp.Show(
                                    this,
                                    emErrorLevel.ERR_LEVEL_INFO,
                                    this.Name,
                                    "���Ӑ�|����ٰ�߂����݂��܂���B",
                                    -1,
                                    MessageBoxButtons.OK);

                                // �R�[�h�߂�
                                // -------UPD 2010/09/26--------->>>>>
                                //this.tNedit_CustRateGrpCodeZero.SetInt(this._prevCustRateGrpCode);
                                //this.tNedit_CustRateGrpCodeZero.Text=""; // UPD 2010/09/09
                                if (this._prevCustRateGrpCode == -1)
                                {
                                    this.tNedit_CustRateGrpCodeZero.Clear();
                                }
                                else
                                {
                                    this.tNedit_CustRateGrpCodeZero.SetInt(this._prevCustRateGrpCode);
                                }
                                // -------UPD 2010/09/26---------<<<<<
                                this.tNedit_CustRateGrpCodeZero.SelectAll();
                                e.NextCtrl = e.PrevCtrl;
                                return;
                            }

                        }
                        # endregion [���Ӑ�|����ٰ��]

                        #region [�t�H�[�J�X����]
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                // -------ADD 2010/09/25--------->>>>>
                                case Keys.Left:
                                    {
                                        e.NextCtrl = null;
                                        break;
                                    }
                                // -------ADD 2010/09/25---------<<<<<
                                // -------ADD 2010/09/26--------->>>>>
                                case Keys.Up:
                                    {
                                        if (!this.tNedit_CustomerCode.Enabled)
                                        {
                                            e.NextCtrl = null;
                                        }
                                        break;
                                    }
                                // -------ADD 2010/09/26---------<<<<<
                                case Keys.LButton: 
                                    {
                                        if(e.NextCtrl==this.Detail_uGrid)
                                        {
                                            this._delBu = true;
                                            
                                        }
                                        break;
                                    }
                                case Keys.Tab:
                                case Keys.Return:
                                    {
                                        if (this.tNedit_CustRateGrpCodeZero.DataText.Trim() == "")
                                        {
                                            e.NextCtrl = this.CustRateGrpGuide_Button;
                                        }
                                        else
                                        {
                                            e.NextCtrl = null;
                                            bool status = SetFocus(3);
                                            if (status == false)
                                            {
                                                if (e.Key == Keys.Return)
                                                {
                                                    //SearchRateData();
                                                    this.Search(); // ADD 2010/09/09
                                                    e.NextCtrl = null;
                                                    // ---ADD 2010/09/26---------------------->>>
                                                    // �����������L�����Z�����ꂽ�ꍇ
                                                    if (this._isCancelFlg)
                                                    {
                                                        // �Ȃ�
                                                    }
                                                    else
                                                    // ---ADD 2010/09/26----------------------<<<
                                                    // ---ADD 2010/09/09---------------------->>>
                                                    //if (this.Detail_uGrid.Rows.Count > 0) // DEL 2010/09/26
                                                    if (this.Detail_uGrid.Rows.Count > 0 && this._checkInputScreenErr == false) // ADD 2010/09/26
                                                    {
                                                        if (this.Mode_Label.Text == INSERT_MODE)
                                                        {
                                                            if (!this._initFocusFlag)
                                                            {
                                                                this.Detail_uGrid.Focus();
                                                                this.Detail_uGrid.ActiveRow = this.Detail_uGrid.Rows[0];
                                                                //this.Detail_uGrid.Rows[0].Cells["MasterNm"].Activate(); // DEL 2010/09/25
                                                                this.Detail_uGrid.Rows[0].Cells[masterCode].Activate(); // ADD 2010/09/25
                                                                this.InitGridFocus(0, 0);
                                                            }
                                                            else
                                                            {
                                                                this._initFocusFlag = false;
                                                            }
                                                        }
                                                        else
                                                        {
                                                            this.Detail_uGrid.Focus();
                                                            this.Detail_uGrid.ActiveRow = this.Detail_uGrid.Rows[0];
                                                            //this.Detail_uGrid.Rows[0].Cells["MasterNm"].Activate(); // DEL 2010/09/25
                                                            this.Detail_uGrid.Rows[0].Cells[masterCode].Activate(); // ADD 2010/09/25
                                                            this.SetGridTabFocus(ref e);
                                                        }
                                                    }
                                                    this._isCancelFlg = false; // ADD 2010/09/26
                                                    this._checkInputScreenErr = false; // ADD 2010/09/26
                                                    // ---ADD 2010/09/09----------------------<<<
                                                }
                                                else
                                                {
                                                    if (this.Detail_uGrid.Rows.Count != 0)
                                                    {
                                                        this.Detail_uGrid.Rows[0].Cells[GetGridInitColumKey()].Activate();
                                                        this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                                        e.NextCtrl = null;
                                                        // ---ADD 2010/09/09---------------------->>>
                                                        if (this.Detail_uGrid.Rows.Count > 0)
                                                        {
                                                            if (this.Mode_Label.Text == INSERT_MODE)
                                                            {
                                                                if (!this._initFocusFlag)
                                                                {
                                                                    this.Detail_uGrid.Focus();
                                                                    this.Detail_uGrid.ActiveRow = this.Detail_uGrid.Rows[0];
                                                                    //this.Detail_uGrid.Rows[0].Cells["MasterNm"].Activate(); // DEL 2010/09/25
                                                                    this.Detail_uGrid.Rows[0].Cells[masterCode].Activate(); // ADD 2010/09/25
                                                                    this.InitGridFocus(0, 0);
                                                                }
                                                                else
                                                                {
                                                                    this._initFocusFlag = false;
                                                                }
                                                            }
                                                            else
                                                            {
                                                                this.Detail_uGrid.Focus();
                                                                this.Detail_uGrid.ActiveRow = this.Detail_uGrid.Rows[0];
                                                                //this.Detail_uGrid.Rows[0].Cells["MasterNm"].Activate(); // DEL 2010/09/25
                                                                this.Detail_uGrid.Rows[0].Cells[masterCode].Activate(); // ADD 2010/09/25
                                                                this.SetGridTabFocus(ref e);
                                                            }
                                                        }
                                                        // ---ADD 2010/09/09----------------------<<<
                                                    }
                                                    else
                                                    {
                                                        e.NextCtrl = null;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    break;
                                case Keys.Down:
                                    {
                                        if (!this.tNedit_SupplierCd.Enabled && this.Detail_uGrid.Rows.Count != 0)
                                        {
                                            // ---UPD 2010/09/25---------------------->>>
                                            //this.Detail_uGrid.Rows[0].Cells[GetGridInitColumKey()].Activate();
                                            //this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                            e.NextCtrl = null;
                                            // ---ADD 2010/09/09---------------------->>>
                                            //if (this.Detail_uGrid.Rows.Count > 0)
                                            //{
                                            //    if (this.Mode_Label.Text == INSERT_MODE)
                                            //    {
                                            //        if (!this._initFocusFlag)
                                            //        {
                                            //            this.Detail_uGrid.Focus();
                                            //            this.Detail_uGrid.ActiveRow = this.Detail_uGrid.Rows[0];
                                            //            //this.Detail_uGrid.Rows[0].Cells["MasterNm"].Activate(); // DEL 2010/09/25
                                            //            this.Detail_uGrid.Rows[0].Cells[masterCode].Activate(); // ADD 2010/09/25
                                            //            this.InitGridFocus(0, 0);
                                            //        }
                                            //        else
                                            //        {
                                            //            this._initFocusFlag = false;
                                            //        }
                                            //    }
                                            //    else
                                            //    {
                                            //        this.Detail_uGrid.Focus();
                                            //        this.Detail_uGrid.ActiveRow = this.Detail_uGrid.Rows[0];
                                            //        //this.Detail_uGrid.Rows[0].Cells["MasterNm"].Activate(); // DEL 2010/09/25
                                            //        this.Detail_uGrid.Rows[0].Cells[masterCode].Activate(); // ADD 2010/09/25
                                            //        this.SetGridTabFocus(ref e);
                                            //    }
                                            //}
                                            // ---ADD 2010/09/09----------------------<<<

                                            this.Detail_uGrid.Rows[GetGridInitRowNo()].Cells[GetGridInitColumKey()].Activate();
                                            this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                            // ---UPD 2010/09/25----------------------<<<
                                        }
                                        else if (!this.tNedit_SupplierCd.Enabled && this.Detail_uGrid.Rows.Count == 0)
                                        {
                                            e.NextCtrl = null;
                                        }
                                    }
                                    break;
                            }
                        }
                        else
                        {
                            if (this._initFocus == this.tNedit_CustRateGrpCodeZero)
                            {
                                switch (e.Key)
                                {
                                    case Keys.Tab:
                                    case Keys.Return:
                                        {
                                            e.NextCtrl = null;
                                        }
                                        break;
                                }
                            }
                        }
                        #endregion [�t�H�[�J�X����]
                        break;
                    }
                //-----------------------------------------------------
                // ���Ӑ�|����ٰ�߃{�^��
                //-----------------------------------------------------
                case "CustRateGrpGuide_Button":
                    {
                        #region [�t�H�[�J�X����]
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                // -------ADD 2010/09/26--------->>>>>
                                case Keys.Up:
                                    {
                                        if (!this.tNedit_CustomerCode.Enabled)
                                        {
                                            e.NextCtrl = null;
                                        }
                                        break;
                                    }
                                // -------ADD 2010/09/26---------<<<<<
                                case Keys.LButton:
                                    {
                                        if (e.NextCtrl == this.Detail_uGrid)
                                        {
                                            this._delBu = true;

                                        }
                                        break;
                                    }
                                case Keys.Tab:
                                case Keys.Return:
                                    {
                                        e.NextCtrl = null;
                                        bool status = SetFocus(3);
                                        if (status == false)
                                        {
                                            if (e.Key == Keys.Return)
                                            {
                                                //SearchRateData();
                                                //this.Search(); // ADD 2010/09/09 // DEL 2010/09/25
                                                bool searchFlg = this.Search(); // ADD 2010/09/09
                                                e.NextCtrl = null;
                                                if (searchFlg == false) return; // ADD 2010/09/25
                                                // ---ADD 2010/09/26---------------------->>>
                                                // �����������L�����Z�����ꂽ�ꍇ
                                                if (this._isCancelFlg)
                                                {
                                                    // �Ȃ�
                                                }
                                                else
                                                // ---ADD 2010/09/26----------------------<<<
                                                // ---ADD 2010/09/09---------------------->>>
                                                //if (this.Detail_uGrid.Rows.Count > 0) // DEL 2010/09/26
                                                if (this.Detail_uGrid.Rows.Count > 0 && this._checkInputScreenErr == false) // ADD 2010/09/26
                                                {
                                                    if (this.Mode_Label.Text == INSERT_MODE)
                                                    {
                                                        if (!this._initFocusFlag)
                                                        {
                                                            this.Detail_uGrid.Focus();
                                                            this.Detail_uGrid.ActiveRow = this.Detail_uGrid.Rows[0];
                                                            //this.Detail_uGrid.Rows[0].Cells["MasterNm"].Activate(); // DEL 2010/09/25
                                                            this.Detail_uGrid.Rows[0].Cells[masterCode].Activate(); // ADD 2010/09/25
                                                            this.InitGridFocus(0, 0);
                                                        }
                                                        else
                                                        {
                                                            this._initFocusFlag = false;
                                                        }
                                                    }
                                                    else
                                                    {
                                                        this.Detail_uGrid.Focus();
                                                        this.Detail_uGrid.ActiveRow = this.Detail_uGrid.Rows[0];
                                                        //this.Detail_uGrid.Rows[0].Cells["MasterNm"].Activate(); // DEL 2010/09/25
                                                        this.Detail_uGrid.Rows[0].Cells[masterCode].Activate(); // ADD 2010/09/25
                                                        this.SetGridTabFocus(ref e);
                                                    }
                                                }
                                                this._isCancelFlg = false; // ADD 2010/09/26
                                                this._checkInputScreenErr = false; // ADD 2010/09/26
                                                // ---ADD 2010/09/09----------------------<<<
                                            }
                                            else
                                            {
                                                if (this.Detail_uGrid.Rows.Count != 0)
                                                {
                                                    this.Detail_uGrid.Rows[0].Cells[GetGridInitColumKey()].Activate();
                                                    this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                                    e.NextCtrl = null;
                                                    // ---ADD 2010/09/09---------------------->>>
                                                    if (this.Detail_uGrid.Rows.Count > 0)
                                                    {
                                                        if (this.Mode_Label.Text == INSERT_MODE)
                                                        {
                                                            if (!this._initFocusFlag)
                                                            {
                                                                this.Detail_uGrid.Focus();
                                                                this.Detail_uGrid.ActiveRow = this.Detail_uGrid.Rows[0];
                                                                //this.Detail_uGrid.Rows[0].Cells["MasterNm"].Activate(); // DEL 2010/09/25
                                                                this.Detail_uGrid.Rows[0].Cells[masterCode].Activate(); // ADD 2010/09/25
                                                                this.InitGridFocus(0, 0);
                                                            }
                                                            else
                                                            {
                                                                this._initFocusFlag = false;
                                                            }
                                                        }
                                                        else
                                                        {
                                                            this.Detail_uGrid.Focus();
                                                            this.Detail_uGrid.ActiveRow = this.Detail_uGrid.Rows[0];
                                                            //this.Detail_uGrid.Rows[0].Cells["MasterNm"].Activate(); // DEL 2010/09/25
                                                            this.Detail_uGrid.Rows[0].Cells[masterCode].Activate(); // ADD 2010/09/25
                                                            this.SetGridTabFocus(ref e);
                                                        }
                                                    }
                                                    // ---ADD 2010/09/09----------------------<<<
                                                }
                                                else
                                                {
                                                    e.NextCtrl = null;
                                                }
                                            }
                                        }
                                    }
                                    break;
                                case Keys.Down:
                                    {
                                        if (!this.SupplierGuide_Button.Enabled && this.Detail_uGrid.Rows.Count != 0)
                                        {
                                            // ---UPD 2010/09/25---------------------->>>
                                            //this.Detail_uGrid.Rows[0].Cells[GetGridInitColumKey()].Activate();
                                            //this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                            e.NextCtrl = null;
                                            // ---ADD 2010/09/09---------------------->>>
                                            //if (this.Detail_uGrid.Rows.Count > 0)
                                            //{
                                            //    if (this.Mode_Label.Text == INSERT_MODE)
                                            //    {
                                            //        if (!this._initFocusFlag)
                                            //        {
                                            //            this.Detail_uGrid.Focus();
                                            //            this.Detail_uGrid.ActiveRow = this.Detail_uGrid.Rows[0];
                                            //            //this.Detail_uGrid.Rows[0].Cells["MasterNm"].Activate(); // DEL 2010/09/25
                                            //            this.Detail_uGrid.Rows[0].Cells[masterCode].Activate(); // ADD 2010/09/25
                                            //            this.InitGridFocus(0, 0);
                                            //        }
                                            //        else
                                            //        {
                                            //            this._initFocusFlag = false;
                                            //        }
                                            //    }
                                            //    else
                                            //    {
                                            //        this.Detail_uGrid.Focus();
                                            //        this.Detail_uGrid.ActiveRow = this.Detail_uGrid.Rows[0];
                                            //        //this.Detail_uGrid.Rows[0].Cells["MasterNm"].Activate(); // DEL 2010/09/25
                                            //        this.Detail_uGrid.Rows[0].Cells[masterCode].Activate(); // ADD 2010/09/25
                                            //        this.SetGridTabFocus(ref e);
                                            //    }
                                            //}
                                            // ---ADD 2010/09/09----------------------<<<

                                            this.Detail_uGrid.Rows[GetGridInitRowNo()].Cells[GetGridInitColumKey()].Activate();
                                            this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);

                                            this.tToolbarsManager_MainMenu.Tools[TOOLBAR_GUIDEBUTTON_KEY].SharedProps.Enabled = false;
                                            // ---UPD 2010/09/25----------------------<<<
                                        }
                                        else if (!this.SupplierGuide_Button.Enabled && this.Detail_uGrid.Rows.Count == 0)
                                        {
                                            e.NextCtrl = null;
                                        }
                                    }
                                    break;
                                // ---ADD 2010/09/25---------------------->>>
                                case Keys.Right:
                                    {
                                        e.NextCtrl = null;
                                        break;
                                    }
                                // ---ADD 2010/09/25----------------------<<<
                            }
                        }
                        #endregion [�t�H�[�J�X����]
                        break;

                    }
                //-----------------------------------------------------
                // �d����R�[�h
                //-----------------------------------------------------
                case "tNedit_SupplierCd":
                    {
                        # region [�d����R�[�h]
                        int inputValue = this.tNedit_SupplierCd.GetInt();

                        // �O��l�ƈ�v���Ȃ��ꍇ
                        if (_prevSupplierCode != inputValue)
                        {
                            // ���͖���
                            if (this.tNedit_SupplierCd.GetInt() == 0)
                            {
                                this.tNedit_SupplierCd.Clear();
                                this.SupplierCdNm_tEdit.Clear();
                                this._prevSupplierCode = 0;
                            }
                            else
                            {
                                string name = string.Empty;
                                bool check = GetSupplierName(inputValue, out name);
                                if (check)
                                {
                                    this.SupplierCdNm_tEdit.Text = name;
                                    this._prevSupplierCode = inputValue;
                                }
                                else
                                {
                                    // �G���[��
                                    TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_INFO,
                                        this.Name,
                                        "�d���悪���݂��܂���B",
                                        -1,
                                        MessageBoxButtons.OK);

                                    // �R�[�h�߂�
                                    this.tNedit_SupplierCd.SetInt(this._prevSupplierCode);
                                    this.tNedit_SupplierCd.SelectAll();
                                    e.NextCtrl = e.PrevCtrl;
                                    return;
                                }

                            }
                        }
                        # endregion [�d����R�[�h]

                        #region [�t�H�[�J�X����]
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                // ---ADD 2010/09/25---------------------->>>
                                case Keys.Left:
                                    {
                                        e.NextCtrl = null;
                                        break;
                                    }
                                // ---ADD 2010/09/25----------------------<<<
                                case Keys.LButton:
                                    {
                                        if (e.NextCtrl == this.Detail_uGrid)
                                        {
                                            this._delBu = true;

                                        }
                                        break;
                                    }
                                case Keys.Tab:
                                case Keys.Return:
                                    {
                                        if (this.tNedit_SupplierCd.GetInt() == 0)
                                        {
                                            e.NextCtrl = this.SupplierGuide_Button;
                                        }
                                        else
                                        {
                                            e.NextCtrl = null;
                                            bool status = SetFocus(3);
                                            if (status == false)
                                            {
                                                if (e.Key == Keys.Return)
                                                {
                                                    //SearchRateData();
                                                    this.Search(); // ADD 2010/09/09
                                                    e.NextCtrl = null;
                                                    // ---ADD 2010/09/26---------------------->>>
                                                    // �����������L�����Z�����ꂽ�ꍇ
                                                    if (this._isCancelFlg)
                                                    {
                                                        // �Ȃ�
                                                    }
                                                    else
                                                    // ---ADD 2010/09/26----------------------<<<
                                                    // ---ADD 2010/09/09---------------------->>>
                                                    //if (this.Detail_uGrid.Rows.Count > 0) // DEL 2010/09/26
                                                    if (this.Detail_uGrid.Rows.Count > 0 && this._checkInputScreenErr == false) // ADD 2010/09/26
                                                    {
                                                        if (this.Mode_Label.Text == INSERT_MODE)
                                                        {
                                                            if (!this._initFocusFlag)
                                                            {
                                                                this.Detail_uGrid.Focus();
                                                                this.Detail_uGrid.ActiveRow = this.Detail_uGrid.Rows[0];
                                                                //this.Detail_uGrid.Rows[0].Cells["MasterNm"].Activate(); // DEL 2010/09/25
                                                                this.Detail_uGrid.Rows[0].Cells[masterCode].Activate(); // ADD 2010/09/25
                                                                this.InitGridFocus(0, 0);
                                                            }
                                                            else
                                                            {
                                                                this._initFocusFlag = false;
                                                            }
                                                        }
                                                        else
                                                        {
                                                            this.Detail_uGrid.Focus();
                                                            this.Detail_uGrid.ActiveRow = this.Detail_uGrid.Rows[0];
                                                            //this.Detail_uGrid.Rows[0].Cells["MasterNm"].Activate(); // DEL 2010/09/25
                                                            this.Detail_uGrid.Rows[0].Cells[masterCode].Activate(); // ADD 2010/09/25
                                                            this.SetGridTabFocus(ref e);
                                                        }
                                                    }
                                                    this._isCancelFlg = false; // ADD 2010/09/26
                                                    this._checkInputScreenErr = false; // ADD 2010/09/26
                                                    // ---ADD 2010/09/09----------------------<<<
                                                }
                                                else
                                                {
                                                    if (this.Detail_uGrid.Rows.Count != 0)
                                                    {
                                                        this.Detail_uGrid.Rows[0].Cells[GetGridInitColumKey()].Activate();
                                                        this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                                        e.NextCtrl = null;
                                                        // ---ADD 2010/09/09---------------------->>>
                                                        if (this.Detail_uGrid.Rows.Count > 0)
                                                        {
                                                            if (this.Mode_Label.Text == INSERT_MODE)
                                                            {
                                                                if (!this._initFocusFlag)
                                                                {
                                                                    this.Detail_uGrid.Focus();
                                                                    this.Detail_uGrid.ActiveRow = this.Detail_uGrid.Rows[0];
                                                                    //this.Detail_uGrid.Rows[0].Cells["MasterNm"].Activate(); // DEL 2010/09/25
                                                                    this.Detail_uGrid.Rows[0].Cells[masterCode].Activate(); // ADD 2010/09/25
                                                                    this.InitGridFocus(0, 0);
                                                                }
                                                                else
                                                                {
                                                                    this._initFocusFlag = false;
                                                                }
                                                            }
                                                            else
                                                            {
                                                                this.Detail_uGrid.Focus();
                                                                this.Detail_uGrid.ActiveRow = this.Detail_uGrid.Rows[0];
                                                                //this.Detail_uGrid.Rows[0].Cells["MasterNm"].Activate(); // DEL 2010/09/25
                                                                this.Detail_uGrid.Rows[0].Cells[masterCode].Activate(); // ADD 2010/09/25
                                                                this.SetGridTabFocus(ref e);
                                                            }
                                                        }
                                                        // ---ADD 2010/09/09----------------------<<<
                                                    }
                                                    else
                                                    {
                                                        e.NextCtrl = null;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    break;
                                case Keys.Down:
                                    {
                                        if (this.Detail_uGrid.Rows.Count != 0)
                                        {
                                            // ---UPD 2010/09/25---------------------->>>
                                            //this.Detail_uGrid.Rows[0].Cells[GetGridInitColumKey()].Activate();
                                            //this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                            e.NextCtrl = null;
                                            // ---ADD 2010/09/09---------------------->>>
                                            //if (this.Detail_uGrid.Rows.Count > 0)
                                            //{
                                            //    if (this.Mode_Label.Text == INSERT_MODE)
                                            //    {
                                            //        if (!this._initFocusFlag)
                                            //        {
                                            //            this.Detail_uGrid.Focus();
                                            //            this.Detail_uGrid.ActiveRow = this.Detail_uGrid.Rows[SelectedRow()];
                                            //            //this.Detail_uGrid.Rows[SelectedRow()].Cells["MasterNm"].Activate(); // DEL 2010/09/25
                                            //            this.Detail_uGrid.Rows[SelectedRow()].Cells[masterCode].Activate(); // ADD 2010/09/25
                                            //            this.InitGridFocus(0, 0);
                                            //        }
                                            //        else
                                            //        {
                                            //            this._initFocusFlag = false;
                                            //        }
                                            //    }
                                            //    else
                                            //    {
                                            //        this.Detail_uGrid.Focus();
                                            //        this.Detail_uGrid.ActiveRow = this.Detail_uGrid.Rows[SelectedRow()];
                                            //        //this.Detail_uGrid.Rows[SelectedRow()].Cells["MasterNm"].Activate(); // DEL 2010/09/25
                                            //        this.Detail_uGrid.Rows[SelectedRow()].Cells[masterCode].Activate(); // ADD 2010/09/25
                                            //        this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                            //    }
                                            //}
                                            // ---ADD 2010/09/09----------------------<<<

                                            this.Detail_uGrid.Rows[GetGridInitRowNo()].Cells[GetGridInitColumKey()].Activate();
                                            this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                            // ---UPD 2010/09/25----------------------<<<
                                        }
                                        else
                                        {
                                            e.NextCtrl = null;
                                        }
                                    }
                                    break;
                            }
                        }
                        else
                        {
                            if (this._initFocus == this.tNedit_SupplierCd)
                            {
                                switch (e.Key)
                                {
                                    case Keys.Tab:
                                    case Keys.Return:
                                        {
                                            e.NextCtrl = null;
                                        }
                                        break;
                                }
                            }
                        }
                        #endregion [�t�H�[�J�X����]
                        break;
                    }
                //-----------------------------------------------------
                // �d����{�^��
                //-----------------------------------------------------
                case "SupplierGuide_Button":
                    {
                        #region [�t�H�[�J�X����]
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                // ---ADD 2010/09/25---------------------->>>
                                case Keys.Right:
                                    {
                                        e.NextCtrl = null;
                                        break;
                                    }
                                // ---ADD 2010/09/25----------------------<<<
                                case Keys.LButton:
                                    {
                                        if (e.NextCtrl == this.Detail_uGrid)
                                        {
                                            this._delBu = true;

                                        }
                                        break;
                                    }
                                case Keys.Tab:
                                case Keys.Return:
                                    {
                                        e.NextCtrl = null;
                                        bool status = SetFocus(3);
                                        if (status == false)
                                        {
                                            if (e.Key == Keys.Return)
                                            {
                                                //SearchRateData();
                                                this.Search(); // ADD 2010/09/09
                                                e.NextCtrl = null;
                                                // ---ADD 2010/09/26---------------------->>>
                                                // �����������L�����Z�����ꂽ�ꍇ
                                                if (this._isCancelFlg)
                                                {
                                                    // �Ȃ�
                                                }
                                                else
                                                // ---ADD 2010/09/26----------------------<<<
                                                // ---ADD 2010/09/09---------------------->>>
                                                //if (this.Detail_uGrid.Rows.Count > 0) // DEL 2010/09/26
                                                if (this.Detail_uGrid.Rows.Count > 0 && this._checkInputScreenErr == false) // ADD 2010/09/26
                                                {
                                                    if (this.Mode_Label.Text == INSERT_MODE)
                                                    {
                                                        if (!this._initFocusFlag)
                                                        {
                                                            this.Detail_uGrid.Focus();
                                                            this.Detail_uGrid.ActiveRow = this.Detail_uGrid.Rows[0];
                                                            //this.Detail_uGrid.Rows[0].Cells["MasterNm"].Activate(); // DEL 2010/09/25
                                                            this.Detail_uGrid.Rows[0].Cells[masterCode].Activate(); // ADD 2010/09/25
                                                            this.InitGridFocus(0, 0);
                                                        }
                                                        else
                                                        {
                                                            this._initFocusFlag = false;
                                                        }
                                                    }
                                                    else
                                                    {
                                                        this.Detail_uGrid.Focus();
                                                        this.Detail_uGrid.ActiveRow = this.Detail_uGrid.Rows[0];
                                                        //this.Detail_uGrid.Rows[0].Cells["MasterNm"].Activate(); // DEL 2010/09/25
                                                        this.Detail_uGrid.Rows[0].Cells[masterCode].Activate(); // ADD 2010/09/25
                                                        this.SetGridTabFocus(ref e);
                                                    }
                                                }
                                                this._isCancelFlg = false; // ADD 2010/09/26
                                                this._checkInputScreenErr = false; // ADD 2010/09/26
                                                // ---ADD 2010/09/09----------------------<<<
                                            }
                                            else
                                            {
                                                if (this.Detail_uGrid.Rows.Count != 0)
                                                {
                                                    this.Detail_uGrid.Rows[0].Cells[GetGridInitColumKey()].Activate();
                                                    this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                                    e.NextCtrl = null;
                                                    // ---ADD 2010/09/09---------------------->>>
                                                    if (this.Detail_uGrid.Rows.Count > 0)
                                                    {
                                                        if (this.Mode_Label.Text == INSERT_MODE)
                                                        {
                                                            if (!this._initFocusFlag)
                                                            {
                                                                this.Detail_uGrid.Focus();
                                                                this.Detail_uGrid.ActiveRow = this.Detail_uGrid.Rows[0];
                                                                //this.Detail_uGrid.Rows[0].Cells["MasterNm"].Activate(); // DEL 2010/09/25
                                                                this.Detail_uGrid.Rows[0].Cells[masterCode].Activate(); // ADD 2010/09/25
                                                                this.InitGridFocus(0, 0);
                                                            }
                                                            else
                                                            {
                                                                this._initFocusFlag = false;
                                                            }
                                                        }
                                                        else
                                                        {
                                                            this.Detail_uGrid.Focus();
                                                            this.Detail_uGrid.ActiveRow = this.Detail_uGrid.Rows[0];
                                                            //this.Detail_uGrid.Rows[0].Cells["MasterNm"].Activate(); // DEL 2010/09/25
                                                            this.Detail_uGrid.Rows[0].Cells[masterCode].Activate(); // ADD 2010/09/25
                                                            this.SetGridTabFocus(ref e);
                                                        }
                                                    }
                                                    // ---ADD 2010/09/09----------------------<<<
                                                }
                                                else
                                                {
                                                    e.NextCtrl = null;
                                                }
                                            }
                                        }
                                    }
                                    break;
                                case Keys.Down:
                                    {
                                        if (this.Detail_uGrid.Rows.Count != 0)
                                        {
                                            // ---UPD 2010/09/25---------------------->>>
                                            //this.Detail_uGrid.Rows[0].Cells[GetGridInitColumKey()].Activate();
                                            //this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                            e.NextCtrl = null;
                                            // ---ADD 2010/09/09---------------------->>>
                                            //if (this.Detail_uGrid.Rows.Count > 0)
                                            //{
                                            //    if (this.Mode_Label.Text == INSERT_MODE)
                                            //    {
                                            //        if (!this._initFocusFlag)
                                            //        {
                                            //            this.Detail_uGrid.Focus();
                                            //            this.Detail_uGrid.ActiveRow = this.Detail_uGrid.Rows[SelectedRow()];
                                            //            //this.Detail_uGrid.Rows[SelectedRow()].Cells["MasterNm"].Activate(); // DEL 2010/09/25
                                            //            this.Detail_uGrid.Rows[SelectedRow()].Cells[masterCode].Activate(); // ADD 2010/09/25
                                            //            this.InitGridFocus(0, 0);
                                            //        }
                                            //        else
                                            //        {
                                            //            this._initFocusFlag = false;
                                            //        }
                                            //    }
                                            //    else
                                            //    {
                                            //        //this.Detail_uGrid.Focus();
                                            //        //this.Detail_uGrid.ActiveRow = this.Detail_uGrid.Rows[0];
                                            //        //this.Detail_uGrid.Rows[0].Cells["MasterNm"].Activate();
                                            //        //this.SetGridTabFocus(ref e);
                                            //        this.Detail_uGrid.Focus();
                                            //        this.Detail_uGrid.ActiveRow = this.Detail_uGrid.Rows[SelectedRow()];
                                            //        //this.Detail_uGrid.Rows[SelectedRow()].Cells["MasterNm"].Activate(); // DEL 2010/09/25
                                            //        this.Detail_uGrid.Rows[SelectedRow()].Cells[masterCode].Activate(); // ADD 2010/09/25
                                            //        //this.SetGridTabFocus(ref e);
                                            //        this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                            //    }
                                            //}
                                            // ---ADD 2010/09/09----------------------<<<

                                            this.Detail_uGrid.Rows[GetGridInitRowNo()].Cells[GetGridInitColumKey()].Activate();
                                            this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);

                                            this.tToolbarsManager_MainMenu.Tools[TOOLBAR_GUIDEBUTTON_KEY].SharedProps.Enabled = false;
                                            // ---UPD 2010/09/25----------------------<<<
                                        }
                                        else
                                        {
                                            e.NextCtrl = null;
                                        }
                                    }
                                    break;
                            }
                        }
                        #endregion [�t�H�[�J�X����]
                        break;
                    }
                //-----------------------------------------------------
                // ���[�J�[
                //-----------------------------------------------------
                case "tNedit_GoodsMakerCd":
                    {
                        # region [���[�J�[]
                        int inputValue = this.tNedit_GoodsMakerCd.GetInt();

                        // �O��l�ƈ�v���Ȃ��ꍇ
                        if (_prevMakerCode != inputValue)
                        {
                            // ���͖���
                            if (this.tNedit_GoodsMakerCd.GetInt() == 0)
                            {
                                this.tNedit_GoodsMakerCd.Clear();
                                this.MakerName_tEdit.Clear();
                                this._prevMakerCode = 0;
                            }
                            else
                            {
                                string name = string.Empty;
                                bool check = GetMakerName(inputValue, out name);
                                if (check)
                                {
                                    this.MakerName_tEdit.Text = name;
                                    this._prevMakerCode = inputValue;
                                }
                                else
                                {
                                    // �G���[��
                                    TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_INFO,
                                        this.Name,
                                        "���[�J�[�}�X�^�����o�^�ł��B",
                                        -1,
                                        MessageBoxButtons.OK);

                                    // �R�[�h�߂�
                                    this.tNedit_GoodsMakerCd.SetInt(this._prevMakerCode);
                                    this.tNedit_GoodsMakerCd.SelectAll();
                                    e.NextCtrl = e.PrevCtrl;
                                    return;
                                }
                            }

                        }
                        # endregion [���[�J�[]

                        #region [�t�H�[�J�X����]
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.LButton:
                                    {
                                        if (e.NextCtrl == this.Detail_uGrid)
                                        {
                                            this._delBu = true;

                                        }
                                        break;
                                    }
                                case Keys.Tab:
                                case Keys.Return:
                                    {
                                        if (this.tNedit_GoodsMakerCd.GetInt() == 0)
                                        {
                                            e.NextCtrl = this.MakerGuide_Button;
                                        }
                                        else
                                        {
                                            e.NextCtrl = null;
                                            bool status = SetFocus(3);
                                            if (status == false)
                                            {
                                                if (e.Key == Keys.Return || e.Key == Keys.Tab)
                                                {
                                                    //SearchRateData();
                                                    this.Search(); // ADD 2010/09/09
                                                    e.NextCtrl = null;
                                                    // ---ADD 2010/09/26---------------------->>>
                                                    // �����������L�����Z�����ꂽ�ꍇ
                                                    if (this._isCancelFlg)
                                                    {
                                                        // �Ȃ�
                                                    }
                                                    else
                                                    // ---ADD 2010/09/26----------------------<<<
                                                    // ---ADD 2010/09/09---------------------->>>
                                                    //if (this.Detail_uGrid.Rows.Count > 0) // DEL 2010/09/26
                                                    if (this.Detail_uGrid.Rows.Count > 0 && this._checkInputScreenErr == false) // ADD 2010/09/26
                                                    {
                                                        if (this.Mode_Label.Text == INSERT_MODE)
                                                        {
                                                            if (!this._initFocusFlag)
                                                            {
                                                                this.Detail_uGrid.Focus();
                                                                this.Detail_uGrid.ActiveRow = this.Detail_uGrid.Rows[0];
                                                                //this.Detail_uGrid.Rows[0].Cells["MasterNm"].Activate(); // DEL 2010/09/25
                                                                this.Detail_uGrid.Rows[0].Cells[masterCode].Activate(); // ADD 2010/09/25
                                                                this.InitGridFocus(0, 0);
                                                            }
                                                            else
                                                            {
                                                                this._initFocusFlag = false;
                                                            }
                                                        }
                                                        else
                                                        {
                                                            this.Detail_uGrid.Focus();
                                                            this.Detail_uGrid.ActiveRow = this.Detail_uGrid.Rows[0];
                                                            //this.Detail_uGrid.Rows[0].Cells["MasterNm"].Activate(); // DEL 2010/09/25
                                                            this.Detail_uGrid.Rows[0].Cells[masterCode].Activate(); // ADD 2010/09/25
                                                            this.SetGridTabFocus(ref e);
                                                        }
                                                    }
                                                    this._isCancelFlg = false; // ADD 2010/09/26
                                                    this._checkInputScreenErr = false; // ADD 2010/09/26
                                                    // ---ADD 2010/09/09----------------------<<<
                                                }
                                                else
                                                {
                                                    if (this.Detail_uGrid.Rows.Count != 0)
                                                    {
                                                        this.Detail_uGrid.Rows[0].Cells[GetGridInitColumKey()].Activate();
                                                        this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                                        e.NextCtrl = null;
                                                        // ---ADD 2010/09/09---------------------->>>
                                                        if (this.Detail_uGrid.Rows.Count > 0)
                                                        {
                                                            if (this.Mode_Label.Text == INSERT_MODE)
                                                            {
                                                                if (!this._initFocusFlag)
                                                                {
                                                                    this.Detail_uGrid.Focus();
                                                                    this.Detail_uGrid.ActiveRow = this.Detail_uGrid.Rows[0];
                                                                    //this.Detail_uGrid.Rows[0].Cells["MasterNm"].Activate(); // DEL 2010/09/25
                                                                    this.Detail_uGrid.Rows[0].Cells[masterCode].Activate(); // ADD 2010/09/25
                                                                    this.InitGridFocus(0, 0);
                                                                }
                                                                else
                                                                {
                                                                    this._initFocusFlag = false;
                                                                }
                                                            }
                                                            else
                                                            {
                                                                this.Detail_uGrid.Focus();
                                                                this.Detail_uGrid.ActiveRow = this.Detail_uGrid.Rows[0];
                                                                //this.Detail_uGrid.Rows[0].Cells["MasterNm"].Activate(); // DEL 2010/09/25
                                                                this.Detail_uGrid.Rows[0].Cells[masterCode].Activate(); // ADD 2010/09/25
                                                                this.SetGridTabFocus(ref e);
                                                            }
                                                        }
                                                        // ---ADD 2010/09/09----------------------<<<
                                                    }
                                                    else
                                                    {
                                                        e.NextCtrl = null;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    break;
                                case Keys.Down:
                                    {
                                        if (!this.tNedit_CustRateGrpCodeZero.Enabled && !this.tNedit_SupplierCd.Enabled && this.Detail_uGrid.Rows.Count != 0)
                                        {
                                            // ---UPD 2010/09/25---------------------->>>
                                            //this.Detail_uGrid.Rows[0].Cells[GetGridInitColumKey()].Activate();
                                            //this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                            e.NextCtrl = null;
                                            // ---ADD 2010/09/09---------------------->>>
                                            //if (this.Detail_uGrid.Rows.Count > 0)
                                            //{
                                            //    if (this.Mode_Label.Text == INSERT_MODE)
                                            //    {
                                            //        if (!this._initFocusFlag)
                                            //        {
                                            //            this.Detail_uGrid.Focus();
                                            //            this.Detail_uGrid.ActiveRow = this.Detail_uGrid.Rows[0];
                                            //            //this.Detail_uGrid.Rows[0].Cells["MasterNm"].Activate(); // DEL 2010/09/25
                                            //            this.Detail_uGrid.Rows[0].Cells[masterCode].Activate(); // ADD 2010/09/25
                                            //            this.InitGridFocus(0, 0);
                                            //        }
                                            //        else
                                            //        {
                                            //            this._initFocusFlag = false;
                                            //        }
                                            //    }
                                            //    else
                                            //    {
                                            //        this.Detail_uGrid.Focus();
                                            //        this.Detail_uGrid.ActiveRow = this.Detail_uGrid.Rows[0];
                                            //        //this.Detail_uGrid.Rows[0].Cells["MasterNm"].Activate(); // DEL 2010/09/25
                                            //        this.Detail_uGrid.Rows[0].Cells[masterCode].Activate(); // ADD 2010/09/25
                                            //        this.SetGridTabFocus(ref e);
                                            //    }
                                            //}
                                            // ---ADD 2010/09/09----------------------<<<

                                            this.Detail_uGrid.Rows[GetGridInitRowNo()].Cells[GetGridInitColumKey()].Activate();
                                            this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                            // ---UPD 2010/09/25----------------------<<<
                                        }
                                        else if (!this.CustRateGrpGuide_Button.Enabled && !this.SupplierGuide_Button.Enabled && this.Detail_uGrid.Rows.Count == 0)
                                        {
                                            e.NextCtrl = null;
                                        }
                                    }
                                    break;
                                // ---ADD 2010/09/25---------------------->>>
                                case Keys.Up:
                                    {
                                        e.NextCtrl = null;
                                        this.tToolbarsManager_MainMenu.Tools["ButtonTool_Guide"].SharedProps.Enabled = true;
                                    }
                                    break;
                                case Keys.Left:
                                    {
                                        if (!this.tNedit_CustomerCode.Enabled)
                                        {
                                            e.NextCtrl = null;
                                        }
                                    }
                                    break;
                                // ---ADD 2010/09/25----------------------<<<
                            }
                        }
                        else
                        {
                            if (this._initFocus == this.tNedit_GoodsMakerCd)
                            {
                                switch (e.Key)
                                {
                                    case Keys.Tab:
                                    case Keys.Return:
                                        {
                                            e.NextCtrl = null;
                                        }
                                        break;
                                    // ---ADD 2010/09/09---------------------->>>
                                    case Keys.Up:
                                        {
                                            e.NextCtrl = null;
                                        }
                                        break;
                                    // ---ADD 2010/09/09----------------------<<<
                                }
                            }
                        }
                        #endregion [�t�H�[�J�X����]
                        break;
                    }
                //-----------------------------------------------------
                // ���[�J�[�{�^��
                //-----------------------------------------------------
                case "MakerGuide_Button":
                    {
                        #region [�t�H�[�J�X����]
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.LButton:
                                    {
                                        if (e.NextCtrl == this.Detail_uGrid)
                                        {
                                            this._delBu = true;

                                        }
                                        break;
                                    }
                                case Keys.Tab:
                                case Keys.Return:
                                    {
                                        if (e.Key == Keys.Return || e.Key == Keys.Tab)
                                        {
                                            //SearchRateData();
                                            this.Search(); // ADD 2010/09/09
                                            e.NextCtrl = null;
                                            // ---ADD 2010/09/26---------------------->>>
                                            // �����������L�����Z�����ꂽ�ꍇ
                                            if (this._isCancelFlg)
                                            {
                                                // �Ȃ�
                                            }
                                            else
                                            // ---ADD 2010/09/26----------------------<<<
                                            // ---ADD 2010/09/09---------------------->>>
                                            //if (this.Detail_uGrid.Rows.Count > 0) // DEL 2010/09/26
                                            if (this.Detail_uGrid.Rows.Count > 0 && this._checkInputScreenErr == false) // ADD 2010/09/26
                                            {
                                                if (this.Mode_Label.Text == INSERT_MODE)
                                                {
                                                    if (!this._initFocusFlag)
                                                    {
                                                        this.Detail_uGrid.Focus();
                                                        this.Detail_uGrid.ActiveRow = this.Detail_uGrid.Rows[0];
                                                        //this.Detail_uGrid.Rows[0].Cells["MasterNm"].Activate(); // DEL 2010/09/25
                                                        this.Detail_uGrid.Rows[0].Cells[masterCode].Activate(); // ADD 2010/09/25
                                                        this.InitGridFocus(0, 0);
                                                    }
                                                    else
                                                    {
                                                        this._initFocusFlag = false;
                                                    }
                                                }
                                                else
                                                {
                                                    this.Detail_uGrid.Focus();
                                                    this.Detail_uGrid.ActiveRow = this.Detail_uGrid.Rows[0];
                                                    //this.Detail_uGrid.Rows[0].Cells["MasterNm"].Activate(); // DEL 2010/09/25
                                                    this.Detail_uGrid.Rows[0].Cells[masterCode].Activate(); // ADD 2010/09/25
                                                    this.SetGridTabFocus(ref e);
                                                }
                                            }
                                            this._isCancelFlg = false; // ADD 2010/09/26
                                            this._checkInputScreenErr = false; // ADD 2010/09/26
                                            // ---ADD 2010/09/09----------------------<<<
                                        }
                                        else
                                        {
                                            if (this.Detail_uGrid.Rows.Count != 0)
                                            {
                                                this.Detail_uGrid.Rows[0].Cells[GetGridInitColumKey()].Activate();
                                                this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                                e.NextCtrl = null;
                                                // ---ADD 2010/09/09---------------------->>>
                                                if (this.Detail_uGrid.Rows.Count > 0)
                                                {
                                                    if (this.Mode_Label.Text == INSERT_MODE)
                                                    {
                                                        if (!this._initFocusFlag)
                                                        {
                                                            this.Detail_uGrid.Focus();
                                                            this.Detail_uGrid.ActiveRow = this.Detail_uGrid.Rows[0];
                                                            //this.Detail_uGrid.Rows[0].Cells["MasterNm"].Activate(); // DEL 2010/09/25
                                                            this.Detail_uGrid.Rows[0].Cells[masterCode].Activate(); // ADD 2010/09/25
                                                            this.InitGridFocus(0, 0);
                                                        }
                                                        else
                                                        {
                                                            this._initFocusFlag = false;
                                                        }
                                                    }
                                                    else
                                                    {
                                                        this.Detail_uGrid.Focus();
                                                        this.Detail_uGrid.ActiveRow = this.Detail_uGrid.Rows[0];
                                                        //this.Detail_uGrid.Rows[0].Cells["MasterNm"].Activate(); // DEL 2010/09/25
                                                        this.Detail_uGrid.Rows[0].Cells[masterCode].Activate(); // ADD 2010/09/25
                                                        this.SetGridTabFocus(ref e);
                                                    }
                                                }
                                                // ---ADD 2010/09/09----------------------<<<
                                            }
                                            else
                                            {
                                                e.NextCtrl = null;
                                            }
                                        }
                                    }
                                    break;
                                case Keys.Down:
                                    {
                                        //if (!this.tNedit_CustRateGrpCodeZero.Enabled && !this.tNedit_SupplierCd.Enabled && this.Detail_uGrid.Rows.Count != 0) // DEL 2010/09/21
                                        //if (this.Detail_uGrid.Rows.Count != 0) // ADD 2010/09/21 // DEL 2010/09/25
                                        if (!this.tNedit_CustRateGrpCodeZero.Enabled && !this.tNedit_SupplierCd.Enabled && this.Detail_uGrid.Rows.Count != 0) // ADD 2010/09/21
                                        {
                                            //this.Detail_uGrid.Rows[0].Cells[GetGridInitColumKey()].Activate(); // DEL 2010/09/25
                                            //this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode); // DEL 2010/09/25
                                            e.NextCtrl = null;
                                            //	---UPD 2010/09/21----------------------------->>>
                                            // ---UPD 2010/09/25---------------------->>>
                                            // ---ADD 2010/09/09---------------------->>>
                                            //if (this.Mode_Label.Text == INSERT_MODE)
                                            //{
                                            //    if (!this._initFocusFlag)
                                            //    {
                                            //        this.Detail_uGrid.Focus();
                                            //        this.Detail_uGrid.ActiveRow = this.Detail_uGrid.Rows[0];
                                            //        //this.Detail_uGrid.Rows[0].Cells["MasterNm"].Activate(); // DEL 2010/09/25
                                            //        this.Detail_uGrid.Rows[0].Cells[masterCode].Activate(); // ADD 2010/09/25
                                            //        this.InitGridFocus(0, 0);
                                            //    }
                                            //    else
                                            //    {
                                            //        this._initFocusFlag = false;
                                            //    }
                                            //}
                                            //else
                                            //{
                                            //    this.Detail_uGrid.Focus();
                                            //    this.Detail_uGrid.ActiveRow = this.Detail_uGrid.Rows[0];
                                            //    //this.Detail_uGrid.Rows[0].Cells["MasterNm"].Activate(); // DEL 2010/09/25
                                            //    this.Detail_uGrid.Rows[0].Cells[masterCode].Activate(); // ADD 2010/09/25
                                            //    this.SetGridTabFocus(ref e);
                                            //}
                                            // ---ADD 2010/09/09----------------------<<<

                                            this.Detail_uGrid.Rows[GetGridInitRowNo()].Cells[GetGridInitColumKey()].Activate();
                                            this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);

                                            this.tToolbarsManager_MainMenu.Tools[TOOLBAR_GUIDEBUTTON_KEY].SharedProps.Enabled = false;
                                            // ---UPD 2010/09/25----------------------<<<
                                        }
                                        // ---UPD 2010/09/25----------------------<<<
                                        //else
                                        //{
                                        //    e.NextCtrl = null;
                                        //}
                                        else if (!this.CustRateGrpGuide_Button.Enabled && !this.SupplierGuide_Button.Enabled && this.Detail_uGrid.Rows.Count == 0)
                                        {
                                            e.NextCtrl = null;
                                        }
                                        // ---UPD 2010/09/25----------------------<<<
										//	---UPD 2010/09/21----------------------------->>>
                                    }
                                    break;
                                // ---ADD 2010/09/09---------------------->>>
                                case Keys.Up:
                                    {
                                        e.NextCtrl = null;
                                    }
                                    break;
                                case Keys.Right:
                                    {
                                        e.NextCtrl = null;
                                    }
                                    break;
                                // ---ADD 2010/09/09----------------------<<<
                            }
                        }
						// ---ADD 2010/09/21---------------------->>>
                        else
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                    {
                                        SetFocus(4);
                                        e.NextCtrl = null;
                                    }
                                    break;
                            }
                        }
						// ---ADD 2010/09/21----------------------<<<
                        #endregion [�t�H�[�J�X����]
                        break;

                    }
                //-----------------------------------------------------
                // ����
                //-----------------------------------------------------
                case "Detail_uGrid":
                    {
                        // ---ADD 2010/09/09---------------------->>>
                        #region ���[�������敪�`�F�b�N
                        if ((this.Detail_uGrid.ActiveCell != null) && this.Detail_uGrid.ActiveCell.Column.Key.Equals("UnPrcFracProcDivNm"))
                        {
                            switch (this.Detail_uGrid.ActiveCell.Text)
                            {
                                case "1":
                                case "1:�؎̂�":
                                case "2":
                                case "2:�l�̌ܓ�":
                                case "3":
                                case "3:�؏グ":
                                    break;
                                default:
                                    this.Detail_uGrid.ActiveCell.Value = 2;
                                    break;
                            }
                        }
                        #endregion
                        //---ADD 2010/09/09----------------------<<<
                        # region [�t�H�[�J�X����]
                        if (this.Detail_uGrid.Rows.Count == 0)
                        {
                            //---ADD 2010/09/09---------------------->>>
                            #region ���K�C�h�L�������̐ݒ�
                            if (e.NextCtrl == this.tNedit_CustomerCode || e.NextCtrl == this.tNedit_CustRateGrpCodeZero || e.NextCtrl == this.tNedit_SupplierCd || e.NextCtrl == tNedit_GoodsMakerCd)
                            {
                                this.tToolbarsManager_MainMenu.Tools["ButtonTool_Guide"].SharedProps.Enabled = true;
                            }
                            #endregion
                            //---ADD 2010/09/09----------------------<<<
                            return;
                        }
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                            {
                                // --- ADD 2010/09/09 ---------->>>>>
                                this.Detail_uGrid.PerformAction(UltraGridAction.ExitEditMode);
                                this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                if (_errorFlg)
                                {
                                    e.NextCtrl = null;
                                    this._errorFlg = false;
                                    break;
                                }
                                // --- ADD 2010/09/09 ----------<<<<<

                                // --- ADD 2010/09/25 ---------->>>>>
                                if (_errorFlg2)
                                {
                                    e.NextCtrl = null;
                                    this._errorFlg2 = false;
                                    break;
                                }
                                // --- ADD 2010/09/25 ----------<<<<<
                                // �O���b�h�^�u�ړ�����
                                SetGridTabFocus(ref e);
                            }
                        }
                        else
                        {
                            if (e.Key == Keys.Tab || e.Key == Keys.Return) 
                            {
                                // �O���b�h�V�t�g�^�u�ړ�����
                                SetGridShiftTabFocus(ref e);

                            }
                        }
                        // --- ADD 2010/09/10 ---------->>>>>
                        if (e.NextCtrl != null)
                        {
                            if (e.NextCtrl.CanSelect)
                            {
                                if (e.NextCtrl != Delete_Button && e.NextCtrl != DeleteAll_Button)
                                {
                                    this.Detail_uGrid.ActiveCell = null;
                                    this.Detail_uGrid.ActiveRow = null;
                                }
                                
                            }
                        }
                        // --- ADD 2010/09/10 ----------<<<<<
                        #endregion
                        break;
                    }
            }
            // ---ADD 2010/09/09---------------------->>>
            #region ���K�C�h�L�������̐ݒ�
            if (this.Detail_uGrid.ActiveCell != null)
            {
                string columnKey = this.Detail_uGrid.ActiveCell.Column.Key;
                int columnIndex = 0;
                if (e.ShiftKey && e.Key == Keys.Tab)
                {
                    columnIndex = GetNextColumnIndexByTab(1, this.Detail_uGrid.Rows.Count - 1, columnKey);
                }
                //if (this.Detail_uGrid.ActiveCell.Column.Key.Equals("MasterNm") && columnIndex >= 0) // DEL 2010/09/25
                if (this.Detail_uGrid.ActiveCell.Column.Key.Equals(masterCode) && columnIndex >= 0) // ADD 2010/09/25
                {
                    this.tToolbarsManager_MainMenu.Tools["ButtonTool_Guide"].SharedProps.Enabled = true;
                }
                else
                {
                    this.tToolbarsManager_MainMenu.Tools["ButtonTool_Guide"].SharedProps.Enabled = false;
                }
            }
            else
            {
                this.tToolbarsManager_MainMenu.Tools["ButtonTool_Guide"].SharedProps.Enabled = false;
            }

            if (e.NextCtrl != null)
            {
                switch (e.NextCtrl.Name)
                {
                    case "tNedit_CustomerCode":
                    case "tNedit_CustRateGrpCodeZero":
                    case "tNedit_SupplierCd":
                    case "tNedit_GoodsMakerCd": // ADD 2010/09/09
                        this.tToolbarsManager_MainMenu.Tools["ButtonTool_Guide"].SharedProps.Enabled = true;
                        break;
                    case "Detail_uGrid":
                        {
                            //if ((this.Detail_uGrid.ActiveCell != null) && (this.Detail_uGrid.ActiveCell.Column.Key.Equals("MasterNm"))) // DEL 2010/09/25
                            if ((this.Detail_uGrid.ActiveCell != null) && (this.Detail_uGrid.ActiveCell.Column.Key.Equals(masterCode))) // ADD 2010/09/25
                            {
                                this.tToolbarsManager_MainMenu.Tools["ButtonTool_Guide"].SharedProps.Enabled = true;
                            }
                            break;
                        }
                    default:
                        this.tToolbarsManager_MainMenu.Tools["ButtonTool_Guide"].SharedProps.Enabled = false;
                        break;
                }

                switch (e.PrevCtrl.Name)
                {
                    case "Detail_uGrid":
                        {
                            //if ((this.Detail_uGrid.ActiveCell != null) && (this.Detail_uGrid.ActiveCell.Column.Key.Equals("MasterNm")) && (e.NextCtrl.Name.Equals("_PMKHN09477UA_Toolbars_Dock_Area_Top"))) // DEL 2010/09/25
                            if ((this.Detail_uGrid.ActiveCell != null) && (this.Detail_uGrid.ActiveCell.Column.Key.Equals(masterCode)) && (e.NextCtrl.Name.Equals("_PMKHN09477UA_Toolbars_Dock_Area_Top"))) // ADD 2010/09/25
                            {
                                this.tToolbarsManager_MainMenu.Tools["ButtonTool_Guide"].SharedProps.Enabled = true;
                            }
                            //else if ((this.Detail_uGrid.ActiveCell != null) && (this.Detail_uGrid.ActiveCell.Column.Key.Equals("MasterNm")) && (e.NextCtrl.CanFocus == false || e.NextCtrl.CanSelect == false)) // DEL 2010/09/25
                            else if ((this.Detail_uGrid.ActiveCell != null) && (this.Detail_uGrid.ActiveCell.Column.Key.Equals(masterCode)) && (e.NextCtrl.CanFocus == false || e.NextCtrl.CanSelect == false)) // ADD 2010/09/25
                            {
                                this.tToolbarsManager_MainMenu.Tools["ButtonTool_Guide"].SharedProps.Enabled = true;
                            }
                            break;
                        }
                    case "tNedit_CustomerCode":
                    case "tNedit_CustRateGrpCodeZero":
                    case "tNedit_SupplierCd":
                    case "tNedit_GoodsMakerCd": // ADD 2010/09/09
                        if (e.NextCtrl.Name.Equals("_PMKHN09477UA_Toolbars_Dock_Area_Top") || e.NextCtrl.CanFocus == false || e.NextCtrl.CanSelect == false)
                        {
                            this.tToolbarsManager_MainMenu.Tools["ButtonTool_Guide"].SharedProps.Enabled = true;
                        }
                        break;
                }
            }
            else
            {
                if (this.tNedit_CustomerCode.Focused || this.tNedit_CustRateGrpCodeZero.Focused || this.tNedit_SupplierCd.Focused || this.tNedit_GoodsMakerCd.Focused )
                {
                    this.tToolbarsManager_MainMenu.Tools["ButtonTool_Guide"].SharedProps.Enabled = true;
                }
            }
            #endregion

            //#region ���s�폜�{�^���L�������̐ݒ�
            //if (this.Detail_uGrid.ActiveCell != null)
            //{
            //    this.Delete_Button.Enabled = true;
            //}
            //else
            //{
            //    this.Delete_Button.Enabled = false;
            //}
            //if (this._delBu && this.Detail_uGrid.Rows.Count > 0) 
            //{
            //    this._delBu = false;
            //    this.Delete_Button.Enabled = true;
            //}

            //#endregion

            //#region ���S�폜�{�^���L�������̐ݒ�
            //if (this.AllDeleteEnabledCheck())
            //{
            //    this.DeleteAll_Button.Enabled = true;
            //}
            //else
            //{
            //    this.DeleteAll_Button.Enabled = false;
            //}
            //#endregion
            #region ���s�폜/�S�폜�{�^���L�������̐ݒ�
            if (this.Detail_uGrid.Rows.Count != 0)
            {
                this.Delete_Button.Enabled = true;
                this.DeleteAll_Button.Enabled = true;
            }
            else
            {
                this.Delete_Button.Enabled = false;
                this.DeleteAll_Button.Enabled = false;
            }
            #endregion
            // ---ADD 2010/09/09----------------------<<<
        }

        /// <summary>
        /// �O���b�h�������C�A�E�g�ݒ�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note		: ��ʏ��������A�O���b�h�������C�A�E�g�ݒ���s���܂��B</br>
        /// <br>Programmer  : ����</br>
        /// <br>Date        : 2010/08/19</br>
        /// <br>Update Note : 2010/08/31 ������</br>
        /// <br>            : Redmine#14030�Ή�</br>
        /// <br>Update Note : 2010/09/09 hanby</br>
        /// <br>            : Redmine#14492�Ή�</br>
        /// </remarks>
        private void Detail_uGrid_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            Infragistics.Win.UltraWinGrid.UltraGridBand band = this.Detail_uGrid.DisplayLayout.Bands[0];
            if (band == null) return;

            int visiblePosition = 0;
            this.Detail_uGrid.DisplayLayout.Override.HeaderAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            this.Detail_uGrid.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.Default;
            // ��U�A�S�Ă̗���\���ɂ���B
            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn column in band.Columns)
            {
                //��\���ݒ�
                column.Hidden = true;
            }

            // No.
            band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.RowNoColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.RowNoColumn.ColumnName].Header.Fixed = true;
            band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.RowNoColumn.ColumnName].Header.Caption = "No.";
            band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.RowNoColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.RowNoColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
            band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.RowNoColumn.ColumnName].Width = 35; //UPD 2010/09/09
            band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.RowNoColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
            band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.RowNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.RowNoColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.RowNoColumn.ColumnName].Hidden = false;
            band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.RowNoColumn.ColumnName].CellAppearance.BackColorDisabled = Color.FromArgb(89, 135, 214);
            band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.RowNoColumn.ColumnName].CellAppearance.BackColorDisabled2 = Color.FromArgb(7, 59, 150);
            band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.RowNoColumn.ColumnName].CellAppearance.BackGradientStyle = GradientStyle.Vertical;
            band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.RowNoColumn.ColumnName].CellAppearance.ForeColor = this.Detail_uGrid.DisplayLayout.Override.HeaderAppearance.ForeColor;
            band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.RowNoColumn.ColumnName].CellAppearance.ForeColorDisabled = this.Detail_uGrid.DisplayLayout.Override.HeaderAppearance.ForeColor;
            // ----------ADD 2010/09/25----------->>>
            // ���i�|����ٰ�߃R�[�h
            band.Columns[masterCode].Header.VisiblePosition = visiblePosition++;
            band.Columns[masterCode].Header.Fixed = true;
            band.Columns[masterCode].Header.Caption = "���i�|���f";
            band.Columns[masterCode].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            band.Columns[masterCode].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
            band.Columns[masterCode].Width = 80;
            band.Columns[masterCode].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
            band.Columns[masterCode].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            band.Columns[masterCode].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            band.Columns[masterCode].Hidden = false;
            band.Columns[masterCode].Format = FORMAT_CODE;
            // ----------ADD 2010/09/25-----------<<<
            // ���i�|����ٰ��
            band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.MasterNmColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.MasterNmColumn.ColumnName].Header.Fixed = true;
            //band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.MasterNmColumn.ColumnName].Header.Caption = "���i�|����ٰ��"; // DEL 2010/09/25
            band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.MasterNmColumn.ColumnName].Header.Caption = "���i�|���f��"; // ADD 2010/09/25
            band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.MasterNmColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            //band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.MasterNmColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;// DEL 2010/09/09
            //band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.MasterNmColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;// ADD 2010/09/09
            band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.MasterNmColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;// ADD 2010/09/25
            //band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.MasterNmColumn.ColumnName].Width = 250;// DEL 2010/08/31
            band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.MasterNmColumn.ColumnName].Width = 160;// ADD 2010/08/31
            band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.MasterNmColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
            band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.MasterNmColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.MasterNmColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.MasterNmColumn.ColumnName].Hidden = false;
            band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.MasterNmColumn.ColumnName].MaxLength = 4; // ADD 2010/09/09

            switch (this._rateProtyMng.UnitPriceKind)
            {
                // �����̏ꍇ
                case 1:
                    {
                        // ������
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.RateValColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.RateValColumn.ColumnName].Header.Fixed = true;
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.RateValColumn.ColumnName].Header.Caption = "������";
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.RateValColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.RateValColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.RateValColumn.ColumnName].Width = 80;
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.RateValColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.RateValColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.RateValColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.RateValColumn.ColumnName].Hidden = false;
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.RateValColumn.ColumnName].Format = FORMAT_FRACTION;
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.RateValColumn.ColumnName].MaxLength = 3; // ADD 2010/09/09

                        // �����z
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.PriceFlColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.PriceFlColumn.ColumnName].Header.Fixed = true;
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.PriceFlColumn.ColumnName].Header.Caption = "�����z";
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.PriceFlColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.PriceFlColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.PriceFlColumn.ColumnName].Width = 100;
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.PriceFlColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.PriceFlColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.PriceFlColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.PriceFlColumn.ColumnName].Hidden = false;
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.PriceFlColumn.ColumnName].Format = FORMAT_FRACTION;

                        // ����UP��
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.UpRateColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.UpRateColumn.ColumnName].Header.Fixed = true;
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.UpRateColumn.ColumnName].Header.Caption = "����UP��";
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.UpRateColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.UpRateColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.UpRateColumn.ColumnName].Width = 80;
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.UpRateColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.UpRateColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.UpRateColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.UpRateColumn.ColumnName].Hidden = false;
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.UpRateColumn.ColumnName].Format = FORMAT_FRACTION;
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.UpRateColumn.ColumnName].MaxLength = 3; // ADD 2010/09/09

                        // �e���m�ۗ�
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.GrsProfitSecureRateColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.GrsProfitSecureRateColumn.ColumnName].Header.Fixed = true;
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.GrsProfitSecureRateColumn.ColumnName].Header.Caption = "�e���m�ۗ�";
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.GrsProfitSecureRateColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.GrsProfitSecureRateColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.GrsProfitSecureRateColumn.ColumnName].Width = 100;
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.GrsProfitSecureRateColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.GrsProfitSecureRateColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.GrsProfitSecureRateColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.GrsProfitSecureRateColumn.ColumnName].Hidden = false;
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.GrsProfitSecureRateColumn.ColumnName].Format = FORMAT_FRACTION;
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.GrsProfitSecureRateColumn.ColumnName].MaxLength = 2; // ADD 2010/09/09

                        break;
                    }
                // �����̏ꍇ
                case 2:
                    {
                        // �d����
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.RateValColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.RateValColumn.ColumnName].Header.Fixed = true;
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.RateValColumn.ColumnName].Header.Caption = "�d����";
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.RateValColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.RateValColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.RateValColumn.ColumnName].Width = 80;
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.RateValColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.RateValColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.RateValColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.RateValColumn.ColumnName].Hidden = false;
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.RateValColumn.ColumnName].Format = FORMAT_FRACTION;

                        // �d������
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.PriceFlColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.PriceFlColumn.ColumnName].Header.Fixed = true;
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.PriceFlColumn.ColumnName].Header.Caption = "�d������";
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.PriceFlColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.PriceFlColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.PriceFlColumn.ColumnName].Width = 80;
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.PriceFlColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.PriceFlColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.PriceFlColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.PriceFlColumn.ColumnName].Hidden = false;
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.PriceFlColumn.ColumnName].Format = FORMAT_FRACTION;

                        break;
                    }
                // ���i�̏ꍇ
                case 3:
                    {
                        // ���[�U�[���i
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.PriceFlColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.PriceFlColumn.ColumnName].Header.Fixed = true;
                        //band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.PriceFlColumn.ColumnName].Header.Caption = "հ�ް���i";// DEL 2010/08/31
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.PriceFlColumn.ColumnName].Header.Caption = "���[�U�[���i";// ADD 2010/08/31
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.PriceFlColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.PriceFlColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                        //band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.PriceFlColumn.ColumnName].Width = 80;// DEL 2010/08/31
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.PriceFlColumn.ColumnName].Width = 90;// ADD 2010/08/31
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.PriceFlColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.PriceFlColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.PriceFlColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.PriceFlColumn.ColumnName].Hidden = false;
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.PriceFlColumn.ColumnName].Format = FORMAT_FRACTION;

                        // �艿UP��
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.UpRateColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.UpRateColumn.ColumnName].Header.Fixed = true;
                        //band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.UpRateColumn.ColumnName].Header.Caption = "�艿UP��";// DEL 2010/08/31
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.UpRateColumn.ColumnName].Header.Caption = "���iUP��";// ADD 2010/08/31
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.UpRateColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.UpRateColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.UpRateColumn.ColumnName].Width = 80;
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.UpRateColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.UpRateColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.UpRateColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.UpRateColumn.ColumnName].Hidden = false;
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.UpRateColumn.ColumnName].Format = FORMAT_FRACTION;

                        // �[�������P��
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.UnPrcFracProcUnitColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.UnPrcFracProcUnitColumn.ColumnName].Header.Fixed = true;
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.UnPrcFracProcUnitColumn.ColumnName].Header.Caption = "�[�������P��";
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.UnPrcFracProcUnitColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.UnPrcFracProcUnitColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.UnPrcFracProcUnitColumn.ColumnName].Width = 100;
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.UnPrcFracProcUnitColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.UnPrcFracProcUnitColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.UnPrcFracProcUnitColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.UnPrcFracProcUnitColumn.ColumnName].Hidden = false;
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.UnPrcFracProcUnitColumn.ColumnName].Format = FORMAT_FRACTION;

                        // �[�������敪
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.UnPrcFracProcDivNmColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.UnPrcFracProcDivNmColumn.ColumnName].Header.Fixed = true;
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.UnPrcFracProcDivNmColumn.ColumnName].Header.Caption = "�[�������敪";
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.UnPrcFracProcDivNmColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.UnPrcFracProcDivNmColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.UnPrcFracProcDivNmColumn.ColumnName].Width = 100;
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.UnPrcFracProcDivNmColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.UnPrcFracProcDivNmColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.UnPrcFracProcDivNmColumn.ColumnName].Hidden = false;
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.UnPrcFracProcDivNmColumn.ColumnName].MaxLength = 1;// ADD 2010/09/09
                        // �R���{�{�b�N�X�ݒ�
                        ValueList valueList = new ValueList();
                        valueList.Appearance.BackColor = Color.FromArgb(247, 227, 156);
                        valueList.ValueListItems.Clear();
                        valueList.ValueListItems.Add("1", UNPRCFRACPROCDIV_1);
                        valueList.ValueListItems.Add("2", UNPRCFRACPROCDIV_2);
                        valueList.ValueListItems.Add("3", UNPRCFRACPROCDIV_3);
                        //band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.UnPrcFracProcDivNmColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;// DEL 2010/09/09
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.UnPrcFracProcDivNmColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDown;// ADD 2010/09/09
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.UnPrcFracProcDivNmColumn.ColumnName].ValueList = valueList.Clone();
                        break;
                    }
                default:
                    {
                        break;
                    }
            }

        }

        /// <summary>
        /// KeyDown �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note        : �O���b�h�A�N�e�B�u����Key�������ꂽ���ɔ������܂��B</br>
        /// <br>Programmer  : ����</br>
        /// <br>Date        : 2010/08/19</br>
        /// <br>Update Note : 2010/09/09 hanby</br>
        /// <br>            : Redmine#14492�Ή�</br>
        /// </remarks>
        //private void Detail_uGrid_KeyDown(object sender, KeyEventArgs e)
        //{

        //    if ((this.Detail_uGrid.Rows.Count == 0) ||
        //        ((this.Detail_uGrid.ActiveCell == null) && (this.Detail_uGrid.ActiveRow == null)))
        //    {
        //        switch (e.KeyCode)
        //        {
        //            case Keys.Up:
        //                {
        //                    SetFocus(1);
        //                    break;
        //                }
        //            case Keys.Down:
        //            case Keys.Right:
        //                {
        //                    break;
        //                }
        //            case Keys.Left:
        //                {
        //                    //
        //                    break;
        //                }
        //        }
        //        return;
        //    }

        //    int rowIndex;
        //    int columnIndex;
        //    string columnKey;

        //    if (Detail_uGrid.ActiveCell != null)
        //    {
        //        rowIndex = Detail_uGrid.ActiveCell.Row.Index;
        //        columnIndex = Detail_uGrid.ActiveCell.Column.Index;
        //        columnKey = Detail_uGrid.ActiveCell.Column.Key;
        //    }
        //    else
        //    {
        //        rowIndex = Detail_uGrid.ActiveRow.Index;
        //        // �����̏ꍇ
        //        if (_rateProtyMng.UnitPriceKind == 2)
        //        {
        //            columnIndex = 3;
        //        }
        //        else
        //        {
        //            columnIndex = 4;
        //        }
        //        columnKey = Detail_uGrid.ActiveRow.Cells[columnIndex].Column.Key;
        //    }

        //    // ---ADD 2010/09/09---------------------->>>
        //    #region ���[�������敪�`�F�b�N
        //    if ((this.Detail_uGrid.ActiveCell != null) && this.Detail_uGrid.ActiveCell.Column.Key.Equals("UnPrcFracProcDivNm"))
        //    {
        //        switch (this.Detail_uGrid.ActiveCell.Text)
        //        {
        //            case "1":
        //            case "1:�؎̂�":
        //            case "2":
        //            case "2:�l�̌ܓ�":
        //            case "3":
        //            case "3:�؏グ":
        //                break;
        //            default:
        //                this.Detail_uGrid.ActiveCell.Value = 2;
        //                break;
        //        }
        //    }
        //    #endregion
        //    // ---ADD 2010/09/09----------------------<<<

        //    switch (e.KeyCode)
        //    {
        //        case Keys.Up:
        //            {
        //                if (this.Detail_uGrid.DisplayLayout.Bands[0].Columns[columnIndex].Style == Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList)
        //                {
        //                    if (this.Detail_uGrid.ActiveCell.ValueListResolved.IsDroppedDown == true)
        //                    {
        //                        return;
        //                    }
        //                }

        //                if (rowIndex == 0)
        //                {
        //                    e.Handled = true;
        //                    SetFocus(1);
        //                    // ---ADD 2010/09/09---------------------->>>
        //                    this.Detail_uGrid.ActiveCell = null;
        //                    this.Detail_uGrid.ActiveRow = null;
        //                    // ---ADD 2010/09/09----------------------<<<
        //                }
        //                else
        //                {
        //                    e.Handled = true;
        //                    for (int index = rowIndex - 1; index >= 0; index--)
        //                    {
        //                        if (this.Detail_uGrid.Rows[index].Cells[columnIndex].Activation == Activation.AllowEdit)
        //                        {
        //                            this.Detail_uGrid.Rows[index].Cells[columnIndex].Activate();
        //                            this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
        //                            return;
        //                        }
        //                    }
        //                }
        //                break;
        //            }
        //        case Keys.Down:
        //            {
        //                if (this.Detail_uGrid.DisplayLayout.Bands[0].Columns[columnIndex].Style == Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList)
        //                {
        //                    if (this.Detail_uGrid.ActiveCell.ValueListResolved.IsDroppedDown == true)
        //                    {
        //                        return;
        //                    }
        //                }

        //                if (rowIndex == this.Detail_uGrid.Rows.Count - 1)
        //                {
        //                    e.Handled = true;
        //                }
        //                else
        //                {
        //                    e.Handled = true;
        //                    for (int index = rowIndex + 1; index < this.Detail_uGrid.Rows.Count; index++)
        //                    {
        //                        if (this.Detail_uGrid.Rows[index].Cells[columnIndex].Activation == Activation.AllowEdit)
        //                        {
        //                            this.Detail_uGrid.Rows[index].Cells[columnIndex].Activate();
        //                            this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
        //                            return;
        //                        }
        //                    }
        //                }
        //                break;
        //            }
        //        case Keys.Left:
        //            {
        //                if (this.Detail_uGrid.ActiveCell == null)
        //                {
        //                    this.InitGridFocus(0, 0);
        //                    this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
        //                    return;
        //                }

        //                if (this.Detail_uGrid.ActiveCell.IsInEditMode)
        //                {
        //                    if ((this.Detail_uGrid.ActiveCell.Column.Style == Infragistics.Win.UltraWinGrid.ColumnStyle.Default) ||
        //                        (this.Detail_uGrid.ActiveCell.Column.Style == Infragistics.Win.UltraWinGrid.ColumnStyle.Edit) ||
        //                        (this.Detail_uGrid.ActiveCell.Column.Style == Infragistics.Win.UltraWinGrid.ColumnStyle.Date))
        //                    {
        //                        if (this.Detail_uGrid.ActiveCell.SelStart == 0)
        //                        {
        //                            e.Handled = true;
        //                            this.Detail_uGrid.PerformAction(UltraGridAction.PrevCellByTab);
        //                        }
        //                    }
        //                    else
        //                    {
        //                        e.Handled = true;
        //                        this.Detail_uGrid.PerformAction(UltraGridAction.PrevCellByTab);
        //                    }
        //                }
        //                else
        //                {
        //                    e.Handled = true;
        //                    this.Detail_uGrid.PerformAction(UltraGridAction.PrevCellByTab);
        //                }
        //                break;
        //            }
        //        case Keys.Right:
        //            {
        //                if (this.Detail_uGrid.ActiveCell == null)
        //                {
        //                    this.InitGridFocus(0, 0);
        //                    this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
        //                    return;
        //                }

        //                if (Detail_uGrid.ActiveCell.IsInEditMode)
        //                {
        //                    if ((this.Detail_uGrid.ActiveCell.Column.Style == Infragistics.Win.UltraWinGrid.ColumnStyle.Default) ||
        //                        (this.Detail_uGrid.ActiveCell.Column.Style == Infragistics.Win.UltraWinGrid.ColumnStyle.Edit) ||
        //                        (this.Detail_uGrid.ActiveCell.Column.Style == Infragistics.Win.UltraWinGrid.ColumnStyle.Date))
        //                    {
        //                        if (this.Detail_uGrid.ActiveCell.SelStart >= Detail_uGrid.ActiveCell.Text.Length)
        //                        {
        //                            e.Handled = true;
        //                            this.Detail_uGrid.PerformAction(UltraGridAction.NextCellByTab);
        //                        }
        //                    }
        //                    else
        //                    {
        //                        e.Handled = true;
        //                        this.Detail_uGrid.PerformAction(UltraGridAction.NextCellByTab);
        //                    }
        //                }
        //                else
        //                {
        //                    e.Handled = true;
        //                    this.Detail_uGrid.PerformAction(UltraGridAction.NextCellByTab);
        //                }
        //                break;
        //            }
        //    }

        //}
        private void Detail_uGrid_KeyDown(object sender, KeyEventArgs e)
        {
            int rowIndex;
            int columnIndex;

            if (this.Detail_uGrid.ActiveCell == null)
            {
                if (this.Detail_uGrid.ActiveRow == null)
                {
                    rowIndex = 0;
                }
                else
                {
                    rowIndex = this.Detail_uGrid.ActiveRow.Index;
                }
                //�����̏ꍇ
                if (this._rateProtyMng.UnitPriceKind == 2)
                {
                    columnIndex = 3;
                }
                else
                {
                    columnIndex = 2;
                }
            }
            else
            {
                rowIndex = this.Detail_uGrid.ActiveCell.Row.Index;
                columnIndex = this.Detail_uGrid.ActiveCell.Column.Index;
            }

            // ---ADD 2010/09/09---------------------->>>
            #region ���[�������敪�`�F�b�N
            if ((this.Detail_uGrid.ActiveCell != null) && this.Detail_uGrid.ActiveCell.Column.Key.Equals("UnPrcFracProcDivNm"))
            {
                switch (this.Detail_uGrid.ActiveCell.Text)
                {
                    case "1":
                    case "1:�؎̂�":
                    case "2":
                    case "2:�l�̌ܓ�":
                    case "3":
                    case "3:�؏グ":
                        break;
                    default:
                        this.Detail_uGrid.ActiveCell.Value = 2;
                        break;
                }
            }
            #endregion
            // ---ADD 2010/09/09----------------------<<<

            switch (e.KeyCode)
            {
                case Keys.Up:
                    {
                        if (this.Detail_uGrid.DisplayLayout.Bands[0].Columns[columnIndex].Style == Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList)
                        {
                            if (this.Detail_uGrid.ActiveCell.ValueListResolved.IsDroppedDown == true)
                            {
                                return;
                            }
                        }

                        if (rowIndex == 0)
                        {
                            e.Handled = true;
                            SetFocus(1);
                            // ---ADD 2010/09/09---------------------->>>
                            this.Detail_uGrid.ActiveCell = null;
                            this.Detail_uGrid.ActiveRow = null;
                            // ---ADD 2010/09/09----------------------<<<
                        }
                        else
                        {
                            e.Handled = true;
                            for (int index = rowIndex - 1; index >= 0; index--)
                            {
                                if (this.Detail_uGrid.Rows[index].Cells[columnIndex].Activation == Activation.AllowEdit)
                                {
                                    this.Detail_uGrid.Rows[index].Cells[columnIndex].Activate();
                                    this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                    return;
                                }
                                // ---ADD 2010/09/25---------------------->>>
                                // ���󁪉�������ƁA��̖��ׂ̓��͍��ڂֈړ�����B
                                if (this.Detail_uGrid.ActiveCell.Column.Key.Equals(this.masterCode))
                                {
                                    for (int rowNo = rowIndex - 1; rowNo >= 0; rowNo--)
                                    {
                                        //if ((int)this.Detail_uGrid.Rows[rowNo].Cells[this._rateProtyMngPatternDataSet.RateProtyMngPattern.LogicalDeleteCodeColumn.ColumnName].Value == 0) // DEL 2010/09/30 �d�l�A�� #15703
                                        //{ // DEL 2010/09/30 �d�l�A�� #15703
                                            int targetColumnIndex = GetNextColumnIndexByTab(0, rowIndex, this.masterCode);
                                            if (targetColumnIndex >= 0)
                                            {
                                                this.Detail_uGrid.Rows[rowNo].Cells[targetColumnIndex].Activate();
                                                this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                                return;
                                            }
                                        }
                                    //} // DEL 2010/09/30 �d�l�A�� #15703

                                    SetFocus(1);
                                    this.Detail_uGrid.ActiveCell = null;
                                    this.Detail_uGrid.ActiveRow = null;
                                    return;
                                }
                                // ---ADD 2010/09/25----------------------<<<
                            }
                            SetFocus(1); // ADD 2010/09/09
                            // ---ADD 2010/09/09---------------------->>>
                            this.Detail_uGrid.ActiveCell = null;
                            this.Detail_uGrid.ActiveRow = null;
                            // ---ADD 2010/09/09----------------------<<<
                        }
                        break;
                    }
                case Keys.Down:
                    {
                        if (this.Detail_uGrid.DisplayLayout.Bands[0].Columns[columnIndex].Style == Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList)
                        {
                            if (this.Detail_uGrid.ActiveCell.ValueListResolved.IsDroppedDown == true)
                            {
                                return;
                            }
                        }

                        if (rowIndex == this.Detail_uGrid.Rows.Count - 1)
                        {
                            e.Handled = true;
                        }
                        else
                        {
                            e.Handled = true;
                            for (int index = rowIndex + 1; index < this.Detail_uGrid.Rows.Count; index++)
                            {
                                if (this.Detail_uGrid.Rows[index].Cells[columnIndex].Activation == Activation.AllowEdit)
                                {
                                    this.Detail_uGrid.Rows[index].Cells[columnIndex].Activate();
                                    this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                    return;
                                }
                            }
                        }
                        break;
                    }
                case Keys.Left:
                    {
                        if (this.Detail_uGrid.ActiveCell == null)
                        {
                            this.InitGridFocus(0, 0);
                            this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                            return;
                        }

                        // UPD 2010/09/19 -- >>>>
                        //if (this.Detail_uGrid.ActiveCell.IsInEditMode)
                        //{
                        //    if ((this.Detail_uGrid.ActiveCell.Column.Style == Infragistics.Win.UltraWinGrid.ColumnStyle.Default) ||
                        //        (this.Detail_uGrid.ActiveCell.Column.Style == Infragistics.Win.UltraWinGrid.ColumnStyle.Edit) ||
                        //        (this.Detail_uGrid.ActiveCell.Column.Style == Infragistics.Win.UltraWinGrid.ColumnStyle.Date))
                        //    {
                        //        if (this.Detail_uGrid.ActiveCell.SelStart == 0)
                        //        {
                        //            e.Handled = true;
                        //            this.Detail_uGrid.PerformAction(UltraGridAction.PrevCellByTab);
                        //        }
                        //    }
                        //    else
                        //    {
                        //        e.Handled = true;
                        //        this.Detail_uGrid.PerformAction(UltraGridAction.PrevCellByTab);
                        //    }
                        //}
                        //else
                        //{
                        //    e.Handled = true;
                        //    this.Detail_uGrid.PerformAction(UltraGridAction.PrevCellByTab);
                        //}

                        if (!MoveNextAllowEditCell(false, 0))
                        {
                            if (rowIndex == 0)
                            {
                                this.Detail_uGrid.Rows[0].Cells[columnIndex].Activate();
                                this.Detail_uGrid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                                this.Detail_uGrid.ActiveCell.SelectAll();
                            }
                        }
                        // UPD 2010/09/19 -- <<<<
                        break;
                    }
                case Keys.Right:
                    {
                        if (this.Detail_uGrid.ActiveCell == null)
                        {
                            this.InitGridFocus(0, 0);
                            this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                            return;
                        }

                        // UPD 2010/09/19 -- >>>>
                        //if (Detail_uGrid.ActiveCell.IsInEditMode)
                        //{
                        //    if ((this.Detail_uGrid.ActiveCell.Column.Style == Infragistics.Win.UltraWinGrid.ColumnStyle.Default) ||
                        //        (this.Detail_uGrid.ActiveCell.Column.Style == Infragistics.Win.UltraWinGrid.ColumnStyle.Edit) ||
                        //        (this.Detail_uGrid.ActiveCell.Column.Style == Infragistics.Win.UltraWinGrid.ColumnStyle.Date))
                        //    {
                        //        if (this.Detail_uGrid.ActiveCell.SelStart >= Detail_uGrid.ActiveCell.Text.Length)
                        //        {
                        //            e.Handled = true;
                        //            this.Detail_uGrid.PerformAction(UltraGridAction.NextCellByTab);
                        //        }
                        //    }
                        //    else
                        //    {
                        //        e.Handled = true;
                        //        this.Detail_uGrid.PerformAction(UltraGridAction.NextCellByTab);
                        //    }
                        //}
                        //else
                        //{
                        //    e.Handled = true;
                        //    this.Detail_uGrid.PerformAction(UltraGridAction.NextCellByTab);
                        //}

                        if (!MoveNextAllowEditCell(false, 1))
                        {
                            if (rowIndex == 998)
                            {
                                this.Detail_uGrid.Rows[998].Cells[columnIndex].Activate();
                                this.Detail_uGrid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                                this.Detail_uGrid.ActiveCell.SelectAll();
                            }
                        }
                        // UPD 2010/09/19 -- <<<<
                        break;
                    }
            }

        }

        /// <summary>
        /// KeyPress �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note        : �O���b�h�A�N�e�B�u����Key�������ꂽ���ɔ������܂��B</br>
        /// <br>Programmer  : ����</br>
        /// <br>Date        : 2010/08/19</br>
        /// </remarks>
        private void Detail_uGrid_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (this.Detail_uGrid.ActiveCell == null)
            {
                return;
            }

            UltraGridCell cell = this.Detail_uGrid.ActiveCell;

            // ActiveCell�������z/�d�������̏ꍇ
            if (cell.Column.Key == this._rateProtyMngPatternDataSet.RateProtyMngPattern.SalesUnitCostColumn.ColumnName ||
                cell.Column.Key == this._rateProtyMngPatternDataSet.RateProtyMngPattern.PriceFlColumn.ColumnName ||
                cell.Column.Key == this._rateProtyMngPatternDataSet.RateProtyMngPattern.ListPriceColumn.ColumnName)
            {
                // �ҏW���[�h���H
                if (cell.IsInEditMode)
                {
                    // ZZ9.99
                    if (!KeyPressNumCheck(11, 2, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false))
                    {
                        e.Handled = true;
                        return;
                    }
                }
            }
            // ������/�d�����A����UP��/�艿UP��
            else if (cell.Column.Key == this._rateProtyMngPatternDataSet.RateProtyMngPattern.RateValColumn.ColumnName ||
                     cell.Column.Key == this._rateProtyMngPatternDataSet.RateProtyMngPattern.UpRateColumn.ColumnName)
            {
                // �ҏW���[�h���H
                if (cell.IsInEditMode)
                {
                    // ZZ9.99
                    if (!KeyPressNumCheck(6, 2, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false))
                    {
                        e.Handled = true;
                        return;
                    }
                }
            }
            // �[�������P��
            else if (cell.Column.Key == this._rateProtyMngPatternDataSet.RateProtyMngPattern.UnPrcFracProcUnitColumn.ColumnName)
            {
                // �ҏW���[�h���H
                if (cell.IsInEditMode)
                {
                    // ZZ9.99
                    if (!KeyPressNumCheck(10, 2, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false))
                    {
                        e.Handled = true;
                        return;
                    }
                }
            }
            // �e���m�ۗ�
            else if (cell.Column.Key == this._rateProtyMngPatternDataSet.RateProtyMngPattern.GrsProfitSecureRateColumn.ColumnName)
            {
                // �ҏW���[�h���H
                if (cell.IsInEditMode)
                {
                    // ZZ9.99
                    if (!KeyPressNumCheck(5, 2, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false))
                    {
                        e.Handled = true;
                        return;
                    }
                }
            }
            // --- ADD 2010/09/09 ---------->>>
            // ���[�J�[�R�[�h
            //else if (cell.Column.Key == this._rateProtyMngPatternDataSet.RateProtyMngPattern.MasterNmColumn.ColumnName) // DEL 2010/09/25
            else if (cell.Column.Key == this._rateProtyMngPatternDataSet.RateProtyMngPattern.GoodsRateGrpCodeColumn.ColumnName) // ADD 2010/09/25
            {
                // �ҏW���[�h���H
                if (cell.IsInEditMode)
                {
                    if (!KeyPressNumCheck(4, 0, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false))
                    {
                        e.Handled = true;
                    }
                }
            }
            // �[�������敪
            else if (cell.Column.Key == this._rateProtyMngPatternDataSet.RateProtyMngPattern.UnPrcFracProcDivNmColumn.ColumnName)
            {
                // �ҏW���[�h���H
                if (cell.IsInEditMode)
                {
                    if (!KeyPressNumCheck(1, 0, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false))
                    {
                        e.Handled = true;
                    }
                }
            }
            // --- ADD 2010/09/09 ----------<<<
        }

        /// <summary>
        /// Leave �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note        : �O���b�h�A�N�e�B�u����Key�������ꂽ���ɔ������܂��B</br>
        /// <br>Programmer  : ����</br>
        /// <br>Date        : 2010/08/19</br>
        /// <br>Update Note : 2010/09/09 hanby</br>
        /// <br>            : Redmine#14492�Ή�</br>
        /// </remarks>
        private void Detail_uGrid_Leave(object sender, EventArgs e)
        {
            // ---DEL 2010/09/09---------------------->>>
            //this.Detail_uGrid.ActiveCell = null;
            //this.Detail_uGrid.ActiveRow = null;
            // ---DEL 2010/09/09----------------------<<<
        }

        // ---ADD 2010/09/09---------------------->>>

        /// <summary>
        /// Enter �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note        : �O���b�h�A�N�e�B�u����Enter�������ꂽ���ɔ������܂��B</br>
        /// <br>Programmer  : hanby</br>
        /// <br>Date        : 2010/08/19</br>
        /// <br>Update Note : 2010/09/09 hanby</br>
        /// <br>            : Redmine#14492�Ή�</br>
        /// </remarks>
        private void Detail_uGrid_AfterEnterEditMode(object sender, EventArgs e)
        {
            
            if (this.Detail_uGrid.ActiveCell != null)
            {
                //if (this.Detail_uGrid.ActiveCell.Column.Key.Equals("MasterNm")) // DEL 2010/09/25
                if (this.Detail_uGrid.ActiveCell.Column.Key.Equals(masterCode)) // ADD 2010/09/25
                {
                    this.tToolbarsManager_MainMenu.Tools["ButtonTool_Guide"].SharedProps.Enabled = true;
                    if (this.Detail_uGrid.ActiveCell.Text.Length > 4)
                    {
                        this._preMakerCd = this.Detail_uGrid.ActiveCell.Text.Trim();
                    }
                }
                else
                {
                    this.tToolbarsManager_MainMenu.Tools["ButtonTool_Guide"].SharedProps.Enabled = false;
                }
            }
            else
            {
                this.tToolbarsManager_MainMenu.Tools["ButtonTool_Guide"].SharedProps.Enabled = false;
            }
            this._prevIndexRow2 = this.Detail_uGrid.ActiveCell.Row.Index;
            this._prevIndexColumn2 = this.Detail_uGrid.ActiveCell.Column.Index;
            
        }
        // ---ADD 2010/09/09----------------------<<<

        /// <summary>
        /// AfterExitEditMode �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note        : �ҏW���[�h���I���������ɔ������܂��B</br>
        /// <br>Programmer  : ����</br>
        /// <br>Date        : 2010/08/19</br>
        /// </remarks>
        private void Detail_uGrid_AfterExitEditMode(object sender, EventArgs e)
        {
            this._errorFlg = false; // ADD 2010/09/25
            if (this.Detail_uGrid.ActiveCell == null) return;
            Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.Detail_uGrid.ActiveCell;

            if (cell == null) return;
            int rowIndex = cell.Row.Index;

            if (cell.Value is DBNull)
            {
                if ((cell.Column.DataType == typeof(Int32)) ||
                    (cell.Column.DataType == typeof(Int64)))
                {
                    cell.Value = 0;
                }
                else if (cell.Column.DataType == typeof(double))
                {
                    cell.Value = 0.0;
                }
                else if (cell.Column.DataType == typeof(string))
                {
                    cell.Value = "";
                }
            }
        }

        /// <summary>
        /// uGrid_Details_AfterCellUpdate�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note        : uGrid_Details_AfterCellUpdate���s���܂��B</br>
        /// <br>Programmer  : ����</br>
        /// <br>Date        : 2010/08/19</br>
        /// <br>Update Note : 2010/09/09 hanby</br>
        /// <br>            : Redmine#14492�Ή�</br>
        /// <br>Update Note : 2010/09/30</br>
        /// <br>            : Redmine#15703�Ή�</br>
        /// </remarks>
        private void Detail_uGrid_AfterCellUpdate(object sender, CellEventArgs e)
        {
            // ---ADD 2010/09/25---------------------->>>
            if (this._gridGuideFlg == true)
            {
                this._gridGuideFlg = false;
                return;
            }
            // ---ADD 2010/09/25----------------------<<<

            // ---ADD 2010/09/09----------------------<<<
            #region ���[�������敪�`�F�b�N
            if (e.Cell.Column.Key == this._rateProtyMngPatternDataSet.RateProtyMngPattern.UnPrcFracProcDivNmColumn.ColumnName)
            {
                switch (this.Detail_uGrid.ActiveCell.Text)
                {
                    case "1":
                    case "1:�؎̂�":
                    case "2":
                    case "2:�l�̌ܓ�":
                    case "3":
                    case "3:�؏グ":
                        break;
                    default:
                        this.Detail_uGrid.ActiveCell.Value = 2;
                        break;
                }
            }
            #endregion
            // ---ADD 2010/09/09----------------------<<<

            int rowIndex = e.Cell.Row.Index;
            int saveFlg = 0;
            // --- ADD 2010/09/09 ---------->>>>>
            if(null==this.Detail_uGrid.ActiveRow)
            {
                return;
            }
            // ---DEL 2010/09/26---------------------->>>
            //if (int.Parse(this.Detail_uGrid.ActiveRow.Cells[this._rateProtyMngPatternDataSet.RateProtyMngPattern.LogicalDeleteCodeColumn.ColumnName].Value.ToString()) == 1)
            //{
            //    return;
            //}
            // ---DEL 2010/09/26----------------------<<<
            if (this._errorFlg)
            {
                return;
            }
            // --- ADD 2010/09/09 ----------<<<<<
            DataRow originalDr = this._rateProtyMngPatternAcs.OriginalRateProtyMngDataTable
                .Select(this._rateProtyMngPatternDataSet.RateProtyMngPattern.RowNoColumn.ColumnName + " = '"
                + this.Detail_uGrid.Rows[rowIndex].Cells[this._rateProtyMngPatternDataSet.RateProtyMngPattern.RowNoColumn.ColumnName].Value.ToString() + "'")[0];

            for (int i = 0; i < this._rateProtyMngPatternDataSet.RateProtyMngPattern.Columns.Count; i++)
            {
                if (this.Detail_uGrid.Rows[rowIndex].Cells[i].Value.ToString() != originalDr[i].ToString())
                {
                    if (this.Detail_uGrid.Rows[rowIndex].Cells[i].Column.Key != this._rateProtyMngPatternDataSet.RateProtyMngPattern.SaveFlgColumn.ColumnName)
                    {
                        saveFlg = 1;
                    }
                }
            }
            // ---ADD 2010/09/09---------------------->>>
            if ((this._prevIndexRow2 >= 0) && (this._prevIndexColumn2 >= 0) && (this.Detail_uGrid.ActiveCell == this.Detail_uGrid.Rows[this._prevIndexRow2].Cells[this._prevIndexColumn2]))
            {
                if (this._errorFlg)
                {
                    this._errorFlg = false;
                }
            }
            // ---ADD 2010/09/09----------------------<<<
            
            this.Detail_uGrid.BeginUpdate();
            this.Detail_uGrid.Rows[rowIndex].Cells[this._rateProtyMngPatternDataSet.RateProtyMngPattern.SaveFlgColumn.ColumnName].Value = saveFlg;
            this.Detail_uGrid.EndUpdate();
            // --- DEL 2010/09/30 �d�l�A�� #15703 ---------->>>>>
            // --- ADD 2010/09/26 ---------->>>>>
            //if (int.Parse(this.Detail_uGrid.ActiveRow.Cells[this._rateProtyMngPatternDataSet.RateProtyMngPattern.LogicalDeleteCodeColumn.ColumnName].Value.ToString()) == 1)
            //{
            //    return;
            //}
            // --- ADD 2010/09/26 ----------<<<<<
            // --- DEL 2010/09/30 �d�l�A�� #15703 ----------<<<<<
            // --- ADD 2010/09/09 ---------->>>>>
            #region
            if (this._searchFlg)
            {
                this._searchFlg = false;
                return;
            }
            //if (this.Detail_uGrid.ActiveCell.Column.Key.Equals(this._rateProtyMngPatternDataSet.RateProtyMngPattern.MasterNmColumn.ColumnName)) // DEL 2010/09/25
            //if (this.Detail_uGrid.ActiveCell.Column.Key.Equals(this._rateProtyMngPatternDataSet.RateProtyMngPattern.GoodsRateGrpCodeColumn.ColumnName)) // ADD 2010/09/25 // DEL 2010/09/30 �d�l�A�� #15703
            if (this.Detail_uGrid.ActiveCell != null && this.Detail_uGrid.ActiveCell.Column.Key.Equals(this._rateProtyMngPatternDataSet.RateProtyMngPattern.GoodsRateGrpCodeColumn.ColumnName)) // ADD 2010/09/30 �d�l�A�� #15703
            {
                if (this.Detail_uGrid.ActiveCell.Value != null && !string.IsNullOrEmpty(this.Detail_uGrid.ActiveCell.Value.ToString()))
                {
                    int inputValue;
                    if (this._guidFlg)
                    {
                        inputValue = this._guidCd;
                        this._guidFlg = false;
                    }
                    else 
                    {
                        if (!int.TryParse(this.Detail_uGrid.ActiveCell.Value.ToString(), out inputValue))
                        {
                            // �G���[��
                            TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_INFO,
                                this.Name,
                                "���i�|���f�}�X�^�����o�^�ł��B",
                                -1,
                                MessageBoxButtons.OK);
                            // --- ADD 2010/09/09 ---------->>>>>
                            ((RateProtyMngPatternDataSet.RateProtyMngPatternRow)this._rateProtyMngPatternDataSet.RateProtyMngPattern.Rows[rowIndex]).MasterNm = string.Empty;
                            this._errorFlg = true;
                            this._isError = true;
                            this._errorFlg2 = true; // ADD 2010/09/25
                            //this.Detail_uGrid.ActiveCell.SelectAll(); // DEL 2010/09/25
                            ((RateProtyMngPatternDataSet.RateProtyMngPatternRow)this._rateProtyMngPatternDataSet.RateProtyMngPattern.Rows[rowIndex]).GoodsRateGrpCode = string.Empty; // ADD 2010/09/25
                            return; // ADD 2010/09/25
                            // --- ADD 2010/09/09 ----------<<<<<
                        }
                        //inputValue = Convert.ToInt32(this.Detail_uGrid.ActiveCell.Value); // ADD 2010/09/09
                    }
                    int rowIndex2 = this.Detail_uGrid.ActiveCell.Row.Index;

                    if (this._errorFlg)
                    {
                        this._errorFlg = false;
                        return;
                    }
                    // �O��l�ƈ�v���Ȃ��ꍇ
                    //if (_prevGoodsRateGrpCode != inputValue) // DEL 2010/09/25
                    //if(inputValue != 0) // ADD 2010/09/25
                    //{ // DEL 2010/09/25
                        // --- DEL 2010/09/25 ---------->>>>>
                        //// ���͖���
                        //if (inputValue == 0)
                        //{
                        //    this.Detail_uGrid.ActiveCell.Value = 0;
                        //}
                        //else
                        // --- DEL 2010/09/25 ----------<<<<<
                        //{ // DEL 2010/09/25
                            string name = GetGoodsMGroupName(inputValue);
                            if (!string.IsNullOrEmpty(name))
                            {
                                this.Detail_uGrid.ActiveCell.Activation = Activation.NoEdit;
                                ((RateProtyMngPatternDataSet.RateProtyMngPatternRow)this._rateProtyMngPatternDataSet.RateProtyMngPattern.Rows[rowIndex2]).MasterNm = name;
                                //((RateProtyMngPatternDataSet.RateProtyMngPatternRow)this._rateProtyMngPatternDataSet.RateProtyMngPattern.Rows[rowIndex2]).GoodsRateGrpCode = inputValue;// DEL 2010/09/25
                                ((RateProtyMngPatternDataSet.RateProtyMngPatternRow)this._rateProtyMngPatternDataSet.RateProtyMngPattern.Rows[rowIndex2]).GoodsRateGrpCode = inputValue.ToString("D4");// ADD 2010/09/25
                                this._prevGoodsRateGrpCode = inputValue;
                                this._searchFlg = true;
                            }
                            else
                            {
                                // �G���[��
                                TMsgDisp.Show(
                                    this,
                                    emErrorLevel.ERR_LEVEL_INFO,
                                    this.Name,
                                    "���i�|���f�}�X�^�����o�^�ł��B",
                                    -1,
                                    MessageBoxButtons.OK);
                                // --- ADD 2010/09/09 ---------->>>>>
                                ((RateProtyMngPatternDataSet.RateProtyMngPatternRow)this._rateProtyMngPatternDataSet.RateProtyMngPattern.Rows[rowIndex]).MasterNm = string.Empty;
                                ((RateProtyMngPatternDataSet.RateProtyMngPatternRow)this._rateProtyMngPatternDataSet.RateProtyMngPattern.Rows[rowIndex]).GoodsRateGrpCode = string.Empty; // ADD 2010/09/25
                                //this._errorFlg = true;
                                //this.Detail_uGrid.ActiveCell.SelectAll(); // DEL 2010/09/25
                                this._errorFlg = true; // ADD 2010/09/25
                                this._errorFlg2 = true; // ADD 2010/09/25
                                // --- ADD 2010/09/09 ----------<<<<<
                            }
                        //} // DEL 2010/09/25
                    //} // DEL 2010/09/25
                    // --- DEL 2010/09/25 ---------->>>>>
                    //else 
                    //{
                    //    if (inputValue != 0 && !this._errorFlg) 
                    //    {
                    //        this.Detail_uGrid.ActiveCell.Activation = Activation.NoEdit;
                    //        ((RateProtyMngPatternDataSet.RateProtyMngPatternRow)this._rateProtyMngPatternDataSet.RateProtyMngPattern.Rows[rowIndex2]).MasterNm = GetGoodsMGroupName(inputValue);
                    //        ((RateProtyMngPatternDataSet.RateProtyMngPatternRow)this._rateProtyMngPatternDataSet.RateProtyMngPattern.Rows[rowIndex2]).GoodsRateGrpCode = inputValue;
                    //        this._prevGoodsRateGrpCode = inputValue;
                    //        this._searchFlg = true;
                    //    }
                    //    if (inputValue == 0)
                    //    {
                    //        if (this._searchFlg)
                    //        {
                    //            this._searchFlg = false;
                    //            return;
                    //        }
                    //        else
                    //        {
                    //            // �G���[��
                    //            TMsgDisp.Show(
                    //                this,
                    //                emErrorLevel.ERR_LEVEL_INFO,
                    //                this.Name,
                    //                "���i�|���f�}�X�^�����o�^�ł��B",
                    //                -1,
                    //                MessageBoxButtons.OK);
                    //            // --- ADD 2010/09/09 ---------->>>>>
                    //            ((RateProtyMngPatternDataSet.RateProtyMngPatternRow)this._rateProtyMngPatternDataSet.RateProtyMngPattern.Rows[rowIndex]).MasterNm = string.Empty;
                    //            ((RateProtyMngPatternDataSet.RateProtyMngPatternRow)this._rateProtyMngPatternDataSet.RateProtyMngPattern.Rows[rowIndex]).GoodsRateGrpCode = 0; // ADD 2010/09/25

                    //            this.Detail_uGrid.ActiveCell.SelectAll();
                    //            // --- ADD 2010/09/09 ----------<<<<<
                    //        }
                    //    }
                    //}
                    // --- DEL 2010/09/25 ----------<<<<<
                }
            }
            #endregion
            // --- ADD 2010/09/09 ----------<<<<<

        }

        /// <summary>
        /// Button_Click �C�x���g(CustomerGuide_Button)
        /// </summary>
        /// <param name="sender">�C�x���g�I�u�W�F�N�g</param>
        /// <param name="e">�C�x���g���</param>
        /// <remarks>
        /// <br>Note		: ���Ӑ�K�C�h�{�^�����N���b�N���ꂽ���ɔ������܂��B</br>
        /// <br>Programmer	: ����</br>
        /// <br>Date		: 2010/08/19</br>
        /// <br>Update Note : 2010/09/09 hanby</br>
        /// <br>            : Redmine#14492�Ή�</br>
        /// </remarks>
        private void CustomerGuide_Button_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                this._cusotmerGuideSelected = false;

                // ���Ӑ�K�C�h
                PMKHN04005UA customerSearchForm = new PMKHN04005UA(PMKHN04005UA.SEARCHMODE_CUSTOMER_ONLY, PMKHN04005UA.EXECUTEMODE_GUIDE_ONLY);

                customerSearchForm.CustomerSelect += new PMKHN04005UA.CustomerSelectEventHandler(this.CustomerSearchForm_CustomerSelect);
                customerSearchForm.ShowDialog(this);

                // �t�H�[�J�X�ݒ�
                if (this._cusotmerGuideSelected == true)
                {
                    bool focusCheck = SetFocus(3);
                    if (focusCheck == false)
                    {
                        //SearchRateData();
                        this.Search(); // ADD 2010/09/09
                        // -------ADD 2010/09/28----------->>>>>
                        if (this._isCancelFlg)
                        {
                            this._isCancelFlg = false;
                            return;
                        }
                        else if (this.Detail_uGrid.Rows.Count != 0 && this._checkInputScreenErr == false)
                        {
                            if (this.Mode_Label.Text == INSERT_MODE)
                            {
                                if (!this._initFocusFlag)
                                {
                                    this.Detail_uGrid.Focus();
                                    this.Detail_uGrid.ActiveRow = this.Detail_uGrid.Rows[0];
                                    this.Detail_uGrid.Rows[0].Cells[masterCode].Activate();
                                    this.InitGridFocus(0, 0);
                                }
                                else
                                {
                                    this._initFocusFlag = false;
                                }
                            }
                            else
                            {
                                this.Detail_uGrid.Focus();
                                this.Detail_uGrid.ActiveRow = this.Detail_uGrid.Rows[0];
                                this.Detail_uGrid.Rows[0].Cells[masterCode].Activate();
                                ChangeFocusEventArgs evt = new ChangeFocusEventArgs(false, false, false, Keys.Tab, this.Detail_uGrid, this.Detail_uGrid);
                                this.SetGridTabFocus(ref evt);
                            }
                        }
                        this._isCancelFlg = false;
                        this._checkInputScreenErr = false;
                        // -------ADD 2010/09/28-----------<<<<<
                    }
                }
                // ---ADD 2010/09/09---------------------->>>
                #region�@���K�C�h�L�������̐ݒ�
                if (this.tNedit_CustomerCode.Focused || this.tNedit_CustRateGrpCodeZero.Focused || this.tNedit_SupplierCd.Focused || tNedit_GoodsMakerCd.Focused)
                {
                    this.tToolbarsManager_MainMenu.Tools["ButtonTool_Guide"].SharedProps.Enabled = true;
                }
                #endregion
                // ---ADD 2010/09/09----------------------<<<
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }

        }

        /// <summary>
        /// ���Ӑ�I���������C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="customerSearchRet">���Ӑ挟���߂�l�N���X</param>
        /// <remarks>
        /// <br>Note        : ���Ӑ�I�����ɔ������܂��B</br>
        /// <br>Programmer	: ����</br>
        /// <br>Date		: 2010/08/19</br>
        /// </remarks>
        private void CustomerSearchForm_CustomerSelect(object sender, CustomerSearchRet customerSearchRet)
        {
            if (customerSearchRet == null)
            {
                this._cusotmerGuideSelected = false;
                return;
            }

            if (customerSearchRet.CustomerCode != this._prevCustomerCode)
            {
                this._prevCustomerCode = customerSearchRet.CustomerCode;

                // ���Ӑ�R�[�h
                this.tNedit_CustomerCode.SetInt(customerSearchRet.CustomerCode);

                // ���Ӑ於��
                this.CustomerCodeNm_tEdit.DataText = customerSearchRet.Snm.Trim();
            }

            this._cusotmerGuideSelected = true;
        }

        /// <summary>
        /// Button_Click �C�x���g(SupplierGuide_Button)
        /// </summary>
        /// <param name="sender">�C�x���g�I�u�W�F�N�g</param>
        /// <param name="e">�C�x���g���</param>
        /// <remarks>
        /// <br>Note		: �d����K�C�h�{�^�����N���b�N���ꂽ���ɔ������܂��B</br>
        /// <br>Programmer	: ����</br>
        /// <br>Date		: 2010/08/19</br>
        /// <br>Update Note : 2010/09/09 hanby</br>
        /// <br>            : Redmine#14492�Ή�</br>
        /// </remarks>
        private void SupplierGuide_Button_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                int status;
                Supplier supplier = new Supplier();

                // �d����K�C�h�\��
                status = this._supplierAcs.ExecuteGuid(out supplier, this._enterpriseCode, _loginSectionCode);
                if (status == 0)
                {
                    if (supplier.SupplierCd != this._prevSupplierCode)
                    {
                        this._prevSupplierCode = supplier.SupplierCd;

                        // �d����R�[�h
                        this.tNedit_SupplierCd.SetInt(supplier.SupplierCd);

                        // �d���於��
                        this.SupplierCdNm_tEdit.DataText = supplier.SupplierSnm.Trim();
                    }

                    // �t�H�[�J�X�ݒ�
                    bool focusCheck = SetFocus(3);
                    if (focusCheck == false)
                    {
                        //SearchRateData();
                        this.Search(); // ADD 2010/09/09
                        // -------ADD 2010/09/28----------->>>>>
                        if (this._isCancelFlg)
                        {
                            this._isCancelFlg = false;
                            return;
                        }
                        else if (this.Detail_uGrid.Rows.Count != 0 && this._checkInputScreenErr == false)
                        {
                            if (this.Mode_Label.Text == INSERT_MODE)
                            {
                                if (!this._initFocusFlag)
                                {
                                    this.Detail_uGrid.Focus();
                                    this.Detail_uGrid.ActiveRow = this.Detail_uGrid.Rows[0];
                                    this.Detail_uGrid.Rows[0].Cells[masterCode].Activate();
                                    this.InitGridFocus(0, 0);
                                }
                                else
                                {
                                    this._initFocusFlag = false;
                                }
                            }
                            else
                            {
                                this.Detail_uGrid.Focus();
                                this.Detail_uGrid.ActiveRow = this.Detail_uGrid.Rows[0];
                                this.Detail_uGrid.Rows[0].Cells[masterCode].Activate();
                                ChangeFocusEventArgs evt = new ChangeFocusEventArgs(false, false, false, Keys.Tab, this.Detail_uGrid, this.Detail_uGrid);
                                this.SetGridTabFocus(ref evt);
                            }
                        }
                        this._isCancelFlg = false;
                        this._checkInputScreenErr = false;
                        // -------ADD 2010/09/28-----------<<<<<
                    }
                }
                // ---ADD 2010/09/09---------------------->>>
                #region�@���K�C�h�L�������̐ݒ�
                if (this.tNedit_CustomerCode.Focused || this.tNedit_CustRateGrpCodeZero.Focused || this.tNedit_SupplierCd.Focused || tNedit_GoodsMakerCd.Focused)
                {
                    this.tToolbarsManager_MainMenu.Tools["ButtonTool_Guide"].SharedProps.Enabled = true;
                }
                #endregion
                // ---ADD 2010/09/09----------------------<<<
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Button_Click �C�x���g(MakerGuide_Button)
        /// </summary>
        /// <param name="sender">�C�x���g�I�u�W�F�N�g</param>
        /// <param name="e">�C�x���g���</param>
        /// <remarks>
        /// <br>Note		: ���[�J�[�K�C�h�{�^�����N���b�N���ꂽ���ɔ������܂��B</br>
        /// <br>Programmer	: ����</br>
        /// <br>Date		: 2010/08/19</br>
        /// <br>Update Note : 2010/09/09 hanby</br>
        /// <br>            : Redmine#14492�Ή�</br>
        /// </remarks>
        private void MakerGuide_Button_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                int status;
                MakerUMnt makerUMnt = new MakerUMnt();

                // ���[�J�[�K�C�h�\��
                status = this._makerAcs.ExecuteGuid(this._enterpriseCode, out makerUMnt);
                if (status == 0)
                {
                    if (makerUMnt.GoodsMakerCd != this._prevMakerCode)
                    {
                        this._prevMakerCode = makerUMnt.GoodsMakerCd;

                        // ���[�J�[�R�[�h
                        this.tNedit_GoodsMakerCd.SetInt(makerUMnt.GoodsMakerCd);

                        // ���[�J�[����
                        this.MakerName_tEdit.DataText = makerUMnt.MakerName.Trim();
                    }

                    // �t�H�[�J�X�ݒ�
                    bool focusCheck = SetFocus(3);
                    if (focusCheck == false)
                    {
                        //SearchRateData();
                        this.Search(); // ADD 2010/09/09
                        // -------ADD 2010/09/28----------->>>>>
                        if (this._isCancelFlg)
                        {
                            this._isCancelFlg = false;
                            return;
                        }
                        else if (this.Detail_uGrid.Rows.Count != 0 && this._checkInputScreenErr == false)
                        {
                            if (this.Mode_Label.Text == INSERT_MODE)
                            {
                                if (!this._initFocusFlag)
                                {
                                    this.Detail_uGrid.Focus();
                                    this.Detail_uGrid.ActiveRow = this.Detail_uGrid.Rows[0];
                                    this.Detail_uGrid.Rows[0].Cells[masterCode].Activate();
                                    this.InitGridFocus(0, 0);
                                }
                                else
                                {
                                    this._initFocusFlag = false;
                                }
                            }
                            else
                            {
                                this.Detail_uGrid.Focus();
                                this.Detail_uGrid.ActiveRow = this.Detail_uGrid.Rows[0];
                                this.Detail_uGrid.Rows[0].Cells[masterCode].Activate();
                                ChangeFocusEventArgs evt = new ChangeFocusEventArgs(false, false, false, Keys.Tab, this.Detail_uGrid, this.Detail_uGrid);
                                this.SetGridTabFocus(ref evt);
                            }
                        }
                        this._isCancelFlg = false;
                        this._checkInputScreenErr = false;
                        // -------ADD 2010/09/28-----------<<<<<
                    }
                }

            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Button_Click �C�x���g(CustRateGrpGuide_Button)
        /// </summary>
        /// <param name="sender">�C�x���g�I�u�W�F�N�g</param>
        /// <param name="e">�C�x���g���</param>
        /// <remarks>
        /// <br>Note		: ���Ӑ�|���O���[�v�K�C�h�{�^�����N���b�N���ꂽ���ɔ������܂��B</br>
        /// <br>Programmer	: ����</br>
        /// <br>Date		: 2010/08/19</br>
        /// <br>Update Note : 2010/09/09 hanby</br>
        /// <br>            : Redmine#14492�Ή�</br>
        /// <br>Update Note : 2010/09/26 ������</br>
        /// <br>            : Redmine#14492�Ή�</br>
        /// </remarks>
        private void CustRateGrpGuide_Button_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                int status;

                UserGdHd userGdHd;
                UserGdBd userGdBd;

                status = this._userGuideAcs.ExecuteGuid(this._enterpriseCode, out userGdHd, out userGdBd, 43);
                if (status == 0)
                {
                    // ---------UPD 2010/09/26--------->>>>>
                    //if (userGdBd.GuideCode == 0)
                    //{
                    //    this.tNedit_CustomerCode.Clear();
                    //    this.tEdit_CustRateGrpNm.Clear();
                    //}
                    //else
                    //{
                    //    this.tNedit_CustRateGrpCodeZero.DataText = userGdBd.GuideCode.ToString("D4");
                    //    this.tEdit_CustRateGrpNm.DataText = userGdBd.GuideName;
                    //}
                    this.tNedit_CustRateGrpCodeZero.DataText = userGdBd.GuideCode.ToString("D4");
                    this.tEdit_CustRateGrpNm.DataText = userGdBd.GuideName;
                    // ---------UPD 2010/09/26---------<<<<<
                    this._prevCustRateGrpCode = userGdBd.GuideCode;
                    // �t�H�[�J�X�ݒ�
                    bool focusCheck = SetFocus(3);
                    if (focusCheck == false)
                    {
                        //SearchRateData();
                        this.Search(); // ADD 2010/09/09
                        // -------ADD 2010/09/28----------->>>>>
                        if (this._isCancelFlg)
                        {
                            this._isCancelFlg = false;
                            return;
                        }
                        else if (this.Detail_uGrid.Rows.Count != 0 && this._checkInputScreenErr == false)
                        {
                            if (this.Mode_Label.Text == INSERT_MODE)
                            {
                                if (!this._initFocusFlag)
                                {
                                    this.Detail_uGrid.Focus();
                                    this.Detail_uGrid.ActiveRow = this.Detail_uGrid.Rows[0];
                                    this.Detail_uGrid.Rows[0].Cells[masterCode].Activate();
                                    this.InitGridFocus(0, 0);
                                }
                                else
                                {
                                    this._initFocusFlag = false;
                                }
                            }
                            else
                            {
                                this.Detail_uGrid.Focus();
                                this.Detail_uGrid.ActiveRow = this.Detail_uGrid.Rows[0];
                                this.Detail_uGrid.Rows[0].Cells[masterCode].Activate();
                                ChangeFocusEventArgs evt = new ChangeFocusEventArgs(false, false, false, Keys.Tab, this.Detail_uGrid, this.Detail_uGrid);
                                this.SetGridTabFocus(ref evt);
                            }
                        }
                        this._isCancelFlg = false;
                        this._checkInputScreenErr = false;
                        // -------ADD 2010/09/28-----------<<<<<
                    }
                }
                // ---ADD 2010/09/09---------------------->>>
                #region�@���K�C�h�L�������̐ݒ�
                if (this.tNedit_CustomerCode.Focused || this.tNedit_CustRateGrpCodeZero.Focused || this.tNedit_SupplierCd.Focused || tNedit_GoodsMakerCd.Focused)
                {
                    this.tToolbarsManager_MainMenu.Tools["ButtonTool_Guide"].SharedProps.Enabled = true;
                }
                #endregion
                // ---ADD 2010/09/09----------------------<<<
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Button_Click �C�x���g(CellDataError)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note		: ���Ӑ�|���O���[�v�K�C�h�{�^�����N���b�N���ꂽ���ɔ������܂��B</br>
        /// <br>Programmer	: ����</br>
        /// <br>Date		: 2010/08/19</br>
        /// </remarks>
        private void Detail_uGrid_CellDataError(object sender, CellDataErrorEventArgs e)
        {
            if (this.Detail_uGrid.ActiveCell != null)
            {
                if ((this.Detail_uGrid.ActiveCell.Column.DataType == typeof(Double)))
                {

                    Infragistics.Win.EmbeddableEditorBase editorBase = this.Detail_uGrid.ActiveCell.EditorResolved;

                    editorBase.Value = 0;
                    this.Detail_uGrid.ActiveCell.Value = 0;
                }

                e.RaiseErrorEvent = false;
            }

        }

        /// <summary>
        /// �O���b�h�}�E�X�N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note        : �O���b�h�}�E�X�N���b�N���鎞�ɔ������܂��B</br>
        /// <br>Programmer  : ����</br>
        /// <br>Date		: 2010/08/19</br>
        /// <br>Update Note : 2010/09/09 hanby</br>
        /// <br>            : Redmine#14492�Ή�</br>
        /// </remarks>
        private void Detail_uGrid_MouseClick(object sender, MouseEventArgs e)
        {
            // ---ADD 2010/09/09---------------------->>>
            #region ���K�C�h�L�������̐ݒ�
            if (this.Detail_uGrid.ActiveCell != null)
            {
                //if (this.Detail_uGrid.ActiveCell.Column.Key.Equals("MasterNm") && (this.Detail_uGrid.ActiveCell.Activation == Activation.AllowEdit)) // DEL 2010/09/25
                if (this.Detail_uGrid.ActiveCell.Column.Key.Equals(masterCode) && (this.Detail_uGrid.ActiveCell.Activation == Activation.AllowEdit)) // ADD 2010/09/25
                {
                    this.tToolbarsManager_MainMenu.Tools["ButtonTool_Guide"].SharedProps.Enabled = true;
                }
                else
                {
                    this.tToolbarsManager_MainMenu.Tools["ButtonTool_Guide"].SharedProps.Enabled = false;
                }
            }
            else
            {
                this.tToolbarsManager_MainMenu.Tools["ButtonTool_Guide"].SharedProps.Enabled = false;
            }
            #endregion

            #region ���[�������敪�`�F�b�N
            if (this._preUnPrcFracProcDivNmCell != null)
            {
                switch (this._preUnPrcFracProcDivNmCell.Text)
                {
                    case "1":
                    case "1:�؎̂�":
                    case "2":
                    case "2:�l�̌ܓ�":
                    case "3":
                    case "3:�؏グ":
                        break;
                    default:
                        this._preUnPrcFracProcDivNmCell.Value = 2;
                        break;
                }
            }
            #endregion
            // ---ADD 2010/09/09----------------------<<<

            // �E�N���b�N�ȊO�̏ꍇ
            //if (e.Button != MouseButtons.Right) return; // DEL 2010/09/09

            if (this.Detail_uGrid.ActiveRow == null) return;

            System.Drawing.Point nowPos = new Point(e.X, e.Y);

            Infragistics.Win.UIElement objElement = this.Detail_uGrid.DisplayLayout.UIElement.ElementFromPoint(nowPos);

            // ---ADD 2010/09/09---------------------->>>
            if (objElement.SelectableItem is Infragistics.Win.UltraWinGrid.UltraGridCell)
            {
                UltraGridCell nextCell = (UltraGridCell)objElement.SelectableItem;
                nextCell.Activate();
                this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
            }
            if (e.Button != MouseButtons.Right) return;
            // ---ADD 2010/09/09----------------------<<<

            // �N���b�N�ʒu����w�b�_�[������
            bool isColumnHeader = false;

            if (objElement != null)
            {
                if ((objElement.SelectableItem is Infragistics.Win.UltraWinGrid.ColumnHeader) ||
                    (objElement is Infragistics.Win.UltraWinGrid.HeaderUIElement))
                {
                    isColumnHeader = true;
                }
            }

            if (isColumnHeader)
            {
                // ��w�b�_�[�E�N���b�N���͉������Ȃ�
            }
            else
            {
                // ����ȊO�ŉE�N���b�N���ꂽ�ꍇ�́A�ҏW�̃|�b�v�A�b�v��\������
                ((Infragistics.Win.UltraWinToolbars.PopupMenuTool)this.tToolbarsManager_MainMenu.Tools["PopupMenuTool_grid"]).ShowPopup(System.Windows.Forms.Cursor.Position, this.Detail_uGrid);

                if ((this.Detail_uGrid.ActiveCell == null) && (this.Detail_uGrid.ActiveRow != null))
                {
                    if (this.Detail_uGrid.ActiveRow.Selected)
                    {
                        //
                    }
                    else
                    {
                        this.Detail_uGrid.Selected.Rows.Clear();
                        this.Detail_uGrid.ActiveRow.Selected = true;
                    }
                }
            }
        }

        #endregion Event

        #region Private Method

        /// <summary>
        /// �A�C�R���ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note        : �c�[���o�[�ƃ{�^���̃A�C�R����ݒ肵�܂��B</br>
        /// <br>Programmer	: ����</br>
        /// <br>Date		: 2010/08/19</br>
        /// <br>Update Note : 2010/09/09 hanby</br>
        /// <br>            : Redmine#14492�Ή�</br>
        /// </remarks>
        private void SetIcon()
        {
            ImageList imageList16 = IconResourceManagement.ImageList16;

            // -----------------------------
            // �c�[���o�[�A�C�R���ݒ�
            // -----------------------------
            // �C���[�W���X�g�ݒ�
            this.tToolbarsManager_MainMenu.ImageListSmall = IconResourceManagement.ImageList16;
            // �I��
            this.tToolbarsManager_MainMenu.Tools[TOOLBAR_CLOSEBUTTON_KEY].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;
            // �N���A
            this.tToolbarsManager_MainMenu.Tools[TOOLBAR_CLEARBUTTON_KEY].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.ALLCANCEL;
            // �ۑ�
            this.tToolbarsManager_MainMenu.Tools[TOOLBAR_SAVEBUTTON_KEY].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SAVE;
            // ����
            this.tToolbarsManager_MainMenu.Tools[TOOLBAR_SEARCHBUTTON_KEY].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SEARCH;
            // �ݒ�
            this.tToolbarsManager_MainMenu.Tools[TOOLBAR_SETBUTTON_KEY].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SETUP1;
            // �s�폜
            this.tToolbarsManager_MainMenu.Tools[TOOLBAR_ROWDELETE_KEY].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.ROWDELETE;
            // ---------ADD 2010/09/09---------->>>>>
            // �S�폜
            this.tToolbarsManager_MainMenu.Tools[TOOLBAR_ALLROWDELETE_KEY].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.ROWDELETE;
            // �K�C�h
            this.tToolbarsManager_MainMenu.Tools[TOOLBAR_GUIDEBUTTON_KEY].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.GUIDE;
            // ---------ADD 2010/09/09----------<<<<<
            // ���O�C�����_
            this.tToolbarsManager_MainMenu.Tools[TOOLBAR_SECTIONTITLELABEL_KEY].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.BASE;
            // ���O�C�����_��
            ToolBase loginName = tToolbarsManager_MainMenu.Tools[TOOLBAR_SECTIONNAMELABEL_KEY];
            if (loginName != null && LoginInfoAcquisition.Employee != null)
            {
                SecInfoSet secInfoSet = new SecInfoSet();
                this._secInfoAcs.GetSecInfo(this._loginSectionCode, out secInfoSet);
                if (secInfoSet != null)
                {
                    loginName.SharedProps.Caption = secInfoSet.SectionGuideNm;
                }
            }
            // ���O�C���S����
            this.tToolbarsManager_MainMenu.Tools[TOOLBAR_LOGINTITLELABEL_KEY].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.EMPLOYEE;

            // �S���ҕ\��
            if (LoginInfoAcquisition.Employee != null)
            {
                this.tToolbarsManager_MainMenu.Tools[TOOLBAR_LOGINNAMELABEL_KEY].SharedProps.Caption = LoginInfoAcquisition.Employee.Name;
            }
            // -----------------------------
            // �{�^���A�C�R���ݒ�
            // -----------------------------
            this.CustomerGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.CustRateGrpGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.SupplierGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.MakerGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
        }

        /// <summary>
        /// �t�H�[�J�X�ݒ菈��
        /// </summary>
        /// <param name="mode">���[�h</param>
        /// <returns>status:(mode = 3���L��)</returns>
        /// <remarks>
        /// <br>Note        : �K�C�h�{�^��������̃t�H�[�J�X�ݒ���s���܂��B</br>
        /// <br>Programmer	: ����</br>
        /// <br>Date		: 2010/08/19</br>
        /// <br>Update Note : 2010/09/09 hanby</br>
        /// <br>            : Redmine#14492�Ή�</br>
        /// </remarks>
        private bool SetFocus(int mode)
        {
            bool status = true;
            switch (mode)
            {
                #region ��ʏ����t�H�[�J�X�擾(�O���b�h����)
                case 0:
                    {
                        if (_initFocus != null)
                        {
                            if (_initFocus is TNedit)
                            {
                                ((TNedit)_initFocus).Focus();
                            }
                            else if (_initFocus is TEdit)
                            {
                                ((TEdit)_initFocus).Focus();
                            }

                        }
                        else
                        {

                            if (_endFocus is TNedit)
                            {
                                ((TNedit)_endFocus).Focus();
                            }
                            else if (_endFocus is TEdit)
                            {
                                ((TEdit)_endFocus).Focus();
                            }
                        }

                        break;
                    }
                #endregion

                #region Grid->���o������(key.Up)
                case 1:
                    {
                        if (_endFocus != null)
                        {

                            if (_endFocus is TNedit)
                            {
                                ((TNedit)_endFocus).Focus();
                            }
                            else if (_endFocus is TEdit)
                            {
                                ((TEdit)_endFocus).Focus();
                            }
                        }

                        break;
                    }
                #endregion Grid->���o������(key.Up)

                #region Grid->���o������(shift + Tab)
                //case 2:
                //    {
                //        if (_endButtonFocus != null)
                //        {
                //            ((UltraButton)_endButtonFocus).Focus();
                //        }
                //        break;
                //    }
                case 2:
                    {
                        if (_endFocus != null)
                        {
                            if (_endFocus is TNedit)
                            {
                                TNedit tNedit = (TNedit)_endFocus;
                                ((UltraButton)_endButtonFocus).Focus();
                            }
                            else if (_endFocus is TEdit)
                            {
                                TEdit tEdit = (TEdit)_endFocus;
                                ((UltraButton)_endButtonFocus).Focus();
                            }
                        }
                        break;
                    }
                #endregion Grid->���o������(shift + Tab)

                #region Next�t�H�[�J�X�ݒ�
                case 3:
                    {
                        // ���Ӑ�
                        if (this.tNedit_CustomerCode.Focused || this.CustomerGuide_Button.Focused)
                        {
                            if (this.tNedit_CustRateGrpCodeZero.Enabled)
                            {
                                this.tNedit_CustRateGrpCodeZero.Focus();
                            }
                            else if (this.tNedit_SupplierCd.Enabled)
                            {
                                this.tNedit_SupplierCd.Focus();
                            }
                            else if (this.tNedit_GoodsMakerCd.Enabled)
                            {
                                this.tNedit_GoodsMakerCd.Focus();
                            }
                            else
                            {
                                status = false;
                            }
                        }
                        // ���Ӑ�|���O���[�v
                        else if (this.tNedit_CustRateGrpCodeZero.Focused || this.CustRateGrpGuide_Button.Focused)
                        {
                            if (this.tNedit_SupplierCd.Enabled)
                            {
                                this.tNedit_SupplierCd.Focus();
                            }
                            else if (this.tNedit_GoodsMakerCd.Enabled)
                            {
                                this.tNedit_GoodsMakerCd.Focus();
                            }
                            else
                            {
                                status = false;
                            }
                        }
                        // �d����
                        else if (this.tNedit_SupplierCd.Focused || this.SupplierGuide_Button.Focused)
                        {
                            if (this.tNedit_GoodsMakerCd.Enabled)
                            {
                                this.tNedit_GoodsMakerCd.Focus();
                            }
                            else
                            {
                                status = false;
                            }
                        }
                        // ���[�J�[
                        else if (this.tNedit_GoodsMakerCd.Focused || this.MakerGuide_Button.Focused)
                        {
                            status = false;
                        }
                        break;
                    }
                #endregion Next�t�H�[�J�X�ݒ�

                #region ���o������(shift + Tab)
                case 4:
                    {
                        // ���Ӑ�|���O���[�v
                        if (this.tNedit_CustRateGrpCodeZero.Focused || this.CustRateGrpGuide_Button.Focused)
                        {
                            if (this.tNedit_CustomerCode.Enabled)
                            {
                                this.CustomerGuide_Button.Focus();
                            }
                        }
                        // �d����
                        else if (this.tNedit_SupplierCd.Focused || this.SupplierGuide_Button.Focused)
                        {
                            if (this.tNedit_CustRateGrpCodeZero.Enabled)
                            {
                                this.CustRateGrpGuide_Button.Focus();
                            }
                            else if (this.tNedit_CustomerCode.Enabled)
                            {
                                this.CustomerGuide_Button.Focus();
                            }
                        }
                        break;
                    }
                #endregion ���o������(shift + Tab)

            }
            // --------ADD 2010/09/09-------->>>
            #region �����L�[��Grid���璊�o�������ւ̏ꍇ�̃K�C�h�L�������̐ݒ�
            if (this.tNedit_CustomerCode.Focused || this.tNedit_CustRateGrpCodeZero.Focused || this.tNedit_SupplierCd.Focused || tNedit_GoodsMakerCd.Focused)
            {
                this.tToolbarsManager_MainMenu.Tools["ButtonTool_Guide"].SharedProps.Enabled = true;
                if (this.Detail_uGrid.Rows.Count != 0)
                {
                    this.Delete_Button.Enabled = true;
                    this.DeleteAll_Button.Enabled = true;
                }
                else
                {
                    this.Delete_Button.Enabled = false;
                    this.DeleteAll_Button.Enabled = false;
                }
            }
            #endregion
            // --------ADD 2010/09/09--------<<<

            return status;
        }

        /// <summary>
        /// ���Ӑ�|���O���[�v���̎擾����
        /// </summary>
        /// <param name="custRateGrpCode">���Ӑ�|���O���[�v�R�[�h</param>
        /// <param name="custRateGrpName">���Ӑ�|���O���[�v����</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note        : �Ȃ�</br>
        /// <br>Programmer	: ����</br>
        /// <br>Date		: 2010/08/19</br>
        /// <br>Update Note : 2010/09/09 hanby</br>
        /// <br>            : Redmine#14492�Ή�</br>
        /// </remarks>
        private bool GetCustRateGrpName(int custRateGrpCode, out string custRateGrpName)
        {
            custRateGrpName = "";
            bool check = false;
            // --------UPD 2010/09/09-------->>>>>
            //if (_custRateGrpDic == null)
            //{
            //    LoadCustRateGrp();
            //}

            //if (this._custRateGrpDic.ContainsKey(custRateGrpCode))
            //{
            //    custRateGrpName = (string)this._custRateGrpDic[custRateGrpCode];
            //    check = true;
            //}

            UserGdBd userGdBd = null;
            UserGuideAcsData acsDataType = UserGuideAcsData.UserBodyData;
            int status = this._userGuideAcs.ReadBody(out userGdBd, this._enterpriseCode, 43, custRateGrpCode, ref acsDataType);

            if (userGdBd != null && status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && userGdBd.LogicalDeleteCode == 0)
            {
                custRateGrpName = userGdBd.GuideName;
                check = true;
            }
            // --------UPD 2010/09/09--------<<<<<<

            return check;
        }

        /// <summary>
        /// ���Ӑ�|���O���[�v���擾����
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note        : �Ȃ�</br>
        /// <br>Programmer	: ����</br>
        /// <br>Date		: 2010/08/19</br>
        /// </remarks>
        private int LoadCustRateGrp()
        {
            this._custRateGrpDic = new Dictionary<int, string>();

            int status;
            ArrayList retList = new ArrayList();

            // ���[�U�[�K�C�h�f�[�^�擾(���Ӑ�|���O���[�v)
            status = GetUserGuideBd(out retList, 43);
            if (status == 0)
            {
                foreach (UserGdBd userGdBd in retList)
                {
                    this._custRateGrpDic.Add(userGdBd.GuideCode, userGdBd.GuideName.Trim());
                }
            }

            return status;
        }

        /// <summary>
        /// ���[�U�[�K�C�h�f�[�^�擾����
        /// </summary>
        /// <param name="retList">���[�U�[�K�C�h�{�f�B�f�[�^���X�g</param>
        /// <param name="userGuideDivCd">�K�C�h�敪</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note        : �Ȃ�</br>
        /// <br>Programmer	: ����</br>
        /// <br>Date		: 2010/08/19</br>
        /// </remarks>
        private int GetUserGuideBd(out ArrayList retList, int userGuideDivCd)
        {
            int status;
            retList = new ArrayList();

            status = this._userGuideAcs.SearchAllDivCodeBody(out retList, this._enterpriseCode,
                                                             userGuideDivCd, UserGuideAcsData.UserBodyData);

            return status;
        }

        /// <summary>
        /// ��ʃN���A����
        /// </summary>
        /// <remarks>
        /// <br>Note        : ��ʏ����N���A���܂��B</br>
        /// <br>Programmer	: ����</br>
        /// <br>Date		: 2010/08/19</br>
        /// <br>Update Note : 2010/09/09 hanby</br>
        /// <br>            : Redmine#14492�Ή�</br>
        /// </remarks>
        private void ScreenClear()
        {
            this.Mode_Label.Text = INSERT_MODE;
            // ----------UPD 2010/09/09----------->>>>>
            this.ultraLabel_RateMngGoodsNm.Text = this._rateProtyMng.RateMngGoodsNm.Trim();
            // �w��Ȃ���\��
            //if (this._rateProtyMng.RateMngCustCd.Trim() == RATEMNGCUSTCD_NONE)
            //{
            //    this.ultraLabel_RateMngCustNm.Text = string.Empty;
            //}
            //else
            //{
            //    this.ultraLabel_RateMngCustNm.Text = this._rateProtyMng.RateMngCustNm.Trim();
            //}
            //this.ultraLabel_RateMngGoodsNm.Text = this._rateProtyMng.RateMngGoodsNm.Trim();
            this.ultraLabel_RateMngCustNm.Text = this._rateProtyMng.RateSettingDivide.Trim();
            this.ultraLabel_RateMngGoodsNm.Text = this._rateProtyMng.RateMngCustNm.Trim() + "+" + this._rateProtyMng.RateMngGoodsNm.Trim();
            if (this._rateProtyMng.UnitPriceKind == 1)
            {
                this.Setting_Label.Text = UnitPriceKindNM_1;
            }
            else if (this._rateProtyMng.UnitPriceKind == 2)
            {
                this.Setting_Label.Text = UnitPriceKindNM_2;
            }
            else if (this._rateProtyMng.UnitPriceKind == 3)
            {
                this.Setting_Label.Text = UnitPriceKindNM_3;
            }
            // ----------UPD 2010/09/09-----------<<<<<
            this.tNedit_GoodsMakerCd.Clear();
            this.MakerName_tEdit.Clear();
            this.tNedit_CustRateGrpCodeZero.Clear();
            this.tEdit_CustRateGrpNm.Clear();
            this.tNedit_CustomerCode.Clear();
            this.CustomerCodeNm_tEdit.Clear();
            this.tNedit_SupplierCd.Clear();
            this.SupplierCdNm_tEdit.Clear();

            ScreenToRateProtyMngPattern(ref this._rateProtyMngPatternWorkClone);
            this._prevMakerCode = 0;
            this._prevCustRateGrpCode = -1;
            this._prevCustomerCode = 0;
            this._prevSupplierCode = 0;

            this._rateProtyMngPatternDataSet.RateProtyMngPattern.Rows.Clear();

            this._prevGoodsRateGrpCode = 0; // ADD 2010/09/09
            this._preUnPrcFracProcDivNmCell = null; // ADD 2010/09/09

            // �t�H�[�J�X�ݒ�
            this.SetFocus(0);
        }

        /// <summary>
        /// �|���ݒ�敪�ɂ��A���Ӑ�A���Ӑ�|���O���[�v�A�d����̍��ڂ���͉ۂ̕ύX�B
        /// </summary>
        /// <remarks>
        /// <br>Note        : �|���ݒ�敪�ɂ��A���Ӑ�A���Ӑ�|���O���[�v�A�d����̍��ڂ���͉ۂ�ύX����B</br>
        /// <br>Programmer	: ����</br>
        /// <br>Date		: 2010/08/19</br>
        /// </remarks>
        private void ScreenInputEnable()
        {
            #region [�|���ݒ�敪�i���Ӑ�j]
            switch (this._rateProtyMng.RateMngCustCd.Trim())
            {
                case "1":// ���Ӑ� + �d����
                    {
                        // ���Ӑ�
                        this.tNedit_CustomerCode.Enabled = true;
                        this.CustomerCode_Label.Enabled = true;
                        this.CustomerCodeNm_tEdit.Enabled = true;
                        this.CustomerGuide_Button.Enabled = true;
                        //���Ӑ�|����ٰ��
                        this.tNedit_CustRateGrpCodeZero.Enabled = false;
                        this.tEdit_CustRateGrpNm.Enabled = false;
                        this.CustRateGrpCode_Label.Enabled = false;
                        this.CustRateGrpGuide_Button.Enabled = false;
                        //�d����
                        this.tNedit_SupplierCd.Enabled = true;
                        this.SupplierCd_Label.Enabled = true;
                        this.SupplierCdNm_tEdit.Enabled = true;
                        this.SupplierGuide_Button.Enabled = true;

                        this._initFocus = this.tNedit_CustomerCode;
                        this._endFocus = this.tNedit_SupplierCd;
                        this._endButtonFocus = this.SupplierGuide_Button;
                        break;
                    }
                case "2":// ���Ӑ�
                    {
                        // ���Ӑ�
                        this.tNedit_CustomerCode.Enabled = true;
                        this.CustomerCode_Label.Enabled = true;
                        this.CustomerCodeNm_tEdit.Enabled = true;
                        this.CustomerGuide_Button.Enabled = true;
                        //���Ӑ�|����ٰ��
                        this.tNedit_CustRateGrpCodeZero.Enabled = false;
                        this.tEdit_CustRateGrpNm.Enabled = false;
                        this.CustRateGrpCode_Label.Enabled = false;
                        this.CustRateGrpGuide_Button.Enabled = false;
                        //�d����
                        this.tNedit_SupplierCd.Enabled = false;
                        this.SupplierCd_Label.Enabled = false;
                        this.SupplierCdNm_tEdit.Enabled = false;
                        this.SupplierGuide_Button.Enabled = false;

                        this._initFocus = this.tNedit_CustomerCode;
                        this._endFocus = this.tNedit_CustomerCode;
                        this._endButtonFocus = this.CustomerGuide_Button;

                        break;
                    }
                case "3":// ���Ӑ�|��G + �d����
                    {
                        // ���Ӑ�
                        this.tNedit_CustomerCode.Enabled = false;
                        this.CustomerCode_Label.Enabled = false;
                        this.CustomerCodeNm_tEdit.Enabled = false;
                        this.CustomerGuide_Button.Enabled = false;
                        //���Ӑ�|����ٰ��
                        this.tNedit_CustRateGrpCodeZero.Enabled = true;
                        this.tEdit_CustRateGrpNm.Enabled = true;
                        this.CustRateGrpCode_Label.Enabled = true;
                        this.CustRateGrpGuide_Button.Enabled = true;
                        //�d����
                        this.tNedit_SupplierCd.Enabled = true;
                        this.SupplierCd_Label.Enabled = true;
                        this.SupplierCdNm_tEdit.Enabled = true;
                        this.SupplierGuide_Button.Enabled = true;

                        this._initFocus = this.tNedit_CustRateGrpCodeZero;
                        this._endFocus = this.tNedit_SupplierCd;
                        this._endButtonFocus = this.SupplierGuide_Button;

                        break;
                    }
                case "4":// ���Ӑ�|��G
                    {
                        // ���Ӑ�
                        this.tNedit_CustomerCode.Enabled = false;
                        this.CustomerCode_Label.Enabled = false;
                        this.CustomerCodeNm_tEdit.Enabled = false;
                        this.CustomerGuide_Button.Enabled = false;
                        //���Ӑ�|����ٰ��
                        this.tNedit_CustRateGrpCodeZero.Enabled = true;
                        this.tEdit_CustRateGrpNm.Enabled = true;
                        this.CustRateGrpCode_Label.Enabled = true;
                        this.CustRateGrpGuide_Button.Enabled = true;
                        //�d����
                        this.tNedit_SupplierCd.Enabled = false;
                        this.SupplierCd_Label.Enabled = false;
                        this.SupplierCdNm_tEdit.Enabled = false;
                        this.SupplierGuide_Button.Enabled = false;

                        this._initFocus = this.tNedit_CustRateGrpCodeZero;
                        this._endFocus = this.tNedit_CustRateGrpCodeZero;
                        this._endButtonFocus = this.CustRateGrpGuide_Button;

                        break;
                    }
                case "5":// �d����
                    {
                        // ���Ӑ�
                        this.tNedit_CustomerCode.Enabled = false;
                        this.CustomerCode_Label.Enabled = false;
                        this.CustomerCodeNm_tEdit.Enabled = false;
                        this.CustomerGuide_Button.Enabled = false;
                        //���Ӑ�|����ٰ��
                        this.tNedit_CustRateGrpCodeZero.Enabled = false;
                        this.tEdit_CustRateGrpNm.Enabled = false;
                        this.CustRateGrpCode_Label.Enabled = false;
                        this.CustRateGrpGuide_Button.Enabled = false;
                        //�d����
                        this.tNedit_SupplierCd.Enabled = true;
                        this.SupplierCd_Label.Enabled = true;
                        this.SupplierCdNm_tEdit.Enabled = true;
                        this.SupplierGuide_Button.Enabled = true;

                        this._initFocus = this.tNedit_SupplierCd;
                        this._endFocus = this.tNedit_SupplierCd;
                        this._endButtonFocus = this.SupplierGuide_Button;

                        break;
                    }
                case "6":// �w��Ȃ�
                    {
                        // ���Ӑ�
                        this.tNedit_CustomerCode.Enabled = false;
                        this.CustomerCode_Label.Enabled = false;
                        this.CustomerCodeNm_tEdit.Enabled = false;
                        this.CustomerGuide_Button.Enabled = false;
                        //���Ӑ�|����ٰ��
                        this.tNedit_CustRateGrpCodeZero.Enabled = false;
                        this.tEdit_CustRateGrpNm.Enabled = false;
                        this.CustRateGrpCode_Label.Enabled = false;
                        this.CustRateGrpGuide_Button.Enabled = false;
                        //�d����
                        this.tNedit_SupplierCd.Enabled = false;
                        this.SupplierCd_Label.Enabled = false;
                        this.SupplierCdNm_tEdit.Enabled = false;
                        this.SupplierGuide_Button.Enabled = false;

                        this._initFocus = this.tNedit_GoodsMakerCd;
                        this._endFocus = this.tNedit_GoodsMakerCd;
                        this._endButtonFocus = this.MakerGuide_Button;
                        break;
                    }
            }
            #endregion [�|���ݒ�敪�i���Ӑ�j]

            #region [�|���ݒ�敪�i���i�j]
            switch (this._rateProtyMng.RateMngGoodsCd.Trim())
            {
                case "F": // Ұ�� + ���i�|��G
                    {
                        // ���[�J�[
                        this.tNedit_GoodsMakerCd.Enabled = true;
                        this.GoodsMakerCd_Grp_Label.Enabled = true;
                        this.MakerName_tEdit.Enabled = true;
                        this.MakerGuide_Button.Enabled = true;

                        this._endFocus = this.tNedit_GoodsMakerCd;
                        this._endButtonFocus = this.MakerGuide_Button;

                        break;
                    }
                case "J": // ���͉�
                    {
                        // ���[�J�[
                        this.tNedit_GoodsMakerCd.Enabled = false;
                        this.GoodsMakerCd_Grp_Label.Enabled = false;
                        this.MakerName_tEdit.Enabled = false;
                        this.MakerGuide_Button.Enabled = false;

                        break;
                    }
            }
            #endregion [�|���ݒ�敪�i���i�j]
        }

        /// <summary>
        /// �O���b�h�ŏ�ʍs�L�[�_�E���C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : ��ʃw�b�_�N���A�������s���B </br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2010/08/19</br>
        /// </remarks>
        private void Detail_uGrid_GridKeyDownTopRow(object sender, EventArgs e)
        {
            //this.tComboEditor_UnitPriceKind.Focus();
        }

        /// <summary>
        /// ���[�U�[�ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note        : ���[�U�[�ݒ��ʂ�\�����܂��B</br>
        /// <br>Programmer  : ����</br>
        /// <br>Date        : 2010/08/19</br>
        /// </remarks>
        private void SetUp()
        {
            PMKHN09475UB pMKHN09477UB = new PMKHN09475UB();
            pMKHN09477UB.ShowDialog();

            this._cellMove = pMKHN09477UB.CellMove;
        }

        /// <summary>
        /// �O���b�h�t�H�[�J�X�ݒ菈��
        /// </summary>
        /// <param name="mode">���[�h</param>
        /// <param name="rowIndex">�O���b�h�s</param>
        /// <remarks>
        /// <br>Note        : �O���b�h�t�H�[�J�X�ݒ���s���܂��B</br>
        /// <br>Programmer  : ����</br>
        /// <br>Date        : 2010/08/19</br>
        /// <br>Update Note : 2010/09/09 hanby</br>
        /// <br>            : Redmine#14492�Ή�</br>
        /// </remarks>
        private void InitGridFocus(int rowIndex, int mode)
        {
            switch (mode)
            {
                // �O���b�h�������t�H�[�J�X�ݒ�
                case 0:
                    {
                        // ---UPD 2010/09/09---------------------->>>
                        // �����ꍇ
                        //if (this._rateProtyMng.UnitPriceKind == 1)
                        //{
                        //    // ������
                        //    this.Detail_uGrid.Rows[rowIndex].Cells[this._rateProtyMngPatternDataSet.RateProtyMngPattern.RateValColumn.ColumnName].Activate();
                        //}
                        //// �����ꍇ
                        //else if (this._rateProtyMng.UnitPriceKind == 2)
                        //{
                        //    // �d����
                        //    this.Detail_uGrid.Rows[0].Cells[this._rateProtyMngPatternDataSet.RateProtyMngPattern.RateValColumn.ColumnName].Activate();
                        //}
                        //// ���i�ꍇ
                        //else if (this._rateProtyMng.UnitPriceKind == 3)
                        //{
                        //    // �艿UP��
                        //    this.Detail_uGrid.Rows[0].Cells[this._rateProtyMngPatternDataSet.RateProtyMngPattern.UpRateColumn.ColumnName].Activate();
                        //}

                        // ���[�J�[�R�[�h
                        //this.Detail_uGrid.Rows[0].Cells[this._rateProtyMngPatternDataSet.RateProtyMngPattern.MasterNmColumn.ColumnName].Activate(); // DEL 2010/09/25
                        this.Detail_uGrid.Rows[0].Cells[this._rateProtyMngPatternDataSet.RateProtyMngPattern.GoodsRateGrpCodeColumn.ColumnName].Activate(); // ADD 2010/09/25
                        // ---UPD 2010/09/09----------------------<<<

                        break;
                    }
                // �O���b�h�ŏI���͗�t�H�[�J�X�ݒ�
                case 1:
                    {
                        // �����ꍇ
                        if (this._rateProtyMng.UnitPriceKind == 1)
                        {
                            // �e���m�ۗ�
                            this.Detail_uGrid.Rows[rowIndex].Cells[this._rateProtyMngPatternDataSet.RateProtyMngPattern.GrsProfitSecureRateColumn.ColumnName].Activate();
                        }
                        // �����ꍇ
                        else if (this._rateProtyMng.UnitPriceKind == 2)
                        {
                            // �d����
                            this.Detail_uGrid.Rows[0].Cells[this._rateProtyMngPatternDataSet.RateProtyMngPattern.RateValColumn.ColumnName].Activate();
                        }
                        // ���i�ꍇ
                        else if (this._rateProtyMng.UnitPriceKind == 3)
                        {
                            // �[�������敪
                            this.Detail_uGrid.Rows[0].Cells[this._rateProtyMngPatternDataSet.RateProtyMngPattern.UnPrcFracProcDivNmColumn.ColumnName].Activate();
                        }
                        break;
                    }
            }
            this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
            
        }

        #region �^�u�ړ�
        /// <summary>
        /// �O���b�h�^�u�ړ�����
        /// </summary>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note        : �O���b�h�Ƀt�H�[�J�X������ꍇ�̃^�u�ړ��𐧌䂵�܂��B</br>
        /// <br>Programmer  : ����</br>
        /// <br>Date        : 2010/08/19</br>
        /// <br>Update Note : 2010/09/09 hanby</br>
        /// <br>            : Redmine#14492�Ή�</br>
        /// </remarks>
        private void SetGridTabFocus(ref ChangeFocusEventArgs e)
        {
            if (this.Detail_uGrid.ActiveCell == null || this.Detail_uGrid.ActiveRow == null)
            {
                e.NextCtrl = null;
                this.Detail_uGrid.Focus();
                this.InitGridFocus(0, 0);
                this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                return;
            }

            int rowIndex = this.Detail_uGrid.ActiveCell.Row.Index;
            int columnIndex = this.Detail_uGrid.ActiveCell.Column.Index;
            string columnKey = this.Detail_uGrid.ActiveCell.Column.Key;

            e.NextCtrl = null;

            this.Detail_uGrid.PerformAction(UltraGridAction.ExitEditMode);

            // �Z���ړ��F�E
            if (this._cellMove == 0)
            {
                if ((rowIndex == this.Detail_uGrid.Rows.Count - 1) &&
                    (columnKey == GetGridLastColumKey()))
                {
                    // ---------DEL 2010/09/09---------->>>>>
                    //SetFocus(0);
                    this.Detail_uGrid.Rows[rowIndex].Cells[columnKey].Activate();
                    this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                    // ---------DEL 2010/09/09----------<<<<<
                    e.NextCtrl = null;
                }
                else
                {
                    this.Detail_uGrid.Focus();

                    string columnName = columnKey;
                    // ���Z���擾
                    int targetColumnIndex = GetNextColumnIndexByTab(0, rowIndex, columnName);
                    if (targetColumnIndex != -1)
                    {
                        this.Detail_uGrid.Rows[rowIndex].Cells[targetColumnIndex].Activate();
                        this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                        return;
                    }
                    else
                    {
                        // ���s
                        columnName = this.GetGridInitColumKey();
                        //for (int targetRowIndex = rowIndex + 1; targetRowIndex < this.Detail_uGrid.Rows.Count; targetRowIndex++)
                        //{
                        //    if (this.Detail_uGrid.Rows[targetRowIndex].Cells[columnName].Activation == Activation.AllowEdit)
                        //    {
                        //        this.Detail_uGrid.Rows[targetRowIndex].Cells[columnName].Activate();
                        //        this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                        //        return;
                        //    }
                        //}
                        // ---------DEL 2010/09/09---------->>>>>
                        //SetFocus(0);
                        //if (this.Detail_uGrid.Rows[rowIndex + 1].Cells[columnName].Activation == Activation.AllowEdit)
                        //{
                        //    this.Detail_uGrid.Rows[rowIndex + 1].Cells[columnName].Activate();
                        //    this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                        //    return;
                        //}
                        //else
                        //{
                        //    int nextColumnIndex = GetNextColumnIndexByTab(0, rowIndex + 1, columnName);
                        //    this.Detail_uGrid.Rows[rowIndex + 1].Cells[nextColumnIndex].Activate();
                        //    this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                        //}
                        if (this.Detail_uGrid.ActiveCell == null)
                        {
                            this.InitGridFocus(0, 0);
                            this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                            return;
                        }

                        if (!MoveNextAllowEditCell(false, 1))
                        {
                            // �Ȃ��B
                        }

                        this.Detail_uGrid.PerformAction(UltraGridAction.ExitEditMode);
                        this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                        // ---------DEL 2010/09/09----------<<<<<
                        e.NextCtrl = null;
                    }
                }
            }
            // �Z���ړ��F��
            else
            {
                if ((rowIndex == this.Detail_uGrid.Rows.Count - 1) &&
                    (columnKey == GetGridLastColumKey()))
                {
                    // ---------ADD 2010/09/09---------->>>>>
                    this.Detail_uGrid.Rows[rowIndex].Cells[columnKey].Activate();
                    this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                    // ---------ADD 2010/09/09----------<<<<<
                    e.NextCtrl = null;
                }
                else
                {
                    this.Detail_uGrid.Focus();

                    for (int targetRowIndex = rowIndex + 1; targetRowIndex < this.Detail_uGrid.Rows.Count; targetRowIndex++)
                    {
                        if (this.Detail_uGrid.Rows[targetRowIndex].Cells[columnIndex].Activation == Activation.AllowEdit)
                        {
                            this.Detail_uGrid.Rows[targetRowIndex].Cells[columnIndex].Activate();
                            this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                            return;
                        }
                    }

                    // ---------ADD 2010/09/09---------->>>>>
                    int targetColumnIndex = GetNextColumnIndexByTab(0, this.Detail_uGrid.Rows.Count - 1, columnKey);
                    if (targetColumnIndex > 0)
                    {
                        for (int index = columnIndex + 1; index < this._rateProtyMngPatternDataSet.Tables[0].Columns.Count; index++)
                        {
                            for (int targetRowIndex = 0; targetRowIndex < this.Detail_uGrid.Rows.Count; targetRowIndex++)
                            {
                                if (this.Detail_uGrid.Rows[targetRowIndex].Cells[targetColumnIndex].Activation == Activation.AllowEdit)
                                {
                                    this.Detail_uGrid.Rows[targetRowIndex].Cells[targetColumnIndex].Activate();
                                    this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                    return;
                                }
                            }
                        }
                    }
                    else
                    {
                        this.Detail_uGrid.Rows[rowIndex].Cells[columnKey].Activate();
                        this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                    }
                    // ---------ADD 2010/09/09----------<<<<<

                    e.NextCtrl = null;
                }
            }
        }

        /// <summary>
        /// �O���b�h�V�t�g�^�u����
        /// </summary>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note        : �O���b�h�Ƀt�H�[�J�X������ꍇ�̃V�t�g�^�u�ړ��𐧌䂵�܂��B</br>
        /// <br>Programmer  : ����</br>
        /// <br>Date        : 2010/08/19</br>
        /// <br>Update Note : 2010/09/09 hanby</br>
        /// <br>            : Redmine#14492�Ή�</br>
        /// </remarks>
        private void SetGridShiftTabFocus(ref ChangeFocusEventArgs e)
        {
            if (this.Detail_uGrid.ActiveCell == null)
            {
                e.NextCtrl = null;
                this.Detail_uGrid.Focus();
                if (this.Detail_uGrid.ActiveRow == null)
                {
                    this.InitGridFocus(0, 1);
                }
                else
                {
                    this.InitGridFocus(0, 0);
                }
                this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                return;
            }

            int rowIndex = this.Detail_uGrid.ActiveCell.Row.Index;
            int columnIndex = this.Detail_uGrid.ActiveCell.Column.Index;
            string columnKey = this.Detail_uGrid.ActiveCell.Column.Key;

            e.NextCtrl = null;

            // �Z���ړ��F�E
            if (this._cellMove == 0)
            {
                if ((rowIndex == 0) &&
                    (columnKey == GetGridInitColumKey()))
                {
                    //SetFocus(2); // DEL 2010/09/09
                    // ---------ADD 2010/09/09---------->>>>>
                    this.Detail_uGrid.ActiveCell = null;
                    this.Detail_uGrid.ActiveRow = null;
                    this.MakerGuide_Button.Focus();
                    // ---------ADD 2010/09/09----------<<<<<
                    e.NextCtrl = null;
                }
                else
                {
                    this.Detail_uGrid.Focus();

                    // ���Z���擾
                    string columnName = columnKey;
                    // ���Z���擾
                    int targetColumnIndex = GetNextColumnIndexByTab(1, rowIndex, columnName);
                    if (targetColumnIndex != -1)
                    {
                        this.Detail_uGrid.Rows[rowIndex].Cells[targetColumnIndex].Activate();
                        this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                        return;
                    }
                    else
                    {
                        // ���s
                        columnName = this.GetGridLastColumKey();
                        for (int targetRowIndex = rowIndex - 1; targetRowIndex >= 0; targetRowIndex--)
                        {
                            //if (this.Detail_uGrid.Rows[targetRowIndex].Cells[columnIndex].Activation == Activation.AllowEdit) // DEL 2010/09/09
                            if (this.Detail_uGrid.Rows[targetRowIndex].Cells[columnName].Activation == Activation.AllowEdit) // ADD 2010/09/09
                            {
                                this.Detail_uGrid.Rows[targetRowIndex].Cells[columnName].Activate();
                                this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                return;
                            }
                        }
                        //SetFocus(2); // DEL 2010/09/09
                        // ---------ADD 2010/09/09---------->>>>>
                        this.Detail_uGrid.ActiveCell = null;
                        this.Detail_uGrid.ActiveRow = null;
                        this.MakerGuide_Button.Focus();
                        // ---------ADD 2010/09/09----------<<<<<
                        e.NextCtrl = null;
                    }
                }
            }
            // �Z���ړ��F��
            else
            {
                if ((rowIndex == 0) &&
                    (columnKey == GetGridInitColumKey()))
                {
                    //SetFocus(2); // DEL 2010/09/09
                    // ---------ADD 2010/09/09---------->>>>>
                    this.Detail_uGrid.ActiveCell = null;
                    this.Detail_uGrid.ActiveRow = null;
                    this.MakerGuide_Button.Focus();
                    // ---------ADD 2010/09/09----------<<<<<
                }
                else
                {
                    this.Detail_uGrid.Focus();

                    for (int targetRowIndex = rowIndex - 1; targetRowIndex >= 0; targetRowIndex--)
                    {
                        if (this.Detail_uGrid.Rows[targetRowIndex].Cells[columnIndex].Activation == Activation.AllowEdit)
                        {
                            this.Detail_uGrid.Rows[targetRowIndex].Cells[columnIndex].Activate();
                            this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                            return;
                        }
                    }

                    int targetColumnIndex = GetNextColumnIndexByTab(1, this.Detail_uGrid.Rows.Count - 1, columnKey);

                    // ---------ADD 2010/09/09---------->>>>>
                    if (targetColumnIndex < 0)
                    {
                        SetFocus(2); // DEL 2010/09/09
                        // ---------ADD 2010/09/09---------->>>>>
                        this.Detail_uGrid.ActiveCell = null;
                        this.Detail_uGrid.ActiveRow = null;
                        //this.MakerGuide_Button.Focus();
                        // ---------ADD 2010/09/09----------<<<<<
                        return;
                    } 
                    if (columnIndex == 1)
                    {
                        this.Detail_uGrid.Rows[this.Detail_uGrid.Rows.Count - 1].Cells[this._rateProtyMngPatternDataSet.RateProtyMngPattern.GoodsNoColumn.ColumnName].Activate();
                        this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                    }
                    // ---------ADD 2010/09/09----------<<<<<

                    for (int index = columnIndex - 1; index > 0; index--)
                    {
                        for (int targetRowIndex = this.Detail_uGrid.Rows.Count - 1; targetRowIndex >= 0; targetRowIndex--)
                        {
                            if (this.Detail_uGrid.Rows[targetRowIndex].Cells[targetColumnIndex].Activation == Activation.AllowEdit)
                            {
                                this.Detail_uGrid.Rows[targetRowIndex].Cells[targetColumnIndex].Activate();
                                this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                return;
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// �O���b�h�ŏI�ҏW����擾����
        /// </summary>
        /// <remarks>
        /// <br>Note        : �O���b�h�ŏI�ҏW�擾���s���܂��B</br>
        /// <br>Programmer  : ����</br>
        /// <br>Date        : 2010/08/19</br>
        /// </remarks>
        private string GetGridLastColumKey()
        {
            string lastColumKey = string.Empty;
            // �����ꍇ
            if (this._rateProtyMng.UnitPriceKind == 1)
            {
                // �e���m�ۗ�
                lastColumKey = this._rateProtyMngPatternDataSet.RateProtyMngPattern.GrsProfitSecureRateColumn.ColumnName;
            }
            // �����ꍇ
            else if (this._rateProtyMng.UnitPriceKind == 2)
            {
                // �d����
                lastColumKey = this._rateProtyMngPatternDataSet.RateProtyMngPattern.RateValColumn.ColumnName;
            }
            // ���i�ꍇ
            else if (this._rateProtyMng.UnitPriceKind == 3)
            {
                // �[�������敪
                lastColumKey = this._rateProtyMngPatternDataSet.RateProtyMngPattern.UnPrcFracProcDivNmColumn.ColumnName;

            }
            return lastColumKey;
        }

        /// <summary>
        /// �O���b�h�����ҏW����擾����
        /// </summary>
        /// <remarks>
        /// <br>Note        : �O���b�h�����ҏW��擾���s���܂��B</br>
        /// <br>Programmer  : ����</br>
        /// <br>Date        : 2010/08/19</br>
        /// <br>Update Note : 2010/09/09 hanby</br>
        /// <br>            : Redmine#14492�Ή�</br>
        /// </remarks>
        private string GetGridInitColumKey()
        {
            string initColumKey = string.Empty;

            // ---UPD 2010/09/09---------------------->>>
            // �����ꍇ
            //if (this._rateProtyMng.UnitPriceKind == 1)
            //{
            //    // ������
            //    initColumKey = this._rateProtyMngPatternDataSet.RateProtyMngPattern.RateValColumn.ColumnName;
            //}
            //// �����ꍇ
            //else if (this._rateProtyMng.UnitPriceKind == 2)
            //{
            //    // �d����
            //    initColumKey = this._rateProtyMngPatternDataSet.RateProtyMngPattern.RateValColumn.ColumnName;
            //}
            //// ���i�ꍇ
            //else if (this._rateProtyMng.UnitPriceKind == 3)
            //{
            //    // �艿UP��
            //    initColumKey = this._rateProtyMngPatternDataSet.RateProtyMngPattern.UpRateColumn.ColumnName;
            //}
            // ���[�J�[�R�[�h
            //initColumKey = this._rateProtyMngPatternDataSet.RateProtyMngPattern.MasterNmColumn.ColumnName; // DEL 2010/09/25
            initColumKey = this._rateProtyMngPatternDataSet.RateProtyMngPattern.GoodsRateGrpCodeColumn.ColumnName; // ADD 2010/09/25
            // ---UPD 2010/09/09----------------------<<<
            return initColumKey;
        }

        /// <summary>
        /// �O���b�hNext�t�H�[�J�X�擾����
        /// </summary>
        /// <param name="mode">���[�h(0:Tab;1;Shift + Tab)</param>
        /// <param name="rowIndex">rowIndex</param>
        /// <param name="columnKey">columnKey</param>
        /// <returns>columnIndex</returns>
        /// <remarks>
        /// <br>Note        : �O���b�hNext�t�H�[�J�X�擾���s���܂��B</br>
        /// <br>Programmer  : ����</br>
        /// <br>Date        : 2010/08/19</br>
        /// <br>Update Note : 2010/09/09 hanby</br>
        /// <br>            : Redmine#14492�Ή�</br>
        /// </remarks>
        private int GetNextColumnIndexByTab(int mode, int rowIndex, string columnKey)
        {
            int columnIndex = -1;
            switch (mode)
            {
                case 0:
                    #region Tab
                    // �����ꍇ
                    if (this._rateProtyMng.UnitPriceKind == 1)
                    {
                        // ������
                        if (columnKey == this._rateProtyMngPatternDataSet.RateProtyMngPattern.RateValColumn.ColumnName)
                        {
                            // ����UP��
                            columnIndex = this.Detail_uGrid.Rows[rowIndex].Cells[this._rateProtyMngPatternDataSet.RateProtyMngPattern.UpRateColumn.ColumnName].Column.Index;
                        }
                        // ����UP��
                        else if (columnKey == this._rateProtyMngPatternDataSet.RateProtyMngPattern.UpRateColumn.ColumnName)
                        {
                            // �e���m�ۗ�
                            columnIndex = this.Detail_uGrid.Rows[rowIndex].Cells[this._rateProtyMngPatternDataSet.RateProtyMngPattern.GrsProfitSecureRateColumn.ColumnName].Column.Index;
                        }
                        // �e���m�ۗ�
                        else if (columnKey == this._rateProtyMngPatternDataSet.RateProtyMngPattern.GrsProfitSecureRateColumn.ColumnName)
                        {
                            columnIndex = -1;
                        }
                        // ---ADD 2010/09/09---------------------->>>
                        // ���[�J�[�R�[�h
                        //else if (columnKey == this._rateProtyMngPatternDataSet.RateProtyMngPattern.MasterNmColumn.ColumnName) // DEL 2010/09/25
                        else if (columnKey == this._rateProtyMngPatternDataSet.RateProtyMngPattern.GoodsRateGrpCodeColumn.ColumnName) // ADD 2010/09/25
                        {
                            // ������
                            columnIndex = this.Detail_uGrid.Rows[rowIndex].Cells[this._rateProtyMngPatternDataSet.RateProtyMngPattern.RateValColumn.ColumnName].Column.Index;
                        }
                        // ---ADD 2010/09/09----------------------<<<
                    }
                    // �����ꍇ
                    else if (this._rateProtyMng.UnitPriceKind == 2)
                    {
                        // �d����
                        if (columnKey == this._rateProtyMngPatternDataSet.RateProtyMngPattern.RateValColumn.ColumnName)
                        {
                            columnIndex = -1;
                        }
                        // ---ADD 2010/09/09---------------------->>>
                        // ���[�J�[�R�[�h
                        //else if (columnKey == this._rateProtyMngPatternDataSet.RateProtyMngPattern.MasterNmColumn.ColumnName) // DEL 2010/09/25
                        else if (columnKey == this._rateProtyMngPatternDataSet.RateProtyMngPattern.GoodsRateGrpCodeColumn.ColumnName) // ADD 2010/09/25
                        {
                            // �d����
                            columnIndex = this.Detail_uGrid.Rows[rowIndex].Cells[this._rateProtyMngPatternDataSet.RateProtyMngPattern.RateValColumn.ColumnName].Column.Index;
                        }
                        // ---ADD 2010/09/09----------------------<<<
                    }
                    // ���i�ꍇ
                    else if (this._rateProtyMng.UnitPriceKind == 3)
                    {
                        // �艿UP��
                        if (columnKey == this._rateProtyMngPatternDataSet.RateProtyMngPattern.UpRateColumn.ColumnName)
                        {
                            // �[�������P��
                            columnIndex = this.Detail_uGrid.Rows[rowIndex].Cells[this._rateProtyMngPatternDataSet.RateProtyMngPattern.UnPrcFracProcUnitColumn.ColumnName].Column.Index;
                        }
                        // �[�������P��
                        else if (columnKey == this._rateProtyMngPatternDataSet.RateProtyMngPattern.UnPrcFracProcUnitColumn.ColumnName)
                        {
                            // �[�������敪
                            columnIndex = this.Detail_uGrid.Rows[rowIndex].Cells[this._rateProtyMngPatternDataSet.RateProtyMngPattern.UnPrcFracProcDivNmColumn.ColumnName].Column.Index;
                        }
                        // �[�������敪
                        else if (columnKey == this._rateProtyMngPatternDataSet.RateProtyMngPattern.UnPrcFracProcDivNmColumn.ColumnName)
                        {
                            columnIndex = -1;
                        }
                        // ---ADD 2010/09/09---------------------->>>
                        // ���[�J�[�R�[�h
                        //else if (columnKey == this._rateProtyMngPatternDataSet.RateProtyMngPattern.MasterNmColumn.ColumnName) // DEL 2010/09/25
                        else if (columnKey == this._rateProtyMngPatternDataSet.RateProtyMngPattern.GoodsRateGrpCodeColumn.ColumnName) // ADD 2010/09/25
                        {
                            // �艿UP��
                            columnIndex = this.Detail_uGrid.Rows[rowIndex].Cells[this._rateProtyMngPatternDataSet.RateProtyMngPattern.UpRateColumn.ColumnName].Column.Index;
                        }
                        // ---ADD 2010/09/09----------------------<<<
                    }
                    break;
                    #endregion Tab
                case 1:
                    #region Shift + Tab
                    // �����ꍇ
                    if (this._rateProtyMng.UnitPriceKind == 1)
                    {
                        // ---UPD 2010/09/09---------------------->>>
                        // ������
                        //if (columnKey == this._rateProtyMngPatternDataSet.RateProtyMngPattern.RateValColumn.ColumnName)
                        //{
                        //    columnIndex = -1;
                        //}
                        // ���[�J�[�R�[�h
                        //if (columnKey == this._rateProtyMngPatternDataSet.RateProtyMngPattern.MasterNmColumn.ColumnName) // DEL 2010/09/25
                        if (columnKey == this._rateProtyMngPatternDataSet.RateProtyMngPattern.GoodsRateGrpCodeColumn.ColumnName) // ADD 2010/09/25
                        {
                            columnIndex = -1;
                        }
                        // ������
                        else if (columnKey == this._rateProtyMngPatternDataSet.RateProtyMngPattern.RateValColumn.ColumnName)
                        {
                            // ���[�J�[�R�[�h
                            //columnIndex = this.Detail_uGrid.Rows[rowIndex].Cells[this._rateProtyMngPatternDataSet.RateProtyMngPattern.MasterNmColumn.ColumnName].Column.Index; // DEL 2010/09/25
                            columnIndex = this.Detail_uGrid.Rows[rowIndex].Cells[this._rateProtyMngPatternDataSet.RateProtyMngPattern.GoodsRateGrpCodeColumn.ColumnName].Column.Index; // ADD 2010/09/25
                        }
                        // ---UPD 2010/09/09----------------------<<<
                        // ����UP��
                        else if (columnKey == this._rateProtyMngPatternDataSet.RateProtyMngPattern.UpRateColumn.ColumnName)
                        {
                            // ������
                            columnIndex = this.Detail_uGrid.Rows[rowIndex].Cells[this._rateProtyMngPatternDataSet.RateProtyMngPattern.RateValColumn.ColumnName].Column.Index;
                        }
                        // �e���m�ۗ�
                        else if (columnKey == this._rateProtyMngPatternDataSet.RateProtyMngPattern.GrsProfitSecureRateColumn.ColumnName)
                        {
                            // ����UP��
                            columnIndex = this.Detail_uGrid.Rows[rowIndex].Cells[this._rateProtyMngPatternDataSet.RateProtyMngPattern.UpRateColumn.ColumnName].Column.Index;
                        }
                    }
                    // �����ꍇ
                    else if (this._rateProtyMng.UnitPriceKind == 2)
                    {
                        // ---UPD 2010/09/09---------------------->>>
                        // �d����
                        //if (columnKey == this._rateProtyMngPatternDataSet.RateProtyMngPattern.RateValColumn.ColumnName)
                        //{
                        //    columnIndex = -1;
                        //}
                        // ���[�J�[�R�[�h
                        //if (columnKey == this._rateProtyMngPatternDataSet.RateProtyMngPattern.MasterNmColumn.ColumnName) // DEL 2010/09/25
                        if (columnKey == this._rateProtyMngPatternDataSet.RateProtyMngPattern.GoodsRateGrpCodeColumn.ColumnName) // ADD 2010/09/25
                        {
                            columnIndex = -1;
                        }
                        // �d����
                        else if (columnKey == this._rateProtyMngPatternDataSet.RateProtyMngPattern.RateValColumn.ColumnName)
                        {
                            // ���[�J�[�R�[�h
                            //columnIndex = this.Detail_uGrid.Rows[rowIndex].Cells[this._rateProtyMngPatternDataSet.RateProtyMngPattern.MasterNmColumn.ColumnName].Column.Index; // DEL 2010/09/25
                            columnIndex = this.Detail_uGrid.Rows[rowIndex].Cells[this._rateProtyMngPatternDataSet.RateProtyMngPattern.GoodsRateGrpCodeColumn.ColumnName].Column.Index; // ADD 2010/09/25
                        }
                        // ---UPD 2010/09/09----------------------<<<
                    }
                    // ���i�ꍇ
                    else if (this._rateProtyMng.UnitPriceKind == 3)
                    {
                        // ---UPD 2010/09/09---------------------->>>
                        //// �艿UP��
                        //if (columnKey == this._rateProtyMngPatternDataSet.RateProtyMngPattern.UpRateColumn.ColumnName)
                        //{
                        //    columnIndex = -1;
                        //}
                        // ���[�J�[�R�[�h
                        //if (columnKey == this._rateProtyMngPatternDataSet.RateProtyMngPattern.MasterNmColumn.ColumnName) // DEL 2010/09/25
                        if (columnKey == this._rateProtyMngPatternDataSet.RateProtyMngPattern.GoodsRateGrpCodeColumn.ColumnName) // ADD 2010/09/25
                        {
                            columnIndex = -1;
                        }
                        // �艿UP��
                        else if (columnKey == this._rateProtyMngPatternDataSet.RateProtyMngPattern.UpRateColumn.ColumnName)
                        {
                            // ���[�J�[�R�[�h
                            //columnIndex = this.Detail_uGrid.Rows[rowIndex].Cells[this._rateProtyMngPatternDataSet.RateProtyMngPattern.MasterNmColumn.ColumnName].Column.Index; // DEL 2010/09/25
                            columnIndex = this.Detail_uGrid.Rows[rowIndex].Cells[this._rateProtyMngPatternDataSet.RateProtyMngPattern.GoodsRateGrpCodeColumn.ColumnName].Column.Index; // ADD 2010/09/25
                        }
                        // ---UPD 2010/09/09----------------------<<<
                        // �[�������P��
                        else if (columnKey == this._rateProtyMngPatternDataSet.RateProtyMngPattern.UnPrcFracProcUnitColumn.ColumnName)
                        {
                            // �艿UP��
                            columnIndex = this.Detail_uGrid.Rows[rowIndex].Cells[this._rateProtyMngPatternDataSet.RateProtyMngPattern.UpRateColumn.ColumnName].Column.Index;
                        }
                        // �[�������敪
                        else if (columnKey == this._rateProtyMngPatternDataSet.RateProtyMngPattern.UnPrcFracProcDivNmColumn.ColumnName)
                        {
                            // �[�������P��
                            columnIndex = this.Detail_uGrid.Rows[rowIndex].Cells[this._rateProtyMngPatternDataSet.RateProtyMngPattern.UnPrcFracProcUnitColumn.ColumnName].Column.Index;
                        }
                    }
                    break;
                    #endregion Shift + Tab
            }

            return columnIndex;
        }
        #endregion �^�u�ړ�

        /// <summary>
        /// ���Ӑ於�̎擾����
        /// </summary>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <param name="customerName">���Ӑ於��</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note        : ���Ӑ於�̂��擾���܂��B</br>
        /// <br>Programmer  : ����</br>
        /// <br>Date        : 2010/08/19</br>
        /// </remarks>
        private bool GetCustomerName(int customerCode, out string customerName)
        {
            customerName = "";
            bool check = false;

            try
            {
                CustomerInfo customerInfo;

                int status = this._customerInfoAcs.ReadDBData(this._enterpriseCode, customerCode, out customerInfo);
                if (status == 0)
                {
                    customerName = customerInfo.CustomerSnm.Trim();
                    check = true;
                }
            }
            catch
            {
                customerName = "";
            }

            return check;

        }

        /// <summary>
        /// �d���於�̎擾����
        /// </summary>
        /// <param name="supplierCode">�d����R�[�h</param>
        /// <param name="supplierName">�d���於��</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note        : �d���於�̂��擾���܂��B</br>
        /// <br>Programmer  : ����</br>
        /// <br>Date        : 2010/08/19</br>
        /// <br>Update Note : 2010/09/09 hanby</br>
        /// <br>            : Redmine#14492�Ή�</br>
        /// </remarks>
        private bool GetSupplierName(int supplierCode, out string supplierName)
        {
            supplierName = "";
            bool check = false;

            // ----------UPD 2010/09/09----------->>>>>
            //try
            //{
            //    if (this._supplierDic == null)
            //    {
            //        // �d����}�X�^�Ǎ�����
            //        LoadSupplier();
            //    }

            //    if (this._supplierDic.ContainsKey(supplierCode))
            //    {
            //        supplierName = this._supplierDic[supplierCode].SupplierSnm.Trim();
            //        check = true;
            //    }
            //}
            //catch
            //{
            //    supplierName = "";
            //}

            Supplier supplier;
            int status = this._supplierAcs.Read(out supplier, this._enterpriseCode, supplierCode);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && supplier != null && supplier.LogicalDeleteCode == 0)
            {
                supplierName = supplier.SupplierSnm;
                check = true;
            }
            // ----------UPD 2010/09/09-----------<<<<<

            return check;
        }

        /// <summary>
        /// ��ʐV�K����
        /// </summary>
        /// <remarks>
        /// <br>Note        : ��ʐV�K�������܂��B</br>
        /// <br>Programmer  : ����</br>
        /// <br>Date        : 2010/08/19</br>
        /// </remarks>
        /// <returns></returns>
        private bool SaveProc()
        {
            bool saveFlg = true;
            int status = 0;
            // �Z���ҏW��ɒ��ڃ{�^���N���b�N���s�Ȃ��ƃZ���̕ҏW���������Ȃ�����
            if (this.Detail_uGrid.ActiveCell != null)
            {
                this.Detail_uGrid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode);
            }


            // �ۑ��O�`�F�b�N
            saveFlg = this.CheckSaveData();

            if (!saveFlg)
            {
                return saveFlg;
            }

            
            // �ۑ�����
            string retMessage = string.Empty;
            int mode = 0;
            if (this.Mode_Label.Text == UPDATE_MODE)
            {
                mode = 1;
            }
            status = this._rateProtyMngPatternAcs.WriteRateRelationData(this._rateProtyMng, mode, 0, out retMessage);

            #region < �o�^�㏈�� >
            switch (status)
            {
                #region -- �ʏ�I�� --
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:

                    // �o�^�����_�C�A���O�\��
                    SaveCompletionDialog dialog = new SaveCompletionDialog();
                    dialog.ShowDialog(2);
                    // ��ʂ�����������
                    this.ScreenClear();
                    break;
                case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:

                    // �R�[�h�d��
                    TMsgDisp.Show(
                        this, 									// �e�E�B���h�E�t�H�[��
                        emErrorLevel.ERR_LEVEL_INFO, 			// �G���[���x��
                        CT_PGID,				        		// �A�Z���u���h�c�܂��̓N���X�h�c
                        //"�X�V�f�[�^����܂���B",  	            // �\�����郁�b�Z�[�W // DEL 2010/09/09
                        "�X�V�Ώۂ̃f�[�^�����݂��܂���B",     // ADD 2010/09/09
                        0, 										// �X�e�[�^�X�l
                        MessageBoxButtons.OK);					// �\������{�^��
                    saveFlg = false;
                    this._checkEmptyFlg = true; // ADD 2010/09/09
                    break;
                // �d���G���[
                case (int)ConstantManagement.DB_Status.ctDB_DUPLICATE:
                    // �R�[�h�d��
                    TMsgDisp.Show(
                        this, 									// �e�E�B���h�E�t�H�[��
                        emErrorLevel.ERR_LEVEL_INFO, 			// �G���[���x��
                        CT_PGID,				        		// �A�Z���u���h�c�܂��̓N���X�h�c
                        "���̃R�[�h�͊��Ɏg�p����Ă��܂��B",  	// �\�����郁�b�Z�[�W
                        0, 										// �X�e�[�^�X�l
                        MessageBoxButtons.OK);					// �\������{�^��
                    saveFlg = false;
                    break;
                #endregion

                #region -- �r������ --
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    ExclusiveTransaction(status, true);
                    saveFlg = false;
                    break;
                #endregion

                #region -- �o�^���s --
                default:
                    TMsgDisp.Show(
                        this,                                 // �e�E�B���h�E�t�H�[��
                        emErrorLevel.ERR_LEVEL_STOP,          // �G���[���x��
                        CT_PGID,                                // �A�Z���u���h�c�܂��̓N���X�h�c
                        CT_PGNM,                                // �v���O��������
                        "SaveProc",                           // ��������
                        TMsgDisp.OPE_UPDATE,                  // �I�y���[�V����
                        "�o�^�Ɏ��s���܂����B",               // �\�����郁�b�Z�[�W
                        status,                               // �X�e�[�^�X�l
                        this._rateProtyMngPatternAcs,         // �G���[�����������I�u�W�F�N�g
                        MessageBoxButtons.OK,                 // �\������{�^��
                        MessageBoxDefaultButton.Button1);     // �����\���{�^��
                    saveFlg = false;
                    break;
                #endregion
            }
            #endregion

            return saveFlg;
        }

        /// <summary>
        /// ���[�J�[���̎擾����
        /// </summary>
        /// <param name="makerCode">���[�J�[�R�[�h</param>
        /// <param name="makerName">���[�J�[����</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note        : ���[�J�[���̂��擾���܂��B</br>
        /// <br>Programmer  : ����</br>
        /// <br>Date        : 2010/08/19</br>
        /// </remarks>
        private bool GetMakerName(int makerCode, out string makerName)
        {
            makerName = "";
            bool check = false;

            try
            {
                if (this._makerUMntDic == null)
                {
                    LoadMakerUMnt();
                }

                if (this._makerUMntDic.ContainsKey(makerCode))
                {
                    makerName = this._makerUMntDic[makerCode].MakerName.Trim();
                    check = true;
                }
            }
            catch
            {
                makerName = "";
            }

            return check;
        }

        /// <summary>
        /// �d����}�X�^�Ǎ�����
        /// </summary>
        /// <remarks>
        /// <br>Note        : �d����}�X�^�Ǎ��������s���܂��B</br>
        /// <br>Programmer  : ����</br>
        /// <br>Date        : 2010/08/19</br>
        /// </remarks>
        private void LoadSupplier()
        {
            this._supplierDic = new Dictionary<int, Supplier>();

            try
            {
                ArrayList retList;

                int status = this._supplierAcs.SearchAll(out retList, this._enterpriseCode);
                if (status == 0)
                {
                    foreach (Supplier supplier in retList)
                    {
                        this._supplierDic.Add(supplier.SupplierCd, supplier);
                    }
                }
            }
            catch
            {
                this._supplierDic = new Dictionary<int, Supplier>();
            }
        }

        /// <summary>
        /// ���[�J�[�}�X�^�Ǎ�����
        /// </summary>
        /// <remarks>
        /// <br>Note        : ���[�J�[�}�X�^�Ǎ��������s���܂��B</br>
        /// <br>Programmer  : ����</br>
        /// <br>Date        : 2010/08/19</br>
        /// </remarks>
        private void LoadMakerUMnt()
        {
            this._makerUMntDic = new Dictionary<int, MakerUMnt>();

            try
            {
                ArrayList retList;

                int status = this._makerAcs.SearchAll(out retList, this._enterpriseCode);
                if (status == 0)
                {
                    foreach (MakerUMnt makerUMnt in retList)
                    {
                        this._makerUMntDic.Add(makerUMnt.GoodsMakerCd, makerUMnt);
                    }
                }
            }
            catch
            {
                this._makerUMntDic = new Dictionary<int, MakerUMnt>();
            }
        }

        /// <summary>
		/// ��ʕ���O�̃`�F�b�N
		/// </summary>
        /// <remarks>
        /// <br>Note        : ��ʕ���O�̃`�F�b�N�������܂��B</br>
        /// <br>Programmer  : ����</br>
        /// <br>Date        : 2010/08/19</br>
        /// </remarks>
        /// <returns></returns>
        private bool CloseCheck()
        {
            bool inputStatus = true;
            // �Z���ҏW��ɒ��ڃ{�^���N���b�N���s�Ȃ��ƃZ���̕ҏW���������Ȃ�����
            if (this.Detail_uGrid.ActiveCell != null)
            {
                this.Detail_uGrid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode);
            }
            // �O���b�h�f�[�^����܂���
            if (this.Detail_uGrid.Rows.Count > 0)
            {
                foreach (UltraGridRow ultraRow in this.Detail_uGrid.Rows) {
                    if ((int)ultraRow.Cells[this._rateProtyMngPatternDataSet.RateProtyMngPattern.SaveFlgColumn.ColumnName].Value == 1)
                    {
                        inputStatus = false;
                        break;
                    }
                }
            }
            return inputStatus;
        }

        ///// <summary>
        ///// ���l���̓`�F�b�N����
        ///// </summary>
        ///// <param name="keta">����(�}�C�i�X�������܂܂�)</param>
        ///// <param name="priod">�����_�ȉ�����</param>
        ///// <param name="prevVal">���݂̕�����</param>
        ///// <param name="key">���͂��ꂽ�L�[�l</param>
        ///// <param name="selstart">�J�[�\���ʒu</param>
        ///// <param name="sellength">�I�𕶎���</param>
        ///// <param name="minusFlg">�}�C�i�X���͉H</param>
        ///// <returns>true=���͉�,false=���͕s��</returns>
        ///// <remarks>
        ///// <br>Note        : ���l�̓��̓`�F�b�N���s���܂��B</br>
        ///// <br>Programmer  : ����</br>
        ///// <br>Date        : 2010/08/19</br>
        ///// </remarks>
        //private bool KeyPressNumCheck(int keta, int priod, string prevVal, char key, int selstart, int sellength, Boolean minusFlg)
        //{
        //    // ����L�[�������ꂽ�H
        //    if (Char.IsControl(key))
        //    {
        //        return true;
        //    }
        //    // ���l�ȊO�́A�m�f
        //    if (!Char.IsDigit(key))
        //    {
        //        // �����_�܂��́A�}�C�i�X�ȊO
        //        if ((key != '.') && (key != '-'))
        //        {
        //            return false;
        //        }
        //    }

        //    // �L�[�������ꂽ�Ɖ��肵���ꍇ�̕�����𐶐�����B
        //    string strResult = "";
        //    if (sellength > 0)
        //    {
        //        strResult = prevVal.Substring(0, selstart) + prevVal.Substring(selstart + sellength, prevVal.Length - (selstart + sellength));
        //    }
        //    else
        //    {
        //        strResult = prevVal;
        //    }

        //    // �}�C�i�X�̃`�F�b�N
        //    if (key == '-')
        //    {
        //        if ((minusFlg == false) || (selstart > 0) || (strResult.IndexOf('-') != -1))
        //        {
        //            return false;
        //        }
        //    }

        //    // �����_�̃`�F�b�N
        //    if (key == '.')
        //    {
        //        if ((priod <= 0) || (strResult.IndexOf('.') != -1))
        //        {
        //            return false;
        //        }
        //    }
        //    // �L�[�������ꂽ���ʂ̕�����𐶐�����B
        //    strResult = prevVal.Substring(0, selstart)
        //        + key
        //        + prevVal.Substring(selstart + sellength, prevVal.Length - (selstart + sellength));

        //    // �����`�F�b�N�I
        //    if (strResult.Length > keta)
        //    {
        //        if (strResult[0] == '-')
        //        {
        //            if (strResult.Length > (keta + 1))
        //            {
        //                return false;
        //            }
        //        }
        //        else
        //        {
        //            return false;
        //        }
        //    }

        //    // �����_�ȉ��̃`�F�b�N
        //    if (priod > 0)
        //    {
        //        // �����_�̈ʒu����
        //        int _pointPos = strResult.IndexOf('.');

        //        // �������ɓ��͉\�Ȍ���������I
        //        int _Rketa = (strResult[0] == '-') ? keta - priod : keta - priod - 1;
        //        // �������̌������`�F�b�N
        //        if (_pointPos != -1)
        //        {
        //            if (_pointPos > _Rketa)
        //            {
        //                return false;
        //            }
        //        }
        //        else
        //        {
        //            if (strResult.Length > _Rketa)
        //            {
        //                return false;
        //            }
        //        }

        //        // �������̌������`�F�b�N
        //        if (_pointPos != -1)
        //        {
        //            // �������̌������v�Z
        //            int _priketa = strResult.Length - _pointPos - 1;
        //            if (priod < _priketa)
        //            {
        //                return false;
        //            }
        //        }
        //    }
        //    return true;
        //}

        /// <summary>
        /// ���o�����ɂ���āA�|���}�X�^�̓ǂݍ��ݏ���
        /// </summary>
        /// <remarks>
        /// <br>Note        : ���o�����ɂ���āA�|���}�X�^�̓ǂݍ��݂��s���܂��B</br>
        /// <br>Programmer  : ����</br>
        /// <br>Date        : 2010/08/19</br>
        /// <br>Update Note : 2010/09/09 hanby</br>
        /// <br>            : Redmine#14492�Ή�</br>
        /// </remarks>
        /// <returns></returns>
        //private void SearchRateData() // DEL 2010/09/25
        private int SearchRateData() // ADD 2010/09/25
        {
            // �I�t���C����ԃ`�F�b�N
            if (!CheckOnline())
            {
                TMsgDisp.Show(
                    emErrorLevel.ERR_LEVEL_STOP,
                    this.Text,
                    this.Text + "��ʌ��������Ɏ��s���܂����B",
                    (int)ConstantManagement.DB_Status.ctDB_OFFLINE, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                //return; // DEL 2010/09/25
                return -1; // ADD 2010/09/25
            }

            // ���͓��e���`�F�b�N����
            if (!this.CheckInputScreen())
            {
                //return; // DEL 2010/09/25
                return -1; // ADD 2010/09/25
            }
            int status = 0;

            // --- DEL 2010/09/09 ---------->>>>>
            //#region ���o�����擾��Compare
            //if (CompareScreenData() && this.Detail_uGrid.Rows.Count > 0)
            //{
            //    this.Detail_uGrid.Focus();
            //    this.Detail_uGrid.ActiveRow = this.Detail_uGrid.Rows[0];
            //    this.InitGridFocus(0, 0);
            //    return;
            //}
            // --- DEL 2010/09/09 ----------<<<<<
            this.ScreenToRateProtyMngPattern(ref this._rateProtyMngPatternWorkClone);
            //#endregion ���o�����擾��Compare// DEL 2010/09/09

            this._rateProtyMngPatternDataSet.RateProtyMngPattern.Rows.Clear();

            // �|���}�X�^���ݓǂ�
            ArrayList goodsList = new ArrayList();
            ArrayList rateList = new ArrayList();
            string errMess = string.Empty;
            status = this._rateProtyMngPatternAcs.SearchRateRelationData(this._rateProtyMngPatternWorkClone, out goodsList, out rateList, 4, out errMess);

            #region ��������
            if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL))
            {
                if (rateList.Count > 0)
                {
                    // --- UPD 2010/09/09 ---------->>>>>
                //    DialogResult dr = TMsgDisp.Show(
                //                emErrorLevel.ERR_LEVEL_QUESTION,
                //                CT_PGID,
                //                "���݁A�o�^�ς̃f�[�^�����݂��܂�\n\n" + "�X�V���Ă��悢�ł����H",
                //                0,
                //                MessageBoxButtons.YesNo);
                //    switch (dr)
                //    {
                //        //"������(N)"�����������ꍇ�A�V�K���[�h�Ƃ��āA�a�k�R�[�h�}�X�^���R�[�h�A���̂�\��
                //        case DialogResult.No:
                //            this.Mode_Label.Text = INSERT_MODE;
                //            this._rateProtyMngPatternAcs.CopyToRateRelationDataSet(goodsList);
                //            break;
                //        //"�͂�(Y)"�����������ꍇ�A�X�V���[�h�Ƃ��ēo�^���f�[�^��\��
                //        case DialogResult.Yes:
                //            this.Mode_Label.Text = UPDATE_MODE;
                //            this._rateProtyMngPatternAcs.CopyToRateRelationDataSet(rateList);
                //            break;
                    //    }
                    // --- UPD 2010/09/09 ----------<<<<<
                    this.Mode_Label.Text = UPDATE_MODE;
                    this._rateProtyMngPatternAcs.CopyToRateRelationDataSet(rateList);
                    // --- ADD 2010/09/09 ---------->>>>>
                    foreach (RateProtyMngPatternDataSet.RateProtyMngPatternRow row in this._rateProtyMngPatternDataSet.RateProtyMngPattern.Rows)
                    {
                        if ("".Equals(row.MasterNm))
                        {
                            break;
                        }
                        row.MasterNm = row.MasterNm.Substring(5, row.MasterNm.Length - 5);
                    }
                    for (int i = 0; i < rateList.Count; i++)
                    {
                        if (((RateRlationWork)rateList[i]).UpdateLineFlg)
                        {
                            //this.Detail_uGrid.Rows[i].Cells[this._rateProtyMngPatternDataSet.RateProtyMngPattern.MasterNmColumn.ColumnName].Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit; // DEL 2010/09/25
                            this.Detail_uGrid.Rows[i].Cells[this._rateProtyMngPatternDataSet.RateProtyMngPattern.GoodsRateGrpCodeColumn.ColumnName].Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit; // ADD 2010/09/25
                        }
                    }
                    // --- ADD 2010/09/09 ----------<<<<<

                }
                else
                {
                    this.Mode_Label.Text = INSERT_MODE;
                    this._rateProtyMngPatternAcs.CopyToRateRelationDataSet(goodsList);
                }
                this.Detail_uGrid.Focus();
                this.Detail_uGrid.ActiveRow = this.Detail_uGrid.Rows[0];
                this.InitGridFocus(0, 0);
                this._initFocusFlag = true; // ADD 2010/09/09
                this.tToolbarsManager_MainMenu.Tools["ButtonTool_Guide"].SharedProps.Enabled = true;// ADD 2010/09/09
            }
            else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
            {
                TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_EXCLAMATION,
                            this.Name,
                            "�Y���f�[�^�����݂��܂���B",
                            0,
                            MessageBoxButtons.OK);
            }
            else
            {
                // �G���[��
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_STOP,
                    this.Name,
                    errMess,
                    status,
                    MessageBoxButtons.OK);
            }
            return status; // ADD 2010/09/25
            #endregion ��������
        }

        /// <summary>
		/// ��ʓ��̓`�F�b�N
		/// </summary>
        /// <remarks>
        /// <br>Note        : ��ʓ��̓`�F�b�N�������܂��B</br>
        /// <br>Programmer  : ����</br>
        /// <br>Date        : 2010/08/19</br>
        /// </remarks>
        /// <returns></returns>
        private bool CheckInputScreen()
        {
            bool checkStatus = true;

            // ���Ӑ�
            if (this.tNedit_CustomerCode.Enabled && this.tNedit_CustomerCode.GetInt() == 0)
            {
                TMsgDisp.Show(
                this,
                emErrorLevel.ERR_LEVEL_EXCLAMATION,
                this.Name,
                "���Ӑ����͂��ĉ������B",
                0,
                MessageBoxButtons.OK);
                this.tNedit_CustomerCode.Focus();
                checkStatus = false;
                this._checkInputScreenErr = true; // ADD 2010/09/09
                // --- ADD 2010/09/09 ---------->>>>>
                this._checkScreanInput = checkStatus;
                // --- ADD 2010/09/09 ----------<<<<<
                return checkStatus;
            }

            // ���Ӑ�|����ٰ��
            if (this.tNedit_CustRateGrpCodeZero.Enabled && this.tNedit_CustRateGrpCodeZero.DataText.Trim() == "")
            {
                TMsgDisp.Show(
                this,
                emErrorLevel.ERR_LEVEL_EXCLAMATION,
                this.Name,
                "���Ӑ�|����ٰ�߂���͂��ĉ������B",
                0,
                MessageBoxButtons.OK);
                this.tNedit_CustRateGrpCodeZero.Focus();
                checkStatus = false;
                this._checkInputScreenErr = true; // ADD 2010/09/09
                return checkStatus;
            }

            // �d����
            if (this.tNedit_SupplierCd.Enabled && this.tNedit_SupplierCd.GetInt() == 0)
            {
                TMsgDisp.Show(
                this,
                emErrorLevel.ERR_LEVEL_EXCLAMATION,
                this.Name,
                "�d�������͂��ĉ������B",
                0,
                MessageBoxButtons.OK);
                this.tNedit_SupplierCd.Focus();
                checkStatus = false;
                this._checkInputScreenErr = true; // ADD 2010/09/09
                return checkStatus;
            }

            // ���[�J�[
            if (this.tNedit_GoodsMakerCd.Enabled && this.tNedit_GoodsMakerCd.GetInt() == 0)
            {
                TMsgDisp.Show(
                this,
                emErrorLevel.ERR_LEVEL_EXCLAMATION,
                this.Name,
                "���[�J�[����͂��ĉ������B",
                0,
                MessageBoxButtons.OK);
                this.tNedit_GoodsMakerCd.Focus();
                checkStatus = false;
                this._checkInputScreenErr = true; // ADD 2010/09/09
                return checkStatus;
            }

            return checkStatus;
        }

        /// <summary>
        /// ��ʒ��o�������f�[�^�`�F�b�N
        /// </summary>
        /// <remarks>
        /// <br>Note        : ��ʒ��o�������f�[�^�`�F�b�N�������܂��B</br>
        /// <br>Programmer  : ����</br>
        /// <br>Date        : 2010/08/19</br>
        /// </remarks>
        /// <returns></returns>
        private bool CompareScreenData()
        {
            return ((this.tNedit_CustomerCode.GetInt() == this._rateProtyMngPatternWorkClone.CustomerCode)
                 && (this.tNedit_CustRateGrpCodeZero.GetInt() == this._rateProtyMngPatternWorkClone.CustRateGrpCode)
                 && (this.tNedit_SupplierCd.GetInt() == this._rateProtyMngPatternWorkClone.SupplierCd)
                 && (this.tNedit_GoodsMakerCd.GetInt() == this._rateProtyMngPatternWorkClone.GoodsMakerCd));
        }

        /// <summary>
        /// �r������
        /// </summary>
        /// <param name="status">STATUS</param>
        /// <param name="hide">��\���t���O(true: ��\���ɂ���, false: ��\���ɂ��Ȃ�)</param>
        /// <remarks>
        /// <br>Note        : ��ʂ�r���������܂��B</br>
        /// <br>Programmer  : ����</br>
        /// <br>Date        : 2010/08/19</br>
        /// </remarks>
        private void ExclusiveTransaction(int status, bool hide)
        {
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    {
                        // ���[���X�V
                        TMsgDisp.Show(
                            this, 								// �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_EXCLAMATION, // �G���[���x��
                            CT_PGID, 						        // �A�Z���u���h�c�܂��̓N���X�h�c
                            "���ɑ��[�����X�V����Ă��܂��B", // �\�����郁�b�Z�[�W
                            0, 									// �X�e�[�^�X�l
                            MessageBoxButtons.OK);				// �\������{�^��
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        // ���[���폜
                        TMsgDisp.Show(
                            this, 								// �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_EXCLAMATION, // �G���[���x��
                            CT_PGID, 						        // �A�Z���u���h�c�܂��̓N���X�h�c
                            "���ɑ��[�����폜����Ă��܂��B", // �\�����郁�b�Z�[�W
                            0, 									// �X�e�[�^�X�l
                            MessageBoxButtons.OK);				// �\������{�^��
                        break;
                    }
            }
        }

        /// <summary>
        /// �ۑ��O�`�F�b�N
        /// </summary>
        /// <returns>�t���O</returns>
        /// <remarks>
        /// <br>Note        : �ۑ��O�`�F�b�N�������s���܂��B</br>
        /// <br>Programmer  : ����</br>
        /// <br>Date        : 2010/08/19</br>
        /// <br>Update Note : 2010/08/31 ������</br>
        /// <br>            : Redmine#14030�Ή�</br>
        /// <br>Update Note : 2010/09/09 hanby</br>
        /// <br>            : Redmine#14492�Ή�</br>
        /// </remarks>
        private bool CheckSaveData()
        {
            if (this._rateProtyMngPatternDataSet.RateProtyMngPattern.Count == 0)
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    "�ۑ��Ώۃf�[�^�����݂��܂���B",
                    -1,
                    MessageBoxButtons.OK);

                return false;
            }

            // --------ADD 2010/08/31-------->>>>>
            // ���i�ݒ�ꍇ
            if (this._rateProtyMng.UnitPriceKind == 3)
            {
                foreach (UltraGridRow ultraRow in this.Detail_uGrid.Rows)
                {
                    bool checkFlg = true;
                    string rowIndexName = string.Empty;
                    // ���[�U�[�艿�������͉��iUP�������͂��ꂽ���ׂɑ΂���
                    if ((double)ultraRow.Cells[this._rateProtyMngPatternDataSet.RateProtyMngPattern.PriceFlColumn.ColumnName].Value != 0 ||
                        (double)ultraRow.Cells[this._rateProtyMngPatternDataSet.RateProtyMngPattern.UpRateColumn.ColumnName].Value != 0)
                    {
                        // �[�������P�ʋy�ђ[�������敪�͕K�{���̓`�F�b�N
                        if ((double)ultraRow.Cells[this._rateProtyMngPatternDataSet.RateProtyMngPattern.UnPrcFracProcUnitColumn.ColumnName].Value == 0)
                        {
                            checkFlg = false;
                            rowIndexName = "UnPrcFracProcUnit";
                        }
                        else if ((string)ultraRow.Cells[this._rateProtyMngPatternDataSet.RateProtyMngPattern.UnPrcFracProcDivNmColumn.ColumnName].Value == string.Empty)
                        {
                            checkFlg = false;
                            rowIndexName = "UnPrcFracProcDivNm";
                        }
                    }
                    if (checkFlg == false)
                    {
                        TMsgDisp.Show(
                           this,
                           emErrorLevel.ERR_LEVEL_EXCLAMATION,
                           this.Name,
                           "�����͂̍��ڂ����݂��邽�߁A�o�^�ł��܂���B",
                           -1,
                           MessageBoxButtons.OK);
                        ultraRow.Cells[rowIndexName].Activate();
                        this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                        return false;
                    }
                }
            }
            // --------ADD 2010/08/31--------<<<<<
            // --------ADD 2010/09/09-------->>>>>
            // ���ׂ����͍ς݂Ŋ��A�����͍��ڂ��L��ꍇ�A�G���[�Ƃ���B
            if (!CheckAllZero())
            {
                return false;
            }

            // ���ׂ����͍ς݂Ŋ��A����R�[�h�����݂���ꍇ�A�G���[�Ƃ���B
            if (!CheckEqual())
            {
                return false;
            }

            // ���ׂ��S�Ė����͂̏ꍇ�A�G���[�Ƃ���B
            if (!CheckEmpty())
            {
                return false;
            }
            // --------ADD 2010/09/09--------<<<<<
            return true;
        }

        /// <summary>
        /// �s�폜����
        /// </summary>
        /// <remarks>
        /// <br>Note        : �s�폜�������s���܂��B</br>
        /// <br>Programmer  : ����</br>
        /// <br>Date        : 2010/08/19</br>
        /// <br>Update Note : 2010/09/09 hanby</br>
        /// <br>            : Redmine#14492�Ή�</br>
        /// <br>Update Note : 2010/09/30</br>
        /// <br>            : Redmine#15703�Ή�</br>
        /// </remarks>
        private void RowDelete()
        {
            int rowIndex = this.GetActiveRowIndex();

            if (rowIndex == -1)
            {
                return;
            }

            try
            {
                this.Cursor = Cursors.WaitCursor;

                this.Detail_uGrid.BeginUpdate();

                if ((Int32)this.Detail_uGrid.ActiveRow.Cells[this._rateProtyMngPatternDataSet.RateProtyMngPattern.LogicalDeleteCodeColumn.ColumnName].Value == 0) // ADD 2010/09/30 �d�l�A�� #15703
                { // ADD 2010/09/30 �d�l�A�� #15703
                    // �s�폜��BackColor�̐ݒ�(�ԐF)
                    foreach (UltraGridCell cell in this.Detail_uGrid.ActiveRow.Cells)
                    {
                        cell.Appearance.BackColor = Color.Red;
                        cell.Appearance.BackColor2 = Color.Red;
                        cell.Appearance.BackColorDisabled = Color.Red;
                        cell.Appearance.BackColorDisabled2 = Color.Red;
                        cell.Appearance.BackGradientStyle = GradientStyle.Vertical;
                    }
                    // �s�폜�t���O
                    this.Detail_uGrid.ActiveRow.Cells[this._rateProtyMngPatternDataSet.RateProtyMngPattern.LogicalDeleteCodeColumn.ColumnName].Value = 1;
                    #region Save�t���O
                    // �V�K�ꍇ�A�s�폜�f�[�^���ΏۊO
                    if (this.Mode_Label.Text == INSERT_MODE)
                    {
                        this.Detail_uGrid.ActiveRow.Cells[this._rateProtyMngPatternDataSet.RateProtyMngPattern.SaveFlgColumn.ColumnName].Value = 0;
                    }
                    // �X�V�ꍇ�A�s�폜�f�[�^���Ώ�
                    else if (this.Mode_Label.Text == UPDATE_MODE)
                    {
                        this.Detail_uGrid.ActiveRow.Cells[this._rateProtyMngPatternDataSet.RateProtyMngPattern.SaveFlgColumn.ColumnName].Value = 1;
                    }
                    #endregion
                // --- ADD 2010/09/30 �d�l�A�� #15703 ---------->>>>>
                }
                else
                {
                    // �s�폜������BackColor�̐ݒ�
                    foreach (UltraGridCell cell in this.Detail_uGrid.ActiveRow.Cells)
                    {
                        cell.Appearance.BackColor = Color.Empty;
                        cell.Appearance.BackColor2 = Color.Empty;
                        cell.Appearance.BackColorDisabled = Color.Empty;
                        cell.Appearance.BackColorDisabled2 = Color.Empty;
                        cell.Appearance.BackGradientStyle = GradientStyle.Vertical;
                    }
                    // �s�폜�t���O
                    this.Detail_uGrid.ActiveRow.Cells[this._rateProtyMngPatternDataSet.RateProtyMngPattern.LogicalDeleteCodeColumn.ColumnName].Value = 0;
                    // �s�폜�����f�[�^���Ώ�
                    this.Detail_uGrid.ActiveRow.Cells[this._rateProtyMngPatternDataSet.RateProtyMngPattern.SaveFlgColumn.ColumnName].Value = 0;
                }
                // --- ADD 2010/09/30 �d�l�A�� #15703 ----------<<<<<
                // �Z��Activation�ݒ�
                //this.SetCellActivation(this.Detail_uGrid.Rows[rowIndex]); // DEL 2010/09/30 �d�l�A�� #15703
                this.Detail_uGrid.EndUpdate();

            }
            finally
            {
                // ---UPD 2010/09/25--------->>>>>
                this.Cursor = Cursors.Default;
                // --- ADD 2010/09/30 �d�l�A�� #15703 ---------->>>>>
                //DataRow[] dr = this._rateProtyMngPatternDataSet.RateProtyMngPattern.Select("LogicalDeleteCode <> 1");
                //if (dr.Length == 0)
                //{
                //    this.Detail_uGrid.PerformAction(UltraGridAction.ExitEditMode);
                //    Delete_Button.Focus();
                //}
                //else
                //{
                //    if (!MoveNextAllowEditCell(false, 1))
                //    {
                //        for (int targetRowIndex = 0; targetRowIndex < this.Detail_uGrid.Rows.Count; targetRowIndex++)
                //        {
                //            if (this.Detail_uGrid.Rows[targetRowIndex].Cells[masterCode].Activation == Activation.AllowEdit)
                //            {
                //                this.Detail_uGrid.Rows[targetRowIndex].Cells[masterCode].Activate();
                //                this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                //                break;
                //            }
                //        }
                //    }

                //    this.Detail_uGrid.PerformAction(UltraGridAction.ExitEditMode);
                //    this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                //}
                // --- ADD 2010/09/30 �d�l�A�� #15703 ----------<<<<<
                // ---UPD 2010/09/25---------<<<<<
            }
        }

        /// <summary>
        /// ActiveRow�C���f�b�N�X�擾����
        /// </summary>
        /// <returns>ActiveRow�C���f�b�N�X</returns>
        /// <remarks>
        /// <br>Note        : ActiveRow�C���f�b�N�X�擾���s���܂��B</br>
        /// <br>Programmer  : ����</br>
        /// <br>Date        : 2010/08/19</br>
        /// </remarks>
        private int GetActiveRowIndex()
        {
            if (this.Detail_uGrid.ActiveCell != null)
            {
                return this.Detail_uGrid.ActiveCell.Row.Index;
            }
            else if (this.Detail_uGrid.ActiveRow != null)
            {
                return this.Detail_uGrid.ActiveRow.Index;
            }
            else
            {
                return -1;
            }
        }

        #region �� �I�t���C����ԃ`�F�b�N����
        /// <summary>
        /// ���O�I�����I�����C����ԃ`�F�b�N����
        /// </summary>
        /// <returns>�`�F�b�N��������</returns>
        /// <remarks>
        /// <br>Note       : ���O�I�����I�����C����ԃ`�F�b�N�������s���B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2010/08/19</br>
        /// </remarks>
        public static bool CheckOnline()
        {
            if (Broadleaf.Application.Common.LoginInfoAcquisition.OnlineFlag == false)
            {
                return false;
            }
            else
            {
                // ���[�J���G���A�ڑ���Ԃɂ��I�����C������				
                if (CheckRemoteOn() == false)
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// �����[�g�ڑ��\����
        /// </summary>
        /// <returns>���茋��</returns>
        /// <remarks>
        /// <br>Note       : �����[�g�ڑ��\������s���B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2010/08/19</br>
        /// </remarks>
        private static bool CheckRemoteOn()
        {
            bool isLocalAreaConnected = NetworkInterface.GetIsNetworkAvailable();

            if (isLocalAreaConnected == false)
            {
                // �C���^�[�l�b�g�ڑ��s�\���
                return false;
            }
            else
            {
                return true;
            }
        }

        #endregion

        /// <summary>
        /// �Z��Activation�ݒ�
        /// </summary>
        /// <remarks>
        /// <br>Note       : �������A�Z���P�ʂ̓��͋��ݒ���s��</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2010/08/19</br>
        /// </remarks>
        private void SetCellActivation(UltraGridRow ultraRow)
        {
            if ((int)ultraRow.Cells[this._rateProtyMngPatternDataSet.RateProtyMngPattern.LogicalDeleteCodeColumn.ColumnName].Value == 1)
            {
                foreach (UltraGridCell ultraCell in ultraRow.Cells)
                {
                    ultraCell.Activation = Activation.Disabled;
                }
            }
        }

        /// <summary>
        /// ��ʏ��f�[�^���i�[����
        /// </summary>
        /// <param name="rateProtyMngPatternWork">���o����</param>
        /// <remarks>
        /// <br>Note        : ��ʏ��f�[�^���i�[���܂��B</br>
        /// <br>Programmer  : ����</br>
        /// <br>Date        : 2010/08/19</br>
        /// </remarks>
        private void ScreenToRateProtyMngPattern(ref RateProtyMngPatternWork rateProtyMngPatternWork)
        {
            rateProtyMngPatternWork.CustomerCode = this.tNedit_CustomerCode.GetInt();
            rateProtyMngPatternWork.CustRateGrpCode = this.tNedit_CustRateGrpCodeZero.GetInt();
            rateProtyMngPatternWork.SupplierCd = this.tNedit_SupplierCd.GetInt();
            rateProtyMngPatternWork.GoodsMakerCd = this.tNedit_GoodsMakerCd.GetInt();
            rateProtyMngPatternWork.SectionCode = this._rateProtyMng.SectionCode.Trim();
            rateProtyMngPatternWork.UnitPriceKind = this._rateProtyMng.UnitPriceKind.ToString();
            rateProtyMngPatternWork.RateSettingDivide = this._rateProtyMng.RateSettingDivide.Trim();
            rateProtyMngPatternWork.EnterpriseCode = this._enterpriseCode;
        }

        // ---ADD 2010/09/09---------------------->>>

        /// <summary>
        /// �K�C�h����
        /// </summary>
        /// <remarks>
        /// <br>Note        : �K�C�h�������s���܂��B</br>
        /// <br>Programmer  : hanby</br>
        /// <br>Date        : 2010/09/09</br>
        /// </remarks>
        private bool ExcuteGuide()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                int status;
                GoodsGroupU goodsGroupU = new GoodsGroupU();

                // ---ADD 2010/09/25---------------------->>>
                this._gridGuideFlg = true;
                if (this.Detail_uGrid.ActiveCell.Activation == Activation.AllowEdit)
                {
                    this.Detail_uGrid.PerformAction(UltraGridAction.ExitEditMode);
                }
                // ---ADD 2010/09/25----------------------<<<

                // ���i�|���f�K�C�h�\��
                status = this._goodsGroupUAcs.ExecuteGuid(this._enterpriseCode, out goodsGroupU, false);
                if (status == 0)
                {
                    // ���[�J�[�R�[�h + ���[�J�[����
                    this.Detail_uGrid.BeginUpdate();
                    this.Detail_uGrid.ActiveCell.Activation = Activation.NoEdit;
                    this._guidFlg = true;
                    this._guidCd = goodsGroupU.GoodsMGroup;
                    //this.Detail_uGrid.ActiveCell.Value = goodsGroupU.GoodsMGroupName.Trim(); // DEL 2010/09/25
                    this.Detail_uGrid.Rows[this.Detail_uGrid.ActiveCell.Row.Index].Cells["MasterNm"].Value = goodsGroupU.GoodsMGroupName.Trim(); // ADD 2010/09/25
                    this.Detail_uGrid.Rows[this.Detail_uGrid.ActiveCell.Row.Index].Cells[masterCode].Value = goodsGroupU.GoodsMGroup.ToString("D4"); // ADD 2010/09/25
                    this._prevGoodsRateGrpCode = goodsGroupU.GoodsMGroup;
                    this.Detail_uGrid.EndUpdate();
                    return true;
                }
                else
                {
                    this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode); // ADD 2010/09/25
                    this.Detail_uGrid.ActiveCell.SelectAll();
                    return false;
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
        /// <summary>
        /// ���[�J�[�}�X�^�`�F�b�N����
        /// </summary>
        /// <remarks>
        /// <br>Note        : ���͂��ꂽ���[�J�[�����[�J�[�}�X�^�ɑ��݂��邩�̃`�F�b�N���s���܂��B</br>
        /// <br>Programmer  : hanby</br>
        /// <br>Date        : 2010/09/09</br>
        /// </remarks>
        private bool SearchMakerUMnt()
        {
            ArrayList retList;
            bool flag = false;

            int status = this._makerAcs.SearchAll(out retList, this._enterpriseCode);
            if (status == 0)
            {
                string inputValue;
                if (this.Detail_uGrid.ActiveCell.Text.Length < 4)
                {
                    inputValue = this.Detail_uGrid.ActiveCell.Text.PadLeft(4, '0');
                }
                else
                {
                    inputValue = this.Detail_uGrid.ActiveCell.Text.Substring(0, 4);
                }
                foreach (MakerUMnt makerUMnt in retList)
                {
                    if (inputValue.Equals(makerUMnt.GoodsMakerCd.ToString("0000")))
                    {
                        if (makerUMnt.LogicalDeleteCode == 1)
                        {
                            flag = false;
                        }
                        else
                        {
                            flag = true;
                            this._preRowIndex = this.Detail_uGrid.ActiveCell.Row.Index;
                            this._preColumnIndex = this.Detail_uGrid.ActiveCell.Column.Index;
                            this.Detail_uGrid.ActiveCell.Value = makerUMnt.GoodsMakerCd.ToString("0000") + " " + makerUMnt.MakerName.Trim();
                        }
                        break;
                    }
                }
                if (!flag)
                {
                    // �G���[��
                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_INFO,
                        this.Name,
                        "���[�J�[�R�[�h�����݂��܂���B",
                        -1,
                        MessageBoxButtons.OK);
                    return false;
                }
                return true;
            }
            return false;
        }

        /// <summary>
        /// �s�폜�{�^���N���b�N�C�x���g
        /// </summary>
        /// <remarks>
        /// <br>Note        : �s�폜�������s���܂��B</br>
        /// <br>Programmer  : hanby</br>
        /// <br>Date        : 2010/09/09</br>
        /// <br>Update Note : 2010/09/30</br>
        /// <br>            : Redmine#15703�Ή�</br>
        /// </remarks>
        private void Delete_Button_Click(object sender, EventArgs e)
        {
            //this.RowDelete(); // DEL 2010/09/25
            // --------UPD 2010/09/28 -------------<<<<<
            //if (!this.AllDeleteCheck())
            //{
            //    this.Delete_Button.Focus();
            //}
            // ---UPD 2010/09/25---------------------->>>
            // ---ADD 2010/09/10---------------------->>>
            int rowIndex = 0;
            //if (this.Detail_uGrid.ActiveCell != null) // DEL 2010/09/30 �d�l�A�� #15703
            if (this.Detail_uGrid.ActiveRow != null) // ADD 2010/09/30 �d�l�A�� #15703
            {
                //rowIndex = this.Detail_uGrid.ActiveCell.Row.Index; // DEL 2010/09/30 �d�l�A�� #15703
                rowIndex = this.Detail_uGrid.ActiveRow.Index; // ADD 2010/09/30 �d�l�A�� #15703
            }
            else
            {
                if (this.Detail_uGrid.Rows.Count > 0)
                {
                    RowDelete();
                    if (!this.AllDeleteCheck())
                    {
                        this.Delete_Button.Focus();
                    }
                }
                else
                {
                    return;
                }
            }
            // ---ADD 2010/09/10----------------------<<<
            this._deleteButtonFlag = true;// ADD 2010/09/10
            //this.Detail_uGrid.PerformAction(UltraGridAction.ExitEditMode);  // ADD 2010/09/10 // DEL 2010/09/30 �d�l�A�� #15703
            // ---ADD 2010/09/10---------------------->>>
            if (this._errorFlg)
            {
                ((RateProtyMngPatternDataSet.RateProtyMngPatternRow)this._rateProtyMngPatternDataSet.RateProtyMngPattern.Rows[rowIndex]).MasterNm = string.Empty;
                ((RateProtyMngPatternDataSet.RateProtyMngPatternRow)this._rateProtyMngPatternDataSet.RateProtyMngPattern.Rows[rowIndex]).GoodsRateGrpCode = string.Empty; // ADD 2010/09/25
                this._errorFlg = false;
            }
            RowDelete();
            if (!this.AllDeleteCheck())
            {
                this.Delete_Button.Focus();
                return;
            }

            // --- DEL 2010/09/30 �d�l�A�� #15703 ---------->>>>>
            //if (!CatchSelectedRow(rowIndex))
            //{
            //    ChangeFocusEventArgs evt = new ChangeFocusEventArgs(false, false, false, Keys.Tab, this.Detail_uGrid, this.Detail_uGrid);
            //    this.Detail_uGrid.ActiveRow = this.Detail_uGrid.Rows[SelectedRow()];
            //    //this.Detail_uGrid.Rows[SelectedRow()].Cells["MasterNm"].Activate(); // DEL 2010/09/25
            //    this.Detail_uGrid.Rows[SelectedRow()].Cells[masterCode].Activate(); // ADD 2010/09/25
            //    //this.SetGridTabFocus(ref evt);
            //    this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
            //}
            //else
            //{
            //    //this.Detail_uGrid_KeyDown(this.Detail_uGrid, new KeyEventArgs(Keys.Right)); // ADD 2010/09/25
            //}
            // --- DEL 2010/09/30 �d�l�A�� #15703 ----------<<<<<

            // ---ADD 2010/09/10----------------------<<<
            this._deleteButtonFlag = false;// ADD 2010/09/10
            // --------UPD 2010/09/28 ------------->>>>>
        }

        /// <summary>
        /// �S�폜�{�^���N���b�N�C�x���g
        /// </summary>
        /// <remarks>
        /// <br>Note        : �S�폜�������s���܂��B</br>
        /// <br>Programmer  : hanby</br>
        /// <br>Date        : 2010/09/09</br>
        /// </remarks>
        private void DeleteAll_Button_Click(object sender, EventArgs e)
        {
            // --------UPD 2010/09/28 ------------->>>>>
            //this.AllRowDelete();
            int rowIndex = 0;
            if (this.Detail_uGrid.ActiveCell != null)
            {
                rowIndex = this.Detail_uGrid.ActiveCell.Row.Index;
            }
            this._deleteButtonFlag = true;
            this.Detail_uGrid.PerformAction(UltraGridAction.ExitEditMode);
            this._deleteButtonFlag = false;
            if (this.AllDeleteEnabledCheck())
            {
                if (this._errorFlg)
                {
                    ((RateProtyMngPatternDataSet.RateProtyMngPatternRow)this._rateProtyMngPatternDataSet.RateProtyMngPattern.Rows[rowIndex]).MasterNm = string.Empty;
                    ((RateProtyMngPatternDataSet.RateProtyMngPatternRow)this._rateProtyMngPatternDataSet.RateProtyMngPattern.Rows[rowIndex]).GoodsRateGrpCode = string.Empty; // ADD 2010/09/25
                }
                AllRowDelete();

                if (!this._errorFlg)
                {
                    ChangeFocusEventArgs evt = new ChangeFocusEventArgs(false, false, false, Keys.Tab, this.Detail_uGrid, this.Detail_uGrid);
                    this.Detail_uGrid.ActiveRow = this.Detail_uGrid.Rows[SelectedRow()];
                    this.Detail_uGrid.Rows[SelectedRow()].Cells[masterCode].Activate();
                    this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                    return;

                }
                else
                {
                    this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);

                }
                this._errorFlg = false;

                if (!CatchSelectedRow(rowIndex))
                {
                    ChangeFocusEventArgs evt = new ChangeFocusEventArgs(false, false, false, Keys.Tab, this.Detail_uGrid, this.Detail_uGrid);
                    this.Detail_uGrid.Rows[GetGridInitRowNo()].Cells[GetGridInitColumKey()].Activate();
                    this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                }
            }
            else
            {
                this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                return;
            }
            // --------UPD 2010/09/28 -------------<<<<<
        }

        /// <summary>
        /// �S�폜�{�^���N���b�N�C�x���g
        /// </summary>
        /// <remarks>
        /// <br>Note        : �S�폜�������s���܂��B</br>
        /// <br>Programmer  : hanby</br>
        /// <br>Date        : 2010/09/09</br>
        /// <br>Update Note : 2010/09/30</br>
        /// <br>            : Redmine#15703�Ή�</br>
        /// </remarks>
        private void AllRowDelete()
        {
            // �폜�Ώۂ��ǂ����`�F�b�N�p�ϐ�
            // ���[�J�[�R�[�h
            //string goodsMakerCdColumn = this._rateProtyMngPatternDataSet.RateProtyMngPattern.MasterNmColumn.ColumnName; // DEL 2010/09/25
            string goodsMakerCdColumn = this._rateProtyMngPatternDataSet.RateProtyMngPattern.GoodsRateGrpCodeColumn.ColumnName; // ADD 2010/09/25
            // ������
            string rateValColumn = this._rateProtyMngPatternDataSet.RateProtyMngPattern.RateValColumn.ColumnName;
            // ����UP��
            string upRateColumn = this._rateProtyMngPatternDataSet.RateProtyMngPattern.UpRateColumn.ColumnName;
            // �e���m�ۗ�
            string grsProfitSecureRateColumn = this._rateProtyMngPatternDataSet.RateProtyMngPattern.GrsProfitSecureRateColumn.ColumnName;
            // �[�������P��
            string unPrcFracProcUnitColumn = this._rateProtyMngPatternDataSet.RateProtyMngPattern.UnPrcFracProcUnitColumn.ColumnName;
            // �[�������敪
            string unPrcFracProcDivNmColumn = this._rateProtyMngPatternDataSet.RateProtyMngPattern.UnPrcFracProcDivNmColumn.ColumnName;


            if (this.Detail_uGrid.Rows.Count == 0)
            {
                return;
            }

            try
            {
                this.Cursor = Cursors.WaitCursor;

                this.Detail_uGrid.BeginUpdate();
                foreach (UltraGridRow row in this.Detail_uGrid.Rows)
                {
                    // �폜�Ώۂ��ǂ����`�F�b�N
                    if (this._rateProtyMng.UnitPriceKind == 1)
                    {
                        if ((row.Cells[goodsMakerCdColumn].Activation == Activation.AllowEdit) &&
                            (double)row.Cells[rateValColumn].Value == 0 &&
                            (double)row.Cells[upRateColumn].Value == 0 &&
                            (double)row.Cells[grsProfitSecureRateColumn].Value == 0)
                        {
                            continue;
                        }
                    }
                    else if (this._rateProtyMng.UnitPriceKind == 2)
                    {
                        if ((row.Cells[goodsMakerCdColumn].Activation == Activation.AllowEdit) &&
                            (double)row.Cells[rateValColumn].Value == 0)
                        {
                            continue;
                        }
                    }
                    else
                    {
                        if ((row.Cells[goodsMakerCdColumn].Activation == Activation.AllowEdit) &&
                            (double)row.Cells[upRateColumn].Value == 0 &&
                            (double)row.Cells[unPrcFracProcUnitColumn].Value == 1 &&
                            "2".Equals(row.Cells[unPrcFracProcDivNmColumn].Value.ToString()))
                        {
                            continue;
                        }
                    }
                        // �s�폜�t���O
                        row.Cells[this._rateProtyMngPatternDataSet.RateProtyMngPattern.LogicalDeleteCodeColumn.ColumnName].Value = 1;

                        // �S�폜��BackColor�̐ݒ�(�ԐF)
                        foreach (UltraGridCell cell in row.Cells)
                        {
                            cell.Appearance.BackColor = Color.Red;
                            cell.Appearance.BackColor2 = Color.Red;
                            cell.Appearance.BackColorDisabled = Color.Red;
                            cell.Appearance.BackColorDisabled2 = Color.Red;
                            cell.Appearance.BackGradientStyle = GradientStyle.Vertical;
                        }

                        #region Save�t���O
                        // �V�K�ꍇ�A�s�폜�f�[�^���ΏۊO
                        if (this.Mode_Label.Text == INSERT_MODE)
                        {
                            row.Cells[this._rateProtyMngPatternDataSet.RateProtyMngPattern.SaveFlgColumn.ColumnName].Value = 0;
                        }
                        // �X�V�ꍇ�A�s�폜�f�[�^���Ώ�
                        else if (this.Mode_Label.Text == UPDATE_MODE)
                        {
                            row.Cells[this._rateProtyMngPatternDataSet.RateProtyMngPattern.SaveFlgColumn.ColumnName].Value = 1;
                        }
                        #endregion

                    // �Z��Activation�ݒ�
                    //this.SetCellActivation(row); // DEL 2010/09/30 �d�l�A�� #15703
                }
                this.Detail_uGrid.EndUpdate();
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// AfterCellActivate�C�x���g
        /// </summary>
        /// <remarks>
        /// <br>Note        : �Z�����A�N�e�B�u�ɂȂ�����ɔ������܂��B</br>
        /// <br>Programmer  : hanby</br>
        /// <br>Date        : 2010/09/09</br>
        /// </remarks>
        private void Detail_uGrid_AfterCellActivate(object sender, EventArgs e)
        {
            #region ���K�C�h�L�������̐ݒ�
            if (this.Detail_uGrid.ActiveCell != null)
            {
                //if (this.Detail_uGrid.ActiveCell.Column.Key.Equals("MasterNm") && (this.Detail_uGrid.ActiveCell.Activation == Activation.AllowEdit)) // DEL 2010/09/25
                if (this.Detail_uGrid.ActiveCell.Column.Key.Equals(masterCode) && (this.Detail_uGrid.ActiveCell.Activation == Activation.AllowEdit)) // ADD 2010/09/25
                {
                    this.tToolbarsManager_MainMenu.Tools["ButtonTool_Guide"].SharedProps.Enabled = true;
                }
                else
                {
                    this.tToolbarsManager_MainMenu.Tools["ButtonTool_Guide"].SharedProps.Enabled = false;
                }
            }
            else
            {
                this.tToolbarsManager_MainMenu.Tools["ButtonTool_Guide"].SharedProps.Enabled = false;
            }
            #endregion

            if ((this.Detail_uGrid.ActiveCell != null) && this.Detail_uGrid.ActiveCell.Column.Key.Equals("UnPrcFracProcDivNm"))
            {
                this._preUnPrcFracProcDivNmCell = this.Detail_uGrid.ActiveCell;
            }
            #region ���[�������敪�`�F�b�N
            if (this._preUnPrcFracProcDivNmCell != null)
            {
                switch (this._preUnPrcFracProcDivNmCell.Text)
                {
                    case "1":
                    case "1:�؎̂�":
                    case "2":
                    case "2:�l�̌ܓ�":
                    case "3":
                    case "3:�؏グ":
                        break;
                    default:
                        if (!this._preUnPrcFracProcDivNmCell.Disposed)
                        {
                            this._preUnPrcFracProcDivNmCell.Value = 2;
                            this.Detail_uGrid.PerformAction(UltraGridAction.ExitEditMode);
                        }
                        break;
                }
            }
            #endregion

            //#region ���s�폜�{�^���L�������̐ݒ�
            //if (this.Detail_uGrid.ActiveCell != null)
            //{
            //    this.Delete_Button.Enabled = true;
            //}
            //else
            //{
            //    this.Delete_Button.Enabled = false;
            //}
            //#endregion

            //#region ���S�폜�{�^���L�������̐ݒ�
            //if (this.AllDeleteEnabledCheck())
            //{
            //    this.DeleteAll_Button.Enabled = true;
            //}
            //else
            //{
            //    this.DeleteAll_Button.Enabled = false;
            //}
            //#endregion
            #region ���s�폜/�S�폜�{�^���L�������̐ݒ�
            if (this.Detail_uGrid.Rows.Count != 0)
            {
                this.Delete_Button.Enabled = true;
                this.DeleteAll_Button.Enabled = true;
            }
            else
            {
                this.Delete_Button.Enabled = false;
                this.DeleteAll_Button.Enabled = false;
            }
            #endregion
        }

        /// <summary>
        /// �t�H�[�����[�h�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Programmer : hanby</br>
        /// <br>Date       : 2010/09/09</br>
        /// </remarks>
        private void ultraExpandableGroupBox_Condition_ExpandedStateChanging(object sender, CancelEventArgs e)
        {
            Size topSize = new Size();
            Size gridSize = new Size();

            topSize.Width = this.Head_panel_Top.Size.Width;
            gridSize.Width = this.Detail_uGrid.Size.Width;
            topSize.Height = 166;
            gridSize.Height = 410;

            if (this.ultraExpandableGroupBox_Condition.Expanded == false)
            {
                topSize.Height = 166;
                gridSize.Height = 410;
            }
            else
            {
                topSize.Height = 60;
                gridSize.Height = 517;
            }

            this.Head_panel_Top.Size = topSize;
            this.Detail_uGrid.Size = gridSize;
        }

        /// <summary>
        /// ���ׂ����͍ς݂Ŋ��A�����͍��ڂ��L��ꍇ
        /// </summary>
        /// <remarks>
        /// <br>Note        : ���ׂ����͍ς݂Ŋ��A�����͍��ڂ��L��ꍇ</br>
        /// <br>Programmer  :hanby</br>
        /// <br>Date        : 2010/09/09</br>
        /// </remarks>
        private bool CheckAllZero()
        {
            bool checkFlg = true;
            string rowIndexName = string.Empty;
            // ���[�J�[�R�[�h
            //string masterNmColumn = this._rateProtyMngPatternDataSet.RateProtyMngPattern.MasterNmColumn.ColumnName; // DEL 2010/09/25
            string masterNmColumn = this._rateProtyMngPatternDataSet.RateProtyMngPattern.GoodsRateGrpCodeColumn.ColumnName; // ADD 2010/09/25
            // ������
            string rateValColumn = this._rateProtyMngPatternDataSet.RateProtyMngPattern.RateValColumn.ColumnName;
            // ����UP��
            string upRateColumn = this._rateProtyMngPatternDataSet.RateProtyMngPattern.UpRateColumn.ColumnName;
            // �e���m�ۗ�
            string grsProfitSecureRateColumn = this._rateProtyMngPatternDataSet.RateProtyMngPattern.GrsProfitSecureRateColumn.ColumnName;
            // �[�������P��
            string unPrcFracProcUnitColumn = this._rateProtyMngPatternDataSet.RateProtyMngPattern.UnPrcFracProcUnitColumn.ColumnName;
            // �[�������敪
            string unPrcFracProcDivNmColumn = this._rateProtyMngPatternDataSet.RateProtyMngPattern.UnPrcFracProcDivNmColumn.ColumnName;
            // �s�폜�t���O
            string logicalDeleteCodeColumn = this._rateProtyMngPatternDataSet.RateProtyMngPattern.LogicalDeleteCodeColumn.ColumnName;

            if (this._rateProtyMng.UnitPriceKind == 1)
            {
                foreach (UltraGridRow ultraRow in this.Detail_uGrid.Rows)
                {
                    //if (!string.IsNullOrEmpty(ultraRow.Cells[masterNmColumn].Value.ToString()) && (int)ultraRow.Cells[logicalDeleteCodeColumn].Value == 0) // DEL 2010/09/25
                    if (!string.IsNullOrEmpty(ultraRow.Cells[masterNmColumn].Text) && (int)ultraRow.Cells[logicalDeleteCodeColumn].Value == 0) // ADD 2010/09/25
                    {
                        if ((double)ultraRow.Cells[rateValColumn].Value == 0 &&
                            (double)ultraRow.Cells[upRateColumn].Value == 0 &&
                            (double)ultraRow.Cells[grsProfitSecureRateColumn].Value == 0)
                        {
                            rowIndexName = rateValColumn;
                            checkFlg = false;
                        }
                    }
                    //else if (string.IsNullOrEmpty(ultraRow.Cells[masterNmColumn].Value.ToString()) && (int)ultraRow.Cells[logicalDeleteCodeColumn].Value == 0) // DEL 2010/09/25
                    else if (string.IsNullOrEmpty(ultraRow.Cells[masterNmColumn].Text) && (int)ultraRow.Cells[logicalDeleteCodeColumn].Value == 0) // ADD 2010/09/25
                    {
                        if (((double)ultraRow.Cells[rateValColumn].Value != 0) ||
                        ((double)ultraRow.Cells[upRateColumn].Value != 0) ||
                        ((double)ultraRow.Cells[grsProfitSecureRateColumn].Value != 0))
                        {
                            rowIndexName = masterNmColumn;
                            checkFlg = false;
                        }
                    }
                    if (checkFlg == false)
                    {
                        TMsgDisp.Show(
                           this,
                           emErrorLevel.ERR_LEVEL_EXCLAMATION,
                           this.Name,
                           "�����͂̍��ڂ����݂��邽�߁A�o�^�ł��܂���B",
                           -1,
                           MessageBoxButtons.OK);
                        ultraRow.Cells[rowIndexName].Activate();
                        this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                        return false;
                    }
                }
            }
            else if (this._rateProtyMng.UnitPriceKind == 2)
            {
                foreach (UltraGridRow ultraRow in this.Detail_uGrid.Rows)
                {
                    //if (!string.IsNullOrEmpty(ultraRow.Cells[masterNmColumn].Value.ToString()) && (int)ultraRow.Cells[logicalDeleteCodeColumn].Value == 0) // DEL 2010/09/25
                    if (!string.IsNullOrEmpty(ultraRow.Cells[masterNmColumn].Text) && (int)ultraRow.Cells[logicalDeleteCodeColumn].Value == 0) // ADD 2010/09/25
                    {
                        if ((double)ultraRow.Cells[rateValColumn].Value == 0)
                        {
                            rowIndexName = rateValColumn;
                            checkFlg = false;
                        }
                    }
                    //else if (string.IsNullOrEmpty(ultraRow.Cells[masterNmColumn].Value.ToString()) && (int)ultraRow.Cells[logicalDeleteCodeColumn].Value == 0) // DEL 2010/09/25
                    else if (string.IsNullOrEmpty(ultraRow.Cells[masterNmColumn].Text) && (int)ultraRow.Cells[logicalDeleteCodeColumn].Value == 0) // ADD 2010/09/25
                    {
                        if ((double)ultraRow.Cells[rateValColumn].Value != 0)
                        {
                            rowIndexName = masterNmColumn;
                            checkFlg = false;
                        }
                    }
                    if (checkFlg == false)
                    {
                        TMsgDisp.Show(
                           this,
                           emErrorLevel.ERR_LEVEL_EXCLAMATION,
                           this.Name,
                           "�����͂̍��ڂ����݂��邽�߁A�o�^�ł��܂���B",
                           -1,
                           MessageBoxButtons.OK);
                        ultraRow.Cells[rowIndexName].Activate();
                        this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                        return false;
                    }
                }
            }
            else
            {
                foreach (UltraGridRow ultraRow in this.Detail_uGrid.Rows)
                {
                    //if (!string.IsNullOrEmpty(ultraRow.Cells[masterNmColumn].Value.ToString()) && (int)ultraRow.Cells[logicalDeleteCodeColumn].Value == 0) // DEL 2010/09/25
                    if (!string.IsNullOrEmpty(ultraRow.Cells[masterNmColumn].Text) && (int)ultraRow.Cells[logicalDeleteCodeColumn].Value == 0) // ADD 2010/09/25
                    {
                        if ((double)ultraRow.Cells[upRateColumn].Value == 0)
                        {
                            rowIndexName = upRateColumn;
                            checkFlg = false;
                        }
                    }
                    //else if (string.IsNullOrEmpty(ultraRow.Cells[masterNmColumn].Value.ToString()) && (int)ultraRow.Cells[logicalDeleteCodeColumn].Value == 0) // DEL 2010/09/25
                    else if (string.IsNullOrEmpty(ultraRow.Cells[masterNmColumn].Text) && (int)ultraRow.Cells[logicalDeleteCodeColumn].Value == 0) // ADD 2010/09/25
                    {
                        if ((double)ultraRow.Cells[upRateColumn].Value != 0)
                        {
                            rowIndexName = masterNmColumn;
                            checkFlg = false;
                        }
                    }
                    if (checkFlg == false)
                    {
                        TMsgDisp.Show(
                           this,
                           emErrorLevel.ERR_LEVEL_EXCLAMATION,
                           this.Name,
                           "�����͂̍��ڂ����݂��邽�߁A�o�^�ł��܂���B",
                           -1,
                           MessageBoxButtons.OK);
                        ultraRow.Cells[rowIndexName].Activate();
                        this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                        return false;
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// ���ׂ����͍ς݂Ŋ��A����R�[�h�����݂���ꍇ
        /// </summary>
        /// <remarks>
        /// <br>Note        : ���ׂ����͍ς݂Ŋ��A����R�[�h�����݂���ꍇ</br>
        /// <br>Programmer  :hanby</br>
        /// <br>Date        : 2010/09/09</br>
        /// </remarks>
        private bool CheckEqual()
        {
            // ���ׂ����͍ς݂Ŋ��A����R�[�h�����݂���ꍇ�A�G���[���ڂփt�H�[�J�X���ړ����A�G���[�Ƃ���B
            //string rowName = this._rateProtyMngPatternDataSet.RateProtyMngPattern.MasterNmColumn.ColumnName; // DEL 2010/09/25
            string rowName = this._rateProtyMngPatternDataSet.RateProtyMngPattern.GoodsRateGrpCodeColumn.ColumnName; // ADD 2010/09/25
            // �s�폜�t���O
            string logicalDeleteCodeColumn = this._rateProtyMngPatternDataSet.RateProtyMngPattern.LogicalDeleteCodeColumn.ColumnName;

            for (int i = 0; i < this.Detail_uGrid.Rows.Count; i++)
            {
                //if (!string.IsNullOrEmpty(this.Detail_uGrid.Rows[i].Cells[rowName].Value.ToString()) && (int)this.Detail_uGrid.Rows[i].Cells[logicalDeleteCodeColumn].Value == 0) // DEL 2010/09/25
                if (!string.IsNullOrEmpty(this.Detail_uGrid.Rows[i].Cells[rowName].Text) && (int)this.Detail_uGrid.Rows[i].Cells[logicalDeleteCodeColumn].Value == 0) // ADD 2010/09/25
                {
                    this.Detail_uGrid.Rows[i].Cells[rowName].Activate();
                    //DataRow[] dr = this._rateProtyMngPatternDataSet.RateProtyMngPattern.Select("MasterNm = '" + this.Detail_uGrid.Rows[i].Cells[rowName].Value.ToString() + "' AND LogicalDeleteCode = 0"); // DEL 2010/09/25
                    DataRow[] dr = this._rateProtyMngPatternDataSet.RateProtyMngPattern.Select("GoodsRateGrpCode = '" + this.Detail_uGrid.Rows[i].Cells[rowName].Text + "' AND LogicalDeleteCode = 0"); // ADD 2010/09/25
                    if (dr.Length > 1)
                    {
                        TMsgDisp.Show(
                           this,
                           emErrorLevel.ERR_LEVEL_EXCLAMATION,
                           this.Name,
                           "����R�[�h�����݂��邽�߁A�o�^�ł��܂���B",
                           -1,
                           MessageBoxButtons.OK);
                        this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                        return false;
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// ���ׂ��S�Ė����͂̏ꍇ�A�G���[�Ƃ���B
        /// </summary>
        /// <remarks>
        /// <br>Note        : ���ׂ��S�Ė����͂̏ꍇ�A�G���[�Ƃ���B</br>
        /// <br>Programmer  :hanby</br>
        /// <br>Date        : 2010/09/09</br>
        /// </remarks>
        private bool CheckEmpty()
        {
            string rowIndexName = string.Empty;
            // �w��
            //string goodsRateRankColumn = this._rateProtyMngPatternDataSet.RateProtyMngPattern.MasterNmColumn.ColumnName; // DEL 2010/09/25
            string goodsRateRankColumn = this._rateProtyMngPatternDataSet.RateProtyMngPattern.GoodsRateGrpCodeColumn.ColumnName; // ADD 2010/09/25
            // ������
            string rateValColumn = this._rateProtyMngPatternDataSet.RateProtyMngPattern.RateValColumn.ColumnName;
            // ����UP��
            string upRateColumn = this._rateProtyMngPatternDataSet.RateProtyMngPattern.UpRateColumn.ColumnName;
            // �e���m�ۗ�
            string grsProfitSecureRateColumn = this._rateProtyMngPatternDataSet.RateProtyMngPattern.GrsProfitSecureRateColumn.ColumnName;
            // �[�������P��
            string unPrcFracProcUnitColumn = this._rateProtyMngPatternDataSet.RateProtyMngPattern.UnPrcFracProcUnitColumn.ColumnName;
            // �[�������敪
            string unPrcFracProcDivNmColumn = this._rateProtyMngPatternDataSet.RateProtyMngPattern.UnPrcFracProcDivNmColumn.ColumnName;

            if (this._rateProtyMng.UnitPriceKind == 1)
            {
                int count = 0;
                foreach (UltraGridRow ultraRow in this.Detail_uGrid.Rows)
                {
                    //if (string.IsNullOrEmpty(ultraRow.Cells[goodsRateRankColumn].Value.ToString()) && // DEL 2010/09/25
                    if (string.IsNullOrEmpty(ultraRow.Cells[goodsRateRankColumn].Text) && // ADD 2010/09/25
                        (double)ultraRow.Cells[rateValColumn].Value == 0 &&
                        (double)ultraRow.Cells[upRateColumn].Value == 0 &&
                        (double)ultraRow.Cells[grsProfitSecureRateColumn].Value == 0)
                    {
                        count++;
                    }
                    if (count == this.Detail_uGrid.Rows.Count)
                    {
                        TMsgDisp.Show(
                           this,
                           emErrorLevel.ERR_LEVEL_EXCLAMATION,
                           this.Name,
                           "�X�V�Ώۂ̃f�[�^�����݂��܂���B",
                           -1,
                           MessageBoxButtons.OK);
                        this.Detail_uGrid.Rows[0].Cells[goodsRateRankColumn].Activate();
                        this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                        this._checkEmptyFlg = true; // ADD 2010/09/09
                        return false;
                    }
                }
            }
            else if (this._rateProtyMng.UnitPriceKind == 2)
            {
                int count = 0;
                foreach (UltraGridRow ultraRow in this.Detail_uGrid.Rows)
                {
                    //if (string.IsNullOrEmpty(ultraRow.Cells[goodsRateRankColumn].Value.ToString()) && // DEL 2010/09/25
                    if (string.IsNullOrEmpty(ultraRow.Cells[goodsRateRankColumn].Text) && // ADD 2010/09/25
                        (double)ultraRow.Cells[rateValColumn].Value == 0)
                    {
                        count++;
                    }
                    if (count == this.Detail_uGrid.Rows.Count)
                    {
                        TMsgDisp.Show(
                           this,
                           emErrorLevel.ERR_LEVEL_EXCLAMATION,
                           this.Name,
                           "�X�V�Ώۂ̃f�[�^�����݂��܂���B",
                           -1,
                           MessageBoxButtons.OK);
                        this.Detail_uGrid.Rows[0].Cells[goodsRateRankColumn].Activate();
                        this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                        return false;
                    }
                }
            }
            else
            {
                int count = 0;
                foreach (UltraGridRow ultraRow in this.Detail_uGrid.Rows)
                {
                    //if (string.IsNullOrEmpty(ultraRow.Cells[goodsRateRankColumn].Value.ToString()) && // DEL 2010/09/25
                    if (string.IsNullOrEmpty(ultraRow.Cells[goodsRateRankColumn].Text) && // ADD 2010/09/25
                        (double)ultraRow.Cells[rateValColumn].Value == 0 &&
                        (double)ultraRow.Cells[unPrcFracProcUnitColumn].Value == 0 &&
                        string.IsNullOrEmpty(ultraRow.Cells[unPrcFracProcDivNmColumn].Value.ToString()))
                    {
                        count++;
                    }
                    if (count == this.Detail_uGrid.Rows.Count)
                    {
                        TMsgDisp.Show(
                           this,
                           emErrorLevel.ERR_LEVEL_EXCLAMATION,
                           this.Name,
                           "�X�V�Ώۂ̃f�[�^�����݂��܂���B",
                           -1,
                           MessageBoxButtons.OK);
                        this.Detail_uGrid.Rows[0].Cells[goodsRateRankColumn].Activate();
                        this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                        return false;
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// ���o�����ɂ���āA�|���}�X�^�̓ǂݍ��ݏ���
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���o�����ɂ���āA�|���}�X�^�̓ǂݍ��݂��s���܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2010/09/09</br>
        /// </remarks>
        /// <returns></returns>
        private bool Search()
        {
            bool searchStatus = false;
            int status = 0; // ADD 2010/09/25
            bool inputStatus = true;

            if (this.Detail_uGrid.ActiveCell != null)
            {
                this.Detail_uGrid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode);
            }

            // �O���b�h�f�[�^����܂���
            if (this.Detail_uGrid.Rows.Count > 0)
            {
                // �O���b�h�f�[�^���ϓ�����ꍇ
                foreach (UltraGridRow ultraRow in this.Detail_uGrid.Rows)
                {
                    if ((int)ultraRow.Cells[this._rateProtyMngPatternDataSet.RateProtyMngPattern.SaveFlgColumn.ColumnName].Value == 1)
                    {
                        inputStatus = false;
                        break;
                    }
                }
            }

            if (!inputStatus)
            {
                DialogResult dr = TMsgDisp.Show(
                                emErrorLevel.ERR_LEVEL_QUESTION,
                                CT_PGID,
                                "���݁A�ҏW���̃f�[�^�����݂��܂�\n\n" + "�o�^���Ă���낵���ł����H",
                                0,
                                MessageBoxButtons.YesNoCancel);

                switch (dr)
                {
                    case DialogResult.Yes:
                        {
                            #region �O��l�ێ��p�ϐ�(�ۑ��̏������s������A���������p)
                            this._prevCustomerCd = this.tNedit_CustomerCode.GetInt();
                            this._prevCustRateGrpCd = this.tNedit_CustRateGrpCodeZero.GetInt();
                            this._prevSupplierCd = this.tNedit_SupplierCd.GetInt();
                            this._prevMakerCd = this.tNedit_GoodsMakerCd.GetInt();
                            #endregion

                            if (this.SaveProc())
                            {
                                if (this.InsertCondition())
                                {
                                    this.SearchRateData();
                                }
                            }
                            break;
                        }
                    case DialogResult.No:
                        {
                            if (this.CheckCodeExit())
                            {
                                this.SearchRateData();
                            }
                            break;
                        }
                    case DialogResult.Cancel:
                        {
                            this._isCancelFlg = true;
                            if (_prevIndexRow >= 0 && _prevIndexColumn >= 0)
                            {
                                this.Detail_uGrid.Rows[_prevIndexRow].Cells[_prevIndexColumn].Activate();
                                this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                if (this.Detail_uGrid.Rows[_prevIndexRow].Cells[_prevIndexColumn].CanEnterEditMode)
                                {
                                    this.Detail_uGrid.Rows[_prevIndexRow].Cells[_prevIndexColumn].SelectAll();
                                }
                            }
                            break;
                        }
                    case DialogResult.Ignore:
                        {
                            break;
                        }
                }
            }
            else
            {
                status = this.SearchRateData();
            }
            // ---ADD 2010/09/25----------->>>>
            if (status == 0)
            {
                this._prevCustomerCode = this.tNedit_CustomerCode.GetInt();
                this._prevCustRateGrpCode = this.tNedit_CustRateGrpCodeZero.GetInt();
                this._prevSupplierCode = this.tNedit_SupplierCd.GetInt();
                this._prevMakerCode = this.tNedit_GoodsMakerCd.GetInt();
                searchStatus = true;
            }
            // ---ADD 2010/09/25-----------<<<<

            return searchStatus;
        }

        /// <summary>
        /// ���i�|���f���̎擾����
        /// </summary>
        /// <param name="goodsMGroupCode">���i�|���f�R�[�h</param>
        /// <returns>���i�|���f����</returns>
        /// <remarks>
        /// <br>Note       : ���i�|���f���̂��擾���܂��B</br>
        /// <br>Programmer : �k���r</br>
        /// <br>Date       : 2010/08/12</br>
        /// </remarks>
        private string GetGoodsMGroupName(int goodsMGroupCode)
        {
            string goodsMGroupName = "";

            try
            {
                if (_goodsGroupUDic == null)
                {
                    LoadGoodsGroupU();
                }

                if (this._goodsGroupUDic.ContainsKey(goodsMGroupCode))
                {
                    goodsMGroupName = this._goodsGroupUDic[goodsMGroupCode].GoodsMGroupName.Trim();
                }
            }
            catch
            {
                goodsMGroupName = "";
            }

            return goodsMGroupName;
        }

        /// <summary>
        /// ���i�|���f�}�X�^�Ǎ�����
        /// </summary>
        private void LoadGoodsGroupU()
        {
            this._goodsGroupUDic = new Dictionary<int, GoodsGroupU>();

            try
            {
                ArrayList retList;

                int status = this._goodsGroupUAcs.SearchAll(out retList, this._enterpriseCode);
                if (status == 0)
                {
                    foreach (GoodsGroupU goodsGroupU in retList)
                    {
                        if (goodsGroupU.LogicalDeleteCode == 0)
                        {
                            this._goodsGroupUDic.Add(goodsGroupU.GoodsMGroup, goodsGroupU);
                        }
                    }
                }
            }
            catch
            {
                this._goodsGroupUDic = new Dictionary<int, GoodsGroupU>();
            }
        }
        /// <summary>
        /// ���������O�A�����������`�F�b�N
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���������O�A�����������`�F�b�N����B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2010/09/09</br>
        /// </remarks>
        /// <returns></returns>
        private void CheckBeforeSearch()
        {
            #region ���������O�A�����������`�F�b�N
            if (this.tNedit_CustomerCode.GetInt() != 0 && this.tNedit_CustomerCode.Enabled)
            {
                string name = string.Empty;
                if (!GetCustomerName(this.tNedit_CustomerCode.GetInt(), out name))
                {
                    this.CustomerCodeNm_tEdit.Clear();
                }
                else
                {
                    this.CustomerCodeNm_tEdit.Text = name;
                }
            }
            if (this.tNedit_CustRateGrpCodeZero.GetInt() != 0 && this.tNedit_CustRateGrpCodeZero.Enabled)
            {
                string name = string.Empty;
                if (!GetCustRateGrpName(this.tNedit_CustRateGrpCodeZero.GetInt(), out name))
                {
                    this.tEdit_CustRateGrpNm.Clear();
                }
                else
                {
                    this.tEdit_CustRateGrpNm.Text = name;
                }
            }
            if (this.tNedit_SupplierCd.GetInt() != 0 && this.tNedit_SupplierCd.Enabled)
            {
                string name = string.Empty;
                if (!GetSupplierName(this.tNedit_SupplierCd.GetInt(), out name))
                {
                    this.SupplierCdNm_tEdit.Clear();
                }
                else
                {
                    this.SupplierCdNm_tEdit.Text = name;
                }
            }
            if (this.tNedit_GoodsMakerCd.GetInt() != 0 && this.tNedit_GoodsMakerCd.Enabled)
            {
                string name = string.Empty;
                if (!GetMakerName(this.tNedit_GoodsMakerCd.GetInt(), out name))
                {
                    this.MakerName_tEdit.Clear();
                }
                else
                {
                    this.MakerName_tEdit.Text = name;
                }
            }
            #endregion
        }

        /// <summary>
        /// �ۑ��̏������s������A�����������s�����A���o������ݒ�
        /// </summary>
        /// <remarks>
        /// <br>Note       : �ۑ��̏������s������A�����������s�����A���o������ݒ肵�܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2010/09/09</br>
        /// </remarks>
        /// <returns></returns>
        private bool InsertCondition()
        {
            bool customerFlg = false;
            bool custRateGrpFlg = false;
            bool supplierFlg = false;
            bool makerFlg = false;

            // ���Ӑ�
            if (this.tNedit_CustomerCode.Enabled)
            {
                this.tNedit_CustomerCode.DataText = this._prevCustomerCd.ToString("D8");
                string name = string.Empty;
                if (GetCustomerName(this._prevCustomerCd, out name))
                {
                    this.CustomerCodeNm_tEdit.Text = name;
                }
                else
                {
                    this.tNedit_CustomerCode.Clear();
                    customerFlg = true;
                }
            }
            // ���Ӑ�|��
            if (this.tNedit_CustRateGrpCodeZero.Enabled)
            {
                this.tNedit_CustRateGrpCodeZero.DataText = this._prevCustRateGrpCd.ToString("D4");
                string name = string.Empty;
                if (GetCustRateGrpName(this._prevCustRateGrpCd, out name))
                {
                    this.tEdit_CustRateGrpNm.Text = name;
                }
                else
                {
                    this.tNedit_CustRateGrpCodeZero.Clear();
                    custRateGrpFlg = true;
                }
            }
            // �d����
            if (this.tNedit_SupplierCd.Enabled)
            {
                this.tNedit_SupplierCd.DataText = this._prevSupplierCd.ToString("D6");
                string name = string.Empty;
                if (GetSupplierName(this._prevSupplierCd, out name))
                {
                    this.SupplierCdNm_tEdit.Text = name;
                }
                else
                {
                    this.tNedit_SupplierCd.Clear();
                    supplierFlg = true;
                }
            }
            // Ұ��
            if (this.tNedit_GoodsMakerCd.Enabled)
            {
                this.tNedit_GoodsMakerCd.DataText = this._prevMakerCd.ToString("D4");
                string name = string.Empty;
                if (GetMakerName(this._prevMakerCd, out name))
                {
                    this.MakerName_tEdit.Text = name;
                }
                else
                {
                    this.tNedit_GoodsMakerCd.Clear();
                    makerFlg = true;
                }
            }

            if (customerFlg == true)
            {
                // �G���[��
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    "���Ӑ悪���݂��܂���B",
                    -1,
                    MessageBoxButtons.OK);

                this.tNedit_CustomerCode.Focus();
                this.tToolbarsManager_MainMenu.Tools[TOOLBAR_GUIDEBUTTON_KEY].SharedProps.Enabled = true;
                return false;
            }
            else if (custRateGrpFlg == true)
            {
                // �G���[��
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    "���Ӑ�|����ٰ�߂����݂��܂���B",
                    -1,
                    MessageBoxButtons.OK);

                this.tNedit_CustRateGrpCodeZero.Focus();
                this.tToolbarsManager_MainMenu.Tools[TOOLBAR_GUIDEBUTTON_KEY].SharedProps.Enabled = true;
                return false;
            }
            else if (supplierFlg == true)
            {
                // �G���[��
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    "�d���悪���݂��܂���B",
                    -1,
                    MessageBoxButtons.OK);

                this.tNedit_SupplierCd.Focus();
                this.tToolbarsManager_MainMenu.Tools[TOOLBAR_GUIDEBUTTON_KEY].SharedProps.Enabled = true;
                return false;
            }
            else if (makerFlg == true)
            {
                // �G���[��
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    "���[�J�[�}�X�^�����o�^�ł��B",
                    -1,
                    MessageBoxButtons.OK);

                this.tNedit_GoodsMakerCd.Focus();
                this.tToolbarsManager_MainMenu.Tools[TOOLBAR_GUIDEBUTTON_KEY].SharedProps.Enabled = true;
                return false;
            }

            return true;
        }

        /// <summary>
        /// ���o�����`�F�b�N
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���o�����`�F�b�N����B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2010/09/09</br>
        /// </remarks>
        /// <returns></returns>
        private bool CheckCodeExit()
        {
            if (this.tNedit_CustomerCode.Focused)
            {
                int inputValue = this.tNedit_CustomerCode.GetInt();
                string name = string.Empty;
                //if (!GetCustomerName(inputValue, out name)) // DEL 2010/09/26
                if (inputValue != 0 && !GetCustomerName(inputValue, out name)) // ADD 2010/09/26
                {
                    this._checkInputScreenErr = true;  // ADD 2010/09/26
                    // �G���[��
                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_INFO,
                        this.Name,
                        "���Ӑ悪���݂��܂���B",
                        -1,
                        MessageBoxButtons.OK);

                    this.CustomerCodeNm_tEdit.Clear();
                    this.tNedit_CustomerCode.SelectAll();
                    return false;
                }
            }
            else if (this.tNedit_CustRateGrpCodeZero.Focused)
            {
                int inputValue = this.tNedit_CustRateGrpCodeZero.GetInt();
                string name = string.Empty;
                //if (!GetCustRateGrpName(inputValue, out name)) // DEL 2010/09/26
                if (inputValue != 0 && !GetCustRateGrpName(inputValue, out name)) // ADD 2010/09/26
                {
                    this._checkInputScreenErr = true;  // ADD 2010/09/26
                    // �G���[��
                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_INFO,
                        this.Name,
                        "���Ӑ�|����ٰ�߂����݂��܂���B",
                        -1,
                        MessageBoxButtons.OK);

                    this.tEdit_CustRateGrpNm.Clear();
                    this.tNedit_CustRateGrpCodeZero.SelectAll();
                    return false;
                }
            }
            else if (this.tNedit_SupplierCd.Focused)
            {
                int inputValue = this.tNedit_SupplierCd.GetInt();
                string name = string.Empty;
                //if (!GetSupplierName(inputValue, out name)) // DEL 2010/09/26
                if (inputValue != 0 && !GetSupplierName(inputValue, out name)) // ADD 2010/09/26
                {
                    this._checkInputScreenErr = true;  // ADD 2010/09/26
                    // �G���[��
                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_INFO,
                        this.Name,
                        "�d���悪���݂��܂���B",
                        -1,
                        MessageBoxButtons.OK);

                    this.SupplierCdNm_tEdit.Clear();
                    this.tNedit_SupplierCd.SelectAll();
                    return false;
                }
            }
            else if (this.tNedit_GoodsMakerCd.Focused)
            {
                int inputValue = this.tNedit_GoodsMakerCd.GetInt();
                string name = string.Empty;
                //if (!GetMakerName(inputValue, out name)) // DEL 2010/09/26
                if (inputValue != 0 && !GetMakerName(inputValue, out name)) // ADD 2010/09/26
                {
                    this._checkInputScreenErr = true;  // ADD 2010/09/26
                    // �G���[��
                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_INFO,
                        this.Name,
                        "���[�J�[�}�X�^�����o�^�ł��B",
                        -1,
                        MessageBoxButtons.OK);

                    this.MakerName_tEdit.Clear();
                    this.tNedit_GoodsMakerCd.SelectAll();
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// ��ʂ�߂�
        /// </summary>
        /// <remarks>
        /// <br>Note       : ��ʂ�߂�</br>
        /// <br>Programmer  : wangc</br>
        /// <br>Date        : 2010/09/13</br>
        /// </remarks>
        /// <returns></returns>
        private void PMKHN09476UA_FormClosing(object sender, FormClosingEventArgs e)
        {
            #region �I��
            if (_closeFlg == false)
            {
                if (!this.CloseCheck())
                {
                    DialogResult dr = TMsgDisp.Show(
                        emErrorLevel.ERR_LEVEL_QUESTION,
                        CT_PGID,
                        "���݁A�ҏW���̃f�[�^�����݂��܂�\n\n" + "�o�^���Ă���낵���ł����H",
                        0,
                        MessageBoxButtons.YesNoCancel);

                    switch (dr)
                    {
                        case DialogResult.No:
                            break;
                        case DialogResult.Yes:
                            if (!this.SaveProc())
                            {
                                e.Cancel = true;
                            }

                            break;
                        case DialogResult.Cancel:
                            e.Cancel = true;
                            if (this.Detail_uGrid.ActiveCell != null && this.Detail_uGrid.ActiveCell.Activation == Activation.AllowEdit)
                            {
                                this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                            }
                            break;
                    }
                }
            }
            #endregion
        }

        /// <summary>
        /// �S�폜�{�^���L�������`�F�b�N
        /// </summary>
        /// <remarks>
        /// <br>Note       : �S�폜�{�^���L�������`�F�b�N���܂��B</br>
        /// <br>Programmer : �� ��</br>
        /// <br>Date       : 2010/09/09</br>
        /// </remarks>
        /// <returns></returns>
        private bool AllDeleteEnabledCheck()
        {
            // ���[�J�[�R�[�h
            //string goodsMakerCdColumn = this._rateProtyMngPatternDataSet.RateProtyMngPattern.MasterNmColumn.ColumnName; // DEL 2010/09/25
            string goodsMakerCdColumn = this._rateProtyMngPatternDataSet.RateProtyMngPattern.GoodsRateGrpCodeColumn.ColumnName; // ADD 2010/09/25
            // ������
            string rateValColumn = this._rateProtyMngPatternDataSet.RateProtyMngPattern.RateValColumn.ColumnName;
            // ����UP��
            string upRateColumn = this._rateProtyMngPatternDataSet.RateProtyMngPattern.UpRateColumn.ColumnName;
            // �e���m�ۗ�
            string grsProfitSecureRateColumn = this._rateProtyMngPatternDataSet.RateProtyMngPattern.GrsProfitSecureRateColumn.ColumnName;
            // �[�������P��
            string unPrcFracProcUnitColumn = this._rateProtyMngPatternDataSet.RateProtyMngPattern.UnPrcFracProcUnitColumn.ColumnName;
            // �[�������敪
            string unPrcFracProcDivNmColumn = this._rateProtyMngPatternDataSet.RateProtyMngPattern.UnPrcFracProcDivNmColumn.ColumnName;
            // ���W�b�N�폜�敪
            string logicalDeleteCodeColumn = this._rateProtyMngPatternDataSet.RateProtyMngPattern.LogicalDeleteCodeColumn.ColumnName;
            // �`�F�b�N�t���O
            bool checkFlg = false;

            if (this.Detail_uGrid.Rows.Count == 0)
            {
                return checkFlg;
            }

            foreach (UltraGridRow row in this.Detail_uGrid.Rows)
            {
                if (this._rateProtyMng.UnitPriceKind == 1)
                {
                    if ((!"1".Equals(row.Cells[logicalDeleteCodeColumn].Text.Trim())) && ((row.Cells[goodsMakerCdColumn].Activation == Activation.NoEdit) ||
                        (double)row.Cells[rateValColumn].Value != 0 ||
                        (double)row.Cells[upRateColumn].Value != 0 ||
                        (double)row.Cells[grsProfitSecureRateColumn].Value != 0))
                    {
                        checkFlg = true;
                        return checkFlg;
                    }
                }
                else if (this._rateProtyMng.UnitPriceKind == 2)
                {
                    if ((!"1".Equals(row.Cells[logicalDeleteCodeColumn].Text.Trim())) && ((row.Cells[goodsMakerCdColumn].Activation == Activation.NoEdit) ||
                        (double)row.Cells[rateValColumn].Value != 0))
                    {
                        checkFlg = true;
                        return checkFlg;
                    }
                }
                else
                {
                    if ((!"1".Equals(row.Cells[logicalDeleteCodeColumn].Text.Trim())) && ((row.Cells[goodsMakerCdColumn].Activation == Activation.NoEdit) ||
                        (double)row.Cells[upRateColumn].Value != 0 ||
                        (double)row.Cells[unPrcFracProcUnitColumn].Value != 1 ||
                        !"2".Equals(row.Cells[unPrcFracProcDivNmColumn].Value.ToString())))
                    {
                        checkFlg = true;
                        return checkFlg;
                    }
                }
            }

            return checkFlg;
        }

        /// <summary>
        /// ���l���̓`�F�b�N����
        /// </summary>
        /// <param name="keta">����(�}�C�i�X�������܂܂�)</param>
        /// <param name="priod">�����_�ȉ�����</param>
        /// <param name="prevVal">���݂̕�����</param>
        /// <param name="key">���͂��ꂽ�L�[�l</param>
        /// <param name="selstart">�J�[�\���ʒu</param>
        /// <param name="sellength">�I�𕶎���</param>
        /// <param name="minusFlg">�}�C�i�X���͉H</param>
        /// <returns>true=���͉�,false=���͕s��</returns>
        /// <remarks>
        /// <br>Note        : ���l�̓��̓`�F�b�N���s���܂��B</br>
        /// <br>Programmer  : caowj</br>
        /// <br>Date        : 2010/08/19</br>
        /// <br>Programmer  : wangc</br>
        /// <br>Date        : 2010/09/19</br>
        /// </remarks>
        private bool KeyPressNumCheck(int keta, int priod, string prevVal, char key, int selstart, int sellength, Boolean minusFlg)
        {
            // ����L�[�������ꂽ�H
            if (Char.IsControl(key))
            {
                return true;
            }
            // ���l�ȊO�́A�m�f
            if (!Char.IsDigit(key))
            {
                // �����_�܂��́A�}�C�i�X�ȊO
                if ((key != '.') && (key != '-'))
                {
                    return false;
                }
            }
            // ----------ADD 2010/09/19----------->>
            // �S�p���l�́A�m�f
            if (2 * key.ToString().Length == Encoding.Default.GetByteCount(key.ToString()))
            {
                return false;
            }
            // --------ADD UPD 2010/09/09---------<<<

            // �L�[�������ꂽ�Ɖ��肵���ꍇ�̕�����𐶐�����B
            string strResult = "";
            if (sellength > 0)
            {
                strResult = prevVal.Substring(0, selstart) + prevVal.Substring(selstart + sellength, prevVal.Length - (selstart + sellength));
            }
            else
            {
                strResult = prevVal;
            }

            // �}�C�i�X�̃`�F�b�N
            if (key == '-')
            {
                if ((minusFlg == false) || (selstart > 0) || (strResult.IndexOf('-') != -1))
                {
                    return false;
                }
            }

            // �����_�̃`�F�b�N
            if (key == '.')
            {
                if ((priod <= 0) || (strResult.IndexOf('.') != -1))
                {
                    return false;
                }
            }
            // �L�[�������ꂽ���ʂ̕�����𐶐�����B
            strResult = prevVal.Substring(0, selstart)
                + key
                + prevVal.Substring(selstart + sellength, prevVal.Length - (selstart + sellength));

            // �����`�F�b�N�I
            if (strResult.Length > keta)
            {
                if (strResult[0] == '-')
                {
                    if (strResult.Length > (keta + 1))
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }

            // �����_�ȉ��̃`�F�b�N
            if (priod > 0)
            {
                // �����_�̈ʒu����
                int _pointPos = strResult.IndexOf('.');

                // �������ɓ��͉\�Ȍ���������I
                int _Rketa = (strResult[0] == '-') ? keta - priod : keta - priod - 1;
                // �������̌������`�F�b�N
                if (_pointPos != -1)
                {
                    if (_pointPos > _Rketa)
                    {
                        return false;
                    }
                }
                else
                {
                    if (strResult.Length > _Rketa)
                    {
                        return false;
                    }
                }

                // �������̌������`�F�b�N
                if (_pointPos != -1)
                {
                    // �������̌������v�Z
                    int _priketa = strResult.Length - _pointPos - 1;
                    if (priod < _priketa)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// �����͉\�Z���ړ�����
        /// </summary>
        /// <param name="activeCellCheck">true:ActiveCell�����͉\�̏ꍇ��Next�Ɉړ������Ȃ� false:ActiveCell�Ɋ֌W�Ȃ�Next�Ɉړ�������</param>
        /// <returns>true:�Z���ړ����� false:�Z���ړ����s</returns>
        /// <remarks>
        /// <br>Note       : �����͉\�Z���ړ����������܂��B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2010/09/19</br>
        /// </remarks>
        private bool MoveNextAllowEditCell(bool activeCellCheck, int leftRightFlg)
        {
            this.Detail_uGrid.SuspendLayout();
            bool moved = false;
            bool performActionResult = false;

            if ((activeCellCheck) && (this.Detail_uGrid.ActiveCell != null))
            {
                if ((!this.Detail_uGrid.ActiveCell.Column.Hidden) &&
                    (this.Detail_uGrid.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) &&
                    (this.Detail_uGrid.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
                {
                    moved = true;
                }
            }

            while (!moved)
            {
                if (leftRightFlg == 0)
                {
                    performActionResult = this.Detail_uGrid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.PrevCell);
                }
                else if (leftRightFlg == 1)
                {
                    performActionResult = this.Detail_uGrid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextCell);
                }

                if (performActionResult)
                {
                    if ((this.Detail_uGrid.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) &&
                        (this.Detail_uGrid.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
                    {
                        moved = true;
                    }
                    else
                    {
                        moved = false;
                    }
                }
                else
                {
                    break;
                }
            }

            if (moved)
            {
                this.Detail_uGrid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                this.Detail_uGrid.ActiveCell.SelectAll();
            }

            this.Detail_uGrid.ResumeLayout();
            return performActionResult;
        }
        /// <summary>
        /// �S���s�̍폜���f
        /// </summary>
        /// <returns>true:�S���s�̍폜 false:��S���s�폜</returns>
        /// <remarks>
        /// <br>Note       : �S���s�̍폜�𔻒f���܂��B</br>
        /// <br>Programmer : wangc</br>
        /// <br>Date       : 2010/09/21</br>
        /// </remarks>
        private bool AllDeleteCheck()
        {
            bool allDeltete = false;
            string logicalDeleteCodeColumn = this._rateProtyMngPatternDataSet.RateProtyMngPattern.LogicalDeleteCodeColumn.ColumnName;
            foreach (UltraGridRow row in this.Detail_uGrid.Rows)
            {

                if ((int)row.Cells[logicalDeleteCodeColumn].Value != 1)
                {
                    allDeltete = true;
                }
            }

            return allDeltete;
        }

        /// <summary>
        /// �s�̑I��
        /// </summary>
        /// <returns>�I���s�̔ԍ�</returns>
        /// <remarks>
        /// <br>Note       : �s�̑I��</br>
        /// <br>Programmer : wangc</br>
        /// <br>Date       : 2010/09/21</br>
        /// </remarks>
        private int SelectedRow()
        {
            int selectRow;
            bool findedFlag = false; //ADD 2011/11/21 xupz
            //string logicalDeleteCodeColumn = this._rateProtyMngPatternDataSet.RateProtyMngPattern.LogicalDeleteCodeColumn.ColumnName;
            for (selectRow = 0; selectRow < this.Detail_uGrid.Rows.Count; selectRow++)
            {
                // if (this.Detail_uGrid.Rows[selectRow].Cells[0].Activation == Activation.AllowEdit) // DEL 2010/09/30
                if (this.Detail_uGrid.Rows[selectRow].Cells[masterCode].Activation == Activation.AllowEdit) // ADD 2010/09/30
                {
                    //this.Detail_uGrid.Rows[targetRowIndex].Cells[columnIndex].Activate();
                    //this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                    findedFlag = true; //ADD 2011/11/21 xupz
                    break;
                }
            }
            //foreach (UltraGridRow row in this.Detail_uGrid.Rows)
            //{
            //    selectRow++;
            //    if ((int)row.Cells[logicalDeleteCodeColumn].Value != 1)
            //    {
            //        break;
            //    }
            //}

            //return selectRow; // DEL 2011/11/21 xupz
            // ----- ADD 2011/11/21 xupz---------->>>>>
            if (findedFlag)
            {
                return selectRow;
            }
            else
            {
                return 0;
            }
            // ----- ADD 2011/11/21 xupz----------<<<<<
        }

        /// <summary>
        /// �s�̑I��
        /// </summary>
        /// <returns>�I���s�̔ԍ�</returns>
        /// <remarks>
        /// <br>Note       : �s�̑I��</br>
        /// <br>Programmer : wangc</br>
        /// <br>Date       : 2010/09/21</br>
        /// </remarks>
        private bool CatchSelectedRow(int rowIndex)
        {
            bool selectedRow = false;
            string logicalDeleteCodeColumn = this._rateProtyMngPatternDataSet.RateProtyMngPattern.LogicalDeleteCodeColumn.ColumnName;

            for (int i = rowIndex; i < 999; i++)
            {
                if ((int)this.Detail_uGrid.Rows[i].Cells[logicalDeleteCodeColumn].Value != 1)
                {
                    selectedRow = true;
                }
            }

            return selectedRow;
        }

        // ---ADD 2010/09/09----------------------<<<
        #endregion Private Method

        /// <summary>
        /// Enter �C�x���g(tNedit_CustRateGrpCode)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note		: �e�L�X�g�{�b�N�X���A�N�e�B�u�ɂȂ����Ƃ��ɔ������܂��B</br>
        /// <br>Programmer  : ����</br>
        /// <br>Date        : 2010/08/19</br>
        /// </remarks>
        private void tNedit_CustRateGrpCodeZero_Enter(object sender, EventArgs e)
        {
            if (this.tNedit_CustRateGrpCodeZero.DataText.Trim() == "")
            {
                return;
            }

            int custRateGrpCode = this.tNedit_CustRateGrpCodeZero.GetInt();

            this.tNedit_CustRateGrpCodeZero.SetInt(custRateGrpCode);
            this.tNedit_CustRateGrpCodeZero.SelectAll();
        }


        // ---DEL 2010/09/25---------------------->>>
        //private void ultraExpandableGroupBoxPanel1_Paint(object sender, PaintEventArgs e)
        //{

        //}
        // ---DEL 2010/09/25----------------------<<<

        // ---UPD 2010/09/25---------------------->>>
        /// <summary>
        /// �O���b�h�����ҏW�s���擾����
        /// </summary>
        /// <remarks>
        /// <br>Note        : �O���b�h�����ҏW�s�擾���s���܂��B</br>
        /// <br>Programmer  : ������</br>
        /// <br>Date        : 2010/09/25</br>
        /// </remarks>
        private int GetGridInitRowNo()
        {
            int rowIndex;
            for (rowIndex = 0; rowIndex < this.Detail_uGrid.Rows.Count; rowIndex++)
            {
                if (this.Detail_uGrid.Rows[rowIndex].Cells[this._rateProtyMngPatternDataSet.RateProtyMngPattern.GoodsRateGrpCodeColumn.ColumnName].Activation == Activation.AllowEdit)
                {
                    break;
                }
            }
            return rowIndex;
        }
        // ---UPD 2010/09/25----------------------<<<
    }
}
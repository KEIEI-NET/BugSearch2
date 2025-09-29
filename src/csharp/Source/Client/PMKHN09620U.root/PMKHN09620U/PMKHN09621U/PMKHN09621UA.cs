//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �L�����y�[���Ώۏ��i�ݒ�}�X�^
// �v���O�����T�v   : �L�����y�[���Ώۏ��i�ݒ�}�X�^���s��
//----------------------------------------------------------------------------//
//                (c)Copyright 2011 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10701342-00 �쐬�S�� : ������
// �� �� ��  2011/04/26  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10700008-00 �쐬�S�� : 杍^
// �C �� ��  2011/07/07  �C�����e : Redmine#22810 �@���׍��ڂ̕��E�����T�C�Y�͕ύX���ɕۑ��̑Ή�
//                                                �A���E�[�̍��ڂŎ~�܂�悤�ɏC��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10700008-00 �쐬�S�� : ������
// �C �� ��  2011/07/12  �C�����e : Redmine#22919 �@����N�����̕����T�C�Y�ƍ��ڕ��̕ύX
//                                                �A���ׂ̃L�����y�[���R�[�h�ɏ����\������悤�ɕύX
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10700008-00 �쐬�S�� : ������
// �C �� ��  2011/07/14  �C�����e : Redmine#22984 �ŏI�s�̏�񂪃f�[�^�o�^����Ȃ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10700008-00 �쐬�S�� : ������
// �C �� ��  2011/07/21  �C�����e : Redmine#23199 �w�b�_�ŃL�����y�[���R�[�h����͌�ɁA�������s��A�P�����f�[�^���Ȃ��ꍇ�ɁA���ד��e�w��s���̏C��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ����g
// �C �� ��  2011/08/12  �C�����e : Redmine#23556 ���������[�h�͕��ׂď������āA���Ԃ���������悤�ɏC������
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30973�@����
// �X �V ��  2015/01/29  �C�����e : ���R�����h�Ή� ���������i�ݒ�ďo���ǉ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30973�@����
// �X �V ��  2015/06/02  �C�����e : ���R�����h�Ή� ���������i�ݒ�ďo���̎g�p��~
//----------------------------------------------------------------------------//
using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Library.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using System.Collections;
using Infragistics.Win.UltraWinToolbars;
using Infragistics.Win.UltraWinGrid;
using System.Diagnostics;
using System.Threading;
// DEL 2015/06/02 ���� ���������i�ݒ�ďo���̎g�p��~ ----------------------------------->>>>>
//using Broadleaf.Application.Resources;  // ADD 2015/01/29 ����
// DEL 2015/06/02 ���� ���������i�ݒ�ďo���̎g�p��~ -----------------------------------<<<<<

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// �L�����y�[���Ώۏ��i�ݒ�}�X�^ UI�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �L�����y�[���Ώۏ��i�ݒ�}�X�^UI�t�H�[���N���X</br>
    /// <br>Programmer : ������</br>
    /// <br>Date       : 2011/04/26</br>
    /// <br>UpdateNote : 2011/07/07 杍^ Redmine#22810 �@���׍��ڂ̕��E�����T�C�Y�͕ύX���ɕۑ��̑Ή�</br>
    /// <br>�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@ �A���E�[�̍��ڂŎ~�܂�悤�ɏC��</br>
    /// <br>UpdateNote : 2011/07/12 ������ Redmine#22919 �@����N�����̕����T�C�Y�ƍ��ڕ��̕ύX</br>
    /// <br>�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@ �A���ׂ̃L�����y�[���R�[�h�ɏ����\������悤�ɕύX</br>
    /// <br>UpdateNote : 2011/07/14 ������ Redmine#22984 �ŏI�s�̏�񂪃f�[�^�o�^����Ȃ�</br>
    /// <br>UpdateNote : 2011/07/21 杍^ Redmine#23199 �w�b�_�ŃL�����y�[���R�[�h����͌�ɁA�������s��A�P�����f�[�^���Ȃ��ꍇ�ɁA���ד��e�w��s���̏C��</br>
    /// </remarks>
    public partial class PMKHN09621UA : Form
    {
        # region Private Members
        private PMKHN09621UB _detailInput;
        private ImageList _imageList16 = null;                                                // �C���[�W���X�g
        private Infragistics.Win.UltraWinToolbars.ButtonTool _closeButton;                    // �I���{�^��
        private Infragistics.Win.UltraWinToolbars.ButtonTool _searchButton;                   // �����{�^��
        private Infragistics.Win.UltraWinToolbars.ButtonTool _saveButton;                     // �ۑ��{�^��
        private Infragistics.Win.UltraWinToolbars.ButtonTool _clearButton;                    // �N���A�{�^��
        private Infragistics.Win.UltraWinToolbars.ButtonTool _guideButton;                    // �K�C�h�{�^��
        private Infragistics.Win.UltraWinToolbars.ButtonTool _reNewalButton;                    // �ŐV���{�^��
        // DEL 2015/06/02 ���� ���������i�ݒ�ďo���̎g�p��~ ----------------------------------->>>>>
        //// ADD 2015/01/29 ���� ���������i�ݒ�ďo���ǉ� ----------------------------------->>>>>
        //private Infragistics.Win.UltraWinToolbars.ButtonTool _recBgnItmStButton;              // ���������i�ݒ�{�^��
        //// ADD 2015/01/29 ���� ���������i�ݒ�ďo���ǉ� -----------------------------------<<<<<
        // DEL 2015/06/02 ���� ���������i�ݒ�ďo���̎g�p��~ -----------------------------------<<<<<
        private Infragistics.Win.UltraWinToolbars.LabelTool _loginNameLabel;                  // ���O�C���S����
        private Infragistics.Win.UltraWinToolbars.LabelTool _loginEmployeeLabel;                  // ���O�C���S���Җ���
        private ControlScreenSkin _controlScreenSkin;
        private Control _prevControl = null;

        private string _enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
        private string _loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;

        private CampaignObjGoodsStAcs _campaignObjGoodsStAcs = null;
        private MakerAcs _makerAcs = null;					// ���[�J�[�A�N�Z�X�N���X
        private CampaignLinkAcs _campaignLinkAcs;
        private SecInfoSetAcs _secInfoSetAcs;
        private UserGuideAcs _userGuideAcs;
        private BLGoodsCdAcs _blGoodsCdAcs;
        private BLGroupUAcs _blGroupUAcs;

        /// <summary>�`�[�\���^�u ��T�C�Y���������l</summary>
        private bool _columnWidthAutoAdjust = false;

        private int _prevSectionCd = 0;
        private int _prevCampaignCd = 0;
        private bool _masterCheckFlg = false;
        private SearchCondition _searchCondition = null;
        private bool _isButtonClick = false;

        // DEL 2015/06/02 ���� ���������i�ݒ�ďo���̎g�p��~ ----------------------------------->>>>>
        //// ADD 2015/01/29 ���� ���������i�ݒ�ďo���ǉ� ----------------------------------->>>>>
        ///// <summary>SCM�I�v�V����</summary>
        //private int _opt_Scm;
        ///// <summary>�I�v�V�����L���L��</summary>
        //private enum Option : int
        //{
        //    /// <summary>����</summary>
        //    OFF = 0,
        //    /// <summary>�L��</summary>
        //    ON = 1,
        //}
        //// ADD 2015/01/29 ���� ���������i�ݒ�ďo���ǉ� -----------------------------------<<<<<
        // DEL 2015/06/02 ���� ���������i�ݒ�ďo���̎g�p��~ -----------------------------------<<<<<

        #endregion

        #region const
        private const string TOOLBAR_CLOSEBUTTON_KEY = "ButtonTool_Close";						// �I��
        private const string TOOLBAR_SEARCHBUTTON_KEY = "ButtonTool_Search";					// ����
        private const string TOOLBAR_SAVEBUTTON_KEY = "ButtonTool_Save";						// �ۑ�
        private const string TOOLBAR_CLEARBUTTON_KEY = "ButtonTool_Clear";						// �N���A
        private const string TOOLBAR_GUIDEBUTTON_KEY = "ButtonTool_Guide";						// �K�C�h
        private const string TOOLBAR_RENEWALBUTTON_KEY = "ButtonTool_ReNewal";					// �ŐV���
        private const string TOOLBAR_SHOWMASTERBUTTON_KEY = "ButtonTool_ShowMaster";			// �L�����y�[�����̐ݒ�
        // DEL 2015/06/02 ���� ���������i�ݒ�ďo���̎g�p��~ ----------------------------------->>>>>
        //// ADD 2015/01/29 ���� ���������i�ݒ�ďo���ǉ� ----------------------------------->>>>>
        //private const string TOOLBAR_SHORECBGNITMST_KEY = "ButtonTool_RecBgnItmSt";	            // ���������i�ݒ�
        //// ADD 2015/01/29 ���� ���������i�ݒ�ďo���ǉ� -----------------------------------<<<<<
        // DEL 2015/06/02 ���� ���������i�ݒ�ďo���̎g�p��~ -----------------------------------<<<<<

        /// <summary>�\���F�����t�H���g�T�C�Y</summary>
        //private const int CT_DEF_FONT_SIZE = 11;   // DEL 2011/07/12
        private const int CT_DEF_FONT_SIZE = 10;     // ADD 2011/07/12

        private static readonly Color ct_READONLY_CELL_COLOR = Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(220)))));
        /// <summary>�����T�C�Y</summary>
        private readonly int[] _fontpitchSize = new int[] { 6, 8, 9, 10, 11, 12, 14, 16, 18, 20, 22, 24 };
        /// <summary>���׃f�[�^���o�ő匏��</summary>
        private const long DATA_COUNT_MAX = 20000;
        #endregion

        # region Constroctors
        /// <summary>
        ///  �L�����y�[���Ώۏ��i�ݒ�}�X�^�t�H�[���N���X �f�t�H���g�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �L�����y�[���Ώۏ��i�ݒ�}�X�^�t�H�[���N���X �f�t�H���g�R���X�g���N�^</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/04/26</br>
        /// <br>UpdateNote : 2011/07/07 杍^ Redmine#22810 ���׍��ڂ̕��E�����T�C�Y�͕ύX���ɕۑ��̑Ή�</br>
        /// <br>UpdateNote : 2011/07/12 ������ Redmine#22919 �@����N�����̕����T�C�Y�ƍ��ڕ��̕ύX</br>
        /// <br>�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@ �A���ׂ̃L�����y�[���R�[�h�ɏ����\������悤�ɕύX</br>
        /// </remarks>
        public PMKHN09621UA()
        {
            InitializeComponent();

            // DEL 2015/06/02 ���� ���������i�ݒ�ďo���̎g�p��~ ----------------------------------->>>>>
            //// ADD 2015/01/29 ���� ���������i�ݒ�ďo���ǉ� ----------------------------------->>>>>
            //// �I�v�V�������
            //this.CacheOptionInfo();
            //// ADD 2015/01/29 ���� ���������i�ݒ�ďo���ǉ� -----------------------------------<<<<<
            // DEL 2015/06/02 ���� ���������i�ݒ�ďo���̎g�p��~ -----------------------------------<<<<<

            // �ϐ�������
            this._detailInput = new PMKHN09621UB();
            this._imageList16 = IconResourceManagement.ImageList16;
            this._loginNameLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)this.tToolsManager_MainMenu.Tools["LabelTool_LoginTitle"];
            this._loginEmployeeLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)this.tToolsManager_MainMenu.Tools["LabelTool_LoginName"];
            this._closeButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools["ButtonTool_Close"];
            this._searchButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools["ButtonTool_Search"];
            this._saveButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools["ButtonTool_Save"];
            this._clearButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools["ButtonTool_Clear"];
            this._guideButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools["ButtonTool_Guide"];
            this._reNewalButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools["ButtonTool_ReNewal"];
            // DEL 2015/06/02 ���� ���������i�ݒ�ďo���̎g�p��~ ----------------------------------->>>>>
            //// ADD 2015/01/29 ���� ���������i�ݒ�ďo���ǉ� ----------------------------------->>>>>
            //this._recBgnItmStButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools["ButtonTool_RecBgnItmSt"];
            //// SCM�I�v�V�����L�����̂ݗL��
            //if (this._opt_Scm == (int)Option.OFF)
            //{
            //    this._recBgnItmStButton.SharedProps.Visible = false;
            //    this._recBgnItmStButton.SharedProps.Enabled = false;
            //}
            //else
            //{ 
            //    this._recBgnItmStButton.SharedProps.Visible = true;
            //    this._recBgnItmStButton.SharedProps.Enabled = true;
            //}
            //// ADD 2015/01/29 ���� ���������i�ݒ�ďo���ǉ� -----------------------------------<<<<<
            // DEL 2015/06/02 ���� ���������i�ݒ�ďo���̎g�p��~ -----------------------------------<<<<<
            this._detailInput.GridKeyUpTopRow += new EventHandler(this.GriedDetail_GridKeyUpTopRow);
            this._controlScreenSkin = new ControlScreenSkin();
            this._loginEmployeeLabel.SharedProps.Caption = LoginInfoAcquisition.Employee.Name;

            this._detailInput.SetGuidButton += new PMKHN09621UB.SetGuidButtonEventHandler(this.SetGuidButton);
            this._detailInput.GetCampaignInfo += new PMKHN09621UB.GetCampaignInfoEventHandler(this.GetCampaignInfo); // ADD 2011/07/12

            this._campaignObjGoodsStAcs = this._detailInput.CampaignObjGoodsStAcs;
            this._makerAcs = new MakerAcs();
            this._campaignLinkAcs = new CampaignLinkAcs();
            this._secInfoSetAcs = new SecInfoSetAcs();
            this._userGuideAcs = new UserGuideAcs();
            this._blGoodsCdAcs = new BLGoodsCdAcs();
            this._blGroupUAcs = new BLGroupUAcs();

            // �ݒ�ǂݍ���
            this._detailInput.Deserialize();   // ADD K2011/07/07 

            this.uExGroupBox_ExtraCondition.Expanded = false;
            this.tComboEditor_DeleteFlag.SelectedIndex = 0;
            this.tComboEditor_PriceFl.SelectedIndex = 0;
            this.tComboEditor_RateVal.SelectedIndex = 0;
            this.tComboEditor_DiscountRate.SelectedIndex = 0;
            this.tComboEditor_StatusBar_FontSize.SelectedIndex = 0;
            this.tComboEditor_StatusBar_FontSize.SelectedIndex = this._detailInput.UserSetting.OutputStyle;
        }
        #endregion

        #region �C�x���g
        /// <summary>
        /// �t�H�[�����[�h�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : �t�H�[�����[�h�C�x���g�������s���܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/04/26</br>
        /// <br>UpdateNote : 2011/07/07 杍^ Redmine#22810 ���׍��ڂ̕��E�����T�C�Y�͕ύX���ɕۑ��̑Ή�</br>
        /// <br>UpdateNote : 2011/07/12 ������ Redmine#22919 �@����N�����̕����T�C�Y�ƍ��ڕ��̕ύX</br>
        /// </remarks>
        private void PMKHN09621UA_Load(object sender, EventArgs e)
        {
            // Skin�ݒ�
            this._controlScreenSkin.LoadSkin();

            List<string> controlNameList = new List<string>();
            controlNameList.Add(this.uExGroupBox_CommonCondition.Name);
            controlNameList.Add(this.uExGroupBox_ExtraCondition.Name);
            this._controlScreenSkin.SetExceptionCtrl(controlNameList);

            this._controlScreenSkin.SettingScreenSkin(this);
            this._controlScreenSkin.SettingScreenSkin(this._detailInput);

            this.panel_DetailInput.Controls.Add(this._detailInput);
            this._detailInput.Dock = DockStyle.Fill;

            // �{�^�������ݒ菈��
            this.ButtonInitialSetting();

            this._campaignObjGoodsStAcs.LoadMstData();
            // ------------------- ADD Redmine#23556 2011/08/12 ------------------------>>>>>
            while (this._campaignObjGoodsStAcs.MasterAcsThread.ThreadState == System.Threading.ThreadState.Running)
            {
                Thread.Sleep(100);
            }
            while (this._campaignObjGoodsStAcs.GoodsAcsThread.ThreadState == System.Threading.ThreadState.Running)
            {
                Thread.Sleep(100);
            }
            // ------------------- ADD Redmine#23556 2011/08/12 ------------------------<<<<<

            // �����T�C�Y�ݒ�
            for (int i = 0; i < this._fontpitchSize.Length; i++)
            {
                this.tComboEditor_StatusBar_FontSize.Items.Add(this._fontpitchSize[i], this._fontpitchSize[i].ToString());
            }
            // ----- UPD K2011/07/07 ------- >>>>>>>>>
            this.tComboEditor_StatusBar_FontSize.ValueChanged -= tComboEditor_StatusBar_FontSize_ValueChanged;
            if (this._detailInput.UserSetting.OutputStyle != 0)
            {
                this.tComboEditor_StatusBar_FontSize.Text = this._detailInput.UserSetting.OutputStyle.ToString();
                this._detailInput.uGrid_Details.DisplayLayout.Appearance.FontData.SizeInPoints = (float)this._detailInput.UserSetting.OutputStyle;
                this._detailInput.uGrid_Details.Refresh();
            }
            else
            {
                this.tComboEditor_StatusBar_FontSize.Text = CT_DEF_FONT_SIZE.ToString();
                // ---ADD 2011/07/12---------------->>>>>
                this._detailInput.uGrid_Details.DisplayLayout.Appearance.FontData.SizeInPoints = (float)CT_DEF_FONT_SIZE;
                this._detailInput.uGrid_Details.Refresh();
                // ---ADD 2011/07/12----------------<<<<<
            }
            this.tComboEditor_StatusBar_FontSize.ValueChanged += tComboEditor_StatusBar_FontSize_ValueChanged;
            // ----- UPD K2011/07/07 ------- <<<<<<<<<

            this.tEdit_SectionCodeAllowZero.Text = "00";
            this.uLabel_SectionName.Text = "�S��";

            this._detailInput.LoadSettings();  // ADD K2011/07/07
        }

        /// <summary>
        /// �{�^�������ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note       : �{�^�������ݒ菈�����s���܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        private void ButtonInitialSetting()
        {
            //tToolbarsManager_MainMenu
            this.tToolsManager_MainMenu.ImageListSmall = this._imageList16;
            this._closeButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;
            this._searchButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SEARCH;
            this._saveButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SAVE;
            this._clearButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.ALLCANCEL;
            this._guideButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.GUIDE;
            this._reNewalButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.RENEWAL;
            this._loginNameLabel.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.EMPLOYEE;
            // DEL 2015/06/02 ���� ���������i�ݒ�ďo���̎g�p��~ ----------------------------------->>>>>
            //// ADD 2015/01/29 ���� ���������i�ݒ�ďo���ǉ� ----------------------------------->>>>>
            //this._recBgnItmStButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SETUP1;
            //// ADD 2015/01/29 ���� ���������i�ݒ�ďo���ǉ� -----------------------------------<<<<<
            // DEL 2015/06/02 ���� ���������i�ݒ�ďo���̎g�p��~ -----------------------------------<<<<<
            
            #region �K�C�h�{�^��
            this.uButton_CampaignGuide.ImageList = this._imageList16;
            this.uButton_CampaignGuide.Appearance.Image = (int)Size16_Index.STAR1;

            this.uButton_SectionGuide.ImageList = this._imageList16;
            this.uButton_SectionGuide.Appearance.Image = (int)Size16_Index.STAR1;

            this.uButton_SalesCodeSt.ImageList = this._imageList16;
            this.uButton_SalesCodeSt.Appearance.Image = (int)Size16_Index.STAR1;
            this.uButton_SalesCodeEd.ImageList = this._imageList16;
            this.uButton_SalesCodeEd.Appearance.Image = (int)Size16_Index.STAR1;

            this.uButton_BlGoodsCodeSt.ImageList = this._imageList16;
            this.uButton_BlGoodsCodeSt.Appearance.Image = (int)Size16_Index.STAR1;
            this.uButton_BlGoodsCodeEd.ImageList = this._imageList16;
            this.uButton_BlGoodsCodeEd.Appearance.Image = (int)Size16_Index.STAR1;

            this.uButton_BLGroupCdSt.ImageList = this._imageList16;
            this.uButton_BLGroupCdSt.Appearance.Image = (int)Size16_Index.STAR1;
            this.uButton_BLGroupCdEd.ImageList = this._imageList16;
            this.uButton_BLGroupCdEd.Appearance.Image = (int)Size16_Index.STAR1;

            this.uButton_MakerCdSt.ImageList = this._imageList16;
            this.uButton_MakerCdSt.Appearance.Image = (int)Size16_Index.STAR1;
            this.uButton_MakerCdEd.ImageList = this._imageList16;
            this.uButton_MakerCdEd.Appearance.Image = (int)Size16_Index.STAR1;
            #endregion
        }

        /// <summary>
        /// �t�H�[�J�X�ϊ�����
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : �t�H�[�J�X�ϊ������B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null || e.NextCtrl == null) return;

            // �t�b�^���ڂֈړ������ꍇ�͈ړ��L�����Z��
            if (e.NextCtrl == this.tComboEditor_StatusBar_FontSize)
            {
                if (!e.ShiftKey && (e.Key == Keys.Down || e.Key == Keys.Right || e.Key == Keys.Tab || e.Key == Keys.Return))
                {
                    e.NextCtrl = e.PrevCtrl;
                    return;
                }
            }
            
            // ���O�ɂ�蕪��
            switch (e.PrevCtrl.Name)
            {
                #region ���ו�
                case "uGrid_Details":
                    {
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                            {
                                this._detailInput.ReturnKeyDown(ref e);
                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                            {
                                if (this._detailInput.uGrid_Details.ActiveCell != null)
                                {
                                    if (this._detailInput.uGrid_Details.ActiveCell.Row.Index == 0)
                                    {
                                        if (this._detailInput.uGrid_Details.ActiveCell.Column.Key == this._campaignObjGoodsStAcs.CampaignMngDataTable.CampaignCodeColumn.ColumnName)
                                        {
                                            this._detailInput.uGrid_Details.ActiveCell.Selected = false;
                                            this._detailInput.uGrid_Details.ActiveCell = null;
                                            if (this._detailInput.uGrid_Details.ActiveRow != null)
                                            {
                                                this._detailInput.uGrid_Details.ActiveRow.Selected = false;
                                                this._detailInput.uGrid_Details.ActiveRow = null;
                                            }
                                            if (this.uExGroupBox_ExtraCondition.Expanded == true)
                                            {
                                                e.NextCtrl = this.tComboEditor_PriceFl;
                                            }
                                            else
                                            {
                                                e.NextCtrl = this.tEdit_SectionCodeAllowZero;
                                            }
                                            break;
                                        }
                                        else if (this._campaignObjGoodsStAcs.PrevCampaignMngDic.Count > 0
                                            && this._detailInput.uGrid_Details.ActiveCell.Column.Key == this._campaignObjGoodsStAcs.CampaignMngDataTable.SectionCodeColumn.ColumnName)
                                        {
                                            this._detailInput.uGrid_Details.ActiveCell.Selected = false;
                                            this._detailInput.uGrid_Details.ActiveCell = null;
                                            if (this._detailInput.uGrid_Details.ActiveRow != null)
                                            {
                                                this._detailInput.uGrid_Details.ActiveRow.Selected = false;
                                                this._detailInput.uGrid_Details.ActiveRow = null;
                                            }
                                            if (this.uExGroupBox_ExtraCondition.Expanded == true)
                                            {
                                                e.NextCtrl = this.tComboEditor_PriceFl;
                                            }
                                            else
                                            {
                                                e.NextCtrl = this.tEdit_SectionCodeAllowZero;
                                            }
                                            break;
                                        }
                                        else if (this._campaignObjGoodsStAcs.PrevCampaignMngDic != null
                                            && this._campaignObjGoodsStAcs.PrevCampaignMngDic.Count <= 0
                                            && this._detailInput.uGrid_Details.ActiveCell.Column.Key == this._campaignObjGoodsStAcs.CampaignMngDataTable.CampaignCodeColumn.ColumnName)
                                        {
                                            this._detailInput.uGrid_Details.ActiveCell.Selected = false;
                                            this._detailInput.uGrid_Details.ActiveCell = null;
                                            if (this._detailInput.uGrid_Details.ActiveRow != null)
                                            {
                                                this._detailInput.uGrid_Details.ActiveRow.Selected = false;
                                                this._detailInput.uGrid_Details.ActiveRow = null;
                                            }
                                            if (this.uExGroupBox_ExtraCondition.Expanded == true)
                                            {
                                                e.NextCtrl = this.tComboEditor_PriceFl;
                                            }
                                            else
                                            {
                                                e.NextCtrl = this.tEdit_SectionCodeAllowZero;
                                            }
                                            break;
                                        }
                                    }
                                }
                                else if (this._detailInput.uGrid_Details.ActiveRow != null)
                                {
                                    if (this._detailInput.uGrid_Details.ActiveRow.Selected && this._detailInput.uGrid_Details.ActiveRow.Index == 0)
                                    {
                                        this._detailInput.uGrid_Details.ActiveRow.Selected = false;
                                        this._detailInput.uGrid_Details.ActiveRow = null;
                                        if (this.uExGroupBox_ExtraCondition.Expanded == true)
                                        {
                                            e.NextCtrl = this.tComboEditor_PriceFl;
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.tEdit_SectionCodeAllowZero;
                                        }
                                        break;
                                    }
                                }

                                this._detailInput.ShiftKeyDown(ref e);
                            }
                        }
                        if (e.NextCtrl != null)
                        {
                            if (e.NextCtrl != this._detailInput.uGrid_Details)
                            {
                                if (this._detailInput.uGrid_Details.ActiveCell != null)
                                {
                                    this._detailInput.uGrid_Details.ActiveCell.Selected = false;
                                    this._detailInput.uGrid_Details.ActiveCell = null;
                                }
                                if (this._detailInput.uGrid_Details.ActiveRow != null)
                                {
                                    this._detailInput.uGrid_Details.ActiveRow.Selected = false;
                                    this._detailInput.uGrid_Details.ActiveRow = null;
                                }
                            }
                        }
                        break;
                    }
                case "PMKHN09621UB":
                    {
                        if (e.NextCtrl != null)
                        {
                            if (e.NextCtrl.Name == "uButton_RowDelete"
                                || e.NextCtrl.Name == "uButton_AllRowDelete"
                                || e.NextCtrl.Name == "uButton_Revival"
                                || e.NextCtrl.Name == "uButton_GetPriceDate"
                                || e.NextCtrl.Name == "_PMKHN09621UA_Toolbars_Dock_Area_Top"
                                || e.NextCtrl.Name == "_PMKHN09621UB_Toolbars_Dock_Area_Top")
                            {
                                break;
                            }
                            if (e.NextCtrl != this._detailInput.uGrid_Details)
                            {
                                if (this._detailInput.uGrid_Details.ActiveCell != null)
                                {
                                    this._detailInput.uGrid_Details.ActiveCell.Selected = false;
                                    this._detailInput.uGrid_Details.ActiveCell = null;
                                }
                                if (this._detailInput.uGrid_Details.ActiveRow != null)
                                {
                                    this._detailInput.uGrid_Details.ActiveRow.Selected = false;
                                    this._detailInput.uGrid_Details.ActiveRow = null;
                                }
                            }
                        }
                        break;
                    }
                #endregion

                #region �L�����y�[���R�[�h
                case "tEdit_CampaignCode":
                    {
                        bool checkFlg = true;
                        int campaignCd = 0;
                        // ��̏ꍇ
                        if (this.tEdit_CampaignCode.Text.Trim() == string.Empty)
                        {
                            this._prevCampaignCd = 0;

                            this.tEdit_CampaignCode.Clear();
                            this.uLabel_CampaignName.Text = string.Empty;
                            this.uLabel_YearSt.Text = string.Empty;
                            this.uLabel_YearEd.Text = string.Empty;
                            this.uLabel_MonthSt.Text = string.Empty;
                            this.uLabel_MonthEd.Text = string.Empty;
                            this.uLabel_DateSt.Text = string.Empty;
                            this.uLabel_DateEd.Text = string.Empty;
                            this.uLabel_ObjCustomerDiv.Text = string.Empty;
                        }
                        // �O��l�ƕs���̏ꍇ
                        else if (!this._prevCampaignCd.ToString().PadLeft(6, '0').Equals(this.tEdit_CampaignCode.Text.Trim().PadLeft(6, '0')))
                        {
                            if (int.TryParse(this.tEdit_CampaignCode.Text, out campaignCd))
                            {
                                // �l�𑶍݂̏ꍇ
                                if (this._campaignObjGoodsStAcs.CampaignStDic.ContainsKey(campaignCd))
                                {
                                    CampaignSt campaignSt = null;
                                    campaignSt = this._campaignObjGoodsStAcs.CampaignStDic[campaignCd];

                                    if (campaignSt.LogicalDeleteCode == 0)
                                    {
                                        // ���ʃZ�b�g
                                        this.tEdit_CampaignCode.Text = campaignSt.CampaignCode.ToString().PadLeft(6, '0');
                                        this.uLabel_CampaignName.Text = campaignSt.CampaignName;
                                        this.uLabel_YearSt.Text = campaignSt.ApplyStaDate.Year.ToString().PadLeft(4, '0');
                                        this.uLabel_MonthSt.Text = campaignSt.ApplyStaDate.Month.ToString().PadLeft(2, '0');
                                        this.uLabel_DateSt.Text = campaignSt.ApplyStaDate.Day.ToString().PadLeft(2, '0');
                                        this.uLabel_YearEd.Text = campaignSt.ApplyEndDate.Year.ToString().PadLeft(4, '0');
                                        this.uLabel_MonthEd.Text = campaignSt.ApplyEndDate.Month.ToString().PadLeft(2, '0');
                                        this.uLabel_DateEd.Text = campaignSt.ApplyEndDate.Day.ToString().PadLeft(2, '0');
                                        this.tEdit_SectionCodeAllowZero.Text = campaignSt.SectionCode.Trim().PadLeft(2, '0');
                                        this._prevSectionCd = Convert.ToInt32(campaignSt.SectionCode);
                                        this._prevCampaignCd = campaignSt.CampaignCode;

                                        if (Convert.ToInt32(campaignSt.SectionCode) == 0)
                                        {
                                            this.uLabel_SectionName.Text = "�S��";
                                        }
                                        else
                                        {
                                            SecInfoSet secInfoSet = null;
                                            int statusFlg = this._secInfoSetAcs.Read(out secInfoSet, this._enterpriseCode, campaignSt.SectionCode.Trim());
                                            if (statusFlg == 0)
                                            {
                                                this.uLabel_SectionName.Text = secInfoSet.SectionGuideNm;
                                            }
                                        }

                                        if (campaignSt.CampaignObjDiv == 0)
                                        {
                                            this.uLabel_ObjCustomerDiv.Text = "�S���Ӑ�";
                                        }
                                        else if (campaignSt.CampaignObjDiv == 1)
                                        {
                                            this.uLabel_ObjCustomerDiv.Text = "�w�蓾�Ӑ�";
                                        }
                                        else
                                        {
                                            this.uLabel_ObjCustomerDiv.Text = string.Empty;
                                        }
                                    }
                                    // �l�s���݂̏ꍇ
                                    else
                                    {
                                        TMsgDisp.Show(
                                                this,
                                                emErrorLevel.ERR_LEVEL_INFO,
                                                this.Name,
                                                "�L�����y�[���R�[�h�����݂��܂���B",
                                                -1,
                                                MessageBoxButtons.OK);
                                        if (this._prevCampaignCd != 0)
                                        {
                                            this.tEdit_CampaignCode.Text = this._prevCampaignCd.ToString().PadLeft(6, '0');
                                        }
                                        else
                                        {
                                            this.tEdit_CampaignCode.Text = string.Empty;
                                        }
                                        checkFlg = false;
                                        e.NextCtrl = e.PrevCtrl;
                                    }
                                }
                                // �l�s���݂̏ꍇ
                                else
                                {
                                    TMsgDisp.Show(
                                            this,
                                            emErrorLevel.ERR_LEVEL_INFO,
                                            this.Name,
                                            "�L�����y�[���R�[�h�����݂��܂���B",
                                            -1,
                                            MessageBoxButtons.OK);
                                    if (this._prevCampaignCd != 0)
                                    {
                                        this.tEdit_CampaignCode.Text = this._prevCampaignCd.ToString().PadLeft(6, '0');
                                    }
                                    else
                                    {
                                        this.tEdit_CampaignCode.Text = string.Empty;
                                    }
                                    checkFlg = false;
                                    e.NextCtrl = e.PrevCtrl;
                                }
                            }
                            else
                            {
                                TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_INFO,
                                        this.Name,
                                        "�L�����y�[���R�[�h�����݂��܂���B",
                                        -1,
                                        MessageBoxButtons.OK);
                                if (this._prevCampaignCd != 0)
                                {
                                    this.tEdit_CampaignCode.Text = this._prevCampaignCd.ToString().PadLeft(6, '0');
                                }
                                else
                                {
                                    this.tEdit_CampaignCode.Text = string.Empty;
                                }
                                checkFlg = false;
                                e.NextCtrl = e.PrevCtrl;
                            }
                        }
                        else
                        {
                            if (this._prevCampaignCd != 0)
                            {
                                this.tEdit_CampaignCode.Text = this._prevCampaignCd.ToString().PadLeft(6, '0');
                            }
                            else
                            {
                                this.tEdit_CampaignCode.Text = string.Empty;
                            }
                        }

                        // �t�H�[�J�X�ݒ�
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                if (this.tEdit_CampaignCode.Text == string.Empty)
                                {
                                    e.NextCtrl = this.uButton_CampaignGuide;
                                }
                                else
                                {
                                    e.NextCtrl = this.tEdit_SectionCodeAllowZero;
                                }
                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                e.NextCtrl = e.PrevCtrl;
                            }
                        }

                        if (!checkFlg)
                        {
                            _masterCheckFlg = true;
                            e.NextCtrl = e.PrevCtrl;
                        }
                        else
                        {
                            _masterCheckFlg = false;
                        }
                        break;
                    }
                #endregion

                #region �L�����y�[���R�[�h�K�C�h
                case "uButton_CampaignGuide":
                    {
                        // �t�H�[�J�X�ݒ�
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                 e.NextCtrl = this.tEdit_SectionCodeAllowZero;
                            }
                            else if (e.Key == Keys.Right)
                            {
                                e.NextCtrl = null;
                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                e.NextCtrl = this.tEdit_CampaignCode;
                            }
                        }
                        break;
                    }
                #endregion

                #region ���_
                case "tEdit_SectionCodeAllowZero":
                    {
                        bool checkFlg = true;
                        int sectionCd = 0;
                        // ��̏ꍇ
                        if (this.tEdit_SectionCodeAllowZero.Text.Trim() == string.Empty)
                        {
                            this.tEdit_SectionCodeAllowZero.Text = "00";
                            this.uLabel_SectionName.Text = "�S��";
                            this._prevSectionCd = 0;
                        }
                        // �O��l�ƕs���̏ꍇ
                        else if (!this._prevSectionCd.ToString().PadLeft(2, '0').Equals(this.tEdit_SectionCodeAllowZero.Text.Trim().PadLeft(2, '0')))
                        {
                            if (int.TryParse(this.tEdit_SectionCodeAllowZero.Text, out sectionCd))
                            {
                                if (sectionCd == 0)
                                {
                                    this.tEdit_SectionCodeAllowZero.Text = "00";
                                    this.uLabel_SectionName.Text = "�S��";
                                    this._prevSectionCd = 0;
                                }
                                else
                                {
                                    // �l�𑶍݂̏ꍇ
                                    if (this._campaignObjGoodsStAcs.SecInfoSetDic.ContainsKey(sectionCd.ToString().Trim().PadLeft(2, '0')))
                                    {
                                        SecInfoSet secInfoSet = null;
                                        secInfoSet = this._campaignObjGoodsStAcs.SecInfoSetDic[sectionCd.ToString().Trim().PadLeft(2, '0')];

                                        this.tEdit_SectionCodeAllowZero.Text = sectionCd.ToString().PadLeft(2, '0');
                                        this.uLabel_SectionName.Text = secInfoSet.SectionGuideNm;
                                        this._prevSectionCd = sectionCd;
                                    }
                                    // �l��s���݂̏ꍇ
                                    else
                                    {
                                        TMsgDisp.Show(
                                                this,
                                                emErrorLevel.ERR_LEVEL_INFO,
                                                this.Name,
                                                "���_�����݂��܂���B",
                                                -1,
                                                MessageBoxButtons.OK);
                                        this.tEdit_SectionCodeAllowZero.Text = this._prevSectionCd.ToString();
                                        this.tEdit_SectionCodeAllowZero.SelectAll();
                                        checkFlg = false;
                                        e.NextCtrl = e.PrevCtrl;
                                    }
                                }
                            }
                            else
                            {
                                TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_INFO,
                                        this.Name,
                                        "���_�����݂��܂���B",
                                        -1,
                                        MessageBoxButtons.OK);
                                this.tEdit_SectionCodeAllowZero.Text = this._prevSectionCd.ToString();
                                this.tEdit_SectionCodeAllowZero.SelectAll();
                                checkFlg = false;
                                e.NextCtrl = e.PrevCtrl;
                            }
                        }
                        else
                        {
                            this.tEdit_SectionCodeAllowZero.Text = this.tEdit_SectionCodeAllowZero.Text.Trim().PadLeft(2, '0');
                            if (this.tEdit_SectionCodeAllowZero.Text == "00")
                            {
                                this.uLabel_SectionName.Text = "�S��";
                            }
                            this._prevSectionCd = 0;
                        }

                        // �t�H�[�J�X�ݒ�
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                if (this.uExGroupBox_ExtraCondition.Expanded)
                                {
                                    e.NextCtrl = this.tEdit_SalesCodeSt;
                                }
                                else
                                {
                                    if (checkFlg)
                                    {
                                        this.Search();
                                    }
                                    e.NextCtrl = null;
                                }
                            }
                            else if (e.Key == Keys.Down)
                            {
                                if (!this.uExGroupBox_ExtraCondition.Expanded)
                                {
                                    if (checkFlg)
                                    {
                                        this.Search();
                                    }
                                    e.NextCtrl = null;
                                }
                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                if (this.tEdit_CampaignCode.Text.Trim() == string.Empty)
                                {
                                    e.NextCtrl = this.uButton_CampaignGuide;
                                }
                                else
                                {
                                    e.NextCtrl = this.tEdit_CampaignCode;
                                }
                            }
                        }

                        if (!checkFlg)
                        {
                            _masterCheckFlg = true;
                            e.NextCtrl = e.PrevCtrl;
                        }
                        else
                        {
                            _masterCheckFlg = false;
                        }
                        break;
                    }
                #endregion

                #region ���_�K�C�h
                case "uButton_SectionGuide":
                    {
                        // �t�H�[�J�X�ݒ�
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                            {
                                if (!this.uExGroupBox_ExtraCondition.Expanded)
                                {
                                    this.Search();
                                    e.NextCtrl = null;
                                }
                                else
                                {
                                    e.NextCtrl = this.tEdit_SalesCodeSt;
                                }
                            }
                            else if (e.Key == Keys.Down)
                            {
                                if (!this.uExGroupBox_ExtraCondition.Expanded)
                                {
                                    this.Search();
                                    e.NextCtrl = null;
                                }
                            }
                            else if (e.Key == Keys.Right)
                            {
                                e.NextCtrl = null;
                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                            {
                                e.NextCtrl = this.tEdit_SectionCodeAllowZero;
                            }
                        }
                        break;
                    }
                #endregion

                #region �̔��敪�i�J�n�j
                case "tEdit_SalesCodeSt":
                    {
                        bool hasValue = true;
                        if (!string.Empty.Equals(this.tEdit_SalesCodeSt.Text.Trim()))
                        {
                            this.tEdit_SalesCodeSt.Text = this.tEdit_SalesCodeSt.Text.PadLeft(4, '0');
                        }
                        else
                        {
                            hasValue = false;
                        }

                        // �t�H�[�J�X�ݒ�
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                if (hasValue)
                                {
                                    e.NextCtrl = this.tEdit_SalesCodeEd;
                                }
                                else
                                {
                                    e.NextCtrl = this.uButton_SalesCodeSt;
                                }
                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                e.NextCtrl = this.tEdit_SectionCodeAllowZero;
                            }
                        }
                        break;
                    }
                #endregion

                #region �̔��敪�K�C�h�i�J�n�j
                case "uButton_SalesCodeSt":
                    {
                        // �t�H�[�J�X�ݒ�
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                e.NextCtrl = this.tEdit_SalesCodeEd;
                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                e.NextCtrl = this.tEdit_SalesCodeSt;
                            }
                        }
                        break;
                    }
                #endregion

                #region �̔��敪�i�I���j
                case "tEdit_SalesCodeEd":
                    {
                        bool hasValue = true;
                        if (!string.Empty.Equals(this.tEdit_SalesCodeEd.Text.Trim()))
                        {
                            this.tEdit_SalesCodeEd.Text = this.tEdit_SalesCodeEd.Text.PadLeft(4, '0');
                        }
                        else
                        {
                            hasValue = false;
                        }

                        // �t�H�[�J�X�ݒ�
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                if (hasValue)
                                {
                                    e.NextCtrl = this.tEdit_BlGoodsCodeSt;
                                }
                                else
                                {
                                    e.NextCtrl = this.uButton_SalesCodeEd;
                                }
                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                if (this.tEdit_SalesCodeSt.Text == string.Empty)
                                {
                                    e.NextCtrl = this.uButton_SalesCodeSt;
                                }
                                else
                                {
                                    e.NextCtrl = this.tEdit_SalesCodeSt; 
                                }
                            }
                        }
                        break;
                    }
                #endregion

                #region �̔��敪�K�C�h�i�I���j
                case "uButton_SalesCodeEd":
                    {
                        // �t�H�[�J�X�ݒ�
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                e.NextCtrl = this.tEdit_BlGoodsCodeSt;
                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                e.NextCtrl = this.tEdit_SalesCodeEd;
                            }
                        }
                        break;
                    }
                #endregion

                #region �a�k�R�[�h�i�J�n�j
                case "tEdit_BlGoodsCodeSt":
                    {
                        bool hasValue = true;
                        if (!string.Empty.Equals(this.tEdit_BlGoodsCodeSt.Text.Trim()))
                        {
                            this.tEdit_BlGoodsCodeSt.Text = this.tEdit_BlGoodsCodeSt.Text.PadLeft(5, '0');
                        }
                        else
                        {
                            hasValue = false;
                        }

                        // �t�H�[�J�X�ݒ�
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                if (hasValue)
                                {
                                    e.NextCtrl = this.tEdit_BlGoodsCodeEd;
                                }
                                else
                                {
                                    e.NextCtrl = this.uButton_BlGoodsCodeSt;
                                }
                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                if (this.tEdit_SalesCodeEd.Text == string.Empty)
                                {
                                    e.NextCtrl = this.uButton_SalesCodeEd;
                                }
                                else
                                {
                                    e.NextCtrl = this.tEdit_SalesCodeEd;
                                }
                            }
                        }
                        break;
                    }
                #endregion

                #region �a�k�R�[�h�K�C�h�i�J�n�j
                case "uButton_BlGoodsCodeSt":
                    {
                        // �t�H�[�J�X�ݒ�
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                e.NextCtrl = this.tEdit_BlGoodsCodeEd;
                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                e.NextCtrl = this.tEdit_BlGoodsCodeSt;
                            }
                        }
                        break;
                    }
                #endregion

                #region �a�k�R�[�h�i�I���j
                case "tEdit_BlGoodsCodeEd":
                    {
                        bool hasValue = true;
                        if (!string.Empty.Equals(this.tEdit_BlGoodsCodeEd.Text.Trim()))
                        {
                            this.tEdit_BlGoodsCodeEd.Text = this.tEdit_BlGoodsCodeEd.Text.PadLeft(5, '0');
                        }
                        else
                        {
                            hasValue = false;
                        }

                        // �t�H�[�J�X�ݒ�
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                if (hasValue)
                                {
                                    e.NextCtrl = this.tEdit_GoodsNo;
                                }
                                else
                                {
                                    e.NextCtrl = this.uButton_BlGoodsCodeEd;
                                }
                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                if (this.tEdit_BlGoodsCodeSt.Text == string.Empty)
                                {
                                    e.NextCtrl = this.uButton_BlGoodsCodeSt;
                                }
                                else
                                {
                                    e.NextCtrl = this.tEdit_BlGoodsCodeSt;
                                }
                            }
                        }
                        break;
                    }
                #endregion

                #region �a�k�R�[�h�K�C�h�i�I���j
                case "uButton_BlGoodsCodeEd":
                    {
                        // �t�H�[�J�X�ݒ�
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                e.NextCtrl = this.tEdit_GoodsNo;
                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                e.NextCtrl = this.tEdit_BlGoodsCodeEd;
                            }
                        }
                        break;
                    }
                #endregion

                #region �i��*
                case "tEdit_GoodsNo":
                    {
                        // �t�H�[�J�X�ݒ�
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                e.NextCtrl = this.tEdit_BLGroupCdSt;
                            }
                            else if (e.Key == Keys.Down)
                            {
                                this.Search();
                                e.NextCtrl = null;
                            }
                            else if (e.Key == Keys.Up)
                            {
                                e.NextCtrl = this.tEdit_BlGoodsCodeSt;
                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                if (this.tEdit_BlGoodsCodeEd.Text == string.Empty)
                                {
                                    e.NextCtrl = this.uButton_BlGoodsCodeEd;
                                }
                                else
                                {
                                    e.NextCtrl = this.tEdit_BlGoodsCodeEd;
                                }
                            }
                        }
                        break;
                    }
                #endregion

                #region �O���[�v�i�J�n�j
                case "tEdit_BLGroupCdSt":
                    {
                        bool hasValue = true;
                        if (!string.Empty.Equals(this.tEdit_BLGroupCdSt.Text.Trim()))
                        {
                            this.tEdit_BLGroupCdSt.Text = this.tEdit_BLGroupCdSt.Text.PadLeft(5, '0');
                        }
                        else
                        {
                            hasValue = false;
                        }

                        // �t�H�[�J�X�ݒ�
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                if (hasValue)
                                {
                                    e.NextCtrl = this.tEdit_BLGroupCdEd;
                                }
                                else
                                {
                                    e.NextCtrl = this.uButton_BLGroupCdSt;
                                }
                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                e.NextCtrl = this.tEdit_GoodsNo;
                            }
                        }
                        break;
                    }
                #endregion

                #region �O���[�v�K�C�h�i�J�n�j
                case "uButton_BLGroupCdSt":
                    {
                        // �t�H�[�J�X�ݒ�
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                e.NextCtrl = this.tEdit_BLGroupCdEd;
                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                e.NextCtrl = this.tEdit_BLGroupCdSt;
                            }
                        }
                        break;
                    }
                #endregion

                #region �O���[�v�i�I���j
                case "tEdit_BLGroupCdEd":
                    {
                        bool hasValue = true;
                        if (!string.Empty.Equals(this.tEdit_BLGroupCdEd.Text.Trim()))
                        {
                            this.tEdit_BLGroupCdEd.Text = this.tEdit_BLGroupCdEd.Text.PadLeft(5, '0');
                        }
                        else
                        {
                            hasValue = false;
                        }

                        // �t�H�[�J�X�ݒ�
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                if (hasValue)
                                {
                                    e.NextCtrl = this.tEdit_MakerCdSt;
                                }
                                else
                                {
                                    e.NextCtrl = this.uButton_BLGroupCdEd;
                                }
                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                if (this.tEdit_BLGroupCdSt.Text == string.Empty)
                                {
                                    e.NextCtrl = this.uButton_BLGroupCdSt;
                                }
                                else
                                {
                                    e.NextCtrl = this.tEdit_BLGroupCdSt; 
                                }
                            }
                        }
                        break;
                    }
                #endregion

                #region �O���[�v�K�C�h�i�I���j
                case "uButton_BLGroupCdEd":
                    {
                        // �t�H�[�J�X�ݒ�
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                e.NextCtrl = this.tEdit_MakerCdSt;
                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                e.NextCtrl = this.tEdit_BLGroupCdEd;
                            }
                        }
                        break;
                    }
                #endregion

                #region ���[�J�[�i�J�n�j
                case "tEdit_MakerCdSt":
                    {
                        bool hasValue = true;
                        if (!string.Empty.Equals(this.tEdit_MakerCdSt.Text.Trim()))
                        {
                            this.tEdit_MakerCdSt.Text = this.tEdit_MakerCdSt.Text.PadLeft(4, '0');
                        }
                        else
                        {
                            hasValue = false;
                        }

                        // �t�H�[�J�X�ݒ�
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                if (hasValue)
                                {
                                    e.NextCtrl = this.tEdit_MakerCdEd;
                                }
                                else
                                {
                                    e.NextCtrl = this.uButton_MakerCdSt;
                                }
                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                if (this.tEdit_BLGroupCdEd.Text == string.Empty)
                                {
                                    e.NextCtrl = this.uButton_BLGroupCdEd;
                                }
                                else
                                {
                                    e.NextCtrl = this.tEdit_BLGroupCdEd;
                                }
                            }
                        }
                        break;
                    }
                #endregion

                #region ���[�J�[�K�C�h�i�J�n�j
                case "uButton_MakerCdSt":
                    {
                        // �t�H�[�J�X�ݒ�
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                e.NextCtrl = this.tEdit_MakerCdEd;
                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                e.NextCtrl = this.tEdit_MakerCdSt;
                            }
                        }
                        break;
                    }
                #endregion

                #region ���[�J�[�i�I���j
                case "tEdit_MakerCdEd":
                    {
                        bool hasValue = true;
                        if (!string.Empty.Equals(this.tEdit_MakerCdEd.Text.Trim()))
                        {
                            this.tEdit_MakerCdEd.Text = this.tEdit_MakerCdEd.Text.PadLeft(4, '0');
                        }
                        else
                        {
                            hasValue = false;
                        }

                        // �t�H�[�J�X�ݒ�
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                if (hasValue)
                                {
                                    e.NextCtrl = this.tComboEditor_DeleteFlag;
                                }
                                else
                                {
                                    e.NextCtrl = this.uButton_MakerCdEd;
                                }
                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                if (this.tEdit_MakerCdSt.Text == string.Empty)
                                {
                                    e.NextCtrl = this.uButton_MakerCdSt;
                                }
                                else
                                {
                                    e.NextCtrl = this.tEdit_MakerCdSt;
                                }
                            }
                        }
                        break;
                    }
                #endregion

                #region ���[�J�[�K�C�h�i�I���j
                case "uButton_MakerCdEd":
                    {
                        // �t�H�[�J�X�ݒ�
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                e.NextCtrl = this.tComboEditor_DeleteFlag;
                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                e.NextCtrl = this.tEdit_MakerCdEd;
                            }
                        }
                        break;
                    }
                #endregion

                #region �폜�w��敪
                case "tComboEditor_DeleteFlag":
                    {
                        // �t�H�[�J�X�ݒ�
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                e.NextCtrl = this.tEdit_DiscountRate;
                            }
                            else if (e.Key == Keys.Down)
                            {
                                this.Search();
                                e.NextCtrl = null;
                            }
                            else if (e.Key == Keys.Up)
                            {
                                e.NextCtrl = this.tEdit_MakerCdSt;
                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                if (this.tEdit_MakerCdEd.Text == string.Empty)
                                {
                                    e.NextCtrl = this.uButton_MakerCdEd;
                                }
                                else
                                {
                                    e.NextCtrl = this.tEdit_MakerCdEd;
                                }
                            }
                        }
                        break;
                    }
                #endregion

                #region �l����
                case "tEdit_DiscountRate":
                    {
                        double inputValue = 0;
                        if (double.TryParse(this.tEdit_DiscountRate.Text.Trim(), out inputValue))
                        {
                            if (inputValue == 0.00)
                            {
                                this.tEdit_DiscountRate.Clear();
                            }
                            else
                            {
                                this.tEdit_DiscountRate.Text = inputValue.ToString("#,##0.00");
                            }
                        }
                        else
                        {
                            this.tEdit_DiscountRate.Clear();
                        }


                        // �t�H�[�J�X�ݒ�
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                e.NextCtrl = this.tComboEditor_DiscountRate;
                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                e.NextCtrl = this.tComboEditor_DeleteFlag;
                            }
                        }
                        break;
                    }
                #endregion

                #region �l�����敪
                case "tComboEditor_DiscountRate":
                    {
                        // �t�H�[�J�X�ݒ�
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                e.NextCtrl = this.tEdit_RateVal;
                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                e.NextCtrl = this.tEdit_DiscountRate;
                            }
                        }
                        break;
                    }
                #endregion

                #region ������
                case "tEdit_RateVal":
                    {
                        double inputValue = 0;
                        if (double.TryParse(this.tEdit_RateVal.Text.Trim(), out inputValue))
                        {
                            if (inputValue == 0.00)
                            {
                                this.tEdit_RateVal.Clear();
                            }
                            else
                            {
                                this.tEdit_RateVal.Text = inputValue.ToString("#,##0.00");
                            }
                        }
                        else
                        {
                            this.tEdit_RateVal.Clear();
                        }

                        // �t�H�[�J�X�ݒ�
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                e.NextCtrl = this.tComboEditor_RateVal;
                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                e.NextCtrl = this.tComboEditor_DiscountRate;
                            }
                        }
                        break;
                    }
                #endregion

                #region �������敪
                case "tComboEditor_RateVal":
                    {
                        // �t�H�[�J�X�ݒ�
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                e.NextCtrl = this.tEdit_PriceFl;
                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                e.NextCtrl = this.tEdit_RateVal;
                            }
                        }
                        break;
                    }
                #endregion

                #region �����z
                case "tEdit_PriceFl":
                    {
                        double inputValue = 0;
                        if (double.TryParse(this.tEdit_PriceFl.Text.Trim(), out inputValue))
                        {
                            if (inputValue == 0.00)
                            {
                                this.tEdit_PriceFl.Clear();
                            }
                            else
                            {
                                this.tEdit_PriceFl.Text = inputValue.ToString("#,##0.00");
                            }
                        }
                        else
                        {
                            this.tEdit_PriceFl.Clear();
                        }

                        // �t�H�[�J�X�ݒ�
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                e.NextCtrl = this.tComboEditor_PriceFl;
                            }
                            else if (e.Key == Keys.Down)
                            {
                                this.Search();
                                e.NextCtrl = null;
                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                e.NextCtrl = this.tComboEditor_RateVal;
                            }
                        }
                        break;
                    }
                #endregion

                #region �����z�敪
                case "tComboEditor_PriceFl":
                    {
                        // �t�H�[�J�X�ݒ�
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                this.Search();
                                e.NextCtrl = null;
                            }
                            else if (e.Key == Keys.Down)
                            {
                                this.Search();
                                e.NextCtrl = null;
                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                e.NextCtrl = this.tEdit_PriceFl;
                            }
                        }
                        break;
                    }
                #endregion
            }

            #region ���K�C�h�L�������̐ݒ�
            if (e.NextCtrl == this.uStatusBar_Main)
            {
                e.NextCtrl = e.PrevCtrl;
                return;
            }
            if (e.NextCtrl != null)
            {
                switch (e.NextCtrl.Name)
                {
                    case "tEdit_CampaignCode":
                    case "tEdit_SectionCodeAllowZero":
                    case "tEdit_SalesCodeSt":
                    case "tEdit_SalesCodeEd":
                    case "tEdit_BlGoodsCodeSt":
                    case "tEdit_BlGoodsCodeEd":
                    case "tEdit_BLGroupCdSt":
                    case "tEdit_BLGroupCdEd":
                    case "tEdit_MakerCdSt":
                    case "tEdit_MakerCdEd":
                        SetGuidButton(true);
                        break;
                    case "uGrid_Details":
                        {
                            this._detailInput.SetGridGuid();
                            break;
                        }
                    case "_PMKHN09621UA_Toolbars_Dock_Area_Top":
                    case "_PMKHN09621UB_Toolbars_Dock_Area_Top":
                        break;
                    default:
                        SetGuidButton(false);
                        break;
                }
            }
            #endregion
        }

        /// <summary>
        /// �t�H�[�����[�h�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note	   : �t�H�[�����ǂݍ��܂ꂽ���ɔ������܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/04/26</br>
        /// <br>UpdateNote : 2011/07/14 ������ Redmine#22984 �ŏI�s�̏�񂪃f�[�^�o�^����Ȃ�</br>
        /// </remarks>
        private void tToolsManager_MainMenu_ToolClick(object sender, ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                // �I��
                case TOOLBAR_CLOSEBUTTON_KEY:
                    {
                        this.Close(true);
                        break;
                    }
                // ����
                case TOOLBAR_SEARCHBUTTON_KEY:
                    {
                        if (this.tEdit_CampaignCode.Focused)
                        {
                            this.tArrowKeyControl1_ChangeFocus(null, new ChangeFocusEventArgs(false, false, false, Keys.Enter, this.tEdit_CampaignCode, this.tEdit_CampaignCode));
                        }
                        else if (this.tEdit_SectionCodeAllowZero.Focused)
                        {
                            this.tArrowKeyControl1_ChangeFocus(null, new ChangeFocusEventArgs(false, false, false, Keys.Up, this.tEdit_SectionCodeAllowZero, this.tEdit_SectionCodeAllowZero));
                        }
                        if (this._masterCheckFlg == true)
                        {
                            this._masterCheckFlg = false;
                            return;
                        }
                        this.uLabel_SectionName.Focus();
                        this._isButtonClick = true;
                        this.Search();
                        break;
                    }
                // �ۑ�
                case TOOLBAR_SAVEBUTTON_KEY:
                    {
                        this._detailInput.uGrid_Details.PerformAction(UltraGridAction.ExitEditMode);
                        if (this._detailInput.FocusFlg == false)
                        {
                            this._detailInput.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                        }

                        this.Save();
                        break;
                    }
                // �N���A
                case TOOLBAR_CLEARBUTTON_KEY:
                    {
                        this.Clear();
                        // ---ADD 2011/07/14------------->>>>>
                        CampaignObjGoodsSt campaignObjGoodsSt = null;
                        this._campaignObjGoodsStAcs.CopyToCampaignMngFromDetailRow((CampaignMngDataSet.CampaignMngRow)this._campaignObjGoodsStAcs.CampaignMngDataTable.Rows[this._campaignObjGoodsStAcs.CampaignMngDataTable.Count - 1], ref campaignObjGoodsSt);
                        this._campaignObjGoodsStAcs.NewCampaignObj = campaignObjGoodsSt.Clone();
                        // ---ADD 2011/07/14-------------<<<<<
                        break;
                    }
                // �K�C�h
                case TOOLBAR_GUIDEBUTTON_KEY:
                    {
                        this.GuideStart();
                        break;
                    }
                // �ŐV���
                case TOOLBAR_RENEWALBUTTON_KEY:
                    {
                        this.ReNewal();
                        break;
                    }
                case TOOLBAR_SHOWMASTERBUTTON_KEY:
                    {
                        //�N�����p�X
                        string directoryName = Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]);

                        if (directoryName.Length > 0)
                        {
                            if (directoryName[directoryName.Length - 1] != '\\')
                            {
                                directoryName = directoryName + "\\";
                            }
                        }
                        string startInfoFileName = directoryName + "SFCMN09000U.EXE";

                        //�N�����p�����[�^
                        string param = Environment.GetCommandLineArgs()[1] + " " +
                                       Environment.GetCommandLineArgs()[2];

                        Process.Start(startInfoFileName, param + " " + "22");

                        break;
                    }
                // DEL 2015/06/02 ���� ���������i�ݒ�ďo���̎g�p��~ ----------------------------------->>>>>
                //// ADD 2015/01/29 ���� ���������i�ݒ�ďo���ǉ� ----------------------------------->>>>>
                //// ���������i�ݒ�
                //case TOOLBAR_SHORECBGNITMST_KEY:
                //    {
                //        //�N�����p�X
                //        string directoryName = Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]);

                //        if (directoryName.Length > 0)
                //        {
                //            if (directoryName[directoryName.Length - 1] != '\\')
                //            {
                //                directoryName = directoryName + "\\";
                //            }
                //        }
                //        string startInfoFileName = directoryName + "PMREC09020U.EXE";

                //        //�N�����p�����[�^
                //        string param = Environment.GetCommandLineArgs()[1] + " " +
                //                       Environment.GetCommandLineArgs()[2];

                //        Process.Start(startInfoFileName, param);

                //        break;
                //    }
                //// ADD 2015/01/29 ���� ���������i�ݒ�ďo���ǉ� -----------------------------------<<<<<
                // DEL 2015/06/02 ���� ���������i�ݒ�ďo���̎g�p��~ -----------------------------------<<<<<
            }
        }

        /// <summary>
        /// �L�����y�[���R�[�h�K�C�h�{�^��
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : �L�����y�[���R�[�h�C�h�{�^��</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        private void uButton_CampaignGuide_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                CampaignSt campaignSt;

                // �K�C�h�N��
                int status = this._campaignLinkAcs.CampaignStAcs.ExecuteGuid(this._enterpriseCode, out campaignSt);
                if (status == 0)
                {
                    SecInfoSet secInfoSet;
                    CampaignSt campaignStObj;
                    int sts = this._campaignLinkAcs.CampaignStAcs.Read(out campaignStObj, this._enterpriseCode, campaignSt.CampaignCode);

                    if (sts == 0)
                    {
                        // ���ʃZ�b�g
                        this.tEdit_CampaignCode.Text = campaignStObj.CampaignCode.ToString().PadLeft(6, '0');
                        this.uLabel_CampaignName.Text = campaignStObj.CampaignName;
                        this.uLabel_YearSt.Text = campaignStObj.ApplyStaDate.Year.ToString().PadLeft(4, '0');
                        this.uLabel_MonthSt.Text = campaignStObj.ApplyStaDate.Month.ToString().PadLeft(2, '0');
                        this.uLabel_DateSt.Text = campaignStObj.ApplyStaDate.Day.ToString().PadLeft(2, '0');
                        this.uLabel_YearEd.Text = campaignStObj.ApplyEndDate.Year.ToString().PadLeft(4, '0');
                        this.uLabel_MonthEd.Text = campaignStObj.ApplyEndDate.Month.ToString().PadLeft(2, '0');
                        this.uLabel_DateEd.Text = campaignStObj.ApplyEndDate.Day.ToString().PadLeft(2, '0');
                        this.tEdit_SectionCodeAllowZero.Text = campaignStObj.SectionCode.Trim().PadLeft(2, '0');
                        this._prevSectionCd = Convert.ToInt32(campaignStObj.SectionCode);
                        this._prevCampaignCd = campaignStObj.CampaignCode;

                        if (Convert.ToInt32(campaignStObj.SectionCode) == 0)
                        {
                            this.uLabel_SectionName.Text = "�S��";
                        }
                        else
                        {
                            int statusFlg = this._secInfoSetAcs.Read(out secInfoSet, this._enterpriseCode, campaignStObj.SectionCode.Trim());
                            if (statusFlg == 0)
                            {
                                this.uLabel_SectionName.Text = secInfoSet.SectionGuideNm;
                            }
                        }

                        if (campaignStObj.CampaignObjDiv == 0)
                        {
                            this.uLabel_ObjCustomerDiv.Text = "�S���Ӑ�";
                        }
                        else if (campaignStObj.CampaignObjDiv == 1)
                        {
                            this.uLabel_ObjCustomerDiv.Text = "�w�蓾�Ӑ�";
                        }
                        else
                        {
                            this.uLabel_ObjCustomerDiv.Text = string.Empty;
                        }

                        // ���t�H�[�J�X
                        this.tEdit_SectionCodeAllowZero.Focus();
                    }
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// ���_�K�C�h�{�^��
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : ���_�K�C�h�{�^��</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        private void uButton_SectionGuide_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                // ���_�K�C�h�Ăяo��
                SecInfoSet secInfoSet;
                int status = this._secInfoSetAcs.ExecuteGuid(LoginInfoAcquisition.EnterpriseCode, true, out secInfoSet);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // ���ʃZ�b�g
                    this.tEdit_SectionCodeAllowZero.Text = secInfoSet.SectionCode.ToString().Trim().PadLeft(2, '0');
                    this.uLabel_SectionName.Text = secInfoSet.SectionGuideNm;
                    this._prevSectionCd = Convert.ToInt32(secInfoSet.SectionCode);

                    if (sender != null)
                    {
                        if (!this.uExGroupBox_ExtraCondition.Expanded)
                        {
                            // �������s��
                            this.Search();
                        }
                        else
                        {
                            this.tEdit_SalesCodeSt.Focus();
                        }
                    }
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// �̔��敪�K�C�h�{�^��
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : �̔��敪�K�C�h�{�^��</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        private void uButton_SalesCode_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                int userGuideDivCd_SalesCode = 71;  // �̔��敪�F71

                // �R�[�h���疼�̂֕ϊ�
                UserGdHd userGuideHdInfo;
                UserGdBd userGuideBdInfo;
                int status = this._userGuideAcs.ExecuteGuid(this._enterpriseCode, out userGuideHdInfo, out userGuideBdInfo, userGuideDivCd_SalesCode);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    if ((Control)sender == this.tEdit_SalesCodeSt
                        || (Control)sender == this.uButton_SalesCodeSt)
                    {
                        this.tEdit_SalesCodeSt.Text = userGuideBdInfo.GuideCode.ToString().PadLeft(4, '0');
                        this.tEdit_SalesCodeEd.Focus();
                    }
                    else if ((Control)sender == this.tEdit_SalesCodeEd
                        || (Control)sender == this.uButton_SalesCodeEd)
                    {
                        this.tEdit_SalesCodeEd.Text = userGuideBdInfo.GuideCode.ToString().PadLeft(4, '0');
                        this.tEdit_BlGoodsCodeSt.Focus();
                    }
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// BL�R�[�h�K�C�h�{�^��
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : BL�R�[�h�K�C�h�{�^��</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        private void uButton_BlGoodsCode_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                // �R�[�h���疼�̂֕ϊ�
                BLGoodsCdUMnt blGoodsUnit;
                int status = this._blGoodsCdAcs.ExecuteGuid(this._enterpriseCode, out blGoodsUnit);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    if ((Control)sender == this.tEdit_BlGoodsCodeSt
                        || (Control)sender == this.uButton_BlGoodsCodeSt)
                    {
                        this.tEdit_BlGoodsCodeSt.Text = blGoodsUnit.BLGoodsCode.ToString().PadLeft(5, '0');
                        this.tEdit_BlGoodsCodeEd.Focus();
                    }
                    else if ((Control)sender == this.tEdit_BlGoodsCodeEd
                        || (Control)sender == this.uButton_BlGoodsCodeEd)
                    {
                        this.tEdit_BlGoodsCodeEd.Text = blGoodsUnit.BLGoodsCode.ToString().PadLeft(5, '0');
                        this.tEdit_GoodsNo.Focus();
                        this.SetGuidButton(false);
                    }
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// �O���[�v�R�[�h�K�C�h�{�^��
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : �O���[�v�R�[�h�K�C�h�{�^��</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        private void uButton_BLGroupCd_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                // �K�C�h�\��
                BLGroupU blGroupUInfo;
                int status = this._blGroupUAcs.ExecuteGuid(this._enterpriseCode, out blGroupUInfo);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    if ((Control)sender == this.tEdit_BLGroupCdSt
                        || (Control)sender == this.uButton_BLGroupCdSt)
                    {
                        this.tEdit_BLGroupCdSt.Text = blGroupUInfo.BLGroupCode.ToString().PadLeft(5, '0');
                        this.tEdit_BLGroupCdEd.Focus();
                    }
                    else if ((Control)sender == this.tEdit_BLGroupCdEd
                        || (Control)sender == this.uButton_BLGroupCdEd)
                    {
                        this.tEdit_BLGroupCdEd.Text = blGroupUInfo.BLGroupCode.ToString().PadLeft(5, '0');
                        this.tEdit_MakerCdSt.Focus();
                    }
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// ���[�J�[�R�[�h�K�C�h�{�^��
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : ���[�J�[�R�[�h�K�C�h�{�^��</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        private void uButton_MakerCd_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                // �R�[�h���疼�̂֕ϊ�
                MakerUMnt makerInfo;
                int status = this._makerAcs.ExecuteGuid(this._enterpriseCode, out makerInfo);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    if ((Control)sender == this.tEdit_MakerCdSt
                        || (Control)sender == this.uButton_MakerCdSt)
                    {
                        this.tEdit_MakerCdSt.Text = makerInfo.GoodsMakerCd.ToString().PadLeft(4, '0');
                        this.tEdit_MakerCdEd.Focus();
                    }
                    else if ((Control)sender == this.tEdit_MakerCdEd
                        || (Control)sender == this.uButton_MakerCdEd)
                    {
                        this.tEdit_MakerCdEd.Text = makerInfo.GoodsMakerCd.ToString().PadLeft(4, '0');
                        this.tComboEditor_DeleteFlag.Focus();
                        this.SetGuidButton(false);
                    }
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// ���������̓C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : ���������̓C�x���g</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        private void tEdit_RateVal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!this._detailInput.KeyPressNumCheck(6, 2, this.tEdit_RateVal.Text, e.KeyChar, this.tEdit_RateVal.SelectionStart, this.tEdit_RateVal.SelectionLength, false))
            {
                e.Handled = true;
                return;
            }
        }

        /// <summary>
        /// �����z���̓C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : �����z���̓C�x���g</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        private void tEdit_PriceFl_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '-')
            {
                if ((this.tEdit_PriceFl.Text.Contains("-") && this.tEdit_PriceFl.SelectionLength == 14)
                    || (!this.tEdit_PriceFl.Text.Contains("-") && this.tEdit_PriceFl.SelectionLength == 13))
                {
                    return;
                }

                if (this.tEdit_PriceFl.Text.Contains("-") || this.tEdit_PriceFl.SelectionStart != 0)
                {
                    e.Handled = true;
                    return;
                }
            }
            else
            {
                if (e.KeyChar != '.')
                {
                    if (this.tEdit_PriceFl.Text.Contains("-"))
                    {
                        if (this.tEdit_PriceFl.SelectionStart == 11)
                        {
                            e.Handled = true;
                            return;
                        }
                    }
                }

                if (this.tEdit_PriceFl.Text.Contains("-"))
                {
                    if (!this._detailInput.KeyPressNumCheck(14, 2, this.tEdit_PriceFl.Text, e.KeyChar, this.tEdit_PriceFl.SelectionStart, this.tEdit_PriceFl.SelectionLength, true))
                    {
                        e.Handled = true;
                        return;
                    }
                }
                else
                {
                    if (!this._detailInput.KeyPressNumCheck(13, 2, this.tEdit_PriceFl.Text, e.KeyChar, this.tEdit_PriceFl.SelectionStart, this.tEdit_PriceFl.SelectionLength, false))
                    {
                        e.Handled = true;
                        return;
                    }
                }
            }
        }

        /// <summary>
        /// �l�������̓C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : �l�������̓C�x���g</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        private void tEdit_DiscountRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!this._detailInput.KeyPressNumCheck(5, 2, this.tEdit_DiscountRate.Text, e.KeyChar, this.tEdit_DiscountRate.SelectionStart, this.tEdit_DiscountRate.SelectionLength, false))
            {
                e.Handled = true;
                return;
            }
        }

        /// <summary>
        /// �����zAfterEnterEditMode�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : �����z�C�x���g</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        private void tEdit_PriceFl_AfterEnterEditMode(object sender, EventArgs e)
        {
            this.tEdit_PriceFl.Text = this.tEdit_PriceFl.Text.Replace(",", "");
            double inputValue = 0;
            if (double.TryParse(this.tEdit_PriceFl.Text, out inputValue))
            {
                this.tEdit_PriceFl.Text = inputValue.ToString();
                this.tEdit_PriceFl.SelectAll();
            }
            else
            {
                this.tEdit_PriceFl.SelectAll();
            }
        }

        /// <summary>
        /// �L�����y�[���R�[�hAfterEnterEditMode�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : �L�����y�[���R�[�h�C�x���g</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        private void tEdit_CampaignCode_AfterEnterEditMode(object sender, EventArgs e)
        {
            this.tEdit_CampaignCode.SelectAll();
        }

        /// <summary>
        /// ���_AfterEnterEditMode�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : ���_�C�x���g</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        private void tEdit_SectionCodeAllowZero_AfterEnterEditMode(object sender, EventArgs e)
        {
            int inputValue = 0;
            if (int.TryParse(this.tEdit_SectionCodeAllowZero.Text, out inputValue))
            {
                this.tEdit_SectionCodeAllowZero.Text = inputValue.ToString();
            }
            else
            {
                this.tEdit_SectionCodeAllowZero.Clear();
            }

            this.tEdit_SectionCodeAllowZero.SelectAll();
        }

        /// <summary>
        /// �̔��敪AfterEnterEditMode�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : �̔��敪�C�x���g</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        private void tEdit_SalesCode_AfterEnterEditMode(object sender, EventArgs e)
        {
            if (((Control)sender).Name == this.tEdit_SalesCodeSt.Name)
            {
                this.tEdit_SalesCodeSt.SelectAll();
            }
            else if (((Control)sender).Name == this.tEdit_SalesCodeEd.Name)
            {
                this.tEdit_SalesCodeEd.SelectAll();
            }
            else
            {
                //�Ȃ��B
            }
        }

        /// <summary>
        /// �a�k�R�[�hAfterEnterEditMode�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : �a�k�R�[�h�C�x���g</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        private void tEdit_BlGoodsCode_AfterEnterEditMode(object sender, EventArgs e)
        {
            if (((Control)sender).Name == this.tEdit_BlGoodsCodeSt.Name)
            {
                this.tEdit_BlGoodsCodeSt.SelectAll();
            }
            else if (((Control)sender).Name == this.tEdit_BlGoodsCodeEd.Name)
            {
                this.tEdit_BlGoodsCodeEd.SelectAll();
            }
            else
            {
                //�Ȃ��B
            }
        }

        /// <summary>
        /// �O���[�v�R�[�hAfterEnterEditMode�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : �O���[�v�R�[�h�C�x���g</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        private void tEdit_BLGroupCd_AfterEnterEditMode(object sender, EventArgs e)
        {
            if (((Control)sender).Name == this.tEdit_BLGroupCdSt.Name)
            {
                this.tEdit_BLGroupCdSt.SelectAll();
            }
            else if (((Control)sender).Name == this.tEdit_BLGroupCdEd.Name)
            {
                this.tEdit_BLGroupCdEd.SelectAll();
            }
            else
            {
                //�Ȃ��B
            }
        }

        /// <summary>
        /// ���[�J�[AfterEnterEditMode�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : ���[�J�[�C�x���g</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        private void tEdit_MakerCd_AfterEnterEditMode(object sender, EventArgs e)
        {
            if (((Control)sender).Name == this.tEdit_MakerCdSt.Name)
            {
                this.tEdit_MakerCdSt.SelectAll();
            }
            else if (((Control)sender).Name == this.tEdit_MakerCdEd.Name)
            {
                this.tEdit_MakerCdEd.SelectAll();
            }
            else
            {
                //�Ȃ��B
            }
        }

        /// <summary>
        /// �l����AfterEnterEditMode�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : �l�����C�x���g</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        private void tEdit_DiscountRate_AfterEnterEditMode(object sender, EventArgs e)
        {
            double inputValue = 0;
            if (double.TryParse(this.tEdit_DiscountRate.Text, out inputValue))
            {
                this.tEdit_DiscountRate.Text = inputValue.ToString();
                this.tEdit_DiscountRate.SelectAll();
            }
            else
            {
                this.tEdit_DiscountRate.SelectAll();
            }
        }

        /// <summary>
        /// ������AfterEnterEditMode�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : �������C�x���g</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        private void tEdit_RateVal_AfterEnterEditMode(object sender, EventArgs e)
        {
            double inputValue = 0;
            if (double.TryParse(this.tEdit_RateVal.Text, out inputValue))
            {
                this.tEdit_RateVal.Text = inputValue.ToString();
                this.tEdit_RateVal.SelectAll();
            }
            else
            {
                this.tEdit_RateVal.SelectAll();
            }
        }

        #region �񕝎�������
        /// <summary>
        /// �񕝎��������`�F�b�N�{�b�N�X�̕ύX
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : �񕝎��������`�F�b�N�{�b�N�X�̕ύX�B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/04/26</br>
        /// <br></br>
        /// </remarks>
        private void uCheckEditor_StatusBar_AutoFillToGridColumn_CheckedChanged(object sender, EventArgs e)
        {
            this._columnWidthAutoAdjust = this.uCheckEditor_StatusBar_AutoFillToGridColumn.Checked;
            autoColumnAdjust(this._columnWidthAutoAdjust);
        }

        /// <summary>
        /// �񕝎�������
        /// </summary>
        /// <param name="autoAdjust">�����������邩�ǂ���</param>
        /// <remarks>
        /// <br>Note       : �񕝎��������B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/04/26</br>
        /// <br>UpdateNote : 2011/07/12 ������ Redmine#22919 �@����N�����̕����T�C�Y�ƍ��ڕ��̕ύX</br>
        /// <br></br>
        /// </remarks>
        private void autoColumnAdjust(bool autoAdjust)
        {
            if (this._detailInput.uGrid_Details.DisplayLayout.AutoFitStyle == Infragistics.Win.UltraWinGrid.AutoFitStyle.None && !autoAdjust ||
                 this._detailInput.uGrid_Details.DisplayLayout.AutoFitStyle != Infragistics.Win.UltraWinGrid.AutoFitStyle.None && autoAdjust) return;

            // ���������v���p�e�B�𒲐�
            if (autoAdjust)
            {
                this._detailInput.uGrid_Details.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;
            }
            else
            {
                this._detailInput.uGrid_Details.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.None;
            }
            // �S�Ă̗�ŃT�C�Y����
            for (int i = 0; i < this._detailInput.uGrid_Details.DisplayLayout.Bands[0].Columns.Count; i++)
            {
                this._detailInput.uGrid_Details.DisplayLayout.Bands[0].Columns[i].PerformAutoResize();
            }
            if (!autoAdjust)
            {
                #region ���\�����ݒ�
                Infragistics.Win.UltraWinGrid.UltraGridBand editBand = this._detailInput.uGrid_Details.DisplayLayout.Bands[0];
                if (editBand == null) return;
                // ---UPD 2011/07/12-------------------->>>>>
                //editBand.Columns[this._campaignObjGoodsStAcs.CampaignMngDataTable.RowNoColumn.ColumnName].Width = 55;		            // ��
                //editBand.Columns[this._campaignObjGoodsStAcs.CampaignMngDataTable.UpdateTimeColumn.ColumnName].Width = 80;		        // �폜��
                //editBand.Columns[this._campaignObjGoodsStAcs.CampaignMngDataTable.CampaignCodeColumn.ColumnName].Width = 70;			    // ����
                //editBand.Columns[this._campaignObjGoodsStAcs.CampaignMngDataTable.CampaignNameColumn.ColumnName].Width = 120;			// ����
                //editBand.Columns[this._campaignObjGoodsStAcs.CampaignMngDataTable.SectionCodeColumn.ColumnName].Width = 40;		    	// ���_
                //editBand.Columns[this._campaignObjGoodsStAcs.CampaignMngDataTable.CampaignSettingKindColumn.ColumnName].Width = 140;		// �ݒ���
                //editBand.Columns[this._campaignObjGoodsStAcs.CampaignMngDataTable.GoodsMakerCodeColumn.ColumnName].Width = 50;		    // Ұ��
                //editBand.Columns[this._campaignObjGoodsStAcs.CampaignMngDataTable.GoodsMakerNameColumn.ColumnName].Width = 180;			// Ұ����
                //editBand.Columns[this._campaignObjGoodsStAcs.CampaignMngDataTable.GoodsNoColumn.ColumnName].Width = 150;	                // �i��
                //editBand.Columns[this._campaignObjGoodsStAcs.CampaignMngDataTable.BLGoodsCodeColumn.ColumnName].Width = 60;		        // BL����
                //editBand.Columns[this._campaignObjGoodsStAcs.CampaignMngDataTable.GoodsNameColumn.ColumnName].Width = 150;				// �i��
                //editBand.Columns[this._campaignObjGoodsStAcs.CampaignMngDataTable.BLGroupCodeColumn.ColumnName].Width = 60;			    // ��ٰ��
                //editBand.Columns[this._campaignObjGoodsStAcs.CampaignMngDataTable.SalesCodeColumn.ColumnName].Width = 80;			    // �̔��敪
                //editBand.Columns[this._campaignObjGoodsStAcs.CampaignMngDataTable.SalesPriceSetDivColumn.ColumnName].Width = 75;		    // �����敪
                //editBand.Columns[this._campaignObjGoodsStAcs.CampaignMngDataTable.CustomerCodeColumn.ColumnName].Width = 80;		        // ���Ӑ�
                //editBand.Columns[this._campaignObjGoodsStAcs.CampaignMngDataTable.DiscountRateColumn.ColumnName].Width = 60;		        // �l����
                //editBand.Columns[this._campaignObjGoodsStAcs.CampaignMngDataTable.RateValColumn.ColumnName].Width = 60;				    // ������
                //editBand.Columns[this._campaignObjGoodsStAcs.CampaignMngDataTable.PriceFlColumn.ColumnName].Width = 150;			        // �����z
                //editBand.Columns[this._campaignObjGoodsStAcs.CampaignMngDataTable.PriceStartDateColumn.ColumnName].Width = 90;			// ���i�J�n��
                //editBand.Columns[this._campaignObjGoodsStAcs.CampaignMngDataTable.PriceEndDateColumn.ColumnName].Width = 90;			// ���i�I����

                editBand.Columns[this._campaignObjGoodsStAcs.CampaignMngDataTable.RowNoColumn.ColumnName].Width = 40;		            // ��
                editBand.Columns[this._campaignObjGoodsStAcs.CampaignMngDataTable.UpdateTimeColumn.ColumnName].Width = 80;		        // �폜��
                editBand.Columns[this._campaignObjGoodsStAcs.CampaignMngDataTable.CampaignCodeColumn.ColumnName].Width = 55;			    // ����
                editBand.Columns[this._campaignObjGoodsStAcs.CampaignMngDataTable.CampaignNameColumn.ColumnName].Width = 120;			// ����
                editBand.Columns[this._campaignObjGoodsStAcs.CampaignMngDataTable.SectionCodeColumn.ColumnName].Width = 35;		    	// ���_
                editBand.Columns[this._campaignObjGoodsStAcs.CampaignMngDataTable.CampaignSettingKindColumn.ColumnName].Width = 125;		// �ݒ���
                editBand.Columns[this._campaignObjGoodsStAcs.CampaignMngDataTable.GoodsMakerCodeColumn.ColumnName].Width = 40;		    // Ұ��
                editBand.Columns[this._campaignObjGoodsStAcs.CampaignMngDataTable.GoodsMakerNameColumn.ColumnName].Width = 85;			// Ұ����
                editBand.Columns[this._campaignObjGoodsStAcs.CampaignMngDataTable.GoodsNoColumn.ColumnName].Width = 115;	                // �i��
                editBand.Columns[this._campaignObjGoodsStAcs.CampaignMngDataTable.BLGoodsCodeColumn.ColumnName].Width = 50;		        // BL����
                editBand.Columns[this._campaignObjGoodsStAcs.CampaignMngDataTable.GoodsNameColumn.ColumnName].Width = 150;				// �i��
                editBand.Columns[this._campaignObjGoodsStAcs.CampaignMngDataTable.BLGroupCodeColumn.ColumnName].Width = 50;			    // ��ٰ��
                editBand.Columns[this._campaignObjGoodsStAcs.CampaignMngDataTable.SalesCodeColumn.ColumnName].Width = 60;			    // �̔��敪
                editBand.Columns[this._campaignObjGoodsStAcs.CampaignMngDataTable.SalesPriceSetDivColumn.ColumnName].Width = 70;		    // �����敪
                editBand.Columns[this._campaignObjGoodsStAcs.CampaignMngDataTable.CustomerCodeColumn.ColumnName].Width = 65;		        // ���Ӑ�
                editBand.Columns[this._campaignObjGoodsStAcs.CampaignMngDataTable.DiscountRateColumn.ColumnName].Width = 50;		        // �l����
                editBand.Columns[this._campaignObjGoodsStAcs.CampaignMngDataTable.RateValColumn.ColumnName].Width = 55;				    // ������
                editBand.Columns[this._campaignObjGoodsStAcs.CampaignMngDataTable.PriceFlColumn.ColumnName].Width = 130;			        // �����z
                editBand.Columns[this._campaignObjGoodsStAcs.CampaignMngDataTable.PriceStartDateColumn.ColumnName].Width = 75;			// ���i�J�n��
                editBand.Columns[this._campaignObjGoodsStAcs.CampaignMngDataTable.PriceEndDateColumn.ColumnName].Width = 75;			// ���i�I����
                // ---UPD 2011/07/12--------------------<<<<<
                #endregion
            }
            return;
        }
        #endregion �񕝎�������

        #region �t�H���g�T�C�Y����
        /// <summary>
        /// �t�H���g�T�C�Y�ύX
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : �t�H���g�T�C�Y�ύX�B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/04/26</br>
        /// <br></br>
        /// </remarks>
        private void tComboEditor_StatusBar_FontSize_ValueChanged(object sender, EventArgs e)
        {
            int a = this.StrToIntDefOfValue(this.tComboEditor_StatusBar_FontSize.Value, CT_DEF_FONT_SIZE);
            float fontPoint = (float)a;

            this._detailInput.uGrid_Details.DisplayLayout.Appearance.FontData.SizeInPoints = fontPoint;
            this._detailInput.uGrid_Details.Refresh();
        }

        /// <summary>
        /// StrToInt�ω�����
        /// </summary>
        /// <param name="obj">obj</param>
        /// <param name="defaultNo">defaultNo</param>
        /// <returns>int</returns>
        /// <remarks>
        /// <br>Note       : StrToInt�ω������B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/04/26</br>
        /// <br></br>
        /// </remarks>
        private int StrToIntDefOfValue(object obj, int defaultNo)
        {
            try
            {
                return (int)obj;
            }
            catch
            {
                return defaultNo;
            }
        }
        #endregion
        #endregion

        #region Private Method
        /// <summary>
        /// ��������
        /// </summary>
        /// <remarks>
        /// <br>Note       : �����������s���܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/04/26</br>
        /// <br>UpdateNote : 2011/07/07 杍^ Redmine#22810 ���E�[�̍��ڂŎ~�܂�悤�ɏC��</br>
        /// <br>UpdateNote : 2011/07/12 ������ Redmine#22919 �A���ׂ̃L�����y�[���R�[�h�ɏ����\������悤�ɕύX</br>
        /// <br>UpdateNote : 2011/07/14 ������ Redmine#22984 �ŏI�s�̏�񂪃f�[�^�o�^����Ȃ�</br>
        /// <br>UpdateNote : 2011/07/21 杍^ Redmine#23199 �w�b�_�ŃL�����y�[���R�[�h����͌�ɁA�������s��A�P�����f�[�^���Ȃ��ꍇ�ɁA���ד��e�w��s���̏C��</br>
        /// </remarks>
        private void Search()
        {
            SearchCondition searchCondition = null;
            // ���������擾����
            this.ScreenToSearchCondition(ref searchCondition);

            if (this._isButtonClick == false)
            {
                if (this._searchCondition != null)
                {
                    if (this._campaignObjGoodsStAcs.CompareSearchCondition(this._searchCondition, searchCondition))
                    {
                        this._detailInput.SetFocusAfterSearch();
                        return;
                    }
                }
            }
            else
            {
                this._isButtonClick = false;
            }


            // �����O�A�`�F�b�N����
            if (!this.SearchCheck(searchCondition))
            {
                return;
            }

            // ���o����ʕ��i�̃C���X�^���X���쐬
            SFCMN00299CA msgForm = new SFCMN00299CA();
            msgForm.Title = "����������";
            msgForm.Message = "�����������ł��B";
            msgForm.Show();

            string errMess = string.Empty;
            int count = 0;
            // ��������
            int status = this._campaignObjGoodsStAcs.Search(searchCondition,out count, out errMess);

            msgForm.Close();

            // �\�[�g�ݒ�̉���
            this._detailInput.uGrid_Details.DisplayLayout.Bands[0].SortedColumns.Clear();
            this._detailInput.uGrid_Details.DisplayLayout.Bands[0].SortedColumns.RefreshSort(true);

            #region ��������
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // ----- ADD 2011/07/07 ------- <<<<<<<<<
                //�폜�w��敪=�ʏ�̏ꍇ
                if (this.tComboEditor_DeleteFlag.SelectedIndex == 0)
                {
                    this._detailInput.LeftFocusFlg = false;
                }
                else
                {
                    this._detailInput.LeftFocusFlg = true;
                }
                // ----- ADD 2011/07/07 ------- >>>>>>>>>

                this._searchCondition = searchCondition;
                // ������A���ו��ݒ菈��
                this._detailInput.GridSettingAfterSearch(this._campaignObjGoodsStAcs.DeleteSearchMode);
                if (this.tComboEditor_DeleteFlag.SelectedIndex == 0)
                {
                    // ---UPD 2011/07/12--------------->>>>>
                    //SetGuidButton(true);

                    if (this.tEdit_CampaignCode.Text.Trim() != string.Empty)
                    {
                        if (this._detailInput.uGrid_Details.Rows.Count > 0)
                        {
                            this._detailInput.uGrid_Details.Rows[this._detailInput.uGrid_Details.Rows.Count - 1].Cells[this._campaignObjGoodsStAcs.CampaignMngDataTable.CampaignCodeColumn.ColumnName].Activate();

                            this._detailInput.uGrid_Details.Rows[this._detailInput.uGrid_Details.Rows.Count - 1].Cells[this._campaignObjGoodsStAcs.CampaignMngDataTable.CampaignCodeColumn.ColumnName].Value = this.tEdit_CampaignCode.Text.Trim().PadLeft(6, '0');
                            this._detailInput.uGrid_Details.Rows[this._detailInput.uGrid_Details.Rows.Count - 1].Cells[this._campaignObjGoodsStAcs.CampaignMngDataTable.CampaignNameColumn.ColumnName].Value = this.uLabel_CampaignName.Text.Trim();
                            this._detailInput.uGrid_Details.Rows[this._detailInput.uGrid_Details.Rows.Count - 1].Cells[this._campaignObjGoodsStAcs.CampaignMngDataTable.SectionCodeColumn.ColumnName].Value = this.tEdit_SectionCodeAllowZero.Text.Trim().PadLeft(2, '0');
                            this._detailInput.uGrid_Details.Rows[this._detailInput.uGrid_Details.Rows.Count - 1].Cells[this._campaignObjGoodsStAcs.CampaignMngDataTable.CampaignSettingKindColumn.ColumnName].Activate();
                            this._detailInput.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                            SetGuidButton(false);
                        }
                        else
                        {
                            SetGuidButton(false);
                        }
                    }
                    else
                    {
                        if (this._detailInput.uGrid_Details.Rows.Count > 0)
                        {
                            this._detailInput.uGrid_Details.Rows[this._detailInput.uGrid_Details.Rows.Count - 1].Cells[this._campaignObjGoodsStAcs.CampaignMngDataTable.CampaignCodeColumn.ColumnName].Activate();
                            this._detailInput.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                            SetGuidButton(true);
                        }
                        else
                        {
                            SetGuidButton(false); 
                        }
                    }
                    // ---ADD 2011/07/14------------->>>>>
                    CampaignObjGoodsSt campaignObjGoodsSt = null;
                    this._campaignObjGoodsStAcs.CopyToCampaignMngFromDetailRow((CampaignMngDataSet.CampaignMngRow)this._campaignObjGoodsStAcs.CampaignMngDataTable.Rows[this._campaignObjGoodsStAcs.CampaignMngDataTable.Count - 1], ref campaignObjGoodsSt);
                    this._campaignObjGoodsStAcs.NewCampaignObj = campaignObjGoodsSt.Clone();
                    // ---ADD 2011/07/14-------------<<<<<
                    // ---UPD 2011/07/12---------------<<<<<
                }
                else
                {
                    SetGuidButton(false);
                }
                if (count > DATA_COUNT_MAX)
                {
                    TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_INFO,
                                this.Name,
                                string.Format("�f�[�^������{0:#,##0}���𒴂��܂����B", DATA_COUNT_MAX) + "\r\n" +
                                "�������i�荞��ōēx�������ĉ������B",
                                0,
                                MessageBoxButtons.OK);
                }
            }
            else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
            {
                TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_INFO,
                            this.Name,
                            "���������ɊY������f�[�^�����݂��܂���B",
                            0,
                            MessageBoxButtons.OK);

                this._searchCondition = searchCondition;

                //�폜�w��敪=�ʏ�̏ꍇ
                if (this.tComboEditor_DeleteFlag.SelectedIndex == 0)
                {
                    this._detailInput.Clear(true);
                    this._detailInput.SetButtonEnabled(1);
                    // ---UPD 2011/07/21--------------->>>>>
                    //this._detailInput.uGrid_Details.Rows[0].Cells[this._campaignObjGoodsStAcs.CampaignMngDataTable.CampaignCodeColumn.ColumnName].Activate();
                    //this._detailInput.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);

                    if (this.tEdit_CampaignCode.Text.Trim() != string.Empty)
                    {
                        if (this._detailInput.uGrid_Details.Rows.Count > 0)
                        {
                            this._detailInput.uGrid_Details.Rows[this._detailInput.uGrid_Details.Rows.Count - 1].Cells[this._campaignObjGoodsStAcs.CampaignMngDataTable.CampaignCodeColumn.ColumnName].Activate();

                            this._detailInput.uGrid_Details.Rows[this._detailInput.uGrid_Details.Rows.Count - 1].Cells[this._campaignObjGoodsStAcs.CampaignMngDataTable.CampaignCodeColumn.ColumnName].Value = this.tEdit_CampaignCode.Text.Trim().PadLeft(6, '0');
                            this._detailInput.uGrid_Details.Rows[this._detailInput.uGrid_Details.Rows.Count - 1].Cells[this._campaignObjGoodsStAcs.CampaignMngDataTable.CampaignNameColumn.ColumnName].Value = this.uLabel_CampaignName.Text.Trim();
                            this._detailInput.uGrid_Details.Rows[this._detailInput.uGrid_Details.Rows.Count - 1].Cells[this._campaignObjGoodsStAcs.CampaignMngDataTable.SectionCodeColumn.ColumnName].Value = this.tEdit_SectionCodeAllowZero.Text.Trim().PadLeft(2, '0');
                            this._detailInput.uGrid_Details.Rows[this._detailInput.uGrid_Details.Rows.Count - 1].Cells[this._campaignObjGoodsStAcs.CampaignMngDataTable.CampaignSettingKindColumn.ColumnName].Activate();
                            this._detailInput.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                            SetGuidButton(false);
                        }
                        else
                        {
                            SetGuidButton(false);
                        }
                    }
                    else
                    {
                        if (this._detailInput.uGrid_Details.Rows.Count > 0)
                        {
                            this._detailInput.uGrid_Details.Rows[this._detailInput.uGrid_Details.Rows.Count - 1].Cells[this._campaignObjGoodsStAcs.CampaignMngDataTable.CampaignCodeColumn.ColumnName].Activate();
                            this._detailInput.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                            SetGuidButton(true);
                        }
                        else
                        {
                            SetGuidButton(false);
                        }
                    }
                    CampaignObjGoodsSt campaignObjGoodsSt = null;
                    this._campaignObjGoodsStAcs.CopyToCampaignMngFromDetailRow((CampaignMngDataSet.CampaignMngRow)this._campaignObjGoodsStAcs.CampaignMngDataTable.Rows[this._campaignObjGoodsStAcs.CampaignMngDataTable.Count - 1], ref campaignObjGoodsSt);
                    this._campaignObjGoodsStAcs.NewCampaignObj = campaignObjGoodsSt.Clone();
                    // ---UPD 2011/07/21---------------<<<<<

                }
                //�폜�w��敪=�폜���݂̂̏ꍇ
                else
                {
                    this._detailInput.SetButtonEnabled(3);

                    this._campaignObjGoodsStAcs.PrevCampaignMngDic.Clear();
                    // ����DataTable�s�N���A����
                    this._campaignObjGoodsStAcs.CampaignMngDataTable.Rows.Clear();

                    this._detailInput.uGrid_Details.DisplayLayout.Bands[0].Columns[this._campaignObjGoodsStAcs.CampaignMngDataTable.UpdateTimeColumn.ColumnName].Hidden = true;

                    this.tEdit_CampaignCode.Focus();
                    SetGuidButton(true);
                }
            }
            else
            {
                // �T�[�`
                TMsgDisp.Show(
                    this, 								// �e�E�B���h�E�t�H�[��
                    emErrorLevel.ERR_LEVEL_STOP, 		// �G���[���x��
                    "PMKHN09621U", 						// �A�Z���u���h�c�܂��̓N���X�h�c
                    "�L�����y�[���Ώۏ��i�ݒ�}�X�^", // �v���O��������
                    "Search", 							// ��������
                    TMsgDisp.OPE_GET, 					// �I�y���[�V����
                    "�ǂݍ��݂Ɏ��s���܂����B", 		// �\�����郁�b�Z�[�W
                    status, 							// �X�e�[�^�X�l
                    this._campaignObjGoodsStAcs, 			// �G���[�����������I�u�W�F�N�g
                    MessageBoxButtons.OK, 				// �\������{�^��
                    MessageBoxDefaultButton.Button1);	// �����\���{�^��
            }
            #endregion
        }

        /// <summary>
        /// �����O�A�`�F�b�N����
        /// </summary>
        /// <param name="searchCondition">��������</param>
        /// <returns>bool</returns>
        /// <remarks>
        /// <br>Note       : �����O�A�`�F�b�N�������s���܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        private bool SearchCheck(SearchCondition searchCondition)
        { 
            List<CampaignObjGoodsSt> deleteList;
            List<CampaignObjGoodsSt> updateList;

            // �폜�w��敪=0�̏ꍇ
            if (this._campaignObjGoodsStAcs.DeleteSearchMode == false)
            {
                // �o�^�f�[�^�擾
                this._detailInput.GetSaveDate(out deleteList, out updateList);
                if (deleteList.Count > 0 || updateList.Count > 0)
                {
                    DialogResult dialogResult = TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_QUESTION,
                        this.Name,
                        "���݁A�ҏW���̃f�[�^�����݂��܂��B" + "\r\n" + "\r\n" +
                        "�j�����Ă���낵���ł����H",
                        0,
                        MessageBoxButtons.YesNo,
                        MessageBoxDefaultButton.Button1);

                    if (dialogResult != DialogResult.Yes) return false;
                }
            }
            // �폜�w��敪=1�̏ꍇ
            else
            {
                // �o�^�f�[�^�擾
                this._detailInput.ReturnSaveDate(out deleteList, out updateList);
                if (deleteList.Count > 0 || updateList.Count > 0)
                {
                    DialogResult dialogResult = TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_QUESTION,
                        this.Name,
                        "���݁A�ҏW���̃f�[�^�����݂��܂��B" + "\r\n" + "\r\n" +
                        "�j�����Ă���낵���ł����H",
                        0,
                        MessageBoxButtons.YesNo,
                        MessageBoxDefaultButton.Button1);

                    if (dialogResult != DialogResult.Yes) return false;
                }
            }


            // �̔��敪�͈̔̓`�F�b�N
            if (searchCondition.SalesCodeSt > searchCondition.SalesCodeEd)
            {
                TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_EXCLAMATION,
                            this.Name,
                            "�̔��敪�͈͎̔w��Ɍ�肪����܂��B",
                            0,
                            MessageBoxButtons.OK);
                this.tEdit_SalesCodeSt.Focus();
                return false;
            }
            // �a�k�R�[�h�͈̔̓`�F�b�N
            if (searchCondition.BLGoodsCodeSt > searchCondition.BLGoodsCodeEd)
            {
                TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_EXCLAMATION,
                            this.Name,
                            "�a�k�R�[�h�͈͎̔w��Ɍ�肪����܂��B",
                            0,
                            MessageBoxButtons.OK);
                this.tEdit_BlGoodsCodeSt.Focus();
                return false;
            }
            // �O���[�v�R�[�h�͈̔̓`�F�b�N
            if (searchCondition.BLGroupCodeSt > searchCondition.BLGroupCodeEd)
            {
                TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_EXCLAMATION,
                            this.Name,
                            "�O���[�v�R�[�h�͈͎̔w��Ɍ�肪����܂��B",
                            0,
                            MessageBoxButtons.OK);
                this.tEdit_BLGroupCdSt.Focus();
                return false;
            }
            // ���[�J�[�͈̔̓`�F�b�N
            if (searchCondition.GoodsMakerCdSt > searchCondition.GoodsMakerCdEd)
            {
                TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_EXCLAMATION,
                            this.Name,
                            "���[�J�[�͈͎̔w��Ɍ�肪����܂��B",
                            0,
                            MessageBoxButtons.OK);
                this.tEdit_MakerCdSt.Focus();
                return false;
            }

            return true;
        }

        /// <summary>
        /// �ۑ�����
        /// </summary>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : �ۑ��������s���܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/04/26</br>
        /// <br>UpdateNote : 2011/07/14 ������ Redmine#22984 �ŏI�s�̏�񂪃f�[�^�o�^����Ȃ�</br>
        /// </remarks>
        private int Save()
        {
            // �}�X�^�f�[�^�Ď擾
            //this._campaignObjGoodsStAcs.LoadMstData();   // DEL Redmine#23556 2011/08/12

            List<CampaignObjGoodsSt> deleteList;
            List<CampaignObjGoodsSt> updateList;

            int status = 0;
            CampaignObjGoodsSt errorCampaignObj = null;
            // �폜�w��敪=0�̏ꍇ
            if (this._campaignObjGoodsStAcs.DeleteSearchMode == false)
            {
                // �o�^�f�[�^�擾
                if (!this._detailInput.CheckSaveDate(out deleteList, out updateList))
                {
                    if (updateList.Count <= 0)
                    {
                        TMsgDisp.Show(
                                    this,
                                    emErrorLevel.ERR_LEVEL_INFO,
                                    this.Name,
                                    "�X�V�Ώۂ̃f�[�^�����݂��܂���B",
                                    0,
                                    MessageBoxButtons.OK);
                    }
                    return -1;
                }

                status = this._campaignObjGoodsStAcs.SaveProc(deleteList, updateList, out errorCampaignObj);

                string errorMsg = string.Empty;
                if (errorCampaignObj != null)
                {
                    if (errorCampaignObj.SalesPriceSetDiv == 0)
                    {
                        switch (errorCampaignObj.CampaignSettingKind)
                        {
                            case 1:
                                {
                                    errorMsg = "����߰ݺ��ށF" + errorCampaignObj.CampaignCode.ToString().PadLeft(6, '0')
                                        + "�A�ݒ��� 1�FҰ��+�i�ԁAҰ���F" + errorCampaignObj.GoodsMakerCd.ToString().PadLeft(4, '0')
                                        + "�A�i�ԁF" + errorCampaignObj.GoodsNo.Trim();
                                    break;
                                }
                            case 2:
                                {
                                    errorMsg = "����߰ݺ��ށF" + errorCampaignObj.CampaignCode.ToString().PadLeft(6, '0')
                                        + "�A�ݒ��� 2�FҰ��+BL���ށAҰ���F" + errorCampaignObj.GoodsMakerCd.ToString().PadLeft(4, '0')
                                        + "�ABL���ށF" + errorCampaignObj.BLGoodsCode.ToString().PadLeft(5, '0');
                                    break;
                                }
                            case 3:
                                {
                                    errorMsg = "����߰ݺ��ށF" + errorCampaignObj.CampaignCode.ToString().PadLeft(6, '0')
                                        + "�A�ݒ��� 3�FҰ��+��ٰ�߁AҰ���F" + errorCampaignObj.GoodsMakerCd.ToString().PadLeft(4, '0')
                                        + "�A��ٰ�߁F" + errorCampaignObj.BLGroupCode.ToString().PadLeft(5, '0');
                                    break;
                                }
                            case 4:
                                {
                                    errorMsg = "����߰ݺ��ށF" + errorCampaignObj.CampaignCode.ToString().PadLeft(6, '0')
                                        + "�A�ݒ��� 4�FҰ���AҰ���F" + errorCampaignObj.GoodsMakerCd.ToString().PadLeft(4, '0');
                                    break;
                                }
                            case 5:
                                {
                                    errorMsg = "����߰ݺ��ށF" + errorCampaignObj.CampaignCode.ToString().PadLeft(6, '0')
                                        + "�A�ݒ��� 5�FBL���ށABL���ށF" + errorCampaignObj.BLGoodsCode.ToString().PadLeft(5, '0');
                                    break;
                                }
                            case 6:
                                {
                                    errorMsg = "����߰ݺ��ށF" + errorCampaignObj.CampaignCode.ToString().PadLeft(6, '0')
                                        + "�A�ݒ��� 6�F�̔��敪�A�̔��敪�F" + errorCampaignObj.SalesCode.ToString().PadLeft(4, '0');
                                    break;
                                } 
                        }
                    }
                    else
                    {
                        switch (errorCampaignObj.CampaignSettingKind)
                        {
                            case 1:
                                {
                                    errorMsg = "����߰ݺ��ށF" + errorCampaignObj.CampaignCode.ToString().PadLeft(6, '0')
                                        + "�A�ݒ��� 1�FҰ��+�i�ԁAҰ���F"+ errorCampaignObj.GoodsMakerCd.ToString().PadLeft(4, '0')
                                        + "�A�i�ԁF" + errorCampaignObj.GoodsNo.Trim()
                                        + "�A���Ӑ�F" + errorCampaignObj.CustomerCode.ToString().PadLeft(8, '0')
                                        + "�A���i���F" + errorCampaignObj.PriceStartDate.ToString().PadLeft(6, '0')
                                        + "�`" + errorCampaignObj.PriceEndDate.ToString().PadLeft(6, '0');
                                    break;
                                }
                            case 2:
                                {
                                    errorMsg = "����߰ݺ��ށF" + errorCampaignObj.CampaignCode.ToString().PadLeft(6, '0')
                                        + "�A�ݒ��� 2�FҰ��+BL���ށAҰ���F"+ errorCampaignObj.GoodsMakerCd.ToString().PadLeft(4, '0')
                                        + "�ABL���ށF" + errorCampaignObj.BLGoodsCode.ToString().PadLeft(5, '0')
                                        + "�A���Ӑ�F" + errorCampaignObj.CustomerCode.ToString().PadLeft(8, '0')
                                        + "�A���i���F" + errorCampaignObj.PriceStartDate.ToString().PadLeft(6, '0')
                                        + "�`" + errorCampaignObj.PriceEndDate.ToString().PadLeft(6, '0');
                                    break;
                                }
                            case 3:
                                {
                                    errorMsg = "����߰ݺ��ށF" + errorCampaignObj.CampaignCode.ToString().PadLeft(6, '0')
                                        + "�A�ݒ��� 3�FҰ��+��ٰ�߁AҰ���F" + errorCampaignObj.GoodsMakerCd.ToString().PadLeft(4, '0')
                                        + "�A��ٰ�߁F" + errorCampaignObj.BLGroupCode.ToString().PadLeft(5, '0')
                                        + "�A���Ӑ�F" + errorCampaignObj.CustomerCode.ToString().PadLeft(8, '0')
                                        + "�A���i���F" + errorCampaignObj.PriceStartDate.ToString().PadLeft(6, '0')
                                        + "�`" + errorCampaignObj.PriceEndDate.ToString().PadLeft(6, '0');
                                    break;
                                }
                            case 4:
                                {
                                    errorMsg = "����߰ݺ��ށF" + errorCampaignObj.CampaignCode.ToString().PadLeft(6, '0')
                                        + "�A�ݒ��� 4�FҰ���AҰ���F" + errorCampaignObj.GoodsMakerCd.ToString().PadLeft(4, '0')
                                        + "�A���Ӑ�F" + errorCampaignObj.CustomerCode.ToString().PadLeft(8, '0')
                                        + "�A���i���F" + errorCampaignObj.PriceStartDate.ToString().PadLeft(6, '0')
                                        + "�`" + errorCampaignObj.PriceEndDate.ToString().PadLeft(6, '0');
                                    break;
                                }
                            case 5:
                                {
                                    errorMsg = "����߰ݺ��ށF" + errorCampaignObj.CampaignCode.ToString().PadLeft(6, '0')
                                        + "�A�ݒ��� 5�FBL���ށABL���ށF" + errorCampaignObj.BLGoodsCode.ToString().PadLeft(5, '0')
                                        + "�A���Ӑ�F" + errorCampaignObj.CustomerCode.ToString().PadLeft(8, '0')
                                        + "�A���i���F" + errorCampaignObj.PriceStartDate.ToString().PadLeft(6, '0')
                                        + "�`" + errorCampaignObj.PriceEndDate.ToString().PadLeft(6, '0');
                                    break;
                                }
                            case 6:
                                {
                                    errorMsg = "����߰ݺ��ށF" + errorCampaignObj.CampaignCode.ToString().PadLeft(6, '0')
                                        + "�A�ݒ��� 6�F�̔��敪�A�̔��敪�F" + errorCampaignObj.SalesCode.ToString().PadLeft(4, '0')
                                        + "�A���Ӑ�F" + errorCampaignObj.CustomerCode.ToString().PadLeft(8, '0')
                                        + "�A���i���F" + errorCampaignObj.PriceStartDate.ToString().PadLeft(6, '0')
                                        + "�`" + errorCampaignObj.PriceEndDate.ToString().PadLeft(6, '0');
                                    break;
                                }
                        }
                    }

                    TMsgDisp.Show(
                         this,
                         emErrorLevel.ERR_LEVEL_EXCLAMATION,
                         this.Name,
                         "����̏��i�ݒ肪���ɓo�^����Ă��܂��B" + "\r\n" +
                         errorMsg,
                         0,
                         MessageBoxButtons.OK);

                    int rowIndex = -1;
                    //�s�ԍ����擾
                    foreach (UltraGridRow row in this._detailInput.uGrid_Details.Rows)
                    {
                        if (errorCampaignObj.RowIndex == (int)row.Cells[this._campaignObjGoodsStAcs.CampaignMngDataTable.RowNoColumn.ColumnName].Value)
                        {
                            rowIndex = row.Index;
                            break;
                        }
                    }

                    if (rowIndex >= 0 && rowIndex < this._detailInput.uGrid_Details.Rows.Count)
                    {
                        this._detailInput.uGrid_Details.Rows[rowIndex].Cells[this._campaignObjGoodsStAcs.CampaignMngDataTable.CampaignCodeColumn.ColumnName].Activate();
                        this._detailInput.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                        return -1;
                    }
                }
            }
            // �폜�w��敪=1�̏ꍇ
            else
            {
                // �o�^�f�[�^�擾
                this._detailInput.ReturnSaveDate(out deleteList, out updateList);

                if (deleteList.Count == 0 && updateList.Count == 0)
                {
                    TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_INFO,
                                this.Name,
                                "�X�V�Ώۂ̃f�[�^�����݂��܂���B",
                                0,
                                MessageBoxButtons.OK);
                    return -1;
                }

                if (deleteList.Count > 0)
                {
                    DialogResult dialogResult = TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_QUESTION,
                                this.Name,
                                "�폜�w�肵���f�[�^�͊��S�폜���܂��B��낵���ł����H",
                                0,
                                MessageBoxButtons.YesNo);

                    if (dialogResult == DialogResult.Yes)
                    {
                        // �Ȃ��B
                    }
                    else
                    {
                        return 0;
                    }
                }

                status = this._campaignObjGoodsStAcs.SaveProc(deleteList, updateList, out errorCampaignObj);
            }

            #region < �o�^�㏈�� >
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        // �o�^�����_�C�A���O�\��
                        SaveCompletionDialog dialog = new SaveCompletionDialog();
                        dialog.ShowDialog(2);

                        //����������������������
                        this.ConditionClear();

                        this._searchCondition = null;

                        // �O���b�h�����ݒ菈��
                        this._detailInput.Clear(true);
                        this.tEdit_CampaignCode.Focus();
                        this.SetGuidButton(true);
                        // ---ADD 2011/07/14------------->>>>>
                        CampaignObjGoodsSt campaignObjGoodsSt = null;
                        this._campaignObjGoodsStAcs.CopyToCampaignMngFromDetailRow((CampaignMngDataSet.CampaignMngRow)this._campaignObjGoodsStAcs.CampaignMngDataTable.Rows[this._campaignObjGoodsStAcs.CampaignMngDataTable.Count - 1], ref campaignObjGoodsSt);
                        this._campaignObjGoodsStAcs.NewCampaignObj = campaignObjGoodsSt.Clone();
                        // ---ADD 2011/07/14-------------<<<<<
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    {
                        TMsgDisp.Show(
                            this, 									// �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_INFO, 			// �G���[���x��
                            "PMKHN09621U",				        	// �A�Z���u���h�c�܂��̓N���X�h�c
                            "�X�V�Ώۂ̃f�[�^�����݂��܂���B",     // �\�����郁�b�Z�[�W 
                            0, 										// �X�e�[�^�X�l
                            MessageBoxButtons.OK);					// �\������{�^��
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_DUPLICATE:
                    {
                        // �R�[�h�d��
                        TMsgDisp.Show(
                            this, 									// �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_INFO, 			// �G���[���x��
                            "PMKHN09621U",				        	// �A�Z���u���h�c�܂��̓N���X�h�c
                            "���̃R�[�h�͊��Ɏg�p����Ă��܂��B",  	// �\�����郁�b�Z�[�W
                            0, 										// �X�e�[�^�X�l
                            MessageBoxButtons.OK);					// �\������{�^��
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    {
                        // ���[���X�V
                        TMsgDisp.Show(
                            this, 								// �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_EXCLAMATION, // �G���[���x��
                            "PMKHN09621U", 						// �A�Z���u���h�c�܂��̓N���X�h�c
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
                            "PMKHN09621U", 						// �A�Z���u���h�c�܂��̓N���X�h�c
                            "���ɑ��[�����폜����Ă��܂��B", // �\�����郁�b�Z�[�W
                            0, 									// �X�e�[�^�X�l
                            MessageBoxButtons.OK);				// �\������{�^��
                        break;
                    }
                default:
                    {
                        TMsgDisp.Show(
                           this,                                 // �e�E�B���h�E�t�H�[��
                           emErrorLevel.ERR_LEVEL_STOP,          // �G���[���x��
                           "PMKHN09621U",                        // �A�Z���u���h�c�܂��̓N���X�h�c
                           "�L�����y�[���Ώۏ��i�ݒ�}�X�^",     // �v���O��������
                           "Save",                               // ��������
                           TMsgDisp.OPE_UPDATE,                  // �I�y���[�V����
                           "�o�^�Ɏ��s���܂����B",               // �\�����郁�b�Z�[�W
                           status,                               // �X�e�[�^�X�l
                           this._campaignObjGoodsStAcs,          // �G���[�����������I�u�W�F�N�g
                           MessageBoxButtons.OK,                 // �\������{�^��
                           MessageBoxDefaultButton.Button1);     // �����\���{�^��
                        break;
                    }
            }
            #endregion

            return status;
        }

        /// <summary>
        /// �N���A����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �N���A�������s���܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        private void Clear()
        {
            bool clearFlg = false;
            #region �N���A�����O�A�ҏW�s�`�F�b�N
            List<CampaignObjGoodsSt> deleteList;
            List<CampaignObjGoodsSt> updateList;

            if (this._campaignObjGoodsStAcs.DeleteSearchMode == false)
            {
                this._detailInput.GetSaveDate(out deleteList, out updateList);
                if (deleteList.Count > 0 || updateList.Count > 0)
                {
                    DialogResult dialogResult = TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_QUESTION,
                        this.Name,
                        "���݁A�ҏW���̃f�[�^�����݂��܂��B" + "\r\n" + "\r\n" +
                        "�o�^���Ă���낵���ł����H",
                        0,
                        MessageBoxButtons.YesNoCancel,
                        MessageBoxDefaultButton.Button1);

                    if (dialogResult == DialogResult.Yes)
                    {
                        if (this.Save() == 0)
                        {
                            clearFlg = true;
                        }
                        else
                        {
                            clearFlg = false;
                        }
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        clearFlg = true;
                    }
                    else if (dialogResult == DialogResult.Cancel)
                    {
                        clearFlg = false;
                    }
                }
                else
                {
                    clearFlg = true;
                }
            }
            else
            {
                this._detailInput.ReturnSaveDate(out deleteList, out updateList);
                if (deleteList.Count > 0 || updateList.Count > 0)
                {
                    DialogResult dialogResult = TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_QUESTION,
                        this.Name,
                        "���݁A�ҏW���̃f�[�^�����݂��܂��B" + "\r\n" + "\r\n" +
                        "�o�^���Ă���낵���ł����H",
                        0,
                        MessageBoxButtons.YesNoCancel,
                        MessageBoxDefaultButton.Button1);

                    if (dialogResult == DialogResult.Yes)
                    {
                        if (this.Save() == 0)
                        {
                            clearFlg = true;
                        }
                        else
                        {
                            clearFlg = false;
                        }
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        clearFlg = true;
                    }
                    else if (dialogResult == DialogResult.Cancel)
                    {
                        clearFlg = false;
                    }
                }
                else
                {
                    clearFlg = true;
                }
            }
            #endregion

            if (clearFlg == true)
            {
                this._searchCondition = null;

                //����������������������
                this.ConditionClear();

                // �O���b�h�����ݒ菈��
                this._detailInput.Clear(true);

                // �\�[�g�ݒ�̉���
                this._detailInput.uGrid_Details.DisplayLayout.Bands[0].SortedColumns.Clear();
                // �����t�H�[�J�X�ݒ�
                this.tEdit_CampaignCode.Focus();
                this.SetGuidButton(true);
            }
        }

        /// <summary>
        /// ����������������������
        /// </summary>
        /// <remarks>
        /// <br>Note       : ����������������������</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        private void ConditionClear()
        {
            #region ��{�����N���A
            this.tEdit_CampaignCode.Clear();
            this.uLabel_CampaignName.Text = string.Empty;
            this.uLabel_YearSt.Text = string.Empty;
            this.uLabel_YearEd.Text = string.Empty;
            this.uLabel_MonthSt.Text = string.Empty;
            this.uLabel_MonthEd.Text = string.Empty;
            this.uLabel_DateSt.Text = string.Empty;
            this.uLabel_DateEd.Text = string.Empty;
            this.tEdit_SectionCodeAllowZero.Text = "00";
            this.uLabel_SectionName.Text = "�S��";
            this.uLabel_ObjCustomerDiv.Text = string.Empty;

            this._prevCampaignCd = 0;
            this._prevSectionCd = 0;
            #endregion

            #region ���o�����N���A
            this.tEdit_SalesCodeSt.Clear();
            this.tEdit_SalesCodeEd.Clear();
            this.tEdit_BlGoodsCodeSt.Clear();
            this.tEdit_BlGoodsCodeEd.Clear();
            this.tEdit_GoodsNo.Clear();
            this.tEdit_BLGroupCdSt.Clear();
            this.tEdit_BLGroupCdEd.Clear();
            this.tEdit_MakerCdSt.Clear();
            this.tEdit_MakerCdEd.Clear();
            this.tComboEditor_DeleteFlag.SelectedIndex = 0;
            this.tComboEditor_RateVal.SelectedIndex = 0;
            this.tComboEditor_PriceFl.SelectedIndex = 0;
            this.tComboEditor_DiscountRate.SelectedIndex = 0;
            this.tEdit_RateVal.Clear();
            this.tEdit_PriceFl.Clear();
            this.tEdit_DiscountRate.Clear();
            #endregion
        }
        
        /// <summary>
        /// ��ʃN���[�Y����
        /// </summary>
        /// <param name="boolean">boolean</param>
        /// <remarks>
        /// <br>Note       : ��ʃN���[�Y�������s���܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        private void Close(bool boolean)
        {
            List<CampaignObjGoodsSt> deleteList;
            List<CampaignObjGoodsSt> updateList;

            if (this._campaignObjGoodsStAcs.DeleteSearchMode == false)
            {
                this._detailInput.GetSaveDate(out deleteList, out updateList);
                if (deleteList.Count > 0 || updateList.Count > 0)
                {
                    DialogResult dialogResult = TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_QUESTION,
                        this.Name,
                        "���݁A�ҏW���̃f�[�^�����݂��܂��B" + "\r\n" + "\r\n" +
                        "�o�^���Ă���낵���ł����H",
                        0,
                        MessageBoxButtons.YesNoCancel,
                        MessageBoxDefaultButton.Button1);

                    if (dialogResult == DialogResult.Yes)
                    {
                        if (this.Save() == 0)
                        {
                            this.Close();
                        }
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        this.Close();
                    }
                    else if (dialogResult == DialogResult.Cancel)
                    {
                        //�Ȃ��B
                    }
                }
                else
                {
                    this.Close();
                }
            }
            else
            {
                this._detailInput.ReturnSaveDate(out deleteList, out updateList);
                if (deleteList.Count > 0 || updateList.Count > 0)
                {
                    DialogResult dialogResult = TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_QUESTION,
                        this.Name,
                        "���݁A�ҏW���̃f�[�^�����݂��܂��B" + "\r\n" + "\r\n" +
                        "�o�^���Ă���낵���ł����H",
                        0,
                        MessageBoxButtons.YesNoCancel,
                        MessageBoxDefaultButton.Button1);

                    if (dialogResult == DialogResult.Yes)
                    {
                        if (this.Save() == 0)
                        {
                            this.Close();
                        }
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        this.Close();
                    }
                    else if (dialogResult == DialogResult.Cancel)
                    {
                        //�Ȃ��B
                    }
                }
                else
                {
                    this.Close();
                }
            }
        }

        // ----- ADD K2011/07/07 ------- >>>>>>>>>
        /// <summary>
        /// �t�H�[���N���[�Y�O����
        /// </summary>
        /// <remarks>FormClosing�C�x���g���Ɓ~�{�^�����ɔ����Ă��܂��̂ŁAParent�ŃE�B���h�E���b�Z�[�W������</remarks>
        public void BeforeFormClose()
        {
            //-----------------------------------------
            // �t�H�[������鎞(�~�{�^�����܂�)
            //-----------------------------------------
            // ���[�U�[�ݒ�ۑ�(��XML��������)
            this._detailInput.SaveSettings((int)this.tComboEditor_StatusBar_FontSize.Value, this.uCheckEditor_StatusBar_AutoFillToGridColumn.Checked);

            this._detailInput.Serialize();
        }
        // ----- ADD K2011/07/07 ------- <<<<<<<<<

        /// <summary>
        /// �K�C�h�N������
        /// </summary>
        /// <remarks>
        /// <br>Note       : �K�C�h�N���������s���܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        private void GuideStart()
        {
            // �L�����y�[���R�[�h
            if (this.tEdit_CampaignCode.Focused)
            {
                this.uButton_CampaignGuide_Click(this.tEdit_CampaignCode, new EventArgs());
            }
            // ���_
            else if (this.tEdit_SectionCodeAllowZero.Focused)
            {
                this.uButton_SectionGuide_Click(this.tEdit_SectionCodeAllowZero, new EventArgs());
            }
            // �̔��敪�i�J�n�j
            else if (this.tEdit_SalesCodeSt.Focused)
            {
                this.uButton_SalesCode_Click(this.tEdit_SalesCodeSt, new EventArgs());
            }
            // �̔��敪�i�I���j
            else if (this.tEdit_SalesCodeEd.Focused)
            {
                this.uButton_SalesCode_Click(this.tEdit_SalesCodeEd, new EventArgs());
            }
            // �a�k�R�[�h�i�J�n�j
            else if (this.tEdit_BlGoodsCodeSt.Focused)
            {
                this.uButton_BlGoodsCode_Click(this.tEdit_BlGoodsCodeSt, new EventArgs());
            }
            // �a�k�R�[�h�i�I���j
            else if (this.tEdit_BlGoodsCodeEd.Focused)
            {
                this.uButton_BlGoodsCode_Click(this.tEdit_BlGoodsCodeEd, new EventArgs());
            }
            // �O���[�v�R�[�h�i�J�n�j
            else if (this.tEdit_BLGroupCdSt.Focused)
            {
                this.uButton_BLGroupCd_Click(this.tEdit_BLGroupCdSt, new EventArgs());
            }
            // �O���[�v�R�[�h�i�I���j
            else if (this.tEdit_BLGroupCdEd.Focused)
            {
                this.uButton_BLGroupCd_Click(this.tEdit_BLGroupCdEd, new EventArgs());
            }
            // ���[�J�[�i�J�n�j
            else if (this.tEdit_MakerCdSt.Focused)
            {
                this.uButton_MakerCd_Click(this.tEdit_MakerCdSt, new EventArgs());
            }
            // ���[�J�[�i�I���j
            else if (this.tEdit_MakerCdEd.Focused)
            {
                this.uButton_MakerCd_Click(this.tEdit_MakerCdEd, new EventArgs());
            }
            // �O���b�h
            else
            {
                int rowIndex = -1;
                string keyName = this._detailInput.GetFocusColumnKey(out rowIndex);
                if (!string.Empty.Equals(keyName))
                {
                    switch (keyName)
                    {
                        case "CampaignCode":
                            {
                                this._detailInput.CampaignCodeGuide(rowIndex);
                                break;
                            }
                        case "SectionCode":
                            {
                                this._detailInput.SectionCodeGuide(rowIndex);
                                break;
                            }
                        case "GoodsMakerCode":
                            {
                                this._detailInput.GoodsMakerCodeGuide(rowIndex);
                                break;
                            }
                        case "BLGoodsCode":
                            {
                                this._detailInput.BLGoodsCodeGuide(rowIndex);
                                break;
                            }
                        case "BLGroupCode":
                            {
                                this._detailInput.BLGroupCodeGuide(rowIndex);
                                break;
                            }
                        case "SalesCode":
                            {
                                this._detailInput.SalesCodeGuide(rowIndex);
                                break;
                            }
                        case "CustomerCode":
                            {
                                this._detailInput.CustomerCodeGuide(rowIndex);
                                break;
                            }
                        default:
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// �ŐV���擾����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �ŐV���擾�������s���܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        private void ReNewal()
        {
            SFCMN00299CA processingDialog = new SFCMN00299CA();
            try
            {
                processingDialog.Title = "�ŐV���擾";
                processingDialog.Message = "���݁A�ŐV���擾���ł��B";
                processingDialog.DispCancelButton = false;
                processingDialog.Show((Form)this.Parent);

                this._campaignObjGoodsStAcs.LoadMstData();
                // ------------------- ADD Redmine#23556 2011/08/12 ------------------------>>>>>
                while (this._campaignObjGoodsStAcs.MasterAcsThread.ThreadState == System.Threading.ThreadState.Running)
                {
                    Thread.Sleep(100);
                }
                while (this._campaignObjGoodsStAcs.GoodsAcsThread.ThreadState == System.Threading.ThreadState.Running)
                {
                    Thread.Sleep(100);
                }
                // ------------------- ADD Redmine#23556 2011/08/12 ------------------------<<<<<
            }
            finally
            {
                processingDialog.Dispose();

                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    "�ŐV�����擾���܂����B�@�@",
                    0,
                    MessageBoxButtons.OK,
                    MessageBoxDefaultButton.Button1);
            }
        }

        /// <summary>
        /// �ڍ׃O���b�h�ŏ�ʍs�A�v�C�x���g����
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : �ڍ׃O���b�h�ŏ�ʍs�A�v�E�����ɔ������܂��B</br>      
        /// <br>Programmer : ������</br>                                  
        /// <br>Date       : 2011/04/26</br> 
        /// </remarks> 
        private void GriedDetail_GridKeyUpTopRow(object sender, EventArgs e)
        {
            Control control = null;
            if (this.uExGroupBox_ExtraCondition.Expanded == false)
            {
                control = this.tEdit_SectionCodeAllowZero;
                this.SetGuidButton(true);
            }
            else
            {
                control = this.tEdit_GoodsNo;
                this.SetGuidButton(false);
            }

            if (control != null)
            {
                control.Focus();
            }

            this._prevControl = this.ActiveControl;
        }

        /// <summary>
        /// �ŐV���擾����
        /// </summary>
        /// <param name="searchCondition">�����������邩�ǂ���</param>
        /// <remarks>
        /// <br>Note       : �ŐV���擾�������s���܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        private void ScreenToSearchCondition(ref SearchCondition searchCondition)
        {
            int code = 0;
            bool flag = false;
            double dd = 0;

            if (searchCondition == null)
            {
                searchCondition = new SearchCondition();
            }

            searchCondition.EnterpriseCode = this._enterpriseCode;

            // �L�����y�[���R�[�h
            flag = int.TryParse(this.tEdit_CampaignCode.Text, out code);
            if (flag)
            {
                searchCondition.CampaignCode = code;
            }
            else
            {
                searchCondition.CampaignCode = 0;
            }

            // ���_
            flag = int.TryParse(this.tEdit_SectionCodeAllowZero.Text, out code);
            if (flag)
            {
                searchCondition.SectionCode = code.ToString();
            }
            else
            {
                searchCondition.SectionCode = "00";
            }

            // �̔��敪�i�J�n�j
            flag = int.TryParse(this.tEdit_SalesCodeSt.Text, out code);
            if (flag)
            {
                searchCondition.SalesCodeSt = code;
            }
            else
            {
                searchCondition.SalesCodeSt = 0;
            }

            // �̔��敪�i�I���j
            flag = int.TryParse(this.tEdit_SalesCodeEd.Text, out code);
            if (flag)
            {
                searchCondition.SalesCodeEd = code;
            }
            else
            {
                searchCondition.SalesCodeEd = 9999;
            }

            // �a�k�R�[�h�i�J�n�j
            flag = int.TryParse(this.tEdit_BlGoodsCodeSt.Text, out code);
            if (flag)
            {
                searchCondition.BLGoodsCodeSt = code;
            }
            else
            {
                searchCondition.BLGoodsCodeSt = 0;
            }

            // �a�k�R�[�h�i�I���j
            flag = int.TryParse(this.tEdit_BlGoodsCodeEd.Text, out code);
            if (flag)
            {
                searchCondition.BLGoodsCodeEd = code;
            }
            else
            {
                searchCondition.BLGoodsCodeEd = 99999;
            }

            // �i��*
            searchCondition.GoodsNo = this.tEdit_GoodsNo.Text.Trim();

            // �O���[�v�R�[�h�i�J�n�j
            flag = int.TryParse(this.tEdit_BLGroupCdSt.Text, out code);
            if (flag)
            {
                searchCondition.BLGroupCodeSt = code;
            }
            else
            {
                searchCondition.BLGroupCodeSt = 0;
            }

            // �O���[�v�R�[�h�i�I���j
            flag = int.TryParse(this.tEdit_BLGroupCdEd.Text, out code);
            if (flag)
            {
                searchCondition.BLGroupCodeEd = code;
            }
            else
            {
                searchCondition.BLGroupCodeEd = 99999;
            }

            // ���[�J�[�i�J�n�j
            flag = int.TryParse(this.tEdit_MakerCdSt.Text, out code);
            if (flag)
            {
                searchCondition.GoodsMakerCdSt = code;
            }
            else
            {
                searchCondition.GoodsMakerCdSt = 0;
            }

            // ���[�J�[�i�I���j
            flag = int.TryParse(this.tEdit_MakerCdEd.Text, out code);
            if (flag)
            {
                searchCondition.GoodsMakerCdEd = code;
            }
            else
            {
                searchCondition.GoodsMakerCdEd = 9999;
            }

            // �폜�w��敪
            searchCondition.DeleteFlag = this.tComboEditor_DeleteFlag.SelectedIndex;

            // �l����
            flag = double.TryParse(this.tEdit_DiscountRate.Text, out dd);
            if (flag)
            {
                searchCondition.DiscountRate = dd;
            }
            else
            {
                searchCondition.DiscountRate = 0;
            }

            // �l�����敪
            searchCondition.DiscountRateDiv = this.tComboEditor_DiscountRate.SelectedIndex;

            // ������
            flag = double.TryParse(this.tEdit_RateVal.Text, out dd);
            if (flag)
            {
                searchCondition.RateVal = dd;
            }
            else
            {
                searchCondition.RateVal = 0;
            }

            // �������敪
            searchCondition.RateValDiv = this.tComboEditor_RateVal.SelectedIndex;

            // �����z
            flag = double.TryParse(this.tEdit_PriceFl.Text, out dd);
            if (flag)
            {
                searchCondition.PriceFl = dd;
            }
            else
            {
                searchCondition.PriceFl = 0;
            }

            // �����z�敪
            searchCondition.PriceFlDiv = this.tComboEditor_PriceFl.SelectedIndex;
        }

        /// <summary>
        /// �K�C�h�{�^���ݒ菈��
        /// </summary>
        /// <param name="enable">enable</param>
        /// <remarks>
        /// <br>Note       : �K�C�h�{�^���ݒ菈�����s���܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        public void SetGuidButton(bool enable)
        {
            this.tToolsManager_MainMenu.Tools["ButtonTool_Guide"].SharedProps.Enabled = enable;
        }

        /// <summary>
        /// ��ʏ������̎��A�t�H�[�J�X��ݒ肷��B
        /// </summary>
        /// <remarks>
        /// <br>Note       : ��ʏ������̎��A�t�H�[�J�X��ݒ肷��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        public void SetInitFocus()
        {
            this.tEdit_CampaignCode.Focus();
        }

        // ---ADD 2011/07/12-------------->>>>>
        /// <summary>
        /// ��ʂ̃L�����y�[�������擾����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ��ʂ̃L�����y�[�������擾����</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/07/12</br>
        /// </remarks>
        public void GetCampaignInfo(out string campaignCode, out string campaignName, out string sectionCode)
        {
            campaignCode = string.Empty;
            campaignName = string.Empty;
            sectionCode = string.Empty;
            if (this.tEdit_CampaignCode.Text.Trim() != string.Empty)
            {
                campaignCode = this.tEdit_CampaignCode.Text.Trim().PadLeft(6, '0');
                campaignName = this.uLabel_CampaignName.Text.Trim();
                sectionCode = this.tEdit_SectionCodeAllowZero.Text.Trim().PadLeft(2, '0');
            }
        }
        // ---ADD 2011/07/12--------------<<<<<
        #endregion

        // DEL 2015/06/02 ���� ���������i�ݒ�ďo���̎g�p��~ ----------------------------------->>>>>
        ///// <summary>
        ///// �I�v�V���������L���b�V��
        ///// </summary>
        //private void CacheOptionInfo()
        //{
        //    Broadleaf.Application.Remoting.ParamData.PurchaseStatus ps;

        //    #region SCM�I�v�V����
        //    ps = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_PM_SCM);
        //    if (ps == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
        //    {
        //        this._opt_Scm = (int)Option.ON;
        //    }
        //    else
        //    {
        //        this._opt_Scm = (int)Option.OFF;
        //    }
        //    #endregion

        //}
        // DEL 2015/06/02 ���� ���������i�ݒ�ďo���̎g�p��~ -----------------------------------<<<<<
    
    }
}
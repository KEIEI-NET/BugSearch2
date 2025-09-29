//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���R�����h���i�֘A�ݒ�}�X�^
// �v���O�����T�v   : ���R�����h���i�֘A�ݒ�}�X�^�̕ێ���s��
//----------------------------------------------------------------------------//
//                (c)Copyright 2011 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11070266-00 �쐬�S�� : �{�{����
// �� �� ��  2015/01/20  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11070266-00 �쐬�S�� : �{�{����
// �� �� ��  2015/02/10  �C�����e : �C�ݒ�}�X�^�Y���������̃T���v���捞��ʂ�
//                                    ��{�����̋��_�E���Ӑ�������\��
// �� �� ��  2015/02/10  �C�����e : �V�X�e���e�X�g��Q#174
//                                  �E���_:"00"���͎���"�S�Ћ���"��\��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11070266-00 �쐬�S�� : �{�{����
// �� �� ��  2015/02/12  �C�����e : �V�X�e���e�X�g��Q#195,196
//                                  �E�V�K�s�Ɋ�{���̓��Ӑ�\�����ɖ⍇������ƁE���_���Z�b�g
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11070266-00 �쐬�S�� : �{�{����
// �� �� ��  2015/02/13  �C�����e : �V�X�e���e�X�g��Q#193
//                                  �E���_(��{����)�̐���ύX
//                                    �󔒁��S�������A"00"���S�Ћ��ʂ̂݁A�R�[�h���́��ΏۃR�[�h�̂�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11070266-00 �쐬�S�� : �{�{����
// �� �� ��  2015/03/02  �C�����e : �T���v���捞���̓o�^�σ`�F�b�N�ɐV�K���͖��ׂ��܂߂�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11070266-00 �쐬�S�� : �{�{����
// �� �� ��  2015/03/03  �C�����e : Redmine#302 �f�[�^�X�V��A����{�^���𖳌��ɂ���
//                                  Redmine#308 ���Ӑ�̑S���Ӑ�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11070266-00 �쐬�S�� : �{�{����
// �� �� ��  2015/03/04  �C�����e : Redmine#193 ���_(��{����)���󔒂̏ꍇ�A�����[�g�p�����[�^���󔒓n��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11070266-00 �쐬�S�� : �e�c���V
// �� �� ��  2015/03/05  �C�����e : Redmine#326 �폜���[�h���ɃT���v���捞�{�^�����L���ɂȂ�
// �@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@ Redmine#328 �f�[�^�X�V��ɃT���v���捞�{�^�����L���ɂȂ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11070266-00 �쐬�S�� : �{�{����
// �� �� ��  2015/03/06  �C�����e : Redmine#338 �S���Ӑ�ݒ���e��萔��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11070266-00 �쐬�S�� : �e�c���V
// �� �� ��  2015/03/11  �C�����e : Redmine#355 �_���폜���ł��Ȃ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11070266-00 �쐬�S�� : �e�c���V
// �� �� ��  2015/03/12  �C�����e : ��{�����̋��_�����������ꍇ�A�V�K�s�̋��_���[���p�f�B���O����Ȃ�
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

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// ���R�����h���i�֘A�ݒ�}�X�^ UI�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���R�����h���i�֘A�ݒ�}�X�^UI�t�H�[���N���X</br>
    /// <br>Programmer : �{�{����</br>
    /// <br>Date       : 2015/01/20</br>
    /// </remarks>
    public partial class PMREC09011UA : Form
    {
        # region Private Members
        private PMREC09011UB _detailInput;
        private ImageList _imageList16 = null;                                                // �C���[�W���X�g
        private Infragistics.Win.UltraWinToolbars.ButtonTool _closeButton;                    // �I���{�^��
        private Infragistics.Win.UltraWinToolbars.ButtonTool _searchButton;                   // �����{�^��
        private Infragistics.Win.UltraWinToolbars.ButtonTool _saveButton;                     // �ۑ��{�^��
        private Infragistics.Win.UltraWinToolbars.ButtonTool _clearButton;                    // �N���A�{�^��
        private Infragistics.Win.UltraWinToolbars.ButtonTool _guideButton;                    // �K�C�h�{�^��
        private Infragistics.Win.UltraWinToolbars.ButtonTool _reNewalButton;                  // �ŐV���{�^��
        private Infragistics.Win.UltraWinToolbars.ButtonTool _sampleButton;                   // �T���v���捞�{�^�� // ADD 2015/02/06 T.Miyamoto �T���v���捞�@�\�ǉ�
        private Infragistics.Win.UltraWinToolbars.LabelTool _loginNameLabel;                  // ���O�C���S����
        private Infragistics.Win.UltraWinToolbars.LabelTool _loginEmployeeLabel;              // ���O�C���S���Җ���
        // --- ADD 2015/02/20 T.Nishi ------------------------------>>>>>
        private Infragistics.Win.UltraWinToolbars.ButtonTool _printButton;                    // ����{�^��
        private Infragistics.Win.UltraWinToolbars.ButtonTool _pdfButton;                    // PDF�\��
        // --- ADD 2015/02/20 T.Nishi ------------------------------<<<<<
        private ControlScreenSkin _controlScreenSkin;
        private Control _prevControl = null;

        private string _enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
        private string _loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;

        private RecGoodsLkStAcs _recGoodsLkStAcs = null;

        private UserGuideAcs _userGuideAcs;
        private BLGoodsCdAcs _blGoodsCdAcs;

        // ���Ӑ�֘A
        private CustomerSearchAcs _customerSearchAcs;
        private Dictionary<int, CustomerSearchRet> _customerSearchRetDic;
        private bool _cusotmerGuideSelected; // ���Ӑ�K�C�h�I���t���O
        private int _prevCusotmerCd = 0;

        //���_�֘A
        private SecInfoSetAcs _secInfoSetAcs;
        private Dictionary<int, SecInfoSet> _sectionSearchRetDic;
        private bool _sectionGuideSelected; // ���_�K�C�h�I���t���O
        private string _prevSectionCd = string.Empty;

        /// <summary>�`�[�\���^�u ��T�C�Y���������l</summary>
        private bool _columnWidthAutoAdjust = false;

        private SearchCondition _searchCondition = null;
        private bool _isButtonClick = false;

        // ���������i�[
        private SearchCondition _extrInfoForPrint; // ADD 2014/03/05 �c���� Redmine#42247
        #endregion

        #region const
        // �A�Z���u��ID
        private const string ASSMBLY_ID = "PMREC09011U";

        private const string TOOLBAR_CLOSEBUTTON_KEY = "ButtonTool_Close";						// �I��
        private const string TOOLBAR_SEARCHBUTTON_KEY = "ButtonTool_Search";					// ����
        private const string TOOLBAR_SAVEBUTTON_KEY = "ButtonTool_Save";						// �ۑ�
        private const string TOOLBAR_CLEARBUTTON_KEY = "ButtonTool_Clear";						// �N���A
        private const string TOOLBAR_GUIDEBUTTON_KEY = "ButtonTool_Guide";						// �K�C�h
        private const string TOOLBAR_RENEWALBUTTON_KEY = "ButtonTool_ReNewal";					// �ŐV���
        private const string TOOLBAR_SAMPLEBUTTON_KEY = "ButtonTool_Sample";                    // �T���v���捞�{�^�� // ADD 2015/02/06 T.Miyamoto �T���v���捞�@�\�ǉ�
        // --- ADD 2015/02/20 T.Nishi ------------------------------>>>>>
        private const string TOOLBAR_PRINT_KEY = "ButtonTool_Print";  //���
        private const string TOOLBAR_PDF_KEY = "ButtonTool_PDF";  //PDF
        // --- ADD 2015/02/20 T.Nishi ------------------------------<<<<<

        /// <summary>�\���F�����t�H���g�T�C�Y</summary>
        private const int CT_DEF_FONT_SIZE = 10;

        private static readonly Color ct_READONLY_CELL_COLOR = Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(220)))));
        /// <summary>�����T�C�Y</summary>
        private readonly int[] _fontpitchSize = new int[] { 6, 8, 9, 10, 11, 12, 14, 16, 18, 20, 22, 24 };
        /// <summary>���׃f�[�^���o�ő匏��</summary>
        private const long DATA_COUNT_MAX = 20000;
        #endregion

        # region Constroctors
        /// <summary>
        ///  ���R�����h���i�֘A�ݒ�}�X�^�t�H�[���N���X �f�t�H���g�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���R�����h���i�֘A�ݒ�}�X�^�t�H�[���N���X �f�t�H���g�R���X�g���N�^</br>
        /// <br>Programmer : �{�{����</br>                                  
        /// <br>Date       : 2015/01/20</br> 
        /// </remarks>
        public PMREC09011UA()
        {
            InitializeComponent();

            // �ϐ�������
            this._detailInput = new PMREC09011UB();
            this._imageList16 = IconResourceManagement.ImageList16;
            this._loginNameLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)this.tToolsManager_MainMenu.Tools["LabelTool_LoginTitle"];
            this._loginEmployeeLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)this.tToolsManager_MainMenu.Tools["LabelTool_LoginName"];
            this._closeButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools["ButtonTool_Close"];
            this._searchButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools["ButtonTool_Search"];
            this._saveButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools["ButtonTool_Save"];
            this._clearButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools["ButtonTool_Clear"];
            this._guideButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools["ButtonTool_Guide"];
            this._reNewalButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools["ButtonTool_ReNewal"];
            this._sampleButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools["ButtonTool_Sample"]; // ADD 2015/02/06 T.Miyamoto �T���v���捞�@�\�ǉ�
            // --- ADD 2015/02/20 T.Nishi ------------------------------>>>>>
            this._printButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools["ButtonTool_Print"];
            this._pdfButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools["ButtonTool_PDF"];
            // --- ADD 2015/02/20 T.Nishi ------------------------------<<<<<

            this._detailInput.GridKeyUpTopRow += new EventHandler(this.GriedDetail_GridKeyUpTopRow);
            this._controlScreenSkin = new ControlScreenSkin();
            this._loginEmployeeLabel.SharedProps.Caption = LoginInfoAcquisition.Employee.Name;

            this._detailInput.SetGuidButton += new PMREC09011UB.SetGuidButtonEventHandler(this.SetGuidButton);
            this._detailInput.GetCustomerInfo += new PMREC09011UB.GetCustomerInfoEventHandler(this.GetCustomerInfo);
            this._detailInput.GetSectionInfo += new PMREC09011UB.GetSectionInfoEventHandler(this.GetSectionInfo);
            this._detailInput.SetSampleButton += new PMREC09011UB.SetSampleButtonEventHandler(this.SetSampleButton); // ADD 2015/02/06 T.Miyamoto �T���v���捞�@�\�ǉ�

            this._recGoodsLkStAcs = this._detailInput.RecGoodsLkStAcs;
            this._userGuideAcs = new UserGuideAcs();
            this._blGoodsCdAcs = new BLGoodsCdAcs();
            this._customerSearchAcs = new CustomerSearchAcs();
            this._secInfoSetAcs = new SecInfoSetAcs();

            // �ݒ�ǂݍ���
            this._detailInput.Deserialize();

            this.tComboEditor_DeleteFlag.SelectedIndex = 0;
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
        /// <br>Programmer : �{�{����</br>
        /// <br>Date       : 2015/01/20</br>
        /// </remarks>
        private void PMREC09011UA_Load(object sender, EventArgs e)
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

            this._recGoodsLkStAcs.LoadMstData();

            while (this._recGoodsLkStAcs.MasterAcsThread.ThreadState == System.Threading.ThreadState.Running)
            {
                Thread.Sleep(100);
            }

            // �����T�C�Y�ݒ�
            for (int i = 0; i < this._fontpitchSize.Length; i++)
            {
                this.tComboEditor_StatusBar_FontSize.Items.Add(this._fontpitchSize[i], this._fontpitchSize[i].ToString());
            }

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
                this._detailInput.uGrid_Details.DisplayLayout.Appearance.FontData.SizeInPoints = (float)CT_DEF_FONT_SIZE;
                this._detailInput.uGrid_Details.Refresh();
            }
            this.tComboEditor_StatusBar_FontSize.ValueChanged += tComboEditor_StatusBar_FontSize_ValueChanged;

            this._detailInput.LoadSettings();

            // ���Ӑ���Ǎ�����
            this.ReadCustomerSearchRet();

            // ���_���Ǎ�����
            this.ReadSectionSearchRet();

            // --- ADD 2015/02/20 T.Nishi ------------------------------>>>>>
            adjustButtonEnable();
            // --- ADD 2015/02/20 T.Nishi ------------------------------<<<<<
        }

        /// <summary>
        /// �{�^�������ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note       : �{�^�������ݒ菈�����s���܂��B</br>
        /// <br>Programmer : �{�{����</br>
        /// <br>Date       : 2015/01/20</br>
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
            this._sampleButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SETUP1; // ADD 2015/02/06 T.Miyamoto �T���v���捞�@�\�ǉ�
            this._loginNameLabel.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.EMPLOYEE;
            // --- ADD 2015/02/20 T.Nishi ------------------------------>>>>>
            this._printButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.PRINT;  // ���
            this._pdfButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.PREVIEW;  // PDF�\��
            // --- ADD 2015/02/20 T.Nishi ------------------------------<<<<<
           
            #region �K�C�h�{�^��
            this.uButton_CustomerGuide.ImageList = this._imageList16;
            this.uButton_CustomerGuide.Appearance.Image = (int)Size16_Index.STAR1;
            this.uButton_SectionGuide.ImageList = this._imageList16;
            this.uButton_SectionGuide.Appearance.Image = (int)Size16_Index.STAR1;
            this.uButton_BlGoodsCodeSt.ImageList = this._imageList16;
            this.uButton_BlGoodsCodeSt.Appearance.Image = (int)Size16_Index.STAR1;
            this.uButton_BlGoodsCodeEd.ImageList = this._imageList16;
            this.uButton_BlGoodsCodeEd.Appearance.Image = (int)Size16_Index.STAR1;
            #endregion

            this.SetSampleButton(false);
        }

        /// <summary>
        /// �t�H�[�J�X�ϊ�����
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : �t�H�[�J�X�ϊ������B</br>
        /// <br>Programmer : �{�{����</br>
        /// <br>Date       : 2015/01/20</br>
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
                                            e.NextCtrl = this.tComboEditor_DeleteFlag;
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.tNedit_SectionCodeAllowZero;
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
                case "PMREC09011UB":
                    {
                        if (e.NextCtrl != null)
                        {
                            if (e.NextCtrl.Name == "uButton_RowDelete"
                                || e.NextCtrl.Name == "uButton_AllRowDelete"
                                || e.NextCtrl.Name == "uButton_Revival"
                                || e.NextCtrl.Name == "uButton_GetPriceDate"
                                || e.NextCtrl.Name == "_PMREC09011UA_Toolbars_Dock_Area_Top"
                                || e.NextCtrl.Name == "_PMREC09011UB_Toolbars_Dock_Area_Top")
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

                #region ���Ӑ�R�[�h
                case "tNedit_CustomerCodeAllowZero":
                    {
                        // --- UPD 2015/03/03 T.Miyamoto Redmine#308 ------------------------------>>>>>
                        //if (!this.CustomerCheck(this.tNedit_CustomerCodeAllowZero.GetInt()))
                        if (!this.CustomerCheck(this.tNedit_CustomerCodeAllowZero.DataText))
                        // --- UPD 2015/03/03 T.Miyamoto Redmine#308 ------------------------------<<<<<
                        {
                            e.NextCtrl = e.PrevCtrl; //�t�H�[�J�X�ړ�����
                            break;
                        }

                        // �t�H�[�J�X�ݒ�
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                if (this.uExGroupBox_ExtraCondition.Expanded)
                                {
                                    // --- UPD 2015/03/03 T.Miyamoto Redmine#308 ------------------------------>>>>>
                                    //if (this.tNedit_CustomerCodeAllowZero.GetInt() == 0)
                                    if (this.tNedit_CustomerCodeAllowZero.DataText.Trim() == string.Empty)
                                    // --- UPD 2015/03/03 T.Miyamoto Redmine#308 ------------------------------<<<<<
                                    {
                                        e.NextCtrl = this.uButton_CustomerGuide;
                                    }
                                    else
                                    {
                                        e.NextCtrl = this.tEdit_BlGoodsCodeSt;
                                    }
                                }
                                else
                                {
                                    // --- UPD 2015/03/03 T.Miyamoto Redmine#308 ------------------------------>>>>>
                                    //this.Search();
                                    //e.NextCtrl = null;
                                    if (this.tNedit_CustomerCodeAllowZero.DataText.Trim() == string.Empty)
                                    {
                                        e.NextCtrl = this.uButton_CustomerGuide;
                                    }
                                    else
                                    {
                                        this.Search();
                                        e.NextCtrl = null;
                                    }
                                    // --- UPD 2015/03/03 T.Miyamoto Redmine#308 ------------------------------<<<<<
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
                        }
                        else
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                if (this.tNedit_SectionCodeAllowZero.DataText.Trim() == string.Empty)
                                {
                                    e.NextCtrl = this.uButton_SectionGuide;
                                }
                                else
                                {
                                    e.NextCtrl = this.tNedit_SectionCodeAllowZero;
                                }
                            }
                        }
                        break;
                    }
                #endregion

                #region ���Ӑ�K�C�h�{�^��
                case "uButton_CustomerGuide":
                    {
                        // �t�H�[�J�X�ݒ�
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                // --- UPD 2015/03/03 T.Miyamoto Redmine#308 ------------------------------>>>>>
                                //e.NextCtrl = this.tEdit_BlGoodsCodeSt;
                                if (this.uExGroupBox_ExtraCondition.Expanded)
                                {
                                    e.NextCtrl = this.tEdit_BlGoodsCodeSt;
                                }
                                else
                                {
                                    this.Search();
                                    e.NextCtrl = null;
                                }
                                // --- UPD 2015/03/03 T.Miyamoto Redmine#308 ------------------------------<<<<<
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
                                e.NextCtrl = this.tNedit_CustomerCodeAllowZero;
                            }
                        }
                        break;
                    }
                #endregion

                #region ���_�R�[�h
                case "tNedit_SectionCodeAllowZero":
                    {
                        // --- UPD 2015/02/13 T.Miyamoto ����ýď�Q#193 ------------------------------>>>>>
                        //string sectionCode = this.tNedit_SectionCodeAllowZero.DataText.PadLeft(2, '0');
                        string sectionCode = this.tNedit_SectionCodeAllowZero.DataText.Trim();
                        // --- UPD 2015/02/13 T.Miyamoto ����ýď�Q#193 ------------------------------<<<<<
                        if (!this.SectionCheck(sectionCode))
                        {
                            e.NextCtrl = e.PrevCtrl; //�t�H�[�J�X�ړ�����
                            this.tNedit_SectionCodeAllowZero.SelectAll();
                            break;
                        }

                        // �t�H�[�J�X�ݒ�
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                if (this.tNedit_SectionCodeAllowZero.DataText.Trim() == string.Empty)
                                {
                                    e.NextCtrl = this.uButton_SectionGuide;
                                }
                                else
                                {
                                    e.NextCtrl = this.tNedit_CustomerCodeAllowZero;
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
                        break;
                    }
                #endregion

                #region ���_�K�C�h�{�^��
                case "uButton_SectionGuide":
                    {
                        // �t�H�[�J�X�ݒ�
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                e.NextCtrl = this.tNedit_CustomerCodeAllowZero;
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
                                e.NextCtrl = this.tNedit_SectionCodeAllowZero;
                            }
                        }
                        break;
                    }
                #endregion


                #region ������BL�R�[�h�i�J�n�j
                case "tEdit_BlGoodsCodeSt":
                    {
                        bool hasValue = true;
                        int blGoodsCodeSt = 0;

                        // ���͒l���擾
                        Int32.TryParse(this.tEdit_BlGoodsCodeSt.Text.Trim(), out blGoodsCodeSt);

                        if (blGoodsCodeSt != 0)
                        {
                            BLGoodsCdUMnt blGoodsCdUMnt = null;
                            if (this._recGoodsLkStAcs.BLGoodsCdDic.ContainsKey(blGoodsCodeSt))
                            {
                                blGoodsCdUMnt = this._recGoodsLkStAcs.BLGoodsCdDic[blGoodsCodeSt];
                            }

                            if (blGoodsCdUMnt != null)
                            {
                                this.tEdit_BlGoodsCodeSt.Text = blGoodsCdUMnt.BLGoodsCode.ToString().PadLeft(5, '0');
                                this.uLabel_BlGoodsNameSt.Text = blGoodsCdUMnt.BLGoodsHalfName;
                            }
                            else
                            {
                                this.uLabel_BlGoodsNameSt.Text = string.Empty;
                            }
                        }
                        else
                        {
                            this.tEdit_BlGoodsCodeSt.Text = string.Empty;
                            this.uLabel_BlGoodsNameSt.Text = string.Empty;
                        }

                        // �t�H�[�J�X�ݒ�
                        if (hasValue)
                        {
                            if (e.ShiftKey == false)
                            {
                                if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                                {
                                    if (this.tEdit_BlGoodsCodeSt.Text.Trim() == string.Empty)
                                    {
                                        e.NextCtrl = this.uButton_BlGoodsCodeSt;
                                    }
                                    else
                                    {
                                        e.NextCtrl = this.tEdit_BlGoodsCodeEd;
                                    }
                                }
                            }
                            else
                            {
                                if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                                {
                                    // --- UPD 2015/03/03 T.Miyamoto Redmine#308 ------------------------------>>>>>
                                    //if (this.tNedit_CustomerCodeAllowZero.GetInt() == 0)
                                    if (this.tNedit_CustomerCodeAllowZero.DataText.Trim() == string.Empty)
                                    // --- UPD 2015/03/03 T.Miyamoto Redmine#308 ------------------------------<<<<<
                                    {
                                        e.NextCtrl = this.uButton_CustomerGuide;
                                    }
                                    else
                                    {
                                        e.NextCtrl = this.tNedit_CustomerCodeAllowZero;
                                    }
                                }
                            }
                        }
                        else
                        {
                            e.NextCtrl = e.PrevCtrl;
                        }
                        break;
                    }
                #endregion

                #region ������BL�R�[�h�K�C�h�{�^���i�J�n�j
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

                #region ������BL�R�[�h�i�I���j
                case "tEdit_BlGoodsCodeEd":
                    {
                        bool hasValue = true;
                        int blGoodsCodeEd = 0;

                        // ���͒l���擾
                        Int32.TryParse(this.tEdit_BlGoodsCodeEd.Text.Trim(), out blGoodsCodeEd);

                        if (blGoodsCodeEd != 0)
                        {
                            BLGoodsCdUMnt blGoodsCdUMnt = null;
                            if (this._recGoodsLkStAcs.BLGoodsCdDic.ContainsKey(blGoodsCodeEd))
                            {
                                blGoodsCdUMnt = this._recGoodsLkStAcs.BLGoodsCdDic[blGoodsCodeEd];
                            }

                            if (blGoodsCdUMnt != null)
                            {
                                this.tEdit_BlGoodsCodeEd.Text = blGoodsCdUMnt.BLGoodsCode.ToString().PadLeft(5, '0');
                                this.uLabel_BlGoodsNameEd.Text = blGoodsCdUMnt.BLGoodsHalfName;
                            }
                            else
                            {
                                this.uLabel_BlGoodsNameEd.Text = string.Empty;
                            }
                        }
                        else
                        {
                            this.tEdit_BlGoodsCodeEd.Text = string.Empty;
                            this.uLabel_BlGoodsNameEd.Text = string.Empty;
                        }

                        // �t�H�[�J�X�ݒ�
                        if (hasValue)
                        {
                            if (e.ShiftKey == false)
                            {
                                if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                                {
                                    if (this.tEdit_BlGoodsCodeEd.Text.Trim() == string.Empty)
                                    {
                                        e.NextCtrl = this.uButton_BlGoodsCodeEd;
                                    }
                                    else
                                    {
                                        e.NextCtrl = this.tComboEditor_DeleteFlag;
                                    }
                                }
                            }
                            else
                            {
                                if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                                {
                                    if (this.tEdit_BlGoodsCodeSt.Text.Trim() == string.Empty)
                                    {
                                        e.NextCtrl = this.uButton_BlGoodsCodeSt;
                                    }
                                    else
                                    {
                                        e.NextCtrl = this.tEdit_BlGoodsCodeSt;
                                    }
                                }
                            }
                        }
                        else
                        {
                            e.NextCtrl = e.PrevCtrl;
                        }
                        break;
                    }
                #endregion

                #region ������BL�R�[�h�K�C�h�{�^���i�I���j
                case "uButton_BlGoodsCodeEd":
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
                                e.NextCtrl = this.tEdit_BlGoodsCodeEd;
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
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab) || (e.Key == Keys.Down))
                            {
                                this.Search();
                                e.NextCtrl = null;
                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                if (this.tEdit_BlGoodsCodeEd.Text.Trim() == string.Empty)
                                {
                                    e.NextCtrl = this.uButton_BlGoodsCodeEd;
                                }
                                else
                                {
                                    e.NextCtrl = this.tEdit_BlGoodsCodeEd;
                                }
                                // --- UPD �@ T.Miyamoto --------------------<<<<<
                            }
                        }
                        break;
                    }
                #endregion

                #region �O���[�v�{�b�N�X�i���Ӑ�R�[�h�j
                case "uExGroupBox_CommonCondition":
                    {
                        // �t�H�[�J�X�ݒ�
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab) || (e.Key == Keys.Down))
                            {
                                if (!this.uExGroupBox_ExtraCondition.Expanded)
                                {
                                    this.Search();
                                    e.NextCtrl = null;
                                }
                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                e.NextCtrl = null;
                            }
                        }
                        break;
                    }
                #endregion

                #region �O���[�v�{�b�N�X�iBL�R�[�h�j
                case "uExGroupBox_ExtraCondition":
                    {
                        
                        // �t�H�[�J�X�ݒ�
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab) || (e.Key == Keys.Down))
                            {
                                this.Search();
                                e.NextCtrl = null;
                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                e.NextCtrl = null;
                            }
                        }
                        break;
                    }
                #endregion
            }

            #region ����������
            if (e.NextCtrl != null)  
            {
                if (e.PrevCtrl.Name != "PMREC09011UB")
                {
                    switch (e.NextCtrl.Name)
                    {
                        case "uGrid_Details":
                            {
                                this.Search();
                                e.NextCtrl = null;
                                break;
                            }
                    }
                }
            }
            #endregion

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
                    case "tNedit_SectionCodeAllowZero":
                    case "tNedit_CustomerCodeAllowZero":
                    case "tEdit_BlGoodsCodeSt":
                    case "tEdit_BlGoodsCodeEd":
                        {
                            SetGuidButton(true);
                            break;
                        }
                    case "uGrid_Details":
                        {
                            this._detailInput.SetGridGuid();
                            break;
                        }
                    case "_PMREC09011UA_Toolbars_Dock_Area_Top":
                    case "_PMREC09011UB_Toolbars_Dock_Area_Top":
                        break;
                    default:
                        SetGuidButton(false);
                        break;
                }
            }
            #endregion

            // --- ADD 2015/02/06 T.Miyamoto �T���v���捞�@�\�ǉ� ------------------------------>>>>>
            #region ���T���v���捞�̗L�������ݒ�
            if (e.NextCtrl == this.uStatusBar_Main)
            {
                e.NextCtrl = e.PrevCtrl;
                return;
            }
            if (e.NextCtrl != null)
            {
                switch (e.NextCtrl.Name)
                {
                    case "tNedit_SectionCodeAllowZero":
                    case "tNedit_CustomerCodeAllowZero":
                    case "tEdit_BlGoodsCodeSt":
                    case "tEdit_BlGoodsCodeEd":
                        {
                            this.SetSampleButton(false);
                            break;
                        }
                    case "uGrid_Details":
                        {
                            this.SetSampleButton(true);
                            break;
                        }
                    case "_PMREC09011UA_Toolbars_Dock_Area_Top":
                    case "_PMREC09011UB_Toolbars_Dock_Area_Top":
                        break;
                    default:
                        this.SetSampleButton(false);
                        break;
                }
            }
            #endregion
            // --- ADD 2015/02/06 T.Miyamoto �T���v���捞�@�\�ǉ� ------------------------------<<<<<
        }

        /// <summary>
        /// �t�H�[�����[�h�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note	   : �t�H�[�����ǂݍ��܂ꂽ���ɔ������܂��B</br>
        /// <br>Programmer : �{�{����</br>
        /// <br>Date       : 2015/01/20</br>
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
                        if (this.tNedit_SectionCodeAllowZero.Focused)
                        {
                            this.tArrowKeyControl1_ChangeFocus(null, new ChangeFocusEventArgs(false, false, false, Keys.Enter, this.tNedit_SectionCodeAllowZero, this.tNedit_SectionCodeAllowZero));
                        }
                        else if (this.tNedit_CustomerCodeAllowZero.Focused)
                        {
                            this.tArrowKeyControl1_ChangeFocus(null, new ChangeFocusEventArgs(false, false, false, Keys.Enter, this.tNedit_CustomerCodeAllowZero, this.tNedit_CustomerCodeAllowZero));
                        }
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
                        // --- DEL 2015/03/11 Y.Wakita Redmine#355 ---------->>>>>
                        //else
                        //{
                        //    this.Save();
                        //}
                        // --- DEL 2015/03/11 Y.Wakita Redmine#355 ----------<<<<<
                        this.Save();    // ADD 2015/03/11 Y.Wakita Redmine#355
                        break;
                    }
                // �N���A
                case TOOLBAR_CLEARBUTTON_KEY:
                    {
                        this.Clear();
                        RecGoodsLkSt recGoodsLkSt = null;
                        this._recGoodsLkStAcs.CopyToRecGoodsLkFromDetailRow((RecGoodsLkDataSet.RecGoodsLkRow)this._recGoodsLkStAcs.RecGoodsLkDataTable.Rows[this._recGoodsLkStAcs.RecGoodsLkDataTable.Count - 1], ref recGoodsLkSt);
                        this._recGoodsLkStAcs.NewRecGoodsLkObj = recGoodsLkSt.Clone();
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
                // --- ADD 2015/02/06 T.Miyamoto �T���v���捞�@�\�ǉ� ------------------------------>>>>>
                // �T���v���捞
                case TOOLBAR_SAMPLEBUTTON_KEY:
                    {
                        // --- UPD 2015/02/10�C T.Miyamoto ------------------------------>>>>>
                        //this.SampleSetting();
                        this.SampleSetting(false);
                        // --- UPD 2015/02/10�C T.Miyamoto ------------------------------<<<<<
                        break;
                    }
                // --- ADD 2015/02/06 T.Miyamoto �T���v���捞�@�\�ǉ� ------------------------------>>>>>
                // --- ADD 2015/02/20 T.Nishi ------------------------------>>>>>
                case TOOLBAR_PRINT_KEY:
                    {
                        // ���
                        Print(false);
                        break;
                    }
                case TOOLBAR_PDF_KEY:
                    {
                        // PDF�\��
                        Print(true);
                        break;
                    }
                // --- ADD 2015/02/20 T.Nishi ------------------------------<<<<<
            }
        }
        // --- ADD 2015/02/20 T.Nishi ------------------------------>>>>>
        /// <summary>
        /// ���(PDF�\��)
        /// </summary>
        /// <param name="pdfOut">PDF�\�����邩�ǂ���</param>
        /// <remarks>
        /// <br>Note        : ���(PDF�\��)</br>
        /// <br>Programmer  : �c����</br>
        /// <br>Date        : 2014/03/05</br>
        /// </remarks>
        private void Print(bool pdfOut)
        {
            // ���׈ꗗ�����݂��Ȃ��ꍇ�͎��s�s�\
            if (this._detailInput.uGrid_Details.Rows.Count == 0)
            {
                return;
            }

            // ����I�u�W�F�N�g�Ăяo��
            SFCMN06001U printDialog = new SFCMN06001U();
            SFCMN06002C printInfo = new SFCMN06002C();

            printInfo.printmode = (pdfOut) ? 2 : 1;�@// 2�FPDF�\���̂݁A1�F����̂�
            printInfo.pdfopen = false;
            printInfo.pdftemppath = "";

            // ���ڈ���o�[�W����
            printInfo.enterpriseCode = this._enterpriseCode;
            printInfo.kidopgid = ASSMBLY_ID;�@// �N��PGID
            // PDF�o�͗���p
            printInfo.prpnm = "";

            // ���������i�[
            if (_extrInfoForPrint != null)
            {
                printInfo.jyoken = _extrInfoForPrint;
            }

            // ����f�[�^�쐬
            DataTable dt = null;
            GetPrintDataSetFromDataView(out dt);

            DataView dtView = new DataView(dt);
            printInfo.rdData = dtView;
            printInfo.key = dtView.Table.TableName;

            printDialog.PrintInfo = printInfo;

            DialogResult result = printDialog.ShowDialog(this);
            if (result == DialogResult.Cancel)
            {
                return;
            }

            // PDF�\���̏ꍇ
            if (printInfo.pdfopen)
            {
                /*
                PMZAI04201UB pdfForm = new PMZAI04201UB(this.Parent as Form);

                try
                {
                    pdfForm.PDFShow(printInfo.pdftemppath);
                }
                finally
                {
                    pdfForm.Close();
                    pdfForm.Dispose();
                }
                 */ 
            }
        }

        /// <summary>
        /// ����p�f�[�^�e�[�u������
        /// </summary>
        /// <param name="dt"></param>
        /// <remarks>
        /// <br>Note        : ����p�f�[�^�e�[�u������</br>
        /// <br>Programmer  : �c����</br>
        /// <br>Date        : 2014/03/05</br>
        /// </remarks>
        private void GetPrintDataSetFromDataView(out DataTable dt)
        {
            dt = new DataTable("InventoryDataDsp");

            dt.Columns.Add(this._recGoodsLkStAcs.RecGoodsLkDataTable.RowNoColumn.ColumnName, typeof(string));  // ��
            dt.Columns.Add(this._recGoodsLkStAcs.RecGoodsLkDataTable.UpdateTimeColumn.ColumnName, typeof(string));  // �폜��
            dt.Columns.Add(this._recGoodsLkStAcs.RecGoodsLkDataTable.InqOtherSecCdColumn.ColumnName, typeof(string));  // ���_�R�[�h
            dt.Columns.Add(this._recGoodsLkStAcs.RecGoodsLkDataTable.InqOtherSecNmColumn.ColumnName, typeof(string));  // ���_����
            dt.Columns.Add(this._recGoodsLkStAcs.RecGoodsLkDataTable.CustomerCodeColumn.ColumnName, typeof(string));  // ���Ӑ�R�[�h
            dt.Columns.Add(this._recGoodsLkStAcs.RecGoodsLkDataTable.CustomerSnmColumn.ColumnName, typeof(string));  // ���Ӑ旪��
            dt.Columns.Add(this._recGoodsLkStAcs.RecGoodsLkDataTable.RecSourceBLGoodsCdColumn.ColumnName, typeof(string));  // ������BL�R�[�h
            dt.Columns.Add(this._recGoodsLkStAcs.RecGoodsLkDataTable.RecSourceBLGoodsNmColumn.ColumnName, typeof(string));  // ������BL�R�[�h��
            dt.Columns.Add(this._recGoodsLkStAcs.RecGoodsLkDataTable.RecDestBLGoodsCdColumn.ColumnName, typeof(string));  // ������BL�R�[�h
            dt.Columns.Add(this._recGoodsLkStAcs.RecGoodsLkDataTable.RecDestBLGoodsNmColumn.ColumnName, typeof(string));  // ������BL�R�[�h��
            dt.Columns.Add(this._recGoodsLkStAcs.RecGoodsLkDataTable.GoodsCommentColumn.ColumnName, typeof(string));  // ���i�R�����g

            DataRow row = null;

            for (int i = 0; i < this._recGoodsLkStAcs.RecGoodsLkDataTable.Rows.Count; i++)
            {
                if (this._recGoodsLkStAcs.RecGoodsLkDataTable[i].FilterGuid != Guid.Empty)
                {
                    row = dt.NewRow();

                    row[this._recGoodsLkStAcs.RecGoodsLkDataTable.InqOtherSecCdColumn.ColumnName] = this._recGoodsLkStAcs.RecGoodsLkDataTable[i].InqOtherSecCd.ToString().Trim().PadLeft(2, '0');  // ���_�R�[�h
                    row[this._recGoodsLkStAcs.RecGoodsLkDataTable.InqOtherSecNmColumn.ColumnName] = this._recGoodsLkStAcs.RecGoodsLkDataTable[i].InqOtherSecNm.Trim();  // ���_����
                    row[this._recGoodsLkStAcs.RecGoodsLkDataTable.CustomerCodeColumn.ColumnName] = this._recGoodsLkStAcs.RecGoodsLkDataTable[i].CustomerCode.ToString().Trim().PadLeft(6, '0');  // ���Ӑ�R�[�h
                    row[this._recGoodsLkStAcs.RecGoodsLkDataTable.CustomerSnmColumn.ColumnName] = this._recGoodsLkStAcs.RecGoodsLkDataTable[i].CustomerSnm.Trim();  // ���Ӑ旪��
                    row[this._recGoodsLkStAcs.RecGoodsLkDataTable.RecSourceBLGoodsCdColumn.ColumnName] = this._recGoodsLkStAcs.RecGoodsLkDataTable[i].RecSourceBLGoodsCd.ToString().Trim().PadLeft(5, '0');  // ������BL�R�[�h
                    row[this._recGoodsLkStAcs.RecGoodsLkDataTable.RecSourceBLGoodsNmColumn.ColumnName] = this._recGoodsLkStAcs.RecGoodsLkDataTable[i].RecSourceBLGoodsNm.Trim();  // ������BL�R�[�h��
                    row[this._recGoodsLkStAcs.RecGoodsLkDataTable.RecDestBLGoodsCdColumn.ColumnName] = this._recGoodsLkStAcs.RecGoodsLkDataTable[i].RecDestBLGoodsCd.ToString().Trim().PadLeft(5, '0');  // ������BL�R�[�h
                    row[this._recGoodsLkStAcs.RecGoodsLkDataTable.RecDestBLGoodsNmColumn.ColumnName] = this._recGoodsLkStAcs.RecGoodsLkDataTable[i].RecDestBLGoodsNm.Trim();  // ������BL�R�[�h��
                    row[this._recGoodsLkStAcs.RecGoodsLkDataTable.GoodsCommentColumn.ColumnName] = this._recGoodsLkStAcs.RecGoodsLkDataTable[i].GoodsComment.Trim();  // ���i�R�����g

                    dt.Rows.Add(row);
                }
            }
            
            /*
            foreach (Infragistics.Win.UltraWinGrid.UltraGridRow gridRow in this._detailInput.uGrid_Details.Rows)
            {
                if ((Guid)gridRow.Cells[this._recGoodsLkStAcs.RecGoodsLkDataTable.FilterGuidColumn.ColumnName].Value != Guid.Empty)
                {
                    row = dt.NewRow();

                    row[this._recGoodsLkStAcs.RecGoodsLkDataTable.RowNoColumn.ColumnName] = gridRow.Cells[this._recGoodsLkStAcs.RecGoodsLkDataTable.RowNoColumn.ColumnName].Value;  // ��
                    row[this._recGoodsLkStAcs.RecGoodsLkDataTable.UpdateTimeColumn.ColumnName] = gridRow.Cells[this._recGoodsLkStAcs.RecGoodsLkDataTable.UpdateTimeColumn.ColumnName].Value;  // �폜��
                    row[this._recGoodsLkStAcs.RecGoodsLkDataTable.InqOtherSecCdColumn.ColumnName] = gridRow.Cells[this._recGoodsLkStAcs.RecGoodsLkDataTable.InqOtherSecCdColumn.ColumnName].Value.ToString().PadLeft(2,'0');  // ���_�R�[�h
                    row[this._recGoodsLkStAcs.RecGoodsLkDataTable.InqOtherSecNmColumn.ColumnName] = gridRow.Cells[this._recGoodsLkStAcs.RecGoodsLkDataTable.InqOtherSecNmColumn.ColumnName].Value;  // ���_����
                    row[this._recGoodsLkStAcs.RecGoodsLkDataTable.CustomerCodeColumn.ColumnName] = gridRow.Cells[this._recGoodsLkStAcs.RecGoodsLkDataTable.CustomerCodeColumn.ColumnName].Value.ToString().PadLeft(6, '0');  // ���Ӑ�R�[�h
                    row[this._recGoodsLkStAcs.RecGoodsLkDataTable.CustomerSnmColumn.ColumnName] = gridRow.Cells[this._recGoodsLkStAcs.RecGoodsLkDataTable.CustomerSnmColumn.ColumnName].Value;  // ���Ӑ旪��
                    row[this._recGoodsLkStAcs.RecGoodsLkDataTable.RecSourceBLGoodsCdColumn.ColumnName] = gridRow.Cells[this._recGoodsLkStAcs.RecGoodsLkDataTable.RecSourceBLGoodsCdColumn.ColumnName].Value.ToString().PadLeft(5, '0');  // ������BL�R�[�h
                    row[this._recGoodsLkStAcs.RecGoodsLkDataTable.RecSourceBLGoodsNmColumn.ColumnName] = gridRow.Cells[this._recGoodsLkStAcs.RecGoodsLkDataTable.RecSourceBLGoodsNmColumn.ColumnName].Value;  // ������BL�R�[�h��
                    row[this._recGoodsLkStAcs.RecGoodsLkDataTable.RecDestBLGoodsCdColumn.ColumnName] = gridRow.Cells[this._recGoodsLkStAcs.RecGoodsLkDataTable.RecDestBLGoodsCdColumn.ColumnName].Value.ToString().PadLeft(5, '0');  // ������BL�R�[�h
                    row[this._recGoodsLkStAcs.RecGoodsLkDataTable.RecDestBLGoodsNmColumn.ColumnName] = gridRow.Cells[this._recGoodsLkStAcs.RecGoodsLkDataTable.RecDestBLGoodsNmColumn.ColumnName].Value;  // ������BL�R�[�h��
                    row[this._recGoodsLkStAcs.RecGoodsLkDataTable.GoodsCommentColumn.ColumnName] = gridRow.Cells[this._recGoodsLkStAcs.RecGoodsLkDataTable.GoodsCommentColumn.ColumnName].Value;  // ���i�R�����g

                    dt.Rows.Add(row);
                }
            }
             */ 
        }

        /// <summary>
        /// �{�^���̗L��/�����ؑ�
        /// </summary>
        /// <remarks>
        /// <br>Note        : �{�^���̗L��/�����ؑ�</br>
        /// <br>Programmer  : �c����</br>
        /// <br>Date        : 2014/03/05</br>
        /// </remarks>
        private void adjustButtonEnable()
        {
            bool bDataFlg = false;
            for (int i = 0; i < this._recGoodsLkStAcs.RecGoodsLkDataTable.Rows.Count; i++)
            {
                if (this._recGoodsLkStAcs.RecGoodsLkDataTable[i].FilterGuid == Guid.Empty)
                {
                    continue;
                }
                bDataFlg = true;
                break;
            }

            if (bDataFlg == true)
            {
                // ���
                this.tToolsManager_MainMenu.Tools[TOOLBAR_PRINT_KEY].SharedProps.Enabled = true;
                // PDF�o��
                this.tToolsManager_MainMenu.Tools[TOOLBAR_PDF_KEY].SharedProps.Enabled = true;
            }
            else
            {
                // ���
                this.tToolsManager_MainMenu.Tools[TOOLBAR_PRINT_KEY].SharedProps.Enabled = false;
                // PDF�o��
                this.tToolsManager_MainMenu.Tools[TOOLBAR_PDF_KEY].SharedProps.Enabled = false;
            }
        }
        // --- ADD 2015/02/20 T.Nishi ------------------------------<<<<<

        /// <summary>
        /// ���Ӑ�K�C�h�{�^��
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : ���Ӑ�K�C�h�{�^��</br>
        /// <br>Programmer : �{�{����</br>
        /// <br>Date       : 2015/01/20</br>
        /// </remarks>
        /// <summary>
        private void uButton_CustomerGuide_Click(object sender, EventArgs e)
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
                    // --- UPD 2015/03/03 T.Miyamoto Redmine#308 ------------------------------>>>>>
                    //if (this.CustomerCheck(this.tNedit_CustomerCodeAllowZero.GetInt()))
                    if (this.CustomerCheck(this.tNedit_CustomerCodeAllowZero.DataText))
                    // --- UPD 2015/03/03 T.Miyamoto Redmine#308 ------------------------------<<<<<
                    {
                        tEdit_BlGoodsCodeSt.Focus();
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
        /// <br>Programmer : �{�{����</br>
        /// <br>Date       : 2015/01/20</br>
        /// </remarks>
        /// <summary>
        private void uButton_SectionGuide_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                int status;
                SecInfoSetAcs secInfoSetAcs = new SecInfoSetAcs();
                SecInfoSet secInfoSet = new SecInfoSet();

                status = secInfoSetAcs.ExecuteGuid(this._enterpriseCode, false, out secInfoSet);
                if (status == 0)
                {
                    this.tNedit_SectionCodeAllowZero.Text = secInfoSet.SectionCode.Trim();
                    this.uLabel_SectionName.Text = secInfoSet.SectionGuideNm.Trim();
                    tNedit_CustomerCodeAllowZero.Focus();
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
        /// <br>Programmer : �{�{����</br>
        /// <br>Date       : 2015/01/20</br>
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
                        this.uLabel_BlGoodsNameSt.Text = blGoodsUnit.BLGoodsHalfName;
                        this.tEdit_BlGoodsCodeEd.Focus();
                    }
                    else if ((Control)sender == this.tEdit_BlGoodsCodeEd
                        || (Control)sender == this.uButton_BlGoodsCodeEd)
                    {
                        this.tEdit_BlGoodsCodeEd.Text = blGoodsUnit.BLGoodsCode.ToString().PadLeft(5, '0');
                        this.uLabel_BlGoodsNameEd.Text = blGoodsUnit.BLGoodsHalfName;
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
        /// BL�R�[�hAfterEnterEditMode�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : �a�k�R�[�h�C�x���g</br>
        /// <br>Programmer : �{�{����</br>
        /// <br>Date       : 2015/01/20</br>
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

        #region �񕝎�������
        /// <summary>
        /// �񕝎��������`�F�b�N�{�b�N�X�̕ύX
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : �񕝎��������`�F�b�N�{�b�N�X�̕ύX�B</br>
        /// <br>Programmer : �{�{����</br>
        /// <br>Date       : 2015/01/20</br>
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
        /// <br>Programmer : �{�{����</br>
        /// <br>Date       : 2015/01/20</br>
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
                editBand.Columns[this._recGoodsLkStAcs.RecGoodsLkDataTable.RowNoColumn.ColumnName].Width = 40;            // ��
                editBand.Columns[this._recGoodsLkStAcs.RecGoodsLkDataTable.UpdateTimeColumn.ColumnName].Width = 80;       // �폜��
                editBand.Columns[this._recGoodsLkStAcs.RecGoodsLkDataTable.InqOtherSecCdColumn.ColumnName].Width = 60;     // ���_�R�[�h
                editBand.Columns[this._recGoodsLkStAcs.RecGoodsLkDataTable.InqOtherSecNmColumn.ColumnName].Width = 180;     // ���_����
                editBand.Columns[this._recGoodsLkStAcs.RecGoodsLkDataTable.CustomerCodeColumn.ColumnName].Width = 80;     // ���Ӑ�R�[�h
                editBand.Columns[this._recGoodsLkStAcs.RecGoodsLkDataTable.CustomerSnmColumn.ColumnName].Width = 180;     // ���Ӑ旪��
                editBand.Columns[this._recGoodsLkStAcs.RecGoodsLkDataTable.RecSourceBLGoodsCdColumn.ColumnName].Width = 70; // ������BL�R�[�h
                editBand.Columns[this._recGoodsLkStAcs.RecGoodsLkDataTable.RecSourceBLGoodsNmColumn.ColumnName].Width = 240; // ������BL�R�[�h��
                editBand.Columns[this._recGoodsLkStAcs.RecGoodsLkDataTable.RecDestBLGoodsCdColumn.ColumnName].Width = 70;    // ������BL�R�[�h
                editBand.Columns[this._recGoodsLkStAcs.RecGoodsLkDataTable.RecDestBLGoodsNmColumn.ColumnName].Width = 240;   // ������BL�R�[�h��
                editBand.Columns[this._recGoodsLkStAcs.RecGoodsLkDataTable.GoodsCommentColumn.ColumnName].Width = 400;   // ���i�R�����g
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
        /// <br>Programmer : �{�{����</br>
        /// <br>Date       : 2015/01/20</br>
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
        /// <br>Programmer : �{�{����</br>
        /// <br>Date       : 2015/01/20</br>
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
        /// <br>Programmer : �{�{����</br>
        /// <br>Date       : 2015/01/20</br>
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
                    if (this._recGoodsLkStAcs.CompareSearchCondition(this._searchCondition, searchCondition))
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

            this._extrInfoForPrint = searchCondition; // ADD 2014/03/05 �c���� Redmine#42247

            // ���o����ʕ��i�̃C���X�^���X���쐬
            SFCMN00299CA msgForm = new SFCMN00299CA();
            msgForm.Title = "����������";
            msgForm.Message = "�����������ł��B";
            msgForm.Show();

            string errMess = string.Empty;
            int count = 0;
            // ��������
            int status = this._recGoodsLkStAcs.Search(searchCondition,out count, out errMess);

            msgForm.Close();

            // �\�[�g�ݒ�̉���
            this._detailInput.uGrid_Details.DisplayLayout.Bands[0].SortedColumns.Clear();
            this._detailInput.uGrid_Details.DisplayLayout.Bands[0].SortedColumns.RefreshSort(true);

            #region ��������
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                //�폜�w��敪=�ʏ�̏ꍇ
                if (this.tComboEditor_DeleteFlag.SelectedIndex == 0)
                {
                    this._detailInput.LeftFocusFlg = false;
                }
                else
                {
                    this._detailInput.LeftFocusFlg = true;
                }

                this._searchCondition = searchCondition;
                // ������A���ו��ݒ菈��
                this._detailInput.GridSettingAfterSearch(this._recGoodsLkStAcs.DeleteSearchMode);
                if (this.tComboEditor_DeleteFlag.SelectedIndex == 0)
                {
                    if (this.tNedit_SectionCodeAllowZero.GetInt() != 0)
                    {
                        if (this._detailInput.uGrid_Details.Rows.Count > 0)
                        {
                            // --- UPD 2015/03/12 Y.Wakita ---------->>>>>
                            //this._detailInput.uGrid_Details.Rows[this._detailInput.uGrid_Details.Rows.Count - 1].Cells[this._recGoodsLkStAcs.RecGoodsLkDataTable.InqOtherSecCdColumn.ColumnName].Value = this.tNedit_SectionCodeAllowZero.GetInt();
                            this._detailInput.uGrid_Details.Rows[this._detailInput.uGrid_Details.Rows.Count - 1].Cells[this._recGoodsLkStAcs.RecGoodsLkDataTable.InqOtherSecCdColumn.ColumnName].Value = this.tNedit_SectionCodeAllowZero.DataText;
                            // --- UPD 2015/03/12 Y.Wakita ----------<<<<<
                            this._detailInput.uGrid_Details.Rows[this._detailInput.uGrid_Details.Rows.Count - 1].Cells[this._recGoodsLkStAcs.RecGoodsLkDataTable.InqOtherSecNmColumn.ColumnName].Value = this.uLabel_SectionName.Text.Trim();
                            this._detailInput.uGrid_Details.Rows[this._detailInput.uGrid_Details.Rows.Count - 1].Cells[this._recGoodsLkStAcs.RecGoodsLkDataTable.CustomerCodeColumn.ColumnName].Activate();
                            if (this.tNedit_CustomerCodeAllowZero.GetInt() != 0)
                            {
                                this._detailInput.uGrid_Details.Rows[this._detailInput.uGrid_Details.Rows.Count - 1].Cells[this._recGoodsLkStAcs.RecGoodsLkDataTable.CustomerCodeColumn.ColumnName].Value = this.tNedit_CustomerCodeAllowZero.GetInt();
                                this._detailInput.uGrid_Details.Rows[this._detailInput.uGrid_Details.Rows.Count - 1].Cells[this._recGoodsLkStAcs.RecGoodsLkDataTable.CustomerSnmColumn.ColumnName].Value = this.uLabel_CustomerName.Text.Trim();
                                this._detailInput.uGrid_Details.Rows[this._detailInput.uGrid_Details.Rows.Count - 1].Cells[this._recGoodsLkStAcs.RecGoodsLkDataTable.RecSourceBLGoodsCdColumn.ColumnName].Activate();
                            }
                            this._detailInput.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                            SetGuidButton(false);
                        }
                        else
                        {
                            SetGuidButton(false);
                        }
                    }
                    else if (this.tNedit_CustomerCodeAllowZero.GetInt() != 0)
                    {
                        if (this._detailInput.uGrid_Details.Rows.Count > 0)
                        {
                            this._detailInput.uGrid_Details.Rows[this._detailInput.uGrid_Details.Rows.Count - 1].Cells[this._recGoodsLkStAcs.RecGoodsLkDataTable.CustomerCodeColumn.ColumnName].Value = this.tNedit_CustomerCodeAllowZero.GetInt();
                            this._detailInput.uGrid_Details.Rows[this._detailInput.uGrid_Details.Rows.Count - 1].Cells[this._recGoodsLkStAcs.RecGoodsLkDataTable.CustomerSnmColumn.ColumnName].Value = this.uLabel_CustomerName.Text.Trim();
                            this._detailInput.uGrid_Details.Rows[this._detailInput.uGrid_Details.Rows.Count - 1].Cells[this._recGoodsLkStAcs.RecGoodsLkDataTable.InqOtherSecCdColumn.ColumnName].Activate();
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
                            this._detailInput.uGrid_Details.Rows[this._detailInput.uGrid_Details.Rows.Count - 1].Cells[this._recGoodsLkStAcs.RecGoodsLkDataTable.InqOtherSecCdColumn.ColumnName].Activate();
                            this._detailInput.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                            SetGuidButton(true);
                        }
                        else
                        {
                            SetGuidButton(false);
                        }
                    }
                    // --- ADD 2015/02/12 T.Miyamoto ����ýď�Q#196 ------------------------------>>>>>
                    if (this.tNedit_CustomerCodeAllowZero.GetInt() != 0)
                    {
                        this._detailInput.CustomerCheck_Detail(this.tNedit_CustomerCodeAllowZero.GetInt(), this._detailInput.uGrid_Details.Rows.Count - 1);
                    }
                    // --- ADD 2015/02/12 T.Miyamoto ����ýď�Q#196 ------------------------------<<<<<
                    RecGoodsLkSt recGoodsLkSt = null;
                    this._recGoodsLkStAcs.CopyToRecGoodsLkFromDetailRow((RecGoodsLkDataSet.RecGoodsLkRow)this._recGoodsLkStAcs.RecGoodsLkDataTable.Rows[this._recGoodsLkStAcs.RecGoodsLkDataTable.Count - 1], ref recGoodsLkSt);
                    this._recGoodsLkStAcs.NewRecGoodsLkObj = recGoodsLkSt.Clone();
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
                // --- UPD 2015/02/09 T.Miyamoto �T���v���捞�@�\�ǉ� ------------------------------>>>>>
                //TMsgDisp.Show(
                //            this,
                //            emErrorLevel.ERR_LEVEL_INFO,
                //            this.Name,
                //            "���������ɊY������f�[�^�����݂��܂���B",
                //            0,
                //            MessageBoxButtons.OK);
                if (searchCondition.RecSourceBLGoodsCdSt == 0 &&
                    searchCondition.RecSourceBLGoodsCdEd == 99999 &&
                    searchCondition.DeleteFlag == 0)
                {
                    DialogResult dialogResult = TMsgDisp.Show(this
                                                             , emErrorLevel.ERR_LEVEL_INFO
                                                             , this.Name
                                                             , "���������ɊY������f�[�^�����݂��܂���B" + "\r\n" + "\r\n" +
                                                               "�T���v���捞�����s���܂����H"
                                                             , 0
                                                             , MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        // --- UPD 2015/02/10�C T.Miyamoto ------------------------------>>>>>
                        //this.SampleSetting();
                        this.SampleSetting(true);
                        // --- UPD 2015/02/10�C T.Miyamoto ------------------------------<<<<<
                        return;

                        // --- ADD 2015/02/20 T.Nishi ------------------------------>>>>>
                        adjustButtonEnable();
                        // --- ADD 2015/02/20 T.Nishi ------------------------------<<<<<
                    }
                }
                else
                {
                    TMsgDisp.Show(this
                                 ,emErrorLevel.ERR_LEVEL_INFO
                                 ,this.Name
                                 ,"���������ɊY������f�[�^�����݂��܂���B"
                                 ,0
                                 ,MessageBoxButtons.OK);
                }
                // --- UPD 2015/02/09 T.Miyamoto �T���v���捞�@�\�ǉ� ------------------------------<<<<<

                this._searchCondition = searchCondition;
                // ������A���ו��ݒ菈��
                this._detailInput.GridSettingAfterSearch(this._recGoodsLkStAcs.DeleteSearchMode);

                //�폜�w��敪=�ʏ�̏ꍇ
                if (this.tComboEditor_DeleteFlag.SelectedIndex == 0)
                {
                    this._detailInput.Clear(true);
                    this._detailInput.SetButtonEnabled(1);

                    if (this.tNedit_SectionCodeAllowZero.GetInt() != 0)
                    {
                        if (this._detailInput.uGrid_Details.Rows.Count > 0)
                        {
                            // --- UPD 2015/03/12 Y.Wakita ---------->>>>>
                            //this._detailInput.uGrid_Details.Rows[this._detailInput.uGrid_Details.Rows.Count - 1].Cells[this._recGoodsLkStAcs.RecGoodsLkDataTable.InqOtherSecCdColumn.ColumnName].Value = this.tNedit_SectionCodeAllowZero.GetInt();
                            this._detailInput.uGrid_Details.Rows[this._detailInput.uGrid_Details.Rows.Count - 1].Cells[this._recGoodsLkStAcs.RecGoodsLkDataTable.InqOtherSecCdColumn.ColumnName].Value = this.tNedit_SectionCodeAllowZero.DataText;
                            // --- UPD 2015/03/12 Y.Wakita ----------<<<<<
                            this._detailInput.uGrid_Details.Rows[this._detailInput.uGrid_Details.Rows.Count - 1].Cells[this._recGoodsLkStAcs.RecGoodsLkDataTable.InqOtherSecNmColumn.ColumnName].Value = this.uLabel_SectionName.Text.Trim();
                            this._detailInput.uGrid_Details.Rows[this._detailInput.uGrid_Details.Rows.Count - 1].Cells[this._recGoodsLkStAcs.RecGoodsLkDataTable.CustomerCodeColumn.ColumnName].Activate();
                            if (this.tNedit_CustomerCodeAllowZero.GetInt() != 0)
                            {
                                this._detailInput.uGrid_Details.Rows[this._detailInput.uGrid_Details.Rows.Count - 1].Cells[this._recGoodsLkStAcs.RecGoodsLkDataTable.CustomerCodeColumn.ColumnName].Value = this.tNedit_CustomerCodeAllowZero.GetInt();
                                this._detailInput.uGrid_Details.Rows[this._detailInput.uGrid_Details.Rows.Count - 1].Cells[this._recGoodsLkStAcs.RecGoodsLkDataTable.CustomerSnmColumn.ColumnName].Value = this.uLabel_CustomerName.Text.Trim();
                                this._detailInput.uGrid_Details.Rows[this._detailInput.uGrid_Details.Rows.Count - 1].Cells[this._recGoodsLkStAcs.RecGoodsLkDataTable.RecSourceBLGoodsCdColumn.ColumnName].Activate();
                            }
                            this._detailInput.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                            SetGuidButton(false);
                        }
                        else
                        {
                            SetGuidButton(false);
                        }
                    }
                    else if (this.tNedit_CustomerCodeAllowZero.GetInt() != 0)
                    {
                        if (this._detailInput.uGrid_Details.Rows.Count > 0)
                        {
                            this._detailInput.uGrid_Details.Rows[this._detailInput.uGrid_Details.Rows.Count - 1].Cells[this._recGoodsLkStAcs.RecGoodsLkDataTable.CustomerCodeColumn.ColumnName].Activate();

                            this._detailInput.uGrid_Details.Rows[this._detailInput.uGrid_Details.Rows.Count - 1].Cells[this._recGoodsLkStAcs.RecGoodsLkDataTable.CustomerCodeColumn.ColumnName].Value = this.tNedit_CustomerCodeAllowZero.GetInt();
                            this._detailInput.uGrid_Details.Rows[this._detailInput.uGrid_Details.Rows.Count - 1].Cells[this._recGoodsLkStAcs.RecGoodsLkDataTable.CustomerSnmColumn.ColumnName].Value = this.uLabel_CustomerName.Text.Trim();
                            this._detailInput.uGrid_Details.Rows[this._detailInput.uGrid_Details.Rows.Count - 1].Cells[this._recGoodsLkStAcs.RecGoodsLkDataTable.InqOtherSecCdColumn.ColumnName].Activate();
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
                            this._detailInput.uGrid_Details.Rows[this._detailInput.uGrid_Details.Rows.Count - 1].Cells[this._recGoodsLkStAcs.RecGoodsLkDataTable.InqOtherSecCdColumn.ColumnName].Activate();
                            this._detailInput.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                            SetGuidButton(true);
                        }
                        else
                        {
                            SetGuidButton(false);
                        }
                    }
                    // --- ADD 2015/02/12 T.Miyamoto ����ýď�Q#196 ------------------------------>>>>>
                    if (this.tNedit_CustomerCodeAllowZero.GetInt() != 0)
                    {
                        this._detailInput.CustomerCheck_Detail(this.tNedit_CustomerCodeAllowZero.GetInt(), this._detailInput.uGrid_Details.Rows.Count - 1);
                    }
                    // --- ADD 2015/02/12 T.Miyamoto ����ýď�Q#196 ------------------------------<<<<<
                    RecGoodsLkSt recGoodsLkSt = null;
                    this._recGoodsLkStAcs.CopyToRecGoodsLkFromDetailRow((RecGoodsLkDataSet.RecGoodsLkRow)this._recGoodsLkStAcs.RecGoodsLkDataTable.Rows[this._recGoodsLkStAcs.RecGoodsLkDataTable.Count - 1], ref recGoodsLkSt);
                    this._recGoodsLkStAcs.NewRecGoodsLkObj = recGoodsLkSt.Clone();
                }
                //�폜�w��敪=�폜���݂̂̏ꍇ
                else
                {
                    this._detailInput.SetButtonEnabled(3);

                    this._recGoodsLkStAcs.PrevRecGoodsLkDic.Clear();
                    // ����DataTable�s�N���A����
                    this._recGoodsLkStAcs.RecGoodsLkDataTable.Rows.Clear();

                    this._detailInput.uGrid_Details.DisplayLayout.Bands[0].Columns[this._recGoodsLkStAcs.RecGoodsLkDataTable.UpdateTimeColumn.ColumnName].Hidden = true;

                    this.tNedit_SectionCodeAllowZero.Focus();
                    SetGuidButton(true);
                }
            }
            else
            {
                // �T�[�`
                TMsgDisp.Show(
                    this, 								// �e�E�B���h�E�t�H�[��
                    emErrorLevel.ERR_LEVEL_STOP, 		// �G���[���x��
                    "PMREC09011U", 						// �A�Z���u���h�c�܂��̓N���X�h�c
                    "���R�����h���i�֘A�ݒ�}�X�^",     // �v���O��������
                    "Search", 							// ��������
                    TMsgDisp.OPE_GET, 					// �I�y���[�V����
                    "�ǂݍ��݂Ɏ��s���܂����B", 		// �\�����郁�b�Z�[�W
                    status, 							// �X�e�[�^�X�l
                    this._recGoodsLkStAcs,               // �G���[�����������I�u�W�F�N�g
                    MessageBoxButtons.OK, 				// �\������{�^��
                    MessageBoxDefaultButton.Button1);	// �����\���{�^��
            }
            // --- ADD 2015/02/20 T.Nishi ------------------------------>>>>>
            adjustButtonEnable();
            // --- ADD 2015/02/20 T.Nishi ------------------------------<<<<<
            #endregion
        }

        /// <summary>
        /// �����O�A�`�F�b�N����
        /// </summary>
        /// <param name="searchCondition">��������</param>
        /// <returns>bool</returns>
        /// <remarks>
        /// <br>Note       : �����O�A�`�F�b�N�������s���܂��B</br>
        /// <br>Programmer : �{�{����</br>
        /// <br>Date       : 2015/01/20</br>
        /// </remarks>
        private bool SearchCheck(SearchCondition searchCondition)
        {
            List<RecGoodsLkSt> deleteList;
            List<RecGoodsLkSt> updateList;

            // �폜�w��敪=0�̏ꍇ
            if (this._recGoodsLkStAcs.DeleteSearchMode == false)
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

            // ������BL�R�[�h�͈̔̓`�F�b�N
            if (searchCondition.RecSourceBLGoodsCdSt > searchCondition.RecSourceBLGoodsCdEd)
            {
                TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_EXCLAMATION,
                            this.Name,
                            "������BL�R�[�h�͈͎̔w��Ɍ�肪����܂��B",
                            0,
                            MessageBoxButtons.OK);
                this.tEdit_BlGoodsCodeSt.Focus();
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
        /// <br>Programmer : �{�{����</br>
        /// <br>Date       : 2015/01/20</br>
        /// </remarks>
        private int Save()
        {
            List<RecGoodsLkSt> deleteList;
            List<RecGoodsLkSt> updateList;

            int status = 0;
            RecGoodsLkSt errorRecGoodsLkObj = null;
            // �폜�w��敪=0�̏ꍇ
            if (this._recGoodsLkStAcs.DeleteSearchMode == false)
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

                status = this._recGoodsLkStAcs.SaveProc(deleteList, updateList, out errorRecGoodsLkObj);

                string errorMsg = string.Empty;
                if (errorRecGoodsLkObj != null)
                {
                    TMsgDisp.Show(this
                                 ,emErrorLevel.ERR_LEVEL_EXCLAMATION
                                 ,this.Name
                                 ,"����̏��i�ݒ肪���ɓo�^����Ă��܂��B" + "\r\n" +
                                  "�E���_����  �@�F" + errorRecGoodsLkObj.InqOtherSecCd.PadLeft(2, '0') + "\r\n" +
                                  "�E���Ӑ溰�ށ@�F" + errorRecGoodsLkObj.CustomerCode.ToString().PadLeft(8, '0') + "\r\n" +
                                  "�E������BL���ށF" + errorRecGoodsLkObj.RecSourceBLGoodsCd.ToString().PadLeft(5, '0') + "\r\n" +
                                  "�E������BL���ށF" + errorRecGoodsLkObj.RecDestBLGoodsCd.ToString().PadLeft(5, '0')
                                 ,0
                                 ,MessageBoxButtons.OK);
                        return -1;
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

                status = this._recGoodsLkStAcs.SaveProc(deleteList, updateList, out errorRecGoodsLkObj);
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
                        this.tNedit_SectionCodeAllowZero.Focus();
                        this.SetGuidButton(true);
                        this.SetSampleButton(false); // ADD 2015/03/05 Y.Wakita Redmine#328

                        adjustButtonEnable(); // ADD 2015/03/03 T.Miyamoto Redmine#302

                        RecGoodsLkSt recGoodsLkSt = null;
                        this._recGoodsLkStAcs.CopyToRecGoodsLkFromDetailRow((RecGoodsLkDataSet.RecGoodsLkRow)this._recGoodsLkStAcs.RecGoodsLkDataTable.Rows[this._recGoodsLkStAcs.RecGoodsLkDataTable.Count - 1], ref recGoodsLkSt);
                        this._recGoodsLkStAcs.NewRecGoodsLkObj = recGoodsLkSt.Clone();

                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    {
                        TMsgDisp.Show(
                            this, 									// �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_INFO, 			// �G���[���x��
                            "PMREC09011U",				        	// �A�Z���u���h�c�܂��̓N���X�h�c
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
                            "PMREC09011U",				        	// �A�Z���u���h�c�܂��̓N���X�h�c
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
                            "PMREC09011U", 						// �A�Z���u���h�c�܂��̓N���X�h�c
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
                            "PMREC09011U", 						// �A�Z���u���h�c�܂��̓N���X�h�c
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
                           "PMREC09011U",                        // �A�Z���u���h�c�܂��̓N���X�h�c
                           "���R�����h���i�֘A�ݒ�}�X�^",       // �v���O��������
                           "Save",                               // ��������
                           TMsgDisp.OPE_UPDATE,                  // �I�y���[�V����
                           "�o�^�Ɏ��s���܂����B",               // �\�����郁�b�Z�[�W
                           status,                               // �X�e�[�^�X�l
                           this._recGoodsLkStAcs,                 // �G���[�����������I�u�W�F�N�g
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
        /// <br>Programmer : �{�{����</br>
        /// <br>Date       : 2015/01/20</br>
        /// </remarks>
        private void Clear()
        {
            bool clearFlg = false;
            #region �N���A�����O�A�ҏW�s�`�F�b�N
            List<RecGoodsLkSt> deleteList;
            List<RecGoodsLkSt> updateList;

            if (this._recGoodsLkStAcs.DeleteSearchMode == false)
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

                //// �\�[�g�ݒ�̉���
                //this._detailInput.uGrid_Details.DisplayLayout.Bands[0].SortedColumns.Clear();

                // �����t�H�[�J�X�ݒ�
                //�w�b�_�̏�Ԃɂ���ăt�H�[�J�X�ʒu�𒲐�
                //�O���[�v�{�b�N�X�i���Ӑ�j���J���Ă���ꍇ�͓��Ӑ�R�[�h�Ƀt�H�[�J�X�J��
                if (this.uExGroupBox_CommonCondition.Expanded == true)
                {
                    this.tNedit_SectionCodeAllowZero.Focus();
                }
                else
                {
                  //�O���[�v�{�b�N�X�i���Ӑ�j���J���Ă��炸�A
                    //�O���[�v�{�b�N�X�iBL�R�[�h�j���J���Ă���ꍇ��BL�R�[�h�i�J�n�j�Ƀt�H�[�J�X�J��
                    if (this.uExGroupBox_ExtraCondition.Expanded == true)
                    {
                        this.tEdit_BlGoodsCodeSt.Focus();
                    }
                    else
                    //�O���[�v�{�b�N�X���J���Ă��Ȃ��ꍇ�̓O���[�v�{�b�N�X�i���Ӑ�j�Ƀt�H�[�J�X�J��
                    {
                        this.uExGroupBox_CommonCondition.Focus();
                    }
                }
                this.SetGuidButton(true);
                this.SetSampleButton(false); // ADD 2015/02/06 T.Miyamoto �T���v���捞�@�\�ǉ�

                // --- ADD 2015/02/20 T.Nishi ------------------------------>>>>>
                adjustButtonEnable(); 
                // --- ADD 2015/02/20 T.Nishi ------------------------------<<<<<
            }
        }

        /// <summary>
        /// ����������������������
        /// </summary>
        /// <remarks>
        /// <br>Note       : ����������������������</br>
        /// <br>Programmer : �{�{����</br>
        /// <br>Date       : 2015/01/20</br>
        /// </remarks>
        private void ConditionClear()
        {
            #region ��{�����N���A
            this.tNedit_SectionCodeAllowZero.Clear();
            this.uLabel_SectionName.Text = string.Empty;
            this.tNedit_CustomerCodeAllowZero.Clear();
            this.uLabel_CustomerName.Text = string.Empty;
            #endregion

            #region ���o�����N���A
            this.tEdit_BlGoodsCodeSt.Clear();
            this.uLabel_BlGoodsNameSt.Text = string.Empty;
            this.tEdit_BlGoodsCodeEd.Clear();
            this.uLabel_BlGoodsNameEd.Text = string.Empty;
            this.tComboEditor_DeleteFlag.SelectedIndex = 0;
            #endregion
        }
        
        /// <summary>
        /// ��ʃN���[�Y����
        /// </summary>
        /// <param name="boolean">boolean</param>
        /// <remarks>
        /// <br>Note       : ��ʃN���[�Y�������s���܂��B</br>
        /// <br>Programmer : �{�{����</br>
        /// <br>Date       : 2015/01/20</br>
        /// </remarks>
        private void Close(bool boolean)
        {
            List<RecGoodsLkSt> deleteList;
            List<RecGoodsLkSt> updateList;

            if (this._recGoodsLkStAcs.DeleteSearchMode == false)
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

        /// <summary>
        /// �K�C�h�N������
        /// </summary>
        /// <remarks>
        /// <br>Note       : �K�C�h�N���������s���܂��B</br>
        /// <br>Programmer : �{�{����</br>
        /// <br>Date       : 2015/01/20</br>
        /// </remarks>
        private void GuideStart()
        {
            // ���_
            if (this.tNedit_SectionCodeAllowZero.Focused)
            {
                this.uButton_SectionGuide_Click(this.tNedit_SectionCodeAllowZero, new EventArgs());
            }
            // ���Ӑ�
            else if (this.tNedit_CustomerCodeAllowZero.Focused)
            {
                this.uButton_CustomerGuide_Click(this.tNedit_CustomerCodeAllowZero, new EventArgs());
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
            // �O���b�h
            else
            {

                int rowIndex = -1;
                string keyName = this._detailInput.GetFocusColumnKey(out rowIndex);
                if (!string.Empty.Equals(keyName))
                {
                    switch (keyName)
                    {
                        case "InqOtherSecCd":
                            {
                                this._detailInput.SectionCodeGuide(rowIndex);
                                break;
                            }
                        case "CustomerCode":
                            {
                                this._detailInput.CustomerCodeGuide(rowIndex);
                                break;
                            }
                        case "RecSourceBLGoodsCd":
                        case "RecDestBLGoodsCd":
                            {
                                this._detailInput.BLGoodsCodeGuide(rowIndex, keyName);
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
        /// <br>Programmer : �{�{����</br>
        /// <br>Date       : 2015/01/20</br>
        /// </remarks>
        private void ReNewal()
        {
            ReadCustomerSearchRet(); // ���Ӑ���Ǎ�����

            SFCMN00299CA processingDialog = new SFCMN00299CA();
            try
            {
                processingDialog.Title = "�ŐV���擾";
                processingDialog.Message = "���݁A�ŐV���擾���ł��B";
                processingDialog.DispCancelButton = false;
                processingDialog.Show((Form)this.Parent);

                this._recGoodsLkStAcs.LoadMstData();

                while (this._recGoodsLkStAcs.MasterAcsThread.ThreadState == System.Threading.ThreadState.Running)
                {
                    Thread.Sleep(100);
                }
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

        // --- ADD 2015/02/06 T.Miyamoto �T���v���捞�@�\�ǉ� ------------------------------>>>>>
        /// <summary>
        /// �T���v���捞�擾����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �T���v���捞�������s���܂��B</br>
        /// <br>Programmer : �{�{����</br>
        /// <br>Date       : 2015/02/06</br>
        /// </remarks>
        private void SampleSetting(bool SetFlg)
        {
            // ���_�E���Ӑ���͉�ʕ\��
            PMREC09011UC SampleDialog = new PMREC09011UC();
            // --- ADD 2015/02/10�C T.Miyamoto ------------------------------>>>>>
            SampleDialog.SampleSecCd = string.Empty;
            SampleDialog.SampleSecNm = string.Empty;
            SampleDialog.SampleCustomerInfo = new CustomerInfo();
            SampleDialog.SampleCustomerInfo.CustomerCode = -1; // ADD 2015/03/03 T.Miyamoto Redmine#308
            if (SetFlg)
            {
                SampleDialog.SampleSecCd = this.tNedit_SectionCodeAllowZero.DataText.Trim();
                SampleDialog.SampleSecNm = this.uLabel_SectionName.Text.Trim();
                // --- UPD 2015/03/03 T.Miyamoto Redmine#308 ------------------------------>>>>>
                //SampleDialog.SampleCustomerInfo.CustomerCode = this.tNedit_CustomerCodeAllowZero.GetInt();
                if (this.tNedit_CustomerCodeAllowZero.DataText.Trim() != string.Empty)
                {
                    SampleDialog.SampleCustomerInfo.CustomerCode = this.tNedit_CustomerCodeAllowZero.GetInt();
                }
                // --- UPD 2015/03/03 T.Miyamoto Redmine#308 ------------------------------<<<<<
                SampleDialog.SampleCustomerInfo.CustomerSnm = this.uLabel_CustomerName.Text.Trim();
            }
            // --- ADD 2015/02/10�C T.Miyamoto ------------------------------<<<<<
            DialogResult dialogResult = SampleDialog.ShowDialog();
            SampleDialog.Close();
            if (dialogResult == DialogResult.OK)
            {
                this.SampleDataSet(SampleDialog.SampleSecCd, SampleDialog.SampleSecNm, SampleDialog.SampleCustomerInfo);
            }
        }

        /// <summary>
        /// �T���v���捞�f�[�^�i�񋟁j�Ǎ�����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �T���v���捞�������s���܂��B</br>
        /// <br>Programmer : �{�{����</br>
        /// <br>Date       : 2015/02/06</br>
        /// </remarks>
        private void SampleDataSet(string sampleSecCd, string sampleSecNm, CustomerInfo sampleCustomerInfo)
        {
            int status = 0;
            string errMess = string.Empty;
            this._recGoodsLkStAcs.SampleSecCd = sampleSecCd;
            this._recGoodsLkStAcs.SampleSecNm = sampleSecNm;
            this._recGoodsLkStAcs.SampleCustomerInfo = sampleCustomerInfo;
            

            // --- UPD 2015/03/02 T.Miyamoto ------------------------------>>>>>
            //status = this._recGoodsLkStAcs.SampleCheck(out errMess);
            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            if (!this._detailInput.CheckSampleData(sampleSecCd, sampleSecNm, sampleCustomerInfo))
            {
                status = this._recGoodsLkStAcs.SampleCheck(out errMess);
            }
            // --- UPD 2015/03/02 T.Miyamoto ------------------------------<<<<<
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                TMsgDisp.Show(this
                             , emErrorLevel.ERR_LEVEL_INFO
                             , this.Name
                             , "���ɏ��i�֘A�ݒ肪�o�^����Ă��܂��B"
                             , 0
                             , MessageBoxButtons.OK);
                return;
            }

            status = this._recGoodsLkStAcs.SampleSearch(out errMess);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // �T���v���ݒ�捞��A���ו��ݒ菈��
                this._detailInput.GridSettingAfterSampleSet();

                // �V�K�s�Ɋ�{���̋��_�E���Ӑ���Z�b�g
                if (this.tNedit_SectionCodeAllowZero.GetInt() != 0)
                {
                    // --- UPD 2015/03/12 Y.Wakita ---------->>>>>
                    //this._detailInput.uGrid_Details.Rows[this._detailInput.uGrid_Details.Rows.Count - 1].Cells[this._recGoodsLkStAcs.RecGoodsLkDataTable.InqOtherSecCdColumn.ColumnName].Value = this.tNedit_SectionCodeAllowZero.GetInt();
                    this._detailInput.uGrid_Details.Rows[this._detailInput.uGrid_Details.Rows.Count - 1].Cells[this._recGoodsLkStAcs.RecGoodsLkDataTable.InqOtherSecCdColumn.ColumnName].Value = this.tNedit_SectionCodeAllowZero.DataText;
                    // --- UPD 2015/03/12 Y.Wakita ----------<<<<<
                    this._detailInput.uGrid_Details.Rows[this._detailInput.uGrid_Details.Rows.Count - 1].Cells[this._recGoodsLkStAcs.RecGoodsLkDataTable.InqOtherSecNmColumn.ColumnName].Value = this.uLabel_SectionName.Text.Trim();
                }
                if (this.tNedit_CustomerCodeAllowZero.GetInt() != 0)
                {
                    this._detailInput.uGrid_Details.Rows[this._detailInput.uGrid_Details.Rows.Count - 1].Cells[this._recGoodsLkStAcs.RecGoodsLkDataTable.CustomerCodeColumn.ColumnName].Value = this.tNedit_CustomerCodeAllowZero.GetInt();
                    this._detailInput.uGrid_Details.Rows[this._detailInput.uGrid_Details.Rows.Count - 1].Cells[this._recGoodsLkStAcs.RecGoodsLkDataTable.CustomerSnmColumn.ColumnName].Value = this.uLabel_CustomerName.Text.Trim();
                    // --- ADD 2015/02/12 T.Miyamoto ����ýď�Q#196 ------------------------------>>>>>
                    this._detailInput.CustomerCheck_Detail(this.tNedit_CustomerCodeAllowZero.GetInt(), this._detailInput.uGrid_Details.Rows.Count - 1);
                    // --- ADD 2015/02/12 T.Miyamoto ����ýď�Q#196 ------------------------------<<<<<
                }

                // �V�K�s�Ƀt�H�[�J�X�Z�b�g
                if (this.tNedit_SectionCodeAllowZero.GetInt() == 0)
                {
                    this._detailInput.uGrid_Details.Rows[this._detailInput.uGrid_Details.Rows.Count - 1].Cells[this._recGoodsLkStAcs.RecGoodsLkDataTable.InqOtherSecCdColumn.ColumnName].Activate();
                }
                else if (this.tNedit_CustomerCodeAllowZero.GetInt() == 0)
                {
                    this._detailInput.uGrid_Details.Rows[this._detailInput.uGrid_Details.Rows.Count - 1].Cells[this._recGoodsLkStAcs.RecGoodsLkDataTable.CustomerCodeColumn.ColumnName].Activate();
                }
                else
                {
                    this._detailInput.uGrid_Details.Rows[this._detailInput.uGrid_Details.Rows.Count - 1].Cells[this._recGoodsLkStAcs.RecGoodsLkDataTable.RecSourceBLGoodsCdColumn.ColumnName].Activate();
                }
                this._detailInput.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
            }
            else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
            {
                TMsgDisp.Show(this
                             ,emErrorLevel.ERR_LEVEL_INFO
                             ,this.Name
                             ,"���������ɊY������f�[�^�����݂��܂���B"
                             ,0
                             ,MessageBoxButtons.OK);
            }
            else
            {
                // �T�[�`
                TMsgDisp.Show(this
                             ,emErrorLevel.ERR_LEVEL_STOP
                             ,"PMREC09011U"
                             ,"���R�����h���i�֘A�ݒ�}�X�^"
                             , "SampleSetting"
                             ,TMsgDisp.OPE_GET
                             ,"�ǂݍ��݂Ɏ��s���܂����B"
                             ,status
                             ,this._recGoodsLkStAcs
                             ,MessageBoxButtons.OK
                             ,MessageBoxDefaultButton.Button1);
            }
        }
        // --- ADD 2015/02/06 T.Miyamoto ����َ捞�@�\�ǉ� ------------------------------<<<<<

        /// <summary>
        /// �ڍ׃O���b�h�ŏ�ʍs�A�v�C�x���g����
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : �ڍ׃O���b�h�ŏ�ʍs�A�v�E�����ɔ������܂��B</br>      
        /// <br>Programmer : �{�{����</br>                                  
        /// <br>Date       : 2015/01/20</br> 
        /// </remarks> 
        private void GriedDetail_GridKeyUpTopRow(object sender, EventArgs e)
        {
            Control control = null;
            if (this.uExGroupBox_ExtraCondition.Expanded == false)
            {
                control = this.tNedit_SectionCodeAllowZero;
                this.SetGuidButton(true);
            }
            else
            {
                control = this.tComboEditor_DeleteFlag;
                this.SetGuidButton(true);
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
        /// <br>Programmer : �{�{����</br>                                  
        /// <br>Date       : 2015/01/20</br> 
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
            searchCondition.InqOtherEpCd = this._enterpriseCode;
            // ���_�R�[�h
            flag = int.TryParse(this.tNedit_SectionCodeAllowZero.Text, out code);
            if (flag)
            {
                // --- UPD 2015/03/04 T.Miyamoto Redmine#193 ------------------------------>>>>>
                //searchCondition.InqOtherSecCd = code.ToString().PadLeft(2, '0');
                //// --- UPD 2015/02/10 ����ý�#174 T.Miyamoto -------------------->>>>>
                ////SecInfoSet secInfoSet = this._recGoodsLkStAcs.SecInfoSetDic[code.ToString().PadLeft(2, '0')];
                //if (searchCondition.InqOtherSecCd == "00")
                //{
                //    searchCondition.InqOtherSecCd = "";
                //}
                //else
                //{
                //    SecInfoSet secInfoSet = this._recGoodsLkStAcs.SecInfoSetDic[code.ToString().PadLeft(2, '0')];
                //}
                //// --- UPD 2015/02/10 ����ý�#174 T.Miyamoto --------------------<<<<<
                if (code.ToString().Trim() == string.Empty)
                {
                    searchCondition.InqOtherSecCd = string.Empty;
                }
                else
                {
                    searchCondition.InqOtherSecCd = code.ToString().PadLeft(2, '0');
                    if (searchCondition.InqOtherSecCd != "00")
                    {
                        SecInfoSet secInfoSet = this._recGoodsLkStAcs.SecInfoSetDic[code.ToString().PadLeft(2, '0')];
                    }
                }
                // --- UPD 2015/03/04 T.Miyamoto Redmine#193 ------------------------------<<<<<
            }
            else
            {
                searchCondition.InqOtherSecCd = "";
            }

            // ���Ӑ�R�[�h
            flag = int.TryParse(this.tNedit_CustomerCodeAllowZero.Text, out code);
            if (flag)
            {
                searchCondition.CustomerCode = code;
                // --- UPD 2015/03/03 T.Miyamoto Redmine#308 ------------------------------>>>>>
                //CustomerInfo customerInfo = this._recGoodsLkStAcs.CustomerDic[code];
                //searchCondition. InqOriginalEpCd = customerInfo.CustomerEpCode; //���Ӑ��ƃR�[�h
                //searchCondition.InqOriginalSecCd = customerInfo.CustomerSecCode; //���Ӑ拒�_�R�[�h
                if (code == 0)
                {
                    searchCondition.InqOriginalEpCd = "0000000000000000"; //���Ӑ��ƃR�[�h
                    searchCondition.InqOriginalSecCd = "000000";           //���Ӑ拒�_�R�[�h
                }
                else
                {
                    CustomerInfo customerInfo = this._recGoodsLkStAcs.CustomerDic[code];
                    searchCondition.InqOriginalEpCd = customerInfo.CustomerEpCode; //���Ӑ��ƃR�[�h
                    searchCondition.InqOriginalSecCd = customerInfo.CustomerSecCode; //���Ӑ拒�_�R�[�h
                }
                // --- UPD 2015/03/03 T.Miyamoto Redmine#308 ------------------------------<<<<<
            }
            else
            {
                searchCondition.CustomerCode = 0;
            }

            // ������BL�R�[�h�i�J�n�j
            flag = int.TryParse(this.tEdit_BlGoodsCodeSt.Text, out code);
            if (flag)
            {
                searchCondition.RecSourceBLGoodsCdSt = code;
            }
            else
            {
                searchCondition.RecSourceBLGoodsCdSt = 0;
            }

            // ������BL�R�[�h�i�I���j
            flag = int.TryParse(this.tEdit_BlGoodsCodeEd.Text, out code);
            if (flag)
            {
                searchCondition.RecSourceBLGoodsCdEd = code;
            }
            else
            {
                searchCondition.RecSourceBLGoodsCdEd = 99999;
            }

            // �폜�w��敪
            searchCondition.DeleteFlag = this.tComboEditor_DeleteFlag.SelectedIndex;
        }

        /// <summary>
        /// �K�C�h�{�^���ݒ菈��
        /// </summary>
        /// <param name="enable">enable</param>
        /// <remarks>
        /// <br>Note       : �K�C�h�{�^���ݒ菈�����s���܂��B</br>
        /// <br>Programmer : �{�{����</br>                                  
        /// <br>Date       : 2015/01/20</br> 
        /// </remarks>
        public void SetGuidButton(bool enable)
        {
            this.tToolsManager_MainMenu.Tools["ButtonTool_Guide"].SharedProps.Enabled = enable;
        }
        // --- ADD 2015/02/06 T.Miyamoto �T���v���捞�@�\�ǉ� ------------------------------>>>>>
        /// <summary>
        /// �T���v���捞�{�^���ݒ菈��
        /// </summary>
        /// <param name="enable">enable</param>
        /// <remarks>
        /// <br>Note       : �T���v���捞�{�^���ݒ菈�����s���܂��B</br>
        /// <br>Programmer : �{�{����</br>                                  
        /// <br>Date       : 2015/02/06</br> 
        /// </remarks>
        public void SetSampleButton(bool enable)
        {
            this.tToolsManager_MainMenu.Tools["ButtonTool_Sample"].SharedProps.Enabled = enable;
            // --- ADD 2015/03/05 Y.Wakita Redmine#326 ---------->>>>>
            if (this.tComboEditor_DeleteFlag.SelectedIndex == 1)
            {
                // 1:�폜���̂�
                this.tToolsManager_MainMenu.Tools["ButtonTool_Sample"].SharedProps.Enabled = false;
            }
            // --- ADD 2015/03/05 Y.Wakita Redmine#326 ----------<<<<<
        }
        // --- ADD 2015/02/06 T.Miyamoto �T���v���捞�@�\�ǉ� ------------------------------<<<<<

        /// <summary>
        /// ��ʏ������̎��A�t�H�[�J�X��ݒ肷��B
        /// </summary>
        /// <remarks>
        /// <br>Note       : ��ʏ������̎��A�t�H�[�J�X��ݒ肷��B</br>
        /// <br>Programmer : �{�{����</br>                                  
        /// <br>Date       : 2015/01/20</br> 
        /// </remarks>
        public void SetInitFocus()
        {
            this.tNedit_SectionCodeAllowZero.Focus();
        }

        /// <summary>
        /// ��ʂ̓��Ӑ�����擾����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ��ʂ̓��Ӑ�����擾����</br>
        /// <br>Programmer : �{�{����</br>
        /// <br>Date       : 2015/01/20</br>
        /// </remarks>
        public void GetCustomerInfo(out Int32 customerCode, out string customerName)
        {
            customerCode = 0;
            customerName = string.Empty;
            if (this.tNedit_CustomerCodeAllowZero.GetInt() != 0)
            {
                customerCode = this.tNedit_CustomerCodeAllowZero.GetInt();
                customerName = this.uLabel_CustomerName.Text.Trim();
            }
        }
        /// <summary>
        /// ��ʂ̋��_�����擾����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ��ʂ̋��_�����擾����</br>
        /// <br>Programmer : �{�{����</br>
        /// <br>Date       : 2015/01/20</br>
        /// </remarks>
        public void GetSectionInfo(out string sectionCode, out string sectionName)
        {
            sectionCode = string.Empty;
            sectionName = string.Empty;
            if (this.tNedit_SectionCodeAllowZero.GetInt() != 0)
            {
                sectionCode = this.tNedit_SectionCodeAllowZero.GetInt().ToString();
                sectionName = this.uLabel_SectionName.Text.Trim();
            }
        }

        #endregion

        /// <summary>
        /// ���Ӑ���Ǎ�����
        /// </summary>
        private void ReadCustomerSearchRet()
        {
            this._customerSearchRetDic = new Dictionary<int, CustomerSearchRet>();

            try
            {
                CustomerSearchRet[] retArray;

                CustomerSearchPara para = new CustomerSearchPara();
                para.EnterpriseCode = this._enterpriseCode;

                int status = this._customerSearchAcs.Serch(out retArray, para);
                if (status == 0)
                {
                    foreach (CustomerSearchRet ret in retArray)
                    {
                        if (ret.LogicalDeleteCode == 0)
                        {
                            this._customerSearchRetDic.Add(ret.CustomerCode, ret);
                        }
                    }
                }
            }
            catch
            {
                this._customerSearchRetDic = new Dictionary<int, CustomerSearchRet>();
            }
        }
        
        /// <summary>
        /// ���_���Ǎ�����
        /// </summary>
        private void ReadSectionSearchRet()
        {
            this._sectionSearchRetDic = new Dictionary<int, SecInfoSet>();

            try
            {
                ArrayList retArray = new ArrayList();

                int status = this._secInfoSetAcs.Search(out retArray, this._enterpriseCode);
                if (status == 0)
                {
                    foreach (SecInfoSet ret in retArray)
                    {
                        if (ret.LogicalDeleteCode == 0)
                        {
                            this._sectionSearchRetDic.Add(int.Parse(ret.SectionCode), ret);
                        }
                    }
                }
            }
            catch
            {
                this._sectionSearchRetDic = new Dictionary<int, SecInfoSet>();
            }
        }
        
        /// <summary>
        /// ���Ӑ�I���������C�x���g
        /// </summary>
        private void CustomerSearchForm_CustomerSelect(object sender, CustomerSearchRet customerSearchRet)
        {
            if (customerSearchRet == null)
            {
                this._cusotmerGuideSelected = false;
                return;
            }

            // ���Ӑ�R�[�h
            this.tNedit_CustomerCodeAllowZero.SetInt(customerSearchRet.CustomerCode);

            this._cusotmerGuideSelected = true;
        }

        /// <summary>
        /// ���Ӑ�`�F�b�N����
        /// </summary>
        // --- UPD 2015/03/03 T.Miyamoto Redmine#308 ------------------------------>>>>>
        //public bool CustomerCheck(int customerCode)
        public bool CustomerCheck(string sCustomerCode)
        // --- UPD 2015/03/03 T.Miyamoto Redmine#308 ------------------------------<<<<<
        {
            string errMsg;
            CustomerInfo retCustomerInfo;

            // --- ADD 2015/03/03 T.Miyamoto Redmine#308 ------------------------------>>>>>
            if (sCustomerCode.Trim() == string.Empty)
            {
                this.tNedit_CustomerCodeAllowZero.Clear();
                this.uLabel_CustomerName.Text = "";
                return true;
            }
            int customerCode = int.Parse(sCustomerCode);
            // --- ADD 2015/03/03 T.Miyamoto Redmine#308 ------------------------------<<<<<

            bool checkResult = this._recGoodsLkStAcs.CheckCustomer(customerCode, false, out errMsg, out retCustomerInfo);
            if (checkResult)
            {
                //���Ӑ�N���A
                this.tNedit_CustomerCodeAllowZero.Clear();
                this.uLabel_CustomerName.Text = "";

                this._prevCusotmerCd = 0;
                // --- ADD 2015/02/20 T.Nishi ------------------------------>>>>>
                if (customerCode == 0)
                {
                    // --- UPD 2015/03/03 T.Miyamoto Redmine#308 ------------------------------>>>>>
                    //this.tNedit_CustomerCodeAllowZero.SetInt(customerCode);      //���Ӑ�R�[�h
                    this.tNedit_CustomerCodeAllowZero.DataText = customerCode.ToString().PadLeft(8, '0');
                    // --- UPD 2015/03/03 T.Miyamoto Redmine#308 ------------------------------<<<<<
                    // --- UPD 2015/03/06 T.Miyamoto Redmine#338 ------------------------------>>>>>
                    //this.uLabel_CustomerName.Text = "�S���Ӑ�"; //���Ӑ旪��
                    this.uLabel_CustomerName.Text = RecGoodsLkStAcs.ALL_CUSTOMERNAME; //���Ӑ旪��
                    // --- UPD 2015/03/06 T.Miyamoto Redmine#338 ------------------------------<<<<<
                }
                // --- ADD 2015/02/20 T.Nishi ------------------------------>>>>>
                else if (retCustomerInfo != null)
                {
                    this._prevCusotmerCd = customerCode;
                    // --- UPD 2015/03/03 T.Miyamoto Redmine#308 ------------------------------>>>>>
                    //this.tNedit_CustomerCodeAllowZero.SetInt(customerCode);      //���Ӑ�R�[�h
                    this.tNedit_CustomerCodeAllowZero.DataText = customerCode.ToString().PadLeft(8, '0');
                    // --- UPD 2015/03/03 T.Miyamoto Redmine#308 ------------------------------<<<<<
                    this.uLabel_CustomerName.Text = retCustomerInfo.CustomerSnm; //���Ӑ旪��
                }
            }
            else
            {
                TMsgDisp.Show(this
                             , emErrorLevel.ERR_LEVEL_EXCLAMATION
                             , this.Name
                             , errMsg
                             , 0
                             , MessageBoxButtons.OK);

                this.tNedit_CustomerCodeAllowZero.SetInt(this._prevCusotmerCd);
            }
            return checkResult;
        }
        /// <summary>
        /// ���_�`�F�b�N����
        /// </summary>
        public bool SectionCheck(string sectionCode)
        {
            string errMsg;
            SecInfoSet retSectionInfo;

            bool checkResult = this._recGoodsLkStAcs.CheckSection(sectionCode, false, out errMsg, out retSectionInfo);
            if (checkResult)
            {
                //���_�N���A
                this.tNedit_SectionCodeAllowZero.Clear();
                this.uLabel_SectionName.Text = "";

                this._prevSectionCd = "";
                // --- ADD 2015/02/13 T.Miyamoto ����ýď�Q#193 ------------------------------>>>>>
                if (sectionCode != "")
                {
                    sectionCode = sectionCode.PadLeft(2, '0');
                }
                // --- ADD 2015/02/13 T.Miyamoto ����ýď�Q#193 ------------------------------<<<<<
                // --- ADD 2015/02/10 ����ý�#174 T.Miyamoto -------------------->>>>>
                if (sectionCode == "00")
                {
                    this._prevSectionCd = sectionCode;
                    this.tNedit_SectionCodeAllowZero.Text = sectionCode;
                    this.uLabel_SectionName.Text = "�S�Ћ���";
                }
                // --- ADD 2015/02/10 ����ý�#174 T.Miyamoto --------------------<<<<<
                if (retSectionInfo != null)
                {
                    this._prevSectionCd = sectionCode;
                    this.tNedit_SectionCodeAllowZero.Text = retSectionInfo.SectionCode; //���_�R�[�h
                    this.uLabel_SectionName.Text = retSectionInfo.SectionGuideNm; //���_��
                }
            }
            else
            {
                TMsgDisp.Show(this
                             , emErrorLevel.ERR_LEVEL_EXCLAMATION
                             , this.Name
                             , errMsg
                             , 0
                             , MessageBoxButtons.OK);

                this.tNedit_SectionCodeAllowZero.Text = this._prevSectionCd; //���_�R�[�h
            }
            return checkResult;
        }
    }
}
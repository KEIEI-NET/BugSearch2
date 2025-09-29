//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���������i�ݒ�}�X�^
// �v���O�����T�v   : ���������i�ݒ�}�X�^���s��
//----------------------------------------------------------------------------//
//                (c)Copyright 2015 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11070266-00 �쐬�S�� : �e�c ���V
// �� �� ��  2015/02/20  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11070266-00 �쐬�S�� : �e�c ���V
// �X �V ��  2015/03/03  �C�����e : RedMine#304 �摜���h���b�O&�h���b�v���邽�т�
//                                              �������g�p�ʂ�������
//                                  RedMine#312 �u�폜���̂݁v�Ō�����A�N���A���Ă�
//                                              �C���[�W�E���J��񂪓��͂ł��Ȃ��܂܂ɂȂ�
//                                  RedMine#313 ���o�����`�F�b�N��̃t�H�[�J�X�ړ����s��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11070266-00 �쐬�S�� : �e�c ���V
// �X �V ��  2015/03/09  �C�����e : �i���ۏؕ���RedMine#3091
//                                  �摜�Q�Ƃ���̃A�b�v���[�h�Ɏ��s����P�[�X����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11070266-00 �쐬�S�� : �e�c ���V
// �X �V ��  2015/03/16  �C�����e : ��Q �����\�����Ɍ��J�敪��OFF�̏ꍇ�A���ڂ��񊈐��ɂȂ�Ȃ�
//                                       �܂��s�ړ��������l
//                                  �v�] ���J�敪��OFF�ɂ����ꍇ�ɔ񊈐����ڂ̒l���N���A���Ȃ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11070266-00 �쐬�S�� : �e�c ���V
// �X �V ��  2015/03/24  �C�����e : �i��Redmine#3093 �ۑ�Ǘ��\��35
//                                  ���[�J�[��]���i�E�W�����i�̍Čv�Z�@�\����������
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
using System.Reflection;
using System.Xml.XPath;
using System.Xml.Xsl;
using Broadleaf.Application.Resources;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// ���������i�ݒ�}�X�^ UI�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���������i�ݒ�}�X�^UI�t�H�[���N���X</br>
    /// <br>Programmer : �e�c ���V</br>
    /// <br>Date       : 2015/02/20</br>
    /// </remarks>
    public partial class PMREC09021UA : Form
    {
        # region Private Members
        private PMREC09021UB _detailInput;
        private ImageList _imageList16 = null;                                                // �C���[�W���X�g
        private Infragistics.Win.UltraWinToolbars.ButtonTool _closeButton;                    // �I���{�^��
        private Infragistics.Win.UltraWinToolbars.ButtonTool _searchButton;                   // �����{�^��
        private Infragistics.Win.UltraWinToolbars.ButtonTool _saveButton;                     // �ۑ��{�^��
        private Infragistics.Win.UltraWinToolbars.ButtonTool _clearButton;                    // �N���A�{�^��
        private Infragistics.Win.UltraWinToolbars.ButtonTool _guideButton;                    // �K�C�h�{�^��
        private Infragistics.Win.UltraWinToolbars.ButtonTool _reNewalButton;                  // �ŐV���{�^��
        private Infragistics.Win.UltraWinToolbars.ButtonTool _moveButton;                     // �ړ��{�^��
        private Infragistics.Win.UltraWinToolbars.LabelTool _loginNameLabel;                  // ���O�C���S����
        private Infragistics.Win.UltraWinToolbars.LabelTool _loginEmployeeLabel;              // ���O�C���S���Җ���
        private ControlScreenSkin _controlScreenSkin;
        private Control _prevControl = null;

        private string _enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
        private string _loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;

        private CustomerInfoAcs _customerInfoAcs = null;
        private RecBgnGdsAcs _recBgnGdsAcs = null;

        private CustomerSearchRet _customerSearchRet = null;
        /// <summary> ���������i�O���[�v��������</summary>
        private RecBgnGrpRet _recBgnGrpRet = null;

        private MakerAcs _makerAcs = null;					// ���[�J�[�A�N�Z�X�N���X
        private SecInfoSetAcs _secInfoSetAcs;
        private UserGuideAcs _userGuideAcs;
        private BLGoodsCdAcs _blGoodsCdAcs;
        private BLGroupUAcs _blGroupUAcs;

        /// <summary>���t�擾���i</summary>
        private DateGetAcs _dateGetAcs;

        /// <summary>�`�[�\���^�u ��T�C�Y���������l</summary>
        private bool _columnWidthAutoAdjust = false;

        private string _prevSectionCd = string.Empty;   
        private int _prevApplyStaDate = 0;
        private int _prevApplyEndDate = 0;

        private bool _masterCheckFlg = false;
        private bool _isButtonClick = false;

        private RecBgnGdsSearchPara _recBgnGdsSearchPara = null;

        private RecBgnGdsDataSet.SecCusSetDataTable _secCusSetDataTable;

        private string _NSDirectory; // NS�V�X�e����Path
        #endregion

        #region const
        private const string TOOLBAR_CLOSEBUTTON_KEY = "ButtonTool_Close";						// �I��
        private const string TOOLBAR_SEARCHBUTTON_KEY = "ButtonTool_Search";					// ����
        private const string TOOLBAR_SAVEBUTTON_KEY = "ButtonTool_Save";						// �ۑ�
        private const string TOOLBAR_CLEARBUTTON_KEY = "ButtonTool_Clear";						// �N���A
        private const string TOOLBAR_GUIDEBUTTON_KEY = "ButtonTool_Guide";						// �K�C�h
        private const string TOOLBAR_RENEWALBUTTON_KEY = "ButtonTool_ReNewal";					// �ŐV���
        private const string TOOLBAR_MOVEBUTTON_KEY = "ButtonTool_Move";						// �ړ�

        /// <summary>�\���F�����t�H���g�T�C�Y</summary>
        private const int CT_DEF_FONT_SIZE = 10;
        private static readonly Color ct_READONLY_CELL_COLOR = Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(220)))));
        /// <summary>�����T�C�Y</summary>
        private readonly int[] _fontpitchSize = new int[] { 6, 8, 9, 10, 11, 12, 14, 16, 18, 20, 22, 24 };
        /// <summary>���׃f�[�^���o�ő匏��</summary>
        private const long DATA_COUNT_MAX = 20000;
        /// <summary>�S�Аݒ�</summary>
        private const string ALL_SECTION_CODE = "00";
        private const string ALL_SECTION_NAME = "�S�Ћ���";

        // �t�@�C����
        private const string PDF_HELP_FILE = "image\\PMREC09020U\\PMREC09020U.pdf";     // �u�����߉^�p���Љ�v�w���v�t�@�C��
        private const string IMG_SAMPLE_FILE = "image\\PMREC09020U\\SampleImage.png";   // �u���q�l���\���C���[�W�v�T���v��
        private const string IMG_DRAGDROP_FILE = "image\\PMREC09020U\\DragDrop.png";    // �h���b�O���h���b�v�摜

        // DataSet��
        private const string DATASET_NAME = "Base";

        // ���i�C���[�W�i�[�T�C�Y
        //private const int GOODSIMG_SAVE_WIDTH = 200;
        //private const int GOODSIMG_SAVE_HEIGHT = 150;
        private const int GOODSIMG_SAVE_WIDTH = 640;
        private const int GOODSIMG_SAVE_HEIGHT = 640;
        #endregion

        # region Constroctors
        /// <summary>
        ///  ���������i�ݒ�}�X�^�t�H�[���N���X �f�t�H���g�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���������i�ݒ�}�X�^�t�H�[���N���X �f�t�H���g�R���X�g���N�^</br>
        /// <br>Programmer : �e�c ���V</br>
        /// <br>Date       : 2015/02/20</br>
        /// </remarks>
        public PMREC09021UA()
        {
            InitializeComponent();

            // �ϐ�������
            this._detailInput = new PMREC09021UB();
            this._imageList16 = IconResourceManagement.ImageList16;
            this._loginNameLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)this.tToolsManager_MainMenu.Tools["LabelTool_LoginTitle"];
            this._loginEmployeeLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)this.tToolsManager_MainMenu.Tools["LabelTool_LoginName"];
            this._closeButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools["ButtonTool_Close"];
            this._searchButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools["ButtonTool_Search"];
            this._saveButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools["ButtonTool_Save"];
            this._clearButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools["ButtonTool_Clear"];
            this._guideButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools["ButtonTool_Guide"];
            this._reNewalButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools["ButtonTool_ReNewal"];
            this._moveButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools["ButtonTool_Move"];
            this._detailInput.GridKeyUpTopRow += new EventHandler(this.GriedDetail_GridKeyUpTopRow);
            this._controlScreenSkin = new ControlScreenSkin();
            this._loginEmployeeLabel.SharedProps.Caption = LoginInfoAcquisition.Employee.Name;

            this._detailInput.SetGuidButton += new PMREC09021UB.SetGuidButtonEventHandler(this.SetGuidButton);
            this._detailInput.GetBaseInfo += new PMREC09021UB.GetBaseInfoEventHandler(this.GetBaseInfo);
            this._detailInput.OpenGoodsImgFile += new PMREC09021UB.OpenGoodsImgFileEventHandler(this.OpenGoodsImgFile);
            this._detailInput.GoodsInfoPreview += new PMREC09021UB.GoodsInfoPreviewEventHandler(this.GoodsInfoPreview);
            this._detailInput.PreviewColumnSync += new PMREC09021UB.PreviewColumnSyncEventHandler(this.PreviewColumnSync);
            this._detailInput.GoodsInfoPreviewClear += new PMREC09021UB.GoodsInfoPreviewClearEventHandler(this.GoodsInfoPreviewClear);

            this._recBgnGdsAcs = this._detailInput.RecBgnGdsAcs;
            this._makerAcs = new MakerAcs();
            this._secInfoSetAcs = new SecInfoSetAcs();
            this._userGuideAcs = new UserGuideAcs();
            this._blGoodsCdAcs = new BLGoodsCdAcs();
            this._blGroupUAcs = new BLGroupUAcs();
            this._customerInfoAcs = new CustomerInfoAcs();

            // �ݒ�ǂݍ���
            this._detailInput.Deserialize();

            this.uExGroupBox_ExtraCondition.Expanded = false;
            this.tComboEditor_DeleteFlag.SelectedIndex = 0;
            this.tComboEditor_StatusBar_FontSize.SelectedIndex = 0;
            this.tComboEditor_StatusBar_FontSize.SelectedIndex = this._detailInput.UserSetting.OutputStyle;

            _NSDirectory = ConstantManagement_ClientDirectory.NSCurrentDirectory; // NS�V�X�e����Path
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
        /// <br>Programmer : �e�c ���V</br>
        /// <br>Date       : 2015/02/20</br>
        /// </remarks>
        private void PMREC09021UA_Load(object sender, EventArgs e)
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

            this._recBgnGdsAcs.LoadMstData();

            while (this._recBgnGdsAcs.MasterAcsThread.ThreadState == System.Threading.ThreadState.Running)
            {
                Thread.Sleep(100);
            }
            while (this._recBgnGdsAcs.GoodsAcsThread.ThreadState == System.Threading.ThreadState.Running)
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

            // ���Ӑ�
            if (this._recBgnGdsAcs.CustomerDic.Count > 0)
            {
                _secCusSetDataTable = new RecBgnGdsDataSet.SecCusSetDataTable();

                _secCusSetDataTable.BeginLoadData();
                foreach (int key in this._recBgnGdsAcs.CustomerDic.Keys)
                {
                    CustomerInfo customerInfo = null;
                    customerInfo = this._recBgnGdsAcs.CustomerDic[key];

                    RecBgnGdsDataSet.SecCusSetRow newRow = _secCusSetDataTable.NewSecCusSetRow();
                    newRow.CustomerCode = customerInfo.CustomerCode.ToString();
                    newRow.CustomerName = customerInfo.CustomerSnm;
                    _secCusSetDataTable.AddSecCusSetRow(newRow);
                }
                _secCusSetDataTable.EndLoadData();
            }

            // ������������������
            this.ConditionClear();

            // ���׏��v���r���[�\������������
            this.GoodsInfoPreviewClear();

            // ���Ӑ�ʐݒ�폜
            this._recBgnGdsAcs.RecBgnGdsCustInfoDic.Clear();

            // �c�[���o�[F6�p
            this.ChangeToolsMove(0);

            this._detailInput.LoadSettings();

            // ���t�擾���i
            _dateGetAcs = DateGetAcs.GetInstance();

            // ���i�C���[�W���c���c��L���ɂ���
            pictureBox_GoodsImage.AllowDrop = true;

            // �T���v���摜
            string samplePath = Path.Combine(_NSDirectory, IMG_SAMPLE_FILE);
            if (File.Exists(samplePath))
            {
                // --- UPD 2015/03/03 Y.Wakita Redmine#304 ---------->>>>>
                //pictureBox1.Image = new Bitmap(im);

                using (FileStream fs = File.OpenRead(samplePath))
                {
                    using (Image img = Image.FromStream(fs, false, false))
                    {
                        pictureBox1.Image = new Bitmap(img);
                    }
                }
                // --- UPD 2015/03/03 Y.Wakita Redmine#304 ----------<<<<<

            }

            // �h���b�O���h���b�v�摜
            string ddPath = Path.Combine(_NSDirectory, IMG_DRAGDROP_FILE);
            if (File.Exists(ddPath))
            {
                // 2015/03/03
                using (FileStream fs = File.OpenRead(ddPath))
                {
                    using (Image img = Image.FromStream(fs, false, false))
                    {
                        pictureBox_GoodsImage.BackgroundImage = new Bitmap(img);
                    }
                }
                //pictureBox_GoodsImage.BackgroundImage = new Bitmap(ddPath);
            }

            string sPath = Path.Combine(_NSDirectory, PDF_HELP_FILE);
            if (!File.Exists(sPath))
            {
                this.uButton_HelpGuide.Enabled = false;
            }

            // �C���[�W���͕��\��
            panel_SaleImage.Visible = true;
            uExGroupBox_Image.Text = "���q�l���\���C���[�W";

        }

        /// <summary>
        /// �{�^�������ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note       : �{�^�������ݒ菈�����s���܂��B</br>
        /// <br>Programmer : �e�c ���V</br>
        /// <br>Date       : 2015/02/20</br>
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
            this._moveButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.RENEWAL;

            this._loginNameLabel.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.EMPLOYEE;
            
            #region �K�C�h�{�^��
            // ���_
            this.uButton_SectionGuide.ImageList = this._imageList16;
            this.uButton_SectionGuide.Appearance.Image = (int)Size16_Index.STAR1;
            // Ұ���i�J�n�|�I���j
            this.uButton_MakerCdSt.ImageList = this._imageList16;
            this.uButton_MakerCdSt.Appearance.Image = (int)Size16_Index.STAR1;
            this.uButton_MakerCdEd.ImageList = this._imageList16;
            this.uButton_MakerCdEd.Appearance.Image = (int)Size16_Index.STAR1;
            // ���������i��ٰ�ߺ���
            this.uButton_BrgnGoodsGrpCodeGuide.ImageList = this._imageList16;
            this.uButton_BrgnGoodsGrpCodeGuide.Appearance.Image = (int)Size16_Index.STAR1;
            #endregion
        }

        /// <summary>
        /// �t�H�[�J�X�ϊ�����
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : �t�H�[�J�X�ϊ������B</br>
        /// <br>Programmer : �e�c ���V</br>
        /// <br>Date       : 2015/02/20</br>
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
                                        if (this._detailInput.uGrid_Details.ActiveCell.Column.Key == this._recBgnGdsAcs.RecBgnGdsDataTable.GoodsMakerCodeColumn.ColumnName)
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
                                                e.NextCtrl = this.tComboEditor_DeleteFlag;
                                            }
                                            else
                                            {
                                                e.NextCtrl = this.tNedit_SectionCodeAllowZero;
                                            }
                                            break;
                                        }
                                        else if (this._recBgnGdsAcs.PrevRecBgnGdsDic != null
                                              && this._recBgnGdsAcs.PrevRecBgnGdsDic.Count <= 0
                                              && this._detailInput.uGrid_Details.ActiveCell.Column.Key == this._recBgnGdsAcs.RecBgnGdsDataTable.GoodsMakerCodeColumn.ColumnName)
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
                                                e.NextCtrl = this.tComboEditor_DeleteFlag;
                                            }
                                            else
                                            {
                                                e.NextCtrl = this.tNedit_SectionCodeAllowZero;
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
                case "PMREC09021UB":
                    {
                        if (e.NextCtrl != null)
                        {
                            if (e.NextCtrl.Name == "uButton_RowDelete"
                             || e.NextCtrl.Name == "uButton_AllRowDelete"
                             || e.NextCtrl.Name == "uButton_Revival"
                             || e.NextCtrl.Name == "uButton_Recapture"   // ADD 2015/03/24 Y.Wakita
                             || e.NextCtrl.Name == "_PMREC09021UA_Toolbars_Dock_Area_Top"
                             || e.NextCtrl.Name == "_PMREC09021UB_Toolbars_Dock_Area_Top")
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

                #region ���_
                case "tNedit_SectionCodeAllowZero":
                    {
                        bool checkFlg = true;
                        string sectionCode = this.tNedit_SectionCodeAllowZero.DataText.Trim();
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
                                if (this.uExGroupBox_ExtraCondition.Expanded)
                                {
                                    e.NextCtrl = this.tEdit_MakerCdSt;
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
                                    e.NextCtrl = this.tEdit_MakerCdSt;
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
                                e.NextCtrl = this.tNedit_SectionCodeAllowZero;
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
                                e.NextCtrl = this.tNedit_SectionCodeAllowZero;
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
                                    e.NextCtrl = this.tEdit_GoodsNo;
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
                                e.NextCtrl = this.tEdit_GoodsNo;
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

                #region �i��*
                case "tEdit_GoodsNo":
                    {
                        // �t�H�[�J�X�ݒ�
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                e.NextCtrl = this.tDateEdit_OpenDateSt;
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

                #region ���J���i�J�n�j
                case "tDateEdit_OpenDateSt":
                    {
                        // �t�H�[�J�X�ݒ�
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                e.NextCtrl = this.tDateEdit_OpenDateEd;
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

                #region ���J���i�I���j
                case "tDateEdit_OpenDateEd":
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
                                e.NextCtrl = this.tDateEdit_OpenDateSt;
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
                                e.NextCtrl = this.tDateEdit_OpenDateEd;
                            }
                        }
                        break;
                    }
                #endregion
                
                #region �S���Ӑ�ݒ�

                #region �i��
                case "tEdit_GoodsName":
                    {
                        int rowIndex = this._detailInput.RowIndex;
                        // �i��
                        this._detailInput.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsAcs.RecBgnGdsDataTable.GoodsNameColumn.ColumnName].Value = this.tEdit_GoodsName.Text.Trim();

                        // �t�H�[�J�X�ݒ�
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                // ���i�R�����g
                                e.NextCtrl = this.tEdit_GoodsComment;
                            }
                            else if (e.Key == Keys.Up)
                            {
                                // �i��
                                this._detailInput.uGrid_Details.Focus();
                                this._detailInput.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsAcs.RecBgnGdsDataTable.GoodsNameColumn.ColumnName].Activate();
                                this._detailInput.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                // ���ׂ̕i���ֈړ�
                                e.NextCtrl = this.panel_DetailInput;
                                this._detailInput.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsAcs.RecBgnGdsDataTable.GoodsNameColumn.ColumnName].Activate();
                                this._detailInput.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                            }
                        }
                        break;
                    }
                #endregion

                #region ���i�R�����g
                case "tEdit_GoodsComment":
                    {
                        int rowIndex = this._detailInput.RowIndex;
                        // ���i�R�����g
                        this._detailInput.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsAcs.RecBgnGdsDataTable.GoodsCommentColumn.ColumnName].Value = this.tEdit_GoodsComment.Text.Trim();

                        // �t�H�[�J�X�ݒ�
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                // ���i�C���[�W
                                e.NextCtrl = this.uButton_FolderOpen;
                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                // �i��
                                e.NextCtrl = this.tEdit_GoodsName;
                            }
                        }

                        break;
                    }
                #endregion

                #region ���i�C���[�W
                case "uButton_FolderOpen":
                    {
                        // �t�H�[�J�X�ݒ�
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                // ���J�J�n��
                                e.NextCtrl = this.tDateEdit_ApplyStaDate;
                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                // ���i�R�����g
                                e.NextCtrl = this.tEdit_GoodsComment;
                            }
                        }

                        break;
                    }
                #endregion

                #region ���J�J�n��
                case "tDateEdit_ApplyStaDate":
                    {
                        int rowIndex = this._detailInput.RowIndex;
                        this._detailInput.SetApplyStaDate = this._detailInput.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsAcs.RecBgnGdsDataTable.ApplyStaDateColumn.ColumnName].Value.ToString();
                        if (this.tDateEdit_ApplyStaDate.LongDate != 0)
                        {
                            if (this._prevApplyStaDate != this.tDateEdit_ApplyStaDate.LongDate)
                            {
                                string date_St = this.tDateEdit_ApplyStaDate.LongDate.ToString();
                                // ���t�`�F�b�N
                                bool chkFlg = this._detailInput.CheckDateValue(ref date_St);
                                if (!chkFlg)
                                {
                                    TMsgDisp.Show(
                                                this,
                                                emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                                this.Name,
                                                "���J�J�n���Ɍ�肪����܂��B",
                                                0,
                                                MessageBoxButtons.OK);

                                    e.NextCtrl = this.tDateEdit_ApplyStaDate;

                                    break;
                                }
                                this.tDateEdit_ApplyStaDate.LongDate = int.Parse(date_St.Replace("/", ""));

                                this._detailInput.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsAcs.RecBgnGdsDataTable.ApplyStaDateColumn.ColumnName].Value = date_St;
                                this._prevApplyStaDate = this.tDateEdit_ApplyStaDate.LongDate;

                                //if (this.tDateEdit_ApplyEndDate.LongDate != 0)
                                //{
                                //    string date_Ed = this.DateFormat(this.tDateEdit_ApplyEndDate.LongDate.ToString());
                                //    this.DispApplyDate(date_St, date_Ed);
                                //}
                            }
                        }
                        else
                        {
                            this._detailInput.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsAcs.RecBgnGdsDataTable.ApplyStaDateColumn.ColumnName].Value = string.Empty;
                            this._prevApplyStaDate = this.tDateEdit_ApplyStaDate.LongDate;
                        }

                        // �t�H�[�J�X�ݒ�
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                // ���J�I����
                                e.NextCtrl = this.tDateEdit_ApplyEndDate;
                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                // ���i�C���[�W
                                e.NextCtrl = this.uButton_FolderOpen;
                            }
                        }

                        break;
                    }
                #endregion

                #region ���J�I����
                case "tDateEdit_ApplyEndDate":
                    {
                        int rowIndex = this._detailInput.RowIndex;
                        this._detailInput.SetApplyEndDate = this._detailInput.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsAcs.RecBgnGdsDataTable.ApplyEndDateColumn.ColumnName].Value.ToString();
                        if (this.tDateEdit_ApplyEndDate.LongDate != 0)
                        {
                            if (this._prevApplyEndDate != this.tDateEdit_ApplyEndDate.LongDate)
                            {
                                string date_Ed = this.tDateEdit_ApplyEndDate.LongDate.ToString();
                                // ���t�`�F�b�N
                                bool chkFlg = this._detailInput.CheckDateValue(ref date_Ed);
                                if (!chkFlg)
                                {
                                    TMsgDisp.Show(
                                                this,
                                                emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                                this.Name,
                                                "���J�I�����Ɍ�肪����܂��B",
                                                0,
                                                MessageBoxButtons.OK);

                                    e.NextCtrl = this.tDateEdit_ApplyEndDate;

                                    break;
                                }
                                this.tDateEdit_ApplyEndDate.LongDate = int.Parse(date_Ed.Replace("/", ""));

                                this._detailInput.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsAcs.RecBgnGdsDataTable.ApplyEndDateColumn.ColumnName].Value = date_Ed;
                                this._prevApplyEndDate = this.tDateEdit_ApplyEndDate.LongDate;

                                //if (this.tDateEdit_ApplyEndDate.LongDate != 0)
                                //{
                                //    string date_St = this.DateFormat(this.tDateEdit_ApplyStaDate.LongDate.ToString());
                                //    this.DispApplyDate(date_St, date_Ed);
                                //}
                            }
                        }
                        else
                        {
                            this._detailInput.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsAcs.RecBgnGdsDataTable.ApplyEndDateColumn.ColumnName].Value = string.Empty;
                            this._prevApplyEndDate = this.tDateEdit_ApplyEndDate.LongDate;
                        }

                        // �t�H�[�J�X�ݒ�
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                // �\���敪
                                e.NextCtrl = this.uCheckEditor_DisplayDivCode;
                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                // ���J�J�n��
                                e.NextCtrl = this.tDateEdit_ApplyStaDate;
                            }
                        }

                        break;
                    }
                #endregion

                #region �\���敪
                case "uCheckEditor_DisplayDivCode":
                    {
                        int rowIndex = this._detailInput.RowIndex;
                        //if (this._detailInput.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsAcs.RecBgnGdsDataTable.GoodsNoColumn.ColumnName].Value.ToString() != string.Empty)
                        //{
                        //    // �\���敪
                        //    this._detailInput.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsAcs.RecBgnGdsDataTable.DisplayDivCodeColumn.ColumnName].Value = Convert.ToInt32(this.uCheckEditor_DisplayDivCode.Checked).ToString();
                        //}

                        // �t�H�[�J�X�ݒ�
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                // ���������i��ٰ��
                                e.NextCtrl = this.tEdit_BrgnGoodsGrpCode;
                            }
                            else if (e.Key == Keys.Up)
                            {
                                // �\���敪
                                this._detailInput.uGrid_Details.Focus();
                                this._detailInput.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsAcs.RecBgnGdsDataTable.DisplayDivCodeColumn.ColumnName].Activate();
                                this._detailInput.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                // ���J�I����
                                e.NextCtrl = this.tDateEdit_ApplyEndDate;
                            }
                        }

                        break;
                    }
                #endregion

                #region ���������i��ٰ��
                case "tEdit_BrgnGoodsGrpCode":
                    {
                        int rowIndex = this._detailInput.RowIndex;
                        this._detailInput.SetBrgnGoodsGrpCode = int.Parse(this._detailInput.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsAcs.RecBgnGdsDataTable.BrgnGoodsGrpCodeColumn.ColumnName].Value.ToString());

                        if (this.tEdit_BrgnGoodsGrpCode.Text != string.Empty)
                        {
                            // ���������i��ٰ��
                            this._detailInput.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsAcs.RecBgnGdsDataTable.BrgnGoodsGrpCodeColumn.ColumnName].Value = this.tEdit_BrgnGoodsGrpCode.Text.Trim();
                            // ���������i��ٰ�ߖ�
                            this.uLabel_BrgnGoodsGrpName.Text = this._detailInput.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsAcs.RecBgnGdsDataTable.BrgnGoodsGrpNameColumn.ColumnName].Value.ToString();
                        }
                        else
                        {
                            // ���������i��ٰ��
                            this._detailInput.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsAcs.RecBgnGdsDataTable.BrgnGoodsGrpCodeColumn.ColumnName].Value = 0;
                        }

                        // �t�H�[�J�X�ݒ�
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                // ������
                                e.NextCtrl = this.tNedit_UnitCalcRate;
                            }
                            else if (e.Key == Keys.Up)
                            {
                                // ���������i��ٰ��
                                this._detailInput.uGrid_Details.Focus();
                                this._detailInput.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsAcs.RecBgnGdsDataTable.BrgnGoodsGrpCodeColumn.ColumnName].Activate();
                                this._detailInput.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                // �\���敪
                                e.NextCtrl = this.uCheckEditor_DisplayDivCode;
                            }
                        }

                        break;
                    }
                #endregion

                #region ������
                case "tNedit_UnitCalcRate":
                    {
                        int rowIndex = this._detailInput.RowIndex;
                        if (this.tNedit_UnitCalcRate.Text != string.Empty)
                        {
                            // ������
                            this._detailInput.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsAcs.RecBgnGdsDataTable.UnitCalcRateColumn.ColumnName].Value = double.Parse(this.tNedit_UnitCalcRate.Text);
                        }

                        // �t�H�[�J�X�ݒ�
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                // ���P��
                                e.NextCtrl = this.tNedit_UnitPrice;
                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                // ���������i��ٰ��
                                e.NextCtrl = this.tEdit_BrgnGoodsGrpCode;
                            }
                        }

                        break;
                    }
                #endregion

                #region ���P��
                case "tNedit_UnitPrice":
                    {
                        int rowIndex = this._detailInput.RowIndex;
                        if (this.tNedit_UnitPrice.Text != string.Empty)
                        {
                            // ���P��
                            this._detailInput.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsAcs.RecBgnGdsDataTable.UnitPriceColumn.ColumnName].Value = long.Parse(this.tNedit_UnitPrice.Text.Replace(",",""));
                        }

                        // �t�H�[�J�X�ݒ�
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                // �ʐݒ�
                                e.NextCtrl = this.uButton_OpenRecBgnCust;
                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                // ������
                                e.NextCtrl = this.tNedit_UnitCalcRate;
                            }
                        }

                        break;
                    }
                #endregion

                #region ���Ӑ�ʐݒ�
                case "uButton_OpenRecBgnCust":
                    {
                        int rowIndex = this._detailInput.RowIndex;
                        // �t�H�[�J�X�ݒ�
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                // �ʐݒ�
                                if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                                {
                                    if (rowIndex == _detailInput.uGrid_Details.Rows.Count - 1)
                                    {
                                        if (this._detailInput.CheckDateForDown())
                                        {
                                            this._detailInput.NewRowAdd();

                                            this._detailInput.uGrid_Details.Rows[this._detailInput.uGrid_Details.Rows.Count - 1].Cells[this._recBgnGdsAcs.RecBgnGdsDataTable.InqOtherSecCdColumn.ColumnName].Activate();
                                            this._detailInput.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                            e.NextCtrl = this._detailInput.uGrid_Details;
                                        
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.uButton_OpenRecBgnCust;
                                        }
                                    }
                                    else
                                    {
                                        this._detailInput.uGrid_Details.Rows[rowIndex + 1].Cells[this._recBgnGdsAcs.RecBgnGdsDataTable.InqOtherSecCdColumn.ColumnName].Activate();
                                        this._detailInput.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                        e.NextCtrl = this._detailInput.uGrid_Details;
                                    }
                                }

                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                // ���P��
                                e.NextCtrl = this.tNedit_UnitPrice;
                            }
                        }

                        break;
                    }
                #endregion

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
                    case "tEdit_MakerCdSt":
                    case "tEdit_MakerCdEd":
                    case "tNedit_SectionCodeAllowZero":
                        SetGuidButton(true);
                        // �c�[���o�[F6�؂�ւ�
                        this.ChangeToolsMove(0);
                        break;
                    case "uGrid_Details":
                        {
                            this._detailInput.SetGridGuid();
                            // �c�[���o�[F6�؂�ւ�
                            this.ChangeToolsMove(1);
                            break;
                        }
                    case "_PMREC09021UA_Toolbars_Dock_Area_Top":
                    case "_PMREC09021UB_Toolbars_Dock_Area_Top":
                        break;
                    case "tEdit_BrgnGoodsGrpCode":
                        {
                            SetGuidButton(true);
                            // �c�[���o�[F6�؂�ւ�
                            this.ChangeToolsMove(2);
                            break;
                        }
                    case "tEdit_GoodsName":
                    case "tEdit_GoodsComment":
                    case "pictureBox_GoodsImage":
                    case "uCheckEditor_DisplayDivCode":
                    case "tDateEdit_ApplyStaDate":
                    case "tDateEdit_ApplyEndDate":
                    case "tNedit_UnitCalcRate":
                    case "tNedit_UnitPrice":
                        {
                            // �c�[���o�[F6�؂�ւ�
                            this.ChangeToolsMove(2);
                            break;
                        }
                    default:
                        SetGuidButton(false);
                        break;
                }
            }
            #endregion
        }

        /// <summary>
        /// ���C�����j���[�c�[���{�^��
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : ���C�����j���[�c�[���{�^��</br>
        /// <br>Programmer : �e�c ���V</br>
        /// <br>Date       : 2015/02/20</br>
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
                            this.tArrowKeyControl1_ChangeFocus(null, new ChangeFocusEventArgs(false, false, false, Keys.Up, this.tNedit_SectionCodeAllowZero, this.tNedit_SectionCodeAllowZero));
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
                        RecBgnGds recBgnGds = null;
                        this._recBgnGdsAcs.CopyToRecBgnGdsFromDetailRow((RecBgnGdsDataSet.RecBgnGdsRow)this._recBgnGdsAcs.RecBgnGdsDataTable.Rows[this._recBgnGdsAcs.RecBgnGdsDataTable.Count - 1], ref recBgnGds);
                        this._recBgnGdsAcs.NewRecBgnGdsObj = recBgnGds.Clone();
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

                        DialogResult dialogResult = TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_INFO,
                            this.Name,
                            "��ʏ��̓N���A����܂��B" + "\r\n" + "\r\n" +
                            "��낵���ł����H",
                            0,
                            MessageBoxButtons.YesNo,
                            MessageBoxDefaultButton.Button1);

                        if (dialogResult == DialogResult.No) break;

                        this.ReNewal();
                        break;
                    }
                // �ړ�
                case TOOLBAR_MOVEBUTTON_KEY:
                    {
                        this.MoveToGridImage();
                        break;
                    }
            }
        }

        #region ���_�K�C�h
        /// <summary>
        /// ���_�K�C�h�{�^��
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : ���_�K�C�h�{�^��</br>
        /// <br>Programmer : �e�c ���V</br>
        /// <br>Date       : 2015/02/20</br>
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
                    this.tNedit_SectionCodeAllowZero.Text = secInfoSet.SectionCode.ToString().Trim().PadLeft(2, '0');
                    this.uLabel_SectionName.Text = secInfoSet.SectionGuideNm;
                    this._prevSectionCd = secInfoSet.SectionCode;

                    if (sender != null)
                    {
                        if (!this.uExGroupBox_ExtraCondition.Expanded)
                        {
                            // �������s��
                            this.Search();
                        }
                        else
                        {
                            this.tEdit_MakerCdSt.Focus();
                        }
                    }
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
        #endregion // ���_�K�C�h

        #region ���[�J�[�R�[�h�K�C�h
        /// <summary>
        /// ���[�J�[�R�[�h�K�C�h�{�^��
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : ���[�J�[�R�[�h�K�C�h�{�^��</br>
        /// <br>Programmer : �e�c ���V</br>
        /// <br>Date       : 2015/02/20</br>
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
        #endregion // ���[�J�[�R�[�h�K�C�h

        /// <summary>
        /// ���[�J�[AfterEnterEditMode�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : ���[�J�[�C�x���g</br>
        /// <br>Programmer : �e�c ���V</br>
        /// <br>Date       : 2015/02/20</br>
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

        #region �񕝎�������
        /// <summary>
        /// �񕝎��������`�F�b�N�{�b�N�X�̕ύX
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : �񕝎��������`�F�b�N�{�b�N�X�̕ύX�B</br>
        /// <br>Programmer : �e�c ���V</br>
        /// <br>Date       : 2015/02/20</br>
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
        /// <br>Programmer : �e�c ���V</br>
        /// <br>Date       : 2015/02/20</br>
        /// <br></br>
        /// </remarks>
        private void autoColumnAdjust(bool autoAdjust)
        {
            if (this._detailInput.uGrid_Details.DisplayLayout.AutoFitStyle == Infragistics.Win.UltraWinGrid.AutoFitStyle.None && !autoAdjust
             || this._detailInput.uGrid_Details.DisplayLayout.AutoFitStyle != Infragistics.Win.UltraWinGrid.AutoFitStyle.None && autoAdjust) return;

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

                editBand.Columns[this._recBgnGdsAcs.RecBgnGdsDataTable.RowNoColumn.ColumnName].Width = 40;		        // ��
                editBand.Columns[this._recBgnGdsAcs.RecBgnGdsDataTable.UpdateTimeColumn.ColumnName].Width = 80;		    // �폜��
                editBand.Columns[this._recBgnGdsAcs.RecBgnGdsDataTable.InqOtherSecCdColumn.ColumnName].Width = 35;		// ���_
                editBand.Columns[this._recBgnGdsAcs.RecBgnGdsDataTable.InqOtherSecNmColumn.ColumnName].Width = 85;		// ���_��
                editBand.Columns[this._recBgnGdsAcs.RecBgnGdsDataTable.GoodsNoColumn.ColumnName].Width = 115;	        // �i��
                editBand.Columns[this._recBgnGdsAcs.RecBgnGdsDataTable.GoodsNameColumn.ColumnName].Width = 150;			// �i��
                editBand.Columns[this._recBgnGdsAcs.RecBgnGdsDataTable.GoodsMakerCodeColumn.ColumnName].Width = 40;		// Ұ��
                editBand.Columns[this._recBgnGdsAcs.RecBgnGdsDataTable.GoodsMakerNameColumn.ColumnName].Width = 85;		// Ұ����
                editBand.Columns[this._recBgnGdsAcs.RecBgnGdsDataTable.GoodsCommentColumn.ColumnName].Width = 200;		// ���i����
                editBand.Columns[this._recBgnGdsAcs.RecBgnGdsDataTable.GoodsImageDmyColumn.ColumnName].Width = 45;		// ���i�Ұ������
                editBand.Columns[this._recBgnGdsAcs.RecBgnGdsDataTable.BrgnGoodsGrpCodeColumn.ColumnName].Width = 65;	// ���������i��ٰ��
                editBand.Columns[this._recBgnGdsAcs.RecBgnGdsDataTable.BrgnGoodsGrpNameColumn.ColumnName].Width = 85;	// ���������i��ٰ�ߖ�
                editBand.Columns[this._recBgnGdsAcs.RecBgnGdsDataTable.DisplayDivCodeColumn.ColumnName].Width = 45;	    // ���i���J�敪
                editBand.Columns[this._recBgnGdsAcs.RecBgnGdsDataTable.ApplyStaDateColumn.ColumnName].Width = 80;		// ���J�J�n��
                editBand.Columns[this._recBgnGdsAcs.RecBgnGdsDataTable.ApplyEndDateColumn.ColumnName].Width = 80;		// ���J�I����
                editBand.Columns[this._recBgnGdsAcs.RecBgnGdsDataTable.MkrSuggestRtPricColumn.ColumnName].Width = 75;	// Ұ����]�������i
                editBand.Columns[this._recBgnGdsAcs.RecBgnGdsDataTable.UnitCalcRateColumn.ColumnName].Width = 50;       // ���|��
                editBand.Columns[this._recBgnGdsAcs.RecBgnGdsDataTable.UnitPriceColumn.ColumnName].Width = 75;          // ���P��
                editBand.Columns[this._recBgnGdsAcs.RecBgnGdsDataTable.RecBgnCustColumn.ColumnName].Width = 45;         // ���Ӑ��


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
        /// <br>Programmer : �e�c ���V</br>
        /// <br>Date       : 2015/02/20</br>
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
        /// <br>Programmer : �e�c ���V</br>
        /// <br>Date       : 2015/02/20</br>
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
        /// <br>Programmer : �e�c ���V</br>
        /// <br>Date       : 2015/02/20</br>
        /// </remarks>
        private void Search()
        {
            RecBgnGdsSearchPara recBgnGdsSearchPara = null;

            //this.uCheckEditor_DisplayDivCode.CheckedChanged -= new EventHandler(uCheckEditor_DisplayDivCode_CheckedChanged);

            // ���������擾����
            this.ScreenToRecBgnGdsSearchPara(ref recBgnGdsSearchPara);

            if (this._isButtonClick == false)
            {
                if (this._recBgnGdsSearchPara != null)
                {
                    if (this._recBgnGdsAcs.CompareRecBgnGdsSearchPara(this._recBgnGdsSearchPara, recBgnGdsSearchPara))
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
            if (!this.SearchCheck(recBgnGdsSearchPara))
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
            int status = this._recBgnGdsAcs.Search(recBgnGdsSearchPara, out count, out errMess);

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
                    this.uExGroupBox_Image.Enabled = true;
                }
                else
                {
                    this._detailInput.LeftFocusFlg = true;
                    this.uExGroupBox_Image.Enabled = false;
                }
                
                this._recBgnGdsSearchPara = recBgnGdsSearchPara;
                // ������A���ו��ݒ菈��
                this._detailInput.GridSettingAfterSearch(this._recBgnGdsAcs.DeleteSearchMode);
                if (this.tComboEditor_DeleteFlag.SelectedIndex == 0)
                {
                    if (this._detailInput.uGrid_Details.Rows.Count > 0)
                    {
                        // �O���b�h��s���͐F�ݒ�
                        this._detailInput.DetailGridInitSetting();

                        // ���_
                        if (this.tNedit_SectionCodeAllowZero.Text != ALL_SECTION_CODE)
                        {
                            this._detailInput.uGrid_Details.Rows[this._detailInput.uGrid_Details.Rows.Count - 1].Cells[this._recBgnGdsAcs.RecBgnGdsDataTable.InqOtherSecCdColumn.ColumnName].Value = this.tNedit_SectionCodeAllowZero.Text.Trim().PadLeft(2, '0');
                            this._detailInput.uGrid_Details.Rows[this._detailInput.uGrid_Details.Rows.Count - 1].Cells[this._recBgnGdsAcs.RecBgnGdsDataTable.InqOtherSecNmColumn.ColumnName].Value = this.uLabel_SectionName.Text.Trim();
                        }

                        this._detailInput.uGrid_Details.Rows[this._detailInput.uGrid_Details.Rows.Count - 1].Cells[this._recBgnGdsAcs.RecBgnGdsDataTable.InqOtherSecCdColumn.ColumnName].Activate();
                        this._detailInput.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                        SetGuidButton(true);
                        this.ChangeToolsMove(1);

                        // --- ADD 2015/03/16 Y.Wakita ��Q ---------->>>>>
                        foreach (UltraGridRow row in this._detailInput.uGrid_Details.Rows)
                        {
                            int inputValue = 0;
                            // ���͒l���擾
                            Int32.TryParse(row.Cells[this._recBgnGdsAcs.RecBgnGdsDataTable.DisplayDivCodeColumn.ColumnName].Text, out inputValue);
                            this._detailInput.ChangeDisplayDiv(row.Index, inputValue);
                        }
                        // --- ADD 2015/03/16 Y.Wakita ��Q ----------<<<<<
                    }
                    else
                    {
                        SetGuidButton(false);
                        this.ChangeToolsMove(0);
                    }

                    RecBgnGds recBgnGds = null;
                    this._recBgnGdsAcs.CopyToRecBgnGdsFromDetailRow((RecBgnGdsDataSet.RecBgnGdsRow)this._recBgnGdsAcs.RecBgnGdsDataTable.Rows[this._recBgnGdsAcs.RecBgnGdsDataTable.Count - 1], ref recBgnGds);
                    this._recBgnGdsAcs.NewRecBgnGdsObj = recBgnGds.Clone();
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

                this._recBgnGdsSearchPara = recBgnGdsSearchPara;

                //�폜�w��敪=�ʏ�̏ꍇ
                if (this.tComboEditor_DeleteFlag.SelectedIndex == 0)
                {
                    this._detailInput.Clear(true);
                    this._detailInput.SetButtonEnabled(1);

                    if (this._detailInput.uGrid_Details.Rows.Count > 0)
                    {
                        // ���_
                        if (this.tNedit_SectionCodeAllowZero.Text != ALL_SECTION_CODE)
                        {
                            this._detailInput.uGrid_Details.Rows[this._detailInput.uGrid_Details.Rows.Count - 1].Cells[this._recBgnGdsAcs.RecBgnGdsDataTable.InqOtherSecCdColumn.ColumnName].Value = this.tNedit_SectionCodeAllowZero.Text.Trim().PadLeft(2, '0');
                            this._detailInput.uGrid_Details.Rows[this._detailInput.uGrid_Details.Rows.Count - 1].Cells[this._recBgnGdsAcs.RecBgnGdsDataTable.InqOtherSecNmColumn.ColumnName].Value = this.uLabel_SectionName.Text.Trim();
                        }
                        this._detailInput.uGrid_Details.Rows[this._detailInput.uGrid_Details.Rows.Count - 1].Cells[this._recBgnGdsAcs.RecBgnGdsDataTable.InqOtherSecCdColumn.ColumnName].Activate();
                        this._detailInput.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                        SetGuidButton(true);
                    }
                    else
                    {
                        SetGuidButton(false);
                    }

                    RecBgnGds recBgnGds = null;
                    this._recBgnGdsAcs.CopyToRecBgnGdsFromDetailRow((RecBgnGdsDataSet.RecBgnGdsRow)this._recBgnGdsAcs.RecBgnGdsDataTable.Rows[this._recBgnGdsAcs.RecBgnGdsDataTable.Count - 1], ref recBgnGds);
                    this._recBgnGdsAcs.NewRecBgnGdsObj = recBgnGds.Clone();
                }
                //�폜�w��敪=�폜���݂̂̏ꍇ
                else
                {
                    this._detailInput.SetButtonEnabled(3);

                    this._recBgnGdsAcs.PrevRecBgnGdsDic.Clear();
                    // ����DataTable�s�N���A����
                    this._recBgnGdsAcs.RecBgnGdsDataTable.Rows.Clear();

                    this._detailInput.uGrid_Details.DisplayLayout.Bands[0].Columns[this._recBgnGdsAcs.RecBgnGdsDataTable.UpdateTimeColumn.ColumnName].Hidden = true;

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
                    "PMREC09021U", 						// �A�Z���u���h�c�܂��̓N���X�h�c
                    "���������i�ݒ�}�X�^",           // �v���O��������
                    "Search", 							// ��������
                    TMsgDisp.OPE_GET, 					// �I�y���[�V����
                    "�ǂݍ��݂Ɏ��s���܂����B", 		// �\�����郁�b�Z�[�W
                    status, 							// �X�e�[�^�X�l
                    this._recBgnGdsAcs, 			// �G���[�����������I�u�W�F�N�g
                    MessageBoxButtons.OK, 				// �\������{�^��
                    MessageBoxDefaultButton.Button1);	// �����\���{�^��
            }
            #endregion

            //this.uCheckEditor_DisplayDivCode.CheckedChanged += new EventHandler(this.uCheckEditor_DisplayDivCode_CheckedChanged);

        }

        /// <summary>
        /// �����O�A�`�F�b�N����
        /// </summary>
        /// <param name="recBgnGdsSearchPara">��������</param>
        /// <returns>bool</returns>
        /// <remarks>
        /// <br>Note       : �����O�A�`�F�b�N�������s���܂��B</br>
        /// <br>Programmer : �e�c ���V</br>
        /// <br>Date       : 2015/02/20</br>
        /// </remarks>
        private bool SearchCheck(RecBgnGdsSearchPara recBgnGdsSearchPara)
        {
            List<RecBgnGds> deleteList;
            List<RecBgnGds> updateList;

            // �폜�w��敪=0�̏ꍇ
            if (this._recBgnGdsAcs.DeleteSearchMode == false)
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

            // ���[�J�[�͈̔̓`�F�b�N
            if (recBgnGdsSearchPara.GoodsMakerCdSt > recBgnGdsSearchPara.GoodsMakerCdEd)
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

            // ���J���`�F�b�N
            Control errorControl = null;
            DateGetAcs.CheckDateRangeResult cdrResult;
            if (CheckDateRangeForSlip(ref this.tDateEdit_OpenDateSt, ref this.tDateEdit_OpenDateEd, out cdrResult, true) == false)
            {
                string errorMessage = string.Empty;
                switch (cdrResult)
                {
                    case DateGetAcs.CheckDateRangeResult.ErrorOfStartInvalid:
                        errorMessage = "���J���i�J�n�j���s���ł��B";
                        errorControl = this.tDateEdit_OpenDateSt;
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfStartNoInput:
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfEndInvalid:
                        errorMessage = "���J���i�I���j���s���ł��B";
                        errorControl = this.tDateEdit_OpenDateEd;
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfEndNoInput:
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfRangeOver:
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfReverse:
                        errorMessage = "���J���͈͎̔w��Ɍ�肪����܂��B";
                        errorControl = this.tDateEdit_OpenDateSt;
                        break;
                }

                if (errorMessage != string.Empty && errorControl != null)
                {
                    // ���b�Z�[�W�\��
                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_EXCLAMATION, 
                        this.Name,
                        errorMessage,
                        0,
                        MessageBoxButtons.OK);

                    // --- UPD 2015/03/03 Y.Wakita Redmine#313 ---------->>>>>
                    //this.tEdit_MakerCdSt.Focus();
                    errorControl.Focus();
                    // --- UPD 2015/03/03 Y.Wakita Redmine#313 ----------<<<<<

                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// ���t�͈̓`�F�b�N����
        /// </summary>
        /// <param name="stEdit"></param>
        /// <param name="edEdit"></param>
        /// <param name="result"></param>
        /// <param name="allowNoInput"></param>
        /// <returns></returns>
        private bool CheckDateRangeForSlip(ref TDateEdit stEdit, ref TDateEdit edEdit, out DateGetAcs.CheckDateRangeResult result, bool allowNoInput)
        {
            int range = 3;
            if (allowNoInput) range = 0;

            result = _dateGetAcs.CheckDateRange(DateGetAcs.YmdType.YearMonth, range, ref stEdit, ref edEdit, allowNoInput);
            return (result == DateGetAcs.CheckDateRangeResult.OK);
        }

        /// <summary>
        /// �ۑ�����
        /// </summary>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : �ۑ��������s���܂��B</br>
        /// <br>Programmer : �e�c ���V</br>
        /// <br>Date       : 2015/02/20</br>
        /// </remarks>
        private int Save()
        {
            List<RecBgnGds> deleteList;
            List<RecBgnGds> updateList;
            List<RecBgnCust> updateCustList;

            int status = 0;
            RecBgnGds errorRecBgnGds = null;
            // �폜�w��敪=0�̏ꍇ
            if (this._recBgnGdsAcs.DeleteSearchMode == false)
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

                // ���Ӑ�ʐݒ�
                this._recBgnGdsAcs.SetGdsToCust2(updateList, out updateCustList);

                status = this._recBgnGdsAcs.SaveProc(deleteList, updateList, updateCustList, out errorRecBgnGds);

                string errorMsg = string.Empty;
                if (errorRecBgnGds != null)
                {
                    errorMsg = "���_�F" + errorRecBgnGds.InqOtherSecCd.ToString().PadLeft(2, '0')
                           + "�A�i�ԁF" + errorRecBgnGds.GoodsNo.Trim()
                           + "�AҰ���F" + errorRecBgnGds.GoodsMakerCd.ToString().PadLeft(4, '0')
                           + "�A���J���F" + errorRecBgnGds.ApplyStaDate.ToString().PadLeft(6, '0')
                           + "�`" + errorRecBgnGds.ApplyEndDate.ToString().PadLeft(6, '0');
        
                    TMsgDisp.Show(
                         this,
                         emErrorLevel.ERR_LEVEL_EXCLAMATION,
                         this.Name,
                         "����̏��i�ݒ肪���ɓo�^����Ă��܂��B" + "\r\n" +
                         errorMsg,
                         0,
                         MessageBoxButtons.OK);

                    foreach (UltraGridRow row in this._detailInput.uGrid_Details.Rows)
                    {
                        int startDate;
                        if (!int.TryParse(row.Cells[this._recBgnGdsAcs.RecBgnGdsDataTable.ApplyStaDateColumn.ColumnName].Text.Replace("/", ""), out startDate)) startDate = 0;

                        if ((errorRecBgnGds.InqOtherEpCd == row.Cells[this._recBgnGdsAcs.RecBgnGdsDataTable.InqOtherEpCdColumn.ColumnName].Value.ToString())
                        && (errorRecBgnGds.InqOtherSecCd == row.Cells[this._recBgnGdsAcs.RecBgnGdsDataTable.InqOtherSecCdColumn.ColumnName].Value.ToString())
                        && (errorRecBgnGds.GoodsNo == row.Cells[this._recBgnGdsAcs.RecBgnGdsDataTable.GoodsNoColumn.ColumnName].Value.ToString())
                        && (errorRecBgnGds.GoodsMakerCd == int.Parse(row.Cells[this._recBgnGdsAcs.RecBgnGdsDataTable.GoodsMakerCodeColumn.ColumnName].Value.ToString()))
                        && (errorRecBgnGds.ApplyStaDate == startDate))
                        {
                            row.Cells[this._recBgnGdsAcs.RecBgnGdsDataTable.GoodsNameColumn.ColumnName].Activate();
                            this._detailInput.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                            break;
                        }
                    }
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

                // ���Ӑ�ʐݒ�
                this._recBgnGdsAcs.SetGdsToCust2(updateList, out updateCustList);

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

                status = this._recBgnGdsAcs.SaveProc(deleteList, updateList, updateCustList, out errorRecBgnGds);
            }

            #region < �o�^�㏈�� >
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        // �o�^�����_�C�A���O�\��
                        SaveCompletionDialog dialog = new SaveCompletionDialog();
                        dialog.ShowDialog(2);

                        // ����������������������
                        this.ConditionClear();

                        // ���׏��v���r���[�\������������
                        this.GoodsInfoPreviewClear();

                        // ���Ӑ�ʐݒ�폜
                        this._recBgnGdsAcs.RecBgnGdsCustInfoDic.Clear();

                        // �c�[���o�[F6�p
                        this.ChangeToolsMove(0);

                        this._recBgnGdsSearchPara = null;

                        // �O���b�h�����ݒ菈��
                        this._detailInput.Clear(true);
                        this.tNedit_SectionCodeAllowZero.Focus();
                        this.SetGuidButton(true);

                        RecBgnGds recBgnGds = null;

                        this._recBgnGdsAcs.CopyToRecBgnGdsFromDetailRow((RecBgnGdsDataSet.RecBgnGdsRow)this._recBgnGdsAcs.RecBgnGdsDataTable.Rows[this._recBgnGdsAcs.RecBgnGdsDataTable.Count - 1], ref recBgnGds);
                        this._recBgnGdsAcs.NewRecBgnGdsObj = recBgnGds.Clone();

                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    {
                        TMsgDisp.Show(
                            this, 									// �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_INFO, 			// �G���[���x��
                            "PMREC09021U",				        	// �A�Z���u���h�c�܂��̓N���X�h�c
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
                            "PMREC09021U",				        	// �A�Z���u���h�c�܂��̓N���X�h�c
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
                            "PMREC09021U", 						// �A�Z���u���h�c�܂��̓N���X�h�c
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
                            "PMREC09021U", 						// �A�Z���u���h�c�܂��̓N���X�h�c
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
                           "PMREC09021U",                        // �A�Z���u���h�c�܂��̓N���X�h�c
                           "���������i�ݒ�}�X�^",     // �v���O��������
                           "Save",                               // ��������
                           TMsgDisp.OPE_UPDATE,                  // �I�y���[�V����
                           "�o�^�Ɏ��s���܂����B",               // �\�����郁�b�Z�[�W
                           status,                               // �X�e�[�^�X�l
                           this._recBgnGdsAcs,          // �G���[�����������I�u�W�F�N�g
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
        /// <br>Programmer : �e�c ���V</br>
        /// <br>Date       : 2015/02/20</br>
        /// </remarks>
        private void Clear()
        {
            bool clearFlg = false;
            #region �N���A�����O�A�ҏW�s�`�F�b�N
            List<RecBgnGds> deleteList;
            List<RecBgnGds> updateList;

            if (this._recBgnGdsAcs.DeleteSearchMode == false)
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
                this._recBgnGdsSearchPara = null;

                //����������������������
                this.ConditionClear();

                // ���׏��v���r���[�\������������
                this.GoodsInfoPreviewClear();

                // ���Ӑ�ʐݒ�폜
                this._recBgnGdsAcs.RecBgnGdsCustInfoDic.Clear();

                // �c�[���o�[F6�p
                this.ChangeToolsMove(0);

                // �O���b�h�����ݒ菈��
                this._detailInput.Clear(true);

                // �\�[�g�ݒ�̉���
                this._detailInput.uGrid_Details.DisplayLayout.Bands[0].SortedColumns.Clear();

                // �����t�H�[�J�X�ݒ�
                this.tNedit_SectionCodeAllowZero.Focus();

                // �K�C�h�{�^���ݒ�
                this.SetGuidButton(true);
            }
        }

        /// <summary>
        /// ����������������������
        /// </summary>
        /// <remarks>
        /// <br>Note       : ����������������������</br>
        /// <br>Programmer : �e�c ���V</br>
        /// <br>Date       : 2015/02/20</br>
        /// </remarks>
        private void ConditionClear()
        {
            #region ��{���N���A
            this.tNedit_SectionCodeAllowZero.Clear();        // ���_�R�[�h
            this.uLabel_SectionName.Text = string.Empty;    // ���_����
            this._prevSectionCd = string.Empty;
            #endregion

            #region ���o�����N���A          
            this.tEdit_MakerCdSt.Clear();       // ���[�J�[�i�J�n�j
            this.tEdit_MakerCdEd.Clear();       // ���[�J�[�i�I���j
            this.tEdit_GoodsNo.Clear();         // �i��
            this.tDateEdit_OpenDateSt.LongDate = int.Parse(DateTime.Now.Date.ToString("yyyyMMdd")); // ���J���i�J�n�j
            this.tDateEdit_OpenDateEd.Clear();  // ���J���i�I���j
            this.tComboEditor_DeleteFlag.SelectedIndex = 0; // �폜�w��敪
            #endregion
        }

        /// <summary>
        /// ���׏��v���r���[�\����������������
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���׏��v���r���[�\����������������</br>
        /// <br>Programmer : �e�c ���V</br>
        /// <br>Date       : 2015/02/20</br>
        /// </remarks>
        public void GoodsInfoPreviewClear()
        {
            this.tEdit_GoodsName.Clear();                       // �i��
            this.tEdit_GoodsComment.Clear();                    // ���i�R�����g
            this.pictureBox_GoodsImage.Image = null;            // ���i�C���[�W
            this.tDateEdit_ApplyStaDate.Clear();                // ���J���i�J�n�j
            this.tDateEdit_ApplyEndDate.Clear();                // ���J���i�I���j
            this.uCheckEditor_DisplayDivCode.Checked = true;    // �\���敪
            this.tEdit_BrgnGoodsGrpCode.Clear();                // ���������i�O���[�v
            this.uLabel_BrgnGoodsGrpName.Text = string.Empty;   // ���������i�O���[�v��
            this.uLabel_MkrSuggestRtPric.Text = string.Empty;   // Ұ����]�������i
            this.uLabel_MkrSuggestRtPric2.Text = string.Empty;  // Ұ����]�������i
            this.tNedit_UnitCalcRate.Clear();                   // ������
            this.tNedit_UnitPrice.Clear();                      // ���P��
            this.uLabel_ApplyDate.Text = string.Empty;          // ���J���i�J�n�`�I���j
            this.uLabel_RecBgnCust.Visible = false;             // ���Ӑ�ݒ肠��
            // --- ADD 2015/03/03 Y.Wakita Redmine#312 ---------->>>>>
            // �Ұ�ޓ��͕�����
            this.uExGroupBox_Image.Enabled = true;
            // --- ADD 2015/03/03 Y.Wakita Redmine#312 ----------<<<<<
        }
       
        /// <summary>
        /// ��ʃN���[�Y����
        /// </summary>
        /// <param name="boolean">boolean</param>
        /// <remarks>
        /// <br>Note       : ��ʃN���[�Y�������s���܂��B</br>
        /// <br>Programmer : �e�c ���V</br>
        /// <br>Date       : 2015/02/20</br>
        /// </remarks>
        private void Close(bool boolean)
        {
            List<RecBgnGds> deleteList;
            List<RecBgnGds> updateList;

            if (this._recBgnGdsAcs.DeleteSearchMode == false)
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
        /// <br>Programmer : �e�c ���V</br>
        /// <br>Date       : 2015/02/20</br>
        /// </remarks>
        private void GuideStart()
        {
            // ���_
            if (this.tNedit_SectionCodeAllowZero.Focused)
            {
                this.uButton_SectionGuide_Click(this.tNedit_SectionCodeAllowZero, new EventArgs());
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
            // ���������i��ٰ��
            else if (this.tEdit_BrgnGoodsGrpCode.Focused)
            {
                this.uButton_BrgnGoodsGrpCodeGuide_Click(this.tEdit_BrgnGoodsGrpCode, new EventArgs());
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
                        case "GoodsMakerCode":
                            {
                                this._detailInput.GoodsMakerCodeGuide(rowIndex);
                                break;
                            }
                        //case "CustomerCode":
                        //    {
                        //        this._detailInput.CustomerCodeGuide(rowIndex);
                        //        break;
                        //    }
                        case "InqOtherSecCd":
                            {
                                this._detailInput.SectionGuide(rowIndex);
                                break;
                            }
                        case "BrgnGoodsGrpCode":
                            {
                                this._detailInput.SetGdsGrpCodeGuide(rowIndex, 0);
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
        /// <br>Programmer : �e�c ���V</br>
        /// <br>Date       : 2015/02/20</br>
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

                this._recBgnGdsAcs.LoadMstData();

                while (this._recBgnGdsAcs.MasterAcsThread.ThreadState == System.Threading.ThreadState.Running)
                {
                    Thread.Sleep(100);
                }
                while (this._recBgnGdsAcs.GoodsAcsThread.ThreadState == System.Threading.ThreadState.Running)
                {
                    Thread.Sleep(100);
                }

                this._recBgnGdsSearchPara = null;

                //����������������������
                this.ConditionClear();

                // ���׏��v���r���[�\������������
                this.GoodsInfoPreviewClear();

                // ���Ӑ�ʐݒ�폜
                this._recBgnGdsAcs.RecBgnGdsCustInfoDic.Clear();

                // �c�[���o�[F6�p
                this.ChangeToolsMove(0);

                // �O���b�h�����ݒ菈��
                this._detailInput.Clear(true);

                // �\�[�g�ݒ�̉���
                this._detailInput.uGrid_Details.DisplayLayout.Bands[0].SortedColumns.Clear();

                // �����t�H�[�J�X�ݒ�
                this.tNedit_SectionCodeAllowZero.Focus();

                // �K�C�h�{�^���ݒ�
                this.SetGuidButton(true);

                RecBgnGds recBgnGds = null;
                this._recBgnGdsAcs.CopyToRecBgnGdsFromDetailRow((RecBgnGdsDataSet.RecBgnGdsRow)this._recBgnGdsAcs.RecBgnGdsDataTable.Rows[this._recBgnGdsAcs.RecBgnGdsDataTable.Count - 1], ref recBgnGds);
                this._recBgnGdsAcs.NewRecBgnGdsObj = recBgnGds.Clone();

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
        /// �ړ�����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �ړ��������s���܂��B</br>
        /// <br>Programmer : �e�c ���V</br>
        /// <br>Date       : 2015/02/20</br>
        /// </remarks>
        private void MoveToGridImage()
        {
            int rowIndex = this._detailInput.RowIndex;

            // �c�[���o�[F6�؂�ւ�
            this.ChangeToolsMove(1);

            // �i��
            if (this.tEdit_GoodsName.Focused)
            {
                this._detailInput.uGrid_Details.Focus();
                this._detailInput.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsAcs.RecBgnGdsDataTable.GoodsNameColumn.ColumnName].Activate();
                this._detailInput.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                return;
            }
            // ���i�R�����g
            if (this.tEdit_GoodsComment.Focused)
            {
                this._detailInput.uGrid_Details.Focus();
                this._detailInput.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsAcs.RecBgnGdsDataTable.GoodsCommentColumn.ColumnName].Activate();
                this._detailInput.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                return;
            }
            // ���i�C���[�W
            if (this.uButton_FolderOpen.Focused)
            {
                this._detailInput.uGrid_Details.Focus();
                this._detailInput.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsAcs.RecBgnGdsDataTable.GoodsImageDmyColumn.ColumnName].Activate();
                this._detailInput.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                return;
            }
            // ���J�J�n��
            if (this.tDateEdit_ApplyStaDate.ContainsFocus)
            {
                this._detailInput.uGrid_Details.Focus();
                this._detailInput.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsAcs.RecBgnGdsDataTable.ApplyStaDateColumn.ColumnName].Activate();
                this._detailInput.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                return;
            }
            // ���J�I����
            if (this.tDateEdit_ApplyEndDate.ContainsFocus)
            {
                this._detailInput.uGrid_Details.Focus();
                this._detailInput.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsAcs.RecBgnGdsDataTable.ApplyEndDateColumn.ColumnName].Activate();
                this._detailInput.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                return;
            }
            // �\���敪
            if (this.uCheckEditor_DisplayDivCode.Focused)
            {
                this._detailInput.uGrid_Details.Focus();
                this._detailInput.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsAcs.RecBgnGdsDataTable.DisplayDivCodeColumn.ColumnName].Activate();
                this._detailInput.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                return;
            }
            // ���������i��ٰ��
            if (this.tEdit_BrgnGoodsGrpCode.Focused)
            {
                this._detailInput.uGrid_Details.Focus();
                this._detailInput.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsAcs.RecBgnGdsDataTable.BrgnGoodsGrpCodeColumn.ColumnName].Activate();
                this._detailInput.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                return;
            }
            // ������
            if (this.tNedit_UnitCalcRate.Focused)
            {
                this._detailInput.uGrid_Details.Focus();
                this._detailInput.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsAcs.RecBgnGdsDataTable.UnitCalcRateColumn.ColumnName].Activate();
                this._detailInput.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                return;
            }
            // ���P��
            if (this.tNedit_UnitPrice.Focused)
            {
                this._detailInput.uGrid_Details.Focus();
                this._detailInput.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsAcs.RecBgnGdsDataTable.UnitPriceColumn.ColumnName].Activate();
                this._detailInput.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                return;
            }
            // ���Ӑ�ʐݒ�
            if (this.uButton_FolderOpen.Focused)
            {
                this._detailInput.uGrid_Details.Focus();
                this._detailInput.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsAcs.RecBgnGdsDataTable.RecBgnCustColumn.ColumnName].Activate();
                this._detailInput.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                return;
            }
            // �O���b�h
            else
            {
                // �c�[���o�[F6�؂�ւ�
                this.ChangeToolsMove(2);

                string keyName = this._detailInput.GetFocusColumnKey(out rowIndex);
                if (!string.Empty.Equals(keyName))
                {
                    switch (keyName)
                    {
                        // �i��
                        case "GoodsName":
                            {
                                this.tEdit_GoodsName.Focus();
                                break;
                            }
                        // ���i�R�����g
                        case "GoodsComment":
                            {
                                this.tEdit_GoodsComment.Focus();
                                break;
                            }
                        // ���i�C���[�W
                        case "GoodsImageDmy":
                            {
                                this.uButton_FolderOpen.Focus();
                                break;
                            }
                        // ���J�J�n��
                        case "ApplyStaDate":
                            {
                                this.tDateEdit_ApplyStaDate.Focus();
                                break;
                            }
                        // ���J�I����
                        case "ApplyEndDate":
                            {
                                this.tDateEdit_ApplyEndDate.Focus();
                                break;
                            }
                        // �\���敪
                        case "DisplayDivCode":
                            {
                                this.uCheckEditor_DisplayDivCode.Focus();
                                break;
                            }
                        // ���������i��ٰ��
                        case "BrgnGoodsGrpCode":
                            {
                                this.tEdit_BrgnGoodsGrpCode.Focus();
                                break;
                            }
                        // ������
                        case "UnitCalcRate":
                            {
                                this.tNedit_UnitCalcRate.Focus();
                                break;
                            }
                        // ���P��
                        case "UnitPrice":
                            {
                                this.tNedit_UnitPrice.Focus();
                                break;
                            }
                        // ���Ӑ�ʐݒ�
                        case "RecBgnCust":
                            {
                                this.uButton_FolderOpen.Focus();
                                break;
                            }
                            
                        default:
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// �ڍ׃O���b�h�ŏ�ʍs�A�v�C�x���g����
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : �ڍ׃O���b�h�ŏ�ʍs�A�v�E�����ɔ������܂��B</br>      
        /// <br>Programmer : �e�c ���V</br>                                  
        /// <br>Date       : 2015/02/20</br> 
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
        /// <param name="recBgnGdsSearchPara">�����������邩�ǂ���</param>
        /// <remarks>
        /// <br>Note       : �ŐV���擾�������s���܂��B</br>
        /// <br>Programmer : �e�c ���V</br>
        /// <br>Date       : 2015/02/20</br>
        /// </remarks>
        private void ScreenToRecBgnGdsSearchPara(ref RecBgnGdsSearchPara recBgnGdsSearchPara)
        {
            int code = 0;
            bool flag = false;

            if (recBgnGdsSearchPara == null)
            {
                recBgnGdsSearchPara = new RecBgnGdsSearchPara();
            }

            // �⍇�����ƃR�[�h
            recBgnGdsSearchPara.InqOtherEpCd = this._enterpriseCode;

            // �⍇���拒�_�R�[�h
            flag = int.TryParse(this.tNedit_SectionCodeAllowZero.Text, out code);
            if (flag)
            {
                code = int.Parse(this.tNedit_SectionCodeAllowZero.Text);
                recBgnGdsSearchPara.InqOtherSecCd = code.ToString().PadLeft(2, '0');
            }
            else
            {
                recBgnGdsSearchPara.InqOtherSecCd = string.Empty;
            }

            // ���[�J�[�i�J�n�j
            flag = int.TryParse(this.tEdit_MakerCdSt.Text, out code);
            if (flag)
            {
                recBgnGdsSearchPara.GoodsMakerCdSt = code;
            }
            else
            {
                recBgnGdsSearchPara.GoodsMakerCdSt = 0;
            }

            // ���[�J�[�i�I���j
            flag = int.TryParse(this.tEdit_MakerCdEd.Text, out code);
            if (flag)
            {
                recBgnGdsSearchPara.GoodsMakerCdEd = code;
            }
            else
            {
                recBgnGdsSearchPara.GoodsMakerCdEd = 9999;
            }

            // �i��*
            recBgnGdsSearchPara.GoodsNo = this.tEdit_GoodsNo.Text.Trim();

            // ���J���i�J�n�j
            recBgnGdsSearchPara.ApplyDateSt = this.tDateEdit_OpenDateSt.LongDate;

            // ���J���i�I���j
            recBgnGdsSearchPara.ApplyDateEd = this.tDateEdit_OpenDateEd.LongDate;

            // �폜�w��敪
            recBgnGdsSearchPara.DeleteFlag = this.tComboEditor_DeleteFlag.SelectedIndex;
        }

        /// <summary>
        /// �K�C�h�{�^���ݒ菈��
        /// </summary>
        /// <param name="enable">enable</param>
        /// <remarks>
        /// <br>Note       : �K�C�h�{�^���ݒ菈�����s���܂��B</br>
        /// <br>Programmer : �e�c ���V</br>
        /// <br>Date       : 2015/02/20</br>
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
        /// <br>Programmer : �e�c ���V</br>
        /// <br>Date       : 2015/02/20</br>
        /// </remarks>
        public void SetInitFocus()
        {
            this.tNedit_SectionCodeAllowZero.Focus();
        }

        /// <summary>
        /// ��ʂ̊�{���擾����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ��ʂ̊�{�����擾����</br>
        /// <br>Programmer : �e�c ���V</br>
        /// <br>Date       : 2015/02/20</br>
        /// </remarks>
        public void GetBaseInfo(out string sectionCode, out string sectionName)
        {
            sectionCode = this.tNedit_SectionCodeAllowZero.Text.Trim().PadLeft(2, '0');
            sectionName = this.uLabel_SectionName.Text;
        }

        /// <summary>
        /// ���Ӑ�I���������C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="customerSearchRet">���Ӑ挟���߂�l�N���X</param>
        /// <remarks>
        /// <br>Note        : ���Ӑ�I�����ɔ������܂��B</br>
        /// <br>Programmer	: �e�c ���V</br>
        /// <br>Date		: 2015/02/20</br>
        /// </remarks>
        private void CustomerSearchForm_CustomerSelect(object sender, CustomerSearchRet customerSearchRet)
        {
            if (customerSearchRet == null)
            {
                this._customerSearchRet = null;
                return;
            }
            this._customerSearchRet = customerSearchRet;
        }
        #endregion

        /// <summary>
        /// �摜�t�@�C���I������
        /// </summary>
        /// <param name="dats">�摜�t�@�C���o�C�i���f�[�^</param>
        /// <remarks>
        /// <br>Programmer : �{�{����</br>
        /// <br>Date       : 2015/01/28</br>
        /// </remarks>
        public void OpenGoodsImgFile(out Byte[] dats)
        {
            dats = null;

            string filePath = string.Empty;
            Assembly myAssembly = Assembly.GetExecutingAssembly();
            string path = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
           
            this.openFileDialog1.FileName = filePath;
            this.openFileDialog1.Filter = "�摜�t�@�C��(*.jpg;*.jpeg)|*.jpg;*.jpeg";
            if (this.openFileDialog1.InitialDirectory == string.Empty)
                this.openFileDialog1.InitialDirectory = path;

            DialogResult openResult = this.openFileDialog1.ShowDialog();
            if (openResult == DialogResult.OK)
            {
                string msg = string.Empty;
                Bitmap bmp = null;
                bool status = this.DatsFromBitmap(openFileDialog1.FileName, out bmp, out dats, out msg);
                if (status)
                {
                    this.openFileDialog1.InitialDirectory = openFileDialog1.FileName.Replace(openFileDialog1.SafeFileName, "");
                }
                else
                {
                    TMsgDisp.Show(
                         this,
                         emErrorLevel.ERR_LEVEL_EXCLAMATION,
                         this.Name,
                         msg,
                         0,
                         MessageBoxButtons.OK);
                }
                if (bmp != null)
                    bmp.Dispose();
            }
        }
        /// <summary>
        /// �ϊ��T�C�Y�擾����
        /// </summary>
        public void SaveSizeGet(ref int saveWidth, ref int saveHeight)
        {
            int iWidth = saveWidth;
            int iHeight = saveHeight;
            int dif = 0;

            // �c���Œ���������ɕύX�T�C�Y���v�Z����
            if ((iWidth > iHeight) && (iWidth > GOODSIMG_SAVE_WIDTH)) // �����c���������ꍇ
                {
                // �ő�l�Ƃ̍����v�Z
                dif = iWidth - GOODSIMG_SAVE_WIDTH;
                // �����c������䗦�ŃZ�b�g����
                saveWidth = saveWidth - dif;
                saveHeight = saveHeight - (int)(((double)iHeight / (double)iWidth) * dif);
            }
            else if ((iWidth < iHeight) && (iHeight > GOODSIMG_SAVE_HEIGHT)) // �c�������������ꍇ
            {
                // �ő�l�Ƃ̍����v�Z
                dif = iHeight - GOODSIMG_SAVE_HEIGHT;
                // �����c������䗦�ŃZ�b�g����
                // --- UPD 2015/03/09 Y.Wakita Redmine#3091 ---------->>>>>
                //saveWidth = saveWidth - (int)(((double)iHeight / (double)iWidth) * dif);
                saveWidth = saveWidth - (int)(((double)iWidth / (double)iHeight) * dif);
                // --- UPD 2015/03/09 Y.Wakita Redmine#3091 ----------<<<<<
                saveHeight = saveHeight - dif;
                }
            else if ((iWidth == iHeight) && (iWidth > GOODSIMG_SAVE_WIDTH)) // �c�Ɖ�������̏ꍇ
            {
                // �ő�l�Ƃ̍����v�Z
                dif = iWidth - GOODSIMG_SAVE_WIDTH;
                // �����c������䗦�ŃZ�b�g����
                saveWidth = saveWidth - dif;
                saveHeight = saveHeight - dif;
            }
        }

        private bool DatsFromBitmap(string fileName, out Bitmap bmp, out Byte[] dats, out string msg)
        {
            bmp = null;
            dats = null;
            msg = string.Empty;

            if (System.IO.Path.GetExtension(fileName) == ".jpg"
             || System.IO.Path.GetExtension(fileName) == ".jpeg"
             || System.IO.Path.GetExtension(fileName) == ".JPG"
             || System.IO.Path.GetExtension(fileName) == ".JPEG")
            {
                // Bitmap����
                // --- UPD 2015/03/03 Y.Wakita Redmine#304 ---------->>>>>
                //Bitmap bmpSrc = new Bitmap(fileName);

                Bitmap bmpSrc = null;
                using (FileStream fs = File.OpenRead(fileName))
                {
                    using (Image img = Image.FromStream(fs, false, false))
                    {
                        bmpSrc = new Bitmap(img);
                    }
                }
                // --- UPD 2015/03/03 Y.Wakita Redmine#304 ----------<<<<<

                int saveWidth = bmpSrc.Size.Width;
                int saveHeight = bmpSrc.Size.Height;

                // �ۑ��T�C�Y�擾
                SaveSizeGet(ref saveWidth, ref saveHeight);

                // --- UPD 2015/03/03 Y.Wakita Redmine#304 ---------->>>>>
                //Bitmap bmpDest = new Bitmap(bmpSrc, saveWidth, saveHeight);
                //System.IO.MemoryStream mms = new System.IO.MemoryStream();
                //bmpDest.Save(mms, System.Drawing.Imaging.ImageFormat.Jpeg);
                //dats = mms.GetBuffer();
                ////mms.Close();
                //mms.Dispose();
                //bmp = bmpDest;

                ////bmpSrc.Dispose();
                ////bmpDest.Dispose();

                using (Bitmap bmpDest = new Bitmap(bmpSrc, saveWidth, saveHeight))
                {
                    using (MemoryStream mms = new MemoryStream())
                    {
                bmpDest.Save(mms, System.Drawing.Imaging.ImageFormat.Jpeg);
                dats = mms.GetBuffer();
                        bmp = (Bitmap)bmpDest.Clone();
                    }
                }
                // --- UPD 2015/03/03 Y.Wakita Redmine#304 ----------<<<<<
            }
            else
            {
                msg = "�I�������t�@�C���͎g�p�ł��܂���B" + "\r\n" +
                      "�摜�t�@�C���i�g���q�F.jpg�A.jpeg�j��I�����ĉ������B";
                return false;
            }

            return true;
        }

        /// <summary>
        /// ���׏��v���r���[�\��
        /// </summary>
        /// <param name="rowIndex">�s�ԍ�</param>
        /// <remarks>
        /// <br>Programmer : �{�{����</br>
        /// <br>Date       : 2015/01/28</br>
        /// </remarks>
        public void GoodsInfoPreview(int rowIndex)
        {
            try
            {
                this.uCheckEditor_DisplayDivCode.CheckedChanged -= new EventHandler(this.uCheckEditor_DisplayDivCode_CheckedChanged);

                // --- DEL 2015/03/24 Y.Wakita ---------->>>>>
                //// �c�[���i���ד��̲́Ұ�ޓ��̓{�^���j�ݒ�
                //this._detailInput.tToolbarsManager_MainMenu.Tools["ButtonTool_Move"].SharedProps.Enabled = false;
                // --- DEL 2015/03/24 Y.Wakita ----------<<<<<

                if (rowIndex >= 0 && rowIndex < this._detailInput.uGrid_Details.Rows.Count)
                {
                    // --- DEL 2015/03/24 Y.Wakita ---------->>>>>
                    //// �c�[���i���ד��̲́Ұ�ޓ��̓{�^���j�ݒ�
                    //this._detailInput.tToolbarsManager_MainMenu.Tools["ButtonTool_Move"].SharedProps.Enabled = true;
                    // --- DEL 2015/03/24 Y.Wakita ----------<<<<<

                    int rowNo = rowIndex + 1;
                    uExGroupBox_Image.Text = "��" + rowNo.ToString() + "�@���Ӑ�ł̃C���[�W";
                    panel_SaleImage.Visible = true;

                    // �i��
                    this.tEdit_GoodsName.Text = this._detailInput.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsAcs.RecBgnGdsDataTable.GoodsNameColumn.ColumnName].Value.ToString().Trim();

                    // ���i�R�����g
                    this.tEdit_GoodsComment.Text = this._detailInput.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsAcs.RecBgnGdsDataTable.GoodsCommentColumn.ColumnName].Value.ToString().Trim();

                    // ���i�C���[�W
                    Byte[] dats = new byte[0];
                    if (this._detailInput.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsAcs.RecBgnGdsDataTable.GoodsImageColumn.ColumnName].Value.ToString().Length != 0)
                        dats = (Byte[])this._detailInput.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsAcs.RecBgnGdsDataTable.GoodsImageColumn.ColumnName].Value;

                    if (dats.Length != 0)
                    {
                        dats = (Byte[])this._detailInput.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsAcs.RecBgnGdsDataTable.GoodsImageColumn.ColumnName].Value;
                        if (dats != null)
                        {
                            // --- UPD 2015/03/03 Y.Wakita Redmine#304 ---------->>>>>
                            //Bitmap bmp = new Bitmap(im);
                            //im.Dispose();
                            ////ms.Close();

                            //this.pictureBox_GoodsImage.Image = bmp;
                            //bmp.Dispose();

                            using (MemoryStream ms = new MemoryStream(dats))
                            {
                                using (Image img = Image.FromStream(ms, false, false))
                                {
                                    Bitmap bmp = new Bitmap(img);
                                    this.pictureBox_GoodsImage.Image = bmp;
                                }
                            }
                            // --- UPD 2015/03/03 Y.Wakita Redmine#304 ----------<<<<<
                        }
                    }
                    else
                    {
                        this.pictureBox_GoodsImage.Image = null;
                    }

                    // ���������i��ٰ��
                    if (int.Parse(this._detailInput.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsAcs.RecBgnGdsDataTable.BrgnGoodsGrpCodeColumn.ColumnName].Value.ToString()) == 0)
                    {
                        this.tEdit_BrgnGoodsGrpCode.Text = string.Empty;
                        this.uLabel_BrgnGoodsGrpName.Text = string.Empty;
                    }
                    else
                    {
                        this.tEdit_BrgnGoodsGrpCode.Text = this._detailInput.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsAcs.RecBgnGdsDataTable.BrgnGoodsGrpCodeColumn.ColumnName].Value.ToString();
                        this.uLabel_BrgnGoodsGrpName.Text = this._detailInput.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsAcs.RecBgnGdsDataTable.BrgnGoodsGrpNameColumn.ColumnName].Value.ToString();
                    }

                    // �\���敪
                    if (this._detailInput.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsAcs.RecBgnGdsDataTable.DisplayDivCodeColumn.ColumnName].Text == "0")
                    {
                        this.uCheckEditor_DisplayDivCode.Checked = false;
                        // --- ADD 2015/03/16 Y.Wakita ��Q ---------->>>>>
                        // ���ڔ񊈐�
                        this.tEdit_BrgnGoodsGrpCode.Enabled = false;
                        this.uButton_BrgnGoodsGrpCodeGuide.Enabled = false;
                        this.tNedit_UnitCalcRate.Enabled = false;
                        this.tNedit_UnitPrice.Enabled = false;
                        // --- ADD 2015/03/16 Y.Wakita ��Q ----------<<<<<
                    }
                    else
                    {
                        this.uCheckEditor_DisplayDivCode.Checked = true;
                        // --- ADD 2015/03/16 Y.Wakita ��Q ---------->>>>>
                        // ���ڊ���
                        this.tEdit_BrgnGoodsGrpCode.Enabled = true;
                        this.uButton_BrgnGoodsGrpCodeGuide.Enabled = true;
                        this.tNedit_UnitCalcRate.Enabled = true;
                        this.tNedit_UnitPrice.Enabled = true;
                        // --- ADD 2015/03/16 Y.Wakita ��Q ----------<<<<<
                    }

                    // ���J�J�n��
                    string date_St = this._detailInput.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsAcs.RecBgnGdsDataTable.ApplyStaDateColumn.ColumnName].Value.ToString();
                    if (date_St == string.Empty)
                        this.tDateEdit_ApplyStaDate.LongDate = 0;
                    else
                        this.tDateEdit_ApplyStaDate.LongDate = int.Parse(date_St.Replace("/", ""));

                    // ���J�I����
                    string date_Ed = this._detailInput.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsAcs.RecBgnGdsDataTable.ApplyEndDateColumn.ColumnName].Value.ToString();
                    if (date_Ed == string.Empty)
                        this.tDateEdit_ApplyEndDate.LongDate = 0;
                    else
                        this.tDateEdit_ApplyEndDate.LongDate = int.Parse(date_Ed.Replace("/", ""));

                    this.DispApplyDate(date_St, date_Ed);

                    // ���[�J�[��]�������i
                    long makerPrice = (Int64)this._detailInput.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsAcs.RecBgnGdsDataTable.MkrSuggestRtPricColumn.ColumnName].Value;
                    this.uLabel_MkrSuggestRtPric.Text = "��" + makerPrice.ToString("#,###");
                    this.uLabel_MkrSuggestRtPric2.Text = makerPrice.ToString("#,###");

                    // �P���Z�o�|��
                    double unitCalcRate = (Double)this._detailInput.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsAcs.RecBgnGdsDataTable.UnitCalcRateColumn.ColumnName].Value;
                    this.tNedit_UnitCalcRate.Text = unitCalcRate.ToString("###.##");

                    // �P��
                    long unitPrice = int.Parse(this._detailInput.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsAcs.RecBgnGdsDataTable.UnitPriceColumn.ColumnName].Value.ToString());
                    this.tNedit_UnitPrice.Text = unitPrice.ToString("#,###");

                    // ���Ӑ�ʐݒ�
                    string recBgnCust = this._detailInput.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsAcs.RecBgnGdsDataTable.RecBgnCustColumn.ColumnName].Value.ToString();
                    if (recBgnCust == string.Empty)
                        this.uLabel_RecBgnCust.Visible = false;
                    else
                        this.uLabel_RecBgnCust.Visible = true;
                }
            }
            finally
            {
                this.uCheckEditor_DisplayDivCode.CheckedChanged += new EventHandler(this.uCheckEditor_DisplayDivCode_CheckedChanged);
            }
        
        }

        /// <summary>
        /// ���׏��v���r���[�\��
        /// </summary>
        /// <param name="rowIndex">�s�ԍ�</param>
        /// <remarks>
        /// <br>Programmer : �{�{����</br>
        /// <br>Date       : 2015/01/28</br>
        /// </remarks>
        public void PreviewColumnSync(int rowIndex, string columnKeyName)
        {
            try
            {
                this.uCheckEditor_DisplayDivCode.CheckedChanged -= new EventHandler(this.uCheckEditor_DisplayDivCode_CheckedChanged);

                // --- DEL 2015/03/24 Y.Wakita ---------->>>>>
                //// �c�[���i���ד��̲́Ұ�ޓ��̓{�^���j�ݒ�
                //this._detailInput.tToolbarsManager_MainMenu.Tools["ButtonTool_Move"].SharedProps.Enabled = false;
                // --- DEL 2015/03/24 Y.Wakita ----------<<<<<

                if (rowIndex >= 0 && rowIndex < this._detailInput.uGrid_Details.Rows.Count)
                {
                    //if (this._detailInput.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsAcs.RecBgnGdsDataTable.GoodsNoColumn.ColumnName].Value.ToString().Trim() != string.Empty)
                    //{
                        // --- DEL 2015/03/24 Y.Wakita ---------->>>>>
                        //// �c�[���i���ד��̲́Ұ�ޓ��̓{�^���j�ݒ�
                        //this._detailInput.tToolbarsManager_MainMenu.Tools["ButtonTool_Move"].SharedProps.Enabled = true;
                        ////this._detailInput.uButton_Move.Enabled = true;
                        // --- DEL 2015/03/24 Y.Wakita ----------<<<<<

                        int rowNo = rowIndex + 1;
                        uExGroupBox_Image.Text = "��" + rowNo.ToString() + "�@���Ӑ�ł̃C���[�W";
                        panel_SaleImage.Visible = true;

                        switch (columnKeyName)
                        {
                            // �i��
                            case "GoodsNo":
                                {
                                    // �i��
                                    this.tEdit_GoodsName.Text = this._detailInput.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsAcs.RecBgnGdsDataTable.GoodsNameColumn.ColumnName].Value.ToString().Trim();
                                    // ���i�R�����g
                                    this.tEdit_GoodsComment.Text = this._detailInput.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsAcs.RecBgnGdsDataTable.GoodsCommentColumn.ColumnName].Value.ToString().Trim();
                                    
                                    #region ���i�C���[�W����

                                    Byte[] dats = new byte[0];
                                    if (this._detailInput.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsAcs.RecBgnGdsDataTable.GoodsImageColumn.ColumnName].Value.ToString().Length != 0)
                                        dats = (Byte[])this._detailInput.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsAcs.RecBgnGdsDataTable.GoodsImageColumn.ColumnName].Value;

                                    if (dats.Length != 0)
                                    {
                                        dats = (Byte[])this._detailInput.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsAcs.RecBgnGdsDataTable.GoodsImageColumn.ColumnName].Value;
                                        if (dats != null)
                                        {
                                            using (MemoryStream ms = new MemoryStream(dats))
                                            {
                                                using (Image img = Image.FromStream(ms, false, false))
                                                {
                                                    Bitmap bmp = new Bitmap(img);
                                                    this.pictureBox_GoodsImage.Image = bmp;
                                                }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        this.pictureBox_GoodsImage.Image = null;
                                    }
                                    #endregion

                                    string brgnGoodsGrpCode = this._detailInput.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsAcs.RecBgnGdsDataTable.BrgnGoodsGrpCodeColumn.ColumnName].Value.ToString();
                                    string brgnGoodsGrpName = this._detailInput.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsAcs.RecBgnGdsDataTable.BrgnGoodsGrpNameColumn.ColumnName].Value.ToString();
                                    if (int.Parse(brgnGoodsGrpCode) == 0)
                                    {
                                        this.tEdit_BrgnGoodsGrpCode.Text = string.Empty;
                                        this.uLabel_BrgnGoodsGrpName.Text = string.Empty;
                                    }
                                    else
                                    {
                                        this.tEdit_BrgnGoodsGrpCode.Text = brgnGoodsGrpCode;
                                        this.uLabel_BrgnGoodsGrpName.Text = brgnGoodsGrpName;
                                    }
                                    
                        			// --- ADD 2015/03/24 Y.Wakita ---------->>>>>
                                    #region ����������
                                    // ���[�J�[��]�������i
                                    long makerPrice = (Int64)this._detailInput.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsAcs.RecBgnGdsDataTable.MkrSuggestRtPricColumn.ColumnName].Value;
                                    uLabel_MkrSuggestRtPric.Text = "��" + makerPrice.ToString("#,###");
                                    uLabel_MkrSuggestRtPric2.Text = makerPrice.ToString("#,###");

                                    // �P���Z�o�|��
                                    double unitCalcRate = (Double)this._detailInput.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsAcs.RecBgnGdsDataTable.UnitCalcRateColumn.ColumnName].Value;
                                    tNedit_UnitCalcRate.Text = unitCalcRate.ToString("###.##");

                                    // �P��
                                    long unitPrice = int.Parse(this._detailInput.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsAcs.RecBgnGdsDataTable.UnitPriceColumn.ColumnName].Value.ToString());
                                    tNedit_UnitPrice.Text = unitPrice.ToString("#,###");
                                    #endregion
                        			// --- ADD 2015/03/24 Y.Wakita ----------<<<<<

                                    break;
                                }
                        	// --- ADD 2015/03/24 Y.Wakita ---------->>>>>
                            // ���[�J�[
                            case "GoodsMakerCode":
                                {
                                    #region ����������
                                    // ���[�J�[��]�������i
                                    long makerPrice = (Int64)this._detailInput.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsAcs.RecBgnGdsDataTable.MkrSuggestRtPricColumn.ColumnName].Value;
                                    uLabel_MkrSuggestRtPric.Text = "��" + makerPrice.ToString("#,###");
                                    uLabel_MkrSuggestRtPric2.Text = makerPrice.ToString("#,###");

                                    // �P���Z�o�|��
                                    double unitCalcRate = (Double)this._detailInput.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsAcs.RecBgnGdsDataTable.UnitCalcRateColumn.ColumnName].Value;
                                    tNedit_UnitCalcRate.Text = unitCalcRate.ToString("###.##");

                                    // �P��
                                    long unitPrice = int.Parse(this._detailInput.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsAcs.RecBgnGdsDataTable.UnitPriceColumn.ColumnName].Value.ToString());
                                    tNedit_UnitPrice.Text = unitPrice.ToString("#,###");
                                    #endregion

                                    break;
                                }
                        	// --- ADD 2015/03/24 Y.Wakita ----------<<<<<
                            // �i��
                            case "GoodsName":
                                {
                                    this.tEdit_GoodsName.Text = this._detailInput.uGrid_Details.Rows[rowIndex].Cells[columnKeyName].Value.ToString().Trim();
                                    break;
                                }
                            // ���i�R�����g
                            case "GoodsComment": 
                                {
                                    this.tEdit_GoodsComment.Text = this._detailInput.uGrid_Details.Rows[rowIndex].Cells[columnKeyName].Value.ToString().Trim();
                                    break;
                                }
                            // ���i�C���[�W
                            case "GoodsImage":
                                {
                                    #region ���i�C���[�W����

                                    Byte[] dats = new byte[0];
                                    if (this._detailInput.uGrid_Details.Rows[rowIndex].Cells[columnKeyName].Value.ToString().Length != 0)
                                        dats = (Byte[])this._detailInput.uGrid_Details.Rows[rowIndex].Cells[columnKeyName].Value;

                                    if (dats.Length != 0)
                                    {
                                        dats = (Byte[])this._detailInput.uGrid_Details.Rows[rowIndex].Cells[columnKeyName].Value;
                                        if (dats != null)
                                        {
                                            // --- UPD 2015/03/03 Y.Wakita Redmine#304 ---------->>>>>
                                            //Bitmap bmp = new Bitmap(im);
                                            //im.Dispose();
                                            ////ms.Close();

                                            //this.pictureBox_GoodsImage.Image = bmp;
                                            //bmp.Dispose();

                                            using (MemoryStream ms = new MemoryStream(dats))
                                            {
                                                using (Image img = Image.FromStream(ms, false, false))
                                                {
                                                    Bitmap bmp = new Bitmap(img);
                                                    this.pictureBox_GoodsImage.Image = bmp;
                                                }
                                            }
                                            // --- UPD 2015/03/03 Y.Wakita Redmine#304 ----------<<<<<
                                        }
                                    }
                                    else
                                    {
                                        this.pictureBox_GoodsImage.Image = null;
                                    }
                                    break;

                                    #endregion
                                }
                            // ���������i��ٰ��
                            case "BrgnGoodsGrpCode":
                                {
                                    #region ���������i��ٰ�ߏ���
                                    // ���������i��ٰ�߁E���������i��ٰ�ߖ�
                                    string brgnGoodsGrpCode = this._detailInput.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsAcs.RecBgnGdsDataTable.BrgnGoodsGrpCodeColumn.ColumnName].Value.ToString();
                                    string brgnGoodsGrpName = this._detailInput.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsAcs.RecBgnGdsDataTable.BrgnGoodsGrpNameColumn.ColumnName].Value.ToString();
                                    if (int.Parse(brgnGoodsGrpCode) == 0)
                                    {
                                        this.tEdit_BrgnGoodsGrpCode.Text = string.Empty;
                                        this.uLabel_BrgnGoodsGrpName.Text = string.Empty;
                                    }
                                    else
                                    {
                                        this.tEdit_BrgnGoodsGrpCode.Text = brgnGoodsGrpCode;
                                        this.uLabel_BrgnGoodsGrpName.Text = brgnGoodsGrpName;
                                    }
                                    break;
                                    #endregion
                                }
                            // �\���敪
                            case "DisplayDivCode":
                                {
                                    #region  �\���敪����
                                    bool isChecked = this._detailInput.uGrid_Details.Rows[rowIndex].Cells[columnKeyName].Text == "0" ? false: true;
                                    this.uCheckEditor_DisplayDivCode.Checked = isChecked;

                                    // --- ADD 2015/03/16 Y.Wakita ��Q ---------->>>>>
                                    if (isChecked)
                                    {
                                        // ���ڊ���
                                        this.tEdit_BrgnGoodsGrpCode.Enabled = true;
                                        this.uButton_BrgnGoodsGrpCodeGuide.Enabled = true;
                                        this.tNedit_UnitCalcRate.Enabled = true;
                                        this.tNedit_UnitPrice.Enabled = true;
                                    }
                                    else
                                    {
                                        // ���ڔ񊈐�
                                        this.tEdit_BrgnGoodsGrpCode.Enabled = false;
                                        this.uButton_BrgnGoodsGrpCodeGuide.Enabled = false;
                                        this.tNedit_UnitCalcRate.Enabled = false;
                                        this.tNedit_UnitPrice.Enabled = false;
                                    }
                                    // --- ADD 2015/03/16 Y.Wakita ��Q ----------<<<<<

                                    // ���������i��ٰ�߁E���������i��ٰ�ߖ�
                                    string brgnGoodsGrpCode = this._detailInput.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsAcs.RecBgnGdsDataTable.BrgnGoodsGrpCodeColumn.ColumnName].Value.ToString();
                                    string brgnGoodsGrpName = this._detailInput.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsAcs.RecBgnGdsDataTable.BrgnGoodsGrpNameColumn.ColumnName].Value.ToString();

                                    // --- DEL 2015/03/16 Y.Wakita �v�] ---------->>>>>
                                    //if (isChecked)
                                    //{
                                    //    // ���i�O���[�v
                                    //    if (int.Parse(brgnGoodsGrpCode) == 0)
                                    //    {
                                    //        this.tEdit_BrgnGoodsGrpCode.Text = string.Empty;
                                    //        this.uLabel_BrgnGoodsGrpName.Text = string.Empty;
                                    //    }
                                    //    else
                                    //    {
                                    //        this.tEdit_BrgnGoodsGrpCode.Text = brgnGoodsGrpCode;
                                    //        this.uLabel_BrgnGoodsGrpName.Text = brgnGoodsGrpName;
                                    //    }

                                    //    // ���[�J�[��]�������i
                                    //    long makerPrice = (Int64)this._detailInput.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsAcs.RecBgnGdsDataTable.MkrSuggestRtPricColumn.ColumnName].Value;
                                    //    uLabel_MkrSuggestRtPric.Text = "��" + makerPrice.ToString("#,###");
                                    //    uLabel_MkrSuggestRtPric2.Text = makerPrice.ToString("#,###");

                                    //    // �P���Z�o�|��
                                    //    double unitCalcRate = (Double)this._detailInput.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsAcs.RecBgnGdsDataTable.UnitCalcRateColumn.ColumnName].Value;
                                    //    tNedit_UnitCalcRate.Text = unitCalcRate.ToString("###.##");

                                    //    // �P��
                                    //    long unitPrice = int.Parse(this._detailInput.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsAcs.RecBgnGdsDataTable.UnitPriceColumn.ColumnName].Value.ToString());
                                    //    tNedit_UnitPrice.Text = unitPrice.ToString("#,###");
                                    //}
                                    //else
                                    //{
                                    //    this.tEdit_BrgnGoodsGrpCode.Text = string.Empty;    // ���i��ٰ��
                                    //    this.uLabel_BrgnGoodsGrpName.Text = string.Empty;   // ���i��ٰ�ߖ�
                                    //    uLabel_MkrSuggestRtPric.Text = string.Empty;        // ���[�J�[��]�������i
                                    //    tNedit_UnitCalcRate.Text = string.Empty;            // �P���Z�o�|��
                                    //    tNedit_UnitPrice.Text = string.Empty;               // �P��
                                    //}
                                    // --- DEL 2015/03/16 Y.Wakita �v�] ----------<<<<<
                                    break;
                                    #endregion
                                }
                            // ���J�J�n���E�I����
                            case "ApplyStaDate":
                            case "ApplyEndDate":
                                {
                                    #region ���J�J�n�E�I��������

                                    // ���J�J�n��
                                    string date_St = this._detailInput.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsAcs.RecBgnGdsDataTable.ApplyStaDateColumn.ColumnName].Value.ToString();
                                    if (date_St == string.Empty)
                                        this.tDateEdit_ApplyStaDate.LongDate = 0;
                                    else
                                        this.tDateEdit_ApplyStaDate.LongDate = int.Parse(date_St.Replace("/", ""));

                                    // ���J�I����
                                    string date_Ed = this._detailInput.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsAcs.RecBgnGdsDataTable.ApplyEndDateColumn.ColumnName].Value.ToString();
                                    if (date_Ed == string.Empty)
                                        this.tDateEdit_ApplyEndDate.LongDate = 0;
                                    else
                                        this.tDateEdit_ApplyEndDate.LongDate = int.Parse(date_Ed.Replace("/", ""));

                                    this.DispApplyDate(date_St, date_Ed);

                                    // ���[�J�[��]�������i
                                    long makerPrice = (Int64)this._detailInput.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsAcs.RecBgnGdsDataTable.MkrSuggestRtPricColumn.ColumnName].Value;
                                    uLabel_MkrSuggestRtPric.Text = "��" + makerPrice.ToString("#,###");
                                    uLabel_MkrSuggestRtPric2.Text = makerPrice.ToString("#,###");

                                    // �P���Z�o�|��
                                    double unitCalcRate = (Double)this._detailInput.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsAcs.RecBgnGdsDataTable.UnitCalcRateColumn.ColumnName].Value;
                                    tNedit_UnitCalcRate.Text = unitCalcRate.ToString("###.##");

                                    // �P��
                                    long unitPrice = int.Parse(this._detailInput.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsAcs.RecBgnGdsDataTable.UnitPriceColumn.ColumnName].Value.ToString());
                                    tNedit_UnitPrice.Text = unitPrice.ToString("#,###");

                                    break;

                                    #endregion
                                }
                            // �P���Z�o�|��
                            case "UnitCalcRate":
                                {
                                    #region ����������
                                    // ���[�J�[��]�������i
                                    long makerPrice = (Int64)this._detailInput.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsAcs.RecBgnGdsDataTable.MkrSuggestRtPricColumn.ColumnName].Value;
                                    uLabel_MkrSuggestRtPric.Text = "��" + makerPrice.ToString("#,###");
                                    uLabel_MkrSuggestRtPric2.Text = makerPrice.ToString("#,###");

                                    // �P���Z�o�|��
                                    double unitCalcRate = (Double)this._detailInput.uGrid_Details.Rows[rowIndex].Cells[columnKeyName].Value;
                                    tNedit_UnitCalcRate.Text = unitCalcRate.ToString("###.##");

                                    // �P��
                                    long unitPrice = int.Parse(this._detailInput.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsAcs.RecBgnGdsDataTable.UnitPriceColumn.ColumnName].Value.ToString());
                                    tNedit_UnitPrice.Text = unitPrice.ToString("#,###");
                                    break;
                                    #endregion
                                }
                            // �P��
                            case "UnitPrice":
                                {
                                    long unitPrice = int.Parse(this._detailInput.uGrid_Details.Rows[rowIndex].Cells[columnKeyName].Value.ToString());
                                    tNedit_UnitPrice.Text = unitPrice.ToString("#,###");
                                    break;
                                }
                            // ���Ӑ�ʐݒ�
                            case "RecBgnCust":
                                {
                                    uLabel_RecBgnCust.Visible = true;
                                    break;
                                }
                        }
                    //}
                }
            }
            finally
            {
                this.uCheckEditor_DisplayDivCode.CheckedChanged += new EventHandler(this.uCheckEditor_DisplayDivCode_CheckedChanged);
            }
        }

        ///// <summary>
        ///// Click�C�x���g
        ///// </summary>
        private void uButton_FolderOpen_Click(object sender, EventArgs e)
        {
            Byte[] dats = new byte[0];

            this.OpenGoodsImgFile(out dats);

            if (dats != null)
            {
                // --- UPD 2015/03/03 Y.Wakita Redmine#304 ---------->>>>>
                //MemoryStream ms = new MemoryStream(dats);
                //Bitmap bmp = new Bitmap(ms);
                ////ms.Close();

                //this.setGoodsImage(bmp, dats);
                //bmp.Dispose();

                using (MemoryStream ms = new MemoryStream(dats))
                {
                    using (Image img = Image.FromStream(ms, false, false))
                    {
                        Bitmap bmp = new Bitmap(img);
                        this.setGoodsImage(bmp, dats);
                    }
                }
                // --- UPD 2015/03/03 Y.Wakita Redmine#304 ----------<<<<<
            }
        }

        ///// <summary>
        ///// DragDrop�C�x���g
        ///// </summary>
        private void pictureBox_GoodsImage_DragDrop(object sender, DragEventArgs e)
        {
            string filename = ((string[])e.Data.GetData(DataFormats.FileDrop))[0];

            string msg = string.Empty;
            Bitmap bmp = null;
            Byte[] dats = new Byte[0];
            bool status = this.DatsFromBitmap(filename, out bmp, out dats, out msg);
            if (status)
            {
                // �摜�ݒ�
                this.setGoodsImage(bmp, dats);
                //bmp.Dispose();
            }
            else
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    msg,
                    -1,
                    MessageBoxButtons.OK);
            }
        }

        ///// <summary>
        ///// DragEnter�C�x���g
        ///// </summary>
        private void pictureBox_GoodsImage_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        ///// <summary>
        ///// ���i�C���[�W�ݒ菈��
        ///// </summary>
        private void setGoodsImage(Bitmap bmp, Byte[] dats)
        {
            this.pictureBox_GoodsImage.Image = bmp;

            int rowIndex = this._detailInput.RowIndex;
            this._detailInput.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsAcs.RecBgnGdsDataTable.GoodsImageColumn.ColumnName].Value = dats;
            this._detailInput.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsAcs.RecBgnGdsDataTable.GoodsImageDmyColumn.ColumnName].Value = "�L";
        }

        ///// <summary>
        ///// ���i�R�����gKeyDown�C�x���g
        ///// </summary>
        private void tEdit_GoodsComment_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Alt && (e.KeyCode == Keys.Enter))
            {
                e.Handled = true;
                this.tEdit_GoodsComment.Text += System.Environment.NewLine;
                this.tEdit_GoodsComment.SelectionStart = tEdit_GoodsComment.Text.Length;
            }
        }

        /// <summary>
        /// �������߉^�p���Љ�{�^��
        /// </summary>
        private void uButton_HelpGuide_Click(object sender, EventArgs e)
        {
            string sPath = Path.Combine(_NSDirectory, PDF_HELP_FILE);
            if (!File.Exists(sPath))
            {
                TMsgDisp.Show(this
                             , emErrorLevel.ERR_LEVEL_INFO
                             , this.Name
                             , "�w���v�t�@�C�������݂��܂���B"
                             , 0
                             , MessageBoxButtons.OK);
                return;
            }
            System.Diagnostics.Process.Start(sPath);
        }

        /// <summary>
        /// ���_�`�F�b�N����
        /// </summary>
        public bool SectionCheck(string sectionCode)
        {
            string errMsg;
            SecInfoSet retSectionInfo;

            bool checkResult = this._recBgnGdsAcs.CheckSection(sectionCode, false, out errMsg, out retSectionInfo);
            if (checkResult)
            {
                //���_�N���A
                this.tNedit_SectionCodeAllowZero.Clear();
                this.uLabel_SectionName.Text = "";

                this._prevSectionCd = "";
                if (sectionCode != "")
                {
                    sectionCode = sectionCode.PadLeft(2, '0');
                }
                if (sectionCode == ALL_SECTION_CODE)
                {
                    this._prevSectionCd = sectionCode;
                    this.tNedit_SectionCodeAllowZero.Text = sectionCode;
                    this.uLabel_SectionName.Text = ALL_SECTION_NAME;
                }
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

        /// <summary>
        /// ���t�ҏW����
        /// </summary>
        private string DateFormat(string date)
        {
            string dateWk = string.Empty;

            if (date != string.Empty)
            {
                string year = date.Substring(0, 4);
                string month = date.Substring(4, 2);
                string day = date.Substring(6, 2);

                dateWk = year + "/" + month + "/" + day;
            }
            return dateWk; 
        }

        /// <summary>
        /// ���J�͈͂̃C���[�W�\���p
        /// </summary>
        private void DispApplyDate(string date_St, string date_Ed)
        {
            if (date_St != string.Empty && date_Ed != string.Empty)
            {
                date_St = DateTime.Parse(date_St).ToString("yyyy/M/d");
                date_Ed = DateTime.Parse(date_Ed).ToString("yyyy/M/d");
                if (date_St.Substring(1, 4) == date_Ed.Substring(1, 4))
                {
                    date_Ed = date_Ed.Substring(5);
                }
                this.uLabel_ApplyDate.Text = date_St + "�`" + date_Ed + "�܂�";
            }
            else
            {
                this.uLabel_ApplyDate.Text = string.Empty;
            }
        }

        #region ���������i�O���[�v�K�C�h
        /// <summary>
        /// ���������i�O���[�v�K�C�h�{�^��
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : ���������i�O���[�v�K�C�h�{�^��</br>
        /// <br>Programmer : �e�c ���V</br>
        /// <br>Date       : 2015/02/20</br>
        /// </remarks>
        private void uButton_BrgnGoodsGrpCodeGuide_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                int customerCode = 0;

                PMREC09030UA recBgnGrpSearchForm = new PMREC09030UA(PMREC09030UA.GUIDETYPE_NORMAL, customerCode, new ArrayList(this._recBgnGdsAcs.CustomerSearchRetList));
                recBgnGrpSearchForm.RecBgnGrpSelect += new PMREC09030UA.RecBgnGrpSelectEventHandler(this.RecBgnGrpSearchForm_RecBgnGrpSelect);
                recBgnGrpSearchForm.ShowDialog(this);

                if (this._recBgnGrpRet != null)
                {
                    string errMsg = string.Empty;

                    // �l�����݂̏ꍇ
                    if (this._recBgnGdsAcs.CheckRecBgnGrp(this._recBgnGrpRet.InqOriginalEpCd, this._recBgnGrpRet.InqOriginalSecCd, this._recBgnGrpRet.BrgnGoodsGrpCode, false, out errMsg))
                    {
                        // ���ʃZ�b�g
                        this.tEdit_BrgnGoodsGrpCode.Text = this._recBgnGrpRet.BrgnGoodsGrpCode.ToString().PadLeft(4, '0');
                        this.uLabel_BrgnGoodsGrpName.Text = this._recBgnGrpRet.BrgnGoodsGrpTitle;

                        this._recBgnGrpRet = null;

                        if (sender != null)
                        {
                            this.uCheckEditor_DisplayDivCode.Focus();
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

                        // ���������i�O���[�v�̃N���A
                        this.tEdit_BrgnGoodsGrpCode.Clear();
                        this.uLabel_BrgnGoodsGrpName.Text=string.Empty;
                    }

                    int rowIndex = this._detailInput.RowIndex;
                    if (this.tEdit_BrgnGoodsGrpCode.Text != string.Empty)
                    {
                        // ���������i��ٰ��
                        this._detailInput.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsAcs.RecBgnGdsDataTable.BrgnGoodsGrpCodeColumn.ColumnName].Value = this.tEdit_BrgnGoodsGrpCode.Text.Trim();
                        // ���������i��ٰ�ߖ�
                        this._detailInput.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsAcs.RecBgnGdsDataTable.BrgnGoodsGrpNameColumn.ColumnName].Value = this.uLabel_BrgnGoodsGrpName.Text.Trim();
                    }
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// ���������i�O���[�v�I���������C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="customerSearchRet">���������i�O���[�v�����߂�l�N���X</param>
        /// <remarks>
        /// <br>Note        : ���������i�O���[�v�I�����ɔ������܂��B</br>
        /// <br>Programmer	: �e�c ���V</br>
        /// <br>Date		: 2015/02/20</br>
        /// </remarks>
        private void RecBgnGrpSearchForm_RecBgnGrpSelect(object sender, RecBgnGrpRet recBgnGrpRet)
        {
            if (recBgnGrpRet == null)
            {
                this._recBgnGrpRet = null;
                return;
            }
            this._recBgnGrpRet = recBgnGrpRet;
        }

        #endregion

        /// <summary>
        /// ���J�͈͂̃C���[�W�\���p
        /// </summary>
        private void uButton_OpenRecBgnCust_Click(object sender, EventArgs e)
        {
            // ���Ӑ�ʐݒ��ʌĂяo��
            int Row = this._detailInput.RowIndex;
            this._detailInput.OpenRecBgnCustDialog(Row);
        }

        #region ���������i��ٰ�ߏ󋵏Ɖ�
        /// <summary>
        /// ���������i��ٰ�ߏ󋵏Ɖ�{�^��
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : ���������i��ٰ�ߏ󋵏Ɖ�{�^��</br>
        /// <br>Programmer : �e�c ���V</br>
        /// <br>Date       : 2015/02/20</br>
        /// </remarks>
        private void uButton_CategoryGuide_Click(object sender, EventArgs e)
        {
                this.Cursor = Cursors.WaitCursor;
                int customerCode = 0;

                PMREC09030UA recBgnGrpSearchForm = new PMREC09030UA(PMREC09030UA.GUIDETYPE_READONLY, customerCode, new ArrayList(this._recBgnGdsAcs.CustomerSearchRetList));
                recBgnGrpSearchForm.RecBgnGrpSelect += new PMREC09030UA.RecBgnGrpSelectEventHandler(this.RecBgnGrpSearchForm_RecBgnGrpSelect);
                recBgnGrpSearchForm.ShowDialog(this);
                recBgnGrpSearchForm.Close();
        }
        #endregion

        /// <summary>
        /// �c�[���o�[��F6�̐؂�ւ��p
        /// </summary>
        private void ChangeToolsMove(int mode)
        {
            switch (mode)
            {
                case 1:

                    this.tToolsManager_MainMenu.Tools["ButtonTool_Move"].SharedProps.Enabled = true;
                    this.tToolsManager_MainMenu.Tools["ButtonTool_Move"].SharedProps.Caption = "�Ұ�ޓ���(F6)";
                    this.tToolsManager_MainMenu.Tools["ButtonTool_Move"].SharedProps.CustomizerCaption = "�Ұ�ޓ��̓{�^��";
                    this.tToolsManager_MainMenu.Tools["ButtonTool_Move"].SharedProps.CustomizerDescription = "�Ұ�ޓ��̓{�^��";
                    this.tToolsManager_MainMenu.Tools["ButtonTool_Move"].SharedProps.ToolTipText = "�C���[�W�̍��ڂֈړ����܂��B";
                    break;

                case 2:

                    this.tToolsManager_MainMenu.Tools["ButtonTool_Move"].SharedProps.Enabled = true;
                    this.tToolsManager_MainMenu.Tools["ButtonTool_Move"].SharedProps.Caption = "���ד���(F6)";
                    this.tToolsManager_MainMenu.Tools["ButtonTool_Move"].SharedProps.CustomizerCaption = "���ד��̓{�^��";
                    this.tToolsManager_MainMenu.Tools["ButtonTool_Move"].SharedProps.CustomizerDescription = "���ד��̓{�^��";
                    this.tToolsManager_MainMenu.Tools["ButtonTool_Move"].SharedProps.ToolTipText = "���ׂ̍��ڂֈړ����܂��B";
                    break;

                default:
                    this.tToolsManager_MainMenu.Tools["ButtonTool_Move"].SharedProps.Enabled = false;
                    this.tToolsManager_MainMenu.Tools["ButtonTool_Move"].SharedProps.Caption = "�Ұ�ޓ���(F6)";
                    this.tToolsManager_MainMenu.Tools["ButtonTool_Move"].SharedProps.CustomizerCaption = "�Ұ�ޓ��̓{�^��";
                    this.tToolsManager_MainMenu.Tools["ButtonTool_Move"].SharedProps.CustomizerDescription = "�Ұ�ޓ��̓{�^��";
                    this.tToolsManager_MainMenu.Tools["ButtonTool_Move"].SharedProps.ToolTipText = "�Ұ�ނ̍��ڂֈړ����܂��B";
                    break;
            }
        }

        /// <summary>
        /// ���J�敪ON/OFF�C�x���g
        /// </summary>
        private void uCheckEditor_DisplayDivCode_CheckedChanged(object sender, EventArgs e)
        {

            int rowIndex = this._detailInput.RowIndex;

            if (this.uCheckEditor_DisplayDivCode.Checked == true)
            {
                // ���ڊ���
                this.tEdit_BrgnGoodsGrpCode.Enabled = true;
                this.uButton_BrgnGoodsGrpCodeGuide.Enabled = true;
                this.tNedit_UnitCalcRate.Enabled = true;
                this.tNedit_UnitPrice.Enabled = true;

                // ���ׂɔ��f
                this._detailInput.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsAcs.RecBgnGdsDataTable.DisplayDivCodeColumn.ColumnName].Value = "1";
            }
            else
            {
                // ���ڔ񊈐�
                this.tEdit_BrgnGoodsGrpCode.Enabled = false;
                this.uButton_BrgnGoodsGrpCodeGuide.Enabled = false;
                this.tNedit_UnitCalcRate.Enabled = false;
                this.tNedit_UnitPrice.Enabled = false;

                // ���ׂɔ��f
                this._detailInput.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsAcs.RecBgnGdsDataTable.DisplayDivCodeColumn.ColumnName].Value = "0";
            }
        }

        /// <summary>
        /// ���J�J�n��Enter�C�x���g
        /// </summary>
        private void tDateEdit_ApplyStaDate_Enter(object sender, EventArgs e)
        {
            if (this.tDateEdit_ApplyStaDate.LongDate == 0)
            {
                string dateNow = DateTime.Now.ToString("yyyyMMdd");
                this.tDateEdit_ApplyStaDate.LongDate = int.Parse(dateNow);
            }
        }
        /// <summary>
        /// ���J�I����Enter�C�x���g
        /// </summary>
        private void tDateEdit_ApplyEndDate_Enter(object sender, EventArgs e)
        {
            if (this.tDateEdit_ApplyEndDate.LongDate == 0)
            {
                string dateNow = DateTime.Now.ToString("yyyyMMdd");
                this.tDateEdit_ApplyEndDate.LongDate = int.Parse(dateNow);
            }
        }
    }
}
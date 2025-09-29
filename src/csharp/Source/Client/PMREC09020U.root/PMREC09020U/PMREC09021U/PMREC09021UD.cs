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
    public partial class PMREC09021UD : Form
    {

        # region Private Members

        /// <summary></summary>
        private PMREC09021UE _detailInput;
        /// <summary>�C���[�W���X�g</summary>
        private ImageList _imageList16 = null;
        /// <summary></summary>
        private ControlScreenSkin _controlScreenSkin;
        ///// <summary></summary>
        //private Control _prevControl = null;

        #region Grid�֘A

        /// <summary>�`�[�\���^�u ��T�C�Y���������l</summary>
        private bool _columnWidthAutoAdjust = false;
        /// <summary>�\���F�����t�H���g�T�C�Y</summary>
        private const int CT_DEF_FONT_SIZE = 10;
        /// <summary>ReadOnly�Z���w�i�F</summary>
        private static readonly Color ct_READONLY_CELL_COLOR = Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(220)))));
        /// <summary>�����T�C�Y</summary>
        private readonly int[] _fontpitchSize = new int[] { 6, 8, 9, 10, 11, 12, 14, 16, 18, 20, 22, 24 };
        /// <summary>���׃f�[�^���o�ő匏��</summary>
        private const long DATA_COUNT_MAX = 20000;

        #endregion

        #region �c�[���o�[�{�^��

        /// <summary>�I��</summary>
        private Infragistics.Win.UltraWinToolbars.ButtonTool _closeButton;                    // �I���{�^��
        /// <summary>�m��</summary>
        private Infragistics.Win.UltraWinToolbars.ButtonTool _saveButton;                     // �ۑ��{�^��
        /// <summary>�K�C�h</summary>
        private Infragistics.Win.UltraWinToolbars.ButtonTool _guideButton;                    // �K�C�h�{�^��

        /// <summary>�I��:�L�[������</summary>
        private const string TOOLBAR_CLOSEBUTTON_KEY = "ButtonTool_Close";						// �I��
        /// <summary>�m��:�L�[������</summary>
        private const string TOOLBAR_SAVEBUTTON_KEY = "ButtonTool_Save";						// �ۑ�
        /// <summary>�K�C�h:�L�[������</summary>
        private const string TOOLBAR_GUIDEBUTTON_KEY = "ButtonTool_Guide";						// �K�C�h

        #endregion

        #region �A�N�Z�X�N���X

        /// <summary>���Ӑ���</summary>
        private CustomerInfoAcs _customerInfoAcs = null;
        /// <summary>�������ݒ�</summary>
        private RecBgnGdsAcs _recBgnGdsAcs = null;
        ///// <summary>���[�J�[</summary>
        //private MakerAcs _makerAcs = null;
        /// <summary>���_</summary>
        private SecInfoSetAcs _secInfoSetAcs;
        /// <summary>���[�U�[�K�C�h</summary>
        private UserGuideAcs _userGuideAcs;
        /// <summary>���t�擾���i</summary>
        private DateGetAcs _dateGetAcs;

        #endregion

        /// <summary>���O�C����ƃR�[�h</summary>
        private string _enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
        /// <summary>���O�C�����_�R�[�h</summary>
        private string _loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;

        /// <summary>�S�Аݒ�F���_�R�[�h</summary>
        private const string ALL_SECTION_CODE = "00";
        /// <summary>�S�Аݒ�F���_��</summary>
        private const string ALL_SECTION_NAME = "�S��";

        /// <summary>���Ӑ挟���߂�l</summary>
        private CustomerSearchRet _customerSearchRet = null;

        /// <summary>���_�E�⍇���f�[�^�e�[�u��</summary>
        private RecBgnGdsDataSet.SecCusSetDataTable _secCusSetDataTable;

        /// <summary>���������i�ʐݒ�f�[�^�e�[�u��</summary>
        private RecBgnGdsDataSet.RecBgnCustDataTable _recBgnCustDataTable;


        #endregion

        #region Public Property

        /// <summary>
        /// ���������i�ݒ�}�X�^ �A�N�Z�X�N���X�v���p�e�B
        /// </summary>
        public RecBgnGdsDataSet.RecBgnCustDataTable RecBgnCustDataTable
        {
            get { return this._recBgnCustDataTable; }
        }

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
        public PMREC09021UD(RecBgnGdsCustInfo recBgnGdsCustInfo)
        {
            InitializeComponent();

            // �ϐ�������
            this._recBgnCustDataTable = (RecBgnGdsDataSet.RecBgnCustDataTable)recBgnGdsCustInfo.recBgnCust.Copy();
            this._detailInput = new PMREC09021UE(recBgnGdsCustInfo);
            this._imageList16 = IconResourceManagement.ImageList16;
            this._closeButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools["ButtonTool_Close"];
            this._saveButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools["ButtonTool_Save"];
            this._guideButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools["ButtonTool_Guide"];
            //this._detailInput.GridKeyUpTopRow += new EventHandler(this.GriedDetail_GridKeyUpTopRow);
            this._controlScreenSkin = new ControlScreenSkin();
            this._detailInput.SetGuidButton += new PMREC09021UE.SetGuidButtonEventHandler(this.SetGuidButton);

            this._recBgnGdsAcs = this._detailInput.RecBgnGdsAcs;
            this._secInfoSetAcs = new SecInfoSetAcs();
            this._userGuideAcs = new UserGuideAcs();
            this._customerInfoAcs = new CustomerInfoAcs();

            // �ݒ�ǂݍ���
            this._detailInput.Deserialize();

        }
        #endregion

        #region �C�x���g

        #region �t�H�[��

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
        private void PMREC09021UD_Load(object sender, EventArgs e)
        {
            
            // Skin�ݒ�
            this._controlScreenSkin.LoadSkin();

            List<string> controlNameList = new List<string>();
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

            // �O���b�h
            this._detailInput.LoadSettings();

            // ���t�擾���i
            _dateGetAcs = DateGetAcs.GetInstance();

        }

        /// <summary>
        /// �t�H�[���@Shown�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PMREC09021UD_Shown(object sender, EventArgs e)
        {
            this._detailInput.Select();
            this._detailInput.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
        }

        #endregion

        #region �{�^��

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
            this._saveButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SAVE;
            this._guideButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.GUIDE;
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
                // �m��
                case TOOLBAR_SAVEBUTTON_KEY:
                    {
                        this._detailInput.uGrid_Details.PerformAction(UltraGridAction.ExitEditMode);
                        this._detailInput.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);

                        if (this.Save() == 0) DialogResult = DialogResult.OK;

                        break;
                    }
                // �K�C�h
                case TOOLBAR_GUIDEBUTTON_KEY:
                    {
                        this.GuideStart();
                        break;
                    }
            }
        }

        #endregion

        #region �t�H�[�J�X����

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
                                        if (this._detailInput.uGrid_Details.ActiveCell.Column.Key == this._recBgnCustDataTable.CustomerCodeColumn.ColumnName)
                                        {
                                            this._detailInput.uGrid_Details.ActiveCell.Selected = false;
                                            this._detailInput.uGrid_Details.ActiveCell = null;
                                            if (this._detailInput.uGrid_Details.ActiveRow != null)
                                            {
                                                this._detailInput.uGrid_Details.ActiveRow.Selected = false;
                                                this._detailInput.uGrid_Details.ActiveRow = null;
                                            }
                                            break;
                                        }
                                        else if (this._recBgnGdsAcs.PrevRecBgnGdsDic != null
                                              && this._recBgnGdsAcs.PrevRecBgnGdsDic.Count <= 0
                                              && this._detailInput.uGrid_Details.ActiveCell.Column.Key == this._recBgnCustDataTable.CustomerCodeColumn.ColumnName)
                                        {
                                            this._detailInput.uGrid_Details.ActiveCell.Selected = false;
                                            this._detailInput.uGrid_Details.ActiveCell = null;
                                            if (this._detailInput.uGrid_Details.ActiveRow != null)
                                            {
                                                this._detailInput.uGrid_Details.ActiveRow.Selected = false;
                                                this._detailInput.uGrid_Details.ActiveRow = null;
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
                case "PMREC09021UE":
                    {
                        if (e.NextCtrl != null)
                        {
                            if (e.NextCtrl.Name == "uButton_RowDelete"
                             || e.NextCtrl.Name == "_PMREC09021UD_Toolbars_Dock_Area_Top"
                             || e.NextCtrl.Name == "_PMREC09021UE_Toolbars_Dock_Area_Top")
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
                    case "uGrid_Details":
                        {
                            this._detailInput.SetGridGuid();
                            break;
                        }
                    case "_PMREC09021UD_Toolbars_Dock_Area_Top":
                    case "_PMREC09021UE_Toolbars_Dock_Area_Top":
                        break;
                    default:
                        SetGuidButton(false);
                        break;
                }
            }
            #endregion
        }

        #endregion 

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

                editBand.Columns[this._recBgnCustDataTable.RowNoColumn.ColumnName].Width = 40;		            // ��
                editBand.Columns[this._recBgnCustDataTable.UpdateTimeColumn.ColumnName].Width = 80;		        // �폜��
                editBand.Columns[this._recBgnCustDataTable.CustomerCodeColumn.ColumnName].Width = 65;		    // ���Ӑ�
                editBand.Columns[this._recBgnCustDataTable.CustomerNameColumn.ColumnName].Width = 130;		    // ���Ӑ於
                editBand.Columns[this._recBgnCustDataTable.BrgnGoodsGrpCodeColumn.ColumnName].Width = 65;	    // ���������i�O���[�v�R�[�h
                editBand.Columns[this._recBgnCustDataTable.BrgnGoodsGrpNameColumn.ColumnName].Width = 100;	    // ���������i�O���[�v��
                editBand.Columns[this._recBgnCustDataTable.DisplayDivCodeColumn.ColumnName].Width = 40;	        // �\���敪
                editBand.Columns[this._recBgnCustDataTable.ApplyStaDateColumn.ColumnName].Width = 80;		    // ���J�J�n��
                editBand.Columns[this._recBgnCustDataTable.ApplyEndDateColumn.ColumnName].Width = 80;		    // ���J�I����
                editBand.Columns[this._recBgnCustDataTable.MkrSuggestRtPricColumn.ColumnName].Width = 90;	    // Ұ����]�������i
                editBand.Columns[this._recBgnCustDataTable.ListPriceColumn.ColumnName].Width = 90;	            // �艿
                editBand.Columns[this._recBgnCustDataTable.UnitCalcRateColumn.ColumnName].Width = 75;           // �P���Z�o�|��
                editBand.Columns[this._recBgnCustDataTable.UnitPriceColumn.ColumnName].Width = 90;              // ����P��
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
        /// �m�菈��
        /// </summary>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : �m�菈�����s���܂��B</br>
        /// <br>Programmer : �e�c ���V</br>
        /// <br>Date       : 2015/02/20</br>
        /// </remarks>
        private int Save()
        {

            int status = -1;

            // �o�^�f�[�^�擾
            RecBgnGdsDataSet.RecBgnCustDataTable recBgnCust = null;
            if (this._detailInput.CheckSaveDate(out recBgnCust))
            {
                // �ԋp�f�[�^���Z�b�g
                this._recBgnCustDataTable = this._detailInput.GetResultRecBgnCust();
                status = 0;
            }
            
            return status;
        }

        /// <summary>
        /// ShowDialog
        /// </summary>
        /// <returns>DialogResult</returns>
        internal new DialogResult ShowDialog()
        {
            DialogResult ret = base.ShowDialog();
            return ret;
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
            if(this._detailInput.IsUpdated())
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
                        DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
                else if (dialogResult == DialogResult.No)
                {
                    DialogResult = DialogResult.Cancel;
                    this.Close();
                }
                else if (dialogResult == DialogResult.Cancel)
                {
                    DialogResult = DialogResult.Cancel;
                }
            }
            else
            {
                DialogResult = DialogResult.Cancel;
                this.Close();
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
            // �O���b�h
            int rowIndex = -1;
            RecBgnGdsDataSet.RecBgnCustRow dataRow = null;
            string keyName = this._detailInput.GetFocusColumnKey(out rowIndex, out dataRow);
            if (!string.Empty.Equals(keyName))
            {
                switch (keyName)
                {
                    case "CustomerCode":
                        {
                            this._detailInput.SetCustomerCodeGuide(rowIndex);
                            break;
                        }
                    case "BrgnGoodsGrpCode":
                        {
                            if (!dataRow.CustomerCode.Trim().Equals(string.Empty)) this._detailInput.SetGdsGrpCodeGuide(rowIndex, int.Parse(dataRow.CustomerCode.Trim()));
                            break;
                        }
                    default:
                        break;
                }
            }
        }

        ///// <summary>
        ///// �ڍ׃O���b�h�ŏ�ʍs�A�b�v�C�x���g����
        ///// </summary>
        ///// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        ///// <param name="e">�C�x���g�p�����[�^�N���X</param>
        ///// <remarks>
        ///// <br>Note       : �ڍ׃O���b�h�ŏ�ʍs�A�v�E�����ɔ������܂��B</br>      
        ///// <br>Programmer : �e�c ���V</br>                                  
        ///// <br>Date       : 2015/02/20</br> 
        ///// </remarks> 
        //private void GriedDetail_GridKeyUpTopRow(object sender, EventArgs e)
        //{
        //    Control control = null;

        //    if (control != null)
        //    {
        //        control.Focus();
        //    }

        //    this._prevControl = this.ActiveControl;
        //}

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

        ///// <summary>
        ///// ��ʏ������̎��A�t�H�[�J�X��ݒ肷��B
        ///// </summary>
        ///// <remarks>
        ///// <br>Note       : ��ʏ������̎��A�t�H�[�J�X��ݒ肷��B</br>
        ///// <br>Programmer : �e�c ���V</br>
        ///// <br>Date       : 2015/02/20</br>
        ///// </remarks>
        //public void SetInitFocus()
        //{
        //    // this.tNedit_SectionCodeAllowZero.Focus();
        //}

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

    }
}
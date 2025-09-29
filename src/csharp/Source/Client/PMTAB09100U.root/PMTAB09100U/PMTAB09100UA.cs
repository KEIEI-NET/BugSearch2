//**********************************************************************//
// �V�X�e��         �F.NS�V���[�Y                                       //
// �v���O��������   �FPMTAB�S�̐ݒ�i���_�ʁj�}�X�^                     //
// �v���O�����T�v   �FPMTAB�S�̐ݒ�i���_�ʁj�̓o�^�E�C���E�폜���s��   //
// ---------------------------------------------------------------------//
//					Copyright(c) 2013 Broadleaf Co.,Ltd.				//
// =====================================================================//
// �Ǘ��ԍ�  10902622-01     �쐬�S���F���|��@�@�@�@�@�@�@�@�@�@�@�@�@
// �C����    2013/05/31�@    �C�����e�F�V�K�쐬
// ---------------------------------------------------------------------//
// �C�����e�@��Q�� #38166�̑Ή�
// �Ǘ��ԍ�  10902622-01 �쐬�S�� : huangt
// �� �� ��  2013/07/11  �쐬���e : ����p�i�Ԃ̐���Ɋւ���
//----------------------------------------------------------------------//
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Collections.Generic;

using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Common;
using Broadleaf.Application.Controller.Util;
using Infragistics.Win.Misc;
using System.Text.RegularExpressions;


namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// �^�u���b�g�S�̐ݒ�}�X�^(���_��)�t�H�[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �^�u���b�g�S�̐ݒ�}�X�^(���_��)���s���܂��B</br>
    /// <br>Programmer : ���|��</br>
    /// <br>Date       : 2013/05/31</br>
    /// </remarks>
    public class PMTAB09100UA : System.Windows.Forms.Form, IMasterMaintenanceMultiType
    {
        # region Private Members (Component)

        private Broadleaf.Library.Windows.Forms.TRetKeyControl tRetKeyControl1;
        private Broadleaf.Library.Windows.Forms.TArrowKeyControl tArrowKeyControl1;
        private Infragistics.Win.UltraWinStatusBar.UltraStatusBar ultraStatusBar1;
        private Infragistics.Win.Misc.UltraButton Delete_Button;
        private Infragistics.Win.Misc.UltraButton Revive_Button;
        private Infragistics.Win.Misc.UltraButton Ok_Button;
        private Infragistics.Win.Misc.UltraButton Cancel_Button;
        private Infragistics.Win.Misc.UltraLabel Mode_Label;
        private System.Windows.Forms.Timer Initial_Timer;
        private Broadleaf.Library.Windows.Forms.TEdit SectionGuideNm_tEdit;
        private Infragistics.Win.Misc.UltraLabel SectionCode_Title_Label;
        private System.Data.DataSet Bind_DataSet;
        private Infragistics.Win.UltraWinToolTip.UltraToolTipManager ultraToolTipManager1;
        private Panel Button_Panel;
        private UltraButton SectionGuide_ultraButton;
        private UiSetControl uiSetControl1;
        private UltraButton Renewal_Button;
        private UltraLabel ultraLabel15;
        private UltraLabel ultraLabel1;
        private UltraLabel CashRegisterNo_Title_Label;
        private TEdit CashRegisterNoNm_tEdit;
        private UltraLabel LiPriSelPrtGdsNoDiv_Title_Lable;
        private TComboEditor LiPriSelPrtGdsNoDiv_tComboEditor;
        private TNedit CashRegisterNo_tEdit;
        private TEdit tEdit_SectionCodeAllowZero2;
        private System.ComponentModel.IContainer components;

        # endregion

        # region Constructor

        /// <summary>
        /// �^�u���b�g�S�̐ݒ�}�X�^(���_��)�t�H�[���N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �t�H�[���N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer : ���|��</br>
        /// <br>Date       : 2013/05/31</br>
        /// </remarks>
        public PMTAB09100UA()
        {
            InitializeComponent();

            // �f�[�^�Z�b�g����\�z����
            DataSetColumnConstruction();

            // �v���p�e�B�����l�ݒ�
            this._canPrint                  = false;
            this._canClose                  = false;
            this._canNew                    = true;
            this._canDelete                 = true;

            this._canLogicalDeleteDataExtraction = true;
            this._defaultAutoFillToColumn = false;
            this._canSpecificationSearch = false;
            this._dataIndex = -1;

            // ��ƃR�[�h���擾
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            this._pmTabTtlStSecAcs = new PmTabTtlStSecAcs();       // PMTAB�S�̐ݒ�}�X�^(���_��)

            this._detailsTable = new Hashtable();
            this._allSearchHash = new Hashtable();

            this._detailsIndexBuf = -2;

            this._posTerminalMgAcs = new PosTerminalMgAcs();

            this._preCashRegisterNo = 0;

            GetCacheData();
        }

        # endregion

        # region Dispose

        /// <summary>
        /// �g�p����Ă��郊�\�[�X�Ɍ㏈�������s���܂��B
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        # endregion

        #region Windows �t�H�[�� �f�U�C�i�Ő������ꂽ�R�[�h

        /// <summary>
        /// �f�U�C�i �T�|�[�g�ɕK�v�ȃ��\�b�h�ł��B���̃��\�b�h�̓��e��
        /// �R�[�h �G�f�B�^�ŕύX���Ȃ��ł��������B
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("���_�K�C�h", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance44 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance45 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance79 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PMTAB09100UA));
            this.tRetKeyControl1 = new Broadleaf.Library.Windows.Forms.TRetKeyControl(this.components);
            this.tArrowKeyControl1 = new Broadleaf.Library.Windows.Forms.TArrowKeyControl(this.components);
            this.ultraStatusBar1 = new Infragistics.Win.UltraWinStatusBar.UltraStatusBar();
            this.Delete_Button = new Infragistics.Win.Misc.UltraButton();
            this.Revive_Button = new Infragistics.Win.Misc.UltraButton();
            this.Ok_Button = new Infragistics.Win.Misc.UltraButton();
            this.Cancel_Button = new Infragistics.Win.Misc.UltraButton();
            this.SectionCode_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.Mode_Label = new Infragistics.Win.Misc.UltraLabel();
            this.SectionGuideNm_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.Initial_Timer = new System.Windows.Forms.Timer(this.components);
            this.Bind_DataSet = new System.Data.DataSet();
            this.ultraToolTipManager1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipManager(this.components);
            this.SectionGuide_ultraButton = new Infragistics.Win.Misc.UltraButton();
            this.Button_Panel = new System.Windows.Forms.Panel();
            this.Renewal_Button = new Infragistics.Win.Misc.UltraButton();
            this.uiSetControl1 = new Broadleaf.Library.Windows.Forms.UiSetControl(this.components);
            this.ultraLabel15 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.CashRegisterNo_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.CashRegisterNoNm_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.LiPriSelPrtGdsNoDiv_Title_Lable = new Infragistics.Win.Misc.UltraLabel();
            this.LiPriSelPrtGdsNoDiv_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.CashRegisterNo_tEdit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.tEdit_SectionCodeAllowZero2 = new Broadleaf.Library.Windows.Forms.TEdit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionGuideNm_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bind_DataSet)).BeginInit();
            this.Button_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CashRegisterNoNm_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LiPriSelPrtGdsNoDiv_tComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CashRegisterNo_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SectionCodeAllowZero2)).BeginInit();
            this.SuspendLayout();
            // 
            // tRetKeyControl1
            // 
            this.tRetKeyControl1.OwnerForm = this;
            this.tRetKeyControl1.Style = Broadleaf.Library.Windows.Forms.emFocusStyle.ByTab;
            this.tRetKeyControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tArrowKeyControl1_ChangeFocus);
            // 
            // tArrowKeyControl1
            // 
            this.tArrowKeyControl1.OwnerForm = this;
            this.tArrowKeyControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tArrowKeyControl1_ChangeFocus);
            // 
            // ultraStatusBar1
            // 
            this.ultraStatusBar1.Location = new System.Drawing.Point(0, 236);
            this.ultraStatusBar1.Name = "ultraStatusBar1";
            this.ultraStatusBar1.Size = new System.Drawing.Size(837, 23);
            this.ultraStatusBar1.TabIndex = 46;
            this.ultraStatusBar1.ViewStyle = Infragistics.Win.UltraWinStatusBar.ViewStyle.Office2003;
            // 
            // Delete_Button
            // 
            this.Delete_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Delete_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Delete_Button.Location = new System.Drawing.Point(316, 10);
            this.Delete_Button.Margin = new System.Windows.Forms.Padding(1);
            this.Delete_Button.Name = "Delete_Button";
            this.Delete_Button.Size = new System.Drawing.Size(125, 34);
            this.Delete_Button.TabIndex = 6;
            this.Delete_Button.Text = "���S�폜(&D)";
            this.Delete_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Delete_Button.Click += new System.EventHandler(this.Delete_Button_Click);
            // 
            // Revive_Button
            // 
            this.Revive_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Revive_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Revive_Button.Location = new System.Drawing.Point(444, 10);
            this.Revive_Button.Margin = new System.Windows.Forms.Padding(1);
            this.Revive_Button.Name = "Revive_Button";
            this.Revive_Button.Size = new System.Drawing.Size(125, 34);
            this.Revive_Button.TabIndex = 8;
            this.Revive_Button.Text = "����(&R)";
            this.Revive_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Revive_Button.Click += new System.EventHandler(this.Revive_Button_Click);
            // 
            // Ok_Button
            // 
            this.Ok_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Ok_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Ok_Button.Location = new System.Drawing.Point(572, 10);
            this.Ok_Button.Margin = new System.Windows.Forms.Padding(1);
            this.Ok_Button.Name = "Ok_Button";
            this.Ok_Button.Size = new System.Drawing.Size(125, 34);
            this.Ok_Button.TabIndex = 9;
            this.Ok_Button.Text = "�ۑ�(&S)";
            this.Ok_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Ok_Button.Click += new System.EventHandler(this.Ok_Button_Click);
            // 
            // Cancel_Button
            // 
            this.Cancel_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Cancel_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Cancel_Button.Location = new System.Drawing.Point(700, 10);
            this.Cancel_Button.Margin = new System.Windows.Forms.Padding(1);
            this.Cancel_Button.Name = "Cancel_Button";
            this.Cancel_Button.Size = new System.Drawing.Size(125, 34);
            this.Cancel_Button.TabIndex = 10;
            this.Cancel_Button.Text = "����(&X)";
            this.Cancel_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Cancel_Button.Click += new System.EventHandler(this.Cancel_Button_Click);
            // 
            // SectionCode_Title_Label
            // 
            appearance3.TextHAlignAsString = "Left";
            appearance3.TextVAlignAsString = "Middle";
            this.SectionCode_Title_Label.Appearance = appearance3;
            this.SectionCode_Title_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.SectionCode_Title_Label.Location = new System.Drawing.Point(32, 47);
            this.SectionCode_Title_Label.Name = "SectionCode_Title_Label";
            this.SectionCode_Title_Label.Size = new System.Drawing.Size(130, 24);
            this.SectionCode_Title_Label.TabIndex = 4;
            this.SectionCode_Title_Label.Text = "���_";
            // 
            // Mode_Label
            // 
            appearance2.ForeColor = System.Drawing.Color.White;
            appearance2.TextHAlignAsString = "Center";
            appearance2.TextVAlignAsString = "Middle";
            this.Mode_Label.Appearance = appearance2;
            this.Mode_Label.BackColorInternal = System.Drawing.Color.Navy;
            this.Mode_Label.Location = new System.Drawing.Point(724, 9);
            this.Mode_Label.Name = "Mode_Label";
            this.Mode_Label.Size = new System.Drawing.Size(100, 23);
            this.Mode_Label.TabIndex = 23;
            this.Mode_Label.Text = "�X�V���[�h";
            // 
            // SectionGuideNm_tEdit
            // 
            appearance16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance16.ForeColor = System.Drawing.Color.Black;
            appearance16.TextVAlignAsString = "Middle";
            this.SectionGuideNm_tEdit.ActiveAppearance = appearance16;
            appearance17.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance17.ForeColor = System.Drawing.Color.Black;
            appearance17.ForeColorDisabled = System.Drawing.Color.Black;
            appearance17.TextVAlignAsString = "Middle";
            this.SectionGuideNm_tEdit.Appearance = appearance17;
            this.SectionGuideNm_tEdit.AutoSelect = true;
            this.SectionGuideNm_tEdit.DataText = "";
            this.SectionGuideNm_tEdit.Enabled = false;
            this.SectionGuideNm_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.SectionGuideNm_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 6, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.SectionGuideNm_tEdit.Location = new System.Drawing.Point(255, 47);
            this.SectionGuideNm_tEdit.MaxLength = 6;
            this.SectionGuideNm_tEdit.Name = "SectionGuideNm_tEdit";
            this.SectionGuideNm_tEdit.ReadOnly = true;
            this.SectionGuideNm_tEdit.Size = new System.Drawing.Size(144, 24);
            this.SectionGuideNm_tEdit.TabIndex = 99;
            // 
            // Initial_Timer
            // 
            this.Initial_Timer.Interval = 1;
            this.Initial_Timer.Tick += new System.EventHandler(this.Initial_Timer_Tick);
            // 
            // Bind_DataSet
            // 
            this.Bind_DataSet.DataSetName = "NewDataSet";
            this.Bind_DataSet.Locale = new System.Globalization.CultureInfo("ja-JP");
            // 
            // ultraToolTipManager1
            // 
            this.ultraToolTipManager1.ContainingControl = this;
            this.ultraToolTipManager1.DisplayStyle = Infragistics.Win.ToolTipDisplayStyle.Standard;
            // 
            // SectionGuide_ultraButton
            // 
            this.SectionGuide_ultraButton.BackColorInternal = System.Drawing.Color.Transparent;
            this.SectionGuide_ultraButton.Location = new System.Drawing.Point(409, 47);
            this.SectionGuide_ultraButton.Margin = new System.Windows.Forms.Padding(4);
            this.SectionGuide_ultraButton.Name = "SectionGuide_ultraButton";
            this.SectionGuide_ultraButton.Size = new System.Drawing.Size(24, 24);
            this.SectionGuide_ultraButton.TabIndex = 2;
            ultraToolTipInfo1.ToolTipText = "���_�K�C�h";
            this.ultraToolTipManager1.SetUltraToolTip(this.SectionGuide_ultraButton, ultraToolTipInfo1);
            this.SectionGuide_ultraButton.Click += new System.EventHandler(this.SectionGuide_ultraButton_Click);
            // 
            // Button_Panel
            // 
            this.Button_Panel.Controls.Add(this.Cancel_Button);
            this.Button_Panel.Controls.Add(this.Ok_Button);
            this.Button_Panel.Controls.Add(this.Delete_Button);
            this.Button_Panel.Controls.Add(this.Renewal_Button);
            this.Button_Panel.Controls.Add(this.Revive_Button);
            this.Button_Panel.Location = new System.Drawing.Point(1, 182);
            this.Button_Panel.Name = "Button_Panel";
            this.Button_Panel.Size = new System.Drawing.Size(835, 54);
            this.Button_Panel.TabIndex = 168;
            // 
            // Renewal_Button
            // 
            this.Renewal_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Renewal_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Renewal_Button.Location = new System.Drawing.Point(444, 10);
            this.Renewal_Button.Margin = new System.Windows.Forms.Padding(1);
            this.Renewal_Button.Name = "Renewal_Button";
            this.Renewal_Button.Size = new System.Drawing.Size(125, 34);
            this.Renewal_Button.TabIndex = 7;
            this.Renewal_Button.Text = "�ŐV���(&I)";
            this.Renewal_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Renewal_Button.Click += new System.EventHandler(this.Renewal_Button_Click);
            // 
            // uiSetControl1
            // 
            this.uiSetControl1.EditWidthSettingWay = Broadleaf.Library.Windows.Forms.UiSetControl.EditWidthSettingWayState.None;
            this.uiSetControl1.OwnerForm = this;
            // 
            // ultraLabel15
            // 
            this.ultraLabel15.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel15.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Inset;
            this.ultraLabel15.Location = new System.Drawing.Point(15, 81);
            this.ultraLabel15.Name = "ultraLabel15";
            this.ultraLabel15.Size = new System.Drawing.Size(808, 3);
            this.ultraLabel15.TabIndex = 169;
            // 
            // ultraLabel1
            // 
            appearance19.ForeColor = System.Drawing.Color.Black;
            appearance19.TextVAlignAsString = "Middle";
            this.ultraLabel1.Appearance = appearance19;
            this.ultraLabel1.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel1.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel1.Location = new System.Drawing.Point(439, 47);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(212, 26);
            this.ultraLabel1.TabIndex = 2381;
            this.ultraLabel1.Text = "���[���ŋ��ʐݒ�ɂȂ�܂�";
            // 
            // CashRegisterNo_Title_Label
            // 
            appearance18.TextHAlignAsString = "Left";
            appearance18.TextVAlignAsString = "Middle";
            this.CashRegisterNo_Title_Label.Appearance = appearance18;
            this.CashRegisterNo_Title_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.CashRegisterNo_Title_Label.Location = new System.Drawing.Point(32, 97);
            this.CashRegisterNo_Title_Label.Name = "CashRegisterNo_Title_Label";
            this.CashRegisterNo_Title_Label.Size = new System.Drawing.Size(171, 24);
            this.CashRegisterNo_Title_Label.TabIndex = 2382;
            this.CashRegisterNo_Title_Label.Text = "��M�����N���[���ԍ�";
            // 
            // CashRegisterNoNm_tEdit
            // 
            appearance9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance9.ForeColor = System.Drawing.Color.Black;
            appearance9.TextVAlignAsString = "Middle";
            this.CashRegisterNoNm_tEdit.ActiveAppearance = appearance9;
            appearance1.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance1.ForeColor = System.Drawing.Color.Black;
            appearance1.ForeColorDisabled = System.Drawing.Color.Black;
            appearance1.TextVAlignAsString = "Middle";
            this.CashRegisterNoNm_tEdit.Appearance = appearance1;
            this.CashRegisterNoNm_tEdit.AutoSelect = true;
            this.CashRegisterNoNm_tEdit.DataText = "";
            this.CashRegisterNoNm_tEdit.Enabled = false;
            this.CashRegisterNoNm_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.CashRegisterNoNm_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 6, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.CashRegisterNoNm_tEdit.Location = new System.Drawing.Point(255, 97);
            this.CashRegisterNoNm_tEdit.MaxLength = 6;
            this.CashRegisterNoNm_tEdit.Name = "CashRegisterNoNm_tEdit";
            this.CashRegisterNoNm_tEdit.ReadOnly = true;
            this.CashRegisterNoNm_tEdit.Size = new System.Drawing.Size(144, 24);
            this.CashRegisterNoNm_tEdit.TabIndex = 100;
            // 
            // LiPriSelPrtGdsNoDiv_Title_Lable
            // 
            appearance13.TextHAlignAsString = "Left";
            appearance13.TextVAlignAsString = "Middle";
            this.LiPriSelPrtGdsNoDiv_Title_Lable.Appearance = appearance13;
            this.LiPriSelPrtGdsNoDiv_Title_Lable.BackColorInternal = System.Drawing.Color.Transparent;
            this.LiPriSelPrtGdsNoDiv_Title_Lable.Location = new System.Drawing.Point(32, 133);
            this.LiPriSelPrtGdsNoDiv_Title_Lable.Name = "LiPriSelPrtGdsNoDiv_Title_Lable";
            this.LiPriSelPrtGdsNoDiv_Title_Lable.Size = new System.Drawing.Size(171, 24);
            this.LiPriSelPrtGdsNoDiv_Title_Lable.TabIndex = 2385;
            this.LiPriSelPrtGdsNoDiv_Title_Lable.Text = "����i�ԑI���敪";
            // 
            // LiPriSelPrtGdsNoDiv_tComboEditor
            // 
            appearance44.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.LiPriSelPrtGdsNoDiv_tComboEditor.ActiveAppearance = appearance44;
            appearance45.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance45.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance45.ForeColorDisabled = System.Drawing.Color.Black;
            this.LiPriSelPrtGdsNoDiv_tComboEditor.Appearance = appearance45;
            this.LiPriSelPrtGdsNoDiv_tComboEditor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.LiPriSelPrtGdsNoDiv_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.LiPriSelPrtGdsNoDiv_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance79.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.LiPriSelPrtGdsNoDiv_tComboEditor.ItemAppearance = appearance79;
            this.LiPriSelPrtGdsNoDiv_tComboEditor.Location = new System.Drawing.Point(208, 133);
            this.LiPriSelPrtGdsNoDiv_tComboEditor.Name = "LiPriSelPrtGdsNoDiv_tComboEditor";
            this.LiPriSelPrtGdsNoDiv_tComboEditor.Size = new System.Drawing.Size(616, 24);
            this.LiPriSelPrtGdsNoDiv_tComboEditor.TabIndex = 4;
            // 
            // CashRegisterNo_tEdit
            // 
            appearance6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance6.TextHAlignAsString = "Right";
            this.CashRegisterNo_tEdit.ActiveAppearance = appearance6;
            appearance7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance7.ForeColorDisabled = System.Drawing.Color.Black;
            appearance7.TextHAlignAsString = "Right";
            this.CashRegisterNo_tEdit.Appearance = appearance7;
            this.CashRegisterNo_tEdit.AutoSelect = true;
            this.CashRegisterNo_tEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.CashRegisterNo_tEdit.CalcSize = new System.Drawing.Size(172, 200);
            this.CashRegisterNo_tEdit.DataText = "";
            this.CashRegisterNo_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.CashRegisterNo_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 3, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.CashRegisterNo_tEdit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.CashRegisterNo_tEdit.Location = new System.Drawing.Point(208, 97);
            this.CashRegisterNo_tEdit.MaxLength = 3;
            this.CashRegisterNo_tEdit.Name = "CashRegisterNo_tEdit";
            this.CashRegisterNo_tEdit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsFILL);
            this.CashRegisterNo_tEdit.Size = new System.Drawing.Size(36, 24);
            this.CashRegisterNo_tEdit.TabIndex = 3;
            this.CashRegisterNo_tEdit.ValueChanged += new System.EventHandler(this.CashRegisterNo_tEdit_ValueChanged);
            // 
            // tEdit_SectionCodeAllowZero2
            // 
            appearance10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_SectionCodeAllowZero2.ActiveAppearance = appearance10;
            appearance11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance11.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance11.ForeColorDisabled = System.Drawing.Color.Black;
            this.tEdit_SectionCodeAllowZero2.Appearance = appearance11;
            this.tEdit_SectionCodeAllowZero2.AutoSelect = true;
            this.tEdit_SectionCodeAllowZero2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tEdit_SectionCodeAllowZero2.DataText = "";
            this.tEdit_SectionCodeAllowZero2.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_SectionCodeAllowZero2.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 2, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tEdit_SectionCodeAllowZero2.Location = new System.Drawing.Point(208, 46);
            this.tEdit_SectionCodeAllowZero2.MaxLength = 2;
            this.tEdit_SectionCodeAllowZero2.Name = "tEdit_SectionCodeAllowZero2";
            this.tEdit_SectionCodeAllowZero2.Size = new System.Drawing.Size(35, 24);
            this.tEdit_SectionCodeAllowZero2.TabIndex = 1;
            this.tEdit_SectionCodeAllowZero2.ValueChanged += new System.EventHandler(this.tEdit_SectionCodeAllowZero2_ValueChanged);
            // 
            // PMTAB09100UA
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 15);
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(837, 259);
            this.Controls.Add(this.tEdit_SectionCodeAllowZero2);
            this.Controls.Add(this.CashRegisterNo_tEdit);
            this.Controls.Add(this.LiPriSelPrtGdsNoDiv_tComboEditor);
            this.Controls.Add(this.LiPriSelPrtGdsNoDiv_Title_Lable);
            this.Controls.Add(this.CashRegisterNoNm_tEdit);
            this.Controls.Add(this.CashRegisterNo_Title_Label);
            this.Controls.Add(this.ultraLabel1);
            this.Controls.Add(this.ultraLabel15);
            this.Controls.Add(this.SectionGuide_ultraButton);
            this.Controls.Add(this.Button_Panel);
            this.Controls.Add(this.ultraStatusBar1);
            this.Controls.Add(this.Mode_Label);
            this.Controls.Add(this.SectionCode_Title_Label);
            this.Controls.Add(this.SectionGuideNm_tEdit);
            this.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PMTAB09100UA";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "�^�u���b�g�S�̐ݒ�}�X�^�i���_�ʁj";
            this.Load += new System.EventHandler(this.PMTAB09100UA_Load);
            this.VisibleChanged += new System.EventHandler(this.PMTAB09100UA_VisibleChanged);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.PMTAB09100UA_Closing);
            ((System.ComponentModel.ISupportInitialize)(this.SectionGuideNm_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bind_DataSet)).EndInit();
            this.Button_Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CashRegisterNoNm_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LiPriSelPrtGdsNoDiv_tComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CashRegisterNo_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SectionCodeAllowZero2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        #region IMasterMaintenanceMultiType �����o

        # region ��Properties
        /// <summary>�_���폜�f�[�^���o�\�ݒ�v���p�e�B</summary>
        /// <value>�_���폜�f�[�^�̒��o���\���ǂ����̐ݒ���擾���܂��B</value>
        public bool CanLogicalDeleteDataExtraction
        {
            get
            {
                return this._canLogicalDeleteDataExtraction;
            }
        }

        /// <summary>�����w�蒊�o�\�ݒ�v���p�e�B</summary>
        /// <value>�����w�蒊�o���\�Ƃ��邩�ǂ����̐ݒ���擾�܂��͐ݒ肵�܂��B</value>
        public bool CanSpecificationSearch
        {
            get
            {
                return this._canSpecificationSearch;
            }
        }

        /// <summary>�f�[�^�Z�b�g�̑I���f�[�^�C���f�b�N�X�v���p�e�B</summary>
        /// <value>�f�[�^�Z�b�g�̑I���f�[�^�C���f�b�N�X���擾�܂��͐ݒ肵�܂��B</value>
        public int DataIndex
        {
            get
            {
                return this._dataIndex;
            }
            set
            {
                this._dataIndex = value;
            }
        }

        /// <summary>��̃T�C�Y�̎��������̃f�t�H���g�l�v���p�e�B</summary>
        /// <value>��̃T�C�Y�̎��������`�F�b�N�{�b�N�X�̃`�F�b�N�L���̃f�t�H���g�l���擾���܂��B</value>
        public bool DefaultAutoFillToColumn
        {
            get
            {
                return this._defaultAutoFillToColumn;
            }
        }
        # endregion ��Properties

        # region ��Public Methods

        /// <summary>GetAppearanceTable</summary>
        /// <value>AppearanceTable���擾���܂��B</value>
        public Hashtable GetAppearanceTable()
        {
            Hashtable appearanceTable = new Hashtable();

            appearanceTable.Add(DELETE_DATE_TITLE, new GridColAppearance(MGridColDispType.DeletionDataBoth, ContentAlignment.MiddleLeft, "", Color.Red));
            appearanceTable.Add(SECTIONCODE_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            appearanceTable.Add(SECTIONGUIDENM_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            appearanceTable.Add(CASHREGISTERNO_TITLE , new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "00#", Color.Black));
            appearanceTable.Add(CASHREGISTERNONM_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            appearanceTable.Add(LIPRISELPRTGDSNODIVNM_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            appearanceTable.Add(DETAILS_GUID_KEY, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));

            return appearanceTable;
        }

        /// <summary>GetBindDataSet</summary>
        /// <value>BindDataSet���擾���܂��B</value>
        public void GetBindDataSet(ref DataSet bindDataSet, ref string tableName)
        {
            bindDataSet = this.Bind_DataSet;
            tableName = DETAILS_TABLE;
        }
        # endregion ��Public Methods

        # region ��Events
        /// <summary>��ʔ�\���C�x���g</summary>
        /// <remarks>��ʂ���\����ԂɂȂ����ۂɔ������܂��B</remarks>
        public event MasterMaintenanceMultiTypeUnDisplayingEventHandler UnDisplaying;
        # endregion

        #endregion

        #region Private Menbers

        private PmTabTtlStSecAcs _pmTabTtlStSecAcs;     // �^�u���b�g�S�̐ݒ�}�X�^(���_��)�p�A�N�Z�X�N���X

        private string _enterpriseCode;         // ��ƃR�[�h
        private Hashtable _detailsTable;        // �^�u���b�g�S�̐ݒ�}�X�^(���_��)�p�n�b�V���e�[�u��
        private Hashtable _allSearchHash;       // �S���R�[�h�m�ۗp

        // �v���p�e�B�p
        private bool _canPrint;
        private bool _canClose;
        private bool _canNew;
        private bool _canDelete;

        private int _dataIndex;
        private bool _canLogicalDeleteDataExtraction;
        private bool _canSpecificationSearch;
        private bool _defaultAutoFillToColumn;

        private bool _modeFlg = false;

        private int _detailsIndexBuf;

        // �[���Ǘ����L���b�V��
        private Dictionary<int, PosTerminalMg> _posTerminalMgDic;

        private PosTerminalMgAcs _posTerminalMgAcs = null;  // �[���Ǘ��ݒ�A�N�Z�X�N���X

        // �O��[���ԍ�
        private int _preCashRegisterNo;

        // �ҏW���[�h
        private const string INSERT_MODE = "�V�K���[�h";
        private const string UPDATE_MODE = "�X�V���[�h";
        private const string DELETE_MODE = "�폜���[�h";

        // �S�Ћ���
        private const string ALL_SECTIONCODE = "00";

        // �I�����̕ҏW�`�F�b�N�p
        private PmTabTtlStSec _PmTabTtlStSecClone;

        // Frem��View�pGrid���KEY��� (�w�b�_�̃^�C�g�����ƂȂ�܂�)
        private const string DELETE_DATE_TITLE      = "�폜��";
        private const string SECTIONCODE_TITLE      = "���_�R�[�h";
        private const string SECTIONGUIDENM_TITLE   = "���_��";
        private const string CASHREGISTERNO_TITLE = "��M�����N���[���ԍ�";
        private const string CASHREGISTERNONM_TITLE = "��M�����N���[����";
        private const string LIPRISELPRTGDSNODIVNM_TITLE = "����i�ԑI���敪";

        //����i�ԑI���敪
        private const string LIPRISELPRTGDSNODIVNM_VALUE0 = "�D�Ǖi�Ԃ���";
        private const string LIPRISELPRTGDSNODIVNM_VALUE1 = "�i�Ԉ󎚂Ȃ�";
        // ----- ADD huangt 2013/07/11 Redmine#38166 ����p�i�Ԃ̐���Ɋւ��� ----- >>>>>
        private const string LIPRISELPRTGDSNODIVNM_VALUE2 = "����S�̐ݒ�̎��Еi�Ԉ󎚋敪�ɏ]��(�󎚋敪�F���Ȃ��@�̏ꍇ�͗D�Ǖi�Ԉ�)";
        private const string LIPRISELPRTGDSNODIVNM_VALUE3 = "����S�̐ݒ�̎��Еi�Ԉ󎚋敪�ɏ]��(�󎚋敪�F���Ȃ��@�̏ꍇ�͕i�Ԉ󎚂Ȃ�)";
        // ----- ADD huangt 2013/07/11 Redmine#38166 ����p�i�Ԃ̐���Ɋւ��� ----- <<<<<

        // �e�[�u������
        private const string DETAILS_TABLE = "PmTabTtlStSec";  // PMTAB�S�̐ݒ�}�X�^�i���_�ʁj

        // �K�C�h�L�[
        private const string DETAILS_GUID_KEY = "DetailsGuid";

        // ��ʃ��C�A�E�g�p�萔
        // ----- DEL huangt 2013/07/11 Redmine#38166 ����p�i�Ԃ̐���Ɋւ��� ----- >>>>>
        //private const int BUTTON_LOCATION1_X = 146;     // ���S�폜�{�^���ʒuX
        //private const int BUTTON_LOCATION2_X = 273;     // �����{�^���ʒuX
        //private const int BUTTON_LOCATION3_X = 400;     // �ۑ��{�^���ʒuX
        //private const int BUTTON_LOCATION4_X = 527;     // ����{�^���ʒuX
        // ----- DEL huangt 2013/07/11 Redmine#38166 ����p�i�Ԃ̐���Ɋւ��� ----- <<<<<
        // ----- ADD huangt 2013/07/11 Redmine#38166 ����p�i�Ԃ̐���Ɋւ��� ----- >>>>>
        private const int BUTTON_LOCATION1_X = 319;     // ���S�폜�{�^���ʒuX
        private const int BUTTON_LOCATION2_X = 446;     // �����{�^���ʒuX
        private const int BUTTON_LOCATION3_X = 573;     // �ۑ��{�^���ʒuX
        private const int BUTTON_LOCATION4_X = 700;     // ����{�^���ʒuX
        private const int BUTTON_LOCATION_Y = 8;        // �{�^���ʒuY(����)
        // ----- ADD huangt 2013/07/11 Redmine#38166 ����p�i�Ԃ̐���Ɋւ��� ----- <<<<<

        // Message�֘A��`
        private const string ASSEMBLY_ID = "PMTAB09100U";
        private const string ERR_READ_MSG = "�ǂݍ��݂Ɏ��s���܂����B";
        private const string ERR_DPR_MSG = "���̃R�[�h�͊��Ɏg�p����Ă��܂��B";
        private const string ERR_RDEL_MSG = "�폜�Ɏ��s���܂����B";
        private const string ERR_UPDT_MSG = "�o�^�Ɏ��s���܂����B";
        private const string ERR_RVV_MSG = "�����Ɏ��s���܂����B";
        private const string ERR_800_MSG = "���ɑ��[�����X�V����Ă��܂�";
        private const string ERR_801_MSG = "���ɑ��[�����폜����Ă��܂�";
        private const string SDC_RDEL_MSG = "�}�X�^����폜����Ă��܂�";

        #endregion

        # region Main
        /// <summary>
        /// �A�v���P�[�V�����̃��C�� �G���g�� �|�C���g�ł��B
        /// </summary>
        [STAThread]
        static void Main()
        {
            System.Windows.Forms.Application.Run(new PMTAB09100UA());
        }
        # endregion

        # region Properties

        /// <summary>����\�ݒ�v���p�e�B</summary>
        /// <value>����\���ǂ����̐ݒ���擾���܂��B</value>
        public bool CanPrint
        {
            get { return this._canPrint; }
        }

        /// <summary>��ʏI���ݒ�v���p�e�B</summary>
        /// <value>��ʃN���[�Y�������邩�ǂ����̐ݒ���擾�܂��͐ݒ肵�܂��B</value>
        /// <remarks>false�̏ꍇ�́A��ʂ����ہAClose�ł͂Ȃ�Hide(��\��)�����s���܂��B</remarks>
        public bool CanClose
        {
            get { return this._canClose; }
            set { this._canClose = value; }
        }

        /// <summary>�V�K�o�^�\�ݒ�v���p�e�B</summary>
        /// <value>�V�K�o�^���\���ǂ����̐ݒ���擾���܂��B</value>
        public bool CanNew
        {
            get { return this._canNew; }
        }

        /// <summary>�폜�\�ݒ�v���p�e�B</summary>
        /// <value>�폜���\���ǂ����̐ݒ���擾���܂��B</value>
        public bool CanDelete
        {
            get { return this._canDelete; }
        }

        # endregion

        # region Public Methods

        /// <summary>
        /// ���_��������
        /// </summary>
        /// <param name="totalCount">�S�Y������</param>
        /// <param name="readCount">���o�Ώی���</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �S�f�[�^���������A���o���ʂ�W�J����DataSet�ƑS�Y��������Ԃ��܂��B</br>
        /// <br>Programmer : ���|��</br>
        /// <br>Date       : 2013/05/31</br>
        /// </remarks>
        public int Search(ref int totalCount, int readCount)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            totalCount = 0;

            try
            {
                // �N���A
                this.Bind_DataSet.Tables[DETAILS_TABLE].Rows.Clear();  
                this._detailsTable.Clear();  

                ArrayList retList = new ArrayList();
                status = this._pmTabTtlStSecAcs.SearchAll(out retList, this._enterpriseCode);
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        int index = 0;
                        foreach (PmTabTtlStSec pmTabTtlStSec in retList)
                        {
                            if (this._detailsTable.ContainsKey(pmTabTtlStSec.FileHeaderGuid) == false)
                            {
                                DetailsToDataSet(pmTabTtlStSec.Clone(), index);
                                ++index;
                            }
                        }
                        totalCount = retList.Count;
                        break;
                    case ( int )ConstantManagement.DB_Status.ctDB_EOF:
					    break;
				    default:
					TMsgDisp.Show( 
						this, 								// �e�E�B���h�E�t�H�[��
						emErrorLevel.ERR_LEVEL_STOP, 		// �G���[���x��
						"PMTAB09100U", 						// �A�Z���u���h�c�܂��̓N���X�h�c
						"�^�u���b�g�S�̐ݒ�}�X�^(���_��)", 					    // �v���O��������
                        "Search", 					        // ��������
						TMsgDisp.OPE_GET, 					// �I�y���[�V����
						"�ǂݍ��݂Ɏ��s���܂����B", 		// �\�����郁�b�Z�[�W
						status, 							// �X�e�[�^�X�l
						this._pmTabTtlStSecAcs, 				// �G���[�����������I�u�W�F�N�g
						MessageBoxButtons.OK, 				// �\������{�^��
						MessageBoxDefaultButton.Button1 );	// �����\���{�^��

					break;
                }
            }
            catch (Exception)
            {
                // �T�[�`
                TMsgDisp.Show(
                    this,								  // �e�E�B���h�E�t�H�[��
                    emErrorLevel.ERR_LEVEL_STOPDISP,	  // �G���[���x��
                    ASSEMBLY_ID,						  // �A�Z���u���h�c�܂��̓N���X�h�c
                    this.Text,							  // �v���O��������
                    "Search",							  // ��������
                    TMsgDisp.OPE_GET,					  // �I�y���[�V����
                    ERR_READ_MSG,						  // �\�����郁�b�Z�[�W 
                    status,								  // �X�e�[�^�X�l
                    this._pmTabTtlStSecAcs,				      // �G���[�����������I�u�W�F�N�g
                    MessageBoxButtons.OK,				  // �\������{�^��
                    MessageBoxDefaultButton.Button1);	  // �����\���{�^��

                status = -1;
                return status;
            }

            return status;
        }

        /// <summary>
        /// �l�N�X�g�f�[�^��������
        /// </summary>
        /// <param name="readCount">���o�Ώی���</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �w�肵���������̃l�N�X�g�f�[�^���������܂��B</br>
        /// <br>Programmer : ���|��</br>
        /// <br>Date       : 2013/05/31</br>
        /// </remarks>
        public int SearchNext(int readCount)
        {
            // �����Ȃ�
            return 9;
        }

        /// <summary>
        /// �f�[�^�폜����
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �I�𒆂̃f�[�^���폜���܂��B</br>
        /// <br>Programmer : ���|��</br>
        /// <br>Date       : 2013/05/31</br>
        /// </remarks>
        public int Delete()
        {
            int status = 0;

            status = LogicalDeleteSubsection();  

            return status;
        }

        /// <summary>
        /// �������
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ������������s���܂��B</br>
        /// <br>Programmer : ���|��</br>
        /// <br>Date       : 2013/05/31</br>
        /// </remarks>
        public int Print()
        {
            // ����@�\�����̈ז�����
            return 0;
        }

        # endregion

        # region Private Methods

        /// <summary>
        /// �^�u���b�g�S�̐ݒ�}�X�^(���_��)�I�u�W�F�N�g�f�[�^�Z�b�g�W�J����
        /// </summary>
        /// <param name="pmTabTtlStSec">�^�u���b�g�S�̐ݒ�}�X�^(���_��)�I�u�W�F�N�g</param>
        /// <param name="index">�f�[�^�Z�b�g�֓W�J����C���f�b�N�X</param>
        /// <remarks>
        /// <br>Note       : �^�u���b�g�S�̐ݒ�}�X�^(���_��)�N���X���f�[�^�Z�b�g�Ɋi�[���܂��B</br>
        /// <br>Programmer : ���|��</br>
        /// <br>Date       : 2013/05/31</br>
        /// </remarks>
        private void DetailsToDataSet(PmTabTtlStSec pmTabTtlStSec, int index)
        {
            if ((index < 0) || (this.Bind_DataSet.Tables[DETAILS_TABLE].Rows.Count <= index))
            {
                // �V�K�Ɣ��f���āA�s��ǉ�����
                DataRow dataRow = this.Bind_DataSet.Tables[DETAILS_TABLE].NewRow();
                this.Bind_DataSet.Tables[DETAILS_TABLE].Rows.Add(dataRow);

                // index���s�̍ŏI�s�ԍ�����
                index = this.Bind_DataSet.Tables[DETAILS_TABLE].Rows.Count - 1;
            }

            // �_���폜�敪
            if (pmTabTtlStSec.LogicalDeleteCode == 0)
            {
                this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][DELETE_DATE_TITLE] = "";
            }
            else
            {
                this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][DELETE_DATE_TITLE] = pmTabTtlStSec.UpdateDateTimeJpInFormal;
            }

            // ���_�R�[�h

            this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][SECTIONCODE_TITLE] = pmTabTtlStSec.SectionCode;

            // ���_����
            string sectionNm = GetSectionName(pmTabTtlStSec.SectionCode);
            if (sectionNm == "")
            {
                sectionNm = "���o�^";
            }
            this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][SECTIONGUIDENM_TITLE] = sectionNm;

            string CashRegisterNoTemp = string.Format("{0:D3}", pmTabTtlStSec.CashRegisterNo);

            // ��M�����N���[���ԍ��R�[�h
            this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][CASHREGISTERNO_TITLE] = CashRegisterNoTemp;

            // ��M�����N���[���ԍ�����
            PosTerminalMg posTerminalMg = GetPosTerminalMg(pmTabTtlStSec.CashRegisterNo);
            if (posTerminalMg == null || posTerminalMg.LogicalDeleteCode != 0)
            {
                // �[����
                this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][CASHREGISTERNONM_TITLE] = "";
            }
            else
            {
                // �[����
                this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][CASHREGISTERNONM_TITLE] = posTerminalMg.MachineName;
            }

            // ����i�ԑI���敪
            this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][LIPRISELPRTGDSNODIVNM_TITLE] = this.GetLiPriSelPrtGdsNoDivNm(pmTabTtlStSec.LiPriSelPrtGdsNoDiv);

            // GUID
            this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][DETAILS_GUID_KEY] = pmTabTtlStSec.FileHeaderGuid;

            // �n�b�V���e�[�u���X�V
            if (this._detailsTable.ContainsKey(pmTabTtlStSec.FileHeaderGuid) == true)
            {
                this._detailsTable.Remove(pmTabTtlStSec.FileHeaderGuid);
            }
            this._detailsTable.Add(pmTabTtlStSec.FileHeaderGuid, pmTabTtlStSec);
        }

        /// <summary>
        /// ���_���̎擾����
        /// </summary>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <returns>���_����</returns>
        /// <remarks>
        /// <br>Note       : ���_���̂��擾���܂��B</br>
        /// <br>Programmer : ���|��</br>
        /// <br>Date       : 2013/05/31</br>
        /// </remarks>
        private string GetSectionName(string sectionCode)
        {
            return this._pmTabTtlStSecAcs.GetSectionName(sectionCode);
        }

        /// <summary>
        /// �^�u���b�g�S�̐ݒ�}�X�^(���_��)�I�u�W�F�N�g�f�[�^�Z�b�g�폜����
        /// </summary>
        /// <param name="pmTabTtlStSec">�^�u���b�g�S�̐ݒ�}�X�^(���_��)�I�u�W�F�N�g</param>
        /// <param name="index">�f�[�^�Z�b�g�֓W�J����C���f�b�N�X</param>
        private void DeleteFromDataSet(PmTabTtlStSec pmTabTtlStSec, int index)
        {
            // �f�[�^�Z�b�g����s�폜���܂�
            this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index].Delete();

            // �n�b�V���e�[�u������폜���܂�
            if (this._detailsTable.ContainsKey(pmTabTtlStSec.FileHeaderGuid) == true)
            {
                this._detailsTable.Remove(pmTabTtlStSec.FileHeaderGuid);
            }
        }

        /// <summary>
        /// �f�[�^�Z�b�g����\�z����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �f�[�^�Z�b�g�̗�����\�z���܂��B
        ///					 �f�[�^�Z�b�g�̗��񂪃t���[���̃r���[�p�O���b�h�̗�ɂȂ�܂�</br>
        /// <br>Programmer : ���|��</br>
        /// <br>Date       : 2013/05/31</br>
        /// </remarks>
        private void DataSetColumnConstruction()
        {
            DataTable detailsTable  = new DataTable(DETAILS_TABLE); // PMTAB�S�̐ݒ�}�X�^(���_��)

            detailsTable.Columns.Add(DELETE_DATE_TITLE, typeof(string));
            detailsTable.Columns.Add(SECTIONCODE_TITLE, typeof(string));
            detailsTable.Columns.Add(SECTIONGUIDENM_TITLE, typeof(string));
            detailsTable.Columns.Add(CASHREGISTERNO_TITLE, typeof(string));
            detailsTable.Columns.Add(CASHREGISTERNONM_TITLE, typeof(string));
            detailsTable.Columns.Add(LIPRISELPRTGDSNODIVNM_TITLE, typeof(string));
            detailsTable.Columns.Add(DETAILS_GUID_KEY, typeof(Guid));
            this.Bind_DataSet.Tables.Add(detailsTable);
        }

        /// <summary>
        /// ��ʃN���A����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ��ʂ��N���A���܂��B</br>
        /// <br>Programmer : ���|��</br>
        /// <br>Date       : 2013/05/31</br>
        /// </remarks>
        private void ScreenClear()
        {
            // ���[�h���x��
            this.Mode_Label.Text = INSERT_MODE;

            // �{�^��
            this.Delete_Button.Visible  = true;  // ���S�폜�{�^��
            this.Revive_Button.Visible  = true;  // �����{�^��
            this.Ok_Button.Visible      = true;  // �ۑ��{�^��
            this.Cancel_Button.Visible = true;  // ����{�^��
            this.Renewal_Button.Visible = true;  // �ŐV���{�^��
            this.Delete_Button.Location = new Point(BUTTON_LOCATION1_X, BUTTON_LOCATION_Y); // ���S�폜�{�^���ʒu
            this.Revive_Button.Location = new Point(BUTTON_LOCATION2_X, BUTTON_LOCATION_Y); // �����{�^���ʒu
            this.Ok_Button.Location     = new Point(BUTTON_LOCATION3_X, BUTTON_LOCATION_Y); // �ۑ��{�^���ʒu
            this.Cancel_Button.Location = new Point(BUTTON_LOCATION4_X, BUTTON_LOCATION_Y); // ����{�^���ʒu
            this.Renewal_Button.Location = new Point(BUTTON_LOCATION2_X, BUTTON_LOCATION_Y); // �����{�^���ʒu

            // ���_��
            this.tEdit_SectionCodeAllowZero2.Clear();
            this.SectionGuideNm_tEdit.Text = "";
            this.tEdit_SectionCodeAllowZero2.Enabled = true;
            this.SectionGuideNm_tEdit.Enabled = false;
            this.SectionGuide_ultraButton.Enabled = true;

            //��M�����N���[���ԍ�
            this.CashRegisterNo_tEdit.Clear();
            this.CashRegisterNo_tEdit.Enabled = true;
            this.CashRegisterNoNm_tEdit.Enabled = false;
            this.CashRegisterNoNm_tEdit.Text = "";

            //����i�ԑI���敪
            this.LiPriSelPrtGdsNoDiv_tComboEditor.Items.Clear();
            this.LiPriSelPrtGdsNoDiv_tComboEditor.Items.Add(0,LIPRISELPRTGDSNODIVNM_VALUE0);
            this.LiPriSelPrtGdsNoDiv_tComboEditor.Items.Add(1,LIPRISELPRTGDSNODIVNM_VALUE1);
            // ----- ADD huangt 2013/07/11 Redmine#38166 ����p�i�Ԃ̐���Ɋւ��� ----- >>>>>
            this.LiPriSelPrtGdsNoDiv_tComboEditor.Items.Add(2, LIPRISELPRTGDSNODIVNM_VALUE2);
            this.LiPriSelPrtGdsNoDiv_tComboEditor.Items.Add(3, LIPRISELPRTGDSNODIVNM_VALUE3);
            // ----- ADD huangt 2013/07/11 Redmine#38166 ����p�i�Ԃ̐���Ɋւ��� ----- <<<<<
            this.LiPriSelPrtGdsNoDiv_tComboEditor.Enabled = true;
        }

        /// <summary>
        /// ��ʏ����ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note       : ��ʂ̏����ݒ���s���܂��B</br>
        /// <br>Programmer : ���|��</br>
        /// <br>Date       : 2013/05/31</br>
        /// </remarks>
        private void ScreenInitialSetting()
        {
            // �V�K�̏ꍇ
            if (this._dataIndex < 0)
            {
                ScreenInputPermissionControl(1);                        // ��ʓ��͋�����
            }
            // �폜�̏ꍇ
            else if ((string)this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[this._dataIndex][DELETE_DATE_TITLE] != "")
            {
                ScreenInputPermissionControl(2);                        // ��ʓ��͋�����
            }
            // �X�V�̏ꍇ
            else
            {
                ScreenInputPermissionControl(3);                        // ��ʓ��͋�����
            }
        }

        /// <summary>
        /// ��ʓ��͋����䏈��
        /// </summary>
        /// <param name="setType">�ݒ�^�C�v 0:�e-�V�K, 1:�e-�X�V, 2:�e-�폜, 3:�q-�V�K, 4:�q-�X�V, 5:�q-�폜</param>
        /// <remarks>
        /// <br>Note       : ��ʂ̓��͋��𐧌䂵�܂��B</br>
        /// <br>Programmer : ���|��</br>
        /// <br>Date       : 2013/05/31</br>
        /// </remarks>
        private void ScreenInputPermissionControl(int setType)
        {
            switch (setType) {
                // 1:�V�K
                case 1:
                    this.tEdit_SectionCodeAllowZero2.Enabled = true;
                    this.SectionGuide_ultraButton.Enabled = true;
                    this.SectionGuideNm_tEdit.Enabled = false;
                    this.CashRegisterNo_tEdit.Enabled = true;
                    this.CashRegisterNoNm_tEdit.Enabled = false;
                    this.LiPriSelPrtGdsNoDiv_tComboEditor.Enabled = true;

                    // �{�^��
                    this.Delete_Button.Visible = false;
                    this.Revive_Button.Visible = false;
                    this.Ok_Button.Visible = true;
                    this.Cancel_Button.Visible = true;
                    this.Renewal_Button.Visible = true;

                    break;
                // 2:�X�V
                case 3:
                    // �\������
                    this.tEdit_SectionCodeAllowZero2.Enabled = false;
                    this.SectionGuideNm_tEdit.Enabled = false;
                    this.SectionGuide_ultraButton.Enabled = false;
                    this.CashRegisterNo_tEdit.Enabled = true;
                    this.CashRegisterNoNm_tEdit.Enabled = false;
                    this.LiPriSelPrtGdsNoDiv_tComboEditor.Enabled = true;

                    // �{�^��
                    this.Ok_Button.Visible = true;
                    this.Cancel_Button.Visible = true;
                    this.Revive_Button.Visible = false;
                    this.Delete_Button.Visible = false;
                    this.Renewal_Button.Visible = true;

                    break;
                // 3:�폜
                case 2:
                    // �\������
                    this.tEdit_SectionCodeAllowZero2.Enabled = false;
                    this.SectionGuideNm_tEdit.Enabled = false;
                    this.SectionGuide_ultraButton.Enabled = false;
                    this.CashRegisterNo_tEdit.Enabled = false;
                    this.CashRegisterNoNm_tEdit.Enabled = false;
                    this.LiPriSelPrtGdsNoDiv_tComboEditor.Enabled = false;

                    // �{�^��
                    this.Delete_Button.Visible = true;
                    this.Revive_Button.Visible = true;
                    this.Ok_Button.Visible = false;
                    this.Renewal_Button.Visible = false;
                    this.Cancel_Button.Visible = true;
                    this.Delete_Button.Location = new Point(BUTTON_LOCATION2_X, BUTTON_LOCATION_Y); // ���S�폜�{�^���ʒu
                    this.Revive_Button.Location = new Point(BUTTON_LOCATION3_X, BUTTON_LOCATION_Y); // �����{�^���ʒu
                    this.Cancel_Button.Location = new Point(BUTTON_LOCATION4_X, BUTTON_LOCATION_Y); // ����{�^���ʒu
                    break;
            }
        }

        /// <summary>
        /// ��ʍč\�z����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���[�h�Ɋ�Â��ĉ�ʂ��č\�z���܂��B</br>
        /// <br>Programmer : ���|��</br>
        /// <br>Date       : 2013/05/31</br>
        /// </remarks>
        private void ScreenReconstruction()
        {
            PmTabTtlStSec pmTabTtlStSec = new PmTabTtlStSec();

            // �V�K�̏ꍇ
            if (this._dataIndex < 0)
            {
                // ��ʓW�J����
                SubsectionToScreen(pmTabTtlStSec);

                // �N���[���쐬
                this._PmTabTtlStSecClone = pmTabTtlStSec.Clone();
                DispToSubsection(ref this._PmTabTtlStSecClone);

            }
            // �폜�̏ꍇ
            else if ((string)this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[this._dataIndex][DELETE_DATE_TITLE] != "")
            {
                // �폜���[�h
                this.Mode_Label.Text = DELETE_MODE;

                // �\�����擾
                Guid guid = (Guid)this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[this._dataIndex][DETAILS_GUID_KEY];
                pmTabTtlStSec = (PmTabTtlStSec)this._detailsTable[guid];

                // ��ʓW�J����
                SubsectionToScreen(pmTabTtlStSec);
            }
            // �X�V�̏ꍇ
            else
            {
                // �X�V���[�h
                this.Mode_Label.Text = UPDATE_MODE;

                // �\�����擾
                Guid guid = (Guid)this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[this._dataIndex][DETAILS_GUID_KEY];
                pmTabTtlStSec = (PmTabTtlStSec)this._detailsTable[guid];

                // ��ʓW�J����
                SubsectionToScreen(pmTabTtlStSec);

                // �N���[���쐬
                this._PmTabTtlStSecClone = pmTabTtlStSec.Clone();
                DispToSubsection(ref this._PmTabTtlStSecClone);

            }

            this._detailsIndexBuf = this._dataIndex; 
        }

        /// <summary>
        /// PMT�S�̐ݒ�N���X��ʓW�J����
        /// </summary>
        /// <param name="pmTabTtlStSec">PMT�S�̐ݒ�I�u�W�F�N�g</param>
        /// <remarks>
        /// <br>Note       : �I�u�W�F�N�g�����ʂɃf�[�^��W�J���܂��B</br>
        /// <br>Programmer : ���|��</br>
        /// <br>Date       : 2013/05/31</br>
        /// </remarks>
        private void SubsectionToScreen(PmTabTtlStSec pmTabTtlStSec)
        {
            // ���_�R�[�h
            this.tEdit_SectionCodeAllowZero2.DataText = pmTabTtlStSec.SectionCode.Trim();

            if (this.tEdit_SectionCodeAllowZero2.DataText == string.Empty)
            {
                this.SectionGuideNm_tEdit.DataText = "";
                this.tEdit_SectionCodeAllowZero2.Clear();
            }
            else
            {
                // ���_����
                string sectionNm =  GetSectionName(pmTabTtlStSec.SectionCode);
                if (sectionNm == "")
                {
                    this.SectionGuideNm_tEdit.DataText = "���o�^";
                }
                else
                {
                    this.SectionGuideNm_tEdit.DataText = GetSectionName(pmTabTtlStSec.SectionCode);
                }
            }

            int cashRegisterNo = pmTabTtlStSec.CashRegisterNo;

            // �[���ԍ�
            this.CashRegisterNo_tEdit.SetInt(cashRegisterNo);

            PosTerminalMg posTerminalMg = GetPosTerminalMg(cashRegisterNo);
            if (posTerminalMg == null || posTerminalMg.LogicalDeleteCode != 0)
            {
                // �[����
                this.CashRegisterNoNm_tEdit.Text = "";
            }
            else
            {
                // �[����
                this.CashRegisterNoNm_tEdit.Text = posTerminalMg.MachineName;
            }

            // ����i�ԑI���敪
            this.LiPriSelPrtGdsNoDiv_tComboEditor.SelectedIndex = pmTabTtlStSec.LiPriSelPrtGdsNoDiv;
        }

        /// <summary>
        /// ��ʏ��S�̐ݒ�N���X�i�[����
        /// </summary>
        /// <param name="pmTabTtlStSec">PMTAB�S�̐ݒ�}�X�^(���_��)�I�u�W�F�N�g</param>
        /// <remarks>
        /// <br>Note       : ��ʏ�񂩂�S�̐ݒ�I�u�W�F�N�g�Ƀf�[�^���i�[���܂��B</br>
        /// <br>Programmer : ���|��</br>
        /// <br>Date       : 2013/05/31</br>
        /// </remarks>
        private void DispToSubsection(ref PmTabTtlStSec pmTabTtlStSec)
        {
            // ��ƃR�[�h
            pmTabTtlStSec.EnterpriseCode = this._enterpriseCode;

            // �V�K�̏ꍇ�A���_�R�[�h���X�V�\
            if(this._dataIndex < 0)
            {
                //���_�R�[�h
                if (this._dataIndex < 0 && (this.tEdit_SectionCodeAllowZero2.DataText == ALL_SECTIONCODE))
                {
                    pmTabTtlStSec.SectionCode = "";
                }
                else
                {
                    pmTabTtlStSec.SectionCode = this.tEdit_SectionCodeAllowZero2.DataText;
                }
            }

            // ��M�����N���[���ԍ�
            pmTabTtlStSec.CashRegisterNo = this.CashRegisterNo_tEdit.GetInt();

            // ��M�����N���[������
            PosTerminalMg posTerminalMg = GetPosTerminalMg(pmTabTtlStSec.CashRegisterNo);
            if (posTerminalMg == null || posTerminalMg.LogicalDeleteCode != 0)
            {
                // �[����
                pmTabTtlStSec.CashRegisterNoNM = "";
            }
            else
            {
                // �[����
                pmTabTtlStSec.CashRegisterNoNM = posTerminalMg.MachineName;
            }

            // ����i�ԑI���敪
            pmTabTtlStSec.LiPriSelPrtGdsNoDiv = this.LiPriSelPrtGdsNoDiv_tComboEditor.SelectedIndex;
        }

        /// <summary>
        /// ��ʓ��͏��s���`�F�b�N����
        /// </summary>
        /// <param name="control">�s���ΏۃR���g���[��</param>
        /// <param name="message">���b�Z�[�W</param>
        /// <returns>�`�F�b�N���ʁitrue:OK�^false:NG�j</returns>
        /// <remarks>
        /// <br>Note		: ��ʓ��͏��̕s���`�F�b�N���s���܂��B</br>
        /// <br>Programmer : ���|��</br>
        /// <br>Date       : 2013/05/31</br>
        /// </remarks>
        private bool ScreenDataCheck1(ref Control control, ref string message)
        {
            bool result = true;

            // ���_�R�[�h
            if (this.tEdit_SectionCodeAllowZero2.DataText.Trim() == "")
            {
                control = this.tEdit_SectionCodeAllowZero2;
                message = this.SectionCode_Title_Label.Text + "����͂��ĉ������B";
                this.tEdit_SectionCodeAllowZero2.Clear();
                this.SectionGuideNm_tEdit.Clear();
                result = false;
            }

            return result;
        }

        /// <summary>
        /// ��ʓ��͏��s���`�F�b�N����
        /// </summary>
        /// <param name="control">�s���ΏۃR���g���[��</param>
        /// <param name="message">���b�Z�[�W</param>
        /// <returns>�`�F�b�N���ʁitrue:OK�^false:NG�j</returns>
        /// <remarks>
        /// <br>Note		: ��ʓ��͏��̕s���`�F�b�N���s���܂��B</br>
        /// <br>Programmer : ���|��</br>
        /// <br>Date       : 2013/05/31</br>
        /// </remarks>
        private bool ScreenDataCheck2(ref Control control, ref string message)
        {
            bool result = true;

            //��M�����N���[���ԍ�
            if (this.CashRegisterNo_tEdit.GetInt() == 0)
            {
                control = this.CashRegisterNo_tEdit;
                message = this.CashRegisterNo_Title_Label.Text + "����͂��ĉ������B";
                this.CashRegisterNo_tEdit.Clear();
                this.CashRegisterNoNm_tEdit.Clear();
                result = false;
            }

            return result;
        }

        /// <summary>
        /// ��ʓ��͏�񑶍݃`�F�b�N����
        /// </summary>
        /// <param name="control">�s���ΏۃR���g���[��</param>
        /// <param name="message">���b�Z�[�W</param>
        /// <returns>�`�F�b�N���ʁitrue:OK�^false:NG�j</returns>
        /// <remarks>
        /// <br>Note		: ��ʓ��͏��̑��݃`�F�b�N���s���܂��B</br>
        /// <br>Programmer : ���|��</br>
        /// <br>Date       : 2013/05/31</br>
        /// </remarks>
        private bool ExistDataCheck1(ref Control control, ref string message)
        {
            bool result = true;

            if (GetSectionName(this.tEdit_SectionCodeAllowZero2.DataText.Trim()) == "")
            {
                control = this.tEdit_SectionCodeAllowZero2;
                message = "���_�����݂��܂���B";
                this.tEdit_SectionCodeAllowZero2.Clear();
                this.SectionGuideNm_tEdit.Clear();
                result = false;
            }

            return result;
        }

        /// <summary>
        /// ��ʓ��͏�񑶍݃`�F�b�N����
        /// </summary>
        /// <param name="control">�s���ΏۃR���g���[��</param>
        /// <param name="message">���b�Z�[�W</param>
        /// <returns>�`�F�b�N���ʁitrue:OK�^false:NG�j</returns>
        /// <remarks>
        /// <br>Note		: ��ʓ��͏��̑��݃`�F�b�N���s���܂��B</br>
        /// <br>Programmer : ���|��</br>
        /// <br>Date       : 2013/05/31</br>
        /// </remarks>
        private bool ExistDataCheck2(ref Control control, ref string message)
        {
            bool result = true;

            PosTerminalMg posterMg = this.GetPosTerminalMg(this.CashRegisterNo_tEdit.GetInt());

            if (posterMg == null || posterMg.LogicalDeleteCode != 0)
            {
                control = this.CashRegisterNo_tEdit;
                message = "�Y������[���ԍ��͑��݂��܂���B";
                this.CashRegisterNo_tEdit.Clear();
                this.CashRegisterNoNm_tEdit.Clear();
                result = false;
            }

            return result;
        }

        /// <summary>
        /// �ۑ�����
        /// </summary>
        /// <returns>�`�F�b�N����</returns>
        /// <remarks>
        /// <br>Note�@�@�@ : ���_�EPMTAB�S�̐ݒ�}�X�^(���_��)�̕ۑ��������s���܂��B</br>
        /// <br>Programmer : ���|��</br>
        /// <br>Date       : 2013/05/31</br>
        /// </remarks>
        private bool SaveProc()
        {
            Control control = null;
            string message = null;

            // �s���f�[�^���̓`�F�b�N
            if (!ScreenDataCheck1(ref control, ref message)) {
                TMsgDisp.Show(
                    this, 								// �e�E�B���h�E�t�H�[��
                    emErrorLevel.ERR_LEVEL_EXCLAMATION, // �G���[���x��
                    ASSEMBLY_ID,						// �A�Z���u���h�c�܂��̓N���X�h�c
                    message, 							// �\�����郁�b�Z�[�W
                    0, 									// �X�e�[�^�X�l
                    MessageBoxButtons.OK);				// �\������{�^��

                control.Focus();
                return false;
            }

            if (!ExistDataCheck1(ref control, ref message))
            {
                TMsgDisp.Show(
                   this, 								// �e�E�B���h�E�t�H�[��
                   emErrorLevel.ERR_LEVEL_INFO,         // �G���[���x��
                   ASSEMBLY_ID,					      	// �A�Z���u���h�c�܂��̓N���X�h�c
                   message, 							// �\�����郁�b�Z�[�W
                   0, 									// �X�e�[�^�X�l
                   MessageBoxButtons.OK);				// �\������{�^��

                control.Focus();
                return false;
            }

            if (this._dataIndex < 0)
            {
                if (ModeChangeProc())
                {
                    this.tEdit_SectionCodeAllowZero2.Focus();
                    return false;
                }
            }

            // �s���f�[�^���̓`�F�b�N
            if (!ScreenDataCheck2(ref control, ref message))
            {
                TMsgDisp.Show(
                    this, 								// �e�E�B���h�E�t�H�[��
                    emErrorLevel.ERR_LEVEL_EXCLAMATION, // �G���[���x��
                    ASSEMBLY_ID,						// �A�Z���u���h�c�܂��̓N���X�h�c
                    message, 							// �\�����郁�b�Z�[�W
                    0, 									// �X�e�[�^�X�l
                    MessageBoxButtons.OK);				// �\������{�^��

                control.Focus();
                return false;
            }

            if (!ExistDataCheck2(ref control, ref message))
            {
                TMsgDisp.Show(
                   this, 								// �e�E�B���h�E�t�H�[��
                   emErrorLevel.ERR_LEVEL_INFO,         // �G���[���x��
                   ASSEMBLY_ID,					      	// �A�Z���u���h�c�܂��̓N���X�h�c
                   message, 							// �\�����郁�b�Z�[�W
                   0, 									// �X�e�[�^�X�l
                   MessageBoxButtons.OK);				// �\������{�^��

                control.Focus();
                return false;
            }

            // PMTAB�S�̐ݒ�}�X�^(���_��)�X�V
            if (!SaveSubsection())
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// �^�u���b�g�S�̐ݒ�}�X�^(���_��)�e�[�u���X�V
        /// </summary>
        /// <return>�X�V����status</return>
        /// <remarks>
        /// <br>Note       : �S�̐ݒ�}�X�^(���_��)�e�[�u���̍X�V���s���܂��B</br>
        /// <br>Programmer : ���|��</br>
        /// <br>Date       : 2013/05/31</br>
        /// </remarks>
        private bool SaveSubsection()
        {
            Control control = null;
            PmTabTtlStSec pmTabTtlStSec = new PmTabTtlStSec();

            // �o�^���R�[�h���擾
            if (this._detailsIndexBuf >= 0) {
                Guid guid = (Guid)this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[this._dataIndex][DETAILS_GUID_KEY];
                pmTabTtlStSec = ((PmTabTtlStSec)this._detailsTable[guid]).Clone();
            }

            // SecInfoSet�N���X�Ƀf�[�^���i�[
            DispToSubsection(ref pmTabTtlStSec);

            if (this._dataIndex < 0)
            {
                pmTabTtlStSec.SectionCode = pmTabTtlStSec.SectionCode.PadLeft(2, '0');
            }

            // SecInfoSet�N���X���A�N�Z�X�N���X�ɓn���ēo�^�E�X�V
            int status = this._pmTabTtlStSecAcs.Write(ref pmTabTtlStSec);

            // �G���[����
            switch (status) {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    // DataSet/Hash�X�V����
                    DetailsToDataSet(pmTabTtlStSec, this._detailsIndexBuf);
                    break;
                case (int)ConstantManagement.DB_Status.ctDB_DUPLICATE:
                    // �d������
                    RepeatTransaction(status, ref control);
                    control.Focus();
                    return false;
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    // �r������
                    ExclusiveTransaction(status, TMsgDisp.OPE_UPDATE, this._pmTabTtlStSecAcs);
                    // UI�q��ʋ����I������
                    EnforcedEndTransaction();
                    return false;
                default:
                    // �o�^���s
                    TMsgDisp.Show(
                        this,								// �e�E�B���h�E�t�H�[��
                        emErrorLevel.ERR_LEVEL_STOPDISP,	// �G���[���x��
                        ASSEMBLY_ID,						// �A�Z���u���h�c�܂��̓N���X�h�c
                        this.Text,							// �v���O��������
                        "SaveSubsection",				    // ��������
                        TMsgDisp.OPE_UPDATE,				// �I�y���[�V����
                        ERR_UPDT_MSG,						// �\�����郁�b�Z�[�W 
                        status,								// �X�e�[�^�X�l
                        this._pmTabTtlStSecAcs,				    // �G���[�����������I�u�W�F�N�g
                        MessageBoxButtons.OK,				// �\������{�^��
                        MessageBoxDefaultButton.Button1);	// �����\���{�^��

                    // UI�q��ʋ����I������
                    EnforcedEndTransaction();

                    return false;
            }

            // �V�K�o�^������
            NewEntryTransaction();

            return true;
        }

        /// <summary>
        /// PMTAB�S�̐ݒ�}�X�^(���_��) �_���폜����
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : PMTAB�S�̐ݒ�}�X�^(���_��)�̑Ώۃ��R�[�h���}�X�^����_���폜���܂��B</br>
        /// <br>Programmer : ���|��</br>
        /// <br>Date       : 2013/05/31</br>
        /// </remarks>
        private int LogicalDeleteSubsection()
        {
            int status = 0;

            // �폜�Ώ�PMTAB�S�̐ݒ�}�X�^(���_��)�擾
            Guid guid = (Guid)this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[this._dataIndex][DETAILS_GUID_KEY];
            PmTabTtlStSec pmTabTtlStSec = ((PmTabTtlStSec)this._detailsTable[guid]).Clone();

            if (pmTabTtlStSec.SectionCode.Trim() == ALL_SECTIONCODE)
            {
                TMsgDisp.Show(this,                             // �e�E�B���h�E�t�H�[��
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,     // �G���[���x��
                        ASSEMBLY_ID,							    // �A�Z���u��ID
                        "�S�Ћ��ʃf�[�^�͍폜�ł��܂���B",	    // �\�����郁�b�Z�[�W
                        0,									    // �X�e�[�^�X�l
                        MessageBoxButtons.OK);					// �\������{�^��
                return 0;
            }

            status = this._pmTabTtlStSecAcs.LogicalDelete(ref pmTabTtlStSec);

            switch (status) {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    // DataSet�X�V
                    DetailsToDataSet(pmTabTtlStSec, _dataIndex);
                    break;
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    // �r������
                    ExclusiveTransaction(status, TMsgDisp.OPE_HIDE, this._pmTabTtlStSecAcs);
                    // �t���[���X�V
                    DetailsToDataSet(pmTabTtlStSec, _dataIndex);
                    return status;
                default:
                    TMsgDisp.Show(
                        this,								// �e�E�B���h�E�t�H�[��
                        emErrorLevel.ERR_LEVEL_STOPDISP,	// �G���[���x��
                        ASSEMBLY_ID,						// �A�Z���u���h�c�܂��̓N���X�h�c
                        this.Text,							// �v���O��������
                        "LogicalDeleteSubsection",	        // ��������
                        TMsgDisp.OPE_HIDE,					// �I�y���[�V����
                        ERR_RDEL_MSG,						// �\�����郁�b�Z�[�W 
                        status,								// �X�e�[�^�X�l
                        this._pmTabTtlStSecAcs,			        // �G���[�����������I�u�W�F�N�g
                        MessageBoxButtons.OK,				// �\������{�^��
                        MessageBoxDefaultButton.Button1);	// �����\���{�^��

                    // �t���[���X�V
                    DetailsToDataSet(pmTabTtlStSec, _dataIndex);

                    return status;
            }

            return status;
        }

        /// <summary>
        /// PMTAB�S�̐ݒ�}�X�^(���_��) �����폜����
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : PMTAB�S�̐ݒ�}�X�^(���_��)�̑Ώۃ��R�[�h���}�X�^���畨���폜���܂��B</br>
        /// <br>Programmer : ���|��</br>
        /// <br>Date       : 2013/05/31</br>
        /// </remarks>
        private int PhysicalDeleteSubsection()
        {
            int status = 0;
            //int dummy = 0;
            Guid guid;

            // �폜�Ώ�PMTAB�S�̐ݒ�}�X�^(���_��)�擾
            guid = (Guid)this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[this._dataIndex][DETAILS_GUID_KEY];
            PmTabTtlStSec pmTabTtlStSec = ((PmTabTtlStSec)this._detailsTable[guid]).Clone();

            // �����폜
            status = this._pmTabTtlStSecAcs.Delete(pmTabTtlStSec);

            switch (status) {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    // DataSet�X�V
                    DeleteFromDataSet(pmTabTtlStSec, _dataIndex);
                    break;
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    // �r������
                    ExclusiveTransaction(status, TMsgDisp.OPE_DELETE, this._pmTabTtlStSecAcs);
                    // UI�q��ʋ����I������
                    EnforcedEndTransaction();

                    return status;
                default:
                    TMsgDisp.Show(
                        this,								// �e�E�B���h�E�t�H�[��
                        emErrorLevel.ERR_LEVEL_STOPDISP,	// �G���[���x��
                        ASSEMBLY_ID,						// �A�Z���u���h�c�܂��̓N���X�h�c
                        this.Text,							// �v���O��������
                        "PhysicalDeleteSubsection",		    // ��������
                        TMsgDisp.OPE_HIDE,					// �I�y���[�V����
                        ERR_RDEL_MSG,						// �\�����郁�b�Z�[�W 
                        status,								// �X�e�[�^�X�l
                        this._pmTabTtlStSecAcs,					// �G���[�����������I�u�W�F�N�g
                        MessageBoxButtons.OK,				// �\������{�^��
                        MessageBoxDefaultButton.Button1);	// �����\���{�^��

                    // UI�q��ʋ����I������
                    EnforcedEndTransaction();

                    return status;
            }

            if (UnDisplaying != null) {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                UnDisplaying(this, me);
            }

            this.DialogResult = DialogResult.OK;
            this._detailsIndexBuf = -2;

            if (CanClose == true) {
                this.Close();
            }
            else {
                this.Hide();
            }

            return status;
        }

        /// <summary>
        /// ���_ ��������
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : PMTAB�S�̐ݒ�}�X�^(���_��)�̑Ώۃ��R�[�h�𕜊����܂��B</br>
        /// <br>Programmer : ���|��</br>
        /// <br>Date       : 2013/05/31</br>
        /// </remarks>
        private int ReviveSubsection()
        {
            int status = 0;
            Guid guid;

            // �����Ώ�PMTAB�S�̐ݒ�}�X�^(���_��)�擾
            guid = (Guid)this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[this._dataIndex][DETAILS_GUID_KEY];
            PmTabTtlStSec pmTabTtlStSec = ((PmTabTtlStSec)this._detailsTable[guid]).Clone();

            // ����
            status = this._pmTabTtlStSecAcs.Revival(ref pmTabTtlStSec);

            switch (status) {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    // DataSet�W�J����
                    DetailsToDataSet(pmTabTtlStSec, this._dataIndex);
                    break;
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    // �r������
                    ExclusiveTransaction(status, TMsgDisp.OPE_UPDATE, this._pmTabTtlStSecAcs);
                    return status;
                default:
                    TMsgDisp.Show(
                        this,								// �e�E�B���h�E�t�H�[��
                        emErrorLevel.ERR_LEVEL_STOPDISP,    // �G���[���x��
                        ASSEMBLY_ID,						// �A�Z���u���h�c�܂��̓N���X�h�c
                        this.Text,							// �v���O��������
                        "ReviveSubsection",				    // ��������
                        TMsgDisp.OPE_UPDATE,				// �I�y���[�V����
                        ERR_RVV_MSG,						// �\�����郁�b�Z�[�W 
                        status,								// �X�e�[�^�X�l
                        this._pmTabTtlStSecAcs,					// �G���[�����������I�u�W�F�N�g
                        MessageBoxButtons.OK,				// �\������{�^��
                        MessageBoxDefaultButton.Button1);	// �����\���{�^��
                    return status;
            }

            if (UnDisplaying != null) {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                UnDisplaying(this, me);
            }

            this.DialogResult = DialogResult.OK;

            if (CanClose == true) {
                this.Close();
            }
            else {
                this.Hide();
            }

            return status;
        }

        /// <summary>
        /// �V�K�o�^������
        /// </summary>
        /// <remarks>
        /// <br>Note       : �V�K�o�^���̏������s���܂��B</br>
        /// <br>Programmer : ���|��</br>
        /// <br>Date       : 2013/05/31</br>
        /// </remarks>
        private void NewEntryTransaction()
        {
            if (UnDisplaying != null) {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                UnDisplaying(this, me);
            }

            // �O��[���ԍ����N�b���A
            this._preCashRegisterNo = 0;

            // �V�K���[�h�̏ꍇ�͉�ʂ��I�������ɘA�����͂��\�Ƃ���
            if (this.Mode_Label.Text == INSERT_MODE) 
            {
                // ��ʃN���A����
                ScreenClear();
                // ��ʏ����ݒ菈��
                ScreenInitialSetting();
                // ��ʍč\�z����
                ScreenReconstruction();
            }
            else {
                this.DialogResult = DialogResult.OK;
                this._detailsIndexBuf = -2;

                if (CanClose == true) {
                    this.Close();
                }
                else {
                    this.Hide();
                }
            }
        }

        /// <summary>
        /// UI�q��ʋ����I������
        /// </summary>
        /// <remarks>
        /// <br>Note       : �f�[�^�X�V�G���[����UI�q��ʋ����I���������s���܂��B</br>
        /// <br>Programmer : ���|��</br>
        /// <br>Date       : 2013/05/31</br>
        /// </remarks>
        private void EnforcedEndTransaction()
        {
            if (UnDisplaying != null) {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                UnDisplaying(this, me);
            }

            this.DialogResult = DialogResult.Cancel;
            this._detailsIndexBuf = -2;

            if (CanClose == true) {
                this.Close();
            }
            else {
                this.Hide();
            }
        }

        /// <summary>
        /// �d������
        /// </summary>
        /// <param name="status">�X�e�[�^�X</param>
        /// <param name="control">�ΏۃR���g���[��</param>
        /// <remarks>
        /// <br>Note       : �f�[�^�X�V���̏d���������s���܂��B</br>
        /// <br>Programmer : ���|��</br>
        /// <br>Date       : 2013/05/31</br>
        /// </remarks>
        private void RepeatTransaction(int status, ref Control control)
        {
            TMsgDisp.Show(
                this, 								// �e�E�B���h�E�t�H�[��
                emErrorLevel.ERR_LEVEL_EXCLAMATION, // �G���[���x��
                ASSEMBLY_ID,						// �A�Z���u���h�c�܂��̓N���X�h�c
                ERR_DPR_MSG, 	                    // �\�����郁�b�Z�[�W
                0, 									// �X�e�[�^�X�l
                MessageBoxButtons.OK);				// �\������{�^��

            control = this.tEdit_SectionCodeAllowZero2;
            this.tEdit_SectionCodeAllowZero2.Clear();
            this.SectionGuideNm_tEdit.Clear();
        }

        /// <summary>
        /// �r������
        /// </summary>
        /// <param name="operation">�I�y���[�V����</param>
        /// <param name="erObject">�G���[�I�u�W�F�N�g</param>
        /// <param name="status">�X�e�[�^�X</param>
        /// <remarks>
        /// <br>Note       : �f�[�^�X�V���̔r���������s���܂��B</br>
        /// <br>Programmer : ���|��</br>
        /// <br>Date       : 2013/05/31</br>
        /// </remarks>
        private void ExclusiveTransaction(int status, string operation, object erObject)
        {
            switch ( status ) {
                case ( int ) ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    TMsgDisp.Show(
                        this,								// �e�E�B���h�E�t�H�[��
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,	// �G���[���x��
                        ASSEMBLY_ID,						// �A�Z���u���h�c�܂��̓N���X�h�c
                        this.Text,							// �v���O��������
                        "ExclusiveTransaction",				// ��������
                        operation,							// �I�y���[�V����
                        ERR_800_MSG,						// �\�����郁�b�Z�[�W 
                        status,								// �X�e�[�^�X�l
                        erObject,							// �G���[�����������I�u�W�F�N�g
                        MessageBoxButtons.OK,				// �\������{�^��
                        MessageBoxDefaultButton.Button1);	// �����\���{�^��
                    break;
                case ( int ) ConstantManagement.DB_Status.ctDB_ALRDY_DELETE: 
                    TMsgDisp.Show(
                        this,								// �e�E�B���h�E�t�H�[��
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,	// �G���[���x��
                        ASSEMBLY_ID,						// �A�Z���u���h�c�܂��̓N���X�h�c
                        this.Text,							// �v���O��������
                        "ExclusiveTransaction",				// ��������
                        operation,							// �I�y���[�V����
                        ERR_801_MSG,						// �\�����郁�b�Z�[�W 
                        status,								// �X�e�[�^�X�l
                        erObject,							// �G���[�����������I�u�W�F�N�g
                        MessageBoxButtons.OK,				// �\������{�^��
                        MessageBoxDefaultButton.Button1);	// �����\���{�^��
                    break;
            }
        }

        /// <summary>
        /// �R���g���[���T�C�Y�ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note       : �R���g���[���̃T�C�Y�ݒ菈�����s���܂��B</br>
        /// <br>Programmer : ���|��</br>
        /// <br>Date       : 2013/05/31</br>
        /// </remarks>
        private void SetControlSize()
        {
            //����i�ԑI���敪
            this.LiPriSelPrtGdsNoDiv_tComboEditor.Items.Clear();
            this.LiPriSelPrtGdsNoDiv_tComboEditor.Items.Add(0,LIPRISELPRTGDSNODIVNM_VALUE0);
            this.LiPriSelPrtGdsNoDiv_tComboEditor.Items.Add(1, LIPRISELPRTGDSNODIVNM_VALUE1);
            // ----- ADD huangt 2013/07/11 Redmine#38166 ����p�i�Ԃ̐���Ɋւ��� ----- >>>>>
            this.LiPriSelPrtGdsNoDiv_tComboEditor.Items.Add(2, LIPRISELPRTGDSNODIVNM_VALUE2);
            this.LiPriSelPrtGdsNoDiv_tComboEditor.Items.Add(3, LIPRISELPRTGDSNODIVNM_VALUE3);
            // ----- ADD huangt 2013/07/11 Redmine#38166 ����p�i�Ԃ̐���Ɋւ��� ----- <<<<<
        }

        # endregion

        # region Control Events

        /// <summary>
        /// Form.Load �C�x���g(MAKHN09230U)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@ : ���[�U�[���t�H�[����ǂݍ��ނƂ��ɔ������܂��B</br>
        /// <br>Programmer : ���|��</br>
        /// <br>Date       : 2013/05/31</br>
        /// </remarks>
        private void PMTAB09100UA_Load(object sender, System.EventArgs e)
        {
            // �A�C�R�����\�[�X�Ǘ��N���X���g�p���āA�A�C�R����\������
            ImageList imageList25 = IconResourceManagement.ImageList24;
            ImageList imageList16 = IconResourceManagement.ImageList16;

            this.Ok_Button.ImageList = imageList25;
            this.Cancel_Button.ImageList = imageList25;
            this.Revive_Button.ImageList = imageList25;
            this.Delete_Button.ImageList = imageList25;
            this.Renewal_Button.ImageList = imageList16;

            this.Ok_Button.Appearance.Image = Size24_Index.SAVE;
            this.Cancel_Button.Appearance.Image = Size24_Index.CLOSE;
            this.Revive_Button.Appearance.Image = Size24_Index.REVIVAL;
            this.Delete_Button.Appearance.Image = Size24_Index.DELETE;
            this.Renewal_Button.Appearance.Image = Size16_Index.RENEWAL;

            // �K�C�h�{�^���̃A�C�R���ݒ�
            this.SectionGuide_ultraButton.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];

            this._preCashRegisterNo = 0;

            // �R���g���[���T�C�Y�ݒ�
            SetControlSize();
        }

        /// <summary>
        /// Form.Closing �C�x���g(MAKHN09230UA)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�L�����Z���ł���C�x���g�̃f�[�^��񋟂���N���X</param>
        /// <remarks>
        /// <br>Note       : �t�H�[�������O�ɁA���[�U�[���t�H�[������悤�Ƃ����Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : ���|��</br>
        /// <br>Date       : 2013/05/31</br>
        /// </remarks>
        private void PMTAB09100UA_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this._detailsIndexBuf = -2;
            this._preCashRegisterNo = 0;

            // �t�H�[���́u�~�v���N���b�N���ꂽ�ꍇ�̑Ή��ł��B
            if ( CanClose == false ) {
                e.Cancel = true;
                this.Hide();
                return;
            }
        }

        /// <summary>
        /// Control.VisibleChanged �C�x���g(MAKHN09230UA)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@  : �t�H�[���̕\����Ԃ��ς�����Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : ���|��</br>
        /// <br>Date       : 2013/05/31</br>
        /// </remarks>
        private void PMTAB09100UA_VisibleChanged(object sender, System.EventArgs e)
        {
            this.Owner.Activate();

            // �������g����\���ɂȂ����ꍇ�͈ȉ��̏������L�����Z������B
            if ( this.Visible == false ) {
                return;
            }

            // ��ʃN���A����
            ScreenClear();

            // ��ʏ����ݒ菈��
            ScreenInitialSetting();

            Initial_Timer.Enabled = true;
        }

        /// <summary>
        /// Control.Click �C�x���g(Ok_Button)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@ : �ۑ��{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : ���|��</br>
        /// <br>Date       : 2013/05/31</br>
        /// </remarks>
        private void Ok_Button_Click(object sender, System.EventArgs e)
        {
            // �o�^����
            SaveProc();
        }

        /// <summary>
        /// Control.Click �C�x���g(Cancel_Button)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@ : ����{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : ���|��</br>
        /// <br>Date       : 2013/05/31</br>
        /// </remarks>
        private void Cancel_Button_Click(object sender, System.EventArgs e)
        {
            bool cloneFlg = true;

            // �폜���[�h�ȊO�̏ꍇ�͕ۑ��m�F�������s��
            if ( this.Mode_Label.Text != DELETE_MODE ) {

                // ���݂̉�ʏ����擾
                PmTabTtlStSec pmTabTtlStSec = new PmTabTtlStSec();
                pmTabTtlStSec = this._PmTabTtlStSecClone.Clone();
                DispToSubsection(ref pmTabTtlStSec);
                // �ŏ��Ɏ擾������ʏ��Ɣ�r
                cloneFlg = this._PmTabTtlStSecClone.Equals(pmTabTtlStSec);

                if ( !( cloneFlg ) ) {
                    // ��ʏ�񂪕ύX����Ă����ꍇ�́A�ۑ��m�F���b�Z�[�W��\������
                    DialogResult res = TMsgDisp.Show(
                        this,								// �e�E�B���h�E�t�H�[��
                        emErrorLevel.ERR_LEVEL_SAVECONFIRM,	// �G���[���x��
                        ASSEMBLY_ID,						// �A�Z���u���h�c�܂��̓N���X�h�c
                        "",									// �\�����郁�b�Z�[�W 
                        0,									// �X�e�[�^�X�l
                        MessageBoxButtons.YesNoCancel);		// �\������{�^��

                    switch ( res ) {
                        case DialogResult.Yes:
                            if (SaveProc()) {
                                this.DialogResult = DialogResult.OK;
                                break;
                            }
                            else {
                                return;
                            }
                        case DialogResult.No: 
                            this.DialogResult = DialogResult.Cancel;
                            break;
                        default:
                            if (_modeFlg)
                            {
                                _modeFlg = false;
                            }
                            else
                            {
                                this.Cancel_Button.Focus();
                            }
                            return;
                    }
                }
            }

            if ( UnDisplaying != null ) {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult);
                UnDisplaying(this, me);
            }

            this.DialogResult = DialogResult.Cancel;
            this._detailsIndexBuf = -2;
            this._preCashRegisterNo = 0;

            if ( CanClose == true ) {
                this.Close();
            }
            else {
                this.Hide();
            }
        }

        /// <summary>
        /// Control.Click �C�x���g(Delete_Button)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@ : ���S�폜�{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : ���|��</br>
        /// <br>Date       : 2013/05/31</br>
        /// </remarks>
        private void Delete_Button_Click(object sender, System.EventArgs e)
        {
            // ���S�폜�m�F
            DialogResult result = TMsgDisp.Show(
                this, 								// �e�E�B���h�E�t�H�[��
                emErrorLevel.ERR_LEVEL_EXCLAMATION, // �G���[���x��
                ASSEMBLY_ID,						// �A�Z���u���h�c�܂��̓N���X�h�c
                "�f�[�^���폜���܂��B" + "\r\n" +
                "��낵���ł����H", 				// �\�����郁�b�Z�[�W
                0, 									// �X�e�[�^�X�l
                MessageBoxButtons.OKCancel,
                MessageBoxDefaultButton.Button2);		// �\������{�^��

            if ( result == DialogResult.OK ) {

                // PMTAB�S�̐ݒ�}�X�^(���_��)�����폜
                PhysicalDeleteSubsection();
            }
        }

        /// <summary>
        /// Control.Click �C�x���g(Revive_Button)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@ : �����{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : ���|��</br>
        /// <br>Date       : 2013/05/31</br>
        /// </remarks>
        private void Revive_Button_Click(object sender, System.EventArgs e)
        {
            ReviveSubsection();  
        }

        /// <summary>
        /// Timer.Tick �C�x���g �C�x���g(Initial_Timer)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@ : �w�肳�ꂽ�Ԋu�̎��Ԃ��o�߂����Ƃ��ɔ������܂��B
        ///					 ���̏����́A�V�X�e�����񋟂���X���b�h �v�[��
        ///					 �X���b�h�Ŏ��s����܂��B</br>
        /// <br>Programmer : ���|��</br>
        /// <br>Date       : 2013/05/31</br>
        /// </remarks>
        private void Initial_Timer_Tick(object sender, System.EventArgs e)
        {
            Initial_Timer.Enabled = false;
            ScreenReconstruction();
        }

        /// <summary>
        /// Control.Click �C�x���g(SectionGuide_Button)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@ : ���_�K�C�h�{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : ���|��</br>
        /// <br>Date       : 2008.06.04</br>
        /// </remarks>
        private void SectionGuide_ultraButton_Click(object sender, EventArgs e)
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
                    this.tEdit_SectionCodeAllowZero2.DataText = secInfoSet.SectionCode.Trim();
                    this.SectionGuideNm_tEdit.DataText = secInfoSet.SectionGuideNm.Trim();

                    this.CashRegisterNo_tEdit.Focus();

                    if (this._dataIndex < 0)
                    {
                        if (ModeChangeProc())
                        {
                            this.tEdit_SectionCodeAllowZero2.Focus();
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
        /// tArrowKeyControlChangeFocus�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note		: �R���g���[���̃t�H�[�J�X���ς��^�C�~���O�Ŕ������܂��B</br>
        /// <br>Programmer	: ���|��</br>
        /// <br>Date		: 2013/05/31</br>
        /// </remarks>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null)
            {
                return;
            }

            _modeFlg = false;
        
            switch (e.PrevCtrl.Name)
            {
                case "tEdit_SectionCodeAllowZero2":

                    if (this.tEdit_SectionCodeAllowZero2.DataText.Trim() == "")
                    {
                        this.SectionGuideNm_tEdit.DataText = "";
                    }
                    else
                    {
                        if (sectionExist(this.tEdit_SectionCodeAllowZero2.DataText.Trim()))
                        {
                            // ���_�R�[�h�擾
                            string sectionCode = this.tEdit_SectionCodeAllowZero2.DataText;

                            this.tEdit_SectionCodeAllowZero2.DataText = this.tEdit_SectionCodeAllowZero2.DataText.PadLeft(2, '0');

                            // ���_���̎擾
                            this.SectionGuideNm_tEdit.DataText = GetSectionName(sectionCode);

                        }
                        else 
                        {
                            TMsgDisp.Show(
                                           this, 								// �e�E�B���h�E�t�H�[��
                                           emErrorLevel.ERR_LEVEL_INFO,         // �G���[���x��
                                           ASSEMBLY_ID,						    // �A�Z���u���h�c�܂��̓N���X�h�c
                                           "���_�����݂��܂���B", 							// �\�����郁�b�Z�[�W
                                           0, 									// �X�e�[�^�X�l
                                           MessageBoxButtons.OK);				// �\������{�^��

                            this.tEdit_SectionCodeAllowZero2.Clear();
                            this.SectionGuideNm_tEdit.Clear();

                            e.NextCtrl = e.PrevCtrl;

                            break;
                        }

                    }

                    // ���_�R�[�h�Ƀt�H�[�J�X������ꍇ
                    if (e.Key == Keys.Right)
                    {
                        if (this.tEdit_SectionCodeAllowZero2.DataText.Trim() == "")
                        {
                            e.NextCtrl = this.SectionGuide_ultraButton;
                        }
                        else 
                        {
                            e.NextCtrl = this.CashRegisterNo_tEdit;
                        }
                    }
                    // ���[�h�ύX����
                    if (e.NextCtrl.Name == "Cancel_Button")
                    {
                        // �J�ڐ悪����{�^��
                        _modeFlg = true;
                    }
                    else if (this._dataIndex < 0)
                    {
                        if(ModeChangeProc())
                        {
                            e.NextCtrl = this.tEdit_SectionCodeAllowZero2;
                        }
                    }
                    break;
                case "CashRegisterNo_tEdit":
                    {
                        if ((this.CashRegisterNo_tEdit.GetInt()) == 0)
                        {
                            this.CashRegisterNoNm_tEdit.DataText = "";
                        }

                        if ((this.CashRegisterNo_tEdit.GetInt()) != 0 && (this.CashRegisterNo_tEdit.GetInt() != this._preCashRegisterNo))
                        {
                            // �[���Ǘ��ݒ�}�X�^���疼�̂��擾
                            PosTerminalMg posTerminalMg = GetPosTerminalMg(this.CashRegisterNo_tEdit.GetInt());
                            if ((posTerminalMg != null) &&
                                (posTerminalMg.LogicalDeleteCode == 0))
                            {
                                this.CashRegisterNoNm_tEdit.Text = posTerminalMg.MachineName;
                            }
                            else
                            {
                                TMsgDisp.Show(
                                    this,
                                    emErrorLevel.ERR_LEVEL_INFO,
                                    this.Name,
                                    "�Y������[���ԍ������݂��܂���B",
                                    -1,
                                    MessageBoxButtons.OK);

                                CashRegisterNo_tEdit.Clear();
                                CashRegisterNoNm_tEdit.Clear();

                                e.NextCtrl = e.PrevCtrl;
                            }
                        }

                        this._preCashRegisterNo = CashRegisterNo_tEdit.GetInt();

                        // ��M�����N���[���ԍ��R�[�h�Ƀt�H�[�J�X������ꍇ
                        if (e.Key == Keys.Down)
                        {
                            // ����i�ԑI���敪�Ƀt�H�[�J�X���ڂ��܂�
                            e.NextCtrl = this.LiPriSelPrtGdsNoDiv_tComboEditor;
                        }
                        break;
                    }
                case "Ok_Button":
                    // �ۑ��{�^���Ƀt�H�[�J�X������ꍇ
                    if (e.Key == Keys.Up)
                    {
                        // ���_�K�C�h�{�^���Ƀt�H�[�J�X���ڂ��܂�
                        e.NextCtrl = this.LiPriSelPrtGdsNoDiv_tComboEditor;
                    }
                    break;
                default:
                    break;
            }
        }

        private void Renewal_Button_Click(object sender, EventArgs e)
        {
            this._pmTabTtlStSecAcs = new PmTabTtlStSecAcs();

            this.GetCacheData();

            TMsgDisp.Show(this, 								// �e�E�B���h�E�t�H�[��
                          emErrorLevel.ERR_LEVEL_INFO,          // �G���[���x��
                          ASSEMBLY_ID,						    // �A�Z���u���h�c�܂��̓N���X�h�c
                          "�ŐV�����擾���܂����B", 			// �\�����郁�b�Z�[�W
                          0, 									// �X�e�[�^�X�l
                          MessageBoxButtons.OK);				// �\������{�^��
        }

        /// <summary>
        /// ���[�h�ύX����
        /// </summary>
        private bool ModeChangeProc()
        {
            if(this.tEdit_SectionCodeAllowZero2.DataText == "")
            {
                return false;
            }

            string msg = "���͂��ꂽ�R�[�h�̃^�u���b�g�S�̐ݒ�}�X�^(���_��)��񂪊��ɓo�^����Ă��܂��B\n�ҏW���s���܂����H";

            // ���_�R�[�h
            string SecCd = this.tEdit_SectionCodeAllowZero2.Text.TrimEnd().PadLeft(2,'0');

            for (int i = 0; i < this.Bind_DataSet.Tables[DETAILS_TABLE].Rows.Count; i++)
            {
                // �f�[�^�Z�b�g�Ɣ�r
                string dbSecCd = this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[i][SECTIONCODE_TITLE].ToString().Trim().PadLeft(2,'0');

                if (SecCd.Equals(dbSecCd.TrimEnd()))
                {
                    // ���̓R�[�h���f�[�^�Z�b�g�ɑ��݂���ꍇ
                    if ((string)this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[i][DELETE_DATE_TITLE] != "")
                    {
                        // �_���폜
                        TMsgDisp.Show(this, 					// �e�E�B���h�E�t�H�[��
                          emErrorLevel.ERR_LEVEL_INFO,          // �G���[���x��
                          ASSEMBLY_ID,						    // �A�Z���u���h�c�܂��̓N���X�h�c
                          "���͂��ꂽ�R�[�h�̃^�u���b�g�S�̐ݒ�}�X�^(���_��)���͊��ɍ폜����Ă��܂��B", 			// �\�����郁�b�Z�[�W
                          0, 									// �X�e�[�^�X�l
                          MessageBoxButtons.OK);				// �\������{�^��
                        // PMTAB�S�̐ݒ�}�X�^(���_��)�R�[�h�̃N���A
                        this.tEdit_SectionCodeAllowZero2.Clear();
                        this.SectionGuideNm_tEdit.Clear();
                        return true;
                    }

                    if (SecCd == ALL_SECTIONCODE)
                    {
                        // �S�Ћ��ʂ̃��b�Z�[�W�ύX
                        msg = "���͂��ꂽ�R�[�h�̃^�u���b�g�S�̐ݒ�}�X�^(���_��)��񂪊��ɓo�^����Ă��܂��B\n�@�y���_���́F�S�Ћ��ʁz\n�ҏW���s���܂����H";
                    }


                    DialogResult res = TMsgDisp.Show(
                        this,                                   // �e�E�B���h�E�t�H�[��
                        emErrorLevel.ERR_LEVEL_INFO,            // �G���[���x��
                        ASSEMBLY_ID,                            // �A�Z���u���h�c�܂��̓N���X�h�c
                        msg,                                    // �\�����郁�b�Z�[�W
                        0,                                      // �X�e�[�^�X�l
                        MessageBoxButtons.YesNo);               // �\������{�^��
                    switch (res)
                    {
                        case DialogResult.Yes:
                            {
                                // ��ʍĕ`��
                                this._dataIndex = i;
                                ScreenClear();
                                ScreenInitialSetting();
                                ScreenReconstruction();
                                break;
                            }
                        case DialogResult.No:
                            {
                                // ���_�R�[�h�̃N���A
                                this.tEdit_SectionCodeAllowZero2.Clear();
                                this.SectionGuideNm_tEdit.Clear();
                                break;
                            }
                    }
                    return true;
                } 
            }
            return false;
        }


        /// <summary>
        /// �L���b�V�����擾����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �[���Ǘ��ԍ��̖��̂��L���b�V�����B</br>
        /// </remarks>
        private void GetCacheData()
        {
            // �[���Ǘ��ݒ�擾
            this.GetPosTerminalMgCache();

        }

        /// <summary>
        /// �[���Ǘ��ݒ�̃��[�J���L���b�V��
        /// </summary>
        /// <remarks>
        /// <br>Note       : �[���Ǘ��ݒ�̃��[�J���L���b�V�����쐬���܂��B</br>
        /// <br></br>
        /// </remarks>
        private void GetPosTerminalMgCache()
        {
            int status;
            ArrayList retList;

            // �[���Ǘ��ݒ�̃��[�J���L���b�V�����N���A
            _posTerminalMgDic = new Dictionary<int, PosTerminalMg>();

            // �[���Ǘ��ݒ�̎擾
            status = this._posTerminalMgAcs.SearchServer(out retList, LoginInfoAcquisition.EnterpriseCode);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                foreach (PosTerminalMg wkPosTerminalMg in retList)
                {
                    if (wkPosTerminalMg.LogicalDeleteCode == 0)
                    {
                        int key = wkPosTerminalMg.CashRegisterNo;
                        if (_posTerminalMgDic.ContainsKey(key))
                        {
                            // ���ɃL���b�V���ɑ��݂��Ă���ꍇ�͍폜
                            _posTerminalMgDic.Remove(key);
                        }
                        _posTerminalMgDic.Add(key, wkPosTerminalMg);
                    }
                }
            }
        }

        /// <summary>
        /// �[���Ǘ��ݒ���擾���܂��B
        /// </summary>
        /// <param name="cashRegisterNo">�[���ԍ�</param>
        /// <returns>�[���Ǘ��ݒ�f�[�^�N���X</returns>
        /// <remarks>
        /// <br>Note       : �[���ԍ�����[���Ǘ��ݒ�f�[�^�N���X���擾���܂��B</br>
        /// <br></br>
        /// </remarks>
        private PosTerminalMg GetPosTerminalMg(int cashRegisterNo)
        {
            PosTerminalMg posTerminalMg = null;

            if (_posTerminalMgDic.ContainsKey(cashRegisterNo))
            {
                posTerminalMg = _posTerminalMgDic[cashRegisterNo];
            }
            else
            {
                int status = this._posTerminalMgAcs.Read(out posTerminalMg, this._enterpriseCode, cashRegisterNo);
                if (status != 0)
                {
                    posTerminalMg = null;
                }
            }

            return posTerminalMg;
        }

        /// <summary>
        /// ����p�i�Ԑݒ�敪���̂��擾���܂��B
        /// </summary>
        /// <param name="liPriSelPrtGdsNoDiv">����p�i�Ԑݒ�敪</param>
        /// <returns>����p�i�Ԑݒ�敪����</returns>
        /// <remarks>
        /// <br>Note       : ����p�i�Ԑݒ�敪�������p�i�Ԑݒ�敪���̂��擾���܂��B</br>
        /// <br></br>
        /// </remarks>
        private string GetLiPriSelPrtGdsNoDivNm(int liPriSelPrtGdsNoDiv)
        {
            string str = string.Empty;

            switch (liPriSelPrtGdsNoDiv)
            {
                case 0:
                    str = LIPRISELPRTGDSNODIVNM_VALUE0;
                    break;
                case 1:
                    str = LIPRISELPRTGDSNODIVNM_VALUE1;
                    break;
                // ----- ADD huangt 2013/07/11 Redmine#38166 ����p�i�Ԃ̐���Ɋւ��� ----- >>>>>
                case 2:
                    str = LIPRISELPRTGDSNODIVNM_VALUE2;
                    break;
                case 3:
                    str = LIPRISELPRTGDSNODIVNM_VALUE3;
                    break;
                // ----- ADD huangt 2013/07/11 Redmine#38166 ����p�i�Ԃ̐���Ɋւ��� ----- <<<<<
                default:
                    break;
            }
            return str;
        }

        /// <summary>
        /// ���_�����݂����`�F�b�N�B
        /// </summary>
        /// <param name="sectioncode">���_�R�[�h</param>
        /// <returns>flag</returns>
        /// <remarks>
        /// <br>Note       : ���_�����݂����`�F�b�N�B</br>
        /// <br></br>
        /// </remarks>
        private bool sectionExist(string sectioncode)
        {
            return this._pmTabTtlStSecAcs.SectionExistCheck(sectioncode);
        }

        /// <summary>
        /// ���_�R�[�hEdit Leave����
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : ���_���̕\������</br>
        /// <br></br>
        /// </remarks>
        private void tEdit_SectionCode_Leave(object sender, EventArgs e)
        {
            // ���_�R�[�h���͂���H
            if (this.tEdit_SectionCodeAllowZero2.Text != "")
            {
                // ���_�R�[�h���̐ݒ�
                this.SectionGuideNm_tEdit.Text = GetSectionName(this.tEdit_SectionCodeAllowZero2.Text.Trim());

                if (SectionUtil.IsAllSection(this.tEdit_SectionCodeAllowZero2.Text))
                {
                    this.SectionGuideNm_tEdit.Text = SectionUtil.ALL_SECTION_NAME;
                }

            }
        }

        /// <summary>
        /// ���_�R�[�htEdit_SectionCodeAllowZero2_ValueChanged�����A�����ȊO���͂ł��Ȃ�
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : ���_�R�[�htEdit_SectionCodeAllowZero2_ValueChanged�����A�����ȊO���͂ł��Ȃ�</br>
        /// <br></br>
        /// </remarks>
        private void tEdit_SectionCodeAllowZero2_ValueChanged(object sender, EventArgs e)
        {
            Regex x = new Regex("^[0-9]*$");
            if (!(x.IsMatch(this.tEdit_SectionCodeAllowZero2.Text)))
            {
                this.tEdit_SectionCodeAllowZero2.Clear();
                this.tEdit_SectionCodeAllowZero2.Focus();
            }
        }

        /// <summary>
        /// �[���ԍ��R�[�hCashRegisterNo_tEdit_ValueChanged�����A�����ȊO���͂ł��Ȃ�
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : �[���ԍ��R�[�hCashRegisterNo_tEdit_ValueChanged�����A�����ȊO���͂ł��Ȃ�</br>
        /// <br></br>
        /// </remarks>
        private void CashRegisterNo_tEdit_ValueChanged(object sender, EventArgs e)
        {
            Regex x = new Regex("^[0-9]*$");
            if (!(x.IsMatch(this.CashRegisterNo_tEdit.Text)))
            {
                this.CashRegisterNo_tEdit.Clear();
                this.CashRegisterNo_tEdit.Focus();
            }
        }
               
        # endregion

    }
}

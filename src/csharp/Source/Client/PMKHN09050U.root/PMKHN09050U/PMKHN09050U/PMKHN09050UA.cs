//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���ʃR�[�h�}�X�^
// �v���O�����T�v   : ���ʃR�[�h�}�X�^�̓o�^�E�ύX�E�폜���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2007 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ����
// �� �� ��  2008/06/17  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  12720       �쐬�S�� : �H��
// �C �� ��  2009/03/25  �C�����e : �u�폜�σf�[�^�̕\���v�͍ŏ�ʍ��ڂŐ���
//----------------------------------------------------------------------------//
#define DELETE_DATE_DEPEND_ON_SUB_TABLE // ���C���e�[�u���̍폜�����T�u�e�[�u���Ɋ֘A������t���O
using System;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Diagnostics;

using Broadleaf.Library.Resources;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Controller.Util;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Windows.Forms;
using Infragistics.Win.UltraWinGrid;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// ���ʃR�[�h�}�X�^ �t�H�[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note		: ���ʃR�[�h�}�X�^���̐ݒ���s���܂��B
    ///					  IMasterMaintenanceThreeArrayType���������Ă��܂��B</br>
    /// <br>Programmer	: 30413 ����</br>
    /// <br>Date		: 2008.06.17</br>
    /// <br>Note		: �u�폜�σf�[�^�̕\���v�͍ŏ�ʍ��ڂŐ���</br>
    /// <br>Programmer	: 30434 �H��</br>
    /// <br>Date		: 2009.03.25</br>
    /// <br></br>
    /// </remarks>
    public class PMKHN09050UA : System.Windows.Forms.Form, IMasterMaintenanceThreeArrayType, ISynchroLogDelChkBox
    {
        # region ��Private Members (Component)

        private Infragistics.Win.Misc.UltraLabel PartsPosCode_Label;
        private TNedit PartsPosCode_tNedit;
        private Infragistics.Win.Misc.UltraLabel PartsPosName_Label;
        private TEdit PartsPosName_tEdit;
        private Infragistics.Win.UltraWinStatusBar.UltraStatusBar ultraStatusBar1;
        private Infragistics.Win.Misc.UltraButton Cancel_Button;
        private Infragistics.Win.Misc.UltraButton Revive_Button;
        private Infragistics.Win.Misc.UltraButton Delete_Button;
        private Infragistics.Win.Misc.UltraButton Ok_Button;
        private IContainer components;
        private TArrowKeyControl tArrowKeyControl1;
        private Timer Initial_Timer;
        private Infragistics.Win.Misc.UltraButton DeleteRow_Button;
        private UltraGrid tbsPartsList_ultraGrid;
        private DataSet Bind_DataSet;
        private TRetKeyControl tRetKeyControl1;
        private UiSetControl uiSetControl1;
        private TEdit CustomerSnm_tEdit;
        private TNedit tNedit_CustomerCodeAllowZero;
        private Infragistics.Win.Misc.UltraLabel ultraLabel1;
        private Infragistics.Win.Misc.UltraButton CustomerCd_GuideBtn;
        private Infragistics.Win.Misc.UltraButton Guid_Button;
        private Infragistics.Win.Misc.UltraButton Renewal_Button;
        private Infragistics.Win.Misc.UltraLabel Mode_Label;

        #endregion

        #region ��Windows �t�H�[�� �f�U�C�i�Ő������ꂽ�R�[�h
        /// <summary>
        /// �f�U�C�i �T�|�[�g�ɕK�v�ȃ��\�b�h�ł��B���̃��\�b�h�̓��e��
        /// �R�[�h �G�f�B�^�ŕύX���Ȃ��ł��������B
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance99 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PMKHN09050UA));
            this.Mode_Label = new Infragistics.Win.Misc.UltraLabel();
            this.PartsPosCode_Label = new Infragistics.Win.Misc.UltraLabel();
            this.PartsPosCode_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.PartsPosName_Label = new Infragistics.Win.Misc.UltraLabel();
            this.PartsPosName_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.ultraStatusBar1 = new Infragistics.Win.UltraWinStatusBar.UltraStatusBar();
            this.Cancel_Button = new Infragistics.Win.Misc.UltraButton();
            this.Revive_Button = new Infragistics.Win.Misc.UltraButton();
            this.Delete_Button = new Infragistics.Win.Misc.UltraButton();
            this.Ok_Button = new Infragistics.Win.Misc.UltraButton();
            this.tArrowKeyControl1 = new Broadleaf.Library.Windows.Forms.TArrowKeyControl(this.components);
            this.Initial_Timer = new System.Windows.Forms.Timer(this.components);
            this.Bind_DataSet = new System.Data.DataSet();
            this.tRetKeyControl1 = new Broadleaf.Library.Windows.Forms.TRetKeyControl(this.components);
            this.tbsPartsList_ultraGrid = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.DeleteRow_Button = new Infragistics.Win.Misc.UltraButton();
            this.uiSetControl1 = new Broadleaf.Library.Windows.Forms.UiSetControl(this.components);
            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.CustomerSnm_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.tNedit_CustomerCodeAllowZero = new Broadleaf.Library.Windows.Forms.TNedit();
            this.CustomerCd_GuideBtn = new Infragistics.Win.Misc.UltraButton();
            this.Guid_Button = new Infragistics.Win.Misc.UltraButton();
            this.Renewal_Button = new Infragistics.Win.Misc.UltraButton();
            ((System.ComponentModel.ISupportInitialize)(this.PartsPosCode_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PartsPosName_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bind_DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbsPartsList_ultraGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerSnm_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_CustomerCodeAllowZero)).BeginInit();
            this.SuspendLayout();
            // 
            // Mode_Label
            // 
            appearance13.ForeColor = System.Drawing.Color.White;
            appearance13.TextHAlignAsString = "Center";
            appearance13.TextVAlignAsString = "Middle";
            this.Mode_Label.Appearance = appearance13;
            this.Mode_Label.BackColorInternal = System.Drawing.Color.Navy;
            this.Mode_Label.Location = new System.Drawing.Point(493, 12);
            this.Mode_Label.Name = "Mode_Label";
            this.Mode_Label.Size = new System.Drawing.Size(100, 23);
            this.Mode_Label.TabIndex = 70;
            this.Mode_Label.Text = "�X�V���[�h";
            // 
            // PartsPosCode_Label
            // 
            appearance1.TextVAlignAsString = "Middle";
            this.PartsPosCode_Label.Appearance = appearance1;
            this.PartsPosCode_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.PartsPosCode_Label.Location = new System.Drawing.Point(12, 71);
            this.PartsPosCode_Label.Name = "PartsPosCode_Label";
            this.PartsPosCode_Label.Size = new System.Drawing.Size(133, 24);
            this.PartsPosCode_Label.TabIndex = 71;
            this.PartsPosCode_Label.Text = "���ʃR�[�h";
            // 
            // PartsPosCode_tNedit
            // 
            appearance4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance4.TextHAlignAsString = "Right";
            this.PartsPosCode_tNedit.ActiveAppearance = appearance4;
            appearance5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance5.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance5.ForeColorDisabled = System.Drawing.Color.Black;
            appearance5.TextHAlignAsString = "Right";
            this.PartsPosCode_tNedit.Appearance = appearance5;
            this.PartsPosCode_tNedit.AutoSelect = true;
            this.PartsPosCode_tNedit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.PartsPosCode_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.PartsPosCode_tNedit.DataText = "";
            this.PartsPosCode_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.PartsPosCode_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 2, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.PartsPosCode_tNedit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.PartsPosCode_tNedit.Location = new System.Drawing.Point(151, 71);
            this.PartsPosCode_tNedit.MaxLength = 2;
            this.PartsPosCode_tNedit.Name = "PartsPosCode_tNedit";
            this.PartsPosCode_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.PartsPosCode_tNedit.Size = new System.Drawing.Size(28, 24);
            this.PartsPosCode_tNedit.TabIndex = 3;
            // 
            // PartsPosName_Label
            // 
            appearance6.TextVAlignAsString = "Middle";
            this.PartsPosName_Label.Appearance = appearance6;
            this.PartsPosName_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.PartsPosName_Label.Location = new System.Drawing.Point(12, 101);
            this.PartsPosName_Label.Name = "PartsPosName_Label";
            this.PartsPosName_Label.Size = new System.Drawing.Size(133, 24);
            this.PartsPosName_Label.TabIndex = 71;
            this.PartsPosName_Label.Text = "���ʖ�";
            // 
            // PartsPosName_tEdit
            // 
            appearance7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.PartsPosName_tEdit.ActiveAppearance = appearance7;
            appearance8.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance8.ForeColorDisabled = System.Drawing.Color.Black;
            this.PartsPosName_tEdit.Appearance = appearance8;
            this.PartsPosName_tEdit.AutoSelect = true;
            this.PartsPosName_tEdit.DataText = "";
            this.PartsPosName_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.PartsPosName_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 15, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, true, true, true, true));
            this.PartsPosName_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.PartsPosName_tEdit.Location = new System.Drawing.Point(151, 101);
            this.PartsPosName_tEdit.MaxLength = 15;
            this.PartsPosName_tEdit.Name = "PartsPosName_tEdit";
            this.PartsPosName_tEdit.Size = new System.Drawing.Size(252, 24);
            this.PartsPosName_tEdit.TabIndex = 4;
            // 
            // ultraStatusBar1
            // 
            this.ultraStatusBar1.Location = new System.Drawing.Point(0, 483);
            this.ultraStatusBar1.Name = "ultraStatusBar1";
            this.ultraStatusBar1.Size = new System.Drawing.Size(605, 23);
            this.ultraStatusBar1.TabIndex = 74;
            this.ultraStatusBar1.ViewStyle = Infragistics.Win.UltraWinStatusBar.ViewStyle.Office2003;
            // 
            // Cancel_Button
            // 
            this.Cancel_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Cancel_Button.Location = new System.Drawing.Point(469, 442);
            this.Cancel_Button.Name = "Cancel_Button";
            this.Cancel_Button.Size = new System.Drawing.Size(125, 34);
            this.Cancel_Button.TabIndex = 10;
            this.Cancel_Button.Text = "����(&X)";
            this.Cancel_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Cancel_Button.Click += new System.EventHandler(this.Cancel_Button_Click);
            // 
            // Revive_Button
            // 
            this.Revive_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Revive_Button.Location = new System.Drawing.Point(338, 442);
            this.Revive_Button.Name = "Revive_Button";
            this.Revive_Button.Size = new System.Drawing.Size(125, 34);
            this.Revive_Button.TabIndex = 8;
            this.Revive_Button.Text = "����(&R)";
            this.Revive_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Revive_Button.Click += new System.EventHandler(this.Revive_Button_Click);
            // 
            // Delete_Button
            // 
            this.Delete_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Delete_Button.Location = new System.Drawing.Point(210, 442);
            this.Delete_Button.Name = "Delete_Button";
            this.Delete_Button.Size = new System.Drawing.Size(125, 34);
            this.Delete_Button.TabIndex = 7;
            this.Delete_Button.Text = "���S�폜(&D)";
            this.Delete_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Delete_Button.Click += new System.EventHandler(this.Delete_Button_Click);
            // 
            // Ok_Button
            // 
            this.Ok_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Ok_Button.Location = new System.Drawing.Point(338, 442);
            this.Ok_Button.Name = "Ok_Button";
            this.Ok_Button.Size = new System.Drawing.Size(125, 34);
            this.Ok_Button.TabIndex = 9;
            this.Ok_Button.Text = "�ۑ�(&S)";
            this.Ok_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Ok_Button.Click += new System.EventHandler(this.Ok_Button_Click);
            // 
            // tArrowKeyControl1
            // 
            this.tArrowKeyControl1.OwnerForm = this;
            this.tArrowKeyControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tArrowKeyControl1_ChangeFocus);
            // 
            // Initial_Timer
            // 
            this.Initial_Timer.Interval = 1;
            this.Initial_Timer.Tick += new System.EventHandler(this.Initial_Timer_Tick);
            // 
            // Bind_DataSet
            // 
            this.Bind_DataSet.DataSetName = "NewDataSet";
            // 
            // tRetKeyControl1
            // 
            this.tRetKeyControl1.OwnerForm = this;
            this.tRetKeyControl1.Style = Broadleaf.Library.Windows.Forms.emFocusStyle.ByTab;
            this.tRetKeyControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tArrowKeyControl1_ChangeFocus);
            // 
            // tbsPartsList_ultraGrid
            // 
            this.tbsPartsList_ultraGrid.Location = new System.Drawing.Point(12, 166);
            this.tbsPartsList_ultraGrid.Name = "tbsPartsList_ultraGrid";
            this.tbsPartsList_ultraGrid.Size = new System.Drawing.Size(582, 270);
            this.tbsPartsList_ultraGrid.TabIndex = 6;
            this.tbsPartsList_ultraGrid.ClickCellButton += new Infragistics.Win.UltraWinGrid.CellEventHandler(this.tbsPartsList_ultraGrid_ClickCellButton);
            this.tbsPartsList_ultraGrid.AfterExitEditMode += new System.EventHandler(this.tbsPartsList_ultraGrid_AfterExitEditMode);
            this.tbsPartsList_ultraGrid.VisibleChanged += new System.EventHandler(this.tbsPartsList_ultraGrid_VisibleChanged);
            this.tbsPartsList_ultraGrid.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbsPartsList_ultraGrid_KeyPress);
            this.tbsPartsList_ultraGrid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbsPartsList_ultraGrid_KeyDown);
            // 
            // DeleteRow_Button
            // 
            this.DeleteRow_Button.Font = new System.Drawing.Font("�l�r �S�V�b�N", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.DeleteRow_Button.Location = new System.Drawing.Point(12, 131);
            this.DeleteRow_Button.Name = "DeleteRow_Button";
            this.DeleteRow_Button.Size = new System.Drawing.Size(98, 29);
            this.DeleteRow_Button.TabIndex = 5;
            this.DeleteRow_Button.Text = "�폜(&D)";
            this.DeleteRow_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.DeleteRow_Button.Click += new System.EventHandler(this.DeleteRow_Button_Click);
            // 
            // uiSetControl1
            // 
            this.uiSetControl1.EditWidthSettingWay = Broadleaf.Library.Windows.Forms.UiSetControl.EditWidthSettingWayState.None;
            this.uiSetControl1.OwnerForm = this;
            // 
            // ultraLabel1
            // 
            appearance19.TextVAlignAsString = "Middle";
            this.ultraLabel1.Appearance = appearance19;
            this.ultraLabel1.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel1.Location = new System.Drawing.Point(12, 42);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(133, 24);
            this.ultraLabel1.TabIndex = 71;
            this.ultraLabel1.Text = "���Ӑ�R�[�h";
            // 
            // CustomerSnm_tEdit
            // 
            appearance2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.CustomerSnm_tEdit.ActiveAppearance = appearance2;
            appearance3.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance3.ForeColorDisabled = System.Drawing.Color.Black;
            this.CustomerSnm_tEdit.Appearance = appearance3;
            this.CustomerSnm_tEdit.AutoSelect = true;
            this.CustomerSnm_tEdit.DataText = "";
            this.CustomerSnm_tEdit.Enabled = false;
            this.CustomerSnm_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.CustomerSnm_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 15, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, true, true, true, true));
            this.CustomerSnm_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.CustomerSnm_tEdit.Location = new System.Drawing.Point(272, 41);
            this.CustomerSnm_tEdit.MaxLength = 15;
            this.CustomerSnm_tEdit.Name = "CustomerSnm_tEdit";
            this.CustomerSnm_tEdit.Size = new System.Drawing.Size(314, 24);
            this.CustomerSnm_tEdit.TabIndex = 2;
            // 
            // tNedit_CustomerCodeAllowZero
            // 
            appearance20.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance20.TextHAlignAsString = "Right";
            this.tNedit_CustomerCodeAllowZero.ActiveAppearance = appearance20;
            appearance21.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance21.ForeColorDisabled = System.Drawing.Color.Black;
            appearance21.TextHAlignAsString = "Right";
            this.tNedit_CustomerCodeAllowZero.Appearance = appearance21;
            this.tNedit_CustomerCodeAllowZero.AutoSelect = true;
            this.tNedit_CustomerCodeAllowZero.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_CustomerCodeAllowZero.DataText = "";
            this.tNedit_CustomerCodeAllowZero.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_CustomerCodeAllowZero.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 2, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_CustomerCodeAllowZero.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.tNedit_CustomerCodeAllowZero.Location = new System.Drawing.Point(151, 41);
            this.tNedit_CustomerCodeAllowZero.MaxLength = 2;
            this.tNedit_CustomerCodeAllowZero.Name = "tNedit_CustomerCodeAllowZero";
            this.tNedit_CustomerCodeAllowZero.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.tNedit_CustomerCodeAllowZero.Size = new System.Drawing.Size(82, 24);
            this.tNedit_CustomerCodeAllowZero.TabIndex = 1;
            // 
            // CustomerCd_GuideBtn
            // 
            appearance99.ImageHAlign = Infragistics.Win.HAlign.Center;
            this.CustomerCd_GuideBtn.Appearance = appearance99;
            this.CustomerCd_GuideBtn.BackColorInternal = System.Drawing.Color.WhiteSmoke;
            this.CustomerCd_GuideBtn.Location = new System.Drawing.Point(241, 40);
            this.CustomerCd_GuideBtn.Name = "CustomerCd_GuideBtn";
            this.CustomerCd_GuideBtn.Size = new System.Drawing.Size(25, 25);
            this.CustomerCd_GuideBtn.TabIndex = 2;
            this.CustomerCd_GuideBtn.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.CustomerCd_GuideBtn.Click += new System.EventHandler(this.CustomerCd_GuideBtn_Click);
            // 
            // Guid_Button
            // 
            this.Guid_Button.Font = new System.Drawing.Font("�l�r �S�V�b�N", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Guid_Button.Location = new System.Drawing.Point(116, 131);
            this.Guid_Button.Name = "Guid_Button";
            this.Guid_Button.Size = new System.Drawing.Size(161, 29);
            this.Guid_Button.TabIndex = 75;
            this.Guid_Button.Text = "�񋟕��ʶ޲��(&G)";
            this.Guid_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Guid_Button.Click += new System.EventHandler(this.Guid_Button_Click);
            // 
            // Renewal_Button
            // 
            this.Renewal_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Renewal_Button.Location = new System.Drawing.Point(210, 442);
            this.Renewal_Button.Name = "Renewal_Button";
            this.Renewal_Button.Size = new System.Drawing.Size(125, 34);
            this.Renewal_Button.TabIndex = 7;
            this.Renewal_Button.Text = "�ŐV���(&I)";
            this.Renewal_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Renewal_Button.Click += new System.EventHandler(this.Renewal_Button_Click);
            // 
            // PMKHN09050UA
            // 
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(605, 506);
            this.Controls.Add(this.Renewal_Button);
            this.Controls.Add(this.Guid_Button);
            this.Controls.Add(this.CustomerCd_GuideBtn);
            this.Controls.Add(this.DeleteRow_Button);
            this.Controls.Add(this.tbsPartsList_ultraGrid);
            this.Controls.Add(this.Cancel_Button);
            this.Controls.Add(this.Revive_Button);
            this.Controls.Add(this.Delete_Button);
            this.Controls.Add(this.Ok_Button);
            this.Controls.Add(this.ultraStatusBar1);
            this.Controls.Add(this.CustomerSnm_tEdit);
            this.Controls.Add(this.PartsPosName_tEdit);
            this.Controls.Add(this.tNedit_CustomerCodeAllowZero);
            this.Controls.Add(this.PartsPosCode_tNedit);
            this.Controls.Add(this.ultraLabel1);
            this.Controls.Add(this.PartsPosName_Label);
            this.Controls.Add(this.PartsPosCode_Label);
            this.Controls.Add(this.Mode_Label);
            this.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PMKHN09050UA";
            this.Text = "���ʃ}�X�^";
            this.Load += new System.EventHandler(this.PMKHN09050UA_Load);
            this.VisibleChanged += new System.EventHandler(this.PMKHN09050UA_VisibleChanged);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PMKHN09050UA_Closing);
            ((System.ComponentModel.ISupportInitialize)(this.PartsPosCode_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PartsPosName_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bind_DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbsPartsList_ultraGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerSnm_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_CustomerCodeAllowZero)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        #region ��Private Members
        private PartsPosCodeUAcs _partsPosCodeUAcs;
        private BLGoodsCdAcs _blGoodsCdAcs;
        
        private PartsPosCodeU _partsPosCodeU;
        private PartsPosCodeU[] _partsPosCodeUCloneList;

        private int _totalCount;
        private string _enterpriseCode;
        private Hashtable _mainGridTable;
        private Hashtable _secondGridTable;
        private Hashtable _thirdGridTable;
        private Hashtable _thirdGridCloneTable;

        // �v���p�e�B�p
        private bool _canPrint;
        private bool _canLogicalDeleteDataExtraction;
        private bool _canClose;
        private bool _canNew;
        private bool _canDelete;
        private MGridDisplayLayout _defaultGridDisplayLayout;
        private string _targetTableName;

        // �^�C�g��
        private string _mainGridTitle;
        private string _secondGridTitle;
        private string _thirdGridTitle;

        // �A�C�R��
        private Image _mainGridIcon;
        private Image _secondGridIcon;
        private Image _thirdGridIcon;

        // �I���f�[�^�C���f�b�N�X
        private int _mainDataIndex;
        private int _secondDataIndex;
        private int _thirdDataIndex;

        //_dataIndex�o�b�t�@�i���C���t���[���ŏ����Ή��j
        private int _mainIndexBuffer;
        private int _secondIndexBuffer;
        private int _thirdIndexBuffer;
        private string _targetTableBuffer;

        // Grid�ύX�t���O
        private bool _gridUpdFlg = true;

        // 2008.11.18 30413 ���� �_���폜�ς݃f�[�^�̕\���`�F�b�N�{�b�N�X��A�� >>>>>>START
        private bool _synchroLogDelFlg = true;
        // 2008.11.18 30413 ���� �_���폜�ς݃f�[�^�̕\���`�F�b�N�{�b�N�X��A�� <<<<<<END
        
        // �O���b�h�^�C�g��
        private const string MAIN_GRID_TITLE = "���Ӑ�";
        private const string SECOND_GRID_TITLE = "����";
        private const string THIRD_GRID_TITLE = "BL����";

        // Fream��View�pGrid���KEY��� (�w�b�_�̃^�C�g�����ƂȂ�܂�)TbsPartsCode
        private const string M_DELETEDATE = "�폜��";   // ADD 2008/03/25 �s��Ή�[12720]�F�u�폜�σf�[�^�̕\���v�͍ŏ�ʍ��ڂŐ���
        private const string M_CUSTOMERCODE = "���Ӑ�R�[�h";
        private const string M_CUSTOMERNAME = "���Ӑ旪��";
        private const string MAIN_TABLE = "CUSTOMERCODE_TABLE";

        private const string S_DELETEDATE = "�폜��";
        private const string S_PARTSPOSCODE = "���ʃR�[�h";
        private const string S_PARTSPOSNAME = "���ʖ�";
        private const string S_PARTSPOSCODE_GUID = "PARTSPOSCODE_GUID";
        private const string SECOND_TABLE = "PARTSPOSCODE_TABLE";

        private const string T_DELETEDATE = "�폜��";
        private const string T_TBSPARTCODE = "BL����";
        private const string T_TBSPARTNAME = "BL���ޖ�";
        private const string T_TBSPARTCODE_GUID = "TBSPARTCODE_GUID";
        private const string THIRD_TABLE = "TBSPARTCODE_TABLE";

        //�f�[�^�敪
        private const int DIVISION_USR = 0;
        private const int DIVISION_OFR = 1;

        // �ҏW���[�h
        private const string INSERT_MODE = "�V�K���[�h";
        private const string UPDATE_MODE = "�X�V���[�h";
        private const string DELETE_MODE = "�폜���[�h";
        private const string REFERENCE_MODE = "�Q�ƃ��[�h";

        // UI��Grid�\���p
        private const string MY_SCREEN_TBSPARTS_CODE = "BL����";
        private const string MY_SCREEN_TBSPARTS_NAME = "BL���ޖ�";
        private const string MY_SCREEN_ODER = "No.";
        private const string MY_SCREEN_GUID = "MY_SCREEN_GUID";
        private const string MY_SCREEN_TABLE = "MY_SCREEN_TABLE";
        private const string MY_SCREEN_ID = "ID";                               // ��ƁE���i���̂Ȃ�(�ҏW�s�A��\��)

        //UI�O���b�h�p�f�[�^�e�[�u��
        private DataTable _bindTable;

        // �A�Z���u�����
        private const string PG_ID = "PMKHN09050U";
        private const string PG_NAME = "���ʃ}�X�^";

        // Message�֘A��`
        private const string ERR_READ_MSG = "�ǂݍ��݂Ɏ��s���܂����B";
        private const string ERR_DPR_MSG = "���̃R�[�h�͊��Ɏg�p����Ă��܂��B";
        private const string ERR_RDEL_MSG = "�폜�Ɏ��s���܂����B";
        private const string ERR_UPDT_MSG = "�o�^�Ɏ��s���܂����B";
        private const string ERR_RVV_MSG = "�����Ɏ��s���܂����B";
        private const string ERR_800_MSG = "���ɑ��[�����X�V����Ă��܂�";
        private const string ERR_801_MSG = "���ɑ��[�����폜����Ă��܂�";
        private const string SDC_RDEL_MSG = "�}�X�^����폜����Ă��܂�";

        // 2008.10.31 30413 ���� ���Ӑ於�̂̋��ʐݒ��ǉ� >>>>>>START
        private const string CUSTOMER_SNM_COMMON = "���ʐݒ�";
        // 2008.10.31 30413 ���� ���Ӑ於�̂̋��ʐݒ��ǉ� <<<<<<END
        
        # endregion

        # region ��Constructor
        /// <summary>
        /// ���ʃR�[�h�}�X�^ �t�H�[���N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ʃR�[�h�}�X�^ �t�H�[���N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.17</br>
        /// </remarks>
        public PMKHN09050UA()
        {
            InitializeComponent();

            // �f�[�^�Z�b�g����\�z����
            DataSetColumnConstruction();

            // �v���p�e�B�����l�ݒ�
            this._canPrint = false;
            this._canLogicalDeleteDataExtraction = true;
            this._canClose = true;
            this._canNew = true;
            this._canDelete = true;
            this._defaultGridDisplayLayout = MGridDisplayLayout.Horizontal;
            
            this._mainGridTitle = MAIN_GRID_TITLE;
            this._secondGridTitle = SECOND_GRID_TITLE;
            this._thirdGridTitle = THIRD_GRID_TITLE;

            // �e��C���f�b�N�X������
            this._mainDataIndex = -1;
            this._secondDataIndex = -1;
            this._thirdDataIndex = -1;

            // �A�C�R���p
            this._mainGridIcon = null;
            this._secondGridIcon = null;
            this._thirdGridIcon = null;

            // Grid��IndexBuffer�i�[�p�ϐ�������
            this._mainIndexBuffer = -2;
            this._secondIndexBuffer = -2;
            this._thirdIndexBuffer = -2;
            this._targetTableBuffer = "";

            //�@��ƃR�[�h���擾����
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            // �ϐ�������
            this._partsPosCodeUAcs = new PartsPosCodeUAcs();
            this._blGoodsCdAcs = new BLGoodsCdAcs();
            
            this._partsPosCodeU = new PartsPosCodeU();
            this._partsPosCodeUCloneList = new PartsPosCodeU[1];

            this._totalCount = 0;
            this._mainGridTable = new Hashtable();
            this._secondGridTable = new Hashtable();
            this._thirdGridTable = new Hashtable();
            this._thirdGridCloneTable = new Hashtable();

            this._bindTable = new DataTable(MY_SCREEN_TABLE);

        }
        # endregion

        # region ��Dispose
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

        # region ��Main
        /// <summary>���C������</summary>
        /// <value></value>
        /// <remarks>�A�v���P�[�V�����̃��C�� �G���g�� �|�C���g�ł��B</remarks>
        [STAThread]
        static void Main()
        {
            System.Windows.Forms.Application.Run(new PMKHN09050UA());
        }
        # endregion

        # region Events
        /// <summary>��ʔ�\���C�x���g</summary>
        /// <remarks>��ʂ���\����ԂɂȂ����ۂɔ������܂��B</remarks>
        public event MasterMaintenanceThreeArrayTypeUnDisplayingEventHandler UnDisplaying;
        # endregion

        # region ��Properties
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

        /// <summary>�_���폜�f�[�^���o�\�ݒ�v���p�e�B</summary>
        /// <value>�_���폜�f�[�^�̒��o���\���ǂ����̐ݒ���擾���܂��B</value>
        public bool CanLogicalDeleteDataExtraction
        {
            get
            {
                return this._canLogicalDeleteDataExtraction;
            }
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

        /// <summary>�O���b�h�̃f�t�H���g�\���ʒu�v���p�e�B</summary>
        /// <value>�O���b�h�̃f�t�H���g�\���ʒu���擾���܂��B</value>
        public MGridDisplayLayout DefaultGridDisplayLayout
        {
            get { return this._defaultGridDisplayLayout; }
        }

        /// <summary>����Ώۃf�[�^�e�[�u�����̃v���p�e�B</summary>
        /// <value>�{���Ώۃf�[�^�̃e�[�u�����̂��擾�܂��͐ݒ肵�܂��B</value>
        public string TargetTableName
        {
            get { return this._targetTableName; }
            set { this._targetTableName = value; }
        }

        /// <summary>�_���폜�ς݃f�[�^�̕\���`�F�b�N�{�b�N�X�A���v���p�e�B</summary>
        /// <value>�_���폜�ς݃f�[�^�̕\���̃`�F�b�N�{�b�N�X�̘A���ۂ��擾���܂��B</value>
        public bool SynchroLogDelFlg
        {
            get { return this._synchroLogDelFlg; }
        }
        # endregion

        # region ��Public Methods

        /// <summary>
        /// �_���폜�f�[�^���o�\�ݒ胊�X�g�擾����
        /// </summary>
        /// <returns>�_���폜�f�[�^���o�\�ݒ胊�X�g</returns>
        /// <remarks>
        /// <br>Note       : �_���폜�f�[�^�̒��o���\���ǂ����̐ݒ��z��Ŏ擾���܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.17</br>
        /// </remarks>
        public bool[] GetCanLogicalDeleteDataExtractionList()
        {
            bool[] logicalDelete = { true, false, false };  // MOD 2008/03/25 �s��Ή�[12720]�F�u�폜�σf�[�^�̕\���v�͍ŏ�ʍ��ڂŐ��� { false, true, true }��{ true, false, false }
            return logicalDelete;
        }

        /// <summary>
        /// �O���b�h�^�C�g�����X�g�擾����
        /// </summary>
        /// <returns>�O���b�h�^�C�g�����X�g</returns>
        /// <remarks>
        /// <br>Note       : �O���b�h�̃^�C�g����z��Ŏ擾���܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.17</br>
        /// </remarks>
        public string[] GetGridTitleList()
        {
            string[] gridTitle = { _mainGridTitle, _secondGridTitle, _thirdGridTitle };
            return gridTitle;
        }

        /// <summary>
        /// �O���b�h�A�C�R�����X�g�擾����
        /// </summary>
        /// <returns>�O���b�h�A�C�R�����X�g</returns>
        /// <remarks>
        /// <br>Note       : �O���b�h�̃A�C�R����z��Ŏ擾���܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.17</br>
        /// </remarks>
        public Image[] GetGridIconList()
        {
            System.Drawing.Image[] gridIcon = { _mainGridIcon, _secondGridIcon, _thirdGridIcon };
            return gridIcon;
        }

        /// <summary>
        /// �O���b�h��̃T�C�Y�̎��������̃f�t�H���g�l���X�g�擾����
        /// </summary>
        /// <returns>�O���b�h��̃T�C�Y�̎��������̃f�t�H���g�l���X�g</returns>
        /// <remarks>
        /// <br>Note       : �O���b�h��̃T�C�Y�̎��������`�F�b�N�{�b�N�X�̃`�F�b�N�L���̃f�t�H���g�l��z��Ŏ擾���܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.17</br>
        /// </remarks>
        public bool[] GetDefaultAutoFillToGridColumnList()
        {
            bool[] defaultAutoFill = { true, true, true };
            return defaultAutoFill;
        }

        /// <summary>
        /// �f�[�^�e�[�u���̑I���f�[�^�C���f�b�N�X���X�g�ݒ菈��
        /// </summary>
        /// <param name="indexList">�f�[�^�e�[�u���̑I���f�[�^�C���f�b�N�X���X�g</param>
        /// <remarks>
        /// <br>Note       : �f�[�^�e�[�u���̑I���f�[�^�C���f�b�N�X���X�g��ݒ肵�܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.17</br>
        /// </remarks>
        public void SetDataIndexList(int[] indexList)
        {
            int[] intVal = indexList;

            this._mainDataIndex = intVal[0];
            this._secondDataIndex = intVal[1];
            this._thirdDataIndex = intVal[2];
        }

        /// <summary>
        /// �V�K�{�^���̗L���ݒ胊�X�g�擾����
        /// </summary>
        /// <returns>�V�K�{�^���̗L���ݒ胊�X�g</returns>
        /// <remarks>
        /// <br>Note       : �V�K�{�^���̗L���ݒ胊�X�g���擾���܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.17</br>
        /// </remarks>
        public bool[] GetNewButtonEnabledList()
        {
            bool[] newButtonEnabled = { true, true, false };
            return newButtonEnabled;
        }

        /// <summary>
        /// �C���{�^���̗L���ݒ胊�X�g�擾����
        /// </summary>
        /// <returns>�C���{�^���̗L���ݒ胊�X�g</returns>
        /// <remarks>
        /// <br>Note       : �C���{�^���̗L���ݒ胊�X�g���擾���܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.17</br>
        /// </remarks>
        public bool[] GetModifyButtonEnabledList()
        {
            bool[] modifyButtonEnabled = { false, true, false };
            return modifyButtonEnabled;
        }

        /// <summary>
        /// �폜�{�^���̗L���ݒ胊�X�g�擾����
        /// </summary>
        /// <returns>�폜�{�^���̗L���ݒ胊�X�g</returns>
        /// <remarks>
        /// <br>Note       : �폜�{�^���̗L���ݒ胊�X�g���擾���܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.17</br>
        /// </remarks>
        public bool[] GetDeleteButtonEnabledList()
        {
            bool[] deleteButtonEnabled = { false, true, false };
            return deleteButtonEnabled;
        }

        /// <summary>
        /// �o�C���h�f�[�^�Z�b�g�擾����
        /// </summary>
        /// <param name="bindDataSet">�O���b�h�\���p�f�[�^�Z�b�g</param>
        /// <param name="tableName">�e�[�u������</param>
        /// <remarks>
        /// <br>Note       : �O���b�h�Ƀo�C���h������f�[�^�Z�b�g���擾���܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.17</br>
        /// </remarks>
        /// 
        public void GetBindDataSet(ref DataSet bindDataSet, ref string[] tableName)
        {
            bindDataSet = this.Bind_DataSet;
            tableName[0] = MAIN_TABLE;
            tableName[1] = SECOND_TABLE;
            tableName[2] = THIRD_TABLE;
        }

        /// <summary>
        /// �f�[�^��������
        /// </summary>
        /// <param name="totalCount">�S�Y������</param>
        /// <param name="readCount">���o�Ώی���</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �擪����w�茏�����̃f�[�^���������A���o���ʂ�W�J����DataSet�ƑS�Y��������Ԃ��܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.18</br>
        /// </remarks>
        public int Search(ref int totalCount, int readCount)
        {
            int status = 0;

            ArrayList retList = null;

            // ADD 2009/03/25 �s��Ή�[12720]�F�u�폜�σf�[�^�̕\���v�͍ŏ�ʍ��ڂŐ��� ---------->>>>>
            // ���o�Ώی��������̏ꍇ�A�����I�ɏI��
            if (readCount < 0)
            {
                // DataSet�̏����N���A
                this.Bind_DataSet.Tables[MAIN_TABLE].Rows.Clear();
                this.Bind_DataSet.Tables[SECOND_TABLE].Rows.Clear();
                this.Bind_DataSet.Tables[THIRD_TABLE].Rows.Clear();
                return 0;
            }
            // ADD 2009/03/25 �s��Ή�[12720]�F�u�폜�σf�[�^�̕\���v�͍ŏ�ʍ��ڂŐ��� ----------<<<<<

            if (readCount == 0)
            {
                // ���o�Ώی�����0�̏ꍇ�͑S�����o�����s����
                status = this._partsPosCodeUAcs.SearchAll(out retList, this._enterpriseCode);

                this._totalCount = retList.Count;
            }

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        // �擾�������ʃR�[�h�N���X���f�[�^�Z�b�g�֓W�J����
                        int index = 0;

                        // ���ʐݒ���f�[�^�Z�b�g�W�J����
                        PartsPosCodeU commonPartsPosCodeU = new PartsPosCodeU();
                        PartsPosCodeUToDataSet(commonPartsPosCodeU.Clone(), ref index);

                        foreach (PartsPosCodeU partsPosCodeU in retList)
                        {
                            // ���ʃR�[�h�N���X�f�[�^�Z�b�g�W�J����
                            PartsPosCodeUToDataSet(partsPosCodeU.Clone(), ref index);
                        }

                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    {
                        // �f�[�^��0���̏ꍇ
                        int index = 0;
                        
                        // ���ʐݒ���f�[�^�Z�b�g�W�J����
                        PartsPosCodeU partsPosCodeU = new PartsPosCodeU();
                        PartsPosCodeUToDataSet(partsPosCodeU.Clone(), ref index);

                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

                        break;
                    }
                default:
                    {
                        // �T�[�`���� ���ʃR�[�h�}�X�^�ǂݍ��ݎ��s
                        TMsgDisp.Show(
                            this, 									    // �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_STOP, 			    // �G���[���x��
                            PG_ID,      							    // �A�Z���u���h�c�܂��̓N���X�h�c
                            PG_NAME,	        					    // �v���O��������
                            "Search", 								    // ��������
                            TMsgDisp.OPE_GET, 						    // �I�y���[�V����
                            "���ʃR�[�h���̓ǂݍ��݂Ɏ��s���܂����B", 	// �\�����郁�b�Z�[�W
                            status, 								    // �X�e�[�^�X�l
                            this._partsPosCodeUAcs,	 				    // �G���[�����������I�u�W�F�N�g
                            MessageBoxButtons.OK, 					    // �\������{�^��
                            MessageBoxDefaultButton.Button1);		    // �����\���{�^��

                        break;
                    }
            }

            // �߂�l�Z�b�g
            totalCount = this._totalCount;

            // �폜�����Đݒ�
            SetDeleteDateOfFirstTable();    // ADD 2008/03/25 �s��Ή�[12720]�F�u�폜�σf�[�^�̕\���v�͍ŏ�ʍ��ڂŐ���

            return status;
        }

        /// <summary>
        /// �l�N�X�g�f�[�^��������
        /// </summary>
        /// <param name="readCount">���o�Ώی���</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �w�肵���������̃l�N�X�g�f�[�^���������܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.17</br>
        /// </remarks>
        public int SearchNext(int readCount)
        {
            // ������
            return 9;
        }

        /// <summary>
        /// �f�[�^��������(�Q�A���C��)
        /// </summary>
        /// <param name="totalCount">�S�Y������</param>
        /// <param name="readCount">���o�Ώی���</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �K�C�h�敪��DB�������s�킸DataSet�ɌŒ����ݒ肷��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.10.20</br>
        /// </remarks>
        public int SecondDataSearch(ref int totalCount, int readCount)
        {
            int status = 0;

            ArrayList retList = null;

            int customerCode = int.Parse((string)this.Bind_DataSet.Tables[MAIN_TABLE].Rows[this._mainDataIndex][M_CUSTOMERCODE]);

            // ���ݕێ����Ă���Z�J���hGrid�f�[�^���N���A����
            this.Bind_DataSet.Tables[SECOND_TABLE].Rows.Clear();
            this._secondGridTable.Clear();
            // ���ݕێ����Ă���T�[�hGrid�f�[�^���N���A����
            this.Bind_DataSet.Tables[THIRD_TABLE].Rows.Clear();
            this._thirdGridTable.Clear();

            // ADD 2009/03/25 �s��Ή�[12720]�F�u�폜�σf�[�^�̕\���v�͍ŏ�ʍ��ڂŐ��� ---------->>>>>
            // ���o�Ώی��������̏ꍇ�A�����I�ɏI��
            if (readCount < 0) return 0;
            // ADD 2009/03/25 �s��Ή�[12720]�F�u�폜�σf�[�^�̕\���v�͍ŏ�ʍ��ڂŐ��� ----------<<<<<

            if (readCount == 0)
            {
                // ���o�Ώی�����0�̏ꍇ�͑S�����o�����s����
                status = this._partsPosCodeUAcs.SearchSelect(customerCode, 0, out retList, this._enterpriseCode);

                this._totalCount = retList.Count;
            }

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        // �擾�������ʃR�[�h�N���X���f�[�^�Z�b�g�֓W�J����
                        int index = 0;

                        foreach (PartsPosCodeU partsPosCodeU in retList)
                        {
                            // ���ʃR�[�h�N���X�f�[�^�Z�b�g�W�J����
                            PartsPosCodeUToSecondDataSet(customerCode, partsPosCodeU.Clone(), ref index);
                        }

                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                        break;
                    }
                default:
                    {
                        // �T�[�`���� ���ʃR�[�h�}�X�^�ǂݍ��ݎ��s
                        TMsgDisp.Show(
                            this, 									    // �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_STOP, 			    // �G���[���x��
                            PG_ID,      							    // �A�Z���u���h�c�܂��̓N���X�h�c
                            PG_NAME,	        					    // �v���O��������
                            "SecondDataSearch", 						// ��������
                            TMsgDisp.OPE_GET, 						    // �I�y���[�V����
                            "���ʃR�[�h���̓ǂݍ��݂Ɏ��s���܂����B", 	// �\�����郁�b�Z�[�W
                            status, 								    // �X�e�[�^�X�l
                            this._partsPosCodeUAcs,	 				    // �G���[�����������I�u�W�F�N�g
                            MessageBoxButtons.OK, 					    // �\������{�^��
                            MessageBoxDefaultButton.Button1);		    // �����\���{�^��

                        break;
                    }
            }

            // �߂�l�Z�b�g
            totalCount = this._totalCount;

            return status;
        }

        /// <summary>
        /// �l�N�X�g�f�[�^��������(�Q�A���C��)
        /// </summary>
        /// <param name="readCount">���o�Ώی���</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note		: ArrayType�ł͖�����</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.10.20</br>
        /// </remarks>
        public int SecondDataSearchNext(int readCount)
        {
            // ������
            return 9;
        }

        /// <summary>
        /// �f�[�^��������(�R�A���C��)
        /// </summary>
        /// <param name="totalCount">�S�Y������</param>
        /// <param name="readCount">���o�Ώی���</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �擪����w�茏�����̃f�[�^���������A���o���ʂ�W�J����DataSet�ƑS�Y��������Ԃ��܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.10.20</br>
        /// </remarks>
        public int ThirdDataSearch(ref int totalCount, int readCount)
        {
            int status = 0;
            ArrayList retList = null;

            // ���ݕێ����Ă���T�[�hGrid�f�[�^���N���A����
            this.Bind_DataSet.Tables[THIRD_TABLE].Rows.Clear();
            this._thirdGridTable.Clear();

            // ADD 2009/03/25 �s��Ή�[12720]�F�u�폜�σf�[�^�̕\���v�͍ŏ�ʍ��ڂŐ��� ---------->>>>>
            // ���o�Ώی��������̏ꍇ�A�����I�ɏI��
            if (readCount < 0) return 0;
            // ADD 2009/03/25 �s��Ή�[12720]�F�u�폜�σf�[�^�̕\���v�͍ŏ�ʍ��ڂŐ��� ----------<<<<<

            // Form �Z�J���hGrid�̏����擾
            string guid = (string)this.Bind_DataSet.Tables[SECOND_TABLE].Rows[this._secondDataIndex][S_PARTSPOSCODE_GUID];
            PartsPosCodeU secondPartsPosCodeU = ((PartsPosCodeU)this._secondGridTable[guid]).Clone();
            int customerCode = secondPartsPosCodeU.CustomerCode;
            int partsPosCode = secondPartsPosCodeU.SearchPartsPosCode;

            if (readCount == 0)
            {
                // ���o�Ώی�����0�̏ꍇ�͑S�����o�����s����
                status = this._partsPosCodeUAcs.SearchSelect(customerCode, partsPosCode, out retList, this._enterpriseCode);

                this._totalCount = retList.Count;
            }

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                    {
                        // �擾�������ʃR�[�h�N���X���f�[�^�Z�b�g�֓W�J����
                        int index = 0;
                        SortedList wkSort = new SortedList();

                        foreach (PartsPosCodeU wkPartsPosCodeU in retList)
                        {
                            // ���Ӑ�+�������ʃR�[�h+�������ʕ\������+BL�R�[�h
                            string key = wkPartsPosCodeU.CustomerCode.ToString("d08") + wkPartsPosCodeU.SearchPartsPosCode.ToString("d02")
                                       + wkPartsPosCodeU.PosDispOrder.ToString("d02") + wkPartsPosCodeU.TbsPartsCode.ToString("d05");
                            // �擾�������ʃR�[�h�N���X���\�[�g
                            wkSort.Add(key, wkPartsPosCodeU);
                        }
                        
                        for (int i = 0; i < wkSort.Count; i++)
                        {
                            // ���ʃR�[�h�N���X�f�[�^�Z�b�g�W�J����
                            PartsPosCodeUToThirdDataSet(customerCode, (PartsPosCodeU)wkSort.GetByIndex(i), ref index);
                        }

                        break;
                    }
                default:
                    {
                        // �T�[�`���� ���ʃR�[�h�}�X�^�ǂݍ��ݎ��s
                        TMsgDisp.Show(
                            this, 								        // �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_STOP, 		        // �G���[���x��
                            PG_ID, 						                // �A�Z���u���h�c�܂��̓N���X�h�c
                            PG_NAME,        					        // �v���O��������
                            "ThirdDataSearch", 				            // ��������
                            TMsgDisp.OPE_GET, 					        // �I�y���[�V����
                            "���ʃR�[�h���̓ǂݍ��݂Ɏ��s���܂����B",	// �\�����郁�b�Z�[�W
                            status, 							        // �X�e�[�^�X�l
                            this._partsPosCodeUAcs, 				        // �G���[�����������I�u�W�F�N�g
                            MessageBoxButtons.OK, 				        // �\������{�^��
                            MessageBoxDefaultButton.Button1);	        // �����\���{�^��

                        break;
                    }
            }

            totalCount = this._totalCount;

            return status;
        }

        /// <summary>
        /// �l�N�X�g�f�[�^��������(�R�A���C��)
        /// </summary>
        /// <param name="readCount">���o�Ώی���</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ArrayType�ł͖�����</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.30</br>
        /// </remarks>
        public int ThirdDataSearchNext(int readCount)
        {
            // ������
            return 9;
        }

        /// <summary>
        /// �f�[�^�폜����
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �I�𒆂̃f�[�^���폜���܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.20</br>
        /// </remarks>
        public int Delete()
        {
            int status = 0;
            
            ArrayList logDelList = new ArrayList();
            PartsPosCodeU partsPosCodeU = new PartsPosCodeU();

            // Form ���C��Grid�̏����擾
            string guid = (string)this.Bind_DataSet.Tables[SECOND_TABLE].Rows[this._secondDataIndex][S_PARTSPOSCODE_GUID];
            partsPosCodeU = ((PartsPosCodeU)this._secondGridTable[guid]).Clone();
            logDelList.Add(partsPosCodeU);

            if (partsPosCodeU.Division == DIVISION_OFR)
            {
                TMsgDisp.Show(this,
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,
                    PG_ID,
                    "���̃��R�[�h�͒񋟃f�[�^�̂��ߍ폜�ł��܂���",
                    status,
                    MessageBoxButtons.OK);
                this.Hide();

                return -2;
            }

            // Form �ڍ�Grid�̏����擾
            int maxRow = this.Bind_DataSet.Tables[THIRD_TABLE].Rows.Count;
            for (int i = 0; i < maxRow; i++)
            {
                string detailGuid = (string)this.Bind_DataSet.Tables[THIRD_TABLE].Rows[i][T_TBSPARTCODE_GUID];
                partsPosCodeU = ((PartsPosCodeU)this._thirdGridTable[detailGuid]).Clone();
                logDelList.Add(partsPosCodeU);
            }

            status = this._partsPosCodeUAcs.LogicalDelete(ref logDelList);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        // �r������
                        ExclusiveTransaction(status, TMsgDisp.OPE_DELETE, this._partsPosCodeUAcs);
                        return status;
                    }
                case -2:
                    {
                        //���Ɛݒ�Ŏg�p��
                        TMsgDisp.Show(this,
                            emErrorLevel.ERR_LEVEL_EXCLAMATION,
                            PG_ID,
                            "���̃��R�[�h�͎��Ɛݒ�Ŏg�p����Ă��邽�ߍ폜�ł��܂���",
                            status,
                            MessageBoxButtons.OK);
                        this.Hide();

                        return status;
                    }
                default:
                    {
                        // �_���폜�����̎��s
                        TMsgDisp.Show(
                            this,								// �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_STOPDISP,	// �G���[���x��
                            PG_ID,	        					// �A�Z���u���h�c�܂��̓N���X�h�c
                            PG_NAME,							// �v���O��������
                            "Delete",							// ��������
                            TMsgDisp.OPE_HIDE,					// �I�y���[�V����
                            ERR_RDEL_MSG,						// �\�����郁�b�Z�[�W 
                            status,								// �X�e�[�^�X�l
                            this._partsPosCodeUAcs,				// �G���[�����������I�u�W�F�N�g
                            MessageBoxButtons.OK,				// �\������{�^��
                            MessageBoxDefaultButton.Button1);	// �����\���{�^��

                        return status;
                    }
            }

            // �f�[�^�Z�b�g�W�J����
            int index = 0;
            int logDelCnt = 0;         // 0�̓��C��Grid���A0�ȊO�͏ڍ�Grid���

            int customerCode = int.Parse((string)this.Bind_DataSet.Tables[MAIN_TABLE].Rows[this._mainDataIndex][M_CUSTOMERCODE]);
                    
            // �_���폜���R�[�h��DataSet�ɔ��f
            foreach (PartsPosCodeU wkPartsPosCodeU in logDelList)
            {
                if (logDelCnt == 0)
                {
                    // �Z�J���hGrid
                    index = this._secondDataIndex;
                    PartsPosCodeUToSecondDataSet(customerCode, wkPartsPosCodeU, ref index);
                    logDelCnt++;
                }
                else
                {
                    // �T�[�hGrid
                    index = wkPartsPosCodeU.PosDispOrder - 1;
                    PartsPosCodeUToThirdDataSet(customerCode, wkPartsPosCodeU, ref index);

                    // �Č���
                    int totalCount = 0;
                    ThirdDataSearch(ref totalCount, 0); // ADD 2009/03/25 �s��Ή�[12720]�F�u�폜�σf�[�^�̕\���v�͍ŏ�ʍ��ڂŐ���
                }
            }

            // �폜��Ƀt�@�[�X�g�e�[�u���̍폜�����Đݒ�
            SetDeleteDateOfFirstTable();    // ADD 2009/03/25 �s��Ή�[12720]�F�u�폜�σf�[�^�̕\���v�͍ŏ�ʍ��ڂŐ���

            return status;
        }

        /// <summary>
        /// �������
        /// </summary>
        /// <param></param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ����@�\�����ׁ̈A�������B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.17</br>
        /// </remarks>
        public int Print()
        {
            // ����@�\�����̈ז�����
            return 0;
        }

        /// <summary>
        /// �O���b�h��O�Ϗ��擾����
        /// </summary>
        /// <param name="appearanceTable">�O���b�h�O��</param>
        /// <returns>�O���b�h��O�Ϗ��i�[Hashtable</returns>
        /// <remarks>
        /// <br>Note       : �e��̊O����ݒ肷��N���X���i�[����Hashtable���擾���܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.17</br>
        /// </remarks>
        public void GetAppearanceTable(out Hashtable[] appearanceTable)
        {
            // ���C���O���b�h
            Hashtable main = new Hashtable();

            main.Add(M_DELETEDATE, new GridColAppearance(MGridColDispType.DeletionDataBoth, ContentAlignment.MiddleLeft, "", Color.Red));   // ADD 2008/03/25 �s��Ή�[12720]�F�u�폜�σf�[�^�̕\���v�͍ŏ�ʍ��ڂŐ���
            main.Add(M_CUSTOMERCODE, new GridColAppearance(MGridColDispType.ListOnly, ContentAlignment.MiddleRight, "", Color.Black));
            main.Add(M_CUSTOMERNAME, new GridColAppearance(MGridColDispType.ListOnly, ContentAlignment.MiddleLeft, "", Color.Black));
            

            // �Z�J���h�O���b�h
            Hashtable second = new Hashtable();

            // �폜��
            second.Add(S_DELETEDATE, new GridColAppearance(MGridColDispType.DeletionDataBoth, ContentAlignment.MiddleLeft, "", Color.Red));
            // ���ʃR�[�h
            second.Add(S_PARTSPOSCODE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            // ���ʖ���
            second.Add(S_PARTSPOSNAME, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // ���ʏ��GUID
            second.Add(S_PARTSPOSCODE_GUID, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));


            // �T�[�h�O���b�h
            Hashtable third = new Hashtable();

            // �폜��
            third.Add(T_DELETEDATE, new GridColAppearance(MGridColDispType.DeletionDataBoth, ContentAlignment.MiddleLeft, "", Color.Red));
            // BL����
            third.Add(T_TBSPARTCODE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            // BL���ޖ�
            third.Add(T_TBSPARTNAME, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // BL���GUID
            third.Add(T_TBSPARTCODE_GUID, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));

            appearanceTable = new Hashtable[3];
            appearanceTable[0] = main;
            appearanceTable[1] = second;
            appearanceTable[2] = third;
        }

        # endregion

        # region ��Control Events

        /// <summary>
        /// ��ʃ��[�h�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�f�[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@  : ���[�U�[���t�H�[����ǂݍ��ނƂ��ɔ������܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.17</br>
        /// </remarks>
        private void PMKHN09050UA_Load(object sender, System.EventArgs e)
        {
            // �A�C�R�����\�[�X�Ǘ��N���X���g�p���āA�A�C�R����\������
            ImageList imageList24 = IconResourceManagement.ImageList24;
            ImageList imageList16 = IconResourceManagement.ImageList16;

            // �K�C�h�{�^���C���[�W�ݒ�
            CustomerCd_GuideBtn.ImageList = IconResourceManagement.ImageList16;
            CustomerCd_GuideBtn.Appearance.Image = Size16_Index.STAR1;

            this.Ok_Button.ImageList = imageList24;
            this.Cancel_Button.ImageList = imageList24;
            this.Revive_Button.ImageList = imageList24;
            this.Delete_Button.ImageList = imageList24;

            this.Ok_Button.Appearance.Image = Size24_Index.SAVE;
            this.Cancel_Button.Appearance.Image = Size24_Index.CLOSE;
            this.Revive_Button.Appearance.Image = Size24_Index.REVIVAL;
            this.Delete_Button.Appearance.Image = Size24_Index.DELETE;

            // --- ADD 2009/03/23 �c�Č�No.14�Ή�------------------------------------------------------>>>>>
            this.Renewal_Button.ImageList = imageList16;
            this.Renewal_Button.Appearance.Image = Size16_Index.RENEWAL;
            // --- ADD 2009/03/23 �c�Č�No.14�Ή�------------------------------------------------------<<<<<

            this.Guid_Button.ImageList = imageList16;
            this.DeleteRow_Button.ImageList = imageList16;

            this.Guid_Button.Appearance.Image = Size16_Index.GUIDE;
            this.DeleteRow_Button.Appearance.Image = Size16_Index.DELETE;

            // ��ʏ����ݒ菈��
            ScreenInitialSetting();

        }

        /// <summary>
        /// ��ʃN���[�Y�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�f�[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@  : ���[�U�[���t�H�[������悤�Ƃ������ɔ������܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.17</br>
        /// </remarks>
        private void PMKHN09050UA_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // Grid��IndexBuffer�i�[�p�ϐ�������
            this._mainIndexBuffer = -2;
            this._secondIndexBuffer = -2;
            this._thirdIndexBuffer = -2;
            this._targetTableBuffer = "";

            // CanClose�v���p�e�B��false�̏ꍇ�́A�N���[�Y�������L�����Z������
            // �t�H�[�����\��������B
            //�i�t�H�[���́u�~�v���N���b�N���ꂽ�ꍇ�̑Ή��ł��B�j
            if (CanClose == false)
            {
                e.Cancel = true;
                this.Hide();
                return;
            }
        }

        /// <summary>
        /// ��ʕ\����ԕύX�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�f�[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@  : ��ʂ̕\����Ԃ��ς�����Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.17</br>
        /// </remarks>
        private void PMKHN09050UA_VisibleChanged(object sender, System.EventArgs e)
        {
            // �������g����\���ɂȂ����ꍇ�͈ȉ��̏������L�����Z������B
            if (this.Visible == false)
            {
                // ���C���t���[���A�N�e�B�u��
                this.Owner.Activate();
                return;
            }

            if (this._targetTableName == THIRD_TABLE)
            {
                if (this._thirdIndexBuffer == this._thirdDataIndex)
                {
                    return;
                }
            }
            else if (this._targetTableName == SECOND_TABLE)
            {
                if (this._secondIndexBuffer == this._secondDataIndex)
                {
                    return;
                }
            }
            else
            {
                if (this._mainIndexBuffer == this._mainDataIndex)
                {
                    return;
                }
            }

            // ��ʏ���������
            ScreenClear();

            // ��ʕ\���^�C�}�[ON
            Initial_Timer.Enabled = true;
        }

        /// <summary>
        /// �ۑ��{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�f�[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@  : �ۑ��{�^���R���g���[�����N���b�N���ꂽ���ɔ������܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.18</br>
        /// </remarks>
        private void Ok_Button_Click(object sender, System.EventArgs e)
        {
            this.Ok_Button.Focus();
            if (!SaveProc())
            {
                return;
            }

            // ��ʔ�\���C�x���g
            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                UnDisplaying(this, me);
            }

            this.DialogResult = DialogResult.OK;

            // Grid��IndexBuffer�i�[�p�ϐ�������
            this._mainIndexBuffer = -2;
            this._secondIndexBuffer = -2;
            this._targetTableBuffer = "";

            // CanClose�v���p�e�B��false�̏ꍇ�́A�N���[�Y�������L�����Z������
            // �t�H�[�����\��������B
            if (CanClose == true)
            {
                this.Close();
            }
            else
            {
                this.Hide();
            }
        }

        /// <summary>
        /// ����{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�f�[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@  : ����{�^���R���g���[�����N���b�N���ꂽ���ɔ������܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.23</br>
        /// </remarks>
        private void Cancel_Button_Click(object sender, System.EventArgs e)
        {
            // �X�V�L���t���O
            bool isUpdate = false;

            // UI��ʂ�Grid�s�����擾
            int maxRow = this._bindTable.Rows.Count;

            // 2008.11.19 30413 ���� �ҏW���̕ۑ��m�F�������C�� >>>>>>START
            ////�ۑ��m�F
            //PartsPosCodeU[] comparePartsPosCodeU = new PartsPosCodeU[maxRow + 1];
            //if (maxRow > 0)
            //{
            //    // UI��ʂ�Grid��1���ȏ�o�^����Ă��邱��
            //    if (this._partsPosCodeUCloneList.Length == comparePartsPosCodeU.Length)
            //    {
            //        // UI��ʂ�Grid�s���������ꍇ�͍X�V�f�[�^�̗L�����m�F
            //        ArrayList updateList = new ArrayList();
            //        ArrayList deleteList = new ArrayList();

            //        UpdateCompare(out updateList, out deleteList);

            //        if ((updateList.Count != 0) || (deleteList.Count != 0))
            //        {
            //            // �X�V�^�폜���R�[�h���L��
            //            isUpdate = true;
            //        }
            //    }
            //    else
            //    {
            //        // �X�V�O���Grid�s�����s��v�̏ꍇ�͍X�V
            //        isUpdate = true;
            //    }
            //}

            if (this._secondDataIndex >= 0)
            {
                // �X�V���[�h
                // �ۑ��m�F
                if (maxRow > 0)
                {
                    // UI��ʂ�Grid��1���ȏ�o�^����Ă��邱��
                    ArrayList updateList = new ArrayList();
                    ArrayList deleteList = new ArrayList();

                    // �X�V�f�[�^�̗L�����m�F
                    UpdateCompare(out updateList, out deleteList);

                    if ((updateList.Count != 0) || (deleteList.Count != 0))
                    {
                        // �X�V�^�폜���R�[�h���L��
                        isUpdate = true;
                    }                    
                }
            }
            else
            {
                // �V�K���[�h
                ArrayList partsList = new ArrayList();
                // ��ʏ����擾
                this.DispToPartsPosCodeU(ref partsList);
                if (partsList.Count > 1)
                {
                    // BL�R�[�h�̐ݒ�L
                    isUpdate = true;
                }
                else if (partsList.Count == 1)
                {
                    // ���ʂ̐ݒ�̂�
                    PartsPosCodeU compPartsPosCode = new PartsPosCodeU();
                    ArrayList compRet = compPartsPosCode.Compare((PartsPosCodeU)partsList[0]);
                    if (compRet.Count > 1)
                    {
                        // ��ƃR�[�h�ȊO�̐ݒ荀�ڗL
                        isUpdate = true;
                    }
                }
            }
            // 2008.11.19 30413 ���� �ҏW���̕ۑ��m�F�������C�� <<<<<<END
            
            if (isUpdate)
            {
                // ��ʏ�񂪕ύX����Ă����ꍇ�́A�ۑ��m�F���b�Z�[�W��\������
                DialogResult res = TMsgDisp.Show(
                    this, 								// �e�E�B���h�E�t�H�[��
                    emErrorLevel.ERR_LEVEL_SAVECONFIRM, // �G���[���x��
                    PG_ID,       						// �A�Z���u���h�c�܂��̓N���X�h�c
                    null, 								// �\�����郁�b�Z�[�W
                    0, 									// �X�e�[�^�X�l
                    MessageBoxButtons.YesNoCancel);	// �\������{�^��

                switch (res)
                {
                    case DialogResult.Yes:
                        {
                            if (!SaveProc())
                            {
                                return;
                            }
                            this.DialogResult = DialogResult.OK;
                            break;
                        }
                    case DialogResult.No:
                        {
                            this.DialogResult = DialogResult.Cancel;
                            break;
                        }
                    default:
                        {
                            this.Cancel_Button.Focus();
                            return;
                        }
                }
            }

            // ��ʔ�\���C�x���g
            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult);
                UnDisplaying(this, me);
            }

            this.DialogResult = DialogResult.Cancel;

            // Grid��IndexBuffer�i�[�p�ϐ�������
            this._mainIndexBuffer = -2;
            this._secondIndexBuffer = -2;
            this._targetTableBuffer = "";

            // CanClose�v���p�e�B��false�̏ꍇ�́A�N���[�Y�������L�����Z������
            // �t�H�[�����\��������B
            if (CanClose == true)
            {
                this.Close();
            }
            else
            {
                this.Hide();
            }
        }

        /// <summary>
        /// Control.Click �C�x���g(Delete_Button)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : ���S�폜�{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.21</br>
        /// </remarks>
        private void Delete_Button_Click(object sender, System.EventArgs e)
        {
            int status = 0;
            DialogResult result = TMsgDisp.Show(
                this,													// �e�E�B���h�E�t�H�[��
                emErrorLevel.ERR_LEVEL_QUESTION,						// �G���[���x��
                PG_ID,					        						// �A�Z���u���h�c�܂��̓N���X�h�c
                "�f�[�^���폜���܂��B" + "\r\n" + "��낵���ł����H",	// �\�����郁�b�Z�[�W 
                0,														// �X�e�[�^�X�l
                MessageBoxButtons.OKCancel,								// �\������{�^��
                MessageBoxDefaultButton.Button2);						// �����\���{�^��


            if (result == DialogResult.OK)
            {
                ArrayList deleteList = new ArrayList();
                PartsPosCodeU partsPosCodeU = new PartsPosCodeU();

                // Form ���C��Grid�̏����擾
                string guid = (string)this.Bind_DataSet.Tables[SECOND_TABLE].Rows[this._secondDataIndex][S_PARTSPOSCODE_GUID];
                partsPosCodeU = ((PartsPosCodeU)this._secondGridTable[guid]).Clone();
                deleteList.Add(partsPosCodeU);

                // Form �ڍ�Grid�̏����擾
                int maxRow = this.Bind_DataSet.Tables[THIRD_TABLE].Rows.Count;
                for (int i = 0; i < maxRow; i++)
                {
                    string detailGuid = (string)this.Bind_DataSet.Tables[THIRD_TABLE].Rows[i][T_TBSPARTCODE_GUID];
                    partsPosCodeU = ((PartsPosCodeU)this._thirdGridTable[detailGuid]).Clone();
                    deleteList.Add(partsPosCodeU);
                }

                status = this._partsPosCodeUAcs.Delete(deleteList);
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        {
                            // Form ���C��Grid�Əڍ�Grid��DataSet���폜
                            this.Bind_DataSet.Tables[SECOND_TABLE].Rows[this._secondDataIndex].Delete();
                            this.Bind_DataSet.Tables[THIRD_TABLE].Rows.Clear();

                            // ���C��Grid�Əڍ�Grid�̃e�[�u�����폜
                            int delCnt = 0;
                            foreach (PartsPosCodeU wkPartsPosCodeU in deleteList)
                            {
                                if (delCnt == 0)
                                {
                                    // �Z�J���hGrid�̃e�[�u��
                                    this._secondGridTable.Remove(CreateHashKeySecond(wkPartsPosCodeU));
                                    delCnt++;
                                }
                                else
                                {
                                    // �T�[�hGrid�̃e�[�u��
                                    this._thirdGridTable.Remove(CreateHashKeyThird(wkPartsPosCodeU));
                                }
                            }                            
                            break;
                        }
                    case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                        {
                            ExclusiveTransaction(status, TMsgDisp.OPE_DELETE, this._partsPosCodeUAcs);

                            if (UnDisplaying != null)
                            {
                                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                                UnDisplaying(this, me);
                            }

                            this.DialogResult = DialogResult.Cancel;
                            this._mainIndexBuffer = -2;
                            this._secondIndexBuffer = -2;
                            
                            if (CanClose == true)
                            {
                                this.Close();
                            }
                            else
                            {
                                this.Hide();
                            }

                            return;
                        }
                    default:
                        {
                            TMsgDisp.Show(
                                this,								  // �e�E�B���h�E�t�H�[��
                                emErrorLevel.ERR_LEVEL_STOPDISP,	  // �G���[���x��
                                PG_ID,      						  // �A�Z���u���h�c�܂��̓N���X�h�c
                                PG_NAME,							  // �v���O��������
                                "Delete_Button_Click",				  // ��������
                                TMsgDisp.OPE_DELETE,				  // �I�y���[�V����
                                ERR_RDEL_MSG,						  // �\�����郁�b�Z�[�W 
                                status,								  // �X�e�[�^�X�l
                                this._partsPosCodeUAcs,					  // �G���[�����������I�u�W�F�N�g
                                MessageBoxButtons.OK,				  // �\������{�^��
                                MessageBoxDefaultButton.Button1);	  // �����\���{�^��

                            if (UnDisplaying != null)
                            {
                                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                                UnDisplaying(this, me);
                            }

                            this.DialogResult = DialogResult.Cancel;
                            this._mainIndexBuffer = -2;
                            this._secondIndexBuffer = -2;
                            
                            if (CanClose == true)
                            {
                                this.Close();
                            }
                            else
                            {
                                this.Hide();
                            }

                            return;
                        }
                }
            }
            else
            {
                this.Delete_Button.Focus();
                return;
            }

            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                UnDisplaying(this, me);
            }

            this.DialogResult = DialogResult.OK;
            this._mainIndexBuffer = -2;
            this._secondIndexBuffer = -2;
            
            if (CanClose == true)
            {
                this.Close();
            }
            else
            {
                this.Hide();
            }
        }

        /// <summary>
        /// Control.Click �C�x���g(Revive_Button)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note �@�@  : �����{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.21</br>
        /// </remarks>
        private void Revive_Button_Click(object sender, System.EventArgs e)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            
            ArrayList reviveList = new ArrayList();
            PartsPosCodeU partsPosCodeU = new PartsPosCodeU();

            // Form ���C��Grid�̏����擾
            string guid = (string)this.Bind_DataSet.Tables[SECOND_TABLE].Rows[this._secondDataIndex][S_PARTSPOSCODE_GUID];
            partsPosCodeU = ((PartsPosCodeU)this._secondGridTable[guid]).Clone();
            reviveList.Add(partsPosCodeU);

            // Form �ڍ�Grid�̏����擾
            int maxRow = this.Bind_DataSet.Tables[THIRD_TABLE].Rows.Count;
            for (int i = 0; i < maxRow; i++)
            {
                string detailGuid = (string)this.Bind_DataSet.Tables[THIRD_TABLE].Rows[i][T_TBSPARTCODE_GUID];
                partsPosCodeU = ((PartsPosCodeU)this._thirdGridTable[detailGuid]).Clone();
                reviveList.Add(partsPosCodeU);
            }

            status = this._partsPosCodeUAcs.Revival(ref reviveList);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        ExclusiveTransaction(status, TMsgDisp.OPE_UPDATE, this._partsPosCodeUAcs);

                        if (UnDisplaying != null)
                        {
                            MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                            UnDisplaying(this, me);
                        }

                        this.DialogResult = DialogResult.Cancel;
                        this._mainIndexBuffer = -2;
                        this._secondIndexBuffer = -2;
                        
                        if (CanClose == true)
                        {
                            this.Close();
                        }
                        else
                        {
                            this.Hide();
                        }

                        return;
                    }
                default:
                    {
                        TMsgDisp.Show(
                            this,								  // �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_STOPDISP,	  // �G���[���x��
                            PG_ID,		        				  // �A�Z���u���h�c�܂��̓N���X�h�c
                            PG_NAME,							  // �v���O��������
                            "Revive_Button_Click",				  // ��������
                            TMsgDisp.OPE_UPDATE,				  // �I�y���[�V����
                            ERR_RVV_MSG,						  // �\�����郁�b�Z�[�W 
                            status,								  // �X�e�[�^�X�l
                            this._partsPosCodeUAcs,				  // �G���[�����������I�u�W�F�N�g
                            MessageBoxButtons.OK,				  // �\������{�^��
                            MessageBoxDefaultButton.Button1);	  // �����\���{�^��

                        if (UnDisplaying != null)
                        {
                            MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                            UnDisplaying(this, me);
                        }

                        this.DialogResult = DialogResult.Cancel;
                        this._mainIndexBuffer = -2;
                        this._secondIndexBuffer = -2;
                        
                        if (CanClose == true)
                        {
                            this.Close();
                        }
                        else
                        {
                            this.Hide();
                        }

                        return;
                    }
            }

            // DataSet�W�J����
            int index = 0;
            int reviveCnt = 0;         // 0�̓��C��Grid���A0�ȊO�͏ڍ�Grid���

            int customerCode = int.Parse((string)this.Bind_DataSet.Tables[MAIN_TABLE].Rows[this._mainDataIndex][M_CUSTOMERCODE]);
                    
            // �_���폜���R�[�h��DataSet�ɔ��f

            // �ĕ`����s���̂ŁA���ݕێ����Ă���T�[�hGrid�f�[�^���N���A����
            this.Bind_DataSet.Tables[THIRD_TABLE].Rows.Clear();
            this._thirdGridTable.Clear();

            foreach (PartsPosCodeU wkPartsPosCodeU in reviveList)
            {
                if (reviveCnt == 0)
                {
                    // �Z�J���hGrid
                    index = this._secondDataIndex;
                    PartsPosCodeUToSecondDataSet(customerCode, wkPartsPosCodeU, ref index);
                    reviveCnt++;
                }
                else
                {
                    // �T�[�hGrid
                    index = wkPartsPosCodeU.PosDispOrder - 1;
                    PartsPosCodeUToThirdDataSet(customerCode, wkPartsPosCodeU, ref index);
                }
            }

            // ������Ƀt�@�[�X�g�e�[�u���̍폜�����Đݒ�
            SetDeleteDateOfFirstTable();    // ADD 2009/03/25 �s��Ή�[12720]�F�u�폜�σf�[�^�̕\���v�͍ŏ�ʍ��ڂŐ���

            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                UnDisplaying(this, me);
            }

            this.DialogResult = DialogResult.OK;
            this._mainIndexBuffer = -2;
            this._secondIndexBuffer = -2;
            
            if (CanClose == true)
            {
                this.Close();
            }
            else
            {
                this.Hide();
            }
        }

        /// <summary>
        /// Timer.Tick �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@  : �w�肳�ꂽ�Ԋu�̎��Ԃ��o�߂����Ƃ��ɔ������܂��B
        ///					  ���̏����́A�V�X�e�����񋟂���X���b�h �v�[��
        ///					  �X���b�h�Ŏ��s����܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.18</br>
        /// </remarks>
        private void Initial_Timer_Tick(object sender, System.EventArgs e)
        {
            Initial_Timer.Enabled = false;

            // ��ʍč\�z����
            ScreenReconstruction();
        }

        /// <summary>
        /// Control.VisibleChange �C�x���g(UI_UltraGrid)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : �R���g���[���̕\����Ԃ��ς�����Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.19</br>
        /// </remarks>
        private void tbsPartsList_ultraGrid_VisibleChanged(object sender, System.EventArgs e)
        {
            // �A�N�e�B�u�Z���E�A�N�e�B�u�s�𖳌�
            this.tbsPartsList_ultraGrid.ActiveCell = null;
        }

        /// <summary>
        /// UltraGrid.AfterCellActivate�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note		: �Z�����A�N�e�B�u�����ꂽ���ɔ������܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.19</br>
        /// </remarks>
        private void tbsPartsList_ultraGrid_AfterCellActivate(object sender, System.EventArgs e)
        {
            this.tbsPartsList_ultraGrid.DisplayLayout.Override.ActiveRowAppearance.BackColor = System.Drawing.Color.FromArgb(251, 230, 148);
            this.tbsPartsList_ultraGrid.DisplayLayout.Override.ActiveRowAppearance.BackColor2 = System.Drawing.Color.FromArgb(238, 149, 21);
            this.tbsPartsList_ultraGrid.DisplayLayout.Override.ActiveRowAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.tbsPartsList_ultraGrid.DisplayLayout.Override.ActiveRowAppearance.ForeColor = System.Drawing.Color.Black;
            this.tbsPartsList_ultraGrid.DisplayLayout.Override.ActiveRowAppearance.BackColorDisabled = System.Drawing.Color.FromArgb(251, 230, 148);
            this.tbsPartsList_ultraGrid.DisplayLayout.Override.ActiveRowAppearance.BackColorDisabled2 = System.Drawing.Color.FromArgb(238, 149, 21);
        }

        /// <summary>
        /// Control.KeyDown �C�x���g (UI_UltraGrid)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : �L�[�������ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.19</br>
        /// </remarks>
        private void tbsPartsList_ultraGrid_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {

            // �A�N�e�B�u�Z����null�̎��͏������s�킸�I��
            if (this.tbsPartsList_ultraGrid.ActiveCell == null)
            {
                return;                
            }

            // �O���b�h��Ԏ擾()
            Infragistics.Win.UltraWinGrid.UltraGridState status = this.tbsPartsList_ultraGrid.CurrentState;

            // 2008.11.05 30413 �K�C�h�{�^�����畔�ʖ���OK�{�^���֑J�ڂł���悤�ɏC�� >>>>>>START
            //if ((status & Infragistics.Win.UltraWinGrid.UltraGridState.InEdit) == Infragistics.Win.UltraWinGrid.UltraGridState.InEdit)
            //{

                //�h���b�v�_�E����Ԃ̎��͏������Ȃ�(UltraGrid�̃f�t�H���g�̓����ɂ���)
                Control nextControl = null;
                if ((e.Control == false) && (e.Shift == false) && (e.Alt == false) &&
                    ((status & Infragistics.Win.UltraWinGrid.UltraGridState.IsDroppedDown) != Infragistics.Win.UltraWinGrid.UltraGridState.IsDroppedDown))
                {

                    switch (e.KeyCode)
                    {
                        // ���L�[
                        case Keys.Up:
                            {
                                // ��̃Z���ֈړ�
                                nextControl = MoveAboveCell();
                                e.Handled = true;
                                break;
                            }
                        // ���L�[
                        case Keys.Down:
                            {
                                // ���̃Z���ֈړ�
                                nextControl = MoveBelowCell();
                                e.Handled = true;
                                break;
                            }
                        // ���L�[
                        case Keys.Left:
                            {
                                // ��̃Z���ֈړ�
                                nextControl = MoveAboveCell();
                                e.Handled = true;

                                break;
                            }
                        // ���L�[
                        case Keys.Right:
                            {
                                // ���̃Z���ֈړ�
                                nextControl = MoveBelowCell();
                                e.Handled = true;

                                break;
                            }
                        case Keys.Space:
                            {
                                if (this.tbsPartsList_ultraGrid.ActiveCell.Column.Style == Infragistics.Win.UltraWinGrid.ColumnStyle.Button)
                                {
                                    UltraGridCell ultraGridCell = this.tbsPartsList_ultraGrid.ActiveCell;
                                    CellEventArgs cellEventArgs = new CellEventArgs(ultraGridCell);
                                    tbsPartsList_ultraGrid_ClickCellButton(sender, cellEventArgs);
                                }
                                break;
                            }
                    }
                //}
                // 2008.11.05 30413 �K�C�h�{�^�����畔�ʖ���OK�{�^���֑J�ڂł���悤�ɏC�� <<<<<<END

                if (nextControl != null)
                {
                    nextControl.Focus();
                }
            }
        }

        /// <summary>
        ///	ultraGrid.AfterExitEditMode �C�x���g(Cell)
        /// </summary>
        /// <remarks>
        /// <br>Note	   : GRID�̃Z���ҏW�I���C�x���g�����B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008/10/21</br>
        /// </remarks>
        private void tbsPartsList_ultraGrid_AfterExitEditMode(object sender, EventArgs e)
        {
            int status = -1;

            if (this.tbsPartsList_ultraGrid.ActiveCell == null) return;

            Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.tbsPartsList_ultraGrid.ActiveCell;

            // BL�R�[�h
            if (cell.Column.Key == MY_SCREEN_TBSPARTS_CODE)
            {
                string strCode = cell.Value.ToString();
                this._gridUpdFlg = true;

                if ((strCode != "") && (int.Parse(strCode) != 0))
                {
                    // ���͗L
                    int tbsPartsCode = int.Parse(strCode);
                    BLGoodsCdUMnt blGoodsCdUMnt;

                    status = this._blGoodsCdAcs.Read(out blGoodsCdUMnt, this._enterpriseCode, tbsPartsCode);

                    if ((status == 0) && (blGoodsCdUMnt.LogicalDeleteCode == 0))
                    {
                        bool AddFlg = true;     // �ǉ��t���O
                        int maxRow = this._bindTable.Rows.Count;

                        // BL�R�[�h�̏d���`�F�b�N
                        for (int i = 0; i < maxRow; i++)
                        {
                            if (cell.Row.Index == i)
                            {
                                // �����s����SKIP
                                continue;
                            }

                            string wkTbsPartsCode = this._bindTable.Rows[i][MY_SCREEN_TBSPARTS_CODE].ToString();
                            if ((wkTbsPartsCode != "") && (int.Parse(wkTbsPartsCode) == blGoodsCdUMnt.BLGoodsCode))
                            {
                                // �d���R�[�h�L
                                AddFlg = false;
                                break;
                            }
                        }

                        if (AddFlg)
                        {
                            // BL�R�[�h�̒ǉ�
                            // �I����������Cell�ɐݒ�
                            cell.Row.Cells[MY_SCREEN_TBSPARTS_CODE].Value = blGoodsCdUMnt.BLGoodsCode.ToString("d05");    // BL�R�[�h
                            cell.Row.Cells[MY_SCREEN_TBSPARTS_NAME].Value = blGoodsCdUMnt.BLGoodsFullName;                // BL�i��

                            if ((int)cell.Row.Cells[MY_SCREEN_ODER].Value == this._bindTable.Rows.Count)
                            {
                                // �ŏI�s�̏ꍇ�A�s��ǉ�
                                this.tbsPartsList_AddRow();
                            }
                        }
                        else
                        {
                            // �d���G���[��\��
                            TMsgDisp.Show(
                                this,								    // �e�E�B���h�E�t�H�[��
                                emErrorLevel.ERR_LEVEL_EXCLAMATION,	    // �G���[���x��
                                PG_ID,      						    // �A�Z���u���h�c�܂��̓N���X�h�c
                                "�I������BL���ނ��d�����Ă��܂��B",	    // �\�����郁�b�Z�[�W 
                                0,									    // �X�e�[�^�X�l
                                MessageBoxButtons.OK);				    // �\������{�^��

                            // BL�R�[�h�ABL�i�����N���A
                            cell.Row.Cells[MY_SCREEN_TBSPARTS_CODE].Value = "";       // BL�R�[�h
                            cell.Row.Cells[MY_SCREEN_TBSPARTS_NAME].Value = "";       // BL�i��

                            // Grid�ύX�Ȃ�
                            this._gridUpdFlg = false;
                        }
                    }
                    else
                    {
                        // �_���폜�f�[�^�͐ݒ�s��
                        TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_INFO,
                            this.Name,
                            "BL���� [" + tbsPartsCode.ToString("d05") + "] �ɊY������f�[�^�����݂��܂���B",
                            -1,
                            MessageBoxButtons.OK);

                        // BL�R�[�h�ABL�i�����N���A
                        cell.Row.Cells[MY_SCREEN_TBSPARTS_CODE].Value = "";       // BL�R�[�h
                        cell.Row.Cells[MY_SCREEN_TBSPARTS_NAME].Value = "";       // BL�i��

                        // Grid�ύX�Ȃ�
                        this._gridUpdFlg = false;
                    }
                }
                else
                {
                    // ������
                    // BL�R�[�h�ABL�i�����N���A
                    cell.Row.Cells[MY_SCREEN_TBSPARTS_CODE].Value = "";       // BL�R�[�h
                    cell.Row.Cells[MY_SCREEN_TBSPARTS_NAME].Value = "";       // BL�i��
                }
            }
        }

        /// <summary>
        ///	ultraGrid.KeyPress �C�x���g(Cell)
        /// </summary>
        /// <remarks>
        /// <br>Note	   : GRID�̃L�[�����C�x���g�����B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008/10/21</br>
        /// </remarks>
        private void tbsPartsList_ultraGrid_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (this.tbsPartsList_ultraGrid.ActiveCell == null) return;
            Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.tbsPartsList_ultraGrid.ActiveCell;

            // BL�R�[�h�̓��͌����`�F�b�N
            if (cell.Column.Key == MY_SCREEN_TBSPARTS_CODE)
            {
                // �ҏW���[�h���H
                if (cell.IsInEditMode)
                {
                    if (!this.KeyPressNumCheck(5, 0, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false, false))
                    {
                        e.Handled = true;
                        return;
                    }
                }
            }
        }

        /// <summary>
        /// ���̃Z���ֈړ�����
        /// </summary>
        /// <returns>���̃R���g���[��</returns>
        /// <remarks>
        /// <br>Note       : BL�R�[�h�O���b�h�̃A�N�e�B�u�Z�������̃Z���Ɉړ����܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.19</br>
        /// </remarks>
        private Control MoveBelowCell()
        {
            bool performActionResult;

            // �A�N�e�B�u�Z����null
            if (this.tbsPartsList_ultraGrid.ActiveCell == null)
            {
                return null;
            }

            // �O���b�h��Ԏ擾
            Infragistics.Win.UltraWinGrid.UltraGridState status = this.tbsPartsList_ultraGrid.CurrentState;

            // �ŉ��i�Z���̎�
            if ((status & Infragistics.Win.UltraWinGrid.UltraGridState.RowLast) == Infragistics.Win.UltraWinGrid.UltraGridState.RowLast)
            {
                // �ۑ��{�^���ֈړ�
                // --- CHG 2009/03/23 �c�Č�No.14�Ή�------------------------------------------------------>>>>>
                //return this.Ok_Button;
                return this.Renewal_Button;
                // --- CHG 2009/03/23 �c�Č�No.14�Ή�------------------------------------------------------<<<<<
            }
            // �ŉ��i�Z���łȂ���
            else
            {
                // �Z���ړ��O�A�N�e�B�u�Z���̃C���f�b�N�X
                int prevCol = this.tbsPartsList_ultraGrid.ActiveCell.Column.Index;
                int prevRow = this.tbsPartsList_ultraGrid.ActiveCell.Row.Index;

                // ���̃Z���Ɉړ�
                performActionResult = this.tbsPartsList_ultraGrid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.BelowCell);

                // �Z�����ړ����Ă��Ȃ���
                if ((prevCol == this.tbsPartsList_ultraGrid.ActiveCell.Column.Index) &&
                    (prevRow == this.tbsPartsList_ultraGrid.ActiveCell.Row.Index))
                {
                    // �ۑ��{�^���ֈړ�
                    // --- CHG 2009/03/23 �c�Č�No.14�Ή�------------------------------------------------------>>>>>
                    //return this.Ok_Button;
                    return this.Renewal_Button;
                    // --- CHG 2009/03/23 �c�Č�No.14�Ή�------------------------------------------------------<<<<<
                }
                // �Z�����ړ����Ă�
                else
                {
                    if (performActionResult)
                    {
                        if ((this.tbsPartsList_ultraGrid.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) &&
                            (this.tbsPartsList_ultraGrid.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
                        {
                            this.tbsPartsList_ultraGrid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                        }
                    }
                    return null;
                }
            }
        }

        /// <summary>
        /// ��̃Z���ֈړ�����
        /// </summary>
        /// <returns>���̃R���g���[��</returns>
        /// <remarks>
        /// <br>Note       : BL�R�[�h�O���b�h�̃A�N�e�B�u�Z������̃Z���Ɉړ����܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.19</br>
        /// </remarks>
        private Control MoveAboveCell()
        {
            bool performActionResult;

            // �A�N�e�B�u�Z����null
            if (this.tbsPartsList_ultraGrid.ActiveCell == null)
            {
                return null;
            }

            // �O���b�h��Ԏ擾
            Infragistics.Win.UltraWinGrid.UltraGridState status = this.tbsPartsList_ultraGrid.CurrentState;

            // �ŏ�i�Z���̎�
            if ((status & Infragistics.Win.UltraWinGrid.UltraGridState.RowFirst) == Infragistics.Win.UltraWinGrid.UltraGridState.RowFirst)
            {
                // �ړ����Ȃ�
                //return null;
                // ���ʖ��̂ֈړ�
                return this.PartsPosName_tEdit;
            }
            // �őO�Z���łȂ���
            else
            {
                // ��̃Z���Ɉړ�
                performActionResult = this.tbsPartsList_ultraGrid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.AboveCell);
                if (performActionResult)
                {
                    if ((this.tbsPartsList_ultraGrid.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) &&
                        (this.tbsPartsList_ultraGrid.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
                    {
                        this.tbsPartsList_ultraGrid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                    }
                }
                return null;

            }
        }

        /// <summary>
        /// �����͉\�Z���ړ�����
        /// </summary>
        /// <param name="activeCellCheck">true:ActiveCell�����͉\�̏ꍇ��Next�Ɉړ������Ȃ� false:ActiveCell�Ɋ֌W�Ȃ�Next�Ɉړ�������</param>
        /// <returns>true:�Z���ړ����� false:�Z���ړ����s</returns>
        /// <remarks>
        /// Note			:	���̓��͉\�ȃZ���Ƀt�H�[�J�X���ړ����鏈�����s���܂��B<br />
        /// Programmer		:	30413 ����<br />
        /// Date			:	2008.10.21<br />
        /// </remarks>
        private bool MoveNextAllowEditCell(bool activeCellCheck)
        {
            bool moved = false;
            bool performActionResult = false;

            if ((activeCellCheck) && (this.tbsPartsList_ultraGrid.ActiveCell != null))
            {
                if ((this.tbsPartsList_ultraGrid.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) &&
                    (this.tbsPartsList_ultraGrid.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
                {
                    moved = true;
                }
            }
            else
            {
                while (!moved)
                {
                    performActionResult = this.tbsPartsList_ultraGrid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextCell);

                    if (performActionResult)
                    {
                        if ((this.tbsPartsList_ultraGrid.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) &&
                            (this.tbsPartsList_ultraGrid.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
                        {
                            moved = true;
                        }
                        else if (this.tbsPartsList_ultraGrid.ActiveCell.Column.Style == Infragistics.Win.UltraWinGrid.ColumnStyle.Button)
                        {
                            // �A�N�e�B�u�Z�����{�^��
                            moved = false;
                            int rowIdx = this.tbsPartsList_ultraGrid.ActiveCell.Row.Index;
                            if ((this._bindTable.Rows[rowIdx][MY_SCREEN_TBSPARTS_CODE].ToString() == "") &&
                                (this._gridUpdFlg))
                            {
                                // BL�R�[�h�������͂̏ꍇ(BL�R�[�h�擾���s���͏���)
                                break;
                            }
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
            }

            if (moved)
            {
                this.tbsPartsList_ultraGrid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
            }

            return performActionResult;
        }

        /// <summary>
        /// �O���͉\�Z���ړ�����
        /// </summary>
        /// <param name="activeCellCheck">true:ActiveCell�����͉\�̏ꍇ��Prev�Ɉړ������Ȃ� false:ActiveCell�Ɋ֌W�Ȃ�Prev�Ɉړ�������</param>
        /// <returns>true:�Z���ړ����� false:�Z���ړ����s</returns>
        /// <remarks>
        /// Note			:	�O�̓��͉\�ȃZ���Ƀt�H�[�J�X���ړ����鏈�����s���܂��B<br />
        /// Programmer		:	30413 ����<br />
        /// Date			:	2008.10.21<br />
        /// </remarks>
        private bool MovePrevAllowEditCell(bool activeCellCheck)
        {
            bool moved = false;
            bool performActionResult = false;

            if ((activeCellCheck) && (this.tbsPartsList_ultraGrid.ActiveCell != null))
            {
                if ((this.tbsPartsList_ultraGrid.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) &&
                    (this.tbsPartsList_ultraGrid.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
                {
                    moved = true;
                }
            }
            else
            {
                while (!moved)
                {
                    performActionResult = this.tbsPartsList_ultraGrid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.PrevCell);

                    if (performActionResult)
                    {
                        if ((this.tbsPartsList_ultraGrid.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) &&
                            (this.tbsPartsList_ultraGrid.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
                        {
                            moved = true;
                        }
                        else if (this.tbsPartsList_ultraGrid.ActiveCell.Column.Style == Infragistics.Win.UltraWinGrid.ColumnStyle.Button)
                        {
                            // �A�N�e�B�u�Z�����{�^��
                            moved = false;
                            int rowIdx = this.tbsPartsList_ultraGrid.ActiveCell.Row.Index;
                            if (this._bindTable.Rows[rowIdx][MY_SCREEN_TBSPARTS_CODE].ToString() == "")                                
                            {
                                // BL�R�[�h�������͂̏ꍇ
                                break;
                            }
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
            }

            if (moved)
            {
                this.tbsPartsList_ultraGrid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
            }

            return performActionResult;
        }

        /// <summary>
        ///	ultraGrid.Click �C�x���g(Cell Button)
        /// </summary>
        /// <remarks>
        /// <br>Note	   : GRID��Cell Button���N���b�N�C�x���g�����B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008/06/19</br>
        /// </remarks>
        private void tbsPartsList_ultraGrid_ClickCellButton(object sender, CellEventArgs e)
        {
            BLGoodsCdUMnt blGoodsCdUMnt = null;
            // BL�R�[�h�}�X�^�̃K�C�h�\��
            int status = this.ShowBLGoodsCdGuide(out blGoodsCdUMnt);

            if (status == 0)
            {
                bool AddFlg = true;     // �ǉ��t���O
                int maxRow = this._bindTable.Rows.Count;

                // BL�R�[�h�̏d���`�F�b�N
                for (int i = 0; i < maxRow; i++)
                {
                    string strTbsPartsCode = (string)this._bindTable.Rows[i][MY_SCREEN_TBSPARTS_CODE];
                    if (strTbsPartsCode == "")
                    {
                        continue;
                    }

                    int tbsPartsCode = Int32.Parse(strTbsPartsCode);
                    if (tbsPartsCode == blGoodsCdUMnt.BLGoodsCode)
                    {
                        // �d���R�[�h�L
                        AddFlg = false;
                        break;
                    }
                }

                if (AddFlg)
                {
                    // �I����������Cell�ɐݒ�
                    e.Cell.Row.Cells[MY_SCREEN_TBSPARTS_CODE].Value = blGoodsCdUMnt.BLGoodsCode.ToString("d05");    // BL�R�[�h
                    e.Cell.Row.Cells[MY_SCREEN_TBSPARTS_NAME].Value = blGoodsCdUMnt.BLGoodsFullName;                // BL�i��

                    if ((int)e.Cell.Row.Cells[MY_SCREEN_ODER].Value == this._bindTable.Rows.Count)
                    {
                        // �ŏI�s�̏ꍇ�A�s��ǉ�
                        this.tbsPartsList_AddRow();
                    }

                    // ���̃R���g���[���փt�H�[�J�X���ړ�
                    this.MoveNextAllowEditCell(false);
                }
                else
                {
                    // �d���G���[��\��
                    TMsgDisp.Show(
                        this,								    // �e�E�B���h�E�t�H�[��
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,	    // �G���[���x��
                        PG_ID,      						    // �A�Z���u���h�c�܂��̓N���X�h�c
                        "�I������BL���ނ��d�����Ă��܂��B",	// �\�����郁�b�Z�[�W 
                        0,									    // �X�e�[�^�X�l
                        MessageBoxButtons.OK);				    // �\������{�^��

                    ((Control)sender).Focus();
                }
            }
            else
            {
                ((Control)sender).Focus();
            }
        }

        /// <summary>
        /// Control.Click �C�x���g(DeleteRow_Button)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note �@�@  : �폜�{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.19</br>
        /// </remarks>
        private void DeleteRow_Button_Click(object sender, EventArgs e)
        {
            string message = "";

            if (this.tbsPartsList_ultraGrid.Rows.Count < 1)
            {
                // �f�o�b�O�p
                this.tbsPartsList_AddRow();
            }

            if (this.tbsPartsList_ultraGrid.ActiveRow == null)
            {
                // �폜����s�����I��
                message = "�폜����BL���ނ�I�����ĉ������B";

                TMsgDisp.Show(
                    this,								// �e�E�B���h�E�t�H�[��
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,	// �G���[���x��
                    PG_ID,      						// �A�Z���u���h�c�܂��̓N���X�h�c
                    message,							// �\�����郁�b�Z�[�W 
                    0,									// �X�e�[�^�X�l
                    MessageBoxButtons.OK);				// �\������{�^��

                this.tbsPartsList_ultraGrid.Focus();
            }
            else if (this.tbsPartsList_ultraGrid.Rows.Count == 1)
            {
                // Grid�̍s����1�s�̏ꍇ�͍폜�s��
                message = "�S�Ă̖��׍폜�͂ł��܂���";

                TMsgDisp.Show(
                    this,								// �e�E�B���h�E�t�H�[��
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,	// �G���[���x��
                    PG_ID,      						// �A�Z���u���h�c�܂��̓N���X�h�c
                    message,							// �\�����郁�b�Z�[�W 
                    0,									// �X�e�[�^�X�l
                    MessageBoxButtons.OK);				// �\������{�^��

                this.tbsPartsList_ultraGrid.Focus();
            }
            else
            {
                // UI��ʂ�Grid����I���s���폜
                // �I���s��index���擾
                int delIndex = (int)this.tbsPartsList_ultraGrid.ActiveRow.Cells[MY_SCREEN_ODER].Value - 1;

                // �I���s�̍폜
                this.tbsPartsList_ultraGrid.ActiveRow.Delete();

                // �폜���Grid�s�����擾
                int maxRow = this._bindTable.Rows.Count;

                for (int index = delIndex; index < maxRow; index++)
                {
                    // �폜�����s�ȍ~�̕\�����ʂ��X�V����
                    this._bindTable.Rows[index][MY_SCREEN_ODER] = index + 1;
                }
            }
        }

        /// <summary>
        /// Control.Click �C�x���g(Guid_Button)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note �@�@  : �K�C�h�{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.11.06</br>
        /// </remarks>
        private void Guid_Button_Click(object sender, EventArgs e)
        {
            PartsPosCodeU partsPosCodeU = null;
            string message;
            int status = this.ShowPartsPosCodeGuide(out partsPosCodeU);

            if (status == 0)
            {
                bool AddFlg = true;     // �ǉ��t���O
                int maxRow = this._bindTable.Rows.Count;

                // BL�R�[�h�̏d���`�F�b�N
                for (int i = 0; i < maxRow; i++)
                {
                    string wkTbsPartsCode = this._bindTable.Rows[i][MY_SCREEN_TBSPARTS_CODE].ToString();
                    if ((wkTbsPartsCode != "") && (int.Parse(wkTbsPartsCode) == partsPosCodeU.TbsPartsCode))
                    {
                        // �d���R�[�h�L
                        AddFlg = false;
                        break;
                    }
                }

                if (AddFlg)
                {
                    int lastRow = this._bindTable.Rows.Count - 1;

                    if (this._bindTable.Rows[lastRow][MY_SCREEN_TBSPARTS_CODE].ToString() == "")
                    {
                        // �ŏI�s����
                        this._bindTable.Rows[lastRow][MY_SCREEN_TBSPARTS_CODE] = partsPosCodeU.TbsPartsCode.ToString("d05");
                        this._bindTable.Rows[lastRow][MY_SCREEN_TBSPARTS_NAME] = partsPosCodeU.TbsPartsName;
                    }
                    else
                    {
                        // �K�C�h�őI������BL�R�[�h��ǉ�
                        DataRow bindRow;

                        bindRow = this._bindTable.NewRow();

                        // BL����Grid�ɒǉ�
                        bindRow[MY_SCREEN_ID] = "";
                        bindRow[MY_SCREEN_ODER] = this._bindTable.Rows.Count + 1;
                        bindRow[MY_SCREEN_TBSPARTS_CODE] = partsPosCodeU.TbsPartsCode.ToString("d05");
                        bindRow[MY_SCREEN_TBSPARTS_NAME] = partsPosCodeU.TbsPartsName;

                        this._bindTable.Rows.Add(bindRow);
                    }

                    // �V�K�s��ǉ�
                    this.tbsPartsList_AddRow();

                    // ���̃R���g���[���փt�H�[�J�X���ړ�
                    this.SelectNextControl((Control)sender, true, true, true, true);
                }
                else
                {
                    // �d���G���[��\��
                    message = "�I������BL���ނ͑I���ςł��B";

                    TMsgDisp.Show(
                        this,								// �e�E�B���h�E�t�H�[��
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,	// �G���[���x��
                        PG_ID,      						// �A�Z���u���h�c�܂��̓N���X�h�c
                        message,							// �\�����郁�b�Z�[�W 
                        0,									// �X�e�[�^�X�l
                        MessageBoxButtons.OK);				// �\������{�^��

                    ((Control)sender).Focus();
                }
            }
            else if (status == -1)
            {
                // ���ʃR�[�h��������
                message = this.PartsPosCode_Label.Text + "����͂��ĉ������B";

                TMsgDisp.Show(
                    this,								// �e�E�B���h�E�t�H�[��
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,	// �G���[���x��
                    PG_ID,      						// �A�Z���u���h�c�܂��̓N���X�h�c
                    message,							// �\�����郁�b�Z�[�W 
                    0,									// �X�e�[�^�X�l
                    MessageBoxButtons.OK);				// �\������{�^��

                this.PartsPosCode_tNedit.Focus();
            }
            else
            {
                ((Control)sender).Focus();
            }
        }

        /// <summary>
        ///	Control.ChangeFocus �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// Note			:	�t�H�[�J�X�ړ����ɔ������܂��B<br />
        /// Programmer		:	30413 ����<br />
        /// Date			:	2008.10.21<br />
        /// </remarks>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null || e.NextCtrl == null) return;

            switch (e.PrevCtrl.Name)
            {
                case "tNedit_CustomerCodeAllowZero":         // ���Ӑ�R�[�h
                    {
                        int customerCode = this.tNedit_CustomerCodeAllowZero.GetInt();
                        string customerSnm;

                        if (customerCode != 0)
                        {
                            // ���Ӑ旪�̂̎擾
                            this._partsPosCodeUAcs.SerachCustomerInfo(customerCode, this._enterpriseCode, out customerSnm);

                            if (customerSnm != "")
                            {
                                this.CustomerSnm_tEdit.Text = customerSnm;

                                // �J�[�\������
                                e.NextCtrl = this.PartsPosCode_tNedit;
                            }
                            else
                            {
                                TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_INFO,
                                this.Name,
                                "�Y�����链�Ӑ�f�[�^�����݂��܂���B",
                                -1,
                                MessageBoxButtons.OK);

                                // ���Ӑ�̃N���A
                                this.tNedit_CustomerCodeAllowZero.Clear();
                                this.CustomerSnm_tEdit.Text = "";

                                // �J�[�\������
                                e.NextCtrl = e.PrevCtrl;
                            }
                        }
                        else
                        {
                            // ������
                            // ���Ӑ�̃N���A
                            this.tNedit_CustomerCodeAllowZero.Clear();
                            this.CustomerSnm_tEdit.Text = CUSTOMER_SNM_COMMON;
                        }

                        break;
                    }
                case "PartsPosCode_tNedit":         // ���ʃR�[�h
                    {
                        // �J�[�\������
                        if (e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                    {
                                        if ((this.tNedit_CustomerCodeAllowZero.Text != "") && (this.tNedit_CustomerCodeAllowZero.GetInt() != 0))
                                        {
                                            // �J�[�\������
                                            e.NextCtrl = tNedit_CustomerCodeAllowZero;
                                        }
                                        break;
                                    }
                            }
                        }

                        // 2009.03.31 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� >>>>>>START
                        //// ���Ӑ�R�[�h�ƕ��ʃR�[�h�ő��݃`�F�b�N
                        //if (this.PartsPosCode_tNedit.GetInt() != 0)
                        //{
                        //    if (this.tNedit_CustomerCodeAllowZero.Enabled)
                        //    {
                        //        int status = -1;
                        //        PartsPosCodeU partsPosCodeU;
                        //        int customerCode = this.tNedit_CustomerCodeAllowZero.GetInt();
                        //        int partsPosCode = this.PartsPosCode_tNedit.GetInt();
                        //        status = this._partsPosCodeUAcs.Read(out partsPosCodeU, this._enterpriseCode, customerCode, partsPosCode, 0);
                        //        if ((status == 0) && (partsPosCodeU != null))
                        //        {
                        //            if ((customerCode == partsPosCodeU.CustomerCode) && (partsPosCode == partsPosCodeU.SearchPartsPosCode))
                        //            {
                        //                TMsgDisp.Show(
                        //                    this,
                        //                    emErrorLevel.ERR_LEVEL_INFO,
                        //                    this.Name,
                        //                    "���ɓo�^����Ă��܂��B",
                        //                    -1,
                        //                    MessageBoxButtons.OK);
                        //                this.PartsPosCode_tNedit.Clear();

                        //                // �J�[�\������
                        //                e.NextCtrl = e.PrevCtrl;
                        //            }
                        //        }
                        //    }
                        //}
                        // 2009.03.31 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� <<<<<<END
        
                        break;
                    }
                case "PartsPosName_tEdit":          // ���ʖ���      
                    {
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Return:
                                case Keys.Tab:
                                case Keys.Down:
                                    {
                                        // GRID��BL���ނփt�H�[�J�X����
                                        this.tbsPartsList_ultraGrid.Rows[0].Cells[MY_SCREEN_TBSPARTS_CODE].Activate();
                                        this.tbsPartsList_ultraGrid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                                        e.NextCtrl = null;
                                        break;
                                    }
                            }
                        }
                        break;
                    }
                case "DeleteRow_Button":            // GRID�폜�{�^��
                    {
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Return:
                                case Keys.Tab:
                                    {
                                        // GRID��BL���ނփt�H�[�J�X����
                                        this.tbsPartsList_ultraGrid.Rows[0].Cells[MY_SCREEN_TBSPARTS_CODE].Activate();
                                        this.tbsPartsList_ultraGrid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                                        e.NextCtrl = null;
                                        break;
                                    }
                            }
                        }
                        break;
                    }
                case "tbsPartsList_ultraGrid":      // �O���b�h
                    {
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Return:
                                case Keys.Tab:
                                    {
                                        // �K�C�h�{�^���Ƀt�H�[�J�X������
                                        if (this.tbsPartsList_ultraGrid.ActiveCell != null)
                                        {
                                            Infragistics.Win.UltraWinGrid.UltraGridState status = this.tbsPartsList_ultraGrid.CurrentState;

                                            if ((this.tbsPartsList_ultraGrid.ActiveCell.Column.Style == Infragistics.Win.UltraWinGrid.ColumnStyle.Button) &&
                                                (status & Infragistics.Win.UltraWinGrid.UltraGridState.RowLast) == Infragistics.Win.UltraWinGrid.UltraGridState.RowLast)
                                            {
                                                // �Z���̃X�^�C�����{�^���ŁA�Z���̍ŏI�s�̏ꍇ
                                                if ((int)this.tbsPartsList_ultraGrid.ActiveCell.Row.Cells[MY_SCREEN_ODER].Value == this._bindTable.Rows.Count)
                                                {
                                                    // �ŏI�s�̏ꍇ�A�s��ǉ�
                                                    this.tbsPartsList_AddRow();
                                                }
                                            }
                                        }

                                        // ���̃Z���ֈړ�
                                        bool moveFlg = this.MoveNextAllowEditCell(false);
                                        if (moveFlg)
                                        {
                                            e.NextCtrl = null;
                                        }
                                        else if (!this._gridUpdFlg)
                                        {
                                            this.MovePrevAllowEditCell(false);
                                            e.NextCtrl = null;
                                        }
                                        break;
                                    }
                            }
                        }
                        else
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                    {
                                        if (this.MovePrevAllowEditCell(false))
                                        {
                                            // �O���b�h���̃t�H�[�J�X����
                                            e.NextCtrl = null;
                                        }
                                        else if (e.NextCtrl.Name == "DeleteRow_Button")
                                        {
                                            // �O���b�h���ł̃t�H�[�J�X����Ɏ��s�����ꍇ�A���ʖ���
                                            e.NextCtrl = this.PartsPosName_tEdit;
                                        }
                                        
                                        break;
                                    }
                            }
                        }
                        break;
                    }
                //case "Ok_Button":
                case "Renewal_Button":
                    {
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Up:
                                    {
                                        // GRID��BL���ނփt�H�[�J�X����
                                        int rowIdx = this.tbsPartsList_ultraGrid.Rows.Count - 1;
                                        // �A�N�e�B�u�s���ŏI�s�ɐݒ�
                                        this.tbsPartsList_ultraGrid.ActiveRow = this.tbsPartsList_ultraGrid.Rows[rowIdx];
                                        // �A�N�e�B�u�Z����BL�R�[�h�ɐݒ�(�t�H�[�J�X�J�ڂ̂���)
                                        this.tbsPartsList_ultraGrid.ActiveCell = this.tbsPartsList_ultraGrid.Rows[rowIdx].Cells[MY_SCREEN_TBSPARTS_CODE];
                                        // BL�R�[�h��ҏW���[�h�ɂ��ăt�H�[�J�X���ړ�
                                        this.tbsPartsList_ultraGrid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                                        if (this._bindTable.Rows[rowIdx][MY_SCREEN_TBSPARTS_CODE].ToString() == "")
                                        {
                                            // �K�C�h�{�^���փt�H�[�J�X�ړ�
                                            this.tbsPartsList_ultraGrid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextCell);
                                        }
                                        e.NextCtrl = null;
                                        break;
                                    }
                            }
                        }
                        else
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                    {
                                        // GRID��BL���ނփt�H�[�J�X����
                                        int rowIdx = this.tbsPartsList_ultraGrid.Rows.Count - 1;
                                        // �A�N�e�B�u�s���ŏI�s�ɐݒ�
                                        this.tbsPartsList_ultraGrid.ActiveRow = this.tbsPartsList_ultraGrid.Rows[rowIdx];
                                        // �A�N�e�B�u�Z����BL�R�[�h�ɐݒ�(�t�H�[�J�X�J�ڂ̂���)
                                        this.tbsPartsList_ultraGrid.ActiveCell = this.tbsPartsList_ultraGrid.Rows[rowIdx].Cells[MY_SCREEN_TBSPARTS_CODE];
                                        // BL�R�[�h��ҏW���[�h�ɂ��ăt�H�[�J�X���ړ�
                                        this.tbsPartsList_ultraGrid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                                        if (this._bindTable.Rows[rowIdx][MY_SCREEN_TBSPARTS_CODE].ToString() == "")
                                        {
                                            // �K�C�h�{�^���փt�H�[�J�X�ړ�
                                            this.tbsPartsList_ultraGrid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextCell);
                                        }
                                        e.NextCtrl = null;
                                        break;
                                    }
                            }
                        }
                        break;
                    }
            }

            // 2009.03.31 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� >>>>>>START
            if (e.NextCtrl != null)
            {
                switch (e.NextCtrl.Name)
                {
                    case "PartsPosName_tEdit":          // ���ʖ�
                    case "tbsPartsList_ultraGrid":      // �O���b�h
                        {
                            if ((this._mainDataIndex < 0) || (this._secondDataIndex < 0))
                            {
                                if (ModeChangeProc())
                                {
                                    e.NextCtrl = tNedit_CustomerCodeAllowZero;
                                }
                            }
                            break;
                        }
                }
            }
            // 2009.03.31 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� <<<<<<END
        }

        /// <summary>
        /// ���Ӑ�I���������C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="customerSearchRet">���Ӑ�ԗ������߂�l�N���X</param>
        /// <remarks>
        /// <br>Note       : �I������Ă���v�㋒�_��ݒ肵�܂�</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.10.20</br>
        /// </remarks>
        private void CustomerCd_GuideBtn_Click(object sender, EventArgs e)
        {
            int beCustCd = this.tNedit_CustomerCodeAllowZero.GetInt();

            PMKHN04005UA customerSearchForm = new PMKHN04005UA(PMKHN04005UA.SEARCHMODE_CUSTOMER_ONLY, PMKHN04005UA.EXECUTEMODE_GUIDE_ONLY);
            customerSearchForm.CustomerSelect += new PMKHN04005UA.CustomerSelectEventHandler(this.CustomerSearchForm_CustomerSelect);
            customerSearchForm.ShowDialog(this);

            if ((!beCustCd.Equals(this.tNedit_CustomerCodeAllowZero.GetInt())) && (this.tNedit_CustomerCodeAllowZero.Text != ""))
            {
                // �K�C�h�ďo�O�ƈႤ�A�N���A����Ă��Ȃ��ꍇ
                // ���̃R���g���[���փt�H�[�J�X���ړ�
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }

        /// <summary>
        /// ���Ӑ�I���������C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="customerSearchRet">���Ӑ�}�X�^�N���X</param>
        /// <remarks>
        /// <br>Note       : �I���������Ӑ����ݒ肵�܂�</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.10.20</br>
        /// </remarks>
        private void CustomerSearchForm_CustomerSelect(object sender, CustomerSearchRet customerSearchRet)
        {
            if (customerSearchRet == null) return;

            CustomerInfo customerInfo;
            CustomerInfoAcs customerInfoAcs = new CustomerInfoAcs();

            int status = customerInfoAcs.ReadDBData(ConstantManagement.LogicalMode.GetData0, customerSearchRet.EnterpriseCode, customerSearchRet.CustomerCode, true, out customerInfo);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // �擾�������Ӑ�R�[�h����ʂɕ\������
                this.tNedit_CustomerCodeAllowZero.SetInt(customerInfo.CustomerCode);
                this.CustomerSnm_tEdit.Text = customerInfo.CustomerSnm;
            }
            else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,
                    this.Name,
                    "�I���������Ӑ�͊��ɍ폜����Ă��܂��B",
                    status,
                    MessageBoxButtons.OK);

                return;
            }
            else
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_STOPDISP,
                    this.Name,
                    "���Ӑ���̎擾�Ɏ��s���܂����B",
                    status,
                    MessageBoxButtons.OK);

                return;
            }
        }

        # endregion

        #region Private Methods

        /// <summary>
        /// ���ʃR�[�h�N���X�f�[�^�Z�b�g�W�J����(���Ӑ�)
        /// </summary>
        /// <param name="partsPosCodeU">���ʃR�[�h�N���X</param>
        /// <param name="index">�f�[�^�Z�b�g�֓W�J����C���f�b�N�X</param>
        /// <remarks>
        /// <br>Note       : ���ʃR�[�h�N���X���f�[�^�Z�b�g�֊i�[���܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.17</br>
        /// </remarks>
        private void PartsPosCodeUToDataSet(PartsPosCodeU partsPosCodeU, ref int index)
        {
            // ���꓾�Ӑ�R�[�h�͕\�����Ȃ�
            if (this._mainGridTable.ContainsKey(CreateHashKeyMain(partsPosCodeU)))
            {
                return;
            }

            // ���C��Grid�Ɋi�[����f�[�^��ݒ�
            if ((index < 0) || (this.Bind_DataSet.Tables[MAIN_TABLE].Rows.Count <= index))
            {
                // �V�K�Ɣ��f���āA�s��ǉ�����
                DataRow dataRow = this.Bind_DataSet.Tables[MAIN_TABLE].NewRow();
                this.Bind_DataSet.Tables[MAIN_TABLE].Rows.Add(dataRow);

                // index���s�̍ŏI�s�ԍ��ɂ���
                index = this.Bind_DataSet.Tables[MAIN_TABLE].Rows.Count - 1;
            }

            // ADD 2009/03/25 �s��Ή�[12720]�F�u�폜�σf�[�^�̕\���v�͍ŏ�ʍ��ڂŐ��� ---------->>>>>
            // �폜��
            if (partsPosCodeU.LogicalDeleteCode == 0)
            {
                this.Bind_DataSet.Tables[MAIN_TABLE].Rows[index][M_DELETEDATE] = "";
            }
            else
            {
                this.Bind_DataSet.Tables[MAIN_TABLE].Rows[index][M_DELETEDATE] = TDateTime.DateTimeToString("ggYY/MM/DD", partsPosCodeU.UpdateDateTime);
            }
            // ADD 2009/03/25 �s��Ή�[12720]�F�u�폜�σf�[�^�̕\���v�͍ŏ�ʍ��ڂŐ��� ----------<<<<<

            if (partsPosCodeU.CustomerCode != 0)
            {
                // ���Ӑ�R�[�h
                this.Bind_DataSet.Tables[MAIN_TABLE].Rows[index][M_CUSTOMERCODE] = partsPosCodeU.CustomerCode.ToString("d08");

                // ���Ӑ旪��
                this.Bind_DataSet.Tables[MAIN_TABLE].Rows[index][M_CUSTOMERNAME] = partsPosCodeU.CustomerSnm;
            }
            else
            {
                // ���Ӑ�R�[�h
                this.Bind_DataSet.Tables[MAIN_TABLE].Rows[index][M_CUSTOMERCODE] = "00000000";

                // ���Ӑ旪��
                this.Bind_DataSet.Tables[MAIN_TABLE].Rows[index][M_CUSTOMERNAME] = CUSTOMER_SNM_COMMON;
            }

            // �n�b�V�������p�ɓ��Ӑ�R�[�h���Z�b�g
            this._mainGridTable.Add(CreateHashKeyMain(partsPosCodeU), partsPosCodeU);

            index++;
        }

        // ADD 2009/03/25 �s��Ή�[12720]�F�u�폜�σf�[�^�̕\���v�͍ŏ�ʍ��ڂŐ��� ---------->>>>>
        /// <summary>
        /// ��1�e�[�u���̍폜����ݒ肵�܂��B
        /// </summary>
        [Conditional("DELETE_DATE_DEPEND_ON_SUB_TABLE")]
        private void SetDeleteDateOfFirstTable()
        {
            ArrayList retList = null;
            int status = this._partsPosCodeUAcs.SearchAll(out retList, this._enterpriseCode);
            if (!status.Equals((int)ConstantManagement.DB_Status.ctDB_NORMAL)) return;
            if (retList == null || retList.Count.Equals(0)) return;

            // �������ʂ𓾈Ӑ�R�[�h�ŕ���
            IDictionary<int, IList<PartsPosCodeU>> partsPosCodeUListMap = new Dictionary<int, IList<PartsPosCodeU>>();
            foreach (PartsPosCodeU partsPosCodeU in retList)
            {
                if (!partsPosCodeUListMap.ContainsKey(partsPosCodeU.CustomerCode))
                {
                    partsPosCodeUListMap.Add(partsPosCodeU.CustomerCode, new List<PartsPosCodeU>());
                }
                partsPosCodeUListMap[partsPosCodeU.CustomerCode].Add(partsPosCodeU);
            }

            // �폜����ݒ�
            foreach (DataRow firstRow in this.Bind_DataSet.Tables[MAIN_TABLE].Rows)
            {
                // ���Ӑ�R�[�h���
                int customerCode = int.Parse(firstRow[M_CUSTOMERCODE].ToString());
                if (!partsPosCodeUListMap.ContainsKey(customerCode)) continue;

                // �폜�����~���ɒ��o
                int deletedRecordCount = 0;
                SortedList<DateTime, PartsPosCodeU> deletedPartsPosCodeUList = new SortedList<DateTime, PartsPosCodeU>(
                    new DateTimeUtil.ReverseComparer()
                );
                foreach (PartsPosCodeU partsPosCodeU in partsPosCodeUListMap[customerCode])
                {
                    if (partsPosCodeU.LogicalDeleteCode.Equals(0)) continue;

                    deletedRecordCount++;
                    if (!deletedPartsPosCodeUList.ContainsKey(partsPosCodeU.UpdateDateTime))
                    {
                        deletedPartsPosCodeUList.Add(partsPosCodeU.UpdateDateTime, partsPosCodeU);
                    }
                }

                // �S�č폜����Ă���ꍇ�A���߂̍폜����ݒ�
                string deleteDate = string.Empty;
                if (deletedRecordCount.Equals(partsPosCodeUListMap[customerCode].Count))
                {
                    deleteDate = deletedPartsPosCodeUList.Values[0].UpdateDateTimeJpInFormal;
                }

                firstRow[M_DELETEDATE] = deleteDate;
            }
        }
        // ADD 2009/03/25 �s��Ή�[12720]�F�u�폜�σf�[�^�̕\���v�͍ŏ�ʍ��ڂŐ��� ----------<<<<<

        /// <summary>
        /// ���ʃR�[�h�N���X�f�[�^�Z�b�g�W�J����(����)
        /// </summary>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <param name="partsPosCodeU">���ʃR�[�h�N���X</param>
        /// <param name="index">�f�[�^�Z�b�g�֓W�J����C���f�b�N�X</param>
        /// <remarks>
        /// <br>Note       : ���ʃR�[�h�N���X���f�[�^�Z�b�g�֊i�[���܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.17</br>
        /// </remarks>
        private void PartsPosCodeUToSecondDataSet(int customerCode, PartsPosCodeU partsPosCodeU, ref int index)
        {
            // ���ʃR�[�h�̒񋟋敪���`�F�b�N
            if (partsPosCodeU.Division != DIVISION_OFR)
            {
                // ���[�U�[�o�^�f�[�^
                if ((partsPosCodeU.PosDispOrder != 0) || (partsPosCodeU.TbsPartsCode != 0))
                {
                    // �\�����ʂ�BL�R�[�h�̉��ꂩ��0�ȊO�Ȃ珈���I��
                    return;
                }
            }
            else
            {
                // �񋟃f�[�^
                if (this._mainGridTable.ContainsKey(CreateHashKeySecond(partsPosCodeU)) == true)
                {
                    // �Y���f�[�^�����C��Grid�ɓo�^�ςȂ珈���I���i�d���`�F�b�N�j
                    return;
                }
            }

            // ���Ӑ�R�[�h�̃`�F�b�N
            if (customerCode != partsPosCodeU.CustomerCode)
            {
                // ���ʐݒ�p�ŁA���Ӑ�R�[�h���s��v�Ȃ珈���I��
                return;
            }

            // ���C��Grid�Ɋi�[����f�[�^��ݒ�
            if ((index < 0) || (this.Bind_DataSet.Tables[SECOND_TABLE].Rows.Count <= index))
            {
                // �V�K�Ɣ��f���āA�s��ǉ�����
                DataRow dataRow = this.Bind_DataSet.Tables[SECOND_TABLE].NewRow();
                this.Bind_DataSet.Tables[SECOND_TABLE].Rows.Add(dataRow);

                // index���s�̍ŏI�s�ԍ��ɂ���
                index = this.Bind_DataSet.Tables[SECOND_TABLE].Rows.Count - 1;
            }

            // �폜��
            if (partsPosCodeU.LogicalDeleteCode == 0)
            {
                this.Bind_DataSet.Tables[SECOND_TABLE].Rows[index][S_DELETEDATE] = "";
            }
            else
            {
                this.Bind_DataSet.Tables[SECOND_TABLE].Rows[index][S_DELETEDATE] = TDateTime.DateTimeToString("ggYY/MM/DD", partsPosCodeU.UpdateDateTime);
            }

            // ���ʃR�[�h
            this.Bind_DataSet.Tables[SECOND_TABLE].Rows[index][S_PARTSPOSCODE] = partsPosCodeU.SearchPartsPosCode.ToString("d02");

            // ���ʖ���
            this.Bind_DataSet.Tables[SECOND_TABLE].Rows[index][S_PARTSPOSNAME] = partsPosCodeU.SearchPartsPosName;

            // ���ʏ��GUID
            this.Bind_DataSet.Tables[SECOND_TABLE].Rows[index][S_PARTSPOSCODE_GUID] = CreateHashKeySecond(partsPosCodeU);

            // �n�b�V�������p��GUID�Z�b�g
            if (this._secondGridTable.ContainsKey(CreateHashKeySecond(partsPosCodeU)) == true)
            {
                this._secondGridTable.Remove(CreateHashKeySecond(partsPosCodeU));
            }
            this._secondGridTable.Add(CreateHashKeySecond(partsPosCodeU), partsPosCodeU);

            index++;

        }

        /// <summary>
        /// ���ʃR�[�h�N���X�f�[�^�Z�b�g�W�J����(BL����)
        /// </summary>
        /// <param name="partsPosCodeU">���ʃR�[�h�N���X</param>
        /// <param name="index">�f�[�^�Z�b�g�֓W�J����C���f�b�N�X</param>
        /// <remarks>
        /// <br>Note       : ���ʃR�[�h�N���X���ڍ�GRID�f�[�^�Z�b�g�֊i�[���܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.18</br>
        /// </remarks>
        private void PartsPosCodeUToThirdDataSet(int customerCode, PartsPosCodeU partsPosCodeU, ref int index)
        {
            // Form ���C��Grid�̏����擾
            string guid = (string)this.Bind_DataSet.Tables[SECOND_TABLE].Rows[this._secondDataIndex][S_PARTSPOSCODE_GUID];
            PartsPosCodeU secondPartsPosCodeU = ((PartsPosCodeU)this._secondGridTable[guid]).Clone();
            int mainDivision = secondPartsPosCodeU.Division;

            // �񋟋敪�̃`�F�b�N
            if (partsPosCodeU.Division != mainDivision)
            {
                // ���C��Grid�̒񋟋敪�ƈႤ�ꍇ�͏����I��
                return;
            }
            else
            {
                // ���C��Grid�ƒ񋟋敪����v
                if (partsPosCodeU.Division != DIVISION_OFR)
                {
                    // ���[�U�[�o�^�f�[�^
                    if ((partsPosCodeU.PosDispOrder == 0) || (partsPosCodeU.TbsPartsCode == 0))
                    {
                        // �\�����ʂ�BL�R�[�h�̉��ꂩ��0�̏ꍇ�͏����I��
                        return;
                    }
                }
            }

            // ���Ӑ�R�[�h�̃`�F�b�N
            if (customerCode != partsPosCodeU.CustomerCode)
            {
                // ���ʐݒ�p�ŁA���Ӑ�R�[�h���s��v�Ȃ珈���I��
                return;
            }

            // �ڍ�Grid�Ɋi�[����f�[�^��ݒ�
            if ((index < 0) || (this.Bind_DataSet.Tables[THIRD_TABLE].Rows.Count <= index))
            {
                // �V�K�Ɣ��f���āA�s��ǉ�����
                DataRow dataRow = this.Bind_DataSet.Tables[THIRD_TABLE].NewRow();
                this.Bind_DataSet.Tables[THIRD_TABLE].Rows.Add(dataRow);

                // index���s�̍ŏI�s�ԍ�����
                index = this.Bind_DataSet.Tables[THIRD_TABLE].Rows.Count - 1;
            }

            // �폜��
            if (partsPosCodeU.LogicalDeleteCode == 0)
            {
                this.Bind_DataSet.Tables[THIRD_TABLE].Rows[index][T_DELETEDATE] = "";
            }
            else
            {
                this.Bind_DataSet.Tables[THIRD_TABLE].Rows[index][T_DELETEDATE] = TDateTime.DateTimeToString("ggYY/MM/DD", partsPosCodeU.UpdateDateTime);
            }

            // BL����
            this.Bind_DataSet.Tables[THIRD_TABLE].Rows[index][T_TBSPARTCODE] = partsPosCodeU.TbsPartsCode.ToString("d05");

            // BL�i��
            this.Bind_DataSet.Tables[THIRD_TABLE].Rows[index][T_TBSPARTNAME] = partsPosCodeU.TbsPartsName;

            // BL���GUID
            this.Bind_DataSet.Tables[THIRD_TABLE].Rows[index][T_TBSPARTCODE_GUID] = CreateHashKeyThird(partsPosCodeU);

            // �n�b�V�������p��GUID�Z�b�g
            if (this._thirdGridTable.ContainsKey(CreateHashKeyThird(partsPosCodeU)) == true)
            {
                this._thirdGridTable.Remove(CreateHashKeyThird(partsPosCodeU));
            }
            this._thirdGridTable.Add(CreateHashKeyThird(partsPosCodeU), partsPosCodeU);

            index++;
        }

        /// <summary>
        /// ���ʃR�[�h�}�X�^ �N���X��ʓW�J����
        /// </summary>
        /// <param name="partsPosCodeU">���ʃR�[�h�}�X�^ �I�u�W�F�N�g</param>
        /// <remarks>
        /// <br>Note       : ���ʃR�[�h�}�X�^ �I�u�W�F�N�g�����ʂɃf�[�^��W�J���܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.18</br>
        /// </remarks>
        private void PartsPosCodeUToScreen(PartsPosCodeU[] partsPosCodeU)
        {
            int i = 0;
            int maxRow;
            DataRow bindRow;

            this.tNedit_CustomerCodeAllowZero.SetInt(partsPosCodeU[i].CustomerCode);    // ���Ӑ�R�[�h
            if (partsPosCodeU[i].CustomerCode == 0)
            {
                this.CustomerSnm_tEdit.Text = CUSTOMER_SNM_COMMON;                      // ���Ӑ旪��
            }
            else
            {
                this.CustomerSnm_tEdit.Text = partsPosCodeU[i].CustomerSnm;             // ���Ӑ旪��
            }
            this.PartsPosCode_tNedit.SetInt(partsPosCodeU[i].SearchPartsPosCode);       // ���ʃR�[�h
            this.PartsPosName_tEdit.Text = partsPosCodeU[i].SearchPartsPosName;         // ���ʖ���

            maxRow = partsPosCodeU.Length;
            for (i = 1; i < maxRow; i++)
            {
                bindRow = this._bindTable.NewRow();

                bindRow[MY_SCREEN_ID] = "";                                             // Grid��ID(��\��)
                bindRow[MY_SCREEN_ODER] = i;                                            // �\������
                bindRow[MY_SCREEN_TBSPARTS_CODE] = partsPosCodeU[i].TbsPartsCode.ToString("d05");       // BL�R�[�h
                bindRow[MY_SCREEN_TBSPARTS_NAME] = partsPosCodeU[i].TbsPartsName;       // BL�i��

                this._bindTable.Rows.Add(bindRow);
            }
        }

        /// <summary>
        /// ��ʏ�񕔈ʃR�[�h�}�X�^ �N���X�i�[����
        /// </summary>
        /// <param name="partsPosCodeUList">���ʃR�[�h�}�X�^ �I�u�W�F�N�g</param>
        /// <remarks>
        /// <br>Note       : ��ʏ�񂩂畔�ʃR�[�h�}�X�^ �I�u�W�F�N�g�Ƀf�[�^���i�[���܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.18</br>
        /// </remarks>
        private void DispToPartsPosCodeU(ref ArrayList partsPosCodeUList)
        {
            int index;
            int rowCnt = this._bindTable.Rows.Count;
            
            PartsPosCodeU partsPosCodeU;
            partsPosCodeUList = new ArrayList();
            
            for (index = 0; index <= rowCnt; index++)
            {
                partsPosCodeU = new PartsPosCodeU();
                
                partsPosCodeU.EnterpriseCode = this._enterpriseCode;                                            // ��ƃR�[�h
                partsPosCodeU.CustomerCode = this.tNedit_CustomerCodeAllowZero.GetInt();                        // ���Ӑ�R�[�h
                partsPosCodeU.SearchPartsPosCode = this.PartsPosCode_tNedit.GetInt();                           // ���ʃR�[�h

                if (index == 0)
                {
                    // ���C��GRID�p�̏��擾
                    partsPosCodeU.SearchPartsPosName = this.PartsPosName_tEdit.Text.TrimEnd();                  // ���ʖ���
                }
                else
                {
                    // ������BL���ނ�SKIP
                    string strBlCode = (string)this._bindTable.Rows[index - 1][MY_SCREEN_TBSPARTS_CODE];
                    if (strBlCode == "")
                    {
                        continue;
                    }

                    // �ڍ�GRID�p�̏��擾
                    partsPosCodeU.PosDispOrder = (int)this._bindTable.Rows[index - 1][MY_SCREEN_ODER];          // �\������
                    partsPosCodeU.TbsPartsCode = Int32.Parse(strBlCode);                                        // BL�R�[�h
                    partsPosCodeU.TbsPartsName = this._bindTable.Rows[index - 1][MY_SCREEN_TBSPARTS_NAME].ToString();   // BL�i��
                }
                partsPosCodeUList.Add(partsPosCodeU);
            }
        }

        /// <summary>
        /// �f�[�^�Z�b�g����\�z����
        /// </summary>
        /// <remarks>
        /// <br>Note       : DataSet�̗�����\�z���܂��B�f�[�^�Z�b�g�̗��񂪃t���[���̃r���[�p�O���b�h�̗�ɂȂ�܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.17</br>
        /// </remarks>
        private void DataSetColumnConstruction()
        {
            // ���C���e�[�u���̗��`
            DataTable _mainDt = new DataTable(MAIN_TABLE);

            // Add���s�����Ԃ��A��̕\�����ʂƂȂ�܂��B
            // ADD 2009/03/25 �s��Ή�[12720]���F�u�폜�σf�[�^�̕\���v�͍ŏ�ʍ��ڂŐ���
            _mainDt.Columns.Add(M_DELETEDATE, typeof(string));              // �폜��
            _mainDt.Columns.Add(M_CUSTOMERCODE, typeof(string));            // ���Ӑ�R�[�h
            _mainDt.Columns.Add(M_CUSTOMERNAME, typeof(string));            // ���Ӑ旪��
            this.Bind_DataSet.Tables.Add(_mainDt);

            // �Z�J���h�e�[�u���̗��`
            DataTable _secondDt = new DataTable(SECOND_TABLE);

            // Add���s�����Ԃ��A��̕\�����ʂƂȂ�܂��B
            _secondDt.Columns.Add(S_DELETEDATE, typeof(string));            // �폜��
            _secondDt.Columns.Add(S_PARTSPOSCODE, typeof(string));			// ���ʃR�[�h
            _secondDt.Columns.Add(S_PARTSPOSNAME, typeof(string));			// ���ʖ���
            _secondDt.Columns.Add(S_PARTSPOSCODE_GUID, typeof(string));     // ���ʏ��GUID

            this.Bind_DataSet.Tables.Add(_secondDt);

            // �T�[�h�e�[�u���̗��`
            DataTable _detailDt = new DataTable(THIRD_TABLE);

            // Add���s�����Ԃ��A��̕\�����ʂƂȂ�܂��B
            _detailDt.Columns.Add(T_DELETEDATE, typeof(string));			// �폜��
            _detailDt.Columns.Add(T_TBSPARTCODE, typeof(string));			// BL����
            _detailDt.Columns.Add(T_TBSPARTNAME, typeof(string));			// BL�i��
            _detailDt.Columns.Add(T_TBSPARTCODE_GUID, typeof(string));      // BL���GUID

            this.Bind_DataSet.Tables.Add(_detailDt);
        }

        /// <summary>
        /// ��ʏ����ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note       : ��ʂ̏����ݒ���s���܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.19</br>
        /// </remarks>
        private void ScreenInitialSetting()
        {
            // �X�L�[�}�̐ݒ�
            DataTableSchemaSetting();

            // GRID�̏����ݒ�
            GridInitialSetting();
        }

        /// <summary>
        /// ��ʍč\�z����
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : ���[�h�Ɋ�Â��ĉ�ʂ̍č\�z���s���܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.18</br>
        /// </remarks>
        private void ScreenReconstruction()
        {
            if (this._secondDataIndex < 0)
            {
                // �V�K���[�h
                this.Mode_Label.Text = INSERT_MODE;

                // ��ʓ��͋����䏈��
                ScreenPermissionControl(INSERT_MODE);

                // Fream��Index/Table�o�b�t�@�ێ�
                this._mainIndexBuffer = this._mainDataIndex;
                this._secondIndexBuffer = this._secondDataIndex;
                this._targetTableBuffer = this._targetTableName;

                //�N���[���쐬
                PartsPosCodeU partsPosCodeU = new PartsPosCodeU();
                // 2009.02.16 30413 ���� ���ʑw�ŐV�K�{�^���̑Ή� >>>>>>START
                if (this._mainDataIndex >= 0)
                {
                    string customerCode = (string)this.Bind_DataSet.Tables[MAIN_TABLE].Rows[this._mainDataIndex][M_CUSTOMERCODE];
                    partsPosCodeU = ((PartsPosCodeU)this._mainGridTable[customerCode]).Clone();

                    this.tNedit_CustomerCodeAllowZero.SetInt(partsPosCodeU.CustomerCode);
                    this.CustomerSnm_tEdit.Text = partsPosCodeU.CustomerSnm;
                }
                // 2009.02.16 30413 ���� ���ʑw�ŐV�K�{�^���̑Ή� <<<<<<END
                this._partsPosCodeUCloneList = new PartsPosCodeU[1];
                this._partsPosCodeUCloneList[0] = partsPosCodeU.Clone();
                
                // �O���b�h�s��ǉ�
                this.tbsPartsList_AddRow();

                // �t�H�[�J�X�ݒ�
                this.tNedit_CustomerCodeAllowZero.Focus();
            }
            else
            {
                // ���C��Grid + �ڍ�Grid�̍s�����擾
                int rowCnt = 0;         // �s���J�E���^(0�̓��C��Grid���A0�ȊO�͏ڍ�Grid���)
                int maxRow = this.Bind_DataSet.Tables[THIRD_TABLE].Rows.Count;
                PartsPosCodeU[] partsPosCodeUList = new PartsPosCodeU[maxRow + 1];

                // �I�𕔈ʂ̏����擾
                string partsGuid = (string)this.Bind_DataSet.Tables[SECOND_TABLE].Rows[this._secondDataIndex][S_PARTSPOSCODE_GUID];
                partsPosCodeUList[rowCnt] = ((PartsPosCodeU)this._secondGridTable[partsGuid]).Clone();
                rowCnt++;

                // BL�����擾
                for (; rowCnt <= maxRow; rowCnt++)
                {
                    string guid = (string)this.Bind_DataSet.Tables[THIRD_TABLE].Rows[rowCnt - 1][T_TBSPARTCODE_GUID];
                    partsPosCodeUList[rowCnt] = ((PartsPosCodeU)this._thirdGridTable[guid]).Clone();
                }

                if (partsPosCodeUList[0].LogicalDeleteCode == 0)
                {
                    // ��ʓ��͋����䏈��
                    if (partsPosCodeUList[0].Division == DIVISION_OFR)
                    {
                        // �Q�ƃ��[�h
                        this.Mode_Label.Text = REFERENCE_MODE;

                        // ��ʓ��͋����䏈��
                        ScreenPermissionControl(REFERENCE_MODE);

                        // ��ʓW�J����
                        PartsPosCodeUToScreen(partsPosCodeUList);

                        //�N���[���쐬
                        this._partsPosCodeUCloneList = new PartsPosCodeU[maxRow + 1];
                        for (int i = 0; i < maxRow + 1; i++)
                        {
                            this._partsPosCodeUCloneList[i] = partsPosCodeUList[i].Clone();
                        }
                        
                        // �t�H�[�J�X�ݒ�
                        this.Cancel_Button.Focus();
                    }
                    else
                    {
                        // �X�V���[�h
                        this.Mode_Label.Text = UPDATE_MODE;

                        // ��ʓ��͋����䏈��
                        ScreenPermissionControl(UPDATE_MODE);

                        // ��ʓW�J����
                        PartsPosCodeUToScreen(partsPosCodeUList);
                        
                        //�N���[���쐬
                        this._partsPosCodeUCloneList = new PartsPosCodeU[maxRow + 1];
                        for (int i = 0; i < maxRow + 1; i++)
                        {
                            this._partsPosCodeUCloneList[i] = partsPosCodeUList[i].Clone();
                        }

                        // �X�V���[�h�̏ꍇ�A�ǉ��p�̍s��p�ӂ���
                        this.tbsPartsList_AddRow();

                        // �t�H�[�J�X�ݒ�
                        this.PartsPosName_tEdit.Focus();
                        this.PartsPosName_tEdit.SelectAll();
                    }
                }
                else
                {
                    // �폜���[�h
                    this.Mode_Label.Text = DELETE_MODE;

                    // ��ʓ��͋����䏈��
                    ScreenPermissionControl(DELETE_MODE);

                    // ��ʓW�J����
                    PartsPosCodeUToScreen(partsPosCodeUList);

                    // 2008.10.31 30413 ���� �폜���[�h���̓O���b�h�I���͍s��Ȃ� >>>>>>START
                    this.tbsPartsList_ultraGrid.Rows[0].Selected = false;
                    this.tbsPartsList_ultraGrid.ActiveCell = null;
                    this.tbsPartsList_ultraGrid.ActiveRow = null;
                    // 2008.10.31 30413 ���� �폜���[�h���̓O���b�h�I���͍s��Ȃ� <<<<<<END
                    
                    //�N���[���쐬
                    this._partsPosCodeUCloneList = new PartsPosCodeU[maxRow + 1];
                    for (int i = 0; i < maxRow + 1; i++)
                    {
                        this._partsPosCodeUCloneList[i] = partsPosCodeUList[i].Clone();
                    }
                    
                    // �t�H�[�J�X�ݒ�
                    this.Delete_Button.Focus();
                }

                // Fream��Index/Table�o�b�t�@�ێ�
                this._mainIndexBuffer = this._mainDataIndex;
                this._secondIndexBuffer = this._secondDataIndex;
                this._targetTableBuffer = this._targetTableName;
            }
        }

        /// <summary>
        /// ��ʋ����䏈��
        /// </summary>
        /// <param name="screenMode">��ʃ��[�h</param>
        /// <remarks>
        /// <br>Note       : ��ʃ��[�h���ɓ��́^�{�^���̋��𐧌䂵�܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.17</br>
        /// </remarks>
        private void ScreenPermissionControl(string screenMode)
        {
            // �V�K
            if (screenMode.Equals(INSERT_MODE))
            {
                // �{�^���ݒ�
                this.CustomerCd_GuideBtn.Enabled = true;
                this.Ok_Button.Visible = true;
                this.Delete_Button.Visible = false;
                this.Revive_Button.Visible = false;
                this.DeleteRow_Button.Visible = true;
                this.DeleteRow_Button.Enabled = true;
                this.Guid_Button.Visible = true;
                this.Guid_Button.Enabled = true;
                // --- ADD 2009/03/23 �c�Č�No.14�Ή�------------------------------------------------------>>>>>
                this.Renewal_Button.Visible = true;
                // --- ADD 2009/03/23 �c�Č�No.14�Ή�------------------------------------------------------<<<<<

                // ���͐ݒ�
                this.tNedit_CustomerCodeAllowZero.Enabled = true;
                this.PartsPosCode_tNedit.Enabled = true;
                this.PartsPosName_tEdit.Enabled = true;
                this.tbsPartsList_ultraGrid.Enabled = true;
                this.tbsPartsList_ultraGrid.DisplayLayout.Bands[0].Columns[MY_SCREEN_GUID].CellActivation = Activation.NoEdit;
            }
            // �X�V
            else if (screenMode.Equals(UPDATE_MODE))
            {
                // �{�^���ݒ�
                this.CustomerCd_GuideBtn.Enabled = false;
                this.Ok_Button.Visible = true;
                this.Delete_Button.Visible = false;
                this.Revive_Button.Visible = false;
                this.DeleteRow_Button.Visible = true;
                this.DeleteRow_Button.Enabled = true;
                this.Guid_Button.Visible = true;
                this.Guid_Button.Enabled = true;
                // --- ADD 2009/03/23 �c�Č�No.14�Ή�------------------------------------------------------>>>>>
                this.Renewal_Button.Visible = true;
                // --- ADD 2009/03/23 �c�Č�No.14�Ή�------------------------------------------------------<<<<<

                // ���͐ݒ�
                this.tNedit_CustomerCodeAllowZero.Enabled = false;
                this.PartsPosCode_tNedit.Enabled = false;
                this.PartsPosName_tEdit.Enabled = true;
                this.tbsPartsList_ultraGrid.Enabled = true;
                this.tbsPartsList_ultraGrid.DisplayLayout.Bands[0].Columns[MY_SCREEN_GUID].CellActivation = Activation.NoEdit;
            }
            // �폜
            else if (screenMode.Equals(DELETE_MODE))
            {
                // �{�^���ݒ�
                this.CustomerCd_GuideBtn.Enabled = false;
                this.Ok_Button.Visible = false;
                this.Delete_Button.Visible = true;
                this.Revive_Button.Visible = true;
                this.DeleteRow_Button.Visible = true;
                this.DeleteRow_Button.Enabled = false;
                this.Guid_Button.Visible = true;
                this.Guid_Button.Enabled = false;
                // --- ADD 2009/03/23 �c�Č�No.14�Ή�------------------------------------------------------>>>>>
                this.Renewal_Button.Visible = false;
                // --- ADD 2009/03/23 �c�Č�No.14�Ή�------------------------------------------------------<<<<<

                // ���͐ݒ�
                this.tNedit_CustomerCodeAllowZero.Enabled = false;
                this.PartsPosCode_tNedit.Enabled = false;
                this.PartsPosName_tEdit.Enabled = false;
                this.tbsPartsList_ultraGrid.Enabled = false;
                this.tbsPartsList_ultraGrid.DisplayLayout.Bands[0].Columns[MY_SCREEN_GUID].CellActivation = Activation.Disabled;
            }
            // �Q��
            else if (screenMode.Equals(REFERENCE_MODE))
            {
                // �{�^���ݒ�
                this.CustomerCd_GuideBtn.Enabled = false;
                this.Ok_Button.Visible = false;
                this.Delete_Button.Visible = false;
                this.Revive_Button.Visible = false;
                this.DeleteRow_Button.Visible = true;
                this.DeleteRow_Button.Enabled = false;
                this.Guid_Button.Visible = true;
                this.Guid_Button.Enabled = false;
                // --- ADD 2009/03/23 �c�Č�No.14�Ή�------------------------------------------------------>>>>>
                this.Renewal_Button.Visible = false;
                // --- ADD 2009/03/23 �c�Č�No.14�Ή�------------------------------------------------------<<<<<

                // ���͐ݒ�
                this.tNedit_CustomerCodeAllowZero.Enabled = false;
                this.PartsPosCode_tNedit.Enabled = false;
                this.PartsPosName_tEdit.Enabled = false;
                this.tbsPartsList_ultraGrid.Enabled = false;
                this.tbsPartsList_ultraGrid.DisplayLayout.Bands[0].Columns[MY_SCREEN_GUID].CellActivation = Activation.Disabled;
            }
        }

        /// <summary>
        /// ��ʏ���������
        /// </summary>
        /// <remarks>
        /// <br>Note       : ��ʂ̏��������s���܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.17</br>
        /// </remarks>
        private void ScreenClear()
        {
            this.tNedit_CustomerCodeAllowZero.Clear();  // ���Ӑ�R�[�h
            this.CustomerSnm_tEdit.Text = "";           // ���Ӑ旪��
            this.PartsPosCode_tNedit.Clear();           // ���ʃR�[�h
            this.PartsPosName_tEdit.Text = "";          // ���ʖ���

            this._bindTable.Rows.Clear();               // Grid�s�̃N���A

        }

        /// <summary>
        /// ��ʓ��͏��s���`�F�b�N����
        /// </summary>
        /// <param name="control">�s���ΏۃR���g���[��</param>
        /// <param name="message">���b�Z�[�W</param>
        /// <param name="loginID">���O�C��ID</param>
        /// <returns>�`�F�b�N���ʁitrue:OK�^false:NG�j</returns>
        /// <remarks>
        /// <br>Note       : ��ʓ��͏��̕s���`�F�b�N���s���܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.17</br>
        /// </remarks>
        private bool ScreenDataCheck(ref Control control, ref string message, string loginID)
        {
            // ���ʃR�[�h
            if (this.PartsPosCode_tNedit.Text == "0" || this.PartsPosCode_tNedit.Text.Trim() == "")
            {
                control = this.PartsPosCode_tNedit;
                message = this.PartsPosCode_Label.Text + "����͂��ĉ������B";
                return false;
            }

            // Grid
            if (this._bindTable.Rows.Count == 0)
            {
                control = this.tbsPartsList_ultraGrid;
                message = "BL���ނ��P���ȏ�o�^���ĉ������B";
                return false;
            }
            else if (this._bindTable.Rows.Count > 0)
            {
                int count = 0;
                for (int i = 0; i < this._bindTable.Rows.Count; i++)
                {
                    string tbsPartsCode = (string)this._bindTable.Rows[i][MY_SCREEN_TBSPARTS_CODE];
                    if (tbsPartsCode.Trim() != "")
                    {
                        count++;
                    }
                }
                if (count == 0)
                {
                    control = this.tbsPartsList_ultraGrid;
                    message = "BL���ނ��o�^����Ă��܂���B";
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// ���ʃR�[�h�}�X�^ ���o�^����
        /// </summary>
        /// <returns>�o�^���ʁitrue:OK�^false:NG�j</returns>
        /// <remarks>
        /// <br>Note       : ���ʃR�[�h�}�X�^ ���o�^���s���܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.19</br>
        /// </remarks>
        private bool SaveProc()
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            Control control = null;
            string message = null;
            string loginID = "";

            ArrayList updateList = new ArrayList();
            ArrayList deleteList = new ArrayList();

            // ��ʓ��̓`�F�b�N
            if (!ScreenDataCheck(ref control, ref message, loginID))
            {
                TMsgDisp.Show(
                    this,								// �e�E�B���h�E�t�H�[��
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,	// �G���[���x��
                    PG_ID,      						// �A�Z���u���h�c�܂��̓N���X�h�c
                    message,							// �\�����郁�b�Z�[�W 
                    0,									// �X�e�[�^�X�l
                    MessageBoxButtons.OK);				// �\������{�^��

                control.Focus();
                return false;
            }

            if (this._secondDataIndex >= 0)
            {
                // �X�V���́A�X�V�Ώۂƍ폜�Ώۂ��擾
                this.UpdateCompare(out updateList, out deleteList);
                
                // �폜�Ώۂ�����ΊY�����R�[�h���폜
                if (deleteList.Count != 0)
                {
                    status = this._partsPosCodeUAcs.Delete(deleteList);
                }
            }
            else
            {
                //�V�K�̏ꍇ�A��ʏ��������N���X�ɐݒ�
                this.DispToPartsPosCodeU(ref updateList);
            }

            // �o�^�^�X�V����
            if (status == 0)
            {
                // �폜�������s�����ꍇ�A�������Ă��邱�Ƃ��O��
                status = this._partsPosCodeUAcs.Write(ref updateList);
            }
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_DUPLICATE:
                    {
                        TMsgDisp.Show(
                            this,								// �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_EXCLAMATION,	// �G���[���x��
                            PG_ID,				        		// �A�Z���u���h�c�܂��̓N���X�h�c
                            ERR_DPR_MSG,						// �\�����郁�b�Z�[�W 
                            status,								// �X�e�[�^�X�l
                            MessageBoxButtons.OK);				// �\������{�^��

                        this.PartsPosCode_tNedit.Focus();
                        return false;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        ExclusiveTransaction(status, TMsgDisp.OPE_UPDATE, this._partsPosCodeUAcs);

                        if (UnDisplaying != null)
                        {
                            MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                            UnDisplaying(this, me);
                        }

                        this.DialogResult = DialogResult.Cancel;
                        this._mainIndexBuffer = -2;
                        this._secondIndexBuffer = -2;
                        
                        if (CanClose == true)
                        {
                            this.Close();
                        }
                        else
                        {
                            this.Hide();
                        }

                        return false;
                    }
                default:
                    {
                        TMsgDisp.Show(
                            this,								// �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_STOPDISP,	// �G���[���x��
                            PG_ID,      						// �A�Z���u���h�c�܂��̓N���X�h�c
                            PG_NAME,							// �v���O��������
                            "SaveProc",							// ��������
                            TMsgDisp.OPE_UPDATE,				// �I�y���[�V����
                            ERR_UPDT_MSG,						// �\�����郁�b�Z�[�W 
                            status,								// �X�e�[�^�X�l
                            this._partsPosCodeUAcs,				// �G���[�����������I�u�W�F�N�g
                            MessageBoxButtons.OK,				// �\������{�^��
                            MessageBoxDefaultButton.Button1);	// �����\���{�^��

                        if (UnDisplaying != null)
                        {
                            MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                            UnDisplaying(this, me);
                        }

                        this.DialogResult = DialogResult.Cancel;
                        this._mainIndexBuffer = -2;
                        this._secondIndexBuffer = -2;
                        
                        if (CanClose == true)
                        {
                            this.Close();
                        }
                        else
                        {
                            this.Hide();
                        }

                        return false;
                    }
            }

            // DataSet�W�J����
            int index = 0;
            int delCnt = 1;         // �폜�͏�l�߂̂��߁A�폜����������ێ����đΉ�

            //int customerCode = int.Parse((string)this.Bind_DataSet.Tables[MAIN_TABLE].Rows[this._mainDataIndex][M_CUSTOMERCODE]);
            int customerCode;
                    
            if (this._mainDataIndex >= 0)
            {
                // �폜�\��DataSet�̍s�����擾
                int delOK = deleteList.Count - updateList.Count;
                
                foreach (PartsPosCodeU partsPosCodeU in deleteList)
                {
                    // �폜���R�[�h���ڍ�Grid��Table����폜
                    this._thirdGridTable.Remove(CreateHashKeyThird(partsPosCodeU));
                    
                    if(delOK > 0)
                    {
                        // �X�V���R�[�h�����f����Ȃ�DataSet�s���폜
                        index = partsPosCodeU.PosDispOrder - delCnt;
                        this.Bind_DataSet.Tables[THIRD_TABLE].Rows[index].Delete();
                        delOK--;
                    }
                    delCnt++;
                }
                
                // ���Ӑ�R�[�h���擾
                customerCode = int.Parse((string)this.Bind_DataSet.Tables[MAIN_TABLE].Rows[this._mainDataIndex][M_CUSTOMERCODE]);

                // 2009.02.16 30413 ���� ���ʑw�ŐV�K�{�^���̑Ή� >>>>>>START
                if (this._secondDataIndex < 0)
                {
                    // ���C��Grid��DataSet�ɒǉ�
                    index = this._mainGridTable.Count;
                    PartsPosCodeUToDataSet(((PartsPosCodeU)updateList[0]).Clone(), ref index);

                    customerCode = int.Parse((string)this.Bind_DataSet.Tables[MAIN_TABLE].Rows[index - 1][M_CUSTOMERCODE]);
                }
                // 2009.02.16 30413 ���� ���ʑw�ŐV�K�{�^���̑Ή� <<<<<<END
                
                // �X�V���R�[�h��DataSet�ɔ��f
                foreach (PartsPosCodeU partsPosCodeU in updateList)
                {
                    //// ���C��Grid��DataSet���X�V
                    //index = this._mainDataIndex;
                    //PartsPosCodeUToDataSet(partsPosCodeU.Clone(), ref index);
                    // �Z�J���hGrid��DataSet���X�V
                    index = this._secondDataIndex;
                    PartsPosCodeUToSecondDataSet(customerCode, partsPosCodeU.Clone(), ref index);
                    // 2009.02.16 30413 ���� ���ʑw�ŐV�K�{�^���̑Ή� >>>>>>START
                    // �T�[�hGrid
                    //index = partsPosCodeU.PosDispOrder - 1;
                    //PartsPosCodeUToThirdDataSet(customerCode, partsPosCodeU.Clone(), ref index);
                    if (this._secondDataIndex >= 0)
                    {
                        index = partsPosCodeU.PosDispOrder - 1;
                        PartsPosCodeUToThirdDataSet(customerCode, partsPosCodeU.Clone(), ref index);
                    }
                    // 2009.02.16 30413 ���� ���ʑw�ŐV�K�{�^���̑Ή� <<<<<<END
                }
            }
            else
            {
                // ���C��Grid��DataSet�ɒǉ�
                index = this._mainGridTable.Count;
                PartsPosCodeUToDataSet(((PartsPosCodeU)updateList[0]).Clone(), ref index);
                
                //// �V�K�o�^���R�[�h��DataSet�ɔ��f
                //foreach (PartsPosCodeU partsPosCodeU in updateList)
                //{
                //    // �Z�J���hGrid��DataSet�ɒǉ�
                //    index = this._secondDataIndex;
                //    PartsPosCodeUToSecondDataSet(customerCode, partsPosCodeU.Clone(), ref index);
                //    break;
                //}
            }

            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                UnDisplaying(this, me);
            }

            this.DialogResult = DialogResult.OK;
            this._mainIndexBuffer = -2;
            this._secondIndexBuffer = -2;

            if (CanClose == true)
            {
                this.Close();
            }
            else
            {
                this.Hide();
            }

            return true;
        }

        /// <summary>
        /// �r������
        /// </summary>
        /// <param name="operation">�I�y���[�V����</param>
        /// <param name="erObject">�G���[�I�u�W�F�N�g</param>
        /// <param name="status">�X�e�[�^�X</param>
        /// <remarks>
        /// <br>Note       : �f�[�^�X�V���̔r���������s���܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.17</br>
        /// </remarks>
        private void ExclusiveTransaction(int status, string operation, object erObject)
        {
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    {
                        TMsgDisp.Show(
                            this,								// �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_EXCLAMATION,	// �G���[���x��
                            PG_ID,      						// �A�Z���u���h�c�܂��̓N���X�h�c
                            PG_NAME,							// �v���O��������
                            "ExclusiveTransaction",				// ��������
                            operation,							// �I�y���[�V����
                            ERR_800_MSG,						// �\�����郁�b�Z�[�W 
                            status,								// �X�e�[�^�X�l
                            erObject,							// �G���[�����������I�u�W�F�N�g
                            MessageBoxButtons.OK,				// �\������{�^��
                            MessageBoxDefaultButton.Button1);	// �����\���{�^��
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        TMsgDisp.Show(
                            this,								// �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_EXCLAMATION,	// �G���[���x��
                            PG_ID,		        				// �A�Z���u���h�c�܂��̓N���X�h�c
                            PG_NAME,							// �v���O��������
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
        }

        /// <summary>
        /// �񋟕��ʃK�C�h�N������
        /// </summary>
        /// <param name="partsPosCodeU">���ʃR�[�h�}�X�^�I�u�W�F�N�g</param>
        /// <returns>����(0:OK, 1:Cancel)</returns>
        /// <remarks>
        /// <br>Note       : �񋟕��ʃR�[�h�K�C�h�̋N�����s���܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.17</br>
        /// </remarks>
        private int ShowPartsPosCodeGuide(out PartsPosCodeU partsPosCodeU)
        {
            // ��ʂ���񋟕��ʃR�[�h���擾
            int partsPosCode = this.PartsPosCode_tNedit.GetInt();
            partsPosCodeU = new PartsPosCodeU();

            if (partsPosCode != 0)
            {
                // �K�C�h�\��
                return this._partsPosCodeUAcs.ExecuteGuid(partsPosCode, LoginInfoAcquisition.EnterpriseCode, out partsPosCodeU);
            }
            else
            {
                // ���ʃR�[�h�������͂̏ꍇ�̓K�C�h�\�����s��Ȃ�
                return -1;
            }
        }

        /// <summary>
        /// BL���ރK�C�h�N������
        /// </summary>
        /// <param name="blGoodsCdUMnt">BL���ރ}�X�^�I�u�W�F�N�g</param>
        /// <returns>����(0:OK, 1:Cancel)</returns>
        /// <remarks>
        /// <br>Note       : BL���ރK�C�h�̋N�����s���܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.19</br>
        /// </remarks>
        private int ShowBLGoodsCdGuide(out BLGoodsCdUMnt blGoodsCdUMnt)
        {
            blGoodsCdUMnt = new BLGoodsCdUMnt();

            return this._blGoodsCdAcs.ExecuteGuid(LoginInfoAcquisition.EnterpriseCode, out blGoodsCdUMnt);
        }

        /// <summary>
        /// HashTable�p�L�[�쐬(MAIN�e�[�u���p)
        /// </summary>
        /// <param name="partsPosCodeU">���ʃR�[�h�}�X�^�I�u�W�F�N�g</param>
        /// <returns>Hash�e�[�u���p�L�[</returns>
        /// <remarks>
        /// <br>Note       : ���ʃR�[�h�}�X�^���烁�C��Grid�̃n�b�V���e�[�u���p�̃L�[���쐬���܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.10.20</br>
        /// </remarks>
        private string CreateHashKeyMain(PartsPosCodeU partsPosCodeU)
        {
            string strHashKey = partsPosCodeU.CustomerCode.ToString("d08");
            return strHashKey;
        }

        /// <summary>
        /// HashTable�p�L�[�쐬
        /// </summary>
        /// <param name="partsPosCodeU">���ʃR�[�h�}�X�^�I�u�W�F�N�g</param>
        /// <returns>Hash�e�[�u���p�L�[</returns>
        /// <remarks>
        /// <br>Note       : ���ʃR�[�h�}�X�^���烁�C��Grid�̃n�b�V���e�[�u���p�̃L�[���쐬���܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.17</br>
        /// </remarks>
        private string CreateHashKeySecond(PartsPosCodeU partsPosCodeU)
        {
            string strHashKey = partsPosCodeU.SearchPartsPosCode.ToString("d04") + "-" + partsPosCodeU.Division.ToString("d02");
            return strHashKey;
        }

        /// <summary>
        /// HashTable�p�L�[�쐬
        /// </summary>
        /// <param name="partsPosCodeU">���ʃR�[�h�}�X�^�I�u�W�F�N�g</param>
        /// <returns>Hash�e�[�u���p�L�[</returns>
        /// <remarks>
        /// <br>Note       : ���ʃR�[�h�}�X�^����ڍ�GRID�̃n�b�V���e�[�u���p�̃L�[���쐬���܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.17</br>
        /// </remarks>
        private string CreateHashKeyThird(PartsPosCodeU partsPosCodeU)
        {
            string strHashKey = partsPosCodeU.PosDispOrder.ToString("d03") + "-" + partsPosCodeU.TbsPartsCode.ToString("d08");
            return strHashKey;
        }

        /// <summary>
        /// �O���b�h�o�C���h����
        /// </summary>
        /// <remarks>
        /// <br>Note	   : �z�񍀖ڂ��O���b�h�փo�C���h���܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008/06/17</br>
        /// </remarks>
        private void DataTableSchemaSetting()
        {
            try
            {
                // �X�L�[�}�̐ݒ�
                _bindTable.Columns.Add(MY_SCREEN_ID, typeof(string));
                _bindTable.Columns.Add(MY_SCREEN_ODER, typeof(int));
                _bindTable.Columns.Add(MY_SCREEN_TBSPARTS_CODE, typeof(string));
                _bindTable.Columns.Add(MY_SCREEN_GUID, typeof(Button));
                _bindTable.Columns[MY_SCREEN_GUID].Caption = "";
                _bindTable.Columns.Add(MY_SCREEN_TBSPARTS_NAME, typeof(string));
            }
            catch (DuplicateNameException e)    // HACK:�폜�̌�A�A�����ďC������Ɣ����i�������Ă�����͂���j
            {
                Debug.Assert(false, e.ToString());
            }
        }

        /// <summary>
        ///	UI��ʂ�GRID�����ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note	   : GRID�̏����ݒ���s���܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008/06/17</br>
        /// </remarks>
        private void GridInitialSetting()
        {
            // �f�[�^�\�[�X�֒ǉ�
            this.tbsPartsList_ultraGrid.DataSource = _bindTable;

            // �O���b�h�̔w�i�F
            this.tbsPartsList_ultraGrid.DisplayLayout.Appearance.BackColor = Color.White;
            this.tbsPartsList_ultraGrid.DisplayLayout.Appearance.BackColor2 = Color.FromArgb(198, 219, 255);
            this.tbsPartsList_ultraGrid.DisplayLayout.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;

            // �s�̒ǉ��s��
            this.tbsPartsList_ultraGrid.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No;
            // �s�̃T�C�Y�ύX�s��
            this.tbsPartsList_ultraGrid.DisplayLayout.Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.Fixed;
            // �s�̍폜�s��
            this.tbsPartsList_ultraGrid.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.True;
            // ��̈ړ��s��
            this.tbsPartsList_ultraGrid.DisplayLayout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.NotAllowed;
            // ��̃T�C�Y�ύX�s��
            this.tbsPartsList_ultraGrid.DisplayLayout.Override.AllowColSizing = Infragistics.Win.UltraWinGrid.AllowColSizing.None;
            // ��̌����s��
            this.tbsPartsList_ultraGrid.DisplayLayout.Override.AllowColSwapping = Infragistics.Win.UltraWinGrid.AllowColSwapping.NotAllowed;
            // �t�B���^�̎g�p�s��
            this.tbsPartsList_ultraGrid.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
            // ���[�U�[�̃f�[�^������������
            //this.tbsPartsList_ultraGrid.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.True;

            //this.tbsPartsList_ultraGrid.DisplayLayout.Override.CardAreaAppearance.BackColor = System.Drawing.Color.Transparent;

            // �^�C�g���̊O�ϐݒ�
            this.tbsPartsList_ultraGrid.DisplayLayout.Override.HeaderAppearance.BackColor = Color.FromArgb(89, 135, 214);
            this.tbsPartsList_ultraGrid.DisplayLayout.Override.HeaderAppearance.BackColor2 = Color.FromArgb(7, 59, 150);
            this.tbsPartsList_ultraGrid.DisplayLayout.Override.HeaderAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.tbsPartsList_ultraGrid.DisplayLayout.Override.HeaderAppearance.ForeColor = Color.White;
            this.tbsPartsList_ultraGrid.DisplayLayout.Override.HeaderAppearance.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;

            // �O���b�h�̑I����@��ݒ�i�Z���P�̂̑I���̂݋��j
            //this.tbsPartsList_ultraGrid.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.Single;
            this.tbsPartsList_ultraGrid.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.tbsPartsList_ultraGrid.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Single;
            // �݂��Ⴂ�̍s�̐F��ύX
            this.tbsPartsList_ultraGrid.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.Lavender;
            // �s�Z���N�^�\������
            this.tbsPartsList_ultraGrid.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True;
            // �X�N���[���o�[��\��
            //this.tbsPartsList_ultraGrid.DisplayLayout.Scrollbars = Infragistics.Win.UltraWinGrid.Scrollbars.None;
            // �A�N�e�B�u�Z���̔w�i�F
            //this.tbsPartsList_ultraGrid.DisplayLayout.Override.ActiveCellAppearance.BackColor = Color.White;
            //this.tbsPartsList_ultraGrid.DisplayLayout.Override.ActiveCellAppearance.BackColor2 = Color.FromArgb(251, 230, 148);
            //this.tbsPartsList_ultraGrid.DisplayLayout.Override.ActiveCellAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            //this.tbsPartsList_ultraGrid.DisplayLayout.Override.ActiveCellAppearance.ForeColor = Color.Black;

            this.tbsPartsList_ultraGrid.DisplayLayout.Override.EditCellAppearance.BackColor = Color.FromArgb(247, 227, 156);
            this.tbsPartsList_ultraGrid.DisplayLayout.Override.ActiveCellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
            this.tbsPartsList_ultraGrid.DisplayLayout.Override.EditCellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
            this.tbsPartsList_ultraGrid.DisplayLayout.Override.CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
            //this.tbsPartsList_ultraGrid.DisplayLayout.Override.RowAppearance.BorderColor = Color.FromArgb(1, 68 ,208);

            // �uID�v�͕ҏW�s�i�Œ荀�ڂƂ��Đݒ�j
            this.tbsPartsList_ultraGrid.DisplayLayout.Bands[0].Columns[MY_SCREEN_ODER].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            this.tbsPartsList_ultraGrid.DisplayLayout.Bands[0].Columns[MY_SCREEN_ODER].TabStop = false;
            this.tbsPartsList_ultraGrid.DisplayLayout.Bands[0].Columns[MY_SCREEN_ODER].CellAppearance.BackColor = Color.FromArgb(89, 135, 214);
            this.tbsPartsList_ultraGrid.DisplayLayout.Bands[0].Columns[MY_SCREEN_ODER].CellAppearance.BackColor2 = Color.FromArgb(7, 59, 150);
            this.tbsPartsList_ultraGrid.DisplayLayout.Bands[0].Columns[MY_SCREEN_ODER].CellAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.tbsPartsList_ultraGrid.DisplayLayout.Bands[0].Columns[MY_SCREEN_ODER].CellAppearance.ForeColor = Color.White;

            // BL�R�[�h��̐ݒ�
            this.tbsPartsList_ultraGrid.DisplayLayout.Bands[0].Columns[MY_SCREEN_TBSPARTS_CODE].CellActivation = Activation.AllowEdit;
            this.tbsPartsList_ultraGrid.DisplayLayout.Bands[0].Columns[MY_SCREEN_TBSPARTS_CODE].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            this.tbsPartsList_ultraGrid.DisplayLayout.Bands[0].Columns[MY_SCREEN_TBSPARTS_CODE].TabStop = true;

            // �K�C�h�{�^���̐ݒ�
            this.tbsPartsList_ultraGrid.DisplayLayout.Bands[0].Columns[MY_SCREEN_GUID].CellActivation = Activation.NoEdit;
            this.tbsPartsList_ultraGrid.DisplayLayout.Bands[0].Columns[MY_SCREEN_GUID].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button;
            this.tbsPartsList_ultraGrid.DisplayLayout.Bands[0].Columns[MY_SCREEN_GUID].ButtonDisplayStyle = ButtonDisplayStyle.Always;
            this.tbsPartsList_ultraGrid.DisplayLayout.Bands[0].Columns[MY_SCREEN_GUID].CellButtonAppearance.Image = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];
            this.tbsPartsList_ultraGrid.DisplayLayout.Bands[0].Columns[MY_SCREEN_GUID].TabStop = true;

            // BL�i����̐ݒ�
            this.tbsPartsList_ultraGrid.DisplayLayout.Bands[0].Columns[MY_SCREEN_TBSPARTS_NAME].CellActivation = Activation.NoEdit;
            this.tbsPartsList_ultraGrid.DisplayLayout.Bands[0].Columns[MY_SCREEN_TBSPARTS_NAME].TabStop = false;

            //�������\����
            this.tbsPartsList_ultraGrid.DisplayLayout.Bands[0].Columns[MY_SCREEN_ID].Hidden = true;

            // �Z���̕��̐ݒ�
            this.tbsPartsList_ultraGrid.DisplayLayout.Bands[0].Columns[MY_SCREEN_ODER].Width = 50;
            this.tbsPartsList_ultraGrid.DisplayLayout.Bands[0].Columns[MY_SCREEN_TBSPARTS_CODE].Width = 60;
            this.tbsPartsList_ultraGrid.DisplayLayout.Bands[0].Columns[MY_SCREEN_GUID].Width = 20;
            this.tbsPartsList_ultraGrid.DisplayLayout.Bands[0].Columns[MY_SCREEN_TBSPARTS_NAME].Width = 430;

            // ValueList��ݒ肷��
            //this.tbsPartsList_ultraGrid.DisplayLayout.Bands[0].Columns[ MY_SCREEN_PRINTDIV_TITLE ].Style			= Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            //this.tbsPartsList_ultraGrid.DisplayLayout.Bands[0].Columns[ MY_SCREEN_PRINTDIV_TITLE ].ValueList		= this.tbsPartsList_ultraGrid.DisplayLayout.ValueLists[ MY_SCREEN_PRINTDIV_TITLE ];

            // �I���s�̊O�ϐݒ�
            this.tbsPartsList_ultraGrid.DisplayLayout.Override.SelectedRowAppearance.BackColor = System.Drawing.Color.FromArgb(251, 230, 148);
            this.tbsPartsList_ultraGrid.DisplayLayout.Override.SelectedRowAppearance.BackColor2 = System.Drawing.Color.FromArgb(238, 149, 21);
            this.tbsPartsList_ultraGrid.DisplayLayout.Override.SelectedRowAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.tbsPartsList_ultraGrid.DisplayLayout.Override.SelectedRowAppearance.ForeColor = System.Drawing.Color.Black;
            this.tbsPartsList_ultraGrid.DisplayLayout.Override.SelectedRowAppearance.BackColorDisabled = System.Drawing.Color.FromArgb(251, 230, 148);
            this.tbsPartsList_ultraGrid.DisplayLayout.Override.SelectedRowAppearance.BackColorDisabled2 = System.Drawing.Color.FromArgb(238, 149, 21);
            // �A�N�e�B�u�s�̊O�ϐݒ�
            this.tbsPartsList_ultraGrid.DisplayLayout.Override.ActiveRowAppearance.BackColor = System.Drawing.Color.FromArgb(251, 230, 148);
            this.tbsPartsList_ultraGrid.DisplayLayout.Override.ActiveRowAppearance.BackColor2 = System.Drawing.Color.FromArgb(238, 149, 21);
            this.tbsPartsList_ultraGrid.DisplayLayout.Override.ActiveRowAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.tbsPartsList_ultraGrid.DisplayLayout.Override.ActiveRowAppearance.ForeColor = System.Drawing.Color.Black;
            this.tbsPartsList_ultraGrid.DisplayLayout.Override.ActiveRowAppearance.BackColorDisabled = System.Drawing.Color.FromArgb(251, 230, 148);
            this.tbsPartsList_ultraGrid.DisplayLayout.Override.ActiveRowAppearance.BackColorDisabled2 = System.Drawing.Color.FromArgb(238, 149, 21);

            // �s�Z���N�^�̊O�ϐݒ�
            this.tbsPartsList_ultraGrid.DisplayLayout.Override.RowSelectorAppearance.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(89)), ((System.Byte)(135)), ((System.Byte)(214)));
            this.tbsPartsList_ultraGrid.DisplayLayout.Override.RowSelectorAppearance.BackColor2 = System.Drawing.Color.FromArgb(((System.Byte)(7)), ((System.Byte)(59)), ((System.Byte)(150)));
            this.tbsPartsList_ultraGrid.DisplayLayout.Override.RowSelectorAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;

            // �r���̐F��ύX
            this.tbsPartsList_ultraGrid.DisplayLayout.Appearance.BorderColor = Color.FromArgb(1, 68, 208);
            //this.tbsPartsList_ultraGrid.Rows[0].Activate();
        }

        /// <summary>
        /// �X�V�O��̃f�[�^��r�ƍX�V�Ώۊi�[����
        /// </summary>
        /// <param name="updateList">�X�V�Ώۃ��R�[�h���i�[</param>
        /// <param name="deleteList">�폜�Ώۃ��R�[�h���i�[</param>
        /// <remarks>
        /// <br>Note       : �X�V�O��̃f�[�^���r���čX�V�^�폜�Ώۃf�[�^���i�[���܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.19</br>
        /// </remarks>
        private void UpdateCompare(out ArrayList updateList, out ArrayList deleteList)
        {
            updateList = new ArrayList();
            deleteList = new ArrayList();
            
            // Form ���C��Grid�����擾
            string partsGuid = (string)this.Bind_DataSet.Tables[SECOND_TABLE].Rows[this._secondDataIndex][S_PARTSPOSCODE_GUID];
            PartsPosCodeU partsPosCodeU = ((PartsPosCodeU)this._secondGridTable[partsGuid]).Clone(); ;

            if (!partsPosCodeU.SearchPartsPosName.Equals(this.PartsPosName_tEdit.Text.TrimEnd()))
            {
                // ���ʖ��̂��X�V����Ă��邽�ߍX�V�Ώۃ��R�[�h�ɒǉ�
                partsPosCodeU.SearchPartsPosName = this.PartsPosName_tEdit.Text.TrimEnd();
                updateList.Add(partsPosCodeU);
            }

            // Form �ڍ�Grid����UI��ʂ�Grid���擾���Ĕ�r
            int index;
            int detailRowCnt = this._thirdGridTable.Count;          // �ڍ�Grid�̍s��
            int tbsPartsRowCnt = this._bindTable.Rows.Count;        // UI��ʂ�Grid�s��

            //for (index = 0; index < tbsPartsRowCnt; index++)
            //{
            //    string strBlCode = (string)this._bindTable.Rows[index][MY_SCREEN_TBSPARTS_CODE];
            //    if (strBlCode == "")
            //    {
            //        // BL�R�[�h�����͂̍s��SKIP
            //        continue;
            //    }

            //    int tbsPartsCode = Int32.Parse(strBlCode);

            //    if (index < detailRowCnt)
            //    {
            //        string guid = (string)this.Bind_DataSet.Tables[THIRD_TABLE].Rows[index][T_TBSPARTCODE_GUID];
            //        partsPosCodeU = ((PartsPosCodeU)this._thirdGridTable[guid]).Clone();

            //        if (partsPosCodeU.TbsPartsCode != tbsPartsCode)
            //        {
            //            // BL�R�[�h���s��v�̏ꍇ�A�ڍ�Grid�����폜�Ώۂɒǉ�
            //            deleteList.Add(partsPosCodeU);

            //            // ��L�[���ς��̂ŁAUI��ʂ�Grid���͐V�K�ǉ��ƂȂ�
            //            partsPosCodeU = new PartsPosCodeU();
            //            partsPosCodeU.EnterpriseCode = this._enterpriseCode;                                // ��ƃR�[�h
            //            partsPosCodeU.CustomerCode = this.tNedit_CustomerCodeAllowZero.GetInt();                     // ���Ӑ�R�[�h
            //            partsPosCodeU.SearchPartsPosCode = this.PartsPosCode_tNedit.GetInt();               // ���ʃR�[�h
            //            partsPosCodeU.PosDispOrder = (int)this._bindTable.Rows[index][MY_SCREEN_ODER];      // �\������
            //            partsPosCodeU.TbsPartsCode = tbsPartsCode;                                          // BL�R�[�h
            //            updateList.Add(partsPosCodeU);
            //        }

            //        else if (partsPosCodeU.PosDispOrder != (int)this._bindTable.Rows[index][MY_SCREEN_ODER])
            //        {
            //            // �\�����ʂ��s��v�̏ꍇ�A�\�����ʂ��X�V���čX�V�Ώۂɒǉ�
            //            partsPosCodeU.PosDispOrder = (int)this._bindTable.Rows[index][MY_SCREEN_ODER];
            //            updateList.Add(partsPosCodeU);
            //        }
            //    }
            //    else
            //    {
            //        if (strBlCode == "")
            //        {
            //            // BL�R�[�h�����͂̍s��SKIP
            //            continue;
            //        }

            //        // �V�K�ǉ��Ƃ��čX�V�Ώۂɒǉ�
            //        partsPosCodeU = new PartsPosCodeU();
            //        partsPosCodeU.EnterpriseCode = this._enterpriseCode;                                // ��ƃR�[�h
            //        partsPosCodeU.CustomerCode = this.tNedit_CustomerCodeAllowZero.GetInt();                     // ���Ӑ�R�[�h
            //        partsPosCodeU.SearchPartsPosCode = this.PartsPosCode_tNedit.GetInt();               // ���ʃR�[�h
            //        partsPosCodeU.PosDispOrder = (int)this._bindTable.Rows[index][MY_SCREEN_ODER];      // �\������
            //        partsPosCodeU.TbsPartsCode = Int32.Parse(strBlCode);                                // BL�R�[�h
            //        updateList.Add(partsPosCodeU);
            //    }
                
            //}

            // �ڍ�Grid���̍s�������r
            for (index = 0; index < detailRowCnt; index++)
            {
                // �ڍ�Grid�����擾
                string guid = (string)this.Bind_DataSet.Tables[THIRD_TABLE].Rows[index][T_TBSPARTCODE_GUID];
                partsPosCodeU = ((PartsPosCodeU)this._thirdGridTable[guid]).Clone();

                if (index >= tbsPartsRowCnt)
                {
                    // �ڍ�Grid�s����UI��ʂ�Grid�s���ȏ�̏ꍇ�̓��[�v�𔲂���
                    break;
                }

                // UI��ʂ�Grid����BL�R�[�h���擾
                string strBlCode = (string)this._bindTable.Rows[index][MY_SCREEN_TBSPARTS_CODE];
                //if (strBlCode == "")
                //{
                //    // BL�R�[�h�����͂̍s��SKIP
                //    continue;
                //}
                int tbsPartsCode = 0;
                if (strBlCode != "")
                {
                    tbsPartsCode = Int32.Parse(strBlCode);
                }

                //int tbsPartsCode = Int32.Parse(strBlCode);
                if (partsPosCodeU.TbsPartsCode != tbsPartsCode)
                {
                    // BL�R�[�h���s��v�̏ꍇ�A�ڍ�Grid�����폜�Ώۂɒǉ�
                    deleteList.Add(partsPosCodeU);

                    if (tbsPartsCode != 0)
                    {
                        // ��L�[���ς��̂ŁAUI��ʂ�Grid���͐V�K�ǉ��ƂȂ�
                        partsPosCodeU = new PartsPosCodeU();
                        partsPosCodeU.EnterpriseCode = this._enterpriseCode;                                // ��ƃR�[�h
                        partsPosCodeU.CustomerCode = this.tNedit_CustomerCodeAllowZero.GetInt();                     // ���Ӑ�R�[�h
                        partsPosCodeU.SearchPartsPosCode = this.PartsPosCode_tNedit.GetInt();               // ���ʃR�[�h
                        partsPosCodeU.PosDispOrder = (int)this._bindTable.Rows[index][MY_SCREEN_ODER];      // �\������
                        partsPosCodeU.TbsPartsCode = tbsPartsCode;                                          // BL�R�[�h
                        updateList.Add(partsPosCodeU);
                    }
                }

                else if (partsPosCodeU.PosDispOrder != (int)this._bindTable.Rows[index][MY_SCREEN_ODER])
                {
                    // �\�����ʂ��s��v�̏ꍇ�A�\�����ʂ��X�V���čX�V�Ώۂɒǉ�
                    partsPosCodeU.PosDispOrder = (int)this._bindTable.Rows[index][MY_SCREEN_ODER];
                    updateList.Add(partsPosCodeU);
                }
            }

            if (detailRowCnt < tbsPartsRowCnt)
            {
                // �ڍ�Grid�̍s�����UI��ʂ�Grid�s��������
                for (index = detailRowCnt; index < tbsPartsRowCnt; index++)
                {
                    string strBlCode = (string)this._bindTable.Rows[index][MY_SCREEN_TBSPARTS_CODE];
                    if (strBlCode == "")
                    {
                        // BL�R�[�h�����͂̍s��SKIP
                        continue;
                    }

                    // �V�K�ǉ��Ƃ��čX�V�Ώۂɒǉ�
                    partsPosCodeU = new PartsPosCodeU();
                    partsPosCodeU.EnterpriseCode = this._enterpriseCode;                                // ��ƃR�[�h
                    partsPosCodeU.CustomerCode = this.tNedit_CustomerCodeAllowZero.GetInt();                     // ���Ӑ�R�[�h
                    partsPosCodeU.SearchPartsPosCode = this.PartsPosCode_tNedit.GetInt();               // ���ʃR�[�h
                    partsPosCodeU.PosDispOrder = (int)this._bindTable.Rows[index][MY_SCREEN_ODER];      // �\������
                    partsPosCodeU.TbsPartsCode = Int32.Parse(strBlCode);                                // BL�R�[�h
                    updateList.Add(partsPosCodeU);
                }
            }
            else if (tbsPartsRowCnt < detailRowCnt)
            {
                // �ڍ�Grid�̍s�����UI��ʂ�Grid�s�������Ȃ�
                for (index = tbsPartsRowCnt; index < detailRowCnt; index++)
                {
                    // �폜�Ώۂɒǉ�
                    string guid = (string)this.Bind_DataSet.Tables[THIRD_TABLE].Rows[index][T_TBSPARTCODE_GUID];
                    partsPosCodeU = ((PartsPosCodeU)this._thirdGridTable[guid]).Clone();
                    deleteList.Add(partsPosCodeU);
                }
            }
        }

        /// <summary>
        ///	Grid �V�K�s�̒ǉ�
        /// </summary>
        /// <remarks>
        /// <br>Note	   : GRID�ɐV�K�s��ǉ����܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008/10/21</br>
        /// </remarks>
        private void tbsPartsList_AddRow()
        {
            if (this._bindTable.Rows.Count == 99)
            {
                // MAX99�s�Ƃ���
                return;
            }

            // �K�C�h�őI������BL�R�[�h��ǉ�
            DataRow bindRow;

            bindRow = this._bindTable.NewRow();

            // BL����Grid�ɒǉ�
            bindRow[MY_SCREEN_ID] = "";
            bindRow[MY_SCREEN_ODER] = this._bindTable.Rows.Count + 1;
            bindRow[MY_SCREEN_TBSPARTS_CODE] = "";
            bindRow[MY_SCREEN_TBSPARTS_NAME] = "";

            this._bindTable.Rows.Add(bindRow);
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
        /// <param name="NumberFlg">���l���͉H</param>
        /// <returns>true=���͉�,false=���͕s��</returns>
        /// <remarks>
        /// Note			:	�����ꂽ�L�[�����l�̂ݗL���ɂ��鏈�����s���܂��B<br />
        /// Programmer		:	30413 ����<br />
        /// Date			:	2008.10.21<br />
        /// </remarks>
        private bool KeyPressNumCheck(int keta, int priod, string prevVal, char key, int selstart, int sellength, Boolean minusFlg, Boolean NumberFlg)
        {
            // ����L�[�������ꂽ�H
            if (Char.IsControl(key))
            {
                return true;
            }

            // �����ꂽ�L�[�����l�ȊO�A�����l�ȊO���͕s��
            if (!Char.IsDigit(key) && !NumberFlg)
            {
                return false;
            }

            // �L�[�������ꂽ�Ɖ��肵���ꍇ�̕�����𐶐�����B
            string _strResult = "";
            if (sellength > 0)
            {
                _strResult = prevVal.Substring(0, selstart) + prevVal.Substring(selstart + sellength, prevVal.Length - (selstart + sellength));
            }
            else
            {
                _strResult = prevVal;
            }

            // �}�C�i�X�̃`�F�b�N
            if (key == '-')
            {
                // �}�C�i�X(�����_)�����͉\���H
                if (minusFlg == false)
                {
                    return false;
                }
            }

            // �����_�̃`�F�b�N
            if (key == '.')
            {
                // �����_�ȉ�������0���H
                if (priod == 0)
                {
                    return false;
                }
                else
                {
                    // �����_�����ɑ��݂��邩�H
                    if (_strResult.Contains("."))
                    {
                        return false;
                    }
                }
            }
            else
            {
                // �����_�����ɑ��݂��邩�H
                if (_strResult.Contains("."))
                {
                    int index = _strResult.IndexOf('.');
                    string strDecimal = _strResult.Substring(index + 1);

                    if ((strDecimal.Length >= priod) && (selstart > index))
                    {
                        // �����������͉\�����ȏ�ŁA�J�[�\���ʒu�������_�ȍ~
                        return false;
                    }
                    else if (((keta - priod) < index))
                    {
                        // �������̌��������͉\�����𒴂���
                        return false;
                    }
                }
                else
                {
                    // �����_������O��ɐ������̌���������
                    if (((keta - priod) <= _strResult.Length))
                    {
                        return false;
                    }
                }
            }

            // �L�[�������ꂽ���ʂ̕�����𐶐�����B
            _strResult = prevVal.Substring(0, selstart)
                + key
                + prevVal.Substring(selstart + sellength, prevVal.Length - (selstart + sellength));

            // �����`�F�b�N�I
            if (_strResult.Length > keta)
            {
                if (_strResult[0] == '-')
                {
                    if (_strResult.Length > (keta + 1))
                    {
                        return false;
                    }
                }
                else if (_strResult.Contains("."))
                {
                    if (_strResult.Length > (keta + 1))
                    {
                        return false;
                    }
                }
                else if ((_strResult[0] == '-') && (_strResult.Contains(".")))
                {
                    if (_strResult.Length > (keta + 2))
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }

            return true;
        }

        #endregion

        // --- ADD 2009/03/23 �c�Č�No.14�Ή�------------------------------------------------------>>>>>
        private void Renewal_Button_Click(object sender, EventArgs e)
        {
            this._partsPosCodeUAcs = new PartsPosCodeUAcs();

            TMsgDisp.Show(this, 								// �e�E�B���h�E�t�H�[��
                          emErrorLevel.ERR_LEVEL_INFO,          // �G���[���x��
                          "PMKHN09050U",						    // �A�Z���u���h�c�܂��̓N���X�h�c
                          "�ŐV�����擾���܂����B", 			// �\�����郁�b�Z�[�W
                          0, 									// �X�e�[�^�X�l
                          MessageBoxButtons.OK);				// �\������{�^��
        }
        // --- ADD 2009/03/23 �c�Č�No.14�Ή�------------------------------------------------------<<<<<

        // 2009.03.31 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� >>>>>>START
        /// <summary>
        /// ���[�h�ύX�����i���Ӑ�ʁj
        /// </summary>
        private bool ModeChangeProc()
        {
            // ���Ӑ�R�[�h
            int customerCode = tNedit_CustomerCodeAllowZero.GetInt();
            // ���ʃR�[�h
            int partsPosCode = PartsPosCode_tNedit.GetInt();

            for (int i = 0; i < this.Bind_DataSet.Tables[MAIN_TABLE].Rows.Count; i++)
            {
                // �f�[�^�Z�b�g�Ɣ�r
                int dsCustomerCode = int.Parse((string)this.Bind_DataSet.Tables[MAIN_TABLE].Rows[i][M_CUSTOMERCODE]);
                if (customerCode == dsCustomerCode)
                {
                    // ���̓R�[�h���f�[�^�Z�b�g�ɑ��݂���ꍇ
                    if ((string)this.Bind_DataSet.Tables[MAIN_TABLE].Rows[i][M_DELETEDATE] != "")
                    {
                        // �_���폜
                        TMsgDisp.Show(this, 					// �e�E�B���h�E�t�H�[��
                          emErrorLevel.ERR_LEVEL_INFO,          // �G���[���x��
                          PG_ID,						        // �A�Z���u���h�c�܂��̓N���X�h�c
                          "���͂��ꂽ�R�[�h�̕��ʃ}�X�^���͊��ɍ폜����Ă��܂��B", 			// �\�����郁�b�Z�[�W
                          0, 									// �X�e�[�^�X�l
                          MessageBoxButtons.OK);				// �\������{�^��
                        // ���Ӑ�R�[�h�A���ʃR�[�h�̃N���A
                        tNedit_CustomerCodeAllowZero.Clear();
                        CustomerSnm_tEdit.Clear();
                        PartsPosCode_tNedit.Clear();
                        return true;
                    }

                    int status = 0;
                    PartsPosCodeU partsPosCodeU;
                    // ���ʃR�[�h�}�X�^�̎擾
                    status = this._partsPosCodeUAcs.Read(out partsPosCodeU, this._enterpriseCode, customerCode, partsPosCode, 0);
                    if ((status == 0) && (partsPosCodeU != null))
                    {
                        if ((customerCode == partsPosCodeU.CustomerCode) && (partsPosCode == partsPosCodeU.SearchPartsPosCode))
                        {
                            DialogResult res = TMsgDisp.Show(
                                this,                                   // �e�E�B���h�E�t�H�[��
                                emErrorLevel.ERR_LEVEL_INFO,            // �G���[���x��
                                PG_ID,                                // �A�Z���u���h�c�܂��̓N���X�h�c
                                "���͂��ꂽ�R�[�h�̕��ʃ}�X�^��񂪊��ɓo�^����Ă��܂��B\n�ҏW���s���܂����H",   // �\�����郁�b�Z�[�W
                                0,                                      // �X�e�[�^�X�l
                                MessageBoxButtons.YesNo);               // �\������{�^��
                            switch (res)
                            {
                                case DialogResult.Yes:
                                    {
                                        // ��ʍĕ`��
                                        this._mainDataIndex = i;
                                        UpdateDataSet(customerCode, partsPosCode);
                                        ScreenClear();
                                        ScreenReconstruction();
                                        break;
                                    }
                                case DialogResult.No:
                                    {
                                        // ���Ӑ�R�[�h�A���ʃR�[�h�̃N���A
                                        tNedit_CustomerCodeAllowZero.Clear();
                                        CustomerSnm_tEdit.Clear();
                                        PartsPosCode_tNedit.Clear();
                                        break;
                                    }
                            }
                            return true;
                        }                        
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// �ĕ`��O�̌�������
        /// </summary>
        private void UpdateDataSet(int customerCode, int partsPosCode)
        {
            int totalCount = 0;
            
            // �f�[�^�r���[�i�Q�A���C�ڂ̍Ď擾�j
            SecondDataSearch(ref totalCount, 0);
            
            for (int i = 0; i < this.Bind_DataSet.Tables[SECOND_TABLE].Rows.Count; i++)
            {
                // �f�[�^�Z�b�g�Ɣ�r
                int dsPartsPosCode = int.Parse((string)this.Bind_DataSet.Tables[SECOND_TABLE].Rows[i][S_PARTSPOSCODE]);
                if (partsPosCode == dsPartsPosCode)
                {
                    this._secondDataIndex = i;
                    totalCount = 0;
                    // �f�[�^�r���[�i�R�A���C���̍Ď擾�j
                    ThirdDataSearch(ref totalCount, 0);
                    break;
                }
            }
        }
        // 2009.03.31 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� <<<<<<END
    }
}

//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �Ԏ햼�̃}�X�^
// �v���O�����T�v   : �Ԏ햼�̃}�X�^�̓o�^�E�ύX�E�폜���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2007 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ����
// �� �� ��  2008/06/12  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �s�V �m��
// �C �� ��  2008/10/07  �C�����e : �o�O�C��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  12693       �쐬�S�� : �H���@�b�D
// �C �� ��  2009/03/24  �C�����e : �u�폜�σf�[�^�̕\���v�͍ŏ�ʍ��ڂŐ���
//----------------------------------------------------------------------------//
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �я���
// �C �� ��  2010/04/26  �C�����e : ���R�����^���}�X�^�����e�i���X����̕ύX
//----------------------------------------------------------------------------//
#define DELETE_DATE_DEPEND_ON_SUB_TABLE // ���C���e�[�u���̍폜�����T�u�e�[�u���Ɋ֘A������t���O

using System;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Forms;
using System.Data;

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
    /// �Ԏ햼�̃}�X�^ �t�H�[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note		: �Ԏ햼�̃}�X�^���̐ݒ���s���܂��B
    ///					  IMasterMaintenanceArrayType���������Ă��܂��B</br>
    /// <br>Programmer	: 30413 ����</br>
    /// <br>Date		: 2008.06.12</br>
    /// <br>UpdateNote   : 2008/10/07 30462 �s�V �m���@�o�O�C��</br>
    /// <br>UpdateNote   : 2009/03/24 30434 �H�� �b�D�@�o�O�C��</br>
    /// <br>UpdateNote   : 2010/04/26 �я����@���R�����^���}�X�^����</br>
    /// </remarks>
    public class PMKHN09030UA : System.Windows.Forms.Form, IMasterMaintenanceArrayType
    {
        # region ��Private Members (Component)

        private TArrowKeyControl tArrowKeyControl1;
        private IContainer components;
        private Infragistics.Win.Misc.UltraLabel MakerCode_Label;
        private TNedit MakerCode_tNedit;
        private TRetKeyControl tRetKeyControl1;
        private DataSet Bind_DataSet;
        private Timer Initial_Timer;
        private TImeControl tImeControl1;
        private Infragistics.Win.Misc.UltraButton Cancel_Button;
        private Infragistics.Win.Misc.UltraButton Revive_Button;
        private Infragistics.Win.Misc.UltraButton Delete_Button;
        private Infragistics.Win.Misc.UltraButton Ok_Button;
        private Infragistics.Win.Misc.UltraLabel ModelAliasName_Label;
        private Infragistics.Win.Misc.UltraLabel ModelHalfName_Label;
        private Infragistics.Win.Misc.UltraLabel ModelFullName_Label;
        private Infragistics.Win.Misc.UltraLabel ModelSubCode_Label;
        private Infragistics.Win.Misc.UltraLabel ModelCode_Label;
        private TEdit MakerCodeNm_tEdit;
        private Infragistics.Win.Misc.UltraButton uButton_ModelGuide;
        private TEdit ModelAliasName_tEdit;
        private TEdit ModelHalfName_tEdit;
        private TEdit ModelFullName_tEdit;
        private Infragistics.Win.Misc.UltraLabel WarnMsg_Label;
        private TNedit ModelSubCodea_tNedit;
        private TNedit ModelCode_tNedit;
        private Infragistics.Win.Misc.UltraLabel Mode_Label;
        private TImeControl tImeControl2;
        private UiSetControl uiSetControl1;
        private Infragistics.Win.Misc.UltraButton uButton_CmpltGoodsMakerGuide;
        private Infragistics.Win.UltraWinStatusBar.UltraStatusBar ultraStatusBar1;

        # endregion

        #region ��Windows �t�H�[�� �f�U�C�i�Ő������ꂽ�R�[�h
        /// <summary>
        /// �f�U�C�i �T�|�[�g�ɕK�v�ȃ��\�b�h�ł��B���̃��\�b�h�̓��e��
        /// �R�[�h �G�f�B�^�ŕύX���Ȃ��ł��������B
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance24 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance23 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance32 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PMKHN09030UA));
            this.ultraStatusBar1 = new Infragistics.Win.UltraWinStatusBar.UltraStatusBar();
            this.tArrowKeyControl1 = new Broadleaf.Library.Windows.Forms.TArrowKeyControl(this.components);
            this.tRetKeyControl1 = new Broadleaf.Library.Windows.Forms.TRetKeyControl(this.components);
            this.Bind_DataSet = new System.Data.DataSet();
            this.Initial_Timer = new System.Windows.Forms.Timer(this.components);
            this.tImeControl1 = new Broadleaf.Library.Windows.Forms.TImeControl(this.components);
            this.ModelFullName_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.ModelHalfName_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.MakerCode_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.MakerCode_Label = new Infragistics.Win.Misc.UltraLabel();
            this.ModelCode_Label = new Infragistics.Win.Misc.UltraLabel();
            this.ModelSubCode_Label = new Infragistics.Win.Misc.UltraLabel();
            this.ModelFullName_Label = new Infragistics.Win.Misc.UltraLabel();
            this.ModelHalfName_Label = new Infragistics.Win.Misc.UltraLabel();
            this.ModelAliasName_Label = new Infragistics.Win.Misc.UltraLabel();
            this.Cancel_Button = new Infragistics.Win.Misc.UltraButton();
            this.Revive_Button = new Infragistics.Win.Misc.UltraButton();
            this.Delete_Button = new Infragistics.Win.Misc.UltraButton();
            this.Ok_Button = new Infragistics.Win.Misc.UltraButton();
            this.ModelCode_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.ModelSubCodea_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.ModelAliasName_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.uButton_ModelGuide = new Infragistics.Win.Misc.UltraButton();
            this.MakerCodeNm_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.WarnMsg_Label = new Infragistics.Win.Misc.UltraLabel();
            this.Mode_Label = new Infragistics.Win.Misc.UltraLabel();
            this.tImeControl2 = new Broadleaf.Library.Windows.Forms.TImeControl(this.components);
            this.uiSetControl1 = new Broadleaf.Library.Windows.Forms.UiSetControl(this.components);
            this.uButton_CmpltGoodsMakerGuide = new Infragistics.Win.Misc.UltraButton();
            ((System.ComponentModel.ISupportInitialize)(this.Bind_DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ModelFullName_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ModelHalfName_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakerCode_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ModelCode_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ModelSubCodea_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ModelAliasName_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakerCodeNm_tEdit)).BeginInit();
            this.SuspendLayout();
            // 
            // ultraStatusBar1
            // 
            this.ultraStatusBar1.Location = new System.Drawing.Point(0, 299);
            this.ultraStatusBar1.Name = "ultraStatusBar1";
            this.ultraStatusBar1.Size = new System.Drawing.Size(608, 23);
            this.ultraStatusBar1.TabIndex = 47;
            this.ultraStatusBar1.ViewStyle = Infragistics.Win.UltraWinStatusBar.ViewStyle.Office2003;
            // 
            // tArrowKeyControl1
            // 
            this.tArrowKeyControl1.OwnerForm = this;
            this.tArrowKeyControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tRetKeyControl1_ChangeFocus);
            // 
            // tRetKeyControl1
            // 
            this.tRetKeyControl1.OwnerForm = this;
            this.tRetKeyControl1.Style = Broadleaf.Library.Windows.Forms.emFocusStyle.ByTab;
            this.tRetKeyControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tRetKeyControl1_ChangeFocus);
            // 
            // Bind_DataSet
            // 
            this.Bind_DataSet.DataSetName = "NewDataSet";
            this.Bind_DataSet.Locale = new System.Globalization.CultureInfo("ja-JP");
            // 
            // Initial_Timer
            // 
            this.Initial_Timer.Interval = 1;
            this.Initial_Timer.Tick += new System.EventHandler(this.Initial_Timer_Tick);
            // 
            // tImeControl1
            // 
            this.tImeControl1.InControl = this.ModelFullName_tEdit;
            this.tImeControl1.OutControl = this.ModelHalfName_tEdit;
            this.tImeControl1.OwnerForm = this;
            this.tImeControl1.PutLength = 20;
            // 
            // ModelFullName_tEdit
            // 
            appearance14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.ModelFullName_tEdit.ActiveAppearance = appearance14;
            appearance15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance15.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance15.ForeColorDisabled = System.Drawing.Color.Black;
            this.ModelFullName_tEdit.Appearance = appearance15;
            this.ModelFullName_tEdit.AutoSelect = true;
            this.ModelFullName_tEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.ModelFullName_tEdit.DataText = "";
            this.ModelFullName_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.ModelFullName_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 15, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, true, true, true, true));
            this.ModelFullName_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.ModelFullName_tEdit.Location = new System.Drawing.Point(151, 134);
            this.ModelFullName_tEdit.MaxLength = 15;
            this.ModelFullName_tEdit.Name = "ModelFullName_tEdit";
            this.ModelFullName_tEdit.Size = new System.Drawing.Size(380, 24);
            this.ModelFullName_tEdit.TabIndex = 5;
            this.ModelFullName_tEdit.ValueChanged += new System.EventHandler(this.ModelFullName_tEdit_ValueChanged);
            // 
            // ModelHalfName_tEdit
            // 
            appearance11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.ModelHalfName_tEdit.ActiveAppearance = appearance11;
            appearance24.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance24.ForeColorDisabled = System.Drawing.Color.Black;
            this.ModelHalfName_tEdit.Appearance = appearance24;
            this.ModelHalfName_tEdit.AutoSelect = true;
            this.ModelHalfName_tEdit.DataText = "";
            this.ModelHalfName_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.ModelHalfName_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 20, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, true, true, true, true, true));
            this.ModelHalfName_tEdit.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf;
            this.ModelHalfName_tEdit.Location = new System.Drawing.Point(151, 164);
            this.ModelHalfName_tEdit.MaxLength = 20;
            this.ModelHalfName_tEdit.Name = "ModelHalfName_tEdit";
            this.ModelHalfName_tEdit.Size = new System.Drawing.Size(387, 24);
            this.ModelHalfName_tEdit.TabIndex = 6;
            this.ModelHalfName_tEdit.ValueChanged += new System.EventHandler(this.ModelHalfName_tEdit_ValueChanged);
            // 
            // MakerCode_tNedit
            // 
            appearance22.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance22.TextHAlignAsString = "Right";
            this.MakerCode_tNedit.ActiveAppearance = appearance22;
            appearance23.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance23.ForeColor = System.Drawing.Color.Black;
            appearance23.ForeColorDisabled = System.Drawing.Color.Black;
            appearance23.TextHAlignAsString = "Right";
            this.MakerCode_tNedit.Appearance = appearance23;
            this.MakerCode_tNedit.AutoSelect = true;
            this.MakerCode_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.MakerCode_tNedit.DataText = "";
            this.MakerCode_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.MakerCode_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 3, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.MakerCode_tNedit.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.MakerCode_tNedit.Location = new System.Drawing.Point(151, 44);
            this.MakerCode_tNedit.MaxLength = 3;
            this.MakerCode_tNedit.Name = "MakerCode_tNedit";
            this.MakerCode_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.MakerCode_tNedit.ReadOnly = true;
            this.MakerCode_tNedit.Size = new System.Drawing.Size(44, 24);
            this.MakerCode_tNedit.TabIndex = 0;
            this.MakerCode_tNedit.AfterExitEditMode += new System.EventHandler(this.MakerCode_tNedit_AfterExitEditMode);
            // 
            // MakerCode_Label
            // 
            appearance9.TextVAlignAsString = "Middle";
            this.MakerCode_Label.Appearance = appearance9;
            this.MakerCode_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.MakerCode_Label.Location = new System.Drawing.Point(12, 44);
            this.MakerCode_Label.Name = "MakerCode_Label";
            this.MakerCode_Label.Size = new System.Drawing.Size(133, 24);
            this.MakerCode_Label.TabIndex = 61;
            this.MakerCode_Label.Text = "���[�J�[";
            // 
            // ModelCode_Label
            // 
            appearance19.TextVAlignAsString = "Middle";
            this.ModelCode_Label.Appearance = appearance19;
            this.ModelCode_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.ModelCode_Label.Location = new System.Drawing.Point(12, 74);
            this.ModelCode_Label.Name = "ModelCode_Label";
            this.ModelCode_Label.Size = new System.Drawing.Size(133, 24);
            this.ModelCode_Label.TabIndex = 61;
            this.ModelCode_Label.Text = "�Ԏ�R�[�h";
            // 
            // ModelSubCode_Label
            // 
            appearance6.TextVAlignAsString = "Middle";
            this.ModelSubCode_Label.Appearance = appearance6;
            this.ModelSubCode_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.ModelSubCode_Label.Location = new System.Drawing.Point(12, 104);
            this.ModelSubCode_Label.Name = "ModelSubCode_Label";
            this.ModelSubCode_Label.Size = new System.Drawing.Size(133, 24);
            this.ModelSubCode_Label.TabIndex = 61;
            this.ModelSubCode_Label.Text = "�ď̃R�[�h";
            // 
            // ModelFullName_Label
            // 
            appearance3.TextVAlignAsString = "Middle";
            this.ModelFullName_Label.Appearance = appearance3;
            this.ModelFullName_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.ModelFullName_Label.Location = new System.Drawing.Point(12, 134);
            this.ModelFullName_Label.Name = "ModelFullName_Label";
            this.ModelFullName_Label.Size = new System.Drawing.Size(133, 24);
            this.ModelFullName_Label.TabIndex = 61;
            this.ModelFullName_Label.Text = "�Ԏ햼";
            // 
            // ModelHalfName_Label
            // 
            appearance18.TextVAlignAsString = "Middle";
            this.ModelHalfName_Label.Appearance = appearance18;
            this.ModelHalfName_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.ModelHalfName_Label.Location = new System.Drawing.Point(12, 164);
            this.ModelHalfName_Label.Name = "ModelHalfName_Label";
            this.ModelHalfName_Label.Size = new System.Drawing.Size(133, 24);
            this.ModelHalfName_Label.TabIndex = 61;
            this.ModelHalfName_Label.Text = "�Ԏ햼(��)";
            // 
            // ModelAliasName_Label
            // 
            appearance16.TextVAlignAsString = "Middle";
            this.ModelAliasName_Label.Appearance = appearance16;
            this.ModelAliasName_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.ModelAliasName_Label.Location = new System.Drawing.Point(12, 194);
            this.ModelAliasName_Label.Name = "ModelAliasName_Label";
            this.ModelAliasName_Label.Size = new System.Drawing.Size(133, 24);
            this.ModelAliasName_Label.TabIndex = 61;
            this.ModelAliasName_Label.Text = "�ď�";
            // 
            // Cancel_Button
            // 
            this.Cancel_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Cancel_Button.Location = new System.Drawing.Point(468, 254);
            this.Cancel_Button.Name = "Cancel_Button";
            this.Cancel_Button.Size = new System.Drawing.Size(125, 34);
            this.Cancel_Button.TabIndex = 11;
            this.Cancel_Button.Text = "����(&X)";
            this.Cancel_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Cancel_Button.Click += new System.EventHandler(this.Cancel_Button_Click);
            // 
            // Revive_Button
            // 
            this.Revive_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Revive_Button.Location = new System.Drawing.Point(337, 254);
            this.Revive_Button.Name = "Revive_Button";
            this.Revive_Button.Size = new System.Drawing.Size(125, 34);
            this.Revive_Button.TabIndex = 9;
            this.Revive_Button.Text = "����(&R)";
            this.Revive_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Revive_Button.Click += new System.EventHandler(this.Revive_Button_Click);
            // 
            // Delete_Button
            // 
            this.Delete_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Delete_Button.Location = new System.Drawing.Point(209, 254);
            this.Delete_Button.Name = "Delete_Button";
            this.Delete_Button.Size = new System.Drawing.Size(125, 34);
            this.Delete_Button.TabIndex = 8;
            this.Delete_Button.Text = "���S�폜(&D)";
            this.Delete_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Delete_Button.Click += new System.EventHandler(this.Delete_Button_Click);
            // 
            // Ok_Button
            // 
            this.Ok_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Ok_Button.Location = new System.Drawing.Point(337, 254);
            this.Ok_Button.Name = "Ok_Button";
            this.Ok_Button.Size = new System.Drawing.Size(125, 34);
            this.Ok_Button.TabIndex = 10;
            this.Ok_Button.Text = "�ۑ�(&S)";
            this.Ok_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Ok_Button.Click += new System.EventHandler(this.Ok_Button_Click);
            // 
            // ModelCode_tNedit
            // 
            appearance20.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance20.TextHAlignAsString = "Right";
            this.ModelCode_tNedit.ActiveAppearance = appearance20;
            appearance21.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance21.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance21.ForeColorDisabled = System.Drawing.Color.Black;
            appearance21.TextHAlignAsString = "Right";
            this.ModelCode_tNedit.Appearance = appearance21;
            this.ModelCode_tNedit.AutoSelect = true;
            this.ModelCode_tNedit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.ModelCode_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.ModelCode_tNedit.DataText = "";
            this.ModelCode_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.ModelCode_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 3, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.ModelCode_tNedit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.ModelCode_tNedit.Location = new System.Drawing.Point(151, 74);
            this.ModelCode_tNedit.MaxLength = 3;
            this.ModelCode_tNedit.Name = "ModelCode_tNedit";
            this.ModelCode_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.ModelCode_tNedit.Size = new System.Drawing.Size(36, 24);
            this.ModelCode_tNedit.TabIndex = 2;
            this.ModelCode_tNedit.Leave += new System.EventHandler(this.ModelCode_tNedit_Leave);
            this.ModelCode_tNedit.BeforeEnterEditMode += new System.ComponentModel.CancelEventHandler(this.ModelCode_tNedit_BeforeEnterEditMode);
            // 
            // ModelSubCodea_tNedit
            // 
            appearance4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance4.TextHAlignAsString = "Right";
            this.ModelSubCodea_tNedit.ActiveAppearance = appearance4;
            appearance5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance5.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance5.ForeColorDisabled = System.Drawing.Color.Black;
            appearance5.TextHAlignAsString = "Right";
            this.ModelSubCodea_tNedit.Appearance = appearance5;
            this.ModelSubCodea_tNedit.AutoSelect = true;
            this.ModelSubCodea_tNedit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.ModelSubCodea_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.ModelSubCodea_tNedit.DataText = "";
            this.ModelSubCodea_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.ModelSubCodea_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 3, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.ModelSubCodea_tNedit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.ModelSubCodea_tNedit.Location = new System.Drawing.Point(151, 104);
            this.ModelSubCodea_tNedit.MaxLength = 3;
            this.ModelSubCodea_tNedit.Name = "ModelSubCodea_tNedit";
            this.ModelSubCodea_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.ModelSubCodea_tNedit.Size = new System.Drawing.Size(36, 24);
            this.ModelSubCodea_tNedit.TabIndex = 4;
            // 
            // ModelAliasName_tEdit
            // 
            appearance7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.ModelAliasName_tEdit.ActiveAppearance = appearance7;
            appearance8.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance8.ForeColorDisabled = System.Drawing.Color.Black;
            this.ModelAliasName_tEdit.Appearance = appearance8;
            this.ModelAliasName_tEdit.AutoSelect = true;
            this.ModelAliasName_tEdit.DataText = "";
            this.ModelAliasName_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.ModelAliasName_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 15, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, true, true, true, true, true));
            this.ModelAliasName_tEdit.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf;
            this.ModelAliasName_tEdit.Location = new System.Drawing.Point(151, 194);
            this.ModelAliasName_tEdit.MaxLength = 15;
            this.ModelAliasName_tEdit.Name = "ModelAliasName_tEdit";
            this.ModelAliasName_tEdit.Size = new System.Drawing.Size(387, 24);
            this.ModelAliasName_tEdit.TabIndex = 7;
            this.ModelAliasName_tEdit.ValueChanged += new System.EventHandler(this.ModelAliasName_tEdit_ValueChanged);
            // 
            // uButton_ModelGuide
            // 
            appearance12.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance12.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.uButton_ModelGuide.Appearance = appearance12;
            this.uButton_ModelGuide.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uButton_ModelGuide.Location = new System.Drawing.Point(209, 74);
            this.uButton_ModelGuide.Name = "uButton_ModelGuide";
            this.uButton_ModelGuide.Size = new System.Drawing.Size(24, 24);
            this.uButton_ModelGuide.TabIndex = 3;
            this.uButton_ModelGuide.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.uButton_ModelGuide.Click += new System.EventHandler(this.uButton_ModelGuide_Click);
            // 
            // MakerCodeNm_tEdit
            // 
            appearance1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance1.ForeColor = System.Drawing.Color.Black;
            appearance1.TextVAlignAsString = "Middle";
            this.MakerCodeNm_tEdit.ActiveAppearance = appearance1;
            appearance2.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance2.ForeColor = System.Drawing.Color.Black;
            appearance2.ForeColorDisabled = System.Drawing.Color.Black;
            appearance2.TextVAlignAsString = "Middle";
            this.MakerCodeNm_tEdit.Appearance = appearance2;
            this.MakerCodeNm_tEdit.AutoSelect = true;
            this.MakerCodeNm_tEdit.DataText = "";
            this.MakerCodeNm_tEdit.Enabled = false;
            this.MakerCodeNm_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.MakerCodeNm_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 15, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.MakerCodeNm_tEdit.Location = new System.Drawing.Point(212, 44);
            this.MakerCodeNm_tEdit.MaxLength = 15;
            this.MakerCodeNm_tEdit.Name = "MakerCodeNm_tEdit";
            this.MakerCodeNm_tEdit.ReadOnly = true;
            this.MakerCodeNm_tEdit.Size = new System.Drawing.Size(239, 24);
            this.MakerCodeNm_tEdit.TabIndex = 68;
            this.MakerCodeNm_tEdit.TabStop = false;
            // 
            // WarnMsg_Label
            // 
            appearance17.TextVAlignAsString = "Middle";
            this.WarnMsg_Label.Appearance = appearance17;
            this.WarnMsg_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.WarnMsg_Label.Location = new System.Drawing.Point(12, 224);
            this.WarnMsg_Label.Name = "WarnMsg_Label";
            this.WarnMsg_Label.Size = new System.Drawing.Size(581, 24);
            this.WarnMsg_Label.TabIndex = 61;
            this.WarnMsg_Label.Text = "���V�K�͎Ԏ�R�[�h/�ď̃R�[�h�̉��ꂩ��900�ȏ�œo�^���ĉ�����";
            // 
            // Mode_Label
            // 
            appearance13.ForeColor = System.Drawing.Color.White;
            appearance13.TextHAlignAsString = "Center";
            appearance13.TextVAlignAsString = "Middle";
            this.Mode_Label.Appearance = appearance13;
            this.Mode_Label.BackColorInternal = System.Drawing.Color.Navy;
            this.Mode_Label.Location = new System.Drawing.Point(496, 12);
            this.Mode_Label.Name = "Mode_Label";
            this.Mode_Label.Size = new System.Drawing.Size(100, 23);
            this.Mode_Label.TabIndex = 69;
            this.Mode_Label.Text = "�X�V���[�h";
            // 
            // tImeControl2
            // 
            this.tImeControl2.InControl = this.ModelFullName_tEdit;
            this.tImeControl2.OutControl = this.ModelAliasName_tEdit;
            this.tImeControl2.OwnerForm = this;
            this.tImeControl2.PutLength = 15;
            // 
            // uiSetControl1
            // 
            this.uiSetControl1.EditWidthSettingWay = Broadleaf.Library.Windows.Forms.UiSetControl.EditWidthSettingWayState.None;
            this.uiSetControl1.OwnerForm = this;
            // 
            // uButton_CmpltGoodsMakerGuide
            // 
            appearance32.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance32.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.uButton_CmpltGoodsMakerGuide.Appearance = appearance32;
            this.uButton_CmpltGoodsMakerGuide.Enabled = false;
            this.uButton_CmpltGoodsMakerGuide.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uButton_CmpltGoodsMakerGuide.Location = new System.Drawing.Point(468, 44);
            this.uButton_CmpltGoodsMakerGuide.Name = "uButton_CmpltGoodsMakerGuide";
            this.uButton_CmpltGoodsMakerGuide.Size = new System.Drawing.Size(24, 24);
            this.uButton_CmpltGoodsMakerGuide.TabIndex = 1;
            this.uButton_CmpltGoodsMakerGuide.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.uButton_CmpltGoodsMakerGuide.Click += new System.EventHandler(this.uButton_CmpltGoodsMakerGuide_Click);
            // 
            // PMKHN09030UA
            // 
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(608, 322);
            this.Controls.Add(this.uButton_CmpltGoodsMakerGuide);
            this.Controls.Add(this.Mode_Label);
            this.Controls.Add(this.MakerCodeNm_tEdit);
            this.Controls.Add(this.uButton_ModelGuide);
            this.Controls.Add(this.ModelAliasName_tEdit);
            this.Controls.Add(this.ModelHalfName_tEdit);
            this.Controls.Add(this.ModelFullName_tEdit);
            this.Controls.Add(this.Cancel_Button);
            this.Controls.Add(this.Revive_Button);
            this.Controls.Add(this.Delete_Button);
            this.Controls.Add(this.Ok_Button);
            this.Controls.Add(this.WarnMsg_Label);
            this.Controls.Add(this.ModelAliasName_Label);
            this.Controls.Add(this.ModelHalfName_Label);
            this.Controls.Add(this.ModelFullName_Label);
            this.Controls.Add(this.ModelSubCode_Label);
            this.Controls.Add(this.ModelCode_Label);
            this.Controls.Add(this.MakerCode_Label);
            this.Controls.Add(this.ModelSubCodea_tNedit);
            this.Controls.Add(this.ModelCode_tNedit);
            this.Controls.Add(this.MakerCode_tNedit);
            this.Controls.Add(this.ultraStatusBar1);
            this.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PMKHN09030UA";
            this.Text = "�Ԏ�}�X�^";
            this.Load += new System.EventHandler(this.PMKHN09030UA_Load);
            this.VisibleChanged += new System.EventHandler(this.PMKHN09030UA_VisibleChanged);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PMKHN09030UA_Closing);
            ((System.ComponentModel.ISupportInitialize)(this.Bind_DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ModelFullName_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ModelHalfName_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakerCode_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ModelCode_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ModelSubCodea_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ModelAliasName_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakerCodeNm_tEdit)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        # endregion

        #region ��Private Members
        private MakerAcs _makerAcs;
        private ModelNameUAcs _modelNameUAcs;
        
        private ModelNameU _modelNameU;
        private ModelNameU _modelNameUClone;
        
        private int _totalCount;
        private string _enterpriseCode;
        private Hashtable _makerUTable;
        private Hashtable _modelNameUTable;
        private Hashtable _modelNameUCloneTable;

        // �v���p�e�B�p
        private bool _canPrint;
        private bool _canLogicalDeleteDataExtraction;
        private bool _canClose;
        private bool _canNew;
        private bool _canDelete;
        private string _mainGridTitle;
        private string _detailsGridTitle;
        private string _targetTableName;
        private int _mainDataIndex;
        private int _detailsDataIndex;
        private Image _mainGridIcon;
        private Image _detailsGridIcon;
        private MGridDisplayLayout _defaultGridDisplayLayout;

        // Fream��View�pGrid���KEY��� (�w�b�_�̃^�C�g�����ƂȂ�܂�)
        private const string I_MAKERCODE = "���[�J�[";
        private const string I_MAKERNAME = "���[�J�[��";
        private const string I_MAKERUMNT_GUID = "MAKERUMNT_GUID";
        private const string I_MAKERUMNT_TABLE = "MAKERUMNT_TABLE";

        private const string S_DELETEDATE = "�폜��";
        private const string S_MAKERCODE = "�ݒ胁�[�J�[�R�[�h";
        private const string S_MODELCODE = "�Ԏ�R�[�h";
        private const string S_MODELNAME = "�Ԏ햼";
        private const string S_MODELSUBCODE = "�ď̃R�[�h";
        private const string S_MODELALIASNAME = "�ď�";
        private const string S_MODELNAMEU_GUID = "MODELNAMEU_GUID";
        private const string S_MODELNAMEU_TABLE = "MODELNAMEU_TABLE";

        //�f�[�^�敪
        private const int DIVISION_USR = 0;
        private const int DIVISION_OFR = 1;	

        // �ҏW���[�h
        private const string INSERT_MODE = "�V�K���[�h";
        private const string UPDATE_MODE = "�X�V���[�h";
        private const string DELETE_MODE = "�폜���[�h";
        private const string REFERENCE_MODE = "�Q�ƃ��[�h";

        // Grid��IndexBuffer�i�[�p�ϐ�
        private int _mainIndexBuffer;
        private int _detailsIndexBuffer;
        private string _targetTableBuffer;
        
        // �A�Z���u�����
        private const string PG_ID = "PMKHN09030U";
        private const string PG_NAME = "�Ԏ�}�X�^";

        // Message�֘A��`
        private const string ERR_READ_MSG = "�ǂݍ��݂Ɏ��s���܂����B";
        private const string ERR_DPR_MSG = "���̃R�[�h�͊��Ɏg�p����Ă��܂��B";
        private const string ERR_RDEL_MSG = "�폜�Ɏ��s���܂����B";
        private const string ERR_UPDT_MSG = "�o�^�Ɏ��s���܂����B";
        private const string ERR_RVV_MSG = "�����Ɏ��s���܂����B";
        private const string ERR_800_MSG = "���ɑ��[�����X�V����Ă��܂�";
        private const string ERR_801_MSG = "���ɑ��[�����폜����Ă��܂�";
        private const string SDC_RDEL_MSG = "�}�X�^����폜����Ă��܂�";

        // ADD 2010.04.26 xaoxd�@>>>>>>>>>>>>>>>>
        // ���R�����}�X�^�����e�i���X����t���O
        private bool flag = false;

        // �}�X�����̎Ԏ�R�[�h�����[�J�[�A�Ԏ�R�[�h�A�ď̃R�[�h
        private string maker;
        private string modelCode;
        private string modelSubCode;
        // ADD 2010.04.26 xaoxd�@<<<<<<<<<<<<<<<<
        # endregion

        # region ��Constructor
		/// <summary>
        /// �Ԏ햼�̃}�X�^ �t�H�[���N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
        /// <br>Note       : �Ԏ햼�̃}�X�^ �t�H�[���N���X�̐V�����C���X�^���X�����������܂��B</br>
		/// <br>Programmer : 30413 ����</br>
		/// <br>Date       : 2008.06.12</br>
		/// </remarks>
        public PMKHN09030UA()
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
            this._mainGridTitle = "���[�J�[";
            this._detailsGridTitle = "�Ԏ�";
            this._defaultGridDisplayLayout = MGridDisplayLayout.Vertical;
            this._mainDataIndex = -1;
            this._detailsDataIndex = -1;
            this._targetTableName = "";
            this._mainGridIcon = null;
            this._detailsGridIcon = null;

            // �K�C�h�{�^���̉摜�C���[�W�ǉ�
            this.uButton_ModelGuide.Appearance.Image
                = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];

            this.uButton_CmpltGoodsMakerGuide.Appearance.Image
                = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];

            //�@��ƃR�[�h���擾����
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            
            // �ϐ�������
            this._makerAcs = new MakerAcs();
            this._modelNameUAcs = new ModelNameUAcs();

            this._modelNameU = new ModelNameU();
            this._modelNameUClone = new ModelNameU();

            this._totalCount = 0;
            this._makerUTable = new Hashtable();
            this._modelNameUTable = new Hashtable();
            this._modelNameUCloneTable = new Hashtable();
            
            // Grid��IndexBuffer�i�[�p�ϐ�������
            this._mainIndexBuffer = -2;
            this._detailsIndexBuffer = -2;
            this._targetTableBuffer = "";
            
		}

        // ADD 2010.04.26 xiaoxd >>>>>>>>>>>>
        /// <summary>
        /// �Ԏ햼�̃}�X�^ �t�H�[���N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �Ԏ햼�̃}�X�^ �t�H�[���N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.12</br>
        /// </remarks>
        public PMKHN09030UA(string maker, string modelCode, string modelSubCode, bool flg)
        {
            InitializeComponent();

            this.flag = flg; //true:���̉�ʂ���Afalse:���g

            this.maker = maker;
            this.modelCode = modelCode;
            this.modelSubCode = modelSubCode;

            // �K�C�h�{�^���̉摜�C���[�W�ǉ�
            this.uButton_ModelGuide.Appearance.Image
                = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];

            this.uButton_CmpltGoodsMakerGuide.Appearance.Image
                = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];

            //�@��ƃR�[�h���擾����
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            this.MakerCode_tNedit.ReadOnly = false;
            this.MakerCode_tNedit.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.uButton_CmpltGoodsMakerGuide.Enabled = true;

            // �ϐ�������
            this._makerAcs = new MakerAcs();
            this._modelNameUAcs = new ModelNameUAcs();

            this._modelNameU = new ModelNameU();
            this._modelNameUClone = new ModelNameU();

            this._targetTableName = S_MODELNAMEU_TABLE;

            // Grid��IndexBuffer�i�[�p�ϐ�������
            this._mainDataIndex = -2;
            this._detailsDataIndex = -2;
     
        }
        // ADD 2010.04.26 xiaoxd <<<<<<<<<<
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
            System.Windows.Forms.Application.Run(new PMKHN09030UA());
        }
        # endregion

        # region Events
        /// <summary>��ʔ�\���C�x���g</summary>
        /// <remarks>��ʂ���\����ԂɂȂ����ۂɔ������܂��B</remarks>
        public event MasterMaintenanceArrayTypeUnDisplayingEventHandler UnDisplaying;
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
        # endregion

        # region ��Public Methods

        /// <summary>
        /// �_���폜�f�[�^���o�\�ݒ胊�X�g�擾����
        /// </summary>
        /// <returns>�_���폜�f�[�^���o�\�ݒ胊�X�g</returns>
        /// <remarks>
        /// <br>Note       : �_���폜�f�[�^�̒��o���\���ǂ����̐ݒ��z��Ŏ擾���܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.12</br>
        /// </remarks>
        public bool[] GetCanLogicalDeleteDataExtractionList()
        {
            bool[] blRet = new bool[2];
            blRet[0] = true;    // MOD 2008/03/24 �s��Ή�[12693]�F�u�폜�σf�[�^�̕\���v�͍ŏ�ʍ��ڂŐ��� false��true
            blRet[1] = false;   // MOD 2008/03/24 �s��Ή�[12693]�F�u�폜�σf�[�^�̕\���v�͍ŏ�ʍ��ڂŐ��� true��false
            return blRet;
        }

        /// <summary>
        /// �O���b�h�^�C�g�����X�g�擾����
        /// </summary>
        /// <returns>�O���b�h�^�C�g�����X�g</returns>
        /// <remarks>
        /// <br>Note       : �O���b�h�̃^�C�g����z��Ŏ擾���܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.12</br>
        /// </remarks>
        public string[] GetGridTitleList()
        {
            string[] strRet = new string[2];
            strRet[0] = this._mainGridTitle;
            strRet[1] = this._detailsGridTitle;
            return strRet;
        }

        /// <summary>
        /// �O���b�h�A�C�R�����X�g�擾����
        /// </summary>
        /// <returns>�O���b�h�A�C�R�����X�g</returns>
        /// <remarks>
        /// <br>Note       : �O���b�h�̃A�C�R����z��Ŏ擾���܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.12</br>
        /// </remarks>
        public Image[] GetGridIconList()
        {
            Image[] objRet = new Image[2];
            objRet[0] = this._mainGridIcon;
            objRet[1] = this._detailsGridIcon;
            return objRet;
        }

        /// <summary>
        /// �O���b�h��̃T�C�Y�̎��������̃f�t�H���g�l���X�g�擾����
        /// </summary>
        /// <returns>�O���b�h��̃T�C�Y�̎��������̃f�t�H���g�l���X�g</returns>
        /// <remarks>
        /// <br>Note       : �O���b�h��̃T�C�Y�̎��������`�F�b�N�{�b�N�X�̃`�F�b�N�L���̃f�t�H���g�l��z��Ŏ擾���܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.12</br>
        /// </remarks>
        public bool[] GetDefaultAutoFillToGridColumnList()
        {
            bool[] blRet = new bool[2];
            blRet[0] = true;
            blRet[1] = true;
            return blRet;
        }

        /// <summary>
        /// �f�[�^�e�[�u���̑I���f�[�^�C���f�b�N�X���X�g�ݒ菈��
        /// </summary>
        /// <param name="indexList">�f�[�^�e�[�u���̑I���f�[�^�C���f�b�N�X���X�g</param>
        /// <remarks>
        /// <br>Note       : �f�[�^�e�[�u���̑I���f�[�^�C���f�b�N�X���X�g��ݒ肵�܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.12</br>
        /// </remarks>
        public void SetDataIndexList(int[] indexList)
        {
            int[] intVal = indexList;
            this._mainDataIndex = intVal[0];
            this._detailsDataIndex = intVal[1];
        }

        /// <summary>
        /// �V�K�{�^���̗L���ݒ胊�X�g�擾����
        /// </summary>
        /// <returns>�V�K�{�^���̗L���ݒ胊�X�g</returns>
        /// <remarks>
        /// <br>Note       : �V�K�{�^���̗L���ݒ胊�X�g���擾���܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.12</br>
        /// </remarks>
        public bool[] GetNewButtonEnabledList()
        {
            bool[] blRet = new bool[2];
            blRet[0] = false;
            blRet[1] = true;
            return blRet;
        }

        /// <summary>
        /// �C���{�^���̗L���ݒ胊�X�g�擾����
        /// </summary>
        /// <returns>�C���{�^���̗L���ݒ胊�X�g</returns>
        /// <remarks>
        /// <br>Note       : �C���{�^���̗L���ݒ胊�X�g���擾���܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.12</br>
        /// </remarks>
        public bool[] GetModifyButtonEnabledList()
        {
            bool[] blRet = new bool[2];
            blRet[0] = false;
            blRet[1] = true;
            return blRet;
        }

        /// <summary>
        /// �폜�{�^���̗L���ݒ胊�X�g�擾����
        /// </summary>
        /// <returns>�폜�{�^���̗L���ݒ胊�X�g</returns>
        /// <remarks>
        /// <br>Note       : �폜�{�^���̗L���ݒ胊�X�g���擾���܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.12</br>
        /// </remarks>
        public bool[] GetDeleteButtonEnabledList()
        {
            bool[] blRet = new bool[2];
            blRet[0] = false;
            blRet[1] = true;
            return blRet;
        }

        /// <summary>
        /// �o�C���h�f�[�^�Z�b�g�擾����
        /// </summary>
        /// <param name="bindDataSet">�O���b�h�\���p�f�[�^�Z�b�g</param>
        /// <param name="tableName">�e�[�u������</param>
        /// <remarks>
        /// <br>Note       : �O���b�h�Ƀo�C���h������f�[�^�Z�b�g���擾���܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.12</br>
        /// </remarks>
        /// 
        public void GetBindDataSet(ref DataSet bindDataSet, ref string[] tableName)
        {
            // �O���b�h�\���p�f�[�^�Z�b�g��ݒ�
            bindDataSet = this.Bind_DataSet;

            // �Q�̃e�[�u�����̂̐ݒ�
            string[] strRet = new string[2];
            strRet[0] = I_MAKERUMNT_TABLE;
            strRet[1] = S_MODELNAMEU_TABLE;
            tableName = strRet;
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
        /// <br>Date       : 2008.06.12</br>
        /// </remarks>
        public int Search(ref int totalCount, int readCount)
        {
            int status = 0;
            ArrayList makerUMntretList = null;

            if (readCount == 0)
            {
                // ���o�Ώی�����0�̏ꍇ�͑S�����o�����s����
                status = this._makerAcs.SearchAll(out makerUMntretList, this._enterpriseCode);

                this._totalCount = makerUMntretList.Count;
            }

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        // �擾�������[�J�[�N���X���f�[�^�Z�b�g�֓W�J����
                        int index = 0;
                        foreach (MakerUMnt makerUMnt in makerUMntretList)
                        {
                            // 2008.12.05 30413 ���� Ұ�����ނ�4���͕��i���[�J�[�Ȃ̂ŏo�͂��Ȃ�
                            //if (makerUMnt.LogicalDeleteCode == 0)
                            if ((makerUMnt.LogicalDeleteCode == 0) && (makerUMnt.GoodsMakerCd < 1000))
                            {
                                // ���[�J�[�N���X�f�[�^�Z�b�g�W�J����
                                MakerUMntToDataSet(makerUMnt.Clone(), index);
                                ++index;
                            }
                        }

                        break;
                    }
                default:
                    {
                        // �T�[�`���� ���[�J�[�}�X�^�ǂݍ��ݎ��s
                        TMsgDisp.Show(
                            this, 									    // �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_STOP, 			    // �G���[���x��
                            PG_ID,      							    // �A�Z���u���h�c�܂��̓N���X�h�c
                            PG_NAME,	        					    // �v���O��������
                            "Search", 								    // ��������
                            TMsgDisp.OPE_GET, 						    // �I�y���[�V����
                            "���[�J�[���̓ǂݍ��݂Ɏ��s���܂����B", 	// �\�����郁�b�Z�[�W
                            status, 								    // �X�e�[�^�X�l
                            this._modelNameUAcs,	 				    // �G���[�����������I�u�W�F�N�g
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
        /// �l�N�X�g�f�[�^��������
        /// </summary>
        /// <param name="readCount">���o�Ώی���</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �w�肵���������̃l�N�X�g�f�[�^���������܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.12</br>
        /// </remarks>
        public int SearchNext(int readCount)
        {
            // ������
            return 9;
        }

        /// <summary>
        /// ���׃f�[�^��������
        /// </summary>
        /// <param name="totalCount">�S�Y������</param>
        /// <param name="readCount">���o�Ώی���</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �擪����w�茏�����̃f�[�^���������A���o���ʂ�W�J����DataSet�ƑS�Y��������Ԃ��܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.12</br>
        /// </remarks>
        public int DetailsDataSearch(ref int totalCount, int readCount)
        {
            int status = 0;
            ArrayList arrModelNameU = new ArrayList();

            // ���ݕێ����Ă���Ԏ햼�̃f�[�^���N���A����
            this.Bind_DataSet.Tables[S_MODELNAMEU_TABLE].Rows.Clear();
            this._modelNameUTable.Clear();

            // ADD 2009/03/24 �s��Ή�[12693]�F�u�폜�σf�[�^�̕\���v�͍ŏ�ʍ��ڂŐ��� ---------->>>>>
            // readCount�����̏ꍇ�A�����I��
            if (readCount < 0) return 0;
            // ADD 2009/03/24 �s��Ή�[12693]�F�u�폜�σf�[�^�̕\���v�͍ŏ�ʍ��ڂŐ��� ----------<<<<<

            // �I������Ă��郁�[�J�[�f�[�^���擾����
            string guid = (string)this.Bind_DataSet.Tables[I_MAKERUMNT_TABLE].Rows[this._mainDataIndex][I_MAKERUMNT_GUID];
            MakerUMnt makerUMnt = (MakerUMnt)this._makerUTable[guid];

            // ���[�J�[�R�[�h�w�� �Ԏ햼�̌��������i�_���폜�܂ށj
            status = this._modelNameUAcs.SearchAll(makerUMnt.GoodsMakerCd, out arrModelNameU, this._enterpriseCode);

            // �Ԏ햼�̂̃��R�[�h��ێ�
            CacheModelNameUList(makerUMnt.GoodsMakerCd, arrModelNameU); // ADD 2009/03/24 �s��Ή�[12693]�F�u�폜�σf�[�^�̕\���v�͍ŏ�ʍ��ڂŐ���

            this._totalCount = arrModelNameU.Count;

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                    {
                        // �擾�����Ԏ햼�̃N���X���f�[�^�Z�b�g�֓W�J����
                        int index = 0;
                        foreach (ModelNameU modelNameU in arrModelNameU)
                        {
                            // �Ԏ햼�̃N���X�f�[�^�Z�b�g�W�J����
                            ModelNameUToDataSet(modelNameU.Clone(), index);
                            ++index;
                        }

                        // �\�[�g
                        //this.Bind_DataSet.Tables[S_MODELNAMEU_TABLE].DefaultView.Sort = S_MODELCODE + ", " + S_MODELSUBCODE + " ASC";
                        
                        break;
                    }
                default:
                    {
                        // ���׃f�[�^��������
                        TMsgDisp.Show(
                            this, 								        // �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_STOP, 		        // �G���[���x��
                            PG_ID, 						                // �A�Z���u���h�c�܂��̓N���X�h�c
                            PG_NAME,        					        // �v���O��������
                            "DetailsDataSearch", 				        // ��������
                            TMsgDisp.OPE_GET, 					        // �I�y���[�V����
                            "�Ԏ햼�̏��̓ǂݍ��݂Ɏ��s���܂����B",	// �\�����郁�b�Z�[�W
                            status, 							        // �X�e�[�^�X�l
                            this._modelNameUAcs, 				        // �G���[�����������I�u�W�F�N�g
                            MessageBoxButtons.OK, 				        // �\������{�^��
                            MessageBoxDefaultButton.Button1);	        // �����\���{�^��
                        
                        break;
                    }
            }

            totalCount = this._totalCount;

            // ���C���e�[�u���̍폜�����T�u�e�[�u������ݒ�
            SetDelateDateOfMainTable(); // ADD 2009/03/24 �s��Ή�[12693]�F�u�폜�σf�[�^�̕\���v�͍ŏ�ʍ��ڂŐ���

            return status;
        }

        /// <summary>
        /// ���׃l�N�X�g�f�[�^��������
        /// </summary>
        /// <param name="readCount">���o�Ώی���</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �w�肵���������̃l�N�X�g�f�[�^���������܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.12</br>
        /// </remarks>
        public int DetailsDataSearchNext(int readCount)
        {
            return 9;
        }

        /// <summary>
        /// �f�[�^�폜����
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �I�𒆂̃f�[�^���폜���܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.12</br>
        /// </remarks>
        public int Delete()
        {
            int status = 0;
            string guid = (string)this.Bind_DataSet.Tables[S_MODELNAMEU_TABLE].Rows[this._detailsDataIndex][S_MODELNAMEU_GUID];
            ModelNameU modelNameU = ((ModelNameU)this._modelNameUTable[guid]).Clone();

            if (modelNameU.Division == DIVISION_OFR)
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

            status = this._modelNameUAcs.LogicalDelete(ref modelNameU);
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
                        ExclusiveTransaction(status, TMsgDisp.OPE_DELETE, this._modelNameUAcs);
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
                            this._modelNameUAcs,				// �G���[�����������I�u�W�F�N�g
                            MessageBoxButtons.OK,				// �\������{�^��
                            MessageBoxDefaultButton.Button1);	// �����\���{�^��

                        return status;
                    }
            }

            // �f�[�^�Z�b�g�W�J����
            ModelNameUToDataSet(modelNameU.Clone(), this._detailsDataIndex);
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
        /// <br>Date       : 2008.06.12</br>
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
        /// <br>Date       : 2008.06.12</br>
        /// </remarks>
        public void GetAppearanceTable(out Hashtable[] appearanceTable)
        {
            // ���C���O���b�h
            Hashtable mainAppearanceTable = new Hashtable();

            // �폜��
            // ADD 2008/03/24 �s��Ή�[12693]���F�u�폜�σf�[�^�̕\���v�͍ŏ�ʍ��ڂŐ���
            mainAppearanceTable.Add(S_DELETEDATE, new GridColAppearance(MGridColDispType.DeletionDataBoth, ContentAlignment.MiddleLeft, "", Color.Red));
            // ���[�J�[�R�[�h
            mainAppearanceTable.Add(I_MAKERCODE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            // ���[�J�[��
            mainAppearanceTable.Add(I_MAKERNAME, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // ���[�J�[���GUID
            mainAppearanceTable.Add(I_MAKERUMNT_GUID, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));


            // �T�u�O���b�h
            Hashtable detailsAppearanceTable = new Hashtable();

            // �폜��
            detailsAppearanceTable.Add(S_DELETEDATE, new GridColAppearance(MGridColDispType.DeletionDataBoth, ContentAlignment.MiddleLeft, "", Color.Red));
            // �ݒ胁�[�J�[�R�[�h
            detailsAppearanceTable.Add(S_MAKERCODE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            // �Ԏ�R�[�h
            detailsAppearanceTable.Add(S_MODELCODE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            // �Ԏ햼
            detailsAppearanceTable.Add(S_MODELNAME, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // �ď̃R�[�h
            detailsAppearanceTable.Add(S_MODELSUBCODE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            // �ď�
            detailsAppearanceTable.Add(S_MODELALIASNAME, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // �Ԏ���GUID
            detailsAppearanceTable.Add(S_MODELNAMEU_GUID, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));

            appearanceTable = new Hashtable[2];
            appearanceTable[0] = mainAppearanceTable;
            appearanceTable[1] = detailsAppearanceTable;
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
        /// <br>Date       : 2008.06.12</br>
        /// </remarks>
        private void PMKHN09030UA_Load(object sender, System.EventArgs e)
        {
            // �A�C�R�����\�[�X�Ǘ��N���X���g�p���āA�A�C�R����\������
            ImageList imageList24 = IconResourceManagement.ImageList24;
            ImageList imageList16 = IconResourceManagement.ImageList16;

            this.Ok_Button.ImageList = imageList24;
            this.Cancel_Button.ImageList = imageList24;
            this.Revive_Button.ImageList = imageList24;
            this.Delete_Button.ImageList = imageList24;

            this.Ok_Button.Appearance.Image = Size24_Index.SAVE;
            this.Cancel_Button.Appearance.Image = Size24_Index.CLOSE;
            this.Revive_Button.Appearance.Image = Size24_Index.REVIVAL;
            this.Delete_Button.Appearance.Image = Size24_Index.DELETE;

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
        /// <br>Date       : 2008.06.12</br>
        /// </remarks>
        private void PMKHN09030UA_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // Grid��IndexBuffer�i�[�p�ϐ�������
            this._mainIndexBuffer = -2;
            this._detailsIndexBuffer = -2;
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
        /// <br>Date       : 2008.06.12</br>
        /// </remarks>
        private void PMKHN09030UA_VisibleChanged(object sender, System.EventArgs e)
        {
            if (!this.flag) // ADD 2010.04.26 xiaoxd
            {
                // �������g����\���ɂȂ����ꍇ�͈ȉ��̏������L�����Z������B
                if (this.Visible == false)
                {
                    // ���C���t���[���A�N�e�B�u��
                    this.Owner.Activate();
                    return;
                }

                if (this._targetTableName == S_MODELNAMEU_TABLE)
                {
                    if (this._detailsIndexBuffer == this._detailsDataIndex)
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
            }




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
        /// <br>Date       : 2008.06.12</br>
        /// </remarks>
        private void Ok_Button_Click(object sender, System.EventArgs e)
        {
            this.Ok_Button.Focus();
            if (!SaveProc())
            {
                return;
            }
            // ADD 2010.04.26 xiaoxd >>>>>>>>>
            if (this.flag)
            {
                this.Close();
            }
            // ADD 2010.04.26 xiaoxd <<<<<<<<<

            // ��ʔ�\���C�x���g
            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                UnDisplaying(this, me);
            }

            // ADD 2008/10/07 �s��Ή�[6320] ---------->>>>>
            // �V�K���[�h�̏ꍇ�͉�ʂ��I���������ɘA�����͂��\�Ƃ���B
            if (this.Mode_Label.Text == INSERT_MODE)
            {
                // ��ʂ�������
                this.ScreenClear();

                // ��ʂ��č\�z
                this.ScreenReconstruction();
                
            }
            else
            {
            // ADD 2008/10/07 �s��Ή�[6320] ----------<<<<<
                this.DialogResult = DialogResult.OK;

                // Grid��IndexBuffer�i�[�p�ϐ�������
                this._mainIndexBuffer = -2;
                this._detailsIndexBuffer = -2;
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
            // ADD 2008/10/07 �s��Ή�[6320] ---------->>>>>
            }
            // ADD 2008/10/07 �s��Ή�[6320] ----------<<<<<
        }

        /// <summary>
        /// ����{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�f�[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@  : ����{�^���R���g���[�����N���b�N���ꂽ���ɔ������܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.12</br>
        /// </remarks>
        private void Cancel_Button_Click(object sender, System.EventArgs e)
        {
            // �X�V�L���t���O
            //bool isUpdate = false;

            //�ۑ��m�F
            ModelNameU compareModelNameU = new ModelNameU();
            compareModelNameU = this._modelNameUClone.Clone();
            //���݂̉�ʏ����擾����
            DispToModelNameU(ref compareModelNameU);

            //�ŏ��Ɏ擾������ʏ��Ɣ�r
            if (!(this._modelNameUClone.Equals(compareModelNameU)))
            {
                // ��ʏ�񂪕ύX����Ă����ꍇ�́A�ۑ��m�F���b�Z�[�W��\������
                // �ۑ��m�F
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
            this._detailsIndexBuffer = -2;
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
        /// <br>Date       : 2008.06.13</br>
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
                string guid = (string)this.Bind_DataSet.Tables[S_MODELNAMEU_TABLE].Rows[this._detailsDataIndex][S_MODELNAMEU_GUID];
                ModelNameU modelNameU = ((ModelNameU)this._modelNameUTable[guid]).Clone();

                status = this._modelNameUAcs.Delete(modelNameU);
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        {
                            this.Bind_DataSet.Tables[S_MODELNAMEU_TABLE].Rows[this._detailsDataIndex].Delete();
                            this._modelNameUTable.Remove(modelNameU.FileHeaderGuid);
                            break;
                        }
                    case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                        {
                            ExclusiveTransaction(status, TMsgDisp.OPE_DELETE, this._modelNameUAcs);

                            if (UnDisplaying != null)
                            {
                                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                                UnDisplaying(this, me);
                            }

                            this.DialogResult = DialogResult.Cancel;
                            this._detailsIndexBuffer = -2;

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
                                this._modelNameUAcs,					  // �G���[�����������I�u�W�F�N�g
                                MessageBoxButtons.OK,				  // �\������{�^��
                                MessageBoxDefaultButton.Button1);	  // �����\���{�^��

                            if (UnDisplaying != null)
                            {
                                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                                UnDisplaying(this, me);
                            }

                            this.DialogResult = DialogResult.Cancel;
                            this._detailsIndexBuffer = -2;

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
            this._detailsIndexBuffer = -2;

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
        /// <br>Date       : 2008.06.13</br>
        /// </remarks>
        private void Revive_Button_Click(object sender, System.EventArgs e)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            string guid = (string)this.Bind_DataSet.Tables[S_MODELNAMEU_TABLE].Rows[this._detailsDataIndex][S_MODELNAMEU_GUID];
            ModelNameU modelNameU = ((ModelNameU)this._modelNameUTable[guid]).Clone();

            status = this._modelNameUAcs.Revival(ref modelNameU);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        ExclusiveTransaction(status, TMsgDisp.OPE_UPDATE, this._modelNameUAcs);

                        if (UnDisplaying != null)
                        {
                            MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                            UnDisplaying(this, me);
                        }

                        this.DialogResult = DialogResult.Cancel;
                        this._detailsIndexBuffer = -2;

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
                            this._modelNameUAcs,					  // �G���[�����������I�u�W�F�N�g
                            MessageBoxButtons.OK,				  // �\������{�^��
                            MessageBoxDefaultButton.Button1);	  // �����\���{�^��

                        if (UnDisplaying != null)
                        {
                            MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                            UnDisplaying(this, me);
                        }

                        this.DialogResult = DialogResult.Cancel;
                        this._detailsIndexBuffer = -2;

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
            ModelNameUToDataSet(modelNameU, this._detailsIndexBuffer);

            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                UnDisplaying(this, me);
            }

            this.DialogResult = DialogResult.OK;
            this._detailsIndexBuffer = -2;

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
        /// �Ԏ햼�̃K�C�h�{�^�������C�x���g
        /// </summary>
        /// <param name="sender">�R���g���[��</param>
        /// <param name="e">�C�x���g�f�[�^</param>
        /// <remarks>
        /// <br>Note       : �Ԏ햼�̃K�C�h�{�^���������̏������s���܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.13</br>
        /// </remarks>
        private void uButton_ModelGuide_Click(object sender, EventArgs e)
        {
            ModelNameU modelNameU = null;
            string message;
            int status = this.ShowModelNameGuide(out modelNameU);

            if (status == 0)
            {
                // �I�����������擾
                this.ModelCode_tNedit.SetInt(modelNameU.ModelCode);
                this.ModelSubCodea_tNedit.SetInt(modelNameU.ModelSubCode);
                this.ModelFullName_tEdit.Text = modelNameU.ModelFullName;
                this.ModelHalfName_tEdit.Text = modelNameU.ModelHalfName;
                this.ModelAliasName_tEdit.Text = modelNameU.ModelAliasName;

                // ���̃R���g���[���փt�H�[�J�X���ړ�
                this.SelectNextControl((Control)sender, true, true, true, true);
            }

            else if (status == -1)
            {
                // ���[�J�[�R�[�h��������
                //message = this.ModelCode_Label.Text + "����͂��ĉ������B"; // DEL 2010.04.26 xiaoxd
                message = this.MakerCode_Label.Text + "����͂��ĉ������B"; // ADD 2010.04.26 xiaoxd
                TMsgDisp.Show(
                    this,								// �e�E�B���h�E�t�H�[��
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,	// �G���[���x��
                    PG_ID,      						// �A�Z���u���h�c�܂��̓N���X�h�c
                    message,							// �\�����郁�b�Z�[�W 
                    0,									// �X�e�[�^�X�l
                    MessageBoxButtons.OK);				// �\������{�^��

                MakerCode_tNedit.Focus();
            }
            else
            {
                ((Control)sender).Focus();
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
        /// <br>Date       : 2008.06.12</br>
        /// </remarks>
        private void Initial_Timer_Tick(object sender, System.EventArgs e)
        {
            Initial_Timer.Enabled = false;

            // ��ʍč\�z����
            ScreenReconstruction();
        }

        /// <summary>
        /// ���^�[���L�[�ړ��C�x���g
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���^�[���L�[�������̐�����s���܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.16</br>
        /// </remarks>
        private void tRetKeyControl1_ChangeFocus(object sender, Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null || e.NextCtrl == null) return;

            // 2009.03.30 30413 ���� �폜 >>>>>>START
            //bool canChangeFocus = true;

            //object inParamObj = null;
            //object outParamObj = null;
            //ArrayList inParamList = new ArrayList();

            //switch (e.PrevCtrl.Name)
            //{
            //    // �Ԏ�R�[�h
            //    case "ModelCode_tNedit":
            //        {
            //            // �����ݒ�N���A
            //            inParamObj = null;
            //            outParamObj = null;

            //            // �����ݒ�
            //            inParamObj = this.ModelCode_tNedit.GetInt();

            //            // �Ԏ햼�擾
            //            outParamObj = this.GetModelName((int)inParamObj);

            //            // �Ԏ햼�̑��݃`�F�b�N
            //            if (outParamObj.Equals(""))
            //            {
            //                //this.ModelCode_tNedit.Clear();
            //                //this.ModelFullName_tEdit.Clear();
            //            }
            //            else
            //            {
            //                // �Ԏ햼�ݒ�
            //                this.ModelFullName_tEdit.Text = (string)outParamObj;
            //            }
            //            break;
            //        }
            //}

            //// �t�H�[�J�X����
            //if (canChangeFocus == false)
            //{
            //    e.NextCtrl = e.PrevCtrl;

            //    // ���݂̍��ڂ���ړ������A�e�L�X�g�S�I����ԂƂ���
            //    e.NextCtrl.Select();
            //}
            // 2009.03.30 30413 ���� �폜 <<<<<<END
            
            // 2009.03.30 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� >>>>>>START
            switch (e.NextCtrl.Name)
            {
                case "ModelFullName_tEdit":     // �Ԏ햼
                case "ModelHalfName_tEdit":     // �Ԏ햼(�J�i)
                case "ModelAliasName_tEdit":    // �ď�
                    {
                        if (this._detailsDataIndex < 0)
                        { 
                            //if (ModeChangeProc()) // DEL 2010.04.26 xiaoxd
                            if (!this.flag && ModeChangeProc())// ADD 2010.04.26 xiaoxd
                            {
                                e.NextCtrl = ModelCode_tNedit;
                            }
                        }
                        break;
                    }
            }
            // 2009.03.30 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� <<<<<<END
        }

        /// <summary>
        /// ModelCode_tNedit_Leave �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : �t�H�[�J�X���������Ƃ��ɔ���</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.16</br>
        /// </remarks>
        private void ModelCode_tNedit_Leave(object sender, EventArgs e)
        {
            // ���[�J�[�R�[�h���󔒂Ȃ�Ή������Ȃ�
            if (this.ModelCode_tNedit.Text == "")
            {
                this.ModelCode_tNedit.Clear();
                //this.MakerCodeNm_tEdit.Clear();
            }
        }

        /// <summary>
        /// ModelCode_tNedit_BeforeEnterEditMode
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : �R���g���[�����ҏW���[�h�ɓ���O�ɔ������܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.16</br>
        /// </remarks>
        private void ModelCode_tNedit_BeforeEnterEditMode(object sender, CancelEventArgs e)
        {
            // ChangeFocus�C�x���g�ꎞ��~
            this.tArrowKeyControl1.ChangeFocus -= this.tRetKeyControl1_ChangeFocus;

            // �擪�̃[���l�߂��폜
            //this.ModelCode_tNedit.Text = GetZeroPadCanceledTextProc(this.ModelCode_tNedit.Text);

            // ChangeFocus�C�x���g�ĊJ
            this.tArrowKeyControl1.ChangeFocus += new ChangeFocusEventHandler(tRetKeyControl1_ChangeFocus);
        }

        /// <summary>
        /// ModelFullName_tEdit_ValueChanged
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : �Ԏ햼�̒l���ύX�����Ɣ������܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.09.11</br>
        /// </remarks>
        private void ModelFullName_tEdit_ValueChanged(object sender, EventArgs e)
        {
            TEdit tEdit = sender as TEdit;

            if (tEdit.Text == "")
            {
                this.ModelHalfName_tEdit.Text = "";
                this.ModelAliasName_tEdit.Text = "";
            }
        }

        /// <summary>
        /// ModelHalfName_tEdit_ValueChanged
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : �Ԏ햼(�J�i)�̒l���ύX�����Ɣ������܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.09.16</br>
        /// </remarks>
        private void ModelHalfName_tEdit_ValueChanged(object sender, EventArgs e)
        {
            TEdit tEdit = sender as TEdit;
            // �S�p�J�i�𔼊p�łɋ����ϊ�
            tEdit.Text = Microsoft.VisualBasic.Strings.StrConv(tEdit.Text, Microsoft.VisualBasic.VbStrConv.Narrow, 0);

            // 2008.11.07 add start [7476]
            if (tEdit.Text.Length > this.tImeControl1.PutLength)
            {
                tEdit.Text = tEdit.Text.Substring(0, this.tImeControl1.PutLength);
            }
            // 2008.11.07 add end [7476]
        }

        /// <summary>
        /// ModelAliasName_tEdit_ValueChanged
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : �ď̂̒l���ύX�����Ɣ������܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.09.16</br>
        /// </remarks>
        private void ModelAliasName_tEdit_ValueChanged(object sender, EventArgs e)
        {
            TEdit tEdit = sender as TEdit;
            // �S�p�J�i�𔼊p�łɋ����ϊ�
            tEdit.Text = Microsoft.VisualBasic.Strings.StrConv(tEdit.Text, Microsoft.VisualBasic.VbStrConv.Narrow, 0);

            // 2008.11.07 add start [7476]
            if (tEdit.Text.Length > this.tImeControl2.PutLength)
            {
                tEdit.Text = tEdit.Text.Substring(0, this.tImeControl2.PutLength);
            }
            // 2008.11.07 add end [7476]
        }

        # endregion

        #region Private Methods

        /// <summary>
        /// ���[�J�[�N���X�f�[�^�Z�b�g�W�J����
        /// </summary>
        /// <param name="makerUMnt">���[�J�[�N���X</param>
        /// <param name="index">�f�[�^�Z�b�g�֓W�J����C���f�b�N�X</param>
        /// <remarks>
        /// <br>Note       : ���[�J�[�N���X���f�[�^�Z�b�g�֊i�[���܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.12</br>
        /// </remarks>
        private void MakerUMntToDataSet(MakerUMnt makerUMnt, int index)
        {
            if ((index < 0) || (this.Bind_DataSet.Tables[I_MAKERUMNT_TABLE].Rows.Count <= index))
            {
                // �V�K�Ɣ��f���āA�s��ǉ�����
                DataRow dataRow = this.Bind_DataSet.Tables[I_MAKERUMNT_TABLE].NewRow();
                this.Bind_DataSet.Tables[I_MAKERUMNT_TABLE].Rows.Add(dataRow);

                // index���s�̍ŏI�s�ԍ��ɂ���
                index = this.Bind_DataSet.Tables[I_MAKERUMNT_TABLE].Rows.Count - 1;
            }

            // �폜��
            // ADD 2008/03/24 �s��Ή�[12693]���F�u�폜�σf�[�^�̕\���v�͍ŏ�ʍ��ڂŐ���
            this.Bind_DataSet.Tables[I_MAKERUMNT_TABLE].Rows[index][S_DELETEDATE] = GetDeleteDate(makerUMnt);

            // ���[�J�[�R�[�h
            // 2008.09.26 30413 ���� �[���l�ߑΉ� >>>>>>START
            //this.Bind_DataSet.Tables[I_MAKERUMNT_TABLE].Rows[index][I_MAKERCODE] = makerUMnt.GoodsMakerCd;
            this.Bind_DataSet.Tables[I_MAKERUMNT_TABLE].Rows[index][I_MAKERCODE] = makerUMnt.GoodsMakerCd.ToString("d04");
            // 2008.09.26 30413 ���� �[���l�ߑΉ� <<<<<<END
            
            // ���[�J�[��
            this.Bind_DataSet.Tables[I_MAKERUMNT_TABLE].Rows[index][I_MAKERNAME] = makerUMnt.MakerName;

            // ���[�J�[���GUID
            this.Bind_DataSet.Tables[I_MAKERUMNT_TABLE].Rows[index][I_MAKERUMNT_GUID] = CreateHashKey(makerUMnt);
            
            // �n�b�V�������p��GUID�Z�b�g
            this._makerUTable.Add(CreateHashKey(makerUMnt), makerUMnt);
            if (this._makerUTable.ContainsKey(CreateHashKey(makerUMnt)) == true)
            {
                this._makerUTable.Remove(CreateHashKey(makerUMnt));
            }
            this._makerUTable.Add(CreateHashKey(makerUMnt), makerUMnt);
        }

        // ADD 2009/03/24 �s��Ή�[12693]�F�u�폜�σf�[�^�̕\���v�͍ŏ�ʍ��ڂŐ��� ---------->>>>>
        /// <summary>
        /// ���C���e�[�u���̍폜�����擾���܂��B
        /// </summary>
        /// <param name="makerUMnt">���[�J�[�N���X</param>
        /// <returns>���C���e�[�u���̍폜���i�폜����Ă��Ȃ��ꍇ�A<c>string.Empty</c>��Ԃ��܂��B�j</returns>
        private string GetDeleteDate(MakerUMnt makerUMnt)
        {
            if (makerUMnt.LogicalDeleteCode.Equals(0))
            {
                return string.Empty;
            }
            else
            {
                return makerUMnt.UpdateDateTimeJpInFormal;
            }
        }

        #region <�Ԏ햼�̂̃L���b�V��/>

        /// <summary>�Ԏ햼�̂̃L���b�V��</summary>
        /// <remarks>�L�[�F���[�J�[�R�[�h</remarks>
        private readonly IDictionary<int, ArrayList> _modelNameUListCacheMap = new Dictionary<int, ArrayList>();
        /// <summary>
        /// �Ԏ햼�̂̃L���b�V�����擾���܂��B
        /// </summary>
        private IDictionary<int, ArrayList> ModelNameUListCacheMap
        {
            get { return _modelNameUListCacheMap; }
        }

        /// <summary>
        /// �Ԏ햼�̂��L���b�V�����܂��B
        /// </summary>
        /// <param name="makerCode">���[�J�[�R�[�h</param>
        /// <param name="modelNameUList">�Ԏ햼�̂̃��R�[�h���X�g</param>
        private void CacheModelNameUList(
            int makerCode,
            ArrayList modelNameUList
        )
        {
            if (ModelNameUListCacheMap.ContainsKey(makerCode))
            {
                ModelNameUListCacheMap.Remove(makerCode);
            }
            ModelNameUListCacheMap.Add(makerCode, (modelNameUList != null ? modelNameUList : new ArrayList()));
        }

        #endregion  // <�Ԏ햼�̂̃L���b�V��/>

        /// <summary>
        /// ���C���e�[�u���̍폜����ݒ肵�܂��B
        /// </summary>
        [Conditional("DELETE_DATE_DEPEND_ON_SUB_TABLE")]
        private void SetDelateDateOfMainTable()
        {
            const string MAIN_TABLE_NAME        = I_MAKERUMNT_TABLE;
            const string RELATION_COLUMN_NAME   = S_MAKERCODE;
            const string SUB_TABLE_NAME         = S_MODELNAMEU_TABLE;
            const string DELETE_DATE_COLUMN_NAME= S_DELETEDATE;

            foreach (DataRow mainRow in this.Bind_DataSet.Tables[MAIN_TABLE_NAME].Rows)
            {
                // �Ή�����T�u�e�[�u���̃��R�[�h�𒊏o
                string strRelationColumn = mainRow[I_MAKERCODE].ToString();
                int relationColumn = (string.IsNullOrEmpty(strRelationColumn) ? 0 : int.Parse(strRelationColumn));
                DataRow[] foundSubRows = this.Bind_DataSet.Tables[SUB_TABLE_NAME].Select(
                    RELATION_COLUMN_NAME + "=" + relationColumn.ToString()
                );
                Debug.WriteLine("�֘A = " + relationColumn.ToString() + ":" + foundSubRows.Length.ToString() + "��");

                if (foundSubRows.Length.Equals(0))
                {
                    #region �T�u�e�[�u���ɊY�����R�[�h�������ꍇ�ADB�������ʁi�L���b�V���j���ݒ�

                    // ���[�J�[�R�[�h�w�� �Ԏ햼�̌��������i�_���폜�܂ށj
                    ArrayList modelNameUList = null;
                    if (ModelNameUListCacheMap.ContainsKey(relationColumn))
                    {
                        modelNameUList = ModelNameUListCacheMap[relationColumn];
                    }
                    else
                    {
                        int status = this._modelNameUAcs.SearchAll(relationColumn, out modelNameUList, this._enterpriseCode);
                        CacheModelNameUList(relationColumn, modelNameUList);
                    }
                    if (modelNameUList == null || modelNameUList.Count.Equals(0)) continue;

                    // �폜�����~���Œ��o
                    int deleteRowCount = 0;
                    SortedList<string, string> sortedDeleteDateList = new SortedList<string, string>(
                        new ReverseComparer<string>()
                    );
                    foreach (ModelNameU modelNameU in modelNameUList)
                    {
                        if (modelNameU.LogicalDeleteCode.Equals(0)) continue;

                        deleteRowCount++;
                        if (!sortedDeleteDateList.ContainsKey(modelNameU.UpdateDateTimeJpInFormal))
                        {
                            sortedDeleteDateList.Add(
                                modelNameU.UpdateDateTimeJpInFormal,
                                modelNameU.UpdateDateTimeJpInFormal
                            );
                        }
                    }

                    // ���R�[�h���S���폜����Ă���ꍇ
                    string deleteDate = string.Empty;
                    if (deleteRowCount > 0 && deleteRowCount.Equals(modelNameUList.Count))
                    {
                        deleteDate = sortedDeleteDateList.Values[0];
                    }
                    mainRow[DELETE_DATE_COLUMN_NAME] = deleteDate;

                    #endregion  // �T�u�e�[�u���ɊY�����R�[�h�������ꍇ�ADB�������ʁi�L���b�V���j���ݒ�
                }
                else
                {
                    #region �T�u�e�[�u���ɊY�����R�[�h������ꍇ�A�T�u�e�[�u�����ݒ�

                    // �폜�����~���Œ��o
                    int deleteRowCount = 0;
                    SortedList<string, string> sortedDeleteDateList = new SortedList<string, string>(
                        new ReverseComparer<string>()
                    );
                    foreach (DataRow subRow in foundSubRows)
                    {
                        Debug.WriteLine("�폜���F" + subRow[DELETE_DATE_COLUMN_NAME].ToString());
                        if (string.IsNullOrEmpty(subRow[DELETE_DATE_COLUMN_NAME].ToString()))
                        {
                            continue;
                        }

                        deleteRowCount++;
                        if (!sortedDeleteDateList.ContainsKey(subRow[DELETE_DATE_COLUMN_NAME].ToString()))
                        {
                            sortedDeleteDateList.Add(
                                subRow[DELETE_DATE_COLUMN_NAME].ToString(),
                                subRow[DELETE_DATE_COLUMN_NAME].ToString()
                            );
                        }
                    }

                    // �T�u�e�[�u�����S���폜����Ă���ꍇ
                    string deleteDate = string.Empty;
                    if (deleteRowCount > 0 && deleteRowCount.Equals(foundSubRows.Length))
                    {
                        deleteDate = sortedDeleteDateList.Values[0];
                    }
                    mainRow[DELETE_DATE_COLUMN_NAME] = deleteDate;

                    #endregion  // �T�u�e�[�u���ɊY�����R�[�h������ꍇ�A�T�u�e�[�u�����ݒ�
                }
            }
        }
        // ADD 2009/03/24 �s��Ή�[12693]�F�u�폜�σf�[�^�̕\���v�͍ŏ�ʍ��ڂŐ��� ----------<<<<<

        /// <summary>
        /// �Ԏ햼�̃N���X�f�[�^�Z�b�g�W�J����
        /// </summary>
        /// <param name="modelNameU">�Ԏ햼�̃N���X</param>
        /// <param name="index">�f�[�^�Z�b�g�֓W�J����C���f�b�N�X</param>
        /// <remarks>
        /// <br>Note       : ���_����N���X���f�[�^�Z�b�g�֊i�[���܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.13</br>
        /// </remarks>
        private void ModelNameUToDataSet(ModelNameU modelNameU, int index)
        {
            if ((index < 0) || (this.Bind_DataSet.Tables[S_MODELNAMEU_TABLE].Rows.Count <= index))
            {
                // �V�K�Ɣ��f���āA�s��ǉ�����
                DataRow dataRow = this.Bind_DataSet.Tables[S_MODELNAMEU_TABLE].NewRow();
                this.Bind_DataSet.Tables[S_MODELNAMEU_TABLE].Rows.Add(dataRow);

                // index���s�̍ŏI�s�ԍ�����
                index = this.Bind_DataSet.Tables[S_MODELNAMEU_TABLE].Rows.Count - 1;
            }

            // �폜��
            if (modelNameU.LogicalDeleteCode == 0)
            {
                this.Bind_DataSet.Tables[S_MODELNAMEU_TABLE].Rows[index][S_DELETEDATE] = "";
            }
            else
            {
                this.Bind_DataSet.Tables[S_MODELNAMEU_TABLE].Rows[index][S_DELETEDATE] = TDateTime.DateTimeToString("ggYY/MM/DD", modelNameU.UpdateDateTime);
            }

            // �ݒ胁�[�J�[�R�[�h
            this.Bind_DataSet.Tables[S_MODELNAMEU_TABLE].Rows[index][S_MAKERCODE] = modelNameU.MakerCode;

            // 2008.09.26 30413 ���� �[���l�ߑΉ� >>>>>>START
            // �Ԏ�R�[�h
            //this.Bind_DataSet.Tables[S_MODELNAMEU_TABLE].Rows[index][S_MODELCODE] = modelNameU.ModelCode;
            this.Bind_DataSet.Tables[S_MODELNAMEU_TABLE].Rows[index][S_MODELCODE] = modelNameU.ModelCode.ToString("d03");

            // �ď̃R�[�h
            //this.Bind_DataSet.Tables[S_MODELNAMEU_TABLE].Rows[index][S_MODELSUBCODE] = modelNameU.ModelSubCode;
            this.Bind_DataSet.Tables[S_MODELNAMEU_TABLE].Rows[index][S_MODELSUBCODE] = modelNameU.ModelSubCode.ToString("d03");
            // 2008.09.26 30413 ���� �[���l�ߑΉ� <<<<<<END
            
            // �Ԏ햼
            this.Bind_DataSet.Tables[S_MODELNAMEU_TABLE].Rows[index][S_MODELNAME] = modelNameU.ModelFullName;

            // �ď�
            this.Bind_DataSet.Tables[S_MODELNAMEU_TABLE].Rows[index][S_MODELALIASNAME] = modelNameU.ModelAliasName;

            // �Ԏ햼�̏��GUID
            this.Bind_DataSet.Tables[S_MODELNAMEU_TABLE].Rows[index][S_MODELNAMEU_GUID] = CreateHashKey(modelNameU);

            // �n�b�V�������p��GUID�Z�b�g
            if (this._modelNameUTable.ContainsKey(CreateHashKey(modelNameU)) == true)
            {
                this._modelNameUTable.Remove(CreateHashKey(modelNameU));
            }
            this._modelNameUTable.Add(CreateHashKey(modelNameU), modelNameU);
        }

        /// <summary>
        /// �Ԏ햼�̃}�X�^ �N���X��ʓW�J����
        /// </summary>
        /// <param name="modelNameU">�Ԏ햼�̃}�X�^ �I�u�W�F�N�g</param>
        /// <remarks>
        /// <br>Note       : �Ԏ햼�̃}�X�^ �I�u�W�F�N�g�����ʂɃf�[�^��W�J���܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.13</br>
        /// </remarks>
        private void ModelNameUToScreen(ModelNameU modelNameU)
        {
            this.MakerCode_tNedit.SetInt(modelNameU.MakerCode);                     // ���[�J�[�R�[�h
            this.MakerCodeNm_tEdit.Text = GetMakerName(modelNameU.MakerCode);       // ���[�J�[��
            this.ModelCode_tNedit.SetInt(modelNameU.ModelCode);                     // �Ԏ�R�[�h
            this.ModelSubCodea_tNedit.SetInt(modelNameU.ModelSubCode);               // �ď̃R�[�h
            this.ModelFullName_tEdit.Text = modelNameU.ModelFullName;               // �Ԏ햼
            this.ModelHalfName_tEdit.Text = modelNameU.ModelHalfName;               // �Ԏ햼(��)
            this.ModelAliasName_tEdit.Text = modelNameU.ModelAliasName;             // �ď�
        }

        /// <summary>
        /// ��ʏ��Ԏ햼�̃}�X�^ �N���X�i�[����
        /// </summary>
        /// <param name="modelNameU">�Ԏ햼�̃}�X�^ �I�u�W�F�N�g</param>
        /// <remarks>
        /// <br>Note       : ��ʏ�񂩂�Ԏ햼�̃}�X�^ �I�u�W�F�N�g�Ƀf�[�^���i�[���܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.12</br>
        /// </remarks>
        private void DispToModelNameU(ref ModelNameU modelNameU)
        {
            if (modelNameU == null)
            {
                // �V�K�̏ꍇ
                modelNameU = new ModelNameU();
            }

            modelNameU.EnterpriseCode = this._enterpriseCode;                       // ��ƃR�[�h

            modelNameU.MakerCode = this.MakerCode_tNedit.GetInt();                  // ���[�J�[�R�[�h
            modelNameU.ModelCode = this.ModelCode_tNedit.GetInt();                  // �Ԏ�R�[�h
            modelNameU.ModelSubCode = this.ModelSubCodea_tNedit.GetInt();            // �ď̃R�[�h
            modelNameU.ModelFullName = this.ModelFullName_tEdit.Text.TrimEnd();     // �Ԏ햼
            modelNameU.ModelHalfName = this.ModelHalfName_tEdit.Text.TrimEnd();     // �Ԏ햼(��)
            modelNameU.ModelAliasName = this.ModelAliasName_tEdit.Text.TrimEnd();   // �ď�
        }

        /// <summary>
        /// �f�[�^�Z�b�g����\�z����
        /// </summary>
        /// <remarks>
        /// <br>Note       : DataSet�̗�����\�z���܂��B�f�[�^�Z�b�g�̗��񂪃t���[���̃r���[�p�O���b�h�̗�ɂȂ�܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.12</br>
        /// </remarks>
        private void DataSetColumnConstruction()
        {
            // ���C���e�[�u���̗��`
            DataTable _makerUMntDt = new DataTable(I_MAKERUMNT_TABLE);

            // Add���s�����Ԃ��A��̕\�����ʂƂȂ�܂��B
            // ADD 2008/03/24 �s��Ή�[12693]���F�u�폜�σf�[�^�̕\���v�͍ŏ�ʍ��ڂŐ���
            _makerUMntDt.Columns.Add(S_DELETEDATE, typeof(string));        // �폜��
            // 2008.09.26 30413 ���� �[���l�ߑΉ� >>>>>>START
            //_makerUMntDt.Columns.Add(I_MAKERCODE, typeof(int));			    // ���[�J�[�R�[�h
            _makerUMntDt.Columns.Add(I_MAKERCODE, typeof(string));			    // ���[�J�[�R�[�h
            // 2008.09.26 30413 ���� �[���l�ߑΉ� <<<<<<END
            _makerUMntDt.Columns.Add(I_MAKERNAME, typeof(string));			// ���[�J�[��
            _makerUMntDt.Columns.Add(I_MAKERUMNT_GUID, typeof(string));     // ���[�J�[���GUID

            this.Bind_DataSet.Tables.Add(_makerUMntDt);

            // �T�u�e�[�u���̗��`
            DataTable _modelNameUDt = new DataTable(S_MODELNAMEU_TABLE);

            // Add���s�����Ԃ��A��̕\�����ʂƂȂ�܂��B
            _modelNameUDt.Columns.Add(S_DELETEDATE, typeof(string));        // �폜��
            _modelNameUDt.Columns.Add(S_MAKERCODE, typeof(string));			// �ݒ胁�[�J�[�R�[�h
            // 2008.09.26 30413 ���� �[���l�ߑΉ� >>>>>>START
            //_modelNameUDt.Columns.Add(S_MODELCODE, typeof(int));			// �Ԏ�R�[�h
            _modelNameUDt.Columns.Add(S_MODELCODE, typeof(string));			// �Ԏ�R�[�h
            // 2008.09.26 30413 ���� �[���l�ߑΉ� <<<<<<END
            _modelNameUDt.Columns.Add(S_MODELNAME, typeof(string));			// �Ԏ햼
            _modelNameUDt.Columns.Add(S_MODELSUBCODE, typeof(string));	    // �ď̃R�[�h
            _modelNameUDt.Columns.Add(S_MODELALIASNAME, typeof(string));	// �ď�
            _modelNameUDt.Columns.Add(S_MODELNAMEU_GUID, typeof(string));   // �Ԏ햼�̏��GUID

            this.Bind_DataSet.Tables.Add(_modelNameUDt);
        }

        /// <summary>
        /// ��ʏ����ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note       : ��ʂ̏����ݒ���s���܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.12</br>
        /// </remarks>
        private void ScreenInitialSetting()
        {
            this.Ok_Button.Location = new System.Drawing.Point(337, 254);
            this.Cancel_Button.Location = new System.Drawing.Point(468, 254);
            this.Delete_Button.Location = new System.Drawing.Point(209, 254);
            this.Revive_Button.Location = new System.Drawing.Point(337, 254);
        }

        /// <summary>
        /// ��ʍč\�z����
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : ���[�h�Ɋ�Â��ĉ�ʂ̍č\�z���s���܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.12</br>
        /// </remarks>
        private void ScreenReconstruction()
        {
            if (this._detailsDataIndex < 0)
            {
                if (!this.flag) // ADD 2010.04.26 xiaoxd
                {
                    // �V�K���[�h
                    this.Mode_Label.Text = INSERT_MODE;

                    // �I�����[�J�[�̏����擾
                    string makerGuid = (string)this.Bind_DataSet.Tables[I_MAKERUMNT_TABLE].Rows[this._mainDataIndex][I_MAKERUMNT_GUID];
                    MakerUMnt makerUMnt = (MakerUMnt)this._makerUTable[makerGuid];
                    // �I�����[�J�[������ʂɐݒ�
                    this.MakerCode_tNedit.SetInt(makerUMnt.GoodsMakerCd);
                    this.MakerCodeNm_tEdit.Text = makerUMnt.MakerName;

                    // ��ʓ��͋����䏈��
                    ScreenPermissionControl(INSERT_MODE);

                    // Fream��Index/Table�o�b�t�@�ێ�
                    this._mainIndexBuffer = -2;
                    this._detailsIndexBuffer = this._detailsDataIndex;
                    this._targetTableBuffer = this._targetTableName;

                    //�N���[���쐬
                    ModelNameU modelNameU = new ModelNameU();
                    this._modelNameUClone = modelNameU.Clone();
                    DispToModelNameU(ref this._modelNameUClone);

                    // �t�H�[�J�X�ݒ�
                    this.ModelCode_tNedit.Focus();
                }
                else
                {
                    // �V�K���[�h
                    this.Mode_Label.Text = INSERT_MODE;

                    ModelNameU modelNameU = new ModelNameU();

                    // ���[�J�[
                    if (!String.IsNullOrEmpty(this.maker))
                    {
                        this.MakerCode_tNedit.SetInt(Convert.ToInt32(this.maker));
                        MakerAcs makerAcs = new MakerAcs();
                        MakerUMnt makerUMnt;
                        int makerCode = this.MakerCode_tNedit.GetInt();
                        //���[�J�[�f�[�^�̎擾
                        int status = makerAcs.Read(out makerUMnt, this._enterpriseCode, makerCode);
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            //���[�J�[
                            this.MakerCodeNm_tEdit.Text = makerUMnt.MakerName;
                        }

                    }
                    //�Ԏ�R�[�h
                    if (!String.IsNullOrEmpty(this.modelCode))
                    {
                        this.ModelCode_tNedit.SetInt(Convert.ToInt32(this.modelCode));
                    }

                    if (!String.IsNullOrEmpty(this.modelSubCode))
                    {
                        this.ModelSubCodea_tNedit.SetInt(Convert.ToInt32(this.modelSubCode));
                    }

                    // ��ʓ��͋����䏈��
                    ScreenPermissionControl(INSERT_MODE);

                    // �t�H�[�J�X�ݒ�
                    this.MakerCode_tNedit.Focus();
                }

            }
            else
            {
                // �I���Ԏ햼�̂̏����擾
                string guid = (string)this.Bind_DataSet.Tables[S_MODELNAMEU_TABLE].Rows[this._detailsDataIndex][S_MODELNAMEU_GUID];
                ModelNameU modelNameU = (ModelNameU)this._modelNameUTable[guid];

                if (modelNameU.LogicalDeleteCode == 0)
                {
                    // ��ʓ��͋����䏈��
                    if (modelNameU.Division == DIVISION_OFR)
                    {
                        // �Q�ƃ��[�h
                        this.Mode_Label.Text = REFERENCE_MODE;

                        // ��ʓ��͋����䏈��
                        ScreenPermissionControl(REFERENCE_MODE);
                        
                        // ��ʓW�J����
                        ModelNameUToScreen(modelNameU);

                        //�N���[���쐬
                        this._modelNameUClone = modelNameU.Clone();
                        DispToModelNameU(ref this._modelNameUClone);

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
                        ModelNameUToScreen(modelNameU);

                        //�N���[���쐬
                        this._modelNameUClone = modelNameU.Clone();
                        DispToModelNameU(ref this._modelNameUClone);
                        
                        // �t�H�[�J�X�ݒ�
                        this.ModelCode_tNedit.Focus();
                        this.ModelCode_tNedit.SelectAll();
                    }
                }
                else
                {
                    // �폜���[�h
                    this.Mode_Label.Text = DELETE_MODE;

                    // ��ʓ��͋����䏈��
                    ScreenPermissionControl(DELETE_MODE);

                    // ��ʓW�J����
                    ModelNameUToScreen(modelNameU);

                    //�N���[���쐬
                    this._modelNameUClone = modelNameU.Clone();
                    DispToModelNameU(ref this._modelNameUClone);

                    // �t�H�[�J�X�ݒ�
                    this.Delete_Button.Focus();
                }

                // Fream��Index/Table�o�b�t�@�ێ�
                this._mainIndexBuffer = this._mainDataIndex;
                this._detailsIndexBuffer = this._detailsDataIndex;
                this._targetTableBuffer = this._targetTableName;
            }
        }

        /// <summary>
        /// ��ʋ����䏈��
        /// </summary>
        /// <param name="enabled">��ʃ��[�h</param>
        /// <remarks>
        /// <br>Note       : ��ʃ��[�h���ɓ��́^�{�^���̋��𐧌䂵�܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.13</br>
        /// </remarks>
        private void ScreenPermissionControl(string screenMode)
        {
            // �V�K
            if (screenMode.Equals(INSERT_MODE))
            {
                // �{�^���ݒ�
                this.Ok_Button.Visible = true;
                this.Delete_Button.Visible = false;
                this.Revive_Button.Visible = false;
                this.uButton_CmpltGoodsMakerGuide.Visible = true; // ADD 2010.04.26 xiaoxd
                this.uButton_ModelGuide.Visible = true;
                this.uButton_ModelGuide.Enabled = true;

                // ���͐ݒ�
                this.MakerCode_tNedit.Enabled = true;
                this.ModelCode_tNedit.Enabled = true;
                this.ModelSubCodea_tNedit.Enabled = true;
                this.ModelFullName_tEdit.Enabled = true;
                this.ModelHalfName_tEdit.Enabled = true;
                this.ModelAliasName_tEdit.Enabled = true;
            }
            // �X�V
            else if (screenMode.Equals(UPDATE_MODE))
            {
                // �{�^���ݒ�
                this.Ok_Button.Visible = true;
                this.Delete_Button.Visible = false;
                this.Revive_Button.Visible = false;
                this.uButton_CmpltGoodsMakerGuide.Visible = true; // ADD 2010.04.26 xiaoxd
                this.uButton_ModelGuide.Visible = true;
                this.uButton_ModelGuide.Enabled = false;

                // ���͐ݒ�
                this.MakerCode_tNedit.Enabled = false;
                this.ModelCode_tNedit.Enabled = false;
                this.ModelSubCodea_tNedit.Enabled = false;
                this.ModelFullName_tEdit.Enabled = true;
                this.ModelHalfName_tEdit.Enabled = true;
                this.ModelAliasName_tEdit.Enabled = true;
            }
            // �폜
            else if (screenMode.Equals(DELETE_MODE))
            {
                // �{�^���ݒ�
                this.Ok_Button.Visible = false;
                this.Delete_Button.Visible = true;
                this.Revive_Button.Visible = true;
                this.uButton_CmpltGoodsMakerGuide.Visible = true; // ADD 2010.04.26 xiaoxd
                this.uButton_ModelGuide.Visible = true;
                this.uButton_ModelGuide.Enabled = false;

                // ���͐ݒ�
                this.MakerCode_tNedit.Enabled = false;
                this.ModelCode_tNedit.Enabled = false;
                this.ModelSubCodea_tNedit.Enabled = false;
                this.ModelFullName_tEdit.Enabled = false;
                this.ModelHalfName_tEdit.Enabled = false;
                this.ModelAliasName_tEdit.Enabled = false;
            }
            // �Q��
            else if (screenMode.Equals(REFERENCE_MODE))
            {
                // �{�^���ݒ�
                this.Ok_Button.Visible = false;
                this.Delete_Button.Visible = false;
                this.Revive_Button.Visible = false;
                this.uButton_CmpltGoodsMakerGuide.Visible = true; // ADD 2010.04.26 xiaoxd
                this.uButton_ModelGuide.Visible = true;
                this.uButton_ModelGuide.Enabled = false;

                // ���͐ݒ�
                this.MakerCode_tNedit.Enabled = false;
                this.ModelCode_tNedit.Enabled = false;
                this.ModelSubCodea_tNedit.Enabled = false;
                this.ModelFullName_tEdit.Enabled = false;
                this.ModelHalfName_tEdit.Enabled = false;
                this.ModelAliasName_tEdit.Enabled = false;
            }            
        }

        /// <summary>
        /// ��ʏ���������
        /// </summary>
        /// <remarks>
        /// <br>Note       : ��ʂ̏��������s���܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.12</br>
        /// </remarks>
        private void ScreenClear()
        {
            this.MakerCode_tNedit.Clear();              // ���[�J�[�R�[�h
            this.MakerCodeNm_tEdit.Text = "";           // ���[�J�[����
            this.ModelCode_tNedit.Clear();              // �Ԏ�R�[�h
            this.ModelSubCodea_tNedit.Clear();           // �ď̃R�[�h
            this.ModelFullName_tEdit.Text = "";         // �Ԏ햼
            this.ModelHalfName_tEdit.Text = "";         // �Ԏ햼(��)
            this.ModelAliasName_tEdit.Text = "";        // �ď�
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
        /// <br>Date       : 2008.06.13</br>
        /// </remarks>
        private bool ScreenDataCheck(ref Control control, ref string message, string loginID)
        {
            // ���[�J�[�R�[�h
            if (this.MakerCode_tNedit.Text == "0" || this.MakerCode_tNedit.Text.Trim() == "")
            {
                control = this.MakerCode_tNedit;
                message = this.MakerCode_Label.Text + "����͂��ĉ������B";
                return false;
            }

            // �Ԏ�R�[�h
            if (this.ModelCode_tNedit.Text == "0" || this.ModelCode_tNedit.Text.Trim() == "")
            {
                control = this.ModelCode_tNedit;
                message = this.ModelCode_Label.Text + "����͂��ĉ������B";
                return false;
            }

            // �ď̃R�[�h�i"0"�͓o�^OK�j
            if (this.ModelSubCodea_tNedit.Text.Trim() == "")
            {
                control = this.ModelSubCodea_tNedit;
                message = this.ModelSubCode_Label.Text + "����͂��ĉ������B";
                return false;
            }

            // �֘A�`�F�b�N
            if ((this.MakerCode_tNedit.GetInt() < 900)
                && (this.ModelCode_tNedit.GetInt() < 900)
                && (this.ModelSubCodea_tNedit.GetInt() < 900))
            {
                control = this.ModelCode_tNedit;
                message = this.ModelCode_Label.Text + "/"
                    + this.ModelSubCode_Label.Text + "�̉��ꂩ��900�ȏ�œo�^���ĉ�����";
                return false;
            }

            // �Ԏ햼
            if (this.ModelFullName_tEdit.Text.Trim() == "")
            {
                control = this.ModelFullName_tEdit;
                message = this.ModelFullName_Label.Text + "����͂��ĉ������B";
                return false;
            }

            // �Ԏ햼(��)
            if (this.ModelHalfName_tEdit.Text.Trim() == "")
            {
                control = this.ModelHalfName_tEdit;
                message = this.ModelHalfName_Label.Text + "����͂��ĉ������B";
                return false;
            }

            // �ď�
            if (this.ModelAliasName_tEdit.Text.Trim() == "")
            {
                control = this.ModelAliasName_tEdit;
                message = this.ModelAliasName_Label.Text + "����͂��ĉ������B";
                return false;
            }

            return true;
        }

        /// <summary>
        /// �Ԏ햼�̃}�X�^ ���o�^����
        /// </summary>
        /// <returns>�o�^���ʁitrue:OK�^false:NG�j</returns>
        /// <remarks>
        /// <br>Note       : �Ԏ햼�̃}�X�^ ���o�^���s���܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.13</br>
        /// </remarks>
        private bool SaveProc()
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            Control control = null;
            string message = null;
            string loginID = "";
            
            ModelNameU modelNameU = null;

            if (this._detailsDataIndex >= 0)
            {
                // �X�V�Ώۂ̏����擾
                string guid = (string)this.Bind_DataSet.Tables[S_MODELNAMEU_TABLE].Rows[this._detailsDataIndex][S_MODELNAMEU_GUID];
                modelNameU = ((ModelNameU)this._modelNameUTable[guid]).Clone();
            }

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
            // ��ʏ��������N���X�ɐݒ�
            this.DispToModelNameU(ref modelNameU);

            // �o�^�^�X�V����
            status = this._modelNameUAcs.Write(ref modelNameU);
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

                        this.MakerCode_tNedit.Focus();
                        return false;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        ExclusiveTransaction(status, TMsgDisp.OPE_UPDATE, this._modelNameUAcs);

                        if (UnDisplaying != null)
                        {
                            MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                            UnDisplaying(this, me);
                        }

                        this.DialogResult = DialogResult.Cancel;
                        this._detailsIndexBuffer = -2;

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
                            this._modelNameUAcs,				// �G���[�����������I�u�W�F�N�g
                            MessageBoxButtons.OK,				// �\������{�^��
                            MessageBoxDefaultButton.Button1);	// �����\���{�^��

                        if (UnDisplaying != null)
                        {
                            MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                            UnDisplaying(this, me);
                        }

                        this.DialogResult = DialogResult.Cancel;
                        this._detailsIndexBuffer = -2;

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

            if (!this.flag)
            {
                // DataSet�W�J����
                ModelNameUToDataSet(modelNameU, this._detailsDataIndex);
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
        /// <br>Date       : 2008.06.13</br>
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
        /// �Ԏ햼�K�C�h�N������
        /// </summary>
        /// <param name="modelNameU">�Ԏ햼�̃}�X�^�I�u�W�F�N�g</param>
        /// <returns>����(0:OK, 1:Cancel)</returns>
        /// <remarks>
        /// <br>Note       : �Ԏ햼�K�C�h�̋N�����s���܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.13</br>
        /// </remarks>
        private int ShowModelNameGuide(out ModelNameU modelNameU)
        {
            // ��ʂ��烁�[�J�[�R�[�h���擾
            int makerCode = this.MakerCode_tNedit.GetInt();
            modelNameU = new ModelNameU();
            
            if (makerCode != 0)
            {
                return this._modelNameUAcs.ExecuteGuid(makerCode, LoginInfoAcquisition.EnterpriseCode, out modelNameU);
            }
            else
            {
                return -1;
            }
            
        }

        /// <summary>
        /// HashTable�p�L�[�쐬
        /// </summary>
        /// <param name="makerUMnt">MakerUMnt�N���X</param>
        /// <returns>Hash�e�[�u���p�L�[</returns>
        /// <remarks>
        /// <br>Note       : MakerUMnt�N���X����n�b�V���e�[�u���p�̃L�[���쐬���܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.13</br>
        /// </remarks>
        private string CreateHashKey(MakerUMnt makerUMnt)
        {
            return makerUMnt.GoodsMakerCd.ToString("d6");
        }

        /// <summary>
        /// HashTable�p�L�[�쐬
        /// </summary>
        /// <param name="modelNameU">ModelNameU�N���X</param>
        /// <returns>Hash�e�[�u���p�L�[</returns>
        /// <remarks>
        /// <br>Note       : ModelNameU�N���X����n�b�V���e�[�u���p�̃L�[���쐬���܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.13</br>
        /// </remarks>
        private string CreateHashKey(ModelNameU modelNameU)
        {
            string strHashKey = modelNameU.ModelCode.ToString("d3") + modelNameU.ModelSubCode.ToString("d3");
            return strHashKey;
        }

        /// <summary>
        /// ���[�J�[���擾����
        /// </summary>
        /// <param name="makerCode">���[�J�[�R�[�h</param>
        /// <returns>���[�J�[��</returns>
        /// <remarks>
        /// <br>Note       : ���[�J�[�����擾���܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008/06/16</br>
        /// </remarks>
        private string GetMakerName(int makerCode)
        {
            string makerName = "";

            int status;
            ArrayList makerUMntRetArray;
            MakerAcs makerAcs = new MakerAcs();
            
            try
            {
                status = makerAcs.SearchAll(out makerUMntRetArray, this._enterpriseCode);
                if (status == 0)
                {
                    if (makerUMntRetArray.Count <= 0)
                    {
                        return makerName;
                    }

                    foreach (MakerUMnt makerUMnt in makerUMntRetArray)
                    {
                        if (makerUMnt.GoodsMakerCd == makerCode)
                        {
                            makerName = makerUMnt.MakerName.Trim();
                            return makerName;
                        }
                    }
                }
            }
            catch
            {
                makerName = "";
            }

            return makerName;
        }

        /// <summary>
        /// �Ԏ햼�擾����
        /// </summary>
        /// <param name="modelCode">�Ԏ�R�[�h</param>
        /// <returns>�Ԏ햼</returns>
        /// <remarks>
        /// <br>Note       : �Ԏ햼���擾���܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008/06/16</br>
        /// </remarks>
        private string GetModelName(int modelCode)
        {
            string modelName = "";

            int status;
            ArrayList modelNameURetArray;
            ModelNameUAcs modelNameUAcs = new ModelNameUAcs();
            int makerCode = this.MakerCode_tNedit.GetInt();
            
            try
            {
                status = modelNameUAcs.SearchAll(makerCode, out modelNameURetArray, this._enterpriseCode);
                if (status == 0)
                {
                    if (modelNameURetArray.Count <= 0)
                    {
                        return modelName;
                    }

                    foreach (ModelNameU modelNameU in modelNameURetArray)
                    {
                        if (modelNameU.ModelCode == modelCode)
                        {
                            modelName = modelNameU.ModelFullName.Trim();
                            return modelName;
                        }
                    }
                }
            }
            catch
            {
                modelName = "";
            }

            return modelName;
        }

        #endregion

        // 2009.03.30 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� >>>>>>START
        /// <summary>
        /// ���[�h�ύX����
        /// </summary>
        private bool ModeChangeProc()
        {
            // ���[�J�[�R�[�h
            int makerCd = MakerCode_tNedit.GetInt();
            // �Ԏ�R�[�h
            int modelCode = ModelCode_tNedit.GetInt();
            // �ď̃R�[�h
            int modelSubCode = ModelSubCodea_tNedit.GetInt();

            for (int i = 0; i < this.Bind_DataSet.Tables[S_MODELNAMEU_TABLE].Rows.Count; i++)
            {
                // �f�[�^�Z�b�g�Ɣ�r
                int dsMakerCd = int.Parse((string)this.Bind_DataSet.Tables[S_MODELNAMEU_TABLE].Rows[i][S_MAKERCODE]);
                int dsModelCode = int.Parse((string)this.Bind_DataSet.Tables[S_MODELNAMEU_TABLE].Rows[i][S_MODELCODE]);
                int dsModelSubCode = int.Parse((string)this.Bind_DataSet.Tables[S_MODELNAMEU_TABLE].Rows[i][S_MODELSUBCODE]);
                if ((makerCd == dsMakerCd) &&
                    (modelCode == dsModelCode) &&
                    (modelSubCode == dsModelSubCode))
                {
                    // ���̓R�[�h���f�[�^�Z�b�g�ɑ��݂���ꍇ
                    if ((string)this.Bind_DataSet.Tables[S_MODELNAMEU_TABLE].Rows[i][S_DELETEDATE] != "")
                    {
                        // �_���폜
                        TMsgDisp.Show(this, 					// �e�E�B���h�E�t�H�[��
                          emErrorLevel.ERR_LEVEL_INFO,          // �G���[���x��
                          PG_ID,						        // �A�Z���u���h�c�܂��̓N���X�h�c
                          "���͂��ꂽ�R�[�h�̎Ԏ�}�X�^���͊��ɍ폜����Ă��܂��B", 			// �\�����郁�b�Z�[�W
                          0, 									// �X�e�[�^�X�l
                          MessageBoxButtons.OK);				// �\������{�^��
                        // �Ԏ�A�ď̂̃N���A
                        ModelCode_tNedit.Clear();
                        ModelSubCodea_tNedit.Clear();
                        return true;
                    }

                    DialogResult res = TMsgDisp.Show(
                        this,                                   // �e�E�B���h�E�t�H�[��
                        emErrorLevel.ERR_LEVEL_INFO,            // �G���[���x��
                        PG_ID,                                  // �A�Z���u���h�c�܂��̓N���X�h�c
                        "���͂��ꂽ�R�[�h�̎Ԏ�}�X�^��񂪊��ɓo�^����Ă��܂��B\n�ҏW���s���܂����H",   // �\�����郁�b�Z�[�W
                        0,                                      // �X�e�[�^�X�l
                        MessageBoxButtons.YesNo);               // �\������{�^��
                    switch (res)
                    {
                        case DialogResult.Yes:
                            {
                                // ��ʍĕ`��
                                this._detailsDataIndex = i;
                                ScreenClear();
                                ScreenReconstruction();
                                break;
                            }
                        case DialogResult.No:
                            {
                                // �Ԏ�A�ď̂̃N���A
                                ModelCode_tNedit.Clear();
                                ModelSubCodea_tNedit.Clear();
                                break;
                            }
                    }
                    return true;
                }
            }
            return false;
        }

        // ADD 2010.04.26 xiaoxd >>>>>>>>>>>>>
        /// <summary>
        /// MakerCode_tNedit_AfterExitEditMode�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MakerCode_tNedit_AfterExitEditMode(object sender, EventArgs e)
        {


            if (!string.IsNullOrEmpty(this.MakerCode_tNedit.Text))
            {
                MakerAcs makerAcs = new MakerAcs();
                MakerUMnt makerUMnt;
                int makerCode = this.MakerCode_tNedit.GetInt();
                //���[�J�[�f�[�^�̎擾
                int status = makerAcs.Read(out makerUMnt, this._enterpriseCode, makerCode);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    //���[�J�[
                    this.MakerCode_tNedit.SetInt(makerUMnt.GoodsMakerCd);
                    this.MakerCodeNm_tEdit.Text = makerUMnt.MakerName;
                }
                else
                {
                    this.MakerCode_tNedit.Clear();
                    this.MakerCodeNm_tEdit.Clear();
                    this.MakerCode_tNedit.Focus();
                }
            }
            else
            {
                this.MakerCodeNm_tEdit.Clear();
            }
        }

        /// <summary>
        /// ���[�J�[�K�C�h�{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        private void uButton_CmpltGoodsMakerGuide_Click(object sender, EventArgs e)
        {
            MakerAcs makerAcs = new MakerAcs();
            MakerUMnt makerUMnt;

            //���[�J�[�f�[�^�̎擾
            int status = makerAcs.ExecuteGuid(this._enterpriseCode, out makerUMnt);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                //���[�J�[
                this.MakerCode_tNedit.SetInt(makerUMnt.GoodsMakerCd);
                this.MakerCodeNm_tEdit.Text = makerUMnt.MakerName;
                // ���̍��ڂփt�H�[�J�X�ړ�
                this.ModelCode_tNedit.Focus();
            }
        }
        // ADD 2010.04.26 xiaoxd <<<<<<<<<<<<

        // 2009.03.30 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� <<<<<<END
    }
}

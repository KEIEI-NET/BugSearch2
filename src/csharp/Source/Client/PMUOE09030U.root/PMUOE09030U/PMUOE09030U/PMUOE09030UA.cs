//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : UOE�K�C�h���̃}�X�^
// �v���O�����T�v   : UOE�K�C�h���̃}�X�^�̓o�^�E�ύX�E�폜���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2007 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ����
// �� �� ��  2008/06/30  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �s�V �m��
// �C �� ��  2008/10/30  �C�����e : �o�O�C��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �{�� �⎟�Y
// �C �� ��  2008/12/11  �C�����e : BO.�[�i,���_�敪�I�����A�K�C�h�R�[�h���󔒂œo�^�ł���悤�C���B
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  12719       �쐬�S�� : �H���@�b�D
// �C �� ��  2009/03/25  �C�����e : �u�폜�σf�[�^�̕\���v�͍ŏ�ʍ��ڂŐ���
//----------------------------------------------------------------------------//
#define DELETE_DATE_DEPEND_ON_SUB_TABLE // ���C���e�[�u���̍폜�����T�u�e�[�u���Ɋ֘A������t���O
using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

using System.Windows.Forms;

using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Globarization;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Controller.Util;
using Broadleaf.Application.Common;
using Broadleaf.Windows.Forms;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// UOE�K�C�h���̃}�X�^ �t�H�[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note		: UOE�K�C�h���̃}�X�^���̐ݒ���s���܂��B
    ///					  IMasterMaintenanceThreeArrayType���������Ă��܂��B</br>
    /// <br>Programmer	: 30413 ����</br>
    /// <br>Date		: 2008.06.30</br>
    /// <br></br>
    /// <br>UpdateNote  : 2008/10/30 30462 �s�V �m���@�o�O�C��</br>
    /// <br>UpdateNote  : 2008/12/11 30365 �{�� �⎟�Y�@BO.�[�i,���_�敪�I�����A�K�C�h�R�[�h���󔒂œo�^�ł���悤�C���B</br>
    /// <br>UpdateNote  : 2009/03/25 30434 �H�� �b�D�@�u�폜�σf�[�^�̕\���v�͍ŏ�ʍ��ڂŐ���</br>
    /// </remarks>
    public class PMUOE09030UA : System.Windows.Forms.Form, IMasterMaintenanceThreeArrayType
    {
        # region ��Private Members (Component)

        private Infragistics.Win.Misc.UltraLabel Mode_Label;
        private Infragistics.Win.Misc.UltraLabel UOESupplierCd_Label;
        private TNedit UOESupplierCd_tNedit;
        private Infragistics.Win.Misc.UltraLabel UOESupplierNm_Label;
        private TEdit UOESupplierNm_tEdit;
        private Infragistics.Win.Misc.UltraLabel ultraLabel8;
        private Infragistics.Win.Misc.UltraLabel UOEGuideDivCd_Label;
        private Infragistics.Win.Misc.UltraLabel ultraLabel4;
        private Infragistics.Win.Misc.UltraLabel UOEGuideCode_Label;
        private Infragistics.Win.Misc.UltraLabel UOEGuideName_Label;
        private TEdit UOEGuideCode_tEdit;
        private TEdit UOEGuideName_tEdit;
        private TRetKeyControl tRetKeyControl1;
        private IContainer components;
        private Infragistics.Win.Misc.UltraButton Cancel_Button;
        private Infragistics.Win.Misc.UltraButton Revive_Button;
        private Infragistics.Win.Misc.UltraButton Delete_Button;
        private Infragistics.Win.Misc.UltraButton Ok_Button;
        private TArrowKeyControl tArrowKeyControl1;
        private DataSet Bind_DataSet;
        private Timer Initial_Timer;
        private TEdit UOEGuideDivNm_tEdit;
        private TNedit UOEGuideDivCd_tNedit;
        private Infragistics.Win.Misc.UltraLabel UOEGuideDivNm_Label;
        private UiSetControl uiSetControl1;
        private Infragistics.Win.UltraWinStatusBar.UltraStatusBar ultraStatusBar1;

        #endregion

        #region ��Windows �t�H�[�� �f�U�C�i�Ő������ꂽ�R�[�h
        /// <summary>
        /// �f�U�C�i �T�|�[�g�ɕK�v�ȃ��\�b�h�ł��B���̃��\�b�h�̓��e��
        /// �R�[�h �G�f�B�^�ŕύX���Ȃ��ł��������B
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance110 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PMUOE09030UA));
            this.ultraStatusBar1 = new Infragistics.Win.UltraWinStatusBar.UltraStatusBar();
            this.Mode_Label = new Infragistics.Win.Misc.UltraLabel();
            this.UOESupplierCd_Label = new Infragistics.Win.Misc.UltraLabel();
            this.UOESupplierCd_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.UOESupplierNm_Label = new Infragistics.Win.Misc.UltraLabel();
            this.UOESupplierNm_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.ultraLabel8 = new Infragistics.Win.Misc.UltraLabel();
            this.UOEGuideDivCd_Label = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel4 = new Infragistics.Win.Misc.UltraLabel();
            this.UOEGuideCode_Label = new Infragistics.Win.Misc.UltraLabel();
            this.UOEGuideName_Label = new Infragistics.Win.Misc.UltraLabel();
            this.UOEGuideCode_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.UOEGuideName_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.tRetKeyControl1 = new Broadleaf.Library.Windows.Forms.TRetKeyControl(this.components);
            this.tArrowKeyControl1 = new Broadleaf.Library.Windows.Forms.TArrowKeyControl(this.components);
            this.Bind_DataSet = new System.Data.DataSet();
            this.Initial_Timer = new System.Windows.Forms.Timer(this.components);
            this.Cancel_Button = new Infragistics.Win.Misc.UltraButton();
            this.Revive_Button = new Infragistics.Win.Misc.UltraButton();
            this.Delete_Button = new Infragistics.Win.Misc.UltraButton();
            this.Ok_Button = new Infragistics.Win.Misc.UltraButton();
            this.UOEGuideDivCd_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.UOEGuideDivNm_Label = new Infragistics.Win.Misc.UltraLabel();
            this.UOEGuideDivNm_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.uiSetControl1 = new Broadleaf.Library.Windows.Forms.UiSetControl(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.UOESupplierCd_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UOESupplierNm_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UOEGuideCode_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UOEGuideName_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bind_DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UOEGuideDivCd_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UOEGuideDivNm_tEdit)).BeginInit();
            this.SuspendLayout();
            // 
            // ultraStatusBar1
            // 
            this.ultraStatusBar1.Location = new System.Drawing.Point(0, 293);
            this.ultraStatusBar1.Name = "ultraStatusBar1";
            this.ultraStatusBar1.Size = new System.Drawing.Size(653, 23);
            this.ultraStatusBar1.SizeGripVisible = Infragistics.Win.DefaultableBoolean.False;
            this.ultraStatusBar1.TabIndex = 27;
            this.ultraStatusBar1.ViewStyle = Infragistics.Win.UltraWinStatusBar.ViewStyle.Office2003;
            // 
            // Mode_Label
            // 
            appearance1.ForeColor = System.Drawing.Color.White;
            appearance1.TextHAlignAsString = "Center";
            appearance1.TextVAlignAsString = "Middle";
            this.Mode_Label.Appearance = appearance1;
            this.Mode_Label.BackColorInternal = System.Drawing.Color.Navy;
            this.Mode_Label.Location = new System.Drawing.Point(541, 12);
            this.Mode_Label.Name = "Mode_Label";
            this.Mode_Label.Size = new System.Drawing.Size(100, 23);
            this.Mode_Label.TabIndex = 28;
            this.Mode_Label.Text = "�X�V���[�h";
            // 
            // UOESupplierCd_Label
            // 
            appearance3.TextVAlignAsString = "Middle";
            this.UOESupplierCd_Label.Appearance = appearance3;
            this.UOESupplierCd_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.UOESupplierCd_Label.Location = new System.Drawing.Point(12, 41);
            this.UOESupplierCd_Label.Name = "UOESupplierCd_Label";
            this.UOESupplierCd_Label.Size = new System.Drawing.Size(123, 23);
            this.UOESupplierCd_Label.TabIndex = 29;
            this.UOESupplierCd_Label.Text = "������R�[�h";
            // 
            // UOESupplierCd_tNedit
            // 
            appearance10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance10.TextHAlignAsString = "Right";
            this.UOESupplierCd_tNedit.ActiveAppearance = appearance10;
            appearance11.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance11.ForeColorDisabled = System.Drawing.Color.Black;
            appearance11.TextHAlignAsString = "Right";
            this.UOESupplierCd_tNedit.Appearance = appearance11;
            this.UOESupplierCd_tNedit.AutoSelect = true;
            this.UOESupplierCd_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.UOESupplierCd_tNedit.DataText = "";
            this.UOESupplierCd_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.UOESupplierCd_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 6, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, true, false, true, false, true));
            this.UOESupplierCd_tNedit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.UOESupplierCd_tNedit.Location = new System.Drawing.Point(141, 41);
            this.UOESupplierCd_tNedit.MaxLength = 6;
            this.UOESupplierCd_tNedit.Name = "UOESupplierCd_tNedit";
            this.UOESupplierCd_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.UOESupplierCd_tNedit.Size = new System.Drawing.Size(59, 24);
            this.UOESupplierCd_tNedit.TabIndex = 1;
            // 
            // UOESupplierNm_Label
            // 
            appearance4.TextVAlignAsString = "Middle";
            this.UOESupplierNm_Label.Appearance = appearance4;
            this.UOESupplierNm_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.UOESupplierNm_Label.Location = new System.Drawing.Point(12, 70);
            this.UOESupplierNm_Label.Name = "UOESupplierNm_Label";
            this.UOESupplierNm_Label.Size = new System.Drawing.Size(123, 23);
            this.UOESupplierNm_Label.TabIndex = 29;
            this.UOESupplierNm_Label.Text = "�����於��";
            // 
            // UOESupplierNm_tEdit
            // 
            this.UOESupplierNm_tEdit.ActiveAppearance = appearance12;
            appearance13.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance13.ForeColorDisabled = System.Drawing.Color.Black;
            this.UOESupplierNm_tEdit.Appearance = appearance13;
            this.UOESupplierNm_tEdit.AutoSelect = true;
            this.UOESupplierNm_tEdit.DataText = "";
            this.UOESupplierNm_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.UOESupplierNm_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 30, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, true, true, true, true));
            this.UOESupplierNm_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.UOESupplierNm_tEdit.Location = new System.Drawing.Point(141, 70);
            this.UOESupplierNm_tEdit.MaxLength = 30;
            this.UOESupplierNm_tEdit.Name = "UOESupplierNm_tEdit";
            this.UOESupplierNm_tEdit.Size = new System.Drawing.Size(484, 24);
            this.UOESupplierNm_tEdit.TabIndex = 2;
            // 
            // ultraLabel8
            // 
            this.ultraLabel8.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel8.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Inset;
            this.ultraLabel8.Location = new System.Drawing.Point(12, 100);
            this.ultraLabel8.Name = "ultraLabel8";
            this.ultraLabel8.Size = new System.Drawing.Size(630, 4);
            this.ultraLabel8.TabIndex = 34;
            // 
            // UOEGuideDivCd_Label
            // 
            appearance14.TextVAlignAsString = "Middle";
            this.UOEGuideDivCd_Label.Appearance = appearance14;
            this.UOEGuideDivCd_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.UOEGuideDivCd_Label.Location = new System.Drawing.Point(12, 110);
            this.UOEGuideDivCd_Label.Name = "UOEGuideDivCd_Label";
            this.UOEGuideDivCd_Label.Size = new System.Drawing.Size(123, 23);
            this.UOEGuideDivCd_Label.TabIndex = 29;
            this.UOEGuideDivCd_Label.Text = "�K�C�h�敪";
            // 
            // ultraLabel4
            // 
            this.ultraLabel4.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel4.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Inset;
            this.ultraLabel4.Location = new System.Drawing.Point(12, 168);
            this.ultraLabel4.Name = "ultraLabel4";
            this.ultraLabel4.Size = new System.Drawing.Size(630, 4);
            this.ultraLabel4.TabIndex = 34;
            // 
            // UOEGuideCode_Label
            // 
            appearance16.TextVAlignAsString = "Middle";
            this.UOEGuideCode_Label.Appearance = appearance16;
            this.UOEGuideCode_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.UOEGuideCode_Label.Location = new System.Drawing.Point(12, 178);
            this.UOEGuideCode_Label.Name = "UOEGuideCode_Label";
            this.UOEGuideCode_Label.Size = new System.Drawing.Size(123, 23);
            this.UOEGuideCode_Label.TabIndex = 29;
            this.UOEGuideCode_Label.Text = "�K�C�h�R�[�h";
            // 
            // UOEGuideName_Label
            // 
            appearance8.TextVAlignAsString = "Middle";
            this.UOEGuideName_Label.Appearance = appearance8;
            this.UOEGuideName_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.UOEGuideName_Label.Location = new System.Drawing.Point(12, 207);
            this.UOEGuideName_Label.Name = "UOEGuideName_Label";
            this.UOEGuideName_Label.Size = new System.Drawing.Size(123, 23);
            this.UOEGuideName_Label.TabIndex = 29;
            this.UOEGuideName_Label.Text = "�K�C�h����";
            // 
            // UOEGuideCode_tEdit
            // 
            appearance17.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.UOEGuideCode_tEdit.ActiveAppearance = appearance17;
            appearance18.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance18.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance18.ForeColorDisabled = System.Drawing.Color.Black;
            this.UOEGuideCode_tEdit.Appearance = appearance18;
            this.UOEGuideCode_tEdit.AutoSelect = true;
            this.UOEGuideCode_tEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.UOEGuideCode_tEdit.DataText = "";
            this.UOEGuideCode_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.UOEGuideCode_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 4, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, true, false, true, true, true));
            this.UOEGuideCode_tEdit.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.UOEGuideCode_tEdit.Location = new System.Drawing.Point(141, 178);
            this.UOEGuideCode_tEdit.MaxLength = 4;
            this.UOEGuideCode_tEdit.Name = "UOEGuideCode_tEdit";
            this.UOEGuideCode_tEdit.ShowOverflowIndicator = true;
            this.UOEGuideCode_tEdit.Size = new System.Drawing.Size(51, 24);
            this.UOEGuideCode_tEdit.TabIndex = 4;
            // 
            // UOEGuideName_tEdit
            // 
            appearance110.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.UOEGuideName_tEdit.ActiveAppearance = appearance110;
            appearance15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance15.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance15.ForeColorDisabled = System.Drawing.Color.Black;
            this.UOEGuideName_tEdit.Appearance = appearance15;
            this.UOEGuideName_tEdit.AutoSelect = true;
            this.UOEGuideName_tEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.UOEGuideName_tEdit.DataText = "";
            this.UOEGuideName_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.UOEGuideName_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 20, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, true, true, true, true));
            this.UOEGuideName_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.UOEGuideName_tEdit.Location = new System.Drawing.Point(141, 207);
            this.UOEGuideName_tEdit.MaxLength = 20;
            this.UOEGuideName_tEdit.Name = "UOEGuideName_tEdit";
            this.UOEGuideName_tEdit.Size = new System.Drawing.Size(330, 24);
            this.UOEGuideName_tEdit.TabIndex = 5;
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
            // Cancel_Button
            // 
            this.Cancel_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Cancel_Button.Location = new System.Drawing.Point(516, 253);
            this.Cancel_Button.Name = "Cancel_Button";
            this.Cancel_Button.Size = new System.Drawing.Size(125, 34);
            this.Cancel_Button.TabIndex = 41;
            this.Cancel_Button.Text = "����(&X)";
            this.Cancel_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Cancel_Button.Click += new System.EventHandler(this.Cancel_Button_Click);
            // 
            // Revive_Button
            // 
            this.Revive_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Revive_Button.Location = new System.Drawing.Point(385, 253);
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
            this.Delete_Button.Location = new System.Drawing.Point(257, 253);
            this.Delete_Button.Name = "Delete_Button";
            this.Delete_Button.Size = new System.Drawing.Size(125, 34);
            this.Delete_Button.TabIndex = 6;
            this.Delete_Button.Text = "���S�폜(&D)";
            this.Delete_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Delete_Button.Click += new System.EventHandler(this.Delete_Button_Click);
            // 
            // Ok_Button
            // 
            this.Ok_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Ok_Button.Location = new System.Drawing.Point(385, 253);
            this.Ok_Button.Name = "Ok_Button";
            this.Ok_Button.Size = new System.Drawing.Size(125, 34);
            this.Ok_Button.TabIndex = 8;
            this.Ok_Button.Text = "�ۑ�(&S)";
            this.Ok_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Ok_Button.Click += new System.EventHandler(this.Ok_Button_Click);
            // 
            // UOEGuideDivCd_tNedit
            // 
            appearance5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance5.TextHAlignAsString = "Right";
            this.UOEGuideDivCd_tNedit.ActiveAppearance = appearance5;
            appearance6.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance6.ForeColorDisabled = System.Drawing.Color.Black;
            appearance6.TextHAlignAsString = "Right";
            this.UOEGuideDivCd_tNedit.Appearance = appearance6;
            this.UOEGuideDivCd_tNedit.AutoSelect = true;
            this.UOEGuideDivCd_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.UOEGuideDivCd_tNedit.DataText = "";
            this.UOEGuideDivCd_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.UOEGuideDivCd_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 6, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.UOEGuideDivCd_tNedit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.UOEGuideDivCd_tNedit.Location = new System.Drawing.Point(141, 110);
            this.UOEGuideDivCd_tNedit.MaxLength = 6;
            this.UOEGuideDivCd_tNedit.Name = "UOEGuideDivCd_tNedit";
            this.UOEGuideDivCd_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, false, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.UOEGuideDivCd_tNedit.Size = new System.Drawing.Size(28, 24);
            this.UOEGuideDivCd_tNedit.TabIndex = 1;
            // 
            // UOEGuideDivNm_Label
            // 
            appearance9.TextVAlignAsString = "Middle";
            this.UOEGuideDivNm_Label.Appearance = appearance9;
            this.UOEGuideDivNm_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.UOEGuideDivNm_Label.Location = new System.Drawing.Point(12, 139);
            this.UOEGuideDivNm_Label.Name = "UOEGuideDivNm_Label";
            this.UOEGuideDivNm_Label.Size = new System.Drawing.Size(123, 23);
            this.UOEGuideDivNm_Label.TabIndex = 29;
            this.UOEGuideDivNm_Label.Text = "�K�C�h�敪����";
            // 
            // UOEGuideDivNm_tEdit
            // 
            this.UOEGuideDivNm_tEdit.ActiveAppearance = appearance2;
            appearance7.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance7.ForeColorDisabled = System.Drawing.Color.Black;
            this.UOEGuideDivNm_tEdit.Appearance = appearance7;
            this.UOEGuideDivNm_tEdit.AutoSelect = true;
            this.UOEGuideDivNm_tEdit.DataText = "";
            this.UOEGuideDivNm_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.UOEGuideDivNm_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 30, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, true, true, true, true));
            this.UOEGuideDivNm_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.UOEGuideDivNm_tEdit.Location = new System.Drawing.Point(141, 139);
            this.UOEGuideDivNm_tEdit.MaxLength = 30;
            this.UOEGuideDivNm_tEdit.Name = "UOEGuideDivNm_tEdit";
            this.UOEGuideDivNm_tEdit.Size = new System.Drawing.Size(97, 24);
            this.UOEGuideDivNm_tEdit.TabIndex = 2;
            // 
            // uiSetControl1
            // 
            this.uiSetControl1.EditWidthSettingWay = Broadleaf.Library.Windows.Forms.UiSetControl.EditWidthSettingWayState.None;
            this.uiSetControl1.OwnerForm = this;
            // 
            // PMUOE09030UA
            // 
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(653, 316);
            this.Controls.Add(this.Cancel_Button);
            this.Controls.Add(this.Revive_Button);
            this.Controls.Add(this.Delete_Button);
            this.Controls.Add(this.Ok_Button);
            this.Controls.Add(this.ultraLabel4);
            this.Controls.Add(this.ultraLabel8);
            this.Controls.Add(this.UOEGuideName_tEdit);
            this.Controls.Add(this.UOEGuideCode_tEdit);
            this.Controls.Add(this.UOEGuideDivNm_tEdit);
            this.Controls.Add(this.UOESupplierNm_tEdit);
            this.Controls.Add(this.UOEGuideDivCd_tNedit);
            this.Controls.Add(this.UOESupplierCd_tNedit);
            this.Controls.Add(this.UOESupplierNm_Label);
            this.Controls.Add(this.UOEGuideName_Label);
            this.Controls.Add(this.UOEGuideCode_Label);
            this.Controls.Add(this.UOEGuideDivNm_Label);
            this.Controls.Add(this.UOEGuideDivCd_Label);
            this.Controls.Add(this.UOESupplierCd_Label);
            this.Controls.Add(this.Mode_Label);
            this.Controls.Add(this.ultraStatusBar1);
            this.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PMUOE09030UA";
            this.Text = "UOE�e�햼�̃}�X�^";
            this.Load += new System.EventHandler(this.PMUOE09030UA_Load);
            this.VisibleChanged += new System.EventHandler(this.PMUOE09030UA_VisibleChanged);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PMUOE09030UA_Closing);
            ((System.ComponentModel.ISupportInitialize)(this.UOESupplierCd_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UOESupplierNm_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UOEGuideCode_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UOEGuideName_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bind_DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UOEGuideDivCd_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UOEGuideDivNm_tEdit)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        #region << Private Members >>

        private UOESupplierAcs _uoeSupplierAcs;                         // UOE������}�X�^�e�[�u���A�N�Z�X�N���X
        private UOEGuideNameAcs _uoeGuideNameAcs;                         // UOE�K�C�h���̃}�X�^�e�[�u���A�N�Z�X�N���X


        private int _totalCount;
        private string _enterpriseCode;
        private string _sectionCode;
        private Hashtable _thirdGridTable;

        // ��r�p�N���[��
        private UOEGuideName _uoeGuideNameClone;

        // �v���p�e�B�p
        private bool _canPrint;
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

        // 2009.03.31 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� >>>>>>START
        // ���[�h�t���O(true�F�R�[�h�Afalse�F�R�[�h�ȊO)
        private bool _modeFlg = false;
        // 2009.03.31 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� <<<<<<END

        #endregion

        # region ��Consts

        // Frame��View�pGrid���KEY��� (�w�b�_�̃^�C�g�����ƂȂ�܂�)
        private const string MAIN_TABLE = "PrintingItem";
        private const string SECOND_TABLE = "CountItem";
        private const string THIRD_TABLE = "CountCondition";

        // �O���b�h�^�C�g��
        private const string SECTION_GRID_TITLE = "������";
        private const string UNITPRICEKIND_GRID_TITLE = "�K�C�h�敪";
        private const string RATEPRIORITYORDER_GRID_TITLE = "�K�C�h";

        // Fream��View�pGrid���KEY��� (�w�b�_�̃^�C�g�����ƂȂ�܂�)
        private const string M_UOESUPPLIERCD = "������R�[�h";
        private const string M_UOESUPPLIERNM = "�����於��";
        
        private const string S_UOEGUIDEDIVCD = "�K�C�h�敪";
        private const string S_UOEGUIDEDIVNM = "�K�C�h�敪����";
        
        private const string T_DELETEDATE = "�폜��";
        private const string T_UOEGUIDECODE = "�K�C�h�R�[�h";
        private const string T_UOEGUIDENAME = "�K�C�h����";
        private const string T_UOEGUIDECODE_GUID = "UOEGUIDECODE_GUID";
        
        // �ҏW���[�h
        private const string INSERT_MODE = "�V�K���[�h";
        private const string UPDATE_MODE = "�X�V���[�h";
        private const string DELETE_MODE = "�폜���[�h";

        // Message�֘A��`
        private const string PG_ID = "PMUOE09030U";
        private const string PG_NM = "UOE�K�C�h���̃}�X�^";
        private const string ERR_READ_MSG = "�ǂݍ��݂Ɏ��s���܂����B";
        private const string ERR_DPR_MSG = "���̃R�[�h�͊��Ɏg�p����Ă��܂��B";
        private const string ERR_RDEL_MSG = "�폜�Ɏ��s���܂����B";
        private const string ERR_UPDT_MSG = "�o�^�Ɏ��s���܂����B";
        private const string ERR_RVV_MSG = "�����Ɏ��s���܂����B";
        private const string ERR_800_MSG = "���ɑ��[�����X�V����Ă��܂�";
        private const string ERR_801_MSG = "���ɑ��[�����폜����Ă��܂�";
        private const string SDC_RDEL_MSG = "�}�X�^����폜����Ă��܂�";

        #endregion

        # region ��Constructor

        /// <summary>
		/// UOE�K�C�h���̃}�X�^���̓t�H�[���N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
        /// <br>Note       : UOE�K�C�h���̃}�X�^���̓t�H�[���N���X�̐V�����C���X�^���X�����������܂��B</br>
		/// <br>Programmer : 30413 ����</br>
		/// <br>Date       : 2008.06.30</br>
		/// </remarks>
        public PMUOE09030UA()
		{
			InitializeComponent();

            // �f�[�^�Z�b�g����\�z����
            DataSetColumnConstruction();

			// �v���p�e�B�����l�ݒ�
			this._canPrint = false;
			this._canClose = true;
			this._canNew = true;
            this._canDelete = true;
            
			this._mainGridTitle = SECTION_GRID_TITLE;
			this._secondGridTitle = UNITPRICEKIND_GRID_TITLE;
			this._thirdGridTitle = RATEPRIORITYORDER_GRID_TITLE;
			this._defaultGridDisplayLayout = MGridDisplayLayout.Horizontal;

			// ��ƃR�[�h
			this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            this._sectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;

            this._uoeSupplierAcs = new UOESupplierAcs();
            this._uoeGuideNameAcs = new UOEGuideNameAcs();

            this._totalCount = 0;
            this._thirdGridTable = new Hashtable();

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
		}

        #endregion

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
        /// <summary>�A�v���P�[�V�����̃��C�� �G���g�� �|�C���g�ł��B</summary>
        [STAThread]
        static void Main()
        {
            System.Windows.Forms.Application.Run(new PMUOE09030UA());
        }
        # endregion

        # region ��Events
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

        /// <summary>
        /// �_���폜�f�[�^���o�\�ݒ胊�X�g�擾����
        /// </summary>
        /// <returns>�_���폜�f�[�^���o�\�ݒ胊�X�g</returns>
        /// <remarks>
        /// <br>Note       : �_���폜�f�[�^�̒��o���\���ǂ����̐ݒ��z��Ŏ擾���܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.30</br>
        /// </remarks>
        public bool[] GetCanLogicalDeleteDataExtractionList()
        {
            bool[] logicalDelete = { true, false, false };  // ADD 2008/03/25 �s��Ή�[12719]�F�u�폜�σf�[�^�̕\���v�͍ŏ�ʍ��ڂŐ��� { false, false, true }��{ true, false, false }
            return logicalDelete;
        }

        /// <summary>
        /// �O���b�h�^�C�g�����X�g�擾����
        /// </summary>
        /// <returns>�O���b�h�^�C�g�����X�g</returns>
        /// <remarks>
        /// <br>Note       : �O���b�h�̃^�C�g����z��Ŏ擾���܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.30</br>
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
        /// <br>Date       : 2008.06.30</br>
        /// </remarks>
        public System.Drawing.Image[] GetGridIconList()
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
        /// <br>Date       : 2008.06.30</br>
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
        /// <br>Date       : 2008.06.30</br>
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
        /// <br>Date       : 2008.06.30</br>
        /// </remarks>
        public bool[] GetNewButtonEnabledList()
        {
            bool[] newButtonEnabled = { false, false, true };
            if (this.Bind_DataSet.Tables[MAIN_TABLE].Rows.Count == 0)
            {
                // ��������0���̏ꍇ�́A�V�K�쐬�s��
                newButtonEnabled[2] = false;
            }
            return newButtonEnabled;
        }

        /// <summary>
        /// �C���{�^���̗L���ݒ胊�X�g�擾����
        /// </summary>
        /// <returns>�C���{�^���̗L���ݒ胊�X�g</returns>
        /// <remarks>
        /// <br>Note       : �C���{�^���̗L���ݒ胊�X�g���擾���܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.30</br>
        /// </remarks>
        public bool[] GetModifyButtonEnabledList()
        {
            bool[] modifyButtonEnabled = { false, false, true };
            if (this.Bind_DataSet.Tables[MAIN_TABLE].Rows.Count == 0)
            {
                // ��������0���̏ꍇ�́A�V�K�쐬�s��
                modifyButtonEnabled[2] = false;
            }
            return modifyButtonEnabled;
        }

        /// <summary>
        /// �폜�{�^���̗L���ݒ胊�X�g�擾����
        /// </summary>
        /// <returns>�폜�{�^���̗L���ݒ胊�X�g</returns>
        /// <remarks>
        /// <br>Note       : �폜�{�^���̗L���ݒ胊�X�g���擾���܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.30</br>
        /// </remarks>
        public bool[] GetDeleteButtonEnabledList()
        {
            bool[] deleteButtonEnabled = { false, false, true };
            if (this.Bind_DataSet.Tables[MAIN_TABLE].Rows.Count == 0)
            {
                // ��������0���̏ꍇ�́A�V�K�쐬�s��
                deleteButtonEnabled[2] = false;
            }
            return deleteButtonEnabled;
        }

        # endregion

        # region ��Public Methods

        /// <summary>
        /// �o�C���h�f�[�^�Z�b�g�擾����
        /// </summary>
        /// <param name="bindDataSet">�O���b�h���b�h�p�f�[�^�Z�b�g</param>
        /// <param name="tableName">�e�[�u������</param>
        /// <remarks>
        /// <br>Note       : �O���b�h�Ƀo�C���h������f�[�^�Z�b�g���擾���܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.30</br>
        /// </remarks>
        public void GetBindDataSet(ref System.Data.DataSet bindDataSet, ref string[] tableName)
        {
            bindDataSet = this.Bind_DataSet;
            tableName[0] = MAIN_TABLE;
            tableName[1] = SECOND_TABLE;
            tableName[2] = THIRD_TABLE;
        }

        /// <summary>
        /// �f�[�^��������(�P�A���C��)
        /// </summary>
        /// <param name="totalCount">�S�Y������</param>
        /// <param name="readCount">���o�Ώی���</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �擪����L�����A�̑S�f�[�^���������A���o���ʂ�W�J����DataSet�ƑS�Y��������Ԃ��܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.30</br>
        /// </remarks>
        public int Search(ref int totalCount, int readCount)
        {
            int status = 0;
            ArrayList retList = null;

            // ADD 2009/03/25 �s��Ή�[12719]�F�u�폜�σf�[�^�̕\���v�͍ŏ�ʍ��ڂŐ��� ---------->>>>>
            // ���o�Ώی��������̏ꍇ�A�����I�ɏI��
            if (readCount < 0)
            {
                // DataSet�̏����N���A
                this.Bind_DataSet.Tables[MAIN_TABLE].Rows.Clear();
                this.Bind_DataSet.Tables[SECOND_TABLE].Rows.Clear();
                this.Bind_DataSet.Tables[THIRD_TABLE].Rows.Clear();
                return 0;
            }
            // ADD 2009/03/25 �s��Ή�[12719]�F�u�폜�σf�[�^�̕\���v�͍ŏ�ʍ��ڂŐ��� ----------<<<<<

            if (readCount == 0)
            {
                // ���o�Ώی�����0�̏ꍇ�͑S�����o�����s����
                status = this._uoeSupplierAcs.SearchAll(out retList, this._enterpriseCode, this._sectionCode);

                this._totalCount = retList.Count;
            }

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                    {

                        // DataSet�̏����N���A
                        this.Bind_DataSet.Tables[MAIN_TABLE].Rows.Clear();
                        this.Bind_DataSet.Tables[SECOND_TABLE].Rows.Clear();
                        this.Bind_DataSet.Tables[THIRD_TABLE].Rows.Clear();

                        // �擾����UOE������N���X���f�[�^�Z�b�g�֓W�J����
                        int index = 0;

                        foreach (UOESupplier wkUOESupplier in retList)
                        {
                            // UOE������N���X�f�[�^�Z�b�g�W�J����
                            UOESupplierToDataSet(wkUOESupplier.Clone(), index);
                            index++;
                        }
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    {
                        // �T�[�`���� UOE������}�X�^�ǂݍ���0��
                        TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                        this.Name,
                                        "�����悪���݂��܂���B",
                                        -1,
                                        MessageBoxButtons.OK);
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                         break;
                    }


                default:
                    // �T�[�`���� UOE������}�X�^�ǂݍ��ݎ��s
                    TMsgDisp.Show(
                        this, 									    // �e�E�B���h�E�t�H�[��
                        emErrorLevel.ERR_LEVEL_STOP, 			    // �G���[���x��
                        PG_ID,      							    // �A�Z���u���h�c�܂��̓N���X�h�c
                        PG_NM,	        					        // �v���O��������
                        "Search", 								    // ��������
                        TMsgDisp.OPE_GET, 						    // �I�y���[�V����
                        "UOE��������̓ǂݍ��݂Ɏ��s���܂����B", 	// �\�����郁�b�Z�[�W
                        status, 								    // �X�e�[�^�X�l
                        this._uoeSupplierAcs,	 				    // �G���[�����������I�u�W�F�N�g
                        MessageBoxButtons.OK, 					    // �\������{�^��
                        MessageBoxDefaultButton.Button1);		    // �����\���{�^��

                    break;
            }

            // �߂�l�Z�b�g
            totalCount = this._totalCount;

            // �폜����ݒ�
            SetDelateDateOfFirstTable(null);

            return status;
        }

        /// <summary>
        /// �l�N�X�g�f�[�^��������(�P�A���C��)
        /// </summary>
        /// <param name="readCount">���o�Ώی���</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ArrayType�ł͖�����</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.30</br>
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
        /// <br>Date       : 2008.06.30</br>
        /// </remarks>
        public int SecondDataSearch(ref int totalCount, int readCount)
        {
            int status = 0;

            // DataSet�̏����N���A
            this.Bind_DataSet.Tables[SECOND_TABLE].Rows.Clear();

            // ADD 2009/03/25 �s��Ή�[12719]�F�u�폜�σf�[�^�̕\���v�͍ŏ�ʍ��ڂŐ��� ---------->>>>>
            // ���o�Ώی��������̏ꍇ�A�����I�ɏI��
            if (readCount < 0)
            {
                this.Bind_DataSet.Tables[THIRD_TABLE].Rows.Clear();
                return 0;
            }

            // ���݂�UOE������R�[�h���擾
            int uoeSupplierCode = int.Parse(this.Bind_DataSet.Tables[MAIN_TABLE].Rows[this._mainDataIndex][M_UOESUPPLIERCD].ToString());
            // ADD 2009/03/25 �s��Ή�[12719]�F�u�폜�σf�[�^�̕\���v�͍ŏ�ʍ��ڂŐ��� ----------<<<<<

            // �K�C�h�敪��DB�������s�킸�ɌŒ�\���Ƃ���
            for (int i = 0; i < 4; i++)
            {
                // �K�C�h�敪�f�[�^�Z�b�g�W�J����
                UOEGuideDivToSecondDataSet(i, uoeSupplierCode); // ADD 2009/03/25 �s��Ή�[12719]�F�u�폜�σf�[�^�̕\���v�͍ŏ�ʍ��ڂŐ���cuoeSupplierCode��ǉ�
            }

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
        /// <br>Date       : 2008.06.30</br>
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
        /// <br>Date       : 2008.07.01</br>
        /// </remarks>
        public int ThirdDataSearch(ref int totalCount, int readCount)
        {
            int status = 0;
            ArrayList retList = null;

            if ((this.Bind_DataSet == null) || (this._mainDataIndex < 0))
            {
                // ���C��Grid�Ńf�[�^��������Ό������s��Ȃ�
                return status;
            }

            // DataSet�̏����N���A
            this.Bind_DataSet.Tables[THIRD_TABLE].Rows.Clear();

            // ADD 2009/03/25 �s��Ή�[12719]�F�u�폜�σf�[�^�̕\���v�͍ŏ�ʍ��ڂŐ��� ---------->>>>>
            // ���o�Ώی��������̏ꍇ�A�����I�ɏI��
            if (readCount < 0) return 0;
            // ADD 2009/03/25 �s��Ή�[12719]�F�u�폜�σf�[�^�̕\���v�͍ŏ�ʍ��ڂŐ��� ----------<<<<<

            // 2009.01.22 30413 ���� ������R�[�h�̃[���l�ߑΉ� >>>>>>START
            // Form ���C��Grid�̏����擾
            //int uoeSupplierCd = (int)this.Bind_DataSet.Tables[MAIN_TABLE].Rows[this._mainDataIndex][M_UOESUPPLIERCD];
            int uoeSupplierCd = int.Parse((string)this.Bind_DataSet.Tables[MAIN_TABLE].Rows[this._mainDataIndex][M_UOESUPPLIERCD]);
            // 2009.01.22 30413 ���� ������R�[�h�̃[���l�ߑΉ� <<<<<<END
            // Form Second Grid�̏����擾
            int uoeGuideDivCd = (int)this.Bind_DataSet.Tables[SECOND_TABLE].Rows[this._secondDataIndex][S_UOEGUIDEDIVCD];

            // UOE�K�C�h���̃}�X�^�̌���������ݒ�
            UOEGuideName uoeGuideName = new UOEGuideName();
            uoeGuideName.EnterpriseCode = this._enterpriseCode;
            uoeGuideName.SectionCode = this._sectionCode;
            uoeGuideName.UOESupplierCd = uoeSupplierCd;
            uoeGuideName.UOEGuideDivCd = uoeGuideDivCd;

            if (readCount == 0)
            {
                // ���o�Ώی�����0�̏ꍇ�͑S�����o�����s����
                status = this._uoeGuideNameAcs.SearchAll(out retList, uoeGuideName);

                this._totalCount = retList.Count;
            }

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                    {
                        // �擾����UOE�K�C�h���̃N���X���f�[�^�Z�b�g�֓W�J����
                        int index = 0;
                        SortedList wkSort = new SortedList();

                        foreach (UOEGuideName wkUOEGuideName in retList)
                        {
                            if (wkUOEGuideName.UOEGuideDivCd == uoeGuideDivCd)
                            {
                                // �K�C�h�敪����v����f�[�^�𒊏o(�敪:0�̏ꍇ�͑S���擾�̈�)
                                string key = wkUOEGuideName.UOEGuideCode;
                                // �擾����UOE�K�C�h���̃N���X���\�[�g
                                wkSort.Add(key, wkUOEGuideName);
                            }
                        }

                        for (int i = 0; i < wkSort.Count; i++)
                        {
                            // UOE�K�C�h���̃N���X�f�[�^�Z�b�g�W�J����
                            UOEGuideNameToThirdDataSet((UOEGuideName)wkSort.GetByIndex(i), ref index);
                        }

                        break;
                    }
                default:
                    {
                        // Third Grid�f�[�^��������
                        TMsgDisp.Show(
                            this, 								        // �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_STOP, 		        // �G���[���x��
                            PG_ID, 						                // �A�Z���u���h�c�܂��̓N���X�h�c
                            PG_NM,        					            // �v���O��������
                            "ThirdDataSearch", 				            // ��������
                            TMsgDisp.OPE_GET, 					        // �I�y���[�V����
                            "UOE�K�C�h���̏��̓ǂݍ��݂Ɏ��s���܂����B",	// �\�����郁�b�Z�[�W
                            status, 							        // �X�e�[�^�X�l
                            this._uoeGuideNameAcs, 				        // �G���[�����������I�u�W�F�N�g
                            MessageBoxButtons.OK, 				        // �\������{�^��
                            MessageBoxDefaultButton.Button1);	        // �����\���{�^��

                        break;
                    }
            }

            totalCount = this._totalCount;
            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            // First/Second�e�[�u���̍폜����ݒ�
            ArrayList allUOEGuideDivCdList = new ArrayList();
            if (readCount == 0)
            {
                // ���݂̔�����R�[�h��ΏۂƂ��A�S�K�C�h�敪������
                uoeGuideName.UOEGuideDivCd = 0;
                status = this._uoeGuideNameAcs.SearchAll(out allUOEGuideDivCdList, uoeGuideName);

                // HACK:�S�������ʂ��L���b�V��
                CacheModelNameUList(uoeGuideName, allUOEGuideDivCdList);    // ADD 2009/03/25 �s��Ή�[12719]�F�u�폜�σf�[�^�̕\���v�͍ŏ�ʍ��ڂŐ���
            }

            // HACK:Second�e�[�u���̍폜����ݒ�
            SetDelateDateOfSecondTable(uoeGuideName);   // ADD 2008/03/25 �s��Ή�[12719]�F�u�폜�σf�[�^�̕\���v�͍ŏ�ʍ��ڂŐ���

            // HACK:First�e�[�u���̍폜����ݒ�
            SetDelateDateOfFirstTable(uoeGuideName);    // ADD 2008/03/25 �s��Ή�[12719]�F�u�폜�σf�[�^�̕\���v�͍ŏ�ʍ��ڂŐ���

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
        /// <br>Date       : 2008.07.01</br>
        /// </remarks>
        public int Delete()
        {
            int status = 0;

            // Form ���C��Grid�̏����擾
            string uoeGuideCdGuid = (string)this.Bind_DataSet.Tables[THIRD_TABLE].Rows[this._thirdDataIndex][T_UOEGUIDECODE_GUID];
            UOEGuideName uoeGuideName = ((UOEGuideName)this._thirdGridTable[uoeGuideCdGuid]).Clone();

            status = this._uoeGuideNameAcs.LogicalDelete(ref uoeGuideName);
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
                        ExclusiveTransaction(status, TMsgDisp.OPE_DELETE, this._uoeGuideNameAcs);
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
                            PG_NM,  							// �v���O��������
                            "Delete",							// ��������
                            TMsgDisp.OPE_HIDE,					// �I�y���[�V����
                            ERR_RDEL_MSG,						// �\�����郁�b�Z�[�W 
                            status,								// �X�e�[�^�X�l
                            this._uoeGuideNameAcs,				// �G���[�����������I�u�W�F�N�g
                            MessageBoxButtons.OK,				// �\������{�^��
                            MessageBoxDefaultButton.Button1);	// �����\���{�^��

                        return status;
                    }
            }

            // �f�[�^�Z�b�g�W�J����
            int index = this._thirdDataIndex;
            UOEGuideNameToThirdDataSet(uoeGuideName, ref index);

            // ADD 2009/03/25 �s��Ή�[12719]�F�u�폜�σf�[�^�̕\���v�͍ŏ�ʍ��ڂŐ��� ---------->>>>>
            // �Č����i�e�e�[�u���̒l���Đݒ�j
            int totalCount = 0;
            ThirdDataSearch(ref totalCount, 0);
            // ADD 2009/03/25 �s��Ή�[12719]�F�u�폜�σf�[�^�̕\���v�͍ŏ�ʍ��ڂŐ��� ----------<<<<<

            return status;
        }

        /// <summary>
        /// �������
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ������������s���܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.30</br>
        /// </remarks>
        public int Print()
        {
            // ����p�A�Z���u�������[�h����i�������j
            return 0;
        }

        /// <summary>
        /// �O���b�h��O�Ϗ��擾����
        /// </summary>
        /// <returns>�O���b�h��O�Ϗ��i�[Hashtable</returns>
        /// <remarks>
        /// <br>Note       : �e��̊O����ݒ肷��N���X���i�[����Hashtable���擾���܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.30</br>
        /// </remarks>
        public void GetAppearanceTable(out Hashtable[] _hashtable)
        {
            //==============================
            // ���C��
            //==============================
            Hashtable main = new Hashtable();

            main.Add(T_DELETEDATE, new GridColAppearance(MGridColDispType.DeletionDataListOnly, ContentAlignment.MiddleLeft, "", Color.Red));   // ADD 2008/03/25 �s��Ή�[12719]�F�u�폜�σf�[�^�̕\���v�͍ŏ�ʍ��ڂŐ���
            main.Add(M_UOESUPPLIERCD, new GridColAppearance(MGridColDispType.ListOnly, ContentAlignment.MiddleRight, "", Color.Black));
            main.Add(M_UOESUPPLIERNM, new GridColAppearance(MGridColDispType.ListOnly, ContentAlignment.MiddleLeft, "", Color.Black));
            
            //==============================
            // �Z�J���h
            //==============================
            Hashtable second = new Hashtable();

            // ������R�[�h
            second.Add(M_UOESUPPLIERCD, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));   // ADD 2008/03/25 �s��Ή�[12719]�F�u�폜�σf�[�^�̕\���v�͍ŏ�ʍ��ڂŐ���

            second.Add(T_DELETEDATE, new GridColAppearance(MGridColDispType.DeletionDataListOnly, ContentAlignment.MiddleLeft, "", Color.Red)); // ADD 2008/03/25 �s��Ή�[12719]�F�u�폜�σf�[�^�̕\���v�͍ŏ�ʍ��ڂŐ���
            second.Add(S_UOEGUIDEDIVCD, new GridColAppearance(MGridColDispType.ListOnly, ContentAlignment.MiddleRight, "", Color.Black));
            second.Add(S_UOEGUIDEDIVNM, new GridColAppearance(MGridColDispType.ListOnly, ContentAlignment.MiddleLeft, "", Color.Black));
            
            //==============================
            // �T�[�h
            //==============================
            Hashtable third = new Hashtable();

            // ������R�[�h
            third.Add(M_UOESUPPLIERCD, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));    // ADD 2008/03/25 �s��Ή�[12719]�F�u�폜�σf�[�^�̕\���v�͍ŏ�ʍ��ڂŐ���
            // �K�C�h�敪
            third.Add(S_UOEGUIDEDIVCD, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));    // ADD 2008/03/25 �s��Ή�[12719]�F�u�폜�σf�[�^�̕\���v�͍ŏ�ʍ��ڂŐ���

            third.Add(T_DELETEDATE, new GridColAppearance(MGridColDispType.DeletionDataListOnly, ContentAlignment.MiddleLeft, "", Color.Red));
            third.Add(T_UOEGUIDECODE, new GridColAppearance(MGridColDispType.ListOnly, ContentAlignment.MiddleLeft, "", Color.Black));
            third.Add(T_UOEGUIDENAME, new GridColAppearance(MGridColDispType.ListOnly, ContentAlignment.MiddleLeft, "", Color.Black));
            third.Add(T_UOEGUIDECODE_GUID, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));

            _hashtable = new Hashtable[3];
            _hashtable[0] = main;
            _hashtable[1] = second;
            _hashtable[2] = third;
        }

        /// <summary>
        /// �f�[�^�Z�b�g����\�z����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �f�[�^�Z�b�g�̗�����\�z���܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.30</br>
        /// </remarks>
        private void DataSetColumnConstruction()
        {
            //==========================
            // ���C���e�[�u����`
            //==========================
            DataTable mainTable = new DataTable(MAIN_TABLE);

            // �폜��
            mainTable.Columns.Add(T_DELETEDATE, typeof(string));    // ADD 2008/03/25 �s��Ή�[12719]�F�u�폜�σf�[�^�̕\���v�͍ŏ�ʍ��ڂŐ���

            // 2009.01.22 30413 ���� ������R�[�h�̃[���l�ߑΉ� >>>>>>START
            // ������R�[�h
            //mainTable.Columns.Add(M_UOESUPPLIERCD, typeof(int));
            mainTable.Columns.Add(M_UOESUPPLIERCD, typeof(string));
            // 2009.01.22 30413 ���� ������R�[�h�̃[���l�ߑΉ� <<<<<<END
            // �����於��
            mainTable.Columns.Add(M_UOESUPPLIERNM, typeof(string));
            
            this.Bind_DataSet.Tables.Add(mainTable);

            //==========================
            // �Z�J���h�e�[�u����`
            //==========================
            DataTable secondTable = new DataTable(SECOND_TABLE);

            // �폜��
            secondTable.Columns.Add(T_DELETEDATE, typeof(string));  // ADD 2008/03/25 �s��Ή�[12719]�F�u�폜�σf�[�^�̕\���v�͍ŏ�ʍ��ڂŐ���

            // ������R�[�h
            secondTable.Columns.Add(M_UOESUPPLIERCD, typeof(int));  // ADD 2008/03/25 �s��Ή�[12719]�F�u�폜�σf�[�^�̕\���v�͍ŏ�ʍ��ڂŐ���

            // �K�C�h�敪
            secondTable.Columns.Add(S_UOEGUIDEDIVCD, typeof(int));
            // �K�C�h�敪����
            secondTable.Columns.Add(S_UOEGUIDEDIVNM, typeof(string));
            
            this.Bind_DataSet.Tables.Add(secondTable);

            //==========================
            // �T�[�h�e�[�u����`
            //==========================
            DataTable thirdTable = new DataTable(THIRD_TABLE);

            // ������R�[�h
            thirdTable.Columns.Add(M_UOESUPPLIERCD, typeof(int));   // ADD 2008/03/25 �s��Ή�[12719]�F�u�폜�σf�[�^�̕\���v�͍ŏ�ʍ��ڂŐ���
            // �K�C�h�敪
            thirdTable.Columns.Add(S_UOEGUIDEDIVCD, typeof(int));   // ADD 2008/03/25 �s��Ή�[12719]�F�u�폜�σf�[�^�̕\���v�͍ŏ�ʍ��ڂŐ���

            // �폜��
            thirdTable.Columns.Add(T_DELETEDATE, typeof(string));
            // �K�C�h�R�[�h
            thirdTable.Columns.Add(T_UOEGUIDECODE, typeof(string));
            // �K�C�h����
            thirdTable.Columns.Add(T_UOEGUIDENAME, typeof(string));
            // �K�C�hGUID
            thirdTable.Columns.Add(T_UOEGUIDECODE_GUID, typeof(string));

            this.Bind_DataSet.Tables.Add(thirdTable);
        }

        # endregion

        # region ��Private Methods

        /// <summary>
        /// UOE������N���X�f�[�^�Z�b�g�W�J����
        /// </summary>
        /// <param name="uoeSupplier">UOE������N���X</param>
        /// <param name="index">�f�[�^�Z�b�g�֓W�J����C���f�b�N�X</param>
        /// <remarks>
        /// <br>Note       : UOE������N���X���f�[�^�Z�b�g�֊i�[���܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.07.01</br>
        /// </remarks>
        private void UOESupplierToDataSet(UOESupplier uoeSupplier, int index)
        {
            if (uoeSupplier.LogicalDeleteCode == 0)
            {
                // ���C��Grid�Ɋi�[����f�[�^��ݒ�
                if ((index < 0) || (this.Bind_DataSet.Tables[MAIN_TABLE].Rows.Count <= index))
                {
                    // �V�K�Ɣ��f���āA�s��ǉ�����
                    DataRow dataRow = this.Bind_DataSet.Tables[MAIN_TABLE].NewRow();
                    this.Bind_DataSet.Tables[MAIN_TABLE].Rows.Add(dataRow);

                    // index���s�̍ŏI�s�ԍ��ɂ���
                    index = this.Bind_DataSet.Tables[MAIN_TABLE].Rows.Count - 1;
                }

                // �폜��
                this.Bind_DataSet.Tables[MAIN_TABLE].Rows[index][T_DELETEDATE] = GetDeleteDate(uoeSupplier);    // ADD 2008/03/25 �s��Ή�[12719]�F�u�폜�σf�[�^�̕\���v�͍ŏ�ʍ��ڂŐ���

                // 2009.01.22 30413 ���� ������R�[�h�̃[���l�ߑΉ� >>>>>>START
                // ������R�[�h
                //this.Bind_DataSet.Tables[MAIN_TABLE].Rows[index][M_UOESUPPLIERCD] = uoeSupplier.UOESupplierCd;
                this.Bind_DataSet.Tables[MAIN_TABLE].Rows[index][M_UOESUPPLIERCD] = uoeSupplier.UOESupplierCd.ToString("d06");
                // 2009.01.22 30413 ���� ������R�[�h�̃[���l�ߑΉ� <<<<<<END
            
                // �����於��
                this.Bind_DataSet.Tables[MAIN_TABLE].Rows[index][M_UOESUPPLIERNM] = uoeSupplier.UOESupplierName;
            }
        }

        /// <summary>
        /// UOE�K�C�h���̃N���XSecond Grid�f�[�^�Z�b�g�W�J����
        /// </summary>
        /// <param name="index">�f�[�^�Z�b�g�֓W�J����C���f�b�N�X</param>
        /// <param name="uoeSupplierCode">UOE������R�[�h</param>
        /// <remarks>
        /// <br>Note       : UOE�K�C�h���̃N���X��Second Grid�f�[�^�Z�b�g�֊i�[���܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.07.01</br>
        /// </remarks>
        private void UOEGuideDivToSecondDataSet(int index, int uoeSupplierCode) // ADD 2008/03/25 �s��Ή�[12719]�F�u�폜�σf�[�^�̕\���v�͍ŏ�ʍ��ڂŐ���cuoeSupplierCode��ǉ�
        {
            // Second Grid�Ɋi�[����f�[�^��ݒ�
            if (this.Bind_DataSet.Tables[SECOND_TABLE].Rows.Count <= index)
            {
                // �V�K�Ɣ��f���āA�s��ǉ�����
                DataRow dataRow = this.Bind_DataSet.Tables[SECOND_TABLE].NewRow();
                this.Bind_DataSet.Tables[SECOND_TABLE].Rows.Add(dataRow);

                // index���s�̍ŏI�s�ԍ�����
                index = this.Bind_DataSet.Tables[SECOND_TABLE].Rows.Count - 1;
            }

            // UOE������R�[�h
            this.Bind_DataSet.Tables[SECOND_TABLE].Rows[index][M_UOESUPPLIERCD] = uoeSupplierCode;  // ADD 2008/03/25 �s��Ή�[12719]�F�u�폜�σf�[�^�̕\���v�͍ŏ�ʍ��ڂŐ���

            // UOE�K�C�h�敪
            this.Bind_DataSet.Tables[SECOND_TABLE].Rows[index][S_UOEGUIDEDIVCD] = index;

            // UOE�K�C�h�敪����
            switch (index)
            {
                case 0:
                    {
                        this.Bind_DataSet.Tables[SECOND_TABLE].Rows[index][S_UOEGUIDEDIVNM] = "�Ɩ��敪";
                        break;
                    }
                case 1:
                    {
                        this.Bind_DataSet.Tables[SECOND_TABLE].Rows[index][S_UOEGUIDEDIVNM] = "BO�敪";
                        break;
                    }
                case 2:
                    {
                        this.Bind_DataSet.Tables[SECOND_TABLE].Rows[index][S_UOEGUIDEDIVNM] = "�[�i�敪";
                        break;
                    }
                case 3:
                    {
                        this.Bind_DataSet.Tables[SECOND_TABLE].Rows[index][S_UOEGUIDEDIVNM] = "���_�敪";
                        break;
                    }
                default:
                    {
                        this.Bind_DataSet.Tables[SECOND_TABLE].Rows[index][S_UOEGUIDEDIVNM] = "";
                        break;
                    }
            }
        }

        /// <summary>
        /// UOE�K�C�h���̃N���XThird Grid�f�[�^�Z�b�g�W�J����
        /// </summary>
        /// <param name="uoeGuideName">UOE�K�C�h���̃N���X</param>
        /// <param name="index">�f�[�^�Z�b�g�֓W�J����C���f�b�N�X</param>
        /// <remarks>
        /// <br>Note       : UOE�K�C�h���̃N���X���ڍ�GRID�f�[�^�Z�b�g�֊i�[���܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.07.01</br>
        /// </remarks>
        private void UOEGuideNameToThirdDataSet(UOEGuideName uoeGuideName, ref int index)
        {
            // Third Grid�Ɋi�[����f�[�^��ݒ�
            if ((index < 0) || (this.Bind_DataSet.Tables[THIRD_TABLE].Rows.Count <= index))
            {
                // �V�K�Ɣ��f���āA�s��ǉ�����
                DataRow dataRow = this.Bind_DataSet.Tables[THIRD_TABLE].NewRow();
                this.Bind_DataSet.Tables[THIRD_TABLE].Rows.Add(dataRow);

                // index���s�̍ŏI�s�ԍ�����
                index = this.Bind_DataSet.Tables[THIRD_TABLE].Rows.Count - 1;
            }

            // UOE������R�[�h
            this.Bind_DataSet.Tables[THIRD_TABLE].Rows[index][M_UOESUPPLIERCD] = uoeGuideName.UOESupplierCd;    // ADD 2009/03/25 �s��Ή�[12719]�F�u�폜�σf�[�^�̕\���v�͍ŏ�ʍ��ڂŐ���
            // UOE�K�C�h�敪
            this.Bind_DataSet.Tables[THIRD_TABLE].Rows[index][S_UOEGUIDEDIVCD] = uoeGuideName.UOEGuideDivCd;    // ADD 2009/03/25 �s��Ή�[12719]�F�u�폜�σf�[�^�̕\���v�͍ŏ�ʍ��ڂŐ���

            // �폜��
            if (uoeGuideName.LogicalDeleteCode == 0)
            {
                this.Bind_DataSet.Tables[THIRD_TABLE].Rows[index][T_DELETEDATE] = "";
            }
            else
            {
                // DEL 2009/03/25 �s��Ή�[12719]���F�u�폜�σf�[�^�̕\���v�͍ŏ�ʍ��ڂŐ���
                //this.Bind_DataSet.Tables[THIRD_TABLE].Rows[index][T_DELETEDATE] = TDateTime.DateTimeToString("ggYY/MM/DD", uoeGuideName.UpdateDateTime);
                this.Bind_DataSet.Tables[THIRD_TABLE].Rows[index][T_DELETEDATE] = FormatDeleteDate(uoeGuideName.UpdateDateTime);    // ADD 2008/03/25 �s��Ή�[12719]�F�u�폜�σf�[�^�̕\���v�͍ŏ�ʍ��ڂŐ���
            }

            // UOE�K�C�h�R�[�h
            this.Bind_DataSet.Tables[THIRD_TABLE].Rows[index][T_UOEGUIDECODE] = uoeGuideName.UOEGuideCode;

            // UOE�K�C�h�R�[�h����
            this.Bind_DataSet.Tables[THIRD_TABLE].Rows[index][T_UOEGUIDENAME] = uoeGuideName.UOEGuideNm;
            
            // �K�C�h�R�[�hGUID
            this.Bind_DataSet.Tables[THIRD_TABLE].Rows[index][T_UOEGUIDECODE_GUID] = CreateHashKeyThird(uoeGuideName);

            // �n�b�V�������p��GUID�Z�b�g
            if (this._thirdGridTable.ContainsKey(CreateHashKeyThird(uoeGuideName)) == true)
            {
                this._thirdGridTable.Remove(CreateHashKeyThird(uoeGuideName));
            }
            this._thirdGridTable.Add(CreateHashKeyThird(uoeGuideName), uoeGuideName);

            index++;
        }

        // ADD 2009/03/25 �s��Ή�[12719]�F�u�폜�σf�[�^�̕\���v�͍ŏ�ʍ��ڂŐ��� ---------->>>>>
        /// <summary>
        /// �폜���������t�Ŏ擾���܂��B
        /// </summary>
        /// <param name="updateDateTime">�X�V����</param>
        /// <returns>"ggYY/MM/DD"</returns>
        private static string FormatDeleteDate(DateTime updateDateTime)
        {
            return TDateTime.DateTimeToString("ggYY/MM/DD", updateDateTime);
        }

        /// <summary>
        /// UOE������̍폜�����擾���܂��B
        /// </summary>
        /// <param name="record">UOE������̃��R�[�h</param>
        /// <returns>�����t�̍폜���i���폜����Ă��Ȃ��ꍇ�A<c>string.Empty</c>��Ԃ��܂��B�j</returns>
        private static string GetDeleteDate(UOESupplier record)
        {
            return record.LogicalDeleteCode.Equals(0) ? string.Empty : FormatDeleteDate(record.UpdateDateTime);
        }

        #region <UOE�K�C�h���̂̃L���b�V��/>

        /// <summary>UOE�K�C�h���̂̃L���b�V��</summary>
        /// <remarks>
        /// ��1�L�[�FUOE������R�[�h<br/>
        /// ��2�L�[�FUOE������R�[�h("000000") + UOE�K�C�h�敪�R�[�h("00")
        /// </remarks>
        private readonly IDictionary<int, IDictionary<string, ArrayList>> _modelNameUListCacheMap = new Dictionary<int, IDictionary<string, ArrayList>>();
        /// <summary>
        /// UOE�K�C�h���̂̃L���b�V�����擾���܂��B
        /// </summary>
        private IDictionary<int, IDictionary<string, ArrayList>> ModelNameUListCacheMap
        {
            get { return _modelNameUListCacheMap; }
        }

        /// <summary>
        /// UOE�K�C�h���̂̃L���b�V���̃L�[(��2�e�[�u���p)���擾���܂��B
        /// </summary>
        /// <param name="uoeSupplierCode">UOE������R�[�h</param>
        /// <param name="uoeGuideDivCode">UOE�K�C�h�敪�R�[�h</param>
        /// <returns>UOE������R�[�h("000000") + UOE�K�C�h�敪�R�[�h("00")</returns>
        private static string GetSecondKey(
            int uoeSupplierCode,
            int uoeGuideDivCode
        )
        {
            return uoeSupplierCode.ToString("000000") + uoeGuideDivCode.ToString("00");
        }

        /// <summary>
        /// HACK:UOE�K�C�h���̂��L���b�V�����܂��B
        /// </summary>
        /// <param name="searchingCondition">��������</param>
        /// <param name="uoeGuideNameList">UOE�K�C�h���̂̑S���R�[�h���X�g</param>
        private void CacheModelNameUList(
            UOEGuideName searchingCondition,
            ArrayList allUOEGuideNameList
        )
        {
            if (allUOEGuideNameList == null) return;

            // �Y������UOE������R�[�h�ɑΉ�����L���b�V�����X�V
            if (ModelNameUListCacheMap.ContainsKey(searchingCondition.UOESupplierCd))
            {
                ModelNameUListCacheMap.Remove(searchingCondition.UOESupplierCd);
            }
            ModelNameUListCacheMap.Add(searchingCondition.UOESupplierCd, new Dictionary<string, ArrayList>());

            // UOE������R�[�h��UOE�K�C�h�敪�R�[�h�ŕ���
            foreach (UOEGuideName uoeGuideName in allUOEGuideNameList)
            {
                string secondKey = GetSecondKey(uoeGuideName.UOESupplierCd, uoeGuideName.UOEGuideDivCd);

                if (!ModelNameUListCacheMap[searchingCondition.UOESupplierCd].ContainsKey(secondKey))
                {
                    ModelNameUListCacheMap[searchingCondition.UOESupplierCd].Add(secondKey, new ArrayList());
                }
                ModelNameUListCacheMap[searchingCondition.UOESupplierCd][secondKey].Add(uoeGuideName);
            }
        }

        // UNDONE:UOE�K�C�h���̃L���b�V���̏�����

        #endregion  // <UOE�K�C�h���̂̃L���b�V��/>

        /// <summary>
        /// ��2�e�[�u���̍폜����ݒ肵�܂��B
        /// </summary>
        [Conditional("DELETE_DATE_DEPEND_ON_SUB_TABLE")]
        private void SetDelateDateOfSecondTable(UOEGuideName searchedCondition)
        {
            const string MAIN_TABLE_NAME        = SECOND_TABLE;
            const string RELATION_COLUMN_NAME   = S_UOEGUIDEDIVCD;
            const string SUB_TABLE_NAME         = THIRD_TABLE;
            const string DELETE_DATE_COLUMN_NAME= T_DELETEDATE;

            // ���݂�UOE������R�[�h���擾
            int uoeSupplierCode = int.Parse(this.Bind_DataSet.Tables[MAIN_TABLE].Rows[this._mainDataIndex][M_UOESUPPLIERCD].ToString());

            foreach (DataRow mainRow in this.Bind_DataSet.Tables[MAIN_TABLE_NAME].Rows)
            {
                // �Ή�����T�u�e�[�u���̃��R�[�h�𒊏o
                int relationColumn = (int)mainRow[RELATION_COLUMN_NAME];
                DataRow[] foundSubRows = this.Bind_DataSet.Tables[SUB_TABLE_NAME].Select(
                    RELATION_COLUMN_NAME + "=" + relationColumn.ToString() + " AND " + M_UOESUPPLIERCD + "=" + uoeSupplierCode.ToString()
                );
                Debug.WriteLine("�֘A = " + relationColumn.ToString() + ":" + foundSubRows.Length.ToString() + "��");

                if (foundSubRows.Length.Equals(0))
                {
                    #region �T�u�e�[�u���ɊY�����R�[�h�������ꍇ�ADB�������ʁi�L���b�V���j���ݒ�

                    // UOE������R�[�h�Œ��o
                    IDictionary<string, ArrayList> uoeGuideNameListGroupedUOESupplierCode = null;
                    if (!ModelNameUListCacheMap.ContainsKey(uoeSupplierCode))
                    {
                        ArrayList allUOEGuideDivCdList = new ArrayList();
                        searchedCondition.UOESupplierCd = uoeSupplierCode;
                        int status = this._uoeGuideNameAcs.SearchAll(out allUOEGuideDivCdList, searchedCondition);
                        CacheModelNameUList(searchedCondition, allUOEGuideDivCdList);

                        // �Y������UOE������R�[�h�̃��R�[�h���Ȃ��ꍇ
                        if (allUOEGuideDivCdList == null || allUOEGuideDivCdList.Count.Equals(0)) return;
                    }
                    uoeGuideNameListGroupedUOESupplierCode = ModelNameUListCacheMap[uoeSupplierCode];

                    // ���[�U�[�K�C�h�敪�R�[�h�Œ��o
                    string secondKey = GetSecondKey(uoeSupplierCode, (int)mainRow[RELATION_COLUMN_NAME]);

                    // �Y�����郆�[�U�[�K�C�h�敪�R�[�h���Ȃ��ꍇ
                    if (!uoeGuideNameListGroupedUOESupplierCode.ContainsKey(secondKey)) continue;

                    ArrayList uoeGuideNameList = null;
                    uoeGuideNameList = uoeGuideNameListGroupedUOESupplierCode[secondKey];

                    // �폜�����~���Œ��o
                    int deleteRowCount = 0;
                    SortedList<string, string> sortedDeleteDateList = new SortedList<string, string>(
                        new ReverseComparer<string>()
                    );
                    foreach (UOEGuideName uoeGuideName in uoeGuideNameList)
                    {
                        if (uoeGuideName.LogicalDeleteCode.Equals(0)) continue;

                        deleteRowCount++;
                        if (!sortedDeleteDateList.ContainsKey(uoeGuideName.UpdateDateTimeJpInFormal))
                        {
                            sortedDeleteDateList.Add(
                                uoeGuideName.UpdateDateTimeJpInFormal,
                                uoeGuideName.UpdateDateTimeJpInFormal
                            );
                        }
                    }

                    // ���R�[�h���S���폜����Ă���ꍇ
                    string deleteDate = string.Empty;
                    if (deleteRowCount > 0 && deleteRowCount.Equals(uoeGuideNameList.Count))
                    {
                        deleteDate = sortedDeleteDateList.Values[0];
                    }
                    mainRow[DELETE_DATE_COLUMN_NAME] = deleteDate;

                    #endregion  // �T�u�e�[�u���ɊY�����R�[�h�������ꍇ�ADB�������ʁi�L���b�V���j���ݒ�
                }
                else
                {
                    #region �T�u�e�[�u���ɊY�����R�[�h������ꍇ�A�T�u�e�[�u�����ݒ�

                    // �폜���𒊏o
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

        /// <summary>
        /// ��1�e�[�u���̍폜����ݒ肵�܂��B
        /// </summary>
        [Conditional("DELETE_DATE_DEPEND_ON_SUB_TABLE")]
        private void SetDelateDateOfFirstTable(UOEGuideName searchedCondition)
        {
            const string MAIN_TABLE_NAME        = MAIN_TABLE;
            const string RELATION_COLUMN_NAME   = M_UOESUPPLIERCD;
            const string SUB_TABLE_NAME         = SECOND_TABLE;
            const string DELETE_DATE_COLUMN_NAME= T_DELETEDATE;

            if (searchedCondition == null)
            {
                searchedCondition = new UOEGuideName();
                searchedCondition.EnterpriseCode= this._enterpriseCode;
                searchedCondition.SectionCode   = this._sectionCode;
                searchedCondition.UOEGuideDivCd = 0;
            }

            foreach (DataRow mainRow in this.Bind_DataSet.Tables[MAIN_TABLE_NAME].Rows)
            {
                // �Ή�����T�u�e�[�u���̃��R�[�h�𒊏o
                int relationColumn = int.Parse(mainRow[RELATION_COLUMN_NAME].ToString());
                DataRow[] foundSubRows = this.Bind_DataSet.Tables[SUB_TABLE_NAME].Select(
                    RELATION_COLUMN_NAME + "=" + relationColumn.ToString()
                );
                Debug.WriteLine("�֘A = " + relationColumn.ToString() + ":" + foundSubRows.Length.ToString() + "��");

                if (foundSubRows.Length.Equals(0))
                {
                    #region �T�u�e�[�u���ɊY�����R�[�h�������ꍇ�ADB�������ʁi�L���b�V���j���ݒ�

                    // UOE������R�[�h�Œ��o
                    int uoeSupplierCode = relationColumn;
                    IDictionary<string, ArrayList> uoeGuideNameListGroupedUOESupplierCode = null;
                    if (!ModelNameUListCacheMap.ContainsKey(uoeSupplierCode))
                    {
                        ArrayList allUOEGuideDivCdList = new ArrayList();
                        searchedCondition.UOESupplierCd = uoeSupplierCode;
                        int status = this._uoeGuideNameAcs.SearchAll(out allUOEGuideDivCdList, searchedCondition);
                        CacheModelNameUList(searchedCondition, allUOEGuideDivCdList);

                        // FIXME:�Y������UOE������R�[�h�̃��R�[�h���Ȃ��ꍇ
                        if (allUOEGuideDivCdList == null || allUOEGuideDivCdList.Count.Equals(0))
                        {
                            continue;
                        }
                    }
                    uoeGuideNameListGroupedUOESupplierCode = ModelNameUListCacheMap[uoeSupplierCode];

                    // �폜�����~���Œ��o
                    int deleteRowCount = 0;
                    SortedList<string, string> sortedDeleteDateList = new SortedList<string, string>(
                        new ReverseComparer<string>()
                    );

                    // ���[�U�[�K�C�h�敪�R�[�h�Œ��o
                    int uoeGuideNameCount = 0;
                    foreach (string secondKey in uoeGuideNameListGroupedUOESupplierCode.Keys)
                    {
                        ArrayList uoeGuideNameList = null;
                        uoeGuideNameList = uoeGuideNameListGroupedUOESupplierCode[secondKey];

                        foreach (UOEGuideName uoeGuideName in uoeGuideNameList)
                        {
                            uoeGuideNameCount++;
                            if (uoeGuideName.LogicalDeleteCode.Equals(0)) continue;

                            deleteRowCount++;
                            if (!sortedDeleteDateList.ContainsKey(uoeGuideName.UpdateDateTimeJpInFormal))
                            {
                                sortedDeleteDateList.Add(
                                    uoeGuideName.UpdateDateTimeJpInFormal,
                                    uoeGuideName.UpdateDateTimeJpInFormal
                                );
                            }
                        }
                    }

                    // ���R�[�h���S���폜����Ă���ꍇ
                    string deleteDate = string.Empty;
                    if (deleteRowCount > 0 && deleteRowCount.Equals(uoeGuideNameCount))
                    {
                        deleteDate = sortedDeleteDateList.Values[0];
                    }
                    mainRow[DELETE_DATE_COLUMN_NAME] = deleteDate;

                    #endregion  // �T�u�e�[�u���ɊY�����R�[�h�������ꍇ�ADB�������ʁi�L���b�V���j���ݒ�
                }
                else
                {
                    #region �T�u�e�[�u���ɊY�����R�[�h������ꍇ�A�T�u�e�[�u�����ݒ�

                    // �폜���𒊏o
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
        // ADD 2009/03/25 �s��Ή�[12719]�F�u�폜�σf�[�^�̕\���v�͍ŏ�ʍ��ڂŐ��� ----------<<<<<

        /// <summary>
        /// UOE�K�C�h���̃}�X�^ �N���X��ʓW�J����
        /// </summary>
        /// <param name="uoeGuideName">UOE�K�C�h���̃}�X�^ �I�u�W�F�N�g</param>
        /// <remarks>
        /// <br>Note       : UOE�K�C�h���̃}�X�^ �I�u�W�F�N�g�����ʂɃf�[�^��W�J���܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.07.01</br>
        /// </remarks>
        private void UOEGuideNameToScreen(UOEGuideName uoeGuideName)
        {
            this.UOESupplierCd_tNedit.SetInt(uoeGuideName.UOESupplierCd);                           // ������R�[�h
            this.UOESupplierNm_tEdit.Text = GetUOESupplierName(uoeGuideName.UOESupplierCd);         // �����於��
            this.UOEGuideDivCd_tNedit.SetInt(uoeGuideName.UOEGuideDivCd);                           // �K�C�h�敪
            // UOE�K�C�h�敪����
            switch (uoeGuideName.UOEGuideDivCd)
            {
                case 0:
                    {
                        this.UOEGuideDivNm_tEdit.Text = "�Ɩ��敪";
                        //this.UOEGuideCode_tEdit.ExtEdit.EnableChars.Space = false; // 2008/12/10 G.Miyatsu ADD
                        break;
                    }
                case 1:
                    {
                        this.UOEGuideDivNm_tEdit.Text = "BO�敪";
                        //this.UOEGuideCode_tEdit.ExtEdit.EnableChars.Space = true; // 2008/12/10 G.Miyatsu ADD
                        break;
                    }
                case 2:
                    {
                        this.UOEGuideDivNm_tEdit.Text = "�[�i�敪";
                        //this.UOEGuideCode_tEdit.ExtEdit.EnableChars.Space = true; // 2008/12/10 G.Miyatsu ADD
                        break;
                    }
                case 3:
                    {
                        this.UOEGuideDivNm_tEdit.Text = "���_�敪";
                        //this.UOEGuideCode_tEdit.ExtEdit.EnableChars.Space = true; // 2008/12/10 G.Miyatsu ADD
                        break;
                    }
                default:
                    {
                        this.UOEGuideDivNm_tEdit.Text = "";
                        //this.UOEGuideCode_tEdit.ExtEdit.EnableChars.Space = true; // 2008/12/10 G.Miyatsu ADD
                        break;
                    }
            }
            this.UOEGuideCode_tEdit.Text = uoeGuideName.UOEGuideCode;                               // �K�C�h�R�[�h
            this.UOEGuideName_tEdit.Text = uoeGuideName.UOEGuideNm;                                 // �K�C�h����
        }

        /// <summary>
        /// ��ʏ��UOE�K�C�h���̃}�X�^ �N���X�i�[����
        /// </summary>
        /// <param name="uoeGuideName">UOE�K�C�h���̃}�X�^ �I�u�W�F�N�g</param>
        /// <remarks>
        /// <br>Note       : ��ʏ�񂩂�UOE�K�C�h���̃}�X�^ �I�u�W�F�N�g�Ƀf�[�^���i�[���܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.07.01</br>
        /// </remarks>
        private void DispToUOEGuideName(ref UOEGuideName uoeGuideName)
        {
            if (uoeGuideName == null)
            {
                // �V�K�̏ꍇ
                uoeGuideName = new UOEGuideName();
            }

            uoeGuideName.EnterpriseCode = this._enterpriseCode;                                     // ��ƃR�[�h
            uoeGuideName.SectionCode = this._sectionCode;
            uoeGuideName.UOESupplierCd = this.UOESupplierCd_tNedit.GetInt();                        // ������R�[�h
            uoeGuideName.UOEGuideDivCd = this.UOEGuideDivCd_tNedit.GetInt();                        // �K�C�h�敪
            uoeGuideName.UOEGuideCode = this.UOEGuideCode_tEdit.Text;                               // �K�C�h�R�[�h
            uoeGuideName.UOEGuideNm = this.UOEGuideName_tEdit.Text;                                 // �K�C�h����

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008/12/11 G.Miyatsu ADD
            uoeGuideName.UOEGuideCode = uoeGuideName.UOEGuideCode.Trim();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008/12/11 G.Miyatsu ADD
        }

        /// <summary>
        /// ��ʏ����ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note       : ��ʂ̏����ݒ���s���܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.30</br>
        /// </remarks>
        private void ScreenInitialSetting()
        {
        }

        /// <summary>
        /// ��ʃN���A����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ��ʂ��N���A���܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.30</br>
        /// </remarks>
        private void ScreenClear()
        {
            this.UOESupplierCd_tNedit.Clear();
            this.UOESupplierNm_tEdit.Clear();
            this.UOEGuideDivCd_tNedit.Clear();
            this.UOEGuideDivNm_tEdit.Clear();
            this.UOEGuideCode_tEdit.Clear();
            this.UOEGuideName_tEdit.Clear();
        }

        /// <summary>
        /// ��ʍč\�z����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���[�h�Ɋ�Â��ĉ�ʂ��č\�z���܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.07.01</br>
        /// </remarks>
        private void ScreenReconstruction()
        {
            if (this._thirdDataIndex < 0)
            {
                // �V�K���[�h
                this.Mode_Label.Text = INSERT_MODE;

                // ��ʓ��͋����䏈��
                ScreenPermissionControl(INSERT_MODE);

                // Fream��Index/Table�o�b�t�@�ێ�
                this._mainIndexBuffer = this._mainDataIndex;
                this._secondIndexBuffer = this._secondDataIndex;
                this._thirdIndexBuffer = this._thirdDataIndex;
                this._targetTableBuffer = this._targetTableName;

                // UOE�������ݒ�
                // 2009.01.22 30413 ���� ������R�[�h�̃[���l�ߑΉ� >>>>>>START
                //this.UOESupplierCd_tNedit.SetInt((int)this.Bind_DataSet.Tables[MAIN_TABLE].Rows[this._mainDataIndex][M_UOESUPPLIERCD]);
                this.UOESupplierCd_tNedit.SetInt(int.Parse((string)this.Bind_DataSet.Tables[MAIN_TABLE].Rows[this._mainDataIndex][M_UOESUPPLIERCD]));
                // 2009.01.22 30413 ���� ������R�[�h�̃[���l�ߑΉ� <<<<<<END
                this.UOESupplierNm_tEdit.Text = (string)this.Bind_DataSet.Tables[MAIN_TABLE].Rows[this._mainDataIndex][M_UOESUPPLIERNM];
                // �K�C�h�敪��ݒ�
                this.UOEGuideDivCd_tNedit.SetInt((int)this.Bind_DataSet.Tables[SECOND_TABLE].Rows[this._secondDataIndex][S_UOEGUIDEDIVCD]);
                this.UOEGuideDivNm_tEdit.Text = (string)this.Bind_DataSet.Tables[SECOND_TABLE].Rows[this._secondDataIndex][S_UOEGUIDEDIVNM];


                //�N���[���쐬
                UOEGuideName uoeGuideName = new UOEGuideName();
                this._uoeGuideNameClone = new UOEGuideName();
                // ADD 2008/10/30 �s��Ή�[7228] ---------->>>>>
                DispToUOEGuideName(ref uoeGuideName);
                // ADD 2008/10/30 �s��Ή�[7228] ----------<<<<<
                this._uoeGuideNameClone = uoeGuideName.Clone();

                // �t�H�[�J�X�ݒ�
                this.UOEGuideCode_tEdit.Focus();
            }
            else
            {
                // �I���K�C�h���̂̏����擾
                string guid = (string)this.Bind_DataSet.Tables[THIRD_TABLE].Rows[this._thirdDataIndex][T_UOEGUIDECODE_GUID];
                UOEGuideName uoeGuideName = ((UOEGuideName)this._thirdGridTable[guid]).Clone();

                if (uoeGuideName.LogicalDeleteCode == 0)
                {
                    // �X�V���[�h
                    this.Mode_Label.Text = UPDATE_MODE;

                    // ��ʓ��͋����䏈��
                    ScreenPermissionControl(UPDATE_MODE);

                    // ��ʓW�J����
                    UOEGuideNameToScreen(uoeGuideName);

                    //�N���[���쐬
                    this._uoeGuideNameClone = new UOEGuideName();
                    this._uoeGuideNameClone = uoeGuideName.Clone();
                    
                    // �t�H�[�J�X�ݒ�
                    this.UOEGuideName_tEdit.Focus();
                }
                else
                {
                    // �폜���[�h
                    this.Mode_Label.Text = DELETE_MODE;

                    // ��ʓ��͋����䏈��
                    ScreenPermissionControl(DELETE_MODE);

                    // ��ʓW�J����
                    UOEGuideNameToScreen(uoeGuideName);

                    //�N���[���쐬
                    this._uoeGuideNameClone = new UOEGuideName();
                    this._uoeGuideNameClone = uoeGuideName.Clone();

                    // �t�H�[�J�X�ݒ�
                    this.Delete_Button.Focus();
                }

                // Fream��Index/Table�o�b�t�@�ێ�
                this._mainIndexBuffer = this._mainDataIndex;
                this._secondIndexBuffer = this._secondDataIndex;
                this._thirdIndexBuffer = this._thirdDataIndex;
                this._targetTableBuffer = this._targetTableName;
            }

            // 2008.12.24 30413 ���� �K�C�h�R�[�h�̌�����ݒ� >>>>>>START
            // �K�C�h�R�[�h�̌�����ݒ�
            ChangeGuideCodeColumn(this.UOEGuideDivCd_tNedit.GetInt());
            // 2008.12.24 30413 ���� �K�C�h�R�[�h�̌�����ݒ� <<<<<<END
        }

        /// <summary>
        /// ��ʋ����䏈��
        /// </summary>
        /// <param name="screenMode">��ʃ��[�h</param>
        /// <remarks>
        /// <br>Note       : ��ʃ��[�h���ɓ��́^�{�^���̋��𐧌䂵�܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.07.01</br>
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
                
                // ���͐ݒ�
                this.UOESupplierCd_tNedit.Enabled = false;
                this.UOESupplierNm_tEdit.Enabled = false;
                this.UOEGuideDivCd_tNedit.Enabled = false;
                this.UOEGuideDivNm_tEdit.Enabled = false;
                this.UOEGuideCode_tEdit.Enabled = true;
                this.UOEGuideName_tEdit.Enabled = true;
            }
            // �X�V
            else if (screenMode.Equals(UPDATE_MODE))
            {
                // �{�^���ݒ�
                this.Ok_Button.Visible = true;
                this.Delete_Button.Visible = false;
                this.Revive_Button.Visible = false;
                
                // ���͐ݒ�
                this.UOESupplierCd_tNedit.Enabled = false;
                this.UOESupplierNm_tEdit.Enabled = false;
                this.UOEGuideDivCd_tNedit.Enabled = false;
                this.UOEGuideDivNm_tEdit.Enabled = false;
                this.UOEGuideCode_tEdit.Enabled = false;
                this.UOEGuideName_tEdit.Enabled = true;
            }
            // �폜
            else if (screenMode.Equals(DELETE_MODE))
            {
                // �{�^���ݒ�
                this.Ok_Button.Visible = false;
                this.Delete_Button.Visible = true;
                this.Revive_Button.Visible = true;
                
                // ���͐ݒ�
                this.UOESupplierCd_tNedit.Enabled = false;
                this.UOESupplierNm_tEdit.Enabled = false;
                this.UOEGuideDivCd_tNedit.Enabled = false;
                this.UOEGuideDivNm_tEdit.Enabled = false;
                this.UOEGuideCode_tEdit.Enabled = false;
                this.UOEGuideName_tEdit.Enabled = false;                
            }

        }

        /// <summary>
        /// �K�C�h�R�[�h�̌�����ݒ�
        /// </summary>
        /// <param name="guideDiv">�K�C�h�敪</param>
        /// <remarks>
        /// <br>Note       : �K�C�h�敪�œ��͌�����ݒ�B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.12.24</br>
        /// </remarks>
        private void ChangeGuideCodeColumn(int guideDiv)
        {
            int column = this.UOEGuideCode_tEdit.ExtEdit.Column;

            switch (guideDiv)
            {
                case 0:     // �Ɩ��敪
                    {
                        column = 1;
                        break;
                    }
                case 1:     // BO�敪
                    {
                        column = 1;
                        break;
                    }
                case 2:     // �[�i�敪
                    {
                        column = 1;
                        break;
                    }
                case 3:     // ���_�敪
                    {
                        column = 3;
                        break;
                    }
                default:
                    {
                        break;
                    }
            }

            // �K�C�h�R�[�h�̌�����ݒ�
            this.UOEGuideCode_tEdit.ExtEdit.Column = column;
        }

        /// <summary>
        /// HashTable�p�L�[�쐬
        /// </summary>
        /// <param name="uoeGuideName">UOE�K�C�h���̃}�X�^�I�u�W�F�N�g</param>
        /// <returns>Hash�e�[�u���p�L�[</returns>
        /// <remarks>
        /// <br>Note       : UOE�K�C�h���̃}�X�^����Third Grid�̃n�b�V���e�[�u���p�̃L�[���쐬���܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.07.01</br>
        /// </remarks>
        private string CreateHashKeyThird(UOEGuideName uoeGuideName)
        {
            string strHashKey = uoeGuideName.UOEGuideDivCd.ToString("d2") + uoeGuideName.UOEGuideCode;
            return strHashKey;
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
        /// <br>Date       : 2008.07.01</br>
        /// </remarks>
        private bool ScreenDataCheck(ref Control control, ref string message, string loginID)
        {
            // �K�C�h�R�[�h
            // >>>>>>>>>>>>>>>>>>>>>>>>>>> 2008/12/11 G.Miyatsu ADD
            if (this._secondDataIndex == 0)
            {
                // 2009.01.14 30413 ���� �[���œo�^�ł���悤�ɏC�� >>>>>>START
                //if (this.UOEGuideCode_tEdit.Text == "0" || this.UOEGuideCode_tEdit.Text.Trim() == "")
                if (this.UOEGuideCode_tEdit.Text.Trim() == "")
                {
                    control = this.UOEGuideCode_tEdit;
                    message = this.UOEGuideCode_Label.Text + "����͂��ĉ������B";
                    return false;
                }
                // 2009.01.14 30413 ���� �[���œo�^�ł���悤�ɏC�� <<<<<<END
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<< 2008/12/10 G.Miyatsu ADD

            // �K�C�h����
            if (this.UOEGuideName_tEdit.Text.Trim() == "")
            {
                control = this.UOEGuideName_tEdit;
                message = this.UOEGuideName_Label.Text + "����͂��ĉ������B";
                return false;
            }

            return true;
        }

        /// <summary>
        /// UOE�K�C�h���̃}�X�^ ���o�^����
        /// </summary>
        /// <returns>�o�^���ʁitrue:OK�^false:NG�j</returns>
        /// <remarks>
        /// <br>Note       : UOE�K�C�h���̃}�X�^ ���o�^���s���܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.07.01</br>
        /// </remarks>
        private bool SaveProc()
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            Control control = null;
            string message = null;
            string loginID = "";

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

            UOEGuideName uoeGuideName = null;

            if (this._thirdDataIndex >= 0)
            {
                string guid = (string)this.Bind_DataSet.Tables[THIRD_TABLE].Rows[this._thirdDataIndex][T_UOEGUIDECODE_GUID];
                uoeGuideName = ((UOEGuideName)this._thirdGridTable[guid]).Clone();
            }

            //�V�K�̏ꍇ�A��ʏ��������N���X�ɐݒ�
            this.DispToUOEGuideName(ref uoeGuideName);

            status = this._uoeGuideNameAcs.Write(ref uoeGuideName);
            
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

                        this.UOESupplierCd_tNedit.Focus();
                        return false;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        ExclusiveTransaction(status, TMsgDisp.OPE_UPDATE, this._uoeGuideNameAcs);

                        if (UnDisplaying != null)
                        {
                            MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                            UnDisplaying(this, me);
                        }

                        this.DialogResult = DialogResult.Cancel;
                        // Grid��IndexBuffer�i�[�p�ϐ�������
                        this._mainIndexBuffer = -2;
                        this._secondIndexBuffer = -2;
                        this._thirdIndexBuffer = -2;

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
                            PG_NM,  							// �v���O��������
                            "SaveProc",							// ��������
                            TMsgDisp.OPE_UPDATE,				// �I�y���[�V����
                            ERR_UPDT_MSG,						// �\�����郁�b�Z�[�W 
                            status,								// �X�e�[�^�X�l
                            this._uoeGuideNameAcs,				// �G���[�����������I�u�W�F�N�g
                            MessageBoxButtons.OK,				// �\������{�^��
                            MessageBoxDefaultButton.Button1);	// �����\���{�^��

                        if (UnDisplaying != null)
                        {
                            MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                            UnDisplaying(this, me);
                        }

                        this.DialogResult = DialogResult.Cancel;
                        // Grid��IndexBuffer�i�[�p�ϐ�������
                        this._mainIndexBuffer = -2;
                        this._secondIndexBuffer = -2;
                        this._thirdIndexBuffer = -2;

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
            int index = this._thirdDataIndex;

            UOEGuideNameToThirdDataSet(uoeGuideName, ref index);

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
        /// <br>Date       : 2008.07.01</br>
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
                            PG_NM,  							// �v���O��������
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
                            PG_NM,  							// �v���O��������
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
        /// UOE�����於�̎擾����
        /// </summary>
        /// <param name="uoeSupplierCd">UOE������R�[�h</param>
        /// <returns>UOE�����於��</returns>
        /// <remarks>
        /// <br>Note       : UOE�����於�̂��擾���܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008/07/01</br>
        /// </remarks>
        private string GetUOESupplierName(int uoeSupplierCd)
        {
            string uoeSupplierName = "";

            int status;
            ArrayList uoeSupplierArray;
            UOESupplier uoeSupplier = new UOESupplier();
            UOESupplierAcs uoeSupplierAcs = new UOESupplierAcs();

            try
            {
                status = uoeSupplierAcs.SearchAll(out uoeSupplierArray, this._enterpriseCode,this._sectionCode);
                if (status == 0)
                {
                    if (uoeSupplierArray.Count <= 0)
                    {
                        return uoeSupplierName;
                    }

                    foreach (UOESupplier wkUOESupplier in uoeSupplierArray)
                    {
                        if (wkUOESupplier.UOESupplierCd == uoeSupplierCd)
                        {
                            uoeSupplierName = wkUOESupplier.UOESupplierName.Trim();
                            return uoeSupplierName;
                        }
                    }
                }
            }
            catch
            {
                uoeSupplierName = "";
            }

            return uoeSupplierName;
        }

        # endregion

        #region ��Control Events

        /// <summary>
        /// PMUOE09030UA_Load �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@  : ���[�U�[���t�H�[����ǂݍ��ނƂ��ɔ������܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.30</br>
        /// </remarks>
        private void PMUOE09030UA_Load(object sender, EventArgs e)
        {
            // �A�C�R�����\�[�X�Ǘ��N���X���g�p���āA�A�C�R����\������
            ImageList imageList16 = IconResourceManagement.ImageList16;
            ImageList imageList24 = IconResourceManagement.ImageList24;

            this.Ok_Button.ImageList = imageList24;
            this.Cancel_Button.ImageList = imageList24;
            this.Revive_Button.ImageList = imageList24;
            this.Delete_Button.ImageList = imageList24;

            this.Ok_Button.Appearance.Image = Size24_Index.SAVE;
            this.Cancel_Button.Appearance.Image = Size24_Index.CLOSE;
            this.Revive_Button.Appearance.Image = Size24_Index.REVIVAL;
            this.Delete_Button.Appearance.Image = Size24_Index.DELETE;
            
            // ��ʃN���A
            ScreenClear();

            // ��ʏ����ݒ�
            ScreenInitialSetting();
        }

        /// <summary>
        /// Form.Closing �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�L�����Z���ł���C�x���g�̃f�[�^��񋟂���N���X</param>
        /// <remarks>
        /// <br>Note       : �t�H�[�������O�ɁA���[�U�[���t�H�[������悤�Ƃ����Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.30</br>
        /// </remarks>
        private void PMUOE09030UA_Closing(object sender, FormClosingEventArgs e)
        {
            // Grid��IndexBuffer�i�[�p�ϐ�������
            this._mainIndexBuffer = -2;
            this._secondIndexBuffer = -2;
            this._thirdIndexBuffer = -2;
            this._targetTableBuffer = "";

            // �t�H�[���́u�~�v���N���b�N���ꂽ�ꍇ�̑Ή��ł��B
            if (CanClose == false)
            {
                e.Cancel = true;
                this.Hide();
                return;
            }
        }

        /// <summary>
        /// Control.VisibleChanged �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note �@�@  : �t�H�[���̕\����Ԃ��ς�����Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.30</br>
        /// </remarks>
        private void PMUOE09030UA_VisibleChanged(object sender, EventArgs e)
        {
            // �������g����\���ɂȂ����ꍇ�͈ȉ��̏������L�����Z������B
            if (this.Visible == false)
            {
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

            // ��ʃN���A
            ScreenClear();

            Initial_Timer.Enabled = true;
        }

        /// <summary>
        /// Timer.Tick �C�x���g �C�x���g(Initial_Timer)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : �w�肳�ꂽ�Ԋu�̎��Ԃ��o�߂����Ƃ��ɔ������܂��B</br>
        ///	<br>             ���̏����́A�V�X�e�����񋟂���X���b�h �v�[��</br>
        ///	<br>             �X���b�h�Ŏ��s����܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.30</br>
        /// </remarks>
        private void Initial_Timer_Tick(object sender, EventArgs e)
        {
            Initial_Timer.Enabled = false;

            // ��ʍč\�z����
            ScreenReconstruction();
        }

        /// <summary>
        /// Control.Click �C�x���g(OK_Button)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : �ۑ��{�^�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.07.01</br>
        /// </remarks>
        private void Ok_Button_Click(object sender, EventArgs e)
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

            // �V�K���[�h�̏ꍇ�͉�ʂ��I���������ɘA�����͂��\�Ƃ���B
            if (this.Mode_Label.Text == INSERT_MODE)
            {
                // �f�[�^�C���f�b�N�X������������
                this._thirdDataIndex = -1;

                // ��ʃN���A����
                this.UOEGuideCode_tEdit.Clear();
                this.UOEGuideName_tEdit.Clear();
            }
            else
            {
                this.DialogResult = DialogResult.OK;

                // Grid��IndexBuffer�i�[�p�ϐ�������
                this._mainIndexBuffer = -2;
                this._secondIndexBuffer = -2;
                this._thirdIndexBuffer = -2;
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
        }

        /// <summary>
        /// Control.Click �C�x���g(Cancel_Button)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : ����{�^�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.07.01</br>
        /// </remarks>
        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            // �폜���[�h�ȊO�̏ꍇ�͕ۑ��m�F�������s��
            if (this.Mode_Label.Text != DELETE_MODE)
            {
                //�ۑ��m�F
                UOEGuideName compareUOEGuideName = new UOEGuideName();
                compareUOEGuideName = this._uoeGuideNameClone.Clone();
                //���݂̉�ʏ����擾����
                DispToUOEGuideName(ref compareUOEGuideName);
                //�ŏ��Ɏ擾������ʏ��Ɣ�r
                if (!(this._uoeGuideNameClone.Equals(compareUOEGuideName)))
                {
                    //��ʏ�񂪕ύX����Ă����ꍇ�́A�ۑ��m�F���b�Z�[�W��\������
                    DialogResult res = TMsgDisp.Show(
                        this,								// �e�E�B���h�E�t�H�[��
                        emErrorLevel.ERR_LEVEL_SAVECONFIRM,	// �G���[���x��
                        PG_ID,      						// �A�Z���u���h�c�܂��̓N���X�h�c
                        "",									// �\�����郁�b�Z�[�W 
                        0,									// �X�e�[�^�X�l
                        MessageBoxButtons.YesNoCancel);		// �\������{�^��

                    switch (res)
                    {
                        case DialogResult.Yes:
                            {
                                if (SaveProc() == false)
                                {
                                    return;
                                }

                                if (UnDisplaying != null)
                                {
                                    MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                                    UnDisplaying(this, me);
                                }

                                break;
                            }
                        case DialogResult.No:
                            {
                                if (UnDisplaying != null)
                                {
                                    MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.Cancel);
                                    UnDisplaying(this, me);
                                }

                                break;
                            }
                        default:
                            {
                                // 2009.03.31 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� >>>>>>START
                                //this.Cancel_Button.Focus();
                                if (_modeFlg)
                                {
                                    UOEGuideCode_tEdit.Focus();
                                    _modeFlg = false;
                                }
                                else
                                {
                                    this.Cancel_Button.Focus();
                                }
                                // 2009.03.31 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� <<<<<<END
                                return;
                            }
                    }
                }
                
            }

            this.DialogResult = DialogResult.Cancel;

            // Grid��IndexBuffer�i�[�p�ϐ�������
            this._mainIndexBuffer = -2;
            this._secondIndexBuffer = -2;
            this._thirdIndexBuffer = -2;
            this._targetTableBuffer = "";

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
        /// <br>Date       : 2008.07.01</br>
        /// </remarks>
        private void Delete_Button_Click(object sender, System.EventArgs e)
        {
            int status = 0;
            DialogResult result = TMsgDisp.Show(
                this,													// �e�E�B���h�E�t�H�[��
                emErrorLevel.ERR_LEVEL_QUESTION,						// �G���[���x��
                PG_ID,      											// �A�Z���u���h�c�܂��̓N���X�h�c
                "�f�[�^���폜���܂��B" + "\r\n" + "��낵���ł����H",	// �\�����郁�b�Z�[�W 
                0,														// �X�e�[�^�X�l
                MessageBoxButtons.OKCancel,								// �\������{�^��
                MessageBoxDefaultButton.Button2);						// �����\���{�^��


            if (result == DialogResult.OK)
            {
                string guid = (string)this.Bind_DataSet.Tables[THIRD_TABLE].Rows[this._thirdDataIndex][T_UOEGUIDECODE_GUID];
                UOEGuideName uoeGuideName = ((UOEGuideName)this._thirdGridTable[guid]).Clone();

                status = this._uoeGuideNameAcs.Delete(uoeGuideName);
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        {
                            this.Bind_DataSet.Tables[THIRD_TABLE].Rows[this._thirdDataIndex].Delete();
                            this._thirdGridTable.Remove(CreateHashKeyThird(uoeGuideName));

                            break;
                        }
                    case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                        {
                            ExclusiveTransaction(status, TMsgDisp.OPE_DELETE, this._uoeSupplierAcs);

                            if (UnDisplaying != null)
                            {
                                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                                UnDisplaying(this, me);
                            }

                            this.DialogResult = DialogResult.Cancel;
                            // Grid��IndexBuffer�i�[�p�ϐ�������
                            this._mainIndexBuffer = -2;
                            this._secondIndexBuffer = -2;
                            this._thirdIndexBuffer = -2;
                            
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
                                PG_NM,  							  // �v���O��������
                                "Delete_Button_Click",				  // ��������
                                TMsgDisp.OPE_DELETE,				  // �I�y���[�V����
                                ERR_RDEL_MSG,						  // �\�����郁�b�Z�[�W 
                                status,								  // �X�e�[�^�X�l
                                this._uoeGuideNameAcs,					  // �G���[�����������I�u�W�F�N�g
                                MessageBoxButtons.OK,				  // �\������{�^��
                                MessageBoxDefaultButton.Button1);	  // �����\���{�^��

                            if (UnDisplaying != null)
                            {
                                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                                UnDisplaying(this, me);
                            }

                            this.DialogResult = DialogResult.Cancel;
                            // Grid��IndexBuffer�i�[�p�ϐ�������
                            this._mainIndexBuffer = -2;
                            this._secondIndexBuffer = -2;
                            this._thirdIndexBuffer = -2;
                            
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

            // Grid��IndexBuffer�i�[�p�ϐ�������
            this._mainIndexBuffer = -2;
            this._secondIndexBuffer = -2;
            this._thirdIndexBuffer = -2;
            
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
        /// <br>Date       : 2008.07.01</br>
        /// </remarks>
        private void Revive_Button_Click(object sender, System.EventArgs e)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            string guid = (string)this.Bind_DataSet.Tables[THIRD_TABLE].Rows[this._thirdDataIndex][T_UOEGUIDECODE_GUID];
            UOEGuideName uoeGuideName = ((UOEGuideName)_thirdGridTable[guid]).Clone();

            status = this._uoeGuideNameAcs.Revival(ref uoeGuideName);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        ExclusiveTransaction(status, TMsgDisp.OPE_UPDATE, this._uoeSupplierAcs);

                        if (UnDisplaying != null)
                        {
                            MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                            UnDisplaying(this, me);
                        }

                        this.DialogResult = DialogResult.Cancel;
                        // Grid��IndexBuffer�i�[�p�ϐ�������
                        this._mainIndexBuffer = -2;
                        this._secondIndexBuffer = -2;
                        this._thirdIndexBuffer = -2;
                        
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
                            PG_NM,		    					  // �v���O��������
                            "Revive_Button_Click",				  // ��������
                            TMsgDisp.OPE_UPDATE,				  // �I�y���[�V����
                            ERR_RVV_MSG,						  // �\�����郁�b�Z�[�W 
                            status,								  // �X�e�[�^�X�l
                            this._uoeGuideNameAcs,					  // �G���[�����������I�u�W�F�N�g
                            MessageBoxButtons.OK,				  // �\������{�^��
                            MessageBoxDefaultButton.Button1);	  // �����\���{�^��

                        if (UnDisplaying != null)
                        {
                            MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                            UnDisplaying(this, me);
                        }

                        this.DialogResult = DialogResult.Cancel;
                        // Grid��IndexBuffer�i�[�p�ϐ�������
                        this._mainIndexBuffer = -2;
                        this._secondIndexBuffer = -2;
                        this._thirdIndexBuffer = -2;
                        
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
            int index = this._thirdDataIndex;
            UOEGuideNameToThirdDataSet(uoeGuideName, ref index);

            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                UnDisplaying(this, me);
            }

            this.DialogResult = DialogResult.OK;

            // Grid��IndexBuffer�i�[�p�ϐ�������
            this._mainIndexBuffer = -2;
            this._secondIndexBuffer = -2;
            this._thirdIndexBuffer = -2;
            
            if (CanClose == true)
            {
                this.Close();
            }
            else
            {
                this.Hide();
            }

            // ADD 2009/03/25 �s��Ή�[12719]�F�u�폜�σf�[�^�̕\���v�͍ŏ�ʍ��ڂŐ��� ---------->>>>>
            // �Č����i�e�e�[�u���̒l���Đݒ�j
            int totalCount = 0;
            ThirdDataSearch(ref totalCount, 0);
            // ADD 2009/03/25 �s��Ή�[12719]�F�u�폜�σf�[�^�̕\���v�͍ŏ�ʍ��ڂŐ��� ----------<<<<<
        }

        # endregion

        // 2009.03.31 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� >>>>>>START
        /// <summary>
        /// �t�H�[�J�X�ړ��C�x���g
        /// </summary>
        /// <remarks>
        /// </remarks>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null || e.NextCtrl == null) return;

            _modeFlg = false;

            switch (e.PrevCtrl.Name)
            {
                case "UOEGuideCode_tEdit":
                    {
                        if (e.NextCtrl.Name == "Cancel_Button")
                        {
                            // �J�ڐ悪����{�^��
                            _modeFlg = true;
                        }
                        else if (this._thirdDataIndex < 0)
                        {
                            if (ModeChangeProc())
                            {
                                e.NextCtrl = UOEGuideCode_tEdit;
                            }
                        }
                        break;
                    }
            }
        }

        /// <summary>
        /// ���[�h�ύX����
        /// </summary>
        private bool ModeChangeProc()
        {
            // UOE�K�C�h�R�[�h
            string uoeGuideCode = UOEGuideCode_tEdit.Text.TrimEnd();

            for (int i = 0; i < this.Bind_DataSet.Tables[THIRD_TABLE].Rows.Count; i++)
            {
                // �f�[�^�Z�b�g�Ɣ�r
                string dsUOEGuideCode = (string)this.Bind_DataSet.Tables[THIRD_TABLE].Rows[i][T_UOEGUIDECODE];
                if (uoeGuideCode.Equals(dsUOEGuideCode.TrimEnd()))
                {
                    // ���̓R�[�h���f�[�^�Z�b�g�ɑ��݂���ꍇ
                    if ((string)this.Bind_DataSet.Tables[THIRD_TABLE].Rows[i][T_DELETEDATE] != "")
                    {
                        // �_���폜
                        TMsgDisp.Show(this, 					// �e�E�B���h�E�t�H�[��
                          emErrorLevel.ERR_LEVEL_INFO,          // �G���[���x��
                          PG_ID,						        // �A�Z���u���h�c�܂��̓N���X�h�c
                          "���͂��ꂽ�R�[�h��UOE�K�C�h���̏��͊��ɍ폜����Ă��܂��B", 			// �\�����郁�b�Z�[�W
                          0, 									// �X�e�[�^�X�l
                          MessageBoxButtons.OK);				// �\������{�^��
                        // UOE�K�C�h�R�[�h�̃N���A
                        UOEGuideCode_tEdit.Clear();
                        return true;
                    }

                    DialogResult res = TMsgDisp.Show(
                        this,                                   // �e�E�B���h�E�t�H�[��
                        emErrorLevel.ERR_LEVEL_INFO,            // �G���[���x��
                        PG_ID,                                  // �A�Z���u���h�c�܂��̓N���X�h�c
                        "���͂��ꂽ�R�[�h��UOE�K�C�h���̏�񂪊��ɓo�^����Ă��܂��B\n�ҏW���s���܂����H",                                    // �\�����郁�b�Z�[�W
                        0,                                      // �X�e�[�^�X�l
                        MessageBoxButtons.YesNo);               // �\������{�^��
                    switch (res)
                    {
                        case DialogResult.Yes:
                            {
                                // ��ʍĕ`��
                                this._thirdDataIndex = i;
                                ScreenClear();
                                ScreenReconstruction();
                                break;
                            }
                        case DialogResult.No:
                            {
                                // UOE�K�C�h�R�[�h�̃N���A
                                UOEGuideCode_tEdit.Clear();
                                break;
                            }
                    }
                    return true;
                }
            }
            return false;
        }
        // 2009.03.31 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� <<<<<<END
    }
}

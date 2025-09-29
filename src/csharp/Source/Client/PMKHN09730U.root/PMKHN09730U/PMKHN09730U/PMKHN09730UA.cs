//**********************************************************************//
// System           :   PM.NS                                           
// Sub System       :                                                   
// Program name     :   ���[���O���[�v�����ݒ�}�X�^                    
//                      �t�H�[���N���X                                  
//                  :   PMKHN09730U.DLL                                 
// Name Space       :   Broadleaf.Windows.Forms                         
// Programmer       :   30746 ���� ��                                   
// Date             :   2013/02/18                                      
//----------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �����@���n
// �C �� ��  2013/03/06  �C�����e : ���[�����̐ݒ肪���݂��Ȃ��ꍇ�̃G���[���b�Z�[�W���C��
//----------------------------------------------------------------------//
//                 Copyright(C) 2008 Broadleaf Co.,Ltd.                 //
//**********************************************************************//

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
    /// ���[���O���[�v�����ݒ�}�X�^ �t�H�[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note        : ���[���O���[�v�����ݒ�}�X�^���̐ݒ���s���܂��B
    ///                   IMasterMaintenanceArrayType���������Ă��܂��B</br>
    /// <br>Programmer  : 30746 ���� ��</br>
    /// <br>Date        : 2013/02/18</br>
    /// </remarks>
    public class PMKHN09730UA : System.Windows.Forms.Form, IMasterMaintenanceArrayType
    {
        # region ��Private Members (Component)

        private TArrowKeyControl tArrowKeyControl1;
        private IContainer components;
        private Infragistics.Win.Misc.UltraLabel lblRoleGroup;
        private TNedit txtRoleGroupCode;
        private TRetKeyControl tRetKeyControl1;
        private DataSet Bind_DataSet;
        private Timer Initial_Timer;
        private TImeControl tImeControl1;
        private Infragistics.Win.Misc.UltraButton buttonCancel;
        private Infragistics.Win.Misc.UltraButton buttonRevive;
        private Infragistics.Win.Misc.UltraButton buttonDelete;
        private Infragistics.Win.Misc.UltraButton buttonOK;
        private Infragistics.Win.Misc.UltraLabel lblSystemFunction;
        private TEdit txtRoleGroupName;
        private Infragistics.Win.Misc.UltraButton buttonSystemFuncGuide;
        private Infragistics.Win.Misc.UltraLabel lblMessage;
        private Infragistics.Win.Misc.UltraLabel lblMode;
        private TImeControl tImeControl2;
        private UiSetControl uiSetControl1;
        internal TEdit txtSystemFunction;
        internal TNedit txtCategoryID;
        internal TNedit txtCategorySubID;
        internal TNedit txtItemID;
        private Infragistics.Win.Misc.UltraLabel lblItemID;
        private Infragistics.Win.Misc.UltraLabel lblCategorySubID;
        private Infragistics.Win.Misc.UltraLabel lblCategoryID;
        public Infragistics.Win.UltraWinStatusBar.UltraStatusBar ultraStatusBar1;

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
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance23 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PMKHN09730UA));
            this.ultraStatusBar1 = new Infragistics.Win.UltraWinStatusBar.UltraStatusBar();
            this.tArrowKeyControl1 = new Broadleaf.Library.Windows.Forms.TArrowKeyControl(this.components);
            this.tRetKeyControl1 = new Broadleaf.Library.Windows.Forms.TRetKeyControl(this.components);
            this.Bind_DataSet = new System.Data.DataSet();
            this.Initial_Timer = new System.Windows.Forms.Timer(this.components);
            this.tImeControl1 = new Broadleaf.Library.Windows.Forms.TImeControl(this.components);
            this.txtSystemFunction = new Broadleaf.Library.Windows.Forms.TEdit();
            this.txtRoleGroupCode = new Broadleaf.Library.Windows.Forms.TNedit();
            this.lblRoleGroup = new Infragistics.Win.Misc.UltraLabel();
            this.lblSystemFunction = new Infragistics.Win.Misc.UltraLabel();
            this.buttonCancel = new Infragistics.Win.Misc.UltraButton();
            this.buttonRevive = new Infragistics.Win.Misc.UltraButton();
            this.buttonDelete = new Infragistics.Win.Misc.UltraButton();
            this.buttonOK = new Infragistics.Win.Misc.UltraButton();
            this.buttonSystemFuncGuide = new Infragistics.Win.Misc.UltraButton();
            this.txtRoleGroupName = new Broadleaf.Library.Windows.Forms.TEdit();
            this.lblMessage = new Infragistics.Win.Misc.UltraLabel();
            this.lblMode = new Infragistics.Win.Misc.UltraLabel();
            this.tImeControl2 = new Broadleaf.Library.Windows.Forms.TImeControl(this.components);
            this.uiSetControl1 = new Broadleaf.Library.Windows.Forms.UiSetControl(this.components);
            this.txtItemID = new Broadleaf.Library.Windows.Forms.TNedit();
            this.txtCategorySubID = new Broadleaf.Library.Windows.Forms.TNedit();
            this.txtCategoryID = new Broadleaf.Library.Windows.Forms.TNedit();
            this.lblCategoryID = new Infragistics.Win.Misc.UltraLabel();
            this.lblCategorySubID = new Infragistics.Win.Misc.UltraLabel();
            this.lblItemID = new Infragistics.Win.Misc.UltraLabel();
            ((System.ComponentModel.ISupportInitialize)(this.Bind_DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSystemFunction)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRoleGroupCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRoleGroupName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtItemID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCategorySubID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCategoryID)).BeginInit();
            this.SuspendLayout();
            // 
            // ultraStatusBar1
            // 
            this.ultraStatusBar1.Location = new System.Drawing.Point(0, 179);
            this.ultraStatusBar1.Name = "ultraStatusBar1";
            this.ultraStatusBar1.Size = new System.Drawing.Size(645, 23);
            this.ultraStatusBar1.TabIndex = 47;
            this.ultraStatusBar1.ViewStyle = Infragistics.Win.UltraWinStatusBar.ViewStyle.Office2003;
            // 
            // tArrowKeyControl1
            // 
            this.tArrowKeyControl1.OwnerForm = this;
            // 
            // tRetKeyControl1
            // 
            this.tRetKeyControl1.OwnerForm = this;
            this.tRetKeyControl1.Style = Broadleaf.Library.Windows.Forms.emFocusStyle.ByTab;
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
            this.tImeControl1.InControl = this.txtSystemFunction;
            this.tImeControl1.OutControl = null;
            this.tImeControl1.OwnerForm = this;
            this.tImeControl1.PutLength = 20;
            // 
            // txtSystemFunction
            // 
            appearance14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.txtSystemFunction.ActiveAppearance = appearance14;
            appearance15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance15.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance15.ForeColorDisabled = System.Drawing.Color.Black;
            this.txtSystemFunction.Appearance = appearance15;
            this.txtSystemFunction.AutoSelect = false;
            this.txtSystemFunction.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.txtSystemFunction.DataText = "";
            this.txtSystemFunction.Enabled = false;
            this.txtSystemFunction.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.txtSystemFunction.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 15, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, true, true, true, true));
            this.txtSystemFunction.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtSystemFunction.Location = new System.Drawing.Point(135, 74);
            this.txtSystemFunction.MaxLength = 15;
            this.txtSystemFunction.Name = "txtSystemFunction";
            this.txtSystemFunction.ReadOnly = true;
            this.txtSystemFunction.Size = new System.Drawing.Size(453, 24);
            this.txtSystemFunction.TabIndex = 5;
            this.txtSystemFunction.TabStop = false;
            // 
            // txtRoleGroupCode
            // 
            appearance8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance8.TextHAlignAsString = "Right";
            this.txtRoleGroupCode.ActiveAppearance = appearance8;
            appearance10.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance10.ForeColor = System.Drawing.Color.Black;
            appearance10.ForeColorDisabled = System.Drawing.Color.Black;
            appearance10.TextHAlignAsString = "Right";
            this.txtRoleGroupCode.Appearance = appearance10;
            this.txtRoleGroupCode.AutoSelect = true;
            this.txtRoleGroupCode.CalcSize = new System.Drawing.Size(172, 200);
            this.txtRoleGroupCode.DataText = "999999";
            this.txtRoleGroupCode.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.txtRoleGroupCode.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 3, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.txtRoleGroupCode.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtRoleGroupCode.Location = new System.Drawing.Point(135, 44);
            this.txtRoleGroupCode.MaxLength = 3;
            this.txtRoleGroupCode.Name = "txtRoleGroupCode";
            this.txtRoleGroupCode.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.txtRoleGroupCode.ReadOnly = true;
            this.txtRoleGroupCode.Size = new System.Drawing.Size(60, 24);
            this.txtRoleGroupCode.TabIndex = 0;
            this.txtRoleGroupCode.Text = "999999";
            // 
            // lblRoleGroup
            // 
            appearance9.TextVAlignAsString = "Middle";
            this.lblRoleGroup.Appearance = appearance9;
            this.lblRoleGroup.BackColorInternal = System.Drawing.Color.Transparent;
            this.lblRoleGroup.Location = new System.Drawing.Point(12, 44);
            this.lblRoleGroup.Name = "lblRoleGroup";
            this.lblRoleGroup.Size = new System.Drawing.Size(117, 24);
            this.lblRoleGroup.TabIndex = 61;
            this.lblRoleGroup.Text = "���[���O���[�v";
            // 
            // lblSystemFunction
            // 
            appearance16.TextVAlignAsString = "Middle";
            this.lblSystemFunction.Appearance = appearance16;
            this.lblSystemFunction.BackColorInternal = System.Drawing.Color.Transparent;
            this.lblSystemFunction.Location = new System.Drawing.Point(12, 74);
            this.lblSystemFunction.Name = "lblSystemFunction";
            this.lblSystemFunction.Size = new System.Drawing.Size(107, 24);
            this.lblSystemFunction.TabIndex = 61;
            this.lblSystemFunction.Text = "�V�X�e���@�\";
            // 
            // buttonCancel
            // 
            this.buttonCancel.ImageSize = new System.Drawing.Size(24, 24);
            this.buttonCancel.Location = new System.Drawing.Point(506, 123);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(125, 34);
            this.buttonCancel.TabIndex = 11;
            this.buttonCancel.Text = "����(&X)";
            this.buttonCancel.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonRevive
            // 
            this.buttonRevive.ImageSize = new System.Drawing.Size(24, 24);
            this.buttonRevive.Location = new System.Drawing.Point(375, 123);
            this.buttonRevive.Name = "buttonRevive";
            this.buttonRevive.Size = new System.Drawing.Size(125, 34);
            this.buttonRevive.TabIndex = 9;
            this.buttonRevive.Text = "����(&R)";
            this.buttonRevive.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.buttonRevive.Click += new System.EventHandler(this.buttonRevive_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.ImageSize = new System.Drawing.Size(24, 24);
            this.buttonDelete.Location = new System.Drawing.Point(247, 123);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(125, 34);
            this.buttonDelete.TabIndex = 8;
            this.buttonDelete.Text = "���S�폜(&D)";
            this.buttonDelete.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // buttonOK
            // 
            this.buttonOK.ImageSize = new System.Drawing.Size(24, 24);
            this.buttonOK.Location = new System.Drawing.Point(375, 123);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(125, 34);
            this.buttonOK.TabIndex = 10;
            this.buttonOK.Text = "�ۑ�(&S)";
            this.buttonOK.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.buttonOK.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // buttonSystemFuncGuide
            // 
            appearance12.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance12.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.buttonSystemFuncGuide.Appearance = appearance12;
            this.buttonSystemFuncGuide.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonSystemFuncGuide.Location = new System.Drawing.Point(596, 74);
            this.buttonSystemFuncGuide.Name = "buttonSystemFuncGuide";
            this.buttonSystemFuncGuide.Size = new System.Drawing.Size(24, 24);
            this.buttonSystemFuncGuide.TabIndex = 3;
            this.buttonSystemFuncGuide.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.buttonSystemFuncGuide.Click += new System.EventHandler(this.buttonSystemFuncGuide_Click);
            // 
            // txtRoleGroupName
            // 
            appearance1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance1.ForeColor = System.Drawing.Color.Black;
            appearance1.TextVAlignAsString = "Middle";
            this.txtRoleGroupName.ActiveAppearance = appearance1;
            appearance2.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance2.ForeColor = System.Drawing.Color.Black;
            appearance2.ForeColorDisabled = System.Drawing.Color.Black;
            appearance2.TextVAlignAsString = "Middle";
            this.txtRoleGroupName.Appearance = appearance2;
            this.txtRoleGroupName.AutoSelect = false;
            this.txtRoleGroupName.DataText = "�����������������������������������Ă�";
            this.txtRoleGroupName.Enabled = false;
            this.txtRoleGroupName.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.txtRoleGroupName.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 20, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.txtRoleGroupName.Location = new System.Drawing.Point(201, 44);
            this.txtRoleGroupName.MaxLength = 20;
            this.txtRoleGroupName.Name = "txtRoleGroupName";
            this.txtRoleGroupName.ReadOnly = true;
            this.txtRoleGroupName.Size = new System.Drawing.Size(401, 24);
            this.txtRoleGroupName.TabIndex = 68;
            this.txtRoleGroupName.TabStop = false;
            this.txtRoleGroupName.Text = "�����������������������������������Ă�";
            // 
            // lblMessage
            // 
            appearance17.TextVAlignAsString = "Middle";
            this.lblMessage.Appearance = appearance17;
            this.lblMessage.BackColorInternal = System.Drawing.Color.Transparent;
            this.lblMessage.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblMessage.Location = new System.Drawing.Point(12, 11);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(368, 24);
            this.lblMessage.TabIndex = 61;
            this.lblMessage.Text = "�Ɩ����j���[�ɕ\�������Ȃ��@�\�̂ݓo�^���܂�";
            // 
            // lblMode
            // 
            appearance13.ForeColor = System.Drawing.Color.White;
            appearance13.TextHAlignAsString = "Center";
            appearance13.TextVAlignAsString = "Middle";
            this.lblMode.Appearance = appearance13;
            this.lblMode.BackColorInternal = System.Drawing.Color.Navy;
            this.lblMode.Location = new System.Drawing.Point(528, 12);
            this.lblMode.Name = "lblMode";
            this.lblMode.Size = new System.Drawing.Size(100, 23);
            this.lblMode.TabIndex = 69;
            this.lblMode.Text = "�X�V���[�h";
            // 
            // tImeControl2
            // 
            this.tImeControl2.InControl = this.txtSystemFunction;
            this.tImeControl2.OutControl = null;
            this.tImeControl2.OwnerForm = this;
            this.tImeControl2.PutLength = 15;
            // 
            // uiSetControl1
            // 
            this.uiSetControl1.EditWidthSettingWay = Broadleaf.Library.Windows.Forms.UiSetControl.EditWidthSettingWayState.None;
            this.uiSetControl1.OwnerForm = this;
            // 
            // txtItemID
            // 
            appearance6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance6.TextHAlignAsString = "Right";
            this.txtItemID.ActiveAppearance = appearance6;
            appearance7.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance7.ForeColor = System.Drawing.Color.Black;
            appearance7.ForeColorDisabled = System.Drawing.Color.Black;
            appearance7.TextHAlignAsString = "Right";
            this.txtItemID.Appearance = appearance7;
            this.txtItemID.AutoSelect = true;
            this.txtItemID.CalcSize = new System.Drawing.Size(172, 200);
            this.txtItemID.DataText = "";
            this.txtItemID.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.txtItemID.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 3, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.txtItemID.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtItemID.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtItemID.Location = new System.Drawing.Point(12, 139);
            this.txtItemID.MaxLength = 3;
            this.txtItemID.Name = "txtItemID";
            this.txtItemID.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.txtItemID.Size = new System.Drawing.Size(55, 21);
            this.txtItemID.TabIndex = 70;
            this.txtItemID.Visible = false;
            // 
            // txtCategorySubID
            // 
            appearance4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance4.TextHAlignAsString = "Right";
            this.txtCategorySubID.ActiveAppearance = appearance4;
            appearance5.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance5.ForeColor = System.Drawing.Color.Black;
            appearance5.ForeColorDisabled = System.Drawing.Color.Black;
            appearance5.TextHAlignAsString = "Right";
            this.txtCategorySubID.Appearance = appearance5;
            this.txtCategorySubID.AutoSelect = true;
            this.txtCategorySubID.CalcSize = new System.Drawing.Size(172, 200);
            this.txtCategorySubID.DataText = "";
            this.txtCategorySubID.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.txtCategorySubID.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 3, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.txtCategorySubID.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtCategorySubID.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtCategorySubID.Location = new System.Drawing.Point(12, 119);
            this.txtCategorySubID.MaxLength = 3;
            this.txtCategorySubID.Name = "txtCategorySubID";
            this.txtCategorySubID.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.txtCategorySubID.Size = new System.Drawing.Size(55, 21);
            this.txtCategorySubID.TabIndex = 71;
            this.txtCategorySubID.Visible = false;
            // 
            // txtCategoryID
            // 
            appearance22.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance22.TextHAlignAsString = "Right";
            this.txtCategoryID.ActiveAppearance = appearance22;
            appearance23.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance23.ForeColor = System.Drawing.Color.Black;
            appearance23.ForeColorDisabled = System.Drawing.Color.Black;
            appearance23.TextHAlignAsString = "Right";
            this.txtCategoryID.Appearance = appearance23;
            this.txtCategoryID.AutoSelect = true;
            this.txtCategoryID.CalcSize = new System.Drawing.Size(172, 200);
            this.txtCategoryID.DataText = "";
            this.txtCategoryID.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.txtCategoryID.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 3, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.txtCategoryID.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtCategoryID.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtCategoryID.Location = new System.Drawing.Point(12, 101);
            this.txtCategoryID.MaxLength = 3;
            this.txtCategoryID.Name = "txtCategoryID";
            this.txtCategoryID.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.txtCategoryID.Size = new System.Drawing.Size(55, 21);
            this.txtCategoryID.TabIndex = 72;
            this.txtCategoryID.Visible = false;
            // 
            // lblCategoryID
            // 
            appearance11.TextVAlignAsString = "Middle";
            this.lblCategoryID.Appearance = appearance11;
            this.lblCategoryID.BackColorInternal = System.Drawing.Color.Transparent;
            this.lblCategoryID.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblCategoryID.Location = new System.Drawing.Point(77, 101);
            this.lblCategoryID.Name = "lblCategoryID";
            this.lblCategoryID.Size = new System.Drawing.Size(156, 24);
            this.lblCategoryID.TabIndex = 73;
            this.lblCategoryID.Text = "���J�e�S��ID(��\��)";
            this.lblCategoryID.Visible = false;
            // 
            // lblCategorySubID
            // 
            appearance3.TextVAlignAsString = "Middle";
            this.lblCategorySubID.Appearance = appearance3;
            this.lblCategorySubID.BackColorInternal = System.Drawing.Color.Transparent;
            this.lblCategorySubID.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblCategorySubID.Location = new System.Drawing.Point(77, 120);
            this.lblCategorySubID.Name = "lblCategorySubID";
            this.lblCategorySubID.Size = new System.Drawing.Size(156, 24);
            this.lblCategorySubID.TabIndex = 74;
            this.lblCategorySubID.Text = "���T�u�J�e�S��ID(��\��)";
            this.lblCategorySubID.Visible = false;
            // 
            // lblItemID
            // 
            appearance19.TextVAlignAsString = "Middle";
            this.lblItemID.Appearance = appearance19;
            this.lblItemID.BackColorInternal = System.Drawing.Color.Transparent;
            this.lblItemID.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblItemID.Location = new System.Drawing.Point(77, 139);
            this.lblItemID.Name = "lblItemID";
            this.lblItemID.Size = new System.Drawing.Size(156, 24);
            this.lblItemID.TabIndex = 75;
            this.lblItemID.Text = "���A�C�e��ID(��\��)";
            this.lblItemID.Visible = false;
            // 
            // PMKHN09730UA
            // 
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(645, 202);
            this.Controls.Add(this.lblItemID);
            this.Controls.Add(this.lblCategorySubID);
            this.Controls.Add(this.lblCategoryID);
            this.Controls.Add(this.txtCategoryID);
            this.Controls.Add(this.txtCategorySubID);
            this.Controls.Add(this.txtItemID);
            this.Controls.Add(this.lblMode);
            this.Controls.Add(this.txtRoleGroupName);
            this.Controls.Add(this.buttonSystemFuncGuide);
            this.Controls.Add(this.txtSystemFunction);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonRevive);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.lblSystemFunction);
            this.Controls.Add(this.lblRoleGroup);
            this.Controls.Add(this.txtRoleGroupCode);
            this.Controls.Add(this.ultraStatusBar1);
            this.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PMKHN09730UA";
            this.Text = "���[���O���[�v�����ݒ�";
            this.Load += new System.EventHandler(this.PMKHN09730UA_Load);
            this.VisibleChanged += new System.EventHandler(this.PMKHN09730UA_VisibleChanged);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PMKHN09730UA_Closing);
            ((System.ComponentModel.ISupportInitialize)(this.Bind_DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSystemFunction)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRoleGroupCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRoleGroupName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtItemID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCategorySubID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCategoryID)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        # endregion

        #region ��Private Members
        private RoleGroupNameStAcs _roleGroupNameStAcs;
        private RoleGroupAuthAcs _roleGroupAuthAcs;

        private RoleGroupAuth _roleGroupAuth;
        private RoleGroupAuth _roleGroupAuthClone;

        private int _totalCount;
        private string _enterpriseCode;
        private Hashtable _roleGroupNameTable;
        private Hashtable _roleGroupAuthTable;
        private Hashtable _roleGroupAuthCloneTable;

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

        // Frame��View�pGrid���KEY��� (�w�b�_�̃^�C�g�����ƂȂ�܂�)
        private const string I_ROLEGROUPCODE = "���[���O���[�v�R�[�h";
        private const string I_ROELGROUPNAME = "���[���O���[�v����";
        private const string I_ROLEGROUPNAME_GUID = "ROLEGROUPNAME_GUID";
        private const string I_ROLEGROUPNAME_TABLE = "ROLEGROUPNAME_TABLE";

        private const string S_DELETEDATE = "�폜��";
        private const string S_SORTKEY = "�\�[�g�L�[";
        private const string S_ROLEGROUPCODE = "���[���O���[�v�R�[�h";
        private const string S_ROLECATEGORYID = "���[���J�e�S��ID";
        private const string S_ROLECATEGORYSUBID = "���[���T�u�J�e�S��ID";
        private const string S_ROLEITEMID = "���[���A�C�e��ID";
        private const string S_ROLECLASS = "����";
        private const string S_ROLESYSTEMFUNCTION = "����";
        private const string S_ROLELIMITDIV = "���[�������敪";
        private const string S_ROLEGROUPAUTH_GUID = "ROLEGROUPAUTH_GUID";
        private const string S_ROLEGROUPAUTH_TABLE = "ROLEGROUPAUTH_TABLE";

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
        private const string PG_ID = "PMKHN09730U";
        private const string PG_NAME = "���[���O���[�v�����ݒ�}�X�^";

        // Message�֘A��`
        private const string ERR_READ_MSG = "�ǂݍ��݂Ɏ��s���܂����B";
        private const string ERR_DPR_MSG = "���̃V�X�e���@�\�͊��ɓo�^����Ă��܂��B";
        private const string ERR_RDEL_MSG = "�폜�Ɏ��s���܂����B";
        private const string ERR_UPDT_MSG = "�o�^�Ɏ��s���܂����B";
        private const string ERR_RVV_MSG = "�����Ɏ��s���܂����B";
        private const string ERR_800_MSG = "���ɑ��[�����X�V����Ă��܂�";
        private const string ERR_801_MSG = "���ɑ��[�����폜����Ă��܂�";
        private const string SDC_RDEL_MSG = "�}�X�^����폜����Ă��܂�";

        private bool flag = false;

        private string roleGroupCode;
        private string roleCategoryID;
        private string roleCategorySubID;
        private string roleItemID;

        // ���j���[��`�擾���ʊi�[�p
        private DataSet dsSystemProducts = new DataSet();
        # endregion

        # region ��Constructor
        /// <summary>
        /// ���[���O���[�v�����ݒ�}�X�^ �t�H�[���N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���[���O���[�v�����ݒ�}�X�^ �t�H�[���N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer : 30746 ���� ��</br>
        /// <br>Date       : 2013/02/18</br>
        /// </remarks>
        public PMKHN09730UA()
        {
            InitializeComponent();

            // ���j���[��`�t�@�C���ǂݍ���
            ReadSfNetMenuNavigator readSfNetMenuNavigator = new ReadSfNetMenuNavigator();
            int status = readSfNetMenuNavigator.ReadSfNetMenuNavigatorXML(out dsSystemProducts);

            // �f�[�^�Z�b�g����\�z����
            DataSetColumnConstruction();

            // �v���p�e�B�����l�ݒ�
            this._canPrint = false;
            this._canLogicalDeleteDataExtraction = true;
            this._canClose = true;
            this._canNew = true;
            this._canDelete = true;
            this._mainGridTitle = "���[���O���[�v";
            this._detailsGridTitle = "���[���O���[�v�ʌ���";
            this._defaultGridDisplayLayout = MGridDisplayLayout.Vertical;
            this._mainDataIndex = -1;
            this._detailsDataIndex = -1;
            this._targetTableName = "";
            this._mainGridIcon = null;
            this._detailsGridIcon = null;

            // �K�C�h�{�^���̉摜�C���[�W�ǉ�
            this.buttonSystemFuncGuide.Appearance.Image
                = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];

            //  ��ƃR�[�h���擾����
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            // �ϐ�������
            this._roleGroupNameStAcs = new RoleGroupNameStAcs();
            this._roleGroupAuthAcs = new RoleGroupAuthAcs();

            this._roleGroupAuth = new RoleGroupAuth();
            this._roleGroupAuthClone = new RoleGroupAuth();

            this._totalCount = 0;
            this._roleGroupNameTable = new Hashtable();
            this._roleGroupAuthTable = new Hashtable();
            this._roleGroupAuthCloneTable = new Hashtable();

            // Grid��IndexBuffer�i�[�p�ϐ�������
            this._mainIndexBuffer = -2;
            this._detailsIndexBuffer = -2;

        }

        /// <summary>
        /// ���[���O���[�v�����ݒ�}�X�^ �t�H�[���N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���[���O���[�v�����ݒ�}�X�^ �t�H�[���N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer : 30746 ���� ��</br>
        /// <br>Date       : 2013/02/18</br>
        /// </remarks>
        public PMKHN09730UA(string roleGroupCode, string roleCategoryID, string roleCategorySubID, string roleItemID)
        {
            InitializeComponent();

            this.roleGroupCode = roleGroupCode;
            this.roleCategoryID = roleCategoryID;
            this.roleCategorySubID = roleCategorySubID;
            this.roleItemID = roleItemID;

            // �K�C�h�{�^���̉摜�C���[�W�ǉ�
            this.buttonSystemFuncGuide.Appearance.Image
                = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];

            //  ��ƃR�[�h���擾����
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            this.txtRoleGroupCode.ReadOnly = false;
            this.txtRoleGroupCode.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));

            // �ϐ�������
            this._roleGroupNameStAcs = new RoleGroupNameStAcs();
            this._roleGroupAuthAcs = new RoleGroupAuthAcs();

            this._roleGroupAuth = new RoleGroupAuth();
            this._roleGroupAuthClone = new RoleGroupAuth();

            this._targetTableName = S_ROLEGROUPAUTH_TABLE;

            // Grid��IndexBuffer�i�[�p�ϐ�������
            this._mainDataIndex = -2;
            this._detailsDataIndex = -2;

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
            System.Windows.Forms.Application.Run(new PMKHN09730UA());
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
        /// <br>Programmer : 30746 ���� ��</br>
        /// <br>Date       : 2013/02/18</br>
        /// </remarks>
        public bool[] GetCanLogicalDeleteDataExtractionList()
        {
            bool[] blRet = new bool[2];
            blRet[0] = true;
            blRet[1] = false;
            return blRet;
        }

        /// <summary>
        /// �O���b�h�^�C�g�����X�g�擾����
        /// </summary>
        /// <returns>�O���b�h�^�C�g�����X�g</returns>
        /// <remarks>
        /// <br>Note       : �O���b�h�̃^�C�g����z��Ŏ擾���܂��B</br>
        /// <br>Programmer : 30746 ���� ��</br>
        /// <br>Date       : 2013/02/18</br>
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
        /// <br>Programmer : 30746 ���� ��</br>
        /// <br>Date       : 2013/02/18</br>
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
        /// <br>Programmer : 30746 ���� ��</br>
        /// <br>Date       : 2013/02/18</br>
        /// </remarks>
        public bool[] GetDefaultAutoFillToGridColumnList()
        {
            bool[] blRet = new bool[2];
            blRet[0] = false;
            blRet[1] = true;
            return blRet;
        }

        /// <summary>
        /// �f�[�^�e�[�u���̑I���f�[�^�C���f�b�N�X���X�g�ݒ菈��
        /// </summary>
        /// <param name="indexList">�f�[�^�e�[�u���̑I���f�[�^�C���f�b�N�X���X�g</param>
        /// <remarks>
        /// <br>Note       : �f�[�^�e�[�u���̑I���f�[�^�C���f�b�N�X���X�g��ݒ肵�܂��B</br>
        /// <br>Programmer : 30746 ���� ��</br>
        /// <br>Date       : 2013/02/18</br>
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
        /// <br>Programmer : 30746 ���� ��</br>
        /// <br>Date       : 2013/02/18</br>
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
        /// <br>Programmer : 30746 ���� ��</br>
        /// <br>Date       : 2013/02/18</br>
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
        /// <br>Programmer : 30746 ���� ��</br>
        /// <br>Date       : 2013/02/18</br>
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
        /// <br>Programmer : 30746 ���� ��</br>
        /// <br>Date       : 2013/02/18</br>
        /// </remarks>
        /// 
        public void GetBindDataSet(ref DataSet bindDataSet, ref string[] tableName)
        {
            // �O���b�h�\���p�f�[�^�Z�b�g��ݒ�
            bindDataSet = this.Bind_DataSet;

            // �Q�̃e�[�u�����̂̐ݒ�
            string[] strRet = new string[2];
            strRet[0] = I_ROLEGROUPNAME_TABLE;
            strRet[1] = S_ROLEGROUPAUTH_TABLE;
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
        /// <br>Programmer : 30746 ���� ��</br>
        /// <br>Date       : 2013/02/18</br>
        /// </remarks>
        public int Search(ref int totalCount, int readCount)
        {
            int status = 0;
            ArrayList roleGroupNameMntretList = null;

            if (readCount == 0)
            {
                // ���o�Ώی�����0�̏ꍇ�͑S�����o�����s����
                status = this._roleGroupNameStAcs.SearchAll(out roleGroupNameMntretList, this._enterpriseCode);

                this._totalCount = roleGroupNameMntretList.Count;
            }

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        // �擾�������[���O���[�v�N���X���f�[�^�Z�b�g�֓W�J����
                        int index = 0;
                        foreach (RoleGroupNameSt roleGroupNameStMnt in roleGroupNameMntretList)
                        {
                            // ���[���O���[�v�N���X�f�[�^�Z�b�g�W�J����
                            RoleGroupNameMntToDataSet(roleGroupNameStMnt.Clone(), index);
                            ++index;
                        }

                        break;
                    }
                // -- ADD 2013/03/06 --------------------------------->>>
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    {
                        TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_EXCLAMATION,
                            this.Name,
                            "���[���O���[�v���̂��o�^����Ă��܂���B\n��ʂ���x���āA���[���O���[�v���̐ݒ肩���ɓo�^���s���ĉ������B",
                            -1,
                            MessageBoxButtons.OK);
                        break;

                    }
                // -- ADD 2013/03/06 ---------------------------------<<<
                default:
                    {
                        // �T�[�`���� ���[���O���[�v���̃}�X�^�ǂݍ��ݎ��s
                        TMsgDisp.Show(
                            this,                                           // �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_STOP,                    // �G���[���x��
                            PG_ID,                                          // �A�Z���u���h�c�܂��̓N���X�h�c
                            PG_NAME,                                        // �v���O��������
                            "Search",                                       // ��������
                            TMsgDisp.OPE_GET,                               // �I�y���[�V����
                            "���[���O���[�v���̓ǂݍ��݂Ɏ��s���܂����B", // �\�����郁�b�Z�[�W
                            status,                                         // �X�e�[�^�X�l
                            this._roleGroupAuthAcs,                         // �G���[�����������I�u�W�F�N�g
                            MessageBoxButtons.OK,                           // �\������{�^��
                            MessageBoxDefaultButton.Button1);               // �����\���{�^��

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
        /// <br>Programmer : 30746 ���� ��</br>
        /// <br>Date       : 2013/02/18</br>
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
        /// <br>Programmer : 30746 ���� ��</br>
        /// <br>Date       : 2013/02/18</br>
        /// </remarks>
        public int DetailsDataSearch(ref int totalCount, int readCount)
        {
            int status = 0;
            ArrayList arrRoleGroupAuth = new ArrayList();

            // ���ݕێ����Ă��郍�[���O���[�v�����f�[�^���N���A����
            this.Bind_DataSet.Tables[S_ROLEGROUPAUTH_TABLE].Rows.Clear();
            this._roleGroupAuthTable.Clear();

            // readCount�����̏ꍇ�A�����I��
            if (readCount < 0) return 0;

            // �I������Ă��郍�[���O���[�v�f�[�^���擾����
            string guid = (string)this.Bind_DataSet.Tables[I_ROLEGROUPNAME_TABLE].Rows[this._mainDataIndex][I_ROLEGROUPNAME_GUID];
            RoleGroupNameSt roleGroupNameSt = (RoleGroupNameSt)this._roleGroupNameTable[guid];

            // ���[���O���[�v�R�[�h�w�� ���[���O���[�v�������������i�_���폜�܂ށj
            status = this._roleGroupAuthAcs.SearchAll(roleGroupNameSt.RoleGroupCode, out arrRoleGroupAuth, this._enterpriseCode);

            // ���[���O���[�v�����̃��R�[�h��ێ�
            CacheRoleGroupAuthList(roleGroupNameSt.RoleGroupCode, arrRoleGroupAuth);

            this._totalCount = arrRoleGroupAuth.Count;

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                    {
                        // �擾�������[���O���[�v�����N���X���f�[�^�Z�b�g�֓W�J����
                        int index = 0;
                        foreach (RoleGroupAuth roleGroupAuth in arrRoleGroupAuth)
                        {
                            // ���[���O���[�v�����N���X�f�[�^�Z�b�g�W�J����
                            RoleGroupAuthToDataSet(roleGroupAuth.Clone(), index);
                            ++index;
                        }
                        // ���[���O���[�v�����\�[�g
                        RoleGroupAuthSort();

                        break;
                    }
                default:
                    {
                        // ���׃f�[�^��������
                        TMsgDisp.Show(
                            this,                                               // �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_STOP,                        // �G���[���x��
                            PG_ID,                                              // �A�Z���u���h�c�܂��̓N���X�h�c
                            PG_NAME,                                            // �v���O��������
                            "DetailsDataSearch",                                // ��������
                            TMsgDisp.OPE_GET,                                   // �I�y���[�V����
                            "���[���O���[�v�������̓ǂݍ��݂Ɏ��s���܂����B", // �\�����郁�b�Z�[�W
                            status,                                             // �X�e�[�^�X�l
                            this._roleGroupAuthAcs,                             // �G���[�����������I�u�W�F�N�g
                            MessageBoxButtons.OK,                               // �\������{�^��
                            MessageBoxDefaultButton.Button1);                   // �����\���{�^��

                        break;
                    }
            }

            totalCount = this._totalCount;

            return status;
        }

        /// <summary>
        /// ���׃l�N�X�g�f�[�^��������
        /// </summary>
        /// <param name="readCount">���o�Ώی���</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �w�肵���������̃l�N�X�g�f�[�^���������܂��B</br>
        /// <br>Programmer : 30746 ���� ��</br>
        /// <br>Date       : 2013/02/18</br>
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
        /// <br>Programmer : 30746 ���� ��</br>
        /// <br>Date       : 2013/02/18</br>
        /// </remarks>
        public int Delete()
        {
            int status = 0;
            string guid = (string)this.Bind_DataSet.Tables[S_ROLEGROUPAUTH_TABLE].Rows[this._detailsDataIndex][S_ROLEGROUPAUTH_GUID];
            RoleGroupAuth roleGroupAuth = ((RoleGroupAuth)this._roleGroupAuthTable[guid]).Clone();

            status = this._roleGroupAuthAcs.LogicalDelete(ref roleGroupAuth);
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
                        ExclusiveTransaction(status, TMsgDisp.OPE_DELETE, this._roleGroupAuthAcs);
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
                            this,                               // �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_STOPDISP,    // �G���[���x��
                            PG_ID,                              // �A�Z���u���h�c�܂��̓N���X�h�c
                            PG_NAME,                            // �v���O��������
                            "Delete",                           // ��������
                            TMsgDisp.OPE_HIDE,                  // �I�y���[�V����
                            ERR_RDEL_MSG,                       // �\�����郁�b�Z�[�W 
                            status,                             // �X�e�[�^�X�l
                            this._roleGroupAuthAcs,             // �G���[�����������I�u�W�F�N�g
                            MessageBoxButtons.OK,               // �\������{�^��
                            MessageBoxDefaultButton.Button1);   // �����\���{�^��

                        return status;
                    }
            }

            // �f�[�^�Z�b�g�W�J����
            RoleGroupAuthToDataSet(roleGroupAuth.Clone(), this._detailsDataIndex);

            // ���[���O���[�v�����\�[�g
            RoleGroupAuthSort();

            return status;
        }

        /// <summary>
        /// �������
        /// </summary>
        /// <param></param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ����@�\�����ׁ̈A�������B</br>
        /// <br>Programmer : 30746 ���� ��</br>
        /// <br>Date       : 2013/02/18</br>
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
        /// <br>Programmer : 30746 ���� ��</br>
        /// <br>Date       : 2013/02/18</br>
        /// </remarks>
        public void GetAppearanceTable(out Hashtable[] appearanceTable)
        {
            // ���C���O���b�h
            Hashtable mainAppearanceTable = new Hashtable();

            // �폜��
            mainAppearanceTable.Add(S_DELETEDATE, new GridColAppearance(MGridColDispType.DeletionDataBoth, ContentAlignment.MiddleLeft, "", Color.Red));
            // ���[���O���[�v�R�[�h
            mainAppearanceTable.Add(I_ROLEGROUPCODE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            // ���[���O���[�v����
            mainAppearanceTable.Add(I_ROELGROUPNAME, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // ���[���O���[�v���GUID
            mainAppearanceTable.Add(I_ROLEGROUPNAME_GUID, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));

            // �T�u�O���b�h
            Hashtable detailsAppearanceTable = new Hashtable();

            // �폜��
            detailsAppearanceTable.Add(S_DELETEDATE, new GridColAppearance(MGridColDispType.DeletionDataBoth, ContentAlignment.MiddleLeft, "", Color.Red));
            // �\�[�g�L�[   
            detailsAppearanceTable.Add(S_SORTKEY, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
            // ���[���O���[�v�R�[�h
            detailsAppearanceTable.Add(S_ROLEGROUPCODE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            // ���[���J�e�S��ID
            detailsAppearanceTable.Add(S_ROLECATEGORYID, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            // ���[���T�u�J�e�S��ID
            detailsAppearanceTable.Add(S_ROLECATEGORYSUBID, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            // ���[���O���[�v�A�C�e��ID
            detailsAppearanceTable.Add(S_ROLEITEMID, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            // �敪
            detailsAppearanceTable.Add(S_ROLECLASS, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // ����
            detailsAppearanceTable.Add(S_ROLESYSTEMFUNCTION, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // ���[�������敪
            detailsAppearanceTable.Add(S_ROLELIMITDIV, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            // ���[���O���[�v�������GUID
            detailsAppearanceTable.Add(S_ROLEGROUPAUTH_GUID, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));

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
        /// <br>Note       : ���[�U�[���t�H�[����ǂݍ��ނƂ��ɔ������܂��B</br>
        /// <br>Programmer : 30746 ���� ��</br>
        /// <br>Date       : 2013/02/18</br>
        /// </remarks>
        private void PMKHN09730UA_Load(object sender, System.EventArgs e)
        {
            // �A�C�R�����\�[�X�Ǘ��N���X���g�p���āA�A�C�R����\������
            ImageList imageList24 = IconResourceManagement.ImageList24;
            ImageList imageList16 = IconResourceManagement.ImageList16;

            this.buttonOK.ImageList = imageList24;
            this.buttonCancel.ImageList = imageList24;
            this.buttonRevive.ImageList = imageList24;
            this.buttonDelete.ImageList = imageList24;

            this.buttonOK.Appearance.Image = Size24_Index.SAVE;
            this.buttonCancel.Appearance.Image = Size24_Index.CLOSE;
            this.buttonRevive.Appearance.Image = Size24_Index.REVIVAL;
            this.buttonDelete.Appearance.Image = Size24_Index.DELETE;
        }

        /// <summary>
        /// ��ʃN���[�Y�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�f�[�^</param>
        /// <remarks>
        /// <br>Note       : ���[�U�[���t�H�[������悤�Ƃ������ɔ������܂��B</br>
        /// <br>Programmer : 30746 ���� ��</br>
        /// <br>Date       : 2013/02/18</br>
        /// </remarks>
        private void PMKHN09730UA_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // Grid��IndexBuffer�i�[�p�ϐ�������
            this._mainIndexBuffer = -2;
            this._detailsIndexBuffer = -2;

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
        /// <br>Note       : ��ʂ̕\����Ԃ��ς�����Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : 30746 ���� ��</br>
        /// <br>Date       : 2013/02/18</br>
        /// </remarks>
        private void PMKHN09730UA_VisibleChanged(object sender, System.EventArgs e)
        {
            if (!this.flag)
            {
                // �������g����\���ɂȂ����ꍇ�͈ȉ��̏������L�����Z������B
                if (this.Visible == false)
                {
                    // ���C���t���[���A�N�e�B�u��
                    this.Owner.Activate();
                    return;
                }

                if (this._targetTableName == S_ROLEGROUPAUTH_TABLE)
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
        /// <br>Note       : �ۑ��{�^���R���g���[�����N���b�N���ꂽ���ɔ������܂��B</br>
        /// <br>Programmer : 30746 ���� ��</br>
        /// <br>Date       : 2013/02/18</br>
        /// </remarks>
        private void buttonOk_Click(object sender, System.EventArgs e)
        {
            this.buttonOK.Focus();
            if (!SaveProc())
            {
                return;
            }

            if (this.flag)
            {
                this.Close();
            }

            // ��ʔ�\���C�x���g
            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                UnDisplaying(this, me);
            }

            // �V�K���[�h�̏ꍇ�͉�ʂ��I���������ɘA�����͂��\�Ƃ���B
            if (this.lblMode.Text == INSERT_MODE)
            {
                // ��ʂ�������
                this.ScreenClear();

                // ��ʂ��č\�z
                this.ScreenReconstruction();

                // �K�C�h�{�^���Ƀt�H�[�J�X���Z�b�g
                this.buttonSystemFuncGuide.Focus();

            }
            else
            {
                this.DialogResult = DialogResult.OK;

                // Grid��IndexBuffer�i�[�p�ϐ�������
                this._mainIndexBuffer = -2;
                this._detailsIndexBuffer = -2;

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
        /// ����{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�f�[�^</param>
        /// <remarks>
        /// <br>Note       : ����{�^���R���g���[�����N���b�N���ꂽ���ɔ������܂��B</br>
        /// <br>Programmer : 30746 ���� ��</br>
        /// <br>Date       : 2013/02/18</br>
        /// </remarks>
        private void buttonCancel_Click(object sender, System.EventArgs e)
        {
            //�ۑ��m�F
            RoleGroupAuth compareRoleGroupAuth = new RoleGroupAuth();
            compareRoleGroupAuth = this._roleGroupAuthClone.Clone();
            //���݂̉�ʏ����擾����
            DispToRoleGroupAuth(ref compareRoleGroupAuth);

            //�ŏ��Ɏ擾������ʏ��Ɣ�r
            if (!(this._roleGroupAuthClone.Equals(compareRoleGroupAuth)))
            {
                // ��ʏ�񂪕ύX����Ă����ꍇ�́A�ۑ��m�F���b�Z�[�W��\������
                // �ۑ��m�F
                DialogResult res = TMsgDisp.Show(
                    this,                               // �e�E�B���h�E�t�H�[��
                    emErrorLevel.ERR_LEVEL_SAVECONFIRM, // �G���[���x��
                    PG_ID,                              // �A�Z���u���h�c�܂��̓N���X�h�c
                    null,                               // �\�����郁�b�Z�[�W
                    0,                                  // �X�e�[�^�X�l
                    MessageBoxButtons.YesNoCancel);     // �\������{�^��

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
                            this.buttonCancel.Focus();
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
        /// <br>Programmer : 30746 ���� ��</br>
        /// <br>Date       : 2013/02/18</br>
        /// </remarks>
        private void buttonDelete_Click(object sender, System.EventArgs e)
        {
            int status = 0;
            DialogResult result = TMsgDisp.Show(
                this,                                                   // �e�E�B���h�E�t�H�[��
                emErrorLevel.ERR_LEVEL_QUESTION,                        // �G���[���x��
                PG_ID,                                                  // �A�Z���u���h�c�܂��̓N���X�h�c
                "�f�[�^���폜���܂��B" + "\r\n" + "��낵���ł����H",   // �\�����郁�b�Z�[�W 
                0,                                                      // �X�e�[�^�X�l
                MessageBoxButtons.OKCancel,                             // �\������{�^��
                MessageBoxDefaultButton.Button2);                       // �����\���{�^��


            if (result == DialogResult.OK)
            {
                string guid = (string)this.Bind_DataSet.Tables[S_ROLEGROUPAUTH_TABLE].Rows[this._detailsDataIndex][S_ROLEGROUPAUTH_GUID];
                RoleGroupAuth roleGroupAuth = ((RoleGroupAuth)this._roleGroupAuthTable[guid]).Clone();

                status = this._roleGroupAuthAcs.Delete(roleGroupAuth);
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        {
                            this.Bind_DataSet.Tables[S_ROLEGROUPAUTH_TABLE].Rows[this._detailsDataIndex].Delete();
                            this._roleGroupAuthTable.Remove(roleGroupAuth.FileHeaderGuid);
                            break;
                        }
                    case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                        {
                            ExclusiveTransaction(status, TMsgDisp.OPE_DELETE, this._roleGroupAuthAcs);

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
                                this,                                 // �e�E�B���h�E�t�H�[��
                                emErrorLevel.ERR_LEVEL_STOPDISP,      // �G���[���x��
                                PG_ID,                                // �A�Z���u���h�c�܂��̓N���X�h�c
                                PG_NAME,                              // �v���O��������
                                "Delete_Button_Click",                // ��������
                                TMsgDisp.OPE_DELETE,                  // �I�y���[�V����
                                ERR_RDEL_MSG,                         // �\�����郁�b�Z�[�W 
                                status,                               // �X�e�[�^�X�l
                                this._roleGroupAuthAcs,               // �G���[�����������I�u�W�F�N�g
                                MessageBoxButtons.OK,                 // �\������{�^��
                                MessageBoxDefaultButton.Button1);     // �����\���{�^��

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
                this.buttonDelete.Focus();
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
        /// <br>Note       : �����{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : 30746 ���� ��</br>
        /// <br>Date       : 2013/02/18</br>
        /// </remarks>
        private void buttonRevive_Click(object sender, System.EventArgs e)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            string guid = (string)this.Bind_DataSet.Tables[S_ROLEGROUPAUTH_TABLE].Rows[this._detailsDataIndex][S_ROLEGROUPAUTH_GUID];
            RoleGroupAuth roleGroupAuth = ((RoleGroupAuth)this._roleGroupAuthTable[guid]).Clone();

            status = this._roleGroupAuthAcs.Revival(ref roleGroupAuth);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        ExclusiveTransaction(status, TMsgDisp.OPE_UPDATE, this._roleGroupAuthAcs);

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
                            this,                                 // �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_STOPDISP,      // �G���[���x��
                            PG_ID,                                // �A�Z���u���h�c�܂��̓N���X�h�c
                            PG_NAME,                              // �v���O��������
                            "Revive_Button_Click",                // ��������
                            TMsgDisp.OPE_UPDATE,                  // �I�y���[�V����
                            ERR_RVV_MSG,                          // �\�����郁�b�Z�[�W 
                            status,                               // �X�e�[�^�X�l
                            this._roleGroupAuthAcs,               // �G���[�����������I�u�W�F�N�g
                            MessageBoxButtons.OK,                 // �\������{�^��
                            MessageBoxDefaultButton.Button1);     // �����\���{�^��

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

            // �f�[�^�Z�b�g�W�J����
            RoleGroupAuthToDataSet(roleGroupAuth, this._detailsIndexBuffer);

            // ���[���O���[�v�����\�[�g
            RoleGroupAuthSort();

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
        /// �V�X�e���@�\�K�C�h�{�^�������C�x���g
        /// </summary>
        /// <param name="sender">�R���g���[��</param>
        /// <param name="e">�C�x���g�f�[�^</param>
        /// <remarks>
        /// <br>Note       : �V�X�e���@�\�K�C�h�{�^���������̏������s���܂��B</br>
        /// <br>Programmer : 30746 ���� ��</br>
        /// <br>Date       : 2013/02/18</br>
        /// </remarks>
        private void buttonSystemFuncGuide_Click(object sender, EventArgs e)
        {

            PMKHN09730UB fPMKHN09730UB = new PMKHN09730UB(this);
            fPMKHN09730UB.Owner = this;

            fPMKHN09730UB.ShowDialog();

            if (fPMKHN09730UB.DialogResult == DialogResult.OK) this.buttonOK.Focus();

        }

        /// <summary>
        /// Timer.Tick �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note        : �w�肳�ꂽ�Ԋu�̎��Ԃ��o�߂����Ƃ��ɔ������܂��B
        ///                   ���̏����́A�V�X�e�����񋟂���X���b�h �v�[��
        ///                   �X���b�h�Ŏ��s����܂��B</br>
        /// <br>Programmer  : 30746 ���� ��</br>
        /// <br>Date        : 2013/02/18</br>
        /// </remarks>
        private void Initial_Timer_Tick(object sender, System.EventArgs e)
        {
            Initial_Timer.Enabled = false;

            // ��ʍč\�z����
            ScreenReconstruction();
        }

        # endregion

        #region Private Methods

        /// <summary>
        /// ���[���O���[�v�N���X�f�[�^�Z�b�g�W�J����
        /// </summary>
        /// <param name="roleGroupName">���[���O���[�v�N���X</param>
        /// <param name="index">�f�[�^�Z�b�g�֓W�J����C���f�b�N�X</param>
        /// <remarks>
        /// <br>Note       : ���[���O���[�v�N���X���f�[�^�Z�b�g�֊i�[���܂��B</br>
        /// <br>Programmer : 30746 ���� ��</br>
        /// <br>Date       : 2013/02/18</br>
        /// </remarks>
        private void RoleGroupNameMntToDataSet(RoleGroupNameSt roleGroupNameSt, int index)
        {
            if ((index < 0) || (this.Bind_DataSet.Tables[I_ROLEGROUPNAME_TABLE].Rows.Count <= index))
            {
                // �V�K�Ɣ��f���āA�s��ǉ�����
                DataRow dataRow = this.Bind_DataSet.Tables[I_ROLEGROUPNAME_TABLE].NewRow();
                this.Bind_DataSet.Tables[I_ROLEGROUPNAME_TABLE].Rows.Add(dataRow);

                // index���s�̍ŏI�s�ԍ��ɂ���
                index = this.Bind_DataSet.Tables[I_ROLEGROUPNAME_TABLE].Rows.Count - 1;
            }

            // �폜��
            this.Bind_DataSet.Tables[I_ROLEGROUPNAME_TABLE].Rows[index][S_DELETEDATE] = GetDeleteDate(roleGroupNameSt);

            // ���[���O���[�v�R�[�h
            this.Bind_DataSet.Tables[I_ROLEGROUPNAME_TABLE].Rows[index][I_ROLEGROUPCODE] = roleGroupNameSt.RoleGroupCode;

            // ���[���O���[�v��
            this.Bind_DataSet.Tables[I_ROLEGROUPNAME_TABLE].Rows[index][I_ROELGROUPNAME] = roleGroupNameSt.RoleGroupName;

            // ���[���O���[�v���GUID
            this.Bind_DataSet.Tables[I_ROLEGROUPNAME_TABLE].Rows[index][I_ROLEGROUPNAME_GUID] = CreateHashKey(roleGroupNameSt);

            // �n�b�V�������p��GUID�Z�b�g
            this._roleGroupNameTable.Add(CreateHashKey(roleGroupNameSt), roleGroupNameSt);
            if (this._roleGroupNameTable.ContainsKey(CreateHashKey(roleGroupNameSt)) == true)
            {
                this._roleGroupNameTable.Remove(CreateHashKey(roleGroupNameSt));
            }
            this._roleGroupNameTable.Add(CreateHashKey(roleGroupNameSt), roleGroupNameSt);
        }

        /// <summary>
        /// ���C���e�[�u���̍폜�����擾���܂��B
        /// </summary>
        /// <param name="roleGroupName">���[���O���[�v�N���X</param>
        /// <returns>���C���e�[�u���̍폜���i�폜����Ă��Ȃ��ꍇ�A<c>string.Empty</c>��Ԃ��܂��B�j</returns>
        private string GetDeleteDate(RoleGroupNameSt roleGroupNameSt)
        {
            if (roleGroupNameSt.LogicalDeleteCode.Equals(0))
            {
                return string.Empty;
            }
            else
            {
                return roleGroupNameSt.UpdateDateTimeJpInFormal;
            }
        }

        #region <���[���O���[�v�����̃L���b�V��/>

        /// <summary>���[���O���[�v�����̃L���b�V��</summary>
        /// <remarks>�L�[�F���[���O���[�v�R�[�h</remarks>
        private readonly IDictionary<int, ArrayList> _roleGroupAuthListCacheMap = new Dictionary<int, ArrayList>();
        /// <summary>
        /// ���[���O���[�v�����̃L���b�V�����擾���܂��B
        /// </summary>
        private IDictionary<int, ArrayList> RoleGroupAuthListCacheMap
        {
            get { return _roleGroupAuthListCacheMap; }
        }

        /// <summary>
        /// ���[���O���[�v�������L���b�V�����܂��B
        /// </summary>
        /// <param name="roleGroupCode">���[���O���[�v�R�[�h</param>
        /// <param name="roleGroupAuthList">���[���O���[�v�����̃��R�[�h���X�g</param>
        private void CacheRoleGroupAuthList(
            int roleGroupCode,
            ArrayList roleGroupAuthList
        )
        {
            if (RoleGroupAuthListCacheMap.ContainsKey(roleGroupCode))
            {
                RoleGroupAuthListCacheMap.Remove(roleGroupCode);
            }
            RoleGroupAuthListCacheMap.Add(roleGroupCode, (roleGroupAuthList != null ? roleGroupAuthList : new ArrayList()));
        }

        #endregion

        /// <summary>
        /// ���[���O���[�v�����N���X�f�[�^�Z�b�g�W�J����
        /// </summary>
        /// <param name="roleGroupAuth">���[���O���[�v�����N���X</param>
        /// <param name="index">�f�[�^�Z�b�g�֓W�J����C���f�b�N�X</param>
        /// <remarks>
        /// <br>Note       : ���[���O���[�v�����N���X���f�[�^�Z�b�g�֊i�[���܂��B</br>
        /// <br>Programmer : 30746 ���� ��</br>
        /// <br>Date       : 2013/02/18</br>
        /// </remarks>
        private void RoleGroupAuthToDataSet(RoleGroupAuth roleGroupAuth, int index)
        {
            if ((index < 0) || (this.Bind_DataSet.Tables[S_ROLEGROUPAUTH_TABLE].Rows.Count <= index))
            {
                // �V�K�Ɣ��f���āA�s��ǉ�����
                DataRow dataRow = this.Bind_DataSet.Tables[S_ROLEGROUPAUTH_TABLE].NewRow();
                this.Bind_DataSet.Tables[S_ROLEGROUPAUTH_TABLE].Rows.Add(dataRow);

                // index���s�̍ŏI�s�ԍ�����
                index = this.Bind_DataSet.Tables[S_ROLEGROUPAUTH_TABLE].Rows.Count - 1;
            }

            // �폜��
            if (roleGroupAuth.LogicalDeleteCode == 0)
            {
                this.Bind_DataSet.Tables[S_ROLEGROUPAUTH_TABLE].Rows[index][S_DELETEDATE] = "";
            }
            else
            {
                this.Bind_DataSet.Tables[S_ROLEGROUPAUTH_TABLE].Rows[index][S_DELETEDATE] = TDateTime.DateTimeToString("ggYY/MM/DD", roleGroupAuth.UpdateDateTime);
            }

            // ���[���O���[�v�R�[�h
            this.Bind_DataSet.Tables[S_ROLEGROUPAUTH_TABLE].Rows[index][S_ROLEGROUPCODE] = roleGroupAuth.RoleGroupCode;

            // ���[���J�e�S��ID
            this.Bind_DataSet.Tables[S_ROLEGROUPAUTH_TABLE].Rows[index][S_ROLECATEGORYID] = roleGroupAuth.RoleCategoryID.ToString();

            // ���[���T�u�J�e�S��ID
            this.Bind_DataSet.Tables[S_ROLEGROUPAUTH_TABLE].Rows[index][S_ROLECATEGORYSUBID] = roleGroupAuth.RoleCategorySubID.ToString();

            // ���[���A�C�e��ID
            this.Bind_DataSet.Tables[S_ROLEGROUPAUTH_TABLE].Rows[index][S_ROLEITEMID] = roleGroupAuth.RoleItemID.ToString();

            // ���[�������敪
            this.Bind_DataSet.Tables[S_ROLEGROUPAUTH_TABLE].Rows[index][S_ROLELIMITDIV] = roleGroupAuth.RoleLimitDiv.ToString();

            // ���[���O���[�v�������GUID
            this.Bind_DataSet.Tables[S_ROLEGROUPAUTH_TABLE].Rows[index][S_ROLEGROUPAUTH_GUID] = CreateHashKey(roleGroupAuth);

            // ���ށA���́A�\�[�g�L�[���擾
            string[] ClassAndName = new string[3];
            int status = GetClassAndName(dsSystemProducts, roleGroupAuth.RoleCategoryID, roleGroupAuth.RoleCategorySubID, roleGroupAuth.RoleItemID, out ClassAndName);

            this.Bind_DataSet.Tables[S_ROLEGROUPAUTH_TABLE].Rows[index][S_ROLECLASS] = ClassAndName[0];             // ����
            this.Bind_DataSet.Tables[S_ROLEGROUPAUTH_TABLE].Rows[index][S_ROLESYSTEMFUNCTION] = ClassAndName[1];    // ����
            this.Bind_DataSet.Tables[S_ROLEGROUPAUTH_TABLE].Rows[index][S_SORTKEY] = ClassAndName[2];               // �\�[�g�L�[

            // �n�b�V�������p��GUID�Z�b�g
            if (this._roleGroupAuthTable.ContainsKey(CreateHashKey(roleGroupAuth)) == true)
            {
                this._roleGroupAuthTable.Remove(CreateHashKey(roleGroupAuth));
            }
            this._roleGroupAuthTable.Add(CreateHashKey(roleGroupAuth), roleGroupAuth);
        }

        /// <summary>
        /// ���[���O���[�v�����ݒ�\�[�g
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���[���O���[�v�����ݒ���L�[���Ƀ\�[�g���܂��B</br>
        /// <br>Programmer : 30746 ���� ��</br>
        /// <br>Date       : 2013/02/18</br>
        /// </remarks>
        private void RoleGroupAuthSort()
        {
            if (this.Bind_DataSet.Tables[S_ROLEGROUPAUTH_TABLE].Rows.Count > 0)
            {
                // �f�[�^�Z�b�g�𕡐�
                DataSet Bind_DataSetWk = Bind_DataSet.Copy();

                // ���̃f�[�^�Z�b�g���N���A
                this.Bind_DataSet.Tables[S_ROLEGROUPAUTH_TABLE].Clear();

                // �f�[�^�Z�b�g���\�[�g�L�[���ɍč\�z
                DataRow[] dataRows = Bind_DataSetWk.Tables[S_ROLEGROUPAUTH_TABLE].Select("", S_SORTKEY);
                foreach (DataRow dataRow in dataRows)
                {
                    this.Bind_DataSet.Tables[S_ROLEGROUPAUTH_TABLE].ImportRow(dataRow);
                }
            }
        }

        /// <summary>
        /// ���[���O���[�v�����ݒ�}�X�^ �N���X��ʓW�J����
        /// </summary>
        /// <param name="roleGroupAuth">���[���O���[�v�����ݒ�}�X�^ �I�u�W�F�N�g</param>
        /// <remarks>
        /// <br>Note       : ���[���O���[�v�����ݒ�}�X�^ �I�u�W�F�N�g�����ʂɃf�[�^��W�J���܂��B</br>
        /// <br>Programmer : 30746 ���� ��</br>
        /// <br>Date       : 2013/02/18</br>
        /// </remarks>
        private void RoleGroupAuthToScreen(RoleGroupAuth roleGroupAuth)
        {
            this.txtRoleGroupCode.SetInt(roleGroupAuth.RoleGroupCode);                      // ���[���O���[�v�R�[�h
            this.txtRoleGroupName.Text = GetRoleGroupName(roleGroupAuth.RoleGroupCode);     // ���[���O���[�v��
            this.txtCategoryID.Text = roleGroupAuth.RoleCategoryID.ToString();              // �J�e�S��ID
            this.txtCategorySubID.Text = roleGroupAuth.RoleCategorySubID.ToString();        // �T�u�J�e�S��ID
            this.txtItemID.Text = roleGroupAuth.RoleItemID.ToString();                      // �A�C�e��ID

            string[] ClassAndName = new string[3];
            int status = GetClassAndName(dsSystemProducts, roleGroupAuth.RoleCategoryID, roleGroupAuth.RoleCategorySubID, roleGroupAuth.RoleItemID, out ClassAndName);
            this.txtSystemFunction.Text = ClassAndName[1];                                  // ����
        }

        /// <summary>
        /// ��ʏ�񃍁[���O���[�v�����ݒ�}�X�^ �N���X�i�[����
        /// </summary>
        /// <param name="roleGroupAuth">���[���O���[�v�����ݒ�}�X�^ �I�u�W�F�N�g</param>
        /// <remarks>
        /// <br>Note       : ��ʏ�񂩂烍�[���O���[�v�����ݒ�}�X�^ �I�u�W�F�N�g�Ƀf�[�^���i�[���܂��B</br>
        /// <br>Programmer : 30746 ���� ��</br>
        /// <br>Date       : 2013/02/18</br>
        /// </remarks>
        private void DispToRoleGroupAuth(ref RoleGroupAuth roleGroupAuth)
        {
            if (roleGroupAuth == null)
            {
                // �V�K�̏ꍇ
                roleGroupAuth = new RoleGroupAuth();
            }

            roleGroupAuth.EnterpriseCode = this._enterpriseCode;                    // ��ƃR�[�h

            roleGroupAuth.RoleGroupCode = this.txtRoleGroupCode.GetInt();           // ���[���O���[�v�R�[�h
            roleGroupAuth.RoleCategoryID = this.txtCategoryID.GetInt();             // �J�e�S��ID
            roleGroupAuth.RoleCategorySubID = this.txtCategorySubID.GetInt();       // �T�u�J�e�S��ID
            roleGroupAuth.RoleItemID = this.txtItemID.GetInt();                     // �A�C�e��ID
            roleGroupAuth.RoleLimitDiv = 1;                                         // ���[�������敪(1:�����Ȃ��Œ�)
        }

        /// <summary>
        /// �f�[�^�Z�b�g����\�z����
        /// </summary>
        /// <remarks>
        /// <br>Note       : DataSet�̗�����\�z���܂��B�f�[�^�Z�b�g�̗��񂪃t���[���̃r���[�p�O���b�h�̗�ɂȂ�܂��B</br>
        /// <br>Programmer : 30746 ���� ��</br>
        /// <br>Date       : 2013/02/18</br>
        /// </remarks>
        private void DataSetColumnConstruction()
        {
            // ���C���e�[�u���̗��`
            DataTable _roleGroupNameDt = new DataTable(I_ROLEGROUPNAME_TABLE);

            _roleGroupNameDt.Columns.Add(S_DELETEDATE, typeof(string));             // �폜��
            _roleGroupNameDt.Columns.Add(I_ROLEGROUPCODE, typeof(string));          // ���[���O���[�v�R�[�h
            _roleGroupNameDt.Columns.Add(I_ROELGROUPNAME, typeof(string));          // ���[���O���[�v��
            _roleGroupNameDt.Columns.Add(I_ROLEGROUPNAME_GUID, typeof(string));     // ���[���O���[�v���GUID

            this.Bind_DataSet.Tables.Add(_roleGroupNameDt);

            // �T�u�e�[�u���̗��`
            DataTable _roleGroupAuthDt = new DataTable(S_ROLEGROUPAUTH_TABLE);

            _roleGroupAuthDt.Columns.Add(S_DELETEDATE, typeof(string));             // �폜��
            _roleGroupAuthDt.Columns.Add(S_SORTKEY, typeof(string));                // �\�[�g�L�[
            _roleGroupAuthDt.Columns.Add(S_ROLEGROUPCODE, typeof(string));          // ���[���O���[�v�R�[�h
            _roleGroupAuthDt.Columns.Add(S_ROLECATEGORYID, typeof(string));         // ���[���J�e�S��ID
            _roleGroupAuthDt.Columns.Add(S_ROLECATEGORYSUBID, typeof(string));      // ���[���T�u�J�e�S��ID
            _roleGroupAuthDt.Columns.Add(S_ROLEITEMID, typeof(string));             // ���[���A�C�e��ID
            _roleGroupAuthDt.Columns.Add(S_ROLECLASS, typeof(string));              // ���[���敪
            _roleGroupAuthDt.Columns.Add(S_ROLESYSTEMFUNCTION, typeof(string));     // �V�X�e���@�\
            _roleGroupAuthDt.Columns.Add(S_ROLELIMITDIV, typeof(string));           // ���[�������敪
            _roleGroupAuthDt.Columns.Add(S_ROLEGROUPAUTH_GUID, typeof(string));     // ���[���O���[�v�����ݒ���GUID

            this.Bind_DataSet.Tables.Add(_roleGroupAuthDt);
        }

        /// <summary>
        /// ��ʍč\�z����
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : ���[�h�Ɋ�Â��ĉ�ʂ̍č\�z���s���܂��B</br>
        /// <br>Programmer : 30746 ���� ��</br>
        /// <br>Date       : 2013/02/18</br>
        /// </remarks>
        private void ScreenReconstruction()
        {
            if (this._detailsDataIndex < 0)
            {
                // �V�K���[�h
                this.lblMode.Text = INSERT_MODE;

                // ���[���O���[�v�����擾
                string roleGroupNameGuid = (string)this.Bind_DataSet.Tables[I_ROLEGROUPNAME_TABLE].Rows[this._mainDataIndex][I_ROLEGROUPNAME_GUID];
                RoleGroupNameSt roleGroupNameSt = (RoleGroupNameSt)this._roleGroupNameTable[roleGroupNameGuid];

                // ���[���O���[�v������ʂɐݒ�
                this.txtRoleGroupCode.SetInt(roleGroupNameSt.RoleGroupCode);
                this.txtRoleGroupName.Text = roleGroupNameSt.RoleGroupName;

                // ��ʓ��͋����䏈��
                ScreenPermissionControl(INSERT_MODE);

                // Frame��Index/Table�o�b�t�@�ێ�
                this._mainIndexBuffer = -2;
                this._detailsIndexBuffer = this._detailsDataIndex;
                this._targetTableBuffer = this._targetTableName;

                //�N���[���쐬
                RoleGroupAuth roleGroupAuth = new RoleGroupAuth();
                this._roleGroupAuthClone = roleGroupAuth.Clone();
                DispToRoleGroupAuth(ref this._roleGroupAuthClone);

                // �t�H�[�J�X�ݒ�
                buttonSystemFuncGuide.Focus();
            }
            else
            {
                // �I�����[���O���[�v�����̏����擾
                string guid = (string)this.Bind_DataSet.Tables[S_ROLEGROUPAUTH_TABLE].Rows[this._detailsDataIndex][S_ROLEGROUPAUTH_GUID];
                RoleGroupAuth roleGroupAuth = (RoleGroupAuth)this._roleGroupAuthTable[guid];

                if (roleGroupAuth.LogicalDeleteCode == 0)
                {
                    // �Q�ƃ��[�h
                    this.lblMode.Text = REFERENCE_MODE;

                    // ��ʓ��͋����䏈��
                    ScreenPermissionControl(REFERENCE_MODE);

                    // ��ʓW�J����
                    RoleGroupAuthToScreen(roleGroupAuth);

                    //�N���[���쐬
                    this._roleGroupAuthClone = roleGroupAuth.Clone();
                    DispToRoleGroupAuth(ref this._roleGroupAuthClone);

                    // �t�H�[�J�X�ݒ�
                    this.buttonCancel.Focus();
                }
                else
                {
                    // �폜���[�h
                    this.lblMode.Text = DELETE_MODE;

                    // ��ʓ��͋����䏈��
                    ScreenPermissionControl(DELETE_MODE);

                    // ��ʓW�J����
                    RoleGroupAuthToScreen(roleGroupAuth);

                    //�N���[���쐬
                    this._roleGroupAuthClone = roleGroupAuth.Clone();
                    DispToRoleGroupAuth(ref this._roleGroupAuthClone);

                    // �t�H�[�J�X�ݒ�
                    this.buttonDelete.Focus();
                }

                // Frame��Index/Table�o�b�t�@�ێ�
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
        /// <br>Programmer : 30746 ���� ��</br>
        /// <br>Date       : 2013/02/18</br>
        /// </remarks>
        private void ScreenPermissionControl(string screenMode)
        {
            // �V�K
            if (screenMode.Equals(INSERT_MODE))
            {
                // �{�^���ݒ�
                this.buttonOK.Visible = true;
                this.buttonDelete.Visible = false;
                this.buttonRevive.Visible = false;
                this.buttonSystemFuncGuide.Visible = true;
                this.buttonSystemFuncGuide.Enabled = true;

                // ���͐ݒ�
                this.txtRoleGroupCode.Enabled = true;
                this.txtSystemFunction.Enabled = true;
            }
            // �X�V
            else if (screenMode.Equals(UPDATE_MODE))
            {
                // �{�^���ݒ�
                this.buttonOK.Visible = true;
                this.buttonDelete.Visible = false;
                this.buttonRevive.Visible = false;
                this.buttonSystemFuncGuide.Visible = true;
                this.buttonSystemFuncGuide.Enabled = false;

                // ���͐ݒ�
                this.txtRoleGroupCode.Enabled = false;
                this.txtSystemFunction.Enabled = true;
            }
            // �폜
            else if (screenMode.Equals(DELETE_MODE))
            {
                // �{�^���ݒ�
                this.buttonOK.Visible = false;
                this.buttonDelete.Visible = true;
                this.buttonRevive.Visible = true;
                this.buttonSystemFuncGuide.Visible = true;
                this.buttonSystemFuncGuide.Enabled = false;

                // ���͐ݒ�
                this.txtRoleGroupCode.Enabled = false;
                this.txtSystemFunction.Enabled = false;
            }
            // �Q��
            else if (screenMode.Equals(REFERENCE_MODE))
            {
                // �{�^���ݒ�
                this.buttonOK.Visible = false;
                this.buttonDelete.Visible = false;
                this.buttonRevive.Visible = false;
                this.buttonSystemFuncGuide.Visible = true;
                this.buttonSystemFuncGuide.Enabled = false;

                // ���͐ݒ�
                this.txtRoleGroupCode.Enabled = false;
                this.txtSystemFunction.Enabled = false;
            }
        }

        /// <summary>
        /// ��ʏ���������
        /// </summary>
        /// <remarks>
        /// <br>Note       : ��ʂ̏��������s���܂��B</br>
        /// <br>Programmer : 30746 ���� ��</br>
        /// <br>Date       : 2013/02/18</br>
        /// </remarks>
        private void ScreenClear()
        {
            this.txtRoleGroupCode.Clear();          // ���[���O���[�v�R�[�h
            this.txtRoleGroupName.Text = "";        // ���[���O���[�v����
            this.txtSystemFunction.Text = "";       // �V�X�e���@�\�R�[�h
            this.txtCategoryID.Text = "";           // �J�e�S��ID
            this.txtCategorySubID.Text = "";        // �T�u�J�e�S��ID
            this.txtItemID.Text = "";               // �A�C�e��ID
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
        /// <br>Programmer : 30746 ���� ��</br>
        /// <br>Date       : 2013/02/18</br>
        /// </remarks>
        private bool ScreenDataCheck(ref Control control, ref string message, string loginID)
        {
            // �V�X�e���@�\
            if (string.IsNullOrEmpty(txtSystemFunction.Text))
            {
                control = this.buttonSystemFuncGuide;
                message = this.lblSystemFunction.Text + "��I�����Ă��������B";
                return false;
            }

            return true;
        }

        /// <summary>
        /// ���[���O���[�v�����ݒ�}�X�^ ���o�^����
        /// </summary>
        /// <returns>�o�^���ʁitrue:OK�^false:NG�j</returns>
        /// <remarks>
        /// <br>Note       : ���[���O���[�v�����ݒ�}�X�^ ���o�^���s���܂��B</br>
        /// <br>Programmer : 30746 ���� ��</br>
        /// <br>Date       : 2013/02/18</br>
        /// </remarks>
        private bool SaveProc()
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            Control control = null;
            string message = null;
            string loginID = "";

            RoleGroupAuth roleGroupAuth = null;

            if (this._detailsDataIndex >= 0)
            {
                // �X�V�Ώۂ̏����擾
                string guid = (string)this.Bind_DataSet.Tables[S_ROLEGROUPAUTH_TABLE].Rows[this._detailsDataIndex][S_ROLEGROUPAUTH_GUID];
                roleGroupAuth = ((RoleGroupAuth)this._roleGroupAuthTable[guid]).Clone();
            }

            // ��ʓ��̓`�F�b�N
            if (!ScreenDataCheck(ref control, ref message, loginID))
            {
                TMsgDisp.Show(
                    this,                               // �e�E�B���h�E�t�H�[��
                    emErrorLevel.ERR_LEVEL_EXCLAMATION, // �G���[���x��
                    PG_ID,                              // �A�Z���u���h�c�܂��̓N���X�h�c
                    message,                            // �\�����郁�b�Z�[�W 
                    0,                                  // �X�e�[�^�X�l
                    MessageBoxButtons.OK);              // �\������{�^��

                control.Focus();
                return false;
            }
            // ��ʏ��������N���X�ɐݒ�
            this.DispToRoleGroupAuth(ref roleGroupAuth);

            // �o�^�^�X�V����
            status = this._roleGroupAuthAcs.Write(ref roleGroupAuth);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_DUPLICATE:
                    {
                        TMsgDisp.Show(
                            this,                               // �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_EXCLAMATION, // �G���[���x��
                            PG_ID,                              // �A�Z���u���h�c�܂��̓N���X�h�c
                            ERR_DPR_MSG,                        // �\�����郁�b�Z�[�W 
                            status,                             // �X�e�[�^�X�l
                            MessageBoxButtons.OK);              // �\������{�^��

                        this.buttonSystemFuncGuide.Focus();
                        return false;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        ExclusiveTransaction(status, TMsgDisp.OPE_UPDATE, this._roleGroupAuthAcs);

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
                            this,                               // �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_STOPDISP,    // �G���[���x��
                            PG_ID,                              // �A�Z���u���h�c�܂��̓N���X�h�c
                            PG_NAME,                            // �v���O��������
                            "SaveProc",                         // ��������
                            TMsgDisp.OPE_UPDATE,                // �I�y���[�V����
                            ERR_UPDT_MSG,                       // �\�����郁�b�Z�[�W 
                            status,                             // �X�e�[�^�X�l
                            this._roleGroupAuthAcs,             // �G���[�����������I�u�W�F�N�g
                            MessageBoxButtons.OK,               // �\������{�^��
                            MessageBoxDefaultButton.Button1);   // �����\���{�^��

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
                // �f�[�^�Z�b�g�W�J����
                RoleGroupAuthToDataSet(roleGroupAuth, this._detailsDataIndex);

                // ���[���O���[�v�����\�[�g
                RoleGroupAuthSort();

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
        /// <br>Programmer : 30746 ���� ��</br>
        /// <br>Date       : 2013/02/18</br>
        /// </remarks>
        private void ExclusiveTransaction(int status, string operation, object erObject)
        {
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    {
                        TMsgDisp.Show(
                            this,                               // �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_EXCLAMATION, // �G���[���x��
                            PG_ID,                              // �A�Z���u���h�c�܂��̓N���X�h�c
                            PG_NAME,                            // �v���O��������
                            "ExclusiveTransaction",             // ��������
                            operation,                          // �I�y���[�V����
                            ERR_800_MSG,                        // �\�����郁�b�Z�[�W 
                            status,                             // �X�e�[�^�X�l
                            erObject,                           // �G���[�����������I�u�W�F�N�g
                            MessageBoxButtons.OK,               // �\������{�^��
                            MessageBoxDefaultButton.Button1);   // �����\���{�^��
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        TMsgDisp.Show(
                            this,                               // �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_EXCLAMATION, // �G���[���x��
                            PG_ID,                              // �A�Z���u���h�c�܂��̓N���X�h�c
                            PG_NAME,                            // �v���O��������
                            "ExclusiveTransaction",             // ��������
                            operation,                          // �I�y���[�V����
                            ERR_801_MSG,                        // �\�����郁�b�Z�[�W 
                            status,                             // �X�e�[�^�X�l
                            erObject,                           // �G���[�����������I�u�W�F�N�g
                            MessageBoxButtons.OK,               // �\������{�^��
                            MessageBoxDefaultButton.Button1);   // �����\���{�^��
                        break;
                    }
            }
        }

        /// <summary>
        /// HashTable�p�L�[�쐬
        /// </summary>
        /// <param name="roleGroupNameSt">RoleGroupNameSt�N���X</param>
        /// <returns>Hash�e�[�u���p�L�[</returns>
        /// <remarks>
        /// <br>Note       : RoleGroupNameSt�N���X����n�b�V���e�[�u���p�̃L�[���쐬���܂��B</br>
        /// <br>Programmer : 30746 ���� ��</br>
        /// <br>Date       : 2013/02/18</br>
        /// </remarks>
        private string CreateHashKey(RoleGroupNameSt roleGroupNameSt)
        {
            return roleGroupNameSt.RoleGroupCode.ToString("d6");
        }

        /// <summary>
        /// HashTable�p�L�[�쐬
        /// </summary>
        /// <param name="roleGroupAuth">RoleGroupAuth�N���X</param>
        /// <returns>Hash�e�[�u���p�L�[</returns>
        /// <remarks>
        /// <br>Note       : RoleGroupAuth�N���X����n�b�V���e�[�u���p�̃L�[���쐬���܂��B</br>
        /// <br>Programmer : 30746 ���� ��</br>
        /// <br>Date       : 2013/02/18</br>
        /// </remarks>
        private string CreateHashKey(RoleGroupAuth roleGroupAuth)
        {
            string strHashKey = roleGroupAuth.RoleCategoryID.ToString("d4") + roleGroupAuth.RoleCategorySubID.ToString("d6") + roleGroupAuth.RoleItemID.ToString();
            return strHashKey;
        }

        /// <summary>
        /// ���[���O���[�v���̎擾����
        /// </summary>
        /// <param name="roleGroupCode">���[���O���[�v�R�[�h</param>
        /// <returns>���[���O���[�v����</returns>
        /// <remarks>
        /// <br>Note       : ���[���O���[�v���̂��擾���܂��B</br>
        /// <br>Programmer : 30746 ���� ��</br>
        /// <br>Date       : 2013/02/18</br>
        /// </remarks>
        private string GetRoleGroupName(int roleGroupCode)
        {
            string roleGroupName = "";

            int status;
            ArrayList roleGroupNameStRetArray;
            RoleGroupNameStAcs roleGroupNameStAcs = new RoleGroupNameStAcs();

            try
            {
                status = roleGroupNameStAcs.SearchAll(out roleGroupNameStRetArray, this._enterpriseCode);
                if (status == 0)
                {
                    if (roleGroupNameStRetArray.Count <= 0)
                    {
                        return roleGroupName;
                    }

                    foreach (RoleGroupNameSt roleGroupNameSt in roleGroupNameStRetArray)
                    {
                        if (roleGroupNameSt.RoleGroupCode == roleGroupCode)
                        {
                            roleGroupName = roleGroupNameSt.RoleGroupName.Trim();
                            return roleGroupName;
                        }
                    }
                }
            }
            catch
            {
                roleGroupName = "";
            }

            return roleGroupName;
        }

        public int GetClassAndName(DataSet dsSystemProducts, int roleCategoryID, int roleCategorySubID, int roleItemID, out string[] ClassAndName)
        {
            string[] wkClassAndName = new string[3];
            string RoleClass = string.Empty;
            string RoleName = string.Empty;
            string SortKeyClass = "0";
            string SortKeyCategoryID = "000";
            string SortKeyCategorySubID = "00";
            string SortKeyItemID = "0";

            if (roleCategoryID != 0)
            {
                RoleClass = "�J�e�S��";

                if (dsSystemProducts.Tables["ProductCategory"].Rows.Count != 0)
                {
                    DataRow[] wkSystemProducts = dsSystemProducts.Tables["ProductCategory"].Select("CategoryID = " + roleCategoryID);

                    if (wkSystemProducts.Length > 0)
                    {
                        RoleName += wkSystemProducts[0].ItemArray[3];
                        SortKeyClass = "1";
                        SortKeyCategoryID = string.Format("{0:D3}", wkSystemProducts[0].ItemArray[2]);
                    }
                }

                if (roleCategorySubID != 0)
                {
                    RoleClass = "�T�u�J�e�S��";

                    if (dsSystemProducts.Tables["ProductSubCategory"].Rows.Count != 0)
                    {
                        DataRow[] wkSystemProducts = dsSystemProducts.Tables["ProductSubCategory"].Select("CategoryID = " + roleCategoryID + " AND CategorySubID = " + roleCategorySubID);

                        if (wkSystemProducts.Length > 0)
                        {
                            RoleName += " - " + wkSystemProducts[0].ItemArray[4];
                            SortKeyClass = "2";
                            SortKeyCategorySubID = string.Format("{0:D2}", wkSystemProducts[0].ItemArray[2]);
                        }
                    }


                    if (roleItemID != 0)
                    {
                        RoleClass = "�A�C�e��";

                        if (dsSystemProducts.Tables["ProductItem"].Rows.Count != 0)
                        {
                            DataRow[] wkSystemProducts = dsSystemProducts.Tables["ProductItem"].Select("CategoryID = " + roleCategoryID + " AND CategorySubID = " + roleCategorySubID + " AND ItemID = " + roleItemID);

                            if (wkSystemProducts.Length > 0)
                            {
                                RoleName += " - " + wkSystemProducts[0].ItemArray[8];
                                SortKeyClass = "3";
                                SortKeyItemID = string.Format("{0:D1}", wkSystemProducts[0].ItemArray[3]);
                            }
                        }
                    }

                }

            }

            RoleName = RoleName.Replace("\\n", "");

            wkClassAndName[0] = RoleClass;
            wkClassAndName[1] = RoleName;
            wkClassAndName[2] = SortKeyClass + SortKeyCategoryID + SortKeyCategorySubID + SortKeyItemID;
            ClassAndName = wkClassAndName;

            return 0;
        }

        #endregion

    }
}
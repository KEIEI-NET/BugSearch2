//**********************************************************************//
// System           :   PM.NS                                           
// Sub System       :                                                   
// Program name     :   ロールグループ権限設定マスタ                    
//                      フォームクラス                                  
//                  :   PMKHN09730U.DLL                                 
// Name Space       :   Broadleaf.Windows.Forms                         
// Programmer       :   30746 高川 悟                                   
// Date             :   2013/02/18                                      
//----------------------------------------------------------------------//
// 管理番号              作成担当 : 長内　数馬
// 修 正 日  2013/03/06  修正内容 : ロール名称設定が存在しない場合のエラーメッセージを修正
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
    /// ロールグループ権限設定マスタ フォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note        : ロールグループ権限設定マスタ情報の設定を行います。
    ///                   IMasterMaintenanceArrayTypeを実装しています。</br>
    /// <br>Programmer  : 30746 高川 悟</br>
    /// <br>Date        : 2013/02/18</br>
    /// </remarks>
    public class PMKHN09730UA : System.Windows.Forms.Form, IMasterMaintenanceArrayType
    {
        # region ※Private Members (Component)

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

        #region ※Windows フォーム デザイナで生成されたコード
        /// <summary>
        /// デザイナ サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディタで変更しないでください。
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
            this.lblRoleGroup.Text = "ロールグループ";
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
            this.lblSystemFunction.Text = "システム機能";
            // 
            // buttonCancel
            // 
            this.buttonCancel.ImageSize = new System.Drawing.Size(24, 24);
            this.buttonCancel.Location = new System.Drawing.Point(506, 123);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(125, 34);
            this.buttonCancel.TabIndex = 11;
            this.buttonCancel.Text = "閉じる(&X)";
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
            this.buttonRevive.Text = "復活(&R)";
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
            this.buttonDelete.Text = "完全削除(&D)";
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
            this.buttonOK.Text = "保存(&S)";
            this.buttonOK.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.buttonOK.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // buttonSystemFuncGuide
            // 
            appearance12.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance12.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.buttonSystemFuncGuide.Appearance = appearance12;
            this.buttonSystemFuncGuide.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
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
            this.txtRoleGroupName.DataText = "あいうえおかきくけこさしすせそたちつてと";
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
            this.txtRoleGroupName.Text = "あいうえおかきくけこさしすせそたちつてと";
            // 
            // lblMessage
            // 
            appearance17.TextVAlignAsString = "Middle";
            this.lblMessage.Appearance = appearance17;
            this.lblMessage.BackColorInternal = System.Drawing.Color.Transparent;
            this.lblMessage.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblMessage.Location = new System.Drawing.Point(12, 11);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(368, 24);
            this.lblMessage.TabIndex = 61;
            this.lblMessage.Text = "業務メニューに表示させない機能のみ登録します";
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
            this.lblMode.Text = "更新モード";
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
            this.txtItemID.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
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
            this.txtCategorySubID.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
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
            this.txtCategoryID.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
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
            this.lblCategoryID.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblCategoryID.Location = new System.Drawing.Point(77, 101);
            this.lblCategoryID.Name = "lblCategoryID";
            this.lblCategoryID.Size = new System.Drawing.Size(156, 24);
            this.lblCategoryID.TabIndex = 73;
            this.lblCategoryID.Text = "←カテゴリID(非表示)";
            this.lblCategoryID.Visible = false;
            // 
            // lblCategorySubID
            // 
            appearance3.TextVAlignAsString = "Middle";
            this.lblCategorySubID.Appearance = appearance3;
            this.lblCategorySubID.BackColorInternal = System.Drawing.Color.Transparent;
            this.lblCategorySubID.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblCategorySubID.Location = new System.Drawing.Point(77, 120);
            this.lblCategorySubID.Name = "lblCategorySubID";
            this.lblCategorySubID.Size = new System.Drawing.Size(156, 24);
            this.lblCategorySubID.TabIndex = 74;
            this.lblCategorySubID.Text = "←サブカテゴリID(非表示)";
            this.lblCategorySubID.Visible = false;
            // 
            // lblItemID
            // 
            appearance19.TextVAlignAsString = "Middle";
            this.lblItemID.Appearance = appearance19;
            this.lblItemID.BackColorInternal = System.Drawing.Color.Transparent;
            this.lblItemID.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblItemID.Location = new System.Drawing.Point(77, 139);
            this.lblItemID.Name = "lblItemID";
            this.lblItemID.Size = new System.Drawing.Size(156, 24);
            this.lblItemID.TabIndex = 75;
            this.lblItemID.Text = "←アイテムID(非表示)";
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
            this.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PMKHN09730UA";
            this.Text = "ロールグループ権限設定";
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

        #region ※Private Members
        private RoleGroupNameStAcs _roleGroupNameStAcs;
        private RoleGroupAuthAcs _roleGroupAuthAcs;

        private RoleGroupAuth _roleGroupAuth;
        private RoleGroupAuth _roleGroupAuthClone;

        private int _totalCount;
        private string _enterpriseCode;
        private Hashtable _roleGroupNameTable;
        private Hashtable _roleGroupAuthTable;
        private Hashtable _roleGroupAuthCloneTable;

        // プロパティ用
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

        // FrameのView用Grid列のKEY情報 (ヘッダのタイトル部となります)
        private const string I_ROLEGROUPCODE = "ロールグループコード";
        private const string I_ROELGROUPNAME = "ロールグループ名称";
        private const string I_ROLEGROUPNAME_GUID = "ROLEGROUPNAME_GUID";
        private const string I_ROLEGROUPNAME_TABLE = "ROLEGROUPNAME_TABLE";

        private const string S_DELETEDATE = "削除日";
        private const string S_SORTKEY = "ソートキー";
        private const string S_ROLEGROUPCODE = "ロールグループコード";
        private const string S_ROLECATEGORYID = "ロールカテゴリID";
        private const string S_ROLECATEGORYSUBID = "ロールサブカテゴリID";
        private const string S_ROLEITEMID = "ロールアイテムID";
        private const string S_ROLECLASS = "分類";
        private const string S_ROLESYSTEMFUNCTION = "名称";
        private const string S_ROLELIMITDIV = "ロール制限区分";
        private const string S_ROLEGROUPAUTH_GUID = "ROLEGROUPAUTH_GUID";
        private const string S_ROLEGROUPAUTH_TABLE = "ROLEGROUPAUTH_TABLE";

        // 編集モード
        private const string INSERT_MODE = "新規モード";
        private const string UPDATE_MODE = "更新モード";
        private const string DELETE_MODE = "削除モード";
        private const string REFERENCE_MODE = "参照モード";

        // GridのIndexBuffer格納用変数
        private int _mainIndexBuffer;
        private int _detailsIndexBuffer;
        private string _targetTableBuffer;

        // アセンブリ情報
        private const string PG_ID = "PMKHN09730U";
        private const string PG_NAME = "ロールグループ権限設定マスタ";

        // Message関連定義
        private const string ERR_READ_MSG = "読み込みに失敗しました。";
        private const string ERR_DPR_MSG = "このシステム機能は既に登録されています。";
        private const string ERR_RDEL_MSG = "削除に失敗しました。";
        private const string ERR_UPDT_MSG = "登録に失敗しました。";
        private const string ERR_RVV_MSG = "復活に失敗しました。";
        private const string ERR_800_MSG = "既に他端末より更新されています";
        private const string ERR_801_MSG = "既に他端末より削除されています";
        private const string SDC_RDEL_MSG = "マスタから削除されています";

        private bool flag = false;

        private string roleGroupCode;
        private string roleCategoryID;
        private string roleCategorySubID;
        private string roleItemID;

        // メニュー定義取得結果格納用
        private DataSet dsSystemProducts = new DataSet();
        # endregion

        # region ※Constructor
        /// <summary>
        /// ロールグループ権限設定マスタ フォームクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : ロールグループ権限設定マスタ フォームクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : 30746 高川 悟</br>
        /// <br>Date       : 2013/02/18</br>
        /// </remarks>
        public PMKHN09730UA()
        {
            InitializeComponent();

            // メニュー定義ファイル読み込み
            ReadSfNetMenuNavigator readSfNetMenuNavigator = new ReadSfNetMenuNavigator();
            int status = readSfNetMenuNavigator.ReadSfNetMenuNavigatorXML(out dsSystemProducts);

            // データセット列情報構築処理
            DataSetColumnConstruction();

            // プロパティ初期値設定
            this._canPrint = false;
            this._canLogicalDeleteDataExtraction = true;
            this._canClose = true;
            this._canNew = true;
            this._canDelete = true;
            this._mainGridTitle = "ロールグループ";
            this._detailsGridTitle = "ロールグループ別権限";
            this._defaultGridDisplayLayout = MGridDisplayLayout.Vertical;
            this._mainDataIndex = -1;
            this._detailsDataIndex = -1;
            this._targetTableName = "";
            this._mainGridIcon = null;
            this._detailsGridIcon = null;

            // ガイドボタンの画像イメージ追加
            this.buttonSystemFuncGuide.Appearance.Image
                = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];

            //  企業コードを取得する
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            // 変数初期化
            this._roleGroupNameStAcs = new RoleGroupNameStAcs();
            this._roleGroupAuthAcs = new RoleGroupAuthAcs();

            this._roleGroupAuth = new RoleGroupAuth();
            this._roleGroupAuthClone = new RoleGroupAuth();

            this._totalCount = 0;
            this._roleGroupNameTable = new Hashtable();
            this._roleGroupAuthTable = new Hashtable();
            this._roleGroupAuthCloneTable = new Hashtable();

            // GridのIndexBuffer格納用変数初期化
            this._mainIndexBuffer = -2;
            this._detailsIndexBuffer = -2;

        }

        /// <summary>
        /// ロールグループ権限設定マスタ フォームクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : ロールグループ権限設定マスタ フォームクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : 30746 高川 悟</br>
        /// <br>Date       : 2013/02/18</br>
        /// </remarks>
        public PMKHN09730UA(string roleGroupCode, string roleCategoryID, string roleCategorySubID, string roleItemID)
        {
            InitializeComponent();

            this.roleGroupCode = roleGroupCode;
            this.roleCategoryID = roleCategoryID;
            this.roleCategorySubID = roleCategorySubID;
            this.roleItemID = roleItemID;

            // ガイドボタンの画像イメージ追加
            this.buttonSystemFuncGuide.Appearance.Image
                = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];

            //  企業コードを取得する
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            this.txtRoleGroupCode.ReadOnly = false;
            this.txtRoleGroupCode.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));

            // 変数初期化
            this._roleGroupNameStAcs = new RoleGroupNameStAcs();
            this._roleGroupAuthAcs = new RoleGroupAuthAcs();

            this._roleGroupAuth = new RoleGroupAuth();
            this._roleGroupAuthClone = new RoleGroupAuth();

            this._targetTableName = S_ROLEGROUPAUTH_TABLE;

            // GridのIndexBuffer格納用変数初期化
            this._mainDataIndex = -2;
            this._detailsDataIndex = -2;

        }
        # endregion

        # region ※Dispose
        /// <summary>
        /// 使用されているリソースに後処理を実行します。
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

        # region ※Main
        /// <summary>メイン処理</summary>
        /// <value></value>
        /// <remarks>アプリケーションのメイン エントリ ポイントです。</remarks>
        [STAThread]
        static void Main()
        {
            System.Windows.Forms.Application.Run(new PMKHN09730UA());
        }
        # endregion

        # region Events
        /// <summary>画面非表示イベント</summary>
        /// <remarks>画面が非表示状態になった際に発生します。</remarks>
        public event MasterMaintenanceArrayTypeUnDisplayingEventHandler UnDisplaying;
        # endregion

        # region ※Properties
        /// <summary>印刷可能設定プロパティ</summary>
        /// <value>印刷可能かどうかの設定を取得します。</value>
        public bool CanPrint
        {
            get { return this._canPrint; }
        }

        /// <summary>画面終了設定プロパティ</summary>
        /// <value>画面クローズを許可するかどうかの設定を取得または設定します。</value>
        /// <remarks>falseの場合は、画面を閉じる際、CloseではなくHide(非表示)を実行します。</remarks>
        public bool CanClose
        {
            get { return this._canClose; }
            set { this._canClose = value; }
        }

        /// <summary>論理削除データ抽出可能設定プロパティ</summary>
        /// <value>論理削除データの抽出が可能かどうかの設定を取得します。</value>
        public bool CanLogicalDeleteDataExtraction
        {
            get
            {
                return this._canLogicalDeleteDataExtraction;
            }
        }

        /// <summary>新規登録可能設定プロパティ</summary>
        /// <value>新規登録が可能かどうかの設定を取得します。</value>
        public bool CanNew
        {
            get { return this._canNew; }
        }

        /// <summary>削除可能設定プロパティ</summary>
        /// <value>削除が可能かどうかの設定を取得します。</value>
        public bool CanDelete
        {
            get { return this._canDelete; }
        }

        /// <summary>グリッドのデフォルト表示位置プロパティ</summary>
        /// <value>グリッドのデフォルト表示位置を取得します。</value>
        public MGridDisplayLayout DefaultGridDisplayLayout
        {
            get { return this._defaultGridDisplayLayout; }
        }

        /// <summary>操作対象データテーブル名称プロパティ</summary>
        /// <value>捜査対象データのテーブル名称を取得または設定します。</value>
        public string TargetTableName
        {
            get { return this._targetTableName; }
            set { this._targetTableName = value; }
        }
        # endregion

        # region ※Public Methods

        /// <summary>
        /// 論理削除データ抽出可能設定リスト取得処理
        /// </summary>
        /// <returns>論理削除データ抽出可能設定リスト</returns>
        /// <remarks>
        /// <br>Note       : 論理削除データの抽出が可能かどうかの設定を配列で取得します。</br>
        /// <br>Programmer : 30746 高川 悟</br>
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
        /// グリッドタイトルリスト取得処理
        /// </summary>
        /// <returns>グリッドタイトルリスト</returns>
        /// <remarks>
        /// <br>Note       : グリッドのタイトルを配列で取得します。</br>
        /// <br>Programmer : 30746 高川 悟</br>
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
        /// グリッドアイコンリスト取得処理
        /// </summary>
        /// <returns>グリッドアイコンリスト</returns>
        /// <remarks>
        /// <br>Note       : グリッドのアイコンを配列で取得します。</br>
        /// <br>Programmer : 30746 高川 悟</br>
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
        /// グリッド列のサイズの自動調整のデフォルト値リスト取得処理
        /// </summary>
        /// <returns>グリッド列のサイズの自動調整のデフォルト値リスト</returns>
        /// <remarks>
        /// <br>Note       : グリッド列のサイズの自動調整チェックボックスのチェック有無のデフォルト値を配列で取得します。</br>
        /// <br>Programmer : 30746 高川 悟</br>
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
        /// データテーブルの選択データインデックスリスト設定処理
        /// </summary>
        /// <param name="indexList">データテーブルの選択データインデックスリスト</param>
        /// <remarks>
        /// <br>Note       : データテーブルの選択データインデックスリストを設定します。</br>
        /// <br>Programmer : 30746 高川 悟</br>
        /// <br>Date       : 2013/02/18</br>
        /// </remarks>
        public void SetDataIndexList(int[] indexList)
        {
            int[] intVal = indexList;
            this._mainDataIndex = intVal[0];
            this._detailsDataIndex = intVal[1];
        }

        /// <summary>
        /// 新規ボタンの有効設定リスト取得処理
        /// </summary>
        /// <returns>新規ボタンの有効設定リスト</returns>
        /// <remarks>
        /// <br>Note       : 新規ボタンの有効設定リストを取得します。</br>
        /// <br>Programmer : 30746 高川 悟</br>
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
        /// 修正ボタンの有効設定リスト取得処理
        /// </summary>
        /// <returns>修正ボタンの有効設定リスト</returns>
        /// <remarks>
        /// <br>Note       : 修正ボタンの有効設定リストを取得します。</br>
        /// <br>Programmer : 30746 高川 悟</br>
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
        /// 削除ボタンの有効設定リスト取得処理
        /// </summary>
        /// <returns>削除ボタンの有効設定リスト</returns>
        /// <remarks>
        /// <br>Note       : 削除ボタンの有効設定リストを取得します。</br>
        /// <br>Programmer : 30746 高川 悟</br>
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
        /// バインドデータセット取得処理
        /// </summary>
        /// <param name="bindDataSet">グリッド表示用データセット</param>
        /// <param name="tableName">テーブル名称</param>
        /// <remarks>
        /// <br>Note       : グリッドにバインドさせるデータセットを取得します。</br>
        /// <br>Programmer : 30746 高川 悟</br>
        /// <br>Date       : 2013/02/18</br>
        /// </remarks>
        /// 
        public void GetBindDataSet(ref DataSet bindDataSet, ref string[] tableName)
        {
            // グリッド表示用データセットを設定
            bindDataSet = this.Bind_DataSet;

            // ２つのテーブル名称の設定
            string[] strRet = new string[2];
            strRet[0] = I_ROLEGROUPNAME_TABLE;
            strRet[1] = S_ROLEGROUPAUTH_TABLE;
            tableName = strRet;
        }

        /// <summary>
        /// データ検索処理
        /// </summary>
        /// <param name="totalCount">全該当件数</param>
        /// <param name="readCount">抽出対象件数</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 先頭から指定件数分のデータを検索し、抽出結果を展開したDataSetと全該当件数を返します。</br>
        /// <br>Programmer : 30746 高川 悟</br>
        /// <br>Date       : 2013/02/18</br>
        /// </remarks>
        public int Search(ref int totalCount, int readCount)
        {
            int status = 0;
            ArrayList roleGroupNameMntretList = null;

            if (readCount == 0)
            {
                // 抽出対象件数が0の場合は全件抽出を実行する
                status = this._roleGroupNameStAcs.SearchAll(out roleGroupNameMntretList, this._enterpriseCode);

                this._totalCount = roleGroupNameMntretList.Count;
            }

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        // 取得したロールグループクラスをデータセットへ展開する
                        int index = 0;
                        foreach (RoleGroupNameSt roleGroupNameStMnt in roleGroupNameMntretList)
                        {
                            // ロールグループクラスデータセット展開処理
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
                            "ロールグループ名称が登録されていません。\n画面を一度閉じて、ロールグループ名称設定から先に登録を行って下さい。",
                            -1,
                            MessageBoxButtons.OK);
                        break;

                    }
                // -- ADD 2013/03/06 ---------------------------------<<<
                default:
                    {
                        // サーチ結果 ロールグループ名称マスタ読み込み失敗
                        TMsgDisp.Show(
                            this,                                           // 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_STOP,                    // エラーレベル
                            PG_ID,                                          // アセンブリＩＤまたはクラスＩＤ
                            PG_NAME,                                        // プログラム名称
                            "Search",                                       // 処理名称
                            TMsgDisp.OPE_GET,                               // オペレーション
                            "ロールグループ情報の読み込みに失敗しました。", // 表示するメッセージ
                            status,                                         // ステータス値
                            this._roleGroupAuthAcs,                         // エラーが発生したオブジェクト
                            MessageBoxButtons.OK,                           // 表示するボタン
                            MessageBoxDefaultButton.Button1);               // 初期表示ボタン

                        break;
                    }
            }

            // 戻り値セット
            totalCount = this._totalCount;

            return status;
        }

        /// <summary>
        /// ネクストデータ検索処理
        /// </summary>
        /// <param name="readCount">抽出対象件数</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 指定した件数分のネクストデータを検索します。</br>
        /// <br>Programmer : 30746 高川 悟</br>
        /// <br>Date       : 2013/02/18</br>
        /// </remarks>
        public int SearchNext(int readCount)
        {
            // 未実装
            return 9;
        }

        /// <summary>
        /// 明細データ検索処理
        /// </summary>
        /// <param name="totalCount">全該当件数</param>
        /// <param name="readCount">抽出対象件数</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 先頭から指定件数分のデータを検索し、抽出結果を展開したDataSetと全該当件数を返します。</br>
        /// <br>Programmer : 30746 高川 悟</br>
        /// <br>Date       : 2013/02/18</br>
        /// </remarks>
        public int DetailsDataSearch(ref int totalCount, int readCount)
        {
            int status = 0;
            ArrayList arrRoleGroupAuth = new ArrayList();

            // 現在保持しているロールグループ権限データをクリアする
            this.Bind_DataSet.Tables[S_ROLEGROUPAUTH_TABLE].Rows.Clear();
            this._roleGroupAuthTable.Clear();

            // readCountが負の場合、強制終了
            if (readCount < 0) return 0;

            // 選択されているロールグループデータを取得する
            string guid = (string)this.Bind_DataSet.Tables[I_ROLEGROUPNAME_TABLE].Rows[this._mainDataIndex][I_ROLEGROUPNAME_GUID];
            RoleGroupNameSt roleGroupNameSt = (RoleGroupNameSt)this._roleGroupNameTable[guid];

            // ロールグループコード指定 ロールグループ権限検索処理（論理削除含む）
            status = this._roleGroupAuthAcs.SearchAll(roleGroupNameSt.RoleGroupCode, out arrRoleGroupAuth, this._enterpriseCode);

            // ロールグループ権限のレコードを保持
            CacheRoleGroupAuthList(roleGroupNameSt.RoleGroupCode, arrRoleGroupAuth);

            this._totalCount = arrRoleGroupAuth.Count;

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                    {
                        // 取得したロールグループ権限クラスをデータセットへ展開する
                        int index = 0;
                        foreach (RoleGroupAuth roleGroupAuth in arrRoleGroupAuth)
                        {
                            // ロールグループ権限クラスデータセット展開処理
                            RoleGroupAuthToDataSet(roleGroupAuth.Clone(), index);
                            ++index;
                        }
                        // ロールグループ権限ソート
                        RoleGroupAuthSort();

                        break;
                    }
                default:
                    {
                        // 明細データ検索処理
                        TMsgDisp.Show(
                            this,                                               // 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_STOP,                        // エラーレベル
                            PG_ID,                                              // アセンブリＩＤまたはクラスＩＤ
                            PG_NAME,                                            // プログラム名称
                            "DetailsDataSearch",                                // 処理名称
                            TMsgDisp.OPE_GET,                                   // オペレーション
                            "ロールグループ権限情報の読み込みに失敗しました。", // 表示するメッセージ
                            status,                                             // ステータス値
                            this._roleGroupAuthAcs,                             // エラーが発生したオブジェクト
                            MessageBoxButtons.OK,                               // 表示するボタン
                            MessageBoxDefaultButton.Button1);                   // 初期表示ボタン

                        break;
                    }
            }

            totalCount = this._totalCount;

            return status;
        }

        /// <summary>
        /// 明細ネクストデータ検索処理
        /// </summary>
        /// <param name="readCount">抽出対象件数</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 指定した件数分のネクストデータを検索します。</br>
        /// <br>Programmer : 30746 高川 悟</br>
        /// <br>Date       : 2013/02/18</br>
        /// </remarks>
        public int DetailsDataSearchNext(int readCount)
        {
            return 9;
        }

        /// <summary>
        /// データ削除処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 選択中のデータを削除します。</br>
        /// <br>Programmer : 30746 高川 悟</br>
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
                        // 排他処理
                        ExclusiveTransaction(status, TMsgDisp.OPE_DELETE, this._roleGroupAuthAcs);
                        return status;
                    }
                case -2:
                    {
                        //主作業設定で使用中
                        TMsgDisp.Show(this,
                            emErrorLevel.ERR_LEVEL_EXCLAMATION,
                            PG_ID,
                            "このレコードは主作業設定で使用されているため削除できません",
                            status,
                            MessageBoxButtons.OK);
                        this.Hide();

                        return status;
                    }
                default:
                    {
                        // 論理削除処理の失敗
                        TMsgDisp.Show(
                            this,                               // 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_STOPDISP,    // エラーレベル
                            PG_ID,                              // アセンブリＩＤまたはクラスＩＤ
                            PG_NAME,                            // プログラム名称
                            "Delete",                           // 処理名称
                            TMsgDisp.OPE_HIDE,                  // オペレーション
                            ERR_RDEL_MSG,                       // 表示するメッセージ 
                            status,                             // ステータス値
                            this._roleGroupAuthAcs,             // エラーが発生したオブジェクト
                            MessageBoxButtons.OK,               // 表示するボタン
                            MessageBoxDefaultButton.Button1);   // 初期表示ボタン

                        return status;
                    }
            }

            // データセット展開処理
            RoleGroupAuthToDataSet(roleGroupAuth.Clone(), this._detailsDataIndex);

            // ロールグループ権限ソート
            RoleGroupAuthSort();

            return status;
        }

        /// <summary>
        /// 印刷処理
        /// </summary>
        /// <param></param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 印刷機能無しの為、未実装。</br>
        /// <br>Programmer : 30746 高川 悟</br>
        /// <br>Date       : 2013/02/18</br>
        /// </remarks>
        public int Print()
        {
            // 印刷機能無しの為未実装
            return 0;
        }

        /// <summary>
        /// グリッド列外観情報取得処理
        /// </summary>
        /// <param name="appearanceTable">グリッド外観</param>
        /// <returns>グリッド列外観情報格納Hashtable</returns>
        /// <remarks>
        /// <br>Note       : 各列の外見を設定するクラスを格納したHashtableを取得します。</br>
        /// <br>Programmer : 30746 高川 悟</br>
        /// <br>Date       : 2013/02/18</br>
        /// </remarks>
        public void GetAppearanceTable(out Hashtable[] appearanceTable)
        {
            // メイングリッド
            Hashtable mainAppearanceTable = new Hashtable();

            // 削除日
            mainAppearanceTable.Add(S_DELETEDATE, new GridColAppearance(MGridColDispType.DeletionDataBoth, ContentAlignment.MiddleLeft, "", Color.Red));
            // ロールグループコード
            mainAppearanceTable.Add(I_ROLEGROUPCODE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            // ロールグループ名称
            mainAppearanceTable.Add(I_ROELGROUPNAME, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // ロールグループ情報GUID
            mainAppearanceTable.Add(I_ROLEGROUPNAME_GUID, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));

            // サブグリッド
            Hashtable detailsAppearanceTable = new Hashtable();

            // 削除日
            detailsAppearanceTable.Add(S_DELETEDATE, new GridColAppearance(MGridColDispType.DeletionDataBoth, ContentAlignment.MiddleLeft, "", Color.Red));
            // ソートキー   
            detailsAppearanceTable.Add(S_SORTKEY, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
            // ロールグループコード
            detailsAppearanceTable.Add(S_ROLEGROUPCODE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            // ロールカテゴリID
            detailsAppearanceTable.Add(S_ROLECATEGORYID, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            // ロールサブカテゴリID
            detailsAppearanceTable.Add(S_ROLECATEGORYSUBID, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            // ロールグループアイテムID
            detailsAppearanceTable.Add(S_ROLEITEMID, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            // 区分
            detailsAppearanceTable.Add(S_ROLECLASS, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // 名称
            detailsAppearanceTable.Add(S_ROLESYSTEMFUNCTION, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // ロール制限区分
            detailsAppearanceTable.Add(S_ROLELIMITDIV, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            // ロールグループ権限情報GUID
            detailsAppearanceTable.Add(S_ROLEGROUPAUTH_GUID, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));

            appearanceTable = new Hashtable[2];
            appearanceTable[0] = mainAppearanceTable;
            appearanceTable[1] = detailsAppearanceTable;
        }

        # endregion

        # region ※Control Events

        /// <summary>
        /// 画面ロードイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントデータ</param>
        /// <remarks>
        /// <br>Note       : ユーザーがフォームを読み込むときに発生します。</br>
        /// <br>Programmer : 30746 高川 悟</br>
        /// <br>Date       : 2013/02/18</br>
        /// </remarks>
        private void PMKHN09730UA_Load(object sender, System.EventArgs e)
        {
            // アイコンリソース管理クラスを使用して、アイコンを表示する
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
        /// 画面クローズイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントデータ</param>
        /// <remarks>
        /// <br>Note       : ユーザーがフォームを閉じようとした時に発生します。</br>
        /// <br>Programmer : 30746 高川 悟</br>
        /// <br>Date       : 2013/02/18</br>
        /// </remarks>
        private void PMKHN09730UA_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // GridのIndexBuffer格納用変数初期化
            this._mainIndexBuffer = -2;
            this._detailsIndexBuffer = -2;

            // CanCloseプロパティがfalseの場合は、クローズ処理をキャンセルして
            // フォームを非表示化する。
            //（フォームの「×」をクリックされた場合の対応です。）
            if (CanClose == false)
            {
                e.Cancel = true;
                this.Hide();
                return;
            }
        }

        /// <summary>
        /// 画面表示状態変更イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントデータ</param>
        /// <remarks>
        /// <br>Note       : 画面の表示状態が変わったときに発生します。</br>
        /// <br>Programmer : 30746 高川 悟</br>
        /// <br>Date       : 2013/02/18</br>
        /// </remarks>
        private void PMKHN09730UA_VisibleChanged(object sender, System.EventArgs e)
        {
            if (!this.flag)
            {
                // 自分自身が非表示になった場合は以下の処理をキャンセルする。
                if (this.Visible == false)
                {
                    // メインフレームアクティブ化
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

                // 画面初期化処理
                ScreenClear();
            }

            // 画面表示タイマーON
            Initial_Timer.Enabled = true;
        }

        /// <summary>
        /// 保存ボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントデータ</param>
        /// <remarks>
        /// <br>Note       : 保存ボタンコントロールがクリックされた時に発生します。</br>
        /// <br>Programmer : 30746 高川 悟</br>
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

            // 画面非表示イベント
            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                UnDisplaying(this, me);
            }

            // 新規モードの場合は画面を終了させずに連続入力を可能とする。
            if (this.lblMode.Text == INSERT_MODE)
            {
                // 画面を初期化
                this.ScreenClear();

                // 画面を再構築
                this.ScreenReconstruction();

                // ガイドボタンにフォーカスをセット
                this.buttonSystemFuncGuide.Focus();

            }
            else
            {
                this.DialogResult = DialogResult.OK;

                // GridのIndexBuffer格納用変数初期化
                this._mainIndexBuffer = -2;
                this._detailsIndexBuffer = -2;

                // CanCloseプロパティがfalseの場合は、クローズ処理をキャンセルして
                // フォームを非表示化する。
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
        /// 閉じるボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントデータ</param>
        /// <remarks>
        /// <br>Note       : 閉じるボタンコントロールがクリックされた時に発生します。</br>
        /// <br>Programmer : 30746 高川 悟</br>
        /// <br>Date       : 2013/02/18</br>
        /// </remarks>
        private void buttonCancel_Click(object sender, System.EventArgs e)
        {
            //保存確認
            RoleGroupAuth compareRoleGroupAuth = new RoleGroupAuth();
            compareRoleGroupAuth = this._roleGroupAuthClone.Clone();
            //現在の画面情報を取得する
            DispToRoleGroupAuth(ref compareRoleGroupAuth);

            //最初に取得した画面情報と比較
            if (!(this._roleGroupAuthClone.Equals(compareRoleGroupAuth)))
            {
                // 画面情報が変更されていた場合は、保存確認メッセージを表示する
                // 保存確認
                DialogResult res = TMsgDisp.Show(
                    this,                               // 親ウィンドウフォーム
                    emErrorLevel.ERR_LEVEL_SAVECONFIRM, // エラーレベル
                    PG_ID,                              // アセンブリＩＤまたはクラスＩＤ
                    null,                               // 表示するメッセージ
                    0,                                  // ステータス値
                    MessageBoxButtons.YesNoCancel);     // 表示するボタン

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

            // 画面非表示イベント
            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult);
                UnDisplaying(this, me);
            }

            this.DialogResult = DialogResult.Cancel;

            // GridのIndexBuffer格納用変数初期化
            this._mainIndexBuffer = -2;
            this._detailsIndexBuffer = -2;

            // CanCloseプロパティがfalseの場合は、クローズ処理をキャンセルして
            // フォームを非表示化する。
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
        /// Control.Click イベント(Delete_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : 完全削除ボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programmer : 30746 高川 悟</br>
        /// <br>Date       : 2013/02/18</br>
        /// </remarks>
        private void buttonDelete_Click(object sender, System.EventArgs e)
        {
            int status = 0;
            DialogResult result = TMsgDisp.Show(
                this,                                                   // 親ウィンドウフォーム
                emErrorLevel.ERR_LEVEL_QUESTION,                        // エラーレベル
                PG_ID,                                                  // アセンブリＩＤまたはクラスＩＤ
                "データを削除します。" + "\r\n" + "よろしいですか？",   // 表示するメッセージ 
                0,                                                      // ステータス値
                MessageBoxButtons.OKCancel,                             // 表示するボタン
                MessageBoxDefaultButton.Button2);                       // 初期表示ボタン


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
                                this,                                 // 親ウィンドウフォーム
                                emErrorLevel.ERR_LEVEL_STOPDISP,      // エラーレベル
                                PG_ID,                                // アセンブリＩＤまたはクラスＩＤ
                                PG_NAME,                              // プログラム名称
                                "Delete_Button_Click",                // 処理名称
                                TMsgDisp.OPE_DELETE,                  // オペレーション
                                ERR_RDEL_MSG,                         // 表示するメッセージ 
                                status,                               // ステータス値
                                this._roleGroupAuthAcs,               // エラーが発生したオブジェクト
                                MessageBoxButtons.OK,                 // 表示するボタン
                                MessageBoxDefaultButton.Button1);     // 初期表示ボタン

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
        /// Control.Click イベント(Revive_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : 復活ボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programmer : 30746 高川 悟</br>
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
                            this,                                 // 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_STOPDISP,      // エラーレベル
                            PG_ID,                                // アセンブリＩＤまたはクラスＩＤ
                            PG_NAME,                              // プログラム名称
                            "Revive_Button_Click",                // 処理名称
                            TMsgDisp.OPE_UPDATE,                  // オペレーション
                            ERR_RVV_MSG,                          // 表示するメッセージ 
                            status,                               // ステータス値
                            this._roleGroupAuthAcs,               // エラーが発生したオブジェクト
                            MessageBoxButtons.OK,                 // 表示するボタン
                            MessageBoxDefaultButton.Button1);     // 初期表示ボタン

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

            // データセット展開処理
            RoleGroupAuthToDataSet(roleGroupAuth, this._detailsIndexBuffer);

            // ロールグループ権限ソート
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
        /// システム機能ガイドボタン押下イベント
        /// </summary>
        /// <param name="sender">コントロール</param>
        /// <param name="e">イベントデータ</param>
        /// <remarks>
        /// <br>Note       : システム機能ガイドボタン押下時の処理を行います。</br>
        /// <br>Programmer : 30746 高川 悟</br>
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
        /// Timer.Tick イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note        : 指定された間隔の時間が経過したときに発生します。
        ///                   この処理は、システムが提供するスレッド プール
        ///                   スレッドで実行されます。</br>
        /// <br>Programmer  : 30746 高川 悟</br>
        /// <br>Date        : 2013/02/18</br>
        /// </remarks>
        private void Initial_Timer_Tick(object sender, System.EventArgs e)
        {
            Initial_Timer.Enabled = false;

            // 画面再構築処理
            ScreenReconstruction();
        }

        # endregion

        #region Private Methods

        /// <summary>
        /// ロールグループクラスデータセット展開処理
        /// </summary>
        /// <param name="roleGroupName">ロールグループクラス</param>
        /// <param name="index">データセットへ展開するインデックス</param>
        /// <remarks>
        /// <br>Note       : ロールグループクラスをデータセットへ格納します。</br>
        /// <br>Programmer : 30746 高川 悟</br>
        /// <br>Date       : 2013/02/18</br>
        /// </remarks>
        private void RoleGroupNameMntToDataSet(RoleGroupNameSt roleGroupNameSt, int index)
        {
            if ((index < 0) || (this.Bind_DataSet.Tables[I_ROLEGROUPNAME_TABLE].Rows.Count <= index))
            {
                // 新規と判断して、行を追加する
                DataRow dataRow = this.Bind_DataSet.Tables[I_ROLEGROUPNAME_TABLE].NewRow();
                this.Bind_DataSet.Tables[I_ROLEGROUPNAME_TABLE].Rows.Add(dataRow);

                // indexを行の最終行番号にする
                index = this.Bind_DataSet.Tables[I_ROLEGROUPNAME_TABLE].Rows.Count - 1;
            }

            // 削除日
            this.Bind_DataSet.Tables[I_ROLEGROUPNAME_TABLE].Rows[index][S_DELETEDATE] = GetDeleteDate(roleGroupNameSt);

            // ロールグループコード
            this.Bind_DataSet.Tables[I_ROLEGROUPNAME_TABLE].Rows[index][I_ROLEGROUPCODE] = roleGroupNameSt.RoleGroupCode;

            // ロールグループ名
            this.Bind_DataSet.Tables[I_ROLEGROUPNAME_TABLE].Rows[index][I_ROELGROUPNAME] = roleGroupNameSt.RoleGroupName;

            // ロールグループ情報GUID
            this.Bind_DataSet.Tables[I_ROLEGROUPNAME_TABLE].Rows[index][I_ROLEGROUPNAME_GUID] = CreateHashKey(roleGroupNameSt);

            // ハッシュ検索用にGUIDセット
            this._roleGroupNameTable.Add(CreateHashKey(roleGroupNameSt), roleGroupNameSt);
            if (this._roleGroupNameTable.ContainsKey(CreateHashKey(roleGroupNameSt)) == true)
            {
                this._roleGroupNameTable.Remove(CreateHashKey(roleGroupNameSt));
            }
            this._roleGroupNameTable.Add(CreateHashKey(roleGroupNameSt), roleGroupNameSt);
        }

        /// <summary>
        /// メインテーブルの削除日を取得します。
        /// </summary>
        /// <param name="roleGroupName">ロールグループクラス</param>
        /// <returns>メインテーブルの削除日（削除されていない場合、<c>string.Empty</c>を返します。）</returns>
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

        #region <ロールグループ権限のキャッシュ/>

        /// <summary>ロールグループ権限のキャッシュ</summary>
        /// <remarks>キー：ロールグループコード</remarks>
        private readonly IDictionary<int, ArrayList> _roleGroupAuthListCacheMap = new Dictionary<int, ArrayList>();
        /// <summary>
        /// ロールグループ権限のキャッシュを取得します。
        /// </summary>
        private IDictionary<int, ArrayList> RoleGroupAuthListCacheMap
        {
            get { return _roleGroupAuthListCacheMap; }
        }

        /// <summary>
        /// ロールグループ権限をキャッシュします。
        /// </summary>
        /// <param name="roleGroupCode">ロールグループコード</param>
        /// <param name="roleGroupAuthList">ロールグループ権限のレコードリスト</param>
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
        /// ロールグループ権限クラスデータセット展開処理
        /// </summary>
        /// <param name="roleGroupAuth">ロールグループ権限クラス</param>
        /// <param name="index">データセットへ展開するインデックス</param>
        /// <remarks>
        /// <br>Note       : ロールグループ権限クラスをデータセットへ格納します。</br>
        /// <br>Programmer : 30746 高川 悟</br>
        /// <br>Date       : 2013/02/18</br>
        /// </remarks>
        private void RoleGroupAuthToDataSet(RoleGroupAuth roleGroupAuth, int index)
        {
            if ((index < 0) || (this.Bind_DataSet.Tables[S_ROLEGROUPAUTH_TABLE].Rows.Count <= index))
            {
                // 新規と判断して、行を追加する
                DataRow dataRow = this.Bind_DataSet.Tables[S_ROLEGROUPAUTH_TABLE].NewRow();
                this.Bind_DataSet.Tables[S_ROLEGROUPAUTH_TABLE].Rows.Add(dataRow);

                // indexを行の最終行番号する
                index = this.Bind_DataSet.Tables[S_ROLEGROUPAUTH_TABLE].Rows.Count - 1;
            }

            // 削除日
            if (roleGroupAuth.LogicalDeleteCode == 0)
            {
                this.Bind_DataSet.Tables[S_ROLEGROUPAUTH_TABLE].Rows[index][S_DELETEDATE] = "";
            }
            else
            {
                this.Bind_DataSet.Tables[S_ROLEGROUPAUTH_TABLE].Rows[index][S_DELETEDATE] = TDateTime.DateTimeToString("ggYY/MM/DD", roleGroupAuth.UpdateDateTime);
            }

            // ロールグループコード
            this.Bind_DataSet.Tables[S_ROLEGROUPAUTH_TABLE].Rows[index][S_ROLEGROUPCODE] = roleGroupAuth.RoleGroupCode;

            // ロールカテゴリID
            this.Bind_DataSet.Tables[S_ROLEGROUPAUTH_TABLE].Rows[index][S_ROLECATEGORYID] = roleGroupAuth.RoleCategoryID.ToString();

            // ロールサブカテゴリID
            this.Bind_DataSet.Tables[S_ROLEGROUPAUTH_TABLE].Rows[index][S_ROLECATEGORYSUBID] = roleGroupAuth.RoleCategorySubID.ToString();

            // ロールアイテムID
            this.Bind_DataSet.Tables[S_ROLEGROUPAUTH_TABLE].Rows[index][S_ROLEITEMID] = roleGroupAuth.RoleItemID.ToString();

            // ロール制限区分
            this.Bind_DataSet.Tables[S_ROLEGROUPAUTH_TABLE].Rows[index][S_ROLELIMITDIV] = roleGroupAuth.RoleLimitDiv.ToString();

            // ロールグループ権限情報GUID
            this.Bind_DataSet.Tables[S_ROLEGROUPAUTH_TABLE].Rows[index][S_ROLEGROUPAUTH_GUID] = CreateHashKey(roleGroupAuth);

            // 分類、名称、ソートキーを取得
            string[] ClassAndName = new string[3];
            int status = GetClassAndName(dsSystemProducts, roleGroupAuth.RoleCategoryID, roleGroupAuth.RoleCategorySubID, roleGroupAuth.RoleItemID, out ClassAndName);

            this.Bind_DataSet.Tables[S_ROLEGROUPAUTH_TABLE].Rows[index][S_ROLECLASS] = ClassAndName[0];             // 分類
            this.Bind_DataSet.Tables[S_ROLEGROUPAUTH_TABLE].Rows[index][S_ROLESYSTEMFUNCTION] = ClassAndName[1];    // 名称
            this.Bind_DataSet.Tables[S_ROLEGROUPAUTH_TABLE].Rows[index][S_SORTKEY] = ClassAndName[2];               // ソートキー

            // ハッシュ検索用にGUIDセット
            if (this._roleGroupAuthTable.ContainsKey(CreateHashKey(roleGroupAuth)) == true)
            {
                this._roleGroupAuthTable.Remove(CreateHashKey(roleGroupAuth));
            }
            this._roleGroupAuthTable.Add(CreateHashKey(roleGroupAuth), roleGroupAuth);
        }

        /// <summary>
        /// ロールグループ権限設定ソート
        /// </summary>
        /// <remarks>
        /// <br>Note       : ロールグループ権限設定をキー順にソートします。</br>
        /// <br>Programmer : 30746 高川 悟</br>
        /// <br>Date       : 2013/02/18</br>
        /// </remarks>
        private void RoleGroupAuthSort()
        {
            if (this.Bind_DataSet.Tables[S_ROLEGROUPAUTH_TABLE].Rows.Count > 0)
            {
                // データセットを複製
                DataSet Bind_DataSetWk = Bind_DataSet.Copy();

                // 元のデータセットをクリア
                this.Bind_DataSet.Tables[S_ROLEGROUPAUTH_TABLE].Clear();

                // データセットをソートキー順に再構築
                DataRow[] dataRows = Bind_DataSetWk.Tables[S_ROLEGROUPAUTH_TABLE].Select("", S_SORTKEY);
                foreach (DataRow dataRow in dataRows)
                {
                    this.Bind_DataSet.Tables[S_ROLEGROUPAUTH_TABLE].ImportRow(dataRow);
                }
            }
        }

        /// <summary>
        /// ロールグループ権限設定マスタ クラス画面展開処理
        /// </summary>
        /// <param name="roleGroupAuth">ロールグループ権限設定マスタ オブジェクト</param>
        /// <remarks>
        /// <br>Note       : ロールグループ権限設定マスタ オブジェクトから画面にデータを展開します。</br>
        /// <br>Programmer : 30746 高川 悟</br>
        /// <br>Date       : 2013/02/18</br>
        /// </remarks>
        private void RoleGroupAuthToScreen(RoleGroupAuth roleGroupAuth)
        {
            this.txtRoleGroupCode.SetInt(roleGroupAuth.RoleGroupCode);                      // ロールグループコード
            this.txtRoleGroupName.Text = GetRoleGroupName(roleGroupAuth.RoleGroupCode);     // ロールグループ名
            this.txtCategoryID.Text = roleGroupAuth.RoleCategoryID.ToString();              // カテゴリID
            this.txtCategorySubID.Text = roleGroupAuth.RoleCategorySubID.ToString();        // サブカテゴリID
            this.txtItemID.Text = roleGroupAuth.RoleItemID.ToString();                      // アイテムID

            string[] ClassAndName = new string[3];
            int status = GetClassAndName(dsSystemProducts, roleGroupAuth.RoleCategoryID, roleGroupAuth.RoleCategorySubID, roleGroupAuth.RoleItemID, out ClassAndName);
            this.txtSystemFunction.Text = ClassAndName[1];                                  // 名称
        }

        /// <summary>
        /// 画面情報ロールグループ権限設定マスタ クラス格納処理
        /// </summary>
        /// <param name="roleGroupAuth">ロールグループ権限設定マスタ オブジェクト</param>
        /// <remarks>
        /// <br>Note       : 画面情報からロールグループ権限設定マスタ オブジェクトにデータを格納します。</br>
        /// <br>Programmer : 30746 高川 悟</br>
        /// <br>Date       : 2013/02/18</br>
        /// </remarks>
        private void DispToRoleGroupAuth(ref RoleGroupAuth roleGroupAuth)
        {
            if (roleGroupAuth == null)
            {
                // 新規の場合
                roleGroupAuth = new RoleGroupAuth();
            }

            roleGroupAuth.EnterpriseCode = this._enterpriseCode;                    // 企業コード

            roleGroupAuth.RoleGroupCode = this.txtRoleGroupCode.GetInt();           // ロールグループコード
            roleGroupAuth.RoleCategoryID = this.txtCategoryID.GetInt();             // カテゴリID
            roleGroupAuth.RoleCategorySubID = this.txtCategorySubID.GetInt();       // サブカテゴリID
            roleGroupAuth.RoleItemID = this.txtItemID.GetInt();                     // アイテムID
            roleGroupAuth.RoleLimitDiv = 1;                                         // ロール制限区分(1:許可しない固定)
        }

        /// <summary>
        /// データセット列情報構築処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : DataSetの列情報を構築します。データセットの列情報がフレームのビュー用グリッドの列になります。</br>
        /// <br>Programmer : 30746 高川 悟</br>
        /// <br>Date       : 2013/02/18</br>
        /// </remarks>
        private void DataSetColumnConstruction()
        {
            // メインテーブルの列定義
            DataTable _roleGroupNameDt = new DataTable(I_ROLEGROUPNAME_TABLE);

            _roleGroupNameDt.Columns.Add(S_DELETEDATE, typeof(string));             // 削除日
            _roleGroupNameDt.Columns.Add(I_ROLEGROUPCODE, typeof(string));          // ロールグループコード
            _roleGroupNameDt.Columns.Add(I_ROELGROUPNAME, typeof(string));          // ロールグループ名
            _roleGroupNameDt.Columns.Add(I_ROLEGROUPNAME_GUID, typeof(string));     // ロールグループ情報GUID

            this.Bind_DataSet.Tables.Add(_roleGroupNameDt);

            // サブテーブルの列定義
            DataTable _roleGroupAuthDt = new DataTable(S_ROLEGROUPAUTH_TABLE);

            _roleGroupAuthDt.Columns.Add(S_DELETEDATE, typeof(string));             // 削除日
            _roleGroupAuthDt.Columns.Add(S_SORTKEY, typeof(string));                // ソートキー
            _roleGroupAuthDt.Columns.Add(S_ROLEGROUPCODE, typeof(string));          // ロールグループコード
            _roleGroupAuthDt.Columns.Add(S_ROLECATEGORYID, typeof(string));         // ロールカテゴリID
            _roleGroupAuthDt.Columns.Add(S_ROLECATEGORYSUBID, typeof(string));      // ロールサブカテゴリID
            _roleGroupAuthDt.Columns.Add(S_ROLEITEMID, typeof(string));             // ロールアイテムID
            _roleGroupAuthDt.Columns.Add(S_ROLECLASS, typeof(string));              // ロール区分
            _roleGroupAuthDt.Columns.Add(S_ROLESYSTEMFUNCTION, typeof(string));     // システム機能
            _roleGroupAuthDt.Columns.Add(S_ROLELIMITDIV, typeof(string));           // ロール制限区分
            _roleGroupAuthDt.Columns.Add(S_ROLEGROUPAUTH_GUID, typeof(string));     // ロールグループ権限設定情報GUID

            this.Bind_DataSet.Tables.Add(_roleGroupAuthDt);
        }

        /// <summary>
        /// 画面再構築処理
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : モードに基づいて画面の再構築を行います。</br>
        /// <br>Programmer : 30746 高川 悟</br>
        /// <br>Date       : 2013/02/18</br>
        /// </remarks>
        private void ScreenReconstruction()
        {
            if (this._detailsDataIndex < 0)
            {
                // 新規モード
                this.lblMode.Text = INSERT_MODE;

                // ロールグループ情報を取得
                string roleGroupNameGuid = (string)this.Bind_DataSet.Tables[I_ROLEGROUPNAME_TABLE].Rows[this._mainDataIndex][I_ROLEGROUPNAME_GUID];
                RoleGroupNameSt roleGroupNameSt = (RoleGroupNameSt)this._roleGroupNameTable[roleGroupNameGuid];

                // ロールグループ情報を画面に設定
                this.txtRoleGroupCode.SetInt(roleGroupNameSt.RoleGroupCode);
                this.txtRoleGroupName.Text = roleGroupNameSt.RoleGroupName;

                // 画面入力許可制御処理
                ScreenPermissionControl(INSERT_MODE);

                // FrameのIndex/Tableバッファ保持
                this._mainIndexBuffer = -2;
                this._detailsIndexBuffer = this._detailsDataIndex;
                this._targetTableBuffer = this._targetTableName;

                //クローン作成
                RoleGroupAuth roleGroupAuth = new RoleGroupAuth();
                this._roleGroupAuthClone = roleGroupAuth.Clone();
                DispToRoleGroupAuth(ref this._roleGroupAuthClone);

                // フォーカス設定
                buttonSystemFuncGuide.Focus();
            }
            else
            {
                // 選択ロールグループ権限の情報を取得
                string guid = (string)this.Bind_DataSet.Tables[S_ROLEGROUPAUTH_TABLE].Rows[this._detailsDataIndex][S_ROLEGROUPAUTH_GUID];
                RoleGroupAuth roleGroupAuth = (RoleGroupAuth)this._roleGroupAuthTable[guid];

                if (roleGroupAuth.LogicalDeleteCode == 0)
                {
                    // 参照モード
                    this.lblMode.Text = REFERENCE_MODE;

                    // 画面入力許可制御処理
                    ScreenPermissionControl(REFERENCE_MODE);

                    // 画面展開処理
                    RoleGroupAuthToScreen(roleGroupAuth);

                    //クローン作成
                    this._roleGroupAuthClone = roleGroupAuth.Clone();
                    DispToRoleGroupAuth(ref this._roleGroupAuthClone);

                    // フォーカス設定
                    this.buttonCancel.Focus();
                }
                else
                {
                    // 削除モード
                    this.lblMode.Text = DELETE_MODE;

                    // 画面入力許可制御処理
                    ScreenPermissionControl(DELETE_MODE);

                    // 画面展開処理
                    RoleGroupAuthToScreen(roleGroupAuth);

                    //クローン作成
                    this._roleGroupAuthClone = roleGroupAuth.Clone();
                    DispToRoleGroupAuth(ref this._roleGroupAuthClone);

                    // フォーカス設定
                    this.buttonDelete.Focus();
                }

                // FrameのIndex/Tableバッファ保持
                this._mainIndexBuffer = this._mainDataIndex;
                this._detailsIndexBuffer = this._detailsDataIndex;
                this._targetTableBuffer = this._targetTableName;
            }
        }

        /// <summary>
        /// 画面許可制御処理
        /// </summary>
        /// <param name="enabled">画面モード</param>
        /// <remarks>
        /// <br>Note       : 画面モード毎に入力／ボタンの許可を制御します。</br>
        /// <br>Programmer : 30746 高川 悟</br>
        /// <br>Date       : 2013/02/18</br>
        /// </remarks>
        private void ScreenPermissionControl(string screenMode)
        {
            // 新規
            if (screenMode.Equals(INSERT_MODE))
            {
                // ボタン設定
                this.buttonOK.Visible = true;
                this.buttonDelete.Visible = false;
                this.buttonRevive.Visible = false;
                this.buttonSystemFuncGuide.Visible = true;
                this.buttonSystemFuncGuide.Enabled = true;

                // 入力設定
                this.txtRoleGroupCode.Enabled = true;
                this.txtSystemFunction.Enabled = true;
            }
            // 更新
            else if (screenMode.Equals(UPDATE_MODE))
            {
                // ボタン設定
                this.buttonOK.Visible = true;
                this.buttonDelete.Visible = false;
                this.buttonRevive.Visible = false;
                this.buttonSystemFuncGuide.Visible = true;
                this.buttonSystemFuncGuide.Enabled = false;

                // 入力設定
                this.txtRoleGroupCode.Enabled = false;
                this.txtSystemFunction.Enabled = true;
            }
            // 削除
            else if (screenMode.Equals(DELETE_MODE))
            {
                // ボタン設定
                this.buttonOK.Visible = false;
                this.buttonDelete.Visible = true;
                this.buttonRevive.Visible = true;
                this.buttonSystemFuncGuide.Visible = true;
                this.buttonSystemFuncGuide.Enabled = false;

                // 入力設定
                this.txtRoleGroupCode.Enabled = false;
                this.txtSystemFunction.Enabled = false;
            }
            // 参照
            else if (screenMode.Equals(REFERENCE_MODE))
            {
                // ボタン設定
                this.buttonOK.Visible = false;
                this.buttonDelete.Visible = false;
                this.buttonRevive.Visible = false;
                this.buttonSystemFuncGuide.Visible = true;
                this.buttonSystemFuncGuide.Enabled = false;

                // 入力設定
                this.txtRoleGroupCode.Enabled = false;
                this.txtSystemFunction.Enabled = false;
            }
        }

        /// <summary>
        /// 画面初期化処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面の初期化を行います。</br>
        /// <br>Programmer : 30746 高川 悟</br>
        /// <br>Date       : 2013/02/18</br>
        /// </remarks>
        private void ScreenClear()
        {
            this.txtRoleGroupCode.Clear();          // ロールグループコード
            this.txtRoleGroupName.Text = "";        // ロールグループ名称
            this.txtSystemFunction.Text = "";       // システム機能コード
            this.txtCategoryID.Text = "";           // カテゴリID
            this.txtCategorySubID.Text = "";        // サブカテゴリID
            this.txtItemID.Text = "";               // アイテムID
        }

        /// <summary>
        /// 画面入力情報不正チェック処理
        /// </summary>
        /// <param name="control">不正対象コントロール</param>
        /// <param name="message">メッセージ</param>
        /// <param name="loginID">ログインID</param>
        /// <returns>チェック結果（true:OK／false:NG）</returns>
        /// <remarks>
        /// <br>Note       : 画面入力情報の不正チェックを行います。</br>
        /// <br>Programmer : 30746 高川 悟</br>
        /// <br>Date       : 2013/02/18</br>
        /// </remarks>
        private bool ScreenDataCheck(ref Control control, ref string message, string loginID)
        {
            // システム機能
            if (string.IsNullOrEmpty(txtSystemFunction.Text))
            {
                control = this.buttonSystemFuncGuide;
                message = this.lblSystemFunction.Text + "を選択してください。";
                return false;
            }

            return true;
        }

        /// <summary>
        /// ロールグループ権限設定マスタ 情報登録処理
        /// </summary>
        /// <returns>登録結果（true:OK／false:NG）</returns>
        /// <remarks>
        /// <br>Note       : ロールグループ権限設定マスタ 情報登録を行います。</br>
        /// <br>Programmer : 30746 高川 悟</br>
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
                // 更新対象の情報を取得
                string guid = (string)this.Bind_DataSet.Tables[S_ROLEGROUPAUTH_TABLE].Rows[this._detailsDataIndex][S_ROLEGROUPAUTH_GUID];
                roleGroupAuth = ((RoleGroupAuth)this._roleGroupAuthTable[guid]).Clone();
            }

            // 画面入力チェック
            if (!ScreenDataCheck(ref control, ref message, loginID))
            {
                TMsgDisp.Show(
                    this,                               // 親ウィンドウフォーム
                    emErrorLevel.ERR_LEVEL_EXCLAMATION, // エラーレベル
                    PG_ID,                              // アセンブリＩＤまたはクラスＩＤ
                    message,                            // 表示するメッセージ 
                    0,                                  // ステータス値
                    MessageBoxButtons.OK);              // 表示するボタン

                control.Focus();
                return false;
            }
            // 画面情報を条件クラスに設定
            this.DispToRoleGroupAuth(ref roleGroupAuth);

            // 登録／更新処理
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
                            this,                               // 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_EXCLAMATION, // エラーレベル
                            PG_ID,                              // アセンブリＩＤまたはクラスＩＤ
                            ERR_DPR_MSG,                        // 表示するメッセージ 
                            status,                             // ステータス値
                            MessageBoxButtons.OK);              // 表示するボタン

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
                            this,                               // 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_STOPDISP,    // エラーレベル
                            PG_ID,                              // アセンブリＩＤまたはクラスＩＤ
                            PG_NAME,                            // プログラム名称
                            "SaveProc",                         // 処理名称
                            TMsgDisp.OPE_UPDATE,                // オペレーション
                            ERR_UPDT_MSG,                       // 表示するメッセージ 
                            status,                             // ステータス値
                            this._roleGroupAuthAcs,             // エラーが発生したオブジェクト
                            MessageBoxButtons.OK,               // 表示するボタン
                            MessageBoxDefaultButton.Button1);   // 初期表示ボタン

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
                // データセット展開処理
                RoleGroupAuthToDataSet(roleGroupAuth, this._detailsDataIndex);

                // ロールグループ権限ソート
                RoleGroupAuthSort();

            }


            return true;
        }

        /// <summary>
        /// 排他処理
        /// </summary>
        /// <param name="operation">オペレーション</param>
        /// <param name="erObject">エラーオブジェクト</param>
        /// <param name="status">ステータス</param>
        /// <remarks>
        /// <br>Note       : データ更新時の排他処理を行います。</br>
        /// <br>Programmer : 30746 高川 悟</br>
        /// <br>Date       : 2013/02/18</br>
        /// </remarks>
        private void ExclusiveTransaction(int status, string operation, object erObject)
        {
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    {
                        TMsgDisp.Show(
                            this,                               // 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_EXCLAMATION, // エラーレベル
                            PG_ID,                              // アセンブリＩＤまたはクラスＩＤ
                            PG_NAME,                            // プログラム名称
                            "ExclusiveTransaction",             // 処理名称
                            operation,                          // オペレーション
                            ERR_800_MSG,                        // 表示するメッセージ 
                            status,                             // ステータス値
                            erObject,                           // エラーが発生したオブジェクト
                            MessageBoxButtons.OK,               // 表示するボタン
                            MessageBoxDefaultButton.Button1);   // 初期表示ボタン
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        TMsgDisp.Show(
                            this,                               // 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_EXCLAMATION, // エラーレベル
                            PG_ID,                              // アセンブリＩＤまたはクラスＩＤ
                            PG_NAME,                            // プログラム名称
                            "ExclusiveTransaction",             // 処理名称
                            operation,                          // オペレーション
                            ERR_801_MSG,                        // 表示するメッセージ 
                            status,                             // ステータス値
                            erObject,                           // エラーが発生したオブジェクト
                            MessageBoxButtons.OK,               // 表示するボタン
                            MessageBoxDefaultButton.Button1);   // 初期表示ボタン
                        break;
                    }
            }
        }

        /// <summary>
        /// HashTable用キー作成
        /// </summary>
        /// <param name="roleGroupNameSt">RoleGroupNameStクラス</param>
        /// <returns>Hashテーブル用キー</returns>
        /// <remarks>
        /// <br>Note       : RoleGroupNameStクラスからハッシュテーブル用のキーを作成します。</br>
        /// <br>Programmer : 30746 高川 悟</br>
        /// <br>Date       : 2013/02/18</br>
        /// </remarks>
        private string CreateHashKey(RoleGroupNameSt roleGroupNameSt)
        {
            return roleGroupNameSt.RoleGroupCode.ToString("d6");
        }

        /// <summary>
        /// HashTable用キー作成
        /// </summary>
        /// <param name="roleGroupAuth">RoleGroupAuthクラス</param>
        /// <returns>Hashテーブル用キー</returns>
        /// <remarks>
        /// <br>Note       : RoleGroupAuthクラスからハッシュテーブル用のキーを作成します。</br>
        /// <br>Programmer : 30746 高川 悟</br>
        /// <br>Date       : 2013/02/18</br>
        /// </remarks>
        private string CreateHashKey(RoleGroupAuth roleGroupAuth)
        {
            string strHashKey = roleGroupAuth.RoleCategoryID.ToString("d4") + roleGroupAuth.RoleCategorySubID.ToString("d6") + roleGroupAuth.RoleItemID.ToString();
            return strHashKey;
        }

        /// <summary>
        /// ロールグループ名称取得処理
        /// </summary>
        /// <param name="roleGroupCode">ロールグループコード</param>
        /// <returns>ロールグループ名称</returns>
        /// <remarks>
        /// <br>Note       : ロールグループ名称を取得します。</br>
        /// <br>Programmer : 30746 高川 悟</br>
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
                RoleClass = "カテゴリ";

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
                    RoleClass = "サブカテゴリ";

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
                        RoleClass = "アイテム";

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
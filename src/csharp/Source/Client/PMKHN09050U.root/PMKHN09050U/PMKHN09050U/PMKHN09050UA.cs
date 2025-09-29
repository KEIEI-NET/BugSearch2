//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 部位コードマスタ
// プログラム概要   : 部位コードマスタの登録・変更・削除を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2007 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 犬飼
// 作 成 日  2008/06/17  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号  12720       作成担当 : 工藤
// 修 正 日  2009/03/25  修正内容 : 「削除済データの表示」は最上位項目で制御
//----------------------------------------------------------------------------//
#define DELETE_DATE_DEPEND_ON_SUB_TABLE // メインテーブルの削除日をサブテーブルに関連させるフラグ
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
    /// 部位コードマスタ フォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note		: 部位コードマスタ情報の設定を行います。
    ///					  IMasterMaintenanceThreeArrayTypeを実装しています。</br>
    /// <br>Programmer	: 30413 犬飼</br>
    /// <br>Date		: 2008.06.17</br>
    /// <br>Note		: 「削除済データの表示」は最上位項目で制御</br>
    /// <br>Programmer	: 30434 工藤</br>
    /// <br>Date		: 2009.03.25</br>
    /// <br></br>
    /// </remarks>
    public class PMKHN09050UA : System.Windows.Forms.Form, IMasterMaintenanceThreeArrayType, ISynchroLogDelChkBox
    {
        # region ※Private Members (Component)

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

        #region ※Windows フォーム デザイナで生成されたコード
        /// <summary>
        /// デザイナ サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディタで変更しないでください。
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
            this.Mode_Label.Text = "更新モード";
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
            this.PartsPosCode_Label.Text = "部位コード";
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
            this.PartsPosName_Label.Text = "部位名";
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
            this.Cancel_Button.Text = "閉じる(&X)";
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
            this.Revive_Button.Text = "復活(&R)";
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
            this.Delete_Button.Text = "完全削除(&D)";
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
            this.Ok_Button.Text = "保存(&S)";
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
            this.DeleteRow_Button.Font = new System.Drawing.Font("ＭＳ ゴシック", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.DeleteRow_Button.Location = new System.Drawing.Point(12, 131);
            this.DeleteRow_Button.Name = "DeleteRow_Button";
            this.DeleteRow_Button.Size = new System.Drawing.Size(98, 29);
            this.DeleteRow_Button.TabIndex = 5;
            this.DeleteRow_Button.Text = "削除(&D)";
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
            this.ultraLabel1.Text = "得意先コード";
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
            this.Guid_Button.Font = new System.Drawing.Font("ＭＳ ゴシック", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Guid_Button.Location = new System.Drawing.Point(116, 131);
            this.Guid_Button.Name = "Guid_Button";
            this.Guid_Button.Size = new System.Drawing.Size(161, 29);
            this.Guid_Button.TabIndex = 75;
            this.Guid_Button.Text = "提供部位ｶﾞｲﾄﾞ(&G)";
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
            this.Renewal_Button.Text = "最新情報(&I)";
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
            this.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PMKHN09050UA";
            this.Text = "部位マスタ";
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

        #region ※Private Members
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

        // プロパティ用
        private bool _canPrint;
        private bool _canLogicalDeleteDataExtraction;
        private bool _canClose;
        private bool _canNew;
        private bool _canDelete;
        private MGridDisplayLayout _defaultGridDisplayLayout;
        private string _targetTableName;

        // タイトル
        private string _mainGridTitle;
        private string _secondGridTitle;
        private string _thirdGridTitle;

        // アイコン
        private Image _mainGridIcon;
        private Image _secondGridIcon;
        private Image _thirdGridIcon;

        // 選択データインデックス
        private int _mainDataIndex;
        private int _secondDataIndex;
        private int _thirdDataIndex;

        //_dataIndexバッファ（メインフレーム最小化対応）
        private int _mainIndexBuffer;
        private int _secondIndexBuffer;
        private int _thirdIndexBuffer;
        private string _targetTableBuffer;

        // Grid変更フラグ
        private bool _gridUpdFlg = true;

        // 2008.11.18 30413 犬飼 論理削除済みデータの表示チェックボックスを連動 >>>>>>START
        private bool _synchroLogDelFlg = true;
        // 2008.11.18 30413 犬飼 論理削除済みデータの表示チェックボックスを連動 <<<<<<END
        
        // グリッドタイトル
        private const string MAIN_GRID_TITLE = "得意先";
        private const string SECOND_GRID_TITLE = "部位";
        private const string THIRD_GRID_TITLE = "BLｺｰﾄﾞ";

        // FreamのView用Grid列のKEY情報 (ヘッダのタイトル部となります)TbsPartsCode
        private const string M_DELETEDATE = "削除日";   // ADD 2008/03/25 不具合対応[12720]：「削除済データの表示」は最上位項目で制御
        private const string M_CUSTOMERCODE = "得意先コード";
        private const string M_CUSTOMERNAME = "得意先略称";
        private const string MAIN_TABLE = "CUSTOMERCODE_TABLE";

        private const string S_DELETEDATE = "削除日";
        private const string S_PARTSPOSCODE = "部位コード";
        private const string S_PARTSPOSNAME = "部位名";
        private const string S_PARTSPOSCODE_GUID = "PARTSPOSCODE_GUID";
        private const string SECOND_TABLE = "PARTSPOSCODE_TABLE";

        private const string T_DELETEDATE = "削除日";
        private const string T_TBSPARTCODE = "BLｺｰﾄﾞ";
        private const string T_TBSPARTNAME = "BLｺｰﾄﾞ名";
        private const string T_TBSPARTCODE_GUID = "TBSPARTCODE_GUID";
        private const string THIRD_TABLE = "TBSPARTCODE_TABLE";

        //データ区分
        private const int DIVISION_USR = 0;
        private const int DIVISION_OFR = 1;

        // 編集モード
        private const string INSERT_MODE = "新規モード";
        private const string UPDATE_MODE = "更新モード";
        private const string DELETE_MODE = "削除モード";
        private const string REFERENCE_MODE = "参照モード";

        // UIのGrid表示用
        private const string MY_SCREEN_TBSPARTS_CODE = "BLｺｰﾄﾞ";
        private const string MY_SCREEN_TBSPARTS_NAME = "BLｺｰﾄﾞ名";
        private const string MY_SCREEN_ODER = "No.";
        private const string MY_SCREEN_GUID = "MY_SCREEN_GUID";
        private const string MY_SCREEN_TABLE = "MY_SCREEN_TABLE";
        private const string MY_SCREEN_ID = "ID";                               // 作業・部品名称など(編集不可、非表示)

        //UIグリッド用データテーブル
        private DataTable _bindTable;

        // アセンブリ情報
        private const string PG_ID = "PMKHN09050U";
        private const string PG_NAME = "部位マスタ";

        // Message関連定義
        private const string ERR_READ_MSG = "読み込みに失敗しました。";
        private const string ERR_DPR_MSG = "このコードは既に使用されています。";
        private const string ERR_RDEL_MSG = "削除に失敗しました。";
        private const string ERR_UPDT_MSG = "登録に失敗しました。";
        private const string ERR_RVV_MSG = "復活に失敗しました。";
        private const string ERR_800_MSG = "既に他端末より更新されています";
        private const string ERR_801_MSG = "既に他端末より削除されています";
        private const string SDC_RDEL_MSG = "マスタから削除されています";

        // 2008.10.31 30413 犬飼 得意先名称の共通設定を追加 >>>>>>START
        private const string CUSTOMER_SNM_COMMON = "共通設定";
        // 2008.10.31 30413 犬飼 得意先名称の共通設定を追加 <<<<<<END
        
        # endregion

        # region ※Constructor
        /// <summary>
        /// 部位コードマスタ フォームクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 部位コードマスタ フォームクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.17</br>
        /// </remarks>
        public PMKHN09050UA()
        {
            InitializeComponent();

            // データセット列情報構築処理
            DataSetColumnConstruction();

            // プロパティ初期値設定
            this._canPrint = false;
            this._canLogicalDeleteDataExtraction = true;
            this._canClose = true;
            this._canNew = true;
            this._canDelete = true;
            this._defaultGridDisplayLayout = MGridDisplayLayout.Horizontal;
            
            this._mainGridTitle = MAIN_GRID_TITLE;
            this._secondGridTitle = SECOND_GRID_TITLE;
            this._thirdGridTitle = THIRD_GRID_TITLE;

            // 各種インデックス初期化
            this._mainDataIndex = -1;
            this._secondDataIndex = -1;
            this._thirdDataIndex = -1;

            // アイコン用
            this._mainGridIcon = null;
            this._secondGridIcon = null;
            this._thirdGridIcon = null;

            // GridのIndexBuffer格納用変数初期化
            this._mainIndexBuffer = -2;
            this._secondIndexBuffer = -2;
            this._thirdIndexBuffer = -2;
            this._targetTableBuffer = "";

            //　企業コードを取得する
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            // 変数初期化
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
            System.Windows.Forms.Application.Run(new PMKHN09050UA());
        }
        # endregion

        # region Events
        /// <summary>画面非表示イベント</summary>
        /// <remarks>画面が非表示状態になった際に発生します。</remarks>
        public event MasterMaintenanceThreeArrayTypeUnDisplayingEventHandler UnDisplaying;
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

        /// <summary>論理削除済みデータの表示チェックボックス連動プロパティ</summary>
        /// <value>論理削除済みデータの表示のチェックボックスの連動可否を取得します。</value>
        public bool SynchroLogDelFlg
        {
            get { return this._synchroLogDelFlg; }
        }
        # endregion

        # region ※Public Methods

        /// <summary>
        /// 論理削除データ抽出可能設定リスト取得処理
        /// </summary>
        /// <returns>論理削除データ抽出可能設定リスト</returns>
        /// <remarks>
        /// <br>Note       : 論理削除データの抽出が可能かどうかの設定を配列で取得します。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.17</br>
        /// </remarks>
        public bool[] GetCanLogicalDeleteDataExtractionList()
        {
            bool[] logicalDelete = { true, false, false };  // MOD 2008/03/25 不具合対応[12720]：「削除済データの表示」は最上位項目で制御 { false, true, true }→{ true, false, false }
            return logicalDelete;
        }

        /// <summary>
        /// グリッドタイトルリスト取得処理
        /// </summary>
        /// <returns>グリッドタイトルリスト</returns>
        /// <remarks>
        /// <br>Note       : グリッドのタイトルを配列で取得します。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.17</br>
        /// </remarks>
        public string[] GetGridTitleList()
        {
            string[] gridTitle = { _mainGridTitle, _secondGridTitle, _thirdGridTitle };
            return gridTitle;
        }

        /// <summary>
        /// グリッドアイコンリスト取得処理
        /// </summary>
        /// <returns>グリッドアイコンリスト</returns>
        /// <remarks>
        /// <br>Note       : グリッドのアイコンを配列で取得します。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.17</br>
        /// </remarks>
        public Image[] GetGridIconList()
        {
            System.Drawing.Image[] gridIcon = { _mainGridIcon, _secondGridIcon, _thirdGridIcon };
            return gridIcon;
        }

        /// <summary>
        /// グリッド列のサイズの自動調整のデフォルト値リスト取得処理
        /// </summary>
        /// <returns>グリッド列のサイズの自動調整のデフォルト値リスト</returns>
        /// <remarks>
        /// <br>Note       : グリッド列のサイズの自動調整チェックボックスのチェック有無のデフォルト値を配列で取得します。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.17</br>
        /// </remarks>
        public bool[] GetDefaultAutoFillToGridColumnList()
        {
            bool[] defaultAutoFill = { true, true, true };
            return defaultAutoFill;
        }

        /// <summary>
        /// データテーブルの選択データインデックスリスト設定処理
        /// </summary>
        /// <param name="indexList">データテーブルの選択データインデックスリスト</param>
        /// <remarks>
        /// <br>Note       : データテーブルの選択データインデックスリストを設定します。</br>
        /// <br>Programmer : 30413 犬飼</br>
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
        /// 新規ボタンの有効設定リスト取得処理
        /// </summary>
        /// <returns>新規ボタンの有効設定リスト</returns>
        /// <remarks>
        /// <br>Note       : 新規ボタンの有効設定リストを取得します。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.17</br>
        /// </remarks>
        public bool[] GetNewButtonEnabledList()
        {
            bool[] newButtonEnabled = { true, true, false };
            return newButtonEnabled;
        }

        /// <summary>
        /// 修正ボタンの有効設定リスト取得処理
        /// </summary>
        /// <returns>修正ボタンの有効設定リスト</returns>
        /// <remarks>
        /// <br>Note       : 修正ボタンの有効設定リストを取得します。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.17</br>
        /// </remarks>
        public bool[] GetModifyButtonEnabledList()
        {
            bool[] modifyButtonEnabled = { false, true, false };
            return modifyButtonEnabled;
        }

        /// <summary>
        /// 削除ボタンの有効設定リスト取得処理
        /// </summary>
        /// <returns>削除ボタンの有効設定リスト</returns>
        /// <remarks>
        /// <br>Note       : 削除ボタンの有効設定リストを取得します。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.17</br>
        /// </remarks>
        public bool[] GetDeleteButtonEnabledList()
        {
            bool[] deleteButtonEnabled = { false, true, false };
            return deleteButtonEnabled;
        }

        /// <summary>
        /// バインドデータセット取得処理
        /// </summary>
        /// <param name="bindDataSet">グリッド表示用データセット</param>
        /// <param name="tableName">テーブル名称</param>
        /// <remarks>
        /// <br>Note       : グリッドにバインドさせるデータセットを取得します。</br>
        /// <br>Programmer : 30413 犬飼</br>
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
        /// データ検索処理
        /// </summary>
        /// <param name="totalCount">全該当件数</param>
        /// <param name="readCount">抽出対象件数</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 先頭から指定件数分のデータを検索し、抽出結果を展開したDataSetと全該当件数を返します。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.18</br>
        /// </remarks>
        public int Search(ref int totalCount, int readCount)
        {
            int status = 0;

            ArrayList retList = null;

            // ADD 2009/03/25 不具合対応[12720]：「削除済データの表示」は最上位項目で制御 ---------->>>>>
            // 抽出対象件数が負の場合、強制的に終了
            if (readCount < 0)
            {
                // DataSetの情報をクリア
                this.Bind_DataSet.Tables[MAIN_TABLE].Rows.Clear();
                this.Bind_DataSet.Tables[SECOND_TABLE].Rows.Clear();
                this.Bind_DataSet.Tables[THIRD_TABLE].Rows.Clear();
                return 0;
            }
            // ADD 2009/03/25 不具合対応[12720]：「削除済データの表示」は最上位項目で制御 ----------<<<<<

            if (readCount == 0)
            {
                // 抽出対象件数が0の場合は全件抽出を実行する
                status = this._partsPosCodeUAcs.SearchAll(out retList, this._enterpriseCode);

                this._totalCount = retList.Count;
            }

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        // 取得した部位コードクラスをデータセットへ展開する
                        int index = 0;

                        // 共通設定をデータセット展開処理
                        PartsPosCodeU commonPartsPosCodeU = new PartsPosCodeU();
                        PartsPosCodeUToDataSet(commonPartsPosCodeU.Clone(), ref index);

                        foreach (PartsPosCodeU partsPosCodeU in retList)
                        {
                            // 部位コードクラスデータセット展開処理
                            PartsPosCodeUToDataSet(partsPosCodeU.Clone(), ref index);
                        }

                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    {
                        // データが0件の場合
                        int index = 0;
                        
                        // 共通設定をデータセット展開処理
                        PartsPosCodeU partsPosCodeU = new PartsPosCodeU();
                        PartsPosCodeUToDataSet(partsPosCodeU.Clone(), ref index);

                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

                        break;
                    }
                default:
                    {
                        // サーチ結果 部位コードマスタ読み込み失敗
                        TMsgDisp.Show(
                            this, 									    // 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_STOP, 			    // エラーレベル
                            PG_ID,      							    // アセンブリＩＤまたはクラスＩＤ
                            PG_NAME,	        					    // プログラム名称
                            "Search", 								    // 処理名称
                            TMsgDisp.OPE_GET, 						    // オペレーション
                            "部位コード情報の読み込みに失敗しました。", 	// 表示するメッセージ
                            status, 								    // ステータス値
                            this._partsPosCodeUAcs,	 				    // エラーが発生したオブジェクト
                            MessageBoxButtons.OK, 					    // 表示するボタン
                            MessageBoxDefaultButton.Button1);		    // 初期表示ボタン

                        break;
                    }
            }

            // 戻り値セット
            totalCount = this._totalCount;

            // 削除日を再設定
            SetDeleteDateOfFirstTable();    // ADD 2008/03/25 不具合対応[12720]：「削除済データの表示」は最上位項目で制御

            return status;
        }

        /// <summary>
        /// ネクストデータ検索処理
        /// </summary>
        /// <param name="readCount">抽出対象件数</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 指定した件数分のネクストデータを検索します。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.17</br>
        /// </remarks>
        public int SearchNext(int readCount)
        {
            // 未実装
            return 9;
        }

        /// <summary>
        /// データ検索処理(２アレイ目)
        /// </summary>
        /// <param name="totalCount">全該当件数</param>
        /// <param name="readCount">抽出対象件数</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : ガイド区分はDB検索を行わずDataSetに固定情報を設定する。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.10.20</br>
        /// </remarks>
        public int SecondDataSearch(ref int totalCount, int readCount)
        {
            int status = 0;

            ArrayList retList = null;

            int customerCode = int.Parse((string)this.Bind_DataSet.Tables[MAIN_TABLE].Rows[this._mainDataIndex][M_CUSTOMERCODE]);

            // 現在保持しているセカンドGridデータをクリアする
            this.Bind_DataSet.Tables[SECOND_TABLE].Rows.Clear();
            this._secondGridTable.Clear();
            // 現在保持しているサードGridデータをクリアする
            this.Bind_DataSet.Tables[THIRD_TABLE].Rows.Clear();
            this._thirdGridTable.Clear();

            // ADD 2009/03/25 不具合対応[12720]：「削除済データの表示」は最上位項目で制御 ---------->>>>>
            // 抽出対象件数が負の場合、強制的に終了
            if (readCount < 0) return 0;
            // ADD 2009/03/25 不具合対応[12720]：「削除済データの表示」は最上位項目で制御 ----------<<<<<

            if (readCount == 0)
            {
                // 抽出対象件数が0の場合は全件抽出を実行する
                status = this._partsPosCodeUAcs.SearchSelect(customerCode, 0, out retList, this._enterpriseCode);

                this._totalCount = retList.Count;
            }

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        // 取得した部位コードクラスをデータセットへ展開する
                        int index = 0;

                        foreach (PartsPosCodeU partsPosCodeU in retList)
                        {
                            // 部位コードクラスデータセット展開処理
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
                        // サーチ結果 部位コードマスタ読み込み失敗
                        TMsgDisp.Show(
                            this, 									    // 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_STOP, 			    // エラーレベル
                            PG_ID,      							    // アセンブリＩＤまたはクラスＩＤ
                            PG_NAME,	        					    // プログラム名称
                            "SecondDataSearch", 						// 処理名称
                            TMsgDisp.OPE_GET, 						    // オペレーション
                            "部位コード情報の読み込みに失敗しました。", 	// 表示するメッセージ
                            status, 								    // ステータス値
                            this._partsPosCodeUAcs,	 				    // エラーが発生したオブジェクト
                            MessageBoxButtons.OK, 					    // 表示するボタン
                            MessageBoxDefaultButton.Button1);		    // 初期表示ボタン

                        break;
                    }
            }

            // 戻り値セット
            totalCount = this._totalCount;

            return status;
        }

        /// <summary>
        /// ネクストデータ検索処理(２アレイ目)
        /// </summary>
        /// <param name="readCount">抽出対象件数</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note		: ArrayTypeでは未実装</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.10.20</br>
        /// </remarks>
        public int SecondDataSearchNext(int readCount)
        {
            // 未実装
            return 9;
        }

        /// <summary>
        /// データ検索処理(３アレイ目)
        /// </summary>
        /// <param name="totalCount">全該当件数</param>
        /// <param name="readCount">抽出対象件数</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 先頭から指定件数分のデータを検索し、抽出結果を展開したDataSetと全該当件数を返します。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.10.20</br>
        /// </remarks>
        public int ThirdDataSearch(ref int totalCount, int readCount)
        {
            int status = 0;
            ArrayList retList = null;

            // 現在保持しているサードGridデータをクリアする
            this.Bind_DataSet.Tables[THIRD_TABLE].Rows.Clear();
            this._thirdGridTable.Clear();

            // ADD 2009/03/25 不具合対応[12720]：「削除済データの表示」は最上位項目で制御 ---------->>>>>
            // 抽出対象件数が負の場合、強制的に終了
            if (readCount < 0) return 0;
            // ADD 2009/03/25 不具合対応[12720]：「削除済データの表示」は最上位項目で制御 ----------<<<<<

            // Form セカンドGridの情報を取得
            string guid = (string)this.Bind_DataSet.Tables[SECOND_TABLE].Rows[this._secondDataIndex][S_PARTSPOSCODE_GUID];
            PartsPosCodeU secondPartsPosCodeU = ((PartsPosCodeU)this._secondGridTable[guid]).Clone();
            int customerCode = secondPartsPosCodeU.CustomerCode;
            int partsPosCode = secondPartsPosCodeU.SearchPartsPosCode;

            if (readCount == 0)
            {
                // 抽出対象件数が0の場合は全件抽出を実行する
                status = this._partsPosCodeUAcs.SearchSelect(customerCode, partsPosCode, out retList, this._enterpriseCode);

                this._totalCount = retList.Count;
            }

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                    {
                        // 取得した部位コードクラスをデータセットへ展開する
                        int index = 0;
                        SortedList wkSort = new SortedList();

                        foreach (PartsPosCodeU wkPartsPosCodeU in retList)
                        {
                            // 得意先+検索部位コード+検索部位表示順位+BLコード
                            string key = wkPartsPosCodeU.CustomerCode.ToString("d08") + wkPartsPosCodeU.SearchPartsPosCode.ToString("d02")
                                       + wkPartsPosCodeU.PosDispOrder.ToString("d02") + wkPartsPosCodeU.TbsPartsCode.ToString("d05");
                            // 取得した部位コードクラスをソート
                            wkSort.Add(key, wkPartsPosCodeU);
                        }
                        
                        for (int i = 0; i < wkSort.Count; i++)
                        {
                            // 部位コードクラスデータセット展開処理
                            PartsPosCodeUToThirdDataSet(customerCode, (PartsPosCodeU)wkSort.GetByIndex(i), ref index);
                        }

                        break;
                    }
                default:
                    {
                        // サーチ結果 部位コードマスタ読み込み失敗
                        TMsgDisp.Show(
                            this, 								        // 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_STOP, 		        // エラーレベル
                            PG_ID, 						                // アセンブリＩＤまたはクラスＩＤ
                            PG_NAME,        					        // プログラム名称
                            "ThirdDataSearch", 				            // 処理名称
                            TMsgDisp.OPE_GET, 					        // オペレーション
                            "部位コード情報の読み込みに失敗しました。",	// 表示するメッセージ
                            status, 							        // ステータス値
                            this._partsPosCodeUAcs, 				        // エラーが発生したオブジェクト
                            MessageBoxButtons.OK, 				        // 表示するボタン
                            MessageBoxDefaultButton.Button1);	        // 初期表示ボタン

                        break;
                    }
            }

            totalCount = this._totalCount;

            return status;
        }

        /// <summary>
        /// ネクストデータ検索処理(３アレイ目)
        /// </summary>
        /// <param name="readCount">抽出対象件数</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : ArrayTypeでは未実装</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.30</br>
        /// </remarks>
        public int ThirdDataSearchNext(int readCount)
        {
            // 未実装
            return 9;
        }

        /// <summary>
        /// データ削除処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 選択中のデータを削除します。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.20</br>
        /// </remarks>
        public int Delete()
        {
            int status = 0;
            
            ArrayList logDelList = new ArrayList();
            PartsPosCodeU partsPosCodeU = new PartsPosCodeU();

            // Form メインGridの情報を取得
            string guid = (string)this.Bind_DataSet.Tables[SECOND_TABLE].Rows[this._secondDataIndex][S_PARTSPOSCODE_GUID];
            partsPosCodeU = ((PartsPosCodeU)this._secondGridTable[guid]).Clone();
            logDelList.Add(partsPosCodeU);

            if (partsPosCodeU.Division == DIVISION_OFR)
            {
                TMsgDisp.Show(this,
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,
                    PG_ID,
                    "このレコードは提供データのため削除できません",
                    status,
                    MessageBoxButtons.OK);
                this.Hide();

                return -2;
            }

            // Form 詳細Gridの情報を取得
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
                        // 排他処理
                        ExclusiveTransaction(status, TMsgDisp.OPE_DELETE, this._partsPosCodeUAcs);
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
                            this,								// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_STOPDISP,	// エラーレベル
                            PG_ID,	        					// アセンブリＩＤまたはクラスＩＤ
                            PG_NAME,							// プログラム名称
                            "Delete",							// 処理名称
                            TMsgDisp.OPE_HIDE,					// オペレーション
                            ERR_RDEL_MSG,						// 表示するメッセージ 
                            status,								// ステータス値
                            this._partsPosCodeUAcs,				// エラーが発生したオブジェクト
                            MessageBoxButtons.OK,				// 表示するボタン
                            MessageBoxDefaultButton.Button1);	// 初期表示ボタン

                        return status;
                    }
            }

            // データセット展開処理
            int index = 0;
            int logDelCnt = 0;         // 0はメインGrid情報、0以外は詳細Grid情報

            int customerCode = int.Parse((string)this.Bind_DataSet.Tables[MAIN_TABLE].Rows[this._mainDataIndex][M_CUSTOMERCODE]);
                    
            // 論理削除レコードをDataSetに反映
            foreach (PartsPosCodeU wkPartsPosCodeU in logDelList)
            {
                if (logDelCnt == 0)
                {
                    // セカンドGrid
                    index = this._secondDataIndex;
                    PartsPosCodeUToSecondDataSet(customerCode, wkPartsPosCodeU, ref index);
                    logDelCnt++;
                }
                else
                {
                    // サードGrid
                    index = wkPartsPosCodeU.PosDispOrder - 1;
                    PartsPosCodeUToThirdDataSet(customerCode, wkPartsPosCodeU, ref index);

                    // 再検索
                    int totalCount = 0;
                    ThirdDataSearch(ref totalCount, 0); // ADD 2009/03/25 不具合対応[12720]：「削除済データの表示」は最上位項目で制御
                }
            }

            // 削除後にファーストテーブルの削除日を再設定
            SetDeleteDateOfFirstTable();    // ADD 2009/03/25 不具合対応[12720]：「削除済データの表示」は最上位項目で制御

            return status;
        }

        /// <summary>
        /// 印刷処理
        /// </summary>
        /// <param></param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 印刷機能無しの為、未実装。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.17</br>
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
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.17</br>
        /// </remarks>
        public void GetAppearanceTable(out Hashtable[] appearanceTable)
        {
            // メイングリッド
            Hashtable main = new Hashtable();

            main.Add(M_DELETEDATE, new GridColAppearance(MGridColDispType.DeletionDataBoth, ContentAlignment.MiddleLeft, "", Color.Red));   // ADD 2008/03/25 不具合対応[12720]：「削除済データの表示」は最上位項目で制御
            main.Add(M_CUSTOMERCODE, new GridColAppearance(MGridColDispType.ListOnly, ContentAlignment.MiddleRight, "", Color.Black));
            main.Add(M_CUSTOMERNAME, new GridColAppearance(MGridColDispType.ListOnly, ContentAlignment.MiddleLeft, "", Color.Black));
            

            // セカンドグリッド
            Hashtable second = new Hashtable();

            // 削除日
            second.Add(S_DELETEDATE, new GridColAppearance(MGridColDispType.DeletionDataBoth, ContentAlignment.MiddleLeft, "", Color.Red));
            // 部位コード
            second.Add(S_PARTSPOSCODE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            // 部位名称
            second.Add(S_PARTSPOSNAME, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // 部位情報GUID
            second.Add(S_PARTSPOSCODE_GUID, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));


            // サードグリッド
            Hashtable third = new Hashtable();

            // 削除日
            third.Add(T_DELETEDATE, new GridColAppearance(MGridColDispType.DeletionDataBoth, ContentAlignment.MiddleLeft, "", Color.Red));
            // BLｺｰﾄﾞ
            third.Add(T_TBSPARTCODE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            // BLｺｰﾄﾞ名
            third.Add(T_TBSPARTNAME, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // BL情報GUID
            third.Add(T_TBSPARTCODE_GUID, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));

            appearanceTable = new Hashtable[3];
            appearanceTable[0] = main;
            appearanceTable[1] = second;
            appearanceTable[2] = third;
        }

        # endregion

        # region ※Control Events

        /// <summary>
        /// 画面ロードイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントデータ</param>
        /// <remarks>
        /// <br>Note　　　  : ユーザーがフォームを読み込むときに発生します。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.17</br>
        /// </remarks>
        private void PMKHN09050UA_Load(object sender, System.EventArgs e)
        {
            // アイコンリソース管理クラスを使用して、アイコンを表示する
            ImageList imageList24 = IconResourceManagement.ImageList24;
            ImageList imageList16 = IconResourceManagement.ImageList16;

            // ガイドボタンイメージ設定
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

            // --- ADD 2009/03/23 残案件No.14対応------------------------------------------------------>>>>>
            this.Renewal_Button.ImageList = imageList16;
            this.Renewal_Button.Appearance.Image = Size16_Index.RENEWAL;
            // --- ADD 2009/03/23 残案件No.14対応------------------------------------------------------<<<<<

            this.Guid_Button.ImageList = imageList16;
            this.DeleteRow_Button.ImageList = imageList16;

            this.Guid_Button.Appearance.Image = Size16_Index.GUIDE;
            this.DeleteRow_Button.Appearance.Image = Size16_Index.DELETE;

            // 画面初期設定処理
            ScreenInitialSetting();

        }

        /// <summary>
        /// 画面クローズイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントデータ</param>
        /// <remarks>
        /// <br>Note　　　  : ユーザーがフォームを閉じようとした時に発生します。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.17</br>
        /// </remarks>
        private void PMKHN09050UA_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // GridのIndexBuffer格納用変数初期化
            this._mainIndexBuffer = -2;
            this._secondIndexBuffer = -2;
            this._thirdIndexBuffer = -2;
            this._targetTableBuffer = "";

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
        /// <br>Note　　　  : 画面の表示状態が変わったときに発生します。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.17</br>
        /// </remarks>
        private void PMKHN09050UA_VisibleChanged(object sender, System.EventArgs e)
        {
            // 自分自身が非表示になった場合は以下の処理をキャンセルする。
            if (this.Visible == false)
            {
                // メインフレームアクティブ化
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

            // 画面初期化処理
            ScreenClear();

            // 画面表示タイマーON
            Initial_Timer.Enabled = true;
        }

        /// <summary>
        /// 保存ボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントデータ</param>
        /// <remarks>
        /// <br>Note　　　  : 保存ボタンコントロールがクリックされた時に発生します。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.18</br>
        /// </remarks>
        private void Ok_Button_Click(object sender, System.EventArgs e)
        {
            this.Ok_Button.Focus();
            if (!SaveProc())
            {
                return;
            }

            // 画面非表示イベント
            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                UnDisplaying(this, me);
            }

            this.DialogResult = DialogResult.OK;

            // GridのIndexBuffer格納用変数初期化
            this._mainIndexBuffer = -2;
            this._secondIndexBuffer = -2;
            this._targetTableBuffer = "";

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
        /// 閉じるボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントデータ</param>
        /// <remarks>
        /// <br>Note　　　  : 閉じるボタンコントロールがクリックされた時に発生します。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.23</br>
        /// </remarks>
        private void Cancel_Button_Click(object sender, System.EventArgs e)
        {
            // 更新有無フラグ
            bool isUpdate = false;

            // UI画面のGrid行数を取得
            int maxRow = this._bindTable.Rows.Count;

            // 2008.11.19 30413 犬飼 編集中の保存確認処理を修正 >>>>>>START
            ////保存確認
            //PartsPosCodeU[] comparePartsPosCodeU = new PartsPosCodeU[maxRow + 1];
            //if (maxRow > 0)
            //{
            //    // UI画面のGridに1件以上登録されていること
            //    if (this._partsPosCodeUCloneList.Length == comparePartsPosCodeU.Length)
            //    {
            //        // UI画面のGrid行数が同じ場合は更新データの有無を確認
            //        ArrayList updateList = new ArrayList();
            //        ArrayList deleteList = new ArrayList();

            //        UpdateCompare(out updateList, out deleteList);

            //        if ((updateList.Count != 0) || (deleteList.Count != 0))
            //        {
            //            // 更新／削除レコードが有り
            //            isUpdate = true;
            //        }
            //    }
            //    else
            //    {
            //        // 更新前後のGrid行数が不一致の場合は更新
            //        isUpdate = true;
            //    }
            //}

            if (this._secondDataIndex >= 0)
            {
                // 更新モード
                // 保存確認
                if (maxRow > 0)
                {
                    // UI画面のGridに1件以上登録されていること
                    ArrayList updateList = new ArrayList();
                    ArrayList deleteList = new ArrayList();

                    // 更新データの有無を確認
                    UpdateCompare(out updateList, out deleteList);

                    if ((updateList.Count != 0) || (deleteList.Count != 0))
                    {
                        // 更新／削除レコードが有り
                        isUpdate = true;
                    }                    
                }
            }
            else
            {
                // 新規モード
                ArrayList partsList = new ArrayList();
                // 画面情報を取得
                this.DispToPartsPosCodeU(ref partsList);
                if (partsList.Count > 1)
                {
                    // BLコードの設定有
                    isUpdate = true;
                }
                else if (partsList.Count == 1)
                {
                    // 部位の設定のみ
                    PartsPosCodeU compPartsPosCode = new PartsPosCodeU();
                    ArrayList compRet = compPartsPosCode.Compare((PartsPosCodeU)partsList[0]);
                    if (compRet.Count > 1)
                    {
                        // 企業コード以外の設定項目有
                        isUpdate = true;
                    }
                }
            }
            // 2008.11.19 30413 犬飼 編集中の保存確認処理を修正 <<<<<<END
            
            if (isUpdate)
            {
                // 画面情報が変更されていた場合は、保存確認メッセージを表示する
                DialogResult res = TMsgDisp.Show(
                    this, 								// 親ウィンドウフォーム
                    emErrorLevel.ERR_LEVEL_SAVECONFIRM, // エラーレベル
                    PG_ID,       						// アセンブリＩＤまたはクラスＩＤ
                    null, 								// 表示するメッセージ
                    0, 									// ステータス値
                    MessageBoxButtons.YesNoCancel);	// 表示するボタン

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

            // 画面非表示イベント
            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult);
                UnDisplaying(this, me);
            }

            this.DialogResult = DialogResult.Cancel;

            // GridのIndexBuffer格納用変数初期化
            this._mainIndexBuffer = -2;
            this._secondIndexBuffer = -2;
            this._targetTableBuffer = "";

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
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.21</br>
        /// </remarks>
        private void Delete_Button_Click(object sender, System.EventArgs e)
        {
            int status = 0;
            DialogResult result = TMsgDisp.Show(
                this,													// 親ウィンドウフォーム
                emErrorLevel.ERR_LEVEL_QUESTION,						// エラーレベル
                PG_ID,					        						// アセンブリＩＤまたはクラスＩＤ
                "データを削除します。" + "\r\n" + "よろしいですか？",	// 表示するメッセージ 
                0,														// ステータス値
                MessageBoxButtons.OKCancel,								// 表示するボタン
                MessageBoxDefaultButton.Button2);						// 初期表示ボタン


            if (result == DialogResult.OK)
            {
                ArrayList deleteList = new ArrayList();
                PartsPosCodeU partsPosCodeU = new PartsPosCodeU();

                // Form メインGridの情報を取得
                string guid = (string)this.Bind_DataSet.Tables[SECOND_TABLE].Rows[this._secondDataIndex][S_PARTSPOSCODE_GUID];
                partsPosCodeU = ((PartsPosCodeU)this._secondGridTable[guid]).Clone();
                deleteList.Add(partsPosCodeU);

                // Form 詳細Gridの情報を取得
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
                            // Form メインGridと詳細GridのDataSetを削除
                            this.Bind_DataSet.Tables[SECOND_TABLE].Rows[this._secondDataIndex].Delete();
                            this.Bind_DataSet.Tables[THIRD_TABLE].Rows.Clear();

                            // メインGridと詳細Gridのテーブルを削除
                            int delCnt = 0;
                            foreach (PartsPosCodeU wkPartsPosCodeU in deleteList)
                            {
                                if (delCnt == 0)
                                {
                                    // セカンドGridのテーブル
                                    this._secondGridTable.Remove(CreateHashKeySecond(wkPartsPosCodeU));
                                    delCnt++;
                                }
                                else
                                {
                                    // サードGridのテーブル
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
                                this,								  // 親ウィンドウフォーム
                                emErrorLevel.ERR_LEVEL_STOPDISP,	  // エラーレベル
                                PG_ID,      						  // アセンブリＩＤまたはクラスＩＤ
                                PG_NAME,							  // プログラム名称
                                "Delete_Button_Click",				  // 処理名称
                                TMsgDisp.OPE_DELETE,				  // オペレーション
                                ERR_RDEL_MSG,						  // 表示するメッセージ 
                                status,								  // ステータス値
                                this._partsPosCodeUAcs,					  // エラーが発生したオブジェクト
                                MessageBoxButtons.OK,				  // 表示するボタン
                                MessageBoxDefaultButton.Button1);	  // 初期表示ボタン

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
        /// Control.Click イベント(Revive_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note 　　  : 復活ボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.21</br>
        /// </remarks>
        private void Revive_Button_Click(object sender, System.EventArgs e)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            
            ArrayList reviveList = new ArrayList();
            PartsPosCodeU partsPosCodeU = new PartsPosCodeU();

            // Form メインGridの情報を取得
            string guid = (string)this.Bind_DataSet.Tables[SECOND_TABLE].Rows[this._secondDataIndex][S_PARTSPOSCODE_GUID];
            partsPosCodeU = ((PartsPosCodeU)this._secondGridTable[guid]).Clone();
            reviveList.Add(partsPosCodeU);

            // Form 詳細Gridの情報を取得
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
                            this,								  // 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_STOPDISP,	  // エラーレベル
                            PG_ID,		        				  // アセンブリＩＤまたはクラスＩＤ
                            PG_NAME,							  // プログラム名称
                            "Revive_Button_Click",				  // 処理名称
                            TMsgDisp.OPE_UPDATE,				  // オペレーション
                            ERR_RVV_MSG,						  // 表示するメッセージ 
                            status,								  // ステータス値
                            this._partsPosCodeUAcs,				  // エラーが発生したオブジェクト
                            MessageBoxButtons.OK,				  // 表示するボタン
                            MessageBoxDefaultButton.Button1);	  // 初期表示ボタン

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

            // DataSet展開処理
            int index = 0;
            int reviveCnt = 0;         // 0はメインGrid情報、0以外は詳細Grid情報

            int customerCode = int.Parse((string)this.Bind_DataSet.Tables[MAIN_TABLE].Rows[this._mainDataIndex][M_CUSTOMERCODE]);
                    
            // 論理削除レコードをDataSetに反映

            // 再描画を行うので、現在保持しているサードGridデータをクリアする
            this.Bind_DataSet.Tables[THIRD_TABLE].Rows.Clear();
            this._thirdGridTable.Clear();

            foreach (PartsPosCodeU wkPartsPosCodeU in reviveList)
            {
                if (reviveCnt == 0)
                {
                    // セカンドGrid
                    index = this._secondDataIndex;
                    PartsPosCodeUToSecondDataSet(customerCode, wkPartsPosCodeU, ref index);
                    reviveCnt++;
                }
                else
                {
                    // サードGrid
                    index = wkPartsPosCodeU.PosDispOrder - 1;
                    PartsPosCodeUToThirdDataSet(customerCode, wkPartsPosCodeU, ref index);
                }
            }

            // 復活後にファーストテーブルの削除日を再設定
            SetDeleteDateOfFirstTable();    // ADD 2009/03/25 不具合対応[12720]：「削除済データの表示」は最上位項目で制御

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
        /// Timer.Tick イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　  : 指定された間隔の時間が経過したときに発生します。
        ///					  この処理は、システムが提供するスレッド プール
        ///					  スレッドで実行されます。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.18</br>
        /// </remarks>
        private void Initial_Timer_Tick(object sender, System.EventArgs e)
        {
            Initial_Timer.Enabled = false;

            // 画面再構築処理
            ScreenReconstruction();
        }

        /// <summary>
        /// Control.VisibleChange イベント(UI_UltraGrid)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : コントロールの表示状態が変わったときに発生します。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.19</br>
        /// </remarks>
        private void tbsPartsList_ultraGrid_VisibleChanged(object sender, System.EventArgs e)
        {
            // アクティブセル・アクティブ行を無効
            this.tbsPartsList_ultraGrid.ActiveCell = null;
        }

        /// <summary>
        /// UltraGrid.AfterCellActivateイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: セルがアクティブ化された時に発生します。</br>
        /// <br>Programmer : 30413 犬飼</br>
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
        /// Control.KeyDown イベント (UI_UltraGrid)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : キーが押されたときに発生します。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.19</br>
        /// </remarks>
        private void tbsPartsList_ultraGrid_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {

            // アクティブセルがnullの時は処理を行わず終了
            if (this.tbsPartsList_ultraGrid.ActiveCell == null)
            {
                return;                
            }

            // グリッド状態取得()
            Infragistics.Win.UltraWinGrid.UltraGridState status = this.tbsPartsList_ultraGrid.CurrentState;

            // 2008.11.05 30413 ガイドボタンから部位名とOKボタンへ遷移できるように修正 >>>>>>START
            //if ((status & Infragistics.Win.UltraWinGrid.UltraGridState.InEdit) == Infragistics.Win.UltraWinGrid.UltraGridState.InEdit)
            //{

                //ドロップダウン状態の時は処理しない(UltraGridのデフォルトの動きにする)
                Control nextControl = null;
                if ((e.Control == false) && (e.Shift == false) && (e.Alt == false) &&
                    ((status & Infragistics.Win.UltraWinGrid.UltraGridState.IsDroppedDown) != Infragistics.Win.UltraWinGrid.UltraGridState.IsDroppedDown))
                {

                    switch (e.KeyCode)
                    {
                        // ↑キー
                        case Keys.Up:
                            {
                                // 上のセルへ移動
                                nextControl = MoveAboveCell();
                                e.Handled = true;
                                break;
                            }
                        // ↓キー
                        case Keys.Down:
                            {
                                // 下のセルへ移動
                                nextControl = MoveBelowCell();
                                e.Handled = true;
                                break;
                            }
                        // ←キー
                        case Keys.Left:
                            {
                                // 上のセルへ移動
                                nextControl = MoveAboveCell();
                                e.Handled = true;

                                break;
                            }
                        // →キー
                        case Keys.Right:
                            {
                                // 下のセルへ移動
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
                // 2008.11.05 30413 ガイドボタンから部位名とOKボタンへ遷移できるように修正 <<<<<<END

                if (nextControl != null)
                {
                    nextControl.Focus();
                }
            }
        }

        /// <summary>
        ///	ultraGrid.AfterExitEditMode イベント(Cell)
        /// </summary>
        /// <remarks>
        /// <br>Note	   : GRIDのセル編集終了イベント処理。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008/10/21</br>
        /// </remarks>
        private void tbsPartsList_ultraGrid_AfterExitEditMode(object sender, EventArgs e)
        {
            int status = -1;

            if (this.tbsPartsList_ultraGrid.ActiveCell == null) return;

            Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.tbsPartsList_ultraGrid.ActiveCell;

            // BLコード
            if (cell.Column.Key == MY_SCREEN_TBSPARTS_CODE)
            {
                string strCode = cell.Value.ToString();
                this._gridUpdFlg = true;

                if ((strCode != "") && (int.Parse(strCode) != 0))
                {
                    // 入力有
                    int tbsPartsCode = int.Parse(strCode);
                    BLGoodsCdUMnt blGoodsCdUMnt;

                    status = this._blGoodsCdAcs.Read(out blGoodsCdUMnt, this._enterpriseCode, tbsPartsCode);

                    if ((status == 0) && (blGoodsCdUMnt.LogicalDeleteCode == 0))
                    {
                        bool AddFlg = true;     // 追加フラグ
                        int maxRow = this._bindTable.Rows.Count;

                        // BLコードの重複チェック
                        for (int i = 0; i < maxRow; i++)
                        {
                            if (cell.Row.Index == i)
                            {
                                // 同じ行数はSKIP
                                continue;
                            }

                            string wkTbsPartsCode = this._bindTable.Rows[i][MY_SCREEN_TBSPARTS_CODE].ToString();
                            if ((wkTbsPartsCode != "") && (int.Parse(wkTbsPartsCode) == blGoodsCdUMnt.BLGoodsCode))
                            {
                                // 重複コード有
                                AddFlg = false;
                                break;
                            }
                        }

                        if (AddFlg)
                        {
                            // BLコードの追加
                            // 選択した情報をCellに設定
                            cell.Row.Cells[MY_SCREEN_TBSPARTS_CODE].Value = blGoodsCdUMnt.BLGoodsCode.ToString("d05");    // BLコード
                            cell.Row.Cells[MY_SCREEN_TBSPARTS_NAME].Value = blGoodsCdUMnt.BLGoodsFullName;                // BL品名

                            if ((int)cell.Row.Cells[MY_SCREEN_ODER].Value == this._bindTable.Rows.Count)
                            {
                                // 最終行の場合、行を追加
                                this.tbsPartsList_AddRow();
                            }
                        }
                        else
                        {
                            // 重複エラーを表示
                            TMsgDisp.Show(
                                this,								    // 親ウィンドウフォーム
                                emErrorLevel.ERR_LEVEL_EXCLAMATION,	    // エラーレベル
                                PG_ID,      						    // アセンブリＩＤまたはクラスＩＤ
                                "選択したBLｺｰﾄﾞが重複しています。",	    // 表示するメッセージ 
                                0,									    // ステータス値
                                MessageBoxButtons.OK);				    // 表示するボタン

                            // BLコード、BL品名をクリア
                            cell.Row.Cells[MY_SCREEN_TBSPARTS_CODE].Value = "";       // BLコード
                            cell.Row.Cells[MY_SCREEN_TBSPARTS_NAME].Value = "";       // BL品名

                            // Grid変更なし
                            this._gridUpdFlg = false;
                        }
                    }
                    else
                    {
                        // 論理削除データは設定不可
                        TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_INFO,
                            this.Name,
                            "BLｺｰﾄﾞ [" + tbsPartsCode.ToString("d05") + "] に該当するデータが存在しません。",
                            -1,
                            MessageBoxButtons.OK);

                        // BLコード、BL品名をクリア
                        cell.Row.Cells[MY_SCREEN_TBSPARTS_CODE].Value = "";       // BLコード
                        cell.Row.Cells[MY_SCREEN_TBSPARTS_NAME].Value = "";       // BL品名

                        // Grid変更なし
                        this._gridUpdFlg = false;
                    }
                }
                else
                {
                    // 未入力
                    // BLコード、BL品名をクリア
                    cell.Row.Cells[MY_SCREEN_TBSPARTS_CODE].Value = "";       // BLコード
                    cell.Row.Cells[MY_SCREEN_TBSPARTS_NAME].Value = "";       // BL品名
                }
            }
        }

        /// <summary>
        ///	ultraGrid.KeyPress イベント(Cell)
        /// </summary>
        /// <remarks>
        /// <br>Note	   : GRIDのキー押下イベント処理。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008/10/21</br>
        /// </remarks>
        private void tbsPartsList_ultraGrid_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (this.tbsPartsList_ultraGrid.ActiveCell == null) return;
            Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.tbsPartsList_ultraGrid.ActiveCell;

            // BLコードの入力桁数チェック
            if (cell.Column.Key == MY_SCREEN_TBSPARTS_CODE)
            {
                // 編集モード中？
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
        /// 下のセルへ移動処理
        /// </summary>
        /// <returns>次のコントロール</returns>
        /// <remarks>
        /// <br>Note       : BLコードグリッドのアクティブセルを下のセルに移動します。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.19</br>
        /// </remarks>
        private Control MoveBelowCell()
        {
            bool performActionResult;

            // アクティブセルがnull
            if (this.tbsPartsList_ultraGrid.ActiveCell == null)
            {
                return null;
            }

            // グリッド状態取得
            Infragistics.Win.UltraWinGrid.UltraGridState status = this.tbsPartsList_ultraGrid.CurrentState;

            // 最下段セルの時
            if ((status & Infragistics.Win.UltraWinGrid.UltraGridState.RowLast) == Infragistics.Win.UltraWinGrid.UltraGridState.RowLast)
            {
                // 保存ボタンへ移動
                // --- CHG 2009/03/23 残案件No.14対応------------------------------------------------------>>>>>
                //return this.Ok_Button;
                return this.Renewal_Button;
                // --- CHG 2009/03/23 残案件No.14対応------------------------------------------------------<<<<<
            }
            // 最下段セルでない時
            else
            {
                // セル移動前アクティブセルのインデックス
                int prevCol = this.tbsPartsList_ultraGrid.ActiveCell.Column.Index;
                int prevRow = this.tbsPartsList_ultraGrid.ActiveCell.Row.Index;

                // 下のセルに移動
                performActionResult = this.tbsPartsList_ultraGrid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.BelowCell);

                // セルが移動していない時
                if ((prevCol == this.tbsPartsList_ultraGrid.ActiveCell.Column.Index) &&
                    (prevRow == this.tbsPartsList_ultraGrid.ActiveCell.Row.Index))
                {
                    // 保存ボタンへ移動
                    // --- CHG 2009/03/23 残案件No.14対応------------------------------------------------------>>>>>
                    //return this.Ok_Button;
                    return this.Renewal_Button;
                    // --- CHG 2009/03/23 残案件No.14対応------------------------------------------------------<<<<<
                }
                // セルが移動してる
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
        /// 上のセルへ移動処理
        /// </summary>
        /// <returns>次のコントロール</returns>
        /// <remarks>
        /// <br>Note       : BLコードグリッドのアクティブセルを上のセルに移動します。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.19</br>
        /// </remarks>
        private Control MoveAboveCell()
        {
            bool performActionResult;

            // アクティブセルがnull
            if (this.tbsPartsList_ultraGrid.ActiveCell == null)
            {
                return null;
            }

            // グリッド状態取得
            Infragistics.Win.UltraWinGrid.UltraGridState status = this.tbsPartsList_ultraGrid.CurrentState;

            // 最上段セルの時
            if ((status & Infragistics.Win.UltraWinGrid.UltraGridState.RowFirst) == Infragistics.Win.UltraWinGrid.UltraGridState.RowFirst)
            {
                // 移動しない
                //return null;
                // 部位名称へ移動
                return this.PartsPosName_tEdit;
            }
            // 最前セルでない時
            else
            {
                // 上のセルに移動
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
        /// 次入力可能セル移動処理
        /// </summary>
        /// <param name="activeCellCheck">true:ActiveCellが入力可能の場合はNextに移動させない false:ActiveCellに関係なくNextに移動させる</param>
        /// <returns>true:セル移動完了 false:セル移動失敗</returns>
        /// <remarks>
        /// Note			:	次の入力可能なセルにフォーカスを移動する処理を行います。<br />
        /// Programmer		:	30413 犬飼<br />
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
                            // アクティブセルがボタン
                            moved = false;
                            int rowIdx = this.tbsPartsList_ultraGrid.ActiveCell.Row.Index;
                            if ((this._bindTable.Rows[rowIdx][MY_SCREEN_TBSPARTS_CODE].ToString() == "") &&
                                (this._gridUpdFlg))
                            {
                                // BLコードが未入力の場合(BLコード取得失敗等は除く)
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
        /// 前入力可能セル移動処理
        /// </summary>
        /// <param name="activeCellCheck">true:ActiveCellが入力可能の場合はPrevに移動させない false:ActiveCellに関係なくPrevに移動させる</param>
        /// <returns>true:セル移動完了 false:セル移動失敗</returns>
        /// <remarks>
        /// Note			:	前の入力可能なセルにフォーカスを移動する処理を行います。<br />
        /// Programmer		:	30413 犬飼<br />
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
                            // アクティブセルがボタン
                            moved = false;
                            int rowIdx = this.tbsPartsList_ultraGrid.ActiveCell.Row.Index;
                            if (this._bindTable.Rows[rowIdx][MY_SCREEN_TBSPARTS_CODE].ToString() == "")                                
                            {
                                // BLコードが未入力の場合
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
        ///	ultraGrid.Click イベント(Cell Button)
        /// </summary>
        /// <remarks>
        /// <br>Note	   : GRIDのCell Buttonをクリックイベント処理。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008/06/19</br>
        /// </remarks>
        private void tbsPartsList_ultraGrid_ClickCellButton(object sender, CellEventArgs e)
        {
            BLGoodsCdUMnt blGoodsCdUMnt = null;
            // BLコードマスタのガイド表示
            int status = this.ShowBLGoodsCdGuide(out blGoodsCdUMnt);

            if (status == 0)
            {
                bool AddFlg = true;     // 追加フラグ
                int maxRow = this._bindTable.Rows.Count;

                // BLコードの重複チェック
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
                        // 重複コード有
                        AddFlg = false;
                        break;
                    }
                }

                if (AddFlg)
                {
                    // 選択した情報をCellに設定
                    e.Cell.Row.Cells[MY_SCREEN_TBSPARTS_CODE].Value = blGoodsCdUMnt.BLGoodsCode.ToString("d05");    // BLコード
                    e.Cell.Row.Cells[MY_SCREEN_TBSPARTS_NAME].Value = blGoodsCdUMnt.BLGoodsFullName;                // BL品名

                    if ((int)e.Cell.Row.Cells[MY_SCREEN_ODER].Value == this._bindTable.Rows.Count)
                    {
                        // 最終行の場合、行を追加
                        this.tbsPartsList_AddRow();
                    }

                    // 次のコントロールへフォーカスを移動
                    this.MoveNextAllowEditCell(false);
                }
                else
                {
                    // 重複エラーを表示
                    TMsgDisp.Show(
                        this,								    // 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,	    // エラーレベル
                        PG_ID,      						    // アセンブリＩＤまたはクラスＩＤ
                        "選択したBLｺｰﾄﾞが重複しています。",	// 表示するメッセージ 
                        0,									    // ステータス値
                        MessageBoxButtons.OK);				    // 表示するボタン

                    ((Control)sender).Focus();
                }
            }
            else
            {
                ((Control)sender).Focus();
            }
        }

        /// <summary>
        /// Control.Click イベント(DeleteRow_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note 　　  : 削除ボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.19</br>
        /// </remarks>
        private void DeleteRow_Button_Click(object sender, EventArgs e)
        {
            string message = "";

            if (this.tbsPartsList_ultraGrid.Rows.Count < 1)
            {
                // デバッグ用
                this.tbsPartsList_AddRow();
            }

            if (this.tbsPartsList_ultraGrid.ActiveRow == null)
            {
                // 削除する行が未選択
                message = "削除するBLｺｰﾄﾞを選択して下さい。";

                TMsgDisp.Show(
                    this,								// 親ウィンドウフォーム
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,	// エラーレベル
                    PG_ID,      						// アセンブリＩＤまたはクラスＩＤ
                    message,							// 表示するメッセージ 
                    0,									// ステータス値
                    MessageBoxButtons.OK);				// 表示するボタン

                this.tbsPartsList_ultraGrid.Focus();
            }
            else if (this.tbsPartsList_ultraGrid.Rows.Count == 1)
            {
                // Gridの行数が1行の場合は削除不可
                message = "全ての明細削除はできません";

                TMsgDisp.Show(
                    this,								// 親ウィンドウフォーム
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,	// エラーレベル
                    PG_ID,      						// アセンブリＩＤまたはクラスＩＤ
                    message,							// 表示するメッセージ 
                    0,									// ステータス値
                    MessageBoxButtons.OK);				// 表示するボタン

                this.tbsPartsList_ultraGrid.Focus();
            }
            else
            {
                // UI画面のGridから選択行を削除
                // 選択行のindexを取得
                int delIndex = (int)this.tbsPartsList_ultraGrid.ActiveRow.Cells[MY_SCREEN_ODER].Value - 1;

                // 選択行の削除
                this.tbsPartsList_ultraGrid.ActiveRow.Delete();

                // 削除後のGrid行数を取得
                int maxRow = this._bindTable.Rows.Count;

                for (int index = delIndex; index < maxRow; index++)
                {
                    // 削除した行以降の表示順位を更新する
                    this._bindTable.Rows[index][MY_SCREEN_ODER] = index + 1;
                }
            }
        }

        /// <summary>
        /// Control.Click イベント(Guid_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note 　　  : ガイドボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.11.06</br>
        /// </remarks>
        private void Guid_Button_Click(object sender, EventArgs e)
        {
            PartsPosCodeU partsPosCodeU = null;
            string message;
            int status = this.ShowPartsPosCodeGuide(out partsPosCodeU);

            if (status == 0)
            {
                bool AddFlg = true;     // 追加フラグ
                int maxRow = this._bindTable.Rows.Count;

                // BLコードの重複チェック
                for (int i = 0; i < maxRow; i++)
                {
                    string wkTbsPartsCode = this._bindTable.Rows[i][MY_SCREEN_TBSPARTS_CODE].ToString();
                    if ((wkTbsPartsCode != "") && (int.Parse(wkTbsPartsCode) == partsPosCodeU.TbsPartsCode))
                    {
                        // 重複コード有
                        AddFlg = false;
                        break;
                    }
                }

                if (AddFlg)
                {
                    int lastRow = this._bindTable.Rows.Count - 1;

                    if (this._bindTable.Rows[lastRow][MY_SCREEN_TBSPARTS_CODE].ToString() == "")
                    {
                        // 最終行が空き
                        this._bindTable.Rows[lastRow][MY_SCREEN_TBSPARTS_CODE] = partsPosCodeU.TbsPartsCode.ToString("d05");
                        this._bindTable.Rows[lastRow][MY_SCREEN_TBSPARTS_NAME] = partsPosCodeU.TbsPartsName;
                    }
                    else
                    {
                        // ガイドで選択したBLコードを追加
                        DataRow bindRow;

                        bindRow = this._bindTable.NewRow();

                        // BL情報をGridに追加
                        bindRow[MY_SCREEN_ID] = "";
                        bindRow[MY_SCREEN_ODER] = this._bindTable.Rows.Count + 1;
                        bindRow[MY_SCREEN_TBSPARTS_CODE] = partsPosCodeU.TbsPartsCode.ToString("d05");
                        bindRow[MY_SCREEN_TBSPARTS_NAME] = partsPosCodeU.TbsPartsName;

                        this._bindTable.Rows.Add(bindRow);
                    }

                    // 新規行を追加
                    this.tbsPartsList_AddRow();

                    // 次のコントロールへフォーカスを移動
                    this.SelectNextControl((Control)sender, true, true, true, true);
                }
                else
                {
                    // 重複エラーを表示
                    message = "選択したBLｺｰﾄﾞは選択済です。";

                    TMsgDisp.Show(
                        this,								// 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,	// エラーレベル
                        PG_ID,      						// アセンブリＩＤまたはクラスＩＤ
                        message,							// 表示するメッセージ 
                        0,									// ステータス値
                        MessageBoxButtons.OK);				// 表示するボタン

                    ((Control)sender).Focus();
                }
            }
            else if (status == -1)
            {
                // 部位コードが未入力
                message = this.PartsPosCode_Label.Text + "を入力して下さい。";

                TMsgDisp.Show(
                    this,								// 親ウィンドウフォーム
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,	// エラーレベル
                    PG_ID,      						// アセンブリＩＤまたはクラスＩＤ
                    message,							// 表示するメッセージ 
                    0,									// ステータス値
                    MessageBoxButtons.OK);				// 表示するボタン

                this.PartsPosCode_tNedit.Focus();
            }
            else
            {
                ((Control)sender).Focus();
            }
        }

        /// <summary>
        ///	Control.ChangeFocus イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// Note			:	フォーカス移動時に発生します。<br />
        /// Programmer		:	30413 犬飼<br />
        /// Date			:	2008.10.21<br />
        /// </remarks>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null || e.NextCtrl == null) return;

            switch (e.PrevCtrl.Name)
            {
                case "tNedit_CustomerCodeAllowZero":         // 得意先コード
                    {
                        int customerCode = this.tNedit_CustomerCodeAllowZero.GetInt();
                        string customerSnm;

                        if (customerCode != 0)
                        {
                            // 得意先略称の取得
                            this._partsPosCodeUAcs.SerachCustomerInfo(customerCode, this._enterpriseCode, out customerSnm);

                            if (customerSnm != "")
                            {
                                this.CustomerSnm_tEdit.Text = customerSnm;

                                // カーソル制御
                                e.NextCtrl = this.PartsPosCode_tNedit;
                            }
                            else
                            {
                                TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_INFO,
                                this.Name,
                                "該当する得意先データが存在しません。",
                                -1,
                                MessageBoxButtons.OK);

                                // 得意先のクリア
                                this.tNedit_CustomerCodeAllowZero.Clear();
                                this.CustomerSnm_tEdit.Text = "";

                                // カーソル制御
                                e.NextCtrl = e.PrevCtrl;
                            }
                        }
                        else
                        {
                            // 未入力
                            // 得意先のクリア
                            this.tNedit_CustomerCodeAllowZero.Clear();
                            this.CustomerSnm_tEdit.Text = CUSTOMER_SNM_COMMON;
                        }

                        break;
                    }
                case "PartsPosCode_tNedit":         // 部位コード
                    {
                        // カーソル制御
                        if (e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                    {
                                        if ((this.tNedit_CustomerCodeAllowZero.Text != "") && (this.tNedit_CustomerCodeAllowZero.GetInt() != 0))
                                        {
                                            // カーソル制御
                                            e.NextCtrl = tNedit_CustomerCodeAllowZero;
                                        }
                                        break;
                                    }
                            }
                        }

                        // 2009.03.31 30413 犬飼 新規モードからモード変更対応 >>>>>>START
                        //// 得意先コードと部位コードで存在チェック
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
                        //                    "既に登録されています。",
                        //                    -1,
                        //                    MessageBoxButtons.OK);
                        //                this.PartsPosCode_tNedit.Clear();

                        //                // カーソル制御
                        //                e.NextCtrl = e.PrevCtrl;
                        //            }
                        //        }
                        //    }
                        //}
                        // 2009.03.31 30413 犬飼 新規モードからモード変更対応 <<<<<<END
        
                        break;
                    }
                case "PartsPosName_tEdit":          // 部位名称      
                    {
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Return:
                                case Keys.Tab:
                                case Keys.Down:
                                    {
                                        // GRIDのBLｺｰﾄﾞへフォーカス制御
                                        this.tbsPartsList_ultraGrid.Rows[0].Cells[MY_SCREEN_TBSPARTS_CODE].Activate();
                                        this.tbsPartsList_ultraGrid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                                        e.NextCtrl = null;
                                        break;
                                    }
                            }
                        }
                        break;
                    }
                case "DeleteRow_Button":            // GRID削除ボタン
                    {
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Return:
                                case Keys.Tab:
                                    {
                                        // GRIDのBLｺｰﾄﾞへフォーカス制御
                                        this.tbsPartsList_ultraGrid.Rows[0].Cells[MY_SCREEN_TBSPARTS_CODE].Activate();
                                        this.tbsPartsList_ultraGrid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                                        e.NextCtrl = null;
                                        break;
                                    }
                            }
                        }
                        break;
                    }
                case "tbsPartsList_ultraGrid":      // グリッド
                    {
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Return:
                                case Keys.Tab:
                                    {
                                        // ガイドボタンにフォーカスがある
                                        if (this.tbsPartsList_ultraGrid.ActiveCell != null)
                                        {
                                            Infragistics.Win.UltraWinGrid.UltraGridState status = this.tbsPartsList_ultraGrid.CurrentState;

                                            if ((this.tbsPartsList_ultraGrid.ActiveCell.Column.Style == Infragistics.Win.UltraWinGrid.ColumnStyle.Button) &&
                                                (status & Infragistics.Win.UltraWinGrid.UltraGridState.RowLast) == Infragistics.Win.UltraWinGrid.UltraGridState.RowLast)
                                            {
                                                // セルのスタイルがボタンで、セルの最終行の場合
                                                if ((int)this.tbsPartsList_ultraGrid.ActiveCell.Row.Cells[MY_SCREEN_ODER].Value == this._bindTable.Rows.Count)
                                                {
                                                    // 最終行の場合、行を追加
                                                    this.tbsPartsList_AddRow();
                                                }
                                            }
                                        }

                                        // 次のセルへ移動
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
                                            // グリッド内のフォーカス制御
                                            e.NextCtrl = null;
                                        }
                                        else if (e.NextCtrl.Name == "DeleteRow_Button")
                                        {
                                            // グリッド内でのフォーカス制御に失敗した場合、部位名称
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
                                        // GRIDのBLｺｰﾄﾞへフォーカス制御
                                        int rowIdx = this.tbsPartsList_ultraGrid.Rows.Count - 1;
                                        // アクティブ行を最終行に設定
                                        this.tbsPartsList_ultraGrid.ActiveRow = this.tbsPartsList_ultraGrid.Rows[rowIdx];
                                        // アクティブセルをBLコードに設定(フォーカス遷移のため)
                                        this.tbsPartsList_ultraGrid.ActiveCell = this.tbsPartsList_ultraGrid.Rows[rowIdx].Cells[MY_SCREEN_TBSPARTS_CODE];
                                        // BLコードを編集モードにしてフォーカスを移動
                                        this.tbsPartsList_ultraGrid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                                        if (this._bindTable.Rows[rowIdx][MY_SCREEN_TBSPARTS_CODE].ToString() == "")
                                        {
                                            // ガイドボタンへフォーカス移動
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
                                        // GRIDのBLｺｰﾄﾞへフォーカス制御
                                        int rowIdx = this.tbsPartsList_ultraGrid.Rows.Count - 1;
                                        // アクティブ行を最終行に設定
                                        this.tbsPartsList_ultraGrid.ActiveRow = this.tbsPartsList_ultraGrid.Rows[rowIdx];
                                        // アクティブセルをBLコードに設定(フォーカス遷移のため)
                                        this.tbsPartsList_ultraGrid.ActiveCell = this.tbsPartsList_ultraGrid.Rows[rowIdx].Cells[MY_SCREEN_TBSPARTS_CODE];
                                        // BLコードを編集モードにしてフォーカスを移動
                                        this.tbsPartsList_ultraGrid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                                        if (this._bindTable.Rows[rowIdx][MY_SCREEN_TBSPARTS_CODE].ToString() == "")
                                        {
                                            // ガイドボタンへフォーカス移動
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

            // 2009.03.31 30413 犬飼 新規モードからモード変更対応 >>>>>>START
            if (e.NextCtrl != null)
            {
                switch (e.NextCtrl.Name)
                {
                    case "PartsPosName_tEdit":          // 部位名
                    case "tbsPartsList_ultraGrid":      // グリッド
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
            // 2009.03.31 30413 犬飼 新規モードからモード変更対応 <<<<<<END
        }

        /// <summary>
        /// 得意先選択時発生イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="customerSearchRet">得意先車両検索戻り値クラス</param>
        /// <remarks>
        /// <br>Note       : 選択されている計上拠点を設定します</br>
        /// <br>Programmer : 30413 犬飼</br>
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
                // ガイド呼出前と違う、クリアされていない場合
                // 次のコントロールへフォーカスを移動
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }

        /// <summary>
        /// 得意先選択時発生イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="customerSearchRet">得意先マスタクラス</param>
        /// <remarks>
        /// <br>Note       : 選択した得意先情報を設定します</br>
        /// <br>Programmer : 30413 犬飼</br>
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
                // 取得した得意先コードを画面に表示する
                this.tNedit_CustomerCodeAllowZero.SetInt(customerInfo.CustomerCode);
                this.CustomerSnm_tEdit.Text = customerInfo.CustomerSnm;
            }
            else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,
                    this.Name,
                    "選択した得意先は既に削除されています。",
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
                    "得意先情報の取得に失敗しました。",
                    status,
                    MessageBoxButtons.OK);

                return;
            }
        }

        # endregion

        #region Private Methods

        /// <summary>
        /// 部位コードクラスデータセット展開処理(得意先)
        /// </summary>
        /// <param name="partsPosCodeU">部位コードクラス</param>
        /// <param name="index">データセットへ展開するインデックス</param>
        /// <remarks>
        /// <br>Note       : 部位コードクラスをデータセットへ格納します。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.17</br>
        /// </remarks>
        private void PartsPosCodeUToDataSet(PartsPosCodeU partsPosCodeU, ref int index)
        {
            // 同一得意先コードは表示しない
            if (this._mainGridTable.ContainsKey(CreateHashKeyMain(partsPosCodeU)))
            {
                return;
            }

            // メインGridに格納するデータを設定
            if ((index < 0) || (this.Bind_DataSet.Tables[MAIN_TABLE].Rows.Count <= index))
            {
                // 新規と判断して、行を追加する
                DataRow dataRow = this.Bind_DataSet.Tables[MAIN_TABLE].NewRow();
                this.Bind_DataSet.Tables[MAIN_TABLE].Rows.Add(dataRow);

                // indexを行の最終行番号にする
                index = this.Bind_DataSet.Tables[MAIN_TABLE].Rows.Count - 1;
            }

            // ADD 2009/03/25 不具合対応[12720]：「削除済データの表示」は最上位項目で制御 ---------->>>>>
            // 削除日
            if (partsPosCodeU.LogicalDeleteCode == 0)
            {
                this.Bind_DataSet.Tables[MAIN_TABLE].Rows[index][M_DELETEDATE] = "";
            }
            else
            {
                this.Bind_DataSet.Tables[MAIN_TABLE].Rows[index][M_DELETEDATE] = TDateTime.DateTimeToString("ggYY/MM/DD", partsPosCodeU.UpdateDateTime);
            }
            // ADD 2009/03/25 不具合対応[12720]：「削除済データの表示」は最上位項目で制御 ----------<<<<<

            if (partsPosCodeU.CustomerCode != 0)
            {
                // 得意先コード
                this.Bind_DataSet.Tables[MAIN_TABLE].Rows[index][M_CUSTOMERCODE] = partsPosCodeU.CustomerCode.ToString("d08");

                // 得意先略称
                this.Bind_DataSet.Tables[MAIN_TABLE].Rows[index][M_CUSTOMERNAME] = partsPosCodeU.CustomerSnm;
            }
            else
            {
                // 得意先コード
                this.Bind_DataSet.Tables[MAIN_TABLE].Rows[index][M_CUSTOMERCODE] = "00000000";

                // 得意先略称
                this.Bind_DataSet.Tables[MAIN_TABLE].Rows[index][M_CUSTOMERNAME] = CUSTOMER_SNM_COMMON;
            }

            // ハッシュ検索用に得意先コードをセット
            this._mainGridTable.Add(CreateHashKeyMain(partsPosCodeU), partsPosCodeU);

            index++;
        }

        // ADD 2009/03/25 不具合対応[12720]：「削除済データの表示」は最上位項目で制御 ---------->>>>>
        /// <summary>
        /// 第1テーブルの削除日を設定します。
        /// </summary>
        [Conditional("DELETE_DATE_DEPEND_ON_SUB_TABLE")]
        private void SetDeleteDateOfFirstTable()
        {
            ArrayList retList = null;
            int status = this._partsPosCodeUAcs.SearchAll(out retList, this._enterpriseCode);
            if (!status.Equals((int)ConstantManagement.DB_Status.ctDB_NORMAL)) return;
            if (retList == null || retList.Count.Equals(0)) return;

            // 検索結果を得意先コードで分別
            IDictionary<int, IList<PartsPosCodeU>> partsPosCodeUListMap = new Dictionary<int, IList<PartsPosCodeU>>();
            foreach (PartsPosCodeU partsPosCodeU in retList)
            {
                if (!partsPosCodeUListMap.ContainsKey(partsPosCodeU.CustomerCode))
                {
                    partsPosCodeUListMap.Add(partsPosCodeU.CustomerCode, new List<PartsPosCodeU>());
                }
                partsPosCodeUListMap[partsPosCodeU.CustomerCode].Add(partsPosCodeU);
            }

            // 削除日を設定
            foreach (DataRow firstRow in this.Bind_DataSet.Tables[MAIN_TABLE].Rows)
            {
                // 得意先コードを基準
                int customerCode = int.Parse(firstRow[M_CUSTOMERCODE].ToString());
                if (!partsPosCodeUListMap.ContainsKey(customerCode)) continue;

                // 削除日を降順に抽出
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

                // 全て削除されている場合、直近の削除日を設定
                string deleteDate = string.Empty;
                if (deletedRecordCount.Equals(partsPosCodeUListMap[customerCode].Count))
                {
                    deleteDate = deletedPartsPosCodeUList.Values[0].UpdateDateTimeJpInFormal;
                }

                firstRow[M_DELETEDATE] = deleteDate;
            }
        }
        // ADD 2009/03/25 不具合対応[12720]：「削除済データの表示」は最上位項目で制御 ----------<<<<<

        /// <summary>
        /// 部位コードクラスデータセット展開処理(部位)
        /// </summary>
        /// <param name="customerCode">得意先コード</param>
        /// <param name="partsPosCodeU">部位コードクラス</param>
        /// <param name="index">データセットへ展開するインデックス</param>
        /// <remarks>
        /// <br>Note       : 部位コードクラスをデータセットへ格納します。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.17</br>
        /// </remarks>
        private void PartsPosCodeUToSecondDataSet(int customerCode, PartsPosCodeU partsPosCodeU, ref int index)
        {
            // 部位コードの提供区分をチェック
            if (partsPosCodeU.Division != DIVISION_OFR)
            {
                // ユーザー登録データ
                if ((partsPosCodeU.PosDispOrder != 0) || (partsPosCodeU.TbsPartsCode != 0))
                {
                    // 表示順位とBLコードの何れかが0以外なら処理終了
                    return;
                }
            }
            else
            {
                // 提供データ
                if (this._mainGridTable.ContainsKey(CreateHashKeySecond(partsPosCodeU)) == true)
                {
                    // 該当データがメインGridに登録済なら処理終了（重複チェック）
                    return;
                }
            }

            // 得意先コードのチェック
            if (customerCode != partsPosCodeU.CustomerCode)
            {
                // 共通設定用で、得意先コードが不一致なら処理終了
                return;
            }

            // メインGridに格納するデータを設定
            if ((index < 0) || (this.Bind_DataSet.Tables[SECOND_TABLE].Rows.Count <= index))
            {
                // 新規と判断して、行を追加する
                DataRow dataRow = this.Bind_DataSet.Tables[SECOND_TABLE].NewRow();
                this.Bind_DataSet.Tables[SECOND_TABLE].Rows.Add(dataRow);

                // indexを行の最終行番号にする
                index = this.Bind_DataSet.Tables[SECOND_TABLE].Rows.Count - 1;
            }

            // 削除日
            if (partsPosCodeU.LogicalDeleteCode == 0)
            {
                this.Bind_DataSet.Tables[SECOND_TABLE].Rows[index][S_DELETEDATE] = "";
            }
            else
            {
                this.Bind_DataSet.Tables[SECOND_TABLE].Rows[index][S_DELETEDATE] = TDateTime.DateTimeToString("ggYY/MM/DD", partsPosCodeU.UpdateDateTime);
            }

            // 部位コード
            this.Bind_DataSet.Tables[SECOND_TABLE].Rows[index][S_PARTSPOSCODE] = partsPosCodeU.SearchPartsPosCode.ToString("d02");

            // 部位名称
            this.Bind_DataSet.Tables[SECOND_TABLE].Rows[index][S_PARTSPOSNAME] = partsPosCodeU.SearchPartsPosName;

            // 部位情報GUID
            this.Bind_DataSet.Tables[SECOND_TABLE].Rows[index][S_PARTSPOSCODE_GUID] = CreateHashKeySecond(partsPosCodeU);

            // ハッシュ検索用にGUIDセット
            if (this._secondGridTable.ContainsKey(CreateHashKeySecond(partsPosCodeU)) == true)
            {
                this._secondGridTable.Remove(CreateHashKeySecond(partsPosCodeU));
            }
            this._secondGridTable.Add(CreateHashKeySecond(partsPosCodeU), partsPosCodeU);

            index++;

        }

        /// <summary>
        /// 部位コードクラスデータセット展開処理(BLｺｰﾄﾞ)
        /// </summary>
        /// <param name="partsPosCodeU">部位コードクラス</param>
        /// <param name="index">データセットへ展開するインデックス</param>
        /// <remarks>
        /// <br>Note       : 部位コードクラスを詳細GRIDデータセットへ格納します。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.18</br>
        /// </remarks>
        private void PartsPosCodeUToThirdDataSet(int customerCode, PartsPosCodeU partsPosCodeU, ref int index)
        {
            // Form メインGridの情報を取得
            string guid = (string)this.Bind_DataSet.Tables[SECOND_TABLE].Rows[this._secondDataIndex][S_PARTSPOSCODE_GUID];
            PartsPosCodeU secondPartsPosCodeU = ((PartsPosCodeU)this._secondGridTable[guid]).Clone();
            int mainDivision = secondPartsPosCodeU.Division;

            // 提供区分のチェック
            if (partsPosCodeU.Division != mainDivision)
            {
                // メインGridの提供区分と違う場合は処理終了
                return;
            }
            else
            {
                // メインGridと提供区分が一致
                if (partsPosCodeU.Division != DIVISION_OFR)
                {
                    // ユーザー登録データ
                    if ((partsPosCodeU.PosDispOrder == 0) || (partsPosCodeU.TbsPartsCode == 0))
                    {
                        // 表示順位とBLコードの何れかが0の場合は処理終了
                        return;
                    }
                }
            }

            // 得意先コードのチェック
            if (customerCode != partsPosCodeU.CustomerCode)
            {
                // 共通設定用で、得意先コードが不一致なら処理終了
                return;
            }

            // 詳細Gridに格納するデータを設定
            if ((index < 0) || (this.Bind_DataSet.Tables[THIRD_TABLE].Rows.Count <= index))
            {
                // 新規と判断して、行を追加する
                DataRow dataRow = this.Bind_DataSet.Tables[THIRD_TABLE].NewRow();
                this.Bind_DataSet.Tables[THIRD_TABLE].Rows.Add(dataRow);

                // indexを行の最終行番号する
                index = this.Bind_DataSet.Tables[THIRD_TABLE].Rows.Count - 1;
            }

            // 削除日
            if (partsPosCodeU.LogicalDeleteCode == 0)
            {
                this.Bind_DataSet.Tables[THIRD_TABLE].Rows[index][T_DELETEDATE] = "";
            }
            else
            {
                this.Bind_DataSet.Tables[THIRD_TABLE].Rows[index][T_DELETEDATE] = TDateTime.DateTimeToString("ggYY/MM/DD", partsPosCodeU.UpdateDateTime);
            }

            // BLｺｰﾄﾞ
            this.Bind_DataSet.Tables[THIRD_TABLE].Rows[index][T_TBSPARTCODE] = partsPosCodeU.TbsPartsCode.ToString("d05");

            // BL品名
            this.Bind_DataSet.Tables[THIRD_TABLE].Rows[index][T_TBSPARTNAME] = partsPosCodeU.TbsPartsName;

            // BL情報GUID
            this.Bind_DataSet.Tables[THIRD_TABLE].Rows[index][T_TBSPARTCODE_GUID] = CreateHashKeyThird(partsPosCodeU);

            // ハッシュ検索用にGUIDセット
            if (this._thirdGridTable.ContainsKey(CreateHashKeyThird(partsPosCodeU)) == true)
            {
                this._thirdGridTable.Remove(CreateHashKeyThird(partsPosCodeU));
            }
            this._thirdGridTable.Add(CreateHashKeyThird(partsPosCodeU), partsPosCodeU);

            index++;
        }

        /// <summary>
        /// 部位コードマスタ クラス画面展開処理
        /// </summary>
        /// <param name="partsPosCodeU">部位コードマスタ オブジェクト</param>
        /// <remarks>
        /// <br>Note       : 部位コードマスタ オブジェクトから画面にデータを展開します。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.18</br>
        /// </remarks>
        private void PartsPosCodeUToScreen(PartsPosCodeU[] partsPosCodeU)
        {
            int i = 0;
            int maxRow;
            DataRow bindRow;

            this.tNedit_CustomerCodeAllowZero.SetInt(partsPosCodeU[i].CustomerCode);    // 得意先コード
            if (partsPosCodeU[i].CustomerCode == 0)
            {
                this.CustomerSnm_tEdit.Text = CUSTOMER_SNM_COMMON;                      // 得意先略称
            }
            else
            {
                this.CustomerSnm_tEdit.Text = partsPosCodeU[i].CustomerSnm;             // 得意先略称
            }
            this.PartsPosCode_tNedit.SetInt(partsPosCodeU[i].SearchPartsPosCode);       // 部位コード
            this.PartsPosName_tEdit.Text = partsPosCodeU[i].SearchPartsPosName;         // 部位名称

            maxRow = partsPosCodeU.Length;
            for (i = 1; i < maxRow; i++)
            {
                bindRow = this._bindTable.NewRow();

                bindRow[MY_SCREEN_ID] = "";                                             // GridのID(非表示)
                bindRow[MY_SCREEN_ODER] = i;                                            // 表示順位
                bindRow[MY_SCREEN_TBSPARTS_CODE] = partsPosCodeU[i].TbsPartsCode.ToString("d05");       // BLコード
                bindRow[MY_SCREEN_TBSPARTS_NAME] = partsPosCodeU[i].TbsPartsName;       // BL品名

                this._bindTable.Rows.Add(bindRow);
            }
        }

        /// <summary>
        /// 画面情報部位コードマスタ クラス格納処理
        /// </summary>
        /// <param name="partsPosCodeUList">部位コードマスタ オブジェクト</param>
        /// <remarks>
        /// <br>Note       : 画面情報から部位コードマスタ オブジェクトにデータを格納します。</br>
        /// <br>Programmer : 30413 犬飼</br>
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
                
                partsPosCodeU.EnterpriseCode = this._enterpriseCode;                                            // 企業コード
                partsPosCodeU.CustomerCode = this.tNedit_CustomerCodeAllowZero.GetInt();                        // 得意先コード
                partsPosCodeU.SearchPartsPosCode = this.PartsPosCode_tNedit.GetInt();                           // 部位コード

                if (index == 0)
                {
                    // メインGRID用の情報取得
                    partsPosCodeU.SearchPartsPosName = this.PartsPosName_tEdit.Text.TrimEnd();                  // 部位名称
                }
                else
                {
                    // 未入力BLｺｰﾄﾞはSKIP
                    string strBlCode = (string)this._bindTable.Rows[index - 1][MY_SCREEN_TBSPARTS_CODE];
                    if (strBlCode == "")
                    {
                        continue;
                    }

                    // 詳細GRID用の情報取得
                    partsPosCodeU.PosDispOrder = (int)this._bindTable.Rows[index - 1][MY_SCREEN_ODER];          // 表示順位
                    partsPosCodeU.TbsPartsCode = Int32.Parse(strBlCode);                                        // BLコード
                    partsPosCodeU.TbsPartsName = this._bindTable.Rows[index - 1][MY_SCREEN_TBSPARTS_NAME].ToString();   // BL品名
                }
                partsPosCodeUList.Add(partsPosCodeU);
            }
        }

        /// <summary>
        /// データセット列情報構築処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : DataSetの列情報を構築します。データセットの列情報がフレームのビュー用グリッドの列になります。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.17</br>
        /// </remarks>
        private void DataSetColumnConstruction()
        {
            // メインテーブルの列定義
            DataTable _mainDt = new DataTable(MAIN_TABLE);

            // Addを行う順番が、列の表示順位となります。
            // ADD 2009/03/25 不具合対応[12720]↓：「削除済データの表示」は最上位項目で制御
            _mainDt.Columns.Add(M_DELETEDATE, typeof(string));              // 削除日
            _mainDt.Columns.Add(M_CUSTOMERCODE, typeof(string));            // 得意先コード
            _mainDt.Columns.Add(M_CUSTOMERNAME, typeof(string));            // 得意先略称
            this.Bind_DataSet.Tables.Add(_mainDt);

            // セカンドテーブルの列定義
            DataTable _secondDt = new DataTable(SECOND_TABLE);

            // Addを行う順番が、列の表示順位となります。
            _secondDt.Columns.Add(S_DELETEDATE, typeof(string));            // 削除日
            _secondDt.Columns.Add(S_PARTSPOSCODE, typeof(string));			// 部位コード
            _secondDt.Columns.Add(S_PARTSPOSNAME, typeof(string));			// 部位名称
            _secondDt.Columns.Add(S_PARTSPOSCODE_GUID, typeof(string));     // 部位情報GUID

            this.Bind_DataSet.Tables.Add(_secondDt);

            // サードテーブルの列定義
            DataTable _detailDt = new DataTable(THIRD_TABLE);

            // Addを行う順番が、列の表示順位となります。
            _detailDt.Columns.Add(T_DELETEDATE, typeof(string));			// 削除日
            _detailDt.Columns.Add(T_TBSPARTCODE, typeof(string));			// BLｺｰﾄﾞ
            _detailDt.Columns.Add(T_TBSPARTNAME, typeof(string));			// BL品名
            _detailDt.Columns.Add(T_TBSPARTCODE_GUID, typeof(string));      // BL情報GUID

            this.Bind_DataSet.Tables.Add(_detailDt);
        }

        /// <summary>
        /// 画面初期設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面の初期設定を行います。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.19</br>
        /// </remarks>
        private void ScreenInitialSetting()
        {
            // スキーマの設定
            DataTableSchemaSetting();

            // GRIDの初期設定
            GridInitialSetting();
        }

        /// <summary>
        /// 画面再構築処理
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : モードに基づいて画面の再構築を行います。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.18</br>
        /// </remarks>
        private void ScreenReconstruction()
        {
            if (this._secondDataIndex < 0)
            {
                // 新規モード
                this.Mode_Label.Text = INSERT_MODE;

                // 画面入力許可制御処理
                ScreenPermissionControl(INSERT_MODE);

                // FreamのIndex/Tableバッファ保持
                this._mainIndexBuffer = this._mainDataIndex;
                this._secondIndexBuffer = this._secondDataIndex;
                this._targetTableBuffer = this._targetTableName;

                //クローン作成
                PartsPosCodeU partsPosCodeU = new PartsPosCodeU();
                // 2009.02.16 30413 犬飼 部位層で新規ボタンの対応 >>>>>>START
                if (this._mainDataIndex >= 0)
                {
                    string customerCode = (string)this.Bind_DataSet.Tables[MAIN_TABLE].Rows[this._mainDataIndex][M_CUSTOMERCODE];
                    partsPosCodeU = ((PartsPosCodeU)this._mainGridTable[customerCode]).Clone();

                    this.tNedit_CustomerCodeAllowZero.SetInt(partsPosCodeU.CustomerCode);
                    this.CustomerSnm_tEdit.Text = partsPosCodeU.CustomerSnm;
                }
                // 2009.02.16 30413 犬飼 部位層で新規ボタンの対応 <<<<<<END
                this._partsPosCodeUCloneList = new PartsPosCodeU[1];
                this._partsPosCodeUCloneList[0] = partsPosCodeU.Clone();
                
                // グリッド行を追加
                this.tbsPartsList_AddRow();

                // フォーカス設定
                this.tNedit_CustomerCodeAllowZero.Focus();
            }
            else
            {
                // メインGrid + 詳細Gridの行数を取得
                int rowCnt = 0;         // 行数カウンタ(0はメインGrid情報、0以外は詳細Grid情報)
                int maxRow = this.Bind_DataSet.Tables[THIRD_TABLE].Rows.Count;
                PartsPosCodeU[] partsPosCodeUList = new PartsPosCodeU[maxRow + 1];

                // 選択部位の情報を取得
                string partsGuid = (string)this.Bind_DataSet.Tables[SECOND_TABLE].Rows[this._secondDataIndex][S_PARTSPOSCODE_GUID];
                partsPosCodeUList[rowCnt] = ((PartsPosCodeU)this._secondGridTable[partsGuid]).Clone();
                rowCnt++;

                // BL情報を取得
                for (; rowCnt <= maxRow; rowCnt++)
                {
                    string guid = (string)this.Bind_DataSet.Tables[THIRD_TABLE].Rows[rowCnt - 1][T_TBSPARTCODE_GUID];
                    partsPosCodeUList[rowCnt] = ((PartsPosCodeU)this._thirdGridTable[guid]).Clone();
                }

                if (partsPosCodeUList[0].LogicalDeleteCode == 0)
                {
                    // 画面入力許可制御処理
                    if (partsPosCodeUList[0].Division == DIVISION_OFR)
                    {
                        // 参照モード
                        this.Mode_Label.Text = REFERENCE_MODE;

                        // 画面入力許可制御処理
                        ScreenPermissionControl(REFERENCE_MODE);

                        // 画面展開処理
                        PartsPosCodeUToScreen(partsPosCodeUList);

                        //クローン作成
                        this._partsPosCodeUCloneList = new PartsPosCodeU[maxRow + 1];
                        for (int i = 0; i < maxRow + 1; i++)
                        {
                            this._partsPosCodeUCloneList[i] = partsPosCodeUList[i].Clone();
                        }
                        
                        // フォーカス設定
                        this.Cancel_Button.Focus();
                    }
                    else
                    {
                        // 更新モード
                        this.Mode_Label.Text = UPDATE_MODE;

                        // 画面入力許可制御処理
                        ScreenPermissionControl(UPDATE_MODE);

                        // 画面展開処理
                        PartsPosCodeUToScreen(partsPosCodeUList);
                        
                        //クローン作成
                        this._partsPosCodeUCloneList = new PartsPosCodeU[maxRow + 1];
                        for (int i = 0; i < maxRow + 1; i++)
                        {
                            this._partsPosCodeUCloneList[i] = partsPosCodeUList[i].Clone();
                        }

                        // 更新モードの場合、追加用の行を用意する
                        this.tbsPartsList_AddRow();

                        // フォーカス設定
                        this.PartsPosName_tEdit.Focus();
                        this.PartsPosName_tEdit.SelectAll();
                    }
                }
                else
                {
                    // 削除モード
                    this.Mode_Label.Text = DELETE_MODE;

                    // 画面入力許可制御処理
                    ScreenPermissionControl(DELETE_MODE);

                    // 画面展開処理
                    PartsPosCodeUToScreen(partsPosCodeUList);

                    // 2008.10.31 30413 犬飼 削除モード時はグリッド選択は行わない >>>>>>START
                    this.tbsPartsList_ultraGrid.Rows[0].Selected = false;
                    this.tbsPartsList_ultraGrid.ActiveCell = null;
                    this.tbsPartsList_ultraGrid.ActiveRow = null;
                    // 2008.10.31 30413 犬飼 削除モード時はグリッド選択は行わない <<<<<<END
                    
                    //クローン作成
                    this._partsPosCodeUCloneList = new PartsPosCodeU[maxRow + 1];
                    for (int i = 0; i < maxRow + 1; i++)
                    {
                        this._partsPosCodeUCloneList[i] = partsPosCodeUList[i].Clone();
                    }
                    
                    // フォーカス設定
                    this.Delete_Button.Focus();
                }

                // FreamのIndex/Tableバッファ保持
                this._mainIndexBuffer = this._mainDataIndex;
                this._secondIndexBuffer = this._secondDataIndex;
                this._targetTableBuffer = this._targetTableName;
            }
        }

        /// <summary>
        /// 画面許可制御処理
        /// </summary>
        /// <param name="screenMode">画面モード</param>
        /// <remarks>
        /// <br>Note       : 画面モード毎に入力／ボタンの許可を制御します。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.17</br>
        /// </remarks>
        private void ScreenPermissionControl(string screenMode)
        {
            // 新規
            if (screenMode.Equals(INSERT_MODE))
            {
                // ボタン設定
                this.CustomerCd_GuideBtn.Enabled = true;
                this.Ok_Button.Visible = true;
                this.Delete_Button.Visible = false;
                this.Revive_Button.Visible = false;
                this.DeleteRow_Button.Visible = true;
                this.DeleteRow_Button.Enabled = true;
                this.Guid_Button.Visible = true;
                this.Guid_Button.Enabled = true;
                // --- ADD 2009/03/23 残案件No.14対応------------------------------------------------------>>>>>
                this.Renewal_Button.Visible = true;
                // --- ADD 2009/03/23 残案件No.14対応------------------------------------------------------<<<<<

                // 入力設定
                this.tNedit_CustomerCodeAllowZero.Enabled = true;
                this.PartsPosCode_tNedit.Enabled = true;
                this.PartsPosName_tEdit.Enabled = true;
                this.tbsPartsList_ultraGrid.Enabled = true;
                this.tbsPartsList_ultraGrid.DisplayLayout.Bands[0].Columns[MY_SCREEN_GUID].CellActivation = Activation.NoEdit;
            }
            // 更新
            else if (screenMode.Equals(UPDATE_MODE))
            {
                // ボタン設定
                this.CustomerCd_GuideBtn.Enabled = false;
                this.Ok_Button.Visible = true;
                this.Delete_Button.Visible = false;
                this.Revive_Button.Visible = false;
                this.DeleteRow_Button.Visible = true;
                this.DeleteRow_Button.Enabled = true;
                this.Guid_Button.Visible = true;
                this.Guid_Button.Enabled = true;
                // --- ADD 2009/03/23 残案件No.14対応------------------------------------------------------>>>>>
                this.Renewal_Button.Visible = true;
                // --- ADD 2009/03/23 残案件No.14対応------------------------------------------------------<<<<<

                // 入力設定
                this.tNedit_CustomerCodeAllowZero.Enabled = false;
                this.PartsPosCode_tNedit.Enabled = false;
                this.PartsPosName_tEdit.Enabled = true;
                this.tbsPartsList_ultraGrid.Enabled = true;
                this.tbsPartsList_ultraGrid.DisplayLayout.Bands[0].Columns[MY_SCREEN_GUID].CellActivation = Activation.NoEdit;
            }
            // 削除
            else if (screenMode.Equals(DELETE_MODE))
            {
                // ボタン設定
                this.CustomerCd_GuideBtn.Enabled = false;
                this.Ok_Button.Visible = false;
                this.Delete_Button.Visible = true;
                this.Revive_Button.Visible = true;
                this.DeleteRow_Button.Visible = true;
                this.DeleteRow_Button.Enabled = false;
                this.Guid_Button.Visible = true;
                this.Guid_Button.Enabled = false;
                // --- ADD 2009/03/23 残案件No.14対応------------------------------------------------------>>>>>
                this.Renewal_Button.Visible = false;
                // --- ADD 2009/03/23 残案件No.14対応------------------------------------------------------<<<<<

                // 入力設定
                this.tNedit_CustomerCodeAllowZero.Enabled = false;
                this.PartsPosCode_tNedit.Enabled = false;
                this.PartsPosName_tEdit.Enabled = false;
                this.tbsPartsList_ultraGrid.Enabled = false;
                this.tbsPartsList_ultraGrid.DisplayLayout.Bands[0].Columns[MY_SCREEN_GUID].CellActivation = Activation.Disabled;
            }
            // 参照
            else if (screenMode.Equals(REFERENCE_MODE))
            {
                // ボタン設定
                this.CustomerCd_GuideBtn.Enabled = false;
                this.Ok_Button.Visible = false;
                this.Delete_Button.Visible = false;
                this.Revive_Button.Visible = false;
                this.DeleteRow_Button.Visible = true;
                this.DeleteRow_Button.Enabled = false;
                this.Guid_Button.Visible = true;
                this.Guid_Button.Enabled = false;
                // --- ADD 2009/03/23 残案件No.14対応------------------------------------------------------>>>>>
                this.Renewal_Button.Visible = false;
                // --- ADD 2009/03/23 残案件No.14対応------------------------------------------------------<<<<<

                // 入力設定
                this.tNedit_CustomerCodeAllowZero.Enabled = false;
                this.PartsPosCode_tNedit.Enabled = false;
                this.PartsPosName_tEdit.Enabled = false;
                this.tbsPartsList_ultraGrid.Enabled = false;
                this.tbsPartsList_ultraGrid.DisplayLayout.Bands[0].Columns[MY_SCREEN_GUID].CellActivation = Activation.Disabled;
            }
        }

        /// <summary>
        /// 画面初期化処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面の初期化を行います。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.17</br>
        /// </remarks>
        private void ScreenClear()
        {
            this.tNedit_CustomerCodeAllowZero.Clear();  // 得意先コード
            this.CustomerSnm_tEdit.Text = "";           // 得意先略称
            this.PartsPosCode_tNedit.Clear();           // 部位コード
            this.PartsPosName_tEdit.Text = "";          // 部位名称

            this._bindTable.Rows.Clear();               // Grid行のクリア

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
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.17</br>
        /// </remarks>
        private bool ScreenDataCheck(ref Control control, ref string message, string loginID)
        {
            // 部位コード
            if (this.PartsPosCode_tNedit.Text == "0" || this.PartsPosCode_tNedit.Text.Trim() == "")
            {
                control = this.PartsPosCode_tNedit;
                message = this.PartsPosCode_Label.Text + "を入力して下さい。";
                return false;
            }

            // Grid
            if (this._bindTable.Rows.Count == 0)
            {
                control = this.tbsPartsList_ultraGrid;
                message = "BLｺｰﾄﾞを１件以上登録して下さい。";
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
                    message = "BLｺｰﾄﾞが登録されていません。";
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// 部位コードマスタ 情報登録処理
        /// </summary>
        /// <returns>登録結果（true:OK／false:NG）</returns>
        /// <remarks>
        /// <br>Note       : 部位コードマスタ 情報登録を行います。</br>
        /// <br>Programmer : 30413 犬飼</br>
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

            // 画面入力チェック
            if (!ScreenDataCheck(ref control, ref message, loginID))
            {
                TMsgDisp.Show(
                    this,								// 親ウィンドウフォーム
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,	// エラーレベル
                    PG_ID,      						// アセンブリＩＤまたはクラスＩＤ
                    message,							// 表示するメッセージ 
                    0,									// ステータス値
                    MessageBoxButtons.OK);				// 表示するボタン

                control.Focus();
                return false;
            }

            if (this._secondDataIndex >= 0)
            {
                // 更新時は、更新対象と削除対象を取得
                this.UpdateCompare(out updateList, out deleteList);
                
                // 削除対象があれば該当レコードを削除
                if (deleteList.Count != 0)
                {
                    status = this._partsPosCodeUAcs.Delete(deleteList);
                }
            }
            else
            {
                //新規の場合、画面情報を条件クラスに設定
                this.DispToPartsPosCodeU(ref updateList);
            }

            // 登録／更新処理
            if (status == 0)
            {
                // 削除処理を行った場合、成功していることが前提
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
                            this,								// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_EXCLAMATION,	// エラーレベル
                            PG_ID,				        		// アセンブリＩＤまたはクラスＩＤ
                            ERR_DPR_MSG,						// 表示するメッセージ 
                            status,								// ステータス値
                            MessageBoxButtons.OK);				// 表示するボタン

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
                            this,								// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_STOPDISP,	// エラーレベル
                            PG_ID,      						// アセンブリＩＤまたはクラスＩＤ
                            PG_NAME,							// プログラム名称
                            "SaveProc",							// 処理名称
                            TMsgDisp.OPE_UPDATE,				// オペレーション
                            ERR_UPDT_MSG,						// 表示するメッセージ 
                            status,								// ステータス値
                            this._partsPosCodeUAcs,				// エラーが発生したオブジェクト
                            MessageBoxButtons.OK,				// 表示するボタン
                            MessageBoxDefaultButton.Button1);	// 初期表示ボタン

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

            // DataSet展開処理
            int index = 0;
            int delCnt = 1;         // 削除は上詰めのため、削除した件数を保持して対応

            //int customerCode = int.Parse((string)this.Bind_DataSet.Tables[MAIN_TABLE].Rows[this._mainDataIndex][M_CUSTOMERCODE]);
            int customerCode;
                    
            if (this._mainDataIndex >= 0)
            {
                // 削除可能なDataSetの行数を取得
                int delOK = deleteList.Count - updateList.Count;
                
                foreach (PartsPosCodeU partsPosCodeU in deleteList)
                {
                    // 削除レコードを詳細GridのTableから削除
                    this._thirdGridTable.Remove(CreateHashKeyThird(partsPosCodeU));
                    
                    if(delOK > 0)
                    {
                        // 更新レコードが反映されないDataSet行を削除
                        index = partsPosCodeU.PosDispOrder - delCnt;
                        this.Bind_DataSet.Tables[THIRD_TABLE].Rows[index].Delete();
                        delOK--;
                    }
                    delCnt++;
                }
                
                // 得意先コードを取得
                customerCode = int.Parse((string)this.Bind_DataSet.Tables[MAIN_TABLE].Rows[this._mainDataIndex][M_CUSTOMERCODE]);

                // 2009.02.16 30413 犬飼 部位層で新規ボタンの対応 >>>>>>START
                if (this._secondDataIndex < 0)
                {
                    // メインGridのDataSetに追加
                    index = this._mainGridTable.Count;
                    PartsPosCodeUToDataSet(((PartsPosCodeU)updateList[0]).Clone(), ref index);

                    customerCode = int.Parse((string)this.Bind_DataSet.Tables[MAIN_TABLE].Rows[index - 1][M_CUSTOMERCODE]);
                }
                // 2009.02.16 30413 犬飼 部位層で新規ボタンの対応 <<<<<<END
                
                // 更新レコードをDataSetに反映
                foreach (PartsPosCodeU partsPosCodeU in updateList)
                {
                    //// メインGridのDataSetを更新
                    //index = this._mainDataIndex;
                    //PartsPosCodeUToDataSet(partsPosCodeU.Clone(), ref index);
                    // セカンドGridのDataSetを更新
                    index = this._secondDataIndex;
                    PartsPosCodeUToSecondDataSet(customerCode, partsPosCodeU.Clone(), ref index);
                    // 2009.02.16 30413 犬飼 部位層で新規ボタンの対応 >>>>>>START
                    // サードGrid
                    //index = partsPosCodeU.PosDispOrder - 1;
                    //PartsPosCodeUToThirdDataSet(customerCode, partsPosCodeU.Clone(), ref index);
                    if (this._secondDataIndex >= 0)
                    {
                        index = partsPosCodeU.PosDispOrder - 1;
                        PartsPosCodeUToThirdDataSet(customerCode, partsPosCodeU.Clone(), ref index);
                    }
                    // 2009.02.16 30413 犬飼 部位層で新規ボタンの対応 <<<<<<END
                }
            }
            else
            {
                // メインGridのDataSetに追加
                index = this._mainGridTable.Count;
                PartsPosCodeUToDataSet(((PartsPosCodeU)updateList[0]).Clone(), ref index);
                
                //// 新規登録レコードをDataSetに反映
                //foreach (PartsPosCodeU partsPosCodeU in updateList)
                //{
                //    // セカンドGridのDataSetに追加
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
        /// 排他処理
        /// </summary>
        /// <param name="operation">オペレーション</param>
        /// <param name="erObject">エラーオブジェクト</param>
        /// <param name="status">ステータス</param>
        /// <remarks>
        /// <br>Note       : データ更新時の排他処理を行います。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.17</br>
        /// </remarks>
        private void ExclusiveTransaction(int status, string operation, object erObject)
        {
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    {
                        TMsgDisp.Show(
                            this,								// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_EXCLAMATION,	// エラーレベル
                            PG_ID,      						// アセンブリＩＤまたはクラスＩＤ
                            PG_NAME,							// プログラム名称
                            "ExclusiveTransaction",				// 処理名称
                            operation,							// オペレーション
                            ERR_800_MSG,						// 表示するメッセージ 
                            status,								// ステータス値
                            erObject,							// エラーが発生したオブジェクト
                            MessageBoxButtons.OK,				// 表示するボタン
                            MessageBoxDefaultButton.Button1);	// 初期表示ボタン
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        TMsgDisp.Show(
                            this,								// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_EXCLAMATION,	// エラーレベル
                            PG_ID,		        				// アセンブリＩＤまたはクラスＩＤ
                            PG_NAME,							// プログラム名称
                            "ExclusiveTransaction",				// 処理名称
                            operation,							// オペレーション
                            ERR_801_MSG,						// 表示するメッセージ 
                            status,								// ステータス値
                            erObject,							// エラーが発生したオブジェクト
                            MessageBoxButtons.OK,				// 表示するボタン
                            MessageBoxDefaultButton.Button1);	// 初期表示ボタン
                        break;
                    }
            }
        }

        /// <summary>
        /// 提供部位ガイド起動処理
        /// </summary>
        /// <param name="partsPosCodeU">部位コードマスタオブジェクト</param>
        /// <returns>結果(0:OK, 1:Cancel)</returns>
        /// <remarks>
        /// <br>Note       : 提供部位コードガイドの起動を行います。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.17</br>
        /// </remarks>
        private int ShowPartsPosCodeGuide(out PartsPosCodeU partsPosCodeU)
        {
            // 画面から提供部位コードを取得
            int partsPosCode = this.PartsPosCode_tNedit.GetInt();
            partsPosCodeU = new PartsPosCodeU();

            if (partsPosCode != 0)
            {
                // ガイド表示
                return this._partsPosCodeUAcs.ExecuteGuid(partsPosCode, LoginInfoAcquisition.EnterpriseCode, out partsPosCodeU);
            }
            else
            {
                // 部位コードが未入力の場合はガイド表示を行わない
                return -1;
            }
        }

        /// <summary>
        /// BLｺｰﾄﾞガイド起動処理
        /// </summary>
        /// <param name="blGoodsCdUMnt">BLｺｰﾄﾞマスタオブジェクト</param>
        /// <returns>結果(0:OK, 1:Cancel)</returns>
        /// <remarks>
        /// <br>Note       : BLｺｰﾄﾞガイドの起動を行います。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.19</br>
        /// </remarks>
        private int ShowBLGoodsCdGuide(out BLGoodsCdUMnt blGoodsCdUMnt)
        {
            blGoodsCdUMnt = new BLGoodsCdUMnt();

            return this._blGoodsCdAcs.ExecuteGuid(LoginInfoAcquisition.EnterpriseCode, out blGoodsCdUMnt);
        }

        /// <summary>
        /// HashTable用キー作成(MAINテーブル用)
        /// </summary>
        /// <param name="partsPosCodeU">部位コードマスタオブジェクト</param>
        /// <returns>Hashテーブル用キー</returns>
        /// <remarks>
        /// <br>Note       : 部位コードマスタからメインGridのハッシュテーブル用のキーを作成します。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.10.20</br>
        /// </remarks>
        private string CreateHashKeyMain(PartsPosCodeU partsPosCodeU)
        {
            string strHashKey = partsPosCodeU.CustomerCode.ToString("d08");
            return strHashKey;
        }

        /// <summary>
        /// HashTable用キー作成
        /// </summary>
        /// <param name="partsPosCodeU">部位コードマスタオブジェクト</param>
        /// <returns>Hashテーブル用キー</returns>
        /// <remarks>
        /// <br>Note       : 部位コードマスタからメインGridのハッシュテーブル用のキーを作成します。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.17</br>
        /// </remarks>
        private string CreateHashKeySecond(PartsPosCodeU partsPosCodeU)
        {
            string strHashKey = partsPosCodeU.SearchPartsPosCode.ToString("d04") + "-" + partsPosCodeU.Division.ToString("d02");
            return strHashKey;
        }

        /// <summary>
        /// HashTable用キー作成
        /// </summary>
        /// <param name="partsPosCodeU">部位コードマスタオブジェクト</param>
        /// <returns>Hashテーブル用キー</returns>
        /// <remarks>
        /// <br>Note       : 部位コードマスタから詳細GRIDのハッシュテーブル用のキーを作成します。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.17</br>
        /// </remarks>
        private string CreateHashKeyThird(PartsPosCodeU partsPosCodeU)
        {
            string strHashKey = partsPosCodeU.PosDispOrder.ToString("d03") + "-" + partsPosCodeU.TbsPartsCode.ToString("d08");
            return strHashKey;
        }

        /// <summary>
        /// グリッドバインド処理
        /// </summary>
        /// <remarks>
        /// <br>Note	   : 配列項目をグリッドへバインドします。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008/06/17</br>
        /// </remarks>
        private void DataTableSchemaSetting()
        {
            try
            {
                // スキーマの設定
                _bindTable.Columns.Add(MY_SCREEN_ID, typeof(string));
                _bindTable.Columns.Add(MY_SCREEN_ODER, typeof(int));
                _bindTable.Columns.Add(MY_SCREEN_TBSPARTS_CODE, typeof(string));
                _bindTable.Columns.Add(MY_SCREEN_GUID, typeof(Button));
                _bindTable.Columns[MY_SCREEN_GUID].Caption = "";
                _bindTable.Columns.Add(MY_SCREEN_TBSPARTS_NAME, typeof(string));
            }
            catch (DuplicateNameException e)    // HACK:削除の後、連続して修正すると発生（無視しても動作はする）
            {
                Debug.Assert(false, e.ToString());
            }
        }

        /// <summary>
        ///	UI画面のGRID初期設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note	   : GRIDの初期設定を行います。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008/06/17</br>
        /// </remarks>
        private void GridInitialSetting()
        {
            // データソースへ追加
            this.tbsPartsList_ultraGrid.DataSource = _bindTable;

            // グリッドの背景色
            this.tbsPartsList_ultraGrid.DisplayLayout.Appearance.BackColor = Color.White;
            this.tbsPartsList_ultraGrid.DisplayLayout.Appearance.BackColor2 = Color.FromArgb(198, 219, 255);
            this.tbsPartsList_ultraGrid.DisplayLayout.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;

            // 行の追加不可
            this.tbsPartsList_ultraGrid.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No;
            // 行のサイズ変更不可
            this.tbsPartsList_ultraGrid.DisplayLayout.Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.Fixed;
            // 行の削除不可
            this.tbsPartsList_ultraGrid.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.True;
            // 列の移動不可
            this.tbsPartsList_ultraGrid.DisplayLayout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.NotAllowed;
            // 列のサイズ変更不可
            this.tbsPartsList_ultraGrid.DisplayLayout.Override.AllowColSizing = Infragistics.Win.UltraWinGrid.AllowColSizing.None;
            // 列の交換不可
            this.tbsPartsList_ultraGrid.DisplayLayout.Override.AllowColSwapping = Infragistics.Win.UltraWinGrid.AllowColSwapping.NotAllowed;
            // フィルタの使用不可
            this.tbsPartsList_ultraGrid.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
            // ユーザーのデータ書き換え許可
            //this.tbsPartsList_ultraGrid.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.True;

            //this.tbsPartsList_ultraGrid.DisplayLayout.Override.CardAreaAppearance.BackColor = System.Drawing.Color.Transparent;

            // タイトルの外観設定
            this.tbsPartsList_ultraGrid.DisplayLayout.Override.HeaderAppearance.BackColor = Color.FromArgb(89, 135, 214);
            this.tbsPartsList_ultraGrid.DisplayLayout.Override.HeaderAppearance.BackColor2 = Color.FromArgb(7, 59, 150);
            this.tbsPartsList_ultraGrid.DisplayLayout.Override.HeaderAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.tbsPartsList_ultraGrid.DisplayLayout.Override.HeaderAppearance.ForeColor = Color.White;
            this.tbsPartsList_ultraGrid.DisplayLayout.Override.HeaderAppearance.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;

            // グリッドの選択方法を設定（セル単体の選択のみ許可）
            //this.tbsPartsList_ultraGrid.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.Single;
            this.tbsPartsList_ultraGrid.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.tbsPartsList_ultraGrid.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Single;
            // 互い違いの行の色を変更
            this.tbsPartsList_ultraGrid.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.Lavender;
            // 行セレクタ表示無し
            this.tbsPartsList_ultraGrid.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True;
            // スクロールバー非表示
            //this.tbsPartsList_ultraGrid.DisplayLayout.Scrollbars = Infragistics.Win.UltraWinGrid.Scrollbars.None;
            // アクティブセルの背景色
            //this.tbsPartsList_ultraGrid.DisplayLayout.Override.ActiveCellAppearance.BackColor = Color.White;
            //this.tbsPartsList_ultraGrid.DisplayLayout.Override.ActiveCellAppearance.BackColor2 = Color.FromArgb(251, 230, 148);
            //this.tbsPartsList_ultraGrid.DisplayLayout.Override.ActiveCellAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            //this.tbsPartsList_ultraGrid.DisplayLayout.Override.ActiveCellAppearance.ForeColor = Color.Black;

            this.tbsPartsList_ultraGrid.DisplayLayout.Override.EditCellAppearance.BackColor = Color.FromArgb(247, 227, 156);
            this.tbsPartsList_ultraGrid.DisplayLayout.Override.ActiveCellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
            this.tbsPartsList_ultraGrid.DisplayLayout.Override.EditCellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
            this.tbsPartsList_ultraGrid.DisplayLayout.Override.CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
            //this.tbsPartsList_ultraGrid.DisplayLayout.Override.RowAppearance.BorderColor = Color.FromArgb(1, 68 ,208);

            // 「ID」は編集不可（固定項目として設定）
            this.tbsPartsList_ultraGrid.DisplayLayout.Bands[0].Columns[MY_SCREEN_ODER].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            this.tbsPartsList_ultraGrid.DisplayLayout.Bands[0].Columns[MY_SCREEN_ODER].TabStop = false;
            this.tbsPartsList_ultraGrid.DisplayLayout.Bands[0].Columns[MY_SCREEN_ODER].CellAppearance.BackColor = Color.FromArgb(89, 135, 214);
            this.tbsPartsList_ultraGrid.DisplayLayout.Bands[0].Columns[MY_SCREEN_ODER].CellAppearance.BackColor2 = Color.FromArgb(7, 59, 150);
            this.tbsPartsList_ultraGrid.DisplayLayout.Bands[0].Columns[MY_SCREEN_ODER].CellAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.tbsPartsList_ultraGrid.DisplayLayout.Bands[0].Columns[MY_SCREEN_ODER].CellAppearance.ForeColor = Color.White;

            // BLコード列の設定
            this.tbsPartsList_ultraGrid.DisplayLayout.Bands[0].Columns[MY_SCREEN_TBSPARTS_CODE].CellActivation = Activation.AllowEdit;
            this.tbsPartsList_ultraGrid.DisplayLayout.Bands[0].Columns[MY_SCREEN_TBSPARTS_CODE].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            this.tbsPartsList_ultraGrid.DisplayLayout.Bands[0].Columns[MY_SCREEN_TBSPARTS_CODE].TabStop = true;

            // ガイドボタンの設定
            this.tbsPartsList_ultraGrid.DisplayLayout.Bands[0].Columns[MY_SCREEN_GUID].CellActivation = Activation.NoEdit;
            this.tbsPartsList_ultraGrid.DisplayLayout.Bands[0].Columns[MY_SCREEN_GUID].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button;
            this.tbsPartsList_ultraGrid.DisplayLayout.Bands[0].Columns[MY_SCREEN_GUID].ButtonDisplayStyle = ButtonDisplayStyle.Always;
            this.tbsPartsList_ultraGrid.DisplayLayout.Bands[0].Columns[MY_SCREEN_GUID].CellButtonAppearance.Image = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];
            this.tbsPartsList_ultraGrid.DisplayLayout.Bands[0].Columns[MY_SCREEN_GUID].TabStop = true;

            // BL品名列の設定
            this.tbsPartsList_ultraGrid.DisplayLayout.Bands[0].Columns[MY_SCREEN_TBSPARTS_NAME].CellActivation = Activation.NoEdit;
            this.tbsPartsList_ultraGrid.DisplayLayout.Bands[0].Columns[MY_SCREEN_TBSPARTS_NAME].TabStop = false;

            //特定列を非表示に
            this.tbsPartsList_ultraGrid.DisplayLayout.Bands[0].Columns[MY_SCREEN_ID].Hidden = true;

            // セルの幅の設定
            this.tbsPartsList_ultraGrid.DisplayLayout.Bands[0].Columns[MY_SCREEN_ODER].Width = 50;
            this.tbsPartsList_ultraGrid.DisplayLayout.Bands[0].Columns[MY_SCREEN_TBSPARTS_CODE].Width = 60;
            this.tbsPartsList_ultraGrid.DisplayLayout.Bands[0].Columns[MY_SCREEN_GUID].Width = 20;
            this.tbsPartsList_ultraGrid.DisplayLayout.Bands[0].Columns[MY_SCREEN_TBSPARTS_NAME].Width = 430;

            // ValueListを設定する
            //this.tbsPartsList_ultraGrid.DisplayLayout.Bands[0].Columns[ MY_SCREEN_PRINTDIV_TITLE ].Style			= Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            //this.tbsPartsList_ultraGrid.DisplayLayout.Bands[0].Columns[ MY_SCREEN_PRINTDIV_TITLE ].ValueList		= this.tbsPartsList_ultraGrid.DisplayLayout.ValueLists[ MY_SCREEN_PRINTDIV_TITLE ];

            // 選択行の外観設定
            this.tbsPartsList_ultraGrid.DisplayLayout.Override.SelectedRowAppearance.BackColor = System.Drawing.Color.FromArgb(251, 230, 148);
            this.tbsPartsList_ultraGrid.DisplayLayout.Override.SelectedRowAppearance.BackColor2 = System.Drawing.Color.FromArgb(238, 149, 21);
            this.tbsPartsList_ultraGrid.DisplayLayout.Override.SelectedRowAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.tbsPartsList_ultraGrid.DisplayLayout.Override.SelectedRowAppearance.ForeColor = System.Drawing.Color.Black;
            this.tbsPartsList_ultraGrid.DisplayLayout.Override.SelectedRowAppearance.BackColorDisabled = System.Drawing.Color.FromArgb(251, 230, 148);
            this.tbsPartsList_ultraGrid.DisplayLayout.Override.SelectedRowAppearance.BackColorDisabled2 = System.Drawing.Color.FromArgb(238, 149, 21);
            // アクティブ行の外観設定
            this.tbsPartsList_ultraGrid.DisplayLayout.Override.ActiveRowAppearance.BackColor = System.Drawing.Color.FromArgb(251, 230, 148);
            this.tbsPartsList_ultraGrid.DisplayLayout.Override.ActiveRowAppearance.BackColor2 = System.Drawing.Color.FromArgb(238, 149, 21);
            this.tbsPartsList_ultraGrid.DisplayLayout.Override.ActiveRowAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.tbsPartsList_ultraGrid.DisplayLayout.Override.ActiveRowAppearance.ForeColor = System.Drawing.Color.Black;
            this.tbsPartsList_ultraGrid.DisplayLayout.Override.ActiveRowAppearance.BackColorDisabled = System.Drawing.Color.FromArgb(251, 230, 148);
            this.tbsPartsList_ultraGrid.DisplayLayout.Override.ActiveRowAppearance.BackColorDisabled2 = System.Drawing.Color.FromArgb(238, 149, 21);

            // 行セレクタの外観設定
            this.tbsPartsList_ultraGrid.DisplayLayout.Override.RowSelectorAppearance.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(89)), ((System.Byte)(135)), ((System.Byte)(214)));
            this.tbsPartsList_ultraGrid.DisplayLayout.Override.RowSelectorAppearance.BackColor2 = System.Drawing.Color.FromArgb(((System.Byte)(7)), ((System.Byte)(59)), ((System.Byte)(150)));
            this.tbsPartsList_ultraGrid.DisplayLayout.Override.RowSelectorAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;

            // 罫線の色を変更
            this.tbsPartsList_ultraGrid.DisplayLayout.Appearance.BorderColor = Color.FromArgb(1, 68, 208);
            //this.tbsPartsList_ultraGrid.Rows[0].Activate();
        }

        /// <summary>
        /// 更新前後のデータ比較と更新対象格納処理
        /// </summary>
        /// <param name="updateList">更新対象レコードを格納</param>
        /// <param name="deleteList">削除対象レコードを格納</param>
        /// <remarks>
        /// <br>Note       : 更新前後のデータを比較して更新／削除対象データを格納します。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.19</br>
        /// </remarks>
        private void UpdateCompare(out ArrayList updateList, out ArrayList deleteList)
        {
            updateList = new ArrayList();
            deleteList = new ArrayList();
            
            // Form メインGrid情報を取得
            string partsGuid = (string)this.Bind_DataSet.Tables[SECOND_TABLE].Rows[this._secondDataIndex][S_PARTSPOSCODE_GUID];
            PartsPosCodeU partsPosCodeU = ((PartsPosCodeU)this._secondGridTable[partsGuid]).Clone(); ;

            if (!partsPosCodeU.SearchPartsPosName.Equals(this.PartsPosName_tEdit.Text.TrimEnd()))
            {
                // 部位名称が更新されているため更新対象レコードに追加
                partsPosCodeU.SearchPartsPosName = this.PartsPosName_tEdit.Text.TrimEnd();
                updateList.Add(partsPosCodeU);
            }

            // Form 詳細Grid情報とUI画面のGridを取得して比較
            int index;
            int detailRowCnt = this._thirdGridTable.Count;          // 詳細Gridの行数
            int tbsPartsRowCnt = this._bindTable.Rows.Count;        // UI画面のGrid行数

            //for (index = 0; index < tbsPartsRowCnt; index++)
            //{
            //    string strBlCode = (string)this._bindTable.Rows[index][MY_SCREEN_TBSPARTS_CODE];
            //    if (strBlCode == "")
            //    {
            //        // BLコード未入力の行はSKIP
            //        continue;
            //    }

            //    int tbsPartsCode = Int32.Parse(strBlCode);

            //    if (index < detailRowCnt)
            //    {
            //        string guid = (string)this.Bind_DataSet.Tables[THIRD_TABLE].Rows[index][T_TBSPARTCODE_GUID];
            //        partsPosCodeU = ((PartsPosCodeU)this._thirdGridTable[guid]).Clone();

            //        if (partsPosCodeU.TbsPartsCode != tbsPartsCode)
            //        {
            //            // BLコードが不一致の場合、詳細Grid情報を削除対象に追加
            //            deleteList.Add(partsPosCodeU);

            //            // 主キーが変わるので、UI画面のGrid情報は新規追加となる
            //            partsPosCodeU = new PartsPosCodeU();
            //            partsPosCodeU.EnterpriseCode = this._enterpriseCode;                                // 企業コード
            //            partsPosCodeU.CustomerCode = this.tNedit_CustomerCodeAllowZero.GetInt();                     // 得意先コード
            //            partsPosCodeU.SearchPartsPosCode = this.PartsPosCode_tNedit.GetInt();               // 部位コード
            //            partsPosCodeU.PosDispOrder = (int)this._bindTable.Rows[index][MY_SCREEN_ODER];      // 表示順位
            //            partsPosCodeU.TbsPartsCode = tbsPartsCode;                                          // BLコード
            //            updateList.Add(partsPosCodeU);
            //        }

            //        else if (partsPosCodeU.PosDispOrder != (int)this._bindTable.Rows[index][MY_SCREEN_ODER])
            //        {
            //            // 表示順位が不一致の場合、表示順位を更新して更新対象に追加
            //            partsPosCodeU.PosDispOrder = (int)this._bindTable.Rows[index][MY_SCREEN_ODER];
            //            updateList.Add(partsPosCodeU);
            //        }
            //    }
            //    else
            //    {
            //        if (strBlCode == "")
            //        {
            //            // BLコード未入力の行はSKIP
            //            continue;
            //        }

            //        // 新規追加として更新対象に追加
            //        partsPosCodeU = new PartsPosCodeU();
            //        partsPosCodeU.EnterpriseCode = this._enterpriseCode;                                // 企業コード
            //        partsPosCodeU.CustomerCode = this.tNedit_CustomerCodeAllowZero.GetInt();                     // 得意先コード
            //        partsPosCodeU.SearchPartsPosCode = this.PartsPosCode_tNedit.GetInt();               // 部位コード
            //        partsPosCodeU.PosDispOrder = (int)this._bindTable.Rows[index][MY_SCREEN_ODER];      // 表示順位
            //        partsPosCodeU.TbsPartsCode = Int32.Parse(strBlCode);                                // BLコード
            //        updateList.Add(partsPosCodeU);
            //    }
                
            //}

            // 詳細Grid情報の行数分を比較
            for (index = 0; index < detailRowCnt; index++)
            {
                // 詳細Grid情報を取得
                string guid = (string)this.Bind_DataSet.Tables[THIRD_TABLE].Rows[index][T_TBSPARTCODE_GUID];
                partsPosCodeU = ((PartsPosCodeU)this._thirdGridTable[guid]).Clone();

                if (index >= tbsPartsRowCnt)
                {
                    // 詳細Grid行数がUI画面のGrid行数以上の場合はループを抜ける
                    break;
                }

                // UI画面のGridからBLコードを取得
                string strBlCode = (string)this._bindTable.Rows[index][MY_SCREEN_TBSPARTS_CODE];
                //if (strBlCode == "")
                //{
                //    // BLコード未入力の行はSKIP
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
                    // BLコードが不一致の場合、詳細Grid情報を削除対象に追加
                    deleteList.Add(partsPosCodeU);

                    if (tbsPartsCode != 0)
                    {
                        // 主キーが変わるので、UI画面のGrid情報は新規追加となる
                        partsPosCodeU = new PartsPosCodeU();
                        partsPosCodeU.EnterpriseCode = this._enterpriseCode;                                // 企業コード
                        partsPosCodeU.CustomerCode = this.tNedit_CustomerCodeAllowZero.GetInt();                     // 得意先コード
                        partsPosCodeU.SearchPartsPosCode = this.PartsPosCode_tNedit.GetInt();               // 部位コード
                        partsPosCodeU.PosDispOrder = (int)this._bindTable.Rows[index][MY_SCREEN_ODER];      // 表示順位
                        partsPosCodeU.TbsPartsCode = tbsPartsCode;                                          // BLコード
                        updateList.Add(partsPosCodeU);
                    }
                }

                else if (partsPosCodeU.PosDispOrder != (int)this._bindTable.Rows[index][MY_SCREEN_ODER])
                {
                    // 表示順位が不一致の場合、表示順位を更新して更新対象に追加
                    partsPosCodeU.PosDispOrder = (int)this._bindTable.Rows[index][MY_SCREEN_ODER];
                    updateList.Add(partsPosCodeU);
                }
            }

            if (detailRowCnt < tbsPartsRowCnt)
            {
                // 詳細Gridの行数よりUI画面のGrid行数が多い
                for (index = detailRowCnt; index < tbsPartsRowCnt; index++)
                {
                    string strBlCode = (string)this._bindTable.Rows[index][MY_SCREEN_TBSPARTS_CODE];
                    if (strBlCode == "")
                    {
                        // BLコード未入力の行はSKIP
                        continue;
                    }

                    // 新規追加として更新対象に追加
                    partsPosCodeU = new PartsPosCodeU();
                    partsPosCodeU.EnterpriseCode = this._enterpriseCode;                                // 企業コード
                    partsPosCodeU.CustomerCode = this.tNedit_CustomerCodeAllowZero.GetInt();                     // 得意先コード
                    partsPosCodeU.SearchPartsPosCode = this.PartsPosCode_tNedit.GetInt();               // 部位コード
                    partsPosCodeU.PosDispOrder = (int)this._bindTable.Rows[index][MY_SCREEN_ODER];      // 表示順位
                    partsPosCodeU.TbsPartsCode = Int32.Parse(strBlCode);                                // BLコード
                    updateList.Add(partsPosCodeU);
                }
            }
            else if (tbsPartsRowCnt < detailRowCnt)
            {
                // 詳細Gridの行数よりUI画面のGrid行数が少ない
                for (index = tbsPartsRowCnt; index < detailRowCnt; index++)
                {
                    // 削除対象に追加
                    string guid = (string)this.Bind_DataSet.Tables[THIRD_TABLE].Rows[index][T_TBSPARTCODE_GUID];
                    partsPosCodeU = ((PartsPosCodeU)this._thirdGridTable[guid]).Clone();
                    deleteList.Add(partsPosCodeU);
                }
            }
        }

        /// <summary>
        ///	Grid 新規行の追加
        /// </summary>
        /// <remarks>
        /// <br>Note	   : GRIDに新規行を追加します。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008/10/21</br>
        /// </remarks>
        private void tbsPartsList_AddRow()
        {
            if (this._bindTable.Rows.Count == 99)
            {
                // MAX99行とする
                return;
            }

            // ガイドで選択したBLコードを追加
            DataRow bindRow;

            bindRow = this._bindTable.NewRow();

            // BL情報をGridに追加
            bindRow[MY_SCREEN_ID] = "";
            bindRow[MY_SCREEN_ODER] = this._bindTable.Rows.Count + 1;
            bindRow[MY_SCREEN_TBSPARTS_CODE] = "";
            bindRow[MY_SCREEN_TBSPARTS_NAME] = "";

            this._bindTable.Rows.Add(bindRow);
        }

        /// <summary>
        /// 数値入力チェック処理
        /// </summary>
        /// <param name="keta">桁数(マイナス符号を含まず)</param>
        /// <param name="priod">小数点以下桁数</param>
        /// <param name="prevVal">現在の文字列</param>
        /// <param name="key">入力されたキー値</param>
        /// <param name="selstart">カーソル位置</param>
        /// <param name="sellength">選択文字長</param>
        /// <param name="minusFlg">マイナス入力可？</param>
        /// <param name="NumberFlg">数値入力可？</param>
        /// <returns>true=入力可,false=入力不可</returns>
        /// <remarks>
        /// Note			:	押されたキーが数値のみ有効にする処理を行います。<br />
        /// Programmer		:	30413 犬飼<br />
        /// Date			:	2008.10.21<br />
        /// </remarks>
        private bool KeyPressNumCheck(int keta, int priod, string prevVal, char key, int selstart, int sellength, Boolean minusFlg, Boolean NumberFlg)
        {
            // 制御キーが押された？
            if (Char.IsControl(key))
            {
                return true;
            }

            // 押されたキーが数値以外、かつ数値以外入力不可
            if (!Char.IsDigit(key) && !NumberFlg)
            {
                return false;
            }

            // キーが押されたと仮定した場合の文字列を生成する。
            string _strResult = "";
            if (sellength > 0)
            {
                _strResult = prevVal.Substring(0, selstart) + prevVal.Substring(selstart + sellength, prevVal.Length - (selstart + sellength));
            }
            else
            {
                _strResult = prevVal;
            }

            // マイナスのチェック
            if (key == '-')
            {
                // マイナス(小数点)が入力可能か？
                if (minusFlg == false)
                {
                    return false;
                }
            }

            // 小数点のチェック
            if (key == '.')
            {
                // 小数点以下桁数が0か？
                if (priod == 0)
                {
                    return false;
                }
                else
                {
                    // 小数点が既に存在するか？
                    if (_strResult.Contains("."))
                    {
                        return false;
                    }
                }
            }
            else
            {
                // 小数点が既に存在するか？
                if (_strResult.Contains("."))
                {
                    int index = _strResult.IndexOf('.');
                    string strDecimal = _strResult.Substring(index + 1);

                    if ((strDecimal.Length >= priod) && (selstart > index))
                    {
                        // 小数桁が入力可能桁数以上で、カーソル位置が小数点以降
                        return false;
                    }
                    else if (((keta - priod) < index))
                    {
                        // 整数部の桁数が入力可能桁数を超えた
                        return false;
                    }
                }
                else
                {
                    // 小数点桁数を前提に整数部の桁数を決定
                    if (((keta - priod) <= _strResult.Length))
                    {
                        return false;
                    }
                }
            }

            // キーが押された結果の文字列を生成する。
            _strResult = prevVal.Substring(0, selstart)
                + key
                + prevVal.Substring(selstart + sellength, prevVal.Length - (selstart + sellength));

            // 桁数チェック！
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

        // --- ADD 2009/03/23 残案件No.14対応------------------------------------------------------>>>>>
        private void Renewal_Button_Click(object sender, EventArgs e)
        {
            this._partsPosCodeUAcs = new PartsPosCodeUAcs();

            TMsgDisp.Show(this, 								// 親ウィンドウフォーム
                          emErrorLevel.ERR_LEVEL_INFO,          // エラーレベル
                          "PMKHN09050U",						    // アセンブリＩＤまたはクラスＩＤ
                          "最新情報を取得しました。", 			// 表示するメッセージ
                          0, 									// ステータス値
                          MessageBoxButtons.OK);				// 表示するボタン
        }
        // --- ADD 2009/03/23 残案件No.14対応------------------------------------------------------<<<<<

        // 2009.03.31 30413 犬飼 新規モードからモード変更対応 >>>>>>START
        /// <summary>
        /// モード変更処理（得意先別）
        /// </summary>
        private bool ModeChangeProc()
        {
            // 得意先コード
            int customerCode = tNedit_CustomerCodeAllowZero.GetInt();
            // 部位コード
            int partsPosCode = PartsPosCode_tNedit.GetInt();

            for (int i = 0; i < this.Bind_DataSet.Tables[MAIN_TABLE].Rows.Count; i++)
            {
                // データセットと比較
                int dsCustomerCode = int.Parse((string)this.Bind_DataSet.Tables[MAIN_TABLE].Rows[i][M_CUSTOMERCODE]);
                if (customerCode == dsCustomerCode)
                {
                    // 入力コードがデータセットに存在する場合
                    if ((string)this.Bind_DataSet.Tables[MAIN_TABLE].Rows[i][M_DELETEDATE] != "")
                    {
                        // 論理削除
                        TMsgDisp.Show(this, 					// 親ウィンドウフォーム
                          emErrorLevel.ERR_LEVEL_INFO,          // エラーレベル
                          PG_ID,						        // アセンブリＩＤまたはクラスＩＤ
                          "入力されたコードの部位マスタ情報は既に削除されています。", 			// 表示するメッセージ
                          0, 									// ステータス値
                          MessageBoxButtons.OK);				// 表示するボタン
                        // 得意先コード、部位コードのクリア
                        tNedit_CustomerCodeAllowZero.Clear();
                        CustomerSnm_tEdit.Clear();
                        PartsPosCode_tNedit.Clear();
                        return true;
                    }

                    int status = 0;
                    PartsPosCodeU partsPosCodeU;
                    // 部位コードマスタの取得
                    status = this._partsPosCodeUAcs.Read(out partsPosCodeU, this._enterpriseCode, customerCode, partsPosCode, 0);
                    if ((status == 0) && (partsPosCodeU != null))
                    {
                        if ((customerCode == partsPosCodeU.CustomerCode) && (partsPosCode == partsPosCodeU.SearchPartsPosCode))
                        {
                            DialogResult res = TMsgDisp.Show(
                                this,                                   // 親ウィンドウフォーム
                                emErrorLevel.ERR_LEVEL_INFO,            // エラーレベル
                                PG_ID,                                // アセンブリＩＤまたはクラスＩＤ
                                "入力されたコードの部位マスタ情報が既に登録されています。\n編集を行いますか？",   // 表示するメッセージ
                                0,                                      // ステータス値
                                MessageBoxButtons.YesNo);               // 表示するボタン
                            switch (res)
                            {
                                case DialogResult.Yes:
                                    {
                                        // 画面再描画
                                        this._mainDataIndex = i;
                                        UpdateDataSet(customerCode, partsPosCode);
                                        ScreenClear();
                                        ScreenReconstruction();
                                        break;
                                    }
                                case DialogResult.No:
                                    {
                                        // 得意先コード、部位コードのクリア
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
        /// 再描画前の検索処理
        /// </summary>
        private void UpdateDataSet(int customerCode, int partsPosCode)
        {
            int totalCount = 0;
            
            // データビュー（２アレイ目の再取得）
            SecondDataSearch(ref totalCount, 0);
            
            for (int i = 0; i < this.Bind_DataSet.Tables[SECOND_TABLE].Rows.Count; i++)
            {
                // データセットと比較
                int dsPartsPosCode = int.Parse((string)this.Bind_DataSet.Tables[SECOND_TABLE].Rows[i][S_PARTSPOSCODE]);
                if (partsPosCode == dsPartsPosCode)
                {
                    this._secondDataIndex = i;
                    totalCount = 0;
                    // データビュー（３アレイ名の再取得）
                    ThirdDataSearch(ref totalCount, 0);
                    break;
                }
            }
        }
        // 2009.03.31 30413 犬飼 新規モードからモード変更対応 <<<<<<END
    }
}

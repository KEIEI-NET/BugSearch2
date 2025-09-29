//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : UOEガイド名称マスタ
// プログラム概要   : UOEガイド名称マスタの登録・変更・削除を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2007 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 犬飼
// 作 成 日  2008/06/30  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 行澤 仁美
// 修 正 日  2008/10/30  修正内容 : バグ修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 宮津 銀次郎
// 修 正 日  2008/12/11  修正内容 : BO.納品,拠点区分選択時、ガイドコードを空白で登録できるよう修正。
//----------------------------------------------------------------------------//
// 管理番号  12719       作成担当 : 工藤　恵優
// 修 正 日  2009/03/25  修正内容 : 「削除済データの表示」は最上位項目で制御
//----------------------------------------------------------------------------//
#define DELETE_DATE_DEPEND_ON_SUB_TABLE // メインテーブルの削除日をサブテーブルに関連させるフラグ
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
    /// UOEガイド名称マスタ フォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note		: UOEガイド名称マスタ情報の設定を行います。
    ///					  IMasterMaintenanceThreeArrayTypeを実装しています。</br>
    /// <br>Programmer	: 30413 犬飼</br>
    /// <br>Date		: 2008.06.30</br>
    /// <br></br>
    /// <br>UpdateNote  : 2008/10/30 30462 行澤 仁美　バグ修正</br>
    /// <br>UpdateNote  : 2008/12/11 30365 宮津 銀次郎　BO.納品,拠点区分選択時、ガイドコードを空白で登録できるよう修正。</br>
    /// <br>UpdateNote  : 2009/03/25 30434 工藤 恵優　「削除済データの表示」は最上位項目で制御</br>
    /// </remarks>
    public class PMUOE09030UA : System.Windows.Forms.Form, IMasterMaintenanceThreeArrayType
    {
        # region ※Private Members (Component)

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

        #region ※Windows フォーム デザイナで生成されたコード
        /// <summary>
        /// デザイナ サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディタで変更しないでください。
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
            this.Mode_Label.Text = "更新モード";
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
            this.UOESupplierCd_Label.Text = "発注先コード";
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
            this.UOESupplierNm_Label.Text = "発注先名称";
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
            this.UOEGuideDivCd_Label.Text = "ガイド区分";
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
            this.UOEGuideCode_Label.Text = "ガイドコード";
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
            this.UOEGuideName_Label.Text = "ガイド名称";
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
            this.Cancel_Button.Text = "閉じる(&X)";
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
            this.Revive_Button.Text = "復活(&R)";
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
            this.Delete_Button.Text = "完全削除(&D)";
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
            this.Ok_Button.Text = "保存(&S)";
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
            this.UOEGuideDivNm_Label.Text = "ガイド区分名称";
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
            this.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PMUOE09030UA";
            this.Text = "UOE各種名称マスタ";
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

        private UOESupplierAcs _uoeSupplierAcs;                         // UOE発注先マスタテーブルアクセスクラス
        private UOEGuideNameAcs _uoeGuideNameAcs;                         // UOEガイド名称マスタテーブルアクセスクラス


        private int _totalCount;
        private string _enterpriseCode;
        private string _sectionCode;
        private Hashtable _thirdGridTable;

        // 比較用クローン
        private UOEGuideName _uoeGuideNameClone;

        // プロパティ用
        private bool _canPrint;
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

        // 2009.03.31 30413 犬飼 新規モードからモード変更対応 >>>>>>START
        // モードフラグ(true：コード、false：コード以外)
        private bool _modeFlg = false;
        // 2009.03.31 30413 犬飼 新規モードからモード変更対応 <<<<<<END

        #endregion

        # region ※Consts

        // FrameのView用Grid列のKEY情報 (ヘッダのタイトル部となります)
        private const string MAIN_TABLE = "PrintingItem";
        private const string SECOND_TABLE = "CountItem";
        private const string THIRD_TABLE = "CountCondition";

        // グリッドタイトル
        private const string SECTION_GRID_TITLE = "発注先";
        private const string UNITPRICEKIND_GRID_TITLE = "ガイド区分";
        private const string RATEPRIORITYORDER_GRID_TITLE = "ガイド";

        // FreamのView用Grid列のKEY情報 (ヘッダのタイトル部となります)
        private const string M_UOESUPPLIERCD = "発注先コード";
        private const string M_UOESUPPLIERNM = "発注先名称";
        
        private const string S_UOEGUIDEDIVCD = "ガイド区分";
        private const string S_UOEGUIDEDIVNM = "ガイド区分名称";
        
        private const string T_DELETEDATE = "削除日";
        private const string T_UOEGUIDECODE = "ガイドコード";
        private const string T_UOEGUIDENAME = "ガイド名称";
        private const string T_UOEGUIDECODE_GUID = "UOEGUIDECODE_GUID";
        
        // 編集モード
        private const string INSERT_MODE = "新規モード";
        private const string UPDATE_MODE = "更新モード";
        private const string DELETE_MODE = "削除モード";

        // Message関連定義
        private const string PG_ID = "PMUOE09030U";
        private const string PG_NM = "UOEガイド名称マスタ";
        private const string ERR_READ_MSG = "読み込みに失敗しました。";
        private const string ERR_DPR_MSG = "このコードは既に使用されています。";
        private const string ERR_RDEL_MSG = "削除に失敗しました。";
        private const string ERR_UPDT_MSG = "登録に失敗しました。";
        private const string ERR_RVV_MSG = "復活に失敗しました。";
        private const string ERR_800_MSG = "既に他端末より更新されています";
        private const string ERR_801_MSG = "既に他端末より削除されています";
        private const string SDC_RDEL_MSG = "マスタから削除されています";

        #endregion

        # region ※Constructor

        /// <summary>
		/// UOEガイド名称マスタ入力フォームクラスコンストラクタ
		/// </summary>
		/// <remarks>
        /// <br>Note       : UOEガイド名称マスタ入力フォームクラスの新しいインスタンスを初期化します。</br>
		/// <br>Programmer : 30413 犬飼</br>
		/// <br>Date       : 2008.06.30</br>
		/// </remarks>
        public PMUOE09030UA()
		{
			InitializeComponent();

            // データセット列情報構築処理
            DataSetColumnConstruction();

			// プロパティ初期値設定
			this._canPrint = false;
			this._canClose = true;
			this._canNew = true;
            this._canDelete = true;
            
			this._mainGridTitle = SECTION_GRID_TITLE;
			this._secondGridTitle = UNITPRICEKIND_GRID_TITLE;
			this._thirdGridTitle = RATEPRIORITYORDER_GRID_TITLE;
			this._defaultGridDisplayLayout = MGridDisplayLayout.Horizontal;

			// 企業コード
			this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            this._sectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;

            this._uoeSupplierAcs = new UOESupplierAcs();
            this._uoeGuideNameAcs = new UOEGuideNameAcs();

            this._totalCount = 0;
            this._thirdGridTable = new Hashtable();

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
		}

        #endregion

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
        /// <summary>アプリケーションのメイン エントリ ポイントです。</summary>
        [STAThread]
        static void Main()
        {
            System.Windows.Forms.Application.Run(new PMUOE09030UA());
        }
        # endregion

        # region ※Events
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

        /// <summary>
        /// 論理削除データ抽出可能設定リスト取得処理
        /// </summary>
        /// <returns>論理削除データ抽出可能設定リスト</returns>
        /// <remarks>
        /// <br>Note       : 論理削除データの抽出が可能かどうかの設定を配列で取得します。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.30</br>
        /// </remarks>
        public bool[] GetCanLogicalDeleteDataExtractionList()
        {
            bool[] logicalDelete = { true, false, false };  // ADD 2008/03/25 不具合対応[12719]：「削除済データの表示」は最上位項目で制御 { false, false, true }→{ true, false, false }
            return logicalDelete;
        }

        /// <summary>
        /// グリッドタイトルリスト取得処理
        /// </summary>
        /// <returns>グリッドタイトルリスト</returns>
        /// <remarks>
        /// <br>Note       : グリッドのタイトルを配列で取得します。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.30</br>
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
        /// <br>Date       : 2008.06.30</br>
        /// </remarks>
        public System.Drawing.Image[] GetGridIconList()
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
        /// <br>Date       : 2008.06.30</br>
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
        /// 新規ボタンの有効設定リスト取得処理
        /// </summary>
        /// <returns>新規ボタンの有効設定リスト</returns>
        /// <remarks>
        /// <br>Note       : 新規ボタンの有効設定リストを取得します。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.30</br>
        /// </remarks>
        public bool[] GetNewButtonEnabledList()
        {
            bool[] newButtonEnabled = { false, false, true };
            if (this.Bind_DataSet.Tables[MAIN_TABLE].Rows.Count == 0)
            {
                // 発注先情報が0件の場合は、新規作成不可
                newButtonEnabled[2] = false;
            }
            return newButtonEnabled;
        }

        /// <summary>
        /// 修正ボタンの有効設定リスト取得処理
        /// </summary>
        /// <returns>修正ボタンの有効設定リスト</returns>
        /// <remarks>
        /// <br>Note       : 修正ボタンの有効設定リストを取得します。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.30</br>
        /// </remarks>
        public bool[] GetModifyButtonEnabledList()
        {
            bool[] modifyButtonEnabled = { false, false, true };
            if (this.Bind_DataSet.Tables[MAIN_TABLE].Rows.Count == 0)
            {
                // 発注先情報が0件の場合は、新規作成不可
                modifyButtonEnabled[2] = false;
            }
            return modifyButtonEnabled;
        }

        /// <summary>
        /// 削除ボタンの有効設定リスト取得処理
        /// </summary>
        /// <returns>削除ボタンの有効設定リスト</returns>
        /// <remarks>
        /// <br>Note       : 削除ボタンの有効設定リストを取得します。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.30</br>
        /// </remarks>
        public bool[] GetDeleteButtonEnabledList()
        {
            bool[] deleteButtonEnabled = { false, false, true };
            if (this.Bind_DataSet.Tables[MAIN_TABLE].Rows.Count == 0)
            {
                // 発注先情報が0件の場合は、新規作成不可
                deleteButtonEnabled[2] = false;
            }
            return deleteButtonEnabled;
        }

        # endregion

        # region ※Public Methods

        /// <summary>
        /// バインドデータセット取得処理
        /// </summary>
        /// <param name="bindDataSet">グリッドリッド用データセット</param>
        /// <param name="tableName">テーブル名称</param>
        /// <remarks>
        /// <br>Note       : グリッドにバインドさせるデータセットを取得します。</br>
        /// <br>Programmer : 30413 犬飼</br>
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
        /// データ検索処理(１アレイ目)
        /// </summary>
        /// <param name="totalCount">全該当件数</param>
        /// <param name="readCount">抽出対象件数</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 先頭からキャリアの全データを検索し、抽出結果を展開したDataSetと全該当件数を返します。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.30</br>
        /// </remarks>
        public int Search(ref int totalCount, int readCount)
        {
            int status = 0;
            ArrayList retList = null;

            // ADD 2009/03/25 不具合対応[12719]：「削除済データの表示」は最上位項目で制御 ---------->>>>>
            // 抽出対象件数が負の場合、強制的に終了
            if (readCount < 0)
            {
                // DataSetの情報をクリア
                this.Bind_DataSet.Tables[MAIN_TABLE].Rows.Clear();
                this.Bind_DataSet.Tables[SECOND_TABLE].Rows.Clear();
                this.Bind_DataSet.Tables[THIRD_TABLE].Rows.Clear();
                return 0;
            }
            // ADD 2009/03/25 不具合対応[12719]：「削除済データの表示」は最上位項目で制御 ----------<<<<<

            if (readCount == 0)
            {
                // 抽出対象件数が0の場合は全件抽出を実行する
                status = this._uoeSupplierAcs.SearchAll(out retList, this._enterpriseCode, this._sectionCode);

                this._totalCount = retList.Count;
            }

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                    {

                        // DataSetの情報をクリア
                        this.Bind_DataSet.Tables[MAIN_TABLE].Rows.Clear();
                        this.Bind_DataSet.Tables[SECOND_TABLE].Rows.Clear();
                        this.Bind_DataSet.Tables[THIRD_TABLE].Rows.Clear();

                        // 取得したUOE発注先クラスをデータセットへ展開する
                        int index = 0;

                        foreach (UOESupplier wkUOESupplier in retList)
                        {
                            // UOE発注先クラスデータセット展開処理
                            UOESupplierToDataSet(wkUOESupplier.Clone(), index);
                            index++;
                        }
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    {
                        // サーチ結果 UOE発注先マスタ読み込み0件
                        TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                        this.Name,
                                        "発注先が存在しません。",
                                        -1,
                                        MessageBoxButtons.OK);
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                         break;
                    }


                default:
                    // サーチ結果 UOE発注先マスタ読み込み失敗
                    TMsgDisp.Show(
                        this, 									    // 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_STOP, 			    // エラーレベル
                        PG_ID,      							    // アセンブリＩＤまたはクラスＩＤ
                        PG_NM,	        					        // プログラム名称
                        "Search", 								    // 処理名称
                        TMsgDisp.OPE_GET, 						    // オペレーション
                        "UOE発注先情報の読み込みに失敗しました。", 	// 表示するメッセージ
                        status, 								    // ステータス値
                        this._uoeSupplierAcs,	 				    // エラーが発生したオブジェクト
                        MessageBoxButtons.OK, 					    // 表示するボタン
                        MessageBoxDefaultButton.Button1);		    // 初期表示ボタン

                    break;
            }

            // 戻り値セット
            totalCount = this._totalCount;

            // 削除日を設定
            SetDelateDateOfFirstTable(null);

            return status;
        }

        /// <summary>
        /// ネクストデータ検索処理(１アレイ目)
        /// </summary>
        /// <param name="readCount">抽出対象件数</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : ArrayTypeでは未実装</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.30</br>
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
        /// <br>Date       : 2008.06.30</br>
        /// </remarks>
        public int SecondDataSearch(ref int totalCount, int readCount)
        {
            int status = 0;

            // DataSetの情報をクリア
            this.Bind_DataSet.Tables[SECOND_TABLE].Rows.Clear();

            // ADD 2009/03/25 不具合対応[12719]：「削除済データの表示」は最上位項目で制御 ---------->>>>>
            // 抽出対象件数が負の場合、強制的に終了
            if (readCount < 0)
            {
                this.Bind_DataSet.Tables[THIRD_TABLE].Rows.Clear();
                return 0;
            }

            // 現在のUOE発注先コードを取得
            int uoeSupplierCode = int.Parse(this.Bind_DataSet.Tables[MAIN_TABLE].Rows[this._mainDataIndex][M_UOESUPPLIERCD].ToString());
            // ADD 2009/03/25 不具合対応[12719]：「削除済データの表示」は最上位項目で制御 ----------<<<<<

            // ガイド区分はDB検索を行わずに固定表示とする
            for (int i = 0; i < 4; i++)
            {
                // ガイド区分データセット展開処理
                UOEGuideDivToSecondDataSet(i, uoeSupplierCode); // ADD 2009/03/25 不具合対応[12719]：「削除済データの表示」は最上位項目で制御…uoeSupplierCodeを追加
            }

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
        /// <br>Date       : 2008.06.30</br>
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
        /// <br>Date       : 2008.07.01</br>
        /// </remarks>
        public int ThirdDataSearch(ref int totalCount, int readCount)
        {
            int status = 0;
            ArrayList retList = null;

            if ((this.Bind_DataSet == null) || (this._mainDataIndex < 0))
            {
                // メインGridでデータが無ければ検索を行わない
                return status;
            }

            // DataSetの情報をクリア
            this.Bind_DataSet.Tables[THIRD_TABLE].Rows.Clear();

            // ADD 2009/03/25 不具合対応[12719]：「削除済データの表示」は最上位項目で制御 ---------->>>>>
            // 抽出対象件数が負の場合、強制的に終了
            if (readCount < 0) return 0;
            // ADD 2009/03/25 不具合対応[12719]：「削除済データの表示」は最上位項目で制御 ----------<<<<<

            // 2009.01.22 30413 犬飼 発注先コードのゼロ詰め対応 >>>>>>START
            // Form メインGridの情報を取得
            //int uoeSupplierCd = (int)this.Bind_DataSet.Tables[MAIN_TABLE].Rows[this._mainDataIndex][M_UOESUPPLIERCD];
            int uoeSupplierCd = int.Parse((string)this.Bind_DataSet.Tables[MAIN_TABLE].Rows[this._mainDataIndex][M_UOESUPPLIERCD]);
            // 2009.01.22 30413 犬飼 発注先コードのゼロ詰め対応 <<<<<<END
            // Form Second Gridの情報を取得
            int uoeGuideDivCd = (int)this.Bind_DataSet.Tables[SECOND_TABLE].Rows[this._secondDataIndex][S_UOEGUIDEDIVCD];

            // UOEガイド名称マスタの検索条件を設定
            UOEGuideName uoeGuideName = new UOEGuideName();
            uoeGuideName.EnterpriseCode = this._enterpriseCode;
            uoeGuideName.SectionCode = this._sectionCode;
            uoeGuideName.UOESupplierCd = uoeSupplierCd;
            uoeGuideName.UOEGuideDivCd = uoeGuideDivCd;

            if (readCount == 0)
            {
                // 抽出対象件数が0の場合は全件抽出を実行する
                status = this._uoeGuideNameAcs.SearchAll(out retList, uoeGuideName);

                this._totalCount = retList.Count;
            }

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                    {
                        // 取得したUOEガイド名称クラスをデータセットへ展開する
                        int index = 0;
                        SortedList wkSort = new SortedList();

                        foreach (UOEGuideName wkUOEGuideName in retList)
                        {
                            if (wkUOEGuideName.UOEGuideDivCd == uoeGuideDivCd)
                            {
                                // ガイド区分が一致するデータを抽出(区分:0の場合は全件取得の為)
                                string key = wkUOEGuideName.UOEGuideCode;
                                // 取得したUOEガイド名称クラスをソート
                                wkSort.Add(key, wkUOEGuideName);
                            }
                        }

                        for (int i = 0; i < wkSort.Count; i++)
                        {
                            // UOEガイド名称クラスデータセット展開処理
                            UOEGuideNameToThirdDataSet((UOEGuideName)wkSort.GetByIndex(i), ref index);
                        }

                        break;
                    }
                default:
                    {
                        // Third Gridデータ検索処理
                        TMsgDisp.Show(
                            this, 								        // 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_STOP, 		        // エラーレベル
                            PG_ID, 						                // アセンブリＩＤまたはクラスＩＤ
                            PG_NM,        					            // プログラム名称
                            "ThirdDataSearch", 				            // 処理名称
                            TMsgDisp.OPE_GET, 					        // オペレーション
                            "UOEガイド名称情報の読み込みに失敗しました。",	// 表示するメッセージ
                            status, 							        // ステータス値
                            this._uoeGuideNameAcs, 				        // エラーが発生したオブジェクト
                            MessageBoxButtons.OK, 				        // 表示するボタン
                            MessageBoxDefaultButton.Button1);	        // 初期表示ボタン

                        break;
                    }
            }

            totalCount = this._totalCount;
            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            // First/Secondテーブルの削除日を設定
            ArrayList allUOEGuideDivCdList = new ArrayList();
            if (readCount == 0)
            {
                // 現在の発注先コードを対象とし、全ガイド区分を検索
                uoeGuideName.UOEGuideDivCd = 0;
                status = this._uoeGuideNameAcs.SearchAll(out allUOEGuideDivCdList, uoeGuideName);

                // HACK:全検索結果をキャッシュ
                CacheModelNameUList(uoeGuideName, allUOEGuideDivCdList);    // ADD 2009/03/25 不具合対応[12719]：「削除済データの表示」は最上位項目で制御
            }

            // HACK:Secondテーブルの削除日を設定
            SetDelateDateOfSecondTable(uoeGuideName);   // ADD 2008/03/25 不具合対応[12719]：「削除済データの表示」は最上位項目で制御

            // HACK:Firstテーブルの削除日を設定
            SetDelateDateOfFirstTable(uoeGuideName);    // ADD 2008/03/25 不具合対応[12719]：「削除済データの表示」は最上位項目で制御

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
        /// <br>Date       : 2008.07.01</br>
        /// </remarks>
        public int Delete()
        {
            int status = 0;

            // Form メインGridの情報を取得
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
                        // 排他処理
                        ExclusiveTransaction(status, TMsgDisp.OPE_DELETE, this._uoeGuideNameAcs);
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
                            PG_NM,  							// プログラム名称
                            "Delete",							// 処理名称
                            TMsgDisp.OPE_HIDE,					// オペレーション
                            ERR_RDEL_MSG,						// 表示するメッセージ 
                            status,								// ステータス値
                            this._uoeGuideNameAcs,				// エラーが発生したオブジェクト
                            MessageBoxButtons.OK,				// 表示するボタン
                            MessageBoxDefaultButton.Button1);	// 初期表示ボタン

                        return status;
                    }
            }

            // データセット展開処理
            int index = this._thirdDataIndex;
            UOEGuideNameToThirdDataSet(uoeGuideName, ref index);

            // ADD 2009/03/25 不具合対応[12719]：「削除済データの表示」は最上位項目で制御 ---------->>>>>
            // 再検索（各テーブルの値を再設定）
            int totalCount = 0;
            ThirdDataSearch(ref totalCount, 0);
            // ADD 2009/03/25 不具合対応[12719]：「削除済データの表示」は最上位項目で制御 ----------<<<<<

            return status;
        }

        /// <summary>
        /// 印刷処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 印刷処理を実行します。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.30</br>
        /// </remarks>
        public int Print()
        {
            // 印刷用アセンブリをロードする（未実装）
            return 0;
        }

        /// <summary>
        /// グリッド列外観情報取得処理
        /// </summary>
        /// <returns>グリッド列外観情報格納Hashtable</returns>
        /// <remarks>
        /// <br>Note       : 各列の外見を設定するクラスを格納したHashtableを取得します。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.30</br>
        /// </remarks>
        public void GetAppearanceTable(out Hashtable[] _hashtable)
        {
            //==============================
            // メイン
            //==============================
            Hashtable main = new Hashtable();

            main.Add(T_DELETEDATE, new GridColAppearance(MGridColDispType.DeletionDataListOnly, ContentAlignment.MiddleLeft, "", Color.Red));   // ADD 2008/03/25 不具合対応[12719]：「削除済データの表示」は最上位項目で制御
            main.Add(M_UOESUPPLIERCD, new GridColAppearance(MGridColDispType.ListOnly, ContentAlignment.MiddleRight, "", Color.Black));
            main.Add(M_UOESUPPLIERNM, new GridColAppearance(MGridColDispType.ListOnly, ContentAlignment.MiddleLeft, "", Color.Black));
            
            //==============================
            // セカンド
            //==============================
            Hashtable second = new Hashtable();

            // 発注先コード
            second.Add(M_UOESUPPLIERCD, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));   // ADD 2008/03/25 不具合対応[12719]：「削除済データの表示」は最上位項目で制御

            second.Add(T_DELETEDATE, new GridColAppearance(MGridColDispType.DeletionDataListOnly, ContentAlignment.MiddleLeft, "", Color.Red)); // ADD 2008/03/25 不具合対応[12719]：「削除済データの表示」は最上位項目で制御
            second.Add(S_UOEGUIDEDIVCD, new GridColAppearance(MGridColDispType.ListOnly, ContentAlignment.MiddleRight, "", Color.Black));
            second.Add(S_UOEGUIDEDIVNM, new GridColAppearance(MGridColDispType.ListOnly, ContentAlignment.MiddleLeft, "", Color.Black));
            
            //==============================
            // サード
            //==============================
            Hashtable third = new Hashtable();

            // 発注先コード
            third.Add(M_UOESUPPLIERCD, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));    // ADD 2008/03/25 不具合対応[12719]：「削除済データの表示」は最上位項目で制御
            // ガイド区分
            third.Add(S_UOEGUIDEDIVCD, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));    // ADD 2008/03/25 不具合対応[12719]：「削除済データの表示」は最上位項目で制御

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
        /// データセット列情報構築処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : データセットの列情報を構築します。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.30</br>
        /// </remarks>
        private void DataSetColumnConstruction()
        {
            //==========================
            // メインテーブル定義
            //==========================
            DataTable mainTable = new DataTable(MAIN_TABLE);

            // 削除日
            mainTable.Columns.Add(T_DELETEDATE, typeof(string));    // ADD 2008/03/25 不具合対応[12719]：「削除済データの表示」は最上位項目で制御

            // 2009.01.22 30413 犬飼 発注先コードのゼロ詰め対応 >>>>>>START
            // 発注先コード
            //mainTable.Columns.Add(M_UOESUPPLIERCD, typeof(int));
            mainTable.Columns.Add(M_UOESUPPLIERCD, typeof(string));
            // 2009.01.22 30413 犬飼 発注先コードのゼロ詰め対応 <<<<<<END
            // 発注先名称
            mainTable.Columns.Add(M_UOESUPPLIERNM, typeof(string));
            
            this.Bind_DataSet.Tables.Add(mainTable);

            //==========================
            // セカンドテーブル定義
            //==========================
            DataTable secondTable = new DataTable(SECOND_TABLE);

            // 削除日
            secondTable.Columns.Add(T_DELETEDATE, typeof(string));  // ADD 2008/03/25 不具合対応[12719]：「削除済データの表示」は最上位項目で制御

            // 発注先コード
            secondTable.Columns.Add(M_UOESUPPLIERCD, typeof(int));  // ADD 2008/03/25 不具合対応[12719]：「削除済データの表示」は最上位項目で制御

            // ガイド区分
            secondTable.Columns.Add(S_UOEGUIDEDIVCD, typeof(int));
            // ガイド区分名称
            secondTable.Columns.Add(S_UOEGUIDEDIVNM, typeof(string));
            
            this.Bind_DataSet.Tables.Add(secondTable);

            //==========================
            // サードテーブル定義
            //==========================
            DataTable thirdTable = new DataTable(THIRD_TABLE);

            // 発注先コード
            thirdTable.Columns.Add(M_UOESUPPLIERCD, typeof(int));   // ADD 2008/03/25 不具合対応[12719]：「削除済データの表示」は最上位項目で制御
            // ガイド区分
            thirdTable.Columns.Add(S_UOEGUIDEDIVCD, typeof(int));   // ADD 2008/03/25 不具合対応[12719]：「削除済データの表示」は最上位項目で制御

            // 削除日
            thirdTable.Columns.Add(T_DELETEDATE, typeof(string));
            // ガイドコード
            thirdTable.Columns.Add(T_UOEGUIDECODE, typeof(string));
            // ガイド名称
            thirdTable.Columns.Add(T_UOEGUIDENAME, typeof(string));
            // ガイドGUID
            thirdTable.Columns.Add(T_UOEGUIDECODE_GUID, typeof(string));

            this.Bind_DataSet.Tables.Add(thirdTable);
        }

        # endregion

        # region ■Private Methods

        /// <summary>
        /// UOE発注先クラスデータセット展開処理
        /// </summary>
        /// <param name="uoeSupplier">UOE発注先クラス</param>
        /// <param name="index">データセットへ展開するインデックス</param>
        /// <remarks>
        /// <br>Note       : UOE発注先クラスをデータセットへ格納します。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.07.01</br>
        /// </remarks>
        private void UOESupplierToDataSet(UOESupplier uoeSupplier, int index)
        {
            if (uoeSupplier.LogicalDeleteCode == 0)
            {
                // メインGridに格納するデータを設定
                if ((index < 0) || (this.Bind_DataSet.Tables[MAIN_TABLE].Rows.Count <= index))
                {
                    // 新規と判断して、行を追加する
                    DataRow dataRow = this.Bind_DataSet.Tables[MAIN_TABLE].NewRow();
                    this.Bind_DataSet.Tables[MAIN_TABLE].Rows.Add(dataRow);

                    // indexを行の最終行番号にする
                    index = this.Bind_DataSet.Tables[MAIN_TABLE].Rows.Count - 1;
                }

                // 削除日
                this.Bind_DataSet.Tables[MAIN_TABLE].Rows[index][T_DELETEDATE] = GetDeleteDate(uoeSupplier);    // ADD 2008/03/25 不具合対応[12719]：「削除済データの表示」は最上位項目で制御

                // 2009.01.22 30413 犬飼 発注先コードのゼロ詰め対応 >>>>>>START
                // 発注先コード
                //this.Bind_DataSet.Tables[MAIN_TABLE].Rows[index][M_UOESUPPLIERCD] = uoeSupplier.UOESupplierCd;
                this.Bind_DataSet.Tables[MAIN_TABLE].Rows[index][M_UOESUPPLIERCD] = uoeSupplier.UOESupplierCd.ToString("d06");
                // 2009.01.22 30413 犬飼 発注先コードのゼロ詰め対応 <<<<<<END
            
                // 発注先名称
                this.Bind_DataSet.Tables[MAIN_TABLE].Rows[index][M_UOESUPPLIERNM] = uoeSupplier.UOESupplierName;
            }
        }

        /// <summary>
        /// UOEガイド名称クラスSecond Gridデータセット展開処理
        /// </summary>
        /// <param name="index">データセットへ展開するインデックス</param>
        /// <param name="uoeSupplierCode">UOE発注先コード</param>
        /// <remarks>
        /// <br>Note       : UOEガイド名称クラスをSecond Gridデータセットへ格納します。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.07.01</br>
        /// </remarks>
        private void UOEGuideDivToSecondDataSet(int index, int uoeSupplierCode) // ADD 2008/03/25 不具合対応[12719]：「削除済データの表示」は最上位項目で制御…uoeSupplierCodeを追加
        {
            // Second Gridに格納するデータを設定
            if (this.Bind_DataSet.Tables[SECOND_TABLE].Rows.Count <= index)
            {
                // 新規と判断して、行を追加する
                DataRow dataRow = this.Bind_DataSet.Tables[SECOND_TABLE].NewRow();
                this.Bind_DataSet.Tables[SECOND_TABLE].Rows.Add(dataRow);

                // indexを行の最終行番号する
                index = this.Bind_DataSet.Tables[SECOND_TABLE].Rows.Count - 1;
            }

            // UOE発注先コード
            this.Bind_DataSet.Tables[SECOND_TABLE].Rows[index][M_UOESUPPLIERCD] = uoeSupplierCode;  // ADD 2008/03/25 不具合対応[12719]：「削除済データの表示」は最上位項目で制御

            // UOEガイド区分
            this.Bind_DataSet.Tables[SECOND_TABLE].Rows[index][S_UOEGUIDEDIVCD] = index;

            // UOEガイド区分名称
            switch (index)
            {
                case 0:
                    {
                        this.Bind_DataSet.Tables[SECOND_TABLE].Rows[index][S_UOEGUIDEDIVNM] = "業務区分";
                        break;
                    }
                case 1:
                    {
                        this.Bind_DataSet.Tables[SECOND_TABLE].Rows[index][S_UOEGUIDEDIVNM] = "BO区分";
                        break;
                    }
                case 2:
                    {
                        this.Bind_DataSet.Tables[SECOND_TABLE].Rows[index][S_UOEGUIDEDIVNM] = "納品区分";
                        break;
                    }
                case 3:
                    {
                        this.Bind_DataSet.Tables[SECOND_TABLE].Rows[index][S_UOEGUIDEDIVNM] = "拠点区分";
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
        /// UOEガイド名称クラスThird Gridデータセット展開処理
        /// </summary>
        /// <param name="uoeGuideName">UOEガイド名称クラス</param>
        /// <param name="index">データセットへ展開するインデックス</param>
        /// <remarks>
        /// <br>Note       : UOEガイド名称クラスを詳細GRIDデータセットへ格納します。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.07.01</br>
        /// </remarks>
        private void UOEGuideNameToThirdDataSet(UOEGuideName uoeGuideName, ref int index)
        {
            // Third Gridに格納するデータを設定
            if ((index < 0) || (this.Bind_DataSet.Tables[THIRD_TABLE].Rows.Count <= index))
            {
                // 新規と判断して、行を追加する
                DataRow dataRow = this.Bind_DataSet.Tables[THIRD_TABLE].NewRow();
                this.Bind_DataSet.Tables[THIRD_TABLE].Rows.Add(dataRow);

                // indexを行の最終行番号する
                index = this.Bind_DataSet.Tables[THIRD_TABLE].Rows.Count - 1;
            }

            // UOE発注先コード
            this.Bind_DataSet.Tables[THIRD_TABLE].Rows[index][M_UOESUPPLIERCD] = uoeGuideName.UOESupplierCd;    // ADD 2009/03/25 不具合対応[12719]：「削除済データの表示」は最上位項目で制御
            // UOEガイド区分
            this.Bind_DataSet.Tables[THIRD_TABLE].Rows[index][S_UOEGUIDEDIVCD] = uoeGuideName.UOEGuideDivCd;    // ADD 2009/03/25 不具合対応[12719]：「削除済データの表示」は最上位項目で制御

            // 削除日
            if (uoeGuideName.LogicalDeleteCode == 0)
            {
                this.Bind_DataSet.Tables[THIRD_TABLE].Rows[index][T_DELETEDATE] = "";
            }
            else
            {
                // DEL 2009/03/25 不具合対応[12719]↓：「削除済データの表示」は最上位項目で制御
                //this.Bind_DataSet.Tables[THIRD_TABLE].Rows[index][T_DELETEDATE] = TDateTime.DateTimeToString("ggYY/MM/DD", uoeGuideName.UpdateDateTime);
                this.Bind_DataSet.Tables[THIRD_TABLE].Rows[index][T_DELETEDATE] = FormatDeleteDate(uoeGuideName.UpdateDateTime);    // ADD 2008/03/25 不具合対応[12719]：「削除済データの表示」は最上位項目で制御
            }

            // UOEガイドコード
            this.Bind_DataSet.Tables[THIRD_TABLE].Rows[index][T_UOEGUIDECODE] = uoeGuideName.UOEGuideCode;

            // UOEガイドコード名称
            this.Bind_DataSet.Tables[THIRD_TABLE].Rows[index][T_UOEGUIDENAME] = uoeGuideName.UOEGuideNm;
            
            // ガイドコードGUID
            this.Bind_DataSet.Tables[THIRD_TABLE].Rows[index][T_UOEGUIDECODE_GUID] = CreateHashKeyThird(uoeGuideName);

            // ハッシュ検索用にGUIDセット
            if (this._thirdGridTable.ContainsKey(CreateHashKeyThird(uoeGuideName)) == true)
            {
                this._thirdGridTable.Remove(CreateHashKeyThird(uoeGuideName));
            }
            this._thirdGridTable.Add(CreateHashKeyThird(uoeGuideName), uoeGuideName);

            index++;
        }

        // ADD 2009/03/25 不具合対応[12719]：「削除済データの表示」は最上位項目で制御 ---------->>>>>
        /// <summary>
        /// 削除日を書式付で取得します。
        /// </summary>
        /// <param name="updateDateTime">更新日時</param>
        /// <returns>"ggYY/MM/DD"</returns>
        private static string FormatDeleteDate(DateTime updateDateTime)
        {
            return TDateTime.DateTimeToString("ggYY/MM/DD", updateDateTime);
        }

        /// <summary>
        /// UOE発注先の削除日を取得します。
        /// </summary>
        /// <param name="record">UOE発注先のレコード</param>
        /// <returns>書式付の削除日（※削除されていない場合、<c>string.Empty</c>を返します。）</returns>
        private static string GetDeleteDate(UOESupplier record)
        {
            return record.LogicalDeleteCode.Equals(0) ? string.Empty : FormatDeleteDate(record.UpdateDateTime);
        }

        #region <UOEガイド名称のキャッシュ/>

        /// <summary>UOEガイド名称のキャッシュ</summary>
        /// <remarks>
        /// 第1キー：UOE発注先コード<br/>
        /// 第2キー：UOE発注先コード("000000") + UOEガイド区分コード("00")
        /// </remarks>
        private readonly IDictionary<int, IDictionary<string, ArrayList>> _modelNameUListCacheMap = new Dictionary<int, IDictionary<string, ArrayList>>();
        /// <summary>
        /// UOEガイド名称のキャッシュを取得します。
        /// </summary>
        private IDictionary<int, IDictionary<string, ArrayList>> ModelNameUListCacheMap
        {
            get { return _modelNameUListCacheMap; }
        }

        /// <summary>
        /// UOEガイド名称のキャッシュのキー(第2テーブル用)を取得します。
        /// </summary>
        /// <param name="uoeSupplierCode">UOE発注先コード</param>
        /// <param name="uoeGuideDivCode">UOEガイド区分コード</param>
        /// <returns>UOE発注先コード("000000") + UOEガイド区分コード("00")</returns>
        private static string GetSecondKey(
            int uoeSupplierCode,
            int uoeGuideDivCode
        )
        {
            return uoeSupplierCode.ToString("000000") + uoeGuideDivCode.ToString("00");
        }

        /// <summary>
        /// HACK:UOEガイド名称をキャッシュします。
        /// </summary>
        /// <param name="searchingCondition">検索条件</param>
        /// <param name="uoeGuideNameList">UOEガイド名称の全レコードリスト</param>
        private void CacheModelNameUList(
            UOEGuideName searchingCondition,
            ArrayList allUOEGuideNameList
        )
        {
            if (allUOEGuideNameList == null) return;

            // 該当するUOE発注先コードに対応するキャッシュを更新
            if (ModelNameUListCacheMap.ContainsKey(searchingCondition.UOESupplierCd))
            {
                ModelNameUListCacheMap.Remove(searchingCondition.UOESupplierCd);
            }
            ModelNameUListCacheMap.Add(searchingCondition.UOESupplierCd, new Dictionary<string, ArrayList>());

            // UOE発注先コードとUOEガイド区分コードで分別
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

        // UNDONE:UOEガイド名称キャッシュの初期化

        #endregion  // <UOEガイド名称のキャッシュ/>

        /// <summary>
        /// 第2テーブルの削除日を設定します。
        /// </summary>
        [Conditional("DELETE_DATE_DEPEND_ON_SUB_TABLE")]
        private void SetDelateDateOfSecondTable(UOEGuideName searchedCondition)
        {
            const string MAIN_TABLE_NAME        = SECOND_TABLE;
            const string RELATION_COLUMN_NAME   = S_UOEGUIDEDIVCD;
            const string SUB_TABLE_NAME         = THIRD_TABLE;
            const string DELETE_DATE_COLUMN_NAME= T_DELETEDATE;

            // 現在のUOE発注先コードを取得
            int uoeSupplierCode = int.Parse(this.Bind_DataSet.Tables[MAIN_TABLE].Rows[this._mainDataIndex][M_UOESUPPLIERCD].ToString());

            foreach (DataRow mainRow in this.Bind_DataSet.Tables[MAIN_TABLE_NAME].Rows)
            {
                // 対応するサブテーブルのレコードを抽出
                int relationColumn = (int)mainRow[RELATION_COLUMN_NAME];
                DataRow[] foundSubRows = this.Bind_DataSet.Tables[SUB_TABLE_NAME].Select(
                    RELATION_COLUMN_NAME + "=" + relationColumn.ToString() + " AND " + M_UOESUPPLIERCD + "=" + uoeSupplierCode.ToString()
                );
                Debug.WriteLine("関連 = " + relationColumn.ToString() + ":" + foundSubRows.Length.ToString() + "件");

                if (foundSubRows.Length.Equals(0))
                {
                    #region サブテーブルに該当レコードが無い場合、DB検索結果（キャッシュ）より設定

                    // UOE発注先コードで抽出
                    IDictionary<string, ArrayList> uoeGuideNameListGroupedUOESupplierCode = null;
                    if (!ModelNameUListCacheMap.ContainsKey(uoeSupplierCode))
                    {
                        ArrayList allUOEGuideDivCdList = new ArrayList();
                        searchedCondition.UOESupplierCd = uoeSupplierCode;
                        int status = this._uoeGuideNameAcs.SearchAll(out allUOEGuideDivCdList, searchedCondition);
                        CacheModelNameUList(searchedCondition, allUOEGuideDivCdList);

                        // 該当するUOE発注先コードのレコードがない場合
                        if (allUOEGuideDivCdList == null || allUOEGuideDivCdList.Count.Equals(0)) return;
                    }
                    uoeGuideNameListGroupedUOESupplierCode = ModelNameUListCacheMap[uoeSupplierCode];

                    // ユーザーガイド区分コードで抽出
                    string secondKey = GetSecondKey(uoeSupplierCode, (int)mainRow[RELATION_COLUMN_NAME]);

                    // 該当するユーザーガイド区分コードがない場合
                    if (!uoeGuideNameListGroupedUOESupplierCode.ContainsKey(secondKey)) continue;

                    ArrayList uoeGuideNameList = null;
                    uoeGuideNameList = uoeGuideNameListGroupedUOESupplierCode[secondKey];

                    // 削除日を降順で抽出
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

                    // レコードが全件削除されている場合
                    string deleteDate = string.Empty;
                    if (deleteRowCount > 0 && deleteRowCount.Equals(uoeGuideNameList.Count))
                    {
                        deleteDate = sortedDeleteDateList.Values[0];
                    }
                    mainRow[DELETE_DATE_COLUMN_NAME] = deleteDate;

                    #endregion  // サブテーブルに該当レコードが無い場合、DB検索結果（キャッシュ）より設定
                }
                else
                {
                    #region サブテーブルに該当レコードがある場合、サブテーブルより設定

                    // 削除日を抽出
                    int deleteRowCount = 0;
                    SortedList<string, string> sortedDeleteDateList = new SortedList<string, string>(
                        new ReverseComparer<string>()
                    );
                    foreach (DataRow subRow in foundSubRows)
                    {
                        Debug.WriteLine("削除日：" + subRow[DELETE_DATE_COLUMN_NAME].ToString());
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

                    // サブテーブルが全件削除されている場合
                    string deleteDate = string.Empty;
                    if (deleteRowCount > 0 && deleteRowCount.Equals(foundSubRows.Length))
                    {
                        deleteDate = sortedDeleteDateList.Values[0];
                    }
                    mainRow[DELETE_DATE_COLUMN_NAME] = deleteDate;

                    #endregion  // サブテーブルに該当レコードがある場合、サブテーブルより設定
                }
            }
        }

        /// <summary>
        /// 第1テーブルの削除日を設定します。
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
                // 対応するサブテーブルのレコードを抽出
                int relationColumn = int.Parse(mainRow[RELATION_COLUMN_NAME].ToString());
                DataRow[] foundSubRows = this.Bind_DataSet.Tables[SUB_TABLE_NAME].Select(
                    RELATION_COLUMN_NAME + "=" + relationColumn.ToString()
                );
                Debug.WriteLine("関連 = " + relationColumn.ToString() + ":" + foundSubRows.Length.ToString() + "件");

                if (foundSubRows.Length.Equals(0))
                {
                    #region サブテーブルに該当レコードが無い場合、DB検索結果（キャッシュ）より設定

                    // UOE発注先コードで抽出
                    int uoeSupplierCode = relationColumn;
                    IDictionary<string, ArrayList> uoeGuideNameListGroupedUOESupplierCode = null;
                    if (!ModelNameUListCacheMap.ContainsKey(uoeSupplierCode))
                    {
                        ArrayList allUOEGuideDivCdList = new ArrayList();
                        searchedCondition.UOESupplierCd = uoeSupplierCode;
                        int status = this._uoeGuideNameAcs.SearchAll(out allUOEGuideDivCdList, searchedCondition);
                        CacheModelNameUList(searchedCondition, allUOEGuideDivCdList);

                        // FIXME:該当するUOE発注先コードのレコードがない場合
                        if (allUOEGuideDivCdList == null || allUOEGuideDivCdList.Count.Equals(0))
                        {
                            continue;
                        }
                    }
                    uoeGuideNameListGroupedUOESupplierCode = ModelNameUListCacheMap[uoeSupplierCode];

                    // 削除日を降順で抽出
                    int deleteRowCount = 0;
                    SortedList<string, string> sortedDeleteDateList = new SortedList<string, string>(
                        new ReverseComparer<string>()
                    );

                    // ユーザーガイド区分コードで抽出
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

                    // レコードが全件削除されている場合
                    string deleteDate = string.Empty;
                    if (deleteRowCount > 0 && deleteRowCount.Equals(uoeGuideNameCount))
                    {
                        deleteDate = sortedDeleteDateList.Values[0];
                    }
                    mainRow[DELETE_DATE_COLUMN_NAME] = deleteDate;

                    #endregion  // サブテーブルに該当レコードが無い場合、DB検索結果（キャッシュ）より設定
                }
                else
                {
                    #region サブテーブルに該当レコードがある場合、サブテーブルより設定

                    // 削除日を抽出
                    int deleteRowCount = 0;
                    SortedList<string, string> sortedDeleteDateList = new SortedList<string, string>(
                        new ReverseComparer<string>()
                    );
                    foreach (DataRow subRow in foundSubRows)
                    {
                        Debug.WriteLine("削除日：" + subRow[DELETE_DATE_COLUMN_NAME].ToString());
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

                    // サブテーブルが全件削除されている場合
                    string deleteDate = string.Empty;
                    if (deleteRowCount > 0 && deleteRowCount.Equals(foundSubRows.Length))
                    {
                        deleteDate = sortedDeleteDateList.Values[0];
                    }
                    mainRow[DELETE_DATE_COLUMN_NAME] = deleteDate;

                    #endregion  // サブテーブルに該当レコードがある場合、サブテーブルより設定
                }
            }
        }
        // ADD 2009/03/25 不具合対応[12719]：「削除済データの表示」は最上位項目で制御 ----------<<<<<

        /// <summary>
        /// UOEガイド名称マスタ クラス画面展開処理
        /// </summary>
        /// <param name="uoeGuideName">UOEガイド名称マスタ オブジェクト</param>
        /// <remarks>
        /// <br>Note       : UOEガイド名称マスタ オブジェクトから画面にデータを展開します。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.07.01</br>
        /// </remarks>
        private void UOEGuideNameToScreen(UOEGuideName uoeGuideName)
        {
            this.UOESupplierCd_tNedit.SetInt(uoeGuideName.UOESupplierCd);                           // 発注先コード
            this.UOESupplierNm_tEdit.Text = GetUOESupplierName(uoeGuideName.UOESupplierCd);         // 発注先名称
            this.UOEGuideDivCd_tNedit.SetInt(uoeGuideName.UOEGuideDivCd);                           // ガイド区分
            // UOEガイド区分名称
            switch (uoeGuideName.UOEGuideDivCd)
            {
                case 0:
                    {
                        this.UOEGuideDivNm_tEdit.Text = "業務区分";
                        //this.UOEGuideCode_tEdit.ExtEdit.EnableChars.Space = false; // 2008/12/10 G.Miyatsu ADD
                        break;
                    }
                case 1:
                    {
                        this.UOEGuideDivNm_tEdit.Text = "BO区分";
                        //this.UOEGuideCode_tEdit.ExtEdit.EnableChars.Space = true; // 2008/12/10 G.Miyatsu ADD
                        break;
                    }
                case 2:
                    {
                        this.UOEGuideDivNm_tEdit.Text = "納品区分";
                        //this.UOEGuideCode_tEdit.ExtEdit.EnableChars.Space = true; // 2008/12/10 G.Miyatsu ADD
                        break;
                    }
                case 3:
                    {
                        this.UOEGuideDivNm_tEdit.Text = "拠点区分";
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
            this.UOEGuideCode_tEdit.Text = uoeGuideName.UOEGuideCode;                               // ガイドコード
            this.UOEGuideName_tEdit.Text = uoeGuideName.UOEGuideNm;                                 // ガイド名称
        }

        /// <summary>
        /// 画面情報UOEガイド名称マスタ クラス格納処理
        /// </summary>
        /// <param name="uoeGuideName">UOEガイド名称マスタ オブジェクト</param>
        /// <remarks>
        /// <br>Note       : 画面情報からUOEガイド名称マスタ オブジェクトにデータを格納します。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.07.01</br>
        /// </remarks>
        private void DispToUOEGuideName(ref UOEGuideName uoeGuideName)
        {
            if (uoeGuideName == null)
            {
                // 新規の場合
                uoeGuideName = new UOEGuideName();
            }

            uoeGuideName.EnterpriseCode = this._enterpriseCode;                                     // 企業コード
            uoeGuideName.SectionCode = this._sectionCode;
            uoeGuideName.UOESupplierCd = this.UOESupplierCd_tNedit.GetInt();                        // 発注先コード
            uoeGuideName.UOEGuideDivCd = this.UOEGuideDivCd_tNedit.GetInt();                        // ガイド区分
            uoeGuideName.UOEGuideCode = this.UOEGuideCode_tEdit.Text;                               // ガイドコード
            uoeGuideName.UOEGuideNm = this.UOEGuideName_tEdit.Text;                                 // ガイド名称

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008/12/11 G.Miyatsu ADD
            uoeGuideName.UOEGuideCode = uoeGuideName.UOEGuideCode.Trim();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008/12/11 G.Miyatsu ADD
        }

        /// <summary>
        /// 画面初期設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面の初期設定を行います。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.30</br>
        /// </remarks>
        private void ScreenInitialSetting()
        {
        }

        /// <summary>
        /// 画面クリア処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面をクリアします。</br>
        /// <br>Programmer : 30413 犬飼</br>
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
        /// 画面再構築処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : モードに基づいて画面を再構築します。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.07.01</br>
        /// </remarks>
        private void ScreenReconstruction()
        {
            if (this._thirdDataIndex < 0)
            {
                // 新規モード
                this.Mode_Label.Text = INSERT_MODE;

                // 画面入力許可制御処理
                ScreenPermissionControl(INSERT_MODE);

                // FreamのIndex/Tableバッファ保持
                this._mainIndexBuffer = this._mainDataIndex;
                this._secondIndexBuffer = this._secondDataIndex;
                this._thirdIndexBuffer = this._thirdDataIndex;
                this._targetTableBuffer = this._targetTableName;

                // UOE発注先を設定
                // 2009.01.22 30413 犬飼 発注先コードのゼロ詰め対応 >>>>>>START
                //this.UOESupplierCd_tNedit.SetInt((int)this.Bind_DataSet.Tables[MAIN_TABLE].Rows[this._mainDataIndex][M_UOESUPPLIERCD]);
                this.UOESupplierCd_tNedit.SetInt(int.Parse((string)this.Bind_DataSet.Tables[MAIN_TABLE].Rows[this._mainDataIndex][M_UOESUPPLIERCD]));
                // 2009.01.22 30413 犬飼 発注先コードのゼロ詰め対応 <<<<<<END
                this.UOESupplierNm_tEdit.Text = (string)this.Bind_DataSet.Tables[MAIN_TABLE].Rows[this._mainDataIndex][M_UOESUPPLIERNM];
                // ガイド区分を設定
                this.UOEGuideDivCd_tNedit.SetInt((int)this.Bind_DataSet.Tables[SECOND_TABLE].Rows[this._secondDataIndex][S_UOEGUIDEDIVCD]);
                this.UOEGuideDivNm_tEdit.Text = (string)this.Bind_DataSet.Tables[SECOND_TABLE].Rows[this._secondDataIndex][S_UOEGUIDEDIVNM];


                //クローン作成
                UOEGuideName uoeGuideName = new UOEGuideName();
                this._uoeGuideNameClone = new UOEGuideName();
                // ADD 2008/10/30 不具合対応[7228] ---------->>>>>
                DispToUOEGuideName(ref uoeGuideName);
                // ADD 2008/10/30 不具合対応[7228] ----------<<<<<
                this._uoeGuideNameClone = uoeGuideName.Clone();

                // フォーカス設定
                this.UOEGuideCode_tEdit.Focus();
            }
            else
            {
                // 選択ガイド名称の情報を取得
                string guid = (string)this.Bind_DataSet.Tables[THIRD_TABLE].Rows[this._thirdDataIndex][T_UOEGUIDECODE_GUID];
                UOEGuideName uoeGuideName = ((UOEGuideName)this._thirdGridTable[guid]).Clone();

                if (uoeGuideName.LogicalDeleteCode == 0)
                {
                    // 更新モード
                    this.Mode_Label.Text = UPDATE_MODE;

                    // 画面入力許可制御処理
                    ScreenPermissionControl(UPDATE_MODE);

                    // 画面展開処理
                    UOEGuideNameToScreen(uoeGuideName);

                    //クローン作成
                    this._uoeGuideNameClone = new UOEGuideName();
                    this._uoeGuideNameClone = uoeGuideName.Clone();
                    
                    // フォーカス設定
                    this.UOEGuideName_tEdit.Focus();
                }
                else
                {
                    // 削除モード
                    this.Mode_Label.Text = DELETE_MODE;

                    // 画面入力許可制御処理
                    ScreenPermissionControl(DELETE_MODE);

                    // 画面展開処理
                    UOEGuideNameToScreen(uoeGuideName);

                    //クローン作成
                    this._uoeGuideNameClone = new UOEGuideName();
                    this._uoeGuideNameClone = uoeGuideName.Clone();

                    // フォーカス設定
                    this.Delete_Button.Focus();
                }

                // FreamのIndex/Tableバッファ保持
                this._mainIndexBuffer = this._mainDataIndex;
                this._secondIndexBuffer = this._secondDataIndex;
                this._thirdIndexBuffer = this._thirdDataIndex;
                this._targetTableBuffer = this._targetTableName;
            }

            // 2008.12.24 30413 犬飼 ガイドコードの桁数を設定 >>>>>>START
            // ガイドコードの桁数を設定
            ChangeGuideCodeColumn(this.UOEGuideDivCd_tNedit.GetInt());
            // 2008.12.24 30413 犬飼 ガイドコードの桁数を設定 <<<<<<END
        }

        /// <summary>
        /// 画面許可制御処理
        /// </summary>
        /// <param name="screenMode">画面モード</param>
        /// <remarks>
        /// <br>Note       : 画面モード毎に入力／ボタンの許可を制御します。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.07.01</br>
        /// </remarks>
        private void ScreenPermissionControl(string screenMode)
        {
            // 新規
            if (screenMode.Equals(INSERT_MODE))
            {
                // ボタン設定
                this.Ok_Button.Visible = true;
                this.Delete_Button.Visible = false;
                this.Revive_Button.Visible = false;
                
                // 入力設定
                this.UOESupplierCd_tNedit.Enabled = false;
                this.UOESupplierNm_tEdit.Enabled = false;
                this.UOEGuideDivCd_tNedit.Enabled = false;
                this.UOEGuideDivNm_tEdit.Enabled = false;
                this.UOEGuideCode_tEdit.Enabled = true;
                this.UOEGuideName_tEdit.Enabled = true;
            }
            // 更新
            else if (screenMode.Equals(UPDATE_MODE))
            {
                // ボタン設定
                this.Ok_Button.Visible = true;
                this.Delete_Button.Visible = false;
                this.Revive_Button.Visible = false;
                
                // 入力設定
                this.UOESupplierCd_tNedit.Enabled = false;
                this.UOESupplierNm_tEdit.Enabled = false;
                this.UOEGuideDivCd_tNedit.Enabled = false;
                this.UOEGuideDivNm_tEdit.Enabled = false;
                this.UOEGuideCode_tEdit.Enabled = false;
                this.UOEGuideName_tEdit.Enabled = true;
            }
            // 削除
            else if (screenMode.Equals(DELETE_MODE))
            {
                // ボタン設定
                this.Ok_Button.Visible = false;
                this.Delete_Button.Visible = true;
                this.Revive_Button.Visible = true;
                
                // 入力設定
                this.UOESupplierCd_tNedit.Enabled = false;
                this.UOESupplierNm_tEdit.Enabled = false;
                this.UOEGuideDivCd_tNedit.Enabled = false;
                this.UOEGuideDivNm_tEdit.Enabled = false;
                this.UOEGuideCode_tEdit.Enabled = false;
                this.UOEGuideName_tEdit.Enabled = false;                
            }

        }

        /// <summary>
        /// ガイドコードの桁数を設定
        /// </summary>
        /// <param name="guideDiv">ガイド区分</param>
        /// <remarks>
        /// <br>Note       : ガイド区分で入力桁数を設定。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.12.24</br>
        /// </remarks>
        private void ChangeGuideCodeColumn(int guideDiv)
        {
            int column = this.UOEGuideCode_tEdit.ExtEdit.Column;

            switch (guideDiv)
            {
                case 0:     // 業務区分
                    {
                        column = 1;
                        break;
                    }
                case 1:     // BO区分
                    {
                        column = 1;
                        break;
                    }
                case 2:     // 納品区分
                    {
                        column = 1;
                        break;
                    }
                case 3:     // 拠点区分
                    {
                        column = 3;
                        break;
                    }
                default:
                    {
                        break;
                    }
            }

            // ガイドコードの桁数を設定
            this.UOEGuideCode_tEdit.ExtEdit.Column = column;
        }

        /// <summary>
        /// HashTable用キー作成
        /// </summary>
        /// <param name="uoeGuideName">UOEガイド名称マスタオブジェクト</param>
        /// <returns>Hashテーブル用キー</returns>
        /// <remarks>
        /// <br>Note       : UOEガイド名称マスタからThird Gridのハッシュテーブル用のキーを作成します。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.07.01</br>
        /// </remarks>
        private string CreateHashKeyThird(UOEGuideName uoeGuideName)
        {
            string strHashKey = uoeGuideName.UOEGuideDivCd.ToString("d2") + uoeGuideName.UOEGuideCode;
            return strHashKey;
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
        /// <br>Date       : 2008.07.01</br>
        /// </remarks>
        private bool ScreenDataCheck(ref Control control, ref string message, string loginID)
        {
            // ガイドコード
            // >>>>>>>>>>>>>>>>>>>>>>>>>>> 2008/12/11 G.Miyatsu ADD
            if (this._secondDataIndex == 0)
            {
                // 2009.01.14 30413 犬飼 ゼロで登録できるように修正 >>>>>>START
                //if (this.UOEGuideCode_tEdit.Text == "0" || this.UOEGuideCode_tEdit.Text.Trim() == "")
                if (this.UOEGuideCode_tEdit.Text.Trim() == "")
                {
                    control = this.UOEGuideCode_tEdit;
                    message = this.UOEGuideCode_Label.Text + "を入力して下さい。";
                    return false;
                }
                // 2009.01.14 30413 犬飼 ゼロで登録できるように修正 <<<<<<END
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<< 2008/12/10 G.Miyatsu ADD

            // ガイド名称
            if (this.UOEGuideName_tEdit.Text.Trim() == "")
            {
                control = this.UOEGuideName_tEdit;
                message = this.UOEGuideName_Label.Text + "を入力して下さい。";
                return false;
            }

            return true;
        }

        /// <summary>
        /// UOEガイド名称マスタ 情報登録処理
        /// </summary>
        /// <returns>登録結果（true:OK／false:NG）</returns>
        /// <remarks>
        /// <br>Note       : UOEガイド名称マスタ 情報登録を行います。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.07.01</br>
        /// </remarks>
        private bool SaveProc()
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            Control control = null;
            string message = null;
            string loginID = "";

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

            UOEGuideName uoeGuideName = null;

            if (this._thirdDataIndex >= 0)
            {
                string guid = (string)this.Bind_DataSet.Tables[THIRD_TABLE].Rows[this._thirdDataIndex][T_UOEGUIDECODE_GUID];
                uoeGuideName = ((UOEGuideName)this._thirdGridTable[guid]).Clone();
            }

            //新規の場合、画面情報を条件クラスに設定
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
                            this,								// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_EXCLAMATION,	// エラーレベル
                            PG_ID,				        		// アセンブリＩＤまたはクラスＩＤ
                            ERR_DPR_MSG,						// 表示するメッセージ 
                            status,								// ステータス値
                            MessageBoxButtons.OK);				// 表示するボタン

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
                        // GridのIndexBuffer格納用変数初期化
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
                            this,								// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_STOPDISP,	// エラーレベル
                            PG_ID,      						// アセンブリＩＤまたはクラスＩＤ
                            PG_NM,  							// プログラム名称
                            "SaveProc",							// 処理名称
                            TMsgDisp.OPE_UPDATE,				// オペレーション
                            ERR_UPDT_MSG,						// 表示するメッセージ 
                            status,								// ステータス値
                            this._uoeGuideNameAcs,				// エラーが発生したオブジェクト
                            MessageBoxButtons.OK,				// 表示するボタン
                            MessageBoxDefaultButton.Button1);	// 初期表示ボタン

                        if (UnDisplaying != null)
                        {
                            MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                            UnDisplaying(this, me);
                        }

                        this.DialogResult = DialogResult.Cancel;
                        // GridのIndexBuffer格納用変数初期化
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

            // DataSet展開処理
            int index = this._thirdDataIndex;

            UOEGuideNameToThirdDataSet(uoeGuideName, ref index);

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
        /// <br>Date       : 2008.07.01</br>
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
                            PG_NM,  							// プログラム名称
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
                            PG_NM,  							// プログラム名称
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
        /// UOE発注先名称取得処理
        /// </summary>
        /// <param name="uoeSupplierCd">UOE発注先コード</param>
        /// <returns>UOE発注先名称</returns>
        /// <remarks>
        /// <br>Note       : UOE発注先名称を取得します。</br>
        /// <br>Programmer : 30413 犬飼</br>
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

        #region ■Control Events

        /// <summary>
        /// PMUOE09030UA_Load イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　  : ユーザーがフォームを読み込むときに発生します。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.30</br>
        /// </remarks>
        private void PMUOE09030UA_Load(object sender, EventArgs e)
        {
            // アイコンリソース管理クラスを使用して、アイコンを表示する
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
            
            // 画面クリア
            ScreenClear();

            // 画面初期設定
            ScreenInitialSetting();
        }

        /// <summary>
        /// Form.Closing イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">キャンセルできるイベントのデータを提供するクラス</param>
        /// <remarks>
        /// <br>Note       : フォームを閉じる前に、ユーザーがフォームを閉じようとしたときに発生します。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.30</br>
        /// </remarks>
        private void PMUOE09030UA_Closing(object sender, FormClosingEventArgs e)
        {
            // GridのIndexBuffer格納用変数初期化
            this._mainIndexBuffer = -2;
            this._secondIndexBuffer = -2;
            this._thirdIndexBuffer = -2;
            this._targetTableBuffer = "";

            // フォームの「×」をクリックされた場合の対応です。
            if (CanClose == false)
            {
                e.Cancel = true;
                this.Hide();
                return;
            }
        }

        /// <summary>
        /// Control.VisibleChanged イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note 　　  : フォームの表示状態が変わったときに発生します。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.30</br>
        /// </remarks>
        private void PMUOE09030UA_VisibleChanged(object sender, EventArgs e)
        {
            // 自分自身が非表示になった場合は以下の処理をキャンセルする。
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

            // 画面クリア
            ScreenClear();

            Initial_Timer.Enabled = true;
        }

        /// <summary>
        /// Timer.Tick イベント イベント(Initial_Timer)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : 指定された間隔の時間が経過したときに発生します。</br>
        ///	<br>             この処理は、システムが提供するスレッド プール</br>
        ///	<br>             スレッドで実行されます。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.30</br>
        /// </remarks>
        private void Initial_Timer_Tick(object sender, EventArgs e)
        {
            Initial_Timer.Enabled = false;

            // 画面再構築処理
            ScreenReconstruction();
        }

        /// <summary>
        /// Control.Click イベント(OK_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : 保存ボタンがクリックされたときに発生します。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.07.01</br>
        /// </remarks>
        private void Ok_Button_Click(object sender, EventArgs e)
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

            // 新規モードの場合は画面を終了させずに連続入力を可能とする。
            if (this.Mode_Label.Text == INSERT_MODE)
            {
                // データインデックスを初期化する
                this._thirdDataIndex = -1;

                // 画面クリア処理
                this.UOEGuideCode_tEdit.Clear();
                this.UOEGuideName_tEdit.Clear();
            }
            else
            {
                this.DialogResult = DialogResult.OK;

                // GridのIndexBuffer格納用変数初期化
                this._mainIndexBuffer = -2;
                this._secondIndexBuffer = -2;
                this._thirdIndexBuffer = -2;
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
        }

        /// <summary>
        /// Control.Click イベント(Cancel_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : 閉じるボタンがクリックされたときに発生します。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.07.01</br>
        /// </remarks>
        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            // 削除モード以外の場合は保存確認処理を行う
            if (this.Mode_Label.Text != DELETE_MODE)
            {
                //保存確認
                UOEGuideName compareUOEGuideName = new UOEGuideName();
                compareUOEGuideName = this._uoeGuideNameClone.Clone();
                //現在の画面情報を取得する
                DispToUOEGuideName(ref compareUOEGuideName);
                //最初に取得した画面情報と比較
                if (!(this._uoeGuideNameClone.Equals(compareUOEGuideName)))
                {
                    //画面情報が変更されていた場合は、保存確認メッセージを表示する
                    DialogResult res = TMsgDisp.Show(
                        this,								// 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_SAVECONFIRM,	// エラーレベル
                        PG_ID,      						// アセンブリＩＤまたはクラスＩＤ
                        "",									// 表示するメッセージ 
                        0,									// ステータス値
                        MessageBoxButtons.YesNoCancel);		// 表示するボタン

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
                                // 2009.03.31 30413 犬飼 新規モードからモード変更対応 >>>>>>START
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
                                // 2009.03.31 30413 犬飼 新規モードからモード変更対応 <<<<<<END
                                return;
                            }
                    }
                }
                
            }

            this.DialogResult = DialogResult.Cancel;

            // GridのIndexBuffer格納用変数初期化
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
        /// Control.Click イベント(Delete_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : 完全削除ボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.07.01</br>
        /// </remarks>
        private void Delete_Button_Click(object sender, System.EventArgs e)
        {
            int status = 0;
            DialogResult result = TMsgDisp.Show(
                this,													// 親ウィンドウフォーム
                emErrorLevel.ERR_LEVEL_QUESTION,						// エラーレベル
                PG_ID,      											// アセンブリＩＤまたはクラスＩＤ
                "データを削除します。" + "\r\n" + "よろしいですか？",	// 表示するメッセージ 
                0,														// ステータス値
                MessageBoxButtons.OKCancel,								// 表示するボタン
                MessageBoxDefaultButton.Button2);						// 初期表示ボタン


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
                            // GridのIndexBuffer格納用変数初期化
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
                                this,								  // 親ウィンドウフォーム
                                emErrorLevel.ERR_LEVEL_STOPDISP,	  // エラーレベル
                                PG_ID,		        				  // アセンブリＩＤまたはクラスＩＤ
                                PG_NM,  							  // プログラム名称
                                "Delete_Button_Click",				  // 処理名称
                                TMsgDisp.OPE_DELETE,				  // オペレーション
                                ERR_RDEL_MSG,						  // 表示するメッセージ 
                                status,								  // ステータス値
                                this._uoeGuideNameAcs,					  // エラーが発生したオブジェクト
                                MessageBoxButtons.OK,				  // 表示するボタン
                                MessageBoxDefaultButton.Button1);	  // 初期表示ボタン

                            if (UnDisplaying != null)
                            {
                                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                                UnDisplaying(this, me);
                            }

                            this.DialogResult = DialogResult.Cancel;
                            // GridのIndexBuffer格納用変数初期化
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

            // GridのIndexBuffer格納用変数初期化
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
        /// Control.Click イベント(Revive_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note 　　  : 復活ボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programmer : 30413 犬飼</br>
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
                        // GridのIndexBuffer格納用変数初期化
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
                            this,								  // 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_STOPDISP,	  // エラーレベル
                            PG_ID,      						  // アセンブリＩＤまたはクラスＩＤ
                            PG_NM,		    					  // プログラム名称
                            "Revive_Button_Click",				  // 処理名称
                            TMsgDisp.OPE_UPDATE,				  // オペレーション
                            ERR_RVV_MSG,						  // 表示するメッセージ 
                            status,								  // ステータス値
                            this._uoeGuideNameAcs,					  // エラーが発生したオブジェクト
                            MessageBoxButtons.OK,				  // 表示するボタン
                            MessageBoxDefaultButton.Button1);	  // 初期表示ボタン

                        if (UnDisplaying != null)
                        {
                            MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                            UnDisplaying(this, me);
                        }

                        this.DialogResult = DialogResult.Cancel;
                        // GridのIndexBuffer格納用変数初期化
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

            // DataSet展開処理
            int index = this._thirdDataIndex;
            UOEGuideNameToThirdDataSet(uoeGuideName, ref index);

            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                UnDisplaying(this, me);
            }

            this.DialogResult = DialogResult.OK;

            // GridのIndexBuffer格納用変数初期化
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

            // ADD 2009/03/25 不具合対応[12719]：「削除済データの表示」は最上位項目で制御 ---------->>>>>
            // 再検索（各テーブルの値を再設定）
            int totalCount = 0;
            ThirdDataSearch(ref totalCount, 0);
            // ADD 2009/03/25 不具合対応[12719]：「削除済データの表示」は最上位項目で制御 ----------<<<<<
        }

        # endregion

        // 2009.03.31 30413 犬飼 新規モードからモード変更対応 >>>>>>START
        /// <summary>
        /// フォーカス移動イベント
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
                            // 遷移先が閉じるボタン
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
        /// モード変更処理
        /// </summary>
        private bool ModeChangeProc()
        {
            // UOEガイドコード
            string uoeGuideCode = UOEGuideCode_tEdit.Text.TrimEnd();

            for (int i = 0; i < this.Bind_DataSet.Tables[THIRD_TABLE].Rows.Count; i++)
            {
                // データセットと比較
                string dsUOEGuideCode = (string)this.Bind_DataSet.Tables[THIRD_TABLE].Rows[i][T_UOEGUIDECODE];
                if (uoeGuideCode.Equals(dsUOEGuideCode.TrimEnd()))
                {
                    // 入力コードがデータセットに存在する場合
                    if ((string)this.Bind_DataSet.Tables[THIRD_TABLE].Rows[i][T_DELETEDATE] != "")
                    {
                        // 論理削除
                        TMsgDisp.Show(this, 					// 親ウィンドウフォーム
                          emErrorLevel.ERR_LEVEL_INFO,          // エラーレベル
                          PG_ID,						        // アセンブリＩＤまたはクラスＩＤ
                          "入力されたコードのUOEガイド名称情報は既に削除されています。", 			// 表示するメッセージ
                          0, 									// ステータス値
                          MessageBoxButtons.OK);				// 表示するボタン
                        // UOEガイドコードのクリア
                        UOEGuideCode_tEdit.Clear();
                        return true;
                    }

                    DialogResult res = TMsgDisp.Show(
                        this,                                   // 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_INFO,            // エラーレベル
                        PG_ID,                                  // アセンブリＩＤまたはクラスＩＤ
                        "入力されたコードのUOEガイド名称情報が既に登録されています。\n編集を行いますか？",                                    // 表示するメッセージ
                        0,                                      // ステータス値
                        MessageBoxButtons.YesNo);               // 表示するボタン
                    switch (res)
                    {
                        case DialogResult.Yes:
                            {
                                // 画面再描画
                                this._thirdDataIndex = i;
                                ScreenClear();
                                ScreenReconstruction();
                                break;
                            }
                        case DialogResult.No:
                            {
                                // UOEガイドコードのクリア
                                UOEGuideCode_tEdit.Clear();
                                break;
                            }
                    }
                    return true;
                }
            }
            return false;
        }
        // 2009.03.31 30413 犬飼 新規モードからモード変更対応 <<<<<<END
    }
}

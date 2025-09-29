//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 車種名称マスタ
// プログラム概要   : 車種名称マスタの登録・変更・削除を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2007 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 犬飼
// 作 成 日  2008/06/12  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 行澤 仁美
// 修 正 日  2008/10/07  修正内容 : バグ修正
//----------------------------------------------------------------------------//
// 管理番号  12693       作成担当 : 工藤　恵優
// 修 正 日  2009/03/24  修正内容 : 「削除済データの表示」は最上位項目で制御
//----------------------------------------------------------------------------//
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 肖緒徳
// 修 正 日  2010/04/26  修正内容 : 自由検索型式マスタメンテナンスからの変更
//----------------------------------------------------------------------------//
#define DELETE_DATE_DEPEND_ON_SUB_TABLE // メインテーブルの削除日をサブテーブルに関連させるフラグ

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
    /// 車種名称マスタ フォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note		: 車種名称マスタ情報の設定を行います。
    ///					  IMasterMaintenanceArrayTypeを実装しています。</br>
    /// <br>Programmer	: 30413 犬飼</br>
    /// <br>Date		: 2008.06.12</br>
    /// <br>UpdateNote   : 2008/10/07 30462 行澤 仁美　バグ修正</br>
    /// <br>UpdateNote   : 2009/03/24 30434 工藤 恵優　バグ修正</br>
    /// <br>UpdateNote   : 2010/04/26 肖緒徳　自由検索型式マスタから</br>
    /// </remarks>
    public class PMKHN09030UA : System.Windows.Forms.Form, IMasterMaintenanceArrayType
    {
        # region ※Private Members (Component)

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
            this.MakerCode_Label.Text = "メーカー";
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
            this.ModelCode_Label.Text = "車種コード";
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
            this.ModelSubCode_Label.Text = "呼称コード";
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
            this.ModelFullName_Label.Text = "車種名";
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
            this.ModelHalfName_Label.Text = "車種名(ｶﾅ)";
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
            this.ModelAliasName_Label.Text = "呼称";
            // 
            // Cancel_Button
            // 
            this.Cancel_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Cancel_Button.Location = new System.Drawing.Point(468, 254);
            this.Cancel_Button.Name = "Cancel_Button";
            this.Cancel_Button.Size = new System.Drawing.Size(125, 34);
            this.Cancel_Button.TabIndex = 11;
            this.Cancel_Button.Text = "閉じる(&X)";
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
            this.Revive_Button.Text = "復活(&R)";
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
            this.Delete_Button.Text = "完全削除(&D)";
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
            this.Ok_Button.Text = "保存(&S)";
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
            this.uButton_ModelGuide.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
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
            this.WarnMsg_Label.Text = "※新規は車種コード/呼称コードの何れかを900以上で登録して下さい";
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
            this.Mode_Label.Text = "更新モード";
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
            this.uButton_CmpltGoodsMakerGuide.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
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
            this.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PMKHN09030UA";
            this.Text = "車種マスタ";
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

        #region ※Private Members
        private MakerAcs _makerAcs;
        private ModelNameUAcs _modelNameUAcs;
        
        private ModelNameU _modelNameU;
        private ModelNameU _modelNameUClone;
        
        private int _totalCount;
        private string _enterpriseCode;
        private Hashtable _makerUTable;
        private Hashtable _modelNameUTable;
        private Hashtable _modelNameUCloneTable;

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

        // FreamのView用Grid列のKEY情報 (ヘッダのタイトル部となります)
        private const string I_MAKERCODE = "メーカー";
        private const string I_MAKERNAME = "メーカー名";
        private const string I_MAKERUMNT_GUID = "MAKERUMNT_GUID";
        private const string I_MAKERUMNT_TABLE = "MAKERUMNT_TABLE";

        private const string S_DELETEDATE = "削除日";
        private const string S_MAKERCODE = "設定メーカーコード";
        private const string S_MODELCODE = "車種コード";
        private const string S_MODELNAME = "車種名";
        private const string S_MODELSUBCODE = "呼称コード";
        private const string S_MODELALIASNAME = "呼称";
        private const string S_MODELNAMEU_GUID = "MODELNAMEU_GUID";
        private const string S_MODELNAMEU_TABLE = "MODELNAMEU_TABLE";

        //データ区分
        private const int DIVISION_USR = 0;
        private const int DIVISION_OFR = 1;	

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
        private const string PG_ID = "PMKHN09030U";
        private const string PG_NAME = "車種マスタ";

        // Message関連定義
        private const string ERR_READ_MSG = "読み込みに失敗しました。";
        private const string ERR_DPR_MSG = "このコードは既に使用されています。";
        private const string ERR_RDEL_MSG = "削除に失敗しました。";
        private const string ERR_UPDT_MSG = "登録に失敗しました。";
        private const string ERR_RVV_MSG = "復活に失敗しました。";
        private const string ERR_800_MSG = "既に他端末より更新されています";
        private const string ERR_801_MSG = "既に他端末より削除されています";
        private const string SDC_RDEL_MSG = "マスタから削除されています";

        // ADD 2010.04.26 xaoxd　>>>>>>>>>>>>>>>>
        // 自由検索マスタメンテナンスからフラグ
        private bool flag = false;

        // マスメンの車種コードをメーカー、車種コード、呼称コード
        private string maker;
        private string modelCode;
        private string modelSubCode;
        // ADD 2010.04.26 xaoxd　<<<<<<<<<<<<<<<<
        # endregion

        # region ※Constructor
		/// <summary>
        /// 車種名称マスタ フォームクラスコンストラクタ
		/// </summary>
		/// <remarks>
        /// <br>Note       : 車種名称マスタ フォームクラスの新しいインスタンスを初期化します。</br>
		/// <br>Programmer : 30413 犬飼</br>
		/// <br>Date       : 2008.06.12</br>
		/// </remarks>
        public PMKHN09030UA()
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
            this._mainGridTitle = "メーカー";
            this._detailsGridTitle = "車種";
            this._defaultGridDisplayLayout = MGridDisplayLayout.Vertical;
            this._mainDataIndex = -1;
            this._detailsDataIndex = -1;
            this._targetTableName = "";
            this._mainGridIcon = null;
            this._detailsGridIcon = null;

            // ガイドボタンの画像イメージ追加
            this.uButton_ModelGuide.Appearance.Image
                = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];

            this.uButton_CmpltGoodsMakerGuide.Appearance.Image
                = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];

            //　企業コードを取得する
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            
            // 変数初期化
            this._makerAcs = new MakerAcs();
            this._modelNameUAcs = new ModelNameUAcs();

            this._modelNameU = new ModelNameU();
            this._modelNameUClone = new ModelNameU();

            this._totalCount = 0;
            this._makerUTable = new Hashtable();
            this._modelNameUTable = new Hashtable();
            this._modelNameUCloneTable = new Hashtable();
            
            // GridのIndexBuffer格納用変数初期化
            this._mainIndexBuffer = -2;
            this._detailsIndexBuffer = -2;
            this._targetTableBuffer = "";
            
		}

        // ADD 2010.04.26 xiaoxd >>>>>>>>>>>>
        /// <summary>
        /// 車種名称マスタ フォームクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 車種名称マスタ フォームクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.12</br>
        /// </remarks>
        public PMKHN09030UA(string maker, string modelCode, string modelSubCode, bool flg)
        {
            InitializeComponent();

            this.flag = flg; //true:他の画面から、false:自身

            this.maker = maker;
            this.modelCode = modelCode;
            this.modelSubCode = modelSubCode;

            // ガイドボタンの画像イメージ追加
            this.uButton_ModelGuide.Appearance.Image
                = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];

            this.uButton_CmpltGoodsMakerGuide.Appearance.Image
                = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];

            //　企業コードを取得する
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            this.MakerCode_tNedit.ReadOnly = false;
            this.MakerCode_tNedit.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.uButton_CmpltGoodsMakerGuide.Enabled = true;

            // 変数初期化
            this._makerAcs = new MakerAcs();
            this._modelNameUAcs = new ModelNameUAcs();

            this._modelNameU = new ModelNameU();
            this._modelNameUClone = new ModelNameU();

            this._targetTableName = S_MODELNAMEU_TABLE;

            // GridのIndexBuffer格納用変数初期化
            this._mainDataIndex = -2;
            this._detailsDataIndex = -2;
     
        }
        // ADD 2010.04.26 xiaoxd <<<<<<<<<<
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
            System.Windows.Forms.Application.Run(new PMKHN09030UA());
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
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.12</br>
        /// </remarks>
        public bool[] GetCanLogicalDeleteDataExtractionList()
        {
            bool[] blRet = new bool[2];
            blRet[0] = true;    // MOD 2008/03/24 不具合対応[12693]：「削除済データの表示」は最上位項目で制御 false→true
            blRet[1] = false;   // MOD 2008/03/24 不具合対応[12693]：「削除済データの表示」は最上位項目で制御 true→false
            return blRet;
        }

        /// <summary>
        /// グリッドタイトルリスト取得処理
        /// </summary>
        /// <returns>グリッドタイトルリスト</returns>
        /// <remarks>
        /// <br>Note       : グリッドのタイトルを配列で取得します。</br>
        /// <br>Programmer : 30413 犬飼</br>
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
        /// グリッドアイコンリスト取得処理
        /// </summary>
        /// <returns>グリッドアイコンリスト</returns>
        /// <remarks>
        /// <br>Note       : グリッドのアイコンを配列で取得します。</br>
        /// <br>Programmer : 30413 犬飼</br>
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
        /// グリッド列のサイズの自動調整のデフォルト値リスト取得処理
        /// </summary>
        /// <returns>グリッド列のサイズの自動調整のデフォルト値リスト</returns>
        /// <remarks>
        /// <br>Note       : グリッド列のサイズの自動調整チェックボックスのチェック有無のデフォルト値を配列で取得します。</br>
        /// <br>Programmer : 30413 犬飼</br>
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
        /// データテーブルの選択データインデックスリスト設定処理
        /// </summary>
        /// <param name="indexList">データテーブルの選択データインデックスリスト</param>
        /// <remarks>
        /// <br>Note       : データテーブルの選択データインデックスリストを設定します。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.12</br>
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
        /// <br>Programmer : 30413 犬飼</br>
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
        /// 修正ボタンの有効設定リスト取得処理
        /// </summary>
        /// <returns>修正ボタンの有効設定リスト</returns>
        /// <remarks>
        /// <br>Note       : 修正ボタンの有効設定リストを取得します。</br>
        /// <br>Programmer : 30413 犬飼</br>
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
        /// 削除ボタンの有効設定リスト取得処理
        /// </summary>
        /// <returns>削除ボタンの有効設定リスト</returns>
        /// <remarks>
        /// <br>Note       : 削除ボタンの有効設定リストを取得します。</br>
        /// <br>Programmer : 30413 犬飼</br>
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
        /// バインドデータセット取得処理
        /// </summary>
        /// <param name="bindDataSet">グリッド表示用データセット</param>
        /// <param name="tableName">テーブル名称</param>
        /// <remarks>
        /// <br>Note       : グリッドにバインドさせるデータセットを取得します。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.12</br>
        /// </remarks>
        /// 
        public void GetBindDataSet(ref DataSet bindDataSet, ref string[] tableName)
        {
            // グリッド表示用データセットを設定
            bindDataSet = this.Bind_DataSet;

            // ２つのテーブル名称の設定
            string[] strRet = new string[2];
            strRet[0] = I_MAKERUMNT_TABLE;
            strRet[1] = S_MODELNAMEU_TABLE;
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
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.12</br>
        /// </remarks>
        public int Search(ref int totalCount, int readCount)
        {
            int status = 0;
            ArrayList makerUMntretList = null;

            if (readCount == 0)
            {
                // 抽出対象件数が0の場合は全件抽出を実行する
                status = this._makerAcs.SearchAll(out makerUMntretList, this._enterpriseCode);

                this._totalCount = makerUMntretList.Count;
            }

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        // 取得したメーカークラスをデータセットへ展開する
                        int index = 0;
                        foreach (MakerUMnt makerUMnt in makerUMntretList)
                        {
                            // 2008.12.05 30413 犬飼 ﾒｰｶｰｺｰﾄﾞが4桁は部品メーカーなので出力しない
                            //if (makerUMnt.LogicalDeleteCode == 0)
                            if ((makerUMnt.LogicalDeleteCode == 0) && (makerUMnt.GoodsMakerCd < 1000))
                            {
                                // メーカークラスデータセット展開処理
                                MakerUMntToDataSet(makerUMnt.Clone(), index);
                                ++index;
                            }
                        }

                        break;
                    }
                default:
                    {
                        // サーチ結果 メーカーマスタ読み込み失敗
                        TMsgDisp.Show(
                            this, 									    // 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_STOP, 			    // エラーレベル
                            PG_ID,      							    // アセンブリＩＤまたはクラスＩＤ
                            PG_NAME,	        					    // プログラム名称
                            "Search", 								    // 処理名称
                            TMsgDisp.OPE_GET, 						    // オペレーション
                            "メーカー情報の読み込みに失敗しました。", 	// 表示するメッセージ
                            status, 								    // ステータス値
                            this._modelNameUAcs,	 				    // エラーが発生したオブジェクト
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
        /// ネクストデータ検索処理
        /// </summary>
        /// <param name="readCount">抽出対象件数</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 指定した件数分のネクストデータを検索します。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.12</br>
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
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.12</br>
        /// </remarks>
        public int DetailsDataSearch(ref int totalCount, int readCount)
        {
            int status = 0;
            ArrayList arrModelNameU = new ArrayList();

            // 現在保持している車種名称データをクリアする
            this.Bind_DataSet.Tables[S_MODELNAMEU_TABLE].Rows.Clear();
            this._modelNameUTable.Clear();

            // ADD 2009/03/24 不具合対応[12693]：「削除済データの表示」は最上位項目で制御 ---------->>>>>
            // readCountが負の場合、強制終了
            if (readCount < 0) return 0;
            // ADD 2009/03/24 不具合対応[12693]：「削除済データの表示」は最上位項目で制御 ----------<<<<<

            // 選択されているメーカーデータを取得する
            string guid = (string)this.Bind_DataSet.Tables[I_MAKERUMNT_TABLE].Rows[this._mainDataIndex][I_MAKERUMNT_GUID];
            MakerUMnt makerUMnt = (MakerUMnt)this._makerUTable[guid];

            // メーカーコード指定 車種名称検索処理（論理削除含む）
            status = this._modelNameUAcs.SearchAll(makerUMnt.GoodsMakerCd, out arrModelNameU, this._enterpriseCode);

            // 車種名称のレコードを保持
            CacheModelNameUList(makerUMnt.GoodsMakerCd, arrModelNameU); // ADD 2009/03/24 不具合対応[12693]：「削除済データの表示」は最上位項目で制御

            this._totalCount = arrModelNameU.Count;

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                    {
                        // 取得した車種名称クラスをデータセットへ展開する
                        int index = 0;
                        foreach (ModelNameU modelNameU in arrModelNameU)
                        {
                            // 車種名称クラスデータセット展開処理
                            ModelNameUToDataSet(modelNameU.Clone(), index);
                            ++index;
                        }

                        // ソート
                        //this.Bind_DataSet.Tables[S_MODELNAMEU_TABLE].DefaultView.Sort = S_MODELCODE + ", " + S_MODELSUBCODE + " ASC";
                        
                        break;
                    }
                default:
                    {
                        // 明細データ検索処理
                        TMsgDisp.Show(
                            this, 								        // 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_STOP, 		        // エラーレベル
                            PG_ID, 						                // アセンブリＩＤまたはクラスＩＤ
                            PG_NAME,        					        // プログラム名称
                            "DetailsDataSearch", 				        // 処理名称
                            TMsgDisp.OPE_GET, 					        // オペレーション
                            "車種名称情報の読み込みに失敗しました。",	// 表示するメッセージ
                            status, 							        // ステータス値
                            this._modelNameUAcs, 				        // エラーが発生したオブジェクト
                            MessageBoxButtons.OK, 				        // 表示するボタン
                            MessageBoxDefaultButton.Button1);	        // 初期表示ボタン
                        
                        break;
                    }
            }

            totalCount = this._totalCount;

            // メインテーブルの削除日をサブテーブルから設定
            SetDelateDateOfMainTable(); // ADD 2009/03/24 不具合対応[12693]：「削除済データの表示」は最上位項目で制御

            return status;
        }

        /// <summary>
        /// 明細ネクストデータ検索処理
        /// </summary>
        /// <param name="readCount">抽出対象件数</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 指定した件数分のネクストデータを検索します。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.12</br>
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
        /// <br>Programmer : 30413 犬飼</br>
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
                    "このレコードは提供データのため削除できません",
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
                        // 排他処理
                        ExclusiveTransaction(status, TMsgDisp.OPE_DELETE, this._modelNameUAcs);
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
                            this._modelNameUAcs,				// エラーが発生したオブジェクト
                            MessageBoxButtons.OK,				// 表示するボタン
                            MessageBoxDefaultButton.Button1);	// 初期表示ボタン

                        return status;
                    }
            }

            // データセット展開処理
            ModelNameUToDataSet(modelNameU.Clone(), this._detailsDataIndex);
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
        /// <br>Date       : 2008.06.12</br>
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
        /// <br>Date       : 2008.06.12</br>
        /// </remarks>
        public void GetAppearanceTable(out Hashtable[] appearanceTable)
        {
            // メイングリッド
            Hashtable mainAppearanceTable = new Hashtable();

            // 削除日
            // ADD 2008/03/24 不具合対応[12693]↓：「削除済データの表示」は最上位項目で制御
            mainAppearanceTable.Add(S_DELETEDATE, new GridColAppearance(MGridColDispType.DeletionDataBoth, ContentAlignment.MiddleLeft, "", Color.Red));
            // メーカーコード
            mainAppearanceTable.Add(I_MAKERCODE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            // メーカー名
            mainAppearanceTable.Add(I_MAKERNAME, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // メーカー情報GUID
            mainAppearanceTable.Add(I_MAKERUMNT_GUID, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));


            // サブグリッド
            Hashtable detailsAppearanceTable = new Hashtable();

            // 削除日
            detailsAppearanceTable.Add(S_DELETEDATE, new GridColAppearance(MGridColDispType.DeletionDataBoth, ContentAlignment.MiddleLeft, "", Color.Red));
            // 設定メーカーコード
            detailsAppearanceTable.Add(S_MAKERCODE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            // 車種コード
            detailsAppearanceTable.Add(S_MODELCODE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            // 車種名
            detailsAppearanceTable.Add(S_MODELNAME, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // 呼称コード
            detailsAppearanceTable.Add(S_MODELSUBCODE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            // 呼称
            detailsAppearanceTable.Add(S_MODELALIASNAME, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // 車種情報GUID
            detailsAppearanceTable.Add(S_MODELNAMEU_GUID, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));

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
        /// <br>Note　　　  : ユーザーがフォームを読み込むときに発生します。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.12</br>
        /// </remarks>
        private void PMKHN09030UA_Load(object sender, System.EventArgs e)
        {
            // アイコンリソース管理クラスを使用して、アイコンを表示する
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
        /// <br>Date       : 2008.06.12</br>
        /// </remarks>
        private void PMKHN09030UA_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // GridのIndexBuffer格納用変数初期化
            this._mainIndexBuffer = -2;
            this._detailsIndexBuffer = -2;
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
        /// <br>Date       : 2008.06.12</br>
        /// </remarks>
        private void PMKHN09030UA_VisibleChanged(object sender, System.EventArgs e)
        {
            if (!this.flag) // ADD 2010.04.26 xiaoxd
            {
                // 自分自身が非表示になった場合は以下の処理をキャンセルする。
                if (this.Visible == false)
                {
                    // メインフレームアクティブ化
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
        /// <br>Note　　　  : 保存ボタンコントロールがクリックされた時に発生します。</br>
        /// <br>Programmer : 30413 犬飼</br>
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

            // 画面非表示イベント
            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                UnDisplaying(this, me);
            }

            // ADD 2008/10/07 不具合対応[6320] ---------->>>>>
            // 新規モードの場合は画面を終了させずに連続入力を可能とする。
            if (this.Mode_Label.Text == INSERT_MODE)
            {
                // 画面を初期化
                this.ScreenClear();

                // 画面を再構築
                this.ScreenReconstruction();
                
            }
            else
            {
            // ADD 2008/10/07 不具合対応[6320] ----------<<<<<
                this.DialogResult = DialogResult.OK;

                // GridのIndexBuffer格納用変数初期化
                this._mainIndexBuffer = -2;
                this._detailsIndexBuffer = -2;
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
            // ADD 2008/10/07 不具合対応[6320] ---------->>>>>
            }
            // ADD 2008/10/07 不具合対応[6320] ----------<<<<<
        }

        /// <summary>
        /// 閉じるボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントデータ</param>
        /// <remarks>
        /// <br>Note　　　  : 閉じるボタンコントロールがクリックされた時に発生します。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.12</br>
        /// </remarks>
        private void Cancel_Button_Click(object sender, System.EventArgs e)
        {
            // 更新有無フラグ
            //bool isUpdate = false;

            //保存確認
            ModelNameU compareModelNameU = new ModelNameU();
            compareModelNameU = this._modelNameUClone.Clone();
            //現在の画面情報を取得する
            DispToModelNameU(ref compareModelNameU);

            //最初に取得した画面情報と比較
            if (!(this._modelNameUClone.Equals(compareModelNameU)))
            {
                // 画面情報が変更されていた場合は、保存確認メッセージを表示する
                // 保存確認
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
            this._detailsIndexBuffer = -2;
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
        /// <br>Date       : 2008.06.13</br>
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
                                this,								  // 親ウィンドウフォーム
                                emErrorLevel.ERR_LEVEL_STOPDISP,	  // エラーレベル
                                PG_ID,      						  // アセンブリＩＤまたはクラスＩＤ
                                PG_NAME,							  // プログラム名称
                                "Delete_Button_Click",				  // 処理名称
                                TMsgDisp.OPE_DELETE,				  // オペレーション
                                ERR_RDEL_MSG,						  // 表示するメッセージ 
                                status,								  // ステータス値
                                this._modelNameUAcs,					  // エラーが発生したオブジェクト
                                MessageBoxButtons.OK,				  // 表示するボタン
                                MessageBoxDefaultButton.Button1);	  // 初期表示ボタン

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
        /// Control.Click イベント(Revive_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note 　　  : 復活ボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programmer : 30413 犬飼</br>
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
                            this,								  // 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_STOPDISP,	  // エラーレベル
                            PG_ID,		        				  // アセンブリＩＤまたはクラスＩＤ
                            PG_NAME,							  // プログラム名称
                            "Revive_Button_Click",				  // 処理名称
                            TMsgDisp.OPE_UPDATE,				  // オペレーション
                            ERR_RVV_MSG,						  // 表示するメッセージ 
                            status,								  // ステータス値
                            this._modelNameUAcs,					  // エラーが発生したオブジェクト
                            MessageBoxButtons.OK,				  // 表示するボタン
                            MessageBoxDefaultButton.Button1);	  // 初期表示ボタン

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

            // DataSet展開処理
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
        /// 車種名称ガイドボタン押下イベント
        /// </summary>
        /// <param name="sender">コントロール</param>
        /// <param name="e">イベントデータ</param>
        /// <remarks>
        /// <br>Note       : 車種名称ガイドボタン押下時の処理を行います。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.13</br>
        /// </remarks>
        private void uButton_ModelGuide_Click(object sender, EventArgs e)
        {
            ModelNameU modelNameU = null;
            string message;
            int status = this.ShowModelNameGuide(out modelNameU);

            if (status == 0)
            {
                // 選択した情報を取得
                this.ModelCode_tNedit.SetInt(modelNameU.ModelCode);
                this.ModelSubCodea_tNedit.SetInt(modelNameU.ModelSubCode);
                this.ModelFullName_tEdit.Text = modelNameU.ModelFullName;
                this.ModelHalfName_tEdit.Text = modelNameU.ModelHalfName;
                this.ModelAliasName_tEdit.Text = modelNameU.ModelAliasName;

                // 次のコントロールへフォーカスを移動
                this.SelectNextControl((Control)sender, true, true, true, true);
            }

            else if (status == -1)
            {
                // メーカーコードが未入力
                //message = this.ModelCode_Label.Text + "を入力して下さい。"; // DEL 2010.04.26 xiaoxd
                message = this.MakerCode_Label.Text + "を入力して下さい。"; // ADD 2010.04.26 xiaoxd
                TMsgDisp.Show(
                    this,								// 親ウィンドウフォーム
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,	// エラーレベル
                    PG_ID,      						// アセンブリＩＤまたはクラスＩＤ
                    message,							// 表示するメッセージ 
                    0,									// ステータス値
                    MessageBoxButtons.OK);				// 表示するボタン

                MakerCode_tNedit.Focus();
            }
            else
            {
                ((Control)sender).Focus();
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
        /// <br>Date       : 2008.06.12</br>
        /// </remarks>
        private void Initial_Timer_Tick(object sender, System.EventArgs e)
        {
            Initial_Timer.Enabled = false;

            // 画面再構築処理
            ScreenReconstruction();
        }

        /// <summary>
        /// リターンキー移動イベント
        /// </summary>
        /// <remarks>
        /// <br>Note       : リターンキー押下時の制御を行います。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.16</br>
        /// </remarks>
        private void tRetKeyControl1_ChangeFocus(object sender, Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null || e.NextCtrl == null) return;

            // 2009.03.30 30413 犬飼 削除 >>>>>>START
            //bool canChangeFocus = true;

            //object inParamObj = null;
            //object outParamObj = null;
            //ArrayList inParamList = new ArrayList();

            //switch (e.PrevCtrl.Name)
            //{
            //    // 車種コード
            //    case "ModelCode_tNedit":
            //        {
            //            // 条件設定クリア
            //            inParamObj = null;
            //            outParamObj = null;

            //            // 条件設定
            //            inParamObj = this.ModelCode_tNedit.GetInt();

            //            // 車種名取得
            //            outParamObj = this.GetModelName((int)inParamObj);

            //            // 車種名の存在チェック
            //            if (outParamObj.Equals(""))
            //            {
            //                //this.ModelCode_tNedit.Clear();
            //                //this.ModelFullName_tEdit.Clear();
            //            }
            //            else
            //            {
            //                // 車種名設定
            //                this.ModelFullName_tEdit.Text = (string)outParamObj;
            //            }
            //            break;
            //        }
            //}

            //// フォーカス制御
            //if (canChangeFocus == false)
            //{
            //    e.NextCtrl = e.PrevCtrl;

            //    // 現在の項目から移動せず、テキスト全選択状態とする
            //    e.NextCtrl.Select();
            //}
            // 2009.03.30 30413 犬飼 削除 <<<<<<END
            
            // 2009.03.30 30413 犬飼 新規モードからモード変更対応 >>>>>>START
            switch (e.NextCtrl.Name)
            {
                case "ModelFullName_tEdit":     // 車種名
                case "ModelHalfName_tEdit":     // 車種名(カナ)
                case "ModelAliasName_tEdit":    // 呼称
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
            // 2009.03.30 30413 犬飼 新規モードからモード変更対応 <<<<<<END
        }

        /// <summary>
        /// ModelCode_tNedit_Leave イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : フォーカスを失ったときに発生</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.16</br>
        /// </remarks>
        private void ModelCode_tNedit_Leave(object sender, EventArgs e)
        {
            // メーカーコードが空白ならば何もしない
            if (this.ModelCode_tNedit.Text == "")
            {
                this.ModelCode_tNedit.Clear();
                //this.MakerCodeNm_tEdit.Clear();
            }
        }

        /// <summary>
        /// ModelCode_tNedit_BeforeEnterEditMode
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : コントロールが編集モードに入る前に発生します。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.16</br>
        /// </remarks>
        private void ModelCode_tNedit_BeforeEnterEditMode(object sender, CancelEventArgs e)
        {
            // ChangeFocusイベント一時停止
            this.tArrowKeyControl1.ChangeFocus -= this.tRetKeyControl1_ChangeFocus;

            // 先頭のゼロ詰めを削除
            //this.ModelCode_tNedit.Text = GetZeroPadCanceledTextProc(this.ModelCode_tNedit.Text);

            // ChangeFocusイベント再開
            this.tArrowKeyControl1.ChangeFocus += new ChangeFocusEventHandler(tRetKeyControl1_ChangeFocus);
        }

        /// <summary>
        /// ModelFullName_tEdit_ValueChanged
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : 車種名の値が変更されると発生します。</br>
        /// <br>Programmer : 30413 犬飼</br>
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
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : 車種名(カナ)の値が変更されると発生します。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.09.16</br>
        /// </remarks>
        private void ModelHalfName_tEdit_ValueChanged(object sender, EventArgs e)
        {
            TEdit tEdit = sender as TEdit;
            // 全角カナを半角ｶﾅに強制変換
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
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : 呼称の値が変更されると発生します。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.09.16</br>
        /// </remarks>
        private void ModelAliasName_tEdit_ValueChanged(object sender, EventArgs e)
        {
            TEdit tEdit = sender as TEdit;
            // 全角カナを半角ｶﾅに強制変換
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
        /// メーカークラスデータセット展開処理
        /// </summary>
        /// <param name="makerUMnt">メーカークラス</param>
        /// <param name="index">データセットへ展開するインデックス</param>
        /// <remarks>
        /// <br>Note       : メーカークラスをデータセットへ格納します。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.12</br>
        /// </remarks>
        private void MakerUMntToDataSet(MakerUMnt makerUMnt, int index)
        {
            if ((index < 0) || (this.Bind_DataSet.Tables[I_MAKERUMNT_TABLE].Rows.Count <= index))
            {
                // 新規と判断して、行を追加する
                DataRow dataRow = this.Bind_DataSet.Tables[I_MAKERUMNT_TABLE].NewRow();
                this.Bind_DataSet.Tables[I_MAKERUMNT_TABLE].Rows.Add(dataRow);

                // indexを行の最終行番号にする
                index = this.Bind_DataSet.Tables[I_MAKERUMNT_TABLE].Rows.Count - 1;
            }

            // 削除日
            // ADD 2008/03/24 不具合対応[12693]↓：「削除済データの表示」は最上位項目で制御
            this.Bind_DataSet.Tables[I_MAKERUMNT_TABLE].Rows[index][S_DELETEDATE] = GetDeleteDate(makerUMnt);

            // メーカーコード
            // 2008.09.26 30413 犬飼 ゼロ詰め対応 >>>>>>START
            //this.Bind_DataSet.Tables[I_MAKERUMNT_TABLE].Rows[index][I_MAKERCODE] = makerUMnt.GoodsMakerCd;
            this.Bind_DataSet.Tables[I_MAKERUMNT_TABLE].Rows[index][I_MAKERCODE] = makerUMnt.GoodsMakerCd.ToString("d04");
            // 2008.09.26 30413 犬飼 ゼロ詰め対応 <<<<<<END
            
            // メーカー名
            this.Bind_DataSet.Tables[I_MAKERUMNT_TABLE].Rows[index][I_MAKERNAME] = makerUMnt.MakerName;

            // メーカー情報GUID
            this.Bind_DataSet.Tables[I_MAKERUMNT_TABLE].Rows[index][I_MAKERUMNT_GUID] = CreateHashKey(makerUMnt);
            
            // ハッシュ検索用にGUIDセット
            this._makerUTable.Add(CreateHashKey(makerUMnt), makerUMnt);
            if (this._makerUTable.ContainsKey(CreateHashKey(makerUMnt)) == true)
            {
                this._makerUTable.Remove(CreateHashKey(makerUMnt));
            }
            this._makerUTable.Add(CreateHashKey(makerUMnt), makerUMnt);
        }

        // ADD 2009/03/24 不具合対応[12693]：「削除済データの表示」は最上位項目で制御 ---------->>>>>
        /// <summary>
        /// メインテーブルの削除日を取得します。
        /// </summary>
        /// <param name="makerUMnt">メーカークラス</param>
        /// <returns>メインテーブルの削除日（削除されていない場合、<c>string.Empty</c>を返します。）</returns>
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

        #region <車種名称のキャッシュ/>

        /// <summary>車種名称のキャッシュ</summary>
        /// <remarks>キー：メーカーコード</remarks>
        private readonly IDictionary<int, ArrayList> _modelNameUListCacheMap = new Dictionary<int, ArrayList>();
        /// <summary>
        /// 車種名称のキャッシュを取得します。
        /// </summary>
        private IDictionary<int, ArrayList> ModelNameUListCacheMap
        {
            get { return _modelNameUListCacheMap; }
        }

        /// <summary>
        /// 車種名称をキャッシュします。
        /// </summary>
        /// <param name="makerCode">メーカーコード</param>
        /// <param name="modelNameUList">車種名称のレコードリスト</param>
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

        #endregion  // <車種名称のキャッシュ/>

        /// <summary>
        /// メインテーブルの削除日を設定します。
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
                // 対応するサブテーブルのレコードを抽出
                string strRelationColumn = mainRow[I_MAKERCODE].ToString();
                int relationColumn = (string.IsNullOrEmpty(strRelationColumn) ? 0 : int.Parse(strRelationColumn));
                DataRow[] foundSubRows = this.Bind_DataSet.Tables[SUB_TABLE_NAME].Select(
                    RELATION_COLUMN_NAME + "=" + relationColumn.ToString()
                );
                Debug.WriteLine("関連 = " + relationColumn.ToString() + ":" + foundSubRows.Length.ToString() + "件");

                if (foundSubRows.Length.Equals(0))
                {
                    #region サブテーブルに該当レコードが無い場合、DB検索結果（キャッシュ）より設定

                    // メーカーコード指定 車種名称検索処理（論理削除含む）
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

                    // 削除日を降順で抽出
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

                    // レコードが全件削除されている場合
                    string deleteDate = string.Empty;
                    if (deleteRowCount > 0 && deleteRowCount.Equals(modelNameUList.Count))
                    {
                        deleteDate = sortedDeleteDateList.Values[0];
                    }
                    mainRow[DELETE_DATE_COLUMN_NAME] = deleteDate;

                    #endregion  // サブテーブルに該当レコードが無い場合、DB検索結果（キャッシュ）より設定
                }
                else
                {
                    #region サブテーブルに該当レコードがある場合、サブテーブルより設定

                    // 削除日を降順で抽出
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
        // ADD 2009/03/24 不具合対応[12693]：「削除済データの表示」は最上位項目で制御 ----------<<<<<

        /// <summary>
        /// 車種名称クラスデータセット展開処理
        /// </summary>
        /// <param name="modelNameU">車種名称クラス</param>
        /// <param name="index">データセットへ展開するインデックス</param>
        /// <remarks>
        /// <br>Note       : 拠点制御クラスをデータセットへ格納します。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.13</br>
        /// </remarks>
        private void ModelNameUToDataSet(ModelNameU modelNameU, int index)
        {
            if ((index < 0) || (this.Bind_DataSet.Tables[S_MODELNAMEU_TABLE].Rows.Count <= index))
            {
                // 新規と判断して、行を追加する
                DataRow dataRow = this.Bind_DataSet.Tables[S_MODELNAMEU_TABLE].NewRow();
                this.Bind_DataSet.Tables[S_MODELNAMEU_TABLE].Rows.Add(dataRow);

                // indexを行の最終行番号する
                index = this.Bind_DataSet.Tables[S_MODELNAMEU_TABLE].Rows.Count - 1;
            }

            // 削除日
            if (modelNameU.LogicalDeleteCode == 0)
            {
                this.Bind_DataSet.Tables[S_MODELNAMEU_TABLE].Rows[index][S_DELETEDATE] = "";
            }
            else
            {
                this.Bind_DataSet.Tables[S_MODELNAMEU_TABLE].Rows[index][S_DELETEDATE] = TDateTime.DateTimeToString("ggYY/MM/DD", modelNameU.UpdateDateTime);
            }

            // 設定メーカーコード
            this.Bind_DataSet.Tables[S_MODELNAMEU_TABLE].Rows[index][S_MAKERCODE] = modelNameU.MakerCode;

            // 2008.09.26 30413 犬飼 ゼロ詰め対応 >>>>>>START
            // 車種コード
            //this.Bind_DataSet.Tables[S_MODELNAMEU_TABLE].Rows[index][S_MODELCODE] = modelNameU.ModelCode;
            this.Bind_DataSet.Tables[S_MODELNAMEU_TABLE].Rows[index][S_MODELCODE] = modelNameU.ModelCode.ToString("d03");

            // 呼称コード
            //this.Bind_DataSet.Tables[S_MODELNAMEU_TABLE].Rows[index][S_MODELSUBCODE] = modelNameU.ModelSubCode;
            this.Bind_DataSet.Tables[S_MODELNAMEU_TABLE].Rows[index][S_MODELSUBCODE] = modelNameU.ModelSubCode.ToString("d03");
            // 2008.09.26 30413 犬飼 ゼロ詰め対応 <<<<<<END
            
            // 車種名
            this.Bind_DataSet.Tables[S_MODELNAMEU_TABLE].Rows[index][S_MODELNAME] = modelNameU.ModelFullName;

            // 呼称
            this.Bind_DataSet.Tables[S_MODELNAMEU_TABLE].Rows[index][S_MODELALIASNAME] = modelNameU.ModelAliasName;

            // 車種名称情報GUID
            this.Bind_DataSet.Tables[S_MODELNAMEU_TABLE].Rows[index][S_MODELNAMEU_GUID] = CreateHashKey(modelNameU);

            // ハッシュ検索用にGUIDセット
            if (this._modelNameUTable.ContainsKey(CreateHashKey(modelNameU)) == true)
            {
                this._modelNameUTable.Remove(CreateHashKey(modelNameU));
            }
            this._modelNameUTable.Add(CreateHashKey(modelNameU), modelNameU);
        }

        /// <summary>
        /// 車種名称マスタ クラス画面展開処理
        /// </summary>
        /// <param name="modelNameU">車種名称マスタ オブジェクト</param>
        /// <remarks>
        /// <br>Note       : 車種名称マスタ オブジェクトから画面にデータを展開します。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.13</br>
        /// </remarks>
        private void ModelNameUToScreen(ModelNameU modelNameU)
        {
            this.MakerCode_tNedit.SetInt(modelNameU.MakerCode);                     // メーカーコード
            this.MakerCodeNm_tEdit.Text = GetMakerName(modelNameU.MakerCode);       // メーカー名
            this.ModelCode_tNedit.SetInt(modelNameU.ModelCode);                     // 車種コード
            this.ModelSubCodea_tNedit.SetInt(modelNameU.ModelSubCode);               // 呼称コード
            this.ModelFullName_tEdit.Text = modelNameU.ModelFullName;               // 車種名
            this.ModelHalfName_tEdit.Text = modelNameU.ModelHalfName;               // 車種名(ｶﾅ)
            this.ModelAliasName_tEdit.Text = modelNameU.ModelAliasName;             // 呼称
        }

        /// <summary>
        /// 画面情報車種名称マスタ クラス格納処理
        /// </summary>
        /// <param name="modelNameU">車種名称マスタ オブジェクト</param>
        /// <remarks>
        /// <br>Note       : 画面情報から車種名称マスタ オブジェクトにデータを格納します。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.12</br>
        /// </remarks>
        private void DispToModelNameU(ref ModelNameU modelNameU)
        {
            if (modelNameU == null)
            {
                // 新規の場合
                modelNameU = new ModelNameU();
            }

            modelNameU.EnterpriseCode = this._enterpriseCode;                       // 企業コード

            modelNameU.MakerCode = this.MakerCode_tNedit.GetInt();                  // メーカーコード
            modelNameU.ModelCode = this.ModelCode_tNedit.GetInt();                  // 車種コード
            modelNameU.ModelSubCode = this.ModelSubCodea_tNedit.GetInt();            // 呼称コード
            modelNameU.ModelFullName = this.ModelFullName_tEdit.Text.TrimEnd();     // 車種名
            modelNameU.ModelHalfName = this.ModelHalfName_tEdit.Text.TrimEnd();     // 車種名(ｶﾅ)
            modelNameU.ModelAliasName = this.ModelAliasName_tEdit.Text.TrimEnd();   // 呼称
        }

        /// <summary>
        /// データセット列情報構築処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : DataSetの列情報を構築します。データセットの列情報がフレームのビュー用グリッドの列になります。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.12</br>
        /// </remarks>
        private void DataSetColumnConstruction()
        {
            // メインテーブルの列定義
            DataTable _makerUMntDt = new DataTable(I_MAKERUMNT_TABLE);

            // Addを行う順番が、列の表示順位となります。
            // ADD 2008/03/24 不具合対応[12693]↓：「削除済データの表示」は最上位項目で制御
            _makerUMntDt.Columns.Add(S_DELETEDATE, typeof(string));        // 削除日
            // 2008.09.26 30413 犬飼 ゼロ詰め対応 >>>>>>START
            //_makerUMntDt.Columns.Add(I_MAKERCODE, typeof(int));			    // メーカーコード
            _makerUMntDt.Columns.Add(I_MAKERCODE, typeof(string));			    // メーカーコード
            // 2008.09.26 30413 犬飼 ゼロ詰め対応 <<<<<<END
            _makerUMntDt.Columns.Add(I_MAKERNAME, typeof(string));			// メーカー名
            _makerUMntDt.Columns.Add(I_MAKERUMNT_GUID, typeof(string));     // メーカー情報GUID

            this.Bind_DataSet.Tables.Add(_makerUMntDt);

            // サブテーブルの列定義
            DataTable _modelNameUDt = new DataTable(S_MODELNAMEU_TABLE);

            // Addを行う順番が、列の表示順位となります。
            _modelNameUDt.Columns.Add(S_DELETEDATE, typeof(string));        // 削除日
            _modelNameUDt.Columns.Add(S_MAKERCODE, typeof(string));			// 設定メーカーコード
            // 2008.09.26 30413 犬飼 ゼロ詰め対応 >>>>>>START
            //_modelNameUDt.Columns.Add(S_MODELCODE, typeof(int));			// 車種コード
            _modelNameUDt.Columns.Add(S_MODELCODE, typeof(string));			// 車種コード
            // 2008.09.26 30413 犬飼 ゼロ詰め対応 <<<<<<END
            _modelNameUDt.Columns.Add(S_MODELNAME, typeof(string));			// 車種名
            _modelNameUDt.Columns.Add(S_MODELSUBCODE, typeof(string));	    // 呼称コード
            _modelNameUDt.Columns.Add(S_MODELALIASNAME, typeof(string));	// 呼称
            _modelNameUDt.Columns.Add(S_MODELNAMEU_GUID, typeof(string));   // 車種名称情報GUID

            this.Bind_DataSet.Tables.Add(_modelNameUDt);
        }

        /// <summary>
        /// 画面初期設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面の初期設定を行います。</br>
        /// <br>Programmer : 30413 犬飼</br>
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
        /// 画面再構築処理
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : モードに基づいて画面の再構築を行います。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.12</br>
        /// </remarks>
        private void ScreenReconstruction()
        {
            if (this._detailsDataIndex < 0)
            {
                if (!this.flag) // ADD 2010.04.26 xiaoxd
                {
                    // 新規モード
                    this.Mode_Label.Text = INSERT_MODE;

                    // 選択メーカーの情報を取得
                    string makerGuid = (string)this.Bind_DataSet.Tables[I_MAKERUMNT_TABLE].Rows[this._mainDataIndex][I_MAKERUMNT_GUID];
                    MakerUMnt makerUMnt = (MakerUMnt)this._makerUTable[makerGuid];
                    // 選択メーカー情報を画面に設定
                    this.MakerCode_tNedit.SetInt(makerUMnt.GoodsMakerCd);
                    this.MakerCodeNm_tEdit.Text = makerUMnt.MakerName;

                    // 画面入力許可制御処理
                    ScreenPermissionControl(INSERT_MODE);

                    // FreamのIndex/Tableバッファ保持
                    this._mainIndexBuffer = -2;
                    this._detailsIndexBuffer = this._detailsDataIndex;
                    this._targetTableBuffer = this._targetTableName;

                    //クローン作成
                    ModelNameU modelNameU = new ModelNameU();
                    this._modelNameUClone = modelNameU.Clone();
                    DispToModelNameU(ref this._modelNameUClone);

                    // フォーカス設定
                    this.ModelCode_tNedit.Focus();
                }
                else
                {
                    // 新規モード
                    this.Mode_Label.Text = INSERT_MODE;

                    ModelNameU modelNameU = new ModelNameU();

                    // メーカー
                    if (!String.IsNullOrEmpty(this.maker))
                    {
                        this.MakerCode_tNedit.SetInt(Convert.ToInt32(this.maker));
                        MakerAcs makerAcs = new MakerAcs();
                        MakerUMnt makerUMnt;
                        int makerCode = this.MakerCode_tNedit.GetInt();
                        //メーカーデータの取得
                        int status = makerAcs.Read(out makerUMnt, this._enterpriseCode, makerCode);
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            //メーカー
                            this.MakerCodeNm_tEdit.Text = makerUMnt.MakerName;
                        }

                    }
                    //車種コード
                    if (!String.IsNullOrEmpty(this.modelCode))
                    {
                        this.ModelCode_tNedit.SetInt(Convert.ToInt32(this.modelCode));
                    }

                    if (!String.IsNullOrEmpty(this.modelSubCode))
                    {
                        this.ModelSubCodea_tNedit.SetInt(Convert.ToInt32(this.modelSubCode));
                    }

                    // 画面入力許可制御処理
                    ScreenPermissionControl(INSERT_MODE);

                    // フォーカス設定
                    this.MakerCode_tNedit.Focus();
                }

            }
            else
            {
                // 選択車種名称の情報を取得
                string guid = (string)this.Bind_DataSet.Tables[S_MODELNAMEU_TABLE].Rows[this._detailsDataIndex][S_MODELNAMEU_GUID];
                ModelNameU modelNameU = (ModelNameU)this._modelNameUTable[guid];

                if (modelNameU.LogicalDeleteCode == 0)
                {
                    // 画面入力許可制御処理
                    if (modelNameU.Division == DIVISION_OFR)
                    {
                        // 参照モード
                        this.Mode_Label.Text = REFERENCE_MODE;

                        // 画面入力許可制御処理
                        ScreenPermissionControl(REFERENCE_MODE);
                        
                        // 画面展開処理
                        ModelNameUToScreen(modelNameU);

                        //クローン作成
                        this._modelNameUClone = modelNameU.Clone();
                        DispToModelNameU(ref this._modelNameUClone);

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
                        ModelNameUToScreen(modelNameU);

                        //クローン作成
                        this._modelNameUClone = modelNameU.Clone();
                        DispToModelNameU(ref this._modelNameUClone);
                        
                        // フォーカス設定
                        this.ModelCode_tNedit.Focus();
                        this.ModelCode_tNedit.SelectAll();
                    }
                }
                else
                {
                    // 削除モード
                    this.Mode_Label.Text = DELETE_MODE;

                    // 画面入力許可制御処理
                    ScreenPermissionControl(DELETE_MODE);

                    // 画面展開処理
                    ModelNameUToScreen(modelNameU);

                    //クローン作成
                    this._modelNameUClone = modelNameU.Clone();
                    DispToModelNameU(ref this._modelNameUClone);

                    // フォーカス設定
                    this.Delete_Button.Focus();
                }

                // FreamのIndex/Tableバッファ保持
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
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.13</br>
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
                this.uButton_CmpltGoodsMakerGuide.Visible = true; // ADD 2010.04.26 xiaoxd
                this.uButton_ModelGuide.Visible = true;
                this.uButton_ModelGuide.Enabled = true;

                // 入力設定
                this.MakerCode_tNedit.Enabled = true;
                this.ModelCode_tNedit.Enabled = true;
                this.ModelSubCodea_tNedit.Enabled = true;
                this.ModelFullName_tEdit.Enabled = true;
                this.ModelHalfName_tEdit.Enabled = true;
                this.ModelAliasName_tEdit.Enabled = true;
            }
            // 更新
            else if (screenMode.Equals(UPDATE_MODE))
            {
                // ボタン設定
                this.Ok_Button.Visible = true;
                this.Delete_Button.Visible = false;
                this.Revive_Button.Visible = false;
                this.uButton_CmpltGoodsMakerGuide.Visible = true; // ADD 2010.04.26 xiaoxd
                this.uButton_ModelGuide.Visible = true;
                this.uButton_ModelGuide.Enabled = false;

                // 入力設定
                this.MakerCode_tNedit.Enabled = false;
                this.ModelCode_tNedit.Enabled = false;
                this.ModelSubCodea_tNedit.Enabled = false;
                this.ModelFullName_tEdit.Enabled = true;
                this.ModelHalfName_tEdit.Enabled = true;
                this.ModelAliasName_tEdit.Enabled = true;
            }
            // 削除
            else if (screenMode.Equals(DELETE_MODE))
            {
                // ボタン設定
                this.Ok_Button.Visible = false;
                this.Delete_Button.Visible = true;
                this.Revive_Button.Visible = true;
                this.uButton_CmpltGoodsMakerGuide.Visible = true; // ADD 2010.04.26 xiaoxd
                this.uButton_ModelGuide.Visible = true;
                this.uButton_ModelGuide.Enabled = false;

                // 入力設定
                this.MakerCode_tNedit.Enabled = false;
                this.ModelCode_tNedit.Enabled = false;
                this.ModelSubCodea_tNedit.Enabled = false;
                this.ModelFullName_tEdit.Enabled = false;
                this.ModelHalfName_tEdit.Enabled = false;
                this.ModelAliasName_tEdit.Enabled = false;
            }
            // 参照
            else if (screenMode.Equals(REFERENCE_MODE))
            {
                // ボタン設定
                this.Ok_Button.Visible = false;
                this.Delete_Button.Visible = false;
                this.Revive_Button.Visible = false;
                this.uButton_CmpltGoodsMakerGuide.Visible = true; // ADD 2010.04.26 xiaoxd
                this.uButton_ModelGuide.Visible = true;
                this.uButton_ModelGuide.Enabled = false;

                // 入力設定
                this.MakerCode_tNedit.Enabled = false;
                this.ModelCode_tNedit.Enabled = false;
                this.ModelSubCodea_tNedit.Enabled = false;
                this.ModelFullName_tEdit.Enabled = false;
                this.ModelHalfName_tEdit.Enabled = false;
                this.ModelAliasName_tEdit.Enabled = false;
            }            
        }

        /// <summary>
        /// 画面初期化処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面の初期化を行います。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.12</br>
        /// </remarks>
        private void ScreenClear()
        {
            this.MakerCode_tNedit.Clear();              // メーカーコード
            this.MakerCodeNm_tEdit.Text = "";           // メーカー名称
            this.ModelCode_tNedit.Clear();              // 車種コード
            this.ModelSubCodea_tNedit.Clear();           // 呼称コード
            this.ModelFullName_tEdit.Text = "";         // 車種名
            this.ModelHalfName_tEdit.Text = "";         // 車種名(ｶﾅ)
            this.ModelAliasName_tEdit.Text = "";        // 呼称
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
        /// <br>Date       : 2008.06.13</br>
        /// </remarks>
        private bool ScreenDataCheck(ref Control control, ref string message, string loginID)
        {
            // メーカーコード
            if (this.MakerCode_tNedit.Text == "0" || this.MakerCode_tNedit.Text.Trim() == "")
            {
                control = this.MakerCode_tNedit;
                message = this.MakerCode_Label.Text + "を入力して下さい。";
                return false;
            }

            // 車種コード
            if (this.ModelCode_tNedit.Text == "0" || this.ModelCode_tNedit.Text.Trim() == "")
            {
                control = this.ModelCode_tNedit;
                message = this.ModelCode_Label.Text + "を入力して下さい。";
                return false;
            }

            // 呼称コード（"0"は登録OK）
            if (this.ModelSubCodea_tNedit.Text.Trim() == "")
            {
                control = this.ModelSubCodea_tNedit;
                message = this.ModelSubCode_Label.Text + "を入力して下さい。";
                return false;
            }

            // 関連チェック
            if ((this.MakerCode_tNedit.GetInt() < 900)
                && (this.ModelCode_tNedit.GetInt() < 900)
                && (this.ModelSubCodea_tNedit.GetInt() < 900))
            {
                control = this.ModelCode_tNedit;
                message = this.ModelCode_Label.Text + "/"
                    + this.ModelSubCode_Label.Text + "の何れかを900以上で登録して下さい";
                return false;
            }

            // 車種名
            if (this.ModelFullName_tEdit.Text.Trim() == "")
            {
                control = this.ModelFullName_tEdit;
                message = this.ModelFullName_Label.Text + "を入力して下さい。";
                return false;
            }

            // 車種名(ｶﾅ)
            if (this.ModelHalfName_tEdit.Text.Trim() == "")
            {
                control = this.ModelHalfName_tEdit;
                message = this.ModelHalfName_Label.Text + "を入力して下さい。";
                return false;
            }

            // 呼称
            if (this.ModelAliasName_tEdit.Text.Trim() == "")
            {
                control = this.ModelAliasName_tEdit;
                message = this.ModelAliasName_Label.Text + "を入力して下さい。";
                return false;
            }

            return true;
        }

        /// <summary>
        /// 車種名称マスタ 情報登録処理
        /// </summary>
        /// <returns>登録結果（true:OK／false:NG）</returns>
        /// <remarks>
        /// <br>Note       : 車種名称マスタ 情報登録を行います。</br>
        /// <br>Programmer : 30413 犬飼</br>
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
                // 更新対象の情報を取得
                string guid = (string)this.Bind_DataSet.Tables[S_MODELNAMEU_TABLE].Rows[this._detailsDataIndex][S_MODELNAMEU_GUID];
                modelNameU = ((ModelNameU)this._modelNameUTable[guid]).Clone();
            }

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
            // 画面情報を条件クラスに設定
            this.DispToModelNameU(ref modelNameU);

            // 登録／更新処理
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
                            this,								// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_EXCLAMATION,	// エラーレベル
                            PG_ID,				        		// アセンブリＩＤまたはクラスＩＤ
                            ERR_DPR_MSG,						// 表示するメッセージ 
                            status,								// ステータス値
                            MessageBoxButtons.OK);				// 表示するボタン

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
                            this,								// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_STOPDISP,	// エラーレベル
                            PG_ID,      						// アセンブリＩＤまたはクラスＩＤ
                            PG_NAME,							// プログラム名称
                            "SaveProc",							// 処理名称
                            TMsgDisp.OPE_UPDATE,				// オペレーション
                            ERR_UPDT_MSG,						// 表示するメッセージ 
                            status,								// ステータス値
                            this._modelNameUAcs,				// エラーが発生したオブジェクト
                            MessageBoxButtons.OK,				// 表示するボタン
                            MessageBoxDefaultButton.Button1);	// 初期表示ボタン

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
                // DataSet展開処理
                ModelNameUToDataSet(modelNameU, this._detailsDataIndex);
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
        /// <br>Date       : 2008.06.13</br>
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
        /// 車種名ガイド起動処理
        /// </summary>
        /// <param name="modelNameU">車種名称マスタオブジェクト</param>
        /// <returns>結果(0:OK, 1:Cancel)</returns>
        /// <remarks>
        /// <br>Note       : 車種名ガイドの起動を行います。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.13</br>
        /// </remarks>
        private int ShowModelNameGuide(out ModelNameU modelNameU)
        {
            // 画面からメーカーコードを取得
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
        /// HashTable用キー作成
        /// </summary>
        /// <param name="makerUMnt">MakerUMntクラス</param>
        /// <returns>Hashテーブル用キー</returns>
        /// <remarks>
        /// <br>Note       : MakerUMntクラスからハッシュテーブル用のキーを作成します。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.13</br>
        /// </remarks>
        private string CreateHashKey(MakerUMnt makerUMnt)
        {
            return makerUMnt.GoodsMakerCd.ToString("d6");
        }

        /// <summary>
        /// HashTable用キー作成
        /// </summary>
        /// <param name="modelNameU">ModelNameUクラス</param>
        /// <returns>Hashテーブル用キー</returns>
        /// <remarks>
        /// <br>Note       : ModelNameUクラスからハッシュテーブル用のキーを作成します。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.13</br>
        /// </remarks>
        private string CreateHashKey(ModelNameU modelNameU)
        {
            string strHashKey = modelNameU.ModelCode.ToString("d3") + modelNameU.ModelSubCode.ToString("d3");
            return strHashKey;
        }

        /// <summary>
        /// メーカー名取得処理
        /// </summary>
        /// <param name="makerCode">メーカーコード</param>
        /// <returns>メーカー名</returns>
        /// <remarks>
        /// <br>Note       : メーカー名を取得します。</br>
        /// <br>Programmer : 30413 犬飼</br>
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
        /// 車種名取得処理
        /// </summary>
        /// <param name="modelCode">車種コード</param>
        /// <returns>車種名</returns>
        /// <remarks>
        /// <br>Note       : 車種名を取得します。</br>
        /// <br>Programmer : 30413 犬飼</br>
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

        // 2009.03.30 30413 犬飼 新規モードからモード変更対応 >>>>>>START
        /// <summary>
        /// モード変更処理
        /// </summary>
        private bool ModeChangeProc()
        {
            // メーカーコード
            int makerCd = MakerCode_tNedit.GetInt();
            // 車種コード
            int modelCode = ModelCode_tNedit.GetInt();
            // 呼称コード
            int modelSubCode = ModelSubCodea_tNedit.GetInt();

            for (int i = 0; i < this.Bind_DataSet.Tables[S_MODELNAMEU_TABLE].Rows.Count; i++)
            {
                // データセットと比較
                int dsMakerCd = int.Parse((string)this.Bind_DataSet.Tables[S_MODELNAMEU_TABLE].Rows[i][S_MAKERCODE]);
                int dsModelCode = int.Parse((string)this.Bind_DataSet.Tables[S_MODELNAMEU_TABLE].Rows[i][S_MODELCODE]);
                int dsModelSubCode = int.Parse((string)this.Bind_DataSet.Tables[S_MODELNAMEU_TABLE].Rows[i][S_MODELSUBCODE]);
                if ((makerCd == dsMakerCd) &&
                    (modelCode == dsModelCode) &&
                    (modelSubCode == dsModelSubCode))
                {
                    // 入力コードがデータセットに存在する場合
                    if ((string)this.Bind_DataSet.Tables[S_MODELNAMEU_TABLE].Rows[i][S_DELETEDATE] != "")
                    {
                        // 論理削除
                        TMsgDisp.Show(this, 					// 親ウィンドウフォーム
                          emErrorLevel.ERR_LEVEL_INFO,          // エラーレベル
                          PG_ID,						        // アセンブリＩＤまたはクラスＩＤ
                          "入力されたコードの車種マスタ情報は既に削除されています。", 			// 表示するメッセージ
                          0, 									// ステータス値
                          MessageBoxButtons.OK);				// 表示するボタン
                        // 車種、呼称のクリア
                        ModelCode_tNedit.Clear();
                        ModelSubCodea_tNedit.Clear();
                        return true;
                    }

                    DialogResult res = TMsgDisp.Show(
                        this,                                   // 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_INFO,            // エラーレベル
                        PG_ID,                                  // アセンブリＩＤまたはクラスＩＤ
                        "入力されたコードの車種マスタ情報が既に登録されています。\n編集を行いますか？",   // 表示するメッセージ
                        0,                                      // ステータス値
                        MessageBoxButtons.YesNo);               // 表示するボタン
                    switch (res)
                    {
                        case DialogResult.Yes:
                            {
                                // 画面再描画
                                this._detailsDataIndex = i;
                                ScreenClear();
                                ScreenReconstruction();
                                break;
                            }
                        case DialogResult.No:
                            {
                                // 車種、呼称のクリア
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
        /// MakerCode_tNedit_AfterExitEditModeイベント
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
                //メーカーデータの取得
                int status = makerAcs.Read(out makerUMnt, this._enterpriseCode, makerCode);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    //メーカー
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
        /// メーカーガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void uButton_CmpltGoodsMakerGuide_Click(object sender, EventArgs e)
        {
            MakerAcs makerAcs = new MakerAcs();
            MakerUMnt makerUMnt;

            //メーカーデータの取得
            int status = makerAcs.ExecuteGuid(this._enterpriseCode, out makerUMnt);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                //メーカー
                this.MakerCode_tNedit.SetInt(makerUMnt.GoodsMakerCd);
                this.MakerCodeNm_tEdit.Text = makerUMnt.MakerName;
                // 次の項目へフォーカス移動
                this.ModelCode_tNedit.Focus();
            }
        }
        // ADD 2010.04.26 xiaoxd <<<<<<<<<<<<

        // 2009.03.30 30413 犬飼 新規モードからモード変更対応 <<<<<<END
    }
}

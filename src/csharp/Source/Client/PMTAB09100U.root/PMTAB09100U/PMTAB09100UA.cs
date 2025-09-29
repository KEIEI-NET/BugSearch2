//**********************************************************************//
// システム         ：.NSシリーズ                                       //
// プログラム名称   ：PMTAB全体設定（拠点別）マスタ                     //
// プログラム概要   ：PMTAB全体設定（拠点別）の登録・修正・削除を行う   //
// ---------------------------------------------------------------------//
//					Copyright(c) 2013 Broadleaf Co.,Ltd.				//
// =====================================================================//
// 管理番号  10902622-01     作成担当：許培珠　　　　　　　　　　　　　
// 修正日    2013/05/31　    修正内容：新規作成
// ---------------------------------------------------------------------//
// 修正内容　障害報告 #38166の対応
// 管理番号  10902622-01 作成担当 : huangt
// 作 成 日  2013/07/11  作成内容 : 印刷用品番の制御に関して
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
    /// タブレット全体設定マスタ(拠点別)フォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : タブレット全体設定マスタ(拠点別)を行います。</br>
    /// <br>Programmer : 許培珠</br>
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
        /// タブレット全体設定マスタ(拠点別)フォームクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : フォームクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : 許培珠</br>
        /// <br>Date       : 2013/05/31</br>
        /// </remarks>
        public PMTAB09100UA()
        {
            InitializeComponent();

            // データセット列情報構築処理
            DataSetColumnConstruction();

            // プロパティ初期値設定
            this._canPrint                  = false;
            this._canClose                  = false;
            this._canNew                    = true;
            this._canDelete                 = true;

            this._canLogicalDeleteDataExtraction = true;
            this._defaultAutoFillToColumn = false;
            this._canSpecificationSearch = false;
            this._dataIndex = -1;

            // 企業コードを取得
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            this._pmTabTtlStSecAcs = new PmTabTtlStSecAcs();       // PMTAB全体設定マスタ(拠点別)

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

        #region Windows フォーム デザイナで生成されたコード

        /// <summary>
        /// デザイナ サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディタで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("拠点ガイド", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
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
            this.Delete_Button.Text = "完全削除(&D)";
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
            this.Revive_Button.Text = "復活(&R)";
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
            this.Ok_Button.Text = "保存(&S)";
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
            this.Cancel_Button.Text = "閉じる(&X)";
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
            this.SectionCode_Title_Label.Text = "拠点";
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
            this.Mode_Label.Text = "更新モード";
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
            ultraToolTipInfo1.ToolTipText = "拠点ガイド";
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
            this.Renewal_Button.Text = "最新情報(&I)";
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
            this.ultraLabel1.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel1.Location = new System.Drawing.Point(439, 47);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(212, 26);
            this.ultraLabel1.TabIndex = 2381;
            this.ultraLabel1.Text = "※ゼロで共通設定になります";
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
            this.CashRegisterNo_Title_Label.Text = "受信処理起動端末番号";
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
            this.LiPriSelPrtGdsNoDiv_Title_Lable.Text = "印刷品番選択区分";
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
            this.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PMTAB09100UA";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "タブレット全体設定マスタ（拠点別）";
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

        #region IMasterMaintenanceMultiType メンバ

        # region ▼Properties
        /// <summary>論理削除データ抽出可能設定プロパティ</summary>
        /// <value>論理削除データの抽出が可能かどうかの設定を取得します。</value>
        public bool CanLogicalDeleteDataExtraction
        {
            get
            {
                return this._canLogicalDeleteDataExtraction;
            }
        }

        /// <summary>件数指定抽出可能設定プロパティ</summary>
        /// <value>件数指定抽出を可能とするかどうかの設定を取得または設定します。</value>
        public bool CanSpecificationSearch
        {
            get
            {
                return this._canSpecificationSearch;
            }
        }

        /// <summary>データセットの選択データインデックスプロパティ</summary>
        /// <value>データセットの選択データインデックスを取得または設定します。</value>
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

        /// <summary>列のサイズの自動調整のデフォルト値プロパティ</summary>
        /// <value>列のサイズの自動調整チェックボックスのチェック有無のデフォルト値を取得します。</value>
        public bool DefaultAutoFillToColumn
        {
            get
            {
                return this._defaultAutoFillToColumn;
            }
        }
        # endregion ▼Properties

        # region ▼Public Methods

        /// <summary>GetAppearanceTable</summary>
        /// <value>AppearanceTableを取得します。</value>
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
        /// <value>BindDataSetを取得します。</value>
        public void GetBindDataSet(ref DataSet bindDataSet, ref string tableName)
        {
            bindDataSet = this.Bind_DataSet;
            tableName = DETAILS_TABLE;
        }
        # endregion ▼Public Methods

        # region ▼Events
        /// <summary>画面非表示イベント</summary>
        /// <remarks>画面が非表示状態になった際に発生します。</remarks>
        public event MasterMaintenanceMultiTypeUnDisplayingEventHandler UnDisplaying;
        # endregion

        #endregion

        #region Private Menbers

        private PmTabTtlStSecAcs _pmTabTtlStSecAcs;     // タブレット全体設定マスタ(拠点別)用アクセスクラス

        private string _enterpriseCode;         // 企業コード
        private Hashtable _detailsTable;        // タブレット全体設定マスタ(拠点別)用ハッシュテーブル
        private Hashtable _allSearchHash;       // 全レコード確保用

        // プロパティ用
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

        // 端末管理情報キャッシュ
        private Dictionary<int, PosTerminalMg> _posTerminalMgDic;

        private PosTerminalMgAcs _posTerminalMgAcs = null;  // 端末管理設定アクセスクラス

        // 前回端末番号
        private int _preCashRegisterNo;

        // 編集モード
        private const string INSERT_MODE = "新規モード";
        private const string UPDATE_MODE = "更新モード";
        private const string DELETE_MODE = "削除モード";

        // 全社共通
        private const string ALL_SECTIONCODE = "00";

        // 終了時の編集チェック用
        private PmTabTtlStSec _PmTabTtlStSecClone;

        // FremのView用Grid列のKEY情報 (ヘッダのタイトル部となります)
        private const string DELETE_DATE_TITLE      = "削除日";
        private const string SECTIONCODE_TITLE      = "拠点コード";
        private const string SECTIONGUIDENM_TITLE   = "拠点名";
        private const string CASHREGISTERNO_TITLE = "受信処理起動端末番号";
        private const string CASHREGISTERNONM_TITLE = "受信処理起動端末名";
        private const string LIPRISELPRTGDSNODIVNM_TITLE = "印刷品番選択区分";

        //印刷品番選択区分
        private const string LIPRISELPRTGDSNODIVNM_VALUE0 = "優良品番を印字";
        private const string LIPRISELPRTGDSNODIVNM_VALUE1 = "品番印字なし";
        // ----- ADD huangt 2013/07/11 Redmine#38166 印刷用品番の制御に関して ----- >>>>>
        private const string LIPRISELPRTGDSNODIVNM_VALUE2 = "売上全体設定の自社品番印字区分に従う(印字区分：しない　の場合は優良品番印字)";
        private const string LIPRISELPRTGDSNODIVNM_VALUE3 = "売上全体設定の自社品番印字区分に従う(印字区分：しない　の場合は品番印字なし)";
        // ----- ADD huangt 2013/07/11 Redmine#38166 印刷用品番の制御に関して ----- <<<<<

        // テーブル名称
        private const string DETAILS_TABLE = "PmTabTtlStSec";  // PMTAB全体設定マスタ（拠点別）

        // ガイドキー
        private const string DETAILS_GUID_KEY = "DetailsGuid";

        // 画面レイアウト用定数
        // ----- DEL huangt 2013/07/11 Redmine#38166 印刷用品番の制御に関して ----- >>>>>
        //private const int BUTTON_LOCATION1_X = 146;     // 完全削除ボタン位置X
        //private const int BUTTON_LOCATION2_X = 273;     // 復活ボタン位置X
        //private const int BUTTON_LOCATION3_X = 400;     // 保存ボタン位置X
        //private const int BUTTON_LOCATION4_X = 527;     // 閉じるボタン位置X
        // ----- DEL huangt 2013/07/11 Redmine#38166 印刷用品番の制御に関して ----- <<<<<
        // ----- ADD huangt 2013/07/11 Redmine#38166 印刷用品番の制御に関して ----- >>>>>
        private const int BUTTON_LOCATION1_X = 319;     // 完全削除ボタン位置X
        private const int BUTTON_LOCATION2_X = 446;     // 復活ボタン位置X
        private const int BUTTON_LOCATION3_X = 573;     // 保存ボタン位置X
        private const int BUTTON_LOCATION4_X = 700;     // 閉じるボタン位置X
        private const int BUTTON_LOCATION_Y = 8;        // ボタン位置Y(共通)
        // ----- ADD huangt 2013/07/11 Redmine#38166 印刷用品番の制御に関して ----- <<<<<

        // Message関連定義
        private const string ASSEMBLY_ID = "PMTAB09100U";
        private const string ERR_READ_MSG = "読み込みに失敗しました。";
        private const string ERR_DPR_MSG = "このコードは既に使用されています。";
        private const string ERR_RDEL_MSG = "削除に失敗しました。";
        private const string ERR_UPDT_MSG = "登録に失敗しました。";
        private const string ERR_RVV_MSG = "復活に失敗しました。";
        private const string ERR_800_MSG = "既に他端末より更新されています";
        private const string ERR_801_MSG = "既に他端末より削除されています";
        private const string SDC_RDEL_MSG = "マスタから削除されています";

        #endregion

        # region Main
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            System.Windows.Forms.Application.Run(new PMTAB09100UA());
        }
        # endregion

        # region Properties

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

        # endregion

        # region Public Methods

        /// <summary>
        /// 拠点検索処理
        /// </summary>
        /// <param name="totalCount">全該当件数</param>
        /// <param name="readCount">抽出対象件数</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 全データを検索し、抽出結果を展開したDataSetと全該当件数を返します。</br>
        /// <br>Programmer : 許培珠</br>
        /// <br>Date       : 2013/05/31</br>
        /// </remarks>
        public int Search(ref int totalCount, int readCount)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            totalCount = 0;

            try
            {
                // クリア
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
						this, 								// 親ウィンドウフォーム
						emErrorLevel.ERR_LEVEL_STOP, 		// エラーレベル
						"PMTAB09100U", 						// アセンブリＩＤまたはクラスＩＤ
						"タブレット全体設定マスタ(拠点別)", 					    // プログラム名称
                        "Search", 					        // 処理名称
						TMsgDisp.OPE_GET, 					// オペレーション
						"読み込みに失敗しました。", 		// 表示するメッセージ
						status, 							// ステータス値
						this._pmTabTtlStSecAcs, 				// エラーが発生したオブジェクト
						MessageBoxButtons.OK, 				// 表示するボタン
						MessageBoxDefaultButton.Button1 );	// 初期表示ボタン

					break;
                }
            }
            catch (Exception)
            {
                // サーチ
                TMsgDisp.Show(
                    this,								  // 親ウィンドウフォーム
                    emErrorLevel.ERR_LEVEL_STOPDISP,	  // エラーレベル
                    ASSEMBLY_ID,						  // アセンブリＩＤまたはクラスＩＤ
                    this.Text,							  // プログラム名称
                    "Search",							  // 処理名称
                    TMsgDisp.OPE_GET,					  // オペレーション
                    ERR_READ_MSG,						  // 表示するメッセージ 
                    status,								  // ステータス値
                    this._pmTabTtlStSecAcs,				      // エラーが発生したオブジェクト
                    MessageBoxButtons.OK,				  // 表示するボタン
                    MessageBoxDefaultButton.Button1);	  // 初期表示ボタン

                status = -1;
                return status;
            }

            return status;
        }

        /// <summary>
        /// ネクストデータ検索処理
        /// </summary>
        /// <param name="readCount">抽出対象件数</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 指定した件数分のネクストデータを検索します。</br>
        /// <br>Programmer : 許培珠</br>
        /// <br>Date       : 2013/05/31</br>
        /// </remarks>
        public int SearchNext(int readCount)
        {
            // 実装なし
            return 9;
        }

        /// <summary>
        /// データ削除処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 選択中のデータを削除します。</br>
        /// <br>Programmer : 許培珠</br>
        /// <br>Date       : 2013/05/31</br>
        /// </remarks>
        public int Delete()
        {
            int status = 0;

            status = LogicalDeleteSubsection();  

            return status;
        }

        /// <summary>
        /// 印刷処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 印刷処理を実行します。</br>
        /// <br>Programmer : 許培珠</br>
        /// <br>Date       : 2013/05/31</br>
        /// </remarks>
        public int Print()
        {
            // 印刷機能無しの為未実装
            return 0;
        }

        # endregion

        # region Private Methods

        /// <summary>
        /// タブレット全体設定マスタ(拠点別)オブジェクトデータセット展開処理
        /// </summary>
        /// <param name="pmTabTtlStSec">タブレット全体設定マスタ(拠点別)オブジェクト</param>
        /// <param name="index">データセットへ展開するインデックス</param>
        /// <remarks>
        /// <br>Note       : タブレット全体設定マスタ(拠点別)クラスをデータセットに格納します。</br>
        /// <br>Programmer : 許培珠</br>
        /// <br>Date       : 2013/05/31</br>
        /// </remarks>
        private void DetailsToDataSet(PmTabTtlStSec pmTabTtlStSec, int index)
        {
            if ((index < 0) || (this.Bind_DataSet.Tables[DETAILS_TABLE].Rows.Count <= index))
            {
                // 新規と判断して、行を追加する
                DataRow dataRow = this.Bind_DataSet.Tables[DETAILS_TABLE].NewRow();
                this.Bind_DataSet.Tables[DETAILS_TABLE].Rows.Add(dataRow);

                // indexを行の最終行番号する
                index = this.Bind_DataSet.Tables[DETAILS_TABLE].Rows.Count - 1;
            }

            // 論理削除区分
            if (pmTabTtlStSec.LogicalDeleteCode == 0)
            {
                this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][DELETE_DATE_TITLE] = "";
            }
            else
            {
                this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][DELETE_DATE_TITLE] = pmTabTtlStSec.UpdateDateTimeJpInFormal;
            }

            // 拠点コード

            this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][SECTIONCODE_TITLE] = pmTabTtlStSec.SectionCode;

            // 拠点名称
            string sectionNm = GetSectionName(pmTabTtlStSec.SectionCode);
            if (sectionNm == "")
            {
                sectionNm = "未登録";
            }
            this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][SECTIONGUIDENM_TITLE] = sectionNm;

            string CashRegisterNoTemp = string.Format("{0:D3}", pmTabTtlStSec.CashRegisterNo);

            // 受信処理起動端末番号コード
            this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][CASHREGISTERNO_TITLE] = CashRegisterNoTemp;

            // 受信処理起動端末番号名称
            PosTerminalMg posTerminalMg = GetPosTerminalMg(pmTabTtlStSec.CashRegisterNo);
            if (posTerminalMg == null || posTerminalMg.LogicalDeleteCode != 0)
            {
                // 端末名
                this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][CASHREGISTERNONM_TITLE] = "";
            }
            else
            {
                // 端末名
                this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][CASHREGISTERNONM_TITLE] = posTerminalMg.MachineName;
            }

            // 印刷品番選択区分
            this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][LIPRISELPRTGDSNODIVNM_TITLE] = this.GetLiPriSelPrtGdsNoDivNm(pmTabTtlStSec.LiPriSelPrtGdsNoDiv);

            // GUID
            this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][DETAILS_GUID_KEY] = pmTabTtlStSec.FileHeaderGuid;

            // ハッシュテーブル更新
            if (this._detailsTable.ContainsKey(pmTabTtlStSec.FileHeaderGuid) == true)
            {
                this._detailsTable.Remove(pmTabTtlStSec.FileHeaderGuid);
            }
            this._detailsTable.Add(pmTabTtlStSec.FileHeaderGuid, pmTabTtlStSec);
        }

        /// <summary>
        /// 拠点名称取得処理
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <returns>拠点名称</returns>
        /// <remarks>
        /// <br>Note       : 拠点名称を取得します。</br>
        /// <br>Programmer : 許培珠</br>
        /// <br>Date       : 2013/05/31</br>
        /// </remarks>
        private string GetSectionName(string sectionCode)
        {
            return this._pmTabTtlStSecAcs.GetSectionName(sectionCode);
        }

        /// <summary>
        /// タブレット全体設定マスタ(拠点別)オブジェクトデータセット削除処理
        /// </summary>
        /// <param name="pmTabTtlStSec">タブレット全体設定マスタ(拠点別)オブジェクト</param>
        /// <param name="index">データセットへ展開するインデックス</param>
        private void DeleteFromDataSet(PmTabTtlStSec pmTabTtlStSec, int index)
        {
            // データセットから行削除します
            this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index].Delete();

            // ハッシュテーブルから削除します
            if (this._detailsTable.ContainsKey(pmTabTtlStSec.FileHeaderGuid) == true)
            {
                this._detailsTable.Remove(pmTabTtlStSec.FileHeaderGuid);
            }
        }

        /// <summary>
        /// データセット列情報構築処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : データセットの列情報を構築します。
        ///					 データセットの列情報がフレームのビュー用グリッドの列になります</br>
        /// <br>Programmer : 許培珠</br>
        /// <br>Date       : 2013/05/31</br>
        /// </remarks>
        private void DataSetColumnConstruction()
        {
            DataTable detailsTable  = new DataTable(DETAILS_TABLE); // PMTAB全体設定マスタ(拠点別)

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
        /// 画面クリア処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面をクリアします。</br>
        /// <br>Programmer : 許培珠</br>
        /// <br>Date       : 2013/05/31</br>
        /// </remarks>
        private void ScreenClear()
        {
            // モードラベル
            this.Mode_Label.Text = INSERT_MODE;

            // ボタン
            this.Delete_Button.Visible  = true;  // 完全削除ボタン
            this.Revive_Button.Visible  = true;  // 復活ボタン
            this.Ok_Button.Visible      = true;  // 保存ボタン
            this.Cancel_Button.Visible = true;  // 閉じるボタン
            this.Renewal_Button.Visible = true;  // 最新情報ボタン
            this.Delete_Button.Location = new Point(BUTTON_LOCATION1_X, BUTTON_LOCATION_Y); // 完全削除ボタン位置
            this.Revive_Button.Location = new Point(BUTTON_LOCATION2_X, BUTTON_LOCATION_Y); // 復活ボタン位置
            this.Ok_Button.Location     = new Point(BUTTON_LOCATION3_X, BUTTON_LOCATION_Y); // 保存ボタン位置
            this.Cancel_Button.Location = new Point(BUTTON_LOCATION4_X, BUTTON_LOCATION_Y); // 閉じるボタン位置
            this.Renewal_Button.Location = new Point(BUTTON_LOCATION2_X, BUTTON_LOCATION_Y); // 復活ボタン位置

            // 拠点部
            this.tEdit_SectionCodeAllowZero2.Clear();
            this.SectionGuideNm_tEdit.Text = "";
            this.tEdit_SectionCodeAllowZero2.Enabled = true;
            this.SectionGuideNm_tEdit.Enabled = false;
            this.SectionGuide_ultraButton.Enabled = true;

            //受信処理起動端末番号
            this.CashRegisterNo_tEdit.Clear();
            this.CashRegisterNo_tEdit.Enabled = true;
            this.CashRegisterNoNm_tEdit.Enabled = false;
            this.CashRegisterNoNm_tEdit.Text = "";

            //印刷品番選択区分
            this.LiPriSelPrtGdsNoDiv_tComboEditor.Items.Clear();
            this.LiPriSelPrtGdsNoDiv_tComboEditor.Items.Add(0,LIPRISELPRTGDSNODIVNM_VALUE0);
            this.LiPriSelPrtGdsNoDiv_tComboEditor.Items.Add(1,LIPRISELPRTGDSNODIVNM_VALUE1);
            // ----- ADD huangt 2013/07/11 Redmine#38166 印刷用品番の制御に関して ----- >>>>>
            this.LiPriSelPrtGdsNoDiv_tComboEditor.Items.Add(2, LIPRISELPRTGDSNODIVNM_VALUE2);
            this.LiPriSelPrtGdsNoDiv_tComboEditor.Items.Add(3, LIPRISELPRTGDSNODIVNM_VALUE3);
            // ----- ADD huangt 2013/07/11 Redmine#38166 印刷用品番の制御に関して ----- <<<<<
            this.LiPriSelPrtGdsNoDiv_tComboEditor.Enabled = true;
        }

        /// <summary>
        /// 画面初期設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面の初期設定を行います。</br>
        /// <br>Programmer : 許培珠</br>
        /// <br>Date       : 2013/05/31</br>
        /// </remarks>
        private void ScreenInitialSetting()
        {
            // 新規の場合
            if (this._dataIndex < 0)
            {
                ScreenInputPermissionControl(1);                        // 画面入力許可制御
            }
            // 削除の場合
            else if ((string)this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[this._dataIndex][DELETE_DATE_TITLE] != "")
            {
                ScreenInputPermissionControl(2);                        // 画面入力許可制御
            }
            // 更新の場合
            else
            {
                ScreenInputPermissionControl(3);                        // 画面入力許可制御
            }
        }

        /// <summary>
        /// 画面入力許可制御処理
        /// </summary>
        /// <param name="setType">設定タイプ 0:親-新規, 1:親-更新, 2:親-削除, 3:子-新規, 4:子-更新, 5:子-削除</param>
        /// <remarks>
        /// <br>Note       : 画面の入力許可を制御します。</br>
        /// <br>Programmer : 許培珠</br>
        /// <br>Date       : 2013/05/31</br>
        /// </remarks>
        private void ScreenInputPermissionControl(int setType)
        {
            switch (setType) {
                // 1:新規
                case 1:
                    this.tEdit_SectionCodeAllowZero2.Enabled = true;
                    this.SectionGuide_ultraButton.Enabled = true;
                    this.SectionGuideNm_tEdit.Enabled = false;
                    this.CashRegisterNo_tEdit.Enabled = true;
                    this.CashRegisterNoNm_tEdit.Enabled = false;
                    this.LiPriSelPrtGdsNoDiv_tComboEditor.Enabled = true;

                    // ボタン
                    this.Delete_Button.Visible = false;
                    this.Revive_Button.Visible = false;
                    this.Ok_Button.Visible = true;
                    this.Cancel_Button.Visible = true;
                    this.Renewal_Button.Visible = true;

                    break;
                // 2:更新
                case 3:
                    // 表示項目
                    this.tEdit_SectionCodeAllowZero2.Enabled = false;
                    this.SectionGuideNm_tEdit.Enabled = false;
                    this.SectionGuide_ultraButton.Enabled = false;
                    this.CashRegisterNo_tEdit.Enabled = true;
                    this.CashRegisterNoNm_tEdit.Enabled = false;
                    this.LiPriSelPrtGdsNoDiv_tComboEditor.Enabled = true;

                    // ボタン
                    this.Ok_Button.Visible = true;
                    this.Cancel_Button.Visible = true;
                    this.Revive_Button.Visible = false;
                    this.Delete_Button.Visible = false;
                    this.Renewal_Button.Visible = true;

                    break;
                // 3:削除
                case 2:
                    // 表示項目
                    this.tEdit_SectionCodeAllowZero2.Enabled = false;
                    this.SectionGuideNm_tEdit.Enabled = false;
                    this.SectionGuide_ultraButton.Enabled = false;
                    this.CashRegisterNo_tEdit.Enabled = false;
                    this.CashRegisterNoNm_tEdit.Enabled = false;
                    this.LiPriSelPrtGdsNoDiv_tComboEditor.Enabled = false;

                    // ボタン
                    this.Delete_Button.Visible = true;
                    this.Revive_Button.Visible = true;
                    this.Ok_Button.Visible = false;
                    this.Renewal_Button.Visible = false;
                    this.Cancel_Button.Visible = true;
                    this.Delete_Button.Location = new Point(BUTTON_LOCATION2_X, BUTTON_LOCATION_Y); // 完全削除ボタン位置
                    this.Revive_Button.Location = new Point(BUTTON_LOCATION3_X, BUTTON_LOCATION_Y); // 復活ボタン位置
                    this.Cancel_Button.Location = new Point(BUTTON_LOCATION4_X, BUTTON_LOCATION_Y); // 閉じるボタン位置
                    break;
            }
        }

        /// <summary>
        /// 画面再構築処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : モードに基づいて画面を再構築します。</br>
        /// <br>Programmer : 許培珠</br>
        /// <br>Date       : 2013/05/31</br>
        /// </remarks>
        private void ScreenReconstruction()
        {
            PmTabTtlStSec pmTabTtlStSec = new PmTabTtlStSec();

            // 新規の場合
            if (this._dataIndex < 0)
            {
                // 画面展開処理
                SubsectionToScreen(pmTabTtlStSec);

                // クローン作成
                this._PmTabTtlStSecClone = pmTabTtlStSec.Clone();
                DispToSubsection(ref this._PmTabTtlStSecClone);

            }
            // 削除の場合
            else if ((string)this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[this._dataIndex][DELETE_DATE_TITLE] != "")
            {
                // 削除モード
                this.Mode_Label.Text = DELETE_MODE;

                // 表示情報取得
                Guid guid = (Guid)this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[this._dataIndex][DETAILS_GUID_KEY];
                pmTabTtlStSec = (PmTabTtlStSec)this._detailsTable[guid];

                // 画面展開処理
                SubsectionToScreen(pmTabTtlStSec);
            }
            // 更新の場合
            else
            {
                // 更新モード
                this.Mode_Label.Text = UPDATE_MODE;

                // 表示情報取得
                Guid guid = (Guid)this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[this._dataIndex][DETAILS_GUID_KEY];
                pmTabTtlStSec = (PmTabTtlStSec)this._detailsTable[guid];

                // 画面展開処理
                SubsectionToScreen(pmTabTtlStSec);

                // クローン作成
                this._PmTabTtlStSecClone = pmTabTtlStSec.Clone();
                DispToSubsection(ref this._PmTabTtlStSecClone);

            }

            this._detailsIndexBuf = this._dataIndex; 
        }

        /// <summary>
        /// PMT全体設定クラス画面展開処理
        /// </summary>
        /// <param name="pmTabTtlStSec">PMT全体設定オブジェクト</param>
        /// <remarks>
        /// <br>Note       : オブジェクトから画面にデータを展開します。</br>
        /// <br>Programmer : 許培珠</br>
        /// <br>Date       : 2013/05/31</br>
        /// </remarks>
        private void SubsectionToScreen(PmTabTtlStSec pmTabTtlStSec)
        {
            // 拠点コード
            this.tEdit_SectionCodeAllowZero2.DataText = pmTabTtlStSec.SectionCode.Trim();

            if (this.tEdit_SectionCodeAllowZero2.DataText == string.Empty)
            {
                this.SectionGuideNm_tEdit.DataText = "";
                this.tEdit_SectionCodeAllowZero2.Clear();
            }
            else
            {
                // 拠点名称
                string sectionNm =  GetSectionName(pmTabTtlStSec.SectionCode);
                if (sectionNm == "")
                {
                    this.SectionGuideNm_tEdit.DataText = "未登録";
                }
                else
                {
                    this.SectionGuideNm_tEdit.DataText = GetSectionName(pmTabTtlStSec.SectionCode);
                }
            }

            int cashRegisterNo = pmTabTtlStSec.CashRegisterNo;

            // 端末番号
            this.CashRegisterNo_tEdit.SetInt(cashRegisterNo);

            PosTerminalMg posTerminalMg = GetPosTerminalMg(cashRegisterNo);
            if (posTerminalMg == null || posTerminalMg.LogicalDeleteCode != 0)
            {
                // 端末名
                this.CashRegisterNoNm_tEdit.Text = "";
            }
            else
            {
                // 端末名
                this.CashRegisterNoNm_tEdit.Text = posTerminalMg.MachineName;
            }

            // 印刷品番選択区分
            this.LiPriSelPrtGdsNoDiv_tComboEditor.SelectedIndex = pmTabTtlStSec.LiPriSelPrtGdsNoDiv;
        }

        /// <summary>
        /// 画面情報全体設定クラス格納処理
        /// </summary>
        /// <param name="pmTabTtlStSec">PMTAB全体設定マスタ(拠点別)オブジェクト</param>
        /// <remarks>
        /// <br>Note       : 画面情報から全体設定オブジェクトにデータを格納します。</br>
        /// <br>Programmer : 許培珠</br>
        /// <br>Date       : 2013/05/31</br>
        /// </remarks>
        private void DispToSubsection(ref PmTabTtlStSec pmTabTtlStSec)
        {
            // 企業コード
            pmTabTtlStSec.EnterpriseCode = this._enterpriseCode;

            // 新規の場合、拠点コードを更新可能
            if(this._dataIndex < 0)
            {
                //拠点コード
                if (this._dataIndex < 0 && (this.tEdit_SectionCodeAllowZero2.DataText == ALL_SECTIONCODE))
                {
                    pmTabTtlStSec.SectionCode = "";
                }
                else
                {
                    pmTabTtlStSec.SectionCode = this.tEdit_SectionCodeAllowZero2.DataText;
                }
            }

            // 受信処理起動端末番号
            pmTabTtlStSec.CashRegisterNo = this.CashRegisterNo_tEdit.GetInt();

            // 受信処理起動端末名称
            PosTerminalMg posTerminalMg = GetPosTerminalMg(pmTabTtlStSec.CashRegisterNo);
            if (posTerminalMg == null || posTerminalMg.LogicalDeleteCode != 0)
            {
                // 端末名
                pmTabTtlStSec.CashRegisterNoNM = "";
            }
            else
            {
                // 端末名
                pmTabTtlStSec.CashRegisterNoNM = posTerminalMg.MachineName;
            }

            // 印刷品番選択区分
            pmTabTtlStSec.LiPriSelPrtGdsNoDiv = this.LiPriSelPrtGdsNoDiv_tComboEditor.SelectedIndex;
        }

        /// <summary>
        /// 画面入力情報不正チェック処理
        /// </summary>
        /// <param name="control">不正対象コントロール</param>
        /// <param name="message">メッセージ</param>
        /// <returns>チェック結果（true:OK／false:NG）</returns>
        /// <remarks>
        /// <br>Note		: 画面入力情報の不正チェックを行います。</br>
        /// <br>Programmer : 許培珠</br>
        /// <br>Date       : 2013/05/31</br>
        /// </remarks>
        private bool ScreenDataCheck1(ref Control control, ref string message)
        {
            bool result = true;

            // 拠点コード
            if (this.tEdit_SectionCodeAllowZero2.DataText.Trim() == "")
            {
                control = this.tEdit_SectionCodeAllowZero2;
                message = this.SectionCode_Title_Label.Text + "を入力して下さい。";
                this.tEdit_SectionCodeAllowZero2.Clear();
                this.SectionGuideNm_tEdit.Clear();
                result = false;
            }

            return result;
        }

        /// <summary>
        /// 画面入力情報不正チェック処理
        /// </summary>
        /// <param name="control">不正対象コントロール</param>
        /// <param name="message">メッセージ</param>
        /// <returns>チェック結果（true:OK／false:NG）</returns>
        /// <remarks>
        /// <br>Note		: 画面入力情報の不正チェックを行います。</br>
        /// <br>Programmer : 許培珠</br>
        /// <br>Date       : 2013/05/31</br>
        /// </remarks>
        private bool ScreenDataCheck2(ref Control control, ref string message)
        {
            bool result = true;

            //受信処理起動端末番号
            if (this.CashRegisterNo_tEdit.GetInt() == 0)
            {
                control = this.CashRegisterNo_tEdit;
                message = this.CashRegisterNo_Title_Label.Text + "を入力して下さい。";
                this.CashRegisterNo_tEdit.Clear();
                this.CashRegisterNoNm_tEdit.Clear();
                result = false;
            }

            return result;
        }

        /// <summary>
        /// 画面入力情報存在チェック処理
        /// </summary>
        /// <param name="control">不正対象コントロール</param>
        /// <param name="message">メッセージ</param>
        /// <returns>チェック結果（true:OK／false:NG）</returns>
        /// <remarks>
        /// <br>Note		: 画面入力情報の存在チェックを行います。</br>
        /// <br>Programmer : 許培珠</br>
        /// <br>Date       : 2013/05/31</br>
        /// </remarks>
        private bool ExistDataCheck1(ref Control control, ref string message)
        {
            bool result = true;

            if (GetSectionName(this.tEdit_SectionCodeAllowZero2.DataText.Trim()) == "")
            {
                control = this.tEdit_SectionCodeAllowZero2;
                message = "拠点が存在しません。";
                this.tEdit_SectionCodeAllowZero2.Clear();
                this.SectionGuideNm_tEdit.Clear();
                result = false;
            }

            return result;
        }

        /// <summary>
        /// 画面入力情報存在チェック処理
        /// </summary>
        /// <param name="control">不正対象コントロール</param>
        /// <param name="message">メッセージ</param>
        /// <returns>チェック結果（true:OK／false:NG）</returns>
        /// <remarks>
        /// <br>Note		: 画面入力情報の存在チェックを行います。</br>
        /// <br>Programmer : 許培珠</br>
        /// <br>Date       : 2013/05/31</br>
        /// </remarks>
        private bool ExistDataCheck2(ref Control control, ref string message)
        {
            bool result = true;

            PosTerminalMg posterMg = this.GetPosTerminalMg(this.CashRegisterNo_tEdit.GetInt());

            if (posterMg == null || posterMg.LogicalDeleteCode != 0)
            {
                control = this.CashRegisterNo_tEdit;
                message = "該当する端末番号は存在しません。";
                this.CashRegisterNo_tEdit.Clear();
                this.CashRegisterNoNm_tEdit.Clear();
                result = false;
            }

            return result;
        }

        /// <summary>
        /// 保存処理
        /// </summary>
        /// <returns>チェック結果</returns>
        /// <remarks>
        /// <br>Note　　　 : 拠点・PMTAB全体設定マスタ(拠点別)の保存処理を行います。</br>
        /// <br>Programmer : 許培珠</br>
        /// <br>Date       : 2013/05/31</br>
        /// </remarks>
        private bool SaveProc()
        {
            Control control = null;
            string message = null;

            // 不正データ入力チェック
            if (!ScreenDataCheck1(ref control, ref message)) {
                TMsgDisp.Show(
                    this, 								// 親ウィンドウフォーム
                    emErrorLevel.ERR_LEVEL_EXCLAMATION, // エラーレベル
                    ASSEMBLY_ID,						// アセンブリＩＤまたはクラスＩＤ
                    message, 							// 表示するメッセージ
                    0, 									// ステータス値
                    MessageBoxButtons.OK);				// 表示するボタン

                control.Focus();
                return false;
            }

            if (!ExistDataCheck1(ref control, ref message))
            {
                TMsgDisp.Show(
                   this, 								// 親ウィンドウフォーム
                   emErrorLevel.ERR_LEVEL_INFO,         // エラーレベル
                   ASSEMBLY_ID,					      	// アセンブリＩＤまたはクラスＩＤ
                   message, 							// 表示するメッセージ
                   0, 									// ステータス値
                   MessageBoxButtons.OK);				// 表示するボタン

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

            // 不正データ入力チェック
            if (!ScreenDataCheck2(ref control, ref message))
            {
                TMsgDisp.Show(
                    this, 								// 親ウィンドウフォーム
                    emErrorLevel.ERR_LEVEL_EXCLAMATION, // エラーレベル
                    ASSEMBLY_ID,						// アセンブリＩＤまたはクラスＩＤ
                    message, 							// 表示するメッセージ
                    0, 									// ステータス値
                    MessageBoxButtons.OK);				// 表示するボタン

                control.Focus();
                return false;
            }

            if (!ExistDataCheck2(ref control, ref message))
            {
                TMsgDisp.Show(
                   this, 								// 親ウィンドウフォーム
                   emErrorLevel.ERR_LEVEL_INFO,         // エラーレベル
                   ASSEMBLY_ID,					      	// アセンブリＩＤまたはクラスＩＤ
                   message, 							// 表示するメッセージ
                   0, 									// ステータス値
                   MessageBoxButtons.OK);				// 表示するボタン

                control.Focus();
                return false;
            }

            // PMTAB全体設定マスタ(拠点別)更新
            if (!SaveSubsection())
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// タブレット全体設定マスタ(拠点別)テーブル更新
        /// </summary>
        /// <return>更新結果status</return>
        /// <remarks>
        /// <br>Note       : 全体設定マスタ(拠点別)テーブルの更新を行います。</br>
        /// <br>Programmer : 許培珠</br>
        /// <br>Date       : 2013/05/31</br>
        /// </remarks>
        private bool SaveSubsection()
        {
            Control control = null;
            PmTabTtlStSec pmTabTtlStSec = new PmTabTtlStSec();

            // 登録レコード情報取得
            if (this._detailsIndexBuf >= 0) {
                Guid guid = (Guid)this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[this._dataIndex][DETAILS_GUID_KEY];
                pmTabTtlStSec = ((PmTabTtlStSec)this._detailsTable[guid]).Clone();
            }

            // SecInfoSetクラスにデータを格納
            DispToSubsection(ref pmTabTtlStSec);

            if (this._dataIndex < 0)
            {
                pmTabTtlStSec.SectionCode = pmTabTtlStSec.SectionCode.PadLeft(2, '0');
            }

            // SecInfoSetクラスをアクセスクラスに渡して登録・更新
            int status = this._pmTabTtlStSecAcs.Write(ref pmTabTtlStSec);

            // エラー処理
            switch (status) {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    // DataSet/Hash更新処理
                    DetailsToDataSet(pmTabTtlStSec, this._detailsIndexBuf);
                    break;
                case (int)ConstantManagement.DB_Status.ctDB_DUPLICATE:
                    // 重複処理
                    RepeatTransaction(status, ref control);
                    control.Focus();
                    return false;
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    // 排他処理
                    ExclusiveTransaction(status, TMsgDisp.OPE_UPDATE, this._pmTabTtlStSecAcs);
                    // UI子画面強制終了処理
                    EnforcedEndTransaction();
                    return false;
                default:
                    // 登録失敗
                    TMsgDisp.Show(
                        this,								// 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_STOPDISP,	// エラーレベル
                        ASSEMBLY_ID,						// アセンブリＩＤまたはクラスＩＤ
                        this.Text,							// プログラム名称
                        "SaveSubsection",				    // 処理名称
                        TMsgDisp.OPE_UPDATE,				// オペレーション
                        ERR_UPDT_MSG,						// 表示するメッセージ 
                        status,								// ステータス値
                        this._pmTabTtlStSecAcs,				    // エラーが発生したオブジェクト
                        MessageBoxButtons.OK,				// 表示するボタン
                        MessageBoxDefaultButton.Button1);	// 初期表示ボタン

                    // UI子画面強制終了処理
                    EnforcedEndTransaction();

                    return false;
            }

            // 新規登録時処理
            NewEntryTransaction();

            return true;
        }

        /// <summary>
        /// PMTAB全体設定マスタ(拠点別) 論理削除処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : PMTAB全体設定マスタ(拠点別)の対象レコードをマスタから論理削除します。</br>
        /// <br>Programmer : 許培珠</br>
        /// <br>Date       : 2013/05/31</br>
        /// </remarks>
        private int LogicalDeleteSubsection()
        {
            int status = 0;

            // 削除対象PMTAB全体設定マスタ(拠点別)取得
            Guid guid = (Guid)this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[this._dataIndex][DETAILS_GUID_KEY];
            PmTabTtlStSec pmTabTtlStSec = ((PmTabTtlStSec)this._detailsTable[guid]).Clone();

            if (pmTabTtlStSec.SectionCode.Trim() == ALL_SECTIONCODE)
            {
                TMsgDisp.Show(this,                             // 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,     // エラーレベル
                        ASSEMBLY_ID,							    // アセンブリID
                        "全社共通データは削除できません。",	    // 表示するメッセージ
                        0,									    // ステータス値
                        MessageBoxButtons.OK);					// 表示するボタン
                return 0;
            }

            status = this._pmTabTtlStSecAcs.LogicalDelete(ref pmTabTtlStSec);

            switch (status) {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    // DataSet更新
                    DetailsToDataSet(pmTabTtlStSec, _dataIndex);
                    break;
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    // 排他処理
                    ExclusiveTransaction(status, TMsgDisp.OPE_HIDE, this._pmTabTtlStSecAcs);
                    // フレーム更新
                    DetailsToDataSet(pmTabTtlStSec, _dataIndex);
                    return status;
                default:
                    TMsgDisp.Show(
                        this,								// 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_STOPDISP,	// エラーレベル
                        ASSEMBLY_ID,						// アセンブリＩＤまたはクラスＩＤ
                        this.Text,							// プログラム名称
                        "LogicalDeleteSubsection",	        // 処理名称
                        TMsgDisp.OPE_HIDE,					// オペレーション
                        ERR_RDEL_MSG,						// 表示するメッセージ 
                        status,								// ステータス値
                        this._pmTabTtlStSecAcs,			        // エラーが発生したオブジェクト
                        MessageBoxButtons.OK,				// 表示するボタン
                        MessageBoxDefaultButton.Button1);	// 初期表示ボタン

                    // フレーム更新
                    DetailsToDataSet(pmTabTtlStSec, _dataIndex);

                    return status;
            }

            return status;
        }

        /// <summary>
        /// PMTAB全体設定マスタ(拠点別) 物理削除処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : PMTAB全体設定マスタ(拠点別)の対象レコードをマスタから物理削除します。</br>
        /// <br>Programmer : 許培珠</br>
        /// <br>Date       : 2013/05/31</br>
        /// </remarks>
        private int PhysicalDeleteSubsection()
        {
            int status = 0;
            //int dummy = 0;
            Guid guid;

            // 削除対象PMTAB全体設定マスタ(拠点別)取得
            guid = (Guid)this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[this._dataIndex][DETAILS_GUID_KEY];
            PmTabTtlStSec pmTabTtlStSec = ((PmTabTtlStSec)this._detailsTable[guid]).Clone();

            // 物理削除
            status = this._pmTabTtlStSecAcs.Delete(pmTabTtlStSec);

            switch (status) {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    // DataSet更新
                    DeleteFromDataSet(pmTabTtlStSec, _dataIndex);
                    break;
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    // 排他処理
                    ExclusiveTransaction(status, TMsgDisp.OPE_DELETE, this._pmTabTtlStSecAcs);
                    // UI子画面強制終了処理
                    EnforcedEndTransaction();

                    return status;
                default:
                    TMsgDisp.Show(
                        this,								// 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_STOPDISP,	// エラーレベル
                        ASSEMBLY_ID,						// アセンブリＩＤまたはクラスＩＤ
                        this.Text,							// プログラム名称
                        "PhysicalDeleteSubsection",		    // 処理名称
                        TMsgDisp.OPE_HIDE,					// オペレーション
                        ERR_RDEL_MSG,						// 表示するメッセージ 
                        status,								// ステータス値
                        this._pmTabTtlStSecAcs,					// エラーが発生したオブジェクト
                        MessageBoxButtons.OK,				// 表示するボタン
                        MessageBoxDefaultButton.Button1);	// 初期表示ボタン

                    // UI子画面強制終了処理
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
        /// 拠点 復活処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : PMTAB全体設定マスタ(拠点別)の対象レコードを復活します。</br>
        /// <br>Programmer : 許培珠</br>
        /// <br>Date       : 2013/05/31</br>
        /// </remarks>
        private int ReviveSubsection()
        {
            int status = 0;
            Guid guid;

            // 復活対象PMTAB全体設定マスタ(拠点別)取得
            guid = (Guid)this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[this._dataIndex][DETAILS_GUID_KEY];
            PmTabTtlStSec pmTabTtlStSec = ((PmTabTtlStSec)this._detailsTable[guid]).Clone();

            // 復活
            status = this._pmTabTtlStSecAcs.Revival(ref pmTabTtlStSec);

            switch (status) {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    // DataSet展開処理
                    DetailsToDataSet(pmTabTtlStSec, this._dataIndex);
                    break;
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    // 排他処理
                    ExclusiveTransaction(status, TMsgDisp.OPE_UPDATE, this._pmTabTtlStSecAcs);
                    return status;
                default:
                    TMsgDisp.Show(
                        this,								// 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_STOPDISP,    // エラーレベル
                        ASSEMBLY_ID,						// アセンブリＩＤまたはクラスＩＤ
                        this.Text,							// プログラム名称
                        "ReviveSubsection",				    // 処理名称
                        TMsgDisp.OPE_UPDATE,				// オペレーション
                        ERR_RVV_MSG,						// 表示するメッセージ 
                        status,								// ステータス値
                        this._pmTabTtlStSecAcs,					// エラーが発生したオブジェクト
                        MessageBoxButtons.OK,				// 表示するボタン
                        MessageBoxDefaultButton.Button1);	// 初期表示ボタン
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
        /// 新規登録時処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 新規登録時の処理を行います。</br>
        /// <br>Programmer : 許培珠</br>
        /// <br>Date       : 2013/05/31</br>
        /// </remarks>
        private void NewEntryTransaction()
        {
            if (UnDisplaying != null) {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                UnDisplaying(this, me);
            }

            // 前回端末番号をクッリア
            this._preCashRegisterNo = 0;

            // 新規モードの場合は画面を終了せずに連続入力を可能とする
            if (this.Mode_Label.Text == INSERT_MODE) 
            {
                // 画面クリア処理
                ScreenClear();
                // 画面初期設定処理
                ScreenInitialSetting();
                // 画面再構築処理
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
        /// UI子画面強制終了処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : データ更新エラー時のUI子画面強制終了処理を行います。</br>
        /// <br>Programmer : 許培珠</br>
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
        /// 重複処理
        /// </summary>
        /// <param name="status">ステータス</param>
        /// <param name="control">対象コントロール</param>
        /// <remarks>
        /// <br>Note       : データ更新時の重複処理を行います。</br>
        /// <br>Programmer : 許培珠</br>
        /// <br>Date       : 2013/05/31</br>
        /// </remarks>
        private void RepeatTransaction(int status, ref Control control)
        {
            TMsgDisp.Show(
                this, 								// 親ウィンドウフォーム
                emErrorLevel.ERR_LEVEL_EXCLAMATION, // エラーレベル
                ASSEMBLY_ID,						// アセンブリＩＤまたはクラスＩＤ
                ERR_DPR_MSG, 	                    // 表示するメッセージ
                0, 									// ステータス値
                MessageBoxButtons.OK);				// 表示するボタン

            control = this.tEdit_SectionCodeAllowZero2;
            this.tEdit_SectionCodeAllowZero2.Clear();
            this.SectionGuideNm_tEdit.Clear();
        }

        /// <summary>
        /// 排他処理
        /// </summary>
        /// <param name="operation">オペレーション</param>
        /// <param name="erObject">エラーオブジェクト</param>
        /// <param name="status">ステータス</param>
        /// <remarks>
        /// <br>Note       : データ更新時の排他処理を行います。</br>
        /// <br>Programmer : 許培珠</br>
        /// <br>Date       : 2013/05/31</br>
        /// </remarks>
        private void ExclusiveTransaction(int status, string operation, object erObject)
        {
            switch ( status ) {
                case ( int ) ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    TMsgDisp.Show(
                        this,								// 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,	// エラーレベル
                        ASSEMBLY_ID,						// アセンブリＩＤまたはクラスＩＤ
                        this.Text,							// プログラム名称
                        "ExclusiveTransaction",				// 処理名称
                        operation,							// オペレーション
                        ERR_800_MSG,						// 表示するメッセージ 
                        status,								// ステータス値
                        erObject,							// エラーが発生したオブジェクト
                        MessageBoxButtons.OK,				// 表示するボタン
                        MessageBoxDefaultButton.Button1);	// 初期表示ボタン
                    break;
                case ( int ) ConstantManagement.DB_Status.ctDB_ALRDY_DELETE: 
                    TMsgDisp.Show(
                        this,								// 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,	// エラーレベル
                        ASSEMBLY_ID,						// アセンブリＩＤまたはクラスＩＤ
                        this.Text,							// プログラム名称
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

        /// <summary>
        /// コントロールサイズ設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : コントロールのサイズ設定処理を行います。</br>
        /// <br>Programmer : 許培珠</br>
        /// <br>Date       : 2013/05/31</br>
        /// </remarks>
        private void SetControlSize()
        {
            //印刷品番選択区分
            this.LiPriSelPrtGdsNoDiv_tComboEditor.Items.Clear();
            this.LiPriSelPrtGdsNoDiv_tComboEditor.Items.Add(0,LIPRISELPRTGDSNODIVNM_VALUE0);
            this.LiPriSelPrtGdsNoDiv_tComboEditor.Items.Add(1, LIPRISELPRTGDSNODIVNM_VALUE1);
            // ----- ADD huangt 2013/07/11 Redmine#38166 印刷用品番の制御に関して ----- >>>>>
            this.LiPriSelPrtGdsNoDiv_tComboEditor.Items.Add(2, LIPRISELPRTGDSNODIVNM_VALUE2);
            this.LiPriSelPrtGdsNoDiv_tComboEditor.Items.Add(3, LIPRISELPRTGDSNODIVNM_VALUE3);
            // ----- ADD huangt 2013/07/11 Redmine#38166 印刷用品番の制御に関して ----- <<<<<
        }

        # endregion

        # region Control Events

        /// <summary>
        /// Form.Load イベント(MAKHN09230U)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　 : ユーザーがフォームを読み込むときに発生します。</br>
        /// <br>Programmer : 許培珠</br>
        /// <br>Date       : 2013/05/31</br>
        /// </remarks>
        private void PMTAB09100UA_Load(object sender, System.EventArgs e)
        {
            // アイコンリソース管理クラスを使用して、アイコンを表示する
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

            // ガイドボタンのアイコン設定
            this.SectionGuide_ultraButton.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];

            this._preCashRegisterNo = 0;

            // コントロールサイズ設定
            SetControlSize();
        }

        /// <summary>
        /// Form.Closing イベント(MAKHN09230UA)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">キャンセルできるイベントのデータを提供するクラス</param>
        /// <remarks>
        /// <br>Note       : フォームを閉じる前に、ユーザーがフォームを閉じようとしたときに発生します。</br>
        /// <br>Programmer : 許培珠</br>
        /// <br>Date       : 2013/05/31</br>
        /// </remarks>
        private void PMTAB09100UA_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this._detailsIndexBuf = -2;
            this._preCashRegisterNo = 0;

            // フォームの「×」をクリックされた場合の対応です。
            if ( CanClose == false ) {
                e.Cancel = true;
                this.Hide();
                return;
            }
        }

        /// <summary>
        /// Control.VisibleChanged イベント(MAKHN09230UA)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　  : フォームの表示状態が変わったときに発生します。</br>
        /// <br>Programmer : 許培珠</br>
        /// <br>Date       : 2013/05/31</br>
        /// </remarks>
        private void PMTAB09100UA_VisibleChanged(object sender, System.EventArgs e)
        {
            this.Owner.Activate();

            // 自分自身が非表示になった場合は以下の処理をキャンセルする。
            if ( this.Visible == false ) {
                return;
            }

            // 画面クリア処理
            ScreenClear();

            // 画面初期設定処理
            ScreenInitialSetting();

            Initial_Timer.Enabled = true;
        }

        /// <summary>
        /// Control.Click イベント(Ok_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　 : 保存ボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programmer : 許培珠</br>
        /// <br>Date       : 2013/05/31</br>
        /// </remarks>
        private void Ok_Button_Click(object sender, System.EventArgs e)
        {
            // 登録処理
            SaveProc();
        }

        /// <summary>
        /// Control.Click イベント(Cancel_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　 : 閉じるボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programmer : 許培珠</br>
        /// <br>Date       : 2013/05/31</br>
        /// </remarks>
        private void Cancel_Button_Click(object sender, System.EventArgs e)
        {
            bool cloneFlg = true;

            // 削除モード以外の場合は保存確認処理を行う
            if ( this.Mode_Label.Text != DELETE_MODE ) {

                // 現在の画面情報を取得
                PmTabTtlStSec pmTabTtlStSec = new PmTabTtlStSec();
                pmTabTtlStSec = this._PmTabTtlStSecClone.Clone();
                DispToSubsection(ref pmTabTtlStSec);
                // 最初に取得した画面情報と比較
                cloneFlg = this._PmTabTtlStSecClone.Equals(pmTabTtlStSec);

                if ( !( cloneFlg ) ) {
                    // 画面情報が変更されていた場合は、保存確認メッセージを表示する
                    DialogResult res = TMsgDisp.Show(
                        this,								// 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_SAVECONFIRM,	// エラーレベル
                        ASSEMBLY_ID,						// アセンブリＩＤまたはクラスＩＤ
                        "",									// 表示するメッセージ 
                        0,									// ステータス値
                        MessageBoxButtons.YesNoCancel);		// 表示するボタン

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
        /// Control.Click イベント(Delete_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　 : 完全削除ボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programmer : 許培珠</br>
        /// <br>Date       : 2013/05/31</br>
        /// </remarks>
        private void Delete_Button_Click(object sender, System.EventArgs e)
        {
            // 完全削除確認
            DialogResult result = TMsgDisp.Show(
                this, 								// 親ウィンドウフォーム
                emErrorLevel.ERR_LEVEL_EXCLAMATION, // エラーレベル
                ASSEMBLY_ID,						// アセンブリＩＤまたはクラスＩＤ
                "データを削除します。" + "\r\n" +
                "よろしいですか？", 				// 表示するメッセージ
                0, 									// ステータス値
                MessageBoxButtons.OKCancel,
                MessageBoxDefaultButton.Button2);		// 表示するボタン

            if ( result == DialogResult.OK ) {

                // PMTAB全体設定マスタ(拠点別)物理削除
                PhysicalDeleteSubsection();
            }
        }

        /// <summary>
        /// Control.Click イベント(Revive_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　 : 復活ボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programmer : 許培珠</br>
        /// <br>Date       : 2013/05/31</br>
        /// </remarks>
        private void Revive_Button_Click(object sender, System.EventArgs e)
        {
            ReviveSubsection();  
        }

        /// <summary>
        /// Timer.Tick イベント イベント(Initial_Timer)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　 : 指定された間隔の時間が経過したときに発生します。
        ///					 この処理は、システムが提供するスレッド プール
        ///					 スレッドで実行されます。</br>
        /// <br>Programmer : 許培珠</br>
        /// <br>Date       : 2013/05/31</br>
        /// </remarks>
        private void Initial_Timer_Tick(object sender, System.EventArgs e)
        {
            Initial_Timer.Enabled = false;
            ScreenReconstruction();
        }

        /// <summary>
        /// Control.Click イベント(SectionGuide_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　 : 拠点ガイドボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programmer : 許培珠</br>
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
        /// tArrowKeyControlChangeFocusイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note		: コントロールのフォーカスが変わるタイミングで発生します。</br>
        /// <br>Programmer	: 許培珠</br>
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
                            // 拠点コード取得
                            string sectionCode = this.tEdit_SectionCodeAllowZero2.DataText;

                            this.tEdit_SectionCodeAllowZero2.DataText = this.tEdit_SectionCodeAllowZero2.DataText.PadLeft(2, '0');

                            // 拠点名称取得
                            this.SectionGuideNm_tEdit.DataText = GetSectionName(sectionCode);

                        }
                        else 
                        {
                            TMsgDisp.Show(
                                           this, 								// 親ウィンドウフォーム
                                           emErrorLevel.ERR_LEVEL_INFO,         // エラーレベル
                                           ASSEMBLY_ID,						    // アセンブリＩＤまたはクラスＩＤ
                                           "拠点が存在しません。", 							// 表示するメッセージ
                                           0, 									// ステータス値
                                           MessageBoxButtons.OK);				// 表示するボタン

                            this.tEdit_SectionCodeAllowZero2.Clear();
                            this.SectionGuideNm_tEdit.Clear();

                            e.NextCtrl = e.PrevCtrl;

                            break;
                        }

                    }

                    // 拠点コードにフォーカスがある場合
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
                    // モード変更処理
                    if (e.NextCtrl.Name == "Cancel_Button")
                    {
                        // 遷移先が閉じるボタン
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
                            // 端末管理設定マスタから名称を取得
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
                                    "該当する端末番号が存在しません。",
                                    -1,
                                    MessageBoxButtons.OK);

                                CashRegisterNo_tEdit.Clear();
                                CashRegisterNoNm_tEdit.Clear();

                                e.NextCtrl = e.PrevCtrl;
                            }
                        }

                        this._preCashRegisterNo = CashRegisterNo_tEdit.GetInt();

                        // 受信処理起動端末番号コードにフォーカスがある場合
                        if (e.Key == Keys.Down)
                        {
                            // 印刷品番選択区分にフォーカスを移します
                            e.NextCtrl = this.LiPriSelPrtGdsNoDiv_tComboEditor;
                        }
                        break;
                    }
                case "Ok_Button":
                    // 保存ボタンにフォーカスがある場合
                    if (e.Key == Keys.Up)
                    {
                        // 拠点ガイドボタンにフォーカスを移します
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

            TMsgDisp.Show(this, 								// 親ウィンドウフォーム
                          emErrorLevel.ERR_LEVEL_INFO,          // エラーレベル
                          ASSEMBLY_ID,						    // アセンブリＩＤまたはクラスＩＤ
                          "最新情報を取得しました。", 			// 表示するメッセージ
                          0, 									// ステータス値
                          MessageBoxButtons.OK);				// 表示するボタン
        }

        /// <summary>
        /// モード変更処理
        /// </summary>
        private bool ModeChangeProc()
        {
            if(this.tEdit_SectionCodeAllowZero2.DataText == "")
            {
                return false;
            }

            string msg = "入力されたコードのタブレット全体設定マスタ(拠点別)情報が既に登録されています。\n編集を行いますか？";

            // 拠点コード
            string SecCd = this.tEdit_SectionCodeAllowZero2.Text.TrimEnd().PadLeft(2,'0');

            for (int i = 0; i < this.Bind_DataSet.Tables[DETAILS_TABLE].Rows.Count; i++)
            {
                // データセットと比較
                string dbSecCd = this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[i][SECTIONCODE_TITLE].ToString().Trim().PadLeft(2,'0');

                if (SecCd.Equals(dbSecCd.TrimEnd()))
                {
                    // 入力コードがデータセットに存在する場合
                    if ((string)this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[i][DELETE_DATE_TITLE] != "")
                    {
                        // 論理削除
                        TMsgDisp.Show(this, 					// 親ウィンドウフォーム
                          emErrorLevel.ERR_LEVEL_INFO,          // エラーレベル
                          ASSEMBLY_ID,						    // アセンブリＩＤまたはクラスＩＤ
                          "入力されたコードのタブレット全体設定マスタ(拠点別)情報は既に削除されています。", 			// 表示するメッセージ
                          0, 									// ステータス値
                          MessageBoxButtons.OK);				// 表示するボタン
                        // PMTAB全体設定マスタ(拠点別)コードのクリア
                        this.tEdit_SectionCodeAllowZero2.Clear();
                        this.SectionGuideNm_tEdit.Clear();
                        return true;
                    }

                    if (SecCd == ALL_SECTIONCODE)
                    {
                        // 全社共通のメッセージ変更
                        msg = "入力されたコードのタブレット全体設定マスタ(拠点別)情報が既に登録されています。\n　【拠点名称：全社共通】\n編集を行いますか？";
                    }


                    DialogResult res = TMsgDisp.Show(
                        this,                                   // 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_INFO,            // エラーレベル
                        ASSEMBLY_ID,                            // アセンブリＩＤまたはクラスＩＤ
                        msg,                                    // 表示するメッセージ
                        0,                                      // ステータス値
                        MessageBoxButtons.YesNo);               // 表示するボタン
                    switch (res)
                    {
                        case DialogResult.Yes:
                            {
                                // 画面再描画
                                this._dataIndex = i;
                                ScreenClear();
                                ScreenInitialSetting();
                                ScreenReconstruction();
                                break;
                            }
                        case DialogResult.No:
                            {
                                // 拠点コードのクリア
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
        /// キャッシュ情報取得処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 端末管理番号の名称をキャッシュ化。</br>
        /// </remarks>
        private void GetCacheData()
        {
            // 端末管理設定取得
            this.GetPosTerminalMgCache();

        }

        /// <summary>
        /// 端末管理設定のローカルキャッシュ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 端末管理設定のローカルキャッシュを作成します。</br>
        /// <br></br>
        /// </remarks>
        private void GetPosTerminalMgCache()
        {
            int status;
            ArrayList retList;

            // 端末管理設定のローカルキャッシュをクリア
            _posTerminalMgDic = new Dictionary<int, PosTerminalMg>();

            // 端末管理設定の取得
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
                            // 既にキャッシュに存在している場合は削除
                            _posTerminalMgDic.Remove(key);
                        }
                        _posTerminalMgDic.Add(key, wkPosTerminalMg);
                    }
                }
            }
        }

        /// <summary>
        /// 端末管理設定を取得します。
        /// </summary>
        /// <param name="cashRegisterNo">端末番号</param>
        /// <returns>端末管理設定データクラス</returns>
        /// <remarks>
        /// <br>Note       : 端末番号から端末管理設定データクラスを取得します。</br>
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
        /// 印刷用品番設定区分名称を取得します。
        /// </summary>
        /// <param name="liPriSelPrtGdsNoDiv">印刷用品番設定区分</param>
        /// <returns>印刷用品番設定区分名称</returns>
        /// <remarks>
        /// <br>Note       : 印刷用品番設定区分から印刷用品番設定区分名称を取得します。</br>
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
                // ----- ADD huangt 2013/07/11 Redmine#38166 印刷用品番の制御に関して ----- >>>>>
                case 2:
                    str = LIPRISELPRTGDSNODIVNM_VALUE2;
                    break;
                case 3:
                    str = LIPRISELPRTGDSNODIVNM_VALUE3;
                    break;
                // ----- ADD huangt 2013/07/11 Redmine#38166 印刷用品番の制御に関して ----- <<<<<
                default:
                    break;
            }
            return str;
        }

        /// <summary>
        /// 拠点が存在かをチェック。
        /// </summary>
        /// <param name="sectioncode">拠点コード</param>
        /// <returns>flag</returns>
        /// <remarks>
        /// <br>Note       : 拠点が存在かをチェック。</br>
        /// <br></br>
        /// </remarks>
        private bool sectionExist(string sectioncode)
        {
            return this._pmTabTtlStSecAcs.SectionExistCheck(sectioncode);
        }

        /// <summary>
        /// 拠点コードEdit Leave処理
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : 拠点名称表示処理</br>
        /// <br></br>
        /// </remarks>
        private void tEdit_SectionCode_Leave(object sender, EventArgs e)
        {
            // 拠点コード入力あり？
            if (this.tEdit_SectionCodeAllowZero2.Text != "")
            {
                // 拠点コード名称設定
                this.SectionGuideNm_tEdit.Text = GetSectionName(this.tEdit_SectionCodeAllowZero2.Text.Trim());

                if (SectionUtil.IsAllSection(this.tEdit_SectionCodeAllowZero2.Text))
                {
                    this.SectionGuideNm_tEdit.Text = SectionUtil.ALL_SECTION_NAME;
                }

            }
        }

        /// <summary>
        /// 拠点コードtEdit_SectionCodeAllowZero2_ValueChanged処理、数字以外入力できない
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : 拠点コードtEdit_SectionCodeAllowZero2_ValueChanged処理、数字以外入力できない</br>
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
        /// 端末番号コードCashRegisterNo_tEdit_ValueChanged処理、数字以外入力できない
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : 端末番号コードCashRegisterNo_tEdit_ValueChanged処理、数字以外入力できない</br>
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

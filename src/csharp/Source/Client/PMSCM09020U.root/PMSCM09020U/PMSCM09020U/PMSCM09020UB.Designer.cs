using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Library.Windows.Forms;

namespace Broadleaf.Windows.Forms
{
    partial class PMSCM09020UB
    {
        #region -- Component --

        private Infragistics.Win.Misc.UltraButton Cancel_Button;
		private Infragistics.Win.Misc.UltraButton Ok_Button;
		private Infragistics.Win.UltraWinStatusBar.UltraStatusBar ultraStatusBar1;
        private Infragistics.Win.Misc.UltraLabel Mode_Label;
		private Infragistics.Win.Misc.UltraLabel Section_uLabel;
		private Broadleaf.Library.Windows.Forms.TEdit SectionName_tEdit;
		private Broadleaf.Library.Windows.Forms.TArrowKeyControl tArrowKeyControl1;
		private Broadleaf.Library.Windows.Forms.TRetKeyControl tRetKeyControl1;
		private System.Data.DataSet Bind_DataSet;
        private System.Windows.Forms.Timer Timer;
        private Infragistics.Win.UltraWinToolTip.UltraToolTipManager ultraToolTipManager1;
        private Infragistics.Win.Misc.UltraLabel DivideLine_Label;
        private Infragistics.Win.Misc.UltraButton SectionGuide_Button;
        private Infragistics.Win.Misc.UltraLabel ultraLabel6;
        private Infragistics.Win.Misc.UltraButton Delete_Button;
        private Infragistics.Win.Misc.UltraButton Revive_Button;
        private TEdit tEdit_SectionCodeAllowZero;
        private UiSetControl uiSetControl1;
        private Infragistics.Win.Misc.UltraButton Renewal_Button;
        private Infragistics.Win.Misc.UltraLabel ultraLabel10;
        private Infragistics.Win.Misc.UltraLabel ultraLabel9;
        private TEdit tEdit_RcvProcStInterval;
        private Infragistics.Win.Misc.UltraLabel ultraLabel7;
        private TEdit tEdit_CashRegisterNo;
        private TEdit tEdit_CashRegisterNoNm;
		#endregion

		
		private System.ComponentModel.IContainer components;

		/// <summary>
		/// 使用されているリソースに後処理を実行します。
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region -- Windows フォーム デザイナで生成されたコード --
		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// デザイナ サポートに必要なメソッドです。このメソッドの内容を
		/// コード エディタで変更しないでください。
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance36 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance37 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("拠点ガイド", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.Appearance appearance34 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance41 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance42 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance39 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance40 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance38 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance43 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance44 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance45 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance48 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance127 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance52 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance53 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance54 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance63 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PMSCM09020UB));
            this.Cancel_Button = new Infragistics.Win.Misc.UltraButton();
            this.Ok_Button = new Infragistics.Win.Misc.UltraButton();
            this.ultraStatusBar1 = new Infragistics.Win.UltraWinStatusBar.UltraStatusBar();
            this.Mode_Label = new Infragistics.Win.Misc.UltraLabel();
            this.Section_uLabel = new Infragistics.Win.Misc.UltraLabel();
            this.SectionName_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.tArrowKeyControl1 = new Broadleaf.Library.Windows.Forms.TArrowKeyControl(this.components);
            this.tRetKeyControl1 = new Broadleaf.Library.Windows.Forms.TRetKeyControl(this.components);
            this.Timer = new System.Windows.Forms.Timer(this.components);
            this.Bind_DataSet = new System.Data.DataSet();
            this.ultraToolTipManager1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipManager(this.components);
            this.SectionGuide_Button = new Infragistics.Win.Misc.UltraButton();
            this.DivideLine_Label = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel6 = new Infragistics.Win.Misc.UltraLabel();
            this.Revive_Button = new Infragistics.Win.Misc.UltraButton();
            this.Delete_Button = new Infragistics.Win.Misc.UltraButton();
            this.tEdit_SectionCodeAllowZero = new Broadleaf.Library.Windows.Forms.TEdit();
            this.uiSetControl1 = new Broadleaf.Library.Windows.Forms.UiSetControl(this.components);
            this.Renewal_Button = new Infragistics.Win.Misc.UltraButton();
            this.tEdit_CashRegisterNo = new Broadleaf.Library.Windows.Forms.TEdit();
            this.tEdit_CashRegisterNoNm = new Broadleaf.Library.Windows.Forms.TEdit();
            this.ultraLabel7 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel9 = new Infragistics.Win.Misc.UltraLabel();
            this.tEdit_RcvProcStInterval = new Broadleaf.Library.Windows.Forms.TEdit();
            this.ultraLabel10 = new Infragistics.Win.Misc.UltraLabel();
            this.SalesCdStAutoAns_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.ultraLabel13 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel12 = new Infragistics.Win.Misc.UltraLabel();
            this.SalesCode_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.uButton_SalesCode = new Infragistics.Win.Misc.UltraButton();
            this.AutoAnsHourDspDiv_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.AutoAnsHourDspDiv_uLabel = new Infragistics.Win.Misc.UltraLabel();
            ((System.ComponentModel.ISupportInitialize)(this.SectionName_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bind_DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SectionCodeAllowZero)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_CashRegisterNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_CashRegisterNoNm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_RcvProcStInterval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesCdStAutoAns_tComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesCode_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AutoAnsHourDspDiv_tComboEditor)).BeginInit();
            this.SuspendLayout();
            // 
            // Cancel_Button
            // 
            this.Cancel_Button.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Cancel_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Cancel_Button.Location = new System.Drawing.Point(563, 239);
            this.Cancel_Button.Name = "Cancel_Button";
            this.Cancel_Button.Size = new System.Drawing.Size(125, 34);
            this.Cancel_Button.TabIndex = 21;
            this.Cancel_Button.Text = "閉じる(&X)";
            this.Cancel_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Cancel_Button.Click += new System.EventHandler(this.Cancel_Button_Click);
            // 
            // Ok_Button
            // 
            this.Ok_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Ok_Button.Location = new System.Drawing.Point(435, 239);
            this.Ok_Button.Name = "Ok_Button";
            this.Ok_Button.Size = new System.Drawing.Size(125, 34);
            this.Ok_Button.TabIndex = 19;
            this.Ok_Button.Text = "保存(&S)";
            this.Ok_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Ok_Button.Click += new System.EventHandler(this.Ok_Button_Click);
            // 
            // ultraStatusBar1
            // 
            this.ultraStatusBar1.Location = new System.Drawing.Point(0, 292);
            this.ultraStatusBar1.Name = "ultraStatusBar1";
            this.ultraStatusBar1.Size = new System.Drawing.Size(713, 23);
            this.ultraStatusBar1.TabIndex = 11;
            this.ultraStatusBar1.ViewStyle = Infragistics.Win.UltraWinStatusBar.ViewStyle.Office2003;
            // 
            // Mode_Label
            // 
            appearance1.ForeColor = System.Drawing.Color.White;
            appearance1.TextHAlignAsString = "Center";
            appearance1.TextVAlignAsString = "Middle";
            this.Mode_Label.Appearance = appearance1;
            this.Mode_Label.BackColorInternal = System.Drawing.Color.Navy;
            this.Mode_Label.Location = new System.Drawing.Point(559, 12);
            this.Mode_Label.Name = "Mode_Label";
            this.Mode_Label.Size = new System.Drawing.Size(100, 23);
            this.Mode_Label.TabIndex = 61;
            this.Mode_Label.Text = "更新モード";
            // 
            // Section_uLabel
            // 
            appearance4.TextVAlignAsString = "Middle";
            this.Section_uLabel.Appearance = appearance4;
            this.Section_uLabel.Location = new System.Drawing.Point(16, 42);
            this.Section_uLabel.Name = "Section_uLabel";
            this.Section_uLabel.Size = new System.Drawing.Size(165, 24);
            this.Section_uLabel.TabIndex = 184;
            this.Section_uLabel.Text = "拠点";
            // 
            // SectionName_tEdit
            // 
            appearance36.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance36.ForeColor = System.Drawing.Color.Black;
            this.SectionName_tEdit.ActiveAppearance = appearance36;
            appearance37.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance37.ForeColor = System.Drawing.Color.Black;
            appearance37.ForeColorDisabled = System.Drawing.Color.Black;
            appearance37.TextHAlignAsString = "Left";
            this.SectionName_tEdit.Appearance = appearance37;
            this.SectionName_tEdit.AutoSelect = true;
            this.SectionName_tEdit.DataText = "";
            this.SectionName_tEdit.Enabled = false;
            this.SectionName_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.SectionName_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 10, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.SectionName_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.SectionName_tEdit.Location = new System.Drawing.Point(255, 42);
            this.SectionName_tEdit.MaxLength = 10;
            this.SectionName_tEdit.Name = "SectionName_tEdit";
            this.SectionName_tEdit.ReadOnly = true;
            this.SectionName_tEdit.Size = new System.Drawing.Size(175, 24);
            this.SectionName_tEdit.TabIndex = 1;
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
            // Timer
            // 
            this.Timer.Interval = 1;
            this.Timer.Tick += new System.EventHandler(this.Timer_Tick);
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
            // SectionGuide_Button
            // 
            this.SectionGuide_Button.Location = new System.Drawing.Point(437, 42);
            this.SectionGuide_Button.Name = "SectionGuide_Button";
            this.SectionGuide_Button.Size = new System.Drawing.Size(25, 24);
            this.SectionGuide_Button.TabIndex = 2;
            ultraToolTipInfo1.ToolTipText = "拠点ガイド";
            this.ultraToolTipManager1.SetUltraToolTip(this.SectionGuide_Button, ultraToolTipInfo1);
            this.SectionGuide_Button.Click += new System.EventHandler(this.SectionGuide_Button_Click);
            // 
            // DivideLine_Label
            // 
            this.DivideLine_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.DivideLine_Label.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Inset;
            this.DivideLine_Label.Location = new System.Drawing.Point(16, 72);
            this.DivideLine_Label.Name = "DivideLine_Label";
            this.DivideLine_Label.Size = new System.Drawing.Size(645, 3);
            this.DivideLine_Label.TabIndex = 261;
            // 
            // ultraLabel6
            // 
            appearance34.TextVAlignAsString = "Middle";
            this.ultraLabel6.Appearance = appearance34;
            this.ultraLabel6.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel6.Location = new System.Drawing.Point(487, 42);
            this.ultraLabel6.Name = "ultraLabel6";
            this.ultraLabel6.Size = new System.Drawing.Size(223, 24);
            this.ultraLabel6.TabIndex = 262;
            this.ultraLabel6.Text = "※ゼロで共通設定になります";
            // 
            // Revive_Button
            // 
            this.Revive_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Revive_Button.Location = new System.Drawing.Point(436, 239);
            this.Revive_Button.Name = "Revive_Button";
            this.Revive_Button.Size = new System.Drawing.Size(125, 34);
            this.Revive_Button.TabIndex = 20;
            this.Revive_Button.Text = "復活(&R)";
            this.Revive_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Revive_Button.Click += new System.EventHandler(this.Revive_Button_Click);
            // 
            // Delete_Button
            // 
            this.Delete_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Delete_Button.Location = new System.Drawing.Point(306, 239);
            this.Delete_Button.Name = "Delete_Button";
            this.Delete_Button.Size = new System.Drawing.Size(125, 34);
            this.Delete_Button.TabIndex = 16;
            this.Delete_Button.Text = "完全削除(&D)";
            this.Delete_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Delete_Button.Click += new System.EventHandler(this.Delete_Button_Click);
            // 
            // tEdit_SectionCodeAllowZero
            // 
            appearance41.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance41.TextHAlignAsString = "Right";
            this.tEdit_SectionCodeAllowZero.ActiveAppearance = appearance41;
            appearance42.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance42.ForeColorDisabled = System.Drawing.Color.Black;
            appearance42.TextHAlignAsString = "Right";
            this.tEdit_SectionCodeAllowZero.Appearance = appearance42;
            this.tEdit_SectionCodeAllowZero.AutoSelect = true;
            this.tEdit_SectionCodeAllowZero.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tEdit_SectionCodeAllowZero.DataText = "";
            this.tEdit_SectionCodeAllowZero.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_SectionCodeAllowZero.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 2, new Broadleaf.Library.Windows.Forms.TEnableChars(false, true, false, false, true, true, true));
            this.tEdit_SectionCodeAllowZero.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.tEdit_SectionCodeAllowZero.Location = new System.Drawing.Point(221, 42);
            this.tEdit_SectionCodeAllowZero.MaxLength = 2;
            this.tEdit_SectionCodeAllowZero.Name = "tEdit_SectionCodeAllowZero";
            this.tEdit_SectionCodeAllowZero.Size = new System.Drawing.Size(28, 24);
            this.tEdit_SectionCodeAllowZero.TabIndex = 0;
            // 
            // uiSetControl1
            // 
            this.uiSetControl1.EditWidthSettingWay = Broadleaf.Library.Windows.Forms.UiSetControl.EditWidthSettingWayState.None;
            this.uiSetControl1.OwnerForm = this;
            // 
            // Renewal_Button
            // 
            this.Renewal_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Renewal_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Renewal_Button.Location = new System.Drawing.Point(306, 239);
            this.Renewal_Button.Margin = new System.Windows.Forms.Padding(1);
            this.Renewal_Button.Name = "Renewal_Button";
            this.Renewal_Button.Size = new System.Drawing.Size(125, 34);
            this.Renewal_Button.TabIndex = 19;
            this.Renewal_Button.Text = "最新情報(&I)";
            this.Renewal_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Renewal_Button.Click += new System.EventHandler(this.Renewal_Button_Click);
            // 
            // tEdit_CashRegisterNo
            // 
            appearance39.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance39.TextHAlignAsString = "Right";
            this.tEdit_CashRegisterNo.ActiveAppearance = appearance39;
            appearance40.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance40.ForeColorDisabled = System.Drawing.Color.Black;
            appearance40.TextHAlignAsString = "Right";
            this.tEdit_CashRegisterNo.Appearance = appearance40;
            this.tEdit_CashRegisterNo.AutoSelect = true;
            this.tEdit_CashRegisterNo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tEdit_CashRegisterNo.DataText = "";
            this.tEdit_CashRegisterNo.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_CashRegisterNo.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 3, new Broadleaf.Library.Windows.Forms.TEnableChars(false, true, false, false, false, false, true));
            this.tEdit_CashRegisterNo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.tEdit_CashRegisterNo.Location = new System.Drawing.Point(221, 81);
            this.tEdit_CashRegisterNo.MaxLength = 3;
            this.tEdit_CashRegisterNo.Name = "tEdit_CashRegisterNo";
            this.tEdit_CashRegisterNo.Size = new System.Drawing.Size(35, 24);
            this.tEdit_CashRegisterNo.TabIndex = 13;
            // 
            // tEdit_CashRegisterNoNm
            // 
            appearance2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance2.ForeColor = System.Drawing.Color.Black;
            this.tEdit_CashRegisterNoNm.ActiveAppearance = appearance2;
            appearance3.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance3.ForeColor = System.Drawing.Color.Black;
            appearance3.ForeColorDisabled = System.Drawing.Color.Black;
            appearance3.TextHAlignAsString = "Left";
            this.tEdit_CashRegisterNoNm.Appearance = appearance3;
            this.tEdit_CashRegisterNoNm.AutoSelect = true;
            this.tEdit_CashRegisterNoNm.DataText = "";
            this.tEdit_CashRegisterNoNm.Enabled = false;
            this.tEdit_CashRegisterNoNm.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_CashRegisterNoNm.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 10, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.tEdit_CashRegisterNoNm.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.tEdit_CashRegisterNoNm.Location = new System.Drawing.Point(270, 81);
            this.tEdit_CashRegisterNoNm.MaxLength = 10;
            this.tEdit_CashRegisterNoNm.Name = "tEdit_CashRegisterNoNm";
            this.tEdit_CashRegisterNoNm.ReadOnly = true;
            this.tEdit_CashRegisterNoNm.Size = new System.Drawing.Size(159, 24);
            this.tEdit_CashRegisterNoNm.TabIndex = 267;
            // 
            // ultraLabel7
            // 
            appearance38.TextVAlignAsString = "Middle";
            this.ultraLabel7.Appearance = appearance38;
            this.ultraLabel7.Location = new System.Drawing.Point(16, 81);
            this.ultraLabel7.Name = "ultraLabel7";
            this.ultraLabel7.Size = new System.Drawing.Size(165, 24);
            this.ultraLabel7.TabIndex = 268;
            this.ultraLabel7.Text = "受信処理起動端末番号";
            // 
            // ultraLabel9
            // 
            appearance5.TextVAlignAsString = "Middle";
            this.ultraLabel9.Appearance = appearance5;
            this.ultraLabel9.Location = new System.Drawing.Point(16, 111);
            this.ultraLabel9.Name = "ultraLabel9";
            this.ultraLabel9.Size = new System.Drawing.Size(165, 24);
            this.ultraLabel9.TabIndex = 270;
            this.ultraLabel9.Text = "受信処理起動間隔";
            // 
            // tEdit_RcvProcStInterval
            // 
            appearance6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance6.TextHAlignAsString = "Right";
            this.tEdit_RcvProcStInterval.ActiveAppearance = appearance6;
            appearance12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance12.ForeColorDisabled = System.Drawing.Color.Black;
            appearance12.TextHAlignAsString = "Right";
            this.tEdit_RcvProcStInterval.Appearance = appearance12;
            this.tEdit_RcvProcStInterval.AutoSelect = true;
            this.tEdit_RcvProcStInterval.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tEdit_RcvProcStInterval.DataText = "";
            this.tEdit_RcvProcStInterval.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_RcvProcStInterval.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 3, new Broadleaf.Library.Windows.Forms.TEnableChars(false, true, false, false, false, false, true));
            this.tEdit_RcvProcStInterval.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.tEdit_RcvProcStInterval.Location = new System.Drawing.Point(221, 111);
            this.tEdit_RcvProcStInterval.MaxLength = 3;
            this.tEdit_RcvProcStInterval.Name = "tEdit_RcvProcStInterval";
            this.tEdit_RcvProcStInterval.Size = new System.Drawing.Size(35, 24);
            this.tEdit_RcvProcStInterval.TabIndex = 14;
            // 
            // ultraLabel10
            // 
            appearance13.TextVAlignAsString = "Middle";
            this.ultraLabel10.Appearance = appearance13;
            this.ultraLabel10.Location = new System.Drawing.Point(271, 111);
            this.ultraLabel10.Name = "ultraLabel10";
            this.ultraLabel10.Size = new System.Drawing.Size(24, 24);
            this.ultraLabel10.TabIndex = 271;
            this.ultraLabel10.Text = "分";
            // 
            // SalesCdStAutoAns_tComboEditor
            // 
            appearance43.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance43.ForeColor = System.Drawing.Color.Black;
            appearance43.TextVAlignAsString = "Middle";
            this.SalesCdStAutoAns_tComboEditor.ActiveAppearance = appearance43;
            appearance44.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance44.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance44.ForeColorDisabled = System.Drawing.Color.Black;
            this.SalesCdStAutoAns_tComboEditor.Appearance = appearance44;
            this.SalesCdStAutoAns_tComboEditor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.SalesCdStAutoAns_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.SalesCdStAutoAns_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance45.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.SalesCdStAutoAns_tComboEditor.ItemAppearance = appearance45;
            this.SalesCdStAutoAns_tComboEditor.Location = new System.Drawing.Point(221, 141);
            this.SalesCdStAutoAns_tComboEditor.Name = "SalesCdStAutoAns_tComboEditor";
            this.SalesCdStAutoAns_tComboEditor.Size = new System.Drawing.Size(224, 24);
            this.SalesCdStAutoAns_tComboEditor.TabIndex = 15;
            this.SalesCdStAutoAns_tComboEditor.ValueChanged += new System.EventHandler(this.SalesCdStAutoAns_tComboEditor_ValueChanged);
            // 
            // ultraLabel13
            // 
            appearance10.TextVAlignAsString = "Middle";
            this.ultraLabel13.Appearance = appearance10;
            this.ultraLabel13.Location = new System.Drawing.Point(16, 171);
            this.ultraLabel13.Name = "ultraLabel13";
            this.ultraLabel13.Size = new System.Drawing.Size(165, 24);
            this.ultraLabel13.TabIndex = 280;
            this.ultraLabel13.Text = "販売区分コード";
            // 
            // ultraLabel12
            // 
            appearance48.TextVAlignAsString = "Middle";
            this.ultraLabel12.Appearance = appearance48;
            this.ultraLabel12.Location = new System.Drawing.Point(16, 141);
            this.ultraLabel12.Name = "ultraLabel12";
            this.ultraLabel12.Size = new System.Drawing.Size(199, 24);
            this.ultraLabel12.TabIndex = 278;
            this.ultraLabel12.Text = "販売区分設定(自動回答時)";
            // 
            // SalesCode_tNedit
            // 
            appearance8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance8.ForeColor = System.Drawing.Color.Black;
            appearance8.TextHAlignAsString = "Right";
            this.SalesCode_tNedit.ActiveAppearance = appearance8;
            appearance9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance9.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance9.ForeColor = System.Drawing.Color.Black;
            appearance9.ForeColorDisabled = System.Drawing.Color.Black;
            appearance9.TextHAlignAsString = "Right";
            appearance9.TextVAlignAsString = "Middle";
            this.SalesCode_tNedit.Appearance = appearance9;
            this.SalesCode_tNedit.AutoSelect = true;
            this.SalesCode_tNedit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.SalesCode_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.SalesCode_tNedit.DataText = "";
            this.SalesCode_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.SalesCode_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 4, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.SalesCode_tNedit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.SalesCode_tNedit.Location = new System.Drawing.Point(221, 171);
            this.SalesCode_tNedit.MaxLength = 4;
            this.SalesCode_tNedit.Name = "SalesCode_tNedit";
            this.SalesCode_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsFILL);
            this.SalesCode_tNedit.Size = new System.Drawing.Size(74, 24);
            this.SalesCode_tNedit.TabIndex = 16;
            // 
            // uButton_SalesCode
            // 
            appearance127.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance127.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.uButton_SalesCode.Appearance = appearance127;
            this.uButton_SalesCode.Location = new System.Drawing.Point(306, 172);
            this.uButton_SalesCode.Name = "uButton_SalesCode";
            this.uButton_SalesCode.Size = new System.Drawing.Size(24, 23);
            this.uButton_SalesCode.TabIndex = 17;
            this.uButton_SalesCode.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.uButton_SalesCode.Click += new System.EventHandler(this.uButton_SalesCode_Click);
            // 
            // AutoAnsHourDspDiv_tComboEditor
            // 
            appearance52.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance52.ForeColor = System.Drawing.Color.Black;
            appearance52.TextVAlignAsString = "Middle";
            this.AutoAnsHourDspDiv_tComboEditor.ActiveAppearance = appearance52;
            appearance53.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance53.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance53.ForeColorDisabled = System.Drawing.Color.Black;
            this.AutoAnsHourDspDiv_tComboEditor.Appearance = appearance53;
            this.AutoAnsHourDspDiv_tComboEditor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.AutoAnsHourDspDiv_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.AutoAnsHourDspDiv_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance54.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.AutoAnsHourDspDiv_tComboEditor.ItemAppearance = appearance54;
            this.AutoAnsHourDspDiv_tComboEditor.Location = new System.Drawing.Point(221, 201);
            this.AutoAnsHourDspDiv_tComboEditor.Name = "AutoAnsHourDspDiv_tComboEditor";
            this.AutoAnsHourDspDiv_tComboEditor.Size = new System.Drawing.Size(224, 24);
            this.AutoAnsHourDspDiv_tComboEditor.TabIndex = 18;
            // 
            // AutoAnsHourDspDiv_uLabel
            // 
            appearance63.TextVAlignAsString = "Middle";
            this.AutoAnsHourDspDiv_uLabel.Appearance = appearance63;
            this.AutoAnsHourDspDiv_uLabel.Location = new System.Drawing.Point(16, 201);
            this.AutoAnsHourDspDiv_uLabel.Name = "AutoAnsHourDspDiv_uLabel";
            this.AutoAnsHourDspDiv_uLabel.Size = new System.Drawing.Size(165, 24);
            this.AutoAnsHourDspDiv_uLabel.TabIndex = 282;
            this.AutoAnsHourDspDiv_uLabel.Text = "自動回答時表示区分";
            // 
            // PMSCM09020UB
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 15);
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(713, 315);
            this.Controls.Add(this.AutoAnsHourDspDiv_tComboEditor);
            this.Controls.Add(this.AutoAnsHourDspDiv_uLabel);
            this.Controls.Add(this.uButton_SalesCode);
            this.Controls.Add(this.SalesCode_tNedit);
            this.Controls.Add(this.SalesCdStAutoAns_tComboEditor);
            this.Controls.Add(this.ultraLabel13);
            this.Controls.Add(this.ultraLabel12);
            this.Controls.Add(this.ultraLabel10);
            this.Controls.Add(this.ultraLabel9);
            this.Controls.Add(this.tEdit_RcvProcStInterval);
            this.Controls.Add(this.ultraLabel7);
            this.Controls.Add(this.tEdit_CashRegisterNo);
            this.Controls.Add(this.tEdit_CashRegisterNoNm);
            this.Controls.Add(this.Renewal_Button);
            this.Controls.Add(this.tEdit_SectionCodeAllowZero);
            this.Controls.Add(this.Delete_Button);
            this.Controls.Add(this.Revive_Button);
            this.Controls.Add(this.SectionGuide_Button);
            this.Controls.Add(this.ultraLabel6);
            this.Controls.Add(this.DivideLine_Label);
            this.Controls.Add(this.ultraStatusBar1);
            this.Controls.Add(this.SectionName_tEdit);
            this.Controls.Add(this.Section_uLabel);
            this.Controls.Add(this.Mode_Label);
            this.Controls.Add(this.Ok_Button);
            this.Controls.Add(this.Cancel_Button);
            this.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PMSCM09020UB";
            this.Text = "PCC全体設定";
            this.Load += new System.EventHandler(this.PMSCM09020UB_Load);
            this.VisibleChanged += new System.EventHandler(this.PMSCM09020UB_VisibleChanged);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.PMSCM09020UB_Closing);
            ((System.ComponentModel.ISupportInitialize)(this.SectionName_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bind_DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SectionCodeAllowZero)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_CashRegisterNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_CashRegisterNoNm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_RcvProcStInterval)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesCdStAutoAns_tComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesCode_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AutoAnsHourDspDiv_tComboEditor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

        private TComboEditor SalesCdStAutoAns_tComboEditor;
        private Infragistics.Win.Misc.UltraLabel ultraLabel13;
        private Infragistics.Win.Misc.UltraLabel ultraLabel12;
        private TNedit SalesCode_tNedit;
        private Infragistics.Win.Misc.UltraButton uButton_SalesCode;
        private TComboEditor AutoAnsHourDspDiv_tComboEditor;
        private Infragistics.Win.Misc.UltraLabel AutoAnsHourDspDiv_uLabel;
    }
}

using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Common;
using Infragistics.Win.Misc;

namespace Broadleaf.Windows.Forms
{
    public partial class PMKHN09601UB : System.Windows.Forms.Form
    {
        /// <summary>
        /// 必要なデザイナ変数です。
        /// </summary>
        private System.ComponentModel.IContainer components;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose( bool disposing )
        {
            if ( disposing && (components != null) )
            {
                components.Dispose();
            }
            base.Dispose( disposing );
        }

        #region Windows フォーム デザイナで生成されたコード

        /// <summary>
        /// デザイナ サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディタで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance37 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance38 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo4 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("拠点ガイド", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("メーカーガイド", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.Appearance appearance57 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo2 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("メーカーガイド", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.Appearance appearance60 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo3 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("メーカーガイド", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.Appearance appearance50 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance51 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance27 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance24 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance25 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance26 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem1 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem2 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem3 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem4 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance44 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance45 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance53 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance54 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance46 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance52 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance55 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance36 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance34 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance35 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance32 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance33 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance40 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance41 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance105 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance23 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance95 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance96 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance43 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance138 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance139 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance29 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PMKHN09601UB));
            this.tRetKeyControl1 = new Broadleaf.Library.Windows.Forms.TRetKeyControl(this.components);
            this.tArrowKeyControl1 = new Broadleaf.Library.Windows.Forms.TArrowKeyControl(this.components);
            this.ultraStatusBar1 = new Infragistics.Win.UltraWinStatusBar.UltraStatusBar();
            this.Delete_Button = new Infragistics.Win.Misc.UltraButton();
            this.Revive_Button = new Infragistics.Win.Misc.UltraButton();
            this.Ok_Button = new Infragistics.Win.Misc.UltraButton();
            this.Cancel_Button = new Infragistics.Win.Misc.UltraButton();
            this.SectionCode_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.Mode_Label = new Infragistics.Win.Misc.UltraLabel();
            this.tEdit_SectionGuideNm = new Broadleaf.Library.Windows.Forms.TEdit();
            this.Initial_Timer = new System.Windows.Forms.Timer(this.components);
            this.ultraToolTipManager1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipManager(this.components);
            this.uButton_Section = new Infragistics.Win.Misc.UltraButton();
            this.uButton_BLGoodsCode = new Infragistics.Win.Misc.UltraButton();
            this.uButton_GoodsMGroup = new Infragistics.Win.Misc.UltraButton();
            this.uButton_GoodsMakerCd = new Infragistics.Win.Misc.UltraButton();
            this.Button_Panel = new System.Windows.Forms.Panel();
            this.Renewal_Button = new Infragistics.Win.Misc.UltraButton();
            this.tEdit_SectionCodeAllowZero = new Broadleaf.Library.Windows.Forms.TEdit();
            this.uiSetControl1 = new Broadleaf.Library.Windows.Forms.UiSetControl(this.components);
            this.ultraLabel17 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.tComboEditor_SetKind = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.panel_Section = new System.Windows.Forms.Panel();
            this.ultraLabel7 = new Infragistics.Win.Misc.UltraLabel();
            this.tNedit_BLGoodsCode = new Broadleaf.Library.Windows.Forms.TNedit();
            this.tNedit_GoodsMGroup = new Broadleaf.Library.Windows.Forms.TNedit();
            this.ultraLabel11 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel8 = new Infragistics.Win.Misc.UltraLabel();
            this.tNedit_GoodsMakerCd = new Broadleaf.Library.Windows.Forms.TNedit();
            this.ultraLabel9 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel2 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel3 = new Infragistics.Win.Misc.UltraLabel();
            this.tEdit_GoodsMakerName = new Broadleaf.Library.Windows.Forms.TEdit();
            this.tEdit_GoodsMGroupName = new Broadleaf.Library.Windows.Forms.TEdit();
            this.tEdit_BLCodeName = new Broadleaf.Library.Windows.Forms.TEdit();
            this.ultraLabel5 = new Infragistics.Win.Misc.UltraLabel();
            this.tEdit_GoodsNo = new Broadleaf.Library.Windows.Forms.TEdit();
            this.tEdit_GoodsName_ReadOnly = new Broadleaf.Library.Windows.Forms.TEdit();
            this.panel_GoodsMaker = new System.Windows.Forms.Panel();
            this.panel_GoodsMGroup = new System.Windows.Forms.Panel();
            this.panel_BLCode = new System.Windows.Forms.Panel();
            this.panel_GoodsNo = new System.Windows.Forms.Panel();
            this.panel_Campaign = new System.Windows.Forms.Panel();
            this.tNedit_PriceFl = new Broadleaf.Library.Windows.Forms.TNedit();
            this.uButton_CampaignCode = new Infragistics.Win.Misc.UltraButton();
            this.ultraLabel12 = new Infragistics.Win.Misc.UltraLabel();
            this.tNedit_RateVal = new Broadleaf.Library.Windows.Forms.TNedit();
            this.tEdit_CampaignName = new Broadleaf.Library.Windows.Forms.TEdit();
            this.tNedit_CampaignCode = new Broadleaf.Library.Windows.Forms.TNedit();
            this.ultraLabel10 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel4 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel6 = new Infragistics.Win.Misc.UltraLabel();
            this.panel_SetKind = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SectionGuideNm)).BeginInit();
            this.Button_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SectionCodeAllowZero)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_SetKind)).BeginInit();
            this.panel_Section.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_BLGoodsCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_GoodsMGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_GoodsMakerCd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_GoodsMakerName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_GoodsMGroupName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_BLCodeName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_GoodsNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_GoodsName_ReadOnly)).BeginInit();
            this.panel_GoodsMaker.SuspendLayout();
            this.panel_GoodsMGroup.SuspendLayout();
            this.panel_BLCode.SuspendLayout();
            this.panel_GoodsNo.SuspendLayout();
            this.panel_Campaign.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_PriceFl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_RateVal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_CampaignName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_CampaignCode)).BeginInit();
            this.panel_SetKind.SuspendLayout();
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
            this.ultraStatusBar1.Location = new System.Drawing.Point(0, 375);
            this.ultraStatusBar1.Name = "ultraStatusBar1";
            this.ultraStatusBar1.Size = new System.Drawing.Size(729, 23);
            this.ultraStatusBar1.TabIndex = 46;
            this.ultraStatusBar1.ViewStyle = Infragistics.Win.UltraWinStatusBar.ViewStyle.Office2003;
            // 
            // Delete_Button
            // 
            this.Delete_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Delete_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Delete_Button.Location = new System.Drawing.Point(211, 10);
            this.Delete_Button.Margin = new System.Windows.Forms.Padding(1);
            this.Delete_Button.Name = "Delete_Button";
            this.Delete_Button.Size = new System.Drawing.Size(125, 34);
            this.Delete_Button.TabIndex = 8;
            this.Delete_Button.Text = "完全削除(&D)";
            this.Delete_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Delete_Button.Click += new System.EventHandler(this.Delete_Button_Click);
            // 
            // Revive_Button
            // 
            this.Revive_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Revive_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Revive_Button.Location = new System.Drawing.Point(338, 10);
            this.Revive_Button.Margin = new System.Windows.Forms.Padding(1);
            this.Revive_Button.Name = "Revive_Button";
            this.Revive_Button.Size = new System.Drawing.Size(125, 34);
            this.Revive_Button.TabIndex = 9;
            this.Revive_Button.Text = "復活(&R)";
            this.Revive_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Revive_Button.Click += new System.EventHandler(this.Revive_Button_Click);
            // 
            // Ok_Button
            // 
            this.Ok_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Ok_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Ok_Button.Location = new System.Drawing.Point(465, 10);
            this.Ok_Button.Margin = new System.Windows.Forms.Padding(1);
            this.Ok_Button.Name = "Ok_Button";
            this.Ok_Button.Size = new System.Drawing.Size(125, 34);
            this.Ok_Button.TabIndex = 10;
            this.Ok_Button.Text = "保存(&S)";
            this.Ok_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Ok_Button.Click += new System.EventHandler(this.Ok_Button_Click);
            // 
            // Cancel_Button
            // 
            this.Cancel_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Cancel_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Cancel_Button.Location = new System.Drawing.Point(592, 10);
            this.Cancel_Button.Margin = new System.Windows.Forms.Padding(1);
            this.Cancel_Button.Name = "Cancel_Button";
            this.Cancel_Button.Size = new System.Drawing.Size(125, 34);
            this.Cancel_Button.TabIndex = 11;
            this.Cancel_Button.Text = "閉じる(&X)";
            this.Cancel_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Cancel_Button.Click += new System.EventHandler(this.Cancel_Button_Click);
            // 
            // SectionCode_Title_Label
            // 
            appearance1.BackColor = System.Drawing.Color.Transparent;
            appearance1.ForeColorDisabled = System.Drawing.Color.Black;
            appearance1.TextHAlignAsString = "Left";
            appearance1.TextVAlignAsString = "Middle";
            this.SectionCode_Title_Label.Appearance = appearance1;
            this.SectionCode_Title_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.SectionCode_Title_Label.Location = new System.Drawing.Point(0, 0);
            this.SectionCode_Title_Label.Margin = new System.Windows.Forms.Padding(1);
            this.SectionCode_Title_Label.Name = "SectionCode_Title_Label";
            this.SectionCode_Title_Label.Size = new System.Drawing.Size(124, 24);
            this.SectionCode_Title_Label.TabIndex = 4;
            this.SectionCode_Title_Label.Text = "拠点";
            // 
            // Mode_Label
            // 
            this.Mode_Label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            appearance11.ForeColor = System.Drawing.Color.White;
            appearance11.TextHAlignAsString = "Center";
            appearance11.TextVAlignAsString = "Middle";
            this.Mode_Label.Appearance = appearance11;
            this.Mode_Label.BackColorInternal = System.Drawing.Color.Navy;
            this.Mode_Label.Location = new System.Drawing.Point(624, 5);
            this.Mode_Label.Name = "Mode_Label";
            this.Mode_Label.Size = new System.Drawing.Size(100, 23);
            this.Mode_Label.TabIndex = 23;
            this.Mode_Label.Text = "更新モード";
            // 
            // tEdit_SectionGuideNm
            // 
            appearance37.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance37.ForeColor = System.Drawing.Color.Black;
            appearance37.TextVAlignAsString = "Middle";
            this.tEdit_SectionGuideNm.ActiveAppearance = appearance37;
            appearance38.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance38.ForeColor = System.Drawing.Color.Black;
            appearance38.ForeColorDisabled = System.Drawing.Color.Black;
            appearance38.TextVAlignAsString = "Middle";
            this.tEdit_SectionGuideNm.Appearance = appearance38;
            this.tEdit_SectionGuideNm.AutoSelect = true;
            this.tEdit_SectionGuideNm.DataText = "";
            this.tEdit_SectionGuideNm.Enabled = false;
            this.tEdit_SectionGuideNm.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_SectionGuideNm.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 10, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.tEdit_SectionGuideNm.Location = new System.Drawing.Point(166, 0);
            this.tEdit_SectionGuideNm.Margin = new System.Windows.Forms.Padding(1);
            this.tEdit_SectionGuideNm.MaxLength = 10;
            this.tEdit_SectionGuideNm.Name = "tEdit_SectionGuideNm";
            this.tEdit_SectionGuideNm.ReadOnly = true;
            this.tEdit_SectionGuideNm.Size = new System.Drawing.Size(179, 24);
            this.tEdit_SectionGuideNm.TabIndex = 6;
            // 
            // Initial_Timer
            // 
            this.Initial_Timer.Interval = 1;
            this.Initial_Timer.Tick += new System.EventHandler(this.Initial_Timer_Tick);
            // 
            // ultraToolTipManager1
            // 
            this.ultraToolTipManager1.ContainingControl = this;
            this.ultraToolTipManager1.DisplayStyle = Infragistics.Win.ToolTipDisplayStyle.Standard;
            // 
            // uButton_Section
            // 
            this.uButton_Section.BackColorInternal = System.Drawing.Color.Transparent;
            this.uButton_Section.Location = new System.Drawing.Point(347, 0);
            this.uButton_Section.Margin = new System.Windows.Forms.Padding(1);
            this.uButton_Section.Name = "uButton_Section";
            this.uButton_Section.Size = new System.Drawing.Size(24, 24);
            this.uButton_Section.TabIndex = 1;
            ultraToolTipInfo4.ToolTipText = "拠点ガイド";
            this.ultraToolTipManager1.SetUltraToolTip(this.uButton_Section, ultraToolTipInfo4);
            this.uButton_Section.Click += new System.EventHandler(this.SectionGuide_ultraButton_Click);
            // 
            // uButton_BLGoodsCode
            // 
            appearance5.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance5.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.uButton_BLGoodsCode.Appearance = appearance5;
            this.uButton_BLGoodsCode.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uButton_BLGoodsCode.Location = new System.Drawing.Point(370, 0);
            this.uButton_BLGoodsCode.Name = "uButton_BLGoodsCode";
            this.uButton_BLGoodsCode.Size = new System.Drawing.Size(24, 24);
            this.uButton_BLGoodsCode.TabIndex = 1;
            ultraToolTipInfo1.ToolTipText = "メーカーガイド";
            this.ultraToolTipManager1.SetUltraToolTip(this.uButton_BLGoodsCode, ultraToolTipInfo1);
            this.uButton_BLGoodsCode.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.uButton_BLGoodsCode.Click += new System.EventHandler(this.uButton_BLGoodsCode_Click);
            // 
            // uButton_GoodsMGroup
            // 
            appearance57.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance57.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.uButton_GoodsMGroup.Appearance = appearance57;
            this.uButton_GoodsMGroup.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uButton_GoodsMGroup.Location = new System.Drawing.Point(362, 0);
            this.uButton_GoodsMGroup.Name = "uButton_GoodsMGroup";
            this.uButton_GoodsMGroup.Size = new System.Drawing.Size(24, 24);
            this.uButton_GoodsMGroup.TabIndex = 1;
            ultraToolTipInfo2.ToolTipText = "メーカーガイド";
            this.ultraToolTipManager1.SetUltraToolTip(this.uButton_GoodsMGroup, ultraToolTipInfo2);
            this.uButton_GoodsMGroup.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.uButton_GoodsMGroup.Click += new System.EventHandler(this.uButton_GoodsMGroup_Click);
            // 
            // uButton_GoodsMakerCd
            // 
            appearance60.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance60.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.uButton_GoodsMakerCd.Appearance = appearance60;
            this.uButton_GoodsMakerCd.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uButton_GoodsMakerCd.Location = new System.Drawing.Point(362, 0);
            this.uButton_GoodsMakerCd.Name = "uButton_GoodsMakerCd";
            this.uButton_GoodsMakerCd.Size = new System.Drawing.Size(24, 24);
            this.uButton_GoodsMakerCd.TabIndex = 1;
            ultraToolTipInfo3.ToolTipText = "メーカーガイド";
            this.ultraToolTipManager1.SetUltraToolTip(this.uButton_GoodsMakerCd, ultraToolTipInfo3);
            this.uButton_GoodsMakerCd.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.uButton_GoodsMakerCd.Click += new System.EventHandler(this.uButton_GoodsMakerCd_Click);
            // 
            // Button_Panel
            // 
            this.Button_Panel.Controls.Add(this.Renewal_Button);
            this.Button_Panel.Controls.Add(this.Cancel_Button);
            this.Button_Panel.Controls.Add(this.Delete_Button);
            this.Button_Panel.Controls.Add(this.Revive_Button);
            this.Button_Panel.Controls.Add(this.Ok_Button);
            this.Button_Panel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Button_Panel.Location = new System.Drawing.Point(0, 321);
            this.Button_Panel.Name = "Button_Panel";
            this.Button_Panel.Size = new System.Drawing.Size(729, 54);
            this.Button_Panel.TabIndex = 8;
            // 
            // Renewal_Button
            // 
            this.Renewal_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Renewal_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Renewal_Button.Location = new System.Drawing.Point(338, 10);
            this.Renewal_Button.Margin = new System.Windows.Forms.Padding(1);
            this.Renewal_Button.Name = "Renewal_Button";
            this.Renewal_Button.Size = new System.Drawing.Size(125, 34);
            this.Renewal_Button.TabIndex = 9;
            this.Renewal_Button.Text = "最新情報(&I)";
            this.Renewal_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Renewal_Button.Click += new System.EventHandler(this.Renewal_Button_Click);
            // 
            // tEdit_SectionCodeAllowZero
            // 
            appearance50.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_SectionCodeAllowZero.ActiveAppearance = appearance50;
            appearance51.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance51.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance51.ForeColorDisabled = System.Drawing.Color.Black;
            this.tEdit_SectionCodeAllowZero.Appearance = appearance51;
            this.tEdit_SectionCodeAllowZero.AutoSelect = true;
            this.tEdit_SectionCodeAllowZero.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tEdit_SectionCodeAllowZero.DataText = "";
            this.tEdit_SectionCodeAllowZero.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_SectionCodeAllowZero.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 2, new Broadleaf.Library.Windows.Forms.TEnableChars(false, true, true, false, true, true, true));
            this.tEdit_SectionCodeAllowZero.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.tEdit_SectionCodeAllowZero.Location = new System.Drawing.Point(136, 0);
            this.tEdit_SectionCodeAllowZero.Margin = new System.Windows.Forms.Padding(1);
            this.tEdit_SectionCodeAllowZero.MaxLength = 2;
            this.tEdit_SectionCodeAllowZero.Name = "tEdit_SectionCodeAllowZero";
            this.tEdit_SectionCodeAllowZero.Size = new System.Drawing.Size(28, 24);
            this.tEdit_SectionCodeAllowZero.TabIndex = 0;
            // 
            // uiSetControl1
            // 
            this.uiSetControl1.EditWidthSettingWay = Broadleaf.Library.Windows.Forms.UiSetControl.EditWidthSettingWayState.None;
            this.uiSetControl1.OwnerForm = this;
            this.uiSetControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tArrowKeyControl1_ChangeFocus);
            // 
            // ultraLabel17
            // 
            this.ultraLabel17.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ultraLabel17.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel17.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Inset;
            this.ultraLabel17.Location = new System.Drawing.Point(12, 62);
            this.ultraLabel17.Name = "ultraLabel17";
            this.ultraLabel17.Size = new System.Drawing.Size(701, 3);
            this.ultraLabel17.TabIndex = 170;
            // 
            // ultraLabel1
            // 
            appearance27.ForeColorDisabled = System.Drawing.Color.Black;
            appearance27.TextHAlignAsString = "Left";
            appearance27.TextVAlignAsString = "Middle";
            this.ultraLabel1.Appearance = appearance27;
            this.ultraLabel1.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel1.Location = new System.Drawing.Point(0, 1);
            this.ultraLabel1.Margin = new System.Windows.Forms.Padding(1);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(130, 24);
            this.ultraLabel1.TabIndex = 172;
            this.ultraLabel1.Text = "設定種別";
            // 
            // tComboEditor_SetKind
            // 
            appearance24.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_SetKind.ActiveAppearance = appearance24;
            appearance25.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance25.ForeColorDisabled = System.Drawing.Color.Black;
            appearance25.TextVAlignAsString = "Middle";
            this.tComboEditor_SetKind.Appearance = appearance25;
            this.tComboEditor_SetKind.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tComboEditor_SetKind.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.tComboEditor_SetKind.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance26.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_SetKind.ItemAppearance = appearance26;
            valueListItem1.DataValue = 0;
            valueListItem1.DisplayText = "メーカー";
            valueListItem2.DataValue = 1;
            valueListItem2.DisplayText = "メーカー＋商品中分類";
            valueListItem3.DataValue = 2;
            valueListItem3.DisplayText = "メーカー＋ＢＬコード";
            valueListItem4.DataValue = 3;
            valueListItem4.DisplayText = "メーカー＋品番";
            this.tComboEditor_SetKind.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem1,
            valueListItem2,
            valueListItem3,
            valueListItem4});
            this.tComboEditor_SetKind.Location = new System.Drawing.Point(136, 1);
            this.tComboEditor_SetKind.Name = "tComboEditor_SetKind";
            this.tComboEditor_SetKind.Size = new System.Drawing.Size(250, 24);
            this.tComboEditor_SetKind.TabIndex = 1;
            this.tComboEditor_SetKind.Text = "メーカー";
            this.tComboEditor_SetKind.ValueChanged += new System.EventHandler(this.tComboEditor_SetKind_ValueChanged);
            // 
            // panel_Section
            // 
            this.panel_Section.Controls.Add(this.ultraLabel7);
            this.panel_Section.Controls.Add(this.SectionCode_Title_Label);
            this.panel_Section.Controls.Add(this.tEdit_SectionGuideNm);
            this.panel_Section.Controls.Add(this.uButton_Section);
            this.panel_Section.Controls.Add(this.tEdit_SectionCodeAllowZero);
            this.panel_Section.Location = new System.Drawing.Point(12, 71);
            this.panel_Section.Name = "panel_Section";
            this.panel_Section.Size = new System.Drawing.Size(701, 24);
            this.panel_Section.TabIndex = 1;
            // 
            // ultraLabel7
            // 
            appearance21.BackColor = System.Drawing.Color.Transparent;
            appearance21.ForeColorDisabled = System.Drawing.Color.Black;
            appearance21.TextHAlignAsString = "Left";
            appearance21.TextVAlignAsString = "Middle";
            this.ultraLabel7.Appearance = appearance21;
            this.ultraLabel7.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel7.Location = new System.Drawing.Point(393, 0);
            this.ultraLabel7.Margin = new System.Windows.Forms.Padding(1);
            this.ultraLabel7.Name = "ultraLabel7";
            this.ultraLabel7.Size = new System.Drawing.Size(277, 24);
            this.ultraLabel7.TabIndex = 7;
            this.ultraLabel7.Text = "※ゼロで共通設定になります。";
            // 
            // tNedit_BLGoodsCode
            // 
            appearance44.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tNedit_BLGoodsCode.ActiveAppearance = appearance44;
            appearance45.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance45.ForeColor = System.Drawing.Color.Black;
            appearance45.ForeColorDisabled = System.Drawing.Color.Black;
            appearance45.TextHAlignAsString = "Right";
            this.tNedit_BLGoodsCode.Appearance = appearance45;
            this.tNedit_BLGoodsCode.AutoSelect = true;
            this.tNedit_BLGoodsCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tNedit_BLGoodsCode.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_BLGoodsCode.DataText = "";
            this.tNedit_BLGoodsCode.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_BLGoodsCode.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 5, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_BLGoodsCode.Font = new System.Drawing.Font("ＭＳ ゴシック", 11F);
            this.tNedit_BLGoodsCode.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tNedit_BLGoodsCode.Location = new System.Drawing.Point(136, 0);
            this.tNedit_BLGoodsCode.MaxLength = 5;
            this.tNedit_BLGoodsCode.Name = "tNedit_BLGoodsCode";
            this.tNedit_BLGoodsCode.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, false, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.tNedit_BLGoodsCode.Size = new System.Drawing.Size(51, 24);
            this.tNedit_BLGoodsCode.TabIndex = 0;
            // 
            // tNedit_GoodsMGroup
            // 
            appearance53.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tNedit_GoodsMGroup.ActiveAppearance = appearance53;
            appearance54.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance54.ForeColor = System.Drawing.Color.Black;
            appearance54.ForeColorDisabled = System.Drawing.Color.Black;
            appearance54.TextHAlignAsString = "Right";
            this.tNedit_GoodsMGroup.Appearance = appearance54;
            this.tNedit_GoodsMGroup.AutoSelect = true;
            this.tNedit_GoodsMGroup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tNedit_GoodsMGroup.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_GoodsMGroup.DataText = "";
            this.tNedit_GoodsMGroup.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_GoodsMGroup.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 4, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_GoodsMGroup.Font = new System.Drawing.Font("ＭＳ ゴシック", 11F);
            this.tNedit_GoodsMGroup.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tNedit_GoodsMGroup.Location = new System.Drawing.Point(136, 0);
            this.tNedit_GoodsMGroup.MaxLength = 4;
            this.tNedit_GoodsMGroup.Name = "tNedit_GoodsMGroup";
            this.tNedit_GoodsMGroup.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, false, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.tNedit_GoodsMGroup.Size = new System.Drawing.Size(43, 24);
            this.tNedit_GoodsMGroup.TabIndex = 0;
            // 
            // ultraLabel11
            // 
            appearance46.BackColor = System.Drawing.Color.Transparent;
            appearance46.ForeColorDisabled = System.Drawing.Color.Black;
            appearance46.TextVAlignAsString = "Middle";
            this.ultraLabel11.Appearance = appearance46;
            this.ultraLabel11.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel11.Location = new System.Drawing.Point(0, 0);
            this.ultraLabel11.Margin = new System.Windows.Forms.Padding(1);
            this.ultraLabel11.Name = "ultraLabel11";
            this.ultraLabel11.Size = new System.Drawing.Size(124, 24);
            this.ultraLabel11.TabIndex = 957;
            this.ultraLabel11.Text = "ＢＬコード";
            // 
            // ultraLabel8
            // 
            appearance18.BackColor = System.Drawing.Color.Transparent;
            appearance18.ForeColorDisabled = System.Drawing.Color.Black;
            appearance18.TextVAlignAsString = "Middle";
            this.ultraLabel8.Appearance = appearance18;
            this.ultraLabel8.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel8.Location = new System.Drawing.Point(0, 0);
            this.ultraLabel8.Margin = new System.Windows.Forms.Padding(1);
            this.ultraLabel8.Name = "ultraLabel8";
            this.ultraLabel8.Size = new System.Drawing.Size(124, 24);
            this.ultraLabel8.TabIndex = 955;
            this.ultraLabel8.Text = "商品中分類";
            // 
            // tNedit_GoodsMakerCd
            // 
            appearance52.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tNedit_GoodsMakerCd.ActiveAppearance = appearance52;
            appearance55.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance55.ForeColor = System.Drawing.Color.Black;
            appearance55.ForeColorDisabled = System.Drawing.Color.Black;
            appearance55.TextHAlignAsString = "Right";
            this.tNedit_GoodsMakerCd.Appearance = appearance55;
            this.tNedit_GoodsMakerCd.AutoSelect = true;
            this.tNedit_GoodsMakerCd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tNedit_GoodsMakerCd.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_GoodsMakerCd.DataText = "";
            this.tNedit_GoodsMakerCd.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_GoodsMakerCd.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 4, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_GoodsMakerCd.Font = new System.Drawing.Font("ＭＳ ゴシック", 11F);
            this.tNedit_GoodsMakerCd.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tNedit_GoodsMakerCd.Location = new System.Drawing.Point(136, 0);
            this.tNedit_GoodsMakerCd.MaxLength = 4;
            this.tNedit_GoodsMakerCd.Name = "tNedit_GoodsMakerCd";
            this.tNedit_GoodsMakerCd.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, false, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.tNedit_GoodsMakerCd.Size = new System.Drawing.Size(43, 24);
            this.tNedit_GoodsMakerCd.TabIndex = 0;
            // 
            // ultraLabel9
            // 
            appearance36.BackColor = System.Drawing.Color.Transparent;
            appearance36.ForeColorDisabled = System.Drawing.Color.Black;
            appearance36.TextVAlignAsString = "Middle";
            this.ultraLabel9.Appearance = appearance36;
            this.ultraLabel9.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel9.Location = new System.Drawing.Point(0, 0);
            this.ultraLabel9.Margin = new System.Windows.Forms.Padding(1);
            this.ultraLabel9.Name = "ultraLabel9";
            this.ultraLabel9.Size = new System.Drawing.Size(124, 24);
            this.ultraLabel9.TabIndex = 954;
            this.ultraLabel9.Text = "メーカー";
            // 
            // ultraLabel2
            // 
            this.ultraLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ultraLabel2.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel2.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Inset;
            this.ultraLabel2.Location = new System.Drawing.Point(0, 11);
            this.ultraLabel2.Name = "ultraLabel2";
            this.ultraLabel2.Size = new System.Drawing.Size(701, 3);
            this.ultraLabel2.TabIndex = 958;
            // 
            // ultraLabel3
            // 
            appearance14.ForeColorDisabled = System.Drawing.Color.Black;
            appearance14.TextHAlignAsString = "Left";
            appearance14.TextVAlignAsString = "Middle";
            this.ultraLabel3.Appearance = appearance14;
            this.ultraLabel3.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel3.Location = new System.Drawing.Point(0, 23);
            this.ultraLabel3.Margin = new System.Windows.Forms.Padding(1);
            this.ultraLabel3.Name = "ultraLabel3";
            this.ultraLabel3.Size = new System.Drawing.Size(130, 24);
            this.ultraLabel3.TabIndex = 959;
            this.ultraLabel3.Text = "ｷｬﾝﾍﾟｰﾝｺｰﾄﾞ";
            // 
            // tEdit_GoodsMakerName
            // 
            appearance34.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance34.ForeColor = System.Drawing.Color.Black;
            appearance34.TextVAlignAsString = "Middle";
            this.tEdit_GoodsMakerName.ActiveAppearance = appearance34;
            appearance35.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance35.ForeColor = System.Drawing.Color.Black;
            appearance35.ForeColorDisabled = System.Drawing.Color.Black;
            appearance35.TextVAlignAsString = "Middle";
            this.tEdit_GoodsMakerName.Appearance = appearance35;
            this.tEdit_GoodsMakerName.AutoSelect = true;
            this.tEdit_GoodsMakerName.DataText = "";
            this.tEdit_GoodsMakerName.Enabled = false;
            this.tEdit_GoodsMakerName.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_GoodsMakerName.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 10, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.tEdit_GoodsMakerName.Location = new System.Drawing.Point(181, 0);
            this.tEdit_GoodsMakerName.Margin = new System.Windows.Forms.Padding(1);
            this.tEdit_GoodsMakerName.MaxLength = 10;
            this.tEdit_GoodsMakerName.Name = "tEdit_GoodsMakerName";
            this.tEdit_GoodsMakerName.ReadOnly = true;
            this.tEdit_GoodsMakerName.Size = new System.Drawing.Size(179, 24);
            this.tEdit_GoodsMakerName.TabIndex = 8;
            // 
            // tEdit_GoodsMGroupName
            // 
            appearance32.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance32.ForeColor = System.Drawing.Color.Black;
            appearance32.TextVAlignAsString = "Middle";
            this.tEdit_GoodsMGroupName.ActiveAppearance = appearance32;
            appearance33.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance33.ForeColor = System.Drawing.Color.Black;
            appearance33.ForeColorDisabled = System.Drawing.Color.Black;
            appearance33.TextVAlignAsString = "Middle";
            this.tEdit_GoodsMGroupName.Appearance = appearance33;
            this.tEdit_GoodsMGroupName.AutoSelect = true;
            this.tEdit_GoodsMGroupName.DataText = "";
            this.tEdit_GoodsMGroupName.Enabled = false;
            this.tEdit_GoodsMGroupName.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_GoodsMGroupName.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 10, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.tEdit_GoodsMGroupName.Location = new System.Drawing.Point(181, 0);
            this.tEdit_GoodsMGroupName.Margin = new System.Windows.Forms.Padding(1);
            this.tEdit_GoodsMGroupName.MaxLength = 10;
            this.tEdit_GoodsMGroupName.Name = "tEdit_GoodsMGroupName";
            this.tEdit_GoodsMGroupName.ReadOnly = true;
            this.tEdit_GoodsMGroupName.Size = new System.Drawing.Size(179, 24);
            this.tEdit_GoodsMGroupName.TabIndex = 961;
            // 
            // tEdit_BLCodeName
            // 
            appearance40.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance40.ForeColor = System.Drawing.Color.Black;
            appearance40.TextVAlignAsString = "Middle";
            this.tEdit_BLCodeName.ActiveAppearance = appearance40;
            appearance41.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance41.ForeColor = System.Drawing.Color.Black;
            appearance41.ForeColorDisabled = System.Drawing.Color.Black;
            appearance41.TextVAlignAsString = "Middle";
            this.tEdit_BLCodeName.Appearance = appearance41;
            this.tEdit_BLCodeName.AutoSelect = true;
            this.tEdit_BLCodeName.DataText = "";
            this.tEdit_BLCodeName.Enabled = false;
            this.tEdit_BLCodeName.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_BLCodeName.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 10, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.tEdit_BLCodeName.Location = new System.Drawing.Point(189, 0);
            this.tEdit_BLCodeName.Margin = new System.Windows.Forms.Padding(1);
            this.tEdit_BLCodeName.MaxLength = 10;
            this.tEdit_BLCodeName.Name = "tEdit_BLCodeName";
            this.tEdit_BLCodeName.ReadOnly = true;
            this.tEdit_BLCodeName.Size = new System.Drawing.Size(179, 24);
            this.tEdit_BLCodeName.TabIndex = 963;
            // 
            // ultraLabel5
            // 
            appearance105.BackColor = System.Drawing.Color.Transparent;
            appearance105.ForeColorDisabled = System.Drawing.Color.Black;
            appearance105.TextVAlignAsString = "Middle";
            this.ultraLabel5.Appearance = appearance105;
            this.ultraLabel5.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel5.Location = new System.Drawing.Point(0, 0);
            this.ultraLabel5.Margin = new System.Windows.Forms.Padding(1);
            this.ultraLabel5.Name = "ultraLabel5";
            this.ultraLabel5.Size = new System.Drawing.Size(124, 24);
            this.ultraLabel5.TabIndex = 964;
            this.ultraLabel5.Text = "品番";
            // 
            // tEdit_GoodsNo
            // 
            appearance22.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_GoodsNo.ActiveAppearance = appearance22;
            appearance23.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance23.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance23.ForeColorDisabled = System.Drawing.Color.Black;
            this.tEdit_GoodsNo.Appearance = appearance23;
            this.tEdit_GoodsNo.AutoSelect = true;
            this.tEdit_GoodsNo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tEdit_GoodsNo.DataText = "";
            this.tEdit_GoodsNo.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_GoodsNo.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 24, new Broadleaf.Library.Windows.Forms.TEnableChars(false, true, true, false, true, true, true));
            this.tEdit_GoodsNo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.tEdit_GoodsNo.Location = new System.Drawing.Point(136, 0);
            this.tEdit_GoodsNo.Margin = new System.Windows.Forms.Padding(1);
            this.tEdit_GoodsNo.MaxLength = 24;
            this.tEdit_GoodsNo.Name = "tEdit_GoodsNo";
            this.tEdit_GoodsNo.Size = new System.Drawing.Size(203, 24);
            this.tEdit_GoodsNo.TabIndex = 0;
            // 
            // tEdit_GoodsName_ReadOnly
            // 
            appearance3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance3.ForeColor = System.Drawing.Color.Black;
            appearance3.TextVAlignAsString = "Middle";
            this.tEdit_GoodsName_ReadOnly.ActiveAppearance = appearance3;
            appearance20.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance20.ForeColor = System.Drawing.Color.Black;
            appearance20.ForeColorDisabled = System.Drawing.Color.Black;
            appearance20.TextVAlignAsString = "Middle";
            this.tEdit_GoodsName_ReadOnly.Appearance = appearance20;
            this.tEdit_GoodsName_ReadOnly.AutoSelect = true;
            this.tEdit_GoodsName_ReadOnly.DataText = "";
            this.tEdit_GoodsName_ReadOnly.Enabled = false;
            this.tEdit_GoodsName_ReadOnly.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_GoodsName_ReadOnly.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 40, new Broadleaf.Library.Windows.Forms.TEnableChars(false, true, true, false, true, true, true));
            this.tEdit_GoodsName_ReadOnly.Location = new System.Drawing.Point(341, 0);
            this.tEdit_GoodsName_ReadOnly.Margin = new System.Windows.Forms.Padding(1);
            this.tEdit_GoodsName_ReadOnly.MaxLength = 40;
            this.tEdit_GoodsName_ReadOnly.Name = "tEdit_GoodsName_ReadOnly";
            this.tEdit_GoodsName_ReadOnly.ReadOnly = true;
            this.tEdit_GoodsName_ReadOnly.Size = new System.Drawing.Size(329, 24);
            this.tEdit_GoodsName_ReadOnly.TabIndex = 966;
            // 
            // panel_GoodsMaker
            // 
            this.panel_GoodsMaker.Controls.Add(this.ultraLabel9);
            this.panel_GoodsMaker.Controls.Add(this.uButton_GoodsMakerCd);
            this.panel_GoodsMaker.Controls.Add(this.tNedit_GoodsMakerCd);
            this.panel_GoodsMaker.Controls.Add(this.tEdit_GoodsMakerName);
            this.panel_GoodsMaker.Location = new System.Drawing.Point(12, 110);
            this.panel_GoodsMaker.Name = "panel_GoodsMaker";
            this.panel_GoodsMaker.Size = new System.Drawing.Size(409, 24);
            this.panel_GoodsMaker.TabIndex = 3;
            // 
            // panel_GoodsMGroup
            // 
            this.panel_GoodsMGroup.Controls.Add(this.ultraLabel8);
            this.panel_GoodsMGroup.Controls.Add(this.uButton_GoodsMGroup);
            this.panel_GoodsMGroup.Controls.Add(this.tNedit_GoodsMGroup);
            this.panel_GoodsMGroup.Controls.Add(this.tEdit_GoodsMGroupName);
            this.panel_GoodsMGroup.Location = new System.Drawing.Point(12, 135);
            this.panel_GoodsMGroup.Name = "panel_GoodsMGroup";
            this.panel_GoodsMGroup.Size = new System.Drawing.Size(409, 24);
            this.panel_GoodsMGroup.TabIndex = 4;
            // 
            // panel_BLCode
            // 
            this.panel_BLCode.Controls.Add(this.ultraLabel11);
            this.panel_BLCode.Controls.Add(this.uButton_BLGoodsCode);
            this.panel_BLCode.Controls.Add(this.tNedit_BLGoodsCode);
            this.panel_BLCode.Controls.Add(this.tEdit_BLCodeName);
            this.panel_BLCode.Location = new System.Drawing.Point(12, 160);
            this.panel_BLCode.Name = "panel_BLCode";
            this.panel_BLCode.Size = new System.Drawing.Size(409, 24);
            this.panel_BLCode.TabIndex = 5;
            // 
            // panel_GoodsNo
            // 
            this.panel_GoodsNo.Controls.Add(this.tEdit_GoodsNo);
            this.panel_GoodsNo.Controls.Add(this.ultraLabel5);
            this.panel_GoodsNo.Controls.Add(this.tEdit_GoodsName_ReadOnly);
            this.panel_GoodsNo.Location = new System.Drawing.Point(12, 185);
            this.panel_GoodsNo.Name = "panel_GoodsNo";
            this.panel_GoodsNo.Size = new System.Drawing.Size(701, 24);
            this.panel_GoodsNo.TabIndex = 6;
            // 
            // panel_Campaign
            // 
            this.panel_Campaign.Controls.Add(this.tNedit_PriceFl);
            this.panel_Campaign.Controls.Add(this.uButton_CampaignCode);
            this.panel_Campaign.Controls.Add(this.ultraLabel12);
            this.panel_Campaign.Controls.Add(this.tNedit_RateVal);
            this.panel_Campaign.Controls.Add(this.tEdit_CampaignName);
            this.panel_Campaign.Controls.Add(this.tNedit_CampaignCode);
            this.panel_Campaign.Controls.Add(this.ultraLabel10);
            this.panel_Campaign.Controls.Add(this.ultraLabel4);
            this.panel_Campaign.Controls.Add(this.ultraLabel3);
            this.panel_Campaign.Controls.Add(this.ultraLabel2);
            this.panel_Campaign.Location = new System.Drawing.Point(12, 215);
            this.panel_Campaign.Name = "panel_Campaign";
            this.panel_Campaign.Size = new System.Drawing.Size(701, 107);
            this.panel_Campaign.TabIndex = 7;
            // 
            // tNedit_PriceFl
            // 
            appearance95.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance95.ForeColor = System.Drawing.Color.Black;
            appearance95.TextHAlignAsString = "Right";
            this.tNedit_PriceFl.ActiveAppearance = appearance95;
            appearance96.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance96.ForeColor = System.Drawing.Color.Black;
            appearance96.ForeColorDisabled = System.Drawing.Color.Black;
            appearance96.TextHAlignAsString = "Right";
            appearance96.TextVAlignAsString = "Middle";
            this.tNedit_PriceFl.Appearance = appearance96;
            this.tNedit_PriceFl.AutoSelect = true;
            this.tNedit_PriceFl.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_PriceFl.DataText = "";
            this.tNedit_PriceFl.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_PriceFl.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 16, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.tNedit_PriceFl.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.tNedit_PriceFl.Location = new System.Drawing.Point(136, 76);
            this.tNedit_PriceFl.MaxLength = 16;
            this.tNedit_PriceFl.Name = "tNedit_PriceFl";
            this.tNedit_PriceFl.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 2, true, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.tNedit_PriceFl.Size = new System.Drawing.Size(144, 24);
            this.tNedit_PriceFl.TabIndex = 3;
            // 
            // uButton_CampaignCode
            // 
            appearance43.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance43.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.uButton_CampaignCode.Appearance = appearance43;
            this.uButton_CampaignCode.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uButton_CampaignCode.Location = new System.Drawing.Point(671, 23);
            this.uButton_CampaignCode.Name = "uButton_CampaignCode";
            this.uButton_CampaignCode.Size = new System.Drawing.Size(24, 24);
            this.uButton_CampaignCode.TabIndex = 1;
            this.uButton_CampaignCode.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.uButton_CampaignCode.Click += new System.EventHandler(this.uButton_CampaignCode_Click);
            // 
            // ultraLabel12
            // 
            appearance13.TextVAlignAsString = "Middle";
            this.ultraLabel12.Appearance = appearance13;
            this.ultraLabel12.Location = new System.Drawing.Point(232, 49);
            this.ultraLabel12.Name = "ultraLabel12";
            this.ultraLabel12.Size = new System.Drawing.Size(24, 24);
            this.ultraLabel12.TabIndex = 963;
            this.ultraLabel12.Text = "％";
            // 
            // tNedit_RateVal
            // 
            appearance138.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance138.ForeColor = System.Drawing.Color.Black;
            appearance138.TextHAlignAsString = "Right";
            this.tNedit_RateVal.ActiveAppearance = appearance138;
            appearance139.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance139.ForeColor = System.Drawing.Color.Black;
            appearance139.ForeColorDisabled = System.Drawing.Color.Black;
            appearance139.TextHAlignAsString = "Right";
            appearance139.TextVAlignAsString = "Middle";
            this.tNedit_RateVal.Appearance = appearance139;
            this.tNedit_RateVal.AutoSelect = true;
            this.tNedit_RateVal.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_RateVal.DataText = "";
            this.tNedit_RateVal.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_RateVal.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 6, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.tNedit_RateVal.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.tNedit_RateVal.Location = new System.Drawing.Point(136, 49);
            this.tNedit_RateVal.MaxLength = 6;
            this.tNedit_RateVal.Name = "tNedit_RateVal";
            this.tNedit_RateVal.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 2, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.tNedit_RateVal.Size = new System.Drawing.Size(90, 24);
            this.tNedit_RateVal.TabIndex = 2;
            // 
            // tEdit_CampaignName
            // 
            appearance12.ForeColor = System.Drawing.Color.Black;
            this.tEdit_CampaignName.ActiveAppearance = appearance12;
            appearance29.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance29.ForeColor = System.Drawing.Color.Black;
            appearance29.ForeColorDisabled = System.Drawing.Color.Black;
            appearance29.TextHAlignAsString = "Left";
            this.tEdit_CampaignName.Appearance = appearance29;
            this.tEdit_CampaignName.AutoSelect = true;
            this.tEdit_CampaignName.DataText = "";
            this.tEdit_CampaignName.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_CampaignName.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 10, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.tEdit_CampaignName.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.tEdit_CampaignName.Location = new System.Drawing.Point(222, 23);
            this.tEdit_CampaignName.MaxLength = 10;
            this.tEdit_CampaignName.Name = "tEdit_CampaignName";
            this.tEdit_CampaignName.ReadOnly = true;
            this.tEdit_CampaignName.Size = new System.Drawing.Size(438, 24);
            this.tEdit_CampaignName.TabIndex = 961;
            // 
            // tNedit_CampaignCode
            // 
            appearance8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance8.ForeColor = System.Drawing.Color.Black;
            appearance8.TextHAlignAsString = "Right";
            this.tNedit_CampaignCode.ActiveAppearance = appearance8;
            appearance9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance9.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance9.ForeColor = System.Drawing.Color.Black;
            appearance9.ForeColorDisabled = System.Drawing.Color.Black;
            appearance9.TextHAlignAsString = "Right";
            appearance9.TextVAlignAsString = "Middle";
            this.tNedit_CampaignCode.Appearance = appearance9;
            this.tNedit_CampaignCode.AutoSelect = true;
            this.tNedit_CampaignCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tNedit_CampaignCode.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_CampaignCode.DataText = "";
            this.tNedit_CampaignCode.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_CampaignCode.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 6, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_CampaignCode.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.tNedit_CampaignCode.Location = new System.Drawing.Point(136, 23);
            this.tNedit_CampaignCode.MaxLength = 6;
            this.tNedit_CampaignCode.Name = "tNedit_CampaignCode";
            this.tNedit_CampaignCode.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, false, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.tNedit_CampaignCode.Size = new System.Drawing.Size(82, 24);
            this.tNedit_CampaignCode.TabIndex = 0;
            // 
            // ultraLabel10
            // 
            appearance2.ForeColorDisabled = System.Drawing.Color.Black;
            appearance2.TextHAlignAsString = "Left";
            appearance2.TextVAlignAsString = "Middle";
            this.ultraLabel10.Appearance = appearance2;
            this.ultraLabel10.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel10.Location = new System.Drawing.Point(1, 75);
            this.ultraLabel10.Margin = new System.Windows.Forms.Padding(1);
            this.ultraLabel10.Name = "ultraLabel10";
            this.ultraLabel10.Size = new System.Drawing.Size(130, 24);
            this.ultraLabel10.TabIndex = 959;
            this.ultraLabel10.Text = "売価額";
            // 
            // ultraLabel4
            // 
            appearance4.ForeColorDisabled = System.Drawing.Color.Black;
            appearance4.TextHAlignAsString = "Left";
            appearance4.TextVAlignAsString = "Middle";
            this.ultraLabel4.Appearance = appearance4;
            this.ultraLabel4.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel4.Location = new System.Drawing.Point(1, 49);
            this.ultraLabel4.Margin = new System.Windows.Forms.Padding(1);
            this.ultraLabel4.Name = "ultraLabel4";
            this.ultraLabel4.Size = new System.Drawing.Size(130, 24);
            this.ultraLabel4.TabIndex = 959;
            this.ultraLabel4.Text = "売価率";
            // 
            // ultraLabel6
            // 
            this.ultraLabel6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ultraLabel6.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel6.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Inset;
            this.ultraLabel6.Location = new System.Drawing.Point(12, 101);
            this.ultraLabel6.Name = "ultraLabel6";
            this.ultraLabel6.Size = new System.Drawing.Size(701, 3);
            this.ultraLabel6.TabIndex = 962;
            // 
            // panel_SetKind
            // 
            this.panel_SetKind.Controls.Add(this.ultraLabel1);
            this.panel_SetKind.Controls.Add(this.tComboEditor_SetKind);
            this.panel_SetKind.Location = new System.Drawing.Point(12, 25);
            this.panel_SetKind.Name = "panel_SetKind";
            this.panel_SetKind.Size = new System.Drawing.Size(417, 31);
            this.panel_SetKind.TabIndex = 0;
            // 
            // PMKHN09601UB
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 15);
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(254)))));
            this.ClientSize = new System.Drawing.Size(729, 398);
            this.Controls.Add(this.ultraLabel6);
            this.Controls.Add(this.panel_SetKind);
            this.Controls.Add(this.panel_Campaign);
            this.Controls.Add(this.panel_GoodsNo);
            this.Controls.Add(this.panel_BLCode);
            this.Controls.Add(this.panel_GoodsMGroup);
            this.Controls.Add(this.panel_GoodsMaker);
            this.Controls.Add(this.panel_Section);
            this.Controls.Add(this.ultraLabel17);
            this.Controls.Add(this.Button_Panel);
            this.Controls.Add(this.ultraStatusBar1);
            this.Controls.Add(this.Mode_Label);
            this.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PMKHN09601UB";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "キャンペーン管理マスタ";
            this.Load += new System.EventHandler(this.PMKHN09601UB_Load);
            this.VisibleChanged += new System.EventHandler(this.PMKHN09601UB_VisibleChanged);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.PMKHN09601UB_Closing);
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SectionGuideNm)).EndInit();
            this.Button_Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SectionCodeAllowZero)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_SetKind)).EndInit();
            this.panel_Section.ResumeLayout(false);
            this.panel_Section.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_BLGoodsCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_GoodsMGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_GoodsMakerCd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_GoodsMakerName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_GoodsMGroupName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_BLCodeName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_GoodsNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_GoodsName_ReadOnly)).EndInit();
            this.panel_GoodsMaker.ResumeLayout(false);
            this.panel_GoodsMaker.PerformLayout();
            this.panel_GoodsMGroup.ResumeLayout(false);
            this.panel_GoodsMGroup.PerformLayout();
            this.panel_BLCode.ResumeLayout(false);
            this.panel_BLCode.PerformLayout();
            this.panel_GoodsNo.ResumeLayout(false);
            this.panel_GoodsNo.PerformLayout();
            this.panel_Campaign.ResumeLayout(false);
            this.panel_Campaign.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_PriceFl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_RateVal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_CampaignName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_CampaignCode)).EndInit();
            this.panel_SetKind.ResumeLayout(false);
            this.panel_SetKind.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Broadleaf.Library.Windows.Forms.TRetKeyControl tRetKeyControl1;
        private Broadleaf.Library.Windows.Forms.TArrowKeyControl tArrowKeyControl1;
        private Infragistics.Win.UltraWinStatusBar.UltraStatusBar ultraStatusBar1;
        private Infragistics.Win.Misc.UltraButton Delete_Button;
        private Infragistics.Win.Misc.UltraButton Revive_Button;
        private Infragistics.Win.Misc.UltraButton Ok_Button;
        private Infragistics.Win.Misc.UltraButton Cancel_Button;
        private Infragistics.Win.Misc.UltraLabel Mode_Label;
        private System.Windows.Forms.Timer Initial_Timer;
        private Broadleaf.Library.Windows.Forms.TEdit tEdit_SectionGuideNm;
        private Infragistics.Win.Misc.UltraLabel SectionCode_Title_Label;
        private Infragistics.Win.UltraWinToolTip.UltraToolTipManager ultraToolTipManager1;
        private Panel Button_Panel;
        private UltraButton uButton_Section;
        private TEdit tEdit_SectionCodeAllowZero;
        private UiSetControl uiSetControl1;
        private UltraButton Renewal_Button;
        private UltraLabel ultraLabel17;
        private Panel panel_Section;
        private TComboEditor tComboEditor_SetKind;
        private UltraLabel ultraLabel1;
        private UltraLabel ultraLabel3;
        private UltraLabel ultraLabel2;
        private TNedit tNedit_BLGoodsCode;
        private UltraButton uButton_BLGoodsCode;
        private TNedit tNedit_GoodsMGroup;
        private UltraButton uButton_GoodsMGroup;
        private UltraLabel ultraLabel11;
        private UltraLabel ultraLabel8;
        private TNedit tNedit_GoodsMakerCd;
        private UltraButton uButton_GoodsMakerCd;
        private UltraLabel ultraLabel9;
        private TEdit tEdit_BLCodeName;
        private TEdit tEdit_GoodsMGroupName;
        private TEdit tEdit_GoodsMakerName;
        private TEdit tEdit_GoodsName_ReadOnly;
        private TEdit tEdit_GoodsNo;
        private UltraLabel ultraLabel5;
        private Panel panel_GoodsMGroup;
        private Panel panel_GoodsMaker;
        private Panel panel_GoodsNo;
        private Panel panel_BLCode;
        private Panel panel_Campaign;
        private UltraLabel ultraLabel6;
        private UltraLabel ultraLabel7;
        private Panel panel_SetKind;
        private TEdit tEdit_CampaignName;
        private TNedit tNedit_CampaignCode;
        private UltraLabel ultraLabel10;
        private UltraLabel ultraLabel4;
        private TNedit tNedit_PriceFl;
        private UltraLabel ultraLabel12;
        private TNedit tNedit_RateVal;
        private UltraButton uButton_CampaignCode;
    }
}

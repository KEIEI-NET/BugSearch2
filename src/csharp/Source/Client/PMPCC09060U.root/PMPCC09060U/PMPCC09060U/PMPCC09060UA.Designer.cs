using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Library.Windows.Forms;
using Infragistics.Win.Misc;
using System.Windows.Forms;
using Infragistics.Win.UltraWinGrid;

namespace Broadleaf.Windows.Forms
{
    partial class PMPCC09060UA
    {
        # region Private Members (Component)

        private Broadleaf.Library.Windows.Forms.TRetKeyControl tRetKeyControl1;
        private Broadleaf.Library.Windows.Forms.TArrowKeyControl tArrowKeyControl1;
        private Infragistics.Win.UltraWinStatusBar.UltraStatusBar ultraStatusBar1;
        private Infragistics.Win.Misc.UltraLabel Mode_Label;
        private System.Windows.Forms.Timer Initial_Timer;
        private System.Data.DataSet Bind_DataSet;
        private Infragistics.Win.UltraWinToolTip.UltraToolTipManager ultraToolTipManager1;
        private UiSetControl uiSetControl1;
        private UltraButton Delete_Button;
        private UltraButton Cancel_Button;
        private UltraButton Ok_Button;
        private UltraButton Revive_Button;
        private Panel Button_Panel;
        private System.ComponentModel.IContainer components;
        private Panel panel1;
        private Panel panel2;
        private UltraLabel ultraLabel1;
        private TEdit tEdit_CampaignName;
        private UltraButton uButton_CampaignGuide;
        private UltraLabel Campaign_Label;
        private TNedit tNedit_CampaignCode;
        private TEdit tEdit_PccCampaignName;
        private UltraLabel ultraLabel2;
        private UltraButton Insert_Button;
        private TEdit tEdit_Message;
        private Panel panel5;
        private UltraButton BlCodeGuid_Button;
        private UltraButton DeleteBlCodeRow_Button;
        private Infragistics.Win.UltraWinGrid.UltraGrid UGrid_ItmSt;
        private TDateEdit ApplyEndDate_TDateEdit;
        private TDateEdit ApplyStaDate_TDateEdit;
        private TComboEditor CampaignObjDiv_tComboEditor;
        private UltraLabel ApplyStaDate_uLabel;
        private UltraLabel CampaignObjDiv_uLabel;
        private UltraLabel ApplyEndDate_uLabel;
        private Panel panel4;
        private UltraButton CustomerGuid_Button;
        private UltraButton DeleteCustomerRow_Button;
        private UltraGrid UGrid_Customer;
        private UltraButton Renewal_Button;

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
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance58 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance59 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance60 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem1 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem2 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance63 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance68 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance26 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("キャンペーン設定名称ガイド", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance23 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PMPCC09060UA));
            this.tRetKeyControl1 = new Broadleaf.Library.Windows.Forms.TRetKeyControl(this.components);
            this.tArrowKeyControl1 = new Broadleaf.Library.Windows.Forms.TArrowKeyControl(this.components);
            this.ultraStatusBar1 = new Infragistics.Win.UltraWinStatusBar.UltraStatusBar();
            this.Mode_Label = new Infragistics.Win.Misc.UltraLabel();
            this.Initial_Timer = new System.Windows.Forms.Timer(this.components);
            this.Bind_DataSet = new System.Data.DataSet();
            this.ultraToolTipManager1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipManager(this.components);
            this.uiSetControl1 = new Broadleaf.Library.Windows.Forms.UiSetControl(this.components);
            this.Ok_Button = new Infragistics.Win.Misc.UltraButton();
            this.Revive_Button = new Infragistics.Win.Misc.UltraButton();
            this.Delete_Button = new Infragistics.Win.Misc.UltraButton();
            this.Cancel_Button = new Infragistics.Win.Misc.UltraButton();
            this.Button_Panel = new System.Windows.Forms.Panel();
            this.Renewal_Button = new Infragistics.Win.Misc.UltraButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.CustomerGuid_Button = new Infragistics.Win.Misc.UltraButton();
            this.DeleteCustomerRow_Button = new Infragistics.Win.Misc.UltraButton();
            this.UGrid_Customer = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.panel5 = new System.Windows.Forms.Panel();
            this.BlCodeGuid_Button = new Infragistics.Win.Misc.UltraButton();
            this.DeleteBlCodeRow_Button = new Infragistics.Win.Misc.UltraButton();
            this.UGrid_ItmSt = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ApplyEndDate_TDateEdit = new Broadleaf.Library.Windows.Forms.TDateEdit();
            this.ApplyStaDate_TDateEdit = new Broadleaf.Library.Windows.Forms.TDateEdit();
            this.CampaignObjDiv_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.ApplyStaDate_uLabel = new Infragistics.Win.Misc.UltraLabel();
            this.CampaignObjDiv_uLabel = new Infragistics.Win.Misc.UltraLabel();
            this.ApplyEndDate_uLabel = new Infragistics.Win.Misc.UltraLabel();
            this.Insert_Button = new Infragistics.Win.Misc.UltraButton();
            this.tEdit_Message = new Broadleaf.Library.Windows.Forms.TEdit();
            this.ultraLabel2 = new Infragistics.Win.Misc.UltraLabel();
            this.tEdit_PccCampaignName = new Broadleaf.Library.Windows.Forms.TEdit();
            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.tEdit_CampaignName = new Broadleaf.Library.Windows.Forms.TEdit();
            this.uButton_CampaignGuide = new Infragistics.Win.Misc.UltraButton();
            this.Campaign_Label = new Infragistics.Win.Misc.UltraLabel();
            this.tNedit_CampaignCode = new Broadleaf.Library.Windows.Forms.TNedit();
            ((System.ComponentModel.ISupportInitialize)(this.Bind_DataSet)).BeginInit();
            this.Button_Panel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UGrid_Customer)).BeginInit();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UGrid_ItmSt)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CampaignObjDiv_tComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_Message)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_PccCampaignName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_CampaignName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_CampaignCode)).BeginInit();
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
            this.ultraStatusBar1.Location = new System.Drawing.Point(0, 514);
            this.ultraStatusBar1.Name = "ultraStatusBar1";
            this.ultraStatusBar1.Size = new System.Drawing.Size(942, 21);
            this.ultraStatusBar1.TabIndex = 46;
            this.ultraStatusBar1.ViewStyle = Infragistics.Win.UltraWinStatusBar.ViewStyle.Office2003;
            // 
            // Mode_Label
            // 
            appearance11.ForeColor = System.Drawing.Color.White;
            appearance11.TextHAlignAsString = "Center";
            appearance11.TextVAlignAsString = "Middle";
            this.Mode_Label.Appearance = appearance11;
            this.Mode_Label.BackColorInternal = System.Drawing.Color.Navy;
            this.Mode_Label.Location = new System.Drawing.Point(804, 9);
            this.Mode_Label.Name = "Mode_Label";
            this.Mode_Label.Size = new System.Drawing.Size(100, 23);
            this.Mode_Label.TabIndex = 23;
            this.Mode_Label.Text = "更新モード";
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
            // uiSetControl1
            // 
            this.uiSetControl1.EditWidthSettingWay = Broadleaf.Library.Windows.Forms.UiSetControl.EditWidthSettingWayState.None;
            this.uiSetControl1.OwnerForm = this;
            // 
            // Ok_Button
            // 
            this.Ok_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Ok_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Ok_Button.Location = new System.Drawing.Point(185, 8);
            this.Ok_Button.Margin = new System.Windows.Forms.Padding(1);
            this.Ok_Button.Name = "Ok_Button";
            this.Ok_Button.Size = new System.Drawing.Size(125, 34);
            this.Ok_Button.TabIndex = 19;
            this.Ok_Button.Text = "保存(&S)";
            this.Ok_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Ok_Button.Click += new System.EventHandler(this.Ok_Button_Click);
            // 
            // Revive_Button
            // 
            this.Revive_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Revive_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Revive_Button.Location = new System.Drawing.Point(187, 8);
            this.Revive_Button.Margin = new System.Windows.Forms.Padding(1);
            this.Revive_Button.Name = "Revive_Button";
            this.Revive_Button.Size = new System.Drawing.Size(125, 34);
            this.Revive_Button.TabIndex = 18;
            this.Revive_Button.Text = "復活(&R)";
            this.Revive_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Revive_Button.Click += new System.EventHandler(this.Revive_Button_Click);
            // 
            // Delete_Button
            // 
            this.Delete_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Delete_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Delete_Button.Location = new System.Drawing.Point(58, 8);
            this.Delete_Button.Margin = new System.Windows.Forms.Padding(1);
            this.Delete_Button.Name = "Delete_Button";
            this.Delete_Button.Size = new System.Drawing.Size(125, 34);
            this.Delete_Button.TabIndex = 17;
            this.Delete_Button.Text = "完全削除(&D)";
            this.Delete_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Delete_Button.Click += new System.EventHandler(this.Delete_Button_Click);
            // 
            // Cancel_Button
            // 
            this.Cancel_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Cancel_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Cancel_Button.Location = new System.Drawing.Point(314, 8);
            this.Cancel_Button.Margin = new System.Windows.Forms.Padding(1);
            this.Cancel_Button.Name = "Cancel_Button";
            this.Cancel_Button.Size = new System.Drawing.Size(125, 34);
            this.Cancel_Button.TabIndex = 20;
            this.Cancel_Button.Text = "閉じる(&X)";
            this.Cancel_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Cancel_Button.Click += new System.EventHandler(this.Cancel_Button_Click);
            // 
            // Button_Panel
            // 
            this.Button_Panel.Controls.Add(this.Renewal_Button);
            this.Button_Panel.Controls.Add(this.Cancel_Button);
            this.Button_Panel.Controls.Add(this.Delete_Button);
            this.Button_Panel.Controls.Add(this.Revive_Button);
            this.Button_Panel.Controls.Add(this.Ok_Button);
            this.Button_Panel.Location = new System.Drawing.Point(483, 456);
            this.Button_Panel.Name = "Button_Panel";
            this.Button_Panel.Size = new System.Drawing.Size(447, 52);
            this.Button_Panel.TabIndex = 4;
            // 
            // Renewal_Button
            // 
            this.Renewal_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Renewal_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Renewal_Button.Location = new System.Drawing.Point(58, 8);
            this.Renewal_Button.Margin = new System.Windows.Forms.Padding(1);
            this.Renewal_Button.Name = "Renewal_Button";
            this.Renewal_Button.Size = new System.Drawing.Size(125, 34);
            this.Renewal_Button.TabIndex = 16;
            this.Renewal_Button.Text = "最新情報(&I)";
            this.Renewal_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Renewal_Button.Click += new System.EventHandler(this.Renewal_Button_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.Button_Panel);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(942, 535);
            this.panel1.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.CustomerGuid_Button);
            this.panel4.Controls.Add(this.DeleteCustomerRow_Button);
            this.panel4.Controls.Add(this.UGrid_Customer);
            this.panel4.Location = new System.Drawing.Point(3, 206);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(465, 239);
            this.panel4.TabIndex = 2;
            // 
            // CustomerGuid_Button
            // 
            this.CustomerGuid_Button.Font = new System.Drawing.Font("ＭＳ ゴシック", 11F);
            this.CustomerGuid_Button.Location = new System.Drawing.Point(113, 13);
            this.CustomerGuid_Button.Name = "CustomerGuid_Button";
            this.CustomerGuid_Button.Size = new System.Drawing.Size(161, 29);
            this.CustomerGuid_Button.TabIndex = 11;
            this.CustomerGuid_Button.Text = "得意先ガイド(&G)";
            this.CustomerGuid_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.CustomerGuid_Button.Click += new System.EventHandler(this.CustomerGuid_Button_Click);
            // 
            // DeleteCustomerRow_Button
            // 
            this.DeleteCustomerRow_Button.Font = new System.Drawing.Font("ＭＳ ゴシック", 11F);
            this.DeleteCustomerRow_Button.Location = new System.Drawing.Point(9, 13);
            this.DeleteCustomerRow_Button.Name = "DeleteCustomerRow_Button";
            this.DeleteCustomerRow_Button.Size = new System.Drawing.Size(98, 29);
            this.DeleteCustomerRow_Button.TabIndex = 10;
            this.DeleteCustomerRow_Button.Text = "削除(&D)";
            this.DeleteCustomerRow_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.DeleteCustomerRow_Button.Click += new System.EventHandler(this.CustomerDeleteRow_Button_Click);
            // 
            // UGrid_Customer
            // 
            this.UGrid_Customer.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.UGrid_Customer.Location = new System.Drawing.Point(9, 48);
            this.UGrid_Customer.Name = "UGrid_Customer";
            this.UGrid_Customer.Size = new System.Drawing.Size(447, 184);
            this.UGrid_Customer.TabIndex = 12;
            this.UGrid_Customer.ClickCellButton += new Infragistics.Win.UltraWinGrid.CellEventHandler(this.UGrid_Customer_ClickCellButton);
            this.UGrid_Customer.AfterExitEditMode += new System.EventHandler(this.UGrid_Customer_AfterExitEditMode);
            this.UGrid_Customer.VisibleChanged += new System.EventHandler(this.UGrid_Customer_VisibleChanged);
            this.UGrid_Customer.CellDataError += new Infragistics.Win.UltraWinGrid.CellDataErrorEventHandler(this.UGrid_CellDataError);
            this.UGrid_Customer.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.UGrid_Customer_KeyPress);
            this.UGrid_Customer.KeyDown += new System.Windows.Forms.KeyEventHandler(this.UGrid_Customer_KeyDown);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.BlCodeGuid_Button);
            this.panel5.Controls.Add(this.DeleteBlCodeRow_Button);
            this.panel5.Controls.Add(this.UGrid_ItmSt);
            this.panel5.Location = new System.Drawing.Point(474, 206);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(465, 239);
            this.panel5.TabIndex = 3;
            // 
            // BlCodeGuid_Button
            // 
            this.BlCodeGuid_Button.Font = new System.Drawing.Font("ＭＳ ゴシック", 11F);
            this.BlCodeGuid_Button.Location = new System.Drawing.Point(113, 13);
            this.BlCodeGuid_Button.Name = "BlCodeGuid_Button";
            this.BlCodeGuid_Button.Size = new System.Drawing.Size(161, 29);
            this.BlCodeGuid_Button.TabIndex = 14;
            this.BlCodeGuid_Button.Text = "BLコードガイド(&H)";
            this.BlCodeGuid_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.BlCodeGuid_Button.Click += new System.EventHandler(this.BlCodeGuid_Button_Click);
            // 
            // DeleteBlCodeRow_Button
            // 
            this.DeleteBlCodeRow_Button.Font = new System.Drawing.Font("ＭＳ ゴシック", 11F);
            this.DeleteBlCodeRow_Button.Location = new System.Drawing.Point(9, 13);
            this.DeleteBlCodeRow_Button.Name = "DeleteBlCodeRow_Button";
            this.DeleteBlCodeRow_Button.Size = new System.Drawing.Size(98, 29);
            this.DeleteBlCodeRow_Button.TabIndex = 13;
            this.DeleteBlCodeRow_Button.Text = "削除(&D)";
            this.DeleteBlCodeRow_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.DeleteBlCodeRow_Button.Click += new System.EventHandler(this.DeleteBlCodeRow_Button_Click);
            // 
            // UGrid_ItmSt
            // 
            this.UGrid_ItmSt.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.UGrid_ItmSt.Location = new System.Drawing.Point(9, 48);
            this.UGrid_ItmSt.Name = "UGrid_ItmSt";
            this.UGrid_ItmSt.Size = new System.Drawing.Size(447, 184);
            this.UGrid_ItmSt.TabIndex = 15;
            this.UGrid_ItmSt.ClickCellButton += new Infragistics.Win.UltraWinGrid.CellEventHandler(this.UGrid_ItmSt_ClickCellButton);
            this.UGrid_ItmSt.AfterExitEditMode += new System.EventHandler(this.UGrid_ItmSt_AfterExitEditMode);
            this.UGrid_ItmSt.CellDataError += new Infragistics.Win.UltraWinGrid.CellDataErrorEventHandler(this.UGrid_CellDataError);
            this.UGrid_ItmSt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.UGrid_ItmSt_KeyPress);
            this.UGrid_ItmSt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.UGrid_ItmSt_KeyDown);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.ApplyEndDate_TDateEdit);
            this.panel2.Controls.Add(this.Mode_Label);
            this.panel2.Controls.Add(this.ApplyStaDate_TDateEdit);
            this.panel2.Controls.Add(this.CampaignObjDiv_tComboEditor);
            this.panel2.Controls.Add(this.ApplyStaDate_uLabel);
            this.panel2.Controls.Add(this.CampaignObjDiv_uLabel);
            this.panel2.Controls.Add(this.ApplyEndDate_uLabel);
            this.panel2.Controls.Add(this.Insert_Button);
            this.panel2.Controls.Add(this.tEdit_Message);
            this.panel2.Controls.Add(this.ultraLabel2);
            this.panel2.Controls.Add(this.tEdit_PccCampaignName);
            this.panel2.Controls.Add(this.ultraLabel1);
            this.panel2.Controls.Add(this.tEdit_CampaignName);
            this.panel2.Controls.Add(this.uButton_CampaignGuide);
            this.panel2.Controls.Add(this.Campaign_Label);
            this.panel2.Controls.Add(this.tNedit_CampaignCode);
            this.panel2.Location = new System.Drawing.Point(0, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(939, 197);
            this.panel2.TabIndex = 1;
            // 
            // ApplyEndDate_TDateEdit
            // 
            appearance14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.ApplyEndDate_TDateEdit.ActiveEditAppearance = appearance14;
            this.ApplyEndDate_TDateEdit.BackColor = System.Drawing.Color.Transparent;
            this.ApplyEndDate_TDateEdit.CalendarDisp = true;
            appearance15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance15.ForeColorDisabled = System.Drawing.Color.Black;
            this.ApplyEndDate_TDateEdit.EditAppearance = appearance15;
            this.ApplyEndDate_TDateEdit.EnableEditors = new Broadleaf.Library.Windows.Forms.TEnableEditors(true, true, true, true);
            this.ApplyEndDate_TDateEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.ApplyEndDate_TDateEdit.Font = new System.Drawing.Font("ＭＳ ゴシック", 11F);
            appearance16.TextHAlignAsString = "Left";
            appearance16.TextVAlignAsString = "Middle";
            this.ApplyEndDate_TDateEdit.LabelAppearance = appearance16;
            this.ApplyEndDate_TDateEdit.Location = new System.Drawing.Point(176, 159);
            this.ApplyEndDate_TDateEdit.Name = "ApplyEndDate_TDateEdit";
            this.ApplyEndDate_TDateEdit.NecessaryEditors = new Broadleaf.Library.Windows.Forms.TNecessaryEditors(false, false, false, false);
            this.ApplyEndDate_TDateEdit.Options = new Broadleaf.Library.Windows.Forms.TDateEditOptions(false, false, false, true, false, true);
            this.ApplyEndDate_TDateEdit.Size = new System.Drawing.Size(172, 24);
            this.ApplyEndDate_TDateEdit.TabIndex = 9;
            this.ApplyEndDate_TDateEdit.TabStop = true;
            // 
            // ApplyStaDate_TDateEdit
            // 
            appearance17.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.ApplyStaDate_TDateEdit.ActiveEditAppearance = appearance17;
            this.ApplyStaDate_TDateEdit.BackColor = System.Drawing.Color.Transparent;
            this.ApplyStaDate_TDateEdit.CalendarDisp = true;
            appearance18.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance18.ForeColorDisabled = System.Drawing.Color.Black;
            this.ApplyStaDate_TDateEdit.EditAppearance = appearance18;
            this.ApplyStaDate_TDateEdit.EnableEditors = new Broadleaf.Library.Windows.Forms.TEnableEditors(true, true, true, true);
            this.ApplyStaDate_TDateEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.ApplyStaDate_TDateEdit.Font = new System.Drawing.Font("ＭＳ ゴシック", 11F);
            appearance19.TextHAlignAsString = "Left";
            appearance19.TextVAlignAsString = "Middle";
            this.ApplyStaDate_TDateEdit.LabelAppearance = appearance19;
            this.ApplyStaDate_TDateEdit.Location = new System.Drawing.Point(176, 129);
            this.ApplyStaDate_TDateEdit.Name = "ApplyStaDate_TDateEdit";
            this.ApplyStaDate_TDateEdit.NecessaryEditors = new Broadleaf.Library.Windows.Forms.TNecessaryEditors(false, false, false, false);
            this.ApplyStaDate_TDateEdit.Options = new Broadleaf.Library.Windows.Forms.TDateEditOptions(false, false, false, true, false, true);
            this.ApplyStaDate_TDateEdit.Size = new System.Drawing.Size(172, 24);
            this.ApplyStaDate_TDateEdit.TabIndex = 8;
            this.ApplyStaDate_TDateEdit.TabStop = true;
            // 
            // CampaignObjDiv_tComboEditor
            // 
            appearance58.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance58.ForeColor = System.Drawing.Color.Black;
            appearance58.TextVAlignAsString = "Middle";
            this.CampaignObjDiv_tComboEditor.ActiveAppearance = appearance58;
            appearance59.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance59.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance59.ForeColorDisabled = System.Drawing.Color.Black;
            this.CampaignObjDiv_tComboEditor.Appearance = appearance59;
            this.CampaignObjDiv_tComboEditor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.CampaignObjDiv_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.CampaignObjDiv_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance60.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.CampaignObjDiv_tComboEditor.ItemAppearance = appearance60;
            valueListItem1.DataValue = 0;
            valueListItem1.DisplayText = "全得意先";
            valueListItem2.DataValue = 1;
            valueListItem2.DisplayText = "対象得意先";
            this.CampaignObjDiv_tComboEditor.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem1,
            valueListItem2});
            this.CampaignObjDiv_tComboEditor.Location = new System.Drawing.Point(176, 99);
            this.CampaignObjDiv_tComboEditor.Name = "CampaignObjDiv_tComboEditor";
            this.CampaignObjDiv_tComboEditor.Size = new System.Drawing.Size(224, 24);
            this.CampaignObjDiv_tComboEditor.TabIndex = 7;
            this.CampaignObjDiv_tComboEditor.ValueChanged += new System.EventHandler(this.CampaignObjDiv_tComboEditor_ValueChanged);
            // 
            // ApplyStaDate_uLabel
            // 
            appearance63.TextVAlignAsString = "Middle";
            this.ApplyStaDate_uLabel.Appearance = appearance63;
            this.ApplyStaDate_uLabel.Location = new System.Drawing.Point(37, 129);
            this.ApplyStaDate_uLabel.Name = "ApplyStaDate_uLabel";
            this.ApplyStaDate_uLabel.Size = new System.Drawing.Size(133, 24);
            this.ApplyStaDate_uLabel.TabIndex = 264;
            this.ApplyStaDate_uLabel.Text = "適用開始日";
            // 
            // CampaignObjDiv_uLabel
            // 
            appearance68.TextVAlignAsString = "Middle";
            this.CampaignObjDiv_uLabel.Appearance = appearance68;
            this.CampaignObjDiv_uLabel.Location = new System.Drawing.Point(37, 99);
            this.CampaignObjDiv_uLabel.Name = "CampaignObjDiv_uLabel";
            this.CampaignObjDiv_uLabel.Size = new System.Drawing.Size(133, 24);
            this.CampaignObjDiv_uLabel.TabIndex = 263;
            this.CampaignObjDiv_uLabel.Text = "対象得意先区分";
            // 
            // ApplyEndDate_uLabel
            // 
            appearance26.TextVAlignAsString = "Middle";
            this.ApplyEndDate_uLabel.Appearance = appearance26;
            this.ApplyEndDate_uLabel.Location = new System.Drawing.Point(37, 159);
            this.ApplyEndDate_uLabel.Name = "ApplyEndDate_uLabel";
            this.ApplyEndDate_uLabel.Size = new System.Drawing.Size(133, 24);
            this.ApplyEndDate_uLabel.TabIndex = 262;
            this.ApplyEndDate_uLabel.Text = "適用終了日";
            // 
            // Insert_Button
            // 
            this.Insert_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Insert_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Insert_Button.Location = new System.Drawing.Point(545, 3);
            this.Insert_Button.Margin = new System.Windows.Forms.Padding(1);
            this.Insert_Button.Name = "Insert_Button";
            this.Insert_Button.Size = new System.Drawing.Size(203, 33);
            this.Insert_Button.TabIndex = 4;
            this.Insert_Button.Text = "キャンペーン設定取込(&C)";
            this.Insert_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Insert_Button.Click += new System.EventHandler(this.Insert_Button_Click);
            // 
            // tEdit_Message
            // 
            appearance1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance1.ForeColor = System.Drawing.Color.Black;
            appearance1.TextVAlignAsString = "Middle";
            this.tEdit_Message.ActiveAppearance = appearance1;
            appearance2.BackColor = System.Drawing.Color.White;
            appearance2.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance2.ForeColor = System.Drawing.Color.Black;
            appearance2.ForeColorDisabled = System.Drawing.Color.Black;
            appearance2.TextVAlignAsString = "Middle";
            this.tEdit_Message.Appearance = appearance2;
            this.tEdit_Message.AutoSelect = true;
            this.tEdit_Message.BackColor = System.Drawing.Color.White;
            this.tEdit_Message.DataText = "";
            this.tEdit_Message.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_Message.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 200, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.tEdit_Message.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.tEdit_Message.Location = new System.Drawing.Point(176, 69);
            this.tEdit_Message.MaxLength = 200;
            this.tEdit_Message.Name = "tEdit_Message";
            this.tEdit_Message.Size = new System.Drawing.Size(661, 24);
            this.tEdit_Message.TabIndex = 6;
            // 
            // ultraLabel2
            // 
            appearance9.TextVAlignAsString = "Middle";
            this.ultraLabel2.Appearance = appearance9;
            this.ultraLabel2.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel2.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel2.Location = new System.Drawing.Point(37, 69);
            this.ultraLabel2.Name = "ultraLabel2";
            this.ultraLabel2.Size = new System.Drawing.Size(133, 24);
            this.ultraLabel2.TabIndex = 75;
            this.ultraLabel2.Text = "メッセージ";
            // 
            // tEdit_PccCampaignName
            // 
            appearance8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance8.ForeColor = System.Drawing.Color.Black;
            appearance8.TextVAlignAsString = "Middle";
            this.tEdit_PccCampaignName.ActiveAppearance = appearance8;
            appearance10.BackColor = System.Drawing.Color.White;
            appearance10.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance10.ForeColor = System.Drawing.Color.Black;
            appearance10.ForeColorDisabled = System.Drawing.Color.Black;
            appearance10.TextVAlignAsString = "Middle";
            this.tEdit_PccCampaignName.Appearance = appearance10;
            this.tEdit_PccCampaignName.AutoSelect = true;
            this.tEdit_PccCampaignName.BackColor = System.Drawing.Color.White;
            this.tEdit_PccCampaignName.DataText = "";
            this.tEdit_PccCampaignName.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_PccCampaignName.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 30, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.tEdit_PccCampaignName.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.tEdit_PccCampaignName.Location = new System.Drawing.Point(176, 39);
            this.tEdit_PccCampaignName.MaxLength = 30;
            this.tEdit_PccCampaignName.Name = "tEdit_PccCampaignName";
            this.tEdit_PccCampaignName.Size = new System.Drawing.Size(208, 24);
            this.tEdit_PccCampaignName.TabIndex = 5;
            // 
            // ultraLabel1
            // 
            appearance7.TextVAlignAsString = "Middle";
            this.ultraLabel1.Appearance = appearance7;
            this.ultraLabel1.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel1.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel1.Location = new System.Drawing.Point(37, 39);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(133, 24);
            this.ultraLabel1.TabIndex = 73;
            this.ultraLabel1.Text = "キャンペーン名称";
            // 
            // tEdit_CampaignName
            // 
            appearance5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance5.ForeColor = System.Drawing.Color.Black;
            appearance5.TextVAlignAsString = "Middle";
            this.tEdit_CampaignName.ActiveAppearance = appearance5;
            appearance6.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance6.ForeColor = System.Drawing.Color.Black;
            appearance6.ForeColorDisabled = System.Drawing.Color.Black;
            appearance6.TextVAlignAsString = "Middle";
            this.tEdit_CampaignName.Appearance = appearance6;
            this.tEdit_CampaignName.AutoSelect = true;
            this.tEdit_CampaignName.DataText = "";
            this.tEdit_CampaignName.Enabled = false;
            this.tEdit_CampaignName.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_CampaignName.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 15, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.tEdit_CampaignName.Location = new System.Drawing.Point(272, 9);
            this.tEdit_CampaignName.MaxLength = 15;
            this.tEdit_CampaignName.Name = "tEdit_CampaignName";
            this.tEdit_CampaignName.ReadOnly = true;
            this.tEdit_CampaignName.Size = new System.Drawing.Size(223, 24);
            this.tEdit_CampaignName.TabIndex = 72;
            this.tEdit_CampaignName.TabStop = false;
            // 
            // uButton_CampaignGuide
            // 
            appearance12.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance12.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.uButton_CampaignGuide.Appearance = appearance12;
            this.uButton_CampaignGuide.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uButton_CampaignGuide.Location = new System.Drawing.Point(242, 9);
            this.uButton_CampaignGuide.Name = "uButton_CampaignGuide";
            this.uButton_CampaignGuide.Size = new System.Drawing.Size(24, 24);
            this.uButton_CampaignGuide.TabIndex = 3;
            ultraToolTipInfo1.ToolTipText = "キャンペーン設定名称ガイド";
            this.ultraToolTipManager1.SetUltraToolTip(this.uButton_CampaignGuide, ultraToolTipInfo1);
            this.uButton_CampaignGuide.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.uButton_CampaignGuide.Click += new System.EventHandler(this.uButton_CampaignGuide_Click);
            // 
            // Campaign_Label
            // 
            appearance4.TextVAlignAsString = "Middle";
            this.Campaign_Label.Appearance = appearance4;
            this.Campaign_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.Campaign_Label.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Campaign_Label.Location = new System.Drawing.Point(37, 9);
            this.Campaign_Label.Name = "Campaign_Label";
            this.Campaign_Label.Size = new System.Drawing.Size(133, 24);
            this.Campaign_Label.TabIndex = 71;
            this.Campaign_Label.Text = "キャンペーンコード";
            // 
            // tNedit_CampaignCode
            // 
            appearance22.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance22.TextHAlignAsString = "Right";
            this.tNedit_CampaignCode.ActiveAppearance = appearance22;
            appearance23.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance23.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance23.ForeColor = System.Drawing.Color.Black;
            appearance23.ForeColorDisabled = System.Drawing.Color.Black;
            appearance23.TextHAlignAsString = "Right";
            this.tNedit_CampaignCode.Appearance = appearance23;
            this.tNedit_CampaignCode.AutoSelect = true;
            this.tNedit_CampaignCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tNedit_CampaignCode.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_CampaignCode.DataText = "";
            this.tNedit_CampaignCode.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_CampaignCode.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 6, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_CampaignCode.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.tNedit_CampaignCode.Location = new System.Drawing.Point(176, 9);
            this.tNedit_CampaignCode.MaxLength = 6;
            this.tNedit_CampaignCode.Name = "tNedit_CampaignCode";
            this.tNedit_CampaignCode.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsFILL);
            this.tNedit_CampaignCode.Size = new System.Drawing.Size(59, 24);
            this.tNedit_CampaignCode.TabIndex = 2;
            // 
            // PMPCC09060UA
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 15);
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(942, 535);
            this.Controls.Add(this.ultraStatusBar1);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PMPCC09060UA";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "BLﾊﾟｰﾂｵｰﾀﾞｰｷｬﾝﾍﾟｰﾝ表示設定";
            this.Load += new System.EventHandler(this.PMPCC09060UA_Load);
            this.VisibleChanged += new System.EventHandler(this.PMPCC09060UA_VisibleChanged);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.PMPCC09060UA_Closing);
            ((System.ComponentModel.ISupportInitialize)(this.Bind_DataSet)).EndInit();
            this.Button_Panel.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.UGrid_Customer)).EndInit();
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.UGrid_ItmSt)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CampaignObjDiv_tComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_Message)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_PccCampaignName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_CampaignName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_CampaignCode)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

    }
}

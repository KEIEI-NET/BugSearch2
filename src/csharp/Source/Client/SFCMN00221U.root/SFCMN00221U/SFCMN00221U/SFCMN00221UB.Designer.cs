//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace Broadleaf.Windows.Forms
//{
//    partial class SFCMN00221UB
//    {
//        private Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarContainerControl ultraExplorerBarContainerControl1;
//        private Infragistics.Win.UltraWinExplorerBar.UltraExplorerBar uExplorerBar_Condition;
//        private System.Windows.Forms.Panel panel_Condition;
//        internal System.Windows.Forms.Panel panel_Main;
//        private Infragistics.Win.UltraWinGrid.UltraGrid uGrid_Search;
//        private System.Data.DataSet dataSet_AcceptAnOrderSearch;
//        private System.Windows.Forms.Timer timer_Search;
//        private Broadleaf.Library.Windows.Forms.TRetKeyControl tRetKeyControl1;
//        private Broadleaf.Library.Windows.Forms.TArrowKeyControl tArrowKeyControl1;
//        private System.Windows.Forms.Timer timer_Activated;
//        private Infragistics.Win.UltraWinStatusBar.UltraStatusBar uStatusBar_Main;
//        private Broadleaf.Library.Windows.Forms.TComboEditor tComboEditor_GridFontSize;
//        private Infragistics.Win.UltraWinEditors.UltraCheckEditor uCheckEditor_CAddUpDisplay;
//        private System.Windows.Forms.Timer timer_MessageUnDisp;
//        private Broadleaf.Library.Windows.Forms.TDateEdit tDateEdit_DateEnd;
//        private Broadleaf.Library.Windows.Forms.TDateEdit tDateEdit_DateSta;
//        private Infragistics.Win.Misc.UltraButton uButton_Guide;
//        private Broadleaf.Library.Windows.Forms.TNedit tNedit_FindCondition;
//        private Broadleaf.Library.Windows.Forms.TEdit tEdit_FindCondition;
//        private Infragistics.Win.Misc.UltraButton uButton_Find;
//        private Broadleaf.Library.Windows.Forms.TComboEditor tComboEditor_FindCondition;
//        private Infragistics.Win.Misc.UltraLabel uLabel_SlipDate;
//        private Infragistics.Win.Misc.UltraLabel uLabel_FindCondition;
//        private System.Windows.Forms.Panel panel_ConditionSub;
//        private System.Windows.Forms.Panel panel_ConditionSection;
//        private Broadleaf.Library.Windows.Forms.TComboEditor tComboEditor_StockSectionCd;
//        private Infragistics.Win.Misc.UltraLabel uLabel_DemandAddUpSecCd;
//        private Broadleaf.Library.Windows.Forms.TLine tLine_SectionPanel;
//        private System.Windows.Forms.ContextMenu contextMenu_Condition;
//        private System.Windows.Forms.MenuItem menuItem_MakerModelClear;
//        private System.Windows.Forms.ToolTip toolTip_Hint;
//        private System.ComponentModel.IContainer components;

//        /// <summary>
//        /// 使用されているリソースに後処理を実行します。
//        /// </summary>
//        protected override void Dispose(bool disposing)
//        {
//            if (disposing)
//            {
//                if (components != null)
//                {
//                    components.Dispose();
//                }
//            }
//            base.Dispose(disposing);
//        }

//        #region コンポーネント デザイナ デザイナで生成されたコード
//        /// <summary>
//        /// デザイナ サポートに必要なメソッドです。このメソッドの内容を
//        /// コード エディタで変更しないでください。
//        /// </summary>
//        private void InitializeComponent()
//        {
//            this.components = new System.ComponentModel.Container();
//            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
//            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
//            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
//            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
//            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
//            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
//            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
//            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
//            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
//            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
//            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
//            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
//            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
//            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
//            Infragistics.Win.Appearance appearance23 = new Infragistics.Win.Appearance();
//            Infragistics.Win.Appearance appearance24 = new Infragistics.Win.Appearance();
//            Infragistics.Win.Appearance appearance25 = new Infragistics.Win.Appearance();
//            Infragistics.Win.Appearance appearance26 = new Infragistics.Win.Appearance();
//            Infragistics.Win.ValueListItem valueListItem20 = new Infragistics.Win.ValueListItem();
//            Infragistics.Win.ValueListItem valueListItem21 = new Infragistics.Win.ValueListItem();
//            Infragistics.Win.ValueListItem valueListItem22 = new Infragistics.Win.ValueListItem();
//            Infragistics.Win.ValueListItem valueListItem23 = new Infragistics.Win.ValueListItem();
//            Infragistics.Win.ValueListItem valueListItem24 = new Infragistics.Win.ValueListItem();
//            Infragistics.Win.ValueListItem valueListItem25 = new Infragistics.Win.ValueListItem();
//            Infragistics.Win.ValueListItem valueListItem26 = new Infragistics.Win.ValueListItem();
//            Infragistics.Win.ValueListItem valueListItem27 = new Infragistics.Win.ValueListItem();
//            Infragistics.Win.ValueListItem valueListItem28 = new Infragistics.Win.ValueListItem();
//            Infragistics.Win.ValueListItem valueListItem29 = new Infragistics.Win.ValueListItem();
//            Infragistics.Win.ValueListItem valueListItem30 = new Infragistics.Win.ValueListItem();
//            Infragistics.Win.ValueListItem valueListItem31 = new Infragistics.Win.ValueListItem();
//            Infragistics.Win.ValueListItem valueListItem32 = new Infragistics.Win.ValueListItem();
//            Infragistics.Win.ValueListItem valueListItem33 = new Infragistics.Win.ValueListItem();
//            Infragistics.Win.ValueListItem valueListItem34 = new Infragistics.Win.ValueListItem();
//            Infragistics.Win.Appearance appearance27 = new Infragistics.Win.Appearance();
//            Infragistics.Win.Appearance appearance28 = new Infragistics.Win.Appearance();
//            Infragistics.Win.Appearance appearance29 = new Infragistics.Win.Appearance();
//            Infragistics.Win.Appearance appearance30 = new Infragistics.Win.Appearance();
//            Infragistics.Win.Appearance appearance31 = new Infragistics.Win.Appearance();
//            Infragistics.Win.Appearance appearance32 = new Infragistics.Win.Appearance();
//            Infragistics.Win.Appearance appearance33 = new Infragistics.Win.Appearance();
//            Infragistics.Win.ValueListItem valueListItem35 = new Infragistics.Win.ValueListItem();
//            Infragistics.Win.ValueListItem valueListItem36 = new Infragistics.Win.ValueListItem();
//            Infragistics.Win.ValueListItem valueListItem37 = new Infragistics.Win.ValueListItem();
//            Infragistics.Win.ValueListItem valueListItem38 = new Infragistics.Win.ValueListItem();
//            Infragistics.Win.ValueListItem valueListItem39 = new Infragistics.Win.ValueListItem();
//            Infragistics.Win.Appearance appearance34 = new Infragistics.Win.Appearance();
//            Infragistics.Win.Appearance appearance35 = new Infragistics.Win.Appearance();
//            Infragistics.Win.Appearance appearance36 = new Infragistics.Win.Appearance();
//            Infragistics.Win.Appearance appearance37 = new Infragistics.Win.Appearance();
//            Infragistics.Win.Appearance appearance38 = new Infragistics.Win.Appearance();
//            Infragistics.Win.Appearance appearance39 = new Infragistics.Win.Appearance();
//            Infragistics.Win.Appearance appearance40 = new Infragistics.Win.Appearance();
//            Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup ultraExplorerBarGroup1 = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup();
//            Infragistics.Win.Appearance appearance41 = new Infragistics.Win.Appearance();
//            Infragistics.Win.Appearance appearance42 = new Infragistics.Win.Appearance();
//            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel1 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
//            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel2 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
//            Infragistics.Win.Appearance appearance43 = new Infragistics.Win.Appearance();
//            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel3 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
//            Infragistics.Win.Appearance appearance44 = new Infragistics.Win.Appearance();
//            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel4 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
//            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
//            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
//            Infragistics.Win.ValueListItem valueListItem14 = new Infragistics.Win.ValueListItem();
//            Infragistics.Win.ValueListItem valueListItem15 = new Infragistics.Win.ValueListItem();
//            Infragistics.Win.ValueListItem valueListItem16 = new Infragistics.Win.ValueListItem();
//            Infragistics.Win.ValueListItem valueListItem17 = new Infragistics.Win.ValueListItem();
//            Infragistics.Win.ValueListItem valueListItem18 = new Infragistics.Win.ValueListItem();
//            Infragistics.Win.ValueListItem valueListItem19 = new Infragistics.Win.ValueListItem();
//            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
//            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
//            Infragistics.Win.ValueListItem valueListItem10 = new Infragistics.Win.ValueListItem();
//            Infragistics.Win.ValueListItem valueListItem11 = new Infragistics.Win.ValueListItem();
//            Infragistics.Win.ValueListItem valueListItem12 = new Infragistics.Win.ValueListItem();
//            Infragistics.Win.ValueListItem valueListItem13 = new Infragistics.Win.ValueListItem();
//            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
//            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
//            Infragistics.Win.ValueListItem valueListItem6 = new Infragistics.Win.ValueListItem();
//            Infragistics.Win.ValueListItem valueListItem7 = new Infragistics.Win.ValueListItem();
//            Infragistics.Win.ValueListItem valueListItem8 = new Infragistics.Win.ValueListItem();
//            Infragistics.Win.ValueListItem valueListItem9 = new Infragistics.Win.ValueListItem();
//            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
//            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
//            Infragistics.Win.ValueListItem valueListItem1 = new Infragistics.Win.ValueListItem();
//            Infragistics.Win.ValueListItem valueListItem2 = new Infragistics.Win.ValueListItem();
//            Infragistics.Win.ValueListItem valueListItem3 = new Infragistics.Win.ValueListItem();
//            Infragistics.Win.ValueListItem valueListItem4 = new Infragistics.Win.ValueListItem();
//            Infragistics.Win.ValueListItem valueListItem5 = new Infragistics.Win.ValueListItem();
//            this.ultraExplorerBarContainerControl1 = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarContainerControl();
//            this.panel_ConditionSub = new System.Windows.Forms.Panel();
//            this.tEdit_FindConditionCodeType = new Broadleaf.Library.Windows.Forms.TEdit();
//            this.tNedit_FindConditionCodeType = new Broadleaf.Library.Windows.Forms.TNedit();
//            this.uButton_Find = new Infragistics.Win.Misc.UltraButton();
//            this.tDateEdit_DateEnd = new Broadleaf.Library.Windows.Forms.TDateEdit();
//            this.tDateEdit_DateSta = new Broadleaf.Library.Windows.Forms.TDateEdit();
//            this.uLabel_SlipDate = new Infragistics.Win.Misc.UltraLabel();
//            this.tLine_ConditionPanel = new Broadleaf.Library.Windows.Forms.TLine();
//            this.ultraLabel16 = new Infragistics.Win.Misc.UltraLabel();
//            this.ultraLabel11 = new Infragistics.Win.Misc.UltraLabel();
//            this.ultraLabel9 = new Infragistics.Win.Misc.UltraLabel();
//            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
//            this.uButton_Guide = new Infragistics.Win.Misc.UltraButton();
//            this.tNedit_FindCondition = new Broadleaf.Library.Windows.Forms.TNedit();
//            this.tEdit_FindCondition = new Broadleaf.Library.Windows.Forms.TEdit();
//            this.tComboEditor_FindCondition = new Broadleaf.Library.Windows.Forms.TComboEditor();
//            this.uLabel_FindCondition = new Infragistics.Win.Misc.UltraLabel();
//            this.panel_ConditionSection = new System.Windows.Forms.Panel();
//            this.tLine_SectionPanel = new Broadleaf.Library.Windows.Forms.TLine();
//            this.uLabel_DemandAddUpSecCd = new Infragistics.Win.Misc.UltraLabel();
//            this.tComboEditor_StockSectionCd = new Broadleaf.Library.Windows.Forms.TComboEditor();
//            this.uCheckEditor_CAddUpDisplay = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
//            this.tComboEditor_GridFontSize = new Broadleaf.Library.Windows.Forms.TComboEditor();
//            this.panel_Main = new System.Windows.Forms.Panel();
//            this.uGrid_Search = new Infragistics.Win.UltraWinGrid.UltraGrid();
//            this.panel_Condition = new System.Windows.Forms.Panel();
//            this.uExplorerBar_Condition = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBar();
//            this.uStatusBar_Main = new Infragistics.Win.UltraWinStatusBar.UltraStatusBar();
//            this.dataSet_AcceptAnOrderSearch = new System.Data.DataSet();
//            this.timer_Search = new System.Windows.Forms.Timer(this.components);
//            this.tRetKeyControl1 = new Broadleaf.Library.Windows.Forms.TRetKeyControl(this.components);
//            this.tArrowKeyControl1 = new Broadleaf.Library.Windows.Forms.TArrowKeyControl(this.components);
//            this.timer_Activated = new System.Windows.Forms.Timer(this.components);
//            this.timer_MessageUnDisp = new System.Windows.Forms.Timer(this.components);
//            this.contextMenu_Condition = new System.Windows.Forms.ContextMenu();
//            this.menuItem_MakerModelClear = new System.Windows.Forms.MenuItem();
//            this.toolTip_Hint = new System.Windows.Forms.ToolTip(this.components);
//            this.uToolTipManager_Information = new Infragistics.Win.UltraWinToolTip.UltraToolTipManager(this.components);
//            this.tComboEditor_SalesSlipKind = new Broadleaf.Library.Windows.Forms.TComboEditor();
//            this.tComboEditor_SalesFormalCode = new Broadleaf.Library.Windows.Forms.TComboEditor();
//            this.tComboEditor_SalesSlipCd = new Broadleaf.Library.Windows.Forms.TComboEditor();
//            this.tComboEditor_GoodsKindCode = new Broadleaf.Library.Windows.Forms.TComboEditor();
//            this.ultraExplorerBarContainerControl1.SuspendLayout();
//            this.panel_ConditionSub.SuspendLayout();
//            ((System.ComponentModel.ISupportInitialize)(this.tEdit_FindConditionCodeType)).BeginInit();
//            ((System.ComponentModel.ISupportInitialize)(this.tNedit_FindConditionCodeType)).BeginInit();
//            ((System.ComponentModel.ISupportInitialize)(this.tLine_ConditionPanel)).BeginInit();
//            ((System.ComponentModel.ISupportInitialize)(this.tNedit_FindCondition)).BeginInit();
//            ((System.ComponentModel.ISupportInitialize)(this.tEdit_FindCondition)).BeginInit();
//            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_FindCondition)).BeginInit();
//            this.panel_ConditionSection.SuspendLayout();
//            ((System.ComponentModel.ISupportInitialize)(this.tLine_SectionPanel)).BeginInit();
//            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_StockSectionCd)).BeginInit();
//            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_GridFontSize)).BeginInit();
//            this.panel_Main.SuspendLayout();
//            ((System.ComponentModel.ISupportInitialize)(this.uGrid_Search)).BeginInit();
//            this.panel_Condition.SuspendLayout();
//            ((System.ComponentModel.ISupportInitialize)(this.uExplorerBar_Condition)).BeginInit();
//            this.uExplorerBar_Condition.SuspendLayout();
//            this.uStatusBar_Main.SuspendLayout();
//            ((System.ComponentModel.ISupportInitialize)(this.dataSet_AcceptAnOrderSearch)).BeginInit();
//            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_SalesSlipKind)).BeginInit();
//            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_SalesFormalCode)).BeginInit();
//            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_SalesSlipCd)).BeginInit();
//            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_GoodsKindCode)).BeginInit();
//            this.SuspendLayout();
//            // 
//            // ultraExplorerBarContainerControl1
//            // 
//            this.ultraExplorerBarContainerControl1.Controls.Add(this.panel_ConditionSub);
//            this.ultraExplorerBarContainerControl1.Controls.Add(this.panel_ConditionSection);
//            this.ultraExplorerBarContainerControl1.Location = new System.Drawing.Point(6, 29);
//            this.ultraExplorerBarContainerControl1.Name = "ultraExplorerBarContainerControl1";
//            this.ultraExplorerBarContainerControl1.Size = new System.Drawing.Size(338, 191);
//            this.ultraExplorerBarContainerControl1.TabIndex = 0;
//            // 
//            // panel_ConditionSub
//            // 
//            this.panel_ConditionSub.BackColor = System.Drawing.Color.Transparent;
//            this.panel_ConditionSub.Controls.Add(this.tComboEditor_GoodsKindCode);
//            this.panel_ConditionSub.Controls.Add(this.tComboEditor_SalesSlipCd);
//            this.panel_ConditionSub.Controls.Add(this.tComboEditor_SalesFormalCode);
//            this.panel_ConditionSub.Controls.Add(this.tComboEditor_SalesSlipKind);
//            this.panel_ConditionSub.Controls.Add(this.tEdit_FindConditionCodeType);
//            this.panel_ConditionSub.Controls.Add(this.tNedit_FindConditionCodeType);
//            this.panel_ConditionSub.Controls.Add(this.uButton_Find);
//            this.panel_ConditionSub.Controls.Add(this.tDateEdit_DateEnd);
//            this.panel_ConditionSub.Controls.Add(this.tDateEdit_DateSta);
//            this.panel_ConditionSub.Controls.Add(this.uLabel_SlipDate);
//            this.panel_ConditionSub.Controls.Add(this.tLine_ConditionPanel);
//            this.panel_ConditionSub.Controls.Add(this.ultraLabel16);
//            this.panel_ConditionSub.Controls.Add(this.ultraLabel11);
//            this.panel_ConditionSub.Controls.Add(this.ultraLabel9);
//            this.panel_ConditionSub.Controls.Add(this.ultraLabel1);
//            this.panel_ConditionSub.Controls.Add(this.uButton_Guide);
//            this.panel_ConditionSub.Controls.Add(this.tNedit_FindCondition);
//            this.panel_ConditionSub.Controls.Add(this.tEdit_FindCondition);
//            this.panel_ConditionSub.Controls.Add(this.tComboEditor_FindCondition);
//            this.panel_ConditionSub.Controls.Add(this.uLabel_FindCondition);
//            this.panel_ConditionSub.Dock = System.Windows.Forms.DockStyle.Fill;
//            this.panel_ConditionSub.Location = new System.Drawing.Point(0, 32);
//            this.panel_ConditionSub.Name = "panel_ConditionSub";
//            this.panel_ConditionSub.Size = new System.Drawing.Size(338, 159);
//            this.panel_ConditionSub.TabIndex = 1;
//            // 
//            // tEdit_FindConditionCodeType
//            // 
//            appearance9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
//            this.tEdit_FindConditionCodeType.ActiveAppearance = appearance9;
//            this.tEdit_FindConditionCodeType.AutoSelect = true;
//            this.tEdit_FindConditionCodeType.AutoSize = false;
//            this.tEdit_FindConditionCodeType.DataText = "";
//            this.tEdit_FindConditionCodeType.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
//            this.tEdit_FindConditionCodeType.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 12, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, true, true, true, true));
//            this.tEdit_FindConditionCodeType.Location = new System.Drawing.Point(163, 131);
//            this.tEdit_FindConditionCodeType.MaxLength = 12;
//            this.tEdit_FindConditionCodeType.Name = "tEdit_FindConditionCodeType";
//            this.tEdit_FindConditionCodeType.Size = new System.Drawing.Size(144, 22);
//            this.tEdit_FindConditionCodeType.TabIndex = 6;
//            // 
//            // tNedit_FindConditionCodeType
//            // 
//            appearance10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
//            this.tNedit_FindConditionCodeType.ActiveAppearance = appearance10;
//            appearance11.TextHAlign = Infragistics.Win.HAlign.Right;
//            this.tNedit_FindConditionCodeType.Appearance = appearance11;
//            this.tNedit_FindConditionCodeType.AutoSelect = true;
//            this.tNedit_FindConditionCodeType.AutoSize = false;
//            this.tNedit_FindConditionCodeType.CalcDisp = Broadleaf.Library.Windows.Forms.emCalcDisp.nclcNone;
//            this.tNedit_FindConditionCodeType.CalcSize = new System.Drawing.Size(172, 200);
//            this.tNedit_FindConditionCodeType.DataText = "";
//            this.tNedit_FindConditionCodeType.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
//            this.tNedit_FindConditionCodeType.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 9, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
//            this.tNedit_FindConditionCodeType.ImeMode = System.Windows.Forms.ImeMode.Off;
//            this.tNedit_FindConditionCodeType.Location = new System.Drawing.Point(192, 117);
//            this.tNedit_FindConditionCodeType.MaxLength = 9;
//            this.tNedit_FindConditionCodeType.Name = "tNedit_FindConditionCodeType";
//            this.tNedit_FindConditionCodeType.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
//            this.tNedit_FindConditionCodeType.Size = new System.Drawing.Size(82, 22);
//            this.tNedit_FindConditionCodeType.TabIndex = 6;
//            // 
//            // uButton_Find
//            // 
//            this.uButton_Find.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
//            this.uButton_Find.HotTracking = true;
//            this.uButton_Find.Location = new System.Drawing.Point(269, 131);
//            this.uButton_Find.Name = "uButton_Find";
//            this.uButton_Find.Size = new System.Drawing.Size(58, 25);
//            this.uButton_Find.TabIndex = 11;
//            this.uButton_Find.Text = "検索";
//            this.uButton_Find.Click += new System.EventHandler(this.uButton_Find_Click);
//            // 
//            // tDateEdit_DateEnd
//            // 
//            appearance12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
//            this.tDateEdit_DateEnd.ActiveEditAppearance = appearance12;
//            this.tDateEdit_DateEnd.BackColor = System.Drawing.Color.Transparent;
//            this.tDateEdit_DateEnd.CalendarDisp = true;
//            appearance13.TextHAlign = Infragistics.Win.HAlign.Left;
//            appearance13.TextVAlign = Infragistics.Win.VAlign.Middle;
//            this.tDateEdit_DateEnd.EditAppearance = appearance13;
//            this.tDateEdit_DateEnd.EnableEditors = new Broadleaf.Library.Windows.Forms.TEnableEditors(true, true, true, true);
//            this.tDateEdit_DateEnd.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
//            appearance14.TextHAlign = Infragistics.Win.HAlign.Left;
//            appearance14.TextVAlign = Infragistics.Win.VAlign.Middle;
//            this.tDateEdit_DateEnd.LabelAppearance = appearance14;
//            this.tDateEdit_DateEnd.Location = new System.Drawing.Point(10, 132);
//            this.tDateEdit_DateEnd.Name = "tDateEdit_DateEnd";
//            this.tDateEdit_DateEnd.NecessaryEditors = new Broadleaf.Library.Windows.Forms.TNecessaryEditors(false, false, false, false);
//            this.tDateEdit_DateEnd.Options = new Broadleaf.Library.Windows.Forms.TDateEditOptions(false, false, false, true, false, true);
//            this.tDateEdit_DateEnd.Size = new System.Drawing.Size(176, 24);
//            this.tDateEdit_DateEnd.TabIndex = 9;
//            this.tDateEdit_DateEnd.TabStop = true;
//            this.tDateEdit_DateEnd.Visible = false;
//            // 
//            // tDateEdit_DateSta
//            // 
//            appearance15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
//            this.tDateEdit_DateSta.ActiveEditAppearance = appearance15;
//            this.tDateEdit_DateSta.BackColor = System.Drawing.Color.Transparent;
//            this.tDateEdit_DateSta.CalendarDisp = true;
//            appearance16.TextHAlign = Infragistics.Win.HAlign.Left;
//            appearance16.TextVAlign = Infragistics.Win.VAlign.Middle;
//            this.tDateEdit_DateSta.EditAppearance = appearance16;
//            this.tDateEdit_DateSta.EnableEditors = new Broadleaf.Library.Windows.Forms.TEnableEditors(true, true, true, true);
//            this.tDateEdit_DateSta.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
//            appearance17.TextHAlign = Infragistics.Win.HAlign.Left;
//            appearance17.TextVAlign = Infragistics.Win.VAlign.Middle;
//            this.tDateEdit_DateSta.LabelAppearance = appearance17;
//            this.tDateEdit_DateSta.Location = new System.Drawing.Point(10, 90);
//            this.tDateEdit_DateSta.Name = "tDateEdit_DateSta";
//            this.tDateEdit_DateSta.NecessaryEditors = new Broadleaf.Library.Windows.Forms.TNecessaryEditors(false, false, false, false);
//            this.tDateEdit_DateSta.Options = new Broadleaf.Library.Windows.Forms.TDateEditOptions(false, false, false, true, false, true);
//            this.tDateEdit_DateSta.Size = new System.Drawing.Size(176, 24);
//            this.tDateEdit_DateSta.TabIndex = 8;
//            this.tDateEdit_DateSta.TabStop = true;
//            this.tDateEdit_DateSta.Visible = false;
//            // 
//            // uLabel_SlipDate
//            // 
//            this.uLabel_SlipDate.BackColor = System.Drawing.Color.Transparent;
//            this.uLabel_SlipDate.Location = new System.Drawing.Point(95, 115);
//            this.uLabel_SlipDate.Name = "uLabel_SlipDate";
//            this.uLabel_SlipDate.Size = new System.Drawing.Size(18, 15);
//            this.uLabel_SlipDate.TabIndex = 30;
//            this.uLabel_SlipDate.Text = "～";
//            // 
//            // tLine_ConditionPanel
//            // 
//            this.tLine_ConditionPanel.BackColor = System.Drawing.Color.Transparent;
//            this.tLine_ConditionPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(157)))), ((int)(((byte)(185)))));
//            this.tLine_ConditionPanel.Location = new System.Drawing.Point(5, 55);
//            this.tLine_ConditionPanel.Name = "tLine_ConditionPanel";
//            this.tLine_ConditionPanel.Size = new System.Drawing.Size(327, 10);
//            this.tLine_ConditionPanel.TabIndex = 1196;
//            // 
//            // ultraLabel16
//            // 
//            appearance18.TextVAlign = Infragistics.Win.VAlign.Middle;
//            this.ultraLabel16.Appearance = appearance18;
//            this.ultraLabel16.Location = new System.Drawing.Point(174, 27);
//            this.ultraLabel16.Name = "ultraLabel16";
//            this.ultraLabel16.Size = new System.Drawing.Size(67, 24);
//            this.ultraLabel16.TabIndex = 1195;
//            this.ultraLabel16.Text = "商品種別";
//            // 
//            // ultraLabel11
//            // 
//            appearance19.TextVAlign = Infragistics.Win.VAlign.Middle;
//            this.ultraLabel11.Appearance = appearance19;
//            this.ultraLabel11.Location = new System.Drawing.Point(10, 27);
//            this.ultraLabel11.Name = "ultraLabel11";
//            this.ultraLabel11.Size = new System.Drawing.Size(67, 24);
//            this.ultraLabel11.TabIndex = 35;
//            this.ultraLabel11.Text = "売上形式";
//            // 
//            // ultraLabel9
//            // 
//            appearance20.TextVAlign = Infragistics.Win.VAlign.Middle;
//            this.ultraLabel9.Appearance = appearance20;
//            this.ultraLabel9.Location = new System.Drawing.Point(174, 1);
//            this.ultraLabel9.Name = "ultraLabel9";
//            this.ultraLabel9.Size = new System.Drawing.Size(67, 24);
//            this.ultraLabel9.TabIndex = 33;
//            this.ultraLabel9.Text = "伝票区分";
//            // 
//            // ultraLabel1
//            // 
//            appearance21.TextVAlign = Infragistics.Win.VAlign.Middle;
//            this.ultraLabel1.Appearance = appearance21;
//            this.ultraLabel1.Location = new System.Drawing.Point(10, 1);
//            this.ultraLabel1.Name = "ultraLabel1";
//            this.ultraLabel1.Size = new System.Drawing.Size(67, 24);
//            this.ultraLabel1.TabIndex = 31;
//            this.ultraLabel1.Text = "伝票種別";
//            // 
//            // uButton_Guide
//            // 
//            this.uButton_Guide.HotTracking = true;
//            this.uButton_Guide.Location = new System.Drawing.Point(302, 88);
//            this.uButton_Guide.Name = "uButton_Guide";
//            this.uButton_Guide.Size = new System.Drawing.Size(24, 23);
//            this.uButton_Guide.TabIndex = 10;
//            this.uButton_Guide.Visible = false;
//            this.uButton_Guide.Click += new System.EventHandler(this.uButton_Guide_Click);
//            // 
//            // tNedit_FindCondition
//            // 
//            appearance22.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
//            this.tNedit_FindCondition.ActiveAppearance = appearance22;
//            appearance23.TextHAlign = Infragistics.Win.HAlign.Right;
//            this.tNedit_FindCondition.Appearance = appearance23;
//            this.tNedit_FindCondition.AutoSelect = true;
//            this.tNedit_FindCondition.AutoSize = false;
//            this.tNedit_FindCondition.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
//            this.tNedit_FindCondition.CalcDisp = Broadleaf.Library.Windows.Forms.emCalcDisp.nclcNone;
//            this.tNedit_FindCondition.CalcSize = new System.Drawing.Size(172, 200);
//            this.tNedit_FindCondition.DataText = "";
//            this.tNedit_FindCondition.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
//            this.tNedit_FindCondition.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 9, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
//            this.tNedit_FindCondition.ImeMode = System.Windows.Forms.ImeMode.Off;
//            this.tNedit_FindCondition.Location = new System.Drawing.Point(219, 90);
//            this.tNedit_FindCondition.MaxLength = 9;
//            this.tNedit_FindCondition.Name = "tNedit_FindCondition";
//            this.tNedit_FindCondition.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
//            this.tNedit_FindCondition.Size = new System.Drawing.Size(82, 20);
//            this.tNedit_FindCondition.SupportThemes = false;
//            this.tNedit_FindCondition.TabIndex = 6;
//            this.tNedit_FindCondition.Enter += new System.EventHandler(this.tNedit_FindCondition_Enter);
//            this.tNedit_FindCondition.ValueChanged += new System.EventHandler(this.tNedit_FindCondition_ValueChanged);
//            this.tNedit_FindCondition.Leave += new System.EventHandler(this.tNedit_FindCondition_Leave);
//            // 
//            // tEdit_FindCondition
//            // 
//            appearance24.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
//            this.tEdit_FindCondition.ActiveAppearance = appearance24;
//            this.tEdit_FindCondition.AutoSelect = true;
//            this.tEdit_FindCondition.AutoSize = false;
//            this.tEdit_FindCondition.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
//            this.tEdit_FindCondition.DataText = "";
//            this.tEdit_FindCondition.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
//            this.tEdit_FindCondition.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 12, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
//            this.tEdit_FindCondition.Location = new System.Drawing.Point(5, 90);
//            this.tEdit_FindCondition.MaxLength = 12;
//            this.tEdit_FindCondition.Name = "tEdit_FindCondition";
//            this.tEdit_FindCondition.Size = new System.Drawing.Size(113, 20);
//            this.tEdit_FindCondition.SupportThemes = false;
//            this.tEdit_FindCondition.TabIndex = 6;
//            this.tEdit_FindCondition.Enter += new System.EventHandler(this.tEdit_FindCondition_Enter);
//            this.tEdit_FindCondition.Leave += new System.EventHandler(this.tEdit_FindCondition_Leave);
//            // 
//            // tComboEditor_FindCondition
//            // 
//            appearance25.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
//            this.tComboEditor_FindCondition.ActiveAppearance = appearance25;
//            this.tComboEditor_FindCondition.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
//            this.tComboEditor_FindCondition.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
//            appearance26.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
//            this.tComboEditor_FindCondition.ItemAppearance = appearance26;
//            valueListItem20.DataValue = 1;
//            valueListItem20.DisplayText = "伝票日付";
//            valueListItem21.DataValue = 2;
//            valueListItem21.DisplayText = "計上日";
//            valueListItem22.DataValue = 3;
//            valueListItem22.DisplayText = "レジ処理日";
//            valueListItem23.DataValue = 4;
//            valueListItem23.DisplayText = "受注番号";
//            valueListItem24.DataValue = 5;
//            valueListItem24.DisplayText = "伝票番号";
//            valueListItem25.DataValue = 6;
//            valueListItem25.DisplayText = "レシート番号";
//            valueListItem26.DataValue = 7;
//            valueListItem26.DisplayText = "受付担当";
//            valueListItem27.DataValue = 8;
//            valueListItem27.DisplayText = "仕入担当";
//            valueListItem28.DataValue = 9;
//            valueListItem28.DisplayText = "得意先";
//            valueListItem29.DataValue = 10;
//            valueListItem29.DisplayText = "請求先";
//            valueListItem30.DataValue = 21;
//            valueListItem30.DisplayText = "商品";
//            valueListItem31.DataValue = 22;
//            valueListItem31.DisplayText = "キャリア";
//            valueListItem32.DataValue = 23;
//            valueListItem32.DisplayText = "事業者";
//            valueListItem33.DataValue = 24;
//            valueListItem33.DisplayText = "商品電話番号";
//            valueListItem34.DataValue = 25;
//            valueListItem34.DisplayText = "製造番号";
//            this.tComboEditor_FindCondition.Items.Add(valueListItem20);
//            this.tComboEditor_FindCondition.Items.Add(valueListItem21);
//            this.tComboEditor_FindCondition.Items.Add(valueListItem22);
//            this.tComboEditor_FindCondition.Items.Add(valueListItem23);
//            this.tComboEditor_FindCondition.Items.Add(valueListItem24);
//            this.tComboEditor_FindCondition.Items.Add(valueListItem25);
//            this.tComboEditor_FindCondition.Items.Add(valueListItem26);
//            this.tComboEditor_FindCondition.Items.Add(valueListItem27);
//            this.tComboEditor_FindCondition.Items.Add(valueListItem28);
//            this.tComboEditor_FindCondition.Items.Add(valueListItem29);
//            this.tComboEditor_FindCondition.Items.Add(valueListItem30);
//            this.tComboEditor_FindCondition.Items.Add(valueListItem31);
//            this.tComboEditor_FindCondition.Items.Add(valueListItem32);
//            this.tComboEditor_FindCondition.Items.Add(valueListItem33);
//            this.tComboEditor_FindCondition.Items.Add(valueListItem34);
//            this.tComboEditor_FindCondition.Location = new System.Drawing.Point(10, 62);
//            this.tComboEditor_FindCondition.MaxDropDownItems = 60;
//            this.tComboEditor_FindCondition.Name = "tComboEditor_FindCondition";
//            this.tComboEditor_FindCondition.Size = new System.Drawing.Size(315, 24);
//            this.tComboEditor_FindCondition.TabIndex = 5;
//            this.tComboEditor_FindCondition.SelectionChangeCommitted += new System.EventHandler(this.tComboEditor_FindCondition_SelectionChangeCommitted);
//            this.tComboEditor_FindCondition.ValueChanged += new System.EventHandler(this.tComboEditor_FindCondition_ValueChanged);
//            // 
//            // uLabel_FindCondition
//            // 
//            appearance27.BackColor = System.Drawing.Color.White;
//            appearance27.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(157)))), ((int)(((byte)(185)))));
//            appearance27.TextVAlign = Infragistics.Win.VAlign.Middle;
//            this.uLabel_FindCondition.Appearance = appearance27;
//            this.uLabel_FindCondition.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Solid;
//            this.uLabel_FindCondition.Cursor = System.Windows.Forms.Cursors.Default;
//            this.uLabel_FindCondition.Location = new System.Drawing.Point(10, 89);
//            this.uLabel_FindCondition.Name = "uLabel_FindCondition";
//            this.uLabel_FindCondition.Size = new System.Drawing.Size(289, 22);
//            this.uLabel_FindCondition.TabIndex = 18;
//            this.uLabel_FindCondition.Click += new System.EventHandler(this.uLabel_FindCondition_Click);
//            // 
//            // panel_ConditionSection
//            // 
//            this.panel_ConditionSection.BackColor = System.Drawing.Color.Transparent;
//            this.panel_ConditionSection.Controls.Add(this.tLine_SectionPanel);
//            this.panel_ConditionSection.Controls.Add(this.uLabel_DemandAddUpSecCd);
//            this.panel_ConditionSection.Controls.Add(this.tComboEditor_StockSectionCd);
//            this.panel_ConditionSection.Dock = System.Windows.Forms.DockStyle.Top;
//            this.panel_ConditionSection.Location = new System.Drawing.Point(0, 0);
//            this.panel_ConditionSection.Name = "panel_ConditionSection";
//            this.panel_ConditionSection.Size = new System.Drawing.Size(338, 32);
//            this.panel_ConditionSection.TabIndex = 0;
//            // 
//            // tLine_SectionPanel
//            // 
//            this.tLine_SectionPanel.BackColor = System.Drawing.Color.Transparent;
//            this.tLine_SectionPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(157)))), ((int)(((byte)(185)))));
//            this.tLine_SectionPanel.Location = new System.Drawing.Point(5, 28);
//            this.tLine_SectionPanel.Name = "tLine_SectionPanel";
//            this.tLine_SectionPanel.Size = new System.Drawing.Size(327, 1);
//            this.tLine_SectionPanel.TabIndex = 5;
//            // 
//            // uLabel_DemandAddUpSecCd
//            // 
//            appearance28.TextVAlign = Infragistics.Win.VAlign.Middle;
//            this.uLabel_DemandAddUpSecCd.Appearance = appearance28;
//            this.uLabel_DemandAddUpSecCd.Location = new System.Drawing.Point(10, 0);
//            this.uLabel_DemandAddUpSecCd.Name = "uLabel_DemandAddUpSecCd";
//            this.uLabel_DemandAddUpSecCd.Size = new System.Drawing.Size(67, 24);
//            this.uLabel_DemandAddUpSecCd.TabIndex = 4;
//            this.uLabel_DemandAddUpSecCd.Text = "売上拠点";
//            // 
//            // tComboEditor_StockSectionCd
//            // 
//            appearance29.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
//            this.tComboEditor_StockSectionCd.ActiveAppearance = appearance29;
//            this.tComboEditor_StockSectionCd.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
//            this.tComboEditor_StockSectionCd.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
//            this.tComboEditor_StockSectionCd.ImeMode = System.Windows.Forms.ImeMode.Disable;
//            appearance30.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
//            this.tComboEditor_StockSectionCd.ItemAppearance = appearance30;
//            this.tComboEditor_StockSectionCd.Location = new System.Drawing.Point(83, 0);
//            this.tComboEditor_StockSectionCd.Name = "tComboEditor_StockSectionCd";
//            this.tComboEditor_StockSectionCd.Size = new System.Drawing.Size(242, 24);
//            this.tComboEditor_StockSectionCd.TabIndex = 0;
//            // 
//            // uCheckEditor_CAddUpDisplay
//            // 
//            appearance31.FontData.SizeInPoints = 9F;
//            this.uCheckEditor_CAddUpDisplay.Appearance = appearance31;
//            this.uCheckEditor_CAddUpDisplay.BackColor = System.Drawing.Color.Transparent;
//            this.uCheckEditor_CAddUpDisplay.Location = new System.Drawing.Point(2, 3);
//            this.uCheckEditor_CAddUpDisplay.Name = "uCheckEditor_CAddUpDisplay";
//            this.uCheckEditor_CAddUpDisplay.Size = new System.Drawing.Size(110, 18);
//            this.uCheckEditor_CAddUpDisplay.TabIndex = 21;
//            this.uCheckEditor_CAddUpDisplay.Text = "締済伝票を表示";
//            // 
//            // tComboEditor_GridFontSize
//            // 
//            appearance32.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
//            this.tComboEditor_GridFontSize.ActiveAppearance = appearance32;
//            this.tComboEditor_GridFontSize.AutoSize = false;
//            this.tComboEditor_GridFontSize.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
//            this.tComboEditor_GridFontSize.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
//            appearance33.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
//            this.tComboEditor_GridFontSize.ItemAppearance = appearance33;
//            valueListItem35.DataValue = 9;
//            valueListItem35.DisplayText = "9";
//            valueListItem36.DataValue = 10;
//            valueListItem36.DisplayText = "10";
//            valueListItem37.DataValue = 11;
//            valueListItem37.DisplayText = "11";
//            valueListItem38.DataValue = 12;
//            valueListItem38.DisplayText = "12";
//            valueListItem39.DataValue = 14;
//            valueListItem39.DisplayText = "14";
//            this.tComboEditor_GridFontSize.Items.Add(valueListItem35);
//            this.tComboEditor_GridFontSize.Items.Add(valueListItem36);
//            this.tComboEditor_GridFontSize.Items.Add(valueListItem37);
//            this.tComboEditor_GridFontSize.Items.Add(valueListItem38);
//            this.tComboEditor_GridFontSize.Items.Add(valueListItem39);
//            this.tComboEditor_GridFontSize.Location = new System.Drawing.Point(72, 3);
//            this.tComboEditor_GridFontSize.Name = "tComboEditor_GridFontSize";
//            this.tComboEditor_GridFontSize.Size = new System.Drawing.Size(40, 18);
//            this.tComboEditor_GridFontSize.TabIndex = 18;
//            this.tComboEditor_GridFontSize.ValueChanged += new System.EventHandler(this.tComboEditor_GridFontSize_ValueChanged);
//            // 
//            // panel_Main
//            // 
//            this.panel_Main.BackColor = System.Drawing.Color.White;
//            this.panel_Main.Controls.Add(this.uGrid_Search);
//            this.panel_Main.Controls.Add(this.panel_Condition);
//            this.panel_Main.Controls.Add(this.uStatusBar_Main);
//            this.panel_Main.Location = new System.Drawing.Point(5, 5);
//            this.panel_Main.Name = "panel_Main";
//            this.panel_Main.Size = new System.Drawing.Size(350, 628);
//            this.panel_Main.TabIndex = 5;
//            // 
//            // uGrid_Search
//            // 
//            appearance34.BackColor = System.Drawing.Color.White;
//            appearance34.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(240)))), ((int)(((byte)(219)))));
//            appearance34.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
//            appearance34.ImageBackgroundStyle = Infragistics.Win.ImageBackgroundStyle.Stretched;
//            appearance34.TextVAlign = Infragistics.Win.VAlign.Middle;
//            this.uGrid_Search.DisplayLayout.Appearance = appearance34;
//            this.uGrid_Search.DisplayLayout.GroupByBox.Hidden = true;
//            this.uGrid_Search.DisplayLayout.InterBandSpacing = 10;
//            this.uGrid_Search.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No;
//            this.uGrid_Search.DisplayLayout.Override.AllowColSizing = Infragistics.Win.UltraWinGrid.AllowColSizing.Synchronized;
//            this.uGrid_Search.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
//            this.uGrid_Search.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
//            this.uGrid_Search.DisplayLayout.Override.AllowRowSummaries = Infragistics.Win.UltraWinGrid.AllowRowSummaries.False;
//            this.uGrid_Search.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.False;
//            appearance35.BackColor = System.Drawing.Color.Transparent;
//            this.uGrid_Search.DisplayLayout.Override.CardAreaAppearance = appearance35;
//            this.uGrid_Search.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
//            appearance36.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
//            appearance36.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
//            appearance36.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
//            appearance36.ForeColor = System.Drawing.Color.White;
//            appearance36.TextHAlign = Infragistics.Win.HAlign.Left;
//            appearance36.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
//            this.uGrid_Search.DisplayLayout.Override.HeaderAppearance = appearance36;
//            this.uGrid_Search.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortSingle;
//            appearance37.BackColor = System.Drawing.Color.Lavender;
//            this.uGrid_Search.DisplayLayout.Override.RowAlternateAppearance = appearance37;
//            appearance38.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(68)))), ((int)(((byte)(208)))));
//            this.uGrid_Search.DisplayLayout.Override.RowAppearance = appearance38;
//            this.uGrid_Search.DisplayLayout.Override.RowFilterAction = Infragistics.Win.UltraWinGrid.RowFilterAction.HideFilteredOutRows;
//            this.uGrid_Search.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand;
//            appearance39.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
//            appearance39.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
//            appearance39.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
//            this.uGrid_Search.DisplayLayout.Override.RowSelectorAppearance = appearance39;
//            this.uGrid_Search.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
//            this.uGrid_Search.DisplayLayout.Override.RowSelectorWidth = 12;
//            this.uGrid_Search.DisplayLayout.Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.AutoFixed;
//            appearance40.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(230)))), ((int)(((byte)(148)))));
//            appearance40.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(149)))), ((int)(((byte)(21)))));
//            appearance40.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
//            appearance40.ForeColor = System.Drawing.Color.Black;
//            this.uGrid_Search.DisplayLayout.Override.SelectedRowAppearance = appearance40;
//            this.uGrid_Search.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.None;
//            this.uGrid_Search.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.SingleAutoDrag;
//            this.uGrid_Search.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.SingleAutoDrag;
//            this.uGrid_Search.DisplayLayout.Override.TipStyleCell = Infragistics.Win.UltraWinGrid.TipStyle.Hide;
//            this.uGrid_Search.DisplayLayout.Override.TipStyleRowConnector = Infragistics.Win.UltraWinGrid.TipStyle.Hide;
//            this.uGrid_Search.DisplayLayout.Override.TipStyleScroll = Infragistics.Win.UltraWinGrid.TipStyle.Hide;
//            this.uGrid_Search.DisplayLayout.RowConnectorColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(167)))), ((int)(((byte)(191)))));
//            this.uGrid_Search.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.Solid;
//            this.uGrid_Search.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
//            this.uGrid_Search.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
//            this.uGrid_Search.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand;
//            this.uGrid_Search.Dock = System.Windows.Forms.DockStyle.Fill;
//            this.uGrid_Search.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
//            this.uGrid_Search.Location = new System.Drawing.Point(0, 226);
//            this.uGrid_Search.Name = "uGrid_Search";
//            this.uGrid_Search.Size = new System.Drawing.Size(350, 379);
//            this.uGrid_Search.TabIndex = 2;
//            this.uGrid_Search.InitializeRow += new Infragistics.Win.UltraWinGrid.InitializeRowEventHandler(this.uGrid_Search_InitializeRow);
//            this.uGrid_Search.MouseDown += new System.Windows.Forms.MouseEventHandler(this.uGrid_Search_MouseDown);
//            this.uGrid_Search.Click += new System.EventHandler(this.uGrid_Search_Click);
//            this.uGrid_Search.MouseLeaveElement += new Infragistics.Win.UIElementEventHandler(this.uGrid_Search_MouseLeaveElement);
//            this.uGrid_Search.MouseEnterElement += new Infragistics.Win.UIElementEventHandler(this.uGrid_Search_MouseEnterElement);
//            // 
//            // panel_Condition
//            // 
//            this.panel_Condition.BackColor = System.Drawing.Color.Transparent;
//            this.panel_Condition.Controls.Add(this.uExplorerBar_Condition);
//            this.panel_Condition.Dock = System.Windows.Forms.DockStyle.Top;
//            this.panel_Condition.Location = new System.Drawing.Point(0, 0);
//            this.panel_Condition.Name = "panel_Condition";
//            this.panel_Condition.Size = new System.Drawing.Size(350, 226);
//            this.panel_Condition.TabIndex = 1;
//            // 
//            // uExplorerBar_Condition
//            // 
//            this.uExplorerBar_Condition.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
//            this.uExplorerBar_Condition.Controls.Add(this.ultraExplorerBarContainerControl1);
//            this.uExplorerBar_Condition.Dock = System.Windows.Forms.DockStyle.Fill;
//            this.uExplorerBar_Condition.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
//            ultraExplorerBarGroup1.Container = this.ultraExplorerBarContainerControl1;
//            appearance41.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(240)))), ((int)(((byte)(219)))));
//            appearance41.BackGradientStyle = Infragistics.Win.GradientStyle.None;
//            ultraExplorerBarGroup1.Settings.AppearancesSmall.Appearance = appearance41;
//            appearance42.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(130)))), ((int)(((byte)(210)))));
//            appearance42.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(67)))), ((int)(((byte)(156)))));
//            appearance42.FontData.BoldAsString = "False";
//            appearance42.FontData.SizeInPoints = 11.25F;
//            appearance42.ForeColor = System.Drawing.Color.White;
//            ultraExplorerBarGroup1.Settings.AppearancesSmall.HeaderAppearance = appearance42;
//            ultraExplorerBarGroup1.Text = "売 上 伝 票 検 索";
//            this.uExplorerBar_Condition.Groups.AddRange(new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup[] {
//            ultraExplorerBarGroup1});
//            this.uExplorerBar_Condition.GroupSettings.Style = Infragistics.Win.UltraWinExplorerBar.GroupStyle.ControlContainer;
//            this.uExplorerBar_Condition.Location = new System.Drawing.Point(0, 0);
//            this.uExplorerBar_Condition.Name = "uExplorerBar_Condition";
//            this.uExplorerBar_Condition.ShowDefaultContextMenu = false;
//            this.uExplorerBar_Condition.Size = new System.Drawing.Size(350, 226);
//            this.uExplorerBar_Condition.Style = Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarStyle.Listbar;
//            this.uExplorerBar_Condition.SupportThemes = false;
//            this.uExplorerBar_Condition.TabIndex = 19;
//            this.uExplorerBar_Condition.ViewStyle = Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarViewStyle.VisualStudio2005;
//            // 
//            // uStatusBar_Main
//            // 
//            this.uStatusBar_Main.Controls.Add(this.uCheckEditor_CAddUpDisplay);
//            this.uStatusBar_Main.Controls.Add(this.tComboEditor_GridFontSize);
//            this.uStatusBar_Main.Location = new System.Drawing.Point(0, 605);
//            this.uStatusBar_Main.Name = "uStatusBar_Main";
//            ultraStatusPanel1.AccessibleName = "";
//            ultraStatusPanel1.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
//            ultraStatusPanel1.Control = this.uCheckEditor_CAddUpDisplay;
//            ultraStatusPanel1.Key = "StatusBarPanel_CAddUpDisplay";
//            ultraStatusPanel1.Style = Infragistics.Win.UltraWinStatusBar.PanelStyle.ControlContainer;
//            ultraStatusPanel1.Visible = false;
//            ultraStatusPanel1.Width = 110;
//            appearance43.FontData.SizeInPoints = 9F;
//            ultraStatusPanel2.Appearance = appearance43;
//            ultraStatusPanel2.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
//            ultraStatusPanel2.Key = "StatusBarPanel_Separator";
//            ultraStatusPanel2.Visible = false;
//            ultraStatusPanel2.Width = 1;
//            appearance44.FontData.SizeInPoints = 9F;
//            ultraStatusPanel3.Appearance = appearance44;
//            ultraStatusPanel3.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
//            ultraStatusPanel3.Key = "StatusBarPanel_FontSizeTitle";
//            ultraStatusPanel3.Padding = new System.Drawing.Size(5, 0);
//            ultraStatusPanel3.SizingMode = Infragistics.Win.UltraWinStatusBar.PanelSizingMode.Automatic;
//            ultraStatusPanel3.Text = "文字サイズ";
//            ultraStatusPanel4.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
//            ultraStatusPanel4.Control = this.tComboEditor_GridFontSize;
//            ultraStatusPanel4.Style = Infragistics.Win.UltraWinStatusBar.PanelStyle.ControlContainer;
//            ultraStatusPanel4.Width = 40;
//            this.uStatusBar_Main.Panels.AddRange(new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel[] {
//            ultraStatusPanel1,
//            ultraStatusPanel2,
//            ultraStatusPanel3,
//            ultraStatusPanel4});
//            this.uStatusBar_Main.Size = new System.Drawing.Size(350, 23);
//            this.uStatusBar_Main.TabIndex = 20;
//            this.uStatusBar_Main.ViewStyle = Infragistics.Win.UltraWinStatusBar.ViewStyle.Office2003;
//            // 
//            // dataSet_AcceptAnOrderSearch
//            // 
//            this.dataSet_AcceptAnOrderSearch.DataSetName = "NewDataSet";
//            this.dataSet_AcceptAnOrderSearch.Locale = new System.Globalization.CultureInfo("ja-JP");
//            // 
//            // timer_Search
//            // 
//            this.timer_Search.Interval = 1;
//            this.timer_Search.Tick += new System.EventHandler(this.timer_Search_Tick);
//            // 
//            // tRetKeyControl1
//            // 
//            this.tRetKeyControl1.OwnerForm = this.panel_Main;
//            this.tRetKeyControl1.Style = Broadleaf.Library.Windows.Forms.emFocusStyle.ByTab;
//            this.tRetKeyControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tRetKeyControl1_ChangeFocus);
//            // 
//            // tArrowKeyControl1
//            // 
//            this.tArrowKeyControl1.OwnerForm = this.panel_Main;
//            this.tArrowKeyControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tRetKeyControl1_ChangeFocus);
//            // 
//            // timer_Activated
//            // 
//            this.timer_Activated.Interval = 10;
//            this.timer_Activated.Tick += new System.EventHandler(this.timer_Activated_Tick);
//            // 
//            // timer_MessageUnDisp
//            // 
//            this.timer_MessageUnDisp.Interval = 3000;
//            this.timer_MessageUnDisp.Tick += new System.EventHandler(this.timer_MessageUnDisp_Tick);
//            // 
//            // contextMenu_Condition
//            // 
//            this.contextMenu_Condition.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
//            this.menuItem_MakerModelClear});
//            // 
//            // menuItem_MakerModelClear
//            // 
//            this.menuItem_MakerModelClear.Index = 0;
//            this.menuItem_MakerModelClear.Text = "クリア(&C)";
//            // 
//            // tComboEditor_SalesSlipKind
//            // 
//            appearance7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
//            this.tComboEditor_SalesSlipKind.ActiveAppearance = appearance7;
//            this.tComboEditor_SalesSlipKind.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
//            appearance8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
//            this.tComboEditor_SalesSlipKind.ItemAppearance = appearance8;
//            valueListItem14.DataValue = 0;
//            valueListItem14.DisplayText = "　";
//            valueListItem15.DataValue = 10;
//            valueListItem15.DisplayText = "売上";
//            valueListItem16.DataValue = 20;
//            valueListItem16.DisplayText = "売切";
//            valueListItem17.DataValue = 21;
//            valueListItem17.DisplayText = "売切計上";
//            valueListItem18.DataValue = 30;
//            valueListItem18.DisplayText = "委託";
//            valueListItem19.DataValue = 31;
//            valueListItem19.DisplayText = "委託計上";
//            this.tComboEditor_SalesSlipKind.Items.Add(valueListItem14);
//            this.tComboEditor_SalesSlipKind.Items.Add(valueListItem15);
//            this.tComboEditor_SalesSlipKind.Items.Add(valueListItem16);
//            this.tComboEditor_SalesSlipKind.Items.Add(valueListItem17);
//            this.tComboEditor_SalesSlipKind.Items.Add(valueListItem18);
//            this.tComboEditor_SalesSlipKind.Items.Add(valueListItem19);
//            this.tComboEditor_SalesSlipKind.Location = new System.Drawing.Point(83, 1);
//            this.tComboEditor_SalesSlipKind.Name = "tComboEditor_SalesSlipKind";
//            this.tComboEditor_SalesSlipKind.Size = new System.Drawing.Size(88, 24);
//            this.tComboEditor_SalesSlipKind.TabIndex = 0;
//            // 
//            // tComboEditor_SalesFormalCode
//            // 
//            appearance5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
//            this.tComboEditor_SalesFormalCode.ActiveAppearance = appearance5;
//            this.tComboEditor_SalesFormalCode.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
//            appearance6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
//            this.tComboEditor_SalesFormalCode.ItemAppearance = appearance6;
//            valueListItem10.DataValue = 0;
//            valueListItem10.DisplayText = "　";
//            valueListItem11.DataValue = 10;
//            valueListItem11.DisplayText = "店頭売上";
//            valueListItem12.DataValue = 11;
//            valueListItem12.DisplayText = "外販";
//            valueListItem13.DataValue = 20;
//            valueListItem13.DisplayText = "業務販売（売切）";
//            this.tComboEditor_SalesFormalCode.Items.Add(valueListItem10);
//            this.tComboEditor_SalesFormalCode.Items.Add(valueListItem11);
//            this.tComboEditor_SalesFormalCode.Items.Add(valueListItem12);
//            this.tComboEditor_SalesFormalCode.Items.Add(valueListItem13);
//            this.tComboEditor_SalesFormalCode.Location = new System.Drawing.Point(83, 27);
//            this.tComboEditor_SalesFormalCode.Name = "tComboEditor_SalesFormalCode";
//            this.tComboEditor_SalesFormalCode.Size = new System.Drawing.Size(88, 24);
//            this.tComboEditor_SalesFormalCode.TabIndex = 2;
//            // 
//            // tComboEditor_SalesSlipCd
//            // 
//            appearance3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
//            this.tComboEditor_SalesSlipCd.ActiveAppearance = appearance3;
//            this.tComboEditor_SalesSlipCd.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
//            appearance4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
//            this.tComboEditor_SalesSlipCd.ItemAppearance = appearance4;
//            valueListItem6.DataValue = -1;
//            valueListItem6.DisplayText = "　";
//            valueListItem7.DataValue = 0;
//            valueListItem7.DisplayText = "売上";
//            valueListItem8.DataValue = 1;
//            valueListItem8.DisplayText = "返品";
//            valueListItem9.DataValue = 2;
//            valueListItem9.DisplayText = "値引";
//            this.tComboEditor_SalesSlipCd.Items.Add(valueListItem6);
//            this.tComboEditor_SalesSlipCd.Items.Add(valueListItem7);
//            this.tComboEditor_SalesSlipCd.Items.Add(valueListItem8);
//            this.tComboEditor_SalesSlipCd.Items.Add(valueListItem9);
//            this.tComboEditor_SalesSlipCd.Location = new System.Drawing.Point(247, 1);
//            this.tComboEditor_SalesSlipCd.Name = "tComboEditor_SalesSlipCd";
//            this.tComboEditor_SalesSlipCd.Size = new System.Drawing.Size(79, 24);
//            this.tComboEditor_SalesSlipCd.TabIndex = 1;
//            // 
//            // tComboEditor_GoodsKindCode
//            // 
//            appearance1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
//            this.tComboEditor_GoodsKindCode.ActiveAppearance = appearance1;
//            this.tComboEditor_GoodsKindCode.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
//            appearance2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
//            this.tComboEditor_GoodsKindCode.ItemAppearance = appearance2;
//            valueListItem1.DataValue = -1;
//            valueListItem1.DisplayText = "　";
//            valueListItem2.DataValue = 0;
//            valueListItem2.DisplayText = "一般";
//            valueListItem3.DataValue = 1;
//            valueListItem3.DisplayText = "携帯電話";
//            valueListItem4.DataValue = 2;
//            valueListItem4.DisplayText = "付属品";
//            valueListItem5.DataValue = 3;
//            valueListItem5.DisplayText = "サービス業務";
//            this.tComboEditor_GoodsKindCode.Items.Add(valueListItem1);
//            this.tComboEditor_GoodsKindCode.Items.Add(valueListItem2);
//            this.tComboEditor_GoodsKindCode.Items.Add(valueListItem3);
//            this.tComboEditor_GoodsKindCode.Items.Add(valueListItem4);
//            this.tComboEditor_GoodsKindCode.Items.Add(valueListItem5);
//            this.tComboEditor_GoodsKindCode.Location = new System.Drawing.Point(247, 27);
//            this.tComboEditor_GoodsKindCode.Name = "tComboEditor_GoodsKindCode";
//            this.tComboEditor_GoodsKindCode.Size = new System.Drawing.Size(79, 24);
//            this.tComboEditor_GoodsKindCode.TabIndex = 3;
//            // 
//            // SFCMN00221UB
//            // 
//            this.BackColor = System.Drawing.Color.White;
//            this.Controls.Add(this.panel_Main);
//            this.Name = "SFCMN00221UB";
//            this.Size = new System.Drawing.Size(448, 646);
//            this.ultraExplorerBarContainerControl1.ResumeLayout(false);
//            this.panel_ConditionSub.ResumeLayout(false);
//            this.panel_ConditionSub.PerformLayout();
//            ((System.ComponentModel.ISupportInitialize)(this.tEdit_FindConditionCodeType)).EndInit();
//            ((System.ComponentModel.ISupportInitialize)(this.tNedit_FindConditionCodeType)).EndInit();
//            ((System.ComponentModel.ISupportInitialize)(this.tLine_ConditionPanel)).EndInit();
//            ((System.ComponentModel.ISupportInitialize)(this.tNedit_FindCondition)).EndInit();
//            ((System.ComponentModel.ISupportInitialize)(this.tEdit_FindCondition)).EndInit();
//            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_FindCondition)).EndInit();
//            this.panel_ConditionSection.ResumeLayout(false);
//            this.panel_ConditionSection.PerformLayout();
//            ((System.ComponentModel.ISupportInitialize)(this.tLine_SectionPanel)).EndInit();
//            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_StockSectionCd)).EndInit();
//            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_GridFontSize)).EndInit();
//            this.panel_Main.ResumeLayout(false);
//            ((System.ComponentModel.ISupportInitialize)(this.uGrid_Search)).EndInit();
//            this.panel_Condition.ResumeLayout(false);
//            ((System.ComponentModel.ISupportInitialize)(this.uExplorerBar_Condition)).EndInit();
//            this.uExplorerBar_Condition.ResumeLayout(false);
//            this.uStatusBar_Main.ResumeLayout(false);
//            ((System.ComponentModel.ISupportInitialize)(this.dataSet_AcceptAnOrderSearch)).EndInit();
//            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_SalesSlipKind)).EndInit();
//            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_SalesFormalCode)).EndInit();
//            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_SalesSlipCd)).EndInit();
//            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_GoodsKindCode)).EndInit();
//            this.ResumeLayout(false);

//        }
//        #endregion

//        private Infragistics.Win.UltraWinToolTip.UltraToolTipManager uToolTipManager_Information;
//        private Infragistics.Win.Misc.UltraLabel ultraLabel1;
//        private Infragistics.Win.Misc.UltraLabel ultraLabel9;
//        private Broadleaf.Library.Windows.Forms.TLine tLine_ConditionPanel;
//        private Infragistics.Win.Misc.UltraLabel ultraLabel16;
//        private Infragistics.Win.Misc.UltraLabel ultraLabel11;
//        private Broadleaf.Library.Windows.Forms.TNedit tNedit_FindConditionCodeType;
//        private Broadleaf.Library.Windows.Forms.TEdit tEdit_FindConditionCodeType;
//        private Broadleaf.Library.Windows.Forms.TComboEditor tComboEditor_GoodsKindCode;
//        private Broadleaf.Library.Windows.Forms.TComboEditor tComboEditor_SalesSlipCd;
//        private Broadleaf.Library.Windows.Forms.TComboEditor tComboEditor_SalesFormalCode;
//        private Broadleaf.Library.Windows.Forms.TComboEditor tComboEditor_SalesSlipKind;
//    }
//}

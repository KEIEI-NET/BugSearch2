namespace Broadleaf.Windows.Forms
{
    partial class MAKHN09620UB
    {
        /// <summary> 
        /// 必要なデザイナ変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region コンポーネント デザイナで生成されたコード

        /// <summary> 
        /// デザイナ サポートに必要なメソッドです。このメソッドの内容を 
        /// コード エディタで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.UltraToolbar ultraToolbar1 = new Infragistics.Win.UltraWinToolbars.UltraToolbar("UltraToolbar_Buttons");
            Infragistics.Win.UltraWinToolbars.ControlContainerTool controlContainerTool1 = new Infragistics.Win.UltraWinToolbars.ControlContainerTool("ControlContainerTool_RowInsert");
            Infragistics.Win.UltraWinToolbars.ControlContainerTool controlContainerTool2 = new Infragistics.Win.UltraWinToolbars.ControlContainerTool("ControlContainerTool_RowDelete");
            Infragistics.Win.UltraWinToolbars.ControlContainerTool controlContainerTool3 = new Infragistics.Win.UltraWinToolbars.ControlContainerTool("ControlContainerTool_RowInsert");
            Infragistics.Win.UltraWinToolbars.ControlContainerTool controlContainerTool4 = new Infragistics.Win.UltraWinToolbars.ControlContainerTool("ControlContainerTool_RowDelete");
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("", -1);
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            this.uButton_RowInsert = new Infragistics.Win.Misc.UltraButton();
            this.uButton_RowDelete = new Infragistics.Win.Misc.UltraButton();
            this.ViewButtonPanel = new System.Windows.Forms.Panel();
            this._MAKHN09620UB_Toolbars_Dock_Area_Left = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this.tToolbarsManager_Main = new Broadleaf.Library.Windows.Forms.TToolbarsManager(this.components);
            this._MAKHN09620UB_Toolbars_Dock_Area_Right = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._MAKHN09620UB_Toolbars_Dock_Area_Top = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._MAKHN09620UB_Toolbars_Dock_Area_Bottom = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this.pnl_uGrid = new System.Windows.Forms.Panel();
            this.uGrid_Details = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.ViewButtonPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tToolbarsManager_Main)).BeginInit();
            this.pnl_uGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uGrid_Details)).BeginInit();
            this.SuspendLayout();
            // 
            // uButton_RowInsert
            // 
            this.uButton_RowInsert.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uButton_RowInsert.Location = new System.Drawing.Point(0, 0);
            this.uButton_RowInsert.Name = "uButton_RowInsert";
            this.uButton_RowInsert.Size = new System.Drawing.Size(74, 27);
            this.uButton_RowInsert.TabIndex = 1;
            this.uButton_RowInsert.Text = "挿入(&I)";
            this.uButton_RowInsert.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.uButton_RowInsert.Click += new System.EventHandler(this.uButton_RowInsert_Click);
            this.uButton_RowInsert.EnabledChanged += new System.EventHandler(this.uButton_RowInsert_EnabledChanged);
            // 
            // uButton_RowDelete
            // 
            this.uButton_RowDelete.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uButton_RowDelete.Location = new System.Drawing.Point(90, 0);
            this.uButton_RowDelete.Name = "uButton_RowDelete";
            this.uButton_RowDelete.Size = new System.Drawing.Size(74, 27);
            this.uButton_RowDelete.TabIndex = 2;
            this.uButton_RowDelete.Text = "削除(&D)";
            this.uButton_RowDelete.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.uButton_RowDelete.Click += new System.EventHandler(this.uButton_RowDelete_Click);
            this.uButton_RowDelete.EnabledChanged += new System.EventHandler(this.uButton_RowDelete_EnabledChanged);
            // 
            // uGrid_Details
            // 
            appearance1.BackColor = System.Drawing.Color.White;
            appearance1.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            appearance1.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.uGrid_Details.DisplayLayout.Appearance = appearance1;
            ultraGridBand1.Override.AllowColSizing = Infragistics.Win.UltraWinGrid.AllowColSizing.None;
            this.uGrid_Details.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            appearance2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance2.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance2.BorderColor = System.Drawing.SystemColors.Window;
            this.uGrid_Details.DisplayLayout.GroupByBox.Appearance = appearance2;
            appearance3.ForeColor = System.Drawing.SystemColors.GrayText;
            this.uGrid_Details.DisplayLayout.GroupByBox.BandLabelAppearance = appearance3;
            this.uGrid_Details.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.uGrid_Details.DisplayLayout.GroupByBox.Hidden = true;
            appearance4.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance4.BackColor2 = System.Drawing.SystemColors.Control;
            appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance4.ForeColor = System.Drawing.SystemColors.GrayText;
            this.uGrid_Details.DisplayLayout.GroupByBox.PromptAppearance = appearance4;
            this.uGrid_Details.DisplayLayout.MaxColScrollRegions = 1;
            this.uGrid_Details.DisplayLayout.MaxRowScrollRegions = 1;
            appearance5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(230)))), ((int)(((byte)(148)))));
            appearance5.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(230)))), ((int)(((byte)(148)))));
            appearance5.ForeColor = System.Drawing.Color.Black;
            this.uGrid_Details.DisplayLayout.Override.ActiveCellAppearance = appearance5;
            this.uGrid_Details.DisplayLayout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.NotAllowed;
            this.uGrid_Details.DisplayLayout.Override.AllowColSizing = Infragistics.Win.UltraWinGrid.AllowColSizing.Free;
            this.uGrid_Details.DisplayLayout.Override.AllowColSwapping = Infragistics.Win.UltraWinGrid.AllowColSwapping.NotAllowed;
            this.uGrid_Details.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
            this.uGrid_Details.DisplayLayout.Override.AllowRowLayoutCellSizing = Infragistics.Win.UltraWinGrid.RowLayoutSizing.None;
            this.uGrid_Details.DisplayLayout.Override.AllowRowLayoutCellSpanSizing = Infragistics.Win.Layout.GridBagLayoutAllowSpanSizing.None;
            this.uGrid_Details.DisplayLayout.Override.AllowRowLayoutColMoving = Infragistics.Win.Layout.GridBagLayoutAllowMoving.None;
            this.uGrid_Details.DisplayLayout.Override.AllowRowLayoutLabelSizing = Infragistics.Win.UltraWinGrid.RowLayoutSizing.None;
            this.uGrid_Details.DisplayLayout.Override.AllowRowLayoutLabelSpanSizing = Infragistics.Win.Layout.GridBagLayoutAllowSpanSizing.None;
            this.uGrid_Details.DisplayLayout.Override.AllowRowSummaries = Infragistics.Win.UltraWinGrid.AllowRowSummaries.False;
            this.uGrid_Details.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.True;
            this.uGrid_Details.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.Edit;
            appearance6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance6.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance6.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance6.ForeColor = System.Drawing.Color.White;
            appearance6.ForeColorDisabled = System.Drawing.Color.White;
            appearance6.TextHAlignAsString = "Center";
            appearance6.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
            this.uGrid_Details.DisplayLayout.Override.HeaderAppearance = appearance6;
            appearance7.BackColor = System.Drawing.Color.Lavender;
            this.uGrid_Details.DisplayLayout.Override.RowAlternateAppearance = appearance7;
            appearance8.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(157)))), ((int)(((byte)(185)))));
            appearance8.TextVAlignAsString = "Middle";
            this.uGrid_Details.DisplayLayout.Override.RowAppearance = appearance8;
            this.uGrid_Details.DisplayLayout.Override.RowFilterAction = Infragistics.Win.UltraWinGrid.RowFilterAction.HideFilteredOutRows;
            appearance9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance9.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance9.ForeColor = System.Drawing.Color.White;
            this.uGrid_Details.DisplayLayout.Override.RowSelectorAppearance = appearance9;
            this.uGrid_Details.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True;
            this.uGrid_Details.DisplayLayout.Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.AutoFixed;
            appearance10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(230)))), ((int)(((byte)(148)))));
            appearance10.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(149)))), ((int)(((byte)(21)))));
            appearance10.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance10.ForeColor = System.Drawing.Color.Black;
            this.uGrid_Details.DisplayLayout.Override.SelectedRowAppearance = appearance10;
            this.uGrid_Details.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.Single;
            this.uGrid_Details.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.SingleAutoDrag;
            this.uGrid_Details.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Single;
            this.uGrid_Details.DisplayLayout.Override.TipStyleScroll = Infragistics.Win.UltraWinGrid.TipStyle.Hide;
            this.uGrid_Details.DisplayLayout.RowConnectorColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(167)))), ((int)(((byte)(191)))));
            this.uGrid_Details.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.uGrid_Details.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.uGrid_Details.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand;
            this.uGrid_Details.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uGrid_Details.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.uGrid_Details.Location = new System.Drawing.Point(0, 29);
            this.uGrid_Details.Name = "uGrid_Details";
            this.uGrid_Details.Size = new System.Drawing.Size(952, 440);
            this.uGrid_Details.TabIndex = 3;
            this.uGrid_Details.SelectionDrag += new System.ComponentModel.CancelEventHandler(this.uGrid_Details_SelectionDrag);
            this.uGrid_Details.BeforeCellUpdate += new Infragistics.Win.UltraWinGrid.BeforeCellUpdateEventHandler(this.uGrid_Details_BeforeCellUpdate);
            this.uGrid_Details.KeyUp += new System.Windows.Forms.KeyEventHandler(this.uGrid_Details_KeyUp);
            this.uGrid_Details.MouseUp += new System.Windows.Forms.MouseEventHandler(this.uGrid_Details_MouseUp);
            this.uGrid_Details.AfterExitEditMode += new System.EventHandler(this.uGrid_Details_AfterExitEditMode);
            this.uGrid_Details.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.uGrid_Details_InitializeLayout);
            this.uGrid_Details.MouseLeaveElement += new Infragistics.Win.UIElementEventHandler(this.uGrid_Details_MouseLeaveElement);
            this.uGrid_Details.BeforeExitEditMode += new Infragistics.Win.UltraWinGrid.BeforeExitEditModeEventHandler(this.uGrid_Details_BeforeExitEditMode);
            this.uGrid_Details.CellDataError += new Infragistics.Win.UltraWinGrid.CellDataErrorEventHandler(this.uGrid_Details_CellDataError);
            this.uGrid_Details.Enter += new System.EventHandler(this.uGrid_Details_Enter);
            this.uGrid_Details.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.uGrid_Details_KeyPress);
            this.uGrid_Details.MouseEnterElement += new Infragistics.Win.UIElementEventHandler(this.uGrid_Details_MouseEnterElement);
            this.uGrid_Details.AfterPerformAction += new Infragistics.Win.UltraWinGrid.AfterUltraGridPerformActionEventHandler(this.uGrid_Details_AfterPerformAction);
            this.uGrid_Details.Leave += new System.EventHandler(this.uGrid_Details_Leave);
            this.uGrid_Details.KeyDown += new System.Windows.Forms.KeyEventHandler(this.uGrid_Details_KeyDown);
            this.uGrid_Details.BeforeCellActivate += new Infragistics.Win.UltraWinGrid.CancelableCellEventHandler(this.uGrid_Details_BeforeCellActivate);
            this.uGrid_Details.AfterCellActivate += new System.EventHandler(this.uGrid_Details_AfterCellActivate);
            // 
            // ViewButtonPanel
            // 
            this.ViewButtonPanel.BackColor = System.Drawing.Color.GhostWhite;
            this.ViewButtonPanel.Controls.Add(this.uButton_RowDelete);
            this.ViewButtonPanel.Controls.Add(this.uButton_RowInsert);
            this.ViewButtonPanel.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.ViewButtonPanel.Location = new System.Drawing.Point(3, 71);
            this.ViewButtonPanel.Name = "ViewButtonPanel";
            this.ViewButtonPanel.Size = new System.Drawing.Size(821, 52);
            this.ViewButtonPanel.TabIndex = 0;
            this.ViewButtonPanel.TabStop = true;
            this.ViewButtonPanel.Visible = false;
            // 
            // _MAKHN09620UB_Toolbars_Dock_Area_Left
            // 
            this._MAKHN09620UB_Toolbars_Dock_Area_Left.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._MAKHN09620UB_Toolbars_Dock_Area_Left.AlphaBlendMode = Infragistics.Win.AlphaBlendMode.Disabled;
            this._MAKHN09620UB_Toolbars_Dock_Area_Left.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(254)))));
            this._MAKHN09620UB_Toolbars_Dock_Area_Left.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Left;
            this._MAKHN09620UB_Toolbars_Dock_Area_Left.ForeColor = System.Drawing.SystemColors.ControlText;
            this._MAKHN09620UB_Toolbars_Dock_Area_Left.Location = new System.Drawing.Point(0, 29);
            this._MAKHN09620UB_Toolbars_Dock_Area_Left.Name = "_MAKHN09620UB_Toolbars_Dock_Area_Left";
            this._MAKHN09620UB_Toolbars_Dock_Area_Left.Size = new System.Drawing.Size(0, 440);
            this._MAKHN09620UB_Toolbars_Dock_Area_Left.ToolbarsManager = this.tToolbarsManager_Main;
            // 
            // tToolbarsManager_Main
            // 
            this.tToolbarsManager_Main.AlphaBlendMode = Infragistics.Win.AlphaBlendMode.Disabled;
            appearance11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(254)))));
            this.tToolbarsManager_Main.Appearance = appearance11;
            this.tToolbarsManager_Main.DesignerFlags = 1;
            this.tToolbarsManager_Main.DockWithinContainer = this;
            this.tToolbarsManager_Main.LockToolbars = true;
            this.tToolbarsManager_Main.ShowFullMenusDelay = 500;
            this.tToolbarsManager_Main.ShowQuickCustomizeButton = false;
            ultraToolbar1.DockedColumn = 0;
            ultraToolbar1.DockedRow = 0;
            controlContainerTool1.ControlName = "uButton_RowInsert";
            controlContainerTool1.InstanceProps.Width = 71;
            controlContainerTool2.ControlName = "uButton_RowDelete";
            ultraToolbar1.NonInheritedTools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            controlContainerTool1,
            controlContainerTool2});
            ultraToolbar1.Text = "UltraToolbar_Buttons";
            this.tToolbarsManager_Main.Toolbars.AddRange(new Infragistics.Win.UltraWinToolbars.UltraToolbar[] {
            ultraToolbar1});
            controlContainerTool3.ControlName = "uButton_RowInsert";
            controlContainerTool3.SharedProps.Caption = "ControlContainerTool_RowInsert";
            controlContainerTool3.SharedProps.Width = 71;
            controlContainerTool4.ControlName = "uButton_RowDelete";
            controlContainerTool4.SharedProps.Caption = "ControlContainerTool_RowDelete";
            this.tToolbarsManager_Main.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            controlContainerTool3,
            controlContainerTool4});
            this.tToolbarsManager_Main.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // _MAKHN09620UB_Toolbars_Dock_Area_Right
            // 
            this._MAKHN09620UB_Toolbars_Dock_Area_Right.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._MAKHN09620UB_Toolbars_Dock_Area_Right.AlphaBlendMode = Infragistics.Win.AlphaBlendMode.Disabled;
            this._MAKHN09620UB_Toolbars_Dock_Area_Right.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(254)))));
            this._MAKHN09620UB_Toolbars_Dock_Area_Right.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Right;
            this._MAKHN09620UB_Toolbars_Dock_Area_Right.ForeColor = System.Drawing.SystemColors.ControlText;
            this._MAKHN09620UB_Toolbars_Dock_Area_Right.Location = new System.Drawing.Point(952, 29);
            this._MAKHN09620UB_Toolbars_Dock_Area_Right.Name = "_MAKHN09620UB_Toolbars_Dock_Area_Right";
            this._MAKHN09620UB_Toolbars_Dock_Area_Right.Size = new System.Drawing.Size(0, 440);
            this._MAKHN09620UB_Toolbars_Dock_Area_Right.ToolbarsManager = this.tToolbarsManager_Main;
            // 
            // _MAKHN09620UB_Toolbars_Dock_Area_Top
            // 
            this._MAKHN09620UB_Toolbars_Dock_Area_Top.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._MAKHN09620UB_Toolbars_Dock_Area_Top.AlphaBlendMode = Infragistics.Win.AlphaBlendMode.Disabled;
            this._MAKHN09620UB_Toolbars_Dock_Area_Top.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(254)))));
            this._MAKHN09620UB_Toolbars_Dock_Area_Top.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Top;
            this._MAKHN09620UB_Toolbars_Dock_Area_Top.ForeColor = System.Drawing.SystemColors.ControlText;
            this._MAKHN09620UB_Toolbars_Dock_Area_Top.Location = new System.Drawing.Point(0, 0);
            this._MAKHN09620UB_Toolbars_Dock_Area_Top.Name = "_MAKHN09620UB_Toolbars_Dock_Area_Top";
            this._MAKHN09620UB_Toolbars_Dock_Area_Top.Size = new System.Drawing.Size(952, 29);
            this._MAKHN09620UB_Toolbars_Dock_Area_Top.ToolbarsManager = this.tToolbarsManager_Main;
            // 
            // _MAKHN09620UB_Toolbars_Dock_Area_Bottom
            // 
            this._MAKHN09620UB_Toolbars_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._MAKHN09620UB_Toolbars_Dock_Area_Bottom.AlphaBlendMode = Infragistics.Win.AlphaBlendMode.Disabled;
            this._MAKHN09620UB_Toolbars_Dock_Area_Bottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(254)))));
            this._MAKHN09620UB_Toolbars_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Bottom;
            this._MAKHN09620UB_Toolbars_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText;
            this._MAKHN09620UB_Toolbars_Dock_Area_Bottom.Location = new System.Drawing.Point(0, 469);
            this._MAKHN09620UB_Toolbars_Dock_Area_Bottom.Name = "_MAKHN09620UB_Toolbars_Dock_Area_Bottom";
            this._MAKHN09620UB_Toolbars_Dock_Area_Bottom.Size = new System.Drawing.Size(952, 0);
            this._MAKHN09620UB_Toolbars_Dock_Area_Bottom.ToolbarsManager = this.tToolbarsManager_Main;
            // 
            // pnl_uGrid
            // 
            this.pnl_uGrid.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(254)))));
            this.pnl_uGrid.Controls.Add(this.uGrid_Details);
            this.pnl_uGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_uGrid.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.pnl_uGrid.Location = new System.Drawing.Point(0, 27);
            this.pnl_uGrid.Name = "pnl_uGrid";
            this.pnl_uGrid.Size = new System.Drawing.Size(952, 440);
            this.pnl_uGrid.TabIndex = 8;
            // 
            // MAKHN09620UB
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Controls.Add(this.pnl_uGrid);
            this.Controls.Add(this.ViewButtonPanel);
            this.Controls.Add(this._MAKHN09620UB_Toolbars_Dock_Area_Left);
            this.Controls.Add(this._MAKHN09620UB_Toolbars_Dock_Area_Right);
            this.Controls.Add(this._MAKHN09620UB_Toolbars_Dock_Area_Top);
            this.Controls.Add(this._MAKHN09620UB_Toolbars_Dock_Area_Bottom);
            this.Name = "MAKHN09620UB";
            this.Size = new System.Drawing.Size(952, 469);
            this.ViewButtonPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tToolbarsManager_Main)).EndInit();
            this.pnl_uGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uGrid_Details)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel ViewButtonPanel;
        private Infragistics.Win.Misc.UltraButton uButton_RowInsert;
        private Broadleaf.Library.Windows.Forms.TToolbarsManager tToolbarsManager_Main;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _MAKHN09620UB_Toolbars_Dock_Area_Left;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _MAKHN09620UB_Toolbars_Dock_Area_Right;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _MAKHN09620UB_Toolbars_Dock_Area_Top;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _MAKHN09620UB_Toolbars_Dock_Area_Bottom;
        private Infragistics.Win.Misc.UltraButton uButton_RowDelete;
        private System.Windows.Forms.Panel pnl_uGrid;
        internal Infragistics.Win.UltraWinGrid.UltraGrid uGrid_Details;


    }
}

namespace Broadleaf.Windows.Forms
{
    partial class PMREC09021UE
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
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.UltraToolbar ultraToolbar1 = new Infragistics.Win.UltraWinToolbars.UltraToolbar("UltraToolbar_Standard");
            Infragistics.Win.UltraWinToolbars.ControlContainerTool controlContainerTool1 = new Infragistics.Win.UltraWinToolbars.ControlContainerTool("ButtonTool_RowDelete");
            Infragistics.Win.UltraWinToolbars.ControlContainerTool controlContainerTool2 = new Infragistics.Win.UltraWinToolbars.ControlContainerTool("ButtonTool_RowDelete");
            Infragistics.Win.UltraWinToolbars.ControlContainerTool controlContainerTool3 = new Infragistics.Win.UltraWinToolbars.ControlContainerTool("ButtonTool_AllRowDelete");
            Infragistics.Win.UltraWinToolbars.ControlContainerTool controlContainerTool4 = new Infragistics.Win.UltraWinToolbars.ControlContainerTool("ButtonTool_Revival");
            Infragistics.Win.UltraWinToolbars.ControlContainerTool controlContainerTool5 = new Infragistics.Win.UltraWinToolbars.ControlContainerTool("ButtonTool_GetPriceDate");
            this.panel_DetailInput = new System.Windows.Forms.Panel();
            this.ViewButtonPanel = new System.Windows.Forms.Panel();
            this.uButton_RowDelete = new Infragistics.Win.Misc.UltraButton();
            this.uGrid_Details = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this._PMREC09021UE_Toolbars_Dock_Area_Left = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this.tToolbarsManager_MainMenu = new Broadleaf.Library.Windows.Forms.TToolbarsManager(this.components);
            this._PMREC09021UE_Toolbars_Dock_Area_Right = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._PMREC09021UE_Toolbars_Dock_Area_Top = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._PMREC09021UE_Toolbars_Dock_Area_Bottom = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this.panel_DetailInput.SuspendLayout();
            this.ViewButtonPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uGrid_Details)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tToolbarsManager_MainMenu)).BeginInit();
            this.SuspendLayout();
            // 
            // panel_DetailInput
            // 
            this.panel_DetailInput.Controls.Add(this.ViewButtonPanel);
            this.panel_DetailInput.Controls.Add(this.uGrid_Details);
            this.panel_DetailInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_DetailInput.Location = new System.Drawing.Point(0, 29);
            this.panel_DetailInput.Margin = new System.Windows.Forms.Padding(4);
            this.panel_DetailInput.Name = "panel_DetailInput";
            this.panel_DetailInput.Size = new System.Drawing.Size(984, 478);
            this.panel_DetailInput.TabIndex = 12346;
            // 
            // ViewButtonPanel
            // 
            this.ViewButtonPanel.BackColor = System.Drawing.Color.GhostWhite;
            this.ViewButtonPanel.Controls.Add(this.uButton_RowDelete);
            this.ViewButtonPanel.Location = new System.Drawing.Point(419, 98);
            this.ViewButtonPanel.Margin = new System.Windows.Forms.Padding(4);
            this.ViewButtonPanel.Name = "ViewButtonPanel";
            this.ViewButtonPanel.Size = new System.Drawing.Size(501, 95);
            this.ViewButtonPanel.TabIndex = 7;
            this.ViewButtonPanel.Visible = false;
            // 
            // uButton_RowDelete
            // 
            this.uButton_RowDelete.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uButton_RowDelete.Location = new System.Drawing.Point(4, 4);
            this.uButton_RowDelete.Margin = new System.Windows.Forms.Padding(4);
            this.uButton_RowDelete.Name = "uButton_RowDelete";
            this.uButton_RowDelete.Size = new System.Drawing.Size(112, 27);
            this.uButton_RowDelete.TabIndex = 3;
            this.uButton_RowDelete.TabStop = false;
            this.uButton_RowDelete.Text = "行削除(F3)";
            this.uButton_RowDelete.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.uButton_RowDelete.Visible = false;
            this.uButton_RowDelete.Click += new System.EventHandler(this.uButton_RowDelete_Click);
            // 
            // uGrid_Details
            // 
            appearance5.BackColor = System.Drawing.Color.White;
            appearance5.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            appearance5.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.uGrid_Details.DisplayLayout.Appearance = appearance5;
            this.uGrid_Details.DisplayLayout.GroupByBox.Hidden = true;
            this.uGrid_Details.DisplayLayout.InterBandSpacing = 10;
            this.uGrid_Details.DisplayLayout.MaxColScrollRegions = 1;
            this.uGrid_Details.DisplayLayout.MaxRowScrollRegions = 1;
            appearance6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(230)))), ((int)(((byte)(148)))));
            appearance6.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(230)))), ((int)(((byte)(148)))));
            appearance6.ForeColor = System.Drawing.Color.Black;
            this.uGrid_Details.DisplayLayout.Override.ActiveCellAppearance = appearance6;
            this.uGrid_Details.DisplayLayout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.NotAllowed;
            this.uGrid_Details.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.uGrid_Details.DisplayLayout.Override.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
            appearance7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance7.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance7.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance7.ForeColor = System.Drawing.Color.White;
            appearance7.ForeColorDisabled = System.Drawing.Color.White;
            appearance7.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
            this.uGrid_Details.DisplayLayout.Override.HeaderAppearance = appearance7;
            this.uGrid_Details.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            appearance8.BackColor = System.Drawing.Color.Lavender;
            this.uGrid_Details.DisplayLayout.Override.RowAlternateAppearance = appearance8;
            appearance9.BackColor = System.Drawing.Color.White;
            appearance9.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(157)))), ((int)(((byte)(185)))));
            appearance9.TextVAlignAsString = "Middle";
            this.uGrid_Details.DisplayLayout.Override.RowAppearance = appearance9;
            appearance10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance10.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance10.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance10.ForeColor = System.Drawing.Color.White;
            this.uGrid_Details.DisplayLayout.Override.RowSelectorAppearance = appearance10;
            this.uGrid_Details.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(230)))), ((int)(((byte)(148)))));
            appearance11.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(149)))), ((int)(((byte)(21)))));
            appearance11.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance11.ForeColor = System.Drawing.Color.Black;
            this.uGrid_Details.DisplayLayout.Override.SelectedRowAppearance = appearance11;
            this.uGrid_Details.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.Single;
            this.uGrid_Details.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.uGrid_Details.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.uGrid_Details.DisplayLayout.RowConnectorColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(167)))), ((int)(((byte)(191)))));
            this.uGrid_Details.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.uGrid_Details.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.uGrid_Details.DisplayLayout.UseFixedHeaders = true;
            this.uGrid_Details.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand;
            this.uGrid_Details.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uGrid_Details.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uGrid_Details.Location = new System.Drawing.Point(0, 0);
            this.uGrid_Details.Margin = new System.Windows.Forms.Padding(4);
            this.uGrid_Details.Name = "uGrid_Details";
            this.uGrid_Details.Size = new System.Drawing.Size(984, 478);
            this.uGrid_Details.TabIndex = 6;
            this.uGrid_Details.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.uGrid_Details_InitializeLayout);
            this.uGrid_Details.CellDataError += new Infragistics.Win.UltraWinGrid.CellDataErrorEventHandler(this.uGrid_Details_CellDataError);
            this.uGrid_Details.AfterCellUpdate += new Infragistics.Win.UltraWinGrid.CellEventHandler(this.uGrid_Details_AfterCellUpdate);
            this.uGrid_Details.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.uGrid_Details_KeyPress);
            this.uGrid_Details.CellChange += new Infragistics.Win.UltraWinGrid.CellEventHandler(this.uGrid_Details_CellChange);
            this.uGrid_Details.KeyDown += new System.Windows.Forms.KeyEventHandler(this.uGrid_Details_KeyDown);
            this.uGrid_Details.BeforeCellActivate += new Infragistics.Win.UltraWinGrid.CancelableCellEventHandler(this.uGrid_Details_BeforeCellActivate);
            this.uGrid_Details.AfterCellActivate += new System.EventHandler(this.uGrid_Details_AfterCellActivate);
            // 
            // _PMREC09021UE_Toolbars_Dock_Area_Left
            // 
            this._PMREC09021UE_Toolbars_Dock_Area_Left.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._PMREC09021UE_Toolbars_Dock_Area_Left.AlphaBlendMode = Infragistics.Win.AlphaBlendMode.Disabled;
            this._PMREC09021UE_Toolbars_Dock_Area_Left.BackColor = System.Drawing.Color.GhostWhite;
            this._PMREC09021UE_Toolbars_Dock_Area_Left.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Left;
            this._PMREC09021UE_Toolbars_Dock_Area_Left.ForeColor = System.Drawing.SystemColors.ControlText;
            this._PMREC09021UE_Toolbars_Dock_Area_Left.Location = new System.Drawing.Point(0, 29);
            this._PMREC09021UE_Toolbars_Dock_Area_Left.Margin = new System.Windows.Forms.Padding(4);
            this._PMREC09021UE_Toolbars_Dock_Area_Left.Name = "_PMREC09021UE_Toolbars_Dock_Area_Left";
            this._PMREC09021UE_Toolbars_Dock_Area_Left.Size = new System.Drawing.Size(0, 478);
            this._PMREC09021UE_Toolbars_Dock_Area_Left.ToolbarsManager = this.tToolbarsManager_MainMenu;
            // 
            // tToolbarsManager_MainMenu
            // 
            this.tToolbarsManager_MainMenu.AlphaBlendMode = Infragistics.Win.AlphaBlendMode.Disabled;
            appearance2.BackColor = System.Drawing.Color.GhostWhite;
            this.tToolbarsManager_MainMenu.Appearance = appearance2;
            this.tToolbarsManager_MainMenu.DesignerFlags = 1;
            this.tToolbarsManager_MainMenu.DockWithinContainer = this;
            this.tToolbarsManager_MainMenu.LockToolbars = true;
            this.tToolbarsManager_MainMenu.RuntimeCustomizationOptions = Infragistics.Win.UltraWinToolbars.RuntimeCustomizationOptions.None;
            this.tToolbarsManager_MainMenu.ShowFullMenusDelay = 500;
            this.tToolbarsManager_MainMenu.ShowQuickCustomizeButton = false;
            ultraToolbar1.DockedColumn = 0;
            ultraToolbar1.DockedRow = 0;
            controlContainerTool1.ControlName = "uButton_RowDelete";
            controlContainerTool1.InstanceProps.Width = 114;
            ultraToolbar1.NonInheritedTools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            controlContainerTool1});
            ultraToolbar1.Settings.AllowFloating = Infragistics.Win.DefaultableBoolean.False;
            ultraToolbar1.Settings.AllowHiding = Infragistics.Win.DefaultableBoolean.False;
            ultraToolbar1.Settings.CaptionPlacement = Infragistics.Win.TextPlacement.BelowImage;
            ultraToolbar1.Text = "標準";
            this.tToolbarsManager_MainMenu.Toolbars.AddRange(new Infragistics.Win.UltraWinToolbars.UltraToolbar[] {
            ultraToolbar1});
            controlContainerTool2.ControlName = "uButton_RowDelete";
            controlContainerTool2.SharedProps.Caption = "行削除(F3)";
            controlContainerTool2.SharedProps.CustomizerCaption = "行削除ボタン";
            controlContainerTool2.SharedProps.CustomizerDescription = "行削除ボタン";
            controlContainerTool2.SharedProps.Shortcut = System.Windows.Forms.Shortcut.F3;
            controlContainerTool2.SharedProps.Width = 114;
            controlContainerTool3.SharedProps.Caption = "全削除(F8)";
            controlContainerTool3.SharedProps.CustomizerCaption = "全削除ボタン";
            controlContainerTool3.SharedProps.CustomizerDescription = "全削除ボタン";
            controlContainerTool3.SharedProps.Shortcut = System.Windows.Forms.Shortcut.F8;
            controlContainerTool3.SharedProps.Width = 114;
            controlContainerTool4.SharedProps.Caption = "復活(F4)";
            controlContainerTool4.SharedProps.CustomizerCaption = "復活ボタン";
            controlContainerTool4.SharedProps.CustomizerDescription = "復活ボタン";
            controlContainerTool4.SharedProps.Shortcut = System.Windows.Forms.Shortcut.F4;
            controlContainerTool4.SharedProps.Width = 114;
            controlContainerTool5.SharedProps.Caption = "価格日取得(F6)";
            controlContainerTool5.SharedProps.CustomizerCaption = "価格日取得ボタン";
            controlContainerTool5.SharedProps.CustomizerDescription = "価格日取得ボタン";
            controlContainerTool5.SharedProps.Shortcut = System.Windows.Forms.Shortcut.F6;
            controlContainerTool5.SharedProps.Width = 143;
            this.tToolbarsManager_MainMenu.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            controlContainerTool2,
            controlContainerTool3,
            controlContainerTool4,
            controlContainerTool5});
            this.tToolbarsManager_MainMenu.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.tToolbarsManager_MainMenu.ToolClick += new Infragistics.Win.UltraWinToolbars.ToolClickEventHandler(this.tToolbarsManager_MainMenu_ToolClick);
            // 
            // _PMREC09021UE_Toolbars_Dock_Area_Right
            // 
            this._PMREC09021UE_Toolbars_Dock_Area_Right.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._PMREC09021UE_Toolbars_Dock_Area_Right.AlphaBlendMode = Infragistics.Win.AlphaBlendMode.Disabled;
            this._PMREC09021UE_Toolbars_Dock_Area_Right.BackColor = System.Drawing.Color.GhostWhite;
            this._PMREC09021UE_Toolbars_Dock_Area_Right.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Right;
            this._PMREC09021UE_Toolbars_Dock_Area_Right.ForeColor = System.Drawing.SystemColors.ControlText;
            this._PMREC09021UE_Toolbars_Dock_Area_Right.Location = new System.Drawing.Point(984, 29);
            this._PMREC09021UE_Toolbars_Dock_Area_Right.Margin = new System.Windows.Forms.Padding(4);
            this._PMREC09021UE_Toolbars_Dock_Area_Right.Name = "_PMREC09021UE_Toolbars_Dock_Area_Right";
            this._PMREC09021UE_Toolbars_Dock_Area_Right.Size = new System.Drawing.Size(0, 478);
            this._PMREC09021UE_Toolbars_Dock_Area_Right.ToolbarsManager = this.tToolbarsManager_MainMenu;
            // 
            // _PMREC09021UE_Toolbars_Dock_Area_Top
            // 
            this._PMREC09021UE_Toolbars_Dock_Area_Top.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._PMREC09021UE_Toolbars_Dock_Area_Top.AlphaBlendMode = Infragistics.Win.AlphaBlendMode.Disabled;
            this._PMREC09021UE_Toolbars_Dock_Area_Top.BackColor = System.Drawing.Color.GhostWhite;
            this._PMREC09021UE_Toolbars_Dock_Area_Top.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Top;
            this._PMREC09021UE_Toolbars_Dock_Area_Top.ForeColor = System.Drawing.SystemColors.ControlText;
            this._PMREC09021UE_Toolbars_Dock_Area_Top.Location = new System.Drawing.Point(0, 0);
            this._PMREC09021UE_Toolbars_Dock_Area_Top.Margin = new System.Windows.Forms.Padding(4);
            this._PMREC09021UE_Toolbars_Dock_Area_Top.Name = "_PMREC09021UE_Toolbars_Dock_Area_Top";
            this._PMREC09021UE_Toolbars_Dock_Area_Top.Size = new System.Drawing.Size(984, 29);
            this._PMREC09021UE_Toolbars_Dock_Area_Top.ToolbarsManager = this.tToolbarsManager_MainMenu;
            // 
            // _PMREC09021UE_Toolbars_Dock_Area_Bottom
            // 
            this._PMREC09021UE_Toolbars_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._PMREC09021UE_Toolbars_Dock_Area_Bottom.AlphaBlendMode = Infragistics.Win.AlphaBlendMode.Disabled;
            this._PMREC09021UE_Toolbars_Dock_Area_Bottom.BackColor = System.Drawing.Color.GhostWhite;
            this._PMREC09021UE_Toolbars_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Bottom;
            this._PMREC09021UE_Toolbars_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText;
            this._PMREC09021UE_Toolbars_Dock_Area_Bottom.Location = new System.Drawing.Point(0, 507);
            this._PMREC09021UE_Toolbars_Dock_Area_Bottom.Margin = new System.Windows.Forms.Padding(4);
            this._PMREC09021UE_Toolbars_Dock_Area_Bottom.Name = "_PMREC09021UE_Toolbars_Dock_Area_Bottom";
            this._PMREC09021UE_Toolbars_Dock_Area_Bottom.Size = new System.Drawing.Size(984, 0);
            this._PMREC09021UE_Toolbars_Dock_Area_Bottom.ToolbarsManager = this.tToolbarsManager_MainMenu;
            // 
            // PMREC09021UE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.panel_DetailInput);
            this.Controls.Add(this._PMREC09021UE_Toolbars_Dock_Area_Left);
            this.Controls.Add(this._PMREC09021UE_Toolbars_Dock_Area_Right);
            this.Controls.Add(this._PMREC09021UE_Toolbars_Dock_Area_Top);
            this.Controls.Add(this._PMREC09021UE_Toolbars_Dock_Area_Bottom);
            this.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "PMREC09021UE";
            this.Size = new System.Drawing.Size(984, 507);
            this.Load += new System.EventHandler(this.PMREC09021UE_Load);
            this.panel_DetailInput.ResumeLayout(false);
            this.ViewButtonPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uGrid_Details)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tToolbarsManager_MainMenu)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_DetailInput;
        private System.Windows.Forms.Panel ViewButtonPanel;
        private Infragistics.Win.Misc.UltraButton uButton_RowDelete;
        internal Infragistics.Win.UltraWinGrid.UltraGrid uGrid_Details;
        private Broadleaf.Library.Windows.Forms.TToolbarsManager tToolbarsManager_MainMenu;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _PMREC09021UE_Toolbars_Dock_Area_Left;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _PMREC09021UE_Toolbars_Dock_Area_Right;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _PMREC09021UE_Toolbars_Dock_Area_Top;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _PMREC09021UE_Toolbars_Dock_Area_Bottom;
    }
}

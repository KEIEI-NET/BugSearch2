namespace Broadleaf.Library.Windows.Forms
{
    partial class PMREC09021UC
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

        #region Windows フォーム デザイナで生成されたコード

        /// <summary>
        /// デザイナ サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディタで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel1 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.UltraToolbar ultraToolbar1 = new Infragistics.Win.UltraWinToolbars.UltraToolbar("Main");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool1 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Button_Select");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool2 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Button_Back");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool1 = new Infragistics.Win.UltraWinToolbars.LabelTool("lbl_Cnt");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool3 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Button_Select");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool4 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Button_Back");
            Infragistics.Win.UltraWinToolbars.StateButtonTool stateButtonTool1 = new Infragistics.Win.UltraWinToolbars.StateButtonTool("Button_Pos", "");
            Infragistics.Win.UltraWinToolbars.StateButtonTool stateButtonTool2 = new Infragistics.Win.UltraWinToolbars.StateButtonTool("Button_All", "");
            Infragistics.Win.UltraWinToolbars.StateButtonTool stateButtonTool3 = new Infragistics.Win.UltraWinToolbars.StateButtonTool("Button_Search", "");
            Infragistics.Win.UltraWinToolbars.StateButtonTool stateButtonTool4 = new Infragistics.Win.UltraWinToolbars.StateButtonTool("Button_Guide", "");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool2 = new Infragistics.Win.UltraWinToolbars.LabelTool("lbl_Cnt");
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PMREC09021UC));
            this.StatusBar = new Infragistics.Win.UltraWinStatusBar.UltraStatusBar();
            this.SelectionForm_Fill_Panel = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.gridSecCusSetInfo = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this._SelectionForm_Toolbars_Dock_Area_Left = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this.ToolbarsManager = new Broadleaf.Library.Windows.Forms.TToolbarsManager(this.components);
            this._SelectionForm_Toolbars_Dock_Area_Right = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._SelectionForm_Toolbars_Dock_Area_Top = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._SelectionForm_Toolbars_Dock_Area_Bottom = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this.SelectionForm_Fill_Panel.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridSecCusSetInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ToolbarsManager)).BeginInit();
            this.SuspendLayout();
            // 
            // StatusBar
            // 
            this.StatusBar.Location = new System.Drawing.Point(0, 407);
            this.StatusBar.Margin = new System.Windows.Forms.Padding(4);
            this.StatusBar.Name = "StatusBar";
            ultraStatusPanel1.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            ultraStatusPanel1.SizingMode = Infragistics.Win.UltraWinStatusBar.PanelSizingMode.Spring;
            this.StatusBar.Panels.AddRange(new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel[] {
            ultraStatusPanel1});
            this.StatusBar.Size = new System.Drawing.Size(521, 29);
            this.StatusBar.TabIndex = 3;
            this.StatusBar.ViewStyle = Infragistics.Win.UltraWinStatusBar.ViewStyle.Office2003;
            // 
            // SelectionForm_Fill_Panel
            // 
            this.SelectionForm_Fill_Panel.Controls.Add(this.splitContainer1);
            this.SelectionForm_Fill_Panel.Cursor = System.Windows.Forms.Cursors.Default;
            this.SelectionForm_Fill_Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SelectionForm_Fill_Panel.Location = new System.Drawing.Point(0, 28);
            this.SelectionForm_Fill_Panel.Name = "SelectionForm_Fill_Panel";
            this.SelectionForm_Fill_Panel.Size = new System.Drawing.Size(521, 379);
            this.SelectionForm_Fill_Panel.TabIndex = 4;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Panel1Collapsed = true;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.gridSecCusSetInfo);
            this.splitContainer1.Size = new System.Drawing.Size(521, 379);
            this.splitContainer1.SplitterDistance = 250;
            this.splitContainer1.TabIndex = 0;
            this.splitContainer1.TabStop = false;
            // 
            // gridSecCusSetInfo
            // 
            appearance8.BackColor = System.Drawing.Color.White;
            appearance8.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            appearance8.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.gridSecCusSetInfo.DisplayLayout.Appearance = appearance8;
            this.gridSecCusSetInfo.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;
            this.gridSecCusSetInfo.DisplayLayout.GroupByBox.Hidden = true;
            this.gridSecCusSetInfo.DisplayLayout.InterBandSpacing = 10;
            this.gridSecCusSetInfo.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No;
            this.gridSecCusSetInfo.DisplayLayout.Override.AllowColSizing = Infragistics.Win.UltraWinGrid.AllowColSizing.None;
            this.gridSecCusSetInfo.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
            this.gridSecCusSetInfo.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
            this.gridSecCusSetInfo.DisplayLayout.Override.AllowRowSummaries = Infragistics.Win.UltraWinGrid.AllowRowSummaries.False;
            this.gridSecCusSetInfo.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.False;
            appearance9.BackColor = System.Drawing.Color.Transparent;
            this.gridSecCusSetInfo.DisplayLayout.Override.CardAreaAppearance = appearance9;
            this.gridSecCusSetInfo.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            appearance10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance10.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance10.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance10.ForeColor = System.Drawing.Color.White;
            appearance10.TextHAlignAsString = "Left";
            appearance10.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
            this.gridSecCusSetInfo.DisplayLayout.Override.HeaderAppearance = appearance10;
            this.gridSecCusSetInfo.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortSingle;
            appearance11.BackColor = System.Drawing.Color.Lavender;
            this.gridSecCusSetInfo.DisplayLayout.Override.RowAlternateAppearance = appearance11;
            appearance12.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(68)))), ((int)(((byte)(208)))));
            this.gridSecCusSetInfo.DisplayLayout.Override.RowAppearance = appearance12;
            this.gridSecCusSetInfo.DisplayLayout.Override.RowFilterAction = Infragistics.Win.UltraWinGrid.RowFilterAction.HideFilteredOutRows;
            this.gridSecCusSetInfo.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand;
            appearance13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance13.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance13.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance13.ForeColor = System.Drawing.Color.White;
            this.gridSecCusSetInfo.DisplayLayout.Override.RowSelectorAppearance = appearance13;
            this.gridSecCusSetInfo.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.SeparateElement;
            this.gridSecCusSetInfo.DisplayLayout.Override.RowSelectorNumberStyle = Infragistics.Win.UltraWinGrid.RowSelectorNumberStyle.RowIndex;
            this.gridSecCusSetInfo.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True;
            this.gridSecCusSetInfo.DisplayLayout.Override.RowSelectorWidth = 40;
            this.gridSecCusSetInfo.DisplayLayout.Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.Fixed;
            appearance14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(230)))), ((int)(((byte)(148)))));
            appearance14.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(149)))), ((int)(((byte)(21)))));
            appearance14.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance14.ForeColor = System.Drawing.Color.Black;
            this.gridSecCusSetInfo.DisplayLayout.Override.SelectedRowAppearance = appearance14;
            this.gridSecCusSetInfo.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.gridSecCusSetInfo.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.SingleAutoDrag;
            this.gridSecCusSetInfo.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.SingleAutoDrag;
            this.gridSecCusSetInfo.DisplayLayout.RowConnectorColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(167)))), ((int)(((byte)(191)))));
            this.gridSecCusSetInfo.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.Solid;
            this.gridSecCusSetInfo.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.gridSecCusSetInfo.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.gridSecCusSetInfo.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand;
            this.gridSecCusSetInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridSecCusSetInfo.Location = new System.Drawing.Point(0, 0);
            this.gridSecCusSetInfo.Margin = new System.Windows.Forms.Padding(4);
            this.gridSecCusSetInfo.Name = "gridSecCusSetInfo";
            this.gridSecCusSetInfo.Size = new System.Drawing.Size(521, 379);
            this.gridSecCusSetInfo.TabIndex = 0;
            this.gridSecCusSetInfo.TabStop = false;
            this.gridSecCusSetInfo.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.gridSecCusSetInfo_InitializeLayout);
            this.gridSecCusSetInfo.AfterSelectChange += new Infragistics.Win.UltraWinGrid.AfterSelectChangeEventHandler(this.gridSecCusSetInfo_AfterSelectChange);
            this.gridSecCusSetInfo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridSecCusSetInfo_KeyDown);
            this.gridSecCusSetInfo.DoubleClickRow += new Infragistics.Win.UltraWinGrid.DoubleClickRowEventHandler(this.gridSecCusSetInfo_DoubleClickRow);
            // 
            // _SelectionForm_Toolbars_Dock_Area_Left
            // 
            this._SelectionForm_Toolbars_Dock_Area_Left.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._SelectionForm_Toolbars_Dock_Area_Left.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this._SelectionForm_Toolbars_Dock_Area_Left.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Left;
            this._SelectionForm_Toolbars_Dock_Area_Left.ForeColor = System.Drawing.SystemColors.ControlText;
            this._SelectionForm_Toolbars_Dock_Area_Left.Location = new System.Drawing.Point(0, 28);
            this._SelectionForm_Toolbars_Dock_Area_Left.Name = "_SelectionForm_Toolbars_Dock_Area_Left";
            this._SelectionForm_Toolbars_Dock_Area_Left.Size = new System.Drawing.Size(0, 379);
            this._SelectionForm_Toolbars_Dock_Area_Left.ToolbarsManager = this.ToolbarsManager;
            // 
            // ToolbarsManager
            // 
            this.ToolbarsManager.DesignerFlags = 1;
            this.ToolbarsManager.DockWithinContainer = this;
            this.ToolbarsManager.DockWithinContainerBaseType = typeof(System.Windows.Forms.Form);
            this.ToolbarsManager.ShowFullMenusDelay = 500;
            this.ToolbarsManager.Style = Infragistics.Win.UltraWinToolbars.ToolbarStyle.Office2003;
            ultraToolbar1.DockedColumn = 0;
            ultraToolbar1.DockedRow = 0;
            labelTool1.InstanceProps.IsFirstInGroup = true;
            ultraToolbar1.NonInheritedTools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool1,
            buttonTool2,
            labelTool1});
            ultraToolbar1.Settings.AllowCustomize = Infragistics.Win.DefaultableBoolean.False;
            ultraToolbar1.Settings.AllowHiding = Infragistics.Win.DefaultableBoolean.False;
            ultraToolbar1.Settings.ToolDisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            ultraToolbar1.Text = "BLコード選択ツールバー";
            this.ToolbarsManager.Toolbars.AddRange(new Infragistics.Win.UltraWinToolbars.UltraToolbar[] {
            ultraToolbar1});
            buttonTool3.SharedProps.Caption = "確定(F10)";
            buttonTool3.SharedProps.Shortcut = System.Windows.Forms.Shortcut.F10;
            buttonTool4.SharedProps.Caption = "戻る(F11)";
            buttonTool4.SharedProps.Shortcut = System.Windows.Forms.Shortcut.F11;
            buttonTool4.SharedProps.ToolTipText = "前の画面に戻ります。";
            stateButtonTool1.SharedProps.Caption = "部位別(F8)";
            stateButtonTool1.SharedProps.Shortcut = System.Windows.Forms.Shortcut.F8;
            stateButtonTool2.SharedProps.Caption = "全て(F7)";
            stateButtonTool2.SharedProps.Shortcut = System.Windows.Forms.Shortcut.F7;
            stateButtonTool3.SharedProps.Caption = "対象のみ(F6)";
            stateButtonTool3.SharedProps.Shortcut = System.Windows.Forms.Shortcut.F6;
            stateButtonTool4.SharedProps.Caption = "ガイド(F5)";
            stateButtonTool4.SharedProps.Shortcut = System.Windows.Forms.Shortcut.F5;
            appearance16.TextHAlignAsString = "Center";
            labelTool2.SharedProps.AppearancesSmall.Appearance = appearance16;
            labelTool2.SharedProps.Width = 60;
            this.ToolbarsManager.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool3,
            buttonTool4,
            stateButtonTool1,
            stateButtonTool2,
            stateButtonTool3,
            stateButtonTool4,
            labelTool2});
            this.ToolbarsManager.ToolClick += new Infragistics.Win.UltraWinToolbars.ToolClickEventHandler(this.ToolbarsManager_ToolClick);
            // 
            // _SelectionForm_Toolbars_Dock_Area_Right
            // 
            this._SelectionForm_Toolbars_Dock_Area_Right.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._SelectionForm_Toolbars_Dock_Area_Right.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this._SelectionForm_Toolbars_Dock_Area_Right.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Right;
            this._SelectionForm_Toolbars_Dock_Area_Right.ForeColor = System.Drawing.SystemColors.ControlText;
            this._SelectionForm_Toolbars_Dock_Area_Right.Location = new System.Drawing.Point(521, 28);
            this._SelectionForm_Toolbars_Dock_Area_Right.Name = "_SelectionForm_Toolbars_Dock_Area_Right";
            this._SelectionForm_Toolbars_Dock_Area_Right.Size = new System.Drawing.Size(0, 379);
            this._SelectionForm_Toolbars_Dock_Area_Right.ToolbarsManager = this.ToolbarsManager;
            // 
            // _SelectionForm_Toolbars_Dock_Area_Top
            // 
            this._SelectionForm_Toolbars_Dock_Area_Top.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._SelectionForm_Toolbars_Dock_Area_Top.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this._SelectionForm_Toolbars_Dock_Area_Top.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Top;
            this._SelectionForm_Toolbars_Dock_Area_Top.ForeColor = System.Drawing.SystemColors.ControlText;
            this._SelectionForm_Toolbars_Dock_Area_Top.Location = new System.Drawing.Point(0, 0);
            this._SelectionForm_Toolbars_Dock_Area_Top.Name = "_SelectionForm_Toolbars_Dock_Area_Top";
            this._SelectionForm_Toolbars_Dock_Area_Top.Size = new System.Drawing.Size(521, 28);
            this._SelectionForm_Toolbars_Dock_Area_Top.ToolbarsManager = this.ToolbarsManager;
            // 
            // _SelectionForm_Toolbars_Dock_Area_Bottom
            // 
            this._SelectionForm_Toolbars_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._SelectionForm_Toolbars_Dock_Area_Bottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this._SelectionForm_Toolbars_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Bottom;
            this._SelectionForm_Toolbars_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText;
            this._SelectionForm_Toolbars_Dock_Area_Bottom.Location = new System.Drawing.Point(0, 407);
            this._SelectionForm_Toolbars_Dock_Area_Bottom.Name = "_SelectionForm_Toolbars_Dock_Area_Bottom";
            this._SelectionForm_Toolbars_Dock_Area_Bottom.Size = new System.Drawing.Size(521, 0);
            this._SelectionForm_Toolbars_Dock_Area_Bottom.ToolbarsManager = this.ToolbarsManager;
            // 
            // PMREC09021UC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(521, 436);
            this.Controls.Add(this.SelectionForm_Fill_Panel);
            this.Controls.Add(this._SelectionForm_Toolbars_Dock_Area_Left);
            this.Controls.Add(this._SelectionForm_Toolbars_Dock_Area_Right);
            this.Controls.Add(this._SelectionForm_Toolbars_Dock_Area_Top);
            this.Controls.Add(this._SelectionForm_Toolbars_Dock_Area_Bottom);
            this.Controls.Add(this.StatusBar);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(500, 400);
            this.Name = "PMREC09021UC";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "得意先選択画面";
            this.Shown += new System.EventHandler(this.PMREC09021UC_Shown);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.PMREC09021UC_FormClosed);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PMREC09021UC_KeyDown);
            this.SelectionForm_Fill_Panel.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridSecCusSetInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ToolbarsManager)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.UltraWinStatusBar.UltraStatusBar StatusBar;
        private System.Windows.Forms.Panel SelectionForm_Fill_Panel;
        private TToolbarsManager ToolbarsManager;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _SelectionForm_Toolbars_Dock_Area_Left;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _SelectionForm_Toolbars_Dock_Area_Right;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _SelectionForm_Toolbars_Dock_Area_Top;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _SelectionForm_Toolbars_Dock_Area_Bottom;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private Infragistics.Win.UltraWinGrid.UltraGrid gridSecCusSetInfo;
        //private Infragistics.Win.UltraWinEditors.UltraTextEditor txtName; 
    }
}
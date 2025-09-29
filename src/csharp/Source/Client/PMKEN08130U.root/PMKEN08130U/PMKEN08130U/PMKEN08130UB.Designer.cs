namespace Broadleaf.Library.Windows.Forms
{
    partial class SelectionForm
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
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel1 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.UltraWinToolbars.UltraToolbar ultraToolbar1 = new Infragistics.Win.UltraWinToolbars.UltraToolbar("Main");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool1 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Button_Back");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool2 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Button_Back");
            this.DataGrid = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.StatusBar = new Infragistics.Win.UltraWinStatusBar.UltraStatusBar();
            this.SelectionForm_Fill_Panel = new System.Windows.Forms.Panel();
            this.ToolbarsManager = new Broadleaf.Library.Windows.Forms.TToolbarsManager(this.components);
            this._SelectionForm_Toolbars_Dock_Area_Left = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._SelectionForm_Toolbars_Dock_Area_Right = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._SelectionForm_Toolbars_Dock_Area_Top = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._SelectionForm_Toolbars_Dock_Area_Bottom = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            ((System.ComponentModel.ISupportInitialize)(this.DataGrid)).BeginInit();
            this.SelectionForm_Fill_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ToolbarsManager)).BeginInit();
            this.SuspendLayout();
            // 
            // DataGrid
            // 
            appearance1.BackColor = System.Drawing.Color.White;
            appearance1.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            appearance1.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.DataGrid.DisplayLayout.Appearance = appearance1;
            this.DataGrid.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;
            this.DataGrid.DisplayLayout.GroupByBox.Hidden = true;
            this.DataGrid.DisplayLayout.InterBandSpacing = 10;
            this.DataGrid.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No;
            this.DataGrid.DisplayLayout.Override.AllowColSizing = Infragistics.Win.UltraWinGrid.AllowColSizing.Synchronized;
            this.DataGrid.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
            this.DataGrid.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
            this.DataGrid.DisplayLayout.Override.AllowRowSummaries = Infragistics.Win.UltraWinGrid.AllowRowSummaries.False;
            this.DataGrid.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.False;
            appearance2.BackColor = System.Drawing.Color.Transparent;
            this.DataGrid.DisplayLayout.Override.CardAreaAppearance = appearance2;
            this.DataGrid.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            appearance3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance3.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance3.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance3.ForeColor = System.Drawing.Color.White;
            appearance3.TextHAlignAsString = "Left";
            appearance3.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
            this.DataGrid.DisplayLayout.Override.HeaderAppearance = appearance3;
            this.DataGrid.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortSingle;
            appearance4.BackColor = System.Drawing.Color.Lavender;
            this.DataGrid.DisplayLayout.Override.RowAlternateAppearance = appearance4;
            appearance5.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(68)))), ((int)(((byte)(208)))));
            this.DataGrid.DisplayLayout.Override.RowAppearance = appearance5;
            this.DataGrid.DisplayLayout.Override.RowFilterAction = Infragistics.Win.UltraWinGrid.RowFilterAction.HideFilteredOutRows;
            this.DataGrid.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand;
            appearance6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance6.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance6.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance6.ForeColor = System.Drawing.Color.White;
            this.DataGrid.DisplayLayout.Override.RowSelectorAppearance = appearance6;
            this.DataGrid.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True;
            this.DataGrid.DisplayLayout.Override.RowSelectorWidth = 12;
            this.DataGrid.DisplayLayout.Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.AutoFixed;
            appearance7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(230)))), ((int)(((byte)(148)))));
            appearance7.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(149)))), ((int)(((byte)(21)))));
            appearance7.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance7.ForeColor = System.Drawing.Color.Black;
            this.DataGrid.DisplayLayout.Override.SelectedRowAppearance = appearance7;
            this.DataGrid.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.DataGrid.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.SingleAutoDrag;
            this.DataGrid.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.SingleAutoDrag;
            this.DataGrid.DisplayLayout.RowConnectorColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(167)))), ((int)(((byte)(191)))));
            this.DataGrid.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.Solid;
            this.DataGrid.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.DataGrid.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.DataGrid.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand;
            this.DataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DataGrid.Location = new System.Drawing.Point(0, 0);
            this.DataGrid.Margin = new System.Windows.Forms.Padding(4);
            this.DataGrid.Name = "DataGrid";
            this.DataGrid.Size = new System.Drawing.Size(329, 311);
            this.DataGrid.TabIndex = 0;
            this.DataGrid.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.DataGrid_InitializeLayout);
            this.DataGrid.AfterSelectChange += new Infragistics.Win.UltraWinGrid.AfterSelectChangeEventHandler(this.DataGrid_AfterSelectChange);
            this.DataGrid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DataGrid_KeyDown);
            this.DataGrid.DoubleClickRow += new Infragistics.Win.UltraWinGrid.DoubleClickRowEventHandler(this.DataGrid_DoubleClickRow);
            // 
            // StatusBar
            // 
            this.StatusBar.Location = new System.Drawing.Point(0, 337);
            this.StatusBar.Margin = new System.Windows.Forms.Padding(4);
            this.StatusBar.Name = "StatusBar";
            ultraStatusPanel1.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            ultraStatusPanel1.SizingMode = Infragistics.Win.UltraWinStatusBar.PanelSizingMode.Spring;
            this.StatusBar.Panels.AddRange(new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel[] {
            ultraStatusPanel1});
            this.StatusBar.Size = new System.Drawing.Size(329, 29);
            this.StatusBar.TabIndex = 3;
            this.StatusBar.ViewStyle = Infragistics.Win.UltraWinStatusBar.ViewStyle.Office2003;
            // 
            // SelectionForm_Fill_Panel
            // 
            this.SelectionForm_Fill_Panel.Controls.Add(this.DataGrid);
            this.SelectionForm_Fill_Panel.Cursor = System.Windows.Forms.Cursors.Default;
            this.SelectionForm_Fill_Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SelectionForm_Fill_Panel.Location = new System.Drawing.Point(0, 26);
            this.SelectionForm_Fill_Panel.Name = "SelectionForm_Fill_Panel";
            this.SelectionForm_Fill_Panel.Size = new System.Drawing.Size(329, 311);
            this.SelectionForm_Fill_Panel.TabIndex = 4;
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
            ultraToolbar1.NonInheritedTools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool1});
            ultraToolbar1.Settings.ToolDisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            ultraToolbar1.Text = "標準";
            this.ToolbarsManager.Toolbars.AddRange(new Infragistics.Win.UltraWinToolbars.UltraToolbar[] {
            ultraToolbar1});
            buttonTool2.SharedProps.Caption = "戻る(F11)";
            buttonTool2.SharedProps.Shortcut = System.Windows.Forms.Shortcut.F11;
            buttonTool2.SharedProps.ToolTipText = "前の画面に戻ります。";
            this.ToolbarsManager.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool2});
            this.ToolbarsManager.ToolKeyDown += new Infragistics.Win.UltraWinToolbars.ToolKeyEventHandler(this.ToolbarsManager_ToolKeyDown);
            this.ToolbarsManager.ToolClick += new Infragistics.Win.UltraWinToolbars.ToolClickEventHandler(this.ToolbarsManager_ToolClick);
            // 
            // _SelectionForm_Toolbars_Dock_Area_Left
            // 
            this._SelectionForm_Toolbars_Dock_Area_Left.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._SelectionForm_Toolbars_Dock_Area_Left.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this._SelectionForm_Toolbars_Dock_Area_Left.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Left;
            this._SelectionForm_Toolbars_Dock_Area_Left.ForeColor = System.Drawing.SystemColors.ControlText;
            this._SelectionForm_Toolbars_Dock_Area_Left.Location = new System.Drawing.Point(0, 26);
            this._SelectionForm_Toolbars_Dock_Area_Left.Name = "_SelectionForm_Toolbars_Dock_Area_Left";
            this._SelectionForm_Toolbars_Dock_Area_Left.Size = new System.Drawing.Size(0, 311);
            this._SelectionForm_Toolbars_Dock_Area_Left.ToolbarsManager = this.ToolbarsManager;
            // 
            // _SelectionForm_Toolbars_Dock_Area_Right
            // 
            this._SelectionForm_Toolbars_Dock_Area_Right.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._SelectionForm_Toolbars_Dock_Area_Right.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this._SelectionForm_Toolbars_Dock_Area_Right.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Right;
            this._SelectionForm_Toolbars_Dock_Area_Right.ForeColor = System.Drawing.SystemColors.ControlText;
            this._SelectionForm_Toolbars_Dock_Area_Right.Location = new System.Drawing.Point(329, 26);
            this._SelectionForm_Toolbars_Dock_Area_Right.Name = "_SelectionForm_Toolbars_Dock_Area_Right";
            this._SelectionForm_Toolbars_Dock_Area_Right.Size = new System.Drawing.Size(0, 311);
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
            this._SelectionForm_Toolbars_Dock_Area_Top.Size = new System.Drawing.Size(329, 26);
            this._SelectionForm_Toolbars_Dock_Area_Top.ToolbarsManager = this.ToolbarsManager;
            // 
            // _SelectionForm_Toolbars_Dock_Area_Bottom
            // 
            this._SelectionForm_Toolbars_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._SelectionForm_Toolbars_Dock_Area_Bottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this._SelectionForm_Toolbars_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Bottom;
            this._SelectionForm_Toolbars_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText;
            this._SelectionForm_Toolbars_Dock_Area_Bottom.Location = new System.Drawing.Point(0, 337);
            this._SelectionForm_Toolbars_Dock_Area_Bottom.Name = "_SelectionForm_Toolbars_Dock_Area_Bottom";
            this._SelectionForm_Toolbars_Dock_Area_Bottom.Size = new System.Drawing.Size(329, 0);
            this._SelectionForm_Toolbars_Dock_Area_Bottom.ToolbarsManager = this.ToolbarsManager;
            // 
            // SelectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(329, 366);
            this.Controls.Add(this.SelectionForm_Fill_Panel);
            this.Controls.Add(this._SelectionForm_Toolbars_Dock_Area_Left);
            this.Controls.Add(this._SelectionForm_Toolbars_Dock_Area_Right);
            this.Controls.Add(this._SelectionForm_Toolbars_Dock_Area_Top);
            this.Controls.Add(this._SelectionForm_Toolbars_Dock_Area_Bottom);
            this.Controls.Add(this.StatusBar);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(300, 250);
            this.Name = "SelectionForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "類別型式表示";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectionForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.DataGrid)).EndInit();
            this.SelectionForm_Fill_Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ToolbarsManager)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.UltraWinGrid.UltraGrid DataGrid;
        private Infragistics.Win.UltraWinStatusBar.UltraStatusBar StatusBar;
        private System.Windows.Forms.Panel SelectionForm_Fill_Panel;
        private TToolbarsManager ToolbarsManager;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _SelectionForm_Toolbars_Dock_Area_Left;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _SelectionForm_Toolbars_Dock_Area_Right;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _SelectionForm_Toolbars_Dock_Area_Top;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _SelectionForm_Toolbars_Dock_Area_Bottom;
    }
}
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
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool1 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Button_Select");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool2 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Button_Back");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool3 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Button_ShowCode");
            Infragistics.Win.UltraWinToolbars.UltraToolbar ultraToolbar2 = new Infragistics.Win.UltraWinToolbars.UltraToolbar("UltraToolbar1");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool1 = new Infragistics.Win.UltraWinToolbars.LabelTool("TotalCount");
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool4 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Button_Select");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool5 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Button_Back");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool6 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Button_ShowCode");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool2 = new Infragistics.Win.UltraWinToolbars.LabelTool("lbl");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool3 = new Infragistics.Win.UltraWinToolbars.LabelTool("TotalCount");
            this.gridCarKindInfo = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.StatusBar = new Infragistics.Win.UltraWinStatusBar.UltraStatusBar();
            this.SelectionForm_Fill_Panel = new System.Windows.Forms.Panel();
            this._SelectionForm_Toolbars_Dock_Area_Left = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this.ToolbarsManager = new Broadleaf.Library.Windows.Forms.TToolbarsManager(this.components);
            this._SelectionForm_Toolbars_Dock_Area_Right = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._SelectionForm_Toolbars_Dock_Area_Top = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._SelectionForm_Toolbars_Dock_Area_Bottom = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            ((System.ComponentModel.ISupportInitialize)(this.gridCarKindInfo)).BeginInit();
            this.SelectionForm_Fill_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ToolbarsManager)).BeginInit();
            this.SuspendLayout();
            // 
            // gridCarKindInfo
            // 
            appearance1.BackColor = System.Drawing.Color.White;
            appearance1.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            appearance1.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.gridCarKindInfo.DisplayLayout.Appearance = appearance1;
            this.gridCarKindInfo.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;
            this.gridCarKindInfo.DisplayLayout.GroupByBox.Hidden = true;
            this.gridCarKindInfo.DisplayLayout.InterBandSpacing = 10;
            this.gridCarKindInfo.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No;
            this.gridCarKindInfo.DisplayLayout.Override.AllowColSizing = Infragistics.Win.UltraWinGrid.AllowColSizing.Synchronized;
            this.gridCarKindInfo.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
            this.gridCarKindInfo.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
            this.gridCarKindInfo.DisplayLayout.Override.AllowRowLayoutCellSizing = Infragistics.Win.UltraWinGrid.RowLayoutSizing.None;
            this.gridCarKindInfo.DisplayLayout.Override.AllowRowLayoutColMoving = Infragistics.Win.Layout.GridBagLayoutAllowMoving.None;
            this.gridCarKindInfo.DisplayLayout.Override.AllowRowSummaries = Infragistics.Win.UltraWinGrid.AllowRowSummaries.False;
            this.gridCarKindInfo.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.False;
            appearance2.BackColor = System.Drawing.Color.Transparent;
            this.gridCarKindInfo.DisplayLayout.Override.CardAreaAppearance = appearance2;
            this.gridCarKindInfo.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            appearance3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance3.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance3.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance3.ForeColor = System.Drawing.Color.White;
            appearance3.TextHAlignAsString = "Left";
            appearance3.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
            this.gridCarKindInfo.DisplayLayout.Override.HeaderAppearance = appearance3;
            this.gridCarKindInfo.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.Select;
            appearance4.BackColor = System.Drawing.Color.Lavender;
            this.gridCarKindInfo.DisplayLayout.Override.RowAlternateAppearance = appearance4;
            appearance5.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(68)))), ((int)(((byte)(208)))));
            this.gridCarKindInfo.DisplayLayout.Override.RowAppearance = appearance5;
            this.gridCarKindInfo.DisplayLayout.Override.RowFilterAction = Infragistics.Win.UltraWinGrid.RowFilterAction.HideFilteredOutRows;
            this.gridCarKindInfo.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand;
            appearance6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance6.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance6.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance6.ForeColor = System.Drawing.Color.White;
            this.gridCarKindInfo.DisplayLayout.Override.RowSelectorAppearance = appearance6;
            this.gridCarKindInfo.DisplayLayout.Override.RowSelectorNumberStyle = Infragistics.Win.UltraWinGrid.RowSelectorNumberStyle.RowIndex;
            this.gridCarKindInfo.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True;
            this.gridCarKindInfo.DisplayLayout.Override.RowSelectorWidth = 24;
            this.gridCarKindInfo.DisplayLayout.Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.AutoFixed;
            appearance7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(230)))), ((int)(((byte)(148)))));
            appearance7.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(149)))), ((int)(((byte)(21)))));
            appearance7.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance7.ForeColor = System.Drawing.Color.Black;
            this.gridCarKindInfo.DisplayLayout.Override.SelectedRowAppearance = appearance7;
            this.gridCarKindInfo.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.gridCarKindInfo.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.SingleAutoDrag;
            this.gridCarKindInfo.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.SingleAutoDrag;
            this.gridCarKindInfo.DisplayLayout.RowConnectorColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(167)))), ((int)(((byte)(191)))));
            this.gridCarKindInfo.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.Solid;
            this.gridCarKindInfo.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.gridCarKindInfo.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.gridCarKindInfo.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand;
            this.gridCarKindInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridCarKindInfo.Location = new System.Drawing.Point(0, 0);
            this.gridCarKindInfo.Margin = new System.Windows.Forms.Padding(4);
            this.gridCarKindInfo.Name = "gridCarKindInfo";
            this.gridCarKindInfo.Size = new System.Drawing.Size(494, 306);
            this.gridCarKindInfo.TabIndex = 0;
            this.gridCarKindInfo.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.gridCarKindInfo_InitializeLayout);
            this.gridCarKindInfo.AfterSelectChange += new Infragistics.Win.UltraWinGrid.AfterSelectChangeEventHandler(this.gridCarKindInfo_AfterSelectChange);
            this.gridCarKindInfo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridCarKindInfo_KeyDown);
            this.gridCarKindInfo.DoubleClickRow += new Infragistics.Win.UltraWinGrid.DoubleClickRowEventHandler(this.gridCarKindInfo_DoubleClickRow);
            // 
            // StatusBar
            // 
            this.StatusBar.Location = new System.Drawing.Point(0, 334);
            this.StatusBar.Margin = new System.Windows.Forms.Padding(4);
            this.StatusBar.Name = "StatusBar";
            ultraStatusPanel1.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            ultraStatusPanel1.SizingMode = Infragistics.Win.UltraWinStatusBar.PanelSizingMode.Spring;
            this.StatusBar.Panels.AddRange(new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel[] {
            ultraStatusPanel1});
            this.StatusBar.Size = new System.Drawing.Size(494, 29);
            this.StatusBar.TabIndex = 3;
            this.StatusBar.ViewStyle = Infragistics.Win.UltraWinStatusBar.ViewStyle.Office2003;
            // 
            // SelectionForm_Fill_Panel
            // 
            this.SelectionForm_Fill_Panel.Controls.Add(this.gridCarKindInfo);
            this.SelectionForm_Fill_Panel.Cursor = System.Windows.Forms.Cursors.Default;
            this.SelectionForm_Fill_Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SelectionForm_Fill_Panel.Location = new System.Drawing.Point(0, 28);
            this.SelectionForm_Fill_Panel.Name = "SelectionForm_Fill_Panel";
            this.SelectionForm_Fill_Panel.Size = new System.Drawing.Size(494, 306);
            this.SelectionForm_Fill_Panel.TabIndex = 4;
            // 
            // _SelectionForm_Toolbars_Dock_Area_Left
            // 
            this._SelectionForm_Toolbars_Dock_Area_Left.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._SelectionForm_Toolbars_Dock_Area_Left.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this._SelectionForm_Toolbars_Dock_Area_Left.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Left;
            this._SelectionForm_Toolbars_Dock_Area_Left.ForeColor = System.Drawing.SystemColors.ControlText;
            this._SelectionForm_Toolbars_Dock_Area_Left.Location = new System.Drawing.Point(0, 28);
            this._SelectionForm_Toolbars_Dock_Area_Left.Name = "_SelectionForm_Toolbars_Dock_Area_Left";
            this._SelectionForm_Toolbars_Dock_Area_Left.Size = new System.Drawing.Size(0, 306);
            this._SelectionForm_Toolbars_Dock_Area_Left.ToolbarsManager = this.ToolbarsManager;
            // 
            // ToolbarsManager
            // 
            this.ToolbarsManager.DesignerFlags = 0;
            this.ToolbarsManager.DockWithinContainer = this;
            this.ToolbarsManager.DockWithinContainerBaseType = typeof(System.Windows.Forms.Form);
            this.ToolbarsManager.ShowFullMenusDelay = 500;
            this.ToolbarsManager.Style = Infragistics.Win.UltraWinToolbars.ToolbarStyle.Office2003;
            ultraToolbar1.DockedColumn = 0;
            ultraToolbar1.DockedRow = 0;
            ultraToolbar1.FloatingLocation = new System.Drawing.Point(208, 295);
            ultraToolbar1.FloatingSize = new System.Drawing.Size(507, 22);
            buttonTool3.InstanceProps.IsFirstInGroup = true;
            ultraToolbar1.NonInheritedTools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool1,
            buttonTool2,
            buttonTool3});
            ultraToolbar1.Settings.AllowCustomize = Infragistics.Win.DefaultableBoolean.False;
            ultraToolbar1.Settings.AllowDockBottom = Infragistics.Win.DefaultableBoolean.False;
            ultraToolbar1.Settings.AllowDockLeft = Infragistics.Win.DefaultableBoolean.False;
            ultraToolbar1.Settings.AllowDockRight = Infragistics.Win.DefaultableBoolean.False;
            ultraToolbar1.Settings.AllowFloating = Infragistics.Win.DefaultableBoolean.False;
            ultraToolbar1.Settings.AllowHiding = Infragistics.Win.DefaultableBoolean.False;
            ultraToolbar1.Settings.BorderStyleDocked = Infragistics.Win.UIElementBorderStyle.RaisedSoft;
            ultraToolbar1.Settings.GrabHandleStyle = Infragistics.Win.UltraWinToolbars.GrabHandleStyle.None;
            ultraToolbar1.Settings.ToolDisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            ultraToolbar1.Text = "標準";
            ultraToolbar2.DockedColumn = 1;
            ultraToolbar2.DockedRow = 0;
            ultraToolbar2.FloatingLocation = new System.Drawing.Point(35, 195);
            ultraToolbar2.FloatingSize = new System.Drawing.Size(199, 22);
            ultraToolbar2.NonInheritedTools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            labelTool1});
            ultraToolbar2.Settings.AllowCustomize = Infragistics.Win.DefaultableBoolean.False;
            ultraToolbar2.Settings.AllowDockBottom = Infragistics.Win.DefaultableBoolean.False;
            ultraToolbar2.Settings.AllowDockLeft = Infragistics.Win.DefaultableBoolean.False;
            ultraToolbar2.Settings.AllowDockRight = Infragistics.Win.DefaultableBoolean.False;
            ultraToolbar2.Settings.AllowFloating = Infragistics.Win.DefaultableBoolean.False;
            ultraToolbar2.Settings.AllowHiding = Infragistics.Win.DefaultableBoolean.False;
            appearance8.TextHAlignAsString = "Center";
            ultraToolbar2.Settings.Appearance = appearance8;
            ultraToolbar2.Settings.BorderStyleDocked = Infragistics.Win.UIElementBorderStyle.RaisedSoft;
            ultraToolbar2.Settings.GrabHandleStyle = Infragistics.Win.UltraWinToolbars.GrabHandleStyle.None;
            ultraToolbar2.Text = "UltraToolbar1";
            this.ToolbarsManager.Toolbars.AddRange(new Infragistics.Win.UltraWinToolbars.UltraToolbar[] {
            ultraToolbar1,
            ultraToolbar2});
            buttonTool4.SharedProps.Caption = "選択(F10)";
            buttonTool4.SharedProps.Shortcut = System.Windows.Forms.Shortcut.F10;
            buttonTool5.SharedProps.Caption = "戻る(F11)";
            buttonTool5.SharedProps.Shortcut = System.Windows.Forms.Shortcut.F11;
            buttonTool5.SharedProps.ToolTipText = "前の画面に戻ります。";
            buttonTool6.SharedProps.Caption = "コード非表示(F9)";
            buttonTool6.SharedProps.Shortcut = System.Windows.Forms.Shortcut.F9;
            labelTool2.SharedProps.Caption = "選択行";
            this.ToolbarsManager.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool4,
            buttonTool5,
            buttonTool6,
            labelTool2,
            labelTool3});
            this.ToolbarsManager.ToolClick += new Infragistics.Win.UltraWinToolbars.ToolClickEventHandler(this.ToolbarsManager_ToolClick);
            // 
            // _SelectionForm_Toolbars_Dock_Area_Right
            // 
            this._SelectionForm_Toolbars_Dock_Area_Right.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._SelectionForm_Toolbars_Dock_Area_Right.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this._SelectionForm_Toolbars_Dock_Area_Right.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Right;
            this._SelectionForm_Toolbars_Dock_Area_Right.ForeColor = System.Drawing.SystemColors.ControlText;
            this._SelectionForm_Toolbars_Dock_Area_Right.Location = new System.Drawing.Point(494, 28);
            this._SelectionForm_Toolbars_Dock_Area_Right.Name = "_SelectionForm_Toolbars_Dock_Area_Right";
            this._SelectionForm_Toolbars_Dock_Area_Right.Size = new System.Drawing.Size(0, 306);
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
            this._SelectionForm_Toolbars_Dock_Area_Top.Size = new System.Drawing.Size(494, 28);
            this._SelectionForm_Toolbars_Dock_Area_Top.ToolbarsManager = this.ToolbarsManager;
            // 
            // _SelectionForm_Toolbars_Dock_Area_Bottom
            // 
            this._SelectionForm_Toolbars_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._SelectionForm_Toolbars_Dock_Area_Bottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this._SelectionForm_Toolbars_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Bottom;
            this._SelectionForm_Toolbars_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText;
            this._SelectionForm_Toolbars_Dock_Area_Bottom.Location = new System.Drawing.Point(0, 334);
            this._SelectionForm_Toolbars_Dock_Area_Bottom.Name = "_SelectionForm_Toolbars_Dock_Area_Bottom";
            this._SelectionForm_Toolbars_Dock_Area_Bottom.Size = new System.Drawing.Size(494, 0);
            this._SelectionForm_Toolbars_Dock_Area_Bottom.ToolbarsManager = this.ToolbarsManager;
            // 
            // SelectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 363);
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
            this.MinimumSize = new System.Drawing.Size(460, 355);
            this.Name = "SelectionForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "車種選択";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SelectionForm_FormClosed);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SelectionForm_KeyPress);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SelectionForm_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectionForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.gridCarKindInfo)).EndInit();
            this.SelectionForm_Fill_Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ToolbarsManager)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.UltraWinGrid.UltraGrid gridCarKindInfo;
        private Infragistics.Win.UltraWinStatusBar.UltraStatusBar StatusBar;
        private System.Windows.Forms.Panel SelectionForm_Fill_Panel;
        private TToolbarsManager ToolbarsManager;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _SelectionForm_Toolbars_Dock_Area_Left;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _SelectionForm_Toolbars_Dock_Area_Right;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _SelectionForm_Toolbars_Dock_Area_Top;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _SelectionForm_Toolbars_Dock_Area_Bottom;
    }
}
namespace Broadleaf.Windows.Forms
{
    partial class PMMIT01010UL
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
            if (disposing && ( components != null ))
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
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.UltraToolbar ultraToolbar1 = new Infragistics.Win.UltraWinToolbars.UltraToolbar("UltraToolbar1");
            Infragistics.Win.UltraWinToolbars.ControlContainerTool controlContainerTool1 = new Infragistics.Win.UltraWinToolbars.ControlContainerTool("ControlContainerTool_OrderCancel");
            Infragistics.Win.UltraWinToolbars.ControlContainerTool controlContainerTool2 = new Infragistics.Win.UltraWinToolbars.ControlContainerTool("ControlContainerTool_OrderCancel");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool1 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("PopupMenuTool_Edit");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool1 = new Infragistics.Win.UltraWinToolbars.ButtonTool("ButtonTool_OrderCancel");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool2 = new Infragistics.Win.UltraWinToolbars.ButtonTool("ButtonTool_OrderCancel");
            this.PMMIT01010UL_Fill_Panel = new System.Windows.Forms.Panel();
            this.ViewButtonPanel = new System.Windows.Forms.Panel();
            this.uButton_OrderCancel = new Infragistics.Win.Misc.UltraButton();
            this.uGrid_Details = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this._PMMIT01010UL_Toolbars_Dock_Area_Left = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this.tToolbarsManager_Main = new Broadleaf.Library.Windows.Forms.TToolbarsManager(this.components);
            this._PMMIT01010UL_Toolbars_Dock_Area_Right = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._PMMIT01010UL_Toolbars_Dock_Area_Top = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._PMMIT01010UL_Toolbars_Dock_Area_Bottom = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this.PMMIT01010UL_Fill_Panel.SuspendLayout();
            this.ViewButtonPanel.SuspendLayout();
            ( (System.ComponentModel.ISupportInitialize)( this.uGrid_Details ) ).BeginInit();
            ( (System.ComponentModel.ISupportInitialize)( this.tToolbarsManager_Main ) ).BeginInit();
            this.SuspendLayout();
            // 
            // PMMIT01010UL_Fill_Panel
            // 
            this.PMMIT01010UL_Fill_Panel.Controls.Add(this.ViewButtonPanel);
            this.PMMIT01010UL_Fill_Panel.Controls.Add(this.uGrid_Details);
            this.PMMIT01010UL_Fill_Panel.Cursor = System.Windows.Forms.Cursors.Default;
            this.PMMIT01010UL_Fill_Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PMMIT01010UL_Fill_Panel.Location = new System.Drawing.Point(0, 29);
            this.PMMIT01010UL_Fill_Panel.Name = "PMMIT01010UL_Fill_Panel";
            this.PMMIT01010UL_Fill_Panel.Size = new System.Drawing.Size(703, 402);
            this.PMMIT01010UL_Fill_Panel.TabIndex = 0;
            // 
            // ViewButtonPanel
            // 
            this.ViewButtonPanel.BackColor = System.Drawing.Color.GhostWhite;
            this.ViewButtonPanel.Controls.Add(this.uButton_OrderCancel);
            this.ViewButtonPanel.Location = new System.Drawing.Point(3, 6);
            this.ViewButtonPanel.Name = "ViewButtonPanel";
            this.ViewButtonPanel.Size = new System.Drawing.Size(411, 94);
            this.ViewButtonPanel.TabIndex = 3;
            this.ViewButtonPanel.Visible = false;
            // 
            // uButton_OrderCancel
            // 
            this.uButton_OrderCancel.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 128 ) ));
            this.uButton_OrderCancel.Location = new System.Drawing.Point(13, 34);
            this.uButton_OrderCancel.Name = "uButton_OrderCancel";
            this.uButton_OrderCancel.Size = new System.Drawing.Size(82, 27);
            this.uButton_OrderCancel.TabIndex = 7;
            this.uButton_OrderCancel.TabStop = false;
            this.uButton_OrderCancel.Text = "取消(&D)";
            this.uButton_OrderCancel.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.uButton_OrderCancel.Click += new System.EventHandler(this.uButton_OrderCancel_Click);
            // 
            // uGrid_Details
            // 
            appearance3.BackColor = System.Drawing.Color.White;
            appearance3.BackColor2 = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 198 ) ) ) ), ( (int)( ( (byte)( 219 ) ) ) ), ( (int)( ( (byte)( 255 ) ) ) ));
            appearance3.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.uGrid_Details.DisplayLayout.Appearance = appearance3;
            this.uGrid_Details.DisplayLayout.GroupByBox.Hidden = true;
            this.uGrid_Details.DisplayLayout.InterBandSpacing = 10;
            this.uGrid_Details.DisplayLayout.MaxColScrollRegions = 1;
            this.uGrid_Details.DisplayLayout.MaxRowScrollRegions = 1;
            appearance4.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 251 ) ) ) ), ( (int)( ( (byte)( 230 ) ) ) ), ( (int)( ( (byte)( 148 ) ) ) ));
            appearance4.BackColor2 = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 251 ) ) ) ), ( (int)( ( (byte)( 230 ) ) ) ), ( (int)( ( (byte)( 148 ) ) ) ));
            appearance4.ForeColor = System.Drawing.Color.Black;
            this.uGrid_Details.DisplayLayout.Override.ActiveCellAppearance = appearance4;
            this.uGrid_Details.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No;
            this.uGrid_Details.DisplayLayout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.NotAllowed;
            this.uGrid_Details.DisplayLayout.Override.AllowColSizing = Infragistics.Win.UltraWinGrid.AllowColSizing.Free;
            this.uGrid_Details.DisplayLayout.Override.AllowColSwapping = Infragistics.Win.UltraWinGrid.AllowColSwapping.NotAllowed;
            this.uGrid_Details.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
            this.uGrid_Details.DisplayLayout.Override.AllowGroupBy = Infragistics.Win.DefaultableBoolean.False;
            this.uGrid_Details.DisplayLayout.Override.AllowGroupMoving = Infragistics.Win.UltraWinGrid.AllowGroupMoving.NotAllowed;
            this.uGrid_Details.DisplayLayout.Override.AllowGroupSwapping = Infragistics.Win.UltraWinGrid.AllowGroupSwapping.NotAllowed;
            this.uGrid_Details.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
            this.uGrid_Details.DisplayLayout.Override.AllowRowLayoutCellSizing = Infragistics.Win.UltraWinGrid.RowLayoutSizing.None;
            this.uGrid_Details.DisplayLayout.Override.AllowRowLayoutCellSpanSizing = Infragistics.Win.Layout.GridBagLayoutAllowSpanSizing.None;
            this.uGrid_Details.DisplayLayout.Override.AllowRowLayoutColMoving = Infragistics.Win.Layout.GridBagLayoutAllowMoving.None;
            this.uGrid_Details.DisplayLayout.Override.AllowRowLayoutLabelSizing = Infragistics.Win.UltraWinGrid.RowLayoutSizing.None;
            this.uGrid_Details.DisplayLayout.Override.AllowRowLayoutLabelSpanSizing = Infragistics.Win.Layout.GridBagLayoutAllowSpanSizing.None;
            this.uGrid_Details.DisplayLayout.Override.AllowRowSummaries = Infragistics.Win.UltraWinGrid.AllowRowSummaries.False;
            this.uGrid_Details.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.True;
            this.uGrid_Details.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.Edit;
            this.uGrid_Details.DisplayLayout.Override.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
            appearance5.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 89 ) ) ) ), ( (int)( ( (byte)( 135 ) ) ) ), ( (int)( ( (byte)( 214 ) ) ) ));
            appearance5.BackColor2 = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 7 ) ) ) ), ( (int)( ( (byte)( 59 ) ) ) ), ( (int)( ( (byte)( 150 ) ) ) ));
            appearance5.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance5.ForeColor = System.Drawing.Color.White;
            appearance5.ForeColorDisabled = System.Drawing.Color.White;
            appearance5.TextHAlignAsString = "Center";
            appearance5.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
            this.uGrid_Details.DisplayLayout.Override.HeaderAppearance = appearance5;
            appearance6.BackColor = System.Drawing.Color.Lavender;
            this.uGrid_Details.DisplayLayout.Override.RowAlternateAppearance = appearance6;
            appearance7.BorderColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 127 ) ) ) ), ( (int)( ( (byte)( 157 ) ) ) ), ( (int)( ( (byte)( 185 ) ) ) ));
            appearance7.TextVAlignAsString = "Middle";
            this.uGrid_Details.DisplayLayout.Override.RowAppearance = appearance7;
            this.uGrid_Details.DisplayLayout.Override.RowFilterAction = Infragistics.Win.UltraWinGrid.RowFilterAction.HideFilteredOutRows;
            this.uGrid_Details.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand;
            appearance2.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 89 ) ) ) ), ( (int)( ( (byte)( 135 ) ) ) ), ( (int)( ( (byte)( 214 ) ) ) ));
            appearance2.BackColor2 = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 7 ) ) ) ), ( (int)( ( (byte)( 59 ) ) ) ), ( (int)( ( (byte)( 150 ) ) ) ));
            appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance2.ForeColor = System.Drawing.Color.White;
            this.uGrid_Details.DisplayLayout.Override.RowSelectorAppearance = appearance2;
            this.uGrid_Details.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True;
            this.uGrid_Details.DisplayLayout.Override.RowSelectorWidth = 20;
            this.uGrid_Details.DisplayLayout.Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.AutoFixed;
            appearance8.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 251 ) ) ) ), ( (int)( ( (byte)( 230 ) ) ) ), ( (int)( ( (byte)( 148 ) ) ) ));
            appearance8.BackColor2 = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 238 ) ) ) ), ( (int)( ( (byte)( 149 ) ) ) ), ( (int)( ( (byte)( 21 ) ) ) ));
            appearance8.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance8.ForeColor = System.Drawing.Color.Black;
            this.uGrid_Details.DisplayLayout.Override.SelectedRowAppearance = appearance8;
            this.uGrid_Details.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.Single;
            this.uGrid_Details.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.SingleAutoDrag;
            this.uGrid_Details.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.ExtendedAutoDrag;
            this.uGrid_Details.DisplayLayout.Override.TipStyleCell = Infragistics.Win.UltraWinGrid.TipStyle.Hide;
            this.uGrid_Details.DisplayLayout.Override.TipStyleRowConnector = Infragistics.Win.UltraWinGrid.TipStyle.Hide;
            this.uGrid_Details.DisplayLayout.Override.TipStyleScroll = Infragistics.Win.UltraWinGrid.TipStyle.Hide;
            this.uGrid_Details.DisplayLayout.RowConnectorColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 168 ) ) ) ), ( (int)( ( (byte)( 167 ) ) ) ), ( (int)( ( (byte)( 191 ) ) ) ));
            this.uGrid_Details.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.uGrid_Details.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.uGrid_Details.DisplayLayout.UseFixedHeaders = true;
            this.uGrid_Details.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand;
            this.uGrid_Details.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uGrid_Details.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 128 ) ));
            this.uGrid_Details.Location = new System.Drawing.Point(0, 0);
            this.uGrid_Details.Name = "uGrid_Details";
            this.uGrid_Details.Size = new System.Drawing.Size(703, 402);
            this.uGrid_Details.TabIndex = 6;
            this.uGrid_Details.BeforeCellUpdate += new Infragistics.Win.UltraWinGrid.BeforeCellUpdateEventHandler(this.uGrid_Details_BeforeCellUpdate);
            this.uGrid_Details.KeyUp += new System.Windows.Forms.KeyEventHandler(this.uGrid_Details_KeyUp);
            this.uGrid_Details.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.uGrid_Details_InitializeLayout);
            this.uGrid_Details.CellDataError += new Infragistics.Win.UltraWinGrid.CellDataErrorEventHandler(this.uGrid_Details_CellDataError);
            this.uGrid_Details.BeforeCellDeactivate += new System.ComponentModel.CancelEventHandler(this.uGrid_Details_BeforeCellDeactivate);
            this.uGrid_Details.AfterCellUpdate += new Infragistics.Win.UltraWinGrid.CellEventHandler(this.uGrid_Details_AfterCellUpdate);
            this.uGrid_Details.Enter += new System.EventHandler(this.uGrid_Details_Enter);
            this.uGrid_Details.AfterRowActivate += new System.EventHandler(this.uGrid_Details_AfterRowActivate);
            this.uGrid_Details.MouseClick += new System.Windows.Forms.MouseEventHandler(this.uGrid_Details_MouseClick);
            this.uGrid_Details.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.uGrid_Details_KeyPress);
            this.uGrid_Details.AfterPerformAction += new Infragistics.Win.UltraWinGrid.AfterUltraGridPerformActionEventHandler(this.uGrid_Details_AfterPerformAction);
            this.uGrid_Details.Leave += new System.EventHandler(this.uGrid_Details_Leave);
            this.uGrid_Details.KeyDown += new System.Windows.Forms.KeyEventHandler(this.uGrid_Details_KeyDown);
            this.uGrid_Details.BeforeCellActivate += new Infragistics.Win.UltraWinGrid.CancelableCellEventHandler(this.uGrid_Details_BeforeCellActivate);
            this.uGrid_Details.AfterCellActivate += new System.EventHandler(this.uGrid_Details_AfterCellActivate);
            // 
            // _PMMIT01010UL_Toolbars_Dock_Area_Left
            // 
            this._PMMIT01010UL_Toolbars_Dock_Area_Left.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._PMMIT01010UL_Toolbars_Dock_Area_Left.AlphaBlendMode = Infragistics.Win.AlphaBlendMode.Disabled;
            this._PMMIT01010UL_Toolbars_Dock_Area_Left.BackColor = System.Drawing.Color.GhostWhite;
            this._PMMIT01010UL_Toolbars_Dock_Area_Left.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Left;
            this._PMMIT01010UL_Toolbars_Dock_Area_Left.ForeColor = System.Drawing.SystemColors.ControlText;
            this._PMMIT01010UL_Toolbars_Dock_Area_Left.Location = new System.Drawing.Point(0, 29);
            this._PMMIT01010UL_Toolbars_Dock_Area_Left.Name = "_PMMIT01010UL_Toolbars_Dock_Area_Left";
            this._PMMIT01010UL_Toolbars_Dock_Area_Left.Size = new System.Drawing.Size(0, 402);
            this._PMMIT01010UL_Toolbars_Dock_Area_Left.ToolbarsManager = this.tToolbarsManager_Main;
            // 
            // tToolbarsManager_Main
            // 
            this.tToolbarsManager_Main.AlphaBlendMode = Infragistics.Win.AlphaBlendMode.Disabled;
            appearance1.BackColor = System.Drawing.Color.GhostWhite;
            this.tToolbarsManager_Main.Appearance = appearance1;
            this.tToolbarsManager_Main.DesignerFlags = 1;
            this.tToolbarsManager_Main.DockWithinContainer = this;
            this.tToolbarsManager_Main.LockToolbars = true;
            this.tToolbarsManager_Main.RuntimeCustomizationOptions = Infragistics.Win.UltraWinToolbars.RuntimeCustomizationOptions.None;
            this.tToolbarsManager_Main.ShowFullMenusDelay = 500;
            this.tToolbarsManager_Main.ShowQuickCustomizeButton = false;
            ultraToolbar1.DockedColumn = 0;
            ultraToolbar1.DockedRow = 0;
            ultraToolbar1.FloatingLocation = new System.Drawing.Point(-1000, -234);
            ultraToolbar1.FloatingSize = new System.Drawing.Size(468, 48);
            controlContainerTool1.ControlName = "uButton_OrderCancel";
            ultraToolbar1.NonInheritedTools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            controlContainerTool1});
            ultraToolbar1.Text = "標準";
            this.tToolbarsManager_Main.Toolbars.AddRange(new Infragistics.Win.UltraWinToolbars.UltraToolbar[] {
            ultraToolbar1});
            controlContainerTool2.ControlName = "uButton_OrderCancel";
            controlContainerTool2.SharedProps.Caption = "発注取消";
            popupMenuTool1.SharedProps.Caption = "編集メニュー";
            popupMenuTool1.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool1});
            buttonTool2.SharedProps.Caption = "発注取消";
            buttonTool2.SharedProps.CustomizerCaption = "発注取消ボタン";
            buttonTool2.SharedProps.CustomizerDescription = "発注取消ボタン";
            buttonTool2.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            this.tToolbarsManager_Main.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            controlContainerTool2,
            popupMenuTool1,
            buttonTool2});
            this.tToolbarsManager_Main.ToolClick += new Infragistics.Win.UltraWinToolbars.ToolClickEventHandler(this.tToolbarsManager_Main_ToolClick);
            // 
            // _PMMIT01010UL_Toolbars_Dock_Area_Right
            // 
            this._PMMIT01010UL_Toolbars_Dock_Area_Right.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._PMMIT01010UL_Toolbars_Dock_Area_Right.AlphaBlendMode = Infragistics.Win.AlphaBlendMode.Disabled;
            this._PMMIT01010UL_Toolbars_Dock_Area_Right.BackColor = System.Drawing.Color.GhostWhite;
            this._PMMIT01010UL_Toolbars_Dock_Area_Right.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Right;
            this._PMMIT01010UL_Toolbars_Dock_Area_Right.ForeColor = System.Drawing.SystemColors.ControlText;
            this._PMMIT01010UL_Toolbars_Dock_Area_Right.Location = new System.Drawing.Point(703, 29);
            this._PMMIT01010UL_Toolbars_Dock_Area_Right.Name = "_PMMIT01010UL_Toolbars_Dock_Area_Right";
            this._PMMIT01010UL_Toolbars_Dock_Area_Right.Size = new System.Drawing.Size(0, 402);
            this._PMMIT01010UL_Toolbars_Dock_Area_Right.ToolbarsManager = this.tToolbarsManager_Main;
            // 
            // _PMMIT01010UL_Toolbars_Dock_Area_Top
            // 
            this._PMMIT01010UL_Toolbars_Dock_Area_Top.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._PMMIT01010UL_Toolbars_Dock_Area_Top.AlphaBlendMode = Infragistics.Win.AlphaBlendMode.Disabled;
            this._PMMIT01010UL_Toolbars_Dock_Area_Top.BackColor = System.Drawing.Color.GhostWhite;
            this._PMMIT01010UL_Toolbars_Dock_Area_Top.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Top;
            this._PMMIT01010UL_Toolbars_Dock_Area_Top.ForeColor = System.Drawing.SystemColors.ControlText;
            this._PMMIT01010UL_Toolbars_Dock_Area_Top.Location = new System.Drawing.Point(0, 0);
            this._PMMIT01010UL_Toolbars_Dock_Area_Top.Name = "_PMMIT01010UL_Toolbars_Dock_Area_Top";
            this._PMMIT01010UL_Toolbars_Dock_Area_Top.Size = new System.Drawing.Size(703, 29);
            this._PMMIT01010UL_Toolbars_Dock_Area_Top.ToolbarsManager = this.tToolbarsManager_Main;
            // 
            // _PMMIT01010UL_Toolbars_Dock_Area_Bottom
            // 
            this._PMMIT01010UL_Toolbars_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._PMMIT01010UL_Toolbars_Dock_Area_Bottom.AlphaBlendMode = Infragistics.Win.AlphaBlendMode.Disabled;
            this._PMMIT01010UL_Toolbars_Dock_Area_Bottom.BackColor = System.Drawing.Color.GhostWhite;
            this._PMMIT01010UL_Toolbars_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Bottom;
            this._PMMIT01010UL_Toolbars_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText;
            this._PMMIT01010UL_Toolbars_Dock_Area_Bottom.Location = new System.Drawing.Point(0, 431);
            this._PMMIT01010UL_Toolbars_Dock_Area_Bottom.Name = "_PMMIT01010UL_Toolbars_Dock_Area_Bottom";
            this._PMMIT01010UL_Toolbars_Dock_Area_Bottom.Size = new System.Drawing.Size(703, 0);
            this._PMMIT01010UL_Toolbars_Dock_Area_Bottom.ToolbarsManager = this.tToolbarsManager_Main;
            // 
            // PMMIT01010UL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.PMMIT01010UL_Fill_Panel);
            this.Controls.Add(this._PMMIT01010UL_Toolbars_Dock_Area_Left);
            this.Controls.Add(this._PMMIT01010UL_Toolbars_Dock_Area_Right);
            this.Controls.Add(this._PMMIT01010UL_Toolbars_Dock_Area_Top);
            this.Controls.Add(this._PMMIT01010UL_Toolbars_Dock_Area_Bottom);
            this.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 128 ) ));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "PMMIT01010UL";
            this.Size = new System.Drawing.Size(703, 431);
            this.Load += new System.EventHandler(this.PMMIT01010UL_Load);
            this.PMMIT01010UL_Fill_Panel.ResumeLayout(false);
            this.ViewButtonPanel.ResumeLayout(false);
            ( (System.ComponentModel.ISupportInitialize)( this.uGrid_Details ) ).EndInit();
            ( (System.ComponentModel.ISupportInitialize)( this.tToolbarsManager_Main ) ).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PMMIT01010UL_Fill_Panel;
        private System.Windows.Forms.Panel ViewButtonPanel;
        internal Infragistics.Win.UltraWinGrid.UltraGrid uGrid_Details;
        private Infragistics.Win.Misc.UltraButton uButton_OrderCancel;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _PMMIT01010UL_Toolbars_Dock_Area_Right;
        private Broadleaf.Library.Windows.Forms.TToolbarsManager tToolbarsManager_Main;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _PMMIT01010UL_Toolbars_Dock_Area_Left;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _PMMIT01010UL_Toolbars_Dock_Area_Top;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _PMMIT01010UL_Toolbars_Dock_Area_Bottom;
    }
}

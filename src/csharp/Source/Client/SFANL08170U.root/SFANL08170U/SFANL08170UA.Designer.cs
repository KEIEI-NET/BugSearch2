namespace Broadleaf.Windows.Forms
{
	partial class SFANL08170UA
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
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.UltraToolbar ultraToolbar1 = new Infragistics.Win.UltraWinToolbars.UltraToolbar( "Main_ToolBar" );
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool1 = new Infragistics.Win.UltraWinToolbars.ButtonTool( "SelectAll_ButtonTool" );
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool2 = new Infragistics.Win.UltraWinToolbars.ButtonTool( "CancelAll_ButtonTool" );
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool3 = new Infragistics.Win.UltraWinToolbars.ButtonTool( "SelectAll_ButtonTool" );
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool4 = new Infragistics.Win.UltraWinToolbars.ButtonTool( "CancelAll_ButtonTool" );
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel1 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel2 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel3 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel4 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel5 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( SFANL08170UA ) );
            this.lblInfoMessage = new System.Windows.Forms.Label();
            this.pnlFill = new System.Windows.Forms.Panel();
            this.gridExportDataSelect = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this._pnlFill_Toolbars_Dock_Area_Left = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this.Main_ToolbarsManager = new Broadleaf.Library.Windows.Forms.TToolbarsManager( this.components );
            this._pnlFill_Toolbars_Dock_Area_Right = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._pnlFill_Toolbars_Dock_Area_Top = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._pnlFill_Toolbars_Dock_Area_Bottom = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this.Main_StatusBar = new Infragistics.Win.UltraWinStatusBar.UltraStatusBar();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.ubExport = new Infragistics.Win.Misc.UltraButton();
            this.ubCancel = new Infragistics.Win.Misc.UltraButton();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.tArrowKeyControl1 = new Broadleaf.Library.Windows.Forms.TArrowKeyControl( this.components );
            this.tRetKeyControl1 = new Broadleaf.Library.Windows.Forms.TRetKeyControl( this.components );
            this.uttmGridToolTip = new Infragistics.Win.UltraWinToolTip.UltraToolTipManager( this.components );
            this.pnlFill.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridExportDataSelect)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Main_ToolbarsManager)).BeginInit();
            this.pnlBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblInfoMessage
            // 
            this.lblInfoMessage.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblInfoMessage.Font = new System.Drawing.Font( "ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)) );
            this.lblInfoMessage.Location = new System.Drawing.Point( 0, 0 );
            this.lblInfoMessage.Name = "lblInfoMessage";
            this.lblInfoMessage.Size = new System.Drawing.Size( 1016, 53 );
            this.lblInfoMessage.TabIndex = 7;
            this.lblInfoMessage.Text = "エクスポートする自由帳票印字位置設定を選択して下さい。";
            this.lblInfoMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlFill
            // 
            this.pnlFill.Controls.Add( this.gridExportDataSelect );
            this.pnlFill.Controls.Add( this._pnlFill_Toolbars_Dock_Area_Left );
            this.pnlFill.Controls.Add( this._pnlFill_Toolbars_Dock_Area_Right );
            this.pnlFill.Controls.Add( this._pnlFill_Toolbars_Dock_Area_Top );
            this.pnlFill.Controls.Add( this._pnlFill_Toolbars_Dock_Area_Bottom );
            this.pnlFill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFill.Location = new System.Drawing.Point( 0, 53 );
            this.pnlFill.Name = "pnlFill";
            this.pnlFill.Size = new System.Drawing.Size( 1016, 492 );
            this.pnlFill.TabIndex = 1;
            // 
            // gridExportDataSelect
            // 
            appearance1.BackColor = System.Drawing.Color.White;
            appearance1.BackColor2 = System.Drawing.Color.FromArgb( ((int)(((byte)(198)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))) );
            appearance1.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.gridExportDataSelect.DisplayLayout.Appearance = appearance1;
            this.gridExportDataSelect.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;
            this.gridExportDataSelect.DisplayLayout.MaxColScrollRegions = 1;
            this.gridExportDataSelect.DisplayLayout.MaxRowScrollRegions = 1;
            appearance2.BackColor = System.Drawing.Color.White;
            appearance2.BackColor2 = System.Drawing.Color.FromArgb( ((int)(((byte)(251)))), ((int)(((byte)(230)))), ((int)(((byte)(148)))) );
            appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.gridExportDataSelect.DisplayLayout.Override.ActiveCellAppearance = appearance2;
            appearance3.BackColor = System.Drawing.Color.FromArgb( ((int)(((byte)(251)))), ((int)(((byte)(230)))), ((int)(((byte)(148)))) );
            appearance3.BackColor2 = System.Drawing.Color.FromArgb( ((int)(((byte)(238)))), ((int)(((byte)(149)))), ((int)(((byte)(21)))) );
            appearance3.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance3.ForeColor = System.Drawing.Color.Black;
            this.gridExportDataSelect.DisplayLayout.Override.ActiveRowAppearance = appearance3;
            this.gridExportDataSelect.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No;
            this.gridExportDataSelect.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
            this.gridExportDataSelect.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
            appearance4.BackColorDisabled = System.Drawing.SystemColors.Control;
            this.gridExportDataSelect.DisplayLayout.Override.CellAppearance = appearance4;
            appearance5.BackColor = System.Drawing.Color.FromArgb( ((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))) );
            this.gridExportDataSelect.DisplayLayout.Override.EditCellAppearance = appearance5;
            appearance6.BackColor = System.Drawing.Color.FromArgb( ((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))) );
            appearance6.BackColor2 = System.Drawing.Color.FromArgb( ((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))) );
            appearance6.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance6.ForeColor = System.Drawing.Color.White;
            appearance6.TextHAlignAsString = "Center";
            appearance6.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
            this.gridExportDataSelect.DisplayLayout.Override.HeaderAppearance = appearance6;
            this.gridExportDataSelect.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.Select;
            appearance7.BackColor = System.Drawing.Color.Lavender;
            this.gridExportDataSelect.DisplayLayout.Override.RowAlternateAppearance = appearance7;
            appearance8.BorderColor = System.Drawing.Color.FromArgb( ((int)(((byte)(1)))), ((int)(((byte)(68)))), ((int)(((byte)(208)))) );
            this.gridExportDataSelect.DisplayLayout.Override.RowAppearance = appearance8;
            appearance9.BackColor = System.Drawing.Color.FromArgb( ((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))) );
            appearance9.BackColor2 = System.Drawing.Color.FromArgb( ((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))) );
            appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            this.gridExportDataSelect.DisplayLayout.Override.RowSelectorAppearance = appearance9;
            this.gridExportDataSelect.DisplayLayout.Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.Fixed;
            this.gridExportDataSelect.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.SingleAutoDrag;
            this.gridExportDataSelect.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.gridExportDataSelect.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.SingleAutoDrag;
            this.gridExportDataSelect.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.gridExportDataSelect.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridExportDataSelect.Location = new System.Drawing.Point( 0, 26 );
            this.gridExportDataSelect.Name = "gridExportDataSelect";
            this.gridExportDataSelect.Size = new System.Drawing.Size( 1016, 466 );
            this.gridExportDataSelect.TabIndex = 1;
            this.gridExportDataSelect.BeforeEnterEditMode += new System.ComponentModel.CancelEventHandler( this.gridExportDataSelect_BeforeEnterEditMode );
            this.gridExportDataSelect.AfterExitEditMode += new System.EventHandler( this.gridExportDataSelect_AfterExitEditMode );
            this.gridExportDataSelect.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler( this.gridExportDataSelect_MouseDoubleClick );
            this.gridExportDataSelect.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler( this.gridExportDataSelect_InitializeLayout );
            this.gridExportDataSelect.MouseLeaveElement += new Infragistics.Win.UIElementEventHandler( this.gridExportDataSelect_MouseLeaveElement );
            this.gridExportDataSelect.Enter += new System.EventHandler( this.gridExportDataSelect_Enter );
            this.gridExportDataSelect.AfterRowActivate += new System.EventHandler( this.gridExportDataSelect_AfterRowActivate );
            this.gridExportDataSelect.InitializeRow += new Infragistics.Win.UltraWinGrid.InitializeRowEventHandler( this.gridExportDataSelect_InitializeRow );
            this.gridExportDataSelect.MouseClick += new System.Windows.Forms.MouseEventHandler( this.gridExportDataSelect_MouseClick );
            this.gridExportDataSelect.MouseEnterElement += new Infragistics.Win.UIElementEventHandler( this.gridExportDataSelect_MouseEnterElement );
            this.gridExportDataSelect.KeyDown += new System.Windows.Forms.KeyEventHandler( this.gridExportDataSelect_KeyDown );
            this.gridExportDataSelect.AfterCellActivate += new System.EventHandler( this.gridExportDataSelect_AfterCellActivate );
            // 
            // _pnlFill_Toolbars_Dock_Area_Left
            // 
            this._pnlFill_Toolbars_Dock_Area_Left.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._pnlFill_Toolbars_Dock_Area_Left.BackColor = System.Drawing.Color.FromArgb( ((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))) );
            this._pnlFill_Toolbars_Dock_Area_Left.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Left;
            this._pnlFill_Toolbars_Dock_Area_Left.ForeColor = System.Drawing.SystemColors.ControlText;
            this._pnlFill_Toolbars_Dock_Area_Left.Location = new System.Drawing.Point( 0, 26 );
            this._pnlFill_Toolbars_Dock_Area_Left.Name = "_pnlFill_Toolbars_Dock_Area_Left";
            this._pnlFill_Toolbars_Dock_Area_Left.Size = new System.Drawing.Size( 0, 466 );
            this._pnlFill_Toolbars_Dock_Area_Left.ToolbarsManager = this.Main_ToolbarsManager;
            // 
            // Main_ToolbarsManager
            // 
            this.Main_ToolbarsManager.DesignerFlags = 1;
            this.Main_ToolbarsManager.DockWithinContainer = this.pnlFill;
            this.Main_ToolbarsManager.Style = Infragistics.Win.UltraWinToolbars.ToolbarStyle.Office2003;
            ultraToolbar1.DockedColumn = 0;
            ultraToolbar1.DockedRow = 0;
            ultraToolbar1.NonInheritedTools.AddRange( new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool1,
            buttonTool2} );
            ultraToolbar1.Text = "ツール";
            this.Main_ToolbarsManager.Toolbars.AddRange( new Infragistics.Win.UltraWinToolbars.UltraToolbar[] {
            ultraToolbar1} );
            buttonTool3.SharedProps.Caption = "全選択(&A)";
            buttonTool3.SharedProps.CustomizerCaption = "全選択";
            buttonTool3.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool4.SharedProps.Caption = "全解除(&D)";
            buttonTool4.SharedProps.CustomizerCaption = "全解除";
            buttonTool4.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            this.Main_ToolbarsManager.Tools.AddRange( new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool3,
            buttonTool4} );
            this.Main_ToolbarsManager.ToolClick += new Infragistics.Win.UltraWinToolbars.ToolClickEventHandler( this.Main_ToolbarsManager_ToolClick );
            // 
            // _pnlFill_Toolbars_Dock_Area_Right
            // 
            this._pnlFill_Toolbars_Dock_Area_Right.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._pnlFill_Toolbars_Dock_Area_Right.BackColor = System.Drawing.Color.FromArgb( ((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))) );
            this._pnlFill_Toolbars_Dock_Area_Right.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Right;
            this._pnlFill_Toolbars_Dock_Area_Right.ForeColor = System.Drawing.SystemColors.ControlText;
            this._pnlFill_Toolbars_Dock_Area_Right.Location = new System.Drawing.Point( 1016, 26 );
            this._pnlFill_Toolbars_Dock_Area_Right.Name = "_pnlFill_Toolbars_Dock_Area_Right";
            this._pnlFill_Toolbars_Dock_Area_Right.Size = new System.Drawing.Size( 0, 466 );
            this._pnlFill_Toolbars_Dock_Area_Right.ToolbarsManager = this.Main_ToolbarsManager;
            // 
            // _pnlFill_Toolbars_Dock_Area_Top
            // 
            this._pnlFill_Toolbars_Dock_Area_Top.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._pnlFill_Toolbars_Dock_Area_Top.BackColor = System.Drawing.Color.FromArgb( ((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))) );
            this._pnlFill_Toolbars_Dock_Area_Top.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Top;
            this._pnlFill_Toolbars_Dock_Area_Top.ForeColor = System.Drawing.SystemColors.ControlText;
            this._pnlFill_Toolbars_Dock_Area_Top.Location = new System.Drawing.Point( 0, 0 );
            this._pnlFill_Toolbars_Dock_Area_Top.Name = "_pnlFill_Toolbars_Dock_Area_Top";
            this._pnlFill_Toolbars_Dock_Area_Top.Size = new System.Drawing.Size( 1016, 26 );
            this._pnlFill_Toolbars_Dock_Area_Top.ToolbarsManager = this.Main_ToolbarsManager;
            // 
            // _pnlFill_Toolbars_Dock_Area_Bottom
            // 
            this._pnlFill_Toolbars_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._pnlFill_Toolbars_Dock_Area_Bottom.BackColor = System.Drawing.Color.FromArgb( ((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))) );
            this._pnlFill_Toolbars_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Bottom;
            this._pnlFill_Toolbars_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText;
            this._pnlFill_Toolbars_Dock_Area_Bottom.Location = new System.Drawing.Point( 0, 492 );
            this._pnlFill_Toolbars_Dock_Area_Bottom.Name = "_pnlFill_Toolbars_Dock_Area_Bottom";
            this._pnlFill_Toolbars_Dock_Area_Bottom.Size = new System.Drawing.Size( 1016, 0 );
            this._pnlFill_Toolbars_Dock_Area_Bottom.ToolbarsManager = this.Main_ToolbarsManager;
            // 
            // Main_StatusBar
            // 
            this.Main_StatusBar.Location = new System.Drawing.Point( 0, 599 );
            this.Main_StatusBar.Name = "Main_StatusBar";
            appearance10.FontData.SizeInPoints = 9F;
            ultraStatusPanel1.Appearance = appearance10;
            ultraStatusPanel1.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            ultraStatusPanel1.Key = "StatusBarPanel_Text";
            ultraStatusPanel1.SizingMode = Infragistics.Win.UltraWinStatusBar.PanelSizingMode.Spring;
            ultraStatusPanel2.Key = "ProgressKido";
            appearance11.FontData.SizeInPoints = 9F;
            appearance11.ForeColor = System.Drawing.Color.Black;
            ultraStatusPanel2.ProgressBarInfo.Appearance = appearance11;
            appearance12.ForeColor = System.Drawing.Color.Black;
            ultraStatusPanel2.ProgressBarInfo.FillAppearance = appearance12;
            ultraStatusPanel2.ProgressBarInfo.Label = "初期情報取得中";
            ultraStatusPanel2.Style = Infragistics.Win.UltraWinStatusBar.PanelStyle.Progress;
            ultraStatusPanel2.ToolTipText = "初期情報取得中";
            ultraStatusPanel2.Visible = false;
            ultraStatusPanel2.Width = 150;
            ultraStatusPanel3.Key = "StatusBarPanel_Progress";
            appearance13.ForeColor = System.Drawing.Color.Black;
            ultraStatusPanel3.ProgressBarInfo.FillAppearance = appearance13;
            ultraStatusPanel3.Style = Infragistics.Win.UltraWinStatusBar.PanelStyle.Progress;
            ultraStatusPanel3.Visible = false;
            ultraStatusPanel3.Width = 150;
            ultraStatusPanel4.BorderStyle = Infragistics.Win.UIElementBorderStyle.RaisedSoft;
            ultraStatusPanel4.Key = "Date";
            ultraStatusPanel4.Style = Infragistics.Win.UltraWinStatusBar.PanelStyle.Date;
            ultraStatusPanel4.Visible = false;
            ultraStatusPanel5.BorderStyle = Infragistics.Win.UIElementBorderStyle.RaisedSoft;
            ultraStatusPanel5.Key = "Time";
            ultraStatusPanel5.Style = Infragistics.Win.UltraWinStatusBar.PanelStyle.Time;
            ultraStatusPanel5.Visible = false;
            ultraStatusPanel5.Width = 50;
            this.Main_StatusBar.Panels.AddRange( new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel[] {
            ultraStatusPanel1,
            ultraStatusPanel2,
            ultraStatusPanel3,
            ultraStatusPanel4,
            ultraStatusPanel5} );
            this.Main_StatusBar.Size = new System.Drawing.Size( 1016, 23 );
            this.Main_StatusBar.TabIndex = 23;
            this.Main_StatusBar.ViewStyle = Infragistics.Win.UltraWinStatusBar.ViewStyle.Office2003;
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add( this.ubExport );
            this.pnlBottom.Controls.Add( this.ubCancel );
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point( 0, 545 );
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size( 1016, 54 );
            this.pnlBottom.TabIndex = 2;
            // 
            // ubExport
            // 
            this.ubExport.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ubExport.Font = new System.Drawing.Font( "ＭＳ ゴシック", 9F );
            this.ubExport.Location = new System.Drawing.Point( 371, 13 );
            this.ubExport.Name = "ubExport";
            this.ubExport.Size = new System.Drawing.Size( 135, 30 );
            this.ubExport.TabIndex = 1;
            this.ubExport.Text = "エクスポート(&E)";
            this.ubExport.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.ubExport.Click += new System.EventHandler( this.ubExport_Click );
            // 
            // ubCancel
            // 
            this.ubCancel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ubCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ubCancel.Location = new System.Drawing.Point( 511, 13 );
            this.ubCancel.Name = "ubCancel";
            this.ubCancel.Size = new System.Drawing.Size( 135, 30 );
            this.ubCancel.TabIndex = 2;
            this.ubCancel.Text = "終了(&X)";
            this.ubCancel.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.ubCancel.Click += new System.EventHandler( this.ubCancel_Click );
            // 
            // tArrowKeyControl1
            // 
            this.tArrowKeyControl1.OwnerForm = this;
            // 
            // tRetKeyControl1
            // 
            this.tRetKeyControl1.OwnerForm = this;
            this.tRetKeyControl1.Style = Broadleaf.Library.Windows.Forms.emFocusStyle.ByTab;
            // 
            // uttmGridToolTip
            // 
            appearance14.FontData.Name = "ＭＳ ゴシック";
            this.uttmGridToolTip.Appearance = appearance14;
            this.uttmGridToolTip.ContainingControl = this;
            // 
            // SFANL08170UA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 8F, 15F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb( ((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))) );
            this.ClientSize = new System.Drawing.Size( 1016, 622 );
            this.Controls.Add( this.pnlFill );
            this.Controls.Add( this.lblInfoMessage );
            this.Controls.Add( this.pnlBottom );
            this.Controls.Add( this.Main_StatusBar );
            this.Font = new System.Drawing.Font( "ＭＳ ゴシック", 11F );
            this.Icon = ((System.Drawing.Icon)(resources.GetObject( "$this.Icon" )));
            this.Margin = new System.Windows.Forms.Padding( 4 );
            this.Name = "SFANL08170UA";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "自由帳票印字位置エクスポート";
            this.Load += new System.EventHandler( this.SFANL08170UA_Load );
            this.Shown += new System.EventHandler( this.SFANL08170UA_Shown );
            this.pnlFill.ResumeLayout( false );
            ((System.ComponentModel.ISupportInitialize)(this.gridExportDataSelect)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Main_ToolbarsManager)).EndInit();
            this.pnlBottom.ResumeLayout( false );
            this.ResumeLayout( false );

		}

		#endregion

		private System.Windows.Forms.Label lblInfoMessage;
		private System.Windows.Forms.Panel pnlFill;
		private Infragistics.Win.UltraWinStatusBar.UltraStatusBar Main_StatusBar;
		private System.Windows.Forms.Panel pnlBottom;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _pnlFill_Toolbars_Dock_Area_Left;
		private Broadleaf.Library.Windows.Forms.TToolbarsManager Main_ToolbarsManager;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _pnlFill_Toolbars_Dock_Area_Right;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _pnlFill_Toolbars_Dock_Area_Top;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _pnlFill_Toolbars_Dock_Area_Bottom;
		private Infragistics.Win.UltraWinGrid.UltraGrid gridExportDataSelect;
		private Infragistics.Win.Misc.UltraButton ubExport;
		private Infragistics.Win.Misc.UltraButton ubCancel;
		private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
		private Broadleaf.Library.Windows.Forms.TArrowKeyControl tArrowKeyControl1;
		private Broadleaf.Library.Windows.Forms.TRetKeyControl tRetKeyControl1;
		private Infragistics.Win.UltraWinToolTip.UltraToolTipManager uttmGridToolTip;
	}
}


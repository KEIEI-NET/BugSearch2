namespace Broadleaf.Windows.Forms
{
	partial class MAKON01110UH
	{
		/// <summary>
		/// 必要なデザイナ変数です。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 使用中のリソースをすべてクリーンアップします。
		/// </summary>
		/// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
		protected override void Dispose( bool disposing )
		{
			if (disposing && ( components != null ))
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
			Infragistics.Win.UltraWinToolbars.UltraToolbar ultraToolbar1 = new Infragistics.Win.UltraWinToolbars.UltraToolbar("標準");
			Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool1 = new Infragistics.Win.UltraWinToolbars.ButtonTool("ButtonTool_Decision");
			Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool2 = new Infragistics.Win.UltraWinToolbars.ButtonTool("ButtonTool_Back");
			Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool3 = new Infragistics.Win.UltraWinToolbars.ButtonTool("ButtonTool_Decision");
			Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool4 = new Infragistics.Win.UltraWinToolbars.ButtonTool("ButtonTool_Back");
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MAKON01110UH));
			this.uStatusBar_Main = new Infragistics.Win.UltraWinStatusBar.UltraStatusBar();
			this.MAKON01110UI_Fill_Panel = new System.Windows.Forms.Panel();
			this.uGrid_Select = new Infragistics.Win.UltraWinGrid.UltraGrid();
			this.timer_InitialFocus = new System.Windows.Forms.Timer(this.components);
			this._MAKON01110UI_Toolbars_Dock_Area_Left = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
			this.tToolbarsManager_MainMenu = new Broadleaf.Library.Windows.Forms.TToolbarsManager(this.components);
			this._MAKON01110UI_Toolbars_Dock_Area_Right = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
			this._MAKON01110UI_Toolbars_Dock_Area_Top = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
			this._MAKON01110UI_Toolbars_Dock_Area_Bottom = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
			this.MAKON01110UI_Fill_Panel.SuspendLayout();
			( (System.ComponentModel.ISupportInitialize)( this.uGrid_Select ) ).BeginInit();
			( (System.ComponentModel.ISupportInitialize)( this.tToolbarsManager_MainMenu ) ).BeginInit();
			this.SuspendLayout();
			// 
			// uStatusBar_Main
			// 
			this.uStatusBar_Main.Location = new System.Drawing.Point(0, 413);
			this.uStatusBar_Main.Name = "uStatusBar_Main";
			this.uStatusBar_Main.Size = new System.Drawing.Size(637, 23);
			this.uStatusBar_Main.TabIndex = 55;
			this.uStatusBar_Main.ViewStyle = Infragistics.Win.UltraWinStatusBar.ViewStyle.Office2003;
			// 
			// MAKON01110UI_Fill_Panel
			// 
			this.MAKON01110UI_Fill_Panel.Controls.Add(this.uGrid_Select);
			this.MAKON01110UI_Fill_Panel.Cursor = System.Windows.Forms.Cursors.Default;
			this.MAKON01110UI_Fill_Panel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.MAKON01110UI_Fill_Panel.Location = new System.Drawing.Point(0, 26);
			this.MAKON01110UI_Fill_Panel.Name = "MAKON01110UI_Fill_Panel";
			this.MAKON01110UI_Fill_Panel.Size = new System.Drawing.Size(637, 387);
			this.MAKON01110UI_Fill_Panel.TabIndex = 56;
			// 
			// uGrid_Select
			// 
			appearance1.BackColor = System.Drawing.Color.White;
			appearance1.BackColor2 = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 198 ) ) ) ), ( (int)( ( (byte)( 219 ) ) ) ), ( (int)( ( (byte)( 255 ) ) ) ));
			appearance1.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
			this.uGrid_Select.DisplayLayout.Appearance = appearance1;
			this.uGrid_Select.DisplayLayout.GroupByBox.Hidden = true;
			this.uGrid_Select.DisplayLayout.InterBandSpacing = 10;
			this.uGrid_Select.DisplayLayout.MaxColScrollRegions = 1;
			this.uGrid_Select.DisplayLayout.MaxRowScrollRegions = 1;
			appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.None;
			this.uGrid_Select.DisplayLayout.Override.ActiveCellAppearance = appearance2;
			this.uGrid_Select.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No;
			this.uGrid_Select.DisplayLayout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.NotAllowed;
			this.uGrid_Select.DisplayLayout.Override.AllowColSizing = Infragistics.Win.UltraWinGrid.AllowColSizing.Free;
			this.uGrid_Select.DisplayLayout.Override.AllowColSwapping = Infragistics.Win.UltraWinGrid.AllowColSwapping.WithinBand;
			this.uGrid_Select.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
			this.uGrid_Select.DisplayLayout.Override.AllowGroupBy = Infragistics.Win.DefaultableBoolean.False;
			this.uGrid_Select.DisplayLayout.Override.AllowGroupMoving = Infragistics.Win.UltraWinGrid.AllowGroupMoving.NotAllowed;
			this.uGrid_Select.DisplayLayout.Override.AllowGroupSwapping = Infragistics.Win.UltraWinGrid.AllowGroupSwapping.NotAllowed;
			this.uGrid_Select.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
			this.uGrid_Select.DisplayLayout.Override.AllowRowLayoutCellSizing = Infragistics.Win.UltraWinGrid.RowLayoutSizing.None;
			this.uGrid_Select.DisplayLayout.Override.AllowRowLayoutCellSpanSizing = Infragistics.Win.Layout.GridBagLayoutAllowSpanSizing.None;
			this.uGrid_Select.DisplayLayout.Override.AllowRowLayoutColMoving = Infragistics.Win.Layout.GridBagLayoutAllowMoving.None;
			this.uGrid_Select.DisplayLayout.Override.AllowRowLayoutLabelSizing = Infragistics.Win.UltraWinGrid.RowLayoutSizing.None;
			this.uGrid_Select.DisplayLayout.Override.AllowRowLayoutLabelSpanSizing = Infragistics.Win.Layout.GridBagLayoutAllowSpanSizing.None;
			this.uGrid_Select.DisplayLayout.Override.AllowRowSummaries = Infragistics.Win.UltraWinGrid.AllowRowSummaries.False;
			this.uGrid_Select.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
			this.uGrid_Select.DisplayLayout.Override.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
			appearance3.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 89 ) ) ) ), ( (int)( ( (byte)( 135 ) ) ) ), ( (int)( ( (byte)( 214 ) ) ) ));
			appearance3.BackColor2 = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 7 ) ) ) ), ( (int)( ( (byte)( 59 ) ) ) ), ( (int)( ( (byte)( 150 ) ) ) ));
			appearance3.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
			appearance3.ForeColor = System.Drawing.Color.White;
			appearance3.TextHAlignAsString = "Center";
			appearance3.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
			this.uGrid_Select.DisplayLayout.Override.HeaderAppearance = appearance3;
			this.uGrid_Select.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortSingle;
			appearance4.BackColor = System.Drawing.Color.Lavender;
			this.uGrid_Select.DisplayLayout.Override.RowAlternateAppearance = appearance4;
			appearance5.BorderColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 1 ) ) ) ), ( (int)( ( (byte)( 68 ) ) ) ), ( (int)( ( (byte)( 208 ) ) ) ));
			appearance5.TextVAlignAsString = "Middle";
			this.uGrid_Select.DisplayLayout.Override.RowAppearance = appearance5;
			this.uGrid_Select.DisplayLayout.Override.RowFilterAction = Infragistics.Win.UltraWinGrid.RowFilterAction.HideFilteredOutRows;
			this.uGrid_Select.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand;
			appearance6.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 89 ) ) ) ), ( (int)( ( (byte)( 135 ) ) ) ), ( (int)( ( (byte)( 214 ) ) ) ));
			appearance6.BackColor2 = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 7 ) ) ) ), ( (int)( ( (byte)( 59 ) ) ) ), ( (int)( ( (byte)( 150 ) ) ) ));
			appearance6.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
			appearance6.ForeColor = System.Drawing.Color.White;
			this.uGrid_Select.DisplayLayout.Override.RowSelectorAppearance = appearance6;
			this.uGrid_Select.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True;
			this.uGrid_Select.DisplayLayout.Override.RowSelectorWidth = 12;
			this.uGrid_Select.DisplayLayout.Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.AutoFixed;
			appearance7.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 251 ) ) ) ), ( (int)( ( (byte)( 230 ) ) ) ), ( (int)( ( (byte)( 148 ) ) ) ));
			appearance7.BackColor2 = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 238 ) ) ) ), ( (int)( ( (byte)( 149 ) ) ) ), ( (int)( ( (byte)( 21 ) ) ) ));
			appearance7.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
			appearance7.ForeColor = System.Drawing.Color.Black;
			this.uGrid_Select.DisplayLayout.Override.SelectedRowAppearance = appearance7;
			this.uGrid_Select.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.None;
			this.uGrid_Select.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.None;
			this.uGrid_Select.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.SingleAutoDrag;
			this.uGrid_Select.DisplayLayout.Override.TipStyleCell = Infragistics.Win.UltraWinGrid.TipStyle.Hide;
			this.uGrid_Select.DisplayLayout.Override.TipStyleRowConnector = Infragistics.Win.UltraWinGrid.TipStyle.Hide;
			this.uGrid_Select.DisplayLayout.Override.TipStyleScroll = Infragistics.Win.UltraWinGrid.TipStyle.Hide;
			this.uGrid_Select.DisplayLayout.RowConnectorColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 168 ) ) ) ), ( (int)( ( (byte)( 167 ) ) ) ), ( (int)( ( (byte)( 191 ) ) ) ));
			this.uGrid_Select.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
			this.uGrid_Select.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
			this.uGrid_Select.DisplayLayout.UseFixedHeaders = true;
			this.uGrid_Select.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand;
			this.uGrid_Select.Dock = System.Windows.Forms.DockStyle.Fill;
			this.uGrid_Select.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 128 ) ));
			this.uGrid_Select.Location = new System.Drawing.Point(0, 0);
			this.uGrid_Select.Name = "uGrid_Select";
			this.uGrid_Select.Size = new System.Drawing.Size(637, 387);
			this.uGrid_Select.TabIndex = 6;
			this.uGrid_Select.DoubleClick += new System.EventHandler(this.uGrid_Select_DoubleClick);
			this.uGrid_Select.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.uGrid_Select_InitializeLayout);
			this.uGrid_Select.KeyDown += new System.Windows.Forms.KeyEventHandler(this.uGrid_Select_KeyDown);
			// 
			// timer_InitialFocus
			// 
			this.timer_InitialFocus.Interval = 1;
			this.timer_InitialFocus.Tick += new System.EventHandler(this.timer_InitialFocus_Tick);
			// 
			// _MAKON01110UI_Toolbars_Dock_Area_Left
			// 
			this._MAKON01110UI_Toolbars_Dock_Area_Left.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
			this._MAKON01110UI_Toolbars_Dock_Area_Left.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 215 ) ) ) ), ( (int)( ( (byte)( 215 ) ) ) ), ( (int)( ( (byte)( 229 ) ) ) ));
			this._MAKON01110UI_Toolbars_Dock_Area_Left.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Left;
			this._MAKON01110UI_Toolbars_Dock_Area_Left.ForeColor = System.Drawing.SystemColors.ControlText;
			this._MAKON01110UI_Toolbars_Dock_Area_Left.Location = new System.Drawing.Point(0, 26);
			this._MAKON01110UI_Toolbars_Dock_Area_Left.Name = "_MAKON01110UI_Toolbars_Dock_Area_Left";
			this._MAKON01110UI_Toolbars_Dock_Area_Left.Size = new System.Drawing.Size(0, 387);
			this._MAKON01110UI_Toolbars_Dock_Area_Left.ToolbarsManager = this.tToolbarsManager_MainMenu;
			// 
			// tToolbarsManager_MainMenu
			// 
			this.tToolbarsManager_MainMenu.DesignerFlags = 1;
			this.tToolbarsManager_MainMenu.DockWithinContainer = this;
			this.tToolbarsManager_MainMenu.DockWithinContainerBaseType = typeof(System.Windows.Forms.Form);
			this.tToolbarsManager_MainMenu.RuntimeCustomizationOptions = Infragistics.Win.UltraWinToolbars.RuntimeCustomizationOptions.None;
			this.tToolbarsManager_MainMenu.ShowFullMenusDelay = 500;
			this.tToolbarsManager_MainMenu.Style = Infragistics.Win.UltraWinToolbars.ToolbarStyle.Office2003;
			ultraToolbar1.DockedColumn = 0;
			ultraToolbar1.DockedRow = 0;
			ultraToolbar1.NonInheritedTools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool1,
            buttonTool2});
			ultraToolbar1.Settings.AllowFloating = Infragistics.Win.DefaultableBoolean.False;
			ultraToolbar1.Settings.AllowHiding = Infragistics.Win.DefaultableBoolean.False;
			ultraToolbar1.Text = "標準";
			this.tToolbarsManager_MainMenu.Toolbars.AddRange(new Infragistics.Win.UltraWinToolbars.UltraToolbar[] {
            ultraToolbar1});
			buttonTool3.SharedProps.Caption = "確定(&S)";
			buttonTool3.SharedProps.CustomizerCaption = "確定ボタン";
			buttonTool3.SharedProps.CustomizerDescription = "確定ボタン";
			buttonTool3.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
			buttonTool4.SharedProps.Caption = "戻る(&X)";
			buttonTool4.SharedProps.CustomizerCaption = "戻るボタン";
			buttonTool4.SharedProps.CustomizerDescription = "戻るボタン";
			buttonTool4.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
			this.tToolbarsManager_MainMenu.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool3,
            buttonTool4});
			this.tToolbarsManager_MainMenu.ToolClick += new Infragistics.Win.UltraWinToolbars.ToolClickEventHandler(this.tToolbarsManager_MainMenu_ToolClick);
			// 
			// _MAKON01110UI_Toolbars_Dock_Area_Right
			// 
			this._MAKON01110UI_Toolbars_Dock_Area_Right.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
			this._MAKON01110UI_Toolbars_Dock_Area_Right.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 215 ) ) ) ), ( (int)( ( (byte)( 215 ) ) ) ), ( (int)( ( (byte)( 229 ) ) ) ));
			this._MAKON01110UI_Toolbars_Dock_Area_Right.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Right;
			this._MAKON01110UI_Toolbars_Dock_Area_Right.ForeColor = System.Drawing.SystemColors.ControlText;
			this._MAKON01110UI_Toolbars_Dock_Area_Right.Location = new System.Drawing.Point(637, 26);
			this._MAKON01110UI_Toolbars_Dock_Area_Right.Name = "_MAKON01110UI_Toolbars_Dock_Area_Right";
			this._MAKON01110UI_Toolbars_Dock_Area_Right.Size = new System.Drawing.Size(0, 387);
			this._MAKON01110UI_Toolbars_Dock_Area_Right.ToolbarsManager = this.tToolbarsManager_MainMenu;
			// 
			// _MAKON01110UI_Toolbars_Dock_Area_Top
			// 
			this._MAKON01110UI_Toolbars_Dock_Area_Top.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
			this._MAKON01110UI_Toolbars_Dock_Area_Top.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 215 ) ) ) ), ( (int)( ( (byte)( 215 ) ) ) ), ( (int)( ( (byte)( 229 ) ) ) ));
			this._MAKON01110UI_Toolbars_Dock_Area_Top.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Top;
			this._MAKON01110UI_Toolbars_Dock_Area_Top.ForeColor = System.Drawing.SystemColors.ControlText;
			this._MAKON01110UI_Toolbars_Dock_Area_Top.Location = new System.Drawing.Point(0, 0);
			this._MAKON01110UI_Toolbars_Dock_Area_Top.Name = "_MAKON01110UI_Toolbars_Dock_Area_Top";
			this._MAKON01110UI_Toolbars_Dock_Area_Top.Size = new System.Drawing.Size(637, 26);
			this._MAKON01110UI_Toolbars_Dock_Area_Top.ToolbarsManager = this.tToolbarsManager_MainMenu;
			// 
			// _MAKON01110UI_Toolbars_Dock_Area_Bottom
			// 
			this._MAKON01110UI_Toolbars_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
			this._MAKON01110UI_Toolbars_Dock_Area_Bottom.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 215 ) ) ) ), ( (int)( ( (byte)( 215 ) ) ) ), ( (int)( ( (byte)( 229 ) ) ) ));
			this._MAKON01110UI_Toolbars_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Bottom;
			this._MAKON01110UI_Toolbars_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText;
			this._MAKON01110UI_Toolbars_Dock_Area_Bottom.Location = new System.Drawing.Point(0, 413);
			this._MAKON01110UI_Toolbars_Dock_Area_Bottom.Name = "_MAKON01110UI_Toolbars_Dock_Area_Bottom";
			this._MAKON01110UI_Toolbars_Dock_Area_Bottom.Size = new System.Drawing.Size(637, 0);
			this._MAKON01110UI_Toolbars_Dock_Area_Bottom.ToolbarsManager = this.tToolbarsManager_MainMenu;
			// 
			// MAKON01110UI
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 222 ) ) ) ), ( (int)( ( (byte)( 239 ) ) ) ), ( (int)( ( (byte)( 254 ) ) ) ));
			this.ClientSize = new System.Drawing.Size(637, 436);
			this.Controls.Add(this.MAKON01110UI_Fill_Panel);
			this.Controls.Add(this._MAKON01110UI_Toolbars_Dock_Area_Left);
			this.Controls.Add(this._MAKON01110UI_Toolbars_Dock_Area_Right);
			this.Controls.Add(this._MAKON01110UI_Toolbars_Dock_Area_Top);
			this.Controls.Add(this._MAKON01110UI_Toolbars_Dock_Area_Bottom);
			this.Controls.Add(this.uStatusBar_Main);
			this.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 128 ) ));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ( (System.Drawing.Icon)( resources.GetObject("$this.Icon") ) );
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "MAKON01110UI";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "同一伝票番号検索";
			this.Load += new System.EventHandler(this.MAKON01110UI_Load);
			this.MAKON01110UI_Fill_Panel.ResumeLayout(false);
			( (System.ComponentModel.ISupportInitialize)( this.uGrid_Select ) ).EndInit();
			( (System.ComponentModel.ISupportInitialize)( this.tToolbarsManager_MainMenu ) ).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private Infragistics.Win.UltraWinStatusBar.UltraStatusBar uStatusBar_Main;
		private Broadleaf.Library.Windows.Forms.TToolbarsManager tToolbarsManager_MainMenu;
		private System.Windows.Forms.Panel MAKON01110UI_Fill_Panel;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _MAKON01110UI_Toolbars_Dock_Area_Left;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _MAKON01110UI_Toolbars_Dock_Area_Right;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _MAKON01110UI_Toolbars_Dock_Area_Top;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _MAKON01110UI_Toolbars_Dock_Area_Bottom;
		public Infragistics.Win.UltraWinGrid.UltraGrid uGrid_Select;
		private System.Windows.Forms.Timer timer_InitialFocus;
	}
}
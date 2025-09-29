namespace Broadleaf.Windows.Forms
{
	partial class DCKOU04101UB
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( DCKOU04101UB ) );
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            this.imageList1 = new System.Windows.Forms.ImageList( this.components );
            this.UserControl_InputDetails_Fill_Panel = new System.Windows.Forms.Panel();
            this.DataView_Panel = new System.Windows.Forms.Panel();
            this.uGrid_Details = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.PrintExtra_Panel = new System.Windows.Forms.Panel();
            this.Select_Button = new Infragistics.Win.Misc.UltraButton();
            this.UnSelect_Button = new Infragistics.Win.Misc.UltraButton();
            this.timer_SelectRow = new System.Windows.Forms.Timer( this.components );
            this.timer_GridSetFocus = new System.Windows.Forms.Timer( this.components );
            this.uiSetControl1 = new Broadleaf.Library.Windows.Forms.UiSetControl( this.components );
            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.lb_MaxSelectCount = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel16 = new Infragistics.Win.Misc.UltraLabel();
            this.lb_SelectedCount = new Infragistics.Win.Misc.UltraLabel();
            this.UserControl_InputDetails_Fill_Panel.SuspendLayout();
            this.DataView_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uGrid_Details)).BeginInit();
            this.PrintExtra_Panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject( "imageList1.ImageStream" )));
            this.imageList1.TransparentColor = System.Drawing.Color.Cyan;
            this.imageList1.Images.SetKeyName( 0, "携帯電話.bmp" );
            this.imageList1.Images.SetKeyName( 1, "携帯電話検索.bmp" );
            // 
            // UserControl_InputDetails_Fill_Panel
            // 
            this.UserControl_InputDetails_Fill_Panel.Controls.Add( this.DataView_Panel );
            this.UserControl_InputDetails_Fill_Panel.Controls.Add( this.PrintExtra_Panel );
            this.UserControl_InputDetails_Fill_Panel.Cursor = System.Windows.Forms.Cursors.Default;
            this.UserControl_InputDetails_Fill_Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UserControl_InputDetails_Fill_Panel.Location = new System.Drawing.Point( 0, 0 );
            this.UserControl_InputDetails_Fill_Panel.Name = "UserControl_InputDetails_Fill_Panel";
            this.UserControl_InputDetails_Fill_Panel.Size = new System.Drawing.Size( 898, 507 );
            this.UserControl_InputDetails_Fill_Panel.TabIndex = 0;
            // 
            // DataView_Panel
            // 
            this.DataView_Panel.Controls.Add( this.uGrid_Details );
            this.DataView_Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DataView_Panel.Font = new System.Drawing.Font( "ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)) );
            this.DataView_Panel.Location = new System.Drawing.Point( 0, 32 );
            this.DataView_Panel.Name = "DataView_Panel";
            this.DataView_Panel.Size = new System.Drawing.Size( 898, 475 );
            this.DataView_Panel.TabIndex = 7;
            // 
            // uGrid_Details
            // 
            appearance1.BackColor = System.Drawing.Color.White;
            appearance1.BackColor2 = System.Drawing.Color.FromArgb( ((int)(((byte)(198)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))) );
            appearance1.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.uGrid_Details.DisplayLayout.Appearance = appearance1;
            this.uGrid_Details.DisplayLayout.GroupByBox.Hidden = true;
            this.uGrid_Details.DisplayLayout.InterBandSpacing = 10;
            this.uGrid_Details.DisplayLayout.MaxColScrollRegions = 1;
            this.uGrid_Details.DisplayLayout.MaxRowScrollRegions = 1;
            appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.None;
            this.uGrid_Details.DisplayLayout.Override.ActiveCellAppearance = appearance2;
            this.uGrid_Details.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No;
            this.uGrid_Details.DisplayLayout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.WithinBand;
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
            this.uGrid_Details.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            this.uGrid_Details.DisplayLayout.Override.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
            appearance3.BackColor = System.Drawing.Color.FromArgb( ((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))) );
            appearance3.BackColor2 = System.Drawing.Color.FromArgb( ((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))) );
            appearance3.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance3.ForeColor = System.Drawing.Color.White;
            appearance3.TextHAlignAsString = "Center";
            appearance3.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
            this.uGrid_Details.DisplayLayout.Override.HeaderAppearance = appearance3;
            this.uGrid_Details.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortSingle;
            appearance4.BackColor = System.Drawing.Color.Lavender;
            this.uGrid_Details.DisplayLayout.Override.RowAlternateAppearance = appearance4;
            appearance5.BorderColor = System.Drawing.Color.FromArgb( ((int)(((byte)(1)))), ((int)(((byte)(68)))), ((int)(((byte)(208)))) );
            appearance5.TextVAlignAsString = "Middle";
            this.uGrid_Details.DisplayLayout.Override.RowAppearance = appearance5;
            this.uGrid_Details.DisplayLayout.Override.RowFilterAction = Infragistics.Win.UltraWinGrid.RowFilterAction.HideFilteredOutRows;
            this.uGrid_Details.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand;
            appearance6.BackColor = System.Drawing.Color.FromArgb( ((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))) );
            appearance6.BackColor2 = System.Drawing.Color.FromArgb( ((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))) );
            appearance6.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance6.ForeColor = System.Drawing.Color.White;
            this.uGrid_Details.DisplayLayout.Override.RowSelectorAppearance = appearance6;
            this.uGrid_Details.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True;
            this.uGrid_Details.DisplayLayout.Override.RowSelectorWidth = 12;
            this.uGrid_Details.DisplayLayout.Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.AutoFixed;
            appearance7.BackColor = System.Drawing.Color.FromArgb( ((int)(((byte)(251)))), ((int)(((byte)(230)))), ((int)(((byte)(148)))) );
            appearance7.BackColor2 = System.Drawing.Color.FromArgb( ((int)(((byte)(238)))), ((int)(((byte)(149)))), ((int)(((byte)(21)))) );
            appearance7.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance7.ForeColor = System.Drawing.Color.Black;
            this.uGrid_Details.DisplayLayout.Override.SelectedRowAppearance = appearance7;
            this.uGrid_Details.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.uGrid_Details.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.uGrid_Details.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.SingleAutoDrag;
            this.uGrid_Details.DisplayLayout.Override.TipStyleCell = Infragistics.Win.UltraWinGrid.TipStyle.Hide;
            this.uGrid_Details.DisplayLayout.Override.TipStyleRowConnector = Infragistics.Win.UltraWinGrid.TipStyle.Hide;
            this.uGrid_Details.DisplayLayout.Override.TipStyleScroll = Infragistics.Win.UltraWinGrid.TipStyle.Hide;
            this.uGrid_Details.DisplayLayout.RowConnectorColor = System.Drawing.Color.FromArgb( ((int)(((byte)(168)))), ((int)(((byte)(167)))), ((int)(((byte)(191)))) );
            this.uGrid_Details.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.uGrid_Details.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.uGrid_Details.DisplayLayout.UseFixedHeaders = true;
            this.uGrid_Details.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand;
            this.uGrid_Details.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uGrid_Details.Font = new System.Drawing.Font( "ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)) );
            this.uGrid_Details.Location = new System.Drawing.Point( 0, 0 );
            this.uGrid_Details.Name = "uGrid_Details";
            this.uGrid_Details.Size = new System.Drawing.Size( 898, 475 );
            this.uGrid_Details.TabIndex = 5;
            this.uGrid_Details.Click += new System.EventHandler( this.uGrid_Details_Click );
            this.uGrid_Details.Enter += new System.EventHandler( this.uGrid_Details_Enter );
            this.uGrid_Details.Leave += new System.EventHandler( this.uGrid_Details_Leave );
            this.uGrid_Details.KeyDown += new System.Windows.Forms.KeyEventHandler( this.uGrid_Details_KeyDown );
            // 
            // PrintExtra_Panel
            // 
            this.PrintExtra_Panel.Controls.Add( this.ultraLabel1 );
            this.PrintExtra_Panel.Controls.Add( this.lb_MaxSelectCount );
            this.PrintExtra_Panel.Controls.Add( this.ultraLabel16 );
            this.PrintExtra_Panel.Controls.Add( this.lb_SelectedCount );
            this.PrintExtra_Panel.Controls.Add( this.Select_Button );
            this.PrintExtra_Panel.Controls.Add( this.UnSelect_Button );
            this.PrintExtra_Panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.PrintExtra_Panel.Location = new System.Drawing.Point( 0, 0 );
            this.PrintExtra_Panel.Name = "PrintExtra_Panel";
            this.PrintExtra_Panel.Size = new System.Drawing.Size( 898, 32 );
            this.PrintExtra_Panel.TabIndex = 6;
            // 
            // Select_Button
            // 
            this.Select_Button.Cursor = System.Windows.Forms.Cursors.Default;
            this.Select_Button.Font = new System.Drawing.Font( "ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)) );
            appearance12.BackColor = System.Drawing.Color.FromArgb( ((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))) );
            this.Select_Button.HotTrackAppearance = appearance12;
            this.Select_Button.Location = new System.Drawing.Point( 108, 4 );
            this.Select_Button.Name = "Select_Button";
            this.Select_Button.Size = new System.Drawing.Size( 100, 27 );
            this.Select_Button.TabIndex = 3;
            this.Select_Button.Text = "全て選択";
            this.Select_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Select_Button.Click += new System.EventHandler( this.Select_Button_Click );
            // 
            // UnSelect_Button
            // 
            this.UnSelect_Button.Cursor = System.Windows.Forms.Cursors.Default;
            this.UnSelect_Button.Font = new System.Drawing.Font( "ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)) );
            appearance13.BackColor = System.Drawing.Color.FromArgb( ((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))) );
            this.UnSelect_Button.HotTrackAppearance = appearance13;
            this.UnSelect_Button.Location = new System.Drawing.Point( 4, 4 );
            this.UnSelect_Button.Name = "UnSelect_Button";
            this.UnSelect_Button.Size = new System.Drawing.Size( 100, 27 );
            this.UnSelect_Button.TabIndex = 1;
            this.UnSelect_Button.Text = "全て解除";
            this.UnSelect_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.UnSelect_Button.Click += new System.EventHandler( this.Select_Button_Click );
            // 
            // timer_SelectRow
            // 
            this.timer_SelectRow.Interval = 1;
            this.timer_SelectRow.Tick += new System.EventHandler( this.timer_SelectRow_Tick );
            // 
            // timer_GridSetFocus
            // 
            this.timer_GridSetFocus.Interval = 1;
            this.timer_GridSetFocus.Tick += new System.EventHandler( this.timer_GridSetFocus_Tick );
            // 
            // uiSetControl1
            // 
            this.uiSetControl1.EditWidthSettingWay = Broadleaf.Library.Windows.Forms.UiSetControl.EditWidthSettingWayState.None;
            this.uiSetControl1.OwnerForm = this;
            // 
            // ultraLabel1
            // 
            this.ultraLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            appearance8.TextHAlignAsString = "Right";
            appearance8.TextVAlignAsString = "Middle";
            this.ultraLabel1.Appearance = appearance8;
            this.ultraLabel1.Location = new System.Drawing.Point( 743, 5 );
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size( 87, 23 );
            this.ultraLabel1.TabIndex = 1378;
            this.ultraLabel1.Text = "選択可能数";
            // 
            // lb_MaxSelectCount
            // 
            this.lb_MaxSelectCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            appearance9.BackColor = System.Drawing.Color.Gainsboro;
            appearance9.BorderColor = System.Drawing.Color.FromArgb( ((int)(((byte)(127)))), ((int)(((byte)(157)))), ((int)(((byte)(185)))) );
            appearance9.TextHAlignAsString = "Right";
            appearance9.TextVAlignAsString = "Middle";
            this.lb_MaxSelectCount.Appearance = appearance9;
            this.lb_MaxSelectCount.BackColorInternal = System.Drawing.Color.White;
            this.lb_MaxSelectCount.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Solid;
            this.lb_MaxSelectCount.Font = new System.Drawing.Font( "ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)) );
            this.lb_MaxSelectCount.Location = new System.Drawing.Point( 836, 5 );
            this.lb_MaxSelectCount.Name = "lb_MaxSelectCount";
            this.lb_MaxSelectCount.Size = new System.Drawing.Size( 59, 24 );
            this.lb_MaxSelectCount.TabIndex = 1377;
            this.lb_MaxSelectCount.WrapText = false;
            // 
            // ultraLabel16
            // 
            this.ultraLabel16.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            appearance10.TextHAlignAsString = "Right";
            appearance10.TextVAlignAsString = "Middle";
            this.ultraLabel16.Appearance = appearance10;
            this.ultraLabel16.Location = new System.Drawing.Point( 601, 5 );
            this.ultraLabel16.Name = "ultraLabel16";
            this.ultraLabel16.Size = new System.Drawing.Size( 71, 23 );
            this.ultraLabel16.TabIndex = 1376;
            this.ultraLabel16.Text = "選択件数";
            // 
            // lb_SelectedCount
            // 
            this.lb_SelectedCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            appearance11.BackColor = System.Drawing.Color.Gainsboro;
            appearance11.BorderColor = System.Drawing.Color.FromArgb( ((int)(((byte)(127)))), ((int)(((byte)(157)))), ((int)(((byte)(185)))) );
            appearance11.TextHAlignAsString = "Right";
            appearance11.TextVAlignAsString = "Middle";
            this.lb_SelectedCount.Appearance = appearance11;
            this.lb_SelectedCount.BackColorInternal = System.Drawing.Color.White;
            this.lb_SelectedCount.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Solid;
            this.lb_SelectedCount.Font = new System.Drawing.Font( "ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)) );
            this.lb_SelectedCount.Location = new System.Drawing.Point( 678, 5 );
            this.lb_SelectedCount.Name = "lb_SelectedCount";
            this.lb_SelectedCount.Size = new System.Drawing.Size( 59, 24 );
            this.lb_SelectedCount.TabIndex = 1375;
            this.lb_SelectedCount.WrapText = false;
            // 
            // DCKOU04101UB
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add( this.UserControl_InputDetails_Fill_Panel );
            this.Font = new System.Drawing.Font( "ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)) );
            this.Name = "DCKOU04101UB";
            this.Size = new System.Drawing.Size( 898, 507 );
            this.Load += new System.EventHandler( this.InputDetails_Load );
            this.UserControl_InputDetails_Fill_Panel.ResumeLayout( false );
            this.DataView_Panel.ResumeLayout( false );
            ((System.ComponentModel.ISupportInitialize)(this.uGrid_Details)).EndInit();
            this.PrintExtra_Panel.ResumeLayout( false );
            this.ResumeLayout( false );

		}

		#endregion

		private System.Windows.Forms.Panel UserControl_InputDetails_Fill_Panel;
        private System.Windows.Forms.ImageList imageList1;
        public Infragistics.Win.UltraWinGrid.UltraGrid uGrid_Details;
		public System.Windows.Forms.Timer timer_SelectRow;
        public System.Windows.Forms.Timer timer_GridSetFocus;
		private System.Windows.Forms.Panel PrintExtra_Panel;
		private Infragistics.Win.Misc.UltraButton Select_Button;
		private Infragistics.Win.Misc.UltraButton UnSelect_Button;
		private System.Windows.Forms.Panel DataView_Panel;
        private Broadleaf.Library.Windows.Forms.UiSetControl uiSetControl1;
        private Infragistics.Win.Misc.UltraLabel ultraLabel1;
        private Infragistics.Win.Misc.UltraLabel lb_MaxSelectCount;
        private Infragistics.Win.Misc.UltraLabel ultraLabel16;
        private Infragistics.Win.Misc.UltraLabel lb_SelectedCount;
	}
}

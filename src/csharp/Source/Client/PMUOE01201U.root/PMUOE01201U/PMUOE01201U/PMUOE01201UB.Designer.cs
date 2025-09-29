namespace Broadleaf.Windows.Forms
{
	partial class PMUOE01201UB
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PMUOE01201UB));
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.UserControl_InputDetails_Fill_Panel = new System.Windows.Forms.Panel();
            this.DataView_Panel = new System.Windows.Forms.Panel();
            this.uGrid_Header = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.Panel_Title = new System.Windows.Forms.Panel();
            this.UserControl_InputDetails_Fill_Panel.SuspendLayout();
            this.DataView_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uGrid_Header)).BeginInit();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Cyan;
            this.imageList1.Images.SetKeyName(0, "携帯電話.bmp");
            this.imageList1.Images.SetKeyName(1, "携帯電話検索.bmp");
            // 
            // UserControl_InputDetails_Fill_Panel
            // 
            this.UserControl_InputDetails_Fill_Panel.Controls.Add(this.DataView_Panel);
            this.UserControl_InputDetails_Fill_Panel.Controls.Add(this.Panel_Title);
            this.UserControl_InputDetails_Fill_Panel.Cursor = System.Windows.Forms.Cursors.Default;
            this.UserControl_InputDetails_Fill_Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UserControl_InputDetails_Fill_Panel.Location = new System.Drawing.Point(0, 0);
            this.UserControl_InputDetails_Fill_Panel.Name = "UserControl_InputDetails_Fill_Panel";
            this.UserControl_InputDetails_Fill_Panel.Size = new System.Drawing.Size(898, 507);
            this.UserControl_InputDetails_Fill_Panel.TabIndex = 0;
            // 
            // DataView_Panel
            // 
            this.DataView_Panel.Controls.Add(this.uGrid_Header);
            this.DataView_Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DataView_Panel.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.DataView_Panel.Location = new System.Drawing.Point(0, 20);
            this.DataView_Panel.Name = "DataView_Panel";
            this.DataView_Panel.Size = new System.Drawing.Size(898, 487);
            this.DataView_Panel.TabIndex = 7;
            // 
            // uGrid_Header
            // 
            appearance1.BackColor = System.Drawing.Color.White;
            appearance1.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            appearance1.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.uGrid_Header.DisplayLayout.Appearance = appearance1;
            this.uGrid_Header.DisplayLayout.GroupByBox.Hidden = true;
            this.uGrid_Header.DisplayLayout.InterBandSpacing = 10;
            this.uGrid_Header.DisplayLayout.MaxColScrollRegions = 1;
            this.uGrid_Header.DisplayLayout.MaxRowScrollRegions = 1;
            appearance2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance2.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance2.ForeColor = System.Drawing.Color.Black;
            this.uGrid_Header.DisplayLayout.Override.ActiveCellAppearance = appearance2;
            this.uGrid_Header.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No;
            this.uGrid_Header.DisplayLayout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.WithinBand;
            this.uGrid_Header.DisplayLayout.Override.AllowColSizing = Infragistics.Win.UltraWinGrid.AllowColSizing.Free;
            this.uGrid_Header.DisplayLayout.Override.AllowColSwapping = Infragistics.Win.UltraWinGrid.AllowColSwapping.NotAllowed;
            this.uGrid_Header.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
            this.uGrid_Header.DisplayLayout.Override.AllowGroupBy = Infragistics.Win.DefaultableBoolean.False;
            this.uGrid_Header.DisplayLayout.Override.AllowGroupMoving = Infragistics.Win.UltraWinGrid.AllowGroupMoving.NotAllowed;
            this.uGrid_Header.DisplayLayout.Override.AllowGroupSwapping = Infragistics.Win.UltraWinGrid.AllowGroupSwapping.NotAllowed;
            this.uGrid_Header.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
            this.uGrid_Header.DisplayLayout.Override.AllowRowLayoutCellSizing = Infragistics.Win.UltraWinGrid.RowLayoutSizing.None;
            this.uGrid_Header.DisplayLayout.Override.AllowRowLayoutCellSpanSizing = Infragistics.Win.Layout.GridBagLayoutAllowSpanSizing.None;
            this.uGrid_Header.DisplayLayout.Override.AllowRowLayoutColMoving = Infragistics.Win.Layout.GridBagLayoutAllowMoving.None;
            this.uGrid_Header.DisplayLayout.Override.AllowRowLayoutLabelSizing = Infragistics.Win.UltraWinGrid.RowLayoutSizing.None;
            this.uGrid_Header.DisplayLayout.Override.AllowRowLayoutLabelSpanSizing = Infragistics.Win.Layout.GridBagLayoutAllowSpanSizing.None;
            this.uGrid_Header.DisplayLayout.Override.AllowRowSummaries = Infragistics.Win.UltraWinGrid.AllowRowSummaries.False;
            this.uGrid_Header.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.True;
            this.uGrid_Header.DisplayLayout.Override.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
            appearance3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance3.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance3.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance3.ForeColor = System.Drawing.Color.White;
            appearance3.TextHAlignAsString = "Center";
            appearance3.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
            this.uGrid_Header.DisplayLayout.Override.HeaderAppearance = appearance3;
            appearance4.BackColor = System.Drawing.Color.Lavender;
            this.uGrid_Header.DisplayLayout.Override.RowAlternateAppearance = appearance4;
            appearance5.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(68)))), ((int)(((byte)(208)))));
            appearance5.TextVAlignAsString = "Middle";
            this.uGrid_Header.DisplayLayout.Override.RowAppearance = appearance5;
            this.uGrid_Header.DisplayLayout.Override.RowFilterAction = Infragistics.Win.UltraWinGrid.RowFilterAction.HideFilteredOutRows;
            this.uGrid_Header.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand;
            appearance6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance6.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance6.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance6.ForeColor = System.Drawing.Color.White;
            this.uGrid_Header.DisplayLayout.Override.RowSelectorAppearance = appearance6;
            this.uGrid_Header.DisplayLayout.Override.RowSelectorWidth = 12;
            this.uGrid_Header.DisplayLayout.Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.AutoFixed;
            this.uGrid_Header.DisplayLayout.Override.TipStyleCell = Infragistics.Win.UltraWinGrid.TipStyle.Hide;
            this.uGrid_Header.DisplayLayout.Override.TipStyleRowConnector = Infragistics.Win.UltraWinGrid.TipStyle.Hide;
            this.uGrid_Header.DisplayLayout.Override.TipStyleScroll = Infragistics.Win.UltraWinGrid.TipStyle.Hide;
            this.uGrid_Header.DisplayLayout.RowConnectorColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(167)))), ((int)(((byte)(191)))));
            this.uGrid_Header.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.uGrid_Header.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.uGrid_Header.DisplayLayout.UseFixedHeaders = true;
            this.uGrid_Header.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand;
            this.uGrid_Header.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uGrid_Header.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uGrid_Header.Location = new System.Drawing.Point(0, 0);
            this.uGrid_Header.Name = "uGrid_Header";
            this.uGrid_Header.Size = new System.Drawing.Size(898, 487);
            this.uGrid_Header.TabIndex = 5;
            this.uGrid_Header.BeforeCellUpdate += new Infragistics.Win.UltraWinGrid.BeforeCellUpdateEventHandler(this.uGrid_Header_BeforeCellUpdate);
            this.uGrid_Header.Click += new System.EventHandler(this.uGrid_Header_Click);
            this.uGrid_Header.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.uGrid_Header_InitializeLayout);
            this.uGrid_Header.AfterCellListCloseUp += new Infragistics.Win.UltraWinGrid.CellEventHandler(this.uGrid_Header_AfterCellListCloseUp);
            this.uGrid_Header.AfterCellUpdate += new Infragistics.Win.UltraWinGrid.CellEventHandler(this.uGrid_Header_AfterCellUpdate);
            this.uGrid_Header.AfterRowActivate += new System.EventHandler(this.uGrid_Header_AfterRowActivate);
            this.uGrid_Header.Leave += new System.EventHandler(this.uGrid_Header_Leave);
            this.uGrid_Header.KeyDown += new System.Windows.Forms.KeyEventHandler(this.uGrid_Header_KeyDown);
            this.uGrid_Header.AfterCellActivate += new System.EventHandler(this.uGrid_Header_AfterCellActivate);
            // 
            // Panel_Title
            // 
            this.Panel_Title.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel_Title.Location = new System.Drawing.Point(0, 0);
            this.Panel_Title.Name = "Panel_Title";
            this.Panel_Title.Size = new System.Drawing.Size(898, 20);
            this.Panel_Title.TabIndex = 6;
            this.Panel_Title.Visible = false;
            // 
            // PMUOE01201UB
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.UserControl_InputDetails_Fill_Panel);
            this.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Name = "PMUOE01201UB";
            this.Size = new System.Drawing.Size(898, 507);
            this.Load += new System.EventHandler(this.PMUOE01201UB_Load);
            this.UserControl_InputDetails_Fill_Panel.ResumeLayout(false);
            this.DataView_Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uGrid_Header)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel UserControl_InputDetails_Fill_Panel;
        private System.Windows.Forms.ImageList imageList1;
        public Infragistics.Win.UltraWinGrid.UltraGrid uGrid_Header;
        private System.Windows.Forms.Panel Panel_Title;
        private System.Windows.Forms.Panel DataView_Panel;
	}
}

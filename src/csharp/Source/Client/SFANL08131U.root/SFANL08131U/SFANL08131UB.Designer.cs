namespace Broadleaf.Windows.Forms
{
	partial class SFANL08131UB
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
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( SFANL08131UB ) );
            this.ubCancel = new Infragistics.Win.Misc.UltraButton();
            this.ubDecide = new Infragistics.Win.Misc.UltraButton();
            this.gridItemSelect = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.ubArrowUp = new Infragistics.Win.Misc.UltraButton();
            this.ubArrowDn = new Infragistics.Win.Misc.UltraButton();
            this.tRetKeyControl1 = new Broadleaf.Library.Windows.Forms.TRetKeyControl( this.components );
            this.tArrowKeyControl1 = new Broadleaf.Library.Windows.Forms.TArrowKeyControl( this.components );
            ((System.ComponentModel.ISupportInitialize)(this.gridItemSelect)).BeginInit();
            this.SuspendLayout();
            // 
            // ubCancel
            // 
            this.ubCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ubCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ubCancel.Location = new System.Drawing.Point( 334, 343 );
            this.ubCancel.Margin = new System.Windows.Forms.Padding( 4 );
            this.ubCancel.Name = "ubCancel";
            this.ubCancel.Size = new System.Drawing.Size( 133, 28 );
            this.ubCancel.TabIndex = 4;
            this.ubCancel.Text = "キャンセル(&C)";
            this.ubCancel.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.ubCancel.Click += new System.EventHandler( this.ubCancel_Click );
            // 
            // ubDecide
            // 
            this.ubDecide.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ubDecide.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.ubDecide.Location = new System.Drawing.Point( 193, 343 );
            this.ubDecide.Margin = new System.Windows.Forms.Padding( 4 );
            this.ubDecide.Name = "ubDecide";
            this.ubDecide.Size = new System.Drawing.Size( 133, 28 );
            this.ubDecide.TabIndex = 3;
            this.ubDecide.Text = "確定(&S)";
            this.ubDecide.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.ubDecide.Click += new System.EventHandler( this.ubDecide_Click );
            // 
            // gridItemSelect
            // 
            this.gridItemSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            appearance1.BackColor = System.Drawing.Color.White;
            appearance1.BackColor2 = System.Drawing.Color.FromArgb( ((int)(((byte)(198)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))) );
            appearance1.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.gridItemSelect.DisplayLayout.Appearance = appearance1;
            this.gridItemSelect.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;
            this.gridItemSelect.DisplayLayout.GroupByBox.Hidden = true;
            this.gridItemSelect.DisplayLayout.InterBandSpacing = 10;
            appearance2.BackColor = System.Drawing.Color.White;
            appearance2.BackColor2 = System.Drawing.Color.FromArgb( ((int)(((byte)(251)))), ((int)(((byte)(230)))), ((int)(((byte)(148)))) );
            appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.gridItemSelect.DisplayLayout.Override.ActiveCellAppearance = appearance2;
            appearance3.BackColor = System.Drawing.Color.FromArgb( ((int)(((byte)(251)))), ((int)(((byte)(230)))), ((int)(((byte)(148)))) );
            appearance3.BackColor2 = System.Drawing.Color.FromArgb( ((int)(((byte)(238)))), ((int)(((byte)(149)))), ((int)(((byte)(21)))) );
            appearance3.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance3.ForeColor = System.Drawing.Color.Black;
            this.gridItemSelect.DisplayLayout.Override.ActiveRowAppearance = appearance3;
            this.gridItemSelect.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No;
            this.gridItemSelect.DisplayLayout.Override.AllowColSizing = Infragistics.Win.UltraWinGrid.AllowColSizing.Synchronized;
            this.gridItemSelect.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
            this.gridItemSelect.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
            this.gridItemSelect.DisplayLayout.Override.AllowRowSummaries = Infragistics.Win.UltraWinGrid.AllowRowSummaries.False;
            appearance4.BackColor = System.Drawing.Color.Transparent;
            this.gridItemSelect.DisplayLayout.Override.CardAreaAppearance = appearance4;
            appearance5.BackColor = System.Drawing.Color.FromArgb( ((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))) );
            this.gridItemSelect.DisplayLayout.Override.EditCellAppearance = appearance5;
            appearance6.BackColor = System.Drawing.Color.FromArgb( ((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))) );
            appearance6.BackColor2 = System.Drawing.Color.FromArgb( ((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))) );
            appearance6.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance6.ForeColor = System.Drawing.Color.White;
            appearance6.TextHAlignAsString = "Left";
            appearance6.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
            this.gridItemSelect.DisplayLayout.Override.HeaderAppearance = appearance6;
            this.gridItemSelect.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.Select;
            appearance7.BackColor = System.Drawing.Color.Lavender;
            this.gridItemSelect.DisplayLayout.Override.RowAlternateAppearance = appearance7;
            appearance8.BorderColor = System.Drawing.Color.FromArgb( ((int)(((byte)(1)))), ((int)(((byte)(68)))), ((int)(((byte)(208)))) );
            this.gridItemSelect.DisplayLayout.Override.RowAppearance = appearance8;
            this.gridItemSelect.DisplayLayout.Override.RowFilterAction = Infragistics.Win.UltraWinGrid.RowFilterAction.HideFilteredOutRows;
            this.gridItemSelect.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand;
            appearance9.BackColor = System.Drawing.Color.FromArgb( ((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))) );
            appearance9.BackColor2 = System.Drawing.Color.FromArgb( ((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))) );
            appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance9.ForeColor = System.Drawing.Color.White;
            this.gridItemSelect.DisplayLayout.Override.RowSelectorAppearance = appearance9;
            this.gridItemSelect.DisplayLayout.Override.RowSelectorNumberStyle = Infragistics.Win.UltraWinGrid.RowSelectorNumberStyle.RowIndex;
            this.gridItemSelect.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True;
            this.gridItemSelect.DisplayLayout.Override.RowSelectorWidth = 24;
            this.gridItemSelect.DisplayLayout.Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.AutoFixed;
            appearance10.BackColor = System.Drawing.Color.FromArgb( ((int)(((byte)(251)))), ((int)(((byte)(230)))), ((int)(((byte)(148)))) );
            appearance10.BackColor2 = System.Drawing.Color.FromArgb( ((int)(((byte)(238)))), ((int)(((byte)(149)))), ((int)(((byte)(21)))) );
            appearance10.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance10.ForeColor = System.Drawing.Color.Black;
            this.gridItemSelect.DisplayLayout.Override.SelectedRowAppearance = appearance10;
            this.gridItemSelect.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.gridItemSelect.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.gridItemSelect.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.SingleAutoDrag;
            this.gridItemSelect.DisplayLayout.RowConnectorColor = System.Drawing.Color.FromArgb( ((int)(((byte)(168)))), ((int)(((byte)(167)))), ((int)(((byte)(191)))) );
            this.gridItemSelect.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.Solid;
            this.gridItemSelect.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.gridItemSelect.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.gridItemSelect.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand;
            this.gridItemSelect.Location = new System.Drawing.Point( 13, 13 );
            this.gridItemSelect.Margin = new System.Windows.Forms.Padding( 4 );
            this.gridItemSelect.Name = "gridItemSelect";
            this.gridItemSelect.Size = new System.Drawing.Size( 413, 311 );
            this.gridItemSelect.TabIndex = 0;
            this.gridItemSelect.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler( this.gridItemSelect_InitializeLayout );
            this.gridItemSelect.Enter += new System.EventHandler( this.gridItemSelect_Enter );
            this.gridItemSelect.AfterRowActivate += new System.EventHandler( this.gridItemSelect_AfterRowActivate );
            this.gridItemSelect.KeyDown += new System.Windows.Forms.KeyEventHandler( this.gridItemSelect_KeyDown );
            this.gridItemSelect.AfterSortChange += new Infragistics.Win.UltraWinGrid.BandEventHandler( this.gridItemSelect_AfterSortChange );
            // 
            // ubArrowUp
            // 
            this.ubArrowUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ubArrowUp.ImageSize = new System.Drawing.Size( 24, 24 );
            this.ubArrowUp.Location = new System.Drawing.Point( 435, 119 );
            this.ubArrowUp.Margin = new System.Windows.Forms.Padding( 4 );
            this.ubArrowUp.Name = "ubArrowUp";
            this.ubArrowUp.Size = new System.Drawing.Size( 32, 32 );
            this.ubArrowUp.TabIndex = 1;
            this.ubArrowUp.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.ubArrowUp.Click += new System.EventHandler( this.ubArrowUp_Click );
            // 
            // ubArrowDn
            // 
            this.ubArrowDn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ubArrowDn.ImageSize = new System.Drawing.Size( 24, 24 );
            this.ubArrowDn.Location = new System.Drawing.Point( 435, 155 );
            this.ubArrowDn.Margin = new System.Windows.Forms.Padding( 4 );
            this.ubArrowDn.Name = "ubArrowDn";
            this.ubArrowDn.Size = new System.Drawing.Size( 32, 32 );
            this.ubArrowDn.TabIndex = 2;
            this.ubArrowDn.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.ubArrowDn.Click += new System.EventHandler( this.ubArrowDn_Click );
            // 
            // tRetKeyControl1
            // 
            this.tRetKeyControl1.OwnerForm = this;
            this.tRetKeyControl1.Style = Broadleaf.Library.Windows.Forms.emFocusStyle.ByTab;
            // 
            // tArrowKeyControl1
            // 
            this.tArrowKeyControl1.OwnerForm = this;
            // 
            // SFANL08131UB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 8F, 15F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb( ((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))) );
            this.CancelButton = this.ubCancel;
            this.ClientSize = new System.Drawing.Size( 480, 384 );
            this.Controls.Add( this.ubArrowDn );
            this.Controls.Add( this.ubArrowUp );
            this.Controls.Add( this.gridItemSelect );
            this.Controls.Add( this.ubCancel );
            this.Controls.Add( this.ubDecide );
            this.Font = new System.Drawing.Font( "ＭＳ ゴシック", 11F );
            this.Icon = ((System.Drawing.Icon)(resources.GetObject( "$this.Icon" )));
            this.Margin = new System.Windows.Forms.Padding( 4 );
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SFANL08131UB";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "自由帳票ソート順位設定";
            ((System.ComponentModel.ISupportInitialize)(this.gridItemSelect)).EndInit();
            this.ResumeLayout( false );

		}

		#endregion

		private Infragistics.Win.Misc.UltraButton ubCancel;
		private Infragistics.Win.Misc.UltraButton ubDecide;
		private Infragistics.Win.UltraWinGrid.UltraGrid gridItemSelect;
		private Infragistics.Win.Misc.UltraButton ubArrowUp;
		private Infragistics.Win.Misc.UltraButton ubArrowDn;
		private Broadleaf.Library.Windows.Forms.TRetKeyControl tRetKeyControl1;
		private Broadleaf.Library.Windows.Forms.TArrowKeyControl tArrowKeyControl1;
	}
}
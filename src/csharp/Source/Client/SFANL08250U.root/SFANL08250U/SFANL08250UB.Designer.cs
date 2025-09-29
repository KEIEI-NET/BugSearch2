namespace Broadleaf.Windows.Forms
{
	partial class SFANL08250UB
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
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( SFANL08250UB ) );
            this.gridPrtItemSet = new Infragistics.Win.UltraWinGrid.UltraGrid();
            ((System.ComponentModel.ISupportInitialize)(this.gridPrtItemSet)).BeginInit();
            this.SuspendLayout();
            // 
            // gridPrtItemSet
            // 
            appearance1.BackColor = System.Drawing.Color.White;
            appearance1.BackColor2 = System.Drawing.Color.FromArgb( ((int)(((byte)(198)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))) );
            appearance1.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.gridPrtItemSet.DisplayLayout.Appearance = appearance1;
            this.gridPrtItemSet.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;
            this.gridPrtItemSet.DisplayLayout.MaxColScrollRegions = 1;
            this.gridPrtItemSet.DisplayLayout.MaxRowScrollRegions = 1;
            appearance2.BackColor = System.Drawing.Color.FromArgb( ((int)(((byte)(251)))), ((int)(((byte)(230)))), ((int)(((byte)(148)))) );
            appearance2.BackColor2 = System.Drawing.Color.FromArgb( ((int)(((byte)(238)))), ((int)(((byte)(149)))), ((int)(((byte)(21)))) );
            appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance2.ForeColor = System.Drawing.Color.Black;
            this.gridPrtItemSet.DisplayLayout.Override.ActiveRowAppearance = appearance2;
            this.gridPrtItemSet.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
            appearance3.BackColor = System.Drawing.Color.Transparent;
            this.gridPrtItemSet.DisplayLayout.Override.CardAreaAppearance = appearance3;
            this.gridPrtItemSet.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            this.gridPrtItemSet.DisplayLayout.Override.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
            appearance4.BackColor = System.Drawing.Color.FromArgb( ((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))) );
            appearance4.BackColor2 = System.Drawing.Color.FromArgb( ((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))) );
            appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance4.FontData.BoldAsString = "True";
            appearance4.FontData.Name = "Arial";
            appearance4.FontData.SizeInPoints = 10F;
            appearance4.ForeColor = System.Drawing.Color.White;
            appearance4.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
            this.gridPrtItemSet.DisplayLayout.Override.HeaderAppearance = appearance4;
            this.gridPrtItemSet.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.Select;
            appearance5.BackColor = System.Drawing.Color.Lavender;
            this.gridPrtItemSet.DisplayLayout.Override.RowAlternateAppearance = appearance5;
            appearance6.BackColor = System.Drawing.Color.FromArgb( ((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))) );
            appearance6.BackColor2 = System.Drawing.Color.FromArgb( ((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))) );
            appearance6.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.gridPrtItemSet.DisplayLayout.Override.RowSelectorAppearance = appearance6;
            appearance7.BackColor = System.Drawing.Color.FromArgb( ((int)(((byte)(251)))), ((int)(((byte)(230)))), ((int)(((byte)(148)))) );
            appearance7.BackColor2 = System.Drawing.Color.FromArgb( ((int)(((byte)(238)))), ((int)(((byte)(149)))), ((int)(((byte)(21)))) );
            appearance7.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance7.ForeColor = System.Drawing.Color.Black;
            this.gridPrtItemSet.DisplayLayout.Override.SelectedRowAppearance = appearance7;
            this.gridPrtItemSet.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.gridPrtItemSet.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.gridPrtItemSet.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Single;
            this.gridPrtItemSet.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.gridPrtItemSet.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.gridPrtItemSet.DisplayLayout.UseFixedHeaders = true;
            this.gridPrtItemSet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridPrtItemSet.Location = new System.Drawing.Point( 0, 0 );
            this.gridPrtItemSet.Name = "gridPrtItemSet";
            this.gridPrtItemSet.Size = new System.Drawing.Size( 389, 334 );
            this.gridPrtItemSet.TabIndex = 8;
            this.gridPrtItemSet.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler( this.gridPrtItemSet_MouseDoubleClick );
            this.gridPrtItemSet.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler( this.gridPrtItemSet_InitializeLayout );
            this.gridPrtItemSet.KeyDown += new System.Windows.Forms.KeyEventHandler( this.gridPrtItemSet_KeyDown );
            // 
            // SFANL08250UB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 8F, 15F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size( 389, 334 );
            this.Controls.Add( this.gridPrtItemSet );
            this.Font = new System.Drawing.Font( "ＭＳ ゴシック", 11F );
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject( "$this.Icon" )));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding( 4 );
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SFANL08250UB";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "追加する行を選択してください";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler( this.SFANL08242UB_KeyDown );
            ((System.ComponentModel.ISupportInitialize)(this.gridPrtItemSet)).EndInit();
            this.ResumeLayout( false );

		}

		#endregion

		private Infragistics.Win.UltraWinGrid.UltraGrid gridPrtItemSet;
	}
}
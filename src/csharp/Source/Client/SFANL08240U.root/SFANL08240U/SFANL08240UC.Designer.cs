namespace Broadleaf.Windows.Forms
{
    partial class SFANL08240UC
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
            if ( disposing && (components != null) )
            {
                components.Dispose();
            }
            base.Dispose( disposing );
        }

        #region Windows フォーム デザイナで生成されたコード

        /// <summary>
        /// デザイナ サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディタで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance30 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance31 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance32 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance33 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance34 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance35 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance36 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( SFANL08240UC ) );
            this.button_Close = new Infragistics.Win.Misc.UltraButton();
            this.tArrowKeyControl1 = new Broadleaf.Library.Windows.Forms.TArrowKeyControl( this.components );
            this.tRetKeyControl1 = new Broadleaf.Library.Windows.Forms.TRetKeyControl( this.components );
            this.panel1 = new System.Windows.Forms.Panel();
            this.gridFPSortInit = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridFPSortInit)).BeginInit();
            this.SuspendLayout();
            // 
            // button_Close
            // 
            this.button_Close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Close.Location = new System.Drawing.Point( 774, 6 );
            this.button_Close.Name = "button_Close";
            this.button_Close.Size = new System.Drawing.Size( 113, 26 );
            this.button_Close.TabIndex = 22;
            this.button_Close.Text = "閉じる";
            this.button_Close.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.button_Close.Click += new System.EventHandler( this.ultraButton1_Click );
            // 
            // tArrowKeyControl1
            // 
            this.tArrowKeyControl1.OwnerForm = this;
            this.tArrowKeyControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler( this.tArrowKeyControl1_ChangeFocus );
            // 
            // tRetKeyControl1
            // 
            this.tRetKeyControl1.OwnerForm = this;
            this.tRetKeyControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler( this.tArrowKeyControl1_ChangeFocus );
            // 
            // panel1
            // 
            this.panel1.Controls.Add( this.button_Close );
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point( 0, 603 );
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size( 897, 39 );
            this.panel1.TabIndex = 29;
            // 
            // gridFPSortInit
            // 
            appearance30.BackColor = System.Drawing.Color.White;
            appearance30.BackColor2 = System.Drawing.Color.FromArgb( ((int)(((byte)(198)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))) );
            appearance30.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.gridFPSortInit.DisplayLayout.Appearance = appearance30;
            this.gridFPSortInit.DisplayLayout.MaxColScrollRegions = 1;
            this.gridFPSortInit.DisplayLayout.MaxRowScrollRegions = 1;
            appearance31.BackColor = System.Drawing.Color.FromArgb( ((int)(((byte)(251)))), ((int)(((byte)(230)))), ((int)(((byte)(148)))) );
            appearance31.BackColor2 = System.Drawing.Color.FromArgb( ((int)(((byte)(238)))), ((int)(((byte)(149)))), ((int)(((byte)(21)))) );
            appearance31.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance31.ForeColor = System.Drawing.Color.Black;
            this.gridFPSortInit.DisplayLayout.Override.ActiveRowAppearance = appearance31;
            appearance32.BackColor = System.Drawing.Color.Transparent;
            this.gridFPSortInit.DisplayLayout.Override.CardAreaAppearance = appearance32;
            this.gridFPSortInit.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.gridFPSortInit.DisplayLayout.Override.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
            appearance33.BackColor = System.Drawing.Color.FromArgb( ((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))) );
            appearance33.BackColor2 = System.Drawing.Color.FromArgb( ((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))) );
            appearance33.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance33.FontData.BoldAsString = "True";
            appearance33.FontData.Name = "Arial";
            appearance33.FontData.SizeInPoints = 10F;
            appearance33.ForeColor = System.Drawing.Color.White;
            appearance33.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
            this.gridFPSortInit.DisplayLayout.Override.HeaderAppearance = appearance33;
            this.gridFPSortInit.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortSingle;
            appearance34.BackColor = System.Drawing.Color.Lavender;
            this.gridFPSortInit.DisplayLayout.Override.RowAlternateAppearance = appearance34;
            appearance35.BackColor = System.Drawing.Color.FromArgb( ((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))) );
            appearance35.BackColor2 = System.Drawing.Color.FromArgb( ((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))) );
            appearance35.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.gridFPSortInit.DisplayLayout.Override.RowSelectorAppearance = appearance35;
            appearance36.BackColor = System.Drawing.Color.FromArgb( ((int)(((byte)(251)))), ((int)(((byte)(230)))), ((int)(((byte)(148)))) );
            appearance36.BackColor2 = System.Drawing.Color.FromArgb( ((int)(((byte)(238)))), ((int)(((byte)(149)))), ((int)(((byte)(21)))) );
            appearance36.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance36.ForeColor = System.Drawing.Color.Black;
            this.gridFPSortInit.DisplayLayout.Override.SelectedRowAppearance = appearance36;
            this.gridFPSortInit.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.gridFPSortInit.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.gridFPSortInit.DisplayLayout.UseFixedHeaders = true;
            this.gridFPSortInit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridFPSortInit.Location = new System.Drawing.Point( 0, 0 );
            this.gridFPSortInit.Name = "gridFPSortInit";
            this.gridFPSortInit.Size = new System.Drawing.Size( 897, 603 );
            this.gridFPSortInit.TabIndex = 30;
            // 
            // SFANL08240UC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 8F, 15F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb( ((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))) );
            this.ClientSize = new System.Drawing.Size( 897, 642 );
            this.Controls.Add( this.gridFPSortInit );
            this.Controls.Add( this.panel1 );
            this.Font = new System.Drawing.Font( "MS UI Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)) );
            this.Icon = ((System.Drawing.Icon)(resources.GetObject( "$this.Icon" )));
            this.Margin = new System.Windows.Forms.Padding( 4 );
            this.MaximizeBox = false;
            this.Name = "SFANL08240UC";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ソート順位初期設定";
            this.TopMost = true;
            this.panel1.ResumeLayout( false );
            ((System.ComponentModel.ISupportInitialize)(this.gridFPSortInit)).EndInit();
            this.ResumeLayout( false );

        }

        #endregion

        private Infragistics.Win.Misc.UltraButton button_Close;
        private Broadleaf.Library.Windows.Forms.TArrowKeyControl tArrowKeyControl1;
        private Broadleaf.Library.Windows.Forms.TRetKeyControl tRetKeyControl1;
        private System.Windows.Forms.Panel panel1;
        private Infragistics.Win.UltraWinGrid.UltraGrid gridFPSortInit;
    }
}
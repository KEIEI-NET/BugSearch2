namespace Broadleaf.Library.Windows.Forms
{
    partial class FrmJoinPartsInfo
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
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            this.GridPrimeParts = new Infragistics.Win.UltraWinGrid.UltraGrid();
            ((System.ComponentModel.ISupportInitialize)(this.GridPrimeParts)).BeginInit();
            this.SuspendLayout();
            // 
            // GridPrimeParts
            // 
            appearance8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            appearance8.BackColor2 = System.Drawing.Color.White;
            appearance8.BackGradientStyle = Infragistics.Win.GradientStyle.Elliptical;
            this.GridPrimeParts.DisplayLayout.Appearance = appearance8;
            appearance9.TextHAlignAsString = "Left";
            this.GridPrimeParts.DisplayLayout.CaptionAppearance = appearance9;
            this.GridPrimeParts.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.True;
            this.GridPrimeParts.DisplayLayout.GroupByBox.Hidden = true;
            this.GridPrimeParts.DisplayLayout.InterBandSpacing = 10;
            this.GridPrimeParts.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No;
            this.GridPrimeParts.DisplayLayout.Override.AllowColSizing = Infragistics.Win.UltraWinGrid.AllowColSizing.Synchronized;
            this.GridPrimeParts.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
            this.GridPrimeParts.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
            this.GridPrimeParts.DisplayLayout.Override.AllowRowSummaries = Infragistics.Win.UltraWinGrid.AllowRowSummaries.False;
            this.GridPrimeParts.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.False;
            appearance10.BackColor = System.Drawing.Color.Transparent;
            this.GridPrimeParts.DisplayLayout.Override.CardAreaAppearance = appearance10;
            this.GridPrimeParts.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            this.GridPrimeParts.DisplayLayout.Override.ColumnAutoSizeMode = Infragistics.Win.UltraWinGrid.ColumnAutoSizeMode.AllRowsInBand;
            appearance11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance11.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance11.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance11.ForeColor = System.Drawing.Color.White;
            appearance11.TextHAlignAsString = "Left";
            appearance11.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
            this.GridPrimeParts.DisplayLayout.Override.HeaderAppearance = appearance11;
            this.GridPrimeParts.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortSingle;
            appearance12.BackColor = System.Drawing.Color.Lavender;
            this.GridPrimeParts.DisplayLayout.Override.RowAlternateAppearance = appearance12;
            appearance13.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(68)))), ((int)(((byte)(208)))));
            this.GridPrimeParts.DisplayLayout.Override.RowAppearance = appearance13;
            this.GridPrimeParts.DisplayLayout.Override.RowFilterAction = Infragistics.Win.UltraWinGrid.RowFilterAction.HideFilteredOutRows;
            this.GridPrimeParts.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand;
            appearance14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance14.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance14.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance14.ForeColor = System.Drawing.Color.White;
            this.GridPrimeParts.DisplayLayout.Override.RowSelectorAppearance = appearance14;
            this.GridPrimeParts.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True;
            this.GridPrimeParts.DisplayLayout.Override.RowSelectorWidth = 12;
            this.GridPrimeParts.DisplayLayout.Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.Fixed;
            appearance15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(230)))), ((int)(((byte)(148)))));
            appearance15.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(149)))), ((int)(((byte)(21)))));
            appearance15.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance15.ForeColor = System.Drawing.Color.Black;
            this.GridPrimeParts.DisplayLayout.Override.SelectedRowAppearance = appearance15;
            this.GridPrimeParts.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.GridPrimeParts.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.SingleAutoDrag;
            this.GridPrimeParts.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.SingleAutoDrag;
            this.GridPrimeParts.DisplayLayout.RowConnectorColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(167)))), ((int)(((byte)(191)))));
            this.GridPrimeParts.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.Solid;
            this.GridPrimeParts.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.GridPrimeParts.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.GridPrimeParts.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand;
            this.GridPrimeParts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GridPrimeParts.Location = new System.Drawing.Point(0, 0);
            this.GridPrimeParts.Name = "GridPrimeParts";
            this.GridPrimeParts.Size = new System.Drawing.Size(369, 404);
            this.GridPrimeParts.TabIndex = 2;
            this.GridPrimeParts.TabStop = false;
            this.GridPrimeParts.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.GridPrimeParts_InitializeLayout);
            // 
            // FrmJoinPartsInfo
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(369, 404);
            this.ControlBox = false;
            this.Controls.Add(this.GridPrimeParts);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FrmJoinPartsInfo";
            this.Opacity = 0.9;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            ((System.ComponentModel.ISupportInitialize)(this.GridPrimeParts)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.UltraWinGrid.UltraGrid GridPrimeParts;
    }
}
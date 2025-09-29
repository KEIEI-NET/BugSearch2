namespace Broadleaf.Windows.Forms
{
    partial class PMKYO01101UC
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
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            this.uGrid_Condition = new Infragistics.Win.UltraWinGrid.UltraGrid();
            ((System.ComponentModel.ISupportInitialize)(this.uGrid_Condition)).BeginInit();
            this.SuspendLayout();
            // 
            // uGrid_Condition
            // 
            appearance3.BackColor = System.Drawing.Color.White;
            appearance3.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            appearance3.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.uGrid_Condition.DisplayLayout.Appearance = appearance3;
            this.uGrid_Condition.DisplayLayout.GroupByBox.Hidden = true;
            this.uGrid_Condition.DisplayLayout.InterBandSpacing = 10;
            this.uGrid_Condition.DisplayLayout.MaxColScrollRegions = 1;
            this.uGrid_Condition.DisplayLayout.MaxRowScrollRegions = 1;
            appearance4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(230)))), ((int)(((byte)(148)))));
            appearance4.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(230)))), ((int)(((byte)(148)))));
            appearance4.ForeColor = System.Drawing.Color.Black;
            this.uGrid_Condition.DisplayLayout.Override.ActiveCellAppearance = appearance4;
            this.uGrid_Condition.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No;
            this.uGrid_Condition.DisplayLayout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.WithinBand;
            this.uGrid_Condition.DisplayLayout.Override.AllowColSizing = Infragistics.Win.UltraWinGrid.AllowColSizing.Free;
            this.uGrid_Condition.DisplayLayout.Override.AllowColSwapping = Infragistics.Win.UltraWinGrid.AllowColSwapping.NotAllowed;
            this.uGrid_Condition.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
            this.uGrid_Condition.DisplayLayout.Override.AllowGroupBy = Infragistics.Win.DefaultableBoolean.False;
            this.uGrid_Condition.DisplayLayout.Override.AllowGroupMoving = Infragistics.Win.UltraWinGrid.AllowGroupMoving.NotAllowed;
            this.uGrid_Condition.DisplayLayout.Override.AllowGroupSwapping = Infragistics.Win.UltraWinGrid.AllowGroupSwapping.NotAllowed;
            this.uGrid_Condition.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
            this.uGrid_Condition.DisplayLayout.Override.AllowRowLayoutCellSizing = Infragistics.Win.UltraWinGrid.RowLayoutSizing.None;
            this.uGrid_Condition.DisplayLayout.Override.AllowRowLayoutCellSpanSizing = Infragistics.Win.Layout.GridBagLayoutAllowSpanSizing.None;
            this.uGrid_Condition.DisplayLayout.Override.AllowRowLayoutColMoving = Infragistics.Win.Layout.GridBagLayoutAllowMoving.None;
            this.uGrid_Condition.DisplayLayout.Override.AllowRowLayoutLabelSizing = Infragistics.Win.UltraWinGrid.RowLayoutSizing.None;
            this.uGrid_Condition.DisplayLayout.Override.AllowRowLayoutLabelSpanSizing = Infragistics.Win.Layout.GridBagLayoutAllowSpanSizing.None;
            this.uGrid_Condition.DisplayLayout.Override.AllowRowSummaries = Infragistics.Win.UltraWinGrid.AllowRowSummaries.False;
            this.uGrid_Condition.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.True;
            this.uGrid_Condition.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.Edit;
            this.uGrid_Condition.DisplayLayout.Override.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
            appearance5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance5.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance5.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance5.ForeColor = System.Drawing.Color.White;
            appearance5.ForeColorDisabled = System.Drawing.Color.White;
            appearance5.TextHAlignAsString = "Center";
            appearance5.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
            this.uGrid_Condition.DisplayLayout.Override.HeaderAppearance = appearance5;
            appearance6.BackColor = System.Drawing.Color.Lavender;
            this.uGrid_Condition.DisplayLayout.Override.RowAlternateAppearance = appearance6;
            appearance7.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(157)))), ((int)(((byte)(185)))));
            appearance7.TextVAlignAsString = "Middle";
            this.uGrid_Condition.DisplayLayout.Override.RowAppearance = appearance7;
            this.uGrid_Condition.DisplayLayout.Override.RowFilterAction = Infragistics.Win.UltraWinGrid.RowFilterAction.HideFilteredOutRows;
            this.uGrid_Condition.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand;
            appearance8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance8.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance8.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance8.ForeColor = System.Drawing.Color.White;
            this.uGrid_Condition.DisplayLayout.Override.RowSelectorAppearance = appearance8;
            this.uGrid_Condition.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True;
            this.uGrid_Condition.DisplayLayout.Override.RowSelectorWidth = 20;
            this.uGrid_Condition.DisplayLayout.Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.AutoFixed;
            appearance9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(230)))), ((int)(((byte)(148)))));
            appearance9.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(149)))), ((int)(((byte)(21)))));
            appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance9.ForeColor = System.Drawing.Color.Black;
            this.uGrid_Condition.DisplayLayout.Override.SelectedRowAppearance = appearance9;
            this.uGrid_Condition.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.Single;
            this.uGrid_Condition.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.SingleAutoDrag;
            this.uGrid_Condition.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.ExtendedAutoDrag;
            this.uGrid_Condition.DisplayLayout.Override.TipStyleCell = Infragistics.Win.UltraWinGrid.TipStyle.Hide;
            this.uGrid_Condition.DisplayLayout.Override.TipStyleRowConnector = Infragistics.Win.UltraWinGrid.TipStyle.Hide;
            this.uGrid_Condition.DisplayLayout.Override.TipStyleScroll = Infragistics.Win.UltraWinGrid.TipStyle.Hide;
            this.uGrid_Condition.DisplayLayout.RowConnectorColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(167)))), ((int)(((byte)(191)))));
            this.uGrid_Condition.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.uGrid_Condition.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.uGrid_Condition.DisplayLayout.UseFixedHeaders = true;
            this.uGrid_Condition.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand;
            this.uGrid_Condition.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uGrid_Condition.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uGrid_Condition.Location = new System.Drawing.Point(0, 0);
            this.uGrid_Condition.Name = "uGrid_Condition";
            this.uGrid_Condition.Size = new System.Drawing.Size(693, 435);
            this.uGrid_Condition.TabIndex = 7;
            this.uGrid_Condition.BeforeEnterEditMode += new System.ComponentModel.CancelEventHandler(this.uGrid_Condition_BeforeEnterEditMode);
            this.uGrid_Condition.AfterExitEditMode += new System.EventHandler(this.uGrid_Condition_AfterExitEditMode);
            this.uGrid_Condition.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.ultraGridCondition_InitializeLayout);
            this.uGrid_Condition.CellDataError += new Infragistics.Win.UltraWinGrid.CellDataErrorEventHandler(this.uGrid_Condition_CellDataError);
            this.uGrid_Condition.AfterCellUpdate += new Infragistics.Win.UltraWinGrid.CellEventHandler(this.uGrid_Conditon_AfterCellUpdate);
            this.uGrid_Condition.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.uGrid_Condition_KeyPress);
            this.uGrid_Condition.KeyDown += new System.Windows.Forms.KeyEventHandler(this.uGrid_Conditon_KeyDown);
            // 
            // PMKYO01101UC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.uGrid_Condition);
            this.Name = "PMKYO01101UC";
            this.Size = new System.Drawing.Size(693, 435);
            this.Load += new System.EventHandler(this.PMKYO01101UC_Load);
            ((System.ComponentModel.ISupportInitialize)(this.uGrid_Condition)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal Infragistics.Win.UltraWinGrid.UltraGrid uGrid_Condition;
    }
}

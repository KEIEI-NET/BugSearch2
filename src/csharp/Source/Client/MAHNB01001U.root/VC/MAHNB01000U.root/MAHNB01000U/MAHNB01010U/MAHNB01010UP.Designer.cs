namespace Broadleaf.Windows.Forms
{
    partial class MAHNB01010UP
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
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MAHNB01010UP));
            this.Btn_OK = new Infragistics.Win.Misc.UltraButton();
            this.ultraLabel_Message = new Infragistics.Win.Misc.UltraLabel();
            this.panel_Footer = new System.Windows.Forms.Panel();
            this.Btn_No = new Infragistics.Win.Misc.UltraButton();
            this.panel_Header = new System.Windows.Forms.Panel();
            this.ultraLabel_Message1 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraGrid_DetailControl = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.tArrowKeyControl1 = new Broadleaf.Library.Windows.Forms.TArrowKeyControl(this.components);
            this.tRetKeyControl1 = new Broadleaf.Library.Windows.Forms.TRetKeyControl(this.components);
            this.panel_Footer.SuspendLayout();
            this.panel_Header.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGrid_DetailControl)).BeginInit();
            this.SuspendLayout();
            // 
            // Btn_OK
            // 
            this.Btn_OK.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F);
            this.Btn_OK.Location = new System.Drawing.Point(105, 3);
            this.Btn_OK.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Btn_OK.Name = "Btn_OK";
            this.Btn_OK.Size = new System.Drawing.Size(96, 26);
            this.Btn_OK.TabIndex = 0;
            this.Btn_OK.Text = "はい(&Y)";
            this.Btn_OK.Click += new System.EventHandler(this.Btn_OK_Click);
            // 
            // ultraLabel_Message
            // 
            appearance10.TextHAlignAsString = "Left";
            appearance10.TextVAlignAsString = "Middle";
            this.ultraLabel_Message.Appearance = appearance10;
            this.ultraLabel_Message.Location = new System.Drawing.Point(48, 3);
            this.ultraLabel_Message.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ultraLabel_Message.Name = "ultraLabel_Message";
            this.ultraLabel_Message.Size = new System.Drawing.Size(314, 36);
            this.ultraLabel_Message.TabIndex = 0;
            this.ultraLabel_Message.TextRenderingMode = Infragistics.Win.TextRenderingMode.GDIPlus;
            // 
            // panel_Footer
            // 
            this.panel_Footer.AutoSize = true;
            this.panel_Footer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_Footer.Controls.Add(this.Btn_No);
            this.panel_Footer.Controls.Add(this.Btn_OK);
            this.panel_Footer.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel_Footer.Location = new System.Drawing.Point(0, 290);
            this.panel_Footer.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panel_Footer.Name = "panel_Footer";
            this.panel_Footer.Size = new System.Drawing.Size(413, 34);
            this.panel_Footer.TabIndex = 4;
            // 
            // Btn_No
            // 
            this.Btn_No.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F);
            this.Btn_No.Location = new System.Drawing.Point(209, 3);
            this.Btn_No.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Btn_No.Name = "Btn_No";
            this.Btn_No.Size = new System.Drawing.Size(96, 26);
            this.Btn_No.TabIndex = 1;
            this.Btn_No.Text = "いいえ(&N)";
            this.Btn_No.Click += new System.EventHandler(this.Btn_No_Click);
            // 
            // panel_Header
            // 
            this.panel_Header.AutoSize = true;
            this.panel_Header.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_Header.Controls.Add(this.ultraLabel_Message1);
            this.panel_Header.Controls.Add(this.ultraLabel_Message);
            this.panel_Header.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_Header.Location = new System.Drawing.Point(0, 0);
            this.panel_Header.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panel_Header.Name = "panel_Header";
            this.panel_Header.Size = new System.Drawing.Size(413, 45);
            this.panel_Header.TabIndex = 3;
            // 
            // ultraLabel_Message1
            // 
            appearance13.TextHAlignAsString = "Left";
            appearance13.TextVAlignAsString = "Middle";
            this.ultraLabel_Message1.Appearance = appearance13;
            this.ultraLabel_Message1.Location = new System.Drawing.Point(71, 4);
            this.ultraLabel_Message1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ultraLabel_Message1.Name = "ultraLabel_Message1";
            this.ultraLabel_Message1.Size = new System.Drawing.Size(268, 36);
            this.ultraLabel_Message1.TabIndex = 1;
            this.ultraLabel_Message1.TextRenderingMode = Infragistics.Win.TextRenderingMode.GDIPlus;
            this.ultraLabel_Message1.Visible = false;
            // 
            // ultraGrid_DetailControl
            // 
            appearance1.BackColor = System.Drawing.Color.White;
            appearance1.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            appearance1.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance1.TextHAlignAsString = "Left";
            this.ultraGrid_DetailControl.DisplayLayout.Appearance = appearance1;
            appearance8.TextHAlignAsString = "Left";
            this.ultraGrid_DetailControl.DisplayLayout.CaptionAppearance = appearance8;
            this.ultraGrid_DetailControl.DisplayLayout.GroupByBox.Hidden = true;
            this.ultraGrid_DetailControl.DisplayLayout.InterBandSpacing = 10;
            this.ultraGrid_DetailControl.DisplayLayout.MaxColScrollRegions = 1;
            this.ultraGrid_DetailControl.DisplayLayout.MaxRowScrollRegions = 1;
            appearance2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(230)))), ((int)(((byte)(148)))));
            appearance2.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(230)))), ((int)(((byte)(148)))));
            appearance2.ForeColor = System.Drawing.Color.Black;
            this.ultraGrid_DetailControl.DisplayLayout.Override.ActiveCellAppearance = appearance2;
            appearance9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(230)))), ((int)(((byte)(148)))));
            appearance9.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(149)))), ((int)(((byte)(21)))));
            appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.ultraGrid_DetailControl.DisplayLayout.Override.ActiveRowAppearance = appearance9;
            this.ultraGrid_DetailControl.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No;
            this.ultraGrid_DetailControl.DisplayLayout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.WithinBand;
            this.ultraGrid_DetailControl.DisplayLayout.Override.AllowColSizing = Infragistics.Win.UltraWinGrid.AllowColSizing.Free;
            this.ultraGrid_DetailControl.DisplayLayout.Override.AllowColSwapping = Infragistics.Win.UltraWinGrid.AllowColSwapping.NotAllowed;
            this.ultraGrid_DetailControl.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
            this.ultraGrid_DetailControl.DisplayLayout.Override.AllowGroupBy = Infragistics.Win.DefaultableBoolean.False;
            this.ultraGrid_DetailControl.DisplayLayout.Override.AllowGroupMoving = Infragistics.Win.UltraWinGrid.AllowGroupMoving.NotAllowed;
            this.ultraGrid_DetailControl.DisplayLayout.Override.AllowGroupSwapping = Infragistics.Win.UltraWinGrid.AllowGroupSwapping.NotAllowed;
            this.ultraGrid_DetailControl.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
            this.ultraGrid_DetailControl.DisplayLayout.Override.AllowRowLayoutCellSizing = Infragistics.Win.UltraWinGrid.RowLayoutSizing.None;
            this.ultraGrid_DetailControl.DisplayLayout.Override.AllowRowLayoutCellSpanSizing = Infragistics.Win.Layout.GridBagLayoutAllowSpanSizing.None;
            this.ultraGrid_DetailControl.DisplayLayout.Override.AllowRowLayoutColMoving = Infragistics.Win.Layout.GridBagLayoutAllowMoving.None;
            this.ultraGrid_DetailControl.DisplayLayout.Override.AllowRowLayoutLabelSizing = Infragistics.Win.UltraWinGrid.RowLayoutSizing.None;
            this.ultraGrid_DetailControl.DisplayLayout.Override.AllowRowLayoutLabelSpanSizing = Infragistics.Win.Layout.GridBagLayoutAllowSpanSizing.None;
            this.ultraGrid_DetailControl.DisplayLayout.Override.AllowRowSummaries = Infragistics.Win.UltraWinGrid.AllowRowSummaries.False;
            this.ultraGrid_DetailControl.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.True;
            this.ultraGrid_DetailControl.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            this.ultraGrid_DetailControl.DisplayLayout.Override.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
            appearance3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance3.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance3.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance3.ForeColor = System.Drawing.Color.White;
            appearance3.ForeColorDisabled = System.Drawing.Color.White;
            appearance3.TextHAlignAsString = "Left";
            appearance3.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
            this.ultraGrid_DetailControl.DisplayLayout.Override.HeaderAppearance = appearance3;
            appearance4.BackColor = System.Drawing.Color.Lavender;
            this.ultraGrid_DetailControl.DisplayLayout.Override.RowAlternateAppearance = appearance4;
            appearance5.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(157)))), ((int)(((byte)(185)))));
            appearance5.TextVAlignAsString = "Middle";
            this.ultraGrid_DetailControl.DisplayLayout.Override.RowAppearance = appearance5;
            this.ultraGrid_DetailControl.DisplayLayout.Override.RowFilterAction = Infragistics.Win.UltraWinGrid.RowFilterAction.HideFilteredOutRows;
            this.ultraGrid_DetailControl.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand;
            appearance6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance6.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance6.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance6.ForeColor = System.Drawing.Color.White;
            this.ultraGrid_DetailControl.DisplayLayout.Override.RowSelectorAppearance = appearance6;
            this.ultraGrid_DetailControl.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            this.ultraGrid_DetailControl.DisplayLayout.Override.RowSelectorWidth = 20;
            this.ultraGrid_DetailControl.DisplayLayout.Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.AutoFixed;
            appearance7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(230)))), ((int)(((byte)(148)))));
            appearance7.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(149)))), ((int)(((byte)(21)))));
            appearance7.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance7.ForeColor = System.Drawing.Color.Black;
            this.ultraGrid_DetailControl.DisplayLayout.Override.SelectedRowAppearance = appearance7;
            this.ultraGrid_DetailControl.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.ultraGrid_DetailControl.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.ultraGrid_DetailControl.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.ultraGrid_DetailControl.DisplayLayout.Override.TipStyleCell = Infragistics.Win.UltraWinGrid.TipStyle.Hide;
            this.ultraGrid_DetailControl.DisplayLayout.Override.TipStyleRowConnector = Infragistics.Win.UltraWinGrid.TipStyle.Hide;
            this.ultraGrid_DetailControl.DisplayLayout.Override.TipStyleScroll = Infragistics.Win.UltraWinGrid.TipStyle.Hide;
            this.ultraGrid_DetailControl.DisplayLayout.RowConnectorColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(167)))), ((int)(((byte)(191)))));
            this.ultraGrid_DetailControl.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.ultraGrid_DetailControl.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.ultraGrid_DetailControl.DisplayLayout.UseFixedHeaders = true;
            this.ultraGrid_DetailControl.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand;
            this.ultraGrid_DetailControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraGrid_DetailControl.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraGrid_DetailControl.Location = new System.Drawing.Point(0, 45);
            this.ultraGrid_DetailControl.Name = "ultraGrid_DetailControl";
            this.ultraGrid_DetailControl.Size = new System.Drawing.Size(413, 245);
            this.ultraGrid_DetailControl.TabIndex = 21;
            this.ultraGrid_DetailControl.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.ultraGrid_DetailControl_InitializeLayout_1);
            this.ultraGrid_DetailControl.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ultraGrid_DetailControl_KeyDown);
            // 
            // tArrowKeyControl1
            // 
            this.tArrowKeyControl1.OwnerForm = this;
            this.tArrowKeyControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tRetKeyControl1_ChangeFocus);
            // 
            // tRetKeyControl1
            // 
            this.tRetKeyControl1.OwnerForm = this;
            this.tRetKeyControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tRetKeyControl1_ChangeFocus);
            // 
            // MAHNB01010UP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(413, 324);
            this.Controls.Add(this.ultraGrid_DetailControl);
            this.Controls.Add(this.panel_Footer);
            this.Controls.Add(this.panel_Header);
            this.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MAHNB01010UP";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "注意 - ＜売上伝票入力＞";
            this.Load += new System.EventHandler(this.MAHNB01010UP_Load);
            this.panel_Footer.ResumeLayout(false);
            this.panel_Header.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGrid_DetailControl)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Infragistics.Win.Misc.UltraButton Btn_OK;
        private Infragistics.Win.Misc.UltraLabel ultraLabel_Message;
        private System.Windows.Forms.Panel panel_Footer;
        private Infragistics.Win.Misc.UltraButton Btn_No;
        private System.Windows.Forms.Panel panel_Header;
        internal Infragistics.Win.UltraWinGrid.UltraGrid ultraGrid_DetailControl;
        private Broadleaf.Library.Windows.Forms.TArrowKeyControl tArrowKeyControl1;
        private Broadleaf.Library.Windows.Forms.TRetKeyControl tRetKeyControl1;
        private Infragistics.Win.Misc.UltraLabel ultraLabel_Message1;
    }
}
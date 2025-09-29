namespace Broadleaf.Windows.Forms
{
    partial class SelectionPrtGoodsNo
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
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("", -1);
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectionPrtGoodsNo));
            this.uGrid_PrintInfo = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.tEdit_SelectNo = new Broadleaf.Library.Windows.Forms.TEdit();
            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.tRetKeyControl1 = new Broadleaf.Library.Windows.Forms.TRetKeyControl(this.components);
            this.tArrowKeyControl1 = new Broadleaf.Library.Windows.Forms.TArrowKeyControl(this.components);
            this.uButton_Close = new Infragistics.Win.Misc.UltraButton();
            ((System.ComponentModel.ISupportInitialize)(this.uGrid_PrintInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SelectNo)).BeginInit();
            this.SuspendLayout();
            // 
            // uGrid_PrintInfo
            // 
            appearance16.BackColor = System.Drawing.Color.White;
            appearance16.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            appearance16.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.uGrid_PrintInfo.DisplayLayout.Appearance = appearance16;
            ultraGridBand1.Override.TipStyleCell = Infragistics.Win.UltraWinGrid.TipStyle.Show;
            ultraGridBand1.UseRowLayout = true;
            this.uGrid_PrintInfo.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.uGrid_PrintInfo.DisplayLayout.GroupByBox.Hidden = true;
            this.uGrid_PrintInfo.DisplayLayout.InterBandSpacing = 10;
            this.uGrid_PrintInfo.DisplayLayout.MaxColScrollRegions = 1;
            this.uGrid_PrintInfo.DisplayLayout.MaxRowScrollRegions = 1;
            appearance17.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(230)))), ((int)(((byte)(148)))));
            appearance17.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(230)))), ((int)(((byte)(148)))));
            appearance17.ForeColor = System.Drawing.Color.Black;
            this.uGrid_PrintInfo.DisplayLayout.Override.ActiveCellAppearance = appearance17;
            this.uGrid_PrintInfo.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No;
            this.uGrid_PrintInfo.DisplayLayout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.NotAllowed;
            this.uGrid_PrintInfo.DisplayLayout.Override.AllowColSizing = Infragistics.Win.UltraWinGrid.AllowColSizing.Free;
            this.uGrid_PrintInfo.DisplayLayout.Override.AllowColSwapping = Infragistics.Win.UltraWinGrid.AllowColSwapping.NotAllowed;
            this.uGrid_PrintInfo.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
            this.uGrid_PrintInfo.DisplayLayout.Override.AllowGroupBy = Infragistics.Win.DefaultableBoolean.False;
            this.uGrid_PrintInfo.DisplayLayout.Override.AllowGroupMoving = Infragistics.Win.UltraWinGrid.AllowGroupMoving.NotAllowed;
            this.uGrid_PrintInfo.DisplayLayout.Override.AllowGroupSwapping = Infragistics.Win.UltraWinGrid.AllowGroupSwapping.NotAllowed;
            this.uGrid_PrintInfo.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
            this.uGrid_PrintInfo.DisplayLayout.Override.AllowRowLayoutCellSizing = Infragistics.Win.UltraWinGrid.RowLayoutSizing.None;
            this.uGrid_PrintInfo.DisplayLayout.Override.AllowRowLayoutCellSpanSizing = Infragistics.Win.Layout.GridBagLayoutAllowSpanSizing.None;
            this.uGrid_PrintInfo.DisplayLayout.Override.AllowRowLayoutColMoving = Infragistics.Win.Layout.GridBagLayoutAllowMoving.None;
            this.uGrid_PrintInfo.DisplayLayout.Override.AllowRowLayoutLabelSizing = Infragistics.Win.UltraWinGrid.RowLayoutSizing.None;
            this.uGrid_PrintInfo.DisplayLayout.Override.AllowRowLayoutLabelSpanSizing = Infragistics.Win.Layout.GridBagLayoutAllowSpanSizing.None;
            this.uGrid_PrintInfo.DisplayLayout.Override.AllowRowSummaries = Infragistics.Win.UltraWinGrid.AllowRowSummaries.False;
            this.uGrid_PrintInfo.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.True;
            this.uGrid_PrintInfo.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.Edit;
            this.uGrid_PrintInfo.DisplayLayout.Override.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
            appearance18.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance18.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance18.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance18.ForeColor = System.Drawing.Color.White;
            appearance18.ForeColorDisabled = System.Drawing.Color.White;
            appearance18.TextHAlignAsString = "Center";
            appearance18.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
            this.uGrid_PrintInfo.DisplayLayout.Override.HeaderAppearance = appearance18;
            appearance19.BackColor = System.Drawing.Color.Lavender;
            this.uGrid_PrintInfo.DisplayLayout.Override.RowAlternateAppearance = appearance19;
            appearance20.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(157)))), ((int)(((byte)(185)))));
            appearance20.TextVAlignAsString = "Middle";
            this.uGrid_PrintInfo.DisplayLayout.Override.RowAppearance = appearance20;
            this.uGrid_PrintInfo.DisplayLayout.Override.RowFilterAction = Infragistics.Win.UltraWinGrid.RowFilterAction.HideFilteredOutRows;
            this.uGrid_PrintInfo.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand;
            appearance21.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance21.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance21.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance21.ForeColor = System.Drawing.Color.White;
            this.uGrid_PrintInfo.DisplayLayout.Override.RowSelectorAppearance = appearance21;
            this.uGrid_PrintInfo.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True;
            this.uGrid_PrintInfo.DisplayLayout.Override.RowSelectorWidth = 20;
            appearance22.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(230)))), ((int)(((byte)(148)))));
            appearance22.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(149)))), ((int)(((byte)(21)))));
            appearance22.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance22.ForeColor = System.Drawing.Color.Black;
            this.uGrid_PrintInfo.DisplayLayout.Override.SelectedRowAppearance = appearance22;
            this.uGrid_PrintInfo.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.Single;
            this.uGrid_PrintInfo.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.SingleAutoDrag;
            this.uGrid_PrintInfo.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.ExtendedAutoDrag;
            this.uGrid_PrintInfo.DisplayLayout.Override.TipStyleCell = Infragistics.Win.UltraWinGrid.TipStyle.Hide;
            this.uGrid_PrintInfo.DisplayLayout.Override.TipStyleRowConnector = Infragistics.Win.UltraWinGrid.TipStyle.Hide;
            this.uGrid_PrintInfo.DisplayLayout.Override.TipStyleScroll = Infragistics.Win.UltraWinGrid.TipStyle.Hide;
            this.uGrid_PrintInfo.DisplayLayout.RowConnectorColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(167)))), ((int)(((byte)(191)))));
            this.uGrid_PrintInfo.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.uGrid_PrintInfo.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.uGrid_PrintInfo.DisplayLayout.UseFixedHeaders = true;
            this.uGrid_PrintInfo.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand;
            this.uGrid_PrintInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.uGrid_PrintInfo.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uGrid_PrintInfo.Location = new System.Drawing.Point(0, 0);
            this.uGrid_PrintInfo.Name = "uGrid_PrintInfo";
            this.uGrid_PrintInfo.Size = new System.Drawing.Size(558, 66);
            this.uGrid_PrintInfo.TabIndex = 2;
            this.uGrid_PrintInfo.ClickCellButton += new Infragistics.Win.UltraWinGrid.CellEventHandler(this.uGrid_PrintInfo_ClickCellButton);
            this.uGrid_PrintInfo.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.uGrid_PrintInfo_InitializeLayout);
            this.uGrid_PrintInfo.Leave += new System.EventHandler(this.uGrid_PrintInfo_Leave);
            this.uGrid_PrintInfo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.uGrid_PrintInfo_KeyDown);
            // 
            // tEdit_SelectNo
            // 
            appearance2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance2.TextHAlignAsString = "Right";
            this.tEdit_SelectNo.ActiveAppearance = appearance2;
            appearance3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance3.ForeColorDisabled = System.Drawing.Color.Black;
            appearance3.TextHAlignAsString = "Right";
            this.tEdit_SelectNo.Appearance = appearance3;
            this.tEdit_SelectNo.AutoSelect = true;
            this.tEdit_SelectNo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tEdit_SelectNo.DataText = "1";
            this.tEdit_SelectNo.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, false, true, true, true, false);
            this.tEdit_SelectNo.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 2, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tEdit_SelectNo.Location = new System.Drawing.Point(500, 70);
            this.tEdit_SelectNo.MaxLength = 2;
            this.tEdit_SelectNo.Name = "tEdit_SelectNo";
            this.tEdit_SelectNo.Size = new System.Drawing.Size(51, 24);
            this.tEdit_SelectNo.TabIndex = 1;
            this.tEdit_SelectNo.Text = "1";
            this.tEdit_SelectNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tEdit_SelectNo_KeyPress);
            // 
            // ultraLabel1
            // 
            appearance1.TextVAlignAsString = "Middle";
            this.ultraLabel1.Appearance = appearance1;
            this.ultraLabel1.Location = new System.Drawing.Point(455, 70);
            this.ultraLabel1.Margin = new System.Windows.Forms.Padding(4);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(38, 26);
            this.ultraLabel1.TabIndex = 30;
            this.ultraLabel1.Text = "選択";
            // 
            // tRetKeyControl1
            // 
            this.tRetKeyControl1.CatchMouse = true;
            this.tRetKeyControl1.OwnerForm = this;
            this.tRetKeyControl1.Style = Broadleaf.Library.Windows.Forms.emFocusStyle.ByTab;
            this.tRetKeyControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tRetKeyControl1_ChangeFocus);
            // 
            // tArrowKeyControl1
            // 
            this.tArrowKeyControl1.OwnerForm = this;
            this.tArrowKeyControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tRetKeyControl1_ChangeFocus);
            // 
            // uButton_Close
            // 
            this.uButton_Close.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.uButton_Close.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uButton_Close.Location = new System.Drawing.Point(231, 12);
            this.uButton_Close.Name = "uButton_Close";
            this.uButton_Close.Size = new System.Drawing.Size(101, 25);
            this.uButton_Close.TabIndex = 31;
            this.uButton_Close.TabStop = false;
            this.uButton_Close.Text = "終了ボタン";
            this.uButton_Close.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            // 
            // SelectionPrtGoodsNo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(254)))));
            this.CancelButton = this.uButton_Close;
            this.ClientSize = new System.Drawing.Size(558, 100);
            this.Controls.Add(this.ultraLabel1);
            this.Controls.Add(this.tEdit_SelectNo);
            this.Controls.Add(this.uGrid_PrintInfo);
            this.Controls.Add(this.uButton_Close);
            this.Font = new System.Drawing.Font("ＭＳ Ｐゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(566, 134);
            this.Name = "SelectionPrtGoodsNo";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "印刷品番選択";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SelectionPrtGoodsNo_FormClosed);
            this.Click += new System.EventHandler(this.uButton_Close_Click);
            ((System.ComponentModel.ISupportInitialize)(this.uGrid_PrintInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SelectNo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal Infragistics.Win.UltraWinGrid.UltraGrid uGrid_PrintInfo;
        private Broadleaf.Library.Windows.Forms.TEdit tEdit_SelectNo;
        private Infragistics.Win.Misc.UltraLabel ultraLabel1;
        private Broadleaf.Library.Windows.Forms.TRetKeyControl tRetKeyControl1;
        private Broadleaf.Library.Windows.Forms.TArrowKeyControl tArrowKeyControl1;
        private Infragistics.Win.Misc.UltraButton uButton_Close;
    }
}
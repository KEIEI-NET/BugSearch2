namespace Broadleaf.Windows.Forms
{
    partial class PMUOE09020UB
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
            Infragistics.Win.Appearance appearance157 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance158 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance159 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance160 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance161 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance162 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance163 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance164 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PMUOE09020UB));
            this.uGrid = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.Ok_Button = new Infragistics.Win.Misc.UltraButton();
            this.Cancel_Button = new Infragistics.Win.Misc.UltraButton();
            this.tArrowKeyControl1 = new Broadleaf.Library.Windows.Forms.TArrowKeyControl(this.components);
            this.tRetKeyControl1 = new Broadleaf.Library.Windows.Forms.TRetKeyControl(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.Title_ultraLabel = new Infragistics.Win.Misc.UltraLabel();
            ((System.ComponentModel.ISupportInitialize)(this.uGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // uGrid
            // 
            appearance157.BackColor = System.Drawing.Color.White;
            appearance157.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            appearance157.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.uGrid.DisplayLayout.Appearance = appearance157;
            this.uGrid.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.uGrid.DisplayLayout.GroupByBox.Hidden = true;
            this.uGrid.DisplayLayout.GroupByBox.Style = Infragistics.Win.UltraWinGrid.GroupByBoxStyle.Compact;
            this.uGrid.DisplayLayout.InterBandSpacing = 10;
            this.uGrid.DisplayLayout.MaxColScrollRegions = 1;
            this.uGrid.DisplayLayout.MaxRowScrollRegions = 1;
            appearance158.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance158.ForeColor = System.Drawing.Color.Black;
            this.uGrid.DisplayLayout.Override.ActiveCellAppearance = appearance158;
            this.uGrid.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.Yes;
            this.uGrid.DisplayLayout.Override.AllowColSizing = Infragistics.Win.UltraWinGrid.AllowColSizing.None;
            this.uGrid.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
            this.uGrid.DisplayLayout.Override.AllowRowSummaries = Infragistics.Win.UltraWinGrid.AllowRowSummaries.False;
            appearance159.ForeColor = System.Drawing.Color.Black;
            appearance159.ForeColorDisabled = System.Drawing.Color.Black;
            this.uGrid.DisplayLayout.Override.CellAppearance = appearance159;
            this.uGrid.DisplayLayout.Override.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
            appearance160.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance160.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance160.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance160.Cursor = System.Windows.Forms.Cursors.Hand;
            appearance160.ForeColor = System.Drawing.Color.White;
            appearance160.TextHAlignAsString = "Center";
            appearance160.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
            this.uGrid.DisplayLayout.Override.HeaderAppearance = appearance160;
            this.uGrid.DisplayLayout.Override.MaxSelectedCells = 1;
            this.uGrid.DisplayLayout.Override.MaxSelectedRows = 1;
            appearance161.BackColor = System.Drawing.Color.Lavender;
            this.uGrid.DisplayLayout.Override.RowAlternateAppearance = appearance161;
            appearance162.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(68)))), ((int)(((byte)(208)))));
            appearance162.TextVAlignAsString = "Middle";
            this.uGrid.DisplayLayout.Override.RowAppearance = appearance162;
            appearance163.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance163.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance163.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance163.ForeColor = System.Drawing.Color.White;
            this.uGrid.DisplayLayout.Override.RowSelectorAppearance = appearance163;
            this.uGrid.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            this.uGrid.DisplayLayout.Override.RowSelectorWidth = 12;
            this.uGrid.DisplayLayout.Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.AutoFixed;
            appearance164.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(230)))), ((int)(((byte)(148)))));
            appearance164.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(149)))), ((int)(((byte)(21)))));
            appearance164.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance164.ForeColor = System.Drawing.Color.Black;
            this.uGrid.DisplayLayout.Override.SelectedRowAppearance = appearance164;
            this.uGrid.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.uGrid.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.uGrid.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.uGrid.DisplayLayout.Override.TipStyleCell = Infragistics.Win.UltraWinGrid.TipStyle.Hide;
            this.uGrid.DisplayLayout.Override.TipStyleRowConnector = Infragistics.Win.UltraWinGrid.TipStyle.Hide;
            this.uGrid.DisplayLayout.Override.TipStyleScroll = Infragistics.Win.UltraWinGrid.TipStyle.Hide;
            this.uGrid.DisplayLayout.RowConnectorColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(167)))), ((int)(((byte)(191)))));
            this.uGrid.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.uGrid.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.uGrid.DisplayLayout.UseFixedHeaders = true;
            this.uGrid.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand;
            this.uGrid.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uGrid.Location = new System.Drawing.Point(12, 50);
            this.uGrid.Name = "uGrid";
            this.uGrid.Size = new System.Drawing.Size(247, 245);
            this.uGrid.TabIndex = 2;
            this.uGrid.ClickCellButton += new Infragistics.Win.UltraWinGrid.CellEventHandler(this.uGrid_ClickCellButton);
            this.uGrid.BeforeCellUpdate += new Infragistics.Win.UltraWinGrid.BeforeCellUpdateEventHandler(this.uGrid_BeforeCellUpdate);
            this.uGrid.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.uGrid_InitializeLayout);
            this.uGrid.AfterCellUpdate += new Infragistics.Win.UltraWinGrid.CellEventHandler(this.uGrid_AfterCellUpdate);
            this.uGrid.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.uGrid_KeyPress);
            this.uGrid.AfterPerformAction += new Infragistics.Win.UltraWinGrid.AfterUltraGridPerformActionEventHandler(this.uGrid_AfterPerformAction);
            this.uGrid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.uGrid_KeyDown);
            // 
            // Ok_Button
            // 
            this.Ok_Button.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Ok_Button.Location = new System.Drawing.Point(140, 311);
            this.Ok_Button.Name = "Ok_Button";
            this.Ok_Button.Size = new System.Drawing.Size(110, 30);
            this.Ok_Button.TabIndex = 3;
            this.Ok_Button.Text = "保存(&S)";
            this.Ok_Button.Click += new System.EventHandler(this.Ok_Button_Click);
            // 
            // Cancel_Button
            // 
            this.Cancel_Button.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Cancel_Button.Location = new System.Drawing.Point(265, 311);
            this.Cancel_Button.Name = "Cancel_Button";
            this.Cancel_Button.Size = new System.Drawing.Size(110, 30);
            this.Cancel_Button.TabIndex = 4;
            this.Cancel_Button.Text = "閉じる(&X)";
            this.Cancel_Button.Click += new System.EventHandler(this.Cancel_Button_Click);
            // 
            // tArrowKeyControl1
            // 
            this.tArrowKeyControl1.OwnerForm = this;
            this.tArrowKeyControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tArrowKeyControl1_ChangeFocus);
            // 
            // tRetKeyControl1
            // 
            this.tRetKeyControl1.OwnerForm = this;
            this.tRetKeyControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tArrowKeyControl1_ChangeFocus);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Title_ultraLabel
            // 
            appearance2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance2.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance2.ForeColor = System.Drawing.Color.White;
            appearance2.TextHAlignAsString = "Center";
            appearance2.TextVAlignAsString = "Middle";
            this.Title_ultraLabel.Appearance = appearance2;
            this.Title_ultraLabel.Location = new System.Drawing.Point(12, 27);
            this.Title_ultraLabel.Name = "Title_ultraLabel";
            this.Title_ultraLabel.Size = new System.Drawing.Size(247, 23);
            this.Title_ultraLabel.TabIndex = 5;
            // 
            // PMUOE09020UB
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(254)))));
            this.ClientSize = new System.Drawing.Size(411, 353);
            this.Controls.Add(this.Title_ultraLabel);
            this.Controls.Add(this.Cancel_Button);
            this.Controls.Add(this.Ok_Button);
            this.Controls.Add(this.uGrid);
            this.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PMUOE09020UB";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "外車対応メーカー";
            this.Load += new System.EventHandler(this.PMUOE09020UB_Load);
            ((System.ComponentModel.ISupportInitialize)(this.uGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.UltraWinGrid.UltraGrid uGrid;
        private Infragistics.Win.Misc.UltraButton Ok_Button;
        private Infragistics.Win.Misc.UltraButton Cancel_Button;
        private Broadleaf.Library.Windows.Forms.TArrowKeyControl tArrowKeyControl1;
        private Broadleaf.Library.Windows.Forms.TRetKeyControl tRetKeyControl1;
        private System.Windows.Forms.Timer timer1;
        private Infragistics.Win.Misc.UltraLabel Title_ultraLabel;
    }
}
namespace Broadleaf.Windows.Forms
{
    partial class MakerGuide
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MakerGuide));
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
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            this.ToolBar_panel = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.Search_panel = new System.Windows.Forms.Panel();
            this.MakerKana_TextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.MakerName_TextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Annotation_panel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.Maker_Grid = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.tRetKeyControl1 = new Broadleaf.Library.Windows.Forms.TRetKeyControl(this.components);
            this.tArrowKeyControl1 = new Broadleaf.Library.Windows.Forms.TArrowKeyControl(this.components);
            this.ToolBar_panel.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.Search_panel.SuspendLayout();
            this.Annotation_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Maker_Grid)).BeginInit();
            this.SuspendLayout();
            // 
            // ToolBar_panel
            // 
            this.ToolBar_panel.Controls.Add(this.toolStrip1);
            this.ToolBar_panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.ToolBar_panel.Location = new System.Drawing.Point(0, 0);
            this.ToolBar_panel.Name = "ToolBar_panel";
            this.ToolBar_panel.Size = new System.Drawing.Size(484, 27);
            this.ToolBar_panel.TabIndex = 20;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(146, 25);
            this.toolStrip1.TabIndex = 18;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Cyan;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(67, 22);
            this.toolStripButton1.Text = "確定(&S)";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Cyan;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(67, 22);
            this.toolStripButton2.Text = "戻る(&C)";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // Search_panel
            // 
            this.Search_panel.Controls.Add(this.MakerKana_TextBox);
            this.Search_panel.Controls.Add(this.label2);
            this.Search_panel.Controls.Add(this.MakerName_TextBox);
            this.Search_panel.Controls.Add(this.label3);
            this.Search_panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.Search_panel.Location = new System.Drawing.Point(0, 56);
            this.Search_panel.Name = "Search_panel";
            this.Search_panel.Size = new System.Drawing.Size(484, 64);
            this.Search_panel.TabIndex = 23;
            // 
            // MakerKana_TextBox
            // 
            this.MakerKana_TextBox.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf;
            this.MakerKana_TextBox.Location = new System.Drawing.Point(91, 35);
            this.MakerKana_TextBox.MaxLength = 20;
            this.MakerKana_TextBox.Name = "MakerKana_TextBox";
            this.MakerKana_TextBox.Size = new System.Drawing.Size(309, 22);
            this.MakerKana_TextBox.TabIndex = 4;
            this.MakerKana_TextBox.TextChanged += new System.EventHandler(this.MakerKana_TextBox_TextChanged);
            this.MakerKana_TextBox.Leave += new System.EventHandler(this.MakerKana_TextBox_Leave);
            this.MakerKana_TextBox.Enter += new System.EventHandler(this.MakerKana_TextBox_Enter);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(13, 31);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 28);
            this.label2.TabIndex = 3;
            this.label2.Text = "カナ";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // MakerName_TextBox
            // 
            this.MakerName_TextBox.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.MakerName_TextBox.Location = new System.Drawing.Point(91, 7);
            this.MakerName_TextBox.MaxLength = 30;
            this.MakerName_TextBox.Name = "MakerName_TextBox";
            this.MakerName_TextBox.Size = new System.Drawing.Size(309, 22);
            this.MakerName_TextBox.TabIndex = 2;
            this.MakerName_TextBox.TextChanged += new System.EventHandler(this.MakerName_TextBox_TextChanged);
            this.MakerName_TextBox.Leave += new System.EventHandler(this.MakerName_TextBox_Leave);
            this.MakerName_TextBox.Enter += new System.EventHandler(this.MakerName_TextBox_Enter);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(13, 3);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 28);
            this.label3.TabIndex = 1;
            this.label3.Text = "名称";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Annotation_panel
            // 
            this.Annotation_panel.Controls.Add(this.label1);
            this.Annotation_panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.Annotation_panel.Location = new System.Drawing.Point(0, 27);
            this.Annotation_panel.Name = "Annotation_panel";
            this.Annotation_panel.Size = new System.Drawing.Size(484, 29);
            this.Annotation_panel.TabIndex = 22;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(13, 5);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(407, 21);
            this.label1.TabIndex = 11;
            this.label1.Text = "メーカーを選択して下さい";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Maker_Grid
            // 
            appearance1.FontData.Name = "ＭＳ ゴシック";
            appearance1.ForeColorDisabled = System.Drawing.Color.Black;
            this.Maker_Grid.DisplayLayout.Appearance = appearance1;
            appearance2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance2.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance2.BorderColor = System.Drawing.SystemColors.Window;
            this.Maker_Grid.DisplayLayout.GroupByBox.Appearance = appearance2;
            appearance3.ForeColor = System.Drawing.SystemColors.GrayText;
            this.Maker_Grid.DisplayLayout.GroupByBox.BandLabelAppearance = appearance3;
            this.Maker_Grid.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.Maker_Grid.DisplayLayout.GroupByBox.Hidden = true;
            appearance4.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance4.BackColor2 = System.Drawing.SystemColors.Control;
            appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance4.ForeColor = System.Drawing.SystemColors.GrayText;
            this.Maker_Grid.DisplayLayout.GroupByBox.PromptAppearance = appearance4;
            appearance5.BackColor = System.Drawing.SystemColors.Window;
            appearance5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Maker_Grid.DisplayLayout.Override.ActiveCellAppearance = appearance5;
            appearance6.BackColor = System.Drawing.SystemColors.Highlight;
            appearance6.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.Maker_Grid.DisplayLayout.Override.ActiveRowAppearance = appearance6;
            this.Maker_Grid.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.Maker_Grid.DisplayLayout.Override.BorderStyleHeader = Infragistics.Win.UIElementBorderStyle.Solid;
            this.Maker_Grid.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            appearance7.BackColor = System.Drawing.SystemColors.Window;
            this.Maker_Grid.DisplayLayout.Override.CardAreaAppearance = appearance7;
            appearance8.BorderColor = System.Drawing.Color.Silver;
            appearance8.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.Maker_Grid.DisplayLayout.Override.CellAppearance = appearance8;
            this.Maker_Grid.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.Maker_Grid.DisplayLayout.Override.CellPadding = 0;
            appearance9.BackColor = System.Drawing.SystemColors.Control;
            appearance9.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance9.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance9.BorderColor = System.Drawing.SystemColors.Window;
            this.Maker_Grid.DisplayLayout.Override.GroupByRowAppearance = appearance9;
            appearance10.TextHAlign = Infragistics.Win.HAlign.Left;
            this.Maker_Grid.DisplayLayout.Override.HeaderAppearance = appearance10;
            this.Maker_Grid.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.Maker_Grid.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance11.BackColor = System.Drawing.SystemColors.Window;
            appearance11.BorderColor = System.Drawing.Color.Silver;
            this.Maker_Grid.DisplayLayout.Override.RowAppearance = appearance11;
            this.Maker_Grid.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(230)))), ((int)(((byte)(148)))));
            appearance12.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(149)))), ((int)(((byte)(21)))));
            appearance12.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance12.ForeColor = System.Drawing.Color.Black;
            appearance12.TextVAlign = Infragistics.Win.VAlign.Middle;
            this.Maker_Grid.DisplayLayout.Override.SelectedRowAppearance = appearance12;
            this.Maker_Grid.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.SingleAutoDrag;
            this.Maker_Grid.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Single;
            appearance13.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Maker_Grid.DisplayLayout.Override.TemplateAddRowAppearance = appearance13;
            this.Maker_Grid.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.Maker_Grid.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.Maker_Grid.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand;
            this.Maker_Grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Maker_Grid.Location = new System.Drawing.Point(0, 120);
            this.Maker_Grid.Name = "Maker_Grid";
            this.Maker_Grid.Size = new System.Drawing.Size(484, 592);
            this.Maker_Grid.TabIndex = 5;
            this.Maker_Grid.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.Maker_Grid_InitializeLayout);
            this.Maker_Grid.Enter += new System.EventHandler(this.Maker_Grid_Enter);
            this.Maker_Grid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Maker_Grid_KeyDown);
            this.Maker_Grid.DoubleClickRow += new Infragistics.Win.UltraWinGrid.DoubleClickRowEventHandler(this.Maker_Grid_DoubleClickRow);
            // 
            // tRetKeyControl1
            // 
            this.tRetKeyControl1.OwnerForm = this;
            this.tRetKeyControl1.Style = Broadleaf.Library.Windows.Forms.emFocusStyle.ByTab;
            this.tRetKeyControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tRetKeyControl1_ChangeFocus);
            // 
            // tArrowKeyControl1
            // 
            this.tArrowKeyControl1.OwnerForm = this;
            this.tArrowKeyControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tRetKeyControl1_ChangeFocus);
            // 
            // MakerGuide
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 712);
            this.Controls.Add(this.Maker_Grid);
            this.Controls.Add(this.Search_panel);
            this.Controls.Add(this.Annotation_panel);
            this.Controls.Add(this.ToolBar_panel);
            this.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MakerGuide";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "メーカーガイド";
            this.ToolBar_panel.ResumeLayout(false);
            this.ToolBar_panel.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.Search_panel.ResumeLayout(false);
            this.Search_panel.PerformLayout();
            this.Annotation_panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Maker_Grid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel ToolBar_panel;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.Panel Search_panel;
        private System.Windows.Forms.TextBox MakerName_TextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel Annotation_panel;
        private System.Windows.Forms.Label label1;
        private Infragistics.Win.UltraWinGrid.UltraGrid Maker_Grid;
        private Broadleaf.Library.Windows.Forms.TRetKeyControl tRetKeyControl1;
        private System.Windows.Forms.TextBox MakerKana_TextBox;
        private System.Windows.Forms.Label label2;
        private Broadleaf.Library.Windows.Forms.TArrowKeyControl tArrowKeyControl1;
    }
}
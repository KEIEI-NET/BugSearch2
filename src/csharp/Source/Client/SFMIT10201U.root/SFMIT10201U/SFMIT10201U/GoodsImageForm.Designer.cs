namespace Broadleaf.Windows.Forms
{
    partial class GoodsImageForm
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
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GoodsImageForm));
            this.Top_panel = new System.Windows.Forms.Panel();
            this.Category_ComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.Category_label = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tool_panel = new System.Windows.Forms.Panel();
            this.ImportImage_Button = new Infragistics.Win.Misc.UltraButton();
            this.DelRow_Button = new Infragistics.Win.Misc.UltraButton();
            this.AddRow_ultraButton = new Infragistics.Win.Misc.UltraButton();
            this.GoodsImage_Grid = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.Buttom_panel = new System.Windows.Forms.Panel();
            this.Cancel_Button = new Infragistics.Win.Misc.UltraButton();
            this.Save_Button = new Infragistics.Win.Misc.UltraButton();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.ToolBar_panel = new System.Windows.Forms.Panel();
            this.Annotation_panel = new System.Windows.Forms.Panel();
            this.Search_panel = new System.Windows.Forms.Panel();
            this.ImageName_TextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tRetKeyControl1 = new Broadleaf.Library.Windows.Forms.TRetKeyControl(this.components);
            this.tArrowKeyControl1 = new Broadleaf.Library.Windows.Forms.TArrowKeyControl(this.components);
            this.Top_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Category_ComboEditor)).BeginInit();
            this.tool_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsImage_Grid)).BeginInit();
            this.Buttom_panel.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.ToolBar_panel.SuspendLayout();
            this.Annotation_panel.SuspendLayout();
            this.Search_panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // Top_panel
            // 
            this.Top_panel.Controls.Add(this.Category_ComboEditor);
            this.Top_panel.Controls.Add(this.Category_label);
            this.Top_panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.Top_panel.Location = new System.Drawing.Point(0, 25);
            this.Top_panel.Margin = new System.Windows.Forms.Padding(4);
            this.Top_panel.Name = "Top_panel";
            this.Top_panel.Size = new System.Drawing.Size(444, 39);
            this.Top_panel.TabIndex = 1;
            // 
            // Category_ComboEditor
            // 
            this.Category_ComboEditor.ActiveAppearance = appearance1;
            this.Category_ComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.Category_ComboEditor.Location = new System.Drawing.Point(127, 8);
            this.Category_ComboEditor.Name = "Category_ComboEditor";
            this.Category_ComboEditor.Size = new System.Drawing.Size(200, 24);
            this.Category_ComboEditor.TabIndex = 3;
            this.Category_ComboEditor.ValueChanged += new System.EventHandler(this.Category_ComboEditor_ValueChanged);
            // 
            // Category_label
            // 
            this.Category_label.Location = new System.Drawing.Point(13, 4);
            this.Category_label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Category_label.Name = "Category_label";
            this.Category_label.Size = new System.Drawing.Size(391, 28);
            this.Category_label.TabIndex = 2;
            this.Category_label.Text = "商品カテゴリ";
            this.Category_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(13, 26);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(407, 21);
            this.label2.TabIndex = 6;
            this.label2.Text = "※画像サイズは200×200ピクセルを推奨します。";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(13, 5);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(407, 21);
            this.label1.TabIndex = 5;
            this.label1.Text = "※登録できるファイルサイズは200KBまでです。";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tool_panel
            // 
            this.tool_panel.Controls.Add(this.ImportImage_Button);
            this.tool_panel.Controls.Add(this.DelRow_Button);
            this.tool_panel.Controls.Add(this.AddRow_ultraButton);
            this.tool_panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.tool_panel.Location = new System.Drawing.Point(0, 151);
            this.tool_panel.Name = "tool_panel";
            this.tool_panel.Size = new System.Drawing.Size(444, 46);
            this.tool_panel.TabIndex = 10;
            // 
            // ImportImage_Button
            // 
            appearance2.ForeColor = System.Drawing.Color.Black;
            this.ImportImage_Button.Appearance = appearance2;
            this.ImportImage_Button.HotTracking = true;
            this.ImportImage_Button.ImageSize = new System.Drawing.Size(25, 25);
            this.ImportImage_Button.Location = new System.Drawing.Point(216, 6);
            this.ImportImage_Button.Name = "ImportImage_Button";
            this.ImportImage_Button.Size = new System.Drawing.Size(105, 34);
            this.ImportImage_Button.TabIndex = 13;
            this.ImportImage_Button.Text = "画像読込(&I)";
            this.ImportImage_Button.Click += new System.EventHandler(this.ImportImage_Button_Click);
            // 
            // DelRow_Button
            // 
            appearance3.ForeColor = System.Drawing.Color.Black;
            this.DelRow_Button.Appearance = appearance3;
            this.DelRow_Button.HotTracking = true;
            this.DelRow_Button.ImageSize = new System.Drawing.Size(25, 25);
            this.DelRow_Button.Location = new System.Drawing.Point(110, 6);
            this.DelRow_Button.Name = "DelRow_Button";
            this.DelRow_Button.Size = new System.Drawing.Size(105, 34);
            this.DelRow_Button.TabIndex = 12;
            this.DelRow_Button.Text = "行削除(&D)";
            this.DelRow_Button.Click += new System.EventHandler(this.DelRow_Button_Click);
            // 
            // AddRow_ultraButton
            // 
            appearance4.ForeColor = System.Drawing.Color.Black;
            this.AddRow_ultraButton.Appearance = appearance4;
            this.AddRow_ultraButton.HotTracking = true;
            this.AddRow_ultraButton.ImageSize = new System.Drawing.Size(25, 25);
            this.AddRow_ultraButton.Location = new System.Drawing.Point(12, 6);
            this.AddRow_ultraButton.Name = "AddRow_ultraButton";
            this.AddRow_ultraButton.Size = new System.Drawing.Size(98, 34);
            this.AddRow_ultraButton.TabIndex = 11;
            this.AddRow_ultraButton.Text = "行追加(&A)";
            this.AddRow_ultraButton.Click += new System.EventHandler(this.AddRow_ultraButton_Click);
            // 
            // GoodsImage_Grid
            // 
            appearance5.BackColor = System.Drawing.Color.White;
            appearance5.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            appearance5.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance5.FontData.Name = "ＭＳ ゴシック";
            appearance5.ForeColorDisabled = System.Drawing.Color.Black;
            this.GoodsImage_Grid.DisplayLayout.Appearance = appearance5;
            appearance6.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance6.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance6.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance6.BorderColor = System.Drawing.SystemColors.Window;
            this.GoodsImage_Grid.DisplayLayout.GroupByBox.Appearance = appearance6;
            appearance7.ForeColor = System.Drawing.SystemColors.GrayText;
            this.GoodsImage_Grid.DisplayLayout.GroupByBox.BandLabelAppearance = appearance7;
            this.GoodsImage_Grid.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.GoodsImage_Grid.DisplayLayout.GroupByBox.Hidden = true;
            appearance8.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance8.BackColor2 = System.Drawing.SystemColors.Control;
            appearance8.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance8.ForeColor = System.Drawing.SystemColors.GrayText;
            this.GoodsImage_Grid.DisplayLayout.GroupByBox.PromptAppearance = appearance8;
            this.GoodsImage_Grid.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.GoodsImage_Grid.DisplayLayout.Override.BorderStyleHeader = Infragistics.Win.UIElementBorderStyle.Solid;
            this.GoodsImage_Grid.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            appearance9.BackColor = System.Drawing.SystemColors.Window;
            this.GoodsImage_Grid.DisplayLayout.Override.CardAreaAppearance = appearance9;
            appearance10.BorderColor = System.Drawing.Color.Silver;
            appearance10.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.GoodsImage_Grid.DisplayLayout.Override.CellAppearance = appearance10;
            this.GoodsImage_Grid.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.GoodsImage_Grid.DisplayLayout.Override.CellPadding = 0;
            appearance11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.GoodsImage_Grid.DisplayLayout.Override.EditCellAppearance = appearance11;
            this.GoodsImage_Grid.DisplayLayout.Override.ExpansionIndicator = Infragistics.Win.UltraWinGrid.ShowExpansionIndicator.Never;
            appearance12.BackColor = System.Drawing.SystemColors.Control;
            appearance12.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance12.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance12.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance12.BorderColor = System.Drawing.SystemColors.Window;
            this.GoodsImage_Grid.DisplayLayout.Override.GroupByRowAppearance = appearance12;
            appearance13.TextHAlign = Infragistics.Win.HAlign.Left;
            this.GoodsImage_Grid.DisplayLayout.Override.HeaderAppearance = appearance13;
            this.GoodsImage_Grid.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.GoodsImage_Grid.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            this.GoodsImage_Grid.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(230)))), ((int)(((byte)(148)))));
            appearance14.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(149)))), ((int)(((byte)(21)))));
            appearance14.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance14.ForeColor = System.Drawing.Color.Black;
            appearance14.TextVAlign = Infragistics.Win.VAlign.Middle;
            this.GoodsImage_Grid.DisplayLayout.Override.SelectedRowAppearance = appearance14;
            this.GoodsImage_Grid.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.SingleAutoDrag;
            this.GoodsImage_Grid.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Single;
            appearance15.BackColor = System.Drawing.SystemColors.ControlLight;
            this.GoodsImage_Grid.DisplayLayout.Override.TemplateAddRowAppearance = appearance15;
            this.GoodsImage_Grid.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.GoodsImage_Grid.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.GoodsImage_Grid.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand;
            this.GoodsImage_Grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GoodsImage_Grid.Location = new System.Drawing.Point(0, 197);
            this.GoodsImage_Grid.Name = "GoodsImage_Grid";
            this.GoodsImage_Grid.Size = new System.Drawing.Size(444, 460);
            this.GoodsImage_Grid.TabIndex = 14;
            this.GoodsImage_Grid.ClickCellButton += new Infragistics.Win.UltraWinGrid.CellEventHandler(this.GoodsImage_Grid_ClickCellButton);
            this.GoodsImage_Grid.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.GoodsImage_Grid_InitializeLayout);
            this.GoodsImage_Grid.Enter += new System.EventHandler(this.GoodsImage_Grid_Enter);
            this.GoodsImage_Grid.InitializeRow += new Infragistics.Win.UltraWinGrid.InitializeRowEventHandler(this.GoodsImage_Grid_InitializeRow);
            this.GoodsImage_Grid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GoodsImage_Grid_KeyDown);
            // 
            // Buttom_panel
            // 
            this.Buttom_panel.Controls.Add(this.Cancel_Button);
            this.Buttom_panel.Controls.Add(this.Save_Button);
            this.Buttom_panel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Buttom_panel.Location = new System.Drawing.Point(0, 657);
            this.Buttom_panel.Name = "Buttom_panel";
            this.Buttom_panel.Size = new System.Drawing.Size(444, 55);
            this.Buttom_panel.TabIndex = 15;
            // 
            // Cancel_Button
            // 
            this.Cancel_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            appearance16.ForeColor = System.Drawing.Color.Black;
            this.Cancel_Button.Appearance = appearance16;
            this.Cancel_Button.HotTracking = true;
            this.Cancel_Button.ImageSize = new System.Drawing.Size(25, 25);
            this.Cancel_Button.Location = new System.Drawing.Point(310, 9);
            this.Cancel_Button.Name = "Cancel_Button";
            this.Cancel_Button.Size = new System.Drawing.Size(125, 34);
            this.Cancel_Button.TabIndex = 17;
            this.Cancel_Button.Text = "閉じる(&X)";
            this.Cancel_Button.Click += new System.EventHandler(this.Cancel_Button_Click);
            // 
            // Save_Button
            // 
            this.Save_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            appearance17.ForeColor = System.Drawing.Color.Black;
            this.Save_Button.Appearance = appearance17;
            this.Save_Button.HotTracking = true;
            this.Save_Button.ImageSize = new System.Drawing.Size(25, 25);
            this.Save_Button.Location = new System.Drawing.Point(185, 9);
            this.Save_Button.Name = "Save_Button";
            this.Save_Button.Size = new System.Drawing.Size(125, 34);
            this.Save_Button.TabIndex = 16;
            this.Save_Button.Text = "保存(&S)";
            this.Save_Button.Click += new System.EventHandler(this.Save_Button_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStrip1.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(444, 25);
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
            // ToolBar_panel
            // 
            this.ToolBar_panel.Controls.Add(this.toolStrip1);
            this.ToolBar_panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.ToolBar_panel.Location = new System.Drawing.Point(0, 0);
            this.ToolBar_panel.Name = "ToolBar_panel";
            this.ToolBar_panel.Size = new System.Drawing.Size(444, 25);
            this.ToolBar_panel.TabIndex = 19;
            // 
            // Annotation_panel
            // 
            this.Annotation_panel.Controls.Add(this.label1);
            this.Annotation_panel.Controls.Add(this.label2);
            this.Annotation_panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.Annotation_panel.Location = new System.Drawing.Point(0, 64);
            this.Annotation_panel.Name = "Annotation_panel";
            this.Annotation_panel.Size = new System.Drawing.Size(444, 51);
            this.Annotation_panel.TabIndex = 4;
            // 
            // Search_panel
            // 
            this.Search_panel.Controls.Add(this.ImageName_TextBox);
            this.Search_panel.Controls.Add(this.label3);
            this.Search_panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.Search_panel.Location = new System.Drawing.Point(0, 115);
            this.Search_panel.Name = "Search_panel";
            this.Search_panel.Size = new System.Drawing.Size(444, 36);
            this.Search_panel.TabIndex = 7;
            this.Search_panel.Visible = false;
            // 
            // ImageName_TextBox
            // 
            this.ImageName_TextBox.Location = new System.Drawing.Point(91, 7);
            this.ImageName_TextBox.MaxLength = 256;
            this.ImageName_TextBox.Name = "ImageName_TextBox";
            this.ImageName_TextBox.Size = new System.Drawing.Size(329, 22);
            this.ImageName_TextBox.TabIndex = 9;
            this.ImageName_TextBox.TextChanged += new System.EventHandler(this.ImageName_TextBox_TextChanged);
            this.ImageName_TextBox.Leave += new System.EventHandler(this.ImageName_TextBox_Leave);
            this.ImageName_TextBox.Enter += new System.EventHandler(this.ImageName_TextBox_Enter);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(13, 3);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 28);
            this.label3.TabIndex = 8;
            this.label3.Text = "名称";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            // GoodsImageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 712);
            this.Controls.Add(this.GoodsImage_Grid);
            this.Controls.Add(this.tool_panel);
            this.Controls.Add(this.Search_panel);
            this.Controls.Add(this.Annotation_panel);
            this.Controls.Add(this.Top_panel);
            this.Controls.Add(this.ToolBar_panel);
            this.Controls.Add(this.Buttom_panel);
            this.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GoodsImageForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "商品画像設定";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GoodsImageForm_FormClosing);
            this.Top_panel.ResumeLayout(false);
            this.Top_panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Category_ComboEditor)).EndInit();
            this.tool_panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GoodsImage_Grid)).EndInit();
            this.Buttom_panel.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ToolBar_panel.ResumeLayout(false);
            this.ToolBar_panel.PerformLayout();
            this.Annotation_panel.ResumeLayout(false);
            this.Search_panel.ResumeLayout(false);
            this.Search_panel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel Top_panel;
        private System.Windows.Forms.Label Category_label;
        private System.Windows.Forms.Panel tool_panel;
        private Infragistics.Win.Misc.UltraButton ImportImage_Button;
        private Infragistics.Win.Misc.UltraButton DelRow_Button;
        private Infragistics.Win.Misc.UltraButton AddRow_ultraButton;
        private Infragistics.Win.UltraWinGrid.UltraGrid GoodsImage_Grid;
        private System.Windows.Forms.Panel Buttom_panel;
        private Infragistics.Win.Misc.UltraButton Cancel_Button;
        private Infragistics.Win.Misc.UltraButton Save_Button;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.Panel ToolBar_panel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel Annotation_panel;
        private System.Windows.Forms.Panel Search_panel;
        private System.Windows.Forms.TextBox ImageName_TextBox;
        private System.Windows.Forms.Label label3;
        private Broadleaf.Library.Windows.Forms.TRetKeyControl tRetKeyControl1;
        private Broadleaf.Library.Windows.Forms.TArrowKeyControl tArrowKeyControl1;
        private Broadleaf.Library.Windows.Forms.TComboEditor Category_ComboEditor;
    }
}
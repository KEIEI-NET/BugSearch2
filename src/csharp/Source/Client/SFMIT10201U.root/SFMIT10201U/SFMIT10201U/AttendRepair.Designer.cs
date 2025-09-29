namespace Broadleaf.Windows.Forms
{
    partial class AttendRepairSetForm
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
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            this.label1 = new System.Windows.Forms.Label();
            this.Top_panel = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.Category_ComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.Middle_panel = new System.Windows.Forms.Panel();
            this.AttendRepair_Grid = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.Buttom_panel = new System.Windows.Forms.Panel();
            this.Cancel_Button = new Infragistics.Win.Misc.UltraButton();
            this.Save_Button = new Infragistics.Win.Misc.UltraButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.DelRow_Button = new Infragistics.Win.Misc.UltraButton();
            this.AddRow_ultraButton = new Infragistics.Win.Misc.UltraButton();
            this.tRetKeyControl1 = new Broadleaf.Library.Windows.Forms.TRetKeyControl(this.components);
            this.tArrowKeyControl1 = new Broadleaf.Library.Windows.Forms.TArrowKeyControl(this.components);
            this.Top_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Category_ComboEditor)).BeginInit();
            this.Middle_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AttendRepair_Grid)).BeginInit();
            this.Buttom_panel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 30);
            this.label1.TabIndex = 2;
            this.label1.Text = "商品カテゴリ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Top_panel
            // 
            this.Top_panel.Controls.Add(this.label2);
            this.Top_panel.Controls.Add(this.Category_ComboEditor);
            this.Top_panel.Controls.Add(this.label1);
            this.Top_panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.Top_panel.Location = new System.Drawing.Point(0, 0);
            this.Top_panel.Name = "Top_panel";
            this.Top_panel.Size = new System.Drawing.Size(644, 78);
            this.Top_panel.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(10, 44);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(579, 21);
            this.label2.TabIndex = 6;
            this.label2.Text = "商品と一緒に整備の提案を行う場合は、登録を行って下さい。";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Category_ComboEditor
            // 
            this.Category_ComboEditor.ActiveAppearance = appearance1;
            this.Category_ComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.Category_ComboEditor.Location = new System.Drawing.Point(121, 11);
            this.Category_ComboEditor.Name = "Category_ComboEditor";
            this.Category_ComboEditor.Size = new System.Drawing.Size(200, 24);
            this.Category_ComboEditor.TabIndex = 3;
            this.Category_ComboEditor.ValueChanged += new System.EventHandler(this.Category_ComboEditor_ValueChanged);
            // 
            // Middle_panel
            // 
            this.Middle_panel.Controls.Add(this.AttendRepair_Grid);
            this.Middle_panel.Controls.Add(this.Buttom_panel);
            this.Middle_panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Middle_panel.Location = new System.Drawing.Point(0, 124);
            this.Middle_panel.Name = "Middle_panel";
            this.Middle_panel.Size = new System.Drawing.Size(644, 378);
            this.Middle_panel.TabIndex = 12;
            // 
            // AttendRepair_Grid
            // 
            appearance2.FontData.Name = "ＭＳ ゴシック";
            appearance2.ForeColorDisabled = System.Drawing.Color.Black;
            this.AttendRepair_Grid.DisplayLayout.Appearance = appearance2;
            appearance3.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance3.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance3.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance3.BorderColor = System.Drawing.SystemColors.Window;
            this.AttendRepair_Grid.DisplayLayout.GroupByBox.Appearance = appearance3;
            appearance4.ForeColor = System.Drawing.SystemColors.GrayText;
            this.AttendRepair_Grid.DisplayLayout.GroupByBox.BandLabelAppearance = appearance4;
            this.AttendRepair_Grid.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.AttendRepair_Grid.DisplayLayout.GroupByBox.Hidden = true;
            appearance5.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance5.BackColor2 = System.Drawing.SystemColors.Control;
            appearance5.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance5.ForeColor = System.Drawing.SystemColors.GrayText;
            this.AttendRepair_Grid.DisplayLayout.GroupByBox.PromptAppearance = appearance5;
            appearance6.BackColor = System.Drawing.SystemColors.Window;
            appearance6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.AttendRepair_Grid.DisplayLayout.Override.ActiveCellAppearance = appearance6;
            appearance7.BackColor = System.Drawing.SystemColors.Highlight;
            appearance7.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.AttendRepair_Grid.DisplayLayout.Override.ActiveRowAppearance = appearance7;
            this.AttendRepair_Grid.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.AttendRepair_Grid.DisplayLayout.Override.BorderStyleHeader = Infragistics.Win.UIElementBorderStyle.Solid;
            this.AttendRepair_Grid.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            appearance8.BackColor = System.Drawing.SystemColors.Window;
            this.AttendRepair_Grid.DisplayLayout.Override.CardAreaAppearance = appearance8;
            appearance9.BorderColor = System.Drawing.Color.Silver;
            appearance9.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.AttendRepair_Grid.DisplayLayout.Override.CellAppearance = appearance9;
            this.AttendRepair_Grid.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.AttendRepair_Grid.DisplayLayout.Override.CellPadding = 0;
            appearance10.BackColor = System.Drawing.SystemColors.Control;
            appearance10.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance10.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance10.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance10.BorderColor = System.Drawing.SystemColors.Window;
            this.AttendRepair_Grid.DisplayLayout.Override.GroupByRowAppearance = appearance10;
            appearance11.TextHAlign = Infragistics.Win.HAlign.Left;
            this.AttendRepair_Grid.DisplayLayout.Override.HeaderAppearance = appearance11;
            this.AttendRepair_Grid.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.AttendRepair_Grid.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance12.BackColor = System.Drawing.SystemColors.Window;
            appearance12.BorderColor = System.Drawing.Color.Silver;
            this.AttendRepair_Grid.DisplayLayout.Override.RowAppearance = appearance12;
            this.AttendRepair_Grid.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(230)))), ((int)(((byte)(148)))));
            appearance13.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(149)))), ((int)(((byte)(21)))));
            appearance13.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance13.ForeColor = System.Drawing.Color.Black;
            appearance13.TextVAlign = Infragistics.Win.VAlign.Middle;
            this.AttendRepair_Grid.DisplayLayout.Override.SelectedRowAppearance = appearance13;
            this.AttendRepair_Grid.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.SingleAutoDrag;
            this.AttendRepair_Grid.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Single;
            appearance14.BackColor = System.Drawing.SystemColors.ControlLight;
            this.AttendRepair_Grid.DisplayLayout.Override.TemplateAddRowAppearance = appearance14;
            this.AttendRepair_Grid.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.AttendRepair_Grid.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.AttendRepair_Grid.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand;
            this.AttendRepair_Grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AttendRepair_Grid.Location = new System.Drawing.Point(0, 0);
            this.AttendRepair_Grid.Name = "AttendRepair_Grid";
            this.AttendRepair_Grid.Size = new System.Drawing.Size(644, 323);
            this.AttendRepair_Grid.TabIndex = 7;
            this.AttendRepair_Grid.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.AttendRepair_Grid_InitializeLayout);
            this.AttendRepair_Grid.AfterEnterEditMode += new System.EventHandler(this.AttendRepair_Grid_AfterEnterEditMode);
            this.AttendRepair_Grid.CellDataError += new Infragistics.Win.UltraWinGrid.CellDataErrorEventHandler(this.AttendRepair_Grid_CellDataError);
            this.AttendRepair_Grid.Enter += new System.EventHandler(this.AttendRepair_Grid_Enter);
            this.AttendRepair_Grid.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AttendRepair_Grid_KeyPress);
            this.AttendRepair_Grid.CellChange += new Infragistics.Win.UltraWinGrid.CellEventHandler(this.AttendRepair_Grid_CellChange);
            this.AttendRepair_Grid.AfterPerformAction += new Infragistics.Win.UltraWinGrid.AfterUltraGridPerformActionEventHandler(this.AttendRepair_Grid_AfterPerformAction);
            this.AttendRepair_Grid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AttendRepair_Grid_KeyDown);
            // 
            // Buttom_panel
            // 
            this.Buttom_panel.Controls.Add(this.Cancel_Button);
            this.Buttom_panel.Controls.Add(this.Save_Button);
            this.Buttom_panel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Buttom_panel.Location = new System.Drawing.Point(0, 323);
            this.Buttom_panel.Name = "Buttom_panel";
            this.Buttom_panel.Size = new System.Drawing.Size(644, 55);
            this.Buttom_panel.TabIndex = 8;
            // 
            // Cancel_Button
            // 
            this.Cancel_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            appearance15.ForeColor = System.Drawing.Color.Black;
            this.Cancel_Button.Appearance = appearance15;
            this.Cancel_Button.HotTracking = true;
            this.Cancel_Button.ImageSize = new System.Drawing.Size(25, 25);
            this.Cancel_Button.Location = new System.Drawing.Point(510, 9);
            this.Cancel_Button.Name = "Cancel_Button";
            this.Cancel_Button.Size = new System.Drawing.Size(125, 34);
            this.Cancel_Button.TabIndex = 10;
            this.Cancel_Button.Text = "閉じる(&X)";
            this.Cancel_Button.Click += new System.EventHandler(this.Cancel_Button_Click);
            // 
            // Save_Button
            // 
            this.Save_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            appearance16.ForeColor = System.Drawing.Color.Black;
            this.Save_Button.Appearance = appearance16;
            this.Save_Button.HotTracking = true;
            this.Save_Button.ImageSize = new System.Drawing.Size(25, 25);
            this.Save_Button.Location = new System.Drawing.Point(385, 9);
            this.Save_Button.Name = "Save_Button";
            this.Save_Button.Size = new System.Drawing.Size(125, 34);
            this.Save_Button.TabIndex = 9;
            this.Save_Button.Text = "保存(&S)";
            this.Save_Button.Click += new System.EventHandler(this.Save_Button_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.DelRow_Button);
            this.panel1.Controls.Add(this.AddRow_ultraButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 78);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(644, 46);
            this.panel1.TabIndex = 4;
            // 
            // DelRow_Button
            // 
            appearance17.ForeColor = System.Drawing.Color.Black;
            this.DelRow_Button.Appearance = appearance17;
            this.DelRow_Button.HotTracking = true;
            this.DelRow_Button.ImageSize = new System.Drawing.Size(25, 25);
            this.DelRow_Button.Location = new System.Drawing.Point(110, 6);
            this.DelRow_Button.Name = "DelRow_Button";
            this.DelRow_Button.Size = new System.Drawing.Size(105, 34);
            this.DelRow_Button.TabIndex = 6;
            this.DelRow_Button.Text = "行削除(&D)";
            this.DelRow_Button.Click += new System.EventHandler(this.DelRow_Button_Click);
            // 
            // AddRow_ultraButton
            // 
            appearance18.ForeColor = System.Drawing.Color.Black;
            this.AddRow_ultraButton.Appearance = appearance18;
            this.AddRow_ultraButton.HotTracking = true;
            this.AddRow_ultraButton.ImageSize = new System.Drawing.Size(25, 25);
            this.AddRow_ultraButton.Location = new System.Drawing.Point(12, 6);
            this.AddRow_ultraButton.Name = "AddRow_ultraButton";
            this.AddRow_ultraButton.Size = new System.Drawing.Size(98, 34);
            this.AddRow_ultraButton.TabIndex = 5;
            this.AddRow_ultraButton.Text = "行追加(&A)";
            this.AddRow_ultraButton.Click += new System.EventHandler(this.AddRow_ultraButton_Click);
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
            // AttendRepairSetForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 502);
            this.Controls.Add(this.Middle_panel);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Top_panel);
            this.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Name = "AttendRepairSetForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "整備提案設定";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AttendRepairSetForm_FormClosing);
            this.Top_panel.ResumeLayout(false);
            this.Top_panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Category_ComboEditor)).EndInit();
            this.Middle_panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.AttendRepair_Grid)).EndInit();
            this.Buttom_panel.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel Top_panel;
        private System.Windows.Forms.Panel Middle_panel;
        private System.Windows.Forms.Panel Buttom_panel;
        private Infragistics.Win.UltraWinGrid.UltraGrid AttendRepair_Grid;
        private Infragistics.Win.Misc.UltraButton Cancel_Button;
        private Infragistics.Win.Misc.UltraButton Save_Button;
        private System.Windows.Forms.Panel panel1;
        private Infragistics.Win.Misc.UltraButton DelRow_Button;
        private Infragistics.Win.Misc.UltraButton AddRow_ultraButton;
        private Broadleaf.Library.Windows.Forms.TComboEditor Category_ComboEditor;
        private Broadleaf.Library.Windows.Forms.TRetKeyControl tRetKeyControl1;
        private Broadleaf.Library.Windows.Forms.TArrowKeyControl tArrowKeyControl1;
        private System.Windows.Forms.Label label2;
    }
}
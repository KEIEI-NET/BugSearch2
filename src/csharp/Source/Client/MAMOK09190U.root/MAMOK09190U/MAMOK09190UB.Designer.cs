namespace Broadleaf.Windows.Forms
{
    partial class MAMOK09190UB
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
            Infragistics.Win.ValueListItem valueListItem1 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem2 = new Infragistics.Win.ValueListItem();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MAMOK09190UB));
            this.TargetSetCd_uOptionSet = new Infragistics.Win.UltraWinEditors.UltraOptionSet();
            this.TargetSetCd_uLabel = new Infragistics.Win.Misc.UltraLabel();
            this.ApplyEndDate_tDateEdit = new Broadleaf.Library.Windows.Forms.TDateEdit();
            this.Range_uLabel = new Infragistics.Win.Misc.UltraLabel();
            this.TargetDivideCode_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.TargetDivideCode_uLabel = new Infragistics.Win.Misc.UltraLabel();
            this.TargetDivideName_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.TargetDivideName_uLabel = new Infragistics.Win.Misc.UltraLabel();
            this.ApplyDate_uLabel = new Infragistics.Win.Misc.UltraLabel();
            this.ApplyStaDate_tDateEdit = new Broadleaf.Library.Windows.Forms.TDateEdit();
            this.SectionName_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.SectionName_uLabel = new Infragistics.Win.Misc.UltraLabel();
            this.Close_Button = new Infragistics.Win.Misc.UltraButton();
            this.Save_Button = new Infragistics.Win.Misc.UltraButton();
            this.tRetKeyControl1 = new Broadleaf.Library.Windows.Forms.TRetKeyControl(this.components);
            this.tArrowKeyControl1 = new Broadleaf.Library.Windows.Forms.TArrowKeyControl(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.TargetSetCd_uOptionSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TargetDivideCode_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TargetDivideName_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionName_tEdit)).BeginInit();
            this.SuspendLayout();
            // 
            // TargetSetCd_uOptionSet
            // 
            appearance1.BackColorDisabled = System.Drawing.Color.Transparent;
            appearance1.ForeColorDisabled = System.Drawing.Color.Black;
            this.TargetSetCd_uOptionSet.Appearance = appearance1;
            this.TargetSetCd_uOptionSet.BackColor = System.Drawing.Color.Transparent;
            this.TargetSetCd_uOptionSet.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            this.TargetSetCd_uOptionSet.CheckedIndex = 1;
            this.TargetSetCd_uOptionSet.Enabled = false;
            appearance2.ForeColorDisabled = System.Drawing.Color.Black;
            this.TargetSetCd_uOptionSet.ItemAppearance = appearance2;
            valueListItem1.DataValue = 10;
            valueListItem1.DisplayText = "月間";
            valueListItem2.DataValue = 20;
            valueListItem2.DisplayText = "個別";
            this.TargetSetCd_uOptionSet.Items.Add(valueListItem1);
            this.TargetSetCd_uOptionSet.Items.Add(valueListItem2);
            this.TargetSetCd_uOptionSet.Location = new System.Drawing.Point(134, 45);
            this.TargetSetCd_uOptionSet.Name = "TargetSetCd_uOptionSet";
            this.TargetSetCd_uOptionSet.Size = new System.Drawing.Size(114, 23);
            this.TargetSetCd_uOptionSet.TabIndex = 510;
            this.TargetSetCd_uOptionSet.Text = "個別";
            // 
            // TargetSetCd_uLabel
            // 
            this.TargetSetCd_uLabel.Location = new System.Drawing.Point(12, 45);
            this.TargetSetCd_uLabel.Name = "TargetSetCd_uLabel";
            this.TargetSetCd_uLabel.Size = new System.Drawing.Size(98, 17);
            this.TargetSetCd_uLabel.TabIndex = 509;
            this.TargetSetCd_uLabel.Text = "目標設定区分";
            // 
            // ApplyEndDate_tDateEdit
            // 
            appearance3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.ApplyEndDate_tDateEdit.ActiveEditAppearance = appearance3;
            this.ApplyEndDate_tDateEdit.BackColor = System.Drawing.Color.Transparent;
            this.ApplyEndDate_tDateEdit.CalendarDisp = true;
            appearance4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance4.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance4.ForeColor = System.Drawing.Color.Black;
            appearance4.ForeColorDisabled = System.Drawing.Color.Black;
            appearance4.TextHAlign = Infragistics.Win.HAlign.Left;
            appearance4.TextVAlign = Infragistics.Win.VAlign.Middle;
            this.ApplyEndDate_tDateEdit.EditAppearance = appearance4;
            this.ApplyEndDate_tDateEdit.EnableEditors = new Broadleaf.Library.Windows.Forms.TEnableEditors(true, true, true, true);
            this.ApplyEndDate_tDateEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            appearance5.TextHAlign = Infragistics.Win.HAlign.Left;
            appearance5.TextVAlign = Infragistics.Win.VAlign.Middle;
            this.ApplyEndDate_tDateEdit.LabelAppearance = appearance5;
            this.ApplyEndDate_tDateEdit.Location = new System.Drawing.Point(343, 75);
            this.ApplyEndDate_tDateEdit.Name = "ApplyEndDate_tDateEdit";
            this.ApplyEndDate_tDateEdit.NecessaryEditors = new Broadleaf.Library.Windows.Forms.TNecessaryEditors(false, false, false, false);
            this.ApplyEndDate_tDateEdit.Options = new Broadleaf.Library.Windows.Forms.TDateEditOptions(false, false, false, true, false, true);
            this.ApplyEndDate_tDateEdit.Size = new System.Drawing.Size(176, 24);
            this.ApplyEndDate_tDateEdit.TabIndex = 1;
            this.ApplyEndDate_tDateEdit.TabStop = true;
            // 
            // Range_uLabel
            // 
            this.Range_uLabel.Location = new System.Drawing.Point(316, 79);
            this.Range_uLabel.Name = "Range_uLabel";
            this.Range_uLabel.Size = new System.Drawing.Size(21, 17);
            this.Range_uLabel.TabIndex = 508;
            this.Range_uLabel.Text = "～";
            // 
            // TargetDivideCode_tEdit
            // 
            appearance6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.TargetDivideCode_tEdit.ActiveAppearance = appearance6;
            appearance7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance7.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance7.ForeColor = System.Drawing.Color.Black;
            appearance7.ForeColorDisabled = System.Drawing.Color.Black;
            appearance7.TextHAlign = Infragistics.Win.HAlign.Left;
            appearance7.TextVAlign = Infragistics.Win.VAlign.Middle;
            this.TargetDivideCode_tEdit.Appearance = appearance7;
            this.TargetDivideCode_tEdit.AutoSelect = true;
            this.TargetDivideCode_tEdit.DataText = "";
            this.TargetDivideCode_tEdit.Enabled = false;
            this.TargetDivideCode_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.TargetDivideCode_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 12, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, true, true, true, true));
            this.TargetDivideCode_tEdit.Location = new System.Drawing.Point(134, 109);
            this.TargetDivideCode_tEdit.MaxLength = 12;
            this.TargetDivideCode_tEdit.Name = "TargetDivideCode_tEdit";
            this.TargetDivideCode_tEdit.Size = new System.Drawing.Size(66, 24);
            this.TargetDivideCode_tEdit.TabIndex = 502;
            // 
            // TargetDivideCode_uLabel
            // 
            this.TargetDivideCode_uLabel.Location = new System.Drawing.Point(12, 113);
            this.TargetDivideCode_uLabel.Name = "TargetDivideCode_uLabel";
            this.TargetDivideCode_uLabel.Size = new System.Drawing.Size(114, 17);
            this.TargetDivideCode_uLabel.TabIndex = 507;
            this.TargetDivideCode_uLabel.Text = "目標区分コード";
            // 
            // TargetDivideName_tEdit
            // 
            appearance8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.TargetDivideName_tEdit.ActiveAppearance = appearance8;
            appearance9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance9.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance9.ForeColor = System.Drawing.Color.Black;
            appearance9.ForeColorDisabled = System.Drawing.Color.Black;
            appearance9.TextHAlign = Infragistics.Win.HAlign.Left;
            appearance9.TextVAlign = Infragistics.Win.VAlign.Middle;
            this.TargetDivideName_tEdit.Appearance = appearance9;
            this.TargetDivideName_tEdit.AutoSelect = true;
            this.TargetDivideName_tEdit.DataText = "";
            this.TargetDivideName_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.TargetDivideName_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 12, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, true, true, true, true));
            this.TargetDivideName_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.TargetDivideName_tEdit.Location = new System.Drawing.Point(134, 143);
            this.TargetDivideName_tEdit.MaxLength = 12;
            this.TargetDivideName_tEdit.Name = "TargetDivideName_tEdit";
            this.TargetDivideName_tEdit.Size = new System.Drawing.Size(268, 24);
            this.TargetDivideName_tEdit.TabIndex = 2;
            // 
            // TargetDivideName_uLabel
            // 
            this.TargetDivideName_uLabel.Location = new System.Drawing.Point(12, 147);
            this.TargetDivideName_uLabel.Name = "TargetDivideName_uLabel";
            this.TargetDivideName_uLabel.Size = new System.Drawing.Size(98, 17);
            this.TargetDivideName_uLabel.TabIndex = 506;
            this.TargetDivideName_uLabel.Text = "目標区分名称";
            // 
            // ApplyDate_uLabel
            // 
            this.ApplyDate_uLabel.Location = new System.Drawing.Point(12, 79);
            this.ApplyDate_uLabel.Name = "ApplyDate_uLabel";
            this.ApplyDate_uLabel.Size = new System.Drawing.Size(67, 17);
            this.ApplyDate_uLabel.TabIndex = 505;
            this.ApplyDate_uLabel.Text = "適用期間";
            // 
            // ApplyStaDate_tDateEdit
            // 
            appearance10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.ApplyStaDate_tDateEdit.ActiveEditAppearance = appearance10;
            this.ApplyStaDate_tDateEdit.BackColor = System.Drawing.Color.Transparent;
            this.ApplyStaDate_tDateEdit.CalendarDisp = true;
            appearance11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance11.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance11.ForeColor = System.Drawing.Color.Black;
            appearance11.ForeColorDisabled = System.Drawing.Color.Black;
            appearance11.TextHAlign = Infragistics.Win.HAlign.Left;
            appearance11.TextVAlign = Infragistics.Win.VAlign.Middle;
            this.ApplyStaDate_tDateEdit.EditAppearance = appearance11;
            this.ApplyStaDate_tDateEdit.EnableEditors = new Broadleaf.Library.Windows.Forms.TEnableEditors(true, true, true, true);
            this.ApplyStaDate_tDateEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            appearance12.TextHAlign = Infragistics.Win.HAlign.Left;
            appearance12.TextVAlign = Infragistics.Win.VAlign.Middle;
            this.ApplyStaDate_tDateEdit.LabelAppearance = appearance12;
            this.ApplyStaDate_tDateEdit.Location = new System.Drawing.Point(134, 75);
            this.ApplyStaDate_tDateEdit.Name = "ApplyStaDate_tDateEdit";
            this.ApplyStaDate_tDateEdit.NecessaryEditors = new Broadleaf.Library.Windows.Forms.TNecessaryEditors(false, false, false, false);
            this.ApplyStaDate_tDateEdit.Options = new Broadleaf.Library.Windows.Forms.TDateEditOptions(false, false, false, true, false, true);
            this.ApplyStaDate_tDateEdit.Size = new System.Drawing.Size(176, 24);
            this.ApplyStaDate_tDateEdit.TabIndex = 0;
            this.ApplyStaDate_tDateEdit.TabStop = true;
            // 
            // SectionName_tEdit
            // 
            this.SectionName_tEdit.ActiveAppearance = appearance13;
            appearance14.ForeColorDisabled = System.Drawing.Color.Black;
            appearance14.TextHAlign = Infragistics.Win.HAlign.Left;
            appearance14.TextVAlign = Infragistics.Win.VAlign.Middle;
            this.SectionName_tEdit.Appearance = appearance14;
            this.SectionName_tEdit.AutoSelect = true;
            this.SectionName_tEdit.DataText = "";
            this.SectionName_tEdit.Enabled = false;
            this.SectionName_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.SectionName_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 12, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, true, true, true, true));
            this.SectionName_tEdit.Location = new System.Drawing.Point(134, 10);
            this.SectionName_tEdit.MaxLength = 12;
            this.SectionName_tEdit.Name = "SectionName_tEdit";
            this.SectionName_tEdit.Size = new System.Drawing.Size(159, 24);
            this.SectionName_tEdit.TabIndex = 499;
            // 
            // SectionName_uLabel
            // 
            this.SectionName_uLabel.Location = new System.Drawing.Point(12, 14);
            this.SectionName_uLabel.Name = "SectionName_uLabel";
            this.SectionName_uLabel.Size = new System.Drawing.Size(36, 17);
            this.SectionName_uLabel.TabIndex = 504;
            this.SectionName_uLabel.Text = "拠点";
            // 
            // Close_Button
            // 
            this.Close_Button.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.Close_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Close_Button.Location = new System.Drawing.Point(407, 220);
            this.Close_Button.Name = "Close_Button";
            this.Close_Button.Size = new System.Drawing.Size(110, 35);
            this.Close_Button.TabIndex = 4;
            this.Close_Button.Text = "閉じる(&X)";
            this.Close_Button.Click += new System.EventHandler(this.Close_Button_Click);
            // 
            // Save_Button
            // 
            this.Save_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Save_Button.Location = new System.Drawing.Point(292, 220);
            this.Save_Button.Name = "Save_Button";
            this.Save_Button.Size = new System.Drawing.Size(110, 35);
            this.Save_Button.TabIndex = 3;
            this.Save_Button.Text = "保存(&S)";
            this.Save_Button.Click += new System.EventHandler(this.Save_Button_Click);
            // 
            // tRetKeyControl1
            // 
            this.tRetKeyControl1.OwnerForm = this;
            this.tRetKeyControl1.Style = Broadleaf.Library.Windows.Forms.emFocusStyle.ByTab;
            // 
            // tArrowKeyControl1
            // 
            this.tArrowKeyControl1.OwnerForm = this;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(529, 264);
            this.panel1.TabIndex = 511;
            // 
            // MAMOK09190UB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(529, 264);
            this.Controls.Add(this.TargetSetCd_uOptionSet);
            this.Controls.Add(this.Close_Button);
            this.Controls.Add(this.Save_Button);
            this.Controls.Add(this.TargetSetCd_uLabel);
            this.Controls.Add(this.ApplyEndDate_tDateEdit);
            this.Controls.Add(this.Range_uLabel);
            this.Controls.Add(this.TargetDivideCode_tEdit);
            this.Controls.Add(this.TargetDivideCode_uLabel);
            this.Controls.Add(this.TargetDivideName_tEdit);
            this.Controls.Add(this.TargetDivideName_uLabel);
            this.Controls.Add(this.ApplyDate_uLabel);
            this.Controls.Add(this.ApplyStaDate_tDateEdit);
            this.Controls.Add(this.SectionName_tEdit);
            this.Controls.Add(this.SectionName_uLabel);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MAMOK09190UB";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "個別目標編集";
            this.Load += new System.EventHandler(this.MAMOK09190UB_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TargetSetCd_uOptionSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TargetDivideCode_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TargetDivideName_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionName_tEdit)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Infragistics.Win.UltraWinEditors.UltraOptionSet TargetSetCd_uOptionSet;
        private Infragistics.Win.Misc.UltraLabel TargetSetCd_uLabel;
        private Broadleaf.Library.Windows.Forms.TDateEdit ApplyEndDate_tDateEdit;
        private Infragistics.Win.Misc.UltraLabel Range_uLabel;
        private Broadleaf.Library.Windows.Forms.TEdit TargetDivideCode_tEdit;
        private Infragistics.Win.Misc.UltraLabel TargetDivideCode_uLabel;
        private Broadleaf.Library.Windows.Forms.TEdit TargetDivideName_tEdit;
        private Infragistics.Win.Misc.UltraLabel TargetDivideName_uLabel;
        private Infragistics.Win.Misc.UltraLabel ApplyDate_uLabel;
        private Broadleaf.Library.Windows.Forms.TDateEdit ApplyStaDate_tDateEdit;
        private Broadleaf.Library.Windows.Forms.TEdit SectionName_tEdit;
        private Infragistics.Win.Misc.UltraLabel SectionName_uLabel;
        private Infragistics.Win.Misc.UltraButton Close_Button;
        private Infragistics.Win.Misc.UltraButton Save_Button;
        private Broadleaf.Library.Windows.Forms.TRetKeyControl tRetKeyControl1;
        private Broadleaf.Library.Windows.Forms.TArrowKeyControl tArrowKeyControl1;
        private System.Windows.Forms.Panel panel1;
    }
}
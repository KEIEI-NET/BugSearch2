namespace Broadleaf.Windows.Forms
{
    partial class CalcPriceForm
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
            Infragistics.Win.ValueListItem valueListItem1 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem2 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem3 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem4 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem5 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem6 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem7 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem8 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem9 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem10 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem11 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem12 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem13 = new Infragistics.Win.ValueListItem();
            this.Cancel_Button = new Infragistics.Win.Misc.UltraButton();
            this.Save_Button = new Infragistics.Win.Misc.UltraButton();
            this.SFTITLE_panel = new System.Windows.Forms.Panel();
            this.SF_CheckEditor = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.SFModeTitle_Lable = new System.Windows.Forms.Label();
            this.SFCALC_panel = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.SF_TARGET_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.label2 = new System.Windows.Forms.Label();
            this.SF_TARGET_ComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.PMTITLE_panel = new System.Windows.Forms.Panel();
            this.PM_CheckEditor = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.PMCALC_panel = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.PM_TARGET_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.label5 = new System.Windows.Forms.Label();
            this.PM_TARGET_ComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.panel5 = new System.Windows.Forms.Panel();
            this.Digit_ComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.label1 = new System.Windows.Forms.Label();
            this.CalcDiv_CheckEditor = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.tRetKeyControl1 = new Broadleaf.Library.Windows.Forms.TRetKeyControl(this.components);
            this.tArrowKeyControl1 = new Broadleaf.Library.Windows.Forms.TArrowKeyControl(this.components);
            this.SFTITLE_panel.SuspendLayout();
            this.SFCALC_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SF_TARGET_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SF_TARGET_ComboEditor)).BeginInit();
            this.PMTITLE_panel.SuspendLayout();
            this.PMCALC_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PM_TARGET_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PM_TARGET_ComboEditor)).BeginInit();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Digit_ComboEditor)).BeginInit();
            this.SuspendLayout();
            // 
            // Cancel_Button
            // 
            this.Cancel_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            appearance1.ForeColor = System.Drawing.Color.Black;
            this.Cancel_Button.Appearance = appearance1;
            this.Cancel_Button.HotTracking = true;
            this.Cancel_Button.ImageSize = new System.Drawing.Size(25, 25);
            this.Cancel_Button.Location = new System.Drawing.Point(377, 75);
            this.Cancel_Button.Name = "Cancel_Button";
            this.Cancel_Button.Size = new System.Drawing.Size(100, 34);
            this.Cancel_Button.TabIndex = 16;
            this.Cancel_Button.Text = "閉じる(&X)";
            this.Cancel_Button.Click += new System.EventHandler(this.Cancel_Button_Click);
            // 
            // Save_Button
            // 
            this.Save_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            appearance2.ForeColor = System.Drawing.Color.Black;
            this.Save_Button.Appearance = appearance2;
            this.Save_Button.HotTracking = true;
            this.Save_Button.ImageSize = new System.Drawing.Size(25, 25);
            this.Save_Button.Location = new System.Drawing.Point(276, 75);
            this.Save_Button.Name = "Save_Button";
            this.Save_Button.Size = new System.Drawing.Size(100, 34);
            this.Save_Button.TabIndex = 15;
            this.Save_Button.Text = "実行(&S)";
            this.Save_Button.Click += new System.EventHandler(this.Save_Button_Click);
            // 
            // SFTITLE_panel
            // 
            this.SFTITLE_panel.Controls.Add(this.SF_CheckEditor);
            this.SFTITLE_panel.Controls.Add(this.SFModeTitle_Lable);
            this.SFTITLE_panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.SFTITLE_panel.Location = new System.Drawing.Point(0, 80);
            this.SFTITLE_panel.Name = "SFTITLE_panel";
            this.SFTITLE_panel.Size = new System.Drawing.Size(484, 40);
            this.SFTITLE_panel.TabIndex = 6;
            // 
            // SF_CheckEditor
            // 
            this.SF_CheckEditor.Checked = true;
            this.SF_CheckEditor.CheckState = System.Windows.Forms.CheckState.Checked;
            this.SF_CheckEditor.Location = new System.Drawing.Point(12, 12);
            this.SF_CheckEditor.Name = "SF_CheckEditor";
            this.SF_CheckEditor.Size = new System.Drawing.Size(304, 20);
            this.SF_CheckEditor.TabIndex = 7;
            this.SF_CheckEditor.Text = "整備工場の店頭価格を計算します";
            this.SF_CheckEditor.CheckedChanged += new System.EventHandler(this.SF_CheckEditor_CheckedChanged);
            // 
            // SFModeTitle_Lable
            // 
            this.SFModeTitle_Lable.Location = new System.Drawing.Point(13, 12);
            this.SFModeTitle_Lable.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.SFModeTitle_Lable.Name = "SFModeTitle_Lable";
            this.SFModeTitle_Lable.Size = new System.Drawing.Size(294, 21);
            this.SFModeTitle_Lable.TabIndex = 18;
            this.SFModeTitle_Lable.Text = "店頭価格の計算をします";
            this.SFModeTitle_Lable.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // SFCALC_panel
            // 
            this.SFCALC_panel.Controls.Add(this.label3);
            this.SFCALC_panel.Controls.Add(this.SF_TARGET_tNedit);
            this.SFCALC_panel.Controls.Add(this.label2);
            this.SFCALC_panel.Controls.Add(this.SF_TARGET_ComboEditor);
            this.SFCALC_panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.SFCALC_panel.Location = new System.Drawing.Point(0, 120);
            this.SFCALC_panel.Name = "SFCALC_panel";
            this.SFCALC_panel.Size = new System.Drawing.Size(484, 40);
            this.SFCALC_panel.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(255, 10);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(129, 21);
            this.label3.TabIndex = 8;
            this.label3.Text = "％の金額を設定";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // SF_TARGET_tNedit
            // 
            this.SF_TARGET_tNedit.ActiveAppearance = appearance3;
            appearance4.TextHAlign = Infragistics.Win.HAlign.Right;
            this.SF_TARGET_tNedit.Appearance = appearance4;
            this.SF_TARGET_tNedit.AutoSelect = true;
            this.SF_TARGET_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.SF_TARGET_tNedit.DataText = "";
            this.SF_TARGET_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.SF_TARGET_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 3, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.SF_TARGET_tNedit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.SF_TARGET_tNedit.Location = new System.Drawing.Point(204, 7);
            this.SF_TARGET_tNedit.MaxLength = 3;
            this.SF_TARGET_tNedit.Name = "SF_TARGET_tNedit";
            this.SF_TARGET_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.SF_TARGET_tNedit.Size = new System.Drawing.Size(36, 24);
            this.SF_TARGET_tNedit.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(173, 10);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 21);
            this.label2.TabIndex = 6;
            this.label2.Text = "の";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // SF_TARGET_ComboEditor
            // 
            this.SF_TARGET_ComboEditor.ActiveAppearance = appearance5;
            this.SF_TARGET_ComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.SF_TARGET_ComboEditor.Location = new System.Drawing.Point(16, 7);
            this.SF_TARGET_ComboEditor.Name = "SF_TARGET_ComboEditor";
            this.SF_TARGET_ComboEditor.Size = new System.Drawing.Size(148, 24);
            this.SF_TARGET_ComboEditor.TabIndex = 9;
            // 
            // PMTITLE_panel
            // 
            this.PMTITLE_panel.Controls.Add(this.PM_CheckEditor);
            this.PMTITLE_panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.PMTITLE_panel.Location = new System.Drawing.Point(0, 0);
            this.PMTITLE_panel.Name = "PMTITLE_panel";
            this.PMTITLE_panel.Size = new System.Drawing.Size(484, 40);
            this.PMTITLE_panel.TabIndex = 1;
            // 
            // PM_CheckEditor
            // 
            this.PM_CheckEditor.Checked = true;
            this.PM_CheckEditor.CheckState = System.Windows.Forms.CheckState.Checked;
            this.PM_CheckEditor.Location = new System.Drawing.Point(12, 12);
            this.PM_CheckEditor.Name = "PM_CheckEditor";
            this.PM_CheckEditor.Size = new System.Drawing.Size(304, 20);
            this.PM_CheckEditor.TabIndex = 2;
            this.PM_CheckEditor.Text = "部品商の売価を計算します";
            this.PM_CheckEditor.CheckedChanged += new System.EventHandler(this.PM_CheckEditor_CheckedChanged);
            // 
            // PMCALC_panel
            // 
            this.PMCALC_panel.Controls.Add(this.label6);
            this.PMCALC_panel.Controls.Add(this.PM_TARGET_tNedit);
            this.PMCALC_panel.Controls.Add(this.label5);
            this.PMCALC_panel.Controls.Add(this.PM_TARGET_ComboEditor);
            this.PMCALC_panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.PMCALC_panel.Location = new System.Drawing.Point(0, 40);
            this.PMCALC_panel.Name = "PMCALC_panel";
            this.PMCALC_panel.Size = new System.Drawing.Size(484, 40);
            this.PMCALC_panel.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(255, 10);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(129, 21);
            this.label6.TabIndex = 9;
            this.label6.Text = "％の金額を設定";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // PM_TARGET_tNedit
            // 
            this.PM_TARGET_tNedit.ActiveAppearance = appearance6;
            appearance7.TextHAlign = Infragistics.Win.HAlign.Right;
            this.PM_TARGET_tNedit.Appearance = appearance7;
            this.PM_TARGET_tNedit.AutoSelect = true;
            this.PM_TARGET_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.PM_TARGET_tNedit.DataText = "";
            this.PM_TARGET_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.PM_TARGET_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 3, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.PM_TARGET_tNedit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.PM_TARGET_tNedit.Location = new System.Drawing.Point(204, 7);
            this.PM_TARGET_tNedit.MaxLength = 3;
            this.PM_TARGET_tNedit.Name = "PM_TARGET_tNedit";
            this.PM_TARGET_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.PM_TARGET_tNedit.Size = new System.Drawing.Size(36, 24);
            this.PM_TARGET_tNedit.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(173, 10);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(27, 21);
            this.label5.TabIndex = 7;
            this.label5.Text = "の";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // PM_TARGET_ComboEditor
            // 
            this.PM_TARGET_ComboEditor.ActiveAppearance = appearance8;
            this.PM_TARGET_ComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.PM_TARGET_ComboEditor.Location = new System.Drawing.Point(16, 7);
            this.PM_TARGET_ComboEditor.Name = "PM_TARGET_ComboEditor";
            this.PM_TARGET_ComboEditor.Size = new System.Drawing.Size(148, 24);
            this.PM_TARGET_ComboEditor.TabIndex = 4;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.Digit_ComboEditor);
            this.panel5.Controls.Add(this.label1);
            this.panel5.Controls.Add(this.CalcDiv_CheckEditor);
            this.panel5.Controls.Add(this.Save_Button);
            this.panel5.Controls.Add(this.Cancel_Button);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 160);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(484, 116);
            this.panel5.TabIndex = 11;
            // 
            // Digit_ComboEditor
            // 
            this.Digit_ComboEditor.ActiveAppearance = appearance9;
            this.Digit_ComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            valueListItem1.DataValue = "0";
            valueListItem1.DisplayText = "処理しない";
            valueListItem2.DataValue = "11";
            valueListItem2.DisplayText = "下一桁切り捨て";
            valueListItem3.DataValue = "12";
            valueListItem3.DisplayText = "下一桁四捨五入";
            valueListItem4.DataValue = "13";
            valueListItem4.DisplayText = "下一桁切り上げ";
            valueListItem5.DataValue = "21";
            valueListItem5.DisplayText = "下二桁切り捨て";
            valueListItem6.DataValue = "22";
            valueListItem6.DisplayText = "下二桁四捨五入";
            valueListItem7.DataValue = "23";
            valueListItem7.DisplayText = "下二桁切り上げ";
            valueListItem8.DataValue = "31";
            valueListItem8.DisplayText = "下三桁切り捨て";
            valueListItem9.DataValue = "32";
            valueListItem9.DisplayText = "下三桁四捨五入";
            valueListItem10.DataValue = "33";
            valueListItem10.DisplayText = "下三桁切り上げ";
            valueListItem11.DataValue = "-11";
            valueListItem11.DisplayText = "円未満切り捨て";
            valueListItem12.DataValue = "-12";
            valueListItem12.DisplayText = "円未満四捨五入";
            valueListItem13.DataValue = "-13";
            valueListItem13.DisplayText = "円未満切り上げ";
            this.Digit_ComboEditor.Items.Add(valueListItem1);
            this.Digit_ComboEditor.Items.Add(valueListItem2);
            this.Digit_ComboEditor.Items.Add(valueListItem3);
            this.Digit_ComboEditor.Items.Add(valueListItem4);
            this.Digit_ComboEditor.Items.Add(valueListItem5);
            this.Digit_ComboEditor.Items.Add(valueListItem6);
            this.Digit_ComboEditor.Items.Add(valueListItem7);
            this.Digit_ComboEditor.Items.Add(valueListItem8);
            this.Digit_ComboEditor.Items.Add(valueListItem9);
            this.Digit_ComboEditor.Items.Add(valueListItem10);
            this.Digit_ComboEditor.Items.Add(valueListItem11);
            this.Digit_ComboEditor.Items.Add(valueListItem12);
            this.Digit_ComboEditor.Items.Add(valueListItem13);
            this.Digit_ComboEditor.Location = new System.Drawing.Point(96, 10);
            this.Digit_ComboEditor.Name = "Digit_ComboEditor";
            this.Digit_ComboEditor.Size = new System.Drawing.Size(181, 24);
            this.Digit_ComboEditor.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(10, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 21);
            this.label1.TabIndex = 12;
            this.label1.Text = "端数処理";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CalcDiv_CheckEditor
            // 
            this.CalcDiv_CheckEditor.Checked = true;
            this.CalcDiv_CheckEditor.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CalcDiv_CheckEditor.Location = new System.Drawing.Point(12, 42);
            this.CalcDiv_CheckEditor.Name = "CalcDiv_CheckEditor";
            this.CalcDiv_CheckEditor.Size = new System.Drawing.Size(275, 20);
            this.CalcDiv_CheckEditor.TabIndex = 14;
            this.CalcDiv_CheckEditor.Text = "金額が未設定の商品のみ対象とする";
            this.CalcDiv_CheckEditor.CheckedChanged += new System.EventHandler(this.CalcDiv_CheckEditor_CheckedChanged);
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
            // CalcPriceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 276);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.SFCALC_panel);
            this.Controls.Add(this.SFTITLE_panel);
            this.Controls.Add(this.PMCALC_panel);
            this.Controls.Add(this.PMTITLE_panel);
            this.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CalcPriceForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "金額一括計算";
            this.SFTITLE_panel.ResumeLayout(false);
            this.SFCALC_panel.ResumeLayout(false);
            this.SFCALC_panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SF_TARGET_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SF_TARGET_ComboEditor)).EndInit();
            this.PMTITLE_panel.ResumeLayout(false);
            this.PMCALC_panel.ResumeLayout(false);
            this.PMCALC_panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PM_TARGET_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PM_TARGET_ComboEditor)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Digit_ComboEditor)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.Misc.UltraButton Cancel_Button;
        private Infragistics.Win.Misc.UltraButton Save_Button;
        private System.Windows.Forms.Panel SFTITLE_panel;
        private Infragistics.Win.UltraWinEditors.UltraCheckEditor SF_CheckEditor;
        private System.Windows.Forms.Panel SFCALC_panel;
        private System.Windows.Forms.Panel PMTITLE_panel;
        private Infragistics.Win.UltraWinEditors.UltraCheckEditor PM_CheckEditor;
        private System.Windows.Forms.Panel PMCALC_panel;
        private System.Windows.Forms.Panel panel5;
        private Broadleaf.Library.Windows.Forms.TComboEditor SF_TARGET_ComboEditor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private Broadleaf.Library.Windows.Forms.TNedit SF_TARGET_tNedit;
        private System.Windows.Forms.Label label6;
        private Broadleaf.Library.Windows.Forms.TNedit PM_TARGET_tNedit;
        private System.Windows.Forms.Label label5;
        private Broadleaf.Library.Windows.Forms.TComboEditor PM_TARGET_ComboEditor;
        private Broadleaf.Library.Windows.Forms.TRetKeyControl tRetKeyControl1;
        private Broadleaf.Library.Windows.Forms.TArrowKeyControl tArrowKeyControl1;
        private System.Windows.Forms.Label SFModeTitle_Lable;
        private Infragistics.Win.UltraWinEditors.UltraCheckEditor CalcDiv_CheckEditor;
        private System.Windows.Forms.Label label1;
        private Broadleaf.Library.Windows.Forms.TComboEditor Digit_ComboEditor;
    }
}
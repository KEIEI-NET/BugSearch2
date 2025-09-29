namespace Broadleaf.Windows.Forms
{
    partial class PMKHN09930UA
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
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PMKHN09930UA));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Ok_Button = new Infragistics.Win.Misc.UltraButton();
            this.Cancel_Button = new Infragistics.Win.Misc.UltraButton();
            this.UtilityDiv_uLabel = new Infragistics.Win.Misc.UltraLabel();
            this.UtilityDiv_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.Confirmation_checkBox = new System.Windows.Forms.CheckBox();
            this.Warning_label = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.UtilityDiv_tComboEditor)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(263, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "掛率優先管理マスタを作成します。";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(263, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "作成する拠点を選択してください。";
            // 
            // Ok_Button
            // 
            this.Ok_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Ok_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Ok_Button.Location = new System.Drawing.Point(152, 147);
            this.Ok_Button.Name = "Ok_Button";
            this.Ok_Button.Size = new System.Drawing.Size(110, 34);
            this.Ok_Button.TabIndex = 36;
            this.Ok_Button.Text = "登録(&S)";
            this.Ok_Button.Click += new System.EventHandler(this.Ok_Button_Click);
            // 
            // Cancel_Button
            // 
            this.Cancel_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Cancel_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Cancel_Button.Location = new System.Drawing.Point(268, 147);
            this.Cancel_Button.Name = "Cancel_Button";
            this.Cancel_Button.Size = new System.Drawing.Size(110, 34);
            this.Cancel_Button.TabIndex = 37;
            this.Cancel_Button.Text = "終了(&X)";
            this.Cancel_Button.Click += new System.EventHandler(this.Cancel_Button_Click);
            // 
            // UtilityDiv_uLabel
            // 
            appearance1.TextVAlignAsString = "Middle";
            this.UtilityDiv_uLabel.Appearance = appearance1;
            this.UtilityDiv_uLabel.BackColorInternal = System.Drawing.Color.Transparent;
            this.UtilityDiv_uLabel.Location = new System.Drawing.Point(26, 63);
            this.UtilityDiv_uLabel.Name = "UtilityDiv_uLabel";
            this.UtilityDiv_uLabel.Size = new System.Drawing.Size(96, 24);
            this.UtilityDiv_uLabel.TabIndex = 218;
            this.UtilityDiv_uLabel.Text = "拠点";
            // 
            // UtilityDiv_tComboEditor
            // 
            appearance2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.UtilityDiv_tComboEditor.ActiveAppearance = appearance2;
            appearance3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance3.ForeColorDisabled = System.Drawing.Color.Black;
            this.UtilityDiv_tComboEditor.Appearance = appearance3;
            this.UtilityDiv_tComboEditor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.UtilityDiv_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            appearance4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.UtilityDiv_tComboEditor.ItemAppearance = appearance4;
            this.UtilityDiv_tComboEditor.Location = new System.Drawing.Point(79, 63);
            this.UtilityDiv_tComboEditor.Name = "UtilityDiv_tComboEditor";
            this.UtilityDiv_tComboEditor.Size = new System.Drawing.Size(191, 24);
            this.UtilityDiv_tComboEditor.TabIndex = 217;
            this.UtilityDiv_tComboEditor.ValueChanged += new System.EventHandler(this.UtilityDiv_tComboEditor_ValueChanged);
            // 
            // Confirmation_checkBox
            // 
            this.Confirmation_checkBox.AutoSize = true;
            this.Confirmation_checkBox.Location = new System.Drawing.Point(26, 118);
            this.Confirmation_checkBox.Name = "Confirmation_checkBox";
            this.Confirmation_checkBox.Size = new System.Drawing.Size(202, 19);
            this.Confirmation_checkBox.TabIndex = 219;
            this.Confirmation_checkBox.Text = "画面を起動して登録する";
            this.Confirmation_checkBox.UseVisualStyleBackColor = true;
            this.Confirmation_checkBox.CheckedChanged += new System.EventHandler(this.Confirmation_checkBox_CheckedChanged);
            // 
            // Warning_label
            // 
            this.Warning_label.AutoSize = true;
            this.Warning_label.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Warning_label.ForeColor = System.Drawing.Color.Red;
            this.Warning_label.Location = new System.Drawing.Point(76, 94);
            this.Warning_label.Name = "Warning_label";
            this.Warning_label.Size = new System.Drawing.Size(262, 13);
            this.Warning_label.TabIndex = 220;
            this.Warning_label.Text = "※抽出に時間がかかる場合があります";
            // 
            // PMKHN09930UA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(254)))));
            this.ClientSize = new System.Drawing.Size(390, 193);
            this.Controls.Add(this.Warning_label);
            this.Controls.Add(this.Confirmation_checkBox);
            this.Controls.Add(this.UtilityDiv_tComboEditor);
            this.Controls.Add(this.UtilityDiv_uLabel);
            this.Controls.Add(this.Cancel_Button);
            this.Controls.Add(this.Ok_Button);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "PMKHN09930UA";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "掛率優先管理マスタ自動登録";
            this.Load += new System.EventHandler(this.PMKHN09930UA_Load);
            ((System.ComponentModel.ISupportInitialize)(this.UtilityDiv_tComboEditor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private Infragistics.Win.Misc.UltraButton Ok_Button;
        private Infragistics.Win.Misc.UltraButton Cancel_Button;
        private Infragistics.Win.Misc.UltraLabel UtilityDiv_uLabel;
        private Broadleaf.Library.Windows.Forms.TComboEditor UtilityDiv_tComboEditor;
        private System.Windows.Forms.CheckBox Confirmation_checkBox;
        private System.Windows.Forms.Label Warning_label;
    }
}


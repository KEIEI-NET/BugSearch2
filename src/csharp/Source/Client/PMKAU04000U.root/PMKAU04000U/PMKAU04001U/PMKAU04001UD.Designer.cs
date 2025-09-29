namespace Broadleaf.Windows.Forms
{
    partial class PMKAU04001UD
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
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance38 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem1 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem2 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PMKAU04001UD));
            this.tComboEditor_GenKaDispDiv = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.uLabel_BalanceDiv = new Infragistics.Win.Misc.UltraLabel();
            this.uButton_Cancel = new Infragistics.Win.Misc.UltraButton();
            this.uButton_OK = new Infragistics.Win.Misc.UltraButton();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_GenKaDispDiv)).BeginInit();
            this.SuspendLayout();
            // 
            // tComboEditor_GenKaDispDiv
            // 
            appearance6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_GenKaDispDiv.ActiveAppearance = appearance6;
            appearance8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tComboEditor_GenKaDispDiv.Appearance = appearance8;
            this.tComboEditor_GenKaDispDiv.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tComboEditor_GenKaDispDiv.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.tComboEditor_GenKaDispDiv.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            appearance38.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_GenKaDispDiv.ItemAppearance = appearance38;
            valueListItem1.DataValue = 0;
            valueListItem1.DisplayText = "0：する";
            valueListItem2.DataValue = 1;
            valueListItem2.DisplayText = "1：しない";
            this.tComboEditor_GenKaDispDiv.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem1,
            valueListItem2});
            this.tComboEditor_GenKaDispDiv.Location = new System.Drawing.Point(104, 34);
            this.tComboEditor_GenKaDispDiv.Name = "tComboEditor_GenKaDispDiv";
            this.tComboEditor_GenKaDispDiv.Size = new System.Drawing.Size(164, 24);
            this.tComboEditor_GenKaDispDiv.TabIndex = 0;
            // 
            // uLabel_BalanceDiv
            // 
            appearance1.BackColorAlpha = Infragistics.Win.Alpha.Transparent;
            appearance1.TextVAlignAsString = "Middle";
            this.uLabel_BalanceDiv.Appearance = appearance1;
            this.uLabel_BalanceDiv.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uLabel_BalanceDiv.Location = new System.Drawing.Point(12, 33);
            this.uLabel_BalanceDiv.Name = "uLabel_BalanceDiv";
            this.uLabel_BalanceDiv.Size = new System.Drawing.Size(86, 25);
            this.uLabel_BalanceDiv.TabIndex = 1300;
            this.uLabel_BalanceDiv.Text = "原価を印刷";
            // 
            // uButton_Cancel
            // 
            this.uButton_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.uButton_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.uButton_Cancel.Location = new System.Drawing.Point(209, 86);
            this.uButton_Cancel.Name = "uButton_Cancel";
            this.uButton_Cancel.Size = new System.Drawing.Size(116, 34);
            this.uButton_Cancel.TabIndex = 2;
            this.uButton_Cancel.Text = "終了";
            this.uButton_Cancel.Click += new System.EventHandler(this.uButton_Cancel_Click);
            // 
            // uButton_OK
            // 
            this.uButton_OK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.uButton_OK.Location = new System.Drawing.Point(87, 86);
            this.uButton_OK.Name = "uButton_OK";
            this.uButton_OK.Size = new System.Drawing.Size(116, 34);
            this.uButton_OK.TabIndex = 1;
            this.uButton_OK.Text = "印刷";
            this.uButton_OK.Click += new System.EventHandler(this.uButton_OK_Click);
            // 
            // PMKAU04001UD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(337, 132);
            this.Controls.Add(this.uButton_Cancel);
            this.Controls.Add(this.uButton_OK);
            this.Controls.Add(this.tComboEditor_GenKaDispDiv);
            this.Controls.Add(this.uLabel_BalanceDiv);
            this.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PMKAU04001UD";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "元帳印刷";
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_GenKaDispDiv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Broadleaf.Library.Windows.Forms.TComboEditor tComboEditor_GenKaDispDiv;
        private Infragistics.Win.Misc.UltraLabel uLabel_BalanceDiv;
        private Infragistics.Win.Misc.UltraButton uButton_Cancel;
        private Infragistics.Win.Misc.UltraButton uButton_OK;
    }
}
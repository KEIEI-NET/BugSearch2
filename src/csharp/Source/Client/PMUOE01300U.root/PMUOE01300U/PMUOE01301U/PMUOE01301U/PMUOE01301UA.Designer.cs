namespace Broadleaf.Windows.Forms
{
    partial class OroshishoStockReceptionView
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

        #region コンポーネント デザイナで生成されたコード

        /// <summary> 
        /// デザイナ サポートに必要なメソッドです。このメソッドの内容を 
        /// コード エディタで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.uoeSupplierLabel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.stockingUnitLabel = new System.Windows.Forms.Label();
            this.stockingCountLabel = new System.Windows.Forms.Label();
            this.stockingTitleLabel = new System.Windows.Forms.Label();
            this.answerUnitLabel = new System.Windows.Forms.Label();
            this.answerCountLabel = new System.Windows.Forms.Label();
            this.answerTitleLabel = new System.Windows.Forms.Label();
            this.receptionUnitLabel = new System.Windows.Forms.Label();
            this.receptionCountLabel = new System.Windows.Forms.Label();
            this.receptionTitleLabel = new System.Windows.Forms.Label();
            this.uoeSupplierComboBox = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // uoeSupplierLabel
            // 
            this.uoeSupplierLabel.AutoSize = true;
            this.uoeSupplierLabel.Location = new System.Drawing.Point(100, 80);
            this.uoeSupplierLabel.Name = "uoeSupplierLabel";
            this.uoeSupplierLabel.Size = new System.Drawing.Size(41, 12);
            this.uoeSupplierLabel.TabIndex = 0;
            this.uoeSupplierLabel.Text = "発注先";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.stockingUnitLabel);
            this.panel1.Controls.Add(this.stockingCountLabel);
            this.panel1.Controls.Add(this.stockingTitleLabel);
            this.panel1.Controls.Add(this.answerUnitLabel);
            this.panel1.Controls.Add(this.answerCountLabel);
            this.panel1.Controls.Add(this.answerTitleLabel);
            this.panel1.Controls.Add(this.receptionUnitLabel);
            this.panel1.Controls.Add(this.receptionCountLabel);
            this.panel1.Controls.Add(this.receptionTitleLabel);
            this.panel1.Controls.Add(this.uoeSupplierComboBox);
            this.panel1.Controls.Add(this.uoeSupplierLabel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(911, 605);
            this.panel1.TabIndex = 1;
            // 
            // stockingUnitLabel
            // 
            this.stockingUnitLabel.AutoSize = true;
            this.stockingUnitLabel.Location = new System.Drawing.Point(430, 204);
            this.stockingUnitLabel.Name = "stockingUnitLabel";
            this.stockingUnitLabel.Size = new System.Drawing.Size(17, 12);
            this.stockingUnitLabel.TabIndex = 10;
            this.stockingUnitLabel.Text = "件";
            // 
            // stockingCountLabel
            // 
            this.stockingCountLabel.Location = new System.Drawing.Point(254, 204);
            this.stockingCountLabel.Name = "stockingCountLabel";
            this.stockingCountLabel.Size = new System.Drawing.Size(170, 12);
            this.stockingCountLabel.TabIndex = 9;
            this.stockingCountLabel.Text = "ZZZ,ZZ9";
            this.stockingCountLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // stockingTitleLabel
            // 
            this.stockingTitleLabel.Location = new System.Drawing.Point(145, 204);
            this.stockingTitleLabel.Name = "stockingTitleLabel";
            this.stockingTitleLabel.Size = new System.Drawing.Size(120, 12);
            this.stockingTitleLabel.TabIndex = 8;
            this.stockingTitleLabel.Text = "在庫仕入データ作成";
            // 
            // answerUnitLabel
            // 
            this.answerUnitLabel.AutoSize = true;
            this.answerUnitLabel.Location = new System.Drawing.Point(430, 177);
            this.answerUnitLabel.Name = "answerUnitLabel";
            this.answerUnitLabel.Size = new System.Drawing.Size(17, 12);
            this.answerUnitLabel.TabIndex = 7;
            this.answerUnitLabel.Text = "件";
            // 
            // answerCountLabel
            // 
            this.answerCountLabel.Location = new System.Drawing.Point(254, 177);
            this.answerCountLabel.Name = "answerCountLabel";
            this.answerCountLabel.Size = new System.Drawing.Size(170, 12);
            this.answerCountLabel.TabIndex = 6;
            this.answerCountLabel.Text = "ZZZ,ZZ9";
            this.answerCountLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // answerTitleLabel
            // 
            this.answerTitleLabel.Location = new System.Drawing.Point(145, 177);
            this.answerTitleLabel.Name = "answerTitleLabel";
            this.answerTitleLabel.Size = new System.Drawing.Size(120, 12);
            this.answerTitleLabel.TabIndex = 5;
            this.answerTitleLabel.Text = "回答データ作成";
            // 
            // receptionUnitLabel
            // 
            this.receptionUnitLabel.AutoSize = true;
            this.receptionUnitLabel.Location = new System.Drawing.Point(430, 150);
            this.receptionUnitLabel.Name = "receptionUnitLabel";
            this.receptionUnitLabel.Size = new System.Drawing.Size(17, 12);
            this.receptionUnitLabel.TabIndex = 4;
            this.receptionUnitLabel.Text = "件";
            // 
            // receptionCountLabel
            // 
            this.receptionCountLabel.Location = new System.Drawing.Point(254, 150);
            this.receptionCountLabel.Name = "receptionCountLabel";
            this.receptionCountLabel.Size = new System.Drawing.Size(170, 12);
            this.receptionCountLabel.TabIndex = 3;
            this.receptionCountLabel.Text = "ZZZ,ZZ9";
            this.receptionCountLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // receptionTitleLabel
            // 
            this.receptionTitleLabel.Location = new System.Drawing.Point(145, 150);
            this.receptionTitleLabel.Name = "receptionTitleLabel";
            this.receptionTitleLabel.Size = new System.Drawing.Size(120, 12);
            this.receptionTitleLabel.TabIndex = 2;
            this.receptionTitleLabel.Text = "受信件数";
            // 
            // uoeSupplierComboBox
            // 
            this.uoeSupplierComboBox.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 179 ) ) ) ), ( (int)( ( (byte)( 219 ) ) ) ), ( (int)( ( (byte)( 231 ) ) ) ));
            this.uoeSupplierComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.uoeSupplierComboBox.FormattingEnabled = true;
            this.uoeSupplierComboBox.Location = new System.Drawing.Point(147, 77);
            this.uoeSupplierComboBox.Name = "uoeSupplierComboBox";
            this.uoeSupplierComboBox.Size = new System.Drawing.Size(300, 20);
            this.uoeSupplierComboBox.TabIndex = 1;
            // 
            // OroshishoStockReceptionView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 222 ) ) ) ), ( (int)( ( (byte)( 239 ) ) ) ), ( (int)( ( (byte)( 255 ) ) ) ));
            this.Controls.Add(this.panel1);
            this.Name = "OroshishoStockReceptionView";
            this.Size = new System.Drawing.Size(911, 605);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label uoeSupplierLabel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox uoeSupplierComboBox;
        private System.Windows.Forms.Label receptionTitleLabel;
        private System.Windows.Forms.Label receptionUnitLabel;
        private System.Windows.Forms.Label receptionCountLabel;
        private System.Windows.Forms.Label stockingUnitLabel;
        private System.Windows.Forms.Label stockingCountLabel;
        private System.Windows.Forms.Label stockingTitleLabel;
        private System.Windows.Forms.Label answerUnitLabel;
        private System.Windows.Forms.Label answerCountLabel;
        private System.Windows.Forms.Label answerTitleLabel;
    }
}

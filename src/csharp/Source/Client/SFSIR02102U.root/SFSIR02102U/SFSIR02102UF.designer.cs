namespace Broadleaf.Windows.Forms
{
    partial class SFSIR02102UF
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
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance109 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SFSIR02102UF));
            this.ulblMessage = new Infragistics.Win.Misc.UltraLabel();
            this.ulblDepositKind = new Infragistics.Win.Misc.UltraLabel();
            this.tcboPaymentKind = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.ubtnOK = new Infragistics.Win.Misc.UltraButton();
            this.ubtnCancel = new Infragistics.Win.Misc.UltraButton();
            this.ulblTeGataMessage = new Infragistics.Win.Misc.UltraLabel();
            ((System.ComponentModel.ISupportInitialize)(this.tcboPaymentKind)).BeginInit();
            this.SuspendLayout();
            // 
            // ulblMessage
            // 
            appearance4.TextVAlignAsString = "Middle";
            this.ulblMessage.Appearance = appearance4;
            this.ulblMessage.Font = new System.Drawing.Font("ＭＳ ゴシック", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ulblMessage.Location = new System.Drawing.Point(12, 13);
            this.ulblMessage.Name = "ulblMessage";
            this.ulblMessage.Size = new System.Drawing.Size(228, 40);
            this.ulblMessage.TabIndex = 901;
            this.ulblMessage.Text = "支払金額を 0 円で作成します。金種を選択して下さい。";
            // 
            // ulblDepositKind
            // 
            appearance109.TextVAlignAsString = "Middle";
            this.ulblDepositKind.Appearance = appearance109;
            this.ulblDepositKind.Font = new System.Drawing.Font("ＭＳ ゴシック", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ulblDepositKind.Location = new System.Drawing.Point(12, 63);
            this.ulblDepositKind.Name = "ulblDepositKind";
            this.ulblDepositKind.Size = new System.Drawing.Size(50, 24);
            this.ulblDepositKind.TabIndex = 902;
            this.ulblDepositKind.Text = "金種";
            // 
            // tcboPaymentKind
            // 
            appearance1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tcboPaymentKind.ActiveAppearance = appearance1;
            appearance2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tcboPaymentKind.Appearance = appearance2;
            this.tcboPaymentKind.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tcboPaymentKind.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.tcboPaymentKind.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            appearance3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tcboPaymentKind.ItemAppearance = appearance3;
            this.tcboPaymentKind.Location = new System.Drawing.Point(68, 63);
            this.tcboPaymentKind.Name = "tcboPaymentKind";
            this.tcboPaymentKind.Size = new System.Drawing.Size(172, 24);
            this.tcboPaymentKind.TabIndex = 1;
            // 
            // ubtnOK
            // 
            this.ubtnOK.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ubtnOK.Location = new System.Drawing.Point(42, 102);
            this.ubtnOK.Name = "ubtnOK";
            this.ubtnOK.Size = new System.Drawing.Size(96, 25);
            this.ubtnOK.TabIndex = 2;
            this.ubtnOK.Text = "OK";
            this.ubtnOK.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.ubtnOK.Click += new System.EventHandler(this.ubtnOK_Click);
            // 
            // ubtnCancel
            // 
            this.ubtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ubtnCancel.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ubtnCancel.Location = new System.Drawing.Point(144, 102);
            this.ubtnCancel.Name = "ubtnCancel";
            this.ubtnCancel.Size = new System.Drawing.Size(96, 25);
            this.ubtnCancel.TabIndex = 3;
            this.ubtnCancel.Text = "キャンセル";
            this.ubtnCancel.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.ubtnCancel.Click += new System.EventHandler(this.ubtnCancel_Click);
            // 
            // ulblTeGataMessage
            // 
            this.ulblTeGataMessage.Location = new System.Drawing.Point(69, 88);
            this.ulblTeGataMessage.Name = "ulblTeGataMessage";
            this.ulblTeGataMessage.Size = new System.Drawing.Size(170, 13);
            this.ulblTeGataMessage.TabIndex = 903;
            this.ulblTeGataMessage.Text = "（手形データは削除されません）";
            this.ulblTeGataMessage.Visible = false;
            // 
            // SFSIR02102UF
            // 
            this.AcceptButton = this.ubtnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(254)))));
            this.CancelButton = this.ubtnCancel;
            this.ClientSize = new System.Drawing.Size(252, 131);
            this.Controls.Add(this.ulblTeGataMessage);
            this.Controls.Add(this.ubtnCancel);
            this.Controls.Add(this.ubtnOK);
            this.Controls.Add(this.tcboPaymentKind);
            this.Controls.Add(this.ulblDepositKind);
            this.Controls.Add(this.ulblMessage);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SFSIR02102UF";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "支払選択";
            this.Load += new System.EventHandler(this.SFUKK01403UC_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tcboPaymentKind)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Infragistics.Win.Misc.UltraLabel ulblMessage;
        private Infragistics.Win.Misc.UltraLabel ulblDepositKind;
        private Broadleaf.Library.Windows.Forms.TComboEditor tcboPaymentKind;
        private Infragistics.Win.Misc.UltraButton ubtnOK;
        private Infragistics.Win.Misc.UltraButton ubtnCancel;
        public Infragistics.Win.Misc.UltraLabel ulblTeGataMessage;

    }
}
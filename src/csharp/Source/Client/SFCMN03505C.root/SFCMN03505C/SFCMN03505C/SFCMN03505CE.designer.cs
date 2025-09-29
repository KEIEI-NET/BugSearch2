namespace Broadleaf.Windows.Forms
{
    partial class SFCMN03505CE
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( SFCMN03505CE ) );
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.Cancel_Button = new Infragistics.Win.Misc.UltraButton();
            this.ultraLabel2 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel3 = new Infragistics.Win.Misc.UltraLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.GhostWhite;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject( "pictureBox1.Image" )));
            this.pictureBox1.Location = new System.Drawing.Point( 35, 97 );
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size( 271, 18 );
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // ultraLabel1
            // 
            this.ultraLabel1.Location = new System.Drawing.Point( 35, 16 );
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size( 247, 19 );
            this.ultraLabel1.TabIndex = 9;
            this.ultraLabel1.Text = "フェリカ対応カードをリーダーに";
            // 
            // Cancel_Button
            // 
            this.Cancel_Button.ImageSize = new System.Drawing.Size( 24, 24 );
            this.Cancel_Button.Location = new System.Drawing.Point( 108, 129 );
            this.Cancel_Button.Name = "Cancel_Button";
            this.Cancel_Button.Size = new System.Drawing.Size( 125, 34 );
            this.Cancel_Button.TabIndex = 10;
            this.Cancel_Button.Text = "戻る(&R)";
            this.Cancel_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Cancel_Button.Click += new System.EventHandler( this.Cancel_Button_Click );
            // 
            // ultraLabel2
            // 
            this.ultraLabel2.Location = new System.Drawing.Point( 35, 68 );
            this.ultraLabel2.Name = "ultraLabel2";
            this.ultraLabel2.Size = new System.Drawing.Size( 251, 23 );
            this.ultraLabel2.TabIndex = 11;
            this.ultraLabel2.Text = "受信中・・・";
            // 
            // ultraLabel3
            // 
            this.ultraLabel3.Location = new System.Drawing.Point( 35, 33 );
            this.ultraLabel3.Name = "ultraLabel3";
            this.ultraLabel3.Size = new System.Drawing.Size( 247, 19 );
            this.ultraLabel3.TabIndex = 12;
            this.ultraLabel3.Text = "かざして下さい。";
            // 
            // SFCMN03505CE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 8F, 15F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size( 334, 179 );
            this.Controls.Add( this.ultraLabel3 );
            this.Controls.Add( this.ultraLabel2 );
            this.Controls.Add( this.Cancel_Button );
            this.Controls.Add( this.ultraLabel1 );
            this.Controls.Add( this.pictureBox1 );
            this.Font = new System.Drawing.Font( "ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)) );
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject( "$this.Icon" )));
            this.Margin = new System.Windows.Forms.Padding( 4 );
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SFCMN03505CE";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "フェリカカードID登録";
            this.Load += new System.EventHandler( this.SFCMN03505CE_Load );
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout( false );

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private Infragistics.Win.Misc.UltraLabel ultraLabel1;
        private Infragistics.Win.Misc.UltraButton Cancel_Button;
        private Infragistics.Win.Misc.UltraLabel ultraLabel2;
        private Infragistics.Win.Misc.UltraLabel ultraLabel3;
    }
}
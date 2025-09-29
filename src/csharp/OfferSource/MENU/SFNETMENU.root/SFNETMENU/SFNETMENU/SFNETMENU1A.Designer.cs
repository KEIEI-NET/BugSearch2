namespace Broadleaf.Windows.Forms
{
    partial class SFNETMENUF
    {
        /// <summary>
        /// 必要なデザイナ変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param rKeyName="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( SFNETMENUF ) );
            this.sfMenuPanel = new Broadleaf.Library.Windows.Forms.SFCMN00037UBC();
            this.tMemPos1 = new Broadleaf.Library.Windows.Forms.TMemPos( this.components );
            this.SuspendLayout();
            // 
            // sfMenuPanel
            // 
            this.sfMenuPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sfMenuPanel.Location = new System.Drawing.Point( 0, 0 );
            this.sfMenuPanel.Name = "sfMenuPanel";
            this.sfMenuPanel.Size = new System.Drawing.Size( 1018, 736 );
            this.sfMenuPanel.TabIndex = 1;
            // 
            // tMemPos1
            // 
            this.tMemPos1.OwnerForm = this;
            this.tMemPos1.SetType = Broadleaf.Library.Windows.Forms.TMemPos.emSetType.Position;
            // 
            // SFNETMENUF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 12F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size( 1018, 736 );
            this.Controls.Add( this.sfMenuPanel );
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject( "$this.Icon" )));
            this.MaximizeBox = false;
            this.Name = "SFNETMENUF";
            this.Text = ".NS MainMenu";
            this.Load += new System.EventHandler( this.SFNETMENUF_Load );
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler( this.SFNETMENUF_FormClosing );
            this.ResumeLayout( false );

        }

        #endregion

        private Broadleaf.Library.Windows.Forms.SFCMN00037UBC sfMenuPanel;
        private Broadleaf.Library.Windows.Forms.TMemPos tMemPos1;
    }
}


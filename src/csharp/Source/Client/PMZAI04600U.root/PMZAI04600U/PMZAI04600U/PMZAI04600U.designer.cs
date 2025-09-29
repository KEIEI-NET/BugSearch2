namespace Broadleaf.Windows.Forms
{
	partial class PMZAI04600U
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( PMZAI04600U ) );
            this.tMemPos1 = new Broadleaf.Library.Windows.Forms.TMemPos( this.components );
            this.SuspendLayout();
            // 
            // tMemPos1
            // 
            this.tMemPos1.OwnerForm = this;
            // 
            // PMZAI04600U
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size( 1016, 704 );
            this.Font = new System.Drawing.Font( "ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)) );
            this.Icon = ((System.Drawing.Icon)(resources.GetObject( "$this.Icon" )));
            this.Margin = new System.Windows.Forms.Padding( 4 );
            this.Name = "PMZAI04600U";
            this.Opacity = 0;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "在庫移動電子元帳";
            this.Load += new System.EventHandler( this.PMZAI04600U_Load );
            this.Shown += new System.EventHandler( this.PMZAI04600U_Shown );
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PMZAI04600U_FormClosing);
            this.ResumeLayout(false);

		}

		#endregion

		private Broadleaf.Library.Windows.Forms.TMemPos tMemPos1;

	}
}


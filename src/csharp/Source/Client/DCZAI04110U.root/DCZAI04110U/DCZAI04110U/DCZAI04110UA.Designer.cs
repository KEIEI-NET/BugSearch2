namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 在庫検索フォーム
    /// </summary>
	partial class DCZAI04110UA
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCZAI04110UA));
            this.tMemPos1 = new Broadleaf.Library.Windows.Forms.TMemPos(this.components);
            this.SuspendLayout();
            // 
            // tMemPos1
            // 
            this.tMemPos1.OwnerForm = this;
            // 
            // DCZAI04110UA
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1016, 734);
            this.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "DCZAI04110UA";
            this.Text = "在庫照会";
            this.Load += new System.EventHandler(this.DCHAT04100UA_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.DCZAI04110UA_FormClosed);
            this.ResumeLayout(false);

		}

		#endregion

		private Broadleaf.Library.Windows.Forms.TMemPos tMemPos1;

	}
}


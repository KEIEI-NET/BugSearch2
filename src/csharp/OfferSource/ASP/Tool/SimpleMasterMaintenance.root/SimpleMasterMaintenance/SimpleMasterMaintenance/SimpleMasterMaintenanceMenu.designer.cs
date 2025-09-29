namespace Broadleaf.Windows.Forms
{
	partial class SimpleMasterMaintenanceMenu
	{
		/// <summary>
		/// 必要なデザイナ変数です。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 使用中のリソースをすべてクリーンアップします。
		/// </summary>
		/// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
		protected override void Dispose( bool disposing )
		{
			if( disposing && ( components != null ) ) {
				components.Dispose();

				if( this._menuSettingList != null ) {
					foreach( MenuSetting menuSetting in this._menuSettingList ) {
						if( ( menuSetting.Form != null ) && 
							( ! menuSetting.Form.IsDisposed ) ) {
							menuSetting.Form.Dispose();
						}
					}
				}
			}
			base.Dispose( disposing );
		}

		#region Windows フォーム デザイナで生成されたコード

		/// <summary>
		/// デザイナ サポートに必要なメソッドです。このメソッドの内容を
		/// コード エディタで変更しないでください。
		/// </summary>
		private void InitializeComponent()
		{
            this.SuspendLayout();
            // 
            // SimpleMasterMaintenanceMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(348, 166);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "SimpleMasterMaintenanceMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "簡易マスタメンテナンス";
            this.Load += new System.EventHandler(this.SimpleMasterMaintenanceMenu_Load);
            this.ResumeLayout(false);

		}

		#endregion


    }
}


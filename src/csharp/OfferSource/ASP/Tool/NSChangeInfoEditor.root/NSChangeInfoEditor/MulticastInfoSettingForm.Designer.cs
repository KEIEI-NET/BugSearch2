namespace Broadleaf.Windows.Forms
{
	partial class MulticastInfoSettingForm
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
			this.OK_button = new System.Windows.Forms.Button();
			this.Cancel_button = new System.Windows.Forms.Button();
			this.AnothersheetPath_label = new System.Windows.Forms.Label();
			this.AnothersheetPath_textBox = new System.Windows.Forms.TextBox();
			this.DirRef_button = new System.Windows.Forms.Button();
			this.DirRef_folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
			this.SuspendLayout();
			// 
			// OK_button
			// 
			this.OK_button.Location = new System.Drawing.Point( 280, 60 );
			this.OK_button.Name = "OK_button";
			this.OK_button.Size = new System.Drawing.Size( 75, 23 );
			this.OK_button.TabIndex = 3;
			this.OK_button.Text = "OK";
			this.OK_button.UseVisualStyleBackColor = true;
			this.OK_button.Click += new System.EventHandler( this.OK_button_Click );
			// 
			// Cancel_button
			// 
			this.Cancel_button.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.Cancel_button.Location = new System.Drawing.Point( 356, 60 );
			this.Cancel_button.Name = "Cancel_button";
			this.Cancel_button.Size = new System.Drawing.Size( 75, 23 );
			this.Cancel_button.TabIndex = 4;
			this.Cancel_button.Text = "キャンセル";
			this.Cancel_button.UseVisualStyleBackColor = true;
			this.Cancel_button.Click += new System.EventHandler( this.Cancel_button_Click );
			// 
			// AnothersheetPath_label
			// 
			this.AnothersheetPath_label.AutoSize = true;
			this.AnothersheetPath_label.Location = new System.Drawing.Point( 8, 20 );
			this.AnothersheetPath_label.Name = "AnothersheetPath_label";
			this.AnothersheetPath_label.Size = new System.Drawing.Size( 138, 12 );
			this.AnothersheetPath_label.TabIndex = 0;
			this.AnothersheetPath_label.Text = "別紙ファイル配置フォルダ(&D)";
			// 
			// AnothersheetPath_textBox
			// 
			this.AnothersheetPath_textBox.Location = new System.Drawing.Point( 148, 16 );
			this.AnothersheetPath_textBox.Name = "AnothersheetPath_textBox";
			this.AnothersheetPath_textBox.Size = new System.Drawing.Size( 224, 19 );
			this.AnothersheetPath_textBox.TabIndex = 1;
			// 
			// DirRef_button
			// 
			this.DirRef_button.Location = new System.Drawing.Point( 372, 14 );
			this.DirRef_button.Name = "DirRef_button";
			this.DirRef_button.Size = new System.Drawing.Size( 60, 23 );
			this.DirRef_button.TabIndex = 2;
			this.DirRef_button.Text = "参照(&R)";
			this.DirRef_button.UseVisualStyleBackColor = true;
			this.DirRef_button.Click += new System.EventHandler( this.DirRef_button_Click );
			// 
			// DirRef_folderBrowserDialog
			// 
			this.DirRef_folderBrowserDialog.Description = "別紙ファイルを配置するフォルダを選択してください。";
			// 
			// MulticastInfoSettingForm
			// 
			this.AcceptButton = this.OK_button;
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 12F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.Cancel_button;
			this.ClientSize = new System.Drawing.Size( 439, 96 );
			this.Controls.Add( this.DirRef_button );
			this.Controls.Add( this.AnothersheetPath_textBox );
			this.Controls.Add( this.AnothersheetPath_label );
			this.Controls.Add( this.Cancel_button );
			this.Controls.Add( this.OK_button );
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "MulticastInfoSettingForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "設定";
			this.Shown += new System.EventHandler( this.MulticastInfoSettingForm_Shown );
			this.Load += new System.EventHandler( this.MulticastInfoSettingForm_Load );
			this.ResumeLayout( false );
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button OK_button;
		private System.Windows.Forms.Button Cancel_button;
		private System.Windows.Forms.Label AnothersheetPath_label;
		private System.Windows.Forms.TextBox AnothersheetPath_textBox;
		private System.Windows.Forms.Button DirRef_button;
		private System.Windows.Forms.FolderBrowserDialog DirRef_folderBrowserDialog;
	}
}
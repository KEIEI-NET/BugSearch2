namespace Broadleaf.Windows.Forms
{
	partial class Form1
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
            this.OutPut_btn = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.New_btn = new System.Windows.Forms.Button();
            this.Upd_btn = new System.Windows.Forms.Button();
            this.LogDel_btn = new System.Windows.Forms.Button();
            this.Del_btn = new System.Windows.Forms.Button();
            this.Rev_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // OutPut_btn
            // 
            this.OutPut_btn.Location = new System.Drawing.Point(12, 24);
            this.OutPut_btn.Name = "OutPut_btn";
            this.OutPut_btn.Size = new System.Drawing.Size(156, 23);
            this.OutPut_btn.TabIndex = 0;
            this.OutPut_btn.Text = "ログ出力";
            this.OutPut_btn.UseVisualStyleBackColor = true;
            this.OutPut_btn.Click += new System.EventHandler(this.Start_btn_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 53);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(156, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "連続ログ出力";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // New_btn
            // 
            this.New_btn.Location = new System.Drawing.Point(185, 24);
            this.New_btn.Name = "New_btn";
            this.New_btn.Size = new System.Drawing.Size(52, 52);
            this.New_btn.TabIndex = 2;
            this.New_btn.Text = "新規 登録";
            this.New_btn.UseVisualStyleBackColor = true;
            this.New_btn.Click += new System.EventHandler(this.New_btn_Click);
            // 
            // Upd_btn
            // 
            this.Upd_btn.Location = new System.Drawing.Point(243, 24);
            this.Upd_btn.Name = "Upd_btn";
            this.Upd_btn.Size = new System.Drawing.Size(52, 52);
            this.Upd_btn.TabIndex = 3;
            this.Upd_btn.Text = "更新";
            this.Upd_btn.UseVisualStyleBackColor = true;
            this.Upd_btn.Click += new System.EventHandler(this.Upd_btn_Click);
            // 
            // LogDel_btn
            // 
            this.LogDel_btn.Location = new System.Drawing.Point(301, 24);
            this.LogDel_btn.Name = "LogDel_btn";
            this.LogDel_btn.Size = new System.Drawing.Size(52, 52);
            this.LogDel_btn.TabIndex = 4;
            this.LogDel_btn.Text = "論理 削除";
            this.LogDel_btn.UseVisualStyleBackColor = true;
            this.LogDel_btn.Click += new System.EventHandler(this.LogDel_btn_Click);
            // 
            // Del_btn
            // 
            this.Del_btn.Location = new System.Drawing.Point(359, 24);
            this.Del_btn.Name = "Del_btn";
            this.Del_btn.Size = new System.Drawing.Size(52, 52);
            this.Del_btn.TabIndex = 5;
            this.Del_btn.Text = "物理 削除";
            this.Del_btn.UseVisualStyleBackColor = true;
            this.Del_btn.Click += new System.EventHandler(this.Del_btn_Click);
            // 
            // Rev_btn
            // 
            this.Rev_btn.Location = new System.Drawing.Point(417, 25);
            this.Rev_btn.Name = "Rev_btn";
            this.Rev_btn.Size = new System.Drawing.Size(52, 51);
            this.Rev_btn.TabIndex = 6;
            this.Rev_btn.Text = "復活";
            this.Rev_btn.UseVisualStyleBackColor = true;
            this.Rev_btn.Click += new System.EventHandler(this.Rev_btn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(496, 108);
            this.Controls.Add(this.Rev_btn);
            this.Controls.Add(this.Del_btn);
            this.Controls.Add(this.LogDel_btn);
            this.Controls.Add(this.Upd_btn);
            this.Controls.Add(this.New_btn);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.OutPut_btn);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button OutPut_btn;
		private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button New_btn;
        private System.Windows.Forms.Button Upd_btn;
        private System.Windows.Forms.Button LogDel_btn;
        private System.Windows.Forms.Button Del_btn;
        private System.Windows.Forms.Button Rev_btn;
	}
}
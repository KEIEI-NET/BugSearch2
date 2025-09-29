namespace Broadleaf.Windows.Forms
{
	partial class PMTSP01103UC
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PMTSP01103UC));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pBWait = new System.Windows.Forms.PictureBox();
            this.cancel_Button = new System.Windows.Forms.Button();
            this.send_timer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pBWait)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(392, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "データを送信しています・・・";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.Location = new System.Drawing.Point(0, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(392, 22);
            this.label2.TabIndex = 1;
            this.label2.Text = "しばらくお待ちください。";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pBWait
            // 
            this.pBWait.Image = ((System.Drawing.Image)(resources.GetObject("pBWait.Image")));
            this.pBWait.Location = new System.Drawing.Point(20, 50);
            this.pBWait.Name = "pBWait";
            this.pBWait.Size = new System.Drawing.Size(360, 16);
            this.pBWait.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pBWait.TabIndex = 13;
            this.pBWait.TabStop = false;
            // 
            // cancel_Button
            // 
            this.cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancel_Button.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.cancel_Button.Location = new System.Drawing.Point(150, 76);
            this.cancel_Button.Name = "cancel_Button";
            this.cancel_Button.Size = new System.Drawing.Size(100, 26);
            this.cancel_Button.TabIndex = 14;
            this.cancel_Button.Text = "閉じる";
            this.cancel_Button.UseVisualStyleBackColor = true;
            this.cancel_Button.Visible = false;
            this.cancel_Button.Click += new System.EventHandler(this.cancel_Button_Click);
            // 
            // send_timer
            // 
            this.send_timer.Tick += new System.EventHandler(this.send_timer_Tick);
            // 
            // PMTSP01103UC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.GhostWhite;
            this.ClientSize = new System.Drawing.Size(392, 106);
            this.Controls.Add(this.cancel_Button);
            this.Controls.Add(this.pBWait);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PMTSP01103UC";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "送信処理";
            this.Load += new System.EventHandler(this.PMTSP01103UB_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pBWait)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.PictureBox pBWait;
		private System.Windows.Forms.Button cancel_Button;
		private System.Windows.Forms.Timer send_timer;
	}
}
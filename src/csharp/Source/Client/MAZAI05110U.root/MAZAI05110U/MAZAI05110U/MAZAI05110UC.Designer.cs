namespace Broadleaf.Windows.Forms
{
	partial class BeforeSaveAttentionDialog
	{
		/// <summary>
		/// 必要なデザイナ変数です。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 使用中のリソースをすべてクリーンアップします。
		/// </summary>
		/// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
		protected override void Dispose ( bool disposing )
		{
			if ( disposing && ( components != null ) )
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
		private void InitializeComponent ()
		{
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BeforeSaveAttentionDialog));
            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel2 = new Infragistics.Win.Misc.UltraLabel();
            this.ubCancel = new Infragistics.Win.Misc.UltraButton();
            this.ubOk = new Infragistics.Win.Misc.UltraButton();
            this.ultraLabel3 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel4 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel5 = new Infragistics.Win.Misc.UltraLabel();
            this.ubAttention = new Infragistics.Win.Misc.UltraButton();
            this.SuspendLayout();
            // 
            // ultraLabel1
            // 
            appearance7.TextVAlignAsString = "Middle";
            this.ultraLabel1.Appearance = appearance7;
            this.ultraLabel1.Location = new System.Drawing.Point(27, 91);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(400, 23);
            this.ultraLabel1.TabIndex = 16;
            this.ultraLabel1.Text = "　伝票入力については、注意事項を参照して下さい。";
            // 
            // ultraLabel2
            // 
            appearance8.TextVAlignAsString = "Middle";
            this.ultraLabel2.Appearance = appearance8;
            this.ultraLabel2.Location = new System.Drawing.Point(12, 70);
            this.ultraLabel2.Name = "ultraLabel2";
            this.ultraLabel2.Size = new System.Drawing.Size(416, 23);
            this.ultraLabel2.TabIndex = 17;
            this.ultraLabel2.Text = "２）棚卸処理中（棚卸準備処理～棚卸過不足更新まで）の";
            // 
            // ubCancel
            // 
            this.ubCancel.Location = new System.Drawing.Point(328, 187);
            this.ubCancel.Name = "ubCancel";
            this.ubCancel.Size = new System.Drawing.Size(92, 29);
            this.ubCancel.TabIndex = 18;
            this.ubCancel.Text = "キャンセル";
            this.ubCancel.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.ubCancel.Click += new System.EventHandler(this.ubCancel_Click);
            // 
            // ubOk
            // 
            this.ubOk.Location = new System.Drawing.Point(232, 187);
            this.ubOk.Name = "ubOk";
            this.ubOk.Size = new System.Drawing.Size(92, 29);
            this.ubOk.TabIndex = 19;
            this.ubOk.Text = "OK";
            this.ubOk.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.ubOk.Click += new System.EventHandler(this.ubOk_Click);
            // 
            // ultraLabel3
            // 
            appearance9.TextVAlignAsString = "Middle";
            this.ultraLabel3.Appearance = appearance9;
            this.ultraLabel3.Location = new System.Drawing.Point(12, 41);
            this.ultraLabel3.Name = "ultraLabel3";
            this.ultraLabel3.Size = new System.Drawing.Size(416, 23);
            this.ultraLabel3.TabIndex = 20;
            this.ultraLabel3.Text = "１）棚卸準備処理後、すぐに棚卸調査表を印刷して下さい。";
            // 
            // ultraLabel4
            // 
            appearance1.FontData.BoldAsString = "True";
            appearance1.ForeColor = System.Drawing.Color.Red;
            appearance1.TextVAlignAsString = "Middle";
            this.ultraLabel4.Appearance = appearance1;
            this.ultraLabel4.Location = new System.Drawing.Point(12, 12);
            this.ultraLabel4.Name = "ultraLabel4";
            this.ultraLabel4.Size = new System.Drawing.Size(416, 23);
            this.ultraLabel4.TabIndex = 21;
            this.ultraLabel4.Text = "以下の注意事項を十分確認してから作業を行って下さい。";
            // 
            // ultraLabel5
            // 
            appearance10.ForeColor = System.Drawing.Color.Blue;
            appearance10.TextVAlignAsString = "Middle";
            this.ultraLabel5.Appearance = appearance10;
            this.ultraLabel5.Location = new System.Drawing.Point(12, 128);
            this.ultraLabel5.Name = "ultraLabel5";
            this.ultraLabel5.Size = new System.Drawing.Size(416, 23);
            this.ultraLabel5.TabIndex = 22;
            this.ultraLabel5.Text = "※詳細内容については、注意事項を参照して下さい。";
            // 
            // ubAttention
            // 
            this.ubAttention.Location = new System.Drawing.Point(12, 187);
            this.ubAttention.Name = "ubAttention";
            this.ubAttention.Size = new System.Drawing.Size(92, 29);
            this.ubAttention.TabIndex = 23;
            this.ubAttention.Text = "注意事項";
            this.ubAttention.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.ubAttention.Click += new System.EventHandler(this.ubAttention_Click);
            // 
            // BeforeSaveAttentionDialog
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(433, 223);
            this.Controls.Add(this.ubAttention);
            this.Controls.Add(this.ultraLabel5);
            this.Controls.Add(this.ultraLabel4);
            this.Controls.Add(this.ultraLabel3);
            this.Controls.Add(this.ubOk);
            this.Controls.Add(this.ubCancel);
            this.Controls.Add(this.ultraLabel2);
            this.Controls.Add(this.ultraLabel1);
            this.Font = new System.Drawing.Font("ＭＳ ゴシック", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BeforeSaveAttentionDialog";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "棚卸準備処理";
            this.ResumeLayout(false);

		}

		#endregion

        private Infragistics.Win.Misc.UltraLabel ultraLabel1;
		private Infragistics.Win.Misc.UltraLabel ultraLabel2;
		private Infragistics.Win.Misc.UltraButton ubCancel;
		private Infragistics.Win.Misc.UltraButton ubOk;
        private Infragistics.Win.Misc.UltraLabel ultraLabel3;
        private Infragistics.Win.Misc.UltraLabel ultraLabel4;
        private Infragistics.Win.Misc.UltraLabel ultraLabel5;
        private Infragistics.Win.Misc.UltraButton ubAttention;
	}
}
namespace Broadleaf.Windows.Forms
{
	partial class PMCMN00783UA
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PMCMN00783UA));
            this.timr_OpenClose = new System.Windows.Forms.Timer(this.components);
            this.lbl_Info01 = new System.Windows.Forms.Label();
            this.lbl_Title = new System.Windows.Forms.Label();
            this.lbl_Info02 = new System.Windows.Forms.Label();
            this.chk_ThisTimeOnly = new System.Windows.Forms.CheckBox();
            this.lbl_Info03 = new System.Windows.Forms.Label();
            this.pnl_Top = new System.Windows.Forms.Panel();
            this.pnl_Bottom = new System.Windows.Forms.Panel();
            this.pnl_Body = new System.Windows.Forms.Panel();
            this.pnl_Top.SuspendLayout();
            this.pnl_Bottom.SuspendLayout();
            this.pnl_Body.SuspendLayout();
            this.SuspendLayout();
            // 
            // timr_OpenClose
            // 
            this.timr_OpenClose.Interval = 10;
            this.timr_OpenClose.Tick += new System.EventHandler(this.timr_OpenClose_Tick);
            // 
            // lbl_Info01
            // 
            this.lbl_Info01.AutoSize = true;
            this.lbl_Info01.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Info01.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbl_Info01.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ( (byte)( 128 ) ));
            this.lbl_Info01.ForeColor = System.Drawing.Color.Blue;
            this.lbl_Info01.Location = new System.Drawing.Point(40, 10);
            this.lbl_Info01.Name = "lbl_Info01";
            this.lbl_Info01.Size = new System.Drawing.Size(119, 15);
            this.lbl_Info01.TabIndex = 0;
            this.lbl_Info01.Text = "重要なお知らせ";
            this.lbl_Info01.Click += new System.EventHandler(this.lbl_Info_Click);
            // 
            // lbl_Title
            // 
            this.lbl_Title.AutoSize = true;
            this.lbl_Title.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Title.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ( (byte)( 128 ) ));
            this.lbl_Title.ForeColor = System.Drawing.Color.Blue;
            this.lbl_Title.Location = new System.Drawing.Point(12, 9);
            this.lbl_Title.Name = "lbl_Title";
            this.lbl_Title.Size = new System.Drawing.Size(217, 13);
            this.lbl_Title.TabIndex = 1;
            this.lbl_Title.Text = "お客様へのお知らせがあります";
            // 
            // lbl_Info02
            // 
            this.lbl_Info02.AutoSize = true;
            this.lbl_Info02.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Info02.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbl_Info02.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ( (byte)( 128 ) ));
            this.lbl_Info02.ForeColor = System.Drawing.Color.Blue;
            this.lbl_Info02.Location = new System.Drawing.Point(40, 35);
            this.lbl_Info02.Name = "lbl_Info02";
            this.lbl_Info02.Size = new System.Drawing.Size(151, 15);
            this.lbl_Info02.TabIndex = 2;
            this.lbl_Info02.Text = "新着情報があります";
            this.lbl_Info02.Click += new System.EventHandler(this.lbl_Info_Click);
            // 
            // chk_ThisTimeOnly
            // 
            this.chk_ThisTimeOnly.AutoSize = true;
            this.chk_ThisTimeOnly.BackColor = System.Drawing.Color.Transparent;
            this.chk_ThisTimeOnly.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 128 ) ));
            this.chk_ThisTimeOnly.Location = new System.Drawing.Point(22, 6);
            this.chk_ThisTimeOnly.Name = "chk_ThisTimeOnly";
            this.chk_ThisTimeOnly.Size = new System.Drawing.Size(250, 17);
            this.chk_ThisTimeOnly.TabIndex = 3;
            this.chk_ThisTimeOnly.TabStop = false;
            this.chk_ThisTimeOnly.Text = "今回通知分に関して今後表示しない";
            this.chk_ThisTimeOnly.UseVisualStyleBackColor = false;
            // 
            // lbl_Info03
            // 
            this.lbl_Info03.AutoSize = true;
            this.lbl_Info03.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Info03.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbl_Info03.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ( (byte)( 128 ) ));
            this.lbl_Info03.ForeColor = System.Drawing.Color.Blue;
            this.lbl_Info03.Location = new System.Drawing.Point(40, 60);
            this.lbl_Info03.Name = "lbl_Info03";
            this.lbl_Info03.Size = new System.Drawing.Size(0, 15);
            this.lbl_Info03.TabIndex = 2;
            this.lbl_Info03.Click += new System.EventHandler(this.lbl_Info_Click);
            // 
            // pnl_Top
            // 
            this.pnl_Top.Controls.Add(this.lbl_Title);
            this.pnl_Top.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_Top.Location = new System.Drawing.Point(0, 0);
            this.pnl_Top.Name = "pnl_Top";
            this.pnl_Top.Size = new System.Drawing.Size(294, 26);
            this.pnl_Top.TabIndex = 4;
            // 
            // pnl_Bottom
            // 
            this.pnl_Bottom.Controls.Add(this.chk_ThisTimeOnly);
            this.pnl_Bottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnl_Bottom.Location = new System.Drawing.Point(0, 81);
            this.pnl_Bottom.Name = "pnl_Bottom";
            this.pnl_Bottom.Size = new System.Drawing.Size(294, 35);
            this.pnl_Bottom.TabIndex = 5;
            // 
            // pnl_Body
            // 
            this.pnl_Body.Controls.Add(this.lbl_Info03);
            this.pnl_Body.Controls.Add(this.lbl_Info02);
            this.pnl_Body.Controls.Add(this.lbl_Info01);
            this.pnl_Body.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_Body.Location = new System.Drawing.Point(0, 26);
            this.pnl_Body.Name = "pnl_Body";
            this.pnl_Body.Size = new System.Drawing.Size(294, 55);
            this.pnl_Body.TabIndex = 6;
            // 
            // PMCMN00783UA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(294, 116);
            this.Controls.Add(this.pnl_Body);
            this.Controls.Add(this.pnl_Bottom);
            this.Controls.Add(this.pnl_Top);
            this.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 128 ) ));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ( (System.Drawing.Icon)( resources.GetObject("$this.Icon") ) );
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PMCMN00783UA";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "PM.NS お知らせ通知";
            this.Load += new System.EventHandler(this.SFCMN00783UA_Load);
            this.Shown += new System.EventHandler(this.SFCMN00783UA_Shown);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SFCMN00783UA_FormClosing);
            this.pnl_Top.ResumeLayout(false);
            this.pnl_Top.PerformLayout();
            this.pnl_Bottom.ResumeLayout(false);
            this.pnl_Bottom.PerformLayout();
            this.pnl_Body.ResumeLayout(false);
            this.pnl_Body.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Timer timr_OpenClose;
		private System.Windows.Forms.Label lbl_Info01;
		private System.Windows.Forms.Label lbl_Title;
		private System.Windows.Forms.Label lbl_Info02;
		private System.Windows.Forms.CheckBox chk_ThisTimeOnly;
		private System.Windows.Forms.Label lbl_Info03;
		private System.Windows.Forms.Panel pnl_Top;
		private System.Windows.Forms.Panel pnl_Bottom;
		private System.Windows.Forms.Panel pnl_Body;

	}
}


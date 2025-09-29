namespace CreateAppConfig
{
	partial class MainForm
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
            this.btn_Create = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_FileName = new System.Windows.Forms.TextBox();
            this.btn_Open = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.num_Span = new System.Windows.Forms.NumericUpDown();
            this.txt_WebTopPageURL = new System.Windows.Forms.TextBox();
            this.txt_WebServiceURL = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            ( (System.ComponentModel.ISupportInitialize)( this.num_Span ) ).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Create
            // 
            this.btn_Create.Location = new System.Drawing.Point(165, 165);
            this.btn_Create.Name = "btn_Create";
            this.btn_Create.Size = new System.Drawing.Size(75, 23);
            this.btn_Create.TabIndex = 0;
            this.btn_Create.Text = "Create";
            this.btn_Create.UseVisualStyleBackColor = true;
            this.btn_Create.Click += new System.EventHandler(this.btn_Create_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "WebServiceURL";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "CheckTimeSpan";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(173, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "秒";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 103);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 2;
            this.label4.Text = "FileName";
            // 
            // txt_FileName
            // 
            this.txt_FileName.AllowDrop = true;
            this.txt_FileName.Location = new System.Drawing.Point(104, 100);
            this.txt_FileName.Name = "txt_FileName";
            this.txt_FileName.Size = new System.Drawing.Size(385, 19);
            this.txt_FileName.TabIndex = 1;
            this.txt_FileName.Text = "PMCMN00783U_Config.dat";
            this.txt_FileName.DragDrop += new System.Windows.Forms.DragEventHandler(this.txt_FileName_DragDrop);
            this.txt_FileName.DragEnter += new System.Windows.Forms.DragEventHandler(this.txt_FileName_DragEnter);
            // 
            // btn_Open
            // 
            this.btn_Open.Location = new System.Drawing.Point(246, 165);
            this.btn_Open.Name = "btn_Open";
            this.btn_Open.Size = new System.Drawing.Size(75, 23);
            this.btn_Open.TabIndex = 0;
            this.btn_Open.Text = "Open";
            this.btn_Open.UseVisualStyleBackColor = true;
            this.btn_Open.Click += new System.EventHandler(this.btn_Open_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 66);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 12);
            this.label5.TabIndex = 2;
            this.label5.Text = "WebTopPageURL";
            // 
            // num_Span
            // 
            this.num_Span.Location = new System.Drawing.Point(104, 38);
            this.num_Span.Maximum = new decimal(new int[] {
            86400,
            0,
            0,
            0});
            this.num_Span.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.num_Span.Name = "num_Span";
            this.num_Span.Size = new System.Drawing.Size(66, 19);
            this.num_Span.TabIndex = 3;
            this.num_Span.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.num_Span.Value = global::CreateAppConfig.Properties.Settings.Default.CheckTimeSpan;
            // 
            // txt_WebTopPageURL
            // 
            this.txt_WebTopPageURL.Location = new System.Drawing.Point(104, 63);
            this.txt_WebTopPageURL.Name = "txt_WebTopPageURL";
            this.txt_WebTopPageURL.Size = new System.Drawing.Size(385, 19);
            this.txt_WebTopPageURL.TabIndex = 1;
            this.txt_WebTopPageURL.Text = global::CreateAppConfig.Properties.Settings.Default.WebTopPageURL;
            // 
            // txt_WebServiceURL
            // 
            this.txt_WebServiceURL.Location = new System.Drawing.Point(104, 12);
            this.txt_WebServiceURL.Name = "txt_WebServiceURL";
            this.txt_WebServiceURL.Size = new System.Drawing.Size(385, 19);
            this.txt_WebServiceURL.TabIndex = 1;
            this.txt_WebServiceURL.Text = global::CreateAppConfig.Properties.Settings.Default.WebServiceURL;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ( (byte)( 128 ) ));
            this.label6.Location = new System.Drawing.Point(12, 139);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(446, 12);
            this.label6.TabIndex = 4;
            this.label6.Text = "WebServiceURL,WebTopPageURLは、 %Infomation% 指定時に認証情報を使用";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(501, 198);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.num_Span);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_FileName);
            this.Controls.Add(this.txt_WebTopPageURL);
            this.Controls.Add(this.txt_WebServiceURL);
            this.Controls.Add(this.btn_Open);
            this.Controls.Add(this.btn_Create);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "CreateAppConfigTool";
            ( (System.ComponentModel.ISupportInitialize)( this.num_Span ) ).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btn_Create;
        private System.Windows.Forms.TextBox txt_WebServiceURL;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.NumericUpDown num_Span;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txt_FileName;
		private System.Windows.Forms.Button btn_Open;
		private System.Windows.Forms.TextBox txt_WebTopPageURL;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
	}
}


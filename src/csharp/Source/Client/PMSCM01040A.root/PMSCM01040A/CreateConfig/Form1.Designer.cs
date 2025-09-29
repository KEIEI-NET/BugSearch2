namespace CreateConfig
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
            if (disposing && ( components != null ))
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
            this.txt_ServiceURL = new System.Windows.Forms.TextBox();
            this.btn_Open = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_FileName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btn_Create
            // 
            this.btn_Create.Location = new System.Drawing.Point(95, 73);
            this.btn_Create.Name = "btn_Create";
            this.btn_Create.Size = new System.Drawing.Size(75, 23);
            this.btn_Create.TabIndex = 0;
            this.btn_Create.Text = "Save";
            this.btn_Create.UseVisualStyleBackColor = true;
            this.btn_Create.Click += new System.EventHandler(this.btn_Create_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "サービスURL";
            // 
            // txt_ServiceURL
            // 
            this.txt_ServiceURL.Location = new System.Drawing.Point(82, 23);
            this.txt_ServiceURL.Name = "txt_ServiceURL";
            this.txt_ServiceURL.Size = new System.Drawing.Size(566, 19);
            this.txt_ServiceURL.TabIndex = 2;
            this.txt_ServiceURL.Text = "http://d-ap-web-vx03/NsExchg/SFINQ06740AB.asmx";
            // 
            // btn_Open
            // 
            this.btn_Open.Location = new System.Drawing.Point(14, 73);
            this.btn_Open.Name = "btn_Open";
            this.btn_Open.Size = new System.Drawing.Size(75, 23);
            this.btn_Open.TabIndex = 3;
            this.btn_Open.Text = "Open";
            this.btn_Open.UseVisualStyleBackColor = true;
            this.btn_Open.Click += new System.EventHandler(this.btn_Open_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "ファイル名";
            // 
            // txt_FileName
            // 
            this.txt_FileName.Location = new System.Drawing.Point(82, 48);
            this.txt_FileName.Name = "txt_FileName";
            this.txt_FileName.Size = new System.Drawing.Size(566, 19);
            this.txt_FileName.TabIndex = 5;
            this.txt_FileName.Text = "PMSCM01040A_Config.dat";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(660, 115);
            this.Controls.Add(this.txt_FileName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_Open);
            this.Controls.Add(this.txt_ServiceURL);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_Create);
            this.Name = "MainForm";
            this.Text = "CreateConfig";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Create;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_ServiceURL;
        private System.Windows.Forms.Button btn_Open;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_FileName;
    }
}


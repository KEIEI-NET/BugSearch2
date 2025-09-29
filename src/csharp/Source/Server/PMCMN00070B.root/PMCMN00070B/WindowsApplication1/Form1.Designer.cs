namespace WindowsApplication1
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
            this.CopyClcLogFile = new System.Windows.Forms.Button();
            this.PGID = new System.Windows.Forms.TextBox();
            this.OutputClcLog = new System.Windows.Forms.Button();
            this.ProductId = new System.Windows.Forms.TextBox();
            this.Message = new System.Windows.Forms.TextBox();
            this.Status = new System.Windows.Forms.TextBox();
            this.ExPara = new System.Windows.Forms.TextBox();
            this.FileFullPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.OutputClcLog_Return = new System.Windows.Forms.Label();
            this.CopyClcLogFile_Return = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // CopyClcLogFile
            // 
            this.CopyClcLogFile.Location = new System.Drawing.Point(339, 163);
            this.CopyClcLogFile.Name = "CopyClcLogFile";
            this.CopyClcLogFile.Size = new System.Drawing.Size(113, 23);
            this.CopyClcLogFile.TabIndex = 0;
            this.CopyClcLogFile.Text = "CopyClcLogFile";
            this.CopyClcLogFile.UseVisualStyleBackColor = true;
            this.CopyClcLogFile.Click += new System.EventHandler(this.CopyClcLogFile_Click);
            // 
            // PGID
            // 
            this.PGID.Location = new System.Drawing.Point(84, 8);
            this.PGID.Name = "PGID";
            this.PGID.Size = new System.Drawing.Size(249, 19);
            this.PGID.TabIndex = 1;
            // 
            // OutputClcLog
            // 
            this.OutputClcLog.Location = new System.Drawing.Point(339, 104);
            this.OutputClcLog.Name = "OutputClcLog";
            this.OutputClcLog.Size = new System.Drawing.Size(113, 23);
            this.OutputClcLog.TabIndex = 2;
            this.OutputClcLog.Text = "OutputClcLog";
            this.OutputClcLog.UseVisualStyleBackColor = true;
            this.OutputClcLog.Click += new System.EventHandler(this.OutputClcLog_Click);
            // 
            // ProductId
            // 
            this.ProductId.Location = new System.Drawing.Point(84, 33);
            this.ProductId.Name = "ProductId";
            this.ProductId.Size = new System.Drawing.Size(249, 19);
            this.ProductId.TabIndex = 3;
            // 
            // Message
            // 
            this.Message.Location = new System.Drawing.Point(84, 58);
            this.Message.Name = "Message";
            this.Message.Size = new System.Drawing.Size(249, 19);
            this.Message.TabIndex = 4;
            // 
            // Status
            // 
            this.Status.Location = new System.Drawing.Point(84, 83);
            this.Status.Name = "Status";
            this.Status.Size = new System.Drawing.Size(249, 19);
            this.Status.TabIndex = 5;
            // 
            // ExPara
            // 
            this.ExPara.Location = new System.Drawing.Point(84, 108);
            this.ExPara.Name = "ExPara";
            this.ExPara.Size = new System.Drawing.Size(249, 19);
            this.ExPara.TabIndex = 6;
            // 
            // FileFullPath
            // 
            this.FileFullPath.Location = new System.Drawing.Point(84, 167);
            this.FileFullPath.Name = "FileFullPath";
            this.FileFullPath.Size = new System.Drawing.Size(249, 19);
            this.FileFullPath.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 12);
            this.label1.TabIndex = 8;
            this.label1.Text = "PGID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 9;
            this.label2.Text = "ProductId";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 61);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 12);
            this.label7.TabIndex = 10;
            this.label7.Text = "Message";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 86);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 12);
            this.label6.TabIndex = 11;
            this.label6.Text = "Status";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 115);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 12);
            this.label8.TabIndex = 12;
            this.label8.Text = "ExPara";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 170);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(66, 12);
            this.label9.TabIndex = 13;
            this.label9.Text = "FileFullPath";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 136);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 12);
            this.label3.TabIndex = 14;
            this.label3.Text = "Return";
            // 
            // OutputClcLog_Return
            // 
            this.OutputClcLog_Return.AutoSize = true;
            this.OutputClcLog_Return.Location = new System.Drawing.Point(82, 136);
            this.OutputClcLog_Return.Name = "OutputClcLog_Return";
            this.OutputClcLog_Return.Size = new System.Drawing.Size(0, 12);
            this.OutputClcLog_Return.TabIndex = 15;
            // 
            // CopyClcLogFile_Return
            // 
            this.CopyClcLogFile_Return.AutoSize = true;
            this.CopyClcLogFile_Return.Location = new System.Drawing.Point(82, 189);
            this.CopyClcLogFile_Return.Name = "CopyClcLogFile_Return";
            this.CopyClcLogFile_Return.Size = new System.Drawing.Size(0, 12);
            this.CopyClcLogFile_Return.TabIndex = 16;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 189);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 12);
            this.label5.TabIndex = 17;
            this.label5.Text = "Return";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(475, 234);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.CopyClcLogFile_Return);
            this.Controls.Add(this.OutputClcLog_Return);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.FileFullPath);
            this.Controls.Add(this.ExPara);
            this.Controls.Add(this.Status);
            this.Controls.Add(this.Message);
            this.Controls.Add(this.ProductId);
            this.Controls.Add(this.OutputClcLog);
            this.Controls.Add(this.PGID);
            this.Controls.Add(this.CopyClcLogFile);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CopyClcLogFile;
        private System.Windows.Forms.TextBox PGID;
        private System.Windows.Forms.Button OutputClcLog;
        private System.Windows.Forms.TextBox ProductId;
        private System.Windows.Forms.TextBox Message;
        private System.Windows.Forms.TextBox Status;
        private System.Windows.Forms.TextBox ExPara;
        private System.Windows.Forms.TextBox FileFullPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label OutputClcLog_Return;
        private System.Windows.Forms.Label CopyClcLogFile_Return;
        private System.Windows.Forms.Label label5;

    }
}


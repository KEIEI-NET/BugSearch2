namespace PutUserDataTool
{
    internal partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnExecute = new System.Windows.Forms.Button();
            this.lblMsg = new System.Windows.Forms.Label();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlDetail = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblMsgDetail = new System.Windows.Forms.Label();
            this.lblResultSts = new System.Windows.Forms.Label();
            this.lblResult = new System.Windows.Forms.Label();
            this.bgWorker = new System.ComponentModel.BackgroundWorker();
            this.pnlMain.SuspendLayout();
            this.pnlDetail.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnExecute
            // 
            this.btnExecute.BackColor = System.Drawing.Color.LightGray;
            this.btnExecute.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExecute.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnExecute.Font = new System.Drawing.Font("MS UI Gothic", 14F, System.Drawing.FontStyle.Bold);
            this.btnExecute.Location = new System.Drawing.Point(18, 44);
            this.btnExecute.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Size = new System.Drawing.Size(232, 41);
            this.btnExecute.TabIndex = 0;
            this.btnExecute.Text = "実　行";
            this.btnExecute.UseVisualStyleBackColor = false;
            this.btnExecute.Click += new System.EventHandler(this.btnExecute_Click);
            // 
            // lblMsg
            // 
            this.lblMsg.BackColor = System.Drawing.Color.Transparent;
            this.lblMsg.Font = new System.Drawing.Font("Meiryo UI", 12F);
            this.lblMsg.Location = new System.Drawing.Point(17, 9);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(720, 31);
            this.lblMsg.TabIndex = 1;
            this.lblMsg.Text = "PM.NSで発生した不具合データの復旧のためデータ抽出とブロードリーフサーバーへの送信を行います。";
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.White;
            this.pnlMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMain.Controls.Add(this.pnlDetail);
            this.pnlMain.Controls.Add(this.lblResultSts);
            this.pnlMain.Controls.Add(this.lblResult);
            this.pnlMain.Location = new System.Drawing.Point(18, 92);
            this.pnlMain.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(738, 250);
            this.pnlMain.TabIndex = 2;
            // 
            // pnlDetail
            // 
            this.pnlDetail.AutoScroll = true;
            this.pnlDetail.BackColor = System.Drawing.Color.White;
            this.pnlDetail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDetail.Controls.Add(this.panel2);
            this.pnlDetail.Controls.Add(this.panel1);
            this.pnlDetail.Location = new System.Drawing.Point(17, 39);
            this.pnlDetail.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlDetail.Name = "pnlDetail";
            this.pnlDetail.Size = new System.Drawing.Size(700, 192);
            this.pnlDetail.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.textBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 24);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(698, 166);
            this.panel2.TabIndex = 7;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.White;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Font = new System.Drawing.Font("Meiryo UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBox1.Location = new System.Drawing.Point(0, 0);
            this.textBox1.Margin = new System.Windows.Forms.Padding(0);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(698, 166);
            this.textBox1.TabIndex = 7;
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.BackColor = System.Drawing.Color.Gray;
            this.panel1.Controls.Add(this.lblMsgDetail);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Font = new System.Drawing.Font("Meiryo UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.panel1.ForeColor = System.Drawing.Color.White;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(3);
            this.panel1.Size = new System.Drawing.Size(698, 24);
            this.panel1.TabIndex = 6;
            // 
            // lblMsgDetail
            // 
            this.lblMsgDetail.AutoSize = true;
            this.lblMsgDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMsgDetail.Font = new System.Drawing.Font("Meiryo UI", 10F);
            this.lblMsgDetail.Location = new System.Drawing.Point(3, 3);
            this.lblMsgDetail.Name = "lblMsgDetail";
            this.lblMsgDetail.Size = new System.Drawing.Size(36, 18);
            this.lblMsgDetail.TabIndex = 6;
            this.lblMsgDetail.Text = "内容";
            // 
            // lblResultSts
            // 
            this.lblResultSts.AutoSize = true;
            this.lblResultSts.Font = new System.Drawing.Font("Meiryo UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblResultSts.ForeColor = System.Drawing.Color.Red;
            this.lblResultSts.Location = new System.Drawing.Point(121, 8);
            this.lblResultSts.Name = "lblResultSts";
            this.lblResultSts.Size = new System.Drawing.Size(0, 23);
            this.lblResultSts.TabIndex = 1;
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Font = new System.Drawing.Font("Meiryo UI", 13F);
            this.lblResult.Location = new System.Drawing.Point(15, 8);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(100, 23);
            this.lblResult.TabIndex = 0;
            this.lblResult.Text = "実行結果：";
            // 
            // bgWorker
            // 
            this.bgWorker.WorkerReportsProgress = true;
            this.bgWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWorker_DoWork);
            this.bgWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgWorker_RunWorkerCompleted);
            this.bgWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgWorker_ProgressChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(774, 354);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.lblMsg);
            this.Controls.Add(this.btnExecute);
            this.Font = new System.Drawing.Font("Meiryo UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "PM.NSデータ復旧プログラム(データ抽出)";
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.pnlDetail.ResumeLayout(false);
            this.pnlDetail.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnExecute;
        private System.Windows.Forms.Label lblMsg;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.Label lblResultSts;
        private System.Windows.Forms.Panel pnlDetail;
        private System.Windows.Forms.Panel panel1;
        public System.ComponentModel.BackgroundWorker bgWorker;
        private System.Windows.Forms.Label lblMsgDetail;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox textBox1;
    }
}


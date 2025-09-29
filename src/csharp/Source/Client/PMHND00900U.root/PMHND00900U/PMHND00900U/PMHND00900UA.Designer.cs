namespace Broadleaf.Windows.Forms
{
    partial class PMHND00900UA
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PMHND00900UA));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.gpBox_Top = new System.Windows.Forms.GroupBox();
            this.btnCopy = new System.Windows.Forms.Button();
            this.rbBtnAll = new System.Windows.Forms.RadioButton();
            this.gpBox_Top.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 89);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(284, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // gpBox_Top
            // 
            this.gpBox_Top.BackColor = System.Drawing.SystemColors.ControlLight;
            this.gpBox_Top.Controls.Add(this.btnCopy);
            this.gpBox_Top.Controls.Add(this.rbBtnAll);
            this.gpBox_Top.Location = new System.Drawing.Point(4, 4);
            this.gpBox_Top.Name = "gpBox_Top";
            this.gpBox_Top.Size = new System.Drawing.Size(275, 84);
            this.gpBox_Top.TabIndex = 3;
            this.gpBox_Top.TabStop = false;
            this.gpBox_Top.Text = "ファイルコピー方法";
            // 
            // btnCopy
            // 
            this.btnCopy.Image = global::Broadleaf.Windows.Forms.Properties.Resources.個別PGインストール;
            this.btnCopy.Location = new System.Drawing.Point(183, 11);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(75, 62);
            this.btnCopy.TabIndex = 2;
            this.btnCopy.Text = "コピー開始";
            this.btnCopy.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // rbBtnAll
            // 
            this.rbBtnAll.AutoSize = true;
            this.rbBtnAll.Checked = true;
            this.rbBtnAll.Location = new System.Drawing.Point(21, 20);
            this.rbBtnAll.Name = "rbBtnAll";
            this.rbBtnAll.Size = new System.Drawing.Size(151, 16);
            this.rbBtnAll.TabIndex = 1;
            this.rbBtnAll.TabStop = true;
            this.rbBtnAll.Text = "全てのファイルをコピーする。";
            this.rbBtnAll.UseVisualStyleBackColor = true;
            // 
            // PMHND00900UA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 111);
            this.Controls.Add(this.gpBox_Top);
            this.Controls.Add(this.statusStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(300, 150);
            this.Name = "PMHND00900UA";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ハンディプログラム導入";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.SizeChanged += new System.EventHandler(this.FormMain_SizeChanged);
            this.gpBox_Top.ResumeLayout(false);
            this.gpBox_Top.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.GroupBox gpBox_Top;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.RadioButton rbBtnAll;
    }
}


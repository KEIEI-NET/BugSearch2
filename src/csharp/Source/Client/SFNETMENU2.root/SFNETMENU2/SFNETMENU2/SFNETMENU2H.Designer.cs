namespace Broadleaf.Windows.Forms
{
    partial class SFNETMENU2H
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SFNETMENU2H));
            this.label1 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.barSub = new System.Windows.Forms.ToolStrip();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.btnCancel = new System.Windows.Forms.ToolStripButton();
            this.lblMessage = new System.Windows.Forms.Label();
            this.lblPassKey1 = new System.Windows.Forms.Label();
            this.lblPasskey2 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.barSub.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(118, 134);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "パスワード：";
            // 
            // txtPassword
            // 
            this.txtPassword.ForeColor = System.Drawing.Color.Black;
            this.txtPassword.Location = new System.Drawing.Point(217, 131);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(4);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(258, 22);
            this.txtPassword.TabIndex = 1;
            // 
            // barSub
            // 
            this.barSub.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.barSub.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSave,
            this.btnCancel});
            this.barSub.Location = new System.Drawing.Point(0, 0);
            this.barSub.Name = "barSub";
            this.barSub.Size = new System.Drawing.Size(624, 25);
            this.barSub.TabIndex = 4;
            // 
            // btnSave
            // 
            this.btnSave.ForeColor = System.Drawing.Color.Black;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(76, 22);
            this.btnSave.Text = "確定(&S)";
            this.btnSave.ToolTipText = "入力されたパスワードのチェックを行い、プログラムを起動します";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.ForeColor = System.Drawing.Color.Black;
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(76, 22);
            this.btnCancel.Text = "戻る(&C)";
            this.btnCancel.ToolTipText = "入力を破棄して前の画面に戻ります";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.ForeColor = System.Drawing.Color.Black;
            this.lblMessage.Location = new System.Drawing.Point(109, 39);
            this.lblMessage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(407, 15);
            this.lblMessage.TabIndex = 5;
            this.lblMessage.Text = "この機能を使用するにはパスワードの入力が必要です。";
            // 
            // lblPassKey1
            // 
            this.lblPassKey1.AutoSize = true;
            this.lblPassKey1.ForeColor = System.Drawing.Color.Black;
            this.lblPassKey1.Location = new System.Drawing.Point(68, 64);
            this.lblPassKey1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPassKey1.Name = "lblPassKey1";
            this.lblPassKey1.Size = new System.Drawing.Size(535, 15);
            this.lblPassKey1.TabIndex = 6;
            this.lblPassKey1.Text = "下に表示される パスキー を連絡して、パスワードを取得してください。";
            this.lblPassKey1.Visible = false;
            // 
            // lblPasskey2
            // 
            this.lblPasskey2.AutoSize = true;
            this.lblPasskey2.ForeColor = System.Drawing.Color.Black;
            this.lblPasskey2.Location = new System.Drawing.Point(196, 100);
            this.lblPasskey2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPasskey2.Name = "lblPasskey2";
            this.lblPasskey2.Size = new System.Drawing.Size(103, 15);
            this.lblPasskey2.TabIndex = 7;
            this.lblPasskey2.Text = "パスキー ： ";
            this.lblPasskey2.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(168, 168);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(327, 15);
            this.label2.TabIndex = 8;
            this.label2.Text = "※英字の大文字小文字は区別してください。";
            // 
            // SFNETMENU2H
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 218);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblPasskey2);
            this.Controls.Add(this.lblPassKey1);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.barSub);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SFNETMENU2H";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "パスワード入力";
            this.barSub.ResumeLayout(false);
            this.barSub.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.ToolStrip barSub;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.ToolStripButton btnCancel;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Label lblPassKey1;
        private System.Windows.Forms.Label lblPasskey2;
        private System.Windows.Forms.Label label2;
    }
}
namespace Broadleaf.Windows.Forms
{
    partial class PMMAX02000UG
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbl_Message = new Infragistics.Win.Misc.UltraLabel();
            this.pictureBox_Icon = new System.Windows.Forms.PictureBox();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.btn_Yes = new System.Windows.Forms.Button();
            this.btn_Open = new System.Windows.Forms.Button();
            this.btn_OK = new System.Windows.Forms.Button();
            this.btn_ErrList = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Icon)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Window;
            this.panel1.Controls.Add(this.lbl_Message);
            this.panel1.Controls.Add(this.pictureBox_Icon);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(500, 136);
            this.panel1.TabIndex = 1;
            // 
            // lbl_Message
            // 
            this.lbl_Message.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lbl_Message.Location = new System.Drawing.Point(72, 24);
            this.lbl_Message.Name = "lbl_Message";
            this.lbl_Message.Size = new System.Drawing.Size(416, 99);
            this.lbl_Message.TabIndex = 1375;
            this.lbl_Message.Text = "入庫倉庫";
            // 
            // pictureBox_Icon
            // 
            this.pictureBox_Icon.Location = new System.Drawing.Point(22, 22);
            this.pictureBox_Icon.Name = "pictureBox_Icon";
            this.pictureBox_Icon.Size = new System.Drawing.Size(44, 38);
            this.pictureBox_Icon.TabIndex = 0;
            this.pictureBox_Icon.TabStop = false;
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_Cancel.Location = new System.Drawing.Point(395, 153);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(93, 29);
            this.btn_Cancel.TabIndex = 5;
            this.btn_Cancel.Text = "中止する";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // btn_Yes
            // 
            this.btn_Yes.DialogResult = System.Windows.Forms.DialogResult.No;
            this.btn_Yes.Location = new System.Drawing.Point(268, 153);
            this.btn_Yes.Name = "btn_Yes";
            this.btn_Yes.Size = new System.Drawing.Size(121, 29);
            this.btn_Yes.TabIndex = 4;
            this.btn_Yes.Text = "部品MAXに登録する";
            this.btn_Yes.UseVisualStyleBackColor = true;
            this.btn_Yes.Click += new System.EventHandler(this.btn_Yes_Click);
            // 
            // btn_Open
            // 
            this.btn_Open.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.btn_Open.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btn_Open.Location = new System.Drawing.Point(104, 153);
            this.btn_Open.Name = "btn_Open";
            this.btn_Open.Size = new System.Drawing.Size(158, 29);
            this.btn_Open.TabIndex = 3;
            this.btn_Open.Text = "チェックリストを確認する";
            this.btn_Open.UseVisualStyleBackColor = true;
            this.btn_Open.Click += new System.EventHandler(this.btn_Open_Click);
            // 
            // btn_OK
            // 
            this.btn_OK.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_OK.Location = new System.Drawing.Point(395, 153);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(93, 29);
            this.btn_OK.TabIndex = 7;
            this.btn_OK.Text = "OK";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // btn_ErrList
            // 
            this.btn_ErrList.DialogResult = System.Windows.Forms.DialogResult.No;
            this.btn_ErrList.Location = new System.Drawing.Point(238, 153);
            this.btn_ErrList.Name = "btn_ErrList";
            this.btn_ErrList.Size = new System.Drawing.Size(151, 29);
            this.btn_ErrList.TabIndex = 6;
            this.btn_ErrList.Text = "エラーリストを修正する";
            this.btn_ErrList.UseVisualStyleBackColor = true;
            this.btn_ErrList.Click += new System.EventHandler(this.btn_ErrList_Click);
            // 
            // PMMAX02000UG
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(500, 194);
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.btn_ErrList);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_Yes);
            this.Controls.Add(this.btn_Open);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PMMAX02000UG";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "確認";
            this.Load += new System.EventHandler(this.PMMAX02000UG_Load);
            this.Shown += new System.EventHandler(this.PMMAX02000UG_Shown);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PMMAX02000UG_FormClosing);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Icon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox_Icon;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Button btn_Yes;
        private System.Windows.Forms.Button btn_Open;
        private Infragistics.Win.Misc.UltraLabel lbl_Message;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.Button btn_ErrList;
    }
}
namespace Broadleaf.Windows.Forms
{
    partial class PMKHN05010UB
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
            Infragistics.Win.Appearance appearance128 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance36 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PMKHN05010UB));
            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.uCheckEditor_OptSendTarget = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.uButton_Yes = new Infragistics.Win.Misc.UltraButton();
            this.uButton_No = new Infragistics.Win.Misc.UltraButton();
            this.tArrowKeyControl1 = new Broadleaf.Library.Windows.Forms.TArrowKeyControl(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.uStatusBar_Main = new Infragistics.Win.UltraWinStatusBar.UltraStatusBar();
            this.panel_PartySalesSlipNum = new System.Windows.Forms.Panel();
            this.tEdit_PartySalesSlipNum = new Broadleaf.Library.Windows.Forms.TEdit();
            this.uLabel_PartySalesSlipNum = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel2 = new Infragistics.Win.Misc.UltraLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel_PartySalesSlipNum.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_PartySalesSlipNum)).BeginInit();
            this.SuspendLayout();
            // 
            // ultraLabel1
            // 
            this.ultraLabel1.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel1.Location = new System.Drawing.Point(64, 28);
            this.ultraLabel1.Margin = new System.Windows.Forms.Padding(4);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(219, 16);
            this.ultraLabel1.TabIndex = 0;
            this.ultraLabel1.Text = "登録してもよろしいですか？";
            // 
            // uCheckEditor_OptSendTarget
            // 
            this.uCheckEditor_OptSendTarget.Checked = true;
            this.uCheckEditor_OptSendTarget.CheckState = System.Windows.Forms.CheckState.Checked;
            this.uCheckEditor_OptSendTarget.Location = new System.Drawing.Point(68, 64);
            this.uCheckEditor_OptSendTarget.Margin = new System.Windows.Forms.Padding(4);
            this.uCheckEditor_OptSendTarget.Name = "uCheckEditor_OptSendTarget";
            this.uCheckEditor_OptSendTarget.Size = new System.Drawing.Size(200, 17);
            this.uCheckEditor_OptSendTarget.TabIndex = 1;
            this.uCheckEditor_OptSendTarget.Text = "TSPインラインで送信";
            this.uCheckEditor_OptSendTarget.KeyUp += new System.Windows.Forms.KeyEventHandler(this.PMKHN05010UA_KeyUp);
            // 
            // uButton_Yes
            // 
            this.uButton_Yes.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uButton_Yes.Location = new System.Drawing.Point(68, 119);
            this.uButton_Yes.Name = "uButton_Yes";
            this.uButton_Yes.Size = new System.Drawing.Size(100, 28);
            this.uButton_Yes.TabIndex = 3;
            this.uButton_Yes.Text = "はい(&Y)";
            this.uButton_Yes.Click += new System.EventHandler(this.uButton_Yes_Click);
            this.uButton_Yes.KeyUp += new System.Windows.Forms.KeyEventHandler(this.PMKHN05010UA_KeyUp);
            // 
            // uButton_No
            // 
            this.uButton_No.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uButton_No.Location = new System.Drawing.Point(174, 119);
            this.uButton_No.Name = "uButton_No";
            this.uButton_No.Size = new System.Drawing.Size(100, 28);
            this.uButton_No.TabIndex = 4;
            this.uButton_No.Text = "いいえ(&N)";
            this.uButton_No.Click += new System.EventHandler(this.uButton_No_Click);
            this.uButton_No.KeyUp += new System.Windows.Forms.KeyEventHandler(this.PMKHN05010UA_KeyUp);
            // 
            // tArrowKeyControl1
            // 
            this.tArrowKeyControl1.OwnerForm = this;
            this.tArrowKeyControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tRetKeyControl1_ChangeFocus);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(16, 19);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // uStatusBar_Main
            // 
            this.uStatusBar_Main.Location = new System.Drawing.Point(0, 162);
            this.uStatusBar_Main.Name = "uStatusBar_Main";
            this.uStatusBar_Main.Size = new System.Drawing.Size(305, 23);
            this.uStatusBar_Main.TabIndex = 55;
            this.uStatusBar_Main.ViewStyle = Infragistics.Win.UltraWinStatusBar.ViewStyle.Office2003;
            // 
            // panel_PartySalesSlipNum
            // 
            this.panel_PartySalesSlipNum.Controls.Add(this.tEdit_PartySalesSlipNum);
            this.panel_PartySalesSlipNum.Controls.Add(this.uLabel_PartySalesSlipNum);
            this.panel_PartySalesSlipNum.Location = new System.Drawing.Point(60, 86);
            this.panel_PartySalesSlipNum.Name = "panel_PartySalesSlipNum";
            this.panel_PartySalesSlipNum.Size = new System.Drawing.Size(232, 24);
            this.panel_PartySalesSlipNum.TabIndex = 2;
            // 
            // tEdit_PartySalesSlipNum
            // 
            appearance128.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_PartySalesSlipNum.ActiveAppearance = appearance128;
            appearance36.ForeColorDisabled = System.Drawing.SystemColors.ControlText;
            appearance36.TextHAlignAsString = "Left";
            this.tEdit_PartySalesSlipNum.Appearance = appearance36;
            this.tEdit_PartySalesSlipNum.AutoSelect = true;
            this.tEdit_PartySalesSlipNum.AutoSize = false;
            this.tEdit_PartySalesSlipNum.DataText = "";
            this.tEdit_PartySalesSlipNum.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_PartySalesSlipNum.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 12, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, true, true, true, true));
            this.tEdit_PartySalesSlipNum.ImeMode = System.Windows.Forms.ImeMode.Close;
            this.tEdit_PartySalesSlipNum.Location = new System.Drawing.Point(93, 0);
            this.tEdit_PartySalesSlipNum.MaxLength = 12;
            this.tEdit_PartySalesSlipNum.Name = "tEdit_PartySalesSlipNum";
            this.tEdit_PartySalesSlipNum.Size = new System.Drawing.Size(113, 24);
            this.tEdit_PartySalesSlipNum.TabIndex = 2;
            // 
            // uLabel_PartySalesSlipNum
            // 
            this.uLabel_PartySalesSlipNum.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uLabel_PartySalesSlipNum.Location = new System.Drawing.Point(4, 4);
            this.uLabel_PartySalesSlipNum.Margin = new System.Windows.Forms.Padding(4);
            this.uLabel_PartySalesSlipNum.Name = "uLabel_PartySalesSlipNum";
            this.uLabel_PartySalesSlipNum.Size = new System.Drawing.Size(87, 18);
            this.uLabel_PartySalesSlipNum.TabIndex = 57;
            this.uLabel_PartySalesSlipNum.Text = "指示書番号";
            // 
            // ultraLabel2
            // 
            this.ultraLabel2.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel2.Location = new System.Drawing.Point(64, 19);
            this.ultraLabel2.Margin = new System.Windows.Forms.Padding(4);
            this.ultraLabel2.Name = "ultraLabel2";
            this.ultraLabel2.Size = new System.Drawing.Size(233, 45);
            this.ultraLabel2.TabIndex = 57;
            this.ultraLabel2.Text = "登録してもよろしいですか？";
            this.ultraLabel2.Visible = false;
            // 
            // PMKHN05010UB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(305, 185);
            this.Controls.Add(this.ultraLabel2);
            this.Controls.Add(this.panel_PartySalesSlipNum);
            this.Controls.Add(this.uStatusBar_Main);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.uButton_No);
            this.Controls.Add(this.uButton_Yes);
            this.Controls.Add(this.uCheckEditor_OptSendTarget);
            this.Controls.Add(this.ultraLabel1);
            this.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PMKHN05010UB";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "データ送信確認";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.PMKHN05010UB_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel_PartySalesSlipNum.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_PartySalesSlipNum)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.Misc.UltraLabel ultraLabel1;
        private Infragistics.Win.UltraWinEditors.UltraCheckEditor uCheckEditor_OptSendTarget;
        private Infragistics.Win.Misc.UltraButton uButton_Yes;
        private Infragistics.Win.Misc.UltraButton uButton_No;
        private Broadleaf.Library.Windows.Forms.TArrowKeyControl tArrowKeyControl1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Infragistics.Win.UltraWinStatusBar.UltraStatusBar uStatusBar_Main;
        private System.Windows.Forms.Panel panel_PartySalesSlipNum;
        private Infragistics.Win.Misc.UltraLabel uLabel_PartySalesSlipNum;
        private Broadleaf.Library.Windows.Forms.TEdit tEdit_PartySalesSlipNum;
        private Infragistics.Win.Misc.UltraLabel ultraLabel2;

    }
}


namespace Broadleaf.Windows.Forms
{
    partial class MAZAI05130UE
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
            Infragistics.Win.Appearance appearance112 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance113 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MAZAI05130UE));
            this.panel1 = new System.Windows.Forms.Panel();
            this.tEdit_GoodsNo = new Broadleaf.Library.Windows.Forms.TEdit();
            this.ultraStatusBar1 = new Infragistics.Win.UltraWinStatusBar.UltraStatusBar();
            this.CloseButton = new Infragistics.Win.Misc.UltraButton();
            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tRetKeyControl = new Broadleaf.Library.Windows.Forms.TRetKeyControl(this.components);
            this.tArrowKeyControl = new Broadleaf.Library.Windows.Forms.TArrowKeyControl(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_GoodsNo)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.panel1.Controls.Add(this.tEdit_GoodsNo);
            this.panel1.Controls.Add(this.ultraStatusBar1);
            this.panel1.Controls.Add(this.CloseButton);
            this.panel1.Controls.Add(this.ultraLabel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(307, 118);
            this.panel1.TabIndex = 0;
            // 
            // tEdit_GoodsNo
            // 
            appearance112.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_GoodsNo.ActiveAppearance = appearance112;
            appearance113.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance113.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance113.Cursor = System.Windows.Forms.Cursors.Default;
            appearance113.ForeColorDisabled = System.Drawing.Color.Black;
            this.tEdit_GoodsNo.Appearance = appearance113;
            this.tEdit_GoodsNo.AutoSelect = true;
            this.tEdit_GoodsNo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tEdit_GoodsNo.Cursor = System.Windows.Forms.Cursors.Default;
            this.tEdit_GoodsNo.DataText = "";
            this.tEdit_GoodsNo.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_GoodsNo.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 24, new Broadleaf.Library.Windows.Forms.TEnableChars(false, true, true, true, true, true, true));
            this.tEdit_GoodsNo.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tEdit_GoodsNo.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tEdit_GoodsNo.Location = new System.Drawing.Point(74, 18);
            this.tEdit_GoodsNo.MaxLength = 24;
            this.tEdit_GoodsNo.Name = "tEdit_GoodsNo";
            this.tEdit_GoodsNo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tEdit_GoodsNo.Size = new System.Drawing.Size(203, 24);
            this.tEdit_GoodsNo.TabIndex = 77;
            // 
            // ultraStatusBar1
            // 
            this.ultraStatusBar1.Location = new System.Drawing.Point(0, 95);
            this.ultraStatusBar1.Name = "ultraStatusBar1";
            this.ultraStatusBar1.Size = new System.Drawing.Size(307, 23);
            this.ultraStatusBar1.TabIndex = 76;
            this.ultraStatusBar1.ViewStyle = Infragistics.Win.UltraWinStatusBar.ViewStyle.Office2003;
            // 
            // CloseButton
            // 
            this.CloseButton.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F);
            this.CloseButton.Location = new System.Drawing.Point(198, 56);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(79, 25);
            this.CloseButton.TabIndex = 6;
            this.CloseButton.Text = "戻る(&F11)";
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // ultraLabel1
            // 
            appearance1.TextVAlignAsString = "Middle";
            this.ultraLabel1.Appearance = appearance1;
            this.ultraLabel1.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.ultraLabel1.Location = new System.Drawing.Point(16, 18);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(45, 24);
            this.ultraLabel1.TabIndex = 0;
            this.ultraLabel1.Text = "品番";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // tRetKeyControl
            // 
            this.tRetKeyControl.OwnerForm = this;
            this.tRetKeyControl.Style = Broadleaf.Library.Windows.Forms.emFocusStyle.ByTab;
            this.tRetKeyControl.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tRetKeyControl_ChangeFocus);
            // 
            // tArrowKeyControl
            // 
            this.tArrowKeyControl.OwnerForm = this;
            this.tArrowKeyControl.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tRetKeyControl_ChangeFocus);
            // 
            // MAZAI05130UE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(307, 118);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MAZAI05130UE";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "品番検索";
            this.Load += new System.EventHandler(this.MAZAI05130UDA_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MAZAI05130UE_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_GoodsNo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Infragistics.Win.Misc.UltraLabel ultraLabel1;
        private Infragistics.Win.Misc.UltraButton CloseButton;
        private Infragistics.Win.UltraWinStatusBar.UltraStatusBar ultraStatusBar1;
        private Broadleaf.Library.Windows.Forms.TEdit tEdit_GoodsNo;
        private System.Windows.Forms.Timer timer1;
        private Broadleaf.Library.Windows.Forms.TRetKeyControl tRetKeyControl;
        private Broadleaf.Library.Windows.Forms.TArrowKeyControl tArrowKeyControl;
    }
}
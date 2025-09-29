namespace Broadleaf.Windows.Forms
{
    partial class OthreSettingForm
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
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OthreSettingForm));
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            this.Section_ComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.label1 = new System.Windows.Forms.Label();
            this.info_pictureBox = new Infragistics.Win.UltraWinEditors.UltraPictureBox();
            this.StockInfo_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.label2 = new System.Windows.Forms.Label();
            this.Cancel_Button = new Infragistics.Win.Misc.UltraButton();
            this.Save_Button = new Infragistics.Win.Misc.UltraButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ultraToolTipManager1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipManager(this.components);
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tRetKeyControl1 = new Broadleaf.Library.Windows.Forms.TRetKeyControl(this.components);
            this.tArrowKeyControl1 = new Broadleaf.Library.Windows.Forms.TArrowKeyControl(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.Section_ComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StockInfo_tComboEditor)).BeginInit();
            this.panel2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Section_ComboEditor
            // 
            this.Section_ComboEditor.ActiveAppearance = appearance1;
            this.Section_ComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.Section_ComboEditor.Location = new System.Drawing.Point(88, 9);
            this.Section_ComboEditor.Margin = new System.Windows.Forms.Padding(4);
            this.Section_ComboEditor.Name = "Section_ComboEditor";
            this.Section_ComboEditor.Size = new System.Drawing.Size(154, 24);
            this.Section_ComboEditor.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 10);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "拠点";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // info_pictureBox
            // 
            this.info_pictureBox.BorderShadowColor = System.Drawing.Color.Empty;
            this.info_pictureBox.Cursor = System.Windows.Forms.Cursors.Help;
            this.info_pictureBox.Image = ((object)(resources.GetObject("info_pictureBox.Image")));
            this.info_pictureBox.ImageTransparentColor = System.Drawing.Color.Cyan;
            this.info_pictureBox.Location = new System.Drawing.Point(249, 20);
            this.info_pictureBox.Name = "info_pictureBox";
            this.info_pictureBox.Size = new System.Drawing.Size(24, 24);
            this.info_pictureBox.TabIndex = 7;
            // 
            // StockInfo_tComboEditor
            // 
            this.StockInfo_tComboEditor.ActiveAppearance = appearance2;
            this.StockInfo_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.StockInfo_tComboEditor.Location = new System.Drawing.Point(88, 18);
            this.StockInfo_tComboEditor.Margin = new System.Windows.Forms.Padding(4);
            this.StockInfo_tComboEditor.Name = "StockInfo_tComboEditor";
            this.StockInfo_tComboEditor.Size = new System.Drawing.Size(154, 24);
            this.StockInfo_tComboEditor.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(12, 20);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "在庫状態";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Cancel_Button
            // 
            this.Cancel_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            appearance3.ForeColor = System.Drawing.Color.Black;
            this.Cancel_Button.Appearance = appearance3;
            this.Cancel_Button.HotTracking = true;
            this.Cancel_Button.ImageSize = new System.Drawing.Size(25, 25);
            this.Cancel_Button.Location = new System.Drawing.Point(339, 9);
            this.Cancel_Button.Name = "Cancel_Button";
            this.Cancel_Button.Size = new System.Drawing.Size(96, 34);
            this.Cancel_Button.TabIndex = 10;
            this.Cancel_Button.Text = "閉じる(&X)";
            this.Cancel_Button.Click += new System.EventHandler(this.Cancel_Button_Click);
            // 
            // Save_Button
            // 
            this.Save_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            appearance4.ForeColor = System.Drawing.Color.Black;
            this.Save_Button.Appearance = appearance4;
            this.Save_Button.HotTracking = true;
            this.Save_Button.ImageSize = new System.Drawing.Size(25, 25);
            this.Save_Button.Location = new System.Drawing.Point(243, 9);
            this.Save_Button.Name = "Save_Button";
            this.Save_Button.Size = new System.Drawing.Size(96, 34);
            this.Save_Button.TabIndex = 9;
            this.Save_Button.Text = "保存(&S)";
            this.Save_Button.Click += new System.EventHandler(this.Save_Button_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.Cancel_Button);
            this.panel2.Controls.Add(this.Save_Button);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 96);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(442, 48);
            this.panel2.TabIndex = 8;
            // 
            // ultraToolTipManager1
            // 
            appearance5.FontData.Name = "ＭＳ ゴシック";
            appearance5.FontData.SizeInPoints = 11.25F;
            this.ultraToolTipManager1.Appearance = appearance5;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.info_pictureBox);
            this.groupBox3.Controls.Add(this.StockInfo_tComboEditor);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(0, 42);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(442, 54);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "設定";
            // 
            // tRetKeyControl1
            // 
            this.tRetKeyControl1.OwnerForm = this;
            this.tRetKeyControl1.Style = Broadleaf.Library.Windows.Forms.emFocusStyle.ByTab;
            this.tRetKeyControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tRetKeyControl1_ChangeFocus);
            // 
            // tArrowKeyControl1
            // 
            this.tArrowKeyControl1.OwnerForm = this;
            this.tArrowKeyControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tRetKeyControl1_ChangeFocus);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.Section_ComboEditor);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(442, 42);
            this.panel1.TabIndex = 9;
            // 
            // OthreSettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 144);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OthreSettingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "動作設定";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OthreSettingForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.Section_ComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StockInfo_tComboEditor)).EndInit();
            this.panel2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Broadleaf.Library.Windows.Forms.TComboEditor Section_ComboEditor;
        private System.Windows.Forms.Label label1;
        private Broadleaf.Library.Windows.Forms.TComboEditor StockInfo_tComboEditor;
        private System.Windows.Forms.Label label2;
        private Infragistics.Win.Misc.UltraButton Cancel_Button;
        private Infragistics.Win.Misc.UltraButton Save_Button;
        private Infragistics.Win.UltraWinEditors.UltraPictureBox info_pictureBox;
        private System.Windows.Forms.Panel panel2;
        private Infragistics.Win.UltraWinToolTip.UltraToolTipManager ultraToolTipManager1;
        private System.Windows.Forms.GroupBox groupBox3;
        private Broadleaf.Library.Windows.Forms.TRetKeyControl tRetKeyControl1;
        private Broadleaf.Library.Windows.Forms.TArrowKeyControl tArrowKeyControl1;
        private System.Windows.Forms.Panel panel1;
    }
}
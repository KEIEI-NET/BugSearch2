namespace Broadleaf.Windows.Forms
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
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            this.ultraButton1 = new Infragistics.Win.Misc.UltraButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.IDmGetDlg = new Infragistics.Win.Misc.UltraButton();
            this.label3 = new System.Windows.Forms.Label();
            this.tNedit2 = new Broadleaf.Library.Windows.Forms.TNedit();
            this.label2 = new System.Windows.Forms.Label();
            this.tNedit1 = new Broadleaf.Library.Windows.Forms.TNedit();
            this.ultraButton6 = new Infragistics.Win.Misc.UltraButton();
            this.ultraButton5 = new Infragistics.Win.Misc.UltraButton();
            this.ultraButton4 = new Infragistics.Win.Misc.UltraButton();
            this.label1 = new System.Windows.Forms.Label();
            this.ultraButton3 = new Infragistics.Win.Misc.UltraButton();
            this.ultraButton2 = new Infragistics.Win.Misc.UltraButton();
            this.LogMsgBox = new System.Windows.Forms.RichTextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tRetKeyControl1 = new Broadleaf.Library.Windows.Forms.TRetKeyControl(this.components);
            this.tArrowKeyControl1 = new Broadleaf.Library.Windows.Forms.TArrowKeyControl(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ultraCheckEditor1 = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ultraButton1
            // 
            this.ultraButton1.Location = new System.Drawing.Point(5, 39);
            this.ultraButton1.Name = "ultraButton1";
            this.ultraButton1.Size = new System.Drawing.Size(127, 40);
            this.ultraButton1.TabIndex = 0;
            this.ultraButton1.Text = "ライブラリ初期化";
            this.ultraButton1.Click += new System.EventHandler(this.ultraButton1_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.Color.LightCyan;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.LightBlue;
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel1.Controls.Add(this.ultraButton4);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.ultraButton3);
            this.splitContainer1.Panel1.Controls.Add(this.ultraButton2);
            this.splitContainer1.Panel1.Controls.Add(this.ultraButton1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.LogMsgBox);
            this.splitContainer1.Size = new System.Drawing.Size(692, 541);
            this.splitContainer1.SplitterDistance = 410;
            this.splitContainer1.TabIndex = 3;
            // 
            // IDmGetDlg
            // 
            this.IDmGetDlg.Location = new System.Drawing.Point(141, 64);
            this.IDmGetDlg.Name = "IDmGetDlg";
            this.IDmGetDlg.Size = new System.Drawing.Size(127, 40);
            this.IDmGetDlg.TabIndex = 12;
            this.IDmGetDlg.Text = "IDm取得ﾀﾞｲｱﾛｸﾞ";
            this.IDmGetDlg.Click += new System.EventHandler(this.IDmGetDlg_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 12);
            this.label3.TabIndex = 11;
            this.label3.Text = "RetryCnt";
            // 
            // tNedit2
            // 
            this.tNedit2.ActiveAppearance = appearance9;
            this.tNedit2.AutoSelect = true;
            this.tNedit2.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit2.DataText = "0";
            this.tNedit2.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, true);
            this.tNedit2.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 12, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.tNedit2.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tNedit2.Location = new System.Drawing.Point(72, 39);
            this.tNedit2.MaxLength = 12;
            this.tNedit2.Name = "tNedit2";
            this.tNedit2.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.tNedit2.Size = new System.Drawing.Size(51, 21);
            this.tNedit2.TabIndex = 5;
            this.tNedit2.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 12);
            this.label2.TabIndex = 9;
            this.label2.Text = "Interval";
            // 
            // tNedit1
            // 
            this.tNedit1.ActiveAppearance = appearance10;
            this.tNedit1.AutoSelect = true;
            this.tNedit1.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit1.DataText = "500";
            this.tNedit1.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, true);
            this.tNedit1.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 12, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.tNedit1.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tNedit1.Location = new System.Drawing.Point(72, 12);
            this.tNedit1.MaxLength = 12;
            this.tNedit1.Name = "tNedit1";
            this.tNedit1.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.tNedit1.Size = new System.Drawing.Size(51, 21);
            this.tNedit1.TabIndex = 4;
            this.tNedit1.Text = "500";
            // 
            // ultraButton6
            // 
            this.ultraButton6.Location = new System.Drawing.Point(8, 114);
            this.ultraButton6.Name = "ultraButton6";
            this.ultraButton6.Size = new System.Drawing.Size(127, 40);
            this.ultraButton6.TabIndex = 7;
            this.ultraButton6.Text = "連続ポーリング終了(FelicaAcs)";
            this.ultraButton6.Click += new System.EventHandler(this.ultraButton6_Click);
            // 
            // ultraButton5
            // 
            this.ultraButton5.Location = new System.Drawing.Point(8, 64);
            this.ultraButton5.Name = "ultraButton5";
            this.ultraButton5.Size = new System.Drawing.Size(127, 40);
            this.ultraButton5.TabIndex = 6;
            this.ultraButton5.Text = "連続ポーリング開始(FelicaAcs)";
            this.ultraButton5.Click += new System.EventHandler(this.ultraButton5_Click);
            // 
            // ultraButton4
            // 
            this.ultraButton4.Location = new System.Drawing.Point(5, 185);
            this.ultraButton4.Name = "ultraButton4";
            this.ultraButton4.Size = new System.Drawing.Size(127, 40);
            this.ultraButton4.TabIndex = 3;
            this.ultraButton4.Text = "自作連続ポーリング";
            this.ultraButton4.Click += new System.EventHandler(this.ultraButton4_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(311, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "このフォームはFeliCaアクセスクラスの開発者用テストフォームです。";
            // 
            // ultraButton3
            // 
            this.ultraButton3.Location = new System.Drawing.Point(5, 89);
            this.ultraButton3.Name = "ultraButton3";
            this.ultraButton3.Size = new System.Drawing.Size(127, 40);
            this.ultraButton3.TabIndex = 1;
            this.ultraButton3.Text = "ポートオープン(自動)";
            this.ultraButton3.Click += new System.EventHandler(this.ultraButton3_Click);
            // 
            // ultraButton2
            // 
            this.ultraButton2.Location = new System.Drawing.Point(5, 139);
            this.ultraButton2.Name = "ultraButton2";
            this.ultraButton2.Size = new System.Drawing.Size(127, 40);
            this.ultraButton2.TabIndex = 2;
            this.ultraButton2.Text = "ポーリング(IDm取得)";
            this.ultraButton2.Click += new System.EventHandler(this.ultraButton2_Click);
            // 
            // LogMsgBox
            // 
            this.LogMsgBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LogMsgBox.Location = new System.Drawing.Point(0, 0);
            this.LogMsgBox.Name = "LogMsgBox";
            this.LogMsgBox.Size = new System.Drawing.Size(692, 127);
            this.LogMsgBox.TabIndex = 0;
            this.LogMsgBox.Text = "";
            // 
            // timer1
            // 
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // tRetKeyControl1
            // 
            this.tRetKeyControl1.OwnerForm = this;
            // 
            // tArrowKeyControl1
            // 
            this.tArrowKeyControl1.OwnerForm = this;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ultraCheckEditor1);
            this.groupBox1.Controls.Add(this.ultraButton5);
            this.groupBox1.Controls.Add(this.IDmGetDlg);
            this.groupBox1.Controls.Add(this.ultraButton6);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.tNedit1);
            this.groupBox1.Controls.Add(this.tNedit2);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(138, 25);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(285, 200);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            // 
            // ultraCheckEditor1
            // 
            this.ultraCheckEditor1.Checked = true;
            this.ultraCheckEditor1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ultraCheckEditor1.Location = new System.Drawing.Point(141, 12);
            this.ultraCheckEditor1.Name = "ultraCheckEditor1";
            this.ultraCheckEditor1.Size = new System.Drawing.Size(120, 20);
            this.ultraCheckEditor1.TabIndex = 13;
            this.ultraCheckEditor1.Text = "DlgErrMsgView";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(692, 541);
            this.Controls.Add(this.splitContainer1);
            this.MinimumSize = new System.Drawing.Size(700, 575);
            this.Name = "Form1";
            this.Text = "FeliCaアクセス検証ツール";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tNedit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.Misc.UltraButton ultraButton1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.RichTextBox LogMsgBox;
        private Infragistics.Win.Misc.UltraButton ultraButton2;
        private Infragistics.Win.Misc.UltraButton ultraButton3;
        private System.Windows.Forms.Label label1;
        private Infragistics.Win.Misc.UltraButton ultraButton4;
        private System.Windows.Forms.Timer timer1;
        private Infragistics.Win.Misc.UltraButton ultraButton5;
        private System.Windows.Forms.Label label2;
        private Broadleaf.Library.Windows.Forms.TNedit tNedit1;
        private Infragistics.Win.Misc.UltraButton ultraButton6;
        private System.Windows.Forms.Label label3;
        private Broadleaf.Library.Windows.Forms.TNedit tNedit2;
        private Broadleaf.Library.Windows.Forms.TRetKeyControl tRetKeyControl1;
        private Broadleaf.Library.Windows.Forms.TArrowKeyControl tArrowKeyControl1;
        private Infragistics.Win.Misc.UltraButton IDmGetDlg;
        private System.Windows.Forms.GroupBox groupBox1;
        private Infragistics.Win.UltraWinEditors.UltraCheckEditor ultraCheckEditor1;
    }
}


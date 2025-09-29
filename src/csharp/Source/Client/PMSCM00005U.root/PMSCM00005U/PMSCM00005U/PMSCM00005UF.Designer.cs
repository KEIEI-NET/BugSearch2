namespace Broadleaf.Windows.Forms
{
    partial class PMSCM00005UF
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
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance186 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance65 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance66 = new Infragistics.Win.Appearance();
            this.checkEditor = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.setButton = new Infragistics.Win.Misc.UltraButton();
            this.closeButton = new Infragistics.Win.Misc.UltraButton();
            this.checkSound = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.uLabel_Sound = new Infragistics.Win.Misc.UltraLabel();
            this.uLabel_SoundSec = new Infragistics.Win.Misc.UltraLabel();
            this.uLabel_SoundPath = new Infragistics.Win.Misc.UltraLabel();
            this.uLabel_SoundNotes = new Infragistics.Win.Misc.UltraLabel();
            this.tEdit_SoundPath = new Broadleaf.Library.Windows.Forms.TEdit();
            this.tNedit_SoundSec = new Broadleaf.Library.Windows.Forms.TNedit();
            this.uButton_SoundGuide = new Infragistics.Win.Misc.UltraButton();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.tRetKeyControl1 = new Broadleaf.Library.Windows.Forms.TRetKeyControl(this.components);
            this.tArrowKeyControl1 = new Broadleaf.Library.Windows.Forms.TArrowKeyControl(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SoundPath)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_SoundSec)).BeginInit();
            this.SuspendLayout();
            // 
            // checkEditor
            // 
            this.checkEditor.Location = new System.Drawing.Point(31, 30);
            this.checkEditor.Name = "checkEditor";
            this.checkEditor.Size = new System.Drawing.Size(198, 18);
            this.checkEditor.TabIndex = 0;
            this.checkEditor.Text = "新着情報に自動回答を表示する";
            // 
            // setButton
            // 
            this.setButton.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.setButton.Location = new System.Drawing.Point(266, 160);
            this.setButton.Margin = new System.Windows.Forms.Padding(1);
            this.setButton.Name = "setButton";
            this.setButton.Size = new System.Drawing.Size(75, 22);
            this.setButton.TabIndex = 5;
            this.setButton.Text = "設定(&S)";
            this.setButton.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.setButton.Click += new System.EventHandler(this.setButton_Click);
            // 
            // closeButton
            // 
            this.closeButton.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.closeButton.Location = new System.Drawing.Point(345, 160);
            this.closeButton.Margin = new System.Windows.Forms.Padding(1);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(75, 22);
            this.closeButton.TabIndex = 6;
            this.closeButton.Text = "閉じる(&X)";
            this.closeButton.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // checkSound
            // 
            this.checkSound.Location = new System.Drawing.Point(31, 54);
            this.checkSound.Name = "checkSound";
            this.checkSound.Size = new System.Drawing.Size(198, 18);
            this.checkSound.TabIndex = 1;
            this.checkSound.Text = "新着情報表示時に着信音を鳴らす";
            this.checkSound.CheckedChanged += new System.EventHandler(this.checkSound_CheckedChanged);
            // 
            // uLabel_Sound
            // 
            appearance2.TextVAlignAsString = "Middle";
            this.uLabel_Sound.Appearance = appearance2;
            this.uLabel_Sound.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uLabel_Sound.Location = new System.Drawing.Point(48, 81);
            this.uLabel_Sound.Margin = new System.Windows.Forms.Padding(4);
            this.uLabel_Sound.Name = "uLabel_Sound";
            this.uLabel_Sound.Size = new System.Drawing.Size(60, 18);
            this.uLabel_Sound.TabIndex = 182;
            this.uLabel_Sound.Text = "再生秒数";
            // 
            // uLabel_SoundSec
            // 
            appearance3.TextVAlignAsString = "Middle";
            this.uLabel_SoundSec.Appearance = appearance3;
            this.uLabel_SoundSec.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uLabel_SoundSec.Location = new System.Drawing.Point(140, 81);
            this.uLabel_SoundSec.Margin = new System.Windows.Forms.Padding(4);
            this.uLabel_SoundSec.Name = "uLabel_SoundSec";
            this.uLabel_SoundSec.Size = new System.Drawing.Size(20, 18);
            this.uLabel_SoundSec.TabIndex = 183;
            this.uLabel_SoundSec.Text = "秒";
            // 
            // uLabel_SoundPath
            // 
            appearance4.TextVAlignAsString = "Middle";
            this.uLabel_SoundPath.Appearance = appearance4;
            this.uLabel_SoundPath.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uLabel_SoundPath.Location = new System.Drawing.Point(48, 106);
            this.uLabel_SoundPath.Margin = new System.Windows.Forms.Padding(4);
            this.uLabel_SoundPath.Name = "uLabel_SoundPath";
            this.uLabel_SoundPath.Size = new System.Drawing.Size(60, 18);
            this.uLabel_SoundPath.TabIndex = 184;
            this.uLabel_SoundPath.Text = "着信音";
            // 
            // uLabel_SoundNotes
            // 
            appearance5.ForeColor = System.Drawing.Color.Red;
            appearance5.TextVAlignAsString = "Middle";
            this.uLabel_SoundNotes.Appearance = appearance5;
            this.uLabel_SoundNotes.AutoSize = true;
            this.uLabel_SoundNotes.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uLabel_SoundNotes.Location = new System.Drawing.Point(144, 133);
            this.uLabel_SoundNotes.Margin = new System.Windows.Forms.Padding(4);
            this.uLabel_SoundNotes.Name = "uLabel_SoundNotes";
            this.uLabel_SoundNotes.Size = new System.Drawing.Size(276, 14);
            this.uLabel_SoundNotes.TabIndex = 185;
            this.uLabel_SoundNotes.Text = "未設定時は、標準のメール着信音を再生します。";
            // 
            // tEdit_SoundPath
            // 
            appearance186.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_SoundPath.ActiveAppearance = appearance186;
            this.tEdit_SoundPath.AutoSelect = true;
            this.tEdit_SoundPath.AutoSize = false;
            this.tEdit_SoundPath.DataText = "";
            this.tEdit_SoundPath.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_SoundPath.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 300, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, true, true, true, true));
            this.tEdit_SoundPath.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tEdit_SoundPath.ImeMode = System.Windows.Forms.ImeMode.Close;
            this.tEdit_SoundPath.Location = new System.Drawing.Point(106, 105);
            this.tEdit_SoundPath.MaxLength = 300;
            this.tEdit_SoundPath.Name = "tEdit_SoundPath";
            this.tEdit_SoundPath.Size = new System.Drawing.Size(290, 21);
            this.tEdit_SoundPath.TabIndex = 3;
            // 
            // tNedit_SoundSec
            // 
            appearance65.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tNedit_SoundSec.ActiveAppearance = appearance65;
            appearance66.ForeColorDisabled = System.Drawing.Color.Black;
            appearance66.TextHAlignAsString = "Right";
            this.tNedit_SoundSec.Appearance = appearance66;
            this.tNedit_SoundSec.AutoSelect = true;
            this.tNedit_SoundSec.AutoSize = false;
            this.tNedit_SoundSec.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_SoundSec.DataText = "";
            this.tNedit_SoundSec.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_SoundSec.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 2, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_SoundSec.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tNedit_SoundSec.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tNedit_SoundSec.Location = new System.Drawing.Point(106, 78);
            this.tNedit_SoundSec.MaxLength = 2;
            this.tNedit_SoundSec.Name = "tNedit_SoundSec";
            this.tNedit_SoundSec.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.tNedit_SoundSec.Size = new System.Drawing.Size(30, 21);
            this.tNedit_SoundSec.TabIndex = 2;
            // 
            // uButton_SoundGuide
            // 
            this.uButton_SoundGuide.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uButton_SoundGuide.Location = new System.Drawing.Point(398, 103);
            this.uButton_SoundGuide.Name = "uButton_SoundGuide";
            this.uButton_SoundGuide.Size = new System.Drawing.Size(24, 24);
            this.uButton_SoundGuide.TabIndex = 4;
            this.uButton_SoundGuide.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.uButton_SoundGuide.Click += new System.EventHandler(this.uButton_SoundGuide_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "サウンドファイル(*.wav)|*.wav";
            this.openFileDialog.RestoreDirectory = true;
            this.openFileDialog.Title = "着信音設定";
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
            // 
            // PMSCM00005UF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(254)))));
            this.ClientSize = new System.Drawing.Size(444, 192);
            this.Controls.Add(this.uButton_SoundGuide);
            this.Controls.Add(this.tNedit_SoundSec);
            this.Controls.Add(this.tEdit_SoundPath);
            this.Controls.Add(this.uLabel_SoundNotes);
            this.Controls.Add(this.uLabel_SoundPath);
            this.Controls.Add(this.uLabel_SoundSec);
            this.Controls.Add(this.uLabel_Sound);
            this.Controls.Add(this.checkSound);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.setButton);
            this.Controls.Add(this.checkEditor);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "PMSCM00005UF";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "動作設定";
            this.Shown += new System.EventHandler(this.PMSCM00005UF_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SoundPath)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_SoundSec)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Infragistics.Win.UltraWinEditors.UltraCheckEditor checkEditor;
        private Infragistics.Win.Misc.UltraButton setButton;
        private Infragistics.Win.Misc.UltraButton closeButton;
        private Infragistics.Win.UltraWinEditors.UltraCheckEditor checkSound;
        private Infragistics.Win.Misc.UltraLabel uLabel_Sound;
        private Infragistics.Win.Misc.UltraLabel uLabel_SoundSec;
        private Infragistics.Win.Misc.UltraLabel uLabel_SoundPath;
        private Infragistics.Win.Misc.UltraLabel uLabel_SoundNotes;
        private Broadleaf.Library.Windows.Forms.TEdit tEdit_SoundPath;
        private Broadleaf.Library.Windows.Forms.TNedit tNedit_SoundSec;
        private Infragistics.Win.Misc.UltraButton uButton_SoundGuide;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private Broadleaf.Library.Windows.Forms.TRetKeyControl tRetKeyControl1;
        private Broadleaf.Library.Windows.Forms.TArrowKeyControl tArrowKeyControl1;
    }
}
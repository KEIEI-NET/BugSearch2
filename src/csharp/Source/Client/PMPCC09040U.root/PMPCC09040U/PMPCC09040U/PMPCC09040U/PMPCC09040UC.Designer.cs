namespace Broadleaf.Windows.Forms
{

    /// <summary>
    ///Tab名のフォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Node        : Tab名のフォームクラスクラスです。</br>
    /// <br>Programmer  : 黄海霞</br>
    /// <br>Date        : 2011.07.20</br>
    /// </remarks>
    partial class PMPCC09040UC
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
            Infragistics.Win.Appearance appearance140 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance131 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance132 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PMPCC09040UC));
            this.TabName_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.Name_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.Cancel_Button = new Infragistics.Win.Misc.UltraButton();
            this.Save_Button = new Infragistics.Win.Misc.UltraButton();
            this.Delete_Button = new Infragistics.Win.Misc.UltraButton();
            this.tArrowKeyControl1 = new Broadleaf.Library.Windows.Forms.TArrowKeyControl(this.components);
            this.tRetKeyControl1 = new Broadleaf.Library.Windows.Forms.TRetKeyControl(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.Name_tEdit)).BeginInit();
            this.SuspendLayout();
            // 
            // TabName_Title_Label
            // 
            appearance1.TextVAlignAsString = "Middle";
            this.TabName_Title_Label.Appearance = appearance1;
            this.TabName_Title_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.TabName_Title_Label.Location = new System.Drawing.Point(34, 12);
            this.TabName_Title_Label.Name = "TabName_Title_Label";
            this.TabName_Title_Label.Size = new System.Drawing.Size(257, 24);
            this.TabName_Title_Label.TabIndex = 4;
            this.TabName_Title_Label.Text = "新しいTab名を入力して下さい";
            // 
            // ultraLabel1
            // 
            appearance140.TextVAlignAsString = "Middle";
            this.ultraLabel1.Appearance = appearance140;
            this.ultraLabel1.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel1.Location = new System.Drawing.Point(34, 72);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(158, 24);
            this.ultraLabel1.TabIndex = 5;
            // 
            // Name_tEdit
            // 
            appearance131.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.Name_tEdit.ActiveAppearance = appearance131;
            appearance132.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance132.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance132.ForeColorDisabled = System.Drawing.Color.Black;
            this.Name_tEdit.Appearance = appearance132;
            this.Name_tEdit.AutoSelect = true;
            this.Name_tEdit.AutoSize = false;
            this.Name_tEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.Name_tEdit.CheckEmpty = true;
            this.Name_tEdit.DataText = "";
            this.Name_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.Name_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 16, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, true, true, true, true));
            this.Name_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.Name_tEdit.Location = new System.Drawing.Point(34, 42);
            this.Name_tEdit.MaxLength = 16;
            this.Name_tEdit.Name = "Name_tEdit";
            this.Name_tEdit.Size = new System.Drawing.Size(270, 24);
            this.Name_tEdit.TabIndex = 6;
            // 
            // Cancel_Button
            // 
            this.Cancel_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Cancel_Button.Location = new System.Drawing.Point(307, 94);
            this.Cancel_Button.Name = "Cancel_Button";
            this.Cancel_Button.Size = new System.Drawing.Size(146, 34);
            this.Cancel_Button.TabIndex = 9;
            this.Cancel_Button.Text = "キャンセル(&X)";
            this.Cancel_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Cancel_Button.Click += new System.EventHandler(this.Cancel_Button_Click);
            // 
            // Save_Button
            // 
            this.Save_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Save_Button.Location = new System.Drawing.Point(174, 94);
            this.Save_Button.Name = "Save_Button";
            this.Save_Button.Size = new System.Drawing.Size(125, 34);
            this.Save_Button.TabIndex = 8;
            this.Save_Button.Text = "確定(&C)";
            this.Save_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Save_Button.Click += new System.EventHandler(this.Save_Button_Click);
            // 
            // Delete_Button
            // 
            this.Delete_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Delete_Button.Location = new System.Drawing.Point(43, 94);
            this.Delete_Button.Name = "Delete_Button";
            this.Delete_Button.Size = new System.Drawing.Size(125, 34);
            this.Delete_Button.TabIndex = 7;
            this.Delete_Button.Text = "削除(&D)";
            this.Delete_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Delete_Button.Click += new System.EventHandler(this.Delete_Button_Click);
            // 
            // tArrowKeyControl1
            // 
            this.tArrowKeyControl1.OwnerForm = this;
            // 
            // tRetKeyControl1
            // 
            this.tRetKeyControl1.OwnerForm = this;
            this.tRetKeyControl1.Style = Broadleaf.Library.Windows.Forms.emFocusStyle.ByTab;
            // 
            // PMPCC09040UC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(480, 161);
            this.Controls.Add(this.Cancel_Button);
            this.Controls.Add(this.Save_Button);
            this.Controls.Add(this.Delete_Button);
            this.Controls.Add(this.Name_tEdit);
            this.Controls.Add(this.ultraLabel1);
            this.Controls.Add(this.TabName_Title_Label);
            this.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.Name = "PMPCC09040UC";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "TAB名変更";
            this.Load += new System.EventHandler(this.PMPCC09040UC_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Name_tEdit)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.Misc.UltraLabel TabName_Title_Label;
        private Infragistics.Win.Misc.UltraLabel ultraLabel1;
        private Broadleaf.Library.Windows.Forms.TEdit Name_tEdit;
        private Infragistics.Win.Misc.UltraButton Cancel_Button;
        private Infragistics.Win.Misc.UltraButton Save_Button;
        private Infragistics.Win.Misc.UltraButton Delete_Button;
        private Broadleaf.Library.Windows.Forms.TArrowKeyControl tArrowKeyControl1;
        private Broadleaf.Library.Windows.Forms.TRetKeyControl tRetKeyControl1;
    }
}
namespace Broadleaf.Windows.Forms
{
    partial class PMTSP01104UC
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
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem1 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem2 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem3 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PMTSP01104UC));
            this.SaveDistance_OptionSet = new Infragistics.Win.UltraWinEditors.UltraOptionSet();
            this.TspDtPath_Edit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.SaveDistance_GroupBox = new Infragistics.Win.Misc.UltraGroupBox();
            this.OK_Button = new Infragistics.Win.Misc.UltraButton();
            this.cancel_Button = new Infragistics.Win.Misc.UltraButton();
            ((System.ComponentModel.ISupportInitialize)(this.SaveDistance_OptionSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TspDtPath_Edit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SaveDistance_GroupBox)).BeginInit();
            this.SaveDistance_GroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // SaveDistance_OptionSet
            // 
            appearance1.BackGradientStyle = Infragistics.Win.GradientStyle.None;
            appearance1.BackHatchStyle = Infragistics.Win.BackHatchStyle.None;
            this.SaveDistance_OptionSet.Appearance = appearance1;
            this.SaveDistance_OptionSet.BackColor = System.Drawing.Color.Transparent;
            this.SaveDistance_OptionSet.BackColorInternal = System.Drawing.Color.Transparent;
            this.SaveDistance_OptionSet.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            valueListItem1.DataValue = "Default Item";
            valueListItem1.DisplayText = "処理済をすぐに削除";
            valueListItem2.DataValue = "ValueListItem1";
            valueListItem2.DisplayText = "1ヵ月後に削除";
            valueListItem3.DataValue = "ValueListItem2";
            valueListItem3.DisplayText = "3ヶ月後に削除";
            this.SaveDistance_OptionSet.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem1,
            valueListItem2,
            valueListItem3});
            this.SaveDistance_OptionSet.ItemSpacingVertical = 5;
            this.SaveDistance_OptionSet.Location = new System.Drawing.Point(6, 22);
            this.SaveDistance_OptionSet.Name = "SaveDistance_OptionSet";
            this.SaveDistance_OptionSet.Size = new System.Drawing.Size(288, 62);
            this.SaveDistance_OptionSet.TabIndex = 7;
            // 
            // TspDtPath_Edit
            // 
            this.TspDtPath_Edit.ActiveAppearance = appearance3;
            this.TspDtPath_Edit.AutoSelect = true;
            this.TspDtPath_Edit.DataText = "C:\\Program Files (x86)\\Partsman\\PRTOUT\\TSP\\TSP-SEND";
            this.TspDtPath_Edit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.TspDtPath_Edit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 128, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, true, true, true, true));
            this.TspDtPath_Edit.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TspDtPath_Edit.Location = new System.Drawing.Point(37, 36);
            this.TspDtPath_Edit.MaxLength = 128;
            this.TspDtPath_Edit.Name = "TspDtPath_Edit";
            this.TspDtPath_Edit.Size = new System.Drawing.Size(337, 24);
            this.TspDtPath_Edit.TabIndex = 0;
            this.TspDtPath_Edit.Text = "C:\\Program Files (x86)\\Partsman\\PRTOUT\\TSP\\TSP-SEND";
            // 
            // ultraLabel1
            // 
            this.ultraLabel1.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel1.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel1.Location = new System.Drawing.Point(37, 12);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(294, 23);
            this.ultraLabel1.TabIndex = 2;
            this.ultraLabel1.Text = "送信データフォルダ";
            // 
            // SaveDistance_GroupBox
            // 
            this.SaveDistance_GroupBox.Controls.Add(this.SaveDistance_OptionSet);
            this.SaveDistance_GroupBox.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.SaveDistance_GroupBox.ForeColor = System.Drawing.SystemColors.WindowText;
            this.SaveDistance_GroupBox.Location = new System.Drawing.Point(37, 75);
            this.SaveDistance_GroupBox.Name = "SaveDistance_GroupBox";
            this.SaveDistance_GroupBox.Size = new System.Drawing.Size(331, 107);
            this.SaveDistance_GroupBox.TabIndex = 4;
            this.SaveDistance_GroupBox.Text = "保存期間(処理済のデータを残す期間）";
            this.SaveDistance_GroupBox.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2000;
            // 
            // OK_Button
            // 
            this.OK_Button.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.OK_Button.Location = new System.Drawing.Point(182, 198);
            this.OK_Button.Name = "OK_Button";
            this.OK_Button.Size = new System.Drawing.Size(100, 26);
            this.OK_Button.TabIndex = 5;
            this.OK_Button.Text = "確定";
            this.OK_Button.Click += new System.EventHandler(this.OK_Button_Click);
            // 
            // cancel_Button
            // 
            this.cancel_Button.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.cancel_Button.Location = new System.Drawing.Point(311, 198);
            this.cancel_Button.Name = "cancel_Button";
            this.cancel_Button.Size = new System.Drawing.Size(100, 26);
            this.cancel_Button.TabIndex = 6;
            this.cancel_Button.Text = "キャンセル";
            this.cancel_Button.Click += new System.EventHandler(this.cancel_Button_Click);
            // 
            // PMTSP01104UC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.GhostWhite;
            this.ClientSize = new System.Drawing.Size(435, 241);
            this.Controls.Add(this.cancel_Button);
            this.Controls.Add(this.OK_Button);
            this.Controls.Add(this.SaveDistance_GroupBox);
            this.Controls.Add(this.ultraLabel1);
            this.Controls.Add(this.TspDtPath_Edit);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PMTSP01104UC";
            this.Text = "送信処理　- 設定";
            ((System.ComponentModel.ISupportInitialize)(this.SaveDistance_OptionSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TspDtPath_Edit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SaveDistance_GroupBox)).EndInit();
            this.SaveDistance_GroupBox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Broadleaf.Library.Windows.Forms.TEdit TspDtPath_Edit;
        private Infragistics.Win.Misc.UltraLabel ultraLabel1;
        private Infragistics.Win.Misc.UltraGroupBox SaveDistance_GroupBox;
        private Infragistics.Win.Misc.UltraButton OK_Button;
        private Infragistics.Win.Misc.UltraButton cancel_Button;
        private Infragistics.Win.UltraWinEditors.UltraOptionSet SaveDistance_OptionSet;
    }
}
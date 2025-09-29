namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 処理の進捗表示フォーム
    /// </summary>
    partial class PMSCM01103AC
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
            this.txtSCMDataPath = new Broadleaf.Library.Windows.Forms.TEdit();
            this.btnOK = new Infragistics.Win.Misc.UltraButton();
            this.btnCancel = new Infragistics.Win.Misc.UltraButton();
            this.lblSCMDataPath = new Infragistics.Win.Misc.UltraLabel();
            this.grpSavePeriodType = new System.Windows.Forms.GroupBox();
            this.optSavePeriodType = new Infragistics.Win.UltraWinEditors.UltraOptionSet();
            ((System.ComponentModel.ISupportInitialize)(this.txtSCMDataPath)).BeginInit();
            this.grpSavePeriodType.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.optSavePeriodType)).BeginInit();
            this.SuspendLayout();
            // 
            // txtSCMDataPath
            // 
            appearance1.BackGradientStyle = Infragistics.Win.GradientStyle.None;
            appearance1.BackHatchStyle = Infragistics.Win.BackHatchStyle.None;
            this.txtSCMDataPath.ActiveAppearance = appearance1;
            this.txtSCMDataPath.AutoSelect = true;
            this.txtSCMDataPath.DataText = "C:\\SCM\\Send";
            this.txtSCMDataPath.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.txtSCMDataPath.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 128, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, true, true, true, true));
            this.txtSCMDataPath.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtSCMDataPath.Location = new System.Drawing.Point(37, 36);
            this.txtSCMDataPath.MaxLength = 128;
            this.txtSCMDataPath.Name = "txtSCMDataPath";
            this.txtSCMDataPath.Size = new System.Drawing.Size(337, 24);
            this.txtSCMDataPath.TabIndex = 0;
            this.txtSCMDataPath.Text = "C:\\SCM\\Send";
            this.txtSCMDataPath.Visible = false;
            // 
            // btnOK
            // 
            this.btnOK.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnOK.Location = new System.Drawing.Point(182, 135);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(100, 26);
            this.btnOK.TabIndex = 5;
            this.btnOK.Text = "確定";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnCancel.Location = new System.Drawing.Point(311, 135);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 26);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "キャンセル";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblSCMDataPath
            // 
            this.lblSCMDataPath.BackColorInternal = System.Drawing.Color.Transparent;
            this.lblSCMDataPath.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblSCMDataPath.Location = new System.Drawing.Point(37, 12);
            this.lblSCMDataPath.Name = "lblSCMDataPath";
            this.lblSCMDataPath.Size = new System.Drawing.Size(294, 23);
            this.lblSCMDataPath.TabIndex = 2;
            this.lblSCMDataPath.Text = "送信データフォルダ";
            this.lblSCMDataPath.Visible = false;
            // 
            // grpSavePeriodType
            // 
            this.grpSavePeriodType.Controls.Add(this.optSavePeriodType);
            this.grpSavePeriodType.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.grpSavePeriodType.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grpSavePeriodType.Location = new System.Drawing.Point(37, 12);
            this.grpSavePeriodType.Name = "grpSavePeriodType";
            this.grpSavePeriodType.Size = new System.Drawing.Size(331, 107);
            this.grpSavePeriodType.TabIndex = 4;
            this.grpSavePeriodType.TabStop = false;
            this.grpSavePeriodType.Text = "保存期間(処理済のデータを残す期間）";
            // 
            // optSavePeriodType
            // 
            this.optSavePeriodType.Appearance = appearance1;
            this.optSavePeriodType.BackColor = System.Drawing.Color.Transparent;
            this.optSavePeriodType.BackColorInternal = System.Drawing.Color.Transparent;
            this.optSavePeriodType.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            this.optSavePeriodType.ItemAppearance = appearance1;
            valueListItem1.DataValue = "Default Item";
            valueListItem1.DisplayText = "送信済をすぐに削除";
            valueListItem2.DataValue = "ValueListItem1";
            valueListItem2.DisplayText = "1ヵ月後に削除";
            valueListItem3.DataValue = "ValueListItem2";
            valueListItem3.DisplayText = "3ヶ月後に削除";
            this.optSavePeriodType.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem1,
            valueListItem2,
            valueListItem3});
            this.optSavePeriodType.ItemSpacingVertical = 5;
            this.optSavePeriodType.Location = new System.Drawing.Point(6, 22);
            this.optSavePeriodType.Name = "optSavePeriodType";
            this.optSavePeriodType.Size = new System.Drawing.Size(288, 62);
            this.optSavePeriodType.TabIndex = 7;
            // 
            // PMSCM01103AC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.GhostWhite;
            this.ClientSize = new System.Drawing.Size(435, 172);
            this.Controls.Add(this.grpSavePeriodType);
            this.Controls.Add(this.lblSCMDataPath);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtSCMDataPath);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PMSCM01103AC";
            this.Text = "送信処理　- 設定";
            ((System.ComponentModel.ISupportInitialize)(this.txtSCMDataPath)).EndInit();
            this.grpSavePeriodType.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.optSavePeriodType)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Broadleaf.Library.Windows.Forms.TEdit txtSCMDataPath;
        private Infragistics.Win.Misc.UltraButton btnOK;
        private Infragistics.Win.Misc.UltraButton btnCancel;
        private Infragistics.Win.Misc.UltraLabel lblSCMDataPath;
        private System.Windows.Forms.GroupBox grpSavePeriodType;
        private Infragistics.Win.UltraWinEditors.UltraOptionSet optSavePeriodType;
    }
}
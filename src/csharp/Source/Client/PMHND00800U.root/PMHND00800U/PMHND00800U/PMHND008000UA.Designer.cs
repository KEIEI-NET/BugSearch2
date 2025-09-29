namespace Broadleaf.Windows.Forms
{
    partial class PMHND008000UA
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
            Infragistics.Win.Appearance appearance47 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem1 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem2 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem3 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PMHND008000UA));
            this.radioPanel = new System.Windows.Forms.Panel();
            this.radioPanelLabel = new Infragistics.Win.Misc.UltraLabel();
            this.uos_SendDiv = new Infragistics.Win.UltraWinEditors.UltraOptionSet();
            this.sendButton = new Infragistics.Win.Misc.UltraButton();
            this.messageLabel = new Infragistics.Win.Misc.UltraLabel();
            this.notificateLabel = new Infragistics.Win.Misc.UltraLabel();
            this.cancelButton = new Infragistics.Win.Misc.UltraButton();
            this.tArrowKeyControl1 = new Broadleaf.Library.Windows.Forms.TArrowKeyControl(this.components);
            this.tRetKeyControl1 = new Broadleaf.Library.Windows.Forms.TRetKeyControl(this.components);
            this.radioPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uos_SendDiv)).BeginInit();
            this.SuspendLayout();
            // 
            // radioPanel
            // 
            this.radioPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.radioPanel.Controls.Add(this.radioPanelLabel);
            this.radioPanel.Controls.Add(this.uos_SendDiv);
            this.radioPanel.Location = new System.Drawing.Point(29, 94);
            this.radioPanel.Name = "radioPanel";
            this.radioPanel.Size = new System.Drawing.Size(420, 97);
            this.radioPanel.TabIndex = 0;
            // 
            // radioPanelLabel
            // 
            this.radioPanelLabel.Location = new System.Drawing.Point(3, 3);
            this.radioPanelLabel.Name = "radioPanelLabel";
            this.radioPanelLabel.Size = new System.Drawing.Size(105, 12);
            this.radioPanelLabel.TabIndex = 1352;
            this.radioPanelLabel.Text = "ファイル入替方法";
            // 
            // uos_SendDiv
            // 
            appearance47.BackColorDisabled = System.Drawing.Color.Transparent;
            this.uos_SendDiv.Appearance = appearance47;
            this.uos_SendDiv.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            this.uos_SendDiv.CheckedIndex = 0;
            this.uos_SendDiv.ItemOrigin = new System.Drawing.Point(5, 5);
            valueListItem1.DataValue = 0;
            valueListItem1.DisplayText = "ファイル日付が異なるファイルのみ入替する。";
            valueListItem2.DataValue = 1;
            valueListItem2.DisplayText = "設定ファイルを除き、全てのファイルを入替する。";
            valueListItem3.DataValue = 2;
            valueListItem3.DisplayText = "全てのファイルを入替する。（入替後にハンディ機器の再設定が必要）";
            this.uos_SendDiv.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem1,
            valueListItem2,
            valueListItem3});
            this.uos_SendDiv.ItemSpacingHorizontal = 20;
            this.uos_SendDiv.ItemSpacingVertical = 7;
            this.uos_SendDiv.Location = new System.Drawing.Point(7, 18);
            this.uos_SendDiv.Name = "uos_SendDiv";
            this.uos_SendDiv.Size = new System.Drawing.Size(398, 71);
            this.uos_SendDiv.TabIndex = 1;
            this.uos_SendDiv.Text = "ファイル日付が異なるファイルのみ入替する。";
            // 
            // sendButton
            // 
            this.sendButton.ImageSize = new System.Drawing.Size(24, 24);
            this.sendButton.Location = new System.Drawing.Point(243, 197);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(100, 33);
            this.sendButton.TabIndex = 2;
            this.sendButton.Text = "送信";
            this.sendButton.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.sendButton.Click += new System.EventHandler(this.sendButton_Click);
            // 
            // messageLabel
            // 
            appearance1.TextVAlignAsString = "Middle";
            this.messageLabel.Appearance = appearance1;
            this.messageLabel.Location = new System.Drawing.Point(29, 5);
            this.messageLabel.Name = "messageLabel";
            this.messageLabel.Size = new System.Drawing.Size(450, 44);
            this.messageLabel.TabIndex = 1350;
            this.messageLabel.Text = "messageLabel";
            // 
            // notificateLabel
            // 
            this.notificateLabel.Location = new System.Drawing.Point(29, 49);
            this.notificateLabel.Name = "notificateLabel";
            this.notificateLabel.Size = new System.Drawing.Size(450, 44);
            this.notificateLabel.TabIndex = 1351;
            this.notificateLabel.Text = "notificateLabel";
            // 
            // cancelButton
            // 
            this.cancelButton.ImageSize = new System.Drawing.Size(24, 24);
            this.cancelButton.Location = new System.Drawing.Point(349, 197);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(100, 33);
            this.cancelButton.TabIndex = 3;
            this.cancelButton.Text = "キャンセル";
            this.cancelButton.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // tArrowKeyControl1
            // 
            this.tArrowKeyControl1.OwnerForm = this;
            // 
            // tRetKeyControl1
            // 
            this.tRetKeyControl1.CatchMouse = true;
            this.tRetKeyControl1.InitFocus = false;
            this.tRetKeyControl1.OwnerForm = this;
            this.tRetKeyControl1.Style = Broadleaf.Library.Windows.Forms.emFocusStyle.ByTab;
            // 
            // PMHND008000UA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 242);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.notificateLabel);
            this.Controls.Add(this.messageLabel);
            this.Controls.Add(this.sendButton);
            this.Controls.Add(this.radioPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PMHND008000UA";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "HTプログラム導入処理";
            this.Load += new System.EventHandler(this.PMHND00800UA_Load);
            this.radioPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uos_SendDiv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel radioPanel;
        private Infragistics.Win.Misc.UltraButton sendButton;
        private Infragistics.Win.Misc.UltraLabel messageLabel;
        private Infragistics.Win.Misc.UltraLabel notificateLabel;
        private Infragistics.Win.UltraWinEditors.UltraOptionSet uos_SendDiv;
        private Infragistics.Win.Misc.UltraLabel radioPanelLabel;
        private Infragistics.Win.Misc.UltraButton cancelButton;
        private Broadleaf.Library.Windows.Forms.TArrowKeyControl tArrowKeyControl1;
        private Broadleaf.Library.Windows.Forms.TRetKeyControl tRetKeyControl1;
    }
}


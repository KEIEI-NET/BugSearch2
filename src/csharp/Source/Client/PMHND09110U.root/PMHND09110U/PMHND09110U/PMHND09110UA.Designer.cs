namespace Broadleaf.Windows.Forms
{
    partial class PMHND09110UA
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
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance32 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance33 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance34 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem1 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem2 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance30 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance78 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance79 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance64 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance65 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PMHND09110UA));
            this.Mode_Label = new Infragistics.Win.Misc.UltraLabel();
            this.OrderInspectCode_ultraLabel = new Infragistics.Win.Misc.UltraLabel();
            this.ultraStatusBar1 = new Infragistics.Win.UltraWinStatusBar.UltraStatusBar();
            this.OrderInspectCode_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.tArrowKeyControl1 = new Broadleaf.Library.Windows.Forms.TArrowKeyControl(this.components);
            this.tRetKeyControl1 = new Broadleaf.Library.Windows.Forms.TRetKeyControl(this.components);
            this.Initial_Timer = new System.Windows.Forms.Timer(this.components);
            this.Ok_Button = new Infragistics.Win.Misc.UltraButton();
            this.Cancel_Button = new Infragistics.Win.Misc.UltraButton();
            this.SectionNm_Label = new Infragistics.Win.Misc.UltraLabel();
            this.tEdit_SectionCodeAllowZero2 = new Broadleaf.Library.Windows.Forms.TEdit();
            this.SectionNm_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.SectionGd_ultraButton = new Infragistics.Win.Misc.UltraButton();
            this.SectionCode_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel17 = new Infragistics.Win.Misc.UltraLabel();
            this.Delete_Button = new Infragistics.Win.Misc.UltraButton();
            this.Revive_Button = new Infragistics.Win.Misc.UltraButton();
            this.Bind_DataSet = new System.Data.DataSet();
            this.uiSetControl1 = new Broadleaf.Library.Windows.Forms.UiSetControl(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.OrderInspectCode_tComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SectionCodeAllowZero2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionNm_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bind_DataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // Mode_Label
            // 
            appearance1.ForeColor = System.Drawing.Color.White;
            appearance1.TextHAlignAsString = "Center";
            appearance1.TextVAlignAsString = "Middle";
            this.Mode_Label.Appearance = appearance1;
            this.Mode_Label.BackColorInternal = System.Drawing.Color.Navy;
            this.Mode_Label.Location = new System.Drawing.Point(347, 0);
            this.Mode_Label.Name = "Mode_Label";
            this.Mode_Label.Size = new System.Drawing.Size(100, 23);
            this.Mode_Label.TabIndex = 150;
            this.Mode_Label.Text = "更新モード";
            // 
            // OrderInspectCode_ultraLabel
            // 
            appearance11.TextVAlignAsString = "Middle";
            this.OrderInspectCode_ultraLabel.Appearance = appearance11;
            this.OrderInspectCode_ultraLabel.Location = new System.Drawing.Point(12, 88);
            this.OrderInspectCode_ultraLabel.Name = "OrderInspectCode_ultraLabel";
            this.OrderInspectCode_ultraLabel.Size = new System.Drawing.Size(180, 24);
            this.OrderInspectCode_ultraLabel.TabIndex = 2;
            this.OrderInspectCode_ultraLabel.Text = "取寄検品区分";
            // 
            // ultraStatusBar1
            // 
            this.ultraStatusBar1.Location = new System.Drawing.Point(0, 183);
            this.ultraStatusBar1.Name = "ultraStatusBar1";
            this.ultraStatusBar1.Size = new System.Drawing.Size(462, 23);
            this.ultraStatusBar1.TabIndex = 153;
            this.ultraStatusBar1.ViewStyle = Infragistics.Win.UltraWinStatusBar.ViewStyle.Office2003;
            // 
            // OrderInspectCode_tComboEditor
            // 
            appearance32.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.OrderInspectCode_tComboEditor.ActiveAppearance = appearance32;
            appearance33.TextVAlignAsString = "Middle";
            this.OrderInspectCode_tComboEditor.Appearance = appearance33;
            this.OrderInspectCode_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.OrderInspectCode_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance34.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.OrderInspectCode_tComboEditor.ItemAppearance = appearance34;
            valueListItem1.DataValue = "しない";
            valueListItem2.DataValue = "する";
            this.OrderInspectCode_tComboEditor.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem1,
            valueListItem2});
            this.OrderInspectCode_tComboEditor.Location = new System.Drawing.Point(179, 88);
            this.OrderInspectCode_tComboEditor.Name = "OrderInspectCode_tComboEditor";
            this.OrderInspectCode_tComboEditor.Size = new System.Drawing.Size(202, 24);
            this.OrderInspectCode_tComboEditor.TabIndex = 6;
            // 
            // tArrowKeyControl1
            // 
            this.tArrowKeyControl1.OwnerForm = this;
            this.tArrowKeyControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tRetKeyControl1_ChangeFocus);
            // 
            // tRetKeyControl1
            // 
            this.tRetKeyControl1.OwnerForm = this;
            this.tRetKeyControl1.Style = Broadleaf.Library.Windows.Forms.emFocusStyle.ByTab;
            this.tRetKeyControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tRetKeyControl1_ChangeFocus);
            // 
            // Initial_Timer
            // 
            this.Initial_Timer.Interval = 1;
            this.Initial_Timer.Tick += new System.EventHandler(this.Initial_Timer_Tick);
            // 
            // Ok_Button
            // 
            this.Ok_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Ok_Button.Location = new System.Drawing.Point(191, 143);
            this.Ok_Button.Name = "Ok_Button";
            this.Ok_Button.Size = new System.Drawing.Size(125, 34);
            this.Ok_Button.TabIndex = 17;
            this.Ok_Button.Text = "保存(&S)";
            this.Ok_Button.Click += new System.EventHandler(this.Ok_Button_Click);
            // 
            // Cancel_Button
            // 
            this.Cancel_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Cancel_Button.Location = new System.Drawing.Point(322, 143);
            this.Cancel_Button.Name = "Cancel_Button";
            this.Cancel_Button.Size = new System.Drawing.Size(125, 34);
            this.Cancel_Button.TabIndex = 18;
            this.Cancel_Button.Text = "閉じる(&X)";
            this.Cancel_Button.Click += new System.EventHandler(this.Cancel_Button_Click);
            // 
            // SectionNm_Label
            // 
            appearance30.TextVAlignAsString = "Middle";
            this.SectionNm_Label.Appearance = appearance30;
            this.SectionNm_Label.Location = new System.Drawing.Point(237, 28);
            this.SectionNm_Label.Name = "SectionNm_Label";
            this.SectionNm_Label.Size = new System.Drawing.Size(210, 23);
            this.SectionNm_Label.TabIndex = 158;
            this.SectionNm_Label.Text = "※ゼロで共通設定になります";
            // 
            // tEdit_SectionCodeAllowZero2
            // 
            appearance78.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_SectionCodeAllowZero2.ActiveAppearance = appearance78;
            appearance79.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance79.ForeColorDisabled = System.Drawing.Color.Black;
            this.tEdit_SectionCodeAllowZero2.Appearance = appearance79;
            this.tEdit_SectionCodeAllowZero2.AutoSelect = true;
            this.tEdit_SectionCodeAllowZero2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tEdit_SectionCodeAllowZero2.DataText = "";
            this.tEdit_SectionCodeAllowZero2.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_SectionCodeAllowZero2.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 2, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tEdit_SectionCodeAllowZero2.Location = new System.Drawing.Point(50, 28);
            this.tEdit_SectionCodeAllowZero2.MaxLength = 2;
            this.tEdit_SectionCodeAllowZero2.Name = "tEdit_SectionCodeAllowZero2";
            this.tEdit_SectionCodeAllowZero2.Size = new System.Drawing.Size(28, 24);
            this.tEdit_SectionCodeAllowZero2.TabIndex = 0;
            this.tEdit_SectionCodeAllowZero2.Leave += new System.EventHandler(this.tEdit_SectionCode_Leave);
            this.tEdit_SectionCodeAllowZero2.Enter += new System.EventHandler(this.tEdit_SectionCodeAllowZero2_Enter);
            // 
            // SectionNm_tEdit
            // 
            this.SectionNm_tEdit.ActiveAppearance = appearance64;
            appearance65.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance65.ForeColorDisabled = System.Drawing.Color.Black;
            this.SectionNm_tEdit.Appearance = appearance65;
            this.SectionNm_tEdit.AutoSelect = true;
            this.SectionNm_tEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.SectionNm_tEdit.DataText = "";
            this.SectionNm_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.SectionNm_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 6, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, true, true, true, true));
            this.SectionNm_tEdit.Location = new System.Drawing.Point(116, 28);
            this.SectionNm_tEdit.MaxLength = 6;
            this.SectionNm_tEdit.Name = "SectionNm_tEdit";
            this.SectionNm_tEdit.ReadOnly = true;
            this.SectionNm_tEdit.Size = new System.Drawing.Size(115, 24);
            this.SectionNm_tEdit.TabIndex = 2;
            // 
            // SectionGd_ultraButton
            // 
            this.SectionGd_ultraButton.BackColorInternal = System.Drawing.Color.Transparent;
            this.SectionGd_ultraButton.Location = new System.Drawing.Point(85, 28);
            this.SectionGd_ultraButton.Margin = new System.Windows.Forms.Padding(4);
            this.SectionGd_ultraButton.Name = "SectionGd_ultraButton";
            this.SectionGd_ultraButton.Size = new System.Drawing.Size(24, 24);
            this.SectionGd_ultraButton.TabIndex = 1;
            this.SectionGd_ultraButton.Click += new System.EventHandler(this.SectionGd_ultraButton_Click);
            // 
            // SectionCode_Title_Label
            // 
            appearance2.TextVAlignAsString = "Middle";
            this.SectionCode_Title_Label.Appearance = appearance2;
            this.SectionCode_Title_Label.Location = new System.Drawing.Point(13, 29);
            this.SectionCode_Title_Label.Name = "SectionCode_Title_Label";
            this.SectionCode_Title_Label.Size = new System.Drawing.Size(125, 23);
            this.SectionCode_Title_Label.TabIndex = 154;
            this.SectionCode_Title_Label.Text = "拠点";
            // 
            // ultraLabel17
            // 
            this.ultraLabel17.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel17.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Inset;
            this.ultraLabel17.Location = new System.Drawing.Point(0, 68);
            this.ultraLabel17.Name = "ultraLabel17";
            this.ultraLabel17.Size = new System.Drawing.Size(458, 3);
            this.ultraLabel17.TabIndex = 159;
            // 
            // Delete_Button
            // 
            this.Delete_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Delete_Button.Location = new System.Drawing.Point(60, 143);
            this.Delete_Button.Name = "Delete_Button";
            this.Delete_Button.Size = new System.Drawing.Size(125, 34);
            this.Delete_Button.TabIndex = 15;
            this.Delete_Button.Text = "完全削除(&D)";
            this.Delete_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Delete_Button.Click += new System.EventHandler(this.Delete_Button_Click);
            // 
            // Revive_Button
            // 
            this.Revive_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Revive_Button.Location = new System.Drawing.Point(60, 143);
            this.Revive_Button.Name = "Revive_Button";
            this.Revive_Button.Size = new System.Drawing.Size(125, 34);
            this.Revive_Button.TabIndex = 16;
            this.Revive_Button.Text = "復活(&R)";
            this.Revive_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Revive_Button.Click += new System.EventHandler(this.Revive_Button_Click);
            // 
            // Bind_DataSet
            // 
            this.Bind_DataSet.DataSetName = "NewDataSet";
            this.Bind_DataSet.Locale = new System.Globalization.CultureInfo("ja-JP");
            // 
            // uiSetControl1
            // 
            this.uiSetControl1.EditWidthSettingWay = Broadleaf.Library.Windows.Forms.UiSetControl.EditWidthSettingWayState.None;
            this.uiSetControl1.OwnerForm = this;
            // 
            // PMHND09110UA
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(462, 206);
            this.Controls.Add(this.Delete_Button);
            this.Controls.Add(this.Revive_Button);
            this.Controls.Add(this.ultraLabel17);
            this.Controls.Add(this.SectionNm_Label);
            this.Controls.Add(this.tEdit_SectionCodeAllowZero2);
            this.Controls.Add(this.SectionNm_tEdit);
            this.Controls.Add(this.SectionGd_ultraButton);
            this.Controls.Add(this.SectionCode_Title_Label);
            this.Controls.Add(this.Cancel_Button);
            this.Controls.Add(this.Ok_Button);
            this.Controls.Add(this.OrderInspectCode_tComboEditor);
            this.Controls.Add(this.ultraStatusBar1);
            this.Controls.Add(this.OrderInspectCode_ultraLabel);
            this.Controls.Add(this.Mode_Label);
            this.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PMHND09110UA";
            this.Text = "検品全体設定";
            this.Load += new System.EventHandler(this.PMHND09110UA_Load);
            this.VisibleChanged += new System.EventHandler(this.PMHND09110UA_VisibleChanged);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PMHND09110UA_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.OrderInspectCode_tComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SectionCodeAllowZero2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionNm_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bind_DataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Infragistics.Win.Misc.UltraLabel Mode_Label;
        private Infragistics.Win.Misc.UltraLabel OrderInspectCode_ultraLabel;
        private Infragistics.Win.UltraWinStatusBar.UltraStatusBar ultraStatusBar1;
        private Broadleaf.Library.Windows.Forms.TComboEditor OrderInspectCode_tComboEditor;
        private Broadleaf.Library.Windows.Forms.TArrowKeyControl tArrowKeyControl1;
        private Broadleaf.Library.Windows.Forms.TRetKeyControl tRetKeyControl1;
        private System.Windows.Forms.Timer Initial_Timer;
        private Infragistics.Win.Misc.UltraButton Cancel_Button;
        private Infragistics.Win.Misc.UltraButton Ok_Button;
        private Infragistics.Win.Misc.UltraLabel ultraLabel17;
        private Infragistics.Win.Misc.UltraLabel SectionNm_Label;
        private Broadleaf.Library.Windows.Forms.TEdit tEdit_SectionCodeAllowZero2;
        private Broadleaf.Library.Windows.Forms.TEdit SectionNm_tEdit;
        private Infragistics.Win.Misc.UltraButton SectionGd_ultraButton;
        private Infragistics.Win.Misc.UltraLabel SectionCode_Title_Label;
        private Infragistics.Win.Misc.UltraButton Delete_Button;
        private Infragistics.Win.Misc.UltraButton Revive_Button;
        private System.Data.DataSet Bind_DataSet;
        private Broadleaf.Library.Windows.Forms.UiSetControl uiSetControl1;
    }
}


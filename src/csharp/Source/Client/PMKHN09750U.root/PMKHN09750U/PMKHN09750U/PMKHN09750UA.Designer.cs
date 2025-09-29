namespace Broadleaf.Windows.Forms
{
    partial class PMKHN09750UA
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
            Infragistics.Win.Appearance appearance99 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PMKHN09750UA));
            this.ultraStatusBar1 = new Infragistics.Win.UltraWinStatusBar.UltraStatusBar();
            this.tArrowKeyControl1 = new Broadleaf.Library.Windows.Forms.TArrowKeyControl(this.components);
            this.tRetKeyControl1 = new Broadleaf.Library.Windows.Forms.TRetKeyControl(this.components);
            this.uiSetControl1 = new Broadleaf.Library.Windows.Forms.UiSetControl(this.components);
            this.ultraToolTipManager1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipManager(this.components);
            this.Bind_DataSet = new System.Data.DataSet();
            this.Initial_Timer = new System.Windows.Forms.Timer(this.components);
            this.Renewal_Button = new Infragistics.Win.Misc.UltraButton();
            this.ultraButton_SectionGuide = new Infragistics.Win.Misc.UltraButton();
            this.DeleteRow_Button = new Infragistics.Win.Misc.UltraButton();
            this.uGrid_ProtyWarehouse = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.Cancel_Button = new Infragistics.Win.Misc.UltraButton();
            this.Revive_Button = new Infragistics.Win.Misc.UltraButton();
            this.tEdit_SectionName = new Broadleaf.Library.Windows.Forms.TEdit();
            this.tEdit_SectionCode = new Broadleaf.Library.Windows.Forms.TEdit();
            this.section_ultraLabel = new Infragistics.Win.Misc.UltraLabel();
            this.Delete_Button = new Infragistics.Win.Misc.UltraButton();
            this.Ok_Button = new Infragistics.Win.Misc.UltraButton();
            this.Mode_Label = new Infragistics.Win.Misc.UltraLabel();
            ((System.ComponentModel.ISupportInitialize)(this.Bind_DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uGrid_ProtyWarehouse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SectionName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SectionCode)).BeginInit();
            this.SuspendLayout();
            // 
            // ultraStatusBar1
            // 
            this.ultraStatusBar1.Location = new System.Drawing.Point(0, 405);
            this.ultraStatusBar1.Name = "ultraStatusBar1";
            this.ultraStatusBar1.Size = new System.Drawing.Size(614, 23);
            this.ultraStatusBar1.TabIndex = 205;
            this.ultraStatusBar1.ViewStyle = Infragistics.Win.UltraWinStatusBar.ViewStyle.Office2003;
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
            // uiSetControl1
            // 
            this.uiSetControl1.EditWidthSettingWay = Broadleaf.Library.Windows.Forms.UiSetControl.EditWidthSettingWayState.None;
            this.uiSetControl1.OwnerForm = this;
            // 
            // ultraToolTipManager1
            // 
            this.ultraToolTipManager1.ContainingControl = this;
            // 
            // Bind_DataSet
            // 
            this.Bind_DataSet.DataSetName = "NewDataSet";
            // 
            // Initial_Timer
            // 
            this.Initial_Timer.Tick += new System.EventHandler(this.Initial_Timer_Tick);
            // 
            // Renewal_Button
            // 
            this.Renewal_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Renewal_Button.Location = new System.Drawing.Point(218, 360);
            this.Renewal_Button.Name = "Renewal_Button";
            this.Renewal_Button.Size = new System.Drawing.Size(125, 34);
            this.Renewal_Button.TabIndex = 211;
            this.Renewal_Button.Text = "最新情報(&I)";
            this.Renewal_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Renewal_Button.Click += new System.EventHandler(this.Renewal_Button_Click);
            // 
            // ultraButton_SectionGuide
            // 
            appearance99.ImageHAlign = Infragistics.Win.HAlign.Center;
            this.ultraButton_SectionGuide.Appearance = appearance99;
            this.ultraButton_SectionGuide.BackColorInternal = System.Drawing.Color.WhiteSmoke;
            this.ultraButton_SectionGuide.Location = new System.Drawing.Point(253, 17);
            this.ultraButton_SectionGuide.Name = "ultraButton_SectionGuide";
            this.ultraButton_SectionGuide.Size = new System.Drawing.Size(25, 25);
            this.ultraButton_SectionGuide.TabIndex = 208;
            this.ultraButton_SectionGuide.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.ultraButton_SectionGuide.Click += new System.EventHandler(this.ultraButton_SectionGuide_Click);
            // 
            // DeleteRow_Button
            // 
            this.DeleteRow_Button.Font = new System.Drawing.Font("ＭＳ ゴシック", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.DeleteRow_Button.Location = new System.Drawing.Point(12, 53);
            this.DeleteRow_Button.Name = "DeleteRow_Button";
            this.DeleteRow_Button.Size = new System.Drawing.Size(98, 29);
            this.DeleteRow_Button.TabIndex = 209;
            this.DeleteRow_Button.Text = "削除(&D)";
            this.DeleteRow_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.DeleteRow_Button.Click += new System.EventHandler(this.DeleteRow_Button_Click);
            // 
            // uGrid_ProtyWarehouse
            // 
            this.uGrid_ProtyWarehouse.Location = new System.Drawing.Point(12, 88);
            this.uGrid_ProtyWarehouse.Name = "uGrid_ProtyWarehouse";
            this.uGrid_ProtyWarehouse.Size = new System.Drawing.Size(590, 260);
            this.uGrid_ProtyWarehouse.TabIndex = 210;
            this.uGrid_ProtyWarehouse.ClickCellButton += new Infragistics.Win.UltraWinGrid.CellEventHandler(this.uGrid_ProtyWarehouse_ClickCellButton);
            this.uGrid_ProtyWarehouse.AfterExitEditMode += new System.EventHandler(this.uGrid_ProtyWarehouse_AfterExitEditMode);
            this.uGrid_ProtyWarehouse.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.uGrid_ProtyWarehouse_KeyPress);
            this.uGrid_ProtyWarehouse.KeyDown += new System.Windows.Forms.KeyEventHandler(this.uGrid_ProtyWarehouse_KeyDown);
            // 
            // Cancel_Button
            // 
            this.Cancel_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Cancel_Button.Location = new System.Drawing.Point(477, 360);
            this.Cancel_Button.Name = "Cancel_Button";
            this.Cancel_Button.Size = new System.Drawing.Size(125, 34);
            this.Cancel_Button.TabIndex = 215;
            this.Cancel_Button.Text = "閉じる(&X)";
            this.Cancel_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Cancel_Button.Click += new System.EventHandler(this.Cancel_Button_Click);
            // 
            // Revive_Button
            // 
            this.Revive_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Revive_Button.Location = new System.Drawing.Point(348, 360);
            this.Revive_Button.Name = "Revive_Button";
            this.Revive_Button.Size = new System.Drawing.Size(125, 34);
            this.Revive_Button.TabIndex = 213;
            this.Revive_Button.Text = "復活(&R)";
            this.Revive_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Revive_Button.Click += new System.EventHandler(this.Revive_Button_Click);
            // 
            // tEdit_SectionName
            // 
            appearance2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_SectionName.ActiveAppearance = appearance2;
            appearance3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance3.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance3.ForeColorDisabled = System.Drawing.Color.Black;
            this.tEdit_SectionName.Appearance = appearance3;
            this.tEdit_SectionName.AutoSelect = true;
            this.tEdit_SectionName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tEdit_SectionName.DataText = "";
            this.tEdit_SectionName.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_SectionName.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 6, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, true, true, true, true));
            this.tEdit_SectionName.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.tEdit_SectionName.Location = new System.Drawing.Point(132, 18);
            this.tEdit_SectionName.MaxLength = 6;
            this.tEdit_SectionName.Name = "tEdit_SectionName";
            this.tEdit_SectionName.Size = new System.Drawing.Size(115, 24);
            this.tEdit_SectionName.TabIndex = 207;
            // 
            // tEdit_SectionCode
            // 
            appearance20.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance20.TextHAlignAsString = "Right";
            this.tEdit_SectionCode.ActiveAppearance = appearance20;
            appearance21.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance21.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance21.ForeColorDisabled = System.Drawing.Color.Black;
            appearance21.TextHAlignAsString = "Right";
            this.tEdit_SectionCode.Appearance = appearance21;
            this.tEdit_SectionCode.AutoSelect = true;
            this.tEdit_SectionCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tEdit_SectionCode.DataText = "";
            this.tEdit_SectionCode.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_SectionCode.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 2, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tEdit_SectionCode.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.tEdit_SectionCode.Location = new System.Drawing.Point(98, 18);
            this.tEdit_SectionCode.MaxLength = 2;
            this.tEdit_SectionCode.Name = "tEdit_SectionCode";
            this.tEdit_SectionCode.Size = new System.Drawing.Size(28, 24);
            this.tEdit_SectionCode.TabIndex = 206;
            // 
            // section_ultraLabel
            // 
            appearance19.TextVAlignAsString = "Middle";
            this.section_ultraLabel.Appearance = appearance19;
            this.section_ultraLabel.BackColorInternal = System.Drawing.Color.Transparent;
            this.section_ultraLabel.Location = new System.Drawing.Point(12, 18);
            this.section_ultraLabel.Name = "section_ultraLabel";
            this.section_ultraLabel.Size = new System.Drawing.Size(61, 24);
            this.section_ultraLabel.TabIndex = 214;
            this.section_ultraLabel.Text = "拠点";
            // 
            // Delete_Button
            // 
            this.Delete_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Delete_Button.Location = new System.Drawing.Point(219, 360);
            this.Delete_Button.Name = "Delete_Button";
            this.Delete_Button.Size = new System.Drawing.Size(125, 34);
            this.Delete_Button.TabIndex = 212;
            this.Delete_Button.Text = "完全削除(&D)";
            this.Delete_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Delete_Button.Click += new System.EventHandler(this.Delete_Button_Click);
            // 
            // Ok_Button
            // 
            this.Ok_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Ok_Button.Location = new System.Drawing.Point(348, 360);
            this.Ok_Button.Name = "Ok_Button";
            this.Ok_Button.Size = new System.Drawing.Size(125, 34);
            this.Ok_Button.TabIndex = 214;
            this.Ok_Button.Text = "保存(&S)";
            this.Ok_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Ok_Button.Click += new System.EventHandler(this.Ok_Button_Click);
            // 
            // Mode_Label
            // 
            appearance13.ForeColor = System.Drawing.Color.White;
            appearance13.TextHAlignAsString = "Center";
            appearance13.TextVAlignAsString = "Middle";
            this.Mode_Label.Appearance = appearance13;
            this.Mode_Label.BackColorInternal = System.Drawing.Color.Navy;
            this.Mode_Label.Location = new System.Drawing.Point(502, 12);
            this.Mode_Label.Name = "Mode_Label";
            this.Mode_Label.Size = new System.Drawing.Size(100, 23);
            this.Mode_Label.TabIndex = 217;
            this.Mode_Label.Text = "更新モード";
            // 
            // PMKHN09750UA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(614, 428);
            this.Controls.Add(this.Mode_Label);
            this.Controls.Add(this.Renewal_Button);
            this.Controls.Add(this.ultraButton_SectionGuide);
            this.Controls.Add(this.DeleteRow_Button);
            this.Controls.Add(this.uGrid_ProtyWarehouse);
            this.Controls.Add(this.Cancel_Button);
            this.Controls.Add(this.Revive_Button);
            this.Controls.Add(this.tEdit_SectionName);
            this.Controls.Add(this.tEdit_SectionCode);
            this.Controls.Add(this.section_ultraLabel);
            this.Controls.Add(this.ultraStatusBar1);
            this.Controls.Add(this.Ok_Button);
            this.Controls.Add(this.Delete_Button);
            this.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "PMKHN09750UA";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "優先倉庫マスタ";
            this.Load += new System.EventHandler(this.PMKHN09750UA_Load);
            this.VisibleChanged += new System.EventHandler(this.PMKHN09750UA_VisibleChanged);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PMKHN09750UA_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.Bind_DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uGrid_ProtyWarehouse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SectionName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SectionCode)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Infragistics.Win.UltraWinStatusBar.UltraStatusBar ultraStatusBar1;
        private Broadleaf.Library.Windows.Forms.TArrowKeyControl tArrowKeyControl1;
        private Broadleaf.Library.Windows.Forms.TRetKeyControl tRetKeyControl1;
        private Broadleaf.Library.Windows.Forms.UiSetControl uiSetControl1;
        private Infragistics.Win.UltraWinToolTip.UltraToolTipManager ultraToolTipManager1;
        private System.Data.DataSet Bind_DataSet;
        private System.Windows.Forms.Timer Initial_Timer;
        private Infragistics.Win.Misc.UltraButton Renewal_Button;
        private Infragistics.Win.Misc.UltraButton ultraButton_SectionGuide;
        private Infragistics.Win.Misc.UltraButton DeleteRow_Button;
        private Infragistics.Win.UltraWinGrid.UltraGrid uGrid_ProtyWarehouse;
        private Infragistics.Win.Misc.UltraButton Cancel_Button;
        private Infragistics.Win.Misc.UltraButton Revive_Button;
        private Broadleaf.Library.Windows.Forms.TEdit tEdit_SectionName;
        private Broadleaf.Library.Windows.Forms.TEdit tEdit_SectionCode;
        private Infragistics.Win.Misc.UltraLabel section_ultraLabel;
        private Infragistics.Win.Misc.UltraButton Ok_Button;
        private Infragistics.Win.Misc.UltraButton Delete_Button;
        private Infragistics.Win.Misc.UltraLabel Mode_Label;


    }
}
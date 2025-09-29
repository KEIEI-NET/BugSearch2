namespace Broadleaf.Windows.Forms
{
    partial class PMSAE09040UA
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
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PMSAE09040UA));
            this.Section_uLabel = new Infragistics.Win.Misc.UltraLabel();
            this.tEdit_MakerName = new Broadleaf.Library.Windows.Forms.TEdit();
            this.GoodsMakerGuide_Button = new Infragistics.Win.Misc.UltraButton();
            this.ultraToolTipManager1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipManager(this.components);
            this.EnterpriseCode_uLabel = new Infragistics.Win.Misc.UltraLabel();
            this.Mode_Label = new Infragistics.Win.Misc.UltraLabel();
            this.Delete_Button = new Infragistics.Win.Misc.UltraButton();
            this.Ok_Button = new Infragistics.Win.Misc.UltraButton();
            this.Cancel_Button = new Infragistics.Win.Misc.UltraButton();
            this.Revive_Button = new Infragistics.Win.Misc.UltraButton();
            this.Bind_DataSet = new System.Data.DataSet();
            this.Timer = new System.Windows.Forms.Timer(this.components);
            this.tArrowKeyControl1 = new Broadleaf.Library.Windows.Forms.TArrowKeyControl(this.components);
            this.tRetKeyControl1 = new Broadleaf.Library.Windows.Forms.TRetKeyControl(this.components);
            this.uiSetControl1 = new Broadleaf.Library.Windows.Forms.UiSetControl(this.components);
            this.ultraStatusBar1 = new Infragistics.Win.UltraWinStatusBar.UltraStatusBar();
            this.Renewal_Button = new Infragistics.Win.Misc.UltraButton();
            this.tNedit_GoodsMakerCd = new Broadleaf.Library.Windows.Forms.TNedit();
            this.tEdit_ABGoodsCode = new Broadleaf.Library.Windows.Forms.TEdit();
            this.ultraLabel20 = new Infragistics.Win.Misc.UltraLabel();
            this.tEdit_GoodsNo = new Broadleaf.Library.Windows.Forms.TEdit();
            this.GoodsNo_uLabel = new Infragistics.Win.Misc.UltraLabel();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_MakerName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bind_DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_GoodsMakerCd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_ABGoodsCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_GoodsNo)).BeginInit();
            this.SuspendLayout();
            // 
            // Section_uLabel
            // 
            appearance4.TextVAlignAsString = "Middle";
            this.Section_uLabel.Appearance = appearance4;
            this.Section_uLabel.Location = new System.Drawing.Point(27, 52);
            this.Section_uLabel.Name = "Section_uLabel";
            this.Section_uLabel.Size = new System.Drawing.Size(92, 23);
            this.Section_uLabel.TabIndex = 0;
            this.Section_uLabel.Text = "メーカー";
            // 
            // tEdit_MakerName
            // 
            appearance10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance10.ForeColor = System.Drawing.Color.Black;
            this.tEdit_MakerName.ActiveAppearance = appearance10;
            appearance3.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance3.ForeColor = System.Drawing.Color.Black;
            appearance3.ForeColorDisabled = System.Drawing.Color.Black;
            appearance3.TextHAlignAsString = "Left";
            this.tEdit_MakerName.Appearance = appearance3;
            this.tEdit_MakerName.AutoSelect = true;
            this.tEdit_MakerName.DataText = "";
            this.tEdit_MakerName.Enabled = false;
            this.tEdit_MakerName.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_MakerName.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 10, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.tEdit_MakerName.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.tEdit_MakerName.Location = new System.Drawing.Point(196, 52);
            this.tEdit_MakerName.MaxLength = 10;
            this.tEdit_MakerName.Name = "tEdit_MakerName";
            this.tEdit_MakerName.ReadOnly = true;
            this.tEdit_MakerName.Size = new System.Drawing.Size(299, 24);
            this.tEdit_MakerName.TabIndex = 2;
            // 
            // GoodsMakerGuide_Button
            // 
            this.GoodsMakerGuide_Button.Location = new System.Drawing.Point(500, 52);
            this.GoodsMakerGuide_Button.Name = "GoodsMakerGuide_Button";
            this.GoodsMakerGuide_Button.Size = new System.Drawing.Size(25, 24);
            this.GoodsMakerGuide_Button.TabIndex = 3;
            this.GoodsMakerGuide_Button.Click += new System.EventHandler(this.GoodsMakerGuide_Button_Click);
            // 
            // ultraToolTipManager1
            // 
            this.ultraToolTipManager1.ContainingControl = this;
            this.ultraToolTipManager1.DisplayStyle = Infragistics.Win.ToolTipDisplayStyle.Standard;
            // 
            // EnterpriseCode_uLabel
            // 
            appearance6.TextVAlignAsString = "Middle";
            this.EnterpriseCode_uLabel.Appearance = appearance6;
            this.EnterpriseCode_uLabel.Location = new System.Drawing.Point(27, 154);
            this.EnterpriseCode_uLabel.Name = "EnterpriseCode_uLabel";
            this.EnterpriseCode_uLabel.Size = new System.Drawing.Size(78, 23);
            this.EnterpriseCode_uLabel.TabIndex = 4;
            this.EnterpriseCode_uLabel.Text = "商品ｺｰﾄﾞ";
            // 
            // Mode_Label
            // 
            appearance1.ForeColor = System.Drawing.Color.White;
            appearance1.TextHAlignAsString = "Center";
            appearance1.TextVAlignAsString = "Middle";
            this.Mode_Label.Appearance = appearance1;
            this.Mode_Label.BackColorInternal = System.Drawing.Color.Navy;
            this.Mode_Label.Location = new System.Drawing.Point(467, 8);
            this.Mode_Label.Name = "Mode_Label";
            this.Mode_Label.Size = new System.Drawing.Size(100, 23);
            this.Mode_Label.TabIndex = 62;
            this.Mode_Label.Text = "更新モード";
            // 
            // Delete_Button
            // 
            this.Delete_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Delete_Button.Location = new System.Drawing.Point(173, 220);
            this.Delete_Button.Name = "Delete_Button";
            this.Delete_Button.Size = new System.Drawing.Size(125, 34);
            this.Delete_Button.TabIndex = 6;
            this.Delete_Button.Text = "完全削除(&D)";
            this.Delete_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Delete_Button.Click += new System.EventHandler(this.Delete_Button_Click);
            // 
            // Ok_Button
            // 
            this.Ok_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Ok_Button.Location = new System.Drawing.Point(305, 220);
            this.Ok_Button.Name = "Ok_Button";
            this.Ok_Button.Size = new System.Drawing.Size(125, 34);
            this.Ok_Button.TabIndex = 7;
            this.Ok_Button.Text = "保存(&S)";
            this.Ok_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Ok_Button.Click += new System.EventHandler(this.Ok_Button_Click);
            // 
            // Cancel_Button
            // 
            this.Cancel_Button.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Cancel_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Cancel_Button.Location = new System.Drawing.Point(436, 220);
            this.Cancel_Button.Name = "Cancel_Button";
            this.Cancel_Button.Size = new System.Drawing.Size(125, 34);
            this.Cancel_Button.TabIndex = 8;
            this.Cancel_Button.Text = "閉じる(&X)";
            this.Cancel_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Cancel_Button.Click += new System.EventHandler(this.Cancel_Button_Click);
            // 
            // Revive_Button
            // 
            this.Revive_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Revive_Button.Location = new System.Drawing.Point(304, 220);
            this.Revive_Button.Name = "Revive_Button";
            this.Revive_Button.Size = new System.Drawing.Size(125, 34);
            this.Revive_Button.TabIndex = 7;
            this.Revive_Button.Text = "復活(&R)";
            this.Revive_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Revive_Button.Click += new System.EventHandler(this.Revive_Button_Click);
            // 
            // Bind_DataSet
            // 
            this.Bind_DataSet.DataSetName = "NewDataSet";
            // 
            // Timer
            // 
            this.Timer.Interval = 1;
            this.Timer.Tick += new System.EventHandler(this.Timer_Tick);
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
            this.uiSetControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tRetKeyControl1_ChangeFocus);
            // 
            // ultraStatusBar1
            // 
            this.ultraStatusBar1.Location = new System.Drawing.Point(0, 276);
            this.ultraStatusBar1.Name = "ultraStatusBar1";
            this.ultraStatusBar1.Size = new System.Drawing.Size(573, 23);
            this.ultraStatusBar1.TabIndex = 67;
            this.ultraStatusBar1.ViewStyle = Infragistics.Win.UltraWinStatusBar.ViewStyle.Office2003;
            // 
            // Renewal_Button
            // 
            this.Renewal_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Renewal_Button.Location = new System.Drawing.Point(173, 220);
            this.Renewal_Button.Name = "Renewal_Button";
            this.Renewal_Button.Size = new System.Drawing.Size(125, 34);
            this.Renewal_Button.TabIndex = 6;
            this.Renewal_Button.Text = "最新情報(&I)";
            this.Renewal_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Renewal_Button.Click += new System.EventHandler(this.Renewal_Button_Click);
            // 
            // tNedit_GoodsMakerCd
            // 
            appearance9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tNedit_GoodsMakerCd.ActiveAppearance = appearance9;
            appearance14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance14.ForeColorDisabled = System.Drawing.Color.Black;
            appearance14.TextHAlignAsString = "Right";
            this.tNedit_GoodsMakerCd.Appearance = appearance14;
            this.tNedit_GoodsMakerCd.AutoSelect = true;
            this.tNedit_GoodsMakerCd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tNedit_GoodsMakerCd.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_GoodsMakerCd.DataText = "";
            this.tNedit_GoodsMakerCd.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_GoodsMakerCd.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 6, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_GoodsMakerCd.Font = new System.Drawing.Font("ＭＳ ゴシック", 11F);
            this.tNedit_GoodsMakerCd.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tNedit_GoodsMakerCd.Location = new System.Drawing.Point(149, 52);
            this.tNedit_GoodsMakerCd.MaxLength = 6;
            this.tNedit_GoodsMakerCd.Name = "tNedit_GoodsMakerCd";
            this.tNedit_GoodsMakerCd.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, false, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.tNedit_GoodsMakerCd.Size = new System.Drawing.Size(43, 24);
            this.tNedit_GoodsMakerCd.TabIndex = 1;
            // 
            // tEdit_ABGoodsCode
            // 
            appearance2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance2.TextHAlignAsString = "Right";
            this.tEdit_ABGoodsCode.ActiveAppearance = appearance2;
            appearance5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance5.ForeColorDisabled = System.Drawing.Color.Black;
            appearance5.TextHAlignAsString = "Right";
            this.tEdit_ABGoodsCode.Appearance = appearance5;
            this.tEdit_ABGoodsCode.AutoSelect = true;
            this.tEdit_ABGoodsCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tEdit_ABGoodsCode.DataText = "";
            this.tEdit_ABGoodsCode.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_ABGoodsCode.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 2, new Broadleaf.Library.Windows.Forms.TEnableChars(false, true, false, false, true, true, true));
            this.tEdit_ABGoodsCode.Location = new System.Drawing.Point(149, 153);
            this.tEdit_ABGoodsCode.MaxLength = 2;
            this.tEdit_ABGoodsCode.Name = "tEdit_ABGoodsCode";
            this.tEdit_ABGoodsCode.Size = new System.Drawing.Size(74, 24);
            this.tEdit_ABGoodsCode.TabIndex = 5;
            // 
            // ultraLabel20
            // 
            this.ultraLabel20.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel20.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Inset;
            this.ultraLabel20.Location = new System.Drawing.Point(27, 133);
            this.ultraLabel20.Name = "ultraLabel20";
            this.ultraLabel20.Size = new System.Drawing.Size(520, 3);
            this.ultraLabel20.TabIndex = 71;
            // 
            // tEdit_GoodsNo
            // 
            appearance7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_GoodsNo.ActiveAppearance = appearance7;
            appearance8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance8.ForeColorDisabled = System.Drawing.Color.Black;
            appearance8.TextVAlignAsString = "Middle";
            this.tEdit_GoodsNo.Appearance = appearance8;
            this.tEdit_GoodsNo.AutoSelect = true;
            this.tEdit_GoodsNo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tEdit_GoodsNo.DataText = "";
            this.tEdit_GoodsNo.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_GoodsNo.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 2, new Broadleaf.Library.Windows.Forms.TEnableChars(false, true, false, false, true, true, true));
            this.tEdit_GoodsNo.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tEdit_GoodsNo.Location = new System.Drawing.Point(149, 94);
            this.tEdit_GoodsNo.MaxLength = 2;
            this.tEdit_GoodsNo.Name = "tEdit_GoodsNo";
            this.tEdit_GoodsNo.Size = new System.Drawing.Size(353, 24);
            this.tEdit_GoodsNo.TabIndex = 4;
            this.tEdit_GoodsNo.Tag = "";
            // 
            // GoodsNo_uLabel
            // 
            appearance13.TextVAlignAsString = "Middle";
            this.GoodsNo_uLabel.Appearance = appearance13;
            this.GoodsNo_uLabel.Location = new System.Drawing.Point(27, 95);
            this.GoodsNo_uLabel.Name = "GoodsNo_uLabel";
            this.GoodsNo_uLabel.Size = new System.Drawing.Size(78, 23);
            this.GoodsNo_uLabel.TabIndex = 72;
            this.GoodsNo_uLabel.Text = "品番";
            // 
            // PMSAE09040UA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(573, 299);
            this.Controls.Add(this.tEdit_GoodsNo);
            this.Controls.Add(this.GoodsNo_uLabel);
            this.Controls.Add(this.ultraLabel20);
            this.Controls.Add(this.tEdit_ABGoodsCode);
            this.Controls.Add(this.tNedit_GoodsMakerCd);
            this.Controls.Add(this.Renewal_Button);
            this.Controls.Add(this.ultraStatusBar1);
            this.Controls.Add(this.Cancel_Button);
            this.Controls.Add(this.Ok_Button);
            this.Controls.Add(this.Delete_Button);
            this.Controls.Add(this.Mode_Label);
            this.Controls.Add(this.EnterpriseCode_uLabel);
            this.Controls.Add(this.GoodsMakerGuide_Button);
            this.Controls.Add(this.tEdit_MakerName);
            this.Controls.Add(this.Section_uLabel);
            this.Controls.Add(this.Revive_Button);
            this.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.Name = "PMSAE09040UA";
            this.Text = "メーカー品番オートバックス商品コード変換マスタ";
            this.Load += new System.EventHandler(this.PMSAE09040U_Load);
            this.VisibleChanged += new System.EventHandler(this.PMSAE09040U_VisibleChanged);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.PMSAE09040U_Closing);
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_MakerName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bind_DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_GoodsMakerCd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_ABGoodsCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_GoodsNo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Infragistics.Win.Misc.UltraLabel Section_uLabel;
        private Broadleaf.Library.Windows.Forms.TEdit tEdit_MakerName;
        private Infragistics.Win.Misc.UltraButton GoodsMakerGuide_Button;
        private Infragistics.Win.UltraWinToolTip.UltraToolTipManager ultraToolTipManager1;
        private Infragistics.Win.Misc.UltraLabel EnterpriseCode_uLabel;
        private Infragistics.Win.Misc.UltraLabel Mode_Label;
        private Infragistics.Win.Misc.UltraButton Revive_Button;
        private Infragistics.Win.Misc.UltraButton Cancel_Button;
        private Infragistics.Win.Misc.UltraButton Ok_Button;
        private Infragistics.Win.Misc.UltraButton Delete_Button;
        private System.Data.DataSet Bind_DataSet;
        private System.Windows.Forms.Timer Timer;
        private Broadleaf.Library.Windows.Forms.TArrowKeyControl tArrowKeyControl1;
        private Broadleaf.Library.Windows.Forms.TRetKeyControl tRetKeyControl1;
        private Broadleaf.Library.Windows.Forms.UiSetControl uiSetControl1;
        private Infragistics.Win.UltraWinStatusBar.UltraStatusBar ultraStatusBar1;
        private Infragistics.Win.Misc.UltraButton Renewal_Button;
        private Broadleaf.Library.Windows.Forms.TNedit tNedit_GoodsMakerCd;
        private Broadleaf.Library.Windows.Forms.TEdit tEdit_ABGoodsCode;
        private Infragistics.Win.Misc.UltraLabel ultraLabel20;
        private Broadleaf.Library.Windows.Forms.TEdit tEdit_GoodsNo;
        private Infragistics.Win.Misc.UltraLabel GoodsNo_uLabel;
    }
}


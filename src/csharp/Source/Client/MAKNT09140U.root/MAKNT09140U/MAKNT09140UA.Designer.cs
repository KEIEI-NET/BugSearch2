namespace Broadleaf.Windows.Forms
{
    partial class MAKNT09140UA
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
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem1 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem2 = new Infragistics.Win.ValueListItem();
            this.ultraStatusBar1 = new Infragistics.Win.UltraWinStatusBar.UltraStatusBar();
            this.ApplyDateCd_uLabel = new Infragistics.Win.Misc.UltraLabel();
            this.Mode_Label = new Infragistics.Win.Misc.UltraLabel();
            this.SectionName_uLabel = new Infragistics.Win.Misc.UltraLabel();
            this.SectionName_tEdit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.Ok_Button = new Infragistics.Win.Misc.UltraButton();
            this.Cancel_Button = new Infragistics.Win.Misc.UltraButton();
            this.Initial_Timer = new System.Windows.Forms.Timer(this.components);
            this.Bind_DataSet = new System.Data.DataSet();
            this.tRetKeyControl1 = new Broadleaf.Library.Windows.Forms.TRetKeyControl(this.components);
            this.tArrowKeyControl1 = new Broadleaf.Library.Windows.Forms.TArrowKeyControl(this.components);
            this.ApplyDateCd_ultraOptionSet = new Infragistics.Win.UltraWinEditors.UltraOptionSet();
            this.ultraLabel3 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel2 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel4 = new Infragistics.Win.Misc.UltraLabel();
            this.tShape1 = new Broadleaf.Library.Windows.Forms.TShape();
            this.calendar_Control = new Broadleaf.Windows.Forms.Calendar_Control();
            ((System.ComponentModel.ISupportInitialize)(this.SectionName_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bind_DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ApplyDateCd_ultraOptionSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tShape1)).BeginInit();
            this.SuspendLayout();
            // 
            // ultraStatusBar1
            // 
            this.ultraStatusBar1.Location = new System.Drawing.Point(0, 716);
            this.ultraStatusBar1.Margin = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.ultraStatusBar1.Name = "ultraStatusBar1";
            this.ultraStatusBar1.Size = new System.Drawing.Size(806, 23);
            this.ultraStatusBar1.TabIndex = 0;
            this.ultraStatusBar1.ViewStyle = Infragistics.Win.UltraWinStatusBar.ViewStyle.Office2003;
            // 
            // ApplyDateCd_uLabel
            // 
            appearance1.TextVAlignAsString = "Middle";
            this.ApplyDateCd_uLabel.Appearance = appearance1;
            this.ApplyDateCd_uLabel.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ApplyDateCd_uLabel.Location = new System.Drawing.Point(30, 75);
            this.ApplyDateCd_uLabel.Name = "ApplyDateCd_uLabel";
            this.ApplyDateCd_uLabel.Size = new System.Drawing.Size(100, 23);
            this.ApplyDateCd_uLabel.TabIndex = 4;
            this.ApplyDateCd_uLabel.Text = "適用区分";
            // 
            // Mode_Label
            // 
            appearance2.ForeColor = System.Drawing.Color.White;
            appearance2.TextHAlignAsString = "Center";
            appearance2.TextVAlignAsString = "Middle";
            this.Mode_Label.Appearance = appearance2;
            this.Mode_Label.BackColorInternal = System.Drawing.Color.Navy;
            this.Mode_Label.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.Mode_Label.Location = new System.Drawing.Point(690, 12);
            this.Mode_Label.Name = "Mode_Label";
            this.Mode_Label.Size = new System.Drawing.Size(100, 23);
            this.Mode_Label.TabIndex = 6;
            // 
            // SectionName_uLabel
            // 
            appearance3.TextVAlignAsString = "Middle";
            this.SectionName_uLabel.Appearance = appearance3;
            this.SectionName_uLabel.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.SectionName_uLabel.Location = new System.Drawing.Point(30, 31);
            this.SectionName_uLabel.Name = "SectionName_uLabel";
            this.SectionName_uLabel.Size = new System.Drawing.Size(100, 23);
            this.SectionName_uLabel.TabIndex = 201;
            this.SectionName_uLabel.Text = "拠点名称";
            // 
            // SectionName_tEdit
            // 
            appearance4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance4.ForeColor = System.Drawing.Color.Black;
            appearance4.TextVAlignAsString = "Middle";
            this.SectionName_tEdit.ActiveAppearance = appearance4;
            appearance5.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance5.ForeColor = System.Drawing.Color.Black;
            appearance5.ForeColorDisabled = System.Drawing.Color.Black;
            this.SectionName_tEdit.Appearance = appearance5;
            this.SectionName_tEdit.AutoSelect = true;
            this.SectionName_tEdit.CalcSize = new System.Drawing.Size(172, 200);
            this.SectionName_tEdit.DataText = "";
            this.SectionName_tEdit.Enabled = false;
            this.SectionName_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.SectionName_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 12, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.SectionName_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.SectionName_tEdit.Location = new System.Drawing.Point(110, 31);
            this.SectionName_tEdit.MaxLength = 12;
            this.SectionName_tEdit.Name = "SectionName_tEdit";
            this.SectionName_tEdit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.SectionName_tEdit.Size = new System.Drawing.Size(128, 21);
            this.SectionName_tEdit.TabIndex = 203;
            // 
            // Ok_Button
            // 
            this.Ok_Button.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Ok_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Ok_Button.Location = new System.Drawing.Point(534, 667);
            this.Ok_Button.Name = "Ok_Button";
            this.Ok_Button.Size = new System.Drawing.Size(125, 34);
            this.Ok_Button.TabIndex = 5;
            this.Ok_Button.Text = "保存(&S)";
            this.Ok_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Ok_Button.Click += new System.EventHandler(this.Ok_Button_Click);
            // 
            // Cancel_Button
            // 
            this.Cancel_Button.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Cancel_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Cancel_Button.Location = new System.Drawing.Point(665, 667);
            this.Cancel_Button.Name = "Cancel_Button";
            this.Cancel_Button.Size = new System.Drawing.Size(125, 34);
            this.Cancel_Button.TabIndex = 6;
            this.Cancel_Button.Text = "閉じる(&X)";
            this.Cancel_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Cancel_Button.Click += new System.EventHandler(this.Cancel_Button_Click);
            // 
            // Initial_Timer
            // 
            this.Initial_Timer.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // Bind_DataSet
            // 
            this.Bind_DataSet.DataSetName = "NewDataSet";
            // 
            // tRetKeyControl1
            // 
            this.tRetKeyControl1.OwnerForm = this;
            this.tRetKeyControl1.Style = Broadleaf.Library.Windows.Forms.emFocusStyle.ByTab;
            // 
            // tArrowKeyControl1
            // 
            this.tArrowKeyControl1.OwnerForm = this;
            this.tArrowKeyControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tArrowKeyControl1_ChangeFocus);
            // 
            // ApplyDateCd_ultraOptionSet
            // 
            appearance6.TextHAlignAsString = "Center";
            appearance6.TextVAlignAsString = "Middle";
            this.ApplyDateCd_ultraOptionSet.Appearance = appearance6;
            this.ApplyDateCd_ultraOptionSet.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            appearance7.FontData.SizeInPoints = 11F;
            appearance7.TextHAlignAsString = "Center";
            appearance7.TextVAlignAsString = "Middle";
            this.ApplyDateCd_ultraOptionSet.ItemAppearance = appearance7;
            valueListItem1.DataValue = ((short)(0));
            valueListItem1.DisplayText = "休業日";
            valueListItem2.DataValue = ((short)(1));
            valueListItem2.DisplayText = "祝祭日";
            this.ApplyDateCd_ultraOptionSet.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem1,
            valueListItem2});
            this.ApplyDateCd_ultraOptionSet.Location = new System.Drawing.Point(110, 77);
            this.ApplyDateCd_ultraOptionSet.Name = "ApplyDateCd_ultraOptionSet";
            this.ApplyDateCd_ultraOptionSet.Size = new System.Drawing.Size(146, 19);
            this.ApplyDateCd_ultraOptionSet.TabIndex = 1;
            this.ApplyDateCd_ultraOptionSet.ValueChanged += new System.EventHandler(this.ApplyDateCd_ultraOptionSet_ValueChanged);
            // 
            // ultraLabel3
            // 
            this.ultraLabel3.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel3.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F);
            this.ultraLabel3.Location = new System.Drawing.Point(627, 69);
            this.ultraLabel3.Name = "ultraLabel3";
            this.ultraLabel3.Size = new System.Drawing.Size(45, 15);
            this.ultraLabel3.TabIndex = 205;
            this.ultraLabel3.Text = "休業日";
            // 
            // ultraLabel2
            // 
            this.ultraLabel2.BackColorInternal = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(230)))), ((int)(((byte)(148)))));
            this.ultraLabel2.Location = new System.Drawing.Point(593, 66);
            this.ultraLabel2.Name = "ultraLabel2";
            this.ultraLabel2.Size = new System.Drawing.Size(18, 18);
            this.ultraLabel2.TabIndex = 204;
            // 
            // ultraLabel1
            // 
            this.ultraLabel1.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel1.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F);
            this.ultraLabel1.Location = new System.Drawing.Point(729, 69);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(45, 15);
            this.ultraLabel1.TabIndex = 207;
            this.ultraLabel1.Text = "祝祭日";
            // 
            // ultraLabel4
            // 
            this.ultraLabel4.BackColorInternal = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(135)))), ((int)(((byte)(148)))));
            this.ultraLabel4.Location = new System.Drawing.Point(695, 67);
            this.ultraLabel4.Name = "ultraLabel4";
            this.ultraLabel4.Size = new System.Drawing.Size(18, 18);
            this.ultraLabel4.TabIndex = 206;
            // 
            // tShape1
            // 
            this.tShape1.BackColor = System.Drawing.Color.Transparent;
            this.tShape1.HatchBackColor = System.Drawing.Color.Empty;
            this.tShape1.HatchForeColor = System.Drawing.Color.Empty;
            this.tShape1.Location = new System.Drawing.Point(583, 57);
            this.tShape1.Name = "tShape1";
            this.tShape1.ShapeStyle = Broadleaf.Library.Windows.Forms.emShapeStyle.ssRectangle;
            this.tShape1.Size = new System.Drawing.Size(207, 39);
            this.tShape1.TabIndex = 208;
            this.tShape1.Text = "tShape1";
            // 
            // calendar_Control
            // 
            this.calendar_Control.ApplyDateCd = 0;
            this.calendar_Control.ApplyDateList = null;
            this.calendar_Control.BackColor = System.Drawing.Color.Transparent;
            this.calendar_Control.Location = new System.Drawing.Point(30, 115);
            this.calendar_Control.Name = "calendar_Control";
            this.calendar_Control.NextControl = null;
            this.calendar_Control.Size = new System.Drawing.Size(749, 542);
            this.calendar_Control.TabIndex = 2;
            this.calendar_Control.Year = 0;
            // 
            // MAKNT09140UA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(806, 739);
            this.Controls.Add(this.ultraLabel1);
            this.Controls.Add(this.ultraLabel4);
            this.Controls.Add(this.ultraLabel3);
            this.Controls.Add(this.ultraLabel2);
            this.Controls.Add(this.calendar_Control);
            this.Controls.Add(this.ApplyDateCd_ultraOptionSet);
            this.Controls.Add(this.Cancel_Button);
            this.Controls.Add(this.Ok_Button);
            this.Controls.Add(this.SectionName_tEdit);
            this.Controls.Add(this.SectionName_uLabel);
            this.Controls.Add(this.Mode_Label);
            this.Controls.Add(this.ApplyDateCd_uLabel);
            this.Controls.Add(this.ultraStatusBar1);
            this.Controls.Add(this.tShape1);
            this.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "MAKNT09140UA";
            this.Text = "営業日設定";
            this.Load += new System.EventHandler(this.MAKNT09140UA_Load);
            this.VisibleChanged += new System.EventHandler(this.MAKNT09140UA_VisibleChanged);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MAKNT09140UA_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.SectionName_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bind_DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ApplyDateCd_ultraOptionSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tShape1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Infragistics.Win.UltraWinStatusBar.UltraStatusBar ultraStatusBar1;
        private Infragistics.Win.Misc.UltraLabel ApplyDateCd_uLabel;
        private Infragistics.Win.Misc.UltraLabel Mode_Label;
        private Infragistics.Win.Misc.UltraLabel SectionName_uLabel;
        private Infragistics.Win.Misc.UltraButton Cancel_Button;
        private Infragistics.Win.Misc.UltraButton Ok_Button;
        private Broadleaf.Library.Windows.Forms.TNedit SectionName_tEdit;
        private System.Windows.Forms.Timer Initial_Timer;
        private System.Data.DataSet Bind_DataSet;
        private Broadleaf.Library.Windows.Forms.TRetKeyControl tRetKeyControl1;
        private Broadleaf.Library.Windows.Forms.TArrowKeyControl tArrowKeyControl1;
        private Infragistics.Win.UltraWinEditors.UltraOptionSet ApplyDateCd_ultraOptionSet;
        private Calendar_Control calendar_Control;
        private Infragistics.Win.Misc.UltraLabel ultraLabel1;
        private Infragistics.Win.Misc.UltraLabel ultraLabel4;
        private Infragistics.Win.Misc.UltraLabel ultraLabel3;
        private Infragistics.Win.Misc.UltraLabel ultraLabel2;
        private Broadleaf.Library.Windows.Forms.TShape tShape1;
    }
}


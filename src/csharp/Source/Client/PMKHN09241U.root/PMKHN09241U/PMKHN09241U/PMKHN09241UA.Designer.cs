namespace Broadleaf.Windows.Forms
{
    partial class PMKHN09241UA
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
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance26 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo( "得意先ガイド", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default );
            Infragistics.Win.Appearance appearance41 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance30 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance33 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance157 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance158 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance159 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance160 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance161 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance162 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance163 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance164 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( PMKHN09241UA ) );
            this.ultraStatusBar1 = new Infragistics.Win.UltraWinStatusBar.UltraStatusBar();
            this.tNedit_CustomerCode = new Broadleaf.Library.Windows.Forms.TNedit();
            this.CustomerGuide_Button = new Infragistics.Win.Misc.UltraButton();
            this.tEdit_CustomerName = new Broadleaf.Library.Windows.Forms.TEdit();
            this.Mode_Label = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel27 = new Infragistics.Win.Misc.UltraLabel();
            this.Cancel_Button = new Infragistics.Win.Misc.UltraButton();
            this.Delete_Button = new Infragistics.Win.Misc.UltraButton();
            this.Revive_Button = new Infragistics.Win.Misc.UltraButton();
            this.Ok_Button = new Infragistics.Win.Misc.UltraButton();
            this.uGrid_SumCustSt = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.tArrowKeyControl1 = new Broadleaf.Library.Windows.Forms.TArrowKeyControl( this.components );
            this.tRetKeyControl1 = new Broadleaf.Library.Windows.Forms.TRetKeyControl( this.components );
            this.uiSetControl1 = new Broadleaf.Library.Windows.Forms.UiSetControl( this.components );
            this.ultraToolTipManager1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipManager( this.components );
            this.Bind_DataSet = new System.Data.DataSet();
            this.Initial_Timer = new System.Windows.Forms.Timer( this.components );
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_CustomerCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_CustomerName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uGrid_SumCustSt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bind_DataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // ultraStatusBar1
            // 
            this.ultraStatusBar1.Location = new System.Drawing.Point( 0, 713 );
            this.ultraStatusBar1.Name = "ultraStatusBar1";
            this.ultraStatusBar1.Size = new System.Drawing.Size( 694, 23 );
            this.ultraStatusBar1.TabIndex = 205;
            this.ultraStatusBar1.ViewStyle = Infragistics.Win.UltraWinStatusBar.ViewStyle.Office2003;
            // 
            // tNedit_CustomerCode
            // 
            appearance5.BackColor = System.Drawing.Color.FromArgb( ((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))) );
            appearance5.ForeColor = System.Drawing.Color.Black;
            this.tNedit_CustomerCode.ActiveAppearance = appearance5;
            appearance6.BackColor = System.Drawing.Color.FromArgb( ((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))) );
            appearance6.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance6.ForeColor = System.Drawing.Color.Black;
            appearance6.ForeColorDisabled = System.Drawing.Color.Black;
            this.tNedit_CustomerCode.Appearance = appearance6;
            this.tNedit_CustomerCode.AutoSelect = true;
            this.tNedit_CustomerCode.BackColor = System.Drawing.Color.FromArgb( ((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))) );
            this.tNedit_CustomerCode.CalcSize = new System.Drawing.Size( 172, 200 );
            this.tNedit_CustomerCode.DataText = "";
            this.tNedit_CustomerCode.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase( true, true, true, true, true, true, true, true, false );
            this.tNedit_CustomerCode.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit( Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 12, new Broadleaf.Library.Windows.Forms.TEnableChars( false, false, false, false, false, true, true ) );
            this.tNedit_CustomerCode.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tNedit_CustomerCode.Location = new System.Drawing.Point( 118, 30 );
            this.tNedit_CustomerCode.MaxLength = 12;
            this.tNedit_CustomerCode.Name = "tNedit_CustomerCode";
            this.tNedit_CustomerCode.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit( false, 0, false, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF );
            this.tNedit_CustomerCode.Size = new System.Drawing.Size( 74, 24 );
            this.tNedit_CustomerCode.TabIndex = 0;
            // 
            // CustomerGuide_Button
            // 
            this.CustomerGuide_Button.AllowDrop = true;
            appearance26.ImageHAlign = Infragistics.Win.HAlign.Center;
            this.CustomerGuide_Button.Appearance = appearance26;
            this.CustomerGuide_Button.Location = new System.Drawing.Point( 377, 30 );
            this.CustomerGuide_Button.Name = "CustomerGuide_Button";
            this.CustomerGuide_Button.Size = new System.Drawing.Size( 24, 24 );
            this.CustomerGuide_Button.TabIndex = 2;
            this.CustomerGuide_Button.Tag = "";
            ultraToolTipInfo1.ToolTipText = "得意先ガイド";
            this.ultraToolTipManager1.SetUltraToolTip( this.CustomerGuide_Button, ultraToolTipInfo1 );
            this.CustomerGuide_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.CustomerGuide_Button.Click += new System.EventHandler( this.CustomerGuide_Button_Click );
            // 
            // tEdit_CustomerName
            // 
            appearance41.BackColor = System.Drawing.Color.FromArgb( ((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))) );
            this.tEdit_CustomerName.ActiveAppearance = appearance41;
            appearance18.BackColorDisabled = System.Drawing.Color.Gainsboro;
            appearance18.ForeColorDisabled = System.Drawing.Color.Black;
            this.tEdit_CustomerName.Appearance = appearance18;
            this.tEdit_CustomerName.AutoSelect = true;
            this.tEdit_CustomerName.DataText = "";
            this.tEdit_CustomerName.Enabled = false;
            this.tEdit_CustomerName.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase( true, true, true, true, true, true, true, true, false );
            this.tEdit_CustomerName.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit( Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 6, new Broadleaf.Library.Windows.Forms.TEnableChars( false, false, true, false, true, true, true ) );
            this.tEdit_CustomerName.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.tEdit_CustomerName.Location = new System.Drawing.Point( 200, 30 );
            this.tEdit_CustomerName.MaxLength = 6;
            this.tEdit_CustomerName.Name = "tEdit_CustomerName";
            this.tEdit_CustomerName.Size = new System.Drawing.Size( 167, 24 );
            this.tEdit_CustomerName.TabIndex = 1;
            this.tEdit_CustomerName.TabStop = false;
            // 
            // Mode_Label
            // 
            appearance30.ForeColor = System.Drawing.Color.White;
            appearance30.TextHAlignAsString = "Center";
            appearance30.TextVAlignAsString = "Middle";
            this.Mode_Label.Appearance = appearance30;
            this.Mode_Label.BackColorInternal = System.Drawing.Color.Navy;
            this.Mode_Label.Location = new System.Drawing.Point( 589, 5 );
            this.Mode_Label.Name = "Mode_Label";
            this.Mode_Label.Size = new System.Drawing.Size( 100, 23 );
            this.Mode_Label.TabIndex = 1230;
            // 
            // ultraLabel27
            // 
            appearance33.ForeColorDisabled = System.Drawing.Color.Black;
            appearance33.TextVAlignAsString = "Middle";
            this.ultraLabel27.Appearance = appearance33;
            this.ultraLabel27.Location = new System.Drawing.Point( 20, 30 );
            this.ultraLabel27.Name = "ultraLabel27";
            this.ultraLabel27.Size = new System.Drawing.Size( 92, 24 );
            this.ultraLabel27.TabIndex = 1229;
            this.ultraLabel27.Text = "総括得意先";
            // 
            // Cancel_Button
            // 
            this.Cancel_Button.ImageSize = new System.Drawing.Size( 24, 24 );
            this.Cancel_Button.Location = new System.Drawing.Point( 557, 664 );
            this.Cancel_Button.Name = "Cancel_Button";
            this.Cancel_Button.Size = new System.Drawing.Size( 125, 34 );
            this.Cancel_Button.TabIndex = 6;
            this.Cancel_Button.Text = "閉じる(&X)";
            this.Cancel_Button.Click += new System.EventHandler( this.Cancel_Button_Click );
            // 
            // Delete_Button
            // 
            this.Delete_Button.ImageSize = new System.Drawing.Size( 24, 24 );
            this.Delete_Button.Location = new System.Drawing.Point( 306, 664 );
            this.Delete_Button.Name = "Delete_Button";
            this.Delete_Button.Size = new System.Drawing.Size( 125, 34 );
            this.Delete_Button.TabIndex = 4;
            this.Delete_Button.Text = "完全削除(&D)";
            this.Delete_Button.Click += new System.EventHandler( this.Delete_Button_Click );
            // 
            // Revive_Button
            // 
            this.Revive_Button.ImageSize = new System.Drawing.Size( 24, 24 );
            this.Revive_Button.Location = new System.Drawing.Point( 431, 664 );
            this.Revive_Button.Name = "Revive_Button";
            this.Revive_Button.Size = new System.Drawing.Size( 125, 34 );
            this.Revive_Button.TabIndex = 5;
            this.Revive_Button.Text = "復活(&R)";
            this.Revive_Button.Click += new System.EventHandler( this.Revive_Button_Click );
            // 
            // Ok_Button
            // 
            this.Ok_Button.ImageSize = new System.Drawing.Size( 24, 24 );
            this.Ok_Button.Location = new System.Drawing.Point( 431, 664 );
            this.Ok_Button.Name = "Ok_Button";
            this.Ok_Button.Size = new System.Drawing.Size( 125, 34 );
            this.Ok_Button.TabIndex = 5;
            this.Ok_Button.Text = "保存(&S)";
            this.Ok_Button.Click += new System.EventHandler( this.Ok_Button_Click );
            // 
            // uGrid_SumCustSt
            // 
            appearance157.BackColor = System.Drawing.Color.White;
            appearance157.BackColor2 = System.Drawing.Color.FromArgb( ((int)(((byte)(198)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))) );
            appearance157.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.uGrid_SumCustSt.DisplayLayout.Appearance = appearance157;
            this.uGrid_SumCustSt.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.uGrid_SumCustSt.DisplayLayout.GroupByBox.Hidden = true;
            this.uGrid_SumCustSt.DisplayLayout.GroupByBox.Style = Infragistics.Win.UltraWinGrid.GroupByBoxStyle.Compact;
            this.uGrid_SumCustSt.DisplayLayout.InterBandSpacing = 10;
            this.uGrid_SumCustSt.DisplayLayout.MaxColScrollRegions = 1;
            this.uGrid_SumCustSt.DisplayLayout.MaxRowScrollRegions = 1;
            appearance158.BackColor = System.Drawing.Color.FromArgb( ((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))) );
            appearance158.ForeColor = System.Drawing.Color.Black;
            this.uGrid_SumCustSt.DisplayLayout.Override.ActiveCellAppearance = appearance158;
            this.uGrid_SumCustSt.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.Yes;
            this.uGrid_SumCustSt.DisplayLayout.Override.AllowColSizing = Infragistics.Win.UltraWinGrid.AllowColSizing.None;
            this.uGrid_SumCustSt.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
            this.uGrid_SumCustSt.DisplayLayout.Override.AllowRowSummaries = Infragistics.Win.UltraWinGrid.AllowRowSummaries.False;
            appearance159.ForeColor = System.Drawing.Color.Black;
            appearance159.ForeColorDisabled = System.Drawing.Color.Black;
            this.uGrid_SumCustSt.DisplayLayout.Override.CellAppearance = appearance159;
            this.uGrid_SumCustSt.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.uGrid_SumCustSt.DisplayLayout.Override.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
            appearance160.BackColor = System.Drawing.Color.FromArgb( ((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))) );
            appearance160.BackColor2 = System.Drawing.Color.FromArgb( ((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))) );
            appearance160.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance160.Cursor = System.Windows.Forms.Cursors.Hand;
            appearance160.ForeColor = System.Drawing.Color.White;
            appearance160.TextHAlignAsString = "Center";
            appearance160.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
            this.uGrid_SumCustSt.DisplayLayout.Override.HeaderAppearance = appearance160;
            this.uGrid_SumCustSt.DisplayLayout.Override.MaxSelectedCells = 1;
            this.uGrid_SumCustSt.DisplayLayout.Override.MaxSelectedRows = 1;
            appearance161.BackColor = System.Drawing.Color.Lavender;
            this.uGrid_SumCustSt.DisplayLayout.Override.RowAlternateAppearance = appearance161;
            appearance162.BorderColor = System.Drawing.Color.FromArgb( ((int)(((byte)(1)))), ((int)(((byte)(68)))), ((int)(((byte)(208)))) );
            appearance162.TextVAlignAsString = "Middle";
            this.uGrid_SumCustSt.DisplayLayout.Override.RowAppearance = appearance162;
            appearance163.BackColor = System.Drawing.Color.FromArgb( ((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))) );
            appearance163.BackColor2 = System.Drawing.Color.FromArgb( ((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))) );
            appearance163.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance163.ForeColor = System.Drawing.Color.White;
            this.uGrid_SumCustSt.DisplayLayout.Override.RowSelectorAppearance = appearance163;
            this.uGrid_SumCustSt.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            this.uGrid_SumCustSt.DisplayLayout.Override.RowSelectorWidth = 12;
            this.uGrid_SumCustSt.DisplayLayout.Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.AutoFixed;
            appearance164.BackColor = System.Drawing.Color.FromArgb( ((int)(((byte)(251)))), ((int)(((byte)(230)))), ((int)(((byte)(148)))) );
            appearance164.BackColor2 = System.Drawing.Color.FromArgb( ((int)(((byte)(238)))), ((int)(((byte)(149)))), ((int)(((byte)(21)))) );
            appearance164.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance164.ForeColor = System.Drawing.Color.Black;
            this.uGrid_SumCustSt.DisplayLayout.Override.SelectedRowAppearance = appearance164;
            this.uGrid_SumCustSt.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.uGrid_SumCustSt.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.uGrid_SumCustSt.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.uGrid_SumCustSt.DisplayLayout.Override.TipStyleCell = Infragistics.Win.UltraWinGrid.TipStyle.Hide;
            this.uGrid_SumCustSt.DisplayLayout.Override.TipStyleRowConnector = Infragistics.Win.UltraWinGrid.TipStyle.Hide;
            this.uGrid_SumCustSt.DisplayLayout.Override.TipStyleScroll = Infragistics.Win.UltraWinGrid.TipStyle.Hide;
            this.uGrid_SumCustSt.DisplayLayout.RowConnectorColor = System.Drawing.Color.FromArgb( ((int)(((byte)(168)))), ((int)(((byte)(167)))), ((int)(((byte)(191)))) );
            this.uGrid_SumCustSt.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.uGrid_SumCustSt.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.uGrid_SumCustSt.DisplayLayout.UseFixedHeaders = true;
            this.uGrid_SumCustSt.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand;
            this.uGrid_SumCustSt.Font = new System.Drawing.Font( "ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)) );
            this.uGrid_SumCustSt.Location = new System.Drawing.Point( 20, 69 );
            this.uGrid_SumCustSt.Name = "uGrid_SumCustSt";
            this.uGrid_SumCustSt.Size = new System.Drawing.Size( 653, 575 );
            this.uGrid_SumCustSt.TabIndex = 3;
            this.uGrid_SumCustSt.ClickCellButton += new Infragistics.Win.UltraWinGrid.CellEventHandler( this.uGrid_SumCustSt_ClickCellButton );
            this.uGrid_SumCustSt.BeforeEnterEditMode += new System.ComponentModel.CancelEventHandler( this.uGrid_SumCustSt_BeforeEnterEditMode );
            this.uGrid_SumCustSt.AfterExitEditMode += new System.EventHandler( this.uGrid_SumCustSt_AfterExitEditMode );
            this.uGrid_SumCustSt.KeyPress += new System.Windows.Forms.KeyPressEventHandler( this.uGrid_SumCustSt_KeyPress );
            this.uGrid_SumCustSt.Leave += new System.EventHandler( this.uGrid_SumCustSt_Leave );
            this.uGrid_SumCustSt.KeyDown += new System.Windows.Forms.KeyEventHandler( this.uGrid_SumCustSt_KeyDown );
            // 
            // tArrowKeyControl1
            // 
            this.tArrowKeyControl1.OwnerForm = this;
            this.tArrowKeyControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler( this.tRetKeyControl1_ChangeFocus );
            // 
            // tRetKeyControl1
            // 
            this.tRetKeyControl1.OwnerForm = this;
            this.tRetKeyControl1.Style = Broadleaf.Library.Windows.Forms.emFocusStyle.ByTab;
            this.tRetKeyControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler( this.tRetKeyControl1_ChangeFocus );
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
            this.Initial_Timer.Tick += new System.EventHandler( this.Initial_Timer_Tick );
            // 
            // PMKHN09241UA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 8F, 15F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size( 694, 736 );
            this.Controls.Add( this.uGrid_SumCustSt );
            this.Controls.Add( this.Cancel_Button );
            this.Controls.Add( this.Delete_Button );
            this.Controls.Add( this.Revive_Button );
            this.Controls.Add( this.Ok_Button );
            this.Controls.Add( this.tNedit_CustomerCode );
            this.Controls.Add( this.CustomerGuide_Button );
            this.Controls.Add( this.tEdit_CustomerName );
            this.Controls.Add( this.Mode_Label );
            this.Controls.Add( this.ultraLabel27 );
            this.Controls.Add( this.ultraStatusBar1 );
            this.Font = new System.Drawing.Font( "ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)) );
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject( "$this.Icon" )));
            this.Margin = new System.Windows.Forms.Padding( 4 );
            this.MaximizeBox = false;
            this.Name = "PMKHN09241UA";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "得意先マスタ(総括設定)";
            this.Load += new System.EventHandler( this.PMKHN09241UA_Load );
            this.VisibleChanged += new System.EventHandler( this.PMKHN09241UA_VisibleChanged );
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler( this.PMKHN09241UA_FormClosing );
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_CustomerCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_CustomerName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uGrid_SumCustSt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bind_DataSet)).EndInit();
            this.ResumeLayout( false );
            this.PerformLayout();

        }

        #endregion

        private Infragistics.Win.UltraWinStatusBar.UltraStatusBar ultraStatusBar1;
        private Broadleaf.Library.Windows.Forms.TNedit tNedit_CustomerCode;
        private Infragistics.Win.Misc.UltraButton CustomerGuide_Button;
        private Broadleaf.Library.Windows.Forms.TEdit tEdit_CustomerName;
        private Infragistics.Win.Misc.UltraLabel Mode_Label;
        private Infragistics.Win.Misc.UltraLabel ultraLabel27;
        private Infragistics.Win.Misc.UltraButton Cancel_Button;
        private Infragistics.Win.Misc.UltraButton Delete_Button;
        private Infragistics.Win.Misc.UltraButton Revive_Button;
        private Infragistics.Win.Misc.UltraButton Ok_Button;
        private Infragistics.Win.UltraWinGrid.UltraGrid uGrid_SumCustSt;
        private Broadleaf.Library.Windows.Forms.TArrowKeyControl tArrowKeyControl1;
        private Broadleaf.Library.Windows.Forms.TRetKeyControl tRetKeyControl1;
        private Broadleaf.Library.Windows.Forms.UiSetControl uiSetControl1;
        private Infragistics.Win.UltraWinToolTip.UltraToolTipManager ultraToolTipManager1;
        private System.Data.DataSet Bind_DataSet;
        private System.Windows.Forms.Timer Initial_Timer;


    }
}
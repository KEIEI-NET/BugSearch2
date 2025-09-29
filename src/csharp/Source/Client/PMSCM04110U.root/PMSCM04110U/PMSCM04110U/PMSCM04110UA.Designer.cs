namespace Broadleaf.Windows.Forms
{
    partial class PMSCM04110UA
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
            Infragistics.Win.Appearance appearance44 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance42 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PMSCM04110UA));
            this.dockableWindow1 = new Infragistics.Win.UltraWinDock.DockableWindow();
            this.tMemPos1 = new Broadleaf.Library.Windows.Forms.TMemPos(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel_GridView = new System.Windows.Forms.Panel();
            this.grid_SynchConfirm = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.panel_Bottom = new System.Windows.Forms.Panel();
            this.lable_ErrorMessage = new Infragistics.Win.Misc.UltraLabel();
            this.btn_ReRead = new Infragistics.Win.Misc.UltraButton();
            this.btn_Close = new Infragistics.Win.Misc.UltraButton();
            this.btn_Synch = new Infragistics.Win.Misc.UltraButton();
            this.panel_Top = new System.Windows.Forms.Panel();
            this.btn_SelectAll = new Infragistics.Win.Misc.UltraButton();
            this.btn_CancelAll = new Infragistics.Win.Misc.UltraButton();
            this.tRetKeyControl1 = new Broadleaf.Library.Windows.Forms.TRetKeyControl(this.components);
            this.tArrowKeyControl1 = new Broadleaf.Library.Windows.Forms.TArrowKeyControl(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.panel_GridView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid_SynchConfirm)).BeginInit();
            this.panel_Bottom.SuspendLayout();
            this.panel_Top.SuspendLayout();
            this.SuspendLayout();
            // 
            // dockableWindow1
            // 
            this.dockableWindow1.Location = new System.Drawing.Point(0, 0);
            this.dockableWindow1.Name = "dockableWindow1";
            this.dockableWindow1.Size = new System.Drawing.Size(0, 0);
            this.dockableWindow1.TabIndex = 0;
            // 
            // tMemPos1
            // 
            this.tMemPos1.OwnerForm = this;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel_GridView);
            this.panel1.Controls.Add(this.panel_Bottom);
            this.panel1.Controls.Add(this.panel_Top);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1008, 412);
            this.panel1.TabIndex = 32;
            // 
            // panel_GridView
            // 
            this.panel_GridView.Controls.Add(this.grid_SynchConfirm);
            this.panel_GridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_GridView.Location = new System.Drawing.Point(0, 66);
            this.panel_GridView.Name = "panel_GridView";
            this.panel_GridView.Size = new System.Drawing.Size(1008, 256);
            this.panel_GridView.TabIndex = 4;
            // 
            // grid_SynchConfirm
            // 
            appearance44.BackColor = System.Drawing.Color.White;
            appearance44.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            appearance44.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance44.ForeColorDisabled = System.Drawing.Color.Black;
            this.grid_SynchConfirm.DisplayLayout.Appearance = appearance44;
            this.grid_SynchConfirm.DisplayLayout.GroupByBox.Hidden = true;
            this.grid_SynchConfirm.DisplayLayout.InterBandSpacing = 0;
            this.grid_SynchConfirm.DisplayLayout.MaxColScrollRegions = 1;
            this.grid_SynchConfirm.DisplayLayout.MaxRowScrollRegions = 1;
            this.grid_SynchConfirm.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No;
            this.grid_SynchConfirm.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
            this.grid_SynchConfirm.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
            this.grid_SynchConfirm.DisplayLayout.Override.AllowRowSummaries = Infragistics.Win.UltraWinGrid.AllowRowSummaries.False;
            this.grid_SynchConfirm.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.False;
            this.grid_SynchConfirm.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            this.grid_SynchConfirm.DisplayLayout.Override.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
            appearance42.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance42.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance42.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance42.BorderColor = System.Drawing.Color.White;
            appearance42.BorderColor2 = System.Drawing.Color.White;
            appearance42.ForeColor = System.Drawing.Color.White;
            appearance42.ForeColorDisabled = System.Drawing.Color.White;
            appearance42.TextHAlignAsString = "Center";
            appearance42.TextVAlignAsString = "Middle";
            appearance42.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
            this.grid_SynchConfirm.DisplayLayout.Override.HeaderAppearance = appearance42;
            this.grid_SynchConfirm.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.Select;
            this.grid_SynchConfirm.DisplayLayout.Override.MinRowHeight = 20;
            appearance3.BackColor = System.Drawing.Color.Lavender;
            this.grid_SynchConfirm.DisplayLayout.Override.RowAlternateAppearance = appearance3;
            appearance4.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(68)))), ((int)(((byte)(208)))));
            this.grid_SynchConfirm.DisplayLayout.Override.RowAppearance = appearance4;
            this.grid_SynchConfirm.DisplayLayout.Override.RowFilterAction = Infragistics.Win.UltraWinGrid.RowFilterAction.HideFilteredOutRows;
            this.grid_SynchConfirm.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand;
            appearance5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance5.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance5.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance5.ForeColor = System.Drawing.Color.White;
            appearance5.ForeColorDisabled = System.Drawing.Color.White;
            appearance5.TextHAlignAsString = "Right";
            this.grid_SynchConfirm.DisplayLayout.Override.RowSelectorAppearance = appearance5;
            this.grid_SynchConfirm.DisplayLayout.Override.RowSelectorNumberStyle = Infragistics.Win.UltraWinGrid.RowSelectorNumberStyle.RowIndex;
            this.grid_SynchConfirm.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True;
            this.grid_SynchConfirm.DisplayLayout.Override.RowSelectorWidth = 29;
            this.grid_SynchConfirm.DisplayLayout.Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.Fixed;
            appearance6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(230)))), ((int)(((byte)(148)))));
            appearance6.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(149)))), ((int)(((byte)(21)))));
            appearance6.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance6.ForeColor = System.Drawing.Color.Black;
            this.grid_SynchConfirm.DisplayLayout.Override.SelectedRowAppearance = appearance6;
            this.grid_SynchConfirm.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.grid_SynchConfirm.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.grid_SynchConfirm.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Single;
            this.grid_SynchConfirm.DisplayLayout.RowConnectorColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(167)))), ((int)(((byte)(191)))));
            this.grid_SynchConfirm.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.None;
            this.grid_SynchConfirm.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.grid_SynchConfirm.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.grid_SynchConfirm.DisplayLayout.UseFixedHeaders = true;
            this.grid_SynchConfirm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid_SynchConfirm.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.grid_SynchConfirm.Location = new System.Drawing.Point(0, 0);
            this.grid_SynchConfirm.Margin = new System.Windows.Forms.Padding(1);
            this.grid_SynchConfirm.Name = "grid_SynchConfirm";
            this.grid_SynchConfirm.Size = new System.Drawing.Size(1008, 256);
            this.grid_SynchConfirm.TabIndex = 5;
            this.grid_SynchConfirm.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.grid_SynchConfirm_InitializeLayout);
            this.grid_SynchConfirm.DoubleClickRow += new Infragistics.Win.UltraWinGrid.DoubleClickRowEventHandler(this.grid_SynchConfirm_DoubleClickRow);
            this.grid_SynchConfirm.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grid_SynchConfirm_KeyDown);
            this.grid_SynchConfirm.Leave += new System.EventHandler(this.grid_SynchConfirm_Leave);
            // 
            // panel_Bottom
            // 
            this.panel_Bottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(254)))));
            this.panel_Bottom.Controls.Add(this.lable_ErrorMessage);
            this.panel_Bottom.Controls.Add(this.btn_ReRead);
            this.panel_Bottom.Controls.Add(this.btn_Close);
            this.panel_Bottom.Controls.Add(this.btn_Synch);
            this.panel_Bottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel_Bottom.Location = new System.Drawing.Point(0, 322);
            this.panel_Bottom.Name = "panel_Bottom";
            this.panel_Bottom.Size = new System.Drawing.Size(1008, 90);
            this.panel_Bottom.TabIndex = 10;
            // 
            // lable_ErrorMessage
            // 
            this.lable_ErrorMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            appearance15.BackColor = System.Drawing.Color.Transparent;
            appearance15.TextHAlignAsString = "Left";
            appearance15.TextVAlignAsString = "Top";
            this.lable_ErrorMessage.Appearance = appearance15;
            this.lable_ErrorMessage.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lable_ErrorMessage.Location = new System.Drawing.Point(13, 18);
            this.lable_ErrorMessage.Name = "lable_ErrorMessage";
            this.lable_ErrorMessage.Size = new System.Drawing.Size(567, 59);
            this.lable_ErrorMessage.TabIndex = 62;
            this.lable_ErrorMessage.Visible = false;
            // 
            // btn_ReRead
            // 
            this.btn_ReRead.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_ReRead.Location = new System.Drawing.Point(657, 26);
            this.btn_ReRead.Name = "btn_ReRead";
            this.btn_ReRead.Size = new System.Drawing.Size(100, 45);
            this.btn_ReRead.TabIndex = 10;
            this.btn_ReRead.Text = "再読み込み";
            this.btn_ReRead.Click += new System.EventHandler(this.btn_ReRead_Click);
            // 
            // btn_Close
            // 
            this.btn_Close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Close.Location = new System.Drawing.Point(883, 26);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(100, 45);
            this.btn_Close.TabIndex = 12;
            this.btn_Close.Text = "閉じる(&X)";
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // btn_Synch
            // 
            this.btn_Synch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Synch.Location = new System.Drawing.Point(770, 26);
            this.btn_Synch.Name = "btn_Synch";
            this.btn_Synch.Size = new System.Drawing.Size(100, 45);
            this.btn_Synch.TabIndex = 11;
            this.btn_Synch.Text = "再送信(&S)";
            this.btn_Synch.Click += new System.EventHandler(this.btn_Synch_Click);
            // 
            // panel_Top
            // 
            this.panel_Top.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(254)))));
            this.panel_Top.Controls.Add(this.btn_SelectAll);
            this.panel_Top.Controls.Add(this.btn_CancelAll);
            this.panel_Top.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_Top.Location = new System.Drawing.Point(0, 0);
            this.panel_Top.Name = "panel_Top";
            this.panel_Top.Size = new System.Drawing.Size(1008, 66);
            this.panel_Top.TabIndex = 0;
            // 
            // btn_SelectAll
            // 
            this.btn_SelectAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_SelectAll.Location = new System.Drawing.Point(770, 24);
            this.btn_SelectAll.Name = "btn_SelectAll";
            this.btn_SelectAll.Size = new System.Drawing.Size(91, 25);
            this.btn_SelectAll.TabIndex = 1;
            this.btn_SelectAll.Text = "全て選択";
            this.btn_SelectAll.Click += new System.EventHandler(this.btn_SelectAll_Click);
            // 
            // btn_CancelAll
            // 
            this.btn_CancelAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_CancelAll.Location = new System.Drawing.Point(883, 24);
            this.btn_CancelAll.Name = "btn_CancelAll";
            this.btn_CancelAll.Size = new System.Drawing.Size(91, 25);
            this.btn_CancelAll.TabIndex = 2;
            this.btn_CancelAll.Text = "全て解除";
            this.btn_CancelAll.Click += new System.EventHandler(this.btn_CancelAll_Click);
            // 
            // tRetKeyControl1
            // 
            this.tRetKeyControl1.OwnerForm = this;
            this.tRetKeyControl1.Style = Broadleaf.Library.Windows.Forms.emFocusStyle.ByTab;
            this.tRetKeyControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tArrowKeyControl1_ChangeFocus);
            // 
            // tArrowKeyControl1
            // 
            this.tArrowKeyControl1.OwnerForm = this;
            this.tArrowKeyControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tArrowKeyControl1_ChangeFocus);
            // 
            // timer1
            // 
            this.timer1.Interval = 200;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // PMSCM04110UA
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(1008, 412);
            this.Controls.Add(this.dockableWindow1);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(100, 50);
            this.Name = "PMSCM04110UA";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "同期状況確認";
            this.Load += new System.EventHandler(this.PMSCM04110UA_Load);
            this.panel1.ResumeLayout(false);
            this.panel_GridView.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grid_SynchConfirm)).EndInit();
            this.panel_Bottom.ResumeLayout(false);
            this.panel_Top.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.UltraWinDock.DockableWindow dockableWindow1;
        private Broadleaf.Library.Windows.Forms.TMemPos tMemPos1;
        private System.Windows.Forms.Panel panel1;
        private Broadleaf.Library.Windows.Forms.TRetKeyControl tRetKeyControl1;
        private Broadleaf.Library.Windows.Forms.TArrowKeyControl tArrowKeyControl1;
        private System.Windows.Forms.Panel panel_Bottom;
        private System.Windows.Forms.Panel panel_Top;
        private System.Windows.Forms.Panel panel_GridView;
        private Infragistics.Win.Misc.UltraButton btn_Close;
        private Infragistics.Win.Misc.UltraButton btn_Synch;
        private Infragistics.Win.Misc.UltraButton btn_SelectAll;
        private Infragistics.Win.Misc.UltraButton btn_CancelAll;
        private Infragistics.Win.Misc.UltraButton btn_ReRead;
        private Infragistics.Win.Misc.UltraLabel lable_ErrorMessage;
        private Infragistics.Win.UltraWinGrid.UltraGrid grid_SynchConfirm;
        private System.Windows.Forms.Timer timer1;

    }
}


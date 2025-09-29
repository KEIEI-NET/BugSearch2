namespace Broadleaf.Windows.Forms
{
    partial class PMHNB04151UB
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
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem7 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem8 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab1 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem3 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem4 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem5 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem6 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem1 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem2 = new Infragistics.Win.ValueListItem();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PMHNB04151UB));
            this.ultraTabPageControl1 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.uComboEditor_StartupSearch = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.uLabel3 = new Infragistics.Win.Misc.UltraLabel();
            this.uLabel2 = new Infragistics.Win.Misc.UltraLabel();
            this.uLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraTabControl1 = new Infragistics.Win.UltraWinTabControl.UltraTabControl();
            this.ultraTabSharedControlsPage1 = new Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage();
            this.uButton_OK = new Infragistics.Win.Misc.UltraButton();
            this.uButton_Cancel = new Infragistics.Win.Misc.UltraButton();
            this.tRetKeyControl = new Broadleaf.Library.Windows.Forms.TRetKeyControl(this.components);
            this.tArrowKeyControl = new Broadleaf.Library.Windows.Forms.TArrowKeyControl(this.components);
            this.uComboEditor_AutoUpdate = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.uComboEditor_DefaultSecCode = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.ultraTabPageControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uComboEditor_StartupSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraTabControl1)).BeginInit();
            this.ultraTabControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uComboEditor_AutoUpdate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uComboEditor_DefaultSecCode)).BeginInit();
            this.SuspendLayout();
            // 
            // ultraTabPageControl1
            // 
            this.ultraTabPageControl1.Controls.Add(this.uComboEditor_DefaultSecCode);
            this.ultraTabPageControl1.Controls.Add(this.uComboEditor_AutoUpdate);
            this.ultraTabPageControl1.Controls.Add(this.uComboEditor_StartupSearch);
            this.ultraTabPageControl1.Controls.Add(this.uLabel3);
            this.ultraTabPageControl1.Controls.Add(this.uLabel2);
            this.ultraTabPageControl1.Controls.Add(this.uLabel1);
            this.ultraTabPageControl1.Location = new System.Drawing.Point(1, 24);
            this.ultraTabPageControl1.Name = "ultraTabPageControl1";
            this.ultraTabPageControl1.Size = new System.Drawing.Size(357, 120);
            // 
            // uComboEditor_StartupSearch
            // 
            appearance8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.uComboEditor_StartupSearch.ActiveAppearance = appearance8;
            appearance9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.uComboEditor_StartupSearch.Appearance = appearance9;
            this.uComboEditor_StartupSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            valueListItem7.DataValue = 0;
            valueListItem7.DisplayText = "する";
            valueListItem8.DataValue = 1;
            valueListItem8.DisplayText = "しない";
            this.uComboEditor_StartupSearch.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem7,
            valueListItem8});
            this.uComboEditor_StartupSearch.Location = new System.Drawing.Point(137, 19);
            this.uComboEditor_StartupSearch.Name = "uComboEditor_StartupSearch";
            this.uComboEditor_StartupSearch.Size = new System.Drawing.Size(200, 24);
            this.uComboEditor_StartupSearch.TabIndex = 1;
            this.uComboEditor_StartupSearch.Leave += new System.EventHandler(this.uComboEditor_StartupSearch_Leave);
            // 
            // uLabel3
            // 
            appearance4.BackColorAlpha = Infragistics.Win.Alpha.Transparent;
            appearance4.TextVAlignAsString = "Middle";
            this.uLabel3.Appearance = appearance4;
            this.uLabel3.Location = new System.Drawing.Point(18, 79);
            this.uLabel3.Name = "uLabel3";
            this.uLabel3.Size = new System.Drawing.Size(136, 23);
            this.uLabel3.TabIndex = 2;
            this.uLabel3.Text = "拠点の初期値";
            // 
            // uLabel2
            // 
            appearance3.BackColorAlpha = Infragistics.Win.Alpha.Transparent;
            appearance3.TextVAlignAsString = "Middle";
            this.uLabel2.Appearance = appearance3;
            this.uLabel2.Location = new System.Drawing.Point(18, 50);
            this.uLabel2.Name = "uLabel2";
            this.uLabel2.Size = new System.Drawing.Size(136, 23);
            this.uLabel2.TabIndex = 1;
            this.uLabel2.Text = "自動更新";
            // 
            // uLabel1
            // 
            appearance2.BackColorAlpha = Infragistics.Win.Alpha.Transparent;
            appearance2.TextVAlignAsString = "Middle";
            this.uLabel1.Appearance = appearance2;
            this.uLabel1.Location = new System.Drawing.Point(18, 20);
            this.uLabel1.Name = "uLabel1";
            this.uLabel1.Size = new System.Drawing.Size(136, 23);
            this.uLabel1.TabIndex = 0;
            this.uLabel1.Text = "起動時の抽出";
            // 
            // ultraTabControl1
            // 
            this.ultraTabControl1.Controls.Add(this.ultraTabSharedControlsPage1);
            this.ultraTabControl1.Controls.Add(this.ultraTabPageControl1);
            this.ultraTabControl1.Location = new System.Drawing.Point(12, 12);
            this.ultraTabControl1.Name = "ultraTabControl1";
            this.ultraTabControl1.SharedControlsPage = this.ultraTabSharedControlsPage1;
            this.ultraTabControl1.Size = new System.Drawing.Size(361, 147);
            this.ultraTabControl1.TabIndex = 0;
            appearance1.BackColor = System.Drawing.Color.White;
            appearance1.BackColor2 = System.Drawing.Color.GhostWhite;
            appearance1.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            ultraTab1.Appearance = appearance1;
            ultraTab1.Key = "Setting";
            ultraTab1.TabPage = this.ultraTabPageControl1;
            ultraTab1.Text = "ユーザー設定";
            this.ultraTabControl1.Tabs.AddRange(new Infragistics.Win.UltraWinTabControl.UltraTab[] {
            ultraTab1});
            // 
            // ultraTabSharedControlsPage1
            // 
            this.ultraTabSharedControlsPage1.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraTabSharedControlsPage1.Name = "ultraTabSharedControlsPage1";
            this.ultraTabSharedControlsPage1.Size = new System.Drawing.Size(357, 120);
            // 
            // uButton_OK
            // 
            this.uButton_OK.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uButton_OK.Location = new System.Drawing.Point(166, 165);
            this.uButton_OK.Name = "uButton_OK";
            this.uButton_OK.Size = new System.Drawing.Size(96, 26);
            this.uButton_OK.TabIndex = 11;
            this.uButton_OK.Text = "ＯＫ";
            this.uButton_OK.Click += new System.EventHandler(this.uButton_OK_Click);
            // 
            // uButton_Cancel
            // 
            this.uButton_Cancel.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uButton_Cancel.Location = new System.Drawing.Point(269, 165);
            this.uButton_Cancel.Name = "uButton_Cancel";
            this.uButton_Cancel.Size = new System.Drawing.Size(96, 26);
            this.uButton_Cancel.TabIndex = 12;
            this.uButton_Cancel.Text = "キャンセル";
            this.uButton_Cancel.Click += new System.EventHandler(this.uButton_Cancel_Click);
            // 
            // tRetKeyControl
            // 
            this.tRetKeyControl.OwnerForm = this;
            this.tRetKeyControl.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tArrowKeyControl_ChangeFocus);
            // 
            // tArrowKeyControl
            // 
            this.tArrowKeyControl.OwnerForm = this;
            this.tArrowKeyControl.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tArrowKeyControl_ChangeFocus);
            // 
            // uComboEditor_AutoUpdate
            // 
            appearance5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.uComboEditor_AutoUpdate.ActiveAppearance = appearance5;
            appearance10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.uComboEditor_AutoUpdate.Appearance = appearance10;
            this.uComboEditor_AutoUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            valueListItem3.DataValue = 0;
            valueListItem3.DisplayText = "しない";
            valueListItem4.DataValue = 5;
            valueListItem4.DisplayText = "5分毎";
            valueListItem5.DataValue = 30;
            valueListItem5.DisplayText = "30分毎";
            valueListItem6.DataValue = 60;
            valueListItem6.DisplayText = "1時間毎";
            this.uComboEditor_AutoUpdate.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem3,
            valueListItem4,
            valueListItem5,
            valueListItem6});
            this.uComboEditor_AutoUpdate.Location = new System.Drawing.Point(137, 49);
            this.uComboEditor_AutoUpdate.Name = "uComboEditor_AutoUpdate";
            this.uComboEditor_AutoUpdate.Size = new System.Drawing.Size(200, 24);
            this.uComboEditor_AutoUpdate.TabIndex = 2;
            this.uComboEditor_AutoUpdate.Leave += new System.EventHandler(this.uComboEditor_AutoUpdate_Leave);
            // 
            // uComboEditor_DefaultSecCode
            // 
            appearance11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.uComboEditor_DefaultSecCode.ActiveAppearance = appearance11;
            appearance12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.uComboEditor_DefaultSecCode.Appearance = appearance12;
            this.uComboEditor_DefaultSecCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            valueListItem1.DataValue = 0;
            valueListItem1.DisplayText = "自拠点";
            valueListItem2.DataValue = 1;
            valueListItem2.DisplayText = "全社";
            this.uComboEditor_DefaultSecCode.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem1,
            valueListItem2});
            this.uComboEditor_DefaultSecCode.Location = new System.Drawing.Point(137, 79);
            this.uComboEditor_DefaultSecCode.Name = "uComboEditor_DefaultSecCode";
            this.uComboEditor_DefaultSecCode.Size = new System.Drawing.Size(200, 24);
            this.uComboEditor_DefaultSecCode.TabIndex = 4;
            this.uComboEditor_DefaultSecCode.Leave += new System.EventHandler(this.uComboEditor_DefaultSecCode_Leave);
            // 
            // PMHNB04151UB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.GhostWhite;
            this.ClientSize = new System.Drawing.Size(383, 202);
            this.Controls.Add(this.uButton_Cancel);
            this.Controls.Add(this.uButton_OK);
            this.Controls.Add(this.ultraTabControl1);
            this.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PMHNB04151UB";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ユーザー設定";
            this.Shown += new System.EventHandler(this.PMHNB04151UB_Shown);
            this.Load += new System.EventHandler(this.PMHNB04151UB_Load);
            this.ultraTabPageControl1.ResumeLayout(false);
            this.ultraTabPageControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uComboEditor_StartupSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraTabControl1)).EndInit();
            this.ultraTabControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uComboEditor_AutoUpdate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uComboEditor_DefaultSecCode)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.UltraWinTabControl.UltraTabControl ultraTabControl1;
        private Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage ultraTabSharedControlsPage1;
        private Infragistics.Win.UltraWinTabControl.UltraTabPageControl ultraTabPageControl1;
        private Infragistics.Win.Misc.UltraLabel uLabel3;
        private Infragistics.Win.Misc.UltraLabel uLabel2;
        private Infragistics.Win.Misc.UltraLabel uLabel1;
        private Infragistics.Win.Misc.UltraButton uButton_OK;
        private Infragistics.Win.Misc.UltraButton uButton_Cancel;
        private Broadleaf.Library.Windows.Forms.TRetKeyControl tRetKeyControl;
        private Broadleaf.Library.Windows.Forms.TArrowKeyControl tArrowKeyControl;
        private Broadleaf.Library.Windows.Forms.TComboEditor uComboEditor_StartupSearch;
        private Broadleaf.Library.Windows.Forms.TComboEditor uComboEditor_AutoUpdate;
        private Broadleaf.Library.Windows.Forms.TComboEditor uComboEditor_DefaultSecCode;
    }
}
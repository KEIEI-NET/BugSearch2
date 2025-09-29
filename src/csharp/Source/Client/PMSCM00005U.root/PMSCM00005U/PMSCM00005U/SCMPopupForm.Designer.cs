//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11070148-00 作成担当 : 吉岡
// 作 成 日  2014/12/01  修正内容 : №10695 起動時、XML読込み処理完了前に、パトランプアイコンクリックイベント実行を抑制する
//----------------------------------------------------------------------------//
namespace Broadleaf.Windows.Forms
{
	partial class SCMPopupForm
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
            System.Windows.Forms.ToolStripMenuItem showToolStripMenuItem;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SCMPopupForm));
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.patoLampNotifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.setToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.close_Timer = new System.Windows.Forms.Timer(this.components);
            this.display_timer = new System.Windows.Forms.Timer(this.components);
            this.panel_Info = new System.Windows.Forms.Panel();
            this.patoLampImage = new System.Windows.Forms.PictureBox();
            this.lblInformation = new Infragistics.Win.Misc.UltraLabel();
            this.check_timer = new System.Windows.Forms.Timer(this.components);
            this.fill_Panel = new System.Windows.Forms.Panel();
            this.bottom_Panel = new System.Windows.Forms.Panel();
            this.autoAnswerLabel = new Infragistics.Win.Misc.UltraLabel();
            this.dataGridView_Data = new System.Windows.Forms.DataGridView();
            this.ScmCheck_timer = new System.Windows.Forms.Timer(this.components);
            this.SoundCheck_timer = new System.Windows.Forms.Timer(this.components);
            showToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip.SuspendLayout();
            this.panel_Info.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.patoLampImage)).BeginInit();
            this.fill_Panel.SuspendLayout();
            this.bottom_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Data)).BeginInit();
            this.SuspendLayout();
            // 
            // showToolStripMenuItem
            // 
            showToolStripMenuItem.Name = "showToolStripMenuItem";
            showToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            showToolStripMenuItem.Text = "表示(&V)";
            showToolStripMenuItem.Click += new System.EventHandler(this.showToolStripMenuItem_Click);
            // 
            // patoLampNotifyIcon
            // 
            this.patoLampNotifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.patoLampNotifyIcon.ContextMenuStrip = this.contextMenuStrip;
            this.patoLampNotifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("patoLampNotifyIcon.Icon")));
            this.patoLampNotifyIcon.Text = "新着情報はありません";
            this.patoLampNotifyIcon.Visible = true;
            this.patoLampNotifyIcon.MouseMove += new System.Windows.Forms.MouseEventHandler(this.patoLampNotifyIcon_MouseMove);
            // DEL 2014/12/01 吉岡 №10695 ---------------->>>>>>>>>>>>>>>>>>
            // this.patoLampNotifyIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.patoLampNotifyIcon_MouseClick);
            // DEL 2014/12/01 吉岡 №10695 ----------------<<<<<<<<<<<<<<<<<<

            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            showToolStripMenuItem,
            this.setToolStripMenuItem,
            this.updateToolStripMenuItem,
            this.changeToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip1";
            this.contextMenuStrip.Size = new System.Drawing.Size(120, 92);
            // 
            // setToolStripMenuItem
            // 
            this.setToolStripMenuItem.Name = "setToolStripMenuItem";
            this.setToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.setToolStripMenuItem.Text = "設定(&S)";
            this.setToolStripMenuItem.Click += new System.EventHandler(this.setToolStripMenuItem_Click);
            // 
            // updateToolStripMenuItem
            // 
            this.updateToolStripMenuItem.Name = "updateToolStripMenuItem";
            this.updateToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.updateToolStripMenuItem.Text = "更新(&U)";
            this.updateToolStripMenuItem.Click += new System.EventHandler(this.updateToolStripMenuItem_Click);
            // 
            // changeToolStripMenuItem
            // 
            this.changeToolStripMenuItem.Name = "changeToolStripMenuItem";
            this.changeToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.changeToolStripMenuItem.Text = "切替(&C)";
            this.changeToolStripMenuItem.Click += new System.EventHandler(this.changeToolStripMenuItem_Click);
            // 
            // close_Timer
            // 
            this.close_Timer.Interval = 30;
            this.close_Timer.Tick += new System.EventHandler(this.close_Timer_Tick);
            // 
            // display_timer
            // 
            this.display_timer.Interval = 1000;
            this.display_timer.Tick += new System.EventHandler(this.display_timer_Tick);
            // 
            // panel_Info
            // 
            this.panel_Info.BackColor = System.Drawing.Color.Transparent;
            this.panel_Info.Controls.Add(this.patoLampImage);
            this.panel_Info.Controls.Add(this.lblInformation);
            this.panel_Info.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_Info.Location = new System.Drawing.Point(0, 0);
            this.panel_Info.Name = "panel_Info";
            this.panel_Info.Size = new System.Drawing.Size(414, 71);
            this.panel_Info.TabIndex = 15;
            // 
            // patoLampImage
            // 
            this.patoLampImage.Image = ((System.Drawing.Image)(resources.GetObject("patoLampImage.Image")));
            this.patoLampImage.InitialImage = null;
            this.patoLampImage.Location = new System.Drawing.Point(12, 16);
            this.patoLampImage.Name = "patoLampImage";
            this.patoLampImage.Size = new System.Drawing.Size(40, 40);
            this.patoLampImage.TabIndex = 15;
            this.patoLampImage.TabStop = false;
            // 
            // lblInformation
            // 
            appearance1.FontData.BoldAsString = "True";
            appearance1.FontData.Name = "ＭＳ ゴシック";
            appearance1.FontData.SizeInPoints = 14F;
            appearance1.FontData.UnderlineAsString = "False";
            appearance1.ForeColor = System.Drawing.Color.White;
            appearance1.ForegroundAlpha = Infragistics.Win.Alpha.Opaque;
            this.lblInformation.Appearance = appearance1;
            this.lblInformation.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblInformation.Font = new System.Drawing.Font("ＭＳ ゴシック", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblInformation.Location = new System.Drawing.Point(71, 27);
            this.lblInformation.Name = "lblInformation";
            this.lblInformation.Size = new System.Drawing.Size(262, 20);
            this.lblInformation.TabIndex = 12;
            // 
            // check_timer
            // 
            this.check_timer.Interval = 60000;
            this.check_timer.Tick += new System.EventHandler(this.check_timer_Tick);
            // 
            // fill_Panel
            // 
            this.fill_Panel.Controls.Add(this.bottom_Panel);
            this.fill_Panel.Controls.Add(this.dataGridView_Data);
            this.fill_Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fill_Panel.Location = new System.Drawing.Point(0, 71);
            this.fill_Panel.Name = "fill_Panel";
            this.fill_Panel.Size = new System.Drawing.Size(414, 190);
            this.fill_Panel.TabIndex = 16;
            // 
            // bottom_Panel
            // 
            this.bottom_Panel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.bottom_Panel.Controls.Add(this.autoAnswerLabel);
            this.bottom_Panel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bottom_Panel.Location = new System.Drawing.Point(0, 135);
            this.bottom_Panel.Name = "bottom_Panel";
            this.bottom_Panel.Size = new System.Drawing.Size(414, 55);
            this.bottom_Panel.TabIndex = 18;
            this.bottom_Panel.VisibleChanged += new System.EventHandler(this.SCMPopupForm_VisibleChanged);
            // 
            // autoAnswerLabel
            // 
            appearance14.FontData.BoldAsString = "True";
            appearance14.FontData.Name = "ＭＳ ゴシック";
            appearance14.FontData.SizeInPoints = 14F;
            appearance14.FontData.UnderlineAsString = "True";
            appearance14.ForeColor = System.Drawing.Color.Black;
            appearance14.ForegroundAlpha = Infragistics.Win.Alpha.Opaque;
            appearance14.TextVAlignAsString = "Middle";
            this.autoAnswerLabel.Appearance = appearance14;
            this.autoAnswerLabel.Cursor = System.Windows.Forms.Cursors.Default;
            this.autoAnswerLabel.Font = new System.Drawing.Font("ＭＳ ゴシック", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.autoAnswerLabel.Location = new System.Drawing.Point(23, 14);
            this.autoAnswerLabel.Name = "autoAnswerLabel";
            this.autoAnswerLabel.Size = new System.Drawing.Size(262, 23);
            this.autoAnswerLabel.TabIndex = 13;
            this.autoAnswerLabel.Text = "自動回答があります";
            this.autoAnswerLabel.Click += new System.EventHandler(this.autoAnswerLabel_Click);
            // 
            // dataGridView_Data
            // 
            this.dataGridView_Data.AllowUserToAddRows = false;
            this.dataGridView_Data.AllowUserToDeleteRows = false;
            this.dataGridView_Data.AllowUserToResizeColumns = false;
            this.dataGridView_Data.AllowUserToResizeRows = false;
            this.dataGridView_Data.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_Data.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dataGridView_Data.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView_Data.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridView_Data.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Data.ColumnHeadersVisible = false;
            this.dataGridView_Data.Cursor = System.Windows.Forms.Cursors.Default;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView_Data.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView_Data.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataGridView_Data.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView_Data.GridColor = System.Drawing.Color.WhiteSmoke;
            this.dataGridView_Data.Location = new System.Drawing.Point(0, 0);
            this.dataGridView_Data.MultiSelect = false;
            this.dataGridView_Data.Name = "dataGridView_Data";
            this.dataGridView_Data.ReadOnly = true;
            this.dataGridView_Data.RowHeadersVisible = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("ＭＳ ゴシック", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView_Data.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView_Data.RowTemplate.Height = 30;
            this.dataGridView_Data.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView_Data.Size = new System.Drawing.Size(414, 135);
            this.dataGridView_Data.TabIndex = 17;
            this.dataGridView_Data.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dataGridView_Data_MouseMove);
            this.dataGridView_Data.MouseLeave += new System.EventHandler(this.dataGridView_Data_MouseLeave);
            this.dataGridView_Data.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_Data_CellClick);
            // 
            // ScmCheck_timer
            // 
            this.ScmCheck_timer.Interval = 1000;
            this.ScmCheck_timer.Tick += new System.EventHandler(this.ScmCheck_timer_Tick);
            // 
            // SoundCheck_timer
            // 
            this.SoundCheck_timer.Interval = 1000;
            this.SoundCheck_timer.Tick += new System.EventHandler(this.SoundCheck_timer_Tick);
            // 
            // SCMPopupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(414, 261);
            this.Controls.Add(this.fill_Panel);
            this.Controls.Add(this.panel_Info);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SCMPopupForm";
            this.Opacity = 0.92;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Tag = "";
            this.Text = "PM 見積問合せ／発注";
            this.Load += new System.EventHandler(this.SCMPopupForm_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.SCMPopupForm_Paint);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.SCMPopupForm_MouseClick);
            this.VisibleChanged += new System.EventHandler(this.SCMPopupForm_VisibleChanged);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SCMPopupForm_FormClosed);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SCMPopupForm_FormClosing);
            this.contextMenuStrip.ResumeLayout(false);
            this.panel_Info.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.patoLampImage)).EndInit();
            this.fill_Panel.ResumeLayout(false);
            this.bottom_Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Data)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

        private System.Windows.Forms.NotifyIcon patoLampNotifyIcon;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.Timer close_Timer;
        private System.Windows.Forms.Timer display_timer;
        private System.Windows.Forms.Panel panel_Info;
        private Infragistics.Win.Misc.UltraLabel lblInformation;
        private System.Windows.Forms.PictureBox patoLampImage;
        private System.Windows.Forms.Timer check_timer;
        private System.Windows.Forms.Timer ScmCheck_timer;
	    private System.Windows.Forms.Panel fill_Panel;
        private System.Windows.Forms.DataGridView dataGridView_Data;
        private System.Windows.Forms.Panel bottom_Panel;
        private Infragistics.Win.Misc.UltraLabel autoAnswerLabel;
        private System.Windows.Forms.ToolStripMenuItem setToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changeToolStripMenuItem;
        private System.Windows.Forms.Timer SoundCheck_timer;
	}
}


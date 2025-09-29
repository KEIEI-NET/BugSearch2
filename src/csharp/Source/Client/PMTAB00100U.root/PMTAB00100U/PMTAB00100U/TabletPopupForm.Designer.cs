namespace Broadleaf.Windows.Forms
{
	partial class TabletPopupForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TabletPopupForm));
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.patoLampNotifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.setToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel_Info = new System.Windows.Forms.Panel();
            this.patoLampImage = new System.Windows.Forms.PictureBox();
            this.lblInformation = new Infragistics.Win.Misc.UltraLabel();
            this.fill_Panel = new System.Windows.Forms.Panel();
            this.dataGridView_Data = new System.Windows.Forms.DataGridView();
            this.waitTimeReset = new System.Windows.Forms.Timer(this.components);
            this.contextMenuStrip.SuspendLayout();
            this.panel_Info.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.patoLampImage)).BeginInit();
            this.fill_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Data)).BeginInit();
            this.SuspendLayout();
            // 
            // patoLampNotifyIcon
            // 
            this.patoLampNotifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.patoLampNotifyIcon.ContextMenuStrip = this.contextMenuStrip;
            this.patoLampNotifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("patoLampNotifyIcon.Icon")));
            this.patoLampNotifyIcon.Text = "タブレット自動回答";
            this.patoLampNotifyIcon.Visible = true;
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setToolStripMenuItem,
            this.updateToolStripMenuItem,
            this.closeToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip1";
            this.contextMenuStrip.Size = new System.Drawing.Size(131, 70);
            // 
            // setToolStripMenuItem
            // 
            this.setToolStripMenuItem.Name = "setToolStripMenuItem";
            this.setToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.setToolStripMenuItem.Text = "設定(&S)";
            this.setToolStripMenuItem.Click += new System.EventHandler(this.setToolStripMenuItem_Click);
            // 
            // updateToolStripMenuItem
            // 
            this.updateToolStripMenuItem.Name = "updateToolStripMenuItem";
            this.updateToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.updateToolStripMenuItem.Text = "更新(&U)";
            this.updateToolStripMenuItem.Click += new System.EventHandler(this.updateToolStripMenuItem_Click);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.closeToolStripMenuItem.Text = "閉じる(&C)";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
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
            this.lblInformation.Text = "売上情報が登録されました";
            // 
            // fill_Panel
            // 
            this.fill_Panel.Controls.Add(this.dataGridView_Data);
            this.fill_Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fill_Panel.Location = new System.Drawing.Point(0, 71);
            this.fill_Panel.Name = "fill_Panel";
            this.fill_Panel.Size = new System.Drawing.Size(414, 135);
            this.fill_Panel.TabIndex = 16;
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
            // 
            // waitTimeReset
            // 
            this.waitTimeReset.Interval = 30000;
            this.waitTimeReset.Tick += new System.EventHandler(this.waitTimeReset_Tick);
            // 
            // TabletPopupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(414, 206);
            this.Controls.Add(this.fill_Panel);
            this.Controls.Add(this.panel_Info);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TabletPopupForm";
            this.Opacity = 0.92;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Tag = "";
            this.Text = "タブレット自動回答";
            this.Load += new System.EventHandler(this.TabletPopupForm_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.TabletPopupForm_Paint);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TabletPopupForm_FormClosing);
            this.contextMenuStrip.ResumeLayout(false);
            this.panel_Info.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.patoLampImage)).EndInit();
            this.fill_Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Data)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

        private System.Windows.Forms.NotifyIcon patoLampNotifyIcon;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.Panel panel_Info;
        private Infragistics.Win.Misc.UltraLabel lblInformation;
        private System.Windows.Forms.PictureBox patoLampImage;
	    private System.Windows.Forms.Panel fill_Panel;
        private System.Windows.Forms.DataGridView dataGridView_Data;
        private System.Windows.Forms.ToolStripMenuItem setToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateToolStripMenuItem;
        private System.Windows.Forms.Timer waitTimeReset;
	}
}


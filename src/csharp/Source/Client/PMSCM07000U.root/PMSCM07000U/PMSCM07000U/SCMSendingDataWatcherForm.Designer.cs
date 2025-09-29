namespace Broadleaf.Windows.Forms
{
    partial class SCMSendingDataWatcherForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SCMSendingDataWatcherForm));
            this.sendingDirector = new System.ComponentModel.BackgroundWorker();
            this.sendingFileWatcher = new System.IO.FileSystemWatcher();
            this.lblState = new System.Windows.Forms.Label();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.leftMarginStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.dateStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.timeStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.timerNow = new System.Windows.Forms.Timer(this.components);
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.sendingFileWatcher)).BeginInit();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // sendingDirector
            // 
            this.sendingDirector.DoWork += new System.ComponentModel.DoWorkEventHandler(this.sendingDirector_DoWork);
            this.sendingDirector.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.sendingDirector_RunWorkerCompleted);
            this.sendingDirector.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.sendingDirector_ProgressChanged);
            // 
            // sendingFileWatcher
            // 
            this.sendingFileWatcher.EnableRaisingEvents = true;
            this.sendingFileWatcher.IncludeSubdirectories = true;
            this.sendingFileWatcher.Path = ".\\";
            this.sendingFileWatcher.SynchronizingObject = this;
            this.sendingFileWatcher.Renamed += new System.IO.RenamedEventHandler(this.sendingFileWatcher_Renamed);
            this.sendingFileWatcher.Deleted += new System.IO.FileSystemEventHandler(this.sendingFileWatcher_Deleted);
            this.sendingFileWatcher.Created += new System.IO.FileSystemEventHandler(this.sendingFileWatcher_Created);
            this.sendingFileWatcher.Changed += new System.IO.FileSystemEventHandler(this.sendingFileWatcher_Changed);
            // 
            // lblState
            // 
            this.lblState.BackColor = System.Drawing.Color.Navy;
            this.lblState.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblState.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblState.ForeColor = System.Drawing.SystemColors.Window;
            this.lblState.Location = new System.Drawing.Point(0, 0);
            this.lblState.Name = "lblState";
            this.lblState.Size = new System.Drawing.Size(292, 32);
            this.lblState.TabIndex = 0;
            this.lblState.Text = "送信待機中...";
            this.lblState.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(205, 218);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 1;
            this.btnStop.Text = "停止";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnStart
            // 
            this.btnStart.Enabled = false;
            this.btnStart.Location = new System.Drawing.Point(124, 218);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 2;
            this.btnStart.Text = "開始";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // txtLog
            // 
            this.txtLog.BackColor = System.Drawing.SystemColors.Window;
            this.txtLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLog.Location = new System.Drawing.Point(0, 32);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtLog.Size = new System.Drawing.Size(292, 212);
            this.txtLog.TabIndex = 3;
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.leftMarginStatusLabel,
            this.dateStatusLabel,
            this.timeStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 244);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.statusStrip.Size = new System.Drawing.Size(292, 22);
            this.statusStrip.TabIndex = 4;
            this.statusStrip.Text = "statusStrip1";
            // 
            // leftMarginStatusLabel
            // 
            this.leftMarginStatusLabel.Name = "leftMarginStatusLabel";
            this.leftMarginStatusLabel.Size = new System.Drawing.Size(162, 17);
            this.leftMarginStatusLabel.Text = "ESCで処理を終了します          ";
            // 
            // dateStatusLabel
            // 
            this.dateStatusLabel.Name = "dateStatusLabel";
            this.dateStatusLabel.Size = new System.Drawing.Size(65, 17);
            this.dateStatusLabel.Text = "2010/06/22";
            // 
            // timeStatusLabel
            // 
            this.timeStatusLabel.Name = "timeStatusLabel";
            this.timeStatusLabel.Size = new System.Drawing.Size(45, 17);
            this.timeStatusLabel.Text = "23:59:59";
            // 
            // timerNow
            // 
            this.timerNow.Enabled = true;
            this.timerNow.Tick += new System.EventHandler(this.timerNow_Tick);
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(12, 189);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "閉じる";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // SCMSendingDataWatcherForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(254)))));
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(292, 266);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.lblState);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SCMSendingDataWatcherForm";
            this.Text = "NS待機処理";
            this.Load += new System.EventHandler(this.SCMSendingDataWatcherForm_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.SCMSendingDataWatcherForm_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.SCMSendingDataWatcherForm_DragEnter);
            ((System.ComponentModel.ISupportInitialize)(this.sendingFileWatcher)).EndInit();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.ComponentModel.BackgroundWorker sendingDirector;
        private System.IO.FileSystemWatcher sendingFileWatcher;
        private System.Windows.Forms.Label lblState;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.Timer timerNow;
        private System.Windows.Forms.ToolStripStatusLabel leftMarginStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel dateStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel timeStatusLabel;
        private System.Windows.Forms.Button btnClose;
    }
}
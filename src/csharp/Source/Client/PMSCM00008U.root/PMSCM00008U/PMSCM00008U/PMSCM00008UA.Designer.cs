namespace Broadleaf.Windows.Forms
{
    partial class PMSCM00008UA
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
            if (disposing && ( components != null ))
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PMSCM00008UA));
            this.compMsg_timer = new System.Windows.Forms.Timer(this.components);
            this.ScmLoadingDlg_Timer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // compMsg_timer
            // 
            this.compMsg_timer.Interval = 2200;
            this.compMsg_timer.Tick += new System.EventHandler(this.compMsg_timer_Tick);
            // 
            // ScmLoadingDlg_Timer
            // 
            this.ScmLoadingDlg_Timer.Interval = 30000;
            this.ScmLoadingDlg_Timer.Tick += new System.EventHandler(this.ScmLoadingDlg_Timer_Tick);
            // 
            // PMSCM00008UA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 22);
            this.ControlBox = false;
            this.Icon = ( (System.Drawing.Icon)( resources.GetObject("$this.Icon") ) );
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PMSCM00008UA";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "受信処理";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer compMsg_timer;
        private System.Windows.Forms.Timer ScmLoadingDlg_Timer;
    }
}
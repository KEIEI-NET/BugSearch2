namespace Broadleaf.Windows.Forms
{
	partial class AnalysisChartViewForm
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
            this.AnalysisChartView_panel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // AnalysisChartView_panel
            // 
            this.AnalysisChartView_panel.BackColor = System.Drawing.Color.Transparent;
            this.AnalysisChartView_panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AnalysisChartView_panel.Location = new System.Drawing.Point(0, 0);
            this.AnalysisChartView_panel.Name = "AnalysisChartView_panel";
            this.AnalysisChartView_panel.Size = new System.Drawing.Size(1024, 768);
            this.AnalysisChartView_panel.TabIndex = 0;
            // 
            // AnalysisChartViewForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1024, 768);
            this.Controls.Add(this.AnalysisChartView_panel);
            this.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "AnalysisChartViewForm";
            this.ResumeLayout(false);

		}

		#endregion

        private System.Windows.Forms.Panel AnalysisChartView_panel;
	}
}
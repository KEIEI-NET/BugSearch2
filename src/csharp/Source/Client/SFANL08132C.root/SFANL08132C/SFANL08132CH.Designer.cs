namespace Broadleaf.Application.Common
{
	partial class SFANL08132CH
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

		#region コンポーネント デザイナで生成されたコード

		/// <summary> 
		/// デザイナ サポートに必要なメソッドです。このメソッドの内容を 
		/// コード エディタで変更しないでください。
		/// </summary>
		private void InitializeComponent()
		{
			Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
			this.ulExtraConditionTitle = new Infragistics.Win.Misc.UltraLabel();
			this.ugbCheckBoxArea = new Infragistics.Win.Misc.UltraGroupBox();
			((System.ComponentModel.ISupportInitialize)(this.ugbCheckBoxArea)).BeginInit();
			this.SuspendLayout();
			// 
			// ulExtraConditionTitle
			// 
			this.ulExtraConditionTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			appearance1.TextVAlign = Infragistics.Win.VAlign.Middle;
			this.ulExtraConditionTitle.Appearance = appearance1;
			this.ulExtraConditionTitle.Location = new System.Drawing.Point(6, 6);
			this.ulExtraConditionTitle.Name = "ulExtraConditionTitle";
			this.ulExtraConditionTitle.Size = new System.Drawing.Size(291, 23);
			this.ulExtraConditionTitle.TabIndex = 1;
			this.ulExtraConditionTitle.Text = "抽出条件タイトル";
			this.ulExtraConditionTitle.WrapText = false;
			this.ulExtraConditionTitle.SizeChanged += new System.EventHandler(this.ulExtraConditionTitle_SizeChanged);
			this.ulExtraConditionTitle.TextChanged += new System.EventHandler(this.ulExtraConditionTitle_TextChanged);
			// 
			// ugbCheckBoxArea
			// 
			this.ugbCheckBoxArea.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.ugbCheckBoxArea.ImeMode = System.Windows.Forms.ImeMode.Disable;
			this.ugbCheckBoxArea.Location = new System.Drawing.Point(6, 26);
			this.ugbCheckBoxArea.Name = "ugbCheckBoxArea";
			this.ugbCheckBoxArea.Size = new System.Drawing.Size(291, 71);
			this.ugbCheckBoxArea.SupportThemes = false;
			this.ugbCheckBoxArea.TabIndex = 2;
			this.ugbCheckBoxArea.SizeChanged += new System.EventHandler(this.ugbCheckBoxArea_SizeChanged);
			// 
			// SFANL08132CH
			// 
			this.BackColor = System.Drawing.Color.Transparent;
			this.Controls.Add(this.ugbCheckBoxArea);
			this.Controls.Add(this.ulExtraConditionTitle);
			this.Font = new System.Drawing.Font("ＭＳ ゴシック", 11F);
			this.Size = new System.Drawing.Size(300, 100);
			((System.ComponentModel.ISupportInitialize)(this.ugbCheckBoxArea)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private Infragistics.Win.Misc.UltraLabel ulExtraConditionTitle;
		private Infragistics.Win.Misc.UltraGroupBox ugbCheckBoxArea;
	}
}

namespace Broadleaf.Application.Common
{
	partial class SFANL08132CC
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
			Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
			this.ulExtraConditionTitle = new Infragistics.Win.Misc.UltraLabel();
			this.tedStExtraCharCode = new Broadleaf.Library.Windows.Forms.TEdit();
			this.tedEdExtraCharCode = new Broadleaf.Library.Windows.Forms.TEdit();
			this.ulRange = new Infragistics.Win.Misc.UltraLabel();
			((System.ComponentModel.ISupportInitialize)(this.tedStExtraCharCode)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tedEdExtraCharCode)).BeginInit();
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
			// tedStExtraCharCode
			// 
			appearance2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
			this.tedStExtraCharCode.ActiveAppearance = appearance2;
			this.tedStExtraCharCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.tedStExtraCharCode.AutoSelect = true;
			this.tedStExtraCharCode.DataText = "";
			this.tedStExtraCharCode.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
			this.tedStExtraCharCode.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 12, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, true, true, true, true));
			this.tedStExtraCharCode.Location = new System.Drawing.Point(20, 35);
			this.tedStExtraCharCode.MaxLength = 12;
			this.tedStExtraCharCode.Name = "tedStExtraCharCode";
			this.tedStExtraCharCode.Size = new System.Drawing.Size(206, 24);
			this.tedStExtraCharCode.TabIndex = 1;
			// 
			// tedEdExtraCharCode
			// 
			appearance3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
			this.tedEdExtraCharCode.ActiveAppearance = appearance3;
			this.tedEdExtraCharCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.tedEdExtraCharCode.AutoSelect = true;
			this.tedEdExtraCharCode.DataText = "";
			this.tedEdExtraCharCode.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
			this.tedEdExtraCharCode.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 12, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, true, true, true, true));
			this.tedEdExtraCharCode.Location = new System.Drawing.Point(48, 65);
			this.tedEdExtraCharCode.MaxLength = 12;
			this.tedEdExtraCharCode.Name = "tedEdExtraCharCode";
			this.tedEdExtraCharCode.Size = new System.Drawing.Size(206, 24);
			this.tedEdExtraCharCode.TabIndex = 2;
			// 
			// ulRange
			// 
			appearance4.TextHAlign = Infragistics.Win.HAlign.Center;
			appearance4.TextVAlign = Infragistics.Win.VAlign.Middle;
			this.ulRange.Appearance = appearance4;
			this.ulRange.Location = new System.Drawing.Point(20, 65);
			this.ulRange.Name = "ulRange";
			this.ulRange.Size = new System.Drawing.Size(22, 23);
			this.ulRange.TabIndex = 4;
			this.ulRange.Text = "～";
			// 
			// SFANL08132CC
			// 
			this.BackColor = System.Drawing.Color.Transparent;
			this.Controls.Add(this.ulRange);
			this.Controls.Add(this.tedEdExtraCharCode);
			this.Controls.Add(this.tedStExtraCharCode);
			this.Controls.Add(this.ulExtraConditionTitle);
			this.Font = new System.Drawing.Font("ＭＳ ゴシック", 11F);
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Size = new System.Drawing.Size(300, 100);
			((System.ComponentModel.ISupportInitialize)(this.tedStExtraCharCode)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tedEdExtraCharCode)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private Infragistics.Win.Misc.UltraLabel ulExtraConditionTitle;
		private Broadleaf.Library.Windows.Forms.TEdit tedStExtraCharCode;
		private Broadleaf.Library.Windows.Forms.TEdit tedEdExtraCharCode;
		private Infragistics.Win.Misc.UltraLabel ulRange;
	}
}

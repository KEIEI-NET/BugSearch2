namespace Broadleaf.Application.Common
{
	partial class SFANL08132CB
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
			Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
			this.ulExtraConditionTitle = new Infragistics.Win.Misc.UltraLabel();
			this.nedStExtraNumCode = new Broadleaf.Library.Windows.Forms.TNedit();
			this.nedEdExtraNumCode = new Broadleaf.Library.Windows.Forms.TNedit();
			this.ulRange = new Infragistics.Win.Misc.UltraLabel();
			((System.ComponentModel.ISupportInitialize)(this.nedStExtraNumCode)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nedEdExtraNumCode)).BeginInit();
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
			this.ulExtraConditionTitle.TabIndex = 0;
			this.ulExtraConditionTitle.Text = "抽出条件タイトル";
			this.ulExtraConditionTitle.WrapText = false;
			this.ulExtraConditionTitle.SizeChanged += new System.EventHandler(this.ulExtraConditionTitle_SizeChanged);
			this.ulExtraConditionTitle.TextChanged += new System.EventHandler(this.ulExtraConditionTitle_TextChanged);
			// 
			// nedStExtraNumCode
			// 
			appearance2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
			this.nedStExtraNumCode.ActiveAppearance = appearance2;
			this.nedStExtraNumCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			appearance3.TextHAlign = Infragistics.Win.HAlign.Right;
			this.nedStExtraNumCode.Appearance = appearance3;
			this.nedStExtraNumCode.AutoSelect = true;
			this.nedStExtraNumCode.CalcDisp = Broadleaf.Library.Windows.Forms.emCalcDisp.nclcNone;
			this.nedStExtraNumCode.CalcSize = new System.Drawing.Size(172, 200);
			this.nedStExtraNumCode.DataText = "";
			this.nedStExtraNumCode.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
			this.nedStExtraNumCode.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 19, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
			this.nedStExtraNumCode.ImeMode = System.Windows.Forms.ImeMode.Off;
			this.nedStExtraNumCode.Location = new System.Drawing.Point(20, 35);
			this.nedStExtraNumCode.MaxLength = 19;
			this.nedStExtraNumCode.Name = "nedStExtraNumCode";
			this.nedStExtraNumCode.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
			this.nedStExtraNumCode.Size = new System.Drawing.Size(159, 24);
			this.nedStExtraNumCode.TabIndex = 1;
			// 
			// nedEdExtraNumCode
			// 
			appearance4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
			this.nedEdExtraNumCode.ActiveAppearance = appearance4;
			this.nedEdExtraNumCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			appearance5.TextHAlign = Infragistics.Win.HAlign.Right;
			this.nedEdExtraNumCode.Appearance = appearance5;
			this.nedEdExtraNumCode.AutoSelect = true;
			this.nedEdExtraNumCode.CalcDisp = Broadleaf.Library.Windows.Forms.emCalcDisp.nclcNone;
			this.nedEdExtraNumCode.CalcSize = new System.Drawing.Size(172, 200);
			this.nedEdExtraNumCode.DataText = "";
			this.nedEdExtraNumCode.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
			this.nedEdExtraNumCode.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 19, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
			this.nedEdExtraNumCode.ImeMode = System.Windows.Forms.ImeMode.Off;
			this.nedEdExtraNumCode.Location = new System.Drawing.Point(48, 65);
			this.nedEdExtraNumCode.MaxLength = 19;
			this.nedEdExtraNumCode.Name = "nedEdExtraNumCode";
			this.nedEdExtraNumCode.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
			this.nedEdExtraNumCode.Size = new System.Drawing.Size(159, 24);
			this.nedEdExtraNumCode.TabIndex = 2;
			// 
			// ulRange
			// 
			appearance6.TextHAlign = Infragistics.Win.HAlign.Center;
			appearance6.TextVAlign = Infragistics.Win.VAlign.Middle;
			this.ulRange.Appearance = appearance6;
			this.ulRange.Location = new System.Drawing.Point(20, 65);
			this.ulRange.Name = "ulRange";
			this.ulRange.Size = new System.Drawing.Size(22, 23);
			this.ulRange.TabIndex = 3;
			this.ulRange.Text = "～";
			// 
			// SFANL08132CB
			// 
			this.BackColor = System.Drawing.Color.Transparent;
			this.Controls.Add(this.ulRange);
			this.Controls.Add(this.nedEdExtraNumCode);
			this.Controls.Add(this.nedStExtraNumCode);
			this.Controls.Add(this.ulExtraConditionTitle);
			this.Font = new System.Drawing.Font("ＭＳ ゴシック", 11F);
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Size = new System.Drawing.Size(300, 100);
			((System.ComponentModel.ISupportInitialize)(this.nedStExtraNumCode)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nedEdExtraNumCode)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private Infragistics.Win.Misc.UltraLabel ulExtraConditionTitle;
		private Broadleaf.Library.Windows.Forms.TNedit nedStExtraNumCode;
		private Broadleaf.Library.Windows.Forms.TNedit nedEdExtraNumCode;
		private Infragistics.Win.Misc.UltraLabel ulRange;

	}
}

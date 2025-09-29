namespace Broadleaf.Application.Common
{
	partial class SFANL08132CF
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
			this.ulExtraConditionTitle = new Infragistics.Win.Misc.UltraLabel();
			this.cmbExtraCondDtlGrpCd = new Broadleaf.Library.Windows.Forms.TComboEditor();
			((System.ComponentModel.ISupportInitialize)(this.cmbExtraCondDtlGrpCd)).BeginInit();
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
			// cmbExtraCondDtlGrpCd
			// 
			appearance2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
			this.cmbExtraCondDtlGrpCd.ActiveAppearance = appearance2;
			this.cmbExtraCondDtlGrpCd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.cmbExtraCondDtlGrpCd.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
			appearance3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
			this.cmbExtraCondDtlGrpCd.ItemAppearance = appearance3;
			this.cmbExtraCondDtlGrpCd.Location = new System.Drawing.Point(20, 35);
			this.cmbExtraCondDtlGrpCd.Name = "cmbExtraCondDtlGrpCd";
			this.cmbExtraCondDtlGrpCd.Size = new System.Drawing.Size(255, 24);
			this.cmbExtraCondDtlGrpCd.TabIndex = 14;
			// 
			// SFANL08132CF
			// 
			this.Controls.Add(this.cmbExtraCondDtlGrpCd);
			this.Controls.Add(this.ulExtraConditionTitle);
			this.Font = new System.Drawing.Font("ＭＳ ゴシック", 11F);
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "SFANL00007CF";
			this.Size = new System.Drawing.Size(300, 70);
			((System.ComponentModel.ISupportInitialize)(this.cmbExtraCondDtlGrpCd)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private Infragistics.Win.Misc.UltraLabel ulExtraConditionTitle;
		private Broadleaf.Library.Windows.Forms.TComboEditor cmbExtraCondDtlGrpCd;
	}
}

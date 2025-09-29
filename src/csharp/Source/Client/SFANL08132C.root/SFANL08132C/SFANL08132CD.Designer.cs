namespace Broadleaf.Application.Common
{
	partial class SFANL08132CD
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
			Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
			this.ulExtraConditionTitle = new Infragistics.Win.Misc.UltraLabel();
			this.dateStartExtraDate = new Broadleaf.Library.Windows.Forms.TDateEdit();
			this.dateEndExtraDate = new Broadleaf.Library.Windows.Forms.TDateEdit();
			this.ulRange = new Infragistics.Win.Misc.UltraLabel();
			this.uceStaSystemDateDiv = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
			this.uceEndSystemDateDiv = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
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
			this.ulExtraConditionTitle.TabIndex = 2;
			this.ulExtraConditionTitle.Text = "抽出条件タイトル";
			this.ulExtraConditionTitle.WrapText = false;
			this.ulExtraConditionTitle.SizeChanged += new System.EventHandler(this.ulExtraConditionTitle_SizeChanged);
			this.ulExtraConditionTitle.TextChanged += new System.EventHandler(this.ulExtraConditionTitle_TextChanged);
			// 
			// dateStartExtraDate
			// 
			appearance2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
			this.dateStartExtraDate.ActiveEditAppearance = appearance2;
			this.dateStartExtraDate.BackColor = System.Drawing.Color.Transparent;
			this.dateStartExtraDate.CalendarDisp = true;
			this.dateStartExtraDate.DateFormat = Broadleaf.Library.Windows.Forms.emDateFormat.dfG2Y2M2D;
			appearance3.TextHAlign = Infragistics.Win.HAlign.Left;
			appearance3.TextVAlign = Infragistics.Win.VAlign.Middle;
			this.dateStartExtraDate.EditAppearance = appearance3;
			this.dateStartExtraDate.EnableEditors = new Broadleaf.Library.Windows.Forms.TEnableEditors(true, true, true, true);
			this.dateStartExtraDate.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
			appearance4.TextHAlign = Infragistics.Win.HAlign.Left;
			appearance4.TextVAlign = Infragistics.Win.VAlign.Middle;
			this.dateStartExtraDate.LabelAppearance = appearance4;
			this.dateStartExtraDate.Location = new System.Drawing.Point(20, 46);
			this.dateStartExtraDate.Name = "dateStartExtraDate";
			this.dateStartExtraDate.NecessaryEditors = new Broadleaf.Library.Windows.Forms.TNecessaryEditors(false, false, false, false);
			this.dateStartExtraDate.Options = new Broadleaf.Library.Windows.Forms.TDateEditOptions(false, false, false, true, false, true);
			this.dateStartExtraDate.Size = new System.Drawing.Size(199, 24);
			this.dateStartExtraDate.TabIndex = 3;
			this.dateStartExtraDate.TabStop = true;
			// 
			// dateEndExtraDate
			// 
			appearance5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
			this.dateEndExtraDate.ActiveEditAppearance = appearance5;
			this.dateEndExtraDate.BackColor = System.Drawing.Color.Transparent;
			this.dateEndExtraDate.CalendarDisp = true;
			this.dateEndExtraDate.DateFormat = Broadleaf.Library.Windows.Forms.emDateFormat.dfG2Y2M2D;
			appearance6.TextHAlign = Infragistics.Win.HAlign.Left;
			appearance6.TextVAlign = Infragistics.Win.VAlign.Middle;
			this.dateEndExtraDate.EditAppearance = appearance6;
			this.dateEndExtraDate.EnableEditors = new Broadleaf.Library.Windows.Forms.TEnableEditors(true, true, true, true);
			this.dateEndExtraDate.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
			appearance7.TextHAlign = Infragistics.Win.HAlign.Left;
			appearance7.TextVAlign = Infragistics.Win.VAlign.Middle;
			this.dateEndExtraDate.LabelAppearance = appearance7;
			this.dateEndExtraDate.Location = new System.Drawing.Point(48, 91);
			this.dateEndExtraDate.Name = "dateEndExtraDate";
			this.dateEndExtraDate.NecessaryEditors = new Broadleaf.Library.Windows.Forms.TNecessaryEditors(false, false, false, false);
			this.dateEndExtraDate.Options = new Broadleaf.Library.Windows.Forms.TDateEditOptions(false, false, false, true, false, true);
			this.dateEndExtraDate.Size = new System.Drawing.Size(199, 24);
			this.dateEndExtraDate.TabIndex = 5;
			this.dateEndExtraDate.TabStop = true;
			// 
			// ulRange
			// 
			appearance8.TextHAlign = Infragistics.Win.HAlign.Center;
			appearance8.TextVAlign = Infragistics.Win.VAlign.Middle;
			this.ulRange.Appearance = appearance8;
			this.ulRange.Location = new System.Drawing.Point(20, 92);
			this.ulRange.Name = "ulRange";
			this.ulRange.Size = new System.Drawing.Size(22, 23);
			this.ulRange.TabIndex = 5;
			this.ulRange.Text = "～";
			// 
			// uceStaSystemDateDiv
			// 
			appearance9.FontData.SizeInPoints = 9F;
			this.uceStaSystemDateDiv.Appearance = appearance9;
			this.uceStaSystemDateDiv.Location = new System.Drawing.Point(128, 29);
			this.uceStaSystemDateDiv.Name = "uceStaSystemDateDiv";
			this.uceStaSystemDateDiv.Size = new System.Drawing.Size(96, 20);
			this.uceStaSystemDateDiv.TabIndex = 4;
			this.uceStaSystemDateDiv.Text = "システム日付";
			this.uceStaSystemDateDiv.CheckedChanged += new System.EventHandler(this.uceStaSystemDateDiv_CheckedChanged);
			// 
			// uceEndSystemDateDiv
			// 
			appearance10.FontData.SizeInPoints = 9F;
			this.uceEndSystemDateDiv.Appearance = appearance10;
			this.uceEndSystemDateDiv.Location = new System.Drawing.Point(156, 74);
			this.uceEndSystemDateDiv.Name = "uceEndSystemDateDiv";
			this.uceEndSystemDateDiv.Size = new System.Drawing.Size(96, 20);
			this.uceEndSystemDateDiv.TabIndex = 6;
			this.uceEndSystemDateDiv.Text = "システム日付";
			this.uceEndSystemDateDiv.CheckedChanged += new System.EventHandler(this.uceEndSystemDateDiv_CheckedChanged);
			// 
			// SFANL08132CD
			// 
			this.Controls.Add(this.dateEndExtraDate);
			this.Controls.Add(this.dateStartExtraDate);
			this.Controls.Add(this.ulExtraConditionTitle);
			this.Controls.Add(this.uceEndSystemDateDiv);
			this.Controls.Add(this.uceStaSystemDateDiv);
			this.Controls.Add(this.ulRange);
			this.Font = new System.Drawing.Font("ＭＳ ゴシック", 11F);
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "SFANL08132CD";
			this.Size = new System.Drawing.Size(300, 126);
			this.ResumeLayout(false);

		}

		#endregion

		private Infragistics.Win.Misc.UltraLabel ulExtraConditionTitle;
		private Broadleaf.Library.Windows.Forms.TDateEdit dateStartExtraDate;
		private Broadleaf.Library.Windows.Forms.TDateEdit dateEndExtraDate;
		private Infragistics.Win.Misc.UltraLabel ulRange;
		private Infragistics.Win.UltraWinEditors.UltraCheckEditor uceStaSystemDateDiv;
		private Infragistics.Win.UltraWinEditors.UltraCheckEditor uceEndSystemDateDiv;
	}
}

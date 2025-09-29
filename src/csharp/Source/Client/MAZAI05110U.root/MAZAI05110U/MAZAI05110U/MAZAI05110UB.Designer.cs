namespace Broadleaf.Windows.Forms
{
	partial class BeforeSaveCheckDialog
	{
		/// <summary>
		/// 必要なデザイナ変数です。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 使用中のリソースをすべてクリーンアップします。
		/// </summary>
		/// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
		protected override void Dispose ( bool disposing )
		{
			if ( disposing && ( components != null ) )
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
		private void InitializeComponent ()
		{
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BeforeSaveCheckDialog));
            this.tceRepetitionData = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.tceAlreadyData = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.StockAnalysisDivCdTitle_Label = new Infragistics.Win.Misc.UltraLabel();
            this.PartsKindDivCdTitle_Label = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel2 = new Infragistics.Win.Misc.UltraLabel();
            this.ubReturn = new Infragistics.Win.Misc.UltraButton();
            this.ubSave = new Infragistics.Win.Misc.UltraButton();
            this.ultraLabel3 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel4 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel5 = new Infragistics.Win.Misc.UltraLabel();
            ((System.ComponentModel.ISupportInitialize)(this.tceRepetitionData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tceAlreadyData)).BeginInit();
            this.SuspendLayout();
            // 
            // tceRepetitionData
            // 
            appearance1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance1.ForeColor = System.Drawing.Color.Black;
            this.tceRepetitionData.ActiveAppearance = appearance1;
            appearance11.ForeColorDisabled = System.Drawing.Color.Black;
            this.tceRepetitionData.Appearance = appearance11;
            this.tceRepetitionData.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            appearance2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance2.ForeColor = System.Drawing.Color.Black;
            appearance2.ForeColorDisabled = System.Drawing.Color.Black;
            this.tceRepetitionData.ItemAppearance = appearance2;
            this.tceRepetitionData.Location = new System.Drawing.Point(144, 174);
            this.tceRepetitionData.Name = "tceRepetitionData";
            this.tceRepetitionData.Size = new System.Drawing.Size(232, 24);
            this.tceRepetitionData.TabIndex = 15;
            // 
            // tceAlreadyData
            // 
            appearance3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance3.ForeColor = System.Drawing.Color.Black;
            this.tceAlreadyData.ActiveAppearance = appearance3;
            appearance12.ForeColorDisabled = System.Drawing.Color.Black;
            this.tceAlreadyData.Appearance = appearance12;
            this.tceAlreadyData.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            appearance4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance4.ForeColor = System.Drawing.Color.Black;
            this.tceAlreadyData.ItemAppearance = appearance4;
            this.tceAlreadyData.Location = new System.Drawing.Point(144, 139);
            this.tceAlreadyData.Name = "tceAlreadyData";
            this.tceAlreadyData.Size = new System.Drawing.Size(232, 24);
            this.tceAlreadyData.TabIndex = 14;
            this.tceAlreadyData.ValueChanged += new System.EventHandler(this.tceAlreadyData_ValueChanged);
            // 
            // StockAnalysisDivCdTitle_Label
            // 
            appearance5.TextVAlignAsString = "Middle";
            this.StockAnalysisDivCdTitle_Label.Appearance = appearance5;
            this.StockAnalysisDivCdTitle_Label.Location = new System.Drawing.Point(16, 174);
            this.StockAnalysisDivCdTitle_Label.Name = "StockAnalysisDivCdTitle_Label";
            this.StockAnalysisDivCdTitle_Label.Size = new System.Drawing.Size(88, 23);
            this.StockAnalysisDivCdTitle_Label.TabIndex = 12;
            this.StockAnalysisDivCdTitle_Label.Text = "棚卸入力数";
            // 
            // PartsKindDivCdTitle_Label
            // 
            appearance6.TextVAlignAsString = "Middle";
            this.PartsKindDivCdTitle_Label.Appearance = appearance6;
            this.PartsKindDivCdTitle_Label.Location = new System.Drawing.Point(16, 139);
            this.PartsKindDivCdTitle_Label.Name = "PartsKindDivCdTitle_Label";
            this.PartsKindDivCdTitle_Label.Size = new System.Drawing.Size(111, 23);
            this.PartsKindDivCdTitle_Label.TabIndex = 13;
            this.PartsKindDivCdTitle_Label.Text = "同一商品の処理";
            // 
            // ultraLabel1
            // 
            appearance7.TextVAlignAsString = "Middle";
            this.ultraLabel1.Appearance = appearance7;
            this.ultraLabel1.Location = new System.Drawing.Point(14, 9);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(400, 23);
            this.ultraLabel1.TabIndex = 16;
            this.ultraLabel1.Text = "同一商品の棚卸データが既に存在します。";
            // 
            // ultraLabel2
            // 
            appearance8.TextVAlignAsString = "Middle";
            this.ultraLabel2.Appearance = appearance8;
            this.ultraLabel2.Location = new System.Drawing.Point(5, 30);
            this.ultraLabel2.Name = "ultraLabel2";
            this.ultraLabel2.Size = new System.Drawing.Size(400, 23);
            this.ultraLabel2.TabIndex = 17;
            this.ultraLabel2.Text = "「処理対象にする」を選択時は、倉庫単位でデータを一度";
            // 
            // ubReturn
            // 
            this.ubReturn.Location = new System.Drawing.Point(328, 210);
            this.ubReturn.Name = "ubReturn";
            this.ubReturn.Size = new System.Drawing.Size(92, 29);
            this.ubReturn.TabIndex = 18;
            this.ubReturn.Text = "戻る";
            this.ubReturn.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.ubReturn.Click += new System.EventHandler(this.ubReturn_Click);
            // 
            // ubSave
            // 
            this.ubSave.Location = new System.Drawing.Point(232, 210);
            this.ubSave.Name = "ubSave";
            this.ubSave.Size = new System.Drawing.Size(92, 29);
            this.ubSave.TabIndex = 19;
            this.ubSave.Text = "更新";
            this.ubSave.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.ubSave.Click += new System.EventHandler(this.ubSave_Click);
            // 
            // ultraLabel3
            // 
            appearance13.TextVAlignAsString = "Middle";
            this.ultraLabel3.Appearance = appearance13;
            this.ultraLabel3.Location = new System.Drawing.Point(14, 53);
            this.ultraLabel3.Name = "ultraLabel3";
            this.ultraLabel3.Size = new System.Drawing.Size(400, 23);
            this.ultraLabel3.TabIndex = 20;
            this.ultraLabel3.Text = "削除してから今回分を追加します。";
            // 
            // ultraLabel4
            // 
            appearance10.ForeColor = System.Drawing.Color.Blue;
            appearance10.TextVAlignAsString = "Middle";
            this.ultraLabel4.Appearance = appearance10;
            this.ultraLabel4.Location = new System.Drawing.Point(16, 100);
            this.ultraLabel4.Name = "ultraLabel4";
            this.ultraLabel4.Size = new System.Drawing.Size(400, 23);
            this.ultraLabel4.TabIndex = 21;
            this.ultraLabel4.Text = "※棚卸過不足更新済みデータは準備処理対象としません。";
            // 
            // ultraLabel5
            // 
            appearance9.TextVAlignAsString = "Middle";
            this.ultraLabel5.Appearance = appearance9;
            this.ultraLabel5.Location = new System.Drawing.Point(13, 74);
            this.ultraLabel5.Name = "ultraLabel5";
            this.ultraLabel5.Size = new System.Drawing.Size(400, 23);
            this.ultraLabel5.TabIndex = 22;
            this.ultraLabel5.Text = "以下の処理区分を選択して下さい。";
            // 
            // BeforeSaveCheckDialog
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(426, 271);
            this.Controls.Add(this.ultraLabel5);
            this.Controls.Add(this.ultraLabel4);
            this.Controls.Add(this.ultraLabel3);
            this.Controls.Add(this.ubSave);
            this.Controls.Add(this.ubReturn);
            this.Controls.Add(this.ultraLabel2);
            this.Controls.Add(this.ultraLabel1);
            this.Controls.Add(this.tceRepetitionData);
            this.Controls.Add(this.tceAlreadyData);
            this.Controls.Add(this.StockAnalysisDivCdTitle_Label);
            this.Controls.Add(this.PartsKindDivCdTitle_Label);
            this.Font = new System.Drawing.Font("ＭＳ ゴシック", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BeforeSaveCheckDialog";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "棚卸準備処理";
            ((System.ComponentModel.ISupportInitialize)(this.tceRepetitionData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tceAlreadyData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private Broadleaf.Library.Windows.Forms.TComboEditor tceRepetitionData;
		private Broadleaf.Library.Windows.Forms.TComboEditor tceAlreadyData;
		private Infragistics.Win.Misc.UltraLabel StockAnalysisDivCdTitle_Label;
		private Infragistics.Win.Misc.UltraLabel PartsKindDivCdTitle_Label;
		private Infragistics.Win.Misc.UltraLabel ultraLabel1;
		private Infragistics.Win.Misc.UltraLabel ultraLabel2;
		private Infragistics.Win.Misc.UltraButton ubReturn;
		private Infragistics.Win.Misc.UltraButton ubSave;
        private Infragistics.Win.Misc.UltraLabel ultraLabel3;
        private Infragistics.Win.Misc.UltraLabel ultraLabel4;
        private Infragistics.Win.Misc.UltraLabel ultraLabel5;
	}
}
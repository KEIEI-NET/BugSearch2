namespace Broadleaf.Windows.Forms
{
	partial class SFANL08105UF
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
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem1 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem2 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( SFANL08105UF ) );
            this.ubCancel = new Infragistics.Win.Misc.UltraButton();
            this.ubDecide = new Infragistics.Win.Misc.UltraButton();
            this.tedDisplayName = new Broadleaf.Library.Windows.Forms.TEdit();
            this.ulDisplayName = new Infragistics.Win.Misc.UltraLabel();
            this.ulPaperName = new Infragistics.Win.Misc.UltraLabel();
            this.ulFreePrtPprItemGrpNm = new Infragistics.Win.Misc.UltraLabel();
            this.cmbPaperName = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.cmbFreePrtPprItemGrpNm = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.tRetKeyControl1 = new Broadleaf.Library.Windows.Forms.TRetKeyControl( this.components );
            this.tArrowKeyControl1 = new Broadleaf.Library.Windows.Forms.TArrowKeyControl( this.components );
            this.uosOrientation = new Infragistics.Win.UltraWinEditors.UltraOptionSet();
            this.ultraLabel6 = new Infragistics.Win.Misc.UltraLabel();
            this.ulLandscape = new Infragistics.Win.Misc.UltraLabel();
            this.cmbPrintPaperUseDivcd = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.tedPrtFormId = new Broadleaf.Library.Windows.Forms.TEdit();
            this.ulPrtFormId = new Infragistics.Win.Misc.UltraLabel();
            ((System.ComponentModel.ISupportInitialize)(this.tedDisplayName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPaperName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbFreePrtPprItemGrpNm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uosOrientation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPrintPaperUseDivcd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tedPrtFormId)).BeginInit();
            this.SuspendLayout();
            // 
            // ubCancel
            // 
            this.ubCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ubCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ubCancel.Location = new System.Drawing.Point( 239, 177 );
            this.ubCancel.Name = "ubCancel";
            this.ubCancel.Size = new System.Drawing.Size( 136, 28 );
            this.ubCancel.TabIndex = 7;
            this.ubCancel.Text = "キャンセル(&C)";
            this.ubCancel.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.ubCancel.Click += new System.EventHandler( this.ubCancel_Click );
            // 
            // ubDecide
            // 
            this.ubDecide.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ubDecide.Location = new System.Drawing.Point( 97, 177 );
            this.ubDecide.Name = "ubDecide";
            this.ubDecide.Size = new System.Drawing.Size( 136, 28 );
            this.ubDecide.TabIndex = 6;
            this.ubDecide.Text = "新規作成(&N)";
            this.ubDecide.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.ubDecide.Click += new System.EventHandler( this.ubDecide_Click );
            // 
            // tedDisplayName
            // 
            appearance11.BackColor = System.Drawing.Color.FromArgb( ((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))) );
            this.tedDisplayName.ActiveAppearance = appearance11;
            appearance15.BackColor = System.Drawing.Color.FromArgb( ((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))) );
            this.tedDisplayName.Appearance = appearance15;
            this.tedDisplayName.AutoSelect = true;
            this.tedDisplayName.BackColor = System.Drawing.Color.FromArgb( ((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))) );
            this.tedDisplayName.DataText = "";
            this.tedDisplayName.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase( true, true, true, true, true, true, true, true, false );
            this.tedDisplayName.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit( Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 15, new Broadleaf.Library.Windows.Forms.TEnableChars( true, true, true, true, true, true, true ) );
            this.tedDisplayName.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.tedDisplayName.Location = new System.Drawing.Point( 118, 39 );
            this.tedDisplayName.MaxLength = 15;
            this.tedDisplayName.Name = "tedDisplayName";
            this.tedDisplayName.Size = new System.Drawing.Size( 253, 24 );
            this.tedDisplayName.TabIndex = 1;
            // 
            // ulDisplayName
            // 
            appearance16.TextVAlignAsString = "Middle";
            this.ulDisplayName.Appearance = appearance16;
            this.ulDisplayName.Location = new System.Drawing.Point( 12, 40 );
            this.ulDisplayName.Name = "ulDisplayName";
            this.ulDisplayName.Size = new System.Drawing.Size( 100, 23 );
            this.ulDisplayName.TabIndex = 0;
            this.ulDisplayName.Text = "帳票名称";
            // 
            // ulPaperName
            // 
            appearance4.TextVAlignAsString = "Middle";
            this.ulPaperName.Appearance = appearance4;
            this.ulPaperName.Location = new System.Drawing.Point( 12, 124 );
            this.ulPaperName.Name = "ulPaperName";
            this.ulPaperName.Size = new System.Drawing.Size( 100, 23 );
            this.ulPaperName.TabIndex = 0;
            this.ulPaperName.Text = "用紙種類";
            // 
            // ulFreePrtPprItemGrpNm
            // 
            appearance5.TextVAlignAsString = "Middle";
            this.ulFreePrtPprItemGrpNm.Appearance = appearance5;
            this.ulFreePrtPprItemGrpNm.Location = new System.Drawing.Point( 12, 96 );
            this.ulFreePrtPprItemGrpNm.Name = "ulFreePrtPprItemGrpNm";
            this.ulFreePrtPprItemGrpNm.Size = new System.Drawing.Size( 100, 23 );
            this.ulFreePrtPprItemGrpNm.TabIndex = 0;
            this.ulFreePrtPprItemGrpNm.Text = "項目グループ";
            // 
            // cmbPaperName
            // 
            appearance6.BackColor = System.Drawing.Color.FromArgb( ((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))) );
            this.cmbPaperName.ActiveAppearance = appearance6;
            this.cmbPaperName.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.cmbPaperName.ImeMode = System.Windows.Forms.ImeMode.Off;
            appearance7.BackColor = System.Drawing.Color.FromArgb( ((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))) );
            this.cmbPaperName.ItemAppearance = appearance7;
            this.cmbPaperName.Location = new System.Drawing.Point( 118, 123 );
            this.cmbPaperName.Name = "cmbPaperName";
            this.cmbPaperName.Size = new System.Drawing.Size( 182, 24 );
            this.cmbPaperName.TabIndex = 4;
            // 
            // cmbFreePrtPprItemGrpNm
            // 
            appearance8.BackColor = System.Drawing.Color.FromArgb( ((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))) );
            this.cmbFreePrtPprItemGrpNm.ActiveAppearance = appearance8;
            this.cmbFreePrtPprItemGrpNm.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.cmbFreePrtPprItemGrpNm.ImeMode = System.Windows.Forms.ImeMode.Off;
            appearance9.BackColor = System.Drawing.Color.FromArgb( ((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))) );
            this.cmbFreePrtPprItemGrpNm.ItemAppearance = appearance9;
            this.cmbFreePrtPprItemGrpNm.Location = new System.Drawing.Point( 118, 95 );
            this.cmbFreePrtPprItemGrpNm.MaxDropDownItems = 20;
            this.cmbFreePrtPprItemGrpNm.Name = "cmbFreePrtPprItemGrpNm";
            this.cmbFreePrtPprItemGrpNm.Size = new System.Drawing.Size( 253, 24 );
            this.cmbFreePrtPprItemGrpNm.TabIndex = 3;
            // 
            // tRetKeyControl1
            // 
            this.tRetKeyControl1.OwnerForm = this;
            this.tRetKeyControl1.Style = Broadleaf.Library.Windows.Forms.emFocusStyle.ByTab;
            // 
            // tArrowKeyControl1
            // 
            this.tArrowKeyControl1.OwnerForm = this;
            // 
            // uosOrientation
            // 
            this.uosOrientation.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            this.uosOrientation.CheckedIndex = 0;
            this.uosOrientation.ItemOrigin = new System.Drawing.Point( 4, 4 );
            valueListItem1.DataValue = 0;
            valueListItem1.DisplayText = "横";
            valueListItem2.DataValue = 1;
            valueListItem2.DisplayText = "縦";
            this.uosOrientation.Items.AddRange( new Infragistics.Win.ValueListItem[] {
            valueListItem1,
            valueListItem2} );
            this.uosOrientation.ItemSpacingHorizontal = 5;
            this.uosOrientation.Location = new System.Drawing.Point( 118, 150 );
            this.uosOrientation.Name = "uosOrientation";
            this.uosOrientation.Size = new System.Drawing.Size( 87, 24 );
            this.uosOrientation.TabIndex = 5;
            this.uosOrientation.Text = "横";
            // 
            // ultraLabel6
            // 
            appearance14.TextVAlignAsString = "Middle";
            this.ultraLabel6.Appearance = appearance14;
            this.ultraLabel6.Location = new System.Drawing.Point( 12, 68 );
            this.ultraLabel6.Name = "ultraLabel6";
            this.ultraLabel6.Size = new System.Drawing.Size( 100, 23 );
            this.ultraLabel6.TabIndex = 102;
            this.ultraLabel6.Text = "帳票使用区分";
            // 
            // ulLandscape
            // 
            appearance10.TextVAlignAsString = "Middle";
            this.ulLandscape.Appearance = appearance10;
            this.ulLandscape.Location = new System.Drawing.Point( 12, 151 );
            this.ulLandscape.Name = "ulLandscape";
            this.ulLandscape.Size = new System.Drawing.Size( 100, 23 );
            this.ulLandscape.TabIndex = 103;
            this.ulLandscape.Text = "用紙方向";
            // 
            // cmbPrintPaperUseDivcd
            // 
            appearance12.BackColor = System.Drawing.Color.FromArgb( ((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))) );
            this.cmbPrintPaperUseDivcd.ActiveAppearance = appearance12;
            this.cmbPrintPaperUseDivcd.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.cmbPrintPaperUseDivcd.ImeMode = System.Windows.Forms.ImeMode.Off;
            appearance13.BackColor = System.Drawing.Color.FromArgb( ((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))) );
            this.cmbPrintPaperUseDivcd.ItemAppearance = appearance13;
            this.cmbPrintPaperUseDivcd.Location = new System.Drawing.Point( 118, 67 );
            this.cmbPrintPaperUseDivcd.Name = "cmbPrintPaperUseDivcd";
            this.cmbPrintPaperUseDivcd.Size = new System.Drawing.Size( 182, 24 );
            this.cmbPrintPaperUseDivcd.TabIndex = 2;
            this.cmbPrintPaperUseDivcd.SelectionChanged += new System.EventHandler( this.cmbPrintPaperUseDivcd_SelectionChanged );
            // 
            // tedPrtFormId
            // 
            appearance1.BackColor = System.Drawing.Color.FromArgb( ((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))) );
            this.tedPrtFormId.ActiveAppearance = appearance1;
            appearance2.BackColor = System.Drawing.Color.FromArgb( ((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))) );
            this.tedPrtFormId.Appearance = appearance2;
            this.tedPrtFormId.AutoSelect = true;
            this.tedPrtFormId.BackColor = System.Drawing.Color.FromArgb( ((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))) );
            this.tedPrtFormId.DataText = "";
            this.tedPrtFormId.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase( true, true, true, true, true, true, true, true, false );
            this.tedPrtFormId.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit( Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 15, new Broadleaf.Library.Windows.Forms.TEnableChars( true, true, true, true, true, true, true ) );
            this.tedPrtFormId.ImeMode = System.Windows.Forms.ImeMode.Close;
            this.tedPrtFormId.Location = new System.Drawing.Point( 118, 11 );
            this.tedPrtFormId.MaxLength = 15;
            this.tedPrtFormId.Name = "tedPrtFormId";
            this.tedPrtFormId.Size = new System.Drawing.Size( 253, 24 );
            this.tedPrtFormId.TabIndex = 0;
            // 
            // ulPrtFormId
            // 
            appearance3.TextVAlignAsString = "Middle";
            this.ulPrtFormId.Appearance = appearance3;
            this.ulPrtFormId.Location = new System.Drawing.Point( 12, 11 );
            this.ulPrtFormId.Name = "ulPrtFormId";
            this.ulPrtFormId.Size = new System.Drawing.Size( 100, 23 );
            this.ulPrtFormId.TabIndex = 105;
            this.ulPrtFormId.Text = "帳票ＩＤ";
            // 
            // SFANL08105UF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 8F, 15F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb( ((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))) );
            this.ClientSize = new System.Drawing.Size( 390, 215 );
            this.Controls.Add( this.ulPrtFormId );
            this.Controls.Add( this.tedPrtFormId );
            this.Controls.Add( this.ulLandscape );
            this.Controls.Add( this.uosOrientation );
            this.Controls.Add( this.cmbFreePrtPprItemGrpNm );
            this.Controls.Add( this.cmbPrintPaperUseDivcd );
            this.Controls.Add( this.cmbPaperName );
            this.Controls.Add( this.ulFreePrtPprItemGrpNm );
            this.Controls.Add( this.ulPaperName );
            this.Controls.Add( this.ulDisplayName );
            this.Controls.Add( this.tedDisplayName );
            this.Controls.Add( this.ubCancel );
            this.Controls.Add( this.ubDecide );
            this.Controls.Add( this.ultraLabel6 );
            this.Font = new System.Drawing.Font( "ＭＳ ゴシック", 11F );
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject( "$this.Icon" )));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding( 4 );
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SFANL08105UF";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "自由帳票 - 新規作成";
            this.Load += new System.EventHandler( this.SFANL08105UF_Load );
            this.KeyDown += new System.Windows.Forms.KeyEventHandler( this.SFANL08105UF_KeyDown );
            ((System.ComponentModel.ISupportInitialize)(this.tedDisplayName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPaperName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbFreePrtPprItemGrpNm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uosOrientation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPrintPaperUseDivcd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tedPrtFormId)).EndInit();
            this.ResumeLayout( false );
            this.PerformLayout();

		}

		#endregion

		private Infragistics.Win.Misc.UltraButton ubCancel;
		private Infragistics.Win.Misc.UltraButton ubDecide;
		private Broadleaf.Library.Windows.Forms.TEdit tedDisplayName;
		private Infragistics.Win.Misc.UltraLabel ulDisplayName;
		private Infragistics.Win.Misc.UltraLabel ulPaperName;
		private Infragistics.Win.Misc.UltraLabel ulFreePrtPprItemGrpNm;
		private Broadleaf.Library.Windows.Forms.TComboEditor cmbPaperName;
		private Broadleaf.Library.Windows.Forms.TComboEditor cmbFreePrtPprItemGrpNm;
		private Broadleaf.Library.Windows.Forms.TRetKeyControl tRetKeyControl1;
		private Broadleaf.Library.Windows.Forms.TArrowKeyControl tArrowKeyControl1;
		private Infragistics.Win.UltraWinEditors.UltraOptionSet uosOrientation;
		private Infragistics.Win.Misc.UltraLabel ultraLabel6;
		private Infragistics.Win.Misc.UltraLabel ulLandscape;
		private Broadleaf.Library.Windows.Forms.TComboEditor cmbPrintPaperUseDivcd;
        private Infragistics.Win.Misc.UltraLabel ulPrtFormId;
        private Broadleaf.Library.Windows.Forms.TEdit tedPrtFormId;
	}
}
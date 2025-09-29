namespace Broadleaf.Windows.Forms
{
	partial class SFANL08105UG
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
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( SFANL08105UG ) );
            this.ubCancel = new Infragistics.Win.Misc.UltraButton();
            this.ubSave = new Infragistics.Win.Misc.UltraButton();
            this.ulDisplayName = new Infragistics.Win.Misc.UltraLabel();
            this.tedDisplayName = new Broadleaf.Library.Windows.Forms.TEdit();
            this.ulPrtPprUserDerivNoCmt = new Infragistics.Win.Misc.UltraLabel();
            this.tedPrtPprUserDerivNoCmt = new Broadleaf.Library.Windows.Forms.TEdit();
            this.ulOutConfimationMsg = new Infragistics.Win.Misc.UltraLabel();
            this.tedOutConfimationMsg = new Broadleaf.Library.Windows.Forms.TEdit();
            this.tArrowKeyControl1 = new Broadleaf.Library.Windows.Forms.TArrowKeyControl( this.components );
            this.tRetKeyControl1 = new Broadleaf.Library.Windows.Forms.TRetKeyControl( this.components );
            this.ulSlipPrtKind = new Infragistics.Win.Misc.UltraLabel();
            this.pnlSlipPrtKind = new System.Windows.Forms.Panel();
            this.uceDelivery = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.uceAcpOdr = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.uceShipment = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.uceEstimate = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.tedPrtFormId = new Broadleaf.Library.Windows.Forms.TEdit();
            this.ulPrtFormId = new Infragistics.Win.Misc.UltraLabel();
            ((System.ComponentModel.ISupportInitialize)(this.tedDisplayName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tedPrtPprUserDerivNoCmt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tedOutConfimationMsg)).BeginInit();
            this.pnlSlipPrtKind.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tedPrtFormId)).BeginInit();
            this.SuspendLayout();
            // 
            // ubCancel
            // 
            this.ubCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ubCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ubCancel.Location = new System.Drawing.Point( 294, 162 );
            this.ubCancel.Name = "ubCancel";
            this.ubCancel.Size = new System.Drawing.Size( 136, 28 );
            this.ubCancel.TabIndex = 6;
            this.ubCancel.Text = "キャンセル(&C)";
            this.ubCancel.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.ubCancel.Click += new System.EventHandler( this.ubCancel_Click );
            // 
            // ubSave
            // 
            this.ubSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ubSave.Location = new System.Drawing.Point( 152, 162 );
            this.ubSave.Name = "ubSave";
            this.ubSave.Size = new System.Drawing.Size( 136, 28 );
            this.ubSave.TabIndex = 5;
            this.ubSave.Text = "保存(&S)";
            this.ubSave.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.ubSave.Click += new System.EventHandler( this.ubSave_Click );
            // 
            // ulDisplayName
            // 
            appearance11.TextVAlignAsString = "Middle";
            this.ulDisplayName.Appearance = appearance11;
            this.ulDisplayName.Location = new System.Drawing.Point( 12, 42 );
            this.ulDisplayName.Name = "ulDisplayName";
            this.ulDisplayName.Size = new System.Drawing.Size( 100, 23 );
            this.ulDisplayName.TabIndex = 104;
            this.ulDisplayName.Text = "帳票名称";
            // 
            // tedDisplayName
            // 
            appearance12.BackColor = System.Drawing.Color.FromArgb( ((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))) );
            this.tedDisplayName.ActiveAppearance = appearance12;
            appearance13.BackColor = System.Drawing.Color.FromArgb( ((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))) );
            this.tedDisplayName.Appearance = appearance13;
            this.tedDisplayName.AutoSelect = true;
            this.tedDisplayName.BackColor = System.Drawing.Color.FromArgb( ((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))) );
            this.tedDisplayName.DataText = "";
            this.tedDisplayName.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase( true, true, true, true, true, true, true, true, false );
            this.tedDisplayName.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit( Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 15, new Broadleaf.Library.Windows.Forms.TEnableChars( true, true, true, true, true, true, true ) );
            this.tedDisplayName.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.tedDisplayName.Location = new System.Drawing.Point( 175, 41 );
            this.tedDisplayName.MaxLength = 15;
            this.tedDisplayName.Name = "tedDisplayName";
            this.tedDisplayName.Size = new System.Drawing.Size( 253, 24 );
            this.tedDisplayName.TabIndex = 1;
            // 
            // ulPrtPprUserDerivNoCmt
            // 
            appearance4.TextVAlignAsString = "Middle";
            this.ulPrtPprUserDerivNoCmt.Appearance = appearance4;
            this.ulPrtPprUserDerivNoCmt.Location = new System.Drawing.Point( 12, 70 );
            this.ulPrtPprUserDerivNoCmt.Name = "ulPrtPprUserDerivNoCmt";
            this.ulPrtPprUserDerivNoCmt.Size = new System.Drawing.Size( 157, 23 );
            this.ulPrtPprUserDerivNoCmt.TabIndex = 106;
            this.ulPrtPprUserDerivNoCmt.Text = "コメント（ユーザー）";
            // 
            // tedPrtPprUserDerivNoCmt
            // 
            appearance5.BackColor = System.Drawing.Color.FromArgb( ((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))) );
            this.tedPrtPprUserDerivNoCmt.ActiveAppearance = appearance5;
            appearance6.BackColor = System.Drawing.Color.FromArgb( ((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))) );
            this.tedPrtPprUserDerivNoCmt.Appearance = appearance6;
            this.tedPrtPprUserDerivNoCmt.AutoSelect = true;
            this.tedPrtPprUserDerivNoCmt.BackColor = System.Drawing.Color.FromArgb( ((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))) );
            this.tedPrtPprUserDerivNoCmt.DataText = "";
            this.tedPrtPprUserDerivNoCmt.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase( true, true, true, true, true, true, true, true, false );
            this.tedPrtPprUserDerivNoCmt.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit( Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 15, new Broadleaf.Library.Windows.Forms.TEnableChars( true, true, true, true, true, true, true ) );
            this.tedPrtPprUserDerivNoCmt.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.tedPrtPprUserDerivNoCmt.Location = new System.Drawing.Point( 175, 69 );
            this.tedPrtPprUserDerivNoCmt.MaxLength = 15;
            this.tedPrtPprUserDerivNoCmt.Name = "tedPrtPprUserDerivNoCmt";
            this.tedPrtPprUserDerivNoCmt.Size = new System.Drawing.Size( 253, 24 );
            this.tedPrtPprUserDerivNoCmt.TabIndex = 2;
            // 
            // ulOutConfimationMsg
            // 
            appearance7.TextVAlignAsString = "Middle";
            this.ulOutConfimationMsg.Appearance = appearance7;
            this.ulOutConfimationMsg.Location = new System.Drawing.Point( 12, 98 );
            this.ulOutConfimationMsg.Name = "ulOutConfimationMsg";
            this.ulOutConfimationMsg.Size = new System.Drawing.Size( 157, 23 );
            this.ulOutConfimationMsg.TabIndex = 108;
            this.ulOutConfimationMsg.Text = "出力確認メッセージ";
            // 
            // tedOutConfimationMsg
            // 
            appearance8.BackColor = System.Drawing.Color.FromArgb( ((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))) );
            this.tedOutConfimationMsg.ActiveAppearance = appearance8;
            appearance9.BackColor = System.Drawing.Color.FromArgb( ((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))) );
            this.tedOutConfimationMsg.Appearance = appearance9;
            this.tedOutConfimationMsg.AutoSelect = true;
            this.tedOutConfimationMsg.BackColor = System.Drawing.Color.FromArgb( ((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))) );
            this.tedOutConfimationMsg.DataText = "";
            this.tedOutConfimationMsg.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase( true, true, true, true, true, true, true, true, false );
            this.tedOutConfimationMsg.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit( Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 25, new Broadleaf.Library.Windows.Forms.TEnableChars( true, true, true, true, true, true, true ) );
            this.tedOutConfimationMsg.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.tedOutConfimationMsg.Location = new System.Drawing.Point( 175, 97 );
            this.tedOutConfimationMsg.MaxLength = 25;
            this.tedOutConfimationMsg.Name = "tedOutConfimationMsg";
            this.tedOutConfimationMsg.Size = new System.Drawing.Size( 252, 24 );
            this.tedOutConfimationMsg.TabIndex = 3;
            // 
            // tArrowKeyControl1
            // 
            this.tArrowKeyControl1.OwnerForm = this;
            // 
            // tRetKeyControl1
            // 
            this.tRetKeyControl1.OwnerForm = this;
            this.tRetKeyControl1.Style = Broadleaf.Library.Windows.Forms.emFocusStyle.ByTab;
            // 
            // ulSlipPrtKind
            // 
            appearance10.TextVAlignAsString = "Middle";
            this.ulSlipPrtKind.Appearance = appearance10;
            this.ulSlipPrtKind.Location = new System.Drawing.Point( 0, 2 );
            this.ulSlipPrtKind.Name = "ulSlipPrtKind";
            this.ulSlipPrtKind.Size = new System.Drawing.Size( 157, 23 );
            this.ulSlipPrtKind.TabIndex = 110;
            this.ulSlipPrtKind.Text = "伝票種別";
            // 
            // pnlSlipPrtKind
            // 
            this.pnlSlipPrtKind.Controls.Add( this.uceDelivery );
            this.pnlSlipPrtKind.Controls.Add( this.uceAcpOdr );
            this.pnlSlipPrtKind.Controls.Add( this.uceShipment );
            this.pnlSlipPrtKind.Controls.Add( this.uceEstimate );
            this.pnlSlipPrtKind.Controls.Add( this.ulSlipPrtKind );
            this.pnlSlipPrtKind.Location = new System.Drawing.Point( 12, 128 );
            this.pnlSlipPrtKind.Name = "pnlSlipPrtKind";
            this.pnlSlipPrtKind.Size = new System.Drawing.Size( 400, 25 );
            this.pnlSlipPrtKind.TabIndex = 4;
            // 
            // uceDelivery
            // 
            this.uceDelivery.Location = new System.Drawing.Point( 163, 4 );
            this.uceDelivery.Name = "uceDelivery";
            this.uceDelivery.Size = new System.Drawing.Size( 55, 20 );
            this.uceDelivery.TabIndex = 0;
            this.uceDelivery.Text = "売上";
            // 
            // uceAcpOdr
            // 
            this.uceAcpOdr.Location = new System.Drawing.Point( 224, 4 );
            this.uceAcpOdr.Name = "uceAcpOdr";
            this.uceAcpOdr.Size = new System.Drawing.Size( 55, 20 );
            this.uceAcpOdr.TabIndex = 1;
            this.uceAcpOdr.Text = "受注";
            // 
            // uceShipment
            // 
            this.uceShipment.Location = new System.Drawing.Point( 282, 4 );
            this.uceShipment.Name = "uceShipment";
            this.uceShipment.Size = new System.Drawing.Size( 55, 20 );
            this.uceShipment.TabIndex = 2;
            this.uceShipment.Text = "貸出";
            // 
            // uceEstimate
            // 
            this.uceEstimate.Location = new System.Drawing.Point( 342, 4 );
            this.uceEstimate.Name = "uceEstimate";
            this.uceEstimate.Size = new System.Drawing.Size( 55, 20 );
            this.uceEstimate.TabIndex = 3;
            this.uceEstimate.Text = "見積";
            // 
            // tedPrtFormId
            // 
            appearance2.BackColor = System.Drawing.Color.FromArgb( ((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))) );
            this.tedPrtFormId.ActiveAppearance = appearance2;
            appearance3.BackColor = System.Drawing.Color.FromArgb( ((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))) );
            this.tedPrtFormId.Appearance = appearance3;
            this.tedPrtFormId.AutoSelect = true;
            this.tedPrtFormId.BackColor = System.Drawing.Color.FromArgb( ((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))) );
            this.tedPrtFormId.DataText = "";
            this.tedPrtFormId.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase( true, true, true, true, true, true, true, true, false );
            this.tedPrtFormId.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit( Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 15, new Broadleaf.Library.Windows.Forms.TEnableChars( true, true, true, true, true, true, true ) );
            this.tedPrtFormId.ImeMode = System.Windows.Forms.ImeMode.Close;
            this.tedPrtFormId.Location = new System.Drawing.Point( 175, 13 );
            this.tedPrtFormId.MaxLength = 15;
            this.tedPrtFormId.Name = "tedPrtFormId";
            this.tedPrtFormId.Size = new System.Drawing.Size( 253, 24 );
            this.tedPrtFormId.TabIndex = 0;
            // 
            // ulPrtFormId
            // 
            appearance1.TextVAlignAsString = "Middle";
            this.ulPrtFormId.Appearance = appearance1;
            this.ulPrtFormId.Location = new System.Drawing.Point( 12, 12 );
            this.ulPrtFormId.Name = "ulPrtFormId";
            this.ulPrtFormId.Size = new System.Drawing.Size( 100, 23 );
            this.ulPrtFormId.TabIndex = 110;
            this.ulPrtFormId.Text = "帳票ＩＤ";
            // 
            // SFANL08105UG
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 8F, 15F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb( ((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))) );
            this.CancelButton = this.ubCancel;
            this.ClientSize = new System.Drawing.Size( 442, 198 );
            this.Controls.Add( this.ulPrtFormId );
            this.Controls.Add( this.tedPrtFormId );
            this.Controls.Add( this.pnlSlipPrtKind );
            this.Controls.Add( this.ulOutConfimationMsg );
            this.Controls.Add( this.tedOutConfimationMsg );
            this.Controls.Add( this.ulPrtPprUserDerivNoCmt );
            this.Controls.Add( this.tedPrtPprUserDerivNoCmt );
            this.Controls.Add( this.ulDisplayName );
            this.Controls.Add( this.tedDisplayName );
            this.Controls.Add( this.ubCancel );
            this.Controls.Add( this.ubSave );
            this.Font = new System.Drawing.Font( "ＭＳ ゴシック", 11F );
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject( "$this.Icon" )));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding( 4 );
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SFANL08105UG";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "自由帳票 - 名前を付けて保存";
            this.Load += new System.EventHandler( this.SFANL08105UI_Load );
            this.KeyDown += new System.Windows.Forms.KeyEventHandler( this.SFANL08105UG_KeyDown );
            ((System.ComponentModel.ISupportInitialize)(this.tedDisplayName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tedPrtPprUserDerivNoCmt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tedOutConfimationMsg)).EndInit();
            this.pnlSlipPrtKind.ResumeLayout( false );
            ((System.ComponentModel.ISupportInitialize)(this.tedPrtFormId)).EndInit();
            this.ResumeLayout( false );
            this.PerformLayout();

		}

		#endregion

		private Infragistics.Win.Misc.UltraButton ubCancel;
		private Infragistics.Win.Misc.UltraButton ubSave;
		private Infragistics.Win.Misc.UltraLabel ulDisplayName;
		private Broadleaf.Library.Windows.Forms.TEdit tedDisplayName;
		private Infragistics.Win.Misc.UltraLabel ulPrtPprUserDerivNoCmt;
		private Broadleaf.Library.Windows.Forms.TEdit tedPrtPprUserDerivNoCmt;
		private Infragistics.Win.Misc.UltraLabel ulOutConfimationMsg;
		private Broadleaf.Library.Windows.Forms.TEdit tedOutConfimationMsg;
		private Broadleaf.Library.Windows.Forms.TArrowKeyControl tArrowKeyControl1;
		private Broadleaf.Library.Windows.Forms.TRetKeyControl tRetKeyControl1;
		private System.Windows.Forms.Panel pnlSlipPrtKind;
		private Infragistics.Win.Misc.UltraLabel ulSlipPrtKind;
		private Infragistics.Win.UltraWinEditors.UltraCheckEditor uceDelivery;
		private Infragistics.Win.UltraWinEditors.UltraCheckEditor uceAcpOdr;
		private Infragistics.Win.UltraWinEditors.UltraCheckEditor uceShipment;
		private Infragistics.Win.UltraWinEditors.UltraCheckEditor uceEstimate;
        private Infragistics.Win.Misc.UltraLabel ulPrtFormId;
        private Broadleaf.Library.Windows.Forms.TEdit tedPrtFormId;
	}
}
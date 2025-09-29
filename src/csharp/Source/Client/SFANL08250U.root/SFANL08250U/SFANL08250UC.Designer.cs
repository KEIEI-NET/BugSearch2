namespace Broadleaf.Windows.Forms
{
	partial class SFANL08250UC
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
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( SFANL08250UC ) );
            this.cmbFreePrtPprSchmGrpCd = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.ulFreePrtPprSchmGrpCd = new Infragistics.Win.Misc.UltraLabel();
            this.ubCancel = new Infragistics.Win.Misc.UltraButton();
            this.ubDecide = new Infragistics.Win.Misc.UltraButton();
            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.ndtFreePrtPprSchmGrpCd = new Broadleaf.Library.Windows.Forms.TNedit();
            this.tArrowKeyControl1 = new Broadleaf.Library.Windows.Forms.TArrowKeyControl( this.components );
            this.tRetKeyControl1 = new Broadleaf.Library.Windows.Forms.TRetKeyControl( this.components );
            ((System.ComponentModel.ISupportInitialize)(this.cmbFreePrtPprSchmGrpCd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ndtFreePrtPprSchmGrpCd)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbFreePrtPprSchmGrpCd
            // 
            appearance1.BackColor = System.Drawing.Color.FromArgb( ((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))) );
            this.cmbFreePrtPprSchmGrpCd.ActiveAppearance = appearance1;
            this.cmbFreePrtPprSchmGrpCd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbFreePrtPprSchmGrpCd.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.cmbFreePrtPprSchmGrpCd.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance2.BackColor = System.Drawing.Color.FromArgb( ((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))) );
            this.cmbFreePrtPprSchmGrpCd.ItemAppearance = appearance2;
            this.cmbFreePrtPprSchmGrpCd.Location = new System.Drawing.Point( 238, 40 );
            this.cmbFreePrtPprSchmGrpCd.Name = "cmbFreePrtPprSchmGrpCd";
            this.cmbFreePrtPprSchmGrpCd.Size = new System.Drawing.Size( 142, 24 );
            this.cmbFreePrtPprSchmGrpCd.TabIndex = 2;
            // 
            // ulFreePrtPprSchmGrpCd
            // 
            appearance3.TextVAlignAsString = "Middle";
            this.ulFreePrtPprSchmGrpCd.Appearance = appearance3;
            this.ulFreePrtPprSchmGrpCd.Font = new System.Drawing.Font( "ＭＳ ゴシック", 11F );
            this.ulFreePrtPprSchmGrpCd.Location = new System.Drawing.Point( 6, 41 );
            this.ulFreePrtPprSchmGrpCd.Name = "ulFreePrtPprSchmGrpCd";
            this.ulFreePrtPprSchmGrpCd.Size = new System.Drawing.Size( 232, 23 );
            this.ulFreePrtPprSchmGrpCd.TabIndex = 18;
            this.ulFreePrtPprSchmGrpCd.Text = "コピー元スキーマグループコード";
            this.ulFreePrtPprSchmGrpCd.WrapText = false;
            // 
            // ubCancel
            // 
            this.ubCancel.BackColorInternal = System.Drawing.Color.WhiteSmoke;
            this.ubCancel.Font = new System.Drawing.Font( "ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)) );
            this.ubCancel.ImageSize = new System.Drawing.Size( 24, 24 );
            this.ubCancel.Location = new System.Drawing.Point( 255, 74 );
            this.ubCancel.Name = "ubCancel";
            this.ubCancel.Size = new System.Drawing.Size( 125, 29 );
            this.ubCancel.TabIndex = 11;
            this.ubCancel.Text = "閉じる(&X)";
            this.ubCancel.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.ubCancel.Click += new System.EventHandler( this.ubCancel_Click );
            // 
            // ubDecide
            // 
            this.ubDecide.BackColorInternal = System.Drawing.Color.WhiteSmoke;
            this.ubDecide.Font = new System.Drawing.Font( "ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)) );
            this.ubDecide.ImageSize = new System.Drawing.Size( 24, 24 );
            this.ubDecide.Location = new System.Drawing.Point( 126, 74 );
            this.ubDecide.Name = "ubDecide";
            this.ubDecide.Size = new System.Drawing.Size( 125, 29 );
            this.ubDecide.TabIndex = 10;
            this.ubDecide.Text = "確定(&S)";
            this.ubDecide.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.ubDecide.Click += new System.EventHandler( this.ubDecide_Click );
            // 
            // ultraLabel1
            // 
            appearance4.TextVAlignAsString = "Middle";
            this.ultraLabel1.Appearance = appearance4;
            this.ultraLabel1.Font = new System.Drawing.Font( "ＭＳ ゴシック", 11F );
            this.ultraLabel1.Location = new System.Drawing.Point( 6, 12 );
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size( 232, 23 );
            this.ultraLabel1.TabIndex = 18;
            this.ultraLabel1.Text = "スキーマグループコード";
            this.ultraLabel1.WrapText = false;
            // 
            // ndtFreePrtPprSchmGrpCd
            // 
            appearance5.BackColor = System.Drawing.Color.FromArgb( ((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))) );
            this.ndtFreePrtPprSchmGrpCd.ActiveAppearance = appearance5;
            appearance6.TextHAlignAsString = "Right";
            this.ndtFreePrtPprSchmGrpCd.Appearance = appearance6;
            this.ndtFreePrtPprSchmGrpCd.AutoSelect = true;
            this.ndtFreePrtPprSchmGrpCd.CalcSize = new System.Drawing.Size( 172, 200 );
            this.ndtFreePrtPprSchmGrpCd.DataText = "";
            this.ndtFreePrtPprSchmGrpCd.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase( true, true, true, true, true, true, true, true, false );
            this.ndtFreePrtPprSchmGrpCd.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit( Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 4, new Broadleaf.Library.Windows.Forms.TEnableChars( false, false, false, false, false, false, true ) );
            this.ndtFreePrtPprSchmGrpCd.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.ndtFreePrtPprSchmGrpCd.Location = new System.Drawing.Point( 238, 11 );
            this.ndtFreePrtPprSchmGrpCd.MaxLength = 4;
            this.ndtFreePrtPprSchmGrpCd.Name = "ndtFreePrtPprSchmGrpCd";
            this.ndtFreePrtPprSchmGrpCd.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit( false, 0, false, true, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF );
            this.ndtFreePrtPprSchmGrpCd.Size = new System.Drawing.Size( 43, 24 );
            this.ndtFreePrtPprSchmGrpCd.TabIndex = 1;
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
            // SFANL08250UC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 8F, 15F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb( ((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))) );
            this.ClientSize = new System.Drawing.Size( 389, 110 );
            this.Controls.Add( this.ndtFreePrtPprSchmGrpCd );
            this.Controls.Add( this.ubCancel );
            this.Controls.Add( this.ubDecide );
            this.Controls.Add( this.ultraLabel1 );
            this.Controls.Add( this.ulFreePrtPprSchmGrpCd );
            this.Controls.Add( this.cmbFreePrtPprSchmGrpCd );
            this.Font = new System.Drawing.Font( "ＭＳ ゴシック", 11F );
            this.Icon = ((System.Drawing.Icon)(resources.GetObject( "$this.Icon" )));
            this.Margin = new System.Windows.Forms.Padding( 4 );
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SFANL08250UC";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "新規追加スキーマグループコード選択";
            ((System.ComponentModel.ISupportInitialize)(this.cmbFreePrtPprSchmGrpCd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ndtFreePrtPprSchmGrpCd)).EndInit();
            this.ResumeLayout( false );
            this.PerformLayout();

		}

		#endregion

		private Broadleaf.Library.Windows.Forms.TComboEditor cmbFreePrtPprSchmGrpCd;
		private Infragistics.Win.Misc.UltraLabel ulFreePrtPprSchmGrpCd;
		private Infragistics.Win.Misc.UltraButton ubCancel;
		private Infragistics.Win.Misc.UltraButton ubDecide;
		private Infragistics.Win.Misc.UltraLabel ultraLabel1;
		private Broadleaf.Library.Windows.Forms.TNedit ndtFreePrtPprSchmGrpCd;
		private Broadleaf.Library.Windows.Forms.TArrowKeyControl tArrowKeyControl1;
		private Broadleaf.Library.Windows.Forms.TRetKeyControl tRetKeyControl1;
	}
}
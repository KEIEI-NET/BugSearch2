namespace Broadleaf.Windows.Forms
{
    partial class EmployeeLogin2FormAF
    {
        /// <summary>
        /// 必要なデザイナ変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private Infragistics.Win.Misc.UltraLabel ultraLabel_LoginId;
        private Infragistics.Win.Misc.UltraLabel ultraLabel_LoginPassword;
        private Infragistics.Win.Misc.UltraButton ultraButton_OK;
        private Infragistics.Win.Misc.UltraButton ultraButton_CANCEL;
        private Broadleaf.Library.Windows.Forms.TEdit tEdit_LoginId;
        private Broadleaf.Library.Windows.Forms.TEdit tEdit_LoginPassword;
        private Broadleaf.Library.Windows.Forms.TRetKeyControl tRetKeyControl1;
        private Broadleaf.Library.Windows.Forms.TArrowKeyControl tArrowKeyControl1;
        private Infragistics.Win.UltraWinStatusBar.UltraStatusBar ultraStatusBar_EmployeeLogin;
        //private System.ComponentModel.IContainer components;
        
        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if( disposing && ( components != null ) )
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
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel1 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( EmployeeLogin2FormAF ) );
            this.tEdit_LoginId = new Broadleaf.Library.Windows.Forms.TEdit();
            this.tEdit_LoginPassword = new Broadleaf.Library.Windows.Forms.TEdit();
            this.ultraButton_OK = new Infragistics.Win.Misc.UltraButton();
            this.ultraButton_CANCEL = new Infragistics.Win.Misc.UltraButton();
            this.ultraLabel_LoginId = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel_LoginPassword = new Infragistics.Win.Misc.UltraLabel();
            this.tRetKeyControl1 = new Broadleaf.Library.Windows.Forms.TRetKeyControl( this.components );
            this.tArrowKeyControl1 = new Broadleaf.Library.Windows.Forms.TArrowKeyControl( this.components );
            this.ultraStatusBar_EmployeeLogin = new Infragistics.Win.UltraWinStatusBar.UltraStatusBar();
            this.timer_FelicaInfo = new System.Windows.Forms.Timer( this.components );
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_LoginId)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_LoginPassword)).BeginInit();
            this.SuspendLayout();
            // 
            // tEdit_LoginId
            // 
            this.tEdit_LoginId.ActiveAppearance = appearance1;
            appearance2.BackColor = System.Drawing.Color.White;
            this.tEdit_LoginId.Appearance = appearance2;
            this.tEdit_LoginId.AutoSelect = true;
            this.tEdit_LoginId.BackColor = System.Drawing.Color.White;
            this.tEdit_LoginId.DataText = "";
            this.tEdit_LoginId.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase( true, true, true, true, true, true, true, true, false );
            this.tEdit_LoginId.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit( Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 24, new Broadleaf.Library.Windows.Forms.TEnableChars( true, false, true, false, true, true, true ) );
            this.tEdit_LoginId.Location = new System.Drawing.Point( 88, 16 );
            this.tEdit_LoginId.MaxLength = 24;
            this.tEdit_LoginId.Name = "tEdit_LoginId";
            this.tEdit_LoginId.Size = new System.Drawing.Size( 190, 21 );
            this.tEdit_LoginId.TabIndex = 0;
            this.tEdit_LoginId.Tag = "1";
            // 
            // tEdit_LoginPassword
            // 
            this.tEdit_LoginPassword.ActiveAppearance = appearance3;
            this.tEdit_LoginPassword.AutoSelect = true;
            this.tEdit_LoginPassword.DataText = "";
            this.tEdit_LoginPassword.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase( true, true, true, true, true, true, true, true, false );
            this.tEdit_LoginPassword.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit( Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 24, new Broadleaf.Library.Windows.Forms.TEnableChars( true, false, true, false, true, true, true ) );
            this.tEdit_LoginPassword.Location = new System.Drawing.Point( 88, 56 );
            this.tEdit_LoginPassword.MaxLength = 24;
            this.tEdit_LoginPassword.Name = "tEdit_LoginPassword";
            this.tEdit_LoginPassword.PasswordChar = '●';
            this.tEdit_LoginPassword.Size = new System.Drawing.Size( 190, 21 );
            this.tEdit_LoginPassword.TabIndex = 1;
            this.tEdit_LoginPassword.Tag = "2";
            // 
            // ultraButton_OK
            // 
            this.ultraButton_OK.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ultraButton_OK.Location = new System.Drawing.Point( 64, 91 );
            this.ultraButton_OK.Name = "ultraButton_OK";
            this.ultraButton_OK.Size = new System.Drawing.Size( 75, 23 );
            this.ultraButton_OK.TabIndex = 2;
            this.ultraButton_OK.Tag = "100";
            this.ultraButton_OK.Text = "OK";
            this.ultraButton_OK.Click += new System.EventHandler( this.ultraButton_OK_Click );
            // 
            // ultraButton_CANCEL
            // 
            this.ultraButton_CANCEL.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ultraButton_CANCEL.Location = new System.Drawing.Point( 168, 91 );
            this.ultraButton_CANCEL.Name = "ultraButton_CANCEL";
            this.ultraButton_CANCEL.Size = new System.Drawing.Size( 75, 23 );
            this.ultraButton_CANCEL.TabIndex = 3;
            this.ultraButton_CANCEL.Tag = "200";
            this.ultraButton_CANCEL.Text = "CANCEL";
            this.ultraButton_CANCEL.Click += new System.EventHandler( this.ultraButton_CANCEL_Click );
            // 
            // ultraLabel_LoginId
            // 
            this.ultraLabel_LoginId.Location = new System.Drawing.Point( 16, 19 );
            this.ultraLabel_LoginId.Name = "ultraLabel_LoginId";
            this.ultraLabel_LoginId.Size = new System.Drawing.Size( 52, 14 );
            this.ultraLabel_LoginId.TabIndex = 5;
            this.ultraLabel_LoginId.Text = "ログインID";
            // 
            // ultraLabel_LoginPassword
            // 
            this.ultraLabel_LoginPassword.Location = new System.Drawing.Point( 16, 59 );
            this.ultraLabel_LoginPassword.Name = "ultraLabel_LoginPassword";
            this.ultraLabel_LoginPassword.Size = new System.Drawing.Size( 53, 14 );
            this.ultraLabel_LoginPassword.TabIndex = 6;
            this.ultraLabel_LoginPassword.Text = "パスワード";
            // 
            // tRetKeyControl1
            // 
            this.tRetKeyControl1.OwnerForm = this;
            this.tRetKeyControl1.Style = Broadleaf.Library.Windows.Forms.emFocusStyle.ByTab;
            this.tRetKeyControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler( this.tArrowKeyControl1_ChangeFocus );
            // 
            // tArrowKeyControl1
            // 
            this.tArrowKeyControl1.OwnerForm = this;
            this.tArrowKeyControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler( this.tArrowKeyControl1_ChangeFocus );
            // 
            // ultraStatusBar_EmployeeLogin
            // 
            this.ultraStatusBar_EmployeeLogin.Location = new System.Drawing.Point( 0, 127 );
            this.ultraStatusBar_EmployeeLogin.Name = "ultraStatusBar_EmployeeLogin";
            appearance4.ForeColor = System.Drawing.Color.Blue;
            ultraStatusPanel1.Appearance = appearance4;
            ultraStatusPanel1.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            ultraStatusPanel1.Key = "Info";
            ultraStatusPanel1.SizingMode = Infragistics.Win.UltraWinStatusBar.PanelSizingMode.Spring;
            ultraStatusPanel1.Text = "カードをリーダーにかざすか、ログイン情報を入力して下さい";
            this.ultraStatusBar_EmployeeLogin.Panels.AddRange( new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel[] {
            ultraStatusPanel1} );
            this.ultraStatusBar_EmployeeLogin.Size = new System.Drawing.Size( 304, 23 );
            this.ultraStatusBar_EmployeeLogin.TabIndex = 7;
            this.ultraStatusBar_EmployeeLogin.ViewStyle = Infragistics.Win.UltraWinStatusBar.ViewStyle.Office2003;
            // 
            // timer_FelicaInfo
            // 
            this.timer_FelicaInfo.Interval = 1000;
            this.timer_FelicaInfo.Tick += new System.EventHandler( this.timer_FelicaInfo_Tick );
            // 
            // EmployeeLogin2FormAF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 12F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size( 304, 150 );
            this.Controls.Add( this.ultraStatusBar_EmployeeLogin );
            this.Controls.Add( this.ultraLabel_LoginPassword );
            this.Controls.Add( this.ultraLabel_LoginId );
            this.Controls.Add( this.ultraButton_CANCEL );
            this.Controls.Add( this.ultraButton_OK );
            this.Controls.Add( this.tEdit_LoginPassword );
            this.Controls.Add( this.tEdit_LoginId );
            this.Icon = ((System.Drawing.Icon)(resources.GetObject( "$this.Icon" )));
            this.Name = "EmployeeLogin2FormAF";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "従業員ログイン";
            this.Load += new System.EventHandler( this.EmployeeLoginFormAF_Load );
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler( this.EmployeeLoginFormAF_FormClosing );
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_LoginId)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_LoginPassword)).EndInit();
            this.ResumeLayout( false );
            this.PerformLayout();

        }

        #endregion

    }
}
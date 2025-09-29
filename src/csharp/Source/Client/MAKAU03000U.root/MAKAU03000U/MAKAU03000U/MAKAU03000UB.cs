//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 請求帳票プレビューＵＩクラス
// プログラム概要   : 請求帳票プレビューＵＩクラス
//----------------------------------------------------------------------------//
//                (c)Copyright 2022 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11570183-00   作成担当 : 陳艶丹
// 作 成 日  2022/03/01    修正内容 : 新規作成
//----------------------------------------------------------------------------//
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// 請求帳票プレビューＵＩクラス
	/// </summary>
    /// <remarks>
    /// <br>Note        : 請求帳票プレビューＵＩクラスです。</br>
    /// <br>Programmer  : 陳艶丹</br>
    /// <br>Date        : 2022/03/07</br>
    /// </remarks>
	public class MAKAU03000UB : System.Windows.Forms.Form
	{
        [DllImport( "ole32.dll" )] extern static void CoFreeUnusedLibraries();

		/// <summary>
		/// 必要なデザイナ変数です。
		/// </summary>
		private System.ComponentModel.Container components = null;        

		public MAKAU03000UB()
		{
			InitializeComponent();
		}

		// ===================================================================================== //
		// 破棄
		// ===================================================================================== //
		# region Dispose
		/// <summary>
		/// 使用されているリソースに後処理を実行します。
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}
		#endregion

		// ===================================================================================== //
		// Windowsフォームデザイナで生成されたコード
		// ===================================================================================== //
		#region Windows フォーム デザイナで生成されたコード 
		/// <summary>
		/// デザイナ サポートに必要なメソッドです。このメソッドの内容を
		/// コード エディタで変更しないでください。
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( MAKAU03000UB ) );
            this.PreviewBrowser = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // PreviewBrowser
            // 
            this.PreviewBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PreviewBrowser.Location = new System.Drawing.Point( 0, 0 );
            this.PreviewBrowser.MinimumSize = new System.Drawing.Size( 20, 20 );
            this.PreviewBrowser.Name = "PreviewBrowser";
            this.PreviewBrowser.Size = new System.Drawing.Size( 1000, 658 );
            this.PreviewBrowser.TabIndex = 0;
            this.PreviewBrowser.Visible = false;
            this.PreviewBrowser.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler( this.PreviewBrowser_PreviewKeyDown );
            // 
            // MAKAU03000UB
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size( 7, 15 );
            this.BackColor = System.Drawing.Color.FromArgb( ((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))) );
            this.ClientSize = new System.Drawing.Size( 1000, 658 );
            this.Controls.Add( this.PreviewBrowser );
            this.Font = new System.Drawing.Font( "MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)) );
            this.Icon = ((System.Drawing.Icon)(resources.GetObject( "$this.Icon" )));
            this.Name = "MAKAU03000UB";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler( this.MAKAU03000UB_FormClosed );
            this.ResumeLayout( false );

		}
		#endregion
	
		// ===================================================================================== //
		// 内部変数
		// ===================================================================================== //
		#region Private member
		private bool _isSave       　   = false;
		private string _printKey        = string.Empty;			// 帳票KEY
		private string _printName       = string.Empty;			// 帳票名
		private string _printDetailName = string.Empty;
		private WebBrowser PreviewBrowser;			    // 帳票詳細名
        private string _printPDFPath = string.Empty;			// 帳票パス
        private const string BLANK = "about:blank";
		#endregion
		
		// ===================================================================================== //
		// プロパティ
		// ===================================================================================== //
		#region Public Property 
		/// <summary>履歴保存可能プロパティ</summary>
		public bool IsSave
		{
			get {return _isSave;}
			set {_isSave = value;}
		}
		
		/// <summary>帳票KEYプロパティ</summary>
		public string PrintKey
		{
			get {return _printKey;}
			set {_printKey = value;}
		}
		
		/// <summary>帳票名プロパティ</summary>
		public string PrintName
		{
			get {return _printName;}
			set {_printName = value;}
		}
		
		/// <summary>帳票名プロパティ</summary>
		public string PrintDetailName
		{
			get {return _printDetailName;}
			set {_printDetailName = value;}
		}
		
		/// <summary>PDFパスプロパティ</summary>
		public string PrintPDFPath
		{
			get {return _printPDFPath;}
			set {_printPDFPath = value;}
		}
		#endregion
		
		// ===================================================================================== //
		// Internal メソッド
		// ===================================================================================== //
		#region Internal Methods
		/// <summary>
		/// 画面表示処理
		/// </summary>
		/// <param name="parameter">タイトル</param>
		/// <remarks>
        /// <br>Note        : </br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/07</br>
		/// </remarks>
		internal void Show(object parameter)
		{
            
			this.Text = parameter.ToString();
			this.Show();
		}

		/// <summary>
		/// プレビューフォーム表示処理
		/// </summary>
		/// <param name="paramater">URL</param>
		/// <remarks>
        /// <br>Note        : 引数で渡されたURLを画面に表示します。</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/07</br>
		/// </remarks>
		internal void Navigate(object paramater)
		{
            // ※WebBrowserコントロールを直接使用する方式と変わらないので、封印（実装してあるだけ）
            this.PreviewBrowser.Visible = true;

			try
			{
				if (String.IsNullOrEmpty(paramater.ToString())) return;

                if (paramater.Equals(BLANK))
				{
                    this.PreviewBrowser.Navigate(new Uri(BLANK));
				}
				else
				{
                    this.PreviewBrowser.Navigate(new Uri(BLANK));
					this.PreviewBrowser.Navigate(new Uri(paramater.ToString()));
				}
			}
			catch (System.UriFormatException)
			{
				return;
			}
		}
		#endregion

        /// <summary>
        /// PreviewBrowser_PreviewKeyDown
        /// </summary>
        /// <param name="sender">オブジェクト</param>
        /// <param name="e">イベント</param>
        /// <remarks>
        /// <br>Note        : </br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private void PreviewBrowser_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            Debug.WriteLine(DateTime.Now.ToString() + ":" + e.KeyCode.ToString());
        }

        /// <summary>
        /// フォームクローズ処理
        /// </summary>
        /// <param name="sender">オブジェクト</param>
        /// <param name="e">イベント</param>
        /// <remarks>
        /// <br>Note        : フォームクローズ処理</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private void MAKAU03000UB_FormClosed( object sender, FormClosedEventArgs e )
        {
            try
            {
                // ブラウザを初期化
                PreviewBrowser.Navigate(BLANK);
                // ブラウザコントロールを明確に破棄する
                PreviewBrowser.Dispose();
                // 破棄の為の時間をシステムに与える
                System.Windows.Forms.Application.DoEvents();
            }
            finally
            {
                // 使用DLLを完全解放
                CoFreeUnusedLibraries();
            }
        }
	}
}

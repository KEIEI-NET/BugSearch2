//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : 請求書発行(総括)
// プログラム概要   : 請求書発行(総括)の印字を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30413 犬飼
// 作 成 日  2009/04/21  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 22018 鈴木 正臣
// 作 成 日  2010/11/02  修正内容 : Adobe Reader9以降だと終了時エラー発生する件の対応。(WebBrowser解放処理の修正)
//----------------------------------------------------------------------------//

using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Forms;
// --- ADD m.suzuki 2010/11/02 ---------->>>>>
using System.Runtime.InteropServices;
// --- ADD m.suzuki 2010/11/02 ----------<<<<<

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// 請求帳票プレビューＵＩクラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : 請求帳票のプレビューフォームを表示するクラスです。</br>
	/// <br>Programer  : 18012 Y.Sasaki</br>
	/// <br>Date       : 2005.08.11</br>
	/// <br>Update Date: xxxx.xx.xx</br>
	/// <br>Update Note: 2006.04.17 Y.Sasaki</br>
	/// <br>           : １.ＰＤＦ履歴保存機能追加に伴う修正</br>
	/// <br>Update Note: 2006.04.27 Y.Sasaki</br>
	/// <br>           : １.WebBrowseコンポーネント対応</br>
    /// -----------------------------------------------------------------------------------
    /// <br>UpdateNote : PM.NS対応</br>
    /// <br>Programmer : 30413 犬飼</br>
    /// <br>Date	   : 2008.09.04</br>
    /// <br></br>
    /// <br>Update Note: 2010/11/02  22018 鈴木 正臣</br>
    /// <br>           : Adobe Reader9以降だと終了時エラー発生する件の対応。(WebBrowser解放処理の修正)</br>
    /// </remarks>
	public class PMHNB02250UB : System.Windows.Forms.Form
	{
        // --- ADD m.suzuki 2010/11/02 ---------->>>>>
        [DllImport( "ole32.dll" )]
        extern static void CoFreeUnusedLibraries();
        // --- ADD m.suzuki 2010/11/02 ----------<<<<<

		/// <summary>
		/// 必要なデザイナ変数です。
		/// </summary>
		private System.ComponentModel.Container components = null;

        // ADD 2009/03/09 請求書系フレーム対応：PDFを一括表示 ---------->>>>>
        // ※WebBrowserコントロールを直接使用する方式と変わらないので、封印（実装してあるだけ）
        #region <PDF表示方式の別パターン/>

        ///// <summary>PDFビューワ</summary>
        //private DCCMN04000UB _pdfViewer;
        ///// <summary>
        ///// PDFビューワのアクセサ
        ///// </summary>
        //private DCCMN04000UB PDFViewer
        //{
        //    get { return _pdfViewer; }
        //    set { _pdfViewer = value; }
        //}

        #endregion  // <PDF表示方式の別パターン/>
        // ADD 2009/03/09 請求書系フレーム対応：PDFを一括表示 ----------<<<<<

		public PMHNB02250UB()
		{
			InitializeComponent();

            // ADD 2009/03/09 請求書系フレーム対応：PDFを一括表示 ---------->>>>>
            //// ※WebBrowserコントロールを直接使用する方式と変わらないので、封印（実装してあるだけ）
            //// PDF表示方式の変更用
            //PDFViewer = new DCCMN04000UB();
            //this.Controls.Add(PDFViewer);
            //this.PDFViewer.Dock = DockStyle.Fill;
            // ADD 2009/03/09 請求書系フレーム対応：PDFを一括表示 ----------<<<<<
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( PMHNB02250UB ) );
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
            // PMHNB02250UB
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size( 7, 15 );
            this.BackColor = System.Drawing.Color.FromArgb( ((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))) );
            this.ClientSize = new System.Drawing.Size( 1000, 658 );
            this.Controls.Add( this.PreviewBrowser );
            this.Font = new System.Drawing.Font( "MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)) );
            this.Icon = ((System.Drawing.Icon)(resources.GetObject( "$this.Icon" )));
            this.Name = "PMHNB02250UB";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler( this.PMHNB02250UB_FormClosed );
            this.ResumeLayout( false );

		}
		#endregion
	
		// ===================================================================================== //
		// 内部変数
		// ===================================================================================== //
		#region Private member
		private bool _isSave       　   = false;
		private string _printKey        = "";			// 帳票KEY
		private string _printName       = "";			// 帳票名
		private string _printDetailName = "";
		private WebBrowser PreviewBrowser;			    // 帳票詳細名
		private string _printPDFPath    = "";			// 帳票パス
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
		/// <br>Note       : </br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2005.08.09</br>
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
		/// <br>Note       : 引数で渡されたURLを画面に表示します。</br>
		/// <br>Programer  : 18012 Y.Sasaki</br>
		/// <br>Date       : 2006.04.27</br>
		/// </remarks>
		internal void Navigate(object paramater)
		{
            // ADD 2009/03/09 請求書系フレーム対応：PDFを一括表示 ---------->>>>>
            // ※WebBrowserコントロールを直接使用する方式と変わらないので、封印（実装してあるだけ）
        #if USING_PDF_VIEWER
            //// PDF表示方式の変更用
            //PDFViewer.PDFShow(paramater.ToString());
        #else
            this.PreviewBrowser.Visible = true;
        #endif
            // ADD 2009/03/09 請求書系フレーム対応：PDFを一括表示 ----------<<<<<

			try
			{
				if (String.IsNullOrEmpty(paramater.ToString())) return;

				if (paramater.Equals("about:blank"))
				{
					this.PreviewBrowser.Navigate(new Uri("about:blank"));
				}
				else
				{
					this.PreviewBrowser.Navigate(new Uri("about:blank"));
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
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PreviewBrowser_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            Debug.WriteLine(DateTime.Now.ToString() + ":" + e.KeyCode.ToString());
        }

        // --- ADD m.suzuki 2010/11/02 ---------->>>>>
        /// <summary>
        /// フォームクローズ処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PMHNB02250UB_FormClosed( object sender, FormClosedEventArgs e )
        {
            try
            {
                // ブラウザを初期化
                PreviewBrowser.Navigate( "about:blank" );
                // ブラウザコントロールを明確に破棄する
                PreviewBrowser.Dispose();
                // 破棄の為の時間をシステムに与える
                System.Windows.Forms.Application.DoEvents();
            }
            finally
            {
                //  使用DLLを完全解放
                CoFreeUnusedLibraries();
            }
        }
        // --- ADD m.suzuki 2010/11/02 ----------<<<<<
    }
}

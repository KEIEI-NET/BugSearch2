#define REP20060427
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
// --- ADD m.suzuki 2010/11/02 ---------->>>>>
using System.Runtime.InteropServices;
// --- ADD m.suzuki 2010/11/02 ----------<<<<<

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// マスタエクスポート・インポートプレビューＵＩクラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : マスタエクスポート・インポートのプレビューフォームを表示するクラスです。</br>
	/// <br>Programer  : 30462 行澤 仁美</br>
	/// <br>Date       : 2008.10.24</br>
    /// <br></br>
    /// <br>Update Note: 2010/11/02  22018 鈴木 正臣</br>
    /// <br>           : Adobe Reader9以降だと終了時エラー発生する件の対応。(WebBrowser解放処理の修正)</br>
    /// </remarks>
	public class PMKHN08500UB : System.Windows.Forms.Form
	{
        // --- ADD m.suzuki 2010/11/02 ---------->>>>>
        [DllImport( "ole32.dll" )]
        extern static void CoFreeUnusedLibraries();
        // --- ADD m.suzuki 2010/11/02 ----------<<<<<

		/// <summary>
		/// 必要なデザイナ変数です。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public PMKHN08500UB()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( PMKHN08500UB ) );
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
            // 
            // PMKHN08500UB
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size( 7, 15 );
            this.BackColor = System.Drawing.Color.FromArgb( ((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))) );
            this.ClientSize = new System.Drawing.Size( 1000, 658 );
            this.Controls.Add( this.PreviewBrowser );
            this.Font = new System.Drawing.Font( "MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)) );
            this.Icon = ((System.Drawing.Icon)(resources.GetObject( "$this.Icon" )));
            this.Name = "PMKHN08500UB";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler( this.PMKHN08500UB_FormClosed );
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
		/// <br>Programmer : 30462 行澤 仁美</br>
		/// <br>Date       : 2008.10.24</br>
		/// </remarks>
		internal void Show(object parameter)
		{
            
			this.Text = parameter.ToString();
			this.Show();
		}

#if REP20060427 
		/// <summary>
		/// プレビューフォーム表示処理
		/// </summary>
		/// <param name="paramater">URL</param>
		/// <remarks>
		/// <br>Note       : 引数で渡されたURLを画面に表示します。</br>
		/// <br>Programer  : 30462 行澤 仁美</br>
		/// <br>Date       : 2008.10.24</br>
		/// </remarks>
		internal void Navigate(object paramater)
		{
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

        // --- ADD m.suzuki 2010/11/02 ---------->>>>>
        /// <summary>
        /// フォームクローズ処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PMKHN08500UB_FormClosed( object sender, FormClosedEventArgs e )
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
#else
		/// <summary>
		/// プレビューフォーム表示処理
		/// </summary>
		/// <param name="parameter">URL</param>
		/// <remarks>
		/// <br>Note       : 引数で渡されたURLを画面に表示します。</br>
		/// <br>Programer  : 30462 行澤 仁美</br>
		/// <br>Date       : 2008.10.24</br>
		/// </remarks>
		internal void ShowPDFPreview(object parameter)
		{
			try
			{
				// 現在表示内容をクリア
				object obj = null;
				PreviewBrowser.Navigate("about:blank", ref obj, ref obj, ref obj, ref obj);

				if (parameter != null && parameter.ToString() != "")
				{
					// 引数を定義します。
					object obj1 = 8;
					object obj2 = "_self";
					// ブラウザで表示を行います。
				
					PreviewBrowser.Navigate2(ref parameter, ref obj1, ref obj2, ref obj, ref obj);
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message,"エラー");
			}
		}
#endif
		#endregion
	}
}

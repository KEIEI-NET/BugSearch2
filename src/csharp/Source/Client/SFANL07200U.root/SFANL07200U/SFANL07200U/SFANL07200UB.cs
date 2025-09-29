#define REP20060427
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Common;
// --- ADD m.suzuki 2010/11/02 ---------->>>>>
using System.Runtime.InteropServices;
// --- ADD m.suzuki 2010/11/02 ----------<<<<<

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 帳票共通ビューフォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 帳票共通のビューフォームクラスです。</br>
    /// <br>Programmer : 18012 Y.Sasaki</br>
    /// <br>Date       : 2005.01.19</br>
    /// <br>Update Note: 2006.04.27 Y.Sasaki</br>
    /// <br>           : １.WebBrowseコンポーネント対応</br>
    /// <br>Update Note: 2010/11/02  22018 鈴木 正臣</br>
    /// <br>           : Adobe Reader9以降だと終了時エラー発生する件の対応。(WebBrowser解放処理の修正)</br>
    /// </remarks>
    public class SFANL07200UB : System.Windows.Forms.Form
	{
        // --- ADD m.suzuki 2010/11/02 ---------->>>>>
        [DllImport( "ole32.dll" )]
        extern static void CoFreeUnusedLibraries();
        // --- ADD m.suzuki 2010/11/02 ----------<<<<<


    # region Private Members (Component)

		/// <summary>
		/// 必要なデザイナ変数です。
		/// </summary>
		private System.ComponentModel.Container components = null;
    #endregion

    // ===================================================================================== //
    // コンストラクタ
    // ===================================================================================== //
    # region Constructor
    public SFANL07200UB()
		{
			//
			// Windows フォーム デザイナ サポートに必要です。
			//
			InitializeComponent();

			//
			// TODO: InitializeComponent 呼び出しの後に、コンストラクタ コードを追加してください。
			//
		}
    #endregion

    // ===================================================================================== //
    // 破棄
    // ===================================================================================== //
    #region Dispose
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
            this.PreviewBrowser = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // PreviewBrowser
            // 
            this.PreviewBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PreviewBrowser.Location = new System.Drawing.Point( 0, 0 );
            this.PreviewBrowser.MinimumSize = new System.Drawing.Size( 20, 20 );
            this.PreviewBrowser.Name = "PreviewBrowser";
            this.PreviewBrowser.Size = new System.Drawing.Size( 1016, 734 );
            this.PreviewBrowser.TabIndex = 0;
            // 
            // SFANL07200UB
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size( 8, 15 );
            this.BackColor = System.Drawing.Color.FromArgb( ((int)(((byte)(198)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))) );
            this.ClientSize = new System.Drawing.Size( 1016, 734 );
            this.Controls.Add( this.PreviewBrowser );
            this.Font = new System.Drawing.Font( "ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)) );
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SFANL07200UB";
            this.Text = "SFANL07200UB";
            this.Activated += new System.EventHandler( this.SFANL07200UB_Activated );
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler( this.SFANL07200UB_FormClosed );
            this.ResumeLayout( false );

		}
		#endregion
	
		//================================================================================
		//  内部変数
		//================================================================================
		#region private member
		private bool _isSave       　   = false;
		private string _printKey        = "";			// 帳票KEY
		private string _printName       = "";			// 帳票名
		private string _printDetailName = "";
		private WebBrowser PreviewBrowser;			// 帳票詳細名
		private string _printPDFPath    = "";			// 帳票パス
		private string _formControlInfoKey = "";
		#endregion
		
		//================================================================================
		//  プロパティ
		//================================================================================
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
			get { return _printPDFPath; }
			set { _printPDFPath = value; }
		}

		/// <summary>帳票共通用フォームコントロール用キープロパティ</summary>
		public string FormControlInfoKey
		{
			get { return _formControlInfoKey; }
			set { _formControlInfoKey = value; }
		}
		#endregion
		
		// ===================================================================================== //
    // 内部メソッド
    // ===================================================================================== //
    #region private methods
    /// <summary>
    /// エラーメッセージ表示
    /// </summary>
    /// <param name="iLevel">エラーレベル</param>
    /// <param name="iMsg">エラーメッセージ</param>
    /// <param name="iSt">エラーステータス</param>
    /// <param name="iButton">表示ボタン</param>
    /// <param name="iDefButton">初期フォーカスボタン</param>
    /// <returns>DialogResult</returns>
    /// <remarks>
    /// <br>Note       : エラーメッセージを表示します。</br>
    /// <br>Programmer : 18012 Y.Sasaki</br>
    /// <br>Date       : 2006.01.19</br>
    /// </remarks>
    private DialogResult TMessageBox(emErrorLevel iLevel, string iMsg, int iSt, MessageBoxButtons iButton, MessageBoxDefaultButton iDefButton)
    {
      return TMsgDisp.Show(iLevel, "SFUKK06180U", iMsg, iSt, iButton, iDefButton);
    }
    #endregion
  
    // ===================================================================================== //
    // Internalイベント
    // ===================================================================================== //
    #region internal event
    /// <summary>
    /// ツールバー表示制御イベント
    /// </summary>
    internal event ParentToolbarSettingEventHandler ParentToolbarSettingEvent;        
    #endregion

    // ===================================================================================== //
    // Internalメソッド
    // ===================================================================================== //
    #region internal methods
    
#if REP20060427
		/// <summary>
		/// プレビューフォーム表示処理
		/// </summary>
		/// <param name="parameter">URL</param>
		/// <remarks>
		/// <br>Note       : 引数で渡されたURLを画面に表示します。</br>
		/// <br>Programer  : 18012 Y.Sasaki</br>
		/// <br>Date       : 2006.04.27</br>
		/// </remarks>
		public void ShowPDFPreview(object paramater)
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
			catch (Exception ex)
			{
				TMessageBox(emErrorLevel.ERR_LEVEL_STOPDISP,
					ex.Message, -1, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
			}
		}
#else
		/// <summary>
    /// プレビューフォーム表示処理
    /// </summary>
    /// <param name="parameter">URL</param>
    /// <remarks>
    /// <br>Note       : 引数で渡されたURLを画面に表示します。</br>
    /// <br>Programer  : 18012 Y.Sasaki</br>
    /// <br>Date       : 2006.01.19</br>
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
        TMessageBox(emErrorLevel.ERR_LEVEL_STOPDISP,
          ex.Message, -1, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
      }
    }
#endif
    #endregion

    // ===================================================================================== //
    // コントロールイベント
    // ===================================================================================== //
    #region control event        
    /// <summary>
    /// Control.Activatedイベント
    /// </summary>
    /// <param name="sender">イベントソース</param>
    /// <param name="e">イベントデータ</param>
    /// <remarks>
    /// <br>Note        : フォームがアクティブにされた時に発生します。</br>
    /// <br>Programmer  : 18012 Y.Sasaki</br>
    /// <br>Date        : 2006.01.19</br>
    /// </remarks>
		private void SFANL07200UB_Activated(object sender, System.EventArgs e)
		{
			ParentToolbarSettingEvent(this);
		}
    #endregion


        // --- ADD m.suzuki 2010/11/02 ---------->>>>>
        /// <summary>
        /// フォームクローズ処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SFANL07200UB_FormClosed( object sender, FormClosedEventArgs e )
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

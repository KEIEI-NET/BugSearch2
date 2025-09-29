using System;
using System.Data;
using System.Collections.Generic;
using System.Configuration;
using System.ComponentModel;
using System.Globalization;
using System.Security.Permissions;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.Design.WebControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace Broadleaf.Web.UI.WebControls
{
	/// <summary>
	/// ページ管理コントロール
	/// </summary>
	/// <remarks>
	/// <br>Note       : ページの管理を行います。</br>
	/// <br>Programmer : 23001 秋山　亮介</br>
	/// <br>Date       : 2007.03.19</br>
	/// </remarks>
	[AspNetHostingPermission( SecurityAction.Demand, Level=AspNetHostingPermissionLevel.Minimal )]
	[AspNetHostingPermission( SecurityAction.InheritanceDemand, Level=AspNetHostingPermissionLevel.Minimal )]
	[DefaultProperty( "TotalPageCount" )]
	[ToolboxData( "<{0}:PagingControl runat=\"server\" />" )]
	public class PagingManageControl : WebControl, IPostBackEventHandler
	{
		#region << Constructor >>

		/// <summary>
		/// ページ管理コントロールコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : ページ管理コントロールの新しいインスタンスを初期化します。</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2007.03.19</br>
		/// </remarks>
		public PagingManageControl() : base( HtmlTextWriterTag.Div )
		{
		}

		#endregion

		#region << Private Members >>

		/// <summary>イベント判別キー</summary>
		private static readonly object EventPageChanged = new object();

		#endregion

		#region << Public Properties >>

		/// <summary>
		/// 総ページ数プロパティ
		/// </summary>
		/// <value>表示する総ページ数を取得または設定します。</value>
		[Bindable( true )]
		[Category( "表示" )]
		[DefaultValue( 0 )]
		[Localizable( true )]
		public virtual int TotalPageCount
		{
			get {
				object obj = ViewState[ "TotalPageCount" ];
				return ( obj == null ? 0 : ( int )obj );
			}
			set {
				this.ViewState[ "TotalPageCount" ] = value;
			}
		}

		/// <summary>
		/// 現在ページインデックスプロパティ
		/// </summary>
		/// <value>現在のページのインデックスを取得または設定します。</value>
		[Bindable( true )]
		[Category( "表示" )]
		[DefaultValue( 0 )]
		[Localizable( true )]
		public virtual int CurrentPageIndex
		{
			get {
				object obj = ViewState[ "CurrentPageIndex" ];
				return ( obj == null ? 0 : ( int )obj );
			}
			set {
				this.ViewState[ "CurrentPageIndex" ] = value;
			}
		}

		/// <summary>
		/// 前のページ移動リンクテキストプロパティ
		/// </summary>
		/// <value>前のページへ移動するリンクの表示テキストを取得または設定します。</value>
		[Bindable( true )]
		[Category( "表示" )]
		[DefaultValue( "前へ" )]
		[Localizable( true )]
		public virtual string PrevPageLinkText
		{
			get {
				object obj = ViewState[ "PrevPageLinkText" ];
				return ( obj == null ? "前へ" : ( string )obj );
			}
			set {
				this.ViewState[ "PrevPageLinkText" ] = value;
			}
		}

		/// <summary>
		/// 次のページ移動リンクテキストプロパティ
		/// </summary>
		/// <value>次のページへ移動するリンクの表示テキストを取得または設定します。</value>
		[Bindable( true )]
		[Category( "表示" )]
		[DefaultValue( "次へ" )]
		[Localizable( true )]
		public virtual string NextPageLinkText
		{
			get {
				object obj = ViewState[ "NextPageLinkText" ];
				return ( obj == null ? "次へ" : ( string )obj );
			}
			set {
				this.ViewState[ "NextPageLinkText" ] = value;
			}
		}

		#endregion

		#region << Public Events >>

		/// <summary>ページ変更イベント</summary>
		public event PageChangedEventHandler PageChanged
		{
			add {
				base.Events.AddHandler( EventPageChanged, value );
			}
			remove {
				base.Events.RemoveHandler( EventPageChanged, value );
			}
		}

		#endregion

		#region << Private Methods >>

		#region ■各ページリンクテキスト作成処理

		/// <summary>
		/// 各ページリンクテキスト作成処理
		/// </summary>
		/// <param name="eventArgument">ポストバックイベント時のパラメータ</param>
		/// <param name="linkText">リンクに表示するテキスト</param>
		/// <param name="title">リンクのタイトル</param>
		/// <param name="showLink">リンクを表示するかどうか</param>
		/// <returns>各ページへのリンクテキスト</returns>
		/// <remarks>
		/// <br>Note       : 各ページへのリンクテキストの作成を行います。</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2007.03.19</br>
		/// </remarks>
		private string CreatePageText( string eventArgument, string linkText, string title, bool showLink )
		{
			if( ! showLink ) {
				return linkText;
			}

			// リンクテキストを以下のように作成
			// <a href="javascript: window.scrollTo( 0, 0 );[PostBackスクリプト]" title="[title]">[linkText]</a>
 
			StringBuilder pageText = new StringBuilder();
			pageText.Append( "<a href=\"javascript: window.scrollTo( 0, 0 );" );
			pageText.Append( this.Page.ClientScript.GetPostBackClientHyperlink( this, eventArgument, false ) );
			if( ! String.IsNullOrEmpty( title ) ) {
				pageText.Append( "\" title=\"" );
				pageText.Append( title );
			}
			pageText.Append( "\" tabindex=\"99\" >" );
			pageText.Append( linkText );
			pageText.Append( "</a>" );

			return pageText.ToString();
		}

		#endregion

		#endregion

		#region << Protected Methods >>

		#region ■PageChanged イベント発生処理

		/// <summary>
		/// PageChanged イベント発生処理
		/// </summary>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : PageChanged イベントを発生させます。</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2007.03.20</br>
		/// </remarks>
		protected virtual void OnPageChanged( PageChangedEventArgs e )
		{
			PageChangedEventHandler handler = ( PageChangedEventHandler )base.Events[ EventPageChanged ];
			if( handler != null ) {
				handler( this, e );
			}
		}

		#endregion

		#region ■AddAttributesToRender メソッド

		/// <summary>
		/// AddAttributesToRender メソッド
		/// </summary>
		/// <param name="writer">HTML コンテンツをクライアントに表示する出力ストリームを表す HtmlTextWriter。</param>
		/// <remarks>
		/// <br>Note       : 指定した HtmlTextWriterTag に表示する必要のある HTML 属性およびスタイルを追加します。</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2007.03.20</br>
		/// </remarks>
		protected override void AddAttributesToRender( HtmlTextWriter writer )
		{
			if( this.Page != null ) {
				this.Page.VerifyRenderingInServerForm( this );
			}

			bool isEnabled = base.IsEnabled;

			if( Enabled && !isEnabled ) {
				writer.AddAttribute( HtmlTextWriterAttribute.Disabled, "disabled" );
			}
			base.AddAttributesToRender( writer );
		}

		#endregion

		#region ■RenderContents メソッド

		/// <summary>
		/// RenderContents メソッド
		/// </summary>
		/// <param name="writer">HTML コンテンツをクライアントに表示する出力ストリームを表す HtmlTextWriter。</param>
		/// <remarks>
		/// <br>Note       : コントロールの内容を指定したライタに出力します。</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2007.03.20</br>
		/// </remarks>
		protected override void RenderContents( HtmlTextWriter writer )
		{
			base.RenderContents( writer );

			// ページングの必要が無い場合は処理を終了
			if( this.TotalPageCount <= 1 ) {
				return;
			}

			// 2ページ目以降の場合
			if( this.CurrentPageIndex > 0 ) {
				// 「前へ」を書き込み

				string argument = "P" + ( this.CurrentPageIndex - 1 ).ToString( CultureInfo.InvariantCulture );
				writer.Write( this.CreatePageText( argument, this.PrevPageLinkText, "前のページへ移動します", true ) );

				// 空白を挿入
				writer.Write( "&nbsp;" );
			}

			for( int ix = 0; ix < this.TotalPageCount; ix++ ) {
				if( ix > 0 ) {
					// 空白を挿入
					writer.Write( "&nbsp;" );
				}

				string argument = "P" + ix.ToString( CultureInfo.InvariantCulture );
				string pageText = ( ix + 1 ).ToString();
				writer.Write( this.CreatePageText( argument, pageText, pageText + "ページへ移動します", ix != this.CurrentPageIndex ) );
			}

			// 最終ページではない場合
			if( this.CurrentPageIndex < this.TotalPageCount - 1 ) {
				// 「次へ」を書き込み

				// 空白を挿入
				writer.Write( "&nbsp;" );

				string argument = "P" + ( this.CurrentPageIndex + 1 ).ToString( CultureInfo.InvariantCulture );
				writer.Write( this.CreatePageText( argument, this.NextPageLinkText, "次のページへ移動します", true ) );
			}
		}

		#endregion

		#endregion

		#region << Public Methods >>

		#region ■RaisePostBackEvent メソッド

		/// <summary>
		/// RaisePostBackEvent メソッド
		/// </summary>
		/// <param name="eventArgument">イベント ハンドラに渡される省略可能なイベント引数を表す String。</param>
		/// <remarks>
		/// <br>Note       : フォームがサーバーにポストされたときに発生するイベントをサーバー コントロールで処理できるようにします。</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2007.03.20</br>
		/// </remarks>
		public void  RaisePostBackEvent( string eventArgument )
		{
			// PostBack パラメータから、移動ページを取得
			if( String.Compare( eventArgument, 0, "P", 0, 1, StringComparison.Ordinal ) == 0 ) {
				int currentPageIndex  = Int32.Parse( eventArgument.Substring( 1 ), CultureInfo.InvariantCulture );
				this.CurrentPageIndex = currentPageIndex;

				// PageChanged イベントを発生
 				this.OnPageChanged( new PageChangedEventArgs( this.CurrentPageIndex, this.TotalPageCount ) );
			}
		}

		#endregion

		#endregion

		#region << IPostBackEventHandler メンバ >>

		#region ■IPostBackEventHandler.RaisePostBackEvent メソッド

		/// <summary>
		/// IPostBackEventHandler.RaisePostBackEvent メソッド
		/// </summary>
		/// <param name="eventArgument">イベント ハンドラに渡される省略可能なイベント引数を表す String。</param>
		/// <remarks>
		/// <br>Note       : フォームがサーバーにポストされたときに発生するイベントをサーバー コントロールで処理できるようにします。</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2007.03.20</br>
		/// </remarks>
		void IPostBackEventHandler.RaisePostBackEvent( string eventArgument )
		{
			this.RaisePostBackEvent( eventArgument );
		}

		#endregion

		#endregion

	}

	/// <summary>
	/// ページ変更イベントハンドラ
	/// </summary>
	/// <param name="sender">対象オブジェクト</param>
	/// <param name="e">イベントパラメータ</param>
	/// <remarks>
	/// <br>Note       : ページが変更されたときに発生します。</br>
	/// <br>Programmer : 23001 秋山　亮介</br>
	/// <br>Date       : 2007.03.20</br>
	/// </remarks>
	public delegate void PageChangedEventHandler( object sender, PageChangedEventArgs e );

	/// <summary>
	/// ページ変更イベントパラメータクラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : PageChanged のイベントのデータを提供します。 </br>
	/// <br>Programmer : 23001 秋山　亮介</br>
	/// <br>Date       : 2007.03.20</br>
	/// </remarks>
	public class PageChangedEventArgs : EventArgs
	{
		#region << Constructor >>

		/// <summary>
		/// ページ変更イベントパラメータクラスコンストラクタ
		/// </summary>
		/// <param name="currentPageIndex">現在ページインデックス</param>
		/// <param name="totalPageCount">総ページ数</param>
		/// <remarks>
		/// <br>Note       : ページ変更イベントパラメータクラスの新しいインスタンスを初期化します。</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2007.03.20</br>
		/// </remarks>
		public PageChangedEventArgs( int currentPageIndex, int totalPageCount )
		{
			this._currentPageIndex = currentPageIndex;
			this._totalPageCount   = totalPageCount;
		}

		#endregion

		#region << Private Members >>

		/// <summary>現在ページインデックス</summary>
		private readonly int _currentPageIndex;
		/// <summary>総ページ数</summary>
		private readonly int _totalPageCount;

		#endregion

		#region << Public Properties >>

		/// <summary>
		/// 現在ページインデックス
		/// </summary>
		public int CurrentPageIndex
		{
			get {
				return this._currentPageIndex;
			}
		}

		/// <summary>
		/// 総ページ数
		/// </summary>
		public int TotalPageCount
		{
			get {
				return this._totalPageCount;
			}
		}

		#endregion
	}
}
using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.UI;

namespace Broadleaf.Application.Common
{
	/// <summary>
	/// クエリ文字列制御クラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : クエリ文字列の制御を行います。</br>
	/// <br>Programmer : 23001 秋山　亮介</br>
	/// <br>Date       : 2007.03.05</br>
	/// <br>Update     : 2007.12.06  Kouguchi  新レイアウト対応</br>
	/// </remarks>
	public class QueryStringController
	{
		#region << Constructor >>

		/// <summary>
		/// クエリ文字列制御クラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : クエリ文字列制御クラスの新しいインスタンスを初期化します。</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2007.03.05</br>
		/// </remarks>
		public QueryStringController() : this( null )
		{
		}

		/// <summary>
		/// クエリ文字列制御クラスコンストラクタ
		/// </summary>
		/// <param name="request">HTTPリクエスト</param>
		/// <remarks>
		/// <br>Note       : クエリ文字列制御クラスの新しいインスタンスを初期化します。新しいインスタンスは、指定されたリクエストで初期化されます。</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2007.03.05</br>
		/// </remarks>
		public QueryStringController( HttpRequest request )
		{
			// クリア
			this.Clear();

			// クエリをセット
			this.SetQueryString( request );
		}

		#endregion



		#region << Private Members >>

		// 配信・メンテ共通
		/// <summary>アクセスチケット</summary>
		private string _accessTicket       = null;
		
		// 配信
		/// <summary>配信バージョン</summary>
		private string _multicastVersion   = null;
		/// <summary>配信連番</summary>
		private int?   _multicastConsNo    = null;

        //Add ↓↓↓ 2007.12.06 Kouguchi
		/// <summary>案内区分</summary>
		private int?   _mcastGidncCntntsCd    = null;
		/// <summary>システム区分</summary>
		private int?   _systemDivCd    = null;
		/// <summary>変更有無</summary>
		private string  _ctCHG        = null;
        //Add ↑↑↑ 2007.12.06 Kouguchi

        //Del ↓↓↓ 2007.12.06 Kouguchi
        //// メンテ
		///// <summary>サーバーメンテナンス連番</summary>
		//private int?   _serverMainteConsNo = null;
        //Del ↑↑↑ 2007.12.06 Kouguchi

		#endregion



		#region << Public Constant >>

		/// <summary>アクセスチケット キー</summary>
		public const string ctAccessTicketKey       = "TICKET";
		/// <summary>配信バージョン キー</summary>
		public const string ctMulticastVersionKey   = "mltcstVer";
		/// <summary>配信連番 キー</summary>
		public const string ctMulticastConsNoKey    = "mltcstCnsNo";

        //Add ↓↓↓ 2007.12.06 Kouguchi
        /// <summary>案内区分 キー</summary>
		public const string ctMcastGidncCntntsCdKey = "mcstGiCntCd";
		/// <summary>システム区分 キー</summary>
		public const string ctSystemDivCdKey        = "sysDivCd";
		/// <summary>変更有無 キー</summary>
		public const string ctCHG        = "CHG";
        //Add ↑↑↑ 2007.12.06 Kouguchi



        //Del ↓↓↓ 2007.12.06 Kouguchi
        ///// <summary>サーバーメンテナンス連番 キー</summary>
        //public const string ctServerMainteConsNoKey = "svrMntCnsNo";
        //Del ↑↑↑ 2007.12.06 Kouguchi

		#endregion



		#region << Public Properties >>

		/// <summary>
		/// アクセスチケット
		/// </summary>
		/// <value>アクセスチケットを取得または設定します。nullは値が設定されていないことを表します。</value>
		public string AccessTicket 
        {
			get { return this._accessTicket; }
			set { this._accessTicket = value; }
		}

		/// <summary>
		/// 配信バージョン
		/// </summary>
		/// <value>配信バージョンを取得または設定します。nullは値が設定されていないことを表します。</value>
		public string MulticastVersion 
        {
			get { return this._multicastVersion; }
			set { this._multicastVersion = value; }
		}

		/// <summary>
		/// 配信連番
		/// </summary>
		/// <value>配信連番を取得または設定します。nullは値が設定されていないことを表します。</value>
		public int? MulticastConsNo 
        {
			get { return this._multicastConsNo; }
			set { this._multicastConsNo = value; }
		}

        //Add ↓↓↓ 2007.12.06 Kouguchi
        /// <summary>
		/// 案内区分
		/// </summary>
		/// <value>案内区分を取得または設定します。nullは値が設定されていないことを表します。</value>
		public int? McastGidncCntntsCd 
        {
			get { return this._mcastGidncCntntsCd; }
			set { this._mcastGidncCntntsCd = value; }
		}

		/// <summary>
		/// システム区分
		/// </summary>
		/// <value>システム区分を取得または設定します。nullは値が設定されていないことを表します。</value>
		public int? SystemDivCd 
        {
			get { return this._systemDivCd; }
			set { this._systemDivCd = value; }
		}

		/// <summary>
		/// 変更有無
		/// </summary>
		/// <value>変更有無を取得または設定します。nullは値が設定されていないことを表します。</value>
		public string CtCHG 
        {
			get { return this._ctCHG; }
			set { this._ctCHG = value; }
		}
        //Add ↑↑↑ 2007.12.06 Kouguchi

        //Del ↓↓↓ 2007.12.06 Kouguchi
        ///// <summary>
        ///// サーバーメンテナンス連番
        ///// </summary>
        ///// <value>サーバーメンテナンス連番を取得または設定します。nullは値が設定されていないことを表します。</value>
        //public int? ServerMainteConsNo {
        //    get {
        //        return this._serverMainteConsNo;
        //    }
        //    set {
        //        this._serverMainteConsNo = value;
        //    }
        //}
        //Del ↑↑↑ 2007.12.06 Kouguchi

		#endregion



		#region << Public Methods >>

		#region ■クエリクリア処理

		/// <summary>
		/// クエリクリア処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : クエリのクリアを行います。</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2007.03.05</br>
		/// </remarks>
		public void Clear()
		{
			this._accessTicket          = null;
            this._multicastVersion      = null;
			this._multicastConsNo       = null;

            //Add ↓↓↓ 2007.12.06 Kouguchi
            this._mcastGidncCntntsCd    = null;
			this._systemDivCd           = null;
            this._ctCHG                 = null;
            //Add ↑↑↑ 2007.12.06 Kouguchi

            //this._serverMainteConsNo = null;  //Del 2007.12.06 Kouguchi
		}

		#endregion

		#region ■クエリ文字列設定処理

		/// <summary>
		/// クエリ文字列設定処理
		/// </summary>
		/// <param name="request">HTTPリクエスト</param>
		/// <remarks>
		/// <br>Note       : HTTPリクエストから、クエリ文字列値を設定します。</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// </remarks>
		public void SetQueryString( HttpRequest request )
		{
			// 値をクリア
			this.Clear();

			if( request == null ) {
				// null 以下の処理を行わない
				return;
			}

			try {
				// アクセスチケット
				this._accessTicket       = request.QueryString[ ctAccessTicketKey ];

				// 配信バージョン
				this._multicastVersion   = ( request.QueryString[ ctMulticastVersionKey ] == null ? null : HttpUtility.UrlDecode( request.QueryString[ ctMulticastVersionKey ] as string ) ) ;

				// 配信連番
				if( !String.IsNullOrEmpty( request.QueryString[ ctMulticastConsNoKey ] ) ) 
                {
					// 数値へ変換
					int multicastConsNo = 0;
					if( Int32.TryParse( request.QueryString[ ctMulticastConsNoKey ], out multicastConsNo ) ) 
                    {
						// 変換成功
						this._multicastConsNo = multicastConsNo;
					}
					else 
                    {
						// 変換失敗
						this._multicastConsNo = null;
					}
				}

                //Add ↓↓↓ 2007.12.06 Kouguchi
                // 案内区分
				if( !String.IsNullOrEmpty( request.QueryString[ ctMcastGidncCntntsCdKey ] ) ) 
                {
					// 数値へ変換
					int mcastGidncCntntsCd = 0;
					if( Int32.TryParse( request.QueryString[ ctMcastGidncCntntsCdKey ], out mcastGidncCntntsCd ) ) 
                    {
						// 変換成功
						this._mcastGidncCntntsCd = mcastGidncCntntsCd;
					}
					else 
                    {
						// 変換失敗
						this._mcastGidncCntntsCd = null;
					}
				}

                // システム区分
				if( !String.IsNullOrEmpty( request.QueryString[ ctSystemDivCdKey ] ) ) 
                {
					// 数値へ変換
					int systemDivCd = 0;
					if( Int32.TryParse( request.QueryString[ ctSystemDivCdKey ], out systemDivCd ) ) 
                    {
						// 変換成功
						this._systemDivCd = systemDivCd;
					}
					else 
                    {
						// 変換失敗
						this._systemDivCd = null;
					}
				}

				// 変更有無
				this._ctCHG       = request.QueryString[ ctCHG ];
                //Add ↑↑↑ 2007.12.06 Kouguchi


                //Del ↓↓↓ 2007.12.06 Kouguchi
                //// メンテナンス連番
                //if( !String.IsNullOrEmpty( request.QueryString[ ctServerMainteConsNoKey ] ) ) {
                //    // 数値へ変換
                //    int serverMainteConsNo = 0;
                //    if( Int32.TryParse( request.QueryString[ ctServerMainteConsNoKey ], out serverMainteConsNo ) ) {
                //        // 変換成功
                //        this._serverMainteConsNo = serverMainteConsNo;
                //    }
                //    else {
                //        // 変換失敗
                //        this._serverMainteConsNo = null;
                //    }
				//}
                //Del ↑↑↑ 2007.12.06 Kouguchi
			}
			catch {
			}
			finally {
			}
		}

		#endregion

		#region ■クエリ文字列取得処理

		/// <summary>
		/// クエリ文字列取得処理
		/// </summary>
		/// <returns>クエリ文字列</returns>
		/// <remarks>
		/// <br>Note       : クエリ文字列の取得を行います。</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2007.03.05</br>
		/// </remarks>
		public string GetQueryString()
		{
			StringBuilder queryString = new StringBuilder();

			// アクセスチケット
			if( this._accessTicket != null ) 
            {
				this.AddQueryString( queryString, ctAccessTicketKey, this._accessTicket );
			}

			// 配信バージョン
			if( this._multicastVersion != null ) 
            {
				this.AddQueryString( queryString, ctMulticastVersionKey, this._multicastVersion );
			}

			// 配信連番
			if( this._multicastConsNo != null ) 
            {
				this.AddQueryString( queryString, ctMulticastConsNoKey, this._multicastConsNo );
			}

            //Add ↓↓↓ 2007.12.06 Kouguchi
			// 案内区分
			if( this._mcastGidncCntntsCd != null ) 
            {
				this.AddQueryString( queryString, ctMcastGidncCntntsCdKey, this._mcastGidncCntntsCd );
			}
			// システム区分
			if( this._systemDivCd != null ) 
            {
				this.AddQueryString( queryString, ctSystemDivCdKey, this._systemDivCd );
			}
			// 変更案内
			if( this._ctCHG != null )
            { 
				this.AddQueryString( queryString, ctCHG, this._ctCHG ); 
			} 
            //Add ↑↑↑ 2007.12.06 Kouguchi

            //Del ↓↓↓ 2007.12.06 Kouguchi
            //// メンテナンス連番
            //if( this._serverMainteConsNo != null ) {
            //    this.AddQueryString( queryString, ctServerMainteConsNoKey, this._serverMainteConsNo );
            //}
            //Del ↑↑↑ 2007.12.06 Kouguchi

			return queryString.ToString();
		}

		#endregion

		#region ■ToString()

		/// <summary>
		/// 現在の <see cref="QueryStringController" /> を表す System.String を返します。
		/// </summary>
		/// <returns>現在の <see cref="QueryStringController" /> を表す System.String 。</returns>
		public override string ToString()
		{
			return this.GetQueryString();
		}

		#endregion

		#endregion



		#region << Private Methods >>

		#region ■クエリ文字列追加処理

		/// <summary>
		/// クエリ文字列追加処理
		/// </summary>
		/// <param name="queryString">追加対象バッファ</param>
		/// <param name="key">キー</param>
		/// <param name="value">値</param>
		/// <remarks>
		/// <br>Note       : クエリ文字列の追加を行います。</br>
		/// </remarks>
		private void AddQueryString( StringBuilder queryString, string key, object value )
		{
			if( String.IsNullOrEmpty( key ) || ( value == null ) ) {
				return;
			}

			if( queryString.Length == 0 ) {
				// クエリの開始文字
				queryString.Append( '?' );
			}
			else {
				// クエリの連結文字
				queryString.Append( '&' );
			}

			// クエリを追加
			queryString.AppendFormat( "{0}={1}", key, ( value is string ? HttpUtility.UrlEncode( value as string ) : value ) );
		}

		#endregion

		#endregion

    }
}

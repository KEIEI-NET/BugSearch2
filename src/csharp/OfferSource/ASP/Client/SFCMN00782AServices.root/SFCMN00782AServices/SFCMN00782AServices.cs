using System;

namespace Broadleaf.Application.Controller
{
	/// <summary>
	/// 変更PG案内案内通知Webサービスアクセスクラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : 変更PG案内案内通知Webサービスへのアクセス制御を行います。</br>
	/// <br>Programmer : 23001 秋山　亮介</br>
	/// <br>Date       : 2007.03.14</br>
	/// </remarks>
	public class SFCMN00782AServices : SFCMN00782AAUTO
	{
		/// <summary>
		/// 変更PG案内案内通知Webサービスコンストラクタ
		/// </summary>
		/// <param name="webServiceUrl">Web サービスのUrl</param>
		/// <remarks>
		/// <br>Note       : 変更PG案内案内通知Webサービスへのアクセスの新しいインスタンスを初期化します。</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2007.03.14</br>
		/// </remarks>
		public SFCMN00782AServices( string webServiceUrl )
		{
			this.Url = webServiceUrl;
		}
	}
}

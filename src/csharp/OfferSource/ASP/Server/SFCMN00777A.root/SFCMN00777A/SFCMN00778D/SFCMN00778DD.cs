using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Broadleaf.Application.Remoting.ParamData
{
	/// <summary>
	/// バージョン文字列変換クラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : バージョン文字列の変換を行います。</br>
	/// <br>Programmer : 23001 秋山　亮介</br>
	/// <br>Date       : 2007.03.15</br>
	/// </remarks>
	internal class VersionStringConverter
	{
		/// <summary>
		/// ゼロサプレスバージョン変換処理
		/// </summary>
		/// <param name="zeroPaddingVersion">ゼロ詰めバージョン</param>
		/// <returns>ゼロサプレスバージョン</returns>
		/// <remarks>
		/// <br>Note       : ゼロ詰めバージョンをゼロサプレスバージョンに変換します。</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2007.03.15</br>
		/// </remarks>
		public static string ConvertToZeroSuppress( string zeroPaddingVersion )
		{
			if( ( zeroPaddingVersion == null ) || 
				( zeroPaddingVersion.Trim() == String.Empty ) ) {
				return String.Empty;
			}

			string[] splitVersion = zeroPaddingVersion.Split( '.' );

			StringBuilder zeroSuppressVersion = new StringBuilder( 32 );

			string wkVer;
			if( splitVersion.Length > 0 ) {
				wkVer = splitVersion[ 0 ].TrimStart( '0' );
				zeroSuppressVersion.Append( ( wkVer == "" ? "0" : wkVer ) );
				if( splitVersion.Length > 1 ) {
					for( int ix = 1; ix < splitVersion.Length; ix++ ) {
						zeroSuppressVersion.Append( '.' );
						wkVer = splitVersion[ ix ].TrimStart( '0' );
						zeroSuppressVersion.Append( ( wkVer == "" ? "0" : wkVer ) );
					}
				}
			}

			return zeroSuppressVersion.ToString();
		}

		/// <summary>
		/// ゼロサプレスバージョン変換処理
		/// </summary>
		/// <param name="zeroPaddingVersion">ゼロ詰めバージョン</param>
		/// <returns>ゼロサプレスバージョン</returns>
		/// <remarks>
		/// <br>Note       : ゼロ詰めバージョンをゼロサプレスバージョンに変換します。</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2007.03.15</br>
		/// </remarks>
		public static string ConvertToZeroPadding( string zeroSuppressVersion, int digit )
		{
			if( ( zeroSuppressVersion == null ) || 
				( zeroSuppressVersion.Trim() == String.Empty ) || 
				( digit == 0 ) ) {
				return String.Empty;
			}

			string[] splitVersion = zeroSuppressVersion.Split( '.' );

			StringBuilder zeroPaddingVersion = new StringBuilder( 32 );

			if( splitVersion.Length > 0 ) {
				zeroPaddingVersion.Append( splitVersion[ 0 ].PadLeft( digit, '0' ) );
				if( splitVersion.Length > 1 ) {
					for( int ix = 1; ix < splitVersion.Length; ix++ ) {
						zeroPaddingVersion.Append( '.' );
						zeroPaddingVersion.Append( splitVersion[ ix ].PadLeft( digit, '0' ) );
					}
				}
			}

			return zeroPaddingVersion.ToString();
		}
	}
}

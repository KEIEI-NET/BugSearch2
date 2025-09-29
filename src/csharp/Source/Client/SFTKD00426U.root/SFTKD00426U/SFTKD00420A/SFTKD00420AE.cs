using System;
using System.Collections;
using System.Collections.Generic;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Application.Common
{

	/// <summary>
	/// 住所ガイドで使うための共通インターフェイス
	/// 郵便番号マスタと住所マスタで共通
	/// </summary>
	/// <remarks>
	/// <br>Note       : </br>
	/// <br>Programmer : 23011　野口　暢朗</br>
	/// <br>Date       : 2006.01.06</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	public interface IMergeableAddressAcs
	{
		/// <summary>
		/// 指定住所コードの住所を取得するのに使う
		/// </summary>
		/// <param name="code1"></param>
		/// <param name="code2"></param>
		/// <param name="code3"></param>
		/// <param name="code4"></param>
		/// <param name="code5"></param>
		/// <param name="alResult"></param>
		/// <returns></returns>
		int GetAddressWork( int code1, long code2, int code3, int code4, int code5, out ArrayList alResult );
		
		/// <summary>
		/// コード１にぶら下がるものを取得
		/// </summary>
		/// <param name="code1"></param>
		/// <param name="alResult"></param>
		/// <returns></returns>
		int GetAddrIndexWork2( int code1, out ArrayList alResult);
		
		/// <summary>
		/// コード２にぶら下がるものを取得
		/// </summary>
		/// <param name="code1"></param>
		/// <param name="code2"></param>
		/// <param name="alResult"></param>
		/// <returns></returns>
		int GetAddrIndexWork3( int code1, long code2, out ArrayList alResult);
		
		/// <summary>
		/// コード３にぶら下がるものを取得
		/// </summary>
		/// <param name="code1"></param>
		/// <param name="code2"></param>
		/// <param name="code3"></param>
		/// <param name="alResult"></param>
		/// <returns></returns>
		int GetAddrIndexWork4( int code1, long code2, int code3, out ArrayList alResult);
		
		/// <summary>
		/// コード４にぶら下がるものを取得
		/// </summary>
		/// <param name="code1"></param>
		/// <param name="code2"></param>
		/// <param name="code3"></param>
		/// <param name="code4"></param>
		/// <param name="alResult"></param>
		/// <returns></returns>
		int GetAddrIndexWork5( int code1, long code2, int code3, int code4, out ArrayList alResult);
		
		/// <summary>
		/// 郵便番号のキーワードから住所を検索する
		/// コードは部分取得の現在位置を示すために使う
		/// </summary>
		/// <param name="keyword"></param>
        /// <param name="alResult"></param>
		/// <returns></returns>
		int GetAddressWorkFromZipCd( string keyword, out ICollection alResult );
		
        ///// <summary>
        ///// 指定の郵便番号キーワードに該当する件数を取得する
        ///// </summary>
        ///// <param name="keyword"></param>
        ///// <param name="intCount"></param>
        ///// <returns></returns>
        //int GetCountFromZipCd( string keyword, out int intCount );
		
        /// <summary>
        /// 指定管区からキーワードで住所を取得する
        /// </summary>
        /// <param name="areaGroup"></param>
        /// <param name="addrkey"></param>
        /// <param name="resultList"></param>
        /// <returns></returns>
		int GetAddrFromName( int areaGroup, string addrkey, out ICollection resultList );
		
        ///// <summary>
        ///// 指定キーワードに該当する住所の件数を取得する
        ///// </summary>
        ///// <param name="addrkey"></param>
        ///// <param name="intCount"></param>
        ///// <returns></returns>
        //int GetCountFromName( string addrkey, out int intCount );
		
        ///// <summary>
        ///// 現在非同期ロード中かどうか
        ///// </summary>
        //bool NowLoading
        //{
        //    get;
        //}
		
		/// <summary>
		/// ステータスバーに表示する文字列を取得する
		/// </summary>
		string StatusBarString
		{
			get;
		}
		
		/// <summary>
		/// 表示グリッドの数を取得する
		/// </summary>
		int DisplayGridCount
		{
			get;
		}
		
	}
	
}

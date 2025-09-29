using System;
using System.Collections;
using System.Data.SqlClient;

using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Resources;

namespace Broadleaf.Application.Remoting
{
	/// <summary>
	/// 自由帳票印字位置設定　DB RemoteObjectインターフェース
	/// </summary>
	/// <remarks>
	/// <br>Note       :自由帳票印字位置設定　DB RemoteObject Interfaceです。</br>
	/// <br>Programmer : 22011　柏原　頼人</br>
	/// <br>Date       : 2007.05.24</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	[APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]		// アプリケーションサーバーの接続先
	public interface IFrePrtPSetDLDB
	{
		/// <summary>
		/// 自由帳票印字位置設定検索処理
		/// </summary>
		/// <param name="EnterpriseCode">企業コード</param>
        /// <param name="OutputFormFileName">出力ファイル名</param>
		/// <param name="frePrtPSetWorkListkByte">検索した自由帳票印字位置設定リスト</param>
		/// <param name="readMode">検索区分</param>
		/// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="msgDiv">メッセージ有無区分</param>
        /// <param name="errMsg">エラーメッセージ文字列</param>
        /// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 自由帳票印字位置設定情報を検索します</br>
		/// <br>           : ※出力ファイル名未指定時、全リストを取得します</br>
		/// <br>           : ※自由帳票印字位置設定データ、背景画像データは取得しません</br>
		/// <br>Programmer : 22011　柏原　頼人</br>
		/// <br>Date       : 2007.05.24</br>
		/// </remarks>
        int Search(string EnterpriseCode, string OutputFormFileName, out byte[] frePrtPSetWorkListkByte, int readMode, ConstantManagement.LogicalMode logicalMode, out bool msgDiv, out string errMsg);

        /// <summary>
        /// 自由帳票選択ガイド情報検索処理
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="printPaperUseDivcd">帳票区分コード(1:帳票,2:伝票)</param>
        /// <param name="printPaperDivCd">帳票区分コード(1:日次帳票,2:月次帳票,3:年次帳票,4:随時帳票)</param>
        /// <param name="dataInputSystem ">データ入力システム(0:共通,1:SF,2:BK,3:SH)</param>
        /// <param name="frePrtPSetSearchRetWork">印字位置設定ワーククラス配列</param>
        /// <param name="msgDiv">メッセージ区分</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note		: 指定された自由帳票印字位置設定検索結果クラスワークLISTを取得します。</br>
        /// <br>Programmer	: 22024 寺坂　誉志</br>
        /// <br>Date		: 2007.05.09</br>
        /// <br>Update Note : 22011 柏原　頼人</br>
        /// <br>            : ガイドのサーチをDL用リモートに統合</br>
        /// </remarks>
        int Search(string enterpriseCode, int printPaperUseDivcd, int printPaperDivCd, int[] dataInputSystem, out byte[] frePrtPSetSearchRetWork, out bool msgDiv, out string errMsg);
        

        /// <summary>
        /// 自由帳票印字位置設定・背景画像の取得を行います。
        /// </summary>
        /// <param name="frePrtPSetWorkByte">印字位置設定データパラメータ(キー値のみを指定)</param>
        /// <param name="msgDiv">メッセージ有無区分</param>
        /// <param name="errMsg">エラーメッセージ文字列</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 自由帳票印字位置設定情報を取得します</br>
        /// <br>Programmer : 22011　柏原　頼人</br>
        /// <br>Date       : 2007.05.24</br>
        /// </remarks>
        int Read(ref byte[] frePrtPSetWorkByte, out bool msgDiv, out string errMsg);

        /// <summary>
        /// 自由帳票印字位置情報を物理削除します
        /// </summary>
        /// <param name="parabyte">FrePrtPSetWorkオブジェクト</param>
        /// <param name="msgDiv">メッセージ有無区分</param>
        /// <param name="errMsg">エラーメッセージ文字列</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       :  自由帳票印字位置情報を物理削除します</br>
        /// <br>Programmer : 22011　柏原　頼人</br>
        /// <br>Date       : 2007.05.24</br>
        /// </remarks>
        int DeleteFrePrtPSet(byte[] parabyte, out bool msgDiv, out string errMsg);
    }
}
using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
	/// <summary>
	/// 拠点情報 RemoteObjectインターフェース
	/// </summary>
	/// <remarks>
	/// <br>Note       : 拠点情報 RemoteObject Interfaceです。</br>
	/// <br>Programmer : 21015　金巻　芳則</br>
	/// <br>Date       : 2005.08.06</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// <br>20050704 yamada  カスタムシリアライズ対応メソッド追加 </br>
	/// </remarks>
	[APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]		//←アプリケーションサーバーの接続先を属性で指示
	public interface ISectionInfo
	{
		
		/// <summary>
		/// 拠点情報設定LISTを全て戻します（論理削除除く）:カスタムシリアライズ
		/// </summary>
		/// <param name="searchRetList">検索結果</param>
		/// <param name="secInfoSetWork">検索パラメータ</param>
		/// <param name="readMode">検索区分(予約用パラメータ)</param>
		/// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
		/// <param name="errorLevel">エラーレベル</param>
		/// <param name="errorCode">エラーコード</param>
		/// <param name="errorMessage">エラーメッセージ</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : </br>
		/// <br>Programmer : 21015　金巻　芳則</br>
		/// <br>Date       : 2005.07.04</br>
		[MustCustomSerialization]
		int Search(
			[CustomSerializationMethodParameterAttribute("SFCMN00021C","Broadleaf.Library.Collections.CustomSerializeArrayList")]
			out object searchRetList,
			object secInfoSetWork,
			int readMode,
			ConstantManagement.LogicalMode logicalMode,
			out int errorLevel,
			out string errorCode,
			out string errorMessage);
		
	}
}

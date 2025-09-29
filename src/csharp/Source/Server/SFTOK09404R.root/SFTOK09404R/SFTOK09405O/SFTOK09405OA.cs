using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting
{
	/// <summary>
	/// 備考ガイドDB RemoteObjectインターフェース
	/// </summary>
	/// <remarks>
	/// <br>Note       : 備考ガイドDB RemoteObject Interfaceです。</br>
	/// <br>Programmer : 21052　山田　圭</br>
	/// <br>Date       : 2005.10.13</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	[APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]		//←アプリケーションサーバーの接続先を属性で指示
	public interface INoteGuidBdDB
	{
		#region ヘッダーメソッド
		/// <summary>
		/// 備考ガイドヘッダーLISTの件数を戻します
		/// </summary>
		/// <param name="retCnt">該当データ件数</param>
		/// <param name="parabyte">検索パラメータ</param>		
		/// <param name="readMode">検索区分</param>
		/// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 指定された企業コードの備考ガイドLISTの件数を戻します</br>
		/// <br>Programmer : 21052　山田　圭</br>
		/// <br>Date       : 2005.10.13</br>
		int SearchCntHeader(out int retCnt, byte[] parabyte, int readMode,ConstantManagement.LogicalMode logicalMode);
		
		/// <summary>
		/// 備考ガイド情報LISTを全て戻します（論理削除除く）
		/// </summary>
		/// <param name="retobj">検索結果</param>
		/// <param name="paraobj">検索パラメータ</param>
		/// <param name="readMode">検索区分</param>
		/// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : </br>
		/// <br>Programmer : 21052　山田　圭</br>
		/// <br>Date       : 2005.10.13</br>
		[MustCustomSerialization]
		int SearchHeader(
			[CustomSerializationMethodParameterAttribute("SFTOK09406D","Broadleaf.Application.Remoting.ParamData.NoteGuidHdWork")]
			out object retobj, object paraobj, int readMode,ConstantManagement.LogicalMode logicalMode);

		/// <summary>
		/// 指定されたコードの備考ガイドヘッダーを戻します
		/// </summary>
		/// <param name="parabyte">NoteGuidHdWorkオブジェクト</param>
		/// <param name="readMode">検索区分</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 指定されたコードの備考ガイドを戻します</br>
		/// <br>Programmer : 21052　山田　圭</br>
		/// <br>Date       : 2005.10.13</br>
		int ReadHeader(ref byte[] parabyte , int readMode);

		/// <summary>
		/// 備考ガイドヘッダー情報を登録、更新します
		/// </summary>
		/// <param name="parabyte">NoteGuidHdWorkオブジェクト</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 備考ガイドヘッダー情報を登録、更新します</br>
		/// <br>Programmer : 21052　山田　圭</br>
		/// <br>Date       : 2005.10.13</br>
		int WriteHeader(ref byte[] parabyte);

		/// <summary>
		/// 備考ガイド情報を物理削除します
		/// </summary>
		/// <param name="parabyte">OcrDefSetWorkオブジェクト</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 備考ガイド情報を物理削除します</br>
		/// <br>Programmer : 21052　山田　圭</br>
		/// <br>Date       : 2005.10.13</br>
		int DeleteHeader(byte[] parabyte);

		/// <summary>
		/// 備考ガイドボディ(ユーザー変更分)情報を論理削除します
		/// </summary>
		/// <param name="parabyte">NoteGuidBdWorkオブジェクト</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 備考ガイド情報を論理削除します</br>
		/// <br>Programmer : 21052　山田　圭</br>
		/// <br>Date       : 2005.10.13</br>
		int LogicalDeleteHeader(ref byte[] parabyte);

		/// <summary>
		/// 論理削除備考ガイド情報を復活します
		/// </summary>
		/// <param name="parabyte">OcrDefSetWorkオブジェクト</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 論理削除備考ガイド情報を復活します</br>
		/// <br>Programmer : 21052　山田　圭</br>
		/// <br>Date       : 2005.10.13</br>
		int RevivalLogicalDeleteHeader(ref byte[] parabyte);

		#endregion

		#region ボディメソッド
		/// <summary>
		/// 備考ガイドヘッダーLISTの件数を戻します
		/// </summary>
		/// <param name="retCnt">該当データ件数</param>
		/// <param name="parabyte">検索パラメータ</param>		
		/// <param name="readMode">検索区分</param>
		/// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 指定された企業コードの備考ガイドLISTの件数を戻します</br>
		/// <br>Programmer : 21052　山田　圭</br>
		/// <br>Date       : 2005.10.13</br>
		int SearchCntBody(out int retCnt, byte[] parabyte, int readMode,ConstantManagement.LogicalMode logicalMode);
		
		/// <summary>
		/// 備考ガイド情報LISTを全て戻します（論理削除除く）
		/// </summary>
		/// <param name="retobj">検索結果</param>
		/// <param name="paraobj">検索パラメータ</param>
		/// <param name="readMode">検索区分</param>
		/// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : </br>
		/// <br>Programmer : 21052　山田　圭</br>
		/// <br>Date       : 2005.10.13</br>
		[MustCustomSerialization]
		int SearchBody(
			[CustomSerializationMethodParameterAttribute("SFTOK09406D","Broadleaf.Application.Remoting.ParamData.NoteGuidBdWork")]
			out object retobj, object paraobj, int readMode,ConstantManagement.LogicalMode logicalMode);

		/// <summary>
		/// 指定されたコードの備考ガイドヘッダーを戻します
		/// </summary>
		/// <param name="parabyte">NoteGuidHdWorkオブジェクト</param>
		/// <param name="readMode">検索区分</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 指定されたコードの備考ガイドを戻します</br>
		/// <br>Programmer : 21052　山田　圭</br>
		/// <br>Date       : 2005.10.13</br>
		int ReadBody(ref byte[] parabyte , int readMode);

		/// <summary>
		/// 備考ガイドヘッダー情報を登録、更新します
		/// </summary>
		/// <param name="parabyte">NoteGuidHdWorkオブジェクト</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 備考ガイドヘッダー情報を登録、更新します</br>
		/// <br>Programmer : 21052　山田　圭</br>
		/// <br>Date       : 2005.10.13</br>
		int WriteBody(ref byte[] parabyte);

		/// <summary>
		/// 備考ガイド情報を物理削除します
		/// </summary>
		/// <param name="parabyte">OcrDefSetWorkオブジェクト</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 備考ガイド情報を物理削除します</br>
		/// <br>Programmer : 21052　山田　圭</br>
		/// <br>Date       : 2005.10.13</br>
		int DeleteBody(byte[] parabyte);

		/// <summary>
		/// 備考ガイドボディ(ユーザー変更分)情報を論理削除します
		/// </summary>
		/// <param name="parabyte">NoteGuidBdWorkオブジェクト</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 備考ガイド情報を論理削除します</br>
		/// <br>Programmer : 21052　山田　圭</br>
		/// <br>Date       : 2005.10.13</br>
		int LogicalDeleteBody(ref byte[] parabyte);

		/// <summary>
		/// 論理削除備考ガイド情報を復活します
		/// </summary>
		/// <param name="parabyte">OcrDefSetWorkオブジェクト</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 論理削除備考ガイド情報を復活します</br>
		/// <br>Programmer : 21052　山田　圭</br>
		/// <br>Date       : 2005.10.13</br>
		int RevivalLogicalDeleteBody(ref byte[] parabyte);

		/// <summary>
		/// 備考ガイドボディLISTを指定区分コード分戻します（論理削除除く）
		/// </summary>
		/// <param name="retobj">検索結果</param>
		/// <param name="paraobj">検索パラメータ</param>
		/// <param name="readMode">検索区分</param>
		/// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 備考ガイドボディLISTを指定区分コード分戻します（論理削除除く）</br>
		/// <br>Programmer : 21052　山田　圭</br>
		/// <br>Date       : 2005.10.13</br>
		[MustCustomSerialization]
		int SearchGuideDivCode(
			[CustomSerializationMethodParameterAttribute("SFTOK09406D","Broadleaf.Application.Remoting.ParamData.NoteGuidBdWork")]
			out object retobj, object paraobj, int readMode,ConstantManagement.LogicalMode logicalMode);
		#endregion
		
	}

}

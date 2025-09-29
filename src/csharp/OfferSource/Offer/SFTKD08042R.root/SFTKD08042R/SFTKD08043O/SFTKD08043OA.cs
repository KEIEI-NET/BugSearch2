using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;
	
namespace Broadleaf.Application.Remoting
{
	/// <summary>
	/// ユーザーガイドDB RemoteObjectインターフェース
	/// </summary>
	/// <remarks>
	/// <br>Note       : ユーザーガイドDB RemoteObject Interfaceです。</br>
	/// <br>Programmer : 21015　金巻　芳則</br>
	/// <br>Date       : 2005.03.24</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	[APServerTarget(ConstantManagement_SF_PRO.ServerCode_OfferAP)]		//←アプリケーションサーバーの接続先を属性で指示
	public interface IUserGdBdDB
	{
		/// <summary>
		/// 指定された企業コードのユーザーガイド情報LISTの件数を戻します
		/// </summary>
		/// <param name="retCnt">該当データ件数</param>
		/// <param name="parabyte">検索パラメータ</param>		
		/// <param name="readMode">検索区分</param>
		/// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : </br>
		/// <br>Programmer : 21015　金巻　芳則</br>
		/// <br>Date       : 2005.03.24</br>
		int SearchCnt(out int retCnt, byte[] parabyte, int readMode,ConstantManagement.LogicalMode logicalMode);
		
		/// <summary>
		/// ユーザーガイド情報LISTを全て戻します（論理削除除く）
		/// </summary>
		/// <param name="retobj">検索結果</param>
		/// <param name="paraobj">検索パラメータ</param>
		/// <param name="readMode">検索区分</param>
		/// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : </br>
		/// <br>Programmer : 21015　金巻　芳則</br>
		/// <br>Date       : 2005.03.24</br>
		[MustCustomSerialization]
		int SearchHeader(
			[CustomSerializationMethodParameterAttribute("SFTKD08044D","Broadleaf.Application.Remoting.ParamData.UserGdHdWork")]
			out object retobj, object paraobj, int readMode,ConstantManagement.LogicalMode logicalMode);

		/// <summary>
		/// ユーザーガイド情報LISTを全て戻します（論理削除除く）
		/// </summary>
		/// <param name="retobj">検索結果</param>
		/// <param name="paraobj">検索パラメータ</param>
		/// <param name="readMode">検索区分</param>
		/// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : </br>
		/// <br>Programmer : 21015　金巻　芳則</br>
		/// <br>Date       : 2005.03.24</br>
		[MustCustomSerialization]
		int SearchBody(
			[CustomSerializationMethodParameterAttribute("SFTKD08044D","Broadleaf.Application.Remoting.ParamData.UserGdBdWork")]
			out object retobj, object paraobj, int readMode,ConstantManagement.LogicalMode logicalMode);

		/// <summary>
		/// 指定されたGuideDivCodeのユーザーガイド情報LISTを全て戻します（論理削除除く）
		/// </summary>
		/// <param name="retobj">検索結果</param>
		/// <param name="paraobj">検索パラメータ</param>
		/// <param name="readMode">検索区分</param>
		/// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : </br>
		/// <br>Programmer : 21015　金巻　芳則</br>
		/// <br>Date       : 2005.03.24</br>
		[MustCustomSerialization]
		int SearchGuideDivCode(
			[CustomSerializationMethodParameterAttribute("SFTKD08044D","Broadleaf.Application.Remoting.ParamData.UserGdBdWork")]
			out object retobj, object paraobj, int readMode,ConstantManagement.LogicalMode logicalMode);
		
		/// <summary>
		/// 指定されたユーザーガイドGuidのユーザーガイド情報を戻します
		/// </summary>
		/// <param name="parabyte">OcrDefSetWorkオブジェクト</param>
		/// <param name="readMode">検索区分</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 指定されたユーザーガイドGuidのユーザーガイドを戻します</br>
		/// <br>Programmer : 21015　金巻　芳則</br>
		/// <br>Date       : 2005.03.24</br>
		int Read(ref byte[] parabyte , int readMode);
	}
}

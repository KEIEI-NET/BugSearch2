using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
	/// <summary>
	/// 伝票印刷設定DB RemoteObjectインターフェース
	/// </summary>
	/// <remarks>
	/// <br>Note       : 伝票印刷設定DB RemoteObject Interfaceです。</br>
	/// <br>Programmer : 22027　橋本　将樹</br>
	/// <br>Date       : 2005.08.30</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	[APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
	public interface ISlipPrtSetDB
	{
		/// <summary>
		/// 伝票印刷設定LISTを全て戻します（論理削除除く）
		/// </summary>
		/// <param name="retobj">検索結果</param>
		/// <param name="paraobj">検索パラメータ</param>
		/// <param name="readMode">検索区分</param>
		/// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : </br>
		/// <br>Programmer : 22027　橋本　将樹</br>
		/// <br>Date       : 2005.08.30</br>
		[MustCustomSerialization]
		int Search(
			[CustomSerializationMethodParameterAttribute("SFURI09026D","Broadleaf.Application.Remoting.ParamData.SlipPrtSetWork")]
			out object retobj,
			object paraobj,
			int readMode,ConstantManagement.LogicalMode logicalMode);
					
		/// <summary>
		/// 指定された伝票印刷設定Guidの伝票印刷設定を戻します
		/// </summary>
		/// <param name="parabyte">SlipPrtSetWorkオブジェクト</param>
		/// <param name="readMode">検索区分</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 指定された伝票印刷設定Guidの伝票印刷設定を戻します</br>
		/// <br>Programmer : 22027　橋本　将樹</br>
		/// <br>Date       : 2005.08.30</br>
		int Read(ref byte[] parabyte , int readMode);

		/// <summary>
		/// 伝票印刷設定情報を登録、更新します
		/// </summary>
		/// <param name="parabyte">SlipPrtSetWorkオブジェクト</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 伝票印刷設定情報を登録、更新します</br>
		/// <br>Programmer : 22027　橋本　将樹</br>
		/// <br>Date       : 2005.08.30</br>
		int Write(ref byte[] parabyte);

		/// <summary>
		/// 伝票印刷設定情報を物理削除します
		/// </summary>
		/// <param name="parabyte">SlipPrtSetWorkオブジェクト</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 伝票印刷設定情報を物理削除します</br>
		/// <br>Programmer : 22027　橋本　将樹</br>
		/// <br>Date       : 2005.08.30</br>
		int Delete(byte[] parabyte);

		/// <summary>
		/// 伝票印刷設定情報を論理削除します
		/// </summary>
		/// <param name="parabyte">SlipPrtSetWorkオブジェクト</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 伝票印刷設定情報を論理削除します</br>
		/// <br>Programmer : 22027　橋本　将樹</br>
		/// <br>Date       : 2005.08.30</br>
		int LogicalDelete(ref byte[] parabyte);

		/// <summary>
		/// 論理削除伝票印刷設定情報を復活します
		/// </summary>
		/// <param name="parabyte">SlipPrtSetWorkオブジェクト</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 論理削除伝票印刷設定情報を復活します</br>
		/// <br>Programmer : 22027　橋本　将樹</br>
		/// <br>Date       : 2005.08.30</br>
		int RevivalLogicalDelete(ref byte[] parabyte);
	}
}

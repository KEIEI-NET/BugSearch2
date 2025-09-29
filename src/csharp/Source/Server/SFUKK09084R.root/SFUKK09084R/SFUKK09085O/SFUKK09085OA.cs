using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
	/// <summary>
	/// 請求印刷設定DB RemoteObjectインターフェース
	/// </summary>
	/// <remarks>
	/// <br>Note       : 請求印刷設定DB RemoteObject Interfaceです。</br>
	/// <br>Programmer : 21052　山田　圭</br>
	/// <br>Date       : 2005.07.20</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	[APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]		//←アプリケーションサーバーの接続先を属性で指示
	public interface IBillPrtStDB
	{
		/// <summary>
		/// 請求印刷設定LISTを全て戻します（論理削除除く）
		/// </summary>
		/// <param name="retobject">検索結果</param>
		/// <param name="paraobject">検索パラメータ</param>
		/// <param name="readMode">検索区分</param>
		/// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : </br>
		/// <br>Programmer : 21052　山田　圭</br>
		/// <br>Date       : 2005.07.20</br>
		[MustCustomSerialization]
		int Search(
			[CustomSerializationMethodParameterAttribute("SFUKK09086D","Broadleaf.Application.Remoting.ParamData.BillPrtStWork")]
			out object retobject, 
			object paraobject, int readMode,ConstantManagement.LogicalMode logicalMode);

		/// <summary>
		/// 指定された請求印刷設定Guidの請求印刷設定を戻します
		/// </summary>
		/// <param name="parabyte">BillPrtStWorkオブジェクト</param>
		/// <param name="readMode">検索区分</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 指定された請求印刷設定Guidの請求印刷設定を戻します</br>
		/// <br>Programmer : 21052　山田　圭</br>
		/// <br>Date       : 2005.07.20</br>
		int Read(ref byte[] parabyte , int readMode);

		/// <summary>
		/// 請求印刷設定情報を登録、更新します
		/// </summary>
		/// <param name="parabyte">BillPrtStWorkオブジェクト</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 請求印刷設定情報を登録、更新します</br>
		/// <br>Programmer : 21052　山田　圭</br>
		/// <br>Date       : 2005.07.20</br>
		int Write(ref byte[] parabyte);

		/// <summary>
		/// 請求印刷設定情報を物理削除します
		/// </summary>
		/// <param name="parabyte">BillPrtStWorkオブジェクト</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 請求印刷設定情報を物理削除します</br>
		/// <br>Programmer : 21052　山田　圭</br>
		/// <br>Date       : 2005.07.20</br>
		int Delete(byte[] parabyte);

		/// <summary>
		/// 請求印刷設定情報を論理削除します
		/// </summary>
		/// <param name="parabyte">BillPrtStWorkオブジェクト</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 請求印刷設定情報を論理削除します</br>
		/// <br>Programmer : 21052　山田　圭</br>
		/// <br>Date       : 2005.07.20</br>
		int LogicalDelete(ref byte[] parabyte);

		/// <summary>
		/// 論理削除請求印刷設定情報を復活します
		/// </summary>
		/// <param name="parabyte">BillPrtStWorkオブジェクト</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 論理削除請求印刷設定情報を復活します</br>
		/// <br>Programmer : 21052　山田　圭</br>
		/// <br>Date       : 2005.07.20</br>
		int RevivalLogicalDelete(ref byte[] parabyte);
	}
}

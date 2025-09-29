using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
	/// <summary>
	/// 全体初期値DB RemoteObjectインターフェース
	/// </summary>
	/// <remarks>
	/// <br>Note       : 全体初期値DB RemoteObject Interfaceです。</br>
	/// <br>Programmer : 21052　山田　圭</br>
	/// <br>Date       : 2005.10.03</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	[APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]		//←アプリケーションサーバーの接続先を属性で指示
	public interface IAllDefSetDB
	{
		#region カスタムシリアライズ

		/// <summary>
		/// 全体初期値LISTを全て戻します（論理削除除く）
		/// </summary>
		/// <param name="retobj">検索結果</param>
		/// <param name="paraobj">検索パラメータ</param>
		/// <param name="readMode">検索区分</param>
		/// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : </br>
		/// <br>Programmer : 21052　山田　圭</br>
		/// <br>Date       : 2005.10.03</br>
		int Search(
			[CustomSerializationMethodParameterAttribute("SFCMN09086D","Broadleaf.Application.Remoting.ParamData.AllDefSetWork")]
			out object retobj,
			object paraobj,
			int readMode,ConstantManagement.LogicalMode logicalMode);
		#endregion

		/// <summary>
		/// 指定された企業コードの全体初期値LISTの件数を戻します
		/// </summary>
		/// <param name="retCnt">該当データ件数</param>
		/// <param name="parabyte">検索パラメータ</param>		
		/// <param name="readMode">検索区分</param>
		/// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : </br>
		/// <br>Programmer : 21052　山田　圭</br>
		/// <br>Date       : 2005.10.03</br>
		int SearchCnt(out int retCnt, byte[] parabyte, int readMode,ConstantManagement.LogicalMode logicalMode);
		
		/// <summary>
		/// 指定された全体初期値Guidの全体初期値を戻します
		/// </summary>
		/// <param name="parabyte">AllDefSetWorkオブジェクト</param>
		/// <param name="readMode">検索区分</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 指定された全体初期値Guidの全体初期値を戻します</br>
		/// <br>Programmer : 21052　山田　圭</br>
		/// <br>Date       : 2005.10.03</br>
		int Read(ref byte[] parabyte , int readMode);

		/// <summary>
		/// 全体初期値情報を登録、更新します
		/// </summary>
		/// <param name="parabyte">AllDefSetWorkオブジェクト</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 全体初期値情報を登録、更新します</br>
		/// <br>Programmer : 21052　山田　圭</br>
		/// <br>Date       : 2005.10.03</br>
		int Write(ref byte[] parabyte);

		/// <summary>
		/// 全体初期値情報を物理削除します
		/// </summary>
		/// <param name="parabyte">AllDefSetWorkオブジェクト</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 全体初期値情報を物理削除します</br>
		/// <br>Programmer : 21052　山田　圭</br>
		/// <br>Date       : 2005.10.03</br>
		int Delete(byte[] parabyte);

		/// <summary>
		/// 全体初期値情報を論理削除します
		/// </summary>
		/// <param name="parabyte">AllDefSetWorkオブジェクト</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 全体初期値情報を論理削除します</br>
		/// <br>Programmer : 21052　山田　圭</br>
		/// <br>Date       : 2005.10.03</br>
		int LogicalDelete(ref byte[] parabyte);

		/// <summary>
		/// 論理削除全体初期値情報を復活します
		/// </summary>
		/// <param name="parabyte">AllDefSetWorkオブジェクト</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 論理削除全体初期値情報を復活します</br>
		/// <br>Programmer : 21052　山田　圭</br>
		/// <br>Date       : 2005.10.03</br>
		int RevivalLogicalDelete(ref byte[] parabyte);

	}
}

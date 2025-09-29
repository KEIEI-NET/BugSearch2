using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
	/// <summary>
	/// フェリカ管理DB RemoteObjectインターフェース
	/// </summary>
	/// <remarks>
	/// <br>Note       : フェリカ管理DB RemoteObject Interfaceです。</br>
	/// <br>Programmer : 22011　柏原頼人</br>
	/// <br>Date       : 2008.10.30</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	[APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]		//←アプリケーションサーバーの接続先を属性で指示
	public interface IFeliCaMngDB
	{
		/// <summary>
		/// 指定された企業コードのフェリカ管理LISTを全て戻します（論理削除除く）
		/// </summary>
		/// <param name="felicaMngWork">検索結果</param>
		/// <param name="parafelicaMngWork">検索パラメータ</param>
		/// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
		/// <returns>STATUS</returns>
        [MustCustomSerialization]
		int Search(
            [CustomSerializationMethodParameterAttribute("SFCMN03504D", "Broadleaf.Application.Remoting.ParamData.FeliCaMngWork")]
			out object felicaMngWork, 
			object parafelicaMngWork,
			ConstantManagement.LogicalMode logicalMode);

		/// <summary>
		/// 指定されたフェリカ管理Guidのフェリカ管理を戻します
		/// </summary>
        /// <param name="paraobj">WorkerWorkオブジェクト</param>
		/// <returns>STATUS</returns>
		int Read(ref object paraobj);
        
		/// <summary>
		/// フェリカ管理情報を登録、更新します
		/// </summary>
		/// <param name="paraobj">WorkerWorkオブジェクト</param>
		/// <returns>STATUS</returns>
        int Write(
            ref object paraobj ); 

		/// <summary>
		/// フェリカ管理情報を物理削除します
		/// </summary>
        /// <param name="paraobj">WorkerWorkオブジェクト</param>
		/// <returns>STATUS</returns>
        int Delete(object paraobj);

		/// <summary>
		/// フェリカ管理情報を論理削除します
		/// </summary>
        /// <param name="paraobj">WorkerWorkオブジェクト</param>
		/// <returns>STATUS</returns>
        int LogicalDelete(ref object paraobj);

		/// <summary>
		/// 論理削除フェリカ管理情報を復活します
		/// </summary>
        /// <param name="paraobj">WorkerWorkオブジェクト</param>
		/// <returns>STATUS</returns>
        int RevivalLogicalDelete(ref object paraobj);
	}
}

using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
	/// <summary>
    /// 得意先マスタ(伝票管理)マスタDB RemoteObjectインターフェース
	/// </summary>
	/// <remarks>
    /// <br>Note       : 得意先マスタ(伝票管理)マスタDB RemoteObject Interfaceです。</br>
	/// <br>Programmer : 20081　疋田　勇人</br>
	/// <br>Date       : 2007.09.18</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	[APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
	public interface ICustSlipMngDB
	{

		/// <summary>
        /// 指定された得意先マスタ(伝票管理)マスタGuidの得意先マスタ(伝票管理)マスタを戻します
		/// </summary>
        /// <param name="parabyte">CustSlipMngWorkオブジェクト</param>
		/// <param name="readMode">検索区分</param>
		/// <returns>STATUS</returns>
        /// <br>Note       : 指定された得意先マスタ(伝票管理)マスタGuidの得意先マスタ(伝票管理)マスタを戻します</br>
		/// <br>Programmer : 20081　疋田　勇人</br>
		/// <br>Date       : 2007.09.18</br>
		int Read(ref byte[] parabyte , int readMode);

		/// <summary>
        /// 得意先マスタ(伝票管理)マスタ情報を物理削除します
		/// </summary>
        /// <param name="parabyte">CustSlipMngWorkオブジェクト</param>
		/// <returns>STATUS</returns>
        /// <br>Note       : 得意先マスタ(伝票管理)マスタ情報を物理削除します</br>
		/// <br>Programmer : 20081　疋田　勇人</br>
		/// <br>Date       : 2007.09.18</br>
		int Delete(byte[] parabyte);

		#region カスタムシリアライズ対応メソッド
		/// <summary>
        /// 得意先マスタ(伝票管理)マスタLISTを全て戻します（論理削除除く）:カスタムシリアライズ
		/// </summary>
		/// <param name="custslipmngWork">検索結果</param>
		/// <param name="paracustslipmngWork">検索パラメータ</param>
		/// <param name="readMode">検索区分</param>
		/// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : </br>
		/// <br>Programmer : 20081　疋田　勇人</br>
		/// <br>Date       : 2007.09.18</br>
		[MustCustomSerialization]
		int Search(
            [CustomSerializationMethodParameterAttribute("DCKHN09136D", "Broadleaf.Application.Remoting.ParamData.CustSlipMngWork")]
			out object custslipmngWork,
			object paracustslipmngWork, int readMode,ConstantManagement.LogicalMode logicalMode);

		/// <summary>
        /// 得意先マスタ(伝票管理)マスタ情報を登録、更新します
		/// </summary>
        /// <param name="custslipmngWork">CustSlipMngWorkオブジェクト</param>
		/// <returns>STATUS</returns>
        /// <br>Note       : 得意先マスタ(伝票管理)マスタ情報を登録、更新します</br>
		/// <br>Programmer : 20081　疋田　勇人</br>
		/// <br>Date       : 2007.09.18</br>
        [MustCustomSerialization]
        int Write(
            [CustomSerializationMethodParameterAttribute("DCKHN09136D", "Broadleaf.Application.Remoting.ParamData.CustSlipMngWork")]
			ref object custslipmngWork
			);

		/// <summary>
        /// 得意先マスタ(伝票管理)マスタ情報を論理削除します
		/// </summary>
        /// <param name="custslipmngWork">CustSlipMngWorkオブジェクト</param>
		/// <returns>STATUS</returns>
        /// <br>Note       : 得意先マスタ(伝票管理)マスタ情報を論理削除します</br>
		/// <br>Programmer : 20081　疋田　勇人</br>
		/// <br>Date       : 2007.09.18</br>
        [MustCustomSerialization]
        int LogicalDelete(
            [CustomSerializationMethodParameterAttribute("DCKHN09136D", "Broadleaf.Application.Remoting.ParamData.CustSlipMngWork")]
			ref object custslipmngWork
			);

		/// <summary>
        /// 論理削除得意先マスタ(伝票管理)マスタ情報を復活します
		/// </summary>
        /// <param name="custslipmngWork">CustSlipMngWorkオブジェクト</param>
		/// <returns>STATUS</returns>
        /// <br>Note       : 論理削除得意先マスタ(伝票管理)マスタ情報を復活します</br>
		/// <br>Programmer : 20081　疋田　勇人</br>
		/// <br>Date       : 2007.09.18</br>
        [MustCustomSerialization]
        int RevivalLogicalDelete(
            [CustomSerializationMethodParameterAttribute("DCKHN09136D", "Broadleaf.Application.Remoting.ParamData.CustSlipMngWork")]
			ref object custslipmngWork
			);
		#endregion
	}
}

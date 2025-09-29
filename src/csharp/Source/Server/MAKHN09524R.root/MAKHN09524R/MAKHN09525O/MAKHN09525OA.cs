using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
	/// <summary>
	/// 商品管理情報マスタDB RemoteObjectインターフェース
	/// </summary>
	/// <remarks>
	/// <br>Note       : 商品管理情報マスタDB RemoteObject Interfaceです。</br>
	/// <br>Programmer : 21015　金巻　芳則</br>
	/// <br>Date       : 2007.01.25</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	[APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
	public interface IGoodsMngDB
	{

		/// <summary>
		/// 指定された商品管理情報マスタGuidの商品管理情報マスタを戻します
		/// </summary>
		/// <param name="parabyte">GoodsMngWorkオブジェクト</param>
		/// <param name="readMode">検索区分</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 指定された商品管理情報マスタGuidの商品管理情報マスタを戻します</br>
		/// <br>Programmer : 21015　金巻　芳則</br>
		/// <br>Date       : 2007.01.25</br>
		int Read(ref byte[] parabyte , int readMode);

		/// <summary>
		/// 商品管理情報マスタ情報を物理削除します
		/// </summary>
		/// <param name="parabyte">GoodsMngWorkオブジェクト</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 商品管理情報マスタ情報を物理削除します</br>
		/// <br>Programmer : 21015　金巻　芳則</br>
		/// <br>Date       : 2007.01.25</br>
		int Delete(byte[] parabyte);

		#region カスタムシリアライズ対応メソッド
		/// <summary>
		/// 商品管理情報マスタLISTを全て戻します（論理削除除く）:カスタムシリアライズ
		/// </summary>
		/// <param name="goodsMngWork">検索結果</param>
		/// <param name="paragoodsMngWork">検索パラメータ</param>
		/// <param name="readMode">検索区分</param>
		/// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : </br>
		/// <br>Programmer : 21015　金巻　芳則</br>
		/// <br>Date       : 2007.01.25</br>
		[MustCustomSerialization]
		int Search(
			[CustomSerializationMethodParameterAttribute("MAKHN09526D","Broadleaf.Application.Remoting.ParamData.GoodsMngWork")]
			out object goodsMngWork,
			object paragoodsMngWork, int readMode,ConstantManagement.LogicalMode logicalMode);

        /// <summary>
        /// 商品番号未登録の商品管理情報マスタLISTを全て戻します（論理削除除く）:カスタムシリアライズ
        /// </summary>
        /// <param name="goodsMngWork">検索結果</param>
        /// <param name="paragoodsMngWork">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.01.25</br>
        [MustCustomSerialization]
        int SearchNoneGoodsNo(
            [CustomSerializationMethodParameterAttribute("MAKHN09526D", "Broadleaf.Application.Remoting.ParamData.GoodsMngWork")]
			out object goodsMngWork,
            object paragoodsMngWork, int readMode, ConstantManagement.LogicalMode logicalMode);
            
        /// <summary>
		/// 商品管理情報マスタ情報を登録、更新します
		/// </summary>
		/// <param name="goodsMngWork">GoodsMngWorkオブジェクト</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 商品管理情報マスタ情報を登録、更新します</br>
		/// <br>Programmer : 21015　金巻　芳則</br>
		/// <br>Date       : 2007.01.25</br>
        [MustCustomSerialization]
        int Write(
			[CustomSerializationMethodParameterAttribute("MAKHN09526D","Broadleaf.Application.Remoting.ParamData.GoodsMngWork")]
			ref object goodsMngWork
			);

		/// <summary>
		/// 商品管理情報マスタ情報を論理削除します
		/// </summary>
		/// <param name="goodsMngWork">GoodsMngWorkオブジェクト</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 商品管理情報マスタ情報を論理削除します</br>
		/// <br>Programmer : 21015　金巻　芳則</br>
		/// <br>Date       : 2007.01.25</br>
        [MustCustomSerialization]
        int LogicalDelete(
			[CustomSerializationMethodParameterAttribute("MAKHN09526D","Broadleaf.Application.Remoting.ParamData.GoodsMngWork")]
			ref object goodsMngWork
			);

		/// <summary>
		/// 論理削除商品管理情報マスタ情報を復活します
		/// </summary>
		/// <param name="goodsMngWork">GoodsMngWorkオブジェクト</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 論理削除商品管理情報マスタ情報を復活します</br>
		/// <br>Programmer : 21015　金巻　芳則</br>
		/// <br>Date       : 2007.01.25</br>
        [MustCustomSerialization]
        int RevivalLogicalDelete(
			[CustomSerializationMethodParameterAttribute("MAKHN09526D","Broadleaf.Application.Remoting.ParamData.GoodsMngWork")]
			ref object goodsMngWork
			);
		#endregion
	}
}

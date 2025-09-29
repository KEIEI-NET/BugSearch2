using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
	/// <summary>
	/// 商品マスタ（ユーザー登録分）DB RemoteObjectインターフェース
	/// </summary>
	/// <remarks>
	/// <br>Note       : 商品マスタ（ユーザー登録分）DB RemoteObject Interfaceです。</br>
	/// <br>Programmer : 21015　金巻　芳則</br>
	/// <br>Date       : 2007.01.24</br>
    /// <br></br>
    /// <br>Update Note: PM.NS用に修正</br>
    /// <br>Programmer : 20081　疋田 勇人</br>
    /// <br>Date       : 2008.06.06</br>
   	/// </remarks>
	[APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
	public interface IGoodsUDB
	{

		/// <summary>
		/// 指定された商品マスタ（ユーザー登録分）Guidの商品マスタ（ユーザー登録分）を戻します
		/// </summary>
		/// <param name="parabyte">GoodsUWorkオブジェクト</param>
		/// <param name="readMode">検索区分</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 指定された商品マスタ（ユーザー登録分）Guidの商品マスタ（ユーザー登録分）を戻します</br>
		/// <br>Programmer : 21015　金巻　芳則</br>
		/// <br>Date       : 2007.01.24</br>
		int Read(ref byte[] parabyte , int readMode);

		/// <summary>
		/// 商品マスタ（ユーザー登録分）情報を物理削除します
		/// </summary>
		/// <param name="parabyte">GoodsUWorkオブジェクト</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 商品マスタ（ユーザー登録分）情報を物理削除します</br>
		/// <br>Programmer : 21015　金巻　芳則</br>
		/// <br>Date       : 2007.01.24</br>
		int Delete(byte[] parabyte);

		#region カスタムシリアライズ対応メソッド
		/// <summary>
		/// 商品マスタ（ユーザー登録分）LISTを全て戻します（論理削除除く）:カスタムシリアライズ
		/// </summary>
		/// <param name="goodsUWork">検索結果</param>
		/// <param name="paragoodsUWork">検索パラメータ</param>
		/// <param name="readMode">検索区分</param>
		/// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : </br>
		/// <br>Programmer : 21015　金巻　芳則</br>
		/// <br>Date       : 2007.01.24</br>
		[MustCustomSerialization]
		int Search(
			[CustomSerializationMethodParameterAttribute("MAKHN09286D","Broadleaf.Application.Remoting.ParamData.GoodsUWork")]
			out object goodsUWork,
			object paragoodsUWork, int readMode,ConstantManagement.LogicalMode logicalMode);

		/// <summary>
		/// 商品マスタ（ユーザー登録分）情報を登録、更新します
		/// </summary>
		/// <param name="goodsUWork">GoodsUWorkオブジェクト</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 商品マスタ（ユーザー登録分）情報を登録、更新します</br>
		/// <br>Programmer : 21015　金巻　芳則</br>
		/// <br>Date       : 2007.01.24</br>
        [MustCustomSerialization]
        int Write(
			[CustomSerializationMethodParameterAttribute("MAKHN09286D","Broadleaf.Application.Remoting.ParamData.GoodsUWork")]
			ref object goodsUWork
			);

		/// <summary>
		/// 商品マスタ（ユーザー登録分）情報を論理削除します
		/// </summary>
		/// <param name="goodsUWork">GoodsUWorkオブジェクト</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 商品マスタ（ユーザー登録分）情報を論理削除します</br>
		/// <br>Programmer : 21015　金巻　芳則</br>
		/// <br>Date       : 2007.01.24</br>
        [MustCustomSerialization]
        int LogicalDelete(
			[CustomSerializationMethodParameterAttribute("MAKHN09286D","Broadleaf.Application.Remoting.ParamData.GoodsUWork")]
			ref object goodsUWork
			);

		/// <summary>
		/// 論理削除商品マスタ（ユーザー登録分）情報を復活します
		/// </summary>
		/// <param name="goodsUWork">GoodsUWorkオブジェクト</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 論理削除商品マスタ（ユーザー登録分）情報を復活します</br>
		/// <br>Programmer : 21015　金巻　芳則</br>
		/// <br>Date       : 2007.01.24</br>
        [MustCustomSerialization]
        int RevivalLogicalDelete(
			[CustomSerializationMethodParameterAttribute("MAKHN09286D","Broadleaf.Application.Remoting.ParamData.GoodsUWork")]
			ref object goodsUWork
			);

        /// <summary>
        /// 指定した商品がマスタに存在しない場合に新規登録します。
        /// </summary>
        /// <param name="goodsUWork">GoodsUWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定した商品がマスタに存在しない場合に新規登録します。</br>
        /// <br>Programmer : 20081　疋田　勇人</br>
        /// <br>Date       : 2008.06.06</br>
        [MustCustomSerialization]
        int ReadWrite(
            [CustomSerializationMethodParameterAttribute("MAKHN09286D", "Broadleaf.Application.Remoting.ParamData.GoodsUWork")]
			ref object goodsUWork
            );
		#endregion


    }
}

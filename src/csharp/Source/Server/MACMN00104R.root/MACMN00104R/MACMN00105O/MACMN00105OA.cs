using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
	/// <summary>
	/// 商品構成取得DB RemoteObjectインターフェース
	/// </summary>
	/// <remarks>
	/// <br>Note       : 商品構成取得DB RemoteObject Interfaceです。</br>
	/// <br>Programmer : 21015　金巻　芳則</br>
	/// <br>Date       : 2006.12.06</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	[APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
	public interface IGoodsURelationDataDB
	{

		/// <summary>
		/// 商品構成取得LISTを全て戻します（論理削除除く）:カスタムシリアライズ
		/// </summary>
		/// <param name="retObj">検索結果</param>
		/// <param name="paraObj">検索パラメータ</param>
		/// <param name="readMode">検索区分</param>
		/// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : </br>
		/// <br>Programmer : 21015　金巻　芳則</br>
		/// <br>Date       : 2006.12.06</br>
		[MustCustomSerialization]
		int Search(
			[CustomSerializationMethodParameterAttribute("SFCMN00021C","Broadleaf.Library.Collections.CustomSerializeArrayList")]
			ref object retObj,
			object paraObj, 
            int readMode,
            ConstantManagement.LogicalMode logicalMode);

        /// <summary>
        /// 商品構成取得LISTを全て戻します（論理削除除く）:カスタムシリアライズ
        /// </summary>
        /// <param name="retObj">検索結果</param>
        /// <param name="paraObj">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2006.12.06</br>
        [MustCustomSerialization]
        int SearchMultiCondition(
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
			out object retObj,
            object paraObj,
            int readMode,
            ConstantManagement.LogicalMode logicalMode);

        #region 商品系マスタを一括で処理する為のメソッド
        ///// <summary>
        ///// 商品マスタ（ユーザー登録分）LISTを全て戻します（論理削除除く）:カスタムシリアライズ
        ///// </summary>
        ///// <param name="goodsUWork">検索結果</param>
        ///// <param name="paragoodsUWork">検索パラメータ</param>
        ///// <param name="readMode">検索区分</param>
        ///// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        ///// <returns>STATUS</returns>
        ///// <br>Note       : </br>
        ///// <br>Programmer : 21015　金巻　芳則</br>
        ///// <br>Date       : 2007.01.24</br>
        //[MustCustomSerialization]
        //int SearchRelation(
        //    [CustomSerializationMethodParameterAttribute("MAKHN09286D", "Broadleaf.Application.Remoting.ParamData.GoodsUWork")]
        //    out object goodsUWork,
        //    object paragoodsUWork, int readMode, ConstantManagement.LogicalMode logicalMode);

        /// <summary>
        /// 商品マスタ（ユーザー登録分）情報を登録、更新します
        /// </summary>
        /// <param name="goodsUWork">GoodsUWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 商品マスタ（ユーザー登録分）情報を登録、更新します</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.01.24</br>
        [MustCustomSerialization]
        int WriteRelation(
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
			ref object goodsUWork
            );

        /// <summary>
        /// 商品マスタ（ユーザー登録分）情報を新規登録(商品マスタに存在がない場合のみ)
        /// </summary>
        /// <param name="goodsUWork">GoodsUWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 商品マスタ（ユーザー登録分）情報を新規登録(商品マスタに存在がない場合のみ)</br>
        /// <br>Programmer : 20081　疋田　勇人</br>
        /// <br>Date       : 2008.06.12</br>
        [MustCustomSerialization]
        int ReadNewWriteRelation(
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
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
        int LogicalDeleteRelation(
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
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
        int RevivalLogicalDeleteRelation(
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
			ref object goodsUWork
            );

        /// <summary>
        /// 商品マスタ情報を物理削除します
        /// </summary>
        /// <param name="paraobj">商品マスタ情報オブジェクト</param>
        /// <returns></returns>
        /// <br>Note       : 商品マスタ情報を物理削除します</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2006.12.08</br>
        int DeleteRelation(object paraobj);
        #endregion

    }
}

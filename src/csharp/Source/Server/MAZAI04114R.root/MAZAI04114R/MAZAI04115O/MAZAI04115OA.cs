using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
	/// <summary>
	/// 商品在庫検索DB RemoteObjectインターフェース
	/// </summary>
	/// <remarks>
	/// <br>Note       : 商品在庫検索DB RemoteObject Interfaceです。</br>
	/// <br>Programmer : 21015　金巻　芳則</br>
	/// <br>Date       : 2007.01.18</br>
	/// <br></br>
	/// <br>Update Note: 2007.09.07 長内 DC.NS用に修正</br>
	/// </remarks>
	[APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
	public interface IGoodsStockSearchDB
	{

		/// <summary>
		/// 商品在庫検索LISTを全て戻します（論理削除除く）:カスタムシリアライズ
		/// </summary>
		/// <param name="goodsStockSearchWork">検索結果</param>
		/// <param name="paragoodsStockSearchWork">検索パラメータ</param>
		/// <param name="readMode">検索区分</param>
		/// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : </br>
		/// <br>Programmer : 21015　金巻　芳則</br>
		/// <br>Date       : 2007.01.18</br>
		[MustCustomSerialization]
		int Search(
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
			out object goodsStockSearchWork,
			object paragoodsStockSearchWork, int readMode,ConstantManagement.LogicalMode logicalMode);

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  T.Nishi 2012/04/10 ADD
        /// <summary>
        /// 商品在庫検索LISTを全て戻します（論理削除除く）:カスタムシリアライズ
        /// </summary>
        /// <param name="goodsStockSearchWork">検索結果</param>
        /// <param name="paragoodsStockSearchWork">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 20073　西 毅</br>
        /// <br>Date       :  2012/04/10</br>
        [MustCustomSerialization]
        int Search2(
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
			out object goodsStockSearchWork,
            object paragoodsStockSearchWork, int readMode, ConstantManagement.LogicalMode logicalMode);
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  T.Nishi 2012/04/10 ADD

        /*
        /// <summary>
        /// 商品在庫検索LISTを全て戻します（論理削除除く）:カスタムシリアライズ
        /// </summary>
        /// <param name="goodsStockSearchWork">検索結果</param>
        /// <param name="paragoodsStockSearchWork">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.01.18</br>
        [MustCustomSerialization]
        int SearchEachWarehouse(
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
			out object goodsStockSearchWork,
            object paragoodsStockSearchWork, int readMode, ConstantManagement.LogicalMode logicalMode);
        */
    }
}

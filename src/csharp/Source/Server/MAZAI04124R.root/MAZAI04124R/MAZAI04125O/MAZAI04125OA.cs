using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
	/// <summary>
	/// 在庫移動DB RemoteObjectインターフェース
	/// </summary>
	/// <remarks>
	/// <br>Note       : 在庫移動DB RemoteObject Interfaceです。</br>
	/// <br>Programmer : 21015　金巻　芳則</br>
	/// <br>Date       : 2007.01.19</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	[APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
	public interface IStockMoveDB
	{

		/// <summary>
		/// 指定された在庫移動Guidの在庫移動を戻します
		/// </summary>
		/// <param name="parabyte">StockMoveWorkオブジェクト</param>
		/// <param name="readMode">検索区分</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 指定された在庫移動Guidの在庫移動を戻します</br>
		/// <br>Programmer : 21015　金巻　芳則</br>
		/// <br>Date       : 2007.01.19</br>
		int Read(ref byte[] parabyte , int readMode);

        #region カスタムシリアライズ対応メソッド
		/// <summary>
		/// 在庫移動LISTを全て戻します（論理削除除く）:カスタムシリアライズ
		/// </summary>
		/// <param name="stockMoveWork">検索結果</param>
		/// <param name="parastockMoveWork">検索パラメータ</param>
		/// <param name="readMode">検索区分</param>
		/// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : </br>
		/// <br>Programmer : 21015　金巻　芳則</br>
		/// <br>Date       : 2007.01.19</br>
		[MustCustomSerialization]
		int Search(
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
			out object stockMoveWork,
			object parastockMoveWork, int readMode,ConstantManagement.LogicalMode logicalMode);

		/// <summary>
		/// 在庫移動情報を登録、更新します
		/// </summary>
        /// <param name="stockMoveWork">StockMoveWorkオブジェクト</param>
        /// <param name="retMsg">メッセージ</param>
        /// <returns>STATUS</returns>
		/// <br>Note       : 在庫移動情報を登録、更新します</br>
		/// <br>Programmer : 21015　金巻　芳則</br>
		/// <br>Date       : 2007.01.19</br>
        [MustCustomSerialization]
        int Write(
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
            ref object stockMoveWork,
            out string retMsg
			);

        /// <summary>
        /// 在庫移動データの伝票発行済区分のみを更新します
        /// </summary>
        /// <param name="objstockMoveWork">StockMoveWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 在庫移動データの伝票発行済区分のみを更新します</br>
        /// <br>Programmer : 22008　長内　数馬</br>
        /// <br>Date       : 2009.03.11</br>
        [MustCustomSerialization]
        int WriteSlipPrintFinishCd(
            [CustomSerializationMethodParameterAttribute("MAZAI04126D", "Broadleaf.Application.Remoting.ParamData.StockMoveWork")]
            ref object objstockMoveWork
            );

		/// <summary>
		/// 在庫移動情報を論理削除します
		/// </summary>
		/// <param name="stockMoveWork">StockMoveWorkオブジェクト</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 在庫移動情報を論理削除します</br>
		/// <br>Programmer : 21015　金巻　芳則</br>
		/// <br>Date       : 2007.01.19</br>
        [MustCustomSerialization]
        int LogicalDelete(
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
			ref object stockMoveWork
			);

		/// <summary>
		/// 論理削除在庫移動情報を復活します
		/// </summary>
		/// <param name="stockMoveWork">StockMoveWorkオブジェクト</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 論理削除在庫移動情報を復活します</br>
		/// <br>Programmer : 21015　金巻　芳則</br>
		/// <br>Date       : 2007.01.19</br>
        [MustCustomSerialization]
        int RevivalLogicalDelete(
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
			ref object stockMoveWork
			);

        /// <summary>
        /// 在庫移動情報を論理削除します
        /// </summary>
        /// <param name="stockMoveWork">StockMoveWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 在庫移動情報を論理削除します</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.01.19</br>
        [MustCustomSerialization]
        int Delete(
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
			ref object stockMoveWork
            );
        #endregion

	}
}

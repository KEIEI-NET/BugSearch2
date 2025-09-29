using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
	/// <summary>
	/// 在庫受払履歴データDB RemoteObjectインターフェース
	/// </summary>
	/// <remarks>
	/// <br>Note       : 在庫受払履歴データDB RemoteObject Interfaceです。</br>
	/// <br>Programmer : 21015　金巻　芳則</br>
	/// <br>Date       : 2007.01.30</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	[APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
	public interface IStockAcPayHistDB
	{

		/// <summary>
		/// 指定された在庫受払履歴データGuidの在庫受払履歴データを戻します
		/// </summary>
		/// <param name="parabyte">StockAcPayHistWorkオブジェクト</param>
		/// <param name="readMode">検索区分</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 指定された在庫受払履歴データGuidの在庫受払履歴データを戻します</br>
		/// <br>Programmer : 21015　金巻　芳則</br>
		/// <br>Date       : 2007.01.30</br>
		int Read(ref byte[] parabyte , int readMode);

		/// <summary>
		/// 在庫受払履歴データ情報を物理削除します
		/// </summary>
        /// <param name="paraobj">StockAcPayHistWorkオブジェクト</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 在庫受払履歴データ情報を物理削除します</br>
		/// <br>Programmer : 21015　金巻　芳則</br>
		/// <br>Date       : 2007.01.30</br>
		int Delete(object paraobj);

		#region カスタムシリアライズ対応メソッド
		/// <summary>
		/// 在庫受払履歴データLISTを全て戻します（論理削除除く）:カスタムシリアライズ
		/// </summary>
		/// <param name="stockAcPayHistWork">検索結果</param>
		/// <param name="parastockAcPayHistWork">検索パラメータ</param>
		/// <param name="readMode">検索区分</param>
		/// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : </br>
		/// <br>Programmer : 21015　金巻　芳則</br>
		/// <br>Date       : 2007.01.30</br>
		[MustCustomSerialization]
		int Search(
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
			out object stockAcPayHistWork,
			object parastockAcPayHistWork, int readMode,ConstantManagement.LogicalMode logicalMode);

		/// <summary>
		/// 在庫受払履歴データ情報を登録、更新します
		/// </summary>
		/// <param name="stockAcPayHistWork">StockAcPayHistWorkオブジェクト</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 在庫受払履歴データ情報を登録、更新します</br>
		/// <br>Programmer : 21015　金巻　芳則</br>
		/// <br>Date       : 2007.01.30</br>
        [MustCustomSerialization]
        int Write(
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
			ref object stockAcPayHistWork
			);

		/// <summary>
		/// 在庫受払履歴データ情報を論理削除します
		/// </summary>
		/// <param name="stockAcPayHistWork">StockAcPayHistWorkオブジェクト</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 在庫受払履歴データ情報を論理削除します</br>
		/// <br>Programmer : 21015　金巻　芳則</br>
		/// <br>Date       : 2007.01.30</br>
        [MustCustomSerialization]
        int LogicalDelete(
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
			ref object stockAcPayHistWork
			);

        /*
		/// <summary>
		/// 論理削除在庫受払履歴データ情報を復活します
		/// </summary>
		/// <param name="stockAcPayHistWork">StockAcPayHistWorkオブジェクト</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 論理削除在庫受払履歴データ情報を復活します</br>
		/// <br>Programmer : 21015　金巻　芳則</br>
		/// <br>Date       : 2007.01.30</br>
        [MustCustomSerialization]
        int RevivalLogicalDelete(
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
			ref object stockAcPayHistWork
			);
        */ 
		#endregion
	}
}

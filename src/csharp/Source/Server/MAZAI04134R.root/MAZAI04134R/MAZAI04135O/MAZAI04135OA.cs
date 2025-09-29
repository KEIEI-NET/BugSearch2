using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
	/// <summary>
	/// 在庫DB RemoteObjectインターフェース
	/// </summary>
	/// <remarks>
	/// <br>Note       : 在庫DB RemoteObject Interfaceです。</br>
	/// <br>Programmer : 21015　金巻　芳則</br>
	/// <br>Date       : 2007.01.18</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	[APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
	public interface IStockDB
	{

		/// <summary>
		/// 指定された在庫Guidの在庫を戻します
		/// </summary>
		/// <param name="parabyte">StockWorkオブジェクト</param>
		/// <param name="readMode">検索区分</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 指定された在庫Guidの在庫を戻します</br>
		/// <br>Programmer : 21015　金巻　芳則</br>
		/// <br>Date       : 2007.01.18</br>
		int Read(ref byte[] parabyte , int readMode);

		/// <summary>
		/// 在庫情報を物理削除します
		/// </summary>
		/// <param name="parabyte">StockWorkオブジェクト</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 在庫情報を物理削除します</br>
		/// <br>Programmer : 21015　金巻　芳則</br>
		/// <br>Date       : 2007.01.18</br>
		int Delete(byte[] parabyte);

		#region カスタムシリアライズ対応メソッド
		/// <summary>
		/// 在庫LISTを全て戻します（論理削除除く）:カスタムシリアライズ
		/// </summary>
		/// <param name="stockWork">検索結果</param>
		/// <param name="parastockWork">検索パラメータ</param>
		/// <param name="readMode">検索区分</param>
		/// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : </br>
		/// <br>Programmer : 21015　金巻　芳則</br>
		/// <br>Date       : 2007.01.18</br>
		[MustCustomSerialization]
		int Search(
			[CustomSerializationMethodParameterAttribute("MAZAI04136D","Broadleaf.Application.Remoting.ParamData.StockWork")]
			out object stockWork,
			object parastockWork, int readMode,ConstantManagement.LogicalMode logicalMode);

		/// <summary>
		/// 在庫情報を登録、更新します
		/// </summary>
		/// <param name="stockWork">StockWorkオブジェクト</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 在庫情報を登録、更新します</br>
		/// <br>Programmer : 21015　金巻　芳則</br>
		/// <br>Date       : 2007.01.18</br>
        [MustCustomSerialization]
        int Write(
            [CustomSerializationMethodParameterAttribute("MAZAI04136D", "Broadleaf.Application.Remoting.ParamData.StockWork")]
			ref object stockWork
			);

		/// <summary>
		/// 在庫情報を論理削除します
		/// </summary>
		/// <param name="stockWork">StockWorkオブジェクト</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 在庫情報を論理削除します</br>
		/// <br>Programmer : 21015　金巻　芳則</br>
		/// <br>Date       : 2007.01.18</br>
        [MustCustomSerialization]
        int LogicalDelete(
            [CustomSerializationMethodParameterAttribute("MAZAI04136D", "Broadleaf.Application.Remoting.ParamData.StockWork")]
			ref object stockWork
			);
        
		/// <summary>
		/// 論理削除在庫情報を復活します
		/// </summary>
		/// <param name="stockWork">StockWorkオブジェクト</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 論理削除在庫情報を復活します</br>
		/// <br>Programmer : 21015　金巻　芳則</br>
		/// <br>Date       : 2007.01.18</br>
        [MustCustomSerialization]
        int RevivalLogicalDelete(
            [CustomSerializationMethodParameterAttribute("MAZAI04136D", "Broadleaf.Application.Remoting.ParamData.StockWork")]
			ref object stockWork
			);
		#endregion

        //IOWriteテスト用
        /// <summary>
        /// 在庫情報を登録、更新します
        /// </summary>
        /// <param name="stockWork">StockWorkオブジェクト</param>
        /// <param name="retMsg">メッセージ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 在庫情報を登録、更新します</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.01.18</br>
        [MustCustomSerialization]
        int Write(
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
			ref object stockWork,
            out string retMsg
            );
    }
}

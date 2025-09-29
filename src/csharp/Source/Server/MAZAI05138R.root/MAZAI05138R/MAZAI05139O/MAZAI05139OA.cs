using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
	/// <summary>
	/// 棚卸数入力DB RemoteObjectインターフェース
	/// </summary>
	/// <remarks>
	/// <br>Note       : 棚卸数入力DB RemoteObject Interfaceです。</br>
	/// <br>Programmer : 22035 三橋 弘憲　  </br>
	/// <br>Date       : 2007.04.07</br>
	/// <br></br>
    /// <br>Update Note: 2013/03/01 yangyi</br>
    /// <br>管理番号   : 10801804-00 2013/03/06配信分の緊急対応</br>
    /// <br>           : Redmine#34175 　棚卸業務のサーバー負荷軽減対策</br>
	/// </remarks>
	[APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]		//←アプリケーションサーバーの接続先を属性で指示
	public interface IInventoryDataUpdateDB
	{		
		/// <summary>
		/// 棚卸数入力情報を登録、更新します
		/// </summary>
        /// <param name="paraList">InventoryDataUpdateWorkオブジェクト</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 棚卸数入力情報を登録、更新します</br>
		/// <br>Programmer : 22035 三橋 弘憲　  </br>
		/// <br>Date       : 2007.04.07</br>
        [MustCustomSerialization]
        int Write(
            [CustomSerializationMethodParameterAttribute("MAZAI05136D", "Broadleaf.Application.Remoting.ParamData.InventoryDataUpdateWork")]
			ref object paraList);

        // --- ADD 2009/12/03 ---------->>>>>
        /// <summary>
        /// 在庫総数取得処理
        /// </summary>
        /// <param name="objIvtDataWork">棚卸データ更新ワーク</param>
        /// <param name="stockTotal">在庫総数</param>
        /// <param name="arrivalCnt">入荷数</param>
        /// <param name="shipmentCnt">出荷数</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : 在庫総数取得処理を行います</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009/12/03</br>
        /// </remarks>
        int GetStockTotal(object objIvtDataWork, ref double stockTotal, ref double arrivalCnt, ref double shipmentCnt);
        // --- ADD 2009/12/03 ----------<<<<<

        // --- ADD yangyi 2013/03/01 for Redmine#34175 ------->>>>>>>>>>>
        /// <summary>
        /// 棚卸入力検索結果クラスLISTを全て戻します
        /// </summary>
        /// <param name="retobj">検索結果</param>
        /// <param name="paraobj">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : yangyi</br>
        /// <br>Date       : 2013/02/19</br>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
            out object retobj,
            object paraobj,
            int readMode,
            ConstantManagement.LogicalMode logicalMode);
        // --- ADD yangyi 2013/03/01 for Redmine#34175 -------<<<<<<<<<<<
	}
}

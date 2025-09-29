using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
	/// <summary>
	/// 棚卸準備処理DB RemoteObjectインターフェース
	/// </summary>
	/// <remarks>
	/// <br>Note       : 棚卸準備処理DB RemoteObject Interfaceです。</br>
	/// <br>Programmer : 22035 三橋 弘憲</br>
	/// <br>Date       : 2007.04.04</br>
	/// <br></br>
    /// <br>Update Note : 2009/11/30 張凱 保守依頼③対応</br>
    /// <br>             既存データ存在時の処理内容を変更</br>
	/// </remarks>
	[APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]		//←アプリケーションサーバーの接続先を属性で指示
    public interface IInventoryExtDB
	{
		/// <summary>
		/// 棚卸準備処理(準備処理履歴)LISTを全て戻します（論理削除除く）
		/// </summary>
		/// <param name="retobj">検索結果(準備処理履歴)</param>
		/// <param name="paraobj">検索パラメータ</param>
		/// <param name="readMode">検索区分</param>
		/// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : </br>
		/// <br>Programmer : 22035 三橋 弘憲</br>
		/// <br>Date       : 2007.04.04</br>
        [MustCustomSerialization]
		int Search(
            [CustomSerializationMethodParameterAttribute("MAZAI05116D", "Broadleaf.Application.Remoting.ParamData.InventDataPreWork")]
			out object retobj,
			object paraobj,
			int readMode,
            ConstantManagement.LogicalMode logicalMode);

		/// <summary>
		/// 棚卸データを検索し、その情報を登録・更新と、棚卸準備処理LIST(準備処理履歴)を全て戻します
		/// </summary>
        /// <param name="retobj">検索結果(準備処理履歴)</param>
		/// <param name="parabyte">検索パラメータ</param>
		/// <param name="readMode">検索区分</param>
		/// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="statusMSG">statusに対するメッセージ</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 棚卸データを検索し、その情報を登録・更新と、棚卸準備処理LIST(準備処理履歴)を全て戻します</br>
		/// <br>Programmer : 22035 三橋 弘憲</br>
		/// <br>Date       : 2007.04.04</br>
        [MustCustomSerialization]
		int SearchWrite(
            [CustomSerializationMethodParameterAttribute("MAZAI05116D", "Broadleaf.Application.Remoting.ParamData.InventDataPreWork")]
            out object retobj,
			object paraobj,
			int readMode,
            ConstantManagement.LogicalMode logicalMode,
            out string statusMSG);

        // --- ADD 2009/11/30 ---------->>>>>
        /// <summary>
        /// 棚卸データを検索し、棚卸データ存在チェックflagを戻します
        /// </summary>
        /// <param name="retobj">存在チェックflag</param>
        /// <param name="parabyte">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="statusMSG">statusに対するメッセージ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 棚卸データを検索し、棚卸データ存在チェックflagを戻します</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009.11.30</br>
        [MustCustomSerialization]
        int SearchRepateDate(
            out object retobj,
            object paraobj,
            int readMode,
            ConstantManagement.LogicalMode logicalMode,
            out string statusMSG);
        // --- ADD 2009/11/30 ----------<<<<<

        /// <summary>
        /// 在庫マスタを検索し、棚卸準備処理LIST(棚卸データ)を全て戻します
        /// </summary>
        /// <param name="retobj">検索結果(棚卸データ)</param>
        /// <param name="parabyte">検索パラメータ</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="statusMSG">statusに対するメッセージ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 在庫マスタを検索し、棚卸準備処理LIST(棚卸データ)を全て戻します
        /// <br>Programmer : 22035 三橋 弘憲</br>
        /// <br>Date       : 2007.04.04</br>
        [MustCustomSerialization]
        int SearchInventoryDate(
            [CustomSerializationMethodParameterAttribute("MAZAI05116D", "Broadleaf.Application.Remoting.ParamData.InventoryDataWork")]
            out object retobj,
            object paraobj,
            ConstantManagement.LogicalMode logicalMode,
            out string statusMSG);

        /// <summary>
        /// 棚卸データを検索し、その情報を登録・更新と、棚卸準備処理LIST(準備処理履歴)を全て戻します
        /// </summary>
        /// <param name="retobj">検索結果(準備処理履歴)</param>
        /// <param name="parabyte">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="statusMSG">statusに対するメッセージ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 棚卸データを検索し、その情報を登録・更新と、棚卸準備処理LIST(準備処理履歴)を全て戻します</br>
        /// <br>Programmer : 22035 三橋 弘憲</br>
        /// <br>Date       : 2007.04.04</br>
        [MustCustomSerialization]
        int WriteInventoryDate(
            [CustomSerializationMethodParameterAttribute("MAZAI05116D", "Broadleaf.Application.Remoting.ParamData.InventDataPreWork")]
            out object retobj,
            object paraobj,
            object paraobj2,
            ConstantManagement.LogicalMode logicalMode,
            out string statusMSG);

        /// <summary>
        /// 棚卸データ(準備処理履歴)を登録、更新します
        /// </summary>
        /// <param name="parabyte">PrtIvntHisWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 棚卸データ(準備処理履歴)を登録、更新します</br>
        /// <br>Programmer : 22035 三橋 弘憲</br>
        /// <br>Date       : 2007.04.04</br>
        int Write(ref byte[] parabyte);

        /// <summary>
        /// 棚卸データ(準備処理履歴)を物理削除します
        /// </summary>
        /// <param name="parabyte">PrtIvntHisWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 棚卸データ(準備処理履歴)を物理削除します</br>
        /// <br>Programmer : 22035 三橋 弘憲</br>
        /// <br>Date       : 2007.04.04</br>
        int Delete(byte[] parabyte);

        /// <summary>
        /// 棚卸データ(在庫、製番在庫)を物理削除します
        /// </summary>
        /// <param name="parabyte">InventoryDataWorkオブジェクト</param>
        /// <param name="parabyte">PrtIvntHisWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 棚卸データ(準備処理履歴)を物理削除します</br>
        /// <br>Programmer : 22035 三橋 弘憲</br>
        /// <br>Date       : 2007.04.04</br>
        int DeleteInvent(byte[] parabyte, out byte[] retbyte);

        // ADD yangyi 2012/06/08 Redmine#30282 ------------->>>>>
        /// <summary>
        /// 棚卸データを検索します
        /// </summary>
        /// <param name="retobj">存在チェックflag</param>
        /// <param name="parabyte">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="statusMSG">statusに対するメッセージ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 棚卸データを検索し、棚卸データ存在チェックflagを戻します</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009.11.30</br>
        [MustCustomSerialization]
        int SearchInventoryData(
            [CustomSerializationMethodParameterAttribute("MAZAI05116D", "Broadleaf.Application.Remoting.ParamData.InventoryDataWork")]
            out object retobj,
            object paraobj,
            ConstantManagement.LogicalMode logicalMode);
        // ADD yangyi 2012/06/08 Redmine#30282 -------------<<<<<
	}
}

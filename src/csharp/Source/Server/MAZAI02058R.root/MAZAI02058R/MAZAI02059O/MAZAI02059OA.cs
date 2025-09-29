using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
	/// <summary>
    /// 在庫・倉庫移動確認表DB RemoteObjectインターフェース
	/// </summary>
	/// <remarks>
    /// <br>Note       : 在庫・倉庫移動確認表DB RemoteObject Interfaceです。</br>
	/// <br>Programmer : 22035 三橋 弘憲</br>
	/// <br>Date       : 2007.03.17</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	[APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IStockAdjustWorkDB
	{
		/// <summary>
        /// 在庫移動確認表LISTを全て戻します（論理削除除く）
		/// </summary>
        /// <param name="stockAdjustResultWork">検索結果</param>
        /// <param name=" stockAdjustCndtnWork">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
		/// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : </br>
		/// <br>Programmer : 22035 三橋 弘憲</br>
		/// <br>Date       : 2007.03.17</br>
        [MustCustomSerialization]
		int Search(
            [CustomSerializationMethodParameterAttribute("MAZAI02056D", "Broadleaf.Application.Remoting.ParamData.StockAdjustResultWork")]
			out object stockAdjustResultWork,
            object stockAdjustCndtnWork,
			int readMode,
            ConstantManagement.LogicalMode logicalMode);
	}
}

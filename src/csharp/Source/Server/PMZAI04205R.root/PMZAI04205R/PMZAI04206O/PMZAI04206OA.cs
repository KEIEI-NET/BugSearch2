using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 棚卸表示DB RemoteObjectインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : 棚卸表示DB RemoteObject Interfaceです。</br>
    /// <br>Programmer : 23012 畠中 啓次朗</br>
    /// <br>Date       : 2008.10.03</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IInventoryDtDspDB
    {
        #region カスタムシリアライズ対応メソッド
        /// <summary>
        /// 棚卸表示データを全て戻します（論理削除除く）:カスタムシリアライズ
        /// </summary>
        /// <param name="inventoryDataDspResultWork">検索結果</param>
        /// <param name="inventoryDataDspParamWork">検索パラメータ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 23012 畠中 啓次朗</br>
        /// <br>Date       : 2008.10.03</br>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("PMZAI04207D", "Broadleaf.Application.Remoting.ParamData.InventoryDataDspResultWork")]
            out object inventoryDataDspResultWork,
            object inventoryDataDspParamWork);
        #endregion
    }
}

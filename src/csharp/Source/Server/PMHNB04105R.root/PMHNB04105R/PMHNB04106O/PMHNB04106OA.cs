using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 出荷部品表示DB RemoteObjectインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : 出荷部品表示DB RemoteObject Interfaceです。</br>
    /// <br>Programmer : 23012 畠中 啓次朗</br>
    /// <br>Date       : 2008.10.03</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface ISPartsDspDB
    {
        #region カスタムシリアライズ対応メソッド
        /// <summary>
        /// 出荷部品表示データを全て戻します（論理削除除く）:カスタムシリアライズ
        /// </summary>
        /// <param name="shipmentPartsDspResultWork">検索結果</param>
        /// <param name="shipmentPartsDspParamWork">検索パラメータ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 23012 畠中 啓次朗</br>
        /// <br>Date       : 2008.10.03</br>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("PMHNB04107D", "Broadleaf.Application.Remoting.ParamData.ShipmentPartsDspResultWork")]
            out object shipmentPartsDspResultWork,
            object shipmentPartsDspParamWork);
        #endregion
    }
}

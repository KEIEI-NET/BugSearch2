using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 代替マスタ新旧関連表示DB RemoteObjectインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : 代替マスタ新旧関連表示DB RemoteObject Interfaceです。</br>
    /// <br>Programmer : 23012 畠中 啓次朗</br>
    /// <br>Date       : 2008.10.01</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IPartsSubstDspDB
    {
        #region カスタムシリアライズ対応メソッド
        /// <summary>
        /// 代替マスタ新旧関連表示データを全て戻します（論理削除除く）:カスタムシリアライズ
        /// </summary>
        /// <param name="partsSubstUSearchResultWork">検索結果</param>
        /// <param name="partsSubstUSearchParamWork">検索パラメータ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 23012 畠中 啓次朗</br>
        /// <br>Date       : 2008.10.01</br>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("PMKEN09086D", "Broadleaf.Application.Remoting.ParamData.PartsSubstUSearchResultWork")]
            out object partsSubstUSearchResultWork,
            object partsSubstUSearchParamWork);
        #endregion
    }
}

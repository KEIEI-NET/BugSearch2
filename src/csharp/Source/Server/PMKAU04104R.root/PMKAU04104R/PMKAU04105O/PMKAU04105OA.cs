using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 更新履歴表示DB RemoteObjectインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : 更新履歴表示DB RemoteObject Interfaceです。</br>
    /// <br>Programmer : 20081</br>
    /// <br>Date       : 2008.08.11</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IUpdHisDspDB
    {
        #region カスタムシリアライズ対応メソッド
        /// <summary>
        /// 更新履歴表示データを全て戻します（論理削除除く）:カスタムシリアライズ
        /// </summary>
        /// <param name="rsltInfo_UpdHisDspWork">検索結果</param>
        /// <param name="extrInfo_UpdHisDspWork">検索パラメータ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 20081</br>
        /// <br>Date       : 2008.08.11</br>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("PMKAU04106D", "Broadleaf.Application.Remoting.ParamData.RsltInfo_UpdHisDspWork")]
            out object rsltInfo_UpdHisDspWork,
            object extrInfo_UpdHisDspWork);
        #endregion
    }
}

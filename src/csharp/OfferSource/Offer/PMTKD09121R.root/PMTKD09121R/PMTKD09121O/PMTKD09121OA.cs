using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// AutoEstmPtNoChgDB RemoteObjectインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : AutoEstmPtNoChgDB RemoteObject Interfaceです。</br>
    /// <br>Programmer : 20073　西　毅</br>
    /// <br>Date       : 2012.05.25</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_OfferAP)]

    public interface IAutoEstmPtNoChgDB
    {
        #region カスタムシリアライズ対応メソッド
        /// <summary>
        /// 自動見積部品番号変換マスタLISTを全て戻します（論理削除除く）:カスタムシリアライズ
        /// </summary>
        /// <param name="AutoEstmPtNoChgWork">検索結果</param>
        /// <param name="paraAutoEstmPtNoChgWork">検索パラメータ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 20073　西　毅</br>
        /// <br>Date       : 2012.05.25</br>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("PMTKD09122D", "Broadleaf.Application.Remoting.ParamData.AutoEstmPtNoChgWork")]
			out object autoEstmPtNoChgWork,
       object paraAutoEstmPtNoChgWork);
        #endregion

    }

}

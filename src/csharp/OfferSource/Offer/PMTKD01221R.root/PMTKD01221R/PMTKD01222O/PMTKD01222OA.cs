using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// SetPartsDB RemoteObjectインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : SetPartsDB RemoteObject Interfaceです。</br>
    /// <br>Programmer : 30350　櫻井　亮太</br>
    /// <br>Date       : 2009.06.22</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_OfferAP)]

    public interface ISetPartsDB
    {
        /// <summary>
        /// セットマスタLISTを全て戻します（論理削除除く）:カスタムシリアライズ
        /// </summary>
        /// <param name="SetPartsWork">検索結果</param>
        /// <param name="paraSetPartsWork">検索パラメータ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 30350 櫻井　亮太</br>
        /// <br>Date       : 2009.06.22</br>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("PMTKD01223D", "Broadleaf.Application.Remoting.ParamData.SetPartsWork")]
			out object SetPartsWork,
       object paraSetPartsWork);

    }

}

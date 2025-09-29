using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// TbsPartsCodeDB RemoteObjectインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : TbsPartsCodeDB RemoteObject Interfaceです。</br>
    /// <br>Programmer : 30350　櫻井　亮太</br>
    /// <br>Date       : 2009.06.22</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_OfferAP)]

    public interface IJoinPartsDB
    {
        /// <summary>
        /// 結合マスタLISTを全て戻します（論理削除除く）:カスタムシリアライズ
        /// </summary>
        /// <param name="TbsPartsCodeWork">検索結果</param>
        /// <param name="paraTbsPartsCodeWork">検索パラメータ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 30350 櫻井　亮太</br>
        /// <br>Date       : 2009.06.22</br>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("PMTKD01213D", "Broadleaf.Application.Remoting.ParamData.JoinPartsWork")]
			out object joinPartsWork,
        object paraJoinPartsWork);

    }

}

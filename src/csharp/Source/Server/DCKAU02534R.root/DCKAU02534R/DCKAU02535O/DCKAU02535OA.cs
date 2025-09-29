using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 回収予定表DB RemoteObjectインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : 回収予定表DB RemoteObject Interfaceです。</br>
    /// <br>Programmer : 980081 山田 明友</br>
    /// <br>Date       : 2007.11.15</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface ICollectProgramDB
    {

        /// <summary>
        /// 回収予定表を戻します
        /// </summary>
        /// <param name="retObj">検索結果</param>
        /// <param name="paraObj">検索パラメータ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 980081 山田 明友</br>
        /// <br>Date       : 2007.11.15</br>
        [MustCustomSerialization]
        int SearchCollectProgram([CustomSerializationMethodParameterAttribute("DCKAU02536D", "Broadleaf.Application.Remoting.ParamData.RsltInfo_CollectPlanWork")]out object retObj, object paraObj);

    }
}

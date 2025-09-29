using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 過年度統計表DB RemoteObjectインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : 過年度統計表DB RemoteObject Interfaceです。</br>
    /// <br>Programmer : 980081 山田 明友</br>
    /// <br>Date       : 2007.12.04</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IPastYearStatisticsDB
    {

        /// <summary>
        /// 過年度統計表を戻します
        /// </summary>
        /// <param name="retObj">検索結果</param>
        /// <param name="paraObj">検索パラメータ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の過年度統計表を戻します</br>
        /// <br>Programmer : 980081 山田 明友</br>
        /// <br>Date       : 2007.12.04</br>
        [MustCustomSerialization]
        int SearchPastYearStatistics([CustomSerializationMethodParameterAttribute("DCTOK02186D", "Broadleaf.Application.Remoting.ParamData.RsltInfo_PastYearStatisticsWork")]out object retObj, object paraObj);

    }
}

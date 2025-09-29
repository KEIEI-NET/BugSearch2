using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 前年対比表DB RemoteObjectインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : 前年対比表DB RemoteObject Interfaceです。</br>
    /// <br>Programmer : 980081 山田 明友</br>
    /// <br>Date       : 2007.11.29</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IPrevYearComparisonDB
    {

        /// <summary>
        /// 前年対比表を戻します
        /// </summary>
        /// <param name="retObj">検索結果</param>
        /// <param name="paraObj">検索パラメータ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の前年対比表を戻します</br>
        /// <br>           : 12ヶ月を超える範囲を指定されたら該当データ無しとします</br>
        /// <br>Programmer : 980081 山田 明友</br>
        /// <br>Date       : 2007.11.29</br>
        [MustCustomSerialization]
        int SearchPrevYearComparison([CustomSerializationMethodParameterAttribute("DCTOK02106D", "Broadleaf.Application.Remoting.ParamData.RsltInfo_PrevYearComparisonWork")]out object retObj, object paraObj);

    }
}

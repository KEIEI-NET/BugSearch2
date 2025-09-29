using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 検索品目制御 DBRemoteObjectインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : 検索品目制御 DBRemoteObjectインターフェースです。</br>
    /// <br>Programmer : 30290</br>
    /// <br>Date       : 2008.11.11</br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_OfferAP)]

    public interface ISearchPrtCtlDB
    {
        /// <summary>
        /// 指定された検索品目制御を戻します
        /// </summary>
        /// <param name="partsPosCodeList">検索結果(ArrayList)</param>
        /// <param name="paraSearchPrtCtlWork">検索パラメータ[SearchPrtCtlWork/null : 全件検索]</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 30290</br>
        /// <br>Date       : 2008.11.11</br>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("PMTKD09113D", "Broadleaf.Application.Remoting.ParamData.SearchPrtCtlWork")]
			out object partsPosCodeList,
            object paraSearchPrtCtlWork);
    }

}

using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 売掛残高元帳DB RemoteObjectインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : 売掛残高元帳DB RemoteObject Interfaceです。</br>
    /// <br>Programmer : 22008 長内 数馬</br>
    /// <br>Date       : 2007.11.09</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IAccRecBalanceLedgerDB
    {

        /// <summary>
        /// 売掛残高元帳を戻します
        /// </summary>
        /// <param name="retObj">検索結果</param>
        /// <param name="paraObj">検索パラメータ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2007.11.09</br>
        [MustCustomSerialization]
        int SearchAccRecBalanceLedger(
          [CustomSerializationMethodParameterAttribute("DCKAU02616D", "Broadleaf.Application.Remoting.ParamData.RsltInfo_AccRecBalanceWork")]
          out object retObj, object paraObj);

    }
}

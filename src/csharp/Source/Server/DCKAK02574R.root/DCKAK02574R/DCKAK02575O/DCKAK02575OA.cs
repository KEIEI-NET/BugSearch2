using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 支払残高元帳DB RemoteObjectインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : 支払残高元帳DB RemoteObject Interfaceです。</br>
    /// <br>Programmer : 980081 山田 明友</br>
    /// <br>Date       : 2007.10.03</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IPaymentBalanceLedgerDB
    {

        /// <summary>
        /// 支払残高元帳を戻します
        /// </summary>
        /// <param name="retObj">検索結果</param>
        /// <param name="paraObj">検索パラメータ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 980081 山田 明友</br>
        /// <br>Date       : 2007.10.03</br>
        [MustCustomSerialization]
        int SearchPaymentBalanceLedger([CustomSerializationMethodParameterAttribute("DCKAK02576D", "Broadleaf.Application.Remoting.ParamData.RsltInfo_PaymentBalanceWork")]out object retObj, object paraObj);

    }
}

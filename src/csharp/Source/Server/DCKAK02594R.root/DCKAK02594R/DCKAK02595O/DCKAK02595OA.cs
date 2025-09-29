using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 買掛残高元帳DB RemoteObjectインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : 買掛残高元帳DB RemoteObject Interfaceです。</br>
    /// <br>Programmer : 22008 長内 数馬</br>
    /// <br>Date       : 2007.11.09</br>
    /// <br></br>
    /// <br>Update Note: 2012/10/02 FSI菅原　要 仕入総括処理対応</br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IAccPayBalanceLedgerDB
    {

        /// <summary>
        /// 買掛残高元帳を戻します
        /// </summary>
        /// <param name="retObj">検索結果</param>
        /// <param name="paraObj">検索パラメータ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2007.11.09</br>
        [MustCustomSerialization]
        int SearchAccPayBalanceLedger(
          [CustomSerializationMethodParameterAttribute("DCKAK02596D", "Broadleaf.Application.Remoting.ParamData.RsltInfo_AccPayBalanceWork")]
          out object retObj, object paraObj);

        // ---------- ADD 2012/10/02 ---------->>>>>
        /// <summary>
        /// 買掛残高元帳を戻します（仕入総括オプション有効時）
        /// </summary>
        /// <param name="retObj">検索結果</param>
        /// <param name="paraObj">検索パラメータ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : FSI菅原　要</br>
        /// <br>Date       : 2012/10/02</br>
        [MustCustomSerialization]
        int SearchAccPayBalanceLedgerForSumOptOn(
          [CustomSerializationMethodParameterAttribute("DCKAK02596D", "Broadleaf.Application.Remoting.ParamData.RsltInfo_AccPayBalanceWork")]
          out object retObj, object paraObj);
        // ---------- ADD 2012/10/02 ----------<<<<<
    }
}

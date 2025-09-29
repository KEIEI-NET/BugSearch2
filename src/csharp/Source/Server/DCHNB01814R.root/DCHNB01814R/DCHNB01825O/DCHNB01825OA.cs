using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 売上データDB RemoteObjectインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : 売上データDB RemoteObject Interfaceです。</br>
    /// <br>Programmer : 21112　久保田　誠</br>
    /// <br>Date       : 2007.11.21</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)] // アプリケーションの接続先を属性で指定
    public interface ISalesSlipDB
    {
        /// <summary>
        /// 明細情報読込
        /// </summary>
        /// <param name="paraList">売上明細抽出条件リスト</param>
        /// <param name="retList">売上明細データリスト</param>
        /// <returns>STATUS</returns>
        [MustCustomSerialization]
        int ReadSalesDetailWork(
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
            ref object paraList,
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
            ref object retList);
    }
}

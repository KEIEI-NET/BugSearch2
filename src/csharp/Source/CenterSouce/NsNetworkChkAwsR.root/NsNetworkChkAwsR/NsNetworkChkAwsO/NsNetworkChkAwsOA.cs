using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// ネットワーク通信処理DBRemoteObjectインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : ネットワーク通信処理DB RemoteObject Interfaceです。</br>
    /// <br>Programmer : 朱宝軍</br>
    /// <br>Date       : 2019.01.02</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_Center_UserAP)]
    public interface IAWSCommTstRsltDB
    {
        /// <summary>
        /// ネットワーク通信テスト結果登録処理
        /// </summary>
        /// <param name="aWSCommTstRsltWorkList">ネットワーク通信テスト結果パラメータリスト</param>
        /// <param name="msgDiv">メッセージ表示区分</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>STATUS</returns>
        [MustCustomSerialization]
        int WriteDBData(
            [CustomSerializationMethodParameterAttribute("NsNetworkChkAwsD", "Broadleaf.Application.Remoting.ParamData.AWSComRsltWork")]
            ref object aWSCommTstRsltWorkList,
            out bool msgDiv,
            out string errMsg);
    }
}

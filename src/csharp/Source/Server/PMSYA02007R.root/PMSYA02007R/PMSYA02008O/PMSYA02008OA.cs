//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 車輌別出荷実績表
// プログラム概要   : 車輌別出荷実績表帳票を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 張莉莉
// 作 成 日  2009/09/15  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日               修正内容 : 
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 車輌別出荷実績表DB RemoteObjectインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : 車輌別出荷実績表DB RemoteObject Interfaceです。</br>
    /// <br>Programmer : 張莉莉</br>
    /// <br>Date       : 2009.09.15</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]

    public interface ICarShipResultDB
    {
        /// <summary>
        /// 車輌別出荷実績表を全て戻します（論理削除除く）:カスタムシリアライズ
        /// </summary>
        /// <param name="carShipResultWork">検索結果</param>
        /// <param name="carShipRsltCndtnWork">検索パラメータ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 張莉莉</br>
        /// <br>Date       : 2009.09.15</br>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("PMSYA02009D", "Broadleaf.Application.Remoting.ParamData.CarShipResultWork")]
            out object carShipResultWork,
          object carShipRsltCndtnWork);

    }
}

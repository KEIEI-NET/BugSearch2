//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 仕入チェックリスト
// プログラム概要   : 仕入チェックリスト帳票を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 張莉莉
// 作 成 日  2009/05/10  修正内容 : 新規作成
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
    /// 仕入チェックリストDB RemoteObjectインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : 仕入チェックリストDB RemoteObject Interfaceです。</br>
    /// <br>Programmer : 張莉莉</br>
    /// <br>Date       : 2009.05.10</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]

    public interface IStockSlipResultDB
    {
        /// <summary>
        /// 仕入チェックリストを全て戻します（論理削除除く）:カスタムシリアライズ
        /// </summary>
        /// <param name="stockSlipResultWork">検索結果</param>
        /// <param name="stockSlipCndtnWork">検索パラメータ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 張莉莉</br>
        /// <br>Date       : 2009.05.10</br>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("PMKOU02059D", "Broadleaf.Application.Remoting.ParamData.StockSlipResultWork")]
            out object stockSlipResultWork,
            object stockSlipCndtnWork);

    }
}

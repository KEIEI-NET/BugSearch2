//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 提供データ削除処理DB RemoteObjectインターフェース
// プログラム概要   : 提供データ削除処理DB RemoteObject Interfaceです
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 呉元嘯
// 作 成 日  2009/06/16  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日              修正内容 : 
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 提供データ削除処理 リモートオブジェクトインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : 提供データ削除処理 リモート インターフェースです。</br>
    /// <br>Programmer : 呉元嘯</br>
    /// <br>Date       : 2009.06.16</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_OfferAP)]
    public interface IOfferDataDeleteDB
    {
        /// <summary>
        /// 提供データ削除処理
        /// </summary>
        /// <param name="offerDataDeleteList">提供データ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 提供データ削除処理</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.06.16</br>
        [MustCustomSerialization]
        int DeleteOfferData(
            [CustomSerializationMethodParameterAttribute("PMTKD01106D", "Broadleaf.Application.Remoting.ParamData.OfferDataDeleteWork")]
           ref object offerDataDeleteList);

        /// <summary>
        /// サーバーのレジストリ更新処理
        /// </summary>
        /// <returns>STATUS</returns>
        /// <br>Note       : サーバーのレジストリ更新処理</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.06.16</br>
        int ServerRegeditUpdate();
    }


}

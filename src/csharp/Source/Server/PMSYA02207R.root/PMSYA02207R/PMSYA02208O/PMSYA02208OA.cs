//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 型式別出荷実績表
// プログラム概要   : 型式別出荷実績表帳票を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//Update Note : 2010/05/07 王海立 redmine #7001
//              型式別出荷対応表の受注ステータスについて、仕様の変更
//Update Note : 2010/05/07 王海立 redmine #7109
//              結合先品番の取得
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : zhshh
// 作 成 日  2010/04/22  修正内容 : 新規作成
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
    /// 型式別出荷実績表DB RemoteObjectインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : 型式別出荷実績表DB RemoteObject Interfaceです。</br>
    /// <br>Programmer : zhshh</br>
    /// <br>Date       : 2010.04.22</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]

    public interface IModelShipResultDB
    {
        /// <summary>
        /// 型式別出荷実績表を全て戻します（論理削除除く）:カスタムシリアライズ
        /// </summary>
        /// <param name="modelShipResultWork">検索結果</param>
        /// <param name="modelShipRsltCndtnWork">検索パラメータ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : zhshh</br>
        /// <br>Date       : 2010.04.22</br>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("PMSYA02209D", "Broadleaf.Application.Remoting.ParamData.ModelShipResultWork")]
            out object modelShipResultWork,
            object modelShipRsltCndtnWork);

        // --- ADD 2010/05/08 ---------->>>>>
        /// <summary>
        /// 指定された条件の在庫情報を全て戻します（論理削除除く）
        /// </summary>
        /// <param name="modelShipResultWork">検索結果</param>
        /// <param name="enterpriseCode">検索パラメータ</param>
        /// <param name="warehouseCode">検索パラメータ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の在庫情報データを全て戻します（論理削除除く）</br>
        /// <br>Programmer : 王海立</br>
        /// <br>Date       : 2010.05.10</br>
        [MustCustomSerialization]
        int SearchStock(
            [CustomSerializationMethodParameterAttribute("PMSYA02209D", "Broadleaf.Application.Remoting.ParamData.ModelShipResultWork")]
            ref object modelShipResultWorkObject,
            string enterpriseCode,//ADD 2010/05/13
            string warehouseCode);
        // --- ADD 2010/05/08 ----------<<<<<
    }
}

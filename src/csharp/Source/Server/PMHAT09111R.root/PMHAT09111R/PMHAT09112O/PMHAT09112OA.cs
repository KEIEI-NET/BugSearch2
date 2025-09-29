//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 発注点設定処理
// プログラム概要   : 発注点設定処理DB RemoteObjectインターフェース
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 劉学智
// 作 成 日  2009/04/28  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日              修正内容 : 
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 発注点設定処理印刷DB RemoteObjectインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : 発注点設定処理印刷DB RemoteObject Interfaceです。</br>
    /// <br>Programmer : 劉学智</br>
    /// <br>Date       : 2009.04.13</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IOrderPointStSimulationDB
    {
        #region 発注点設定処理印刷データの取得処理
        /// <summary>
        /// 発注点設定処理印刷データを取得する
        /// </summary>
        /// <param name="list">検索結果</param>
        /// <param name="stockList">在庫マスタ検索結果</param>
        /// <param name="extrInfo_OrderPointStSimulationWork">検索パラメータ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009.04.13</br>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("PMHAT09113D", "Broadleaf.Application.Remoting.ParamData.OrderPointStSimulationWork")]
            out object list,
            [CustomSerializationMethodParameterAttribute("MAZAI04136D", "Broadleaf.Application.Remoting.ParamData.StockWork")]
            out object stockList,
            object extrInfo_OrderPointStSimulationWork);
        #endregion

        #region 在庫マスタの更新処理
        /// <summary>
        /// 発注点設定処理印刷データを取得する
        /// </summary>
        /// <param name="stockWorkList">在庫マスタワーク</param>
        /// <param name="orderPointStWorkList">発注点設定ワーク</param>
        /// <param name="retMsg">メッセージ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009.04.27</br>
        [MustCustomSerialization]
        int Write(
            [CustomSerializationMethodParameterAttribute("MAZAI04136D", "Broadleaf.Application.Remoting.ParamData.StockWork")]
            ref object stockWorkList,
            [CustomSerializationMethodParameterAttribute("PMHAT09007D", "Broadleaf.Application.Remoting.ParamData.OrderPointStWork")]
            ref object orderPointStWorkList,
            out string retMsg);
        #endregion
    }
}

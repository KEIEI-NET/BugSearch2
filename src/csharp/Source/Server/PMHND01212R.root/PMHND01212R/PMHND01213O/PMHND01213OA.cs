//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : ハンディターミナル在庫（仕入・移動）DBRemoteObjectインターフェース
// プログラム概要   : ハンディターミナル在庫（仕入・移動）DBRemoteObjectインターフェースです
//----------------------------------------------------------------------------//
//                (c)Copyright  2017 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11370074-00 作成担当 : 陳艶丹
// 作 成 日  2017/08/02  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号  11570136-00 作成担当 : 岸
// 作 成 日  2019/11/13  修正内容 : ハンディ６次改良
//----------------------------------------------------------------------------//

using System;
using System.Collections;

using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// ハンディターミナル在庫（仕入・移動）リモートオブジェクト インターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : ハンディターミナル在庫（仕入・移動）リモートオブジェクト インターフェースです。</br>
    /// <br>Programmer : 陳艶丹</br>
    /// <br>Date       : 2017/08/02</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IHandyStockMoveDB
    {
        #region [SearchStock]
        /// <summary>
        /// ハンディターミナル在庫仕入の在庫情報取得処理
        /// </summary>
        /// <param name="condByte">検索条件</param>
        /// <param name="retByte">検索結果</param>
        /// <returns>ステータス</returns>
        /// <br>Note       : ハンディターミナル在庫仕入の在庫情報取得処理を行います。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2017/08/02</br>
        int SearchStock(
            byte[] condByte,
            out byte[] retByte);
        #endregion

        // --- ADD 2019/11/13 ---------->>>>>
        #region [SearchStockHandy]
        /// <summary>
        /// ハンディターミナル在庫仕入の在庫情報取得処理
        /// </summary>
        /// <param name="condByte">検索条件</param>
        /// <param name="retByte">検索結果</param>
        /// <returns>ステータス</returns>
        /// <br>Note       : ハンディターミナル在庫仕入の在庫情報取得処理を行います。</br>
        /// <br>Programmer : 岸</br>
        /// <br>Date       : 2019/11/13</br>
        int SearchStockHandy(
            byte[] condByte,
            out object retByte);
        #endregion
        // --- ADD 2019/11/13 ----------<<<<<

        #region [Write]
        /// <summary>
        /// 検品データ登録処理（同一キーで物理削除）
        /// </summary>
        /// <param name="inspectDataObj">検品データオブジェクト</param>
        /// <param name="mode">0:検品データ登録、1:検品データ登録(先行検品)</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 検品データ登録処理を行います。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2017/08/02</br>
        /// </remarks>
        [MustCustomSerialization]
        int Write(
            [CustomSerializationMethodParameterAttribute("PMHND00213D", "Broadleaf.Application.Remoting.ParamData.HandyInspectDataWork")]
			ref object inspectDataObj,
            int mode);
        #endregion

        #region [Search]
        /// <summary>
        /// ハンディターミナル在庫移動の検品対象取得処理(伝票番号)
        /// </summary>
        /// <param name="condByte">検索条件</param>
        /// <param name="retObj">検索結果</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : ハンディターミナル在庫移動の検品対象取得処理(伝票番号)を行います。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2017/08/02</br>
        /// </remarks>
        [MustCustomSerialization]
        int Search(
            byte[] condByte,
            [CustomSerializationMethodParameterAttribute("PMHND01214D", "Broadleaf.Application.Remoting.ParamData.HandyStockMoveWork")]
            out object retObj);
        #endregion

        #region [SearchStockMove]
        /// <summary>
        /// 指定された条件の在庫移動情報LIST取得
        /// </summary>
        /// <param name="paraStockMoveWork">検索条件</param>
        /// <param name="retObj">検索結果</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 指定された条件で在庫移動情報LISTを戻します。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2017/08/02</br>
        /// </remarks>
        [MustCustomSerialization]
        int SearchStockMove(
            object paraStockMoveWork,
            [CustomSerializationMethodParameterAttribute("MAZAI04126D", "Broadleaf.Application.Remoting.ParamData.StockMoveWork")]
            out object retObj);
        #endregion
    }
}

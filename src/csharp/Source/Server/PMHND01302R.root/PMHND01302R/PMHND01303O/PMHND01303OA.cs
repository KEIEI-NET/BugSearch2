//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : ハンディターミナル委託在庫補充リモートオブジェクト インターフェース
// プログラム概要   : ハンディターミナル委託在庫補充RemoteObject Interfaceです
//----------------------------------------------------------------------------//
//                (c)Copyright  2017 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11370074-00 作成担当 : 譚洪
// 作 成 日  2017/08/11  修正内容 : 新規作成
//----------------------------------------------------------------------------//

using System;
using System.Collections;

using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// ハンディターミナル委託在庫補充リモートオブジェクト インターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : ハンディターミナル委託在庫補充リモートオブジェクト インターフェースです。</br>
    /// <br>Programmer : 譚洪</br>
    /// <br>Date       : 2017/08/11</br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IHandyConsStockRepDB
    {
        #region [ハンディターミナル委託在庫補充_倉庫情報抽出処理]
        /// <summary>
        /// ハンディターミナル委託在庫補充_倉庫情報抽出処理
        /// </summary>
        /// <param name="condByte">検索条件</param>
        /// <param name="retListObj">検索結果</param>
        /// <returns>検索結果ステータス</returns>
        /// <br>Note       : ハンディターミナル委託在庫補充_倉庫情報を抽出します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/08/11</br>
        [MustCustomSerialization]
        int SearchHandyWarehouseInfo(
            byte[] condByte,
            [CustomSerializationMethodParameterAttribute("PMHND01304D", "Broadleaf.Application.Remoting.ParamData.ConsStockRepWarehouseRetWork")]
            out object retListObj);
        #endregion

        #region [ハンディターミナル委託在庫補充_検品情報抽出処理]
        /// <summary>
        /// ハンディターミナル委託在庫補充_検品情報抽出処理
        /// </summary>
        /// <param name="condByte">検索条件</param>
        /// <param name="retListObj">検索結果</param>
        /// <returns>検索結果ステータス</returns>
        /// <br>Note       : ハンディターミナル委託在庫補充_検品情報を抽出します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/08/11</br>
        [MustCustomSerialization]
        int SearchHandyInspectInfo(
            byte[] condByte,
            [CustomSerializationMethodParameterAttribute("PMHND01304D", "Broadleaf.Application.Remoting.ParamData.ConsStockRepInspectRetWork")]
            out object retListObj);
        #endregion

    }
}

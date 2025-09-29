//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : TSP連携マスタ設定
// プログラム概要   : TSP連携マスタ設定を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2020 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号 : 11670305-00  作成担当 : 3H 劉星光
// 作 成 日 : 2020/11/23  修正内容 : 新規作成
//----------------------------------------------------------------------------//
using Broadleaf.Application.Resources;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using System;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// TSP連携マスタ設定　DB RemoteObjectインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : TSP連携マスタ設定 DB RemoteObject Interfaceです。</br>
    /// <br>Programmer : 3H 劉星光</br>
    /// <br>Date       : 2020/11/23</br>
    /// <br>依頼番号   : 11670305-00</br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)] // アプリケーションサーバーの接続先
    public interface ITspCprtStDB
    {
        /// <summary>
        /// 指定された条件のTSP連携マスタ設定情報LISTの件数を戻します。
        /// </summary>
        /// <param name="tspCprtStWork">検索条件</param>
        /// <param name="tspCprtStWorkList">TSP連携マスタ設定情報LIST</param>
        /// <param name="logicalMode">論理削除区分</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 指定された条件のTSP連携マスタ設定情報LISTの件数を戻します。</br>
        /// <br>Programmer : 3H 劉星光</br>
        /// <br>Date       : 2020/11/23</br>
        /// </remarks>
        [MustCustomSerialization]
        int Search(
            object tspCprtStWork,
            [CustomSerializationMethodParameterAttribute("PMTSP09006D", "Broadleaf.Application.Remoting.ParamData.TspCprtStWork")]
            out object tspCprtStWorkList,
            ConstantManagement.LogicalMode logicalMode
            );

        /// <summary>
        /// TSP連携マスタ設定情報を登録、更新します。
        /// </summary>
        /// <param name="tspCprtStWork">TSP連携マスタ設定情報</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : TSP連携マスタ設定情報を登録、更新します。</br>
        /// <br>Programmer : 3H 劉星光</br>
        /// <br>Date       : 2020/11/23</br>
        /// </remarks>
        [MustCustomSerialization]
        int Write(
            [CustomSerializationMethodParameterAttribute("PMTSP09006D", "Broadleaf.Application.Remoting.ParamData.TspCprtStWork")]
            ref object tspCprtStWork
            );

        /// <summary>
        /// TSP連携マスタ設定情報を完全削除します。
        /// </summary>
        /// <param name="tspCprtStWork">TSP連携マスタ設定情報</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : TSP連携マスタ設定情報を完全削除します。</br>
        /// <br>Programmer : 3H 劉星光</br>
        /// <br>Date       : 2020/11/23</br>
        /// </remarks>
        [MustCustomSerialization]
        int Delete(
            object tspCprtStWork
            );

        /// <summary>
        /// TSP連携マスタ設定情報を論理削除します。
        /// </summary>
        /// <param name="tspCprtStWork">TSP連携マスタ設定情報</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : TSP連携マスタ設定情報を論理削除します。</br>
        /// <br>Programmer : 3H 劉星光</br>
        /// <br>Date       : 2020/11/23</br>
        /// </remarks>
        [MustCustomSerialization]
        int LogicalDelete(
            [CustomSerializationMethodParameterAttribute("PMTSP09006D", "Broadleaf.Application.Remoting.ParamData.TspCprtStWork")]
            ref object tspCprtStWork
            );

        /// <summary>
        /// TSP連携マスタ設定情報を復活します。
        /// </summary>
        /// <param name="tspCprtStWork">TSP連携マスタ設定情報</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : TSP連携マスタ設定情報を復活します。</br>
        /// <br>Programmer : 3H 劉星光</br>
        /// <br>Date       : 2020/11/23</br>
        /// </remarks>
        [MustCustomSerialization]
        int Revival(
            [CustomSerializationMethodParameterAttribute("PMTSP09006D", "Broadleaf.Application.Remoting.ParamData.TspCprtStWork")]
            ref object tspCprtStWork
            );
    }
}
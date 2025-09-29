//****************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : 検品対象取得リモートオブジェクト インターフェース
// プログラム概要   : 検品対象取得RemoteObject Interfaceです
//----------------------------------------------------------------------------//
//                (c)Copyright  2017 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11370006-00 作成担当 : 朱宝軍
// 作 成 日  2017/06/12  修正内容 : 新規作成
//----------------------------------------------------------------------------//

using System;
using System.Collections;

using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 検品対象取得リモートオブジェクト インターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : 検品対象取得リモートオブジェクト インターフェースです。</br>
    /// <br>Programmer : 朱宝軍</br>
    /// <br>Date       : 2017/06/12</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IHandyInspectDB
    {
        #region [SearchSlipNum]
        /// <summary>
        /// 検品対象情報(伝票番号)の取得処理
        /// </summary>
        /// <param name="condByte">検索条件</param>
        /// <param name="retListObj">検索結果</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 検品対象情報(伝票番号)を検索します。</br>
        /// <br>Programmer : 朱宝軍</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        [MustCustomSerialization]
        int SearchSlipNum(
            byte[] condByte,
            [CustomSerializationMethodParameterAttribute("PMHND04004D", "Broadleaf.Application.Remoting.ParamData.HandyInspectWork")]
            out object retListObj);
        #endregion

        #region [SearchTotal]
        /// <summary>
        /// 検品対象情報(一括検品)の取得処理
        /// </summary>
        /// <param name="condByte">検索条件</param>
        /// <param name="retListObj">検索結果</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 検品対象情報(一括検品)を検索します。</br>
        /// <br>Programmer : 朱宝軍</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        [MustCustomSerialization]
        int SearchTotal(
            byte[] condByte,
            [CustomSerializationMethodParameterAttribute("PMHND04004D", "Broadleaf.Application.Remoting.ParamData.HandyInspectWork")]
            out object retListObj);
        #endregion
    }
}
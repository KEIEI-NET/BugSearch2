//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : ハンディターミナル発注先ガイドリモートオブジェクト インターフェース
// プログラム概要   : ハンディターミナル発注先ガイドRemoteObject Interfaceです
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

using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// ハンディターミナル発注先ガイドリモートオブジェクト インターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : ハンディターミナル発注先ガイドリモートオブジェクト インターフェースです。</br>
    /// <br>Programmer : 譚洪</br>
    /// <br>Date       : 2017/08/11</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IHandySupplierGuideDB
    {
        #region [Search]
        /// <summary>
        /// ハンディターミナル発注先ガイド情報の取得処理
        /// </summary>
        /// <param name="condByte">検索条件</param>
        /// <param name="retListObj">検索結果</param>
        /// <returns>検索結果ステータス</returns>
        /// <br>Note       : ハンディターミナル発注先ガイド情報を検索します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/08/11</br>
        [MustCustomSerialization]
        int Search(
            byte[] condByte,
            [CustomSerializationMethodParameterAttribute("PMHND04304D", "Broadleaf.Application.Remoting.ParamData.SupplierGuideResultWork")]
			out object retListObj);
        #endregion
    }
}

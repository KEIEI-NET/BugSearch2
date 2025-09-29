//****************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : ハンディターミナルログイン情報取得リモートオブジェクト インターフェース
// プログラム概要   : ハンディターミナルログイン情報取得RemoteObject Interfaceです
//----------------------------------------------------------------------------//
//                (c)Copyright  2017 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11370006-00 作成担当 : 朱宝軍
// 作 成 日  2017/06/05  修正内容 : 新規作成
//----------------------------------------------------------------------------//

using System;
using System.Collections;

using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// ハンディターミナルログイン情報取得リモートオブジェクト インターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : ハンディターミナルログイン情報取得リモートオブジェクト インターフェースです。</br>
    /// <br>Programmer : 朱宝軍</br>
    /// <br>Date       : 2017/06/05</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IHandyLoginInfoDB
    {
        #region [Search]
        /// <summary>
        /// ハンディターミナルログイン情報の取得処理
        /// </summary>
        /// <param name="condByte">検索条件</param>
        /// <param name="retByte">検索結果</param>
        /// <returns>ステータス</returns>
        /// <br>Note       : ハンディターミナルログイン情報を検索します。</br>
        /// <br>Programmer : 朱宝軍</br>
        /// <br>Date       : 2017/06/05</br>
        int Search(
            byte[] condByte,
			out byte[] retByte);
        #endregion
    }
}

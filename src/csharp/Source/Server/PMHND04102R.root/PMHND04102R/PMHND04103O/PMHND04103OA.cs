//****************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : ハンディターミナル在庫情報取得(通常)リモートオブジェクト インターフェース
// プログラム概要   : ハンディターミナル在庫情報取得(通常)RemoteObject Interfaceです
//----------------------------------------------------------------------------//
//                (c)Copyright  2017 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11370006-00 作成担当 : 譚洪
// 作 成 日  2017/06/15  修正内容 : 新規作成
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
    /// ハンディターミナル在庫情報取得(通常)リモートオブジェクト インターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : ハンディターミナル在庫情報取得(通常)リモートオブジェクト インターフェースです。</br>
    /// <br>Programmer : 譚洪</br>
    /// <br>Date       : 2017/06/15</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IHandyStockDB
    {
        #region [Search]
        /// <summary>
        /// ハンディターミナル在庫情報の取得処理
        /// </summary>
        /// <param name="condByte">検索条件</param>
        /// <param name="retByte">検索結果</param>
        /// <returns>ステータス</returns>
        /// <br>Note       : ハンディターミナル在庫情報を検索します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/06/15</br>
        int Search(
            byte[] condByte,
			out byte[] retByte);
        #endregion

        // --- ADD 2019/11/13 ---------->>>>>
        #region [SearchHandy]
        /// <summary>
        /// ハンディターミナル在庫情報の取得処理
        /// </summary>
        /// <param name="condByte">検索条件</param>
        /// <param name="retByte">検索結果</param>
        /// <returns>ステータス</returns>
        /// <br>Note       : ハンディターミナル在庫情報を検索します。</br>
        /// <br>Programmer : 岸</br>
        /// <br>Date       : 2019/11/13</br>
        int SearchHandy(
            byte[] condByte,
            out object retByte);
        #endregion
        // --- ADD 2019/11/13 ----------<<<<<
    }
}

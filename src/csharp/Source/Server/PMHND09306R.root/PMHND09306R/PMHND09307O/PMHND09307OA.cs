//****************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : 商品バーコード関連付けマスタ登録リモートオブジェクト インターフェース
// プログラム概要   : 商品バーコード関連付けマスタ登録RemoteObject Interfaceです
//----------------------------------------------------------------------------//
//                (c)Copyright  2017 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11370006-00 作成担当 : 譚洪
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
    /// 商品バーコード関連付けマスタ登録リモートオブジェクト インターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : 商品バーコード関連付けマスタ登録リモートオブジェクト インターフェースです。</br>
    /// <br>Programmer : 譚洪</br>
    /// <br>Date       : 2017/06/05</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IHandyGoodsBarCodeDB
    {
        #region [Insert]
        /// <summary>
        /// 商品バーコード関連付けマスタの登録処理
        /// </summary>
        /// <param name="insertByte">登録ワーク</param>
        /// <returns>ステータス</returns>
        /// <br>Note       : 商品バーコード関連付けマスタ情報を登録します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/06/05</br>
        int InsertForHandy(
            byte[] insertByte);
        #endregion
    }
}

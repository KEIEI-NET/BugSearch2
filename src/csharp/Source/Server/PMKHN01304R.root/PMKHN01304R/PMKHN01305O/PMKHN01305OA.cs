//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 仕入先変換ツール
// プログラム概要   : 商品管理情報マスタの最適化の為、不要なレコードを削除する。
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 譚洪
// 作 成 日  2009/07/13  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日              修正内容 : 
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;

using Broadleaf.Application.Resources;
using Broadleaf.Library.Runtime.Serialization;
using System.Collections;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 仕入先変換ツール用DB Access RemoteObjectインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : 仕入先変換ツール用DB Access RemoteObjectインターフェースです。</br>
    /// <br>Programmer : 譚洪</br>
    /// <br>Date       : 2009.07.13</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface ISupplierChangeProcDB
    {
        /// <summary>
        /// 仕入先変換ツールの削除処理
        /// </summary>
        /// <param name="enterpriseCodes">企業コード</param>
        /// <param name="readCount">検索件数</param>
        /// <param name="delCount">削除件数</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 仕入先変換ツールの削除処理を行うクラスです。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009.07.13</br>
        /// </remarks>
        [MustCustomSerialization]
        int DeleteGoodsMng(
            string enterpriseCodes,
            out int readCount,
            out int delCount);
    }
}

//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 通信テストツール
// プログラム概要   : データセンターに対して追加・検索処理を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2014 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 譚洪
// 作 成 日  2014/09/18  修正内容 : 新規作成
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
    /// データ送信処理用DB Access RemoteObjectインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : 通信テストツール処理用DB Access RemoteObjectインターフェースです。</br>
    /// <br>Programmer : 譚洪</br>
    /// <br>Date       : 2014/09/18</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_Center_UserAP)]
    public interface IAPNSNetworkTestDB
    {
        /// <summary>
        /// データ初期設定
        /// </summary>
        /// <param name="tusinTestLogList">検索条件</param>
        /// <param name="retMessage">エラーメッセージ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : データを初期設定する</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2014/09/18</br>
        int SearchLogData(
            ArrayList tusinTestLogList,
            out string retMessage);

        /// <summary>
        /// データ初期設定
        /// </summary>
        /// <param name="tusinTestLogList">登録内容</param>
        /// <param name="retMessage">エラーメッセージ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : データを初期設定する</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2014/09/18</br>
        int InsertLogData(
            ArrayList tusinTestLogList,
            out string retMessage);

    }
}

//****************************************************************************//
// システム         : セキュリティ管理
// プログラム名称   : セキュリティ管理インターフェース
// プログラム概要   : セキュリティ管理の子フォーム用照会インタフェース
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 工藤 恵優
// 作 成 日  2008/07/24  修正内容 : 新規作成
//----------------------------------------------------------------------------//

using System;

namespace Broadleaf.Application.Common
{
    /// <summary>
    /// グリッドが選択されたときのイベントハンドラ
    /// </summary>
    /// <param name="sender">グリッドの親オブジェクト</param>
    /// <param name="operationSt">選択された行に対するオペレーション情報</param>
    public delegate void GridSelectedEventHandler(
        object sender,
        OperationSt operationSt
    );

    /// <summary>
    /// セキュリティ管理照会インタフェース
    /// </summary>
    public interface ISecurityManagementView
    {
        /// <summary>
        /// 行ダブルクリックされたときに発生させるイベント
        /// </summary>
        event GridSelectedEventHandler Selected;
    }
}

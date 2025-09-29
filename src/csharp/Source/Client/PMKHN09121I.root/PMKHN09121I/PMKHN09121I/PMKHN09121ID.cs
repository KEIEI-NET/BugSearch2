//****************************************************************************//
// システム         : セキュリティ管理
// プログラム名称   : セキュリティ管理インターフェース
// プログラム概要   : セキュリティ管理のオペレーション設定情報を保持します。
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
    /// セキュリティ管理オペレーション設定情報イベントパラメータクラス
    /// </summary>
    public sealed class OperationSt : EventArgs
    {
        /// <summary>選択されたグリッドの行</summary>
        private readonly object _selectedGridRow;
        /// <summary>
        /// 選択されたグリッドの行を取得します。
        /// </summary>
        /// <value>選択されたグリッドの行</value>
        public object SelectedGridRow
        {
            get { return _selectedGridRow; }
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="selectedGridRow">選択されたグリッドの行</param>
        public OperationSt(object selectedGridRow)
        {
            _selectedGridRow = selectedGridRow;
        }
    }
}

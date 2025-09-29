//****************************************************************************//
// システム         : セキュリティ管理
// プログラム名称   : セキュリティ管理インターフェース
// プログラム概要   : セキュリティ管理の子フォーム用設定インタフェース
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
    /// セキュリティ管理設定インタフェース
    /// </summary>
    public interface ISecurityManagementSetting
    {
        /// <summary>
        /// 引数OperationStに対応するグリッド行を選択状態にする処理を行います。
        /// </summary>
        /// <param name="operationSt">選択すべき行に対応するオペレーション設定情報</param>
        void Select(OperationSt operationSt);
    }

    #region <ステータスバー/>

    /// <summary>
    /// ステータスバーに表示するメッセージクラス
    /// </summary>
    public sealed class StatusBarMsg : EventArgs
    {
        /// <summary>メッセージ</summary>
        private readonly string _msg;
        /// <summary>
        /// メッセージを取得します。
        /// </summary>
        /// <value>メッセージ</value>
        public string Msg
        {
            get { return _msg; }
        }

        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        public StatusBarMsg()
        {
            _msg = string.Empty;
        }

        /// <summary>
        /// カスタムコンストラクタ
        /// </summary>
        /// <param name="msg">メッセージ</param>
        public StatusBarMsg(string msg)
        {
            _msg = msg;
        }
    }

    /// <summary>
    /// 値が不正だったときのイベントハンドラ
    /// </summary>
    /// <param name="sender">イベントソース</param>
    /// <param name="statusBarMsg">イベントパラメータ</param>
    public delegate void ValueIsInvalidEventHandler(
        object sender,
        StatusBarMsg statusBarMsg
    );

    /// <summary>
    /// ステータスバー表示インタフェース
    /// </summary>
    public interface IStatusBarShowable
    {
        /// <summary>
        /// ステータスバーに表示するときのイベント
        /// </summary>
        event ValueIsInvalidEventHandler ShowStatusBar;
    }

    #endregion  // <ステータスバー/>
}

//****************************************************************************//
// システム         : 待機処理
// プログラム名称   : 送信コマンド
// プログラム概要   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 工藤 恵優
// 作 成 日  2010/06/22  修正内容 : 新規作成
//----------------------------------------------------------------------------//
using System;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 送信コマンドインターフェース
    /// </summary>
    public interface ISendingCommand
    {
        /// <summary>
        /// 名称を取得します。
        /// </summary>
        string Name { get; }

        /// <summary>
        /// 実行します。
        /// </summary>
        /// <returns>処理結果ステータス</returns>
        int Execute();
    }

    /// <summary>
    /// 何もしない送信コマンドクラス
    /// </summary>
    public sealed class NullSendingCommand : ISendingCommand
    {
        #region ISendingCommand メンバ

        /// <summary>
        /// 名称を取得します。
        /// </summary>
        /// <see cref="ISendingCommand"/>
        public string Name
        {
            get { return "何もしません"; }
        }

        /// <summary>
        /// 実行します。
        /// </summary>
        /// <returns>処理結果ステータス(正常終了)</returns>
        /// <see cref="ISendingCommand"/>
        public int Execute()
        {
            return 0;
        }

        #endregion // ISendingCommand メンバ

        #region Constructor

        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        public NullSendingCommand() { }

        #endregion // Constructor
    }
}

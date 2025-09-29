//****************************************************************************//
// システム         : NS待機処理
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
using System.Collections.Generic;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 送信コマンドの待ち行列クラス
    /// </summary>
    public sealed class SendingCommandQueue
    {
        #region 待ち行列

        /// <summary>送信コマンドの待ち行列</summary>
        private readonly Queue<ISendingCommand> _commandQueue = new Queue<ISendingCommand>();
        /// <summary>送信コマンドの待ち行列を取得します。</summary>
        private Queue<ISendingCommand> CommandQueue { get { return _commandQueue; } }

        #endregion // 待ち行列

        #region Constructor

        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        public SendingCommandQueue() { }

        #endregion // Constructor

        /// <summary>
        /// 送信コマンドが存在するか判断します。
        /// </summary>
        public bool ExistsCommand
        {
            get { return CommandQueue.Count > 0; }
        }

        /// <summary>
        /// 待ち行列に追加します。
        /// </summary>
        /// <param name="command">送信コマンド</param>
        public void Enqueue(ISendingCommand command)
        {
            CommandQueue.Enqueue(command);
        }

        /// <summary>
        /// 待ち行列から取り出します。
        /// </summary>
        /// <returns>送信コマンド</returns>
        public ISendingCommand Dequeue()
        {
            if (!ExistsCommand) return new NullSendingCommand();

            return CommandQueue.Dequeue();
        }
    }
}

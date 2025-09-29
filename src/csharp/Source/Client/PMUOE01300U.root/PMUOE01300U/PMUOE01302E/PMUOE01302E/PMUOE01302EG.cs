//****************************************************************************//
// システム         : 卸商仕入受信処理
// プログラム名称   : 卸商仕入受信処理Model
// プログラム概要   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 工藤 恵優
// 作 成 日  2008/11/17  修正内容 : 新規作成
//----------------------------------------------------------------------------//

using System;
using System.Text;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// 送信テキスト（送信電文）クラス
    /// </summary>
    public class SendingText
    {
        #region <電文/>

        /// <summary>電文</summary>
        private readonly byte[] _telegram;
        /// <summary>
        /// 電文を取得します。
        /// </summary>
        /// <value>電文</value>
        protected byte[] Telegram { get { return _telegram; } }

        #endregion  // <電文/>

        /// <summary>電文区分</summary>
        private readonly byte[] _telegramDivs = new byte[1];
        /// <summary>電文区分</summary>
        protected byte[] TelegramDivs { get { return _telegramDivs; } }

        /// <summary>処理区分</summary>
        private readonly byte[] _processDivs = new byte[1];
        /// <summary>処理区分</summary>
        protected byte[] ProcessDivs { get { return _processDivs; } }

        /// <summary>端末側コード</summary>
        private readonly byte[] _terminalCodes = new byte[7];
        /// <summary>端末側コード</summary>
        protected byte[] TerminalCodes { get { return _terminalCodes; } }

        /// <summary>ホストコード</summary>
        private readonly byte[] _hostCodes = new byte[7];
        /// <summary>ホストコード</summary>
        protected byte[] HostCodes { get { return _hostCodes; } }

        /// <summary>パスワード</summary>
        private readonly byte[] _passwords = new byte[6];
        /// <summary>パスワード</summary>
        protected byte[] Passwords { get { return _passwords; } }

        /// <summary>送信日付</summary>
        private readonly byte[] _sendDates = new byte[6];
        /// <summary>送信日付</summary>
        protected byte[] SendDates { get { return _sendDates; } }

        /// <summary>送信時刻</summary>
        private readonly byte[] _sendTimes = new byte[6];
        /// <summary>送信時刻</summary>
        protected byte[] SendTimes { get { return _sendTimes; } }

        /// <summary>結果</summary>
        private readonly byte[] _results = new byte[2];
        /// <summary>結果</summary>
        protected byte[] Results { get { return _results; } }

        /// <summary>発注区分</summary>
        private readonly byte[] _orderDivs = new byte[1];
        /// <summary>発注区分</summary>
        protected byte[] OrderDivs { get { return _orderDivs; } }

        /// <summary>メッセージ</summary>
        private readonly byte[] _messages = new byte[32];
        /// <summary>メッセージ</summary>
        protected byte[] Messages { get { return _messages; } } 

        #region <Constructor/>

        /// <summary>
        /// カスタムコンストラクタ
        /// </summary>
        /// <param name="telegram">電文</param>
        public SendingText(byte[] telegram)
        {
            _telegram = telegram;

            Initialize();
        }

        /// <summary>
        /// 初期化します。
        /// </summary>
        private void Initialize()
        {
            int currentPos = 0;

            // 電文区分
            for (int i = 0; i < TelegramDivs.Length; i++)
            {
                TelegramDivs[i] = Telegram[currentPos];
                currentPos++;
            }

            // 処理区分
            for (int i = 0; i < ProcessDivs.Length; i++)
            {
                ProcessDivs[i] = Telegram[currentPos];
                currentPos++;
            }

            // 端末側コード
            for (int i = 0; i < TerminalCodes.Length; i++)
            {
                TerminalCodes[i] = Telegram[currentPos];
                currentPos++;
            }

            // ホストコード
            for (int i = 0; i < HostCodes.Length; i++)
            {
                HostCodes[i] = Telegram[currentPos];
                currentPos++;
            }

            // パスワード
            for (int i = 0; i < Passwords.Length; i++)
            {
                Passwords[i] = Telegram[currentPos];
                currentPos++;
            }

            // 送信日付
            for (int i = 0; i < SendDates.Length; i++)
            {
                SendDates[i] = Telegram[currentPos];
                currentPos++;
            }

            // 送信時刻
            for (int i = 0; i < SendTimes.Length; i++)
            {
                SendTimes[i] = Telegram[currentPos];
                currentPos++;
            }

            // 結果
            for (int i = 0; i < Results.Length; i++)
            {
                Results[i] = Telegram[currentPos];
                currentPos++;
            }

            // 発注区分
            for (int i = 0; i < OrderDivs.Length; i++)
            {
                OrderDivs[i] = Telegram[currentPos];
                currentPos++;
            }

            // メッセージ
            for (int i = 0; i < Messages.Length; i++)
            {
                Messages[i] = Telegram[currentPos];
                currentPos++;
            }
        }

        #endregion  // <Constructor/>

        #region <Override/>

        /// <summary>
        /// 文字列に変換します。
        /// </summary>
        /// <returns>文字列</returns>
        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            {
                str.Append("電文区分：").Append(ConvertString(TelegramDivs)).Append(Environment.NewLine);
                str.Append("処理区分：").Append(ConvertString(ProcessDivs)).Append(Environment.NewLine);
                str.Append("端末側コード：").Append(ConvertString(TerminalCodes)).Append(Environment.NewLine);
                str.Append("ホストコード：").Append(ConvertString(HostCodes)).Append(Environment.NewLine);
                str.Append("パスワード：").Append(ConvertString(Passwords)).Append(Environment.NewLine);
                str.Append("送信日付：").Append(ConvertString(SendDates)).Append(Environment.NewLine);
                str.Append("送信時刻：").Append(ConvertString(SendTimes)).Append(Environment.NewLine);
                str.Append("結果：").Append(ConvertString(Results)).Append(Environment.NewLine);
                str.Append("発注区分：").Append(ConvertString(OrderDivs)).Append(Environment.NewLine);
                str.Append("メッセージ：").Append(ConvertString(Messages)).Append(Environment.NewLine);
            }
            return str.ToString();
        }

        #endregion  // <Override/>

        /// <summary>
        /// 文字列に変換します。
        /// </summary>
        /// <param name="jisCodes">JISコード配列</param>
        /// <returns>文字列</returns>
        private static string ConvertString(byte[] jisCodes)
        {
            StringBuilder str = new StringBuilder();

            foreach (byte jisCode in jisCodes)
            {
                char aCharacter = Convert.ToChar(jisCode);
                if (aCharacter.Equals('\0'))
                {
                    aCharacter = ' ';
                }
                str.Append("<" + aCharacter.ToString() + ">");
            }

            return str.ToString().Trim();
        }
    }
}

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
using System.Diagnostics;
using System.IO;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 送信コマンドクラス
    /// </summary>
    public sealed class SendingCommand : ISendingCommand
    {
        #region ISendingCommand メンバ

        /// <summary>名称</summary>
        private readonly string _name;
        /// <summary>名称を取得します。</summary>
        /// <see cref="ISendingCommand"/>
        public string Name { get { return _name; } }

        /// <summary>
        /// 実行します。
        /// </summary>
        /// <returns>処理結果ステータス</returns>
        /// <see cref="ISendingCommand"/>
        public int Execute()
        {
            try
            {
                ProcessStartInfo processStartInfo = new ProcessStartInfo();
                {
                    // 起動ディレクトリを設定する
                    processStartInfo.WorkingDirectory = Environment.CurrentDirectory;

                    // 起動するアプリケーションを設定する
                    processStartInfo.FileName = SendingAppName;

                    // コマンドライン引数を設定する
                    processStartInfo.Arguments = CommandLineArg;

                    #region 参考

                    //// 新しいウィンドウを作成するかどうかを設定する (初期値 false)
                    //processStartInfo.CreateNoWindow = true;

                    //// シェルを使用するかどうか設定する (初期値 true)
                    //processStartInfo.UseShellExecute = false;

                    //// 起動できなかった時にエラーダイアログを表示するかどうかを設定する (初期値 false)
                    //processStartInfo.ErrorDialog = true;

                    //// エラーダイアログを表示するのに必要な親ハンドルを設定する
                    //processStartInfo.ErrorDialogParentHandle = this.Handle;

                    //// アプリケーションを起動する時の動詞を設定する
                    //processStartInfo.Verb = "Open";

                    //// 起動時のウィンドウの状態を設定する
                    //processStartInfo.WindowStyle = ProcessWindowStyle.Normal;     //通常
                    //processStartInfo.WindowStyle = ProcessWindowStyle.Hidden;     //非表示
                    //processStartInfo.WindowStyle = ProcessWindowStyle.Minimized;  //最小化
                    //processStartInfo.WindowStyle = ProcessWindowStyle.Maximized;  //最大化

                    #endregion // 参考
                }
                using (Process nsScmSendApp = Process.Start(processStartInfo))
                {
                    // 終了するまで待機
                    nsScmSendApp.WaitForExit();

                    // 終了したら破棄
                    nsScmSendApp.Close();
                }

                return 0;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return 1;
            }
        }

        #endregion // ISendingCommand メンバ

        #region コマンドライン

        /// <summary>送信処理を行うアプリケーション名</summary>
        private readonly string _sendingAppName;
        /// <summary>送信処理を行うアプリケーション名を取得します。</summary>
        private string SendingAppName { get { return _sendingAppName; } }

        /// <summary>コマンドライン引数</summary>
        private readonly string _commandLineArg;
        /// <summary>コマンドライン引数を取得します。</summary>
        private string CommandLineArg { get { return _commandLineArg; } }

        #endregion // コマンドライン

        #region Constructor

        /// <summary>
        /// カスタムコンストラクタ
        /// </summary>
        /// <param name="name">名称</param>
        /// <param name="sendingAppName">送信処理を行うアプリケーション名</param>
        /// <param name="commandLineArg">コマンドライン引数</param>
        public SendingCommand(
            string name,
            string sendingAppName,
            string commandLineArg
        )
        {
            _name = name;
            _sendingAppName = sendingAppName;
            _commandLineArg = commandLineArg;
        }

        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        public SendingCommand() : this(string.Empty, string.Empty, string.Empty) { }

        #endregion // Constructor
    }
}

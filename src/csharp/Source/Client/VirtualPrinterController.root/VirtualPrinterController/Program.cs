//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 仮想プリンタダイアログ制御
// プログラム概要   : 仮想プリンタダイアログ制御を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2022 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11870080-00 作成担当 : 3H 仰亮亮
// 作 成 日  2022/04/24 修正内容 : 新規作成
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Serialization.Formatters;
using System.Diagnostics;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;
using System.IO;
using System.Text;


namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 仮想プリンタダイアログ制御
    /// </summary>
    /// <remarks>
    /// <br>Note       : 仮想プリンタダイアログ制御</br>
    /// <br>Programmer : 3H 仰亮亮</br>
    /// <br>Date       : 2022/04/24</br>
    /// <br>管理番号   : 11870080-00</br>
    /// </remarks>
    static class Program
    {
        private static System.Windows.Forms.Form _form = null;
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        /// <param name="args"></param>
        /// <remarks>
        /// <br>Note       : アプリケーションのメイン エントリ ポイントです。</br>
        /// <br>Programmer : 3H 仰亮亮</br>
        /// <br>Date       : 2022/04/24</br>
        /// <br>管理番号   : 11870080-00</br>
        /// </remarks>
        [STAThread]
        static void Main(string[] args)
        {
            try
            {
                // 起動パラメータ
                // [0]	PDFファイル保存先フォルダ名
                // [1]	得意先コード（8桁）
                // [2]	得意先名
                // [3]	伝票区分(売上／見積)
                // [4]	伝票番号（9桁）
                // [5]	ダイアログ待ち時間（ミリ秒）
                // [6]	起動元情報(売上伝票:１/得意先電子元帳:２)
                // アプリケーション開始準備処理
                if ((args.Length == 7) && (Process.GetProcessesByName(Process.GetCurrentProcess().ProcessName).Length <= 1))
                {
                    _form = new VirtualPrinterControllerUCA(args);
                    System.Windows.Forms.Application.Run(_form);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                System.Windows.Forms.Application.Exit();
            }
        }

        /// <summary>
        /// アプリケーション終了イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">メッセージ</param>
        /// <remarks>
        /// <br>Note       : アプリケーション終了イベント</br>
        /// <br>Programmer : 3H 仰亮亮</br>
        /// <br>Date       : 2022/04/24</br>
        /// <br>管理番号   : 11870080-00</br>
        /// </remarks>
        private static void ApplicationReleased(object sender, EventArgs e)
        {
            //アプリケーション終了
            System.Windows.Forms.Application.Exit();
        }
    }
}
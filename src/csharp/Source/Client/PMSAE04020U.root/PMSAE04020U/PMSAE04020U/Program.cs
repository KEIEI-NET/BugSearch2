//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : データ送信処理
// プログラム概要   : データセンターに対して追加・更新処理を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2013 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  10901034-00 作成担当 : wangf
// 作 成 日  K2013/06/27 修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号  10901034-00 作成担当 : wujun
// 修 正 日  K2013/07/09 修正内容 : 従業員ログオフ時、メッセージ出さないように修正する
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

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// データ送信処理自起動
    /// </summary>
    /// <remarks>
    /// <br>Note       : データ送信処理自起動</br>
    /// <br>Programmer : wangf</br>
    /// <br>Date       : K2013/06/27</br>
    /// </remarks>
    static class Program
    {
        internal static string[] _parameter;						// 起動パラメータ
        private static System.Windows.Forms.Form _form = null;

        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        /// <param name="args"></param>
        /// <remarks>
        /// <br>Note       : アプリケーションのメイン エントリ ポイントです。</br>
        /// <br>Programmer : wangf</br>
        /// <br>Date       : K2013/06/27</br>
        /// </remarks>
        [STAThread]
        static void Main(string[] args)
        {
            try
            {
                string msg = "";
                _parameter = args;

                // アプリケーション開始準備処理
                // 第二パラメータはアプリケーションのソフトウェアコードが指定できる場合は未定。出来ない場合はプロダクトコード
                int status = ApplicationStartControl.StartApplication(
                    out msg, ref _parameter, ConstantManagement_SF_PRO.ProductCode, new EventHandler(ApplicationReleased));
                if (status == 0)
                {
                    System.Windows.Forms.Application.EnableVisualStyles();
                    System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
                    if (Process.GetProcessesByName(Process.GetCurrentProcess().ProcessName).Length <= 1)
                    {
                        _form = new PMSAE04020UA();
                        System.Windows.Forms.Application.Run(_form);
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                ApplicationStartControl.EndApplication();
            }
        }

        /// <summary>
        /// アプリケーション終了イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">メッセージ</param>
        /// <remarks>
        /// <br>Note       : アプリケーション終了イベント</br>
        /// <br>Programmer : wangf</br>
        /// <br>Date       : K2013/06/27</br>
        /// </remarks>
        private static void ApplicationReleased(object sender, EventArgs e)
        {
            //メッセージを出す前に全て開放
            ApplicationStartControl.EndApplication();
            //従業員ログオフのメッセージを表示
            //MessageBox.Show(e.ToString(), "PMSAE04020U", MessageBoxButtons.OK);  //DEL BY wujun K2013/07/09
            //アプリケーション終了
            System.Windows.Forms.Application.Exit();
        }
    }
}
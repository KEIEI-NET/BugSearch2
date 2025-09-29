//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 開発ツール監視常駐
// プログラム概要   : 開発ツール監視常駐処理を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11570189-00 作成担当 : 岸　傑
// 作 成 日  2020/01/24  修正内容 : 新規作成
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
using Broadleaf.Library.Windows.Forms;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 開発ツール監視常駐
    /// </summary>
    /// <remarks>
    /// <br>Note       : 開発ツール監視常駐</br>
    /// <br>Programmer : 岸　傑</br>
    /// <br>Date       : 2020/01/24</br>
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
        /// <br>Programmer : 岸　傑</br>
        /// <br>Date       : 2020/01/24</br>
        /// </remarks>
        [STAThread]
        static void Main(string[] args)
        {
            try
            {

                if (args != null && args.Length == 1 && args[0].Trim() == "KILL")
                {
                    Process[] p = Process.GetProcessesByName("PMKHN09971U");

                    if (p != null && p.Length > 0)
                    {
                        foreach (Process itm in p)
                        {
                            if (itm.Id != System.Diagnostics.Process.GetCurrentProcess().Id)
                            {
                                Process pp = Process.GetProcessById(itm.Id);

                                pp.Kill();
                            }

                        }
                    }

                    return;
                }

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
                    _form = new PMKHN09971UA();
                    System.Windows.Forms.Application.Run(_form);

                }
            }
            catch
            {

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
        /// <br>Programmer : 岸　傑</br>
        /// <br>Date       : 2020/01/24</br>
        /// </remarks>
        private static void ApplicationReleased(object sender, EventArgs e)
        {
            //メッセージを出す前に全て開放
            ApplicationStartControl.EndApplication();
            //アプリケーション終了
            System.Windows.Forms.Application.Exit();
        }
    }
}
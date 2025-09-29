//****************************************************************************//
// システム         : プリンタ設定マスタ（サーバ用）
// プログラム名称   : プリンタ設定マスタ（サーバ用）フレーム
// プログラム概要   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 工藤 恵優
// 作 成 日  2009/09/16  修正内容 : 新規作成
//----------------------------------------------------------------------------//
using System;
using System.Threading;

using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// サーバ構成設定アプリのエントリクラス
    /// </summary>
    internal static class Program
    {
        /// <summary>正常</summary>
        private const int NORMAL_STATUS = 0;

        /// <summary>アプリケーション名</summary>
        private const string APP_NAME = "サーバ構成設定";

        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        /// <param name="commandLineArgs">コマンドライン引数</param>
        [STAThread]
        static void Main(string[] commandLineArgs)
        {
            try
            {
                Mutex mutex = new Mutex(false, APP_NAME);

                // ミューテックスの所有権を要求
                if (!mutex.WaitOne(0, false))
                {
                    //すでに起動していると判断して終了
                    ShowAlert("多重起動はできません。");
                    return;
                }

                string msg = string.Empty;  // 1パラ目

            #if DEBUG
                //アプリケーション開始準備処理（クライアント用）
                int status = ApplicationStartControl.StartApplication(
                    out msg,
                    ref commandLineArgs,
                    ConstantManagement_SF_PRO.ProductCode,  // アプリケーションのソフトウェアコードを指定（できない場合はプロダクトコード）
                    new EventHandler(ReleasedApplicationEventHandler)
                );
            #else
                //アプリケーション開始準備処理（サーバ用）
                int status = ServerApplicationMethodCallControl.StartApplication(
                    out msg,
                    ref commandLineArgs,
                    ConstantManagement_SF_PRO.ProductCode
                );
            #endif

                if (status.Equals(NORMAL_STATUS))
                {
                    System.Windows.Forms.Application.EnableVisualStyles();
                    System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
                    System.Windows.Forms.Application.Run(new ServerConfigurationForm());
                }
                else
                {
                    ShowAlert(msg);
                }

                // ミューテックスを解放する
                if (mutex != null) mutex.ReleaseMutex();
            }
            finally
            {
                ApplicationStartControl.EndApplication();
            }
        }

        #region <お約束>

        /// <summary>
        /// アラートを表示します。
        /// </summary>
        /// <param name="msg">メッセージ</param>
        private static void ShowAlert(string msg)
        {
            System.Windows.Forms.MessageBox.Show(
                msg,
                APP_NAME,
                System.Windows.Forms.MessageBoxButtons.OK,
                System.Windows.Forms.MessageBoxIcon.Error
            );
        }

        /// <summary>
        /// アプリケーション終了時のイベントハンドラ
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        private static void ReleasedApplicationEventHandler(
            object sender,
            EventArgs e
        )
        {
            // メッセージを出す前に全て開放
            ApplicationStartControl.EndApplication();

            // アプリケーション終了
            System.Windows.Forms.Application.Exit();
        }

        #endregion // </お約束>
    }
}
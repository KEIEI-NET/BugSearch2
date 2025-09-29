//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : Tablet常駐処理
// プログラム概要   : エントリクラス
//----------------------------------------------------------------------------//
//                (c)Copyright  2013 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  10902622-01 作成担当 : 高峰
// 作 成 日  2013/05/29  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号  10902622-01 作成担当 : 吉岡
// 作 成 日  2013/08/07  修正内容 : 再起動対応
//----------------------------------------------------------------------------//

using System;
using System.Windows.Forms;

using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Application.Controller.Util;
using Broadleaf.Library.Windows.Forms;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// SCMポップアップアプリケーションのエントリクラス
    /// </summary>
	internal static class Program
	{
        private static string[] _parameter;						// 起動パラメータ
        //public static bool PM7Mode=false;// DEL 2013/06/10 wangl2 FOR ソースチェック確認事項一覧NO.6の対応

        /// <summary>
        /// コマンドライン引数の保管
        /// </summary>
        public static string[] argsSave;
        public const string RIGHTCLICK = "rightClick";

        // ADD 吉岡 2013/08/07 常駐処理再起動対応 --------->>>>>>>>>>>>>>>>>>>>>>>>>
        public const string RESTART = "RESTART";
        public const Int32 WM_COPYDATA = 0x4A;
        // ADD 吉岡 2013/08/07 常駐処理再起動対応 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

        /// <summary>
		/// アプリケーションのメイン エントリ ポイントです。
		/// </summary>
        /// <param name="args">コマンドライン引数</param>
		[STAThread]
		static void Main(string[] args)
        {
            argsSave = args;

            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
            if (args[0] == "/B")
            {
                //PM7Mode = true;// DEL 2013/06/10 wangl2 FOR ソースチェック確認事項一覧NO.6の対応
                // ポップアップの多重起動防止
                if (SCMClientUtil.CanRun())
                {
                    System.Windows.Forms.Application.EnableVisualStyles();
                    System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
                    System.Windows.Forms.Application.Run(new TabletPopupForm(args));
                }

            }
            else
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
                        // オンライン状態判断
                        if (!LoginInfoAcquisition.OnlineFlag)
                        {
                            if (args.Length <= 2 || args[2] != "/S")
                            {
                                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION, "PMTAB00100U",
                                    "オフライン状態で本機能はご使用できません。", 0, MessageBoxButtons.OK);
                            }
                        }
                        else
                        {

                            // コマンドライン引数の数　2個：業務メニュー　3個かつ"rightClick"：タスクのパトランプアイコン右クリックメニューの"更新"
                            if (args.Length == 2
                                || !(args.Length == 3 && args[2].Equals(RIGHTCLICK)))
                            {
                                // ポップアップの多重起動防止
                                if (SCMClientUtil.CanRun())
                                {
                                    System.Windows.Forms.Application.EnableVisualStyles();
                                    System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
                                    System.Windows.Forms.Application.Run(new TabletPopupForm(args));
                                }
                                else
                                {
                                    // ADD 吉岡 2013/08/07 常駐処理再起動対応 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                                    // 起動済みの常駐処理を終了して、新規に常駐処理を起動
                                    if (Restart())
                                    {
                                        System.Windows.Forms.Application.EnableVisualStyles();
                                        System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
                                        System.Windows.Forms.Application.Run(new TabletPopupForm(args));
                                    }
                                    // ADD 吉岡 2013/08/07 常駐処理再起動対応 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                                }
                            }
                            else
                            {
                                System.Windows.Forms.Application.EnableVisualStyles();
                                System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
                                System.Windows.Forms.Application.Run(new TabletPopupForm(args));
                            }
                        }
                    }
                }
                finally
                {
                    ApplicationStartControl.EndApplication();
                }
            }
		}

        /// <summary>
        /// アプリケーション終了イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        private static void ApplicationReleased(object sender, EventArgs e)
        {
            // メッセージを出す前に全て開放
            ApplicationStartControl.EndApplication();

            // アプリケーション終了
            System.Windows.Forms.Application.Exit();
        }


        // ADD 吉岡 2013/08/07 常駐処理再起動対応 --------->>>>>>>>>>>>>>>>>>>>>>>>>
        [System.Runtime.InteropServices .DllImport("User32.dll", EntryPoint = "FindWindow")]
        public static extern Int32 FindWindow(String lpClassName, String lpWindowName);

        [System.Runtime.InteropServices.DllImport("User32.dll", EntryPoint = "SendMessage")]
        public static extern Int32 SendMessage(Int32 hWnd, Int32 Msg, Int32 wParam,
          ref COPYDATASTRUCT lParam);

        //COPYDATASTRUCT構造体 
        public struct COPYDATASTRUCT
        {
            public Int32 dwData;    //送信する32ビット値
            public Int32 cbData;    //lpDataのバイト数
            public string lpData;   //送信するデータへのポインタ(0も可能)
        }

        /// <summary>
        /// 再起動処理　メッセージ送信
        /// </summary>
        /// <returns></returns>
        private static bool Restart()
        {
            // TabletPopupFormのTextプロパティと同一とする必要がある
            string windowName = "タブレット自動回答";

            Int32 result = 0;

            //相手のウィンドウハンドルを取得します
            Int32 hWnd = FindWindow(null, windowName);
            if (hWnd == 0)
            {
                //ハンドルが取得できなかった
                MessageBox.Show("起動済み常駐処理のハンドルが取得できません");
                return false;
            }

            //文字列メッセージを送信します
            //送信データをByte配列に格納
            byte[] bytearry = System.Text.Encoding.Default.GetBytes(RESTART);
            Int32 len = bytearry.Length;
            COPYDATASTRUCT cds;
            cds.dwData = 0;        //使用しない
            cds.lpData = RESTART;  //テキストのポインターをセット
            cds.cbData = len + 1;  //長さをセット
            //文字列を送る
            result = SendMessage(hWnd, WM_COPYDATA, 0, ref cds);

            return result.Equals(0);
        }
        // ADD 吉岡 2013/08/07 常駐処理再起動対応 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
    }
}
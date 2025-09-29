using System;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// スプラッシュウィンドウクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : スプラッシュウィンドウを表示するクラスです（メインフォームのShownイベントで自動的に消えます）</br>
    /// <br>Programmer : 21024　佐々木 健</br>
    /// <br>Date       : 2010/01/05</br>
    /// </remarks>
    public class SplashWindow
    {
        #region ■ Private Member
        //Splashフォーム
        private static FloatingWindowF _form = null;
        //メインフォーム
        private static System.Windows.Forms.Form _mainForm = null;
        //Splashを表示するスレッド
        private static System.Threading.Thread _thread = null;
        //lock用のオブジェクト
        private static readonly object syncObject = new object();
        #endregion

        #region ■ Public Method
        /// <summary>
        /// Splashフォームを表示する
        /// </summary>
        /// <param name="mainForm">メインフォーム</param>
        public static void ShowSplash(System.Windows.Forms.Form mainForm)
        {
            if (_form != null || _thread != null)
                return;

            _mainForm = mainForm;
            //メインフォームのActivatedイベントでSplashフォームを消す
            if (_mainForm != null)
            {
                _mainForm.Shown += new EventHandler(MainForm_Shown);
            }

            //スレッドの作成
            _thread = new System.Threading.Thread(
                new System.Threading.ThreadStart(StartThread));
            _thread.Name = "SplashForm";
            _thread.IsBackground = true;
            _thread.ApartmentState = System.Threading.ApartmentState.STA;
            //スレッドの開始
            _thread.Start();
        }

        /// <summary>
        /// Splashフォームを表示する
        /// </summary>
        public static void ShowSplash()
        {
            ShowSplash(null);
        }

        /// <summary>
        /// Splashフォームを消す
        /// </summary>
        public static void CloseSplash()
        {
            lock (syncObject)
            {
                if (_form != null && _form.IsDisposed == false)
                {
                    //Splashフォームを閉じる
                    //Invokeが必要か調べる
                    if (_form.InvokeRequired)
                        _form.Invoke(new System.Windows.Forms.MethodInvoker(_form.Close));
                    else
                        _form.Close();
                }

                if (_mainForm != null)
                {
                    _mainForm.Activated -= new EventHandler(MainForm_Shown);
                    //メインフォームをアクティブにする
                    _mainForm.Activate();
                }

                _form = null;
                _thread = null;
                _mainForm = null;
            }
        }
        #endregion

        #region ■ Private Method
        /// <summary>
        /// スレッドで開始するメソッド
        /// </summary>
        private static void StartThread()
        {
            //Splashフォームを作成
            _form = new FloatingWindowF();
            //Splashフォームを表示する
            System.Windows.Forms.Application.Run(_form);
        }

        /// <summary>
        /// メインフォームがShownされた時
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void MainForm_Shown(object sender, EventArgs e)
        {
            //Splashフォームを閉じる
            CloseSplash();
        }
        #endregion

    }
}

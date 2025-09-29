//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : 得意先電子元帳
// プログラム概要   : 得意先電子元帳 テキスト出力用検索プログレスバー進捗状況の表示
//----------------------------------------------------------------------------//
//                (c)Copyright 2015 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 王亜楠
// 修 正 日  2015/02/05    修正内容 : テキスト出力件数制限なしモードの追加
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using System.ComponentModel;
using System.Diagnostics;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 得意先電子元帳 テキスト出力用検索プログレスバー進捗状況の表示
    /// </summary>
    /// <remarks>
    /// <br>Note       : テキスト出力用検索プログレスバー進捗状況の表示クラスです。</br>
    /// <br>Programmer : 王亜楠</br>
    /// <br>Date       : 2015/02/05</br>
    /// </remarks>
    public class PMKAU04004UD : IDisposable
    {
        // Fields
        private volatile PMKAU04004UC _form;
        private volatile bool _isClosing;
        private bool _isShowing;
        private Form _ownerForm;
        private Thread _showingThread;
        private ManualResetEvent _startEvent;
        private EventHandler _cancelButtonClick;
        /// <summary>抽出総件数</summary>
        private int _searchMax;
        /// <summary>抽出件数</summary>
        private int _seachCount;

        /// <summary>
        /// 抽出件数
        /// </summary>
        public int SearchMax
        {
            get { return _searchMax; }
            set { _searchMax = value; }
        }

        /// <summary>
        /// キャンセルイベント
        /// </summary>
        public event EventHandler CancelButtonClick
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            add
            {
                this._cancelButtonClick = (EventHandler)Delegate.Combine(this._cancelButtonClick, value);
            }


            [MethodImpl(MethodImplOptions.Synchronized)]
            remove
            {
                this._cancelButtonClick = (EventHandler)Delegate.Remove(this._cancelButtonClick, value);
            }
        }

        /// <summary>
        /// 閉じる
        /// </summary>
        /// <remarks>
        /// <br>Note       : 閉じる。</br>
        /// <br>Programmer : 王亜楠</br>
        /// <br>Date       : 2015/02/05</br>
        /// </remarks>
        public void Close()
        {
            this._isClosing = true;
            if ((this._form != null) && !this._form.IsDisposed)
            {
                this._form.Invoke(new MethodInvoker(this._form.Close));
            }
            System.Windows.Forms.Application.DoEvents();
        }

        /// <summary>
        /// 閉じる
        /// </summary>
        /// <remarks>
        /// <br>Note       : 閉じる。</br>
        /// <br>Programmer : 王亜楠</br>
        /// <br>Date       : 2015/02/05</br>
        /// </remarks>
        public void Dispose()
        {
            if ((this._form != null) && !this._form.IsDisposed)
            {
                this._form.Invoke(new MethodInvoker(this._form.Dispose));
            }
        }

        /// <summary>
        /// コンストラクター
        /// </summary>
        /// <remarks>
        /// <br>Note       : コンストラクターです。</br>
        /// <br>Programmer : 王亜楠</br>
        /// <br>Date       : 2015/02/05</br>
        /// </remarks>
        public PMKAU04004UD()
        {
        }

        /// <summary>
        /// プログレスバー進捗状況の更新
        /// </summary>
        /// <remarks>
        /// <br>Note       : プログレスバー進捗状況の更新。</br>
        /// <br>Programmer : 王亜楠</br>
        /// <br>Date       : 2015/02/05</br>
        /// </remarks>
        /// <param name="seachCount"></param>
        public void ProgressBarUpEvent(int seachCount)
        {
            this._seachCount = seachCount;
            if ((this._form != null) && !this._form.IsDisposed)
            {
                this._form.Invoke(new MethodInvoker(this.SetProgressBarUp));
            }
        }

        /// <summary>
        /// プログレスバー進捗状況の更新
        /// </summary>
        /// <remarks>
        /// <br>Note       : プログレスバー進捗状況の更新。</br>
        /// <br>Programmer : 王亜楠</br>
        /// <br>Date       : 2015/02/05</br>
        /// </remarks>
        private void SetProgressBarUp()
        {
            if ((this._form != null) && !this._form.IsDisposed)
            {
                this._form.ProgressBarUpEvent(this._seachCount);
            }
        }

        /// <summary>
        /// プログレスバー進捗状況画面の閉じる
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : プログレスバー進捗状況画面の閉じる。</br>
        /// <br>Programmer : 王亜楠</br>
        /// <br>Date       : 2015/02/05</br>
        /// </remarks>
        private void _form_Closing(object sender, CancelEventArgs e)
        {
            if (!this._isClosing)
            {
                e.Cancel = true;
            }
        }

        /// <summary>
        /// プログレスバー進捗状況画面のActivated
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : プログレスバー進捗状況画面のActivated。</br>
        /// <br>Programmer : 王亜楠</br>
        /// <br>Date       : 2015/02/05</br>
        /// </remarks>
        private void _form_Activated(object sender, EventArgs e)
        {
            this._form.Activated -= new EventHandler(this._form_Activated);
            this._startEvent.Set();
        }

        /// <summary>
        /// メインフォームの取得
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : メインフォームの取得。</br>
        /// <br>Programmer : 王亜楠</br>
        /// <br>Date       : 2015/02/05</br>
        /// </remarks>
        private Form GetMainForm()
        {
            Form activeForm = null;
            IntPtr mainWindowHandle = Process.GetCurrentProcess().MainWindowHandle;
            if (mainWindowHandle != IntPtr.Zero)
            {
                Control control = Control.FromHandle(mainWindowHandle);
                if ((control != null) && !control.IsDisposed)
                {
                    activeForm = (Form)control;
                }
            }
            if (activeForm == null)
            {
                activeForm = Form.ActiveForm;
                if (activeForm != null)
                {
                    return activeForm;
                }
                if (System.Windows.Forms.Application.OpenForms.Count > 0)
                {
                    activeForm = System.Windows.Forms.Application.OpenForms[0];
                }
                if (activeForm == null)
                {
                    System.Windows.Forms.Application.DoEvents();
                    activeForm = Form.ActiveForm;
                }
            }
            return activeForm;
        }

        /// <summary>
        /// プログレスバー進捗状況の表示
        /// </summary>
        /// <remarks>
        /// <br>Note       : プログレスバー進捗状況の表示。</br>
        /// <br>Programmer : 王亜楠</br>
        /// <br>Date       : 2015/02/05</br>
        /// </remarks>
        public void Show()
        {
            this.Show(null);
        }

        /// <summary>
        /// プログレスバー進捗状況の表示
        /// </summary>
        /// <remarks>
        /// <br>Note       : プログレスバー進捗状況の表示。</br>
        /// <br>Programmer : 王亜楠</br>
        /// <br>Date       : 2015/02/05</br>
        /// </remarks>
        /// <param name="owner"></param>
        public void Show(Form owner)
        {
            if (!this._isShowing)
            {
                this._ownerForm = owner;
                this._isShowing = true;
                this._isClosing = false;
                this._startEvent = new ManualResetEvent(false);
                this._showingThread = new Thread(new ThreadStart(this.ShowThread));
                this._showingThread.SetApartmentState(ApartmentState.STA);
                this._showingThread.IsBackground = true;
                this._showingThread.Start();
                this._startEvent.WaitOne();
            }
        }

        /// <summary>
        /// プログレスバー進捗状況の表示
        /// </summary>
        /// <remarks>
        /// <br>Note       : プログレスバー進捗状況の表示。</br>
        /// <br>Programmer : 王亜楠</br>
        /// <br>Date       : 2015/02/05</br>
        /// </remarks>
        private void ShowThread()
        {
            try
            {
                this._form = new PMKAU04004UC();
                this._form.Closing += new CancelEventHandler(this._form_Closing);
                this._form.Activated += new EventHandler(this._form_Activated);
                this._form.SearchMax = this._searchMax;
                this._form.Height = 126;
                if (this._cancelButtonClick != null)
                {
                    this._form.CancelButtonClick += this._cancelButtonClick;
                }
                if ((this._ownerForm != null) && this._ownerForm.Visible)
                {
                    this._form.StartPosition = FormStartPosition.Manual;
                    this._form.Left = this._ownerForm.Left + ((this._ownerForm.Width - this._form.Width) / 2);
                    this._form.Top = this._ownerForm.Top + ((this._ownerForm.Height - this._form.Height) / 2);
                }
                else
                {
                    Form mainForm = this.GetMainForm();
                    if (mainForm != null)
                    {
                        this._form.StartPosition = FormStartPosition.Manual;
                        this._form.Left = mainForm.Left + ((mainForm.Width - this._form.Width) / 2);
                        this._form.Top = mainForm.Top + ((mainForm.Height - this._form.Height) / 2);
                    }
                    else
                    {
                        this._form.StartPosition = FormStartPosition.CenterScreen;
                    }
                }
                this._form.ShowDialog();
            }
            finally
            {
                this._form.Dispose();
                this._form = null;
                this._isShowing = false;
            }
        }

    }
}

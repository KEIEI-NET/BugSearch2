//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 棚卸表示UI　PDF表示用
// プログラム概要   : 棚卸表示UI　PDF表示用
//----------------------------------------------------------------------------//
//                (c)Copyright 2014 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号               作成担当 : 田建委
// 作 成 日  2014/03/05   修正内容 : 新規作成
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// PDF表示画面UIクラス
    /// </summary>
    /// <remarks>
    /// <br>Note        : PDF表示画面UIクラスのインスタンスを生成します。</br>
    /// <br>Programmer  : 田建委</br>
    /// <br>Date        : 2014/03/05</br>
    /// </remarks>
    public partial class PMZAI04201UB : Form, IDisposable
    {
        [DllImport("ole32.dll")]
        extern static void CoFreeUnusedLibraries();

        private Form _ownerForm;
        private DCCMN04000UB _pdfViewer = new DCCMN04000UB();
        private string _pdfName;
        private bool _pdfResult;

        /// <summary>
        /// PDF表示画面UIクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note        : PDF表示画面UIクラスのインスタンスを生成します。</br>
        /// <br>Programmer  : 田建委</br>
        /// <br>Date        : 2014/03/05</br>
        /// </remarks>
        /// <param name="ownerForm"></param>
        public PMZAI04201UB(Form ownerForm)
        {
            InitializeComponent();
            _ownerForm = ownerForm;
        }

        /// <summary>
        /// PDF表示画面のLoad
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note        : PDF表示画面のLoad。</br>
        /// <br>Programmer  : 田建委</br>
        /// <br>Date        : 2014/03/05</br>
        /// </remarks>
        private void PMZAI04201UB_Load(object sender, EventArgs e)
        {
            this._pdfViewer = new DCCMN04000UB();
            this.Controls.Add(this._pdfViewer);
            this._pdfViewer.Dock = DockStyle.Fill;

            this.Width = _ownerForm.Width;
            this.Height = _ownerForm.Height;
            this.Left = _ownerForm.Left;
            this.Top = _ownerForm.Top;
        }

        /// <summary>
        /// PDF表示
        /// </summary>
        /// <param name="pdfName"></param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note        : PDF表示を行う。</br>
        /// <br>Programmer  : 田建委</br>
        /// <br>Date        : 2014/03/05</br>
        /// </remarks>
        public bool PDFShow(string pdfName)
        {
            _pdfName = pdfName;
            _pdfResult = false;
            this.ShowDialog();

            return _pdfResult;
        }

        /// <summary>
        /// PDF表示画面のShown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note        : PDF表示画面のShown。</br>
        /// <br>Programmer  : 田建委</br>
        /// <br>Date        : 2014/03/05</br>
        /// </remarks>
        private void PMZAI04201UB_Shown(object sender, EventArgs e)
        {
            _pdfResult = this._pdfViewer.PDFShow(_pdfName);
        }

        /// <summary>
        /// PDF表示画面閉じるイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note        : DF表示画面閉じるイベント。</br>
        /// <br>Programmer  : 田建委</br>
        /// <br>Date        : 2014/03/05</br>
        /// </remarks>
        private void PMZAI04201UB_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                // ブラウザコントロールを明確に破棄する
                _pdfViewer.Dispose();
                // 破棄の為の時間をシステムに与える
                System.Windows.Forms.Application.DoEvents();
            }
            finally
            {
                //  使用DLLを完全解放
                CoFreeUnusedLibraries();
            }
        }
    }
}
//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 未入金一覧表
// プログラム概要   : 未入金一覧表情報を抽出し、印刷・PDF出力する
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 22018 鈴木正臣
// 作 成 日  2010/07/01  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 22018 鈴木正臣
// 作 成 日  2010/11/02  修正内容 : 新規作成
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.Remoting;

using Broadleaf.Application.Common;
using Broadleaf.Windows.Forms;
// --- ADD m.suzuki 2010/11/02 ---------->>>>>
using System.Runtime.InteropServices;
// --- ADD m.suzuki 2010/11/02 ----------<<<<<

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 未入金一覧表 PDF表示フォーム
    /// </summary>
    /// <remarks>
    /// <br>Note       : 未入金一覧表PDF表示を行うフォームです。</br>
    /// <br>Programmer : 22018 鈴木正臣</br>
    /// <br>Date       : 2010/07/01</br>
    /// <br></br>
    /// <br>Update Note: 2010/11/02  22018 鈴木 正臣</br>
    /// <br>           : Adobe Reader9以降だと終了時エラー発生する件の対応。(WebBrowser解放処理の修正)</br>
    /// </remarks>
	public partial class PMKAU02000UB : Form, IDisposable
	{
        // --- ADD m.suzuki 2010/11/02 ---------->>>>>
        [DllImport( "ole32.dll" )]
        extern static void CoFreeUnusedLibraries();
        // --- ADD m.suzuki 2010/11/02 ----------<<<<<

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="ownerForm"></param>
        public PMKAU02000UB( Form ownerForm )
        {
            InitializeComponent();
            _ownerForm = ownerForm;
        }

        private Form _ownerForm;
        private DCCMN04000UB _pdfViewer = new DCCMN04000UB();
        private string _pdfName;
        private bool _pdfResult;

        /// <summary>
        /// Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PMKAU02000UB_Load(object sender, EventArgs e)
		{
            this._pdfViewer = new DCCMN04000UB();
            this.Controls.Add( this._pdfViewer );
            this._pdfViewer.Dock = DockStyle.Fill;

            if ( _ownerForm != null )
            {
                this.Width = _ownerForm.Width;
                this.Height = _ownerForm.Height;
                this.Left = _ownerForm.Left;
                this.Top = _ownerForm.Top;
            }
		}
        /// <summary>
        /// PDFShow
        /// </summary>
        /// <param name="pdfName"></param>
        /// <returns></returns>
        public bool PDFShow( string pdfName )
        {
            _pdfName = pdfName;
            _pdfResult = false;
            this.ShowDialog();

            return _pdfResult;
        }
        /// <summary>
        /// Shown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PMKAU02000UB_Shown( object sender, EventArgs e )
        {
            _pdfResult = this._pdfViewer.PDFShow( _pdfName );
        }
        /// <summary>
        /// FormClosing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PMKAU02000UB_FormClosing( object sender, FormClosingEventArgs e )
        {
        }
        /// <summary>
        /// FormClosed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PMKAU02000UB_FormClosed( object sender, FormClosedEventArgs e )
        {
            // --- ADD m.suzuki 2010/11/02 ---------->>>>>
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
            // --- ADD m.suzuki 2010/11/02 ----------<<<<<
        }
        /// <summary>
        /// Dispose
        /// </summary>
        void IDisposable.Dispose()
        {
            // --- DEL m.suzuki 2010/11/02 ---------->>>>>
            //if ( this._pdfViewer != null )
            //{
            //    this.Controls.Remove( this._pdfViewer );
            //    this._pdfViewer.Dispose();
            //}
            // --- DEL m.suzuki 2010/11/02 ----------<<<<<
        }
    }
}
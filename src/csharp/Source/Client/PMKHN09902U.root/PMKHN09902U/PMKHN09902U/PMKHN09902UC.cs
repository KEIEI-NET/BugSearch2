//**********************************************************************//
// システム         ：.NSシリーズ
// プログラム名称   ：掛率一括登録・修正Ⅱ
// プログラム概要   ：掛率マスタの登録・修正をを一括で行う
// ---------------------------------------------------------------------//
//					Copyright(c) 2013 Broadleaf Co.,Ltd.				//
// =====================================================================//
// 履歴
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：李占川
// 修正日    2013/02/17     修正内容：新規作成
// ---------------------------------------------------------------------//
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
using System.Runtime.InteropServices;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// PMKHN09902UCクラス
    /// </summary>
	public partial class PMKHN09902UC : Form, IDisposable
	{
        [DllImport( "ole32.dll" )]
        extern static void CoFreeUnusedLibraries();

        /// <summary>
        /// PMKHN09902UC
        /// </summary>
        /// <param name="ownerForm">フォーム</param>
        public PMKHN09902UC( Form ownerForm )
        {
            InitializeComponent();
            _ownerForm = ownerForm;
        }

        private Form _ownerForm;
        private DCCMN04000UB _pdfViewer = new DCCMN04000UB();
        private string _pdfName;
        private bool _pdfResult;

        /// <summary>
        /// PMKAU04001UB_Load画面ロード処理
        /// </summary>
        /// <param name="sender">senderオブジェクト</param>
        /// <param name="e">eオブジェクト</param>
        private void PMKAU04001UB_Load(object sender, EventArgs e)
		{
            this._pdfViewer = new DCCMN04000UB();
            this.Controls.Add( this._pdfViewer );
            this._pdfViewer.Dock = DockStyle.Fill;

            this.Width = _ownerForm.Width;
            this.Height = _ownerForm.Height;
            this.Left = _ownerForm.Left;
            this.Top = _ownerForm.Top;
		}

        /// <summary>
        /// PDF表示処理
        /// </summary>
        /// <param name="pdfName">PDFパス</param>
        /// <returns>フラグ</returns>
        public bool PDFShow( string pdfName )
        {
            _pdfName = pdfName;
            _pdfResult = false;
            this.ShowDialog();

            return _pdfResult;
        }

        /// <summary>
        /// PDF表示処理
        /// </summary>
        /// <param name="sender">senderオブジェクト</param>
        /// <param name="e">eオブジェクト</param>
        private void PMKAU04001UB_Shown( object sender, EventArgs e )
        {
            _pdfResult = this._pdfViewer.PDFShow( _pdfName );
        }

        /// <summary>
        /// 画面Closing処理
        /// </summary>
        /// <param name="sender">senderオブジェクト</param>
        /// <param name="e">eオブジェクト</param>
        private void PMKAU04001UB_FormClosing( object sender, FormClosingEventArgs e )
        {
        }

        /// <summary>
        /// 画面Closed処理
        /// </summary>
        /// <param name="sender">senderオブジェクト</param>
        /// <param name="e">eオブジェクト</param>
        private void PMKAU04001UB_FormClosed( object sender, FormClosedEventArgs e )
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

        /// <summary>
        /// Dispose処理
        /// </summary>
        void IDisposable.Dispose()
        {
            
        }
    }
}
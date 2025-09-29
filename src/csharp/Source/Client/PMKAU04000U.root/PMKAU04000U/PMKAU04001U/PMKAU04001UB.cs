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
	public partial class PMKAU04001UB : Form, IDisposable
	{
        // --- ADD m.suzuki 2010/11/02 ---------->>>>>
        [DllImport( "ole32.dll" )]
        extern static void CoFreeUnusedLibraries();
        // --- ADD m.suzuki 2010/11/02 ----------<<<<<

        public PMKAU04001UB( Form ownerForm )
        {
            InitializeComponent();
            _ownerForm = ownerForm;
        }

        private Form _ownerForm;
        private DCCMN04000UB _pdfViewer = new DCCMN04000UB();
        private string _pdfName;
        private bool _pdfResult;

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

        public bool PDFShow( string pdfName )
        {
            _pdfName = pdfName;
            _pdfResult = false;
            this.ShowDialog();

            return _pdfResult;
        }

        private void PMKAU04001UB_Shown( object sender, EventArgs e )
        {
            _pdfResult = this._pdfViewer.PDFShow( _pdfName );
        }

        private void PMKAU04001UB_FormClosing( object sender, FormClosingEventArgs e )
        {
        }

        private void PMKAU04001UB_FormClosed( object sender, FormClosedEventArgs e )
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
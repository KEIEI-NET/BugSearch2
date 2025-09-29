//**********************************************************************//
// �V�X�e��         �F.NS�V���[�Y
// �v���O��������   �F�|���ꊇ�o�^�E�C���U
// �v���O�����T�v   �F�|���}�X�^�̓o�^�E�C�������ꊇ�ōs��
// ---------------------------------------------------------------------//
//					Copyright(c) 2013 Broadleaf Co.,Ltd.				//
// =====================================================================//
// ����
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�                 �쐬�S���F�����
// �C����    2013/02/17     �C�����e�F�V�K�쐬
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
    /// PMKHN09902UC�N���X
    /// </summary>
	public partial class PMKHN09902UC : Form, IDisposable
	{
        [DllImport( "ole32.dll" )]
        extern static void CoFreeUnusedLibraries();

        /// <summary>
        /// PMKHN09902UC
        /// </summary>
        /// <param name="ownerForm">�t�H�[��</param>
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
        /// PMKAU04001UB_Load��ʃ��[�h����
        /// </summary>
        /// <param name="sender">sender�I�u�W�F�N�g</param>
        /// <param name="e">e�I�u�W�F�N�g</param>
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
        /// PDF�\������
        /// </summary>
        /// <param name="pdfName">PDF�p�X</param>
        /// <returns>�t���O</returns>
        public bool PDFShow( string pdfName )
        {
            _pdfName = pdfName;
            _pdfResult = false;
            this.ShowDialog();

            return _pdfResult;
        }

        /// <summary>
        /// PDF�\������
        /// </summary>
        /// <param name="sender">sender�I�u�W�F�N�g</param>
        /// <param name="e">e�I�u�W�F�N�g</param>
        private void PMKAU04001UB_Shown( object sender, EventArgs e )
        {
            _pdfResult = this._pdfViewer.PDFShow( _pdfName );
        }

        /// <summary>
        /// ���Closing����
        /// </summary>
        /// <param name="sender">sender�I�u�W�F�N�g</param>
        /// <param name="e">e�I�u�W�F�N�g</param>
        private void PMKAU04001UB_FormClosing( object sender, FormClosingEventArgs e )
        {
        }

        /// <summary>
        /// ���Closed����
        /// </summary>
        /// <param name="sender">sender�I�u�W�F�N�g</param>
        /// <param name="e">e�I�u�W�F�N�g</param>
        private void PMKAU04001UB_FormClosed( object sender, FormClosedEventArgs e )
        {
            try
            {
                // �u���E�U�R���g���[���𖾊m�ɔj������
                _pdfViewer.Dispose();
                // �j���ׂ̈̎��Ԃ��V�X�e���ɗ^����
                System.Windows.Forms.Application.DoEvents();
            }
            finally
            {
                //  �g�pDLL�����S���
                CoFreeUnusedLibraries();
            }
        }

        /// <summary>
        /// Dispose����
        /// </summary>
        void IDisposable.Dispose()
        {
            
        }
    }
}
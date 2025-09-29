using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.Remoting;
using Broadleaf.Application.Common;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// UOE���ɍX�V���C���t���[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : UOE���ɍX�V�̃��C���t���[���N���X�ł��B</br>
    /// <br>Programmer : �Ɠc �M�u</br>
    /// <br>Date       : 2008/09/04</br>
    /// </remarks>
    public partial class PMUOE01200UA : Form
	{
        // �ϐ�
        private PMUOE01201UA _uoeEnterUpdate;    // UI

        // ===================================================================================== //
        // �R���X�g���N�^
        // ===================================================================================== //
        #region ��Constructor
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer : �Ɠc �M�u</br>
        /// <br>Date       : 2008/09/04</br>
        /// </remarks>
        public PMUOE01200UA()
		{
			InitializeComponent();
        }
        #endregion

        // ===================================================================================== //
        // �C�x���g
        // ===================================================================================== //
        #region ��PMUOE01200UA_Load(�t�H�[�����[�h)
        /// <summary>
        /// �t�H�[�����[�h
        /// </summary>
        /// <param name="sender">PMUOE01200UA�^</param>
        /// <param name="e">��{�C�x���g�f�[�^</param>
        /// <remarks>
        /// <br>Note       : ��ʕ\�����ڂ̏��������s���܂��B</br>
        /// <br>Programmer : �Ɠc �M�u</br>
        /// <br>Date       : 2008/09/04</br>
        /// </remarks>
        private void PMUOE01200UA_Load(object sender, EventArgs e)
        {
            this._uoeEnterUpdate = new PMUOE01201UA();

            // PMUOE01200UA�\��
            this._uoeEnterUpdate.TopLevel = false;
            this._uoeEnterUpdate.FormBorderStyle = FormBorderStyle.None;
            this._uoeEnterUpdate.Show();

            // PMUOE01201UA��PMUOE01200UA�ɓ\��t����
            this._uoeEnterUpdate.Dock = DockStyle.Fill;
            this._uoeEnterUpdate.FormClosed += new FormClosedEventHandler(this.UOEEnterUpdateForm_FormClosed);
            this.Controls.Add(this._uoeEnterUpdate);
        }
        #endregion

        // ===================================================================================== //
        // �f���Q�[�g
        // ===================================================================================== //
        #region ��UOEEnterUpdateForm_FormClosed(�t�H�[���N���[�Y)
        /// <summary>
        /// �t�H�[���N���[�Y
        /// </summary>
        /// <param name="sender">PMUOE01201UA�^</param>
        /// <param name="e">�t�H�[���N���[�Y�C�x���g�f�[�^</param>
        /// <remarks>
        /// <br>Note       : �t�H�[������܂��B</br>
        /// <br>Programmer : �Ɠc �M�u</br>
        /// <br>Date       : 2008/09/04</br>
        /// </remarks>
        private void UOEEnterUpdateForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}
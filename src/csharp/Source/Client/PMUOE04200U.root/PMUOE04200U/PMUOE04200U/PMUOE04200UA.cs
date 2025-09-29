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
    /// �t�n�d�񓚕\��(����)
    /// </summary>
    /// <remarks>
    /// <br>Note       : </br>
    /// <br>Programmer : </br>
    /// <br>Date       : </br>
    /// <br></br>
    /// <br>Update Note: 2010/11/25  22018 ��� ���b</br>
    /// <br>           : Adobe Reader9�ȍ~���ƏI�����G���[�������錏�̑Ή��B(WebBrowser��������̏C��)</br>
    /// <br></br>
    /// </remarks>
    public partial class PMUOE04200UA : Form
	{
        private PMUOE04201UA _uoeReplyReference;    // UI

        #region ��Constructor
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        public PMUOE04200UA()
		{
			InitializeComponent();
        }
        #endregion

        #region ��PMUOE04201UA_Load(�t�H�[�����[�h)
        /// <summary>
        /// �t�H�[�����[�h
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : �t�H�[���N�����̏����B</br>
        /// <br>Programmer : �Ɠc �M�u</br>
        /// <br>Date       : 2008/11/10</br>
        /// </remarks>
        private void PMUOE04201UA_Load(object sender, EventArgs e)
        {
            this.Text = "UOE�񓚕\��(����)";                //ADD 2009/01/20 �s��Ή�[9833]

            this._uoeReplyReference = new PMUOE04201UA();

            this._uoeReplyReference.TopLevel = false;
            this._uoeReplyReference.FormBorderStyle = FormBorderStyle.None;
            this._uoeReplyReference.Show();

            this._uoeReplyReference.Dock = DockStyle.Fill;
            this._uoeReplyReference.FormClosed += new FormClosedEventHandler(this.UOEReplyReferenceForm_FormClosed);
            this.Controls.Add(this._uoeReplyReference);
        }
        #endregion

        #region ��UOEReplyReferenceForm_FormClosed(�t�H�[���N���[�Y)
        /// <summary>
        /// �t�H�[���N���[�Y
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : �t�H�[������鎞�̏����B</br>
        /// <br>Programmer : �Ɠc �M�u</br>
        /// <br>Date       : 2008/11/10</br>
        /// </remarks>
        private void UOEReplyReferenceForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            // --- ADD m.suzuki 2010/11/25 ---------->>>>>
            // _uoeReplyReference���̂�Close�ɂ��{�������Ă΂�Ă���̂ŁA
            // _uoeReplyReference=null�ɂ��鎖�ŁA�Q�d�ɏ������Ȃ��悤�ɂ���B
            _uoeReplyReference = null;
            // --- ADD m.suzuki 2010/11/25 ----------<<<<<
            this.Close();
        }
        #endregion

        // --- ADD m.suzuki 2010/11/25 ---------->>>>>
        /// <summary>
        /// �t�H�[���N���[�Y����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PMUOE04200UA_FormClosed( object sender, FormClosedEventArgs e )
        {
            if ( _uoeReplyReference != null )
            {
                // �q�t�H�[���̉��
                _uoeReplyReference.FormClosed -= this.UOEReplyReferenceForm_FormClosed;
                _uoeReplyReference.Close();
                _uoeReplyReference.Dispose();
            }
        }
        // --- ADD m.suzuki 2010/11/25 ----------<<<<<
    }
}
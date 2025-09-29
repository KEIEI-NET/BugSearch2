//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �`�[�ԍ���������
// �v���O�����T�v   : �`�[�ԍ���������
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���m
// �� �� ��  2009/06/01  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 22018 ��� ���b
// �C �� ��  2010/11/02  �C�����e : ActiveReports�̃��C�Z���X���t�^����Ă��Ȃ��̂őΉ��B
//                                 (������Ƀg���C�A���ł̎|�A�󎚂���Ă��܂��̂ŏC��)
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 22018 ��� ���b
// �C �� ��  2010/11/25  �C�����e : Adobe Reader9�ȍ~���ƏI�����G���[�������錏�̑Ή��B(WebBrowser��������̏C��)
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// �`�[�ԍ����������t�H�[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �`�[�ԍ������������s���܂��B</br>
    /// <br>Programmer : ���m</br>
    /// <br>Date       : 2008.06.01</br>
    /// <br></br>
    /// <br>Update Note: 2010/11/25  22018 ��� ���b</br>
    /// <br>           : Adobe Reader9�ȍ~���ƏI�����G���[�������錏�̑Ή��B(WebBrowser��������̏C��)</br>
    /// <br></br>
    /// </remarks>
    public partial class PMUOE01600UA : Form
    {
        #region Constroctors
        /// <summary>
        /// �`�[�ԍ����������t�H�[���N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note		: �`�[�ԍ����������t�H�[���N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer	: ���m</br>
        /// <br>Date		: 2008.06.01</br>
        /// </remarks>
        public PMUOE01600UA()
        {
            InitializeComponent();
        }
        #endregion


        #region Private Members
        private PMUOE01601UA _slipNoAlwcForm;

        #endregion


        #region Event
        /// <summary>
        /// �`�[�ԍ����������t�H�[�����[�h�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : �Ȃ�</br>
        /// <br>Programmer : ���m</br>
        /// <br>Date       : 2008.03.27</br>
        /// </remarks>
        private void PMUOE01600UA_Load(object sender, EventArgs e)
        {
            this._slipNoAlwcForm = new PMUOE01601UA();

            this._slipNoAlwcForm.TopLevel = false;
            this._slipNoAlwcForm.FormBorderStyle = FormBorderStyle.None;
            this._slipNoAlwcForm.Show();
            this._slipNoAlwcForm.Dock = DockStyle.Fill;

            this.Text = this._slipNoAlwcForm.Text;

            this.Controls.Add(this._slipNoAlwcForm);
            this._slipNoAlwcForm.FormClosed += new FormClosedEventHandler(this.slipNoAlwc_FormClosed);
        }

        /// <summary>
        /// �`�[�ԍ����������t�H�[������C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : �Ȃ�</br>
        /// <br>Programmer : ���m</br>
        /// <br>Date       : 2008.03.27</br>
        /// </remarks>
        private void slipNoAlwc_FormClosed(object sender, FormClosedEventArgs e)
        {
            // --- ADD m.suzuki 2010/11/25 ---------->>>>>
            // _slipNoAlwcForm���g��Close�ɂ��{���������s����Ă���̂ŁA
            // _slipNoAlwcForm=null �ɂ��邱�Ƃ�
            _slipNoAlwcForm = null;
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
        private void PMUOE01600UA_FormClosed( object sender, FormClosedEventArgs e )
        {
            if ( _slipNoAlwcForm != null )
            {
                _slipNoAlwcForm.FormClosed -= this.slipNoAlwc_FormClosed;
                _slipNoAlwcForm.Close();
                _slipNoAlwcForm.Dispose();
            }
        }
        // --- ADD m.suzuki 2010/11/25 ----------<<<<<
    }
}
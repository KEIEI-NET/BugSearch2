//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : SCM�i�ڐݒ�}�X�^�����e�i���X
// �v���O�����T�v   : SCM�i�ڐݒ�}�X�^�̑�����s���܂�
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ��� ���b
// �� �� ��  2009/05/11  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��               �C�����e : 
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
    /// SCM�i�ڐݒ胁�C���t���[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note		: �|���}�X�^�ꊇ�C���E�o�^UI�N���X��\�����܂��B</br>
    /// <br>Programmer	: 22018 ��� ���b</br>
    /// <br>Date		: 2009/05/21</br>
    /// </remarks>
    public partial class PMSCM09000UA : Form
    {
        PMSCM09001UA _pmkhn09401UA;

        /// <summary>
        /// �|���}�X�^�ꊇ�C���E�o�^���C���t���[���N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note		: �|���}�X�^�ꊇ�C���E�o�^���C���t���[���N���X�̃C���X�^���X�𐶐����܂��B</br>
        /// <br>Programmer	: 22018 ��� ���b</br>
        /// <br>Date		: 2009/05/21</br>
        /// </remarks>
        public PMSCM09000UA()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Load �C�x���g
        /// </summary>
        /// <remarks>
        /// <br>Note		: ��ʂ�Load���ꂽ���ɔ������܂��B</br>
        /// <br>Programmer	: 22018 ��� ���b</br>
        /// <br>Date		: 2009/05/21</br>
        /// </remarks>
        private void PMSCM09000UA_Load(object sender, EventArgs e)
        {
            this._pmkhn09401UA = new PMSCM09001UA();
            this._pmkhn09401UA.TopLevel = false;
            this._pmkhn09401UA.FormBorderStyle = FormBorderStyle.None;
            this._pmkhn09401UA.Show();
            this.Controls.Add(this._pmkhn09401UA);
            this._pmkhn09401UA.Dock = DockStyle.Fill;

            this._pmkhn09401UA.FormClosed += new FormClosedEventHandler(PMSCM09001UA_FormClosed);
        }

        /// <summary>
        /// ��ʏI������
        /// </summary>
        /// <remarks>
        /// <br>Note		: �|���}�X�^�ꊇ�C���E�o�^���C���t���[����ʂ��I�����܂��B</br>
        /// <br>Programmer	: 22018 ��� ���b</br>
        /// <br>Date		: 2009/05/21</br>
        /// </remarks>
        private void PMSCM09001UA_FormClosed(object sender, FormClosedEventArgs e)
        {
            Close();
        }

        /// <summary>
        /// FormClosing �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note        : �t�H�[���������鎞�ɔ������܂��B</br>
        /// <br>Programmer  : 22018 ��� ���b</br>
        /// <br>Date        : 2009/05/21</br>
        /// </remarks>
        private void PMSCM09000UA_FormClosing(object sender, FormClosingEventArgs e)
        {
            // ��ʏ���r
            bool bStatus = this._pmkhn09401UA.CompareScreen();
            if (!bStatus)
            {
                e.Cancel = true;
            }

            // XML�ۑ�
            this._pmkhn09401UA.SaveStateXmlData();
        }
    }
}
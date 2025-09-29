//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �����ꊇ�C��
// �v���O�����T�v   : �����ꊇ�C�����s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���M
// �� �� ��  2009/04/14  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��              �C�����e : 
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
    /// �����ꊇ�C�����C���t���[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note		: �����ꊇ�C��UI�N���X��\�����܂��B</br>
    /// <br>Programmer	: ���M</br>
    /// <br>Date		: 2009/04/01</br>
    /// </remarks>
    public partial class PMKHN09430UA : Form
    {
        PMKHN09431UA _pmkhn09431UA;

        /// <summary>
        ///�����ꊇ�C�����C���t���[���N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note		: �����ꊇ�C�����C���t���[���N���X�̃C���X�^���X�𐶐����܂��B</br>
        /// <br>Programmer	: ���M</br>
        /// <br>Date		: 2009/04/01</br>
        /// </remarks>
        public PMKHN09430UA()
        {
            InitializeComponent();
        }

        /// <summary>
        /// FormClosing �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note        : �t�H�[���������鎞�ɔ������܂��B</br>
        /// <br>Programmer  : ���M</br>
        /// <br>Date        : 2009/04/01</br>
        /// </remarks>
        private void PMKHN09430UA_FormClosing(object sender, FormClosingEventArgs e)
        {
            // XML�ۑ�
            this._pmkhn09431UA.SaveStateXmlData();
        }

        /// <summary>
        /// ��ʏI������
        /// </summary>
        /// <remarks>
        /// <br>Note		: �����ꊇ�C�����C���t���[����ʂ��I�����܂��B</br>
        /// <br>Programmer	: ���M</br>
        /// <br>Date		: 2009/04/01</br>
        /// </remarks>
        private void PMKHN09431UA_FormClosed(object sender, FormClosedEventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Load �C�x���g
        /// </summary>
        /// <remarks>
        /// <br>Note		: ��ʂ�Load���ꂽ���ɔ������܂��B</br>
        /// <br>Programmer	: ���M</br>
        /// <br>Date		: 2009/04/01</br>
        /// </remarks>
        private void PMKHN09430UA_Load(object sender, EventArgs e)
        {
            this._pmkhn09431UA = new PMKHN09431UA();
            this._pmkhn09431UA.TopLevel = false;
            this._pmkhn09431UA.FormBorderStyle = FormBorderStyle.None;
            this._pmkhn09431UA.Show();
            this.Controls.Add(this._pmkhn09431UA);
            this._pmkhn09431UA.Dock = DockStyle.Fill;

            this._pmkhn09431UA.FormClosed += new FormClosedEventHandler(PMKHN09431UA_FormClosed);
        }
    }
}
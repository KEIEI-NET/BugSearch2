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
    /// �ʐM���O�f�[�^�Ɖ�C���t���[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note		: �ʐM���O�f�[�^�Ɖ�UI�N���X��\�����܂��B</br>
    /// <br>Programmer	: 30350 �N�� ����</br>
    /// <br>Date		: 2008/12/02</br>
    /// </remarks>
    public partial class PMUOE04350UA : Form
    {
        PMUOE04351UA _pmuoe04351UA;

        /// <summary>
        /// �ʐM���O�f�[�^�Ɖ�C���t���[���N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note		: �ʐM���O�f�[�^�Ɖ�C���t���[���N���X�̃C���X�^���X�𐶐����܂��B</br>
        /// <br>Programmer	: 30350 �N�� ����</br>
        /// <br>Date		: 2008/12/02</br>
        /// </remarks>
        public PMUOE04350UA()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Load �C�x���g
        /// </summary>
        /// <remarks>
        /// <br>Note		: ��ʂ�Load���ꂽ���ɔ������܂��B</br>
        /// <br>Programmer	: 30350 �N�� ����/br>
        /// <br>Date		: 2008/12/02</br>
        /// </remarks>
        private void PMUOE04350UA_Load(object sender, EventArgs e)
        {
            this._pmuoe04351UA = new PMUOE04351UA();
            this._pmuoe04351UA.TopLevel = false;
            this._pmuoe04351UA.FormBorderStyle = FormBorderStyle.None;
            this._pmuoe04351UA.Show();
            this.Controls.Add(this._pmuoe04351UA);
            this._pmuoe04351UA.Dock = DockStyle.Fill;

            this._pmuoe04351UA.FormClosed += new FormClosedEventHandler(PMUOE04350UA_FormClosed);
        }

        /// <summary>
        /// ��ʏI������
        /// </summary>
        /// <remarks>
        /// <br>Note		: �ʐM���O�f�[�^�Ɖ�C���t���[����ʂ��I�����܂��B</br>
        /// <br>Programmer	: 30350 �N�� ����</br>
        /// <br>Date		: 2008/12/02</br>
        /// </remarks>
        private void PMUOE04350UA_FormClosed(object sender, FormClosedEventArgs e)
        {
            Close();
        }
    }
}
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
    /// DSP���O�f�[�^�Ɖ�C���t���[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note		: DSP�f�[�^���O�Ɖ�UI�N���X��\�����܂��B</br>
    /// <br>Programmer	: 30350 �N�� ����</br>
    /// <br>Date		: 2008/12/02</br>
    /// </remarks>
    public partial class PMUOE04300UA : Form
    {
        PMUOE04301UA _pmuoe04301UA;

        /// <summary>
        /// DSP���O�f�[�^�Ɖ�C���t���[���N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note		: DSP�f�[�^���O�Ɖ�C���t���[���N���X�̃C���X�^���X�𐶐����܂��B</br>
        /// <br>Programmer	: 30350 �N�� ����</br>
        /// <br>Date		: 2008/12/02</br>
        /// </remarks>
        public PMUOE04300UA()
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
        private void PMUOE04300UA_Load(object sender, EventArgs e)
        {
            this._pmuoe04301UA = new PMUOE04301UA();
            this._pmuoe04301UA.TopLevel = false;
            this._pmuoe04301UA.FormBorderStyle = FormBorderStyle.None;
            this._pmuoe04301UA.Show();
            this.Controls.Add(this._pmuoe04301UA);
            this._pmuoe04301UA.Dock = DockStyle.Fill;

            this._pmuoe04301UA.FormClosed += new FormClosedEventHandler(PMUOE04300UA_FormClosed);
        }

        /// <summary>
        /// ��ʏI������
        /// </summary>
        /// <remarks>
        /// <br>Note		: DSP���O�f�[�^�Ɖ�C���t���[����ʂ��I�����܂��B</br>
        /// <br>Programmer	: 30350 �N�� ����</br>
        /// <br>Date		: 2008/12/02</br>
        /// </remarks>
        private void PMUOE04300UA_FormClosed(object sender, FormClosedEventArgs e)
        {
            Close();
        }
    }
}
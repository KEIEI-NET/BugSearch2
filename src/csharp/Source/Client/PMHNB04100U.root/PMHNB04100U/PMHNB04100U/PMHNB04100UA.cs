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
    /// �o�ו��i�\�����C���t���[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note		: �o�ו��i�\��UI�N���X��\�����܂��B</br>
    /// <br>Programmer	: 30414 �E�@�K�j</br>
    /// <br>Date		: 2008/11/10</br>
    /// </remarks>
    public partial class PMHNB04100UA : Form
    {
        PMHNB04101UA _pmhnb04101UA;

        /// <summary>
        /// �o�ו��i�\�����C���t���[���N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note		: �o�ו��i�\�����C���t���[���N���X�̃C���X�^���X�𐶐����܂��B</br>
        /// <br>Programmer	: 30414 �E�@�K�j</br>
        /// <br>Date		: 2008/11/10</br>
        /// </remarks>
        public PMHNB04100UA()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Load �C�x���g
        /// </summary>
        /// <remarks>
        /// <br>Note		: ��ʂ�Load���ꂽ���ɔ������܂��B</br>
        /// <br>Programmer	: 30414 �E�@�K�j</br>
        /// <br>Date		: 2008/11/10</br>
        /// </remarks>
        private void PMHNB04100UA_Load(object sender, EventArgs e)
        {
            this._pmhnb04101UA = new PMHNB04101UA();
            this._pmhnb04101UA.TopLevel = false;
            this._pmhnb04101UA.FormBorderStyle = FormBorderStyle.None;
            this._pmhnb04101UA.Show();
            this.Controls.Add(this._pmhnb04101UA);
            this._pmhnb04101UA.Dock = DockStyle.Fill;

            this._pmhnb04101UA.FormClosed += new FormClosedEventHandler(PMHNB04101UA_FormClosed);
        }

        /// <summary>
        /// ��ʏI������
        /// </summary>
        /// <remarks>
        /// <br>Note		: �o�ו��i�\�����C���t���[����ʂ��I�����܂��B</br>
        /// <br>Programmer	: 30414 �E�@�K�j</br>
        /// <br>Date		: 2008/11/10</br>
        /// </remarks>
        private void PMHNB04101UA_FormClosed(object sender, FormClosedEventArgs e)
        {
            Close();
        }
    }
}
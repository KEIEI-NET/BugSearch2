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
    /// �݌Ɏ��яƉ�C���t���[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note		: �݌Ɏ��яƉ�UI�N���X��\�����܂��B</br>
    /// <br>Programmer	: 30350 �N�� ����</br>
    /// <br>Date		: 2008/11/25</br>
    /// </remarks>
    public partial class PMZAI04100UA : Form
    {
        PMZAI04101UA _pmzai04101UA;

        /// <summary>
        /// �݌Ɏ��яƉ�C���t���[���N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note		: �݌Ɏ��яƉ�C���t���[���N���X�̃C���X�^���X�𐶐����܂��B</br>
        /// <br>Programmer	: 30350 �N�� ����</br>
        /// <br>Date		: 2008/11/25</br>
        /// </remarks>
        public PMZAI04100UA()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Load �C�x���g
        /// </summary>
        /// <remarks>
        /// <br>Note		: ��ʂ�Load���ꂽ���ɔ������܂��B</br>
        /// <br>Programmer	: 30350 �N�� ����</br>
        /// <br>Date		: 2008/11/25</br>
        /// </remarks>
        private void PMZAI04100UA_Load(object sender, EventArgs e)
        {
            this._pmzai04101UA = new PMZAI04101UA();
            this._pmzai04101UA.TopLevel = false;
            this._pmzai04101UA.FormBorderStyle = FormBorderStyle.None;
            this._pmzai04101UA.Show();
            this.Controls.Add(this._pmzai04101UA);
            this._pmzai04101UA.Dock = DockStyle.Fill;

            this._pmzai04101UA.FormClosed += new FormClosedEventHandler(PMZAI04101UA_FormClosed);
        }

        /// <summary>
        /// ��ʏI������
        /// </summary>
        /// <remarks>
        /// <br>Note		: �݌Ɏ��яƉ�C���t���[����ʂ��I�����܂��B</br>
        /// <br>Programmer	: 30350 �N�� ����</br>
        /// <br>Date		: 2008/11/25</br>
        /// </remarks>
        private void PMZAI04101UA_FormClosed(object sender, FormClosedEventArgs e)
        {
            Close();
        }
    }
}
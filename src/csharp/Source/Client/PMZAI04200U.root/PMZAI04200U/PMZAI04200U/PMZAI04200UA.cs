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
    /// �I���\�����C���t���[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note		: �I���\��UI�N���X��\�����܂��B</br>
    /// <br>Programmer	: 30350 �N�� ����</br>
    /// <br>Date		: 2008/11/17</br>
    /// <br>Update Note : 2014/03/05 �c����</br>
    /// <br>            : Redmine#42247 ����@�\��ǉ�����ׁAActiveReports�̃��C�Z���X����t���B(licenses.licx)</br>
    /// </remarks>
    public partial class PMZAI04200UA : Form
    {
        PMZAI04201UA _pmzai04201UA;

        /// <summary>
        /// �I���\�����C���t���[���N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note		: �I���\�����C���t���[���N���X�̃C���X�^���X�𐶐����܂��B</br>
        /// <br>Programmer	: 30350 �N�� ����</br>
        /// <br>Date		: 2008/11/17</br>
        /// </remarks>
        public PMZAI04200UA()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Load �C�x���g
        /// </summary>
        /// <remarks>
        /// <br>Note		: ��ʂ�Load���ꂽ���ɔ������܂��B</br>
        /// <br>Programmer	: 30350 �N�� ����/br>
        /// <br>Date		: 2008/11/17</br>
        /// </remarks>
        private void PMZAI04200UA_Load(object sender, EventArgs e)
        {
            this._pmzai04201UA = new PMZAI04201UA();
            this._pmzai04201UA.TopLevel = false;
            this._pmzai04201UA.FormBorderStyle = FormBorderStyle.None;
            this._pmzai04201UA.Show();
            this.Controls.Add(this._pmzai04201UA);
            this._pmzai04201UA.Dock = DockStyle.Fill;

            this._pmzai04201UA.FormClosed += new FormClosedEventHandler(PMZAI04200UA_FormClosed);
        }

        /// <summary>
        /// ��ʏI������
        /// </summary>
        /// <remarks>
        /// <br>Note		: �I���\�����C���t���[����ʂ��I�����܂��B</br>
        /// <br>Programmer	: 30350 �N�� ����</br>
        /// <br>Date		: 2008/11/17</br>
        /// </remarks>
        private void PMZAI04200UA_FormClosed(object sender, FormClosedEventArgs e)
        {
            Close();
        }
    }
}
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
    /// �݌ɑg���E�����������C���t���[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note		: �݌ɑg���E��������UI�N���X��\�����܂��B</br>
    /// <br>Programmer	: 980035 ����@��`</br>
    /// <br>Date		: 2008/11/05</br>
    /// </remarks>
    public partial class PMZAI04020UA : Form
    {
        private PMZAI04021UA _customerCarSearchForm;

        /// <summary>
        /// �݌ɑg���E�����������C���t���[���N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note		: �݌ɑg���E�����������C���t���[���N���X�̃C���X�^���X�𐶐����܂��B</br>
        /// <br>Programmer	: 980035 ����@��`</br>
        /// <br>Date		: 2008/11/05</br>
        /// </remarks>
        public PMZAI04020UA()
        {
            InitializeComponent();
        }

        /// <summary>
        /// ��ʏI������
        /// </summary>
        /// <remarks>
        /// <br>Note		: �݌ɑg���E�����������C���t���[����ʂ��I�����܂��B</br>
        /// <br>Programmer	: 980035 ����@��`</br>
        /// <br>Date		: 2008/11/05</br>
        /// </remarks>
        private void CustomerCarSearchForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Load �C�x���g
        /// </summary>
        /// <remarks>
        /// <br>Note		: ��ʂ�Load���ꂽ���ɔ������܂��B</br>
        /// <br>Programmer	: 980035 ����@��`</br>
        /// <br>Date		: 2008/11/05</br>
        /// </remarks>
        private void PMZAI04020UA_Load(object sender, EventArgs e)
        {
            this._customerCarSearchForm = new PMZAI04021UA();
            this._customerCarSearchForm.TopLevel = false;
            this._customerCarSearchForm.FormBorderStyle = FormBorderStyle.None;
            this._customerCarSearchForm.Show();
            this.Controls.Add(this._customerCarSearchForm);
            this._customerCarSearchForm.Dock = DockStyle.Fill;

            this._customerCarSearchForm.FormClosed += new FormClosedEventHandler(CustomerCarSearchForm_FormClosed);
        }
    }
}
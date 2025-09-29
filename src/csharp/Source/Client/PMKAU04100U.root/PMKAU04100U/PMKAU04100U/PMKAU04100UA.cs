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
    /// �X�V����\�����C���t���[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note		: �X�V����\��UI�N���X��\�����܂��B</br>
    /// <br>Programmer	: 30414 �E�@�K�j</br>
    /// <br>Date		: 2008/09/29</br>
    /// </remarks>
    public partial class PMKAU04100UA : Form
    {
        private PMKAU04101UA _customerCarSearchForm;

        /// <summary>
        /// �X�V����\�����C���t���[���N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note		: �X�V����\�����C���t���[���N���X�̃C���X�^���X�𐶐����܂��B</br>
        /// <br>Programmer	: 30414 �E�@�K�j</br>
        /// <br>Date		: 2008/09/29</br>
        /// </remarks>
        public PMKAU04100UA()
        {
            InitializeComponent();
        }

        /// <summary>
        /// ��ʏI������
        /// </summary>
        /// <remarks>
        /// <br>Note		: �X�V����\�����C���t���[����ʂ��I�����܂��B</br>
        /// <br>Programmer	: 30414 �E�@�K�j</br>
        /// <br>Date		: 2008/09/29</br>
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
        /// <br>Programmer	: 30414 �E�@�K�j</br>
        /// <br>Date		: 2008/09/29</br>
        /// </remarks>
        private void PMKAU04100UA_Load(object sender, EventArgs e)
        {
            this._customerCarSearchForm = new PMKAU04101UA();
            this._customerCarSearchForm.TopLevel = false;
            this._customerCarSearchForm.FormBorderStyle = FormBorderStyle.None;
            this._customerCarSearchForm.Show();
            this.Controls.Add(this._customerCarSearchForm);
            this._customerCarSearchForm.Dock = DockStyle.Fill;

            this._customerCarSearchForm.FormClosed += new FormClosedEventHandler(CustomerCarSearchForm_FormClosed);
        }
    }
}
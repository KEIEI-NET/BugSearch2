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
    /// ���Ӑ�ꊇ�C�����C���t���[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note		: �o�ו��i�\��UI�N���X��\�����܂��B</br>
    /// <br>Programmer	: 30414 �E�@�K�j</br>
    /// <br>Date		: 2008/11/20</br>
    /// </remarks>
    public partial class PMKHN09350UA : Form
    {
        PMKHN09351UA _pmkhn09351UA;

        /// <summary>
        /// ���Ӑ�ꊇ�C�����C���t���[���N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note		: ���Ӑ�ꊇ�C�����C���t���[���N���X�̃C���X�^���X�𐶐����܂��B</br>
        /// <br>Programmer	: 30414 �E�@�K�j</br>
        /// <br>Date		: 2008/11/20</br>
        /// </remarks>
        public PMKHN09350UA()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Load �C�x���g
        /// </summary>
        /// <remarks>
        /// <br>Note		: ��ʂ�Load���ꂽ���ɔ������܂��B</br>
        /// <br>Programmer	: 30414 �E�@�K�j</br>
        /// <br>Date		: 2008/11/20</br>
        /// </remarks>
        private void PMKHN09350UA_Load(object sender, EventArgs e)
        {
            this._pmkhn09351UA = new PMKHN09351UA();
            this._pmkhn09351UA.TopLevel = false;
            this._pmkhn09351UA.FormBorderStyle = FormBorderStyle.None;
            this._pmkhn09351UA.Show();
            this.Controls.Add(this._pmkhn09351UA);
            this._pmkhn09351UA.Dock = DockStyle.Fill;

            this._pmkhn09351UA.FormClosed += new FormClosedEventHandler(PMHNB04101UA_FormClosed);
        }

        /// <summary>
        /// ��ʏI������
        /// </summary>
        /// <remarks>
        /// <br>Note		: ���Ӑ�ꊇ�C�����C���t���[����ʂ��I�����܂��B</br>
        /// <br>Programmer	: 30414 �E�@�K�j</br>
        /// <br>Date		: 2008/11/20</br>
        /// </remarks>
        private void PMHNB04101UA_FormClosed(object sender, FormClosedEventArgs e)
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
        /// <br>Programmer  : 30414 �E �K�j</br>
        /// <br>Date        : 2008/11/20</br>
        /// </remarks>
        private void PMKHN09350UA_FormClosing(object sender, FormClosingEventArgs e)
        {
            // ��ʏ���r
            bool bStatus = this._pmkhn09351UA.CompareScreen();
            if (!bStatus)
            {
                e.Cancel = true;
            }

            // XML�ۑ�
            this._pmkhn09351UA.SaveStateXmlData();
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Broadleaf.Windows.Forms
{
    public partial class SFCMN00047UBF : Form
    {
        //[System.Runtime.InteropServices.DllImport("user32.dll")] static extern bool SetForegroundWindow(IntPtr hWnd);

        public SFCMN00047UBF()
        {
            InitializeComponent();
        }

        /// <summary>
        /// �_�C�A���O�\��
        /// </summary>
        /// <param name="msg">�\�����b�Z�[�W</param>
        /// <param name="LimitDate">���O�I�t����</param>
        /// <remarks>
        /// <br>Note       :�_�C�A���O�\��</br>
        /// <br>Programmer  : 96203 ����@�K��</br>
        /// <br>Date        : 2008.06.06</br>
        /// </remarks>
        public void ShowMessageDialog(string msg)
        {

            lblMsg1.Text = msg;

            ShowDialog(null);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void SFCMN00047UBF_Shown(object sender, EventArgs e)
        {
            //SetForegroundWindow(this.Handle);

        }

    }
}
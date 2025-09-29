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
        /// ダイアログ表示
        /// </summary>
        /// <param name="msg">表示メッセージ</param>
        /// <param name="LimitDate">ログオフ期限</param>
        /// <remarks>
        /// <br>Note       :ダイアログ表示</br>
        /// <br>Programmer  : 96203 鹿野　幸生</br>
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
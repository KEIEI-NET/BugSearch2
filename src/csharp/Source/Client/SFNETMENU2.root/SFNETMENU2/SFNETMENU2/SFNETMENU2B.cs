using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using Broadleaf.Library.Resources;

namespace Broadleaf.Windows.Forms
{

    /// <summary>
    /// �N�����\����ʃN���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �N�����\����ʃN���X</br>
    /// <br>Programmer : 96203 ����@�K��</br>
    /// <br>Date       : 2006.09.04</br>
    /// <br></br>
    /// <br>Update Note: 200x.xx.xx �w�w  �w�w</br>
    /// </remarks>
    public partial class SFNETMENU2B : Form
    {
        private int _mImageIndex = 0;
        private int _mCloseTime = 0;
        private int _mStackTime = 0;
        private int _mImageMaxFig = 0;

        /// <summary>
        /// �N�����\����ʃR���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �N�����\����ʃR���X�g���N�^</br>
        /// <br>Programmer : 96203 ����@�K��</br>
        /// <br>Date       : 2006.09.04</br>
        /// </remarks>
        public SFNETMENU2B()
        {
            InitializeComponent();

            lblMessage.ImageList = MenuIconResourceManagement.imgAction;
            _mImageMaxFig = lblMessage.ImageList.Images.Count;
        }

        /// <summary>
        /// ��ʕ\�����䏈��
        /// </summary>
        /// <param name="CloseTime">����܂ł̎���</param>
        /// <param name="si">��ʐF���</param>
        /// <remarks>
        /// <br>Note       :��ʕ\������</br>
        /// <br>Programmer  : 96203 ����@�K��</br>
        /// <br>Date        : 2006.09.04</br>
        /// </remarks>
        public void ShowProgressMessage(int CloseTime, ScreenInfomation si)
        {
            BackColor = si.ScreenBackColor;
            _mCloseTime = CloseTime * 1000;
            _mStackTime = 0;
            if (this.Visible == false)
            {
                this.Show();
                intTimer.Enabled = true;
            }
        }

        /// <summary>
        /// �^�C�}�[�����C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void intTimer_Tick(object sender, EventArgs e)
        {

            lblMessage.ImageIndex = _mImageIndex++;
            if (_mImageIndex >= _mImageMaxFig)
            {
                _mImageIndex = 0;
            }
            System.Windows.Forms.Application.DoEvents();
            _mStackTime = _mStackTime + intTimer.Interval;
            if (_mStackTime >= _mCloseTime)
            {
                intTimer.Enabled = false;
                _mStackTime = 0;
                this.Hide();
            }
        }

        /// <summary>
        /// ��ʕ`��C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SFNETMENU2B_Paint(object sender, PaintEventArgs e)
        {

            Rectangle rc = new Rectangle(5, 5, this.ClientSize.Width - 10, this.ClientSize.Height - 10);
            //Pen penBrsh = new Pen(Color.Red, 2);                              //  2007.01.10  �ύX
            //penBrsh.DashStyle = DashStyle.DashDotDot;                         //      V
            Pen penBrsh = new Pen(Color.Red, 2);                                //      V
            penBrsh.DashStyle = DashStyle.Dash;                                 //  2007.01.10  �ύX
            e.Graphics.DrawRectangle(penBrsh, rc);

            penBrsh.Dispose();
            e.Dispose();
        }
    }
}
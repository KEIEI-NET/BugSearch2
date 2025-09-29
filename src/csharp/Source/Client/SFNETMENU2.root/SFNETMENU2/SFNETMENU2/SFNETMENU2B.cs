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
    /// 起動中表示画面クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 起動中表示画面クラス</br>
    /// <br>Programmer : 96203 鹿野　幸生</br>
    /// <br>Date       : 2006.09.04</br>
    /// <br></br>
    /// <br>Update Note: 200x.xx.xx ＸＸ  ＸＸ</br>
    /// </remarks>
    public partial class SFNETMENU2B : Form
    {
        private int _mImageIndex = 0;
        private int _mCloseTime = 0;
        private int _mStackTime = 0;
        private int _mImageMaxFig = 0;

        /// <summary>
        /// 起動中表示画面コンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 起動中表示画面コンストラクタ</br>
        /// <br>Programmer : 96203 鹿野　幸生</br>
        /// <br>Date       : 2006.09.04</br>
        /// </remarks>
        public SFNETMENU2B()
        {
            InitializeComponent();

            lblMessage.ImageList = MenuIconResourceManagement.imgAction;
            _mImageMaxFig = lblMessage.ImageList.Images.Count;
        }

        /// <summary>
        /// 画面表示制御処理
        /// </summary>
        /// <param name="CloseTime">閉じるまでの時間</param>
        /// <param name="si">画面色情報</param>
        /// <remarks>
        /// <br>Note       :画面表示制御</br>
        /// <br>Programmer  : 96203 鹿野　幸生</br>
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
        /// タイマー発生イベント
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
        /// 画面描画イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SFNETMENU2B_Paint(object sender, PaintEventArgs e)
        {

            Rectangle rc = new Rectangle(5, 5, this.ClientSize.Width - 10, this.ClientSize.Height - 10);
            //Pen penBrsh = new Pen(Color.Red, 2);                              //  2007.01.10  変更
            //penBrsh.DashStyle = DashStyle.DashDotDot;                         //      V
            Pen penBrsh = new Pen(Color.Red, 2);                                //      V
            penBrsh.DashStyle = DashStyle.Dash;                                 //  2007.01.10  変更
            e.Graphics.DrawRectangle(penBrsh, rc);

            penBrsh.Dispose();
            e.Dispose();
        }
    }
}
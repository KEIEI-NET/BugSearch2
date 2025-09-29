//**********************************************************************//
// System           :   ＳＦ．ＮＥＴ                                    //
// Sub System       :                                                   //
// Program name     :   アセンブリ配置属性            　　　　　　　　　//
//                  :   SFCMN00036C.DLL        　　　　　　　　　　　　 //
// Name Space       :   Broadleaf.Windows.Forms.                        //
// Programmer       :   鹿野　幸生                                    //
// Date             :   2006.07.15                                      //
//----------------------------------------------------------------------//
// Update Note      :             　　　　　　　　　　　　　　　　　　　//
//----------------------------------------------------------------------//
//                 Copyright(c)2006 Broadleaf Co.,Ltd.                  //
//**********************************************************************//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;


namespace Broadleaf.Library.Net.Mail
{

    /// <summary>
    /// 状況表示ウインドウクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 状況表示ウインドウクラス</br>
    /// <br>Programmer : 96203 鹿野　幸生</br>
    /// <br>Date       : 2006.07.19</br>
    /// <br></br>
    /// <br>Update Note: 200x.xx.xx ＸＸ  ＸＸ</br>
    /// </remarks>
    public partial class ProgressWindow : Form
    {
        //  デリゲート
        delegate void AddStatusDelegate(string Status, bool NoProgressMode);
        delegate void SetTitleDelegate(string Title);
        delegate void SetProgressDelegate(int NowPos, int MaxPos);
        delegate void SetLabelProgressDelegate(int NowPos, int MaxPos);
        delegate void SetButtonVisibleDelegate(bool visible);
        delegate void HideWindowDelegate();

        //  内部処理用のイベント群
        private AddStatusDelegate AddStatusProc;
        private SetTitleDelegate SetTitleProc;
        private SetProgressDelegate SetProgressProc;
        private SetLabelProgressDelegate SetLabelProgressProc;
        private SetButtonVisibleDelegate SetButtonVisibleProc;
        private HideWindowDelegate HideWindowProc;

        /// <summary>
        /// ProgressWindowクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : ProgressWindowクラスコンストラクタ</br>
        /// <br>Programmer : 96203 鹿野　幸生</br>
        /// <br>Date       : 2006.07.19</br>
        /// </remarks>
        public ProgressWindow()
        {
            InitializeComponent();
            AddStatusProc = new AddStatusDelegate(AddStatusProc2);
            SetTitleProc = new SetTitleDelegate(SetTitleProc2);
            SetProgressProc = new SetProgressDelegate(SetProgressProc2);
            SetLabelProgressProc = new SetLabelProgressDelegate(SetLabelProgressProc2);
            SetButtonVisibleProc = new SetButtonVisibleDelegate(SetButtonVisibleProc2);
            HideWindowProc = new HideWindowDelegate(HideWindowProc2);
        }


        /// <summary>
        /// 進捗状況設定処理
        /// </summary>
        /// <param name="Status">進捗状況文字列</param>
        /// <param name="NoProgressMode">自動スクロール停止設定(True:スクロール停止,false:スクロール)</param>
        /// <returns>無し</returns>
        /// <remarks>
        /// <br>Note       :</br>
        /// <br>Programmer  : 96203 鹿野　幸生</br>
        /// <br>Date        : 2006.07.19</br>
        /// </remarks>
        [MTAThread]
        public void AddStatus(string Status, bool NoProgressMode)
        {
            try
            {
                Invoke(AddStatusProc, new object[] { Status, NoProgressMode });
            }
            catch
            {
            }
        }

        /// <summary>
        /// 進捗状況プログレスバー設定処理
        /// </summary>
        /// <param name="NowPos">現在ポジション</param>
        /// <param name="MaxPos">最大長</param>
        /// <returns>無し</returns>
        /// <remarks>
        /// <br>Note       :</br>
        /// <br>Programmer  : 96203 鹿野　幸生</br>
        /// <br>Date        : 2006.07.19</br>
        /// </remarks>
        [MTAThread]
        public void SetProgress(int NowPos, int MaxPos)
        {
            try
            {
                Invoke(SetProgressProc, new object[] { NowPos, MaxPos });
            }
            catch
            {
            }
        }

        /// <summary>
        /// ウインドウタイトル設定処理
        /// </summary>
        /// <param name="Title">ウインドウタイトル</param>
        /// <returns>無し</returns>
        /// <remarks>
        /// <br>Note       :</br>
        /// <br>Programmer  : 96203 鹿野　幸生</br>
        /// <br>Date        : 2006.07.19</br>
        /// </remarks>
        [MTAThread]
        public void SetTitle(string Title)
        {
            try
            {
                Invoke(SetTitleProc, new object[] { Title });
            }
            catch
            {
            }
        }

        /// <summary>
        /// 進捗状況ラベル設定処理
        /// </summary>
        /// <param name="NowPos">現在位置</param>
        /// <param name="MaxPos">最大位置</param>
        /// <returns>無し</returns>
        /// <remarks>
        /// <br>Note       :</br>
        /// <br>Programmer  : 96203 鹿野　幸生</br>
        /// <br>Date        : 2006.07.19</br>
        /// </remarks>
        [MTAThread]
        public void SetLabelProgress(int NowPos, int MaxPos)
        {
            try
            {
                Invoke(SetLabelProgressProc, new object[] { NowPos, MaxPos });
            }
            catch
            {
            }
        }

        /// <summary>
        /// 閉じるボタン表示制御処理
        /// </summary>
        /// <param name="visible">表示制御(True:表示,false:非表示)</param>
        /// <returns>無し</returns>
        /// <remarks>
        /// <br>Note       :</br>
        /// <br>Programmer  : 96203 鹿野　幸生</br>
        /// <br>Date        : 2006.07.19</br>
        /// </remarks>
        [MTAThread]
        public void SetButtonVisible(bool visible)
        {
            try
            {
                Invoke(SetButtonVisibleProc, new object[] { visible });
            }
            catch
            {
                Application.DoEvents();
            }
        }

        /// <summary>
        /// ウインドウ非表示制御処理
        /// </summary>
        /// <returns>無し</returns>
        /// <remarks>
        /// <br>Note       :</br>
        /// <br>Programmer  : 96203 鹿野　幸生</br>
        /// <br>Date        : 2006.07.19</br>
        /// </remarks>
        [MTAThread]
        public void HideWindow()
        {
            try
            {
                Invoke(HideWindowProc, new object[] {  });
            }
            catch
            {
            }
        }

        /// <summary>
        /// 進捗状況設定処理(内部処理用)
        /// </summary>
        /// <param name="Status">進捗状況文字列</param>
        /// <param name="NoProgressMode">自動スクロール停止設定(True:スクロール停止,false:スクロール)</param>
        /// <returns>無し</returns>
        /// <remarks>
        /// <br>Note       :</br>
        /// <br>Programmer  : 96203 鹿野　幸生</br>
        /// <br>Date        : 2006.07.19</br>
        /// </remarks>
        [MTAThread]
        private void AddStatusProc2(string Status, bool NoProgressMode)
        {
            try
            {
                lstStatus.Items.Add(Status);
                if (NoProgressMode != true)
                {
                    lstStatus.SelectedIndex = lstStatus.Items.Count - 1;
                }
            }
            finally
            {
                Application.DoEvents();
            }
        }

        /// <summary>
        /// 進捗状況プログレスバー設定処理(内部処理用)
        /// </summary>
        /// <param name="NowPos">現在ポジション</param>
        /// <param name="MaxPos">最大長</param>
        /// <returns>無し</returns>
        /// <remarks>
        /// <br>Note       :</br>
        /// <br>Programmer  : 96203 鹿野　幸生</br>
        /// <br>Date        : 2006.07.19</br>
        /// </remarks>
        [MTAThread]
        public void SetProgressProc2(int NowPos, int MaxPos)
        {
            try
            {
                barProgress.Maximum = MaxPos;
                barProgress.Minimum = 0;
                barProgress.Value = NowPos;
            }
            finally
            {
                Application.DoEvents();
            }
        }

        /// <summary>
        /// 進捗状況ラベル設定処理(内部処理用)
        /// </summary>
        /// <param name="NowPos">現在位置</param>
        /// <param name="MaxPos">最大位置</param>
        /// <returns>無し</returns>
        /// <remarks>
        /// <br>Note       :</br>
        /// <br>Programmer  : 96203 鹿野　幸生</br>
        /// <br>Date        : 2006.07.19</br>
        /// </remarks>
        [MTAThread]
        public void SetLabelProgressProc2(int NowPos, int MaxPos)
        {
            try
            {
                lblProgress.Text = "(" + NowPos.ToString() + "/" + MaxPos.ToString() + ")";
            }
            finally
            {
                Application.DoEvents();
            }
        }

        /// <summary>
        /// ウインドウタイトル設定処理(内部処理用)
        /// </summary>
        /// <param name="Title">ウインドウタイトル</param>
        /// <returns>無し</returns>
        /// <remarks>
        /// <br>Note       :</br>
        /// <br>Programmer  : 96203 鹿野　幸生</br>
        /// <br>Date        : 2006.07.19</br>
        /// </remarks>
        [MTAThread]
        public void SetTitleProc2(string Title)
        {
            try
            {
                this.Text = "進捗状況：" + Title;
            }
            finally
            {
                Application.DoEvents();
            }
        }

        /// <summary>
        /// 閉じるボタン表示制御処理(内部処理用)
        /// </summary>
        /// <param name="visible">表示制御(True:表示,false:非表示)</param>
        /// <returns>無し</returns>
        /// <remarks>
        /// <br>Note       :</br>
        /// <br>Programmer  : 96203 鹿野　幸生</br>
        /// <br>Date        : 2006.07.19</br>
        /// </remarks>
        private void SetButtonVisibleProc2(bool visible)
        {
            btnFunc.Visible = visible;
        }

        /// <summary>
        /// ウインドウ非表示制御処理(内部処理用)
        /// </summary>
        /// <returns>無し</returns>
        /// <remarks>
        /// <br>Note       :</br>
        /// <br>Programmer  : 96203 鹿野　幸生</br>
        /// <br>Date        : 2006.07.19</br>
        /// </remarks>
        private void HideWindowProc2()
        {
            Hide();
            Application.DoEvents();
        }

        /// <summary>
        /// 閉じるボタン押下時イベント
        /// </summary>
        /// <param name="sender">イベント発生コントロール</param>
        /// <param name="e">イベントデータ</param>
        /// <remarks>
        /// <br>Note　　　  : 閉じるボタン押下時に発生します</br>
        /// <br>Programmer  : 96203 鹿野　幸生</br>
        /// <br>Date        : 2006.07.19</br>
        /// </remarks>
        private void btnFunc_Click(object sender, EventArgs e)
        {
            Hide();
        }

        /// <summary>
        /// ウインドウサイズ変更イベント
        /// </summary>
        /// <param name="sender">イベント発生コントロール</param>
        /// <param name="e">イベントデータ</param>
        /// <remarks>
        /// <br>Note　　　  : ウインドウサイズを変更した時に発生します</br>
        /// <br>Programmer  : 96203 鹿野　幸生</br>
        /// <br>Date        : 2006.07.19</br>
        /// </remarks>
        private void ProgressWindow_Resize(object sender, EventArgs e)
        {
            //  サイズ変更に合わせてコントロールの位置サイズを調整します
            barProgress.Width = (int)(pnlBar.ClientSize.Width * .9);
            barProgress.Left = (ClientSize.Width - barProgress.Width) / 2;
            lblProgress.Left = (ClientSize.Width - lblProgress.Width) / 2;
        }

        /// <summary>
        /// ウインドウ表示時イベント
        /// </summary>
        /// <param name="sender">イベント発生コントロール</param>
        /// <param name="e">イベントデータ</param>
        /// <remarks>
        /// <br>Note　　　  : ウインドウを表示した時に発生します</br>
        /// <br>Programmer  : 96203 鹿野　幸生</br>
        /// <br>Date        : 2006.07.19</br>
        /// </remarks>
        private void ProgressWindow_Shown(object sender, EventArgs e)
        {
            //  サイズ変更に合わせてコントロールの位置サイズを調整します
            barProgress.Width = (int)(pnlBar.ClientSize.Width * .9);
            barProgress.Left = (ClientSize.Width - barProgress.Width) / 2;
            lblProgress.Left = (ClientSize.Width - lblProgress.Width) / 2;

        }


    }
}
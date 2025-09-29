using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

using Broadleaf.NSNetworkChk.UI;

namespace Broadleaf.NSNetworkChk.UI
{
    /// <summary>
    /// AWS通信テストメインEXE
    /// </summary>
    /// <remarks>
    /// <br>Note       : AWS通信テストのメインとなるEXEです。</br>
    /// <br>Programmer : 朱宝軍</br>
    /// <br>Date       : 2019.01.02</br>
    /// </remarks>
    public partial class NSNetworkChkA : ApplicationContext
    {
        //=========================================================================================
        // コンストラクタ
        //=========================================================================================
        #region Constructors
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : コンストラクタ。</br>
        /// <br>Programmer : 朱宝軍</br>
        /// <br>Date       : 2019.01.02</br>
        /// </remarks>
        public NSNetworkChkA()
        {
            nSNetworkTest_Form = new NSNetworkChk_Form();
            nSNetworkTest_Form.Opacity = 0;
            nSNetworkTest_Form.TopMost = false;
            nSNetworkTest_Form.FormClosing += new FormClosingEventHandler(OnFormClosed);
            System.Windows.Forms.Application.DoEvents();
            nSNetworkTest_Form.AutoNSNetworkTest(1);
            nSNetworkTest_Form.Opacity = 0;
            nSNetworkTest_Form.ShowInTaskbar = false;
            nSNetworkTest_Form.ShowIcon = false;
        }

        #endregion

        //=========================================================================================
        // 内部メンバ
        //=========================================================================================
        #region Private Members
        /// <summary>AWS通信テストメインフレーム</summary>
        private NSNetworkChk_Form nSNetworkTest_Form = null;
        #endregion

        /// <summary>
        /// 起動フォームのクローズイベントハンドラです。
        /// </summary>
        private void OnFormClosed(object sender, EventArgs e)
        {
            // スレッドのメッセージループ終了の呼出
            ExitThread();
        }

        /// <summary>
        /// スレッドの終了です。
        /// </summary>
        protected override void ExitThreadCore()
        {
            // Applicationオブジェクトにてスレッド終了
            base.ExitThreadCore();
        }
    }
}
//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 発注処理(自動)エラーメッセージ
// プログラム概要   : 発注処理(自動)エラーメッセージ処理を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  10902931-00 作成担当 : 譚洪
// 作 成 日  2013/08/15  修正内容 : 新規作成
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 発注処理(自動)エラーメッセージ
    /// </summary>
    /// <remarks>
    /// <br>Note       : 発注処理(自動)エラーメッセージ</br>
    /// <br>Programmer : 譚洪</br>
    /// <br>Date       : 2013/08/15</br>
    /// </remarks>
    public partial class PMCMN00900UA : Form
    {
        // ===================================================================================== //
        // プライベート変数
        // ===================================================================================== //
        #region Private Members
        private const string SELECTRESULT = "SELECTRESULT";
        private const string MSGSHOWSOLT = "MSGSHOWSOLT";

        //private UoeSndRcvCtlAndAutoAcs uoeSndRcvCtlAndAutoAcs;
        private LocalDataStoreSlot selectResult = null;
        private LocalDataStoreSlot msgShowSolt = null;

        #endregion

        // ===================================================================================== //
        // コンストラクタ
        // ===================================================================================== //
        # region Constructors
        public PMCMN00900UA()
        {
            InitializeComponent();
            msgShowSolt = Thread.GetNamedDataSlot(MSGSHOWSOLT);
            if (Thread.GetData(msgShowSolt) != null)
            {
                if ((int)Thread.GetData(msgShowSolt) == 3)
                {
                    this.Text = "エラー発生 ‐ ＜受信処理＞";
                }
                else
                {
                    this.Text = "エラー発生 ‐ ＜送信処理＞";
                }
            }
        }
        #endregion

        // ===================================================================================== //
        // パブイベートメソッド
        // ===================================================================================== //
        #region public Methods
        /// <summary>
        /// エラーメッセージ表示処理
        /// </summary>
        /// <param name="message">表示メッセージ</param>
        /// <remarks>
        /// <br>Note       : エラーメッセージの表示を行います。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date	   : 2013/08/15</br>
        /// </remarks>
        public void ErrorMsgShow(string msg)
        {
            this.ultraLabel1.Text = msg;
            this.ShowDialog();
            Close();
        }
        #endregion

        // ===================================================================================== //
        // 画面操作処理ラクタ
        // ===================================================================================== //
        #region Control Event Methods
        /// <summary>
        /// フォームロードイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void contimueBtn_Click(object sender, EventArgs e)
        {
            Thread.FreeNamedDataSlot(SELECTRESULT);
            selectResult = Thread.AllocateNamedDataSlot(SELECTRESULT);
            Thread.SetData(selectResult, 1);
            Close();
        }

        /// <summary>
        /// フォームロードイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void closeBtn_Click(object sender, EventArgs e)
        {
            Thread.FreeNamedDataSlot(SELECTRESULT);
            selectResult = Thread.AllocateNamedDataSlot(SELECTRESULT);
            Thread.SetData(selectResult, 2);
            Close();
        }
        #endregion
    }
}
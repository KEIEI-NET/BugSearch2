//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 売上データテキスト出力（ＴＭＹ）
// プログラム概要   : 売上データテキスト出力（ＴＭＹ）　フレームクラス
//----------------------------------------------------------------------------//
//                (c)Copyright  2012 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  10805731-00 作成担当 : 鄧潘ハン
// 作 成 日  2011/10/31  修正内容 : 新規作成
//----------------------------------------------------------------------------//

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
    /// 売上データテキスト出力（ＴＭＹ） UIクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 売上データテキスト出力（ＴＭＹ） UIクラス</br>										
    /// <br>Programmer : 鄧潘ハン</br>										
    /// <br>Date       : 2012/10/31</br>										
    /// <br>管理番号   : 10805731-00</br>
    /// </remarks>
    public partial class PMKHN07700UA : Form
    {
        #region Public Members
        /// <summary>
        /// 売上データテキスト出力（ＴＭＹ）メインフレームクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 売上データテキスト出力（ＴＭＹ）メインフレームクラスコンストラクタ</br>										
        /// <br>Programmer : 鄧潘ハン</br>										
        /// <br>Date       : 2012/10/31</br>										
        /// <br>管理番号   : 10805731-00</br>
        /// </remarks>
        public PMKHN07700UA()
        {
            InitializeComponent();
        }

        #endregion

        #region Private Members
        private PMKHN07701UA _pmkhn07701UA;
        /// <summary>
        /// Load イベント
        /// </summary>
        /// <remarks>
        /// <br>Note       : 売上データテキスト出力（ＴＭＹ）Load イベント</br>										
        /// <br>Programmer : 鄧潘ハン</br>										
        /// <br>Date       : 2012/10/31</br>										
        /// <br>管理番号   : 10805731-00</br>
        /// </remarks>
        private void PMKHN07700UA_Load(object sender, EventArgs e)
        {
            this._pmkhn07701UA = new PMKHN07701UA();

            this._pmkhn07701UA.TopLevel = false;
            this._pmkhn07701UA.FormBorderStyle = FormBorderStyle.None;
            this._pmkhn07701UA.Show();
            this._pmkhn07701UA.Dock = DockStyle.Fill;

            this.Text = this._pmkhn07701UA.Text;

            this.Controls.Add(this._pmkhn07701UA);
            this._pmkhn07701UA.FormClosed += new FormClosedEventHandler(this.PMKHN07700UA_FormClosed);

        }

        /// <summary>
        /// 画面終了処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 売上データテキスト出力（ＴＭＹ）画面終了処理</br>										
        /// <br>Programmer : 鄧潘ハン</br>										
        /// <br>Date       : 2012/10/31</br>										
        /// <br>管理番号   : 10805731-00</br>
        /// </remarks>
        private void PMKHN07700UA_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 画面終了処理
        /// </summary>
        /// <param name="m">m</param>
        /// <remarks>
        /// <br>Note       : 売上データテキスト出力（ＴＭＹ）画面終了処理</br>										
        /// <br>Programmer : 鄧潘ハン</br>										
        /// <br>Date       : 2012/10/31</br>										
        /// <br>管理番号   : 10805731-00</br>
        /// </remarks>
        protected override void WndProc(ref Message m)
        {
            const int WM_SYSCOMMAND = 0x0112;
            const int SC_CLOSE = 0xF060;

            if (m.Msg == WM_SYSCOMMAND && m.WParam.ToInt32() == SC_CLOSE)
            {
                // FormClose前の処理
                this._pmkhn07701UA.Close();
            }
            base.WndProc(ref m);
        }

        /// <summary>
        /// 画面表示処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 売上データテキスト出力（ＴＭＹ）画面表示処理</br>										
        /// <br>Programmer : 鄧潘ハン</br>										
        /// <br>Date       : 2012/10/31</br>										
        /// <br>管理番号   : 10805731-00</br>
        /// </remarks>
        private void PMKHN07700UA_Shown(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.DoEvents();
            this.Opacity = 1;
        }

        #endregion 
    }
}
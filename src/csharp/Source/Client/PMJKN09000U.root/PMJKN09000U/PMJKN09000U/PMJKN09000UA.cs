//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 自由検索型式マスタフォームクラス
// プログラム概要   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  10602352-00 作成担当 : 肖緒徳
// 作 成 日  2010/04/26  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日              修正内容 : 
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
    /// 自由検索型式マスタフォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 自由検索型式マスタのフォームクラスです。</br>
    /// <br>Programmer : 肖緒徳</br>
    /// <br>Date       : 2010.04.26</br>
    /// <br></br>
    public partial class PMJKN09000UA : Form
    {
        # region コンストラクタ
        /// <summary>
        /// 自由検索型式マスタフォームクラス デフォルトコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 自由検索型式マスタ処理のコンストラクタです。</br>      
        /// <br>Programmer : 肖緒徳</br>
        /// <br>Date       : 2010/04/26</br>
        /// </remarks>
        public PMJKN09000UA()
        {
            InitializeComponent();
        }

        # endregion

        # region private Member
        /// <summary>自由検索型式マスタフォームクラス</summary>             
        /// <remarks>なし</remarks>　
        PMJKN09001UA _mPMJKN09001UAForm;
        # endregion

        # region イベント
        /// <summary>
        /// ロードイベント                                            
        /// </summary>
        /// <param name="sender">イベントソース</param>                            
        /// <param name="e">イベントデータ</param>
        /// <remarks>
        /// <br>Note       : 画面がロード時に発生します。</br>      
        /// <br>Programmer : 肖緒徳</br>
        /// <br>Date       : 2010/04/26</br>
        /// </remarks>
        private void PMJKN09000UA_Load(object sender, EventArgs e)
        {

            this._mPMJKN09001UAForm = new PMJKN09001UA();

            this._mPMJKN09001UAForm.TopLevel = false;
            this._mPMJKN09001UAForm.FormBorderStyle = FormBorderStyle.None;
            this._mPMJKN09001UAForm.Show();
            this._mPMJKN09001UAForm.Dock = DockStyle.Fill;
            this.Text = this._mPMJKN09001UAForm.Text;
            this.Controls.Add(this._mPMJKN09001UAForm);

            this._mPMJKN09001UAForm.FormClosed += new FormClosedEventHandler(this.PMJKN09000UA_FormClosed);
        }

        /// <summary>
        /// 閉じるイベント                                        
        /// </summary>
        /// <param name="sender">イベントソース</param>                           
        /// <param name="e">イベントデータ</param>
        /// <remarks>
        /// <br>Note       : 画面が閉じる時に発生します。</br>      
        /// <br>Programmer : 肖緒徳</br>
        /// <br>Date       : 2010/04/26</br>
        /// </remarks>
        private void PMJKN09000UA_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }
        # endregion

    }
}
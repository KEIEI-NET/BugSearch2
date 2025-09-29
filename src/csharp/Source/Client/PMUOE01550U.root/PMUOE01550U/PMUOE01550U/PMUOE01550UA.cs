//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 注文一覧更新処理
// プログラム概要   : ホンダe-Partsシステムより「ご注文一覧CSV」を取り込み、
//                    回答情報を更新します。
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 李占川
// 作 成 日  2009/05/31  修正内容 : 新規作成
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
    /// 注文一覧更新処理フレームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 注文一覧更新処理のフレームクラスです。</br>
    /// <br>Programmer : 李占川</br>
    /// <br>Date       : 2009.05.31</br>
    /// <br></br>
    /// <br>UpDate</br>
    /// <br>2009.05.31 lizc 新規作成</br>
    /// </remarks>
    public partial class PMUOE01550UA : Form
    {
        # region コンストラクタ
        /// <summary>
        /// 注文一覧更新処理フォームクラス デフォルトコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 注文一覧更新処理のコンストラクタです。</br>      
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009.05.31</br>
        /// </remarks>
        public PMUOE01550UA()
        {
            InitializeComponent();
        }

        # endregion

        # region private Member
        /// <summary>注文一覧更新処理入力フォームクラス</summary>             
        /// <remarks>なし</remarks>　
        PMUOE01551UA _mPMUOE01551UAForm;
        # endregion

        # region イベント
        /// <summary>
        /// ロードイベント                                            
        /// </summary>
        /// <param name="sender">イベントソース</param>                            
        /// <param name="e">イベントデータ</param>
        /// <remarks>
        /// <br>Note       : 画面がロード時に発生します。</br>      
        /// <br>Programmer : 李占川</br>                                  
        /// <br>Date       : 2009.05.31</br> 
        /// </remarks>
        private void PMUOE01550UA_Load(object sender, EventArgs e)
        {

            this._mPMUOE01551UAForm = new PMUOE01551UA();

            this._mPMUOE01551UAForm.TopLevel = false;
            this._mPMUOE01551UAForm.FormBorderStyle = FormBorderStyle.None;
            this._mPMUOE01551UAForm.Show();
            this._mPMUOE01551UAForm.Dock = DockStyle.Fill;
            this.Text = this._mPMUOE01551UAForm.Text;
            this.Controls.Add(this._mPMUOE01551UAForm);

            this._mPMUOE01551UAForm.FormClosed += new FormClosedEventHandler(this.PMUOE01550UA_FormClosed);
        }

        /// <summary>
        /// 閉じるイベント                                        
        /// </summary>
        /// <param name="sender">イベントソース</param>                           
        /// <param name="e">イベントデータ</param>
        /// <remarks>
        /// <br>Note       : 画面が閉じる時に発生します。</br>      
        /// <br>Programmer : 李占川</br>                                  
        /// <br>Date       : 2009.05.31</br> 
        /// </remarks>
        private void PMUOE01550UA_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }
        # endregion
    }
}
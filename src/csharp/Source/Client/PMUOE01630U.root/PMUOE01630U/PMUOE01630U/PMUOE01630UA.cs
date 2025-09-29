//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 三菱回答データ取込処理
// プログラム概要   : UOE発注データと発注回答データのつけ合わせを行い、
//                    売上・仕入データの作成を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  10601191-00 作成担当 : 肖緒徳
// 作 成 日  2010/04/21  修正内容 : 新規作成
//                                 【要件No.6】UOE発注データと発注回答データのつけ合わせを行い、売上・仕入データの作成を行う
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
    /// 三菱回答データ取込処理フレームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 三菱回答データ取込処理のフレームクラスです。</br>
    /// <br>Programmer : 肖緒徳</br>
    /// <br>Date       : 2010/04/21</br>
    /// <br></br>
    /// </remarks>
    public partial class PMUOE01630UA : Form
    {
        # region コンストラクタ
        /// <summary>
        /// 三菱回答データ取込処理フォームクラス デフォルトコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 三菱回答データ取込処理のコンストラクタです。</br>      
        /// <br>Programmer : 肖緒徳</br>
        /// <br>Date       : 2010/04/21</br>
        /// </remarks>
        public PMUOE01630UA()
        {
            InitializeComponent();
        }

        # endregion

        # region private Member
        /// <summary>三菱回答データ取込処理入力フォームクラス</summary>             
        /// <remarks>なし</remarks>　
        PMUOE01631UA _mPMUOE01631UAForm;
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
        /// <br>Date       : 2010/04/21</br> 
        /// </remarks>
        private void PMUOE01630UA_Load(object sender, EventArgs e)
        {

            this._mPMUOE01631UAForm = new PMUOE01631UA();

            this._mPMUOE01631UAForm.TopLevel = false;
            this._mPMUOE01631UAForm.FormBorderStyle = FormBorderStyle.None;
            this._mPMUOE01631UAForm.Show();
            this._mPMUOE01631UAForm.Dock = DockStyle.Fill;
            this.Text = this._mPMUOE01631UAForm.Text;
            this.Controls.Add(this._mPMUOE01631UAForm);

            this._mPMUOE01631UAForm.FormClosed += new FormClosedEventHandler(this.PMUOE01630UA_FormClosed);
        }

        /// <summary>
        /// 閉じるイベント                                        
        /// </summary>
        /// <param name="sender">イベントソース</param>                           
        /// <param name="e">イベントデータ</param>
        /// <remarks>
        /// <br>Note       : 画面が閉じる時に発生します。</br>      
        /// <br>Programmer : 肖緒徳</br>                                  
        /// <br>Date       : 2010/04/21</br> 
        /// </remarks>
        private void PMUOE01630UA_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }
        # endregion
    }
}
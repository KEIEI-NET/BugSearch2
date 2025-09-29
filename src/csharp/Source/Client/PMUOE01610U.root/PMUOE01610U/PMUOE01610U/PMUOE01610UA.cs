//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : トヨタ回答データ取込処理
// プログラム概要   : UOE発注データと発注回答データのつけ合わせを行い、
//                    売上・仕入データの作成を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  10507391-00 作成担当 : 李占川
// 作 成 日  2010/01/04  修正内容 : 新規作成
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
    /// トヨタ回答データ取込処理フレームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : トヨタ回答データ取込処理のフレームクラスです。</br>
    /// <br>Programmer : 李占川</br>
    /// <br>Date       : 2010/01/04</br>
    /// <br></br>
    /// </remarks>
    public partial class PMUOE01610UA : Form
    {
        # region コンストラクタ
        /// <summary>
        /// トヨタ回答データ取込処理フォームクラス デフォルトコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : トヨタ回答データ取込処理のコンストラクタです。</br>      
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2010/01/04</br>
        /// </remarks>
        public PMUOE01610UA()
        {
            InitializeComponent();
        }

        # endregion

        # region private Member
        /// <summary>トヨタ回答データ取込処理入力フォームクラス</summary>             
        /// <remarks>なし</remarks>　
        PMUOE01611UA _mPMUOE01611UAForm;
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
        /// <br>Date       : 2010/01/04</br> 
        /// </remarks>
        private void PMUOE01610UA_Load(object sender, EventArgs e)
        {

            this._mPMUOE01611UAForm = new PMUOE01611UA();

            this._mPMUOE01611UAForm.TopLevel = false;
            this._mPMUOE01611UAForm.FormBorderStyle = FormBorderStyle.None;
            this._mPMUOE01611UAForm.Show();
            this._mPMUOE01611UAForm.Dock = DockStyle.Fill;
            this.Text = this._mPMUOE01611UAForm.Text;
            this.Controls.Add(this._mPMUOE01611UAForm);

            this._mPMUOE01611UAForm.FormClosed += new FormClosedEventHandler(this.PMUOE01610UA_FormClosed);
        }

        /// <summary>
        /// 閉じるイベント                                        
        /// </summary>
        /// <param name="sender">イベントソース</param>                           
        /// <param name="e">イベントデータ</param>
        /// <remarks>
        /// <br>Note       : 画面が閉じる時に発生します。</br>      
        /// <br>Programmer : 李占川</br>                                  
        /// <br>Date       : 2010/01/04</br> 
        /// </remarks>
        private void PMUOE01610UA_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }
        # endregion
    }
}
//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : マツダ回答データ取込処理
// プログラム概要   : UOE発注データと発注回答データのつけ合わせを行い、
//                    売上・仕入データの作成を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  10702591-00 作成担当 : 曹文傑
// 作 成 日  2011/05/18  修正内容 : 新規作成
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
    /// マツダ回答データ取込処理フレームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : マツダ回答データ取込処理のフレームクラスです。</br>
    /// <br>Programmer : 曹文傑</br>
    /// <br>Date       : 2011/05/18</br>
    /// <br></br>
    /// </remarks>
    public partial class PMUOE01640UA : Form
    {
        # region コンストラクタ
        /// <summary>
        /// マツダ回答データ取込処理フォームクラス デフォルトコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : マツダ回答データ取込処理のコンストラクタです。</br>      
        /// <br>Programmer : 曹文傑</br>
        /// <br>Date       : 2011/05/18</br>
        /// </remarks>
        public PMUOE01640UA()
        {
            InitializeComponent();
        }

        # endregion

        # region private Member
        /// <summary>マツダ回答データ取込処理入力フォームクラス</summary>             
        /// <remarks>なし</remarks>　
        PMUOE01641UA _mPMUOE01641UAForm;
        # endregion

        # region イベント
        /// <summary>
        /// ロードイベント                                            
        /// </summary>
        /// <param name="sender">イベントソース</param>                            
        /// <param name="e">イベントデータ</param>
        /// <remarks>
        /// <br>Note       : 画面がロード時に発生します。</br>      
        /// <br>Programmer : 曹文傑</br>                                  
        /// <br>Date       : 2011/05/18</br> 
        /// </remarks>
        private void PMUOE01640UA_Load(object sender, EventArgs e)
        {

            this._mPMUOE01641UAForm = new PMUOE01641UA();

            this._mPMUOE01641UAForm.TopLevel = false;
            this._mPMUOE01641UAForm.FormBorderStyle = FormBorderStyle.None;
            this._mPMUOE01641UAForm.Show();
            this._mPMUOE01641UAForm.Dock = DockStyle.Fill;
            this.Text = this._mPMUOE01641UAForm.Text;
            this.Controls.Add(this._mPMUOE01641UAForm);

            this._mPMUOE01641UAForm.FormClosed += new FormClosedEventHandler(this.PMUOE01640UA_FormClosed);
        }

        /// <summary>
        /// 閉じるイベント                                        
        /// </summary>
        /// <param name="sender">イベントソース</param>                           
        /// <param name="e">イベントデータ</param>
        /// <remarks>
        /// <br>Note       : 画面が閉じる時に発生します。</br>      
        /// <br>Programmer : 曹文傑</br>                                  
        /// <br>Date       : 2011/05/18</br> 
        /// </remarks>
        private void PMUOE01640UA_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }
        # endregion
    }
}
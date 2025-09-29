//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 車輌管理マスタ
// プログラム概要   : 車輌管理マスタの登録・変更・削除を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 李占川
// 作 成 日  2009/09/07  修正内容 : 新規作成
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
    /// 車輌管理マスタ  フレームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note        : 車輌管理マスタ関連の一覧表示を行うフォームクラスです。</br>
    /// <br>Programmer  : 李占川</br>
    /// <br>Date        : 2009.09.07</br>
    /// <br>Update Note : </br>
    /// </remarks>
    public partial class PMSYA09020UA : Form
    {
        # region コンストラクタ
        /// <summary>
        /// 車輌管理マスタUIクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note        : 車輌管理マスタ  フレームクラスのインスタンスを生成します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009.09.07</br>
        /// </remarks>
        public PMSYA09020UA()
        {
            InitializeComponent();
        }
        # endregion

        # region private Member
        /// <summary>車輌管理マスタ 入力フォームクラス</summary>             
        /// <remarks>なし</remarks>　
        private PMSYA09021UA _pMSYA09021UA;
        # endregion

        # region イベント
        /// <summary>
        /// ロードイベント                                            
        /// </summary>
        /// <param name="sender">イベントソース</param>                            
        /// <param name="e">イベントデータ</param>
        /// <remarks>
        /// <br>Note        : 画面がロード時に発生します。</br>      
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009.09.07</br>
        /// </remarks>
        private void PMSYA09020UA_Load(object sender, EventArgs e)
        {
            this._pMSYA09021UA = new PMSYA09021UA();
            this._pMSYA09021UA.TopLevel = false;
            this._pMSYA09021UA.FormBorderStyle = FormBorderStyle.None;
            this._pMSYA09021UA.Show();
            this.Controls.Add(this._pMSYA09021UA);
            this._pMSYA09021UA.Dock = DockStyle.Fill;

            this._pMSYA09021UA.FormClosed += new FormClosedEventHandler(this.PMZAI09201UA_FormClosed);
        }

        /// <summary>
        /// 閉じるイベント                                        
        /// </summary>
        /// <param name="sender">イベントソース</param>                           
        /// <param name="e">イベントデータ</param>
        /// <remarks>
        /// <br>Note        : 画面が閉じる時に発生します。</br>      
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009.09.07</br>
        /// </remarks>
        private void PMZAI09201UA_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }
        # endregion
    }
}
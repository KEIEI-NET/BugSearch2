//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : データ受信処理
// プログラム概要   : データセンターに対して追加・更新処理を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 孫東響
// 作 成 日  2011/07/28  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 譚洪
// 修 正 日  2011/11/29  修正内容 : Redmine #8136 拠点管理／受信処理の締チェック処理変更
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Library.Resources;
using System.Collections;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// エラー表示フォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : エラー表示のフォームクラスです。</br>
    /// <br>Programmer : 孫東響</br>
    /// <br>Date       : 2011.07.28</br>
    /// <br></br>
    /// <br>UpDate</br>
    /// <br>2011.07.28 新規作成</br>
    /// </remarks>
    public partial class PMKYO01101UD : Form
    {
        ArrayList _errList;
        public bool _continueFlg;  // ADD 2011/11/29

        /// <summary>
        /// エラー処理
        /// </summary>
        /// <param name="errList"></param>
        public PMKYO01101UD(ArrayList errList)
        {
            InitializeComponent();
            _errList = errList;
            _continueFlg = false;   // ADD 2011/11/29
            //ultraPictureBox_Warning.Image = ;
        }


        /// <summary>
        /// エラー明細表示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ultraButton_Detail_Click(object sender, EventArgs e)
        {
            try
            {
                PMKYO01900UA form = new PMKYO01900UA(_errList);
                form.Show();
            }
            catch { }
        }
        /// <summary>
        /// 終了
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ultraButton_Close_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch { }
        }

        // --- ADD 2011/11/29  ---- >>>>
        /// <summary>
        /// 続行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ultraButton_Continue_Click(object sender, EventArgs e)
        {
            this._continueFlg = true;

            try
            {
                this.Close();
            }
            catch { }
        }
        // --- ADD 2011/11/29  ---- <<<<
    }
}
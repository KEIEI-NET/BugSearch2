//****************************************************************************//
// システム         : PM.NS                                                   //
// プログラム名称   : 商品バーコード一括登録                                  //
// プログラム概要   : 商品バーコード一括登録 UIフレームクラス                 //
//----------------------------------------------------------------------------//
//                (c)Copyright  2017 Broadleaf Co.,Ltd.                       //
//============================================================================//
// 履歴                                                                       //
//----------------------------------------------------------------------------//
// 管理番号  11370006-00 作成担当 : 3H 張小磊                                 //
// 作 成 日  2017/06/12  修正内容 : 新規作成                                  //
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.Remoting;
using Broadleaf.Application.Common;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 商品バーコード一括登録 UIフレームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note        : 商品バーコード一括登録 UIフレームクラス</br>
    /// <br>Programmer  : 3H 張小磊</br>
    /// <br>Date        : 2017/06/12</br>
    /// </remarks>
	public partial class PMHND09200UA : Form
	{
        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : デフォルトコンストラクタ</br>
        /// <br>Programmer : 3H 張小磊</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
		public PMHND09200UA()
		{
			InitializeComponent();
		}

        // 商品バーコード一括登録 UIクラス
        private PMHND09210UA _goodsBarCodeRevnForm;

        /// <summary>
        /// 画面起動時処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : 画面起動時処理。</br>
        /// <br>Programmer : 3H 張小磊</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        private void PMHND09200UA_Load(object sender, EventArgs e)
		{
            this._goodsBarCodeRevnForm = new PMHND09210UA();
            this._goodsBarCodeRevnForm.TopLevel = false;
            this._goodsBarCodeRevnForm.FormBorderStyle = FormBorderStyle.None;
            this._goodsBarCodeRevnForm.Show();
            this.Controls.Add(this._goodsBarCodeRevnForm);
            this._goodsBarCodeRevnForm.Dock = DockStyle.Fill;
            // 画面終了処理
            this._goodsBarCodeRevnForm.FormClosed += new FormClosedEventHandler(this.GoodsBarCodeRevnForm_FormClosed);
		}

        /// <summary>
        /// 画面終了処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : 画面終了処理。</br>
        /// <br>Programmer : 3H 張小磊</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        private void GoodsBarCodeRevnForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			this.Close();
		}
	}
}
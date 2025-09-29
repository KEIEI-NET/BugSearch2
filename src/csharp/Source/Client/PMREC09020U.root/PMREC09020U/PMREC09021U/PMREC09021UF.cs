//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : お買得商品設定マスタ
// プログラム概要   : 拠点・得意先選択を行う
//----------------------------------------------------------------------------//
//                (c)Copyright 2015 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11070266-00 作成担当 : 脇田 靖之
// 作 成 日  2015/02/20  修正内容 : 新規作成
//----------------------------------------------------------------------------//
using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.UltraWinToolbars;
using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;

namespace Broadleaf.Library.Windows.Forms
{
    /// <summary>
    /// 選択ガイド
    /// </summary>
    /// <remarks>
    /// <br>本クラスはinternalで宣言されている為、外部アセンブリからは直接参照できない。</br>
    /// <br>外部アセンブリから本クラスにアクセスする場合は、操作クラスにインターフェース</br>
    /// <br>となるメソッドやプロパティを作成する事</br>
    /// </remarks>
    public partial class PMREC09021UD : Form
    {

        # region 変数定義

        # endregion

        #region [ コンストラクタ ]

        /// <summary>
        /// 選択画面コンストラクタ
        /// </summary>
        /// <param name="secCusSetDataTable">グリッド表示用 データテーブル</param>
        public PMREC09021UD()
        {
            InitializeComponent();
            InitializeForm();

        }

        #endregion

        #region [ 初期処理 ]
        private void InitializeForm()
        {
        }
        #endregion

        #region ColInfo　インターナル

        internal static class ColInfo
        {
        }
        #endregion

        #region [ フォームイベント処理 ]
        /// <summary>
        /// FormClosed イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>DialogResultがOKの場合にのみ、グリッド上で選択されている行に関連するDataRowオブジェクトを取得し、</br>
        /// <br>"選択状態"に相当する処理を行います。</br>
        /// </remarks>
        private void PMREC09021UD_FormClosed(object sender, FormClosedEventArgs e)
        {
        }

        /// <summary>
        /// ESCキー押下による終了処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PMREC09021UD_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                DialogResult = DialogResult.Cancel;
            }
        }

        private void tRetKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
        }

        private void PMREC09021UD_Shown(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.Manual;
        }
        /// <summary>
        /// ShowDialog
        /// </summary>
        /// <returns>DialogResult</returns>
        internal new DialogResult ShowDialog()
        {
            DialogResult ret = base.ShowDialog();

            return ret;
        }

        #endregion

        private void ToolbarsManager_ToolClick(object sender, ToolClickEventArgs e)
        {

        }

        private void uButton_OK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
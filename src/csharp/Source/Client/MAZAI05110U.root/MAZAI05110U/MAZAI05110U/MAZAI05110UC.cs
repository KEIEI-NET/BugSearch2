//****************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : 棚卸準備処理
// プログラム概要   : 棚卸準備処理実行時の注意事項を表示する。
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田 貴志
// 作 成 日  2009/05/11  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 張凱
// 作 成 日  2009/11/30  修正内容 : 保守依頼③対応
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Library.Resources;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// 棚卸準備処理実行時注意事項UIクラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : 棚卸準備処理実行時注意事項UIクラスの機能を実装します</br>
	/// <br>Programmer : 照田 貴志</br>
	/// <br>Date       : 2009/05/11</br>
    /// <br>Update Note : 2009/11/30 張凱 保守依頼③対応</br>
    /// <br>             棚卸運用区分に合わせて内容を変更する</br>
	/// </remarks>
	public partial class BeforeSaveAttentionDialog : Form
	{
		#region Constructor

        private int _inventoryMngDiv; // ADD 2009/11/30
		/// <summary>
		/// 棚卸準備処理実行時注意事項UIクラス
		/// </summary>
        /// <param name="inventoryMngDiv">棚卸運用区分</param>
		/// <remarks>
		/// <br>Note       : 棚卸準備処理実行時注意事項UIクラスのインスタンスを初期化します</br>
		/// <br>Programmer : 照田 貴志</br>
	    /// <br>Date       : 2009/05/11</br>
        /// <br>Update Note : 2009/11/30 張凱 保守依頼③対応</br>
        /// <br>             棚卸運用区分に合わせて内容を変更する</br>
		/// </remarks>
		public BeforeSaveAttentionDialog (int inventoryMngDiv)
		{
            InitializeComponent();

            this._inventoryMngDiv = inventoryMngDiv;// ADD 2009/11/30
		}
		#endregion

		#region Control Event
        #region ubOk_Click Event
        /// <summary>
        /// ubOk_Click Event
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		private void ubOk_Click ( object sender, EventArgs e )
		{
			this.DialogResult = DialogResult.OK;
		}
		#endregion

        #region ubCancel_Click Event
        /// <summary>
        /// ubCancel_Click Event
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		private void ubCancel_Click ( object sender, EventArgs e )
		{
			this.DialogResult = DialogResult.Cancel;
		}
		#endregion

        #region ubAttention_Click Event
        /// <summary>
        /// ubAttention_Click Event
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        private void ubAttention_Click(object sender, EventArgs e)
        {
            // --- UPD 2009/11/30 ---------->>>>>
            //AttentionDialog dlg = new AttentionDialog();
            AttentionDialog dlg = new AttentionDialog(_inventoryMngDiv);
            // --- UPD 2009/11/30 ----------<<<<<
            dlg.ShowDialog();
        }
        #endregion
        #endregion
    }
}
//****************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : Tab名名称変更
// プログラム概要   : Tab名名称変更 フォームクラス
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 黄海霞
// 作 成 日  2011/07/20  修正内容 : 新規作成
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using System.Text.RegularExpressions;

namespace Broadleaf.Windows.Forms
{
    public partial class PMPCC09040UC : Form
    {
        private string _tabName;
        /// <summary>
        /// Tab名名称変更のフォームクラス
        /// </summary>
        /// <remarks>
        /// <br>Node        :  Tab名名称変更のフォームクラスです。</br>
        /// <br>Programmer  : 黄海霞</br>
        /// <br>Date        : 2011.07.20</br>
        /// </remarks>
        public PMPCC09040UC()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Tab名
        /// </summary>
        public string TabName
        {
           get { return this._tabName; }
           set { this._tabName = value; }
        }
        
        /// <summary>
        /// Control.Click イベント(Delete_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　  : 削除ボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programmer  : 黄海霞</br>
        /// <br>Date        : 2011.07.20</br>
        /// </remarks>
        private void Delete_Button_Click(object sender, EventArgs e)
        {
            this.Name_tEdit.Text = string.Empty;
            this.DialogResult = DialogResult.No;
            this.Close();
        }

        /// <summary>
        /// Control.Click イベント(Delete_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　  : 閉じるボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programmer  : 黄海霞</br>
        /// <br>Date        : 2011.07.20</br>
        /// </remarks>
        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        /// <summary>
        /// Control.Click イベント(Delete_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　  : 確定ボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programmer  : 黄海霞</br>
        /// <br>Date        : 2011.07.20</br>
        /// </remarks>
        private void Save_Button_Click(object sender, EventArgs e)
        {
            //必須入力チェック
            string inputValue = this.Name_tEdit.Text.Trim();
            if (string.IsNullOrEmpty(inputValue))
            {
                //メインに戻る
                TMsgDisp.Show(this,
                                   emErrorLevel.ERR_LEVEL_INFO,
                                   this.Name,
                                   "TAB名を入力して下さい",
                                   -1,
                                   MessageBoxButtons.OK);
                this.Name_tEdit.Focus();
                return;
            }
            else
            {
                this._tabName = inputValue;
                this.DialogResult = DialogResult.OK;
                this.Name_tEdit.Clear();
                this.Name_tEdit.Focus();

                this.Close();
            }
        }

        /// <summary>
        /// Form.Load イベント(PMPCC09040UC)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　  : ユーザーがフォームを読み込むときに発生します。</br>
        /// <br>Programmer  : 黄海霞</br>
        /// <br>Date        : 2011.07.20</br>
        /// </remarks>
        private void PMPCC09040UC_Load(object sender, EventArgs e)
        {
            // アイコンリソース管理クラスを使用して、アイコンを表示する
            ImageList imageList25 = IconResourceManagement.ImageList24;
            this.Cancel_Button.ImageList = imageList25;
            this.Save_Button.ImageList = imageList25;
            this.Delete_Button.ImageList = imageList25;

            this.Cancel_Button.Appearance.Image = Size24_Index.CLOSE;
            this.Save_Button.Appearance.Image = Size24_Index.DECISION;
            this.Delete_Button.Appearance.Image = Size24_Index.DELETE;
            this.Name_tEdit.Focus();
            this.Name_tEdit.Text = this._tabName;
            this.Cancel_Button.Enabled = true;
            this.Delete_Button.Enabled = true;
        }

      
    }
}
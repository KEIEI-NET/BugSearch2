//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : 得意先電子元帳
// プログラム概要   : 得意先電子元帳 テキスト出力用検索プログレスバー進捗状況
//----------------------------------------------------------------------------//
//                (c)Copyright 2015 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号                作成担当 : 王亜楠
// 修 正 日  2015/02/05    修正内容 : テキスト出力件数制限なしモードの追加
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Library.Windows.Forms;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// テキスト出力用検索プログレスバー進捗状況
    /// </summary>
    /// <remarks>
    /// <br>Note       : テキスト出力用検索プログレスバー進捗状況クラスです。</br>
    /// <br>Programmer : 王亜楠</br>
    /// <br>Date       : 2015/02/05</br>
    /// </remarks>
    public partial class PMKAU04004UC : Form
    {
        /// <summary>抽出件数</summary>
        private int _searchMax;

        /// <summary>
        /// 抽出件数
        /// </summary>
        public int SearchMax
        {
            get { return _searchMax; }
            set { _searchMax = value; }
        }

        /// <summary>
        /// コンストラクター
        /// </summary>
        /// <remarks>
        /// <br>Note       : コンストラクターです。</br>
        /// <br>Programmer : 王亜楠</br>
        /// <br>Date       : 2015/02/05</br>
        /// </remarks>
        public PMKAU04004UC()
        {
            InitializeComponent();
        }

        /// <summary>
        /// PMKAU04004UC_Load イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : PMKAU04004UC_Load イベントです。</br>
        /// <br>Programmer : 王亜楠</br>
        /// <br>Date       : 2015/02/05</br>
        /// </remarks>
        private void PMKAU04004UC_Load(object sender, EventArgs e)
        {
            this.Cancel_Button.Visible = true;
            this.Cancel_Button.Enabled = true;

            // 画面設定
            this.ScreenSetting(this._searchMax);
        }

        /// <summary>
        /// 画面初期設定
        /// </summary>
        /// <param name="searchMax"></param>
        /// <remarks>
        /// <br>Note       : 画面初期設定</br>
        /// <br>Programmer : 王亜楠</br>
        /// <br>Date       : 2015/02/05</br>
        /// </remarks>
        private void ScreenSetting(int searchMax)
        {
            // 呼出元のスレッドを判定
            if (this.InvokeRequired == false)
            {
                this.InitialSetting(searchMax);
            }
        }

        /// <summary>
        /// 画面初期設定
        /// </summary>
        /// <param name="max"></param>
        /// <remarks>
        /// <br>Note       : 画面初期設定</br>
        /// <br>Programmer : 王亜楠</br>
        /// <br>Date       : 2015/02/05</br>
        /// </remarks>
        private void InitialSetting(int max)
        {
            if (max != 0)
            {
                this.Main_ProgressBar.Visible = true;
                this.Main_ProgressBar.Maximum = max;
                this.Main_ProgressBar.Minimum = 0;
            }
            else
            {
                this.Main_ProgressBar.Visible = false;
            }
        }

        /// <summary>
        /// プログレスバー進捗状況設定処理
        /// </summary>
        /// <param name="seachCount"></param>
        /// <remarks>
        /// <br>Note       : プログレスバー進捗状況設定処理</br>
        /// <br>Programmer : 王亜楠</br>
        /// <br>Date       : 2015/02/05</br>
        /// </remarks>
        public void ProgressBarUpEvent(int seachCount)
        {
            ProcessSetting(seachCount);
        }

        /// <summary>
        /// プログレスバー進捗状況設定処理
        /// </summary>
        /// <param name="cnt"></param>
        /// <remarks>
        /// <br>Note       : プログレスバー進捗状況設定処理</br>
        /// <br>Programmer : 王亜楠</br>
        /// <br>Date       : 2015/02/05</br>
        /// </remarks>
        private void ProcessSetting(int cnt)
        {
            if (this._searchMax != 0)
            {
                this.Main_ProgressBar.Value = cnt;
                this.Main_ProgressBar.Refresh();
                System.Windows.Forms.Application.DoEvents();
            }
        }

        /// <summary>
        /// キャンセルボタンのクリック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : キャンセルボタンのクリックイベント</br>
        /// <br>Programmer : 王亜楠</br>
        /// <br>Date       : 2015/02/05</br>
        /// </remarks>
        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            if (TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_QUESTION, this.Name,
                    "抽出処理を中断してよろしいですか？", -1, MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (CancelButtonClick != null)
                {
                    CancelButtonClick(sender, e);
                }
            }
        }

        /// <summary>キャンセルボタンのクリックイベント </summary>
        public event EventHandler CancelButtonClick;
    }
}
//****************************************************************************//
// システム         : 回答送信処理
// プログラム名称   : 回答送信処理アクセス
// プログラム概要   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 杉村 利彦
// 作 成 日  2006/10/10  修正内容 : 新規作成：ＴＳＰ送受信処理【ＰＭ側】(SFMIT02851A)
// 管理番号              作成担当 : 工藤 恵優
// 作 成 日  2009/05/29  修正内容 : SCM用にアレンジ
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 回答送信処理の設定画面フォーム
    /// </summary>
    public partial class PMSCM01103AC : Form
    {
        #region <送信データフォルダ>

        /// <summary>SCM送信データフォルダパス</summary>
        private string _scmDataPath;
        /// <summary>SCM送信データフォルダパスを取得または設定します。</summary>
        public string SCMDataPath
        {
            get { return _scmDataPath; }
            set { _scmDataPath = value; }
        }

        #endregion // </送信データフォルダ>

        #region <保存期間>

        /// <summary>保存期間種別</summary>
        private int _savePeriodType;
        /// <summary>保存期間種別を取得または設定します。</summary>
        public int SavePeriodType
        {
            get { return _savePeriodType; }
            set { _savePeriodType = value; }
        }

        #endregion // </保存期間>

        #region <Constructor>

        /// <summary>
        /// カスタムコンストラクタ
        /// </summary>
        /// <param name="scmDataPath">SCM送信データパス</param>
        /// <param name="savePeriodType">保存期間種別</param>
        public PMSCM01103AC(
            string scmDataPath,
            int savePeriodType
        )
        {
            #region <Designer Code>

            InitializeComponent();

            #endregion // </Designer Code>

            _scmDataPath    = scmDataPath;
            _savePeriodType = savePeriodType;
            
            this.DialogResult = DialogResult.Cancel;
            this.txtSCMDataPath.Text = SCMDataPath;
            this.optSavePeriodType.CheckedIndex = SavePeriodType;
        }

        #endregion // </Constructor>

        /// <summary>
        /// [確定]ボタンのClickイベントハンドラ
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            SCMDataPath     = this.txtSCMDataPath.Text;
            SavePeriodType  = this.optSavePeriodType.CheckedIndex;
            this.Close();
        }

        /// <summary>
        /// [キャンセル]ボタンのClickイベントハンドラ
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
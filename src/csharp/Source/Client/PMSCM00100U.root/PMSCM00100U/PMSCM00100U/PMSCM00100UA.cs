//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 簡単問合せCTI表示 フレームクラス
// プログラム概要   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号 10601193-00  作成担当 : 21024　佐々木 健
// 作 成 日  2010/04/06  修正内容 : IAAE版から製品版へ変更(不要ロジック削除)
//----------------------------------------------------------------------------//
// 管理番号 10601193-00  作成担当 : 21024　佐々木 健
// 作 成 日  2010/04/30  修正内容 : ActiveReport製品版対応
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
using Broadleaf.Windows.Forms;
using Broadleaf.Library.Text;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 簡単問合せCTI表示 フレームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : IAAE版から製品版へ変更(不要ロジック削除)</br>
    /// <br>Programmer : 21024　佐々木 健</br>
    /// <br>Date       : 2010/04/06</br>
    /// </remarks>
    public partial class PMSCM00100UA : Form
    {
        // ===================================================================================== //
        // プライベート変数
        // ===================================================================================== //
        #region ■ Private Member

        /// <summary>コマンドライン引数</summary>
        private readonly string[] _commandLineArgs;
        /// <summary>コマンドライン引数を取得します。</summary>
        private string[] CommandLineArgs { get { return _commandLineArgs; } }

        /// <summary>画面</summary>
        private PMSCM00101UA _ctiForm;

        #endregion

        // ===================================================================================== //
        // コンストラクタ
        // ===================================================================================== //
        #region ■ Constructor

        /// <summary>
        /// カスタムコンストラクタ
        /// </summary>
        /// <param name="commandLineArgs">コマンドライン引数</param>
		public PMSCM00100UA(string[] commandLineArgs)
		{
			InitializeComponent();

            _commandLineArgs = commandLineArgs;


            int customerCode = 0;
            foreach (string prm in _commandLineArgs)
            {
                if (prm.Contains("/Customer,"))
                {
                    string customerCodeStr = prm.Replace("/Customer,", "");
                    customerCode = TStrConv.StrToIntDef(customerCodeStr, 0);
                    break;
                }
            }
            this._ctiForm = ( customerCode > 0 ) ? new PMSCM00101UA(customerCode) : new PMSCM00101UA();
        }

        #endregion

        // ===================================================================================== //
        // コンポーネントのイベント
        // ===================================================================================== //
        #region ■ Component Event
        /// <summary>
        /// 画面ロードイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PMSCM00100UA_Load(object sender, EventArgs e)
		{
            this._ctiForm.CommandLineArgs = CommandLineArgs; 
            this._ctiForm.SettingVisible += new PMSCM00101UA.SettingVisibleEventHandler(this.SetVisibleState);
            this._ctiForm.TopLevel = false;
			this._ctiForm.FormBorderStyle = FormBorderStyle.None;
			this._ctiForm.Show();
			this.Controls.Add(this._ctiForm);
			this._ctiForm.Dock = DockStyle.Fill;

            // クローズ処理のイベントを追加
			this._ctiForm.FormClosed += new FormClosedEventHandler(this.CTIForm_FormClosed);
        }

        #endregion

        // ===================================================================================== //
        // パブリックメソッド
        // ===================================================================================== //
        #region ■ Public Method

        /// <summary>
        /// 起動可能かチェック
        /// </summary>
        /// <returns></returns>
        public bool CanStart()
        {
            return this._ctiForm.CanStart;
        }
        #endregion

        // ===================================================================================== //
        // プライベートメソッド
        // ===================================================================================== //
        #region ■ Private Method

        /// <summary>
        /// CTIの子画面が閉じたときに発生するイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CTIForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			this.Close();
		}

        /// <summary>
        /// 表示状態を設定します。
        /// </summary>
        /// <param name="visible">表示フラグ</param>
        private void SetVisibleState(bool visible)
        {
            if (visible)
            {
                Visible = true;
                ShowInTaskbar = true;
                TopMost = true;
                Activate();
                TopMost = false;
                SetInitialPosition();
            }
            else
            {
                Visible = false;
                ShowInTaskbar = false;
                this.Hide();
            }
        }

        /// <summary>
        /// 初期起動位置を設定します。
        /// </summary>
        private void SetInitialPosition()
        {
            this.StartPosition = FormStartPosition.WindowsDefaultLocation;
        }

        protected override void WndProc(ref Message m)
        {
            const int WM_SYSCOMMAND = 0x112;
            const int SC_CLOSE = 0xF060;

            if (m.Msg == WM_SYSCOMMAND && m.WParam.ToInt32() == SC_CLOSE)
            {
                //this.SetVisibleState(false);
                this._ctiForm.SaveDetailSetting();
                //return;
            }
            base.WndProc(ref m);
        }

        #endregion
    }
}
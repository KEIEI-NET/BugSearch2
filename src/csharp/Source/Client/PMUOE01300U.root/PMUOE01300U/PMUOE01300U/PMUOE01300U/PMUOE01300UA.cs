//****************************************************************************//
// システム         : 卸商仕入受信処理
// プログラム名称   : 卸商仕入受信処理メインフレーム
// プログラム概要   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 工藤 恵優
// 作 成 日  2008/11/17  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 21024　佐々木 健
// 作 成 日  2009/10/09  修正内容 : 受信の該当データ無し対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 21024  佐々木 健 
// 作 成 日  2010/10/19  修正内容 : EXEのアイコンの変更(MANTIS[0016443])
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Controller.Util;
using Broadleaf.Application.UIData;
using Broadleaf.Application.UIData.Exception;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Windows.Forms;

using Infragistics.Win;
using Infragistics.Win.UltraWinToolbars;

namespace Broadleaf.Windows.Forms
{
    using LoginWorkerAcs = SingletonPolicy<LoginWorker>;

	/// <summary>
    /// 卸商仕入受信処理メインフレームフォーム
	/// </summary>
	public partial class PMUOE01300UA : Form
    {
        #region <Constructor/>

        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        public PMUOE01300UA()
        {
            #region <Designer Code/>

            InitializeComponent();

            #endregion  // <Designer Code/>
        }

        #endregion  // <Constructor/>

        #region <フォーム/>

        /// <summary>
		/// セキュリティ管理メインフレームのLoadイベントハンドラ
		/// </summary>
		/// <param name="sender">イベントソース</param>
		/// <param name="e">イベントパラメータ</param>
        private void PMUOE01300UA_Load(object sender, EventArgs e)
        {
            // 現在のカーソルを保持
            Cursor localCursor = Cursor;
            try
            {
                // カーソルを砂時計に設定
                Cursor = Cursors.WaitCursor;

                // ツールバーを初期化
                InitializeToolbar();

                // Viewを初期化
                this.oroshishoStockReceptionView.Initialize();

                // UOE発注先が存在しない場合、処理は行えない
                if (!this.oroshishoStockReceptionView.ExistsUOESupplier)
                {
                    SaveToolButton.SharedProps.Enabled = false;
                }

                // 進捗表示用のイベントを設定
                this.oroshishoStockReceptionView.UpdateProgress += this.UpdateProgress;
            }
            catch (OroshishoStockReceptionException ex)
            {
                Program.ShowDefaultAlert(emErrorLevel.ERR_LEVEL_EXCLAMATION, ex.Message, ex.Status);
            }
			finally
			{
                // カーソルを戻す
                Cursor = localCursor;
			}
		}

        /// <summary>
        /// 卸商仕入受信処理メインフレームのKeyDownイベントハンドラ
        /// </summary>
        /// <remarks>
        /// [Escape]キー押下時に終了処理を行います。
        /// </remarks>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントハンドラ</param>
        private void PMUOE01300UA_KeyDown(object sender, KeyEventArgs e)
        {
            #region <Guard Phrase/>
            
            if (!e.KeyCode.Equals(Keys.Escape)) return;

            #endregion  // <Guard Phrase/>

            const string TEXT = "終了しますか？";   // LITERAL:
            const string CAPTION = "確認";          // LITERAL:
            if (MessageBox.Show(TEXT, CAPTION, MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.Yes))
            {
                Close();
            }
        }

        #endregion  // <フォーム/>

        #region <ツールバー/>

        #region <[終了]ツールボタン/>

        /// <summary>[終了]ツールボタンのキー</summary>
        private const string TOOL_BUTTON_CLOSE_KEY = "Close";
        /// <summary>[終了]ツールボタンのアイコン（インデックス）</summary>
        private const int TOOL_BUTTON_CLOSE_ICON_INDEX = (int)Size16_Index.CLOSE;

        /// <summary>
        /// [終了]ツールボタンを取得します。
        /// </summary>
        /// <value>閉じるツールボタン</value>
        private ButtonTool CloseToolButton
        {
            get { return (ButtonTool)this.mainToolbarsManager.Tools[TOOL_BUTTON_CLOSE_KEY]; }
        }

        #endregion  // <[終了]ツールボタン/>

        #region <[確定]ツールボタン/>

        /// <summary>[確定]ツールボタンのキー</summary>
        private const string TOOL_BUTTON_SAVE_KEY = "Save";
        /// <summary>[確定]ツールボタンのアイコン（インデックス）</summary>
        private const int TOOL_BUTTON_SAVE_ICON_INDEX = (int)Size16_Index.SAVE;

        /// <summary>
        /// [確定]ツールボタンを取得します。
        /// </summary>
        /// <value>[確定]ツールボタン</value>
        private ButtonTool SaveToolButton
        {
            get { return (ButtonTool)this.mainToolbarsManager.Tools[TOOL_BUTTON_SAVE_KEY]; }
        }

        #endregion

        /// <summary>
        /// ツールバーのToolClickイベントハンドラ
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        private void mainToolbarsManager_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                case TOOL_BUTTON_CLOSE_KEY: // [終了]
                {
                    Close();
                    break;
                }
                case TOOL_BUTTON_SAVE_KEY:  // [確定]
                {
                    const string TEXT = "仕入受信処理を実行しますか？"; // LITERAL:
                    const string CAPTION = "確認";                      // LITERAL:
                    if (!MessageBox.Show(TEXT, CAPTION, MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.Yes)) break;
                    SetStatusBarText(string.Empty);
                    this.Update();

                    // [確定]ツールボタンをクリック
                    // 2009/10/09 >>>
                    //int resultCode = this.oroshishoStockReceptionView.Execute();
                    Result.ProcessID processID;
                    int resultCode = this.oroshishoStockReceptionView.Execute(out processID);
                    // 2009/10/09 <<<
                    if (
                        !resultCode.Equals((int)Result.Code.Normal)
                            &&
                        !resultCode.Equals((int)Result.Code.Abort)  // 既にメッセージを出力済み
                    )
                    {
                        // TODO:エラーメッセージの設定箇所
                        // 2009/10/09 >>>
                        //string msg = Result.ToErrorMessage(resultCode);
                        string msg = Result.ToErrorMessage(resultCode, processID);
                        // 2009/10/09 <<<
                        MessageBox.Show(
                            msg,
                            "＜卸商仕入受信処理＞", 
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                        );
                    }
                    SetStatusBarText(string.Empty);
                    break;
                }
            }
        }

        /// <summary>
        /// ツールバーを初期化します。
        /// </summary>
        private void InitializeToolbar()
        {
            // イメージリストを設定する
            this.mainToolbarsManager.ImageListSmall = IconResourceManagement.ImageList16;

            //--------------------------------------------------------------
            // メイン ツールバー
            //--------------------------------------------------------------
            // ログイン担当者のアイコン設定
            LabelTool loginEmployeeLabel = (LabelTool)this.mainToolbarsManager.Tools["LOGINTITLE"];
            loginEmployeeLabel.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.EMPLOYEE;

            // ログイン名
            LabelTool loginName = (LabelTool)this.mainToolbarsManager.Tools["LoginName_LabelTool"];
            if (LoginWorkerAcs.Instance.Policy.Profile != null)
            {
                loginName.SharedProps.Caption = LoginWorkerAcs.Instance.Policy.Profile.Name;
            }

            //--------------------------------------------------------------
            // 標準 ツールバー
            //--------------------------------------------------------------
            // 閉じるツールボタンのアイコン設定
            CloseToolButton.SharedProps.AppearancesSmall.Appearance.Image = TOOL_BUTTON_CLOSE_ICON_INDEX;

            // 保存ツールボタンのアイコン設定
            SaveToolButton.SharedProps.AppearancesSmall.Appearance.Image = TOOL_BUTTON_SAVE_ICON_INDEX;
        }

        #endregion  // <ツールバー/>

        #region <ステータスバー/>

        /// <summary>
        /// ステータスバーのテキストを設定します。
        /// </summary>
        /// <param name="text">テキスト</param>
        private void SetStatusBarText(string text)
        {
            this.ultraStatusBar.Panels["Text"].Text = text;
        }

        /// <summary>
        /// 進捗を更新します。
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        private void UpdateProgress(
            object sender,
            UpdateProgressEventArgs e
        )
        {
            SetStatusBarText(e.ToString());
            this.Update();
        }

        #endregion  // <ステータスバー/>
    }
}
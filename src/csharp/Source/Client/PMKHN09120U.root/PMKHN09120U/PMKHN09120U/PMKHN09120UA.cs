//****************************************************************************//
// システム         : セキュリティ管理
// プログラム名称   : セキュリティ管理メインフレーム
// プログラム概要   : ①オペレーション操作権限設定マスメン呼び出し
//                  : ②オペレーション操作権限設定一覧表示の呼び出し
//                  : ③操作履歴表示の呼び出し
//                  : ④エラーログ表示の呼び出し
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 工藤 恵優
// 作 成 日  2008/07/23  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 吉岡
// 作 成 日  2013/08/09  修正内容 : タブレット マスタアップロード対象の場合にメッセージ表示
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Windows.Forms;

using Infragistics.Win;
using Infragistics.Win.UltraWinTabControl;
using Infragistics.Win.UltraWinToolbars;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
    /// セキュリティ管理メインフレームのフォームクラス
	/// </summary>
	public partial class PMKHN09120UA : Form
	{
        #region <ツールバー/>
        
        #region <[閉じる]ツールボタン/>

        /// <summary>[閉じる]ツールボタンのキー</summary>
        private const string TOOL_BUTTON_CLOSE_KEY = "Close";
        /// <summary>[閉じる]ツールボタンのアイコン（インデックス）</summary>
        private const int TOOL_BUTTON_CLOSE_ICON_INDEX = (int)Size16_Index.CLOSE;

        /// <summary>
        /// 閉じるツールボタンを取得します。
        /// </summary>
        /// <value>閉じるツールボタン</value>
        private ButtonTool CloseToolButton
        {
            get { return (ButtonTool)this.mainToolbarsManager.Tools[TOOL_BUTTON_CLOSE_KEY]; }
        }

        #endregion  // <[閉じる]ツールボタン/>

        #region <[表示更新]ツールボタン/>

        /// <summary>[表示更新]ツールボタンのキー</summary>
        private const string TOOL_BUTTON_UPDATE_KEY = "Update";
        /// <summary>[表示更新]ツールボタンのアイコン（インデックス）</summary>
        private const int TOOL_BUTTON_UPDATE_ICON_INDEX = (int)Size16_Index.VIEW;

        /// <summary>
        /// 表示更新ツールボタンを取得します。
        /// </summary>
        /// <value>表示更新ツールボタン</value>
        private ButtonTool UpdateToolButton
        {
            get { return (ButtonTool)this.mainToolbarsManager.Tools[TOOL_BUTTON_UPDATE_KEY]; }
        }

        #endregion  // <[表示更新]ツールボタン/>

        #region <[保存]ツールボタン/>

        /// <summary>保存ツールボタンのキー</summary>
        private const string TOOL_BUTTON_SAVE_KEY = "Save";
        /// <summary>保存ツールボタンのアイコン（インデックス）</summary>
        private const int TOOL_BUTTON_SAVE_ICON_INDEX = (int)Size16_Index.SAVE;

        /// <summary>
        /// 保存ツールボタンを取得します。
        /// </summary>
        /// <value>保存ツールボタン</value>
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
                case TOOL_BUTTON_CLOSE_KEY: // [閉じる]
                    {
                        Close();
                        break;
                    }
                case TOOL_BUTTON_UPDATE_KEY:// [表示更新]
                    {
                        #region <Guard Phrase/>

                        if (CurrentChildForm == null) break;

                        #endregion  // <Guard Phrase/>

                        CurrentChildForm.UpdateDisplay();
                        break;
                    }
                case TOOL_BUTTON_SAVE_KEY:  // [保存]
                    {
                        #region <Guard Phrase/>

                        const string TEXT = "保存しますか？";   // LITERAL:
                        const string CAPTION = "確認";          // LITERAL:
                        if (!MessageBox.Show(
                            TEXT, CAPTION,
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question).Equals(DialogResult.Yes)
                        ) break;

                        if (CurrentChildForm == null) break;

                        #endregion  // <Guard Phrase/>

                        if (!CurrentChildForm.Write().Equals((int)ResultCode.Normal))
                        {
                            MessageBox.Show(
                                "保存に失敗しました。", // LITERAL:
                                "＜セキュリティ管理＞", // LITERAL:
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information
                            );
                        }
                        break;
                    }
            }
        }

        #endregion  // <ツールバー/>

        #region <タブ/>

        /// <summary>タブのキー配列</summary>
        /// <remarks>タブを追加する場合はここに追加</remarks>
        private readonly string[] _entryTabKeys = new string[]
        {
            // TODO:タブを追加する場合はここに追加
            TabConfig.SECURITY_MANAGEMENT_SETTING_KEY,
            TabConfig.SECURITY_MANAGEMENT_VIEW_KEY,
            TabConfig.OPERATION_LOG_VIEW_KEY,
            TabConfig.ERROR_LOG_VIEW_KEY
        };

        /// <summary>タブ構成のマップ</summary>
        private readonly Dictionary<string, TabConfig> _tabConfigMap = new Dictionary<string, TabConfig>();

        /// <summary>
        /// 現在の子フォームを取得します。
        /// </summary>
        /// <value>現在の子フォーム</value>
        private ISecurityManagementForm CurrentChildForm
        {
            get { return this._tabConfigMap[this.mainTabControl.ActiveTab.Key].Form as ISecurityManagementForm; }
        }

        /// <summary>
        /// タブのSelectedTabChangedイベントハンドラ
        /// </summary>
        /// <remarks>
        /// 選択タブに応じたツールバー制御を行います。
        /// </remarks>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        private void mainTabControl_SelectedTabChanged(object sender, SelectedTabChangedEventArgs e)
        {
            if (CurrentChildForm != null)
            {
                UpdateToolButton.SharedProps.Visible= CurrentChildForm.CanUpdateDisplay;
                SaveToolButton.SharedProps.Visible  = CurrentChildForm.CanWrite;
            }
            else
            {
                UpdateToolButton.SharedProps.Visible= false;
                SaveToolButton.SharedProps.Visible  = false;
            }

            if (CurrentChildForm is ISecurityManagementForm)
            {
                ((ISecurityManagementForm)CurrentChildForm).Active();
            }

            // ADD 吉岡 2013/08/09 タブレットアップロードメッセージ対応 --------->>>>>>>>>>>>>>>>>>>>>>>>>
            // オプションチェック
            Broadleaf.Application.Remoting.ParamData.PurchaseStatus ps;
            ps = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(Broadleaf.Application.Resources.ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_BasicTablet);
            if (ps == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
            {
                if (mainTabControl.ActiveTab.Key.Equals(TabConfig.SECURITY_MANAGEMENT_SETTING_KEY)
                    || mainTabControl.ActiveTab.Key.Equals(TabConfig.SECURITY_MANAGEMENT_VIEW_KEY))
                {
                    ultraStatusBar.Panels["Msg"].Visible = true;
                }
                else
                {
                    ultraStatusBar.Panels["Msg"].Visible = false;
                }
            }
            // ADD 吉岡 2013/08/09 タブレットアップロードメッセージ対応 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

        }

        #endregion  // <タブ/>

        #region <Constructor/>

        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        public PMKHN09120UA()
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
        private void PMKHN09120UA_Load(object sender, EventArgs e)
        {
            // 現在のカーソルを保持
            Cursor localCursor = Cursor;
			try
			{
                // カーソルを砂時計に設定
                Cursor = Cursors.WaitCursor;

				// ツールバーを初期化
				InitializeToolbar();

                // タブを初期化
                InitializeTab();

                // イベントハンドラを追加
                ISecurityManagementView
                    viewForm = this._tabConfigMap[TabConfig.SECURITY_MANAGEMENT_VIEW_KEY].Form
                        as ISecurityManagementView;
                if (viewForm != null)
                {
                    viewForm.Selected += new GridSelectedEventHandler(this.SecurityManagementViewGridSelected);
                }

                IStatusBarShowable settingForm = this._tabConfigMap[TabConfig.SECURITY_MANAGEMENT_SETTING_KEY].Form
                        as IStatusBarShowable;
                if (settingForm != null)
                {
                    settingForm.ShowStatusBar += new ValueIsInvalidEventHandler(this.ShowStatusBar);
                }
			}
			finally
			{
                // カーソルを戻す
                Cursor = localCursor;
			}
		}

        /// <summary>
        /// セキュリティ管理メインフレームのKeyDownイベントハンドラ
        /// </summary>
        /// <remarks>
        /// [Escape]キー押下時に終了処理を行います。
        /// </remarks>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントハンドラ</param>
        private void PMKHN09120UA_KeyDown(object sender, KeyEventArgs e)
        {
            #region <Guard Phrase/>
            
            if (!e.KeyCode.Equals(Keys.Escape)) return;

            #endregion  // <Guard Phrase/>

            const string TEXT = "終了しますか？";   // LITERAL:
            const string CAPTION = "確認";          // LITERAL:
            if (MessageBox.Show(TEXT, CAPTION, MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.Yes)) Close();
        }

        #endregion  // <フォーム/>

        #region <操作権限一覧表示のグリッドが選択されたときのイベント/>

        /// <summary>
        /// 操作権限一覧表示のグリッドが選択されたときのイベントハンドラ
        /// </summary>
        /// <param name="sender">グリッドの親オブジェクト</param>
        /// <param name="operationSt">選択された行に対するオペレーション情報</param>
        private void SecurityManagementViewGridSelected(
            object sender,
            OperationSt operationSt
        )
        {
            ISecurityManagementSetting
                settingForm = this._tabConfigMap[TabConfig.SECURITY_MANAGEMENT_SETTING_KEY].Form
                    as ISecurityManagementSetting;
            if (settingForm == null) return;

            this.mainTabControl.SelectedTab = this.mainTabControl.Tabs[TabConfig.SECURITY_MANAGEMENT_SETTING_KEY];

            settingForm.Select(operationSt);
        }

        #endregion  // <操作権限一覧表示のグリッドが選択されたときのイベント/>

        #region <ツールバーの構築/>

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
            if (LoginInfoAcquisition.Employee != null)
            {
                loginName.SharedProps.Caption = LoginInfoAcquisition.Employee.Name;
            }

            //--------------------------------------------------------------
            // 標準 ツールバー
            //--------------------------------------------------------------
            // 閉じるツールボタンのアイコン設定
            CloseToolButton.SharedProps.AppearancesSmall.Appearance.Image = TOOL_BUTTON_CLOSE_ICON_INDEX;

            // 表示更新ツールボタンのアイコン設定
            UpdateToolButton.SharedProps.AppearancesSmall.Appearance.Image = TOOL_BUTTON_UPDATE_ICON_INDEX;

            // 保存ツールボタンのアイコン設定
            SaveToolButton.SharedProps.AppearancesSmall.Appearance.Image = TOOL_BUTTON_SAVE_ICON_INDEX;
        }

        #endregion  // <ツールバーの構築/>

        #region <タブの構築/>

        /// <summary>
        /// タブを初期化します。
        /// </summary>
        private void InitializeTab()
        {
            // タブにイメージリストを設定
            this.mainTabControl.ImageList = TabConfig.ImageList;

            this._tabConfigMap.Clear();
            foreach (string tabKey in this._entryTabKeys)
            {
                // タブ構成マップを構築
                this._tabConfigMap.Add(tabKey, TabConfig.CreateInstance(tabKey));

                // タブに子フォームを追加
                AddChildFormToTab(this._tabConfigMap[tabKey]);
            }

            // 先頭タブを選択
            this.mainTabControl.SelectedTab = this.mainTabControl.Tabs[0];
        }

        /// <summary>
        /// タブに子フォームを追加します。
        /// </summary>
        /// <param name="config">タブ構成</param>
        private void AddChildFormToTab(TabConfig config)
        {
            #region <Guard Phrase/>

            if (config.Form == null) return;

            #endregion  // <Guard Phrase/>

            // 対応するフォームコントロールのプロパティを変更
            config.Form.Name = config.Key;
            config.Form.TopLevel = false;
            config.Form.FormBorderStyle = FormBorderStyle.None;
            config.Form.Dock = DockStyle.Fill;

            // タブページコントロールのインスタンスを生成
            UltraTabPageControl uTabPageControl = new UltraTabPageControl();
            uTabPageControl.Controls.Add(config.Form);

            // タブの外観を設定し、タブコントロールにタブを追加
            UltraTab uTab = new UltraTab();
            uTab.TabPage = uTabPageControl;

            uTab.Key = config.Key;				    // キー
            uTab.Text = config.Text;				// タイトル
            uTab.Tag = config.Form;				    // 対応するフォームコントロール
            uTab.Appearance.Image = config.Icon;    // アイコン

            uTab.Appearance.BackColor = Color.White;
            uTab.Appearance.BackColor2 = Color.Lavender;
            uTab.Appearance.BackGradientStyle = GradientStyle.Vertical;
            uTab.ActiveAppearance.BackColor = Color.White;
            uTab.ActiveAppearance.BackColor2 = Color.LightPink;
            uTab.ActiveAppearance.BackGradientStyle = GradientStyle.Vertical;

            this.mainTabControl.Controls.Add(uTabPageControl);
            this.mainTabControl.Tabs.AddRange(new UltraTab[] { uTab });
            this.mainTabControl.SelectedTab = uTab;

            config.Form.Show();
        }

        #endregion  // <タブの構築/>

        #region <ステータスバー/>

        /// <summary>
        /// ステータスバーに表示するイベントハンドラ
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        private void ShowStatusBar(
            object sender,
            StatusBarMsg e
        )
        {
            this.ultraStatusBar.Panels["Text"].Text = e.Msg;
        }

        #endregion  // <ステータスバー/>
    }
}
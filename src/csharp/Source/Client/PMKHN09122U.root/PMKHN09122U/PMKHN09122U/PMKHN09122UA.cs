//****************************************************************************//
// システム         : 操作履歴表示
// プログラム名称   : 操作履歴表示メインフレーム
// プログラム概要    : セキュリティ管理の操作履歴表示／エラーログ表示のみに限定した参照用ＰＧ
//                  : 　①操作履歴表示の呼び出し
//                  : 　②エラーログ表示の呼び出し
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 22018 鈴木 正臣
// 作 成 日  2010/02/22  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号  11202046-00 作成担当 : 時シン
// 作 成 日  K2016/10/28 修正内容 : 神姫産業㈱ テキスト出力機能追加と時刻検索条件の追加対応
//----------------------------------------------------------------------------//
// 管理番号  11770181-00 作成担当 : 陳艶丹
// 作 成 日  2021/12/15  修正内容 : テキスト出力機能追加と時刻検索条件の追加対応
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
// ADD 時シン K2016/10/28 神姫産業㈱ テキスト出力機能追加対応 ---->>>>>
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Resources;
using System.IO;
using Broadleaf.Library.Windows.Forms;
// ADD 時シン K2016/10/28 神姫産業㈱ テキスト出力機能追加対応 ----<<<<<

namespace Broadleaf.Windows.Forms
{
	/// <summary>
    /// 操作履歴表示メインフレームのフォームクラス
	/// </summary>
    /// <remarks>
    /// <br>Note         : 操作履歴表示・ログ表示を行います。</br>
    /// <br>Programmer   : 22018 鈴木　正臣</br>
    /// <br>Date         : 2010.02.22</br>
    /// <br>Update Note  : K2016/10/28  時シン</br>
    /// <br>管理番号     : 11202046-00</br>
    /// <br>             : 神姫産業㈱ テキスト出力機能追加対応</br>
    /// <br>Update Note  : 2021/12/15  陳艶丹</br>
    /// <br>管理番号     : 11770181-00</br>
    /// <br>             : テキスト出力機能追加と時刻検索条件の追加対応</br>
    /// <br></br>
    /// </remarks>
    public partial class PMKHN09122UA : Form
	{
        //----- ADD 時シン K2016/10/28 神姫産業㈱ 時刻検索条件の追加 ---------->>>>>
        private PMKHN09122UC PMKHN09122UCObj;
        /*DEL 陳艶丹 2021/12/15 神姫産業㈱オプションの廃止 ----->>>>>
        /// <summary>神姫産業㈱-操作履歴表示オプション</summary>
        private PurchaseStatus ShinkiOperahistoryOpt;
        //DEL 陳艶丹 2021/12/15 神姫産業㈱オプションの廃止 -----<<<<<*/
        /// <summary> 設定情報 </summary>
        private ExtractionConditionSet ExtractionConditionSetObj;

        /// <summary>設定ファイル名</summary>
        private const string CT_XML_FILE = "PMKHN09122U_UserSetting.xml";
        /// <summary>プログラムID</summary>
        private const string PROGRAM_ID = "PMKHN09122";
        /// <summary>異常</summary>
        private const int ERROR_STATUS = -1;
        /// <summary>XMLファイルエラー</summary>
        private const string MSG_START_ERR = "設定ファイル({0})に誤りがあります。設定内容を正しく設定し、再度起動して下さい。";
        //----- ADD 時シン K2016/10/28 神姫産業㈱ 時刻検索条件の追加 ----------<<<<<
        //----- ADD 陳艶丹 2021/12/15 テキスト出力機能追加と時刻検索条件の追加対応 ----->>>>>
        private const int MINTIME = 0;
        private const int HSEC = 3600;
        private const int MSEC = 60;
        private const int INPUTMAXHOUR = 30;
        //----- ADD 陳艶丹 2021/12/15 テキスト出力機能追加と時刻検索条件の追加対応 -----<<<<<
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

        // ADD 時シン K2016/10/28 神姫産業㈱ テキスト出力機能追加対応 ---->>>>>
        #region <[テキスト出力]ツールボタン/>
        /// <summary>[テキスト出力]ツールボタンのキー</summary>
        private const string TOOL_BUTTON_TEXTOUT_KEY = "TextOut";
        /// <summary>[テキスト出力]ツールボタンのアイコン（インデックス）</summary>
        private const int TOOL_BUTTON_TEXTOUT_ICON_INDEX = (int)Size16_Index.CSVOUTPUT;

        /// <summary>
        /// テキスト出力ツールボタンを取得します。
        /// </summary>
        /// <value>テキスト出力ツールボタン</value>
        private ButtonTool TextOutToolButton
        {
            get { return (ButtonTool)this.mainToolbarsManager.Tools[TOOL_BUTTON_TEXTOUT_KEY]; }
        }
        #endregion
        // ADD 時シン K2016/10/28 神姫産業㈱ テキスト出力機能追加対応 ----<<<<<

        /// <summary>
        /// ツールバーのToolClickイベントハンドラ
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Update Note  : K2016/10/28  時シン</br>
        /// <br>管理番号     : 11202046-00</br>
        /// <br>             : 神姫産業㈱ テキスト出力機能追加対応</br>
        /// </remarks>
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
                // ADD 時シン K2016/10/28 神姫産業㈱ テキスト出力機能追加対応 ---->>>>>
                case TOOL_BUTTON_TEXTOUT_KEY:
                    {
                        if (CurrentChildForm == null) break;

                        // 子フォーム
                        this.PMKHN09122UCObj.GetSubForm = CurrentChildForm;

                        // テキスト出力確認画面起動
                        this.PMKHN09122UCObj.ShowDialog();
                        break;
                    }
                // ADD 時シン K2016/10/28 神姫産業㈱ テキスト出力機能追加対応 ----<<<<<
                // --- DEL m.suzuki 2010/02/22 ---------->>>>>
                //case TOOL_BUTTON_SAVE_KEY:  // [保存]
                //    {
                //        #region <Guard Phrase/>

                //        const string TEXT = "保存しますか？";   // LITERAL:
                //        const string CAPTION = "確認";          // LITERAL:
                //        if (!MessageBox.Show(
                //            TEXT, CAPTION,
                //            MessageBoxButtons.YesNo,
                //            MessageBoxIcon.Question).Equals(DialogResult.Yes)
                //        ) break;

                //        if (CurrentChildForm == null) break;

                //        #endregion  // <Guard Phrase/>

                //        if (!CurrentChildForm.Write().Equals((int)ResultCode.Normal))
                //        {
                //            MessageBox.Show(
                //                "保存に失敗しました。", // LITERAL:
                //                "＜セキュリティ管理＞", // LITERAL:
                //                MessageBoxButtons.OK,
                //                MessageBoxIcon.Information
                //            );
                //        }
                //        break;
                //    }
                // --- DEL m.suzuki 2010/02/22 ----------<<<<<
            }
        }

        #endregion  // <ツールバー/>

        #region <タブ/>

        /// <summary>タブのキー配列</summary>
        /// <remarks>タブを追加する場合はここに追加</remarks>
        private readonly string[] _entryTabKeys = new string[]
        {
            // TODO:タブを追加する場合はここに追加
            // --- DEL m.suzuki 2010/02/22 ---------->>>>>
            //TabConfigForRef.SECURITY_MANAGEMENT_SETTING_KEY,
            //TabConfigForRef.SECURITY_MANAGEMENT_VIEW_KEY,
            // --- DEL m.suzuki 2010/02/22 ----------<<<<<
            TabConfigForRef.OPERATION_LOG_VIEW_KEY,
            TabConfigForRef.ERROR_LOG_VIEW_KEY
        };

        /// <summary>タブ構成のマップ</summary>
        private readonly Dictionary<string, TabConfigForRef> _tabConfigMap = new Dictionary<string, TabConfigForRef>();

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
        /// <remarks>
        /// <br>Update Note  : K2016/10/28  時シン</br>
        /// <br>管理番号     : 11202046-00</br>
        /// <br>             : 神姫産業㈱ テキスト出力機能追加対応</br>
        /// </remarks>
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

            // ADD 時シン K2016/10/28 神姫産業㈱ テキスト出力機能追加対応 ---->>>>>
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)mainToolbarsManager.Tools[TOOL_BUTTON_TEXTOUT_KEY];
            // 操作履歴タグ
            if (this.mainTabControl.ActiveTab.Key.Equals(TabConfigForRef.OPERATION_LOG_VIEW_KEY))
            {
                // ボタン活性がある
                if (buttonTool != null)
                {
                    buttonTool.SharedProps.Enabled = true;
                }

            }
            // エラーログ表示タグ
            else
            {
                // ボタン活性がない
                if (buttonTool != null)
                {
                    buttonTool.SharedProps.Enabled = false;
                }
            }
            // ADD 時シン K2016/10/28 神姫産業㈱ テキスト出力機能追加対応 ----<<<<<
        }

        #endregion  // <タブ/>

        #region <Constructor/>

        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Update Note  : K2016/10/28  時シン</br>
        /// <br>管理番号     : 11202046-00</br>
        /// <br>             : 神姫産業㈱ テキスト出力機能追加対応</br>
        /// <br>Update Note  : 2021/12/15  陳艶丹</br>
        /// <br>管理番号     : 11770181-00</br>
        /// <br>             : テキスト出力機能追加と時刻検索条件の追加対応</br>
        /// </remarks>
        public PMKHN09122UA()
        {
            #region <Designer Code/>

            InitializeComponent();

            #endregion  // <Designer Code/>

            // ADD 時シン K2016/10/28 神姫産業㈱ テキスト出力機能追加対応 ---->>>>>
            /* DEL 陳艶丹 2021/12/15 神姫産業㈱オプションの廃止 ----->>>>>
            // テキスト出力ボタンオプション
            ShinkiOperahistoryOpt = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_CPM_ShinkiOperationhistoryCtl);

            //テキスト出力ボタン
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)mainToolbarsManager.Tools[TOOL_BUTTON_TEXTOUT_KEY];
            // 契約済
            // 体験版契約済
            if (ShinkiOperahistoryOpt == PurchaseStatus.Contract || ShinkiOperahistoryOpt == PurchaseStatus.Trial_Contract)
            {
                //画面表示しない
                this.Opacity = 0.0;
                this.ShowInTaskbar = false;

                // テキスト出力ボタンオプションがある場合
                if (buttonTool != null)
                {
                    buttonTool.SharedProps.Visible = true;
                    buttonTool.SharedProps.Enabled = true;
                }
            }
            else
            {
                // テキスト出力ボタンオプションがない場合
                if (buttonTool != null)
                {
                    buttonTool.SharedProps.Visible = false;
                    buttonTool.SharedProps.Enabled = false;
                }

            }
            DEL 陳艶丹 2021/12/15 神姫産業㈱オプションの廃止 -----<<<<<*/

            this.PMKHN09122UCObj = new PMKHN09122UC(); // テキスト出力画面初期化
            // ADD 時シン K2016/10/28 神姫産業㈱ テキスト出力機能追加対応 ----<<<<<
        }

        #endregion  // <Constructor/>

        #region <フォーム/>

        /// <summary>
		/// セキュリティ管理メインフレームのLoadイベントハンドラ
		/// </summary>
		/// <param name="sender">イベントソース</param>
		/// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Update Note  : 時シン K2016/10/28</br>
        /// <br>管理番号     : 11202046-00</br>
        /// <br>             : 神姫産業㈱ 時刻検索条件の追加</br>
        /// <br>Update Note  : 2021/12/15  陳艶丹</br>
        /// <br>管理番号     : 11770181-00</br>
        /// <br>             : テキスト出力機能追加と時刻検索条件の追加対応</br>
        /// </remarks>
        private void PMKHN09122UA_Load(object sender, EventArgs e)
        {
            // 現在のカーソルを保持
            Cursor localCursor = Cursor;
			try
			{
                //----- ADD 時シン K2016/10/28 神姫産業㈱ 時刻検索条件の追加 ----->>>>>
                // ----- DEL 陳艶丹 2021/12/15 神姫産業㈱オプションの廃止 ----->>>>>
                // // 契約済
                // // 体験版契約済
                // if (ShinkiOperahistoryOpt == PurchaseStatus.Contract || ShinkiOperahistoryOpt == PurchaseStatus.Trial_Contract)
                // {
                // ----- DEL 陳艶丹 2021/12/15 神姫産業㈱オプションの廃止 -----<<<<<
                    // XMLファイル読み込み
                    this.Deserialize();
                    string errMessage = string.Format(MSG_START_ERR, CT_XML_FILE);

                    if (this.ExtractionConditionSetObj != null)
                    {
                        /*----- DEL 陳艶丹 2021/12/15 深夜時間帯終了時間チェックの廃止 ----->>>>>
                        // 深夜時間帯終了時間
                        int latenightTimezoneEndHour = 0;
                        int latenightTimezoneEndMinute = 0;
                        int latenightTimezoneEndSecond = 0;
                        string latenightTimezoneEnd = string.Empty;
                        bool isLatenightTimezoneEndOk = this.CheckTime(this.ExtractionConditionSetObj.LatenightTimezoneEnd,
                            out latenightTimezoneEndHour, out latenightTimezoneEndMinute, out latenightTimezoneEndSecond);
                        // 抽出上限
                        int endTimeHour = 0;
                        int endTimeMinute = 0;
                        int endTimeSecond = 0;
                        string endTime = string.Empty;
                        bool isEndTimeOk = this.CheckTime(this.ExtractionConditionSetObj.EndTime, out endTimeHour, out endTimeMinute, out endTimeSecond);

                        if (!isLatenightTimezoneEndOk || !isEndTimeOk)
                        {
                            ShowMessage(errMessage);
                        }
                        else
                        {
                            // 深夜時間帯終了時間:06:00:00～23:59:59の場合、エラーとする
                            if (latenightTimezoneEndHour >= 6 && latenightTimezoneEndHour <= 23 &&
                                latenightTimezoneEndMinute >= 0 && latenightTimezoneEndMinute <= 59 &&
                                latenightTimezoneEndSecond >= 0 && latenightTimezoneEndSecond <= 59)
                            {
                                ShowMessage(errMessage);
                            }
                            else
                            {
                                //画面表示
                                this.Opacity = 1.0;
                                this.ShowInTaskbar = true;
                            }
                        }
                        //----- DEL 陳艶丹 2021/12/15 深夜時間帯終了時間チェックの廃止 -----<<<<<*/
                        //----- ADD 陳艶丹 2021/12/15 深夜時間帯終了時間チェックの廃止 ----->>>>>
                        // 終了時間チェック
                        int endTimeHour = MINTIME;
                        int endTimeMinute = MINTIME;
                        int endTimeSecond = MINTIME;
                        bool isEndTimeOk = this.CheckTime(this.ExtractionConditionSetObj.EndTime, out endTimeHour, out endTimeMinute, out endTimeSecond);
                        if (!isEndTimeOk)
                        {
                            ShowMessage(errMessage);
                        }
                        else
                        {
                            int totalSeconds = endTimeHour * HSEC + endTimeMinute * MSEC + endTimeSecond;
                            if (totalSeconds > INPUTMAXHOUR * HSEC)
                            {
                                ShowMessage(errMessage);
                            }
                            else
                            {
                                //画面表示
                                this.Opacity = 1.0;
                                this.ShowInTaskbar = true;                            
                            }
                        }
                        //----- ADD 陳艶丹 2021/12/15 深夜時間帯終了時間チェックの廃止 -----<<<<<
                    }
                    // ----- DEL 陳艶丹 2021/12/15 神姫産業㈱オプションの廃止 ----->>>>>
                    //else
                    //{
                    //    ShowMessage(errMessage);
                    //}
                    // ----- DEL 陳艶丹 2021/12/15 神姫産業㈱オプションの廃止 -----<<<<<
                //} // DEL 陳艶丹 2021/12/15 神姫産業㈱オプションの廃止
                //----- ADD 時シン K2016/10/28 神姫産業㈱ 時刻検索条件の追加 -----<<<<<

                // カーソルを砂時計に設定
                Cursor = Cursors.WaitCursor;

                // ツールバーを初期化
                InitializeToolbar();

                // タブを初期化
                InitializeTab();

                // --- DEL m.suzuki 2010/02/22 ---------->>>>>
                //// イベントハンドラを追加
                //ISecurityManagementView
                //    viewForm = this._tabConfigMap[TabConfigForRef.SECURITY_MANAGEMENT_VIEW_KEY].Form
                //        as ISecurityManagementView;
                //if (viewForm != null)
                //{
                //    viewForm.Selected += new GridSelectedEventHandler(this.SecurityManagementViewGridSelected);
                //}

                //IStatusBarShowable settingForm = this._tabConfigMap[TabConfigForRef.SECURITY_MANAGEMENT_SETTING_KEY].Form
                //        as IStatusBarShowable;
                //if (settingForm != null)
                //{
                //    settingForm.ShowStatusBar += new ValueIsInvalidEventHandler(this.ShowStatusBar);
                //}
                // --- DEL m.suzuki 2010/02/22 ----------<<<<<
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
        private void PMKHN09122UA_KeyDown(object sender, KeyEventArgs e)
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
        // --- DEL m.suzuki 2010/02/22 ---------->>>>>
        ///// <summary>
        ///// 操作権限一覧表示のグリッドが選択されたときのイベントハンドラ
        ///// </summary>
        ///// <param name="sender">グリッドの親オブジェクト</param>
        ///// <param name="operationSt">選択された行に対するオペレーション情報</param>
        //private void SecurityManagementViewGridSelected(
        //    object sender,
        //    OperationSt operationSt
        //)
        //{
        //    ISecurityManagementSetting
        //        settingForm = this._tabConfigMap[TabConfigForRef.SECURITY_MANAGEMENT_SETTING_KEY].Form
        //            as ISecurityManagementSetting;
        //    if (settingForm == null) return;

        //    this.mainTabControl.SelectedTab = this.mainTabControl.Tabs[TabConfigForRef.SECURITY_MANAGEMENT_SETTING_KEY];

        //    settingForm.Select(operationSt);
        //}
        // --- DEL m.suzuki 2010/02/22 ----------<<<<<
        #endregion  // <操作権限一覧表示のグリッドが選択されたときのイベント/>

        #region <ツールバーの構築/>

        /// <summary>
        /// ツールバーを初期化します。
        /// </summary>
        /// <remarks>
        /// <br>Update Note  : K2016/10/28  時シン</br>
        /// <br>管理番号     : 11202046-00</br>
        /// <br>             : 神姫産業㈱ テキスト出力機能追加対応</br>
        /// </remarks>
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

            // ADD 時シン K2016/10/28 神姫産業㈱ テキスト出力機能追加対応 ---->>>>>
            // テキスト出力ボタンのアイコン設定
            TextOutToolButton.SharedProps.AppearancesSmall.Appearance.Image = TOOL_BUTTON_TEXTOUT_ICON_INDEX;
            // ADD 時シン K2016/10/28 神姫産業㈱ テキスト出力機能追加対応 ----<<<<<
        }

        #endregion  // <ツールバーの構築/>

        #region <タブの構築/>

        /// <summary>
        /// タブを初期化します。
        /// </summary>
        private void InitializeTab()
        {
            // タブにイメージリストを設定
            this.mainTabControl.ImageList = TabConfigForRef.ImageList;

            this._tabConfigMap.Clear();
            foreach (string tabKey in this._entryTabKeys)
            {
                // タブ構成マップを構築
                this._tabConfigMap.Add(tabKey, TabConfigForRef.CreateInstance(tabKey));

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
        /// <remarks>
        /// <br>Update Note  : 時シン K2016/10/28</br>
        /// <br>管理番号     : 11202046-00</br>
        /// <br>             : 神姫産業㈱ 時刻検索条件の追加</br>
        /// <br>Update Note  : 2021/12/15  陳艶丹</br>
        /// <br>管理番号     : 11770181-00</br>
        /// <br>             : テキスト出力機能追加と時刻検索条件の追加対応</br>
        /// </remarks>
        private void AddChildFormToTab(TabConfigForRef config)
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

            //----- ADD 時シン K2016/10/28 神姫産業㈱ 時刻検索条件の追加 ----->>>>>
            //----- DEL 陳艶丹 2021/12/15 神姫産業㈱オプションの廃止 ----->>>>>
            // 契約済
            // 体験版契約済
            // if (ShinkiOperahistoryOpt == PurchaseStatus.Contract || ShinkiOperahistoryOpt == PurchaseStatus.Trial_Contract)
            // {
            //----- DEL 陳艶丹 2021/12/15 神姫産業㈱オプションの廃止 -----<<<<<
            // 操作履歴表示タブの場合
            if (config.Key.Equals(TabConfigForRef.OPERATION_LOG_VIEW_KEY))
            {
                if (config.Form is IDoTextOutForm)
                {
                    ((IDoTextOutForm)config.Form).TransferSettingInfo(true, this.ExtractionConditionSetObj);
                }
            }
            // } // DEL 陳艶丹 2021/12/15 神姫産業㈱オプションの廃止
            //----- ADD 時シン K2016/10/28 神姫産業㈱ 時刻検索条件の追加 -----<<<<<
            config.Form.Show();
        }

        //----- ADD 時シン K2016/10/28 神姫産業㈱ 時刻検索条件の追加 ----->>>>>
        /// <summary>
        /// XMLファイルから読み込む処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : XMLファイルから読み込む処理。</br>
        /// <br>Programmer : 時シン</br>
        /// <br>Date       : K2016/10/28</br>
        /// </remarks>
        private void Deserialize()
        {
            if (UserSettingController.ExistUserSetting(Path.Combine(ConstantManagement_ClientDirectory.UISettings, CT_XML_FILE)))
            {
                try
                {
                    this.ExtractionConditionSetObj = UserSettingController.DeserializeUserSetting<ExtractionConditionSet>(Path.Combine(ConstantManagement_ClientDirectory.UISettings, CT_XML_FILE));
                }
                catch
                {
                    this.ExtractionConditionSetObj = null;
                }
            }
        }

        /// <summary>
        /// 時刻のチェック
        /// </summary>
        /// <param name="inputTime">入力の時刻（XX:XX:XX）</param>
        /// <param name="hour">戻る時刻（時）</param>
        /// <param name="minute">戻る時刻（分）</param>
        /// <param name="second">戻る時刻（秒）</param>
        /// <returns>チェック結果（True:OK False:NG）</returns>
        /// <remarks>
        /// <br>Note       : 時刻のチェックを行う。</br>
        /// <br>Programmer : 時シン</br>
        /// <br>Date       : K2016/10/28</br>
        /// </remarks>
        private bool CheckTime(string inputTime, out int hour, out int minute, out int second)
        {
            bool isOK = false;
            hour = 0;
            minute = 0;
            second = 0;

            if (!string.IsNullOrEmpty(inputTime))
            {
                string[] time = inputTime.Split(new char[] { ':' });
                if (time != null && time.Length == 3)
                {
                    string hourStr = time[0];
                    string minuteStr = time[1];
                    string secondStr = time[2];

                    // 時のチェック
                    isOK = CheckTime(hourStr, 0, out hour);
                    // 分のチェック
                    if (isOK)
                    {
                        isOK = CheckTime(minuteStr, 1, out minute);
                    }
                    // 秒のチェック
                    if (isOK)
                    {
                        isOK = CheckTime(secondStr, 2, out second);
                    }
                }
            }

            return isOK;
        }

        /// <summary>
        /// 時刻のチェック
        /// </summary>
        /// <param name="timeStr">入力の時刻(時/分/秒)</param>
        /// <param name="mode">モード（0:時 1:分 2:秒）</param>
        /// <param name="timeInt">戻る時刻(時/分/秒)</param>
        /// <returns>チェック結果（True:OK False:NG）</returns>
        /// <remarks>
        /// <br>Note       : 時刻のチェックを行う。</br>
        /// <br>Programmer : 時シン</br>
        /// <br>Date       : K2016/10/28</br>
        /// </remarks>
        private bool CheckTime(string timeStr, int mode, out int timeInt)
        {
            bool isOK = false;
            timeInt = 0;

            if (string.IsNullOrEmpty(timeStr.Trim()))
            {
                isOK = true;
            }
            else
            {
                switch (mode)
                {
                    case 0: // 時のチェック
                        if (int.TryParse(timeStr, out timeInt))
                        {
                            // --- UPD テキスト出力機能追加と時刻検索条件の追加対応 ----->>>>>
                            //if (timeInt >= 0 && timeInt <= 23)
                            if (timeInt >= MINTIME && timeInt <= INPUTMAXHOUR)
                            // --- UPD テキスト出力機能追加と時刻検索条件の追加対応 -----<<<<<
                            {
                                isOK = true;
                            }
                        }
                        break;
                    case 1: // 分のチェック
                    case 2: // 秒のチェック
                        if (int.TryParse(timeStr, out timeInt))
                        {
                            if (timeInt >= 0 && timeInt <= 59)
                            {
                                isOK = true;
                            }
                        }
                        break;
                    default:
                        isOK = false;
                        break;
                }
            }

            return isOK;
        }

        /// <summary>
        /// エラーメッセージの表示と画面の終了
        /// </summary>
        /// <param name="errMessage">エラーメッセージ</param>
        /// <remarks>
        /// <br>Note       : エラーメッセージの表示と画面の終了を行う。</br>
        /// <br>Programmer : 時シン</br>
        /// <br>Date       : K2016/10/28</br>
        /// </remarks>
        private void ShowMessage(string errMessage)
        {
            TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION, PROGRAM_ID, errMessage, ERROR_STATUS, MessageBoxButtons.OK);

            //画面表示しない
            this.Opacity = 0.0;
            this.ShowInTaskbar = false;

            //exit
            System.Windows.Forms.Application.Exit();
        }
        //----- ADD K2016/10/28 時シン 神姫産業㈱ 時刻検索条件の追加 -----<<<<<

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
//****************************************************************************//
// システム         : 回答送信処理
// プログラム名称   : 回答送信処理の画面
// プログラム概要   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 杉村 利彦
// 作 成 日  2006/10/10  修正内容 : 新規作成：ＴＳＰ送受信処理【ＰＭ側】(SFMIT02850U)
// 管理番号              作成担当 : 工藤 恵優
// 作 成 日  2009/05/29  修正内容 : SCM用にアレンジ
// 管理番号              作成担当 : 工藤 恵優
// 作 成 日  2010/03/30  修正内容 : 送信中画面の表示処理を再実装
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 21112 久保田 誠
// 作 成 日  2011/06/01  修正内容 : ログ表示ボタンの表示制御追加
//                                  ログ表示方法の変更(メモ帳 → ログ表示画面)
//                                  設定ボタンの非表示(機能未実装の為)
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 三戸　伸悟
// 作 成 日  2012/12/05  修正内容 : 2012/12/99配信 SCM障害№10442対応 送信ボタン表示制御、単体起動時ログ修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 吉岡
// 作 成 日  2013/08/28  修正内容 : タブレットからの売上登録時、"送信中"ウィンドウを非表示にする
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30744 湯上 千加子
// 作 成 日  2014/04/09  修正内容 : SCM仕掛一覧№10641対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 31065 豊沢 憲弘
// 作 成 日  2014/11/26  修正内容 : SCM仕掛一覧№10707対応
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;

using Broadleaf.Application.Controller;
using Broadleaf.Application.Controller.Agent;
using Broadleaf.Application.Controller.Util;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using System.Runtime.InteropServices;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 送信処理(伝票表示)フォーム
    /// </summary>
    public partial class PMSCM01101UA : Form
    {
        #region API定義
        [DllImport("User32.dll", EntryPoint = "SendMessage")]
        static extern uint SendMessage(IntPtr window, int msg, IntPtr wParam, ref COPYDATASTRUCT lParam);

        public const Int32 WM_COPYDATA = 0x4A;
        public const Int32 WM_USER = 0x400;

        //COPYDATASTRUCT構造体 
        struct COPYDATASTRUCT
        {
            public IntPtr dwData;
            public UInt32 cbData;
            public string lpData;
        }
        #endregion 
        // ADD 2013/08/28 吉岡 タブレット 送信中ウィンドウ非表示 ---------->>>>>>>>>>
        private string cmdLineTablet = string.Empty;
        // ADD 2013/08/28 吉岡 タブレット 送信中ウィンドウ非表示 ----------<<<<<<<<<<

        // ADD 2010/03/30 送信中画面の表示処理を再実装 ---------->>>>>
        #region 送信中画面

        /// <summary>
        /// 送信中画面
        /// （表示および閉じる際はそれぞれ<c>ShowingNowSendingForm()</c>および<c>CloseNowSendingForm()</c>を使用して下さい）
        /// </summary>
        private PMSCM01104UA _nowSendingForm;
        /// <summary>
        /// 送信中画面を取得します。
        /// （表示および閉じる際はそれぞれ<c>ShowingNowSendingForm()</c>および<c>CloseNowSendingForm()</c>を使用して下さい）
        /// </summary>
        private PMSCM01104UA NowSendingForm
        {
            get
            {
                if (_nowSendingForm == null)
                {
                    _nowSendingForm = new PMSCM01104UA();
                    _nowSendingForm.Title = "送信処理";
                    _nowSendingForm.Message = "データを送信しています";
                }
                return _nowSendingForm;
            }
            set { _nowSendingForm = value; }
        }

        /// <summary>送信中画面表示中フラグ</summary>
        private bool _showingNowSendingForm;
        /// <summary>送信中画面表示中フラグを取得または設定します。</summary>
        private bool ShowingNowSendingForm
        {
            get { return _showingNowSendingForm; }
            set { _showingNowSendingForm = value; }
        }

        /// <summary>
        /// 送信中画面を表示します。
        /// </summary>
        private void ShowNowSendingForm()
        {
            if (ShowingNowSendingForm) return;

            ShowingNowSendingForm = true;
            // ADD 2013/08/28 吉岡 タブレット 送信中ウィンドウ非表示 ---------->>>>>>>>>>
            // タブレットの場合は"送信中…"のウインドウを表示しない
            if (this.cmdLineTablet == SCMSendController.CMD_LINE_FOR_PMSCM01100_TABLET) return;
            // ADD 2013/08/28 吉岡 タブレット 送信中ウィンドウ非表示 ----------<<<<<<<<<<
            NowSendingForm.Show(this);
        }

        /// <summary>
        /// 送信中画面を閉じます。
        /// </summary>
        private void CloseNowSendingForm()
        {
            ShowingNowSendingForm = false;

            if (NowSendingForm != null)
            {
                NowSendingForm.Close();
                NowSendingForm = null;
            }
        }

        #endregion // 送信中画面
        // ADD 2010/03/30 送信中画面の表示処理を再実装 ----------<<<<<

        #region <回答送信処理>

        /// <summary>回答送信処理</summary>
        private readonly SCMSendController _scmController;
        /// <summary>回答送信処理を取得します。</summary>
        private SCMSendController SCMController { get { return _scmController; } }

        // --- ADD 2012/12/05 三戸 2012/12/99配信分 SCM障害№10442 --------->>>>>>>>>>>>>>>>>>>>>>>>
        private string mode = "(単体起動モード)";
        // --- ADD 2012/12/05 三戸 2012/12/99配信分 SCM障害№10442 ---------<<<<<<<<<<<<<<<<<<<<<<<<

        /// <summary>
        /// バッチ処理(送信起動モード)であるか判断します。
        /// </summary>
        /// <value>
        /// <c>true</c> :バッチ処理(送信起動モード)です。<br/>
        /// <c>false</c>:対話処理(単体起動モード)です。
        /// </value>
        public bool IsBatchMode
        {
            get { return SCMController.IsBatchMode; }
        }

        #endregion // </回答送信処理>

        #region <送信処理(明細表示)画面>

        /// <summary>送信処理(明細表示)画面</summary>
        private PMSCM01101UB _detailRecordForm;
        /// <summary>送信処理(明細表示)画面を取得します。</summary>
        private PMSCM01101UB DetailRecordForm
        {
            get
            {
                if (_detailRecordForm == null)
                {
                    _detailRecordForm = new PMSCM01101UB(SCMController);
                }
                return _detailRecordForm;
            }
        }

        #endregion // </送信処理(明細表示)画面>

        #region <Constructor>

        /// <summary>
        /// カスタムコンストラクタ
        /// </summary>
        /// <param name="scmController">回答送信処理</param>
        public PMSCM01101UA(SCMSendController scmController)
        {
            #region <Designer Code>

            InitializeComponent();

            #endregion // </Designer Code>

            _scmController = scmController;

            // ADD 2013/08/28 吉岡 タブレット 送信中ウィンドウ非表示 ---------->>>>>>>>>>
            this.cmdLineTablet = string.Empty;
            this.cmdLineTablet = scmController.CmdLineTablet;
            // ADD 2013/08/28 吉岡 タブレット 送信中ウィンドウ非表示 ----------<<<<<<<<<<

            // ADD 2010/03/30 送信中画面の表示処理を再実装 ---------->>>>>
            if (_scmController.IsBatchMode)
            {
                ShowNowSendingForm();
            }
            // ADD 2010/03/30 送信中画面の表示処理を再実装 ---------->>>>>
        }

        #endregion // </Constructor>

        #region <初期化>

        /// <summary>
        /// 回答送信処理フォームのLoadイベントハンドラ
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        private void PMSCM01101UA_Load(object sender, EventArgs e)
        {
            // アイコンリソース管理クラスを使用して、アイコンを表示
            // ツールボタン
            this.myToolbar.ImageListSmall = IconResourceManagement.ImageList24;
            this.myToolbar.Tools["exit"].SharedProps.AppearancesSmall.Appearance.Image = Size24_Index.CLOSE;
            this.myToolbar.Tools["send"].SharedProps.AppearancesSmall.Appearance.Image = Size24_Index.DEMANDPROP;
            this.myToolbar.Tools["detail"].SharedProps.AppearancesSmall.Appearance.Image = Size24_Index.MODIFY;
            this.myToolbar.Tools["delete"].SharedProps.AppearancesSmall.Appearance.Image = Size24_Index.DELETE;
            this.myToolbar.Tools["log"].SharedProps.AppearancesSmall.Appearance.Image = Size24_Index.AMBIGUOUSSEARCH;
            this.myToolbar.Tools["setting"].SharedProps.AppearancesSmall.Appearance.Image = Size24_Index.SETUP1;
            // ツールボタンを無効にする
            this.myToolbar.Tools["exit"].SharedProps.Enabled = false;
            this.myToolbar.Tools["send"].SharedProps.Enabled = false;
            this.myToolbar.Tools["log"].SharedProps.Enabled = false;
            this.myToolbar.Tools["setting"].SharedProps.Enabled = false;
            this.myToolbar.Tools["detail"].SharedProps.Enabled = false;
            this.myToolbar.Tools["delete"].SharedProps.Enabled = false;
            this.myToolbar.Tools["filter"].SharedProps.Enabled = false;

            Infragistics.Win.UltraWinToolbars.ComboBoxTool combo = (Infragistics.Win.UltraWinToolbars.ComboBoxTool)this.myToolbar.Tools.GetItem(this.myToolbar.Tools.IndexOf("filter"));
            combo.SelectedIndex = 0;

            // 情報部
            this.Stat0Cnt_label.Text = "0件";
            this.Stat1Cnt_label.Text = "0件";
            this.Stat2Cnt_label.Text = "0件";
            this.lblLastDate.Text = "--/--/-- --:--:--";

            this.myToolbar.Tools["log"].SharedProps.Visible = this.SCMController.SettingInfo.LogDisplay == 1;  //ADD 2011/06/01

            // --- ADD 2012/12/05 三戸 2012/12/99配信分 SCM障害№10442 --------->>>>>>>>>>>>>>>>>>>>>>>>
            // UPD 2014/04/09 SCM仕掛一覧№10641対応 ------------------------------------------>>>>>
            //this.myToolbar.Tools["send"].SharedProps.Visible = this.SCMController.SendDisplay;
            if (this.SCMController.SendDisplay && this.SCMController.SettingInfo.AloneStartSend == 1)
            {
                this.myToolbar.Tools["send"].SharedProps.Visible = true;
            }
            else
            {
                this.myToolbar.Tools["send"].SharedProps.Visible = false;
            }
            // UPD 2014/04/09 SCM仕掛一覧№10641対応 ------------------------------------------<<<<<
            // --- ADD 2012/12/05 三戸 2012/12/99配信分 SCM障害№10442 ---------<<<<<<<<<<<<<<<<<<<<<<<<

            // タイマー ON
            this.initializeTimer.Enabled = true;
        }

        /// <summary>
        /// 初期化タイマーのTickイベントハンドラ
        /// </summary>
        /// <remarks>
        /// 起動後処理
        /// </remarks>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        private void initializeTimer_Tick(object sender, EventArgs e)
        {
            const string MY_NAME= "PMSCM01101UA";
            const string METHOD = "initializeTimer_Tick";

            // タイマー OFF
            this.initializeTimer.Enabled = false;

            // FIXME:PM7用送信起動モードの仕様変更…メッセージボックス表示の無効化と中断処理

            // 送信データフォルダ
            if (string.IsNullOrEmpty(SCMController.SettingInfo.SCMDataPath))
            {
                if (!SCMController.IsBatchMode)
                {
                    MessageBox.Show("送信フォルダが設定されていません。\n送信フォルダの設定を行ってください。");
                }
                else
                {
                    // UNDONE:ログ出力？
                    this.Close();
                }
                // ツールボタンを無効にする
                this.myToolbar.Tools["exit"].SharedProps.Enabled = true;
                this.myToolbar.Tools["setting"].SharedProps.Enabled = true;
                return;
            }
            if (!Directory.Exists(SCMController.SettingInfo.SCMDataPath))
            {
                if (!SCMController.IsBatchMode)
                {
                    MessageBox.Show("送信フォルダが存在しません。\n送信フォルダの設定を行ってください。");
                }
                else
                {
                    // UNDONE:ログ出力？
                    this.Close();
                }
                //SCMController.WriteLog("処理中断\r\n");
                //SCMController.CloseLog();
                // ツールボタンを無効にする
                this.myToolbar.Tools["exit"].SharedProps.Enabled = true;
                this.myToolbar.Tools["setting"].SharedProps.Enabled = true;
                return;
            }

            // ログを開始
            // UPD 2014/04/09 SCM仕掛一覧№10641対応 --------------------------------------->>>>>
            //if (SCMController.OpenLog().Equals((int)ResultUtil.ResultCode.Error))
            if (SCMController.IsBatchMode && SCMController.OpenLog().Equals((int)ResultUtil.ResultCode.Error))
            // UPD 2014/04/09 SCM仕掛一覧№10641対応 ---------------------------------------<<<<<
            {
                if (!SCMController.IsBatchMode)
                {
                    MessageBox.Show("他の端末で送信中の為読込みできませんでした。");
                }
                else
                {
                    // UNDONE:ログ出力？
                    // ADD 2014/04/09 SCM仕掛一覧№10641対応 --------------------------------------------------------------------->>>>>
                    // メッセージ表示・ログ出力
                    string msg = string.Empty;
                    string commentSlipNumber = string.Empty;
                    if (SCMController.SalesSlipNumList != null && SCMController.SalesSlipNumList.Count != 0)
                    {
                        for (int i = 0; i < SCMController.SalesSlipNumList.Count; i++)
                        {
                            if (i != 0) commentSlipNumber = commentSlipNumber + ",";
                            commentSlipNumber = commentSlipNumber + SCMController.SalesSlipNumList[i];
                        }
                        msg = "他の端末で送信中の為送信できませんでした。" + Environment.NewLine +
                                        "売上伝票番号【" + commentSlipNumber + "】";
                        MessageBox.Show(msg, "回答送信処理", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        SimpleLogger.WriteSlipNumLog(SCMController.SettingInfo.SCMDataPath, msg);
                    }
                    else if (SCMController.InquiryNumber != 0)
                    {
                        commentSlipNumber = SCMController.InquiryNumber.ToString();
                        msg = "他の端末で送信中の為送信できませんでした。" + Environment.NewLine +
                                        "問合せ番号【" + commentSlipNumber + "】";
                        MessageBox.Show(msg, "回答送信処理", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        SimpleLogger.WriteSlipNumLog(SCMController.SettingInfo.SCMDataPath, msg);
                    }
                    // SCM受注データ更新(未送信状態解除）
                    UpdateSCMData();
                    // ADD 2014/04/09 SCM仕掛一覧№10641対応 ---------------------------------------------------------------------<<<<<
                    this.Close();
                }
                // ツールボタンを無効にする
                this.myToolbar.Tools["exit"].SharedProps.Enabled = true;
                return;
            }
            // --- UPD 2012/12/05 三戸 2012/12/99配信分 SCM障害№10442 --------->>>>>>>>>>>>>>>>>>>>>>>>
            //SCMController.WriteLog("回答送信処理起動");
            //SimpleLogger.WriteDebugLog(MY_NAME, METHOD, "回答送信処理起動");
            if (SCMController.IsBatchMode) mode = ""; //単体起動じゃない場合、モードクリア
            SCMController.WriteLog("回答送信処理起動" + mode);
            SimpleLogger.WriteDebugLog(MY_NAME, METHOD, "回答送信処理起動" + mode);
            // --- UPD 2012/12/05 三戸 2012/12/99配信分 SCM障害№10442 ---------<<<<<<<<<<<<<<<<<<<<<<<<
            
            try
            {
                SimpleLogger.WriteDebugLog(MY_NAME, METHOD, "\t得意先グリッドのソースを設定中…");
                // 送信先得意先リスト
                this.sendingCustomerGrid.DataSource = SCMController.SendingCustomerTable.DefaultView;
                SimpleLogger.WriteDebugLog(MY_NAME, METHOD, "\t得意先グリッドのソースを設定完了");

                SimpleLogger.WriteDebugLog(MY_NAME, METHOD, "\t送信データグリッドのソースを設定中…");
                // 送信データを検索
                this.sendingAnswerGrid.DataSource = SCMController.SendingHeaderTable.DefaultView;
                SimpleLogger.WriteDebugLog(MY_NAME, METHOD, "\t送信データグリッドのソースを設定完了");

                // ツールボタンを有効にする
                this.myToolbar.Tools["exit"].SharedProps.Enabled = true;
                this.myToolbar.Tools["send"].SharedProps.Enabled = true;
                this.myToolbar.Tools["log"].SharedProps.Enabled = true;
                this.myToolbar.Tools["setting"].SharedProps.Enabled = true;
                this.myToolbar.Tools["filter"].SharedProps.Enabled = true;

                // ツールボタンを無効にする
                this.myToolbar.Tools["detail"].SharedProps.Enabled = false;
                this.myToolbar.Tools["delete"].SharedProps.Enabled = false;

                // 得意先をフィルタリング(オンライン種別区分が"SCM"を表示対象とする)
                string customerFilter = SCMController.SendingCustomerTable.OnlineKindDivColumn.ColumnName + "=" + ((int)CustomerAgent.OnlineKindDiv.SCM).ToString();
                this.SCMController.SendingCustomerTable.DefaultView.RowFilter = customerFilter;
                if (this.sendingCustomerGrid.Rows.Count > 0)
                {
                    this.sendingCustomerGrid.Rows[0].Selected = true;
                }
            }
            catch (SCMFileOpeningException ex)
            {
                Debug.WriteLine(ex.ToString());

                if (!SCMController.IsBatchMode)
                {
                    MessageBox.Show("回答データが作成中です。", "回答送信処理", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                if (SCMController != null)
                {
                    SCMController.WriteLog("回答データが作成中です。起動を中断しました。");
                    SCMController.CloseLog();
                }
                this.Close();
            }
            // ADD 2014/11/26 k.toyosawa SCM仕掛一覧№10707対応 --->>>>>>
            catch (Exception exception)
            {
                if (SCMController != null)
                {
                    SCMController.WriteLog(exception.ToString());
                    SCMController.CloseLog();
                }
                this.Close();
            }
            // ADD 2014/11/26 k.toyosawa SCM仕掛一覧№10707対応 ---<<<<<<

            // 送信起動モードの場合
            // アイコンのみを表示→送信処理→終了
            if (SCMController.IsBatchMode)
            {
                this.Visible = false;
                this.Refresh();
                OnClickSendToolButton();
                this.Close();
            }
            else
            {
                // 伝票枚数表示
                SlipCountRefresh();

                this.Visible = true;
                this.WindowState = FormWindowState.Normal;
            }
        }

        #endregion // </初期化>

        #region <得意先>

        /// <summary>
        /// 得意先グリッドのInitializeLayoutイベントハンドラ
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントハンドラ</param>
        private void sendingCustomerGrid_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            Infragistics.Win.UltraWinGrid.UltraGrid grid = sendingCustomerGrid;
            // バンドを取得
            Infragistics.Win.UltraWinGrid.UltraGridBand band = grid.DisplayLayout.Bands[0];

            // 列幅自動調整
            grid.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.None;

            // カラムのキー
            string codeColumnKey= SCMController.SendingCustomerTable.CustomerCodeColumn.ColumnName; // 得意先コード
            string nameColumnKey= SCMController.SendingCustomerTable.CustomerNameColumn.ColumnName; // 得意先名称
            string divColumnKey = SCMController.SendingCustomerTable.OnlineKindDivColumn.ColumnName;// オンライン種別区分

            // 列の表示／非表示
            band.Columns[divColumnKey].Hidden = true;   // オンライン種別区分

            // 幅
            band.Columns[codeColumnKey].Width = 160;    // 得意先コード
            band.Columns[nameColumnKey].Width = 280;	// 得意先名称
            // 表示順
            band.Columns[codeColumnKey].Header.VisiblePosition = 0;	// 得意先コード
            band.Columns[nameColumnKey].Header.VisiblePosition = 1;	// 得意先名称
            // 表示位置
            band.Columns[codeColumnKey].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;   // 得意先コード
            band.Columns[nameColumnKey].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;	// 得意先名称
        }

        /// <summary>
        /// 得意先グリッドのAfterRowActivateイベントハンドラ
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        private void sendingCustomerGrid_AfterRowActivate(object sender, EventArgs e)
        {
            #region <Guard Phrase>

            if (this.sendingCustomerGrid.ActiveRow == null) return;

            #endregion // </Guard Phrase>

            FilterSendingAnswerGridByCustomerCode();
        }

        /// <summary>
        /// 送信伝票リストグリッドを得意先コードでフィルタリングします。
        /// </summary>
        private void FilterSendingAnswerGridByCustomerCode()
        {
            #region <Guard Phrase>

            if (this.sendingCustomerGrid.ActiveRow == null) return;

            #endregion // </Guard Phrase>

            string customerCodeKey = SCMController.SendingCustomerTable.CustomerCodeColumn.ColumnName;
            int currentCustomerCode = (int)this.sendingCustomerGrid.ActiveRow.Cells[customerCodeKey].Value;
            string answerFilter = SCMController.SendingHeaderTable.CustomerCodeColumn.ColumnName + "=" + currentCustomerCode.ToString();
            SCMController.SendingHeaderTable.DefaultView.RowFilter = answerFilter;
        }

        #endregion // </得意先>

        #region <送信伝票リスト>

        #region <初期化>

        /// <summary>
        /// 送信伝票リストグリッドのInitializeLayoutイベントハンドラ
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        private void sendingAnswerGrid_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            Infragistics.Win.UltraWinGrid.UltraGrid grid = this.sendingAnswerGrid;

            // バンドを取得
            Infragistics.Win.UltraWinGrid.UltraGridBand band = grid.DisplayLayout.Bands[0];

            // 列幅自動調整
            grid.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.None;

            // カラムのキー
            string idKey                = SCMController.SendingHeaderTable.IDColumn.ColumnName;             // ID
            string sendStatusKey = SCMController.SendingHeaderTable.SendStatusColumn.ColumnName;    // 通信状態
            string inquiryNumberKey     = SCMController.SendingHeaderTable.InquiryNumberColumn.ColumnName;  // 問合せ番号
            string acptAnOdrStatusKey   = SCMController.SendingHeaderTable.AcptAnOdrStatusColumn.ColumnName;// 受注ステータス
            string slipTypeNameKey      = SCMController.SendingHeaderTable.SlipTypeNameColumn.ColumnName;   // 伝票種別
            string salesSlipNumKey      = SCMController.SendingHeaderTable.SalesSlipNumColumn.ColumnName;   // 伝票番号
            string salesDateKey         = SCMController.SendingHeaderTable.SalesDateColumn.ColumnName;      // 受注日
            string salesTotalKey        = SCMController.SendingHeaderTable.SalesTotalColumn.ColumnName;     // 合計金額
            string inqOrdNoteKey        = SCMController.SendingHeaderTable.InqOrdNoteColumn.ColumnName;     // 備考
            string customerCodeKey      = SCMController.SendingHeaderTable.CustomerCodeColumn.ColumnName;   // 得意先コード

            // 列の表示／非表示
            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn column in band.Columns)
            {
                // 一度全て非表示にする
                column.Hidden = true;
            }

            // 表示項目
            band.Columns[sendStatusKey].Hidden = false;    // 通信状態
            band.Columns[inquiryNumberKey].Hidden = false;	// 問合せ番号
            band.Columns[slipTypeNameKey].Hidden = false;	// 伝票種別
            band.Columns[salesSlipNumKey].Hidden = false;	// 伝票番号
            band.Columns[salesDateKey].Hidden = false;	// 受注日
            band.Columns[salesTotalKey].Hidden = false;	// 合計金額
            band.Columns[inqOrdNoteKey].Hidden = false;	// 備考

            // 表示順
            band.Columns[sendStatusKey].Header.VisiblePosition = 0;    // 通信状態
            band.Columns[inquiryNumberKey].Header.VisiblePosition   = 1;	// 問合せ番号
            band.Columns[slipTypeNameKey].Header.VisiblePosition    = 2;	// 伝票種別
            band.Columns[salesSlipNumKey].Header.VisiblePosition    = 3;	// 伝票番号
            band.Columns[salesDateKey].Header.VisiblePosition       = 4;	// 受注日
            band.Columns[salesTotalKey].Header.VisiblePosition      = 5;	// 合計金額
            band.Columns[inqOrdNoteKey].Header.VisiblePosition      = 6;	// 備考

            // 幅
            band.Columns[sendStatusKey].Width = 70;	// 通信状態
            band.Columns[inquiryNumberKey].Width= 90;	// 問合せ番号
            band.Columns[slipTypeNameKey].Width = 70;   // 伝票種別
            band.Columns[salesSlipNumKey].Width = 100;	// 伝票番号
            band.Columns[salesDateKey].Width    = 90;	// 受注日
            band.Columns[salesTotalKey].Width   = 80;	// 合計金額
            band.Columns[inqOrdNoteKey].Width   = 300;  // 備考

            // 書式
            band.Columns[salesDateKey].Format = "yyyy/MM/dd";
            band.Columns[salesTotalKey].Format = "#,##0;-#,##0;";	// 合計金額

            // 表示位置
            band.Columns[sendStatusKey].CellAppearance.TextHAlign   = Infragistics.Win.HAlign.Center;	// 通信状態
            band.Columns[inquiryNumberKey].CellAppearance.TextHAlign= Infragistics.Win.HAlign.Right;	// 問合せ番号
            band.Columns[slipTypeNameKey].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;	    // 伝票種別
            band.Columns[salesSlipNumKey].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;	    // 伝票番号
            band.Columns[salesDateKey].CellAppearance.TextHAlign    = Infragistics.Win.HAlign.Left;	    // 受注日
            band.Columns[salesTotalKey].CellAppearance.TextHAlign   = Infragistics.Win.HAlign.Right;	// 合計金額
            band.Columns[inqOrdNoteKey].CellAppearance.TextHAlign   = Infragistics.Win.HAlign.Left;	    // 備考
            
            // キー動作マッピングを追加
            grid.KeyActionMappings.Add(
                new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
                    Keys.Enter,	// Enterキー
                    Infragistics.Win.UltraWinGrid.UltraGridAction.NextCellByTab,
                    0,
                    Infragistics.Win.UltraWinGrid.UltraGridState.Cell,
                    Infragistics.Win.SpecialKeys.All,
                    0
                )
            );
        }

        #endregion // </初期化>

        #region <ツールバー制御>

        /// <summary>
        /// 送信伝票リストグリッドのEnterイベントハンドラ
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        private void sendingAnswerGrid_Enter(object sender, EventArgs e)
        {
            if (!this.myToolbar.Tools["send"].SharedProps.Enabled)
            {
                // ツールボタンを無効にする
                this.myToolbar.Tools["detail"].SharedProps.Enabled = false;
                this.myToolbar.Tools["delete"].SharedProps.Enabled = false;
            }
            else
            {
                // ツールボタンを有効にする
                this.myToolbar.Tools["detail"].SharedProps.Enabled = true;
                this.myToolbar.Tools["delete"].SharedProps.Enabled = true;
            }
        }

        /// <summary>
        /// 送信伝票リストグリッドのleaveイベントハンドラ
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        private void sendingAnswerGrid_Leave(object sender, EventArgs e)
        {
            // ツールボタンを無効にする
            this.myToolbar.Tools["detail"].SharedProps.Enabled = false;
            this.myToolbar.Tools["delete"].SharedProps.Enabled = false;
        }

        #endregion // </ツールバー制御>

        /// <summary>
        /// 送信伝票リストグリッドのDblClickイベントハンドラ
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        private void sendingAnswerGrid_DblClick(object sender, Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs e)
        {
            #region <Guard Phrase>

            if (e.Row == null) return;
            if (this.sendingAnswerGrid.ActiveRow == null) return;

            #endregion // </Guard Phrase>

            OnClickDetailToolButton();
        }

        #endregion // </送信伝票リスト>

        #region <ツールバー>

        /// <summary>
        /// ツールバーのToolClickイベントハンドラ
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        private void myToolbar_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                case "exit":    // 終了
                    OnClickExitToolButton();    break;

                case "detail":	// 詳細
                    OnClickDetailToolButton();  break;

                case "delete":	// 削除
                    OnClickDeleteToolButton();  break;

                case "send":    // 送信
                    OnClickSendToolButton(); break;

                case "log":	    // ログ表示
                    OnClickShowLogToolButton(); break;

                case "setting": // 設定
                    OnClickSettingToolButton(); break;
            }
        }

        #endregion </ツールバー>

        #region <終了>

        /// <summary>
        /// [終了]ツールボタンのClickイベントハンドラ
        /// </summary>
        private void OnClickExitToolButton()
        {
            this.Close();
        }

        /// <summary>
        /// 回答送信画面フォームのFormClosingイベントハンドラ
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        private void PMSCM01101UA_FormClosing(object sender, FormClosingEventArgs e)
        {
            // 送信が無効の場合は終了処理を行わない
            if (!this.myToolbar.Tools["send"].SharedProps.Enabled) return;

            // 削除
            SCMController.AutoDelete();
            SCMController.CloseLog();
            //SendRecevingClose();
            //if (_sendFrm != null)
            //{
            //    _sendFrm.Close();
            //}
        }

        private void SendRecevingClose()
        {
            Process[] pr = Process.GetProcessesByName("PMSCM01104U");
            foreach (Process process in pr)
            {
                COPYDATASTRUCT st = new COPYDATASTRUCT();

                string msg = "Close";
                st.dwData = (IntPtr)0;
                st.cbData = (uint)( msg.Length + 1 );
                st.lpData = msg;

                SendMessage(process.MainWindowHandle, WM_COPYDATA, this.Handle, ref st);
            }
        }

        #endregion // </終了>

        #region <詳細>

        /// <summary>
        /// [詳細]ツールボタンのClickイベントハンドラ
        /// </summary>
        private void OnClickDetailToolButton()
        {
            #region <Guard Phrase>

            if (this.sendingAnswerGrid.ActiveRow == null) return;

            #endregion // </Guard Phrase>

            DetailRecordForm.CurrentHeaderID = (long)this.sendingAnswerGrid.ActiveRow.Cells[SCMController.SendingHeaderTable.IDColumn.ColumnName].Value;
            DetailRecordForm.ShowDialog();
        }

        #endregion // </詳細>

        #region <削除>

        /// <summary>
        /// [削除]ツールボタンのClickイベントハンドラ
        /// </summary>
        private void OnClickDeleteToolButton()
        {
            if (this.sendingAnswerGrid.ActiveRow == null)
            {
                return;
            }

            // 削除確認メッセージ
            DialogResult dialogResult = TMsgDisp.Show(
                this,
                emErrorLevel.ERR_LEVEL_QUESTION,
                this.Name,
                "選択したデータを削除します。" + "\r\n" + "\r\n" +"よろしいですか？",
                0,
                MessageBoxButtons.YesNo);

            if (dialogResult != DialogResult.Yes)
            {
                return;
            }
            SCMController.WriteLog("削除開始\r\n");

            SCMController.Delete((DataRowView)this.sendingAnswerGrid.ActiveRow.ListObject);
               
            // 既存データのクリア
            SCMController.ClearSCMIOData();

            SCMController.WriteLog("削除終了\r\n");
            SCMController.CloseLog();

            // ログを閉じる
            SCMController.CloseLog();

            // 初期化タイマー ON
            this.initializeTimer.Enabled = true;

            this.sendingCustomerGrid.Select();
        }

        // ADD 2014/04/09 SCM仕掛一覧№10641対応 ---------------------------------------------->>>>>
        /// <summary>
        /// SCM受注データ関連を更新し未送信状態を解除します
        /// </summary>
        private void UpdateSCMData()
        {
            const string MY_NAME = "PMSCM01101UA";
            const string METHOD = "UpdateSCMData";

            try
            {
                // 更新対象のリストを生成
                SimpleLogger.WriteDebugLog(MY_NAME, METHOD, "\t得意先グリッドのソースを設定中…");
                // 送信先得意先リスト
                this.sendingCustomerGrid.DataSource = SCMController.SendingCustomerTable.DefaultView;
                SimpleLogger.WriteDebugLog(MY_NAME, METHOD, "\t得意先グリッドのソースを設定完了");

                SimpleLogger.WriteDebugLog(MY_NAME, METHOD, "\t送信データグリッドのソースを設定中…");
                // 送信データを検索
                this.sendingAnswerGrid.DataSource = SCMController.SendingHeaderTable.DefaultView;
                SimpleLogger.WriteDebugLog(MY_NAME, METHOD, "\t送信データグリッドのソースを設定完了");

                SCMController.WriteLog("削除開始\r\n");

                // 送信データをすべて削除
                for (int i = 0; i < this.sendingAnswerGrid.Rows.Count; i++)
                {
                    SCMController.Delete((DataRowView)this.sendingAnswerGrid.Rows[i].ListObject);
                }

                // 既存データのクリア
                SCMController.ClearSCMIOData();

                SCMController.WriteLog("削除終了\r\n");
                // ログを閉じる
                SCMController.CloseLog();

            }
            catch (SCMFileOpeningException ex)
            {
                Debug.WriteLine(ex.ToString());

                if (SCMController != null)
                {
                    SCMController.WriteLog("回答データが作成中です。起動を中断しました。");
                    SCMController.CloseLog();
                }
            }

        }
        // ADD 2014/04/09 SCM仕掛一覧№10641対応 ----------------------------------------------<<<<<


        #endregion // </削除>

        #region <送信>

        /// <summary>
        /// [送信]ツールボタンのClickイベントハンドラ
        /// </summary>
        private void OnClickSendToolButton()
        {
            #region <Guard Phrase>

            if (!SCMController.IsOpenedLog)
            {
                if (SCMController.OpenLog().Equals((int)ResultUtil.ResultCode.Error))
                {
                    MessageBox.Show("他の端末で処理中の為送信出来ませんでした。\nしばらくしてから再度処理を行ってください。");
                    return;
                }
            }

            #endregion // </Guard Phrase>

        #if DEBUG
            DialogResult result = MessageBox.Show(
                "送信しますか？",
                "回答送信処理",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question
            );
            if (result.Equals(DialogResult.Cancel)) return;
        #else
            // 単体起動モードの場合、確認する
            if (!SCMController.IsBatchMode)
            {
                DialogResult result = MessageBox.Show(
                    "送信しますか？",
                    "回答送信処理",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question
                );
                if (result.Equals(DialogResult.Cancel)) return;
            }
        #endif

            // --- UPD 2012/12/05 三戸 2012/12/99配信分 SCM障害№10442 --------->>>>>>>>>>>>>>>>>>>>>>>>
            //SCMController.WriteLog("手動送信開始");
            //SimpleLogger.WriteDebugLog("PMSCM01101UA", "OnClickSendToolButton", "手動送信開始");
            SCMController.WriteLog("手動送信開始" + mode);
            SimpleLogger.WriteDebugLog("PMSCM01101UA", "OnClickSendToolButton", "手動送信開始" + mode);
            // --- UPD 2012/12/05 三戸 2012/12/99配信分 SCM障害№10442 ---------<<<<<<<<<<<<<<<<<<<<<<<<
            using (PMSCM01101UC progressForm = new PMSCM01101UC(SCMController, FormStartPosition.CenterParent))
            {
                if (!IsBatchMode) ShowNowSendingForm(); // ADD 2010/03/30 送信中画面の表示処理を再実装

                progressForm.ShowDialog();

                if (!IsBatchMode) CloseNowSendingForm();// ADD 2010/03/30 送信中画面の表示処理を再実装
            }

            // 既存データのクリア
            SCMController.ClearSCMIOData();

            // --- UPD 2012/12/05 三戸 2012/12/99配信分 SCM障害№10442 --------->>>>>>>>>>>>>>>>>>>>>>>>
            //SCMController.WriteLog("手動送信終了\r\n");
            SCMController.WriteLog("手動送信終了" + mode + "\r\n");
            // --- UPD 2012/12/05 三戸 2012/12/99配信分 SCM障害№10442 ---------<<<<<<<<<<<<<<<<<<<<<<<<

            SCMController.CloseLog();

            // --- UPD 2012/12/05 三戸 2012/12/99配信分 SCM障害№10442 --------->>>>>>>>>>>>>>>>>>>>>>>>
            //SimpleLogger.WriteDebugLog("PMSCM01101UA", "OnClickSendToolButton", "手動送信終了");
            SimpleLogger.WriteDebugLog("PMSCM01101UA", "OnClickSendToolButton", "手動送信終了" + mode);
            // --- UPD 2012/12/05 三戸 2012/12/99配信分 SCM障害№10442 ---------<<<<<<<<<<<<<<<<<<<<<<<<

            // ログを閉じる
            SCMController.CloseLog();

            // 初期化タイマー ON
            this.initializeTimer.Enabled = true;
        }

        #endregion // </送信>

        #region <ログ表示>

        # region --- DEL 2011/06/01 ---
        /*
        #region <テキストファイルのビューワ>

        /// <summary>メモ帳</summary>
        private const string NOTEPAD_NAME = "NOTEPAD.EXE";
        /// <summary>テキストファイルのビューワ名</summary>
        private readonly string _textFileViewerName = NOTEPAD_NAME;
        /// <summary>テキストファイルのビューワ名を取得します。</summary>
        private string TextFileViewerName { get { return _textFileViewerName; } }

        #endregion // </テキストファイルのビューワ>

        /// <summary>テキストファイルのビューワ用プロセス</summary>
        private Process _textFileViewerProcess;
        /// <summary>テキストファイルのビューワ用スレッド</summary>
        private Thread _textFileViewerThread;

        /// <summary>
        /// [ログ表示]ツールボタンのClickイベントハンドラ
        /// </summary>
        private void OnClickShowLogToolButton()
        {
            _textFileViewerThread = new Thread(new ThreadStart(ShowLogFileByTextFileViewer));
            _textFileViewerThread.Start();
        }

        /// <summary>
        /// ログファイルをテキストファイルのビューワで表示します。
        /// </summary>
        /// <remarks>
        /// 外部プロセスを起動するためのスレッド
        /// </remarks>
        private void ShowLogFileByTextFileViewer()
        {
            // 外部プロセスの起動
            try
            {
                _textFileViewerProcess = new Process();
                _textFileViewerProcess.StartInfo.FileName = TextFileViewerName; // 起動するファイル名
                _textFileViewerProcess.StartInfo.Arguments= SCMController.LogFilePath;
                _textFileViewerProcess.Start();

                // スレッドが終了されるまで待機
                while (!_textFileViewerProcess.HasExited)
                {
                    Thread.Sleep(100);
                }
            }
            catch (ThreadAbortException e)
            {
                Debug.WriteLine(e.ToString());
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.ToString());
            }
        }
        */
        # endregion

        //--- ADD 2011/06/01 ------------------------------------------------->>>
        private PMSCM01101UD _LogDisplayForm = null;

        /// <summary>
        /// [ログ表示]ツールボタンのClickイベントハンドラ
        /// </summary>
        private void OnClickShowLogToolButton()
        {
            // ログ表示フォームの生成
            if (this._LogDisplayForm == null)
            {
                this._LogDisplayForm = new PMSCM01101UD(SCMController.SettingInfo.SCMDataPath, SCMController.LogFileNameFormat);
            }

            if (!this._LogDisplayForm.Visible)
            {
                // 表示位置調整、但し初回表示時のみ
                this._LogDisplayForm.Width = this.Width;
                this._LogDisplayForm.Height = (int)(this.Height * 0.8);
                this._LogDisplayForm.Top = this.Top + this.Height - this._LogDisplayForm.Height;
                this._LogDisplayForm.Left = this.Left + 50;
                
            }

            this._LogDisplayForm.Show();            
            this._LogDisplayForm.Activate();
        }
        //--- ADD 2011/06/01 -------------------------------------------------<<<

        #endregion // </ログ表示>

        #region <設定>

        /// <summary>
        /// [設定]ツールボタンのClickイベントハンドラ
        /// </summary>
        private void OnClickSettingToolButton()
        {
            SCMController.SettingInfo.ShowDialog();
        }

        #endregion // </設定>

        private void SlipCountRefresh()
        {
            SCMController.GetSlipCnt();
            this.Stat0Cnt_label.Text = String.Format("{0}件", SCMController.Stat0Cnt);
            this.Stat1Cnt_label.Text = String.Format("{0}件", SCMController.Stat1Cnt);

            if (SCMController.SettingInfo.LastDate == DateTime.MinValue)
            {
                this.lblLastDate.Text = "--/--/-- --:--:--";
            }
            else
            {
                this.lblLastDate.Text = (SCMController.SettingInfo.LastDate.ToShortDateString() + " " + SCMController.SettingInfo.LastDate.ToShortTimeString());
            }
        }
    }
}
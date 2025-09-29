using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.UIData;
using Broadleaf.Windows.Forms;
using Broadleaf.Library.Globarization;
// --- ADD m.suzuki 2010/11/02 ---------->>>>>
using System.Runtime.InteropServices;
// --- ADD m.suzuki 2010/11/02 ----------<<<<<

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// UOE回答表示(単体)入力フォームクラス
	/// </summary>
	/// <remarks>
	/// <br>Note		: UOE回答表示(単体)のUIクラスです。</br>
	/// <br>Programmer	: 照田 貴志</br>
	/// <br>Date		: 2008/11/10</br>
    /// <br>UpdateNote  : 2008/12/19 照田 貴志　抽出条件クラス項目追加</br>
    /// <br>              2009/01/06 照田 貴志　不具合対応[9530]</br>
    /// <br>              2009/01/21 照田 貴志　不具合対応[10005]</br>
    /// <br>              2009/01/22 照田 貴志　不具合対応[10368]</br>
    /// <br>Update Note: 2010/11/02  22018 鈴木 正臣</br>
    /// <br>           : Adobe Reader9以降だと終了時エラー発生する件の対応。(WebBrowser解放処理の修正)</br>
    /// </remarks>
	public partial class PMUOE04201UA : Form
	{
        // --- ADD m.suzuki 2010/11/02 ---------->>>>>
        [DllImport( "ole32.dll" )]
        extern static void CoFreeUnusedLibraries();
        // --- ADD m.suzuki 2010/11/02 ----------<<<<<

        // ===================================================================================== //
        // プライベート変数
        // ===================================================================================== //
        #region ■定数、変数、構造体等
        // 定数
        private const string TAB_MAIN = "Main";                                 // メインタブ
        private const string TAB_PREVIEW = "Preview";                           // 印刷プレビュー用タブ
        private const string CURSORMOVE_PREV = "PREV";                          // Shift+Enter/Tab時の動作
        private const string CURSORMOVE_NEXT = "NEXT";                          // Enter/Tab時の動作
        private const string CURSORMOVE_NONE = "NONE";                          // 上記以外の動作
        private const string MESSAGE_INVALID_UOESUPPLIER = "発注先が存在しません。";
        private const string MESSAGE_INVALID_CUSTOMER = "得意先が存在しません。";
        private const string MESSAGE_INVALID_DATE = "有効な日付ではありません。";
        private const string MESSAGE_ST_ED_MISS_DATE = "開始≦終了となるよう設定してください。";
        private const int CHECKDATA_FAILED = -1;                                // チェック失敗
        private const int CHECKDATA_CNDTNEMPTY = 0;                             // 入力なし
        private const int CHECKDATA_SUCCESS = 1;                                // チェック成功
        // クラス
        private PMUOE04203AA _uoeReplyIndicateAcs;                              // UOE回答表示アクセスクラス
        private UOEAnswerLedgerOrderCndtn _uoeAnswerLedgerOrderCndtn;           // 検索条件クラス
        private PMUOE04201UB _detailForm;                                       // 詳細部制御クラス
        private ImageList _imageList16 = null;		                            // イメージリストクラス
        private DCCMN04000UA _printControl = null;                              // 印刷制御クラス
        private SecInfoSetAcs _secInfoSetAcs = new SecInfoSetAcs();             // 拠点情報アクセスクラス
        private ControlScreenSkin _controlScreenSkin;                           // 画面スキン制御クラス
        // ボタン
        private Infragistics.Win.UltraWinToolbars.ButtonTool _closeButton;		// 終了ボタン
        private Infragistics.Win.UltraWinToolbars.ButtonTool _undoButton;		// 取消ボタン
        private Infragistics.Win.UltraWinToolbars.ButtonTool _searchButton;		// 検索ボタン
        private Infragistics.Win.UltraWinToolbars.ButtonTool _printButton;		// 印刷ボタン
        private Infragistics.Win.UltraWinToolbars.ButtonTool _previewButton;	// 印刷ボタン
        // その他変数
        private string _enterpriseCode = string.Empty;                          // 企業コード
        private string _sectionCode = string.Empty;                             // 拠点コード
        private Backup _backup;                                                 // 入力値保持

        #region Backup構造体
        struct Backup
        {
            public int SystemDivCd;                 // 発注区分
            public int UOESupplierCd;               // 発注先コード
            public string UOESupplierName;          // 発注先名称
            public int CustomerCode;                // 得意先コード
            public string CustomerName;             // 得意先名称
            public int ReceiveDateSt;               // 受信日From
            public int ReceiveDateEd;               // 受信日To
        }
        #endregion
        #endregion

        // ===================================================================================== //
		// コンストラクタ
		// ===================================================================================== //
		#region ■Constructor
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note		: クラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer	: 照田 貴志</br>
        /// <br>Date		: 2008/11/10</br>
        /// </remarks>
        public PMUOE04201UA()
		{
			InitializeComponent();

            // UOE回答表示アクセスクラスインスタンス化＆イベント組み込み
            this._uoeReplyIndicateAcs = new PMUOE04203AA();
            this._uoeReplyIndicateAcs.StatusBarMessageSetting += new PMUOE04203AA.SettingStatusBarMessageEventHandler(this.SetStatusBarMessage);    // ステータスバーメッセージ表示
            // 詳細部制御クラスインスタンス化
            this._detailForm = new PMUOE04201UB(this._uoeReplyIndicateAcs);
            // ボタン画像表示
            this._imageList16 = IconResourceManagement.ImageList16;
			this._closeButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Close"];             // 終了
			this._undoButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Undo"];               // 取消
            this._searchButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Search"];           // 検索
			this._printButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Print"];             // 印刷
			this._previewButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Preview"];         // プレビュー
            // 画面スキン制御クラスインスタンス化
            this._controlScreenSkin = new ControlScreenSkin();
			// 企業コード
			this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            // 拠点コード
            this._sectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;
        }
        #endregion ■Constructor - end

        // ===================================================================================== //
        // イベント
        // ===================================================================================== //
        #region ■イベント
        #region ▼PMUOE04201UA_Load(画面ロード)
        /// <summary>
        /// 画面ロードイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note		: 画面表示項目の初期化を行います。</br>
        /// <br>Programmer	: 照田 貴志</br>
        /// <br>Date		: 2008/11/10</br>
        /// </remarks>
        private void PMUOE04201UA_Load(object sender, EventArgs e)
        {
            // 画面スキンファイルの読込(デフォルトスキン指定)
            this._controlScreenSkin.LoadSkin();

            // スキン変更除外設定
            List<string> excCtrlNm = new List<string>();
            excCtrlNm.Add(this.Extract_UGroupBox.Name);
            this._controlScreenSkin.SetExceptionCtrl(excCtrlNm);

            // 画面スキン変更
            this._controlScreenSkin.SettingScreenSkin(this);
            this._controlScreenSkin.SettingScreenSkin(this._detailForm);

            // PMUOE04201UBを、panel_Detailを親としたコントロールにする
            this.panel_Detail.Controls.Add(this._detailForm);
            this._detailForm.Dock = DockStyle.Fill;

            // ボタン初期設定
            this.ButtonInitialSetting();

            // 初期表示設定
            this.InitializeDisplay();
        }
        #endregion

        #region ▼PMUOE04201UA_Shown(フォームが最初に表示された時)
        /// <summary>
        /// フォームが最初に表示された時
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note		: 初期表示時のフォーカス設定を行います。</br>
        /// <br>Programmer	: 照田 貴志</br>
        /// <br>Date		: 2008/11/10</br>
        /// </remarks>
        private void PMUOE04201UA_Shown(object sender, EventArgs e)
        {
            // フォーカスの初期設定
            this.tComboEditor_SalesDivCd.Focus();
        }
        #endregion

        #region ▼PMUOE04201UA_FormClosing(フォーム終了前)
        /// <summary>
        /// フォーム終了前イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note		: 詳細フォームの終了処理(グリッド状態保存)を行います。</br>
        /// <br>Programmer	: 照田 貴志</br>
        /// <br>Date		: 2008/11/10</br>
        /// </remarks>
        private void PMUOE04201UA_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                this._detailForm.Closing();
            }
            catch (NullReferenceException)
            {
                // Exception回避
            }
        }
        #endregion

        #region ▼PMUOE04201UA_FormClosed(フォーム終了後)
        /// <summary>
        /// フォーム終了後イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note		: フォーム終了処理を行います。</br>
        /// <br>Programmer	: 照田 貴志</br>
        /// <br>Date		: 2008/11/10</br>
        /// </remarks>
        private void PMUOE04201UA_FormClosed(object sender, FormClosedEventArgs e)
        {
            // --- UPE m.suzuki 2010/11/02 ---------->>>>>
            //if ( this._printControl != null )
            //{
            //    this._printControl.Dispose();
            //}
            try
            {
                if ( this._printControl != null && this._printControl.PDFViewer != null )
                {
                    // ブラウザコントロールを明確に破棄する
                    this._printControl.PDFViewer.Dispose();
                    // 破棄の為の時間をシステムに与える
                    System.Windows.Forms.Application.DoEvents();
                }
            }
            finally
            {
                //  使用DLLを完全解放
                CoFreeUnusedLibraries();
            }
            // --- UPD m.suzuki 2010/11/02 ----------<<<<<
        }
        #endregion

        #region ▼tToolbarsManager_MainMenu_ToolClick(ツールバーボタンクリック)
        /// <summary>
        /// ツールバーボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note		: ツールバーのボタンクリック時の動作を設定します。</br>
        /// <br>Programmer	: 照田 貴志</br>
        /// <br>Date		: 2008/11/10</br>
        /// </remarks>
        private void tToolbarsManager_MainMenu_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                case "ButtonTool_Close":
                    {
                        // 終了処理
                        this.Close();
                        break;
                    }
                case "ButtonTool_Undo":
                    {
                        // 取消
                        this.InitializeDisplay();               // 表示初期化
                        this.tComboEditor_SalesDivCd.Focus();   // フォーカスセット
                        break;
                    }
                case "ButtonTool_Search":
                    {
                        // 検索処理
                        this.SearchData();

                        break;
                    }
                case "ButtonTool_Print":
                    {
                        // 印刷処理
                        this.Print(false);

                        break;
                    }
                case "ButtonTool_Preview":
                    {
                        // プレビュー処理
                        this.Print(true);
                        break;
                    }
            }
        }
        #endregion

        #region ▼tArrowKeyControl1_ChangeFocus(フォーカス移動)
        /// <summary>
        /// フォーカス移動イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note		: フォーカス移動時の動作を設定します。</br>
        /// <br>Programmer	: 照田 貴志</br>
        /// <br>Date		: 2008/11/10</br>
        /// </remarks>
        private void tArrowKeyControl1_ChangeFocus(object sender, Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null || e.NextCtrl == null)
            {
                return;
            }

            #region 初期設定
            string cursorMove = CURSORMOVE_NONE;    // Enter/Tab以外
            if (e.ShiftKey)
            {
                if ((e.Key == Keys.Return) || (e.Key == Keys.Tab))
                {
                    cursorMove = CURSORMOVE_PREV;   // Shift + Enter/Tab
                }
            }
            else
            {
                if ((e.Key == Keys.Return) || (e.Key == Keys.Tab))
                {
                    cursorMove = CURSORMOVE_NEXT;   // Enter/Tab
                }
            }
            #endregion

            if (e.PrevCtrl == this.uTabControl)
            {
                if ((cursorMove == CURSORMOVE_NEXT) ||
                    ((cursorMove == CURSORMOVE_NONE) && (e.Key == Keys.Down)))
                {
                    e.NextCtrl = this.tComboEditor_SalesDivCd;
                }
            }

            #region PrevCtrl = 発注区分
            if (e.PrevCtrl == this.tComboEditor_SalesDivCd)
            {
                if (cursorMove == CURSORMOVE_PREV)
                {
                    e.NextCtrl = e.PrevCtrl;                // なし
                }
                if ((cursorMove == CURSORMOVE_NONE) && (e.Key == Keys.Up))
                {
                    e.NextCtrl = e.PrevCtrl;                // なし
                }
                if ((cursorMove == CURSORMOVE_NONE) && (e.Key == Keys.Down))
                {
                    e.NextCtrl = this.tNedit_SupplierCd;    // 発注先
                }

                // 値の保存
                this.BackupInputValue(e.PrevCtrl);
                return;
            }
            #endregion

            #region PrevCtrl = 発注先
            if (e.PrevCtrl == this.tNedit_SupplierCd)
            {
                int status = this.CheckInputValueSupplierCd();
                if (status == CHECKDATA_FAILED)
                {
                    // 値を戻す
                    this.RecoverInputValue(e.PrevCtrl);

                    e.NextCtrl = e.PrevCtrl;                        // 移動なし
                    return;
                }
                if ((status == CHECKDATA_SUCCESS) && (cursorMove == CURSORMOVE_NEXT))
                {
                    // 名称取得時
                    if (this.tNedit_CustomerCode.Enabled)
                    {
                        e.NextCtrl = this.tNedit_CustomerCode;      // 得意先
                    }
                    else
                    {
                        e.NextCtrl = this.tDateEdit_ReceiveDateSt;  // 受信日From
                    }
                }

                // 値の保持
                this.BackupInputValue(e.PrevCtrl);
                return;
            }
            #endregion

            #region PrevCtrl = 得意先
            if (e.PrevCtrl == this.tNedit_CustomerCode)
            {
                int status = this.CheckInputValueCustomerCode();
                if (status == CHECKDATA_FAILED)
                {
                    // 値を戻す
                    this.RecoverInputValue(e.PrevCtrl);

                    e.NextCtrl = e.PrevCtrl;                    // 移動なし
                    return;
                }
                if ((status == CHECKDATA_SUCCESS) && (cursorMove == CURSORMOVE_NEXT))
                {
                    // 名称取得時
                    e.NextCtrl = this.tDateEdit_ReceiveDateSt;  // 受信日From
                }

                // 値の保持
                this.BackupInputValue(e.PrevCtrl);
                return;

            }
            #endregion

            #region PrevCtrl = 受信日
            if ((e.PrevCtrl == this.tDateEdit_ReceiveDateSt) || (e.PrevCtrl == this.tDateEdit_ReceiveDateEd))
            {
                int status = this.CheckInputValueReceiveDate((TDateEdit)e.PrevCtrl);
                if (status == CHECKDATA_FAILED)
                {
                    // 値を戻す
                    this.RecoverInputValue(e.PrevCtrl);

                    e.NextCtrl = e.PrevCtrl;                        // 移動なし
                    return;
                }

                // 値の保持
                this.BackupInputValue(e.PrevCtrl);

                if ((cursorMove == CURSORMOVE_NONE) && (e.Key == Keys.Down))
                {
                    // ↓押下
                    e.NextCtrl = this._detailForm.uGrid_Details;    // 明細
                }
                if ((e.PrevCtrl == this.tDateEdit_ReceiveDateEd) && (cursorMove == CURSORMOVE_NEXT))
                {
                    // 受信日ToでEnter/Tab
                    e.NextCtrl = this._detailForm.uGrid_Details;    // 明細
                }
            }
            #endregion

            #region PrevCtrl = 全て解除
            if (e.PrevCtrl == this._detailForm.UnSelect_Button)
            {
                if ((cursorMove == CURSORMOVE_NONE) && (e.Key == Keys.Up))
                {
                    e.NextCtrl = this.tDateEdit_ReceiveDateSt;          // 受信日From
                }
                if (cursorMove == CURSORMOVE_PREV)
                {
                    e.NextCtrl = this.tDateEdit_ReceiveDateSt;          // 受信日From
                }
                return;
            }
            #endregion

            #region PrevCtrl = 全て選択
            if (e.PrevCtrl == this._detailForm.Select_Button)
            {
                if (cursorMove == CURSORMOVE_NONE)
                {
                    if (e.Key == Keys.Up)
                    {
                        e.NextCtrl = this.tDateEdit_ReceiveDateSt;      // 受信日From
                    }
                    if (e.Key == Keys.Right)
                    {
                        e.NextCtrl = this._detailForm.uGrid_Details;    // 明細
                    }
                }
                return;
            }
            #endregion

            #region PrevCtrl = 明細
            if (e.PrevCtrl == this._detailForm.uGrid_Details)
            {
                if (cursorMove == CURSORMOVE_NEXT)
                {
                    e.NextCtrl = e.PrevCtrl;            // 移動なし
                }
            }
            #endregion

            // データ検索
            // 『受信日から↓押下』『受信日ToからEnter/Tab押下』時のみ
            if ((e.PrevCtrl.Parent.Parent == this.Extract_UGroupBox) && (e.NextCtrl == this._detailForm.uGrid_Details))
            {
                this.SearchData();
                if (this._detailForm.uGrid_Details.Enabled == false)
                {
                    if (cursorMove == CURSORMOVE_NEXT)
                    {
                        e.NextCtrl = this.tComboEditor_SalesDivCd;
                    }
                    else
                    {
                        e.NextCtrl = e.PrevCtrl;        // 移動なし
                    }
                }
            }
        }
        #endregion

        #region ▼tComboEditor_SalesDivCd_ValueChanged(発注区分コンボボックス値変更時)
        /// <summary>
        /// 発注区分値変更イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note		: 発注区分に合わせて項目の使用可/不可設定を行います。</br>
        /// <br>Programmer	: 照田 貴志</br>
        /// <br>Date		: 2008/11/10</br>
        /// </remarks>
        private void tComboEditor_SalesDivCd_ValueChanged(object sender, EventArgs e)
        {
            int itemValue = (int)((TComboEditor)sender).Value;
            switch (itemValue)
            {
                case 1:     // 伝発
                case 2:     // 検索
                    {
                        this.tNedit_CustomerCode.Enabled = true;
                        this.uButton_CustomerGuide.Enabled = true;
                        break;
                    }
                default:
                    this.tNedit_CustomerCode.Clear();
                    this.tNedit_CustomerCode.Enabled = false;
                    this.uButton_CustomerGuide.Enabled = false;
                    this.uLabel_CustomerName.Text = string.Empty;
                    break;
            }
        }
        #endregion

        #region ▼uButton_SupplierGuide_Click(発注先ガイドクリック)
        /// <summary>
        /// 発注先ガイド呼び出し
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note		: 発注先ガイドの呼び出しを行います。</br>
        /// <br>Programmer	: 照田 貴志</br>
        /// <br>Date		: 2008/11/10</br>
        /// </remarks>
        private void uButton_SupplierGuide_Click(object sender, EventArgs e)
        {
            UOESupplier uoeSupplier = null;
            UOESupplierAcs uoeSupplierAcs = new UOESupplierAcs();

            // 発注先ガイド表示
            int status = uoeSupplierAcs.ExecuteGuid(this._enterpriseCode,this._sectionCode, out uoeSupplier);
            if ((status == 0) && (uoeSupplier != null))
            {
                this.tNedit_SupplierCd.Value = uoeSupplier.UOESupplierCd;
                this.uLabel_SupplierName.Text = uoeSupplier.UOESupplierName;

                if (this.tNedit_CustomerCode.Enabled)
                {
                    this.tNedit_CustomerCode.Focus();           // 得意先
                }
                else
                {
                    this.tDateEdit_ReceiveDateSt.Focus();       // 受信日From
                }

                // 値の保持
                this.BackupInputValue(this.tNedit_SupplierCd);
            }
        }
        #endregion

        #region ▼uButton_CustomerGuide_Click(得意先ガイドクリック)
        /// <summary>
        /// 得意先ガイド呼び出し
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note		: 得意先ガイドの呼び出しを行います。</br>
        /// <br>Programmer	: 照田 貴志</br>
        /// <br>Date		: 2008/11/10</br>
        /// </remarks>
        private void uButton_CustomerGuide_Click(object sender, EventArgs e)
        {
            // 得意先ガイド用ライブラリ名変更
            PMKHN04005UA customerSearchForm = new PMKHN04005UA(PMKHN04005UA.SEARCHMODE_CUSTOMER_ONLY, PMKHN04005UA.EXECUTEMODE_GUIDE_ONLY);	// 得意先検索アクセスクラス
            customerSearchForm.CustomerSelect += new PMKHN04005UA.CustomerSelectEventHandler(this.CustomerSearchForm_CustomerSelect);
            DialogResult ret = customerSearchForm.ShowDialog(this);
            if (ret == DialogResult.OK)
            {
                this.tDateEdit_ReceiveDateSt.Focus();
            }
        }

        /// <summary>
        /// 得意先選択時発生イベント
        /// </summary>
        /// <param name="sender">ガイドフォーム</param>
        /// <param name="customerSearchRet">得意先情報戻り値クラス</param>
        /// <remarks>
        /// <br>Note		: 得意先選択時に発生するイベント処理を記述します。</br>
        /// <br>Programmer	: 照田 貴志</br>
        /// <br>Date		: 2008/11/10</br>
        /// </remarks>
        private void CustomerSearchForm_CustomerSelect(object sender, CustomerSearchRet customerSearchRet)
        {
            if (customerSearchRet == null)
            {
                return;
            }

            this.tNedit_CustomerCode.Value = customerSearchRet.CustomerCode;                    // 得意先コード
            this.uLabel_CustomerName.Text = customerSearchRet.Name + customerSearchRet.Name2;   // 得意先名称

            // 結果
            ((PMKHN04005UA)sender).DialogResult = DialogResult.OK;
        }
        #endregion

        #region ▼SetStatusBarMessage(ステータスバーメッセージ表示)
        /// <summary>
        /// ステータスバーメッセージ表示イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="message">メッセージ</param>
        /// <remarks>
        /// <br>Note		: ステータスバーにメッセージを設定します。</br>
        /// <br>Programmer	: 照田 貴志</br>
        /// <br>Date		: 2008/11/10</br>
        /// </remarks>
        private void SetStatusBarMessage(object sender, string message)
        {
            this.uStatusBar_Main.Panels[0].Text = message;
        }
        #endregion
        #endregion ■イベント - end

        #region ■Private
        #region ▼InitializeDisplay(画面初期表示)
        /// <summary>
        /// 画面初期表示設定
        /// </summary>
        /// <remarks>
        /// <br>Note		: 画面の初期化を行います。</br>
        /// <br>Programmer	: 照田 貴志</br>
        /// <br>Date		: 2008/11/10</br>
        /// </remarks>
        private void InitializeDisplay()
        {
            // 検索条件初期表示
            this.tComboEditor_SalesDivCd.Value = 1;                     // 発注区分
            this.tNedit_SupplierCd.Clear();                             // 発注先コード
            this.uLabel_SupplierName.Text = string.Empty;               // 発注先名称
            this.tNedit_CustomerCode.Clear();                           // 得意先コード
            this.uLabel_CustomerName.Text = string.Empty;               // 得意先名称
            this.tDateEdit_ReceiveDateSt.SetDateTime(DateTime.Today);   // 受信日付From
            this.tDateEdit_ReceiveDateEd.SetDateTime(DateTime.Today);   // 受信日付To

            // 入力値(初期値)の保持
            this.BackupInputValueAll();

            // 検索条件セット
            this._uoeAnswerLedgerOrderCndtn = this.CreateUOEAnswerLedgerOrderCndtn();

            // 印刷ボタン使用不可
            this.ChangePrintEnable(false);

            // グリッドデータクリア
            this._uoeReplyIndicateAcs.ClearUOEOrderDtlDataTable();
            this._detailForm.SetGridEnable();

            // メッセージ初期化
            SetStatusBarMessage(this, "");

            // プレビュータブ非表示
            this.uTabControl.Tabs[TAB_PREVIEW].Visible = false;
        }
        #endregion

        #region ▼ButtonInitialSetting(ボタン初期設定)
        /// <summary>
        /// ボタン初期設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note		: ボタンの設定を行います。</br>
        /// <br>Programmer	: 照田 貴志</br>
        /// <br>Date		: 2008/11/10</br>
        /// </remarks>
        private void ButtonInitialSetting()
        {
            // ツールバー
            this.tToolbarsManager_MainMenu.ImageListSmall = this._imageList16;
            this._closeButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;       // 終了
            //this._undoButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.RETRY;        // 取消       //DEL 2009/01/06 不具合対応[9530]
            this._undoButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.ALLCANCEL;    // クリア       //ADD 2009/01/06 不具合対応[9530]
            this._searchButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SEARCH;     // 検索
            this._printButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.PRINT;       // 印刷
            this._previewButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.PREVIEW;   // プレビュー
            // ガイド
            this.uButton_SupplierGuide.ImageList = this._imageList16;
            this.uButton_SupplierGuide.Appearance.Image = (int)Size16_Index.STAR1;
            this.uButton_CustomerGuide.ImageList = this._imageList16;
            this.uButton_CustomerGuide.Appearance.Image = (int)Size16_Index.STAR1;
        }
        #endregion

        #region ▼ChangePrintEnable(印刷使用可/不可設定)
        /// <summary>
        /// 印刷使用可/不可設定
        /// </summary>
        /// <param name="isEnabled">True：使用可、False：使用不可</param>
        /// <remarks>
        /// <br>Note		: 印刷ボタン使用可/不可の設定を行います。</br>
        /// <br>Programmer	: 照田 貴志</br>
        /// <br>Date		: 2008/11/10</br>
        /// </remarks>
        private void ChangePrintEnable(bool isEnabled)
        {
            this._printButton.SharedProps.Enabled = isEnabled;      // 印刷
            this._previewButton.SharedProps.Enabled = isEnabled;    // プレビュー
        }
        #endregion

        #region ▼SearchData(検索開始)
        /// <summary>
        /// 検索実行処理
        /// </summary>
        /// <remarks>
        /// <br>Note		: 検索を行います。</br>
        /// <br>Programmer	: 照田 貴志</br>
        /// <br>Date		: 2008/11/10</br>
        /// </remarks>
        private void SearchData()
        {
            // グリッドのフィルタリセット
            this._detailForm.uGrid_Details.Rows.ColumnFilters.ClearAllFilters();

            // 検索条件パラメータクラス設定
            this._uoeAnswerLedgerOrderCndtn = this.CreateUOEAnswerLedgerOrderCndtn();

            this._uoeReplyIndicateAcs.ClearUOEOrderDtlDataTable();

            // 伝票情報読込・データセット格納処理
            this._uoeReplyIndicateAcs.SetSearchData(this._uoeAnswerLedgerOrderCndtn);

            // ChangeGridEnableは上記SetSearchDataの結果(データの有無)によって変わる
            if (this._detailForm.SetGridEnable())
            {
                // データあり
                this.ChangePrintEnable(true);
                this.Extract_UGroupBoxPanel.Focus();            //ADD 2009/01/22 不具合対応[10368]　グリッドにフォーカスが当たるタイミングで色を設定しているので、一度フォーカスをグリッドから外す。
                this._detailForm.uGrid_Details.Focus();
            }
            else
            {
                // データなし
                this.ChangePrintEnable(false);
            }
        }
        #endregion

        #region ▼Print(印刷開始)
        /// <summary>
        /// 印刷処理
        /// </summary>
        /// <param name="preview">True：プレビュー、False：印刷</param>
        /// <remarks>
        /// <br>Note		: 印刷、プレビュー印刷を行います。</br>
        /// <br>Programmer	: 照田 貴志</br>
        /// <br>Date		: 2008/11/10</br>
        /// </remarks>
        private void Print(bool preview)
        {
            if (this._uoeReplyIndicateAcs.GetSelectedRowCount() == 0)
            {
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, this.Name, "明細を選択してください。", -1, MessageBoxButtons.OK);
                return;
            }

            SFCMN06002C printInfo = new SFCMN06002C();
            if (this._printControl == null)
            {
                this._printControl = new DCCMN04000UA();
            }

            printInfo.printmode = (preview) ? 2 : 3;    // 2：プレビュー、3：印刷
            printInfo.pdfopen = false;
            printInfo.pdftemppath = "";

            // 直接印刷バージョン
            printInfo.enterpriseCode = this._enterpriseCode;
            printInfo.kidopgid = "PMUOE04201U";				// 起動PGID

            // PDF出力履歴用
            printInfo.key = "aa37c077-6bcb-4700-9938-a23a1f7545c2";             //ADD 2009/01/21 不具合対応[10005]
            printInfo.prpnm = "";
            printInfo.PrintPaperSetCd = 0;

            printInfo.jyoken = this._uoeAnswerLedgerOrderCndtn;                 // 検索時の条件
            printInfo.rdData = this._uoeReplyIndicateAcs.UOEReplyDataView;      // 印刷対象データ

            int status = _printControl.Print(printInfo);
            if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                if (preview)
                {
                    this._printControl.PDFViewer.Dock = DockStyle.Fill;
                    this.uTab_View.Controls.Add(this._printControl.PDFViewer);
                    this.uTabControl.Tabs[TAB_PREVIEW].Visible = true;
                    this.uTabControl.SelectedTab = this.uTabControl.Tabs[TAB_PREVIEW];
                }
            }
        }
        #endregion

        #region ▼CheckInputValueSupplierCd(発注先入力チェック)
        /// <summary>
        /// 発注先入力チェック
        /// </summary>
        /// <returns>-1：NG、0：入力なし、1：OK</returns>
        /// <remarks>
        /// <br>Note		: 発注先の入力状態をチェックします。</br>
        /// <br>Programmer	: 照田 貴志</br>
        /// <br>Date		: 2008/11/10</br>
        /// </remarks>
        private int CheckInputValueSupplierCd()
        {
            // 値なし
            if (string.IsNullOrEmpty(this.tNedit_SupplierCd.Text))
            {
                this.uLabel_SupplierName.Text = string.Empty;
                return CHECKDATA_CNDTNEMPTY;
            }

            // 名称取得
            string uoeSupplierName = string.Empty;
            bool status = this._uoeReplyIndicateAcs.GetUOESupplierName(this.tNedit_SupplierCd.GetInt(), out uoeSupplierName);
            if (status == false)
            {
                // 取得失敗
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, this.Name, MESSAGE_INVALID_UOESUPPLIER, -1, MessageBoxButtons.OK);
                return CHECKDATA_FAILED;
            }

            // 取得成功
            this.uLabel_SupplierName.Text = uoeSupplierName;
            return CHECKDATA_SUCCESS;
        }
        #endregion

        #region ▼CheckInputValueCustomerCode(得意先入力チェック)
        /// <summary>
        /// 得意先入力チェック
        /// </summary>
        /// <returns>-1：NG、0：入力なし、1：OK</returns>
        /// <remarks>
        /// <br>Note		: 得意先の入力状態をチェックします。</br>
        /// <br>Programmer	: 照田 貴志</br>
        /// <br>Date		: 2008/11/10</br>
        /// </remarks>
        private int CheckInputValueCustomerCode()
        {
            // 値なし
            if (string.IsNullOrEmpty(this.tNedit_CustomerCode.Text))
            {
                this.uLabel_CustomerName.Text = string.Empty;
                return CHECKDATA_CNDTNEMPTY;
            }

            // 名称取得
            string customerName = string.Empty;
            bool status = this._uoeReplyIndicateAcs.GetCustomerName(this.tNedit_CustomerCode.GetInt(), out customerName);
            if (status == false)
            {
                // 取得失敗
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, this.Name, MESSAGE_INVALID_CUSTOMER, -1, MessageBoxButtons.OK);
                return CHECKDATA_FAILED;
            }

            // 取得成功
            this.uLabel_CustomerName.Text = customerName;
            return CHECKDATA_SUCCESS;
        }
        #endregion

        #region ▼CheckInputValueReceiveDate(受信日入力チェック)
        /// <summary>
        /// 受信日入力チェック
        /// </summary>
        /// <param name="ctrl">対象コントロール</param>
        /// <returns>-1：NG、0：入力なし、1：OK</returns>
        /// <remarks>
        /// <br>Note		: 受信日の入力状態をチェックします。</br>
        /// <br>Programmer	: 照田 貴志</br>
        /// <br>Date		: 2008/11/10</br>
        /// </remarks>
        private int CheckInputValueReceiveDate(TDateEdit ctrl)
        {
            if (ctrl.GetLongDate() == 0)
            {
                return CHECKDATA_CNDTNEMPTY;
            }

            DateTime retDateTime = new DateTime();

            // 有効チェック
            if (DateTime.TryParse(ctrl.GetDateTimeString("yyyy.MM.DD"), out retDateTime) == false)
            {
                // チェックNG
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, this.Name, MESSAGE_INVALID_DATE, -1, MessageBoxButtons.OK);
                return CHECKDATA_FAILED;
            }

            // 大小チェック
            if ((this.tDateEdit_ReceiveDateSt.LongDate != 0) && (this.tDateEdit_ReceiveDateEd.LongDate != 0))
            {
                if (this.tDateEdit_ReceiveDateSt.LongDate > this.tDateEdit_ReceiveDateEd.LongDate)
                {
                    // チェックNG
                    TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, this.Name, MESSAGE_ST_ED_MISS_DATE, -1, MessageBoxButtons.OK);
                    return CHECKDATA_FAILED;
                }
            }

            // チェックOK
            return CHECKDATA_SUCCESS;
        }
        #endregion

        #region ▼CreateUOEOrderDtlCndtn(検索条件パラメータ取得)
        /// <summary>
        /// 検索条件パラメータ設定処理
        /// </summary>
        /// <returns>検索条件パラメータクラス</returns>
        /// <remarks>
        /// <br>Note		: 検索条件パラメータ値の取得を行います。</br>
        /// <br>Programmer	: 照田 貴志</br>
        /// <br>Date		: 2008/11/10</br>
        /// </remarks>
        private UOEAnswerLedgerOrderCndtn CreateUOEAnswerLedgerOrderCndtn()
        {
            UOEAnswerLedgerOrderCndtn uoeAnswerLedgerOrderCndtn = new UOEAnswerLedgerOrderCndtn();
            uoeAnswerLedgerOrderCndtn.EnterpriseCode = this._enterpriseCode;                        // 企業コード
            uoeAnswerLedgerOrderCndtn.SectionCode = this._sectionCode;                              // 拠点コード
            uoeAnswerLedgerOrderCndtn.SystemDivCd = (int)this.tComboEditor_SalesDivCd.Value;        // システム区分
            uoeAnswerLedgerOrderCndtn.SystemDivName = this.tComboEditor_SalesDivCd.Text;            // システム区分名称
            uoeAnswerLedgerOrderCndtn.UOESupplierCd = this.tNedit_SupplierCd.GetInt();              // 発注先コード
            uoeAnswerLedgerOrderCndtn.UOESupplierName = this.uLabel_SupplierName.Text;              // 発注先名称
            uoeAnswerLedgerOrderCndtn.CustomerCode = this.tNedit_CustomerCode.GetInt();             // 得意先コード
            uoeAnswerLedgerOrderCndtn.CustomerName = this.uLabel_CustomerName.Text;                 // 得意先名称
            uoeAnswerLedgerOrderCndtn.St_ReceiveDate = this.tDateEdit_ReceiveDateSt.GetDateTime();  // 開始受信日付
            uoeAnswerLedgerOrderCndtn.Ed_ReceiveDate = this.tDateEdit_ReceiveDateEd.GetDateTime();  // 終了受信日付
            uoeAnswerLedgerOrderCndtn.UOEKind = 0;                                                  // UOE種別(0：UOE固定)  //ADD 2008/12/19
            uoeAnswerLedgerOrderCndtn.St_InputDay = DateTime.MinValue;                              // 入力日(開始)         //ADD 2008/12/19
            uoeAnswerLedgerOrderCndtn.Ed_InputDay = DateTime.MinValue;                              // 入力日(終了)         //ADD 2008/12/19

            return uoeAnswerLedgerOrderCndtn;
        }
        #endregion

        #region ▼BackupInputValue(入力値の保持－全て)
        /// <summary>
        /// 入力値保存
        /// </summary>
        /// <remarks>
        /// <br>Note		: 入力値を保存します。</br>
        /// <br>Programmer	: 照田 貴志</br>
        /// <br>Date		: 2008/11/10</br>
        /// </remarks>
        private void BackupInputValueAll()
        {
            this.BackupInputValue(this.tNedit_SupplierCd);          // 発注先
            this.BackupInputValue(this.tNedit_CustomerCode);        // 得意先
            this.BackupInputValue(this.tDateEdit_ReceiveDateSt);    // 受信日From
            this.BackupInputValue(this.tDateEdit_ReceiveDateEd);    // 受信日To
        }
        #endregion

        #region ▼BackupInputValue(入力値の保持－単体)
        /// <summary>
        /// 入力値保存
        /// </summary>
        /// <param name="ctrl">対象コントロール</param>
        /// <remarks>
        /// <br>Note		: 入力値を保存します。</br>
        /// <br>Programmer	: 照田 貴志</br>
        /// <br>Date		: 2008/11/10</br>
        /// </remarks>
        private void BackupInputValue(Control ctrl)
        {
            // 発注区分
            if (ctrl == this.tComboEditor_SalesDivCd)
            {
                this._backup.SystemDivCd = (int)this.tComboEditor_SalesDivCd.Value;
            }
            // 発注先
            if (ctrl == this.tNedit_SupplierCd)
            {
                this._backup.UOESupplierCd = this.tNedit_SupplierCd.GetInt();
                this._backup.UOESupplierName = this.uLabel_SupplierName.Text;
                return;
            }
            // 得意先
            if (ctrl == this.tNedit_CustomerCode)
            {
                this._backup.CustomerCode = this.tNedit_CustomerCode.GetInt();
                this._backup.CustomerName = this.uLabel_CustomerName.Text;
                return;
            }
            // 受信日From
            if (ctrl == this.tDateEdit_ReceiveDateSt)
            {
                this._backup.ReceiveDateSt = this.tDateEdit_ReceiveDateSt.GetLongDate();
                return;
            }
            // 受信日To
            if (ctrl == this.tDateEdit_ReceiveDateEd)
            {
                this._backup.ReceiveDateEd = this.tDateEdit_ReceiveDateEd.GetLongDate();
                return;
            }
        }
        #endregion

        #region ▼RecoverInputValue(保持した値に戻す)
        /// <summary>
        /// 入力値リカバリー
        /// </summary>
        /// <param name="ctrl">対象コントロール</param>
        /// <remarks>
        /// <br>Note		: 入力値を入力前の値に戻します。</br>
        /// <br>Programmer	: 照田 貴志</br>
        /// <br>Date		: 2008/11/10</br>
        /// </remarks>
        private void RecoverInputValue(Control ctrl)
        {
            // 発注区分
            if (ctrl == this.tComboEditor_SalesDivCd)
            {
                this.tComboEditor_SalesDivCd.Value = this._backup.SystemDivCd;
            }
            // 発注先
            if (ctrl == this.tNedit_SupplierCd)
            {
                if (this._backup.UOESupplierCd == 0)
                {
                    this.tNedit_SupplierCd.Clear();
                    this.uLabel_SupplierName.Text = string.Empty;
                }
                else
                {
                    this.tNedit_SupplierCd.Value = this._backup.UOESupplierCd;
                    this.uLabel_SupplierName.Text = this._backup.UOESupplierName;
                }
                return;
            }
            // 得意先
            if (ctrl == this.tNedit_CustomerCode)
            {
                if (this._backup.CustomerCode == 0)
                {
                    this.tNedit_CustomerCode.Clear();
                    this.uLabel_CustomerName.Text = string.Empty;
                }
                else
                {
                    this.tNedit_CustomerCode.Value = this._backup.CustomerCode;
                    this.uLabel_CustomerName.Text = this._backup.CustomerName;
                }
                return;
            }
            // 受信日From
            if (ctrl == this.tDateEdit_ReceiveDateSt)
            {
                this.tDateEdit_ReceiveDateSt.SetLongDate(this._backup.ReceiveDateSt);
                return;
            }
            // 受信日To
            if (ctrl == this.tDateEdit_ReceiveDateEd)
            {
                this.tDateEdit_ReceiveDateEd.SetLongDate(this._backup.ReceiveDateEd);
                return;
            }
        }
        #endregion

        #endregion ■Private - end
    }
}
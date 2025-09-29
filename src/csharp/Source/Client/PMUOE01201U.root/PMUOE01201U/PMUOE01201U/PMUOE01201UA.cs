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

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// UOE入庫更新入力フォームクラス
	/// </summary>
	/// <remarks>
	/// <br>Note		: UOE入庫更新のUIクラスです。</br>
	/// <br>Programmer	: 照田 貴志</br>
	/// <br>Date		: 2008/09/04</br>
    /// <br>UpdateNote  : 2009/01/19 照田 貴志　不具合対応[10063]</br>
    /// <br>              2009/02/05 照田 貴志　不具合対応[10974]</br>
    /// <br>              2009/02/17 上野 俊治　不具合対応[11510]</br>
    /// <br>              2009/03/11 忍 幸史　不具合対応[12319]</br>
    /// <br>              2009/03/12 忍 幸史　不具合対応[12291]</br>
	/// </remarks>
	public partial class PMUOE01201UA : Form
	{
        // ===================================================================================== //
        // プライベート変数
        // ===================================================================================== //
        #region ▼定数
        // メッセージ
        //private const string MESSAGE_INVALID_SUPPLIER = "仕入先が存在しません。";                                         //DEL 2009/01/19 不具合対応[10063]
        //private const string MESSAGE_INVALID_INDISPENSABLE = "「仕入先」「納品書No.」のいずれかを入力して下さい。";       //DEL 2009/01/19 不具合対応[10063]
        private const string MESSAGE_INVALID_SUPPLIER = "発注先が存在しません。";                                           //ADD 2009/01/19
        private const string MESSAGE_INVALID_INDISPENSABLE = "「発注先」「納品書No.」のいずれかを入力して下さい。";         //ADD 2009/01/19
        // キーダウン制御
        private const string CURSORMOVE_PREV = "PREV";                          // Shift+Enter/Tab時の動作
        private const string CURSORMOVE_NEXT = "NEXT";                          // Enter/Tab時の動作
        private const string CURSORMOVE_NONE = "NONE";                          // 上記以外の動作
        // エラーチェック
        private const int CHECKDATA_FAILED = -1;                                // チェック失敗
        private const int CHECKDATA_CNDTNEMPTY = 0;                             // 入力なし
        private const int CHECKDATA_SUCCESS = 1;                                // チェック成功
        #endregion

        #region ▼変数
        // 各種クラス
        private ImageList _imageList16 = null;		                            // イメージリスト
        private ControlScreenSkin _controlScreenSkin = null;                    // 画面スキン制御
        private UOESettingAcs _uoeSettingAcs = null;                            // UOE自社マスタアクセス
        private PMUOE01203AA _uoeEnterUpdAcs = null;                            // UOE入庫更新アクセス
        private UOEStockUpdSearch _uoeStockUpdSearch = null;                      // 検索条件
        private PMUOE01201UB _headerForm = null;                                // ヘッダーグリッド制御
        private PMUOE01201UC _detailForm = null;                                // 詳細部グリッド制御
        // ボタン
        private Infragistics.Win.UltraWinToolbars.ButtonTool _closeButton;		// 終了ボタン
        private Infragistics.Win.UltraWinToolbars.ButtonTool _decisionButton;   // 確定ボタン
        private Infragistics.Win.UltraWinToolbars.ButtonTool _clearButton;		// クリアボタン
        private Infragistics.Win.UltraWinToolbars.ButtonTool _searchButton;		// 検索ボタン
        // その他変数
        private string _enterpriseCode;             // 企業コード
        private string _loginSectionCode;           // 自拠点コード
        private int _stockBlnktPrtNoDiv;            // UOE自社.在庫一括品番区分
        #endregion

        #region ▼Backup構造体
        private Backup _backup;                     // 入力値保持
        struct Backup
        {
            public int ProcessDiv;                  // 処理区分
            public int SupplierCd;                  // 仕入先コード
            public string SupplierName;             // 仕入先名称
            public string SupplierSlipNo;           // 納品書No.
        }
        #endregion

        // ===================================================================================== //
		// コンストラクタ
		// ===================================================================================== //
		#region ▼Constructor
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note		: クラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer	: 照田 貴志</br>
        /// <br>Date		: 2008/09/04</br>
        /// </remarks>
        public PMUOE01201UA()
		{
			InitializeComponent();

            // クラスインスタンス化
            this._controlScreenSkin = new ControlScreenSkin();              // 画面スキン制御
            this._uoeSettingAcs = new UOESettingAcs();                      // UOE自社マスタアクセス
            this._uoeEnterUpdAcs = new PMUOE01203AA();                      // UOE入庫更新アクセス
            this._headerForm = new PMUOE01201UB(this._uoeEnterUpdAcs);      // ヘッダーグリッド制御
            this._detailForm = new PMUOE01201UC(this._uoeEnterUpdAcs);      // 明細グリッド制御

            // デリゲートイベント組み込み
            this._uoeEnterUpdAcs.StatusBarMessageSetting +=
                new PMUOE01203AA.SettingStatusBarMessageEventHandler(this.SetStatusBarMessage);                             // ステータスバーメッセージ表示
            this._headerForm.DetailEnableSetting +=
                new PMUOE01201UB.DetailEnableSettingEventHandler(this.DetailEnableSetting);                                 // 明細グリッド使用可/不可設定
            this._headerForm.MoveFocusDetailGridFromHeaderGrid +=
                new PMUOE01201UB.MoveFocusDetailGridFromHeaderGridEventHandler(this.MoveFocusDetailGridFromHeaderGrid);     // フォーカス移動(ヘッダー→明細)
            this._detailForm.MoveFocusHeaderGridFromDetailGrid +=
                new PMUOE01201UC.MoveFocusHeaderGridFromDetailGridEventHandler(this.MoveFocusHeaderGridFromDetailGrid);     // フォーカス移動(明細→ヘッダー)

            // ボタン画像表示
            this._imageList16 = IconResourceManagement.ImageList16;
            this._closeButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Close"];             // 終了
            this._decisionButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Decision"];       // 確定
            this._clearButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Clear"];             // クリア
            this._searchButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Search"];           // 検索
            
            // ログイン情報取得
			this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;                 // 企業コード
            this._loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;   // 自拠点コード
        }
        #endregion

        // ===================================================================================== //
        // イベント
        // ===================================================================================== //
        #region ▼PMUOE01201UA_Load(フォームロード)
        /// <summary>
        /// フォームロード
        /// </summary>
        /// <param name="sender">PMUOE01201UA型</param>
        /// <param name="e">基本イベントデータ</param>
        /// <remarks>
        /// <br>Note		: 画面表示項目の初期化を行います。</br>
        /// <br>Programmer	: 照田 貴志</br>
        /// <br>Date		: 2008/09/04</br>
        /// </remarks>
        private void PMUOE01201UA_Load(object sender, EventArgs e)
        {
            // UOE自社マスタ読み込み
            UOESetting uoeSetting = null;
            int status = this._uoeSettingAcs.Read(out uoeSetting, this._enterpriseCode, this._loginSectionCode);
            if ((status == 0) && (uoeSetting != null))
            {
                this._stockBlnktPrtNoDiv = uoeSetting.StockBlnktPrtNoDiv;           // 在庫一括品番区分

                // 入庫更新用アクセスクラスに渡す
                this._uoeEnterUpdAcs.StockBlnktPrtNoDiv = this._stockBlnktPrtNoDiv;
            }

            // 画面スキン変更
            this._controlScreenSkin.LoadSkin();
            this._controlScreenSkin.SettingScreenSkin(this);                // メインフォーム
            this._controlScreenSkin.SettingScreenSkin(this._headerForm);    // ヘッダーグリッド用フォーム
            this._controlScreenSkin.SettingScreenSkin(this._detailForm);    // 明細グリッド用フォーム

            // PMUOE04201UBをpanel_Headerに貼り付ける
            this.panel_Header.Controls.Add(this._headerForm);
            this._headerForm.Dock = DockStyle.Fill;

            // PMUOE04201UCをpanel_Detailに貼り付ける
            this.panel_Detail.Controls.Add(this._detailForm);
            this._detailForm.Dock = DockStyle.Fill;

            // ボタン設定
            this.ButtonInitialSetting();

            // 表示設定
            this.InitializeDisplay();
        }
        #endregion

        #region ▼PMUOE01201UA_Shown(フォーム初回表示)
        /// <summary>
        /// フォーム初回表示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">基本イベントデータ</param>
        /// <remarks>
        /// <br>Note		: 初回表示時のフォーカス設定を行います。</br>
        /// <br>Programmer	: 照田 貴志</br>
        /// <br>Date		: 2008/09/04</br>
        /// </remarks>
        private void PMUOE01201UA_Shown(object sender, EventArgs e)
        {
            this.tNedit_SupplierCd.Focus();
        }
        #endregion

        #region ▼PMUOE01201UA_FormClosing(フォームクローズ前)
        /// <summary>
        /// フォームクローズ前
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">フォームクローズイベントデータ</param>
        /// <remarks>
        /// <br>Note		: 詳細フォームの終了処理(グリッド状態保存)を行います。</br>
        /// <br>Programmer	: 照田 貴志</br>
        /// <br>Date		: 2008/09/04</br>
        /// </remarks>
        private void PMUOE01201UA_FormClosing(object sender, FormClosingEventArgs e)
        {
            // ヘッダーグリッド用フォーム
            try
            {
                this._headerForm.Closing();
            }
            catch (NullReferenceException)
            {
                // Exception回避
            }

            // 明細グリッド用フォーム
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

        #region ▼tToolbarsManager_MainMenu_ToolClick(ツールバークリック)
        /// <summary>
        /// ツールバークリック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">ツールクリックイベントデータ</param>
        /// <remarks>
        /// <br>Note		: ツールバークリック時の動作を設定します。</br>
        /// <br>Programmer	: 照田 貴志</br>
        /// <br>Date		: 2008/09/04</br>
        /// </remarks>
        private void tToolbarsManager_MainMenu_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                // 終了
                case "ButtonTool_Close":
                    {
                        this.Close();
                        break;
                    }
                // 確定
                case "ButtonTool_Decision":
                    {
                        this.DecisionData();
                        break;
                    }
                // 検索
                case "ButtonTool_Search":
                    {
                        this.SearchData();
                        break;
                    }
                // クリア
                case "ButtonTool_Clear":
                    {
                        this.InitializeDisplay();
                        this.tNedit_SupplierCd.Focus();       // 指定拠点
                        break;
                    }
            }
        }
        #endregion        

        #region ▼tArrowKeyControl1_ChangeFocus(フォーカス移動)
        /// <summary>
        /// フォーカス移動
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">フォーカス移動イベントデータ</param>
        /// <remarks>
        /// <br>Note		: フォーカス移動時の動作を設定します。</br>
        /// <br>Programmer	: 照田 貴志</br>
        /// <br>Date		: 2008/09/04</br>
        /// </remarks>
        private void tArrowKeyControl1_ChangeFocus(object sender, Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null || e.NextCtrl == null)
            {
                return;
            }

            // カーソル移動区分設定
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

            #region PrevCtrl = 処理区分
            if (e.PrevCtrl == this.tComboEditor_ProcessDiv)
            {
                // Shift + Enter/Tab
                if (cursorMove == CURSORMOVE_PREV)
                {
                    e.NextCtrl = e.PrevCtrl;                // なし
                }
                // ↑
                if ((cursorMove == CURSORMOVE_NONE) && (e.Key == Keys.Up))
                {
                    e.NextCtrl = e.PrevCtrl;                // なし
                }
                // ↓
                if ((cursorMove == CURSORMOVE_NONE) && (e.Key == Keys.Down))
                {
                    e.NextCtrl = this.tNedit_SupplierCd;    // 仕入先
                }

                // 値の保存
                this.BackupInputValue(e.PrevCtrl);
                return;
            }
            #endregion

            #region PrevCtrl = 発注先コード
            // 発注先コード
            if (e.PrevCtrl == this.tNedit_SupplierCd)
            {
                // 発注コード入力チェック
                int supplierStatus = this.CheckInputValueSupplierCd();
                switch (supplierStatus)
                {
                    // チェックNG
                    case CHECKDATA_FAILED:
                        {
                            // 値を戻す
                            this.RecoverInputValue(e.PrevCtrl);
                            e.NextCtrl = e.PrevCtrl;        // なし
                            return;
                        }
                    // チェックOK
                    case CHECKDATA_SUCCESS:
                        {
                            // Enter/Tab
                            if (cursorMove == CURSORMOVE_NEXT)
                            {
                                e.NextCtrl = this.tEdit_SlipNo;    // 納品書No.
                            }
                            // ↓
                            if ((cursorMove == CURSORMOVE_NONE) && (e.Key == Keys.Down))
                            {
                                // 検索
                                this.SearchData();
                                if (this._headerForm.uGrid_Header.Enabled == false)
                                {
                                    e.NextCtrl = e.PrevCtrl;        // なし
                                }
                            }
                            break;
                        }
                    // 入力値なし
                    case CHECKDATA_CNDTNEMPTY:
                        {
                            // 納品書No.入力チェック
                            int slipNoStatus = this.CheckInputValueSlipNo();

                            // 入力値なし
                            if (slipNoStatus == CHECKDATA_CNDTNEMPTY)
                            {
                                // ↓
                                if ((cursorMove == CURSORMOVE_NONE) && (e.Key == Keys.Down))
                                {
                                    e.NextCtrl = e.PrevCtrl;        // なし
                                    return;
                                }
                            }
                            // ↓
                            if ((cursorMove == CURSORMOVE_NONE) && (e.Key == Keys.Down))
                            {
                                // 検索
                                this.SearchData();
                                if (this._headerForm.uGrid_Header.Enabled == false)
                                {
                                    e.NextCtrl = e.PrevCtrl;        // なし
                                }
                            }
                            break;
                        }
                }
                // 値の保持
                this.BackupInputValue(e.PrevCtrl);
                return;
            }
            #endregion

            #region PrevCtrl = 発注先ガイド
            // 発注先ガイド
            if (e.PrevCtrl == this.uButton_SupplierGuide)
            {
                // ↓
                if ((cursorMove == CURSORMOVE_NONE) && (e.Key == Keys.Down))
                {
                    e.NextCtrl = e.PrevCtrl;        // なし
                }
            }
            #endregion

            #region PrevCtrl = 納品書No.
            if (e.PrevCtrl == this.tEdit_SlipNo)
            {
                // 納品書No.入力チェック
                int slipNoStatus = this.CheckInputValueSlipNo();

                // 入力値なし
                if (slipNoStatus == CHECKDATA_CNDTNEMPTY)
                {
                    // 仕入先入力チェック
                    int supplierStatus = this.CheckInputValueSupplierCd();

                    // 入力値なし
                    if (supplierStatus == CHECKDATA_CNDTNEMPTY)
                    {
                        // Enter/Tab or ↓
                        if ((cursorMove == CURSORMOVE_NEXT) ||
                            ((cursorMove == CURSORMOVE_NONE) && (e.Key == Keys.Down)))
                        {
                            e.NextCtrl = this.tComboEditor_ProcessDiv;
                            return;
                        }
                    }
                }

                // 値の保持
                this.BackupInputValue(e.PrevCtrl);

                // Enter/Tab or ↓
                if ((cursorMove == CURSORMOVE_NEXT) || 
                    ((cursorMove == CURSORMOVE_NONE) && (e.Key == Keys.Down)))
                {
                    // 検索
                    this.SearchData();
                    if (this._headerForm.uGrid_Header.Enabled == false)
                    {
                        if (cursorMove == CURSORMOVE_NEXT)
                        {
                            e.NextCtrl = this.tComboEditor_ProcessDiv;
                        }
                        else
                        {
                            e.NextCtrl = e.PrevCtrl;
                        }
                        return;
                    }
                    e.NextCtrl = this._headerForm.uGrid_Header;
                }
            }
            #endregion

            #region PrevCtrl = ヘッダーグリッド
            if (e.PrevCtrl == this._headerForm.uGrid_Header)
            {
                // Enter/Tab or Shift + Enter/Tab
                if ((cursorMove == CURSORMOVE_NEXT) || (cursorMove == CURSORMOVE_PREV))
                {
                    // ヘッダーグリッド用フォーム内にて処理
                    this._headerForm.ReturnKeyDown(e);
                }
                e.NextCtrl = null;      // なし
            }
            #endregion

            #region PrevCtrl = 明細グリッド
            if (e.PrevCtrl == this._detailForm.uGrid_Detail)
            {
                // Enter/Tab or Shift + Enter/Tab
                if ((cursorMove == CURSORMOVE_NEXT) || (cursorMove == CURSORMOVE_PREV))
                {
                    // 明細グリッド用フォーム内にて処理
                    this._detailForm.ReturnKeyDown(e);
                }
                e.NextCtrl = null;      // なし
            }
            #endregion
        }
        #endregion

        #region ▼uButton_SupplierGuide_Click(仕入先ガイドクリック)
        /// <summary>
        /// 仕入先ガイド呼び出し
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">基本イベントデータ</param>
        /// <remarks>
        /// <br>Note		: 仕入先ガイドの呼び出しを行います。</br>
        /// <br>Programmer	: 照田 貴志</br>
        /// <br>Date		: 2008/09/04</br>
        /// </remarks>
        private void uButton_SupplierGuide_Click(object sender, EventArgs e)
        {
            /* ---DEL 2009/01/19 不具合対応[10063] ------------------------------------------------------>>>>>
            SupplierAcs supplierAcs = new SupplierAcs();

            // 仕入先ガイド表示
            Supplier supplier = null;
            int status = supplierAcs.ExecuteGuid(out supplier, this._enterpriseCode, this._loginSectionCode);
            if ((status == 0) && (supplier != null))
            {
                // 値設定
                this.tNedit_SupplierCd.Value = supplier.SupplierCd;
                this.tNedit_SupplierCd.Text = supplier.SupplierCd.ToString("000000");
                this.uLabel_SupplierSNm.Text = supplier.SupplierSnm;

                // 値の保持
                this.BackupInputValue(this.tNedit_SupplierCd);

                // フォーカス移動
                this.tEdit_SlipNo.Focus();
            }
              ---DEL 2009/01/19 不具合対応[10063] ------------------------------------------------------<<<<< */
            // ---ADD 2009/01/19 不具合対応[10063] ------------------------------------------------------>>>>>
            UOESupplier uoeSupplier = new UOESupplier();
            UOESupplierAcs uoeSupplierAcs = new UOESupplierAcs();

            // 発注先ガイド表示
            int status = uoeSupplierAcs.ExecuteGuid(this._enterpriseCode, LoginInfoAcquisition.Employee.BelongSectionCode, out uoeSupplier);
            if ((status == 0) && (uoeSupplier != null))
            {
                // 値設定
                this.tNedit_SupplierCd.Value = uoeSupplier.UOESupplierCd;
                this.tNedit_SupplierCd.Text = uoeSupplier.UOESupplierCd.ToString("000000");
                this.uLabel_SupplierSNm.Text = uoeSupplier.UOESupplierName;

                // 値の保持
                this.BackupInputValue(this.tNedit_SupplierCd);

                // フォーカス移動
                this.tEdit_SlipNo.Focus();
            }
            // ---ADD 2009/01/19 不具合対応[10063] ------------------------------------------------------<<<<<
        }
        #endregion

        // ===================================================================================== //
        // デリゲート
        // ===================================================================================== //
        #region ▼SetStatusBarMessage(ステータスバーメッセージ表示)
        /// <summary>
        /// ステータスバーメッセージ表示
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="message">メッセージ</param>
        /// <remarks>
        /// <br>Note		: ステータスバーにメッセージを設定します。</br>
        /// <br>Programmer	: 照田 貴志</br>
        /// <br>Date		: 2008/09/04</br>
        /// </remarks>
        private void SetStatusBarMessage(object sender, string message)
        {
            this.uStatusBar_Main.Panels[0].Text = message;
        }
        #endregion

        #region ▼DetailEnableSetting(明細グリッド使用可/不可設定)
        /// <summary>
        /// 明細グリッド使用可/不可設定
        /// </summary>
        /// <param name="sender">呼び出し元クラス</param>
        /// <param name="enableFlg">True：使用可、False：使用不可</param>
        /// <remarks>
        /// <br>Note		: 明細グリッドの設定を行います。</br>
        /// <br>Programmer	: 照田 貴志</br>
        /// <br>Date		: 2008/09/04</br>
        /// </remarks>
        private void DetailEnableSetting(object sender, bool enableFlg)
        {
            // 明細グリッド使用可/不可設定
            this._detailForm.uGrid_Detail.Enabled = enableFlg;

            // 明細グリッド列編集可/不可設定
            this._detailForm.InitializeColumnEditCondition();

            // 明細グリッドセル色設定
            this._detailForm.ChangeColorAll();
        }
        #endregion

        #region ▼MoveFocusDetailGridFromHeaderGrid(ヘッダーグリッド→明細グリッドフォーカス移動)
        /// <summary>
        /// ヘッダーグリッド→明細グリッドフォーカス移動
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">基本イベントデータ</param>
        /// <remarks>
        /// <br>Note		: ヘッダーグリッドから明細グリッドにフォーカスを移動します。</br>
        /// <br>Programmer	: 照田 貴志</br>
        /// <br>Date		: 2008/09/04</br>
        /// </remarks>
        private void MoveFocusDetailGridFromHeaderGrid(object sender, EventArgs e)
        {
            // 移動前チェック
            if (this._detailForm.uGrid_Detail.Enabled == false)
            {
                return;
            }
            if (this._detailForm.uGrid_Detail.Rows.Count == 0)
            {
                return;
            }

            string colName = this._uoeEnterUpdAcs.UOEEnterUpdDetailDataSet.DetailTable.DivCdColumn.ColumnName;      // 区分
            // フォーカス移動
            this._detailForm.uGrid_Detail.Focus();
            this._detailForm.uGrid_Detail.Rows[0].Cells[colName].Activate();
        }
        #endregion

        #region ▼MoveFocusHeaderGridFromDetailGrid(明細グリッド→ヘッダーグリッドフォーカス移動)
        /// <summary>
        /// 明細グリッド→ヘッダーグリッドフォーカス移動
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">基本イベントデータ</param>
        /// <remarks>
        /// <br>Note		: 明細グリッドからヘッダーグリッドにフォーカスを移動します。</br>
        /// <br>Programmer	: 照田 貴志</br>
        /// <br>Date		: 2008/09/04</br>
        /// </remarks>
        private void MoveFocusHeaderGridFromDetailGrid(object sender, EventArgs e)
        {
            // 移動前チェック
            if (this._headerForm.uGrid_Header.Enabled == false)
            {
                return;
            }
            if (this._headerForm.uGrid_Header.Rows.Count == 0)
            {
                return;
            }

            // フォーカス移動
            this._headerForm.uGrid_Header.Focus();
            this._headerForm.uGrid_Header.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ActivateCell);
        }
        #endregion

        // ===================================================================================== //
        // プライベート
        // ===================================================================================== //
        // 初期設定関連
        #region ▼InitializeDisplay(画面初期表示)
        /// <summary>
        /// 画面初期表示設定
        /// </summary>
        /// <remarks>
        /// <br>Note		: 画面の初期化を行います。</br>
        /// <br>Programmer	: 照田 貴志</br>
        /// <br>Date		: 2008/09/04</br>
        /// </remarks>
        private void InitializeDisplay()
        {
            // 検索条件初期表示
            this.tComboEditor_ProcessDiv.Value = 0;                     // 処理区分
            this.tNedit_SupplierCd.Clear();                             // 仕入先コード
            this.uLabel_SupplierSNm.Text = string.Empty;                // 仕入先名称
            this.tEdit_SlipNo.Clear();                                  // 納品書No.

            // 代替品番区分
            if (this._stockBlnktPrtNoDiv == 1)
            {
                this.uLabel_SubstPartsNoDiv.Text = "発注品採用";
            }
            else
            {
                this.uLabel_SubstPartsNoDiv.Text = "代替品採用";
            }

            // 入力値(初期値)の保持
            this.BackupInputValueAll();

            // 検索条件セット
            this._uoeStockUpdSearch = this.CreateUOEStockUpdSearch();

            // ヘッダーグリッドクリア
            this._uoeEnterUpdAcs.ClearUOEEnterUpdHeaderData();
            this._headerForm.SetGridEnable();

            // 明細グリッドクリア
            this._uoeEnterUpdAcs.ClearUOEEnterUpdDetailData();
            this._detailForm.SetGridEnable();

            // メッセージ初期化
            SetStatusBarMessage(this, "");
        }
        #endregion

        #region ▼ButtonInitialSetting(ボタン初期設定)
        /// <summary>
        /// ボタン初期設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note		: ボタンの設定を行います。</br>
        /// <br>Programmer	: 照田 貴志</br>
        /// <br>Date		: 2008/09/04</br>
        /// </remarks>
        private void ButtonInitialSetting()
        {
            // ツールバー
            this.tToolbarsManager_MainMenu.ImageListSmall = this._imageList16;
            this._closeButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;           // 終了
            // --- CHG 2009/03/12 障害ID:12291対応------------------------------------------------------>>>>>
            //this._decisionButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.DECISION;     // 確定
            this._decisionButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SAVE;     // 確定
            // --- CHG 2009/03/12 障害ID:12291対応------------------------------------------------------<<<<<
            this._clearButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.ALLCANCEL;       // クリア
            this._searchButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SEARCH;         // 検索
            // ガイド
            this.uButton_SupplierGuide.ImageList = this._imageList16;
            this.uButton_SupplierGuide.Appearance.Image = (int)Size16_Index.STAR1;
        }
        #endregion

        // 検索関連
        #region ▼CreateUOEEnterUpdCndtn(検索条件パラメータ取得)
        /// <summary>
        /// 検索条件パラメータ設定処理
        /// </summary>
        /// <returns>検索条件パラメータクラス</returns>
        /// <remarks>
        /// <br>Note		: 検索条件パラメータ値の取得を行います。</br>
        /// <br>Programmer	: 照田 貴志</br>
        /// <br>Date		: 2008/09/04</br>
        /// </remarks>
        private UOEStockUpdSearch CreateUOEStockUpdSearch()
        {
            UOEStockUpdSearch uoeStockUpdSearch = new UOEStockUpdSearch();
            uoeStockUpdSearch.EnterpriseCode = this._enterpriseCode;                    // 企業コード
            uoeStockUpdSearch.SectionCode = this._loginSectionCode;                     // 拠点コード
            uoeStockUpdSearch.ProcDiv = (int)this.tComboEditor_ProcessDiv.Value;        // 処理区分
            uoeStockUpdSearch.UOESupplierCd = this.tNedit_SupplierCd.GetInt();          // UOE発注先コード
            uoeStockUpdSearch.SlipNo = this.tEdit_SlipNo.Text;          // 伝票番号

            return uoeStockUpdSearch;
        }
        #endregion

        #region ▼SearchData(検索開始)
        /// <summary>
        /// 検索実行処理
        /// </summary>
        /// <remarks>
        /// <br>Note		: 検索を行います。</br>
        /// <br>Programmer	: 照田 貴志</br>
        /// <br>Date		: 2008/09/04</br>
        /// </remarks>
        private void SearchData()
        {
            // 入力チェック
            if ((string.IsNullOrEmpty(this.tNedit_SupplierCd.Text)) && (string.IsNullOrEmpty(this.tEdit_SlipNo.Text)))
            {
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, this.Name, MESSAGE_INVALID_INDISPENSABLE, -1, MessageBoxButtons.OK);
                return;
            }

            // 検索条件設定
            this._uoeStockUpdSearch = this.CreateUOEStockUpdSearch();

            // 検索
            int status = this._uoeEnterUpdAcs.SetSearchData(this._uoeStockUpdSearch);
            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {

            }

            // ヘッダーグリッド使用可/不可設定
            if (this._headerForm.SetGridEnable() == true)
            {
                this._headerForm.uGrid_Header.Focus();
            }

            // 明細グリッド使用可/不可設定
            this._detailForm.SetGridEnable();
        }
        #endregion

        #region ▼DecisionData(確定)
        /// <summary>
        /// 確定実行処理
        /// </summary>
        /// <remarks>
        /// <br>Note		: 入力データの確定を行います。</br>
        /// <br>Programmer	: 照田 貴志</br>
        /// <br>Date		: 2008/09/04</br>
        /// </remarks>
        private void DecisionData()
        {
            // --- ADD 2009/03/11 障害ID:12319対応------------------------------------------------------>>>>>
            DialogResult result = TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_QUESTION, this.Name, "更新してもよろしいですか？", 0, MessageBoxButtons.YesNo);
            if (result == DialogResult.No)
            {
                return;
            }
            // --- ADD 2009/03/11 障害ID:12319対応------------------------------------------------------<<<<<

            string msg = string.Empty;
            
            // 明細情報確定
            if (this._detailForm.uGrid_Detail.ActiveCell != null)
            {
                if (this._detailForm.uGrid_Detail.ActiveCell.IsInEditMode)
                {
                    this._detailForm.uGrid_Detail.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode);
                }
            }
            this._uoeEnterUpdAcs.SaveDetailGrid();

            // 更新前チェック
            if (this.CheckGrid(out msg) == false)
            {
                return;
            }

            //bool status = this._uoeEnterUpdAcs.DecisionData(out msg); // DEL 2009/02/02
            int status = this._uoeEnterUpdAcs.DecisionData(out msg); // ADD 2009/02/02

            //if (status) // DEL 2009/02/02
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) // ADD 2009/02/02
            {
                // 正常
                this.InitializeDisplay();
                this.tComboEditor_ProcessDiv.Focus();       // 指定拠点
            }
            // --- ADD 2009/02/02 -------------------------------->>>>>
            else if (status == (int)ConstantManagement.DB_Status.ctDB_ENT_LOCK_TIMEOUT)
            {
                // --- DEL 2009/02/17 -------------------------------->>>>>
                //TMsgDisp.Show(this,
                //    emErrorLevel.ERR_LEVEL_INFO,
                //    this.Name,
                //    "シェアチェックエラー(企業ロック)です。" + "\r\n"
                //    + "月次処理か、その他の業務を行っているため本処理は行えません。" + "\r\n"
                //    + "再試行するか、しばらく待ってから再度処理を行ってください。",
                //    status,
                //    MessageBoxButtons.OK);
                // --- DEL 2009/02/17 --------------------------------<<<<<
                // --- ADD 2009/02/17 -------------------------------->>>>>
                TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_STOPDISP,
                        this.Name,
                        "保存に失敗しました。" + "\r\n" + "\r\n" +
                        "シェアチェックエラー（企業ロック）です。" + "\r\n" +
                        "月次処理か、その他の業務を行っているため本処理は行えません。" + "\r\n" +
                        "再試行するか、しばらく待ってから再度処理を行ってください。" + "\r\n",
                        status,
                        MessageBoxButtons.OK);
                // --- ADD 2009/02/17 --------------------------------<<<<<
            }
            else if (status == (int)ConstantManagement.DB_Status.ctDB_SEC_LOCK_TIMEOUT)
            {
                // --- DEL 2009/02/17 -------------------------------->>>>>
                //TMsgDisp.Show(this,
                //    emErrorLevel.ERR_LEVEL_INFO,
                //    this.Name,
                //    "シェアチェックエラー(拠点ロック)です。" + "\r\n"
                //    + "締処理か、処理が込み合っているためタイムアウトしました。" + "\r\n"
                //    + "再試行するか、しばらく待ってから再度処理を行ってください。",
                //    status,
                //    MessageBoxButtons.OK);
                // --- DEL 2009/02/17 --------------------------------<<<<<
                // --- ADD 2009/02/17 -------------------------------->>>>>
                TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_STOPDISP,
                        this.Name,
                        "保存に失敗しました。" + "\r\n" + "\r\n" +
                        "シェアチェックエラー（拠点ロック）です。" + "\r\n" +
                        "締処理か、処理が込み合っているためタイムアウトしました。" + "\r\n" +
                        "再試行するか、しばらく待ってから再度処理を行ってください。" + "\r\n",
                        status,
                        MessageBoxButtons.OK);
                // --- ADD 2009/02/17 --------------------------------<<<<<
            }
            else if (status == (int)ConstantManagement.DB_Status.ctDB_WAR_LOCK_TIMEOUT)
            {
                // --- DEL 2009/02/17 -------------------------------->>>>>
                //TMsgDisp.Show(this,
                //    emErrorLevel.ERR_LEVEL_INFO,
                //    this.Name,
                //    "シェアチェックエラー(倉庫ロック)です。" + "\r\n"
                //    + "棚卸処理か、その他の在庫業務を行っているためタイムアウトしました。" + "\r\n"
                //    + "再試行するか、しばらく待ってから再度処理を行ってください。",
                //    status,
                //    MessageBoxButtons.OK);
                // --- DEL 2009/02/17 --------------------------------<<<<<
                // --- ADD 2009/02/17 -------------------------------->>>>>
                TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_STOPDISP,
                        this.Name,
                        "保存に失敗しました。" + "\r\n" + "\r\n" +
                        "シェアチェックエラー（倉庫ロック）です。" + "\r\n" +
                        "棚卸処理か、その他の在庫業務を行っているためタイムアウトしました" + "\r\n" +
                        "再試行するか、しばらく待ってから再度処理を行ってください。" + "\r\n",
                        status,
                        MessageBoxButtons.OK);
                // --- ADD 2009/02/17 --------------------------------<<<<<
            }
            // --- ADD 2009/02/02 --------------------------------<<<<<
            else
            {
                // エラー
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, this.Name, msg, -1, MessageBoxButtons.OK);
            }
        }
        #endregion

        // チェック関連
        #region ▼CheckInputValueSupplierCd(発注先入力チェック)
        /// <summary>
        /// 発注先入力チェック
        /// </summary>
        /// <returns>-1：NG、0：入力なし、1：OK</returns>
        /// <remarks>
        /// <br>Note		: 発注先の入力状態をチェックします。</br>
        /// <br>Programmer	: 照田 貴志</br>
        /// <br>Date		: 2008/09/04</br>
        /// </remarks>
        private int CheckInputValueSupplierCd()
        {
            // 値なし
            if (string.IsNullOrEmpty(this.tNedit_SupplierCd.Text))
            {
                this.uLabel_SupplierSNm.Text = string.Empty;
                return CHECKDATA_CNDTNEMPTY;
            }

            // 名称取得
            string uoeSupplierName = string.Empty;
            //bool status = this._uoeEnterUpdAcs.GetSupplierName(this.tNedit_SupplierCd.GetInt(), out uoeSupplierName);         //DEL 2009/01/19 不具合対応[10063]
            bool status = this._uoeEnterUpdAcs.GetUOESupplierName(this.tNedit_SupplierCd.GetInt(), out uoeSupplierName);        //ADD 2009/01/19 不具合対応[10063]
            if (status == false)
            {
                // 取得失敗
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, this.Name, MESSAGE_INVALID_SUPPLIER, -1, MessageBoxButtons.OK);
                return CHECKDATA_FAILED;
            }

            // 取得成功
            this.uLabel_SupplierSNm.Text = uoeSupplierName;
            return CHECKDATA_SUCCESS;
        }
        #endregion

        #region ▼CheckInputValueSlipNo(納品書No.入力チェック)
        /// <summary>
        /// 納品書No.入力チェック
        /// </summary>
        /// <returns>-1：NG、0：入力なし、1：OK</returns>
        /// <remarks>
        /// <br>Note		: 納品書No.の入力状態をチェックします。</br>
        /// <br>Programmer	: 照田 貴志</br>
        /// <br>Date		: 2008/09/04</br>
        /// </remarks>
        private int CheckInputValueSlipNo()
        {
            // 値なし
            if (string.IsNullOrEmpty(this.tEdit_SlipNo.Text))
            {
                return CHECKDATA_CNDTNEMPTY;
            }

            // 取得成功
            return CHECKDATA_SUCCESS;
        }
        #endregion

        #region ▼CheckGrid(更新時グリッド状態チェック)
        /// <summary>
        /// 更新時グリッド状態チェック
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note		: グリッドの各状態をチェックします。</br>
        /// <br>Programmer	: 照田 貴志</br>
        /// <br>Date		: 2008/09/04</br>
        /// </remarks>
        private bool CheckGrid(out string msg)
        {
            msg = string.Empty;

            // グリッドにデータなし
            if ((this._headerForm.uGrid_Header.Rows.Count == 0) || (this._detailForm.uGrid_Detail.Rows.Count == 0))
            {
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, this.Name, "対象データがありません。", -1, MessageBoxButtons.OK);
                return false;
            }

            // 区分が「1：入庫」「3：明細修正」「9：消し込み」の場合に伝票番号が入っているか
            int errorRow = 0;
            if (this._uoeEnterUpdAcs.CheckSlipNoIsNullOrEmpty(out errorRow) == false)
            {
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, this.Name, "伝票番号が入力されていません。", -1, MessageBoxButtons.OK);

                this._headerForm.Focus();
                this._headerForm.SetFocusDivCdColumn(errorRow);
                return false;
            }

            // ---ADD 2009/02/05 不具合対応[10974] ------------------------------------------------------------------------------------------->>>>>
            int status = this._uoeEnterUpdAcs.CheckDayPayment(out errorRow);
            if (status == -1)
            {
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, this.Name, "仕入日が前回月次更新日以前になっています。", -1, MessageBoxButtons.OK);

                this._headerForm.Focus();
                this._headerForm.SetFocusDivCdColumn(errorRow);
                return false;
            }
            else if (status == -2)
            {
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, this.Name, "仕入日が前回請求日以前になっています。", -1, MessageBoxButtons.OK);

                this._headerForm.Focus();
                this._headerForm.SetFocusDivCdColumn(errorRow);
                return false;
            }
            // ---ADD 2009/02/05 不具合対応[10974] -------------------------------------------------------------------------------------------<<<<<

            return true;
        }
        #endregion

        // 入力値リカバリー関連
        #region ▼BackupInputValue(入力値の保持－全て)
        /// <summary>
        /// 入力値保存
        /// </summary>
        /// <remarks>
        /// <br>Note		: 入力値を保存します。</br>
        /// <br>Programmer	: 照田 貴志</br>
        /// <br>Date		: 2008/09/04</br>
        /// </remarks>
        private void BackupInputValueAll()
        {
            this.BackupInputValue(this.tComboEditor_ProcessDiv);    // 処理区分
            this.BackupInputValue(this.tNedit_SupplierCd);          // 仕入先
            this.BackupInputValue(this.tEdit_SlipNo);               // 納品書No.
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
        /// <br>Date		: 2008/09/04</br>
        /// </remarks>
        private void BackupInputValue(Control ctrl)
        {
            // 処理区分
            if (ctrl == this.tComboEditor_ProcessDiv)
            {
                this._backup.ProcessDiv = (int)this.tComboEditor_ProcessDiv.Value;
                return;
            }

            // 仕入先
            if (ctrl == this.tNedit_SupplierCd)
            {
                this._backup.SupplierCd = this.tNedit_SupplierCd.GetInt();
                this._backup.SupplierName = this.uLabel_SupplierSNm.Text;
                return;
            }
            // 納品書No.
            if (ctrl == this.tEdit_SlipNo)
            {
                this._backup.SupplierSlipNo = this.tEdit_SlipNo.Text;
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
        /// <br>Date		: 2008/09/04</br>
        /// </remarks>
        private void RecoverInputValue(Control ctrl)
        {
            // 処理区分
            if (ctrl == this.tComboEditor_ProcessDiv)
            {
                this.tComboEditor_ProcessDiv.Value = this._backup.ProcessDiv;
                return;
            }

            // 仕入先
            if (ctrl == this.tNedit_SupplierCd)
            {
                if (this._backup.SupplierCd == 0)
                {
                    this.tNedit_SupplierCd.Clear();
                    this.uLabel_SupplierSNm.Text = string.Empty;
                }
                else
                {
                    this.tNedit_SupplierCd.Value = this._backup.SupplierCd;
                    this.uLabel_SupplierSNm.Text = this._backup.SupplierName;
                }
                return;
            }
            // 納品書No.
            if (ctrl == this.tEdit_SlipNo)
            {
                if (string.IsNullOrEmpty(this._backup.SupplierSlipNo))
                {
                    this.tEdit_SlipNo.Clear();
                }
                else
                {
                    this.tEdit_SlipNo.Value = this._backup.SupplierSlipNo;
                }
                return;
            }
        }
        #endregion
    }
}
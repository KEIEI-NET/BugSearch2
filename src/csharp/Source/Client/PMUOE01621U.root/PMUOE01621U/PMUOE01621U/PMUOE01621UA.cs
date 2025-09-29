//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 日産回答データ取込処理
// プログラム概要   : UOE発注データと発注回答データのつけ合わせを行い、
//                    売上・仕入データの作成を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  10601190-00 作成担当 : 李占川
// 作 成 日  2010/03/08  修正内容 : 新規作成
//                                 【要件No.6】UOE発注データと発注回答データのつけ合わせを行い、売上・仕入データの作成を行う
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日              修正内容 : 
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Application.Common;
using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Windows.Forms;
using System.IO;
using System.Collections;
using Broadleaf.Application.Controller;
using System.Diagnostics;
using Broadleaf.Library.Diagnostics;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 日産回答データ取込処理入力フォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 日産回答データ取込処理の入力フォームクラスです。</br>
    /// <br>Programmer : 李占川</br>
    /// <br>Date       : 2010/03/08</br>
    /// <br>UpdateNote : </br>
    /// <br></br>
    /// </remarks>
    public partial class PMUOE01621UA : Form
    {
        // ===================================================================================== //
        // コンストラクタ
        // ===================================================================================== //
        # region コンストラクタ
        /// <summary>
        /// 日産回答データ取込処理入力フォームクラス デフォルトコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 日産回答データ取込処理のコンストラクタです。</br>      
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2010/03/08</br>
        /// </remarks>
        public PMUOE01621UA()
        {
            InitializeComponent();

            // 企業コード取得
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            this._loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;

            this._uOEOrderDtlNissanAcs = new UOEOrderDtlNissanAcs();
            this._dataTable = this._uOEOrderDtlNissanAcs.DetailDataTable;
        }
        # endregion コンストラクタ

        // ===================================================================================== //
        // プライベート定数
        // ===================================================================================== //
        # region Private Constant
        // ツールバーツールキー設定
        private const string TOOLBAR_CLOSEBUTTON_KEY = "ButtonTool_Close";
        private const string TOOLBAR_CONFIRMBUTTON_KEY = "ButtonTool_Confirm";
        private const string TOOLBAR_SEARCHBUTTON_KEY = "ButtonTool_Search";
        private const string TOOLBAR_LOGINNAMELABLE_KEY = "LableTool_LoginName";
        private const string TOOLBAR_LOGINLABEL_TITLE = "LableTool_LoginTitle";

        private const string ASSEMBLY_ID = "PMUOE01621U";

        private const int INIT_MODE = 0;
        private const int AFTERSEARCH_MODE = 1;
        # endregion

        // ===================================================================================== //
        // プライベート変数
        // ===================================================================================== //
        # region Private Members
        // 企業コード取得用
        private string _enterpriseCode;
        // ログイン拠点(自拠点)
        private string _loginSectionCode;

        // アクセスクラス
        private UOEOrderDtlNissanAcs _uOEOrderDtlNissanAcs;

        private DataTable _dataTable;

        private Dictionary<int, UOESupplier> _uOESupplierDic;

        private ImageList _imageList16 = null;											// イメージリスト
        private Infragistics.Win.UltraWinToolbars.ButtonTool _closeButton;				// 終了ボタン
        private Infragistics.Win.UltraWinToolbars.ButtonTool _confirmButton;			// 確定ボタン
        private Infragistics.Win.UltraWinToolbars.ButtonTool _searchButton;			    // 検索ボタン
        private Infragistics.Win.UltraWinToolbars.LabelTool _loginTitleLabel;		    // ログイン担当者名称
        private Infragistics.Win.UltraWinToolbars.LabelTool _loginNameLabel;            // ログイン担当者名称

        # endregion Private Members

        // ===================================================================================== //
        // プライベート
        // ===================================================================================== //
        # region Private Method
        # region 画面初期化
        /// <summary>
        /// 初期画面設定
        /// </summary>
        /// <remarks>
        /// <br>Note        : 画面初期化時に発生します。</br>      
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2010/03/08</br>
        /// </remarks> 
        private void InitialScreenSetting()
        {
            // -----------------------------
            // ツールバー初期設定処理
            // -----------------------------
            this._imageList16 = IconResourceManagement.ImageList16;
            this.tToolbarsManager_MainMenu.ImageListSmall = this._imageList16;

            // 終了のアイコン設定
            this._closeButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools[TOOLBAR_CLOSEBUTTON_KEY];
            if (this._closeButton != null)
            {
                this._closeButton.SharedProps.AppearancesSmall.Appearance.Image = this._imageList16.Images[(int)Size16_Index.CLOSE];
            }

            // 確定のアイコン設定
            this._confirmButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools[TOOLBAR_CONFIRMBUTTON_KEY];
            if (this._confirmButton != null)
            {
                this._confirmButton.SharedProps.AppearancesSmall.Appearance.Image = this._imageList16.Images[(int)Size16_Index.SAVE];
            }

            // 検索のアイコン設定
            this._searchButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools[TOOLBAR_SEARCHBUTTON_KEY];
            if (this._searchButton != null)
            {
                this._searchButton.SharedProps.AppearancesSmall.Appearance.Image = this._imageList16.Images[(int)Size16_Index.SEARCH];
            }

            // ログイン担当者のアイコン設定
            this._loginTitleLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)tToolbarsManager_MainMenu.Tools[TOOLBAR_LOGINLABEL_TITLE];
            if (this._loginTitleLabel != null)
            {
                this._loginTitleLabel.SharedProps.AppearancesSmall.Appearance.Image = this._imageList16.Images[(int)Size16_Index.EMPLOYEE];
            }
        }
        # endregion 画面初期化

        # region 画面データ初期化
        /// <summary>
        /// 初期画面のデータ
        /// </summary>
        /// <remarks>
        /// <br>Note        : 画面初期化時に発生します。</br>      
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2010/03/08</br>
        /// </remarks> 
        private void InitialScreenData()
        {
            // ログイン担当者名
            this._loginNameLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)tToolbarsManager_MainMenu.Tools[TOOLBAR_LOGINNAMELABLE_KEY];
            if (this._loginNameLabel != null && LoginInfoAcquisition.Employee != null)
            {
                Employee employee = new Employee();
                employee = LoginInfoAcquisition.Employee;
                this._loginNameLabel.SharedProps.Caption = employee.Name;
            }

            this._uOESupplierDic = new Dictionary<int, UOESupplier>();
            // 発注先の算出
            this.LoadUOESupplier();

            // 発注先のComboEditorデータ初期化
            this.InitialUOESupplierCombo();
        }
        # endregion 画面データ初期化

        # region 発注先のComboEditorデータ初期化
        /// <summary>
        /// 発注先のComboEditorデータ初期化
        /// </summary>
        /// <remarks>
        /// <br>Note        : 発注先のComboEditorデータ初期化処理を行います。</br>      
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2010/03/08</br>
        /// </remarks> 
        private void InitialUOESupplierCombo()
        {
            if (this._uOESupplierDic.Count == 0) return;

            // 発注先
            this.tComboEditor_UOESupplier.Items.Clear();
            foreach (KeyValuePair<int, UOESupplier> kvp in this._uOESupplierDic)
            {
                this.tComboEditor_UOESupplier.Items.Add(kvp.Key, kvp.Key.ToString("000000") + ":" + kvp.Value.UOESupplierName);
            }

            this.tComboEditor_UOESupplier.SelectedIndex = 0;
        }
        # endregion

        # region 発注先の算出
        /// <summary>
        /// 発注先の算出
        /// </summary>
        /// <remarks>
        /// <br>Note        : 発注先の算出処理を行います。</br>      
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2010/03/08</br>
        /// </remarks> 
        private void LoadUOESupplier()
        {
            // 発注先と回答保存フォルダ
            ArrayList uOESupplierList;
            int status = this._uOEOrderDtlNissanAcs.GetUOESupplier(out uOESupplierList, this._enterpriseCode, this._loginSectionCode);

            switch (status)
            {
                case 0:
                    foreach (UOESupplier uOESupplier in uOESupplierList)
                    {
                        this._uOESupplierDic.Add(uOESupplier.UOESupplierCd, uOESupplier);
                    }
                    break;
                default:
                    ShowMessageBox(emErrorLevel.ERR_LEVEL_STOP,
                       "InitialScreenData",
                       "その他異常が発生しました。",
                       0,
                       MessageBoxButtons.OK);
                    this.Close();
                    break;
            }
        }
        # endregion

        #region 画面設定
        /// <summary>
        /// コントロールFocus設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : コントロールFocusを設定する</br>
        /// <br>Programer  : 李占川</br>
        /// <br>Date       : 2010/03/08</br>
        /// </remarks>
        private void SetControlFocus(Control control)
        {
            if (control == null) return;

            // Focus設定
            control.Focus();

            this.SetStatusBarMsg(control);
        }

        /// <summary>
        /// StatusBarのメッセージ設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : StatusBarのメッセージを設定する</br>
        /// <br>Programer  : 李占川</br>
        /// <br>Date       : 2010/03/08</br>
        /// </remarks>
        private void SetStatusBarMsg(Control control)
        {
            // controlが未設定場合
            if (control == null) return;

            // 発注先
            if (control == this.tComboEditor_UOESupplier)
            {
                this.MainStatusBar.Panels["Text"].Text = "発注先を選択して下さい。";
            }
            // その他
            else
            {
                this.MainStatusBar.Panels["Text"].Text = string.Empty;
            }
        }

        /// <summary>
        /// コントロールEnabled制御処理
        /// </summary>
        /// <param name="mode">編集モード</param>
        /// <remarks>
        /// <br>Note       : コントロールのEnabled制御を行います。</br>
        /// <br>Programer  : 李占川</br>
        /// <br>Date       : 2010/03/08</br>
        /// </remarks>
        private void SetControlEnabled(int mode)
        {
            switch (mode)
            {
                // 初期化時
                case INIT_MODE:
                    {
                        this._closeButton.SharedProps.Enabled = true;
                        this._confirmButton.SharedProps.Enabled = false;
                        this._searchButton.SharedProps.Enabled = true;
                        this.tComboEditor_UOESupplier.Enabled = true;
                        this.tEdit_AnswerSaveFolder.Enabled = false;
                        break;
                    }
                // 検索結果がある時
                case AFTERSEARCH_MODE:
                    {
                        this._closeButton.SharedProps.Enabled = true;
                        this._confirmButton.SharedProps.Enabled = true;
                        this._searchButton.SharedProps.Enabled = false;
                        this.tComboEditor_UOESupplier.Enabled = false;
                        this.tEdit_AnswerSaveFolder.Enabled = false;
                        break;
                    }
            }
        }
        # endregion 画面設定

        # region 検索処理
        /// <summary>
        ///　検索処理(SearchProc())
        /// </summary>
        /// <remarks>
        /// <br>Note　　　  : 検索処理を行います。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2010/03/08</br>
        /// </remarks>
        private void SearchProc()
        {
            // データセットクリア
            this._uOEOrderDtlNissanAcs.DataTableClear();

            // 入力チェック
            if (this.CheckInputScreen() != true)
            {
                this.uLabel_UOESupplier.Focus();
                this.SetControlFocus(this.tComboEditor_UOESupplier);

                return;
            }

            // 画面情報データクラス格納処理
            AnswerDateNissanPara answerDateNissanPara = new AnswerDateNissanPara();
            this.ScreenToAnswerDateNissanPara(ref answerDateNissanPara);

            SFCMN00299CA form = new SFCMN00299CA();
            // 表示文字を設定
            form.Title = "検索処理中";
            form.Message = "検索処理中です";

            // 注文一覧ＣＳＶファイルの取得
            string resultMessage = string.Empty;
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            try
            {
                // ダイアログ表示
                form.Show();
                this.Cursor = Cursors.WaitCursor;
                status = this._uOEOrderDtlNissanAcs.DoSearch(answerDateNissanPara, out resultMessage);

                this.Cursor = Cursors.Default;
            }
            finally
            {
                // ダイアログを閉じる
                form.Close();
            }

            emErrorLevel errLevel = emErrorLevel.ERR_LEVEL_INFO;
            switch (status)
            {
                case (int)ConstantManagement.MethodResult.ctFNC_NORMAL:
                    this.SetControlEnabled(AFTERSEARCH_MODE);
                    break;
                case (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN:
                    resultMessage = "該当データが存在しません。";
                    errLevel = emErrorLevel.ERR_LEVEL_INFO;

                    this.ShowMessageBox(errLevel,
                            "SearchProc",
                            resultMessage,
                            status,
                            MessageBoxButtons.OK);

                    break;
                case (int)ConstantManagement.MethodResult.ctFNC_WARNING:
                    DialogResult dialogResult = this.ShowMessageBox(errLevel,
                                                    "SearchProc",
                                                    resultMessage,
                                                    status,
                                                    MessageBoxButtons.RetryCancel);

                    if (dialogResult == DialogResult.Retry)
                    {
                        this.SearchProc();
                    }
                    break;
                default:    // その他エラー
                    errLevel = emErrorLevel.ERR_LEVEL_STOP;

                    this.ShowMessageBox(errLevel,
                            "SearchProc",
                            resultMessage,
                            status,
                            MessageBoxButtons.OK);
                    break;
            }

            this.uLabel_UOESupplier.Focus();
            this.SetControlFocus(this.tComboEditor_UOESupplier);
        }
        # endregion 検索処理

        # region 確定処理
        /// <summary>
        ///　確定処理(ConfirmProc())
        /// </summary>
        /// <remarks>
        /// <br>Note　　　  : 確定処理を行います。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2010/03/08</br>
        /// <br>UpdateNote  : </br>
        /// </remarks>
        private void ConfirmProc()
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            string resultMessage = string.Empty;

            // 画面情報データクラス格納処理
            AnswerDateNissanPara answerDateNissanPara = new AnswerDateNissanPara();
            this.ScreenToAnswerDateNissanPara(ref answerDateNissanPara);

            SFCMN00299CA form = new SFCMN00299CA();
            // 表示文字を設定
            form.Title = "取込処理中";
            form.Message = "取込処理中です";

            // 進捗表示用フォームを設定
            this._uOEOrderDtlNissanAcs.ProgressForm = form;

            try
            {
                // ダイアログ表示
                form.Show();
                this.Cursor = Cursors.WaitCursor;

                // 確定処理
                status = this._uOEOrderDtlNissanAcs.DoConfirm(answerDateNissanPara, out resultMessage);

                this.Cursor = Cursors.Default;
            }
            finally
            {
                // ダイアログを閉じる
                form.Close();
            }

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:    // 処理成功
                    {
                        // 画面情報クリア処理
                        this.ClearScreen();
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        // 排他処理
                        ExclusiveTransaction(status);
                        break;
                    }
                default:    // その他エラー
                    {
                        this.ShowMessageBox(emErrorLevel.ERR_LEVEL_STOP,
                                "ConfirmProc",
                                resultMessage,
                                status,
                                MessageBoxButtons.OK);
                        break;
                    }
            }
        }
        # endregion

        # region チェック処理
        /// <summary>
        /// 画面情報入力チェック処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note        : 画面情報の入力チェックを行います。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2010/03/08</br>
        /// </remarks>
        private bool CheckInputScreen()
        {
            string errMsg = "";

            try
            {
                // 発注先が未選択の場合
                if (this.tComboEditor_UOESupplier.SelectedIndex == -1)
                {
                    errMsg = "発注先が選択されていません。";
                    return false;
                }

                string answerSaveFolder = this.tEdit_AnswerSaveFolder.DataText;

                // 回答保存フォルダが未入力時の場合
                if (answerSaveFolder == string.Empty)
                {
                    errMsg = "回答保存フォルダが未入力です。UOE発注先マスタの設定をご確認ください。";
                    return false;
                }

                // 設定された回答保存フォルダが存在しない場合
                if (!Directory.Exists(answerSaveFolder))
                {
                    errMsg = "回答保存フォルダがありません。";
                    return false;
                }

                // 回答保存フォルダにトヨタ発注回答ファイルが存在しない場合
                if (!File.Exists(answerSaveFolder + "\\HKAITO.DAT")
                    && !File.Exists(answerSaveFolder + "\\Order.csv")
                    && !File.Exists(answerSaveFolder + "\\OrderAns.csv"))
                {
                    errMsg = "回答保存フォルダに発注回答ファイルがありません。";
                    return false;
                }
            }
            finally
            {
                if (errMsg.Length > 0)
                {
                    this.ShowMessageBox(emErrorLevel.ERR_LEVEL_INFO
                                 , "CheckInputScreen"
                                 , errMsg
                                 , 0
                                 , MessageBoxButtons.OK);
                }
            }
            return true;
        }

        /// <summary>
        /// 編集中のデータチェック処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note        : 編集中のデータチェックを行います。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2010/03/08</br>
        /// </remarks>
        private bool EditCheck()
        {
            // 検索結果がある場合
            if (this.Detail_uGrid.Rows.Count > 0)
            {
                return true;
            }

            return false;
        }
        # endregion チェック処理

        # region 画面情報取得
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// 画面情報データクラス格納処理
        /// </summary>
        /// <param name="answerDateNissanPara">データクラスオブジェクト</param>
        /// <remarks>
        /// <br>Note        : 画面情報からデータクラスオブジェクトにデータを格納します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2010/03/08</br>
        /// </remarks>
        private void ScreenToAnswerDateNissanPara(ref AnswerDateNissanPara answerDateNissanPara)
        {
            if (answerDateNissanPara == null)
            {
                // 新規の場合
                answerDateNissanPara = new AnswerDateNissanPara();
            }

            // 企業コード
            answerDateNissanPara.EnterpriseCode = this._enterpriseCode;
            // 拠点コード
            answerDateNissanPara.SectionCode = this._loginSectionCode;
            // UOE発注先コード
            answerDateNissanPara.UOESupplierCd = (int)this.tComboEditor_UOESupplier.SelectedItem.DataValue;
            // 回答保存フォルダ
            answerDateNissanPara.AnswerSaveFolder = this.tEdit_AnswerSaveFolder.DataText.Trim();

            UOESupplier outUOESupplier;
            this._uOESupplierDic.TryGetValue((int)this.tComboEditor_UOESupplier.SelectedItem.DataValue, out outUOESupplier);
        }
        # endregion

        # region Grid関連
        /// <summary>
        /// グリッド列初期設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note		: 画面初期化の時、グリッド列初期設定を行います。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2010/03/08</br>
        /// </remarks>
        private void InitialSettingGridCol()
        {
            Infragistics.Win.UltraWinGrid.UltraGridBand editBand = this.Detail_uGrid.DisplayLayout.Bands[0];
            if (editBand == null) return;

            editBand.ColHeadersVisible = true;

            //---------------------------------------------------------------------
            // 表示幅設定
            //---------------------------------------------------------------------
            editBand.Columns[NissanWebUOEOrderDtlInfoBuilder.NO].Width = 34;
            editBand.Columns[NissanWebUOEOrderDtlInfoBuilder.GOODSNO].Width = 180;
            editBand.Columns[NissanWebUOEOrderDtlInfoBuilder.GOODSMAKERCD].Width = 44;
            editBand.Columns[NissanWebUOEOrderDtlInfoBuilder.GOODSNAME].Width = 190;
            editBand.Columns[NissanWebUOEOrderDtlInfoBuilder.COUNT].Width = 90;
            editBand.Columns[NissanWebUOEOrderDtlInfoBuilder.ANSWERPARTSNO].Width = 210;
            editBand.Columns[NissanWebUOEOrderDtlInfoBuilder.LISTPRICE].Width = 80;
            editBand.Columns[NissanWebUOEOrderDtlInfoBuilder.SALESUNITCOST].Width = 80;
            editBand.Columns[NissanWebUOEOrderDtlInfoBuilder.COMMENT].Width = 110;
            editBand.Columns[NissanWebUOEOrderDtlInfoBuilder.UOESECTIONSLIPNO].Width = 60;
            editBand.Columns[NissanWebUOEOrderDtlInfoBuilder.UOESECTOUTGOODSCNT].Width = 110;
            editBand.Columns[NissanWebUOEOrderDtlInfoBuilder.BOSLIPNO1].Width = 94;
            editBand.Columns[NissanWebUOEOrderDtlInfoBuilder.BOSHIPMENTCNT1].Width = 80;
            editBand.Columns[NissanWebUOEOrderDtlInfoBuilder.BOSLIPNO2].Width = 94;
            editBand.Columns[NissanWebUOEOrderDtlInfoBuilder.BOSHIPMENTCNT2].Width = 80;
            editBand.Columns[NissanWebUOEOrderDtlInfoBuilder.BOSLIPNO3].Width = 94;
            editBand.Columns[NissanWebUOEOrderDtlInfoBuilder.BOSHIPMENTCNT3].Width = 80;
            editBand.Columns[NissanWebUOEOrderDtlInfoBuilder.BOMANAGEMENTNO].Width = 94;
            editBand.Columns[NissanWebUOEOrderDtlInfoBuilder.EOALWCCOUNT].Width = 94;
            editBand.Columns[NissanWebUOEOrderDtlInfoBuilder.MAKERFOLLOWCNT].Width = 100;

            //---------------------------------------------------------------------
            // 入力許可設定
            //---------------------------------------------------------------------
            editBand.Columns[NissanWebUOEOrderDtlInfoBuilder.NO].CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
            editBand.Columns[NissanWebUOEOrderDtlInfoBuilder.GOODSNO].CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
            editBand.Columns[NissanWebUOEOrderDtlInfoBuilder.GOODSMAKERCD].CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
            editBand.Columns[NissanWebUOEOrderDtlInfoBuilder.GOODSNAME].CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
            editBand.Columns[NissanWebUOEOrderDtlInfoBuilder.COUNT].CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
            editBand.Columns[NissanWebUOEOrderDtlInfoBuilder.ANSWERPARTSNO].CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
            editBand.Columns[NissanWebUOEOrderDtlInfoBuilder.LISTPRICE].CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
            editBand.Columns[NissanWebUOEOrderDtlInfoBuilder.SALESUNITCOST].CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
            editBand.Columns[NissanWebUOEOrderDtlInfoBuilder.COMMENT].CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
            editBand.Columns[NissanWebUOEOrderDtlInfoBuilder.UOESECTIONSLIPNO].CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
            editBand.Columns[NissanWebUOEOrderDtlInfoBuilder.UOESECTOUTGOODSCNT].CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
            editBand.Columns[NissanWebUOEOrderDtlInfoBuilder.BOSLIPNO1].CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
            editBand.Columns[NissanWebUOEOrderDtlInfoBuilder.BOSHIPMENTCNT1].CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
            editBand.Columns[NissanWebUOEOrderDtlInfoBuilder.BOSLIPNO2].CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
            editBand.Columns[NissanWebUOEOrderDtlInfoBuilder.BOSHIPMENTCNT2].CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
            editBand.Columns[NissanWebUOEOrderDtlInfoBuilder.BOSLIPNO3].CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
            editBand.Columns[NissanWebUOEOrderDtlInfoBuilder.BOSHIPMENTCNT3].CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
            editBand.Columns[NissanWebUOEOrderDtlInfoBuilder.MAKERFOLLOWCNT].CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
            editBand.Columns[NissanWebUOEOrderDtlInfoBuilder.BOMANAGEMENTNO].CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
            editBand.Columns[NissanWebUOEOrderDtlInfoBuilder.EOALWCCOUNT].CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;

            //---------------------------------------------------------------------
            // 詰め
            //---------------------------------------------------------------------
            editBand.Columns[NissanWebUOEOrderDtlInfoBuilder.NO].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            editBand.Columns[NissanWebUOEOrderDtlInfoBuilder.GOODSNO].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            editBand.Columns[NissanWebUOEOrderDtlInfoBuilder.GOODSMAKERCD].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            editBand.Columns[NissanWebUOEOrderDtlInfoBuilder.GOODSNAME].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            editBand.Columns[NissanWebUOEOrderDtlInfoBuilder.COUNT].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            editBand.Columns[NissanWebUOEOrderDtlInfoBuilder.ANSWERPARTSNO].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            editBand.Columns[NissanWebUOEOrderDtlInfoBuilder.LISTPRICE].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            editBand.Columns[NissanWebUOEOrderDtlInfoBuilder.SALESUNITCOST].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            editBand.Columns[NissanWebUOEOrderDtlInfoBuilder.COMMENT].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            editBand.Columns[NissanWebUOEOrderDtlInfoBuilder.UOESECTIONSLIPNO].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            editBand.Columns[NissanWebUOEOrderDtlInfoBuilder.UOESECTOUTGOODSCNT].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            editBand.Columns[NissanWebUOEOrderDtlInfoBuilder.BOSLIPNO1].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            editBand.Columns[NissanWebUOEOrderDtlInfoBuilder.BOSHIPMENTCNT1].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            editBand.Columns[NissanWebUOEOrderDtlInfoBuilder.BOSLIPNO2].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            editBand.Columns[NissanWebUOEOrderDtlInfoBuilder.BOSHIPMENTCNT2].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            editBand.Columns[NissanWebUOEOrderDtlInfoBuilder.BOSLIPNO3].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            editBand.Columns[NissanWebUOEOrderDtlInfoBuilder.BOSHIPMENTCNT3].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            editBand.Columns[NissanWebUOEOrderDtlInfoBuilder.MAKERFOLLOWCNT].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            editBand.Columns[NissanWebUOEOrderDtlInfoBuilder.BOMANAGEMENTNO].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            editBand.Columns[NissanWebUOEOrderDtlInfoBuilder.EOALWCCOUNT].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;

            //---------------------------------------------------------------------
            // 詰め(header)
            //---------------------------------------------------------------------
            editBand.Columns[NissanWebUOEOrderDtlInfoBuilder.NO].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            editBand.Columns[NissanWebUOEOrderDtlInfoBuilder.GOODSNO].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            editBand.Columns[NissanWebUOEOrderDtlInfoBuilder.GOODSMAKERCD].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            editBand.Columns[NissanWebUOEOrderDtlInfoBuilder.GOODSNAME].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            editBand.Columns[NissanWebUOEOrderDtlInfoBuilder.COUNT].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            editBand.Columns[NissanWebUOEOrderDtlInfoBuilder.ANSWERPARTSNO].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            editBand.Columns[NissanWebUOEOrderDtlInfoBuilder.LISTPRICE].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            editBand.Columns[NissanWebUOEOrderDtlInfoBuilder.SALESUNITCOST].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            editBand.Columns[NissanWebUOEOrderDtlInfoBuilder.COMMENT].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            editBand.Columns[NissanWebUOEOrderDtlInfoBuilder.UOESECTIONSLIPNO].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            editBand.Columns[NissanWebUOEOrderDtlInfoBuilder.UOESECTOUTGOODSCNT].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            editBand.Columns[NissanWebUOEOrderDtlInfoBuilder.BOSLIPNO1].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            editBand.Columns[NissanWebUOEOrderDtlInfoBuilder.BOSHIPMENTCNT1].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            editBand.Columns[NissanWebUOEOrderDtlInfoBuilder.BOSLIPNO2].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            editBand.Columns[NissanWebUOEOrderDtlInfoBuilder.BOSHIPMENTCNT2].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            editBand.Columns[NissanWebUOEOrderDtlInfoBuilder.BOSLIPNO3].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            editBand.Columns[NissanWebUOEOrderDtlInfoBuilder.BOSHIPMENTCNT3].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            editBand.Columns[NissanWebUOEOrderDtlInfoBuilder.MAKERFOLLOWCNT].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            editBand.Columns[NissanWebUOEOrderDtlInfoBuilder.BOMANAGEMENTNO].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            editBand.Columns[NissanWebUOEOrderDtlInfoBuilder.EOALWCCOUNT].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;

            //---------------------------------------------------------------------
            // フォーマット設定
            //---------------------------------------------------------------------
            string codeFormat = "#";
            string codeFormat_GoodsMakerCd = "0000";
            string numFormat = "#,###";

            editBand.Columns[NissanWebUOEOrderDtlInfoBuilder.GOODSNO].Format = codeFormat; // 品番
            editBand.Columns[NissanWebUOEOrderDtlInfoBuilder.GOODSMAKERCD].Format = codeFormat_GoodsMakerCd; // メーカー
            editBand.Columns[NissanWebUOEOrderDtlInfoBuilder.COUNT].Format = numFormat; // 数量
            editBand.Columns[NissanWebUOEOrderDtlInfoBuilder.LISTPRICE].Format = numFormat; // 定価
            editBand.Columns[NissanWebUOEOrderDtlInfoBuilder.SALESUNITCOST].Format = numFormat; //単価
            editBand.Columns[NissanWebUOEOrderDtlInfoBuilder.UOESECTOUTGOODSCNT].Format = numFormat; // UOE拠点出庫数
            editBand.Columns[NissanWebUOEOrderDtlInfoBuilder.BOSHIPMENTCNT1].Format = numFormat; // BO出庫数1
            editBand.Columns[NissanWebUOEOrderDtlInfoBuilder.BOSHIPMENTCNT2].Format = numFormat; // BO出庫数2
            editBand.Columns[NissanWebUOEOrderDtlInfoBuilder.BOSHIPMENTCNT3].Format = numFormat; // BO出庫数3
            editBand.Columns[NissanWebUOEOrderDtlInfoBuilder.MAKERFOLLOWCNT].Format = numFormat; // メーカーフォロー数
            editBand.Columns[NissanWebUOEOrderDtlInfoBuilder.EOALWCCOUNT].Format = numFormat; // EO引当数
        }
        # endregion Grid関連

        # region 画面情報クリア処理
        /// <summary>
        /// 画面情報クリア処理
        /// </summary>
        /// <remarks>
        /// <br>Note        : 画面情報クリア処理を行う。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2010/03/08</br>
        /// </remarks>
        private void ClearScreen()
        {
            // 発注先のComboEditorデータ初期化
            this.InitialUOESupplierCombo();

            // データセットクリア処理
            this._uOEOrderDtlNissanAcs.DataTableClear();

            // コントロールEnabled制御処理
            this.SetControlEnabled(INIT_MODE);

            // コントロールFocus設定処理
            this.uLabel_UOESupplier.Focus();
            this.SetControlFocus(this.tComboEditor_UOESupplier);
        }
        # endregion

        # region メッセージボックス表示
        /// <summary>
        /// メッセージボックス表示処理
        /// </summary>
        /// <param name="errLevel">エラーレベル</param>
        /// <param name="methodName">処理名称</param>
        /// <param name="message">表示するメッセージ</param>
        /// <param name="status">ステータス値</param>
        /// <param name="msgButton">表示するボタン</param>
        /// <returns>DialogResult</returns>
        /// <remarks>
        /// <br>Note       : メッセージボックスを表示します。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2010/03/08</br>
        /// </remarks>
        private DialogResult ShowMessageBox(emErrorLevel errLevel, string methodName, string message, int status, MessageBoxButtons msgButton)
        {
            DialogResult dialogResult;
            dialogResult = this.ShowMsg(this.Text,
                                        this, errLevel,
                                        ASSEMBLY_ID,
                                        message,
                                        status,
                                        msgButton,
                                        MessageBoxDefaultButton.Button1);

            return dialogResult;
        }

        /// <summary>
        /// メッセージの表示
        /// </summary>
        /// <param name="mainWindowTitle">タイトル</param>
        /// <param name="iWin">ウインドー</param>
        /// <param name="iLevel">エラーレベル</param>
        /// <param name="iPgid">プログラムID</param>
        /// <param name="iMsg">メッセージ</param>
        /// <param name="iSt">ステータス</param>
        /// <param name="iButton">ボタンタイプ</param>
        /// <param name="iDefButton">ボタンタイプ</param>
        /// <remarks>
        /// <br>Note       : メッセージボックスを表示します。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2010/03/08</br>
        /// </remarks>
        private DialogResult ShowMsg(string mainWindowTitle, IWin32Window iWin, emErrorLevel iLevel, string iPgid, string iMsg, int iSt, MessageBoxButtons iButton, MessageBoxDefaultButton iDefButton)
        {
            MessageBoxIcon hand = MessageBoxIcon.Hand;
            MessageBoxButtons oK = MessageBoxButtons.OK;
            string text = iMsg;
            switch (iLevel)
            {
                case emErrorLevel.ERR_LEVEL_STOP:
                case emErrorLevel.ERR_LEVEL_STOPDISP:
                case emErrorLevel.ERR_LEVEL_NODISP:
                    {
                        string[] strArray = System.Windows.Forms.Application.ExecutablePath.Split(new char[] { '\\' });
                        hand = MessageBoxIcon.Hand;
                        mainWindowTitle = "エラー発生 - ＜" + mainWindowTitle + "＞";
                        text = strArray[strArray.Length - 1] + "(" + iPgid + ") にてエラーが発生しました\n\n" + iMsg + " ST = " + iSt.ToString();
                        ClientLogTextOut @out = new ClientLogTextOut();
                        @out.Output(iPgid, iMsg, iSt);
                        if (iLevel == emErrorLevel.ERR_LEVEL_NODISP)
                        {
                            return DialogResult.OK;
                        }
                        break;
                    }
                case emErrorLevel.ERR_LEVEL_EXCLAMATION:
                    hand = MessageBoxIcon.Exclamation;
                    mainWindowTitle = "注意 - ＜" + mainWindowTitle + "＞";
                    break;

                case emErrorLevel.ERR_LEVEL_INFO:
                    hand = MessageBoxIcon.Asterisk;
                    mainWindowTitle = "情報 - ＜" + mainWindowTitle + "＞";
                    break;

                case emErrorLevel.ERR_LEVEL_QUESTION:
                    hand = MessageBoxIcon.Question;
                    mainWindowTitle = "確認 - ＜" + mainWindowTitle + "＞";
                    break;

                case emErrorLevel.ERR_LEVEL_CONFIRM:
                    hand = MessageBoxIcon.Question;
                    mainWindowTitle = "確認 - ＜" + mainWindowTitle + "＞";
                    text = "現在、編集中のデータが存在します\n\n" + iMsg + "終了してもよろしいですか？";
                    oK = MessageBoxButtons.YesNo;
                    break;

                case emErrorLevel.ERR_LEVEL_SAVECONFIRM:
                    hand = MessageBoxIcon.Question;
                    mainWindowTitle = "確認 - ＜" + mainWindowTitle + "＞";
                    text = "現在、編集中のデータが存在します\n\n" + iMsg + "登録してもよろしいですか？";
                    oK = MessageBoxButtons.YesNoCancel;
                    break;

                default:
                    return DialogResult.OK;
            }
            if (oK == MessageBoxButtons.OK)
            {
                oK = iButton;
            }
            if (iWin == null)
            {
                iWin = Form.ActiveForm;
                if (iWin == null)
                {
                    IntPtr handle = Process.GetCurrentProcess().MainWindowHandle;
                    if (handle != IntPtr.Zero)
                    {
                        Control control = Control.FromHandle(handle);
                        if ((control != null) && !control.IsDisposed)
                        {
                            iWin = control;
                        }
                    }
                    if (iWin == null)
                    {
                        if (System.Windows.Forms.Application.OpenForms.Count > 0)
                        {
                            iWin = System.Windows.Forms.Application.OpenForms[0];
                        }
                        if (iWin == null)
                        {
                            System.Windows.Forms.Application.DoEvents();
                            iWin = Form.ActiveForm;
                        }
                    }
                }
            }
            return MessageBox.Show(iWin, text, mainWindowTitle, oK, hand, iDefButton);
        }
        # endregion メッセージボックス表示

        # region ■ 排他処理 ■
        /// <summary>
        /// 排他処理
        /// </summary>
        /// <param name="status">ステータス</param>
        /// <remarks>
        /// <br>Note       : 排他制御を行います。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2010/03/08</br>
        /// </remarks>
        private void ExclusiveTransaction(int status)
        {
            string errMsg = "";

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    {
                        // 他端末更新
                        errMsg = "既に他端末より更新されています。";
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        // 他端末削除
                        errMsg = "既に他端末より削除されています。";
                        break;
                    }
            }

            this.ShowMessageBox(emErrorLevel.ERR_LEVEL_EXCLAMATION,
                    "ConfirmProc",
                    errMsg,
                    status,
                    MessageBoxButtons.OK);
        }
        # endregion ■ 排他処理
        # endregion Private Method

        // ===================================================================================== //
        // コントロールイベント
        // ===================================================================================== //
        # region Control Event Methods
        /// <summary>
        /// ロードイベント                                            
        /// </summary>
        /// <param name="sender">イベントソース</param>                            
        /// <param name="e">イベントデータ</param>
        /// <remarks>
        /// <br>Note        : 画面がロード時に発生します。</br>      
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2010/03/08</br>
        /// </remarks>
        private void PMUOE01621UA_Load(object sender, EventArgs e)
        {
            // 画面初期化
            this.InitialScreenSetting();

            // 画面データ初期化
            InitialScreenData();

            // コントロールEnabled制御処理
            this.SetControlEnabled(INIT_MODE);

            this.Detail_uGrid.DataSource = this._dataTable;

            Initial_Timer.Enabled = true;
        }

        /// <summary>
        /// ツールバークリックイベント
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントデータ</param>
        /// <remarks>
        /// <br>Note        : ツールバークリック時に発生します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2010/03/08</br>
        /// <br>UpdateNote  : </br>
        /// </remarks>
        private void tToolbarsManager_MainMenu_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                // 終了
                case TOOLBAR_CLOSEBUTTON_KEY:
                    {
                        if (this.EditCheck())
                        {
                            DialogResult dialogResult = TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                this.Name,
                                "現在、編集中のデータが存在します。" + "\r\n" + "\r\n" +
                                "実行して宜しいですか？",
                                0,
                                MessageBoxButtons.YesNo,
                                MessageBoxDefaultButton.Button1);

                            if (dialogResult == DialogResult.No)
                            {
                                return;
                            }
                        }

                        this.Close();
                        break;
                    }
                // 確定
                case TOOLBAR_CONFIRMBUTTON_KEY:
                    {
                        this.ConfirmProc();
                        break;
                    }
                // 検索
                case TOOLBAR_SEARCHBUTTON_KEY:
                    {
                        this.SearchProc();
                        break;
                    }
            }
        }

        /// <summary>
        /// Timer.Tick イベント(timer)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　  : 指定された間隔の時間が経過したときに発生します。
        ///					  この処理は、システムが提供するスレッド プール
        ///					  スレッドで実行されます。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2010/03/08</br>
        /// </remarks>
        private void Timer_Init_Tick(object sender, EventArgs e)
        {
            Initial_Timer.Enabled = false;

            this.SetControlFocus(this.tComboEditor_UOESupplier);
        }

        /// <summary>
        /// グリッド初期レイアウト設定イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note		: 画面初期化時、グリッド初期レイアウト設定を行います。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2010/03/08</br>
        /// </remarks>
        private void Detail_uGrid_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            // グリッド列初期設定処理
            this.InitialSettingGridCol();
        }

        /// <summary>
        /// ValueChangedイベント(tComboEditor_UOESupplier)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note        : ValueChangedイベント時に発生します。</br> 
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2010/03/08</br>
        /// </remarks>
        private void tComboEditor_UOESupplier_ValueChanged(object sender, EventArgs e)
        {

            UOESupplier outUOESupplier;
            this._uOESupplierDic.TryGetValue((int)this.tComboEditor_UOESupplier.SelectedItem.DataValue, out outUOESupplier);

            // 回答保存フォルダの設定
            this.tEdit_AnswerSaveFolder.DataText = outUOESupplier.AnswerSaveFolder;
        }

        /// <summary>
        /// ChangeFocus イベント(tRetKeyControl1)
        /// </summary>
        /// <param name="sender">イベントオブジェクト</param>
        /// <param name="e">イベント情報</param>
        /// <remarks>
        /// <br>Note		: 各コントロールからフォーカスが離れたときに発生します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2010/03/08</br>
        /// </remarks>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null || e.NextCtrl == null) return;

            // 発注先
            if (e.PrevCtrl == this.tComboEditor_UOESupplier)
            {
                // フォーカス設定
                if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                {
                    e.NextCtrl = this.tComboEditor_UOESupplier;
                }
            }

            if (e.NextCtrl != null)
            {
                // StatusBarのメッセージ設定処理
                this.SetStatusBarMsg(e.NextCtrl);
            }
        }
        # endregion Control Event Methods
    }
}
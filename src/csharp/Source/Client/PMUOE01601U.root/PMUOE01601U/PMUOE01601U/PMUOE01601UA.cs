//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 伝票番号引当処理
// プログラム概要   : 伝票番号引当処理
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 劉洋
// 作 成 日  2009/06/01  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 22018 鈴木正臣
// 修 正 日  2010/11/02  修正内容 : Adobe Reader9以降だと終了時エラー発生する件の対応。(WebBrowser解放処理の修正)
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Library.Windows.Forms;
using System.Collections;
using System.IO;
// --- ADD m.suzuki 2010/11/02 ---------->>>>>
using System.Runtime.InteropServices;
// --- ADD m.suzuki 2010/11/02 ----------<<<<<

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 伝票番号引当処理フォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 伝票番号引当処理を行います。</br>
    /// <br>Programmer : 劉洋</br>
    /// <br>Date       : 2008.06.01</br>
    /// <br>Update Note: 2010/11/02  22018 鈴木 正臣</br>
    /// <br>           : Adobe Reader9以降だと終了時エラー発生する件の対応。(WebBrowser解放処理の修正)</br>
    /// </remarks>
    public partial class PMUOE01601UA : Form
    {
        // --- ADD m.suzuki 2010/11/02 ---------->>>>>
        [DllImport( "ole32.dll" )]
        extern static void CoFreeUnusedLibraries();
        // --- ADD m.suzuki 2010/11/02 ----------<<<<<

        #region Constroctors
        /// <summary>
        /// 伝票番号引当処理フォームクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note		: 伝票番号引当処理フォームクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer	: 劉洋</br>
        /// <br>Date		: 2008.06.01</br>
        /// </remarks>
        public PMUOE01601UA()
        {
            InitializeComponent();
            // 変数初期化
            this._imageList16 = IconResourceManagement.ImageList16;

            this._loginTitleLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)tToolbarsManager_MainMenu.Tools["LabelTool_LoginTitle"];
            this._loginNameLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)this.tToolbarsManager_MainMenu.Tools["LabelTool_LoginName"];
            this._closeButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Close"];
            this._printButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Print"];
            this._previewButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Preview"];
            this._updateButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Update"];
            this._clearButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Clear"];

            // ガイド系アクセスクラス
            this._employeeAcs = new EmployeeAcs();

            // アクセスクラス
            _slipNoAlwcInputAcs = SlipNoAlwcInputAcs.GetInstance();
            _enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            this._loginNameLabel.SharedProps.Caption = LoginInfoAcquisition.Employee.Name;
        }
        #endregion

        // ===================================================================================== //
        // Private Members
        // ===================================================================================== //
        #region
        private ImageList _imageList16 = null;
        private Infragistics.Win.UltraWinToolbars.ButtonTool _closeButton;					// 終了ボタン
        private Infragistics.Win.UltraWinToolbars.ButtonTool _updateButton;					// 更新ボタン
        private Infragistics.Win.UltraWinToolbars.ButtonTool _clearButton;					// クリアボタン
        private Infragistics.Win.UltraWinToolbars.ButtonTool _printButton;	                // 印刷ボタン
        private Infragistics.Win.UltraWinToolbars.ButtonTool _previewButton;                // ＰＤＦ表示ボタン
        private Infragistics.Win.UltraWinToolbars.LabelTool _loginTitleLabel;				// ログイン担当者名称
        private Infragistics.Win.UltraWinToolbars.LabelTool _loginNameLabel;

        // アクセスクラス
        private SlipNoAlwcInputAcs _slipNoAlwcInputAcs = null;

        // ガイド系アクセスクラス
        EmployeeAcs _employeeAcs;

        // アセンブリID
        private const string ASSEMBLY_ID = "PMUOE01601U";
        private DCCMN04000UA _printControl = null;
        private string _enterpriseCode;             // 企業コード
        private const string cTAB_PREVIEW = "Preview";
        private Control _prevControl = null;									// 現在のコントロール
        #endregion


        // ===================================================================================== //
        //  Private Methods
        // ===================================================================================== //
        #region
        /// <summary>
        /// ボタン設定
        /// </summary>
        /// <remarks>
        /// <br>Note       : なし</br>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date       : 2009.06.01</br>
        /// </remarks>
        private void ButtonInitialSetting()
        {
            this.tToolbarsManager_MainMenu.ImageListSmall = this._imageList16;
            this._closeButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;
            this._updateButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SAVE;
            this._clearButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.ALLCANCEL;
            this._printButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.PRINT;
            this._previewButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.PREVIEW;
            this._loginTitleLabel.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.EMPLOYEE;

            this.EmployeeCode_Button.Appearance.Image = this._imageList16.Images[(int)Size16_Index.STAR1];
            this.AnswerSaveFolder_Button.Appearance.Image = this._imageList16.Images[(int)Size16_Index.STAR1];
        }


        /// <summary>
        /// コンボックス初期設定
        /// </summary>
        /// <remarks>
        /// <br>Note       : なし</br>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date       : 2009.06.01</br>
        /// </remarks>
        private void ComboxValueSetting()
        {
            this.ultraComboEditor_SupplierCode.Items.Clear();

            if (this._slipNoAlwcInputAcs.UOESupplierData.Count > 0)
            {
                int i = 0;
                foreach (UOESupplier uoeSupplier in this._slipNoAlwcInputAcs.UOESupplierData)
                {
                    Infragistics.Win.ValueListItem item = new Infragistics.Win.ValueListItem();
                    item.Tag = i + 1;
                    item.DataValue = i;
                    item.DisplayText = uoeSupplier.UOESupplierCd.ToString("000000") + ":" + uoeSupplier.UOESupplierName;
                    this.ultraComboEditor_SupplierCode.Items.Add(item);
                    i++;
                }
            }
            else
            {
                Infragistics.Win.ValueListItem item = new Infragistics.Win.ValueListItem();
                item.Tag = 1;
                item.DataValue = "";
                item.DisplayText = "";
                this.ultraComboEditor_SupplierCode.Items.Add(item);
            }
        }

        /// <summary>
        /// 初期化処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : なし</br>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date       : 2009.06.01</br>
        /// </remarks>
        private void Clear()
        {
            // データ取得
            string msg = string.Empty;
            this._slipNoAlwcInputAcs.ReadInitData(_enterpriseCode, LoginInfoAcquisition.Employee.BelongSectionCode, ref msg);

            // コンボックス設定
            this.ComboxValueSetting();

            // 画面初期化データ
            this._slipNoAlwcInputAcs.CreateSlipNoAlwcInitialData();
            // 画面初期化表示
            this.SetDisplay(this._slipNoAlwcInputAcs.SlipNoAlwcData);

            // 初期化ボタン
            this.BfUpdateButtonSetting();

            // ヘッダ入力項目設定
            this.HeaderEnabledSetting(true);

            // 明細クリア処理
            this._slipNoAlwcInputAcs.SlipNoAlwcDataTable.Clear();

            // 画面表示処理
            this.ultraTabControl1.Tabs[cTAB_PREVIEW].Visible = false;

            // フォーカス設定
            this.timer_SetFocus.Enabled = true;
        }

        
        /// <summary>
        /// 画面表示
        /// </summary>
        /// <param name="slipNoAlwcData">画面データ</param>
        /// <remarks>
        /// <br>Note       : なし</br>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date       : 2009.06.01</br>
        /// </remarks>
        private void SetDisplay(SlipNoAlwcData slipNoAlwcData)
        {
            if (slipNoAlwcData == null) return;

            this.ultraComboEditor_SupplierCode.BeginUpdate();
            this.tEdit_AnswerSaveFolder.BeginUpdate();
            this.tEdit_EmployeeCode.BeginUpdate();
            this.tEdit_EmployeeName.BeginUpdate();
            this.ultraComboEditor_PriceUpdate.BeginUpdate();
            this.ultraComboEditor_StockData.BeginUpdate();

            if (this._slipNoAlwcInputAcs.UOESupplierData.Count > 0)
            {
                this.ultraComboEditor_SupplierCode.Value = slipNoAlwcData.SupplierCode;
            }
            this.tEdit_AnswerSaveFolder.DataText = slipNoAlwcData.AnswerSaveFolder;
            this.tEdit_EmployeeCode.DataText = slipNoAlwcData.EmployeeCode;
            this.tEdit_EmployeeName.DataText = slipNoAlwcData.EmployeeName;
            this.ultraComboEditor_PriceUpdate.Value = slipNoAlwcData.PriceUpdateCode;
            this.ultraComboEditor_StockData.Value = slipNoAlwcData.StockDataCode;

            this.ultraComboEditor_SupplierCode.EndUpdate();
            this.tEdit_AnswerSaveFolder.EndUpdate();
            this.tEdit_EmployeeCode.EndUpdate();
            this.tEdit_EmployeeName.EndUpdate();
            this.ultraComboEditor_PriceUpdate.EndUpdate();
            this.ultraComboEditor_StockData.EndUpdate();
        }

        /// <summary>
        /// 初期化ボタン設定
        /// </summary>
        /// <remarks>
        /// <br>Note       : なし</br>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date       : 2009.06.01</br>
        /// </remarks>
        private void BfUpdateButtonSetting()
        {
            this._printButton.SharedProps.Enabled = false;
            this._previewButton.SharedProps.Enabled = false;
            this._updateButton.SharedProps.Enabled = true;
        }

        /// <summary>
        /// 確定後初期化ボタン設定
        /// </summary>
        /// <remarks>
        /// <br>Note       : なし</br>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date       : 2009.06.01</br>
        /// </remarks>
        private void AfUpdateButtonSetting()
        {
            this._updateButton.SharedProps.Enabled = false;
            this._printButton.SharedProps.Enabled = true;
            this._previewButton.SharedProps.Enabled = true;
        }

        /// <summary>
        /// 画面情報比較処理
        /// </summary>
        /// <param name="msg">メッセージ</param>
        /// <returns>ステータス(True:処理続行　False:処理中断)</returns>
        /// <remarks>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date       : 2009.06.05</br>
        /// </remarks>
        public bool CompareScreen(string msg)
        {
            // 画面情報比較
            if (!CompareOriginalScreen())
            {
                DialogResult res = ShowMessageBox(emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                                  msg,
                                                  0,
                                                  MessageBoxButtons.YesNo,
                                                  MessageBoxDefaultButton.Button1);

                switch (res)
                {
                    case DialogResult.Yes:
                        {
                            // 保存処理
                            return (true);
                        }
                    case DialogResult.No:
                        {
                            return (false);
                        }
                }
            }

            return (true);
        }

        /// <summary>
        /// 画面情報比較処理
        /// </summary>
        /// <returns>ステータス(True:変更なし　False:変更あり)</returns>
        /// <remarks>
        /// <br>Note        : 画面情報を比較し、変更されている場合はメッセージを表示します。</br>
        /// <br>Programmer  : 劉洋</br>
        /// <br>Date        : 2009/06/01</br>
        /// </remarks>
        private bool CompareOriginalScreen()
        {
            if (this.uGrid_Result.Rows.Count > 0)
            {
                return (false);
            }

            return (true);
        }

        /// <summary>
        /// メッセージボックス表示処理
        /// </summary>
        /// <param name="errLevel">エラーレベル</param>
        /// <param name="message">表示するメッセージ</param>
        /// <param name="status">ステータス値</param>
        /// <param name="msgButton">表示するボタン</param>
        /// <param name="defaultButton">初期表示ボタン</param>
        /// <returns>DialogResult</returns>
        /// <remarks>
        /// <br>Note       : メッセージボックスを表示します。</br>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date       : 2009/06/01</br>
        /// </remarks>
        private DialogResult ShowMessageBox(emErrorLevel errLevel, string message, int status, MessageBoxButtons msgButton, MessageBoxDefaultButton defaultButton)
        {
            DialogResult dialogResult;
            dialogResult = TMsgDisp.Show(this,                              // 親ウィンドウフォーム
                                         errLevel,                          // エラーレベル
                                         ASSEMBLY_ID,                        // アセンブリID
                                         message,                           // 表示するメッセージ
                                         status,                            // ステータス値
                                         msgButton,                         // 表示するボタン
                                         defaultButton);                    // 初期表示ボタン
            return dialogResult;
        }

        /// <summary>
        /// 保存処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : なし</br>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date       : 2009/06/01</br>
        /// </remarks>
        private void Save()
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            this._slipNoAlwcInputAcs.SlipNoAlwcDataTable.Clear();

            if (this._prevControl != null)
            {
                ChangeFocusEventArgs e = new ChangeFocusEventArgs(false, false, false, Keys.Return, this._prevControl, this._prevControl);
                this.tRetKeyControl1_ChangeFocus(this, e);
            }

            this.ultraStatusBar1.Panels[0].Text = string.Empty;

            // 更新前チェック
            bool saveFlg = BeforeSaveCheck();

            if (!saveFlg)
            {
                return;
            }

            // 画面入力を禁止する
            this.HeaderEnabledSetting(false);

            string msg = string.Empty;

            // 抽出中画面部品のインスタンスを作成
            SFCMN00299CA msgForm = new SFCMN00299CA();
            msgForm.Title = "引当処理中";
            msgForm.Message = "引当処理中です。";

            try
            {
                msgForm.Show();
                status = this._slipNoAlwcInputAcs.SaveData(ref msg);
            }
            finally
            {
                msgForm.Close();
            }

            if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                if (this.uGrid_Result.Rows.Count == 0)
                {
                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_INFO,
                        this.Name,
                        "引当対象のデータは存在しませんでした。",
                        -1,
                        MessageBoxButtons.OK);

                    // 画面初期化処理
                    this.Clear();
                }
                else
                {
                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_INFO,
                        this.Name,
                        "正常終了しました。",
                        -1,
                        MessageBoxButtons.OK);

                    // ボタン設定
                    this.AfUpdateButtonSetting();
                }

            }
            else if (status == (int)ConstantManagement.MethodResult.ctFNC_WARNING)
            {
                TMsgDisp.Show(
                   this,
                   emErrorLevel.ERR_LEVEL_INFO,
                   this.Name,
                   "お買上一覧ＣＳＶファイルが存在しません。",
                   -1,
                   MessageBoxButtons.OK);

                // 画面初期化処理
                this.Clear();
            }
            else
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_STOP,
                    this.Name,
                    msg,
                    -1,
                    MessageBoxButtons.OK);

                // ボタン設定
                this.AfUpdateButtonSetting();
            }
        }


        /// <summary>
        /// 印刷処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : なし</br>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date       : 2009/06/01</br>
        /// </remarks>
        private void Print(bool preview)
        {
            if (this._slipNoAlwcInputAcs.SlipNoAlwcDataTable.Count == 0)
            {
                TMsgDisp.Show(
                   this,
                   emErrorLevel.ERR_LEVEL_INFO,
                   this.Name,
                   "印刷対象のデータが存在しません。",
                   -1,
                   MessageBoxButtons.OK);
                return;
            }

            // 抽出中画面部品のインスタンスを作成
            SFCMN00299CA msgForm = new SFCMN00299CA();
            msgForm.Title = "印刷処理中";
            msgForm.Message = "印刷処理中です。";

            SFCMN06002C printInfo = new SFCMN06002C();

            try
            {
                msgForm.Show();

                if (this._printControl == null)
                    this._printControl = new DCCMN04000UA();

                printInfo.printmode = (preview) ? 2 : 3;
                printInfo.pdfopen = false;
                printInfo.pdftemppath = "";

                // 直接印刷バージョン
                printInfo.enterpriseCode = this._enterpriseCode;
                printInfo.kidopgid = "PMUOE01601U";				// 起動PGID

                SlipNoAlwcData slipNoAlwcData = this._slipNoAlwcInputAcs.SlipNoAlwcData;
                // PDF出力履歴用
                printInfo.key = "27e4e53d-9379-460c-8c4d-189584e6d0b7";
                printInfo.prpnm = "";
                printInfo.PrintPaperSetCd = 0;

                printInfo.jyoken = slipNoAlwcData;

                DataView myView = new DataView(this._slipNoAlwcInputAcs.SlipNoAlwcDataTable, "", "", DataViewRowState.CurrentRows);

                printInfo.rdData = myView;
            }
            finally
            {
                msgForm.Close();
            }

            int status = _printControl.Print(printInfo);

            if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                if (preview)
                {
                    this._printControl.PDFViewer.Dock = DockStyle.Fill;
                    this.uTab_View.Controls.Add(this._printControl.PDFViewer);
                    this.ultraTabControl1.Tabs[cTAB_PREVIEW].Visible = true;
                    this.ultraTabControl1.SelectedTab = this.ultraTabControl1.Tabs[cTAB_PREVIEW];
                }
            }
        }

        /// <summary>
        /// 画面入力項目禁止
        /// </summary>
        /// <param name="enabledFlg">フラグ</param>
        /// <remarks>
        /// <br>Note       : なし</br>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date       : 2009/06/01</br>
        /// </remarks>
        private void HeaderEnabledSetting(bool enabledFlg)
        {
            this.panel_Header.Enabled = enabledFlg;
        }

        /// <summary>
        /// 更新前チェック
        /// </summary>
        /// <returns>結果</returns>
        /// <remarks>
        /// <br>Note       : なし</br>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date       : 2009/06/01</br>
        /// </remarks>
        private bool BeforeSaveCheck()
        {
            SlipNoAlwcData slipNoAlwcData = this._slipNoAlwcInputAcs.SlipNoAlwcData;

            // 発注先チェック
            if (this._slipNoAlwcInputAcs.UOESupplierData.Count == 0)
            {
                // 該当なし
                TMsgDisp.Show(this, 												// 親ウィンドウフォーム
                                emErrorLevel.ERR_LEVEL_INFO, 						// エラーレベル
                                this.Name,											// アセンブリID
                                "発注先が選択されていません。",                     // 表示するメッセージ
                                -1,													// ステータス値
                                MessageBoxButtons.OK);

                // フォーカス設定
                this.ultraComboEditor_SupplierCode.Focus();
                this.ultraStatusBar1.Panels[0].Text = "発注先を選択して下さい。";

                return false;
            }

            // 保存フォルダチェック
            if (string.IsNullOrEmpty(slipNoAlwcData.AnswerSaveFolder))
            {
                // 該当なし
                TMsgDisp.Show(this, 												// 親ウィンドウフォーム
                                emErrorLevel.ERR_LEVEL_INFO, 						// エラーレベル
                                this.Name,											// アセンブリID
                                "回答保存フォルダが未入力です。",                   // 表示するメッセージ
                                -1,													// ステータス値
                                MessageBoxButtons.OK); 

                // フォーカス設定
                this.tEdit_AnswerSaveFolder.Focus();
                this.ultraStatusBar1.Panels[0].Text = "回答保存フォルダを入力して下さい。";

                return false;
            }
            // 保存フォルダ有効チェック
            // 設定された回答保存フォルダが存在しない場合
            if (!Directory.Exists(slipNoAlwcData.AnswerSaveFolder))
            {
                // 該当なし
                TMsgDisp.Show(this, 												// 親ウィンドウフォーム
                                emErrorLevel.ERR_LEVEL_INFO, 						// エラーレベル
                                this.Name,											// アセンブリID
                                "回答保存フォルダが無効です。",                   // 表示するメッセージ
                                -1,													// ステータス値
                                MessageBoxButtons.OK);

                // フォーカス設定
                this.tEdit_AnswerSaveFolder.Focus();
                this.ultraStatusBar1.Panels[0].Text = "回答保存フォルダを入力して下さい。";
                return false;
            }
            // 担当者チェック
            if (string.IsNullOrEmpty(slipNoAlwcData.EmployeeCode))
            {
                // 該当なし
                TMsgDisp.Show(this, 												// 親ウィンドウフォーム
                                emErrorLevel.ERR_LEVEL_INFO, 						// エラーレベル
                                this.Name,											// アセンブリID
                                "担当者が未入力です。",                             // 表示するメッセージ
                                -1,													// ステータス値
                                MessageBoxButtons.OK);

                // フォーカス設定
                this.tEdit_EmployeeCode.Focus();
                this.ultraStatusBar1.Panels[0].Text = "担当者を入力して下さい。";

                return false;
            }

            return true;
        }
        #endregion

        // ===================================================================================== //
        // 各コントロールイベント処理
        // ===================================================================================== //
        # region ■Control Event Methods
        /// <summary>
        ///	Form.Load イベント(PMUOE01601U)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: ユーザーがフォームを読み込むときに発生します。</br>
        /// <br>Programmer	: 劉洋</br>
        /// <br>Date		: 2008.06.02</br>
        /// </remarks>
        private void PMUOE01601UA_Load(object sender, EventArgs e)
        {
            // ボタン設定
            this.ButtonInitialSetting();

            // 初期化情報取得
            //string msg = string.Empty;
            //int status = this._slipNoAlwcInputAcs.ReadInitData(LoginInfoAcquisition.EnterpriseCode,
            //    LoginInfoAcquisition.Employee.BelongSectionCode, ref msg);

            // グリッド
            this.uGrid_Result.DataSource = this._slipNoAlwcInputAcs.SlipNoAlwcDataTable;

            // コンボックス設定
            // this.ComboxValueSetting();

            // 従業員マスタ
            this._slipNoAlwcInputAcs.ReadEmployeeData();

            // 初期化処理
            this.Clear();
        }

        /// <summary>
        /// ボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note		: 担当者ボタンをクリックときに発生します。</br>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date       : 2009.06.02</br>
        /// </remarks>
        private void EmployeeCode_Button_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                // キャッシュ処理
                SlipNoAlwcData slipNoAlwcData = this._slipNoAlwcInputAcs.SlipNoAlwcData;

                int status = -1;

                // ガイド起動
                Employee employee = new Employee();
                status = _employeeAcs.ExecuteGuid(LoginInfoAcquisition.EnterpriseCode, true, out employee);

                // 項目に展開
                if (status == 0)
                {
                    slipNoAlwcData.EmployeeCode = employee.EmployeeCode.TrimEnd();
                    slipNoAlwcData.EmployeeName = employee.Name;

                    // 再表示する
                    this.SetDisplay(slipNoAlwcData);

                    this._slipNoAlwcInputAcs.CacheSlipNoAlwcData(slipNoAlwcData);
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// ボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note		: 回答保存フォルダをクリックときに発生します。</br>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date       : 2009.06.02</br>
        /// </remarks>
        private void AnswerSaveFolder_Button_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
            {
                folderBrowserDialog.Description = "回答保存フォルダ選択";

                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    SlipNoAlwcData slipNoAlwcData = this._slipNoAlwcInputAcs.SlipNoAlwcData;

                    slipNoAlwcData.AnswerSaveFolder = folderBrowserDialog.SelectedPath;

                    this.SetDisplay(slipNoAlwcData);

                    this._slipNoAlwcInputAcs.CacheSlipNoAlwcData(slipNoAlwcData);
                }
            }
        }

        /// <summary>
        /// フォーカス設定イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note	　 : フォーカス設定ときに発生します。</br>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date       : 2009.06.02</br>
        /// </remarks>
        private void timer_SetFocus_Tick(object sender, EventArgs e)
        {
            this.timer_SetFocus.Enabled = false;

            this.ultraComboEditor_SupplierCode.Focus();
            this.ultraStatusBar1.Panels[0].Text = "発注先を選択して下さい。";
        }

        /// <summary>
        /// グリッド設定イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : なし。</br>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date       : 2009.06.02</br>
        /// </remarks>
        private void uGrid_Result_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            this.uGrid_Result.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;

            Infragistics.Win.UltraWinGrid.UltraGridBand editBand = this.uGrid_Result.DisplayLayout.Bands[0];
            if (editBand == null) return;

            editBand.ColHeadersVisible = true;

            // グリッド
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._slipNoAlwcInputAcs.SlipNoAlwcDataTable.SupplierDateColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Left;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._slipNoAlwcInputAcs.SlipNoAlwcDataTable.OrderDateColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Left;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._slipNoAlwcInputAcs.SlipNoAlwcDataTable.OldSupplierSlipNoColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Left;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._slipNoAlwcInputAcs.SlipNoAlwcDataTable.SupplierSlipNoColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Left;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._slipNoAlwcInputAcs.SlipNoAlwcDataTable.GoodsNoColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Left;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._slipNoAlwcInputAcs.SlipNoAlwcDataTable.GoodsNameColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Left;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._slipNoAlwcInputAcs.SlipNoAlwcDataTable.UpdatePriceColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Left;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._slipNoAlwcInputAcs.SlipNoAlwcDataTable.PriceColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Left;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._slipNoAlwcInputAcs.SlipNoAlwcDataTable.FilesNameColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Left;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._slipNoAlwcInputAcs.SlipNoAlwcDataTable.UpdateResultColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Left;

            // CellAppearance設定
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._slipNoAlwcInputAcs.SlipNoAlwcDataTable.SupplierDateColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._slipNoAlwcInputAcs.SlipNoAlwcDataTable.OrderDateColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._slipNoAlwcInputAcs.SlipNoAlwcDataTable.OldSupplierSlipNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._slipNoAlwcInputAcs.SlipNoAlwcDataTable.SupplierSlipNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._slipNoAlwcInputAcs.SlipNoAlwcDataTable.GoodsNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._slipNoAlwcInputAcs.SlipNoAlwcDataTable.GoodsNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._slipNoAlwcInputAcs.SlipNoAlwcDataTable.UpdatePriceColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._slipNoAlwcInputAcs.SlipNoAlwcDataTable.PriceColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._slipNoAlwcInputAcs.SlipNoAlwcDataTable.FilesNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._slipNoAlwcInputAcs.SlipNoAlwcDataTable.UpdateResultColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;

            // 表示幅設定
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._slipNoAlwcInputAcs.SlipNoAlwcDataTable.SupplierDateColumn.ColumnName].Width = 90;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._slipNoAlwcInputAcs.SlipNoAlwcDataTable.OrderDateColumn.ColumnName].Width = 90;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._slipNoAlwcInputAcs.SlipNoAlwcDataTable.OldSupplierSlipNoColumn.ColumnName].Width = 120;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._slipNoAlwcInputAcs.SlipNoAlwcDataTable.SupplierSlipNoColumn.ColumnName].Width = 100;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._slipNoAlwcInputAcs.SlipNoAlwcDataTable.GoodsNoColumn.ColumnName].Width = 95;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._slipNoAlwcInputAcs.SlipNoAlwcDataTable.GoodsNameColumn.ColumnName].Width = 100;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._slipNoAlwcInputAcs.SlipNoAlwcDataTable.UpdatePriceColumn.ColumnName].Width = 92;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._slipNoAlwcInputAcs.SlipNoAlwcDataTable.PriceColumn.ColumnName].Width = 80;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._slipNoAlwcInputAcs.SlipNoAlwcDataTable.FilesNameColumn.ColumnName].Width = 165;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._slipNoAlwcInputAcs.SlipNoAlwcDataTable.UpdateResultColumn.ColumnName].Width = 80;

            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._slipNoAlwcInputAcs.SlipNoAlwcDataTable.SupplierDateColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._slipNoAlwcInputAcs.SlipNoAlwcDataTable.OrderDateColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._slipNoAlwcInputAcs.SlipNoAlwcDataTable.OldSupplierSlipNoColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._slipNoAlwcInputAcs.SlipNoAlwcDataTable.SupplierSlipNoColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._slipNoAlwcInputAcs.SlipNoAlwcDataTable.GoodsNoColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._slipNoAlwcInputAcs.SlipNoAlwcDataTable.GoodsNameColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._slipNoAlwcInputAcs.SlipNoAlwcDataTable.UpdatePriceColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._slipNoAlwcInputAcs.SlipNoAlwcDataTable.PriceColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._slipNoAlwcInputAcs.SlipNoAlwcDataTable.FilesNameColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._slipNoAlwcInputAcs.SlipNoAlwcDataTable.UpdateResultColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
        }

        /// <summary>
        /// ツールバーボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : なし。</br>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date       : 2009.06.02</br>
        /// </remarks>
        private void tToolbarsManager_MainMenu_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            this.ultraStatusBar1.Panels[0].Text = string.Empty;

            switch (e.Tool.Key)
            {
                case "ButtonTool_Close":
                    {
                        // 画面情報比較
                        string msg = "現在、編集中のデータが存在します。\r\n伝票番号引当処理を終了してよろしいですか？";
                        bool bStatus = CompareScreen(msg);
                        if (!bStatus)
                        {
                            return;
                        }

                        this.Close();
                        break;
                    }
                case "ButtonTool_Update":
                    {
                        this.Save();

                        break;
                    }
                case "ButtonTool_Clear":
                    {
                        // 画面情報比較
                        string msg = "現在、編集中のデータが存在します。\r\n初期状態に戻しますか？";
                        bool bStatus = CompareScreen(msg);
                        if (!bStatus)
                        {
                            return;
                        }

                        this.Clear();
                        break;
                    }
                case "ButtonTool_Print":
                    {
                        // 印刷処理
                        Print(false);

                        break;
                    }
                case "ButtonTool_Preview":
                    {
                        // 印刷処理
                        Print(true);

                        break;
                    }
            }
        }

        /// <summary>
        /// ChangeFocus イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : なし</br>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date       : 2009.06.01</br>
        /// </remarks>
        private void tRetKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null)
            {
                return;
            }

            this._prevControl = e.NextCtrl;

            bool reRead = false;

            SlipNoAlwcData slipNoAlwcDataCurrent = this._slipNoAlwcInputAcs.SlipNoAlwcData.Clone();
            if (slipNoAlwcDataCurrent == null) return;

            SlipNoAlwcData slipNoAlwcData = slipNoAlwcDataCurrent.Clone();

            switch (e.PrevCtrl.Name)
            {
                // 発注先
                case "ultraComboEditor_SupplierCode":
                    {
                        if (e.ShiftKey == false)
                        {
                            if (e.Key == Keys.Tab || e.Key == Keys.Enter)
                            {
                                e.NextCtrl = this.tEdit_AnswerSaveFolder;
                            }
                        }
                        else
                        {
                            if (e.Key == Keys.Tab || e.Key == Keys.Enter)
                            {
                                e.NextCtrl = this.ultraComboEditor_StockData;
                            }
                        }

                        break;
                    }
                // 回答保存フォルダ
                case "tEdit_AnswerSaveFolder":
                    {
                        string filePath = this.tEdit_AnswerSaveFolder.DataText;

                        if (e.ShiftKey == false)
                        {
                            // 変更なし
                            if (filePath.Equals(slipNoAlwcData.AnswerSaveFolder))
                            {
                                if (e.Key == Keys.Tab || e.Key == Keys.Enter)
                                {
                                    if (string.IsNullOrEmpty(filePath))
                                    {
                                        e.NextCtrl = this.AnswerSaveFolder_Button;
                                    }
                                    else
                                    {
                                        e.NextCtrl = this.tEdit_EmployeeCode;
                                    }
                                }
                            }
                            else
                            {
                                slipNoAlwcData.AnswerSaveFolder = filePath;

                                if (e.Key == Keys.Tab || e.Key == Keys.Enter)
                                {
                                    e.NextCtrl = this.tEdit_EmployeeCode;
                                }
                            }
                        }
                        else
                        {
                            // 変更なし
                            if (filePath.Equals(slipNoAlwcData.AnswerSaveFolder))
                            {
                                if (e.Key == Keys.Tab || e.Key == Keys.Enter)
                                {
                                    e.NextCtrl = this.ultraComboEditor_SupplierCode;
                                }
                            }
                            else
                            {
                                slipNoAlwcData.AnswerSaveFolder = filePath;

                                if (e.Key == Keys.Tab || e.Key == Keys.Enter)
                                {
                                    e.NextCtrl = this.ultraComboEditor_SupplierCode;
                                }
                            }
                        }
                        break;
                    }
                // 回答保存フォルダ
                case "AnswerSaveFolder_Button":
                    {
                        if (e.ShiftKey == false)
                        {
                            if (e.Key == Keys.Tab || e.Key == Keys.Enter)
                            {
                                e.NextCtrl = this.tEdit_EmployeeCode;
                            }
                        }
                        else
                        {
                            if (e.Key == Keys.Tab || e.Key == Keys.Enter)
                            {
                                e.NextCtrl = this.tEdit_AnswerSaveFolder;
                            }
                        }
                        break;
                    }
                // 従業員コード
                case "tEdit_EmployeeCode":
                    {
                        string code = this.tEdit_EmployeeCode.Text;

                        if (e.ShiftKey == false)
                        {
                            // 変更なし
                            if (code.Equals(slipNoAlwcData.EmployeeCode))
                            {
                                if (e.Key == Keys.Tab || e.Key == Keys.Enter)
                                {
                                    if (string.IsNullOrEmpty(code))
                                    {
                                        e.NextCtrl = this.EmployeeCode_Button;
                                    }
                                    else
                                    {
                                        e.NextCtrl = this.ultraComboEditor_PriceUpdate;
                                    }
                                }
                            }
                            else
                            {
                                if (string.IsNullOrEmpty(code))
                                {
                                    slipNoAlwcData.EmployeeCode = string.Empty;
                                    slipNoAlwcData.EmployeeName = string.Empty;

                                    // フォーカス設定
                                    if (e.Key == Keys.Tab || e.Key == Keys.Enter)
                                    {
                                        e.NextCtrl = this.EmployeeCode_Button;
                                    }
                                }
                                else
                                {
                                    if (!string.IsNullOrEmpty(this._slipNoAlwcInputAcs.GetEmployeeName(code)))
                                    {
                                        slipNoAlwcData.EmployeeCode = code;
                                        slipNoAlwcData.EmployeeName = this._slipNoAlwcInputAcs.GetEmployeeName(code);

                                        if (e.Key == Keys.Tab || e.Key == Keys.Enter)
                                        {
                                            e.NextCtrl = this.ultraComboEditor_PriceUpdate;
                                        }
                                    }
                                    else
                                    {
                                        TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO,
                                              ASSEMBLY_ID,
                                              "担当者が存在しません。",
                                              0,
                                              MessageBoxButtons.OK);

                                        // ↓ 2009.07.01 liuyang modify
                                        // e.NextCtrl = this.EmployeeCode_Button;
                                        e.NextCtrl = e.PrevCtrl;
                                        // ↑ 2009.07.01 liuyang

                                        reRead = true;

                                        break;
                                    }
                                }
                            }
                        }
                        else
                        {
                            // 変更なし
                            if (code.Equals(slipNoAlwcData.EmployeeCode))
                            {
                                if (e.Key == Keys.Tab || e.Key == Keys.Enter)
                                {
                                    if (string.IsNullOrEmpty(this.tEdit_AnswerSaveFolder.Text))
                                    {
                                        e.NextCtrl = this.AnswerSaveFolder_Button;
                                    }
                                    else
                                    {
                                        e.NextCtrl = this.tEdit_AnswerSaveFolder;
                                    }
                                }
                            }
                            else
                            {
                                if (string.IsNullOrEmpty(code))
                                {
                                    slipNoAlwcData.EmployeeCode = string.Empty;
                                    slipNoAlwcData.EmployeeName = string.Empty;

                                    // フォーカス設定
                                    if (e.Key == Keys.Tab || e.Key == Keys.Enter)
                                    {
                                        if (string.IsNullOrEmpty(this.tEdit_AnswerSaveFolder.Text))
                                        {
                                            e.NextCtrl = this.AnswerSaveFolder_Button;
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.tEdit_AnswerSaveFolder;
                                        }
                                    }
                                }
                                else
                                {
                                    if (!string.IsNullOrEmpty(this._slipNoAlwcInputAcs.GetEmployeeName(code)))
                                    {
                                        slipNoAlwcData.EmployeeCode = code;
                                        slipNoAlwcData.EmployeeName = this._slipNoAlwcInputAcs.GetEmployeeName(code);

                                        if (e.Key == Keys.Tab || e.Key == Keys.Enter)
                                        {
                                            if (string.IsNullOrEmpty(this.tEdit_AnswerSaveFolder.Text))
                                            {
                                                e.NextCtrl = this.AnswerSaveFolder_Button;
                                            }
                                            else
                                            {
                                                e.NextCtrl = this.tEdit_AnswerSaveFolder;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO,
                                              ASSEMBLY_ID,
                                              "担当者が存在しません。",
                                              0,
                                              MessageBoxButtons.OK);

                                        e.NextCtrl = this.EmployeeCode_Button;

                                        reRead = true;

                                        break;
                                    }
                                }
                            }
                        }

                        break;
                    }
                // 従業員ボタン
                case "EmployeeCode_Button":
                    {
                        if (e.ShiftKey == false)
                        {
                            if (e.Key == Keys.Tab || e.Key == Keys.Enter)
                            {
                                e.NextCtrl = this.ultraComboEditor_PriceUpdate;
                            }
                        }
                        else
                        {
                            if (e.Key == Keys.Tab || e.Key == Keys.Enter)
                            {
                                e.NextCtrl = this.tEdit_EmployeeCode;
                            }
                        }
                        break;
                    }
                // 原価更新
                case "ultraComboEditor_PriceUpdate":
                    {
                        if (e.ShiftKey == false)
                        {
                            if (e.Key == Keys.Tab || e.Key == Keys.Enter)
                            {
                                e.NextCtrl = this.ultraComboEditor_StockData;
                            }
                        }
                        else
                        {
                            if (e.Key == Keys.Tab || e.Key == Keys.Enter)
                            {
                                if (string.IsNullOrEmpty(this.tEdit_EmployeeCode.Text))
                                {
                                    e.NextCtrl = this.EmployeeCode_Button;
                                }
                                else
                                {
                                    e.NextCtrl = this.tEdit_EmployeeCode;
                                }
                            }
                        }
                        break;
                    }
                // 仕入データ作成区分
                case "ultraComboEditor_StockData":
                    {
                        if (e.ShiftKey == false)
                        {
                            if (e.Key == Keys.Tab || e.Key == Keys.Enter)
                            {
                                e.NextCtrl = this.ultraComboEditor_SupplierCode;
                            }
                        }
                        else
                        {
                            if (e.Key == Keys.Tab || e.Key == Keys.Enter)
                            {
                                e.NextCtrl = this.ultraComboEditor_PriceUpdate;
                            }
                        }
                        break;
                    }
                default :
                    break;
            }

            switch (e.NextCtrl.Name)
            {
                // メッセージ内容
                case "ultraComboEditor_SupplierCode":
                    {
                        this.ultraStatusBar1.Panels[0].Text = "発注先を選択して下さい。";

                        break;
                    }
                case "tEdit_AnswerSaveFolder":
                    {
                        this.ultraStatusBar1.Panels[0].Text = "回答保存フォルダを入力して下さい。";

                        break;
                    }
                case "AnswerSaveFolder_Button":
                    {
                        this.ultraStatusBar1.Panels[0].Text = "回答保存フォルダを入力して下さい。";

                        break;
                    }
                case "tEdit_EmployeeCode":
                    {
                        this.ultraStatusBar1.Panels[0].Text = "担当者を入力して下さい。";

                        break;
                    }
                case "EmployeeCode_Button":
                    {
                        this.ultraStatusBar1.Panels[0].Text = "担当者を入力して下さい。";

                        break;
                    }
                case "ultraComboEditor_PriceUpdate":
                    {
                        this.ultraStatusBar1.Panels[0].Text = "原価更新を選択して下さい。";

                        break;
                    }
                case "ultraComboEditor_StockData":
                    {
                        this.ultraStatusBar1.Panels[0].Text = "仕入データ作成区分を選択して下さい。";

                        break;
                    }
                default:
                    {
                        this.ultraStatusBar1.Panels[0].Text = "";

                        break;
                    }
            }


            // メモリ上の内容と比較する
            ArrayList arRetList = slipNoAlwcData.Compare(slipNoAlwcDataCurrent);

            if (arRetList.Count > 0 || reRead)
            {
                this._slipNoAlwcInputAcs.CacheSlipNoAlwcData(slipNoAlwcData);

                // 画面表示
                this.SetDisplay(slipNoAlwcData);
            }
        }

        /// <summary>
        /// 発注先設定
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">クラス</param>
        /// <remarks>
        /// <br>Note       : なし</br>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date       : 2009.06.03</br>
        /// </remarks>
        private void ultraComboEditor_SupplierCode_ValueChanged(object sender, EventArgs e)
        {
            if (this.ultraComboEditor_SupplierCode.Value != null && !string.IsNullOrEmpty(this.ultraComboEditor_SupplierCode.Value.ToString()))
            {
                // キャッシュ処理
                SlipNoAlwcData slipNoAlwcData = this._slipNoAlwcInputAcs.SlipNoAlwcData;

                if ((int)this.ultraComboEditor_SupplierCode.Value != slipNoAlwcData.SupplierCode)
                {
                    // 画面値
                    slipNoAlwcData.SupplierCode = (int)this.ultraComboEditor_SupplierCode.Value;
                    // UOE発注先データ
                    if (this._slipNoAlwcInputAcs.UOESupplierData.Count > 0)
                    {
                        UOESupplier uoeSupplier = (UOESupplier)this._slipNoAlwcInputAcs.UOESupplierData[slipNoAlwcData.SupplierCode];
                        slipNoAlwcData.UOESupplierCd = uoeSupplier.UOESupplierCd;
                        slipNoAlwcData.UOESupplierName = uoeSupplier.UOESupplierName;
                        slipNoAlwcData.AnswerSaveFolder = uoeSupplier.AnswerSaveFolder;
                        this.tEdit_AnswerSaveFolder.Text = uoeSupplier.AnswerSaveFolder;
                    }
                    else
                    {
                        slipNoAlwcData.UOESupplierCd = 0;
                        slipNoAlwcData.UOESupplierName = "";
                        slipNoAlwcData.AnswerSaveFolder = "";
                        this.tEdit_AnswerSaveFolder.Text = "";
                    }

                    this._slipNoAlwcInputAcs.CacheSlipNoAlwcData(slipNoAlwcData);
                }
            }
        }

        /// <summary>
        /// 原価更新設定
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">クラス</param>
        /// <remarks>
        /// <br>Note       : なし</br>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date       : 2009.06.03</br>
        /// </remarks>
        private void ultraComboEditor_PriceUpdate_ValueChanged(object sender, EventArgs e)
        {
            if (this.ultraComboEditor_PriceUpdate.Value != null)
            {
                // キャッシュ処理
                SlipNoAlwcData slipNoAlwcData = this._slipNoAlwcInputAcs.SlipNoAlwcData;

                // 画面値
                slipNoAlwcData.PriceUpdateCode = (int)this.ultraComboEditor_PriceUpdate.Value;

                this._slipNoAlwcInputAcs.CacheSlipNoAlwcData(slipNoAlwcData);
            }
        }

        /// <summary>
        /// 仕入データ作成区分設定
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">クラス</param>
        /// <remarks>
        /// <br>Note       : なし</br>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date       : 2009.06.03</br>
        /// </remarks>
        private void ultraComboEditor_StockData_ValueChanged(object sender, EventArgs e)
        {
            if (this.ultraComboEditor_StockData.Value != null)
            {
                // キャッシュ処理
                SlipNoAlwcData slipNoAlwcData = this._slipNoAlwcInputAcs.SlipNoAlwcData;

                // 画面値
                slipNoAlwcData.StockDataCode = (int)this.ultraComboEditor_StockData.Value;

                this._slipNoAlwcInputAcs.CacheSlipNoAlwcData(slipNoAlwcData);
            }
        }
        #endregion

        // --- ADD m.suzuki 2010/11/02 ---------->>>>>
        /// <summary>
        /// フォームクローズ処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PMUOE01601UA_FormClosed( object sender, FormClosedEventArgs e )
        {
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
        }
        // --- ADD m.suzuki 2010/11/02 ----------<<<<<
    }
}
//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 注文一覧更新処理
// プログラム概要   : ホンダe-Partsシステムより「ご注文一覧CSV」を取り込み、
//                    回答情報を更新します。
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 李占川
// 作 成 日  2009/05/31  修正内容 : 新規作成
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
    /// 注文一覧更新処理入力フォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 注文一覧更新処理の入力フォームクラスです。</br>
    /// <br>Programmer : 李占川</br>
    /// <br>Date       : 2009.05.31</br>
    /// <br></br>
    /// <br>UpDate</br>
    /// <br>2009.05.31 lizc 新規作成</br>
    /// <br>Update Note: 2009/06/25 李占川</br>
    /// <br>             PVCS#273について、アイテムチェックを修正します。</br>
    /// </remarks>
    public partial class PMUOE01551UA : Form
    {
        // ===================================================================================== //
        // コンストラクタ
        // ===================================================================================== //
        # region コンストラクタ
        /// <summary>
        /// 注文一覧更新処理入力フォームクラス デフォルトコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 注文一覧更新処理のコンストラクタです。</br>      
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009.05.31</br>
        /// </remarks>
        public PMUOE01551UA()
        {
            InitializeComponent();

            this._startMode = HAND_MODE;

            // 企業コード取得
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            this._loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;

            this._uoeOrderAllInfoAcs = new UoeOrderAllInfoAcs();
            this._dataTable = this._uoeOrderAllInfoAcs.DetailDataTable;

            // フォームのタイトル
            this.Text = FORM_HANDTITLE;
        }

        /// <summary>
        /// 注文一覧更新処理入力フォームクラス デフォルトコンストラクタ
        /// </summary>
        /// <param name="uOESupplier">uOESupplier</param>
        /// <remarks>
        /// <br>Note       : 注文一覧更新処理のコンストラクタです。</br>      
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009.05.31</br>
        /// </remarks>
        public PMUOE01551UA(UOESupplier uOESupplier)
        {
            InitializeComponent();

            this._startMode = AUTO_MODE;

            // 起動パラメータ
            this._paraUOESupplier = uOESupplier;

            // 企業コード取得
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            this._loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;

            this._uoeOrderAllInfoAcs = new UoeOrderAllInfoAcs();
            this._dataTable = this._uoeOrderAllInfoAcs.DetailDataTable;

            // フォームのタイトル
            this.Text = FORM_AUTOTITLE;
        }
        # endregion コンストラクタ

        // ===================================================================================== //
        // プライベート定数
        // ===================================================================================== //
        # region Private Constant
        // タイトル
        private const string FORM_AUTOTITLE = "ﾎﾝﾀﾞ e-Parts 注文一覧更新処理";
        private const string FORM_HANDTITLE = "ﾎﾝﾀﾞ e-Parts 注文一覧更新処理";

        // ツールバーツールキー設定
        private const string TOOLBAR_CLOSEBUTTON_KEY = "ButtonTool_Close";
        private const string TOOLBAR_CONFIRMBUTTON_KEY = "ButtonTool_Confirm";
        private const string TOOLBAR_LOGINNAMELABLE_KEY = "LableTool_LoginName";
        private const string TOOLBAR_LOGINLABEL_TITLE = "LableTool_LoginTitle";

        private const string ASSEMBLY_ID = "PMUOE01551U";

        // datatable名称用
        private const string TABLE_ID = "RESULT_TABLE";
        private const string FILENAME = "FileName"; // ファイル名
        private const string PROCESSNUM = "processNum"; // 件数
        private const string RESULT = "result"; // 結果

        // 起動Mode
        private const int HAND_MODE = 1;  // 手動起動
        private const int AUTO_MODE = 0;  // 自動起動

        // ショートカットメニュー
        private const string TOOLSTRIPMENUITEM_SCREEN = "toolStripMenuItem_Screen";
        private const string TOOLSTRIPMENUITEM_CLOSE = "toolStripMenuItem_Close";

        # endregion

        // ===================================================================================== //
        // プライベート変数
        // ===================================================================================== //
        # region Private Members
        // 起動mode. 1:手動起動;0:自動起動
        private int _startMode;
        // 企業コード取得用
        private string _enterpriseCode;
        // ログイン拠点(自拠点)
        private string _loginSectionCode;

        // アクセスクラス
        private UoeOrderAllInfoAcs _uoeOrderAllInfoAcs;

        private DataTable _dataTable;

        private Dictionary<int, UOESupplier> _uOESupplierDic;

        private ImageList _imageList16 = null;											// イメージリスト
        private Infragistics.Win.UltraWinToolbars.ButtonTool _closeButton;				// 終了ボタン
        private Infragistics.Win.UltraWinToolbars.ButtonTool _confirmButton;			// 確定ボタン
        private Infragistics.Win.UltraWinToolbars.LabelTool _loginTitleLabel;		    // ログイン担当者名称
        private Infragistics.Win.UltraWinToolbars.LabelTool _loginNameLabel;            // ログイン担当者名称

        // 起動パラメータ
        private UOESupplier _paraUOESupplier;

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
        /// <br>Date        : 2009.03.31</br>
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

            // ログイン担当者のアイコン設定
            this._loginTitleLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)tToolbarsManager_MainMenu.Tools[TOOLBAR_LOGINLABEL_TITLE];
            if (this._loginTitleLabel != null)
            {
                this._loginTitleLabel.SharedProps.AppearancesSmall.Appearance.Image = this._imageList16.Images[(int)Size16_Index.EMPLOYEE];
            }

            // -----------------------------
            // ボタンアイコン設定
            // -----------------------------
            this.FolderGuide_Button.Appearance.Image = this._imageList16.Images[(int)Size16_Index.STAR1];
        }
        # endregion 画面初期化

        # region 画面データ初期化
        /// <summary>
        /// 初期画面のデータ
        /// </summary>
        /// <remarks>
        /// <br>Note        : 画面初期化時に発生します。</br>      
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009.05.31</br>
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
            if (this._startMode == HAND_MODE)
            {
                // 発注先の算出
                this.LoadUOESupplier();

                // 発注先のComboEditorデータ初期化
                this.InitialUOESupplierCombo();
            }
            else
            {
                if (this._paraUOESupplier.CommAssemblyId == "0502")
                {
                    this._uOESupplierDic.Add(this._paraUOESupplier.UOESupplierCd, this._paraUOESupplier);
                }
                // 発注先のComboEditorデータ初期化
                this.InitialUOESupplierCombo();
            }
        }
        # endregion 画面データ初期化

        # region 発注先のComboEditorデータ初期化
        /// <summary>
        /// 発注先のComboEditorデータ初期化
        /// </summary>
        /// <remarks>
        /// <br>Note        : 発注先のComboEditorデータ初期化処理を行います。</br>      
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009.06.03</br>
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
        /// <br>Date        : 2009.06.03</br>
        /// </remarks> 
        private void LoadUOESupplier()
        {
            // 発注先と回答保存フォルダ
            ArrayList uOESupplierList;
            int status = this._uoeOrderAllInfoAcs.GetUOESupplier(out uOESupplierList, this._enterpriseCode, this._loginSectionCode);

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
        /// <br>Date       : 2009.05.31</br>
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
        /// <br>Date       : 2009.06.04</br>
        /// </remarks>
        private void SetStatusBarMsg(Control control)
        {
            // 自動起動場合、設定しない
            if (this._startMode == AUTO_MODE) return;

            // controlが未設定場合
            if (control == null) return;

            // 発注先
            if (control == this.tComboEditor_UOESupplier)
            {
                this.MainStatusBar.Panels["Text"].Text = "発注先を選択して下さい。";
            }
            // 回答保存フォルダ
            else if (control == this.tEdit_AnswerSaveFolder)
            {
                this.MainStatusBar.Panels["Text"].Text = "回答保存フォルダを入力して下さい。";
            }
            // その他
            else
            {
                this.MainStatusBar.Panels["Text"].Text = string.Empty;
            }
        }

        /// <summary>
        /// Visible設定処理(From)
        /// </summary>
        /// <param name="visible">表示</param>
        /// <remarks>
        /// <br>Note       : Visibleを設定する</br>
        /// <br>Programer  : 李占川</br>
        /// <br>Date       : 2009.05.31</br>
        /// </remarks>
        private void SetFromVisible(bool visible)
        {
            switch (visible)
            {
                // 手動起動時
                case true:
                    {
                        this.Visible = true;
                        this.ParentForm.Visible = true;
                        break;
                    }
                // 自動起動時
                case false:
                    {
                        this.ParentForm.Visible = false;
                        this.Visible = false;
                        break;
                    }
            }
        }

        /// <summary>
        /// コントロールEnabled制御処理
        /// </summary>
        /// <param name="mode">編集モード</param>
        /// <remarks>
        /// <br>Note       : コントロールのEnabled制御を行います。</br>
        /// <br>Programer  : 李占川</br>
        /// <br>Date       : 2009.05.31</br>
        /// </remarks>
        private void SetControlEnabled(int mode)
        {
            switch (mode)
            {
                // 手動起動時
                case HAND_MODE:
                    {
                        this._closeButton.SharedProps.Enabled = true;
                        this._confirmButton.SharedProps.Enabled = true;
                        this.tComboEditor_UOESupplier.Enabled = true;
                        this.tEdit_AnswerSaveFolder.Enabled = true;
                        this.FolderGuide_Button.Enabled = true;
                        break;
                    }
                // 自動起動時
                case AUTO_MODE:
                    {
                        this._closeButton.SharedProps.Enabled = false;
                        this._confirmButton.SharedProps.Enabled = false;
                        this.tComboEditor_UOESupplier.Enabled = false;
                        this.tEdit_AnswerSaveFolder.Enabled = false;
                        this.FolderGuide_Button.Enabled = false;
                        break;
                    }
            }
        }
        # endregion 画面設定

        # region 確定処理
        /// <summary>
        ///　確定処理(ConfirmProc())
        /// </summary>
        /// <remarks>
        /// <br>Note　　　  : 保存処理を行います。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009.05.31</br>
        /// </remarks>
        private void ConfirmProc()
        {
            // データセットクリア
            this._uoeOrderAllInfoAcs.DataTableClear();

            // 入力チェック
            if (this.CheckInputScreen() != true)
            {
                // PM連動
                if (this._startMode == AUTO_MODE)
                {
                    this.Close();
                }
                return;
            }

            // 画面情報データクラス格納処理
            UOESupplierInfo uOESupplierInfo = new UOESupplierInfo();
            this.ScreenToUOESupplierInfo(ref uOESupplierInfo);

            SFCMN00299CA form = new SFCMN00299CA();
            // 表示文字を設定
            form.Title = "更新処理中";
            form.Message = "更新処理中です";

            // 注文一覧ＣＳＶファイルの取得
            string resultMessage;
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            try
            {
                // ダイアログ表示
                form.Show();
                this.Cursor = Cursors.WaitCursor;
                status = this._uoeOrderAllInfoAcs.DoConfirm(uOESupplierInfo, out resultMessage);

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
                case (int)ConstantManagement.MethodResult.ctFNC_NORMAL:    // 処理成功
                    resultMessage = "正常終了しました。";
                    break;
                case (int)ConstantManagement.MethodResult.ctFNC_ERROR:
                    errLevel = emErrorLevel.ERR_LEVEL_INFO;
                    break;
                default:    // その他エラー
                    errLevel = emErrorLevel.ERR_LEVEL_STOP;
                    //resultMessage = "その他異常が発生しました。";
                    break;
            }

            // メッセージ表示
            if (resultMessage != "")
            {
                this.ShowMessageBox(errLevel, "ConfirmProc", resultMessage, status, MessageBoxButtons.OK);
            }

            this.SetControlFocus(this.tComboEditor_UOESupplier);

            // PM連動場合、画面を閉じる
            if (this._startMode == AUTO_MODE)
            {
                this.Close();
            }
        }
        # endregion 確定処理

        # region チェック処理
        /// <summary>
        /// 画面情報入力チェック処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note        : 画面情報の入力チェックを行います。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009.05.31</br>
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
                    this.SetControlFocus(this.tComboEditor_UOESupplier);
                    return false;
                }

                string answerSaveFolder = this.tEdit_AnswerSaveFolder.DataText;

                // 回答保存フォルダが未入力時の場合
                if (answerSaveFolder == string.Empty)
                {
                    errMsg = "回答保存フォルダが未入力です。";
                    this.SetControlFocus(this.tEdit_AnswerSaveFolder);
                    return false;
                }

                // 設定された回答保存フォルダが存在しない場合
                if (!Directory.Exists(answerSaveFolder))
                {
                    errMsg = "回答保存フォルダが無効です。";
                    this.SetControlFocus(this.tEdit_AnswerSaveFolder);
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
        # endregion チェック処理

        # region 画面情報取得
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// 画面情報データクラス格納処理
        /// </summary>
        /// <param name="uOESupplierInfo">データクラスオブジェクト</param>
        /// <remarks>
        /// <br>Note        : 画面情報からデータクラスオブジェクトにデータを格納します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009/06/02</br>
        /// </remarks>
        private void ScreenToUOESupplierInfo(ref UOESupplierInfo uOESupplierInfo)
        {
            if (uOESupplierInfo == null)
            {
                // 新規の場合
                uOESupplierInfo = new UOESupplierInfo();
            }

            // 企業コード
            uOESupplierInfo.EnterpriseCode = this._enterpriseCode;
            // 拠点コード
            uOESupplierInfo.SectionCode = this._loginSectionCode;
            // UOE発注先コード
            uOESupplierInfo.UOESupplierCd = (int)this.tComboEditor_UOESupplier.SelectedItem.DataValue;
            // 回答保存フォルダ
            uOESupplierInfo.AnswerSaveFolder = this.tEdit_AnswerSaveFolder.DataText.Trim();

            // --- ADD 2009/06/25 ------------------------------->>>>>
            UOESupplier outUOESupplier;
            this._uOESupplierDic.TryGetValue((int)this.tComboEditor_UOESupplier.SelectedItem.DataValue, out outUOESupplier);
            // アイテム
            uOESupplierInfo.UOEItemCd = outUOESupplier.UOEItemCd;
            // --- ADD 2009/06/25 ------------------------------<<<<<
        }
        # endregion

        # region Grid関連
        /// <summary>
        /// グリッド列初期設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note		: 画面初期化の時、グリッド列初期設定を行います。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009.05.31</br>
        /// </remarks>
        private void InitialSettingGridCol()
        {
            Infragistics.Win.UltraWinGrid.UltraGridBand editBand = this.Detail_uGrid.DisplayLayout.Bands[0];
            if (editBand == null) return;

            editBand.ColHeadersVisible = true;

            //---------------------------------------------------------------------
            // 表示幅設定
            //---------------------------------------------------------------------
            editBand.Columns[FILENAME].Width = 400;
            editBand.Columns[PROCESSNUM].Width = 92;
            editBand.Columns[RESULT].Width = 230;

            //---------------------------------------------------------------------
            // 入力許可設定
            //---------------------------------------------------------------------
            editBand.Columns[FILENAME].CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
            editBand.Columns[PROCESSNUM].CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
            editBand.Columns[RESULT].CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;

            //---------------------------------------------------------------------
            // 詰め
            //---------------------------------------------------------------------
            editBand.Columns[FILENAME].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            editBand.Columns[PROCESSNUM].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            editBand.Columns[RESULT].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;

            //---------------------------------------------------------------------
            // 詰め(header)
            //---------------------------------------------------------------------
            editBand.Columns[FILENAME].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Left;
            editBand.Columns[PROCESSNUM].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Left;
            editBand.Columns[RESULT].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Left;
        }
        # endregion Grid関連

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
        /// <br>Date       : 2009/05/31</br>
        /// </remarks>
        private DialogResult ShowMessageBox(emErrorLevel errLevel, string methodName, string message, int status, MessageBoxButtons msgButton)
        {
            DialogResult dialogResult;
            //dialogResult = TMsgDisp.Show(this, 						        // 親ウィンドウフォーム
            //                             errLevel,			                // エラーレベル
            //                             this.Name,						    // プログラム名称
            //                             ASSEMBLY_ID, 		  　　			// アセンブリID
            //                             methodName,						// 処理名称
            //                             "",					            // オペレーション
            //                             message,	                        // 表示するメッセージ
            //                             status,							// ステータス値
            //                             this._uoeOrderAllInfoAcs,			// エラーが発生したオブジェクト
            //                             msgButton,         			  	// 表示するボタン
            //                             MessageBoxDefaultButton.Button1);	// 初期表示ボタン
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
        /// <br>Date       : 2009/06/25</br>
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
        /// <br>Date        : 2009.05.31</br>
        /// </remarks>
        private void PMUOE01550UA_Load(object sender, EventArgs e)
        {
            // 画面初期化
            this.InitialScreenSetting();

            // 画面データ初期化
            InitialScreenData();

            // コントロールEnabled制御処理
            this.SetControlEnabled(this._startMode);

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
        /// <br>Date        : 2009.05.31</br>
        /// </remarks>
        private void tToolbarsManager_MainMenu_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                // 終了
                case TOOLBAR_CLOSEBUTTON_KEY:
                    {
                        this.Close();
                        break;
                    }
                // 確定
                case TOOLBAR_CONFIRMBUTTON_KEY:
                    {
                        this.ConfirmProc();
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
        /// <br>Date        : 2009.05.31</br>
        /// </remarks>
        private void Timer_Init_Tick(object sender, EventArgs e)
        {
            Initial_Timer.Enabled = false;

            // 画面データ初期化
            //InitialScreenData();

            this.SetControlFocus(this.tComboEditor_UOESupplier);

            // PM連動場合
            if (this._startMode == AUTO_MODE)
            {
                this.ConfirmProc();
            }
        }

        /// <summary>
        /// 回答保存フォルダ選択ボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note        : 回答保存フォルダ選択ボタンクリック時に発生します。</br> 
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009.05.31</br>
        /// </remarks>
        private void FolderGuide_Button_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
            {
                //folderBrowserDialog.RootFolder = Environment.SpecialFolder.MyComputer;
                folderBrowserDialog.Description = "回答保存フォルダを選択して下さい。";

                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    this.tEdit_AnswerSaveFolder.DataText = folderBrowserDialog.SelectedPath;
                    //this.SetControlFocus(this.tComboEditor_UOESupplier);
                }
            }
        }

        /// <summary>
        /// グリッド初期レイアウト設定イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note		: 画面初期化時、グリッド初期レイアウト設定を行います。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009.05.31</br>
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
        /// <br>Date        : 2009.06.03</br>
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
        /// <br>Date        : 2009.06.04</br>
        /// </remarks>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null || e.NextCtrl == null) return;

            // 発注先
            if (e.PrevCtrl == this.tComboEditor_UOESupplier)
            {
                // フォーカス設定
                if (e.ShiftKey == false)
                {
                    if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                    {
                        e.NextCtrl = this.tEdit_AnswerSaveFolder;
                    }
                }
                else
                {
                    if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                    {
                        e.NextCtrl = this.FolderGuide_Button;
                    }
                }
            }
            // 回答保存フォルダ
            else if (e.PrevCtrl == this.tEdit_AnswerSaveFolder)
            {
                // フォーカス設定
                if (e.ShiftKey == false)
                {
                    if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                    {
                        e.NextCtrl = this.FolderGuide_Button;
                    }
                }
                else
                {
                    if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                    {
                        e.NextCtrl = this.tComboEditor_UOESupplier;
                    }
                }
            }
            // 回答保存フォルダButton
            else if (e.PrevCtrl == this.FolderGuide_Button)
            {
                // フォーカス設定
                if (e.ShiftKey == false)
                {
                    if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                    {
                        e.NextCtrl = this.tComboEditor_UOESupplier;
                    }
                }
                else
                {
                    if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                    {
                        e.NextCtrl = this.tEdit_AnswerSaveFolder;
                    }
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
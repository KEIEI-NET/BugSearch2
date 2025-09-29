//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 在庫一括削除画面
// プログラム概要   : 在庫一括削除画面UIフォームクラス
//----------------------------------------------------------------------------//
//                (c)Copyright  2020 Broadleaf Co.,Ltd.
//----------------------------------------------------------------------------//
// 管理番号  11570249-00  作成担当 : 譚洪
// 作 成 日  2020/03/09   修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号  11601223-00   作成担当 : 呉元嘯
// 作 成 日  2021/06/21    修正内容 : PMKOBETSU-3268の対応
//----------------------------------------------------------------------------//

using System;
using System.Text;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Collections;

using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Controller.Util;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Windows.Forms;

using Infragistics.Win;
using Infragistics.Win.UltraWinToolbars;

namespace Broadleaf.Windows.Forms
{
    using Broadleaf.Application.Remoting.ParamData;
    using System.Text.RegularExpressions;

	/// <summary>
    /// 在庫一括削除画面メインフレームフォーム
	/// </summary>
    /// <remarks>
    /// <br>Note		: 在庫一括削除画面メインフレームフォーム。</br>
    /// <br>Programmer	: 譚洪</br>
    /// <br>Date		: 2020/03/09</br>
    /// <br>Update Note: 呉元嘯</br>
    /// <br>Date       : 2021/06/21</br>
    /// <br>管理番号   : 11601223-00</br>
    /// <br>           : PMKOBETSU-3268の対応</br> 
    /// </remarks>
	public partial class PMKHN09770UA : Form
    {
        #region Constructor

        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note		: デフォルトコンストラクタ。</br>
        /// <br>Programmer	: 譚洪</br>
        /// <br>Date		: 2020/03/09</br>
        /// </remarks>
        public PMKHN09770UA()
        {
            InitializeComponent();
            DateGetAcsObj = DateGetAcs.GetInstance();
            // ログイン情報生成
            if (LoginInfoAcquisition.Employee != null)
            {
                // 従業員情報
                Employee employee = new Employee();
                employee = LoginInfoAcquisition.Employee;
                //企業コード
                this._enterpriseCode = employee.EnterpriseCode;
                //ログイン従業員コード
                this._employeeCode = employee.EmployeeCode;
                //ログイン従業員名称
                this._employeeName = employee.Name;
            }

            // メーカー品番パターンマスタアクセスクラス
            MakerGoodsPtrnAcs = new HandyMakerGoodsPtrnAcs();
            this._prevInfo = new HandyDeleteStockCondWork();
        }
        #endregion

        #region Private Members
        // クラスID
        private const string ClassID = "PMKHN09770U";
        // ダイアログリザルト
        private DialogResult DialogRes = DialogResult.Cancel;
        // 日付取得部品
        private DateGetAcs DateGetAcsObj;
        /// <summary>倉庫アクセスクラス</summary>
        private WarehouseAcs WarehouseObj;
        /// <summary>メーカーマスタ　アクセスクラス</summary>
        private MakerAcs MakerObj;
        private HandyMakerGoodsPtrnAcs MakerGoodsPtrnAcs;	    // メーカー品番パターンマスタアクセスクラス
        private HandyDeleteStockCondWork _prevInfo;        // 前回入力検索条件情報
        // ログイン情報
        private string _enterpriseCode;
        private string _employeeCode;
        private string _employeeName;

        #endregion

        #region Private Constant
        // 日付が未入力
        private const string NoInput = "を入力してください。";
        // 日付が入力不正
        private const string DateInputError = "最終売上日の入力が不正です。";
        /// <summary>開始検索日付無効年月日のメッセージ</summary>
        private const string SearchDateBeginInvalidDate = "開始検索日付の入力が不正です。";
        /// <summary>終了検索日付無効年月日のメッセージ</summary>
        private const string SearchDateEndInvalidDate = "終了検索日付の入力が不正です。";
        /// <summary>検索日付開始＞終了のメッセージ</summary>
        private const string SearchDateStartEndError = "検索日付の範囲指定に誤りがあります。";
        // 処理条件が入力無し
        private const string NoInputError = "在庫一括削除処理条件を入力して下さい。";
        // 実行ボタン LITERAL
        private const string DoText = "在庫一括削除を実行しますか？";
        // 終了、実行ボタン LITERAL
        private const string Caption = "確認";
        // 抽出中画面部品タイトル
        private const string FormTitle = "在庫一括削除";
        // 抽出中画面部品メッセージ
        private const string FormMessage = "在庫一括削除処理中です";
        // 在庫一括削除対象のデータがないメッセージ
        private const string NoDeleteData = "在庫一括削除対象が存在しません。";
        // 在庫一括削除処理完了メッセージ
        private const string DeleteCopyFinish = "在庫一括削除処理が完了しました。";
        // エラーログ参照メッセージ
        private const string ErrorLog = "在庫一括削除中にエラーが発生しました。";
        // ログインタイトル
        private const string LoginName = "LOGINTITLE";
        // ログイン名称
        private const string LoginNameTitle = "LoginName_LabelTool";
        // [終了]ツールボタンのキー
        private const string ToolButtonCloseKey = "Close";
        // [終了]ツールボタンのアイコン（インデックス）
        private const int ToolButtonCloseIconIndex = (int)Size16_Index.CLOSE;
        // [実行]ツールボタンのキー
        private const string ToolButtonSaveKey = "Save";
        // [実行]ツールボタンのアイコン（インデックス）
        private const int ToolButtonSaveIconIndex = (int)Size16_Index.SAVE;

        /// <summary>日付「0」：日付未入力</summary>
        private const int LongDateZero = 0;
        /// <summary>0ステータス</summary>
        private const int StatusNormal = 0;
        #endregion

        #region Private Methods
        /// <summary>
        /// ツールバーを初期化します。
        /// </summary>
        /// <remarks>
        /// <br>Note       : ツールバーを初期化します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2020/03/09</br>
        /// <br>Update Note: 呉元嘯</br>
        /// <br>Date       : 2021/06/21</br>
        /// <br>管理番号   : 11601223-00</br>
        /// <br>           : PMKOBETSU-3268の対応</br> 
        /// </remarks>
        private void InitializeToolbar()
        {
            // イメージリストを設定する
            this.mainToolbarsManager.ImageListSmall = IconResourceManagement.ImageList16;

            // ツールバーにログイン担当者を表示する            
            this.ShowToolbarSlip();

            ImageList imageList16 = IconResourceManagement.ImageList16;
            this.uButton_GoodsMakerGuide.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.uButton_WarehouseGuide.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            //最終売上日
            this.LastSalesDate_TDateEdit.SetDateTime(DateTime.Now);
            // 倉庫
            this.Warehouse_tComboEditor.SelectedIndex = 0;
            // 棚番
            this.ShelfNo_tComboEdotor.SelectedIndex = 0;
            //-----DEL 2021/06/21 呉元嘯 PMKOBETSU-3268の対応----->>>>>
            //// 在庫数
            //this.tComboEditor_StockCnt.SelectedIndex = 0;
            //-----DEL 2021/06/21 呉元嘯 PMKOBETSU-3268の対応-----<<<<<
            // 検索日付⇒システム日付セット
            DateTime dateTime = DateTime.Now;
            this.tDate_SearchDateBegin.SetDateTime(dateTime);
            this.tDate_SearchDateEnd.SetDateTime(dateTime);
            //--------------------------------------------------------------
            // 標準 ツールバー
            //--------------------------------------------------------------
            // 閉じるツールボタンのアイコン設定
            CloseToolButton.SharedProps.AppearancesSmall.Appearance.Image = ToolButtonCloseIconIndex;

            // 実行ツールボタンのアイコン設定
            SaveToolButton.SharedProps.AppearancesSmall.Appearance.Image = ToolButtonSaveIconIndex;
        }

        /// <summary>
        /// ツールバーにログイン担当者を表示する
        /// </summary>
        private void ShowToolbarSlip()
        {
            //ログイン従業員名称
            if (LoginInfoAcquisition.Employee.Name != null)
            {
                this.mainToolbarsManager.Tools[LoginNameTitle].SharedProps.Caption = LoginInfoAcquisition.Employee.Name;
            }

            LabelTool loginName = (LabelTool)mainToolbarsManager.Tools[LoginNameTitle];
            if (loginName != null && _employeeName != null)
                loginName.SharedProps.Caption = this._employeeName;
        }

        /// <summary>
        /// 抽出条件設定処理(画面→抽出条件)
        /// </summary>
        /// <param name="extraInfo">在庫一括削除画面の抽出条件ワーク</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note		: 画面→抽出条件へ設定する。</br>
        /// <br>Programmer	: 譚洪</br>
        /// <br>Date		: 2020/03/09</br>
        /// <br>Update Note : 呉元嘯</br>
        /// <br>Date        : 2021/06/21</br>
        /// <br>管理番号    : 11601223-00</br>
        /// <br>            : PMKOBETSU-3268の対応</br> 
        /// </remarks>
        private int SetExtraInfoFromScreen(ref HandyDeleteStockCondWork extraInfo)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            try
            {
                extraInfo.EnterpriseCode = this._enterpriseCode;
                // 最終売上日
                extraInfo.LastSalesDate = this.LastSalesDate_TDateEdit.GetLongDate();
                // 倉庫
                extraInfo.WarehouseCode = this.tEdit_WarehouseCode.Text.Trim();
                // メーカー
                extraInfo.GoodsMakerCd = this.tNedit_GoodsMakerCd.GetInt();
                // 倉庫棚番
                extraInfo.WarehouseShelfNo = this.tEdit_WarehouseShelfNo.Text.TrimEnd();
                //-----DEL 2021/06/21 呉元嘯 PMKOBETSU-3268の対応----->>>>>
                //// 在庫数
                //extraInfo.StockDiv = this.tComboEditor_StockCnt.SelectedIndex;
                //-----DEL 2021/06/21 呉元嘯 PMKOBETSU-3268の対応-----<<<<<
                // 使用回数
                extraInfo.UseCount = this.tNedit1_count.GetInt();
                // 検索日付開始
                extraInfo.SearchDateSt = GetLongDate(this.tDate_SearchDateBegin.GetDateTime());
                // 検索日付終了
                extraInfo.SearchDateEd = GetLongDate(this.tDate_SearchDateEnd.GetDateTime());

            }
            catch (Exception)
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            return status;
        }

        /// <summary>
        /// 在庫一括削除処理
        /// </summary>
        /// <param name="deleteStockCondWork">在庫一括削除データ抽出条件ワーク</param>
        /// <remarks>
        /// <br>Note        : 在庫一括削除処理を行う。</br>
        /// <br>Programmer  : 譚洪</br>
        /// <br>Date        : 2020/03/09</br>
        /// </remarks>
        private void DeleteStockWithMng(HandyDeleteStockCondWork deleteStockCondWork)
        {
            // 抽出中画面部品のインスタンスを作成
            Broadleaf.Windows.Forms.SFCMN00299CA form = new Broadleaf.Windows.Forms.SFCMN00299CA();
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            // 表示文字を設定
            form.Title = FormTitle;
            form.Message = FormMessage;
            this.Cursor = Cursors.WaitCursor;
            // ダイアログ表示
            ToolbarOff();
            form.Show();

            //処理結果状態取得
            status = this.MakerGoodsPtrnAcs.DeleteStockWithMng(deleteStockCondWork);

            this.Cursor = Cursors.Default;
            // ダイアログを閉じる
            form.Close();
            ToolbarOn();
            this.Activate();

            // 実行正常の場合
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // 在庫一括削除完了メッセージ
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO,
                                 ClassID,
                                 DeleteCopyFinish,
                                 0,
                                 MessageBoxButtons.OK);

            }
            else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
            {
                // メッセージを表示
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                 ClassID,
                                 NoDeleteData,
                                 0,
                                 MessageBoxButtons.OK);
            }
            else
            {
                //在庫一括削除中にエラーが発生する場合、メッセージを表示
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                 ClassID,
                                 ErrorLog,
                                 0,
                                 MessageBoxButtons.OK);
            }
        }

        #region 日付数値取得処理
        /// <summary>
        /// 日付数値取得処理
        /// </summary>
        /// <param name="date">DateTime型日付</param>
        /// <returns>数値日付(YYYYMMDD)</returns>
        /// <remarks>
        /// <br>Note       : 日付数値取得処理を行う。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        private static int GetLongDate(DateTime date)
        {
            if (date == DateTime.MinValue)
            {
                return 0;
            }
            else
            {
                return ((date.Year * 10000) + (date.Month * 100) + (date.Day));
            }
        }
        #endregion
        #endregion

        #region 入力チェック
        /// <summary>
        /// 画面の入力チェック
        /// </summary>
        /// <remarks>
        /// <br>Note        : 画面の入力チェックを行う</br>
        /// <br>Programmer  : 譚洪</br>
        /// <br>Date        : 2020/03/09</br>
        /// </remarks>
        private bool InputCheck()
        {
            bool status = true;

            string errMessage = null;
            Control errComponent = null;

            if (!this.ScreenInputCheck(ref errMessage, ref errComponent))
            {
                // メッセージを表示
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION, ClassID, errMessage, 0, MessageBoxButtons.OK);
                // コントロールにフォーカスをセット
                if (errComponent != null)
                {
                    errComponent.Focus();
                }
                else
                {
                    //なし
                }
                status = false;
            }
            else
            {
                //なし
            }
            return status;
        }

        /// <summary>
        /// 入力チェック処理
        /// </summary>
        /// <param name="errMessage">エラーメッセージ</param>
        /// <param name="errComponent">エラー発生コンポーネント</param>
        /// <returns>True:OK, False:NG</returns>
        /// <remarks>
        /// <br>Note		: 画面の入力チェックを行う。</br>
        /// <br>Programmer	: 譚洪</br>
        /// <br>Date		: 2020/03/09</br>
        /// <br>Update Note : 呉元嘯</br>
        /// <br>Date        : 2021/06/21</br>
        /// <br>管理番号    : 11601223-00</br>
        /// <br>            : PMKOBETSU-3268の対応</br>
        /// </remarks>
        private bool ScreenInputCheck(ref string errMessage, ref Control errComponent)
        {
            bool status = true;
            // 最終売上日
            if (DateGetAcsObj.CheckDate(ref LastSalesDate_TDateEdit, true) == DateGetAcs.CheckDateResult.ErrorOfInvalid)
            {
                errMessage = DateInputError;
                errComponent = this.LastSalesDate_TDateEdit;
                status = false;
                return status;
            }

            DateGetAcs.CheckDateResult Cdr;

            // 検索日付開始
            if (this.tDate_SearchDateBegin.GetLongDate() != LongDateZero)
            {
                // 無効年月日の場合
                Cdr = this.DateGetAcsObj.CheckDate(ref this.tDate_SearchDateBegin, true);

                if (Cdr != DateGetAcs.CheckDateResult.OK)
                {
                    errMessage = SearchDateBeginInvalidDate;
                    errComponent = this.tDate_SearchDateBegin;
                    status = false;
                    return status;
                }
            }

            // 検索日付終了
            if (this.tDate_SearchDateEnd.GetLongDate() != LongDateZero)
            {
                // 無効年月日の場合
                Cdr = this.DateGetAcsObj.CheckDate(ref this.tDate_SearchDateEnd, true);

                if (Cdr != DateGetAcs.CheckDateResult.OK)
                {
                    errMessage = SearchDateEndInvalidDate;
                    errComponent = this.tDate_SearchDateEnd;
                    status = false;
                    return status;
                }
            }

            // 検索日付開始、終了
            // 開始、終了の大小比較
            if (this.tDate_SearchDateBegin.GetLongDate() != LongDateZero && this.tDate_SearchDateEnd.GetLongDate() != LongDateZero)
            {
                if (this.tDate_SearchDateBegin.GetLongDate() > this.tDate_SearchDateEnd.GetLongDate())
                {
                    errMessage = SearchDateStartEndError;
                    errComponent = this.tDate_SearchDateBegin;
                    status = false;
                    return status;
                }
            }

            // 処理条件無の場合
            // 在庫数が指定なしのみの場合、チェックを行う
            //-----DEL 2021/06/21 呉元嘯 PMKOBETSU-3268の対応----->>>>>
            //if (tComboEditor_StockCnt.SelectedIndex == 0)
            //{
            //-----DEL 2021/06/21 呉元嘯 PMKOBETSU-3268の対応-----<<<<<
                if (string.IsNullOrEmpty(tEdit_WarehouseCode.Text.Trim())
                    && string.IsNullOrEmpty(tEdit_WarehouseShelfNo.Text.Trim())
                    && string.IsNullOrEmpty(tNedit_GoodsMakerCd.Text.Trim())
                    && string.IsNullOrEmpty(tNedit1_count.Text.Trim())
                    && this.LastSalesDate_TDateEdit.GetLongDate() == LongDateZero
                    && this.tDate_SearchDateBegin.GetLongDate() == LongDateZero
                    && this.tDate_SearchDateEnd.GetLongDate() == LongDateZero)
                {
                    errMessage = NoInputError;
                    errComponent = this.Warehouse_tComboEditor;
                    status = false;
                }
            //}// DEL 2021/06/21 呉元嘯 PMKOBETSU-3268の対応 
            return status;
        }
        #endregion
        
        #region ControlEvent

        #region [終了]ツールボタン

        /// <summary>
        /// [終了]ツールボタンを取得します。
        /// </summary>
        /// <remarks>
        /// <br>Note		: 閉じるツールボタン。</br>
        /// <br>Programmer	: 譚洪</br>
        /// <br>Date		: 2020/03/09</br>
        /// </remarks>
        private ButtonTool CloseToolButton
        {
            get { return (ButtonTool)this.mainToolbarsManager.Tools[ToolButtonCloseKey]; }
        }

        #endregion

        #region [実行]ツールボタン

        /// <summary>
        /// [実行]ツールボタンを取得します。
        /// </summary>
        /// <remarks>
        /// <br>Note		: [実行]ツールボタン。</br>
        /// <br>Programmer	: 譚洪</br>
        /// <br>Date		: 2020/03/09</br>
        /// </remarks>
        private ButtonTool SaveToolButton
        {
            get { return (ButtonTool)this.mainToolbarsManager.Tools[ToolButtonSaveKey]; }
        }

        #endregion

        /// <summary>
        /// ツールバーのToolClickイベントハンドラ
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note        : ツールバーのToolClickイベントハンドラ。</br>
        /// <br>Programmer  : 譚洪</br>
        /// <br>Date        : 2020/03/09</br>
        /// </remarks>
        private void mainToolbarsManager_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                case ToolButtonCloseKey: // [終了]
                    {
                        this.Close();
                        break;
                    }
                case ToolButtonSaveKey:  // [実行]
                    {
                        // [実行]ツールボタンをクリック
                        // 確定処理
                        if (InputCheck().Equals(true))
                        {
                            HandyDeleteStockCondWork deleteStockCondWork = new HandyDeleteStockCondWork();
                            // 実行を判断する。
                            if (!TMsgDisp.Show(emErrorLevel.ERR_LEVEL_QUESTION, ClassID, DoText, 0, MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button1).Equals(DialogResult.Yes)) break;
                            // 抽出条件設定処理
                            this.SetExtraInfoFromScreen(ref deleteStockCondWork);
                            // 確定処理
                            this.DeleteStockWithMng(deleteStockCondWork);
                            // ダイアログリザルト設定処理
                            this.SetDialogRes(DialogResult.OK);
                        }
                        else
                        {
                            //なし
                        }
                        break;
                    }
            }
        }

        /// <summary>
        /// ダイアログリザルト設定処理
        /// </summary>
        /// <param name="dialogRes">ダイアログリザルト</param>
        /// <remarks>
        /// <br>Note       : ダイアログリザルト設定処理。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        private void SetDialogRes(DialogResult dialogRes)
        {
            DialogRes = dialogRes;
        }

        /// <summary>
		/// セキュリティ管理メインフレームのLoadイベントハンドラ
		/// </summary>
		/// <param name="sender">イベントソース</param>
		/// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note        : 画面初期化Load時、実行する。</br>
        /// <br>Programmer  : 譚洪</br>
        /// <br>Date        : 2020/03/09</br>
        /// </remarks>
        private void PMKHN09770UA_Load(object sender, EventArgs e)
        {
            // ツールバーを初期化
            InitializeToolbar();
        }
        

        /// <summary>
        /// 矢印キーでのフォーカス移動イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note		: チェックリストボックスフォーカスRight時、移動しない。</br>
        /// <br>Programmer	: 譚洪</br>
        /// <br>Date		: 2020/03/09</br>
        /// </remarks>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null || e.NextCtrl == null) return;

            // マウスでメニュのファンクションボタンをクリックする場合
            if (e.NextCtrl is Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea) return;

            switch (e.PrevCtrl.Name)
            {
                case "Warehouse_tComboEditor":
                    {
                        if (!e.ShiftKey)
                        {
                            if (e.Key == Keys.Up && e.PrevCtrl.Name.Equals("Warehouse_tComboEditor"))
                            {
                                e.NextCtrl = this.Warehouse_tComboEditor;
                            }
                        }

                        break;
                    }
                case "uButton_WarehouseGuide":
                    {
                        if (!e.ShiftKey)
                        {
                            if (e.Key == Keys.Up && e.PrevCtrl.Name.Equals("uButton_WarehouseGuide"))
                            {
                                e.NextCtrl = this.uButton_WarehouseGuide;
                            }
                            if (e.Key == Keys.Down && e.PrevCtrl.Name.Equals("uButton_WarehouseGuide"))
                            {
                                e.NextCtrl = this.ShelfNo_tComboEdotor;
                            }
                        }

                        break;
                    }
                case "tEdit_WarehouseCode":
                    {
                        # region [倉庫]

                        if (!e.ShiftKey)
                        {
                            if (e.Key == Keys.Down && e.PrevCtrl.Name.Equals("tEdit_WarehouseCode"))
                            {
                                e.NextCtrl = this.ShelfNo_tComboEdotor;
                            }
                        }

                        bool status;

                        if (tEdit_WarehouseCode.Text == _prevInfo.WarehouseCode)
                        {
                            status = true;
                        }
                        else
                        {
                            string code;
                            string name;
                            // 読み込み
                            status = ReadWarehouse(tEdit_WarehouseCode.Text, out code, out name);

                            if (status)
                            {
                                // コード・名称を更新
                                tEdit_WarehouseCode.Text = code.TrimEnd();
                                _prevInfo.WarehouseCode = code.TrimEnd();
                                uLabel_WarehouseName.Text = name;
                            }
                            else
                            {
                                tEdit_WarehouseCode.Text = _prevInfo.WarehouseCode;
                            }
                        }

                        if (status == true)
                        {
                            if (!e.ShiftKey)
                            {
                                // NextCtrl制御
                                switch (e.Key)
                                {
                                    case Keys.Return:
                                    case Keys.Tab:
                                        {
                                            if (_prevInfo.WarehouseCode == string.Empty)
                                            {
                                                e.NextCtrl = this.uButton_WarehouseGuide;
                                            }
                                            else
                                            {
                                                e.NextCtrl = this.ShelfNo_tComboEdotor;
                                            }
                                            break;
                                        }
                                }
                            }
                        }
                        else
                        {
                            e.NextCtrl = e.PrevCtrl;
                            TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_INFO,
                                this.Name,
                                "倉庫コードが存在しません。",
                                -1,
                                MessageBoxButtons.OK);
                        }
                        # endregion
                        break;
                    }
                case "tNedit_GoodsMakerCd":
                    {
                        # region [メーカー]

                        bool status = false;

                        if (tNedit_GoodsMakerCd.GetInt() == _prevInfo.GoodsMakerCd)
                        {
                            status = true;
                        }
                        else
                        {
                            int code;
                            string name;
                            // 読み込み
                            status = ReadGoodsMaker(tNedit_GoodsMakerCd.GetInt(), out code, out name);

                            if (status)
                            {
                                // コード・名称を更新
                                tNedit_GoodsMakerCd.SetInt(code);
                                _prevInfo.GoodsMakerCd = code;
                                uLabel_MakerName.Text = name;
                            }
                            else
                            {
                                tNedit_GoodsMakerCd.SetInt(_prevInfo.GoodsMakerCd);
                            }
                        }

                        if (status == true)
                        {
                            if (!e.ShiftKey)
                            {
                                // NextCtrl制御
                                switch (e.Key)
                                {
                                    case Keys.Return:
                                    case Keys.Tab:
                                        {
                                            if (_prevInfo.GoodsMakerCd == 0)
                                            {
                                                e.NextCtrl = this.uButton_GoodsMakerGuide;
                                            }
                                            else
                                            {
                                                e.NextCtrl = this.tNedit1_count;
                                            }
                                            break;
                                        }
                                }
                            }
                        }
                        else
                        {
                            e.NextCtrl = e.PrevCtrl;
                            TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_INFO,
                                this.Name,
                                "メーカーコードが存在しません。",
                                -1,
                                MessageBoxButtons.OK);
                        }
                        # endregion
                        break;
                    }
                case "tComboEditor_StockCnt":
                    {
                        if (!e.ShiftKey)
                        {
                            if (e.Key == Keys.Up && e.PrevCtrl.Name.Equals("tComboEditor_StockCnt"))
                            {
                                e.NextCtrl = this.ShelfNo_tComboEdotor;
                            }
                        }
                        break;
                    }
                case "tEdit_WarehouseShelfNo":
                    {
                        if (!e.ShiftKey)
                        {
                            if (e.Key == Keys.Up && e.PrevCtrl.Name.Equals("tEdit_WarehouseShelfNo"))
                            {
                                e.NextCtrl = this.Warehouse_tComboEditor;
                            }
                        }
                        break;
                    }
                case "LastSalesDate_TDateEdit":
                    {
                        if (!e.ShiftKey)
                        {
                            if (e.Key == Keys.Down && e.PrevCtrl.Name.Equals("LastSalesDate_TDateEdit"))
                            {
                                e.NextCtrl = this.tNedit_GoodsMakerCd;
                            }
                        }
                        break;
                    }
                case "uButton_GoodsMakerGuide":
                    {
                        if (!e.ShiftKey)
                        {
                            if (e.Key == Keys.Up && e.PrevCtrl.Name.Equals("uButton_GoodsMakerGuide"))
                            {
                                e.NextCtrl = this.LastSalesDate_TDateEdit;
                            }
                        }
                        break;
                    }
                case "tDate_SearchDateBegin":

                    // 数字以外を入力する場合、クリアする
                    if (this.tDate_SearchDateBegin.GetDateYear() == 0 || this.tDate_SearchDateBegin.GetDateMonth() == 0 || this.tDate_SearchDateBegin.GetDateDay() == 0)
                    {
                        this.tDate_SearchDateBegin.Clear();
                    }
                    if (!e.ShiftKey && e.Key == Keys.Up)
                    {
                        e.NextCtrl = this.tNedit1_count;
                    }
                    break;
                case "tDate_SearchDateEnd":

                    // 数字以外を入力する場合、クリアする
                    if (this.tDate_SearchDateEnd.GetDateYear() == 0 || this.tDate_SearchDateEnd.GetDateMonth() == 0 || this.tDate_SearchDateEnd.GetDateDay() == 0)
                    {
                        this.tDate_SearchDateEnd.Clear();
                    }
                    if (!e.ShiftKey && e.Key == Keys.Up)
                    {
                        e.NextCtrl = this.tNedit1_count;
                    }

                    break;
            }
        }
        # region ■ ツールバー起動用フラグ ■
        /// <summary>
        /// ツールバー起動用フラグ
        /// </summary>
        /// <remarks>		
        /// <br>Note		: ツールバー起動用処理を行う。</br>
        /// <br>Programmer	: 譚洪</br>	
        /// <br>Date		: 2020/03/09</br>
        /// </remarks>
        private void ToolbarOn()
        {
            this.mainToolbarsManager.Tools[ToolButtonCloseKey].SharedProps.Enabled = true;
            this.mainToolbarsManager.Tools[ToolButtonSaveKey].SharedProps.Enabled = true;
        }
        # endregion ■ ツールバー起動用フラグ ■

        # region ■ ツールバー閉める用フラグ ■
        /// <summary>
        /// ツールバー閉める用フラグ
        /// </summary>
        /// <remarks>		
        /// <br>Note		: ツールバー閉める用処理を行う。</br>
        /// <br>Programmer	: 譚洪</br>	
        /// <br>Date		: 2020/03/09</br>
        /// </remarks>
        private void ToolbarOff()
        {
            this.mainToolbarsManager.Tools[ToolButtonCloseKey].SharedProps.Enabled = false;
            this.mainToolbarsManager.Tools[ToolButtonSaveKey].SharedProps.Enabled = false;
        }
        # endregion ■ ツールバー閉める用フラグ ■


        /// <summary>
        /// 倉庫ガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>		
        /// <br>Note		: 倉庫ガイドボタンクリックときに発生します。</br>
        /// <br>Programmer	: 譚洪</br>	
        /// <br>Date		: 2020/03/09</br>
        /// </remarks>
        private void uButton_WarehouseGuide_Click(object sender, EventArgs e)
        {
            // アクセスクラスインスタンス生成
            if (WarehouseObj == null)
            {
                WarehouseObj = new WarehouseAcs();
            }

            // ガイド実行
            Warehouse warehouse;
            int status = WarehouseObj.ExecuteGuid(out warehouse, this._enterpriseCode);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                this.tEdit_WarehouseCode.Text = warehouse.WarehouseCode.Trim();
                _prevInfo.WarehouseCode = warehouse.WarehouseCode.Trim();
                this.uLabel_WarehouseName.Text = warehouse.WarehouseName;

                // 次フォーカス
                ShelfNo_tComboEdotor.Focus();
            }
        }

        /// <summary>
        /// メーカーガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : メーカーガイドボタンクリックときに発生します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        private void uButton_GoodsMakerGuide_Click(object sender, EventArgs e)
        {
            MakerUMnt makerUMnt;
            // アクセスクラスインスタンス生成
            if (MakerObj == null)
            {
                MakerObj = new MakerAcs();
            }
            int status = MakerObj.ExecuteGuid(this._enterpriseCode, out makerUMnt);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                tNedit_GoodsMakerCd.SetInt(makerUMnt.GoodsMakerCd);
                _prevInfo.GoodsMakerCd = makerUMnt.GoodsMakerCd;
                uLabel_MakerName.Text = makerUMnt.MakerName.Trim();

                // 次フォーカス
                tNedit1_count.Focus();
            }
        }

        /// <summary>
        /// 倉庫抽出条件 値変更イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : 倉庫抽出条件 値変更ときに発生します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        private void Warehouse_tComboEditor_ValueChanged(object sender, EventArgs e)
        {
            if (this.Warehouse_tComboEditor.SelectedIndex == 0)
            {
                this.uButton_WarehouseGuide.Enabled = false;
                this.tEdit_WarehouseCode.Enabled = false;
                this.tEdit_WarehouseCode.Clear();
                this.uLabel_WarehouseName.Text = "";
                this._prevInfo.WarehouseCode = string.Empty;
            }
            else
            {
                this.uButton_WarehouseGuide.Enabled = true;
                this.tEdit_WarehouseCode.Enabled = true;
                this.tEdit_WarehouseCode.Clear();
                this.uLabel_WarehouseName.Text = "";
                this._prevInfo.WarehouseCode = string.Empty;
            }

        }

        /// <summary>
        /// 棚番抽出条件 値変更イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : 棚番抽出条件 値変更ときに発生します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        private void ShelfNo_tComboEdotor_ValueChanged(object sender, EventArgs e)
        {
            if (this.ShelfNo_tComboEdotor.SelectedIndex == 0)
            {
                this.tEdit_WarehouseShelfNo.Enabled = false;
                this.tEdit_WarehouseShelfNo.Clear();
            }
            else
            {
                this.tEdit_WarehouseShelfNo.Enabled = true;
                this.tEdit_WarehouseShelfNo.Clear();
            }

        }

        /// <summary>
        /// 倉庫Read
        /// </summary>
        /// <param name="warehouseCode">倉庫コード</param>
        /// <param name="code">倉庫コード</param>
        /// <param name="name">倉庫名</param>
        /// <returns>Read処理結果</returns>
        /// <remarks>
        /// <br>Note       : 倉庫Read</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        private bool ReadWarehouse(string warehouseCode, out string code, out string name)
        {
            bool result = false;

            // 未入力判定
            if (warehouseCode != string.Empty)
            {
                // 読み込み
                if (WarehouseObj == null)
                {
                    WarehouseObj = new WarehouseAcs();
                }
                Warehouse warehouse;
                string warehouseCd = warehouseCode.Trim().PadLeft(4, '0');
                int status = WarehouseObj.Read(out warehouse, this._enterpriseCode, string.Empty, warehouseCd);

                if (status == 0 && warehouse != null && warehouse.LogicalDeleteCode == 0)
                {
                    // 該当あり→表示
                    code = warehouse.WarehouseCode.TrimEnd();
                    name = warehouse.WarehouseName;

                    result = true;
                }
                else
                {
                    // 該当なし→クリア
                    code = string.Empty;
                    name = string.Empty;

                    // ＮＧにする
                    result = false;
                }
            }
            else
            {
                // 未入力→クリア
                code = string.Empty;
                name = string.Empty;

                result = true;
            }

            return result;
        }

        /// <summary>
        /// 商品メーカーRead
        /// </summary>
        /// <param name="goodsMakerCd">商品メーカーコード</param>
        /// <param name="code">商品メーカーコード</param>
        /// <param name="name">商品メーカー名</param>
        /// <returns>Read処理結果</returns>
        /// <remarks>
        /// <br>Note       : 商品メーカーRead</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        private bool ReadGoodsMaker(int goodsMakerCd, out int code, out string name)
        {
            bool result = false;

            // 未入力判定
            if (goodsMakerCd != 0)
            {
                // 読み込み
                if (MakerObj == null)
                {
                    MakerObj = new MakerAcs();
                }
                MakerUMnt maker;
                int status = MakerObj.Read(out maker, this._enterpriseCode, goodsMakerCd);

                if (status == 0 && maker != null && maker.LogicalDeleteCode == 0)
                {
                    // 該当あり→表示
                    code = maker.GoodsMakerCd;
                    name = maker.MakerName;

                    result = true;
                }
                else
                {
                    // 該当なし→クリア
                    code = 0;
                    name = string.Empty;

                    // ＮＧにする
                    result = false;
                }
            }
            else
            {
                // 未入力→クリア
                code = 0;
                name = string.Empty;

                result = true;
            }

            return result;
        }

        # endregion

    }
}
//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : ハンディターミナル循環棚卸照会
// プログラム概要   : ハンディターミナル循環棚卸照会の検索を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2017 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11370074-00 作成担当 : 陳艶丹
// 作 成 日  2017/08/16  修正内容 : 新規作成
//----------------------------------------------------------------------------//
using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Collections;
using System.Drawing;
using System.Reflection;
using System.ComponentModel;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Resources;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// ハンディターミナル循環棚卸照会メインフレームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : ハンディターミナル循環棚卸照会メインフレームの定義と実装を行うクラス。</br>
    /// <br>Programmer : 陳艶丹</br>
    /// <br>Date       : 2017/08/16</br>
    /// </remarks>
    public partial class PMHND04401UA : System.Windows.Forms.Form
    {
        #region ■Private Const
        /// <summary>終了ボタン</summary>
        private const string ButtonToolClose = "ButtonTool_Close";
        /// <summary>検索ボタン</summary>
        private const string ButtonToolSearch = "ButtonTool_Search";
        /// <summary>クリアボタン</summary>
        private const string ButtonToolClear = "ButtonTool_Clear";
        /// <summary>ログイン担当者名称</summary>
        private const string LabelToolLoginName = "LabelTool_LoginName";

        /// <summary>開始棚卸日未入力のメッセージ</summary>
        private const string IoInventDayBeginEmptyDate = "開始棚卸日を入力して下さい。";
        /// <summary>開始棚卸日無効年月日のメッセージ</summary>
        private const string IoInventDayBeginInvalidDate = "開始棚卸日の入力が不正です。";
        /// <summary>終了棚卸日未入力のメッセージ</summary>
        private const string IoInventDayEndEmptyDate = "終了棚卸日を入力して下さい。";
        /// <summary>終了棚卸日無効年月日のメッセージ</summary>
        private const string IoInventDayEndInvalidDate = "終了棚卸日の入力が不正です。";
        /// <summary>棚卸日開始＞終了のメッセージ</summary>
        private const string IoInventDayStartEndError = "棚卸日の範囲指定に誤りがあります。";
        /// <summary>棚番開始＞終了のメッセージ</summary>
        private const string IoWarehouseShelfNoStartEndError = "棚番の範囲指定に誤りがあります。";
        /// <summary>倉庫開始＞終了のメッセージ</summary>
        private const string IoWarehouseCodeStartEndError = "倉庫の範囲指定に誤りがあります。";

        /// <summary>従業員情報取得エラーのメッセージ</summary>
        private const string EmployeeSearchError = "従業員情報取得に失敗しました。";
        /// <summary>倉庫情報取得エラーのメッセージ</summary>
        private const string WarehouseInfoSearchError = "倉庫情報取得に失敗しました。";
        /// <summary>メーカー情報取得エラーのメッセージ</summary>
        private const string GoodsMakerInfoSearchError = "メーカー情報取得に失敗しました。";

        /// <summary>倉庫情報取得できないのメッセージ</summary>
        private const string WarehouseInfoEmptyError = "倉庫コードが存在しません。";
        /// <summary>メーカー情報取得できないのメッセージ</summary>
        private const string GoodsMakerInfoEmptyError = "メーカーコードが存在しません。";
        /// <summary>従業員情報取得できないのメッセージ</summary>
        private const string EmployeeInfoEmptyError = "従業員コードが存在しません。";

        /// <summary>データ情報取得できないのメッセージ</summary>
        private const string DataInfoEmptyError = "該当するデータがありません。";
        /// <summary>循環棚卸情報取得エラーのメッセージ</summary>
        private const string InventInfoSearchError = "読み込みに失敗しました。"; 

        /// <summary>プログラムID</summary>
        private const string AssemblyId = "PMHND04401U";
        /// <summary>プログラム名前</summary>
        private const string AssemblyName = "循環棚卸照会";
        /// <summary>グリッド列表示状態保存処理エラーのメッセージ</summary>
        private const string ColDisplayStatusSaveError = "グリッド列表示状態保存処理に失敗しました。";
        /// <summary>列表示状態セッティングXMLファイル名</summary>
        private const string FileNameColDisplayStatus = "PMHND04401U_ColSetting.DAT";

        /// <summary>抽出中画面のタイトル</summary>
        private const string SearchFormTitle = "抽出中";
        /// <summary>抽出中画面のメッセージ</summary>
        private const string SearchFormMessage = "データ抽出中です。";
        /// <summary>数量フォーマット</summary>
        private const string CountFormat = "#,###,##0.00";

        enum GoodNoSearchType
        {
            /// <summary>あいまい検索「と一致」ステータス</summary>
            MatchWith = 0,
            /// <summary>あいまい検索「で始る」ステータス</summary>
            StartWith = 1,
            /// <summary>あいまい検索「で終る」ステータス</summary>
            EndWith = 2,
            /// <summary>あいまい検索「を含む」ステータス</summary>
            IncludeWith = 3,
        };

        /// <summary>0文字列</summary>
        private const char CharZero = '0';
        /// <summary>0文字列</summary>
        private const string StringZero = "0";
        /// <summary>*文字列</summary>
        private const string StringHash = "*";
        /// <summary>日付フォーマット</summary>
        private const string DateFormat = "yyyy/MM/dd";
        /// <summary>時刻フォーマット</summary>
        private const string TimeFormat = "HH:mm";


        /// <summary>文字列の一部を補正(PadLeft用:4)</summary>
        private const int PadLeftIndexFour = 4;
        /// <summary>削除フラグ「0」：有効</summary>
        private const int DataEffective = 0;
        /// <summary>0ステータス</summary>
        private const int StatusNormal = 0;
        /// <summary>日付「0」：日付未入力</summary>
        private const int LongDateZero = 0;
        /// <summary>グリッドデータ件数「0」：グリッドデータ件数0件</summary>
        private const int InventGridRowsCountZero = 0;
        /// <summary>-1ステータス</summary>
        private const int StatusError = -1;
        
        #endregion ■ Private Const

        # region ◆Private Members
        /// <summary>明細データ格納データビュー</summary>
        private DataView DataViewInvent = null;
        /// <summary>明細データ格納データセット</summary>
        private CirculInventDataSet CirculInventData = null;
        /// <summary>循環棚卸アクセスクラス</summary>
        private HandyCirculInventAcs CirculInventAcs = null;
        /// <summary>FLAG</summary>
        private Boolean IsSaveFlg=false;
        /// <summary>企業コード</summary>
        private string EnterpriseCode = string.Empty;
        /// <summary>日付アクセスクラス</summary>
        private DateGetAcs DateGetAccessor = null;
        /// <summary>画面イメージ</summary>
        private ImageList ImageList16 = null;

        /// <summary>前回入力従業員コード</summary>
        private string PrevEmployeeCode = string.Empty;
        /// <summary>前回入力従業員名</summary>
        private string PrevEmployeeName = string.Empty;
        /// <summary>前回入力メーカーコード</summary>
        private string PrevGoodsMakerCode = string.Empty;
        /// <summary>前回入力メーカー名</summary>
        private string PrevGoodsMakerName = string.Empty;

        /// <summary>倉庫アクセスクラス</summary>
        private WarehouseAcs WarehouseAccessor = null;
        /// <summary>メーカーアクセスクラス</summary>
        private MakerAcs MakerAccessor = null;
        /// <summary>従業員アクセスクラス</summary>
        private EmployeeAcs EmployeeAccessor = null;

        /// <summary>倉庫ディクショナリー</summary>
        private Dictionary<string, string> WarehouseDic = null;
        /// <summary>メーカーディクショナリー</summary>
        private Dictionary<int, string> GoodsMakerDic = null;
        /// <summary>従業員ディクショナリー</summary>
        private Dictionary<string, string> EmployeeDic = null;
        # endregion

        #region ◆Constractor
        /// <summary>
        /// ハンディターミナル循環棚卸照会フォームクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       :ハンディターミナル循環棚卸照会フォームクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2017/08/16</br>
        /// </remarks>
        public PMHND04401UA()
        {
            InitializeComponent();
            // 循環棚卸アクセスクラス
            this.CirculInventAcs=new HandyCirculInventAcs ();
            // 企業コードを取得します。
            this.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            // 日付アクセスクラスを初期化します。
            this.DateGetAccessor = DateGetAcs.GetInstance();
            // コントロール部品イメージを設定します。
            this.ImageList16 = IconResourceManagement.ImageList16;

            // 倉庫アクセスクラスを初期化します。
            this.WarehouseAccessor = new WarehouseAcs();
            // 倉庫マスタデータキャッシューします。
            int status = this.GetWarehouseInfo();

            // 倉庫情報を取得できない場合
            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                this.ErrMsgDispProc(WarehouseInfoSearchError, status);
                this.Close();
            }
            // 従業員アクセスクラスを初期化します。
            this.EmployeeAccessor = new EmployeeAcs();
            // 従業員マスタデータキャッシューします
            status = this.GetEmployeeInfo();
            // 従業員情報を取得できない場合
            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                this.ErrMsgDispProc(EmployeeSearchError, status);
                this.Close();
            }

            // メーカーアクセスクラスを初期化します。
            this.MakerAccessor = new MakerAcs();
            // メーカーマスタデータキャッシューします。
            status = this.GetGoodsMakerInfo();

            // メーカー情報を取得できない場合
            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                this.ErrMsgDispProc(GoodsMakerInfoSearchError, status);
                this.Close();
            }

        }
        #endregion

        #region ◆ControlEvent
        /// <summary>
        /// Form.Load イベント (PMHND04401U)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : フォームが表示されるときに発生します。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2017/08/16</br>
        /// </remarks>
        private void PMHND04401UA_Load(object sender, EventArgs e)
        {
            // 画面を構築
            this.ScreenInitialSetting();
            this.ScreenClear();
        }

        /// <summary>
        /// メインメニュークリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : メインメニューをクリックした際に発生するイベントハンドラ</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2017/08/16</br>
        /// </remarks>
        private void tToolsManager_MainMenu_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            // 処理中、再処理不可
            // IsSaveFlgがTrueの場合、処理不可。IsSaveFlgがFalseの場合、処理可
            if (this.IsSaveFlg)
            {
                return;
            }
            this.IsSaveFlg = true;

            #region 各処理前、フォーカスアウト補正処理
            Control ActiveControl = this.GetActiveControl();
            if (ActiveControl != null)
            {
                if (ActiveControl != this.Invent_Grid)
                {
                    ChangeFocusEventArgs ex = new ChangeFocusEventArgs(false, false, false, Keys.Right, this.GetActiveControl(), this.tEdit_WarehouseCode_St);
                    this.tArrowKeyControl1_ChangeFocus(sender, ex);
                }
                else
                {
                    this.tEdit_WarehouseCode_St.Focus();
                    this.Invent_Grid.Focus();
                }
            }
            #endregion

            try
            {
                switch (e.Tool.Key)
                {
                    #region 終了(F1)
                    case "ButtonTool_Close":
                        {
                            // 終了処理
                            this.Close();

                            break;
                        }
                    #endregion

                    #region 検索(F2)
                    case "ButtonTool_Search":
                        {
                            // 入力項目チェック処理
                            if (!this.CheckInputPara())
                            {
                                return;
                            }
                            // 検索処理
                            this.SearchProc();

                            break;
                        }
                    #endregion

                    #region クリア(F9)
                    case "ButtonTool_Clear":
                        {
                            this.ScreenClear();
                            break;
                        }
                    #endregion
                }
            }
            finally
            {
                this.IsSaveFlg = false;
            }
        }

        /// <summary>
        /// アクティブコントロール取得処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : アクティブコントロールを取得します。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2017/08/16</br>
        /// </remarks>
        private Control GetActiveControl()
        {
            Control Ctrl = this.ActiveControl;

            if (Ctrl != null)
            {
                Ctrl = this.GetParentControl(Ctrl);
            }

            return Ctrl;
        }

        /// <summary>
        /// 親コントロール取得処理
        /// </summary>
        /// <param name="ctrl">子コントロール</param>
        /// <returns>親コントロール</returns>
        /// <remarks>
        /// <br>Note       : 親コントロールを取得します。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2017/08/16</br>
        /// </remarks>
        private Control GetParentControl(Control ctrl)
        {
            Control RetCtrl = ctrl;
            if (RetCtrl.Parent != null)
            {
                if ((RetCtrl.Parent is Broadleaf.Library.Windows.Forms.TNedit) ||
                    (RetCtrl.Parent is Broadleaf.Library.Windows.Forms.TEdit) ||
                    (RetCtrl.Parent is Broadleaf.Library.Windows.Forms.TDateEdit) ||
                    (RetCtrl.Parent is Broadleaf.Library.Windows.Forms.TComboEditor))
                {
                    RetCtrl = GetParentControl(RetCtrl.Parent);
                }
            }

            return RetCtrl;
        }

        /// <summary>
        /// フォーム閉じる処理
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : フォームを閉じる前に、ユーザーがフォームを閉じようとしたときに発生します。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2017/08/16</br>
        /// </remarks>
        private void PMHND04401UA_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                this.BeforeClosing();
            }
            catch
            {
                // エラーメッセージ表示
                this.ErrMsgDispProc(ColDisplayStatusSaveError, StatusError);

            }
        }

        #endregion

        #region ◆Private Method
        /// <summary>
        /// 画面初期設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note	   : 画面の初期設定を行います。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2017/08/16</br>
        /// </remarks>
        private void ScreenInitialSetting()
        {
            // ガイドボタンのアイコン設定
            this.ub_WarehouseGuideSt.Appearance.Image = this.ImageList16.Images[(int)Size16_Index.STAR1];
            this.ub_WarehouseGuideEd.Appearance.Image = this.ImageList16.Images[(int)Size16_Index.STAR1];
            this.ub_Employee.Appearance.Image = this.ImageList16.Images[(int)Size16_Index.STAR1];
            this.ub_GoodsMakerCd.Appearance.Image = this.ImageList16.Images[(int)Size16_Index.STAR1];

            // イメージリスト設定
            this.tToolsManager_MainMenu.ImageListSmall = IconResourceManagement.ImageList16;

            //----------------------------
            // ツールアイコン設定
            //----------------------------
            // 終了
            this.tToolsManager_MainMenu.Tools[ButtonToolClose].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;
            // 検索
            this.tToolsManager_MainMenu.Tools[ButtonToolSearch].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SEARCH;
            // クリア
            this.tToolsManager_MainMenu.Tools[ButtonToolClear].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.ALLCANCEL;

            // 担当者表示
            if (LoginInfoAcquisition.Employee != null)
            {
                this.tToolsManager_MainMenu.Tools[LabelToolLoginName].SharedProps.Caption = LoginInfoAcquisition.Employee.Name;
            }

            this.CirculInventData = new CirculInventDataSet();

            this.DataViewInvent = new DataView(this.CirculInventData.InventList);

            this.Invent_Grid.DataSource = this.DataViewInvent;

            // 棚卸日(開始)と棚卸日(終了)設定
            DateTime date = new DateTime();
            date = DateTime.Now;
            this.tDate_InventoryDateStart.SetDateTime(date);
            this.tDate_InventoryDateEnd.SetDateTime(date);

            // グリッド列初期設定処理
            InitializeGridColumns(this.Invent_Grid.DisplayLayout.Bands[0].Columns);
        }

        /// <summary>
        /// 画面クリア処理
        /// </summary>
        /// <remarks>
        /// <br>Note	   : 画面をクリアします。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2017/08/16</br>
        ///</remarks>
        private void ScreenClear()
        {
            // グリッドをクリアします。
            this.CirculInventData.InventList.Clear();

            // 日付に情報をクリアします。
            this.tDate_InventoryDateStart.Clear();
            this.tDate_InventoryDateEnd.Clear();

            // 棚卸日(開始)と棚卸日(終了)⇒システム日付セット
            DateTime dateTime = DateTime.Now;
            this.tDate_InventoryDateStart.SetDateTime(dateTime);
            this.tDate_InventoryDateEnd.SetDateTime(dateTime);

            // 画面内容をクリアします。
            this.tEdit_WarehouseCode_St.Text = string.Empty;
            this.tEdit_WarehouseCode_Ed.Text = string.Empty;
            this.tEdit_WarehouseShelfNoStart.Text = string.Empty;
            this.tEdit_WarehouseShelfNoEnd.Text = string.Empty;
            this.tEdit_EmployeeCode.Text = string.Empty;
            this.lb_EmployeeName.Text = string.Empty;
            this.tNedit_GoodsMakerCd.Clear();
            this.lb_GoodsMakerName.Text = string.Empty;
            this.tEdit_Note.Text = string.Empty;
            this.tEdit_GoodsNo.Text = string.Empty;
            this.tEdit_WarehouseCode_St.Focus();
        }

        #region グリッドレイアウト設定処理
        /// <summary>
        /// グリッドレイアウト設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : グリッドレイアウトを設定します。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2017/08/16</br>
        /// </remarks>
        private void InitializeGridColumns(Infragistics.Win.UltraWinGrid.ColumnsCollection columns)
        {
            int visiblePosition = 0;

            Infragistics.Win.UltraWinGrid.ColumnsCollection Columns = this.Invent_Grid.DisplayLayout.Bands[0].Columns;

            // 一旦、全ての列を非表示にする。
            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn column in Columns)
            {
                //非表示設定
                column.Hidden = true;
                column.Header.Fixed = false;
            }

            // 倉庫コード
            columns[this.CirculInventData.InventList.WarehouseCodeColumn.ColumnName].Hidden = false;
            columns[this.CirculInventData.InventList.WarehouseCodeColumn.ColumnName].Header.Caption = "倉庫コード";
            columns[this.CirculInventData.InventList.WarehouseCodeColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            columns[this.CirculInventData.InventList.WarehouseCodeColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            columns[this.CirculInventData.InventList.WarehouseCodeColumn.ColumnName].Width = 120;
            columns[this.CirculInventData.InventList.WarehouseCodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            columns[this.CirculInventData.InventList.WarehouseCodeColumn.ColumnName].Header.Fixed = true;
            columns[this.CirculInventData.InventList.WarehouseCodeColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // 倉庫名
            columns[this.CirculInventData.InventList.WarehouseNameColumn.ColumnName].Hidden = false;
            columns[this.CirculInventData.InventList.WarehouseNameColumn.ColumnName].Header.Caption = "倉庫名";
            columns[this.CirculInventData.InventList.WarehouseNameColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            columns[this.CirculInventData.InventList.WarehouseNameColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            columns[this.CirculInventData.InventList.WarehouseNameColumn.ColumnName].Width = 150;
            columns[this.CirculInventData.InventList.WarehouseNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            columns[this.CirculInventData.InventList.WarehouseNameColumn.ColumnName].Header.Fixed = true;
            columns[this.CirculInventData.InventList.WarehouseNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // 棚卸日
            columns[this.CirculInventData.InventList.InventoryDateColumn.ColumnName].Hidden = false;
            columns[this.CirculInventData.InventList.InventoryDateColumn.ColumnName].Header.Caption = "棚卸日";
            columns[this.CirculInventData.InventList.InventoryDateColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            columns[this.CirculInventData.InventList.InventoryDateColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            columns[this.CirculInventData.InventList.InventoryDateColumn.ColumnName].Width = 100;
            columns[this.CirculInventData.InventList.InventoryDateColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            columns[this.CirculInventData.InventList.InventoryDateColumn.ColumnName].Header.Fixed = true;
            columns[this.CirculInventData.InventList.InventoryDateColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // 棚卸時刻
            columns[this.CirculInventData.InventList.InventoryTimeColumn.ColumnName].Hidden = false;
            columns[this.CirculInventData.InventList.InventoryTimeColumn.ColumnName].Header.Caption = "棚卸時刻";
            columns[this.CirculInventData.InventList.InventoryTimeColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            columns[this.CirculInventData.InventList.InventoryTimeColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            columns[this.CirculInventData.InventList.InventoryTimeColumn.ColumnName].Width = 100;
            columns[this.CirculInventData.InventList.InventoryTimeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            columns[this.CirculInventData.InventList.InventoryTimeColumn.ColumnName].Header.Fixed = true;
            columns[this.CirculInventData.InventList.InventoryTimeColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // 棚番
            columns[this.CirculInventData.InventList.WarehouseShelfNoColumn.ColumnName].Hidden = false;
            columns[this.CirculInventData.InventList.WarehouseShelfNoColumn.ColumnName].Header.Caption = "棚番";
            columns[this.CirculInventData.InventList.WarehouseShelfNoColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            columns[this.CirculInventData.InventList.WarehouseShelfNoColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            columns[this.CirculInventData.InventList.WarehouseShelfNoColumn.ColumnName].Width = 100;
            columns[this.CirculInventData.InventList.WarehouseShelfNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            columns[this.CirculInventData.InventList.WarehouseShelfNoColumn.ColumnName].Header.Fixed = true;
            columns[this.CirculInventData.InventList.WarehouseShelfNoColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // メーカー
            columns[this.CirculInventData.InventList.MakerNameColumn.ColumnName].Hidden = false;
            columns[this.CirculInventData.InventList.MakerNameColumn.ColumnName].Header.Caption = "メーカー";
            columns[this.CirculInventData.InventList.MakerNameColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            columns[this.CirculInventData.InventList.MakerNameColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            columns[this.CirculInventData.InventList.MakerNameColumn.ColumnName].Width = 150;
            columns[this.CirculInventData.InventList.MakerNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            columns[this.CirculInventData.InventList.MakerNameColumn.ColumnName].Header.Fixed = true;
            columns[this.CirculInventData.InventList.MakerNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // 品番
            columns[this.CirculInventData.InventList.GoodsNoColumn.ColumnName].Hidden = false;
            columns[this.CirculInventData.InventList.GoodsNoColumn.ColumnName].Header.Caption = "品番";
            columns[this.CirculInventData.InventList.GoodsNoColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            columns[this.CirculInventData.InventList.GoodsNoColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            columns[this.CirculInventData.InventList.GoodsNoColumn.ColumnName].Width = 160;
            columns[this.CirculInventData.InventList.GoodsNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            columns[this.CirculInventData.InventList.GoodsNoColumn.ColumnName].Header.Fixed = true;
            columns[this.CirculInventData.InventList.GoodsNoColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // 品名
            columns[this.CirculInventData.InventList.GoodsNameColumn.ColumnName].Hidden = false;
            columns[this.CirculInventData.InventList.GoodsNameColumn.ColumnName].Header.Caption = "品名";
            columns[this.CirculInventData.InventList.GoodsNameColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            columns[this.CirculInventData.InventList.GoodsNameColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            columns[this.CirculInventData.InventList.GoodsNameColumn.ColumnName].Width = 180;
            columns[this.CirculInventData.InventList.GoodsNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            columns[this.CirculInventData.InventList.GoodsNameColumn.ColumnName].Header.Fixed = true;
            columns[this.CirculInventData.InventList.GoodsNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // 帳簿数
            columns[this.CirculInventData.InventList.StockTotalColumn.ColumnName].Hidden = false;
            columns[this.CirculInventData.InventList.StockTotalColumn.ColumnName].Header.Caption = "帳簿数";
            columns[this.CirculInventData.InventList.StockTotalColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            columns[this.CirculInventData.InventList.StockTotalColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            columns[this.CirculInventData.InventList.StockTotalColumn.ColumnName].Width = 120;
            columns[this.CirculInventData.InventList.StockTotalColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            columns[this.CirculInventData.InventList.StockTotalColumn.ColumnName].Header.Fixed = true;
            columns[this.CirculInventData.InventList.StockTotalColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // 棚卸数
            columns[this.CirculInventData.InventList.InventoryStockCntColumn.ColumnName].Hidden = false;
            columns[this.CirculInventData.InventList.InventoryStockCntColumn.ColumnName].Header.Caption = "棚卸数";
            columns[this.CirculInventData.InventList.InventoryStockCntColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            columns[this.CirculInventData.InventList.InventoryStockCntColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            columns[this.CirculInventData.InventList.InventoryStockCntColumn.ColumnName].Width = 120;
            columns[this.CirculInventData.InventList.InventoryStockCntColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            columns[this.CirculInventData.InventList.InventoryStockCntColumn.ColumnName].Header.Fixed = true;
            columns[this.CirculInventData.InventList.InventoryStockCntColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // 棚卸担当者
            columns[this.CirculInventData.InventList.EmployeeCodeColumn.ColumnName].Hidden = false;
            columns[this.CirculInventData.InventList.EmployeeCodeColumn.ColumnName].Header.Caption = "棚卸担当者";
            columns[this.CirculInventData.InventList.EmployeeCodeColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            columns[this.CirculInventData.InventList.EmployeeCodeColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            columns[this.CirculInventData.InventList.EmployeeCodeColumn.ColumnName].Width = 150;
            columns[this.CirculInventData.InventList.EmployeeCodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            columns[this.CirculInventData.InventList.EmployeeCodeColumn.ColumnName].Header.Fixed = true;
            columns[this.CirculInventData.InventList.EmployeeCodeColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // 備考
            columns[this.CirculInventData.InventList.NoteColumn.ColumnName].Hidden = false;
            columns[this.CirculInventData.InventList.NoteColumn.ColumnName].Header.Caption = "備考";
            columns[this.CirculInventData.InventList.NoteColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            columns[this.CirculInventData.InventList.NoteColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            columns[this.CirculInventData.InventList.NoteColumn.ColumnName].Width = 150;
            columns[this.CirculInventData.InventList.NoteColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            columns[this.CirculInventData.InventList.NoteColumn.ColumnName].Header.Fixed = true;
            columns[this.CirculInventData.InventList.NoteColumn.ColumnName].Header.VisiblePosition = visiblePosition++;


            //-------------------------------------------------------------
            // 前回表示情報設定
            //-------------------------------------------------------------
            // 列表示状態クラスリストXMLファイルをデシリアライズ
            List<ColDisplayStatus> colDisplayStatusList = this.Deserialize(FileNameColDisplayStatus);

            foreach (ColDisplayStatus colDisplayStatus in colDisplayStatusList)
            {
                if (colDisplayStatus.Key == this.FontSize_tComboEditor.Name)
                {
                    this.FontSize_tComboEditor.Value = colDisplayStatus.Width;
                }
                else if (columns.Exists(colDisplayStatus.Key))
                {
                    columns[colDisplayStatus.Key].Header.VisiblePosition = colDisplayStatus.VisiblePosition;
                    columns[colDisplayStatus.Key].Header.Fixed = colDisplayStatus.HeaderFixed;
                    columns[colDisplayStatus.Key].Width = colDisplayStatus.Width;
                }
            }
        }
        #endregion

        /// <summary>
        /// 倉庫(開始)ガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : 倉庫(開始)ガイドボタンクリックイベント。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2017/08/16</br>
        /// </remarks>
        private void ub_WarehouseGuideSt_Click(object sender, EventArgs e)
        {
            try
            {
                Warehouse warehouseWork;
                int status = this.WarehouseAccessor.ExecuteGuid(out warehouseWork, this.EnterpriseCode);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    this.tEdit_WarehouseCode_St.Text = warehouseWork.WarehouseCode.Trim();

                    // 次のコントロールへフォーカスを移動
                    this.SelectNextControl((Control)sender, true, true, true, true);
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// 倉庫(終了)ガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : 倉庫(終了)ガイドボタンクリックイベント。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2017/08/16</br>
        /// </remarks>
        private void ub_WarehouseGuideEd_Click(object sender, EventArgs e)
        {
            try
            {
                Warehouse warehouseWork;
                int status = this.WarehouseAccessor.ExecuteGuid(out warehouseWork, this.EnterpriseCode);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    this.tEdit_WarehouseCode_Ed.Text = warehouseWork.WarehouseCode.Trim();

                    // 次のコントロールへフォーカスを移動
                    this.SelectNextControl((Control)sender, true, true, true, true);
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// メーカーガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : メーカーガイドボタンクリックイベント。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2017/08/16</br>
        /// </remarks>
        private void ub_GoodsMakerCd_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                MakerUMnt makerUMntWork;

                int status = this.MakerAccessor.ExecuteGuid(this.EnterpriseCode, out makerUMntWork);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // 結果セット
                    this.tNedit_GoodsMakerCd.SetInt(makerUMntWork.GoodsMakerCd);
                    this.lb_GoodsMakerName.Text = makerUMntWork.MakerName;

                    #region < 編集前データ保持 >
                    // 編集されたメーカー情報を編集前データとして保持
                    this.PrevGoodsMakerCode = this.tNedit_GoodsMakerCd.GetInt().ToString();
                    this.PrevGoodsMakerName = this.lb_GoodsMakerName.Text.Trim();
                    #endregion

                    // 次のコントロールへフォーカスを移動
                    this.SelectNextControl((Control)sender, true, true, true, true);
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// 棚卸担当者ガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : 棚卸担当者ガイドボタンクリックイベント。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2017/08/16</br>
        /// </remarks>
        private void ub_Employee_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                // ガイド表示
                Employee employeeInfoWork;
                int status;
                status = this.EmployeeAccessor.ExecuteGuid(this.EnterpriseCode, true, out employeeInfoWork);

                // ステータスが正常の場合
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // コードと名称をセット
                    this.tEdit_EmployeeCode.Text = employeeInfoWork.EmployeeCode.TrimEnd();
                    this.lb_EmployeeName.Text = employeeInfoWork.Name.TrimEnd();

                    #region < 編集前データ保持 >
                    // 編集された棚卸担当者情報を編集前データとして保持
                    this.PrevEmployeeCode = this.tEdit_EmployeeCode.Text.Trim();
                    this.PrevEmployeeName = this.lb_EmployeeName.Text.Trim();
                    #endregion

                    // 次のコントロールへフォーカスを移動
                    this.SelectNextControl((Control)sender, true, true, true, true);
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// 検索処理
        /// </summary>
        /// <returns>[0: 正常, 4: 検索結果0件,0、4以外: 異常]</returns>
        /// <remarks>
        /// <br>Note       : 循環棚卸情報の検索処理を行ないます。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2017/08/16</br>
        /// </remarks>
        private int SearchProc()
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            // パラメータを設定します。
            HandyInventoryCondWork condWork = new HandyInventoryCondWork();
            // 企業コード
            condWork.EnterpriseCode = (string)this.EnterpriseCode;
            // 倉庫コード(開始)
            condWork.WarehouseCode = (string)this.tEdit_WarehouseCode_St.Value;
            // 倉庫コード(終了)
            condWork.WarehouseCodeEd = (string)this.tEdit_WarehouseCode_Ed.Value;
            // 棚卸日(開始)
            condWork.InventoryDateStart = this.tDate_InventoryDateStart.GetDateTime();
            // 棚卸日(終了)
            condWork.InventoryDateEnd = this.tDate_InventoryDateEnd.GetDateTime();
            // 倉庫棚番(開始)
            condWork.WarehouseShelfNoStart = (string)this.tEdit_WarehouseShelfNoStart.Value;
            // 倉庫棚番(終了)
            condWork.WarehouseShelfNoEnd = (string)this.tEdit_WarehouseShelfNoEnd.Value;
            // 従業員コード
            condWork.EmployeeCode = (string)this.tEdit_EmployeeCode.Value;
            // 商品メーカーコード
            condWork.GoodsMakerCd = Convert.ToInt32(this.tNedit_GoodsMakerCd.Value);
            // 備考
            condWork.Note = (string)this.tEdit_Note.Value;
            // 品番検索タイプ
            string resultGoodsNo = null;
            int goodsNoSrchTyp=this.getGoodsNoType((string)this.tEdit_GoodsNo.Value, out resultGoodsNo);
            condWork.GoodsNoSrchTyp = goodsNoSrchTyp;
            // 商品番号
            condWork.GoodsNo = resultGoodsNo;

            object condObj = condWork as object;
            ArrayList dataWorkList = new ArrayList();
            // 抽出中画面インスタンス作成
            Broadleaf.Windows.Forms.SFCMN00299CA sfcmn00299ca = new Broadleaf.Windows.Forms.SFCMN00299CA();
            sfcmn00299ca.Title = SearchFormTitle;
            sfcmn00299ca.Message = SearchFormMessage;

            try
            {
                // 抽出中画面を表示します。
                sfcmn00299ca.Show();
                object retObj = null;
                status = this.CirculInventAcs.SearchCirculInvent(condObj, out retObj);
                dataWorkList = (ArrayList)retObj;
            }
            finally
            {
                // 抽出中画面を閉じます。
                sfcmn00299ca.Close();
                this.CirculInventData.InventList.Clear();
            }

            #region < 検索後処理 >
            switch (status)
            {
                #region -- 正常終了 --
                // 全件取得メソッドの結果が"正常終了"のとき
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        // 検索結果はグリッドに設定します。
                        this.InventGridSetting(dataWorkList);
                        // グリッド選択行を設定します。
                        if (this.Invent_Grid.Rows.Count > InventGridRowsCountZero)
                        {
                            this.Invent_Grid.Focus();
                            this.Invent_Grid.ActiveRow = this.Invent_Grid.Rows[0];
                            this.Invent_Grid.ActiveRow.Selected = true;
                        }

                        break;
                    }
                #endregion

                #region -- データ無し --
                case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    {
                        this.InfoMsgDispProc(DataInfoEmptyError, status);
                        break;
                    }
                #endregion

                #region -- 検索失敗 --
                default:
                    {
                        this.ErrMsgDispProc(InventInfoSearchError, status);
                        break;
                    }
                #endregion
            }
            #endregion

            return status;

        }

        /// <summary>
        /// グリッドに情報設定処理
        /// </summary>
        /// <param name="dataWorkList">循環棚卸情報リスト</param>
        /// <remarks>
        /// <br>Note       : グリッドに循環棚卸情報を設定します。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2017/08/16</br>
        /// </remarks>
        private void InventGridSetting(ArrayList dataWorkList)
        {
            if (dataWorkList == null || dataWorkList.Count == InventGridRowsCountZero)
            {
                return;
            }

            this.CirculInventData.InventList.BeginLoadData();
            this.CirculInventData.InventList.Rows.Clear();

            DataRow row = null;
            foreach (HandyInventoryDataWork dataWork in dataWorkList)
            {
                row = this.CirculInventData.InventList.NewRow();
                // 棚卸日
                row[this.CirculInventData.InventList.InventoryDateColumn] = dataWork.InventoryDateTime.ToString(DateFormat);
                // 棚卸時刻
                row[this.CirculInventData.InventList.InventoryTimeColumn] = dataWork.InventoryDateTime.ToString(TimeFormat);
                // 倉庫コード
                row[this.CirculInventData.InventList.WarehouseCodeColumn] = dataWork.WarehouseCode;
                // 倉庫名
                row[this.CirculInventData.InventList.WarehouseNameColumn] = getWarehouseName(dataWork.WarehouseCode);
                // 棚番
                row[this.CirculInventData.InventList.WarehouseShelfNoColumn] = dataWork.WarehouseShelfNo;
                // メーカー
                row[this.CirculInventData.InventList.MakerNameColumn] = dataWork.MakerName;
                // 品名
                row[this.CirculInventData.InventList.GoodsNameColumn] = dataWork.GoodsName;
                // 品番
                row[this.CirculInventData.InventList.GoodsNoColumn] = dataWork.GoodsNo;
                // 帳簿数
                row[this.CirculInventData.InventList.StockTotalColumn] = dataWork.StockTotal.ToString(CountFormat);
                // 棚卸数
                row[this.CirculInventData.InventList.InventoryStockCntColumn] = dataWork.InventoryStockCnt.ToString(CountFormat);
                // 棚卸担当者
                row[this.CirculInventData.InventList.EmployeeCodeColumn] = this.GetEmployeeName(dataWork.EmployeeCode.Trim());
                // 備考
                row[this.CirculInventData.InventList.NoteColumn] = dataWork.Note;

                this.CirculInventData.InventList.Rows.Add(row);
            }
            this.CirculInventData.InventList.EndLoadData();
        }

        /// <summary>
        /// 入力項目チェック処理
        /// </summary>
        /// <returns>チェック結果[true: チェックOK, false: チェックエラー]</returns>
        /// <remarks>
        /// <br>Note       : 入力項目をチェックします。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2017/08/16</br>
        /// </remarks>
        private bool CheckInputPara()
        {
            bool checkInputParaFlg = true;

            DateGetAcs.CheckDateResult cdr;

            // 倉庫コード開始、終了の範囲チェック
            if (!String.IsNullOrEmpty(this.tEdit_WarehouseCode_St.DataText.Trim()) &&
                !String.IsNullOrEmpty(this.tEdit_WarehouseCode_Ed.DataText.Trim()) &&
                 (this.tEdit_WarehouseCode_St.DataText.TrimEnd().PadLeft(4, '0').CompareTo(this.tEdit_WarehouseCode_Ed.DataText.TrimEnd().PadLeft(4, '0')) > 0))
            {
                this.tEdit_WarehouseCode_St.Focus();

                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    IoWarehouseCodeStartEndError,
                    StatusNormal,
                    MessageBoxButtons.OK);

                return false;
            }
            // 棚卸日開始未入力の場合
            if (this.tDate_InventoryDateStart.GetLongDate() == LongDateZero)
            {
                this.tDate_InventoryDateStart.Focus();

                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    IoInventDayBeginEmptyDate,
                    StatusNormal,
                    MessageBoxButtons.OK);

                return false;
            }
            // 棚卸日開始が無効年月日の場合
            cdr = this.DateGetAccessor.CheckDate(ref this.tDate_InventoryDateStart, true);
            if (cdr != DateGetAcs.CheckDateResult.OK)
            {
                this.tDate_InventoryDateStart.Focus();

                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    IoInventDayBeginInvalidDate,
                    StatusNormal,
                    MessageBoxButtons.OK);

                return false;
            }
            // 棚卸日終了未入力の場合
            if (this.tDate_InventoryDateEnd.GetLongDate() == LongDateZero)
            {
                this.tDate_InventoryDateEnd.Focus();

                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    IoInventDayEndEmptyDate,
                    StatusNormal,
                    MessageBoxButtons.OK);

                return false;
            }
            // 棚卸日終了が無効年月日の場合
            cdr = this.DateGetAccessor.CheckDate(ref this.tDate_InventoryDateEnd, true);
            if (cdr != DateGetAcs.CheckDateResult.OK)
            {
                this.tDate_InventoryDateEnd.Focus();

                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    IoInventDayEndInvalidDate,
                    StatusNormal,
                    MessageBoxButtons.OK);

                return false;
            }
            // 棚卸日開始、終了の範囲チェック
            if (this.tDate_InventoryDateStart.GetLongDate() > this.tDate_InventoryDateEnd.GetLongDate())
            {
                this.tDate_InventoryDateStart.Focus();

                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    IoInventDayStartEndError,
                    StatusNormal,
                    MessageBoxButtons.OK);

                return false;
            }
            // 棚番開始、終了の範囲チェック
            if (!String.IsNullOrEmpty(this.tEdit_WarehouseShelfNoStart.DataText.Trim()) &&
                !String.IsNullOrEmpty(this.tEdit_WarehouseShelfNoEnd.DataText.Trim()) &&
                 (this.tEdit_WarehouseShelfNoStart.DataText.CompareTo(this.tEdit_WarehouseShelfNoEnd.DataText) > 0))
            {
                this.tEdit_WarehouseShelfNoStart.Focus();
                TMsgDisp.Show(
                   this,
                   emErrorLevel.ERR_LEVEL_INFO,
                   this.Name,
                   IoWarehouseShelfNoStartEndError,
                   StatusNormal,
                   MessageBoxButtons.OK);
                return false;
            }

            return checkInputParaFlg;
        }

        /// <summary>
        /// 品番検索タイプ区分の取得処理
        /// </summary>
        /// <param name="inputGoodsNo">入力品番</param>
        /// <param name="resultGoodsNo">変更後品番</param>
        /// <returns>取得結果[0：完全一致、1：前方一致、2：後方一致、3：曖昧]</returns>
        /// <remarks>
        /// <br>Note       : 品番検索タイプ区分を取得します。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2017/08/16</br>
        /// </remarks>
        private int getGoodsNoType(string inputGoodsNo, out string resultGoodsNo)
        {
            int goodsNoType = 0;
            resultGoodsNo = string.Empty;
            if (string.IsNullOrEmpty(inputGoodsNo)) return goodsNoType;

            if (!inputGoodsNo.Contains(StringHash))
            {
                // [*]なし（「と一致」）
                goodsNoType = (int)GoodNoSearchType.MatchWith;
            }
            else if (inputGoodsNo.StartsWith(StringHash) && inputGoodsNo.EndsWith(StringHash))
            {
                // [*]…[*]（「を含む」）
                goodsNoType = (int)GoodNoSearchType.IncludeWith;
            }
            else if (inputGoodsNo.StartsWith(StringHash))
            {
                // [*]…（「で終る」）
                goodsNoType = (int)GoodNoSearchType.EndWith;
            }
            else if (inputGoodsNo.EndsWith(StringHash))
            {
                // …[*]（「で始る」）
                goodsNoType = (int)GoodNoSearchType.StartWith;
            }
            resultGoodsNo = inputGoodsNo.Replace(StringHash, string.Empty);
            return goodsNoType;
        }

        #region ◎ エラーメッセージ表示処理
        /// <summary>
        /// エラーメッセージ表示処理
        /// </summary>
        /// <param name="message">表示メッセージ</param>
        /// <param name="status">ステータス</param>
        /// <remarks>
        /// <br>Note       : エラーメッセージの表示を行います。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2017/08/16</br>
        /// </remarks>
        private void ErrMsgDispProc(string message, int status)
        {
            TMsgDisp.Show(
                emErrorLevel.ERR_LEVEL_STOP, 							// エラーレベル
                AssemblyId,						// アセンブリＩＤまたはクラスＩＤ
                AssemblyName,						// プログラム名称
                MethodBase.GetCurrentMethod().Name, // 処理名称
                string.Empty,						// オペレーション
                message,							// 表示するメッセージ
                status, 							// ステータス値
                string.Empty, 						// エラーが発生したオブジェクト
                MessageBoxButtons.OK, 				// 表示するボタン
                MessageBoxDefaultButton.Button1);	// 初期表示ボタン
        }

        /// <summary>
        /// インフォメッセージ表示処理
        /// </summary>
        /// <param name="message">表示メッセージ</param>
        /// <param name="status">ステータス</param>
        /// <remarks>
        /// <br>Note       : インフォメッセージの表示を行います。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2017/08/16</br>
        /// </remarks>
        private void InfoMsgDispProc(string message, int status)
        {
            TMsgDisp.Show(this,											// 親ウィンドウフォーム
                          emErrorLevel.ERR_LEVEL_INFO,					// エラーレベル
                          AssemblyId,									// アセンブリＩＤ
                          message, 										// 表示するメッセージ
                          status,										// ステータス値
                          MessageBoxButtons.OK);						// 表示するボタン
        }

        #endregion

        /// <summary>
        /// Control.ChangeFocus イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : フォーカス移動時に発生します。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2017/08/16</br>
        /// </remarks>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null || e.NextCtrl == null) return;

            switch (e.PrevCtrl.Name)
            {
                #region ●倉庫コード(開始)
                case "tEdit_WarehouseCode_St":
                    {
                        int number;
                        if (!Int32.TryParse(this.tEdit_WarehouseCode_St.DataText.Trim(), out number))
                        {
                            this.tEdit_WarehouseCode_St.DataText = string.Empty;
                        }

                        if (e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Enter:
                                case Keys.Tab:
                                    {
                                        if (this.Invent_Grid.Rows.Count > 0)
                                        {
                                            e.NextCtrl = null;
                                            this.Invent_Grid.Focus();
                                            this.Invent_Grid.ActiveRow = this.Invent_Grid.Rows[0];
                                            this.Invent_Grid.ActiveRow.Selected = true;
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.tEdit_GoodsNo;
                                        }
                                    }
                                    break;
                            }
                        }
                        break;
                    }
                #endregion

                #region ●倉庫コード(終了)
                case "tEdit_WarehouseCode_Ed":
                    {
                        int number;
                        if (!Int32.TryParse(this.tEdit_WarehouseCode_Ed.DataText.Trim(), out number))
                        {
                            this.tEdit_WarehouseCode_Ed.DataText = string.Empty;
                        }
                        break;
                    }
                #endregion

                #region ●メーカーコード
                case "tNedit_GoodsMakerCd":
                    {
                        // 変数保持
                        string goodsMakerCd = this.tNedit_GoodsMakerCd.GetInt().ToString();

                        #region < メーカー検索 >
                        if (goodsMakerCd != StringZero)
                        {
                            string goodsMakerName = this.getGoodsMakerName(goodsMakerCd);

                            if (string.IsNullOrEmpty(goodsMakerName))
                            {
                                TMsgDisp.Show(
                                    this,
                                    emErrorLevel.ERR_LEVEL_INFO,
                                    this.Name,
                                    GoodsMakerInfoEmptyError,
                                    -1,
                                    MessageBoxButtons.OK);
                                if (!string.IsNullOrEmpty(this.PrevGoodsMakerCode))
                                {
                                    this.tNedit_GoodsMakerCd.SetInt(int.Parse(this.PrevGoodsMakerCode));
                                }
                                this.tNedit_GoodsMakerCd.SelectAll();
                                e.NextCtrl = this.tNedit_GoodsMakerCd;
                            }
                            else
                            {
                                this.tNedit_GoodsMakerCd.SetInt(int.Parse(goodsMakerCd));
                                this.lb_GoodsMakerName.Text = goodsMakerName;
                                if (!e.ShiftKey && (e.Key == Keys.Tab || e.Key == Keys.Return))
                                {
                                    e.NextCtrl = this.tEdit_Note;
                                }
                            }
                        }
                        else
                        {
                            this.tNedit_GoodsMakerCd.Clear();
                            this.lb_GoodsMakerName.Text = string.Empty;
                        }

                        #endregion

                        #region < 編集前データ保持 >
                        // 編集されたメーカー情報を編集前データとして保持
                        this.PrevGoodsMakerCode = this.tNedit_GoodsMakerCd.GetInt().ToString();
                        this.PrevGoodsMakerName = this.lb_GoodsMakerName.Text.Trim();
                        #endregion
                        break;
                    }

                #endregion

                #region ●棚卸担当者
                case "tEdit_EmployeeCode":
                    {
                        // 変数保持
                        string inventEmployee = this.tEdit_EmployeeCode.Text;

                        #region < 従業員検索 >
                        if (!string.IsNullOrEmpty(inventEmployee))
                        {
                            string employeeName = this.GetEmployeeName(inventEmployee.PadLeft(PadLeftIndexFour, CharZero));

                            if (string.IsNullOrEmpty(employeeName))
                            {
                                TMsgDisp.Show(
                                    this,
                                    emErrorLevel.ERR_LEVEL_INFO,
                                    this.Name,
                                    EmployeeInfoEmptyError,
                                    -1,
                                    MessageBoxButtons.OK);

                                this.tEdit_EmployeeCode.Text = this.PrevEmployeeCode;
                                this.tEdit_EmployeeCode.SelectAll();
                                e.NextCtrl = this.tEdit_EmployeeCode;
                            }
                            else
                            {
                                this.tEdit_EmployeeCode.Text = inventEmployee.PadLeft(PadLeftIndexFour, CharZero);
                                this.lb_EmployeeName.Text = employeeName;
                                if (!e.ShiftKey && (e.Key == Keys.Tab || e.Key == Keys.Return))
                                {
                                    e.NextCtrl = this.tNedit_GoodsMakerCd;
                                }
                            }

                        }
                        else
                        {
                            this.tEdit_EmployeeCode.Clear();
                            this.lb_EmployeeName.Text = string.Empty;
                        }

                        #endregion

                        #region < 編集前データ保持 >
                        // 編集された棚卸担当者情報を編集前データとして保持
                        this.PrevEmployeeCode = this.tEdit_EmployeeCode.Text;
                        this.PrevEmployeeName = this.lb_EmployeeName.Text.Trim();
                        #endregion

                        break;
                    }

                #endregion

                #region ●棚卸日開始
                case "tDate_InventoryDateStart":

                    if (e.Key == Keys.Down)
                    {
                        e.NextCtrl = this.tEdit_EmployeeCode;
                    }
                    // 数字以外を入力する場合、クリアする
                    if (this.tDate_InventoryDateStart.GetDateYear() == 0 || this.tDate_InventoryDateStart.GetDateMonth() == 0 || this.tDate_InventoryDateStart.GetDateDay() == 0)
                    {
                        this.tDate_InventoryDateStart.Clear();
                    }
                    break;
                #endregion

                #region ●棚卸日終了
                case "tDate_InventoryDateEnd":

                    // 数字以外を入力する場合、クリアする
                    if (this.tDate_InventoryDateEnd.GetDateYear() == 0 || this.tDate_InventoryDateEnd.GetDateMonth() == 0 || this.tDate_InventoryDateEnd.GetDateDay() == 0)
                    {
                        this.tDate_InventoryDateEnd.Clear();
                    }
                    if (e.Key == Keys.Down)
                    {
                        e.NextCtrl = this.ub_Employee;
                    }
                    break;
                #endregion

                // 商品番号
                case "tEdit_GoodsNo":
                   
                    if (e.ShiftKey)
                    {
                        if (e.Key == Keys.Tab || e.Key == Keys.Return)
                        {
                            e.NextCtrl = this.tEdit_Note;
                        }
                    }
                    else
                    {
                        if (e.Key == Keys.Tab || e.Key == Keys.Return)
                        {
                            if (this.Invent_Grid.Rows.Count > 0)
                            {
                                e.NextCtrl = null;
                                this.Invent_Grid.Focus();
                                this.Invent_Grid.ActiveRow = this.Invent_Grid.Rows[0];
                                this.Invent_Grid.ActiveRow.Selected = true;
                            }
                            else
                            {
                                e.NextCtrl = this.tEdit_WarehouseCode_St;
                            }
                        }
                        if (e.Key == Keys.Down)
                        {
                            if (this.Invent_Grid.Rows.Count > 0)
                            {
                                e.NextCtrl = null;
                                this.Invent_Grid.Focus();
                                this.Invent_Grid.ActiveRow = this.Invent_Grid.Rows[0];
                                this.Invent_Grid.ActiveRow.Selected = true;
                            }
                            else
                            {
                                e.NextCtrl = this.tEdit_GoodsNo;
                            }
                        }
                    }
                    break;
            }
        }

        /// <summary>
        /// 倉庫名の取得処理。
        /// </summary>
        /// <param name="warehouseCode">倉庫コード</param>
        /// <returns>倉庫名</returns>
        /// <remarks>
        /// <br>Note       : 倉庫名を取得します。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2017/08/16</br>
        /// </remarks>
        private string getWarehouseName(string warehouseCode)
        {
            string warehouseName = string.Empty;
            if (string.IsNullOrEmpty(warehouseCode)) return warehouseName;

            if (this.WarehouseDic.ContainsKey(warehouseCode.Trim()))
            {
                warehouseName = this.WarehouseDic[warehouseCode.Trim()];
            }

            return warehouseName;
        }

        /// <summary>
        /// メーカー名の取得処理。
        /// </summary>
        /// <param name="goodsMakerCode">メーカーコード</param>
        /// <returns>メーカー名</returns>
        /// <remarks>
        /// <br>Note       : メーカー名を取得します。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2017/08/16</br>
        /// </remarks>
        private string getGoodsMakerName(string goodsMakerCode)
        {
            string goodsMakerName = string.Empty;
            if (string.IsNullOrEmpty(goodsMakerCode)) return goodsMakerName;
            int goodsMakerCd = int.Parse(goodsMakerCode.Trim());

            if (this.GoodsMakerDic.ContainsKey(goodsMakerCd))
            {
                goodsMakerName = this.GoodsMakerDic[goodsMakerCd];
            }

            return goodsMakerName;
        }

        /// <summary>
        /// 従業員名称取得処理
        /// </summary>
        /// <param name="employeeCode">従業員コード</param>
        /// <returns>従業員名称</returns>
        /// <remarks>
        /// <br>Note       : 従業員名称を取得します。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2017/08/16</br>
        /// </remarks>
        private string GetEmployeeName(string employeeCode)
        {
            string EmployeeName = string.Empty;

            if (this.EmployeeDic.ContainsKey(employeeCode))
            {
                EmployeeName = this.EmployeeDic[employeeCode];
            }

            return EmployeeName;
        }

        /// <summary>
        /// 倉庫情報のキャッシュ処理。
        /// </summary>
        /// <returns>取得結果[0: 取得OK, 0以外: 取得エラー]</returns>
        /// <remarks>
        /// <br>Note       : 倉庫情報をキャッシュします。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2017/08/16</br>
        /// </remarks>
        private int GetWarehouseInfo()
        {
            ArrayList warehouseWork = new ArrayList();
            int status = this.WarehouseAccessor.SearchAll(out warehouseWork, this.EnterpriseCode);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                this.WarehouseDic = new Dictionary<string, string>();
                foreach (Warehouse warehouse in warehouseWork)
                {
                    if (warehouse.LogicalDeleteCode == DataEffective && !this.WarehouseDic.ContainsKey(warehouse.WarehouseCode.Trim().PadLeft(PadLeftIndexFour, CharZero)))
                    {
                        this.WarehouseDic.Add(warehouse.WarehouseCode.Trim().PadLeft(PadLeftIndexFour, CharZero), warehouse.WarehouseName.Trim());
                    }
                }
            }
            return status;
        }

        /// <summary>
        /// メーカー情報のキャッシュ処理。
        /// </summary>
        /// <returns>取得結果[0: 取得OK, 0以外: 取得エラー]</returns>
        /// <remarks>
        /// <br>Note       : メーカー情報をキャッシュします。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2017/08/16</br>
        /// </remarks>
        private int GetGoodsMakerInfo()
        {
            ArrayList makerList = new ArrayList();
            int status = this.MakerAccessor.SearchAll(out makerList, this.EnterpriseCode);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                this.GoodsMakerDic = new Dictionary<int, string>();
                foreach (MakerUMnt makerUMntWork in makerList)
                {
                    if (makerUMntWork.LogicalDeleteCode == 0 && !this.GoodsMakerDic.ContainsKey(makerUMntWork.GoodsMakerCd))
                    {
                        this.GoodsMakerDic.Add(makerUMntWork.GoodsMakerCd, makerUMntWork.MakerName.Trim());
                    }
                }
            }
            return status;
        }

        /// <summary>
        /// 従業員マスタ読込処理
        /// </summary>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 従業員マスタを読込、バッファに保持します。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2017/08/16</br>
        /// </remarks>
        private int GetEmployeeInfo()
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            this.EmployeeDic = new Dictionary<string, string>();

            try
            {
                ArrayList retList;
                ArrayList retList2;
                status = this.EmployeeAccessor.Search(out retList, out retList2, LoginInfoAcquisition.EnterpriseCode);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    foreach (Employee employeeWork in retList)
                    {
                        if (employeeWork.LogicalDeleteCode == 0)
                        {
                            this.EmployeeDic.Add(employeeWork.EmployeeCode.Trim().PadLeft(PadLeftIndexFour, CharZero), employeeWork.Name.Trim());
                        }
                    }
                }
            }
            catch
            {
                // 処理なし
            }

            return status;
        }
  
        /// <summary>
        /// 列サイズの自動調整チェック変更
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : 列サイズの自動調整のチェックが変更された時に発生します。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2017/08/16</br>
        /// </remarks>
        private void AutoFitCol_ultraCheckEditor_CheckedChanged(object sender, EventArgs e)
        {
            // 列サイズの自動調整
            if (this.AutoFitCol_ultraCheckEditor.Checked)
                this.Invent_Grid.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;
            else
                this.Invent_Grid.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.None;

            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn wkColumn in this.Invent_Grid.DisplayLayout.Bands[0].Columns)
            {
                wkColumn.PerformAutoResize(Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand);
            }
        }

        /// <summary>
        /// フォントサイズ値変更
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : フォントサイズの値が変更された時に発生します。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2017/08/16</br>
        /// </remarks>
        private void FontSize_tComboEditor_ValueChanged(object sender, EventArgs e)
        {
            // フォントサイズを変更
            this.Invent_Grid.DisplayLayout.Appearance.FontData.SizeInPoints = (int)FontSize_tComboEditor.Value;
        }

        /// <summary>
        /// 列表示状態クラスリスト構築処理
        /// </summary>
        /// <param name="columns">グリッドのカラムコレクション</param>
        /// <returns>列表示状態クラスリスト</returns>
        /// <remarks>
        /// <br>Note       : グリッドのカラムコレクションを元に、列表示状態クラスリストを構築します。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2017/08/16</br>
        /// </remarks>
        private List<ColDisplayStatus> ColDisplayStatusListConstruction(Infragistics.Win.UltraWinGrid.ColumnsCollection columns)
        {
            List<ColDisplayStatus> colDisplayStatusList = new List<ColDisplayStatus>();

            // フォントサイズを格納
            ColDisplayStatus fontStatus = new ColDisplayStatus();
            fontStatus.Key = this.FontSize_tComboEditor.Name;
            fontStatus.VisiblePosition = -1;
            fontStatus.Width = (int)this.FontSize_tComboEditor.Value;
            colDisplayStatusList.Add(fontStatus);

            // グリッドから列表示状態クラスリストを構築
            // グループ内の各カラム
            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn column in columns)
            {
                ColDisplayStatus colDisplayStatus = new ColDisplayStatus();
                colDisplayStatus.Key = column.Key;
                colDisplayStatus.VisiblePosition = column.Header.VisiblePosition;
                colDisplayStatus.HeaderFixed = column.Header.Fixed;
                colDisplayStatus.Width = column.Width;

                colDisplayStatusList.Add(colDisplayStatus);
            }

            return colDisplayStatusList;
        }

        /// <summary>
        /// 終了前処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 終了前処理を行う。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2017/08/16</br>
        /// </remarks>
        private void BeforeClosing()
        {
            // 列表示状態クラスリスト構築処理
            List<ColDisplayStatus> colDisplayStatusList = this.ColDisplayStatusListConstruction(this.Invent_Grid.DisplayLayout.Bands[0].Columns);
            // 列表示状態クラスリストをXMLにシリアライズする
            this.Serialize(colDisplayStatusList, FileNameColDisplayStatus);
        }

        /// <summary>
        /// 列表示状態クラスリストシリアライズ処理
        /// </summary>
        /// <param name="colDisplayStatusList">列表示状態クラスリスト</param>
        /// <param name="fileName">ファイル名</param>
        /// <remarks>
        /// <br>Note       : 列表示状態クラスリストのシリアライズ処理を行います。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2017/08/16</br>
        /// </remarks>
        private void Serialize(List<ColDisplayStatus> colDisplayStatusList, string fileName)
        {
            ColDisplayStatus[] colDisplayStatusArray = new ColDisplayStatus[colDisplayStatusList.Count];
            colDisplayStatusList.CopyTo(colDisplayStatusArray);

            UserSettingController.SerializeUserSetting(colDisplayStatusArray, Path.Combine(ConstantManagement_ClientDirectory.UISettings_GridInfo, fileName));
        }

        /// <summary>
        /// 列表示状態クラスリストデシリアライズ処理
        /// </summary>
        /// <param name="fileName">ファイル名</param>
        /// <returns>列表示状態クラスリスト</returns>
        /// <remarks>
        /// <br>Note       : 列表示状態クラスリストのデシリアライズ処理を行います。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2017/08/16</br>
        /// </remarks>
        public List<ColDisplayStatus> Deserialize(string fileName)
        {
            List<ColDisplayStatus> retList = new List<ColDisplayStatus>();

            if (UserSettingController.ExistUserSetting(Path.Combine(ConstantManagement_ClientDirectory.UISettings_GridInfo, fileName)) == true)
            {
                try
                {
                    ColDisplayStatus[] retArray = UserSettingController.DeserializeUserSetting<ColDisplayStatus[]>(Path.Combine(ConstantManagement_ClientDirectory.UISettings_GridInfo, fileName));

                    foreach (ColDisplayStatus colDisplayStatus in retArray)
                    {
                        retList.Add(colDisplayStatus);
                    }
                }
                catch (System.InvalidOperationException)
                {
                    UserSettingController.DeleteUserSetting(Path.Combine(ConstantManagement_ClientDirectory.UISettings_GridInfo, fileName));
                }
            }

            return retList;
        }

        /// <summary>
        /// 棚卸データグリッドのLeaveイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : 棚卸データグリッドのLeaveイベントを行う。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2017/08/16</br>
        /// </remarks>
        private void Invent_Grid_Leave(object sender, EventArgs e)
        {
            if (this.Invent_Grid.ActiveRow != null)
            {
                this.Invent_Grid.ActiveRow.Selected = false;
                this.Invent_Grid.ActiveRow = null;
            }

        }

        /// <summary>
        /// 棚卸データグリッドのKeyDownイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : 棚卸データグリッドのKeyDownイベントを行う。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2017/08/16</br>
        /// </remarks>
        private void Invent_Grid_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.Invent_Grid.ActiveRow != null && this.Invent_Grid.ActiveRow.Index == 0 && e.KeyCode == Keys.Up)
            {
                this.tEdit_GoodsNo.Focus();
            }
        }
        #endregion

    }
}

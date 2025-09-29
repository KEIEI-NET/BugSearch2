//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 車輌管理マスタ(一括入力)
// プログラム概要   : 車輌管理マスタの登録・変更・削除を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 李占川
// 作 成 日  2009/09/07  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 張莉莉
// 修 正 日  2009/10/10  修正内容 : 障害報告Redmine#537の修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 張莉莉
// 修 正 日  2009/10/21  修正内容 : MANTIS：0014457 障害報告Redmine#784の修正
//                                  MANTIS：0014458 障害報告Redmine#784の修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 張莉莉
// 修 正 日  2009/10/26  修正内容 : 障害報告Redmine#831,879,878の修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 李占川
// 修 正 日  2010/06/08  修正内容 : 管理番号選択時の不具合修正
//----------------------------------------------------------------------------//
// 管理番号  10900269-00 作成担当 : FSI高橋 文彰
// 修 正 日  2013/03/22  修正内容 : SPK車台番号文字列対応に伴う国産/外車区分の追加
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 脇田 靖之
// 修 正 日  2013/05/14  修正内容 : 全体初期表示設定の元号表示区分（年式）対応
//----------------------------------------------------------------------------//
// 管理番号  11270098-00 作成担当 : 呉軍
// 作 成 日  2016/12/13  修正内容 : Redmine#48934 PMNSナンバープレート英文字対応
//----------------------------------------------------------------------------//
// 管理番号  11770175-00 作成担当 : 佐々木亘
// 修 正 日  2021/11/02  修正内容 : OUT OF MEMORY対応(4GB対応) 車輌管理マスタ保守
//                                  抽出対象件数を最大件数20001件まで（20000件まで画面表示）
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Library.Resources;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win;
using Broadleaf.Library.Windows.Forms;
using System.Collections;
using System.Text.RegularExpressions;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 車輌管理マスタコントロールクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 車輌管理マスタの明細表示、入力を行う</br>
    /// <br>Programmer : 李占川</br>
    /// <br>Date       : 2009/09/07</br>
    /// <br>Update Note : 張莉莉 2009/10/10</br>
    /// <br>            : 障害報告Redmine#537の修正</br>
    /// <br>Update Note : 李占川 2010/06/08 障害改良対応（７月分）</br>
    /// <br>            : 管理番号選択時の不具合修正</br>
    /// <br>UpdateNote  : 2016/12/13 呉軍</br>
    /// <br>管理番号    : 11270098-00</br>
    /// <br>            : Redmine#48934 PMNSナンバープレート英文字対応</br>
    /// </remarks>
    public partial class PMSYA09021UB : UserControl
    {
        #region ■private定数
        // グリッド列
        private const string column_No = "RowNo";
        private const string column_CarRelationGuid = "CarRelationGuid";
        private const string column_DeleteDate = "DeleteDate";
        private const string column_CustomerCode = "CustomerCode";
        private const string column_CustomerCodeGuide = "CustomerCodeGuide";
        private const string column_CarMngCode = "CarMngCode";
        private const string column_CarMngCodeGuide = "CarMngCodeGuide";
        private const string column_ModelFullName = "ModelFullName";
        private const string column_FullModel = "FullModel";
        private const string column_ModelDesignationNo = "ModelDesignationNo";
        private const string column_CategoryNo = "CategoryNo";
        private const string column_EngineModelNm = "EngineModelNm";
        private const string column_FirstEntryDate = "FirstEntryDate";
        private const string column_FrameNo = "FrameNo";
        private const string column_ColorCode = "ColorCode";
        private const string column_TrimCode = " TrimCode";
        private const string column_EngineModel = "EngineModel";
        private const string column_CarAddInfo1 = "CarAddInfo1";
        private const string column_CarAddInfo2 = "CarAddInfo2";
        private const string column_NumberPlate1Code = "NumberPlate1Code";
        private const string column_NumberPlate1CodeGuide = "NumberPlate1CodeGuide";
        private const string column_NumberPlate1Name = "NumberPlate1Name";
        private const string column_NumberPlate2 = "NumberPlate2";
        private const string column_NumberPlate3 = "NumberPlate3";
        private const string column_NumberPlate4 = "NumberPlate4";
        private const string column_Mileage = "Mileage";
        private const string column_CarInspectYear = "CarInspectYear";
        private const string column_EntryDate = "EntryDate";
        private const string column_LTimeCiMatDate = "LTimeCiMatDate";
        private const string column_InspectMaturityDate = "InspectMaturityDate";
        private const string column_CarNote = "CarNote";
        private const string column_CarNoteGuide = "CarNoteGuide";

        /// <summary>備考ガイド区分コード１</summary>
        public const int ctDIVCODE_NoteGuideDivCd = 201;

        //カラー定義
        private static readonly Color DISABLE_COLOR = Color.Gainsboro;
        private static readonly Color DISABLE_FONT_COLOR = Color.Black;
        private static readonly Color READONLY_COLOR = Color.WhiteSmoke;
        private static readonly Color ROWSTATUS_COPY_COLOR = Color.Pink;
        private static readonly Color ROWSTATUS_CUT_COLOR = Color.Gray;
        private static readonly Color REDUCTION_FONT_COLOR = Color.Green;
        private static readonly Color READONLY_CELL_COLOR = Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(220)))));

        // 行選択状態
        private const int MODE_SELECTEDSINGLE = 1;
        private const int MODE_SELECTEDMULTI = 2;

        // 画面状態保存用ファイル名
        private const string XML_FILE_INITIAL_DATA = "PMSYA09021U.dat";
        #endregion

        #region ■private変数
        // 企業コード
        private string _enterpriseCode;

        // 画面イメージコントロール部品
        private ControlScreenSkin _controlScreenSkin;
        // イメージリスト
        private ImageList _imageList16 = null;

        // 車輌管理マスタテーブルアクセスクラス
        private CarMngListInputAcs _carMngListInputAcs;
        private CarMngInputAcs _carMngInputAcs;

        // 商品在庫テーブル
        private CarMngInputDataSet.CarInfoDataTable _carInfoDataTable;
        private DataTable _originalCarInfoDataTable;

        private CustomerSearchRet _customerSearchRet;
        private bool _cusotmerGuideSelected;

        // ユーザーガイドマスタアクセスクラス
        private UserGuideAcs _userGuideAcs;
        // 備考ガイドマスタアクセスクラス
        private NoteGuidAcs _noteGuidAcs;

        private CustomerSearchAcs _customerSearchAcs;

        //ボタン定義
        private Infragistics.Win.UltraWinToolbars.ButtonTool _rowCopyButton;
        private Infragistics.Win.UltraWinToolbars.ButtonTool _rowPasteButton;
        private Infragistics.Win.UltraWinToolbars.ButtonTool _rowDeleteButton;

        // 前選択行インデックス(背景色設定用)
        private List<int> _beforeSelectRowIndexList = new List<int>();

        // グリッド設定制御クラス
        private GridStateController _gridStateController;

        // グリッド項目の更新前項目値
        private string _tmpCustomerCode = string.Empty;
        private string _tmpCarMngCode = string.Empty;
        private string _tmpNumberPlate1Code = string.Empty;
        #endregion

        #region ■イベント
        /// <summary>フォーカス設定イベント</summary>
        internal event SettingFocusEventHandler SetFocus;
        /// <summary>編集ボタン押下可否設定イベント</summary>
        internal event SetEditButtonEnableHandler SetEditButton;
        /// <summary>データ入力画面を起動イベント</summary>
        internal event StartInPutHandler StartInPut;

        private bool _canMove = true;
        private bool _chooseFlg = true;
        /// <summary>
        /// ChooseFlg
        /// </summary>
        public bool ChooseFlg
        {
            get { return _chooseFlg; }
            set { _chooseFlg = value; }
        }
        #endregion

        #region ■デリゲート
        /// <summary>
        /// フォーカス設定デリゲート
        /// </summary>
        /// <param name="itemName">項目名称</param>
        internal delegate void SettingFocusEventHandler(string itemName);

        /// <summary>
        /// 編集ボタン押下可否制御イベント
        /// </summary>
        /// <param name="flag">可否制御</param>
        internal delegate void SetEditButtonEnableHandler(bool flag);

        /// <summary>
        /// データ入力画面を起動イベント
        /// </summary>
        /// <param name="key">車両情報共通キー</param>
        internal delegate void StartInPutHandler(object key);
        #endregion


        // --- ADD 2009/10/26 -------------------------------->>>>>
        /// <summary>
        /// 行番号列ソートComparere
        /// </summary>
        private class RowNumberSortComparer : IComparer
        {
            public RowNumberSortComparer()
            {
            }

            public int Compare(object x, object y)
            {
                UltraGridCell xCell = (UltraGridCell)x;
                UltraGridCell yCell = (UltraGridCell)y;

                int xValue = 0;
                int yValue = 0;

                Int32.TryParse(xCell.Value.ToString(), out xValue);
                Int32.TryParse(yCell.Value.ToString(), out yValue);

                if (xValue == 0)
                {
                    if (yValue == 0)
                    {
                        return 0;
                    }
                    else
                    {
                        return 1;
                    }
                }
                else
                {
                    if (yValue == 0)
                    {
                        return -1;
                    }
                    else
                    {
                        return (xValue.CompareTo(yValue));
                    }
                }
            }
        }
        // --- ADD 2009/10/26 --------------------------------<<<<<

        #region ■コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public PMSYA09021UB()
        {
            InitializeComponent();

            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            this._controlScreenSkin = new ControlScreenSkin();
            this._imageList16 = IconResourceManagement.ImageList16;

            this._carMngListInputAcs = CarMngListInputAcs.GetInstance();
            this._carMngInputAcs = CarMngInputAcs.GetInstance();
            this._carInfoDataTable = this._carMngListInputAcs.CarInfoDataTable;
            this._originalCarInfoDataTable = this._carMngListInputAcs.OriginalCarInfoDataTable;

            // 変数初期化
            this._userGuideAcs = new UserGuideAcs();
            this._noteGuidAcs = new NoteGuidAcs();

            this._customerSearchAcs = new CustomerSearchAcs();

            this._gridStateController = new GridStateController();
        }
        #endregion

        #region ■publicメソッド
        #region ■ 初期化処理
        /// <summary>
        /// 初期化(クリア)処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 初期化(クリア)処理を行う</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        internal void Initialize()
        {
            // 画面項目初期化
            InitializeScreen();

            this._carMngListInputAcs.CarInfoDataTable.Clear();
            this._carMngListInputAcs.OriginalCarInfoDataTable.Clear();

            // ボタン操作有効処理
            this.SetButtonEnable();
        }
        #endregion

        #region ■ フォーカス遷移制御
        /// <summary>
        /// グリッドタブ移動制御
        /// </summary>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : グリッドタブ移動制御を行う</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        internal void SetGridTabFocus(ref ChangeFocusEventArgs e)
        {
            // 次フォーカス先カラム名
            string nextFocusColumn;
            int activationColIndex = 0;
            int activationRowIndex = 0;

            if (this.uGrid_Details.ActiveCell == null)
            {
                // アクティブなし または 行アクティブ
                e.NextCtrl = null;
                this.uGrid_Details.Focus();

                int colIndex = 0;
                int rowIndex = 0;

                if (this.uGrid_Details.ActiveRow != null)
                {
                    rowIndex = this.uGrid_Details.ActiveRow.Index;
                }

                // 1行目の最初の入力可能行にフォーカス
                nextFocusColumn = this.GetNextFocusColumnKey(colIndex, rowIndex, false, out activationColIndex, out activationRowIndex);

                if (nextFocusColumn != string.Empty)
                {
                    this.uGrid_Details.Rows[activationRowIndex].Cells[nextFocusColumn].Activate();
                    this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                }
                else
                {
                    this.SetFocus("tNedit_CustomerCode_St");
                }

                return;
            }
            else
            {
                // セルアクティブ
                int rowIndex = this.uGrid_Details.ActiveCell.Row.Index;
                int colIndex = this.uGrid_Details.ActiveCell.Column.Index;

                // グリッド脱出時用のコントロールを保持
                e.NextCtrl = null;
                this.uGrid_Details.PerformAction(UltraGridAction.ExitEditMode);

                this.uGrid_Details.Focus();

                // マスタチェック完了場合、フォーカス移動
                if (this._canMove)
                {
                    nextFocusColumn = string.Empty;

                    // ---- ADD 2009/10/10 ------->>>>>
                    // 次回車検日
                    if (this.uGrid_Details.ActiveCell.Column.Key == column_CarInspectYear
                        || this.uGrid_Details.ActiveCell.Column.Key == column_LTimeCiMatDate
                        || this.uGrid_Details.ActiveCell.Column.Key == column_InspectMaturityDate)
                    {
                        // 前回車検日を入力後、次回車検日が空白の場合は、次回車検日へ前回車検日＋期間で初期表示する
                        string lTimeCiMatDate = this.uGrid_Details.Rows[rowIndex].Cells["LTimeCiMatDate"].Value.ToString();
                        string inspectMaturityDate = this.uGrid_Details.Rows[rowIndex].Cells["InspectMaturityDate"].Value.ToString();
                        int carInspectYear = Convert.ToInt32(this.uGrid_Details.Rows[rowIndex].Cells["CarInspectYear"].Value.ToString());
                        if (!string.Empty.Equals(lTimeCiMatDate) && string.Empty.Equals(inspectMaturityDate)
                            && Convert.ToDateTime(lTimeCiMatDate) != DateTime.MinValue)
                        {
                            this.uGrid_Details.Rows[rowIndex].Cells["InspectMaturityDate"].Value = (object)Convert.ToDateTime(lTimeCiMatDate).AddYears(carInspectYear).ToString();
                        }
                    }

                    // ---- ADD 2009/10/10 -------<<<<<

                    // 得意先コード
                    if (this.uGrid_Details.ActiveCell.Column.Key == column_CustomerCode)
                    {
                        activationRowIndex = rowIndex;

                        // 入力した場合
                        if (this.uGrid_Details.ActiveCell.Value != DBNull.Value
                            && (string)this.uGrid_Details.ActiveCell.Value != string.Empty)
                        {
                            nextFocusColumn = column_CarMngCode;
                        }
                        else
                        {
                            nextFocusColumn = column_CustomerCodeGuide;
                        }

                    }
                    // 陸運事務所番号
                    else if (this.uGrid_Details.ActiveCell.Column.Key == column_NumberPlate1Code)
                    {
                        activationRowIndex = rowIndex;

                        // 入力した場合
                        if (this.uGrid_Details.ActiveCell.Value != DBNull.Value
                            && (string)this.uGrid_Details.ActiveCell.Value != string.Empty)
                        {
                            nextFocusColumn = column_NumberPlate2;
                        }
                        else
                        {
                            nextFocusColumn = column_NumberPlate1CodeGuide;
                        }
                    }
                    // 車輌備考
                    else if (this.uGrid_Details.ActiveCell.Column.Key == column_CarNote)
                    {
                        // 入力した場合
                        if (this.uGrid_Details.ActiveCell.Value != DBNull.Value
                            && (string)this.uGrid_Details.ActiveCell.Value != string.Empty)
                        {
                            colIndex = colIndex + 1;
                            // 次セル取得
                            nextFocusColumn = GetNextFocusColumnKey(colIndex, rowIndex, false, out activationColIndex, out activationRowIndex);
                        }
                        else
                        {
                            activationRowIndex = rowIndex;
                            nextFocusColumn = column_CarNoteGuide;
                        }
                    }
                    else
                    {
                        // 次セル取得
                        nextFocusColumn = GetNextFocusColumnKey(colIndex, rowIndex, false, out activationColIndex, out activationRowIndex);
                    }

                    if (nextFocusColumn != string.Empty)
                    {
                        this.uGrid_Details.Rows[activationRowIndex].Cells[nextFocusColumn].Activate();
                        this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                    }
                    else
                    {
                        this.SetFocus("uCheckEditor_AutoFillToColumn");
                    }
                }
                // フォーカスを移動しない。
                else
                {
                    nextFocusColumn = string.Empty;
                   

                    // 得意先コード
                    if (this.uGrid_Details.ActiveCell.Column.Key == column_CustomerCode)
                    {
                        nextFocusColumn = column_CustomerCode;
                    }
                    // 管理番号
                    else if (this.uGrid_Details.ActiveCell.Column.Key == column_CarMngCode)
                    {
                        nextFocusColumn = column_CarMngCode;
                    }
                    // 陸運事務所番号
                    else if (this.uGrid_Details.ActiveCell.Column.Key == column_NumberPlate1Code)
                    {
                        nextFocusColumn = column_NumberPlate1Code;
                    }
                    if (nextFocusColumn != string.Empty)
                    {
                        this.uGrid_Details.Rows[rowIndex].Cells[nextFocusColumn].Activate();
                        this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                    }
                    else
                    {
                        this.SetFocus("tNedit_CustomerCode_St");
                    }

                    
                    this._canMove = true;
                }
            }
        }

        /// <summary>
        /// グリッドシフトタブ制御
        /// </summary>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : グリッドシフトタブ制御を行う</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        internal void SetGridShiftTabFocus(ref ChangeFocusEventArgs e)
        {
            // 次フォーカス先カラム名
            string nextFocusColumn;
            int activationColIndex;
            int activationRowIndex;

            if (this.uGrid_Details.ActiveCell == null)
            {
                // アクティブなし または 行アクティブ
                e.NextCtrl = null;
                this.uGrid_Details.Focus();

                int colIndex = this.uGrid_Details.DisplayLayout.Bands[0].Columns.Count - 1;
                int rowIndex = this.uGrid_Details.Rows.Count - 1;

                if (this.uGrid_Details.ActiveRow != null)
                {
                    colIndex = 0;
                    rowIndex = uGrid_Details.ActiveRow.Index;
                }

                // 1行目の最後の入力可能行にフォーカス
                nextFocusColumn = this.GetNextFocusColumnKey(colIndex, rowIndex, true, out activationColIndex, out activationRowIndex);

                if (nextFocusColumn != string.Empty)
                {
                    this.uGrid_Details.Rows[activationRowIndex].Cells[nextFocusColumn].Activate();
                    this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                }
                else
                {
                    this.SetFocus("Before_Grid");
                }

                return;
            }
            else
            {
                // セルアクティブ
                int rowIndex = this.uGrid_Details.ActiveCell.Row.Index;
                int columnIndex = this.uGrid_Details.ActiveCell.Column.Index;

                // グリッド脱出時用のコントロールを保持
                e.NextCtrl = null;
                this.uGrid_Details.PerformAction(UltraGridAction.ExitEditMode);

                this.uGrid_Details.Focus();

                // 次セル取得
                nextFocusColumn = GetNextFocusColumnKey(columnIndex, rowIndex, true, out activationColIndex, out activationRowIndex);

                if (nextFocusColumn != string.Empty)
                {
                    this.uGrid_Details.Rows[activationRowIndex].Cells[nextFocusColumn].Activate();
                    this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                }
                else
                {
                    this.SetFocus("Before_Grid");
                }
            }
        }

        /// <summary>
        /// 次の入力可能列のKeyを取得する
        /// </summary>
        /// <param name="colIndex">チェック開始列index、Activation可能列を返す</param>
        /// <param name="rowIndex">チェック開始行index、Activation可能行を返す</param>
        /// <param name="isShift">true:シフトあり false:シフトなし</param>
        /// <param name="ActivationColIndex">Activation可能列Index</param>
        /// <param name="ActivationRowIndex">Activation可能行Index</param>
        /// <returns>Activation可能列のキー。ない場合はstring.Empty</returns>
        /// <remarks>
        /// <br>Note       : 次の入力可能列のKeyを取得を行う</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        internal string GetNextFocusColumnKey(int colIndex, int rowIndex, bool isShift, out int ActivationColIndex, out int ActivationRowIndex)
        {
            ActivationColIndex = 0;
            ActivationRowIndex = 0;

            // 指定列の次の入力可能列を検索
            if (!isShift)
            {
                // シフト無
                for (int j = rowIndex; j < this.uGrid_Details.Rows.Count; j++)
                {
                    if (!this.uGrid_Details.Rows[j].IsFilteredOut)
                    {
                        if (j == rowIndex)
                        {
                            // 指定行は指定カラムから先をチェック
                            for (int i = colIndex + 1; i < this.uGrid_Details.DisplayLayout.Bands[0].Columns.Count; i++)
                            {
                                if (this.uGrid_Details.DisplayLayout.Bands[0].Columns[i].CellActivation == Activation.AllowEdit
                                    && this.uGrid_Details.Rows[j].Cells[i].Activation == Activation.AllowEdit
                                    && this.uGrid_Details.DisplayLayout.Bands[0].Columns[i].Hidden == false)
                                {
                                    // 入力可能行のColumnKeyを取得
                                    ActivationColIndex = i;
                                    ActivationRowIndex = j;
                                    return this.uGrid_Details.DisplayLayout.Bands[0].Columns[i].Key;
                                }
                            }
                        }
                        else
                        {
                            // 次行以降はカラムを順にチェック
                            for (int i = 0; i < this.uGrid_Details.DisplayLayout.Bands[0].Columns.Count; i++)
                            {
                                if (this.uGrid_Details.DisplayLayout.Bands[0].Columns[i].CellActivation == Activation.AllowEdit
                                    && this.uGrid_Details.Rows[j].Cells[i].Activation == Activation.AllowEdit
                                    && this.uGrid_Details.DisplayLayout.Bands[0].Columns[i].Hidden == false)
                                {
                                    // 入力可能行のColumnKeyを取得
                                    ActivationColIndex = i;
                                    ActivationRowIndex = j;
                                    return this.uGrid_Details.DisplayLayout.Bands[0].Columns[i].Key;
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                // シフトあり
                for (int j = rowIndex; j >= 0; j--)
                {
                    if (!this.uGrid_Details.Rows[j].IsFilteredOut)
                    {
                        if (j == rowIndex)
                        {
                            for (int i = colIndex - 1; i >= 0; i--)
                            {
                                if (this.uGrid_Details.DisplayLayout.Bands[0].Columns[i].CellActivation == Activation.AllowEdit
                                    && this.uGrid_Details.Rows[j].Cells[i].Activation == Activation.AllowEdit
                                    && this.uGrid_Details.DisplayLayout.Bands[0].Columns[i].Hidden == false)
                                {
                                    // 入力可能行のColumnKeyを取得
                                    ActivationColIndex = i;
                                    ActivationRowIndex = j;
                                    return this.uGrid_Details.DisplayLayout.Bands[0].Columns[i].Key;
                                }
                            }
                        }
                        else
                        {
                            for (int i = this.uGrid_Details.DisplayLayout.Bands[0].Columns.Count - 1; i >= 0; i--)
                            {

                                if (this.uGrid_Details.DisplayLayout.Bands[0].Columns[i].CellActivation == Activation.AllowEdit
                                    && this.uGrid_Details.Rows[j].Cells[i].Activation == Activation.AllowEdit
                                    && this.uGrid_Details.DisplayLayout.Bands[0].Columns[i].Hidden == false)
                                {
                                    // 入力可能行のColumnKeyを取得
                                    ActivationColIndex = i;
                                    ActivationRowIndex = j;
                                    return this.uGrid_Details.DisplayLayout.Bands[0].Columns[i].Key;
                                }
                            }
                        }
                    }
                }
            }

            return string.Empty;
        }
        #endregion

        #region ■ その他処理
        /// <summary>
        /// 列サイズの自動調整チェックボックスの反映
        /// </summary>
        /// <remarks>
        /// <br>Note        : 列サイズの自動調整チェックボックスのチェックが変更された時に発生します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009.09.07</br>
        /// </remarks>
        internal void AutoFillToColumnSetting(bool isChecked)
        {
            if (isChecked)
            {
                this.uGrid_Details.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns;
            }
            else
            {
                this.uGrid_Details.DisplayLayout.AutoFitStyle = AutoFitStyle.None;

                // 画面ロード時の列幅に戻します
                this.SetGridInitialLayout();
            }
        }

        /// <summary>
        /// 文字サイズの反映
        /// </summary>
        /// <remarks>
        /// <br>Note        : 文字サイズの値が変更された時に発生します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009.09.07</br>
        /// </remarks>
        internal void GridFontSizeSetting(int size)
        {
            this.uGrid_Details.DisplayLayout.Appearance.FontData.SizeInPoints = size;
        }

        /// <summary>
        /// 削除済みデータの表示チェックボックスの反映
        /// </summary>
        /// <remarks>
        /// <br>Note        : 削除済みデータ表示ボタンクの値が変更された時に発生します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009.09.07</br>
        /// </remarks>
        internal void DeleteIndicationSetting(bool isChecked)
        {
            if (isChecked)
            {
                this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._carInfoDataTable.DeleteDateColumn.ColumnName].Hidden = false;
            }
            else
            {
                this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._carInfoDataTable.DeleteDateColumn.ColumnName].Hidden = true;
            }

            this.SetGridFiltering(isChecked);
        }

        /// <summary>
        /// フィルタ設定
        /// </summary>
        /// <remarks>
        /// <br>Note       : フィルタ設定処理を行う</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        private void SetGridFiltering(bool deleteDispChecked)
        {
            Infragistics.Win.UltraWinGrid.ColumnFiltersCollection columnFilters = this.uGrid_Details.DisplayLayout.Bands[0].ColumnFilters;

            columnFilters[this._carInfoDataTable.DeleteDateColumn.ColumnName].FilterConditions.Clear();

            if (!deleteDispChecked)
            {
                // 空白とNull以外をフィルタに設定する
                columnFilters[this._carInfoDataTable.DeleteDateColumn.ColumnName].FilterConditions.Add(Infragistics.Win.UltraWinGrid.FilterComparisionOperator.Equals, "");
                columnFilters[this._carInfoDataTable.DeleteDateColumn.ColumnName].FilterConditions.Add(Infragistics.Win.UltraWinGrid.FilterComparisionOperator.Equals, null);
                columnFilters[this._carInfoDataTable.DeleteDateColumn.ColumnName].LogicalOperator = Infragistics.Win.UltraWinGrid.FilterLogicalOperator.Or;
            }
        }
        #endregion
        #endregion

        #region ■privateメソッド
        #region ■ ガイド処理
        /// <summary>
        /// 得意先ガイド表示処理
        /// </summary>
        /// <param name="customerSearchRet">得意先マスタ</param>
        /// <param name="searchMode">検索</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note        : 得意先ガイドを表示します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009.09.07</br>
        /// </remarks>
        private int ShowCustomerGuide(out CustomerSearchRet customerSearchRet, int searchMode)
        {
            customerSearchRet = new CustomerSearchRet();

            this._cusotmerGuideSelected = false;

            PMKHN04005UA customerSearchForm = new PMKHN04005UA(searchMode, PMKHN04005UA.EXECUTEMODE_GUIDE_ONLY);

            customerSearchForm.CustomerSelect += new PMKHN04005UA.CustomerSelectEventHandler(CustomerSearchForm_CustomerSelect);
            customerSearchForm.ShowDialog(this);

            if (this._cusotmerGuideSelected == true)
            {
                customerSearchRet = this._customerSearchRet;
                return 0;
            }
            else
            {
                return -1;
            }
        }

        /// <summary>
        /// 得意先選択時発生イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="customerSearchRet">得意先車両検索戻り値クラス</param>
        /// <remarks>
        /// <br>Note        : 得意先ガイドで得意先を選択した時に発生します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009.09.07</br>
        /// </remarks>
        private void CustomerSearchForm_CustomerSelect(object sender, CustomerSearchRet customerSearchRet)
        {
            if (customerSearchRet == null)
            {
                this._cusotmerGuideSelected = false;
                return;
            }

            // 選択した得意先マスタをバッファに保持
            this._customerSearchRet = customerSearchRet.Clone();

            this._cusotmerGuideSelected = true;
        }

        /// <summary>
        /// ユーザーガイド表示処理
        /// </summary>
        /// <remarks>
        /// <br>Note        : ユーザーガイドを表示します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009.09.07</br>
        /// </remarks>
        private int ShowUserGuide(out UserGdBd userGdBd, int userGuideDivCd)
        {
            int status;
            UserGdHd userGdHd = new UserGdHd();

            userGdBd = new UserGdBd();

            status = this._userGuideAcs.ExecuteGuid(this._enterpriseCode, out userGdHd, out userGdBd, userGuideDivCd);

            return status;
        }

        /// <summary>
        /// 備考ガイド表示処理
        /// </summary>
        /// <remarks>
        /// <br>Note        : 備考ガイドを表示します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009.09.07</br>
        /// </remarks>
        private int ShowNoteGuide(out NoteGuidBd noteGuidBd, int noteGuideDivCd)
        {
            int status;

            noteGuidBd = new NoteGuidBd();

            status = this._noteGuidAcs.ExecuteGuide(out noteGuidBd, this._enterpriseCode, noteGuideDivCd);

            return status;
        }
        #endregion

        # region ■ 次入力可能セル移動処理
        /// <summary>
        /// 次入力可能セル移動処理
        /// </summary>
        /// <param name="activeCellCheck">true:ActiveCellが入力可能の場合はNextに移動させない false:ActiveCellに関係なくNextに移動させる</param>
        /// <returns>true:セル移動完了 false:セル移動失敗</returns>
        /// <remarks>
        /// <br>Note       : 次入力可能セル移動処理を行う</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        private bool MoveNextAllowEditCell(bool activeCellCheck)
        {
            bool moved = false;
            bool performActionResult = false;

            try
            {
                // 更新開始（描画ストップ）
                this.uGrid_Details.BeginUpdate();

                if ((activeCellCheck) && (this.uGrid_Details.ActiveCell != null))
                {
                    if ((!this.uGrid_Details.ActiveCell.Column.Hidden) &&
                        (this.uGrid_Details.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) &&
                        (this.uGrid_Details.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
                    {
                        moved = true;
                    }
                }

                while (!moved)
                {
                    performActionResult = this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextCell);

                    if (performActionResult)
                    {
                        if ((this.uGrid_Details.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) &&
                            (this.uGrid_Details.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
                        {
                            moved = true;
                        }
                        else
                        {
                            moved = false;
                        }
                    }
                    else
                    {
                        break;
                    }
                }

                if (moved)
                {
                    this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                }
            }
            finally
            {
                // 更新終了（描画再開）
                this.uGrid_Details.EndUpdate();
            }

            return performActionResult;
        }
        # endregion

        # region ■ 明細グリッド設定処理
        /// <summary>
        /// 明細グリッド設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note		: 明細グリッド設定処理を行います。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009/09/07</br>
        /// </remarks>
        internal void SettingGrid()
        {
            try
            {
                // 描画を一時停止
                this.uGrid_Details.BeginUpdate();

                // 描画が必要な明細件数を取得する。
                int cnt = this._carInfoDataTable.Count;

                // 各行ごとの設定
                for (int i = 0; i < cnt; i++)
                {
                    // Color設定
                    this.SetGridColorRow(this.uGrid_Details.Rows[i]);
                    // セルActivation設定
                    this.SetCellActivation(this.uGrid_Details.Rows[i]);
                    
                }
            }
            finally
            {
                // 描画を開始
                this.uGrid_Details.EndUpdate();
            }
        }
        # endregion

        # region ■ 明細グリッド・行単位でのセル設定
        /// <summary>
        /// 明細グリッド・行単位でのセルColor設定
        /// </summary>
        /// <param name="ultraRow">対象行</param>
        /// <remarks>
        /// <br>Note		: 明細グリッド・行単位でのセル設定を行います。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009/09/07</br>
        /// </remarks>
        private void SetGridColorRow(UltraGridRow ultraRow)
        {
            Infragistics.Win.UltraWinGrid.UltraGridBand editBand = this.uGrid_Details.DisplayLayout.Bands[0];
            if (editBand == null) return;

            if (ultraRow.Selected)
            {
                // 選択行の場合
                foreach (UltraGridCell cell in ultraRow.Cells)
                {
                    if (cell.Column.Key != this._carInfoDataTable.RowNoColumn.ColumnName)
                    {
                        // 無効行もActiveセル色で上書き
                        cell.Appearance.BackColor = Color.FromArgb(251, 230, 148);
                        cell.Appearance.BackColor2 = Color.FromArgb(238, 149, 21);
                        cell.Appearance.BackColorDisabled = Color.FromArgb(251, 230, 148);
                        cell.Appearance.BackColorDisabled2 = Color.FromArgb(238, 149, 21);
                        cell.Appearance.BackGradientStyle = GradientStyle.Vertical;
                    }
                }
            }
            else
            {
                // 通常色設定
                if (ultraRow.Index % 2 == 0)
                {
                    foreach (UltraGridCell ultraCell in ultraRow.Cells)
                    {
                        if (ultraCell.Column.Key != this._carInfoDataTable.RowNoColumn.ColumnName)
                        {
                            ultraCell.Appearance.BackColor = Color.White;
                            ultraCell.Appearance.BackColor2 = Color.White;
                            ultraCell.Appearance.BackColorDisabled = Color.White;
                            ultraCell.Appearance.BackColorDisabled2 = Color.White;
                        }
                    }
                }
                else
                {
                    foreach (UltraGridCell ultraCell in ultraRow.Cells)
                    {
                        if (ultraCell.Column.Key != this._carInfoDataTable.RowNoColumn.ColumnName)
                        {
                            ultraCell.Appearance.BackColor = Color.Lavender;
                            ultraCell.Appearance.BackColor2 = Color.Lavender;
                            ultraCell.Appearance.BackColorDisabled = Color.Lavender;
                            ultraCell.Appearance.BackColorDisabled2 = Color.Lavender;
                        }
                    }
                }

                int status = (int)ultraRow.Cells[this._carInfoDataTable.RowStatusColumn.ColumnName].Value;
                int deleteFlag = (int)ultraRow.Cells[this._carInfoDataTable.DeleteFlagColumn.ColumnName].Value;

                // COPY行
                if (status == CarMngListInputAcs.ROWSTATUS_COPY)
                {
                    foreach (UltraGridCell ultraCell in ultraRow.Cells)
                    {
                        if (ultraCell.Column.Key != this._carInfoDataTable.RowNoColumn.ColumnName)
                        {
                            ultraCell.Appearance.BackColor = Color.Pink;
                            ultraCell.Appearance.BackColor2 = Color.Pink;
                            ultraCell.Appearance.BackColorDisabled = Color.Pink;
                            ultraCell.Appearance.BackColorDisabled2 = Color.Pink;
                        }
                    }
                }
                // 論理削除行
                else if (deleteFlag == CarMngListInputAcs.DELETE_FLAG1)
                {
                    foreach (UltraGridCell ultraCell in ultraRow.Cells)
                    {
                        if (ultraCell.Column.Key != this._carInfoDataTable.RowNoColumn.ColumnName)
                        {
                            ultraCell.Appearance.BackColor = Color.Red;
                            ultraCell.Appearance.BackColor2 = Color.Red;
                            ultraCell.Appearance.BackColorDisabled = Color.Red;
                            ultraCell.Appearance.BackColorDisabled2 = Color.Red;
                        }
                    }
                }
                else
                {
                    // 追加行は対象外(通常色どおり)
                    if (ultraRow.Cells[this._carInfoDataTable.RowNoColumn.ColumnName].Value.ToString() == CarMngListInputAcs.ROWNO_NEW)
                    {
                        return;
                    }

                    // 更新セル設定
                    if (this._carMngListInputAcs.OriginalCarInfoDataTable.Rows.Count == 0)
                    {
                        return;
                    }

                    DataRow[] originalDrs = this._carMngListInputAcs.OriginalCarInfoDataTable
                        .Select(this._carInfoDataTable.CarRelationGuidColumn.ColumnName + " = '"
                        + ultraRow.Cells[this._carInfoDataTable.CarRelationGuidColumn.ColumnName].Value.ToString() + "'");
                    if (originalDrs.Length > 0)
                    {
                        DataRow originalDr = originalDrs[0];
                        for (int j = 0; j < this._carInfoDataTable.Columns.Count; j++)
                        {
                            if (ultraRow.Cells[j].Value.ToString() != originalDr[j].ToString())
                            {
                                ultraRow.Cells[j].Appearance.BackColor = Color.Lime;
                                ultraRow.Cells[j].Appearance.BackColor2 = Color.Lime;
                                ultraRow.Cells[j].Appearance.BackColorDisabled = Color.Lime;
                                ultraRow.Cells[j].Appearance.BackColorDisabled2 = Color.Lime;
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// セルActivation設定
        /// </summary>
        /// <remarks>
        /// <br>Note       : 検索時、セル単位の入力許可設定を行う</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        internal void SetCellActivation(UltraGridRow ultraRow)
        {
            // 論理削除行は編集不可
            if ((int)ultraRow.Cells[this._carInfoDataTable.DeleteFlagColumn.ColumnName].Value == CarMngListInputAcs.DELETE_FLAG1
                || ultraRow.Cells[this._carInfoDataTable.DeleteDateColumn.ColumnName].Value != DBNull.Value)
            {
                foreach (UltraGridCell ultraCell in ultraRow.Cells)
                {
                    //ultraCell.Activation = Activation.NoEdit;
                    ultraCell.Activation = Activation.Disabled;  // ADD 2009/10/10
                }
                ultraRow.Cells[this._carInfoDataTable.CustomerCodeGuideColumn.ColumnName].Activation = Activation.Disabled;
                ultraRow.Cells[this._carInfoDataTable.CarNoteGuideColumn.ColumnName].Activation = Activation.Disabled;
                ultraRow.Cells[this._carInfoDataTable.NumberPlate1CodeGuideColumn.ColumnName].Activation = Activation.Disabled;
                // ---- ADD 2009/10/10 ------>>>>>
                //削除ボタンが押下後、取り消しができない。削除ボタン押下時は、赤色に変更するのではなくグリット上から消すように変更
                string delDt = ultraRow.Cells[this._carInfoDataTable.DeleteDateColumn.ColumnName].Value.ToString();
                if (string.Empty.Equals(delDt))
                {
                    ultraRow.Hidden = true;
                }
                else
                {
                    ultraRow.Hidden = false;
                }
                // ---- ADD 2009/10/10 ------<<<<<
            }
            else
            {
                // 編集可状態に更新
                ultraRow.Cells[this._carInfoDataTable.CarNoteGuideColumn.ColumnName].Activation = Activation.AllowEdit;
                ultraRow.Cells[this._carInfoDataTable.NumberPlate1CodeGuideColumn.ColumnName].Activation = Activation.AllowEdit;

                ultraRow.Cells[this._carInfoDataTable.EngineModelColumn.ColumnName].Activation = Activation.AllowEdit;
                ultraRow.Cells[this._carInfoDataTable.CarAddInfo1Column.ColumnName].Activation = Activation.AllowEdit;
                ultraRow.Cells[this._carInfoDataTable.CarAddInfo2Column.ColumnName].Activation = Activation.AllowEdit;
                ultraRow.Cells[this._carInfoDataTable.NumberPlate1CodeColumn.ColumnName].Activation = Activation.AllowEdit;
                ultraRow.Cells[this._carInfoDataTable.NumberPlate2Column.ColumnName].Activation = Activation.AllowEdit;
                ultraRow.Cells[this._carInfoDataTable.NumberPlate3Column.ColumnName].Activation = Activation.AllowEdit;
                ultraRow.Cells[this._carInfoDataTable.NumberPlate4Column.ColumnName].Activation = Activation.AllowEdit;
                ultraRow.Cells[this._carInfoDataTable.MileageColumn.ColumnName].Activation = Activation.AllowEdit;
                ultraRow.Cells[this._carInfoDataTable.CarInspectYearColumn.ColumnName].Activation = Activation.AllowEdit;
                ultraRow.Cells[this._carInfoDataTable.EntryDateColumn.ColumnName].Activation = Activation.AllowEdit;
                ultraRow.Cells[this._carInfoDataTable.LTimeCiMatDateColumn.ColumnName].Activation = Activation.AllowEdit;
                ultraRow.Cells[this._carInfoDataTable.InspectMaturityDateColumn.ColumnName].Activation = Activation.AllowEdit;
                ultraRow.Cells[this._carInfoDataTable.CarNoteColumn.ColumnName].Activation = Activation.AllowEdit;
            }

            // 新規行,入力を可能とする。
            if ((string)ultraRow.Cells[this._carInfoDataTable.RowNoColumn.ColumnName].Value == CarMngListInputAcs.ROWNO_NEW)
            {
                ultraRow.Cells[this._carInfoDataTable.CustomerCodeColumn.ColumnName].Activation = Activation.AllowEdit;
                ultraRow.Cells[this._carInfoDataTable.CustomerCodeGuideColumn.ColumnName].Activation = Activation.AllowEdit;
                ultraRow.Cells[this._carInfoDataTable.CarMngCodeColumn.ColumnName].Activation = Activation.AllowEdit;
            }
            else
            {
                //ultraRow.Cells[this._carInfoDataTable.CustomerCodeColumn.ColumnName].Activation = Activation.NoEdit;
                ultraRow.Cells[this._carInfoDataTable.CustomerCodeColumn.ColumnName].Activation = Activation.Disabled;  // ADD 2009/10/10
                ultraRow.Cells[this._carInfoDataTable.CustomerCodeGuideColumn.ColumnName].Activation = Activation.Disabled;
                //ultraRow.Cells[this._carInfoDataTable.CarMngCodeColumn.ColumnName].Activation = Activation.NoEdit;
                ultraRow.Cells[this._carInfoDataTable.CarMngCodeColumn.ColumnName].Activation = Activation.Disabled;  // ADD 2009/10/10
            }
        }
        #endregion

        # region ■ 削除処理
        /// <summary>
        /// 削除処理
        /// </summary>
        /// <param name="selectedStockRowNoList"></param>
        /// <remarks>
        /// <br>Note       : 削除処理を行う</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        public void RowDelete(List<Guid> selectedStockRowNoList)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                // 行削除処理
                this._carMngListInputAcs.DeleteCarInfoRow(selectedStockRowNoList);

                // 明細グリッドセル設定処理
                this.SettingGrid();

                // 次入力可能セル移動処理
                this.MoveNextAllowEditCell(true);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
        #endregion

        #region ■ ボタンEnabled変更後イベント
        /// <summary>
        /// 引用複写ボタンEnabled変更後発生イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note        : 引用複写ボタンEnabled変更時に発生します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009.09.07</br>
        /// </remarks>
        private void uButton_RowCopy_EnabledChanged(object sender, EventArgs e)
        {
            this._rowCopyButton.SharedProps.Enabled = ((Infragistics.Win.Misc.UltraButton)sender).Enabled;
        }

        /// <summary>
        /// 引用貼付ボタンEnabled変更後発生イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note        : 引用貼付ボタンEnabled変更時に発生します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009.09.07</br>
        /// </remarks>
        private void uButton_RowCopyAdd_EnabledChanged(object sender, EventArgs e)
        {
            this._rowPasteButton.SharedProps.Enabled = ((Infragistics.Win.Misc.UltraButton)sender).Enabled;
        }

        /// <summary>
        /// 削除ボタンEnabled変更後発生イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note        : 削除ボタンEnabled変更時に発生します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009.09.07</br>
        /// </remarks>
        private void uButton_RowDelete_EnabledChanged(object sender, EventArgs e)
        {
            this._rowDeleteButton.SharedProps.Enabled = ((Infragistics.Win.Misc.UltraButton)sender).Enabled;
        }

        /// <summary>
        /// CellDataError イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : 不正な値が入力された状態でセル値を更新しようとした時に発生します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009.09.07</br>
        /// </remarks>
        private void uGrid_Details_CellDataError(object sender, CellDataErrorEventArgs e)
        {
            e.RaiseErrorEvent = false;
            e.StayInEditMode = false;

            if (this.uGrid_Details.ActiveCell != null)
            {
                // 数値項目の場合
                if ((this.uGrid_Details.ActiveCell.Column.DataType == typeof(Int32)) ||
                    (this.uGrid_Details.ActiveCell.Column.DataType == typeof(Int64)) ||
                    (this.uGrid_Details.ActiveCell.Column.DataType == typeof(double)))
                {
                    Infragistics.Win.EmbeddableEditorBase editorBase = this.uGrid_Details.ActiveCell.EditorResolved;

                    // 未入力は0にする
                    if (editorBase.CurrentEditText.Trim() == "")
                    {
                        editorBase.Value = 0;				// 0をセット
                        this.uGrid_Details.ActiveCell.Value = 0;
                    }
                    // 数値項目に「-」or「.」だけしか入ってなかったら駄目です
                    else if ((editorBase.CurrentEditText.Trim() == "-") ||
                        (editorBase.CurrentEditText.Trim() == ".") ||
                        (editorBase.CurrentEditText.Trim() == "-."))
                    {
                        editorBase.Value = 0;				// 0をセット
                        this.uGrid_Details.ActiveCell.Value = 0;
                    }
                    // 通常入力
                    else
                    {
                        try
                        {
                            editorBase.Value = Convert.ChangeType(editorBase.CurrentEditText.Trim(), this.uGrid_Details.ActiveCell.Column.DataType);
                            this.uGrid_Details.ActiveCell.Value = editorBase.Value;
                        }
                        catch
                        {
                            editorBase.Value = 0;
                            this.uGrid_Details.ActiveCell.Value = 0;
                        }
                    }
                    e.RaiseErrorEvent = false;			// エラーイベントは発生させない
                    e.RestoreOriginalValue = false;		// セルの値を元に戻さない
                    e.StayInEditMode = false;			// 編集モードは抜ける
                }
            }
        }
        #endregion

        #region ■ その他処理
        /// <summary>
        /// 数値入力チェック処理
        /// </summary>
        /// <param name="keta">桁数(マイナス符号を含まず)</param>
        /// <param name="priod">小数点以下桁数</param>
        /// <param name="prevVal">現在の文字列</param>
        /// <param name="key">入力されたキー値</param>
        /// <param name="selstart">カーソル位置</param>
        /// <param name="sellength">選択文字長</param>
        /// <param name="minusFlg">マイナス入力可？</param>
        /// <returns>true=入力可,false=入力不可</returns>
        /// <remarks>
        /// <br>Note        : 数値の入力チェックを行います。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009/09/07</br>
        /// </remarks>
        private bool KeyPressNumCheck(int keta, int priod, string prevVal, char key, int selstart, int sellength, Boolean minusFlg)
        {
            // 制御キーが押された？
            if (Char.IsControl(key))
            {
                return true;
            }
            // 数値以外は、ＮＧ
            if (!Char.IsDigit(key))
            {
                // 小数点または、マイナス以外
                if ((key != '.') && (key != '-'))
                {
                    return false;
                }
            }

            // キーが押されたと仮定した場合の文字列を生成する。
            string strResult = "";
            if (sellength > 0)
            {
                strResult = prevVal.Substring(0, selstart) + prevVal.Substring(selstart + sellength, prevVal.Length - (selstart + sellength));
            }
            else
            {
                strResult = prevVal;
            }

            // マイナスのチェック
            if (key == '-')
            {
                if ((minusFlg == false) || (selstart > 0) || (strResult.IndexOf('-') != -1))
                {
                    return false;
                }
            }

            // 小数点のチェック
            if (key == '.')
            {
                if ((priod <= 0) || (strResult.IndexOf('.') != -1))
                {
                    return false;
                }
            }
            // キーが押された結果の文字列を生成する。
            strResult = prevVal.Substring(0, selstart)
                + key
                + prevVal.Substring(selstart + sellength, prevVal.Length - (selstart + sellength));

            // 桁数チェック！
            if (strResult.Length > keta)
            {
                if (strResult[0] == '-')
                {
                    if (strResult.Length > (keta + 1))
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }

            // 小数点以下のチェック
            if (priod > 0)
            {
                // 小数点の位置決定
                int _pointPos = strResult.IndexOf('.');

                // 整数部に入力可能な桁数を決定！
                int _Rketa = (strResult[0] == '-') ? keta - priod : keta - priod - 1;
                // 整数部の桁数をチェック
                if (_pointPos != -1)
                {
                    if (_pointPos > _Rketa)
                    {
                        return false;
                    }
                }
                else
                {
                    if (strResult.Length > _Rketa)
                    {
                        return false;
                    }
                }

                // 小数部の桁数をチェック
                if (_pointPos != -1)
                {
                    // 小数部の桁数を計算
                    int _priketa = strResult.Length - _pointPos - 1;
                    if (priod < _priketa)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        //----- ADD 2016/12/13 呉軍 Redmine#48934 PMNSナンバープレート英文字対応 ----->>>>>
        /// <summary>
        /// 文字列入力チェック処理
        /// </summary>
        /// <param name="keta">桁数(マイナス符号を含まず)</param>
        /// <param name="priod">小数点以下桁数</param>
        /// <param name="prevVal">現在の文字列</param>
        /// <param name="key">入力されたキー値</param>
        /// <param name="selstart">カーソル位置</param>
        /// <param name="sellength">選択文字長</param>
        /// <param name="minusFlg">マイナス入力可？</param>
        /// <returns>true=入力可,false=入力不可</returns>
        /// <remarks>
        /// <br>Note        : 英数字の入力チェックを行います。</br>
        /// <br>Programmer  : 呉軍</br>
        /// <br>Date        : 2016/12/13</br>
        /// </remarks>
        private bool KeyPressChrCheck(int keta, int priod, string prevVal, char key, int selstart, int sellength, Boolean minusFlg)
        {
            // 制御キーが押された？
            if (Char.IsControl(key))
            {
                return true;
            }

            string value = key.ToString();

            Regex r = new Regex(@"^[a-zａ-ｚA-ZＡ-Ｚ0-9０-９]+(\.)?[a-zａ-ｚA-ZＡ-Ｚ0-9０-９]*$");

            if ((!String.IsNullOrEmpty(value)) && !r.IsMatch(value))
            {
                return false;
            }
               
            return true;
        }
        //----- ADD 2016/12/13 呉軍 Redmine#48934 PMNSナンバープレート英文字対応 -----<<<<<

        /// <summary>
        /// 数値入力チェック処理
        /// </summary>
        /// <param name="keta">桁数(マイナス符号を含まず)</param>
        /// <param name="prevVal">現在の文字列</param>
        /// <param name="key">入力されたキー値</param>
        /// <param name="selstart">カーソル位置</param>
        /// <param name="sellength">選択文字長</param>
        /// <returns>true=入力可,false=入力不可</returns>
        /// <remarks>
        /// <br>Note        : なし。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009/09/07</br>
        /// </remarks>
        private bool KeyPressStringCheck(int keta, string prevVal, char key, int selstart, int sellength)
        {
            // 制御キーが押された？
            if (Char.IsControl(key))
            {
                return true;
            }
            // キーが押されたと仮定した場合の文字列を生成する。
            string _strResult = string.Empty;
            if (sellength > 0)
            {
                _strResult = prevVal.Substring(0, selstart) + prevVal.Substring(selstart + sellength, prevVal.Length - (selstart + sellength));
            }
            else
            {
                _strResult = prevVal;
            }

            // キーが押された結果の文字列を生成する。
            _strResult = prevVal.Substring(0, selstart)
                + key
                + prevVal.Substring(selstart + sellength, prevVal.Length - (selstart + sellength));

            // 桁数チェック！
            if (_strResult.Length > keta)
            {
                if (_strResult[0] == '-')
                {
                    if (_strResult.Length > (keta + 1))
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// 選択済み仕入行番号リスト取得処理
        /// </summary>
        /// <returns>選択済み仕入行番号リスト</returns>
        /// <remarks>
        /// <br>Note       : 選択済み仕入行番号リスト取得処理を行う</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009/09/07</br>
        /// <br>UpdateNote : 張莉莉 2009/10/21 </br>
        /// <br>           : MANTIS：0014458 ソート後に削除を行うと、ソート前の車輌が削除される。</br>
        /// </remarks>
        public List<Guid> GetSelectedRowNoList()
        {
            Infragistics.Win.UltraWinGrid.SelectedRowsCollection rows = this.uGrid_Details.Selected.Rows;
            if (rows == null) return null;

            List<Guid> selectedRowNoList = new List<Guid>();

            if (rows != null)
            {
                foreach (Infragistics.Win.UltraWinGrid.UltraGridRow row in rows)
                {
                    // --- UPD 2009/10/21 MANTIS：0014458 ----->>>>> 
                    //selectedRowNoList.Add(this._carInfoDataTable[row.Index].CarRelationGuid);
                    selectedRowNoList.Add((Guid)this.uGrid_Details.Rows[row.Index].Cells[0].Value);
                    // --- UPD 2009/10/21 MANTIS：0014458 -----<<<<<

                }
            }

            return selectedRowNoList;
        }

        /// <summary>
        /// 車輌管理マスタチェック処理
        /// </summary>
        /// <param name="row">行</param>
        /// <remarks>
        /// <br>Note       : 車輌管理マスタチェック処理を行う</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        private void CarManagementCheck(UltraGridRow row)
        {
            this._chooseFlg = true;
            string customer = (string)row.Cells[column_CustomerCode].Value;
            string carMngCode = (string)row.Cells[column_CarMngCode].Value;
            // 得意先コードと管理番号は入力した場合
            if (customer != string.Empty && carMngCode != string.Empty)
            {
                CarMngGuideParamInfo paramInfo = new CarMngGuideParamInfo();

                paramInfo.IsCheckCustomerCode = true;
                paramInfo.CustomerCode = this._carMngListInputAcs.StrObjToInt(customer);
                paramInfo.IsCheckCarMngCode = true;
                paramInfo.CarMngCode = carMngCode;
                paramInfo.IsCheckCarMngDivCd = false;
                paramInfo.EnterpriseCode = this._enterpriseCode;

                int status = this._carMngInputAcs.ExecuteGuidBeforeDataCheck(paramInfo);

                if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    DialogResult dialogResult = TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_QUESTION,
                        this.Name,
                        "入力されたコードの車輌管理マスタ情報が既に登録されています。" + "\r\n" + "\r\n" +
                        "別の車輌として入力を行いますか？",
                        0,
                        MessageBoxButtons.YesNo,
                        MessageBoxDefaultButton.Button1);

                    if (dialogResult == DialogResult.Yes)
                    {
                        this._canMove = true;

                        row.Cells["SaveCanFlag"].Value = 0; // 2009/10/26 ADD
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        this._canMove = false;
                        this._chooseFlg = false;
                        row.Cells["SaveCanFlag"].Value = 1; // 2009/10/26 ADD
                    }
                }
                else
                {
                    this._canMove = true;

                    row.Cells["SaveCanFlag"].Value = 0; // 2009/10/26 ADD
                }
            }
            else
            {
                this._canMove = true;
            }
        }
        #endregion
        #endregion

        #region ■コントロールイベント

        #region ■ 初期イベント
        /// <summary>
        /// Load イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : UserControlがLoadされた時に発生します。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        private void PMSYA09021UB_Load(object sender, EventArgs e)
        {
            this.uGrid_Details.DataSource = this._carInfoDataTable;

            // コントロール初期化
            this.InitializeScreen();
        }

        /// <summary>
        /// 画面初期化
        /// </summary>
        /// <remarks>
        /// <br>Note		: 画面初期化時、グリッド初期データ設定を行います。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009/09/07</br>
        /// </remarks>
        private void InitializeScreen()
        {
            // スキン設定
            this._controlScreenSkin.LoadSkin();
            this._controlScreenSkin.SettingScreenSkin(this);

            // ボタン設定
            this.uButton_RowCopy.ImageList = this._imageList16;
            this.uButton_RowCopyAdd.ImageList = this._imageList16;
            this.uButton_RowDelete.ImageList = this._imageList16;

            this.uButton_RowCopy.Appearance.Image = (int)Size16_Index.ROWCOPY;
            this.uButton_RowCopyAdd.Appearance.Image = (int)Size16_Index.ROWPASTE;
            this.uButton_RowDelete.Appearance.Image = (int)Size16_Index.ROWDELETE;

            // ボタン初期化
            this._rowCopyButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_Main.Tools["ButtonTool_RowCopy"];
            this._rowDeleteButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_Main.Tools["ButtonTool_RowDelete"];
            this._rowPasteButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_Main.Tools["ButtonTool_RowPaste"];

            this.tToolbarsManager_Main.ImageListSmall = this._imageList16;

            this._rowCopyButton.SharedProps.AppearancesSmall.Appearance.Image = (int)Size16_Index.ROWCOPY;
            this._rowDeleteButton.SharedProps.AppearancesSmall.Appearance.Image = (int)Size16_Index.ROWDELETE;
            this._rowPasteButton.SharedProps.AppearancesSmall.Appearance.Image = (int)Size16_Index.ROWPASTE;
        }

        /// <summary>
        /// グリッド初期レイアウト設定イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note		: 画面初期化時、グリッド初期レイアウト設定を行います。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009/09/07</br>
        /// </remarks>
        private void uGrid_Details_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            // グリッド列初期設定処理
            this.SetGridInitialLayout();

            // グリッド列表示非表示設定処理
            this.SetGridColVisible();

            // ボタン操作有効処理
            this.SetButtonEnable();
        }

        /// <summary>
        /// グリッド列初期設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note		: 画面初期化の時、グリッド列初期設定を行います。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009/09/07</br>
        /// <br>Update Note : SPK車台番号文字列対応に伴うハンドル位置チェック処理の追加</br>
        /// <br>Programmer  : FSI高橋 文彰</br>
        /// <br>Date        : 2013/03/22</br>
        /// <br>UpdateNote  : 2016/12/13 呉軍</br>
        /// <br>管理番号    : 11270098-00</br>
        /// <br>            : Redmine#48934 PMNSナンバープレート英文字対応</br>
        /// </remarks>
        private void SetGridInitialLayout()
        {
            Infragistics.Win.UltraWinGrid.UltraGridBand editBand = this.uGrid_Details.DisplayLayout.Bands[0];
            if (editBand == null) return;

            // ヘッダクリックアクションの設定(ソート処理)
            editBand.Layout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            // 行フィルター設定
            editBand.Layout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
            // 複数行選択可
            editBand.Layout.Override.SelectTypeRow = SelectType.ExtendedAutoDrag;

            editBand.ColHeadersVisible = true;

            CarMngInputDataSet.CarInfoDataTable table = this._carInfoDataTable;
            ColumnsCollection columns = editBand.Columns;


            // 行番号列のみセル表示色変更
            columns[table.RowNoColumn.ColumnName].CellAppearance.BackColorDisabled = Color.FromArgb(89, 135, 214);
            columns[table.RowNoColumn.ColumnName].CellAppearance.BackColorDisabled2 = Color.FromArgb(7, 59, 150);
            columns[table.RowNoColumn.ColumnName].CellAppearance.BackGradientStyle = GradientStyle.Vertical;
            columns[table.RowNoColumn.ColumnName].CellAppearance.ForeColor = Color.White;
            columns[table.RowNoColumn.ColumnName].CellAppearance.ForeColorDisabled = Color.White;

            // 行番号列のソート順指定
            columns[table.RowNoColumn.ColumnName].SortComparer = new RowNumberSortComparer(); // ADD 2009/10/26


            //--------------------------------------
            // 固定ヘッダー
            //--------------------------------------
            // 「№」「削除日」「得意先コード」「管理番号」「車種」「型式」
            columns[table.RowNoColumn.ColumnName].Header.Fixed = true;
            editBand.Columns[table.RowNoColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
            columns[table.DeleteDateColumn.ColumnName].Header.Fixed = true;
            columns[table.CustomerCodeColumn.ColumnName].Header.Fixed = true;
            columns[table.CustomerCodeGuideColumn.ColumnName].Header.Fixed = true;
            columns[table.CarMngCodeColumn.ColumnName].Header.Fixed = true;
            columns[table.CarMngCodeGuideColumn.ColumnName].Header.Fixed = true;
            columns[table.ModelFullNameColumn.ColumnName].Header.Fixed = true;
            //columns[table.FullModelColumn.ColumnName].Header.Fixed = true;   // DEL 2009/10/10

            //--------------------------------------
            // 入力不可
            //--------------------------------------
            columns[table.RowNoColumn.ColumnName].CellActivation = Activation.Disabled;
            // ---- UPD 2009/10/10 ---->>>>>
            //columns[table.DeleteDateColumn.ColumnName].CellActivation = Activation.NoEdit;
            //columns[table.ModelFullNameColumn.ColumnName].CellActivation = Activation.NoEdit;
            //columns[table.FullModelColumn.ColumnName].CellActivation = Activation.NoEdit;
            //columns[table.ModelDesignationNoColumn.ColumnName].CellActivation = Activation.NoEdit;
            //columns[table.CategoryNoColumn.ColumnName].CellActivation = Activation.NoEdit;
            //columns[table.EngineModelNmColumn.ColumnName].CellActivation = Activation.NoEdit;
            //columns[table.FirstEntryDateColumn.ColumnName].CellActivation = Activation.NoEdit;
            //columns[table.FrameNoColumn.ColumnName].CellActivation = Activation.NoEdit;
            //columns[table.ColorCodeColumn.ColumnName].CellActivation = Activation.NoEdit;
            //columns[table.TrimCodeColumn.ColumnName].CellActivation = Activation.NoEdit;
            //columns[table.NumberPlate1NameColumn.ColumnName].CellActivation = Activation.NoEdit;

            columns[table.DeleteDateColumn.ColumnName].CellActivation = Activation.Disabled;
            columns[table.ModelFullNameColumn.ColumnName].CellActivation = Activation.Disabled;
            columns[table.FullModelColumn.ColumnName].CellActivation = Activation.Disabled;
            columns[table.ModelDesignationNoColumn.ColumnName].CellActivation = Activation.Disabled;
            columns[table.CategoryNoColumn.ColumnName].CellActivation = Activation.Disabled;
            columns[table.EngineModelNmColumn.ColumnName].CellActivation = Activation.Disabled;
            columns[table.FirstEntryDateColumn.ColumnName].CellActivation = Activation.Disabled;
            columns[table.FrameNoColumn.ColumnName].CellActivation = Activation.Disabled;
            columns[table.ColorCodeColumn.ColumnName].CellActivation = Activation.Disabled;
            columns[table.TrimCodeColumn.ColumnName].CellActivation = Activation.Disabled;
            columns[table.NumberPlate1NameColumn.ColumnName].CellActivation = Activation.Disabled;
            // ---- UPD 2009/10/10 ----<<<<<

            //--------------------------------------
            // キャプション
            //--------------------------------------
            columns[table.RowNoColumn.ColumnName].Header.Caption = "No.";
            columns[table.DeleteDateColumn.ColumnName].Header.Caption = "削除日";
            columns[table.CustomerCodeColumn.ColumnName].Header.Caption = "得意先コード";
            columns[table.CustomerCodeGuideColumn.ColumnName].Header.Caption = "";
            columns[table.CarMngCodeColumn.ColumnName].Header.Caption = "管理番号";
            columns[table.CarMngCodeGuideColumn.ColumnName].Header.Caption = "";
            columns[table.ModelFullNameColumn.ColumnName].Header.Caption = "車種";
            columns[table.FullModelColumn.ColumnName].Header.Caption = "型式";
            columns[table.ModelDesignationNoColumn.ColumnName].Header.Caption = "型式指定番号";
            columns[table.CategoryNoColumn.ColumnName].Header.Caption = "類別番号";
            columns[table.EngineModelNmColumn.ColumnName].Header.Caption = "エンジン型式";
            columns[table.FirstEntryDateColumn.ColumnName].Header.Caption = "年式";
            columns[table.FrameNoColumn.ColumnName].Header.Caption = "車台番号";
            columns[table.ColorCodeColumn.ColumnName].Header.Caption = "カラー";
            columns[table.TrimCodeColumn.ColumnName].Header.Caption = "トリム";
            columns[table.EngineModelColumn.ColumnName].Header.Caption = "原動機型式";
            columns[table.CarAddInfo1Column.ColumnName].Header.Caption = "追加情報１";
            columns[table.CarAddInfo2Column.ColumnName].Header.Caption = "追加情報２";
            columns[table.NumberPlate1CodeColumn.ColumnName].Header.Caption = "陸運事務所番号";
            columns[table.NumberPlate1CodeGuideColumn.ColumnName].Header.Caption = "";
            columns[table.NumberPlate1NameColumn.ColumnName].Header.Caption = "陸運事務局名称";
            columns[table.NumberPlate2Column.ColumnName].Header.Caption = "登録番号（種別）";
            columns[table.NumberPlate3Column.ColumnName].Header.Caption = "登録番号（カナ）";
            columns[table.NumberPlate4Column.ColumnName].Header.Caption = "登録番号（プレート番号）";
            columns[table.MileageColumn.ColumnName].Header.Caption = "走行距離";
            columns[table.CarInspectYearColumn.ColumnName].Header.Caption = "車検期間";
            columns[table.EntryDateColumn.ColumnName].Header.Caption = "登録年月日";
            columns[table.LTimeCiMatDateColumn.ColumnName].Header.Caption = "前回車検日";
            columns[table.InspectMaturityDateColumn.ColumnName].Header.Caption = "次回車検日";
            columns[table.CarNoteColumn.ColumnName].Header.Caption = "車輌備考";
            columns[table.CarNoteGuideColumn.ColumnName].Header.Caption = "";

            //--------------------------------------
            // 列幅
            //--------------------------------------
            // --- UPD 佐々木亘 2021/11/02 ------>>>>> 
            //columns[table.RowNoColumn.ColumnName].Width = 45;
            columns[table.RowNoColumn.ColumnName].Width = 50;
            // --- UPD 佐々木亘 2021/11/02 ------<<<<<
            columns[table.DeleteDateColumn.ColumnName].Width = 90;
            // ---- UPD 2009/10/10 ---->>>>>
            //columns[table.CustomerCodeColumn.ColumnName].Width = 120;
            columns[table.CustomerCodeColumn.ColumnName].Width = 75;
            columns[table.CustomerCodeGuideColumn.ColumnName].Width = 24;
            //columns[table.CarMngCodeColumn.ColumnName].Width = 170;
            columns[table.CarMngCodeColumn.ColumnName].Width = 155;
            columns[table.CarMngCodeGuideColumn.ColumnName].Width = 24;
            //columns[table.ModelFullNameColumn.ColumnName].Width = 150;
            columns[table.ModelFullNameColumn.ColumnName].Width = 140;
            // ---- UPD 2009/10/10 ----<<<<<
            columns[table.FullModelColumn.ColumnName].Width = 130;
            columns[table.ModelDesignationNoColumn.ColumnName].Width = 130;
            columns[table.CategoryNoColumn.ColumnName].Width = 90;
            columns[table.EngineModelNmColumn.ColumnName].Width = 120;
            // --- UPD 2013/05/14 Y.Wakita ---------->>>>>
            //columns[table.FirstEntryDateColumn.ColumnName].Width = 90;
            columns[table.FirstEntryDateColumn.ColumnName].Width = 105;
            // --- UPD 2013/05/14 Y.Wakita ----------<<<<<
            // --- UPD 2013/03/22 ---------->>>>>
            // VINコード17桁表示出来るように列幅を修正
            //columns[table.FrameNoColumn.ColumnName].Width = 100;
            columns[table.FrameNoColumn.ColumnName].Width = 160;
            // --- UPD 2013/03/22 ----------<<<<<
            columns[table.ColorCodeColumn.ColumnName].Width = 90;
            columns[table.TrimCodeColumn.ColumnName].Width = 90;
            columns[table.EngineModelColumn.ColumnName].Width = 110;
            columns[table.CarAddInfo1Column.ColumnName].Width = 160;
            columns[table.CarAddInfo2Column.ColumnName].Width = 160;
            columns[table.NumberPlate1CodeColumn.ColumnName].Width = 130;
            columns[table.NumberPlate1CodeGuideColumn.ColumnName].Width = 24;
            columns[table.NumberPlate1NameColumn.ColumnName].Width = 130;
            columns[table.NumberPlate2Column.ColumnName].Width = 150;
            columns[table.NumberPlate3Column.ColumnName].Width = 150;
            columns[table.NumberPlate4Column.ColumnName].Width = 210;
            columns[table.MileageColumn.ColumnName].Width = 90;
            columns[table.CarInspectYearColumn.ColumnName].Width = 100;
            columns[table.EntryDateColumn.ColumnName].Width = 130;
            columns[table.LTimeCiMatDateColumn.ColumnName].Width = 130;
            columns[table.InspectMaturityDateColumn.ColumnName].Width = 130;
            columns[table.CarNoteColumn.ColumnName].Width = 210;
            columns[table.CarNoteGuideColumn.ColumnName].Width = 24;

            //--------------------------------------
            // 入力桁数
            //--------------------------------------
            //columns[table.RowNoColumn.ColumnName].MaxLength = 4;
            //columns[table.DeleteDateColumn.ColumnName].MaxLength = 4;
            columns[table.CustomerCodeColumn.ColumnName].MaxLength = 8;
            //columns[table.CustomerCodeGuideColumn.ColumnName].MaxLength = 4;
            columns[table.CarMngCodeColumn.ColumnName].MaxLength = 18;
            //columns[table.CarMngCodeGuideColumn.ColumnName].MaxLength = 4;
            columns[table.ModelFullNameColumn.ColumnName].MaxLength = 4;
            columns[table.FullModelColumn.ColumnName].MaxLength = 4;
            columns[table.ModelDesignationNoColumn.ColumnName].MaxLength = 4;
            columns[table.CategoryNoColumn.ColumnName].MaxLength = 4;
            columns[table.EngineModelNmColumn.ColumnName].MaxLength = 4;
            //columns[table.FirstEntryDateColumn.ColumnName].MaxLength = 4;
            columns[table.FrameNoColumn.ColumnName].MaxLength = 4;
            columns[table.ColorCodeColumn.ColumnName].MaxLength = 4;
            columns[table.TrimCodeColumn.ColumnName].MaxLength = 4;
            columns[table.EngineModelColumn.ColumnName].MaxLength = 12;
            columns[table.CarAddInfo1Column.ColumnName].MaxLength = 15;
            columns[table.CarAddInfo2Column.ColumnName].MaxLength = 15;
            columns[table.NumberPlate1CodeColumn.ColumnName].MaxLength = 4;
            columns[table.NumberPlate1CodeGuideColumn.ColumnName].MaxLength = 4;
            columns[table.NumberPlate1NameColumn.ColumnName].MaxLength = 4;
            columns[table.NumberPlate2Column.ColumnName].MaxLength = 3;
            columns[table.NumberPlate3Column.ColumnName].MaxLength = 1;
            columns[table.NumberPlate4Column.ColumnName].MaxLength = 4;
            columns[table.MileageColumn.ColumnName].MaxLength = 7;
            columns[table.CarInspectYearColumn.ColumnName].MaxLength = 2;
            //columns[table.EntryDateColumn.ColumnName].MaxLength = 20;
            //columns[table.LTimeCiMatDateColumn.ColumnName].MaxLength = 20;
            //columns[table.InspectMaturityDateColumn.ColumnName].MaxLength = 20;
            columns[table.CarNoteColumn.ColumnName].MaxLength = 30;
            columns[table.CarNoteGuideColumn.ColumnName].MaxLength = 4;

            //--------------------------------------
            // テキスト位置(HAlign)
            //--------------------------------------
            columns[table.RowNoColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Right;
            columns[table.DeleteDateColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;
            columns[table.CustomerCodeColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Right;
            columns[table.CustomerCodeGuideColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Center;
            columns[table.CarMngCodeColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;
            //columns[table.CarMngCodeGuideColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Center;
            columns[table.ModelFullNameColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;
            columns[table.FullModelColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;
            columns[table.ModelDesignationNoColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Right;
            columns[table.CategoryNoColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Right;
            columns[table.EngineModelNmColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;
            columns[table.FirstEntryDateColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;
            columns[table.FrameNoColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;  // ADD 2013/03/22
            columns[table.ColorCodeColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;
            columns[table.TrimCodeColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;
            columns[table.EngineModelColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;
            columns[table.CarAddInfo1Column.ColumnName].CellAppearance.TextHAlign = HAlign.Left;
            columns[table.CarAddInfo2Column.ColumnName].CellAppearance.TextHAlign = HAlign.Left;
            columns[table.NumberPlate1CodeColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Right;
            columns[table.NumberPlate1CodeGuideColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Center;
            columns[table.NumberPlate1NameColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;
            //----- UPD 2016/12/13 呉軍 Redmine#48934 PMNSナンバープレート英文字対応 ----->>>>>
            //columns[table.NumberPlate2Column.ColumnName].CellAppearance.TextHAlign = HAlign.Right;
            columns[table.NumberPlate2Column.ColumnName].CellAppearance.TextHAlign = HAlign.Left;
            //----- UPD 2016/12/13 呉軍 Redmine#48934 PMNSナンバープレート英文字対応 -----<<<<<
            columns[table.NumberPlate3Column.ColumnName].CellAppearance.TextHAlign = HAlign.Left;
            columns[table.NumberPlate4Column.ColumnName].CellAppearance.TextHAlign = HAlign.Right;
            columns[table.MileageColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Right;
            columns[table.CarInspectYearColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Right;
            columns[table.EntryDateColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;
            columns[table.LTimeCiMatDateColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;
            columns[table.InspectMaturityDateColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;
            columns[table.CarNoteColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;
            columns[table.CarNoteGuideColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Center;
            //--------------------------------------
            // テキスト位置(VAlign)
            //--------------------------------------
            for (int index = 0; index < columns.Count; index++)
            {
                columns[index].CellAppearance.TextVAlign = VAlign.Middle;
            }

            //--------------------------------------
            // 日付コントロール設定
            //--------------------------------------
            //columns[table.FirstEntryDateColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Date;
            columns[table.EntryDateColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Date;
            columns[table.LTimeCiMatDateColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Date;
            columns[table.InspectMaturityDateColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Date;

            //columns[table.FirstEntryDateColumn.ColumnName].CellDisplayStyle = CellDisplayStyle.FormattedText;
            columns[table.EntryDateColumn.ColumnName].CellDisplayStyle = CellDisplayStyle.FormattedText;
            columns[table.LTimeCiMatDateColumn.ColumnName].CellDisplayStyle = CellDisplayStyle.FormattedText;
            columns[table.InspectMaturityDateColumn.ColumnName].CellDisplayStyle = CellDisplayStyle.FormattedText;

            //columns[table.FirstEntryDateColumn.ColumnName].Format = "yyyy年MM月";
            columns[table.EntryDateColumn.ColumnName].Format = "yyyy年MM月dd日";
            columns[table.LTimeCiMatDateColumn.ColumnName].Format = "yyyy年MM月dd日";
            columns[table.InspectMaturityDateColumn.ColumnName].Format = "yyyy年MM月dd日";
            columns[table.DeleteDateColumn.ColumnName].Format = "yyyy/MM/dd";
            columns[table.MileageColumn.ColumnName].Format = "###,###,##0";

            //--------------------------------------
            // ガイドボタン設定
            //--------------------------------------
            Image guideButtonImage = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];

            columns[table.CustomerCodeGuideColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button;
            columns[table.CarMngCodeGuideColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button;
            columns[table.NumberPlate1CodeGuideColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button;
            columns[table.CarNoteGuideColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button;

            columns[table.CustomerCodeGuideColumn.ColumnName].ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always;
            columns[table.CarMngCodeGuideColumn.ColumnName].ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always;
            columns[table.NumberPlate1CodeGuideColumn.ColumnName].ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always;
            columns[table.CarNoteGuideColumn.ColumnName].ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always;

            columns[table.CustomerCodeGuideColumn.ColumnName].CellButtonAppearance.Image = guideButtonImage;
            columns[table.CarMngCodeGuideColumn.ColumnName].CellButtonAppearance.Image = guideButtonImage;
            columns[table.NumberPlate1CodeGuideColumn.ColumnName].CellButtonAppearance.Image = guideButtonImage;
            columns[table.CarNoteGuideColumn.ColumnName].CellButtonAppearance.Image = guideButtonImage;

            columns[table.CustomerCodeGuideColumn.ColumnName].CellButtonAppearance.ImageHAlign = HAlign.Center;
            columns[table.CarMngCodeGuideColumn.ColumnName].CellButtonAppearance.ImageHAlign = HAlign.Center;
            columns[table.NumberPlate1CodeGuideColumn.ColumnName].CellButtonAppearance.ImageHAlign = HAlign.Center;
            columns[table.CarNoteGuideColumn.ColumnName].CellButtonAppearance.ImageHAlign = HAlign.Center;

            columns[table.CustomerCodeGuideColumn.ColumnName].CellButtonAppearance.ImageVAlign = VAlign.Middle;
            columns[table.CarMngCodeGuideColumn.ColumnName].CellButtonAppearance.ImageVAlign = VAlign.Middle;
            columns[table.NumberPlate1CodeGuideColumn.ColumnName].CellButtonAppearance.ImageVAlign = VAlign.Middle;
            columns[table.CarNoteGuideColumn.ColumnName].CellButtonAppearance.ImageVAlign = VAlign.Middle;

            columns[table.CustomerCodeGuideColumn.ColumnName].CellAppearance.Cursor = Cursors.Hand;
            columns[table.CarMngCodeGuideColumn.ColumnName].CellAppearance.Cursor = Cursors.Hand;
            columns[table.NumberPlate1CodeGuideColumn.ColumnName].CellAppearance.Cursor = Cursors.Hand;
            columns[table.CarNoteGuideColumn.ColumnName].CellAppearance.Cursor = Cursors.Hand;

            //--------------------------------------
            // クリック時動作制御
            //--------------------------------------
            columns[table.RowNoColumn.ColumnName].CellClickAction = CellClickAction.RowSelect;
            columns[table.DeleteDateColumn.ColumnName].CellClickAction = CellClickAction.RowSelect;
            //columns[table.CustomerCodeColumn.ColumnName].CellClickAction = CellClickAction.RowSelect;
            //columns[table.CustomerCodeGuideColumn.ColumnName].CellClickAction = CellClickAction.RowSelect;
            // ---- ADD 2009/10/10 ------>>>>>
            columns[table.DeleteDateColumn.ColumnName].CellClickAction = CellClickAction.RowSelect;
            columns[table.ModelFullNameColumn.ColumnName].CellClickAction = CellClickAction.RowSelect;
            columns[table.FullModelColumn.ColumnName].CellClickAction = CellClickAction.RowSelect;
            columns[table.ModelDesignationNoColumn.ColumnName].CellClickAction = CellClickAction.RowSelect;
            columns[table.CategoryNoColumn.ColumnName].CellClickAction = CellClickAction.RowSelect;
            columns[table.EngineModelNmColumn.ColumnName].CellClickAction = CellClickAction.RowSelect;
            columns[table.FirstEntryDateColumn.ColumnName].CellClickAction = CellClickAction.RowSelect;
            columns[table.FrameNoColumn.ColumnName].CellClickAction = CellClickAction.RowSelect;
            columns[table.ColorCodeColumn.ColumnName].CellClickAction = CellClickAction.RowSelect;
            columns[table.TrimCodeColumn.ColumnName].CellClickAction = CellClickAction.RowSelect;
            columns[table.NumberPlate1NameColumn.ColumnName].CellClickAction = CellClickAction.RowSelect;
            // ---- ADD 2009/10/10 ------<<<<<

            //--------------------------------------
            // フォーマット設定
            //--------------------------------------
            //columns[table.CustomerCodeColumn.ColumnName].CellDisplayStyle = CellDisplayStyle.FormattedText;
            //columns[table.CustomerCodeColumn.ColumnName].Format = "00000000";

            columns[table.DeleteDateColumn.ColumnName].CellAppearance.ForeColor = Color.Red;
            columns[table.DeleteDateColumn.ColumnName].CellAppearance.ForeColorDisabled = Color.Red;
        }

        /// <summary>
        /// グリッド列表示非表示設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note		: 画面初期化の時、グリッド列初期設定を行います。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009/09/07</br>
        /// </remarks>
        private void SetGridColVisible()
        {
            Infragistics.Win.UltraWinGrid.UltraGridBand editBand = this.uGrid_Details.DisplayLayout.Bands[0];
            if (editBand == null) return;

            CarMngInputDataSet.CarInfoDataTable table = this._carInfoDataTable;
            ColumnsCollection columns = editBand.Columns;

            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn col in columns)
            {
                // 全ての列をいったん非表示にする。
                col.Hidden = true;
            }

            columns[table.RowNoColumn.ColumnName].Hidden = false;
            columns[table.DeleteDateColumn.ColumnName].Hidden = true;
            columns[table.CustomerCodeColumn.ColumnName].Hidden = false;
            columns[table.CustomerCodeGuideColumn.ColumnName].Hidden = false;
            columns[table.CarMngCodeColumn.ColumnName].Hidden = false;
            columns[table.CarMngCodeGuideColumn.ColumnName].Hidden = true;
            columns[table.ModelFullNameColumn.ColumnName].Hidden = false;
            columns[table.FullModelColumn.ColumnName].Hidden = false;
            columns[table.ModelDesignationNoColumn.ColumnName].Hidden = false;
            columns[table.CategoryNoColumn.ColumnName].Hidden = false;
            columns[table.EngineModelNmColumn.ColumnName].Hidden = false;
            columns[table.FirstEntryDateColumn.ColumnName].Hidden = false;
            columns[table.FrameNoColumn.ColumnName].Hidden = false;
            columns[table.ColorCodeColumn.ColumnName].Hidden = false;
            columns[table.TrimCodeColumn.ColumnName].Hidden = false;
            columns[table.EngineModelColumn.ColumnName].Hidden = false;
            columns[table.CarAddInfo1Column.ColumnName].Hidden = false;
            columns[table.CarAddInfo2Column.ColumnName].Hidden = false;
            columns[table.NumberPlate1CodeColumn.ColumnName].Hidden = false;
            columns[table.NumberPlate1CodeGuideColumn.ColumnName].Hidden = false;
            columns[table.NumberPlate1NameColumn.ColumnName].Hidden = false;
            columns[table.NumberPlate2Column.ColumnName].Hidden = false;
            columns[table.NumberPlate3Column.ColumnName].Hidden = false;
            columns[table.NumberPlate4Column.ColumnName].Hidden = false;
            columns[table.MileageColumn.ColumnName].Hidden = false;
            columns[table.CarInspectYearColumn.ColumnName].Hidden = false;
            columns[table.EntryDateColumn.ColumnName].Hidden = false;
            columns[table.LTimeCiMatDateColumn.ColumnName].Hidden = false;
            columns[table.InspectMaturityDateColumn.ColumnName].Hidden = false;
            columns[table.CarNoteColumn.ColumnName].Hidden = false;
            columns[table.CarNoteGuideColumn.ColumnName].Hidden = false;

        }

        /// <summary>
        /// ボタン操作有効処理
        /// </summary>
        /// <remarks>
        /// <br>Note		: ボタン操作有効処理を行います。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009/09/07</br>
        /// </remarks>
        public void SetButtonEnable()
        {
            // ボタン操作有効処理(引用複写,削除)
            this.SetCopyDeleteButtonEnable();

            // ボタン操作有効処理(引用貼付)
            this.SetPasteButtonEnable();
        }

        /// <summary>
        /// ボタン操作有効処理(引用複写,削除)
        /// </summary>
        /// <remarks>
        /// <br>Note		: ボタン操作有効処理(引用複写,削除)を行います。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009/09/07</br>
        /// </remarks>
        private void SetCopyDeleteButtonEnable()
        {
            int mode = -1;

            // ボタン押下制御
            // 選択済み行番号リスト取得処理
            Infragistics.Win.UltraWinGrid.SelectedRowsCollection rows = this.uGrid_Details.Selected.Rows;
            if (rows == null || rows.Count == 0)
            {
                this.SetEditButton(false);
                mode = -1;
            }
            // 選択済み行複数
            else if (rows.Count > 1)
            {
                mode = MODE_SELECTEDMULTI;
            }
            else
            {
                mode = MODE_SELECTEDSINGLE;
            }

            switch (mode)
            {
                // 選択済み行複数以外
                case MODE_SELECTEDSINGLE:
                    {
                        this.uButton_RowCopy.Enabled = true;

                        // 論理削除済の場合,ボタンを無効
                        if (rows[0].Cells[this._carInfoDataTable.DeleteDateColumn.ColumnName].Value != DBNull.Value
                            && (DateTime)rows[0].Cells[this._carInfoDataTable.DeleteDateColumn.ColumnName].Value != DateTime.MinValue)
                        {
                            this.uButton_RowDelete.Enabled = false;
                        }
                        else
                        {
                            this.uButton_RowDelete.Enabled = true;
                        }

                        // 新規の場合、編集不可
                        if ((string)rows[0].Cells[column_No].Value == CarMngListInputAcs.ROWNO_NEW)
                        {
                            this.SetEditButton(false);
                        }
                        else
                        {
                            this.SetEditButton(true);
                        }
                        break;
                    }
                // 選択済み行複数
                case MODE_SELECTEDMULTI:
                    {
                        this.uButton_RowCopy.Enabled = true;
                        this.uButton_RowDelete.Enabled = false;

                        this.SetEditButton(false);
                        break;
                    }
                default:
                    {
                        this.uButton_RowCopy.Enabled = false;
                        this.uButton_RowDelete.Enabled = false;

                        this.SetEditButton(false);
                        break;
                    }
            }
        }

        /// <summary>
        /// ボタン操作有効処理(引用貼付)
        /// </summary>
        /// <remarks>
        /// <br>Note		: ボタン操作有効処理(引用貼付)を行います。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009/09/07</br>
        /// </remarks>
        private void SetPasteButtonEnable()
        {
            // コピー行番号取得処理
            List<Guid> copyRowNoList = this._carMngListInputAcs.GetCopyCarInfoRowNo();

            if (copyRowNoList == null || copyRowNoList.Count == 0)
            {
                this.uButton_RowCopyAdd.Enabled = false;
            }
            else
            {
                this.uButton_RowCopyAdd.Enabled = true;
            }
        }
        #endregion

        #region ■ ボタンクリックイベント
        /// <summary>
        /// ツールバークリックイベント
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントデータ</param>
        /// <remarks>
        /// <br>Note        : ツールバークリック時に発生します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009.09.07</br>
        /// </remarks>
        private void tToolbarsManager_Main_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                //引用複写
                case "ButtonTool_RowCopy":
                    {
                        this.uButton_RowCopy_Click(this.uButton_RowCopy, new EventArgs());
                        break;
                    }
                //引用貼付
                case "ButtonTool_RowPaste":
                    {
                        this.uButton_RowCopyAdd_Click(this.uButton_RowCopyAdd, new EventArgs());
                        break;
                    }
                //削除
                case "ButtonTool_RowDelete":
                    {
                        this.uButton_RowDelete_Click(this.uButton_RowDelete, new EventArgs());
                        break;
                    }
            }
        }

        /// <summary>
        /// ClickCellButton イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : セルボタンをクリックされた時に発生します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009/09/07</br>
        /// </remarks>
        private void uGrid_Details_ClickCellButton(object sender, CellEventArgs e)
        {
            int status;

            UltraGrid uGrid = (UltraGrid)sender;
            int rowIndex = e.Cell.Row.Index;
            int columnIndex = e.Cell.Column.Index;

            switch (e.Cell.Column.Key)
            {
                // 得意先ガイド
                case column_CustomerCodeGuide:
                    try
                    {
                        this.Cursor = Cursors.WaitCursor;

                        CustomerSearchRet customerSearchRet;

                        status = ShowCustomerGuide(out customerSearchRet, PMKHN04005UA.SEARCHMODE_NORMAL);

                        if (status == 0)
                        {
                            uGrid.Rows[rowIndex].Cells[this._carInfoDataTable.CustomerCodeColumn.ColumnName].Value = customerSearchRet.CustomerCode.ToString();

                            // フォーカス設定
                            this.uGrid_Details.PerformAction(UltraGridAction.NextCellByTab);
                        }
                    }
                    finally
                    {
                        this.Cursor = Cursors.Default;
                    }
                    break;
                // 管理番号ガイド
                case column_CarMngCodeGuide:
                    // なし
                    break;

                // 陸運事務所番号ガイド
                case column_NumberPlate1CodeGuide:
                    try
                    {
                        this.Cursor = Cursors.WaitCursor;
                        UserGdBd userGdBd = new UserGdBd();

                        status = ShowUserGuide(out userGdBd, 80);

                        if (status == 0)
                        {
                            uGrid.Rows[rowIndex].Cells[this._carInfoDataTable.NumberPlate1CodeColumn.ColumnName].Value = userGdBd.GuideCode.ToString();
                            //uGrid.Rows[rowIndex].Cells[this._carInfoDataTable.NumberPlate1NameColumn.ColumnName].Value = userGdBd.GuideName;
                            if (userGdBd.GuideName.Length>4)
                            {
                                uGrid.Rows[rowIndex].Cells[this._carInfoDataTable.NumberPlate1NameColumn.ColumnName].Value = userGdBd.GuideName.Substring(0, 4);
                            }
                            else
                            {
                                uGrid.Rows[rowIndex].Cells[this._carInfoDataTable.NumberPlate1NameColumn.ColumnName].Value = userGdBd.GuideName;
                            }
                           
                        }
                    }
                    finally
                    {
                        this.Cursor = Cursors.Default;
                    }
                    break;

                // 備考ガイド
                case column_CarNoteGuide:
                    {
                        try
                        {
                            this.Cursor = Cursors.WaitCursor;
                            NoteGuidBd noteGuidBd;

                            status = this.ShowNoteGuide(out noteGuidBd, ctDIVCODE_NoteGuideDivCd);

                            if (status == 0)
                            {
                                uGrid.Rows[rowIndex].Cells[this._carInfoDataTable.CarNoteColumn.ColumnName].Value = noteGuidBd.NoteGuideName;
                            }
                        }
                        finally
                        {
                            this.Cursor = Cursors.Default;
                        }
                        break;
                    }
            }

            // 行単位でのセルColor設定
            this.SetGridColorRow(uGrid.Rows[rowIndex]);
        }

        /// <summary>
        /// 引用複写ボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note		: 引用複写ボタンクリックイベントを行います。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009/09/07</br>
        /// </remarks>
        private void uButton_RowCopy_Click(object sender, EventArgs e)
        {
            this._carInfoDataTable.AcceptChanges();

            // 選択済み行番号リスト取得処理
            List<Guid> selectedStockRowNoList = this.GetSelectedRowNoList();
            if (selectedStockRowNoList == null) return;

            // --- UPD 2009/10/26 -------------------------------->>>>>
            //// データテーブルRowStatus列値設定処理
            //this._carMngListInputAcs.SetCarInfoRowStatusColumn(selectedStockRowNoList, CarMngListInputAcs.ROWSTATUS_COPY);
            // コピー行番号取得処理
            List<Guid> myCopyRowNoList = this._carMngListInputAcs.GetCopyCarInfoRowNo();
            List<Guid> removeRowNoList = new List<Guid>();
            if (myCopyRowNoList != null)
            {
                for (int i = 0; i < selectedStockRowNoList.Count; i++)
                {
                    if (myCopyRowNoList.Contains(selectedStockRowNoList[i]))
                    {
                        //引用複写として選択済みの行を選択し、「引用複写ボタン」押下した場合、選択行の引用複写を解除する。
                        removeRowNoList.Add(selectedStockRowNoList[i]);
                    }
                }
            }
            if (selectedStockRowNoList.Count > 0)
            {
                // データテーブルRowStatus列値設定処理
                this._carMngListInputAcs.SetCarInfoRowStatusColumn(selectedStockRowNoList, CarMngListInputAcs.ROWSTATUS_COPY);
            }
            if (removeRowNoList != null && removeRowNoList.Count > 0)
            {
                this._carMngListInputAcs.SetCarInfoRowStatusColumn(removeRowNoList, CarMngListInputAcs.ROWSTATUS_NORMAL);
            }
            // --- UPD 2009/10/26 --------------------------------<<<<<
            // 明細グリッド設定処理
            this.SettingGrid();

            // 次入力可能セル移動処理
            this.MoveNextAllowEditCell(true);

            this.SetButtonEnable();
        }

        /// <summary>
        /// 引用貼付ボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note		: 引用貼付ボタンクリックイベントを行います。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009/09/07</br>
        /// </remarks>
        private void uButton_RowCopyAdd_Click(object sender, EventArgs e)
        {
            this._carInfoDataTable.AcceptChanges();

            // コピー行番号取得処理
            List<Guid> copyRowNoList = this._carMngListInputAcs.GetCopyCarInfoRowNo();
            if (copyRowNoList == null) return;

            this._carMngListInputAcs.PasteInsertCarInfoRow(copyRowNoList);

            this._carMngListInputAcs.SetCarInfoRowStatusColumn(copyRowNoList, CarMngListInputAcs.ROWSTATUS_NORMAL);

            // 明細グリッドセル設定処理
            this.SettingGrid();

            // 次入力可能セル移動処理
            this.MoveNextAllowEditCell(true);

            this.SetButtonEnable();

            // --- ADD 2009/10/21 MANTIS：0014457 ------>>>>>
            _beforeSelectRowIndexList.Clear();
            foreach (UltraGridRow ultraGridRow in this.uGrid_Details.Selected.Rows)
            {
                this._beforeSelectRowIndexList.Add(ultraGridRow.Index);
            }
            // --- ADD 2009/10/21 MANTIS：0014457 ------<<<<<
        }

        /// <summary>
        /// 削除ボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note		: 削除ボタンクリックイベントを行います。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009/09/07</br>
        /// </remarks>
        private void uButton_RowDelete_Click(object sender, EventArgs e)
        {
            this._carInfoDataTable.AcceptChanges();

            // 選択済み行番号リスト取得処理
            List<Guid> selectedRowNoList = this.GetSelectedRowNoList();
            if (selectedRowNoList == null) return;
            if (selectedRowNoList.Count <= 0) return;

            this.RowDelete(selectedRowNoList);

            this.SetButtonEnable();
        }
        #endregion

        #region ■ グリッドセル更新イベント
        /// <summary>
        /// KeyDown イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : グリッドアクティブ時にKeyを押された時に発生します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009/09/07</br>
        /// </remarks>
        private void uGrid_Details_KeyDown(object sender, KeyEventArgs e)
        {
            UltraGrid uGrid = (UltraGrid)sender;

            if ((uGrid.Rows.Count == 0) ||
                ((uGrid.ActiveCell == null) && (uGrid.ActiveRow == null)))
            {
                switch (e.KeyCode)
                {
                    case Keys.Up:
                        {
                            this.SetFocus("tEdit_CarMngCode");
                            break;
                        }
                    case Keys.Down:
                    case Keys.Right:
                        {
                            this.SetFocus("tNedit_CustomerCode_St");
                            break;
                        }
                    case Keys.Left:
                        {
                            this.SetFocus("Before_Grid");
                            break;
                        }
                }
                return;
            }

            int rowIndex;
            int columnIndex;
            string columnKey;

            if (uGrid.ActiveCell != null)
            {
                // アクティブセル
                rowIndex = uGrid.ActiveCell.Row.Index;
                columnIndex = uGrid.ActiveCell.Column.Index;
                columnKey = uGrid.ActiveCell.Column.Key;
            }
            else
            {
                // アクティブ行
                rowIndex = uGrid.ActiveRow.Index;
                columnIndex = 0;
                columnKey = uGrid.ActiveRow.Cells[columnIndex].Column.Key;
            }

            string nextFocusColumn;
            bool doActivate = false;

            switch (e.KeyCode)
            {
                case Keys.Up:
                    {
                        if (rowIndex == 0)
                        {
                            e.Handled = true;
                            //this.SetFocus("tEdit_CarMngCode");  // DEL 2009/10/10
                        }
                        else
                        {
                            if (uGrid.ActiveCell != null)
                            {
                                // セルアクティブ＆DDL
                                if (uGrid.DisplayLayout.Bands[0].Columns[columnIndex].Style == Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList)
                                {
                                    e.Handled = true;
                                    if (uGrid.ActiveCell.ValueListResolved.SelectedItemIndex != 0)
                                    {
                                        // 選択中のValueListが最小でなければキー遷移しない
                                        uGrid.ActiveCell.ValueListResolved.SelectedItemIndex = uGrid.ActiveCell.ValueListResolved.SelectedItemIndex - 1;
                                        break;
                                    }
                                    else
                                    {
                                        for (int i = rowIndex - 1; i >= 0; i--)
                                        {
                                            if (uGrid.Rows[i].Cells[columnIndex].Activation == Activation.AllowEdit)
                                            {
                                                uGrid.Rows[i].Cells[columnIndex].Activate();
                                                uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                                doActivate = true;
                                                break;
                                            }
                                        }

                                        if (!doActivate)
                                        {
                                            //this.SetFocus("tEdit_CarMngCode");  // DEL 2009/10/10
                                        }

                                        break;
                                    }
                                }
                            }

                            if (uGrid.ActiveCell != null)
                            {
                                e.Handled = true;

                                for (int i = rowIndex; i >= 1; i--)
                                {
                                    // 表示行探し
                                    if (!uGrid.Rows[i - 1].IsFilteredOut)
                                    {
                                        if (uGrid.Rows[i - 1].Cells[columnIndex].Activation == Activation.AllowEdit)
                                        {
                                            uGrid.Rows[i - 1].Cells[columnIndex].Activate();
                                            uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                            doActivate = true;
                                            break;
                                        }
                                        else
                                        {

                                            // 行アクティブ
                                            uGrid.Rows[i - 1].Activate();
                                            uGrid.Rows[i - 1].Selected = true;
                                            doActivate = true;
                                            break;

                                        }
                                    }
                                }

                                if (!doActivate)
                                {
                                    //this.SetFocus("tEdit_CarMngCode");  // DEL 2009/10/10
                                }
                            }
                        }
                        break;
                    }
                case Keys.Down:
                    {
                        if (rowIndex == uGrid.Rows.Count - 1)
                        {
                            e.Handled = true;
                            //this.SetFocus("tNedit_CustomerCode_St");  // DEL 2009/10/10
                        }
                        else
                        {
                            if (uGrid.ActiveCell != null)
                            {
                                if (uGrid.DisplayLayout.Bands[0].Columns[columnIndex].Style == Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList)
                                {
                                    e.Handled = true;
                                    if (uGrid.ActiveCell.ValueListResolved.SelectedItemIndex != uGrid.ActiveCell.ValueListResolved.ItemCount - 1)
                                    {
                                        // 選択中のValueListが最大でなければキー遷移しない
                                        uGrid.ActiveCell.ValueListResolved.SelectedItemIndex = uGrid.ActiveCell.ValueListResolved.SelectedItemIndex + 1;
                                        break;
                                    }
                                    else
                                    {
                                        for (int i = rowIndex + 1; i < uGrid.Rows.Count; i++)
                                        {
                                            if (uGrid.Rows[i].Cells[columnIndex].Activation == Activation.AllowEdit)
                                            {
                                                uGrid.Rows[i].Cells[columnIndex].Activate();
                                                uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                                doActivate = true;
                                                break;
                                            }
                                        }

                                        if (!doActivate)
                                        {
                                            //this.SetFocus("tNedit_CustomerCode_St");  // DEL 2009/10/10
                                        }

                                        break;
                                    }
                                }
                            }

                            if (uGrid.ActiveCell != null)
                            {
                                e.Handled = true;

                                for (int i = rowIndex; i < uGrid.Rows.Count - 1; i++)
                                {
                                    // 表示行探し
                                    if (!uGrid.Rows[i + 1].IsFilteredOut)
                                    {
                                        if (uGrid.Rows[i + 1].Cells[columnIndex].Activation == Activation.AllowEdit)
                                        {
                                            uGrid.Rows[i + 1].Cells[columnIndex].Activate();
                                            uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                            doActivate = true;
                                            break;
                                        }
                                        else
                                        {

                                            // 行アクティブ
                                            uGrid.Rows[i + 1].Activate();
                                            uGrid.Rows[i + 1].Selected = true;
                                            doActivate = true;
                                            break;

                                        }
                                    }
                                }

                                if (!doActivate)
                                {
                                    //this.SetFocus("tNedit_CustomerCode_St");  // DEL 2009/10/10
                                }
                            }
                        }
                        break;
                    }
                case Keys.Left:
                    {
                        if (uGrid.ActiveCell == null)
                        {
                            // 行アクティブ
                            int activationColIndex;
                            int activationRowIndex;

                            // 左はShift+Tabと同じ
                            nextFocusColumn = this.GetNextFocusColumnKey(columnIndex, rowIndex, true, out activationColIndex, out activationRowIndex);

                            if (nextFocusColumn != string.Empty)
                            {
                                uGrid.Rows[activationRowIndex].Cells[nextFocusColumn].Activate();
                                uGrid.PerformAction(UltraGridAction.EnterEditMode);
                            }
                            else
                            {
                                this.SetFocus("Before_Grid");
                            }

                            break;
                        }

                        if (
                            (uGrid.ActiveCell.IsInEditMode)
                            &&
                            ((uGrid.ActiveCell.Column.Style == Infragistics.Win.UltraWinGrid.ColumnStyle.Default) ||
                                (uGrid.ActiveCell.Column.Style == Infragistics.Win.UltraWinGrid.ColumnStyle.Edit) ||
                                (uGrid.ActiveCell.Column.Style == Infragistics.Win.UltraWinGrid.ColumnStyle.Date))
                            &&
                            (uGrid.ActiveCell.SelStart != 0)
                            )
                        {
                            break;
                        }
                        else
                        {
                            e.Handled = true;

                            int activationColIndex;
                            int activationRowIndex;

                            // 左はShift+Tabと同じ
                            nextFocusColumn = this.GetNextFocusColumnKey(columnIndex, rowIndex, true, out activationColIndex, out activationRowIndex);

                            if (nextFocusColumn != string.Empty)
                            {
                                // ----- UPD 2009/10/10 -------->>>>>
                                // グリット内の左右矢印のフォーカスは右端と左端で止まるように修正。
                                if (nextFocusColumn.Equals("CarNoteGuide"))
                                {
                                    uGrid.Rows[rowIndex].Cells[columnIndex].Activate();
                                    uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                }
                                else
                                {
                                    uGrid.Rows[activationRowIndex].Cells[nextFocusColumn].Activate();
                                    uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                }
                                
                            }
                            //else
                            //{
                            //    this.SetFocus("Before_Grid");
                            //}
                            // ----- UPD 2009/10/10 --------<<<<<
                        }
                        break;
                    }
                case Keys.Right:
                    {
                        if (uGrid.ActiveCell == null)
                        {
                            // 行アクティブ
                            int activationColIndex;
                            int activationRowIndex;

                            // 右はTabと同じ
                            nextFocusColumn = this.GetNextFocusColumnKey(columnIndex, rowIndex, false, out activationColIndex, out activationRowIndex);

                            if (nextFocusColumn != string.Empty)
                            {
                                uGrid.Rows[activationRowIndex].Cells[nextFocusColumn].Activate();
                                uGrid.PerformAction(UltraGridAction.EnterEditMode);
                            }
                            else
                            {
                                this.SetFocus("tNedit_CustomerCode_St");
                            }
                            break;
                        }

                        if (
                            (uGrid.ActiveCell.IsInEditMode)
                            &&
                            ((uGrid.ActiveCell.Column.Style == Infragistics.Win.UltraWinGrid.ColumnStyle.Default) ||
                                (uGrid.ActiveCell.Column.Style == Infragistics.Win.UltraWinGrid.ColumnStyle.Edit) ||
                                (uGrid.ActiveCell.Column.Style == Infragistics.Win.UltraWinGrid.ColumnStyle.Date))
                            &&
                            (uGrid.ActiveCell.SelStart < uGrid.ActiveCell.Text.Length)
                            )
                        {
                            break;
                        }
                        else
                        {
                            e.Handled = true;

                            int activationColIndex;
                            int activationRowIndex;

                            // 右はTabと同じ
                            nextFocusColumn = this.GetNextFocusColumnKey(columnIndex, rowIndex, false, out activationColIndex, out activationRowIndex);

                            if (nextFocusColumn != string.Empty)
                            { 
                                // ----- UPD 2009/10/10 -------->>>>>
                                // グリット内の左右矢印のフォーカスは右端と左端で止まるように修正。
                                if ((nextFocusColumn.Equals("EngineModel")
                                    && activationRowIndex != rowIndex) || (nextFocusColumn.Equals("CustomerCode")))
                                {
                                    uGrid.Rows[rowIndex].Cells[columnIndex].Activate();
                                    uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                }
                                else
                                {
                                    uGrid.Rows[activationRowIndex].Cells[nextFocusColumn].Activate();
                                    uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                }

                            }
                            //else
                            //{
                            //    this.SetFocus("Before_Grid");
                            //}
                            // ----- UPD 2009/10/10 --------<<<<<
                        }

                        break;
                    }
                case Keys.Space:
                    {
                        uGrid_Details_ClickCellButton(this.uGrid_Details, new CellEventArgs(uGrid_Details.ActiveCell));
                        break;
                    }
            }
        }

        /// <summary>
        /// KeyPress イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : グリッドアクティブ時にKeyを押された時に発生します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009/09/07</br>
        /// <br>UpdateNote  : 2016/12/13 呉軍</br>
        /// <br>管理番号    : 11270098-00</br>
        /// <br>            : Redmine#48934 PMNSナンバープレート英文字対応</br>
        /// </remarks>
        private void uGrid_Details_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (this.uGrid_Details.ActiveCell == null)
            {
                return;
            }

            UltraGridCell cell = this.uGrid_Details.ActiveCell;

            if (cell.IsInEditMode)
            {
                // 得意先コード
                if (cell.Column.Key == this._carInfoDataTable.CustomerCodeColumn.ColumnName)
                {
                    if (!KeyPressNumCheck(9, 0, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false))
                    {
                        e.Handled = true;
                        return;
                    }
                }
                // 陸運事務所番号,登録番号（プレート番号）
                if (cell.Column.Key == this._carInfoDataTable.NumberPlate1CodeColumn.ColumnName
                    || cell.Column.Key == this._carInfoDataTable.NumberPlate4Column.ColumnName)
                {
                    if (!KeyPressNumCheck(4, 0, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false))
                    {
                        e.Handled = true;
                        return;
                    }
                }
                // 登録番号（種別）
                else if (cell.Column.Key == this._carInfoDataTable.NumberPlate2Column.ColumnName)
                {
                    //----- UPD 2016/12/13 呉軍 Redmine#48934 PMNSナンバープレート英文字対応 ----->>>>>
                    //if (!KeyPressNumCheck(3, 0, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false))
                    if (!KeyPressChrCheck(3, 0, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false))
                    //----- UPD 2016/12/13 呉軍 Redmine#48934 PMNSナンバープレート英文字対応 -----<<<<<
                    {
                        e.Handled = true;
                        return;
                    }
                }
                // 走行距離
                else if (cell.Column.Key == this._carInfoDataTable.MileageColumn.ColumnName)
                {
                    if (!KeyPressNumCheck(7, 0, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false))
                    {
                        e.Handled = true;
                        return;
                    }
                }
                // 車検期間
                else if (cell.Column.Key == this._carInfoDataTable.CarInspectYearColumn.ColumnName)
                {
                    if (!KeyPressNumCheck(2, 0, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false))
                    {
                        e.Handled = true;
                        return;
                    }
                }
                else
                {
                    // UI設定を参照
                    if (this.uiSetControl1.CheckMatchingSet(cell.Column.Key, e.KeyChar) == false)
                    {
                        e.Handled = true;
                        return;
                    }
                }
            }
        }

        /// <summary>
        /// セルアクティブ前イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : セルアクティブ前時に発生します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009/09/07</br>
        /// </remarks>
        private void uGrid_Details_BeforeCellActivate(object sender, CancelableCellEventArgs e)
        {
            #region ■セル編集関連
            // 項目に従いIMEモード設定
            string cellKey = e.Cell.Column.Key;

            switch (cellKey)
            {
                // 半角
                case column_CustomerCode:
                case column_EngineModel:
                case column_NumberPlate1Code:
                case column_NumberPlate2:
                case column_NumberPlate4:
                case column_Mileage:
                case column_CarInspectYear:
                case column_EntryDate:
                case column_LTimeCiMatDate:
                case column_InspectMaturityDate:
                    {
                        // IMEを起動しない
                        this.uGrid_Details.ImeMode = ImeMode.Disable;
                        break;
                    }
                case column_NumberPlate3:
                case column_CarNote:
                    {
                        this.uGrid_Details.ImeMode = ImeMode.Hiragana;
                        break;
                    }
                // ｶﾅ
                case column_CarAddInfo1:
                case column_CarAddInfo2:
                    {
                        this.uGrid_Details.ImeMode = ImeMode.KatakanaHalf;
                        break;
                    }
                case column_CarMngCode:
                    {
                        this.uGrid_Details.ImeMode = ImeMode.Close;
                        break;
                    }
                default:
                    {
                        this.uGrid_Details.ImeMode = ImeMode.NoControl;
                        break;
                    }
            }

            // ゼロ詰め解除実行
            if (e.Cell.Column.DataType == typeof(string) &&
                e.Cell.StyleResolved == Infragistics.Win.UltraWinGrid.ColumnStyle.Edit)
            {
                if (e.Cell.Value != DBNull.Value)
                {
                    this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[e.Cell.Column.Key].Value =
                        this.uiSetControl1.GetZeroPadCanceledText(e.Cell.Column.Key,
                        (string)this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[e.Cell.Column.Key].Value);
                }
            }
            #endregion

            #region ■編集前項目値保存
            switch (e.Cell.Column.Key)
            {
                // 得意先コード
                case column_CustomerCode:
                    {
                        if (e.Cell.Value == null || e.Cell.Value == DBNull.Value)
                        {
                            this._tmpCustomerCode = string.Empty;
                        }
                        else
                        {
                            this._tmpCustomerCode = e.Cell.Value.ToString();
                        }
                        break;
                    }
                // 管理番号
                case column_CarMngCode:
                    {
                        if (e.Cell.Value == null || e.Cell.Value == DBNull.Value)
                        {
                            this._tmpCarMngCode = string.Empty;
                        }
                        else
                        {
                            this._tmpCarMngCode = e.Cell.Value.ToString();
                        }
                        break;
                    }
                // 陸運事務所番号
                case column_NumberPlate1Code:
                    {
                        if (e.Cell.Value == null || e.Cell.Value == DBNull.Value)
                        {
                            this._tmpNumberPlate1Code = string.Empty;
                        }
                        else
                        {
                            this._tmpNumberPlate1Code = e.Cell.Value.ToString();
                        }
                        break;
                    }
            #endregion
            }
        }

        /// <summary>
        /// AfterCellUpdate イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : セルの値が変更された時に発生します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009/09/07</br>
        /// </remarks>
        private void uGrid_Details_AfterCellUpdate(object sender, CellEventArgs e)
        {
            if (this.uGrid_Details.ActiveCell == null) return;
            Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.uGrid_Details.ActiveCell;

            switch (e.Cell.Column.Key)
            {
                // 得意先コード
                case column_CustomerCode:
                    {
                        this._canMove = true;
                        string code;
                        if (this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[column_CustomerCode].Value != DBNull.Value
                            && !string.Empty.Equals(this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[column_CustomerCode].Value.ToString()))
                        {
                            code = (string)this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[column_CustomerCode].Value;
                        }
                        else
                        {
                            return;
                        }

                        if (!this._carMngListInputAcs.CustomerSearchRetDic.ContainsKey(this._carMngListInputAcs.StrObjToInt(code)))
                        {
                            this._canMove = false;
                            // 該当なし
                            TMsgDisp.Show(this, 												// 親ウィンドウフォーム
                                            emErrorLevel.ERR_LEVEL_INFO, 						// エラーレベル
                                            this.Name,											// アセンブリID
                                            "得意先が存在しません。",                           // 表示するメッセージ
                                            -1,													// ステータス値
                                            MessageBoxButtons.OK);								// 表示するボタン

                            this.uGrid_Details.AfterCellUpdate -= this.uGrid_Details_AfterCellUpdate;
                            this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[column_CustomerCode].Value =
                                    this._carMngListInputAcs.StrPadLeft0(this._tmpCustomerCode, 8);
                            this.uGrid_Details.AfterCellUpdate += this.uGrid_Details_AfterCellUpdate;
                        }
                        else
                        {
                            this.uGrid_Details.AfterCellUpdate -= this.uGrid_Details_AfterCellUpdate;
                            this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[column_CustomerCode].Value =
                                    this._carMngListInputAcs.StrPadLeft0(code, 8);
                            this.uGrid_Details.AfterCellUpdate += this.uGrid_Details_AfterCellUpdate;

                            this.uGrid_Details.Rows[e.Cell.Row.Index].Cells["SaveCanFlag"].Value = 1; // 2009/10/26 ADD
                        }

                        break;
                    }
                // 管理番号
                case column_CarMngCode:
                    {
                        this.uGrid_Details.Rows[e.Cell.Row.Index].Cells["SaveCanFlag"].Value = 1; // 2009/10/26 ADD
                        break;
                    }
                // 原動機型式
                case column_EngineModel:
                    {
                        break;
                    }
                // 陸運事務所番号
                case column_NumberPlate1Code:
                    {
                        this._canMove = true;
                        string code;
                        if (this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[column_NumberPlate1Code].Value != DBNull.Value)
                        {
                            code = (string)this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[column_NumberPlate1Code].Value;
                        }
                        else
                        {
                            this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[column_NumberPlate1Name].Value = string.Empty;
                            return;
                        }

                        if (this._carMngListInputAcs.NumberPlate1CodeDic.ContainsKey(this._carMngListInputAcs.StrObjToInt(code)))
                        {
                            this.uGrid_Details.AfterCellUpdate -= this.uGrid_Details_AfterCellUpdate;
                            this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[column_NumberPlate1Code].Value = this._carMngListInputAcs.StrPadLeft0(code, 4);
                            string NumberPlate1Name = this._carMngListInputAcs.NumberPlate1CodeDic[this._carMngListInputAcs.StrObjToInt(code)].GuideName.Trim();
                            //this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[column_NumberPlate1Name].Value = NumberPlate1Name;
                            if (NumberPlate1Name.Length>4)
                            {
                                this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[column_NumberPlate1Name].Value = NumberPlate1Name.Substring(0,4);// ADD 2009/10/10
                            }
                            else
                            {
                                this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[column_NumberPlate1Name].Value = NumberPlate1Name;
                            }
                            
                            this.uGrid_Details.AfterCellUpdate += this.uGrid_Details_AfterCellUpdate;
                        }
                        else
                        {
                            this._canMove = false;
                            // 該当なし
                            TMsgDisp.Show(this, 												// 親ウィンドウフォーム
                                            emErrorLevel.ERR_LEVEL_INFO, 						// エラーレベル
                                            this.Name,											// アセンブリID
                                            "陸運事務所コードが存在しません。",                 // 表示するメッセージ
                                            -1,													// ステータス値
                                            MessageBoxButtons.OK);								// 表示するボタン

                            this.uGrid_Details.AfterCellUpdate -= this.uGrid_Details_AfterCellUpdate;
                            this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[column_NumberPlate1Code].Value = this._tmpNumberPlate1Code;
                            this.uGrid_Details.AfterCellUpdate += this.uGrid_Details_AfterCellUpdate;
                        }

                        break;
                    }
                // 走行距離
                case column_Mileage:
                    {
                        if (this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[column_Mileage].Value == DBNull.Value)
                        {
                            this.uGrid_Details.AfterCellUpdate -= this.uGrid_Details_AfterCellUpdate;
                            this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[column_Mileage].Value = 0;
                            this.uGrid_Details.AfterCellUpdate += this.uGrid_Details_AfterCellUpdate;
                        }
                        break;
                    }

                // 車検期間
                case column_CarInspectYear:
                    {
                        if (this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[column_CarInspectYear].Value == DBNull.Value)
                        {
                            this.uGrid_Details.AfterCellUpdate -= this.uGrid_Details_AfterCellUpdate;
                            this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[column_CarInspectYear].Value = 0;
                            this.uGrid_Details.AfterCellUpdate += this.uGrid_Details_AfterCellUpdate;
                        }
                        break;
                    }
            }
        }

        /// <summary>
        /// CellChange イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : セルの値が変更された時に発生します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009/09/07</br>
        /// <br>UpdateNote  : 2016/12/13 呉軍</br>
        /// <br>管理番号    : 11270098-00</br>
        /// <br>            : Redmine#48934 PMNSナンバープレート英文字対応</br>
        /// </remarks>
        private void uGrid_Details_CellChange(object sender, CellEventArgs e)
        {
            if (this.uGrid_Details.ActiveCell == null) return;
            Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.uGrid_Details.ActiveCell;

            switch (e.Cell.Column.Key)
            {
                //----- UPD 2016/12/13 呉軍 Redmine#48934 PMNSナンバープレート英文字対応 ----->>>>>
                //// 得意先コード
                //case column_CustomerCode:
                //// 登録番号（種別）
                //case column_NumberPlate2:
                // 登録番号（種別）
                case column_NumberPlate2:
                    {
                        // 半角英数字のみ入力可能
                        string value = cell.Text;

                        Regex r = new Regex(@"^[a-zａ-ｚA-ZＡ-Ｚ0-9０-９]+(\.)?[a-zａ-ｚA-ZＡ-Ｚ0-9０-９]*$");

                        if ((!String.IsNullOrEmpty(value)) && !r.IsMatch(value))
                        {
                            cell.Value = string.Empty;
                        }

                        break;
                    }
                // 得意先コード
                case column_CustomerCode:
                //----- UPD 2016/12/13 呉軍 Redmine#48934 PMNSナンバープレート英文字対応 -----<<<<<
                // 登録番号（プレート番号）
                case column_NumberPlate4:
                    {
                        // 半角数字のみ入力可能
                        string value = cell.Text;

                        Regex r = new Regex(@"^\d+(\.)?\d*$");

                        if ((!String.IsNullOrEmpty(value)) && !r.IsMatch(value))
                        {
                            this.uGrid_Details.AfterCellUpdate -= this.uGrid_Details_AfterCellUpdate;
                            cell.Value = string.Empty;
                            this.uGrid_Details.AfterCellUpdate += this.uGrid_Details_AfterCellUpdate;
                        }

                        break;
                    }
                // 登録番号（カナ）
                case column_NumberPlate3:
                    {
                        // 全角文字のみ入力可能
                        string value = cell.Text;


                        // 全角文字を判断する
                        bool isKana = true;
                        for (int i = 0; i < value.Length; i++)
                        {
                            String cutStr = value.Substring(i, 1);
                            if (ASCIIEncoding.Default.GetByteCount(cutStr) == 1)
                            {
                                isKana = false;
                                break;
                            }
                        }

                        // 半角がありの場合、クリアする
                        if (!isKana)
                        {
                            cell.Value = string.Empty;
                        }
                        break;
                    }
                // 管理番号
                case column_CarMngCode:
                // 原動機型式
                case column_EngineModel:
                    {
                        // 半角のみ入力可能
                        string value = cell.Text;

                        // 半角を判断する
                        bool isHalfKana = true;
                        for (int i = 0; i < value.Length; i++)
                        {
                            String cutStr = value.Substring(i, 1);
                            if (ASCIIEncoding.Default.GetByteCount(cutStr) == 2)
                            {
                                isHalfKana = false;
                                break;
                            }
                        }

                        // 半角がありの場合、クリアする
                        if (!isHalfKana)
                        {
                            cell.Value = string.Empty;
                        }
                        break;
                    }
            }
        }

        /// <summary>
        /// 選択行変更イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note		: 選択行変更を行います。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009/09/07</br>
        /// </remarks>
        private void uGrid_Details_AfterSelectChange(object sender, AfterSelectChangeEventArgs e)
        {
            // 前アクティブ行の設定
            if (this._beforeSelectRowIndexList.Count != 0)
            {
                foreach (int rowIndex in this._beforeSelectRowIndexList)
                {
                    if (rowIndex <= this.uGrid_Details.Rows.Count - 1)
                    {
                        this.SetGridColorRow(this.uGrid_Details.Rows[rowIndex]);
                    }
                }

                this._beforeSelectRowIndexList.Clear();
            }

            // BeforeRowDeactivateから移動
            foreach (UltraGridRow ultraGridRow in this.uGrid_Details.Selected.Rows)
            {
                this._beforeSelectRowIndexList.Add(ultraGridRow.Index);
            }

            // 選択行の背景色設定
            if (this.uGrid_Details.Selected.Rows.Count != 0)
            {
                foreach (UltraGridRow ultraGr in this.uGrid_Details.Selected.Rows)
                {
                    this.SetGridColorRow(ultraGr);
                }
            }
            if (this.uGrid_Details.ActiveCell != null)
            {
                this.SetGridColorRow(this.uGrid_Details.Rows[this.uGrid_Details.ActiveCell.Row.Index]);
            }

            // ボタン操作有効処理
            this.SetButtonEnable();

        }

        /// <summary>
        /// グリッドマウスクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note        : グリッドマウスクリックに発生します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009.09.07</br>
        /// <br>Update Note : 李占川 2010/06/08 障害改良対応（７月分）</br>
        /// <br>            : 管理番号選択時の不具合修正</br>
        /// </remarks>
        private void uGrid_Details_MouseClick(object sender, MouseEventArgs e)
        {
            // --- ADD 2010/06/08 ---------->>>>>
            if (e.Button == MouseButtons.Left)
            {
                Point lastMouseDown = new Point(e.X, e.Y);
                // UIElementを利用して座標位置のコントロールを取得
                UIElement element = this.uGrid_Details.DisplayLayout.UIElement.ElementFromPoint(lastMouseDown);
                // クリックした位置がGridRowの場合のみ処理を行う
                UltraGridRow ultraRow = element.GetContext(typeof(UltraGridRow)) as UltraGridRow;

                if (ultraRow != null && (string)ultraRow.Cells[this._carInfoDataTable.RowNoColumn.ColumnName].Value != CarMngListInputAcs.ROWNO_NEW)
                {
                    this.uGrid_Details.AfterSelectChange -= new Infragistics.Win.UltraWinGrid.AfterSelectChangeEventHandler(this.uGrid_Details_AfterSelectChange);
                    this.uGrid_Details.Selected.Rows.Clear();
                    this.uGrid_Details.AfterSelectChange += new Infragistics.Win.UltraWinGrid.AfterSelectChangeEventHandler(this.uGrid_Details_AfterSelectChange);
                    ultraRow.Activated = true;
                    ultraRow.Selected = true;
                }
            }
            // --- ADD 2010/06/08 ----------<<<<<

            // 右クリック以外の場合
            if (e.Button != MouseButtons.Right) return;
            if (this.uGrid_Details.ActiveRow == null) return;

            System.Drawing.Point nowPos = new Point(e.X, e.Y);

            Infragistics.Win.UIElement objElement = this.uGrid_Details.DisplayLayout.UIElement.ElementFromPoint(nowPos);

            // クリック位置が列ヘッダーか判定
            bool isColumnHeader = false;

            if (objElement != null)
            {
                if ((objElement.SelectableItem is Infragistics.Win.UltraWinGrid.ColumnHeader) ||
                    (objElement is Infragistics.Win.UltraWinGrid.HeaderUIElement))
                {
                    isColumnHeader = true;
                }
            }

            if (isColumnHeader)
            {
                // 列ヘッダー右クリック時は何もしない
            }
            else
            {
                // それ以外で右クリックされた場合は、編集のポップアップを表示する
                ((Infragistics.Win.UltraWinToolbars.PopupMenuTool)this.tToolbarsManager_Main.Tools["PopupMenuTool_Edit"]).ShowPopup(System.Windows.Forms.Cursor.Position, this.uGrid_Details);

                if ((this.uGrid_Details.ActiveCell == null) && (this.uGrid_Details.ActiveRow != null))
                {
                    if (this.uGrid_Details.ActiveRow.Selected)
                    {
                        //
                    }
                    else
                    {
                        this.uGrid_Details.Selected.Rows.Clear();
                        this.uGrid_Details.ActiveRow.Selected = true;
                    }
                }
            }
            
        }

        /// <summary>
        /// グリッドマウスDouleクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note        : グリッドマウスDouleクリック時に発生します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009.09.07</br>
        /// </remarks>
        private void uGrid_Details_DoubleClickCell(object sender, DoubleClickCellEventArgs e)
        {
            // ActiveRowがnull場合、処理しない
            if (this.uGrid_Details.ActiveRow == null)
            {
                return;
            }

            // ActiveRow行
            UltraGridRow row = this.uGrid_Details.ActiveRow;

            // 新規行場合、処理しない
            if ((string)row.Cells[column_No].Value == CarMngListInputAcs.ROWNO_NEW)
            {
                return;
            }

            this.uGrid_Details.Selected.Rows.Clear();
            this.uGrid_Details.ActiveRow.Selected = true;

            // データ入力画面を起動
            this.StartInPut((Guid)row.Cells[column_CarRelationGuid].Value);
        }

        /// <summary>
        /// BeforeCellDeactivateイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note        : セルアクティブ後時に発生します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009.09.07</br>
        /// </remarks>
        private void uGrid_Details_BeforeCellDeactivate(object sender, CancelEventArgs e)
        {
            // --- ADD 2009/10/26 ----->>>>>
            if (!_chooseFlg)
            {
                _chooseFlg = true;
            }
            // --- ADD 2009/10/26 -----<<<<<
            if (this.uGrid_Details.ActiveCell != null)
            {
                // 背景色設定
                this.SetGridColorRow(this.uGrid_Details.Rows[this.uGrid_Details.ActiveCell.Row.Index]);
            }
        }

        /// <summary>
        /// AfterExitEditModeイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note        : セル編集後時に発生します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009.09.07</br>
        /// </remarks>
        private void uGrid_Details_AfterExitEditMode(object sender, EventArgs e)
        {
            if (this.uGrid_Details.ActiveCell == null) return;
            Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.uGrid_Details.ActiveCell;

            switch (cell.Column.Key)
            {
                // 得意先コード
                case column_CustomerCode:
                    {
                        this._canMove = true;
                        if (this.uGrid_Details.Rows[cell.Row.Index].Cells[column_CustomerCode].Value != DBNull.Value &&
                            (string)this.uGrid_Details.Rows[cell.Row.Index].Cells[column_CustomerCode].Text != string.Empty
                            && this.uGrid_Details.Rows[cell.Row.Index].Cells[column_CarMngCode].Value != DBNull.Value &&
                            (string)this.uGrid_Details.Rows[cell.Row.Index].Cells[column_CarMngCode].Text != string.Empty
                            && (int)this.uGrid_Details.Rows[cell.Row.Index].Cells["SaveCanFlag"].Value == 1  // 2009/10/26 add
                            && cell.Activation.Equals(Activation.AllowEdit))
                        {
                            // 車輌管理マスタチェック処理
                            this.CarManagementCheck(this.uGrid_Details.Rows[cell.Row.Index]);
                            if(!_chooseFlg)
                            {
                                this.uGrid_Details.Rows[cell.Row.Index].Cells[column_CustomerCode].Value = this._tmpCustomerCode;
                            }
                        }
                        break;
                    }
                // 管理番号
                case column_CarMngCode:
                    {
                        this._canMove = true;
                        if (this.uGrid_Details.Rows[cell.Row.Index].Cells[column_CustomerCode].Value != DBNull.Value &&
                            (string)this.uGrid_Details.Rows[cell.Row.Index].Cells[column_CustomerCode].Text != string.Empty
                            && this.uGrid_Details.Rows[cell.Row.Index].Cells[column_CarMngCode].Value != DBNull.Value &&
                            (string)this.uGrid_Details.Rows[cell.Row.Index].Cells[column_CarMngCode].Text != string.Empty
                            && (int)this.uGrid_Details.Rows[cell.Row.Index].Cells["SaveCanFlag"].Value == 1  // 2009/10/26 add
                            && cell.Activation.Equals(Activation.AllowEdit))
                        {
                            // 車輌管理マスタチェック処理
                            this.CarManagementCheck(this.uGrid_Details.Rows[cell.Row.Index]);
                            if (!_chooseFlg)
                            {
                                this.uGrid_Details.Rows[cell.Row.Index].Cells[column_CarMngCode].Value = this._tmpCarMngCode;
                            }
                        }
                        break;
                    }
            }
            
        }
        #endregion

        #region ■ ボタン制御関連イベント
        /// <summary>
        /// Leaveイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note        : Leave時に発生します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009.09.07</br>
        /// </remarks>
        private void PMSYA09021UB_Leave(object sender, EventArgs e)
        {
            this.uGrid_Details.ActiveCell = null;
            this.uGrid_Details.ActiveRow = null;
            this.uGrid_Details.Selected.Rows.Clear();

            // ボタンを不可にする
            this.SetButtonEnable();

            this.SettingGrid();
        }
        #endregion

        // --- ADD 2009/10/21 MANTIS：0014457 ------>>>>>
        /// <summary>
        /// ソート変更後イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note		: ソート変更後イベントイベントを行います。</br>
        /// <br>Programmer  : 張莉莉</br>
        /// <br>Date        : 2009/10/21</br>
        /// </remarks>
        private void uGrid_Details_AfterSortChange(object sender, BandEventArgs e)
        {
            _beforeSelectRowIndexList.Clear();
            foreach (UltraGridRow ultraGridRow in this.uGrid_Details.Selected.Rows)
            {
                if (ultraGridRow.Index == -1) return;
                this._beforeSelectRowIndexList.Add(ultraGridRow.Index);
            }

            foreach (UltraGridRow gridRow in this.uGrid_Details.Rows)
            {
                if (gridRow.Selected)
                {
                    // 選択行の場合
                    foreach (UltraGridCell cell in gridRow.Cells)
                    {
                        if (cell.Column.Key != this._carInfoDataTable.RowNoColumn.ColumnName)
                        {
                            // 無効行もActiveセル色で上書き
                            cell.Appearance.BackColor = Color.FromArgb(251, 230, 148);
                            cell.Appearance.BackColor2 = Color.FromArgb(238, 149, 21);
                            cell.Appearance.BackColorDisabled = Color.FromArgb(251, 230, 148);
                            cell.Appearance.BackColorDisabled2 = Color.FromArgb(238, 149, 21);
                            cell.Appearance.BackGradientStyle = GradientStyle.Vertical;
                        }
                    }
                }
                else
                {
                    // 通常色設定
                    if (gridRow.Index % 2 == 0)
                    {
                        foreach (UltraGridCell ultraCell in gridRow.Cells)
                        {
                            if (ultraCell.Column.Key != this._carInfoDataTable.RowNoColumn.ColumnName)
                            {
                                if (ultraCell.Appearance.BackColor == Color.White
                                    || ultraCell.Appearance.BackColor == Color.Lavender)
                                {
                                    ultraCell.Appearance.BackColor = Color.White;
                                    ultraCell.Appearance.BackColor2 = Color.White;
                                    ultraCell.Appearance.BackColorDisabled = Color.White;
                                    ultraCell.Appearance.BackColorDisabled2 = Color.White;
                                }
                                else
                                {
                                    continue;
                                }
                                
                            }
                        }
                    }
                    else
                    {
                        foreach (UltraGridCell ultraCell in gridRow.Cells)
                        {
                            if (ultraCell.Column.Key != this._carInfoDataTable.RowNoColumn.ColumnName)
                            {
                                if (ultraCell.Appearance.BackColor == Color.White
                                    || ultraCell.Appearance.BackColor == Color.Lavender)
                                {
                                    ultraCell.Appearance.BackColor = Color.Lavender;
                                    ultraCell.Appearance.BackColor2 = Color.Lavender;
                                    ultraCell.Appearance.BackColorDisabled = Color.Lavender;
                                    ultraCell.Appearance.BackColorDisabled2 = Color.Lavender;
                                }
                                else
                                {
                                    continue;
                                }
                            }
                        }
                    }

                }
            }

        }
        // --- ADD 2009/10/21 MANTIS：0014457 ------<<<<<
        #endregion
    }
}

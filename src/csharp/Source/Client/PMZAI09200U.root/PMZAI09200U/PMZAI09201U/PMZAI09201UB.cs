//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 商品在庫一括登録修正
// プログラム概要   : 商品在庫の一括登録・一括変更・削除を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 上野 俊治
// 作 成 日  2008/12/22  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 上野 俊治
// 修 正 日  2009/02/02  修正内容 : 排他制御処理追加
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 上野 俊治
// 修 正 日  2009/02/23  修正内容 : 障害対応10766 複数行選択対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 上野 俊治
// 修 正 日  2009/03/02  修正内容 : 障害対応12082,12072,12087,12076
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 上野 俊治
// 修 正 日  2009/03/03  修正内容 : 障害対応12104,12103,12081,12074,12075
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 上野 俊治
// 修 正 日  2009/03/03  修正内容 : 障害対応12084
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 上野 俊治
// 修 正 日  2009/03/05  修正内容 : 障害対応12072,12085
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 上野 俊治
// 修 正 日  2009/03/05  修正内容 : 障害対応12082,12070,12132,12073,12205
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 上野 俊治
// 修 正 日  2009/03/10  修正内容 : 障害対応12080
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 上野 俊治
// 修 正 日  2009/03/10  修正内容 : 障害対応12223
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 上野 俊治
// 修 正 日  2009/04/06  修正内容 : 障害対応13112
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 高峰
// 修 正 日  2010/06/08  修正内容 : 障害・改良対応（７月リリース案件）
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 高峰
// 修 正 日  2010/08/11  修正内容 : 障害改良対応（８月分） キーボード操作の改良を行う。
//----------------------------------------------------------------------------//
// 管理番号  10707327-00 作成担当 : yangmj
// 作 成 日  2012/09/11  修正内容 : 障害・改良対応 Redmine#32095 商品在庫一括登録修正で「全ての価格情報が消える」
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : 宮本
// 作 成 日  2012/10/05  修正内容 : 障害・改良対応 移動先列取得関数修正(列移動時の対応)
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : yangyi
// 作 成 日  2013/05/11  修正内容 : 20150515配信分
//                                  Redmine#35018 「商品在庫一括修正」のサーバー負荷軽減　その２対応
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using Infragistics.Win;
using Infragistics.Win.Misc;
using Infragistics.Win.UltraWinGrid;

using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Common;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;


namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 商品在庫一括登録修正コントロールクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 商品在庫一括登録修正の明細表示、入力を行う</br>
    /// <br>Programmer : 30452 上野 俊治</br>
    /// <br>Date       : 2008.12.22</br>
    /// <br></br>
    /// <br>Update Note: 2009.02.02 30452 上野 俊治</br>
    /// <br>            ・排他制御処理追加</br>
    /// <br>Update Note: 2009/02/23 30452 上野 俊治</br>
    /// <br>            ・障害対応10766 複数行選択対応</br>
    /// <br>Update Note: 2009/03/02 30452 上野 俊治</br>
    /// <br>            ・障害対応12082,12072,12087,12076</br>
    /// <br>Update Note: 2009/03/03 30452 上野 俊治</br>
    /// <br>            ・障害対応12104,12103,12081,12074,12075</br>
    /// <br>Update Note: 2009/03/03 30452 上野 俊治</br>
    /// <br>            ・障害対応12084</br>
    /// <br>Update Note: 2009/03/05 30452 上野 俊治</br>
    /// <br>            ・障害対応12072,12085</br>
    /// <br>Update Note: 2009/03/05 30452 上野 俊治</br>
    /// <br>            ・障害対応12082,12070,12132,12073,12205</br>
    /// <br>Update Note: 2009/03/10 30452 上野 俊治</br>
    /// <br>            ・障害対応12080</br>
    /// <br>Update Note: 2009/03/10 30452 上野 俊治</br>
    /// <br>            ・障害対応12223</br>
    /// <br>Update Note: 2009/04/06 30452 上野 俊治</br>
    /// <br>            ・障害対応13112</br>
    /// <br>UpdateNote   : 2010/06/08 高峰 障害・改良対応（７月リリース案件）</br>
    /// <br>UpdateNote   : 2010/08/11 高峰 
    ///                 ・障害改良対応（８月分） キーボード操作の改良を行う。</br>
    /// <br>UpdateNote   : 2012/09/11 yangmj 障害・改良対応（７月リリース案件）</br>
    /// <br>管理番号     : 10707327-00 PM1203G</br> 							
    /// <br>               Redmine32095 商品在庫一括登録修正で「全ての価格情報が消える」</br>
    /// <br>Update Note　: 2013/05/11 yangyi</br>
    /// <br>管理番号   　: 10801804-00 20150515配信分の対応</br>
    /// <br>           　: Redmine#35018 「商品在庫一括修正」のサーバー負荷軽減　その２対応</br>
    /// </remarks>
    public partial class PMZAI09201UB : UserControl
    {
        # region ■Inner Class
        /// <summary>
        /// セル結合条件クラス（IMergedCellEvaluator インタフェースをインプリメント）
        /// </summary>
        private class CustomMergedCellEvaluatorGoods : Infragistics.Win.UltraWinGrid.IMergedCellEvaluator
        {
            /// <summary>
            /// セル結合条件判定処理
            /// </summary>
            /// <param name="row1">行１</param>
            /// <param name="row2">行２</param>
            /// <param name="column">列</param>
            /// <returns>列に関連付けられたrow1とrow2のセルが結合される場合、Trueを返します</returns>
            public bool ShouldCellsBeMerged(Infragistics.Win.UltraWinGrid.UltraGridRow row1, Infragistics.Win.UltraWinGrid.UltraGridRow row2, Infragistics.Win.UltraWinGrid.UltraGridColumn column)
            {
                if (row1.Cells["GoodsMaker"].Value == null || row1.Cells["GoodsMaker"].Value.ToString() == string.Empty
                    || row2.Cells["GoodsMaker"].Value == null || row2.Cells["GoodsMaker"].Value.ToString() == string.Empty
                    || row1.Cells["GoodsNo"].Value == null || row1.Cells["GoodsNo"].Value.ToString() == string.Empty
                    || row2.Cells["GoodsNo"].Value == null || row2.Cells["GoodsNo"].Value.ToString() == string.Empty)
                {
                    return false;
                }

                int makerCode1 = Convert.ToInt32(row1.Cells["GoodsMaker"].Value);
                int makerCode2 = Convert.ToInt32(row2.Cells["GoodsMaker"].Value);

                string goodsCode1 = row1.Cells["GoodsNo"].Value.ToString();
                string goodsCode2 = row2.Cells["GoodsNo"].Value.ToString();

                if ((goodsCode1.Trim() == "") || (goodsCode2.Trim() == "")) return false;
                return ((makerCode1 == makerCode2) && (goodsCode1 == goodsCode2));
            }
        }

        // --- ADD 2009/03/02 -------------------------------->>>>>
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

                /*
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
                */
                // --- DEL 2009/03/09 -------------------------------->>>>>
                //if (xCell.Value.ToString() == "新規")
                //{
                //    if (yCell.Value.ToString() == "新規")
                //    {
                //        return 0;
                //    }
                //    else
                //    {
                //        return 1;
                //    }
                //}
                //else
                //{
                //    if (yCell.Value.ToString() == "新規")
                //    {
                //        return -1;
                //    }
                //    else
                //    {
                //        return (Convert.ToInt32(xCell.Value).CompareTo(Convert.ToInt32(yCell.Value)));
                //    }
                //}
                // --- DEL 2009/03/09 --------------------------------<<<<<
                // --- ADD 2009/03/09 -------------------------------->>>>>
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
                // --- ADD 2009/03/09 --------------------------------<<<<<
            }
        }
        // --- ADD 2009/03/02 --------------------------------<<<<<
        #endregion

        #region ■private定数
        // 画面状態保存用ファイル名
        private const string XML_FILE_INITIAL_DATA = "PMZAI09201U.dat";
        #endregion

        #region ■private変数
        // 画面イメージコントロール部品
        private ControlScreenSkin _controlScreenSkin;
        // イメージリスト
        private ImageList _imageList16 = null;

        // 企業コード
        private string _enterpriseCode;
        // ログイン拠点コード
        private string _loginSectionCode;
                
        // 商品在庫テーブル
        private GoodsStockDataSet.GoodsStockDataTable _goodsStockDataTable;
        // 商品在庫一括登録アクセス
        private GoodsStockAcs _goodsStockAcs;

        // メーカーガイドアクセス
        private MakerAcs _makerAcs;
        // BLコードアクセス
        private BLGoodsCdAcs _blGoodsCdAcs;
        // 倉庫アクセス
        private WarehouseAcs _warehouseAcs;
        // ユーザーガイドアクセス
        private UserGuideAcs _userGuideAcs;
        // 仕入先ガイドアクセス
        private SupplierAcs _supplierAcs;
        // 商品中分類ガイド
        private GoodsGroupUAcs _goodsGroupUAcs;
        // グループコードガイド
        private BLGroupUAcs _blGroupUAcs;
        
        // 前回検索実行時の抽出条件
        // ※表示区分、対象区分変更時にクリアされる仕様になり、必要なくなりました。 // ADD 2009/02/04
        private ExtractInfo _beforeSearchExtractInfo;

        // 名称表示状態フラグ(true:表示)
        private bool _visibleNameColumnsStat;

        // グリッド設定制御クラス
        private GridStateController _gridStateController;

        // グリッド項目の更新前項目値
        private string _tmpGoodsNo = string.Empty;
        private int _tmpGoodsMaker = 0;
        private int _tmpBLGoodsCode = 0;
        private int _tmpEnterpriseGanreCode = 0;
        private string _tmpWarehouseCode = string.Empty;
        private int _tmpStockSupplierCode = 0;
        private string _tmpPriceStartDate1;
        private string _tmpPriceStartDate2;
        private string _tmpPriceStartDate3;
        private string _tmpPriceStartDate4; // ADD 2010/08/31
        private string _tmpPriceStartDate5; // ADD 2010/08/31
        private int _tmpSalesOrderUnit;
        private double _tmpMinimumStockCnt;
        private double _tmpMaximumStockCnt;

        //// 前アクティブ行インデックス(背景色設定用)
        //private int _tmpActiveRowIndex = -1; // DEL 2009/02/23
        // 前選択行インデックス(背景色設定用)
        private List<int> _beforeSelectRowIndexList = new List<int>(); // ADD 2009/02/23

        // 選択行に論理削除済行を含むか？(完全削除、復活時Warning表示用)
        private bool _includeGoodsLogicalDeleted = false; // ADD 2009/02/23
        private bool _includeStockLogicalDeleted = false; // ADD 2009/02/23

        private object _preComboEditorValue = null; // ADD 2010/08/11

        //--- ADD 2013/05/11 yangyi Redmine#35018の#53-No.7 ----->>>>>
        private string _gridGoodsNo;
        private int _gridGoodsMakerCd;
        //--- ADD 2013/05/11 yangyi Redmine#35018の#53-No.7 -----<<<<<

        #endregion

        //--- ADD 2013/05/11 yangyi Redmine#35018の#53-No.7 ----->>>>>
        public string GridGoodsNo
        {
            get { return this._gridGoodsNo; }
        }
        public int GridGoodsMakerCd
        {
            get { return this._gridGoodsMakerCd; }
        }
        //--- ADD 2013/05/11 yangyi Redmine#35018の#53-No.7 -----<<<<<

        #region ■デリゲート
        /// <summary>
        /// 抽出条件取得デリゲート
        /// </summary>
        /// <returns></returns>
        internal delegate ExtractInfo GetExtractInfoHander();

        /// <summary>
        /// フォーカス設定デリゲート
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="itemName">項目名称</param>
        internal delegate void SettingFocusEventHandler(string itemName);

        // --- ADD 2009/02/03 -------------------------------->>>>>
        /// <summary>
        /// 保存ボタン押下可否制御イベント
        /// </summary>
        internal delegate void SetSaveButtonEnableHandler();
        // --- ADD 2009/02/03 --------------------------------<<<<<
        #endregion

        #region ■イベント
        /// <summary>抽出条件取得イベント</summary>
        internal event GetExtractInfoHander GetExtractInfo;
        /// <summary>フォーカス設定イベント</summary>
        internal event SettingFocusEventHandler SetFocus;
        // --- ADD 2009/02/03 -------------------------------->>>>>
        /// <summary>保存ボタン押下可否設定イベント</summary>
        internal event SetSaveButtonEnableHandler SetSaveButton;
        // --- ADD 2009/02/03 --------------------------------<<<<<

        // --- ADD 2010/08/11 -------------------------------->>>>>
        /// <summary>
        /// ガイドの設定
        /// </summary>
        internal delegate void SetGuideEnabled(bool enabled);
        internal event SetGuideEnabled SetGuide;
        // --- ADD 2010/08/11 --------------------------------<<<<<
        #endregion

        #region ■コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public PMZAI09201UB()
        {
            InitializeComponent();

            this._controlScreenSkin = new ControlScreenSkin();
            this._imageList16 = IconResourceManagement.ImageList16;

            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            this._loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode.TrimEnd();

            this._goodsStockAcs = GoodsStockAcs.GetInstance();
            this._goodsStockDataTable = this._goodsStockAcs.GoodsStockDataTable;

            this._makerAcs = new MakerAcs();
            this._blGoodsCdAcs = new BLGoodsCdAcs();
            this._warehouseAcs = new WarehouseAcs();
            this._userGuideAcs = new UserGuideAcs();
            this._supplierAcs = new SupplierAcs();
            this._goodsGroupUAcs = new GoodsGroupUAcs();
            this._blGroupUAcs = new BLGroupUAcs();

            this._gridStateController = new GridStateController();
        }
        #endregion

        #region ■プロパティ
        /// <summary>検索時の抽出条件</summary>
        internal ExtractInfo BeforeSearchExtractInfo
        {
            get
            {
                return this._beforeSearchExtractInfo;
            }
            set
            {
                this._beforeSearchExtractInfo = value;
            }
        }
        #endregion

        #region ■publicメソッド

        #region ■ 初期化処理
        /// <summary>
        /// 初期化(クリア)処理
        /// </summary>
        internal void Initialize()
        {
            // 画面項目初期化
            InitializeScreen();

            // --- DEL 2009/02/23 -------------------------------->>>>>
            //// 明細グリッドセル設定処理
            //this.SetGridSettings();

            //// DataTable行クリア処理
            //this._goodsStockAcs.GoodsStockDataTable.Clear();
            //this._goodsStockAcs.OriginalGoodsStockDataTable.Clear();
            // --- DEL 2009/02/23 --------------------------------<<<<<
            // --- ADD 2009/02/23 -------------------------------->>>>>

            // DataTable行クリア処理
            this._goodsStockAcs.GoodsStockDataTable.Clear();
            this._goodsStockAcs.OriginalGoodsStockDataTable.Clear();

            // 明細グリッドセル設定処理
            this.SetGridSettings();

            // ソート設定の解除
            this.uGrid_Details.DisplayLayout.Bands[0].SortedColumns.Clear();
            // --- ADD 2009/02/23 --------------------------------<<<<<

            // 初期表示時の抽出条件を保存
            this._beforeSearchExtractInfo = this.GetExtractInfo();
        }
        #endregion

        #region ■ フォーカス遷移制御
        /// <summary>
        /// グリッドタブ移動制御
        /// </summary>
        /// <param name="e">イベントハンドラ</param>
        internal void SetGridTabFocus(ref ChangeFocusEventArgs e)
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
                    this.SetFocus("tComboEditor_DisplayDiv");
                }

                return;
            }
            else
            {
                // セルアクティブ
                int rowIndex = this.uGrid_Details.ActiveCell.Row.Index;
                int colIndex = this.uGrid_Details.ActiveCell.Column.Index;

                // グリッド脱出時用のコントロールを保持
                //Control tmpCntl = e.NextCtrl;
                e.NextCtrl = null;
                this.uGrid_Details.PerformAction(UltraGridAction.ExitEditMode);

                this.uGrid_Details.Focus();

                // 次セル取得
                nextFocusColumn = GetNextFocusColumnKey(colIndex, rowIndex, false, out activationColIndex, out activationRowIndex);

                if (nextFocusColumn != string.Empty)
                {
                    this.uGrid_Details.Rows[activationRowIndex].Cells[nextFocusColumn].Activate();
                    this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                }
                else
                {
                    this.SetFocus("tComboEditor_DisplayDiv");
                }
            }
        }

        /// <summary>
        /// グリッドシフトタブ制御
        /// </summary>
        /// <param name="e">イベントハンドラ</param>
        internal void SetGridShiftTabFocus(ref ChangeFocusEventArgs e)
        {
            // 次フォーカス先カラム名
            string nextFocusColumn;
            int activationColIndex;
            int activationRowIndex;

            //int lastColumnIndex = this.uGrid_Details.DisplayLayout.Bands[0].Columns.Count - 1;

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
                    //this.SetFocus("uButton_EmployeeCdGuide"); // DEL 2009/03/06
                    this.SetFocus("Before_Grid"); // ADD 2009/03/06
                }

                return;
            }
            else
            {
                // セルアクティブ
                int rowIndex = this.uGrid_Details.ActiveCell.Row.Index;
                int columnIndex = this.uGrid_Details.ActiveCell.Column.Index;

                // グリッド脱出時用のコントロールを保持
                //Control tmpCntl = e.NextCtrl;
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
                    //this.SetFocus("uButton_EmployeeCdGuide"); // DEL 2009/03/06
                    this.SetFocus("Before_Grid"); // ADD 2009/03/06
                }
            }
        }

        /// <summary>
        /// 次の入力可能列のKeyを取得する
        /// </summary>
        /// <param name="colIndex">チェック開始列index、Activation可能列を返す</param>
        /// <param name="rowIndex">チェック開始行index、Activation可能行を返す</param>
        /// <param param name="isShift">true:シフトあり false:シフトなし</param>
        /// <returns>Activation可能列のキー。ない場合はstring.Empty</returns>
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
                    if (!this.uGrid_Details.Rows[j].IsFilteredOut) // ADD 2009/03/06
                    {
                        /* --- DEL 2012/10/05 -------------------------------->>>>>
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
                           --- DEL 2012/10/05 --------------------------------<<<<< */
                        // --- ADD 2012/10/05 -------------------------------->>>>>
                        if (j == rowIndex)
                        {
                            // 指定行は指定カラムから先をチェック
                            for (int k = this.uGrid_Details.DisplayLayout.Bands[0].Columns[colIndex].Header.VisiblePosition + 1; k < this.uGrid_Details.DisplayLayout.Bands[0].Columns.Count; k++)
                            {
                                for (int i = 0; i < this.uGrid_Details.DisplayLayout.Bands[0].Columns.Count; i++)
                                {
                                    if (this.uGrid_Details.DisplayLayout.Bands[0].Columns[i].Header.VisiblePosition == k
                                     && this.uGrid_Details.DisplayLayout.Bands[0].Columns[i].CellActivation == Activation.AllowEdit
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
                        else
                        {
                            // 次行以降はカラムを順にチェック
                            for (int k = 0; k < this.uGrid_Details.DisplayLayout.Bands[0].Columns.Count; k++)
                            {
                                for (int i = 0; i < this.uGrid_Details.DisplayLayout.Bands[0].Columns.Count; i++)
                                {
                                    if (this.uGrid_Details.DisplayLayout.Bands[0].Columns[i].Header.VisiblePosition == k
                                     && this.uGrid_Details.DisplayLayout.Bands[0].Columns[i].CellActivation == Activation.AllowEdit
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
                        // --- ADD 2012/10/05 --------------------------------<<<<<
                    }
                }
            }
            else
            {
                // シフトあり
                for (int j = rowIndex; j >= 0; j--)
                {
                    if (!this.uGrid_Details.Rows[j].IsFilteredOut) // ADD 2009/03/06
                    {
                        /* --- DEL 2012/10/05 -------------------------------->>>>>
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
                           --- DEL 2012/10/05 --------------------------------<<<<< */
                        // --- ADD 2012/10/05 -------------------------------->>>>>
                        if (j == rowIndex)
                        {
                            for (int k = this.uGrid_Details.DisplayLayout.Bands[0].Columns[colIndex].Header.VisiblePosition - 1; k >= 0; k--)
                            {
                                for (int i = this.uGrid_Details.DisplayLayout.Bands[0].Columns.Count - 1; i >= 0; i--)
                                {
                                    if (this.uGrid_Details.DisplayLayout.Bands[0].Columns[i].Header.VisiblePosition == k
                                     && this.uGrid_Details.DisplayLayout.Bands[0].Columns[i].CellActivation == Activation.AllowEdit
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
                        else
                        {
                            for (int k = this.uGrid_Details.DisplayLayout.Bands[0].Columns.Count - 1; k >= 0; k--)
                            {
                                for (int i = this.uGrid_Details.DisplayLayout.Bands[0].Columns.Count - 1; i >= 0; i--)
                                {
                                    if (this.uGrid_Details.DisplayLayout.Bands[0].Columns[i].Header.VisiblePosition == k
                                     && this.uGrid_Details.DisplayLayout.Bands[0].Columns[i].CellActivation == Activation.AllowEdit
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
                        // --- ADD 2012/10/05 --------------------------------<<<<<
                    }
                }
            }


            return string.Empty;
        }

        #endregion

        #region ボタン押下制御
        // --- ADD 2009/02/23 -------------------------------->>>>>
        /// <summary>
        /// ボタン押下制御をCellアクティブとRowアクティブで振り分ける
        /// </summary>
        internal void SetButtonEnable()
        {
            if (this.uGrid_Details.ActiveCell != null)
            {
                this.SetButtonEnableByCell(this.uGrid_Details.ActiveCell.Row.Index, this.uGrid_Details.ActiveCell.Column.Key);
            }
            else
            {
                this.SetButtonEnableBySelectedRows();
            }
        }
        // --- ADD 2009/02/23 --------------------------------<<<<<
        #endregion

        #endregion

        #region ■privateメソッド

        #region ■ 画面表示関連
        #region ■ 初期表示設定
        /// <summary>
        /// 画面初期化
        /// </summary>
        private void InitializeScreen()
        {
            // スキン設定
            this._controlScreenSkin.LoadSkin();
            this._controlScreenSkin.SettingScreenSkin(this);

            // ボタン設定
            this.uButton_RowGoodsDelete.ImageList = this._imageList16;
            this.uButton_RowGoodsRevive.ImageList = this._imageList16;
            this.uButton_RowStockDelete.ImageList = this._imageList16;
            this.uButton_RowStockRevive.ImageList = this._imageList16;
            this.uButton_RowAdd.ImageList = this._imageList16;
            this.uButton_RowDispPrice.ImageList = this._imageList16;
            this.uButton_RowDispNames.ImageList = this._imageList16;
            //this.uButton_RowExcuteGuide.ImageList = this._imageList16; // DEL 2010/08/11

            this.uButton_RowGoodsDelete.Appearance.Image = (int)Size16_Index.ROWDELETE;
            this.uButton_RowGoodsRevive.Appearance.Image = (int)Size16_Index.RENEWAL;
            this.uButton_RowStockDelete.Appearance.Image = (int)Size16_Index.ROWDELETE;
            this.uButton_RowStockRevive.Appearance.Image = (int)Size16_Index.RENEWAL;
            this.uButton_RowAdd.Appearance.Image = (int)Size16_Index.ROWADD;
            this.uButton_RowDispPrice.Appearance.Image = (int)Size16_Index.GRIDDISPLAY;
            this.uButton_RowDispNames.Appearance.Image = (int)Size16_Index.GRIDDISPLAY;
            //this.uButton_RowExcuteGuide.Appearance.Image = (int)Size16_Index.GUIDE; // DEL 2010/08/11

            this.uButton_RowGoodsDelete.Enabled = false;
            this.uButton_RowGoodsRevive.Enabled = false;
            this.uButton_RowStockDelete.Enabled = false;
            this.uButton_RowStockRevive.Enabled = false;
            this.uButton_RowAdd.Enabled = true;
            this.uButton_RowDispPrice.Enabled = true;
            this.uButton_RowDispNames.Enabled = true;
            //this.uButton_RowExcuteGuide.Enabled = false; // DEL 2010/08/11
            this.SetGuide(false); // ADD 2010/08/11
        }

        /// <summary>
        /// グリッド列の初期化
        /// </summary>
        private void InitializeGrid()
        {
            // グリッド外観設定
            this.SetGridInitialSetting();

            // ボタン名称、表示、非表示設定処理
            this.SetButtonEnableByExtactInfo();

            // グリッド列表示非表示設定処理
            this.SetGridColSetting();

            // 初期表示時の抽出条件を保存
            this._beforeSearchExtractInfo = this.GetExtractInfo();
        }
        #endregion

        #region ■ グリッド表示設定
        /// <summary>
        /// グリッド列表示非表示設定
        /// </summary>
        /// <remarks>
        /// <br>補記</br>
        /// <br>CellActivationは固定とし、表示区分、対象区分によりHiddenを変更している</br>
        /// <br>グリッド内のキー遷移はCellActivation=Allow、Hidden=falseの行を入力可能行として制御している</br>
        /// <br>UpdateNote       : 2010/06/08 高峰 障害・改良対応（７月リリース案件）</br>
        /// </remarks>
        private void SetGridInitialSetting()
        {
            Infragistics.Win.UltraWinGrid.UltraGridBand band = this.uGrid_Details.DisplayLayout.Bands[0];
            if (band == null) return;

            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn col in band.Columns)
            {
                // 全列共通設定
                // 表示位置(vertical)
                col.CellAppearance.TextVAlign = VAlign.Middle;
            }

            GoodsStockDataSet.GoodsStockDataTable table = this._goodsStockDataTable;

            // 行番号列のみセル表示色変更
            band.Columns[table.RowNumberColumn.ColumnName].CellAppearance.BackColorDisabled = Color.FromArgb(89, 135, 214);
            band.Columns[table.RowNumberColumn.ColumnName].CellAppearance.BackColorDisabled2 = Color.FromArgb(7, 59, 150);
            band.Columns[table.RowNumberColumn.ColumnName].CellAppearance.BackGradientStyle = GradientStyle.Vertical;
            band.Columns[table.RowNumberColumn.ColumnName].CellAppearance.ForeColor = Color.White;
            band.Columns[table.RowNumberColumn.ColumnName].CellAppearance.ForeColorDisabled = Color.White;

            // 行番号列クリック時は行Active
            band.Columns[table.RowNumberColumn.ColumnName].CellClickAction = CellClickAction.RowSelect; // ADD 2009/02/05
            // 行番号列のソート順指定
            band.Columns[table.RowNumberColumn.ColumnName].SortComparer = new RowNumberSortComparer(); // ADD 2009/03/02

            // 固定列設定
            band.Columns[table.RowNumberColumn.ColumnName].Header.Fixed = true; // 行番号
            band.Columns[table.GoodsDeleteDateColumn.ColumnName].Header.Fixed = true; // 商品削除日
            band.Columns[table.StockDeleteDateColumn.ColumnName].Header.Fixed = true; // 在庫削除日
            band.Columns[table.GoodsNoColumn.ColumnName].Header.Fixed = true; // 品番

            // 表示幅設定
            band.Columns[table.RowNumberColumn.ColumnName].Width = 50; // 行番号
            band.Columns[table.GoodsDeleteDateColumn.ColumnName].Width = 80; // 商品削除日
            band.Columns[table.StockDeleteDateColumn.ColumnName].Width = 80; // 在庫削除日
            band.Columns[table.GoodsNoColumn.ColumnName].Width = 200; // 品番
            band.Columns[table.GoodsNameColumn.ColumnName].Width = 200; // 品名
            band.Columns[table.GoodsMakerColumn.ColumnName].Width = 100; // メーカーコード
            band.Columns[table.GoodsMakerNameColumn.ColumnName].Width = 100; // メーカー名称
            // --- DEL 2010/06/08 ---------->>>>>
            //band.Columns[table.GoodsNameKanaColumn.ColumnName].Width = 200; // 品名カナ
            // --- DEL 2010/06/08 ----------<<<<<
            band.Columns[table.JanColumn.ColumnName].Width = 120; // JANコード
            band.Columns[table.BLGoodsCodeColumn.ColumnName].Width = 100; // BLコード
            band.Columns[table.BLGoodsNameColumn.ColumnName].Width = 100; // BLコード名
            band.Columns[table.EnterpriseGanreCodeColumn.ColumnName].Width = 100; // 商品区分
            band.Columns[table.EnterpriseGanreNameColumn.ColumnName].Width = 100; // 商品区分名
            band.Columns[table.GoodsRateRankColumn.ColumnName].Width = 100; // 層別
            band.Columns[table.GoodsKindCodeColumn.ColumnName].Width = 100; // 商品属性
            band.Columns[table.TaxationDivCdColumn.ColumnName].Width = 100; // 課税区分
            band.Columns[table.GoodsMGroupColumn.ColumnName].Width = 100; // 商品中分類
            band.Columns[table.GoodsMGroupNameColumn.ColumnName].Width = 200; // 商品中分類名
            band.Columns[table.BLGroupCodeColumn.ColumnName].Width = 130; // グループコード
            band.Columns[table.BLGroupNameColumn.ColumnName].Width = 200; // グループコード名
            band.Columns[table.PriceStartDate1Column.ColumnName].Width = 120; // 価格開始日1
            band.Columns[table.ListPrice1Column.ColumnName].Width = 100; // 価格1
            band.Columns[table.OpenPriceDiv1Column.ColumnName].Width = 160; // オープン価格区分1
            band.Columns[table.StockRate1Column.ColumnName].Width = 100; // 仕入率1
            band.Columns[table.SalesUnitCost1Column.ColumnName].Width = 100; // 原単価1
            band.Columns[table.PriceStartDate2Column.ColumnName].Width = 120; // 価格開始日2
            band.Columns[table.ListPrice2Column.ColumnName].Width = 100; // 価格2
            band.Columns[table.OpenPriceDiv2Column.ColumnName].Width = 160; // オープン価格区分2
            band.Columns[table.StockRate2Column.ColumnName].Width = 100; // 仕入率2
            band.Columns[table.SalesUnitCost2Column.ColumnName].Width = 100; // 原単価2
            band.Columns[table.PriceStartDate3Column.ColumnName].Width = 120; // 価格開始日3
            band.Columns[table.ListPrice3Column.ColumnName].Width = 100; // 価格3
            band.Columns[table.OpenPriceDiv3Column.ColumnName].Width = 160; // オープン価格区分3
            band.Columns[table.StockRate3Column.ColumnName].Width = 100; // 仕入率3
            band.Columns[table.SalesUnitCost3Column.ColumnName].Width = 100; // 原単価3
            // --- ADD 2010/08/11 ---------->>>>>
            band.Columns[table.PriceStartDate4Column.ColumnName].Width = 120; // 価格開始日4
            band.Columns[table.ListPrice4Column.ColumnName].Width = 100; // 価格4
            band.Columns[table.OpenPriceDiv4Column.ColumnName].Width = 160; // オープン価格区分4
            band.Columns[table.StockRate4Column.ColumnName].Width = 100; // 仕入率4
            band.Columns[table.SalesUnitCost4Column.ColumnName].Width = 100; // 原単価4
            band.Columns[table.PriceStartDate5Column.ColumnName].Width = 120; // 価格開始日5
            band.Columns[table.ListPrice5Column.ColumnName].Width = 100; // 価格5
            band.Columns[table.OpenPriceDiv5Column.ColumnName].Width = 160; // オープン価格区分5
            band.Columns[table.StockRate5Column.ColumnName].Width = 100; // 仕入率5
            band.Columns[table.SalesUnitCost5Column.ColumnName].Width = 100; // 原単価5
            // --- ADD 2010/08/11 ----------<<<<<
            band.Columns[table.PriceFlColumn.ColumnName].Width = 120; // ユーザー価格
            band.Columns[table.UpRateColumn.ColumnName].Width = 100; // UP率
            band.Columns[table.WarehouseCodeColumn.ColumnName].Width = 100; // 倉庫コード
            band.Columns[table.WarehouseNameColumn.ColumnName].Width = 100; // 倉庫名
            // --- ADD 2009/03/10 -------------------------------->>>>>
            band.Columns[table.SectionCodeColumn.ColumnName].Width = 130; // 管理拠点コード
            band.Columns[table.SectionGuideSnmColumn.ColumnName].Width = 130; // 管理拠点名
            // --- ADD 2009/03/10 --------------------------------<<<<<
            band.Columns[table.WarehouseShelfNoColumn.ColumnName].Width = 100; // 棚番
            band.Columns[table.DuplicationShelfNo1Column.ColumnName].Width = 100; // 重複棚番1
            band.Columns[table.DuplicationShelfNo2Column.ColumnName].Width = 100; // 重複棚番2
            band.Columns[table.PartsManagementDivide1Column.ColumnName].Width = 100; // 管理区分1
            band.Columns[table.PartsManagementDivide2Column.ColumnName].Width = 100; // 管理区分2
            band.Columns[table.StockSupplierCodeColumn.ColumnName].Width = 100; // 発注先コード
            band.Columns[table.StockSupplierSnmColumn.ColumnName].Width = 150; // 発注先名
            band.Columns[table.StockDivColumn.ColumnName].Width = 100; // 在庫区分
            band.Columns[table.SalesOrderUnitColumn.ColumnName].Width = 100; // 発注ロット
            band.Columns[table.MinimumStockCntColumn.ColumnName].Width = 100; // 最低在庫数
            band.Columns[table.MaximumStockCntColumn.ColumnName].Width = 100; // 最大在庫数
            band.Columns[table.SupplierStockColumn.ColumnName].Width = 100; // 仕入在庫数
            band.Columns[table.ArrivalCntColumn.ColumnName].Width = 150; // 入荷数
            band.Columns[table.ShipmentCntColumn.ColumnName].Width = 150; // 出荷数
            band.Columns[table.AcpOdrCountColumn.ColumnName].Width = 100; // 受注数
            band.Columns[table.MovingSupliStockColumn.ColumnName].Width = 100; // 移動中仕入在庫数
            band.Columns[table.NowStockCntColumn.ColumnName].Width = 100; // 現在庫数
            // --- ADD 2009/03/05 -------------------------------->>>>>
            band.Columns[table.StockUnitPriceRateColumn.ColumnName].Width = 150;
            band.Columns[table.StockUnitPriceFlColumn.ColumnName].Width = 150;
            // --- ADD 2009/03/05 --------------------------------<<<<<
            band.Columns[table.ErrorMessageColumn.ColumnName].Width = 500; // エラーメッセージ // ADD 2009/03/10

            // 入力可否
            band.Columns[table.RowNumberColumn.ColumnName].CellActivation = Activation.Disabled; // 行番号
            band.Columns[table.GoodsLogicalDeleteFlgColumn.ColumnName].CellActivation = Activation.Disabled; // 商品マスタ論理削除フラグ
            band.Columns[table.StockLogicalDeleteFlgColumn.ColumnName].CellActivation = Activation.Disabled; // 在庫マスタ論理削除フラグ
            band.Columns[table.GoodsDeleteDateColumn.ColumnName].CellActivation = Activation.Disabled; // 商品削除日
            band.Columns[table.StockDeleteDateColumn.ColumnName].CellActivation = Activation.Disabled; // 在庫削除日
            band.Columns[table.GoodsNoColumn.ColumnName].CellActivation = Activation.AllowEdit; // 品番
            band.Columns[table.GoodsNameColumn.ColumnName].CellActivation = Activation.AllowEdit; // 品名
            band.Columns[table.GoodsMakerColumn.ColumnName].CellActivation = Activation.AllowEdit; // メーカーコード
            band.Columns[table.GoodsMakerNameColumn.ColumnName].CellActivation = Activation.Disabled; // メーカー名称
            // --- DEL 2010/06/08 ---------->>>>>
            //band.Columns[table.GoodsNameKanaColumn.ColumnName].CellActivation = Activation.AllowEdit; // 品名カナ
            // --- DEL 2010/06/08 ----------<<<<<
            band.Columns[table.JanColumn.ColumnName].CellActivation = Activation.AllowEdit; // JANコード
            band.Columns[table.BLGoodsCodeColumn.ColumnName].CellActivation = Activation.AllowEdit; // BLコード
            band.Columns[table.BLGoodsNameColumn.ColumnName].CellActivation = Activation.Disabled; // BLコード名
            band.Columns[table.EnterpriseGanreCodeColumn.ColumnName].CellActivation = Activation.AllowEdit; // 商品区分
            band.Columns[table.EnterpriseGanreNameColumn.ColumnName].CellActivation = Activation.Disabled; // 商品区分名
            band.Columns[table.GoodsRateRankColumn.ColumnName].CellActivation = Activation.AllowEdit; // 層別
            band.Columns[table.GoodsKindCodeColumn.ColumnName].CellActivation = Activation.AllowEdit; // 商品属性
            band.Columns[table.TaxationDivCdColumn.ColumnName].CellActivation = Activation.AllowEdit; // 課税区分
            band.Columns[table.GoodsMGroupColumn.ColumnName].CellActivation = Activation.Disabled; // 商品中分類
            band.Columns[table.GoodsMGroupNameColumn.ColumnName].CellActivation = Activation.Disabled; // 商品中分類名
            band.Columns[table.BLGroupCodeColumn.ColumnName].CellActivation = Activation.Disabled; // グループコード
            band.Columns[table.BLGroupNameColumn.ColumnName].CellActivation = Activation.Disabled; // グループコード名
            band.Columns[table.PriceStartDate1Column.ColumnName].CellActivation = Activation.AllowEdit; // 価格開始日1
            band.Columns[table.ListPrice1Column.ColumnName].CellActivation = Activation.AllowEdit; // 価格1
            band.Columns[table.OpenPriceDiv1Column.ColumnName].CellActivation = Activation.AllowEdit; // オープン価格区分1
            band.Columns[table.StockRate1Column.ColumnName].CellActivation = Activation.AllowEdit; // 仕入率1
            band.Columns[table.SalesUnitCost1Column.ColumnName].CellActivation = Activation.AllowEdit; // 原単価1
            band.Columns[table.PriceStartDate2Column.ColumnName].CellActivation = Activation.AllowEdit; // 価格開始日2
            band.Columns[table.ListPrice2Column.ColumnName].CellActivation = Activation.AllowEdit; // 価格2
            band.Columns[table.OpenPriceDiv2Column.ColumnName].CellActivation = Activation.AllowEdit; // オープン価格区分2
            band.Columns[table.StockRate2Column.ColumnName].CellActivation = Activation.AllowEdit; // 仕入率2
            band.Columns[table.SalesUnitCost2Column.ColumnName].CellActivation = Activation.AllowEdit; // 原単価2
            band.Columns[table.PriceStartDate3Column.ColumnName].CellActivation = Activation.AllowEdit; // 価格開始日3
            band.Columns[table.ListPrice3Column.ColumnName].CellActivation = Activation.AllowEdit; // 価格3
            band.Columns[table.OpenPriceDiv3Column.ColumnName].CellActivation = Activation.AllowEdit; // オープン価格区分3
            band.Columns[table.StockRate3Column.ColumnName].CellActivation = Activation.AllowEdit; // 仕入率3
            band.Columns[table.SalesUnitCost3Column.ColumnName].CellActivation = Activation.AllowEdit; // 原単価3
            // --- ADD 2010/08/11 ---------->>>>>
            band.Columns[table.PriceStartDate4Column.ColumnName].CellActivation = Activation.AllowEdit; // 価格開始日4
            band.Columns[table.ListPrice4Column.ColumnName].CellActivation = Activation.AllowEdit; // 価格4
            band.Columns[table.OpenPriceDiv4Column.ColumnName].CellActivation = Activation.AllowEdit; // オープン価格区分4
            band.Columns[table.StockRate4Column.ColumnName].CellActivation = Activation.AllowEdit; // 仕入率4
            band.Columns[table.SalesUnitCost4Column.ColumnName].CellActivation = Activation.AllowEdit; // 原単価4
            band.Columns[table.PriceStartDate5Column.ColumnName].CellActivation = Activation.AllowEdit; // 価格開始日5
            band.Columns[table.ListPrice5Column.ColumnName].CellActivation = Activation.AllowEdit; // 価格5
            band.Columns[table.OpenPriceDiv5Column.ColumnName].CellActivation = Activation.AllowEdit; // オープン価格区分5
            band.Columns[table.StockRate5Column.ColumnName].CellActivation = Activation.AllowEdit; // 仕入率5
            band.Columns[table.SalesUnitCost5Column.ColumnName].CellActivation = Activation.AllowEdit; // 原単価5
            // --- ADD 2010/08/11 ----------<<<<<
            band.Columns[table.PriceFlColumn.ColumnName].CellActivation = Activation.AllowEdit; // ユーザー価格
            band.Columns[table.UpRateColumn.ColumnName].CellActivation = Activation.AllowEdit; // UP率
            band.Columns[table.WarehouseCodeColumn.ColumnName].CellActivation = Activation.AllowEdit; // 倉庫コード
            band.Columns[table.WarehouseNameColumn.ColumnName].CellActivation = Activation.Disabled; // 倉庫名
            // --- ADD 2009/03/10 -------------------------------->>>>>
            band.Columns[table.SectionCodeColumn.ColumnName].CellActivation = Activation.Disabled; // 管理拠点コード
            band.Columns[table.SectionGuideSnmColumn.ColumnName].CellActivation = Activation.Disabled; // 管理拠点名
            // --- ADD 2009/03/10 --------------------------------<<<<<
            band.Columns[table.WarehouseShelfNoColumn.ColumnName].CellActivation = Activation.AllowEdit; // 棚番
            band.Columns[table.DuplicationShelfNo1Column.ColumnName].CellActivation = Activation.AllowEdit; // 重複棚番1
            band.Columns[table.DuplicationShelfNo2Column.ColumnName].CellActivation = Activation.AllowEdit; // 重複棚番2
            band.Columns[table.PartsManagementDivide1Column.ColumnName].CellActivation = Activation.AllowEdit; // 管理区分1
            band.Columns[table.PartsManagementDivide2Column.ColumnName].CellActivation = Activation.AllowEdit; // 管理区分2
            band.Columns[table.StockSupplierCodeColumn.ColumnName].CellActivation = Activation.AllowEdit; // 発注先コード
            band.Columns[table.StockSupplierSnmColumn.ColumnName].CellActivation = Activation.Disabled; // 発注先名
            band.Columns[table.StockDivColumn.ColumnName].CellActivation = Activation.AllowEdit; // 在庫区分
            band.Columns[table.SalesOrderUnitColumn.ColumnName].CellActivation = Activation.AllowEdit; // 発注ロット
            band.Columns[table.MinimumStockCntColumn.ColumnName].CellActivation = Activation.AllowEdit; // 最低在庫数
            band.Columns[table.MaximumStockCntColumn.ColumnName].CellActivation = Activation.AllowEdit; // 最大在庫数
            band.Columns[table.SupplierStockColumn.ColumnName].CellActivation = Activation.AllowEdit; // 仕入在庫数
            // --- DEL 2009/03/06 -------------------------------->>>>>
            //band.Columns[table.ArrivalCntColumn.ColumnName].CellActivation = Activation.AllowEdit; // 入荷数
            //band.Columns[table.ShipmentCntColumn.ColumnName].CellActivation = Activation.AllowEdit; // 出荷数
            //band.Columns[table.AcpOdrCountColumn.ColumnName].CellActivation = Activation.AllowEdit; // 受注数
            //band.Columns[table.MovingSupliStockColumn.ColumnName].CellActivation = Activation.AllowEdit; // 移動中仕入在庫数
            // --- DEL 2009/03/06 --------------------------------<<<<<
            // --- ADD 2009/03/06 -------------------------------->>>>>
            band.Columns[table.ArrivalCntColumn.ColumnName].CellActivation = Activation.Disabled; // 入荷数
            band.Columns[table.ShipmentCntColumn.ColumnName].CellActivation = Activation.Disabled; // 出荷数
            band.Columns[table.AcpOdrCountColumn.ColumnName].CellActivation = Activation.Disabled; // 受注数
            band.Columns[table.MovingSupliStockColumn.ColumnName].CellActivation = Activation.Disabled; // 移動中仕入在庫数
            // --- ADD 2009/03/06 --------------------------------<<<<<
            band.Columns[table.NowStockCntColumn.ColumnName].CellActivation = Activation.Disabled; // 現在庫数
            // --- ADD 2009/03/05 -------------------------------->>>>>
            band.Columns[table.StockUnitPriceRateColumn.ColumnName].CellActivation = Activation.AllowEdit; // 棚卸評価率
            band.Columns[table.StockUnitPriceFlColumn.ColumnName].CellActivation = Activation.AllowEdit; // 棚卸評価単価
            // --- ADD 2009/03/05 --------------------------------<<<<<
            band.Columns[table.ErrorMessageColumn.ColumnName].CellActivation = Activation.Disabled; // エラーメッセージ // ADD 2009/03/10

            // --- ADD 2009/02/23 -------------------------------->>>>>
            // 選択不可行はクリック時行選択にする
            band.Columns[table.GoodsLogicalDeleteFlgColumn.ColumnName].CellClickAction = CellClickAction.RowSelect;
            band.Columns[table.StockLogicalDeleteFlgColumn.ColumnName].CellClickAction = CellClickAction.RowSelect;
            band.Columns[table.GoodsDeleteDateColumn.ColumnName].CellClickAction = CellClickAction.RowSelect;
            band.Columns[table.StockDeleteDateColumn.ColumnName].CellClickAction = CellClickAction.RowSelect;
            band.Columns[table.GoodsMakerNameColumn.ColumnName].CellClickAction = CellClickAction.RowSelect;
            band.Columns[table.BLGoodsNameColumn.ColumnName].CellClickAction = CellClickAction.RowSelect;
            band.Columns[table.EnterpriseGanreNameColumn.ColumnName].CellClickAction = CellClickAction.RowSelect;
            band.Columns[table.GoodsMGroupColumn.ColumnName].CellClickAction = CellClickAction.RowSelect;
            band.Columns[table.GoodsMGroupNameColumn.ColumnName].CellClickAction = CellClickAction.RowSelect;
            band.Columns[table.BLGroupCodeColumn.ColumnName].CellClickAction = CellClickAction.RowSelect;
            band.Columns[table.BLGroupNameColumn.ColumnName].CellClickAction = CellClickAction.RowSelect;
            band.Columns[table.WarehouseNameColumn.ColumnName].CellClickAction = CellClickAction.RowSelect;
            // --- ADD 2009/03/10 -------------------------------->>>>>
            band.Columns[table.SectionCodeColumn.ColumnName].CellClickAction = CellClickAction.RowSelect; // 管理拠点コード
            band.Columns[table.SectionGuideSnmColumn.ColumnName].CellClickAction = CellClickAction.RowSelect; // 管理拠点名
            // --- ADD 2009/03/10 --------------------------------<<<<<
            band.Columns[table.StockSupplierSnmColumn.ColumnName].CellClickAction = CellClickAction.RowSelect;
            band.Columns[table.NowStockCntColumn.ColumnName].CellClickAction = CellClickAction.RowSelect;
            // --- ADD 2009/02/23 --------------------------------<<<<<
            // --- ADD 2009/03/06 -------------------------------->>>>>
            band.Columns[table.ArrivalCntColumn.ColumnName].CellClickAction = CellClickAction.RowSelect; // 入荷数
            band.Columns[table.ShipmentCntColumn.ColumnName].CellClickAction = CellClickAction.RowSelect; // 出荷数
            band.Columns[table.AcpOdrCountColumn.ColumnName].CellClickAction = CellClickAction.RowSelect; // 受注数
            band.Columns[table.MovingSupliStockColumn.ColumnName].CellClickAction = CellClickAction.RowSelect; // 移動中仕入在庫数
            // --- ADD 2009/03/06 --------------------------------<<<<<
            band.Columns[table.ErrorMessageColumn.ColumnName].CellActivation = Activation.Disabled; // エラーメッセージ

            // 入力可能桁数
            band.Columns[table.RowNumberColumn.ColumnName].MaxLength = 8; // 行番号
            band.Columns[table.GoodsNoColumn.ColumnName].MaxLength = 24; // 品番
            band.Columns[table.GoodsNameColumn.ColumnName].MaxLength = 40; // 品名
            band.Columns[table.GoodsMakerColumn.ColumnName].MaxLength = 4; // メーカーコード
            band.Columns[table.GoodsMakerNameColumn.ColumnName].MaxLength = 10; // メーカー名称
            // --- DEL 2010/06/08 ---------->>>>>
            //band.Columns[table.GoodsNameKanaColumn.ColumnName].MaxLength = 40; // 品名カナ
            // --- DEL 2010/06/08 ----------<<<<<
            band.Columns[table.JanColumn.ColumnName].MaxLength = 13; // JANコード
            band.Columns[table.BLGoodsCodeColumn.ColumnName].MaxLength = 5; // BLコード
            band.Columns[table.BLGoodsNameColumn.ColumnName].MaxLength = 20; // BLコード名
            band.Columns[table.EnterpriseGanreCodeColumn.ColumnName].MaxLength = 4; // 商品区分
            band.Columns[table.EnterpriseGanreNameColumn.ColumnName].MaxLength = 15; // 商品区分名
            band.Columns[table.GoodsRateRankColumn.ColumnName].MaxLength = 2; // 層別
            band.Columns[table.GoodsMGroupColumn.ColumnName].MaxLength = 4; // 商品中分類
            band.Columns[table.GoodsMGroupNameColumn.ColumnName].MaxLength = 20; // 商品中分類名
            band.Columns[table.BLGroupCodeColumn.ColumnName].MaxLength = 5; // グループコード
            band.Columns[table.BLGroupNameColumn.ColumnName].MaxLength = 20; // グループコード名
            band.Columns[table.PriceStartDate1Column.ColumnName].MaxLength = 8; // 価格開始日1
            band.Columns[table.ListPrice1Column.ColumnName].MaxLength = 7; // 価格1
            band.Columns[table.StockRate1Column.ColumnName].MaxLength = 6; // 仕入率1
            band.Columns[table.SalesUnitCost1Column.ColumnName].MaxLength = 10; // 原単価1
            band.Columns[table.PriceStartDate2Column.ColumnName].MaxLength = 8; // 価格開始日2
            band.Columns[table.ListPrice2Column.ColumnName].MaxLength = 7; // 価格2
            band.Columns[table.StockRate2Column.ColumnName].MaxLength = 6; // 仕入率2
            band.Columns[table.SalesUnitCost2Column.ColumnName].MaxLength = 10; // 原単価2
            band.Columns[table.PriceStartDate3Column.ColumnName].MaxLength = 8; // 価格開始日3
            band.Columns[table.ListPrice3Column.ColumnName].MaxLength = 7; // 価格3
            band.Columns[table.StockRate3Column.ColumnName].MaxLength = 6; // 仕入率3
            band.Columns[table.SalesUnitCost3Column.ColumnName].MaxLength = 10; // 原単価3
            // --- ADD 2010/08/11 ---------->>>>>
            band.Columns[table.PriceStartDate4Column.ColumnName].MaxLength = 8; // 価格開始日4
            band.Columns[table.ListPrice4Column.ColumnName].MaxLength = 7; // 価格4
            band.Columns[table.StockRate4Column.ColumnName].MaxLength = 6; // 仕入率4
            band.Columns[table.SalesUnitCost4Column.ColumnName].MaxLength = 10; // 原単価4
            band.Columns[table.PriceStartDate5Column.ColumnName].MaxLength = 8; // 価格開始日5
            band.Columns[table.ListPrice5Column.ColumnName].MaxLength = 7; // 価格5
            band.Columns[table.StockRate5Column.ColumnName].MaxLength = 6; // 仕入率5
            band.Columns[table.SalesUnitCost5Column.ColumnName].MaxLength = 10; // 原単価5

            // --- ADD 2010/08/11 ----------<<<<<
            band.Columns[table.PriceFlColumn.ColumnName].MaxLength = 9; // ユーザー価格
            band.Columns[table.UpRateColumn.ColumnName].MaxLength = 6; // UP率
            band.Columns[table.WarehouseCodeColumn.ColumnName].MaxLength = 4; // 倉庫コード
            band.Columns[table.WarehouseNameColumn.ColumnName].MaxLength = 10; // 倉庫名
            // --- ADD 2009/03/10 -------------------------------->>>>>
            band.Columns[table.SectionCodeColumn.ColumnName].MaxLength = 2; // 管理拠点コード
            band.Columns[table.SectionGuideSnmColumn.ColumnName].MaxLength = 10; // 管理拠点名
            // --- ADD 2009/03/10 --------------------------------<<<<<
            band.Columns[table.WarehouseShelfNoColumn.ColumnName].MaxLength = 8; // 棚番
            band.Columns[table.DuplicationShelfNo1Column.ColumnName].MaxLength = 8; // 重複棚番1
            band.Columns[table.DuplicationShelfNo2Column.ColumnName].MaxLength = 8; // 重複棚番2
            band.Columns[table.PartsManagementDivide1Column.ColumnName].MaxLength = 1; // 管理区分1
            band.Columns[table.PartsManagementDivide2Column.ColumnName].MaxLength = 1; // 管理区分2
            band.Columns[table.StockSupplierCodeColumn.ColumnName].MaxLength = 6; // 発注先コード
            band.Columns[table.StockSupplierSnmColumn.ColumnName].MaxLength = 20; // 発注先名
            band.Columns[table.SalesOrderUnitColumn.ColumnName].MaxLength = 6; // 発注ロット
            band.Columns[table.MinimumStockCntColumn.ColumnName].MaxLength = 9; // 最低在庫数
            band.Columns[table.MaximumStockCntColumn.ColumnName].MaxLength = 9; // 最大在庫数
            band.Columns[table.SupplierStockColumn.ColumnName].MaxLength = 9; // 仕入在庫数
            band.Columns[table.ArrivalCntColumn.ColumnName].MaxLength = 9; // 入荷数
            band.Columns[table.ShipmentCntColumn.ColumnName].MaxLength = 9; // 出荷数
            band.Columns[table.AcpOdrCountColumn.ColumnName].MaxLength = 9; // 受注数
            band.Columns[table.MovingSupliStockColumn.ColumnName].MaxLength = 9; // 移動中仕入在庫数
            band.Columns[table.NowStockCntColumn.ColumnName].MaxLength = 9; // 現在庫数
            // --- ADD 2009/03/05 -------------------------------->>>>>
            band.Columns[table.StockUnitPriceRateColumn.ColumnName].MaxLength = 6;
            band.Columns[table.StockUnitPriceFlColumn.ColumnName].MaxLength = 9;
            // --- ADD 2009/03/05 --------------------------------<<<<<

            // 表示位置(horizon)
            band.Columns[table.RowNumberColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Right; // 行番号
            band.Columns[table.GoodsDeleteDateColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left; // 商品削除日
            band.Columns[table.StockDeleteDateColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left; // 在庫削除日
            band.Columns[table.GoodsNoColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left; // 品番
            band.Columns[table.GoodsNameColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left; // 品名
            band.Columns[table.GoodsMakerColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Right; // メーカーコード
            //band.Columns[table.GoodsMakerNameColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Right; // メーカー名称 // DEL 2009/02/03
            band.Columns[table.GoodsMakerNameColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left; // メーカー名称 // ADD 2009/02/03
            // --- DEL 2010/06/08 ---------->>>>>
            //band.Columns[table.GoodsNameKanaColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left; // 品名カナ
            // --- DEL 2010/06/08 ----------<<<<<
            band.Columns[table.JanColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left; // JANコード
            band.Columns[table.BLGoodsCodeColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Right; // BLコード
            band.Columns[table.BLGoodsNameColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left; // BLコード名
            band.Columns[table.EnterpriseGanreCodeColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Right; // 商品区分
            band.Columns[table.EnterpriseGanreNameColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left; // 商品区分名
            band.Columns[table.GoodsRateRankColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left; // 層別
            band.Columns[table.GoodsKindCodeColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left; // 商品属性
            band.Columns[table.TaxationDivCdColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left; // 課税区分
            band.Columns[table.GoodsMGroupColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Right; // 商品中分類
            band.Columns[table.GoodsMGroupNameColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left; // 商品中分類名
            band.Columns[table.BLGroupCodeColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Right; // グループコード
            band.Columns[table.BLGroupNameColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left; // グループコード名
            band.Columns[table.PriceStartDate1Column.ColumnName].CellAppearance.TextHAlign = HAlign.Right; // 価格開始日1
            band.Columns[table.ListPrice1Column.ColumnName].CellAppearance.TextHAlign = HAlign.Right; // 価格1
            band.Columns[table.OpenPriceDiv1Column.ColumnName].CellAppearance.TextHAlign = HAlign.Left; // オープン価格区分1
            band.Columns[table.StockRate1Column.ColumnName].CellAppearance.TextHAlign = HAlign.Right; // 仕入率1
            band.Columns[table.SalesUnitCost1Column.ColumnName].CellAppearance.TextHAlign = HAlign.Right; // 原単価1
            band.Columns[table.PriceStartDate2Column.ColumnName].CellAppearance.TextHAlign = HAlign.Right; // 価格開始日2
            band.Columns[table.ListPrice2Column.ColumnName].CellAppearance.TextHAlign = HAlign.Right; // 価格2
            band.Columns[table.OpenPriceDiv2Column.ColumnName].CellAppearance.TextHAlign = HAlign.Left; // オープン価格区分2
            band.Columns[table.StockRate2Column.ColumnName].CellAppearance.TextHAlign = HAlign.Right; // 仕入率2
            band.Columns[table.SalesUnitCost2Column.ColumnName].CellAppearance.TextHAlign = HAlign.Right; // 原単価2
            band.Columns[table.PriceStartDate3Column.ColumnName].CellAppearance.TextHAlign = HAlign.Right; // 価格開始日3
            band.Columns[table.ListPrice3Column.ColumnName].CellAppearance.TextHAlign = HAlign.Right; // 価格3
            band.Columns[table.OpenPriceDiv3Column.ColumnName].CellAppearance.TextHAlign = HAlign.Left; // オープン価格区分3
            band.Columns[table.StockRate3Column.ColumnName].CellAppearance.TextHAlign = HAlign.Right; // 仕入率3
            band.Columns[table.SalesUnitCost3Column.ColumnName].CellAppearance.TextHAlign = HAlign.Right; // 原単価3
            // --- ADD 2010/08/11 ---------->>>>>
            band.Columns[table.PriceStartDate4Column.ColumnName].CellAppearance.TextHAlign = HAlign.Right; // 価格開始日4
            band.Columns[table.ListPrice4Column.ColumnName].CellAppearance.TextHAlign = HAlign.Right; // 価格4
            band.Columns[table.OpenPriceDiv4Column.ColumnName].CellAppearance.TextHAlign = HAlign.Left; // オープン価格区分4
            band.Columns[table.StockRate4Column.ColumnName].CellAppearance.TextHAlign = HAlign.Right; // 仕入率4
            band.Columns[table.SalesUnitCost4Column.ColumnName].CellAppearance.TextHAlign = HAlign.Right; // 原単価4
            band.Columns[table.PriceStartDate5Column.ColumnName].CellAppearance.TextHAlign = HAlign.Right; // 価格開始日5
            band.Columns[table.ListPrice5Column.ColumnName].CellAppearance.TextHAlign = HAlign.Right; // 価格5
            band.Columns[table.OpenPriceDiv5Column.ColumnName].CellAppearance.TextHAlign = HAlign.Left; // オープン価格区分5
            band.Columns[table.StockRate5Column.ColumnName].CellAppearance.TextHAlign = HAlign.Right; // 仕入率5
            band.Columns[table.SalesUnitCost5Column.ColumnName].CellAppearance.TextHAlign = HAlign.Right; // 原単価5
            // --- ADD 2010/08/11 ----------<<<<<
            band.Columns[table.PriceFlColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Right; // ユーザー価格
            band.Columns[table.UpRateColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Right; // UP率
            band.Columns[table.WarehouseCodeColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left; // 倉庫コード
            band.Columns[table.WarehouseNameColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left; // 倉庫名
            // --- ADD 2009/03/10 -------------------------------->>>>>
            band.Columns[table.SectionCodeColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left; // 管理拠点コード
            band.Columns[table.SectionGuideSnmColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left; // 管理拠点名
            // --- ADD 2009/03/10 --------------------------------<<<<<
            band.Columns[table.WarehouseShelfNoColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left; // 棚番
            band.Columns[table.DuplicationShelfNo1Column.ColumnName].CellAppearance.TextHAlign = HAlign.Left; // 重複棚番1
            band.Columns[table.DuplicationShelfNo2Column.ColumnName].CellAppearance.TextHAlign = HAlign.Left; // 重複棚番2
            band.Columns[table.PartsManagementDivide1Column.ColumnName].CellAppearance.TextHAlign = HAlign.Left; // 管理区分1
            band.Columns[table.PartsManagementDivide2Column.ColumnName].CellAppearance.TextHAlign = HAlign.Left; // 管理区分2
            band.Columns[table.StockSupplierCodeColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Right; // 発注先コード
            band.Columns[table.StockSupplierSnmColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left; // 発注先名
            band.Columns[table.StockDivColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left; // 在庫区分
            band.Columns[table.SalesOrderUnitColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Right; // 発注ロット
            band.Columns[table.MinimumStockCntColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Right; // 最低在庫数
            band.Columns[table.MaximumStockCntColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Right; // 最大在庫数
            band.Columns[table.SupplierStockColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Right; // 仕入在庫数
            band.Columns[table.ArrivalCntColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Right; // 入荷数
            band.Columns[table.ShipmentCntColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Right; // 出荷数
            band.Columns[table.AcpOdrCountColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Right; // 受注数
            band.Columns[table.MovingSupliStockColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Right; // 移動中仕入在庫数
            band.Columns[table.NowStockCntColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Right; // 現在庫数
            // --- ADD 2009/03/05 -------------------------------->>>>>
            band.Columns[table.StockUnitPriceRateColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Right;
            band.Columns[table.StockUnitPriceFlColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Right;
            // --- ADD 2009/03/05 --------------------------------<<<<<
            band.Columns[table.ErrorMessageColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left; // エラーメッセージ

            // リストボックス設定
            ValueList valueList = new ValueList();
            valueList.Appearance.BackColor = Color.FromArgb(247, 227, 156);

            // 商品属性
            valueList.ValueListItems.Clear();
            //valueList.ValueListItems.Add(0, "純正"); // DEL 2010/08/11
            //valueList.ValueListItems.Add(1, "その他"); // DEL 2010/08/11
            //band.Columns[table.GoodsKindCodeColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList; // DEL 2010/08/11
            valueList.ValueListItems.Add(0, "0:純正"); // ADD 2010/08/11
            valueList.ValueListItems.Add(1, "1:その他"); // ADD 2010/08/11
            band.Columns[table.GoodsKindCodeColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDown; // ADD 2010/08/11
            band.Columns[table.GoodsKindCodeColumn.ColumnName].ValueList = valueList.Clone();

            // 課税区分
            valueList.ValueListItems.Clear();
            //valueList.ValueListItems.Add(0, "外税"); // DEL 2010/08/11
            //valueList.ValueListItems.Add(1, "非課税"); // DEL 2010/08/11
            //band.Columns[table.TaxationDivCdColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList; // DEL 2010/08/11
            valueList.ValueListItems.Add(0, "0:外税");  // ADD 2010/08/11
            valueList.ValueListItems.Add(1, "1:非課税"); // ADD 2010/08/11
            band.Columns[table.TaxationDivCdColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDown; // ADD 2010/08/11
            band.Columns[table.TaxationDivCdColumn.ColumnName].ValueList = valueList.Clone();

            // オープン価格区分1
            valueList.ValueListItems.Clear();
            //valueList.ValueListItems.Add(0, "通常"); // DEL 2010/08/11
            //valueList.ValueListItems.Add(1, "オープン価格"); // DEL 2010/08/11
            //band.Columns[table.OpenPriceDiv1Column.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList; // DEL 2010/08/11
            valueList.ValueListItems.Add(0, "0:通常"); // ADD 2010/08/11
            valueList.ValueListItems.Add(1, "1:オープン価格"); // ADD 2010/08/11
            band.Columns[table.OpenPriceDiv1Column.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDown; // ADD 2010/08/11
            band.Columns[table.OpenPriceDiv1Column.ColumnName].ValueList = valueList.Clone();

            // オープン価格区分2
            valueList.ValueListItems.Clear();
            //valueList.ValueListItems.Add(0, "通常"); // DEL 2010/08/11
            //valueList.ValueListItems.Add(1, "オープン価格"); // DEL 2010/08/11
            //band.Columns[table.OpenPriceDiv2Column.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList; // DEL 2010/08/11
            valueList.ValueListItems.Add(0, "0:通常"); // ADD 2010/08/11
            valueList.ValueListItems.Add(1, "1:オープン価格"); // ADD 2010/08/11
            band.Columns[table.OpenPriceDiv2Column.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDown; // ADD 2010/08/11
            band.Columns[table.OpenPriceDiv2Column.ColumnName].ValueList = valueList.Clone();

            // オープン価格区分3
            valueList.ValueListItems.Clear();
            //valueList.ValueListItems.Add(0, "通常"); // DEL 2010/08/11
            //valueList.ValueListItems.Add(1, "オープン価格"); // DEL 2010/08/11
            //band.Columns[table.OpenPriceDiv3Column.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList; // DEL 2010/08/11
            valueList.ValueListItems.Add(0, "0:通常"); // ADD 2010/08/11
            valueList.ValueListItems.Add(1, "1:オープン価格"); // ADD 2010/08/11
            band.Columns[table.OpenPriceDiv3Column.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDown; // ADD 2010/08/11
            band.Columns[table.OpenPriceDiv3Column.ColumnName].ValueList = valueList.Clone();

            // --- ADD 2010/08/11 ---------->>>>>
            // オープン価格区分4
            valueList.ValueListItems.Clear();
            valueList.ValueListItems.Add(0, "0:通常");
            valueList.ValueListItems.Add(1, "1:オープン価格");
            band.Columns[table.OpenPriceDiv4Column.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDown;
            band.Columns[table.OpenPriceDiv4Column.ColumnName].ValueList = valueList.Clone();

            // オープン価格区分5
            valueList.ValueListItems.Clear();
            valueList.ValueListItems.Add(0, "0:通常");
            valueList.ValueListItems.Add(1, "1:オープン価格");
            band.Columns[table.OpenPriceDiv5Column.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDown;
            band.Columns[table.OpenPriceDiv5Column.ColumnName].ValueList = valueList.Clone();

            // --- ADD 2010/08/11 ----------<<<<<

            // 在庫区分
            valueList.ValueListItems.Clear();
            //valueList.ValueListItems.Add(0, "自社"); // DEL 2010/08/11
            //valueList.ValueListItems.Add(1, "受託"); // DEL 2010/08/11
            //band.Columns[table.StockDivColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList; // DEL 2010/08/11
            valueList.ValueListItems.Add(0, "0:自社"); // ADD 2010/08/11
            valueList.ValueListItems.Add(1, "1:受託"); // ADD 2010/08/11
            band.Columns[table.StockDivColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDown; // ADD 2010/08/11
            band.Columns[table.StockDivColumn.ColumnName].ValueList = valueList.Clone();

            // フォーマット設定
            string deleteDateFormat = "yy/MM/dd"; // 削除日付
            string intCommaFormat = "#,##0"; // コンマ付き整数フォーマット
            string decCommaFormat = "#,##0.00"; // コンマ付き小数点2位フォーマット
            string decNoCommaFormat = "0.00"; // コンマ無し小数点2位フォーマット

            band.Columns[table.GoodsDeleteDateColumn.ColumnName].Format = deleteDateFormat;	// 商品削除日
            band.Columns[table.StockDeleteDateColumn.ColumnName].Format = deleteDateFormat;	// 在庫削除日
            band.Columns[table.GoodsMakerColumn.ColumnName].Format = "0000"; // メーカーコード
            band.Columns[table.BLGoodsCodeColumn.ColumnName].Format = "00000"; // BLコード
            band.Columns[table.EnterpriseGanreCodeColumn.ColumnName].Format = "0000"; // 商品区分
            band.Columns[table.GoodsMGroupColumn.ColumnName].Format = "0000"; // 商品中分類
            band.Columns[table.BLGroupCodeColumn.ColumnName].Format = "00000"; // グループコード
            band.Columns[table.ListPrice1Column.ColumnName].Format = intCommaFormat; // 価格1
            band.Columns[table.StockRate1Column.ColumnName].Format = decNoCommaFormat; // 仕入率1
            band.Columns[table.SalesUnitCost1Column.ColumnName].Format = decCommaFormat; // 原単価1
            band.Columns[table.ListPrice2Column.ColumnName].Format = intCommaFormat; // 価格2
            band.Columns[table.StockRate2Column.ColumnName].Format = decNoCommaFormat; // 仕入率2
            band.Columns[table.SalesUnitCost2Column.ColumnName].Format = decCommaFormat; // 原単価2
            band.Columns[table.ListPrice3Column.ColumnName].Format = intCommaFormat; // 価格3
            band.Columns[table.StockRate3Column.ColumnName].Format = decNoCommaFormat; // 仕入率3
            band.Columns[table.SalesUnitCost3Column.ColumnName].Format = decCommaFormat; // 原単価3
            // --- ADD 2010/08/11 ---------->>>>>
            band.Columns[table.ListPrice4Column.ColumnName].Format = intCommaFormat; // 価格4
            band.Columns[table.StockRate4Column.ColumnName].Format = decNoCommaFormat; // 仕入率4
            band.Columns[table.SalesUnitCost4Column.ColumnName].Format = decCommaFormat; // 原単価4
            band.Columns[table.ListPrice5Column.ColumnName].Format = intCommaFormat; // 価格5
            band.Columns[table.StockRate5Column.ColumnName].Format = decNoCommaFormat; // 仕入率5
            band.Columns[table.SalesUnitCost5Column.ColumnName].Format = decCommaFormat; // 原単価5

            // --- ADD 2010/08/11 ----------<<<<<
            band.Columns[table.PriceFlColumn.ColumnName].Format = intCommaFormat; // ユーザー価格
            band.Columns[table.UpRateColumn.ColumnName].Format = decNoCommaFormat; // UP率
            band.Columns[table.WarehouseCodeColumn.ColumnName].Format = "0000"; // 倉庫コード
            band.Columns[table.SectionCodeColumn.ColumnName].Format = "00"; // 管理拠点コード // ADD 2009/03/10
            band.Columns[table.StockSupplierCodeColumn.ColumnName].Format = "000000";
            band.Columns[table.SalesOrderUnitColumn.ColumnName].Format = intCommaFormat; // 発注ロット
            band.Columns[table.MinimumStockCntColumn.ColumnName].Format = decCommaFormat; // 最低在庫数
            band.Columns[table.MaximumStockCntColumn.ColumnName].Format = decCommaFormat; // 最大在庫数
            band.Columns[table.SupplierStockColumn.ColumnName].Format = decCommaFormat; // 仕入在庫数
            band.Columns[table.ArrivalCntColumn.ColumnName].Format = decCommaFormat; // 入荷数
            band.Columns[table.ShipmentCntColumn.ColumnName].Format = decCommaFormat; // 出荷数
            band.Columns[table.AcpOdrCountColumn.ColumnName].Format = decCommaFormat; // 受注数
            band.Columns[table.MovingSupliStockColumn.ColumnName].Format = decCommaFormat; // 移動中仕入在庫数
            band.Columns[table.NowStockCntColumn.ColumnName].Format = decCommaFormat; // 現在庫数
            // --- ADD 2009/03/05 -------------------------------->>>>>
            band.Columns[table.StockUnitPriceRateColumn.ColumnName].Format = decCommaFormat;
            band.Columns[table.StockUnitPriceFlColumn.ColumnName].Format = decCommaFormat;
            // --- ADD 2009/03/05 --------------------------------<<<<<

            // セルの結合
            List<string> mergedColumnList = new List<string>();
            mergedColumnList.Add(table.GoodsDeleteDateColumn.ColumnName);
            mergedColumnList.Add(table.GoodsNoColumn.ColumnName);
            mergedColumnList.Add(table.GoodsNameColumn.ColumnName);
            mergedColumnList.Add(table.GoodsMakerColumn.ColumnName);
            mergedColumnList.Add(table.GoodsMakerNameColumn.ColumnName);
            // --- DEL 2010/06/08 ---------->>>>>
            //mergedColumnList.Add(table.GoodsNameKanaColumn.ColumnName);
            // --- DEL 2010/06/08 ----------<<<<<
            mergedColumnList.Add(table.JanColumn.ColumnName);
            mergedColumnList.Add(table.BLGoodsCodeColumn.ColumnName);
            mergedColumnList.Add(table.BLGoodsNameColumn.ColumnName);
            mergedColumnList.Add(table.EnterpriseGanreCodeColumn.ColumnName);
            mergedColumnList.Add(table.EnterpriseGanreNameColumn.ColumnName);
            mergedColumnList.Add(table.GoodsRateRankColumn.ColumnName);
            mergedColumnList.Add(table.GoodsKindCodeColumn.ColumnName);
            mergedColumnList.Add(table.TaxationDivCdColumn.ColumnName);
            mergedColumnList.Add(table.GoodsMGroupColumn.ColumnName);
            mergedColumnList.Add(table.GoodsMGroupNameColumn.ColumnName);
            mergedColumnList.Add(table.BLGroupCodeColumn.ColumnName);
            mergedColumnList.Add(table.BLGroupNameColumn.ColumnName);
            mergedColumnList.Add(table.PriceStartDate1Column.ColumnName);
            mergedColumnList.Add(table.ListPrice1Column.ColumnName);
            mergedColumnList.Add(table.OpenPriceDiv1Column.ColumnName);
            mergedColumnList.Add(table.StockRate1Column.ColumnName);
            mergedColumnList.Add(table.SalesUnitCost1Column.ColumnName);
            mergedColumnList.Add(table.PriceStartDate2Column.ColumnName);
            mergedColumnList.Add(table.ListPrice2Column.ColumnName);
            mergedColumnList.Add(table.OpenPriceDiv2Column.ColumnName);
            mergedColumnList.Add(table.StockRate2Column.ColumnName);
            mergedColumnList.Add(table.SalesUnitCost2Column.ColumnName);
            mergedColumnList.Add(table.PriceStartDate3Column.ColumnName);
            mergedColumnList.Add(table.ListPrice3Column.ColumnName);
            mergedColumnList.Add(table.OpenPriceDiv3Column.ColumnName);
            mergedColumnList.Add(table.StockRate3Column.ColumnName);
            mergedColumnList.Add(table.SalesUnitCost3Column.ColumnName);
            // --- ADD 2010/08/11 ---------->>>>>
            mergedColumnList.Add(table.PriceStartDate4Column.ColumnName);
            mergedColumnList.Add(table.ListPrice4Column.ColumnName);
            mergedColumnList.Add(table.OpenPriceDiv4Column.ColumnName);
            mergedColumnList.Add(table.StockRate4Column.ColumnName);
            mergedColumnList.Add(table.SalesUnitCost4Column.ColumnName);
            mergedColumnList.Add(table.PriceStartDate5Column.ColumnName);
            mergedColumnList.Add(table.ListPrice5Column.ColumnName);
            mergedColumnList.Add(table.OpenPriceDiv5Column.ColumnName);
            mergedColumnList.Add(table.StockRate5Column.ColumnName);
            mergedColumnList.Add(table.SalesUnitCost5Column.ColumnName);

            // --- ADD 2010/08/11 ----------<<<<<
            mergedColumnList.Add(table.PriceFlColumn.ColumnName);
            mergedColumnList.Add(table.UpRateColumn.ColumnName);

            foreach (string key in mergedColumnList)
            {
                band.Columns[key].MergedCellStyle = MergedCellStyle.Always;
                band.Columns[key].MergedCellContentArea = MergedCellContentArea.VisibleRect;
                band.Columns[key].MergedCellEvaluator = new CustomMergedCellEvaluatorGoods();
                band.Columns[key].MergedCellAppearance.BackGradientStyle = GradientStyle.None;
            }
        }

        /// <summary>
        /// グリッド列表示非表示設定
        /// </summary>
        /// <remarks>
        /// <br>UpdateNote       : 2010/06/08 高峰 障害・改良対応（７月リリース案件）</br>
        /// </remarks>
        private void SetGridColSetting()
        {
            ExtractInfo extractInfo = this.GetExtractInfo();

            Infragistics.Win.UltraWinGrid.UltraGridBand band = this.uGrid_Details.DisplayLayout.Bands[0];
            if (band == null) return;

            GoodsStockDataSet.GoodsStockDataTable table = this._goodsStockDataTable;

            #region ■ 入力可否設定
            // 品番、メーカー、倉庫は行ごとに入力可否を制御するため、ここでは設定しない

            // 品名列の設定
            if (extractInfo.TargetDiv == ExtractInfo.TargetDivState.Stock)
            {
                band.Columns[table.GoodsNameColumn.ColumnName].CellActivation = Activation.Disabled; // 品名
            }
            else
            {
                band.Columns[table.GoodsNameColumn.ColumnName].CellActivation = Activation.AllowEdit; // 品名
            }
            #endregion

            #region ■ 表示・非表示設定
            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn col in band.Columns)
            {
                // 全ての列をいったん非表示にする。
                col.Hidden = true;
            }
            
            if (
                (extractInfo.DisplayDiv == ExtractInfo.DisplayDivState.New
                && extractInfo.TargetDiv == ExtractInfo.TargetDivState.Goods) // 新規登録-商品
                ||
                (extractInfo.DisplayDiv == ExtractInfo.DisplayDivState.Update
                && extractInfo.TargetDiv == ExtractInfo.TargetDivState.Goods) // 修正登録-商品
                )
            {
                band.Columns[table.RowNumberColumn.ColumnName].Hidden = false;
                band.Columns[table.GoodsNoColumn.ColumnName].Hidden = false;
                band.Columns[table.GoodsNameColumn.ColumnName].Hidden = false;
                band.Columns[table.GoodsMakerColumn.ColumnName].Hidden = false;
                band.Columns[table.GoodsMakerNameColumn.ColumnName].Hidden = false;
                // --- DEL 2010/06/08 ---------->>>>>
                //band.Columns[table.GoodsNameKanaColumn.ColumnName].Hidden = false;
                // --- DEL 2010/06/08 ----------<<<<<
                band.Columns[table.JanColumn.ColumnName].Hidden = false;
                band.Columns[table.BLGoodsCodeColumn.ColumnName].Hidden = false;
                band.Columns[table.BLGoodsNameColumn.ColumnName].Hidden = false;
                band.Columns[table.EnterpriseGanreCodeColumn.ColumnName].Hidden = false;
                band.Columns[table.EnterpriseGanreNameColumn.ColumnName].Hidden = false;
                band.Columns[table.GoodsRateRankColumn.ColumnName].Hidden = false;
                band.Columns[table.GoodsKindCodeColumn.ColumnName].Hidden = false;
                band.Columns[table.TaxationDivCdColumn.ColumnName].Hidden = false;
                band.Columns[table.GoodsMGroupColumn.ColumnName].Hidden = false;
                band.Columns[table.GoodsMGroupNameColumn.ColumnName].Hidden = false;
                band.Columns[table.BLGroupCodeColumn.ColumnName].Hidden = false;
                band.Columns[table.BLGroupNameColumn.ColumnName].Hidden = false;


                band.Columns[table.PriceStartDate1Column.ColumnName].Hidden = false;
                band.Columns[table.ListPrice1Column.ColumnName].Hidden = false;
                band.Columns[table.OpenPriceDiv1Column.ColumnName].Hidden = false;
                band.Columns[table.StockRate1Column.ColumnName].Hidden = false;
                band.Columns[table.SalesUnitCost1Column.ColumnName].Hidden = false;

                if (this._goodsStockAcs.RateProtyMngExist)
                {
                    // 掛率優先管理情報があれば表示
                    band.Columns[table.PriceFlColumn.ColumnName].Hidden = false;
                    band.Columns[table.UpRateColumn.ColumnName].Hidden = false;
                }
            }
            else if (
                (extractInfo.DisplayDiv == ExtractInfo.DisplayDivState.New
                && extractInfo.TargetDiv == ExtractInfo.TargetDivState.Stock) // 新規登録-在庫
                ||
            (extractInfo.DisplayDiv == ExtractInfo.DisplayDivState.Update
                && extractInfo.TargetDiv == ExtractInfo.TargetDivState.Stock) // 修正登録-在庫
                )
            {
                band.Columns[table.RowNumberColumn.ColumnName].Hidden = false;
                band.Columns[table.GoodsNoColumn.ColumnName].Hidden = false;
                band.Columns[table.GoodsNameColumn.ColumnName].Hidden = false;

                // --- ADD 2009/03/10 -------------------------------->>>>>
                band.Columns[table.SectionCodeColumn.ColumnName].Hidden = false;
                band.Columns[table.SectionGuideSnmColumn.ColumnName].Hidden = false;
                // --- ADD 2009/03/10 --------------------------------<<<<<
                band.Columns[table.WarehouseShelfNoColumn.ColumnName].Hidden = false;
                band.Columns[table.DuplicationShelfNo1Column.ColumnName].Hidden = false;
                band.Columns[table.DuplicationShelfNo2Column.ColumnName].Hidden = false;
                band.Columns[table.PartsManagementDivide1Column.ColumnName].Hidden = false;
                band.Columns[table.PartsManagementDivide2Column.ColumnName].Hidden = false;
                band.Columns[table.StockSupplierCodeColumn.ColumnName].Hidden = false;
                band.Columns[table.StockSupplierSnmColumn.ColumnName].Hidden = false;
                band.Columns[table.StockDivColumn.ColumnName].Hidden = false;
                band.Columns[table.SalesOrderUnitColumn.ColumnName].Hidden = false;
                band.Columns[table.MinimumStockCntColumn.ColumnName].Hidden = false;
                band.Columns[table.MaximumStockCntColumn.ColumnName].Hidden = false;
                band.Columns[table.SupplierStockColumn.ColumnName].Hidden = false;
                band.Columns[table.ArrivalCntColumn.ColumnName].Hidden = false;
                band.Columns[table.ShipmentCntColumn.ColumnName].Hidden = false;
                band.Columns[table.AcpOdrCountColumn.ColumnName].Hidden = false;
                band.Columns[table.MovingSupliStockColumn.ColumnName].Hidden = false;
                band.Columns[table.NowStockCntColumn.ColumnName].Hidden = false;
                // --- ADD 2009/03/05 -------------------------------->>>>>
                band.Columns[table.StockUnitPriceRateColumn.ColumnName].Hidden = false;
                band.Columns[table.StockUnitPriceFlColumn.ColumnName].Hidden = false;
                // --- ADD 2009/03/05 --------------------------------<<<<<
            }
            else
            {
                // 修正登録-商品在庫、在庫商品
                band.Columns[table.RowNumberColumn.ColumnName].Hidden = false;
                band.Columns[table.GoodsNoColumn.ColumnName].Hidden = false;
                band.Columns[table.GoodsNameColumn.ColumnName].Hidden = false;
                band.Columns[table.GoodsMakerColumn.ColumnName].Hidden = false;
                band.Columns[table.GoodsMakerNameColumn.ColumnName].Hidden = false;

                // 商品情報
                // --- DEL 2010/06/08 ---------->>>>>
                //band.Columns[table.GoodsNameKanaColumn.ColumnName].Hidden = false;
                // --- DEL 2010/06/08 ----------<<<<<
                band.Columns[table.JanColumn.ColumnName].Hidden = false;
                band.Columns[table.BLGoodsCodeColumn.ColumnName].Hidden = false;
                band.Columns[table.BLGoodsNameColumn.ColumnName].Hidden = false;
                band.Columns[table.EnterpriseGanreCodeColumn.ColumnName].Hidden = false;
                band.Columns[table.EnterpriseGanreNameColumn.ColumnName].Hidden = false;
                band.Columns[table.GoodsRateRankColumn.ColumnName].Hidden = false;
                band.Columns[table.GoodsKindCodeColumn.ColumnName].Hidden = false;
                band.Columns[table.TaxationDivCdColumn.ColumnName].Hidden = false;
                band.Columns[table.GoodsMGroupColumn.ColumnName].Hidden = false;
                band.Columns[table.GoodsMGroupNameColumn.ColumnName].Hidden = false;
                band.Columns[table.BLGroupCodeColumn.ColumnName].Hidden = false;
                band.Columns[table.BLGroupNameColumn.ColumnName].Hidden = false;

                band.Columns[table.PriceStartDate1Column.ColumnName].Hidden = false;
                band.Columns[table.ListPrice1Column.ColumnName].Hidden = false;
                band.Columns[table.OpenPriceDiv1Column.ColumnName].Hidden = false;
                band.Columns[table.StockRate1Column.ColumnName].Hidden = false;
                band.Columns[table.SalesUnitCost1Column.ColumnName].Hidden = false;

                if (this._goodsStockAcs.RateProtyMngExist)
                {
                    // 掛率優先管理情報があれば表示
                    band.Columns[table.PriceFlColumn.ColumnName].Hidden = false;
                    band.Columns[table.UpRateColumn.ColumnName].Hidden = false;
                }

                // 在庫情報
                band.Columns[table.WarehouseCodeColumn.ColumnName].Hidden = false;
                band.Columns[table.WarehouseNameColumn.ColumnName].Hidden = false;
                // --- ADD 2009/03/10 -------------------------------->>>>>
                band.Columns[table.SectionCodeColumn.ColumnName].Hidden = false;
                band.Columns[table.SectionGuideSnmColumn.ColumnName].Hidden = false;
                // --- ADD 2009/03/10 --------------------------------<<<<<
                band.Columns[table.WarehouseShelfNoColumn.ColumnName].Hidden = false;
                band.Columns[table.DuplicationShelfNo1Column.ColumnName].Hidden = false;
                band.Columns[table.DuplicationShelfNo2Column.ColumnName].Hidden = false;
                band.Columns[table.PartsManagementDivide1Column.ColumnName].Hidden = false;
                band.Columns[table.PartsManagementDivide2Column.ColumnName].Hidden = false;
                band.Columns[table.StockSupplierCodeColumn.ColumnName].Hidden = false;
                band.Columns[table.StockSupplierSnmColumn.ColumnName].Hidden = false;
                band.Columns[table.StockDivColumn.ColumnName].Hidden = false;
                band.Columns[table.SalesOrderUnitColumn.ColumnName].Hidden = false;
                band.Columns[table.MinimumStockCntColumn.ColumnName].Hidden = false;
                band.Columns[table.MaximumStockCntColumn.ColumnName].Hidden = false;
                band.Columns[table.SupplierStockColumn.ColumnName].Hidden = false;
                band.Columns[table.ArrivalCntColumn.ColumnName].Hidden = false;
                band.Columns[table.ShipmentCntColumn.ColumnName].Hidden = false;
                band.Columns[table.AcpOdrCountColumn.ColumnName].Hidden = false;
                band.Columns[table.MovingSupliStockColumn.ColumnName].Hidden = false;
                band.Columns[table.NowStockCntColumn.ColumnName].Hidden = false;
                // --- ADD 2009/03/05 -------------------------------->>>>>
                band.Columns[table.StockUnitPriceRateColumn.ColumnName].Hidden = false;
                band.Columns[table.StockUnitPriceFlColumn.ColumnName].Hidden = false;
                // --- ADD 2009/03/05 --------------------------------<<<<<
            }

            #endregion

            // --- ADD 2009/02/23 -------------------------------->>>>>
            #region クリック時動作制御
            if (extractInfo.DisplayDiv == ExtractInfo.DisplayDivState.New
                && extractInfo.TargetDiv == ExtractInfo.TargetDivState.Goods)
            {
                band.Columns[table.GoodsNoColumn.ColumnName].CellClickAction = CellClickAction.Edit;
                band.Columns[table.GoodsMakerColumn.ColumnName].CellClickAction = CellClickAction.Edit;
            }
            else
            {
                // 品番、メーカーが選択不可なので行セレクト
                band.Columns[table.GoodsNoColumn.ColumnName].CellClickAction = CellClickAction.RowSelect;
                band.Columns[table.GoodsMakerColumn.ColumnName].CellClickAction = CellClickAction.RowSelect;
            }

            if (extractInfo.DisplayDiv == ExtractInfo.DisplayDivState.Update
                && extractInfo.TargetDiv == ExtractInfo.TargetDivState.GoodsStock)
            {
                band.Columns[table.WarehouseCodeColumn.ColumnName].CellClickAction = CellClickAction.Edit;
            }
            else
            {
                // 倉庫が選択不可なので行セレクト
                band.Columns[table.WarehouseCodeColumn.ColumnName].CellClickAction = CellClickAction.RowSelect;
            }
            #endregion
            // --- ADD 2009/02/23 --------------------------------<<<<<
        }

        /// <summary>
        /// 明細グリッド設定処理
        /// </summary>
        /// <remarks>
        /// <br>最新の抽出条件を参照する為、初期化時や検索実行時以外は使用不可</br>
        /// </remarks>
        internal void SetGridSettings()
        {
            try
            {
                // 描画を一時停止
                this.uGrid_Details.BeginUpdate();

                this.tToolbarsManager_Main.Enabled = true;

                // ボタン表示、非表示設定処理
                this.SetButtonEnableByExtactInfo();

                // グリッド列表示非表示設定処理
                this.SetGridColSetting();

                // グリッド背景色設定
                this.SetGridColorAll();
            }
            finally
            {
                // 描画を開始
                this.uGrid_Details.EndUpdate();
            }
        }
        #endregion

        #region ■ 背景色設定
        /// <summary>
        /// 各データの状態に応じた背景色を設定
        /// </summary>
        /// <remarks>
        /// <br>下記の優先順で色設定</br>
        /// <br>削除行：赤</br>
        /// <br>更新行：淡緑</br>
        /// <br>在庫登録されている商品：ピンク</br>
        /// </remarks>
        private void SetGridColorAll()
        {
            UltraGridRow dr;

            for (int i = 0; i < this.uGrid_Details.Rows.Count; i++)
            {
                dr = this.uGrid_Details.Rows[i];

                this.SetGridColorRow(dr);
            }
        }

        /// <summary>
        /// 各データの状態に応じた背景色を設定
        /// </summary>
        /// <remarks>
        /// <br>下記の優先順で色設定</br>
        /// <br>削除行：赤</br>
        /// <br>更新行：淡緑</br>
        /// <br>在庫登録されている商品：ピンク</br>
        /// </remarks>
        private void SetGridColorRow(UltraGridRow dr)
        {
            // 行番号セルの設定(更新エラー時のみ赤色)
            if ((int)dr.Cells[this._goodsStockDataTable.UpdateErrFlgColumn.ColumnName].Value == 0)
            {
                // 正常
                dr.Cells[this._goodsStockDataTable.RowNumberColumn.ColumnName].Appearance.BackColorDisabled = Color.FromArgb(89, 135, 214);
                dr.Cells[this._goodsStockDataTable.RowNumberColumn.ColumnName].Appearance.BackColorDisabled2 = Color.FromArgb(7, 59, 150);

                // --- ADD 2009/03/06 -------------------------------->>>>>
                // 削除予約行のみ色変更
                if (dr.Cells[this._goodsStockDataTable.RowNumberColumn.ColumnName].Value.ToString() != "新規"
                    &&
                    ((int)dr.Cells[this._goodsStockDataTable.GoodsLogicalDeleteFlgColumn.ColumnName].Value == 0
                    && (int)dr.Cells[this._goodsStockDataTable.StockLogicalDeleteFlgColumn.ColumnName].Value == 0))
                {
                    if (
                        ((int)dr.Cells[this._goodsStockDataTable.GoodsLogicalDeleteFlgColumn.ColumnName].Value == 0
                        && (int)dr.Cells[this._goodsStockDataTable.GoodsDeleteReserveFlgColumn.ColumnName].Value != 0)
                        ||
                        ((int)dr.Cells[this._goodsStockDataTable.StockDeleteReserveFlgColumn.ColumnName].Value != 0
                        && (int)dr.Cells[this._goodsStockDataTable.StockLogicalDeleteFlgColumn.ColumnName].Value == 0)
                        )
                    {
                        // 削除予約行はピンク
                        dr.Cells[this._goodsStockDataTable.RowNumberColumn.ColumnName].Appearance.BackColorDisabled = Color.Pink;
                        dr.Cells[this._goodsStockDataTable.RowNumberColumn.ColumnName].Appearance.BackColorDisabled2 = Color.Pink;
                    }
                }
                // --- ADD 2009/03/06 --------------------------------<<<<<
            }
            else
            {
                // 更新エラー
                dr.Cells[this._goodsStockDataTable.RowNumberColumn.ColumnName].Appearance.BackColorDisabled = Color.Red;
                dr.Cells[this._goodsStockDataTable.RowNumberColumn.ColumnName].Appearance.BackColorDisabled2 = Color.Red;
            }

            if (dr.Selected)
            {
                // 選択行の場合
                foreach (UltraGridCell cell in dr.Cells)
                {
                    if (cell.Column.Key != this._goodsStockDataTable.RowNumberColumn.ColumnName)
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
                if (dr.Index % 2 == 0)
                {
                    foreach (UltraGridCell cell in dr.Cells)
                    {
                        if (cell.Column.Key != this._goodsStockDataTable.RowNumberColumn.ColumnName)
                        {
                            cell.Appearance.BackColor = Color.White;
                            cell.Appearance.BackColor2 = Color.White;
                            cell.Appearance.BackColorDisabled = Color.White;
                            cell.Appearance.BackColorDisabled2 = Color.White;
                        }
                    }

                }
                else
                {
                    foreach (UltraGridCell cell in dr.Cells)
                    {
                        if (cell.Column.Key != this._goodsStockDataTable.RowNumberColumn.ColumnName)
                        {
                            cell.Appearance.BackColor = Color.Lavender;
                            cell.Appearance.BackColor2 = Color.Lavender;
                            cell.Appearance.BackColorDisabled = Color.Lavender;
                            cell.Appearance.BackColorDisabled2 = Color.Lavender;
                        }
                    }
                }

                // 追加行は対象外(通常色どおり)
                if (dr.Cells[this._goodsStockDataTable.RowNumberColumn.ColumnName].Value.ToString() == "新規")
                {
                    return;
                }

                // 論理削除行は対象外
                if ((int)dr.Cells[this._goodsStockDataTable.GoodsLogicalDeleteFlgColumn.ColumnName].Value != 0
                    || (int)dr.Cells[this._goodsStockDataTable.StockLogicalDeleteFlgColumn.ColumnName].Value != 0)
                {
                    return;
                }

                // 状態によって上書き
                //if (dr.Cells[this._goodsStockDataTable.GoodsDeleteDateColumn.ColumnName].Value != null
                //    && dr.Cells[this._goodsStockDataTable.GoodsDeleteDateColumn.ColumnName].Value != DBNull.Value
                //    && (int)dr.Cells[this._goodsStockDataTable.GoodsLogicalDeleteFlgColumn.ColumnName].Value == 0) // DEL 2009/02/05
                if ((int)dr.Cells[this._goodsStockDataTable.GoodsLogicalDeleteFlgColumn.ColumnName].Value == 0
                    && (int)dr.Cells[this._goodsStockDataTable.GoodsDeleteReserveFlgColumn.ColumnName].Value != 0) // ADD 2009/02/05
                {
                    // 商品削除予約行
                    foreach (UltraGridCell cell in dr.Cells)
                    {
                        //if (cell.Column.Key != this._goodsStockDataTable.RowNumberColumn.ColumnName) // DEL 2009/03/06
                        //{
                        // --- DEL 2009/03/06 -------------------------------->>>>>
                        //cell.Appearance.BackColor = Color.Red;
                        //cell.Appearance.BackColor2 = Color.Red;
                        //cell.Appearance.BackColorDisabled = Color.Red;
                        //cell.Appearance.BackColorDisabled2 = Color.Red;
                        // --- DEL 2009/03/06 --------------------------------<<<<<
                        // --- ADD 2009/03/06 -------------------------------->>>>>
                        cell.Appearance.BackColor = Color.Pink;
                        cell.Appearance.BackColor2 = Color.Pink;
                        cell.Appearance.BackColorDisabled = Color.Pink;
                        cell.Appearance.BackColorDisabled2 = Color.Pink;
                        // --- ADD 2009/03/06 --------------------------------<<<<<
                        //}
                    }

                    return;
                }
                //else if (dr.Cells[this._goodsStockDataTable.StockDeleteDateColumn.ColumnName].Value != null
                //    && dr.Cells[this._goodsStockDataTable.StockDeleteDateColumn.ColumnName].Value != DBNull.Value
                //    && (int)dr.Cells[this._goodsStockDataTable.StockLogicalDeleteFlgColumn.ColumnName].Value == 0) // DEL 2009/02/05
                else if ((int)dr.Cells[this._goodsStockDataTable.StockDeleteReserveFlgColumn.ColumnName].Value != 0
                    && (int)dr.Cells[this._goodsStockDataTable.StockLogicalDeleteFlgColumn.ColumnName].Value == 0) // ADD 2009/02/05
                {
                    // 在庫削除予約行
                    // 倉庫コード以降の背景色を変更
                    int warehouseColIndex = this.uGrid_Details.DisplayLayout.Bands[0]
                        .Columns[this._goodsStockDataTable.WarehouseCodeColumn.ColumnName].Index;

                    // --- ADD 2009/03/06 -------------------------------->>>>>
                    // 行番号も設定
                    dr.Cells[this._goodsStockDataTable.RowNumberColumn.ColumnName]
                        .Appearance.BackColor = Color.Pink;
                    dr.Cells[this._goodsStockDataTable.RowNumberColumn.ColumnName]
                        .Appearance.BackColor2 = Color.Pink;
                    dr.Cells[this._goodsStockDataTable.RowNumberColumn.ColumnName]
                        .Appearance.BackColorDisabled = Color.Pink;
                    dr.Cells[this._goodsStockDataTable.RowNumberColumn.ColumnName]
                        .Appearance.BackColorDisabled2 = Color.Pink;
                    // --- ADD 2009/03/06 --------------------------------<<<<<

                    // 在庫削除日も設定
                    // --- DEL 2009/03/06 -------------------------------->>>>>
                    //dr.Cells[this._goodsStockDataTable.StockDeleteDateColumn.ColumnName]
                    //    .Appearance.BackColor = Color.Red;
                    //dr.Cells[this._goodsStockDataTable.StockDeleteDateColumn.ColumnName]
                    //    .Appearance.BackColor2 = Color.Red;
                    //dr.Cells[this._goodsStockDataTable.StockDeleteDateColumn.ColumnName]
                    //    .Appearance.BackColorDisabled = Color.Red;
                    //dr.Cells[this._goodsStockDataTable.StockDeleteDateColumn.ColumnName]
                    //    .Appearance.BackColorDisabled2 = Color.Red;
                    // --- DEL 2009/03/06 --------------------------------<<<<<
                    // --- ADD 2009/03/06 -------------------------------->>>>>
                    dr.Cells[this._goodsStockDataTable.StockDeleteDateColumn.ColumnName]
                        .Appearance.BackColor = Color.Pink;
                    dr.Cells[this._goodsStockDataTable.StockDeleteDateColumn.ColumnName]
                        .Appearance.BackColor2 = Color.Pink;
                    dr.Cells[this._goodsStockDataTable.StockDeleteDateColumn.ColumnName]
                        .Appearance.BackColorDisabled = Color.Pink;
                    dr.Cells[this._goodsStockDataTable.StockDeleteDateColumn.ColumnName]
                        .Appearance.BackColorDisabled2 = Color.Pink;
                    // --- ADD 2009/03/06 --------------------------------<<<<<

                    if (this._beforeSearchExtractInfo.TargetDiv == ExtractInfo.TargetDivState.Stock)
                    {
                        // 対象区分「在庫」の場合、品番、品名も設定
                        // --- DEL 2009/03/06 -------------------------------->>>>>
                        //dr.Cells[this._goodsStockDataTable.GoodsNoColumn.ColumnName]
                        //.Appearance.BackColor = Color.Red;
                        //dr.Cells[this._goodsStockDataTable.GoodsNoColumn.ColumnName]
                        //    .Appearance.BackColor2 = Color.Red;
                        //dr.Cells[this._goodsStockDataTable.GoodsNoColumn.ColumnName]
                        //    .Appearance.BackColorDisabled = Color.Red;
                        //dr.Cells[this._goodsStockDataTable.GoodsNoColumn.ColumnName]
                        //    .Appearance.BackColorDisabled2 = Color.Red;

                        //dr.Cells[this._goodsStockDataTable.GoodsNameColumn.ColumnName]
                        //.Appearance.BackColor = Color.Red;
                        //dr.Cells[this._goodsStockDataTable.GoodsNameColumn.ColumnName]
                        //    .Appearance.BackColor2 = Color.Red;
                        //dr.Cells[this._goodsStockDataTable.GoodsNameColumn.ColumnName]
                        //    .Appearance.BackColorDisabled = Color.Red;
                        //dr.Cells[this._goodsStockDataTable.GoodsNameColumn.ColumnName]
                        //    .Appearance.BackColorDisabled2 = Color.Red;
                        // --- DEL 2009/03/06 --------------------------------<<<<<
                        // --- ADD 2009/03/06 -------------------------------->>>>>
                        dr.Cells[this._goodsStockDataTable.GoodsNoColumn.ColumnName]
                        .Appearance.BackColor = Color.Pink;
                        dr.Cells[this._goodsStockDataTable.GoodsNoColumn.ColumnName]
                            .Appearance.BackColor2 = Color.Pink;
                        dr.Cells[this._goodsStockDataTable.GoodsNoColumn.ColumnName]
                            .Appearance.BackColorDisabled = Color.Pink;
                        dr.Cells[this._goodsStockDataTable.GoodsNoColumn.ColumnName]
                            .Appearance.BackColorDisabled2 = Color.Pink;

                        dr.Cells[this._goodsStockDataTable.GoodsNameColumn.ColumnName]
                        .Appearance.BackColor = Color.Pink;
                        dr.Cells[this._goodsStockDataTable.GoodsNameColumn.ColumnName]
                            .Appearance.BackColor2 = Color.Pink;
                        dr.Cells[this._goodsStockDataTable.GoodsNameColumn.ColumnName]
                            .Appearance.BackColorDisabled = Color.Pink;
                        dr.Cells[this._goodsStockDataTable.GoodsNameColumn.ColumnName]
                            .Appearance.BackColorDisabled2 = Color.Pink;
                        // --- ADD 2009/03/06 --------------------------------<<<<<
                    }

                    for (int k = warehouseColIndex; k < this.uGrid_Details.DisplayLayout.Bands[0].Columns.Count; k++)
                    {
                        // --- DEL 2009/03/06 -------------------------------->>>>>
                        //dr.Cells[k].Appearance.BackColor = Color.Red;
                        //dr.Cells[k].Appearance.BackColor2 = Color.Red;
                        //dr.Cells[k].Appearance.BackColorDisabled = Color.Red;
                        //dr.Cells[k].Appearance.BackColorDisabled2 = Color.Red;
                        // --- DEL 2009/03/06 --------------------------------<<<<<
                        // --- ADD 2009/03/06 -------------------------------->>>>>
                        dr.Cells[k].Appearance.BackColor = Color.Pink;
                        dr.Cells[k].Appearance.BackColor2 = Color.Pink;
                        dr.Cells[k].Appearance.BackColorDisabled = Color.Pink;
                        dr.Cells[k].Appearance.BackColorDisabled2 = Color.Pink;
                        // --- ADD 2009/03/06 --------------------------------<<<<<
                    }
                }
                else
                {
                    if (dr.Cells[this._goodsStockDataTable.OriginalWarehouseCodeColumn.ColumnName].Value != null
                      && dr.Cells[this._goodsStockDataTable.OriginalWarehouseCodeColumn.ColumnName].Value != DBNull.Value)
                    {
                        if (this._beforeSearchExtractInfo.TargetDiv != ExtractInfo.TargetDivState.Stock) // ADD 2009/02/23
                        {
                            // 在庫保持行設定
                            int upRateColIndex = this.uGrid_Details.DisplayLayout.Bands[0]
                                .Columns[this._goodsStockDataTable.UpRateColumn.ColumnName].Index;

                            for (int m = 1; m <= upRateColIndex; m++)
                            {
                                // --- DEL 2009/03/06 -------------------------------->>>>>
                                //dr.Cells[m].Appearance.BackColor = Color.Pink;
                                //dr.Cells[m].Appearance.BackColor2 = Color.Pink;
                                //dr.Cells[m].Appearance.BackColorDisabled = Color.Pink;
                                //dr.Cells[m].Appearance.BackColorDisabled2 = Color.Pink;
                                // --- DEL 2009/03/06 --------------------------------<<<<<
                                // --- ADD 2009/03/06 -------------------------------->>>>>
                                dr.Cells[m].Appearance.BackColor = Color.Thistle;
                                dr.Cells[m].Appearance.BackColor2 = Color.Thistle;
                                dr.Cells[m].Appearance.BackColorDisabled = Color.Thistle;
                                dr.Cells[m].Appearance.BackColorDisabled2 = Color.Thistle;
                                // --- ADD 2009/03/06 --------------------------------<<<<<
                            }
                        }
                    }

                    // 更新セル設定
                    //DataRow originalDr = this._goodsStockAcs.OriginalGoodsStockDataTable
                    //    .Select(this._goodsStockDataTable.RowNumberColumn.ColumnName + " = '"
                    //    + dr.Cells[this._goodsStockDataTable.RowNumberColumn.ColumnName].Value.ToString() + "'")[0]; // DEL 2009/03/06
                    DataRow originalDr = this._goodsStockAcs.OriginalGoodsStockDataTable
                        .Select(this._goodsStockDataTable.RowIndexColumn.ColumnName + " = '"
                        + dr.Cells[this._goodsStockDataTable.RowIndexColumn.ColumnName].Value.ToString() + "'")[0]; // ADD 2009/03/06

                    for (int j = 0; j < this._goodsStockDataTable.Columns.Count; j++)
                    {
                        if (dr.Cells[j].Value.ToString() != originalDr[j].ToString())
                        {
                            // エラー内容行は除く
                            if (dr.Cells[j].Column.Key != this._goodsStockDataTable.ErrorMessageColumn.ColumnName) // ADD 2009/03/10
                            {
                                dr.Cells[j].Appearance.BackColor = Color.Lime;
                                dr.Cells[j].Appearance.BackColor2 = Color.Lime;
                                dr.Cells[j].Appearance.BackColorDisabled = Color.Lime;
                                dr.Cells[j].Appearance.BackColorDisabled2 = Color.Lime;
                            }
                        }
                    }
                }
            }
        }
        #endregion

        #region ■ ボタン表示制御
        /// <summary>
        /// ボタン表示非表示設定
        /// </summary>
        /// <remarks>
        /// <br>UpdateNote       : 2010/08/11 高峰 障害改良対応（８月分） キーボード操作の改良を行う。</br>
        /// </remarks>
        private void SetButtonEnableByExtactInfo()
        {
            ExtractInfo extractInfo = this.GetExtractInfo();

            if (extractInfo.DisplayDiv == ExtractInfo.DisplayDivState.New
                && extractInfo.TargetDiv == ExtractInfo.TargetDivState.Goods)
            {
                this.tToolbarsManager_Main.Toolbars[0].Tools["Container_GoodsAdd"].SharedProps.Visible = true;
                this.uButton_RowAdd.Enabled = true; // ADD 2009/02/04
                // --- UPD 2010/08/11 -------------------------------->>>>>
                //this.uButton_RowAdd.Text = "商品追加(&I)"; // ADD 2009/03/03
                this.uButton_RowAdd.Text = "商品追加(F11)";
                // --- UPD 2010/08/11 --------------------------------<<<<<
            }
            else if (extractInfo.DisplayDiv == ExtractInfo.DisplayDivState.Update
                && extractInfo.TargetDiv == ExtractInfo.TargetDivState.GoodsStock)
            {
                this.tToolbarsManager_Main.Toolbars[0].Tools["Container_GoodsAdd"].SharedProps.Visible = true;
                this.uButton_RowAdd.Enabled = false; // ADD 2009/02/04
                // --- UPD 2010/08/11 -------------------------------->>>>>
                //this.uButton_RowAdd.Text = "在庫追加(&I)"; // ADD 2009/03/03
                this.uButton_RowAdd.Text = "在庫追加(F11)";
                // --- UPD 2010/08/11 --------------------------------<<<<<
            }
            else
            {
                this.tToolbarsManager_Main.Toolbars[0].Tools["Container_GoodsAdd"].SharedProps.Visible = false;
            }

            // --- ADD 2009/03/03 -------------------------------->>>>>
            // 削除・復活ボタン名称
            if (extractInfo.DisplayDiv == ExtractInfo.DisplayDivState.New)
            {
                // --- UPD 2010/08/11 -------------------------------->>>>>
                //this.uButton_RowGoodsDelete.Text = "商品非表示(&D)";
                //this.uButton_RowStockDelete.Text = "在庫非表示(&A)";
                this.uButton_RowGoodsDelete.Text = "商品非表示(F3)";
                this.uButton_RowStockDelete.Text = "在庫非表示(F6)";
                // --- UPD 2010/08/11 --------------------------------<<<<<
            }
            else
            {
                // --- UPD 2010/08/11 -------------------------------->>>>>
                //this.uButton_RowGoodsDelete.Text = "商品削除(&D)";
                //this.uButton_RowStockDelete.Text = "在庫削除(&A)";
                this.uButton_RowGoodsDelete.Text = "商品削除(F3)";
                this.uButton_RowStockDelete.Text = "在庫削除(F6)";
                // --- UPD 2010/08/11 --------------------------------<<<<<
            }
            // --- ADD 2009/03/03 --------------------------------<<<<<
            // --- ADD 2009/02/04 -------------------------------->>>>>
            //if (extractInfo.TargetDiv == ExtractInfo.TargetDivState.Stock)
            //{
            //    this.uButton_RowDispPrice.Enabled = false;
            //}
            //else
            //{
            //    this.uButton_RowDispPrice.Enabled = true;
            //}
            // --- ADD 2009/02/04 --------------------------------<<<<<
        }

        /// <summary>
        /// 指定グリッド行の状態に応じたボタン押下可否制御を行う。
        /// </summary>
        /// <remarks>
        /// </remarks>
        //private void SetButtonEnableByRow(int rowIndex, string columnKey) // DEL 2009/02/23
        private void SetButtonEnableByCell(int rowIndex, string columnKey) // ADD 2009/02/23
        {
            #region 削除、復活ボタン制御
            bool isGoodsLogicalDelete; // 商品が論理削除済みか
            bool isGoodsReserveDelete; // 商品が削除予約か
            bool isStockLogicalDelete; // 在庫が論理削除済みか
            bool isStockReserveDelete; // 在庫が削除予約か

            // 指定行の状態取得
            // 商品は論理削除状態か
            if ((int)this.uGrid_Details.Rows[rowIndex].Cells[this._goodsStockDataTable.GoodsLogicalDeleteFlgColumn.ColumnName].Value == 0)
            {
                isGoodsLogicalDelete = false;
            }
            else
            {
                isGoodsLogicalDelete = true;
            }

            // 商品は削除予約状態か
            //if (this.uGrid_Details.Rows[rowIndex].Cells[this._goodsStockDataTable.GoodsDeleteDateColumn.ColumnName].Value == null
            //    || this.uGrid_Details.Rows[rowIndex].Cells[this._goodsStockDataTable.GoodsDeleteDateColumn.ColumnName].Value == DBNull.Value) // DEL 2009/02/05
            if ((int)this.uGrid_Details.Rows[rowIndex].Cells[this._goodsStockDataTable.GoodsDeleteReserveFlgColumn.ColumnName].Value == 0) // ADD 2009/02/05
            {
                isGoodsReserveDelete = false;
            }
            else
            {
                isGoodsReserveDelete = true;
            }

            // 在庫自体が無い場合もあるため、要Nullチェック
            // 在庫は論理削除状態か
            if (this.uGrid_Details.Rows[rowIndex].Cells[this._goodsStockDataTable.StockLogicalDeleteFlgColumn.ColumnName].Value == null
                || this.uGrid_Details.Rows[rowIndex].Cells[this._goodsStockDataTable.StockLogicalDeleteFlgColumn.ColumnName].Value == DBNull.Value
                || (int)this.uGrid_Details.Rows[rowIndex].Cells[this._goodsStockDataTable.StockLogicalDeleteFlgColumn.ColumnName].Value == 0)
            {
                isStockLogicalDelete = false;
            }
            else
            {
                isStockLogicalDelete = true;
            }

            // 在庫は削除予約状態か
            //if (this.uGrid_Details.Rows[rowIndex].Cells[this._goodsStockDataTable.StockDeleteDateColumn.ColumnName].Value == null
            //    || this.uGrid_Details.Rows[rowIndex].Cells[this._goodsStockDataTable.StockDeleteDateColumn.ColumnName].Value == DBNull.Value) // DEL 2009/02/05
            if ((int)this.uGrid_Details.Rows[rowIndex].Cells[this._goodsStockDataTable.StockDeleteReserveFlgColumn.ColumnName].Value == 0) // ADD 2009/02/05
            {
                isStockReserveDelete = false;
            }
            else
            {
                isStockReserveDelete = true;
            }

            // --- ADD 2009/02/23 -------------------------------->>>>>
            if (isGoodsLogicalDelete) this._includeGoodsLogicalDeleted = true;
            else this._includeGoodsLogicalDeleted = false;

            if (isStockLogicalDelete) this._includeStockLogicalDeleted = true;
            else this._includeStockLogicalDeleted = false;
            // --- ADD 2009/02/23 --------------------------------<<<<<


            // 削除・復活ボタン
            if (this._beforeSearchExtractInfo.DisplayDiv == ExtractInfo.DisplayDivState.New)
            {
                // 新規登録
                if (this._beforeSearchExtractInfo.TargetDiv == ExtractInfo.TargetDivState.Goods) // 商品
                {
                    // 在庫ボタン不可
                    this.uButton_RowStockDelete.Enabled = false;
                    this.uButton_RowStockRevive.Enabled = false;

                    if (isGoodsReserveDelete)
                    {
                        // 削除予約行なので、削除押下不可
                        this.uButton_RowGoodsDelete.Enabled = false;
                        this.uButton_RowGoodsRevive.Enabled = true;
                    }
                    else
                    {
                        // 削除予約可能、復活不可
                        this.uButton_RowGoodsDelete.Enabled = true;
                        this.uButton_RowGoodsRevive.Enabled = false;
                    }
                }
                else if (this._beforeSearchExtractInfo.TargetDiv == ExtractInfo.TargetDivState.Stock) // 在庫
                {
                    // 商品ボタン不可
                    this.uButton_RowGoodsDelete.Enabled = false;
                    this.uButton_RowGoodsRevive.Enabled = false;

                    if (isStockReserveDelete)
                    {
                        // 削除予約行なので、削除押下不可
                        this.uButton_RowStockDelete.Enabled = false;
                        this.uButton_RowStockRevive.Enabled = true;
                    }
                    else
                    {
                        // 削除予約可能、復活不可
                        this.uButton_RowStockDelete.Enabled = true;
                        this.uButton_RowStockRevive.Enabled = false;
                    }
                }
            }
            else
            {
                // 修正登録
                if (this._beforeSearchExtractInfo.TargetDiv == ExtractInfo.TargetDivState.Goods) // 商品
                {
                    // 在庫ボタン不可
                    this.uButton_RowStockDelete.Enabled = false;
                    this.uButton_RowStockRevive.Enabled = false;

                    if (isGoodsLogicalDelete)
                    {
                        // 論理削除行の場合、削除、復活可能
                        this.uButton_RowGoodsDelete.Enabled = true;
                        this.uButton_RowGoodsRevive.Enabled = true;
                    }
                    else if (isGoodsReserveDelete)
                    {
                        // 削除予約行の場合、削除不可、復活可能
                        this.uButton_RowGoodsDelete.Enabled = false;
                        this.uButton_RowGoodsRevive.Enabled = true;
                    }
                    else
                    {
                        this.uButton_RowGoodsDelete.Enabled = true;
                        this.uButton_RowGoodsRevive.Enabled = false;
                    }
                }
                else if (this._beforeSearchExtractInfo.TargetDiv == ExtractInfo.TargetDivState.Stock
                    || this._beforeSearchExtractInfo.TargetDiv == ExtractInfo.TargetDivState.StockGoods) // 在庫と在庫商品
                {
                    // 商品ボタン不可
                    this.uButton_RowGoodsDelete.Enabled = false;
                    this.uButton_RowGoodsRevive.Enabled = false;

                    if (isStockLogicalDelete)
                    {
                        // 論理削除行の場合、削除、復活可能
                        this.uButton_RowStockDelete.Enabled = true;
                        this.uButton_RowStockRevive.Enabled = true;
                    }
                    else if (isStockReserveDelete)
                    {
                        // 削除予約行の場合、削除不可、復活可能
                        this.uButton_RowStockDelete.Enabled = false;
                        this.uButton_RowStockRevive.Enabled = true;
                    }
                    else
                    {
                        this.uButton_RowStockDelete.Enabled = true;
                        this.uButton_RowStockRevive.Enabled = false;
                    }
                }
                else if (this._beforeSearchExtractInfo.TargetDiv == ExtractInfo.TargetDivState.GoodsStock) // 商品在庫
                {
                    // 商品ボタン
                    if (isGoodsLogicalDelete)
                    {
                        // 論理削除行の場合、削除、復活可能
                        this.uButton_RowGoodsDelete.Enabled = true;
                        this.uButton_RowGoodsRevive.Enabled = true;
                        this.uButton_RowStockDelete.Enabled = false;
                        this.uButton_RowStockRevive.Enabled = false;
                    }
                    else if (isGoodsReserveDelete)
                    {
                        // 削除予約行の場合、削除不可、復活可能
                        this.uButton_RowGoodsDelete.Enabled = false;
                        this.uButton_RowGoodsRevive.Enabled = true;
                        this.uButton_RowStockDelete.Enabled = false;
                        this.uButton_RowStockRevive.Enabled = false;
                    }
                    else
                    {
                        this.uButton_RowGoodsDelete.Enabled = true;
                        this.uButton_RowGoodsRevive.Enabled = false;

                        // 在庫ボタン
                        if (isStockLogicalDelete)
                        {
                            // 論理削除行の場合、削除、復活可能
                            this.uButton_RowStockDelete.Enabled = true;
                            this.uButton_RowStockRevive.Enabled = true;
                        }
                        else if (isStockReserveDelete)
                        {
                            // 削除予約行の場合、削除不可、復活可能
                            this.uButton_RowStockDelete.Enabled = false;
                            this.uButton_RowStockRevive.Enabled = true;
                        }
                        else
                        {
                            this.uButton_RowStockDelete.Enabled = true;
                            this.uButton_RowStockRevive.Enabled = false;
                        }
                    }
                }

                if (this.uGrid_Details.Rows[rowIndex].Cells[this._goodsStockDataTable.OriginalWarehouseCodeColumn.ColumnName].Value == null
                || this.uGrid_Details.Rows[rowIndex].Cells[this._goodsStockDataTable.OriginalWarehouseCodeColumn.ColumnName].Value == DBNull.Value)
                {
                    //if (this.uGrid_Details.Rows[rowIndex].Cells[this._goodsStockDataTable.RowNumberColumn.ColumnName].Value.ToString() != "新規") // DEL 2009/03/06
                    if (this.uGrid_Details.Rows[rowIndex].Cells[this._goodsStockDataTable.RowIndexColumn.ColumnName].Value.ToString() != "新規") // ADD 2009/03/06
                    {
                        // 修正登録で在庫がなければ在庫ボタン押下不可
                        // (商品在庫で、既存の在庫なし商品は在庫削除不可)
                        this.uButton_RowStockDelete.Enabled = false;
                        this.uButton_RowStockRevive.Enabled = false;
                    }
                }
            }

            #endregion

            #region ガイドボタン制御

            // ガイドボタン設定
            switch (columnKey)
            {
                case "GoodsMaker":
                case "BLGoodsCode":
                case "EnterpriseGanreCode":
                case "WarehouseCode":
                case "PartsManagementDivide1":
                case "PartsManagementDivide2":
                case "StockSupplierCode":
                    {
                        //this.uButton_RowExcuteGuide.Enabled = true; // DEL 2010/08/11
                        this.SetGuide(true); // ADD 2010/08/11
                        break;
                    }
                default:
                    {
                        //this.uButton_RowExcuteGuide.Enabled = false; // DEL 2010/08/11
                        this.SetGuide(false); // ADD 2010/08/11
                        break;
                    }
            }

            #endregion

            #region 商品追加ボタン
            if (this._beforeSearchExtractInfo.DisplayDiv == ExtractInfo.DisplayDivState.New
                && this._beforeSearchExtractInfo.TargetDiv == ExtractInfo.TargetDivState.Goods)
            {
                this.uButton_RowAdd.Enabled = true;
            }
            else if (this._beforeSearchExtractInfo.TargetDiv == ExtractInfo.TargetDivState.GoodsStock)
            {
                // --- DEL 2009/02/23 -------------------------------->>>>>
                //if (this.uGrid_Details.Rows[rowIndex].Cells[this._goodsStockDataTable.WarehouseCodeColumn.ColumnName].Value == null
                //    || this.uGrid_Details.Rows[rowIndex].Cells[this._goodsStockDataTable.WarehouseCodeColumn.ColumnName].Value == DBNull.Value)
                //{
                //    // 在庫が無い場合は押下不可
                //    this.uButton_RowAdd.Enabled = false;
                //}
                //else
                //{
                //    this.uButton_RowAdd.Enabled = true;
                //}
                // --- DEL 2009/02/23 --------------------------------<<<<<
                // --- DEL 2009/03/03 -------------------------------->>>>>
                //// --- ADD 2009/02/23 -------------------------------->>>>>
                //if ((int)this.uGrid_Details.Rows[rowIndex].Cells[this._goodsStockDataTable.GoodsLogicalDeleteFlgColumn.ColumnName].Value == 0
                //    && (int)this.uGrid_Details.Rows[rowIndex].Cells[this._goodsStockDataTable.GoodsDeleteReserveFlgColumn.ColumnName].Value == 0
                //    && this.uGrid_Details.Rows[rowIndex].Cells[this._goodsStockDataTable.WarehouseCodeColumn.ColumnName].Value != null
                //    && this.uGrid_Details.Rows[rowIndex].Cells[this._goodsStockDataTable.WarehouseCodeColumn.ColumnName].Value != DBNull.Value)
                //{
                //    // 商品が削除行でないかつ倉庫の入力が存在する場合、押下可能
                //    this.uButton_RowAdd.Enabled = true;
                //}
                //else
                //{
                //    this.uButton_RowAdd.Enabled = false;
                //}
                //// --- ADD 2009/02/23 --------------------------------<<<<<
                // --- DEL 2009/03/03 --------------------------------<<<<<
                // --- ADD 2009/03/03 -------------------------------->>>>>
                // 商品が正常行の場合のみ在庫の情報をチェック
                if ((int)this.uGrid_Details.Rows[rowIndex].Cells[this._goodsStockDataTable.GoodsLogicalDeleteFlgColumn.ColumnName].Value == 0
                && (int)this.uGrid_Details.Rows[rowIndex].Cells[this._goodsStockDataTable.GoodsDeleteReserveFlgColumn.ColumnName].Value == 0)
                {
                    bool noStockExistFlg = this.CheckStockNotExist(this.uGrid_Details.Rows[rowIndex].Cells[this._goodsStockDataTable.GoodsNoColumn.ColumnName].Value.ToString(),
                        (int)this.uGrid_Details.Rows[rowIndex].Cells[this._goodsStockDataTable.GoodsMakerColumn.ColumnName].Value);

                    if (noStockExistFlg)
                    {
                        this.uButton_RowAdd.Enabled = false;
                    }
                    else
                    {
                        this.uButton_RowAdd.Enabled = true;
                    }
                }
                else
                {
                    this.uButton_RowAdd.Enabled = false;
                }
                // --- ADD 2009/03/03 --------------------------------<<<<<
            }
            else
            {
                this.uButton_RowAdd.Enabled = false;
            }
            #endregion
        }

        // --- ADD 2009/02/23 -------------------------------->>>>>
        /// <summary>
        /// 指定グリッド行の状態に応じたボタン押下可否制御を行う。
        /// </summary>
        /// <remarks>
        /// </remarks>
        private void SetButtonEnableBySelectedRows()
        {
            #region 削除、復活ボタン制御

            bool isGoodsLogicalDelete = false; // 1つでも商品が論理削除済の場合true
            bool isGoodsReserveDelete = false; // 1つでも商品が削除予約の場合true
            bool isStockLogicalDelete = false; // 1つでも在庫が論理削除済の場合true
            bool isStockReserveDelete = false; // 1つでも在庫が削除予約の場合true
            bool isGoodsNotDelete = false;     // 1つでも商品が正常(削除対象でない)の場合true
            bool isStockNotDelete = false;     // 1つでも在庫が正常(削除対象でない)の場合true

            bool isStockExist = false;         // 1つも在庫のない商品がある (商品追加ボタンの制御用)

            #region 行状態チェック
            foreach (UltraGridRow ultraRow in this.uGrid_Details.Selected.Rows)
            {
                if ((int)ultraRow.Cells[this._goodsStockDataTable.GoodsLogicalDeleteFlgColumn.ColumnName].Value != 0)
                {
                    isGoodsLogicalDelete = true; // 商品論理削除行あり
                }
                
                if ((int)ultraRow.Cells[this._goodsStockDataTable.GoodsDeleteReserveFlgColumn.ColumnName].Value != 0)
                {
                    isGoodsReserveDelete = true; // 商品削除予約行あり
                }

                if ((int)ultraRow.Cells[this._goodsStockDataTable.GoodsLogicalDeleteFlgColumn.ColumnName].Value == 0
                    && (int)ultraRow.Cells[this._goodsStockDataTable.GoodsDeleteReserveFlgColumn.ColumnName].Value == 0)
                {
                    isGoodsNotDelete = true; // 商品正常行(削除対象外行)あり
                }

                // 商品が正常行の場合のみ在庫の情報をチェック
                if ((int)ultraRow.Cells[this._goodsStockDataTable.GoodsLogicalDeleteFlgColumn.ColumnName].Value == 0
                && (int)ultraRow.Cells[this._goodsStockDataTable.GoodsDeleteReserveFlgColumn.ColumnName].Value == 0)
                {
                    // 修正登録の場合は在庫情報がある行のみチェック
                    if (this._beforeSearchExtractInfo.DisplayDiv == ExtractInfo.DisplayDivState.New
                        ||
                        (ultraRow.Cells[this._goodsStockDataTable.OriginalWarehouseCodeColumn.ColumnName].Value != null
                        && ultraRow.Cells[this._goodsStockDataTable.OriginalWarehouseCodeColumn.ColumnName].Value != DBNull.Value
                        //&& ultraRow.Cells[this._goodsStockDataTable.RowNumberColumn.ColumnName].Value.ToString() != "新規")) // DEL 2009/03/06
                        && ultraRow.Cells[this._goodsStockDataTable.RowIndexColumn.ColumnName].Value.ToString() != "新規")) // ADD 2009/03/06
                    {

                        if ((int)ultraRow.Cells[this._goodsStockDataTable.StockLogicalDeleteFlgColumn.ColumnName].Value != 0)
                        {
                            isStockLogicalDelete = true; // 在庫論理削除行あり
                        }

                        if ((int)ultraRow.Cells[this._goodsStockDataTable.StockDeleteReserveFlgColumn.ColumnName].Value != 0)
                        {
                            isStockReserveDelete = true; // 在庫削除予約行あり
                        }

                        if ((int)ultraRow.Cells[this._goodsStockDataTable.StockLogicalDeleteFlgColumn.ColumnName].Value == 0
                            && (int)ultraRow.Cells[this._goodsStockDataTable.StockDeleteReserveFlgColumn.ColumnName].Value == 0)
                        {
                            isStockNotDelete = true; // 在庫正常行(削除対象外行)あり
                        }

                        //isStockExist = true; // DEL 2009/03/03
                    }
                    // --- ADD 2009/03/03 -------------------------------->>>>>
                    if (this._beforeSearchExtractInfo.TargetDiv == ExtractInfo.TargetDivState.GoodsStock)
                    {
                        // 商品在庫の場合のみ在庫存在チェック(在庫追加ボタン用)
                        // 行追加はアクティブ行のみ対象
                        if (ultraRow.IsActiveRow
                            && !this.CheckStockNotExist(ultraRow.Cells[this._goodsStockDataTable.GoodsNoColumn.ColumnName].Value.ToString(),
                            (int)ultraRow.Cells[this._goodsStockDataTable.GoodsMakerColumn.ColumnName].Value))
                        {
                            isStockExist = true;
                        }
                    }
                    // --- ADD 2009/03/03 --------------------------------<<<<<
                }
            }

            if (isGoodsLogicalDelete) this._includeGoodsLogicalDeleted = true;
            else this._includeGoodsLogicalDeleted = false;

            if (isStockLogicalDelete) this._includeStockLogicalDeleted = true;
            else this._includeStockLogicalDeleted = false;
            #endregion

            #region 削除・復活ボタン制御
            if (this._beforeSearchExtractInfo.DisplayDiv == ExtractInfo.DisplayDivState.New)
            {
                // 新規登録
                if (this._beforeSearchExtractInfo.TargetDiv == ExtractInfo.TargetDivState.Goods) // 商品
                {
                    // 在庫ボタン不可
                    this.uButton_RowStockDelete.Enabled = false;
                    this.uButton_RowStockRevive.Enabled = false;

                    // 商品ボタンを一旦trueに
                    this.uButton_RowGoodsDelete.Enabled = true;
                    this.uButton_RowGoodsRevive.Enabled = true;

                    if (!isGoodsReserveDelete)
                    {
                        // 削除予約行がない場合、復活ボタン押下不可
                        this.uButton_RowGoodsRevive.Enabled = false;
                    }

                    if (!isGoodsNotDelete)
                    {
                        // 正常行が無い場合、削除ボタン押下不可
                        this.uButton_RowGoodsDelete.Enabled = false;
                    }
                }
                else if (this._beforeSearchExtractInfo.TargetDiv == ExtractInfo.TargetDivState.Stock) // 在庫
                {
                    // 商品ボタン不可
                    this.uButton_RowGoodsDelete.Enabled = false;
                    this.uButton_RowGoodsRevive.Enabled = false;

                    // 在庫ボタンを一旦trueに
                    this.uButton_RowStockDelete.Enabled = true;
                    this.uButton_RowStockRevive.Enabled = true;

                    if (!isStockReserveDelete)
                    {
                        // 削除予約行がない場合、復活ボタン押下不可
                        this.uButton_RowStockRevive.Enabled = false;
                    }

                    if (!isStockNotDelete)
                    {
                        // 正常行が無い場合、削除ボタン押下不可
                        this.uButton_RowStockDelete.Enabled = false;
                    }
                }
            }
            else
            {
                // 修正登録
                if (this._beforeSearchExtractInfo.TargetDiv == ExtractInfo.TargetDivState.Goods) // 商品
                {
                    // 在庫ボタン不可
                    this.uButton_RowStockDelete.Enabled = false;
                    this.uButton_RowStockRevive.Enabled = false;

                    // 商品ボタンを一旦trueに
                    this.uButton_RowGoodsDelete.Enabled = true;
                    this.uButton_RowGoodsRevive.Enabled = true;

                    if (!isGoodsLogicalDelete)
                    {
                        // 論理削除行がある場合、削除、復活とも可能
                        if (!isGoodsReserveDelete)
                        {
                            // 論理削除行がないかつ削除予約行がない場合、復活ボタン押下不可
                            this.uButton_RowGoodsRevive.Enabled = false;
                        }

                        if (!isGoodsNotDelete)
                        {
                            // 論理削除行がないかつ正常行が無い場合、削除ボタン押下不可
                            this.uButton_RowGoodsDelete.Enabled = false;
                        }
                    }
                }
                else if (this._beforeSearchExtractInfo.TargetDiv == ExtractInfo.TargetDivState.Stock
                    || this._beforeSearchExtractInfo.TargetDiv == ExtractInfo.TargetDivState.StockGoods) // 在庫と在庫商品
                {
                    // 商品ボタン不可
                    this.uButton_RowGoodsDelete.Enabled = false;
                    this.uButton_RowGoodsRevive.Enabled = false;

                    // 在庫ボタンを一旦trueに
                    this.uButton_RowStockDelete.Enabled = true;
                    this.uButton_RowStockRevive.Enabled = true;

                    if (!isStockLogicalDelete)
                    {
                        // 論理削除行がある場合、削除、復活とも可能
                        if (!isStockReserveDelete)
                        {
                            // 論理削除行がないかつ削除予約行がない場合、復活ボタン押下不可
                            this.uButton_RowStockRevive.Enabled = false;
                        }

                        if (!isStockNotDelete)
                        {
                            // 論理削除行がないかつ正常行が無い場合、削除ボタン押下不可
                            this.uButton_RowStockDelete.Enabled = false;
                        }
                    }
                }
                else if (this._beforeSearchExtractInfo.TargetDiv == ExtractInfo.TargetDivState.GoodsStock) // 商品在庫
                {
                    // 商品ボタン、在庫ボタンを一旦trueに
                    this.uButton_RowGoodsDelete.Enabled = true;
                    this.uButton_RowGoodsRevive.Enabled = true;

                    this.uButton_RowStockDelete.Enabled = true;
                    this.uButton_RowStockRevive.Enabled = true;

                    if (!isGoodsLogicalDelete)
                    {
                        // 論理削除行がある場合、削除、復活とも可能
                        if (!isGoodsReserveDelete)
                        {
                            // 論理削除行がないかつ削除予約行がない場合、復活ボタン押下不可
                            this.uButton_RowGoodsRevive.Enabled = false;
                        }

                        if (!isGoodsNotDelete)
                        {
                            // 論理削除行がないかつ正常行が無い場合、削除ボタン押下不可
                            this.uButton_RowGoodsDelete.Enabled = false;
                        }
                    }

                    if (!isStockLogicalDelete)
                    {
                        // 論理削除行がある場合、削除、復活とも可能
                        if (!isStockReserveDelete)
                        {
                            // 論理削除行がないかつ削除予約行がない場合、復活ボタン押下不可
                            this.uButton_RowStockRevive.Enabled = false;
                        }

                        if (!isStockNotDelete)
                        {
                            // 論理削除行がないかつ正常行が無い場合、削除ボタン押下不可
                            this.uButton_RowStockDelete.Enabled = false;
                        }
                    }
                }
            }
            #endregion

            #endregion

            // ガイドボタン制御(行の場合は押下不可)
            //this.uButton_RowExcuteGuide.Enabled = false; // DEL 2010/08/11
            this.SetGuide(false); // ADD 2010/08/11

            #region 商品追加ボタン
            if (this._beforeSearchExtractInfo.DisplayDiv == ExtractInfo.DisplayDivState.New
                && this._beforeSearchExtractInfo.TargetDiv == ExtractInfo.TargetDivState.Goods)
            {
                this.uButton_RowAdd.Enabled = true;
            }
            else if (this._beforeSearchExtractInfo.TargetDiv == ExtractInfo.TargetDivState.GoodsStock)
            {
                if (isStockExist)
                {
                    this.uButton_RowAdd.Enabled = true;
                }
                else
                {
                    // 在庫が無い場合は押下不可
                    this.uButton_RowAdd.Enabled = false;
                }
            }
            else
            {
                this.uButton_RowAdd.Enabled = false;
            }
            #endregion
        }
        // --- ADD 2009/02/23 --------------------------------<<<<<
        #endregion

        #region ■ XML操作
        /// <summary>
        /// ＸＭＬデータの読込処理
        /// </summary>
        public void LoadStateXmlData()
        {
            int status = this._gridStateController.LoadGridState(XML_FILE_INITIAL_DATA, ref this.uGrid_Details);
        }

        /// <summary>
        /// ＸＭＬデータの保存処理
        /// </summary>
        public void SaveStateXmlData()
        {
            // グリッド情報を保存
            this._gridStateController.SaveGridState(XML_FILE_INITIAL_DATA, ref this.uGrid_Details);
        }
        #endregion XML操作

        #endregion

        #region ■ グリッド入力制御関連

        /// <summary>
        /// セルActivation設定
        /// </summary>
        /// <remarks>
        /// <br>検索時、セル単位の入力許可設定を行う</br>
        /// <br>品名、メーカー、倉庫は列単位で入力可否が決まらない為、セル単位で制御する</br>
        /// </remarks>
        internal void SetCellActivation()
        {
            foreach (UltraGridRow ultraRow in this.uGrid_Details.Rows)
            {
                // 既存のキー値（商品、メーカー、倉庫）は入力不可(商品、在庫の追加時のみ編集可能にする)
                ultraRow.Cells[this._goodsStockDataTable.GoodsNoColumn.ColumnName].Activation = Activation.Disabled;
                ultraRow.Cells[this._goodsStockDataTable.GoodsMakerColumn.ColumnName].Activation = Activation.Disabled;
                
                if (ultraRow.Cells[this._goodsStockDataTable.OriginalWarehouseCodeColumn.ColumnName].Value != null
                    && ultraRow.Cells[this._goodsStockDataTable.OriginalWarehouseCodeColumn.ColumnName].Value != DBNull.Value)
                {
                    // 倉庫が無い場合は編集可能
                    ultraRow.Cells[this._goodsStockDataTable.WarehouseCodeColumn.ColumnName].Activation = Activation.Disabled;
                }

                // 商品論理削除行は編集不可
                if ((int)ultraRow.Cells[this._goodsStockDataTable.GoodsLogicalDeleteFlgColumn.ColumnName].Value != 0)
                {
                    foreach (UltraGridCell ultraCell in ultraRow.Cells)
                    {
                        ultraCell.Activation = Activation.Disabled;
                    }
                }

                // 在庫論理削除行は在庫情報のみ編集不可
                if ((int)ultraRow.Cells[this._goodsStockDataTable.StockLogicalDeleteFlgColumn.ColumnName].Value != 0)
                {
                    int stockColIndex = ultraRow.Cells[this._goodsStockDataTable.WarehouseCodeColumn.ColumnName].Column.Index;

                    for (int i = stockColIndex; i < ultraRow.Cells.Count; i++)
                    {
                        ultraRow.Cells[i].Activation = Activation.Disabled;
                    }
                }
            }
        }
        #endregion

        #region ■ その他処理
        #region ■ 削除済みデータの表示関連処理
        /// <summary>
        /// 削除済みデータの表示チェックボックスの反映
        /// </summary>
        internal void DeleteIndicationSetting(bool isChecked)
        {
            if (isChecked)
            {
                if (this._beforeSearchExtractInfo.TargetDiv != ExtractInfo.TargetDivState.Stock
                    && this._beforeSearchExtractInfo.TargetDiv != ExtractInfo.TargetDivState.StockGoods) // ADD 2009/02/03
                {
                    // 在庫、在庫商品の場合、商品削除日は表示しない
                    this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsStockDataTable.GoodsDeleteDateColumn.ColumnName].Hidden = false;
                }

                if (this._beforeSearchExtractInfo.TargetDiv != ExtractInfo.TargetDivState.Goods)
                {
                    // 商品の場合、在庫削除日は表示しない
                    this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsStockDataTable.StockDeleteDateColumn.ColumnName].Hidden = false;
                }
            }
            else
            {
                this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsStockDataTable.GoodsDeleteDateColumn.ColumnName].Hidden = true;
                this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsStockDataTable.StockDeleteDateColumn.ColumnName].Hidden = true;
            }

            // 論理削除フィルタ設定
            this.SetGridFiltering(isChecked);

            // --- ADD 2009/02/23 -------------------------------->>>>>
            // フィルタ変更によるアクティブ行、選択行制御
            this.SetActivationStatByFilteredOut();

            // 選択行の状態が変わるのでボタン押下制御
            this.SetButtonEnable();

            // 選択行の状態が変わるので背景色リフレッシュ
            this.SetGridColorAll();
            // --- ADD 2009/02/23 --------------------------------<<<<<
        }

        /// <summary>
        /// フィルタ設定
        /// </summary>
        /// <remarks>
        /// <br>論理削除行フィルタのみ再設定</br>
        /// </remarks>
        private void SetGridFiltering()
        {
            ExtractInfo extractInfo = this.GetExtractInfo();

            this.SetGridFiltering(extractInfo.DeleteIndication);

            // --- ADD 2009/02/23 -------------------------------->>>>>
            // フィルタ変更によるアクティブ行、選択行制御
            this.SetActivationStatByFilteredOut();

            // 選択行の状態が変わるのでボタン押下制御
            this.SetButtonEnable();

            // 選択行の状態が変わるので背景色リフレッシュ
            this.SetGridColorAll();
            // --- ADD 2009/02/23 --------------------------------<<<<<
        }

        /// <summary>
        /// フィルタ設定
        /// </summary>
        private void SetGridFiltering(bool deleteDispChecked)
        {
            Infragistics.Win.UltraWinGrid.ColumnFiltersCollection columnFilters = this.uGrid_Details.DisplayLayout.Bands[0].ColumnFilters;
            //columnFilters.ClearAllFilters(); // 画面で指定したフィルタも外れてしまうので×。

            columnFilters[this._goodsStockDataTable.GoodsDeleteDateColumn.ColumnName].FilterConditions.Clear();
            columnFilters[this._goodsStockDataTable.StockDeleteDateColumn.ColumnName].FilterConditions.Clear();

            if (!deleteDispChecked)
            {
                // 空白とNull以外をフィルタに設定する
                columnFilters[this._goodsStockDataTable.GoodsDeleteDateColumn.ColumnName].FilterConditions.Add(Infragistics.Win.UltraWinGrid.FilterComparisionOperator.Equals, "");
                columnFilters[this._goodsStockDataTable.GoodsDeleteDateColumn.ColumnName].FilterConditions.Add(Infragistics.Win.UltraWinGrid.FilterComparisionOperator.Equals, null);
                columnFilters[this._goodsStockDataTable.GoodsDeleteDateColumn.ColumnName].LogicalOperator = Infragistics.Win.UltraWinGrid.FilterLogicalOperator.Or;

                if (this._beforeSearchExtractInfo.TargetDiv != ExtractInfo.TargetDivState.Goods)
                {
                    // 対象区分「商品」以外の場合は、在庫削除日でもフィルタ
                    columnFilters[this._goodsStockDataTable.StockDeleteDateColumn.ColumnName].FilterConditions.Add(Infragistics.Win.UltraWinGrid.FilterComparisionOperator.Equals, "");
                    columnFilters[this._goodsStockDataTable.StockDeleteDateColumn.ColumnName].FilterConditions.Add(Infragistics.Win.UltraWinGrid.FilterComparisionOperator.Equals, null);
                    columnFilters[this._goodsStockDataTable.StockDeleteDateColumn.ColumnName].LogicalOperator = Infragistics.Win.UltraWinGrid.FilterLogicalOperator.Or;
                }
            }
        }

        // --- ADD 2009/02/23 -------------------------------->>>>>
        /// <summary>
        /// フィルタ変更による行のアクティブ、選択行制御
        /// </summary>
        private void SetActivationStatByFilteredOut()
        {
            // アクティブセルのチェック
            if (this.uGrid_Details.ActiveCell != null)
            {
                if (this.uGrid_Details.ActiveCell.Row.IsFilteredOut)
                {
                    if (!this.uGrid_Details.PerformAction(UltraGridAction.BelowCell))
                    {
                        if (!this.uGrid_Details.PerformAction(UltraGridAction.BelowRow))
                        {
                            if (!this.uGrid_Details.PerformAction(UltraGridAction.AboveCell))
                            {
                                if (!this.uGrid_Details.PerformAction(UltraGridAction.AboveRow))
                                {
                                    // 表示行がない
                                    this.uGrid_Details.ActiveCell = null;
                                    this.uGrid_Details.ActiveRow = null;
                                }
                            }
                        }
                    }
                }

                if (this.uGrid_Details.ActiveCell != null)
                {
                    this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                }
            }
            // 選択行のチェック
            else if (this.uGrid_Details.Selected.Rows.Count != 0)
            {
                foreach (UltraGridRow ultraRow in this.uGrid_Details.Selected.Rows)
                {
                    if (ultraRow.IsFilteredOut)
                    {
                        if (ultraRow.Activated)
                        {
                            // アクティブ行の場合、表示行に変更
                            if (!this.uGrid_Details.PerformAction(UltraGridAction.BelowRow))
                            {
                                if (!this.uGrid_Details.PerformAction(UltraGridAction.AboveRow))
                                {
                                    // 表示行がない
                                    this.uGrid_Details.ActiveCell = null;
                                    this.uGrid_Details.ActiveRow = null;
                                    ultraRow.Selected = false;
                                }
                            }
                        }
                        else
                        {
                            // 選択行の場合、非選択に
                            ultraRow.Selected = false;
                        }
                    }
                }
            }
        }
        // --- ADD 2009/02/23 --------------------------------<<<<<
        #endregion

        /// <summary>
        /// 明細グリッド選択行、アクティブセルの行index取得
        /// </summary>
        /// <returns>行番号(無い場合は空のリスト)</returns>
        /// <remarks>
        /// <br>複数行選択に対応</br>
        /// </remarks>
        //private int GetSelectRowIndex() // DEL 2009/02/23
        private List<int> GetSelectRowIndex() // ADD 2009/02/23
        {
            // --- DEL 2009/02/23 -------------------------------->>>>>
            //if (this.uGrid_Details.ActiveRow != null)
            //{
            //    return this.uGrid_Details.ActiveRow.Index;
            //}
            //else if (this.uGrid_Details.ActiveCell != null)
            //{
            //    return this.uGrid_Details.ActiveCell.Row.Index;
            //}

            //return -1;
            // --- DEL 2009/02/23 --------------------------------<<<<<
            // --- ADD 2009/02/23 -------------------------------->>>>>
            List<int> rowIndexList = new List<int>();

            if (this.uGrid_Details.ActiveCell != null)
            {
                // セルアクティブ
                rowIndexList.Add(this.uGrid_Details.ActiveCell.Row.Index);
            }
            else if (this.uGrid_Details.Selected.Rows.Count != 0)
            {
                foreach (UltraGridRow ultraRow in this.uGrid_Details.Selected.Rows)
                {
                    rowIndexList.Add(ultraRow.Index);
                }
            }

            return rowIndexList;
            // --- ADD 2009/02/23 --------------------------------<<<<<
        }

        /// <summary>
        /// DBNullを含む項目の数値変換処理(整数用)
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        private double ConvertToDoubleFromGridValue(object obj)
        {
            if (obj == null || obj == DBNull.Value)
            {
                return 0;
            }
            else
            {
                return Convert.ToDouble(obj);
            }
        }

        /// <summary>
        /// 数値入力チェック処理
        /// </summary>
        /// <remarks>コピー元：MAKHN09280UC.csのKeyPressNumCheck()</remarks>
        /// <param name="keta">桁数(マイナス符号を含まず)</param>
        /// <param name="priod">小数点以下桁数</param>
        /// <param name="prevVal">現在の文字列</param>
        /// <param name="key">入力されたキー値</param>
        /// <param name="selstart">カーソル位置</param>
        /// <param name="sellength">選択文字長</param>
        /// <param name="minusFlg">マイナス入力可？</param>
        /// <returns>true=入力可,false=入力不可</returns>
        private bool CheckKeyPressNumber(
            int keta,
            int priod,
            string prevVal,
            char key,
            int selstart,
            int sellength,
            Boolean minusFlg
        )
        {
            // 制御キーが押された？
            if (Char.IsControl(key))
            {
                return true;
            }

            // 1文字目が'.'はNG
            if (string.IsNullOrEmpty(prevVal) && key.Equals('.'))
            {
                return false;
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
            string _strResult = "";
            if (sellength > 0)
            {
                _strResult = prevVal.Substring(0, selstart) + prevVal.Substring(selstart + sellength, prevVal.Length - (selstart + sellength));
            }
            else
            {
                _strResult = prevVal;
            }

            // マイナスのチェック
            if (key == '-')
            {
                if ((minusFlg == false) || (selstart > 0) || (_strResult.IndexOf('-') != -1))
                {
                    return false;
                }
            }

            // 小数点のチェック
            if (key == '.')
            {
                if ((priod <= 0) || (_strResult.IndexOf('.') != -1))
                {
                    return false;
                }
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

            // 小数点以下のチェック
            if (priod > 0)
            {
                // 小数点の位置決定
                int _pointPos = _strResult.IndexOf('.');

                // 整数部に入力可能な桁数を決定！
                int _Rketa = (_strResult[0] == '-') ? keta - priod : keta - priod - 1;
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
                    if (_strResult.Length > _Rketa)
                    {
                        return false;
                    }
                }

                // 小数部の桁数をチェック
                if (_pointPos != -1)
                {
                    // 小数部の桁数を計算
                    int _priketa = _strResult.Length - _pointPos - 1;
                    if (priod < _priketa)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        // --- ADD 2009/03/03 -------------------------------->>>>>
        /// <summary>
        /// 在庫有無チェック
        /// </summary>
        /// <returns>true;在庫の無いデータがある false:在庫の無いデータが無い</returns>
        /// <remarks>
        /// <br>同商品で在庫のないデータがあるかチェックする</br>
        /// <br>Update Note : 2012/09/11 yangmj 障害・改良対応（７月リリース案件）</br>
        /// <br>管理番号    : 10707327-00 PM1203G</br> 							
        /// <br>              Redmine32095 商品在庫一括登録修正で「全ての価格情報が消える」</br> 		 
        /// </remarks>
        private bool CheckStockNotExist(string goodsNo, int goodsMakerCode)
        {
            StringBuilder filSb = new StringBuilder();
            //----- ADD YANGMJ 2012/09/11 REDMINE#32095 ----->>>>>
            if (goodsNo.Contains("'"))
            {
                goodsNo = goodsNo.Replace("'", "''");
            }
            //----- ADD YANGMJ 2012/09/11 REDMINE#32095 -----<<<<<
            filSb.Append(this._goodsStockDataTable.GoodsNoColumn.ColumnName);
            filSb.Append(" = '");
            filSb.Append(goodsNo);
            filSb.Append("' AND ");
            filSb.Append(this._goodsStockDataTable.GoodsMakerColumn.ColumnName);
            filSb.Append(" = ");
            filSb.Append(goodsMakerCode);

            DataRow[] drList = this._goodsStockDataTable.Select(filSb.ToString());

            if (drList.Length > 0)
            {
                foreach (DataRow dr in drList)
                {
                    if (dr[this._goodsStockDataTable.WarehouseCodeColumn.ColumnName] == null
                        || dr[this._goodsStockDataTable.WarehouseCodeColumn.ColumnName] == DBNull.Value)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
        // --- ADD 2009/03/03 --------------------------------<<<<<
        #endregion

        #region ■ 削除処理
        /// <summary>
        /// 商品削除メイン処理
        /// </summary>
        /// <param name="rowIndex">対象行</param>
        /// <remarks>
        /// <br>複数行選択に対応</br>
        /// </remarks>
        //private void GoodsDeleteMain(int rowIndex) // DEL 2009/02/23
        private void GoodsDeleteMain() // ADD 2009/02/23
        {
            // --- DEL 2009/02/23 -------------------------------->>>>>
            //if (this.uGrid_Details.Rows[rowIndex].Cells[this._goodsStockDataTable.RowNumberColumn.ColumnName].Value.ToString() == "新規")
            //{
            //    // 追加行の場合、削除する
            //    this.uGrid_Details.Rows[rowIndex].Delete();
            //    return;
            //}

            //if (this._beforeSearchExtractInfo.DisplayDiv == ExtractInfo.DisplayDivState.New)
            //{
            //    // 削除予約処理
            //    this.GoodsLogicalDeleteReserve(rowIndex);
            //}
            //else
            //{
            //    // 商品
            //    if ((int)this.uGrid_Details.Rows[rowIndex].Cells[this._goodsStockDataTable.GoodsLogicalDeleteFlgColumn.ColumnName].Value == 1)
            //    {
            //        // 商品が論理削除済の場合、物理削除処理(商品、在庫とも)
            //        this.GoodsCompleteDelete(rowIndex);
            //    }
            //    else if ((int)this.uGrid_Details.Rows[rowIndex].Cells[this._goodsStockDataTable.GoodsLogicalDeleteFlgColumn.ColumnName].Value == 0)
            //    {
            //        // 削除予約処理
            //        this.GoodsLogicalDeleteReserve(rowIndex);
            //    }
            //}
            // --- DEL 2009/02/23 --------------------------------<<<<<
            // --- ADD 2009/02/23 -------------------------------->>>>>
            List<int> rowIndexList = this.GetSelectRowIndex();
            rowIndexList.Sort();

            if (rowIndexList.Count == 0)
            {
                // 選択行、アクティブセルが無い場合、処理なし
                return;
            }

            if (this._includeGoodsLogicalDeleted)
            {
                // 完全削除を含む場合は警告を表示
                DialogResult dialogResult = TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_QUESTION,
                        this.Name,
                        "選択した商品のうち、削除済みデータを完全削除します。" + "\r\n" + "\r\n" +
                        "よろしいですか？",
                        0,
                        MessageBoxButtons.YesNo,
                        MessageBoxDefaultButton.Button1);

                if (dialogResult != DialogResult.Yes)
                {
                    return;
                }
            }

            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            // 処理済商品リスト
            Dictionary<string, List<int>> deletedDic = new Dictionary<string, List<int>>();
            // 物理削除対象商品リスト
            ArrayList completeDeletedList = new ArrayList();

            // 完全削除時、行が削除されるためIndexが大きい方から処理
            for (int i = rowIndexList.Count - 1; i >= 0; i--)
            {
                int rowIndex = rowIndexList[i];

                //if (this.uGrid_Details.Rows[rowIndex].Cells[this._goodsStockDataTable.RowNumberColumn.ColumnName].Value.ToString() == "新規") // DEL 2009/03/06
                if (this.uGrid_Details.Rows[rowIndex].Cells[this._goodsStockDataTable.RowIndexColumn.ColumnName].Value.ToString() == "新規") // ADD 2009/03/06
                {
                    // 追加行の場合、削除する
                    this.uGrid_Details.Rows[rowIndex].Delete(false);
                    continue;
                }

                if (deletedDic.ContainsKey(this.uGrid_Details.Rows[rowIndex].Cells[this._goodsStockDataTable.GoodsNoColumn.ColumnName].Value.ToString())
                    && deletedDic[this.uGrid_Details.Rows[rowIndex].Cells[this._goodsStockDataTable.GoodsNoColumn.ColumnName].Value.ToString()]
                    .Contains((int)this.uGrid_Details.Rows[rowIndex].Cells[this._goodsStockDataTable.GoodsMakerColumn.ColumnName].Value))
                {
                    // 処理済み
                    continue;
                }

                // 商品
                if ((int)this.uGrid_Details.Rows[rowIndex].Cells[this._goodsStockDataTable.GoodsLogicalDeleteFlgColumn.ColumnName].Value == 1)
                {
                    // 物理削除対象商品リストの作成
                    // 物理削除は複数行削除によりIndexが壊れるため、後で行う。
                    // また、同商品は処理済みリストの方で除かれる
                    ArrayList list = new ArrayList();
                    list.Add(this.uGrid_Details.Rows[rowIndex].Cells[this._goodsStockDataTable.GoodsNoColumn.ColumnName].Value);
                    list.Add(this.uGrid_Details.Rows[rowIndex].Cells[this._goodsStockDataTable.GoodsMakerColumn.ColumnName].Value);
                    
                    completeDeletedList.Add(list);
                }
                else if ((int)this.uGrid_Details.Rows[rowIndex].Cells[this._goodsStockDataTable.GoodsDeleteReserveFlgColumn.ColumnName].Value == 0)
                {
                    // 削除予約処理
                    this.GoodsLogicalDeleteReserve(rowIndex);
                }
                else
                {
                    // 処理対象外(既に予約済の行など)
                    continue;
                }

                // 処理済リストの作成
                if (deletedDic.ContainsKey(this.uGrid_Details.Rows[rowIndex].Cells[this._goodsStockDataTable.GoodsNoColumn.ColumnName].Value.ToString()))
                {
                    deletedDic[this.uGrid_Details.Rows[rowIndex].Cells[this._goodsStockDataTable.GoodsNoColumn.ColumnName].Value.ToString()]
                        .Add((int)this.uGrid_Details.Rows[rowIndex].Cells[this._goodsStockDataTable.GoodsMakerColumn.ColumnName].Value);
                }
                else
                {
                    List<int> makerList = new List<int>();
                    makerList.Add((int)this.uGrid_Details.Rows[rowIndex].Cells[this._goodsStockDataTable.GoodsMakerColumn.ColumnName].Value);

                    deletedDic.Add(this.uGrid_Details.Rows[rowIndex].Cells[this._goodsStockDataTable.GoodsNoColumn.ColumnName].Value.ToString(), makerList);
                }
            }

            // 完全削除処理
            if (completeDeletedList.Count != 0)
            {
                foreach (ArrayList goodsList in completeDeletedList)
                {
                    // 物理削除処理(商品、在庫とも)
                    status = this.GoodsCompleteDelete(goodsList[0].ToString(), (int)goodsList[1]);

                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        break;
                    }
                }
            }

            if (this._includeGoodsLogicalDeleted
                && status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // 完全削除行が存在かつ全て正常に完了時はメッセージを表示
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    "完全削除しました。",
                    0,
                    MessageBoxButtons.OK);

                // 保存ボタン押下可否設定
                if (this._goodsStockDataTable.Rows.Count == 0)
                {
                    this.SetSaveButton();
                }
            }

            // 論理削除行を再フィルタ
            this.SetGridFiltering();
            // --- ADD 2009/02/23 --------------------------------<<<<<
        }

        /// <summary>
        /// 商品論理削除処理
        /// </summary>
        /// <param name="rowIndex"></param>
        private void GoodsLogicalDeleteReserve(int rowIndex)
        {
            // 選択行のキー値を取得
            string goodsNo = this.uGrid_Details.Rows[rowIndex].Cells[this._goodsStockDataTable.GoodsNoColumn.ColumnName].Value.ToString();
            int goodsMakerCd = (int)this.uGrid_Details.Rows[rowIndex].Cells[this._goodsStockDataTable.GoodsMakerColumn.ColumnName].Value;

            foreach (UltraGridRow ultraGr in this.uGrid_Details.Rows)
            {
                if (ultraGr.Cells[this._goodsStockDataTable.GoodsNoColumn.ColumnName].Value.ToString() == goodsNo
                    && (int)ultraGr.Cells[this._goodsStockDataTable.GoodsMakerColumn.ColumnName].Value == goodsMakerCd)
                {
                    // 同商品、在庫の削除日に現在日時を設定
                    // --- DEL 2009/02/05 -------------------------------->>>>>
                    //ultraGr.Cells[this._goodsStockDataTable.GoodsDeleteDateColumn.ColumnName].Value = DateTime.Today;
                    //ultraGr.Cells[this._goodsStockDataTable.StockDeleteDateColumn.ColumnName].Value = DateTime.Today;
                    // --- DEL 2009/02/05 --------------------------------<<<<<
                    // --- ADD 2009/02/05 -------------------------------->>>>>
                    ultraGr.Cells[this._goodsStockDataTable.GoodsDeleteReserveFlgColumn.ColumnName].Value = 1;

                    // 在庫がある場合のみ設定
                    if (ultraGr.Cells[this._goodsStockDataTable.OriginalWarehouseCodeColumn.ColumnName].Value != null
                        && ultraGr.Cells[this._goodsStockDataTable.OriginalWarehouseCodeColumn.ColumnName].Value != DBNull.Value)// ADD 2009/03/02
                    {
                        ultraGr.Cells[this._goodsStockDataTable.StockDeleteReserveFlgColumn.ColumnName].Value = 1;
                    }

                    if (this._beforeSearchExtractInfo.DisplayDiv == ExtractInfo.DisplayDivState.New)
                    {
                        ultraGr.Cells[this._goodsStockDataTable.GoodsDeleteDateColumn.ColumnName].Value = DateTime.Today;
                        ultraGr.Cells[this._goodsStockDataTable.StockDeleteDateColumn.ColumnName].Value = DateTime.Today;
                    }
                    // --- ADD 2009/02/05 --------------------------------<<<<<

                    // 論理削除予約行は編集不可に変更
                    foreach (UltraGridCell ultraCell in ultraGr.Cells)
                    {
                        ultraCell.Activation = Activation.Disabled;
                    }
                }
            }

            // 背景色設定
            //this.SetGridColorRow(this.uGrid_Details.Rows[rowIndex]); // DEL 2009/02/23

            // 論理削除行を再フィルタ
            //this.SetGridFiltering(); // DEL 2009/02/23
        }

        /// <summary>
        /// 商品完全削除処理
        /// </summary>
        /// <returns>処理結果ステータス</returns>
        //private int GoodsCompleteDelete(int rowIndex)
        private int GoodsCompleteDelete(string goodsNo, int goodsMakerCd)
        {
            // 複数行の一括削除のため、1行ずつでは注意文言を表示しない // ADD 2009/02/23
            // --- DEL 2009/02/23 -------------------------------->>>>>
            //// 注意文言表示
            //DialogResult dialogResult = TMsgDisp.Show(
            //        this,
            //        emErrorLevel.ERR_LEVEL_QUESTION,
            //        this.Name,
            //        "選択した商品を完全削除します。" + "\r\n" + "\r\n" +
            //        "よろしいですか？",
            //        0,
            //        MessageBoxButtons.YesNo,
            //        MessageBoxDefaultButton.Button1);

            //if (dialogResult != DialogResult.Yes)
            //{
            //    return;
            //}
            // --- DEL 2009/02/23 --------------------------------<<<<<

            //string goodsNo = this.uGrid_Details.Rows[rowIndex].Cells[this._goodsStockDataTable.GoodsNoColumn.ColumnName].Value.ToString(); // DEL 2009/02/23
            //int goodsMakerCd = (int)this.uGrid_Details.Rows[rowIndex].Cells[this._goodsStockDataTable.GoodsMakerColumn.ColumnName].Value; // DEL 2009/02/23

            // 完全削除実行
            int status = this._goodsStockAcs.GoodsCompleteDelete(goodsNo, goodsMakerCd);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // 複数行の一括削除対応のため、1行ずつでは文言を表示しない // ADD 2009/02/23
                // --- DEL 2009/02/23 -------------------------------->>>>>
                //TMsgDisp.Show(
                //    this,
                //    emErrorLevel.ERR_LEVEL_INFO,
                //    this.Name,
                //    "完全削除しました。",
                //    0,
                //    MessageBoxButtons.OK);
                // --- DEL 2009/02/23 --------------------------------<<<<<

                // 商品在庫テーブルより削除
                for (int i = this._goodsStockDataTable.Rows.Count - 1; i >= 0; i--)
                {
                    DataRow dr = this._goodsStockDataTable.Rows[i];

                    if (dr[this._goodsStockDataTable.GoodsNoColumn.ColumnName].ToString() == goodsNo
                        && (int)dr[this._goodsStockDataTable.GoodsMakerColumn.ColumnName] == goodsMakerCd)
                    {
                        this._goodsStockDataTable.Rows.RemoveAt(i);
                    }
                }

                // 更新用テーブルも同様に更新
                for (int i = this._goodsStockAcs.OriginalGoodsStockDataTable.Rows.Count - 1; i >= 0; i--)
                {
                    DataRow dr = this._goodsStockAcs.OriginalGoodsStockDataTable.Rows[i];

                    if (dr[this._goodsStockDataTable.GoodsNoColumn.ColumnName].ToString() == goodsNo
                        && (int)dr[this._goodsStockDataTable.GoodsMakerColumn.ColumnName] == goodsMakerCd)
                    {
                        this._goodsStockAcs.OriginalGoodsStockDataTable.Rows.RemoveAt(i);
                    }
                }

                // --- DEL 2009/02/23 -------------------------------->>>>>
                //// 論理削除行を再フィルタ
                //this.SetGridFiltering();

                //// --- ADD 2009/02/03 -------------------------------->>>>>
                //// 保存ボタン押下可否設定
                //if (this._goodsStockDataTable.Rows.Count == 0)
                //{
                //    this.SetSaveButton();
                //}
                //// --- ADD 2009/02/03 --------------------------------<<<<<
                // --- DEL 2009/02/23 --------------------------------<<<<<
            }
            // --- ADD 2009/02/02 -------------------------------->>>>>
            else
            {
                switch (status)
                {

                    case (int)ConstantManagement.DB_Status.ctDB_ENT_LOCK_TIMEOUT:
                        {
                            TMsgDisp.Show(this,
                                emErrorLevel.ERR_LEVEL_STOPDISP,
                                this.Name,
                                "シェアチェックエラー(企業ロック)です。" + "\r\n"
                                + "月次処理か、その他の業務を行っているため本処理は行えません。" + "\r\n"
                                + "再試行するか、しばらく待ってから再度処理を行ってください。",
                                status,
                                MessageBoxButtons.OK);

                            break;
                        }
                    case (int)ConstantManagement.DB_Status.ctDB_SEC_LOCK_TIMEOUT:
                        {
                            TMsgDisp.Show(this,
                                emErrorLevel.ERR_LEVEL_STOPDISP,
                                this.Name,
                                "シェアチェックエラー(拠点ロック)です。" + "\r\n"
                                + "締処理か、処理が込み合っているためタイムアウトしました。" + "\r\n"
                                + "再試行するか、しばらく待ってから再度処理を行ってください。",
                                status,
                                MessageBoxButtons.OK);

                            break;
                        }
                    case (int)ConstantManagement.DB_Status.ctDB_WAR_LOCK_TIMEOUT:
                        {
                            TMsgDisp.Show(this,
                                emErrorLevel.ERR_LEVEL_STOPDISP,
                                this.Name,
                                "シェアチェックエラー(倉庫ロック)です。" + "\r\n"
                                + "棚卸処理か、その他の在庫業務を行っているためタイムアウトしました。" + "\r\n"
                                + "再試行するか、しばらく待ってから再度処理を行ってください。",
                                status,
                                MessageBoxButtons.OK);

                            break;
                        }
                    default:
                        {
                            TMsgDisp.Show(this,
                                emErrorLevel.ERR_LEVEL_STOPDISP,
                                this.Name,
                                "完全削除処理でエラーが発生しました。",
                                status,
                                MessageBoxButtons.OK);

                            break;
                        }
                }
            }
            // --- ADD 2009/02/02 --------------------------------<<<<<

            return status; // ADD 2009/02/23
        }

        /// <summary>
        /// 在庫削除メイン処理
        /// </summary>
        /// <param name="rowIndex">対象行</param>
        /// <remarks>
        /// </remarks>
        //private void StockDeleteMain(int rowIndex)
        private void StockDeleteMain()
        {
            // --- DEL 2009/02/23 -------------------------------->>>>>
            //if (this.uGrid_Details.Rows[rowIndex].Cells[this._goodsStockDataTable.RowNumberColumn.ColumnName].Value.ToString() == "新規")
            //{
            //    // 追加行の場合、削除する
            //    this.uGrid_Details.Rows[rowIndex].Delete();
            //    return;
            //}

            //// 修正登録の場合
            //if ((int)this.uGrid_Details.Rows[rowIndex].Cells[this._goodsStockDataTable.StockLogicalDeleteFlgColumn.ColumnName].Value == 1)
            //{
            //    // 在庫が論理削除済の場合、物理削除処理
            //    this.StockCompleteDelete(rowIndex);
            //}
            //else if ((int)this.uGrid_Details.Rows[rowIndex].Cells[this._goodsStockDataTable.StockLogicalDeleteFlgColumn.ColumnName].Value == 0)
            //{
            //    // 削除予約処理
            //    this.StockLogicalDeleteReserve(rowIndex);
            //}
            // --- DEL 2009/02/23 --------------------------------<<<<<
            // --- ADD 2009/02/23 -------------------------------->>>>>
            List<int> rowIndexList = this.GetSelectRowIndex();
            rowIndexList.Sort();

            if (rowIndexList.Count == 0)
            {
                // 選択行、アクティブセルが無い場合、処理なし
                return;
            }

            // --- ADD 2009/03/05 -------------------------------->>>>>
            if (this.uGrid_Details.ActiveCell != null)
            {
                // セルアクティブの場合、
                // マージセルの非表示処理で同商品のデータが削除されているので元に戻す
                this.uGrid_Details_BeforeCellDeactivate();
            }
            // --- ADD 2009/03/05 --------------------------------<<<<<

            if (this._includeStockLogicalDeleted)
            {
                // 完全削除を含む場合は警告を表示
                DialogResult dialogResult = TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_QUESTION,
                        this.Name,
                        "選択した在庫のうち、削除済みデータを完全削除します。" + "\r\n" + "\r\n" +
                        "よろしいですか？",
                        0,
                        MessageBoxButtons.YesNo,
                        MessageBoxDefaultButton.Button1);

                if (dialogResult != DialogResult.Yes)
                {
                    return;
                }
            }

            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            // 完全削除時、行が削除されるためIndexが大きい方から処理
            for (int i = rowIndexList.Count - 1; i >= 0; i--)
            {
                int rowIndex = rowIndexList[i];

                if ((int)this.uGrid_Details.Rows[rowIndex].Cells[this._goodsStockDataTable.GoodsLogicalDeleteFlgColumn.ColumnName].Value != 0
                    || (int)this.uGrid_Details.Rows[rowIndex].Cells[this._goodsStockDataTable.GoodsDeleteReserveFlgColumn.ColumnName].Value != 0)
                {
                    // 商品が論理削除済または削除予約行の場合、在庫は削除しない
                    continue;
                }

                //if (this.uGrid_Details.Rows[rowIndex].Cells[this._goodsStockDataTable.RowNumberColumn.ColumnName].Value.ToString() == "新規") // DEL 2009/03/06
                if (this.uGrid_Details.Rows[rowIndex].Cells[this._goodsStockDataTable.RowIndexColumn.ColumnName].Value.ToString() == "新規") // ADD 2009/03/06
                {
                    // 追加行の場合、削除する
                    this.uGrid_Details.Rows[rowIndex].Delete(false);
                    continue;
                }

                if ((int)this.uGrid_Details.Rows[rowIndex].Cells[this._goodsStockDataTable.StockLogicalDeleteFlgColumn.ColumnName].Value == 1)
                {
                    // 在庫が論理削除済の場合、物理削除処理
                    status = this.StockCompleteDelete(rowIndex);
                }
                else if ((int)this.uGrid_Details.Rows[rowIndex].Cells[this._goodsStockDataTable.StockDeleteReserveFlgColumn.ColumnName].Value == 0)
                {
                    // 削除予約処理
                    this.StockLogicalDeleteReserve(rowIndex);
                }
            }

            if (this._includeStockLogicalDeleted
                && status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // 完全削除行が存在かつ全て正常に完了時はメッセージを表示
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    "完全削除しました。",
                    0,
                    MessageBoxButtons.OK);

                // 保存ボタン押下可否設定
                if (this._goodsStockDataTable.Rows.Count == 0)
                {
                    this.SetSaveButton();
                }
            }

            // 論理削除行を再フィルタ
            this.SetGridFiltering();
            // --- ADD 2009/02/23 -------------------------------->>>>>
        }

        /// <summary>
        /// 在庫論理削除処理
        /// </summary>
        /// <param name="rowIndex"></param>
        private void StockLogicalDeleteReserve(int rowIndex)
        {
            this.uGrid_Details.Rows[rowIndex].Cells[this._goodsStockDataTable.StockDeleteReserveFlgColumn.ColumnName].Value = 1; // ADD 2009/02/05
            
            if (this._beforeSearchExtractInfo.DisplayDiv == ExtractInfo.DisplayDivState.New)
            {
                this.uGrid_Details.Rows[rowIndex].Cells[this._goodsStockDataTable.StockDeleteDateColumn.ColumnName].Value = DateTime.Today;
            }

            int stockColIndex = this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsStockDataTable.WarehouseCodeColumn.ColumnName].Index;

            for (int i = stockColIndex; i < this.uGrid_Details.DisplayLayout.Bands[0].Columns.Count; i++)
            {
                // 在庫情報を編集不可に変更
                this.uGrid_Details.Rows[rowIndex].Cells[i].Activation = Activation.Disabled;
            }

            //// 背景色設定
            //this.SetGridColorRow(this.uGrid_Details.Rows[rowIndex]); // DEL 2009/02/23

            //// 論理削除行を再フィルタ
            //this.SetGridFiltering(); // DEL 2009/02/23
        }
        
        /// <summary>
        /// 在庫完全削除処理
        /// </summary>
        /// <returns>処理結果ステータス</returns>
        /// <br>Update Note : 2012/09/11 yangmj 障害・改良対応（７月リリース案件）</br>
        /// <br>管理番号    : 10707327-00 PM1203G</br> 							
        /// <br>              Redmine32095 商品在庫一括登録修正で「全ての価格情報が消える」</br> 		 
        //private void StockCompleteDelete(int rowIndex)
        private int StockCompleteDelete(int rowIndex)
        {
            // --- DEL 2009/02/23 -------------------------------->>>>>
            //// 注意文言表示
            //DialogResult dialogResult = TMsgDisp.Show(
            //        this,
            //        emErrorLevel.ERR_LEVEL_QUESTION,
            //        this.Name,
            //        "選択した在庫を完全削除します。" + "\r\n" + "\r\n" +
            //        "よろしいですか？",
            //        0,
            //        MessageBoxButtons.YesNo,
            //        MessageBoxDefaultButton.Button1);

            //if (dialogResult != DialogResult.Yes)
            //{
            //    return;
            //}
            // --- DEL 2009/02/23 --------------------------------<<<<<

            string goodsNo = this.uGrid_Details.Rows[rowIndex].Cells[this._goodsStockDataTable.GoodsNoColumn.ColumnName].Value.ToString();
            int goodsMakerCd = (int)this.uGrid_Details.Rows[rowIndex].Cells[this._goodsStockDataTable.GoodsMakerColumn.ColumnName].Value;
            string warehouseCd = this.uGrid_Details.Rows[rowIndex].Cells[this._goodsStockDataTable.WarehouseCodeColumn.ColumnName].Value.ToString();


            int status = this._goodsStockAcs.StockCompleteDelete(goodsNo, goodsMakerCd, warehouseCd);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // --- DEL 2009/02/23 -------------------------------->>>>>
                //TMsgDisp.Show(
                //    this,
                //    emErrorLevel.ERR_LEVEL_INFO,
                //    this.Name,
                //    "完全削除しました。",
                //    0,
                //    MessageBoxButtons.OK);
                // --- DEL 2009/02/23 --------------------------------<<<<<
                // --- DEL 2009/03/03 -------------------------------->>>>>
                //// 商品在庫テーブルより削除
                //for (int i = this._goodsStockDataTable.Rows.Count - 1; i >= 0; i--)
                //{
                //    DataRow dr = this._goodsStockDataTable.Rows[i];

                //    if (dr[this._goodsStockDataTable.GoodsNoColumn.ColumnName].ToString() == goodsNo
                //        && (int)dr[this._goodsStockDataTable.GoodsMakerColumn.ColumnName] == goodsMakerCd
                //        && dr[this._goodsStockDataTable.WarehouseCodeColumn.ColumnName].ToString() == warehouseCd)
                //    {
                //        this._goodsStockDataTable.Rows.RemoveAt(i);
                //    }
                //}

                //// 更新用テーブルも同様に更新
                //for (int i = this._goodsStockAcs.OriginalGoodsStockDataTable.Rows.Count - 1; i >= 0; i--)
                //{
                //    DataRow dr = this._goodsStockAcs.OriginalGoodsStockDataTable.Rows[i];

                //    if (dr[this._goodsStockDataTable.GoodsNoColumn.ColumnName].ToString() == goodsNo
                //        && (int)dr[this._goodsStockDataTable.GoodsMakerColumn.ColumnName] == goodsMakerCd
                //        && dr[this._goodsStockDataTable.WarehouseCodeColumn.ColumnName].ToString() == warehouseCd)
                //    {
                //        this._goodsStockAcs.OriginalGoodsStockDataTable.Rows.RemoveAt(i);
                //    }
                //}
                // --- DEL 2009/03/03 --------------------------------<<<<<
                // --- ADD 2009/03/05 -------------------------------->>>>>
                // 削除対象行以外で同商品がある場合は行削除、なければ在庫情報のみ削除
                StringBuilder filSb = new StringBuilder();
                //----- ADD YANGMJ 2012/09/11 REDMINE#32095 ----->>>>>
                if (goodsNo.Contains("'"))
                {
                    goodsNo = goodsNo.Replace("'", "''");
                }
                //----- ADD YANGMJ 2012/09/11 REDMINE#32095 -----<<<<<
                filSb.Append(this._goodsStockDataTable.GoodsNoColumn.ColumnName);
                filSb.Append(" = '");
                filSb.Append(goodsNo);
                filSb.Append("' AND ");
                filSb.Append(this._goodsStockDataTable.GoodsMakerColumn.ColumnName);
                filSb.Append(" = ");
                filSb.Append(goodsMakerCd);

                DataRow[] deleteRowList = this._goodsStockDataTable.Select(filSb.ToString());

                int stockStartIndex = this.uGrid_Details.DisplayLayout.Bands[0]
                                .Columns[this._goodsStockDataTable.UpRateColumn.ColumnName].Index + 1;
                int stockEndIndex = this.uGrid_Details.DisplayLayout.Bands[0]
                                .Columns[this._goodsStockDataTable.StockUnitPriceFlColumn.ColumnName].Index; // ADD 2009/03/10

                if (this.BeforeSearchExtractInfo.TargetDiv != ExtractInfo.TargetDivState.Stock // ADD 2009/03/05
                    && deleteRowList.Length == 1)
                {
                    DataRow dr = deleteRowList[0];
                    
                    // 在庫のみ削除
                    // 論理削除関連
                    dr[this._goodsStockDataTable.StockLogicalDeleteFlgColumn.ColumnName] = 0;
                    dr[this._goodsStockDataTable.StockDeleteReserveFlgColumn.ColumnName] = 0;
                    dr[this._goodsStockDataTable.StockDeleteDateColumn.ColumnName] = DBNull.Value;
                    
                    // UP率以降の在庫関連項目を初期化
                    for (int i = stockStartIndex; i <= stockEndIndex; i++)
                    {
                        if (dr[i].GetType() == typeof(Int32)
                            || dr[i].GetType() == typeof(double))
                        {
                            dr[i] = 0;
                        }
                        else
                        {
                            dr[i] = DBNull.Value;
                        }

                        // グリッドを編集可能にする
                        this.uGrid_Details.Rows[rowIndex].Cells[i].Activation = Activation.AllowEdit;
                    }
                }
                else if (this.BeforeSearchExtractInfo.TargetDiv == ExtractInfo.TargetDivState.Stock // ADD 2009/03/05
                    || deleteRowList.Length > 1)
                {
                    // 行ごと削除
                    foreach (DataRow dr in deleteRowList)
                    {
                        if (dr[this._goodsStockDataTable.WarehouseCodeColumn.ColumnName].ToString() == warehouseCd)
                        {
                            this._goodsStockDataTable.Rows.Remove(dr);
                            break;
                        }
                    }
                }

                // 更新用テーブルも同様に更新
                DataRow[] originalDeleteRowList = this._goodsStockAcs.OriginalGoodsStockDataTable.Select(filSb.ToString());

                if (originalDeleteRowList.Length == 1)
                {
                    DataRow dr = originalDeleteRowList[0];

                    // 在庫のみ削除
                    // 論理削除関連
                    dr[this._goodsStockDataTable.StockLogicalDeleteFlgColumn.ColumnName] = 0;
                    dr[this._goodsStockDataTable.StockDeleteReserveFlgColumn.ColumnName] = 0;
                    dr[this._goodsStockDataTable.StockDeleteDateColumn.ColumnName] = DBNull.Value;

                    // UP率以降の在庫関連項目
                    for (int i = stockStartIndex; i <= stockEndIndex; i++)
                    {
                        if (dr[i].GetType() == typeof(Int32)
                            || dr[i].GetType() == typeof(double))
                        {
                            dr[i] = 0;
                        }
                        else
                        {
                            dr[i] = DBNull.Value;
                        }
                    }
                }
                else if (originalDeleteRowList.Length > 1)
                {
                    // 行ごと削除
                    foreach (DataRow dr in originalDeleteRowList)
                    {
                        if (dr[this._goodsStockDataTable.WarehouseCodeColumn.ColumnName].ToString() == warehouseCd)
                        {
                            this._goodsStockAcs.OriginalGoodsStockDataTable.Rows.Remove(dr);
                            break;
                        }
                    }
                }
                // --- ADD 2009/03/05 --------------------------------<<<<<

                // 論理削除行を再フィルタ
                //this.SetGridFiltering(); // DEL 2009/02/23
            }
            // --- ADD 2009/02/02 -------------------------------->>>>>
            else
            {
                switch (status)
                {

                    case (int)ConstantManagement.DB_Status.ctDB_ENT_LOCK_TIMEOUT:
                        {
                            TMsgDisp.Show(this,
                                emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                this.Name,
                                "シェアチェックエラー(企業ロック)です。" + "\r\n"
                                + "月次処理か、その他の業務を行っているため本処理は行えません。" + "\r\n"
                                + "再試行するか、しばらく待ってから再度処理を行ってください。",
                                status,
                                MessageBoxButtons.OK);

                            break;
                        }
                    case (int)ConstantManagement.DB_Status.ctDB_SEC_LOCK_TIMEOUT:
                        {
                            TMsgDisp.Show(this,
                                emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                this.Name,
                                "シェアチェックエラー(拠点ロック)です。" + "\r\n"
                                + "締処理か、処理が込み合っているためタイムアウトしました。" + "\r\n"
                                + "再試行するか、しばらく待ってから再度処理を行ってください。",
                                status,
                                MessageBoxButtons.OK);

                            break;
                        }
                    case (int)ConstantManagement.DB_Status.ctDB_WAR_LOCK_TIMEOUT:
                        {
                            TMsgDisp.Show(this,
                                emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                this.Name,
                                "シェアチェックエラー(倉庫ロック)です。" + "\r\n"
                                + "棚卸処理か、その他の在庫業務を行っているためタイムアウトしました。" + "\r\n"
                                + "再試行するか、しばらく待ってから再度処理を行ってください。",
                                status,
                                MessageBoxButtons.OK);

                            break;
                        }
                    default:
                        {
                            TMsgDisp.Show(this,
                                emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                this.Name,
                                "完全削除処理でエラーが発生しました。",
                                status,
                                MessageBoxButtons.OK);

                            break;
                        }
                }
            }
            // --- ADD 2009/02/02 --------------------------------<<<<<

            return status; // ADD 2009/02/23
        }
        #endregion

        #region ■ 復活処理

        /// <summary>
        /// 復活メイン処理
        /// </summary>
        /// <param name="rowIndex">グリッド上の対象行</param>
        //private void GoodsReviveMain(int rowIndex) // DEL 2009/02/23
        private void GoodsReviveMain() // ADD 2009/02/23
        {
            // --- DEL 2009/02/23 -------------------------------->>>>>
            //if (this._beforeSearchExtractInfo.DisplayDiv == ExtractInfo.DisplayDivState.New)
            //{
            //    // 削除予約キャンセル処理
            //    this.GoodsDeleteReserveCancel(rowIndex);
            //}
            //else
            //{
            //    if ((int)this.uGrid_Details.Rows[rowIndex].Cells[this._goodsStockDataTable.GoodsLogicalDeleteFlgColumn.ColumnName].Value == 1)
            //    {
            //        // 商品が論理削除済の場合、復活処理
            //        this.GoodsRevive(rowIndex);
            //    }
            //    else if ((int)this.uGrid_Details.Rows[rowIndex].Cells[this._goodsStockDataTable.GoodsLogicalDeleteFlgColumn.ColumnName].Value == 0)
            //    {
            //        // 削除予約キャンセル処理
            //        this.GoodsDeleteReserveCancel(rowIndex);
            //    }
            //}
            // --- DEL 2009/02/23 --------------------------------<<<<<

            // --- ADD 2009/02/23 -------------------------------->>>>>
            List<int> rowIndexList = this.GetSelectRowIndex();

            if (rowIndexList.Count == 0)
            {
                // 選択行、アクティブセルが無い場合、処理なし
                return;
            }

            if (this._includeGoodsLogicalDeleted)
            {
                // 復活を含む場合は警告を表示
                DialogResult dialogResult = TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_QUESTION,
                        this.Name,
                        "選択した商品のうち、削除済みデータを復活します。" + "\r\n" + "\r\n" +
                        "よろしいですか？",
                        0,
                        MessageBoxButtons.YesNo,
                        MessageBoxDefaultButton.Button1);

                if (dialogResult != DialogResult.Yes)
                {
                    return;
                }
            }

            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            // 処理済商品リスト
            Dictionary<string, List<int>> revivedDic = new Dictionary<string, List<int>>();

            foreach (int rowIndex in rowIndexList)
            {
                if (revivedDic.ContainsKey(this.uGrid_Details.Rows[rowIndex].Cells[this._goodsStockDataTable.GoodsNoColumn.ColumnName].Value.ToString())
                    && revivedDic[this.uGrid_Details.Rows[rowIndex].Cells[this._goodsStockDataTable.GoodsNoColumn.ColumnName].Value.ToString()]
                    .Contains((int)this.uGrid_Details.Rows[rowIndex].Cells[this._goodsStockDataTable.GoodsMakerColumn.ColumnName].Value))
                {
                    // 処理済み
                    continue;
                }

                if ((int)this.uGrid_Details.Rows[rowIndex].Cells[this._goodsStockDataTable.GoodsLogicalDeleteFlgColumn.ColumnName].Value == 1)
                {
                    // 商品が論理削除済の場合、復活処理
                    status = this.GoodsRevive(rowIndex);
                }
                else if ((int)this.uGrid_Details.Rows[rowIndex].Cells[this._goodsStockDataTable.GoodsDeleteReserveFlgColumn.ColumnName].Value == 1)
                {
                    // 削除予約キャンセル処理
                    this.GoodsDeleteReserveCancel(rowIndex);
                }
                else
                {
                    continue;
                }

                // 処理済リストの作成
                if (revivedDic.ContainsKey(this.uGrid_Details.Rows[rowIndex].Cells[this._goodsStockDataTable.GoodsNoColumn.ColumnName].Value.ToString()))
                {
                    revivedDic[this.uGrid_Details.Rows[rowIndex].Cells[this._goodsStockDataTable.GoodsNoColumn.ColumnName].Value.ToString()]
                        .Add((int)this.uGrid_Details.Rows[rowIndex].Cells[this._goodsStockDataTable.GoodsMakerColumn.ColumnName].Value);
                }
                else
                {
                    List<int> makerList = new List<int>();
                    makerList.Add((int)this.uGrid_Details.Rows[rowIndex].Cells[this._goodsStockDataTable.GoodsMakerColumn.ColumnName].Value);

                    revivedDic.Add(this.uGrid_Details.Rows[rowIndex].Cells[this._goodsStockDataTable.GoodsNoColumn.ColumnName].Value.ToString(), makerList);
                }
            }

            if (this._includeGoodsLogicalDeleted
                && status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // 完全削除行が存在かつ全て正常に完了時はメッセージを表示
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    "復活しました。",
                    0,
                    MessageBoxButtons.OK);
            }

            // 論理削除行を再フィルタ
            this.SetGridFiltering();
            // --- ADD 2009/02/23 --------------------------------<<<<<

        }

        /// <summary>
        /// 商品削除予約キャンセル処理
        /// </summary>
        /// <param name="rowIndex"></param>
        private void GoodsDeleteReserveCancel(int rowIndex)
        {
            // 選択行のキー値を取得
            string goodsNo = this.uGrid_Details.Rows[rowIndex].Cells[this._goodsStockDataTable.GoodsNoColumn.ColumnName].Value.ToString();
            int goodsMakerCd = (int)this.uGrid_Details.Rows[rowIndex].Cells[this._goodsStockDataTable.GoodsMakerColumn.ColumnName].Value;

            // 在庫情報の最初の列インデックス
            int stockColIndex = this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsStockDataTable.WarehouseCodeColumn.ColumnName].Index;

            foreach (UltraGridRow ultraGr in this.uGrid_Details.Rows)
            {
                if (ultraGr.Cells[this._goodsStockDataTable.GoodsNoColumn.ColumnName].Value.ToString() == goodsNo
                    && (int)ultraGr.Cells[this._goodsStockDataTable.GoodsMakerColumn.ColumnName].Value == goodsMakerCd)
                {
                    // 同商品の削除日をクリア
                    // --- ADD 2009/02/05 -------------------------------->>>>>
                    ultraGr.Cells[this._goodsStockDataTable.GoodsDeleteReserveFlgColumn.ColumnName].Value = 0;
                    // --- ADD 2009/02/05 --------------------------------<<<<<

                    ultraGr.Cells[this._goodsStockDataTable.GoodsDeleteDateColumn.ColumnName].Value = DBNull.Value;

                    if ((int)ultraGr.Cells[this._goodsStockDataTable.StockDeleteReserveFlgColumn.ColumnName].Value != 0) // ADD 2009/03/03
                    {
                        // 商品を編集可能にする
                        for (int i = 0; i < stockColIndex; i++)
                        {
                            // キー値以外を編集可能に
                            if (this.uGrid_Details.DisplayLayout.Bands[0].Columns[i].Key != this._goodsStockDataTable.GoodsNoColumn.ColumnName
                                && this.uGrid_Details.DisplayLayout.Bands[0].Columns[i].Key != this._goodsStockDataTable.GoodsMakerColumn.ColumnName)
                            {
                                ultraGr.Cells[i].Activation = Activation.AllowEdit;
                            }
                        }
                    }
                    else
                    {
                        // 在庫が削除予約ではない場合(検索時在庫のない行のみ)、全て編集可能に
                        // 商品を編集可能にする
                        for (int i = 0; i < this.uGrid_Details.DisplayLayout.Bands[0].Columns.Count; i++)
                        {
                            // キー値以外を編集可能に
                            if (this.uGrid_Details.DisplayLayout.Bands[0].Columns[i].Key != this._goodsStockDataTable.GoodsNoColumn.ColumnName
                                && this.uGrid_Details.DisplayLayout.Bands[0].Columns[i].Key != this._goodsStockDataTable.GoodsMakerColumn.ColumnName)
                            {
                                ultraGr.Cells[i].Activation = Activation.AllowEdit;
                            }
                        }
                    }

                }
            }

            // --- DEL 2009/02/23 -------------------------------->>>>>
            //// 背景色設定
            //this.SetGridColorRow(this.uGrid_Details.Rows[rowIndex]);

            //// 論理削除行を再フィルタ
            //this.SetGridFiltering();
            // --- DEL 2009/02/23 --------------------------------<<<<<
        }

        /// <summary>
        /// 商品復活処理
        /// </summary>
        //private void GoodsRevive(int rowIndex) // DEL 2009/02/23
        private int GoodsRevive(int rowIndex) // ADD 2009/02/23
        {
            // --- DEL 2009/02/23 -------------------------------->>>>>
            //// 注意文言表示
            //DialogResult dialogResult = TMsgDisp.Show(
            //        this,
            //        emErrorLevel.ERR_LEVEL_QUESTION,
            //        this.Name,
            //        "選択した商品を復活します。" + "\r\n" + "\r\n" +
            //        "よろしいですか？",
            //        0,
            //        MessageBoxButtons.YesNo,
            //        MessageBoxDefaultButton.Button1);

            //if (dialogResult != DialogResult.Yes)
            //{
            //    return;
            //}
            // --- DEL 2009/02/23 --------------------------------<<<<<

            string goodsNo = this.uGrid_Details.Rows[rowIndex].Cells[this._goodsStockDataTable.GoodsNoColumn.ColumnName].Value.ToString();
            int goodsMakerCd = (int)this.uGrid_Details.Rows[rowIndex].Cells[this._goodsStockDataTable.GoodsMakerColumn.ColumnName].Value;

            // 復活実行
            int status = this._goodsStockAcs.GoodsRevive(goodsNo, goodsMakerCd);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // --- DEL 2009/02/23 -------------------------------->>>>>
                //TMsgDisp.Show(
                //    this,
                //    emErrorLevel.ERR_LEVEL_INFO,
                //    this.Name,
                //    "復活しました。",
                //    0,
                //    MessageBoxButtons.OK);
                // --- DEL 2009/02/23 --------------------------------<<<<<

                // 商品論理削除の値を更新
                foreach (DataRow dr in this._goodsStockDataTable.Rows)
                {
                    if (dr[this._goodsStockDataTable.GoodsNoColumn.ColumnName].ToString() == goodsNo
                        && (int)dr[this._goodsStockDataTable.GoodsMakerColumn.ColumnName] == goodsMakerCd)
                    {
                        dr[this._goodsStockDataTable.GoodsLogicalDeleteFlgColumn.ColumnName] = 0;
                        dr[this._goodsStockDataTable.GoodsDeleteReserveFlgColumn.ColumnName] = 0; // ADD 2009/02/05
                        dr[this._goodsStockDataTable.GoodsDeleteDateColumn.ColumnName] = DBNull.Value;

                        dr[this._goodsStockDataTable.RowNumberColumn.ColumnName] = "復活"; // ADD 2009/03/06
                    }
                }

                // 更新用テーブルも同様に更新
                foreach (DataRow originalDr in this._goodsStockAcs.OriginalGoodsStockDataTable.Rows)
                {
                    if (originalDr[this._goodsStockDataTable.GoodsNoColumn.ColumnName].ToString() == goodsNo
                        && (int)originalDr[this._goodsStockDataTable.GoodsMakerColumn.ColumnName] == goodsMakerCd)
                    {
                        originalDr[this._goodsStockDataTable.GoodsLogicalDeleteFlgColumn.ColumnName] = 0;
                        originalDr[this._goodsStockDataTable.GoodsDeleteReserveFlgColumn.ColumnName] = 0; // ADD 2009/02/05
                        originalDr[this._goodsStockDataTable.GoodsDeleteDateColumn.ColumnName] = DBNull.Value;

                        originalDr[this._goodsStockDataTable.RowNumberColumn.ColumnName] = "復活"; // ADD 2009/03/06
                    }
                }

                // 商品情報のみ編集可能に
                int stockColIndex = this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsStockDataTable.WarehouseCodeColumn.ColumnName].Index;

                foreach (UltraGridRow ultraRow in this.uGrid_Details.Rows)
                {
                    if (ultraRow.Cells[this._goodsStockDataTable.GoodsNoColumn.ColumnName].Value.ToString() == goodsNo
                        && (int)ultraRow.Cells[this._goodsStockDataTable.GoodsMakerColumn.ColumnName].Value == goodsMakerCd)
                    {
                        for (int i = 0; i < stockColIndex; i++)
                        {
                            // キー値以外を編集可能に
                            if (this.uGrid_Details.DisplayLayout.Bands[0].Columns[i].Key != this._goodsStockDataTable.GoodsNoColumn.ColumnName
                                && this.uGrid_Details.DisplayLayout.Bands[0].Columns[i].Key != this._goodsStockDataTable.GoodsMakerColumn.ColumnName)
                            {
                                ultraRow.Cells[i].Activation = Activation.AllowEdit;
                            }
                        }
                    }
                }

                // --- DEL 2009/02/23 -------------------------------->>>>>
                //// 背景色設定
                //this.SetGridColorRow(this.uGrid_Details.Rows[rowIndex]);

                //// 論理削除行を再フィルタ
                //this.SetGridFiltering();
                // --- DEL 2009/02/23 --------------------------------<<<<<
            }
            // --- ADD 2009/02/02 -------------------------------->>>>>
            else
            {
                switch (status)
                {

                    case (int)ConstantManagement.DB_Status.ctDB_ENT_LOCK_TIMEOUT:
                        {
                            TMsgDisp.Show(this,
                                emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                this.Name,
                                "シェアチェックエラー(企業ロック)です。" + "\r\n"
                                + "月次処理か、その他の業務を行っているため本処理は行えません。" + "\r\n"
                                + "再試行するか、しばらく待ってから再度処理を行ってください。",
                                status,
                                MessageBoxButtons.OK);

                            break;
                        }
                    case (int)ConstantManagement.DB_Status.ctDB_SEC_LOCK_TIMEOUT:
                        {
                            TMsgDisp.Show(this,
                                emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                this.Name,
                                "シェアチェックエラー(拠点ロック)です。" + "\r\n"
                                + "締処理か、処理が込み合っているためタイムアウトしました。" + "\r\n"
                                + "再試行するか、しばらく待ってから再度処理を行ってください。",
                                status,
                                MessageBoxButtons.OK);

                            break;
                        }
                    case (int)ConstantManagement.DB_Status.ctDB_WAR_LOCK_TIMEOUT:
                        {
                            TMsgDisp.Show(this,
                                emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                this.Name,
                                "シェアチェックエラー(倉庫ロック)です。" + "\r\n"
                                + "棚卸処理か、その他の在庫業務を行っているためタイムアウトしました。" + "\r\n"
                                + "再試行するか、しばらく待ってから再度処理を行ってください。",
                                status,
                                MessageBoxButtons.OK);

                            break;
                        }
                    default:
                        {
                            TMsgDisp.Show(this,
                                emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                this.Name,
                                "復活処理でエラーが発生しました。",
                                status,
                                MessageBoxButtons.OK);

                            break;
                        }
                }
            }
            // --- ADD 2009/02/02 --------------------------------<<<<<

            return status; // ADD 2009/02/23
        }

        /// <summary>
        /// 在庫復活メイン処理
        /// </summary>
        /// <param name="rowIndex">対象行</param>
        //private void StockReviveMain(int rowIndex) // DEL 2009/02/23
        private void StockReviveMain() // ADD 2009/02/23
        {
            // --- DEL 2009/02/23 -------------------------------->>>>>
            //if (this._beforeSearchExtractInfo.DisplayDiv == ExtractInfo.DisplayDivState.New)
            //{
            //    // 新規登録の場合、在庫復活は押下不可
            //    return;
            //}
            //else
            //{
            //    if ((int)this.uGrid_Details.Rows[rowIndex].Cells[this._goodsStockDataTable.StockLogicalDeleteFlgColumn.ColumnName].Value == 1)
            //    {
            //        // 在庫が論理削除済の場合、復活処理
            //        this.StockRevive(rowIndex);
            //    }
            //    else if ((int)this.uGrid_Details.Rows[rowIndex].Cells[this._goodsStockDataTable.StockLogicalDeleteFlgColumn.ColumnName].Value == 0)
            //    {
            //        // 削除予約キャンセル処理
            //        this.StockDeleteReserveCancel(rowIndex);
            //    }
            //}
            // --- DEL 2009/02/23 --------------------------------<<<<<
            // --- ADD 2009/02/23 -------------------------------->>>>>
            List<int> rowIndexList = this.GetSelectRowIndex();

            if (rowIndexList.Count == 0)
            {
                // 選択行、アクティブセルが無い場合、処理なし
                return;
            }

            if (this._includeStockLogicalDeleted)
            {
                // 復活を含む場合は警告を表示
                DialogResult dialogResult = TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_QUESTION,
                        this.Name,
                        "選択した在庫のうち、削除済みデータを復活します。" + "\r\n" + "\r\n" +
                        "よろしいですか？",
                        0,
                        MessageBoxButtons.YesNo,
                        MessageBoxDefaultButton.Button1);

                if (dialogResult != DialogResult.Yes)
                {
                    return;
                }
            }

            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            foreach (int rowIndex in rowIndexList)
            {
                if ((int)this.uGrid_Details.Rows[rowIndex].Cells[this._goodsStockDataTable.GoodsLogicalDeleteFlgColumn.ColumnName].Value != 0
                    || (int)this.uGrid_Details.Rows[rowIndex].Cells[this._goodsStockDataTable.GoodsDeleteReserveFlgColumn.ColumnName].Value != 0)
                {
                    // 商品が論理削除済または削除予約行の場合、在庫は復活しない
                    continue;
                }

                if ((int)this.uGrid_Details.Rows[rowIndex].Cells[this._goodsStockDataTable.StockLogicalDeleteFlgColumn.ColumnName].Value == 1)
                {
                    // 在庫が論理削除済の場合、復活処理
                    status = this.StockRevive(rowIndex);
                }
                else if ((int)this.uGrid_Details.Rows[rowIndex].Cells[this._goodsStockDataTable.StockDeleteReserveFlgColumn.ColumnName].Value == 1)
                {
                    // 削除予約キャンセル処理
                    this.StockDeleteReserveCancel(rowIndex);
                }
            }

            if (this._includeStockLogicalDeleted
                && status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // 完全削除行が存在かつ全て正常に完了時はメッセージを表示
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    "復活しました。",
                    0,
                    MessageBoxButtons.OK);
            }

            // 論理削除行を再フィルタ
            this.SetGridFiltering();
            // --- ADD 2009/02/23 --------------------------------<<<<<
        }

        /// <summary>
        /// 在庫削除予約キャンセル処理
        /// </summary>
        /// <param name="rowIndex"></param>
        private void StockDeleteReserveCancel(int rowIndex)
        {
            this.uGrid_Details.Rows[rowIndex].Cells[this._goodsStockDataTable.StockDeleteReserveFlgColumn.ColumnName].Value = 0; // ADD 2009/02/05
            this.uGrid_Details.Rows[rowIndex].Cells[this._goodsStockDataTable.StockDeleteDateColumn.ColumnName].Value = DBNull.Value;

            int stockColIndex = this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsStockDataTable.WarehouseCodeColumn.ColumnName].Index;

            for (int i = stockColIndex; i < this.uGrid_Details.DisplayLayout.Bands[0].Columns.Count; i++)
            {
                // キー値以外を編集可能に
                if (this.uGrid_Details.DisplayLayout.Bands[0].Columns[i].Key != this._goodsStockDataTable.WarehouseCodeColumn.ColumnName)
                {
                    this.uGrid_Details.Rows[rowIndex].Cells[i].Activation = Activation.AllowEdit;
                }
            }

            // --- DEL 2009/02/23 -------------------------------->>>>>
            //// 背景色設定
            //this.SetGridColorRow(this.uGrid_Details.Rows[rowIndex]);

            //// 論理削除行を再フィルタ
            //this.SetGridFiltering();
            // --- DEL 2009/02/23 --------------------------------<<<<<
        }

        /// <summary>
        /// 在庫復活処理
        /// </summary>
        //private void StockRevive(int rowIndex) // DEL 2009/02/23
        private int StockRevive(int rowIndex) // ADD 2009/02/23
        {
            // --- DEL 2009/02/23 -------------------------------->>>>>
            //// 注意文言表示
            //DialogResult dialogResult = TMsgDisp.Show(
            //        this,
            //        emErrorLevel.ERR_LEVEL_QUESTION,
            //        this.Name,
            //        "選択した在庫を復活します。" + "\r\n" + "\r\n" +
            //        "よろしいですか？",
            //        0,
            //        MessageBoxButtons.YesNo,
            //        MessageBoxDefaultButton.Button1);

            //if (dialogResult != DialogResult.Yes)
            //{
            //    return;
            //}
            // --- DEL 2009/02/23 --------------------------------<<<<<

            string goodsNo = this.uGrid_Details.Rows[rowIndex].Cells[this._goodsStockDataTable.GoodsNoColumn.ColumnName].Value.ToString();
            int goodsMakerCd = (int)this.uGrid_Details.Rows[rowIndex].Cells[this._goodsStockDataTable.GoodsMakerColumn.ColumnName].Value;
            string warehouseCd = this.uGrid_Details.Rows[rowIndex].Cells[this._goodsStockDataTable.WarehouseCodeColumn.ColumnName].Value.ToString();

            int status = this._goodsStockAcs.StockRevive(goodsNo, goodsMakerCd, warehouseCd);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // --- DEL 2009/02/23 -------------------------------->>>>>
                //TMsgDisp.Show(
                //    this,
                //    emErrorLevel.ERR_LEVEL_INFO,
                //    this.Name,
                //    "復活しました。",
                //    0,
                //    MessageBoxButtons.OK);
                // --- DEL 2009/02/23 --------------------------------<<<<<

                // 在庫論理削除の値を更新
                foreach (DataRow dr in this._goodsStockDataTable.Rows)
                {
                    if (dr[this._goodsStockDataTable.GoodsNoColumn.ColumnName].ToString() == goodsNo
                        && (int)dr[this._goodsStockDataTable.GoodsMakerColumn.ColumnName] == goodsMakerCd
                        && dr[this._goodsStockDataTable.WarehouseCodeColumn.ColumnName].ToString() == warehouseCd)
                    {
                        dr[this._goodsStockDataTable.StockLogicalDeleteFlgColumn.ColumnName] = 0;
                        dr[this._goodsStockDataTable.StockDeleteReserveFlgColumn.ColumnName] = 0; // ADD 2009/02/05
                        dr[this._goodsStockDataTable.StockDeleteDateColumn.ColumnName] = DBNull.Value;

                        dr[this._goodsStockDataTable.RowNumberColumn.ColumnName] = "復活"; // ADD 2009/03/06

                        break;
                    }
                }

                // 更新用テーブルも同様に更新
                foreach (DataRow originalDr in this._goodsStockAcs.OriginalGoodsStockDataTable.Rows)
                {
                    if (originalDr[this._goodsStockDataTable.GoodsNoColumn.ColumnName].ToString() == goodsNo
                        && (int)originalDr[this._goodsStockDataTable.GoodsMakerColumn.ColumnName] == goodsMakerCd
                        && originalDr[this._goodsStockDataTable.WarehouseCodeColumn.ColumnName].ToString() == warehouseCd)
                    {
                        originalDr[this._goodsStockDataTable.StockLogicalDeleteFlgColumn.ColumnName] = 0;
                        originalDr[this._goodsStockDataTable.StockDeleteReserveFlgColumn.ColumnName] = 0; // ADD 2009/02/05
                        originalDr[this._goodsStockDataTable.StockDeleteDateColumn.ColumnName] = DBNull.Value;

                        originalDr[this._goodsStockDataTable.RowNumberColumn.ColumnName] = "復活"; // ADD 2009/03/06
                    }
                }

                // 在庫情報のみ編集可能に
                int stockColIndex = this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsStockDataTable.WarehouseCodeColumn.ColumnName].Index;

                foreach (UltraGridRow ultraRow in this.uGrid_Details.Rows)
                {
                    if (ultraRow.Cells[this._goodsStockDataTable.GoodsNoColumn.ColumnName].Value.ToString() == goodsNo
                        && (int)ultraRow.Cells[this._goodsStockDataTable.GoodsMakerColumn.ColumnName].Value == goodsMakerCd
                        && ultraRow.Cells[this._goodsStockDataTable.WarehouseCodeColumn.ColumnName].Value.ToString() == warehouseCd)
                    {
                        for (int i = stockColIndex; i < ultraRow.Cells.Count; i++)
                        {
                            // キー値以外を編集可能に
                            if (this.uGrid_Details.DisplayLayout.Bands[0].Columns[i].Key != this._goodsStockDataTable.WarehouseCodeColumn.ColumnName)
                            {
                                ultraRow.Cells[i].Activation = Activation.AllowEdit;
                            }
                        }
                    }
                }

                // --- DEL 2009/02/23 -------------------------------->>>>>
                //// 背景色設定
                //this.SetGridColorRow(this.uGrid_Details.Rows[rowIndex]);

                //// 論理削除行を再フィルタ
                //this.SetGridFiltering();
                // --- DEL 2009/02/23 --------------------------------<<<<<
            }
            // --- ADD 2009/02/02 -------------------------------->>>>>
            else
            {
                switch (status)
                {

                    case (int)ConstantManagement.DB_Status.ctDB_ENT_LOCK_TIMEOUT:
                        {
                            TMsgDisp.Show(this,
                                emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                this.Name,
                                "シェアチェックエラー(企業ロック)です。" + "\r\n"
                                + "月次処理か、その他の業務を行っているため本処理は行えません。" + "\r\n"
                                + "再試行するか、しばらく待ってから再度処理を行ってください。",
                                status,
                                MessageBoxButtons.OK);

                            break;
                        }
                    case (int)ConstantManagement.DB_Status.ctDB_SEC_LOCK_TIMEOUT:
                        {
                            TMsgDisp.Show(this,
                                emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                this.Name,
                                "シェアチェックエラー(拠点ロック)です。" + "\r\n"
                                + "締処理か、処理が込み合っているためタイムアウトしました。" + "\r\n"
                                + "再試行するか、しばらく待ってから再度処理を行ってください。",
                                status,
                                MessageBoxButtons.OK);

                            break;
                        }
                    case (int)ConstantManagement.DB_Status.ctDB_WAR_LOCK_TIMEOUT:
                        {
                            TMsgDisp.Show(this,
                                emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                this.Name,
                                "シェアチェックエラー(倉庫ロック)です。" + "\r\n"
                                + "棚卸処理か、その他の在庫業務を行っているためタイムアウトしました。" + "\r\n"
                                + "再試行するか、しばらく待ってから再度処理を行ってください。",
                                status,
                                MessageBoxButtons.OK);

                            break;
                        }
                    default:
                        {
                            TMsgDisp.Show(this,
                                emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                this.Name,
                                "復活処理でエラーが発生しました。", // ADD 2009/03/03
                                status,
                                MessageBoxButtons.OK);

                            break;
                        }
                }
            }
            // --- ADD 2009/02/02 --------------------------------<<<<<

            return status; // ADD 2009/02/23
        }
        #endregion

        #region ■ 商品追加処理
        /// <summary>
        /// 商品追加メイン処理
        /// </summary>
        /// <param name="rowIndex"></param>
        //private void AddNewRowMain(int rowIndex) // DEL 2009/02/23
        private void AddNewRowMain() // ADD 2009/02/23
        {
            //DataRow newDr = this._goodsStockAcs.GoodsStockDataTable.NewRow(); // DEL 2009/02/23
            DataRow newDr; // ADD 2009/02/23

            if (this._beforeSearchExtractInfo.DisplayDiv == ExtractInfo.DisplayDivState.New
                && this._beforeSearchExtractInfo.TargetDiv == ExtractInfo.TargetDivState.Goods)
            {
                // 商品追加
                newDr = this._goodsStockAcs.GoodsStockDataTable.NewRow(); // ADD 2009/02/23

                // 最終行に追加する
                this._goodsStockAcs.GoodsStockDataTable.Rows.Add(newDr);

                // --- ADD 2009/02/03 -------------------------------->>>>>
                // フォーカス設定
                int activationCol;
                int activationRow;

                string nextFocusColumnKey = this.GetNextFocusColumnKey(0, this._goodsStockAcs.GoodsStockDataTable.Rows.Count - 1, false, out activationCol, out activationRow);

                if (nextFocusColumnKey != string.Empty)
                {
                    this.uGrid_Details.Rows[activationRow].Cells[nextFocusColumnKey].Activate();
                    this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                }
                else
                {
                    // (ありえないが)無い場合は行アクティブ
                    this.uGrid_Details.Rows[this._goodsStockAcs.GoodsStockDataTable.Rows.Count - 1].Activate();
                }
                // --- ADD 2009/02/03 --------------------------------<<<<<

                this.SetGridColorAll(); // 背景色再設定 // ADD 2009/03/05
            }
            else if (this._beforeSearchExtractInfo.DisplayDiv == ExtractInfo.DisplayDivState.Update
                && this._beforeSearchExtractInfo.TargetDiv == ExtractInfo.TargetDivState.GoodsStock)
            {

                // --- DEL 2009/02/23 -------------------------------->>>>>
                #region 削除
                //if (rowIndex == -1)
                //{
                //    // Active行が無い場合は追加しない
                //    return;
                //}

                //// 在庫追加
                //// 在庫が無い(倉庫コードの入力が無い)場合は、追加しない(ボタン押下可否で制御)
                //if (this.uGrid_Details.Rows[rowIndex].Cells[this._goodsStockDataTable.WarehouseCodeColumn.ColumnName].Value != null
                //    && this.uGrid_Details.Rows[rowIndex].Cells[this._goodsStockDataTable.WarehouseCodeColumn.ColumnName].Value != DBNull.Value)
                //{
                //    // ソート、フィルタ状態の確認
                //    SortedColumnsCollection sr = this.uGrid_Details.DisplayLayout.Bands[0].SortedColumns;
                //    ColumnFiltersCollection fr = this.uGrid_Details.DisplayLayout.Bands[0].ColumnFilters;

                //    if (sr.Count != 0 || fr.Count != 0)
                //    {
                //        DialogResult dialogResult = TMsgDisp.Show(
                //            this,
                //            emErrorLevel.ERR_LEVEL_QUESTION,
                //            this.Name,
                //            "現在のフィルタ、ソート条件を破棄してもよろしいですか？",
                //            0,
                //            MessageBoxButtons.YesNo,
                //            MessageBoxDefaultButton.Button1);

                //        if (dialogResult == DialogResult.Yes)
                //        {
                //            // 選択行のキー値を保持
                //            string goodsNo = this.uGrid_Details.Rows[rowIndex].Cells[this._goodsStockDataTable.GoodsNoColumn.ColumnName].Value.ToString();
                //            int goodsMakerCd = (int)this.uGrid_Details.Rows[rowIndex].Cells[this._goodsStockDataTable.GoodsMakerColumn.ColumnName].Value;
                //            string warehouseCd = this.uGrid_Details.Rows[rowIndex].Cells[this._goodsStockDataTable.WarehouseCodeColumn.ColumnName].Value.ToString();

                //            sr.Clear();
                //            sr.RefreshSort(true); // 再ソート実行(trueだと行)
                //            fr.ClearAllFilters();

                //            // ソート解除後のRowIndexを取得
                //            for (int i = 0; i < this.uGrid_Details.Rows.Count; i++)
                //            {
                //                if (this.uGrid_Details.Rows[i].Cells[this._goodsStockDataTable.WarehouseCodeColumn.ColumnName].Value != null
                //                    && this.uGrid_Details.Rows[i].Cells[this._goodsStockDataTable.WarehouseCodeColumn.ColumnName].Value != DBNull.Value)
                //                {
                //                    if (this.uGrid_Details.Rows[i].Cells[this._goodsStockDataTable.GoodsNoColumn.ColumnName].Value.ToString() == goodsNo
                //                        && (int)this.uGrid_Details.Rows[i].Cells[this._goodsStockDataTable.GoodsMakerColumn.ColumnName].Value == goodsMakerCd
                //                        && this.uGrid_Details.Rows[i].Cells[this._goodsStockDataTable.WarehouseCodeColumn.ColumnName].Value.ToString() == warehouseCd)
                //                    {
                //                        rowIndex = i;
                //                        break;
                //                    }
                //                }
                //            }

                //            // 在庫追加の場合、選択行の商品情報をコピー
                //            int goodsLastColIndex = this.uGrid_Details.DisplayLayout.Bands[0]
                //                .Columns[this._goodsStockDataTable.UpRateColumn.ColumnName].Index;

                //            for (int i = 1; i < goodsLastColIndex; i++)
                //            {
                //                newDr[i] = this.uGrid_Details.Rows[rowIndex].Cells[i].Value;
                //            }

                //            // 指定行に追加
                //            this._goodsStockDataTable.Rows.InsertAt(newDr, rowIndex + 1);

                //            // --- ADD 2009/02/04 -------------------------------->>>>>
                //            // 品番とメーカーは変更不能(その他入力不可行は列単位で制御されているのでActivation指定不要)
                //            this.uGrid_Details.Rows[rowIndex + 1].Cells[
                //                this._goodsStockDataTable.GoodsNoColumn.ColumnName].Activation = Activation.Disabled;
                //            this.uGrid_Details.Rows[rowIndex + 1].Cells[
                //                this._goodsStockDataTable.GoodsMakerColumn.ColumnName].Activation = Activation.Disabled;
                //            // --- ADD 2009/02/04 --------------------------------<<<<<

                //            // --- DEL 2009/02/23 -------------------------------->>>>>
                //            //int activationCol;
                //            //int activationRow;

                //            //string nextFocusColumnKey = this.GetNextFocusColumnKey(0, rowIndex + 1, false, out activationCol, out activationRow);

                //            //if (nextFocusColumnKey != string.Empty)
                //            //{
                //            //    this.uGrid_Details.Rows[activationRow].Cells[nextFocusColumnKey].Activate();
                //            //    this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                //            //}
                //            //else
                //            //{
                //            //    // (ありえないが)無い場合は行アクティブ
                //            //    this.uGrid_Details.Rows[rowIndex + 1].Activate();
                //            //}
                //            // --- DEL 2009/02/23 --------------------------------<<<<<

                //            // --- ADD 2009/02/23 -------------------------------->>>>>
                //            // 追加行の倉庫コードにフォーカス
                //            this.uGrid_Details.Rows[rowIndex + 1].Cells[this._goodsStockDataTable.WarehouseCodeColumn.ColumnName].Activate();
                //            this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                //            // --- ADD 2009/02/23 --------------------------------<<<<<

                //            // 論理削除フィルタを再設定
                //            SetGridFiltering();

                //            return;
                //        }
                //        else
                //        {
                //            return;
                //        }
                //    }
                //    else
                //    {
                //        // 在庫追加の場合、選択行の商品情報をコピー
                //        int goodsLastColIndex = this.uGrid_Details.DisplayLayout.Bands[0]
                //            .Columns[this._goodsStockDataTable.UpRateColumn.ColumnName].Index;

                //        for (int i = 1; i < goodsLastColIndex; i++)
                //        {
                //            newDr[i] = this.uGrid_Details.Rows[rowIndex].Cells[i].Value;
                //        }

                //        // 指定行に追加
                //        this._goodsStockDataTable.Rows.InsertAt(newDr, rowIndex + 1);
                //    }
                //}
                #endregion
                // --- DEL 2009/02/23 --------------------------------<<<<<
                // --- ADD 2009/02/23 -------------------------------->>>>>


                //List<int> addRowIndexList = new List<int>();
                //foreach (int selectedRowIndex in selectedRowIndexList)
                //{
                //    // 商品が削除済でないかつ削除予約行でないかつ倉庫コードに入力がある
                //    if ((int)this.uGrid_Details.Rows[selectedRowIndex].Cells[this._goodsStockDataTable.GoodsLogicalDeleteFlgColumn.ColumnName].Value == 0
                //        && (int)this.uGrid_Details.Rows[selectedRowIndex].Cells[this._goodsStockDataTable.GoodsDeleteReserveFlgColumn.ColumnName].Value == 0
                //        && this.uGrid_Details.Rows[selectedRowIndex].Cells[this._goodsStockDataTable.WarehouseCodeColumn.ColumnName].Value != null
                //        && this.uGrid_Details.Rows[selectedRowIndex].Cells[this._goodsStockDataTable.WarehouseCodeColumn.ColumnName].Value != DBNull.Value)
                //    {
                //        addRowIndexList.Add(selectedRowIndex);
                //    }
                //}

                //if (addRowIndexList.Count == 0)
                //{
                //    // 対象行なし(ボタン制御でこのケースは除かれているはず)
                //    return;
                //}

                // ソート、フィルタ状態の確認
                SortedColumnsCollection sr = this.uGrid_Details.DisplayLayout.Bands[0].SortedColumns;
                ColumnFiltersCollection fr = this.uGrid_Details.DisplayLayout.Bands[0].ColumnFilters;

                if (sr.Count != 0 || fr.Count != 0)
                {
                    DialogResult dialogResult = TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_QUESTION,
                        this.Name,
                        //"現在のフィルタ、ソート条件を破棄してもよろしいですか？", // DEL 2009/03/05
                        "明細の表示についてソートや絞り込みを行っている場合、" + "\r\n"
                        + "それらの設定がクリアされますがよろしいでしょうか？", // ADD 2009/03/05
                        0,
                        MessageBoxButtons.YesNo,
                        MessageBoxDefaultButton.Button1);

                    if (dialogResult == DialogResult.Yes)
                    {
                        sr.Clear();
                        sr.RefreshSort(true); // 再ソート実行(trueだと行)
                        fr.ClearAllFilters();
                    }
                    else
                    {
                        return; // ADD 2009/03/03
                    }
                }

                //// 選択行取得(ソートフィルタ解除後のIndexになる)
                //List<int> selectedRowIndexList = this.GetSelectRowIndex(); // DEL 2009/03/03

                // 在庫追加はアクティブ行に対して行う
                int rowIndex = this.uGrid_Details.ActiveRow.Index; // ADD 2009/03/03

                // 在庫カラム開始Index
                int goodsLastColIndex = this.uGrid_Details.DisplayLayout.Bands[0]
                    .Columns[this._goodsStockDataTable.UpRateColumn.ColumnName].Index;

                //for (int rowIndex = selectedRowIndexList.Count - 1; rowIndex >= 0; rowIndex--) // DEL 2009/03/02
                // --- DEL 2009/03/03 -------------------------------->>>>>
                //for (int j = selectedRowIndexList.Count - 1; j >= 0; j--) // ADD 2009/03/02
                //{
                //    int rowIndex = selectedRowIndexList[j]; // ADD 2009/03/02
                // --- DEL 2009/03/03 --------------------------------<<<<<

                //// 商品が削除済でないかつ削除予約行でないかつ倉庫コードに入力がある
                //if ((int)this.uGrid_Details.Rows[rowIndex].Cells[this._goodsStockDataTable.GoodsLogicalDeleteFlgColumn.ColumnName].Value == 0
                //    && (int)this.uGrid_Details.Rows[rowIndex].Cells[this._goodsStockDataTable.GoodsDeleteReserveFlgColumn.ColumnName].Value == 0
                //    && this.uGrid_Details.Rows[rowIndex].Cells[this._goodsStockDataTable.WarehouseCodeColumn.ColumnName].Value != null
                //    && this.uGrid_Details.Rows[rowIndex].Cells[this._goodsStockDataTable.WarehouseCodeColumn.ColumnName].Value != DBNull.Value) // DEL 2009/03/03
                // 商品が削除済でないかつ削除予約行でないかつ同商品で倉庫コードに入力の無いデータがない
                if ((int)this.uGrid_Details.Rows[rowIndex].Cells[this._goodsStockDataTable.GoodsLogicalDeleteFlgColumn.ColumnName].Value == 0
                    && (int)this.uGrid_Details.Rows[rowIndex].Cells[this._goodsStockDataTable.GoodsDeleteReserveFlgColumn.ColumnName].Value == 0
                    && !this.CheckStockNotExist(this.uGrid_Details.Rows[rowIndex].Cells[this._goodsStockDataTable.GoodsNoColumn.ColumnName].Value.ToString(),
                        (int)this.uGrid_Details.Rows[rowIndex].Cells[this._goodsStockDataTable.GoodsMakerColumn.ColumnName].Value))
                {
                    newDr = this._goodsStockAcs.GoodsStockDataTable.NewRow();

                    // 在庫追加の場合、選択行の商品情報をコピー
                    for (int i = 1; i <= goodsLastColIndex; i++)
                    {
                        // 在庫の論理削除、削除予約は除く
                        if (this.uGrid_Details.Rows[rowIndex].Cells[i].Column.Key != this._goodsStockDataTable.StockLogicalDeleteFlgColumn.ColumnName
                            && this.uGrid_Details.Rows[rowIndex].Cells[i].Column.Key != this._goodsStockDataTable.StockDeleteReserveFlgColumn.ColumnName
                            && this.uGrid_Details.Rows[rowIndex].Cells[i].Column.Key != this._goodsStockDataTable.StockDeleteDateColumn.ColumnName) // ADD 2009/03/03
                        {
                            newDr[i] = this.uGrid_Details.Rows[rowIndex].Cells[i].Value;
                        }
                    }

                    // 指定行に追加
                    this._goodsStockDataTable.Rows.InsertAt(newDr, rowIndex + 1);

                    // 品番とメーカーは変更不能(その他入力不可行は列単位で制御されているのでActivation指定不要)
                    this.uGrid_Details.Rows[rowIndex + 1].Cells[
                        this._goodsStockDataTable.GoodsNoColumn.ColumnName].Activation = Activation.Disabled;
                    this.uGrid_Details.Rows[rowIndex + 1].Cells[
                        this._goodsStockDataTable.GoodsMakerColumn.ColumnName].Activation = Activation.Disabled;

                    // 追加行の倉庫コードにフォーカス
                    this.uGrid_Details.Rows[rowIndex + 1].Cells[this._goodsStockDataTable.WarehouseCodeColumn.ColumnName].Activate();
                    this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                }
                //} // DEL 2009/03/03

                // 論理削除フィルタを再設定
                SetGridFiltering();
                // --- ADD 2009/02/23 --------------------------------<<<<<
            }

            // 商品追加後は保存ボタン可
            this.SetSaveButton(); // ADD 2009/02/23
        }
        #endregion

        #region ■ 価格表示制御
        /// <summary>
        /// 価格表示の変更を行う
        /// </summary>
        private void DispPriceMain()
        {
            if (this._beforeSearchExtractInfo.TargetDiv == ExtractInfo.TargetDivState.Stock)
            {
                // 対象区分「在庫」の場合、表示対象ではないので制御なし
                return;
            }

            bool hiddenStat;

            if (this.uGrid_Details.DisplayLayout.Bands[0]
                .Columns[this._goodsStockDataTable.PriceStartDate2Column.ColumnName].Hidden == true)
            {
                hiddenStat = false;
            }
            else
            {
                hiddenStat = true;
            }

            Infragistics.Win.UltraWinGrid.UltraGridBand band = this.uGrid_Details.DisplayLayout.Bands[0];

            // --- UPD 2010/08/11 ---------->>>>>
            //// 価格リスト2、3の表示状態を設定
            //band.Columns[this._goodsStockDataTable.PriceStartDate2Column.ColumnName].Hidden = hiddenStat;
            //band.Columns[this._goodsStockDataTable.ListPrice2Column.ColumnName].Hidden = hiddenStat;
            //band.Columns[this._goodsStockDataTable.OpenPriceDiv2Column.ColumnName].Hidden = hiddenStat;
            //band.Columns[this._goodsStockDataTable.StockRate2Column.ColumnName].Hidden = hiddenStat;
            //band.Columns[this._goodsStockDataTable.SalesUnitCost2Column.ColumnName].Hidden = hiddenStat;
            //band.Columns[this._goodsStockDataTable.PriceStartDate3Column.ColumnName].Hidden = hiddenStat;
            //band.Columns[this._goodsStockDataTable.ListPrice3Column.ColumnName].Hidden = hiddenStat;
            //band.Columns[this._goodsStockDataTable.OpenPriceDiv3Column.ColumnName].Hidden = hiddenStat;
            //band.Columns[this._goodsStockDataTable.StockRate3Column.ColumnName].Hidden = hiddenStat;
            //band.Columns[this._goodsStockDataTable.SalesUnitCost3Column.ColumnName].Hidden = hiddenStat;

            PriceChgSetAcs priceChgSetAcs = new PriceChgSetAcs();
            PriceChgSet priceChgSet = new PriceChgSet();

            int status = priceChgSetAcs.Read(out priceChgSet, this._enterpriseCode);
            
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                switch (priceChgSet.PriceMngCnt)
                {
                    case 3:
                        {
                            // 価格リスト2、3の表示状態を設定
                            band.Columns[this._goodsStockDataTable.PriceStartDate2Column.ColumnName].Hidden = hiddenStat;
                            band.Columns[this._goodsStockDataTable.ListPrice2Column.ColumnName].Hidden = hiddenStat;
                            band.Columns[this._goodsStockDataTable.OpenPriceDiv2Column.ColumnName].Hidden = hiddenStat;
                            band.Columns[this._goodsStockDataTable.StockRate2Column.ColumnName].Hidden = hiddenStat;
                            band.Columns[this._goodsStockDataTable.SalesUnitCost2Column.ColumnName].Hidden = hiddenStat;
                            band.Columns[this._goodsStockDataTable.PriceStartDate3Column.ColumnName].Hidden = hiddenStat;
                            band.Columns[this._goodsStockDataTable.ListPrice3Column.ColumnName].Hidden = hiddenStat;
                            band.Columns[this._goodsStockDataTable.OpenPriceDiv3Column.ColumnName].Hidden = hiddenStat;
                            band.Columns[this._goodsStockDataTable.StockRate3Column.ColumnName].Hidden = hiddenStat;
                            band.Columns[this._goodsStockDataTable.SalesUnitCost3Column.ColumnName].Hidden = hiddenStat;
                            band.Columns[this._goodsStockDataTable.PriceStartDate4Column.ColumnName].Hidden = true;
                            band.Columns[this._goodsStockDataTable.ListPrice4Column.ColumnName].Hidden = true;
                            band.Columns[this._goodsStockDataTable.OpenPriceDiv4Column.ColumnName].Hidden = true;
                            band.Columns[this._goodsStockDataTable.StockRate4Column.ColumnName].Hidden = true;
                            band.Columns[this._goodsStockDataTable.SalesUnitCost4Column.ColumnName].Hidden = true;
                            band.Columns[this._goodsStockDataTable.PriceStartDate5Column.ColumnName].Hidden = true;
                            band.Columns[this._goodsStockDataTable.ListPrice5Column.ColumnName].Hidden = true;
                            band.Columns[this._goodsStockDataTable.OpenPriceDiv5Column.ColumnName].Hidden = true;
                            band.Columns[this._goodsStockDataTable.StockRate5Column.ColumnName].Hidden = true;
                            band.Columns[this._goodsStockDataTable.SalesUnitCost5Column.ColumnName].Hidden = true;
                            break;
                        }
                    case 4:
                        {
                            // 価格リスト2、3、4の表示状態を設定
                            band.Columns[this._goodsStockDataTable.PriceStartDate2Column.ColumnName].Hidden = hiddenStat;
                            band.Columns[this._goodsStockDataTable.ListPrice2Column.ColumnName].Hidden = hiddenStat;
                            band.Columns[this._goodsStockDataTable.OpenPriceDiv2Column.ColumnName].Hidden = hiddenStat;
                            band.Columns[this._goodsStockDataTable.StockRate2Column.ColumnName].Hidden = hiddenStat;
                            band.Columns[this._goodsStockDataTable.SalesUnitCost2Column.ColumnName].Hidden = hiddenStat;
                            band.Columns[this._goodsStockDataTable.PriceStartDate3Column.ColumnName].Hidden = hiddenStat;
                            band.Columns[this._goodsStockDataTable.ListPrice3Column.ColumnName].Hidden = hiddenStat;
                            band.Columns[this._goodsStockDataTable.OpenPriceDiv3Column.ColumnName].Hidden = hiddenStat;
                            band.Columns[this._goodsStockDataTable.StockRate3Column.ColumnName].Hidden = hiddenStat;
                            band.Columns[this._goodsStockDataTable.SalesUnitCost3Column.ColumnName].Hidden = hiddenStat;
                            band.Columns[this._goodsStockDataTable.PriceStartDate4Column.ColumnName].Hidden = hiddenStat;
                            band.Columns[this._goodsStockDataTable.ListPrice4Column.ColumnName].Hidden = hiddenStat;
                            band.Columns[this._goodsStockDataTable.OpenPriceDiv4Column.ColumnName].Hidden = hiddenStat;
                            band.Columns[this._goodsStockDataTable.StockRate4Column.ColumnName].Hidden = hiddenStat;
                            band.Columns[this._goodsStockDataTable.SalesUnitCost4Column.ColumnName].Hidden = hiddenStat;
                            band.Columns[this._goodsStockDataTable.PriceStartDate5Column.ColumnName].Hidden = true;
                            band.Columns[this._goodsStockDataTable.ListPrice5Column.ColumnName].Hidden = true;
                            band.Columns[this._goodsStockDataTable.OpenPriceDiv5Column.ColumnName].Hidden = true;
                            band.Columns[this._goodsStockDataTable.StockRate5Column.ColumnName].Hidden = true;
                            band.Columns[this._goodsStockDataTable.SalesUnitCost5Column.ColumnName].Hidden = true;
                            break;
                        }
                    case 5:
                        {
                            // 価格リスト2、3、4、5の表示状態を設定
                            band.Columns[this._goodsStockDataTable.PriceStartDate2Column.ColumnName].Hidden = hiddenStat;
                            band.Columns[this._goodsStockDataTable.ListPrice2Column.ColumnName].Hidden = hiddenStat;
                            band.Columns[this._goodsStockDataTable.OpenPriceDiv2Column.ColumnName].Hidden = hiddenStat;
                            band.Columns[this._goodsStockDataTable.StockRate2Column.ColumnName].Hidden = hiddenStat;
                            band.Columns[this._goodsStockDataTable.SalesUnitCost2Column.ColumnName].Hidden = hiddenStat;
                            band.Columns[this._goodsStockDataTable.PriceStartDate3Column.ColumnName].Hidden = hiddenStat;
                            band.Columns[this._goodsStockDataTable.ListPrice3Column.ColumnName].Hidden = hiddenStat;
                            band.Columns[this._goodsStockDataTable.OpenPriceDiv3Column.ColumnName].Hidden = hiddenStat;
                            band.Columns[this._goodsStockDataTable.StockRate3Column.ColumnName].Hidden = hiddenStat;
                            band.Columns[this._goodsStockDataTable.SalesUnitCost3Column.ColumnName].Hidden = hiddenStat;
                            band.Columns[this._goodsStockDataTable.PriceStartDate4Column.ColumnName].Hidden = hiddenStat;
                            band.Columns[this._goodsStockDataTable.ListPrice4Column.ColumnName].Hidden = hiddenStat;
                            band.Columns[this._goodsStockDataTable.OpenPriceDiv4Column.ColumnName].Hidden = hiddenStat;
                            band.Columns[this._goodsStockDataTable.StockRate4Column.ColumnName].Hidden = hiddenStat;
                            band.Columns[this._goodsStockDataTable.SalesUnitCost4Column.ColumnName].Hidden = hiddenStat;
                            band.Columns[this._goodsStockDataTable.PriceStartDate5Column.ColumnName].Hidden = hiddenStat;
                            band.Columns[this._goodsStockDataTable.ListPrice5Column.ColumnName].Hidden = hiddenStat;
                            band.Columns[this._goodsStockDataTable.OpenPriceDiv5Column.ColumnName].Hidden = hiddenStat;
                            band.Columns[this._goodsStockDataTable.StockRate5Column.ColumnName].Hidden = hiddenStat;
                            band.Columns[this._goodsStockDataTable.SalesUnitCost5Column.ColumnName].Hidden = hiddenStat;
                            break;
                        }
                }
            }
            // --- UPD 2010/08/11 ----------<<<<<
        }
        #endregion

        #region ■ 名称表示制御
        /// <summary>
        /// 名称表示の変更を行う
        /// </summary>
        /// <remarks>
        /// <br>UpdateNote       : 2010/06/08 高峰 障害・改良対応（７月リリース案件）</br>
        /// </remarks>
        private void DispNameMain()
        {
            bool hiddenStat;

            if (this._visibleNameColumnsStat)
            {
                // 表示しない
                hiddenStat = true;
            }
            else
            {
                // 表示する
                hiddenStat = false;
            }

            Infragistics.Win.UltraWinGrid.UltraGridBand band = this.uGrid_Details.DisplayLayout.Bands[0];

            if (this._beforeSearchExtractInfo.TargetDiv == ExtractInfo.TargetDivState.Goods)
            {
                band.Columns[this._goodsStockDataTable.GoodsNameColumn.ColumnName].Hidden = hiddenStat; // 品名
                band.Columns[this._goodsStockDataTable.GoodsMakerNameColumn.ColumnName].Hidden = hiddenStat; // メーカー名
                // --- DEL 2010/06/08 ---------->>>>>
                //band.Columns[this._goodsStockDataTable.GoodsNameKanaColumn.ColumnName].Hidden = hiddenStat; // 品名カナ
                // --- DEL 2010/06/08 ----------<<<<<
                band.Columns[this._goodsStockDataTable.BLGoodsNameColumn.ColumnName].Hidden = hiddenStat; // BLコード
                band.Columns[this._goodsStockDataTable.EnterpriseGanreNameColumn.ColumnName].Hidden = hiddenStat; // 商品区分名
                band.Columns[this._goodsStockDataTable.GoodsMGroupNameColumn.ColumnName].Hidden = hiddenStat; // 商品中分類名
                band.Columns[this._goodsStockDataTable.BLGroupNameColumn.ColumnName].Hidden = hiddenStat; // グループコード名
            }
            else if (this._beforeSearchExtractInfo.TargetDiv == ExtractInfo.TargetDivState.Stock)
            {
                band.Columns[this._goodsStockDataTable.GoodsNameColumn.ColumnName].Hidden = hiddenStat; // 品名

                band.Columns[this._goodsStockDataTable.WarehouseNameColumn.ColumnName].Hidden = hiddenStat; // 倉庫名
                band.Columns[this._goodsStockDataTable.StockSupplierSnmColumn.ColumnName].Hidden = hiddenStat; // 発注先名

            }
            else if (this._beforeSearchExtractInfo.TargetDiv == ExtractInfo.TargetDivState.GoodsStock
                || this._beforeSearchExtractInfo.TargetDiv == ExtractInfo.TargetDivState.StockGoods)
            {
                band.Columns[this._goodsStockDataTable.GoodsNameColumn.ColumnName].Hidden = hiddenStat; // 品名
                band.Columns[this._goodsStockDataTable.GoodsMakerNameColumn.ColumnName].Hidden = hiddenStat; // メーカー名
                // --- DEL 2010/06/08 ---------->>>>>
                //band.Columns[this._goodsStockDataTable.GoodsNameKanaColumn.ColumnName].Hidden = hiddenStat; // 品名カナ
                // --- DEL 2010/06/08 ----------<<<<<
                band.Columns[this._goodsStockDataTable.BLGoodsNameColumn.ColumnName].Hidden = hiddenStat; // BLコード
                band.Columns[this._goodsStockDataTable.EnterpriseGanreNameColumn.ColumnName].Hidden = hiddenStat; // 商品区分名
                band.Columns[this._goodsStockDataTable.GoodsMGroupNameColumn.ColumnName].Hidden = hiddenStat; // 商品中分類名
                band.Columns[this._goodsStockDataTable.BLGroupNameColumn.ColumnName].Hidden = hiddenStat; // グループコード名

                band.Columns[this._goodsStockDataTable.WarehouseNameColumn.ColumnName].Hidden = hiddenStat; // 倉庫名
                band.Columns[this._goodsStockDataTable.StockSupplierSnmColumn.ColumnName].Hidden = hiddenStat; // 発注先名
            }

            // 名称表示状態フラグの更新
            if (hiddenStat)
            {
                this._visibleNameColumnsStat = false;
            }
            else
            {
                this._visibleNameColumnsStat = true;
            }
        }
        #endregion

        #region ■ ガイド処理
        /// <summary>
        /// ガイド処理メイン
        /// </summary>
        //private void ExecuteGuideMain() // DEL 2010/08/11
        public void ExecuteGuideMain() // ADD 2010/08/11
        {
            Infragistics.Win.UltraWinGrid.UltraGridCell activeCell = this.uGrid_Details.ActiveCell;

            if (activeCell == null)
            {
                // セルが選択されていなければ処理しない
                return;
            }

            int status;

            switch (activeCell.Column.Key)
            {
                case "GoodsMaker":
                    {
                        MakerUMnt makerUMnt;

                        // メーカーガイド起動
                        status = this.ExecuteMakerGuide(out makerUMnt);

                        if (status == 0)
                        {
                            activeCell.Value = makerUMnt.GoodsMakerCd;
                            this.uGrid_Details.Rows[activeCell.Row.Index].Cells[this._goodsStockDataTable.GoodsMakerNameColumn.ColumnName].Value = makerUMnt.MakerName;

                            // フォーカス移動
                            this.uGrid_Details.PerformAction(UltraGridAction.NextCellByTab);
                        }

                        break;
                    }
                case "BLGoodsCode":
                    {
                        BLGoodsCdUMnt bLGoodsCdUMnt;

                        // BLコードガイド起動
                        status = this.ExecuteBLGoodsCodeGuide(out bLGoodsCdUMnt);

                        if (status == 0)
                        {
                            activeCell.Value = bLGoodsCdUMnt.BLGoodsCode;
                            this.uGrid_Details.Rows[activeCell.Row.Index].Cells[this._goodsStockDataTable.BLGoodsNameColumn.ColumnName].Value = bLGoodsCdUMnt.BLGoodsHalfName;

                            status = this._blGoodsCdAcs.Read(out bLGoodsCdUMnt, this._enterpriseCode, bLGoodsCdUMnt.BLGoodsCode);


                            if (status == 0)
                            {
                                // グループコード
                                BLGroupU bLGroupU;

                                status = this._blGroupUAcs.Search(out bLGroupU, this._enterpriseCode, bLGoodsCdUMnt.BLGloupCode);

                                if (status == 0)
                                {
                                    this.uGrid_Details.Rows[activeCell.Row.Index].Cells[this._goodsStockDataTable.BLGroupCodeColumn.ColumnName].Value = bLGroupU.BLGroupCode;
                                    this.uGrid_Details.Rows[activeCell.Row.Index].Cells[this._goodsStockDataTable.BLGroupNameColumn.ColumnName].Value = bLGroupU.BLGroupName;

                                    // 中分類コード
                                    GoodsGroupU goodsGroupU;

                                    status = this._goodsGroupUAcs.Search(out goodsGroupU, this._enterpriseCode, bLGroupU.GoodsMGroup);

                                    if (status == 0)
                                    {
                                        this.uGrid_Details.Rows[activeCell.Row.Index].Cells[this._goodsStockDataTable.GoodsMGroupColumn.ColumnName].Value = goodsGroupU.GoodsMGroup;
                                        this.uGrid_Details.Rows[activeCell.Row.Index].Cells[this._goodsStockDataTable.GoodsMGroupNameColumn.ColumnName].Value = goodsGroupU.GoodsMGroupName;
                                    }
                                }
                            }

                            // フォーカス設定
                            this.uGrid_Details.PerformAction(UltraGridAction.NextCellByTab);
                        }

                        break;
                    }
                case "EnterpriseGanreCode":
                    {
                        UserGdHd userGdHd;
                        UserGdBd userGdBd;

                        // 商品区分ガイド起動
                        status = this.ExecuteEnterpriseGanreCodeGuide(out userGdHd, out userGdBd);

                        if (status == 0)
                        {
                            activeCell.Value = userGdBd.GuideCode;
                            this.uGrid_Details.Rows[activeCell.Row.Index].Cells[this._goodsStockDataTable.EnterpriseGanreNameColumn.ColumnName].Value = userGdBd.GuideName;

                            // フォーカス設定
                            this.uGrid_Details.PerformAction(UltraGridAction.NextCellByTab);
                        }

                        break;
                    }
                case "WarehouseCode":
                    {
                        Warehouse warehouse;

                        // 倉庫ガイド起動
                        status = this.ExecuteWarehouseGuide(out warehouse);
                        

                        if (status == 0)
                        {
                            activeCell.Value = warehouse.WarehouseCode.Trim();
                            this.uGrid_Details.Rows[activeCell.Row.Index].Cells[this._goodsStockDataTable.WarehouseNameColumn.ColumnName].Value = warehouse.WarehouseName;

                            // フォーカス設定
                            this.uGrid_Details.PerformAction(UltraGridAction.NextCellByTab);
                        }

                        break;
                    }
                case "PartsManagementDivide1":
                    {
                        UserGdHd userGdHd;
                        UserGdBd userGdBd;

                        // 管理区分ガイド1起動
                        status = this.ExecutePartsManagementDivide1Guide(out userGdHd, out userGdBd);

                        if (status == 0)
                        {
                            activeCell.Value = userGdBd.GuideCode;

                            // フォーカス設定
                            this.uGrid_Details.PerformAction(UltraGridAction.NextCellByTab);
                        }

                        break;
                    }
                case "PartsManagementDivide2":
                    {
                        UserGdHd userGdHd;
                        UserGdBd userGdBd;

                        // 管理区分ガイド2起動
                        status = this.ExecutePartsManagementDivide2Guide(out userGdHd, out userGdBd);

                        if (status == 0)
                        {
                            activeCell.Value = userGdBd.GuideCode;

                            // フォーカス設定
                            this.uGrid_Details.PerformAction(UltraGridAction.NextCellByTab);
                        }

                        break;
                    }
                case "StockSupplierCode":
                    {
                        // 仕入先ガイド起動
                        Supplier supplier;

                        status = this.ExecuteSupplierGuide(out supplier);

                        if (status == 0)
                        {
                            activeCell.Value = supplier.SupplierCd;
                            this.uGrid_Details.Rows[activeCell.Row.Index].Cells[this._goodsStockDataTable.StockSupplierSnmColumn.ColumnName].Value = supplier.SupplierSnm;

                            // フォーカス設定
                            this.uGrid_Details.PerformAction(UltraGridAction.NextCellByTab);
                        }

                        break;
                    }
            }
        }

        /// <summary>
        /// メーカーガイド
        /// </summary>
        internal int ExecuteMakerGuide(out MakerUMnt makerUmnt)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

            makerUmnt = new MakerUMnt();

            try
            {
                status = this._makerAcs.ExecuteGuid(this._enterpriseCode, out makerUmnt);
            }
            catch
            {
                status = -1;
            }

            return status;
        }

        /// <summary>
        /// BLコードガイド
        /// </summary>
        /// <param name="bLGoodsCdUMnt"></param>
        /// <returns></returns>
        internal int ExecuteBLGoodsCodeGuide(out BLGoodsCdUMnt bLGoodsCdUMnt)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

            bLGoodsCdUMnt = new BLGoodsCdUMnt();

            try
            {
                status = this._blGoodsCdAcs.ExecuteGuid(this._enterpriseCode, out bLGoodsCdUMnt);
            }
            catch
            {
                status = -1;
            }

            return status;
        }

        /// <summary>
        ///  自社分類(商品区分)ガイド起動
        /// </summary>
        /// <returns></returns>
        private int ExecuteEnterpriseGanreCodeGuide(out UserGdHd userGdHd, out UserGdBd userGdBd)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

            userGdHd = new UserGdHd();
            userGdBd = new UserGdBd();

            try
            {
                status = _userGuideAcs.ExecuteGuid(this._enterpriseCode, out userGdHd, out userGdBd, 41);
            }
            catch
            {
                status = -1;
            }

            return status;
        }

        /// <summary>
        /// 仕入先ガイド起動
        /// </summary>
        /// <param name="supplier"></param>
        /// <returns></returns>
        private int ExecuteSupplierGuide(out Supplier supplier)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

            supplier = new Supplier();

            try
            {
                status = this._supplierAcs.ExecuteGuid(out supplier, this._enterpriseCode, this._loginSectionCode);
            }
            catch
            {
                status = -1;
            }

            return status;
        }

        /// <summary>
        ///  倉庫ガイド起動
        /// </summary>
        /// <returns></returns>
        internal int ExecuteWarehouseGuide(out Warehouse warehouse)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

            warehouse = new Warehouse();

            try
            {
                status = this._warehouseAcs.ExecuteGuid(out warehouse, this._enterpriseCode);
            }
            catch
            {
                status = -1;
            }

            return status;
        }

        /// <summary>
        /// 管理区分ガイド1起動
        /// </summary>
        /// <param name="userGdHd"></param>
        /// <param name="userGdBd"></param>
        /// <returns></returns>
        private int ExecutePartsManagementDivide1Guide(out UserGdHd userGdHd, out UserGdBd userGdBd)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

            userGdHd = new UserGdHd();
            userGdBd = new UserGdBd();

            try
            {
                status = _userGuideAcs.ExecuteGuid(this._enterpriseCode, out userGdHd, out userGdBd, 72);
            }
            catch
            {
                status = -1;
            }

            return status;
        }

        /// <summary>
        /// 管理区分ガイド2起動
        /// </summary>
        /// <param name="userGdHd"></param>
        /// <param name="userGdBd"></param>
        /// <returns></returns>
        private int ExecutePartsManagementDivide2Guide(out UserGdHd userGdHd, out UserGdBd userGdBd)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

            userGdHd = new UserGdHd();
            userGdBd = new UserGdBd();

            try
            {
                status = _userGuideAcs.ExecuteGuid(this._enterpriseCode, out userGdHd, out userGdBd, 73);
            }
            catch
            {
                status = -1;
            }

            return status;
        }
        #endregion
        #endregion

        #region ■コントロールイベント

        #region ■ 初期イベント
        /// <summary>
        /// PMZAI09201UB_Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PMZAI09201UB_Load(object sender, EventArgs e)
        {
            this.uGrid_Details.DataSource = this._goodsStockDataTable;

            string errMsg = string.Empty;

            // コントロール初期化
            this.InitializeScreen();

            // グリッド初期化
            this.InitializeGrid();

            // 初期表示時、名称表示状態はtrue
            this._visibleNameColumnsStat = true;

            // グリッドキーマッピング設定処理
            // いらない？　編集モードにならない。。。
            //this.MakeKeyMappingForGrid(this.uGrid_Details);
        }

        /// <summary>
        /// InitializeLayoutイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>列名クリックによるソート、フィルタ設定を行う。</br>
        /// </remarks>
        private void uGrid_Details_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            // ヘッダクリックアクションの設定(ソート処理)
            e.Layout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            // 行フィルター設定
            e.Layout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
            // 複数行選択可
            e.Layout.Override.SelectTypeRow = SelectType.ExtendedAutoDrag; // ADD 2009/02/23
        }
        #endregion

        #region ■ グリッドセル更新イベント
        /// <summary>
        /// セルアクティブ前イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Update Note: 2013/05/11 yangyi</br>
        /// <br>管理番号   : 10801804-00 20150515配信分の対応</br>
        /// <br>           : Redmine#35018 「商品在庫一括修正」のサーバー負荷軽減　その２対応</br>
        /// </remarks>
        private void uGrid_Details_BeforeCellActivate(object sender, CancelableCellEventArgs e)
        {
            //--- ADD 2013/05/11 yangyi Redmine#35018の#53-No.7 ----->>>>>
            this._gridGoodsNo = string.Empty;
            this._gridGoodsMakerCd = 0;
            //--- ADD 2013/05/11 yangyi Redmine#35018の#53-No.7 -----<<<<<

            #region ■セル編集関連
            // 共通設定に従いIMEモード設定
            this.uGrid_Details.ImeMode = this.uiSetControl2.GetSettingImeMode(e.Cell.Column.Key);

            // ゼロ詰め解除実行
            if (e.Cell.Column.DataType == typeof(string) &&
                e.Cell.StyleResolved == Infragistics.Win.UltraWinGrid.ColumnStyle.Edit)
            {
                if (e.Cell.Value != DBNull.Value)
                {
                    this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[e.Cell.Column.Key].Value =
                        this.uiSetControl2.GetZeroPadCanceledText(e.Cell.Column.Key,
                        (string)this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[e.Cell.Column.Key].Value);
                }
            }
            #endregion

            #region ■編集前項目値保存
            switch (e.Cell.Column.Key)
            {
                case "GoodsNo":
                    {
                        if (e.Cell.Value == null || e.Cell.Value == DBNull.Value)
                        {
                            this._tmpGoodsNo = string.Empty;
                        }
                        else
                        {
                            this._tmpGoodsNo = e.Cell.Value.ToString();
                        }

                        break;
                    }
                case "GoodsMaker":
                    {
                        if (e.Cell.Value == null || e.Cell.Value == DBNull.Value || e.Cell.Value.ToString() == string.Empty)
                        {
                            this._tmpGoodsMaker = 0;
                        }
                        else
                        {
                            this._tmpGoodsMaker = (int)e.Cell.Value;
                        }

                        break;
                    }
                case "BLGoodsCode":
                    {
                        if (e.Cell.Value == null || e.Cell.Value == DBNull.Value || e.Cell.Value.ToString() == string.Empty)
                        {
                            this._tmpBLGoodsCode = 0;
                        }
                        else
                        {
                            this._tmpBLGoodsCode = (int)e.Cell.Value;
                        }

                        break;
                    }
                case "EnterpriseGanreCode":
                    {
                        if (e.Cell.Value == null || e.Cell.Value == DBNull.Value || e.Cell.Value.ToString() == string.Empty)
                        {
                            this._tmpEnterpriseGanreCode = 0;
                        }
                        else
                        {
                            this._tmpEnterpriseGanreCode = (int)e.Cell.Value;
                        }

                        break;
                    }
                case "WarehouseCode":
                    {
                        if (e.Cell.Value == null || e.Cell.Value == DBNull.Value)
                        {
                            this._tmpWarehouseCode = string.Empty;
                        }
                        else
                        {
                            this._tmpWarehouseCode = e.Cell.Value.ToString();
                        }

                        break;
                    }
                case "StockSupplierCode":
                    {
                        if (e.Cell.Value == null || e.Cell.Value == DBNull.Value || e.Cell.Value.ToString() == string.Empty)
                        {
                            this._tmpStockSupplierCode = 0;
                        }
                        else
                        {
                            this._tmpStockSupplierCode = (int)e.Cell.Value;
                        }

                        break;
                    }
                case "PriceStartDate1":
                    {
                        if (e.Cell.Value == null || e.Cell.Value == DBNull.Value)
                        {
                            this._tmpPriceStartDate1 = string.Empty;
                        }
                        else
                        {
                            this._tmpPriceStartDate1 = e.Cell.Value.ToString();
                        }

                        break;
                    }
                case "PriceStartDate2":
                    {
                        if (e.Cell.Value == null || e.Cell.Value == DBNull.Value)
                        {
                            this._tmpPriceStartDate2 = string.Empty;
                        }
                        else
                        {
                            this._tmpPriceStartDate2 = e.Cell.Value.ToString();
                        }

                        break;
                    }
                case "PriceStartDate3":
                    {
                        if (e.Cell.Value == null || e.Cell.Value == DBNull.Value)
                        {
                            this._tmpPriceStartDate3 = string.Empty;
                        }
                        else
                        {
                            this._tmpPriceStartDate3 = e.Cell.Value.ToString();
                        }

                        break;
                    }
                // --- ADD 2010/08/31 ---------->>>>>
                case "PriceStartDate4":
                    {
                        if (e.Cell.Value == null || e.Cell.Value == DBNull.Value)
                        {
                            this._tmpPriceStartDate4 = string.Empty;
                        }
                        else
                        {
                            this._tmpPriceStartDate4 = e.Cell.Value.ToString();
                        }

                        break;
                    }
                case "PriceStartDate5":
                    {
                        if (e.Cell.Value == null || e.Cell.Value == DBNull.Value)
                        {
                            this._tmpPriceStartDate5 = string.Empty;
                        }
                        else
                        {
                            this._tmpPriceStartDate5 = e.Cell.Value.ToString();
                        }

                        break;
                    }
                // --- ADD 2010/08/31 ----------<<<<<
                case "SalesOrderUnit":
                    {
                        if (e.Cell.Value == null || e.Cell.Value == DBNull.Value || e.Cell.Value.ToString() == string.Empty)
                        {
                            this._tmpSalesOrderUnit = 0;
                        }
                        else
                        {
                            this._tmpSalesOrderUnit = (int)e.Cell.Value;
                        }

                        break;
                    }
                case "MinimumStockCnt":
                    {
                        if (e.Cell.Value == null || e.Cell.Value == DBNull.Value || e.Cell.Value.ToString() == string.Empty)
                        {
                            this._tmpMinimumStockCnt = 0;
                        }
                        else
                        {
                            this._tmpMinimumStockCnt = (double)e.Cell.Value;
                        }

                        break;
                    }
                case "MaximumStockCnt":
                    {
                        if (e.Cell.Value == null || e.Cell.Value == DBNull.Value || e.Cell.Value.ToString() == string.Empty)
                        {
                            this._tmpMaximumStockCnt = 0;
                        }
                        else
                        {
                            this._tmpMaximumStockCnt = (double)e.Cell.Value;
                        }

                        break;
                    }
            }
            #endregion

            // --- ADD 2009/02/04 -------------------------------->>>>>
            #region ■同商品同項目削除処理
            // 商品項目一括変更処理(同商品の設定値を消す)
            if (this._beforeSearchExtractInfo != null
                &&
                (this._beforeSearchExtractInfo.TargetDiv == ExtractInfo.TargetDivState.GoodsStock
                || this._beforeSearchExtractInfo.TargetDiv == ExtractInfo.TargetDivState.StockGoods)
                )
            {
                // 商品のカラムのみ
                if (e.Cell.Column.Index <= this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsStockDataTable.UpRateColumn.ColumnName].Index)
                {
                    // 在庫削除日は除く
                    if (e.Cell.Column.Key != this._goodsStockDataTable.StockDeleteDateColumn.ColumnName)
                    {
                        string goodsNo = this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._goodsStockDataTable.GoodsNoColumn.ColumnName].Value.ToString();
                        int goodsMakerCd = (int)this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._goodsStockDataTable.GoodsMakerColumn.ColumnName].Value;

                        //--- ADD 2013/05/11 yangyi Redmine#35018の#53-No.7 ----->>>>>
                        this._gridGoodsNo = goodsNo;
                        this._gridGoodsMakerCd = goodsMakerCd;
                        //--- ADD 2013/05/11 yangyi Redmine#35018の#53-No.7 -----<<<<<

                        // 同商品の同列の情報を消す(非表示にする。非アクティブイベントで編集セルの値をコピーする)
                        foreach (UltraGridRow ultraGr in this.uGrid_Details.Rows)
                        {
                            if (ultraGr.Cells[this._goodsStockDataTable.GoodsNoColumn.ColumnName].Value.ToString() == goodsNo
                                && (int)ultraGr.Cells[this._goodsStockDataTable.GoodsMakerColumn.ColumnName].Value == goodsMakerCd)
                            {
                                // 編集行自体は除く
                                if (ultraGr.Index != e.Cell.Row.Index)
                                {
                                    this.uGrid_Details.AfterCellUpdate -= this.uGrid_Details_AfterCellUpdate;
                                    ultraGr.Cells[e.Cell.Column.Index].Value = DBNull.Value;
                                    this.uGrid_Details.AfterCellUpdate += this.uGrid_Details_AfterCellUpdate;
                                }
                            }
                        }
                    }
                }
            }
            #endregion
            // --- ADD 2009/02/04 --------------------------------<<<<<

            // ボタン制御
            //this.SetButtonEnableByRow(e.Cell.Row.Index, e.Cell.Column.Key); // DEL 2009/02/23
            this.SetButtonEnableByCell(e.Cell.Row.Index, e.Cell.Column.Key); // ADD 2009/02/23
        }

        /// <summary>
        /// uGrid_Details_AfterCellUpdateイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// </remarks>
        private void uGrid_Details_AfterCellUpdate(object sender, CellEventArgs e)
        {
            Infragistics.Win.UltraWinGrid.ColumnsCollection Columns = this.uGrid_Details.DisplayLayout.Bands[0].Columns; // 2010/08/11
            switch (e.Cell.Column.Key)
            {
                case "GoodsNo":
                    {
                        if (this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._goodsStockDataTable.GoodsNoColumn.ColumnName].Value != null
                            && this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._goodsStockDataTable.GoodsNoColumn.ColumnName].Value != DBNull.Value
                            && this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._goodsStockDataTable.GoodsMakerColumn.ColumnName].Value != null
                            && this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._goodsStockDataTable.GoodsMakerColumn.ColumnName].Value != DBNull.Value
                            && (int)this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._goodsStockDataTable.GoodsMakerColumn.ColumnName].Value != 0) // ADD 2009/03/03
                        {
                            // 品番の設定がある場合、商品のキー重複チェック
                            if (!this._goodsStockAcs.CheckKeyDuplication(
                                this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._goodsStockDataTable.GoodsNoColumn.ColumnName].Value.ToString(),
                                (int)this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._goodsStockDataTable.GoodsMakerColumn.ColumnName].Value,
                                string.Empty))
                            {
                                // 該当なし
                                TMsgDisp.Show(this, 												// 親ウィンドウフォーム
                                                emErrorLevel.ERR_LEVEL_INFO, 						// エラーレベル
                                                this.Name,											// アセンブリID
                                                "指定された商品は既に登録されています。",           // 表示するメッセージ
                                                -1,													// ステータス値
                                                MessageBoxButtons.OK);								// 表示するボタン

                                this.uGrid_Details.AfterCellUpdate -= this.uGrid_Details_AfterCellUpdate;
                                e.Cell.Value = this._tmpGoodsNo;
                                this.uGrid_Details.AfterCellUpdate += this.uGrid_Details_AfterCellUpdate;
                            }
                        }

                        break;
                    }
                case "GoodsMaker":
                    {

                        if (this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._goodsStockDataTable.GoodsMakerColumn.ColumnName].Value == null
                            || this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._goodsStockDataTable.GoodsMakerColumn.ColumnName].Value == DBNull.Value
                            || (int)this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._goodsStockDataTable.GoodsMakerColumn.ColumnName].Value == 0) // ADD 2009/03/03
                        {
                            // 入力が無ければチェックしない
                            this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._goodsStockDataTable.GoodsMakerNameColumn.ColumnName].Value = 0; // ADD 2009/03/03
                            break;
                        }

                        MakerUMnt makerUMnt;

                        int goodsMakerCd = (int)e.Cell.Value;

                        int status = this._makerAcs.Read(out makerUMnt, this._enterpriseCode, goodsMakerCd);

                        //--- ADD 2010/08/11 ---------->>>>>
                        if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL || makerUMnt == null || (makerUMnt != null && makerUMnt.LogicalDeleteCode != (int)ConstantManagement.LogicalMode.GetData0))
                        {
                            status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                        }
                        else
                        {
                            status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                        }
                        //--- ADD 2010/08/11 ---------->>>>>

                        if (status != 0)
                        {
                            // 該当なし
                            TMsgDisp.Show(this, 												// 親ウィンドウフォーム
                                            emErrorLevel.ERR_LEVEL_INFO, 						// エラーレベル
                                            this.Name,											// アセンブリID
                                            "指定された条件でメーカーコードは存在しませんでした。", // 表示するメッセージ
                                            -1,													// ステータス値
                                            MessageBoxButtons.OK);								// 表示するボタン

                            this.uGrid_Details.AfterCellUpdate -= this.uGrid_Details_AfterCellUpdate;
                            e.Cell.Value = this._tmpGoodsMaker;
                            this.uGrid_Details.AfterCellUpdate += this.uGrid_Details_AfterCellUpdate;

                            break;
                        }

                        if (this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._goodsStockDataTable.GoodsNoColumn.ColumnName].Value != null
                                && this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._goodsStockDataTable.GoodsNoColumn.ColumnName].Value != DBNull.Value)
                        {
                            // 品番の設定がある場合、商品のキー重複チェック
                            if (!this._goodsStockAcs.CheckKeyDuplication(
                                this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._goodsStockDataTable.GoodsNoColumn.ColumnName].Value.ToString(),
                                goodsMakerCd, string.Empty))
                            {
                                // 該当なし
                                TMsgDisp.Show(this, 												// 親ウィンドウフォーム
                                                emErrorLevel.ERR_LEVEL_INFO, 						// エラーレベル
                                                this.Name,											// アセンブリID
                                                "指定された商品は既に登録されています。",           // 表示するメッセージ
                                                -1,													// ステータス値
                                                MessageBoxButtons.OK);								// 表示するボタン

                                this.uGrid_Details.AfterCellUpdate -= this.uGrid_Details_AfterCellUpdate;
                                e.Cell.Value = this._tmpGoodsMaker;
                                this.uGrid_Details.AfterCellUpdate += this.uGrid_Details_AfterCellUpdate;
                            }
                            else
                            {
                                this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._goodsStockDataTable.GoodsMakerNameColumn.ColumnName].Value = makerUMnt.MakerName;
                            }
                        }
                        else
                        {
                            this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._goodsStockDataTable.GoodsMakerNameColumn.ColumnName].Value = makerUMnt.MakerName; // ADD 2009/02/03
                        }

                        break;
                    }
                case "BLGoodsCode":
                    {
                        if (this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._goodsStockDataTable.BLGoodsCodeColumn.ColumnName].Value == null
                            || this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._goodsStockDataTable.BLGoodsCodeColumn.ColumnName].Value == DBNull.Value)
                        {
                            // 入力が無ければチェックしない
                            this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._goodsStockDataTable.BLGoodsNameColumn.ColumnName].Value = string.Empty;
                            break;
                        }

                        BLGoodsCdUMnt bLGoodsCdUMnt;

                        int blGoodsCd = (int)e.Cell.Value;

                        int status = this._blGoodsCdAcs.Read(out bLGoodsCdUMnt, this._enterpriseCode, blGoodsCd);

                        //--- ADD 2010/08/11 ---------->>>>>
                        if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL || bLGoodsCdUMnt == null || (bLGoodsCdUMnt != null && bLGoodsCdUMnt.LogicalDeleteCode != (int)ConstantManagement.LogicalMode.GetData0))
                        {
                            status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                        }
                        else
                        {
                            status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                        }
                        //--- ADD 2010/08/11 ---------->>>>>

                        if (status == 0)
                        {
                            this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._goodsStockDataTable.BLGoodsNameColumn.ColumnName].Value = bLGoodsCdUMnt.BLGoodsHalfName;

                            // グループコード
                            BLGroupU bLGroupU;

                            status = this._blGroupUAcs.Search(out bLGroupU, this._enterpriseCode, bLGoodsCdUMnt.BLGloupCode);

                            if (status == 0)
                            {
                                this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._goodsStockDataTable.BLGroupCodeColumn.ColumnName].Value = bLGroupU.BLGroupCode;
                                this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._goodsStockDataTable.BLGroupNameColumn.ColumnName].Value = bLGroupU.BLGroupName;

                                // 中分類コード
                                GoodsGroupU goodsGroupU;

                                status = this._goodsGroupUAcs.Search(out goodsGroupU, this._enterpriseCode, bLGroupU.GoodsMGroup);

                                if (status == 0)
                                {
                                    this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._goodsStockDataTable.GoodsMGroupColumn.ColumnName].Value = goodsGroupU.GoodsMGroup;
                                    this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._goodsStockDataTable.GoodsMGroupNameColumn.ColumnName].Value = goodsGroupU.GoodsMGroupName;
                                }
                            }
                        }
                        else
                        {
                            // 該当なし
                            TMsgDisp.Show(this, 												// 親ウィンドウフォーム
                                            emErrorLevel.ERR_LEVEL_INFO, 						// エラーレベル
                                            this.Name,											// アセンブリID
                                            "指定された条件でＢＬコードは存在しませんでした。", // 表示するメッセージ
                                            -1,													// ステータス値
                                            MessageBoxButtons.OK);								// 表示するボタン

                            this.uGrid_Details.AfterCellUpdate -= this.uGrid_Details_AfterCellUpdate;
                            e.Cell.Value = this._tmpBLGoodsCode;
                            this.uGrid_Details.AfterCellUpdate += this.uGrid_Details_AfterCellUpdate;
                        }

                        break;
                    }
                case "EnterpriseGanreCode":
                    {
                        if (this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._goodsStockDataTable.EnterpriseGanreCodeColumn.ColumnName].Value == null
                            || this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._goodsStockDataTable.EnterpriseGanreCodeColumn.ColumnName].Value == DBNull.Value)
                        {
                            // 入力が無ければチェックしない
                            this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._goodsStockDataTable.EnterpriseGanreNameColumn.ColumnName].Value = string.Empty;
                            break;
                        }

                        UserGdBd userGdBd;

                        int enterpriseGanreCode = (int)e.Cell.Value;

                        UserGuideAcsData userGuideAcsData = UserGuideAcsData.UserBodyData;
                        int status = this._userGuideAcs.ReadBody(out userGdBd, this._enterpriseCode, 41, enterpriseGanreCode, ref userGuideAcsData);

                        //--- ADD 2010/08/11 ---------->>>>>
                        if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL || userGdBd == null || (userGdBd != null && userGdBd.LogicalDeleteCode != (int)ConstantManagement.LogicalMode.GetData0))
                        {
                            status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                        }
                        else
                        {
                            status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                        }
                        //--- ADD 2010/08/11 ---------->>>>>

                        if (status == 0)
                        {
                            this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._goodsStockDataTable.EnterpriseGanreNameColumn.ColumnName].Value = userGdBd.GuideName;
                        }
                        else
                        {
                            // 該当なし
                            TMsgDisp.Show(this, 												// 親ウィンドウフォーム
                                            emErrorLevel.ERR_LEVEL_INFO, 						// エラーレベル
                                            this.Name,											// アセンブリID
                                            "指定された条件で商品区分コードは存在しませんでした。", // 表示するメッセージ
                                            -1,													// ステータス値
                                            MessageBoxButtons.OK);								// 表示するボタン

                            this.uGrid_Details.AfterCellUpdate -= this.uGrid_Details_AfterCellUpdate;
                            e.Cell.Value = this._tmpEnterpriseGanreCode;
                            this.uGrid_Details.AfterCellUpdate += this.uGrid_Details_AfterCellUpdate;
                        }

                        break;
                    }
                case "WarehouseCode":
                    {
                        if (this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._goodsStockDataTable.WarehouseCodeColumn.ColumnName].Value == null
                            || this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._goodsStockDataTable.WarehouseCodeColumn.ColumnName].Value == DBNull.Value)
                        {
                            // 入力が無ければチェックしない
                            this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._goodsStockDataTable.WarehouseNameColumn.ColumnName].Value = string.Empty;
                            break;
                        }

                        // 倉庫は0埋め処理も行う
                        Warehouse warehouse;

                        string warehouseCd = e.Cell.Value.ToString().TrimEnd().PadLeft(4, '0');

                        int status = this._warehouseAcs.Read(out warehouse, this._enterpriseCode, string.Empty, warehouseCd);

                        //--- ADD 2010/08/11 ---------->>>>>
                        if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL || warehouse == null || (warehouse != null && warehouse.LogicalDeleteCode != (int)ConstantManagement.LogicalMode.GetData0))
                        {
                            status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                        }
                        else
                        {
                            status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                        }
                        //--- ADD 2010/08/11 ---------->>>>>

                        if (status != 0)
                        {
                            // 該当なし
                            TMsgDisp.Show(this, 												// 親ウィンドウフォーム
                                            emErrorLevel.ERR_LEVEL_INFO, 						// エラーレベル
                                            this.Name,											// アセンブリID
                                            "指定された条件で倉庫コードは存在しませんでした。", // 表示するメッセージ
                                            -1,													// ステータス値
                                            MessageBoxButtons.OK);								// 表示するボタン

                            this.uGrid_Details.AfterCellUpdate -= this.uGrid_Details_AfterCellUpdate;
                            e.Cell.Value = this._tmpWarehouseCode;
                            this.uGrid_Details.AfterCellUpdate += this.uGrid_Details_AfterCellUpdate;

                            break;
                        }

                        // 在庫のキー重複チェック
                        if (!this._goodsStockAcs.CheckKeyDuplication(
                            this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._goodsStockDataTable.GoodsNoColumn.ColumnName].Value.ToString(),
                            (int)this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._goodsStockDataTable.GoodsMakerColumn.ColumnName].Value,
                            warehouseCd))
                        {
                            // 該当なし
                            TMsgDisp.Show(this, 												// 親ウィンドウフォーム
                                            emErrorLevel.ERR_LEVEL_INFO, 						// エラーレベル
                                            this.Name,											// アセンブリID
                                            "指定された在庫は既に登録されています。",           // 表示するメッセージ
                                            -1,													// ステータス値
                                            MessageBoxButtons.OK);								// 表示するボタン

                            this.uGrid_Details.AfterCellUpdate -= this.uGrid_Details_AfterCellUpdate;   
                            e.Cell.Value = this._tmpWarehouseCode;
                            this.uGrid_Details.AfterCellUpdate += this.uGrid_Details_AfterCellUpdate;
                        }
                        else
                        {
                            this.uGrid_Details.AfterCellUpdate -= this.uGrid_Details_AfterCellUpdate;
                            e.Cell.Value = warehouseCd.PadLeft(4, '0');
                            this.uGrid_Details.AfterCellUpdate += this.uGrid_Details_AfterCellUpdate;
                            this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._goodsStockDataTable.WarehouseNameColumn.ColumnName].Value = warehouse.WarehouseName;
                        }

                        break;
                    }
                case "StockSupplierCode":
                    {
                        if (this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._goodsStockDataTable.StockSupplierCodeColumn.ColumnName].Value == null
                            || this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._goodsStockDataTable.StockSupplierCodeColumn.ColumnName].Value == DBNull.Value)
                        {
                            // 入力が無ければチェックしない
                            this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._goodsStockDataTable.StockSupplierSnmColumn.ColumnName].Value = string.Empty;
                            break;
                        }

                        Supplier supplier;

                        int supplierCd = (int)e.Cell.Value;

                        int status = this._supplierAcs.Read(out supplier, this._enterpriseCode, supplierCd);

                        //--- ADD 2010/08/11 ---------->>>>>
                        if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL || supplier == null || (supplier != null && supplier.LogicalDeleteCode != (int)ConstantManagement.LogicalMode.GetData0))
                        {
                            status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                        }
                        else
                        {
                            status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                        }
                        //--- ADD 2010/08/11 ---------->>>>>

                        if (status == 0)
                        {
                            this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._goodsStockDataTable.StockSupplierSnmColumn.ColumnName].Value = supplier.SupplierSnm;
                        }
                        else
                        {
                            // 該当なし
                            TMsgDisp.Show(this, 												// 親ウィンドウフォーム
                                            emErrorLevel.ERR_LEVEL_INFO, 						// エラーレベル
                                            this.Name,											// アセンブリID
                                            "指定された条件で発注先コードは存在しませんでした。", // 表示するメッセージ
                                            -1,													// ステータス値
                                            MessageBoxButtons.OK);								// 表示するボタン

                            this.uGrid_Details.AfterCellUpdate -= this.uGrid_Details_AfterCellUpdate;
                            e.Cell.Value = this._tmpStockSupplierCode;
                            this.uGrid_Details.AfterCellUpdate += this.uGrid_Details_AfterCellUpdate;
                        }

                        break;
                    }

                // --- ADD 2010/08/11 ---------->>>>>
                case "GoodsKindCode":
                case "TaxationDivCd":
                case "OpenPriceDiv1":
                case "OpenPriceDiv2":
                case "OpenPriceDiv3":
                case "OpenPriceDiv4": // ADD 2010/08/31
                case "OpenPriceDiv5": // ADD 2010/08/31
                case "StockDiv":
                    {
                        if ((e.Cell.Value != null) && (!(e.Cell.Value is System.DBNull)))
                        {
                            bool inputErrorFlg = true;
                            Infragistics.Win.ValueList list = (Infragistics.Win.ValueList)Columns[e.Cell.Column.Key].ValueList;
                            foreach (Infragistics.Win.ValueListItem item in list.ValueListItems)
                            {
                                if (item.DataValue.Equals(e.Cell.Value))
                                {
                                    inputErrorFlg = false;
                                    break;
                                }
                            }

                            if (inputErrorFlg)
                            {
                                e.Cell.Value = this._preComboEditorValue;
                            }
                            else
                            {
                                this._preComboEditorValue = e.Cell.Value;
                            }
                        }
                        else
                        {
                            e.Cell.Value = this._preComboEditorValue;
                        }
                        break;
                    }
                // --- ADD 2010/08/11 ----------<<<<<
            }

            // 入力形式チェック
            // 価格開始日
            if (e.Cell.Column.Key == "PriceStartDate1"
                || e.Cell.Column.Key == "PriceStartDate2"
                || e.Cell.Column.Key == "PriceStartDate3"
                || e.Cell.Column.Key == "PriceStartDate4"  // ADD 2010/08/31
                || e.Cell.Column.Key == "PriceStartDate5")   // ADD 2010/08/31
            {
                if (e.Cell.Value != null && e.Cell.Value != DBNull.Value)
                {
                    bool isDateFormat = false;

                    if (e.Cell.Value.ToString().Length == 8)
                    {
                        DateTime tmpDate;

                        if (DateTime.TryParseExact(e.Cell.Value.ToString(), "yyyyMMdd", null, System.Globalization.DateTimeStyles.None, out tmpDate))
                        {
                            isDateFormat = true;
                        }
                    }

                    if (!isDateFormat)
                    {
                        TMsgDisp.Show(this, 												// 親ウィンドウフォーム
                                        emErrorLevel.ERR_LEVEL_INFO, 						// エラーレベル
                                        this.Name,											// アセンブリID
                                        "価格開始日は日付8桁(例:20080101)で入力してください", // 表示するメッセージ
                                        -1,													// ステータス値
                                        MessageBoxButtons.OK);								// 表示するボタン

                        this.uGrid_Details.AfterCellUpdate -= this.uGrid_Details_AfterCellUpdate;
                        if (e.Cell.Column.Key == "PriceStartDate1")
                        {
                            if (this._tmpPriceStartDate1 == string.Empty)
                            {
                                e.Cell.Value = DBNull.Value;
                            }
                            else
                            {
                                e.Cell.Value = Convert.ToInt32(this._tmpPriceStartDate1);
                            }
                        }
                        else if (e.Cell.Column.Key == "PriceStartDate2")
                        {
                            if (this._tmpPriceStartDate2 == string.Empty)
                            {
                                e.Cell.Value = DBNull.Value;
                            }
                            else
                            {
                                e.Cell.Value = Convert.ToInt32(this._tmpPriceStartDate2);
                            }
                        }
                        else if (e.Cell.Column.Key == "PriceStartDate3")
                        {
                            if (this._tmpPriceStartDate3 == string.Empty)
                            {
                                e.Cell.Value = DBNull.Value;
                            }
                            else
                            {
                                e.Cell.Value = Convert.ToInt32(this._tmpPriceStartDate3);
                            }
                        }
                        // --- ADD 2010/08/31 ---------->>>>>
                        else if (e.Cell.Column.Key == "PriceStartDate4")
                        {
                            if (this._tmpPriceStartDate4 == string.Empty)
                            {
                                e.Cell.Value = DBNull.Value;
                            }
                            else
                            {
                                e.Cell.Value = Convert.ToInt32(this._tmpPriceStartDate4);
                            }
                        }
                        else if (e.Cell.Column.Key == "PriceStartDate5")
                        {
                            if (this._tmpPriceStartDate5 == string.Empty)
                            {
                                e.Cell.Value = DBNull.Value;
                            }
                            else
                            {
                                e.Cell.Value = Convert.ToInt32(this._tmpPriceStartDate5);
                            }
                        }
                        // --- ADD 2010/08/31 ----------<<<<<

                        this.uGrid_Details.AfterCellUpdate += this.uGrid_Details_AfterCellUpdate;
                    }
                }
            }

            // 数値項目チェック
            if (e.Cell.Column.Key == "ListPrice1"
                || e.Cell.Column.Key == "StockRate1"
                || e.Cell.Column.Key == "SalesUnitCost1"
                || e.Cell.Column.Key == "ListPrice2"
                || e.Cell.Column.Key == "StockRate2"
                || e.Cell.Column.Key == "SalesUnitCost2"
                || e.Cell.Column.Key == "ListPrice3"
                || e.Cell.Column.Key == "StockRate3"
                || e.Cell.Column.Key == "SalesUnitCost3"
                // --- ADD 2010/08/31 ---------->>>>>
                || e.Cell.Column.Key == "ListPrice4"
                || e.Cell.Column.Key == "StockRate4"
                || e.Cell.Column.Key == "SalesUnitCost4"
                || e.Cell.Column.Key == "ListPrice5"
                || e.Cell.Column.Key == "StockRate5"
                || e.Cell.Column.Key == "SalesUnitCost5"
                // --- ADD 2010/08/31 ----------<<<<<
                || e.Cell.Column.Key == "PriceFl"
                || e.Cell.Column.Key == "UpRate"
                || e.Cell.Column.Key == "SalesOrderUnit"
                || e.Cell.Column.Key == "MinimumStockCnt"
                || e.Cell.Column.Key == "MaximumStockCnt"
                || e.Cell.Column.Key == "SupplierStock"
                || e.Cell.Column.Key == "ArrivalCnt"
                || e.Cell.Column.Key == "ShipmentCnt"
                || e.Cell.Column.Key == "AcpOdrCount"
                || e.Cell.Column.Key == "MovingSupliStock"
                )
            {
                // 入力が無い場合、0を設定
                if (e.Cell.Value == null || e.Cell.Value == DBNull.Value)
                {
                    this.uGrid_Details.AfterCellUpdate -= this.uGrid_Details_AfterCellUpdate;
                    e.Cell.Value = 0;
                    this.uGrid_Details.AfterCellUpdate += this.uGrid_Details_AfterCellUpdate;
                }
            }

            // 関連項目チェック(最低在庫数 <= 最高在庫数、発注ロット<=最高在庫数)
            if (e.Cell.Column.Key == "SalesOrderUnit"
                || e.Cell.Column.Key == "MinimumStockCnt"
                || e.Cell.Column.Key == "MaximumStockCnt")
            {
                if (e.Cell.Column.Key != "SalesOrderUnit"
                    &&
                    ((double)this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._goodsStockDataTable.MinimumStockCntColumn.ColumnName].Value
                    > (double)this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._goodsStockDataTable.MaximumStockCntColumn.ColumnName].Value))
                {
                    TMsgDisp.Show(this, 									// 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_INFO, 						// エラーレベル
                        this.Name,											// アセンブリID
                        "最低在庫数<=最高在庫数となるように入力してください", // 表示するメッセージ
                        -1,													// ステータス値
                        MessageBoxButtons.OK);								// 表示するボタン

                    this.uGrid_Details.AfterCellUpdate -= this.uGrid_Details_AfterCellUpdate;
                    if (e.Cell.Column.Key == "MinimumStockCnt")
                    {
                        e.Cell.Value = this._tmpMinimumStockCnt;
                    }
                    else if (e.Cell.Column.Key == "MaximumStockCnt")
                    {
                        e.Cell.Value = this._tmpMaximumStockCnt;
                    }
                    this.uGrid_Details.AfterCellUpdate += this.uGrid_Details_AfterCellUpdate;
                }
                else if (e.Cell.Column.Key != "MinimumStockCnt"
                    &&
                    ((int)this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._goodsStockDataTable.SalesOrderUnitColumn.ColumnName].Value
                    > (double)this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._goodsStockDataTable.MaximumStockCntColumn.ColumnName].Value))
                {
                    TMsgDisp.Show(this, 									// 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_INFO, 						// エラーレベル
                        this.Name,											// アセンブリID
                        "発注ロット<=最高在庫数となるように入力してください", // 表示するメッセージ
                        -1,													// ステータス値
                        MessageBoxButtons.OK);								// 表示するボタン

                    this.uGrid_Details.AfterCellUpdate -= this.uGrid_Details_AfterCellUpdate;
                    if (e.Cell.Column.Key == "SalesOrderUnit")
                    {
                        e.Cell.Value = this._tmpSalesOrderUnit;
                    }
                    else if (e.Cell.Column.Key == "MaximumStockCnt")
                    {
                        e.Cell.Value = this._tmpMaximumStockCnt;
                    }
                    this.uGrid_Details.AfterCellUpdate += this.uGrid_Details_AfterCellUpdate;
                }
            }

            // --- DEL 2009/02/04 -------------------------------->>>>>
            //// 商品項目一括変更処理
            //if (this._beforeSearchExtractInfo != null
            //    &&
            //    (this._beforeSearchExtractInfo.TargetDiv == ExtractInfo.TargetDivState.GoodsStock
            //    || this._beforeSearchExtractInfo.TargetDiv == ExtractInfo.TargetDivState.StockGoods)
            //    )
            //{
            //    // 商品のカラムのみ
            //    if (e.Cell.Column.Index <= this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsStockDataTable.UpRateColumn.ColumnName].Index)
            //    {
            //        // 在庫削除日は除く
            //        if (e.Cell.Column.Key != this._goodsStockDataTable.StockDeleteDateColumn.ColumnName)
            //        {
            //            string goodsNo = this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._goodsStockDataTable.GoodsNoColumn.ColumnName].Value.ToString();
            //            int goodsMakerCd = (int)this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._goodsStockDataTable.GoodsMakerColumn.ColumnName].Value;

            //            // セル値が更新された場合、同商品の同列の情報を上書きする
            //            foreach (UltraGridRow ultraGr in this.uGrid_Details.Rows)
            //            {
            //                if (ultraGr.Cells[this._goodsStockDataTable.GoodsNoColumn.ColumnName].Value.ToString() == goodsNo
            //                    && (int)ultraGr.Cells[this._goodsStockDataTable.GoodsMakerColumn.ColumnName].Value == goodsMakerCd)
            //                {
            //                    this.uGrid_Details.AfterCellUpdate -= this.uGrid_Details_AfterCellUpdate;
            //                    ultraGr.Cells[e.Cell.Column.Index].Value = e.Cell.Value;
            //                    this.uGrid_Details.AfterCellUpdate += this.uGrid_Details_AfterCellUpdate;
            //                }
            //            }
            //        }
            //    }
            //}
            // --- DEL 2009/02/04 --------------------------------<<<<<

            // 現在庫計算処理
            if (e.Cell.Column.Key == this._goodsStockDataTable.SupplierStockColumn.ColumnName
                || e.Cell.Column.Key == this._goodsStockDataTable.ArrivalCntColumn.ColumnName
                || e.Cell.Column.Key == this._goodsStockDataTable.ShipmentCntColumn.ColumnName
                || e.Cell.Column.Key == this._goodsStockDataTable.AcpOdrCountColumn.ColumnName
                || e.Cell.Column.Key == this._goodsStockDataTable.MovingSupliStockColumn.ColumnName)
            {
                this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._goodsStockDataTable.NowStockCntColumn.ColumnName].Value
                = ConvertToDoubleFromGridValue(this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._goodsStockDataTable.SupplierStockColumn.ColumnName].Value)
                + ConvertToDoubleFromGridValue(this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._goodsStockDataTable.ArrivalCntColumn.ColumnName].Value)
                - ConvertToDoubleFromGridValue(this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._goodsStockDataTable.ShipmentCntColumn.ColumnName].Value)
                - ConvertToDoubleFromGridValue(this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._goodsStockDataTable.AcpOdrCountColumn.ColumnName].Value)
                - ConvertToDoubleFromGridValue(this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._goodsStockDataTable.MovingSupliStockColumn.ColumnName].Value);
            }

            // --- ADD 2009/03/05 -------------------------------->>>>>
            // 棚卸評価単価計算処理
            // 価格開始日、価格、棚卸評価率
            if (e.Cell.Column.Key == this._goodsStockDataTable.PriceStartDate1Column.ColumnName
                || e.Cell.Column.Key == this._goodsStockDataTable.ListPrice1Column.ColumnName
                || e.Cell.Column.Key == this._goodsStockDataTable.PriceStartDate2Column.ColumnName
                || e.Cell.Column.Key == this._goodsStockDataTable.ListPrice2Column.ColumnName
                || e.Cell.Column.Key == this._goodsStockDataTable.PriceStartDate3Column.ColumnName
                || e.Cell.Column.Key == this._goodsStockDataTable.ListPrice3Column.ColumnName
                // --- ADD 2010/08/11 ---------->>>>>
                || e.Cell.Column.Key == this._goodsStockDataTable.PriceStartDate4Column.ColumnName
                || e.Cell.Column.Key == this._goodsStockDataTable.ListPrice4Column.ColumnName
                || e.Cell.Column.Key == this._goodsStockDataTable.PriceStartDate5Column.ColumnName
                || e.Cell.Column.Key == this._goodsStockDataTable.ListPrice5Column.ColumnName
                // --- ADD 2010/08/11 ----------<<<<<
                || e.Cell.Column.Key == this._goodsStockDataTable.StockUnitPriceRateColumn.ColumnName
                )
            {
                // 棚卸評価単価が0でない場合は計算を行わない
                if ((double)this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._goodsStockDataTable.OriginalStockUnitPriceFlColumn.ColumnName].Value == 0)
                {
                    Int32 now = DateTime.Now.Year * 10000 + DateTime.Now.Month * 100 + DateTime.Now.Day;
                    double listPrice = 0;

                    SortedList<Int32, double> sortedList = new SortedList<Int32, double>();

                    if (this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._goodsStockDataTable.PriceStartDate1Column.ColumnName].Value != null
                        && this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._goodsStockDataTable.PriceStartDate1Column.ColumnName].Value != DBNull.Value)
                    {
                        sortedList.Add((Int32)this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._goodsStockDataTable.PriceStartDate1Column.ColumnName].Value,
                            (double)this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._goodsStockDataTable.ListPrice1Column.ColumnName].Value);
                    }

                    if (this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._goodsStockDataTable.PriceStartDate2Column.ColumnName].Value != null
                        && this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._goodsStockDataTable.PriceStartDate2Column.ColumnName].Value != DBNull.Value)
                    {
                        sortedList.Add((Int32)this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._goodsStockDataTable.PriceStartDate2Column.ColumnName].Value,
                            (double)this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._goodsStockDataTable.ListPrice2Column.ColumnName].Value);
                    }

                    if (this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._goodsStockDataTable.PriceStartDate3Column.ColumnName].Value != null
                        && this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._goodsStockDataTable.PriceStartDate3Column.ColumnName].Value != DBNull.Value)
                    {
                        sortedList.Add((Int32)this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._goodsStockDataTable.PriceStartDate3Column.ColumnName].Value,
                            (double)this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._goodsStockDataTable.ListPrice3Column.ColumnName].Value);
                    }

                    // --- ADD 2010/08/11 ---------->>>>>
                    if (this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._goodsStockDataTable.PriceStartDate4Column.ColumnName].Value != null
                        && this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._goodsStockDataTable.PriceStartDate4Column.ColumnName].Value != DBNull.Value)
                    {
                        sortedList.Add((Int32)this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._goodsStockDataTable.PriceStartDate4Column.ColumnName].Value,
                            (double)this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._goodsStockDataTable.ListPrice4Column.ColumnName].Value);
                    }

                    if (this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._goodsStockDataTable.PriceStartDate5Column.ColumnName].Value != null
                        && this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._goodsStockDataTable.PriceStartDate5Column.ColumnName].Value != DBNull.Value)
                    {
                        sortedList.Add((Int32)this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._goodsStockDataTable.PriceStartDate5Column.ColumnName].Value,
                            (double)this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._goodsStockDataTable.ListPrice5Column.ColumnName].Value);
                    }

                    // --- ADD 2010/08/11 ----------<<<<<

                    for (int i = 0; i < sortedList.Count; i++)
                    {
                        if (sortedList.Keys[i] <= now)
                        {
                            listPrice = sortedList.Values[i];
                        }
                    }

                    double StockUnitPriceFlColumn = listPrice * ((double)this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._goodsStockDataTable.StockUnitPriceRateColumn.ColumnName].Value) / 100;

                    // 小数点3桁以下にはなりえないので、端数処理必要なし
                    this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._goodsStockDataTable.StockUnitPriceFlColumn.ColumnName].Value = StockUnitPriceFlColumn;
                }
            }
            // --- ADD 2009/03/05 --------------------------------<<<<<
        }

        /// <summary>
        /// uGrid_Details_KeyPressイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uGrid_Details_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (this.uGrid_Details.ActiveCell == null)
            {
                return;
            }

            Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.uGrid_Details.ActiveCell;

            // 編集中
            if (cell.IsInEditMode)
            {
                // UI共通設定を読込み、形式チェック
                if (this.uiSetControl2.CheckMatchingSet(cell.Column.Key, e.KeyChar) == false)
                {
                    e.Handled = true;
                    return;
                }

                // --- ADD 2009/04/06 -------------------------------->>>>>
                // 棚番は8バイトまで
                if (cell.Column.Key == "WarehouseShelfNo"
                    || cell.Column.Key == "DuplicationShelfNo1"
                    || cell.Column.Key == "DuplicationShelfNo2")
                {
                    if (!Char.IsControl(e.KeyChar))
                    {
                        string prevStr = cell.Text;
                        string resultStr = prevStr.Substring(0, cell.SelStart) // 選択前の部分
                                         + e.KeyChar.ToString() // 選択部が入力キーに置換される部分
                                         + prevStr.Substring(cell.SelStart + cell.SelLength, prevStr.Length - (cell.SelStart + cell.SelLength)); // 選択後の部分

                        Encoding sjis = Encoding.GetEncoding("Shift_JIS");

                        int byteLength = sjis.GetByteCount(resultStr);

                        // 8バイト(半角8桁、全角4桁)まで入力可
                        if (byteLength > 8)
                        {
                            e.Handled = true;
                            return;
                        }
                    }
                }
                // --- ADD 2009/04/06 --------------------------------<<<<<
                // 数値項目の入力制御
                else if (cell.Column.Key == "PriceFl")
                {
                    // 9桁整数
                    if (!this.CheckKeyPressNumber(9, 0, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false))
                    {
                        e.Handled = true;
                        return;
                    }
                }
                else if (cell.Column.Key == "ListPrice1"
                || cell.Column.Key == "ListPrice2"
                    || cell.Column.Key == "ListPrice3"
               || cell.Column.Key == "ListPrice4" // ADD 2010/08/31
               || cell.Column.Key == "ListPrice5" // ADD 2010/08/31
                )
                {
                    // 7桁整数
                    if (!this.CheckKeyPressNumber(7, 0, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false))
                    {
                        e.Handled = true;
                        return;
                    }
                }
                else if (cell.Column.Key == "SalesOrderUnit")
                {
                    // 6桁整数
                    if (!this.CheckKeyPressNumber(6, 0, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false))
                    {
                        e.Handled = true;
                        return;
                    }
                }
                else if (cell.Column.Key == "SalesUnitCost1"
                || cell.Column.Key == "SalesUnitCost2"
                || cell.Column.Key == "SalesUnitCost3"
                || cell.Column.Key == "SalesUnitCost4" // ADD 2010/08/31
                || cell.Column.Key == "SalesUnitCost5" // ADD 2010/08/31
                || cell.Column.Key == "StockUnitPriceFl") // ADD 2009/03/05
                {
                    // 7桁+小数点2位
                    if (!this.CheckKeyPressNumber(10, 2, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false))
                    {
                        e.Handled = true;
                        return;
                    }
                }
                else if
                    (cell.Column.Key == "MinimumStockCnt"
                || cell.Column.Key == "MaximumStockCnt"
                || cell.Column.Key == "SupplierStock"
                || cell.Column.Key == "ArrivalCnt"
                || cell.Column.Key == "ShipmentCnt"
                || cell.Column.Key == "AcpOdrCount"
                || cell.Column.Key == "MovingSupliStock")
                {
                    // 6桁+小数点2位
                    //if (!this.CheckKeyPressNumber(9, 2, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false)) // DEL 2009/02/03
                    if (!this.CheckKeyPressNumber(9, 2, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, true)) // ADD 2009/02/03
                    {
                        e.Handled = true;
                        return;
                    }
                }
                else if
               (cell.Column.Key == "StockRate1"
               || cell.Column.Key == "StockRate2"
               || cell.Column.Key == "StockRate3"
               || cell.Column.Key == "StockRate4"  // ADD 2010/08/31
               || cell.Column.Key == "StockRate5" // ADD 2010/08/31
               || cell.Column.Key == "UpRate"
               || cell.Column.Key == "StockUnitPriceRate" // ADD 2009/03/05
           )
                {
                    // 率項目(3桁+小数点2桁)
                    if (!this.CheckKeyPressNumber(6, 2, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false))
                    {
                        e.Handled = true;
                        return;
                    }
                }

            }
        }
        #endregion

        #region ■ ボタンクリックイベント
        /// <summary>
        /// 商品削除ボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_RowDelete_Click(object sender, EventArgs e)
        {
            // --- DEL 2009/02/23 -------------------------------->>>>>
            //// Active行index取得
            //int selectRowIndex = this.GetSelectRowIndex();

            //if (selectRowIndex == -1)
            //{
            //    // Active行が無ければ処理しない
            //    return;
            //}

            //// 削除処理
            //this.GoodsDeleteMain(selectRowIndex);
            // --- DEL 2009/02/23 --------------------------------<<<<<

            // 削除処理
            this.GoodsDeleteMain(); // ADD 2009/02/23
        }

        /// <summary>
        /// 在庫削除ボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_RowStockDelete_Click(object sender, EventArgs e)
        {
            // --- DEL 2009/02/23 -------------------------------->>>>>
            //// Active行index取得
            //int selectRowIndex = this.GetSelectRowIndex();

            //if (selectRowIndex == -1)
            //{
            //    // Active行が無ければ処理しない
            //    return;
            //}

            //// 削除処理
            //this.StockDeleteMain(selectRowIndex);
            // --- DEL 2009/02/23 --------------------------------<<<<<

            // 削除処理
            this.StockDeleteMain(); // ADD 2009/02/23
        }

        /// <summary>
        /// 復活ボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_RowRevive_Click(object sender, EventArgs e)
        {
            // --- DEL 2009/02/23 -------------------------------->>>>>
            //// Active行index取得
            //int selectRowIndex = this.GetSelectRowIndex();

            //if (selectRowIndex == -1)
            //{
            //    // Active行が無ければ処理しない
            //    return;
            //}
            
            //// 復活処理
            //this.GoodsReviveMain(selectRowIndex);
            // --- DEL 2009/02/23 --------------------------------<<<<<

            // 復活処理
            this.GoodsReviveMain(); // ADD 2009/02/23
        }

        /// <summary>
        /// 在庫復活ボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_RowStockRevive_Click(object sender, EventArgs e)
        {
            // --- DEL 2009/02/23 -------------------------------->>>>>
            //// Active行index取得
            //int selectRowIndex = this.GetSelectRowIndex();

            //if (selectRowIndex == -1)
            //{
            //    // Active行が無ければ処理しない
            //    return;
            //}

            //// 復活処理
            //this.StockReviveMain(selectRowIndex);
            // --- DEL 2009/02/23 --------------------------------<<<<<

            // 復活処理
            this.StockReviveMain(); // ADD 2009/02/23
        }

        /// <summary>
        /// 商品追加ボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_RowAdd_Click(object sender, EventArgs e)
        {
            // --- DEL 2009/02/23 -------------------------------->>>>>
            //// Active行index取得
            //int selectRowIndex = this.GetSelectRowIndex();

            //this.AddNewRowMain(selectRowIndex);

            //// 背景色設定
            //this.SetGridColorAll();
            // --- DEL 2009/02/23 --------------------------------<<<<<

            // 商品(在庫)追加
            this.AddNewRowMain(); // ADD 2009/02/23
        }

        /// <summary>
        /// 価格表示ボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_RowDispPrice_Click(object sender, EventArgs e)
        {
            // 価格表示処理
            this.DispPriceMain();
        }

        /// <summary>
        /// 名称表示ボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_RowDispNames_Click(object sender, EventArgs e)
        {
            // 名称表示処理
            this.DispNameMain();
        }

        /// <summary>
        /// ガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_RowExcuteGuide_Click(object sender, EventArgs e)
        {
            // ガイド処理
            this.ExecuteGuideMain();
        }

        #endregion

        #region ■ フォーカス遷移関連イベント
        /// <summary>
        /// uGrid_Details_KeyDownイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                            this.SetFocus("tEdit_GoodsNo");
                            break;
                        }
                    case Keys.Down:
                    case Keys.Right:
                        {
                            this.SetFocus("tComboEditor_DisplayDiv");
                            break;
                        }
                    case Keys.Left:
                        {
                            //this.SetFocus("uButton_EmployeeCdGuide");  // DEL 2009/03/06
                            this.SetFocus("Before_Grid");  // ADD 2009/03/06
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
                            this.SetFocus("tEdit_GoodsNo");
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
                                            this.SetFocus("tEdit_GoodsNo");
                                        }

                                        break;
                                    }
                                }
                            }

                            // キー値の行はセル毎にActivationが異なるケースがある
                            // --- DEL 2009/02/23 -------------------------------->>>>>
                            //for (int i = rowIndex; i >= 1; i--)
                            //{
                            //    if (uGrid.Rows[i - 1].Cells[columnIndex].Activation == Activation.AllowEdit)
                            //    {
                            //        uGrid.Rows[i - 1].Cells[columnIndex].Activate();
                            //        uGrid.PerformAction(UltraGridAction.EnterEditMode);
                            //        doActivate = true;
                            //        break;
                            //    }
                            //}

                            //if (!doActivate)
                            //{
                            //    this.SetFocus("tEdit_GoodsNo");
                            //}
                            // --- DEL 2009/02/23 --------------------------------<<<<<
                            // --- ADD 2009/02/23 -------------------------------->>>>>
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
                                    this.SetFocus("tEdit_GoodsNo");
                                }
                            }
                            // --- ADD 2009/02/23 -------------------------------->>>>>
                        }
                        break;
                    }
                case Keys.Down:
                    {
                        if (rowIndex == uGrid.Rows.Count - 1)
                        {
                            e.Handled = true;
                            this.SetFocus("tComboEditor_DisplayDiv");
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
                                            this.SetFocus("tComboEditor_DisplayDiv");
                                        }

                                        break;
                                    }
                                }
                            }

                            // --- DEL 2009/02/23 -------------------------------->>>>>
                            //// キー値の行はセル毎にActivationが異なるケースがある
                            //for (int i = rowIndex; i < uGrid.Rows.Count - 1; i++)
                            //{
                            //    if (uGrid.Rows[i + 1].Cells[columnIndex].Activation == Activation.AllowEdit)
                            //    {
                            //        uGrid.Rows[i + 1].Cells[columnIndex].Activate();
                            //        uGrid.PerformAction(UltraGridAction.EnterEditMode);
                            //        doActivate = true;
                            //        break;
                            //    }
                            //}

                            //if (!doActivate)
                            //{
                            //    this.SetFocus("tComboEditor_DisplayDiv");
                            //}
                            // --- DEL 2009/02/23 --------------------------------<<<<<
                            // --- ADD 2009/02/23 -------------------------------->>>>>
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
                                    this.SetFocus("tComboEditor_DisplayDiv");
                                }
                            }
                            // --- ADD 2009/02/23 -------------------------------->>>>>
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
                                //this.SetFocus("uButton_EmployeeCdGuide"); // DEL 2009/03/06
                                this.SetFocus("Before_Grid"); // ADD 2009/03/06
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
                                uGrid.Rows[activationRowIndex].Cells[nextFocusColumn].Activate();
                                uGrid.PerformAction(UltraGridAction.EnterEditMode);
                            }
                            else
                            {
                                //this.SetFocus("uButton_EmployeeCdGuide"); // DEL 2009/03/06
                                this.SetFocus("Before_Grid"); // ADD 2009/03/06
                            }
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
                                this.SetFocus("tComboEditor_DisplayDiv");
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
                                uGrid.Rows[activationRowIndex].Cells[nextFocusColumn].Activate();
                                uGrid.PerformAction(UltraGridAction.EnterEditMode);
                            }
                            else
                            {
                                this.SetFocus("tComboEditor_DisplayDiv");
                            }
                        }

                        break;
                    }
            }
        }

        /// <summary>
        /// Leaveイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PMZAI09201UB_Leave(object sender, EventArgs e)
        {
            this.uGrid_Details.ActiveCell = null;
            this.uGrid_Details.ActiveRow = null;
            this.uGrid_Details.Selected.Rows.Clear();

            // --- ADD 2009/03/02 -------------------------------->>>>>
            // ボタンを不可にする
            this.uButton_RowGoodsDelete.Enabled = false;
            this.uButton_RowGoodsRevive.Enabled = false;
            this.uButton_RowStockDelete.Enabled = false;
            this.uButton_RowStockRevive.Enabled = false;
            //this.uButton_RowExcuteGuide.Enabled = false; // DEL 2010/08/11

            if (this._beforeSearchExtractInfo.TargetDiv == ExtractInfo.TargetDivState.GoodsStock)
            {
                this.uButton_RowAdd.Enabled = false;
            }
            // --- ADD 2009/03/02 --------------------------------<<<<<

            this.SetGridColorAll(); // ADD 2009/02/23
        }
        #endregion

        #region ■ 背景色設定関連イベント
        // --- ADD 2009/03/05 -------------------------------->>>>>
        /// <summary>
        /// BeforeCellDeactivateイベント
        /// </summary>
        private void uGrid_Details_BeforeCellDeactivate()
        {
            this.uGrid_Details_BeforeCellDeactivate(new Object(), new CancelEventArgs());
        }
        // --- ADD 2009/03/05 --------------------------------<<<<<

        /// <summary>
        /// BeforeCellDeactivateイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uGrid_Details_BeforeCellDeactivate(object sender, CancelEventArgs e)
        {
            if (this.uGrid_Details.ActiveCell != null)
            {
                // 背景色設定
                this.SetGridColorRow(this.uGrid_Details.Rows[this.uGrid_Details.ActiveCell.Row.Index]);
            }

            // --- ADD 2009/02/04 -------------------------------->>>>>
            // 同商品の項目削除処理が追加されたため、当処理をCellUpdateから移動。
            // 商品項目一括変更処理
            if (this._beforeSearchExtractInfo != null
                &&
                (this._beforeSearchExtractInfo.TargetDiv == ExtractInfo.TargetDivState.GoodsStock
                || this._beforeSearchExtractInfo.TargetDiv == ExtractInfo.TargetDivState.StockGoods)
                )
            {
                // 商品のカラムのみ
                if (this.uGrid_Details.ActiveCell.Column.Index <= this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsStockDataTable.UpRateColumn.ColumnName].Index)
                {
                    // 在庫削除日は除く
                    if (this.uGrid_Details.ActiveCell.Column.Key != this._goodsStockDataTable.StockDeleteDateColumn.ColumnName)
                    {
                        string goodsNo = this.uGrid_Details.Rows[this.uGrid_Details.ActiveCell.Row.Index].Cells[this._goodsStockDataTable.GoodsNoColumn.ColumnName].Value.ToString();
                        int goodsMakerCd = (int)this.uGrid_Details.Rows[this.uGrid_Details.ActiveCell.Row.Index].Cells[this._goodsStockDataTable.GoodsMakerColumn.ColumnName].Value;

                        // セル値が更新された場合、同商品の同列の情報を上書きする
                        foreach (UltraGridRow ultraGr in this.uGrid_Details.Rows)
                        {
                            if (ultraGr.Cells[this._goodsStockDataTable.GoodsNoColumn.ColumnName].Value.ToString() == goodsNo
                                && (int)ultraGr.Cells[this._goodsStockDataTable.GoodsMakerColumn.ColumnName].Value == goodsMakerCd)
                            {
                                this.uGrid_Details.AfterCellUpdate -= this.uGrid_Details_AfterCellUpdate;
                                ultraGr.Cells[this.uGrid_Details.ActiveCell.Column.Index].Value = this.uGrid_Details.ActiveCell.Value;
                                this.uGrid_Details.AfterCellUpdate += this.uGrid_Details_AfterCellUpdate;

                                this.SetGridColorRow(ultraGr); // ADD 2009/02/04
                            }
                        }
                    }
                }
            }
            // --- ADD 2009/02/04 --------------------------------<<<<<
        }

        /// <summary>
        /// 非アクティブ前イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>行選択時の背景色を戻すために行indexを保存</br>
        /// </remarks>
        private void uGrid_Details_BeforeRowDeactivate(object sender, CancelEventArgs e)
        {
            // --- DEL 2009/02/23 -------------------------------->>>>>
            //if (this.uGrid_Details.ActiveRow != null)
            //{
            //    // 前アクティブ行インデックスの保存
            //    this._tmpActiveRowIndex = this.uGrid_Details.ActiveRow.Index;
            //}
            // --- DEL 2009/02/23 --------------------------------<<<<<
            // --- DEL 2009/03/05 -------------------------------->>>>>
            // --- ADD 2009/02/23 -------------------------------->>>>>
            //// 複数行選択を可能にしたため、選択行を残すように修正
            //foreach (UltraGridRow ultraGridRow in this.uGrid_Details.Selected.Rows)
            //{
            //    this._beforeSelectRowIndexList.Add(ultraGridRow.Index);
            //}
            // --- ADD 2009/02/23 --------------------------------<<<<<
            // --- DEL 2009/03/05 --------------------------------<<<<<
        }

        /// <summary>
        /// 選択行変更イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>無効列の背景色を設定</br>
        /// </remarks>
        private void uGrid_Details_AfterSelectChange(object sender, AfterSelectChangeEventArgs e)
        {
            this._goodsStockAcs.GoodsStockDataTable.AcceptChanges(); // ADD 2009/03/10

            // --- DEL 2009/02/23 -------------------------------->>>>>
            // 前アクティブ行の設定
            //if (this._tmpActiveRowIndex != -1
            //    && this._tmpActiveRowIndex <= this.uGrid_Details.Rows.Count)
            //{
            //    this.SetGridColorRow(this.uGrid_Details.Rows[this._tmpActiveRowIndex]);
            //}
            // --- DEL 2009/02/23 --------------------------------<<<<<
            // --- ADD 2009/02/23 -------------------------------->>>>>
            if (this._beforeSelectRowIndexList.Count != 0)
            {
                foreach(int rowIndex in this._beforeSelectRowIndexList)
                {
                    if (rowIndex <= this.uGrid_Details.Rows.Count - 1) // ADD 2009/03/05
                    {
                        this.SetGridColorRow(this.uGrid_Details.Rows[rowIndex]);
                    }
                }

                this._beforeSelectRowIndexList.Clear();
            }
            // --- ADD 2009/02/23 --------------------------------<<<<<
            // --- ADD 2009/03/05 -------------------------------->>>>>
            // BeforeRowDeactivateから移動
            foreach (UltraGridRow ultraGridRow in this.uGrid_Details.Selected.Rows)
            {
                this._beforeSelectRowIndexList.Add(ultraGridRow.Index);
            }
            // --- ADD 2009/03/05 --------------------------------<<<<<
            // --- DEL 2009/02/23 -------------------------------->>>>>
            //// アクティブ行の設定
            //if (this.uGrid_Details.ActiveRow != null)
            //{
            //    this.SetGridColorRow(this.uGrid_Details.ActiveRow);
            //}
            // --- DEL 2009/02/23 --------------------------------<<<<<
            // --- ADD 2009/02/23 -------------------------------->>>>>
            // 選択行の背景色設定
            if (this.uGrid_Details.Selected.Rows.Count != 0)
            {
                foreach (UltraGridRow ultraGr in this.uGrid_Details.Selected.Rows)
                {
                    this.SetGridColorRow(ultraGr);
                }
            }
            // --- ADD 2009/02/23 --------------------------------<<<<<


            if (this.uGrid_Details.ActiveCell != null)
            {
                this.SetGridColorRow(this.uGrid_Details.Rows[this.uGrid_Details.ActiveCell.Row.Index]);
            }

            // --- ADD 2009/02/23 -------------------------------->>>>>
            this.SetButtonEnable();
            // --- ADD 2009/02/23 --------------------------------<<<<<
        }
        #endregion

        #region ■ ボタン制御関連イベント
        // --- DEL 2009/02/23 -------------------------------->>>>>
        ///// <summary>
        ///// uGrid_Details_BeforeRowActivate
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void uGrid_Details_BeforeRowActivate(object sender, RowEventArgs e)
        //{
        //    // ボタン制御
        //    this.SetButtonEnableByRow(e.Row.Index, string.Empty);
        //}
        // --- DEL 2009/02/23 --------------------------------<<<<<

        /// <summary>
        /// uGrid_Details_Leave
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uGrid_Details_Leave(object sender, EventArgs e)
        {
            // --- DEL 2009/03/02 -------------------------------->>>>>
            //// ボタンを不可にする
            //this.uButton_RowGoodsDelete.Enabled = false;
            //this.uButton_RowGoodsRevive.Enabled = false;
            //this.uButton_RowStockDelete.Enabled = false;
            //this.uButton_RowStockRevive.Enabled = false;
            //this.uButton_RowExcuteGuide.Enabled = false;

            //// --- ADD 2009/02/04 -------------------------------->>>>>
            //if (this._beforeSearchExtractInfo.TargetDiv == ExtractInfo.TargetDivState.GoodsStock)
            //{
            //    this.uButton_RowAdd.Enabled = false;
            //}
            //// --- ADD 2009/02/04 --------------------------------<<<<<
            // --- DEL 2009/03/02 --------------------------------<<<<<
        }
        #endregion

        #region ■ フィルタ変更イベント
        // --- ADD 2009/02/23 -------------------------------->>>>>
        /// <summary>
        /// uGrid_Details_AfterRowFilterChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uGrid_Details_AfterRowFilterChanged(object sender, AfterRowFilterChangedEventArgs e)
        {
            this.SetActivationStatByFilteredOut();

            // 選択行の状態が変わるのでボタン押下制御
            this.SetButtonEnable();

            // 選択行の状態が変わるので背景色リフレッシュ
            this.SetGridColorAll();
        }

        // --- ADD 2009/02/23 --------------------------------<<<<<
        #endregion

        //---ADD 2010/08/09---------->>>>>
        /// <summary>
        /// BeforeCellUpdateイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uGrid_Details_BeforeCellUpdate(object sender, BeforeCellUpdateEventArgs e)
        {
            switch(e.Cell.Column.Key) 
            {
                case "GoodsKindCode": // 商品属性
                case "TaxationDivCd": // 課税区分
                case "OpenPriceDiv1": // オープン価格区分1
                case "OpenPriceDiv2": // オープン価格区分2
                case "OpenPriceDiv3": // オープン価格区分3
                case "OpenPriceDiv4": // オープン価格区分4
                case "OpenPriceDiv5": // オープン価格区分5
                case "StockDiv": // 在庫区分
                    {
                        if ((e.Cell.Value != null) && (!(e.Cell.Value is System.DBNull)))
                        {
                            this._preComboEditorValue = e.Cell.Value;
                        }
                        break;
                    }
            }
        }

        /// <summary>
        /// キー押下イベント処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        internal void PMZAI09201UB_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode) 
            {
                case Keys.F3:
                    {
                        uButton_RowDelete_Click(sender, e);
                        break;
                    }
                case Keys.F4:
                    {
                        uButton_RowRevive_Click(sender, e);
                        break;
                    }
                case Keys.F6:
                    {
                        uButton_RowStockDelete_Click(sender, e);
                        break;
                    }
                case Keys.F8:
                    {
                        uButton_RowStockRevive_Click(sender, e);
                        break;
                    }
                case Keys.F11:
                    {
                        uButton_RowAdd_Click(sender, e);
                        break;
                    }
                default:
                    break;
            }
        }

        /// <summary>
        /// uGrid_Details_CellDataError
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uGrid_Details_CellDataError(object sender, CellDataErrorEventArgs e)
        {
            e.RaiseErrorEvent = false;
            e.StayInEditMode = false;
        }
        //---ADD 2010/08/09----------<<<<<

        #endregion
    }       
}

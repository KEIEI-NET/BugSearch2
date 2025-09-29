using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Controller;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.UltraWinToolbars;

namespace Broadleaf.Library.Windows.Forms
{
    /// <summary>
    /// 選択ガイド
    /// </summary>
    /// <remarks>
    /// <br>本クラスはinternalで宣言されている為、外部アセンブリからは直接参照できない。</br>
    /// <br>外部アセンブリから本クラスにアクセスする場合は、操作クラスにインターフェース</br>
    /// <br>となるメソッドやプロパティを作成する事</br>
    /// <br></br>
    /// <br>Update Note	: 速度チューニング対応（表示対象データの価格一括取得を追加）</br>
    /// <br>Programmer	: 21024　佐々木 健</br>
    /// <br>Date		: 2009.02.10</br>
    /// <br></br>
    /// <br>Update Note	: 優先倉庫にトリムをかけてチェックするように修正</br>
    /// <br>Programmer	: 21024　佐々木 健</br>
    /// <br>Date		: 2009.02.16</br>
    /// <br></br>
    /// <br>Update Note	: オーナーフォーム対応</br>
    /// <br>Programmer	: 21024　佐々木 健</br>
    /// <br>Date		: 2009.02.19</br>
    /// <br></br>
    /// <br>Update Note	: MANTIS対応[0011539],[0012230]
    ///                   ①初期表示順序を、メーカー、品番順に変更
    ///                   ②品名表示「提供優先」時にユーザー登録品の品名が表示されない不具合の修正</br>
    /// <br>Programmer	: 21024　佐々木 健</br>
    /// <br>Date		: 2009.02.19</br>
    /// <br></br>
    /// <br>Update Note	: 在庫表示順で優先倉庫が上に表示されるよう変更</br>
    /// <br>             : 在庫の選択方法をチェック方式に変更（未チェックで取寄を選択可能に変更）</br>
    /// <br>Programmer	: 22018　鈴木 正臣</br>
    /// <br>Date		: 2009.03.27</br>
    /// <br></br>
    /// <br>Update Note	: 品名表示区分が提供優先時の表示順位変更</br>
    /// <br>Programmer	: 20056 對馬 大輔</br>
    /// <br>Date		: 2009.08.03</br>
    /// <br></br>
    /// <br>Update Note	: 品番検索で同一品番ウィンドウで部品選択後、落ちる現象の修正(MANTIS[0014749])</br>
    /// <br>Programmer	: 21024　佐々木 健</br>
    /// <br>Date		: 2009/12/03</br>
    /// <br></br>
    /// <br>Update Note	: ①セット・結合品の場合に、優先倉庫情報がセットされない現象の修正(MANTIS[0014650])</br>
    /// <br>            : ②代替後、同一部品が複数存在する場合に落ちる現象の修正(MANTIS[0014772])</br>
    /// <br>Programmer	: 21024　佐々木 健</br>
    /// <br>Date		: 2009/12/14</br>
    /// <br></br>
    /// <br>Update Note: 2010/06/08　李占川　障害改良対応（７月リリース分）の対応</br>
    /// <br>             表示可能最大件数を超えた場合はメッセージを表示する様に変更</br>
    /// <br></br>
    /// <br>Update Note  : 障害改良対応（８月分）</br>
    /// <br>             :   ・在庫の明細件数がゼロならば在庫グリッドに移動しないよう変更。</br>
    /// <br>Programmer   : 22018  鈴木 正臣</br>
    /// <br>Date         : 2010/10/26</br>
    /// <br></br>
    /// <br>Update Note  : 障害改良対応（ｘｘ月分）</br>
    /// <br>             :   ①代替する場合も代替元の情報を表示するように変更。</br>
    /// <br>             :   ②代替する/しないの判定をＰＭ７準拠の仕様に変更。</br>
    /// <br>Programmer   : 22018  鈴木 正臣</br>
    /// <br>Date         : 2011/01/31</br>
    /// <br></br>
    /// <br>Update Note  : 障害改良対応（ｘｘ月分）</br>
    /// <br>             :   ・2011/01/31分の修正。在庫有無判定は優先倉庫のみ対象とする。(PM7準拠)</br>
    /// <br>Programmer   : 22018  鈴木 正臣</br>
    /// <br>Date         : 2011/02/09</br>
    /// <br></br>
    /// <br>Update Note  : 障害改良対応(ｘｘ月分)</br>
    /// <br>             :   ・2011/02/09分の修正。優先倉庫未設定の場合の処理を修正(異常終了させない)</br>
    /// <br>Programmer   : 22018  鈴木 正臣</br>
    /// <br>Date         : 2011/02/18</br>
    /// <br></br>
    /// <br>Update Note: 2011/07/25　譚洪　連番No.702の対応</br>
    /// <br>             代替する（在庫無）の場合、在庫数＞１での条件にして欲しい。品番入力の場合も、在庫条件を参照して欲しい</br>
    /// <br>Update Note  : 2011/11/29　yangmj　redmine#7759 の対応</br>
    /// <br>               結合選択が表示されないの修正</br>
    /// <br>Update Note　: 2011/12/26　田建委</br>
    /// <br>             　Redmine#27481 売上伝票入力/優先倉庫の取得の対応</br>
    /// <br>Update Note　: 2014/03/03　脇田 靖之</br>
    /// <br>             　仕掛一覧 №2311 品番項目表示幅変更対応</br>
    /// <br>Update Note　: 2014/03/04　脇田 靖之</br>
    /// <br>             　仕掛一覧 №2311 システムテスト障害対応</br>
    /// </remarks>
    public partial class SelectionSamePartsNoParts : Form
    {
        # region DataTableスキーマ情報 (DataGrid表示用)
        private PartsInfoDataSet _orgDataSet = null;
        private SameParts dataSet = null;
        private SameParts.SamePartsDataTable _PartsTable = null;
        private SameParts.StockDataTable _StockTable = null;
        //internal SameParts.SamePartsDataTable SamePartsTable
        //{
        //    get
        //    {
        //        return _PartsTable;
        //    }
        //}
        #endregion

        #region [ Private Member ]
        /// <summary>0:品番検索 1:品番結合検索 2:品番検索[エントリ用] 3:在庫組立 </summary>
        private int _mode = 0;
        private bool isUserClose = true;
        private bool uiControlFlg; // false:PM7スタイル　　true:PM.NSスタイル
        //private bool substFlg;     // false:代替なし       true:代替あり
        private int userSubstFlg;
        private int enterFlg;           // 0:PM7, 1:選択 2:次画面（純正⇒結合、結合⇒セット、セット⇒確定）
        private int totalAmountDispWay;       // 総額表示方法区分 0:総額表示しない（税抜き）,1:総額表示する（税込み）

        private List<int> _makerList = null;
        private SelectionInfo _prevSelInfo;
        private bool isDialogShown = true;
        /// <summary> ダイアログが表示可否フラグ（データ数により自動判定） </summary>
        public bool IsDialogShown
        {
            get { return isDialogShown; }
        }
        # endregion

        /// <summary>
        /// 選択画面コンストラクタ
        /// </summary>
        /// <param name="dsSource">グリッドに表示するデータを指定します。</param>
        /// <param name="Mode">0:品番検索[マスメン用] 1:品番結合検索 2:品番検索[エントリ用] 3:在庫組立</param>
        /// <param name="makerList"></param>
        public SelectionSamePartsNoParts(PartsInfoDataSet dsSource, int Mode, List<int> makerList)
        {
            InitializeComponent(); // ADD 2010/06/08

            _mode = Mode;
            _makerList = makerList;
            _orgDataSet = dsSource;
            Thread initialProcThread = new Thread(InitializeData);
            initialProcThread.Start();

            if (dsSource.SearchCondition != null)
            {
                uiControlFlg = Convert.ToBoolean(dsSource.SearchCondition.SearchCntSetWork.SearchUICntDivCd); // 0:PM7スタイル／1:PM.NSスタイル
                //substFlg = (dsSource.SearchCondition.SearchCntSetWork.SubstCondDivCd != 0);
                //substFlg = false; // 品番検索時提供代替情報を取得しないことにする。　20081011 Ahn
                userSubstFlg = dsSource.SearchCondition.SearchCntSetWork.SubstApplyDivCd;
                enterFlg = dsSource.SearchCondition.SearchCntSetWork.EnterProcDivCd; // 0:PM7, 1:選択 2:次画面（純正⇒結合、結合⇒セット、セット⇒確定）
                totalAmountDispWay = dsSource.SearchCondition.SearchCntSetWork.TotalAmountDispWayCd; // 0:総額表示しない（税抜き）,1:総額表示する（税込み）
            }
            else // マスメンなど直で同一品番選択UIを表示する場合
            {
                uiControlFlg = true;
                //substFlg = false;
                userSubstFlg = 0;
            }

            //InitializeComponent(); // DEL 2010/06/08
            if (_mode == 1)
            {
                Width = 1010;
            }
            else
            {
                Width = 950;
            }
            // ツールバーのイメージ(16x16)やメッセージを設定する
            ToolbarsManager.ImageListSmall = IconResourceManagement.ImageList16;
            ToolbarsManager.Tools["Button_Select"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.DECISION;
            ToolbarsManager.Tools["Button_Back"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.BEFORE;
            ToolbarsManager.Tools["Button_Subst"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CARADD;
            ToolbarsManager.Tools["Button_SubstOff"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.UNDO;
            if (uiControlFlg && _mode == 2 && _orgDataSet.SearchCondition.SearchFlg == SearchFlag.GoodsAndSetInfo)
            {
                ToolbarsManager.Tools["Button_Set"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.MODEL;
                ToolbarsManager.Tools["Button_Join"].SharedProps.Visible = false;
            }
            else if (_mode != 1 || uiControlFlg == false)
            {
                //if (_mode == 0)
                //{
                //    ToolbarsManager.Tools["Button_Subst"].SharedProps.Visible = false;
                //}
                ToolbarsManager.Tools["Button_Set"].SharedProps.Visible = false;
                ToolbarsManager.Tools["Button_Join"].SharedProps.Visible = false;
            }
            else
            {
                ToolbarsManager.Tools["Button_Set"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.MODEL;
                ToolbarsManager.Tools["Button_Join"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CARCHANGE;
            }
            ToolbarsManager.Tools["Button_Subst"].SharedProps.Visible = false; // 品番検索の提供代替なしとする 20081011 Ahn
            ToolbarsManager.Tools["Button_SubstOff"].SharedProps.Visible = false;
            StatusBar.Text = "";

            while (initialProcThread.ThreadState == ThreadState.Running)
            {
                Thread.Sleep(10);
            }
            //InitializeData();
            InitializeTable();

        }

        private void InitializeTable()
        {
            gridParts.BeginUpdate();
            // 2009.03.06 >>>
            //gridParts.DataSource = _PartsTable;
            gridParts.DataSource = _PartsTable.DefaultView;
            // 2009.03.06 <<<
            gridParts.EndUpdate();
            gridStock.DataSource = _StockTable.DefaultView;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/26 ADD
            SettingStockView( _StockTable.DefaultView );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/26 ADD
        }
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/26 ADD
        /// <summary>
        /// 在庫のDataSourceとなるViewを設定します
        /// </summary>
        /// <param name="dataView"></param>
        private void SettingStockView( DataView dataView )
        {
            // ソート設定
            dataView.Sort = string.Format( "{0}, {1}",
                                            _StockTable.SortDivColumn.ColumnName,
                                            _StockTable.WarehouseCodeColumn.ColumnName );
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/26 ADD

        /// <summary>
        /// ダイアログを表示します。（結合、セット選択UIにて元部品を選択した場合は表示せず、終了します）
        /// </summary>
        /// <param name="owner"></param>
        /// <param name="previousRet"></param>
        /// <returns></returns>
        // 2009.02.19 >>>
        //public DialogResult ShowDialog(DialogResult previousRet)
        public DialogResult ShowDialog(IWin32Window owner, DialogResult previousRet)
        // 2009.02.19 <<<
        {
            if (previousRet != DialogResult.Cancel)
            {
                //string filter = string.Format("{0} = 0 AND {1} = True",
                //    _orgDataSet.UsrGoodsInfo.GoodsKindColumn.ColumnName,
                //    _orgDataSet.UsrGoodsInfo.SelectionStateColumn.ColumnName);
                //string filter = string.Format("{0} = True",
                //    _orgDataSet.UsrGoodsInfo.SelectionStateColumn.ColumnName);
                //if (_orgDataSet.UsrGoodsInfo.Select(filter).Length > 0)
                //    return DialogResult.OK;
                if (_prevSelInfo != null && _orgDataSet.ListSelectionInfo.ContainsKey(_prevSelInfo.Key)
                    && _orgDataSet.ListSelectionInfo[_prevSelInfo.Key].IsThereSelection)
                    return DialogResult.OK;
            }
            if (CheckCount())
            {
                if (uiControlFlg)
                {
                    return DialogResult.Retry;
                }
                return DialogResult.OK;
            }

            if (previousRet == DialogResult.OK)
            {
                PartsInfoDataSet.UsrGoodsInfoRow orgRow = _orgDataSet.UsrGoodsInfo.RowToProcess;
                if (orgRow != null && orgRow.NewGoodsNo != string.Empty) //代替された部品があるかチェック[NewGoodsNo:代替先品番]
                {
                    SameParts.SamePartsRow oldRow = _PartsTable.FindByMakerCodePartsNo(orgRow.GoodsMakerCd, orgRow.GoodsNo);
                    PartsInfoDataSet.UsrGoodsInfoRow newRow =
                        _orgDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(orgRow.GoodsMakerCd, orgRow.NewGoodsNo);

                    // 代替する前の選択した結合先・セット子部品情報クリア
                    _prevSelInfo.ListChildGoods.Clear();
                    _prevSelInfo.ListChildGoods2.Clear();
                    if (_prevSelInfo.ListPlrlSubst.Count > 0)
                        _prevSelInfo.ListPlrlSubst.RemoveAt(0); // 1個目は代替品情報なので削除しておく。

                    oldRow.OldPartsNo = oldRow.PartsNo;
                    oldRow.PartsNo = newRow.GoodsNo;
                    oldRow.PartsName = newRow.GoodsName;
                    if (totalAmountDispWay == 1) // 総額表示する（税込み）
                    {
                        oldRow.Price = newRow.PriceTaxInc;
                    }
                    else // 総額表示しない（税抜き）
                    {
                        oldRow.Price = newRow.PriceTaxExc;
                    }
                    SetImage(oldRow);
                    SetButtonState();
                    ToolbarsManager.Tools["Button_SubstOff"].SharedProps.Visible = true;

                    orgRow.SelectionState = false;
                    orgRow.NewGoodsNo = string.Empty;
                }
            }
            isUserClose = true;
            // 2009.02.19 >>>
            //return base.ShowDialog();
            return base.ShowDialog(owner);
            // 2009.02.19 <<<
        }

        /// <summary>
        /// 同一品番選択UIを表示する
        /// </summary>
        /// <returns></returns>
        // 2009.02.19 >>>
        //public new DialogResult ShowDialog()
        public new DialogResult ShowDialog(IWin32Window owner)
        // 2009.02.19 <<<
        {
            if (CheckCount())
            {
                if (uiControlFlg && (_orgDataSet.JoinSrcSelInf != null || _orgDataSet.SetSrcSelInf != null))
                {
                    return DialogResult.Retry;
                }
                return DialogResult.OK;
            }
            // 2009.02.19 >>>
            //return base.ShowDialog();
            return base.ShowDialog(owner);
            // 2009.02.19 <<<
        }

        /// <summary>
        /// UOEのメーカーリストによる絞込時の表示部品数チェック処理
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Update Note : 2011/12/26　田建委</br>
        /// <br>              Redmine#27481 売上伝票入力/優先倉庫の取得の対応</br>
        /// </remarks>
        private bool CheckCount()
        {
            if (_PartsTable.Count == 0) // メーカー複数指定による絞込の場合、この画面を開いても表示する部品がない場合がある。
                return true;

            bool flg = (_orgDataSet.UsrJoinParts.Count == 0 && _orgDataSet.UsrSetParts.Count == 0);// && _orgDataSet.UsrSubstParts.Count == 0);
            //string query = string.Format("{0}={1} AND {2}='{3}'",
            //    _orgDataSet.UsrSubstParts.ChgSrcMakerCdColumn.ColumnName, _PartsTable[0].MakerCode,
            //    _orgDataSet.UsrSubstParts.ChgSrcGoodsNoColumn.ColumnName, _PartsTable[0].PartsNo);
            if (_PartsTable.Count == 1) // 品番検索の対象は1個しかない場合
            {
                //if (_mode == 0                                // 品番検索の場合：部品1個ならそのまま選択UI終了
                //          || (_mode == 1 && flg) // 品番結合検索：自分自身が結合先などになるケース顧慮
                //    //          || (_mode == 1 && _orgDataSet.UsrGoodsInfo.Count == 1 && flg) // 品番結合検索：自分自身が結合先などになるケース顧慮
                //    //          || (uiControlFlg == false && _orgDataSet.UsrSubstParts.Select(query).Length == 0) // PM7式：代替がない場合そのまま選択UI終了
                //    )
                //{
                // --- UPD m.suzuki 2011/01/31 ---------->>>>>
                //PartsInfoDataSet.UsrGoodsInfoRow row =
                //    _orgDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo( _PartsTable[0].MakerCode, _PartsTable[0].PartsNoToShow );
                PartsInfoDataSet.UsrGoodsInfoRow row =
                    _orgDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo( _PartsTable[0].MakerCodeToShow, _PartsTable[0].PartsNoToShow );
                // --- UPD m.suzuki 2011/01/31 ----------<<<<<

                _orgDataSet.UsrGoodsInfo.RowToProcess = row;
                SelectionInfo selInfo = new SelectionInfo();
                selInfo.Depth = 0;
                selInfo.Key = gridParts.Rows[0].ListIndex;
                selInfo.RowGoods = row;
                _orgDataSet.AddSelectionInfo(_orgDataSet.ListSelectionInfo, selInfo.Key, ref selInfo);
                if (gridParts.Rows[0].Cells[_PartsTable.JoinColumn.ColumnName].Value.Equals(DBNull.Value)
                        && gridParts.Rows[0].Cells[_PartsTable.SetColumn.ColumnName].Value.Equals(DBNull.Value))
                { // 結合もセットもない場合
                    selInfo.Selected = true;

                    string filter = string.Format("{0}={1} AND {2}='{3}' ",
                        // --- UPD m.suzuki 2011/01/31 ---------->>>>>
                        //_StockTable.GoodsMakerCdColumn.ColumnName, _PartsTable[0].MakerCode,
                        _StockTable.GoodsMakerCdColumn.ColumnName, _PartsTable[0].MakerCodeToShow,
                        // --- UPD m.suzuki 2011/01/31 ----------<<<<<
                        _StockTable.GoodsNoColumn.ColumnName, _PartsTable[0].PartsNoToShow);
                    _StockTable.DefaultView.RowFilter = filter;
                    if (_orgDataSet.ListPriorWarehouse != null) // 優先倉庫指定あり
                    {
                        for (int i = 0; i < _orgDataSet.ListPriorWarehouse.Count; i++)
                        {
                            // 2009.02.16 >>>
                            //string warehouseCd = _orgDataSet.ListPriorWarehouse[i];
                            string warehouseCd = _orgDataSet.ListPriorWarehouse[i].Trim();
                            // 2009.02.16 <<<
                            for (int j = 0; j < _StockTable.DefaultView.Count; j++)
                            {
                                if (warehouseCd.Equals(_StockTable.DefaultView[j][_StockTable.WarehouseCodeColumn.ColumnName]))
                                {
                                    selInfo.WarehouseCode = warehouseCd;
                                    return true;
                                }
                            }
                        }
                    }
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/27 DEL // 優先倉庫にない場合は取寄にする
                    //if (_StockTable.DefaultView.Count > 0)
                    //    selInfo.WarehouseCode = _StockTable.DefaultView[0][_StockTable.WarehouseCodeColumn.ColumnName].ToString();
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/27 DEL
                }
                else
                {
                    bool flgStock = false; // ADD 2011/12/26 tianjw Redmine#27481
                    // 2009/12/14 Add >>>
                    if (_orgDataSet.ListPriorWarehouse != null) // 優先倉庫指定あり
                    {
                        string orgFilter = _StockTable.DefaultView.RowFilter;
                        try
                        {
                            string filter = string.Format("{0}={1} AND {2}='{3}' ",
                                _StockTable.GoodsMakerCdColumn.ColumnName, _PartsTable[0].MakerCode,
                                // --- UPD m.suzuki 2011/01/31 ---------->>>>>
                                //_StockTable.GoodsNoColumn.ColumnName, _PartsTable[0].PartsNoToShow);
                                _StockTable.GoodsNoColumn.ColumnName, _PartsTable[0].PartsNo);
                                // --- UPD m.suzuki 2011/01/31 ----------<<<<<
                            _StockTable.DefaultView.RowFilter = filter;
                            //if (_StockTable.DefaultView.Count > 0) // DEL 2011/12/26 tianjw Redmine#27481
                            if (flgStock == false && _StockTable.DefaultView.Count > 0) // ADD 2011/12/26 tianjw Redmine#27481
                            {
                                for (int i = 0; i < _orgDataSet.ListPriorWarehouse.Count; i++)
                                {
                                    string warehouseCd = _orgDataSet.ListPriorWarehouse[i].Trim();
                                    for (int j = 0; j < _StockTable.DefaultView.Count; j++)
                                    {
                                        if (warehouseCd.Equals(_StockTable.DefaultView[j][_StockTable.WarehouseCodeColumn.ColumnName]))
                                        {
                                            selInfo.WarehouseCode = warehouseCd;
                                            // --- ADD 2011/12/26 tianjw Redmine#27481 --->>>>>
                                            flgStock = true;
                                            break;
                                            // --- ADD 2011/12/26 tianjw Redmine#27481 ---<<<<<
                                        }
                                    }
                                    // --- ADD 2011/12/26 tianjw Redmine#27481 --->>>>>
                                    if (flgStock)
                                    {
                                        break;
                                    }
                                    // --- ADD 2011/12/26 tianjw Redmine#27481 ---<<<<<
                                }
                            }
                        }
                        finally
                        {
                            _StockTable.DefaultView.RowFilter = orgFilter;
                        }
                    }
                    // 2009/12/14 Add <<<
                    if (uiControlFlg)
                    {
                        if (gridParts.Rows[0].Cells[_PartsTable.JoinColumn.ColumnName].Value.Equals(DBNull.Value) == false)
                        {
                            _orgDataSet.JoinSrcSelInf = selInfo;
                            _orgDataSet.UIKind = SelectUIKind.Join;
                        }
                        else if (gridParts.Rows[0].Cells[_PartsTable.SetColumn.ColumnName].Value.Equals(DBNull.Value) == false)
                        {
                            _orgDataSet.SetSrcSelInf = selInfo;
                            _orgDataSet.UIKind = SelectUIKind.Set;
                        }
                    }
                }
                isDialogShown = false;
                return true;
            }
            return false;
        }

        #region インターナル
        internal static class ColInfo
        {
            public static void SetColInfo(UltraGridBand Band, string colname, int originX, int originY, int width)
            {
                System.Drawing.Size sizeHeader = new Size();
                System.Drawing.Size sizeCell = new Size();

                Band.RowLayoutLabelPosition = Infragistics.Win.UltraWinGrid.LabelPosition.Top;
                Band.RowLayoutLabelStyle = Infragistics.Win.UltraWinGrid.RowLayoutLabelStyle.Separate;

                Band.Columns[colname].RowLayoutColumnInfo.LabelSpan = 2;
                Band.Columns[colname].RowLayoutColumnInfo.OriginX = originX;
                Band.Columns[colname].RowLayoutColumnInfo.OriginY = originY;

                sizeCell.Height = 24;
                sizeCell.Width = width;
                Band.Columns[colname].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
                sizeHeader.Height = 24;
                sizeHeader.Width = width;
                Band.Columns[colname].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            }
            public static void SetColInfo(UltraGridBand Band, string colname, int originX, int originY, int spanX, int spanY, int width)
            {
                System.Drawing.Size sizeHeader = new Size();
                System.Drawing.Size sizeCell = new Size();

                Band.RowLayoutLabelPosition = Infragistics.Win.UltraWinGrid.LabelPosition.Top;
                Band.RowLayoutLabelStyle = Infragistics.Win.UltraWinGrid.RowLayoutLabelStyle.Separate;

                Band.Columns[colname].RowLayoutColumnInfo.LabelSpan = 2;
                Band.Columns[colname].RowLayoutColumnInfo.OriginX = originX;
                Band.Columns[colname].RowLayoutColumnInfo.OriginY = originY;
                Band.Columns[colname].RowLayoutColumnInfo.SpanX = spanX;
                Band.Columns[colname].RowLayoutColumnInfo.SpanY = spanY;

                sizeCell.Height = 24;
                sizeCell.Width = width;
                Band.Columns[colname].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
                sizeHeader.Height = 24;
                sizeHeader.Width = width;
                Band.Columns[colname].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            }

        }
        #endregion

        private void InitializeData()
        {
            // 2009.02.10 Add >>>
            this.SettingPriceTargetData();
            // 2009.02.10 Add <<<
            #region データセット

            dataSet = new SameParts();
            _PartsTable = dataSet._SameParts;
            _StockTable = dataSet.Stock;

            try
            {
                SameParts.SamePartsRow wkRow = null;
                SameParts.StockRow stockRow = null;

                #region [ フィルタリング条件算出 ]
                string filter = string.Empty;
                string cond = string.Empty;
                string colName = string.Empty;
                string queryOp = string.Empty;
                string goodsNo = string.Empty;

                if (_orgDataSet.SearchCondition != null)
                {
                    switch (_orgDataSet.SearchCondition.SearchType)
                    {
                        case SearchType.WholeWord:
                            queryOp = " = ";
                            goodsNo = _orgDataSet.SearchCondition.PartsNo;
                            break;
                        case SearchType.WholeWordWithNoHyphen:
                            queryOp = " = ";
                            goodsNo = _orgDataSet.SearchCondition.PartsNo;
                            colName = _orgDataSet.UsrGoodsInfo.GoodsNoNoneHyphenColumn.ColumnName;
                            break;
                        case SearchType.FreeSearch:
                            queryOp = " LIKE ";
                            goodsNo = "%" + _orgDataSet.SearchCondition.PartsNo + "%";
                            break;
                        case SearchType.PrefixSearch:
                            queryOp = " LIKE ";
                            goodsNo = _orgDataSet.SearchCondition.PartsNo + "%";
                            break;
                        case SearchType.SuffixSearch:
                            queryOp = " LIKE ";
                            goodsNo = "%" + _orgDataSet.SearchCondition.PartsNo;
                            break;
                        default:
                            queryOp = " = ";
                            goodsNo = _orgDataSet.SearchCondition.PartsNo;
                            break;
                    }
                    if (colName == string.Empty)
                    {
                        if (goodsNo.Contains("-"))
                        {
                            colName = _orgDataSet.UsrGoodsInfo.GoodsNoColumn.ColumnName;
                        }
                        else
                        {
                            colName = _orgDataSet.UsrGoodsInfo.GoodsNoNoneHyphenColumn.ColumnName;
                        }
                    }
                    if (_orgDataSet.SearchCondition.PartsMakerCode != 0)
                    {
                        cond = string.Format("{0} {1} '{2}' AND {3} = {4}", colName, queryOp, goodsNo,
                                _orgDataSet.UsrGoodsInfo.GoodsMakerCdColumn.ColumnName, _orgDataSet.SearchCondition.PartsMakerCode);
                    }
                    else
                    {
                        cond = string.Format("{0} {1} '{2}'", colName, queryOp, goodsNo);
                    }
                    string cond2 = string.Empty;
                    if (_makerList != null)
                    {
                        for (int i = 0; i < _makerList.Count; i++)
                        {
                            cond2 += string.Format(" {0} = {1} OR ", _orgDataSet.UsrGoodsInfo.GoodsMakerCdColumn.ColumnName, _makerList[i]);
                        }
                        cond2 = cond2.Remove(cond2.Length - 3);
                    }

                    if (_orgDataSet.UsrGoodsInfo.DefaultView.RowFilter.Length == 0)
                    {
                        filter = cond;
                    }
                    else
                    {
                        filter = string.Format("( {0} ) AND {1} ",
                            _orgDataSet.UsrGoodsInfo.DefaultView.RowFilter, cond);
                    }
                    if (cond2 != string.Empty)
                    {
                        filter = string.Format("( {0} ) AND ( {1} )", filter, cond2);
                    }
                    if (_mode == 3) // 在庫組立用
                    {
                        filter = string.Format("( {0} ) AND ( {1} <= 2 )", filter, _orgDataSet.UsrGoodsInfo.OfferKubunColumn.ColumnName); // ユーザー登録商品か
                    }
                }
                #endregion
                _PartsTable.BeginLoadData();
                PartsInfoDataSet.UsrGoodsInfoRow[] usrRows =
                    (PartsInfoDataSet.UsrGoodsInfoRow[])_orgDataSet.UsrGoodsInfo.Select(filter, _orgDataSet.UsrGoodsInfo.OfferKubunColumn.ColumnName);
                //for (int i = 0; i < usrRows.Length; i++) // DEL 2010/06/08
                for (int i = 0; i < usrRows.Length && i < 200; i++) // ADD 2010/06/08
                {
                    #region [ 部品情報設定 ]
                    PartsInfoDataSet.UsrGoodsInfoRow row;

                    // --- UPD m.suzuki 2011/01/31 ---------->>>>>
                    //if (userSubstFlg > 0 && 
                    //    (_mode == 1 || 
                    //    (_mode == 2 && _orgDataSet.SearchCondition.SearchFlg == SearchFlag.GoodsAndSetInfo)))
                    //    row = _orgDataSet.GetUsrSubst(usrRows[i]);
                    //else
                    //    row = usrRows[i];
                    ////if (_mode == 0 || _mode == 3 || userSubstFlg == 0)
                    ////    row = usrRows[i];
                    ////else
                    ////    row = _orgDataSet.GetUsrSubst(usrRows[i]);
                    // --- UPD 2011/07/25 ---- >>>>>
                    //if ( userSubstFlg > 0 &&
                    //    (_mode == 1 ||
                    //    (_mode == 2 && _orgDataSet.SearchCondition.SearchFlg == SearchFlag.GoodsAndSetInfo)) )
                    // --- UPD 2011/11/29 ---- >>>>>
                    //if ((_mode == 1 ||
                    //(_mode == 2 && _orgDataSet.SearchCondition.SearchFlg == SearchFlag.GoodsAndSetInfo)))
                     if ( userSubstFlg > 0 &&
                        (_mode == 1 ||
                        (_mode == 2 && _orgDataSet.SearchCondition.SearchFlg == SearchFlag.GoodsAndSetInfo)) )
                    // --- UPD 2011/11/29 ---- <<<<<
                    // --- UPD 2011/07/25 ---- <<<<<
                    {
                        if ( CatalogPartsStockCheck( usrRows[i].GoodsNo, usrRows[i].GoodsMakerCd ) )
                        {
                            // 代替元品番の在庫が存在する場合は、代替元
                            row = usrRows[i];
                        }
                        else
                        {
                            // 代替先
                            row = _orgDataSet.GetUsrSubst( usrRows[i] );
                        }
                    }
                    else
                    {
                        // 代替元
                        row = usrRows[i];
                    }
                    // --- UPD m.suzuki 2011/01/31 ----------<<<<<

                    // --- UPD m.suzuki 2011/01/31 ---------->>>>>
                    //// 2009/12/14 Add >>>
                    //if (_PartsTable.FindByMakerCodePartsNo(row.GoodsMakerCd, usrRows[i].GoodsNo) != null) continue;
                    //// 2009/12/14 Add <<<
                    if ( _PartsTable.FindByMakerCodePartsNo( usrRows[i].GoodsMakerCd, usrRows[i].GoodsNo ) != null ) continue;
                    // --- UPD m.suzuki 2011/01/31 ----------<<<<<

                    // --- UPD m.suzuki 2011/01/31 ---------->>>>>
                    //PartsInfoDataSet.StockRow[] stockRows = (PartsInfoDataSet.StockRow[])row.GetChildRows( "UsrGoodsInfo_Stock" );
                    // (代替先の)在庫
                    List<PartsInfoDataSet.StockRow> stockRowList = new List<PartsInfoDataSet.StockRow>( (PartsInfoDataSet.StockRow[])row.GetChildRows( "UsrGoodsInfo_Stock" ) );
                    if ( usrRows[i].GoodsNo != row.GoodsNo || usrRows[i].GoodsMakerCd != row.GoodsMakerCd )
                    {
                        // 代替元の在庫
                        stockRowList.AddRange( (PartsInfoDataSet.StockRow[])usrRows[i].GetChildRows( "UsrGoodsInfo_Stock" ) );
                    }
                    PartsInfoDataSet.StockRow[] stockRows = stockRowList.ToArray();
                    // --- UPD m.suzuki 2011/01/31 ----------<<<<<
                    if (_mode == 3)　// 在庫組立の場合
                    {
                        if (_orgDataSet.UsrSetParts.SetExist(row.GoodsMakerCd, row.GoodsNo) == false) // セット情報がない場合登録しない。
                            continue;
                        if (stockRows.Length == 0) // 在庫がない場合登録しない。
                            continue;
                    }

                    wkRow = _PartsTable.NewSamePartsRow();
                    // データセット
                    // --- DEL m.suzuki 2011/01/31 ---------->>>>>
                    # region // DEL
                    //wkRow.MakerCode = row.GoodsMakerCd;
                    //wkRow.MakerName = row.GoodsMakerNm;
                    //wkRow.PartsNo = usrRows[i].GoodsNo; // ユーザー代替されるとき、この品番がユニーク
                    //wkRow.PartsNoToShow = row.GoodsNo;  // この品番が表示される。ユーザー代替されるときはユニークでないかも
                    //if (_orgDataSet.PartsNameDspDivCd == 0) // 品名表示区分が商品優先の場合
                    //{
                    //    if (row.GoodsName != string.Empty)
                    //    {
                    //        wkRow.PartsName = row.GoodsName;
                    //    }
                    //    else
                    //    {
                    //        wkRow.PartsName = row.GoodsOfrName;
                    //    }
                    //}
                    //else  // 品名表示区分が提供優先の場合
                    //{
                    //    // 2009.08.03 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                    //    //// 2009.03.06 >>>
                    //    ////if (row.GoodsName != string.Empty)
                    //    //if (row.GoodsOfrName != string.Empty)
                    //    //// 2009.03.06 <<<
                    //    //{
                    //    //    wkRow.PartsName = row.GoodsOfrName;
                    //    //}
                    //    //else
                    //    //{
                    //    //    wkRow.PartsName = row.GoodsName;
                    //    //}
                    //    if (row.GoodsName != string.Empty)
                    //    {
                    //        wkRow.PartsName = row.GoodsName;
                    //    }
                    //    else
                    //    {
                    //        wkRow.PartsName = row.GoodsOfrName;
                    //    }
                    //    // 2009.08.03 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                    //}
                    //if (totalAmountDispWay == 1) // 総額表示する（税込み）
                    //{
                    //    wkRow.Price = row.PriceTaxInc;
                    //}
                    //else // 総額表示しない（税抜き）
                    //{
                    //    wkRow.Price = row.PriceTaxExc;
                    //}
                    //
                    //SetImage(wkRow);
                    //if (row.OfferKubun == 0)
                    //    wkRow.Attr = "純正";
                    //else
                    //    wkRow.Attr = "優良";
                    # endregion
                    // --- DEL m.suzuki 2011/01/31 ----------<<<<<
                    // --- ADD m.suzuki 2011/01/31 ---------->>>>>
                    // 代替元：PartsNo, MakerCode
                    // 代替先：PartsNoToShow, MakerCodeToShow
                    wkRow.PartsNoToShow = row.GoodsNo;  // 代替後の品番
                    wkRow.MakerCodeToShow = row.GoodsMakerCd; // 代替後のメーカーコード

                    wkRow.MakerCode = usrRows[i].GoodsMakerCd; // 代替前のメーカーコード

                    // ↓以下、代替元の情報に変更
                    wkRow.MakerName = usrRows[i].GoodsMakerNm;
                    wkRow.PartsNo = usrRows[i].GoodsNo; // ユーザー代替されるとき、この品番がユニーク
                    if ( _orgDataSet.PartsNameDspDivCd == 0 ) // 品名表示区分が商品優先の場合
                    {
                        if ( usrRows[i].GoodsName != string.Empty )
                        {
                            wkRow.PartsName = usrRows[i].GoodsName;
                        }
                        else
                        {
                            wkRow.PartsName = usrRows[i].GoodsOfrName;
                        }
                    }
                    else  // 品名表示区分が提供優先の場合
                    {
                        if ( usrRows[i].GoodsName != string.Empty )
                        {
                            wkRow.PartsName = usrRows[i].GoodsName;
                        }
                        else
                        {
                            wkRow.PartsName = usrRows[i].GoodsOfrName;
                        }
                    }
                    if ( totalAmountDispWay == 1 ) // 総額表示する（税込み）
                    {
                        wkRow.Price = usrRows[i].PriceTaxInc;
                    }
                    else // 総額表示しない（税抜き）
                    {
                        wkRow.Price = usrRows[i].PriceTaxExc;
                    }

                    SetImage( wkRow );
                    if ( usrRows[i].OfferKubun == 0 )
                        wkRow.Attr = "純正";
                    else
                        wkRow.Attr = "優良";
                    // --- ADD m.suzuki 2011/01/31 ----------<<<<<

                    _PartsTable.AddSamePartsRow(wkRow);
                    #endregion

                    bool flgStock = false;

                    for (int j = 0; j < stockRows.Length; j++)
                    {
                        if (_StockTable.FindByWarehouseCodeGoodsMakerCdGoodsNo(stockRows[j].WarehouseCode,
                            stockRows[j].GoodsMakerCd, stockRows[j].GoodsNo) == null)
                        {
                            stockRow = _StockTable.NewStockRow();
                            stockRow.GoodsMakerCd = stockRows[j].GoodsMakerCd;
                            stockRow.GoodsNo = stockRows[j].GoodsNo;
                            stockRow.MaximumStockCnt = stockRows[j].MaximumStockCnt;
                            stockRow.MinimumStockCnt = stockRows[j].MinimumStockCnt;
                            stockRow.ShipmentPosCnt = stockRows[j].ShipmentPosCnt;
                            stockRow.WarehouseCode = stockRows[j].WarehouseCode;
                            stockRow.WarehouseName = stockRows[j].WarehouseName;
                            stockRow.WarehouseShelfNo = stockRows[j].WarehouseShelfNo;
                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/27 ADD
                            // 在庫情報のソートに使用する区分値をセットする
                            if ( _orgDataSet.ListPriorWarehouse != null )
                            {
                                int index = _orgDataSet.ListPriorWarehouse.IndexOf( stockRow.WarehouseCode.Trim() );
                                if ( index >= 0 )
                                {
                                    // 優先倉庫リストにあればindexをセット
                                    stockRow.SortDiv = index;
                                }
                                else
                                {
                                    // 優先倉庫リストになければリストのCount(最大のindex+1)
                                    stockRow.SortDiv = _orgDataSet.ListPriorWarehouse.Count;
                                }
                            }
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/27 ADD
                            _StockTable.AddStockRow(stockRow);
                            if (stockRows[j].SelectionState)
                            {
                                wkRow.Shelf = stockRow.WarehouseShelfNo;
                                wkRow.StockCnt = stockRow.ShipmentPosCnt;
                                wkRow.Warehouse = stockRow.WarehouseName;
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/27 ADD
                                wkRow.WarehouseCode = stockRow.WarehouseCode;
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/27 ADD
                                flgStock = true;
                            }
                        }
                    }
                    if (flgStock == false && _orgDataSet.ListPriorWarehouse != null)
                    {
                        for (int j = 0; j < _orgDataSet.ListPriorWarehouse.Count; j++)
                        {
                            // 2009.02.16 >>>
                            //string warehouseCd = _orgDataSet.ListPriorWarehouse[j];
                            string warehouseCd = _orgDataSet.ListPriorWarehouse[j].Trim();
                            // 2009.02.16 <<<
                            for (int k = 0; k < stockRows.Length; k++)
                            {
                                // --- UPD m.suzuki 2011/01/31 ---------->>>>>
                                //if (stockRows[k].WarehouseCode.Equals(warehouseCd))
                                if ( stockRows[k].WarehouseCode.Equals( warehouseCd ) &&
                                     wkRow.PartsNo == stockRows[k].GoodsNo &&
                                     wkRow.MakerCode == stockRows[k].GoodsMakerCd )
                                // --- UPD m.suzuki 2011/01/31 ----------<<<<<
                                {
                                    wkRow.Shelf = stockRows[k].WarehouseShelfNo;
                                    wkRow.StockCnt = stockRows[k].ShipmentPosCnt;
                                    wkRow.Warehouse = stockRows[k].WarehouseName;
                                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/27 ADD
                                    wkRow.WarehouseCode = stockRows[k].WarehouseCode;
                                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/27 ADD
                                    flgStock = true;
                                    break;
                                }
                            }
                            if (flgStock)
                                break;
                        }
                    }
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki m.suzuki 2009/03/27 DEL // 優先倉庫にない場合は取寄にする
                    //if (flgStock == false && stockRows.Length > 0)
                    //{
                    //    wkRow.Shelf = stockRows[0].WarehouseShelfNo;
                    //    wkRow.StockCnt = stockRows[0].ShipmentPosCnt;
                    //    wkRow.Warehouse = stockRows[0].WarehouseName;
                    //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/27 ADD
                    //    wkRow.WarehouseCode = stockRows[0].WarehouseCode;
                    //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/27 ADD
                    //}
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki m.suzuki 2009/03/27 DEL
                }
                // --- UPD m.suzuki 2011/01/31 ---------->>>>>
                //// 2009.03.06 Add >>>
                //this._PartsTable.DefaultView.Sort = string.Format("{0},{1}", this._PartsTable.MakerCodeColumn.ColumnName, this._PartsTable.PartsNoToShowColumn.ColumnName);
                //// 2009.03.06 Add <<<
                this._PartsTable.DefaultView.Sort = string.Format("{0},{1}", this._PartsTable.MakerCodeColumn.ColumnName, this._PartsTable.PartsNoColumn.ColumnName);
                // --- UPD m.suzuki 2011/01/31 ----------<<<<<

                // --- ADD 2010/06/08 ---------->>>>>
                if (usrRows.Length > 200)
                {
                    StatusBar.Text = "検索明細が２００件を超えています";
                }
                else
                {
                    StatusBar.Text = "";
                }
                // --- ADD 2010/06/08 ----------<<<<<
            }
            finally
            {
                _PartsTable.EndLoadData();
            }
            #endregion
        }

        // --- ADD m.suzuki 2011/01/31 ---------->>>>>
        /// <summary>
        /// カタログ品番在庫チェック処理
        /// </summary>
        /// <param name="parts"></param>
        /// <param name="maker"></param>
        /// <returns></returns>
        internal bool CatalogPartsStockCheck( string parts, int maker )
        {
            bool ret = false;
            // --- ADD m.suzuki 2011/02/09 ---------->>>>>
            if ( _orgDataSet.ListPriorWarehouse == null ||
                 _orgDataSet.ListPriorWarehouse.Count == 0 )
            {
                return false;
            }
            // --- ADD m.suzuki 2011/02/09 ----------<<<<<
            // --- ADD m.suzuki 2011/02/18 ---------->>>>>
            bool settingFlag = false;
            foreach ( string warehouseCd in _orgDataSet.ListPriorWarehouse )
            {
                if ( !string.IsNullOrEmpty( warehouseCd ) )
                {
                    settingFlag = true;
                    break;
                }
            }
            if ( settingFlag == false )
            {
                return false;
            }
            // --- ADD m.suzuki 2011/02/18 ----------<<<<<
            string rowFilter = String.Format( "{0}='{1}' AND {2}={3}",
                        _orgDataSet.Stock.GoodsNoColumn.ColumnName, parts,
                        _orgDataSet.Stock.GoodsMakerCdColumn.ColumnName, maker );
            // --- ADD m.suzuki 2011/02/09 ---------->>>>>
            rowFilter += " AND (";
            foreach ( string priorWarehouse in _orgDataSet.ListPriorWarehouse )
            {
                if ( string.IsNullOrEmpty( priorWarehouse ) ) continue;
                rowFilter += string.Format( " {0}='{1}' OR", _orgDataSet.Stock.WarehouseCodeColumn.ColumnName, priorWarehouse );
            }
            rowFilter = rowFilter.Remove( rowFilter.Length - 2, 2 );
            rowFilter += ")";
            // --- ADD m.suzuki 2011/02/09 ----------<<<<<
            PartsInfoDataSet.StockRow[] rowStock = (PartsInfoDataSet.StockRow[])_orgDataSet.Stock.Select( rowFilter );

            // 在庫マスタの数量をチェックする
            // （※レコードあり・現在庫数ゼロは在庫無しと判断する。）
            for ( int i = 0; i < rowStock.Length; i++ )
            {
                if ( rowStock[i].ShipmentPosCnt > 0 )
                {
                    ret = true;
                    break;
                }
            }
            return ret;
        }
        // --- ADD m.suzuki 2011/01/31 ----------<<<<<

        // 2009.02.10 Add >>>
        /// <summary>
        /// 対象データの定価設定
        /// </summary>
        private void SettingPriceTargetData()
        {
            if (_orgDataSet.CalculatePrice == null) return;

            List<PartsInfoDataSet.GoodsPrimaryKey> goodsPrimaryKeyList = new List<PartsInfoDataSet.GoodsPrimaryKey>();

            #region [ フィルタリング条件算出 ]
            string filter = string.Empty;
            string cond = string.Empty;
            string colName = string.Empty;
            string queryOp = string.Empty;
            string goodsNo = string.Empty;

            if (_orgDataSet.SearchCondition != null)
            {
                switch (_orgDataSet.SearchCondition.SearchType)
                {
                    case SearchType.WholeWord:
                        queryOp = " = ";
                        goodsNo = _orgDataSet.SearchCondition.PartsNo;
                        break;
                    case SearchType.WholeWordWithNoHyphen:
                        queryOp = " = ";
                        goodsNo = _orgDataSet.SearchCondition.PartsNo;
                        colName = _orgDataSet.UsrGoodsInfo.GoodsNoNoneHyphenColumn.ColumnName;
                        break;
                    case SearchType.FreeSearch:
                        queryOp = " LIKE ";
                        goodsNo = "%" + _orgDataSet.SearchCondition.PartsNo + "%";
                        break;
                    case SearchType.PrefixSearch:
                        queryOp = " LIKE ";
                        goodsNo = _orgDataSet.SearchCondition.PartsNo + "%";
                        break;
                    case SearchType.SuffixSearch:
                        queryOp = " LIKE ";
                        goodsNo = "%" + _orgDataSet.SearchCondition.PartsNo;
                        break;
                    default:
                        queryOp = " = ";
                        goodsNo = _orgDataSet.SearchCondition.PartsNo;
                        break;
                }
                if (colName == string.Empty)
                {
                    if (goodsNo.Contains("-"))
                    {
                        colName = _orgDataSet.UsrGoodsInfo.GoodsNoColumn.ColumnName;
                    }
                    else
                    {
                        colName = _orgDataSet.UsrGoodsInfo.GoodsNoNoneHyphenColumn.ColumnName;
                    }
                }
                if (_orgDataSet.SearchCondition.PartsMakerCode != 0)
                {
                    cond = string.Format("{0} {1} '{2}' AND {3} = {4}", colName, queryOp, goodsNo,
                            _orgDataSet.UsrGoodsInfo.GoodsMakerCdColumn.ColumnName, _orgDataSet.SearchCondition.PartsMakerCode);
                }
                else
                {
                    cond = string.Format("{0} {1} '{2}'", colName, queryOp, goodsNo);
                }
                string cond2 = string.Empty;
                if (_makerList != null)
                {
                    for (int i = 0; i < _makerList.Count; i++)
                    {
                        cond2 += string.Format(" {0} = {1} OR ", _orgDataSet.UsrGoodsInfo.GoodsMakerCdColumn.ColumnName, _makerList[i]);
                    }
                    cond2 = cond2.Remove(cond2.Length - 3);
                }

                if (_orgDataSet.UsrGoodsInfo.DefaultView.RowFilter.Length == 0)
                {
                    filter = cond;
                }
                else
                {
                    filter = string.Format("( {0} ) AND {1} ",
                        _orgDataSet.UsrGoodsInfo.DefaultView.RowFilter, cond);
                }
                if (cond2 != string.Empty)
                {
                    filter = string.Format("( {0} ) AND ( {1} )", filter, cond2);
                }
                if (_mode == 3) // 在庫組立用
                {
                    filter = string.Format("( {0} ) AND ( {1} <= 2 )", filter, _orgDataSet.UsrGoodsInfo.OfferKubunColumn.ColumnName); // ユーザー登録商品か
                }
            }
            #endregion

            PartsInfoDataSet.UsrGoodsInfoRow[] usrRows =
                (PartsInfoDataSet.UsrGoodsInfoRow[])_orgDataSet.UsrGoodsInfo.Select(filter, _orgDataSet.UsrGoodsInfo.OfferKubunColumn.ColumnName);
            for (int i = 0; i < usrRows.Length; i++)
            {
                PartsInfoDataSet.UsrGoodsInfoRow row;

                // --- UPD m.suzuki 2011/01/31 ---------->>>>>
                //if (userSubstFlg > 0 &&
                //    ( _mode == 1 ||
                //    ( _mode == 2 && _orgDataSet.SearchCondition.SearchFlg == SearchFlag.GoodsAndSetInfo ) ))
                //    row = _orgDataSet.GetUsrSubst(usrRows[i]);
                //else
                //    row = usrRows[i];

                // 代替する/しないの判定によらず、常に代替元の情報を表示する。
                row = usrRows[i];
                // --- UPD m.suzuki 2011/01/31 ----------<<<<<

                PartsInfoDataSet.StockRow[] stockRows = (PartsInfoDataSet.StockRow[])row.GetChildRows("UsrGoodsInfo_Stock");
                if (_mode == 3)　// 在庫組立の場合
                {
                    if (_orgDataSet.UsrSetParts.SetExist(row.GoodsMakerCd, row.GoodsNo) == false) // セット情報がない場合登録しない。
                        continue;
                    if (stockRows.Length == 0) // 在庫がない場合登録しない。
                        continue;
                }

                goodsPrimaryKeyList.Add(new PartsInfoDataSet.GoodsPrimaryKey(row.GoodsNo, row.GoodsMakerCd));
            }
            // 商品情報が存在する場合は定価計算
            if (goodsPrimaryKeyList.Count > 0)
            {
                _orgDataSet.SettingDefaultListPrice(goodsPrimaryKeyList);
            }
        }
        // 2009.02.10 Add <<<

        private void SetImage(SameParts.SamePartsRow wkRow)
        {
            if (!(_mode == 1 || (_mode == 2 && _orgDataSet.SearchCondition.SearchFlg == SearchFlag.GoodsAndSetInfo)))
                return;
            //if (SubstExists(wkRow.PartsNoToShow, wkRow.MakerCode))
            //{
            //    wkRow.Subst = IconResourceManagement.ImageList16.Images[(int)Size16_Index.CARADD];
            //}
            //else
            //{
            //    wkRow[_PartsTable.SubstColumn] = DBNull.Value;
            //}
            // --- UPD m.suzuki 2011/01/31 ---------->>>>>
            //if (SetExists(wkRow.PartsNoToShow, wkRow.MakerCode))
            if ( SetExists( wkRow.PartsNo, wkRow.MakerCode ) )
            // --- UPD m.suzuki 2011/01/31 ----------<<<<<
            {
                wkRow.Set = IconResourceManagement.ImageList16.Images[(int)Size16_Index.MODEL];
            }
            else
            {
                wkRow[_PartsTable.SetColumn] = DBNull.Value;
            }
            // --- UPD m.suzuki 2011/01/31 ---------->>>>>
            //if (JoinExists(wkRow.PartsNoToShow, wkRow.MakerCode))
            if ( JoinExists( wkRow.PartsNo, wkRow.MakerCode ) )
            // --- UPD m.suzuki 2011/01/31 ----------<<<<<
            {
                wkRow.Join = IconResourceManagement.ImageList16.Images[(int)Size16_Index.CARCHANGE];
            }
            else
            {
                wkRow[_PartsTable.JoinColumn] = DBNull.Value;
            }
        }

        #region [ 代替・セット・結合存在性チェック ]
        internal bool SubstExists(string parts, int maker)
        {
            string rowFilter = String.Format("{0}='{1}' AND {2}={3} AND {4} = true", // 代替選択UIには提供のみ表示
                _orgDataSet.UsrSubstParts.ChgSrcGoodsNoColumn.ColumnName, parts,
                _orgDataSet.UsrSubstParts.ChgSrcMakerCdColumn.ColumnName, maker, _orgDataSet.UsrSubstParts.OfferKubunColumn.ColumnName);
            if (_orgDataSet.UsrSubstParts.Select(rowFilter).Length > 0)
                return true;
            return false;
        }

        internal bool SetExists(string parts, int maker)
        {
            string rowFilter = String.Format("{0}='{1}' AND {2}={3} AND {4}=true",
                _orgDataSet.UsrSetParts.ParentGoodsNoColumn.ColumnName, parts,
                _orgDataSet.UsrSetParts.ParentGoodsMakerCdColumn.ColumnName, maker,
                _orgDataSet.UsrSetParts.PrmSettingFlgColumn.ColumnName);

            if (_orgDataSet.UsrSetParts.Select(rowFilter).Length > 0)
                return true;
            return false;
        }

        internal bool JoinExists(string parts, int maker)
        {
            string rowFilter = String.Format("{0}='{1}' AND {2}={3} AND {4}=true",
                _orgDataSet.UsrJoinParts.JoinSrcPartsNoWithHColumn.ColumnName, parts,
                _orgDataSet.UsrJoinParts.JoinSourceMakerCodeColumn.ColumnName, maker,
                _orgDataSet.UsrJoinParts.PrmSettingFlgColumn.ColumnName);
            if (_orgDataSet.UsrJoinParts.Select(rowFilter).Length > 0)
                return true;
            return false;
        }
        #endregion

        #region [ フォームイベント処理 ]
        /// <summary>
        /// FormClosed イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>DialogResultがOKの場合にのみ、グリッド上で選択されている行に関連するDataRowオブジェクトを取得し、</br>
        /// <br>"選択状態"に相当する処理を行います。</br>
        /// </remarks>
        private void SelectionSamePartsNoParts_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (DialogResult == DialogResult.Cancel || _PartsTable.Count == 0)
            {
                return;
            }
            //int cnt = _PartsTable.Count;
            //string filter = string.Format("{0} = True", _PartsTable.SelectionStateColumn.ColumnName);
            //_PartsTable.AcceptChanges();
            //SameParts.SamePartsRow[] samePartsRows = (SameParts.SamePartsRow[])_PartsTable.Select(filter);

            //if (samePartsRows.Length > 0 && _orgDataSet.UsrGoodsInfo.Count > 0)
            //{
            //    PartsInfoDataSet.UsrGoodsInfoRow rowUsr = _orgDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(samePartsRows[0].MakerCode, samePartsRows[0].PartsNoToShow);
            //    if (rowUsr != null)
            //    {
            //        rowUsr.SelectionState = true;
            //        rowUsr.GoodsKindResolved = (int)GoodsKind.Parent;
            //    }
            //}
            int cnt = gridParts.Rows.Count;
            for (int i = 0; i < cnt; i++)
            {
                PartsInfoDataSet.UsrGoodsInfoRow row = null;
                UltraGridRow gridRow = gridParts.Rows[i];
                if (gridRow.Cells[_PartsTable.SelectionStateColumn.ColumnName].Value.Equals(true))
                {
                    gridRow.Cells[_PartsTable.SelectionStateColumn.ColumnName].Value = false; // 次回のためクリアしておく。
                    // --- UPD m.suzuki 2011/01/31 ---------->>>>>
                    //row = _orgDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo((int)gridRow.Cells[_PartsTable.MakerCodeColumn.ColumnName].Value,
                    //        gridRow.Cells[_PartsTable.PartsNoToShowColumn.ColumnName].Value.ToString());
                    row = _orgDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo( (int)gridRow.Cells[_PartsTable.MakerCodeToShowColumn.ColumnName].Value,
                            gridRow.Cells[_PartsTable.PartsNoToShowColumn.ColumnName].Value.ToString() );
                    // --- UPD m.suzuki 2011/01/31 ----------<<<<<
                    if (row != null)
                    {
                        _orgDataSet.ListSelectionInfo.Clear();
                        SelectionInfo selInfo = new SelectionInfo();
                        selInfo.Depth = 0;
                        selInfo.Key = gridRow.ListIndex;
                        selInfo.RowGoods = row;
                        selInfo.WarehouseCode = gridRow.Cells[_PartsTable.WarehouseCodeColumn.ColumnName].Value.ToString();
                        //if (uiControlFlg && gridRow.Cells[_PartsTable.SelImageColumn.ColumnName].Value.Equals(DBNull.Value) == false)
                        //    selInfo.Selected = true;
                        //else
                        selInfo.Selected = false;
                        _orgDataSet.AddSelectionInfo(_orgDataSet.ListSelectionInfo, selInfo.Key, ref selInfo);
                        if (gridParts.ActiveRow != null && i == gridParts.ActiveRow.Index)
                        {
                            switch (_orgDataSet.UIKind)
                            {
                                case SelectUIKind.Join:
                                    _orgDataSet.JoinSrcSelInf = selInfo;
                                    break;
                                case SelectUIKind.Set:
                                    _orgDataSet.SetSrcSelInf = selInfo;
                                    break;
                                case SelectUIKind.Subst:
                                    _orgDataSet.SubstSrcSelInf = selInfo;
                                    break;
                            }
                            //if (_orgDataSet.UIKind == SelectUIKind.Join)
                            //    _orgDataSet.JoinSrcSelInf = selInfo;
                            //else if (_orgDataSet.UIKind == SelectUIKind.Set)
                            //    _orgDataSet.SetSrcSelInf = selInfo;
                            //else 
                            //if (uiControlFlg // PM7式制御の場合は次の画面が表示されるため選択しない。
                            //   || _orgDataSet.SearchCondition == null // 直で同一品番選択UIを開くとき
                            if (_mode == 3 // 在庫組立の場合
                               || _orgDataSet.SearchCondition == null // 直で同一品番選択UIを開くとき
                               || _orgDataSet.SearchCondition.SearchFlg == SearchFlag.GoodsInfoOnly) // 品番検索のみの場合
                                selInfo.Selected = true;
                            _prevSelInfo = selInfo;
                        }
                    }
                }
                else
                {
                    _orgDataSet.RemoveSelectionInfo(_orgDataSet.ListSelectionInfo, gridRow.ListIndex);
                }
            }

        }

        private void SelectionSamePartsNoParts_Shown(object sender, EventArgs e)
        {
            if (gridParts.Rows.Count == 0)
                return;
            // 先頭行を選択状態にする
            gridParts.Focus();
            gridParts.Rows[0].Activate();
            gridParts.Rows[0].Selected = true;
        }

        private void SelectionSamePartsNoParts_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (uiControlFlg && e.CloseReason == CloseReason.UserClosing && isUserClose)
            //{
            //    if (TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, this.Text, "選択UIを終了しますか？", 0, MessageBoxButtons.YesNo)
            //        == DialogResult.Yes)
            //    {
            //        this.DialogResult = DialogResult.Cancel;
            //    }
            //    else
            //    {
            //        e.Cancel = true;
            //    }
            //}
        }

        /// <summary>
        /// ESCキー押下による終了処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectionSamePartsNoParts_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                DialogResult = DialogResult.Cancel;
                isUserClose = false;
            }
        }

        /// <summary>
        /// ツールボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolbarsManager_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            UltraGridRow activeRow = gridParts.ActiveRow;
            switch (e.Tool.Key)
            {
                case "Button_Select":
                    // 選択されている行を確定する
                    DialogResult = DialogResult.OK;
                    isUserClose = false;
                    //if (uiControlFlg == false)
                    SetSelect();
                    break;

                case "Button_Back":
                    // 前の画面に戻る
                    DialogResult = DialogResult.Cancel;
                    isUserClose = false;
                    break;

                case "Button_Subst":
                    // 代替がある場合代替UI表示
                    if (activeRow != null)
                    {
                        if (activeRow.Cells[_PartsTable.SubstColumn.ColumnName].Value != DBNull.Value)
                        {
                            //DialogResult = DialogResult.OK;
                            isUserClose = false;
                            // --- UPD m.suzuki 2011/01/31 ---------->>>>>
                            //int makerCd = (int)activeRow.Cells[_PartsTable.MakerCodeColumn.ColumnName].Value;
                            int makerCd = (int)activeRow.Cells[_PartsTable.MakerCodeToShowColumn.ColumnName].Value;
                            // --- UPD m.suzuki 2011/01/31 ----------<<<<<
                            string partsNo = activeRow.Cells[_PartsTable.PartsNoToShowColumn.ColumnName].Value.ToString();
                            PartsInfoDataSet.UsrGoodsInfoRow row =
                                _orgDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(makerCd, partsNo);
                            if (row != null)
                            {
                                _orgDataSet.UsrGoodsInfo.RowToProcess = row;
                                //_orgDataSet.UsrGoodsInfo.PreviousActiveRow = row;
                                _orgDataSet.UIKind = SelectUIKind.Subst;
                                DialogResult = DialogResult.Retry;
                            }
                        }
                    }
                    break;

                case "Button_Set":
                    // セットがある場合セット選択UI表示
                    if (uiControlFlg && activeRow != null)
                    {
                        if (activeRow.Cells[_PartsTable.SetColumn.ColumnName].Value != DBNull.Value)
                        {
                            //DialogResult = DialogResult.OK;
                            isUserClose = false;
                            // --- UPD m.suzuki 2011/01/31 ---------->>>>>
                            //int makerCd = (int)activeRow.Cells[_PartsTable.MakerCodeColumn.ColumnName].Value;
                            int makerCd = (int)activeRow.Cells[_PartsTable.MakerCodeToShowColumn.ColumnName].Value;
                            // --- UPD m.suzuki 2011/01/31 ----------<<<<<
                            string partsNo = activeRow.Cells[_PartsTable.PartsNoToShowColumn.ColumnName].Value.ToString();
                            PartsInfoDataSet.UsrGoodsInfoRow row =
                                _orgDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(makerCd, partsNo);
                            if (row != null)
                            {
                                activeRow.Cells[_PartsTable.SelectionStateColumn.ColumnName].Value = true;
                                _orgDataSet.UsrGoodsInfo.RowToProcess = row;
                                //_orgDataSet.UsrGoodsInfo.PreviousActiveRow = row;
                                _orgDataSet.UIKind = SelectUIKind.Set;
                                DialogResult = DialogResult.Retry;
                            }
                        }
                    }
                    break;

                case "Button_Join":
                    if (uiControlFlg && activeRow != null)
                    {
                        if (activeRow.Cells[_PartsTable.JoinColumn.ColumnName].Value != DBNull.Value)
                        {
                            DialogResult = DialogResult.OK;
                            isUserClose = false;
                            // --- UPD m.suzuki 2011/01/31 ---------->>>>>
                            //int makerCd = (int)activeRow.Cells[_PartsTable.MakerCodeColumn.ColumnName].Value;
                            int makerCd = (int)activeRow.Cells[_PartsTable.MakerCodeToShowColumn.ColumnName].Value;
                            // --- UPD m.suzuki 2011/01/31 ----------<<<<<
                            string partsNo = activeRow.Cells[_PartsTable.PartsNoToShowColumn.ColumnName].Value.ToString();
                            PartsInfoDataSet.UsrGoodsInfoRow row =
                                _orgDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(makerCd, partsNo);
                            if (row != null)
                            {
                                activeRow.Cells[_PartsTable.SelectionStateColumn.ColumnName].Value = true;
                                _orgDataSet.UsrGoodsInfo.RowToProcess = row;
                                //_orgDataSet.UsrGoodsInfo.PreviousActiveRow = row;
                                _orgDataSet.UIKind = SelectUIKind.Join;
                                DialogResult = DialogResult.Retry;
                            }
                        }
                    }
                    break;

                case "Button_SubstOff":
                    if (activeRow != null &&
                        activeRow.Cells[_PartsTable.OldPartsNoColumn.ColumnName].Value.Equals(string.Empty) == false)
                    {
                        // --- UPD m.suzuki 2011/01/31 ---------->>>>>
                        //int makerCd = (int)activeRow.Cells[_PartsTable.MakerCodeColumn.ColumnName].Value;
                        int makerCd = (int)activeRow.Cells[_PartsTable.MakerCodeToShowColumn.ColumnName].Value;
                        // --- UPD m.suzuki 2011/01/31 ----------<<<<<
                        string partsNo = activeRow.Cells[_PartsTable.PartsNoToShowColumn.ColumnName].Value.ToString();
                        string oldPartsNo = activeRow.Cells[_PartsTable.OldPartsNoColumn.ColumnName].Value.ToString();
                        SameParts.SamePartsRow oldRow = _PartsTable.FindByMakerCodePartsNo(makerCd, partsNo);
                        PartsInfoDataSet.UsrGoodsInfoRow newRow =
                            _orgDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(makerCd, oldPartsNo);

                        oldRow.OldPartsNo = string.Empty;
                        oldRow.PartsNo = newRow.GoodsNo;
                        oldRow.PartsName = newRow.GoodsName;
                        if (totalAmountDispWay == 1) // 総額表示する（税込み）
                        {
                            oldRow.Price = newRow.PriceTaxInc;
                        }
                        else // 総額表示しない（税抜き）
                        {
                            oldRow.Price = newRow.PriceTaxExc;
                        }
                        SetImage(oldRow);

                        _orgDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(makerCd, partsNo).SelectionState = false;
                        PartsInfoDataSet.SubstPartsInfoRow substRow = _orgDataSet.SubstPartsInfo.
                            FindByNewPartsNoWithHyphenCatalogPartsMakerCdOldPartsNoWithHyphen(partsNo, makerCd, oldPartsNo);
                        if (substRow != null)
                        {
                            PartsInfoDataSet.DSubstPartsInfoRow[] dSubstRows = substRow.GetDSubstPartsInfoRows();
                            for (int i = 0; i < dSubstRows.Length; i++)
                            {
                                _orgDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(dSubstRows[i].CatalogPartsMakerCd, dSubstRows[i].NewPartsNoWithHyphen).SelectionState = false;
                            }
                        }

                        SetButtonState();
                        ToolbarsManager.Tools["Button_SubstOff"].SharedProps.Visible = false;
                    }
                    break;
            }
        }
        #endregion

        #region [ メイングリッドイベント処理 ]
        /// <summary>
        /// InitializeLayout イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>グリッドのレイアウト初期化処理</br>
        /// </remarks>
        private void gridParts_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            // 列幅の自動調整方法
            e.Layout.AutoFitStyle = AutoFitStyle.ResizeAllColumns;
            e.Layout.Override.RowSizing = RowSizing.Fixed;
            e.Layout.Override.AllowColSizing = AllowColSizing.None;
            e.Layout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;

            List<string> colShow = new List<string>(new string[]{
                _PartsTable.MakerCodeColumn.ColumnName,  // 0
                _PartsTable.MakerNameColumn.ColumnName,  // 1
                // --- UPD m.suzuki 2011/01/31 ---------->>>>>
                //_PartsTable.PartsNoToShowColumn.ColumnName,    // 2
                _PartsTable.PartsNoColumn.ColumnName,    // 2
                // --- UPD m.suzuki 2011/01/31 ----------<<<<<
                _PartsTable.PartsNameColumn.ColumnName,  // 3
                _PartsTable.PriceColumn.ColumnName,      // 4
                _PartsTable.SetColumn.ColumnName,        // 5
                //_PartsTable.SubstColumn.ColumnName,      // 6
                _PartsTable.JoinColumn.ColumnName,       // 7
                _PartsTable.WarehouseColumn.ColumnName,  // 8
                _PartsTable.ShelfColumn.ColumnName,      // 9
                _PartsTable.StockCntColumn.ColumnName    // 10
                });
            // バンドの取得
            UltraGridBand Band = e.Layout.Bands[0];
            Band.UseRowLayout = true;

            for (int Index = 0; Index < Band.Columns.Count; Index++)
            {
                if (colShow.Contains(Band.Columns[Index].Key))
                {
                    // 列の表示・非表示
                    //Band.Columns[Index].PerformAutoResize(PerformAutoSizeType.AllRowsInBand, true);  // 列幅のリサイズ
                    Band.Columns[Index].Hidden = false;
                }
                else
                {
                    Band.Columns[Index].Hidden = true;
                }

                // 水平表示位置
                if (Band.Columns[Index].DataType == typeof(int) || Band.Columns[Index].DataType == typeof(double))
                {
                    Band.Columns[Index].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                }
                else if (Band.Columns[Index].DataType == typeof(Image))
                {
                    Band.Columns[Index].CellAppearance.ImageHAlign = Infragistics.Win.HAlign.Center;
                    Band.Columns[Index].CellAppearance.ImageVAlign = Infragistics.Win.VAlign.Middle;
                }
                else
                {
                    Band.Columns[Index].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                }
                Band.Columns[Index].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;

                // 垂直表示位置
                Band.Columns[Index].CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
            }

            // --- UPD 2014/03/04 Y.Wakita ---------->>>>>
            //ColInfo.SetColInfo(Band, _PartsTable.MakerCodeColumn.ColumnName, 2, 0, 40);
            ColInfo.SetColInfo(Band, _PartsTable.MakerCodeColumn.ColumnName, 2, 0, 36);
            // --- UPD 2014/03/04 Y.Wakita ----------<<<<<
            ColInfo.SetColInfo(Band, _PartsTable.MakerNameColumn.ColumnName, 6, 0, 100);
            // --- UPD m.suzuki 2011/01/31 ---------->>>>>
            //ColInfo.SetColInfo(Band, _PartsTable.PartsNoToShowColumn.ColumnName, 16, 0, 80);
            // --- UPD 2014/03/03 Y.Wakita ---------->>>>>
            //ColInfo.SetColInfo(Band, _PartsTable.PartsNoColumn.ColumnName, 16, 0, 80);
            ColInfo.SetColInfo(Band, _PartsTable.PartsNoColumn.ColumnName, 16, 0, 84);
            // --- UPD 2014/03/03 Y.Wakita ----------<<<<<
            // --- UPD m.suzuki 2011/01/31 ----------<<<<<
            ColInfo.SetColInfo(Band, _PartsTable.PartsNameColumn.ColumnName, 24, 0, 160);
            ColInfo.SetColInfo(Band, _PartsTable.PriceColumn.ColumnName, 40, 0, 60);
            ColInfo.SetColInfo(Band, _PartsTable.WarehouseColumn.ColumnName, 46, 0, 60);
            ColInfo.SetColInfo(Band, _PartsTable.ShelfColumn.ColumnName, 52, 0, 30);
            ColInfo.SetColInfo(Band, _PartsTable.StockCntColumn.ColumnName, 55, 0, 40);

            if (_mode == 2 && _orgDataSet.SearchCondition.SearchFlg == SearchFlag.GoodsAndSetInfo)
            {
                ColInfo.SetColInfo(Band, _PartsTable.SetColumn.ColumnName, 59, 0, 20);
                Band.Columns[_PartsTable.JoinColumn.ColumnName].Hidden = true;
            }
            else if (_mode != 1)
            {
                //Band.Columns[_PartsTable.SubstColumn.ColumnName].Hidden = true;
                Band.Columns[_PartsTable.SetColumn.ColumnName].Hidden = true;
                Band.Columns[_PartsTable.JoinColumn.ColumnName].Hidden = true;
            }
            else // 品番結合検索
            {
                //ColInfo.SetColInfo(Band, _PartsTable.SubstColumn.ColumnName, 59, 0, 20);
                //ColInfo.SetColInfo(Band, _PartsTable.SetColumn.ColumnName, 61, 0, 20);
                //ColInfo.SetColInfo(Band, _PartsTable.JoinColumn.ColumnName, 63, 0, 20);
                ColInfo.SetColInfo(Band, _PartsTable.SetColumn.ColumnName, 59, 0, 20);
                ColInfo.SetColInfo(Band, _PartsTable.JoinColumn.ColumnName, 61, 0, 20);
            }

            // 表示フォーマット
            Band.Columns[_PartsTable.MakerCodeColumn.ColumnName].Format = "D4";
            Band.Columns[_PartsTable.PriceColumn.ColumnName].Format = "C";
            Band.Columns[_PartsTable.StockCntColumn.ColumnName].Format = "###,###,##0.00";
        }

        /// <summary>
        /// アクティブ行変更後イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridParts_AfterSelectChange(object sender, AfterSelectChangeEventArgs e)
        {
            #region [ 在庫グリッドフィルタリング処理 ]
            string filter = string.Empty;
            try
            {
                if (gridParts.ActiveRow == null)
                    return;

                filter = string.Format("{0}={1} AND {2}='{3}' ",
                    _StockTable.GoodsMakerCdColumn.ColumnName,
                    gridParts.ActiveRow.Cells[_PartsTable.MakerCodeColumn.ColumnName].Value,
                    _StockTable.GoodsNoColumn.ColumnName,
                    // --- UPD m.suzuki 2011/01/31 ---------->>>>>
                    //gridParts.ActiveRow.Cells[_PartsTable.PartsNoToShowColumn.ColumnName].Value);
                    gridParts.ActiveRow.Cells[_PartsTable.PartsNoColumn.ColumnName].Value);
                    // --- UPD m.suzuki 2011/01/31 ----------<<<<<

                SetButtonState();
            }
            finally
            {
                _StockTable.DefaultView.RowFilter = filter;
            }
            #endregion

            SetStockGridSelect();
            if (gridParts.Selected.Rows.Count > 0 &&
                gridParts.Selected.Rows[0].Cells[_PartsTable.OldPartsNoColumn.ColumnName].Value.Equals(string.Empty) == false)
            {
                ToolbarsManager.Tools["Button_SubstOff"].SharedProps.Visible = true;
            }
            else
            {
                ToolbarsManager.Tools["Button_SubstOff"].SharedProps.Visible = false;
            }
        }

        /// <summary>
        /// 行をダブルクリックされた場合は、その行を選択する。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// データが表示されていない行をダブルクリックしても本イベントは発生しない。
        /// </remarks>
        private void gridParts_DoubleClickRow(object sender, DoubleClickRowEventArgs e)
        {
            SetSelect();
        }

        /// <summary>
        /// グリッド上でEnterキーが押された場合は、その行を選択する。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridParts_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SetSelect();
            }
        }
        #endregion

        #region [ その他メソッド ]
        private void SetButtonState()
        {
            bool enaSet = false;
            bool enaSubst = false;
            bool enaJoin = false;
            try
            {
                if (this.gridParts.ActiveRow == null) return;//
                if (this.gridParts.ActiveRow.Band != gridParts.DisplayLayout.Bands[0]) return;
                //DataRow wkRow = (DataRow)this.grid.ActiveRow.Cells[COL_WR].Value;
                enaSet = (gridParts.ActiveRow.Cells[_PartsTable.SetColumn.ColumnName].Value != System.DBNull.Value);
                enaSubst = (gridParts.ActiveRow.Cells[_PartsTable.SubstColumn.ColumnName].Value != System.DBNull.Value);
                enaJoin = (gridParts.ActiveRow.Cells[_PartsTable.JoinColumn.ColumnName].Value != System.DBNull.Value);
                //enaSubst = enaSet = enaJoin = true;
            }
            finally
            {
                ToolbarsManager.Tools["Button_Set"].SharedProps.Enabled = enaSet;
                ToolbarsManager.Tools["Button_Subst"].SharedProps.Enabled = enaSubst;
                ToolbarsManager.Tools["Button_Join"].SharedProps.Enabled = enaJoin;
            }
        }

        private void SetSelect()
        {
            if (gridParts.ActiveRow != null)
            {
                CellsCollection activeCells = gridParts.ActiveRow.Cells;
                //if (uiControlFlg == false || enterFlg != 2)
                //{
                activeCells["SelectionState"].Value = true;
                //}
                //if (uiControlFlg && (enterFlg == 0 || enterFlg == 2)) // PM.NS式制御＆EnterキーがPM7又は次画面の場合
                if (uiControlFlg && enterFlg == 2) // PM.NS式制御＆Enterキーが次画面の場合
                {
                    PartsInfoDataSet.UsrGoodsInfoRow row = _orgDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo
                        // --- UPD m.suzuki 2011/01/31 ---------->>>>>
                        //((int)activeCells[_PartsTable.MakerCodeColumn.ColumnName].Value,
                        ((int)activeCells[_PartsTable.MakerCodeToShowColumn.ColumnName].Value,
                        // --- UPD m.suzuki 2011/01/31 ----------<<<<<
                         activeCells[_PartsTable.PartsNoToShowColumn.ColumnName].Value.ToString());
                    _orgDataSet.UsrGoodsInfo.RowToProcess = row;
                    //_orgDataSet.UsrGoodsInfo.PreviousActiveRow = row;
                    if (activeCells[_PartsTable.JoinColumn.ColumnName].Value != DBNull.Value)
                    {
                        _orgDataSet.UIKind = SelectUIKind.Join;
                        DialogResult = DialogResult.Retry;
                    }
                    else if (activeCells[_PartsTable.SetColumn.ColumnName].Value != DBNull.Value)
                    {
                        _orgDataSet.UIKind = SelectUIKind.Set;
                        DialogResult = DialogResult.Retry;
                    }
                    else
                    {
                        DialogResult = DialogResult.OK;
                    }
                }
                else
                {
                    // 2009/12/03 Add >>>
                    PartsInfoDataSet.UsrGoodsInfoRow row = _orgDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo
                        // --- UPD m.suzuki 2011/01/31 ---------->>>>>
                        //((int)activeCells[_PartsTable.MakerCodeColumn.ColumnName].Value,
                        ((int)activeCells[_PartsTable.MakerCodeToShowColumn.ColumnName].Value,
                        // --- UPD m.suzuki 2011/01/31 ----------<<<<<
                         activeCells[_PartsTable.PartsNoToShowColumn.ColumnName].Value.ToString());
                    _orgDataSet.UsrGoodsInfo.RowToProcess = row;
                    // 2009/12/03 Add <<<
                    DialogResult = DialogResult.OK;
                }
                isUserClose = false;
            }
            SetStockGridSelect();

            // --- ADD m.suzuki 2011/01/31 ---------->>>>>
            // 代替元が選択された場合の代替先在庫選択処理
            SetStockGridSelectOnClose();
            // --- ADD m.suzuki 2011/01/31 ----------<<<<<
        }

        /// <summary>
        /// 在庫グリッド選択処理（ユーザー選択→優先倉庫→先頭行の順で選択）
        /// </summary>
        private void SetStockGridSelect()
        {
            if (gridParts.ActiveRow.Cells[_PartsTable.WarehouseCodeColumn.ColumnName].Value.Equals(string.Empty) == false)
            {
                for (int i = 0; i < gridStock.Rows.Count; i++)
                {
                    if (gridStock.Rows[i].Cells[_StockTable.WarehouseCodeColumn.ColumnName].Value
                        .Equals(gridParts.ActiveRow.Cells[_PartsTable.WarehouseCodeColumn.ColumnName].Value))
                    {
                        gridStock.Rows[i].Activate();
                        gridStock.Rows[i].Selected = true;
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/27 ADD
                        SetSelectStock( false, true );
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/27 ADD
                        return;
                    }
                }
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/02 ADD
                // 該当がない場合は先頭行にフォーカスのみセット
                if ( gridStock.Rows.Count > 0 )
                {
                    gridStock.Rows[0].Activate();
                    gridStock.Rows[0].Selected = true;
                }
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/02 ADD
            }
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/27 ADD
            else
            {
                // 在庫未選択(取寄扱い)ならば在庫行の選択解除
                foreach ( UltraGridRow row in gridStock.Rows )
                {
                    if ( row.Cells[_StockTable.SelImageColumn.ColumnName].Value != DBNull.Value )
                    {
                        row.Cells[_StockTable.SelImageColumn.ColumnName].Value = DBNull.Value;
                        row.Cells[_StockTable.SelectionStateColumn.ColumnName].Value = false;
                    }
                }
                // 在庫を全て選択解除した後、フォーカスは先頭の在庫
                if ( gridStock.Rows.Count > 0 )
                {
                    gridStock.Rows[0].Activate();
                    gridStock.Rows[0].Selected = true;
                }
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/27 ADD

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/27 DEL
            //if (_orgDataSet.ListPriorWarehouse != null)
            //{
            //    for (int i = 0; i < _orgDataSet.ListPriorWarehouse.Count; i++)
            //    {
            //        string warehouseCd = _orgDataSet.ListPriorWarehouse[i];
            //        for (int j = 0; j < gridStock.Rows.Count; j++)
            //        {
            //            if (gridStock.Rows[j].Cells[_StockTable.WarehouseCodeColumn.ColumnName].Value.Equals(warehouseCd))
            //            {
            //                gridStock.Rows[j].Activate();
            //                gridStock.Rows[j].Selected = true;
            //                return;
            //            }
            //        }
            //    }
            //}
            //if (gridStock.Rows.Count > 0)
            //{
            //    gridStock.Rows[0].Activate();
            //    gridStock.Rows[0].Selected = true;
            //    gridStock.Rows[0].Cells[_StockTable.SelectionStateColumn.ColumnName].Value = true;
            //}
            //else
            //{
            //    gridParts.ActiveRow.Cells[_PartsTable.WarehouseColumn.ColumnName].Value = string.Empty;
            //    gridParts.ActiveRow.Cells[_PartsTable.ShelfColumn.ColumnName].Value = string.Empty;
            //    gridParts.ActiveRow.Cells[_PartsTable.StockCntColumn.ColumnName].Value = 0;
            //    gridParts.ActiveRow.Cells[_PartsTable.WarehouseCodeColumn.ColumnName].Value = string.Empty;
            //    gridParts.UpdateData();
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/27 DEL
        }
        // --- ADD m.suzuki 2011/01/31 ---------->>>>>
        /// <summary>
        /// 終了時に代替先在庫の優先倉庫を反映させる
        /// </summary>
        private void SetStockGridSelectOnClose()
        {
            CellsCollection activeCells = gridParts.ActiveRow.Cells;
            if (activeCells != null)
            {
                int makerCodeToShow = (int)activeCells[_PartsTable.MakerCodeToShowColumn.ColumnName].Value;
                int makerCode = (int)activeCells[_PartsTable.MakerCodeColumn.ColumnName].Value;
                string partsNoToShow = (string)activeCells[_PartsTable.PartsNoToShowColumn.ColumnName].Value;
                string partsNo = (string)activeCells[_PartsTable.PartsNoColumn.ColumnName].Value;

                // 代替元を選択した場合
                if (makerCodeToShow != makerCode ||
                    partsNoToShow != partsNo)
                {
                    // 在庫選択解除
                    for ( int k = 0; k < _StockTable.Rows.Count; k++ )
                    {
                        _StockTable.Rows[k][_StockTable.SelectionStateColumn.ColumnName] = false;
                    }
                    activeCells[_PartsTable.WarehouseCodeColumn.ColumnName].Value = string.Empty;
                    activeCells[_PartsTable.WarehouseColumn.ColumnName].Value = string.Empty;
                    activeCells[_PartsTable.ShelfColumn.ColumnName].Value = string.Empty;
                    activeCells[_PartsTable.StockCntColumn.ColumnName].Value = 0;


                    // 代替先在庫を選択（優先倉庫から選択）
                    if ( _orgDataSet.ListPriorWarehouse != null )
                    {
                        bool flgStock = false;

                        for ( int j = 0; j < _orgDataSet.ListPriorWarehouse.Count; j++ )
                        {
                            string warehouseCd = _orgDataSet.ListPriorWarehouse[j].Trim();

                            for ( int k = 0; k < _StockTable.Rows.Count; k++ )
                            {
                                // 代替先の在庫
                                if ( _StockTable.Rows[k][_StockTable.WarehouseCodeColumn.ColumnName].Equals( warehouseCd ) &&
                                     partsNoToShow == (string)_StockTable.Rows[k][_StockTable.GoodsNoColumn.ColumnName] &&
                                     makerCodeToShow == (int)_StockTable.Rows[k][_StockTable.GoodsMakerCdColumn.ColumnName] )
                                {
                                    // 在庫選択
                                    _StockTable.Rows[k][_StockTable.SelectionStateColumn.ColumnName] = true;
                                    
                                    // 部品Table更新(在庫情報更新)
                                    activeCells[_PartsTable.WarehouseCodeColumn.ColumnName].Value = _StockTable.Rows[k][_StockTable.WarehouseCodeColumn.ColumnName];
                                    activeCells[_PartsTable.WarehouseColumn.ColumnName].Value = _StockTable.Rows[k][_StockTable.WarehouseNameColumn.ColumnName];
                                    activeCells[_PartsTable.ShelfColumn.ColumnName].Value = _StockTable.Rows[k][_StockTable.WarehouseShelfNoColumn.ColumnName];
                                    activeCells[_PartsTable.StockCntColumn.ColumnName].Value = _StockTable.Rows[k][_StockTable.ShipmentPosCntColumn.ColumnName];
                                    flgStock = true;
                                    break;
                                }
                            }
                            if ( flgStock )
                            {
                                break;
                            }
                        }
                    }
                }
            }
        }
        // --- ADD m.suzuki 2011/01/31 ----------<<<<<
        #endregion

        #region [ 在庫グリッドイベント処理 ]
        private void gridStock_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            e.Layout.AutoFitStyle = AutoFitStyle.ResizeAllColumns;
            e.Layout.Override.RowSizing = RowSizing.Fixed;
            e.Layout.Override.AllowColSizing = AllowColSizing.None;
            e.Layout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;

            UltraGridBand band = e.Layout.Bands[0];
            band.UseRowLayout = true;
            band.Indentation = 0;

            band.Columns[_StockTable.SelectionStateColumn.ColumnName].Hidden = true;
            band.Columns[_StockTable.GoodsMakerCdColumn.ColumnName].Hidden = true;
            band.Columns[_StockTable.GoodsNoColumn.ColumnName].Hidden = true;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/27 ADD
            band.Columns[_StockTable.SortDivColumn.ColumnName].Hidden = true;
            if ( this.VisibleStockSelectCheckBox() )
            {
                band.Columns[_StockTable.SelImageColumn.ColumnName].Hidden = false;
            }
            else
            {
                band.Columns[_StockTable.SelImageColumn.ColumnName].Hidden = true;
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/27 ADD
            for (int Index = 0; Index < band.Columns.Count; Index++)
            {
                // 水平表示位置
                if ((band.Columns[Index].DataType == typeof(int)) ||
                   (band.Columns[Index].DataType == typeof(double)))
                {
                    band.Columns[Index].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                }
                else
                {
                    band.Columns[Index].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                }
                band.Columns[Index].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                // 垂直表示位置
                band.Columns[Index].CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
            }
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/27 ADD
            ColInfo.SetColInfo( band, _StockTable.SelImageColumn.ColumnName, 0, 0, 10 );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/27 ADD
            ColInfo.SetColInfo(band, _StockTable.WarehouseCodeColumn.ColumnName, 2, 0, 50);
            ColInfo.SetColInfo(band, _StockTable.WarehouseNameColumn.ColumnName, 5, 0, 100);
            ColInfo.SetColInfo(band, _StockTable.WarehouseShelfNoColumn.ColumnName, 7, 0, 50);
            ColInfo.SetColInfo(band, _StockTable.ShipmentPosCntColumn.ColumnName, 9, 0, 50);
            ColInfo.SetColInfo(band, _StockTable.MinimumStockCntColumn.ColumnName, 11, 0, 50);
            ColInfo.SetColInfo(band, _StockTable.MaximumStockCntColumn.ColumnName, 13, 0, 50);
            band.Columns[_StockTable.ShipmentPosCntColumn.ColumnName].Format = "###,###,##0.00";
            band.Columns[_StockTable.MinimumStockCntColumn.ColumnName].Format = "###,###,##0.00";
            band.Columns[_StockTable.MaximumStockCntColumn.ColumnName].Format = "###,###,##0.00";
        }

        private void gridStock_AfterSelectChange(object sender, AfterSelectChangeEventArgs e)
        {
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/27 ADD
            if ( !this.VisibleStockSelectCheckBox() )
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/27 ADD
            {
                if ( gridStock.ActiveRow != null && gridParts.ActiveRow != null )
                {
                    gridParts.ActiveRow.Cells[_PartsTable.WarehouseColumn.ColumnName].Value
                        = gridStock.ActiveRow.Cells[_StockTable.WarehouseNameColumn.ColumnName].Value;
                    gridParts.ActiveRow.Cells[_PartsTable.ShelfColumn.ColumnName].Value
                        = gridStock.ActiveRow.Cells[_StockTable.WarehouseShelfNoColumn.ColumnName].Value;
                    gridParts.ActiveRow.Cells[_PartsTable.StockCntColumn.ColumnName].Value
                        = gridStock.ActiveRow.Cells[_StockTable.ShipmentPosCntColumn.ColumnName].Value;
                    gridParts.ActiveRow.Cells[_PartsTable.WarehouseCodeColumn.ColumnName].Value
                        = gridStock.ActiveRow.Cells[_StockTable.WarehouseCodeColumn.ColumnName].Value;
                    gridStock.ActiveRow.Cells[_StockTable.SelectionStateColumn.ColumnName].Value = true;
                    gridParts.UpdateData();
                }
            }
        }

        private void gridStock_BeforeSelectChange(object sender, BeforeSelectChangeEventArgs e)
        {
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/27 ADD
            if ( !this.VisibleStockSelectCheckBox() )
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/27 ADD
            {
                if ( gridStock.Selected.Rows.Count > 0 )
                    gridStock.Selected.Rows[0].Cells[_StockTable.SelectionStateColumn.ColumnName].Value = false;
            }
        }

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/27 ADD
        /// <summary>
        /// 在庫選択チェックボックス表示チェック
        /// </summary>
        /// <returns></returns>
        private bool VisibleStockSelectCheckBox()
        {
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/02 DEL
            //// 2:エントリ, 3:在庫組立の場合
            //return (_mode == 2 || _mode == 3);
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/02 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/02 ADD
            // 常に表示する。
            return true;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/02 ADD
        }
        /// <summary>
        /// 在庫グリッド・Enterキー(ダブルクリック)による選択処理
        /// </summary>
        /// <param name="moveFlg"></param>
        private void SetSelectStock( bool moveFlg )
        {
            SetSelectStock( moveFlg, false );
        }
        /// <summary>
        /// 在庫グリッド・Enterキー(ダブルクリック)による選択処理
        /// </summary>
        /// <param name="moveFlg">true:次の行を選択状態に／false:なにもしない（マウスダブルクリック時）</param>
        /// <param name="setTrue">true:選択状態TRUEにする／選択状態を反転する</param>
        private void SetSelectStock( bool moveFlg, bool setTrue )
        {
            UltraGridRow activeRow = gridStock.ActiveRow;
            if ( activeRow != null )
            {
                CellsCollection activeCells = activeRow.Cells;

                // 選択/非選択の切り替え
                if ( activeCells[_StockTable.SelImageColumn.ColumnName].Value != DBNull.Value && !setTrue )
                {
                    activeCells[_StockTable.SelImageColumn.ColumnName].Value = DBNull.Value;
                    activeCells[_StockTable.SelectionStateColumn.ColumnName].Value = false;
                }
                else
                {
                    activeCells[_StockTable.SelImageColumn.ColumnName].Value = IconResourceManagement.ImageList24.Images[(int)Size24_Index.ITEMCHECK];
                    activeCells[_StockTable.SelectionStateColumn.ColumnName].Value = true;
                }
                _StockTable.AcceptChanges();

                // 他の行は選択解除する
                # region [他の行は選択解除する]
                foreach ( UltraGridRow row in gridStock.Rows )
                {
                    if ( row.Equals( activeRow ) == false && row.Cells[_StockTable.SelImageColumn.ColumnName].Value != DBNull.Value )
                    {
                        row.Cells[_StockTable.SelImageColumn.ColumnName].Value = DBNull.Value;
                        row.Cells[_StockTable.SelectionStateColumn.ColumnName].Value = false;
                    }
                }
                # endregion

                // 部品グリッドの在庫情報表示を更新
                # region [部品グリッドの在庫情報表示を更新]
                if ( gridParts.ActiveRow != null )
                {
                    if ( (bool)activeCells[_StockTable.SelectionStateColumn.ColumnName].Value == true )
                    {
                        // 部品グリッドに在庫情報表示
                        gridParts.ActiveRow.Cells[_PartsTable.WarehouseColumn.ColumnName].Value
                            = gridStock.ActiveRow.Cells[_StockTable.WarehouseNameColumn.ColumnName].Value;
                        gridParts.ActiveRow.Cells[_PartsTable.ShelfColumn.ColumnName].Value
                            = gridStock.ActiveRow.Cells[_StockTable.WarehouseShelfNoColumn.ColumnName].Value;
                        gridParts.ActiveRow.Cells[_PartsTable.StockCntColumn.ColumnName].Value
                            = gridStock.ActiveRow.Cells[_StockTable.ShipmentPosCntColumn.ColumnName].Value;
                        gridParts.ActiveRow.Cells[_PartsTable.WarehouseCodeColumn.ColumnName].Value
                            = gridStock.ActiveRow.Cells[_StockTable.WarehouseCodeColumn.ColumnName].Value;
                    }
                    else
                    {
                        // 部品グリッドの在庫情報をクリア
                        gridParts.ActiveRow.Cells[_PartsTable.WarehouseColumn.ColumnName].Value = string.Empty;
                        gridParts.ActiveRow.Cells[_PartsTable.ShelfColumn.ColumnName].Value = string.Empty;
                        gridParts.ActiveRow.Cells[_PartsTable.StockCntColumn.ColumnName].Value = 0;
                        gridParts.ActiveRow.Cells[_PartsTable.WarehouseCodeColumn.ColumnName].Value = string.Empty;
                    }
                    gridParts.UpdateData();
                }
                # endregion
            }
        }
        /// <summary>
        /// 在庫グリッド・行ダブルクリック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridStock_DoubleClickRow( object sender, DoubleClickRowEventArgs e )
        {
            SetSelectStock( false );
        }
        /// <summary>
        /// 在庫グリッド・キーダウン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridStock_KeyDown( object sender, KeyEventArgs e )
        {
            switch ( e.KeyCode )
            {
                case Keys.Enter:
                    SetSelectStock( true );
                    break;
            }
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/27 ADD
        // --- ADD m.suzuki 2010/10/26 ---------->>>>>
        /// <summary>
        /// 在庫グリッド進入時
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridStock_Enter( object sender, EventArgs e )
        {
            if ( gridStock.Rows.Count == 0 )
            {
                // 強制的に部品グリッドに移動
                gridParts.Focus();
            }
        }
        // --- ADD m.suzuki 2010/10/26 ----------<<<<<
        #endregion

    }
}
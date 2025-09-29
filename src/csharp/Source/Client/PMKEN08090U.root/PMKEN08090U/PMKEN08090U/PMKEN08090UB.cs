using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Controller;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.UltraWinToolbars;
using Broadleaf.Application.UIData;

using System.IO;   // ADD 譚洪 2014/09/01 FOR Redmine#43289
using Broadleaf.Application.Resources; // ADD 譚洪 2014/09/01 FOR Redmine#43289
using Broadleaf.Application.Common;  // ADD 譚洪 2014/09/01 FOR Redmine#43289
using System.Threading; // ADD 譚洪 2014/09/01 FOR Redmine#43289
using Broadleaf.Library.Globarization; // ADD 譚洪 2014/09/01 FOR Redmine#43289

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
    /// <br>Update Note	: 在庫表示順で優先倉庫が上に表示されるよう変更</br>
    /// <br>            : 在庫の選択方法をチェック方式に変更（未チェックで取寄を選択可能に変更）</br>
    /// <br>Programmer	: 22018　鈴木 正臣</br>
    /// <br>Date		: 2009.03.30</br>
    /// <br></br>
    /// <br>Update Note	: 子品番の倉庫を変更した場合にエントリ画面に反映されない障害の修正(MANTIS[0014650])</br>
    /// <br>            : セット子品番を選択した場合に、商品種別(複数なし)にセット子をセットするように修正(MANTIS[0014690])</br>
    /// <br>Programmer	: 21024　佐々木 健</br>
    /// <br>Date		: 2009/11/26</br>
    /// <br></br>
    /// <br>Update Note  : 障害改良対応（８月分）</br>
    /// <br>             : 　・在庫の明細件数がゼロの場合は、在庫グリッドにフォーカス移動しないように変更。</br>
    /// <br>Programmer   : 22018　鈴木 正臣</br>
    /// <br>Date         : 2010/10/26</br>
    /// <br></br>
    /// <br>Update Note	: 障害改良対応（ｘｘ月）</br>
    /// <br>             :   ・代替制御をＰＭ７準拠の動作に修正。</br>
    /// <br>                   （代替元の在庫があれば、代替しない。(※セット選択からの代替はユーザー代替のみ)）</br>
    /// <br>Programmer   : 22018  鈴木 正臣</br>
    /// <br>Date         : 2011/02/02</br>
    /// <br></br>
    /// <br>Update Note  : 障害改良対応(ｘｘ月分)</br>
    /// <br>             :   ・2011/02/02分の修正。在庫有無判定は優先倉庫のみ対象とする。(PM7準拠)</br>
    /// <br>Programmer   : 22018  鈴木 正臣</br>
    /// <br>Date         : 2011/02/09</br>
    /// <br></br>
    /// <br>Update Note  : 障害改良対応(ｘｘ月分)</br>
    /// <br>             :   ・2011/02/09分の修正。優先倉庫未設定の場合の処理を修正(異常終了させない)</br>
    /// <br>Programmer   : 22018  鈴木 正臣</br>
    /// <br>Date         : 2011/02/18</br>
    /// <br>Update Note  : 11070184-00 Redmine#43289対応</br>
    /// <br>                 車両情報・備考情報が表示されている状態で部品選択画面が起動するよう改良をおこないます。</br>
    /// <br>Programmer   : 譚洪</br>
    /// <br>Date         : 2014/09/01</br>
    /// <br>Update Note: 2014/09/01 譚洪</br>
    /// <br>管理番号   : 11070184-00　SCM障害対応 №190　RedMine#43289</br>
    /// <br>         　: SFから問合せの車輌情報・備考を売上伝票入力に表示する</br>
    /// <br>Update Note: 2014/09/22 鹿庭 一郎</br>
    /// <br>管理番号   : 11070184-00　SCM仕掛一覧No.10598</br>
    /// <br>         　: 文字列車台番号での発注・問合せ対応</br>
    /// <br>Update Note: 2014/11/04 宮本 利明</br>
    /// <br>管理番号   : 11070221-00　仕掛一覧 №2577</br>
    /// <br>         　: 車両情報を表示切替時の明細グリッドの高さ調整処理を修正</br>
    /// <br></br>
    /// </remarks>
    public partial class SelectionFormSet : Form
    {
        #region [ Private Member Variable ]
        /// <summary>データセット</summary>
        private PartsInfoDataSet _orgDataSet = null;
        private PartsInfoDataSet.UsrSetPartsDataTable _setPartsTable = null;
        private PartsInfoDataSet.UsrGoodsInfoRow _orgRow = null;
        private PartsInfoDataSet.UsrGoodsInfoRow _prevRow = null;
        private SetParts _dsSet = null;
        private SetParts.StockDataTable _StockTable;
        //public SetParts DsSet
        //{
        //    get
        //    {
        //        return _dsSet;
        //    }
        //}
        private string _JoinPartsNo = string.Empty;
        private int _JoinMakerCode = 0;
        private bool isUserClose = true;
        private bool uiControlFlg;      // false:PM7スタイル　　true:PM.NSスタイル
        private int substFlg;           // 0:代替しない  1:代替する（在庫判定あり） 2:代替する（在庫判定なし）
        private int userSubstFlg;
        private int enterFlg;           // 0:PM7, 1:選択 2:次画面（純正⇒結合、結合⇒セット、セット⇒確定）
        private int totalAmountDispWay;       // 総額表示方法区分 0:総額表示しない（税抜き）,1:総額表示する（税込み）

        private bool isSelectChangeDisabled = false;

        /// <summary> セット子品番の選択リスト </summary>
        private Dictionary<int, SelectionInfo> _lstSelInf;
        /// <summary> セット親品番の選択情報 </summary>
        private SelectionInfo _selInf;
        private SelectionInfo _prevSelInfo;

        private PMKEN01010E _orgCar = null;

        // ADD 譚洪 2014/09/01 FOR Redmine#43289 --- >>>
        private string _pgid = string.Empty;
        /// <summary>車両情報を表示用XMLファイル名（売伝画面）</summary>
        private const string MAHNB01001U_PMKEN08060U_CARINFOSELETED = "MAHNB01001U_PMKEN08060U_CarInfoSeleted.XML";
        /// <summary>車両情報を表示用XMLファイル名（見積画面）</summary>
        private const string PMMIT01010U_PMKEN08060U_CARINFOSELETED = "PMMIT01010U_PMKEN08060U_CarInfoSeleted.XML";
        /// <summary>売伝画面PGID</summary>
        private const string MAHNB01001U_PGID = "MAHNB01001U";
        /// <summary>見積画面PGID</summary>
        private const string PMMIT01010U_PGID = "PMMIT01010U";
        /// <summary>車両情報表示用SOLT</summary>
        private const string CARINFOSOLT = "CARINFOSOLT";
        private LocalDataStoreSlot carInfoSolt = null;
        // ADD 譚洪 2014/09/01 FOR Redmine#43289 --- <<<

        #endregion

        #region [ Constructor ]
        /// <summary>
        /// 選択画面コンストラクタ
        /// </summary>
        /// <param name="dsSource">グリッドに表示するデータを指定します。</param>
        public SelectionFormSet(PartsInfoDataSet dsSource)
        {
            _orgDataSet = dsSource;

            _setPartsTable = dsSource.UsrSetParts;
            if (dsSource.SearchCondition != null)
            {
                uiControlFlg = Convert.ToBoolean(dsSource.SearchCondition.SearchCntSetWork.SearchUICntDivCd); // 0:PM7スタイル／1:PM.NSスタイル
                substFlg = dsSource.SearchCondition.SearchCntSetWork.PrmSubstCondDivCd; // 0:代替しない  1:代替する（在庫判定あり） 2:代替する（在庫判定なし）
                userSubstFlg = dsSource.SearchCondition.SearchCntSetWork.SubstApplyDivCd;
                enterFlg = dsSource.SearchCondition.SearchCntSetWork.EnterProcDivCd; // 0:PM7, 1:選択 2:次画面（純正⇒結合、結合⇒セット、セット⇒確定）
                totalAmountDispWay = dsSource.SearchCondition.SearchCntSetWork.TotalAmountDispWayCd; // 0:総額表示しない（税抜き）,1:総額表示する（税込み）
            }
            else // マスメンなど直で同一品番選択UIを表示する場合
            {
                uiControlFlg = true;
                substFlg = 0;
                userSubstFlg = 0;
                enterFlg = 1;
            }
            InitializeComponent();
            InitializeTable();
            InitializeForm();
            StatusBar.Text = "";

            // ツールバーのイメージ(16x16)やメッセージを設定する
            ToolbarsManager.ImageListSmall = IconResourceManagement.ImageList16;

            ToolbarsManager.Tools["Button_Select"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.DECISION;
            ToolbarsManager.Tools["Button_Back"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.BEFORE;
            if (substFlg != 0)
            {
                ToolbarsManager.Tools["Button_Subst"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CARADD;
                //ToolbarsManager.Tools["Button_SubstOff"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.UNDO;
            }
            else
            {
                ToolbarsManager.Tools["Button_Subst"].SharedProps.Visible = false;
            }
            //ToolbarsManager.Tools["Button_SubstOff"].SharedProps.Visible = false;
        }
        #endregion

        #region [ イニシャル処理 ]
        private void InitializeForm()
        {
            //_prevRow = _orgRow;
            _orgRow = _orgDataSet.UsrGoodsInfo.RowToProcess;
            InitializeData();
            gridSetParts.Rows[0].ExpandAll();
            gridSetParts.Rows[0].Fixed = true;
        }

        /// <summary>
        /// 画面表示処理
        /// </summary>
        /// <returns>ダイアログ戻り値</returns>
        // 2009.02.19 >>>
        //public new DialogResult ShowDialog()
        public new DialogResult ShowDialog(IWin32Window owner)
        // 2009.02.19 <<<
        {
            // --- ADD 譚洪 2014/09/01 Redmine#43289 -------------------- >>>
            // Thread中、車両情報を取得します
            carInfoSolt = Thread.GetNamedDataSlot(CARINFOSOLT);
            string carInfoStr = string.Empty;
            // Thread中、車両情報を取得できる場合、
            if (Thread.GetData(carInfoSolt) != null)
            {
                CarInfoThreadData carInfoThreadData = (CarInfoThreadData)Thread.GetData(carInfoSolt);


                // 類別(PMの情報)
                this.tNedit_ModelDesignationNo.SetInt(carInfoThreadData.ModelDesignationNo);
                // 番号(PMの情報)
                this.tNedit_CategoryNo.SetInt(carInfoThreadData.CategoryNo);
                // 車台番号(PMとSF計算後の情報)
                this.tEdit_ProduceFrameNo.Text = carInfoThreadData.FrameNo;
                // VINコード「1:国産,2:外車」
                if (carInfoThreadData.FrameNoKubun == 2)
                {
                    this.uLabel_ProduceFrameNoTitle.Text = "VINコード";
                    this.uLabel_ProduceFrameNoTitle.Size = new Size(80, 24);
                    // --- DEL 2014/09/22 鹿庭 仕掛一覧 №10598 ------------------------------>>>>>
                    //this.tEdit_ProduceFrameNo.Size = new Size(147, 24);
                    // --- DEL 2014/09/22 鹿庭 仕掛一覧 №10598 ------------------------------<<<<<
                }
                else
                {
                    this.uLabel_ProduceFrameNoTitle.Text = "車台番号";
                    this.uLabel_ProduceFrameNoTitle.Size = new Size(67, 24);
                    // --- DEL 2014/09/22 鹿庭 仕掛一覧 №10598 ------------------------------>>>>>
                    //this.tEdit_ProduceFrameNo.Size = new Size(76, 24);
                    // --- DEL 2014/09/22 鹿庭 仕掛一覧 №10598 ------------------------------<<<<<
                }
                // 年式区分(PMの情報)全体初期値設定マスタの「0:西暦　1:和暦（年式）」
                if (carInfoThreadData.FirstEntryDateKubun == 0)
                {
                    // 西暦
                    this.tEdit_Gango.Visible = false;
                    this.tNedit_Wareki_Year.Visible = false;
                    this.tNedit_Sereki_Year.Visible = true;

                    // 西暦
                    if (carInfoThreadData.FirstEntryDate != 0)
                    {
                        this.tNedit_Sereki_Year.SetInt(carInfoThreadData.FirstEntryDate / 100); // 西暦年
                        this.tNedit_Month.SetInt(carInfoThreadData.FirstEntryDate % 100);　// 西暦月
                    }
                }
                else
                {
                    // 和歴
                    this.tEdit_Gango.Visible = true;
                    this.tNedit_Wareki_Year.Visible = true;
                    this.tNedit_Sereki_Year.Visible = false;

                    // 和暦
                    if (carInfoThreadData.FirstEntryDate != 0)
                    {
                        this.tNedit_Wareki_Year.SetInt(GetDateFW(carInfoThreadData.FirstEntryDate * 100 + 1)); // 和暦年
                        this.tEdit_Gango.Text = TDateTime.LongDateToString("GG", carInfoThreadData.FirstEntryDate * 100 + 1); // 和暦元号
                        this.tNedit_Month.SetInt(carInfoThreadData.FirstEntryDate % 100); // 和暦月
                    }
                }
                // メーカー(PMの情報)
                this.tNedit_MakerCode.SetInt(carInfoThreadData.MakerCode);
                // 車種(PMの情報)(PMの情報)
                this.tNedit_ModelCode.SetInt(carInfoThreadData.ModelCode);
                // 車種サブコード(PMの情報)
                this.tNedit_ModelSubCode.SetInt(carInfoThreadData.ModelSubCode);
                // 車種名(PMの情報)
                this.tEdit_ModelFullName.Text = carInfoThreadData.ModelFullName;
                // 型式(PMとSF計算後の情報)
                this.tEdit_FullModel.Text = carInfoThreadData.FullModel;
                // 備考(PMとSF計算後の情報)
                this.tEdit_Note.Text = carInfoThreadData.Note;
                // 画面元
                this._pgid = carInfoThreadData.Pgid;
            }

            // 検索見積画面のXMLファイルを読む
            if (this._pgid.Equals(PMMIT01010U_PGID))
            {
                bool carInfoFlg = Deserialize(PMMIT01010U_PMKEN08060U_CARINFOSELETED);
                this.pnl_CarInfo.Visible = carInfoFlg;
                this.SetPnlCarInfoVisible(carInfoFlg);
            }
            // 売伝画面のXMLファイルを読む
            else if (this._pgid.Equals(MAHNB01001U_PGID))
            {
                bool carInfoFlg = Deserialize(MAHNB01001U_PMKEN08060U_CARINFOSELETED);
                this.pnl_CarInfo.Visible = carInfoFlg;
                this.SetPnlCarInfoVisible(carInfoFlg);
            }
            // --- ADD 譚洪 2014/09/01 Redmine#43289 -------------------- <<<

            if (_prevRow != null && _prevRow.NewGoodsNo != string.Empty)
            {
                if (_prevSelInfo != null && _prevSelInfo.ListPlrlSubst.Count > 0)
                {
                    _prevSelInfo.Selected = true;
                    _prevSelInfo.ListPlrlSubst.RemoveAt(0); // 1個目は代替品情報なので削除しておく。
                }
                PartsInfoDataSet.UsrGoodsInfoRow newRow =
                        _orgDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(_prevRow.GoodsMakerCd, _prevRow.NewGoodsNo);
                //if (_dsSet.SetMain[0].Equals(_prevRow)) // セット親に対する代替は出来ないように制限する。
                //{
                //    //_joinParts.PartsInfo[0].OldPartsNo = _joinParts.PartsInfo[0].ClgPrtsNo;
                //    //_joinParts.PartsInfo[0].ClgPrtsNo = newRow.GoodsNo;
                //    //_joinParts.PartsInfo[0].PartsName = newRow.GoodsName;
                //    //_joinParts.PartsInfo[0].Price = newRow.Price;
                //}
                //else
                if (_dsSet.SetMain[0].Equals(_prevRow) == false)
                {
                    string filter = string.Format("{0}={1} AND {2}='{3}' ",
                            _dsSet.GoodsSet.SetSubMakerCdColumn.ColumnName, _prevRow.GoodsMakerCd,
                        //_dsSet.GoodsSet.SetSubOrgPrtNoColumn.ColumnName, _prevRow.GoodsNo);
                            _dsSet.GoodsSet.SetSubPartsNoColumn.ColumnName, _prevRow.GoodsNo);
                    SetParts.GoodsSetRow oldRow = ((SetParts.GoodsSetRow[])_dsSet.GoodsSet.Select(filter))[0];
                    //SetParts.GoodsSetRow oldRow =
                    //    _dsSet.GoodsSet.FindBySetSubMakerCdSetSubPartsNo(_prevRow.GoodsMakerCd, _prevRow.GoodsNo);

                    oldRow.OldPartsNo = oldRow.SetSubPartsNo;
                    oldRow.SetSubPartsNo = newRow.GoodsNo;
                    oldRow.SubGoodsName = newRow.GoodsName;
                    if (totalAmountDispWay == 1) // 総額表示する（税込み）
                    {
                        oldRow.SetPrice = newRow.PriceTaxInc;
                        oldRow.GenTanka = newRow.UnitCostTaxInc;
                        oldRow.UriTanka = newRow.SalesUnitPriceTaxInc;
                    }
                    else
                    {
                        oldRow.SetPrice = newRow.PriceTaxExc;
                        oldRow.GenTanka = newRow.UnitCostTaxExc;
                        oldRow.UriTanka = newRow.SalesUnitPriceTaxExc;
                    }
                    // 粗利額・粗利率は区分関係なく税抜きで計算
                    oldRow.Ararigaku = newRow.SalesUnitPriceTaxExc - newRow.UnitCostTaxExc;
                    if (newRow.SalesUnitPriceTaxExc != 0)
                        oldRow.Arariritu = oldRow.Ararigaku / newRow.SalesUnitPriceTaxExc;

                    //oldRow.SetSpecialNote = newRow.GoodsSpecialNote;
                    //oldRow[_dsSet.GoodsSet.SubstColumn] = DBNull.Value;    // 代替した部品はさらに代替選択不可
                    filter = string.Format("{0}={1} AND {2}='{3}' ",
                            _orgDataSet.Stock.GoodsMakerCdColumn.ColumnName,
                            gridSetParts.ActiveRow.Cells[_dsSet.GoodsSet.SetSubMakerCdColumn.ColumnName].Value,
                            _orgDataSet.Stock.GoodsNoColumn.ColumnName,
                            gridSetParts.ActiveRow.Cells[_dsSet.GoodsSet.SetSubPartsNoColumn.ColumnName].Value);
                    _StockTable.DefaultView.RowFilter = filter;
                    SetStockGridSelect();
                    if (gridStock.Rows.Count == 0)
                    {
                        oldRow.Shelf = string.Empty;
                        oldRow.StockCnt = 0;
                        oldRow.Warehouse = string.Empty;
                    }
                    _dsSet.GoodsSet.AcceptChanges(); ////
                    //ToolbarsManager.Tools["Button_SubstOff"].SharedProps.Visible = true;
                    ToolbarsManager.Tools["Button_Subst"].SharedProps.Enabled =
                            (gridSetParts.ActiveRow.Cells[_dsSet.GoodsSet.SubstColumn.ColumnName].Value != System.DBNull.Value);
                }
                if (_prevRow.Equals(newRow) == false)
                    _prevRow.SelectionState = false;
                _prevRow.NewGoodsNo = string.Empty;
                _prevRow = null;
                GridSetParts_AfterSelectChange(this, null);
            }

            isUserClose = true;
            if (_orgRow.Equals(_orgDataSet.UsrGoodsInfo.RowToProcess) == false)
            {
                InitializeForm();
            }
            _selInf = _orgDataSet.SetSrcSelInf;
            if (_selInf.Depth == 0) // 部品選択UIからのセット選択の場合
                _lstSelInf = _selInf.ListChildGoods2;
            else
                _lstSelInf = _selInf.ListChildGoods;

            _dsSet.SetMain[0].SelectionState = _selInf.Selected;
            _dsSet.SetMain[0].WarehouseCode = _selInf.WarehouseCode;
            if (_selInf.Selected)
            {
                _dsSet.SetMain[0].SelImage = IconResourceManagement.ImageList24.Images[(int)Size24_Index.ITEMCHECK];
            }
            else
            {
                _dsSet.SetMain[0][_dsSet.SetMain.SelImageColumn] = DBNull.Value;
            }

            Infragistics.Win.UltraWinGrid.RowsCollection rows = gridSetParts.Rows[0].ChildBands[0].Rows;
            int cnt = rows.Count;
            for (int i = 0; i < cnt; i++)
            {
                if (_lstSelInf.ContainsKey(rows[i].ListIndex) && _lstSelInf[rows[i].ListIndex].Selected)
                {
                    rows[i].Cells[_dsSet.GoodsSet.SelectionStateColumn.ColumnName].Value = true;
                    rows[i].Cells[_dsSet.GoodsSet.SelImageColumn.ColumnName].Value = IconResourceManagement.ImageList24.Images[(int)Size24_Index.ITEMCHECK];
                }
                else
                {
                    rows[i].Cells[_dsSet.GoodsSet.SelectionStateColumn.ColumnName].Value = false;
                    //rows[i].SelectionState = false;
                    rows[i].Cells[_dsSet.GoodsSet.SelImageColumn.ColumnName].Value = DBNull.Value;
                }
            }

            //int cnt = _dsSet.GoodsSet.Count;
            //for (int i = 0; i < cnt; i++)
            //{
            //    PartsInfoDataSet.UsrGoodsInfoRow row = _orgDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(
            //        _dsSet.GoodsSet[i].SetSubMakerCd, _dsSet.GoodsSet[i].SetSubPartsNo);

            //    if (row != null)
            //    {
            //        _dsSet.GoodsSet[i].SelectionState = row.SelectionState;
            //        if (row.SelectionState)
            //        {
            //            _dsSet.GoodsSet[i].SelImage = IconResourceManagement.ImageList24.Images[(int)Size24_Index.ITEMCHECK];
            //        }
            //        else
            //        {
            //            _dsSet.GoodsSet[i][_dsSet.GoodsSet.SelImageColumn] = DBNull.Value;
            //        }
            //    }
            //}

            if (gridSetParts.Selected.Rows.Count > 0)
            {
                gridSetParts.Selected.Rows[0].Activated = true;
            }
            else
            {
                gridSetParts.Rows[0].Activate();
                gridSetParts.Rows[0].Selected = true;
            }

            cnt = _StockTable.Count;
            for (int i = 0; i < cnt; i++)
            {
                PartsInfoDataSet.StockRow stockRow = _orgDataSet.Stock.FindByWarehouseCodeGoodsNoGoodsMakerCd(
                    _StockTable[i].WarehouseCode, _StockTable[i].GoodsNo, _StockTable[i].GoodsMakerCd);
                if (stockRow != null)
                {
                    _StockTable[i].SelectionState = stockRow.SelectionState;
                }
            }
            SetStockGridSelect();
            gridSetParts.UpdateData();
            // 2009.02.19 >>>
            //return base.ShowDialog();
            return base.ShowDialog(owner);
            // 2009.02.19 <<<
        }

        /// <summary>
        /// テーブル作成及びデータセットへの追加、リレーション設定
        /// </summary>
        private void InitializeTable()
        {
            // DataTable の設定

        }

        /// <summary>
        /// コントローラのデータセットよりローカルデータセットへのデータコピー
        /// </summary>
        private void InitializeData()
        {
            // 2009.02.10 Add >>>
            this.SettingPriceTargetData();
            // 2009.02.10 Add <<<
            _dsSet = new SetParts();
            _StockTable = _dsSet.Stock;
            # region データの設定
            //_dsSet.GoodsSet.BeginLoadData();
            try
            {
                #region [ セット親の設定 ]
                if (_orgRow.NewGoodsNo != string.Empty)
                {
                    PartsInfoDataSet.UsrGoodsInfoRow rowNewPartsNo =
                        _orgDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(_orgRow.GoodsMakerCd, _orgRow.NewGoodsNo);
                    if (rowNewPartsNo != null)
                        _orgRow = rowNewPartsNo;
                }

                _JoinPartsNo = _orgRow.GoodsNo;
                _JoinMakerCode = _orgRow.GoodsMakerCd;

                SetParts.SetMainRow mainRow = _dsSet.SetMain.NewSetMainRow();
                mainRow.MakerCd = _orgRow.GoodsMakerCd;
                mainRow.MakerNm = _orgRow.GoodsMakerNm;
                mainRow.PartsNo = _orgRow.GoodsNo;
                if (totalAmountDispWay == 1) // 総額表示する（税込み）
                {
                    mainRow.Price = _orgRow.PriceTaxInc;
                    mainRow.UriTanka = _orgRow.SalesUnitPriceTaxInc;
                    mainRow.GenTanka = _orgRow.UnitCostTaxInc;
                }
                else
                {
                    mainRow.Price = _orgRow.PriceTaxExc;
                    mainRow.UriTanka = _orgRow.SalesUnitPriceTaxExc;
                    mainRow.GenTanka = _orgRow.UnitCostTaxExc;
                }
                // 粗利額・粗利率は区分関係なく税抜きで計算
                mainRow.Ararigaku = _orgRow.SalesUnitPriceTaxExc - _orgRow.UnitCostTaxExc;
                if (_orgRow.SalesUnitPriceTaxExc != 0)
                    mainRow.Arariritu = mainRow.Ararigaku / _orgRow.SalesUnitPriceTaxExc;

                if ((_orgRow.OfferKubun == 1 || _orgRow.OfferKubun == 3) &&  // セット親が純正か
                        _orgRow.SearchPartsFullName != string.Empty)
                {
                    mainRow.PrimePartsName = _orgRow.SearchPartsFullName;
                }
                else if (_orgRow.GoodsName != string.Empty)
                {
                    mainRow.PrimePartsName = _orgRow.GoodsName;
                }
                else
                {
                    mainRow.PrimePartsName = _orgRow.GoodsOfrName;
                }

                mainRow.SetSpecialNote = _orgRow.GoodsSpecialNote;
                mainRow.Qty = _orgRow.QTY;
                if (mainRow.Qty == 0)
                    mainRow.Qty = 1;

                //string filter = string.Format("{0}={1} AND {2}='{3}'",
                //    _orgDataSet.UsrSubstParts.ChgSrcMakerCdColumn.ColumnName, mainRow.MakerCd,
                //    _orgDataSet.UsrSubstParts.ChgSrcGoodsNoColumn.ColumnName, mainRow.PartsNo);
                //if (_orgDataSet.UsrSubstParts.Select(filter).Length > 0)
                //    mainRow.Subst = IconResourceManagement.ImageList16.Images[(int)Size16_Index.CARADD];
                if (SubstExists(mainRow.PartsNo, mainRow.MakerCd))
                {
                    mainRow.Subst = IconResourceManagement.ImageList16.Images[(int)Size16_Index.CARADD];
                }

                _dsSet.SetMain.AddSetMainRow(mainRow);

                //在庫設定
                bool flgStock = false;
                PartsInfoDataSet.StockRow[] stockRows = (PartsInfoDataSet.StockRow[])_orgRow.GetChildRows("UsrGoodsInfo_Stock");
                for (int i = 0; i < stockRows.Length; i++)
                {
                    //mainRow.Subst = IconResourceManagement.ImageList16.Images[(int)Size16_Index.MAIN];
                    SetParts.StockRow stockRow = _StockTable.NewStockRow();
                    stockRow.GoodsMakerCd = stockRows[i].GoodsMakerCd;
                    stockRow.GoodsNo = stockRows[i].GoodsNo;
                    stockRow.MaximumStockCnt = stockRows[i].MaximumStockCnt;
                    stockRow.MinimumStockCnt = stockRows[i].MinimumStockCnt;
                    stockRow.ShipmentPosCnt = stockRows[i].ShipmentPosCnt;
                    stockRow.WarehouseCode = stockRows[i].WarehouseCode;
                    stockRow.WarehouseName = stockRows[i].WarehouseName;
                    stockRow.WarehouseShelfNo = stockRows[i].WarehouseShelfNo;
                    stockRow.SelectionState = stockRows[i].SelectionState;
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/26 ADD
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
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/26 ADD
                    _StockTable.AddStockRow(stockRow);
                    if (stockRows[i].SelectionState)
                    {
                        mainRow.Shelf = stockRow.WarehouseShelfNo;
                        mainRow.StockCnt = stockRow.ShipmentPosCnt;
                        mainRow.Warehouse = stockRow.WarehouseName;
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/27 ADD
                        mainRow.WarehouseCode = stockRow.WarehouseCode;
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/27 ADD
                        flgStock = true;
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
                            if (stockRows[k].WarehouseCode.Equals(warehouseCd))
                            {
                                mainRow.Shelf = stockRows[k].WarehouseShelfNo;
                                mainRow.StockCnt = stockRows[k].ShipmentPosCnt;
                                mainRow.Warehouse = stockRows[k].WarehouseName;
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/27 ADD
                                mainRow.WarehouseCode = stockRows[k].WarehouseCode;
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/27 ADD
                                flgStock = true;
                                break;
                            }
                        }
                        if (flgStock)
                            break;
                    }
                }
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/27 DEL // 優先倉庫にない場合は取寄にする
                //if (flgStock == false && stockRows.Length > 0)
                //{
                //    mainRow.Shelf = stockRows[0].WarehouseShelfNo;
                //    mainRow.StockCnt = stockRows[0].ShipmentPosCnt;
                //    mainRow.Warehouse = stockRows[0].WarehouseName;
                //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/27 ADD
                //    mainRow.WarehouseCode = stockRows[0].WarehouseCode;
                //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/27 ADD
                //}
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/27 DEL
                #endregion

                string filter = String.Format("{0}='{1}' and {2}={3}",
                    _setPartsTable.ParentGoodsNoColumn.ColumnName, _JoinPartsNo,
                    _setPartsTable.ParentGoodsMakerCdColumn.ColumnName, _JoinMakerCode);
                PartsInfoDataSet.UsrSetPartsRow[] setRows = (PartsInfoDataSet.UsrSetPartsRow[])_setPartsTable.Select(filter,
                    _setPartsTable.DisplayOrderColumn.ColumnName);

                for (int i = 0; i < setRows.Length; i++)
                {
                    PartsInfoDataSet.UsrSetPartsRow setRow = setRows[i];
                    PartsInfoDataSet.UsrGoodsInfoRow setPartsRow =
                        _orgDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(setRow.SubGoodsMakerCd, setRow.SubGoodsNo);
                    if (setPartsRow == null) // nullになるケースはないはずなので。
                        continue;
                    // --- UPD m.suzuki 2011/02/02 ---------->>>>>
                    # region // DEL
                    //if (substFlg != 1 || PartsStockCheck(setRow.SubGoodsNo, setRow.SubGoodsMakerCd) == false)
                    //{       // [代替条件：在庫判定有　且つ　旧品在庫ありの場合]以外は最新品番に代替する。
                    //    PartsInfoDataSet.UsrGoodsInfoRow rowNew = _orgDataSet.GetOfrSubst(setPartsRow);
                    //    if (userSubstFlg != 0) // ユーザー代替しない以外の場合
                    //    {
                    //        PartsInfoDataSet.UsrGoodsInfoRow rowSubst = _orgDataSet.GetUsrSubst(setPartsRow);
                    //        if (rowSubst.Equals(setPartsRow)) // 旧優良品に対しユーザー代替がない
                    //        {
                    //            if (rowNew.Equals(setPartsRow) == false) // 最新品番がある場合
                    //            {
                    //                rowSubst = _orgDataSet.GetUsrSubst(rowNew);
                    //                if (rowSubst.Equals(rowNew)) // 最新品に対しユーザー代替なし
                    //                {
                    //                    setPartsRow = rowNew;
                    //                }
                    //                else // 最新品に対しユーザー代替あり
                    //                {
                    //                    setPartsRow = rowSubst;
                    //                }
                    //            }
                    //        }
                    //        else // 旧優良品に対しユーザー代替がある場合
                    //        {
                    //            setPartsRow = rowSubst;
                    //        }
                    //    }
                    //    else // ユーザー代替しないの場合最新品番に代替する。
                    //    {
                    //        setPartsRow = rowNew;
                    //    }
                    //    //row = _orgDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(makerCd, partsNoInUse);
                    //}
                    # endregion

                    // 代替元の在庫チェック
                    bool stockCountNotZero;
                    if ( PartsStockCheck( setRow.SubGoodsNo, setRow.SubGoodsMakerCd, out stockCountNotZero ) == false ||
                         stockCountNotZero == false )
                    {
                        // ユーザー代替区分
                        if ( userSubstFlg != 0 )
                        {
                            PartsInfoDataSet.UsrGoodsInfoRow rowSubst = _orgDataSet.GetUsrSubst( setPartsRow );
                            if ( rowSubst.Equals( setPartsRow ) == false )
                            {
                                // ユーザー代替先に代替
                                setPartsRow = rowSubst;
                            }
                        }
                    }
                    // --- UPD m.suzuki 2011/02/02 ----------<<<<<

                    SetParts.GoodsSetRow wkRow = _dsSet.GoodsSet.NewGoodsSetRow();

                    wkRow.SetMainPartsNo = setRow.ParentGoodsNo;
                    wkRow.SetSubPartsNo = setPartsRow.GoodsNo;
                    wkRow.SetSubOrgPrtNo = setRow.SubGoodsNo;
                    wkRow.SetSubMakerCd = setPartsRow.GoodsMakerCd;
                    wkRow.SetQty = setRow.CntFl;
                    if (wkRow.SetQty == 0)
                        wkRow.SetQty = 1;
                    wkRow.SetSpecialNote = setRow.SetSpecialNote;
                    wkRow.CatalogShapeNo = setRow.CatalogShapeNo;
                    wkRow.SetMainRowParent = mainRow;

                    wkRow.SetSubMakerName = setPartsRow.GoodsMakerNm;
                    if (setPartsRow.GoodsName != string.Empty)
                    {
                        wkRow.SubGoodsName = setPartsRow.GoodsName;
                    }
                    else
                    {
                        wkRow.SubGoodsName = setPartsRow.GoodsOfrName;
                    }
                    if (totalAmountDispWay == 1) // 総額表示する（税込み）
                    {
                        wkRow.SetPrice = setPartsRow.PriceTaxInc;
                        wkRow.UriTanka = setPartsRow.SalesUnitPriceTaxInc;
                        wkRow.GenTanka = setPartsRow.UnitCostTaxInc;
                    }
                    else
                    {
                        wkRow.SetPrice = setPartsRow.PriceTaxExc;
                        wkRow.UriTanka = setPartsRow.SalesUnitPriceTaxExc;
                        wkRow.GenTanka = setPartsRow.UnitCostTaxExc;
                    }
                    // 粗利額・粗利率は区分関係なく税抜きで計算
                    wkRow.Ararigaku = setPartsRow.SalesUnitPriceTaxExc - setPartsRow.UnitCostTaxExc;
                    if (setPartsRow.SalesUnitPriceTaxExc != 0)
                        wkRow.Arariritu = wkRow.Ararigaku / setPartsRow.SalesUnitPriceTaxExc;

                    filter = String.Format("{0}='{1}' and {2}={3}",
                                _orgDataSet.GoodsSet.SetMainPartsNoColumn.ColumnName, _JoinPartsNo,
                                _orgDataSet.GoodsSet.SetMainMakerCdColumn.ColumnName, _JoinMakerCode);
                    PartsInfoDataSet.GoodsSetRow[] ofrSetRows = (PartsInfoDataSet.GoodsSetRow[])_orgDataSet.GoodsSet.Select(filter);
                    if (ofrSetRows.Length > 0)
                    {
                        wkRow.SetName = ofrSetRows[0].SetName;
                    }
                    if (SubstExists(wkRow.SetSubOrgPrtNo, wkRow.SetSubMakerCd))
                    {
                        wkRow.Subst = IconResourceManagement.ImageList16.Images[(int)Size16_Index.CARADD];
                    }
                    _dsSet.GoodsSet.AddGoodsSetRow(wkRow);

                    #region [ 在庫設定 ]
                    filter = string.Format("{0}={1} AND {2}='{3}'",
                            _orgDataSet.Stock.GoodsMakerCdColumn.ColumnName, wkRow.SetSubMakerCd,
                            _orgDataSet.Stock.GoodsNoColumn.ColumnName, wkRow.SetSubPartsNo);
                    stockRows = (PartsInfoDataSet.StockRow[])_orgDataSet.Stock.Select(filter);
                    flgStock = false;
                    for (int j = 0; j < stockRows.Length; j++)
                    {
                        if (_StockTable.FindByWarehouseCodeGoodsMakerCdGoodsNo(stockRows[j].WarehouseCode,
                            stockRows[j].GoodsMakerCd, stockRows[j].GoodsNo) == null)
                        {
                            SetParts.StockRow stockRow = _StockTable.NewStockRow();
                            stockRow.GoodsMakerCd = stockRows[j].GoodsMakerCd;
                            stockRow.GoodsNo = stockRows[j].GoodsNo;
                            stockRow.MaximumStockCnt = stockRows[j].MaximumStockCnt;
                            stockRow.MinimumStockCnt = stockRows[j].MinimumStockCnt;
                            stockRow.ShipmentPosCnt = stockRows[j].ShipmentPosCnt;
                            stockRow.WarehouseCode = stockRows[j].WarehouseCode;
                            stockRow.WarehouseName = stockRows[j].WarehouseName;
                            stockRow.WarehouseShelfNo = stockRows[j].WarehouseShelfNo;
                            stockRow.SelectionState = stockRows[j].SelectionState;
                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/26 ADD
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
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/26 ADD
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
                                if (stockRows[k].WarehouseCode.Equals(warehouseCd))
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
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/27 DEL // 優先倉庫に無い場合は取寄にする
                    //if (flgStock == false && stockRows.Length > 0)
                    //{
                    //    wkRow.Shelf = stockRows[0].WarehouseShelfNo;
                    //    wkRow.StockCnt = stockRows[0].ShipmentPosCnt;
                    //    wkRow.Warehouse = stockRows[0].WarehouseName;
                    //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/27 ADD
                    //    wkRow.WarehouseCode = stockRows[0].WarehouseCode;
                    //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/27 ADD
                    //}
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/27 DEL
                    #endregion
                }
            }
            finally
            {
                _dsSet.AcceptChanges();
                //_dsSet.GoodsSet.EndLoadData();
                gridSetParts.BeginUpdate();
                gridSetParts.DataSource = _dsSet.SetMain.DefaultView;
                gridSetParts.EndUpdate();
                gridStock.DataSource = _StockTable.DefaultView;
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/26 ADD
                SettingStockView( _StockTable.DefaultView );
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/26 ADD
            }

            # endregion
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

        // 2009.02.10 Add >>>
        /// <summary>
        /// 対象データの価格設定
        /// </summary>
        private void SettingPriceTargetData()
        {
            if (_orgDataSet.CalculateGoodsPrice == null) return;

            List<PartsInfoDataSet.GoodsPrimaryKey> goodsPrimaryKeyList = new List<PartsInfoDataSet.GoodsPrimaryKey>();

            // 結合元
            goodsPrimaryKeyList.Add(new PartsInfoDataSet.GoodsPrimaryKey(_orgRow.GoodsNo, _orgRow.GoodsMakerCd));

            string filter = String.Format("{0}='{1}' and {2}={3}",
                _setPartsTable.ParentGoodsNoColumn.ColumnName, _orgRow.GoodsNo,
                _setPartsTable.ParentGoodsMakerCdColumn.ColumnName, _orgRow.GoodsMakerCd);
            PartsInfoDataSet.UsrSetPartsRow[] setRows = (PartsInfoDataSet.UsrSetPartsRow[])_setPartsTable.Select(filter,
                _setPartsTable.DisplayOrderColumn.ColumnName);

            for (int i = 0; i < setRows.Length; i++)
            {
                PartsInfoDataSet.UsrSetPartsRow setRow = setRows[i];
                PartsInfoDataSet.UsrGoodsInfoRow setPartsRow =
                    _orgDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(setRow.SubGoodsMakerCd, setRow.SubGoodsNo);
                if (setPartsRow == null) // nullになるケースはないはずなので。
                    continue;
                // --- UPD m.suzuki 2011/02/02 ---------->>>>>
                # region // DEL
                //if (substFlg != 1 || PartsStockCheck(setRow.SubGoodsNo, setRow.SubGoodsMakerCd) == false)
                //{       // [代替条件：在庫判定有　且つ　旧品在庫ありの場合]以外は最新品番に代替する。
                //    PartsInfoDataSet.UsrGoodsInfoRow rowNew = _orgDataSet.GetOfrSubst(setPartsRow);
                //    if (userSubstFlg != 0) // ユーザー代替しない以外の場合
                //    {
                //        PartsInfoDataSet.UsrGoodsInfoRow rowSubst = _orgDataSet.GetUsrSubst(setPartsRow);
                //        if (rowSubst.Equals(setPartsRow)) // 旧優良品に対しユーザー代替がない
                //        {
                //            if (rowNew.Equals(setPartsRow) == false) // 最新品番がある場合
                //            {
                //                rowSubst = _orgDataSet.GetUsrSubst(rowNew);
                //                if (rowSubst.Equals(rowNew)) // 最新品に対しユーザー代替なし
                //                {
                //                    setPartsRow = rowNew;
                //                }
                //                else // 最新品に対しユーザー代替あり
                //                {
                //                    setPartsRow = rowSubst;
                //                }
                //            }
                //        }
                //        else // 旧優良品に対しユーザー代替がある場合
                //        {
                //            setPartsRow = rowSubst;
                //        }
                //    }
                //    else // ユーザー代替しないの場合最新品番に代替する。
                //    {
                //        setPartsRow = rowNew;
                //    }
                //    //row = _orgDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(makerCd, partsNoInUse);
                //}
                # endregion

                // 代替元の在庫チェック
                bool stockCountNotZero;
                if ( PartsStockCheck( setRow.SubGoodsNo, setRow.SubGoodsMakerCd, out stockCountNotZero ) == false ||
                     stockCountNotZero == false )
                {
                    // ユーザー代替区分
                    if ( userSubstFlg != 0 )
                    {
                        PartsInfoDataSet.UsrGoodsInfoRow rowSubst = _orgDataSet.GetUsrSubst( setPartsRow );
                        if ( rowSubst.Equals( setPartsRow ) == false )
                        {
                            // ユーザー代替先に代替
                            setPartsRow = rowSubst;
                        }
                    }
                }
                // --- UPD m.suzuki 2011/02/02 ----------<<<<<

                if (setPartsRow != null)
                {
                    goodsPrimaryKeyList.Add(new PartsInfoDataSet.GoodsPrimaryKey(setPartsRow.GoodsNo, setPartsRow.GoodsMakerCd));
                }
            }

            // 商品情報が存在する場合は価格計算
            if (goodsPrimaryKeyList.Count > 0)
            {
                _orgDataSet.SettingGoodsPrice(goodsPrimaryKeyList);
            }
        }
        // 2009.02.10 Add <<<

        #endregion

        /// <summary>
        /// カタログ品番の現在庫数チェック
        /// </summary>
        /// <param name="parts">品番</param>
        /// <param name="maker">メーカー</param>
        /// <returns>true:現在庫数あり　false:現在庫なし</returns>
        internal bool PartsStockCheck(string parts, int maker)
        {
            bool ret = false;
            string rowFilter = String.Format("{0}='{1}' AND {2}={3}",
                        _orgDataSet.Stock.GoodsNoColumn.ColumnName, parts,
                        _orgDataSet.Stock.GoodsMakerCdColumn.ColumnName, maker);
            PartsInfoDataSet.StockRow[] rowStock = (PartsInfoDataSet.StockRow[])_orgDataSet.Stock.Select(rowFilter);
            if (rowStock.Length > 0) // 実は下記のコメントされた処理がもっと正しいと思われるが、PM7に合わせたほうが
                ret = true;          // いいということによりこの処理にする。
            //for (int i = 0; i < rowStock.Length; i++)
            //{
            //    if (rowStock[i].ShipmentPosCnt > 0)
            //    {
            //        ret = true;
            //        break;
            //    }
            //}
            return ret;
        }
        // --- ADD m.suzuki 2011/02/02 ---------->>>>>
        /// <summary>
        /// カタログ品番の現在庫数チェック(2)
        /// </summary>
        /// <param name="parts">品番</param>
        /// <param name="maker">メーカー</param>
        /// <param name="stockCountNotZero"></param>
        /// <returns>true:現在庫数あり　false:現在庫なし</returns>
        internal bool PartsStockCheck( string parts, int maker, out bool stockCountNotZero )
        {
            bool ret = false;
            stockCountNotZero = false;

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

            if ( rowStock.Length > 0 )
            {
                // 在庫レコードあり
                ret = true;

                // 在庫数>0のレコード有無を判定
                for ( int i = 0; i < rowStock.Length; i++ )
                {
                    if ( rowStock[i].ShipmentPosCnt > 0 )
                    {
                        // 在庫数>0の在庫が存在する
                        stockCountNotZero = true;
                        break;
                    }
                }
            }

            return ret;
        }
        // --- ADD m.suzuki 2011/02/02 ----------<<<<<

        internal bool SubstExists(string parts, int maker)
        {
            // --- UPD m.suzuki 2011/02/02 ---------->>>>>
            //if (substFlg == 0) // 「代替しない」の時は無条件false
            //    return false;
            //string rowFilter = String.Format("{0}='{1}' AND {2}={3} AND {4} = true", // 代替選択UIには提供のみ表示
            //    _orgDataSet.UsrSubstParts.ChgSrcGoodsNoColumn.ColumnName, parts,
            //    _orgDataSet.UsrSubstParts.ChgSrcMakerCdColumn.ColumnName, maker, _orgDataSet.UsrSubstParts.OfferKubunColumn.ColumnName);
            //if (_orgDataSet.UsrSubstParts.Select(rowFilter).Length > 0)
            //{
            //    if (substFlg == 2) // 「在庫判定なし」の時は　代替があるだけでtrue
            //    {
            //        return true;
            //    }
            //    else // 「在庫判定あり」の時は代替あり且つ代替元品の現在庫数なしの時のみtrue
            //    {
            //        if (PartsStockCheck(parts, maker) == false) // 現在庫なしなら「在庫判定有」でも代替可
            //        {
            //            return true;
            //        }
            //    }
            //}
            //return false;
            return false;
            // --- UPD m.suzuki 2011/02/02 ----------<<<<<
        }

        #region [ フォームイベント処理 ]
        /// <summary>
        /// ESCキー押下による終了処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectionFormSet_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                DialogResult = DialogResult.Cancel;
                isUserClose = false;
            }
        }

        /// <summary>
        /// FormClosed イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>DialogResultがOKの場合にのみ、グリッド上で選択されている行に関連するDataRowオブジェクトを取得し、</br>
        /// <br>"選択状態"に相当する処理を行います。</br>
        /// </remarks>
        private void SelectionFormSet_FormClosed(object sender, FormClosedEventArgs e)
        {
            // ADD 譚洪 2014/09/01 FOR Redmine#43289 --- >>>
            bool carInfoFlg = this.pnl_CarInfo.Visible;

            if (this._pgid.Equals(PMMIT01010U_PGID))
            {
                Serialize(carInfoFlg, PMMIT01010U_PMKEN08060U_CARINFOSELETED);
            }
            else if (this._pgid.Equals(MAHNB01001U_PGID))
            {
                Serialize(carInfoFlg, MAHNB01001U_PMKEN08060U_CARINFOSELETED);
            }
            // ADD 譚洪 2014/09/01 FOR Redmine#43289 --- <<<

            if (DialogResult == DialogResult.Cancel)
            {
                //_orgDataSet.UsrGoodsInfo.RowToProcess = _orgDataSet.UsrGoodsInfo.PreviouslyProcessedRow;
                return;
            }
            //bool flg = false;

            //_orgRow.SelectionState = _dsSet.SetMain[0].SelectionState;
            _selInf.Selected = _dsSet.SetMain[0].SelectionState;
            if (_dsSet.SetMain[0].SelectionState)
            {
                _selInf.RowGoods.QTY = _dsSet.SetMain[0].Qty;
                _selInf.RowGoods.GoodsKindResolved = (int)GoodsKind.Parent;
                _selInf.WarehouseCode = _dsSet.SetMain[0].WarehouseCode;
            }

            Infragistics.Win.UltraWinGrid.RowsCollection rows = gridSetParts.Rows[0].ChildBands[0].Rows;
            int cnt = rows.Count;
            for (int i = 0; i < cnt; i++)
            {
                if (rows[i].Cells[_dsSet.GoodsSet.SelectionStateColumn.ColumnName].Value.Equals(true))
                {
                    PartsInfoDataSet.UsrGoodsInfoRow row = _orgDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(
                        (int)rows[i].Cells[_dsSet.GoodsSet.SetSubMakerCdColumn.ColumnName].Value,
                        rows[i].Cells[_dsSet.GoodsSet.SetSubPartsNoColumn.ColumnName].Value.ToString());
                    //_joinParts.JoinParts[i].JoinDestMakerCd,
                    //_joinParts.JoinParts[i].JoinDestPartsNo);
                    if (row != null)
                    {
                        row.QTY = _dsSet.GoodsSet[i].SetQty;
                        // 2009/11/26 >>>
                        //row.GoodsKindResolved = (int)GoodsKind.Join;
                        row.GoodsKindResolved = (int)GoodsKind.Set;
                        // 2009/11/26 <<<

                        SelectionInfo selInfo = new SelectionInfo();
                        selInfo.Depth = 2;
                        selInfo.Key = rows[i].ListIndex;
                        selInfo.RowGoods = row;
                        selInfo.Selected = true;
                        // 2009/11/26 >>>
                        selInfo.WarehouseCode = rows[i].Cells[_dsSet.GoodsSet.WarehouseCodeColumn.ColumnName].Value.ToString();
                        // 2009/11/26 <<<
                        if (gridSetParts.ActiveRow != null && gridSetParts.ActiveRow.Index == i
                            && _orgDataSet.UIKind == SelectUIKind.Subst)
                        {
                            _orgDataSet.SubstSrcSelInf = selInfo;
                            _prevSelInfo = selInfo;
                        }
                        _orgDataSet.AddSelectionInfo(_lstSelInf, rows[i].ListIndex, ref selInfo);
                    }
                }
                else
                {
                    _orgDataSet.RemoveSelectionInfo(_lstSelInf, rows[i].ListIndex);
                }
            }
            //int cnt = _dsSet.GoodsSet.Count;
            //for (int i = 0; i < cnt; i++)
            //{
            //    PartsInfoDataSet.UsrGoodsInfoRow row = _orgDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(
            //        _dsSet.GoodsSet[i].SetSubMakerCd,
            //        _dsSet.GoodsSet[i].SetSubPartsNo);
            //    if (row != null)
            //    {
            //        row.SelectionState = _dsSet.GoodsSet[i].SelectionState;
            //        if (_dsSet.GoodsSet[i].SelectionState)
            //        {
            //            row.QTY = _dsSet.GoodsSet[i].SetQty;
            //            row.GoodsKindResolved = (int)GoodsKind.Set;
            //        }
            //        if (row.SelectionState)
            //            flg = true;
            //    }
            //}

            cnt = _StockTable.Count;
            for (int i = 0; i < cnt; i++)
            {
                PartsInfoDataSet.StockRow stockRow = _orgDataSet.Stock.FindByWarehouseCodeGoodsNoGoodsMakerCd(
                    _StockTable[i].WarehouseCode, _StockTable[i].GoodsNo, _StockTable[i].GoodsMakerCd);
                if (stockRow != null)
                {
                    stockRow.SelectionState = _StockTable[i].SelectionState;
                }
            }
        }

        private void SelectionFormSet_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (uiControlFlg && e.CloseReason == CloseReason.UserClosing && isUserClose)
            //{
            //    if (TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, this.Text,
            //        "以前の選択画面に戻らず、選択をキャンセルしますか？", 0, MessageBoxButtons.YesNo)
            //        == DialogResult.Yes)
            //    {
            //        this.DialogResult = DialogResult.Abort;
            //    }
            //    else
            //    {
            //        e.Cancel = true;
            //    }
            //}
        }
        #endregion

        #region [ ツールバーイベント処理 ]
        /// <summary>
        /// ツールボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolbarsManager_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                case "Button_Select":
                    // 選択されている行を確定する
                    //_orgDataSet.UsrGoodsInfo.RowToProcess = _orgDataSet.UsrGoodsInfo.PreviouslyProcessedRow;
                    if (enterFlg == 2) // Enterキーが「次画面」の場合
                    {
                        SetSelect(false);
                    }
                    else
                    {
                        if (uiControlFlg == false && _dsSet.SetMain[0].SelectionState == false
                           && _dsSet.GoodsSet.Select("SelectionState = true").Length == 0)
                        {
                            SetStatusBarText(1, "データの選択がされていません。");
                            break;
                        }
                        DialogResult = DialogResult.OK;
                    }
                    isUserClose = false;
                    break;

                case "Button_Back":
                    // 前の画面に戻る
                    DialogResult = DialogResult.Cancel;
                    isUserClose = false;
                    break;

                case "Button_Subst":
                    UltraGridRow activeRow = gridSetParts.ActiveRow;
                    if (activeRow != null)
                    {
                        if (activeRow.Cells[_dsSet.GoodsSet.SubstColumn.ColumnName].Value != DBNull.Value)
                        {
                            int makerCd;
                            string partsNo;
                            if (activeRow.Band.ParentBand == null) // 親バンドの場合
                            {
                                makerCd = (int)activeRow.Cells[_dsSet.SetMain.MakerCdColumn.ColumnName].Value;
                                partsNo = activeRow.Cells[_dsSet.SetMain.PartsNoColumn.ColumnName].Value.ToString();
                            }
                            else
                            {
                                makerCd = (int)activeRow.Cells[_dsSet.GoodsSet.SetSubMakerCdColumn.ColumnName].Value;
                                partsNo = activeRow.Cells[_dsSet.GoodsSet.SetSubOrgPrtNoColumn.ColumnName].Value.ToString();
                            }
                            PartsInfoDataSet.UsrGoodsInfoRow row =
                                _orgDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(makerCd, partsNo);
                            if (row != null)
                            {
                                //_orgDataSet.UsrGoodsInfo.PreviousActiveRow = row;
                                activeRow.Cells[_dsSet.GoodsSet.SelectionStateColumn.ColumnName].Value = true;
                                _orgDataSet.UsrGoodsInfo.RowToProcess = row;
                                //_prevRow = row;
                                _prevRow = _orgDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(makerCd,
                                       activeRow.Cells[_dsSet.GoodsSet.SetSubPartsNoColumn.ColumnName].Value.ToString());
                                _orgDataSet.UIKind = SelectUIKind.Subst;
                                DialogResult = DialogResult.Retry;
                                isUserClose = false;
                            }
                        }
                    }
                    break;

                // ADD 譚洪 2014/09/01 FOR Redmine#43289 --- >>>
                case "Button_Car":
                    if (this.pnl_CarInfo.Visible == false)
                    {
                        this.pnl_CarInfo.Visible = true;
                    }
                    else
                    {
                        this.pnl_CarInfo.Visible = false;
                    }

                    this.SetPnlCarInfoVisible(this.pnl_CarInfo.Visible);
                    break;
                // ADD 譚洪 2014/09/01 FOR Redmine#43289 --- <<<

                /*case "Button_SubstOff":
                    if (gridSetParts.ActiveRow != null &&
                        gridSetParts.ActiveRow.Cells[_dsSet.GoodsSet.OldPartsNoColumn.ColumnName].Value.Equals(string.Empty) == false)
                    {
                        int makerCd = (int)gridSetParts.ActiveRow.Cells[_dsSet.GoodsSet.SetSubMakerCdColumn.ColumnName].Value;
                        string partsNo = gridSetParts.ActiveRow.Cells[_dsSet.GoodsSet.SetSubPartsNoColumn.ColumnName].Value.ToString();
                        string oldPartsNo = gridSetParts.ActiveRow.Cells[_dsSet.GoodsSet.OldPartsNoColumn.ColumnName].Value.ToString();
                        string setDestNo = gridSetParts.ActiveRow.Cells[_dsSet.GoodsSet.SetSubOrgPrtNoColumn.ColumnName].Value.ToString();
                        SetParts.GoodsSetRow oldRow = _dsSet.GoodsSet.FindBySetSubMakerCdSetSubPartsNo(makerCd, partsNo); // TODO : 見直し
                        PartsInfoDataSet.UsrGoodsInfoRow newRow =
                            _orgDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(makerCd, oldPartsNo);

                        oldRow.OldPartsNo = string.Empty;
                        oldRow.SetSubPartsNo = newRow.GoodsNo;
                        oldRow.SubGoodsName = newRow.GoodsName;
                        oldRow.SetPrice = newRow.Price;
                        oldRow.GenTanka = newRow.UnitCost;
                        oldRow.UriTanka = newRow.SalesUnitPrice;
                        if (newRow.UnitCost != 0)
                            oldRow.Arariritu = oldRow.Ararigaku / newRow.UnitCost;
                        //oldRow.SetSpecialNote = newRow.GoodsSpecialNote;
                        if (SubstExists(setDestNo, makerCd))
                        {
                            oldRow.Subst = IconResourceManagement.ImageList16.Images[(int)Size16_Index.CARADD];
                        }

                        string filter = string.Format("{0}={1} AND {2}='{3}' ",
                            _orgDataSet.Stock.GoodsMakerCdColumn.ColumnName,
                            gridSetParts.ActiveRow.Cells[_dsSet.GoodsSet.SetSubMakerCdColumn.ColumnName].Value,
                            _orgDataSet.Stock.GoodsNoColumn.ColumnName,
                            gridSetParts.ActiveRow.Cells[_dsSet.GoodsSet.SetSubPartsNoColumn.ColumnName].Value);
                        _dsSet.Stock.DefaultView.RowFilter = filter;
                        SetStockGridSelect();
                        if (gridStock.Rows.Count == 0)
                        {
                            oldRow.ShelfNo = string.Empty;
                            oldRow.StockCnt = 0;
                            oldRow.Warehouse = string.Empty;
                        }

                        _orgDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(makerCd, partsNo).SelectionState = false; // 代替解除した部品の選択状態をfalseにする。
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

                        ToolbarsManager.Tools["Button_Subst"].SharedProps.Enabled =
                            (gridSetParts.ActiveRow.Cells[_dsSet.GoodsSet.SubstColumn.ColumnName].Value != System.DBNull.Value);
                        //ToolbarsManager.Tools["Button_SubstOff"].SharedProps.Visible = false;
                        GridSetParts_AfterSelectChange(this, null);
                    }
                    break;*/
            }
        }
        #endregion

        #region [ グリッドイベント処理 ]
        /// <summary>
        /// アクティブ行変更後イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GridSetParts_AfterSelectChange(object sender, AfterSelectChangeEventArgs e)
        {
            if (isSelectChangeDisabled)
                return;
            bool ena = false;
            bool enaSubstOff = false;
            string filter = string.Empty;
            try
            {
                if (gridSetParts.Selected.Rows.Count == 0)
                    return;
                if (gridSetParts.Selected.Rows[0].Activated == false)
                    gridSetParts.Selected.Rows[0].Activate();
                if (gridSetParts.ActiveRow.Band.ParentBand == null)
                {
                    filter = string.Format("{0}={1} AND {2}='{3}'",
                            _orgDataSet.Stock.GoodsMakerCdColumn.ColumnName, _orgRow.GoodsMakerCd,
                            _orgDataSet.Stock.GoodsNoColumn.ColumnName, _orgRow.GoodsNo);
                }
                else
                {
                    ena = (gridSetParts.ActiveRow.Cells[_dsSet.GoodsSet.SubstColumn.ColumnName].Value != System.DBNull.Value);
                    enaSubstOff = (gridSetParts.ActiveRow.Cells[_dsSet.GoodsSet.OldPartsNoColumn.ColumnName].Value.Equals(string.Empty) == false);
                    filter = string.Format("{0}={1} AND {2}='{3}' ",
                            _orgDataSet.Stock.GoodsMakerCdColumn.ColumnName,
                            gridSetParts.ActiveRow.Cells[_dsSet.GoodsSet.SetSubMakerCdColumn.ColumnName].Value,
                            _orgDataSet.Stock.GoodsNoColumn.ColumnName,
                            gridSetParts.ActiveRow.Cells[_dsSet.GoodsSet.SetSubPartsNoColumn.ColumnName].Value);
                }
            }
            finally
            {
                ToolbarsManager.Tools["Button_Subst"].SharedProps.Enabled = ena;
                //ToolbarsManager.Tools["Button_SubstOff"].SharedProps.Visible = enaSubstOff;
                _StockTable.DefaultView.RowFilter = filter;
            }
            SetStockGridSelect();
        }

        /// <summary>
        /// InitializeLayout イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>グリッドのレイアウト初期化処理</br>
        /// </remarks>
        private void GridSetParts_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            // 列幅の自動調整方法
            e.Layout.Override.RowSizing = RowSizing.Fixed;
            e.Layout.Override.AllowColSizing = AllowColSizing.None;
            e.Layout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;

            UltraGridBand band0 = e.Layout.Bands[0];
            band0.Indentation = 0;
            //band0.Override.HeaderPlacement = HeaderPlacement.FixedOnTop;
            band0.Override.RowSelectorWidth = 24;
            band0.UseRowLayout = true;

            ColInfo.SetColInfo(band0, _dsSet.SetMain.SelImageColumn.ColumnName, 2, 0, 1, 4, 16);
            if (substFlg != 0) // 「代替しない」以外
            {
                ColInfo.SetColInfo(band0, _dsSet.SetMain.SubstColumn.ColumnName, 46, 0, 1, 4, 16);
            }
            ColInfo.SetColInfo(band0, _dsSet.SetMain.MakerCdColumn.ColumnName, 3, 0, 3, 2, 25);
            ColInfo.SetColInfo(band0, _dsSet.SetMain.MakerNmColumn.ColumnName, 6, 0, 10, 2, 95);
            ColInfo.SetColInfo(band0, _dsSet.SetMain.PrimePartsNameColumn.ColumnName, 16, 0, 14, 2, 140);
            ColInfo.SetColInfo(band0, _dsSet.SetMain.WarehouseColumn.ColumnName, 30, 0, 4, 2, 40);
            ColInfo.SetColInfo(band0, _dsSet.SetMain.QtyColumn.ColumnName, 34, 0, 4, 2, 40);
            ColInfo.SetColInfo(band0, _dsSet.SetMain.GenTankaColumn.ColumnName, 38, 0, 4, 2, 40);
            ColInfo.SetColInfo(band0, _dsSet.SetMain.ArarirituColumn.ColumnName, 42, 0, 4, 2, 40);

            ColInfo.SetColInfo(band0, _dsSet.SetMain.SetSpecialNoteColumn.ColumnName, 3, 2, 13, 2, 130);
            ColInfo.SetColInfo(band0, _dsSet.SetMain.PartsNoColumn.ColumnName, 16, 2, 10, 2, 100);
            ColInfo.SetColInfo(band0, _dsSet.SetMain.ShelfColumn.ColumnName, 26, 2, 4, 2, 40);
            ColInfo.SetColInfo(band0, _dsSet.SetMain.StockCntColumn.ColumnName, 30, 2, 4, 2, 40);
            ColInfo.SetColInfo(band0, _dsSet.SetMain.PriceColumn.ColumnName, 34, 2, 4, 2, 40);
            ColInfo.SetColInfo(band0, _dsSet.SetMain.UriTankaColumn.ColumnName, 38, 2, 4, 2, 40);
            ColInfo.SetColInfo(band0, _dsSet.SetMain.ArarigakuColumn.ColumnName, 42, 2, 4, 2, 40);

            band0.Columns[_dsSet.SetMain.SelectionStateColumn.ColumnName].Hidden = true;
            band0.Columns[_dsSet.SetMain.CatalogShapeNoColumn.ColumnName].Hidden = true;
            //band0.Columns[_dsSet.SetMain.MakerCdColumn.ColumnName].Hidden = true;
            band0.Columns[_dsSet.SetMain.OldPartsNoColumn.ColumnName].Hidden = true;
            band0.Columns[_dsSet.SetMain.WarehouseCodeColumn.ColumnName].Hidden = true;
            if (substFlg == 0) // 「代替しない」は代替カラムを表示しない。
            {
                band0.Columns[_dsSet.SetMain.SubstColumn.ColumnName].Hidden = true;
            }

            for (int i = 0; i < band0.Columns.Count; i++)
            {
                // 水平表示位置
                if ((band0.Columns[i].DataType == typeof(int)) ||
                   (band0.Columns[i].DataType == typeof(double)) ||
                   (band0.Columns[i].DataType == typeof(Int64)))
                {
                    band0.Columns[i].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                }
                else if (band0.Columns[i].DataType == typeof(Image))
                {
                    band0.Columns[i].CellAppearance.ImageHAlign = Infragistics.Win.HAlign.Center;
                    band0.Columns[i].CellAppearance.ImageVAlign = Infragistics.Win.VAlign.Middle;
                }
                else
                {
                    band0.Columns[i].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                }
                band0.Columns[i].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                // 垂直表示位置
                band0.Columns[i].CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
            }
            band0.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.None;

            band0.Columns[_dsSet.SetMain.MakerCdColumn.ColumnName].Format = "0000";
            band0.Columns[_dsSet.SetMain.PriceColumn.ColumnName].Format = "C";
            band0.Columns[_dsSet.SetMain.GenTankaColumn.ColumnName].Format = "C";
            band0.Columns[_dsSet.SetMain.UriTankaColumn.ColumnName].Format = "C";
            band0.Columns[_dsSet.SetMain.ArarigakuColumn.ColumnName].Format = "C";
            band0.Columns[_dsSet.SetMain.ArarirituColumn.ColumnName].Format = "#%";
            band0.Columns[_dsSet.SetMain.StockCntColumn.ColumnName].Format = "###,###,##0.00";
            band0.Columns[_dsSet.SetMain.QtyColumn.ColumnName].Format = "###,###,##0.00";
            gridSetParts.DisplayLayout.InterBandSpacing = 3;

            // バンドの取得
            UltraGridBand band1 = e.Layout.Bands[1];
            band0.ColHeadersVisible = false;
            band1.Override.HeaderPlacement = HeaderPlacement.FixedOnTop;
            band1.Indentation = 0;
            band1.UseRowLayout = true;
            band1.Override.DefaultRowHeight = 20;
            band1.Override.RowSelectorWidth = 24;

            for (int i = 0; i < band1.Columns.Count; i++)
            {
                // 水平表示位置
                if ((band1.Columns[i].DataType == typeof(int)) ||
                   (band1.Columns[i].DataType == typeof(double)) ||
                   (band1.Columns[i].DataType == typeof(Int64)))
                {
                    band1.Columns[i].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                }
                else if (band1.Columns[i].DataType == typeof(Image))
                {
                    band1.Columns[i].CellAppearance.ImageHAlign = Infragistics.Win.HAlign.Center;
                    band1.Columns[i].CellAppearance.ImageVAlign = Infragistics.Win.VAlign.Middle;
                }
                else
                {
                    band1.Columns[i].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                }
                band1.Columns[i].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                // 垂直表示位置
                band1.Columns[i].CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
            }
            band1.Columns[_dsSet.GoodsSet.CatalogShapeNoColumn.ColumnName].Hidden = true;
            band1.Columns[_dsSet.GoodsSet.SetDisplayOrderColumn.ColumnName].Hidden = true;
            band1.Columns[_dsSet.GoodsSet.SetMainMakerCdColumn.ColumnName].Hidden = true;
            band1.Columns[_dsSet.GoodsSet.SetMainPartsNoColumn.ColumnName].Hidden = true;
            band1.Columns[_dsSet.GoodsSet.SetNameColumn.ColumnName].Hidden = true;
            band1.Columns[_dsSet.GoodsSet.SelectionStateColumn.ColumnName].Hidden = true;
            band1.Columns[_dsSet.GoodsSet.OldPartsNoColumn.ColumnName].Hidden = true;
            band1.Columns[_dsSet.GoodsSet.SetSubOrgPrtNoColumn.ColumnName].Hidden = true;
            band1.Columns[_dsSet.GoodsSet.WarehouseCodeColumn.ColumnName].Hidden = true;
            if (substFlg == 0) // 「代替しない」は代替カラムを表示しない。
            {
                band1.Columns[_dsSet.GoodsSet.SubstColumn.ColumnName].Hidden = true;
            }
            ColInfo.SetColInfo(band1, _dsSet.GoodsSet.SelImageColumn.ColumnName, 2, 0, 1, 4, 16);
            if (substFlg != 0) // 「代替しない」以外
            {
                ColInfo.SetColInfo(band1, _dsSet.GoodsSet.SubstColumn.ColumnName, 46, 0, 1, 4, 16);
            }
            ColInfo.SetColInfo(band1, _dsSet.GoodsSet.SetSubMakerCdColumn.ColumnName, 3, 0, 3, 2, 25);
            ColInfo.SetColInfo(band1, _dsSet.GoodsSet.SetSubMakerNameColumn.ColumnName, 6, 0, 10, 2, 95);
            ColInfo.SetColInfo(band1, _dsSet.GoodsSet.SubGoodsNameColumn.ColumnName, 16, 0, 14, 2, 140);
            ColInfo.SetColInfo(band1, _dsSet.GoodsSet.WarehouseColumn.ColumnName, 30, 0, 4, 2, 40);
            ColInfo.SetColInfo(band1, _dsSet.GoodsSet.SetQtyColumn.ColumnName, 34, 0, 4, 2, 40);
            ColInfo.SetColInfo(band1, _dsSet.GoodsSet.GenTankaColumn.ColumnName, 38, 0, 4, 2, 40);
            ColInfo.SetColInfo(band1, _dsSet.GoodsSet.ArarirituColumn.ColumnName, 42, 0, 4, 2, 40);

            ColInfo.SetColInfo(band1, _dsSet.GoodsSet.SetSpecialNoteColumn.ColumnName, 3, 2, 13, 2, 130);
            ColInfo.SetColInfo(band1, _dsSet.GoodsSet.SetSubPartsNoColumn.ColumnName, 16, 2, 10, 2, 100);
            ColInfo.SetColInfo(band1, _dsSet.GoodsSet.ShelfColumn.ColumnName, 26, 2, 4, 2, 40);
            ColInfo.SetColInfo(band1, _dsSet.GoodsSet.StockCntColumn.ColumnName, 30, 2, 4, 2, 40);
            ColInfo.SetColInfo(band1, _dsSet.GoodsSet.SetPriceColumn.ColumnName, 34, 2, 4, 2, 40);
            ColInfo.SetColInfo(band1, _dsSet.GoodsSet.UriTankaColumn.ColumnName, 38, 2, 4, 2, 40);
            ColInfo.SetColInfo(band1, _dsSet.GoodsSet.ArarigakuColumn.ColumnName, 42, 2, 4, 2, 40);

            band1.Columns[_dsSet.GoodsSet.SetSubMakerCdColumn.ColumnName].Format = "0000";
            band1.Columns[_dsSet.GoodsSet.SetPriceColumn.ColumnName].Format = "C";
            band1.Columns[_dsSet.GoodsSet.GenTankaColumn.ColumnName].Format = "C";
            band1.Columns[_dsSet.GoodsSet.UriTankaColumn.ColumnName].Format = "C";
            band1.Columns[_dsSet.GoodsSet.ArarigakuColumn.ColumnName].Format = "C";
            band1.Columns[_dsSet.GoodsSet.ArarirituColumn.ColumnName].Format = "#%";
            band1.Columns[_dsSet.GoodsSet.StockCntColumn.ColumnName].Format = "###,###,##0.00";
            band1.Columns[_dsSet.GoodsSet.SetQtyColumn.ColumnName].Format = "###,###,##0.00";
        }

        /// <summary>
        /// 行をダブルクリックされた場合は、その行を選択する。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// データが表示されていない行をダブルクリックしても本イベントは発生しない。
        /// </remarks>
        private void GridSetParts_DoubleClickRow(object sender, DoubleClickRowEventArgs e)
        {
            SetSelect(false);
        }

        /// <summary>
        /// グリッド上でEnterキーが押された場合は、その行を選択する。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GridSetParts_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Down:
                    if (gridSetParts.ActiveRow != null && gridSetParts.ActiveRow.ParentRow == null) // 親バンドか
                    {
                        gridSetParts.ActiveRow.ChildBands[0].Rows[0].Activate();
                        gridSetParts.ActiveRow.Selected = true;
                        e.Handled = true;
                    }
                    break;

                case Keys.Up:
                    if (gridSetParts.ActiveRow != null && gridSetParts.ActiveRow.ParentRow != null // 子バンドか
                        && gridSetParts.ActiveRow.Index == 0)
                    {
                        gridSetParts.Rows[0].Activate();
                        gridSetParts.ActiveRow.Selected = true;
                        e.Handled = true;
                    }
                    break;

                case Keys.Enter:
                    SetSelect(true);
                    break;

                case Keys.PageDown:
                    if (gridSetParts.ActiveRow != null && gridSetParts.ActiveRow.Band.ParentBand == null)
                    {
                        gridSetParts.ActiveRow.ChildBands[0].Rows[0].Activate();
                        gridSetParts.ActiveRow.Selected = true;
                        GridSetParts_KeyDown(sender, e);
                    }
                    break;
            }
        }

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
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/26 ADD
            band.Columns[_StockTable.SortDivColumn.ColumnName].Hidden = true;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/26 ADD
            for (int i = 0; i < band.Columns.Count; i++)
            {
                // 水平表示位置
                if ((band.Columns[i].DataType == typeof(int)) ||
                   (band.Columns[i].DataType == typeof(double)))
                {
                    band.Columns[i].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                }
                else if (band.Columns[i].DataType == typeof(Image))
                {
                    band.Columns[i].CellAppearance.ImageHAlign = Infragistics.Win.HAlign.Center;
                    band.Columns[i].CellAppearance.ImageVAlign = Infragistics.Win.VAlign.Middle;
                }
                else
                {
                    band.Columns[i].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                }
                band.Columns[i].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                // 垂直表示位置
                band.Columns[i].CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
            }
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/26 ADD
            ColInfo.SetColInfo( band, _StockTable.SelImageColumn.ColumnName, 0, 0, 10 );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/26 ADD
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
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/30 DEL
            //if (gridStock.ActiveRow != null && gridSetParts.ActiveRow != null)// && gridSetParts.ActiveRow.Band.ParentBand != null)
            //{
            //    gridSetParts.ActiveRow.Cells[_dsSet.GoodsSet.WarehouseColumn.ColumnName].Value
            //        = gridStock.ActiveRow.Cells[_StockTable.WarehouseNameColumn.ColumnName].Value;
            //    gridSetParts.ActiveRow.Cells[_dsSet.GoodsSet.ShelfColumn.ColumnName].Value
            //        = gridStock.ActiveRow.Cells[_StockTable.WarehouseShelfNoColumn.ColumnName].Value;
            //    gridSetParts.ActiveRow.Cells[_dsSet.GoodsSet.StockCntColumn.ColumnName].Value
            //        = gridStock.ActiveRow.Cells[_StockTable.ShipmentPosCntColumn.ColumnName].Value;
            //    gridSetParts.ActiveRow.Cells[_dsSet.GoodsSet.WarehouseCodeColumn.ColumnName].Value
            //        = gridStock.ActiveRow.Cells[_StockTable.WarehouseCodeColumn.ColumnName].Value;
            //    gridStock.ActiveRow.Cells[_StockTable.SelectionStateColumn.ColumnName].Value = true;
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/30 DEL
        }

        private void gridStock_BeforeSelectChange(object sender, BeforeSelectChangeEventArgs e)
        {
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/30 DEL
            //if (gridStock.Selected.Rows.Count > 0)
            //    gridStock.Selected.Rows[0].Cells[_StockTable.SelectionStateColumn.ColumnName].Value = false;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/30 DEL
        }
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/27 ADD
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
                if ( gridSetParts.ActiveRow != null )
                {
                    if ( (bool)activeCells[_StockTable.SelectionStateColumn.ColumnName].Value == true )
                    {
                        // 部品グリッドに在庫情報表示
                        gridSetParts.ActiveRow.Cells[_dsSet.GoodsSet.WarehouseColumn.ColumnName].Value
                            = gridStock.ActiveRow.Cells[_StockTable.WarehouseNameColumn.ColumnName].Value;
                        gridSetParts.ActiveRow.Cells[_dsSet.GoodsSet.ShelfColumn.ColumnName].Value
                            = gridStock.ActiveRow.Cells[_StockTable.WarehouseShelfNoColumn.ColumnName].Value;
                        gridSetParts.ActiveRow.Cells[_dsSet.GoodsSet.StockCntColumn.ColumnName].Value
                            = gridStock.ActiveRow.Cells[_StockTable.ShipmentPosCntColumn.ColumnName].Value;
                        gridSetParts.ActiveRow.Cells[_dsSet.GoodsSet.WarehouseCodeColumn.ColumnName].Value
                            = gridStock.ActiveRow.Cells[_StockTable.WarehouseCodeColumn.ColumnName].Value;
                    }
                    else
                    {
                        // 部品グリッドの在庫情報をクリア
                        gridSetParts.ActiveRow.Cells[_dsSet.GoodsSet.WarehouseColumn.ColumnName].Value = string.Empty;
                        gridSetParts.ActiveRow.Cells[_dsSet.GoodsSet.ShelfColumn.ColumnName].Value = string.Empty;
                        gridSetParts.ActiveRow.Cells[_dsSet.GoodsSet.StockCntColumn.ColumnName].Value = 0;
                        gridSetParts.ActiveRow.Cells[_dsSet.GoodsSet.WarehouseCodeColumn.ColumnName].Value = string.Empty;
                    }
                    gridSetParts.UpdateData();
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
        #endregion

        /// <summary>
        /// Enterキー(ダブルクリック)による選択処理
        /// </summary>
        /// <param name="moveFlg">true:次の行を選択状態に／false:なにもしない（マウスダブルクリック時）</param>
        private void SetSelect(bool moveFlg)
        {
            UltraGridRow activeRow = gridSetParts.ActiveRow;
            if (gridSetParts.Selected.Rows.Count > 0 && activeRow != gridSetParts.Selected.Rows[0])
            {
                gridSetParts.Selected.Rows[0].Activate();
                activeRow = gridSetParts.ActiveRow;
            }
            if (activeRow != null)
            {
                UltraGridCell cell = activeRow.Cells[_dsSet.GoodsSet.SelImageColumn.ColumnName];

                if (cell.Value != DBNull.Value)
                {
                    if (uiControlFlg == false || enterFlg != 2) // （PM.NS式制御でEnterキーが「次画面」）以外か
                    {
                        cell.Value = DBNull.Value;
                        activeRow.Cells["SelectionState"].Value = false;
                    }
                }
                else
                {
                    if (activeRow.ParentRow == null) // セット親品か
                    {
                        isSelectChangeDisabled = true;
                        foreach (UltraGridRow row in gridSetParts.Rows[0].ChildBands[0].Rows)
                        {
                            row.Cells[_dsSet.GoodsSet.SelImageColumn.ColumnName].Value = DBNull.Value; // 親品の選択状態を解除
                            row.Cells["SelectionState"].Value = false;
                        }
                        isSelectChangeDisabled = false;
                    }
                    else // セット子品か
                    {
                        isSelectChangeDisabled = true;
                        gridSetParts.Rows[0].Cells[_dsSet.SetMain.SelImageColumn.ColumnName].Value = DBNull.Value; // 親品の選択状態を解除
                        gridSetParts.Rows[0].Cells["SelectionState"].Value = false;
                        isSelectChangeDisabled = false;
                    }
                    cell.Value = IconResourceManagement.ImageList24.Images[(int)Size24_Index.ITEMCHECK];
                    activeRow.Cells["SelectionState"].Value = true;
                }

                switch (enterFlg)
                {
                    case 2: // Enterキーが「次画面」の場合
                        if (gridSetParts.Rows[0].Equals(activeRow) == false
                        && gridSetParts.Rows[0].Cells[_dsSet.SetMain.SelImageColumn.ColumnName].Value != DBNull.Value)
                        {
                            gridSetParts.Rows[0].Cells[_dsSet.SetMain.SelImageColumn.ColumnName].Value = DBNull.Value;
                            gridSetParts.Rows[0].Cells[_dsSet.SetMain.SelectionStateColumn.ColumnName].Value = false;
                            _selInf.ListPlrlSubst.Clear();
                        }
                        foreach (UltraGridRow row in gridSetParts.Rows[0].ChildBands[0].Rows) // 選択行以外は選択解除する
                        {
                            if (row.Equals(activeRow) == false && row.Cells[_dsSet.GoodsSet.SelImageColumn.ColumnName].Value != DBNull.Value)
                            {
                                row.Cells[_dsSet.GoodsSet.SelImageColumn.ColumnName].Value = DBNull.Value;
                                row.Cells[_dsSet.GoodsSet.SelectionStateColumn.ColumnName].Value = false;
                                if (_lstSelInf.ContainsKey(row.ListIndex))
                                {
                                    _lstSelInf.Remove(row.ListIndex);
                                }
                            }
                        }
                        if (uiControlFlg)
                        {
                            DialogResult = DialogResult.Ignore; // 残りの画面を無視し選択確定する。
                        }
                        else
                        {
                            DialogResult = DialogResult.OK;
                        }
                        break;
                    default: // Enterキーが「選択」「PM7」の場合：複数選択動作のため次行を選択状態とする。                        
                        if (moveFlg)
                        {
                            if (activeRow.Band.ParentBand == null) // 親バンドか
                            {
                                activeRow.ChildBands[0].Rows[0].Activate();
                                activeRow.ChildBands[0].Rows[0].Selected = true;
                            }
                            else
                            {
                                UltraGridRow ugr = activeRow.GetSibling(SiblingRow.Next);
                                if (ugr != null)
                                {
                                    ugr.Activate();
                                    ugr.Selected = true;
                                }
                            }
                        }
                        break;
                }
                gridSetParts.UpdateData();

            }
        }

        /// <summary>
        /// 在庫グリッド選択処理（ユーザー選択→優先倉庫→先頭行の順で選択）
        /// </summary>
        private void SetStockGridSelect()
        {
            if (gridSetParts.ActiveRow.Cells[_dsSet.GoodsSet.WarehouseCodeColumn.ColumnName].Value.Equals(string.Empty) == false)
            {
                for (int i = 0; i < gridStock.Rows.Count; i++)
                {
                    if (gridStock.Rows[i].Cells[_StockTable.WarehouseCodeColumn.ColumnName].Value
                        .Equals(gridSetParts.ActiveRow.Cells[_dsSet.GoodsSet.WarehouseCodeColumn.ColumnName].Value))
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
                // 該当がなければ先頭行へフォーカスセット
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

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/30 DEL
            //if (_orgDataSet.ListPriorWarehouse != null)
            //{
            //    for (int i = 0; i < _orgDataSet.ListPriorWarehouse.Count; i++)
            //    {
            //        // 2009.02.16 >>>
            //        //string warehouseCd = _orgDataSet.ListPriorWarehouse[i];
            //        string warehouseCd = _orgDataSet.ListPriorWarehouse[i].Trim();
            //        // 2009.02.16 <<<
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
            //    gridSetParts.ActiveRow.Cells[_dsSet.GoodsSet.WarehouseColumn.ColumnName].Value = string.Empty;
            //    gridSetParts.ActiveRow.Cells[_dsSet.GoodsSet.ShelfColumn.ColumnName].Value = string.Empty;
            //    gridSetParts.ActiveRow.Cells[_dsSet.GoodsSet.StockCntColumn.ColumnName].Value = 0;
            //    gridSetParts.ActiveRow.Cells[_dsSet.GoodsSet.WarehouseCodeColumn.ColumnName].Value = string.Empty;
            //    gridSetParts.UpdateData();
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/30 DEL
        }

        /// <summary>
        /// ステータスバー設定
        /// </summary>
        /// <param name="mode">0:黒字　1:赤字</param>
        /// <param name="msg">設定するメッセージ</param>
        private void SetStatusBarText(int mode, string msg)
        {
            StatusBar.Panels[0].Text = msg;
            switch (mode)
            {
                case 0: // 0:黒字
                    StatusBar.Panels[0].Appearance.Reset();
                    break;
                case 1: // 1:赤字
                    StatusBar.Panels[0].Appearance.ForeColor = Color.Red;
                    StatusBar.Panels[0].Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                    break;
            }
        }

        #region [ Utility Class ]
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
                sizeHeader.Height = 20;
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
                sizeHeader.Height = 20;
                sizeHeader.Width = width;
                Band.Columns[colname].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            }
        }
        #endregion

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
                // 強制的に部品グリッドに移動する
                gridSetParts.Focus();
            }
        }
        // --- ADD m.suzuki 2010/10/26 ----------<<<<<

        // ADD 譚洪 2014/09/01 FOR Redmine#43289 --- >>>
        /// <summary>
        /// 車両情報を表示切替処理
        /// </summary>
        private void SetPnlCarInfoVisible(bool carInfoVisible)
        {
            if (carInfoVisible)
            {
                this.gridSetParts.Location = new System.Drawing.Point(0, this.pnl_CarInfo.Height);
                // --- ADD 2014/11/04 T.Miyamoto 仕掛一覧 №2577 ------------------------------>>>>>
                this.gridSetParts.Height = this.SelectionForm_Fill_Panel.Height - this.pnl_CarInfo.Height;
                // --- ADD 2014/11/04 T.Miyamoto 仕掛一覧 №2577 ------------------------------<<<<<
            }
            else
            {
                this.gridSetParts.Location = new System.Drawing.Point(0, 0);
                // --- UPD 2014/11/04 T.Miyamoto 仕掛一覧 №2577 ------------------------------>>>>>
                //this.gridSetParts.Height = this.gridSetParts.Height + this.pnl_CarInfo.Height;
                this.gridSetParts.Height = this.SelectionForm_Fill_Panel.Height;
                // --- UPD 2014/11/04 T.Miyamoto 仕掛一覧 №2577 ------------------------------<<<<<
            }
        }
        // ADD 譚洪 2014/09/01 FOR Redmine#43289 --- <<<

        // ADD 譚洪 2014/09/01 FOR Redmine#43289　--- >>>
        /// <summary>
        /// XMLファイルを保存処理
        /// </summary>
        /// <param name="carInfoFlg">車両情報ボタン表示フラグ</param>
        /// <param name="fileName">ファイル名</param>
        /// <remarks>
        /// <br>Note       : XMLファイルを保存処理を行います。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2014/09/01</br>
        /// </remarks>
        private void Serialize(bool carInfoFlg, string fileName)
        {
            UserSettingController.SerializeUserSetting(carInfoFlg, Path.Combine(ConstantManagement_ClientDirectory.UISettings, fileName));
        }


        /// <summary>
        /// XMLファイルを読み処理
        /// </summary>
        /// <param name="fileName">ファイル名</param>
        /// <remarks>
        /// <br>Note       : XMLファイルを読み処理を行います。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2014/09/01</br>
        /// </remarks>
        private bool Deserialize(string fileName)
        {
            bool carInfoFlg = false;

            if (UserSettingController.ExistUserSetting(Path.Combine(ConstantManagement_ClientDirectory.UISettings, fileName)))
            {
                try
                {
                    carInfoFlg = UserSettingController.DeserializeUserSetting<bool>(Path.Combine(ConstantManagement_ClientDirectory.UISettings, fileName));
                }
                catch (System.InvalidOperationException)
                {
                    UserSettingController.DeleteUserSetting(Path.Combine(ConstantManagement_ClientDirectory.UISettings, fileName));
                }
            }

            return carInfoFlg;
        }

        /// <summary>
        /// 和暦年取得処理（H20の"20"のみを取得する）
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        private static int GetDateFW(int date)
        {
            // 和暦略号を取得
            string date_gg = TDateTime.LongDateToString("gg", date);  // H
            string date_exggyy = TDateTime.LongDateToString("exggyy", date);  // H20

            // "H20" から "H" を取り除いて "20" を取得する
            return ToInt(date_exggyy.Substring(date_gg.Length, date_exggyy.Length - date_gg.Length));

        }

        /// <summary>
        /// 数値変換処理
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        private static int ToInt(string text)
        {
            try
            {
                return Int32.Parse(text);
            }
            catch
            {
                return 0;
            }
        }
        // ADD 譚洪 2014/09/01 FOR Redmine#43289　--- <<<
    }
}
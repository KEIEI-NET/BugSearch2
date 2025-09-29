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
    /// <br>             : 在庫の選択方法をチェック方式に変更（未チェックで取寄を選択可能に変更）</br>
    /// <br>Programmer	: 22018　鈴木 正臣</br>
    /// <br>Date		: 2009.03.27</br>
    /// <br></br>
    /// <br>Update Note	: 結合元部品≠表示部品が1件の場合にカタログ品番の結合情報が表示されない不具合の修正</br>
    /// <br>Programmer	: 21024　佐々木 健</br>
    /// <br>Date		: 2009/09/29</br>
    /// <br></br>
    /// <br>Update Note	: SCM自動回答対応</br>
    /// <br>Programmer	: 21024　佐々木 健</br>
    /// <br>Date		: 2010/03/16</br>
    /// <br></br>
    /// <br>Update Note	: 障害改良対応（８月分）（※武生自動車部品 対応）</br>
    /// <br>             :   ・在庫ゼロ件の場合は、在庫グリッドにフォーカス移動しないように変更。</br>
    /// <br>Programmer	: 22018　鈴木 正臣</br>
    /// <br>Date		: 2010/10/26</br>
    /// <br></br>
    /// <br>Update Note	:liyp 2010/12/03  障害改良対応（１２月分）</br>
    /// <br>             結合初期表示区分が「在庫順」の場合のソート列の変更を行う</br>
    /// <br></br>
    /// <br>Update Note	: 障害対応</br>
    /// <br>            :   「結合初期表示区分：在庫順」にした場合、QTYが正常にセットされない件の対応</br>
    /// <br>Programmer	: 20056　對馬 大輔</br>
    /// <br>Date		: 2010/12/09</br>
    /// <br></br>
    /// <br>Update Note	: 障害改良対応（ｘｘ月）</br>
    /// <br>             :   ・代替制御をＰＭ７準拠の動作に修正。</br>
    /// <br>                   （代替元の在庫があれば、代替しない。(※結合選択からの代替はユーザー代替のみ)）</br>
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
    /// <br></br>
    /// <br>UpdateNote   : 2012/12/11 zhuhh</br>
    /// <br>管理番号     : 10806793-00　2013/03/13配信分</br>
    /// <br>             : redmine #33834 結合選択画面の修正</br>
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
    /// <br>Update Note  : SCM障害№10462対応</br>
    /// <br>             :   ・ツールバーの確定ボタン(F10)押下時に選択状態の行が有効にならない障害の対応</br>
    /// <br>Programmer   : 30744  湯上 千加子</br>
    /// <br>Date         : 2013/01/11</br>
    /// <br></br>
    /// <br>Update Note: 2015/12/18 脇田 靖之</br>
    /// <br>管理番号   : 11170207-00 仕掛一覧 №2810</br>
    /// <br>           : 特記事項が表示されない障害の対応</br>
    /// </remarks>
    public partial class SelectionFormJ : Form
    {
        #region [ Private Member Variable ]
        /// <summary>データセット</summary>
        private PartsInfoDataSet _orgDataSet = null;
        private PartsInfoDataSet.UsrJoinPartsDataTable _orgUsrJoin = null;
        /// <summary>処理するロー（提供純正部品又はユーザー登録部品）</summary>
        private PartsInfoDataSet.UsrGoodsInfoRow _orgRow = null;
        // 2009/09/29 Add >>>
        /// <summary>最新品番の部品情報</summary>
        private PartsInfoDataSet.UsrGoodsInfoRow _newPartsRow = null;
        // 2009/09/29 Add <<<
        private PartsInfoDataSet.UsrGoodsInfoRow _prevRow = null;
        /// <summary>結合の元が提供純正部品の場合その純正部品情報を持つロー</summary>
        private PartsInfoDataSet.PartsInfoRow _partsInfoRow = null;
        private dsParts _joinParts = null;
        private dsParts.StockDataTable _StockTable = null;
        //public dsParts JoinParts
        //{
        //    get
        //    {
        //        return _joinParts;
        //    }
        //}
        //private bool orgRowChged = false;
        private string _clgPartsNo; // カタログ品番(結合元品番)
        private string _newPartsNo; // 最新品番
        //private string _selectedPartsNo; // 選択品番
        private int _makerCd;

        // 2010/03/16 Add >>>
        /// <summary>
        /// モード(0:通常,1:結合全選択)
        /// </summary>
        private int _mode;
        // 2010/03/16 Add <<<

        private bool isUserClose = true;

        #region [ 表示オプション関連変数 ]
        /// <summary>UI制御方式　[false:PM7スタイル　　true:PM.NSスタイル]</summary> 
        private bool uiControlFlg;      // false:PM7スタイル　　true:PM.NSスタイル
        private int substFlg;           // 0:代替しない  1:代替する（在庫判定あり） 2:代替する（在庫判定なし）
        private int userSubstFlg;
        private int enterFlg;           // 0:PM7, 1:選択 2:次画面（純正⇒結合、結合⇒セット、セット⇒確定）
        private int displayOrder;       // 0:表示順 1:在庫順
        private int totalAmountDispWay;       // 総額表示方法区分 0:総額表示しない（税抜き）,1:総額表示する（税込み）

        #endregion
        private bool isDialogShown = true;

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

        /// <summary> ダイアログが表示可否フラグ（データ数により自動判定） </summary>
        public bool IsDialogShown
        {
            get { return isDialogShown; }
        }

        /// <summary> 結合先品番の選択リスト </summary>
        private Dictionary<int, SelectionInfo> _lstSelInf;
        /// <summary> 結合元品番の選択情報 </summary>
        private SelectionInfo _selInf;
        private SelectionInfo _prevSelInfo;
        #endregion

        #region [ Constructor ]
        /// <summary>
        /// 選択画面コンストラクタ
        /// </summary>
        /// <param name="dsSource">グリッドに表示するデータを指定します。</param>
        public SelectionFormJ(PartsInfoDataSet dsSource)
        {
            _orgDataSet = dsSource;
            _orgUsrJoin = dsSource.UsrJoinParts;
            //_prevRow = _orgRow;
            _orgRow = dsSource.UsrGoodsInfo.RowToProcess;
            // 2009/09/29 Add >>>
            _newPartsRow = _orgRow;
            // 2009/09/29 Add <<<
            SearchCntSetWork cond = dsSource.SearchCondition.SearchCntSetWork;
            uiControlFlg = Convert.ToBoolean(cond.SearchUICntDivCd); // 0:PM7スタイル／1:PM.NSスタイル
            substFlg = cond.PrmSubstCondDivCd; // 0:代替しない  1:代替する（在庫判定あり） 2:代替する（在庫判定なし）
            userSubstFlg = cond.SubstApplyDivCd;
            enterFlg = cond.EnterProcDivCd; // 0:PM7, 1:選択 2:次画面（純正⇒結合、結合⇒セット、セット⇒確定）
            displayOrder = cond.JoinInitDispDiv; // 0:表示順 1:在庫順
            totalAmountDispWay = cond.TotalAmountDispWayCd; // 0:総額表示しない（税抜き）,1:総額表示する（税込み）
            //////////////////////////////

            InitializeComponent();
            InitializeForm();
            InitializeTable();

            //ToolbarsManager.Tools["Button_SubstOff"].SharedProps.Visible = false;
        }

        // 2010/03/16 Add >>>
        /// <summary>
        /// 選択画面コンストラクタ（画面表示無し)
        /// </summary>
        /// <param name="dsSource">データソース</param>
        /// <param name="mode">0:通常 1:結合全選択</param>
        public SelectionFormJ(PartsInfoDataSet dsSource, int mode)
        {
            _orgDataSet = dsSource;
            _orgUsrJoin = dsSource.UsrJoinParts;
            _orgRow = dsSource.UsrGoodsInfo.RowToProcess;
            _newPartsRow = _orgRow;
            _orgDataSet = dsSource;
            _orgUsrJoin = dsSource.UsrJoinParts;
            //_prevRow = _orgRow;
            _orgRow = dsSource.UsrGoodsInfo.RowToProcess;
            // 2009/09/29 Add >>>
            _newPartsRow = _orgRow;
            // 2009/09/29 Add <<<
            SearchCntSetWork cond = dsSource.SearchCondition.SearchCntSetWork;
            uiControlFlg = Convert.ToBoolean(cond.SearchUICntDivCd); // 0:PM7スタイル／1:PM.NSスタイル
            substFlg = cond.PrmSubstCondDivCd; // 0:代替しない  1:代替する（在庫判定あり） 2:代替する（在庫判定なし）
            userSubstFlg = cond.SubstApplyDivCd;
            enterFlg = cond.EnterProcDivCd; // 0:PM7, 1:選択 2:次画面（純正⇒結合、結合⇒セット、セット⇒確定）
            displayOrder = cond.JoinInitDispDiv; // 0:表示順 1:在庫順
            totalAmountDispWay = cond.TotalAmountDispWayCd; // 0:総額表示しない（税抜き）,1:総額表示する（税込み）

            this.InitializeTable2();
        }
        // 2010/03/16 Add <<<
        #endregion

        #region [ イニシャル処理 ]
        private void InitializeForm()
        {
            // ステータスバーの初期化
            StatusBar.Panels[0].Text = "";
            // ツールバーのイメージ(16x16)やメッセージを設定する
            ToolbarsManager.ImageListSmall = IconResourceManagement.ImageList16;
            ToolbarsManager.Tools["Button_Select"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.DECISION;
            ToolbarsManager.Tools["Button_Back"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.BEFORE;
            if (uiControlFlg)
            {
                ToolbarsManager.Tools["Button_Set"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.MODEL;
            }
            else
            {
                ToolbarsManager.Tools["Button_Set"].SharedProps.Visible = false;
            }
            if (substFlg != 0)
            {
                ToolbarsManager.Tools["Button_Subst"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CARADD;
                //ToolbarsManager.Tools["Button_SubstOff"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.UNDO;
            }
            else
            {
                ToolbarsManager.Tools["Button_Subst"].SharedProps.Visible = false;
            }
        }

        /// <summary>
        /// テーブル作成及びデータセットへの追加、リレーション設定
        /// </summary>
        /// <br>Update Note :liyp 2010/12/03</br>
        /// <br>             結合初期表示区分が「在庫順」の場合のソート列の変更を行う</br>
        /// <br>UpdateNote   : 2012/12/11 zhuhh</br>
        /// <br>管理番号     : 10806793-00　2013/03/13配信分</br>
        /// <br>             : redmine #33834 結合選択画面の修正</br>
        private void InitializeTable()
        {
            _orgRow = _orgDataSet.UsrGoodsInfo.RowToProcess;
            //_prevRow = _orgDataSet.UsrGoodsInfo.PreviouslyProcessedRow;

            // 純正部品情報取得処理
            PartsInfoDataSet.PartsInfoRow[] childRows = (PartsInfoDataSet.PartsInfoRow[])_orgRow.GetChildRows("UsrGoodsInfo_PartsInfo");
            if (childRows.Length > 0)
            {
                _partsInfoRow = childRows[0];
            }
            //if (_partsInfoRow != null)
            //{
            //    _clgPartsNo = _partsInfoRow.ClgPrtsNoWithHyphen;
            //    _newPartsNo = _partsInfoRow.NewPrtsNoWithHyphen;
            //    _selectedPartsNo = _orgDataSet.GoodsNoSel;
            //    _makerCd = _partsInfoRow.CatalogPartsMakerCd;
            //    if (_clgPartsNo != _newPartsNo &&
            //        ((_orgRow.NewGoodsNo != _clgPartsNo && _orgRow.NewGoodsNo != _selectedPartsNo) // カタログ品番以外に代替した場合
            //        //(_orgRow.NewGoodsNo != _clgPartsNo // カタログ品番以外に代替した場合
            //        || _selectedPartsNo == _clgPartsNo)) // カタログ品番に代替した場合
            //    { // NewGoodsNoは純正部品選択UIでの代替などによる処理のため使う。
            //        _newPartsNo = _clgPartsNo;
            //        _orgRow = _orgDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(_makerCd, _newPartsNo);
            //        orgRowChged = true; // このフラグでInitializeTableがShowDialogで2回目実行されることを防ぐ
            //    }
            //    else
            //    {
            //        orgRowChged = false;
            //    }
            //}
            //else
            //{
            _clgPartsNo = _orgRow.GoodsNo;
            if (_orgRow.NewGoodsNo == string.Empty)
                _newPartsNo = _clgPartsNo;
            else
                _newPartsNo = _orgRow.NewGoodsNo;
            _makerCd = _orgRow.GoodsMakerCd;
            //}

            // 2009/09/29 Add >>>
            // 最新品番の情報設定
            _newPartsRow = ( _newPartsNo != _clgPartsNo ) ? _orgDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(_makerCd, _newPartsNo) : _newPartsRow = _orgRow;

            // 通常ありえない
            if (_newPartsRow == null) _newPartsRow = _orgRow;
            // 2009/09/29 Add <<<

            // 2010/03/16 >>>
            //InitializeData();
            InitializeData(true);
            // 2010/03/16 <<<

            // 2010/03/16 Add >>>
            gridJoinParts.DataSource = _joinParts.PartsInfo.DefaultView;

            gridStock.DataSource = _StockTable.DefaultView;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/26 ADD
            SettingStockView(_StockTable.DefaultView);
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/26 ADD

            if (displayOrder == 1) // 1:在庫順か
            {
                //gridJoinParts.Rows[0].ChildBands[0].Band.SortedColumns.Add(_joinParts.JoinParts.StockCntColumn.ColumnName, true);
                gridJoinParts.DisplayLayout.Bands[1].SortedColumns.Add(_joinParts.JoinParts.StockCntColumn.ColumnName, true);
            }
            else
            {
                gridJoinParts.DisplayLayout.Bands[1].SortedColumns.Add(_joinParts.JoinParts.JoinDispOrderColumn.ColumnName, false);
            }

            Infragistics.Win.Appearance app = new Infragistics.Win.Appearance();
            //app.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
            app.ForeColor = Color.Red;
            // ----- ADD zhuhh 2012/12/11 for Redmine #33834 ----->>>>>
            Infragistics.Win.Appearance app2 = new Infragistics.Win.Appearance();
            app2.BackColor = Color.Cyan;
            bool flag = false;
            // ----- ADD zhuhh 2012/12/11 for Redmine #33834 -----<<<<<

            for (int i = 0; i < gridJoinParts.Rows[0].ChildBands[0].Rows.Count; i++)
            {
                string joinSrcPartsNo = gridJoinParts.Rows[0].ChildBands[0].Rows[i].Cells[_joinParts.JoinParts.JoinSourPartsNoColumn.ColumnName].Text;
                if (_clgPartsNo != _newPartsNo && _newPartsNo == joinSrcPartsNo)
                {
                    gridJoinParts.Rows[0].ChildBands[0].Rows[i].Cells[_joinParts.JoinParts.JoinDestPartsNoColumn.ColumnName].Appearance = app;
                    gridJoinParts.Rows[0].ChildBands[0].Rows[i].Cells[_joinParts.JoinParts.JoinDestPartsNoColumn.ColumnName].SelectedAppearance = app;   
                }
                // ----- ADD zhuhh 2012/12/11 for Redmine #33834 ----->>>>>
                if (_clgPartsNo == joinSrcPartsNo && _newPartsNo != joinSrcPartsNo) 
                {
                    gridJoinParts.Rows[0].ChildBands[0].Rows[i].Cells[_joinParts.JoinParts.JoinSourPartsNoColumn.ColumnName].Appearance = app2;
                    flag = true;  
                }
                // ----- ADD zhuhh 2012/12/11 for Redmine #33834 -----<<<<<
            }
            if (flag) gridJoinParts.Rows[0].Appearance = app2;//ADD zhuhh 2012/12/11 for Redmine #33834
            // 2010/03/16 Add <<<

            // --------------- ADD 2010/12/03 -----------------<<<<<
            if (displayOrder == 1) // 1:在庫順か
            {
                gridJoinParts.Rows[0].ChildBands[0].Band.Columns[_joinParts.JoinParts.WarehouseCodeColumn.ColumnName].SortIndicator = SortIndicator.Descending;
                gridJoinParts.Rows[0].ChildBands[0].Band.Columns[_joinParts.JoinParts.StockCntColumn.ColumnName].SortIndicator = SortIndicator.Descending;
                gridJoinParts.Rows[0].ChildBands[0].Band.SortedColumns.Add(_joinParts.JoinParts.WarehouseCodeColumn.ColumnName, true); 
                gridJoinParts.Rows[0].ChildBands[0].Band.SortedColumns.Add(_joinParts.JoinParts.StockCntColumn.ColumnName, true);
            }
            // --------------- ADD 2010/12/03 ----------------->>>>>

            // 先頭行を選択状態にする
            //gridJoinParts.Rows[0].Activate();
            //gridJoinParts.Rows[0].Selected = true;
            gridJoinParts.Rows[0].ExpandAll();
            gridJoinParts.Rows[0].Fixed = true;
        }

        /// <summary>
        /// コントローラのデータセットよりローカルデータセットへのデータコピー
        /// </summary>
        /// <remarks>
        /// <br>Update Note: 2015/12/18 脇田 靖之</br>
        /// <br>管理番号   : 11170207-00 仕掛一覧 №2810</br>
        /// <br>           : 特記事項が表示されない障害の対応</br>
        /// </remarks>
        // 2010/03/16 >>>
        //private void InitializeData()
        private void InitializeData(bool setPrice)
        // 2010/03/16 <<<
        {
            // 2010/03/16 >>>
            //// 2009.02.10 Add >>>
            //this.SettingPriceTargetData();
            //// 2009.02.10 Add <<<

            if (setPrice)
            {
                this.SettingPriceTargetData();
            }
            // 2010/03/16 <<<
            _joinParts = new dsParts();
            _StockTable = _joinParts.Stock;

            #region [ 結合元品設定 ]
            dsParts.PartsInfoRow row = _joinParts.PartsInfo.NewPartsInfoRow();
            row.ClgPrtsNo = _orgRow.GoodsNo;
            row.MakerCd = _orgRow.GoodsMakerCd;
            row.MakerName = _orgRow.GoodsMakerNm;

            // 2009/09/29 価格情報は最新部品の情報を表示する >>>
            //if ((_orgRow.OfferKubun == 1 || _orgRow.OfferKubun == 3) &&  // セット親が純正か
            //    _orgRow.SearchPartsFullName != string.Empty)
            //{
            //    row.PartsName = _orgRow.SearchPartsFullName;
            //}
            //else if (_orgRow.GoodsName != string.Empty)
            //{
            //    row.PartsName = _orgRow.GoodsName;
            //}
            //else
            //{
            //    row.PartsName = _orgRow.GoodsOfrName;
            //}

            //if (totalAmountDispWay == 1) // 総額表示する（税込み）
            //{
            //    row.Price = _orgRow.PriceTaxInc;
            //    row.UriTanka = _orgRow.SalesUnitPriceTaxInc;
            //    row.GenTanka = _orgRow.UnitCostTaxInc;
            //}
            //else
            //{
            //    row.Price = _orgRow.PriceTaxExc;
            //    row.UriTanka = _orgRow.SalesUnitPriceTaxExc;
            //    row.GenTanka = _orgRow.UnitCostTaxExc;
            //}
            //// 粗利額・粗利率は区分関係なく税抜きで計算
            //row.Ararigaku = _orgRow.SalesUnitPriceTaxExc - _orgRow.UnitCostTaxExc;
            //if (_orgRow.SalesUnitPriceTaxExc != 0)
            //    row.Arariritu = row.Ararigaku / _orgRow.SalesUnitPriceTaxExc;

            if (( _newPartsRow.OfferKubun == 1 || _newPartsRow.OfferKubun == 3 ) &&  // セット親が純正か
                _newPartsRow.SearchPartsFullName != string.Empty)
            {
                row.PartsName = _newPartsRow.SearchPartsFullName;
            }
            else if (_newPartsRow.GoodsName != string.Empty)
            {
                row.PartsName = _newPartsRow.GoodsName;
            }
            else
            {
                row.PartsName = _newPartsRow.GoodsOfrName;
            }

            if (totalAmountDispWay == 1) // 総額表示する（税込み）
            {
                row.Price = _newPartsRow.PriceTaxInc;
                row.UriTanka = _newPartsRow.SalesUnitPriceTaxInc;
                row.GenTanka = _newPartsRow.UnitCostTaxInc;
            }
            else
            {
                row.Price = _newPartsRow.PriceTaxExc;
                row.UriTanka = _newPartsRow.SalesUnitPriceTaxExc;
                row.GenTanka = _newPartsRow.UnitCostTaxExc;
            }
            // 粗利額・粗利率は区分関係なく税抜きで計算
            row.Ararigaku = _newPartsRow.SalesUnitPriceTaxExc - _newPartsRow.UnitCostTaxExc;
            if (_newPartsRow.SalesUnitPriceTaxExc != 0)
                row.Arariritu = row.Ararigaku / _newPartsRow.SalesUnitPriceTaxExc;
            // 2009/09/29 <<<

            row.NewPrtsNo = _newPartsNo;
            row.PrmSetDtlNo2 = string.Empty;

            if (_partsInfoRow != null) // 純正部品情報があるか(InitializeTable参照)
            {
                row.PartsOpNm = _partsInfoRow.PartsOpNm; // 純正部品の特記事項
                row.PartsQty = _partsInfoRow.PartsQty;
                //row.ClgPrtsNo = _partsInfoRow.ClgPrtsNoWithHyphen;
                //if (_orgRow.NewGoodsNo != string.Empty)
                //    row.NewPrtsNo = _orgRow.NewGoodsNo;
                row.StandardName = _partsInfoRow.StandardName;
            }
            else
            {
                // 2009/09/29 >>>
                //row.PartsQty = _orgRow.QTY;
                row.PartsQty = _newPartsRow.QTY;
                // 2009/09/29 <<<
            }
            if (row.PartsQty == 0)
                row.PartsQty = 1;

            if (SubstExists(row.NewPrtsNo, row.MakerCd))
                row.Subst = IconResourceManagement.ImageList16.Images[(int)Size16_Index.CARADD];
            if (SetExists(row.NewPrtsNo, row.MakerCd))
                row.Set = IconResourceManagement.ImageList16.Images[(int)Size16_Index.MODEL];
            _joinParts.PartsInfo.AddPartsInfoRow(row);

            #region [ 在庫設定 ]
            //在庫設定
            bool flgStock = false;
            // 2009/09/29 >>>
            //PartsInfoDataSet.StockRow[] stockRows = (PartsInfoDataSet.StockRow[])_orgRow.GetChildRows("UsrGoodsInfo_Stock");
            PartsInfoDataSet.StockRow[] stockRows = (PartsInfoDataSet.StockRow[])_newPartsRow.GetChildRows("UsrGoodsInfo_Stock");
            // 2009/09/29 <<<
            for (int i = 0; i < stockRows.Length; i++)
            {
                dsParts.StockRow stockRow = _StockTable.NewStockRow();
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
                    row.Shelf = stockRow.WarehouseShelfNo;
                    row.StockCnt = stockRow.ShipmentPosCnt;
                    row.Warehouse = stockRow.WarehouseName;
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/27 ADD
                    row.WarehouseCode = stockRow.WarehouseCode;
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
                            row.Shelf = stockRows[k].WarehouseShelfNo;
                            row.StockCnt = stockRows[k].ShipmentPosCnt;
                            row.Warehouse = stockRows[k].WarehouseName;
                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/27 ADD
                            row.WarehouseCode = stockRows[k].WarehouseCode;
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
            //    row.Shelf = stockRows[0].WarehouseShelfNo;
            //    row.StockCnt = stockRows[0].ShipmentPosCnt;
            //    row.Warehouse = stockRows[0].WarehouseName;
            //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/27 ADD
            //    row.WarehouseCode = stockRows[0].WarehouseCode;
            //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/27 ADD
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/27 DEL
            #endregion
            #endregion

            //if(_joinParts.PartsInfo[0].ClgPrtsNo = _joinParts.PartsInfo[0].join
            //結合部品設定
            string filter = string.Format("({0}='{1}' OR {2}='{3}') AND {4}={5}",
                        _orgUsrJoin.JoinSrcPartsNoWithHColumn.ColumnName, _clgPartsNo,
                        _orgUsrJoin.JoinSrcPartsNoWithHColumn.ColumnName, _newPartsNo,
                        _orgUsrJoin.JoinSourceMakerCodeColumn.ColumnName, _makerCd);
            PartsInfoDataSet.UsrJoinPartsRow[] rows =
                (PartsInfoDataSet.UsrJoinPartsRow[])_orgUsrJoin.Select(filter);//, _orgUsrJoin.JoinDispOrderColumn.ColumnName);
            for (int i = 0; i < rows.Length; i++)
            {
                PartsInfoDataSet.UsrJoinPartsRow rowToGetInfo = rows[i];

                PartsInfoDataSet.UsrGoodsInfoRow joinPartsRow =
                        _orgDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(rowToGetInfo.JoinDestMakerCd, rowToGetInfo.JoinDestPartsNo);
                if (joinPartsRow == null) // ちょっとこんなケースはなんとかしてくれ。もう限界だもん。
                    continue;

                // --- UPD m.suzuki 2011/02/02 ---------->>>>>
                # region // DEL
                //if (substFlg != 1 || PartsStockCheck(rowToGetInfo.JoinDestPartsNo, rowToGetInfo.JoinDestMakerCd) == false)
                //{       // [代替条件：在庫判定有　且つ　旧品在庫ありの場合]以外は最新品番に代替する。
                //    PartsInfoDataSet.UsrGoodsInfoRow rowNew = _orgDataSet.GetOfrSubst(joinPartsRow);
                //    if (userSubstFlg != 0) // ユーザー代替しない以外の場合
                //    {
                //        PartsInfoDataSet.UsrGoodsInfoRow rowSubst = _orgDataSet.GetUsrSubst(joinPartsRow);
                //        if (rowSubst.Equals(joinPartsRow)) // 旧優良品に対しユーザー代替がない
                //        {
                //            if (rowNew.Equals(joinPartsRow) == false) // 最新品番がある場合
                //            {
                //                rowSubst = _orgDataSet.GetUsrSubst(rowNew);
                //                if (rowSubst.Equals(rowNew)) // 最新品に対しユーザー代替なし
                //                {
                //                    joinPartsRow = rowNew;
                //                }
                //                else // 最新品に対しユーザー代替あり
                //                {
                //                    joinPartsRow = rowSubst;
                //                }
                //            }
                //        }
                //        else // 旧優良品に対しユーザー代替がある場合
                //        {
                //            joinPartsRow = rowSubst;
                //        }
                //    }
                //    else // ユーザー代替しないの場合最新品番に代替する。
                //    {
                //        joinPartsRow = rowNew;
                //    }
                //    //row = _orgDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(makerCd, partsNoInUse);
                //}
                # endregion

                // 代替元の在庫チェック
                bool stockCountNotZero;
                if ( PartsStockCheck( rowToGetInfo.JoinDestPartsNo, rowToGetInfo.JoinDestMakerCd, out stockCountNotZero ) == false ||
                     stockCountNotZero == false )
                {
                    // ユーザー代替区分
                    if ( userSubstFlg != 0 )
                    {
                        PartsInfoDataSet.UsrGoodsInfoRow rowSubst = _orgDataSet.GetUsrSubst( joinPartsRow );
                        if ( rowSubst.Equals( joinPartsRow ) == false )
                        {
                            // ユーザー代替先に代替
                            joinPartsRow = rowSubst;
                        }
                    }
                }
                // --- UPD m.suzuki 2011/02/02 ----------<<<<<

                dsParts.JoinPartsRow joinRow =
                    _joinParts.JoinParts.FindByJoinDestPartsNoJoinDestMakerCd(joinPartsRow.GoodsNo, joinPartsRow.GoodsMakerCd);
                //_joinParts.JoinParts.FindByJoinDestPartsNoJoinDestMakerCd(rowToGetInfo.JoinDestPartsNo, rowToGetInfo.JoinDestMakerCd);
                if (joinRow == null)
                {
                    joinRow = _joinParts.JoinParts.NewJoinPartsRow();

                    joinRow.JoinDestMakerCd = joinPartsRow.GoodsMakerCd; // rowToGetInfo.JoinDestMakerCd;
                    joinRow.JoinDestPartsNo = joinPartsRow.GoodsNo; // rowToGetInfo.JoinDestPartsNo;
                    joinRow.JoinDestOrgPrtNo = rowToGetInfo.JoinDestPartsNo;
                    // 2009.02.17 >>>
                    //joinRow.JoinDispOrder = joinPartsRow.DisplayOrder; // TODO //prmSetting.MakerDispOrder; //rowToGetInfo.JoinDispOrder;

                    joinRow.JoinDispOrder = rowToGetInfo.JoinDispOrder;
                    // 2009.02.17 <<<
                    joinRow.JoinQty = rowToGetInfo.JoinQty;
                    if (joinRow.JoinQty == 0)
                        joinRow.JoinQty = row.PartsQty;
                    //joinRow.JoinQty  = _orgDataSet.GetQty(row.MakerCd, row.ClgPrtsNo, joinRow.JoinDestMakerCd, joinRow.JoinDestPartsNo);
                    //joinRow.JoinQty = 1;
                    joinRow.JoinSourMaker = rowToGetInfo.JoinSourceMakerCode;
                    joinRow.JoinSourPartsNo = rowToGetInfo.JoinSrcPartsNoWithH;
                    joinRow.JoinSpecialNote = rowToGetInfo.JoinSpecialNote;

                    joinRow.JoinDestMakerNm = joinPartsRow.GoodsMakerNm;
                    if (joinPartsRow.GoodsName != string.Empty)
                    {
                        joinRow.PrimePartsName = joinPartsRow.GoodsName;
                    }
                    else
                    {
                        joinRow.PrimePartsName = joinPartsRow.GoodsOfrName;
                    }
                    if (totalAmountDispWay == 1) // 総額表示する（税込み）
                    {
                        joinRow.Price = joinPartsRow.PriceTaxInc;
                        joinRow.UriTanka = joinPartsRow.SalesUnitPriceTaxInc;
                        joinRow.GenTanka = joinPartsRow.UnitCostTaxInc;
                    }
                    else // 総額表示しない（税抜き）
                    {
                        joinRow.Price = joinPartsRow.PriceTaxExc;
                        joinRow.UriTanka = joinPartsRow.SalesUnitPriceTaxExc;
                        joinRow.GenTanka = joinPartsRow.UnitCostTaxExc;
                    }
                    // 粗利額・粗利率は区分関係なく税抜きで計算
                    joinRow.Ararigaku = joinPartsRow.SalesUnitPriceTaxExc - joinPartsRow.UnitCostTaxExc;
                    if (joinPartsRow.SalesUnitPriceTaxExc != 0)
                        joinRow.Arariritu = joinRow.Ararigaku / joinPartsRow.SalesUnitPriceTaxExc;

                    joinRow.PrmSetDtlNo2 = joinPartsRow.PrmSetDtlName2;
                    //PartsInfoDataSet.JoinPartsRow[] ofrJoinPartsRow =
                    //    (PartsInfoDataSet.JoinPartsRow[])joinPartsRow.GetChildRows("UsrGoodsInfo_JoinParts");
                    //if (ofrJoinPartsRow.Length > 0)
                    //{
                    //    joinRow.PrmSetDtlNo2 = ofrJoinPartsRow[0].PrmSetDtlNo2;
                    //    joinRow.SetPartsFlg = ofrJoinPartsRow[0].SetPartsFlg;
                    //    //if (ofrJoinPartsRow[0].SetPartsFlg != 0)
                    //    //    joinRow.Set = IconResourceManagement.ImageList16.Images[(int)Size16_Index.MODEL];
                    //}
                    //}

                    if (SubstExists(joinRow.JoinDestOrgPrtNo, joinRow.JoinDestMakerCd))
                        joinRow.Subst = IconResourceManagement.ImageList16.Images[(int)Size16_Index.CARADD];
                    if (SetExists(joinRow.JoinDestPartsNo, joinRow.JoinDestMakerCd))
                        joinRow.Set = IconResourceManagement.ImageList16.Images[(int)Size16_Index.MODEL];
                    //joinRow.PartsInfoRowParent = row;

                    _joinParts.JoinParts.AddJoinPartsRow(joinRow);
                }
                else
                {
                    if (joinRow.JoinSourPartsNo == _newPartsNo && rowToGetInfo.JoinSrcPartsNoWithH == _clgPartsNo)
                    {
                        // 表示用データテーブルに最新品番が設定されている場合、カタログ品番の情報を再設定する
                        joinRow.JoinSourPartsNo = _clgPartsNo;
                        // --- ADD 2015/12/18 Y.Wakita ---------->>>>>
                        joinRow.JoinSpecialNote = rowToGetInfo.JoinSpecialNote;
                        // --- ADD 2015/12/18 Y.Wakita ----------<<<<<
                    }
                }

                #region [ 在庫設定 ]
                //filter = string.Format("{0}={1} AND ({2}='{3}' OR {4}='{5}')",
                //            _orgDataSet.Stock.GoodsMakerCdColumn.ColumnName, joinRow.JoinDestMakerCd,
                //            _orgDataSet.Stock.GoodsNoColumn.ColumnName, joinRow.JoinDestPartsNo,
                //            _orgDataSet.Stock.GoodsNoColumn.ColumnName, joinRow.JoinDestOrgPrtNo);
                filter = string.Format("{0}={1} AND {2}='{3}'",
                            _orgDataSet.Stock.GoodsMakerCdColumn.ColumnName, joinRow.JoinDestMakerCd,
                            _orgDataSet.Stock.GoodsNoColumn.ColumnName, joinRow.JoinDestPartsNo);
                stockRows = (PartsInfoDataSet.StockRow[])_orgDataSet.Stock.Select(filter);
                flgStock = false;
                for (int j = 0; j < stockRows.Length; j++)
                {
                    if (_StockTable.FindByWarehouseCodeGoodsMakerCdGoodsNo(stockRows[j].WarehouseCode,
                            stockRows[j].GoodsMakerCd, stockRows[j].GoodsNo) == null)
                    {
                        dsParts.StockRow stockRow = _StockTable.NewStockRow();
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
                            joinRow.Shelf = stockRow.WarehouseShelfNo;
                            joinRow.StockCnt = stockRow.ShipmentPosCnt;
                            joinRow.Warehouse = stockRow.WarehouseName;
                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/27 ADD
                            joinRow.WarehouseCode = stockRow.WarehouseCode;
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
                                joinRow.Shelf = stockRows[k].WarehouseShelfNo;
                                joinRow.StockCnt = stockRows[k].ShipmentPosCnt;
                                joinRow.Warehouse = stockRows[k].WarehouseName;
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/27 ADD
                                joinRow.WarehouseCode = stockRows[k].WarehouseCode;
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
                //    joinRow.Shelf = stockRows[0].WarehouseShelfNo;
                //    joinRow.StockCnt = stockRows[0].ShipmentPosCnt;
                //    joinRow.Warehouse = stockRows[0].WarehouseName;
                //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/27 ADD
                //    joinRow.WarehouseCode = stockRows[0].WarehouseCode;
                //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/27 ADD
                //}
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/27 DEL
                #endregion
            }
            _joinParts.AcceptChanges();///////

            // 2010/03/16 Del >>>
            #region 別メソッドへ移動する為削除
            //gridJoinParts.DataSource = _joinParts.PartsInfo.DefaultView;

            //gridStock.DataSource = _StockTable.DefaultView;
            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/26 ADD
            //SettingStockView(_StockTable.DefaultView);
            //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/26 ADD

            //if (displayOrder == 1) // 1:在庫順か
            //{
            //    //gridJoinParts.Rows[0].ChildBands[0].Band.SortedColumns.Add(_joinParts.JoinParts.StockCntColumn.ColumnName, true);
            //    gridJoinParts.DisplayLayout.Bands[1].SortedColumns.Add(_joinParts.JoinParts.StockCntColumn.ColumnName, true);
            //}
            //else
            //{
            //    gridJoinParts.DisplayLayout.Bands[1].SortedColumns.Add(_joinParts.JoinParts.JoinDispOrderColumn.ColumnName, false);
            //}

            //Infragistics.Win.Appearance app = new Infragistics.Win.Appearance();
            ////app.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
            //app.ForeColor = Color.Red;

            //for (int i = 0; i < gridJoinParts.Rows[0].ChildBands[0].Rows.Count; i++)
            //{
            //    string joinSrcPartsNo = gridJoinParts.Rows[0].ChildBands[0].Rows[i].Cells[_joinParts.JoinParts.JoinSourPartsNoColumn.ColumnName].Text;
            //    if (_clgPartsNo != _newPartsNo && _newPartsNo == joinSrcPartsNo)
            //    {
            //        gridJoinParts.Rows[0].ChildBands[0].Rows[i].Cells[_joinParts.JoinParts.JoinDestPartsNoColumn.ColumnName].Appearance = app;
            //        gridJoinParts.Rows[0].ChildBands[0].Rows[i].Cells[_joinParts.JoinParts.JoinDestPartsNoColumn.ColumnName].SelectedAppearance = app;
            //    }
            //}
            #endregion
            // 2010/03/16 Del <<<
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

            //if(_joinParts.PartsInfo[0].ClgPrtsNo = _joinParts.PartsInfo[0].join
            //結合部品設定
            string filter = string.Format("({0}='{1}' OR {2}='{3}') AND {4}={5}",
                        _orgUsrJoin.JoinSrcPartsNoWithHColumn.ColumnName, _clgPartsNo,
                        _orgUsrJoin.JoinSrcPartsNoWithHColumn.ColumnName, _newPartsNo,
                        _orgUsrJoin.JoinSourceMakerCodeColumn.ColumnName, _makerCd);
            PartsInfoDataSet.UsrJoinPartsRow[] rows =
                (PartsInfoDataSet.UsrJoinPartsRow[])_orgUsrJoin.Select(filter);//, _orgUsrJoin.JoinDispOrderColumn.ColumnName);
            for (int i = 0; i < rows.Length; i++)
            {
                PartsInfoDataSet.UsrJoinPartsRow rowToGetInfo = rows[i];

                PartsInfoDataSet.UsrGoodsInfoRow joinPartsRow =
                        _orgDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(rowToGetInfo.JoinDestMakerCd, rowToGetInfo.JoinDestPartsNo);
                if (joinPartsRow == null) // ちょっとこんなケースはなんとかしてくれ。もう限界だもん。
                    continue;

                // --- UPD m.suzuki 2011/02/02 ---------->>>>>
                # region // DEL
                //if (substFlg != 1 || PartsStockCheck(rowToGetInfo.JoinDestPartsNo, rowToGetInfo.JoinDestMakerCd) == false)
                //{       // [代替条件：在庫判定有　且つ　旧品在庫ありの場合]以外は最新品番に代替する。
                //    PartsInfoDataSet.UsrGoodsInfoRow rowNew = _orgDataSet.GetOfrSubst(joinPartsRow);
                //    if (userSubstFlg != 0) // ユーザー代替しない以外の場合
                //    {
                //        PartsInfoDataSet.UsrGoodsInfoRow rowSubst = _orgDataSet.GetUsrSubst(joinPartsRow);
                //        if (rowSubst.Equals(joinPartsRow)) // 旧優良品に対しユーザー代替がない
                //        {
                //            if (rowNew.Equals(joinPartsRow) == false) // 最新品番がある場合
                //            {
                //                rowSubst = _orgDataSet.GetUsrSubst(rowNew);
                //                if (rowSubst.Equals(rowNew)) // 最新品に対しユーザー代替なし
                //                {
                //                    joinPartsRow = rowNew;
                //                }
                //                else // 最新品に対しユーザー代替あり
                //                {
                //                    joinPartsRow = rowSubst;
                //                }
                //            }
                //        }
                //        else // 旧優良品に対しユーザー代替がある場合
                //        {
                //            joinPartsRow = rowSubst;
                //        }
                //    }
                //    else // ユーザー代替しないの場合最新品番に代替する。
                //    {
                //        joinPartsRow = rowNew;
                //    }
                //}
                # endregion

                // 代替元の在庫チェック
                bool stockCountNotZero;
                if ( PartsStockCheck( rowToGetInfo.JoinDestPartsNo, rowToGetInfo.JoinDestMakerCd, out stockCountNotZero ) == false ||
                     stockCountNotZero == false)
                {
                    // ユーザー代替区分
                    if ( userSubstFlg != 0 )
                    {
                        PartsInfoDataSet.UsrGoodsInfoRow rowSubst = _orgDataSet.GetUsrSubst( joinPartsRow );
                        if ( rowSubst.Equals( joinPartsRow ) == false )
                        {
                            // ユーザー代替先に代替
                            joinPartsRow = rowSubst;
                        }
                    }
                }
                // --- UPD m.suzuki 2011/02/02 ----------<<<<<

                if (joinPartsRow != null)
                {
                    goodsPrimaryKeyList.Add(new PartsInfoDataSet.GoodsPrimaryKey(joinPartsRow.GoodsNo, joinPartsRow.GoodsMakerCd));
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
        /// 
        /// </summary>
        /// <returns></returns>
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

            if (_joinParts.JoinParts.Count == 0)
            {
                isDialogShown = false;
                if (uiControlFlg)
                {
                    _orgDataSet.UsrGoodsInfo.RowToProcess = _orgRow;
                    _orgDataSet.UIKind = SelectUIKind.Set;
                    return DialogResult.Retry;
                }
                else
                {
                    _orgRow.SelectionState = true;
                    return DialogResult.OK;
                }
            }

            // 2010/03/16 Add >>>
            if (_mode == 1)
            {
                isDialogShown = false;
                return DialogResult.None;
            }
            // 2010/03/16 Add <<<

            #region [ 代替選択UIあと処理 ]
            if (_prevRow != null && _prevRow.NewGoodsNo != string.Empty) // 代替されたか
            {
                if (_prevSelInfo != null)
                {
                    _prevSelInfo.ListChildGoods.Clear();
                    _prevSelInfo.ListChildGoods2.Clear();
                    if (_prevSelInfo.ListPlrlSubst.Count > 0)
                    {
                        _prevSelInfo.Selected = true;
                        _prevSelInfo.ListPlrlSubst.RemoveAt(0); // 1個目は代替品情報なので削除しておく。
                    }
                }
                PartsInfoDataSet.UsrGoodsInfoRow newRow =
                        _orgDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(_prevRow.GoodsMakerCd, _prevRow.NewGoodsNo);
                //if (_joinParts.PartsInfo[0].Equals(_prevRow)) // 結合元に対する代替は出来ないように制限する。
                //{
                //_joinParts.PartsInfo[0].OldPartsNo = _joinParts.PartsInfo[0].ClgPrtsNo;
                //_joinParts.PartsInfo[0].ClgPrtsNo = newRow.GoodsNo;
                //_joinParts.PartsInfo[0].PartsName = newRow.GoodsName;
                //_joinParts.PartsInfo[0].Price = newRow.Price;
                //}
                //else
                if (_joinParts.PartsInfo[0].Equals(_prevRow) == false) // 結合元品番は代替させない
                {
                    string filter = string.Format("{0}={1} AND {2}='{3}' ",
                            _joinParts.JoinParts.JoinDestMakerCdColumn.ColumnName, _prevRow.GoodsMakerCd,
                        //_joinParts.JoinParts.JoinDestOrgPrtNoColumn.ColumnName, _prevRow.GoodsNo);
                            _joinParts.JoinParts.JoinDestPartsNoColumn.ColumnName, _prevRow.GoodsNo);
                    dsParts.JoinPartsRow oldRow = ((dsParts.JoinPartsRow[])_joinParts.JoinParts.Select(filter))[0];
                    //dsParts.JoinPartsRow oldRow =
                    //    _joinParts.JoinParts.FindByJoinDestPartsNoJoinDestMakerCd(_prevRow.GoodsNo, _prevRow.GoodsMakerCd);

                    oldRow.OldPartsNo = oldRow.JoinDestPartsNo;
                    oldRow.JoinDestPartsNo = newRow.GoodsNo;
                    oldRow.PrimePartsName = newRow.GoodsName;
                    if (totalAmountDispWay == 1) // 総額表示する（税込み）
                    {
                        oldRow.Price = newRow.PriceTaxInc;
                        oldRow.UriTanka = newRow.SalesUnitPriceTaxInc;
                        oldRow.GenTanka = newRow.UnitCostTaxInc;
                    }
                    else // 総額表示しない（税抜き）
                    {
                        oldRow.Price = newRow.PriceTaxExc;
                        oldRow.UriTanka = newRow.SalesUnitPriceTaxExc;
                        oldRow.GenTanka = newRow.UnitCostTaxExc;
                    }
                    // 粗利額・粗利率は区分関係なく税抜きで計算
                    oldRow.Ararigaku = newRow.SalesUnitPriceTaxExc - newRow.UnitCostTaxExc;
                    if (newRow.SalesUnitPriceTaxExc != 0)
                        oldRow.Arariritu = oldRow.Ararigaku / newRow.SalesUnitPriceTaxExc;

                    oldRow.JoinSpecialNote = newRow.GoodsSpecialNote;
                    //oldRow[_joinParts.JoinParts.SubstColumn] = DBNull.Value;    // 代替した部品はさらに代替選択不可
                    if (SetExists(oldRow.JoinDestPartsNo, oldRow.JoinDestMakerCd))
                        oldRow.Set = IconResourceManagement.ImageList16.Images[(int)Size16_Index.MODEL];
                    else
                        oldRow[_joinParts.JoinParts.SetColumn] = DBNull.Value;
                    filter = string.Format("{0}={1} AND {2}='{3}' ",
                            _orgDataSet.Stock.GoodsMakerCdColumn.ColumnName,
                            gridJoinParts.ActiveRow.Cells[_joinParts.JoinParts.JoinDestMakerCdColumn.ColumnName].Value,
                            _orgDataSet.Stock.GoodsNoColumn.ColumnName,
                            gridJoinParts.ActiveRow.Cells[_joinParts.JoinParts.JoinDestPartsNoColumn.ColumnName].Value);
                    _StockTable.DefaultView.RowFilter = filter;
                    SetStockGridSelect();
                    if (gridStock.Rows.Count == 0)
                    {
                        oldRow.Shelf = string.Empty;
                        oldRow.StockCnt = 0;
                        oldRow.Warehouse = string.Empty;
                    }
                    _joinParts.JoinParts.AcceptChanges(); /////
                    //ToolbarsManager.Tools["Button_SubstOff"].SharedProps.Visible = true;
                }
                if (_prevRow.Equals(newRow) == false)
                    _prevRow.SelectionState = false;
                _prevRow.NewGoodsNo = string.Empty;
                _prevRow = null;
                gridJoinParts_AfterSelectChange(this, null);
            }
            #endregion

            SetButtonState();

            isUserClose = true;
            //if (_orgRow.Equals(_orgDataSet.UsrGoodsInfo.RowToProcess) == false && orgRowChged == false)
            {
                InitializeTable();
            }
            _selInf = _orgDataSet.JoinSrcSelInf;
            _lstSelInf = _selInf.ListChildGoods;

            //orgRowChged = false;

            _joinParts.PartsInfo[0].SelectionState = _selInf.Selected;
            _joinParts.PartsInfo[0].WarehouseCode = _selInf.WarehouseCode;
            if (_selInf.Selected)
            {
                _joinParts.PartsInfo[0].SelImage = IconResourceManagement.ImageList24.Images[(int)Size24_Index.ITEMCHECK];
            }
            else
            {
                _joinParts.PartsInfo[0][_joinParts.PartsInfo.SelImageColumn] = DBNull.Value;
            }

            Infragistics.Win.UltraWinGrid.RowsCollection rows = gridJoinParts.Rows[0].ChildBands[0].Rows;
            int cnt = rows.Count;
            for (int i = 0; i < cnt; i++)
            {
                if (_lstSelInf.ContainsKey(rows[i].ListIndex) && _lstSelInf[rows[i].ListIndex].Selected)
                {
                    rows[i].Cells[_joinParts.JoinParts.SelectionStateColumn.ColumnName].Value = true;
                    rows[i].Cells[_joinParts.JoinParts.SelImageColumn.ColumnName].Value = IconResourceManagement.ImageList24.Images[(int)Size24_Index.ITEMCHECK];
                }
                else
                {
                    rows[i].Cells[_joinParts.JoinParts.SelectionStateColumn.ColumnName].Value = false;
                    //rows[i].SelectionState = false;
                    rows[i].Cells[_joinParts.JoinParts.SelImageColumn.ColumnName].Value = DBNull.Value;
                }
            }

            //for (int i = 0; i < cnt; i++)
            //{
            //    PartsInfoDataSet.UsrGoodsInfoRow row = _orgDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(
            //        _joinParts.JoinParts[i].JoinDestMakerCd, _joinParts.JoinParts[i].JoinDestPartsNo);
            //    if (row != null)
            //    {
            //        _joinParts.JoinParts[i].SelectionState = row.SelectionState;
            //        if (row.SelectionState)
            //        {
            //            _joinParts.JoinParts[i].SelImage = IconResourceManagement.ImageList24.Images[(int)Size24_Index.ITEMCHECK];
            //        }
            //        else
            //        {
            //            _joinParts.JoinParts[i][_joinParts.JoinParts.SelImageColumn] = DBNull.Value;
            //        }
            //    }
            //}

            if (gridJoinParts.Selected.Rows.Count > 0)
            {
                gridJoinParts.Selected.Rows[0].Activated = true;
                int makerCd;
                string goodsNo;
                if (gridJoinParts.Selected.Rows[0].Band.ParentBand == null)
                {
                    makerCd = (int)gridJoinParts.Selected.Rows[0].Cells[_joinParts.PartsInfo.MakerCdColumn.ColumnName].Value;
                    goodsNo = gridJoinParts.Selected.Rows[0].Cells[_joinParts.PartsInfo.ClgPrtsNoColumn.ColumnName].Value.ToString();
                    if (goodsNo.Equals(string.Empty)) // 本来はあってはいけないケースだが、現状データの問題により、障害が発生する恐れがあり。
                    {                                 // このチェック処理で防ぐ。
                        goodsNo = gridJoinParts.Selected.Rows[0].Cells[_joinParts.PartsInfo.NewPrtsNoColumn.ColumnName].Value.ToString();
                    }
                }
                else
                {
                    makerCd = (int)gridJoinParts.Selected.Rows[0].Cells[_joinParts.JoinParts.JoinDestMakerCdColumn.ColumnName].Value;
                    goodsNo = gridJoinParts.Selected.Rows[0].Cells[_joinParts.JoinParts.JoinDestPartsNoColumn.ColumnName].Value.ToString();
                }
                PartsInfoDataSet.UsrGoodsInfoRow row = _orgDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(makerCd, goodsNo);

                if (row.SelectionComplete)
                {
                    gridJoinParts.Selected.Rows[0].Cells[_joinParts.JoinParts.SelImageColumn.ColumnName].Appearance.BackColor = Color.DarkKhaki;
                    gridJoinParts.Selected.Rows[0].Cells[_joinParts.JoinParts.SelImageColumn.ColumnName].SelectedAppearance.BackColor = Color.DarkKhaki;
                    gridJoinParts.Selected.Rows[0].Cells[_joinParts.JoinParts.SelImageColumn.ColumnName].SelectedAppearance.BackColor2 = Color.DarkKhaki;
                }
                else
                {
                    gridJoinParts.Selected.Rows[0].Cells[_joinParts.JoinParts.SelImageColumn.ColumnName].Appearance.ResetBackColor();
                    gridJoinParts.Selected.Rows[0].Cells[_joinParts.JoinParts.SelImageColumn.ColumnName].SelectedAppearance.ResetBackColor();
                    gridJoinParts.Selected.Rows[0].Cells[_joinParts.JoinParts.SelImageColumn.ColumnName].SelectedAppearance.ResetBackColor2();
                }
            }
            else
            {
                gridJoinParts.Rows[0].Activate();
                gridJoinParts.Rows[0].Selected = true;
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
            gridJoinParts.UpdateData();
            // 2009.02.19 >>>
            //return base.ShowDialog();
            return base.ShowDialog(owner);
            // 2009.02.19 <<<
        }

        #region [ チェック処理 ]
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
        #endregion

        #region internal[2007]
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
        private void SelectionForm_FormClosed(object sender, FormClosedEventArgs e)
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
                return;
            }

            //_orgRow.SelectionState = _joinParts.PartsInfo[0].SelectionState;
            //if (uiControlFlg && _joinParts.PartsInfo[0].SelImage.Equals(DBNull.Value) == false)
            if (uiControlFlg) // PM.NS式制御
            {
                if (_joinParts.PartsInfo[0][_joinParts.PartsInfo.SelImageColumn.ColumnName].Equals(DBNull.Value) == false)
                    _selInf.Selected = true;
                if (gridJoinParts.ActiveRow != null && gridJoinParts.ActiveRow.Equals(gridJoinParts.Rows[0]))
                {
                    if (_orgDataSet.UIKind == SelectUIKind.Set)
                    {
                        _selInf.JoinSet = true;
                        _orgDataSet.SetSrcSelInf = _selInf;
                        _prevSelInfo = _selInf;
                    }
                    //if (_orgDataSet.UIKind == SelectUIKind.Subst) // 結合元品に関しては代替なし
                    //{
                    //    _orgDataSet.SubstSrcSelInf = _selInf;
                    //    _prevSelInfo = _selInf;
                    //}
                }
            }
            else　// PM7式制御
            {
                if (_joinParts.PartsInfo[0][_joinParts.PartsInfo.SelImageColumn.ColumnName].Equals(DBNull.Value) == false)
                {
                    _selInf.JoinSet = true;
                    //if (_orgDataSet.UIKind == SelectUIKind.Subst)
                    //{
                    //    _orgDataSet.SubstSrcSelInf = _selInf;
                    //    _prevSelInfo = _selInf;
                    //}
                }

                //if (gridJoinParts.ActiveRow != null && gridJoinParts.ActiveRow.Equals(gridJoinParts.Rows[0]))
                //{
                //    _selInf.JoinSet = true;
                //    if (enterFlg == 0 || enterFlg == 2) // 0:PM7, 1:選択 2:次画面（純正⇒結合、結合⇒セット、セット⇒確定）
                //        _selInf.Selected = false;
                //    else if (_joinParts.PartsInfo[0][_joinParts.PartsInfo.SelImageColumn.ColumnName].Equals(DBNull.Value) == false)
                //        _selInf.Selected = true;
                //}
                //else
                //{
                //    if (_joinParts.PartsInfo[0][_joinParts.PartsInfo.SelImageColumn.ColumnName].Equals(DBNull.Value) == false)
                //    {
                //        _selInf.JoinSet = true;
                //        _selInf.Selected = true;
                //    }
                //}
            }
            if (_joinParts.PartsInfo[0].SelectionState)
            {
                _selInf.RowGoods.QTY = _joinParts.PartsInfo[0].PartsQty;
                _selInf.RowGoods.GoodsKindResolved = (int)GoodsKind.Parent;
                _selInf.WarehouseCode = _joinParts.PartsInfo[0].WarehouseCode;
            }

            Infragistics.Win.UltraWinGrid.RowsCollection rows = gridJoinParts.Rows[0].ChildBands[0].Rows;
            int cnt = rows.Count;
            for (int i = 0; i < cnt; i++)
            {
                UltraGridRow gridRow = rows[i];
                if (gridRow.Cells[_joinParts.JoinParts.SelectionStateColumn.ColumnName].Value.Equals(true))
                {
                    PartsInfoDataSet.UsrGoodsInfoRow row = _orgDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(
                        (int)gridRow.Cells[_joinParts.JoinParts.JoinDestMakerCdColumn.ColumnName].Value,
                        gridRow.Cells[_joinParts.JoinParts.JoinDestPartsNoColumn.ColumnName].Value.ToString());
                    //_joinParts.JoinParts[i].JoinDestMakerCd,
                    //_joinParts.JoinParts[i].JoinDestPartsNo);
                    if (row != null)
                    {
                        //>>>2010/12/09 表示順：在庫順にした場合、QTYが正常にセットされない件の対応
                        //row.QTY = _joinParts.JoinParts[i].JoinQty;
                        row.QTY = (double)gridRow.Cells[_joinParts.JoinParts.JoinQtyColumn.ColumnName].Value;
                        //<<<2010/12/09 表示順：在庫順にした場合、QTYが正常にセットされない件の対応
                        row.GoodsKindResolved = (int)GoodsKind.Join;

                        SelectionInfo selInfo = new SelectionInfo();
                        selInfo.Depth = 1;
                        selInfo.Key = gridRow.ListIndex;
                        selInfo.RowGoods = row;
                        selInfo.WarehouseCode = gridRow.Cells[_joinParts.JoinParts.WarehouseCodeColumn.ColumnName].Value.ToString();
                        if (uiControlFlg) // PM.NS式制御
                        {
                            if (gridRow.Cells[_joinParts.JoinParts.SelImageColumn.ColumnName].Value.Equals(DBNull.Value) == false)
                                selInfo.Selected = true;
                            if (gridJoinParts.ActiveRow != null && gridJoinParts.ActiveRow.Index == i)
                            {
                                if (_orgDataSet.UIKind == SelectUIKind.Set)
                                {
                                    _orgDataSet.SetSrcSelInf = selInfo;
                                    _prevSelInfo = selInfo;
                                }
                            }
                        }
                        if (gridJoinParts.ActiveRow != null && gridJoinParts.ActiveRow.Index == i
                            && _orgDataSet.UIKind == SelectUIKind.Subst)
                        {
                            _orgDataSet.SubstSrcSelInf = selInfo;
                            _prevSelInfo = selInfo;
                        }
                        //else　// PM7式制御
                        //{
                        //    if (gridJoinParts.ActiveRow != null && gridJoinParts.ActiveRow.Index == i)
                        //    {
                        //        if (enterFlg == 0 || enterFlg == 2) // 0:PM7, 1:選択 2:次画面（純正⇒結合、結合⇒セット、セット⇒確定）
                        //            selInfo.Selected = false;
                        //        else if (gridRow.Cells[_joinParts.JoinParts.SetColumn.ColumnName].Value.Equals(DBNull.Value) == false)
                        //            selInfo.Selected = true;
                        //    }
                        //    else
                        //    {
                        //        if (gridRow.Cells[_joinParts.JoinParts.SetColumn.ColumnName].Value.Equals(DBNull.Value) == false)
                        //            selInfo.Selected = true;
                        //    }
                        //}
                        _orgDataSet.AddSelectionInfo(_lstSelInf, gridRow.ListIndex, ref selInfo);
                        //if (_orgDataSet.UsrGoodsInfo.RowToProcess.Equals(row))                        
                    }
                }
                else
                {
                    _orgDataSet.RemoveSelectionInfo(_lstSelInf, gridRow.ListIndex);
                }
            }

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

        /// <summary>
        /// ESCキー押下による終了処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectionForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                DialogResult = DialogResult.Cancel;
                isUserClose = false;
            }
        }

        /// <summary>
        /// FormClosing イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// </remarks>
        private void SelectionForm_FormClosing(object sender, FormClosingEventArgs e)
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
            UltraGridRow activeRow = gridJoinParts.ActiveRow;
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
                        // UPD 2013/01/11 2013/03/13配信予定 SCM障害№10462対応 ---------------------------->>>>>
                        //if (uiControlFlg == false && _joinParts.PartsInfo[0].SelectionState == false
                        //   && _joinParts.JoinParts.Select("SelectionState = true").Length == 0)
                        //{
                        //    SetStatusBarText(1, "データの選択がされていません。");
                        //    break;
                        //}
                        //DialogResult = DialogResult.OK;
                        SetSelect(true);
                        // UPD 2013/01/11 2013/03/13配信予定 SCM障害№10462対応 ----------------------------<<<<<
                    }
                    isUserClose = false;
                    break;

                case "Button_Back":
                    // 前の画面に戻る                    
                    DialogResult = DialogResult.Cancel;
                    isUserClose = false;
                    break;

                case "Button_Subst":
                    if (activeRow != null)
                    {
                        if (activeRow.Cells[_joinParts.JoinParts.SubstColumn.ColumnName].Value != DBNull.Value)
                        {
                            int makerCd;
                            string partsNo;
                            if (activeRow.Band.ParentBand == null) // 親バンドの場合
                            {
                                makerCd = (int)activeRow.Cells[_joinParts.PartsInfo.MakerCdColumn.ColumnName].Value;
                                partsNo = activeRow.Cells[_joinParts.PartsInfo.ClgPrtsNoColumn.ColumnName].Value.ToString();
                            }
                            else
                            {
                                makerCd = (int)activeRow.Cells[_joinParts.JoinParts.JoinDestMakerCdColumn.ColumnName].Value;
                                partsNo = activeRow.Cells[_joinParts.JoinParts.JoinDestOrgPrtNoColumn.ColumnName].Value.ToString();
                            }
                            PartsInfoDataSet.UsrGoodsInfoRow row =
                                _orgDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(makerCd, partsNo);
                            if (row != null)
                            {
                                if (row.SelectionComplete)
                                {
                                    TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, this.Text,
                                        "セット選択UIで選択した項目があるため、代替出来ません。", 0,
                                        MessageBoxButtons.OK);
                                }
                                else
                                {
                                    //_orgDataSet.UsrGoodsInfo.PreviousActiveRow = row;
                                    activeRow.Cells[_joinParts.JoinParts.SelectionStateColumn.ColumnName].Value = true;
                                    _orgDataSet.UsrGoodsInfo.RowToProcess = row;
                                    //_prevRow = row;
                                    _prevRow = _orgDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(makerCd,
                                        activeRow.Cells[_joinParts.JoinParts.JoinDestPartsNoColumn.ColumnName].Value.ToString());
                                    _orgDataSet.UIKind = SelectUIKind.Subst;
                                    DialogResult = DialogResult.Retry;
                                    isUserClose = false;
                                }
                            }
                        }
                    }
                    break;

                case "Button_Set":
                    // セットがある場合セット選択UI表示
                    if (uiControlFlg && activeRow != null)
                    {
                        if (activeRow.Cells[_joinParts.JoinParts.SetColumn.ColumnName].Value != DBNull.Value)
                        {
                            isUserClose = false;
                            int makerCd;
                            string partsNo;
                            if (activeRow.Band.ParentBand == null) // 親バンドの場合
                            {
                                makerCd = (int)activeRow.Cells[_joinParts.PartsInfo.MakerCdColumn.ColumnName].Value;
                                //partsNo = activeRow.Cells[_joinParts.PartsInfo.ClgPrtsNoColumn.ColumnName].Value.ToString();
                                partsNo = activeRow.Cells[_joinParts.PartsInfo.NewPrtsNoColumn.ColumnName].Value.ToString();
                            }
                            else
                            {
                                makerCd = (int)activeRow.Cells[_joinParts.JoinParts.JoinDestMakerCdColumn.ColumnName].Value;
                                partsNo = activeRow.Cells[_joinParts.JoinParts.JoinDestPartsNoColumn.ColumnName].Value.ToString();
                            }
                            PartsInfoDataSet.UsrGoodsInfoRow row =
                                _orgDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(makerCd, partsNo);
                            if (row != null)
                            {
                                //_orgDataSet.UsrGoodsInfo.PreviousActiveRow = row;
                                activeRow.Cells[_joinParts.JoinParts.SelectionStateColumn.ColumnName].Value = true;
                                _orgDataSet.UsrGoodsInfo.RowToProcess = row;
                                _orgDataSet.UIKind = SelectUIKind.Set;
                                DialogResult = DialogResult.Retry;
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
                    if (activeRow != null &&
                        activeRow.Cells[_joinParts.JoinParts.OldPartsNoColumn.ColumnName].Value.Equals(string.Empty) == false)
                    {
                        int makerCd = (int)activeRow.Cells[_joinParts.JoinParts.JoinDestMakerCdColumn.ColumnName].Value;
                        string partsNo = activeRow.Cells[_joinParts.JoinParts.JoinDestPartsNoColumn.ColumnName].Value.ToString();
                        string oldPartsNo = activeRow.Cells[_joinParts.JoinParts.OldPartsNoColumn.ColumnName].Value.ToString();
                        string joinDestPrtNo = activeRow.Cells[_joinParts.JoinParts.JoinDestOrgPrtNoColumn.ColumnName].Value.ToString();
                        dsParts.JoinPartsRow oldRow = _joinParts.JoinParts.FindByJoinDestPartsNoJoinDestMakerCd(partsNo, makerCd); // TODO : 見直し
                        PartsInfoDataSet.UsrGoodsInfoRow newRow =
                            _orgDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(makerCd, oldPartsNo);

                        oldRow.OldPartsNo = string.Empty;
                        oldRow.JoinDestPartsNo = newRow.GoodsNo;
                        oldRow.PrimePartsName = newRow.GoodsName;
                        oldRow.Price = newRow.Price;
                        oldRow.GenTanka = newRow.UnitCost;
                        oldRow.UriTanka = newRow.SalesUnitPrice;
                        oldRow.Ararigaku = newRow.SalesUnitPrice - newRow.UnitCost;
                        if (newRow.UnitCost != 0)
                            oldRow.Arariritu = oldRow.Ararigaku / newRow.UnitCost;
                        if (SubstExists(joinDestPrtNo, makerCd))
                        {
                            oldRow.Subst = IconResourceManagement.ImageList16.Images[(int)Size16_Index.CARADD];
                        }
                        if (SetExists(oldRow.JoinDestPartsNo, oldRow.JoinDestMakerCd))
                            oldRow.Set = IconResourceManagement.ImageList16.Images[(int)Size16_Index.MODEL];
                        else
                            oldRow[_joinParts.JoinParts.SetColumn] = DBNull.Value;
                        string filter = string.Format("{0}={1} AND {2}='{3}' ",
                            _orgDataSet.Stock.GoodsMakerCdColumn.ColumnName,
                            activeRow.Cells[_joinParts.JoinParts.JoinDestMakerCdColumn.ColumnName].Value,
                            _orgDataSet.Stock.GoodsNoColumn.ColumnName,
                            activeRow.Cells[_joinParts.JoinParts.JoinDestPartsNoColumn.ColumnName].Value);
                        _StockTable.DefaultView.RowFilter = filter;
                        SetStockGridSelect();
                        if (gridStock.Rows.Count == 0)
                        {
                            oldRow.Shelf = string.Empty;
                            oldRow.StockCnt = 0;
                            oldRow.Warehouse = string.Empty;
                        }

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
                        //ToolbarsManager.Tools["Button_SubstOff"].SharedProps.Visible = false;
                        gridJoinParts_AfterSelectChange(this, null);
                    }
                    break;*/
            }
        }

        // ADD 譚洪 2014/09/01 FOR Redmine#43289 --- >>>
        /// <summary>
        /// 車両情報を表示切替処理
        /// </summary>
        private void SetPnlCarInfoVisible(bool carInfoVisible)
        {
            if (carInfoVisible)
            {
                this.gridJoinParts.Location = new System.Drawing.Point(0, this.pnl_CarInfo.Height);
                // --- ADD 2014/11/04 T.Miyamoto 仕掛一覧 №2577 ------------------------------>>>>>
                this.gridJoinParts.Height = this.SelectionForm_Fill_Panel.Height - this.pnl_CarInfo.Height;
                // --- ADD 2014/11/04 T.Miyamoto 仕掛一覧 №2577 ------------------------------<<<<<
            }
            else
            {
                this.gridJoinParts.Location = new System.Drawing.Point(0, 0);
                // --- UPD 2014/11/04 T.Miyamoto 仕掛一覧 №2577 ------------------------------>>>>>
                //this.gridJoinParts.Height = this.gridJoinParts.Height + this.pnl_CarInfo.Height;
                this.gridJoinParts.Height = this.SelectionForm_Fill_Panel.Height;
                // --- UPD 2014/11/04 T.Miyamoto 仕掛一覧 №2577 ------------------------------<<<<<
            }
        }
        // ADD 譚洪 2014/09/01 FOR Redmine#43289 --- <<<

        private void SetButtonState()
        {
            bool ena = false;
            bool enaSubst = false;
            try
            {
                if (gridJoinParts.ActiveRow == null)
                    return;
                ena = (gridJoinParts.ActiveRow.Cells[_joinParts.JoinParts.SetColumn.ColumnName].Value != System.DBNull.Value);
                if (gridJoinParts.ActiveRow.Band.ParentBand != null)
                {
                    enaSubst = (gridJoinParts.ActiveRow.Cells[_joinParts.JoinParts.SubstColumn.ColumnName].Value != System.DBNull.Value);
                }
            }
            finally
            {
                ToolbarsManager.Tools["Button_Set"].SharedProps.Enabled = ena;
                ToolbarsManager.Tools["Button_Subst"].SharedProps.Enabled = enaSubst;
            }
        }
        #endregion

        #region [ グリッドイベント処理 ]
        /// <summary>
        /// アクティブ行変更後イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridJoinParts_AfterSelectChange(object sender, AfterSelectChangeEventArgs e)
        {
            string filter = string.Empty;
            try
            {
                if (gridJoinParts.Selected.Rows.Count == 0)
                    return;
                if (gridJoinParts.Selected.Rows[0].Activated == false)
                    gridJoinParts.Selected.Rows[0].Activate();
                if (gridJoinParts.ActiveRow.Band.ParentBand == null)
                {
                    filter = string.Format("{0}={1} AND ({2}='{3}' OR {4}='{5}')",
                            _orgDataSet.Stock.GoodsMakerCdColumn.ColumnName, _makerCd,
                            _orgDataSet.Stock.GoodsNoColumn.ColumnName, _clgPartsNo,
                            _orgDataSet.Stock.GoodsNoColumn.ColumnName, _newPartsNo);
                    //gridJoinParts.DisplayLayout.Bands[1].Columns[_joinParts.JoinParts.JoinDestPartsNoColumn.ColumnName].
                    //    Header.Caption = "最新品番";
                }
                else
                {
                    filter = string.Format("{0}={1} AND {2}='{3}' ",
                            _orgDataSet.Stock.GoodsMakerCdColumn.ColumnName,
                            gridJoinParts.ActiveRow.Cells[_joinParts.JoinParts.JoinDestMakerCdColumn.ColumnName].Value,
                            _orgDataSet.Stock.GoodsNoColumn.ColumnName,
                            gridJoinParts.ActiveRow.Cells[_joinParts.JoinParts.JoinDestPartsNoColumn.ColumnName].Value);
                    //gridJoinParts.DisplayLayout.Bands[1].Columns[_joinParts.JoinParts.JoinDestPartsNoColumn.ColumnName].
                    //    Header.Caption = "優良品番";
                }
                SetButtonState();
            }
            finally
            {
                _StockTable.DefaultView.RowFilter = filter;
            }

            SetStockGridSelect();

            if (gridJoinParts.ActiveRow.Band.ParentBand != null)
            {
                string joinSrcPartsNo = gridJoinParts.ActiveRow.Cells[_joinParts.JoinParts.JoinSourPartsNoColumn.ColumnName].Text;
                if (_clgPartsNo != _newPartsNo && joinSrcPartsNo == _newPartsNo)
                {
                    SetStatusBarText(1, "部品メーカーに確認の上、ご使用下さい。");
                }
                else
                {
                    SetStatusBarText(0, string.Empty);
                }
            }
            else
            {
                SetStatusBarText(0, string.Empty);
            }
        }

        /// <summary>
        /// InitializeLayout イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>グリッドのレイアウト初期化処理</br>
        /// </remarks>
        private void gridJoinParts_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            // 列幅の自動調整方法
            e.Layout.AutoFitStyle = AutoFitStyle.ResizeAllColumns;
            e.Layout.Override.RowSizing = RowSizing.Fixed;
            e.Layout.Override.AllowColSizing = AllowColSizing.None;
            e.Layout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;

            gridJoinParts.DisplayLayout.InterBandSpacing = 3;

            #region 結合グリッド（バンド０）の設定
            // バンドの取得
            UltraGridBand band0 = e.Layout.Bands[0];
            //band0.Override.HeaderPlacement = HeaderPlacement.FixedOnTop;
            band0.UseRowLayout = true;
            band0.Indentation = 0;

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
            band0.Columns[_joinParts.PartsInfo.SelectionStateColumn.ColumnName].Hidden = true;
            band0.Columns[_joinParts.PartsInfo.StandardNameColumn.ColumnName].Hidden = true;
            band0.Columns[_joinParts.PartsInfo.OldPartsNoColumn.ColumnName].Hidden = true;
            band0.Columns[_joinParts.PartsInfo.WarehouseCodeColumn.ColumnName].Hidden = true;
            if (substFlg == 0) // 「代替しない」は代替カラムを表示しない。
            {
                band0.Columns[_joinParts.PartsInfo.SubstColumn.ColumnName].Hidden = true;
            }
            //２段
            ColInfo.SetColInfo(band0, _joinParts.PartsInfo.SelImageColumn.ColumnName, 2, 0, 1, 4, 16);

            //上段
            ColInfo.SetColInfo(band0, _joinParts.PartsInfo.MakerCdColumn.ColumnName, 3, 0, 3, 2, 25);
            ColInfo.SetColInfo(band0, _joinParts.PartsInfo.MakerNameColumn.ColumnName, 6, 0, 10, 2, 95);
            ColInfo.SetColInfo(band0, _joinParts.PartsInfo.PartsNameColumn.ColumnName, 16, 0, 14, 2, 140);
            ColInfo.SetColInfo(band0, _joinParts.PartsInfo.WarehouseColumn.ColumnName, 30, 0, 4, 2, 40);
            ColInfo.SetColInfo(band0, _joinParts.PartsInfo.PrmSetDtlNo2Column.ColumnName, 34, 0, 4, 2, 40);
            ColInfo.SetColInfo(band0, _joinParts.PartsInfo.PartsQtyColumn.ColumnName, 38, 0, 4, 2, 40);
            ColInfo.SetColInfo(band0, _joinParts.PartsInfo.GenTankaColumn.ColumnName, 42, 0, 4, 2, 40);
            ColInfo.SetColInfo(band0, _joinParts.PartsInfo.ArarirituColumn.ColumnName, 46, 0, 4, 2, 40);

            //下段
            ColInfo.SetColInfo(band0, _joinParts.PartsInfo.PartsOpNmColumn.ColumnName, 3, 2, 13, 2, 130);
            ColInfo.SetColInfo(band0, _joinParts.PartsInfo.ClgPrtsNoColumn.ColumnName, 16, 2, 7, 2, 70);
            ColInfo.SetColInfo(band0, _joinParts.PartsInfo.NewPrtsNoColumn.ColumnName, 23, 2, 7, 2, 70);
            ColInfo.SetColInfo(band0, _joinParts.PartsInfo.ShelfColumn.ColumnName, 30, 2, 4, 2, 40);
            ColInfo.SetColInfo(band0, _joinParts.PartsInfo.StockCntColumn.ColumnName, 34, 2, 4, 2, 40);
            ColInfo.SetColInfo(band0, _joinParts.PartsInfo.PriceColumn.ColumnName, 38, 2, 4, 2, 40);
            ColInfo.SetColInfo(band0, _joinParts.PartsInfo.UriTankaColumn.ColumnName, 42, 2, 4, 2, 40);
            ColInfo.SetColInfo(band0, _joinParts.PartsInfo.ArarigakuColumn.ColumnName, 46, 2, 4, 2, 40);
            if (substFlg == 0) // 「代替しない」は代替カラムを表示しない。
            {
                ColInfo.SetColInfo(band0, _joinParts.PartsInfo.SetColumn.ColumnName, 50, 0, 1, 4, 14);
            }
            else
            {
                ColInfo.SetColInfo(band0, _joinParts.PartsInfo.SubstColumn.ColumnName, 50, 0, 1, 4, 13);
                ColInfo.SetColInfo(band0, _joinParts.PartsInfo.SetColumn.ColumnName, 51, 0, 1, 4, 13);
            }

            band0.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.None;
            band0.Columns[_joinParts.PartsInfo.MakerCdColumn.ColumnName].Format = "0000";
            band0.Columns[_joinParts.PartsInfo.PriceColumn.ColumnName].Format = "C";
            band0.Columns[_joinParts.PartsInfo.GenTankaColumn.ColumnName].Format = "C";
            band0.Columns[_joinParts.PartsInfo.UriTankaColumn.ColumnName].Format = "C";
            band0.Columns[_joinParts.PartsInfo.ArarigakuColumn.ColumnName].Format = "C";
            band0.Columns[_joinParts.PartsInfo.ArarirituColumn.ColumnName].Format = "#%";
            band0.Columns[_joinParts.PartsInfo.StockCntColumn.ColumnName].Format = "###,###,##0.00";
            band0.Columns[_joinParts.PartsInfo.PartsQtyColumn.ColumnName].Format = "###,###,##0.00";
            #endregion

            UltraGridBand band1 = e.Layout.Bands[1];
            //band1.ColHeadersVisible = false;
            band1.Override.HeaderPlacement = HeaderPlacement.FixedOnTop;
            band0.ColHeadersVisible = false;
            band1.UseRowLayout = true;
            band1.Indentation = 0;

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
            band1.Columns[_joinParts.JoinParts.SelectionStateColumn.ColumnName].Hidden = true;
            band1.Columns[_joinParts.JoinParts.JoinSourMakerColumn.ColumnName].Hidden = true;
            band1.Columns[_joinParts.JoinParts.SetPartsFlgColumn.ColumnName].Hidden = true;
            band1.Columns[_joinParts.JoinParts.JoinDispOrderColumn.ColumnName].Hidden = true;
            band1.Columns[_joinParts.JoinParts.OldPartsNoColumn.ColumnName].Hidden = true;
            band1.Columns[_joinParts.JoinParts.JoinDestOrgPrtNoColumn.ColumnName].Hidden = true;
            band1.Columns[_joinParts.JoinParts.WarehouseCodeColumn.ColumnName].Hidden = true;
            band1.Columns[_joinParts.JoinParts.PrimeDispOrderColumn.ColumnName].Hidden = true;  // 2009.02.17 Add
            band1.Columns[_joinParts.JoinParts.JoinDestMakerCdColumn.ColumnName].MergedCellStyle = MergedCellStyle.Always;
            if (substFlg == 0) // 「代替しない」は代替カラムを表示しない。
            {
                band1.Columns[_joinParts.JoinParts.SubstColumn.ColumnName].Hidden = true;
            }

            //２段
            ColInfo.SetColInfo(band1, _joinParts.JoinParts.SelImageColumn.ColumnName, 2, 0, 1, 4, 16);

            //上段
            ColInfo.SetColInfo(band1, _joinParts.JoinParts.JoinDestMakerCdColumn.ColumnName, 3, 0, 3, 2, 25);
            ColInfo.SetColInfo(band1, _joinParts.JoinParts.JoinDestMakerNmColumn.ColumnName, 6, 0, 10, 2, 95);
            ColInfo.SetColInfo(band1, _joinParts.JoinParts.PrimePartsNameColumn.ColumnName, 16, 0, 14, 2, 140);
            ColInfo.SetColInfo(band1, _joinParts.JoinParts.WarehouseColumn.ColumnName, 30, 0, 4, 2, 40);
            ColInfo.SetColInfo(band1, _joinParts.JoinParts.PrmSetDtlNo2Column.ColumnName, 34, 0, 4, 2, 40);
            ColInfo.SetColInfo(band1, _joinParts.JoinParts.JoinQtyColumn.ColumnName, 38, 0, 4, 2, 40);
            ColInfo.SetColInfo(band1, _joinParts.JoinParts.GenTankaColumn.ColumnName, 42, 0, 4, 2, 40);
            ColInfo.SetColInfo(band1, _joinParts.JoinParts.ArarirituColumn.ColumnName, 46, 0, 4, 2, 40);

            //下段
            ColInfo.SetColInfo(band1, _joinParts.JoinParts.JoinSpecialNoteColumn.ColumnName, 3, 2, 13, 2, 130);
            ColInfo.SetColInfo(band1, _joinParts.JoinParts.JoinSourPartsNoColumn.ColumnName, 16, 2, 7, 2, 70);
            ColInfo.SetColInfo(band1, _joinParts.JoinParts.JoinDestPartsNoColumn.ColumnName, 23, 2, 7, 2, 70);
            ColInfo.SetColInfo(band1, _joinParts.JoinParts.ShelfColumn.ColumnName, 30, 2, 4, 2, 40);
            ColInfo.SetColInfo(band1, _joinParts.JoinParts.StockCntColumn.ColumnName, 34, 2, 4, 2, 40);
            ColInfo.SetColInfo(band1, _joinParts.JoinParts.PriceColumn.ColumnName, 38, 2, 4, 2, 40);
            ColInfo.SetColInfo(band1, _joinParts.JoinParts.UriTankaColumn.ColumnName, 42, 2, 4, 2, 40);
            ColInfo.SetColInfo(band1, _joinParts.JoinParts.ArarigakuColumn.ColumnName, 46, 2, 4, 2, 40);

            if (substFlg == 0) // 「代替しない」は代替カラムを表示しない。
            {
                ColInfo.SetColInfo(band1, _joinParts.PartsInfo.SetColumn.ColumnName, 50, 0, 1, 4, 14);
            }
            else
            {
                ColInfo.SetColInfo(band1, _joinParts.PartsInfo.SubstColumn.ColumnName, 50, 0, 1, 4, 13);
                ColInfo.SetColInfo(band1, _joinParts.PartsInfo.SetColumn.ColumnName, 51, 0, 1, 4, 13);
            }

            band1.Columns[_joinParts.JoinParts.JoinDestMakerCdColumn.ColumnName].Format = "0000";
            band1.Columns[_joinParts.JoinParts.PriceColumn.ColumnName].Format = "C";
            band1.Columns[_joinParts.JoinParts.GenTankaColumn.ColumnName].Format = "C";
            band1.Columns[_joinParts.JoinParts.UriTankaColumn.ColumnName].Format = "C";
            band1.Columns[_joinParts.JoinParts.ArarigakuColumn.ColumnName].Format = "C";
            band1.Columns[_joinParts.JoinParts.ArarirituColumn.ColumnName].Format = "#%";
            band1.Columns[_joinParts.JoinParts.StockCntColumn.ColumnName].Format = "###,###,##0.00";
            band1.Columns[_joinParts.JoinParts.JoinQtyColumn.ColumnName].Format = "###,###,##0.00";
        }

        /// <summary>
        /// 行をダブルクリックされた場合は、その行を選択する。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// データが表示されていない行をダブルクリックしても本イベントは発生しない。
        /// </remarks>
        private void gridJoinParts_DoubleClickRow(object sender, DoubleClickRowEventArgs e)
        {
            SetSelect(false);
        }

        /// <summary>
        /// グリッド上でEnterキーが押された場合は、その行を選択する。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridJoinParts_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Down:
                    if (gridJoinParts.ActiveRow != null && gridJoinParts.ActiveRow.Band.ParentBand == null) // 親バンドか
                    {
                        gridJoinParts.ActiveRow.ChildBands[0].Rows[0].Activate();
                        gridJoinParts.ActiveRow.Selected = true;
                        e.Handled = true;
                    }
                    break;

                case Keys.Up:
                    if (gridJoinParts.ActiveRow != null && gridJoinParts.ActiveRow.Band.ParentBand != null // 子バンドか
                        && gridJoinParts.ActiveRow.Index == 0)
                    {
                        //gridJoinParts.ActiveRow.ParentRow.Activate();
                        gridJoinParts.Rows[0].Activate();
                        gridJoinParts.ActiveRow.Selected = true;
                        e.Handled = true;
                    }
                    break;

                case Keys.Enter:
                    SetSelect(true);
                    break;

                case Keys.PageDown:
                    if (gridJoinParts.ActiveRow != null && gridJoinParts.ActiveRow.Band.ParentBand == null)
                    {
                        gridJoinParts.ActiveRow.ChildBands[0].Rows[0].Activate();
                        gridJoinParts.ActiveRow.Selected = true;
                        gridJoinParts_KeyDown(sender, e);
                    }
                    break;

            }
        }

        //private void gridJoinParts_MouseEnterElement(object sender, Infragistics.Win.UIElementEventArgs e)
        //{
        //    if (e.Element != null)
        //    {
        //        System.Diagnostics.Trace.WriteLine(e.Element.ToString());
        //        string tmp = string.Format("X=[{0}] Y=[{1}] TOP=[{2}] BOTTOM[{3}]", e.Element.Rect.X, e.Element.Rect.Y, e.Element.Rect.Top, e.Element.Rect.Bottom);

        //        System.Diagnostics.Trace.WriteLine(tmp);

        //        if (e.Element.Equals(gridJoinParts.Rows[0].ChildBands[0].Rows[0].Cells[_joinParts.JoinParts.JoinDestPartsNoColumn.ColumnName].GetUIElement()))
        //            System.Diagnostics.Trace.WriteLine("優良品番");
        //    }
        //    else
        //        System.Diagnostics.Trace.WriteLine("Element Null");
        //}

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

        /// <summary>
        /// 在庫情報選択反映
        /// </summary>
        /// <remarks>在庫情報を選択すると部品情報の在庫情報を更新する</remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridStock_AfterSelectChange(object sender, AfterSelectChangeEventArgs e)
        {
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/27 DEL
            //if (gridStock.ActiveRow != null && gridJoinParts.ActiveRow != null)// && gridJoinParts.ActiveRow.Band.ParentBand != null)
            //{
            //    gridJoinParts.ActiveRow.Cells[_joinParts.JoinParts.WarehouseColumn.ColumnName].Value
            //        = gridStock.ActiveRow.Cells[_StockTable.WarehouseNameColumn.ColumnName].Value;
            //    gridJoinParts.ActiveRow.Cells[_joinParts.JoinParts.ShelfColumn.ColumnName].Value
            //        = gridStock.ActiveRow.Cells[_StockTable.WarehouseShelfNoColumn.ColumnName].Value;
            //    gridJoinParts.ActiveRow.Cells[_joinParts.JoinParts.StockCntColumn.ColumnName].Value
            //        = gridStock.ActiveRow.Cells[_StockTable.ShipmentPosCntColumn.ColumnName].Value;
            //    gridJoinParts.ActiveRow.Cells[_joinParts.JoinParts.WarehouseCodeColumn.ColumnName].Value
            //        = gridStock.ActiveRow.Cells[_StockTable.WarehouseCodeColumn.ColumnName].Value;
            //    gridStock.ActiveRow.Cells[_StockTable.SelectionStateColumn.ColumnName].Value = true;
            //    gridJoinParts.UpdateData();
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/27 DEL
        }

        private void gridStock_BeforeSelectChange(object sender, BeforeSelectChangeEventArgs e)
        {
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/27 DEL
            //if (gridStock.Selected.Rows.Count > 0)
            //    gridStock.Selected.Rows[0].Cells[_StockTable.SelectionStateColumn.ColumnName].Value = false;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/27 DEL
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
                if ( gridJoinParts.ActiveRow != null )
                {
                    if ( (bool)activeCells[_StockTable.SelectionStateColumn.ColumnName].Value == true )
                    {
                        // 部品グリッドに在庫情報表示
                        gridJoinParts.ActiveRow.Cells[_joinParts.JoinParts.WarehouseColumn.ColumnName].Value
                            = gridStock.ActiveRow.Cells[_StockTable.WarehouseNameColumn.ColumnName].Value;
                        gridJoinParts.ActiveRow.Cells[_joinParts.JoinParts.ShelfColumn.ColumnName].Value
                            = gridStock.ActiveRow.Cells[_StockTable.WarehouseShelfNoColumn.ColumnName].Value;
                        gridJoinParts.ActiveRow.Cells[_joinParts.JoinParts.StockCntColumn.ColumnName].Value
                            = gridStock.ActiveRow.Cells[_StockTable.ShipmentPosCntColumn.ColumnName].Value;
                        gridJoinParts.ActiveRow.Cells[_joinParts.JoinParts.WarehouseCodeColumn.ColumnName].Value
                            = gridStock.ActiveRow.Cells[_StockTable.WarehouseCodeColumn.ColumnName].Value;
                    }
                    else
                    {
                        // 部品グリッドの在庫情報をクリア
                        gridJoinParts.ActiveRow.Cells[_joinParts.JoinParts.WarehouseColumn.ColumnName].Value = string.Empty;
                        gridJoinParts.ActiveRow.Cells[_joinParts.JoinParts.ShelfColumn.ColumnName].Value = string.Empty;
                        gridJoinParts.ActiveRow.Cells[_joinParts.JoinParts.StockCntColumn.ColumnName].Value = 0;
                        gridJoinParts.ActiveRow.Cells[_joinParts.JoinParts.WarehouseCodeColumn.ColumnName].Value = string.Empty;
                    }
                    gridJoinParts.UpdateData();
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
        /// 在庫グリッド選択処理（ユーザー選択→優先倉庫→先頭行の順で選択）
        /// </summary>
        private void SetStockGridSelect()
        {
            if (gridJoinParts.ActiveRow.Cells[_joinParts.JoinParts.WarehouseCodeColumn.ColumnName].Value.Equals(string.Empty) == false)
            {
                for (int i = 0; i < gridStock.Rows.Count; i++)
                {
                    if (gridStock.Rows[i].Cells[_StockTable.WarehouseCodeColumn.ColumnName].Value
                        .Equals(gridJoinParts.ActiveRow.Cells[_joinParts.JoinParts.WarehouseCodeColumn.ColumnName].Value))
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
                // 該当なしの場合は先頭行にフォーカスのみセット
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
            //    gridJoinParts.ActiveRow.Cells[_joinParts.JoinParts.WarehouseColumn.ColumnName].Value = string.Empty;
            //    gridJoinParts.ActiveRow.Cells[_joinParts.JoinParts.ShelfColumn.ColumnName].Value = string.Empty;
            //    gridJoinParts.ActiveRow.Cells[_joinParts.JoinParts.StockCntColumn.ColumnName].Value = 0;
            //    gridJoinParts.ActiveRow.Cells[_joinParts.JoinParts.WarehouseCodeColumn.ColumnName].Value = string.Empty;
            //    gridJoinParts.UpdateData();
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/27 DEL
        }

        /// <summary>
        /// Enterキー(ダブルクリック)による選択処理
        /// </summary>
        /// <param name="moveFlg">true:次の行を選択状態に／false:なにもしない（マウスダブルクリック時）</param>
        private void SetSelect(bool moveFlg)
        {
            UltraGridRow activeRow = gridJoinParts.ActiveRow;
            if (activeRow != null)
            {
                CellsCollection activeCells = activeRow.Cells;
                if (uiControlFlg == false || enterFlg == 1) // PM7式制御又はEnterキーが「選択」か
                {
                    if (activeCells[_joinParts.JoinParts.SelImageColumn.ColumnName].Value != DBNull.Value)
                    {
                        activeCells[_joinParts.JoinParts.SelImageColumn.ColumnName].Value = DBNull.Value;
                        activeCells[_joinParts.JoinParts.SelectionStateColumn.ColumnName].Value = false;
                        if (activeRow.ParentRow == null) // 結合元品(親バンド)か
                        {
                            _selInf.Selected = false;
                            //_selInf.ListChildGoods.Clear();  // 選択解除する部品の結合先などの選択状態解除
                            _selInf.ListChildGoods2.Clear();
                            _selInf.ListPlrlSubst.Clear();
                        }
                        else  // 結合先品(子バンド)か
                        {
                            if (_lstSelInf.ContainsKey(activeRow.ListIndex)) // 選択解除する部品の結合先などの選択状態解除
                            {
                                _lstSelInf.Remove(activeRow.ListIndex);
                            }
                        }
                    }
                    else
                    {
                        activeCells[_joinParts.JoinParts.SelImageColumn.ColumnName].Value = IconResourceManagement.ImageList24.Images[(int)Size24_Index.ITEMCHECK];
                        activeCells[_joinParts.JoinParts.SelectionStateColumn.ColumnName].Value = true;
                    }
                }
                if (enterFlg == 0 || enterFlg == 2) // エンたーキーが[PM7]又は[次画面]の場合
                {
                    if (gridJoinParts.Rows[0].Equals(activeRow) == false
                        && gridJoinParts.Rows[0].Cells[_joinParts.PartsInfo.SelImageColumn.ColumnName].Value != DBNull.Value)
                    {
                        gridJoinParts.Rows[0].Cells[_joinParts.PartsInfo.SelImageColumn.ColumnName].Value = DBNull.Value;
                        gridJoinParts.Rows[0].Cells[_joinParts.PartsInfo.SelectionStateColumn.ColumnName].Value = false;
                        _selInf.Selected = false;
                        //_selInf.ListChildGoods.Clear();  // 選択解除する部品の結合先などの選択状態解除
                        _selInf.ListChildGoods2.Clear();
                        _selInf.ListPlrlSubst.Clear();
                    }
                    foreach (UltraGridRow row in gridJoinParts.Rows[0].ChildBands[0].Rows) // 選択行以外は選択解除する
                    {
                        if (row.Equals(activeRow) == false && row.Cells[_joinParts.JoinParts.SelImageColumn.ColumnName].Value != DBNull.Value)
                        {
                            row.Cells[_joinParts.JoinParts.SelImageColumn.ColumnName].Value = DBNull.Value;
                            row.Cells[_joinParts.JoinParts.SelectionStateColumn.ColumnName].Value = false;
                            if (_lstSelInf.ContainsKey(row.ListIndex))
                            {
                                _lstSelInf.Remove(row.ListIndex);
                            }
                        }
                    }
                }
                switch (enterFlg) // エンターキー処理区分
                {
                    case 1: // Enterキーが「選択」の場合：複数選択動作のため次行を選択状態とする。
                        if (moveFlg) // マウスダブルクリックによる場合は以下の処理しない。
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
                    case 0: // Enterキーが「PM7」の場合(結合選択UIには「PM7」と「次画面」は同等)
                    case 2: // Enterキーが「次画面」の場合
                        if (uiControlFlg)
                        {
                            if (activeCells[_joinParts.JoinParts.SetColumn.ColumnName].Value != DBNull.Value) // セット情報あり
                            {
                                int makerCd;
                                string partsNo;
                                if (gridJoinParts.ActiveRow.Band.ParentBand == null) // 親バンドの場合
                                {
                                    makerCd = (int)gridJoinParts.ActiveRow.Cells[_joinParts.PartsInfo.MakerCdColumn.ColumnName].Value;
                                    //partsNo = gridJoinParts.ActiveRow.Cells[_joinParts.PartsInfo.ClgPrtsNoColumn.ColumnName].Value.ToString();
                                    partsNo = activeRow.Cells[_joinParts.PartsInfo.NewPrtsNoColumn.ColumnName].Value.ToString();
                                }
                                else
                                {
                                    makerCd = (int)gridJoinParts.ActiveRow.Cells[_joinParts.JoinParts.JoinDestMakerCdColumn.ColumnName].Value;
                                    partsNo = gridJoinParts.ActiveRow.Cells[_joinParts.JoinParts.JoinDestPartsNoColumn.ColumnName].Value.ToString();
                                }
                                PartsInfoDataSet.UsrGoodsInfoRow row = _orgDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(makerCd, partsNo);
                                gridJoinParts.ActiveRow.Cells[_joinParts.JoinParts.SelectionStateColumn.ColumnName].Value = true;
                                _orgDataSet.UsrGoodsInfo.RowToProcess = row;
                                _orgDataSet.UIKind = SelectUIKind.Set;
                                DialogResult = DialogResult.Retry; // 次画面あり→選択なしで次画面開く。
                            }
                            else // セット情報なし
                            {
                                activeCells[_joinParts.JoinParts.SelImageColumn.ColumnName].Value = IconResourceManagement.ImageList24.Images[(int)Size24_Index.ITEMCHECK];
                                activeCells[_joinParts.JoinParts.SelectionStateColumn.ColumnName].Value = true; // 次画面がない場合選択し終了
                                if (enterFlg == 2)
                                    DialogResult = DialogResult.Ignore; // 残りの画面を無視し選択確定する。
                                else // 
                                    DialogResult = DialogResult.OK; // 部品選択UIへ戻る。
                            }
                        }
                        else
                        {
                            DialogResult = DialogResult.OK;
                        }
                        break;

                }
                gridJoinParts.UpdateData();
            }
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

        // 2010/03/16 Add >>>
        /// <summary>
        /// テーブル作成及びデータセットへの追加、リレーション設定
        /// </summary>
        private void InitializeTable2()
        {
            _orgRow = _orgDataSet.UsrGoodsInfo.RowToProcess;

            // 純正部品情報取得処理
            PartsInfoDataSet.PartsInfoRow[] childRows = (PartsInfoDataSet.PartsInfoRow[])_orgRow.GetChildRows("UsrGoodsInfo_PartsInfo");
            if (childRows.Length > 0)
            {
                _partsInfoRow = childRows[0];
            }
            _clgPartsNo = _orgRow.GoodsNo;
            if (_orgRow.NewGoodsNo == string.Empty)
                _newPartsNo = _clgPartsNo;
            else
                _newPartsNo = _orgRow.NewGoodsNo;
            _makerCd = _orgRow.GoodsMakerCd;

            // 最新品番の情報設定
            _newPartsRow = ( _newPartsNo != _clgPartsNo ) ? _orgDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(_makerCd, _newPartsNo) : _newPartsRow = _orgRow;

            // 通常ありえない
            if (_newPartsRow == null) _newPartsRow = _orgRow;
            InitializeData(false);
        }

        /// <summary>
        /// 結合全選択
        /// </summary>
        public void SelectAllJoinParts()
        {
            _selInf = _orgDataSet.JoinSrcSelInf;
            _lstSelInf = _selInf.ListChildGoods;

            dsParts.JoinPartsRow[] rows = (dsParts.JoinPartsRow[])_joinParts.PartsInfo[0].GetChildRows("PartsInfo_JoinParts");
            if (rows != null && rows.Length > 0)
            {
                int index =1;
                foreach (dsParts.JoinPartsRow joinrow in rows)
                {

                    PartsInfoDataSet.UsrGoodsInfoRow row = _orgDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(
                        joinrow.JoinDestMakerCd, joinrow.JoinDestPartsNo);
                    if (row != null)
                    {
                        row.QTY = joinrow.JoinQty;
                        row.GoodsKindResolved = (int)GoodsKind.Join;
                        row.SelectionState = true;

                        SelectionInfo selInfo = new SelectionInfo();
                        selInfo.Depth = 1;
                        selInfo.Key = index;
                        selInfo.RowGoods = row;
                        selInfo.WarehouseCode = joinrow.WarehouseCode;
                        selInfo.Selected = true;

                        //_orgDataSet.AddSelectionInfo(_lstSelInf, index, ref selInfo);
                        _orgDataSet.AddSelectionInfo(_lstSelInf, index, ref selInfo);
                        index++;
                    }
                }

            }
        }
        // 2010/03/16 Add <<<
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
                // 強制的に結合部品グリッドに移動
                gridJoinParts.Focus();
            }
        }
        // --- ADD m.suzuki 2010/10/26 ----------<<<<<

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
//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : 結合マスタ
// プログラム概要   : 結合マスタの登録・更新・削除を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30415 柴田 倫幸
// 作 成 日  2008/07/28  修正内容 : Partsman対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30413 犬飼
// 作 成 日  2009/02/12  修正内容 : 速度アップ対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30413 犬飼
// 作 成 日  2009/04/09  修正内容 : 削除商品の商品情報を非表示に修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30413 犬飼
// 作 成 日  2009/06/22  修正内容 : MANTIS【13572】【13573】【13574】
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30413 犬飼
// 作 成 日  2009/06/24  修正内容 : MANTIS【13575】
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 22008 長内
// 作 成 日  2009/07/16  修正内容 : Mantis【13573】【13574】
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 22008 長内
// 作 成 日  2009/10/30  修正内容 : Mantis【14536】
//                                : GoodsSetDetailDataTable.SetNote の桁数を変更 40⇒80
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30517 夏野 駿希
// 作 成 日  2010/01/05  修正内容 : Mantis【14852】
//                                : 表示順位：00でメンテナンス可能に変更する
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30517 夏野 駿希
// 作 成 日  2010/07/14  修正内容 : Mantis【15808】
//                                : 連続で行削除するとエラーとなる（フィードバック）
//                                : 行削除後削除するとエラーとなる（フィードバック）
//                                : 提供分新規登録時、行追加しても行削除ボタンが有効にならない（フィードバック）
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 徐佳
// 作 成 日  2010/12/03  修正内容 : 結合先品番入力時の例外エラー
//                                : 複数明細の行削除時のエラー
//----------------------------------------------------------------------------//
// 管理番号  10704766-00 作成担当 : 周雨
// 修 正 日  2011/09/01  修正内容 : 選択した在庫が初期表示されるよう修正の対応
//                                : 案件一覧 連番984 FOR redmine #24263
//----------------------------------------------------------------------------//
// 管理番号  10902175-00 作成担当 : 宮本 利明
// 修 正 日  2013/10/03  修正内容 : 仕掛一覧 №2154対応(2011/09/01修正による障害)
//                                : 既存の結合情報呼出時は2011/09/01対応は不要
//----------------------------------------------------------------------------//
// 管理番号  10902175-00 作成担当 : 宮本 利明
// 修 正 日  2013/10/08  修正内容 : 仕掛一覧 №2094対応
//                                : 原単価の取得に掛率マスタの設定を含める
//----------------------------------------------------------------------------//
// 管理番号  10904597-00 作成担当 : 宮本 利明
// 修 正 日  2013/12/02  修正内容 : 原価取得を掛率マスタの単品設定のみ対象とする
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 劉超
// 作 成 日  2013/12/04  修正内容 : 明細の項目位置を保持するように対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : gezh
// 作 成 日  2014/01/21  修正内容 : Redmine#41447既存障害の修正
//----------------------------------------------------------------------------//
// 管理番号  11170188-00 作成担当 : 時シン
// 作 成 日  2015/10/28  修正内容 : Redmine#47547 結合先品番入力時に "." を入力できないことの対応
//----------------------------------------------------------------------------//

using System;
using System.IO; // ADD 劉超　2013/12/04 FOR Redmine#41447
using System.Collections;
using System.ComponentModel;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Resources; // ADD 劉超　2013/12/04 FOR Redmine#41447

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 結合情報入力コントロールクラス
    /// </summary>
    /// <remarks>
    /// <br>------------------------------------------------------------------------------------</br>
    /// <br>UpdateNote : PM.NS用に変更する(変更点が多すぎるため変更コメントは残しません)        </br>
    /// <br>Programmer : 30415 柴田 倫幸                                                        </br>
    /// <br>Date       : 2008/07/28                                                             </br>
    /// <br>------------------------------------------------------------------------------------</br>    
    /// <br>UpdateNote : 速度アップ対応</br>
    /// <br>Programmer : 30413 犬飼</br>
    /// <br>Date       : 2009/02.12</br>
    /// <br>------------------------------------------------------------------------------------</br>
    /// <br>UpdateNote : 案件一覧 連番984 の対応                                                </br>
    /// <br>           : 選択した在庫が初期表示されるよう修正 FOR redmine #24263                </br>
    /// <br>Programmer : 周雨                                                                   </br>
    /// <br>Date       : 2011/09/01                                                             </br>
    /// <br>------------------------------------------------------------------------------------</br>
    /// <br>UpdateNote : 明細の項目位置を保持するように対応</br>
    /// <br>Programmer : 劉超</br>
    /// <br>Date       : 2013/12/04</br>
    /// <br>------------------------------------------------------------------------------------</br>
    /// <br>UpdateNote : Redmine#41447既存障害の修正</br>
    /// <br>Programmer : gezh</br>
    /// <br>Date       : 2014/01/21</br>
    /// <br>------------------------------------------------------------------------------------</br>
    /// <br>UpdateNote : Redmine#47547 結合先品番入力時に "." を入力できないことの対応          </br>
    /// <br>Programmer : 時シン                                                                 </br>
    /// <br>Date       : 2015/10/28                                                             </br>
    /// <br>------------------------------------------------------------------------------------</br>
    /// </remarks>
    public partial class PMKEN09074UB : UserControl
    {
        #region ◆Constractor
        /// <summary>
        /// 結合情報入力コントロールクラスコンストラクタ
        /// </summary>
        /// <param name="joinPartsUAcs">結合マスタ（ユーザー登録）アクセス</param>
        /// <remarks>
        /// <br>Update Note : 2010/12/03 徐佳 複数明細の行削除時のエラーを修正</br>
        /// </remarks>
        public PMKEN09074UB(JoinPartsUAcs joinPartsUAcs)    // ADD 2008/10/17 不具合対応[6559] 引数：joinPartsUAcs を追加
        {
            InitializeComponent();

            _goodsDetailDataTable = new GoodsSetGoodsDataSet.GoodsSetDetailDataTable();

            // 削除テーブル
            _deleteGoodsDetailDataTable = new GoodsSetGoodsDataSet.GoodsSetDetailDataTable();

            // -- ADD 2010/12/03 ------------------------------>>>
            // 削除テーブルの主キーを「null」とする
            _deleteGoodsDetailDataTable.PrimaryKey = null;
            // -- ADD 2010/12/03 ------------------------------<<<

            // 企業コードを取得する
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            // 商品セットマスタアクセスクラスインスタンス化
            this._joinPartsUAcs = joinPartsUAcs;  // ADD 2008/10/17 不具合対応[6559]

            // 在庫情報
            _storeDic = new Dictionary<string, ArrayList>();
            
            // 商品連結データローカルキャッシュ
            _lcGoodsUnitDataList = new List<GoodsUnitData>();

            // ADD START 劉超　2013/12/04 FOR Redmine#41447 ------>>>>>>
            this._userSetting = new IntegrateMstUserConst();

            this.Deserialize();

            // 明細グリッド
            this.LoadGridColumnsSetting(ref uGrid_Details, this._detailColumnsList);
            // ADD END 劉超　2013/12/04 FOR Redmine#41447 ------<<<<<<
        }

        #endregion

        #region ◆Private Members

        private GoodsSetGoodsDataSet.GoodsSetDetailDataTable _goodsDetailDataTable;
        private Image _guideButtonImage;
        private ImageList _imageList16;

        // 初期表示行数
        private int _defaultRowCnt = 100;

        // 削除テーブル
        private GoodsSetGoodsDataSet.GoodsSetDetailDataTable _deleteGoodsDetailDataTable;
        
        // 企業コード
        private string _enterpriseCode;

        // 変更フラグ
        private bool _changeFlg;

        /// <summary>結合マスタ（ユーザー登録）アクセス</summary>
        private JoinPartsUAcs _joinPartsUAcs;

        // 在庫情報格納ディクショナリー
        private Dictionary<string, ArrayList> _storeDic;
        
        // 結合元メーカーコード
        private int _joinSourceMakerCode;

        // 結合元品番
        private string _joinSourPartsNoWithH;

        // 結合商品の品番更新区分
        private bool _joinGoodNoUpdFlg = true;

        /// <summary>商品連結ローカルキャッシュ用データリストクラス</summary>
        private List<GoodsUnitData> _lcGoodsUnitDataList;

        // 編集前の結合先品番
        private string _childGoodsNo = "";

        private bool _deleteBtnFlag = true;

        // ADD START 劉超　2013/12/04 FOR Redmine#41447 ------>>>>>>
        /// <summary>設定ファイル上の列番号は3桁ゼロ詰め</summary>
        static public readonly int ct_ColumnCountLength = 3;
        // ユーザー設定
        private IntegrateMstUserConst _userSetting;
        // 明細グリッドカラムリスト
        private List<ColumnInfo> _detailColumnsList;
        /// <summary>設定XMLファイル名</summary>
        private const string XML_FILE_NAME = "PMKEN09074UB_Construction.XML";
        //初期化フラグ
        private bool _initialLoadFlag = false;
        // ADD END 劉超　2013/12/04 FOR Redmine#41447 ------<<<<<<

        #endregion

        /// public propaty name  :  JoinSourceMakerCode
        /// <summary>結合元メーカーコードプロパティ</summary>
        public int JoinSourceMakerCode
        {
            get { return _joinSourceMakerCode; }
            set { _joinSourceMakerCode = value; }
        }

        /// public propaty name  :  JoinSourPartsNoWithH
        /// <summary>結合元品番プロパティ</summary>
        public string JoinSourPartsNoWithH
        {
            get { return _joinSourPartsNoWithH; }
            set { _joinSourPartsNoWithH = value; }
        }

        /// public propaty name  :  DeleteBtnFlag
        /// <summary>削除ボタンの有効プロパティ</summary>
        public bool DeleteBtnFlag
        {
            get { return _deleteBtnFlag; }
            set { _deleteBtnFlag = value; }
        }

        // ADD START 劉超　2013/12/04 FOR Redmine#41447 ------>>>>>>
        /// <summary>結合マスタユーザー設定</summary>
        public IntegrateMstUserConst UserSetting
        {
            get { return this._userSetting; }
        }

        /// <summary>明細グリッドカラムリスト</summary>
        public List<ColumnInfo> DetailColumnsList
        {
            get { return this._detailColumnsList; }
            set { this._detailColumnsList = value; }
        }

        /// <summary>初期化フラグ</summary>
        public bool InitialLoadFlag
        {
            get { return this._initialLoadFlag; }
            set { this._initialLoadFlag = value; }
        }
        // ADD END 劉超　2013/12/04 FOR Redmine#41447 ------<<<<<<

        # region ◆Event

        /// <summary>グリッド最上位行キーダウンイベント</summary>
        internal event EventHandler GridKeyDownTopRow;

        /// <summary>グリッド最下層行キーダウンイベント</summary>
        internal event EventHandler GridKeyDownButtomRow;
        
        # endregion

        #region ◆Public Methods

        /// <summary>
        /// 結合情報行追加処理
        /// </summary>
        /// <remarks>
        /// </remarks>
        public void AddGoodsDetailRow()
        {
            // No採番のためにデータテーブルの行数をカウントする
            int rowCount = this._goodsDetailDataTable.Rows.Count;

            GoodsSetGoodsDataSet.GoodsSetDetailRow row = this._goodsDetailDataTable.NewGoodsSetDetailRow();
            row.No = (short)(rowCount + 1);
            this._goodsDetailDataTable.AddGoodsSetDetailRow(row);
        }

        /// <summary>
        /// データテーブルグリッドバインド処理
        /// </summary>
        /// <remarks>
        /// </remarks>
        public void SetJoinPartsUGrid()   // MEMO:グリッドの初期設定
        {
            // グリッドに表示するデータテーブルを設定
            uGrid_Details.DataSource = _goodsDetailDataTable;

            // グリッド初期設定
            this.InitialSettingGridCol();

            // ボタンの初期設定
            ButtonInitialSetting();

            // グリッドキーマッピング設定処理
            this.MakeKeyMappingForGrid(this.uGrid_Details);
        }

        /// <summary>
        /// データ行データテーブル格納処理
        /// </summary>
        /// <param name="No">表示No</param>
        /// <param name="goodsUnitData">選択されたデータ行</param>
        /// <param name="unitPriceCalcRet">単価算出結果</param>
        /// <remarks>
        /// <br>UpdateNote : 2011/09/01 周雨 案件一覧 連番984 の対応 選択した在庫が初期表示されるよう修正 FOR redmine #24263</br>
        /// </remarks>
        // --- UPD 2013/10/08 T.Miyamoto ------------------------------>>>>>
        //public void SetJoinPartsUDataTable(int No, GoodsUnitData goodsUnitData)
        public void SetJoinPartsUDataTable(int No, GoodsUnitData goodsUnitData, UnitPriceCalcRet unitPriceCalcRet)
        // --- UPD 2013/10/08 T.Miyamoto ------------------------------<<<<<
        {
            this._goodsDetailDataTable.BeginLoadData();

            // 表示行
            GoodsSetGoodsDataSet.GoodsSetDetailRow detailRow;

            // 空の入力行以上データが存在する場合は新規行を作ってデータを格納
            if (No > _defaultRowCnt)
            {
                detailRow = this._goodsDetailDataTable.NewGoodsSetDetailRow();
            }
            // 空の入力行以下の場合は存在する行数と変数Noが一致する行を更新する
            else
            {
                detailRow = (GoodsSetGoodsDataSet.GoodsSetDetailRow)this._goodsDetailDataTable.Rows.Find((short)No);
            }

            // 必要な項目だけグリッド表示データテーブルにセット
            detailRow.No = (short)No;                                                   // No
            detailRow.Disply = goodsUnitData.JoinDispOrder;                             // 表示順位
            detailRow.GoodsCode = goodsUnitData.GoodsNo;                                // 品番
            detailRow.GoodsName = goodsUnitData.GoodsName;                              // 品名
            // DEL 2009/04/09 ------>>>
            //detailRow.MakerCode = goodsUnitData.GoodsMakerCd.ToString("d04");           // メーカーコード
            //detailRow.MakerName = goodsUnitData.MakerName;                              // メーカー名称
            // DEL 2009/04/09 ------<<<
            
            // ADD 2009/04/09 ------>>>
            if (goodsUnitData.GoodsMakerCd == 0)
            {
                detailRow.MakerCode = string.Empty;
                detailRow.MakerName = string.Empty;
            }
            else
            {
                detailRow.MakerCode = goodsUnitData.GoodsMakerCd.ToString("d04");           // メーカーコード
                detailRow.MakerName = goodsUnitData.MakerName;                              // メーカー名称
            }
            // ADD 2009/04/09 ------<<<

            detailRow.Qty = goodsUnitData.JoinQty.ToString("##0.00");                   // ＱＴＹ(数量)
            detailRow.SetNote = goodsUnitData.JoinSpecialNote;                          // 結合規格・特記事項

            //detailRow.OfferDate = goodsUnitData.OfferDate;        // 提供日付
            // 2009/07/16 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //行削除時のnull値をエラー防ぐため
            detailRow.OfferDate = "";        // 提供日付
            // 2009/07/16 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<
            
            // 価格リストから現在の価格を取得
            GoodsPrice goodsPrice = this._joinPartsUAcs.GetGoodsPriceFromGoodsPriceList(goodsUnitData.GoodsPriceList);
            if (goodsPrice != null)
            {
                detailRow.Price = goodsPrice.ListPrice;                                 // 標準価格
                detailRow.Cost = goodsPrice.SalesUnitCost;                              // 原単価
            }
            // 2009.03.26 30413 犬飼 結合先商品の商品マスタ削除チェック >>>>>>START
            else
            {
                // 初期値設定
                detailRow.Price = 0.0;                                                  // 標準価格
                detailRow.Cost = 0.0;                                                   // 原単価
            }
            // 2009.03.26 30413 犬飼 結合先商品の商品マスタ削除チェック <<<<<<END
            // --- ADD 2013/10/08 T.Miyamoto ------------------------------>>>>>
            if (unitPriceCalcRet != null)
            {
                detailRow.Cost = unitPriceCalcRet.UnitPriceTaxExcFl; // 原単価
            }
            // --- ADD 2013/10/08 T.Miyamoto ------------------------------<<<<<
            
            // 倉庫リストの情報を取得
            //if (goodsUnitData.StockList.Count != 0)
            if ((goodsUnitData.StockList != null) && (goodsUnitData.StockList.Count != 0))  // 2009.03.26 削除チェック対応
            {
                // --- UPD 2013/10/03 T.Miyamoto ------------------------------>>>>>
                ///* -------------------- DEL 2011/09/01 --------------------- >>>>>
                //detailRow.StoreCode = goodsUnitData.StockList[0].WarehouseCode;         // 倉庫コード
                //detailRow.Store = goodsUnitData.StockList[0].WarehouseName;             // 倉庫名称
                //detailRow.ShelfNo = goodsUnitData.StockList[0].WarehouseShelfNo;        // 棚番
                //detailRow.Stock = goodsUnitData.StockList[0].ShipmentPosCnt;            // 現在庫
                //----------------------- DEL 2011/09/01 --------------------- <<<<<*/
                //// ----------------- ADD 2011/09/01 ------------------- >>>>>
                //Stock stock = new Stock();
                //foreach (Stock stockBak in goodsUnitData.StockList)
                //{
                //    if (stockBak.WarehouseCode == goodsUnitData.SelectedWarehouseCode)
                //    {
                //        stock = stockBak;
                //    }
                //}
                //detailRow.Store = stock.WarehouseName;                            // 倉庫名称
                //detailRow.ShelfNo = stock.WarehouseShelfNo;                       // 棚番
                //detailRow.Stock = stock.ShipmentPosCnt;                           // 現在庫
                //detailRow.StoreCode = stock.WarehouseCode;                        // 倉庫コード
                //// ----------------- ADD 2011/09/01 ------------------- <<<<<
                detailRow.StoreCode = goodsUnitData.StockList[0].WarehouseCode;         // 倉庫コード
                detailRow.Store = goodsUnitData.StockList[0].WarehouseName;             // 倉庫名称
                detailRow.ShelfNo = goodsUnitData.StockList[0].WarehouseShelfNo;        // 棚番
                detailRow.Stock = goodsUnitData.StockList[0].ShipmentPosCnt;            // 現在庫
                // --- UPD 2013/10/03 T.Miyamoto ------------------------------<<<<<

                // 在庫情報リストの作成
                string key = goodsUnitData.GoodsNo + "-" + goodsUnitData.GoodsMakerCd.ToString("d4");
                if (!this._storeDic.ContainsKey(key))
                {
                    ArrayList storeList = new ArrayList();
                    foreach (Stock wkStock in goodsUnitData.StockList)
                    {
                        JoinPartsUAcs.F_DATA_STORE dataStore = new JoinPartsUAcs.F_DATA_STORE();
                        dataStore.joinDestMakerCd = goodsUnitData.GoodsMakerCd;
                        dataStore.joinDestPartsNo = goodsUnitData.GoodsNo;
                        dataStore.store = wkStock.WarehouseName;
                        dataStore.shelfNo = wkStock.WarehouseShelfNo;
                        dataStore.stock = wkStock.ShipmentPosCnt;
                        dataStore.storeCode = wkStock.WarehouseCode;

                        if (!storeList.Contains(dataStore))
                        {
                            storeList.Add(dataStore);
                        }
                    }
                    this._storeDic.Add(key, storeList);
                }
            }
            // 2009/07/16 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            else
            {
                detailRow.StoreCode = "";
                detailRow.Store = "";
                detailRow.ShelfNo = "";
                detailRow.Stock = 0;
            }
            // 2009/07/16 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<


            // 新規行のときのみ新しい行を追加するためAdd処理が必要
            if (No > _defaultRowCnt)
            {
                this._goodsDetailDataTable.AddGoodsSetDetailRow(detailRow);
            }

            // 提供データ行を編集不可とする
            // -- UPD 2009/10/30 ------------------------------>>>
            //表示順位１００番以降を提供データとする
            //if (!this._joinPartsUAcs.CheckDivision(goodsUnitData))
            if (goodsUnitData.JoinDispOrder >= 100)
            // -- UPD 2009/10/30 ------------------------------<<<
            {
                // 提供データ
                detailRow.OfferKubun = "0";
                detailRow.EditFlg = false;                                              // 編集可否フラグ

                int rowIdx = No - 1;
                this.uGrid_Details.Rows[rowIdx].Cells[this._goodsDetailDataTable.DisplyColumn.ColumnName].Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                this.uGrid_Details.Rows[rowIdx].Cells[this._goodsDetailDataTable.GoodsCodeColumn.ColumnName].Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                this.uGrid_Details.Rows[rowIdx].Cells[this._goodsDetailDataTable.QtyColumn.ColumnName].Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                this.uGrid_Details.Rows[rowIdx].Cells[this._goodsDetailDataTable.SetNoteColumn.ColumnName].Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            }
            else
            {
                // ユーザデータ
                detailRow.OfferKubun = "1";
                detailRow.EditFlg = true;                                               // 編集可否フラグ

                // Tab制御
                int rowIdx = No - 1;
                this.uGrid_Details.Rows[rowIdx].Cells[this._goodsDetailDataTable.QtyColumn.ColumnName].TabStop = Infragistics.Win.DefaultableBoolean.True;
                this.uGrid_Details.Rows[rowIdx].Cells[this._goodsDetailDataTable.SetNoteColumn.ColumnName].TabStop = Infragistics.Win.DefaultableBoolean.True;
            }

            detailRow.AddFlag = false;                                                  // 追加フラグ
            
            this._goodsDetailDataTable.EndLoadData();
        }

        /// <summary>
        /// 削除対象データテーブル格納処理
        /// </summary>
        /// <param name="deleteDataList">選択されたデータ行</param>
        /// <remarks>
        /// </remarks>
        public void GetDeleteData(out List<GoodsSetGoodsDataSet.GoodsSetDetailRow> deleteDataList)
        {
            deleteDataList = new List<GoodsSetGoodsDataSet.GoodsSetDetailRow>();

            // 削除対象データテーブルの件数をカウント
            int totalCnt = this._deleteGoodsDetailDataTable.Rows.Count;

            for (int i = 0; i < totalCnt; i++)
            {
                GoodsSetGoodsDataSet.GoodsSetDetailRow row = (GoodsSetGoodsDataSet.GoodsSetDetailRow)this._deleteGoodsDetailDataTable.Rows[i];

                // 削除対象データテーブルを追加
                deleteDataList.Add(row);
            }
        }

        /// <summary>
        /// データテーブルクリア処理
        /// </summary>
        /// <remarks>
        /// </remarks>
        public void ClearGoodsSetDataTable()
        {
            this._goodsDetailDataTable.Clear();

            // 削除データテーブル
            this._deleteGoodsDetailDataTable.Clear();

            //this.uGrid_Details.DataSource = null;   // ADD 2008/10/24 不具合対応[7009] // DEL 劉超　2013/12/04 FOR Redmine#41447

            // ローカルキャッシュをクリア
            this._lcGoodsUnitDataList.Clear();
        }

        /// <summary>
        /// データテーブルリセット処理
        /// </summary>
        /// <remarks>
        /// </remarks>
        public void ResetGoodsSetDataTable()
        {
            this._goodsDetailDataTable.Reset();

            // 削除データテーブル
            this._deleteGoodsDetailDataTable.Reset();
        }

        /// <summary>
        /// グリッド入力許可制御処理
        /// </summary>
        /// <remarks>
        /// </remarks>
        public void GridInputPermissionControl(bool enabled)
        {
            this.uGrid_Details.Enabled = enabled;
        }

        /// <summary>
        /// グリッドボタン許可制御処理
        /// </summary>
        /// <remarks>
        /// </remarks>
        public void GridButtonPermissionControl(bool enabled)
        {
            //this.uButton_JoinSource.Enabled = enabled;  // DEL gezh 2014/01/21 Redmine#41447
            this.uButton_JoinDest.Enabled = enabled;
        }

        /// <summary>
        /// グリッド内入力チェック
        /// </summary>
        /// <return>RESULT</return>
        /// <remarks>
        /// </remarks>
        public bool GridDataCheck(ref Control control, ref string message)
        {
            bool result;
            int errorRowNo;
            string errorColNm;

            int errorDispNo;

            // 2009.03.26 30413 犬飼 結合先商品の商品マスタ削除チェック >>>>>>START
            #region ●削除チェック
            this.CheckDeleteData(out errorRowNo);
            if (errorRowNo != 0)
            {
                message = "結合先情報の [ " + errorRowNo + " ] 行目が商品マスタから削除されています。";
                control = this.uGrid_Details;
                result = false;
                return result;
            }
            #endregion
            // 2009.03.26 30413 犬飼 結合先商品の商品マスタ削除チェック <<<<<<END

            List<GoodsSetGoodsDataSet.GoodsSetDetailRow> effectDataList = new List<GoodsSetGoodsDataSet.GoodsSetDetailRow>();
            
            #region ●有効データチェック
            
            #region < 有効データ件数取得 >
            this.GetEffectiveData(out errorRowNo, out errorColNm, out effectDataList);
            #endregion

            #region < 必須入力チェック >
            if (errorColNm != "")
            {
                message = "結合先情報の [ " + errorRowNo + " ] 行目の" + errorColNm + "を入力してください。";
                control = this.uGrid_Details;
                result = false;
                return result;
            }

            // 2010/07/14 Add >>>
            List<GoodsSetGoodsDataSet.GoodsSetDetailRow> deleteDataList;
            List<JoinPartsU> delDataList = new List<JoinPartsU>();

            // 削除対象データの取得
            this.GetDeleteData(out deleteDataList);
            // 2010/07/14 Add <<<

            // 2010/07/14 >>>
            //if (effectDataList.Count == 0)
            if (effectDataList.Count == 0 && deleteDataList.Count == 0)
            // 2010/07/14 <<<
            {
                message = "結合先情報を入力してください。";
                control = this.uGrid_Details;
                result = false;
                return result;
            }
            #endregion

            #region < 無効データ件数チェック>
            if (errorRowNo != 0)
            {
                message = "結合先情報の [ " + errorRowNo + " ] 行目を正しく入力してください。";
                control = this.uGrid_Details;
                result = false;
                return result;
            }
            #endregion

            #endregion

            #region ●結合元商品と同一商品チェック
            this.CheckParentOverlapData(out errorRowNo, effectDataList);

            #region -- 結合元商品と同一商品有り --
            if (errorRowNo != 0)
            {
                message = "結合先情報の [ " + errorRowNo + " ] 行目が結合元商品と同一です";
                control = this.uGrid_Details;
                result = false;
                return result;
            }
            #endregion
            #endregion

            #region ●重複チェック
            this.CheckOverlapData(out errorRowNo, out errorDispNo, effectDataList);

            #region -- 重複有り --
            if (errorRowNo != 0)
            {
                message = "結合先情報の [ " + errorRowNo + " ] 行目が重複しています";
                control = this.uGrid_Details;
                result = false;
                return result;
            }
            #endregion

            #region -- 表示順位の重複有り --
            if (errorDispNo != 0)
            {
                // 2010/01/05 >>>
                //message = "結合先情報の [ " + errorDispNo + " ] 行目の表示順位が重複\nまたは入力範囲(1～50)から外れています";
                message = "結合先情報の [ " + errorDispNo + " ] 行目の表示順位が重複\nまたは入力範囲(0～50)から外れています";
                // 2010/01/05 <<<
                control = this.uGrid_Details;
                result = false;
                return result;
            }
            #endregion

            #endregion

            result = true;
            return result;
        }

        /// <summary>
        /// 商品マスタ削除データチェック
        /// </summary>
        /// <param name="errorRowNo">エラー行番号</param>
        /// <remarks>
        /// </remarks>
        public void CheckDeleteData(out int errorRowNo)
        {
            // エラーが行番号(0 が正常終了)
            errorRowNo = 0;

            // データテーブルの総件数をカウントし、その中でデータが入力されている行のみチェックを行う
            int totalCnt = this._goodsDetailDataTable.Rows.Count;

            for (int i = 0; i < totalCnt; i++)
            {
                GoodsSetGoodsDataSet.GoodsSetDetailRow row = (GoodsSetGoodsDataSet.GoodsSetDetailRow)this._goodsDetailDataTable.Rows[i];

                if (row.EditFlg)
                {
                    // 品名が空白のデータは無効
                    if (row.MakerCode != "" && row.GoodsCode != "")
                    {
                        if (row.GoodsName.Trim() == "")
                        {
                            // 無効データ行の行番号
                            errorRowNo = (int)row.No;
                            return;
                        }
                    }
                }
                // ADD 2009/04/09 ------>>>
                else if (row.MakerCode == "" && row.GoodsCode == "")
                {
                    // 空データなので何もしない
                }
                // 無効データ
                else
                {
                    if (row.GoodsName.Trim() == "")
                    {
                        // 無効データ行の行番号
                        errorRowNo = (int)row.No;
                        return;
                    }
                }
                // ADD 2009/04/09 ------<<<
            }
        }

        /// <summary>
        /// 有効データテーブル行取得処理
        /// </summary>
        /// <param name="errorRowNo">エラー行番号</param>
        /// <param name="errorColNm">エラー列名称</param>
        /// <param name="effectDataList">有効データ行リスト</param>
        /// <remarks>
        /// <br>--------------------------------------------------------------------------------------</br>
        /// Note			:	データテーブルの中から有効なデータ行のリストを取得する処理を行います。<br />
        /// Programmer		:	30005 木建　翼<br />
        /// Date			:	2007.05.14<br />
        /// <br>--------------------------------------------------------------------------------------</br>
          /// </remarks>
        public void GetEffectiveData(out int errorRowNo, out string errorColNm, out List<GoodsSetGoodsDataSet.GoodsSetDetailRow> effectDataList)
        {
            // エラーが行番号(0 が正常終了)
            errorRowNo = 0;
            errorColNm = "";
            effectDataList = new List<GoodsSetGoodsDataSet.GoodsSetDetailRow>();

            // データテーブルの総件数をカウントし、その中でデータが入力されている行のみチェックを行う
            int totalCnt = this._goodsDetailDataTable.Rows.Count;

            for (int i = 0; i < totalCnt ; i++)
            {
                GoodsSetGoodsDataSet.GoodsSetDetailRow row = (GoodsSetGoodsDataSet.GoodsSetDetailRow)this._goodsDetailDataTable.Rows[i];

                if (row.EditFlg)
                {
                    // 全カラムが入力されている(☆有効データ)
                    //if (row.MakerCode != 0 && row.GoodsCode != "")
                    if ((row.MakerCode != "") && (row.GoodsCode != ""))
                    {
                        // DEL 2009/06/24 ------>>>
                        //double qty = 0.0;
                        //if ((!double.TryParse(row.Qty, out qty)) || (qty == 0.0))
                        //{
                        //    // 無効データ行の行番号
                        //    errorRowNo = (int)row.No;
                        //    errorColNm = this._goodsDetailDataTable.QtyColumn.Caption;
                        //    return;
                        //}
                        // DEL 2009/06/24 ------<<<
                        
                        effectDataList.Add(row);
                    }
                    // 提供データ
                    else if (row.OfferKubun != "1")
                    {
                        // 処理対象データとしない
                    }
                    // 全カラムが入力されていない。(☆有効データ)
                    else if (row.MakerCode == "" && row.GoodsCode == "")
                    {
                        // 空データなので何もしない
                    }
                    // 無効データ
                    else
                    {
                        // 無効データ行の行番号
                        errorRowNo = (int)row.No;
                        return;
                    }
                }
            }
        }

        /// <summary>
        /// 親商品との同一品チェック処理
        /// </summary>
        /// <param name="errorRowNo">エラー行番号</param>
        /// <param name="effectDataList">有効データ行リスト</param>
        /// <remarks>
        /// </remarks>
        public void CheckParentOverlapData(out int errorRowNo, List<GoodsSetGoodsDataSet.GoodsSetDetailRow> effectDataList)
        {
            int effectRowCnt;

            // 有効データ全件数取得
            effectRowCnt = effectDataList.Count;

            errorRowNo = 0;

            #region < 比較対象行を設定し全件比較 >
            for (int i = 0; i < effectRowCnt; i++)
            {
                GoodsSetGoodsDataSet.GoodsSetDetailRow targetRow = effectDataList[i];
                List<int> equalRowNoList = new List<int>();

                #region - 結合元商品の品番、メーカーと同一比較 -
                if ((targetRow.GoodsCode == this.JoinSourPartsNoWithH) &&
                    (int.Parse(targetRow.MakerCode) == this.JoinSourceMakerCode))
                {
                    equalRowNoList.Add((int)targetRow.No);
                }
                #endregion

                #region -- 結合元商品同一Noチェック --
                if (equalRowNoList.Count > 0)
                {
                    // 結合元商品の品番、メーカーと同一の結合先商品の行番号を取得して引数に格納
                    errorRowNo = equalRowNoList[equalRowNoList.Count - 1];
                    return;
                }
                #endregion
            }
            #endregion

            // 重複が存在しなかったのでエラー番号は０
            errorRowNo = 0;
        }

        /// <summary>
        /// データテーブル行重複チェック処理
        /// </summary>
        /// <param name="errorRowNo">エラー行番号</param>
        /// <param name="errorDispNo">表示順位エラー行番号</param>
        /// <param name="effectDataList">有効データ行リスト</param>
        /// <remarks>
        /// </remarks>
        public void CheckOverlapData(out int errorRowNo, out int errorDispNo, List<GoodsSetGoodsDataSet.GoodsSetDetailRow> effectDataList)
        {
            int effectRowCnt;
            
            // 有効データ全件数取得
            effectRowCnt = effectDataList.Count;

            errorRowNo = 0;
            errorDispNo = 0;
            
            #region < 比較対象行を設定し全件比較 >
            for (int i = 0; i < effectRowCnt; i++)
            {
                GoodsSetGoodsDataSet.GoodsSetDetailRow targetRow = effectDataList[i];
                List<int> equalRowNoList = new List<int>();

                List<int> equalDispNoList = new List<int>();

                // 2010/01/05 >>>
                //if ((targetRow.Disply < 1) || (targetRow.Disply > 50))
                if ((targetRow.Disply < 0) || (targetRow.Disply > 50))
                // 2010/01/05 <<<
                {
                    // 表示順位の範囲が不正
                    equalDispNoList.Add((int)targetRow.No);
                }

                #region -- 比較対象を元に行リストを全件比較 --
                for (int j = 0; j < effectRowCnt; j++)
                {
                    GoodsSetGoodsDataSet.GoodsSetDetailRow compareRow = effectDataList[j];

                    #region - 商品コード比較 -
                    if (
                        targetRow.GoodsCode == compareRow.GoodsCode
                            && targetRow.MakerCode.Equals(compareRow.MakerCode) // ADD 2008/10/22 不具合対応[6574]
                    )
                    {
                        equalRowNoList.Add((int)compareRow.No);
                    }
                    #endregion

                    #region - 表示順位比較 -
                    if (targetRow.Disply == compareRow.Disply)
                    {
                        equalDispNoList.Add((int)compareRow.No);
                    }
                    #endregion
                }
                #endregion

                #region -- 重複Noチェック --
                if (equalRowNoList.Count > 1)
                {
                    // 重複があった最後の行番号を取得して引数に格納
                    errorRowNo = equalRowNoList[equalRowNoList.Count - 1];
                    return ;
                }
                #endregion

                #region -- 重複表示順位チェック --
                if (equalDispNoList.Count > 1)
                {
                    // 重複があった最後の行番号を取得して引数に格納
                    errorDispNo = equalDispNoList[equalDispNoList.Count - 1];
                    return;
                }
                #endregion

            }
            #endregion

            // 重複が存在しなかったのでエラー番号は０
            errorRowNo = 0;
        }

        /// <summary>
        /// グリッド内変更確認処理
        /// </summary>
        /// <return>変更フラグ(ON:変更有  OFF:変更無)</return>
        /// <remarks>
        /// </remarks>
        public bool CheckGridChange()
        {
            return _changeFlg;
        }

        /// <summary>
        /// 検索タイプ取得処理
        /// </summary>
        /// <param name="inputCode">入力されたコード</param>
        /// <param name="searchCode">検索用コード（*を除く）</param>
        /// <returns>0:完全一致検索 1:前方一致検索 2:後方一致検索 3:曖昧検索</returns>
        /// <remarks>
        /// </remarks>
        public int GetSearchType(string inputCode, out string searchCode)
        {
            searchCode = inputCode;
            if (String.IsNullOrEmpty(inputCode)) return 0;

            if (inputCode.Contains("*"))
            {
                string firstString = inputCode.Substring(0, 1);
                string lastString = inputCode.Substring(inputCode.Length - 1, 1);

                if ((firstString == "*") && (lastString == "*"))
                {
                    return 3;
                }
                else if (firstString == "*")
                {
                    return 2;
                }
                else if (lastString == "*")
                {
                    return 1;
                }
                else
                {
                    return 3;
                }
            }
            else
            {
                // *が存在しないため完全一致検索
                return 0;
            }
        }

        /// <summary>
        /// 削除ボタンの有効制御
        /// </summary>
        /// <param name="flag">有効フラグ</param>
        public void uButton_RowDeleteEnabled(bool flag)
        {
            this.uButton_RowDelete.Enabled = flag;
        }

        /// <summary>
        /// Returnキーダウン処理
        /// </summary>
        /// <param name="previousCellCoodinate">移動前のセル座標</param>
        /// <returns>true:セル移動完了 false:セル移動失敗</returns>
        internal bool ReturnKeyDown(out CellCoodinate previousCellCoodinate)    // ADD 2008/11/25 不具合対応[6564] 結合先を新規追加時は「QTY」へ強制フォーカス遷移　※パラメータ：out CellCoodinateを追加
        {
            previousCellCoodinate = new CellCoodinate(0, 0);    // ADD 2008/11/25 不具合対応[6564] 結合先を新規追加時は「QTY」へ強制フォーカス遷移

            if (this.uGrid_Details.ActiveCell == null) return false;
            Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.uGrid_Details.ActiveCell;

            // ADD 2008/11/25 不具合対応[6564] 結合先を新規追加時は「QTY」へ強制フォーカス遷移 ---------->>>>>
            previousCellCoodinate.Row = cell.Row.Index;
            previousCellCoodinate.Column = cell.Column.Index;
            Debug.WriteLine("Cell( " + previousCellCoodinate.Row.ToString() + ", " + previousCellCoodinate.Column.ToString() + " )");
            // ADD 2008/11/25 不具合対応[6564] 結合先を新規追加時は「QTY」へ強制フォーカス遷移 ----------<<<<<

            int goodsRowNo = this._goodsDetailDataTable[cell.Row.Index].No;

            // DEL START 劉超　2013/12/04 FOR Redmine#41447 ------>>>>>>
            //// 2009.02.09 30413 犬飼 品番なしのフォーカス制御を追加 >>>>>>START
            ////bool canMove;
            ////canMove = this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextCellByTab);
            //bool canMove = true;
            //canMove = this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextCellByTab);

            //if (!this._joinGoodNoUpdFlg)
            //{
            //    this._joinGoodNoUpdFlg = true;
            //    canMove = this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.PrevCellByTab);
            //}
            //// 2009.02.09 30413 犬飼 品番なしのフォーカス制御を追加 <<<<<<END
            // DEL START 劉超　2013/12/04 FOR Redmine#41447 ------<<<<<
            // ADD START 劉超　2013/12/04 FOR Redmine#41447 ------>>>>>>
            if (this.uGrid_Details.ActiveCell == null) return false;

            bool canMove = this.MoveNextAllowEditCell(false);

            return canMove;
            // ADD START 劉超　2013/12/04 FOR Redmine#41447 ------<<<<<
        }

        #endregion

        #region Returnキーダウン処理(Shift+TAB用)
        /// <summary>
        /// Returnキーダウン処理(Shift+TAB用)
        /// </summary>
        /// <returns>true:セル移動完了 false:セル移動失敗</returns>
        internal bool ReturnKeyDown2()
        {
            if (this.uGrid_Details.ActiveCell == null) return false;
            Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.uGrid_Details.ActiveCell;

            bool canMove = true;

            #region ●ActiveCellが表示順位
            if (cell.Column.Key == this._goodsDetailDataTable.DisplyColumn.ColumnName)
            {
                canMove = this.MovePrevAllowEditCell(false);
            }
            #endregion

            #region ●ActiveCellが品番
            else if (cell.Column.Key == this._goodsDetailDataTable.GoodsCodeColumn.ColumnName)
            {
                // 2009.02.09 30413 犬飼 品番なしのフォーカス制御を追加 >>>>>>START
                //canMove = this.MovePrevAllowEditCell(false);
                canMove = this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.PrevCellByTab);

                if (!this._joinGoodNoUpdFlg)
                {
                    this._joinGoodNoUpdFlg = true;
                    canMove = this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextCellByTab);
                }
                // 2009.02.09 30413 犬飼 品番なしのフォーカス制御を追加 <<<<<<END
            }
            #endregion

            #region ●ActiveCellが品名
            else if (cell.Column.Key == this._goodsDetailDataTable.GoodsNameColumn.ColumnName)
            {
                canMove = this.MovePrevAllowEditCell(false);
            }
            #endregion

            #region ●ActiveCellがメーカー名称
            else if (cell.Column.Key == this._goodsDetailDataTable.MakerNameColumn.ColumnName)
            {
                canMove = this.MovePrevAllowEditCell(false);
            }
            #endregion

            #region ●ActiveCellがメーカーコード
            else if (cell.Column.Key == this._goodsDetailDataTable.MakerCodeColumn.ColumnName)
            {
                canMove = this.MovePrevAllowEditCell(false);
            }
            #endregion

            #region ●ActiveCellがＱＴＹ
            else if (cell.Column.Key == this._goodsDetailDataTable.QtyColumn.ColumnName)
            {
                canMove = this.MovePrevAllowEditCell(false);
            }
            #endregion

            #region ●ActiveCellがセット規格・特記事項
            else if (cell.Column.Key == this._goodsDetailDataTable.SetNoteColumn.ColumnName)
            {
                canMove = this.MovePrevAllowEditCell(false);
            }
            #endregion

            return canMove;
        }

        
        #endregion
        
        #region ◆Private Methods

        /// <summary>
        /// グリッド列初期設定処理
        /// </summary>
        /// <remarks>
        /// </remarks>
        private void InitialSettingGridCol()
        {
            // ガイドボタンのアイコン
            this._guideButtonImage = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];
            
            // 入力フォーム画面表示のためデータテーブル初期化
            this._goodsDetailDataTable.Clear();

            // ADD 2008/11/06 不具合対応[6568] 倉庫コードを表示 ---------->>>>>
            if (InitialLoadFlag)       // ADD 劉超　2013/12/04 FOR Redmine#41447 
            {    // ADD 劉超　2013/12/04 FOR Redmine#41447
                #region ●表示列順

                int visiblePosition = 0;
                this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.NoColumn.ColumnName].Header.VisiblePosition = visiblePosition++;       // No
                this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.DisplyColumn.ColumnName].Header.VisiblePosition = visiblePosition++;   // 表示順位
                this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.GoodsCodeColumn.ColumnName].Header.VisiblePosition = visiblePosition++;// 品番
                this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.GoodsNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;// 品名
                this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.MakerCodeColumn.ColumnName].Header.VisiblePosition = visiblePosition++;// メーカーコード 
                this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.MakerNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;// メーカー名称
                this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.QtyColumn.ColumnName].Header.VisiblePosition = visiblePosition++;      // QTY
                this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.SetNoteColumn.ColumnName].Header.VisiblePosition = visiblePosition++;  // 結合規格・特記事項
                this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.OfferDateColumn.ColumnName].Header.VisiblePosition = visiblePosition++;// 提供日付
                this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.PriceColumn.ColumnName].Header.VisiblePosition = visiblePosition++;    // 標準価格
                this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.CostColumn.ColumnName].Header.VisiblePosition = visiblePosition++;     // 原単価
                this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.StoreCodeColumn.ColumnName].Header.VisiblePosition = visiblePosition++;// 倉庫コード
                this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.StoreColumn.ColumnName].Header.VisiblePosition = visiblePosition++;    // 倉庫
                this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.ShelfNoColumn.ColumnName].Header.VisiblePosition = visiblePosition++;  // 棚番
                this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.StockColumn.ColumnName].Header.VisiblePosition = visiblePosition++;    // 現在庫
                // TODO:列順とタブインデックスは合わせること
                int tabIndex = 0;
                this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.NoColumn.ColumnName].TabIndex = tabIndex++;
                this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.DisplyColumn.ColumnName].TabIndex = tabIndex++;
                this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.GoodsCodeColumn.ColumnName].TabIndex = tabIndex++;
                this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.GoodsNameColumn.ColumnName].TabIndex = tabIndex++;
                this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.MakerCodeColumn.ColumnName].TabIndex = tabIndex++;
                this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.MakerNameColumn.ColumnName].TabIndex = tabIndex++;
                this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.QtyColumn.ColumnName].TabIndex = tabIndex++;
                this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.SetNoteColumn.ColumnName].TabIndex = tabIndex++;
                this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.OfferDateColumn.ColumnName].TabIndex = tabIndex++;
                this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.PriceColumn.ColumnName].TabIndex = tabIndex++;
                this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.CostColumn.ColumnName].TabIndex = tabIndex++;
                this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.StoreCodeColumn.ColumnName].TabIndex = tabIndex++;
                this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.StoreColumn.ColumnName].TabIndex = tabIndex++;
                this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.ShelfNoColumn.ColumnName].TabIndex = tabIndex++;
                this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.StockColumn.ColumnName].TabIndex = tabIndex++;

                #endregion  // ●表示列順

                #region ●表示幅設定
                this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.NoColumn.ColumnName].Width = 50;                   // No

                this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.DisplyColumn.ColumnName].PerformAutoResize();      // 表示順位
                this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.GoodsCodeColumn.ColumnName].Width = 200;           // 商品コード
                this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.GoodsNameColumn.ColumnName].Width = 300;           // 商品名称
                this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.MakerCodeColumn.ColumnName].Width = 100;           // メーカーコード 
                this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.MakerNameColumn.ColumnName].Width = 150;           // メーカー名称
                this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.QtyColumn.ColumnName].Width = 80;                  // MOD 2008/11/07 不具合対応[6568] QTYは編集可能 .PerformAutoResize()→.Width = 100
                this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.SetNoteColumn.ColumnName].Width = 300;             // セット規格・特記事項
                this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.PriceColumn.ColumnName].Width = 100;               // 標準価格
                this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.CostColumn.ColumnName].Width = 100;                // 原単価
                this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.StoreColumn.ColumnName].Width = 100;               // 倉庫
                this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.ShelfNoColumn.ColumnName].Width = 100;             // 棚番
                this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.StockColumn.ColumnName].Width = 100;               // 現在庫
                this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.StoreCodeColumn.ColumnName].Width = 100;           // ADD 2008/11/06 不具合対応[6568] 倉庫コードを表示

                #endregion

                InitialLoadFlag = false; // ADD 劉超　2013/12/04 FOR Redmine#41447
            } // ADD 劉超　2013/12/04 FOR Redmine#41447

            #region ●セル内のデータ表示位置設定
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.NoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.DisplyColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.MakerCodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.MakerNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.GoodsCodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.GoodsNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.SetNoteColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.QtyColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;            // QTY
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.PriceColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;          // 標準価格
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.CostColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;           // 原単価
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.StoreColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;           // 倉庫
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.ShelfNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;         // 棚番
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.StockColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;          // 現在庫
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.StoreCodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right; // ADD 2008/11/06 不具合対応[6568] 倉庫コードを表示
            #endregion

            #region ●セル内の入力項目大文字小文字設定
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.GoodsCodeColumn.ColumnName].CharacterCasing = CharacterCasing.Normal;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.SetNoteColumn.ColumnName].CharacterCasing = CharacterCasing.Upper;
            #endregion

            #region ●表示カーソル設定
            //this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.MakerGuideButtonColumn.ColumnName].CellAppearance.Cursor = Cursors.Hand;
            //this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.GoodsGuideButtonColumn.ColumnName].CellAppearance.Cursor = Cursors.Hand;
            #endregion

            #region ●スタイル設定
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.DisplyColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;                 // 表示順位
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.GoodsCodeColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;              // 商品コード
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.GoodsNameColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;              // 商品名称
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.MakerCodeColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;              // メーカーコード 
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.MakerNameColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;              // メーカー名称
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.QtyColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;                    // QTY
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.SetNoteColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;                // セット規格・特記事項
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.PriceColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;                  // 標準価格
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.CostColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;                   // 原単価
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.StoreColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;                  // 倉庫
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.ShelfNoColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;                // 棚番
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.StockColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;                  // 現在庫
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.StoreCodeColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;    // ADD 2008/11/06 不具合対応[6568] 倉庫コードを表示          
            #endregion

            #region ●個別設定

            #region < No >
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.NoColumn.ColumnName].CellAppearance.BackColor = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.BackColor;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.NoColumn.ColumnName].CellAppearance.BackColor2 = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.BackColor2;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.NoColumn.ColumnName].CellAppearance.BackGradientStyle = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.BackGradientStyle;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.NoColumn.ColumnName].CellAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.NoColumn.ColumnName].CellAppearance.ForeColor = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.ForeColor;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.NoColumn.ColumnName].CellAppearance.ForeColorDisabled = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.ForeColor;
            #endregion

            // 提供区分非表示
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.OfferKubunColumn.ColumnName].Hidden = true;
            // 編集フラグ非表示
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.EditFlgColumn.ColumnName].Hidden = true;
            // 提供日付非表示
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.OfferDateColumn.ColumnName].Hidden = true; // ADD 2008/10/21 不具合対応[6567]
            // 追加フラグの非表示
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.AddFlagColumn.ColumnName].Hidden = true;

            #endregion

            #region ●入力制御
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.NoColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;        // No
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.MakerCodeColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;   // メーカー
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.MakerNameColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;   // メーカー名称
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.GoodsNameColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;	 // 商品名称
            
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.OfferDateColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;   // 提供日付
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.PriceColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;       // 標準価格
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.CostColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;        // 原単価
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.StoreColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;       // 倉庫
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.ShelfNoColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;     // 棚番
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.StockColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;       // 現在庫
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.StoreCodeColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;  // ADD 2008/11/06 不具合対応[6568] 倉庫コードを表示   
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.AddFlagColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;       // 追加フラグ
            #endregion

            // ADD 2008/10/21 不具合対応[6564]---------->>>>>
            #region ●フォーカス制御
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.MakerCodeColumn.ColumnName].TabStop = false;   // メーカー
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.MakerNameColumn.ColumnName].TabStop = false;   // メーカー名称
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.GoodsNameColumn.ColumnName].TabStop = false;	// 商品名称
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.QtyColumn.ColumnName].TabStop = false;		    // QTY
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.SetNoteColumn.ColumnName].TabStop = false;     // 結合規格・特記事項
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.OfferDateColumn.ColumnName].TabStop = false;   // 提供日付
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.PriceColumn.ColumnName].TabStop = false;       // 標準価格
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.CostColumn.ColumnName].TabStop = false;        // 原単価
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.StoreColumn.ColumnName].TabStop = false;       // 倉庫
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.ShelfNoColumn.ColumnName].TabStop = false;     // 棚番
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.StockColumn.ColumnName].TabStop = false;       // 現在庫
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.StoreCodeColumn.ColumnName].TabStop = false;   // ADD 2008/11/06 不具合対応[6568] 倉庫コードを表示     
            #endregion
            // ADD 2008/10/21 不具合対応[6559]----------<<<<<

            #region ●フォーマット設定

            string codeFormat = "0000";            
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.MakerCodeColumn.ColumnName].Format = codeFormat;

            const string NUMBER_FORMAT = "N";
            // 標準価格
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.PriceColumn.ColumnName].Format = NUMBER_FORMAT;
            // 原単価
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.CostColumn.ColumnName].Format = NUMBER_FORMAT;
            // 現在庫
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.StockColumn.ColumnName].Format = NUMBER_FORMAT;
            // 倉庫コード
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.StoreCodeColumn.ColumnName].Format = "0000";

            #endregion

            #region ●新規入力行作成

            int count;
            for (count = 1; count <= _defaultRowCnt; count++)
            {
                GoodsSetGoodsDataSet.GoodsSetDetailRow detailRow = this._goodsDetailDataTable.NewGoodsSetDetailRow();
                detailRow.No = (short)count;
                this._goodsDetailDataTable.AddGoodsSetDetailRow(detailRow);
            }

            #endregion

            #region ●変更不可時フォントカラー設定
            // 2007.07.10 add by T-Kidate
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.DisplyColumn.ColumnName].CellAppearance.ForeColorDisabled = Color.Black;               // 表示順位
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.MakerCodeColumn.ColumnName].CellAppearance.ForeColorDisabled = Color.Black;            // メーカーコード 
            //this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.MakerGuideButtonColumn.ColumnName].CellAppearance.ForeColorDisabled = Color.Black;   // メーカーガイドボタン
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.MakerNameColumn.ColumnName].CellAppearance.ForeColorDisabled = Color.Black;            // メーカー名称
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.GoodsCodeColumn.ColumnName].CellAppearance.ForeColorDisabled = Color.Black;            // 商品コード
            //this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.GoodsGuideButtonColumn.ColumnName].CellAppearance.ForeColorDisabled = Color.Black;     // 商品ガイドボタン
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.GoodsNameColumn.ColumnName].CellAppearance.ForeColorDisabled = Color.Black;            // 商品名称
            //this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.CntFlColumn.ColumnName].CellAppearance.ForeColorDisabled = Color.Black;              // 数量
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.SetNoteColumn.ColumnName].CellAppearance.ForeColorDisabled = Color.Black;              // セット規格・特記事項
            //this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.CatalogShapeColumn.ColumnName].CellAppearance.ForeColorDisabled = Color.Black;       // カタログ図番
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.QtyColumn.ColumnName].CellAppearance.ForeColorDisabled = Color.Black;                  // QTY
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.PriceColumn.ColumnName].CellAppearance.ForeColorDisabled = Color.Black;                // 標準価格
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.CostColumn.ColumnName].CellAppearance.ForeColorDisabled = Color.Black;                 // 原単価
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.StoreColumn.ColumnName].CellAppearance.ForeColorDisabled = Color.Black;                // 倉庫
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.ShelfNoColumn.ColumnName].CellAppearance.ForeColorDisabled = Color.Black;              // 棚番
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.StockColumn.ColumnName].CellAppearance.ForeColorDisabled = Color.Black;                // 現在庫
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.StoreCodeColumn.ColumnName].CellAppearance.ForeColorDisabled = Color.Black;    // ADD 2008/11/06 不具合対応[6568] 倉庫コードを表示         
            #endregion

            #region ●左詰め設定
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.GoodsCodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;  // 商品コード
            #endregion

            // 列の入替えを可能にする
            this.uGrid_Details.DisplayLayout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.WithinBand;

            // 列幅の変更を可能にする
            this.uGrid_Details.DisplayLayout.Override.AllowColSizing = Infragistics.Win.UltraWinGrid.AllowColSizing.Free;

            // ADD 2008/10/27 不具合対応[6558]---------->>>>>
            // 1行目の表示順位をアクティブセルに設定
            this.uGrid_Details.Rows[0].Activate();
            this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ActivateCell);
            // ADD 2008/10/27 不具合対応[6558]----------<<<<<
        }

        /// <summary>
		/// ボタン初期設定処理
		/// </summary>
        /// <remarks>
        /// </remarks>
        private void ButtonInitialSetting()
        {
            this._imageList16 = IconResourceManagement.ImageList16;

            this.uButton_StoreChange.ImageList = this._imageList16;
            this.uButton_RowDelete.ImageList = this._imageList16;

            this.uButton_StoreChange.Appearance.Image = (int)Size16_Index.ROWINSERT;
            this.uButton_RowDelete.Appearance.Image = (int)Size16_Index.ROWDELETE;

            this.uButton_StoreChange.Enabled = false;
            if (_deleteBtnFlag)
            {
                // 削除ボタン使用可
                this.uButton_RowDelete.Enabled = true;
            }
            else
            {
                // 削除ボタン使用不可
                this.uButton_RowDelete.Enabled = false;
            }
            this.uButton_JoinSource.Enabled = true;
            // -- 2009/08/04 ------------------>>>
            //新規作成時の初期表示時に結合先ボタンが有効になっているため変更
            //this.uButton_JoinDest.Enabled = true;
            this.uButton_JoinDest.Enabled = false;
            // -- 2009/08/04 ------------------<<<
			
            // 変更フラグOFF
            this._changeFlg = false;
        }

        /// <summary>
        /// グリッドキーマッピング設定処理
        /// </summary>
        /// <param name="grid">設定対象のグリッド</param>
        /// <remarks>
        /// </remarks>
        private void MakeKeyMappingForGrid(Infragistics.Win.UltraWinGrid.UltraGrid grid)
        {
            Infragistics.Win.UltraWinGrid.GridKeyActionMapping enterMap;

            //----- Enterキー
            enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
                Keys.Enter,
                Infragistics.Win.UltraWinGrid.UltraGridAction.NextCellByTab,
                0,
                Infragistics.Win.UltraWinGrid.UltraGridState.Cell,
                Infragistics.Win.SpecialKeys.All,
                0,
                true);
            this.uGrid_Details.KeyActionMappings.Add(enterMap);

            //----- Shift + Enterキー
            enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
                Keys.Enter,
                Infragistics.Win.UltraWinGrid.UltraGridAction.PrevCellByTab,
                0,
                Infragistics.Win.UltraWinGrid.UltraGridState.Cell,
                Infragistics.Win.SpecialKeys.AltCtrl,
                Infragistics.Win.SpecialKeys.Shift,
                true);
            this.uGrid_Details.KeyActionMappings.Add(enterMap);

            //----- ↑キー
            enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
                Keys.Up,
                Infragistics.Win.UltraWinGrid.UltraGridAction.AboveCell,
                Infragistics.Win.UltraWinGrid.UltraGridState.IsDroppedDown,
                Infragistics.Win.UltraWinGrid.UltraGridState.InEdit,
                Infragistics.Win.SpecialKeys.All,
                0,
                true);
            this.uGrid_Details.KeyActionMappings.Add(enterMap);

            //----- ↑キー (最上段のドロップダウンリストでは何もしない。これが無いとリスト項目が変わってしまうので...)
            enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
                Keys.Up,
                Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode,
                Infragistics.Win.UltraWinGrid.UltraGridState.IsDroppedDown,
                Infragistics.Win.UltraWinGrid.UltraGridState.RowFirst | Infragistics.Win.UltraWinGrid.UltraGridState.HasDropdown,
                Infragistics.Win.SpecialKeys.All,
                0,
                true);
            this.uGrid_Details.KeyActionMappings.Add(enterMap);

            //----- ↓キー (最下段のドロップダウンリストでは何もしない。これが無いとリスト項目が変わってしまうので...)
            enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
                Keys.Down,
                Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode,
                Infragistics.Win.UltraWinGrid.UltraGridState.IsDroppedDown,
                Infragistics.Win.UltraWinGrid.UltraGridState.RowLast | Infragistics.Win.UltraWinGrid.UltraGridState.HasDropdown,
                Infragistics.Win.SpecialKeys.All,
                0,
                true);
            this.uGrid_Details.KeyActionMappings.Add(enterMap);

            //----- ↓キー
            enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
                Keys.Down,
                Infragistics.Win.UltraWinGrid.UltraGridAction.BelowCell,
                Infragistics.Win.UltraWinGrid.UltraGridState.IsDroppedDown,
                Infragistics.Win.UltraWinGrid.UltraGridState.InEdit,
                Infragistics.Win.SpecialKeys.All,
                0,
                true);
            this.uGrid_Details.KeyActionMappings.Add(enterMap);

            //----- 前頁キー
            enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
                Keys.Prior,
                Infragistics.Win.UltraWinGrid.UltraGridAction.PageUpCell,
                0,
                Infragistics.Win.UltraWinGrid.UltraGridState.InEdit,
                Infragistics.Win.SpecialKeys.All,
                0,
                true);
            this.uGrid_Details.KeyActionMappings.Add(enterMap);

            //----- 次頁キー
            enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
                Keys.Next,
                Infragistics.Win.UltraWinGrid.UltraGridAction.PageDownCell,
                0,
                Infragistics.Win.UltraWinGrid.UltraGridState.InEdit,
                Infragistics.Win.SpecialKeys.All,
                0,
                true);

            this.uGrid_Details.KeyActionMappings.Add(enterMap);
        }

        /// <summary>
        /// ActiveRowインデックス取得処理
        /// </summary>
        /// <returns>ActiveRowインデックス</returns>
        /// <remarks>
        /// </remarks>
        private int GetActiveRowIndex()
        {
            if (this.uGrid_Details.ActiveCell != null)
            {
                return this.uGrid_Details.ActiveCell.Row.Index;
            }
            else if (this.uGrid_Details.ActiveRow != null)
            {
                return this.uGrid_Details.ActiveRow.Index;
            }
            else
            {
                return -1;
            }
        }

        /// <summary>
        /// 次入力可能セル移動処理
        /// </summary>
        /// <param name="activeCellCheck">true:ActiveCellが入力可能の場合はNextに移動させない false:ActiveCellに関係なくNextに移動させる</param>
        /// <returns>true:セル移動完了 false:セル移動失敗</returns>
        /// <remarks>
        /// </remarks>
        private bool MoveNextAllowEditCell(bool activeCellCheck)
        {
            bool moved = false;
            bool performActionResult = false;

            if ((activeCellCheck) && (this.uGrid_Details.ActiveCell != null))
            {
                if ((this.uGrid_Details.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) &&
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

            return performActionResult;
        }

        /// <summary>
        /// 前入力可能セル移動処理
        /// </summary>
        /// <param name="activeCellCheck">true:ActiveCellが入力可能の場合はPrevに移動させない false:ActiveCellに関係なくPrevに移動させる</param>
        /// <returns>true:セル移動完了 false:セル移動失敗</returns>
        /// <remarks>
        /// </remarks>
        private bool MovePrevAllowEditCell(bool activeCellCheck)    // TODO:グリッドでのShift+Tab
        {
            bool moved = false;
            bool performActionResult = false;

            if ((activeCellCheck) && (this.uGrid_Details.ActiveCell != null))
            {
                if ((this.uGrid_Details.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) &&
                    (this.uGrid_Details.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
                {
                    moved = true;
                }
            }
            else
            {
                while (!moved)
                {
                    if (!this._goodsDetailDataTable[this.uGrid_Details.ActiveCell.Row.Index].EditFlg)   // MOD 2008/03/30 不具合対応[12871] .EditFlg.Equals("1")→.EditFlg
                    {
                        int rowCnt = this.uGrid_Details.ActiveCell.Row.Index;
                        while (!this._goodsDetailDataTable[rowCnt].EditFlg) // MOD 2008/03/30 不具合対応[12871] .EditFlg.Equals("1")→.EditFlg
                        {
                            rowCnt--;
                        }
                        this.uGrid_Details.Rows[rowCnt].Activate();
                        this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ActivateCell);
                        moved = true;
                    }
                    else
                    {
                        performActionResult = this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.PrevCell);

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
                }
            }

            if (moved)
            {
                this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
            }

            return performActionResult;
        }

        /// <summary>
        /// 選択済み結合情報行番号リスト取得処理
        /// </summary>
        /// <returns>選択済み結合情報行番号リスト</returns>
        /// <remarks>
        /// </remarks>
        private List<int> GetSelectedGoodsRowNoList()
        {
            // 選択されたセルを取得
            Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.uGrid_Details.ActiveCell;
            // 選択された行を取得する
            Infragistics.Win.UltraWinGrid.SelectedRowsCollection rows = this.uGrid_Details.Selected.Rows;
            
            if ((cell == null) && (rows == null)) return null;

            List<int> selectedGoodsRowNoList = new List<int>();
            List<int> selectedIndexList = new List<int>();

            if (cell != null)
            {
                selectedGoodsRowNoList.Add(this._goodsDetailDataTable[cell.Row.Index].No);
                selectedIndexList.Add(cell.Row.Index);
            }
            else if (rows != null)
            {
                foreach (Infragistics.Win.UltraWinGrid.UltraGridRow row in rows)
                {
                    selectedGoodsRowNoList.Add(this._goodsDetailDataTable[row.Index].No);
                    selectedIndexList.Add(row.Index);
                }
            }

            return selectedGoodsRowNoList;
        }

        /// <summary>
        /// 結合情報行削除可能チェック処理
        /// </summary>
        /// <param name="goodsRowNoList">削除行StockRowNoリスト</param>
        /// <param name="message">メッセージ</param>
        /// <returns>true:行削除可能 false:行削除不可</returns>
        /// <remarks>
        /// </remarks>
        private bool CanDeleteGoodsDetailRow(List<int> goodsRowNoList, out string message)
        {
            message = "";
            return true;
        }

        /// <summary>
        /// 結合情報行削除処理
        /// </summary>
        /// <param name="goodsRowNoList">削除行Noリスト</param>
        /// <remarks>
        /// </remarks>
        private void DeleteGoodsDetailRow(List<int> goodsRowNoList)
        {
            this.DeleteGoodsDetailRow(goodsRowNoList, false);
        }

        /// <summary>
        /// 結合情報行削除処理(オーバーロード)
        /// </summary>
        /// <param name="goodsRowNoList">削除行StockRowNoリスト</param>
        /// <param name="changeRowCount">true:行数を変更する false:行数を変更するは変更しない</param>
        /// <remarks>
        /// </remarks>
        private void DeleteGoodsDetailRow(List<int> goodsRowNoList, bool changeRowCount)
        {
            this._goodsDetailDataTable.BeginLoadData();
            foreach (int goodsRowNo in goodsRowNoList)
            {
                // 削除対象行情報を取得する
                GoodsSetGoodsDataSet.GoodsSetDetailRow targetRow = this._goodsDetailDataTable.FindByNo((short)goodsRowNo);
                if (targetRow == null) continue;

                // 削除対象行を退避
                if ((targetRow.GoodsCode != "") && (targetRow.MakerCode != "") && (!targetRow.AddFlag))
                {
                    GoodsSetGoodsDataSet.GoodsSetDetailRow row = this._deleteGoodsDetailDataTable.NewGoodsSetDetailRow();
                    // 2010/07/14 >>>
                    //row.No = targetRow.No;
                    row.No = (short)(targetRow.No + this._deleteGoodsDetailDataTable.Rows.Count);
                    // 2010/07/14 <<<
                    row.Disply = targetRow.Disply;
                    row.GoodsCode = targetRow.GoodsCode;
                    row.GoodsName = targetRow.GoodsName;
                    row.MakerCode = targetRow.MakerCode;
                    row.MakerName = targetRow.MakerName;
                    row.Qty = targetRow.Qty;
                    row.SetNote = targetRow.SetNote;
                    row.OfferDate = targetRow.OfferDate;
                    row.Price = targetRow.Price;
                    row.Cost = targetRow.Cost;
                    row.Store = targetRow.Store;
                    row.ShelfNo = targetRow.ShelfNo;
                    row.Stock = targetRow.Stock;
                    row.OfferKubun = targetRow.OfferKubun;
                    row.EditFlg = targetRow.EditFlg;
                    row.StoreCode = targetRow.StoreCode;
                    row.AddFlag = targetRow.AddFlag;
                    this._deleteGoodsDetailDataTable.AddGoodsSetDetailRow(row);
                }
                
                // 対象行削除処理
                this._goodsDetailDataTable.RemoveGoodsSetDetailRow(targetRow);
            }

            // 結合情報データテーブルStockRowNo列初期化処理
            this.InitializeGoodsSetDetailRowNoColumn();

            if (!changeRowCount)
            {
                // 削除した分だけ新規に行を追加する
                for (int i = 0; i < goodsRowNoList.Count; i++)
                {
                    this.AddGoodsDetailRow();
                }
            }
            this._goodsDetailDataTable.EndLoadData();

        }

        /// <summary>
        /// 結合情報データテーブルNo列初期化処理
        /// </summary>
        /// <remarks>
        /// </remarks>
        private void InitializeGoodsSetDetailRowNoColumn()
        {
            this._goodsDetailDataTable.BeginLoadData();

            for (int i = 0; i < this._goodsDetailDataTable.Rows.Count; i++)
            {
                this._goodsDetailDataTable[i].No = (short)(i + 1);
            }

            this._goodsDetailDataTable.EndLoadData();
        }

        /// <summary>
        /// セルアクティブ時ボタン有効無効コントロール処理
        /// </summary>
        /// <param name="index">行インデックス</param>
        /// <remarks>
       /// </remarks>
        private void ActiveCellButtonEnabledControl(int index)
        {
            // 行操作ボタンの有効無効を設定する
            int makerCode = int.Parse(this._goodsDetailDataTable[index].MakerCode); 
            string goodsCode = this._goodsDetailDataTable[index].GoodsCode;

            if (makerCode == 0 && goodsCode == "")
            {
                this.uButton_StoreChange.Enabled = true;
                
            }
        }

        /// <summary>
        /// 結合情報データセッティング処理（商品セット情報設定）
        /// </summary>
        /// <param name="goodsRowNo">結合情報行番号</param>
        /// <param name="goodsUnitData">商品セット内容クラスリスト</param>
        /// <param name="unitPriceCalcRet">単価算出結果</param>
        /// <remarks>
        /// <br>UpdateNote : 2010/12/03 徐佳 結合先品番入力時の例外エラーの修正</br>
        /// <br>UpdateNote : 2011/09/01 周雨 案件一覧 連番984 の対応 選択した在庫が初期表示されるよう修正 FOR redmine #24263</br>
        /// </remarks>
        // --- UPD 2013/10/08 T.Miyamoto ------------------------------>>>>>
        //private void GoodsDetailRowGoodsSetSetting(int goodsRowNo, GoodsUnitData goodsUnitData)
        private void GoodsDetailRowGoodsSetSetting(int goodsRowNo, GoodsUnitData goodsUnitData, UnitPriceCalcRet unitPriceCalcRet)
        // --- UPD 2013/10/08 T.Miyamoto ------------------------------<<<<<
        {
            GoodsSetGoodsDataSet.GoodsSetDetailRow row = this._goodsDetailDataTable.FindByNo((short)goodsRowNo);

            row.Disply    = goodsUnitData.JoinDispOrder;                    // 表示順位
            row.MakerCode = goodsUnitData.GoodsMakerCd.ToString("d04");     // 結合先メーカーコード   
            row.MakerName = goodsUnitData.MakerName;                        // 結合先メーカー名
            row.GoodsCode = goodsUnitData.GoodsNo;                          // 品番
            row.GoodsName = goodsUnitData.GoodsName;                        // 品名
            row.Qty = goodsUnitData.JoinQty.ToString();                     // QTY
            //row.OfferKubun = goodsUnitData.OfferKubun.ToString();         // 提供区分
            row.SetNote = goodsUnitData.JoinSpecialNote;                    // 結合規格・特記事項

            switch (goodsUnitData.OfferKubun)
            {
                case 0:     // ユーザー登録
                case 1:     // 提供純正編集
                case 2:     // 提供優良編集
                    {
                        // ユーザー
                        row.OfferKubun = "0";
                        break;
                    }
                case 3:     // 3:提供純正
                case 4:     // 4:提供優良
                case 5:     // 5:TBO
                case 7:     // 7:オリジナル
                    {
                        // 提供
                        row.OfferKubun = "1";
                        break;
                    }
            }

            //row.OfferDate = goodsUnitData.OfferDate.ToString("yyyy/MM/dd");
            row.EditFlg = true;                                             // 編集可否
            row.AddFlag = true;                                             // 追加フラグ
            
            // 価格設定
            if (goodsUnitData.GoodsPriceList.Count > 0)
            {
                GoodsPrice goodsPrice;

                // 価格リストから現在の価格を取得
                goodsPrice = this._joinPartsUAcs.GetGoodsPriceFromGoodsPriceList(goodsUnitData.GoodsPriceList);
                // ---UPD 2010/12/03 ---------------------------------------->>>>>
                //row.Price = goodsPrice.ListPrice;                           // 標準価格
                //row.Cost = goodsPrice.SalesUnitCost;                        // 原単価
                if (goodsPrice != null)
                {
                    row.Price = goodsPrice.ListPrice;                           // 標準価格
                    row.Cost = goodsPrice.SalesUnitCost;                       // 原単価
                }
                // ---UPD 2010/12/03 ----------------------------------------<<<<<
            }
            // --- ADD 2013/10/08 T.Miyamoto ------------------------------>>>>>
            if (unitPriceCalcRet != null)
            {
                row.Cost = unitPriceCalcRet.UnitPriceTaxExcFl; // 原単価
            }
            // --- ADD 2013/10/08 T.Miyamoto ------------------------------<<<<<

            // 倉庫設定
            if (goodsUnitData.StockList.Count > 0)
            {
                Stock stock = new Stock();
                //stock = goodsUnitData.StockList[0];  // DEL 2011/09/01
                // ----------------- ADD 2011/09/01 ------------------- >>>>>
                foreach (Stock stockBak in goodsUnitData.StockList)
                {
                    if (stockBak.WarehouseCode == goodsUnitData.SelectedWarehouseCode)
                    {
                        stock = stockBak;
                    }
                }
                // ----------------- ADD 2011/09/01 ------------------- <<<<<

                row.Store = stock.WarehouseName;                            // 倉庫名称
                row.ShelfNo = stock.WarehouseShelfNo;                       // 棚番
                row.Stock = stock.ShipmentPosCnt;                           // 現在庫
                row.StoreCode = stock.WarehouseCode;                        // 倉庫コード

                // 在庫情報リストの作成
                string key = goodsUnitData.GoodsNo + "-" + goodsUnitData.GoodsMakerCd.ToString("d4");
                if (!this._storeDic.ContainsKey(key))
                {
                    ArrayList storeList = new ArrayList();
                    foreach (Stock wkStock in goodsUnitData.StockList)
                    {
                        JoinPartsUAcs.F_DATA_STORE dataStore = new JoinPartsUAcs.F_DATA_STORE();
                        dataStore.joinDestMakerCd = goodsUnitData.GoodsMakerCd;
                        dataStore.joinDestPartsNo = goodsUnitData.GoodsNo;
                        dataStore.store = wkStock.WarehouseName;
                        dataStore.shelfNo = wkStock.WarehouseShelfNo;
                        dataStore.stock = wkStock.ShipmentPosCnt;
                        dataStore.storeCode = wkStock.WarehouseCode;

                        if (!storeList.Contains(dataStore))
                        {
                            storeList.Add(dataStore);
                        }
                    }
                    this._storeDic.Add(key, storeList);
                }
            }

            // 次行が存在しない場合は新規に追加する
            if (goodsRowNo == (this._goodsDetailDataTable.Rows.Count + 1))
            {
                this.AddGoodsDetailRow();
            }
        }

        /// <summary>
        /// 結合情報データセッティング処理（メーカー情報設定）
        /// </summary>
        /// <param name="goodsRowNo">結合情報行番号</param>
        /// <param name="makerUMnt">メーカー内容クラスリスト</param>
        /// <remarks>
        /// </remarks>
        private void MakerDetailRowGoodsSetSetting(int goodsRowNo, MakerUMnt makerUMnt)
        {
            GoodsSetGoodsDataSet.GoodsSetDetailRow row = this._goodsDetailDataTable.FindByNo((short)goodsRowNo);

            // ガイドデータ展開
            row.MakerCode = makerUMnt.GoodsMakerCd.ToString("d04");
            row.MakerName = makerUMnt.MakerName;

            // メーカーが設定されたらデータの整合性をあわせるため商品情報をクリアする
            row.GoodsCode = "";
            row.GoodsName = "";
        }

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
        /// <param name="NumberFlg">数値入力可？</param>
        /// <returns>true=入力可,false=入力不可</returns>
        /// <remarks>
        /// </remarks>
        private bool KeyPressNumCheck(int keta, int priod, string prevVal, char key, int selstart, int sellength, Boolean minusFlg, Boolean NumberFlg)
        {
            // 制御キーが押された？
            if (Char.IsControl(key))
            {
                return true;
            }

            // 押されたキーが数値以外、かつ数値以外入力不可
            if (!Char.IsDigit(key) && !NumberFlg)
            {
                return false;
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
                // マイナス(小数点)が入力可能か？
                if (minusFlg == false)
                {
                    return false;
                }
            }

            // 小数点のチェック
            if (key == '.')
            {
                if (priod == 0)
                {
                    return false;
                }
                else
                {
                    // 小数点が既に存在するか？
                    if (_strResult.Contains("."))
                    {
                        return false;
                    }
                }
            }
            else
            {
                // 小数点が既に存在するか？
                if (_strResult.Contains("."))
                {
                    int index = _strResult.IndexOf('.');
                    string strDecimal = _strResult.Substring(index + 1);

                    if ((strDecimal.Length >= priod) && (selstart > index))
                    {
                        // 小数桁が入力可能桁数以上で、カーソル位置が小数点以降
                        return false;
                    }
                    else if (((keta - priod) < index))
                    {
                        // 整数部の桁数が入力可能桁数を超えた
                        return false;
                    }
                }
                else
                {
                    // 小数点桁数を前提に整数部の桁数を決定
                    if (((keta - priod) <= _strResult.Length))
                    {
                        return false;
                    }
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
                else if (_strResult.Contains("."))
                {
                    if (_strResult.Length > (keta + 1))
                    {
                        return false;
                    }
                }
                else if ((_strResult[0] == '-') && (_strResult.Contains(".")))
                {
                    if (_strResult.Length > (keta + 2))
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

        // ADD 2008/11/17 不具合対応[6564] 「QTY」、「結合規格・特記事項」は編集可能 ---------->>>>>
        /// <summary>
        /// 編集可能なレイアウト設定を行います。
        /// </summary>
        /// <param name="no">
        /// 行番号<br/>
        /// ※<c>cell.Rows.Index</c>を指定する場合、内部で -1 されるので、渡すときに +1 すること。
        /// </param>
        private void SetEditableDisplayLayout(int no)
        {
            IList<string> enabledColumnNameList = new List<string>();
            {
                // 表示順
                enabledColumnNameList.Add(this._goodsDetailDataTable.DisplyColumn.ColumnName);
                // 品番
                enabledColumnNameList.Add(this._goodsDetailDataTable.GoodsCodeColumn.ColumnName);
                // QTY
                enabledColumnNameList.Add(this._goodsDetailDataTable.QtyColumn.ColumnName);
                // 結合規格・特記事項
                enabledColumnNameList.Add(this._goodsDetailDataTable.SetNoteColumn.ColumnName);
            }
            foreach (string columnName in enabledColumnNameList)
            {
                bool editFlag = (bool)this.uGrid_Details.DisplayLayout.Rows[no - 1].Cells[this._goodsDetailDataTable.EditFlgColumn.ColumnName].Value;
                if (!editFlag) continue;

                this.uGrid_Details.DisplayLayout.Rows[no - 1].Cells[columnName].Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                this.uGrid_Details.DisplayLayout.Rows[no - 1].Cells[columnName].TabStop = Infragistics.Win.DefaultableBoolean.True;
            }
        }
        // ADD 2008/11/17 不具合対応[6564] 「QTY」、「結合規格・特記事項」は編集可能 ----------<<<<<

        #endregion

        /// <summary>
        /// ボタンEnable設定処理
        /// </summary>
        /// <remarks>
        /// Note			: グリッドで倉庫列が選択された場合に倉庫切替ボタンを有効にする<br />
        /// Programmer		: 30415 柴田 倫幸<br />
        /// Date			: 2008/07/30<br />
        /// </remarks>
        private void SetEnable_Btn()
        {
            if (this.uGrid_Details.ActiveCell == null)
            {
                uButton_StoreChange.Enabled = false;
                uButton_RowDelete.Enabled = false;

                return;
            }

            // 倉庫列？
            if (
                this.uGrid_Details.ActiveCell.Column.Key == this._goodsDetailDataTable.StoreColumn.ColumnName
                // ADD 2008/11/06 不具合対応[6568] 倉庫コードを表示 ---------->>>>>
                    ||
                this.uGrid_Details.ActiveCell.Column.Key.Equals(this._goodsDetailDataTable.StoreCodeColumn.ColumnName)
                // ADD 2008/11/06 不具合対応[6568] 倉庫コードを表示 ----------<<<<<
            )
            {
                // 表示順位列と品番列が空でない場合
                if ((this.uGrid_Details.Rows[this.uGrid_Details.ActiveRow.Index].Cells[this._goodsDetailDataTable.DisplyColumn.ColumnName].Value.ToString() != "") &&
                   (this.uGrid_Details.Rows[this.uGrid_Details.ActiveRow.Index].Cells[this._goodsDetailDataTable.GoodsCodeColumn.ColumnName].Value.ToString() != ""))
                {
                    // 倉庫切替ボタン有効
                    uButton_StoreChange.Enabled = true;
                }
                else
                {
                    // 倉庫切替ボタン無効
                    uButton_StoreChange.Enabled = false;
                }
            }
            else
            {
                // 倉庫切替ボタン無効
                uButton_StoreChange.Enabled = false;
            }

            if (_deleteBtnFlag)
            {
                if ((this.uGrid_Details.Rows[this.uGrid_Details.ActiveRow.Index].Cells[this._goodsDetailDataTable.DisplyColumn.ColumnName].Value.ToString() != "") &&
                   (this.uGrid_Details.Rows[this.uGrid_Details.ActiveRow.Index].Cells[this._goodsDetailDataTable.GoodsCodeColumn.ColumnName].Value.ToString() != ""))
                {
                    // DEL 2009/06/22 ------>>>
                    //// 提供データ？
                    //if ((this.uGrid_Details.Rows[this.uGrid_Details.ActiveRow.Index].Cells[this._goodsDetailDataTable.EditFlgColumn.ColumnName].Value.ToString() != "1"))
                    // DEL 2009/06/22 ------<<<
                    // ADD 2009/06/22 ------>>>
                    // 編集可能データ？
                    if (!(bool)this.uGrid_Details.Rows[this.uGrid_Details.ActiveRow.Index].Cells[this._goodsDetailDataTable.EditFlgColumn.ColumnName].Value)
                    // ADD 2009/06/22 ------<<<
                    {
                        // 削除ボタン使用不可
                        uButton_RowDelete.Enabled = false;
                    }
                    else
                    {
                        // 削除ボタン使用可
                        uButton_RowDelete.Enabled = true;
                    }
                }
                else
                {
                    // 削除ボタン使用可
                    uButton_RowDelete.Enabled = true;
                }
            }
            else
            {
                // 削除ボタン使用不可
                uButton_RowDelete.Enabled = false;
            }
        }

        /// <summary>
        /// 商品連結データ用ローカルキャッシュ取得
        /// </summary>
        /// <param name="goodsUnitDataDic">商品連結データ用ディクショナリー</param>
        /// <remarks>
        /// </remarks>
        public void GetLC_GoodsUnitData(out Dictionary<string, GoodsUnitData> goodsUnitDataDic)
        {
            goodsUnitDataDic = new Dictionary<string, GoodsUnitData>();

            foreach (GoodsUnitData workGoodsUnitData in _lcGoodsUnitDataList)
            {
                // ユーザー登録されていない商品連結データを設定
                switch (workGoodsUnitData.OfferKubun)
                {
                    case 3:     // 3:提供純正
                    case 4:     // 4:提供優良
                    case 5:     // 5:TBO
                    case 7:     // 7:オリジナル
                        {
                            // 品番とメーカーコードをキーとする
                            string key = workGoodsUnitData.GoodsNo + "-" + workGoodsUnitData.GoodsMakerCd.ToString("d04");
                            if (goodsUnitDataDic.ContainsKey(key))
                            {
                                goodsUnitDataDic.Remove(key);
                            }
                            goodsUnitDataDic.Add(key, workGoodsUnitData);
                            break;
                        }
                }
            }
        }

        # region ◆Control Event Methods

        /// <summary>
        /// グリッドセルアクティブ後発生イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void uGrid_Details_AfterCellActivate(object sender, EventArgs e)
        {
            // ボタンEnable設定処理
            // 2010/07/14 Add >>>
            if (this.uGrid_Details.ActiveCell == null) return;

            Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.uGrid_Details.ActiveCell;

            // 数値項目が空の場合
            if (cell.Value is DBNull)
            {
                if ((cell.Column.DataType == typeof(Int32)) ||
                    (cell.Column.DataType == typeof(Int64)) ||
                    (cell.Column.DataType == typeof(double)))
                {
                    cell.Value = 0;
                }
            }
            if ((string.IsNullOrEmpty(this._goodsDetailDataTable[cell.Row.Index]["GoodsCode"].ToString()))
                && (string.IsNullOrEmpty(this._goodsDetailDataTable[cell.Row.Index]["MakerCode"].ToString()))
                && (Convert.ToInt32(_goodsDetailDataTable[cell.Row.Index]["Disply"]) < 100))
            {
                _deleteBtnFlag = false;
            }
            else
            {
                _deleteBtnFlag = true;
            }
            // 2010/07/14 Add <<<
            SetEnable_Btn();
        }

        /// <summary>
        /// Gridアクション処理後イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void uGrid_Details_AfterPerformAction(object sender, Infragistics.Win.UltraWinGrid.AfterUltraGridPerformActionEventArgs e)
        {
            // ADD 2008/11/20 不具合対応[7971] 矢印キーによるセル移動時の編集モード ---------->>>>>　※コメントアウトされていたコードを復活
            switch (e.UltraGridAction)
            {
                case Infragistics.Win.UltraWinGrid.UltraGridAction.ActivateCell:
                case Infragistics.Win.UltraWinGrid.UltraGridAction.AboveCell:
                case Infragistics.Win.UltraWinGrid.UltraGridAction.BelowCell:
                case Infragistics.Win.UltraWinGrid.UltraGridAction.PrevCell:
                case Infragistics.Win.UltraWinGrid.UltraGridAction.NextCell:
                case Infragistics.Win.UltraWinGrid.UltraGridAction.PageUpCell:
                case Infragistics.Win.UltraWinGrid.UltraGridAction.PageDownCell:

                    // アクティブなセルがあるか？または編集可能セルか？
                    if ((this.uGrid_Details.ActiveCell != null) && (this.uGrid_Details.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) && (this.uGrid_Details.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
                    {
                        // アクティブセルのスタイルを取得
                        switch (this.uGrid_Details.ActiveCell.StyleResolved)
                        {
                            // エディット系スタイル
                            case Infragistics.Win.UltraWinGrid.ColumnStyle.Default:
                            case Infragistics.Win.UltraWinGrid.ColumnStyle.Edit:
                            case Infragistics.Win.UltraWinGrid.ColumnStyle.EditButton:
                                {
                                    // 編集モードにある？
                                    if (this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode))
                                    {
                                        if (!(this.uGrid_Details.ActiveCell.Value is System.DBNull))
                                        {
                                            // 全選択状態にする。
                                            this.uGrid_Details.ActiveCell.SelStart = 0;
                                            this.uGrid_Details.ActiveCell.SelLength = this.uGrid_Details.ActiveCell.Text.Length;
                                        }
                                    }
                                    break;
                                }
                            default:
                                {
                                    // エディット系以外のスタイルであれば、編集状態にする。
                                    this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                                    break;
                                }
                        }
                    }
                    break;
            }
            // ADD 2008/11/20 不具合対応[7971] 矢印キーによるセル移動時の編集モード ----------<<<<<
        }

        /// <summary>
        /// グリッドセルアクティブ化前イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void uGrid_Details_BeforeCellActivate(object sender, Infragistics.Win.UltraWinGrid.CancelableCellEventArgs e)
        {
            // 2009.02.09 30413 犬飼 規格特記事項のみIMEをON >>>>>>START
            if (e.Cell.Column.Key == this._goodsDetailDataTable.SetNoteColumn.ColumnName)
            {
                // 規格／特記事項 IMEをON
                this.uGrid_Details.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            }
            else
            {
                // その他 IMEを無効
                this.uGrid_Details.ImeMode = System.Windows.Forms.ImeMode.Disable;
            }
            // 2009.02.09 30413 犬飼 規格特記事項のみIMEをON <<<<<<END
        }

        /// <summary>
        /// グリッドセルアップデート前イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void uGrid_Details_BeforeCellUpdate(object sender, Infragistics.Win.UltraWinGrid.BeforeCellUpdateEventArgs e)
        {
            return;
        }

        /// <summary>
        /// グリッドデータエラー発生イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void uGrid_Details_CellDataError(object sender, Infragistics.Win.UltraWinGrid.CellDataErrorEventArgs e)
        {
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

        /// <summary>
        /// グリッドエンターイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void uGrid_Details_Enter(object sender, EventArgs e)
        {
            // [結合先]ボタンのフォーカス制御
            this.uButton_JoinDest.Enabled = true;   // ADD 2008/11/06 不具合対応[7109] 代替マスタ新旧表示
        }

        // ADD 2008/11/06 不具合対応[7109] 代替マスタ新旧表示 ---------->>>>>
        /// <summary>
        /// 子：結合先情報グリッドのLeaveイベントハンドラ
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        private void uGrid_Details_Leave(object sender, EventArgs e)
        {
            // [結合先]ボタンのフォーカス制御
            //this.uButton_JoinDest.Enabled = false;  // DEL gezh 2014/01/21 Redmine#41447
            // ---------- ADD gezh 2014/01/21 Redmine#41447 ------------------------>>>>>
            if (this.uButton_StoreChange.Focused || this.uButton_JoinDest.Focused)
            {
                this.uButton_JoinDest.Enabled = true;
            }
            // ---------- ADD gezh 2014/01/21 Redmine#41447 ------------------------<<<<<
        }
        // ADD 2008/11/06 不具合対応[7109] 代替マスタ新旧表示 ----------<<<<<

        /// <summary>
        /// グリッドキーダウンイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void uGrid_Details_KeyDown(object sender, KeyEventArgs e)
        {
            #region ■セルが選択されている場合
        if (this.uGrid_Details.ActiveCell != null)
            {
                Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.uGrid_Details.ActiveCell;

                #region ●Escapeキー
                if (e.KeyCode == Keys.Escape)
                {
                    // なにもしない
                }
                #endregion

                #region ●Shiftキー
                if (e.Shift)
                {
                    switch (e.KeyCode)
                    {
                        case Keys.Down:
                            {
                                this.uGrid_Details.ActiveCell = null;
                                this.uGrid_Details.ActiveRow = cell.Row;
                                this.uGrid_Details.Selected.Rows.Clear();
                                this.uGrid_Details.Selected.Rows.Add(cell.Row);
                                break;
                            }
                        case Keys.Up:
                            {
                                this.uGrid_Details.ActiveCell = null;
                                this.uGrid_Details.ActiveRow = cell.Row;
                                this.uGrid_Details.Selected.Rows.Clear();
                                this.uGrid_Details.Selected.Rows.Add(cell.Row);
                                break;
                            }
                    }
                }
                #endregion

                #region ●その他のキー
                else
                {
                    // 編集中であった場合
                    if (cell.IsInEditMode)
                    {
                        // セルのスタイルにて判定
                        switch (this.uGrid_Details.ActiveCell.StyleResolved)
                        {
                            #region < テキストボックス・テキストボックス(ボタン付) >
                            case Infragistics.Win.UltraWinGrid.ColumnStyle.Edit:
                            case Infragistics.Win.UltraWinGrid.ColumnStyle.EditButton:
                                {
                                    switch (e.KeyData)
                                    {
                                        // ←キー
                                        case Keys.Left:
                                            if (this.uGrid_Details.ActiveCell.SelStart == 0)
                                            {
                                                this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.PrevCellByTab);
                                                e.Handled = true;
                                            }
                                            break;
                                        // →キー
                                        case Keys.Right:
                                            if (this.uGrid_Details.ActiveCell.SelStart >= this.uGrid_Details.ActiveCell.Text.Length)
                                            {
                                                this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextCellByTab);
                                                e.Handled = true;
                                            }
                                            break;
                                    }
                                    break;
                                }
                            #endregion

                            #region < 上記以外のスタイル >
                            default:
                                {
                                    switch (e.KeyData)
                                    {
                                        // ←キー
                                        case Keys.Left:
                                            {
                                                this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.PrevCellByTab);
                                                e.Handled = true;
                                            }
                                            break;
                                        // →キー
                                        case Keys.Right:
                                            {
                                                this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextCellByTab);
                                                e.Handled = true;
                                            }
                                            break;
                                    }
                                    break;
                                }
                            #endregion
                        }
                    }

                    switch (e.KeyCode)
                    {
                        #region < Homoキー >
                        case Keys.Home:
                            {
                                this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.FirstCellInGrid);
                                this.MoveNextAllowEditCell(true);
                                break;
                            }
                        #endregion

                        #region < Endキー >
                        case Keys.End:
                            {
                                this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.LastCellInGrid);
                                this.MoveNextAllowEditCell(true);
                                break;
                            }
                        #endregion
                    }

                    // 最上位行にフォーカス
                    if (this.uGrid_Details.ActiveCell.Row.Index == 0)
                    {
                        #region < ↑キー >
                        if (e.KeyCode == Keys.Up)
                        {
                            if (this.GridKeyDownTopRow != null)
                            {
                                this.GridKeyDownTopRow(this, new EventArgs());
                                e.Handled = true;
                            }
                        }
                        #endregion
                    }
                    // 最下位行にフォーカス
                    else if (this.uGrid_Details.ActiveCell.Row.Index == this.uGrid_Details.Rows.Count - 1)
                    {
                        #region < ↓キー >
                        if (e.KeyCode == Keys.Down)
                        {
                            if (this.GridKeyDownButtomRow != null)
                            {
                                this.GridKeyDownButtomRow(this, new EventArgs());
                                e.Handled = true;
                            }
                        }
                        #endregion
                    }
                }
                #endregion
            }
            #endregion

            #region ■列が選択されている場合
            else if (this.uGrid_Details.ActiveRow != null)
            {
                Infragistics.Win.UltraWinGrid.UltraGridRow row = this.uGrid_Details.ActiveRow;

                switch (e.KeyCode)
                {
                    #region < Deleteキー >
                    case Keys.Delete:
                        {
                            this.uButton_RowDelete_Click(this.uButton_RowDelete, new EventArgs());
                            break;
                        }
                    #endregion
                }

                if (this.uGrid_Details.ActiveRow.Index == 0)
                {
                    #region < ↑キー >
                    if (e.KeyCode == Keys.Up)
                    {
                        if (this.GridKeyDownTopRow != null)
                        {
                            this.GridKeyDownTopRow(this, new EventArgs());
                            e.Handled = true;
                        }
                    }
                    #endregion
                }
                else if (this.uGrid_Details.ActiveRow.Index == this.uGrid_Details.Rows.Count - 1)
                {
                    #region < ↓キー >
                    if (e.KeyCode == Keys.Down)
                    {
                        if (this.GridKeyDownButtomRow != null)
                        {
                            this.GridKeyDownButtomRow(this, new EventArgs());
                            e.Handled = true;
                        }
                    }
                    #endregion
                }
            }
            #endregion
        }

        /// <summary>
        /// グリッドキープレスイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void uGrid_Details_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (this.uGrid_Details.ActiveCell == null) return;
            Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.uGrid_Details.ActiveCell;

            // 表示順位？
            if (cell.Column.Key == this._goodsDetailDataTable.DisplyColumn.ColumnName)
            {
                // 編集モード中？
                if (cell.IsInEditMode)
                {
                    // 数値以外は入力不可
                    if (!this.KeyPressNumCheck(2, 0, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false, false))
                    {
                        e.Handled = true;
                        return;
                    }
                }
            }

            #region ●ActiveCellがメーカーコードの場合
            if (cell.Column.Key == this._goodsDetailDataTable.MakerCodeColumn.ColumnName)
            {
                // 編集モード中？
                if (cell.IsInEditMode)
                {
                    if (!this.KeyPressNumCheck(4, 0, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false, false))
                    {
                        e.Handled = true;
                        return;
                    }
                }
            }
            #endregion

            #region DEL 品番チェックの削除
            // DEL 2015/10/28 時シン Redmine#47547 結合先品番入力時に "." を入力できないことの対応 ----->>>>>
            //#region ●ActiveCellが商品コードの場合
            //else if (cell.Column.Key == this._goodsDetailDataTable.GoodsCodeColumn.ColumnName)
            //{
            //    // 編集モード中？
            //    if (cell.IsInEditMode)
            //    {
            //        if (!this.KeyPressNumCheck(24, 0, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, true, true ))
            //        {
            //            e.Handled = true;
            //            return;
            //        }
            //    }
            //}
            //#endregion
            // DEL 2015/10/28 時シン Redmine#47547 結合先品番入力時に "." を入力できないことの対応 -----<<<<<
            #endregion

            // ADD 2008/11/06 不具合対応[6568] 「QTY」、「結合規格・特記事項」は編集可能 ---------->>>>>
            #region ●ActiveCellがQTYの場合

            // QTYの編集
            else if (cell.Column.Key.Equals(this._goodsDetailDataTable.QtyColumn.ColumnName))
            {
                // 編集モード中？
                if (cell.IsInEditMode)
                {
                    if (!this.KeyPressNumCheck(5, 2, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false, true))
                    {
                        e.Handled = true;
                        return;
                    }
                }
            }

            #endregion  // ●ActiveCellがQTYの場合
            // ADD 2008/11/06 不具合対応[6568] 「QTY」、「結合規格・特記事項」は編集可能 ----------<<<<<
        }

        /// <summary>
        /// グリッドキーアップイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void uGrid_Details_KeyUp(object sender, KeyEventArgs e)
        {
            if (this.uGrid_Details.ActiveCell == null) return;
        }

        private void uGrid_Details_MouseUp(object sender, MouseEventArgs e)
        {
            // ボタンEnable設定
            //SetEnable_Btn();

            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.NoColumn.ColumnName].Header.VisiblePosition = 0;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.DisplyColumn.ColumnName].Header.VisiblePosition = 1;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.GoodsCodeColumn.ColumnName].Header.VisiblePosition = 2;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.GoodsNameColumn.ColumnName].Header.VisiblePosition = 3;
        }

        #region ■ uButton イベント

        /// <summary>
        /// 削除ボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void uButton_RowDelete_Click(object sender, EventArgs e)
        {
            this._goodsDetailDataTable.AcceptChanges();

            // 選択済み結合情報行番号リスト取得処理
            List<int> selectedGoodsRowNoList = this.GetSelectedGoodsRowNoList();
            if ((selectedGoodsRowNoList == null) || (selectedGoodsRowNoList.Count == 0))
            {
                return;
            }

            int rowIdx = selectedGoodsRowNoList[0];
            GoodsSetGoodsDataSet.GoodsSetDetailRow detailRow = (GoodsSetGoodsDataSet.GoodsSetDetailRow)this._goodsDetailDataTable.Rows.Find(rowIdx);

            if (!detailRow.EditFlg)
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    "登録済の提供データは削除できません。",
                    -1,
                    MessageBoxButtons.OK);
                return;
            }

            DialogResult dialogResult = TMsgDisp.Show(
                this,
                emErrorLevel.ERR_LEVEL_QUESTION,
                this.Name,
                "選択行を削除してもよろしいですか？",
                0,
                MessageBoxButtons.YesNo,
                MessageBoxDefaultButton.Button1);

            if (dialogResult != DialogResult.Yes)
            {
                return;
            }

            // ActiveRowインデックス取得処理
            int rowIndex = this.GetActiveRowIndex();

            string message;
            // 削除可能チェック処理(現在は必ずTrueがかえってくる)
            if (!this.CanDeleteGoodsDetailRow(selectedGoodsRowNoList, out message))
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    message,
                    -1,
                    MessageBoxButtons.OK);

                return;
            }

            try
            {
                this.Cursor = Cursors.WaitCursor;

                // 結合情報行削除処理
                this.DeleteGoodsDetailRow(selectedGoodsRowNoList);

                // 明細グリッドセル設定処理
                if ((this.uGrid_Details.ActiveCell == null) && (this.uGrid_Details.Rows.Count > rowIndex))
                {
                    this.uGrid_Details.ActiveCell = this.uGrid_Details.Rows[rowIndex].Cells[this._goodsDetailDataTable.GoodsCodeColumn.ColumnName];

                    if ((this.uGrid_Details.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) &&
                        (this.uGrid_Details.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
                    {
                        this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                    }
                }

                // 次入力可能セル移動処理
                this.MoveNextAllowEditCell(true);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// 削除ボタンEnabled変更後発生イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void uButton_RowDelete_EnabledChanged(object sender, EventArgs e)
        {
            // [説明]ウインドウ内のボタンとツールボックス内のボタンのEnabledプロパティの同期を取るための処理
            //       今回ウインドウを表示しないためこのイベント内では処理は何も行なわないものとする。
            //this._rowDeleteButton.SharedProps.Enabled = ((Infragistics.Win.Misc.UltraButton)sender).Enabled;
        }

        /// <summary>
        /// 倉庫ボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void uButton_StoreChange_Click(object sender, EventArgs e)
        {
            JoinPartsUAcs.F_DATA_STORE dataStore = new JoinPartsUAcs.F_DATA_STORE();
            int stockIndex;
            
            // 結合先メーカーコード
            dataStore.joinDestMakerCd = int.Parse(this.uGrid_Details.Rows[this.uGrid_Details.ActiveRow.Index].Cells[this._goodsDetailDataTable.MakerCodeColumn.ColumnName].Value.ToString());
            // 結合先品番
            dataStore.joinDestPartsNo = this.uGrid_Details.Rows[this.uGrid_Details.ActiveRow.Index].Cells[this._goodsDetailDataTable.GoodsCodeColumn.ColumnName].Value.ToString();
            // 倉庫名称
            dataStore.store = this.uGrid_Details.Rows[this.uGrid_Details.ActiveRow.Index].Cells[this._goodsDetailDataTable.StoreColumn.ColumnName].Value.ToString();
            // 棚番
            dataStore.shelfNo = this.uGrid_Details.Rows[this.uGrid_Details.ActiveRow.Index].Cells[this._goodsDetailDataTable.ShelfNoColumn.ColumnName].Value.ToString();
            // 現在庫
            if (this.uGrid_Details.Rows[this.uGrid_Details.ActiveRow.Index].Cells[this._goodsDetailDataTable.StockColumn.ColumnName].Value != DBNull.Value)
            {
                dataStore.stock = (double)this.uGrid_Details.Rows[this.uGrid_Details.ActiveRow.Index].Cells[this._goodsDetailDataTable.StockColumn.ColumnName].Value;
            }
            // 倉庫コード
            if (this.uGrid_Details.Rows[this.uGrid_Details.ActiveRow.Index].Cells[this._goodsDetailDataTable.StoreCodeColumn.ColumnName].Value != DBNull.Value)
            {
                dataStore.storeCode = this.uGrid_Details.Rows[this.uGrid_Details.ActiveRow.Index].Cells[this._goodsDetailDataTable.StoreCodeColumn.ColumnName].Value.ToString();
            }

            string key = dataStore.joinDestPartsNo + "-" + dataStore.joinDestMakerCd.ToString("d04");
            if (this._storeDic.ContainsKey(key))
            {
                ArrayList storeData = this._storeDic[key];

                // 該当データIndex取得
                stockIndex = storeData.IndexOf(dataStore);

                if (stockIndex >= 0)
                {
                    // Indexとデータ数は同じ？
                    if ((stockIndex + 1) >= storeData.Count)
                    {
                        // 先頭の在庫情報を表示
                        dataStore = (JoinPartsUAcs.F_DATA_STORE)storeData[0];
                    }
                    else
                    {
                        // Indexの次のデータを表示
                        dataStore = (JoinPartsUAcs.F_DATA_STORE)storeData[stockIndex + 1];
                    }
                }

                // 結合先メーカーコード
                this.uGrid_Details.Rows[this.uGrid_Details.ActiveRow.Index].Cells[this._goodsDetailDataTable.MakerCodeColumn.ColumnName].Value = dataStore.joinDestMakerCd.ToString("d04");
                // 結合先品番
                this.uGrid_Details.Rows[this.uGrid_Details.ActiveRow.Index].Cells[this._goodsDetailDataTable.GoodsCodeColumn.ColumnName].Value = dataStore.joinDestPartsNo;
                // 倉庫名称
                this.uGrid_Details.Rows[this.uGrid_Details.ActiveRow.Index].Cells[this._goodsDetailDataTable.StoreColumn.ColumnName].Value = dataStore.store;
                // 棚番
                this.uGrid_Details.Rows[this.uGrid_Details.ActiveRow.Index].Cells[this._goodsDetailDataTable.ShelfNoColumn.ColumnName].Value = dataStore.shelfNo;
                // 現在庫
                this.uGrid_Details.Rows[this.uGrid_Details.ActiveRow.Index].Cells[this._goodsDetailDataTable.StockColumn.ColumnName].Value = dataStore.stock;
                // 倉庫コード
                this.uGrid_Details.Rows[this.uGrid_Details.ActiveRow.Index].Cells[this._goodsDetailDataTable.StoreCodeColumn.ColumnName].Value = dataStore.storeCode;
            }
        }

        // ADD 2008/11/06 不具合対応[7109] 代替マスタ新旧表示 ---------->>>>>
        /// <summary>
        /// 代替マスタ新旧表示画面用パラメータの列挙体
        /// </summary>
        private enum InitialSearchDivForSubstituteMaster : int
        {
            /// <summary>結合先</summary>
            Dest = 0,
            /// <summary>結合元</summary>
            Source = 1
        }

        /// <summary>
        /// 代替マスタ新旧表示画面を表示します。
        /// </summary>
        /// <param name="initialSearchDiv">結合元か結合先かを判別する区分</param>
        private void ShowSubstituteMasterForm(InitialSearchDivForSubstituteMaster initialSearchDiv)
        {
            PartsInfoDataSet partsInfoDataSet;
            GoodsCndtn goodsCndtn = new GoodsCndtn();
            List<GoodsUnitData> goodsUnitDataList;
            
            goodsCndtn.EnterpriseCode = this._enterpriseCode;
            goodsCndtn.MakerName = "";
            goodsCndtn.GoodsNoSrchTyp = 0;
            // DEL 2009/06/22 ------>>>
            //goodsCndtn.GoodsMakerCd = JoinSourceMakerCode;
            //goodsCndtn.GoodsNo = JoinSourPartsNoWithH;
            // DEL 2009/06/22 ------<<<
            goodsCndtn.JoinSearchDiv = (int)GoodsCndtn.JoinSearchDivType.Search;
            goodsCndtn.IsSettingSupplier = 1;
            goodsCndtn.PriceApplyDate = DateTime.Today;
            goodsCndtn.TotalAmountDispWayCd = 0; // 0:総額表示しない
            goodsCndtn.ConsTaxLayMethod = 1; // 1:明細転嫁
            goodsCndtn.SalesCnsTaxFrcProcCd = 0; // 0:共通設定

            // ADD 2009/06/22 ------>>>
            if (initialSearchDiv == InitialSearchDivForSubstituteMaster.Source)
            {
                // 結合元
                goodsCndtn.GoodsMakerCd = JoinSourceMakerCode;
                if (!string.IsNullOrEmpty(JoinSourPartsNoWithH))
                {
                    goodsCndtn.GoodsNo = JoinSourPartsNoWithH;
                }
                else
                {
                    goodsCndtn.GoodsNo = "";
                }

                // 2009/08/04 ---------------------------------------->>>
                if (goodsCndtn.GoodsMakerCd == 0 || string.IsNullOrEmpty(JoinSourPartsNoWithH))
                {
                    TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_EXCLAMATION,
                            this.Name,
                            "結合元の商品を指定して下さい。",
                            -1,
                            MessageBoxButtons.OK);
                    return;
                }
                // 2009/08/04 ----------------------------------------<<<

            }
            else
            {
                // 結合先
                // ActiveRowインデックス取得処理
                int rowIndex = this.GetActiveRowIndex();

                // 2009/08/04 ---------------------------------------->>>
                //goodsCndtn.GoodsMakerCd = int.Parse(this.uGrid_Details.Rows[rowIndex].Cells[this._goodsDetailDataTable.MakerCodeColumn.ColumnName].Value.ToString());

                try
                {
                    goodsCndtn.GoodsMakerCd = int.Parse(this.uGrid_Details.Rows[rowIndex].Cells[this._goodsDetailDataTable.MakerCodeColumn.ColumnName].Value.ToString());
                }
                catch
                {
                    goodsCndtn.GoodsMakerCd = 0;
                }
                // 2009/08/04 ---------------------------------------->>>

                goodsCndtn.GoodsNo = this.uGrid_Details.Rows[rowIndex].Cells[this._goodsDetailDataTable.GoodsCodeColumn.ColumnName].Value.ToString();

                // 2009/08/04 ---------------------------------------->>>
                if (goodsCndtn.GoodsMakerCd == 0 || string.IsNullOrEmpty(JoinSourPartsNoWithH))
                {
                    TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_EXCLAMATION,
                            this.Name,
                            "結合先の商品を指定して下さい。",
                            -1,
                            MessageBoxButtons.OK);

                    return;
                }
                // 2009/08/04 ---------------------------------------<<<

            }
            // ADD 2009/06/22 ------<<<
            
            int status = this._joinPartsUAcs.SearchJoinPartsUData(goodsCndtn, out partsInfoDataSet, out goodsUnitDataList);
            if (status == 0)
            {
                // 2009/07/16 >>>>>>>>>>>>>>>>>>>>>>
                // ADD 2009/06/22 ------>>>
                // 商品種別の確認(8:代替商品)
                //int goodsKind = goodsUnitDataList[0].GoodsKind & 8;
                //if (goodsKind != 8)
                //{
                //    // 代替商品では無い
                //    TMsgDisp.Show(
                //            this,
                //            emErrorLevel.ERR_LEVEL_INFO,
                //            this.Name,
                //            "条件に合致するデータが存在しません。",
                //            -1,
                //            MessageBoxButtons.OK);
                //    return;
                //}
                // ADD 2009/06/22 ------<<<
                // 2009/07/16 <<<<<<<<<<<<<<<<<<<<<<
                
                PMKEN09081U substituteMaster = new PMKEN09081U();
                substituteMaster.ShowDialog(this, goodsUnitDataList[0], (int)initialSearchDiv);

                // 2009/08/04 --------------------------------------->>>
                uGrid_Details.Focus();
                uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                // 2009/08/04 ---------------------------------------<<<
            }

        }
        // ADD 2008/11/06 不具合対応[7109] 代替マスタ新旧表示 ----------<<<<<

        /// <summary>
        /// 結合元ボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void uButton_JoinSource_Click(object sender, EventArgs e)
        {
            // TODO:代替マスタ新旧表示
            ShowSubstituteMasterForm(InitialSearchDivForSubstituteMaster.Source);   // ADD 2008/11/06 不具合対応[7109] 代替マスタ新旧表示
        }

        /// <summary>
        /// 結合先ボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void uButton_JoinDest_Click(object sender, EventArgs e)
        {
            // TODO:代替マスタ新旧表示
            ShowSubstituteMasterForm(InitialSearchDivForSubstituteMaster.Dest); // ADD 2008/11/06 不具合対応[7109] 代替マスタ新旧表示
        }

        #endregion

        /// <summary>
        ///	ultraGrid.AfterExitEditMode イベント(Cell)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// </remarks>
        private void uGrid_Details_AfterExitEditMode(object sender, EventArgs e)
        {
            if (this.uGrid_Details.ActiveCell == null) return;

            Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.uGrid_Details.ActiveCell;
            int goodsRowNo = this._goodsDetailDataTable[cell.Row.Index].No;
            int rowIndex = cell.Row.Index;

            // 数値項目が空の場合
            if (cell.Value is DBNull)
            {
                if ((cell.Column.DataType == typeof(Int32)) ||
                    (cell.Column.DataType == typeof(Int64)) ||
                    (cell.Column.DataType == typeof(double)))
                {
                    cell.Value = 0;
                }
            }

            #region ●ActiveCellが商品コードの場合
            if (cell.Column.Key == this._goodsDetailDataTable.GoodsCodeColumn.ColumnName)
            {
                string goodsCode = cell.Value.ToString();

                // 変更フラグON
                _changeFlg = true;

                // 品番更新区分の初期設定
                this._joinGoodNoUpdFlg = true;

                if (this._childGoodsNo == goodsCode)
                {
                    // 編集前と編集後が同じ場合は処理を行わない
                    return;
                }

                if (!String.IsNullOrEmpty(goodsCode))
                {
                    #region ■入力有
                    
                    #region < 検索種類取得 >
                    int searchType = this.GetSearchType(goodsCode, out goodsCode);
                    #endregion

                    GoodsCndtn goodsCndtn = new GoodsCndtn();
                    List<GoodsUnitData> goodsUnitDataList;
                    string message;

                    goodsCndtn.EnterpriseCode = this._enterpriseCode;
                    goodsCndtn.GoodsMakerCd = 0;
                    goodsCndtn.MakerName = "";
                    goodsCndtn.GoodsNo = goodsCode;
                    goodsCndtn.GoodsNoSrchTyp = searchType;
                    goodsCndtn.PriceApplyDate = DateTime.Today;
                    goodsCndtn.IsSettingSupplier = 1; // 2009.02.09
                    
                    // 品番検索（結合先）
                    int status = this._joinPartsUAcs.SearchPartsFromGoodsNoNonVariousSearch(goodsCndtn, out goodsUnitDataList, out message);
                    
                    if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) && (goodsUnitDataList != null) && (goodsUnitDataList.Count > 0))
                    {
                        #region -- 正常取得 --
                        // 商品マスタデータクラス
                        GoodsUnitData goodsUnitData = new GoodsUnitData();
                        goodsUnitData = goodsUnitDataList[0];

                        if (this.uGrid_Details.Rows[this.uGrid_Details.ActiveRow.Index].Cells[this._goodsDetailDataTable.DisplyColumn.ColumnName].Value.ToString() != "")
                        {
                            // 表示順設定
                            goodsUnitData.JoinDispOrder = int.Parse(this.uGrid_Details.Rows[this.uGrid_Details.ActiveRow.Index].Cells[this._goodsDetailDataTable.DisplyColumn.ColumnName].Value.ToString());
                        }

                        // 商品マスタ情報設定処理
                        // --- UPD 2013/10/08 T.Miyamoto ------------------------------>>>>>
                        //this.GoodsDetailRowGoodsSetSetting(goodsRowNo, goodsUnitData);
                        List<UnitPriceCalcRet> unitPriceCalcRetList = null;
                        unitPriceCalcRetList = this.CalclationUnitPrice(goodsUnitDataList); // 原単価取得

                        UnitPriceCalcRet UnitPriceCalcRet = this.SearchUnitPriceCalcRet(2, unitPriceCalcRetList, goodsUnitData);
                        this.GoodsDetailRowGoodsSetSetting(goodsRowNo, goodsUnitData, UnitPriceCalcRet);
                        // --- UPD 2013/10/08 T.Miyamoto ------------------------------<<<<<

                        // 取得した商品連結データをキャッシュとして保持
                        if (!_lcGoodsUnitDataList.Contains(goodsUnitData))
                        {
                            _lcGoodsUnitDataList.Add(goodsUnitData);
                        }
                        #endregion

                        // 編集可能カラムの設定
                        SetEditableDisplayLayout(cell.Row.Index + 1); // ADD 2008/11/17 不具合対応[6564] 「QTY」、「結合規格・特記事項」は編集可能
                    }
                    // 2009.02.09 30413 犬飼 キャンセル時のフォーカス制御 >>>>>>START
                    else if (status == -1)
                    {
                        // 同一品番選択画面でキャンセル
                        // 対象行のクリア
                        this._goodsDetailDataTable[cell.Row.Index].GoodsCode = "";    // 商品コード
                        this._goodsDetailDataTable[cell.Row.Index].GoodsName = "";    // 商品名称
                        this._goodsDetailDataTable[cell.Row.Index].MakerCode = "";     // メーカーコード
                        this._goodsDetailDataTable[cell.Row.Index].MakerName = "";    // メーカー名称
                        this._goodsDetailDataTable[cell.Row.Index].SetNote = "";      // 結合規格・特記事項
                        this._goodsDetailDataTable[cell.Row.Index].OfferDate = "";    // 提供日付
                        this._goodsDetailDataTable[cell.Row.Index][this._goodsDetailDataTable.PriceColumn.ColumnName] = DBNull.Value;   // 標準価格
                        this._goodsDetailDataTable[cell.Row.Index][this._goodsDetailDataTable.CostColumn.ColumnName] = DBNull.Value;    // 原単価
                        this._goodsDetailDataTable[cell.Row.Index].Store = "";        // 倉庫
                        this._goodsDetailDataTable[cell.Row.Index].ShelfNo = "";      // 棚番
                        this._goodsDetailDataTable[cell.Row.Index][this._goodsDetailDataTable.StockColumn.ColumnName] = DBNull.Value;   // 現在庫

                        // 品番更新区分の初期設定
                        this._joinGoodNoUpdFlg = false;
                    }
                    // 2009.02.09 30413 犬飼 キャンセル時のフォーカス制御 <<<<<<END
                    else
                    {
                        #region -- 取得失敗 --
                        TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_INFO,
                            this.Name,
                            "商品コード [" + goodsCode + "] に該当するデータが存在しません。",
                            -1,
                            MessageBoxButtons.OK);

                        //this._goodsDetailDataTable[cell.Row.Index].Disply = "";     // 表示順位
                        this._goodsDetailDataTable[cell.Row.Index].GoodsCode = "";    // 商品コード
                        this._goodsDetailDataTable[cell.Row.Index].GoodsName = "";    // 商品名称
                        this._goodsDetailDataTable[cell.Row.Index].MakerCode = "";     // メーカーコード
                        this._goodsDetailDataTable[cell.Row.Index].MakerName = "";    // メーカー名称
                        this._goodsDetailDataTable[cell.Row.Index].SetNote = "";      // 結合規格・特記事項
                        this._goodsDetailDataTable[cell.Row.Index].OfferDate = "";    // 提供日付
                        this._goodsDetailDataTable[cell.Row.Index][this._goodsDetailDataTable.PriceColumn.ColumnName] = DBNull.Value;   // 標準価格
                        this._goodsDetailDataTable[cell.Row.Index][this._goodsDetailDataTable.CostColumn.ColumnName] = DBNull.Value;    // 原単価
                        this._goodsDetailDataTable[cell.Row.Index].Store = "";        // 倉庫
                        this._goodsDetailDataTable[cell.Row.Index].ShelfNo = "";      // 棚番
                        this._goodsDetailDataTable[cell.Row.Index][this._goodsDetailDataTable.StockColumn.ColumnName] = DBNull.Value;   // 現在庫

                        // 品番更新区分の初期設定
                        this._joinGoodNoUpdFlg = false;

                        return;

                        #endregion
                    }
                    #endregion
                }
                else
                {
                    // 未入力
                    this._goodsDetailDataTable[cell.Row.Index].GoodsCode = "";   // 商品コード
                    this._goodsDetailDataTable[cell.Row.Index].GoodsName = "";   // 商品名称
                    this._goodsDetailDataTable[cell.Row.Index].MakerCode = "";    // メーカーコード
                    this._goodsDetailDataTable[cell.Row.Index].MakerName = "";   // メーカー名称
                    this._goodsDetailDataTable[cell.Row.Index].Qty = "";         // ADD 2008/10/21 不具合対応[6565]
                    this._goodsDetailDataTable[cell.Row.Index].SetNote = "";     // 結合規格・特記事項
                    this._goodsDetailDataTable[cell.Row.Index].OfferDate = "";   // 提供日付
                    this._goodsDetailDataTable[cell.Row.Index][this._goodsDetailDataTable.PriceColumn.ColumnName] = DBNull.Value;   // 標準価格
                    this._goodsDetailDataTable[cell.Row.Index][this._goodsDetailDataTable.CostColumn.ColumnName] = DBNull.Value;    // 原単価
                    this._goodsDetailDataTable[cell.Row.Index].Store = "";        // 倉庫
                    this._goodsDetailDataTable[cell.Row.Index].ShelfNo = "";      // 棚番
                    this._goodsDetailDataTable[cell.Row.Index][this._goodsDetailDataTable.StockColumn.ColumnName] = DBNull.Value;   // 現在庫

                    return;
                }
            }
            #endregion

            else if (cell.Column.Key == this._goodsDetailDataTable.QtyColumn.ColumnName)
            {
                // QTY
                double qty = 0.0;
                if ((!double.TryParse(cell.Text, out qty)) || (qty == 0.0))
                {
                    // DEL 2009/06/24 ------>>>
                    //if (cell.Text != "")
                    //{
                    //    this._goodsDetailDataTable[cell.Row.Index].Qty = "0";
                    //}
                    // DEL 2009/06/24 ------<<<
                    this._goodsDetailDataTable[cell.Row.Index].Qty = "0.00";    // ADD 2009/06/24
                }
                else
                {
                    this._goodsDetailDataTable[cell.Row.Index].Qty = qty.ToString("##0.00");

                }
            }
        }

        #endregion

        /// <summary>
        ///	ultraGrid.uGrid_Details_BeforeExitEditMode イベント(Cell)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// </remarks>
        private void uGrid_Details_BeforeExitEditMode(object sender, Infragistics.Win.UltraWinGrid.BeforeExitEditModeEventArgs e)
        {
            if (this.uGrid_Details.ActiveCell == null) return;

            Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.uGrid_Details.ActiveCell;

            if (cell.Column.Key == this._goodsDetailDataTable.GoodsCodeColumn.ColumnName)
            {
                this._childGoodsNo = cell.Value.ToString();
            }
        }

        // --- ADD 2013/10/08 T.Miyamoto ------------------------------>>>>>
        /// <summary>
        /// 単価算出モジュールにより、原単価を算出します。
        /// </summary>
        /// <param name="goodsUnitDataList">商品連結データオブジェクトリスト</param>
        /// <returns></returns>
        public List<UnitPriceCalcRet> CalclationUnitPrice(List<GoodsUnitData> goodsUnitDataList)
        {
            UnitPriceCalculation _unitPriceCalculation = new UnitPriceCalculation();

            List<UnitPriceCalcRet> unitPriceCalcRetList = new List<UnitPriceCalcRet>();
            List<UnitPriceCalcParam> unitPriceCalcParamList = new List<UnitPriceCalcParam>();
            List<GoodsUnitData> tempGoodsUnitDataList = new List<GoodsUnitData>();

            foreach (GoodsUnitData goodsUnitData in goodsUnitDataList)
            {
                GoodsUnitData tempGoodsUnitData = goodsUnitData.Clone();
                tempGoodsUnitDataList.Add(tempGoodsUnitData);

                if ((goodsUnitData.GoodsMakerCd != 0) && (!string.IsNullOrEmpty(goodsUnitData.GoodsNo)))
                {
                    UnitPriceCalcParam unitPriceCalcParam = new UnitPriceCalcParam();

                    unitPriceCalcParam.GoodsMakerCd = goodsUnitData.GoodsMakerCd;                               // メーカーコード
                    unitPriceCalcParam.GoodsNo = goodsUnitData.GoodsNo;                                         // 商品番号
                    // --- DEL 2013/12/02 T.Miyamoto ------------------------------>>>>>
                    //unitPriceCalcParam.GoodsRateGrpCode = goodsUnitData.GoodsRateGrpCode;                       // 商品掛率グループコード
                    //unitPriceCalcParam.GoodsRateRank = goodsUnitData.GoodsRateRank;                             // 商品掛率ランク
                    // --- DEL 2013/12/02 T.Miyamoto ------------------------------<<<<<
                    unitPriceCalcParam.PriceApplyDate = DateTime.Now;                                           // 適用日
                    unitPriceCalcParam.SectionCode = LoginInfoAcquisition.Employee.BelongSectionCode.TrimEnd(); // 拠点コード

                    unitPriceCalcParamList.Add(unitPriceCalcParam);
                }
            }

            // 原単価取得
            _unitPriceCalculation.CalculateUnitCost(unitPriceCalcParamList, tempGoodsUnitDataList, out unitPriceCalcRetList);

            return unitPriceCalcRetList;
        }

        /// <summary>
        /// 単価算出結果リストから該当データ検索
        /// </summary>
        /// <param name="unitPriceKind">単価種類</param>
        /// <param name="unitPriceCalcRetList">単価算出結果リスト</param>
        /// <param name="goodsUnitData">商品連結データオブジェクト</param>
        /// <returns></returns>
        public UnitPriceCalcRet SearchUnitPriceCalcRet(int unitPriceKind, List<UnitPriceCalcRet> unitPriceCalcRetList, GoodsUnitData goodsUnitData)
        {
            UnitPriceCalcRet unitPriceCalcRet = null;

            foreach (UnitPriceCalcRet unitPriceCalcRetWk in unitPriceCalcRetList)
            {
                if ((unitPriceCalcRetWk.UnitPriceKind == ((int)unitPriceKind).ToString()) &&
                    //(unitPriceCalcRetWk.GoodsNo == unitPriceCalcParam.GoodsNo) &&
                    //(unitPriceCalcRetWk.GoodsMakerCd == unitPriceCalcParam.GoodsMakerCd))
                    // --- ADD 2013/12/02 T.Miyamoto ------------------------------>>>>>
                    (unitPriceCalcRetWk.RateSettingDivide == "6A") &&
                    // --- ADD 2013/12/02 T.Miyamoto ------------------------------<<<<<
                    (unitPriceCalcRetWk.GoodsNo       == goodsUnitData.GoodsNo) &&
                    (unitPriceCalcRetWk.GoodsMakerCd  == goodsUnitData.GoodsMakerCd))
                {
                    unitPriceCalcRet = unitPriceCalcRetWk.Clone();
                }
            }
            return unitPriceCalcRet;
        }
        // --- ADD 2013/10/08 T.Miyamoto ------------------------------<<<<<

        // ------------ ADD 譚洪 2013/12/04 --------------- >>>>
        /// <summary>
        /// 画面の横幅を変更イベット
        /// </summary>
        /// <param name="width">画面の横幅</param>
        /// <returns></returns>
        public void SettingGridWidth(int width, int height)
        {
            this.Width = width;
            this.panel1.Width = width;
            this.uGrid_Details.Width = width;

            this.Height = height;
            this.panel1.Height = height;
            this.uGrid_Details.Height = height;

            this.panel1.Dock = DockStyle.Fill;
            this.uGrid_Details.Dock = DockStyle.Fill;
            this.uGrid_Details.Refresh();
        }
        // ------------ ADD 譚洪 2013/12/04 --------------- <<<<

        // ADD START 劉超　2013/12/04 FOR Redmine#41447 ------>>>>>>
        # region [グリッドカラム情報 保存・復元]
        /// <summary>
        /// グリッドカラム情報の保存
        /// </summary>
        /// <param name="targetGrid"></param>
        /// <param name="settingList"></param>
        public void SaveGridColumnsSetting(Infragistics.Win.UltraWinGrid.UltraGrid targetGrid, out List<ColumnInfo> settingList)
        {
            settingList = new List<ColumnInfo>();
            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn in targetGrid.DisplayLayout.Bands[0].Columns)
            {
                settingList.Add(new ColumnInfo(ultraGridColumn.Key, ultraGridColumn.Header.VisiblePosition, ultraGridColumn.Hidden, ultraGridColumn.Width, ultraGridColumn.Header.Fixed));
            }
        }
        /// <summary>
        /// グリッドカラム情報の読み込み
        /// </summary>
        /// <param name="targetGrid"></param>
        /// <param name="settingList"></param>
        public void LoadGridColumnsSetting(ref Infragistics.Win.UltraWinGrid.UltraGrid targetGrid, List<ColumnInfo> settingList)
        {
            if (settingList == null || settingList.Count == 0) return;

            targetGrid.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.None;

            // カラム設定情報を表示順でソートする
            settingList.Sort(new ColumnInfoComparer());

            // 一度、全てのカラムのFixedを解除する
            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn in targetGrid.DisplayLayout.Bands[0].Columns)
            {
                ultraGridColumn.Header.Fixed = false;
            }

            foreach (ColumnInfo columnInfo in settingList)
            {
                try
                {
                    Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn = targetGrid.DisplayLayout.Bands[0].Columns[columnInfo.ColumnName];
                    ultraGridColumn.Header.VisiblePosition = columnInfo.VisiblePosition;
                    ultraGridColumn.Hidden = columnInfo.Hidden;
                    ultraGridColumn.Width = columnInfo.Width;
                }
                catch
                {
                }
            }

            // 列並び換え後、まとめてFixedを設定する。
            foreach (ColumnInfo columnInfo in settingList)
            {
                try
                {
                    Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn = targetGrid.DisplayLayout.Bands[0].Columns[columnInfo.ColumnName];
                    ultraGridColumn.Header.Fixed = columnInfo.ColumnFixed;
                }
                catch
                {
                }
            }
        }
        # endregion

        #region プライベート関数
        /// <summary>
        /// グリッドのセッティングを文字列から取り出す
        /// </summary>
        /// <param name="patternStr"></param>
        /// <param name="gridSetting"></param>
        /// <param name="isSlip"></param>
        private void getGridSettingPattern(string patternStr, out string[] gridSetting, bool isSlip)
        {
            int count = patternStr.Length / (ct_ColumnCountLength + 1);
            gridSetting = new string[count];

            for (int i = 0; i < count; i++)
            {
                gridSetting[i] = patternStr.Substring(i * (ct_ColumnCountLength + 1), (ct_ColumnCountLength + 1));
            }
        }
        #endregion

        #region ユーザー設定の保存・読み込み

        /// <summary>データ変更後発生イベント</summary>
        public event EventHandler DataChanged;

        /// <summary>
        /// 結合マスタ用ユーザー設定シリアライズ処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 結合マスタ用ユーザー設定のシリアライズを行います。</br>
        /// <br>Programmer : 劉超</br>
        /// <br>Date       : 2013/12/04</br>
        /// </remarks>
        public void Serialize()
        {
            try
            {
                UserSettingController.SerializeUserSetting(_userSetting, Path.Combine(ConstantManagement_ClientDirectory.NSCurrentDirectory, Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_FILE_NAME)));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException.Message);
            }

            if (DataChanged != null)
            {
                // データ変更後発生イベント実行
                DataChanged(this, new EventArgs());
            }
        }

        /// <summary>
        /// 結合マスタ用ユーザー設定デシリアライズ処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 結合マスタ用ユーザー設定クラスをデシリアライズします。</br>
        /// <br>Programmer : 劉超</br>
        /// <br>Date       : 2013/12/04</br>
        /// </remarks>
        public void Deserialize()
        {
            if (UserSettingController.ExistUserSetting(Path.Combine(ConstantManagement_ClientDirectory.NSCurrentDirectory, Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_FILE_NAME))))
            {
                try
                {
                    this._userSetting = UserSettingController.DeserializeUserSetting<IntegrateMstUserConst>(Path.Combine(ConstantManagement_ClientDirectory.NSCurrentDirectory, Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_FILE_NAME)));

                }
                catch
                {
                    this._userSetting = new IntegrateMstUserConst();
                }
            }
        }

        /// <summary>
        /// カラム名のリスト取得
        /// </summary>
        /// <param name="sourceStr"></param>
        /// <param name="isSlip"></param>
        /// <returns></returns>
        public List<String> GetColumnNameList(string sourceStr, bool isSlip)
        {
            List<String> columnList;

            columnList = new List<String>();
            string[] p;
            getGridSettingPattern(sourceStr, out p, true);

            for (int i = 0; i < p.Length; i++)
            {
                columnList.Add(p[i]);
            }

            return columnList;
        }

        #endregion // ユーザー設定の保存・読み込み
        // ADD END 劉超　2013/12/04 FOR Redmine#41447 ------<<<<<<
    }

    // ADD START 劉超　2013/12/04 FOR Redmine#41447 ------>>>>>>
    /// <summary>
    /// 結合マスタ用ユーザー設定クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 結合マスタのユーザー設定情報を管理するクラス</br>
    /// <br>Programmer : </br>
    /// <br>Date       : </br>
    /// <br></br>
    /// </remarks>
    [Serializable]
    public class IntegrateMstUserConst
    {

        # region プライベート変数

        // 出力ファイル名
        private string _outputFileName;

        // 出力形式
        private int _outputStyle;

        // 出力パターン
        private string[] _outputPattern;

        // 選択されたパターン名
        private string _selectedPatternName;

        /// <summary>項目区切り文字</summary>
        private const string STRING_DIVIDER = "'";

        // 明細グリッドカラムリスト
        private List<ColumnInfo> _detailColumnsList;

        // 行フィルタ
        private int _allowRowFiltering;
        // 列交換
        private int _allowColSwapping;
        // 列固定
        private int _fixedHeaderIndicator;

        # endregion // プライベート変数

        # region コンストラクタ

        /// <summary>
        /// 結合マスタユーザー設定情報クラス
        /// </summary>
        public IntegrateMstUserConst()
        {

        }

        # endregion // コンストラクタ

        # region プロパティ

        /// <summary>出力ファイル名</summary>
        public string OutputFileName
        {
            get { return this._outputFileName; }
            set { this._outputFileName = value; }
        }

        /// <summary>出力型式</summary>
        public int OutputStyle
        {
            get { return this._outputStyle; }
            set { this._outputStyle = value; }
        }

        /// <summary>出力パターン</summary>
        public string[] OutputPattern
        {
            get { return this._outputPattern; }
            set { this._outputPattern = value; }
        }

        /// <summary>選択パターン名</summary>
        public string SelectedPatternName
        {
            get { return this._selectedPatternName; }
            set { this._selectedPatternName = value; }
        }

        /// <summary>区切り文字</summary>
        public string DIVIDER
        {
            get { return STRING_DIVIDER; }
        }

        /// <summary>明細グリッドカラムリスト</summary>
        public List<ColumnInfo> DetailColumnsList
        {
            get { return this._detailColumnsList; }
            set { this._detailColumnsList = value; }
        }
        /// <summary>行フィルタ</summary>
        public int AllowRowFiltering
        {
            get { return _allowRowFiltering; }
            set { _allowRowFiltering = value; }
        }
        /// <summary>列交換</summary>
        public int AllowColSwapping
        {
            get { return _allowColSwapping; }
            set { _allowColSwapping = value; }
        }
        /// <summary>列固定</summary>
        public int FixedHeaderIndicator
        {
            get { return _fixedHeaderIndicator; }
            set { _fixedHeaderIndicator = value; }
        }

        # endregion

        /// <summary>
        /// 結合マスタユーザー設定情報クラス複製処理
        /// </summary>
        /// <returns>結合マスタユーザー設定情報クラス</returns>
        public IntegrateMstUserConst Clone()
        {
            IntegrateMstUserConst constObj = new IntegrateMstUserConst();
            return constObj;
        }

        /// <summary>
        /// ファイル拡張子変換処理
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="selectedValue"></param>
        /// <returns></returns>
        public static string ChangeFileExtension(string fileName, string selectedValue)
        {
            string newExt = string.Empty;
            switch (selectedValue)
            {
                case "0":
                    newExt = ".CSV";
                    break;
                case "1":
                    newExt = ".TXT";
                    break;
                case "2":
                    newExt = ".PRN";
                    break;
                case "3":
                default:
                    break;
            }
            if (newExt != string.Empty)
            {
                try
                {
                    fileName = Path.ChangeExtension(fileName, newExt);
                }
                catch
                {
                }
            }
            return fileName;
        }
    }

    # region [ColumnInfo]
    /// <summary>
    /// ColumnInfo
    /// </summary>
    [Serializable]
    public struct ColumnInfo
    {
        /// <summary>列名</summary>
        private string _columnName;
        /// <summary>並び順</summary>
        private int _visiblePosition;
        /// <summary>非表示フラグ</summary>
        private bool _hidden;
        /// <summary>幅</summary>
        private int _width;
        /// <summary>固定フラグ</summary>
        private bool _columnFixed;
        /// <summary>
        /// 列名
        /// </summary>
        public string ColumnName
        {
            get { return _columnName; }
            set { _columnName = value; }
        }
        /// <summary>
        /// 並び順
        /// </summary>
        public int VisiblePosition
        {
            get { return _visiblePosition; }
            set { _visiblePosition = value; }
        }
        /// <summary>
        /// 非表示フラグ
        /// </summary>
        public bool Hidden
        {
            get { return _hidden; }
            set { _hidden = value; }
        }
        /// <summary>
        /// 幅
        /// </summary>
        public int Width
        {
            get { return _width; }
            set { _width = value; }
        }
        /// <summary>
        /// 固定フラグ
        /// </summary>
        public bool ColumnFixed
        {
            get { return _columnFixed; }
            set { _columnFixed = value; }
        }
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="columnName">列名</param>
        /// <param name="visiblePosition">並び順</param>
        /// <param name="hidden">非表示フラグ</param>
        /// <param name="width">幅</param>
        /// <param name="columnFixed">固定フラグ</param>
        public ColumnInfo(string columnName, int visiblePosition, bool hidden, int width, bool columnFixed)
        {
            _columnName = columnName;
            _visiblePosition = visiblePosition;
            _hidden = hidden;
            _width = width;
            _columnFixed = columnFixed;
        }
    }

    /// <summary>
    /// ColumnInfo比較クラス（ソート用）
    /// </summary>
    public class ColumnInfoComparer : IComparer<ColumnInfo>
    {
        /// <summary>
        /// ColumnInfo比較処理
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public int Compare(ColumnInfo x, ColumnInfo y)
        {
            // 列表示順で比較
            int result = x.VisiblePosition.CompareTo(y.VisiblePosition);
            // 列表示順が一致する場合は列名で比較(通常は発生しない)
            if (result == 0)
            {
                result = x.ColumnName.CompareTo(y.ColumnName);
            }
            return result;
        }
    }
    # endregion
    // ADD END 劉超　2013/12/04 FOR Redmine#41447 ------<<<<<<
}

//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : 在庫移動電子元帳
// プログラム概要   : 在庫移動電子元帳データ取得アクセスクラス
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : yangmj
// 作 成 日  2011/04/06  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : tianjw
// 作 成 日  2011/05/11  修正内容 : redmine #20913
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 朱俊成
// 作 成 日  2011/05/20  修正内容 : redmine #21657
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using System.Windows.Forms;

using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Collections;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 在庫移動電子元帳データ取得アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 在庫移動電子元帳のアクセスクラスです。</br>
    /// <br>Programmer : yangmj</br>
    /// <br>Date       : 2011/04/06</br>
    /// <br>Update Note: 2011/05/11 tianjw</br>
    /// <br>             redmine #20913</br>
    /// </remarks>
    public partial class StockMoveSlipSearchAcs
    {
        #region コンストラクタ

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public StockMoveSlipSearchAcs()
        {
            // リモートインスタンス取得
            this._iStockMoveWorkDB = MediationStockMoveWorkDB.GetStockMoveWorkDB();

            // データセットを作成
            this._dataSet = new StockMoveDetailDataSet();
        }

        #endregion // コンストラクタ

        #region プライベート変数

        // リモートDB検索クラス インタフェースオブジェクト
        private IStockMoveWorkDB _iStockMoveWorkDB;

        // データセットクラス
        private StockMoveDetailDataSet _dataSet;

        // 抽出中断フラグ
        private bool _extractCancelFlag;

        // 出荷/出庫 合計数量
        private double _totalMoveCountOut = 0;
        // 出荷/出庫 合計金額
        private double _totalStockMovePriceOut = 0;
        // 出荷/出庫 合計標準価格
        private double _totalListPriceFlOut = 0;
        // 入荷済/入庫 合計数量
        private double _totalMoveCountIn = 0;
        // 入荷済/入庫 合計金額
        private double _totalStockMovePriceIn = 0;
        // 入荷済/入庫 合計標準価格
        private double _totalListPriceFlIn = 0;
        // 未入荷 合計数量
        private double _totalMoveCount = 0;
        // 未入荷 合計金額
        private double _totalStockMovePrice = 0;
        // 未入荷 合計標準価格
        private double _totalListPriceFl = 0;
        // 伝票枚数
        private int _totalSaleslipCnt = 0;
        // 明細数
        private int _totalCnt = 0;
        // 在庫移動確定区分

        #endregion // プライベート変数

        #region プロパティ
        /// <summary>
        /// データセットオブジェクト 
        /// </summary>
        public StockMoveDetailDataSet DataSet
        {
            get { return this._dataSet; }
        }

        /// <summary>
        /// 抽出中断フラグ
        /// </summary>
        public bool ExtractCancelFlag
        {
            get { return _extractCancelFlag; }
            set { _extractCancelFlag = value; }
        }

        /// <summary>
        /// 出荷/出庫 合計数量
        /// </summary>
        public double TotalMoveCounIn
        {
            get { return _totalMoveCountOut; }
            set { _totalMoveCountOut = value; }
        }

        /// <summary>
        /// 出荷/出庫 合計金額
        /// </summary>
        public double TotalStockMovePriceIn
        {
            get { return _totalStockMovePriceOut; }
            set { _totalStockMovePriceOut = value; }
        }

        /// <summary>
        /// 出荷/出庫 合計標準価格
        /// </summary>
        public double TotalListPriceFlIn
        {
            get { return _totalListPriceFlOut; }
            set { _totalListPriceFlOut = value; }
        }

        /// <summary>
        /// 入荷済/入庫 合計数量
        /// </summary>
        public double TotalMoveCounOut
        {
            get { return _totalMoveCountIn; }
            set { _totalMoveCountIn = value; }
        }

        /// <summary>
        /// 入荷済/入庫 合計金額
        /// </summary>
        public double TotalStockMovePriceOut
        {
            get { return _totalStockMovePriceIn; }
            set { _totalStockMovePriceIn = value; }
        }

        /// <summary>
        /// 入荷済/入庫 合計標準価格
        /// </summary>
        public double TotalListPriceFlOut
        {
            get { return _totalListPriceFlIn; }
            set { _totalListPriceFlIn = value; }
        }

        /// <summary>
        /// 未入荷 合計数量
        /// </summary>
        public double TotalMoveCoun
        {
            get { return _totalMoveCount; }
            set { _totalMoveCount = value; }
        }

        /// <summary>
        /// 未入荷 合計金額
        /// </summary>
        public double TotalStockMovePrice
        {
            get { return _totalStockMovePrice; }
            set { _totalStockMovePrice = value; }
        }

        /// <summary>
        /// 未入荷 合計標準価格
        /// </summary>
        public double TotalListPriceFl
        {
            get { return _totalListPriceFl; }
            set { _totalListPriceFl = value; }
        }

        /// <summary>
        /// 伝票枚数
        /// </summary>
        public int TotalSaleslipCnt
        {
            get { return _totalSaleslipCnt; }
            set { _totalSaleslipCnt = value; }
        }

        /// <summary>
        /// 明細数
        /// </summary>
        public int TotalCnt
        {
            get { return _totalCnt; }
            set { _totalCnt = value; }
        }

        #endregion // プロパティ

        #region delegate
        /// <summary>
        /// UpdateSectionEventHandler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="sectionCode"></param>
        /// <param name="sectionName"></param>
        public delegate void UpdateSectionEventHandler( object sender, string sectionCode, string sectionName );
        #endregion // delegate

        #region Search
        /// <summary>
        /// 検索
        /// </summary>
        /// <param name="stockMovePpr">検索条件クラス</param>
        /// <param name="logicalDelDiv">削除指定区分：0=標準,1=削除分のみ</param>
        /// <param name="counter">明細件数</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 検索処理。</br>
        /// <br>Programmer : yangmj</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br>Update Note: 2011/05/11 tianjw</br>
        /// <br>             redmine #20913</br>
        /// <br>Update Note: 2011/05/20 朱俊成 仕入先と仕入先名を追加します</br>
        /// <br></br>
        /// </remarks>
        public int Search( StockMovePpr stockMovePpr, int logicalDelDiv, out long counter )
        {
            int status;

            // パラメータクラスを作成
            StockMovePrtWork stockMovePrtWork = new StockMovePrtWork();
            StockMovePprStockMovePprWork(ref stockMovePpr, ref stockMovePrtWork);
            object stockMovePrtWorkObj = new object();
            //---------------------------------
            // 返り値で使用するクラスを作成
            //---------------------------------
            counter = 0;
 
            if ( _extractCancelFlag == true ) return 0;

            if ( logicalDelDiv == 0 )
            {
                // 削除分を含まない場合はGetData0を指定(削除フラグ=0のデータを返す)
                status = this._iStockMoveWorkDB.SearchRef(ref stockMovePrtWorkObj, (object)stockMovePrtWork, out counter, 0, ConstantManagement.LogicalMode.GetData0);
            }
            else
            {
                // 削除済みの場合はGetData1を指定(削除フラグ=1のデータを返す)
                status = this._iStockMoveWorkDB.SearchRef(ref stockMovePrtWorkObj, (object)stockMovePrtWork, out counter, 0, ConstantManagement.LogicalMode.GetData1);
            }
            if ( _extractCancelFlag == true ) return 0;
            // ※引数のreadModeは現在使用していないのでどんな値を入れても問題なし

            if (status != (int)ConstantManagement.DB_Status.ctDB_ERROR)
            {
                this._totalMoveCountIn = 0;
                this._totalStockMovePriceIn = 0;
                this._totalListPriceFlIn = 0;
                this._totalMoveCountOut = 0;
                this._totalStockMovePriceOut = 0;
                this._totalListPriceFlOut = 0;
                this._totalMoveCount = 0;
                this._totalStockMovePrice = 0;
                this._totalListPriceFl = 0;
                this._totalSaleslipCnt = 0;
                this._totalCnt = 0;

                DataRow row2;

                int rowNo = 1;
                if (counter > 0)
                {
                    int lastIndex = 0;

                    int maxCount = (stockMovePrtWorkObj as ArrayList).Count;
                    if (maxCount > stockMovePpr.SearchCnt - 1)
                    {
                        // リモートからは最大で20,001件返ってくるので、20,000件までにする
                        maxCount = (int)stockMovePpr.SearchCnt - 1;
                    }
                    DataRow row;

                    ArrayList keyList = new ArrayList();

                    for (int index = 0; index < maxCount; index++)
                    {
                        lastIndex = index;
                        StockMoveWork data = (StockMoveWork)((stockMovePrtWorkObj as ArrayList)[index]);

                        string key = data.StockMoveFormal.ToString() + data.StockMoveSlipNo.ToString();
                        string saleSlipNum = data.StockMoveSlipNo.ToString().PadLeft(9, '0');
                        if (keyList == null || keyList.Count == 0)
                        {
                            keyList.Add(key);
                            this._totalSaleslipCnt++;
                        }
                        else
                        {
                            if (!keyList.Contains(key))
                            {
                                this._totalSaleslipCnt++;
                                keyList.Add(key);
                            }
                        }

                        row = this._dataSet.StockMoveDetail.NewRow();

                        try
                        {
                            if (stockMovePrtWork.StockMoveFixCode == 1) // 在庫移動確定区分＝入荷確定あり
                            {
                                // 出力区分が「入荷済分」「未入荷分」で表示するときは非表示
                                if (stockMovePpr.OutputDiv == 1 || stockMovePpr.OutputDiv == 2)
                                {
                                    row[_dataSet.StockMoveDetail.SelectionCheckColumn.ColumnName] = DBNull.Value;
                                }
                                else
                                {
                                    row[_dataSet.StockMoveDetail.SelectionCheckColumn.ColumnName] = false;
                                }
                            }
                            else if (stockMovePrtWork.StockMoveFixCode == 2) // 在庫移動確定区分＝入荷確定なし
                            {
                                // 入庫データ（在庫移動形式=3,4）
                                if (data.StockMoveFormal == 3
                                    || data.StockMoveFormal == 4)
                                {
                                    row[_dataSet.StockMoveDetail.SelectionCheckColumn.ColumnName] = DBNull.Value;
                                }
                                else
                                {
                                    row[_dataSet.StockMoveDetail.SelectionCheckColumn.ColumnName] = false;
                                }
                            }

                            //row[_dataSet.StockMoveDetail.SelectionCheckColumn.ColumnName] = false;
                            // 1：入荷確定あり
                            if (stockMovePrtWork.StockMoveFixCode == 1)
                            {
                                //出力区分＝入荷済
                                if (stockMovePrtWork.OutputDiv == 1)
                                {
                                    row[_dataSet.StockMoveDetail.DateColumn.ColumnName] = data.ArrivalGoodsDay;// 入荷日

                                    this._totalMoveCountIn += data.MoveCount;
                                    this._totalStockMovePriceIn += data.StockMovePrice;
                                    this._totalListPriceFlIn += (long)((decimal)data.ListPriceFl * (decimal)data.MoveCount);
                                }
                                //出力区分＝出荷分
                                else if (stockMovePrtWork.OutputDiv == 0)
                                {
                                    row[_dataSet.StockMoveDetail.DateColumn.ColumnName] = data.ShipmentFixDay;//出荷確定日
                                    this._totalMoveCountOut += data.MoveCount;
                                    this._totalStockMovePriceOut += data.StockMovePrice;
                                    this._totalListPriceFlOut += (long)((decimal)data.ListPriceFl * (decimal)data.MoveCount);

                                }
                                //出力区分＝未入荷分
                                else
                                {
                                    row[_dataSet.StockMoveDetail.DateColumn.ColumnName] = data.ShipmentFixDay;//出荷確定日
                                    this._totalMoveCount += data.MoveCount;
                                    this._totalStockMovePrice += data.StockMovePrice;
                                    this._totalListPriceFl += (long)((decimal)data.ListPriceFl * (decimal)data.MoveCount);
                                }
                            }
                            //２：入荷確定なし 
                            else
                            {
                                row[_dataSet.StockMoveDetail.DateColumn.ColumnName] = data.ArrivalGoodsDay;// 入荷日
                                if (stockMovePrtWork.SalesSlipDiv == 0)
                                {
                                    if (data.StockMoveFormal == 1 || data.StockMoveFormal == 2)
                                    {
                                        this._totalMoveCountOut += data.MoveCount;
                                        this._totalStockMovePriceOut += data.StockMovePrice;
                                        this._totalListPriceFlOut += (long)((decimal)data.ListPriceFl * (decimal)data.MoveCount);
                                    }
                                    else
                                    {
                                        this._totalMoveCountIn += data.MoveCount;
                                        this._totalStockMovePriceIn += data.StockMovePrice;
                                        this._totalListPriceFlIn += (long)((decimal)data.ListPriceFl * (decimal)data.MoveCount);
                                    }
                                }
                                else if (stockMovePrtWork.SalesSlipDiv == 1)
                                {
                                    this._totalMoveCountOut += data.MoveCount;
                                    this._totalStockMovePriceOut += data.StockMovePrice;
                                    this._totalListPriceFlOut += (long)((decimal)data.ListPriceFl * (decimal)data.MoveCount);
                                }
                                else
                                {
                                    this._totalMoveCountIn += data.MoveCount;
                                    this._totalStockMovePriceIn += data.StockMovePrice;
                                    this._totalListPriceFlIn += (long)((decimal)data.ListPriceFl * (decimal)data.MoveCount);
                                }
                            }

                            row[_dataSet.StockMoveDetail.RowNoColumn.ColumnName] = rowNo;//行番号

                            row[_dataSet.StockMoveDetail.StockMoveSlipNoColumn.ColumnName] = saleSlipNum;//在庫移動伝票番号

                            row[_dataSet.StockMoveDetail.StockMoveRowNoColumn.ColumnName] = data.StockMoveRowNo;//在庫移動行番号

                            row[_dataSet.StockMoveDetail.StockMoveFormalCdColumn.ColumnName] = data.StockMoveFormal; // 区分コード

                            //区分表示
                            if (data.StockMoveFormal == 1 || data.StockMoveFormal == 2)
                            {
                                row[_dataSet.StockMoveDetail.StockMoveFormalDisplayColumn.ColumnName] = "出庫";
                            }
                            else if (data.StockMoveFormal == 3 || data.StockMoveFormal == 4)
                            {
                                row[_dataSet.StockMoveDetail.StockMoveFormalDisplayColumn.ColumnName] = "入庫";
                            }

                            // 担当者名
                            //出力区分＝入荷済
                            if (stockMovePrtWork.OutputDiv == 1)
                            {
                                row[_dataSet.StockMoveDetail.AgentNmColumn.ColumnName] = data.ReceiveAgentNm;// 引取担当従業員名称
                            }
                            else
                            {
                                row[_dataSet.StockMoveDetail.AgentNmColumn.ColumnName] = data.StockMvEmpName;// 在庫移動入力従業員名称
                            }

                            //品名
                            row[_dataSet.StockMoveDetail.GoodsNameColumn.ColumnName] = data.GoodsName;// 品名

                            //品番
                            row[_dataSet.StockMoveDetail.GoodsNoColumn.ColumnName] = data.GoodsNo;//品番

                            // メーカーコード
                            row[_dataSet.StockMoveDetail.GoodsMakerCdColumn.ColumnName] = data.GoodsMakerCd.ToString().PadLeft(4, '0'); ;// メーカーコード
                            // メーカー名
                            row[_dataSet.StockMoveDetail.MakerNameColumn.ColumnName] = data.MakerName;// メーカー名
                            // ADD 2011/05/20 -------------------------->>>>>>
                            // 仕入先コード
                            row[_dataSet.StockMoveDetail.SupplierCdColumn.ColumnName] = data.SupplierCd.ToString().PadLeft(6, '0'); ;// メーカーコード
                            // 仕入先ー名
                            row[_dataSet.StockMoveDetail.SupplierSnmColumn.ColumnName] = data.SupplierSnm;// メーカー名
                            // ADD 2011/05/20 --------------------------<<<<<<
                            // BLｺｰﾄﾞ
                            row[_dataSet.StockMoveDetail.BLGoodsCodeColumn.ColumnName] = data.BLGoodsCode.ToString().PadLeft(5, '0'); ;
                            // 移動単価
                            row[_dataSet.StockMoveDetail.StockUnitPriceFlColumn.ColumnName] = data.StockUnitPriceFl;
                            // 数量
                            row[_dataSet.StockMoveDetail.MoveCounColumn.ColumnName] = data.MoveCount;
                            // 標準価格
                            row[_dataSet.StockMoveDetail.ListPriceFlColumn.ColumnName] = data.ListPriceFl;
                            // 移動金額
                            row[_dataSet.StockMoveDetail.StockMovePriceColumn.ColumnName] = data.StockMovePrice;
                            // 入力拠点コード
                            row[_dataSet.StockMoveDetail.UpdateSecCdColumn.ColumnName] = data.UpdateSecCd.PadLeft(2, '0');
                            // 入力拠点名
                            row[_dataSet.StockMoveDetail.UpdateSecGuideSnmColumn.ColumnName] = data.UpdateSecNm;
                            // 出庫拠点コード
                            row[_dataSet.StockMoveDetail.BfSectionCodeColumn.ColumnName] = data.BfSectionCode.PadLeft(2, '0');
                            // 出庫拠点名
                            row[_dataSet.StockMoveDetail.BfSectionGuideSnmColumn.ColumnName] = data.BfSectionGuideSnm;
                            // 出庫倉庫
                            row[_dataSet.StockMoveDetail.BfEnterWarehCodeColumn.ColumnName] = data.BfEnterWarehCode.PadLeft(4, '0');
                            // 出庫倉庫名
                            row[_dataSet.StockMoveDetail.BfEnterWarehNameColumn.ColumnName] = data.BfEnterWarehName;
                            // 出庫棚番
                            row[_dataSet.StockMoveDetail.BfShelfNoColumn.ColumnName] = data.BfShelfNo;
                            // 入庫拠点コード
                            row[_dataSet.StockMoveDetail.AfSectionCodColumn.ColumnName] = data.AfSectionCode.PadLeft(2, '0');
                            // 入庫拠点名
                            row[_dataSet.StockMoveDetail.AfSectionGuideSnmColumn.ColumnName] = data.AfSectionGuideSnm;
                            // 入庫倉庫
                            row[_dataSet.StockMoveDetail.AfEnterWarehCodeColumn.ColumnName] = data.AfEnterWarehCode.PadLeft(4, '0');
                            // 入庫倉庫名
                            row[_dataSet.StockMoveDetail.AfEnterWarehNameColumn.ColumnName] = data.AfEnterWarehName;
                            // 入庫棚番
                            row[_dataSet.StockMoveDetail.AfShelfNoColumn.ColumnName] = data.AfShelfNo;
                            // 入荷区分
                            if (data.MoveStatus == 9)
                            {
                                row[_dataSet.StockMoveDetail.MoveStatusColumn.ColumnName] = "入荷済";
                            }
                            else
                            {
                                row[_dataSet.StockMoveDetail.MoveStatusColumn.ColumnName] = "未入荷";
                            }
                            // 出荷日
                            // ----- UPD 2011/05/11 tianjw --------------------------------------------------->>>>>
                            //row[_dataSet.StockMoveDetail.ShipmentFixDayColumn.ColumnName] = data.ShipmentFixDay;
                            if (data.ShipmentFixDay == DateTime.MinValue)
                            {
                                row[_dataSet.StockMoveDetail.ShipmentFixDayColumn.ColumnName] = DBNull.Value;
                            }
                            else
                            {
                                row[_dataSet.StockMoveDetail.ShipmentFixDayColumn.ColumnName] = data.ShipmentFixDay;
                            }
                            // 入荷日
                            //row[_dataSet.StockMoveDetail.ArrivalGoodsDayColumn.ColumnName] = data.ArrivalGoodsDay;
                            if (data.ArrivalGoodsDay == DateTime.MinValue)
                            {
                                row[_dataSet.StockMoveDetail.ArrivalGoodsDayColumn.ColumnName] = DBNull.Value;
                            }
                            else
                            {
                                row[_dataSet.StockMoveDetail.ArrivalGoodsDayColumn.ColumnName] = data.ArrivalGoodsDay;
                            }
                            // ----- UPD 2011/05/11 tianjw ---------------------------------------------------<<<<<
                            // 入力日
                            row[_dataSet.StockMoveDetail.InputDayColumn.ColumnName] = data.InputDay;
                            // 備考
                            row[_dataSet.StockMoveDetail.WarehouseNote1Column.ColumnName] = data.WarehouseNote1;

                            this._dataSet.StockMoveDetail.Rows.Add(row);
                            _totalCnt++;
                            rowNo++;

                            if (_extractCancelFlag == true)
                            {
                                break;
                            }
                        }
                        catch (ConstraintException ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
                else
                {
                    // 件数ゼロならばリモートstatus＝0:正常でも該当なしで返す
                    status = (int)ConstantManagement.DB_Status.ctDB_EOF;
                }

                // 合計表示部
                row2 = this._dataSet.StockMoveTotal.NewRow();
                // 出荷/出庫 合計数量
                row2[this._dataSet.StockMoveTotal.ShipmentCount_TotalColumn.ColumnName] = _totalMoveCountOut;
                // 出荷/出庫 合計金額
                row2[this._dataSet.StockMoveTotal.ShipmentPrice_TotalColumn.ColumnName] = _totalStockMovePriceOut;
                // 出荷/出庫 合計標準価格
                row2[this._dataSet.StockMoveTotal.ShipmentListPriceFl_TotalColumn] = _totalListPriceFlOut;
                // 入荷済/入庫 合計数量
                row2[this._dataSet.StockMoveTotal.ArrivalCount_TotalColumn.ColumnName] = _totalMoveCountIn;
                // 入荷済/入庫 合計金額
                row2[this._dataSet.StockMoveTotal.ArrivalPrice_TotalColumn.ColumnName] = _totalStockMovePriceIn;
                // 入荷済/入庫 合計標準価格
                row2[this._dataSet.StockMoveTotal.ArrivalListPriceFl_TotalColumn.ColumnName] = _totalListPriceFlIn;
                // 未入荷 合計数量
                row2[this._dataSet.StockMoveTotal.NotArrivalCount_TotalColumn.ColumnName] = _totalMoveCount;
                // 未入荷 合計金額
                row2[this._dataSet.StockMoveTotal.NotArrivalPrice_TotalColumn.ColumnName] = _totalStockMovePrice;
                // 未入荷 合計標準価格
                row2[this._dataSet.StockMoveTotal.NotArrivalListPriceFl_TotalColumn.ColumnName] = _totalListPriceFl;
                // 伝票枚数
                row2[this._dataSet.StockMoveTotal.SlipCountColumn.ColumnName] = _totalSaleslipCnt;
                // 明細数
                row2[this._dataSet.StockMoveTotal.DetailCountColumn.ColumnName] = _totalCnt;

                this._dataSet.StockMoveTotal.Rows.Add(row2);
            }
            return status;
        }
        #endregion // Search

        #region StockMovePprStockMovePprWork
        /// <summary>
        /// パラメータクラス(PMZAI04602E.StockMovePpr)からリモートパラメータクラス(PMKAU04016D.StockMovePrtWork)クラスへ変換
        /// </summary>
        /// <param name="stockMovePpr"></param>
        /// <param name="stockMovePrtWork"></param>
        /// <remarks>
        /// <br>Note       : 変換処理。</br>
        /// <br>Programmer : yangmj</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private void StockMovePprStockMovePprWork(ref StockMovePpr stockMovePpr, ref StockMovePrtWork stockMovePrtWork)
        {
            stockMovePrtWork.SearchCnt = stockMovePpr.SearchCnt;
            stockMovePrtWork.EnterpriseCode = stockMovePpr.EnterpriseCode;
            stockMovePrtWork.OutputDiv = stockMovePpr.OutputDiv;
            stockMovePrtWork.InputSectionCode = stockMovePpr.InputSectionCode;
            stockMovePrtWork.SectionCode = stockMovePpr.SectionCode;
            stockMovePrtWork.WarehouseCode = stockMovePpr.WarehouseCode;
            stockMovePrtWork.St_Date = stockMovePpr.St_Date;
            stockMovePrtWork.Ed_Date = stockMovePpr.Ed_Date;
            stockMovePrtWork.SalesSlipNum = stockMovePpr.SalesSlipNum;
            stockMovePrtWork.St_AddUpADate = stockMovePpr.St_AddUpADate;
            stockMovePrtWork.Ed_AddUpADate = stockMovePpr.Ed_AddUpADate;
            stockMovePrtWork.SalesEmployeeCd = stockMovePpr.SalesEmployeeCd;
            stockMovePrtWork.SupplierCd = stockMovePpr.SupplierCd;
            stockMovePrtWork.GoodsMakerCd = stockMovePpr.GoodsMakerCd;
            stockMovePrtWork.BLGoodsCode = stockMovePpr.BLGoodsCode;
            stockMovePrtWork.GoodsNo = stockMovePpr.GoodsNo;
            stockMovePrtWork.GoodsName = stockMovePpr.GoodsName;
            stockMovePrtWork.WarehouseShelfNo = stockMovePpr.WarehouseShelfNo;
            stockMovePrtWork.AfSectionCode = stockMovePpr.AfSectionCode;
            stockMovePrtWork.AfEnterWarehCode = stockMovePpr.AfEnterWarehCode;
            stockMovePrtWork.ArrivalGoodsFlag = stockMovePpr.ArrivalGoodsFlag;
            stockMovePrtWork.SlipNote = stockMovePpr.SlipNote;
            stockMovePrtWork.DeleteFlag = stockMovePpr.DeleteFlag;
            stockMovePrtWork.StockMoveFixCode = stockMovePpr.StockMoveFixCode;
            stockMovePrtWork.SalesSlipDiv = stockMovePpr.SalesSlipDiv;
        }
        #endregion // StockMovePprStockMovePprWork
    }
}

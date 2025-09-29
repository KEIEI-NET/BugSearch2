using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;

using Broadleaf.Library.Collections;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Windows.Forms;
using Broadleaf.Library.Text;
using Broadleaf.Library.Globarization;
using Broadleaf.Application.LocalAccess;

using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Runtime.InteropServices;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 商品アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 商品アクセスクラス(価格情報)のアクセス制御を行います。</br>
    /// <br>Programmer : 20056 對馬 大輔</br>
    /// <br>Date       : 2008.06.18</br>
    /// <br>Update Note: 2009/02/03 30414 忍 幸史 障害ID:10848対応</br>
    /// <br>Update Note: 2009/03/17 30414 忍 幸史 障害ID:12473対応</br>
    /// <br>Update Note: 2012/12/06 田建委</br>
    /// <br>管理番号   : 2013/01/16配信分</br>
    /// <br>             Redmine#33663の#4 掛率単品原価【仕入単価】が設定された場合、掛率データ仕入単価の参照表示不正の対応</br>
    /// <br>Update Note: 2013/02/08 田建委</br>
    /// <br>管理番号   : 10806793-00 2013/03/26配信分</br>
    /// <br>             Redmine#34640 商品在庫マスタの仕様変更(#33231の残留分)</br>
    /// </remarks>
    public partial class GoodsAcs
    {
        /// <summary>
        /// 価格情報キャッシュ処理
        /// </summary>
        /// <param name="goodsUnitData">商品連結データオブジェクト</param>
        public void CacheGoodsPrice(GoodsUnitData goodsUnitData)
        {
            int rowNo = 1;
            _goodsPriceDataTable.Clear();
            List<GoodsPrice> goodsPriceList = goodsUnitData.GoodsPriceList;
            goodsPriceList.Sort(); // メーカー(降順)・品番(降順)・価格開始日(昇順)
            foreach (GoodsPrice goodsPrice in goodsPriceList)
            {
                this.CacheGoodsPrice(rowNo, goodsPrice, _goodsPriceDataTable, goodsUnitData);
                rowNo++;
            }

            while (true)
            {
                if (rowNo > ctGoodsPriceMaxCount) break;

                GoodsPrice goodsPrice = new GoodsPrice();
                this.AddGoodsPriceEmptyRow(rowNo, goodsPrice, _goodsPriceDataTable);
                rowNo++;
            }
        }

        /// <summary>
        /// 価格情報キャッシュ処理
        /// </summary>
        /// <param name="rowNo"></param>
        /// <param name="goodsPrice"></param>
        /// <param name="goodsPriceDataTable"></param>
        /// <param name="goodsUnitData"></param>
        private void CacheGoodsPrice(int rowNo, GoodsPrice goodsPrice, GoodsInputDataSet.GoodsPriceDataTable goodsPriceDataTable, GoodsUnitData goodsUnitData)
        {
            try
            {
                goodsPriceDataTable.AddGoodsPriceRow(this.CreateRowFromUIData(rowNo, goodsPrice, goodsPriceDataTable, goodsUnitData));
            }
            catch (ConstraintException)
            {
                DataRow[] rows = _goodsPriceDataTable.Select(string.Format("{0}={1} and {2}={3} and {4}={5}",
                    this.GoodsPriceDataTable.GoodsMakerCdColumn, goodsPrice.GoodsMakerCd,
                    this.GoodsPriceDataTable.GoodsNoColumn, goodsPrice.GoodsNo,
                    this.GoodsPriceDataTable.PriceStartDateColumn, goodsPrice.PriceStartDate));

                GoodsInputDataSet.GoodsPriceRow goodsPriceRow = (GoodsInputDataSet.GoodsPriceRow)rows[0];
                this.SetGoodsPriceRowFromUIData(ref goodsPriceRow, goodsPrice, goodsUnitData);
            }
        }

        /// <summary>
        /// 価格情報空行追加処理
        /// </summary>
        /// <param name="rowNo"></param>
        /// <param name="goodsPrice"></param>
        /// <param name="goodsPriceDataTable"></param>
        public void AddGoodsPriceEmptyRow(int rowNo, GoodsPrice goodsPrice, GoodsInputDataSet.GoodsPriceDataTable goodsPriceDataTable)
        {
            goodsPriceDataTable.AddGoodsPriceRow(this.CreateRowFromUIData(rowNo, goodsPrice, goodsPriceDataTable, null));
        }

        /// <summary>
        /// 価格情報データテーブル初期化
        /// </summary>
        public void ClearGoodsPriceDataTable()
        {
            this.ClearGoodsPriceDataTable(ref _goodsPriceDataTable);
        }

        /// <summary>
        /// 価格情報データテーブル初期化
        /// </summary>
        /// <param name="goodsPriceDataTable"></param>
        private void ClearGoodsPriceDataTable(ref GoodsInputDataSet.GoodsPriceDataTable goodsPriceDataTable)
        {
            goodsPriceDataTable.Clear();
            for (int i = 1; i <= GoodsAcs.ctGoodsPriceMaxCount; i++)
            {
                GoodsPrice goodsPrice = new GoodsPrice();
                this.AddGoodsPriceEmptyRow(i, goodsPrice, goodsPriceDataTable);
            }
        }

        /// <summary>
        /// 価格情報データ行オブジェクト生成処理
        /// </summary>
        /// <param name="rowNo"></param>
        /// <param name="goodsPrice"></param>
        /// <param name="goodsPriceDataTable"></param>
        /// <param name="goodsUnitData"></param>
        /// <returns></returns>
        private GoodsInputDataSet.GoodsPriceRow CreateRowFromUIData(int rowNo, GoodsPrice goodsPrice, GoodsInputDataSet.GoodsPriceDataTable goodsPriceDataTable, GoodsUnitData goodsUnitData)
        {
            GoodsInputDataSet.GoodsPriceRow goodsPriceRow = goodsPriceDataTable.NewGoodsPriceRow();
            goodsPriceRow.FileHeaderGuid = Guid.Empty;
            this.SetGoodsPriceRowFromUIData(ref goodsPriceRow, goodsPrice, goodsUnitData);
            goodsPriceRow.RowNo = rowNo;
            return goodsPriceRow;
        }

        /// <summary>
        /// 価格情報データ行オブジェクト設定処理
        /// </summary>
        /// <param name="goodsPriceRow"></param>
        /// <param name="goodsPrice"></param>
        /// <param name="goodsUnitData"></param>
        /// <remarks>
        /// <br>Update Note: 2013/02/08 田建委</br>
        /// <br>管理番号   : 10806793-00 2013/03/26配信分</br>
        /// <br>             Redmine#34640 商品在庫マスタの仕様変更(#33231の残留分)</br>
        /// </remarks>
        private void SetGoodsPriceRowFromUIData(ref GoodsInputDataSet.GoodsPriceRow goodsPriceRow, GoodsPrice goodsPrice, GoodsUnitData goodsUnitData)
        {
            goodsPriceRow.CreateDateTime = goodsPrice.CreateDateTime; // 作成日時
            goodsPriceRow.UpdateDateTime = goodsPrice.UpdateDateTime; // 更新日時
            goodsPriceRow.EnterpriseCode = goodsPrice.EnterpriseCode; // 企業コード
            goodsPriceRow.FileHeaderGuid = goodsPrice.FileHeaderGuid; // GUID
            goodsPriceRow.UpdEmployeeCode = goodsPrice.UpdEmployeeCode; // 更新従業員コード
            goodsPriceRow.UpdAssemblyId1 = goodsPrice.UpdAssemblyId1; // 更新アセンブリID1
            goodsPriceRow.UpdAssemblyId2 = goodsPrice.UpdAssemblyId2; // 更新アセンブリID2
            goodsPriceRow.LogicalDeleteCode = goodsPrice.LogicalDeleteCode; // 論理削除区分
            goodsPriceRow.GoodsMakerCd = goodsPrice.GoodsMakerCd; // 商品メーカーコード
            goodsPriceRow.GoodsNo = goodsPrice.GoodsNo; // 商品番号
            goodsPriceRow.PriceStartDate = goodsPrice.PriceStartDate; // 価格開始日
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/11/04 ADD
            if ( goodsPrice.PriceStartDate != null && goodsPrice.PriceStartDate != DateTime.MinValue )
            {
                goodsPriceRow.PriceStartDateYear = goodsPrice.PriceStartDate.Year;
                goodsPriceRow.PriceStartDateMonth = goodsPrice.PriceStartDate.Month;
                goodsPriceRow.PriceStartDateDay = goodsPrice.PriceStartDate.Day;
                goodsPriceRow.PriceStartDateDis = Broadleaf.Library.Globarization.TDateTime.DateTimeToLongDate(goodsPrice.PriceStartDate); // ADD 2013/02/08 田建委
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/11/04 ADD
            goodsPriceRow.ListPrice = goodsPrice.ListPrice; // 定価（浮動）
            goodsPriceRow.SalesUnitCost = goodsPrice.SalesUnitCost; // 原価単価
            goodsPriceRow.StockRate = goodsPrice.StockRate; // 仕入率
            goodsPriceRow.OpenPriceDiv = goodsPrice.OpenPriceDiv; // オープン価格区分
            goodsPriceRow.OfferDate = goodsPrice.OfferDate; // 提供日付

            // 2009.04.06 30413 犬飼 商品連結データnullを考慮 >>>>>>START
            // 2009.04.01 30413 犬飼 仕入単価端数処理コードの追加 >>>>>>START
            //goodsPriceRow.StockUnPrcFrcProcCd = goodsUnitData.StockUnPrcFrcProcCd;  // 仕入単価端数処理コード
            if (goodsUnitData != null)
            {
                goodsPriceRow.StockUnPrcFrcProcCd = goodsUnitData.StockUnPrcFrcProcCd;  // 仕入単価端数処理コード
            }
            // 2009.04.01 30413 犬飼 仕入単価端数処理コードの追加 <<<<<<END
            // 2009.04.06 30413 犬飼 商品連結データnullを考慮 <<<<<<END
            
            if (goodsUnitData != null) this.CalclateUnitPrice(goodsPriceRow, goodsUnitData); // 単価算出
            this.SettingCalcMaster(goodsPriceRow); // 算出マスタ
            this.SettingCalcStockRate(goodsPriceRow); // 算出用原価率
            this.SettingCalcSalesUnitCost(goodsPriceRow); // 算出用原価単価
            
        }

        /// <summary>
        /// 価格情報データ行オブジェクト削除処理
        /// </summary>
        /// <param name="goodsMakerCode"></param>
        /// <param name="goodsNo"></param>
        /// <param name="priceStartDate"></param>
        private void DeleteGoodsPriceRow(int goodsMakerCode, string goodsNo, DateTime priceStartDate)
        {
            DataRow[] rows = _goodsPriceDataTable.Select(string.Format("{0}={1} and {2}={3} and {4}={5}",
                this.GoodsPriceDataTable.GoodsMakerCdColumn, goodsMakerCode,
                this.GoodsPriceDataTable.GoodsNoColumn, goodsNo,
                this.GoodsPriceDataTable.PriceStartDateColumn, priceStartDate));

            GoodsInputDataSet.GoodsPriceRow goodsPriceRow = (GoodsInputDataSet.GoodsPriceRow)rows[0];
            if (goodsPriceRow != null)
            {
                _goodsPriceDataTable.RemoveGoodsPriceRow(goodsPriceRow);
            }
        }

        /// <summary>
        /// 価格情報データオブジェクトリスト取得処理
        /// </summary>
        /// <param name="goodsPriceList"></param>
        public void GetGoodsPriceListFromGoodsPriceDataTable(out List<GoodsPrice> goodsPriceList)
        {
            this.GetGoodsPriceListFromGoodsPriceDataTableProc(_goodsPriceDataTable, out goodsPriceList);
        }

        /// <summary>
        /// 価格情報データオブジェクトリスト取得処理
        /// </summary>
        /// <param name="goodsPriceDataTable"></param>
        /// <param name="goodsPriceList"></param>
        public void GetGoodsPriceListFromGoodsPriceDataTable(GoodsInputDataSet.GoodsPriceDataTable goodsPriceDataTable, out List<GoodsPrice> goodsPriceList)
        {
            this.GetGoodsPriceListFromGoodsPriceDataTableProc(goodsPriceDataTable, out goodsPriceList);
        }

        /// <summary>
        /// 価格情報データオブジェクトリスト取得処理
        /// </summary>
        /// <param name="goodsPriceDataTable"></param>
        /// <param name="goodsPriceList"></param>
        private void GetGoodsPriceListFromGoodsPriceDataTableProc(GoodsInputDataSet.GoodsPriceDataTable goodsPriceDataTable, out List<GoodsPrice> goodsPriceList)
        {
            goodsPriceList = new List<GoodsPrice>();

            foreach (GoodsInputDataSet.GoodsPriceRow goodsPriceRow in goodsPriceDataTable)
            {
                GoodsPrice goodsPrice = new GoodsPrice();
                
                goodsPrice.CreateDateTime = goodsPriceRow.CreateDateTime; // 作成日時
                goodsPrice.UpdateDateTime = goodsPriceRow.UpdateDateTime; // 更新日時
                goodsPrice.EnterpriseCode = goodsPriceRow.EnterpriseCode; // 企業コード
                goodsPrice.FileHeaderGuid = goodsPriceRow.FileHeaderGuid; // GUID
                goodsPrice.UpdEmployeeCode = goodsPriceRow.UpdEmployeeCode; // 更新従業員コード
                goodsPrice.UpdAssemblyId1 = goodsPriceRow.UpdAssemblyId1; // 更新アセンブリID1
                goodsPrice.UpdAssemblyId2 = goodsPriceRow.UpdAssemblyId2; // 更新アセンブリID2
                goodsPrice.LogicalDeleteCode = goodsPriceRow.LogicalDeleteCode; // 論理削除区分
                goodsPrice.GoodsMakerCd = goodsPriceRow.GoodsMakerCd; // 商品メーカーコード
                goodsPrice.GoodsNo = goodsPriceRow.GoodsNo; // 商品番号
                goodsPrice.PriceStartDate = goodsPriceRow.PriceStartDate; // 価格開始日
                goodsPrice.ListPrice = goodsPriceRow.ListPrice; // 定価（浮動）
                goodsPrice.SalesUnitCost = goodsPriceRow.SalesUnitCost; // 原価単価
                goodsPrice.StockRate = goodsPriceRow.StockRate; // 仕入率
                goodsPrice.OpenPriceDiv = goodsPriceRow.OpenPriceDiv; // オープン価格区分
                goodsPrice.OfferDate = goodsPriceRow.OfferDate; // 提供日付

                goodsPriceList.Add(goodsPrice);
            }
        }

        /// <summary>
        /// 価格情報データオブジェクトリスト取得処理
        /// </summary>
        /// <param name="goodsPriceWorkList">価格情報データワークオブジェクトリスト</param>
        /// <param name="goodsPriceList">価格情報データオブジェクトリスト</param>
        private void GetGoodsPriceListFromGoodsPriceUWorkList(ArrayList goodsPriceWorkList, out List<GoodsPrice> goodsPriceList)
        {
            goodsPriceList = new List<GoodsPrice>();

            foreach (GoodsPriceUWork goodsPriceUWork in goodsPriceWorkList)
            {
                GoodsPrice goodsPrice = new GoodsPrice();

                goodsPrice.CreateDateTime = goodsPriceUWork.CreateDateTime; // 作成日時
                goodsPrice.UpdateDateTime = goodsPriceUWork.UpdateDateTime; // 更新日時
                goodsPrice.EnterpriseCode = goodsPriceUWork.EnterpriseCode; // 企業コード
                goodsPrice.FileHeaderGuid = goodsPriceUWork.FileHeaderGuid; // GUID
                goodsPrice.UpdEmployeeCode = goodsPriceUWork.UpdEmployeeCode; // 更新従業員コード
                goodsPrice.UpdAssemblyId1 = goodsPriceUWork.UpdAssemblyId1; // 更新アセンブリID1
                goodsPrice.UpdAssemblyId2 = goodsPriceUWork.UpdAssemblyId2; // 更新アセンブリID2
                goodsPrice.LogicalDeleteCode = goodsPriceUWork.LogicalDeleteCode; // 論理削除区分
                goodsPrice.GoodsMakerCd = goodsPriceUWork.GoodsMakerCd; // 商品メーカーコード
                goodsPrice.GoodsNo = goodsPriceUWork.GoodsNo; // 商品番号
                goodsPrice.PriceStartDate = goodsPriceUWork.PriceStartDate; // 価格開始日
                goodsPrice.ListPrice = goodsPriceUWork.ListPrice; // 定価（浮動）
                goodsPrice.SalesUnitCost = goodsPriceUWork.SalesUnitCost; // 原価単価
                goodsPrice.StockRate = goodsPriceUWork.StockRate; // 仕入率
                goodsPrice.OpenPriceDiv = goodsPriceUWork.OpenPriceDiv; // オープン価格区分
                goodsPrice.OfferDate = goodsPriceUWork.OfferDate; // 提供日付
                goodsPrice.UpdateDate = goodsPriceUWork.UpdateDate; // 更新年月日

                goodsPriceList.Add(goodsPrice);
            }
        }

        /// <summary>
        /// 価格情報データワークオブジェクトリスト取得処理
        /// </summary>
        /// <param name="goodsPriceList">価格情報データワークオブジェクトリスト</param>
        /// <param name="goodsPriceWorkList">価格情報データオブジェクトリスト</param>
        private void GetGoodsPriceUWorkListFromGoodsPriceList(List<GoodsPrice> goodsPriceList, out ArrayList goodsPriceWorkList)
        {
            goodsPriceWorkList = new ArrayList();
            foreach (GoodsPrice goodsPrice in goodsPriceList)
            {
                if (goodsPrice.PriceStartDate != DateTime.MinValue)
                {
                    GoodsPriceUWork goodsPriceUWork = new GoodsPriceUWork();

                    goodsPriceUWork.CreateDateTime = goodsPrice.CreateDateTime; // 作成日時
                    goodsPriceUWork.UpdateDateTime = goodsPrice.UpdateDateTime; // 更新日時
                    goodsPriceUWork.EnterpriseCode = goodsPrice.EnterpriseCode; // 企業コード
                    goodsPriceUWork.FileHeaderGuid = goodsPrice.FileHeaderGuid; // GUID
                    goodsPriceUWork.UpdEmployeeCode = goodsPrice.UpdEmployeeCode; // 更新従業員コード
                    goodsPriceUWork.UpdAssemblyId1 = goodsPrice.UpdAssemblyId1; // 更新アセンブリID1
                    goodsPriceUWork.UpdAssemblyId2 = goodsPrice.UpdAssemblyId2; // 更新アセンブリID2
                    goodsPriceUWork.LogicalDeleteCode = goodsPrice.LogicalDeleteCode; // 論理削除区分
                    goodsPriceUWork.GoodsMakerCd = goodsPrice.GoodsMakerCd; // 商品メーカーコード
                    goodsPriceUWork.GoodsNo = goodsPrice.GoodsNo; // 商品番号
                    goodsPriceUWork.PriceStartDate = goodsPrice.PriceStartDate; // 価格開始日
                    goodsPriceUWork.ListPrice = goodsPrice.ListPrice; // 定価（浮動）
                    goodsPriceUWork.SalesUnitCost = goodsPrice.SalesUnitCost; // 原価単価
                    goodsPriceUWork.StockRate = goodsPrice.StockRate; // 仕入率
                    goodsPriceUWork.OpenPriceDiv = goodsPrice.OpenPriceDiv; // オープン価格区分
                    goodsPriceUWork.OfferDate = goodsPrice.OfferDate; // 提供日付
                    goodsPriceUWork.UpdateDate = goodsPrice.UpdateDate; // 更新年月日

                    goodsPriceWorkList.Add(goodsPriceUWork);
                }
            }
        }


        /// <summary>
        /// 価格情報データ行オブジェクト取得処理
        /// </summary>
        /// <param name="goodsNo"></param>
        /// <param name="goodsMakerCd"></param>
        /// <param name="priceStartDate"></param>
        /// <returns></returns>
        public GoodsInputDataSet.GoodsPriceRow GetGoodsPriceRowFromGoodsPriceDataTable(string goodsNo, int goodsMakerCd, DateTime priceStartDate)
        {
            DataRow[] rows = _goodsPriceDataTable.Select(string.Format("{0}={1} and {2}={3} and {4}={5}",
                this.GoodsPriceDataTable.GoodsMakerCdColumn, goodsMakerCd,
                this.GoodsPriceDataTable.GoodsNoColumn, goodsNo,
                this.GoodsPriceDataTable.PriceStartDateColumn, priceStartDate));

            GoodsInputDataSet.GoodsPriceRow goodsPriceRow = (GoodsInputDataSet.GoodsPriceRow)rows[0];
            return goodsPriceRow;
        }

        /// <summary>
        /// 価格情報データ行オブジェクト取得処理
        /// </summary>
        /// <param name="rowNo"></param>
        /// <returns></returns>
        public GoodsInputDataSet.GoodsPriceRow GetGoodsPriceRowFromGoodsPriceDataTable(int rowNo)
        {
            GoodsInputDataSet.GoodsPriceRow goodsPriceRow = _goodsPriceDataTable.FindByRowNo(rowNo);
            return goodsPriceRow;
        }

        /// <summary>
        /// 指定日条件該当価格情報データ行オブジェクト取得処理
        /// </summary>
        /// <param name="targetDateTime"></param>
        /// <returns></returns>
        public GoodsInputDataSet.GoodsPriceRow GetGoodsPriceRowFromGoodsPriceDataTable(DateTime targetDateTime)
        {
            DataView goodsPriceDataView = _goodsPriceDataTable.DefaultView;
            goodsPriceDataView.Sort = string.Format("{0}, {1}, {2} DESC", _goodsPriceDataTable.GoodsMakerCdColumn,
                                                                          _goodsPriceDataTable.GoodsNoColumn,
                                                                          _goodsPriceDataTable.PriceStartDateColumn);
            foreach (DataRowView dv in goodsPriceDataView)
            {
                DateTime priceStartDate = (DateTime)dv[_goodsPriceDataTable.PriceStartDateColumn.ColumnName];
                if (priceStartDate >= targetDateTime)
                {
                    GoodsInputDataSet.GoodsPriceRow goodsPriceRow = _goodsPriceDataTable.FindByRowNo((int)dv[_goodsPriceDataTable.RowNoColumn.ColumnName]);
                    return goodsPriceRow;
                }
            }
            return null;
        }

        /// <summary>
        /// 指定日条件該当価格情報データオブジェクト取得処理
        /// </summary>
        /// <param name="targetDateTime"></param>
        /// <param name="goodsPriceList"></param>
        /// <returns></returns>
        public GoodsPrice GetGoodsPriceFromGoodsPriceList(DateTime targetDateTime, List<GoodsPrice> goodsPriceList)
        {
            if ((goodsPriceList != null) && (goodsPriceList.Count != 0))
            {
                goodsPriceList.Sort(); // メーカー(降順)・品番(降順)・価格開始日(昇順)

                foreach (GoodsPrice goodsPrice in goodsPriceList)
                {
                    if (goodsPrice.PriceStartDate != DateTime.MinValue)
                    {
                        if (goodsPrice.PriceStartDate <= targetDateTime)
                        {
                            return goodsPrice;
                        }
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// 価格開始日入力チェック
        /// </summary>
        /// <returns>ture:入力あり false:入力なし</returns>
        public bool CheckInputPriceStartDate()
        {
            foreach (GoodsInputDataSet.GoodsPriceRow goodsPriceRow in _goodsPriceDataTable)
            {
                if (goodsPriceRow.PriceStartDate == DateTime.MinValue) continue;
                if (goodsPriceRow.PriceStartDate != DateTime.MinValue) return true;
            }
            return false;
        }

        /// <summary>
        /// 価格開始日重複チェック
        /// </summary>
        /// <param name="priceStartDate"></param>
        /// <returns>true:重複あり false:重複なし</returns>
        public bool CheckRepeatPriceStartDate(DateTime priceStartDate)
        {
            foreach (GoodsInputDataSet.GoodsPriceRow goodsPriceRow in _goodsPriceDataTable)
            {
                if (goodsPriceRow.PriceStartDate == DateTime.MinValue) continue;
                if (goodsPriceRow.PriceStartDate == priceStartDate) return true;
            }
            return false;
        }

        /// <summary>
        /// 計算原価率入力チェック
        /// </summary>
        /// <param name="rowNo"></param>
        /// <returns>true:入力あり false:入力なし</returns>
        public bool CheckInputCalcStockRate(int rowNo)
        {
            bool ret = false;

            GoodsInputDataSet.GoodsPriceRow goodsPriceRow = _goodsPriceDataTable.FindByRowNo(rowNo);
            if (goodsPriceRow != null)
            {
                if (goodsPriceRow.CalcStockRate != 0) ret = true;
            }

            return ret;
        }

        /// <summary>
        /// メーカー・品番設定処理
        /// </summary>
        /// <param name="rowNo"></param>
        /// <param name="goodsMakerCd"></param>
        /// <param name="goodsNo"></param>
        public void SettingKeyValue(int rowNo, int goodsMakerCd, string goodsNo)
        {
            GoodsInputDataSet.GoodsPriceRow goodsPriceRow = _goodsPriceDataTable.FindByRowNo(rowNo);
            this.SettingKeyValue(goodsPriceRow, goodsMakerCd, goodsNo);
        }

        /// <summary>
        /// メーカー・品番設定処理
        /// </summary>
        /// <param name="goodsPriceRow"></param>
        /// <param name="goodsMakerCd"></param>
        /// <param name="goodsNo"></param>
        public void SettingKeyValue(GoodsInputDataSet.GoodsPriceRow goodsPriceRow, int goodsMakerCd, string goodsNo)
        {
            if (goodsPriceRow != null)
            {
                goodsPriceRow.GoodsMakerCd = goodsMakerCd;
                goodsPriceRow.GoodsNo = goodsNo;
            }
        }

        /// <summary>
        /// メーカー・品番設定処理
        /// </summary>
        /// <param name="goodsPriceList"></param>
        /// <param name="goodsMakerCd"></param>
        /// <param name="goodsNo"></param>
        public void SettingKeyValue(List<GoodsPrice> goodsPriceList, int goodsMakerCd, string goodsNo)
        {
            if (goodsPriceList != null)
            {
                foreach (GoodsPrice goodsPrice in goodsPriceList)
                {
                    goodsPrice.GoodsMakerCd = goodsMakerCd;
                    goodsPrice.GoodsNo = goodsNo;
                }
            }
        }
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/09/10 ADD
        /// <summary>
        /// メーカー・品番設定処理
        /// </summary>
        /// <param name="stockList"></param>
        /// <param name="goodsMakerCd"></param>
        /// <param name="goodsNo"></param>
        public void SettingKeyValue( List<Stock> stockList, int goodsMakerCd, string goodsNo )
        {
            if ( stockList != null )
            {
                foreach ( Stock stock in stockList )
                {
                    stock.GoodsMakerCd = goodsMakerCd;
                    stock.GoodsNo = goodsNo;

                    // --- ADD 2008/12/24 [障害ID:9457対応]----------------------------------------------------------->>>>>
                    stock.GoodsNoNoneHyphen = goodsNo.Replace("-", "").TrimEnd(); // ハイフン無品番
                    // --- ADD 2008/12/24 [障害ID:9457対応]-----------------------------------------------------------<<<<<
                }
            }
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/09/10 ADD

        /// <summary>
        /// 計算用原価率設定処理
        /// </summary>
        /// <param name="rowNo"></param>
        public void SettingCalcStockRate(int rowNo)
        {
            GoodsInputDataSet.GoodsPriceRow goodsPriceRow = _goodsPriceDataTable.FindByRowNo(rowNo);
            this.SettingCalcStockRate(goodsPriceRow);
        }

        /// <summary>
        /// 計算用原価率設定処理
        /// </summary>
        /// <param name="goodsPriceRow"></param>
        public void SettingCalcStockRate(GoodsInputDataSet.GoodsPriceRow goodsPriceRow)
        {
            if (goodsPriceRow != null)
            {
                if (goodsPriceRow.SalesUnitCost == 0)
                {
                    if (goodsPriceRow.StockRate != 0)
                    {
                        // 2009.04.02 30413 犬飼 掛率を上書きしないように修正 >>>>>>START
                        //goodsPriceRow.CalcStockRate = goodsPriceRow.StockRate;
                        // 2009.04.02 30413 犬飼 掛率を上書きしないように修正 <<<<<<END
                    }
                }
                else
                {
                    goodsPriceRow.CalcStockRate = 0;
                }
            }
        }

        /// <summary>
        /// 計算原価額設定処理
        /// </summary>
        /// <param name="rowNo"></param>
        public void SettingCalcSalesUnitCost(int rowNo)
        {
            GoodsInputDataSet.GoodsPriceRow goodsPriceRow = _goodsPriceDataTable.FindByRowNo(rowNo);
            this.SettingCalcSalesUnitCost(goodsPriceRow);
        }

        /// <summary>
        /// 計算原価額設定処理
        /// </summary>
        /// <param name="goodsPriceRow"></param>
        public void SettingCalcSalesUnitCost(GoodsInputDataSet.GoodsPriceRow goodsPriceRow)
        {
            if (goodsPriceRow != null)
            {
                if (goodsPriceRow.SalesUnitCost == 0)
                {
                    if (goodsPriceRow.CalcSalesUnitCost == 0)
                    {
                        double fracProcUnit = 0;
                        int fracProcCd = 0;
                        // 2009.04.02 30413 犬飼 仕入率が入力されている場合を考慮 >>>>>>START
                        double stockRate = goodsPriceRow.CalcStockRate;
                        if (goodsPriceRow.StockRate != 0.0)
                        {
                            stockRate = goodsPriceRow.StockRate;
                        }
                        //double unitCost = this.CalclateUnitPriceByRate(UnitPriceKind.UnitCost, 0, goodsPriceRow.ListPrice, goodsPriceRow.CalcStockRate, ref fracProcUnit, ref fracProcCd);
                        double unitCost = this.CalclateUnitPriceByRate(UnitPriceKind.UnitCost, goodsPriceRow.StockUnPrcFrcProcCd, goodsPriceRow.ListPrice, stockRate, ref fracProcUnit, ref fracProcCd);
                        // 2009.04.02 30413 犬飼 仕入率が入力されている場合を考慮 <<<<<<END
                        goodsPriceRow.CalcSalesUnitCost = unitCost;
                    }
                }
                else
                {
                    goodsPriceRow.CalcSalesUnitCost = goodsPriceRow.SalesUnitCost;
                }
            }
        }

        /// <summary>
        /// 算出マスタ設定処理
        /// </summary>
        /// <param name="rowNo"></param>
        public void SettingCalcMaster(int rowNo)
        {
            GoodsInputDataSet.GoodsPriceRow goodsPriceRow = _goodsPriceDataTable.FindByRowNo(rowNo);
            this.SettingCalcMaster(goodsPriceRow);
        }

        /// <summary>
        /// 算出マスタ設定処理
        /// </summary>
        /// <param name="goodsPriceRow"></param>
        public void SettingCalcMaster(GoodsInputDataSet.GoodsPriceRow goodsPriceRow)
        {
            if (goodsPriceRow != null)
            {
                if (goodsPriceRow.PriceStartDate != DateTime.MinValue)
                {
                    if ((goodsPriceRow.SalesUnitCost == 0) && (goodsPriceRow.StockRate == 0))
                    {
                        if ((goodsPriceRow.CalcStockRate == 0) && (goodsPriceRow.CalcSalesUnitCost != 0))
                        {
                            goodsPriceRow.CalcMaster = "単品設定";
                        }
                        else if ((goodsPriceRow.CalcStockRate == 0) && (goodsPriceRow.CalcSalesUnitCost == 0))
                        {
                            goodsPriceRow.CalcMaster = string.Empty;
                        }
                        else
                        {
                            goodsPriceRow.CalcMaster = "掛率設定";
                        }
                    }
                    else
                    {
                        goodsPriceRow.CalcMaster = "商品";
                    }
                }
                else
                {
                    goodsPriceRow.CalcMaster = string.Empty;
                }
            }
        }

        /// <summary>
        /// 算出情報クリア処理
        /// </summary>
        /// <param name="rowNo">行番号</param>
        public void ClearCalcInfo(int rowNo)
        {
            GoodsInputDataSet.GoodsPriceRow goodsPriceRow = _goodsPriceDataTable.FindByRowNo(rowNo);
            this.ClearCalcInfo(goodsPriceRow);
        }

        /// <summary>
        /// 算出情報クリア処理
        /// </summary>
        /// <param name="goodsPriceRow">商品連結データ行オブジェクト</param>
        public void ClearCalcInfo(GoodsInputDataSet.GoodsPriceRow goodsPriceRow)
        {
            if (goodsPriceRow != null)
            {
                goodsPriceRow.CalcMaster = string.Empty;
                goodsPriceRow.CalcSalesUnitCost = 0;
                // 2009.04.02 30413 犬飼 計算仕入率と優先順位はクリアしない >>>>>>START
                //goodsPriceRow.CalcStockRate = 0;
                //goodsPriceRow.PriorityOrder = 0;
                // 2009.04.02 30413 犬飼 計算仕入率と優先順位はクリアしない <<<<<<END
            }
        }

        /// <summary>
        /// 入力情報クリア処理
        /// </summary>
        /// <param name="rowNo">行番号</param>
        public void ClearInputInfo(int rowNo)
        {
            GoodsInputDataSet.GoodsPriceRow goodsPriceRow = _goodsPriceDataTable.FindByRowNo(rowNo);
            this.ClearInputInfo(goodsPriceRow);
        }

        /// <summary>
        /// 入力情報クリア処理
        /// </summary>
        /// <param name="goodsPriceRow">商品連結データ行オブジェクト</param>
        public void ClearInputInfo(GoodsInputDataSet.GoodsPriceRow goodsPriceRow)
        {
            if (goodsPriceRow != null)
            {
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/03 ADD
                goodsPriceRow.ListPrice = 0;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/03 ADD
                goodsPriceRow.SalesUnitCost = 0;
                goodsPriceRow.StockRate = 0;

                // --- ADD 2009/02/03 障害ID:10848対応------------------------------------------------------>>>>>
                goodsPriceRow.CalcStockRate = 0;
                goodsPriceRow.CalcSalesUnitCost = 0;
                // --- ADD 2009/02/03 障害ID:10848対応------------------------------------------------------<<<<<
            }
        }

        /// <summary>
        /// 掛率を使用して単価を計算します。
        /// </summary>
        /// <param name="unitPriceKind">単価種類</param>
        /// <param name="fractionProcCode">端数処理コード</param>
        /// <param name="stdPrice">基準価格</param>
        /// <param name="rate">掛率</param>
        /// <param name="fracProcUnit">端数処理単位</param>
        /// <param name="fracProcCd">端数処理区分</param>
        /// <returns></returns>
        public double CalclateUnitPriceByRate(UnitPriceKind unitPriceKind, int fractionProcCode, double stdPrice, double rate, ref double fracProcUnit, ref int fracProcCd)
        {
            return this.CalclateUnitPriceByRateProc(unitPriceKind, fractionProcCode, stdPrice, rate, ref fracProcUnit, ref fracProcCd);
        }

        /// <summary>
        /// 掛率を使用して単価を計算します。
        /// </summary>
        /// <param name="unitPriceKind">単価種類</param>
        /// <param name="fractionProcCode">端数処理コード</param>
        /// <param name="stdPrice">基準価格</param>
        /// <param name="rate">掛率</param>
        /// <param name="fracProcUnit">端数処理単位</param>
        /// <param name="fracProcCd">端数処理区分</param>
        /// <returns></returns>
        private double CalclateUnitPriceByRateProc(UnitPriceKind unitPriceKind, int fractionProcCode, double stdPrice, double rate, ref double fracProcUnit, ref int fracProcCd)
        {
            if ((rate == 0) || (stdPrice == 0)) return 0;

            double unitPrice = (rate < 0) ? stdPrice * (100 + rate) * 0.01 : stdPrice * rate * 0.01;

            this.SettingFracProcInfo(unitPriceKind, fractionProcCode, unitPrice, ref fracProcUnit, ref fracProcCd);

            FractionCalculate.FracCalcMoney(unitPrice, fracProcUnit, fracProcCd, out unitPrice);

            return unitPrice;
        }

        /// <summary>
        /// 単価算出処理
        /// </summary>
        /// <param name="goodsUnitData"></param>
        /// <returns></returns>
        public void CalclateUnitPrice(GoodsUnitData goodsUnitData)
        {
            for (int i = 0; i < _goodsPriceDataTable.Count; i++)
            {
                this.CalclateUnitPrice(i + 1, goodsUnitData);
            }
        }

        /// <summary>
        /// 単価算出処理
        /// </summary>
        /// <param name="rowNo"></param>
        /// <param name="goodsUnitData"></param>
        /// <returns></returns>
        public void CalclateUnitPrice(int rowNo, GoodsUnitData goodsUnitData)
        {
            GoodsInputDataSet.GoodsPriceRow goodsPriceRow = _goodsPriceDataTable.FindByRowNo(rowNo);
            this.CalclateUnitPriceProc(goodsPriceRow, goodsUnitData);
        }

        /// <summary>
        /// 単価算出処理
        /// </summary>
        /// <param name="goodsPriceRow"></param>
        /// <param name="goodsUnitData"></param>
        public void CalclateUnitPrice(GoodsInputDataSet.GoodsPriceRow goodsPriceRow, GoodsUnitData goodsUnitData)
        {
            this.CalclateUnitPriceProc(goodsPriceRow, goodsUnitData);
        }

        /// <summary>
        /// 単価算出処理
        /// </summary>
        /// <param name="goodsPriceRow"></param>
        /// <param name="goodsUnitData"></param>
        private void CalclateUnitPriceProc(GoodsInputDataSet.GoodsPriceRow goodsPriceRow, GoodsUnitData goodsUnitData)
        {
            //----------------------------------------------------------------------------
            // 初期処理
            //----------------------------------------------------------------------------
            List<UnitPriceCalcRet> unitPriceCalcRetList = new List<UnitPriceCalcRet>();

            //----------------------------------------------------------------------------
            // 単価算出
            //----------------------------------------------------------------------------
            unitPriceCalcRetList = this.CalclateUnitPriceProc(goodsUnitData, goodsPriceRow);

            //----------------------------------------------------------------------------
            // 単価算出情報設定
            //----------------------------------------------------------------------------
            this.SettingCalclateUnitPriceInfo(unitPriceCalcRetList, ref goodsPriceRow);
        }
        
        /// <summary>
        /// 単価算出処理
        /// </summary>
        /// <param name="goodsUnitData"></param>
        /// <param name="goodsPriceRow"></param>
        /// <returns></returns>
        private List<UnitPriceCalcRet> CalclateUnitPriceProc(GoodsUnitData goodsUnitData, GoodsInputDataSet.GoodsPriceRow goodsPriceRow)
        {
            //----------------------------------------------------------------------------
            // 初期処理
            //----------------------------------------------------------------------------
            List<UnitPriceCalcRet> unitPriceCalcRetList = new List<UnitPriceCalcRet>();
            UnitPriceCalcParam unitPriceCalcParam = new UnitPriceCalcParam();

            if ((goodsUnitData.GoodsMakerCd != 0) && (!string.IsNullOrEmpty(goodsUnitData.GoodsNo)))
            {
                //----------------------------------------------------------------------------
                // パラメータ設定
                //----------------------------------------------------------------------------
                unitPriceCalcParam.BLGoodsCode = goodsUnitData.BLGoodsCode;                 // BLコード
                unitPriceCalcParam.BLGoodsName = goodsUnitData.BLGoodsName;                 // BLコード名称
                unitPriceCalcParam.BLGroupCode = goodsUnitData.BLGroupCode;                 // BLグループコード
                unitPriceCalcParam.CountFl = 0;                                             // 数量
                unitPriceCalcParam.CustomerCode = 0;                                        // 得意先コード
                unitPriceCalcParam.CustRateGrpCode = 0;                                     // 得意先掛率グループコード
                unitPriceCalcParam.GoodsMakerCd = goodsUnitData.GoodsMakerCd;               // メーカーコード
                unitPriceCalcParam.GoodsRateGrpCode = goodsUnitData.GoodsMGroup;            // 商品中分類コード
                unitPriceCalcParam.GoodsNo = goodsUnitData.GoodsNo;                         // 品番
                unitPriceCalcParam.GoodsRateRank = goodsUnitData.GoodsRateRank;             // 商品掛率ランク
                unitPriceCalcParam.PriceApplyDate = DateTime.Today;                         // 価格適用日
                unitPriceCalcParam.SalesUnPrcFrcProcCd = 0;                                 // 売上単価端数処理コード
                unitPriceCalcParam.SectionCode = goodsUnitData.SectionCode;                 // 拠点コード
                unitPriceCalcParam.StockUnPrcFrcProcCd = goodsUnitData.StockUnPrcFrcProcCd; // 仕入単価端数処理コード
                unitPriceCalcParam.SupplierCd = goodsUnitData.SupplierCd;                   // 仕入先コード
                unitPriceCalcParam.TaxationDivCd = goodsUnitData.TaxationDivCd;             // 課税区分

                unitPriceCalcParam.StockCnsTaxFrcProcCd = goodsUnitData.StockCnsTaxFrcProcCd;// 仕入消費税端数処理コード
                unitPriceCalcParam.SalesCnsTaxFrcProcCd = 0;                                // 売上消費税端数処理コード
                unitPriceCalcParam.TaxRate = this._taxRate;                                 // 税率
                unitPriceCalcParam.TotalAmountDispWayCd = 0;                                // 総額表示方法区分(0:総額表示しない)
                unitPriceCalcParam.TtlAmntDspRateDivCd = 0;                                 // 総額表示掛率適用区分(0：基準価格(税込)×掛率, 1:基準価格(税抜)×掛率) → 総額表示しない場合、参照しない

                //----------------------------------------------------------------------------
                // 単価算出
                //----------------------------------------------------------------------------
                this._unitPriceCalculation.CalculateUnitCost(unitPriceCalcParam, goodsUnitData, out unitPriceCalcRetList);
            }

            return unitPriceCalcRetList;

        }

        /// <summary>
        /// 単価算出情報設定
        /// </summary>
        /// <param name="unitPriceCalcRetList"></param>
        /// <param name="goodsPriceRow"></param>
        /// <remarks>
        /// <br>Update Note: 2012/12/06 田建委</br>
        /// <br>管理番号   : 2013/01/16配信分</br>
        /// <br>             Redmine#33663の#4 掛率単品原価【仕入単価】が設定された場合、掛率データ仕入単価の参照表示不正の対応</br>
        /// </remarks>
        private void SettingCalclateUnitPriceInfo(List<UnitPriceCalcRet> unitPriceCalcRetList, ref GoodsInputDataSet.GoodsPriceRow goodsPriceRow)
        {
            foreach (UnitPriceCalcRet unitPriceCalcRet in unitPriceCalcRetList)
            {
                // 原価設定時のみ展開
                if (unitPriceCalcRet.UnitPriceKind == UnitPriceCalculation.ctUnitPriceKind_UnitCost)
                {
                    //goodsPriceRow.RateUnitCost = unitPriceCalcRet.UnitPriceTaxIncFl; // 算出用原単価
                    //goodsPriceRow.RateStockRate = unitPriceCalcRet.RateVal; // 算出用原価率
                    if ((goodsPriceRow.SalesUnitCost == 0) && (goodsPriceRow.StockRate == 0))
                    {
                        // 2009.04.02 30413 犬飼 仕入単価の端数対応 >>>>>>START
                        // --- CHG 2009/03/17 障害ID:12473対応------------------------------------------------------>>>>>
                        //goodsPriceRow.CalcSalesUnitCost = unitPriceCalcRet.UnitPriceTaxIncFl;
                        //goodsPriceRow.CalcSalesUnitCost = unitPriceCalcRet.UnitPriceTaxExcFl;
                        // --- CHG 2009/03/17 障害ID:12473対応------------------------------------------------------<<<<<
                        // 2009.04.02 30413 犬飼 仕入単価の端数対応 <<<<<<END
                        goodsPriceRow.CalcStockRate = unitPriceCalcRet.RateVal;
                        //----- ADD 2012/12/06 田建委 Redmine#33663の#4 ---------->>>>>
                        // 掛率単品原価【仕入単価】が設定された場合、算出用原単価を仕入単価でセットする
                        if (unitPriceCalcRet.RateVal == 0)
                        {
                            goodsPriceRow.CalcSalesUnitCost = unitPriceCalcRet.UnitPriceTaxExcFl;
                        }
                        //----- ADD 2012/12/06 田建委 Redmine#33663の#4 ----------<<<<<
                    }
                    goodsPriceRow.PriorityOrder = unitPriceCalcRet.RatePriorityOrder; // 優先順位
                    this.SettingCalcMaster(goodsPriceRow);
                }
            }
        }

        #region マスタキャッシュ
        /// <summary>
        /// 仕入金額端数処理区分設定マスタキャッシュ
        /// </summary>
        /// <param name="stockProcMoneyList">仕入金額処理区分設定マスタリスト</param>
        public void CacheStockProcMoneyList(List<StockProcMoney> stockProcMoneyList)
        {
            _stockProcMoneyList = stockProcMoneyList;
            this.SettingStockProcMoneyTable();
        }

        /// <summary>
        /// 売上金額端数処理区分設定マスタキャッシュ
        /// </summary>
        /// <param name="salesProcMoneyList">売上金額処理区分設定マスタリスト</param>
        public void CacheSalesProcMoneyList(List<SalesProcMoney> salesProcMoneyList)
        {
            _salesProcMoneyList = salesProcMoneyList;
            this.SettingSalesProcMoneyTable();
        }
        #endregion

        #region 金額処理区マスタ関連
        /// <summary>
        /// 単価種類、金額に従って端数処理単位、端数処理区分を設定します。
        /// </summary>
        /// <param name="unitPriceKind">単価種類</param>
        /// <param name="fractionProcCode">端数処理コード</param>
        /// <param name="price">対象金額</param>
        /// <param name="fractionProcUnit">端数処理単位</param>
        /// <param name="fractionProcCd">端数処理区分</param>
        private void SettingFracProcInfo(UnitPriceKind unitPriceKind, int fractionProcCode, double price, ref double fractionProcUnit, ref int fractionProcCd)
        {
            if (fractionProcUnit == 0)
            {
                switch (unitPriceKind)
                {
                    // 仕入単価
                    case UnitPriceKind.UnitCost:
                        {
                            this.GetStockFractionProcInfo(ctFracProcMoneyDiv_UnitPrice, fractionProcCode, price, out fractionProcUnit, out fractionProcCd);
                            break;
                        }
                    // 定価、売上単価
                    case UnitPriceKind.ListPrice:
                    case UnitPriceKind.SalesUnitPrice:
                        {
                            this.GetSalesFractionProcInfo(ctFracProcMoneyDiv_UnitPrice, fractionProcCode, price, out fractionProcUnit, out fractionProcCd);
                            break;
                        }
                }
            }
        }

        /// <summary>
        /// 売上金額処理区分設定マスタリストをデータテーブルにセットします。
        /// </summary>
        private void SettingSalesProcMoneyTable()
        {
            if (_salesProcMoneyList == null) return;

            // データテーブル生成
            CreateSalesProcMoneyTable(out _salesProcMoneyDataTable, _salesProcMoneyList);

            _salesProcMoneyDataTableView = new DataView(_salesProcMoneyDataTable);
            _salesProcMoneyDataTableView.Sort = string.Format("{0},{1}", _salesProcMoneyDataTable.FracProcMoneyDivColumn, _salesProcMoneyDataTable.FractionProcCodeColumn, _salesProcMoneyDataTable.UpperLimitPriceColumn);
        }

        /// <summary>
        /// 売上金額処理区分設定マスタより、対象金額に該当する端数処理単位、端数処理コードを取得します。
        /// </summary>
        /// <param name="fracProcMoneyDiv">端数処理対象金額区分</param>
        /// <param name="fractionProcCode">端数処理コード</param>
        /// <param name="price">対象金額</param>
        /// <param name="fractionProcUnit">端数処理単位</param>
        /// <param name="fractionProcCd">端数処理区分</param>
        private void GetSalesFractionProcInfo(int fracProcMoneyDiv, int fractionProcCode, double price, out double fractionProcUnit, out int fractionProcCd)
        {
            fractionProcUnit = GetDefaultFractionProcUnit(fracProcMoneyDiv);
            fractionProcCd = GetDefaultFractionProcCd(fracProcMoneyDiv);

            if (_salesProcMoneyDataTableView == null) return;

            string defaultSort = _salesProcMoneyDataTableView.Sort;
            string defaultRowFilter = _salesProcMoneyDataTableView.RowFilter;
            try
            {
                _salesProcMoneyDataTableView.RowFilter = string.Format("{0}={1} AND {2}={3} AND {4}>={5}", _salesProcMoneyDataTable.FracProcMoneyDivColumn, fracProcMoneyDiv, _salesProcMoneyDataTable.FractionProcCodeColumn.ColumnName, fractionProcCode, _salesProcMoneyDataTable.UpperLimitPriceColumn.ColumnName, price);

                if (_salesProcMoneyDataTableView.Count > 0)
                {
                    fractionProcUnit = (double)_salesProcMoneyDataTableView[0][_salesProcMoneyDataTable.FractionProcUnitColumn.ColumnName];
                    fractionProcCd = (int)_salesProcMoneyDataTableView[0][_salesProcMoneyDataTable.FractionProcCdColumn.ColumnName];
                }
            }
            finally
            {
                _salesProcMoneyDataTableView.Sort = defaultSort;
                _salesProcMoneyDataTableView.RowFilter = defaultRowFilter;
            }
        }

        /// <summary>
        /// 仕入金額処理区分設定マスタを検索します。
        /// </summary>
        private void SettingStockProcMoneyTable()
        {
            if (_stockProcMoneyList == null) return;

            // データテーブル生成
            CreateStockProcMoneyTable(out _stockProcMoneyDataTable, _stockProcMoneyList);

            _stockProcMoneyDataTableView = new DataView(_stockProcMoneyDataTable);
            _stockProcMoneyDataTableView.Sort = string.Format("{0},{1}", _stockProcMoneyDataTable.FracProcMoneyDivColumn.ColumnName, _stockProcMoneyDataTable.FractionProcCodeColumn.ColumnName, _stockProcMoneyDataTable.UpperLimitPriceColumn.ColumnName);
        }

        /// <summary>
        /// 仕入金額処理区分設定マスタより、対象金額に該当する端数処理単位、端数処理コードを取得します。
        /// </summary>
        /// <param name="fracProcMoneyDiv">端数処理対象金額区分</param>
        /// <param name="fractionProcCode">端数処理コード</param>
        /// <param name="price">対象金額</param>
        /// <param name="fractionProcUnit">端数処理単位</param>
        /// <param name="fractionProcCd">端数処理区分</param>
        private void GetStockFractionProcInfo(int fracProcMoneyDiv, int fractionProcCode, double price, out double fractionProcUnit, out int fractionProcCd)
        {
            fractionProcUnit = GetDefaultFractionProcUnit(fracProcMoneyDiv);
            fractionProcCd = GetDefaultFractionProcCd(fracProcMoneyDiv);

            if (_stockProcMoneyDataTableView == null) return;

            string defaultSort = _stockProcMoneyDataTableView.Sort;
            string defaultRowFilter = _stockProcMoneyDataTableView.RowFilter;
            try
            {
                _stockProcMoneyDataTableView.RowFilter = string.Format("{0}={1} AND {2}={3} AND {4}>={5}", _stockProcMoneyDataTable.FracProcMoneyDivColumn, fracProcMoneyDiv, _stockProcMoneyDataTable.FractionProcCodeColumn.ColumnName, fractionProcCode, _stockProcMoneyDataTable.UpperLimitPriceColumn.ColumnName, price);

                if (_stockProcMoneyDataTableView.Count > 0)
                {
                    fractionProcUnit = (double)_stockProcMoneyDataTableView[0][_stockProcMoneyDataTable.FractionProcUnitColumn.ColumnName];
                    fractionProcCd = (int)_stockProcMoneyDataTableView[0][_stockProcMoneyDataTable.FractionProcCdColumn.ColumnName];
                }
            }
            finally
            {
                _stockProcMoneyDataTableView.Sort = defaultSort;
                _stockProcMoneyDataTableView.RowFilter = defaultRowFilter;
            }
        }
        #endregion

        #region ■Public Static Methods
        /// <summary>
        /// 売上金額処理設定区分リストより、金額処理区分テーブルを生成します。
        /// </summary>
        /// <param name="procMoneyDataTable"></param>
        /// <param name="salesProcMoneyList"></param>
        public static void CreateSalesProcMoneyTable(out GoodsInputDataSet.ProcMoneyDataTable procMoneyDataTable, List<SalesProcMoney> salesProcMoneyList)
        {
            procMoneyDataTable = new GoodsInputDataSet.ProcMoneyDataTable();
            try
            {
                procMoneyDataTable.BeginLoadData();

                foreach (SalesProcMoney salesProcMoney in salesProcMoneyList)
                {
                    GoodsInputDataSet.ProcMoneyRow row = procMoneyDataTable.NewProcMoneyRow();

                    row[procMoneyDataTable.FracProcMoneyDivColumn.ColumnName] = salesProcMoney.FracProcMoneyDiv;
                    row[procMoneyDataTable.FractionProcCodeColumn.ColumnName] = salesProcMoney.FractionProcCode;
                    row[procMoneyDataTable.UpperLimitPriceColumn.ColumnName] = salesProcMoney.UpperLimitPrice;
                    row[procMoneyDataTable.FractionProcUnitColumn.ColumnName] = salesProcMoney.FractionProcUnit;
                    row[procMoneyDataTable.FractionProcCdColumn.ColumnName] = salesProcMoney.FractionProcCd;

                    procMoneyDataTable.AddProcMoneyRow(row);
                }
            }
            finally
            {
                procMoneyDataTable.EndLoadData();
            }
        }

        /// <summary>
        /// 仕入金額処理設定区分リストより、金額処理区分テーブルを生成します。
        /// </summary>
        /// <param name="procMoneyDataTable"></param>
        /// <param name="stockProcMoneyList"></param>
        public static void CreateStockProcMoneyTable(out GoodsInputDataSet.ProcMoneyDataTable procMoneyDataTable, List<StockProcMoney> stockProcMoneyList)
        {
            procMoneyDataTable = new GoodsInputDataSet.ProcMoneyDataTable();

            try
            {
                procMoneyDataTable.BeginLoadData();

                foreach (StockProcMoney stockProcMoney in stockProcMoneyList)
                {
                    GoodsInputDataSet.ProcMoneyRow row = procMoneyDataTable.NewProcMoneyRow();

                    if (stockProcMoney.LogicalDeleteCode == 0)
                    {
                        row[procMoneyDataTable.FracProcMoneyDivColumn.ColumnName] = stockProcMoney.FracProcMoneyDiv;
                        row[procMoneyDataTable.FractionProcCodeColumn.ColumnName] = stockProcMoney.FractionProcCode;
                        row[procMoneyDataTable.UpperLimitPriceColumn.ColumnName] = stockProcMoney.UpperLimitPrice;
                        row[procMoneyDataTable.FractionProcUnitColumn.ColumnName] = stockProcMoney.FractionProcUnit;
                        row[procMoneyDataTable.FractionProcCdColumn.ColumnName] = stockProcMoney.FractionProcCd;
                    }

                    procMoneyDataTable.AddProcMoneyRow(row);
                }
            }
            finally
            {
                procMoneyDataTable.EndLoadData();
            }
        }

        /// <summary>
        /// 端数処理対象金額設定区分に従った端数処理単位のデフォルト値を取得します。
        /// </summary>
        /// <param name="fracProcMoneyDiv">端数処理対象金額区分</param>
        /// <returns>端数処理単位</returns>
        public static double GetDefaultFractionProcUnit(int fracProcMoneyDiv)
        {
            switch (fracProcMoneyDiv)
            {
                // 金額、原価、消費税は1円単位
                case ctFracProcMoneyDiv_Price:
                //case ctFracProcMoneyDiv_CostPrice: // 2009.01.21
                case ctFracProcMoneyDiv_Tax:
                    {
                        return 1;
                    }
                default:
                    {
                        return 0.01;
                    }
            }
        }

        /// <summary>
        /// 端数処理区分初期値取得
        /// </summary>
        /// <param name="fracProcMoneyDiv">端数処理対象金額区分</param>
        /// <returns>端数処理区分</returns>
        public static int GetDefaultFractionProcCd(int fracProcMoneyDiv)
        {
            // 1:切捨て
            return 1;
        }
        #endregion

        #region 価格情報取得
        /// <summary>
        /// 価格情報取得
        /// </summary>
        /// <param name="goodsMakerCd"></param>
        /// <param name="goodsNo"></param>
        /// <param name="goodsPriceList"></param>
        /// <returns></returns>
        public int GetGoodsPriceU(int goodsMakerCd, string goodsNo, out List<GoodsPrice> goodsPriceList)
        {
             IGoodsPriceUDB iGoodsPriceUDB = null;
            iGoodsPriceUDB = (IGoodsPriceUDB)MediationGoodsPriceUDB.GetGoodsPriceUDB();

            object objGoodsPriceUWorkArrayList = null;
            GoodsPriceUWork paraGoodsPriceUWork = new GoodsPriceUWork();
            paraGoodsPriceUWork.EnterpriseCode = this._enterpriseCode;
            paraGoodsPriceUWork.GoodsMakerCd = goodsMakerCd;
            paraGoodsPriceUWork.GoodsNo = goodsNo;

            int st = iGoodsPriceUDB.Search(out objGoodsPriceUWorkArrayList, paraGoodsPriceUWork, 0, ConstantManagement.LogicalMode.GetData0);

            this.GetGoodsPriceListFromGoodsPriceUWorkList(objGoodsPriceUWorkArrayList as ArrayList, out goodsPriceList);

            return st;
        }
        #endregion
    }
}

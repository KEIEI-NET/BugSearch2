//****************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : 在庫仕入入力
// プログラム概要   : 在庫仕入入力アクセスクラスです。
//----------------------------------------------------------------------------//
//                (c)Copyright  2007 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 19077 渡邉貴裕
// 作 成 日  2007/03/26  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 980035 金沢 貞義
// 修 正 日  2007/10/11  修正内容 : DC.NS対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 980035 金沢 貞義
// 修 正 日  2008/03/28  修正内容 : 不具合対応（DC.NS対応）
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30414 忍 幸史
// 修 正 日  2008/07/24  修正内容 : Partsman用に変更
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田 貴志
// 修 正 日  2009/06/03  修正内容 : 不具合対応[13427]
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 工藤 恵優
// 修 正 日  2009/11/16  修正内容 : 在庫登録機能の追加
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 朱俊成
// 修 正 日  2009/12/16  修正内容 : PM.NS-5
//　　　　　　　　　　　　　　　　　標準価格、原単価、仕入数、仕入後数の
//                                  ディフォルトの改修
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 曹文傑
// 修 正 日  2010/12/20  修正内容 : 障害改良対応x月
//　　　　　　　　　　　　　　　　　あいまい検索で非在庫品を選択した場合に、品番が表示が不正になる不具合の修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 陳建明
// 修 正 日  2011/12/13  修正内容 : redmine#26816 修正呼び出し時には同一品番選択ウィンドウは表示しない
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 陳建明
// 修 正 日  2011/12/16  修正内容 : redmine#26816 修正呼び出し時には同一品番選択ウィンドウは表示しない
//----------------------------------------------------------------------------//
// 管理番号  10806793-00 作成担当 : zhangy3
// 修 正 日  2013/01/04  修正内容 : 2013/03/13配信分 redmine#33845 在庫品仕入入力
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 鈴木創
// 修 正 日  2021/10/12  修正内容 : PJMIT-1477 PM.NS 在庫仕入入力画面にて品番を変更しても登録できてしまう
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;

using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.UIData;
using Broadleaf.Library;
using Broadleaf.Library.Collections;
using Broadleaf.Library.Resources;

namespace Broadleaf.Application.Controller
{
	/// <summary>
	/// 在庫調整アクセスクラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : 在庫調整アクセスクラスです。</br>
	/// <br>Programmer : 19077 渡邉貴裕</br>
	/// <br>Date       : 2007.03.26</br>
    /// <br>Update Note: 2007.10.11 980035 金沢 貞義</br>
    /// <br>			 ・DC.NS対応</br>
    /// <br>Update Note: 2008.03.28 980035 金沢 貞義</br>
    /// <br>			 ・不具合対応（DC.NS対応）</br>
    /// <br>Update Note: 2008/07/24 30414 忍 幸史</br>
    /// <br>             ・Partsman用に変更</br>
    /// <br>Update Note: 2009/06/03       照田 貴志</br>
    /// <br>             ・不具合対応[13427]</br>
    /// <br>Update Note: 2009/11/16       工藤 恵優</br>
    /// <br>             ・在庫登録機能の追加</br>
    /// <br>Update Note: 2010/12/20 曹文傑</br>
    /// <br>               障害改良対応x月</br>
    /// <br>               あいまい検索で非在庫品を選択した場合に、品番が表示が不正になる不具合の修正。</br>
    /// <br>Update Note: 2011/12/13 陳建明</br>
    /// <br>               redmine#26816 修正呼び出し時には同一品番選択ウィンドウは表示しない</br>
    /// <br>Update Note: 2013/01/04 zhangy3</br>
    /// <br>管理番号   : 10806793-00　2013/03/13配信分</br>　
    /// <br>           : Redmine#33845 在庫品仕入入力</br>
    /// </remarks>
	public partial class AdjustStockAcs
	{
		#region デリゲート設定
        // --- CHG 2008/07/24 --------------------------------------------------------------------->>>>>
        //// デリゲートイベント
        //public static event GetStockSectionCodeEventHandler GetStockSectionCode; //拠点
        //public static event GetDateEventHandler GetDate;       //日付
        //public static event GetStockPointWayEventHandler GetStockPointWay; //在庫評価方法
        //public static event GetEditModeEventHandler GetEditMode; //編集モード
        //public static event GetFractionProcCdEventHandler GetFractionProcCd; //端数処理区分
        //public static event GetInputAgentEventHandler GetInputAgent;
        //public static event GetSubttlPriceEventHandler GetSubttlPrice;
        //public static event GetBlGoodsNameEventHandler GetBlGoodsName;
        
        ////デリゲート処理
        //public delegate Employee GetInputAgentEventHandler();
        //public delegate string GetStockSectionCodeEventHandler();
        //public delegate DateTime GetDateEventHandler();
        //public delegate int GetStockPointWayEventHandler();
        //public delegate int GetEditModeEventHandler();
        //public delegate int GetFractionProcCdEventHandler();
        //public delegate Int64 GetSubttlPriceEventHandler();
        //public delegate string GetBlGoodsNameEventHandler(int blGoodsCode);

        // デリゲートイベント
        public static event GetStockSectionCodeEventHandler GetStockSectionCode;    // 仕入拠点コード取得
        public static event GetDateEventHandler GetDate;                            // 作成日取得
        public static event GetInputAgentCodeEventHandler GetInputAgentCode;        // 担当者コード取得
        public static event GetSubttlPriceEventHandler GetSubttlPrice;              // 仕入金額計取得
        public static event GetSlipNoteEventHandler GetSlipNote;                    // 伝票備考取得

        //デリゲート処理
        public delegate string GetInputAgentCodeEventHandler();
        public delegate string GetStockSectionCodeEventHandler();
        public delegate DateTime GetDateEventHandler();
        public delegate Int64 GetSubttlPriceEventHandler();
        public delegate string GetSlipNoteEventHandler();
        // --- CHG 2008/07/24 ---------------------------------------------------------------------<<<<<

        #endregion

        #region パブリック

        #region 2008.02.15 削除
        // 2008.02.15 削除 >>>>>>>>>>>>>>>>>>>>
        //public void StockToList(List<Stock> souceList)
        //{
        //    StockToDataList(souceList);
        //}
        // 2008.02.15 削除 <<<<<<<<<<<<<<<<<<<<
        #endregion 2008.02.15 削除

        #region DEL 2008/07/24 使用していないのでコメントアウト
        /* --- DEL 2008/07/24 --------------------------------------------------------------------->>>>>
        // 2007.10.11 修正 >>>>>>>>>>>>>>>>>>>>
        //public void StockToListGrs(List<StockEachWarehouse> souceList)
        public void StockToListGrs(List<StockExpansion> souceList)
        // 2007.10.11 修正 <<<<<<<<<<<<<<<<<<<<
        {
            StockTodataListGrs(souceList);
        }
        
        /// <summary>
        /// 在庫状態クリア
        /// </summary>
        public void StockDataClear()
        {
            _stockList.Clear();
        }
           --- DEL 2008/07/24 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/07/24 使用していないのでコメントアウト

        /// <summary>
        /// 行クリア
        /// </summary>
        public void ClrRowData(int targetRow)
        {
            ClrGridRow(targetRow);
        }

        // 2008.01.17 追加 >>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// 行削除
        /// </summary>
        public void DelRowData(int targetRow)
        {
            DelGridRow(targetRow);
        }
        // 2008.01.17 追加 <<<<<<<<<<<<<<<<<<<<
        #endregion

        #region プライベート

        /// <summary>
        /// 行クリア
        /// </summary>
        private void ClrGridRow(int targetRow)
        {
            for (int i = 0; i < _mainProductStock.Columns.Count; i++)
            {
                _mainProductStock.Rows[targetRow][i] = DBNull.Value;
            }
            _mainProductStock.Rows[targetRow][ctCOL_RowNum] = targetRow + 1;
        }

        // 2008.01.17 追加 >>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// 行削除
        /// </summary>
        private void DelGridRow(int targetRow)
        {
            string msg;

            // 行削除処理
            ClrGridRow(targetRow);
            _mainProductStock.Rows[targetRow].Delete();

            // 行番号再設定
            for (int i = targetRow; i < _mainProductStock.Rows.Count; i++)
            {
                _mainProductStock.Rows[i][ctCOL_RowNum] = i + 1;
            }

            // 空行追加
            CreateDummySlipDtl(out msg);
        }
        // 2008.01.17 追加 <<<<<<<<<<<<<<<<<<<<

        #region 2008.03.28 削除
        // 2008.03.28 削除 >>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// 重複存在チェック
        /// </summary>
        //private static bool ChkExistStock(Stock chkTgt)
        //{
        //    bool result = false;

        //    if (_stockList == null)
        //    {
        //        return false;
        //    }

        //    ChkStock chkStock = new ChkStock();

        //    chkStock.EnterPriseCode = chkTgt.EnterpriseCode;
        //    chkStock.SectionCode = chkTgt.SectionCode;
        //    // 2007.10.11 修正 >>>>>>>>>>>>>>>>>>>>
        //    //chkStock.MakerCode = chkTgt.MakerCode;
        //    //chkStock.GoodsCode = chkTgt.GoodsCode;
        //    chkStock.GoodsMakerCd = chkTgt.GoodsMakerCd;
        //    chkStock.GoodsNo = chkTgt.GoodsNo;
        //    // 2007.10.11 修正 <<<<<<<<<<<<<<<<<<<<

        //    // 2007.10.11 修正 >>>>>>>>>>>>>>>>>>>>
        //    //foreach (StockEachWarehouse chkStockTgt in _stockList)
        //    foreach (StockExpansion chkStockTgt in _stockList)
        //    // 2007.10.11 修正 <<<<<<<<<<<<<<<<<<<<
        //    {
        //        if ((chkStockTgt.EnterpriseCode == chkStock.EnterPriseCode)
        //            && (chkStockTgt.SectionCode == chkStock.SectionCode)
        //            // 2007.10.11 修正 >>>>>>>>>>>>>>>>>>>>
        //            //&& (chkStockTgt.MakerCode == chkStock.MakerCode)
        //            //&& (chkStockTgt.GoodsCode == chkStock.GoodsCode))
        //            && (chkStockTgt.GoodsMakerCd == chkStock.GoodsMakerCd)
        //            && (chkStockTgt.GoodsNo == chkStock.GoodsNo))
        //            // 2007.10.11 修正 <<<<<<<<<<<<<<<<<<<<
        //        {
        //            result = true;
        //        }
        //    }
        //    return result;
        //}
        // 2008.03.28 削除 <<<<<<<<<<<<<<<<<<<<
        #endregion

        #region DEL 2008/07/24 使用していないのでコメントアウト
        /* --- DEL 2008/07/24 --------------------------------------------------------------------->>>>>
        // 2007.10.11 修正 >>>>>>>>>>>>>>>>>>>>
        //private static bool ChkExistStockGrs(StockEachWarehouse chkTgt)
        private static bool ChkExistStockGrs(StockExpansion chkTgt)
        // 2007.10.11 修正 <<<<<<<<<<<<<<<<<<<<
        {
            bool result = false;
            if (_stockList == null)
            {
                return false;
            }
            ChkStock chkStock = new ChkStock();

            chkStock.EnterPriseCode = chkTgt.EnterpriseCode;
            chkStock.SectionCode = chkTgt.SectionCode;
            // 2007.10.11 修正 >>>>>>>>>>>>>>>>>>>>
            //chkStock.MakerCode = chkTgt.MakerCode;
            //chkStock.GoodsCode = chkTgt.GoodsCode;
            chkStock.GoodsMakerCd = chkTgt.GoodsMakerCd;
            chkStock.GoodsNo = chkTgt.GoodsNo;
            // 2007.10.11 修正 <<<<<<<<<<<<<<<<<<<<
            // 2008.03.28 追加 >>>>>>>>>>>>>>>>>>>>
            chkStock.WarehouseCode = chkStock.WarehouseCode;
            // 2008.03.28 追加 <<<<<<<<<<<<<<<<<<<<

            // 2007.10.11 修正 >>>>>>>>>>>>>>>>>>>>
            //foreach (StockEachWarehouse chkStockTgt in _stockList)
            foreach (StockExpansion chkStockTgt in _stockList)
            // 2007.10.11 修正 <<<<<<<<<<<<<<<<<<<<
            {
                // 2008.03.28 修正 >>>>>>>>>>>>>>>>>>>>
                //if ((chkStockTgt.EnterpriseCode == chkStock.EnterPriseCode)
                //    && (chkStockTgt.SectionCode == chkStock.SectionCode)
                //    // 2007.10.11 修正 >>>>>>>>>>>>>>>>>>>>
                //    //&& (chkStockTgt.MakerCode == chkStock.MakerCode)
                //    //&& (chkStockTgt.GoodsCode == chkStock.GoodsCode))
                //    && (chkStockTgt.GoodsMakerCd == chkStock.GoodsMakerCd)
                //    && (chkStockTgt.GoodsNo == chkStock.GoodsNo))
                //    // 2007.10.11 修正 <<<<<<<<<<<<<<<<<<<<
                if ((chkStockTgt.EnterpriseCode   == chkStock.EnterPriseCode)
                    && (chkStockTgt.SectionCode   == chkStock.SectionCode)
                    && (chkStockTgt.GoodsMakerCd  == chkStock.GoodsMakerCd)
                    && (chkStockTgt.GoodsNo       == chkStock.GoodsNo)
                    && (chkStockTgt.WarehouseCode == chkStock.GoodsNo))
                // 2008.03.28 修正 <<<<<<<<<<<<<<<<<<<<
                {
                    return true;
                }
            }
            return result;
        }
           --- DEL 2008/07/24 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/07/24 使用していないのでコメントアウト

        #region 2008.02.15 削除
        // 2008.02.15 削除 >>>>>>>>>>>>>>>>>>>>
        //private static void StockToDataList(List<Stock> souceList)
        //{
        //    // 2007.10.11 修正 >>>>>>>>>>>>>>>>>>>>
        //    //StockEachWarehouse stockEachWarehouse = new StockEachWarehouse();
        //    ////重複存在チェック
        //    //foreach (Stock stockRet in souceList)
        //    //{
        //    //    if (ChkExistStock(stockRet) != true)
        //    //    {
        //    //        stockEachWarehouse = StockToEachStock(stockRet);
        //    //        _stockList.Add(stockEachWarehouse);
        //    //    }
        //    //}
        //    StockExpansion stockExpansion = new StockExpansion();
        //    //重複存在チェック
        //    foreach (Stock stockRet in souceList)
        //    {
        //        if (ChkExistStock(stockRet) != true)
        //        {
        //            stockExpansion = StockToEachStock(stockRet);
        //            _stockList.Add(stockExpansion);
        //        }
        //    }
        //    // 2007.10.11 修正 <<<<<<<<<<<<<<<<<<<<
        //}
        // 2008.02.15 削除 <<<<<<<<<<<<<<<<<<<<
        #endregion 2008.02.15 削除

        #region DEL 2008/07/24 Partsman用に変更
        /* --- DEL 2008/07/24 --------------------------------------------------------------------->>>>>
        // 2007.10.11 修正 >>>>>>>>>>>>>>>>>>>>
        //private static void StockTodataListGrs(List<StockEachWarehouse> souceList)
        //{
        //    foreach (StockEachWarehouse stockEachWarehouseRet in souceList)
        //    {
        //        if (ChkExistStockGrs(stockEachWarehouseRet) != true)
        //        {
        //            _stockList.Add(stockEachWarehouseRet);
        //        }
        //    }
        //}
        //private static StockEachWarehouse StockToEachStock(Stock stock)
        //{
        //    StockEachWarehouse stockEachWarehouse = new StockEachWarehouse();
        //    stockEachWarehouse.AcpOdrCount = stock.AcpOdrCount;
        //    stockEachWarehouse.AllowStockCnt = stock.AllowStockCnt;
        //    stockEachWarehouse.CarrierCode = stock.CarrierCode;
        //    stockEachWarehouse.CarrierName = stock.CarrierName;
        //    stockEachWarehouse.CellphoneModelCode = stock.CellphoneModelCode;
        //    stockEachWarehouse.CellphoneModelName = stock.CellphoneModelName;
        //    stockEachWarehouse.CreateDateTime = stock.CreateDateTime;
        //    stockEachWarehouse.CreateDateTimeAdFormal = stock.CreateDateTimeAdFormal;
        //    stockEachWarehouse.CreateDateTimeAdInFormal = stock.CreateDateTimeAdInFormal;
        //    stockEachWarehouse.CreateDateTimeJpFormal = stock.CreateDateTimeJpFormal;
        //    stockEachWarehouse.CreateDateTimeJpInFormal = stock.CreateDateTimeJpInFormal;
        //    stockEachWarehouse.EnterpriseCode = stock.EnterpriseCode;
        //    stockEachWarehouse.EnterpriseName = stock.EnterpriseName;
        //    stockEachWarehouse.EntrustCnt = stock.EntrustCnt;
        //    stockEachWarehouse.FileHeaderGuid = stock.FileHeaderGuid;
        //    stockEachWarehouse.GoodsCode = stock.GoodsCode;
        //    stockEachWarehouse.GoodsName = stock.GoodsName;
        //    stockEachWarehouse.LargeGoodsGanreCode = stock.LargeGoodsGanreCode;
        //    stockEachWarehouse.LargeGoodsGanreName = stock.LargeGoodsGanreName;
        //    stockEachWarehouse.LastInventoryUpdate = stock.LastInventoryUpdate;
        //    stockEachWarehouse.LastInventoryUpdateAdFormal = stock.LastInventoryUpdateAdFormal;
        //    stockEachWarehouse.LastInventoryUpdateAdInFormal = stock.LastInventoryUpdateAdInFormal;
        //    stockEachWarehouse.LastInventoryUpdateJpFormal = stock.LastInventoryUpdateJpFormal;
        //    stockEachWarehouse.LastInventoryUpdateJpInFormal = stock.LastInventoryUpdateJpInFormal;
        //    stockEachWarehouse.LastSalesDate = stock.LastSalesDate;
        //    stockEachWarehouse.LastSalesDateAdFormal = stock.LastSalesDateAdFormal;
        //    stockEachWarehouse.LastSalesDateAdInFormal = stock.LastSalesDateAdInFormal;
        //    stockEachWarehouse.LastSalesDateJpFormal = stock.LastSalesDateJpFormal;
        //    stockEachWarehouse.LastSalesDateJpInFormal = stock.LastSalesDateJpInFormal;
        //    stockEachWarehouse.LastStockDate = stock.LastStockDate;
        //    stockEachWarehouse.LastStockDateAdFormal = stock.LastStockDateAdFormal;
        //    stockEachWarehouse.LastStockDateAdInFormal = stock.LastStockDateAdInFormal;
        //    stockEachWarehouse.LastStockDateJpFormal = stock.LastStockDateJpFormal;
        //    stockEachWarehouse.LastStockDateJpInFormal = stock.LastStockDateJpInFormal;
        //    stockEachWarehouse.LogicalDeleteCode = stock.LogicalDeleteCode;
        //    stockEachWarehouse.MakerCode = stock.MakerCode;
        //    stockEachWarehouse.MakerName = stock.MakerName;
        //    stockEachWarehouse.MaximumStockCnt = stock.MaximumStockCnt;
        //    stockEachWarehouse.MediumGoodsGanreCode = stock.MediumGoodsGanreCode;
        //    stockEachWarehouse.MediumGoodsGanreName = stock.MediumGoodsGanreName;
        //    stockEachWarehouse.MinimumStockCnt = stock.MinimumStockCnt;
        //    stockEachWarehouse.MovingSupliStock = stock.MovingSupliStock;
        //    stockEachWarehouse.MovingTrustStock = stock.MovingTrustStock;
        //    stockEachWarehouse.NmlSalOdrCount = stock.NmlSalOdrCount;
        //    stockEachWarehouse.PrdNumMngDiv = stock.PrdNumMngDiv;
        //    stockEachWarehouse.ReservedCount = stock.ReservedCount;
        //    stockEachWarehouse.SalesOrderCount = stock.SalesOrderCount;
        //    stockEachWarehouse.SalOdrLot = stock.SalOdrLot;
        //    stockEachWarehouse.SectionCode = stock.SectionCode;
        //    stockEachWarehouse.ShipmentPosCnt = stock.ShipmentPosCnt;
        //    stockEachWarehouse.SoldCnt = stock.SoldCnt;
        //    stockEachWarehouse.StockTotalPrice = stock.StockTotalPrice;
        //    stockEachWarehouse.StockUnitPrice = stock.StockUnitPrice;
        //    stockEachWarehouse.SupplierStock = stock.SupplierStock;
        //    stockEachWarehouse.SystematicColorCd = stock.SystematicColorCd;
        //    stockEachWarehouse.SystematicColorNm = stock.SystematicColorNm;
        //    stockEachWarehouse.TrustCount = stock.TrustCount;
        //    stockEachWarehouse.TrustEntrustCnt = stock.TrustEntrustCnt;
        //    stockEachWarehouse.UpdAssemblyId1 = stock.UpdAssemblyId1;
        //    stockEachWarehouse.UpdAssemblyId2 = stock.UpdAssemblyId2;
        //    stockEachWarehouse.UpdateDateTime = stock.UpdateDateTime;
        //    stockEachWarehouse.UpdateDateTimeAdFormal = stock.UpdateDateTimeAdFormal;
        //    stockEachWarehouse.UpdateDateTimeAdInFormal = stock.UpdateDateTimeAdInFormal;
        //    stockEachWarehouse.UpdateDateTimeJpFormal = stock.UpdateDateTimeJpFormal;
        //    stockEachWarehouse.UpdateDateTimeJpInFormal = stock.UpdateDateTimeJpInFormal;
        //    stockEachWarehouse.UpdEmployeeCode = stock.UpdEmployeeCode;
        //    stockEachWarehouse.UpdEmployeeName = stock.UpdEmployeeName;
        //    stockEachWarehouse.WarehouseCode = "";
        //    stockEachWarehouse.WarehouseName = "";
        //
        //    return stockEachWarehouse;
        //}
        private static void StockTodataListGrs(List<StockExpansion> souceList)
        {
            foreach (StockExpansion stockExpansionRet in souceList)
            {
                if (ChkExistStockGrs(stockExpansionRet) != true)
                {
                    _stockList.Add(stockExpansionRet);
                }
            }
        }
        private static StockExpansion StockToEachStock(Stock stock)
        {
            StockExpansion stockExpansion = new StockExpansion();
            stockExpansion.AcpOdrCount = stock.AcpOdrCount;
            stockExpansion.CreateDateTime = stock.CreateDateTime;
            stockExpansion.CreateDateTimeAdFormal = stock.CreateDateTimeAdFormal;
            stockExpansion.CreateDateTimeAdInFormal = stock.CreateDateTimeAdInFormal;
            stockExpansion.CreateDateTimeJpFormal = stock.CreateDateTimeJpFormal;
            stockExpansion.CreateDateTimeJpInFormal = stock.CreateDateTimeJpInFormal;
            stockExpansion.EnterpriseCode = stock.EnterpriseCode;
            stockExpansion.EnterpriseName = stock.EnterpriseName;
            stockExpansion.EntrustCnt = stock.EntrustCnt;
            stockExpansion.FileHeaderGuid = stock.FileHeaderGuid;
            stockExpansion.GoodsNo = stock.GoodsNo;
            stockExpansion.GoodsName = stock.GoodsName;
            stockExpansion.LastInventoryUpdate = stock.LastInventoryUpdate;
            stockExpansion.LastInventoryUpdateAdFormal = stock.LastInventoryUpdateAdFormal;
            stockExpansion.LastInventoryUpdateAdInFormal = stock.LastInventoryUpdateAdInFormal;
            stockExpansion.LastInventoryUpdateJpFormal = stock.LastInventoryUpdateJpFormal;
            stockExpansion.LastInventoryUpdateJpInFormal = stock.LastInventoryUpdateJpInFormal;
            stockExpansion.LastSalesDate = stock.LastSalesDate;
            stockExpansion.LastSalesDateAdFormal = stock.LastSalesDateAdFormal;
            stockExpansion.LastSalesDateAdInFormal = stock.LastSalesDateAdInFormal;
            stockExpansion.LastSalesDateJpFormal = stock.LastSalesDateJpFormal;
            stockExpansion.LastSalesDateJpInFormal = stock.LastSalesDateJpInFormal;
            stockExpansion.LastStockDate = stock.LastStockDate;
            stockExpansion.LastStockDateAdFormal = stock.LastStockDateAdFormal;
            stockExpansion.LastStockDateAdInFormal = stock.LastStockDateAdInFormal;
            stockExpansion.LastStockDateJpFormal = stock.LastStockDateJpFormal;
            stockExpansion.LastStockDateJpInFormal = stock.LastStockDateJpInFormal;
            stockExpansion.LogicalDeleteCode = stock.LogicalDeleteCode;
            stockExpansion.GoodsMakerCd = stock.GoodsMakerCd;
            stockExpansion.MakerName = stock.MakerName;
            stockExpansion.MaximumStockCnt = stock.MaximumStockCnt;
            stockExpansion.MinimumStockCnt = stock.MinimumStockCnt;
            stockExpansion.MovingSupliStock = stock.MovingSupliStock;
            stockExpansion.MovingTrustStock = stock.MovingTrustStock;
            stockExpansion.NmlSalOdrCount = stock.NmlSalOdrCount;
            stockExpansion.SalesOrderCount = stock.SalesOrderCount;
            stockExpansion.SalesOrderUnit = stock.SalesOrderUnit;
            stockExpansion.SectionCode = stock.SectionCode;
            stockExpansion.ShipmentPosCnt = stock.ShipmentPosCnt;
            stockExpansion.SoldCnt = stock.SoldCnt;
            stockExpansion.StockTotalPrice = stock.StockTotalPrice;
            stockExpansion.StockUnitPriceFl = stock.StockUnitPriceFl;
            stockExpansion.SupplierStock = stock.SupplierStock;
            stockExpansion.TrustCount = stock.TrustCount;
            stockExpansion.UpdAssemblyId1 = stock.UpdAssemblyId1;
            stockExpansion.UpdAssemblyId2 = stock.UpdAssemblyId2;
            stockExpansion.UpdateDateTime = stock.UpdateDateTime;
            stockExpansion.UpdateDateTimeAdFormal = stock.UpdateDateTimeAdFormal;
            stockExpansion.UpdateDateTimeAdInFormal = stock.UpdateDateTimeAdInFormal;
            stockExpansion.UpdateDateTimeJpFormal = stock.UpdateDateTimeJpFormal;
            stockExpansion.UpdateDateTimeJpInFormal = stock.UpdateDateTimeJpInFormal;
            stockExpansion.UpdEmployeeCode = stock.UpdEmployeeCode;
            stockExpansion.UpdEmployeeName = stock.UpdEmployeeName;
            stockExpansion.WarehouseCode = stock.WarehouseCode;
            stockExpansion.WarehouseName = stock.WarehouseName;
            stockExpansion.WarehouseShelfNo = stock.WarehouseShelfNo;

//            stockExpansion.LargeGoodsGanreCode = stock.LargeGoodsGanreCode;
//            stockExpansion.LargeGoodsGanreName = stock.LargeGoodsGanreName;
//            stockExpansion.MediumGoodsGanreCode = stock.MediumGoodsGanreCode;
//            stockExpansion.MediumGoodsGanreName = stock.MediumGoodsGanreName;
//            stockExpansion.DetailGoodsGanreCode = stock.DetailGoodsGanreCode;
//            stockExpansion.DetailGoodsGanreName = stock.DetailGoodsGanreName;
//            stockExpansion.BLGoodsCode = stock.BLGoodsCode;

            return stockExpansion;
        }
        // 2007.10.11 修正 <<<<<<<<<<<<<<<<<<<<
           --- DEL 2008/07/24 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/07/24 Partsman用に変更

        #endregion

        //--------------------------------------------------------
		//  各種変換処理
		//--------------------------------------------------------
        #region 2007.10.11 削除
        // 2007.10.11 削除 >>>>>>>>>>>>>>>>>>>>
        #region 在庫調整データ変換処理(UIデータ→StaticTable)
        /*
        public void ProductStockToGrid(List<ProductStock> souceList)
        {
            ProductStockToDataTable(souceList);
        }                
        public void ProductStockToGrid(List<ProductStock> souceList,List<Stock> stockList, int insRow,int mode)
        {
            ProductStockToDataTable(souceList,stockList, insRow,mode);
        }
        public void ProductStockToGridGrs(List<ProductStock> souceList, List<StockEachWarehouse> stockList, int insRow, int mode)
        {
            ProductStockToDataTableGrs(souceList, stockList, insRow, mode);
        }
		/// <summary>
		/// 在庫調整データ変換処理(UIデータ→StaticTable)
		/// </summary>
		/// <param name="souceList"></param>
		private static void ProductStockToDataTable(List<ProductStock> souceList)
		{
			// 変更イベント無効
			DeactivateDtlChangeEventHandler();

			try
			{
				if (souceList != null)
				{                    
					// 製番在庫データよりデータ行を作成する
					foreach (ProductStock wkDtl in souceList)
					{
						// DataRowをDataTableへ設定する
						_mainProductStock.Rows.Add(ProductStockToDataRow(wkDtl));
					}
				}

				// 初期明細行数の決定
				maxRowCnt = ctCOUNT_RowInit;
				while (maxRowCnt < _mainProductStock.Rows.Count)
				{
					maxRowCnt += ctCOUNT_RowAdd;
				}

				// 明細最大行数に満たない分を生成する
				string msg;
				CreateDummySlipDtl(out msg);
			}
			finally
			{
				// 変更イベント有効
				ActivateDtlChangeEventHandler();
			}
		}

        /// <summary>
        /// DataTableへ反映
        /// </summary>
        /// <param name="souceList"></param>
        /// <param name="stockList"></param>
        /// <param name="insRow"></param>
        /// <param name="mode"></param>
        private void ProductStockToDataTableGrs(List<ProductStock> souceList, List<StockEachWarehouse> stockList, int insRow, int mode)
        {
            DeactivateDtlChangeEventHandler();
            int lastRowNo = 0;
            try
            {
                if (souceList != null)
                {
                    DataRow newRow = null;
                    foreach (ProductStock wkDTL in souceList)
                    {
                        if (insRow >= 0)
                        {
                            newRow = _mainProductStock.Rows[insRow];
                        }
                        else if (insRow < 0 || (newRow[ctCOL_ProductNumber].ToString().Trim() == ""))
                        {
                            //空白行に埋め込みなので、前方に空白行があれば詰める。
                            for (int i = 0; i < _mainProductStock.Rows.Count; i++)
                            {

                                if ((_mainProductStock.Rows[i][ctCOL_FileHeaderGuid] == DBNull.Value) ||
                                    ((Guid)_mainProductStock.Rows[i][ctCOL_FileHeaderGuid] == Guid.Empty))
                                {
                                    newRow = _mainProductStock.Rows[i];
                                    lastRowNo++;
                                    break;
                                }
                            }
                        }

                        ProductStockChangeRowGrs(ref newRow, stockList, wkDTL, mode);
                        newRow.AcceptChanges();
                        if (lastRowNo == _mainProductStock.Rows.Count)
                        {
                            IncrementProductStock();
                        }
                    }
                }
            }
            finally
            {
                ActivateDtlChangeEventHandler();
            }
        }
        /// <summary>
        /// 製番在庫データ変換処理(1件置換え)
        /// </summary>
        private void ProductStockToDataTable(List<ProductStock> souceList,List<Stock> stockList, int insRow,int mode)
        {
            DeactivateDtlChangeEventHandler();
            int lastRowNo = 0;
            try
            {

                if (souceList != null)
                {
                    DataRow newRow = null;
                    foreach (ProductStock wkDTL in souceList)
                    {
                        if (insRow >= 0)
                        {
                            newRow = _mainProductStock.Rows[insRow];
                        }
                        else if (insRow < 0 || (newRow[ctCOL_ProductNumber].ToString().Trim() == ""))
                        {
                            //空白行に埋め込みなので、前方に空白行があれば詰める。
                            for (int i = 0; i < _mainProductStock.Rows.Count; i++)
                            {

                                if ((_mainProductStock.Rows[i][ctCOL_FileHeaderGuid] == DBNull.Value) ||
                                    ((Guid)_mainProductStock.Rows[i][ctCOL_FileHeaderGuid] == Guid.Empty))
                                {
                                    newRow = _mainProductStock.Rows[i];
                                    lastRowNo++;
                                    break;
                                }
                            }
                        }

                        ProductStockChangeRow(ref newRow,stockList, wkDTL,mode);
                        newRow.AcceptChanges();
                        if (lastRowNo == _mainProductStock.Rows.Count)
                        {
                            IncrementProductStock();
                        }
                    }
                }
            }
            finally
            {
                ActivateDtlChangeEventHandler();
            }
        }
        /// <summary>
        /// Grid更新
        /// </summary>
        private void ProductStockChangeRow(ref DataRow newRow,List<Stock> stockList, ProductStock wkDTL,int mode)
        {
            newRow[ctCOL_CreateDateTime] = wkDTL.CreateDateTime;
            newRow[ctCOL_UpdateDateTime] = wkDTL.UpdateDateTime;
            newRow[ctCOL_EnterpriseCode] = wkDTL.EnterpriseCode;
            newRow[ctCOL_FileHeaderGuid] = wkDTL.FileHeaderGuid;
            newRow[ctCOL_UpdEmployeeCode] = wkDTL.UpdEmployeeCode;
            newRow[ctCOL_UpdAssemblyId1] = wkDTL.UpdAssemblyId1;
            newRow[ctCOL_UpdAssemblyId2] = wkDTL.UpdAssemblyId2;
            newRow[ctCOL_LogicalDeleteCode] = wkDTL.LogicalDeleteCode;
            newRow[ctCOL_SectionCode] = wkDTL.SectionCode;
            newRow[ctCOL_MakerCode] = wkDTL.MakerCode;
            newRow[ctCOL_GoodsCode] = wkDTL.GoodsCode;
            newRow[ctCOL_GoodsName] = wkDTL.GoodsName;
            newRow[ctCOL_ProductNumber] = wkDTL.ProductNumber.Trim();
            newRow[ctCOL_BfProductNumber] = wkDTL.ProductNumber;
            newRow[ctCOL_ProductStockGuid] = wkDTL.ProductStockGuid;
            newRow[ctCOL_WarehouseCode] = wkDTL.WarehouseCode;
            newRow[ctCOL_WarehouseName] = wkDTL.WarehouseName;
            newRow[ctCOL_StockDiv] = wkDTL.StockDiv;
            newRow[ctCOL_CarrierEpCode] = wkDTL.CarrierEpCode;
            newRow[ctCOL_CarrierEpName] = wkDTL.CarrierEpName;
            newRow[ctCOL_CustomerCode] = wkDTL.CustomerCode;
            newRow[ctCOL_CustomerName] = wkDTL.CustomerName;
            newRow[ctCOL_CustomerName2] = wkDTL.CustomerName2;
            newRow[ctCOL_StockDate] = wkDTL.StockDate;
            newRow[ctCOL_ArrivalGoodsDay] = wkDTL.ArrivalGoodsDay;

            int stockPointWay = GetStockPointWay();
            Int64 setPrice = 0;
            if ((stockPointWay == (int)ConstantManagement_Mobile.ct_StockPointWay.Average) ||
                (stockPointWay == (int)ConstantManagement_Mobile.ct_StockPointWay.Last))
            {
                //移動平均法=>在庫マスタの仕入単価が全体設定(在庫マスタ参照)
                Stock chkStock = new Stock();
                //在庫情報呼出                
                string goodsCode = (string)newRow[ctCOL_GoodsCode];
                if (!String.IsNullOrEmpty(goodsCode))
                {
                    GetStockInf(out chkStock, goodsCode, (Int32)newRow[ctCOL_MakerCode], mode);
                    if (wkDTL.StockDiv != 1)
                    {
                        setPrice = chkStock.StockUnitPrice;
                        newRow[ctCOL_StockUnitPrice] = setPrice;
                    }
                    else
                    {
                        newRow[ctCOL_StockUnitPrice] = 0;
                    }
                }
            }
            else
            {
                if (wkDTL.StockDiv != 1)
                {
                    setPrice = wkDTL.StockUnitPrice;
                    newRow[ctCOL_StockUnitPrice] = setPrice;
                }
                else
                {
                    newRow[ctCOL_StockUnitPrice] = 0;
                }

            }

            newRow[ctCOL_BfStockUnitPrice] = setPrice;
            newRow[ctCOL_TaxationCode] = wkDTL.TaxationCode;
            newRow[ctCOL_StockState] = wkDTL.StockState;
            newRow[ctCOL_MoveStatus] = wkDTL.MoveStatus;
            newRow[ctCOL_GoodsCodeStatus] = wkDTL.GoodsCodeStatus;
            newRow[ctCOL_GoodsCodeStatus] = wkDTL.GoodsCodeStatus;
            newRow[ctCOL_StockTelNo1] = wkDTL.StockTelNo1.ToString().Trim();
            newRow[ctCOL_StockTelNo2] = wkDTL.StockTelNo2.ToString().Trim();
            newRow[ctCOL_RomDiv] = wkDTL.RomDiv;
            newRow[ctCOL_CellphoneModelCode] = wkDTL.CellphoneModelCode;
            newRow[ctCOL_CellphoneModelName] = wkDTL.CellphoneModelName;
            newRow[ctCOL_CarrierCode] = wkDTL.CarrierCode;
            newRow[ctCOL_CarrierName] = wkDTL.CarrierName;
            newRow[ctCOL_MakerName] = wkDTL.MakerName;
            newRow[ctCOL_SystematicColorCd] = wkDTL.SystematicColorCd;
            newRow[ctCOL_SystematicColorNm] = wkDTL.SystematicColorNm;
            newRow[ctCOL_LargeGoodsGanreCode] = wkDTL.LargeGoodsGanreCode;
            newRow[ctCOL_MediumGoodsGanreCode] = wkDTL.MediumGoodsGanreCode;
            newRow[ctCOL_ShipCustomerCode] = wkDTL.ShipCustomerCode;
            newRow[ctCOL_ShipCustomerName] = wkDTL.ShipCustomerName;
            newRow[ctCOL_ShipCustomerName2] = wkDTL.ShipCustomerName2;
            if (mode == ctMode_StockAdjust)
            {                
                newRow[ctCOL_AdjustCount] = -1;
                newRow[ctCOL_AdjustPrice] = setPrice * -1;                
            }
            else if (mode == ctMode_TrustAdjust)
            {
                newRow[ctCOL_AdjustCount] = -1;
                newRow[ctCOL_AdjustPrice] = setPrice * -1;                
            }
            else
            {
                if (wkDTL.StockDiv == 0)
                {
                    newRow[ctCOL_SupplierStock] = 1;
                }
                else if (wkDTL.StockDiv == 1)
                {
                    newRow[ctCOL_TrustCount] = 1;
                }
                newRow[ctCOL_AdjustCount] = 0;
            }

            if (mode == ctMode_StockAdjust)
            {
                newRow[ctCOL_SupplierStock] = 1; //製番単位は必ず1            
                newRow[ctCOL_TrustCount] = 0;
            }
            else if (mode == ctMode_TrustAdjust)
            {
                newRow[ctCOL_SupplierStock] = 0;
                newRow[ctCOL_TrustCount] = 1; //受託在庫
            }

            //　製番管理区分をセット
            foreach (Stock stock in stockList)
            {
                if ((stock.MakerCode == wkDTL.MakerCode) &&
                    (stock.GoodsCode == wkDTL.GoodsCode))
                {
                    newRow[ctCOL_PrdNumMngDiv] = stock.PrdNumMngDiv;
                    break;
                }                    
            }

            newRow[ctCOL_RowType] = 1; //製番単位は必ず1

        }

        private void ProductStockChangeRowGrs(ref DataRow newRow, List<StockEachWarehouse> stockList, ProductStock wkDTL, int mode)
        {
            newRow[ctCOL_CreateDateTime] = wkDTL.CreateDateTime;
            newRow[ctCOL_UpdateDateTime] = wkDTL.UpdateDateTime;
            newRow[ctCOL_EnterpriseCode] = wkDTL.EnterpriseCode;
            newRow[ctCOL_FileHeaderGuid] = wkDTL.FileHeaderGuid;
            newRow[ctCOL_UpdEmployeeCode] = wkDTL.UpdEmployeeCode;
            newRow[ctCOL_UpdAssemblyId1] = wkDTL.UpdAssemblyId1;
            newRow[ctCOL_UpdAssemblyId2] = wkDTL.UpdAssemblyId2;
            newRow[ctCOL_LogicalDeleteCode] = wkDTL.LogicalDeleteCode;
            newRow[ctCOL_SectionCode] = wkDTL.SectionCode;
            newRow[ctCOL_MakerCode] = wkDTL.MakerCode;
            newRow[ctCOL_GoodsCode] = wkDTL.GoodsCode;
            newRow[ctCOL_GoodsName] = wkDTL.GoodsName;
            newRow[ctCOL_ProductNumber] = wkDTL.ProductNumber.Trim();
            newRow[ctCOL_BfProductNumber] = wkDTL.ProductNumber;
            newRow[ctCOL_ProductStockGuid] = wkDTL.ProductStockGuid;
            newRow[ctCOL_WarehouseCode] = wkDTL.WarehouseCode;
            newRow[ctCOL_WarehouseName] = wkDTL.WarehouseName;
            newRow[ctCOL_StockDiv] = wkDTL.StockDiv;
            newRow[ctCOL_CarrierEpCode] = wkDTL.CarrierEpCode;
            newRow[ctCOL_CarrierEpName] = wkDTL.CarrierEpName;
            newRow[ctCOL_CustomerCode] = wkDTL.CustomerCode;
            newRow[ctCOL_CustomerName] = wkDTL.CustomerName;
            newRow[ctCOL_CustomerName2] = wkDTL.CustomerName2;
            newRow[ctCOL_StockDate] = wkDTL.StockDate;
            newRow[ctCOL_ArrivalGoodsDay] = wkDTL.ArrivalGoodsDay;

            int stockPointWay = GetStockPointWay();
            Int64 setPrice = 0;
            if ((stockPointWay == (int)ConstantManagement_Mobile.ct_StockPointWay.Average) ||
                (stockPointWay == (int)ConstantManagement_Mobile.ct_StockPointWay.Last))
            {
                //移動平均法=>在庫マスタの仕入単価が全体設定(在庫マスタ参照)
                Stock chkStock = new Stock();
                //在庫情報呼出                
                string goodsCode = (string)newRow[ctCOL_GoodsCode];
                if (!String.IsNullOrEmpty(goodsCode))
                {
                    GetStockInf(out chkStock, goodsCode, (Int32)newRow[ctCOL_MakerCode], mode);
                    if (wkDTL.StockDiv != 1)
                    {
                        setPrice = chkStock.StockUnitPrice;
                        newRow[ctCOL_StockUnitPrice] = setPrice;
                    }
                    else
                    {
                        newRow[ctCOL_StockUnitPrice] = 0;
                    }
                }
            }
            else
            {
                if (wkDTL.StockDiv != 1)
                {
                    setPrice = wkDTL.StockUnitPrice;
                    newRow[ctCOL_StockUnitPrice] = setPrice;
                }
                else
                {
                    newRow[ctCOL_StockUnitPrice] = 0;
                }

            }

            newRow[ctCOL_BfStockUnitPrice] = setPrice;
            newRow[ctCOL_TaxationCode] = wkDTL.TaxationCode;
            newRow[ctCOL_StockState] = wkDTL.StockState;
            newRow[ctCOL_MoveStatus] = wkDTL.MoveStatus;
            newRow[ctCOL_GoodsCodeStatus] = wkDTL.GoodsCodeStatus;
            newRow[ctCOL_GoodsCodeStatus] = wkDTL.GoodsCodeStatus;
            newRow[ctCOL_StockTelNo1] = wkDTL.StockTelNo1.ToString().Trim();
            newRow[ctCOL_StockTelNo2] = wkDTL.StockTelNo2.ToString().Trim();
            newRow[ctCOL_RomDiv] = wkDTL.RomDiv;
            newRow[ctCOL_CellphoneModelCode] = wkDTL.CellphoneModelCode;
            newRow[ctCOL_CellphoneModelName] = wkDTL.CellphoneModelName;
            newRow[ctCOL_CarrierCode] = wkDTL.CarrierCode;
            newRow[ctCOL_CarrierName] = wkDTL.CarrierName;
            newRow[ctCOL_MakerName] = wkDTL.MakerName;
            newRow[ctCOL_SystematicColorCd] = wkDTL.SystematicColorCd;
            newRow[ctCOL_SystematicColorNm] = wkDTL.SystematicColorNm;
            newRow[ctCOL_LargeGoodsGanreCode] = wkDTL.LargeGoodsGanreCode;
            newRow[ctCOL_MediumGoodsGanreCode] = wkDTL.MediumGoodsGanreCode;
            newRow[ctCOL_ShipCustomerCode] = wkDTL.ShipCustomerCode;
            newRow[ctCOL_ShipCustomerName] = wkDTL.ShipCustomerName;
            newRow[ctCOL_ShipCustomerName2] = wkDTL.ShipCustomerName2;
            if (mode == ctMode_StockAdjust)
            {
                newRow[ctCOL_AdjustCount] = -1;
                newRow[ctCOL_AdjustPrice] = setPrice * -1;
            }
            else if (mode == ctMode_TrustAdjust)
            {
                newRow[ctCOL_AdjustCount] = -1;
                newRow[ctCOL_AdjustPrice] = setPrice * -1;
            }
            else
            {
                if (wkDTL.StockDiv == 0)
                {
                    newRow[ctCOL_SupplierStock] = 1;
                }
                else if (wkDTL.StockDiv == 1)
                {
                    newRow[ctCOL_TrustCount] = 1;
                }
                newRow[ctCOL_AdjustCount] = 0;
            }

            if (mode == ctMode_StockAdjust)
            {
                newRow[ctCOL_SupplierStock] = 1; //製番単位は必ず1            
                newRow[ctCOL_TrustCount] = 0;
            }
            else if (mode == ctMode_TrustAdjust)
            {
                newRow[ctCOL_SupplierStock] = 0;
                newRow[ctCOL_TrustCount] = 1; //受託在庫
            }

            //　製番管理区分をセット
            foreach (StockEachWarehouse stock in stockList)
            {
                if ((stock.MakerCode == wkDTL.MakerCode) &&
                    (stock.GoodsCode == wkDTL.GoodsCode))
                {
                    newRow[ctCOL_PrdNumMngDiv] = stock.PrdNumMngDiv;
                    break;
                }
            }

            newRow[ctCOL_RowType] = 1; //製番単位は必ず1

        }
        */
        // 2007.10.11 削除 <<<<<<<<<<<<<<<<<<<<
        #endregion
        #endregion

        #region DEL 2008/07/24 Partsman用に変更
        /* --- DEL 2008/07/24 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// 特定CELLの中身を変更
        /// </summary>
        /// <param name="cellname"></param>
        /// <param name="RowNo"></param>
        /// <param name="setCount"></param>
        public void ProductStockChangeCell(string cellname, int RowNo,double setCount)
        {
            ProductStockChangeAtCell(cellname, RowNo,setCount);
        }
        private void ProductStockChangeAtCell(string cellname, int RowNo,double setCount)
        {
            DataRow nowRow = _mainProductStock.Rows[RowNo];
            nowRow[cellname] = setCount;

            
            ProductStockCalcTotal(RowNo);
        }
        
        /// <summary>
        /// 合計金額計算
        /// </summary>
        /// <param name="RowNo"></param>
        private void ProductStockCalcTotal(int RowNo)
        {            
            DataRow targetRow = _mainProductStock.Rows[RowNo];
            // 2008.01.17 修正 >>>>>>>>>>>>>>>>>>>>
            //double setPrice = (double)targetRow[ctCOL_AdjustCount]
            //                * (Int64)targetRow[ctCOL_StockUnitPrice];
            double setPrice = (double)targetRow[ctCOL_AdjustCount]
                            * (double)targetRow[ctCOL_StockUnitPrice];
            // 2008.01.17 修正 <<<<<<<<<<<<<<<<<<<<
            targetRow[ctCOL_AdjustPrice] = setPrice;
        }
        public Int64 ProductStockChangeTotalPrice()
        {
            Int64 totalPrice = 0;
            DataRow targetRow = null;
            for (int i = 0; i < _mainProductStock.Rows.Count; i++)
            {                
                targetRow = _mainProductStock.Rows[i];

                if (targetRow[ctCOL_AdjustPrice] == System.DBNull.Value)
                {
                    continue;
                }
                if (targetRow[ctCOL_AdjustPrice].ToString().Trim() == "")
                {
                    continue;
                }
                totalPrice = totalPrice + (Int64)targetRow[ctCOL_AdjustPrice];                    

            }
            return totalPrice;
        }
        /// <summary>
        /// 合計数計算
        /// </summary>
        /// <returns></returns>
        public double ProductStockChangeTotalCount()
        {
            double totalCount = 0;
            DataRow targetRow = null;
            for (int i = 0; i < _mainProductStock.Rows.Count; i++)
            {
                targetRow = _mainProductStock.Rows[i];

                if ((targetRow[ctCOL_AdjustCount] != null) && (targetRow[ctCOL_AdjustCount].ToString().Trim() != ""))
                {
                    string a1 = targetRow[ctCOL_AdjustCount].ToString();
                    totalCount = totalCount + (double)targetRow[ctCOL_AdjustCount];
                }
            }
            return totalCount;
        }
           --- DEL 2008/07/24 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/07/24 Partsman用に変更

        // --- ADD 2008/07/24 --------------------------------------------------------------------->>>>>
        public void ReadStockMngTtlSt()
        {
            ArrayList retList;

            int statusMngTtlSt = _stockMngTtlStAcs.SearchAll(out retList, LoginInfoAcquisition.EnterpriseCode);
            if (statusMngTtlSt == 0)
            {
                foreach (StockMngTtlSt stockMngTtlSt in retList)
                {
                    if ((stockMngTtlSt.LogicalDeleteCode == 0) && (stockMngTtlSt.SectionCode.Trim() == "00"))
                    {
                        _stockMngTtlSt = stockMngTtlSt;
                        break;
                    }
                }
            }
            else
            {
                _stockMngTtlSt = new StockMngTtlSt();
            }
        }

        public bool CheckSameGoodsUnitData(int makerCode, string goodsNo)
        {
            for (int i = 0; i < _mainProductStock.Rows.Count; i++)
            {
                if (_mainProductStock.Rows[i][ctCOL_GoodsMakerCd] == DBNull.Value)
                {
                    continue;
                }
                if (_mainProductStock.Rows[i][ctCOL_GoodsMakerCd].ToString().Trim() == "")
                {
                    continue;
                }
                if (_mainProductStock.Rows[i][ctCOL_GoodsNo] == DBNull.Value)
                {
                    continue;
                }
                if (_mainProductStock.Rows[i][ctCOL_GoodsNo].ToString().Trim() == "")
                {
                    continue;
                }

                int colMakerCd = int.Parse((string)_mainProductStock.Rows[i][ctCOL_GoodsMakerCd]);
                string colGoodsNo = (string)_mainProductStock.Rows[i][ctCOL_GoodsNo];

                if ((colMakerCd == makerCode) && (colGoodsNo == goodsNo))
                {
                    return (true);
                }
            }

            return (false);
        }

        /// <summary>
        /// 合計金額取得処理
        /// </summary>
        /// <returns>合計金額</returns>
        /// <remarks>
        /// <br>Note       : 合計金額を取得します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/07/24</br>
        /// </remarks>
        public Int64 GetTotalPrice()
        {
            Int64 totalPrice = 0;
            double dblTotalPrice = 0;

            // (単価×仕入数)の合計を求めます
            for (int i = 0; i < _mainProductStock.Rows.Count; i++)
            {
                if (_mainProductStock.Rows[i][ctCOL_StockUnitPrice] == DBNull.Value)
                {
                    continue;
                }
                if (_mainProductStock.Rows[i][ctCOL_StockUnitPrice].ToString().Trim() == "")
                {
                    continue;
                }
                if (_mainProductStock.Rows[i][ctCOL_SalesOrderUnit] == DBNull.Value)
                {
                    continue;
                }
                if (_mainProductStock.Rows[i][ctCOL_SalesOrderUnit].ToString().Trim() == "")
                {
                    continue;
                }

                dblTotalPrice = (double)_mainProductStock.Rows[i][ctCOL_StockUnitPrice] * 
                                (double)_mainProductStock.Rows[i][ctCOL_SalesOrderUnit];

                if ((dblTotalPrice % 1) != 0)
                {
                    switch (_stockMngTtlSt.FractionProcCd)
                    {
                        case 1:
                            {
                                // 切り捨て
                                totalPrice += (long)(dblTotalPrice / 1);
                                break;
                            }
                        case 2:
                            {
                                // 四捨五入
                                if (dblTotalPrice >= 0)
                                {
                                    totalPrice += (long)((dblTotalPrice + 0.5) / 1);
                                }
                                else
                                {
                                    totalPrice += (long)((dblTotalPrice - 0.5) / 1);
                                }
                                break;
                            }
                        case 3:
                            {
                                // 切り上げ
                                if (dblTotalPrice % 1 == 0)
                                {
                                    totalPrice += (long)(dblTotalPrice);
                                }
                                else
                                {
                                    if (dblTotalPrice >= 0)
                                    {
                                        totalPrice += (long)((dblTotalPrice + 1) / 1);
                                    }
                                    else
                                    {
                                        totalPrice += (long)((dblTotalPrice - 1) / 1);
                                    }
                                }
                                break;
                            }
                    }
                }
                else
                {
                    totalPrice += (long)dblTotalPrice;
                }

                //totalPrice += (Int64)((double)_mainProductStock.Rows[i][ctCOL_StockUnitPrice] * 
                //               (double)_mainProductStock.Rows[i][ctCOL_SalesOrderUnit]);
            }

            return totalPrice;
        }

        public Int64 GetTotalStockPriceTaxExc()
        {
            double dblTotalPrice = 0;

            // (単価×仕入数)の合計を求めます
            for (int i = 0; i < _mainProductStock.Rows.Count; i++)
            {
                if (_mainProductStock.Rows[i][ctCOL_StockPriceTaxExc] == DBNull.Value)
                {
                    continue;
                }
                if (_mainProductStock.Rows[i][ctCOL_StockPriceTaxExc].ToString().Trim() == "")
                {
                    continue;
                }

                dblTotalPrice += (long)_mainProductStock.Rows[i][ctCOL_StockPriceTaxExc];
            }

            return (Int64)dblTotalPrice;
        }

        public Int64 GetStockPriceTaxExc(double stockUnitPrice, double salesOrderUnit)
        {
            Int64 totalPrice = 0;
            double dblTotalPrice = 0;

            dblTotalPrice = stockUnitPrice * salesOrderUnit;

            if ((dblTotalPrice % 1) != 0)
            {
                switch (_stockMngTtlSt.FractionProcCd)
                {
                    case 1:
                        {
                            // 切り捨て
                            totalPrice += (long)(dblTotalPrice / 1);
                            break;
                        }
                    case 2:
                        {
                            // 四捨五入
                            if (dblTotalPrice >= 0)
                            {
                                totalPrice += (long)((dblTotalPrice + 0.5) / 1);
                            }
                            else
                            {
                                totalPrice += (long)((dblTotalPrice - 0.5) / 1);
                            }
                            break;
                        }
                    case 3:
                        {
                            // 切り上げ
                            if (dblTotalPrice % 1 == 0)
                            {
                                totalPrice += (long)(dblTotalPrice);
                            }
                            else
                            {
                                if (dblTotalPrice >= 0)
                                {
                                    totalPrice += (long)((dblTotalPrice + 1) / 1);
                                }
                                else
                                {
                                    totalPrice += (long)((dblTotalPrice - 1) / 1);
                                }
                            }
                            break;
                        }
                }
            }
            else
            {
                totalPrice += (long)dblTotalPrice;
            }

            return totalPrice;

        }

        /// <summary>
        /// 合計数取得処理
        /// </summary>
        /// <returns>合計数</returns>
        /// <remarks>
        /// <br>Note       : 合計数を取得します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/07/24</br>
        /// </remarks>
        public double GetTotalCount()
        {
            double totalCount = 0;

            // 仕入数の合計を求めます
            for (int i = 0; i < _mainProductStock.Rows.Count; i++)
            {
                if (_mainProductStock.Rows[i][ctCOL_SalesOrderUnit] == DBNull.Value)
                {
                    continue;
                }
                if (_mainProductStock.Rows[i][ctCOL_SalesOrderUnit].ToString().Trim() == "")
                {
                    continue;
                }

                totalCount += (double)_mainProductStock.Rows[i][ctCOL_SalesOrderUnit];
            }

            return totalCount;
        }

        /// <summary>
        /// 商品連結データグリッド表示処理
        /// </summary>
        /// <param name="goodsUnitData">商品連結データ</param>
        /// <param name="warehouseCode">倉庫コード</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="insertRowIndex">行インデックス</param>
        /// <remarks>
        /// <br>Note       : 商品連結データをグリッドへ反映します。(グリッドで品番入力後に使用します)</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/07/24</br>
        /// <br>Update Note: 2010/12/20 曹文傑</br>
        /// <br>               障害改良対応x月</br>
        /// <br>               あいまい検索で非在庫品を選択した場合に、品番が表示が不正になる不具合の修正。</br>
        /// <br>Update Note: 2013/01/04 zhangy3</br>
        /// <br>管理番号   : 10806793-00　2013/03/13配信分</br>　
        /// <br>           : Redmine#33845 在庫品仕入入力</br>
        /// <br>Update Note: 2021/10/12 鈴木創</br>
        /// <br>           : PJMIT-1477 PM.NS 在庫仕入入力画面にて品番を変更しても登録できてしまう</br>
        /// </remarks>
        public int GoodsUnitDataToGrid(GoodsUnitData goodsUnitData, string warehouseCode, string sectionCode, int insertRowIndex)
        {
            // 明細情報(MainStaticMemory)変更イベントハンドラ無効化
            DeactivateDtlChangeEventHandler();

            try
            {
                bool stockFlg = false;

                Stock stock = new Stock();

                // DEL 2009/11/16 3次分対応 在庫登録機能を追加 ---------->>>>>
                //if (goodsUnitData.StockList != null)
                // DEL 2009/11/16 3次分対応 在庫登録機能を追加 ----------<<<<<
                if (goodsUnitData.StockList != null && goodsUnitData.StockList.Count > 0)   // ADD 2009/11/16 3次分対応 在庫登録機能を追加
                {
                    // 在庫リストの中から倉庫コードが一致するものを取得
                    foreach (Stock stockwk in goodsUnitData.StockList)
                    {
                        //if ((stockwk.WarehouseCode.Trim().PadLeft(4, '0') == warehouseCode.Trim().PadLeft(4, '0')) &&
                        //    (stockwk.SectionCode.Trim().PadLeft(2, '0') == sectionCode.Trim().PadLeft(2, '0')))
                        // 2010/07/14 >>>
                        //if (stockwk.WarehouseCode.Trim().PadLeft(4, '0') == warehouseCode.Trim().PadLeft(4, '0'))
                        if (stockwk.WarehouseCode.Trim().PadLeft(4, '0') == warehouseCode.Trim().PadLeft(4, '0') &&
                            stockwk.LogicalDeleteCode == 0)
                        // 2010/07/14 <<<
                        {
                            stock = stockwk;
                            stockFlg = true;
                            break;
                        }
                    }
                    // --- Add Start zhangy3 2013/01/04 For Redmine#33845 ----->>>>>
                    if (goodsUnitData.OfferKubun == 4)
                    {
                        stockFlg = true;
                    }
                    // --- Add End   zhangy3 2013/01/04 For Redmine#33845 -----<<<<<
                    // 在庫商品の倉庫が不一致
                    if (!stockFlg)
                    {
                        // DEL 2009/11/16 3次分対応 在庫登録機能を追加 ---------->>>>>
                        // return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                        // DEL 2009/11/16 3次分対応 在庫登録機能を追加 ----------<<<<<
                        // 2010/07/14 Add >>>
                        DataRow newRowWk = _mainProductStock.Rows[insertRowIndex];

                        // メーカーコード
                        if (goodsUnitData.GoodsMakerCd == 0)
                        {
                            newRowWk[ctCOL_GoodsMakerCd] = "";
                        }
                        else
                        {
                            newRowWk[ctCOL_GoodsMakerCd] = goodsUnitData.GoodsMakerCd.ToString("0000");
                        }
                        newRowWk[ctCOL_GoodsNo] = goodsUnitData.GoodsNo;　// ADD 2010/12/20
                        // 2010/07/14 Add <<<
                        return (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;    // ADD 2009/11/16 3次分対応 在庫登録機能を追加
                    }
                }
                // ADD 2009/11/16 3次分対応 在庫登録機能を追加 ---------->>>>>
                // MEMO:商品は存在するが、在庫がない場合
                else
                {
                    // ADD 2021/10/12 ----------------------->>>>>
                    //前に入力したデータが残っている場合、表示が不正になるため、一度行情報を削除
                    ClrRowData(insertRowIndex);
                    // ADD 2021/10/12 -----------------------<<<<<

                    // --- ADD m.suzuki 2010/01/14 ---------->>>>>
                    DataRow newRowWk = _mainProductStock.Rows[insertRowIndex];

                    // メーカーコード
                    if ( goodsUnitData.GoodsMakerCd == 0 )
                    {
                        newRowWk[ctCOL_GoodsMakerCd] = "";
                    }
                    else
                    {
                        newRowWk[ctCOL_GoodsMakerCd] = goodsUnitData.GoodsMakerCd.ToString( "0000" );
                    }
                    // --- ADD m.suzuki 2010/01/14 ----------<<<<<

                    newRowWk[ctCOL_GoodsNo] = goodsUnitData.GoodsNo;　// ADD 2010/12/20

                    stockFlg = false;
                    return (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                }
                // ADD 2009/11/16 3次分対応 在庫登録機能を追加 ----------<<<<<

                DataRow newRow = _mainProductStock.Rows[insertRowIndex];

                // 在庫情報反映
                stock.SalesOrderUnit = 1;   // 仕入数の初期値を1に設定
                StockChangeRowGrs(ref newRow, stock, goodsUnitData);
            }
            finally
            {
                // 明細情報(MainStaticMemory)変更イベントハンドラ有効化
                ActivateDtlChangeEventHandler();
            }

            return (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
        }

        /// <summary>
        /// 在庫リストグリッド表示処理
        /// </summary>
        /// <param name="stockList">在庫リスト</param>
        /// <remarks>
        /// <br>Note       : 在庫リストをグリッドへ反映します。(在庫検索後に使用します)</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/07/24</br>
        /// </remarks>
        public void StockListToGrid(List<Stock> stockList)
        {
            // 明細情報(MainStaticMemory)変更イベントハンドラ無効化
            DeactivateDtlChangeEventHandler();

            try
            {
                if ((stockList == null) || (stockList.Count == 0))
                {
                    return;
                }

                // 在庫マスタリストに対応する商品連結データリストを取得
                List<GoodsUnitData> goodsUnitDataList = GetGoodsUnitDataList(stockList);

                List<int> deleteIndex = new List<int>();

                // 既に入力済みのデータを退避します
                List<object[]> dataRowList = new List<object[]>();
                for (int index = 0; index < _mainProductStock.Rows.Count; index++)
                {
                    if ((_mainProductStock.Rows[index][ctCOL_GoodsNo] != DBNull.Value) &&
                        (((String)_mainProductStock.Rows[index][ctCOL_GoodsNo]).Trim() != ""))
                    {
                        dataRowList.Add(_mainProductStock.Rows[index].ItemArray);

                        // 削除対象行インデックス取得
                        deleteIndex.Add(index);
                    }
                }

                for (int index = deleteIndex.Count - 1; index >= 0; index--)
                {
                    // 対象行削除
                    DelGridRow(deleteIndex[index]);
                }

                // 退避したデータをグリッドに反映します
                for (int index = 0; index < dataRowList.Count; index++)
                {
                    _mainProductStock.Rows[index].ItemArray = dataRowList[index];
                    _mainProductStock.Rows[index][ctCOL_RowNum] = index + 1;
                }

                // データの挿入開始インデックスを取得
                int insertIndex = 0;
                for (int index = 0; index < _mainProductStock.Rows.Count; index++)
                {
                    if ((_mainProductStock.Rows[index][ctCOL_GoodsNo] == DBNull.Value) ||
                        (((String)_mainProductStock.Rows[index][ctCOL_GoodsNo]).Trim() == ""))
                    {
                        insertIndex = index;
                        break;
                    }
                }

                Stock stock = new Stock();
                DataRow newRow = null;
                for (int index = 0; index < stockList.Count; index++)
                {
                    stock = stockList[index];
                    newRow = _mainProductStock.Rows[insertIndex];

                    // 在庫情報反映
                    StockChangeRowGrs(ref newRow, stock, goodsUnitDataList[index]);

                    if (insertIndex >= _mainProductStock.Rows.Count - 1)
                    {
                        // 明細行数増加
                        IncrementProductStock();
                    }

                    insertIndex++;
                }
            }
            finally
            {
                // 明細情報(MainStaticMemory)変更イベントハンドラ有効化
                ActivateDtlChangeEventHandler();
            }
        }

        /// <summary>
        /// 在庫調整伝票グリッド表示処理
        /// </summary>
        /// <param name="stockAdjust">在庫調整データ</param>
        /// <param name="stockAdjustDtlList">在庫調整明細データリスト</param>
        /// <param name="flag">伝票番号で検索するかどうかを判断する用のフラグ</param>
        /// <remarks>
        /// <br>Note       : 在庫調整伝票をグリッドへ反映します。(在庫仕入伝票検索後に使用します)</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/07/24</br>
        /// </remarks>
        public void StockAdjustDtlListToGrid(StockAdjust stockAdjust, List<StockAdjustDtl> stockAdjustDtlList, params bool[] flag)//add 2011/12/13 陳建明 Redmine #26816
        //public void StockAdjustDtlListToGrid(StockAdjust stockAdjust, List<StockAdjustDtl> stockAdjustDtlList)//del 2011/12/13 陳建明 Redmine #26816
        {
            // 明細情報(MainStaticMemory)変更イベントハンドラ無効化
            DeactivateDtlChangeEventHandler();

            try
            {
                for (int index = 0; index < _mainProductStock.Rows.Count; index++)
                {
                    // 行クリア
                    ClrGridRow(index);
                }

                if ((stockAdjustDtlList == null) || (stockAdjustDtlList.Count == 0))
                {
                    return;
                }

                // 在庫調整明細データリストに対応する在庫マスタリストを取得
                List<Stock> stockList = GetStockList(stockAdjust, stockAdjustDtlList);

                // 在庫マスタリストに対応する商品連結データリストを取得
                List<GoodsUnitData> goodsUnitDataList = GetGoodsUnitDataList(stockList, flag);//add 2011/12/13 陳建明 Redmine #26816
                //List<GoodsUnitData> goodsUnitDataList = GetGoodsUnitDataList(stockList);//del 2011/12/13 陳建明 Redmine #26816

                DataRow newRow = null;
                for (int index = 0; index < stockList.Count; index++)
                {
                    newRow = _mainProductStock.Rows[index];

                    // ---ADD 2009/06/03 不具合対応[13427] ----------->>>>>
                    //下記項目に関しては在庫調整データから表示
                    goodsUnitDataList[index].GoodsNo = stockAdjustDtlList[index].GoodsNo;               //品番
                    goodsUnitDataList[index].GoodsName = stockAdjustDtlList[index].GoodsName;           //品名
                    goodsUnitDataList[index].BLGoodsCode = stockAdjustDtlList[index].BLGoodsCode;       //ＢＬコード
                    goodsUnitDataList[index].GoodsMakerCd = stockAdjustDtlList[index].GoodsMakerCd;     //メーカーコード
                    goodsUnitDataList[index].SupplierCd = stockAdjustDtlList[index].SupplierCd;         //仕入先コード
                    goodsUnitDataList[index].SupplierSnm = stockAdjustDtlList[index].SupplierSnm;       //仕入先名称
                    stockList[index].WarehouseShelfNo = stockAdjustDtlList[index].WarehouseShelfNo;     //棚番
                    // ---ADD 2009/06/03 不具合対応[13427] -----------<<<<<

                    // 在庫情報反映
                    StockChangeRowGrs(ref newRow, stockList[index], stockAdjust, stockAdjustDtlList[index],  goodsUnitDataList[index]);

                    if (index >= _mainProductStock.Rows.Count - 1)
                    {
                        // 明細行数増加
                        IncrementProductStock();
                    }
                }

                // 対象行以外削除
                for (int index = _mainProductStock.Rows.Count - 1; index >= stockList.Count; index--)
                {
                    _mainProductStock.Rows[index].Delete();
                }
            }
            finally
            {
                // 明細情報(MainStaticMemory)変更イベントハンドラ有効化
                ActivateDtlChangeEventHandler();
            }
        }

        /// <summary>
        /// 発注残照会リモート抽出結果グリッド表示処理
        /// </summary>
        /// <param name="orderListResultWorkList">発注残照会リモート抽出結果リスト</param>
        /// <remarks>
        /// <br>Note       : 発注残照会リモート抽出結果をグリッドへ反映します。(発注残照会検索後に使用します)</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/07/24</br>
        /// </remarks>
        public void OrderListResultWorkToGrid(List<OrderListResultWork> orderListResultWorkList)
        {
            // 明細情報(MainStaticMemory)変更イベントハンドラ無効化
            DeactivateDtlChangeEventHandler();

            try
            {
                for (int index = 0; index < _mainProductStock.Rows.Count; index++)
                {
                    // 行クリア
                    ClrGridRow(index);
                }

                if ((orderListResultWorkList == null) || (orderListResultWorkList.Count == 0))
                {
                    return;
                }

                // 発注残照会リモート抽出結果リストに対応する在庫マスタリストを取得
                List<Stock> stockList = GetStockList(orderListResultWorkList);

                // 在庫マスタリストに対応する商品連結データリストを取得
                List<GoodsUnitData> goodsUnitDataList = GetGoodsUnitDataList(stockList, true);//add 2011/12/16 陳建明 Redmine #26816
                //List<GoodsUnitData> goodsUnitDataList = GetGoodsUnitDataList(stockList);//del 2011/12/16 陳建明 Redmine #26816
                DataRow newRow = null;
                for (int index = 0; index < stockList.Count; index++)
                {
                    newRow = _mainProductStock.Rows[index];

                    // 在庫情報反映
                    StockChangeRowGrs(ref newRow, stockList[index], goodsUnitDataList[index], orderListResultWorkList[index]);

                    if (index >= _mainProductStock.Rows.Count - 1)
                    {
                        // 明細行数増加
                        IncrementProductStock();
                    }
                }

                // 対象行以外削除
                for (int index = _mainProductStock.Rows.Count - 1; index >= stockList.Count; index--)
                {
                    _mainProductStock.Rows[index].Delete();
                }
            }
            finally
            {
                // 明細情報(MainStaticMemory)変更イベントハンドラ有効化
                ActivateDtlChangeEventHandler();
            }
        }
        // --- ADD 2008/07/24 ---------------------------------------------------------------------<<<<<

        #region DEL 2008/07/24 Partsman用に変更
        /* --- DEL 2008/07/24 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// DataTableへ反映
        /// </summary>
        /// <param name="souceList"></param>
        /// <param name="insRow"></param>
        // 2008.02.15 削除 >>>>>>>>>>>>>>>>>>>>
        #region 2008.02.15 削除
        //public void StockToGrid(List<Stock> souceList,int insRow)
        //{
        //    StockToDataTable(souceList, insRow);           
        //}
        #endregion
        // 2008.02.15 削除 <<<<<<<<<<<<<<<<<<<<
        // 2007.10.11 修正 >>>>>>>>>>>>>>>>>>>>
        //public void StockToGridGrs(List<StockEachWarehouse> souceList, int insRow)
        public void StockToGridGrs(List<StockExpansion> souceList, int insRow)
        // 2007.10.11 修正 <<<<<<<<<<<<<<<<<<<<
        {
            StockToDataTableGrs(souceList, insRow);
        }
        // 2007.10.11 修正 >>>>>>>>>>>>>>>>>>>>
        //private void StockToDataTableGrs(List<StockEachWarehouse> souceList, int insRow)
        private void StockToDataTableGrs(List<StockExpansion> souceList, int insRow)
        // 2007.10.11 修正 <<<<<<<<<<<<<<<<<<<<
        {
            DeactivateDtlChangeEventHandler();
            int lastRowNo = 0;
            try
            {
                if (souceList != null)
                {
                    DataRow newRow = null;
                    // 2007.10.11 修正 >>>>>>>>>>>>>>>>>>>>
                    //foreach (StockEachWarehouse wkDTL in souceList)
                    foreach (StockExpansion wkDTL in souceList)
                    // 2007.10.11 修正 <<<<<<<<<<<<<<<<<<<<
                    {
                        if (insRow >= 0)
                        {
                            newRow = _mainProductStock.Rows[insRow];
                        }
                        else if (insRow < 0)
                        {
                            //空白行に埋め込みなので、前方に空白行があれば詰める。
                            for (int i = 0; i < _mainProductStock.Rows.Count; i++)
                            {
                                //                                if ((System.Guid)_mainProductStock.Rows[i][ctCOL_FileHeaderGuid] == Guid.Empty)
                                object oo = _mainProductStock.Rows[i][ctCOL_FileHeaderGuid];
                                if ((_mainProductStock.Rows[i][ctCOL_FileHeaderGuid] == DBNull.Value) ||
                                    ((Guid)_mainProductStock.Rows[i][ctCOL_FileHeaderGuid] == Guid.Empty))
                                {
                                    newRow = _mainProductStock.Rows[i];
                                    lastRowNo++;
                                    break;
                                }
                            }
                        }
                        StockChangeRowGrs(ref newRow, wkDTL);
                        //StockChangeRow(ref newRow, wkDTL);
                        if (lastRowNo == _mainProductStock.Rows.Count)
                        {
                            IncrementProductStock();
                        }

                    }
                }
            }
            finally
            {
                ActivateDtlChangeEventHandler();
            }
        }
           --- DEL 2008/07/24 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/07/24 Partsman用に変更

        #region 2008.02.15 削除
        // 2008.02.15 削除 >>>>>>>>>>>>>>>>>>>>
        //private void StockToDataTable(List<Stock> souceList, int insRow)
        //{
        //    DeactivateDtlChangeEventHandler();
        //    int lastRowNo = 0;
        //    try
        //    {

        //        if (souceList != null)
        //        {
        //            DataRow newRow = null;
        //            foreach (Stock wkDTL in souceList)
        //            {
        //                if (insRow >= 0)
        //                {
        //                    newRow = _mainProductStock.Rows[insRow];
        //                }
        //                else if (insRow < 0)
        //                {
        //                    //空白行に埋め込みなので、前方に空白行があれば詰める。
        //                    for (int i = 0; i < _mainProductStock.Rows.Count; i++)
        //                    {
        //                        //if ((System.Guid)_mainProductStock.Rows[i][ctCOL_FileHeaderGuid] == Guid.Empty)
        //                        object oo = _mainProductStock.Rows[i][ctCOL_FileHeaderGuid];
        //                        if ((_mainProductStock.Rows[i][ctCOL_FileHeaderGuid] == DBNull.Value) ||
        //                            ((Guid)_mainProductStock.Rows[i][ctCOL_FileHeaderGuid] == Guid.Empty))
        //                        {
        //                            newRow = _mainProductStock.Rows[i];
        //                            lastRowNo++;
        //                            break;
        //                        }
        //                    }
        //                }

        //                StockChangeRow(ref newRow, wkDTL);
        //                if (lastRowNo == _mainProductStock.Rows.Count)
        //                {
        //                    IncrementProductStock();
        //                }

        //            }
        //        }
        //    }
        //    finally
        //    {
        //        ActivateDtlChangeEventHandler();
        //    }
        //}
        // 2008.02.15 削除 <<<<<<<<<<<<<<<<<<<<
        #endregion

        #region 2008.02.15 削除
        // 2008.02.15 削除 >>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// 在庫情報反映(GRID)
        /// </summary>
        /// <param name="newRow"></param>
        /// <param name="wkDTL"></param>
        //private void StockChangeRow(ref DataRow newRow, Stock wkDTL)        
        //{
        //    newRow[ctCOL_CreateDateTime] = wkDTL.CreateDateTime;
        //    newRow[ctCOL_UpdateDateTime] = wkDTL.UpdateDateTime;
        //    newRow[ctCOL_EnterpriseCode] = wkDTL.EnterpriseCode;
        //    newRow[ctCOL_FileHeaderGuid] = wkDTL.FileHeaderGuid;
        //    newRow[ctCOL_UpdEmployeeCode] = wkDTL.UpdEmployeeCode;
        //    newRow[ctCOL_UpdAssemblyId1] = wkDTL.UpdAssemblyId1;
        //    newRow[ctCOL_UpdAssemblyId2] = wkDTL.UpdAssemblyId2;
        //    newRow[ctCOL_LogicalDeleteCode] = wkDTL.LogicalDeleteCode;
        //    newRow[ctCOL_SectionCode] = wkDTL.SectionCode;
        //    // 2007.10.11 修正 >>>>>>>>>>>>>>>>>>>>
        //    //newRow[ctCOL_MakerCode] = wkDTL.MakerCode;
        //    //newRow[ctCOL_GoodsCode] = wkDTL.GoodsCode;
        //    newRow[ctCOL_GoodsMakerCd] = wkDTL.GoodsMakerCd;
        //    newRow[ctCOL_GoodsNo] = wkDTL.GoodsNo;
        //    // 2007.10.11 修正 <<<<<<<<<<<<<<<<<<<<
        //    newRow[ctCOL_GoodsName] = wkDTL.GoodsName;

        //    newRow[ctCOL_WarehouseCode] = "";
        //    newRow[ctCOL_WarehouseName] = "";

        //    // 2008.02.15 修正 >>>>>>>>>>>>>>>>>>>>
        //    //if (GetEditMode() == 1)
        //    //{
        //    //    //受託調整は単価０
        //    //    newRow[ctCOL_StockUnitPrice] = 0;
        //    //    newRow[ctCOL_BfStockUnitPrice] = 0;
        //    //}
        //    //else
        //    //{
        //    //    // 2007.10.11 修正 >>>>>>>>>>>>>>>>>>>>
        //    //    //newRow[ctCOL_StockUnitPrice] = wkDTL.StockUnitPrice;
        //    //    //newRow[ctCOL_BfStockUnitPrice] = wkDTL.StockUnitPrice;
        //    //    newRow[ctCOL_StockUnitPrice] = wkDTL.StockUnitPriceFl;
        //    //    newRow[ctCOL_BfStockUnitPrice] = wkDTL.StockUnitPriceFl;
        //    //    // 2007.10.11 修正 <<<<<<<<<<<<<<<<<<<<
        //    //}
        //    newRow[ctCOL_StockUnitPrice] = wkDTL.StockUnitPriceFl;
        //    newRow[ctCOL_BfStockUnitPrice] = wkDTL.StockUnitPriceFl;
        //    // 2008.02.15 修正 <<<<<<<<<<<<<<<<<<<<
        //    // 仕入在庫数 = 仕入在庫数 - 仕入委託 - 移動仕入
        //    newRow[ctCOL_SupplierStock] = wkDTL.SupplierStock - wkDTL.EntrustCnt - wkDTL.MovingSupliStock;
        //    // 受託在庫数 = 受託在庫数 - 受託委託 - 移動受託
        //    // 2007.10.11 修正 >>>>>>>>>>>>>>>>>>>>
        //    //newRow[ctCOL_TrustCount] = wkDTL.TrustCount - wkDTL.TrustEntrustCnt - wkDTL.MovingTrustStock;
        //    newRow[ctCOL_TrustCount] = wkDTL.TrustCount - wkDTL.TrustCount - wkDTL.MovingTrustStock;
        //    // 2007.10.11 修正 <<<<<<<<<<<<<<<<<<<<

        //    // 2007.10.11 修正 >>>>>>>>>>>>>>>>>>>>
        //    //newRow[ctCOL_CellphoneModelCode] = wkDTL.CellphoneModelCode;
        //    //newRow[ctCOL_CellphoneModelName] = wkDTL.CellphoneModelName;
        //    //newRow[ctCOL_CarrierCode] = wkDTL.CarrierCode;
        //    //newRow[ctCOL_CarrierName] = wkDTL.CarrierName;
        //    //newRow[ctCOL_MakerName] = wkDTL.MakerName;
        //    //newRow[ctCOL_SystematicColorCd] = wkDTL.SystematicColorCd;
        //    //newRow[ctCOL_SystematicColorNm] = wkDTL.SystematicColorNm;
        //    //newRow[ctCOL_LargeGoodsGanreCode] = wkDTL.LargeGoodsGanreCode;
        //    //newRow[ctCOL_MediumGoodsGanreCode] = wkDTL.MediumGoodsGanreCode;
        //    //newRow[ctCOL_PrdNumMngDiv] = wkDTL.PrdNumMngDiv;

        //    newRow[ctCOL_MakerName] = wkDTL.MakerName;
        //    //newRow[ctCOL_LargeGoodsGanreCode] = wkDTL.LargeGoodsGanreCode;
        //    //newRow[ctCOL_MediumGoodsGanreCode] = wkDTL.MediumGoodsGanreCode;
        //    //newRow[ctCOL_DetailGoodsGanreCode] = wkDTL.DetailGoodsGanreCode;
        //    //newRow[ctCOL_BLGoodsCode] = wkDTL.BLGoodsCode;

        //    newRow[ctCOL_WarehouseShelfNo] = wkDTL.WarehouseShelfNo;
        //    newRow[ctCOL_BfWarehouseShelfNo] = wkDTL.WarehouseShelfNo;
        //    // 2007.10.11 修正 <<<<<<<<<<<<<<<<<<<<
        //    // 2008.02.15 修正 >>>>>>>>>>>>>>>>>>>>
        //    //if (GetEditMode() == 1)
        //    //{
        //    //    newRow[ctCOL_StockDiv] = 1;
        //    //}
        //    //else
        //    //{
        //    //    newRow[ctCOL_StockDiv] = 0;
        //    //}
        //    newRow[ctCOL_StockDiv] = 0;
        //    // 2008.02.15 修正 <<<<<<<<<<<<<<<<<<<<
        //    newRow[ctCOL_RowType] = 0; //在庫は必ず0
        //}
        // 2008.02.15 削除 <<<<<<<<<<<<<<<<<<<<
        #endregion

        #region DEL 2008/07/24 Partsman用に変更
        /* --- DEL 2008/07/24 --------------------------------------------------------------------->>>>>
        // 2007.10.11 修正 >>>>>>>>>>>>>>>>>>>>
        //private void StockChangeRowGrs(ref DataRow newRow, StockEachWarehouse wkDTL)
        private void StockChangeRowGrs(ref DataRow newRow, StockExpansion wkDTL)
        // 2007.10.11 修正 <<<<<<<<<<<<<<<<<<<<
        {
            newRow[ctCOL_CreateDateTime] = wkDTL.CreateDateTime;
            newRow[ctCOL_UpdateDateTime] = wkDTL.UpdateDateTime;
            newRow[ctCOL_EnterpriseCode] = wkDTL.EnterpriseCode;
            newRow[ctCOL_FileHeaderGuid] = wkDTL.FileHeaderGuid;
            newRow[ctCOL_UpdEmployeeCode] = wkDTL.UpdEmployeeCode;
            newRow[ctCOL_UpdAssemblyId1] = wkDTL.UpdAssemblyId1;
            newRow[ctCOL_UpdAssemblyId2] = wkDTL.UpdAssemblyId2;
            newRow[ctCOL_LogicalDeleteCode] = wkDTL.LogicalDeleteCode;
            newRow[ctCOL_SectionCode] = wkDTL.SectionCode;
            // 2007.10.11 修正 >>>>>>>>>>>>>>>>>>>>
            //newRow[ctCOL_MakerCode] = wkDTL.MakerCode;
            //newRow[ctCOL_GoodsCode] = wkDTL.GoodsCode;
            newRow[ctCOL_GoodsMakerCd] = wkDTL.GoodsMakerCd;
            newRow[ctCOL_GoodsNo] = wkDTL.GoodsNo;
            // 2007.10.11 修正 <<<<<<<<<<<<<<<<<<<<
            newRow[ctCOL_GoodsName] = wkDTL.GoodsName;


            newRow[ctCOL_WarehouseCode] = wkDTL.WarehouseCode;
            newRow[ctCOL_WarehouseName] = wkDTL.WarehouseName;

            // 2008.02.15 修正 >>>>>>>>>>>>>>>>>>>>
            //if (GetEditMode() == 1)
            //{
            //    //受託調整は単価０
            //    newRow[ctCOL_StockUnitPrice] = 0;
            //    newRow[ctCOL_BfStockUnitPrice] = 0;
            //}
            //else
            //{
            //    // 2007.10.11 修正 >>>>>>>>>>>>>>>>>>>>
            //    //newRow[ctCOL_StockUnitPrice] = wkDTL.StockUnitPrice;
            //    //newRow[ctCOL_BfStockUnitPrice] = wkDTL.StockUnitPrice;
            //    newRow[ctCOL_StockUnitPrice] = wkDTL.StockUnitPriceFl;
            //    newRow[ctCOL_BfStockUnitPrice] = wkDTL.StockUnitPriceFl;
            //    // 2007.10.11 修正 <<<<<<<<<<<<<<<<<<<<
            //}
            newRow[ctCOL_StockUnitPrice] = wkDTL.StockUnitPriceFl;
            newRow[ctCOL_BfStockUnitPrice] = wkDTL.StockUnitPriceFl;
            // 2008.02.15 修正 <<<<<<<<<<<<<<<<<<<<
            // 2007.10.11 修正 >>>>>>>>>>>>>>>>>>>>
            //// 仕入在庫数 = 仕入在庫数 - 仕入委託 - 移動仕入
            //newRow[ctCOL_SupplierStock] = wkDTL.SupplierStock - wkDTL.EntrustCnt - wkDTL.MovingSupliStock;
            //// 受託在庫数 = 受託在庫数 - 受託委託 - 移動受託
            //newRow[ctCOL_TrustCount] = wkDTL.TrustCount - wkDTL.TrustEntrustCnt - wkDTL.MovingTrustStock;
            // 仕入在庫数 = 仕入在庫数 - 仕入委託 - 移動仕入
            newRow[ctCOL_SupplierStock] = wkDTL.SupplierStock - wkDTL.EntrustCnt - wkDTL.MovingSupliStock;
            // 受託在庫数 = 受託在庫数 - 移動受託
            newRow[ctCOL_TrustCount] = wkDTL.TrustCount - wkDTL.MovingTrustStock;
            // 2007.10.11 修正 <<<<<<<<<<<<<<<<<<<<

            // 2007.10.11 修正 >>>>>>>>>>>>>>>>>>>>
            //newRow[ctCOL_CellphoneModelCode] = wkDTL.CellphoneModelCode;
            //newRow[ctCOL_CellphoneModelName] = wkDTL.CellphoneModelName;
            //newRow[ctCOL_CarrierCode] = wkDTL.CarrierCode;
            //newRow[ctCOL_CarrierName] = wkDTL.CarrierName;
            //newRow[ctCOL_MakerName] = wkDTL.MakerName;
            //newRow[ctCOL_SystematicColorCd] = wkDTL.SystematicColorCd;
            //newRow[ctCOL_SystematicColorNm] = wkDTL.SystematicColorNm;
            //newRow[ctCOL_LargeGoodsGanreCode] = wkDTL.LargeGoodsGanreCode;
            //newRow[ctCOL_MediumGoodsGanreCode] = wkDTL.MediumGoodsGanreCode;
            //newRow[ctCOL_PrdNumMngDiv] = wkDTL.PrdNumMngDiv;

            newRow[ctCOL_MakerName] = wkDTL.MakerName;
            newRow[ctCOL_LargeGoodsGanreCode] = wkDTL.LargeGoodsGanreCode;
            newRow[ctCOL_MediumGoodsGanreCode] = wkDTL.MediumGoodsGanreCode;
            newRow[ctCOL_DetailGoodsGanreCode] = wkDTL.DetailGoodsGanreCode;
            newRow[ctCOL_WarehouseShelfNo] = wkDTL.WarehouseShelfNo;
            newRow[ctCOL_BfWarehouseShelfNo] = wkDTL.WarehouseShelfNo;
            newRow[ctCOL_BLGoodsCode] = wkDTL.BLGoodsCode;
            // 2007.10.11 修正 <<<<<<<<<<<<<<<<<<<<
            // 2008.02.15 修正 >>>>>>>>>>>>>>>>>>>>
            //if (GetEditMode() == 1)
            //{
            //    newRow[ctCOL_StockDiv] = 1;
            //}
            //else
            //{
            //    newRow[ctCOL_StockDiv] = 0;
            //}
            newRow[ctCOL_StockDiv] = 0;
            // 2008.02.15 修正 <<<<<<<<<<<<<<<<<<<<
            newRow[ctCOL_RowType] = 0; //在庫は必ず0
        }
           --- DEL 2008/07/24 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/07/24 Partsman用に変更

        // --- ADD 2008/07/24 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// 在庫情報反映処理
        /// </summary>
        /// <param name="newRow">新規行</param>
        /// <param name="stock">在庫マスタ</param>
        /// <param name="goodsUnitData">商品連結データ</param>
        /// <remarks>
        /// <br>Note       : 在庫情報を反映します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/07/24</br>
        /// </remarks>
        private void StockChangeRowGrs(ref DataRow newRow, Stock stock, GoodsUnitData goodsUnitData)
        {
            StockAdjust stockAdjust = new StockAdjust();
            StockAdjustDtl stockAdjustDtl = new StockAdjustDtl();

            // 在庫情報反映
            StockChangeRowGrs(ref newRow, stock, stockAdjust, stockAdjustDtl, goodsUnitData);
        }

        /// <summary>
        /// 在庫情報反映処理
        /// </summary>
        /// <param name="newRow">新規行</param>
        /// <param name="stock">在庫マスタ</param>
        /// <param name="goodsUnitData">商品連結データ</param>
        /// <remarks>
        /// <br>Note       : 在庫情報を反映します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/07/24</br>
        /// </remarks>
        private void StockChangeRowGrs(ref DataRow newRow, Stock stock, StockAdjust stockAdjust, StockAdjustDtl stockAdjustDtl, GoodsUnitData goodsUnitData)
        {
            this._goodsAcs.SettingGoodsUnitDataFromVariousMst(ref goodsUnitData);

            newRow[ctCOL_CreateDateTime] = stock.CreateDateTime;
            newRow[ctCOL_UpdateDateTime] = stock.UpdateDateTime;
            newRow[ctCOL_EnterpriseCode] = stock.EnterpriseCode;
            newRow[ctCOL_FileHeaderGuid] = stock.FileHeaderGuid;
            newRow[ctCOL_UpdEmployeeCode] = stock.UpdEmployeeCode;
            newRow[ctCOL_UpdAssemblyId1] = stock.UpdAssemblyId1;
            newRow[ctCOL_UpdAssemblyId2] = stock.UpdAssemblyId2;
            newRow[ctCOL_LogicalDeleteCode] = stock.LogicalDeleteCode;
            newRow[ctCOL_SectionCode] = stock.SectionCode;                          // 拠点コード

            // 在庫調整伝票番号
            newRow[ctCOL_StockAdjustSlipNo] = stockAdjust.StockAdjustSlipNo;
            // 在庫調整行番号

            // メーカーコード
            if (goodsUnitData.GoodsMakerCd == 0)
            {
                newRow[ctCOL_GoodsMakerCd] = "";
            }
            else
            {
                newRow[ctCOL_GoodsMakerCd] = goodsUnitData.GoodsMakerCd.ToString("0000");
            }
            newRow[ctCOL_GoodsNo] = goodsUnitData.GoodsNo;                          // 品番
            newRow[ctCOL_GoodsName] = goodsUnitData.GoodsName;                      // 品名
            if (stockAdjustDtl.AdjustCount == 0)
            {
                newRow[ctCOL_StockUnitPrice] = GetStockUnitPrice(stock, goodsUnitData); // 原単価(単価取得モジュールより取得)
                newRow[ctCOL_BfStockUnitPrice] = newRow[ctCOL_StockUnitPrice];          // 変更前原単価(単価取得モジュールより取得)
            }
            else
            {
                newRow[ctCOL_StockUnitPrice] = stockAdjustDtl.StockUnitPriceFl;         // 原単価
                newRow[ctCOL_BfStockUnitPrice] = stockAdjustDtl.StockUnitPriceFl;          // 変更前原単価
            }
            newRow[ctCOL_WarehouseCode] = stock.WarehouseCode;                      // 倉庫コード
            // BL商品コード
            if (goodsUnitData.BLGoodsCode == 0)
            {
                newRow[ctCOL_BLGoodsCode] = "";
            }
            else
            {
                newRow[ctCOL_BLGoodsCode] = goodsUnitData.BLGoodsCode.ToString("00000");                  
            }
            newRow[ctCOL_WarehouseShelfNo] = stock.WarehouseShelfNo;                // 倉庫棚番

            // 標準価格(価格マスタより取得)
            // オープン価格区分
            GoodsPrice goodsPrice = this._goodsAcs.GetGoodsPriceFromGoodsPriceList(GetDate(), goodsUnitData.GoodsPriceList);
            if (stockAdjustDtl.AdjustCount == 0)
            {
                if (goodsPrice == null)
                {
                    newRow[ctCOL_ListPriceFl] = 0;
                    newRow[ctCOL_OpenPriceDiv] = 0;
                }
                else
                {
                    newRow[ctCOL_ListPriceFl] = goodsPrice.ListPrice;
                    newRow[ctCOL_OpenPriceDiv] = goodsPrice.OpenPriceDiv;
                }
            }
            else
            {
                newRow[ctCOL_ListPriceFl] = stockAdjustDtl.ListPriceFl;
                newRow[ctCOL_OpenPriceDiv] = stockAdjustDtl.OpenPriceDiv;
            }

            // 仕入先
            if (goodsUnitData.SupplierCd == 0)
            {
                newRow[ctCOL_SupplierCd] = DBNull.Value;
                newRow[ctCOL_SupplierSnm] = "";
            }
            else
            {
                newRow[ctCOL_SupplierCd] = goodsUnitData.SupplierCd.ToString("000000");
                newRow[ctCOL_SupplierSnm] = goodsUnitData.SupplierSnm.Trim();
                stockAdjustDtl.SupplierCd = goodsUnitData.SupplierCd;
                stockAdjustDtl.SupplierSnm = goodsUnitData.SupplierSnm.Trim();
            }
            
            // 仕入数
            if (stockAdjustDtl.AdjustCount == 0)
            {
                newRow[ctCOL_SalesOrderUnit] = stock.SalesOrderUnit;
                newRow[ctCOL_BfSalesOrderUnit] = stock.SalesOrderUnit;                                
            }
            else
            {
                newRow[ctCOL_SalesOrderUnit] = stockAdjustDtl.AdjustCount;
                newRow[ctCOL_BfSalesOrderUnit] = stockAdjustDtl.AdjustCount;                          
            }
            //newRow[ctCOL_SupplierStock] = stock.ShipmentPosCnt;                                     // 仕入在庫数
            newRow[ctCOL_SupplierStock] = stock.ShipmentPosCnt - stockAdjustDtl.AdjustCount;                                     // 仕入在庫数
            //newRow[ctCOL_BfSupplierStock] = stock.ShipmentPosCnt;                                     // 変更前仕入在庫数
            newRow[ctCOL_BfSupplierStock] = stock.ShipmentPosCnt - stockAdjustDtl.AdjustCount;                                     // 変更前仕入在庫数
            //newRow[ctCOL_AfSalesOrderUnit] = stock.SalesOrderUnit + stock.ShipmentPosCnt;           // 仕入後数
            newRow[ctCOL_AfSalesOrderUnit] = stock.ShipmentPosCnt;           // 仕入後数
            newRow[ctCOL_SalesOrderCount] = stock.SalesOrderCount;                                  // 発注残

            // 仕入金額
            newRow[ctCOL_StockPriceTaxExc] = stockAdjustDtl.StockPriceTaxExc;

            newRow[ctCOL_Stock] = stock.Clone();                                                    // 在庫マスタ
            newRow[ctCOL_StockAdjust] = stockAdjust.Clone();                                        // 在庫調整データ
            newRow[ctCOL_StockAdjustDtl] = stockAdjustDtl.Clone();                                  // 在庫調整明細データ
            newRow[ctCOL_GoodsPrice] = goodsPrice;                                                  // 価格マスタ
            newRow[ctCOL_DtlNote] = stockAdjustDtl.DtlNote.Trim();                                  // 明細備考

            // 仕入形式
            newRow[ctCOL_SupplierFormalSrc] = stockAdjustDtl.SupplierFormalSrc;
            // 仕入明細通番
            newRow[ctCOL_StockSlipDtlNumSrc] = stockAdjustDtl.StockSlipDtlNumSrc;
        }

        /// <summary>
        /// 在庫情報反映処理
        /// </summary>
        /// <param name="newRow">新規行</param>
        /// <param name="stock">在庫マスタ</param>
        /// <param name="goodsUnitData">商品連結データ</param>
        /// <remarks>
        /// <br>Note       : 在庫情報を反映します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/07/24</br>
        /// </remarks>
        private void StockChangeRowGrs(ref DataRow newRow, Stock stock, GoodsUnitData goodsUnitData, OrderListResultWork orderListResultWork)
        {
            this._goodsAcs.SettingGoodsUnitDataFromVariousMst(ref goodsUnitData);

            newRow[ctCOL_CreateDateTime] = orderListResultWork.OrderDataCreateDate;
            newRow[ctCOL_UpdateDateTime] = stock.UpdateDateTime;
            newRow[ctCOL_EnterpriseCode] = stock.EnterpriseCode;
            newRow[ctCOL_FileHeaderGuid] = Guid.NewGuid();
            newRow[ctCOL_UpdEmployeeCode] = stock.UpdEmployeeCode;
            newRow[ctCOL_UpdAssemblyId1] = stock.UpdAssemblyId1;
            newRow[ctCOL_UpdAssemblyId2] = stock.UpdAssemblyId2;
            newRow[ctCOL_LogicalDeleteCode] = stock.LogicalDeleteCode;
            newRow[ctCOL_SectionCode] = stock.SectionCode;                          // 拠点コード

            //// 在庫調整伝票番号
            //newRow[ctCOL_StockAdjustSlipNo] = stockAdjust.StockAdjustSlipNo;
            // 在庫調整行番号

            // メーカーコード
            if (orderListResultWork.GoodsMakerCd == 0)
            {
                newRow[ctCOL_GoodsMakerCd] = "";
            }
            else
            {
                newRow[ctCOL_GoodsMakerCd] = orderListResultWork.GoodsMakerCd.ToString("0000");
            }
            newRow[ctCOL_GoodsNo] = orderListResultWork.GoodsNo;                            // 品番
            newRow[ctCOL_GoodsName] = orderListResultWork.GoodsName;                        // 品名
            newRow[ctCOL_StockUnitPrice] = orderListResultWork.StockUnitPriceFl;            // 原単価
            newRow[ctCOL_BfStockUnitPrice] = orderListResultWork.StockUnitPriceFl;          // 変更前原単価
            newRow[ctCOL_WarehouseCode] = orderListResultWork.WarehouseCode;                // 倉庫コード
            // BL商品コード
            if (orderListResultWork.BLGoodsCode == 0)
            {
                newRow[ctCOL_BLGoodsCode] = "";
            }
            else
            {
                newRow[ctCOL_BLGoodsCode] = orderListResultWork.BLGoodsCode.ToString("00000");                    
            }
            newRow[ctCOL_WarehouseShelfNo] = stock.WarehouseShelfNo;                        // 倉庫棚番
            newRow[ctCOL_ListPriceFl] = orderListResultWork.ListPriceTaxExcFl;              // 標準価格
            newRow[ctCOL_OpenPriceDiv] = 0;                                                 // オープン価格区分
            // 仕入先
            if (orderListResultWork.SupplierCd == 0)
            {
                newRow[ctCOL_SupplierCd] = DBNull.Value;
                newRow[ctCOL_SupplierSnm] = "";
            }
            else
            {
                newRow[ctCOL_SupplierCd] = orderListResultWork.SupplierCd.ToString("000000");
                newRow[ctCOL_SupplierSnm] = GetSupplierSnm(orderListResultWork.SupplierCd);
            }
            newRow[ctCOL_SalesOrderUnit] = orderListResultWork.OrderRemainCnt;                      // 仕入数
            newRow[ctCOL_BfSalesOrderUnit] = orderListResultWork.OrderRemainCnt;                      // 仕入数
            newRow[ctCOL_SupplierStock] = stock.ShipmentPosCnt;                                     // 在庫数
            newRow[ctCOL_BfSupplierStock] = stock.ShipmentPosCnt;                                     // 変更前在庫数
            newRow[ctCOL_AfSalesOrderUnit] = orderListResultWork.OrderRemainCnt + stock.ShipmentPosCnt; // 仕入後数
            newRow[ctCOL_SalesOrderCount] = stock.SalesOrderCount;                                  // 発注残
            //newRow[ctCOL_SalesOrderCount] = orderListResultWork.OrderRemainCnt;                     // 発注残

            // 仕入金額
            newRow[ctCOL_StockPriceTaxExc] = 0;

            newRow[ctCOL_Stock] = stock.Clone();                                                    // 在庫マスタ
            newRow[ctCOL_StockAdjust] = new StockAdjust();                                        // 在庫調整データ
            newRow[ctCOL_StockAdjustDtl] = new StockAdjustDtl();                                  // 在庫調整明細データ

            GoodsPrice goodsPrice = this._goodsAcs.GetGoodsPriceFromGoodsPriceList(GetDate(), goodsUnitData.GoodsPriceList);
            newRow[ctCOL_GoodsPrice] = goodsPrice;                                                  // 価格マスタ

            newRow[ctCOL_SupplierFormalSrc] = orderListResultWork.SupplierFormal;                   // 仕入形式
            newRow[ctCOL_StockSlipDtlNumSrc] = orderListResultWork.StockSlipDtlNum;                 // 仕入明細通番
            newRow[ctCOL_DtlNote] = orderListResultWork.StockDtiSlipNote1.Trim();                   // 明細備考
        }

        public int StringObjToInt(object strTarget)
        {
            if ((strTarget == DBNull.Value) || (strTarget == null) || (((string)strTarget).Trim() == ""))
            {
                return 0;
            }

            return int.Parse((string)strTarget);
        }

        public string StringObjToString(object strTarget)
        {
            if ((strTarget == DBNull.Value) || (strTarget == null) || (((string)strTarget).Trim() == ""))
            {
                return "";
            }

            return ((string)strTarget).Trim();
        }

        /// <summary>
        /// 仕入後数設定処理
        /// </summary>
        /// <param name="makerCode">メーカーコード</param>
        /// <param name="goodsNo">品番</param>
        /// <remarks>
        /// <br>Note       : 仕入後数を設定します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/07/24</br>
        /// </remarks>
        public void SetAfSalesOrderUnit(int makerCode, string goodsNo)
        {
            // 仕入数
            double salesOrderUnit = 0;
            double supplierStock = 0;
            double bfSupplierStock = 0;

            bool firstFlg = true;

            for (int index = 0; index < _mainProductStock.Rows.Count; index++)
            {
                if ((_mainProductStock.Rows[index][ctCOL_FileHeaderGuid] == DBNull.Value) ||
                    ((Guid)_mainProductStock.Rows[index][ctCOL_FileHeaderGuid] == Guid.Empty))
                {
                    continue;
                }

                // 同一の在庫情報が存在する場合
                if ((makerCode == StringObjToInt(_mainProductStock.Rows[index][ctCOL_GoodsMakerCd])) &&
                    (goodsNo == (string)_mainProductStock.Rows[index][ctCOL_GoodsNo]) &&
                    (_mainProductStock.Rows[index][ctCOL_SalesOrderUnit] != DBNull.Value))
                {
                    if (firstFlg == true)
                    {
                        firstFlg = false;

                        // 変更前在庫数取得
                        if (_mainProductStock.Rows[index][ctCOL_BfSupplierStock] != DBNull.Value)
                        {
                            bfSupplierStock = (double)_mainProductStock.Rows[index][ctCOL_BfSupplierStock];
                        }

                        // 同一の在庫情報の在庫数を設定
                        _mainProductStock.Rows[index][ctCOL_SupplierStock] = bfSupplierStock;
                    }
                    else
                    {
                        // 同一の在庫情報の在庫数を設定
                        _mainProductStock.Rows[index][ctCOL_SupplierStock] = salesOrderUnit + supplierStock;
                    }

                    // 仕入数取得
                    salesOrderUnit = (double)_mainProductStock.Rows[index][ctCOL_SalesOrderUnit];

                    // 在庫数取得
                    if (_mainProductStock.Rows[index][ctCOL_SupplierStock] != DBNull.Value)
                    {
                        supplierStock = (double)_mainProductStock.Rows[index][ctCOL_SupplierStock];
                    }

                    // 同一の在庫情報の仕入後数を設定
                    _mainProductStock.Rows[index][ctCOL_AfSalesOrderUnit] = salesOrderUnit + supplierStock;
                }
            }
        }
        // --- ADD 2008/07/24 ---------------------------------------------------------------------<<<<<

        #region 2007.10.11 削除
        // 2007.10.11 削除 >>>>>>>>>>>>>>>>>>>>
        #region 製番在庫データ変換処理(ワーク→StaticTable)
        /*
		/// <summary>
		/// 製番在庫データ変換処理(ワーク→StaticTable)
		/// </summary>
		/// <param name="sauceList"></param>
		private static void ProductStockWorkToDataRow(ArrayList sauceList)
		{
			// 変更イベント無効
			DeactivateDtlChangeEventHandler();

			try
			{
				// 現在のデータ行をクリアする
				_mainProductStock.Rows.Clear();

				if (sauceList != null)
				{
					// 製番在庫ワークよりデータ行を作成する
					foreach (ProductStockWork wkDtl in sauceList)
					{
						// DataRowをDataTableへ設定する
						_mainProductStock.Rows.Add(SlipDtlWorkToDataRow(wkDtl));
					}
				}

				// 初期明細行数の決定
				maxRowCnt = ctCOUNT_RowInit;
				while (maxRowCnt < _mainProductStock.Rows.Count)
				{
					maxRowCnt += ctCOUNT_RowAdd;
				}

				// 明細最大行数に満たない分を生成する
				string msg;
				CreateDummySlipDtl(out msg);
			}
			finally
			{
				// 変更イベント有効
				ActivateDtlChangeEventHandler();
			}
		}
        */
        #endregion
        // 2007.10.11 削除 <<<<<<<<<<<<<<<<<<<<
        #endregion

        #region 2007.10.11 削除
        // 2007.10.11 削除 >>>>>>>>>>>>>>>>>>>>
        #region 製番在庫データ変換処理(UIデータ→DataRow)
        /*
		/// <summary>
		/// 製番在庫データ変換処理(UIデータ→DataRow)
		/// </summary>
		/// <param name="productStock"></param>
		private static DataRow ProductStockToDataRow(ProductStock productStock)
		{
			return ProductStockToDataRow(productStock, null);
		}

		/// <summary>
		/// 製番在庫データ変換処理(UIデータ→DataRow)[DataRow指定版]
		/// </summary>
		/// <param name="productStock"></param>
		/// <param name="dataRow"></param>
		private static DataRow ProductStockToDataRow(ProductStock productStock, DataRow dataRow)
		{
			if (dataRow == null) dataRow = _mainProductStock.NewRow();

			try
			{
				// 論理削削除区分
				if ((dataRow[ctCOL_LogicalDeleteCode] == DBNull.Value) || ((Int32)dataRow[ctCOL_LogicalDeleteCode] != productStock.LogicalDeleteCode))
					dataRow[ctCOL_LogicalDeleteCode] = productStock.LogicalDeleteCode;
				dataRow.EndEdit();

				// 作成日時
				if ((dataRow[ctCOL_CreateDateTime] == DBNull.Value) || ((DateTime)dataRow[ctCOL_CreateDateTime] != productStock.CreateDateTime))
					dataRow[ctCOL_CreateDateTime] = productStock.CreateDateTime;
				// 更新日時
				if ((dataRow[ctCOL_UpdateDateTime] == DBNull.Value) || ((DateTime)dataRow[ctCOL_UpdateDateTime] != productStock.UpdateDateTime))
					dataRow[ctCOL_UpdateDateTime] = productStock.UpdateDateTime;
				// 企業コード
				if ((dataRow[ctCOL_EnterpriseCode] == DBNull.Value) || ((string)dataRow[ctCOL_EnterpriseCode] != productStock.EnterpriseCode))
					dataRow[ctCOL_EnterpriseCode] = productStock.EnterpriseCode;
				// GUID
				if ((dataRow[ctCOL_FileHeaderGuid] == DBNull.Value) || ((Guid)dataRow[ctCOL_FileHeaderGuid] != productStock.FileHeaderGuid))
					dataRow[ctCOL_FileHeaderGuid] = productStock.FileHeaderGuid;
				// 更新従業員コード
				if ((dataRow[ctCOL_UpdEmployeeCode] == DBNull.Value) || ((string)dataRow[ctCOL_UpdEmployeeCode] != productStock.UpdEmployeeCode))
					dataRow[ctCOL_UpdEmployeeCode] = productStock.UpdEmployeeCode;
				// 更新アセンブリID1
				if ((dataRow[ctCOL_UpdAssemblyId1] == DBNull.Value) || ((string)dataRow[ctCOL_UpdAssemblyId1] != productStock.UpdAssemblyId1))
					dataRow[ctCOL_UpdAssemblyId1] = productStock.UpdAssemblyId1;
				// 更新アセンブリID2
				if ((dataRow[ctCOL_UpdAssemblyId2] == DBNull.Value) || ((string)dataRow[ctCOL_UpdAssemblyId2] != productStock.UpdAssemblyId2))
					dataRow[ctCOL_UpdAssemblyId2] = productStock.UpdAssemblyId2;
                // 論理削除区分
                if ((dataRow[ctCOL_LogicalDeleteCode] == DBNull.Value) || ((Int32)dataRow[ctCOL_LogicalDeleteCode] != productStock.LogicalDeleteCode))
                    dataRow[ctCOL_LogicalDeleteCode] = productStock.LogicalDeleteCode;
                // 拠点コード
                if ((dataRow[ctCOL_SectionCode] == DBNull.Value) || ((string)dataRow[ctCOL_SectionCode] != productStock.SectionCode))
                    dataRow[ctCOL_SectionCode] = productStock.SectionCode;
                // メーカーコード
                if ((dataRow[ctCOL_MakerCode] == DBNull.Value) || ((Int32)dataRow[ctCOL_MakerCode] != productStock.MakerCode))
                    dataRow[ctCOL_MakerCode] = productStock.MakerCode;
                // 商品コード
                if ((dataRow[ctCOL_GoodsCode] == DBNull.Value) || ((string)dataRow[ctCOL_GoodsCode] != productStock.GoodsCode))
                    dataRow[ctCOL_GoodsCode] = productStock.GoodsCode;
                // 商品名称
                if ((dataRow[ctCOL_GoodsName] == DBNull.Value) || ((string)dataRow[ctCOL_GoodsName] != productStock.GoodsName))
                    dataRow[ctCOL_GoodsName] = productStock.GoodsName;
                // 製造番号
                if ((dataRow[ctCOL_ProductNumber] == DBNull.Value) || ((string)dataRow[ctCOL_ProductNumber] != productStock.ProductNumber))
                    dataRow[ctCOL_ProductNumber] = productStock.ProductNumber;
                // 製番在庫マスタGUID
                if ((dataRow[ctCOL_ProductStockGuid] == DBNull.Value) || ((Guid)dataRow[ctCOL_ProductStockGuid] != productStock.ProductStockGuid))
                    dataRow[ctCOL_ProductStockGuid] = productStock.ProductStockGuid;
                // 在庫区分
                if ((dataRow[ctCOL_StockDiv] == DBNull.Value) || ((Int32)dataRow[ctCOL_StockDiv] != productStock.StockDiv))
                    dataRow[ctCOL_StockDiv] = productStock.StockDiv;
                // 倉庫コード
                if ((dataRow[ctCOL_WarehouseCode] == DBNull.Value) || ((string)dataRow[ctCOL_WarehouseCode] != productStock.WarehouseCode))
                    dataRow[ctCOL_WarehouseCode] = productStock.WarehouseCode;
                // 倉庫名称
                if ((dataRow[ctCOL_WarehouseName] == DBNull.Value) || ((string)dataRow[ctCOL_WarehouseName] != productStock.WarehouseName))
                    dataRow[ctCOL_WarehouseName] = productStock.WarehouseName;
                // 事業者コード
                if ((dataRow[ctCOL_CarrierEpCode] == DBNull.Value) || ((Int32)dataRow[ctCOL_CarrierEpCode] != productStock.CarrierEpCode))
                    dataRow[ctCOL_CarrierEpCode] = productStock.CarrierEpCode;
                // 事業者名称
                if ((dataRow[ctCOL_CarrierEpName] == DBNull.Value) || ((string)dataRow[ctCOL_CarrierEpName] != productStock.CarrierEpName))
                    dataRow[ctCOL_CarrierEpName] = productStock.CarrierEpName;
                // 得意先コード
                if ((dataRow[ctCOL_CustomerCode] == DBNull.Value) || ((Int32)dataRow[ctCOL_CustomerCode] != productStock.CustomerCode))
                    dataRow[ctCOL_CustomerCode] = productStock.CustomerCode;
                // 得意先名称
                if ((dataRow[ctCOL_CustomerName] == DBNull.Value) || ((string)dataRow[ctCOL_CustomerName] != productStock.CustomerName))
                    dataRow[ctCOL_CustomerName] = productStock.CustomerName;
                // 得意先名称2
                if ((dataRow[ctCOL_CustomerName2] == DBNull.Value) || ((string)dataRow[ctCOL_CustomerName2] != productStock.CustomerName2))
                    dataRow[ctCOL_CustomerName2] = productStock.CustomerName2;
                // 仕入日
                if ((dataRow[ctCOL_StockDate] == DBNull.Value) || ((DateTime)dataRow[ctCOL_StockDate] != productStock.StockDate))
                    dataRow[ctCOL_StockDate] = productStock.StockDate;
                // 入荷日
                if ((dataRow[ctCOL_ArrivalGoodsDay] == DBNull.Value) || ((DateTime)dataRow[ctCOL_ArrivalGoodsDay] != productStock.ArrivalGoodsDay))
                    dataRow[ctCOL_ArrivalGoodsDay] = productStock.ArrivalGoodsDay;
                int stockPointWay = GetStockPointWay();
                if ((stockPointWay == (int)ConstantManagement_Mobile.ct_StockPointWay.Average) ||
                    (stockPointWay == (int)ConstantManagement_Mobile.ct_StockPointWay.Last))
                {
                    //移動平均法=>在庫マスタの仕入単価が全体設定(在庫マスタ参照)
                    Stock chkStock = new Stock();
                    //在庫情報呼出
                    int mode = GetEditMode();
                    string goodsCode = (string)dataRow[ctCOL_GoodsCode];
                    if (!String.IsNullOrEmpty(goodsCode))
                    {
                        GetStockInf(out chkStock, goodsCode, (Int32)dataRow[ctCOL_MakerCode], mode);
                    }
                    
                    dataRow[ctCOL_StockUnitPrice] = chkStock.StockUnitPrice;
                }
                else
                {
                    // 仕入単価
                    if ((dataRow[ctCOL_StockUnitPrice] == DBNull.Value) || ((Int64)dataRow[ctCOL_StockUnitPrice] != productStock.StockUnitPrice))
                        dataRow[ctCOL_StockUnitPrice] = productStock.StockUnitPrice;
                }

                // 課税区分
                if ((dataRow[ctCOL_TaxationCode] == DBNull.Value) || ((Int32)dataRow[ctCOL_TaxationCode] != productStock.TaxationCode))
                    dataRow[ctCOL_TaxationCode] = productStock.TaxationCode;
                // 在庫状態
                if ((dataRow[ctCOL_StockState] == DBNull.Value) || ((Int32)dataRow[ctCOL_StockState] != productStock.StockState))
                    dataRow[ctCOL_StockState] = productStock.StockState;
                // 移動状態
                if ((dataRow[ctCOL_MoveStatus] == DBNull.Value) || ((Int32)dataRow[ctCOL_MoveStatus] != productStock.MoveStatus))
                    dataRow[ctCOL_MoveStatus] = productStock.MoveStatus;
                // 商品状態
                if ((dataRow[ctCOL_GoodsCodeStatus] == DBNull.Value) || ((Int32)dataRow[ctCOL_GoodsCodeStatus] != productStock.GoodsCodeStatus))
                    dataRow[ctCOL_GoodsCodeStatus] = productStock.GoodsCodeStatus;
                // 修正前商品状態
                if ((dataRow[ctCOL_BfGoodsCodeStatus] == DBNull.Value) || ((Int32)dataRow[ctCOL_BfGoodsCodeStatus] != productStock.GoodsCodeStatus))
                    dataRow[ctCOL_BfGoodsCodeStatus] = productStock.GoodsCodeStatus;
                // 商品電話番号1
                if ((dataRow[ctCOL_StockTelNo1] == DBNull.Value) || ((string)dataRow[ctCOL_StockTelNo1] != productStock.StockTelNo1))
                    dataRow[ctCOL_StockTelNo1] = productStock.StockTelNo1;
                // 商品電話番号2
                if ((dataRow[ctCOL_StockTelNo2] == DBNull.Value) || ((string)dataRow[ctCOL_StockTelNo2] != productStock.StockTelNo2))
                    dataRow[ctCOL_StockTelNo2] = productStock.StockTelNo2;
                // ロム区分
                if ((dataRow[ctCOL_RomDiv] == DBNull.Value) || ((Int32)dataRow[ctCOL_RomDiv] != productStock.RomDiv))
                    dataRow[ctCOL_RomDiv] = productStock.RomDiv;
                // 機種コード
                if ((dataRow[ctCOL_CellphoneModelCode] == DBNull.Value) || ((string)dataRow[ctCOL_CellphoneModelCode] != productStock.CellphoneModelCode))
                    dataRow[ctCOL_CellphoneModelCode] = productStock.CellphoneModelCode;
                // 機種名称
                if ((dataRow[ctCOL_CellphoneModelName] == DBNull.Value) || ((string)dataRow[ctCOL_CellphoneModelName] != productStock.CellphoneModelName))
                    dataRow[ctCOL_CellphoneModelName] = productStock.CellphoneModelName;
                // キャリアコード
                if ((dataRow[ctCOL_CarrierCode] == DBNull.Value) || ((Int32)dataRow[ctCOL_CarrierCode] != productStock.CarrierCode))
                    dataRow[ctCOL_CarrierCode] = productStock.CarrierCode;
                // キャリア名称
                if ((dataRow[ctCOL_CarrierName] == DBNull.Value) || ((string)dataRow[ctCOL_CarrierName] != productStock.CarrierName))
                    dataRow[ctCOL_CarrierName] = productStock.CarrierName;
                // メーカー名称
                if ((dataRow[ctCOL_MakerName] == DBNull.Value) || ((string)dataRow[ctCOL_MakerName] != productStock.MakerName))
                    dataRow[ctCOL_MakerName] = productStock.MakerName;
                // 系統色コード
                if ((dataRow[ctCOL_SystematicColorCd] == DBNull.Value) || ((Int32)dataRow[ctCOL_SystematicColorCd] != productStock.SystematicColorCd))
                    dataRow[ctCOL_SystematicColorCd] = productStock.SystematicColorCd;
                // 系統色名称
                if ((dataRow[ctCOL_SystematicColorNm] == DBNull.Value) || ((string)dataRow[ctCOL_SystematicColorNm] != productStock.SystematicColorNm))
                    dataRow[ctCOL_SystematicColorNm] = productStock.SystematicColorNm;
                // 商品大分類コード
                if ((dataRow[ctCOL_LargeGoodsGanreCode] == DBNull.Value) || ((string)dataRow[ctCOL_LargeGoodsGanreCode] != productStock.LargeGoodsGanreCode))
                    dataRow[ctCOL_LargeGoodsGanreCode] = productStock.LargeGoodsGanreCode;
                // 商品中分類コード
                if ((dataRow[ctCOL_MediumGoodsGanreCode] == DBNull.Value) || ((string)dataRow[ctCOL_MediumGoodsGanreCode] != productStock.MediumGoodsGanreCode))
                    dataRow[ctCOL_MediumGoodsGanreCode] = productStock.MediumGoodsGanreCode;
                // 出荷先得意先コード
                if ((dataRow[ctCOL_ShipCustomerCode] == DBNull.Value) || ((Int32)dataRow[ctCOL_ShipCustomerCode] != productStock.ShipCustomerCode))
                    dataRow[ctCOL_ShipCustomerCode] = productStock.ShipCustomerCode;
                // 出荷先得意先名称
                if ((dataRow[ctCOL_ShipCustomerName] == DBNull.Value) || ((string)dataRow[ctCOL_ShipCustomerName] != productStock.ShipCustomerName))
                    dataRow[ctCOL_ShipCustomerName] = productStock.ShipCustomerName;
                // 出荷先得意先名称2
                if ((dataRow[ctCOL_ShipCustomerName2] == DBNull.Value) || ((string)dataRow[ctCOL_ShipCustomerName2] != productStock.ShipCustomerName2))
                    dataRow[ctCOL_ShipCustomerName2] = productStock.ShipCustomerName2;

                // 行No付加
                if (dataRow[ctCOL_RowNum] == DBNull.Value)
                    dataRow[ctCOL_RowNum] = mainAdjustStockDtlFullView.Count + 1;


				// 編集を行に反映
				dataRow.EndEdit();
			}
			finally
			{
			}

			return dataRow;
		}
        */
        #endregion
        // 2007.10.11 削除 <<<<<<<<<<<<<<<<<<<<
        #endregion

        #region 2007.10.11 削除
        // 2007.10.11 削除 >>>>>>>>>>>>>>>>>>>>
        #region 製番在庫データ変換処理(ワーク→DataRow)
        /*
        /// <summary>
		/// 製番在庫データ変換処理(ワーク→DataRow)
		/// </summary>
		/// <param name="productStockWork"></param>
		private static DataRow SlipDtlWorkToDataRow(ProductStockWork productStockWork)
		{
			return SlipDtlWorkToDataRow(productStockWork, null);
		}

		/// <summary>
		/// 製番在庫データ変換処理(ワーク→DataRow)[DataRow指定版]
		/// </summary>
		/// <param name="productStockWork"></param>
		/// <param name="dataRow"></param>
		private static DataRow SlipDtlWorkToDataRow(ProductStockWork productStockWork, DataRow dataRow)
		{
			if (dataRow == null) dataRow = _mainProductStock.NewRow();

			try
			{
				// 作成日時
				if ((dataRow[ctCOL_CreateDateTime] == DBNull.Value) || ((DateTime)dataRow[ctCOL_CreateDateTime] != productStockWork.CreateDateTime))
					dataRow[ctCOL_CreateDateTime] = productStockWork.CreateDateTime;
				// 更新日時
				if ((dataRow[ctCOL_UpdateDateTime] == DBNull.Value) || ((DateTime)dataRow[ctCOL_UpdateDateTime] != productStockWork.UpdateDateTime))
					dataRow[ctCOL_UpdateDateTime] = productStockWork.UpdateDateTime;
				// 企業コード
				if ((dataRow[ctCOL_EnterpriseCode] == DBNull.Value) || ((string)dataRow[ctCOL_EnterpriseCode] != productStockWork.EnterpriseCode))
					dataRow[ctCOL_EnterpriseCode] = productStockWork.EnterpriseCode;
				// GUID
				if ((dataRow[ctCOL_FileHeaderGuid] == DBNull.Value) || ((Guid)dataRow[ctCOL_FileHeaderGuid] != productStockWork.FileHeaderGuid))
					dataRow[ctCOL_FileHeaderGuid] = productStockWork.FileHeaderGuid;
				// 更新従業員コード
				if ((dataRow[ctCOL_UpdEmployeeCode] == DBNull.Value) || ((string)dataRow[ctCOL_UpdEmployeeCode] != productStockWork.UpdEmployeeCode))
					dataRow[ctCOL_UpdEmployeeCode] = productStockWork.UpdEmployeeCode;
				// 更新アセンブリID1
				if ((dataRow[ctCOL_UpdAssemblyId1] == DBNull.Value) || ((string)dataRow[ctCOL_UpdAssemblyId1] != productStockWork.UpdAssemblyId1))
					dataRow[ctCOL_UpdAssemblyId1] = productStockWork.UpdAssemblyId1;
				// 更新アセンブリID2
				if ((dataRow[ctCOL_UpdAssemblyId2] == DBNull.Value) || ((string)dataRow[ctCOL_UpdAssemblyId2] != productStockWork.UpdAssemblyId2))
					dataRow[ctCOL_UpdAssemblyId2] = productStockWork.UpdAssemblyId2;
				// 論理削削除区分
				if ((dataRow[ctCOL_LogicalDeleteCode] == DBNull.Value) || ((Int32)dataRow[ctCOL_LogicalDeleteCode] != productStockWork.LogicalDeleteCode))
					dataRow[ctCOL_LogicalDeleteCode] = productStockWork.LogicalDeleteCode;
                // 拠点コード
                if ((dataRow[ctCOL_SectionCode] == DBNull.Value) || ((string)dataRow[ctCOL_SectionCode] != productStockWork.SectionCode))
                    dataRow[ctCOL_SectionCode] = productStockWork.SectionCode;
                // メーカーコード
                if ((dataRow[ctCOL_MakerCode] == DBNull.Value) || ((Int32)dataRow[ctCOL_MakerCode] != productStockWork.MakerCode))
                    dataRow[ctCOL_MakerCode] = productStockWork.MakerCode;
                // 商品コード
                if ((dataRow[ctCOL_GoodsCode] == DBNull.Value) || ((string)dataRow[ctCOL_GoodsCode] != productStockWork.GoodsCode))
                    dataRow[ctCOL_GoodsCode] = productStockWork.GoodsCode;
                // 商品名称
                if ((dataRow[ctCOL_GoodsName] == DBNull.Value) || ((string)dataRow[ctCOL_GoodsName] != productStockWork.GoodsName))
                    dataRow[ctCOL_GoodsName] = productStockWork.GoodsName;
                // 製造番号
                if ((dataRow[ctCOL_ProductNumber] == DBNull.Value) || ((string)dataRow[ctCOL_ProductNumber] != productStockWork.ProductNumber))
                    dataRow[ctCOL_ProductNumber] = productStockWork.ProductNumber;
                // 製番在庫マスタGUID
                if ((dataRow[ctCOL_ProductStockGuid] == DBNull.Value) || ((Guid)dataRow[ctCOL_ProductStockGuid] != productStockWork.ProductStockGuid))
                    dataRow[ctCOL_ProductStockGuid] = productStockWork.ProductStockGuid;
                // 在庫区分
                if ((dataRow[ctCOL_StockDiv] == DBNull.Value) || ((Int32)dataRow[ctCOL_StockDiv] != productStockWork.StockDiv))
                    dataRow[ctCOL_StockDiv] = productStockWork.StockDiv;
                // 倉庫コード
                if ((dataRow[ctCOL_WarehouseCode] == DBNull.Value) || ((string)dataRow[ctCOL_WarehouseCode] != productStockWork.WarehouseCode))
                    dataRow[ctCOL_WarehouseCode] = productStockWork.WarehouseCode;
                // 倉庫名称
                if ((dataRow[ctCOL_WarehouseName] == DBNull.Value) || ((string)dataRow[ctCOL_WarehouseName] != productStockWork.WarehouseName))
                    dataRow[ctCOL_WarehouseName] = productStockWork.WarehouseName;
                // 事業者コード
                if ((dataRow[ctCOL_CarrierEpCode] == DBNull.Value) || ((Int32)dataRow[ctCOL_CarrierEpCode] != productStockWork.CarrierEpCode))
                    dataRow[ctCOL_CarrierEpCode] = productStockWork.CarrierEpCode;
                // 事業者名称
                if ((dataRow[ctCOL_CarrierEpName] == DBNull.Value) || ((string)dataRow[ctCOL_CarrierEpName] != productStockWork.CarrierEpName))
                    dataRow[ctCOL_CarrierEpName] = productStockWork.CarrierEpName;
                // 得意先コード
                if ((dataRow[ctCOL_CustomerCode] == DBNull.Value) || ((Int32)dataRow[ctCOL_CustomerCode] != productStockWork.CustomerCode))
                    dataRow[ctCOL_CustomerCode] = productStockWork.CustomerCode;
                // 得意先名称
                if ((dataRow[ctCOL_CustomerName] == DBNull.Value) || ((string)dataRow[ctCOL_CustomerName] != productStockWork.CustomerName))
                    dataRow[ctCOL_CustomerName] = productStockWork.CustomerName;
                // 得意先名称2
                if ((dataRow[ctCOL_CustomerName2] == DBNull.Value) || ((string)dataRow[ctCOL_CustomerName2] != productStockWork.CustomerName2))
                    dataRow[ctCOL_CustomerName2] = productStockWork.CustomerName2;
                // 仕入日
                if ((dataRow[ctCOL_StockDate] == DBNull.Value) || ((DateTime)dataRow[ctCOL_StockDate] != productStockWork.StockDate))
                    dataRow[ctCOL_StockDate] = productStockWork.StockDate;
                // 入荷日
                if ((dataRow[ctCOL_ArrivalGoodsDay] == DBNull.Value) || ((DateTime)dataRow[ctCOL_ArrivalGoodsDay] != productStockWork.ArrivalGoodsDay))
                    dataRow[ctCOL_ArrivalGoodsDay] = productStockWork.ArrivalGoodsDay;
                // 仕入単価
                if ((dataRow[ctCOL_StockUnitPrice] == DBNull.Value) || ((Int64)dataRow[ctCOL_StockUnitPrice] != productStockWork.StockUnitPrice))
                    dataRow[ctCOL_StockUnitPrice] = productStockWork.StockUnitPrice;
                // 課税区分
                if ((dataRow[ctCOL_TaxationCode] == DBNull.Value) || ((Int32)dataRow[ctCOL_TaxationCode] != productStockWork.TaxationCode))
                    dataRow[ctCOL_TaxationCode] = productStockWork.TaxationCode;
                // 在庫状態
                if ((dataRow[ctCOL_StockState] == DBNull.Value) || ((Int32)dataRow[ctCOL_StockState] != productStockWork.StockState))
                    dataRow[ctCOL_StockState] = productStockWork.StockState;
                // 移動状態
                if ((dataRow[ctCOL_MoveStatus] == DBNull.Value) || ((Int32)dataRow[ctCOL_MoveStatus] != productStockWork.MoveStatus))
                    dataRow[ctCOL_MoveStatus] = productStockWork.MoveStatus;
                // 商品状態
                if ((dataRow[ctCOL_GoodsCodeStatus] == DBNull.Value) || ((Int32)dataRow[ctCOL_GoodsCodeStatus] != productStockWork.GoodsCodeStatus))
                    dataRow[ctCOL_GoodsCodeStatus] = productStockWork.GoodsCodeStatus;
                // 修正前商品状態
                if ((dataRow[ctCOL_GoodsCodeStatus] == DBNull.Value) || ((Int32)dataRow[ctCOL_GoodsCodeStatus] != productStockWork.GoodsCodeStatus))
                    dataRow[ctCOL_BfGoodsCodeStatus] = productStockWork.GoodsCodeStatus;
                // 商品電話番号1
                if ((dataRow[ctCOL_StockTelNo1] == DBNull.Value) || ((string)dataRow[ctCOL_StockTelNo1] != productStockWork.StockTelNo1))
                    dataRow[ctCOL_StockTelNo1] = productStockWork.StockTelNo1;
                // 商品電話番号2
                if ((dataRow[ctCOL_StockTelNo2] == DBNull.Value) || ((string)dataRow[ctCOL_StockTelNo2] != productStockWork.StockTelNo2))
                    dataRow[ctCOL_StockTelNo2] = productStockWork.StockTelNo2;
                // ロム区分
                if ((dataRow[ctCOL_RomDiv] == DBNull.Value) || ((Int32)dataRow[ctCOL_RomDiv] != productStockWork.RomDiv))
                    dataRow[ctCOL_RomDiv] = productStockWork.RomDiv;
                // 機種コード
                if ((dataRow[ctCOL_CellphoneModelCode] == DBNull.Value) || ((string)dataRow[ctCOL_CellphoneModelCode] != productStockWork.CellphoneModelCode))
                    dataRow[ctCOL_CellphoneModelCode] = productStockWork.CellphoneModelCode;
                // 機種名称
                if ((dataRow[ctCOL_CellphoneModelName] == DBNull.Value) || ((string)dataRow[ctCOL_CellphoneModelName] != productStockWork.CellphoneModelName))
                    dataRow[ctCOL_CellphoneModelName] = productStockWork.CellphoneModelName;
                // キャリアコード
                if ((dataRow[ctCOL_CarrierCode] == DBNull.Value) || ((Int32)dataRow[ctCOL_CarrierCode] != productStockWork.CarrierCode))
                    dataRow[ctCOL_CarrierCode] = productStockWork.CarrierCode;
                // キャリア名称
                if ((dataRow[ctCOL_CarrierName] == DBNull.Value) || ((string)dataRow[ctCOL_CarrierName] != productStockWork.CarrierName))
                    dataRow[ctCOL_CarrierName] = productStockWork.CarrierName;
                // メーカー名称
                if ((dataRow[ctCOL_MakerName] == DBNull.Value) || ((string)dataRow[ctCOL_MakerName] != productStockWork.MakerName))
                    dataRow[ctCOL_MakerName] = productStockWork.MakerName;
                // 系統色コード
                if ((dataRow[ctCOL_SystematicColorCd] == DBNull.Value) || ((Int32)dataRow[ctCOL_SystematicColorCd] != productStockWork.SystematicColorCd))
                    dataRow[ctCOL_SystematicColorCd] = productStockWork.SystematicColorCd;
                // 系統色名称
                if ((dataRow[ctCOL_SystematicColorNm] == DBNull.Value) || ((string)dataRow[ctCOL_SystematicColorNm] != productStockWork.SystematicColorNm))
                    dataRow[ctCOL_SystematicColorNm] = productStockWork.SystematicColorNm;
                // 商品大分類コード
                if ((dataRow[ctCOL_LargeGoodsGanreCode] == DBNull.Value) || ((string)dataRow[ctCOL_LargeGoodsGanreCode] != productStockWork.LargeGoodsGanreCode))
                    dataRow[ctCOL_LargeGoodsGanreCode] = productStockWork.LargeGoodsGanreCode;
                // 商品中分類コード
                if ((dataRow[ctCOL_MediumGoodsGanreCode] == DBNull.Value) || ((string)dataRow[ctCOL_MediumGoodsGanreCode] != productStockWork.MediumGoodsGanreCode))
                    dataRow[ctCOL_MediumGoodsGanreCode] = productStockWork.MediumGoodsGanreCode;
                // 出荷先得意先コード
                if ((dataRow[ctCOL_ShipCustomerCode] == DBNull.Value) || ((Int32)dataRow[ctCOL_ShipCustomerCode] != productStockWork.ShipCustomerCode))
                    dataRow[ctCOL_ShipCustomerCode] = productStockWork.ShipCustomerCode;
                // 出荷先得意先名称
                if ((dataRow[ctCOL_ShipCustomerName] == DBNull.Value) || ((string)dataRow[ctCOL_ShipCustomerName] != productStockWork.ShipCustomerName))
                    dataRow[ctCOL_ShipCustomerName] = productStockWork.ShipCustomerName;
                // 出荷先得意先名称2
                if ((dataRow[ctCOL_ShipCustomerName2] == DBNull.Value) || ((string)dataRow[ctCOL_ShipCustomerName2] != productStockWork.ShipCustomerName2))
                    dataRow[ctCOL_ShipCustomerName2] = productStockWork.ShipCustomerName2;
            }
			finally
			{
			}

			return dataRow;
		}
        */
        #endregion
        // 2007.10.11 削除 <<<<<<<<<<<<<<<<<<<<
        #endregion

        #region DEL 2008/07/24 Partsman用に変更
        /* --- DEL 2008/07/24 --------------------------------------------------------------------->>>>>
        // 2007.10.11 追加 >>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// 在庫データ変換処理(UIデータ→DataRow)[DataRow指定版]
        /// </summary>
        /// <param name="productStock"></param>
        /// <param name="dataRow"></param>
        private static DataRow StockToDataRow(StockExpansion stockExpansion, DataRow dataRow)
        {
            if (dataRow == null) dataRow = _mainProductStock.NewRow();

            try
            {
                // 論理削削除区分
                if ((dataRow[ctCOL_LogicalDeleteCode] == DBNull.Value) || ((Int32)dataRow[ctCOL_LogicalDeleteCode] != stockExpansion.LogicalDeleteCode))
                    dataRow[ctCOL_LogicalDeleteCode] = stockExpansion.LogicalDeleteCode;
                dataRow.EndEdit();

                // 作成日時
                if ((dataRow[ctCOL_CreateDateTime] == DBNull.Value) || ((DateTime)dataRow[ctCOL_CreateDateTime] != stockExpansion.CreateDateTime))
                    dataRow[ctCOL_CreateDateTime] = stockExpansion.CreateDateTime;
                // 更新日時
                if ((dataRow[ctCOL_UpdateDateTime] == DBNull.Value) || ((DateTime)dataRow[ctCOL_UpdateDateTime] != stockExpansion.UpdateDateTime))
                    dataRow[ctCOL_UpdateDateTime] = stockExpansion.UpdateDateTime;
                // 企業コード
                if ((dataRow[ctCOL_EnterpriseCode] == DBNull.Value) || ((string)dataRow[ctCOL_EnterpriseCode] != stockExpansion.EnterpriseCode))
                    dataRow[ctCOL_EnterpriseCode] = stockExpansion.EnterpriseCode;
                // GUID
                if ((dataRow[ctCOL_FileHeaderGuid] == DBNull.Value) || ((Guid)dataRow[ctCOL_FileHeaderGuid] != stockExpansion.FileHeaderGuid))
                    dataRow[ctCOL_FileHeaderGuid] = stockExpansion.FileHeaderGuid;
                // 更新従業員コード
                if ((dataRow[ctCOL_UpdEmployeeCode] == DBNull.Value) || ((string)dataRow[ctCOL_UpdEmployeeCode] != stockExpansion.UpdEmployeeCode))
                    dataRow[ctCOL_UpdEmployeeCode] = stockExpansion.UpdEmployeeCode;
                // 更新アセンブリID1
                if ((dataRow[ctCOL_UpdAssemblyId1] == DBNull.Value) || ((string)dataRow[ctCOL_UpdAssemblyId1] != stockExpansion.UpdAssemblyId1))
                    dataRow[ctCOL_UpdAssemblyId1] = stockExpansion.UpdAssemblyId1;
                // 更新アセンブリID2
                if ((dataRow[ctCOL_UpdAssemblyId2] == DBNull.Value) || ((string)dataRow[ctCOL_UpdAssemblyId2] != stockExpansion.UpdAssemblyId2))
                    dataRow[ctCOL_UpdAssemblyId2] = stockExpansion.UpdAssemblyId2;
                // 論理削除区分
                if ((dataRow[ctCOL_LogicalDeleteCode] == DBNull.Value) || ((Int32)dataRow[ctCOL_LogicalDeleteCode] != stockExpansion.LogicalDeleteCode))
                    dataRow[ctCOL_LogicalDeleteCode] = stockExpansion.LogicalDeleteCode;
                // 拠点コード
                if ((dataRow[ctCOL_SectionCode] == DBNull.Value) || ((string)dataRow[ctCOL_SectionCode] != stockExpansion.SectionCode))
                    dataRow[ctCOL_SectionCode] = stockExpansion.SectionCode;
                // メーカーコード
                //if ((dataRow[ctCOL_GoodsMakerCd] == DBNull.Value) || ((Int32)dataRow[ctCOL_GoodsMakerCd] != stockExpansion.GoodsMakerCd))
                //    dataRow[ctCOL_GoodsMakerCd] = stockExpansion.GoodsMakerCd;
                // 商品コード
                if ((dataRow[ctCOL_GoodsNo] == DBNull.Value) || ((string)dataRow[ctCOL_GoodsNo] != stockExpansion.GoodsNo))
                    dataRow[ctCOL_GoodsNo] = stockExpansion.GoodsNo;
                // 商品名称
                if ((dataRow[ctCOL_GoodsName] == DBNull.Value) || ((string)dataRow[ctCOL_GoodsName] != stockExpansion.GoodsName))
                    dataRow[ctCOL_GoodsName] = stockExpansion.GoodsName;
                // 倉庫コード
                if ((dataRow[ctCOL_WarehouseCode] == DBNull.Value) || ((string)dataRow[ctCOL_WarehouseCode] != stockExpansion.WarehouseCode))
                    dataRow[ctCOL_WarehouseCode] = stockExpansion.WarehouseCode;
                // 倉庫名称
                if ((dataRow[ctCOL_WarehouseName] == DBNull.Value) || ((string)dataRow[ctCOL_WarehouseName] != stockExpansion.WarehouseName))
                    dataRow[ctCOL_WarehouseName] = stockExpansion.WarehouseName;
//                // 仕入先コード
//                if ((dataRow[ctCOL_CustomerCode] == DBNull.Value) || ((Int32)dataRow[ctCOL_CustomerCode] != stockExpansion.CustomerCode))
//                    dataRow[ctCOL_CustomerCode] = stockExpansion.CustomerCode;
//                // 仕入先名称
//                if ((dataRow[ctCOL_CustomerName] == DBNull.Value) || ((string)dataRow[ctCOL_CustomerName] != stockExpansion.CustomerName))
//                    dataRow[ctCOL_CustomerName] = stockExpansion.CustomerName;
//                // 仕入先名称2
//                if ((dataRow[ctCOL_CustomerName2] == DBNull.Value) || ((string)dataRow[ctCOL_CustomerName2] != stockExpansion.CustomerName2))
//                    dataRow[ctCOL_CustomerName2] = stockExpansion.CustomerName2;
                // 仕入日
                if ((dataRow[ctCOL_LastStockDate] == DBNull.Value) || ((DateTime)dataRow[ctCOL_LastStockDate] != stockExpansion.LastStockDate))
                    dataRow[ctCOL_LastStockDate] = stockExpansion.LastStockDate;

                int stockPointWay = GetStockPointWay();
                if ((stockPointWay == (int)ConstantManagement_Mobile.ct_StockPointWay.Average) ||
                    (stockPointWay == (int)ConstantManagement_Mobile.ct_StockPointWay.Last))
                {
                    //移動平均法=>在庫マスタの仕入単価が全体設定(在庫マスタ参照)
                    StockExpansion chkStock = new StockExpansion();
                    //在庫情報呼出
                    int mode = GetEditMode();
                    string goodsNo = (string)dataRow[ctCOL_GoodsNo];
                    if (!String.IsNullOrEmpty(goodsNo))
                    {
                        GetStockInf(out chkStock, goodsNo, (Int32)dataRow[ctCOL_GoodsMakerCd], (string)dataRow[ctCOL_WarehouseCode], mode);
                    }

                    dataRow[ctCOL_StockUnitPrice] = chkStock.StockUnitPriceFl;
                }
                else
                {
                    // 仕入単価
                    // 2008.01.17 修正 >>>>>>>>>>>>>>>>>>>>
                    //if ((dataRow[ctCOL_StockUnitPrice] == DBNull.Value) || ((Int64)dataRow[ctCOL_StockUnitPrice] != stockExpansion.StockUnitPriceFl))
                    //    dataRow[ctCOL_StockUnitPrice] = stockExpansion.StockUnitPriceFl;
                    if ((dataRow[ctCOL_StockUnitPrice] == DBNull.Value) || ((Double)dataRow[ctCOL_StockUnitPrice] != stockExpansion.StockUnitPriceFl))
                        dataRow[ctCOL_StockUnitPrice] = stockExpansion.StockUnitPriceFl;
                    // 2008.01.17 修正 <<<<<<<<<<<<<<<<<<<<
                }

                // メーカー名称
                if ((dataRow[ctCOL_MakerName] == DBNull.Value) || ((string)dataRow[ctCOL_MakerName] != stockExpansion.MakerName))
                    dataRow[ctCOL_MakerName] = stockExpansion.MakerName;
                // 商品区分グループコード
                if ((dataRow[ctCOL_LargeGoodsGanreCode] == DBNull.Value) || ((string)dataRow[ctCOL_LargeGoodsGanreCode] != stockExpansion.LargeGoodsGanreCode))
                    dataRow[ctCOL_LargeGoodsGanreCode] = stockExpansion.LargeGoodsGanreCode;
                // 商品区分コード
                if ((dataRow[ctCOL_MediumGoodsGanreCode] == DBNull.Value) || ((string)dataRow[ctCOL_MediumGoodsGanreCode] != stockExpansion.MediumGoodsGanreCode))
                    dataRow[ctCOL_MediumGoodsGanreCode] = stockExpansion.MediumGoodsGanreCode;
                // 商品区分詳細コード
                if ((dataRow[ctCOL_DetailGoodsGanreCode] == DBNull.Value) || ((string)dataRow[ctCOL_DetailGoodsGanreCode] != stockExpansion.DetailGoodsGanreCode))
                    dataRow[ctCOL_DetailGoodsGanreCode] = stockExpansion.DetailGoodsGanreCode;
                // ＢＬ商品コード
                //if ((dataRow[ctCOL_BLGoodsCode] == DBNull.Value) || ((Int32)dataRow[ctCOL_BLGoodsCode] != stockExpansion.BLGoodsCode))
                //    dataRow[ctCOL_BLGoodsCode] = stockExpansion.BLGoodsCode;
                // 倉庫棚番
                if ((dataRow[ctCOL_WarehouseShelfNo] == DBNull.Value) || ((string)dataRow[ctCOL_WarehouseShelfNo] != stockExpansion.WarehouseShelfNo))
                    dataRow[ctCOL_WarehouseShelfNo] = stockExpansion.WarehouseShelfNo;

                // 行No付加
                if (dataRow[ctCOL_RowNum] == DBNull.Value)
                    dataRow[ctCOL_RowNum] = mainAdjustStockDtlFullView.Count + 1;


                // 編集を行に反映
                dataRow.EndEdit();
            }
            finally
            {
            }

            return dataRow;
        }
        // 2007.10.11 追加 <<<<<<<<<<<<<<<<<<<<
           --- DEL 2008/07/24 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/07/24 Partsman用に変更

        // --- ADD 2008/07/24 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// 在庫データ変換処理(UIデータ→DataRow)[DataRow指定版]
        /// </summary>
        /// <param name="stock">在庫マスタ</param>
        /// <param name="dataRow">データ行</param>
        /// <returns>DataRow</returns>
        /// <remarks>
        /// <br>Note       : 在庫データをDataRowに変換します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/07/24</br>
        /// <br>Update Note: 2009/12/16 朱俊成</br>
        /// <br>             PM.NS-5</br>
        /// <br>             スペース→0、又は0.00の修正</br>
        /// </remarks>
        private static DataRow StockToDataRow(Stock stock, DataRow dataRow)
        {
            if (dataRow == null) dataRow = _mainProductStock.NewRow();

            try
            {
                // 論理削削除区分
                if ((dataRow[ctCOL_LogicalDeleteCode] == DBNull.Value) || ((Int32)dataRow[ctCOL_LogicalDeleteCode] != stock.LogicalDeleteCode))
                    dataRow[ctCOL_LogicalDeleteCode] = stock.LogicalDeleteCode;
                
                dataRow.EndEdit();

                // 作成日時
                if ((dataRow[ctCOL_CreateDateTime] == DBNull.Value) || ((DateTime)dataRow[ctCOL_CreateDateTime] != stock.CreateDateTime))
                    dataRow[ctCOL_CreateDateTime] = stock.CreateDateTime;
                // 更新日時
                if ((dataRow[ctCOL_UpdateDateTime] == DBNull.Value) || ((DateTime)dataRow[ctCOL_UpdateDateTime] != stock.UpdateDateTime))
                    dataRow[ctCOL_UpdateDateTime] = stock.UpdateDateTime;
                // 企業コード
                if ((dataRow[ctCOL_EnterpriseCode] == DBNull.Value) || ((string)dataRow[ctCOL_EnterpriseCode] != stock.EnterpriseCode))
                    dataRow[ctCOL_EnterpriseCode] = stock.EnterpriseCode;
                // GUID
                if ((dataRow[ctCOL_FileHeaderGuid] == DBNull.Value) || ((Guid)dataRow[ctCOL_FileHeaderGuid] != stock.FileHeaderGuid))
                    dataRow[ctCOL_FileHeaderGuid] = stock.FileHeaderGuid;
                // 更新従業員コード
                if ((dataRow[ctCOL_UpdEmployeeCode] == DBNull.Value) || ((string)dataRow[ctCOL_UpdEmployeeCode] != stock.UpdEmployeeCode))
                    dataRow[ctCOL_UpdEmployeeCode] = stock.UpdEmployeeCode;
                // 更新アセンブリID1
                if ((dataRow[ctCOL_UpdAssemblyId1] == DBNull.Value) || ((string)dataRow[ctCOL_UpdAssemblyId1] != stock.UpdAssemblyId1))
                    dataRow[ctCOL_UpdAssemblyId1] = stock.UpdAssemblyId1;
                // 更新アセンブリID2
                if ((dataRow[ctCOL_UpdAssemblyId2] == DBNull.Value) || ((string)dataRow[ctCOL_UpdAssemblyId2] != stock.UpdAssemblyId2))
                    dataRow[ctCOL_UpdAssemblyId2] = stock.UpdAssemblyId2;
                // 論理削除区分
                if ((dataRow[ctCOL_LogicalDeleteCode] == DBNull.Value) || ((Int32)dataRow[ctCOL_LogicalDeleteCode] != stock.LogicalDeleteCode))
                    dataRow[ctCOL_LogicalDeleteCode] = stock.LogicalDeleteCode;
                // 拠点コード
                if ((dataRow[ctCOL_SectionCode] == DBNull.Value) || ((string)dataRow[ctCOL_SectionCode] != stock.SectionCode))
                    dataRow[ctCOL_SectionCode] = stock.SectionCode;
                // 行No付加
                if (dataRow[ctCOL_RowNum] == DBNull.Value)
                    dataRow[ctCOL_RowNum] = mainAdjustStockDtlFullView.Count + 1;
                // 品番
                if ((dataRow[ctCOL_GoodsNo] == DBNull.Value) || ((string)dataRow[ctCOL_GoodsNo] != stock.GoodsNo))
                    dataRow[ctCOL_GoodsNo] = stock.GoodsNo;
                // 品名
                if ((dataRow[ctCOL_GoodsName] == DBNull.Value) || ((string)dataRow[ctCOL_GoodsName] != stock.GoodsName))
                    dataRow[ctCOL_GoodsName] = stock.GoodsName;
                // BLコード
                
                //// メーカーコード
                //if ((dataRow[ctCOL_GoodsMakerCd] == DBNull.Value) || ((Int32)dataRow[ctCOL_GoodsMakerCd] != stock.GoodsMakerCd))
                //    dataRow[ctCOL_GoodsMakerCd] = stock.GoodsMakerCd;
                // 仕入先

                // 標準価格

                // --- DEL 2009/12/16 ---------->>>>>
                //スペースではなく0、又は0.00を表示するように修正する
                // 原単価
                //dataRow[ctCOL_StockUnitPrice] = stock.StockUnitPriceFl;

                // 仕入数
                //if ((dataRow[ctCOL_SalesOrderUnit] == DBNull.Value) || ((Double)dataRow[ctCOL_SalesOrderUnit] != stock.SalesOrderUnit))
                //dataRow[ctCOL_SalesOrderUnit] = stock.SalesOrderUnit;
                // 仕入後数
                //if ((dataRow[ctCOL_AfSalesOrderUnit] == DBNull.Value) || ((Double)dataRow[ctCOL_AfSalesOrderUnit] != ((Double)stock.SalesOrderUnit + stock.ShipmentPosCnt)))
                //dataRow[ctCOL_AfSalesOrderUnit] = stock.SalesOrderUnit;
                //--- DEL 2009/12/16 ----------<<<<<
                // 倉庫棚番
                if ((dataRow[ctCOL_WarehouseShelfNo] == DBNull.Value) || ((string)dataRow[ctCOL_WarehouseShelfNo] != stock.WarehouseShelfNo))
                    dataRow[ctCOL_WarehouseShelfNo] = stock.WarehouseShelfNo;
                //// 発注残
                //if ((dataRow[ctCOL_SalesOrderCount] == DBNull.Value) || ((Double)dataRow[ctCOL_SalesOrderCount] != stock.SalesOrderCount))
                //    dataRow[ctCOL_SalesOrderCount] = stock.SalesOrderCount;
                //// 在庫数
                //if ((dataRow[ctCOL_SupplierStock] == DBNull.Value) || ((Double)dataRow[ctCOL_SupplierStock] != stock.ShipmentPosCnt))
                //    dataRow[ctCOL_SupplierStock] = stock.ShipmentPosCnt;
                // 変更前在庫数
                if ((dataRow[ctCOL_BfSupplierStock] == DBNull.Value) || ((Double)dataRow[ctCOL_BfSupplierStock] != stock.ShipmentPosCnt))
                    dataRow[ctCOL_BfSupplierStock] = stock.ShipmentPosCnt;
                // 倉庫コード
                if ((dataRow[ctCOL_WarehouseCode] == DBNull.Value) || ((string)dataRow[ctCOL_WarehouseCode] != stock.WarehouseCode))
                    dataRow[ctCOL_WarehouseCode] = stock.WarehouseCode;
                // 明細備考

                // 編集を行に反映
                dataRow.EndEdit();
            }
            finally
            {
            }

            return dataRow;
        }
        // --- ADD 2008/07/24 ---------------------------------------------------------------------<<<<<

        #region DEL 2008/07/24 使用していないのでコメントアウト
        /* --- DEL 2008/07/24 --------------------------------------------------------------------->>>>>
        #region 在庫データ変換処理(DataRow→StockWork)
        /// <summary>
        /// 製番在庫データ変換処理(DataRow→Stock)
        /// </summary>
        /// <br>Note       : 在庫情報(KEY部分のみ)作成</br>/// 
        /// <param name="dataRow"></param>
        /// <returns></returns>
        private static Stock DataRowToStock(DataRow dataRow)
        {
            Stock stock = new Stock();
            // 企業コード
            stock.EnterpriseCode = (dataRow[ctCOL_EnterpriseCode] != DBNull.Value) ? (string)dataRow[ctCOL_EnterpriseCode] : "";
            // 拠点コード
            stock.SectionCode = (dataRow[ctCOL_SectionCode] != DBNull.Value) ? (string)dataRow[ctCOL_SectionCode] : "";
            // 2007.10.11 修正 >>>>>>>>>>>>>>>>>>>>
            //// メーカーコード
            //stock.MakerCode = (dataRow[ctCOL_MakerCode] != DBNull.Value) ? (Int32)dataRow[ctCOL_MakerCode] : 0;
            //// 商品コード
            //stock.GoodsCode = (dataRow[ctCOL_GoodsCode] != DBNull.Value) ? (string)dataRow[ctCOL_GoodsCode] : "";
            // メーカーコード
            stock.GoodsMakerCd = (dataRow[ctCOL_GoodsMakerCd] != DBNull.Value) ? (Int32)dataRow[ctCOL_GoodsMakerCd] : 0;
            // 商品コード
            stock.GoodsNo = (dataRow[ctCOL_GoodsNo] != DBNull.Value) ? (string)dataRow[ctCOL_GoodsNo] : "";
            // 2007.10.11 修正 <<<<<<<<<<<<<<<<<<<<
            return stock;
        }
        #endregion
           --- DEL 2008/07/24 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/07/24 使用していないのでコメントアウト

        #region 2007.10.11 削除
        // 2007.10.11 削除 >>>>>>>>>>>>>>>>>>>>
        #region 製番在庫データ変換
        /*
        /// <summary>
		/// 製番在庫データ変換
		/// </summary>
		/// <param name="dataRow"></param>
		/// <returns></returns>
		private static ProductStock DataRowToProductStock(DataRow dataRow,int mode)
		{
			ProductStock productStock = new ProductStock();

			// 作成日時
			productStock.CreateDateTime = (dataRow[ctCOL_CreateDateTime] != DBNull.Value) ? (DateTime)dataRow[ctCOL_CreateDateTime] : DateTime.MinValue;
			// 更新日時
			productStock.UpdateDateTime = (dataRow[ctCOL_UpdateDateTime] != DBNull.Value) ? (DateTime)dataRow[ctCOL_UpdateDateTime] : DateTime.MinValue;
			// 企業コード
			productStock.EnterpriseCode = (dataRow[ctCOL_EnterpriseCode] != DBNull.Value) ? (string)dataRow[ctCOL_EnterpriseCode] : "";
			// GUID
			productStock.FileHeaderGuid = (dataRow[ctCOL_FileHeaderGuid] != DBNull.Value) ? (Guid)dataRow[ctCOL_FileHeaderGuid] : Guid.Empty;
			// 更新従業員コード
			productStock.UpdEmployeeCode = (dataRow[ctCOL_UpdEmployeeCode] != DBNull.Value) ? (string)dataRow[ctCOL_UpdEmployeeCode] : "";
			// 更新アセンブリID1
			productStock.UpdAssemblyId1 = (dataRow[ctCOL_UpdAssemblyId1] != DBNull.Value) ? (string)dataRow[ctCOL_UpdAssemblyId1] : "";
			// 更新アセンブリID2
			productStock.UpdAssemblyId2 = (dataRow[ctCOL_UpdAssemblyId2] != DBNull.Value) ? (string)dataRow[ctCOL_UpdAssemblyId2] : "";
			// 論理削除区分
			productStock.LogicalDeleteCode = (dataRow[ctCOL_LogicalDeleteCode] != DBNull.Value) ? (Int32)dataRow[ctCOL_LogicalDeleteCode] : 0;
            // 拠点コード
            productStock.SectionCode = (dataRow[ctCOL_SectionCode] != DBNull.Value) ? (string)dataRow[ctCOL_SectionCode] : "";
            // メーカーコード
            productStock.MakerCode = (dataRow[ctCOL_MakerCode] != DBNull.Value) ? (Int32)dataRow[ctCOL_MakerCode] : 0;
            // 商品コード
            productStock.GoodsCode = (dataRow[ctCOL_GoodsCode] != DBNull.Value) ? (string)dataRow[ctCOL_GoodsCode] : "";
            // 商品名称
            productStock.GoodsName = (dataRow[ctCOL_GoodsName] != DBNull.Value) ? (string)dataRow[ctCOL_GoodsName] : "";
            // 製造番号
            productStock.ProductNumber = (dataRow[ctCOL_ProductNumber] != DBNull.Value) ? (string)dataRow[ctCOL_ProductNumber] : "";
            // 製造番号マスタGUID
            productStock.ProductStockGuid = (dataRow[ctCOL_ProductStockGuid] != DBNull.Value) ? (Guid)dataRow[ctCOL_ProductStockGuid] : Guid.Empty;
            // 在庫区分
            productStock.StockDiv = (dataRow[ctCOL_StockDiv] != DBNull.Value) ? (Int32)dataRow[ctCOL_StockDiv] : 0;
            // 倉庫コード
            productStock.WarehouseCode = (dataRow[ctCOL_WarehouseCode] != DBNull.Value) ? (string)dataRow[ctCOL_WarehouseCode] : "";
            // 倉庫名称
            productStock.WarehouseName = (dataRow[ctCOL_WarehouseName] != DBNull.Value) ? (string)dataRow[ctCOL_WarehouseName] : "";
            // 事業者コード
            productStock.CarrierEpCode = (dataRow[ctCOL_CarrierEpCode] != DBNull.Value) ? (Int32)dataRow[ctCOL_CarrierEpCode] : 0;
            // 事業者名称
            productStock.CarrierEpName = (dataRow[ctCOL_CarrierEpName] != DBNull.Value) ? (string)dataRow[ctCOL_CarrierEpName] : "";
            // 得意先コード
            productStock.CustomerCode = (dataRow[ctCOL_CustomerCode] != DBNull.Value) ? (Int32)dataRow[ctCOL_CustomerCode] : 0;
            // 得意先名称
            productStock.CustomerName = (dataRow[ctCOL_CustomerName] != DBNull.Value) ? (string)dataRow[ctCOL_CustomerName] : "";
            // 得意先名称2
            productStock.CustomerName2 = (dataRow[ctCOL_CustomerName2] != DBNull.Value) ? (string)dataRow[ctCOL_CustomerName2] : "";
            // 仕入日
            productStock.StockDate = (dataRow[ctCOL_StockDate] != DBNull.Value) ? (DateTime)dataRow[ctCOL_StockDate] : DateTime.MinValue;
            // 入荷日
            productStock.ArrivalGoodsDay = (dataRow[ctCOL_ArrivalGoodsDay] != DBNull.Value) ? (DateTime)dataRow[ctCOL_ArrivalGoodsDay] : DateTime.MinValue;
            // 仕入単価
            // 在庫評価方法によって変える(受託在庫はなし)
            if (productStock.StockDiv == 0)
            {
                int pointWay = GetStockPointWay();

                if (pointWay == 1)
                {
                    //最終仕入法
                    productStock.StockUnitPrice = (dataRow[ctCOL_StockUnitPrice] != DBNull.Value) ? (Int64)dataRow[ctCOL_StockUnitPrice] : 0;
                }
                else if (pointWay == 3)
                {
                    //個別単価法
                    productStock.StockUnitPrice = (dataRow[ctCOL_StockUnitPrice] != DBNull.Value) ? (Int64)dataRow[ctCOL_StockUnitPrice] : 0;
                }
                else if (pointWay == 2)
                {
                    //移動平均法
                    //変更できない!                    
                    productStock.StockUnitPrice = (dataRow[ctCOL_StockUnitPrice] != DBNull.Value) ? (Int64)dataRow[ctCOL_StockUnitPrice] : 0;
                }
            }
            else
            {
                productStock.StockUnitPrice = (dataRow[ctCOL_StockUnitPrice] != DBNull.Value) ? (Int64)dataRow[ctCOL_StockUnitPrice] : 0;
            }
            // 課税区分
            productStock.TaxationCode = (dataRow[ctCOL_TaxationCode] != DBNull.Value) ? (Int32)dataRow[ctCOL_TaxationCode] : 0;
            // 在庫状態
            if ((mode != ctMode_StockAdjust) && (mode != ctMode_TrustAdjust))
            {
                productStock.StockState = (dataRow[ctCOL_StockState] != DBNull.Value) ? (Int32)dataRow[ctCOL_StockState] : 0;
            }
            else
            {
                productStock.StockState = 81;//消去
            }
            // 移動状態
            productStock.MoveStatus = (dataRow[ctCOL_MoveStatus] != DBNull.Value) ? (Int32)dataRow[ctCOL_MoveStatus] : 0;
            // 商品状態
            if (mode != ctMode_GoodsCodeStatus)
            {
                productStock.GoodsCodeStatus = (dataRow[ctCOL_GoodsCodeStatus] != DBNull.Value) ? (Int32)dataRow[ctCOL_GoodsCodeStatus] : 0;
            }
            else
            {
                productStock.GoodsCodeStatus = (dataRow[ctCOL_GoodsCodeStatus] != DBNull.Value) ? (Int32)dataRow[ctCOL_GoodsCodeStatus] : 0;
            }
            // 商品電話番号1
            productStock.StockTelNo1 = (dataRow[ctCOL_StockTelNo1] != DBNull.Value) ? (string)dataRow[ctCOL_StockTelNo1] : "";
            // 商品電話番号2
            productStock.StockTelNo2 = (dataRow[ctCOL_StockTelNo2] != DBNull.Value) ? (string)dataRow[ctCOL_StockTelNo2] : "";
            // ロム区分
            productStock.RomDiv = (dataRow[ctCOL_RomDiv] != DBNull.Value) ? (Int32)dataRow[ctCOL_RomDiv] : 0;
            // 機種コード
            productStock.CellphoneModelCode = (dataRow[ctCOL_CellphoneModelCode] != DBNull.Value) ? (string)dataRow[ctCOL_CellphoneModelCode] : "";
            // 機種名称
            productStock.CellphoneModelName = (dataRow[ctCOL_CellphoneModelName] != DBNull.Value) ? (string)dataRow[ctCOL_CellphoneModelName] : "";
            // キャリアコード
            productStock.CarrierCode = (dataRow[ctCOL_CarrierCode] != DBNull.Value) ? (Int32)dataRow[ctCOL_CarrierCode] : 0;
            // キャリア名称
            productStock.CarrierName = (dataRow[ctCOL_CarrierName] != DBNull.Value) ? (string)dataRow[ctCOL_CarrierName] : "";
            // メーカー名称
            productStock.MakerName = (dataRow[ctCOL_MakerName] != DBNull.Value) ? (string)dataRow[ctCOL_MakerName] : "";
            // 系統色コード
            productStock.SystematicColorCd = (dataRow[ctCOL_SystematicColorCd] != DBNull.Value) ? (Int32)dataRow[ctCOL_SystematicColorCd] : 0;
            // 系統色名称
            productStock.SystematicColorNm = (dataRow[ctCOL_SystematicColorNm] != DBNull.Value) ? (string)dataRow[ctCOL_SystematicColorNm] : "";
            // 商品大分類コード
            productStock.LargeGoodsGanreCode = (dataRow[ctCOL_LargeGoodsGanreCode] != DBNull.Value) ? (string)dataRow[ctCOL_LargeGoodsGanreCode] : "";
            // 商品中分類コード
            productStock.MediumGoodsGanreCode = (dataRow[ctCOL_MediumGoodsGanreCode] != DBNull.Value) ? (string)dataRow[ctCOL_MediumGoodsGanreCode] : "";
            // 出荷先得意先コード
            productStock.ShipCustomerCode= (dataRow[ctCOL_ShipCustomerCode] != DBNull.Value) ? (Int32)dataRow[ctCOL_ShipCustomerCode] : 0;
            // 出荷先得意先名称
            productStock.ShipCustomerName = (dataRow[ctCOL_ShipCustomerName] != DBNull.Value) ? (string)dataRow[ctCOL_ShipCustomerName] : "";
            // 出荷先得意先名称2
            productStock.ShipCustomerName2 = (dataRow[ctCOL_ShipCustomerName2] != DBNull.Value) ? (string)dataRow[ctCOL_ShipCustomerName2] : "";

            return productStock;
		}
        */
		#endregion
        // 2007.10.11 削除 <<<<<<<<<<<<<<<<<<<<
        #endregion

        #region DEL 2008/07/24 Partsman用に変更
        /* --- DEL 2008/07/24 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// 在庫調整データ変換
        /// </summary>
        /// <param name="dataRow"></param>
        /// <returns></returns>
        private static StockAdjust DataRowToStockAdjust(DataRow dataRow, int mode, string setMsg)
        {
            StockAdjust stockAdjust = new StockAdjust();

            // 作成日時            
            stockAdjust.CreateDateTime = (dataRow[ctCOL_CreateDateTime] != DBNull.Value) ? (DateTime)dataRow[ctCOL_CreateDateTime] : DateTime.MinValue;
            // 更新日時

            stockAdjust.UpdateDateTime = DateTime.Now;
            // 企業コード
            stockAdjust.EnterpriseCode = (dataRow[ctCOL_EnterpriseCode] != DBNull.Value) ? (string)dataRow[ctCOL_EnterpriseCode] : "";
            // GUID

            // 更新従業員コード
            stockAdjust.UpdEmployeeCode = (dataRow[ctCOL_UpdEmployeeCode] != DBNull.Value) ? (string)dataRow[ctCOL_UpdEmployeeCode] : "";
            // 更新アセンブリID1
            stockAdjust.UpdAssemblyId1 = (dataRow[ctCOL_UpdAssemblyId1] != DBNull.Value) ? (string)dataRow[ctCOL_UpdAssemblyId1] : "";
            // 更新アセンブリID2
            stockAdjust.UpdAssemblyId2 = (dataRow[ctCOL_UpdAssemblyId2] != DBNull.Value) ? (string)dataRow[ctCOL_UpdAssemblyId2] : "";
            // 論理削除区分
            stockAdjust.LogicalDeleteCode = (dataRow[ctCOL_LogicalDeleteCode] != DBNull.Value) ? (Int32)dataRow[ctCOL_LogicalDeleteCode] : 0;
            // 拠点コード
            stockAdjust.SectionCode = GetSection();
            // 在庫調整伝票番号
            // 受払元伝票区分
            stockAdjust.AcPaySlipCd = 40;// 調整
            // 受払元取引区分
            int setCd = 0;
            switch (mode)
            {
                case ctMode_StockAdjust://調整
                    // 2008.01.17 削除 >>>>>>>>>>>>>>>>>>>>
                    //case ctMode_TrustAdjust:
                    // 2008.01.17 削除 <<<<<<<<<<<<<<<<<<<<
                    {
                        setCd = 30;
                        break;
                    }
                // 2007.10.11 修正 >>>>>>>>>>>>>>>>>>>>
                //case ctMode_ProductReEdit://製番
                //    {
                //        setCd = 32;
                //        break;
                //    }
                // 2007.10.11 修正 <<<<<<<<<<<<<<<<<<<<
                case ctMode_UnitPriceReEdit://原価調整
                    {
                        setCd = 31;
                        break;
                    }
                // 2007.10.11 修正 >>>>>>>>>>>>>>>>>>>>
                //case ctMode_GoodsCodeStatus://不良品
                //    {
                //        setCd = 33;
                //        break;
                //    }
                // 2007.10.11 修正 <<<<<<<<<<<<<<<<<<<<
                // 2007.10.11 追加 >>>>>>>>>>>>>>>>>>>>
                case ctMode_ShelfNoReEdit://棚番
                    {
                        setCd = 40;
                        break;
                    }
                // 2007.10.11 追加 <<<<<<<<<<<<<<<<<<<<
            }
            stockAdjust.AcPayTransCd = setCd;
            // 調整日付
            stockAdjust.AdjustDate = GetDate();
            // 入力担当者コード
            stockAdjust.InputAgenCd = LoginInfoAcquisition.Employee.EmployeeCode;
            stockAdjust.InputAgenCd = GetInputAgent().EmployeeCode;
            // 入力担当者名称
            stockAdjust.InputAgenNm = LoginInfoAcquisition.Employee.Name;
            stockAdjust.InputAgenNm = GetInputAgent().Name;
            // 伝票備考
            stockAdjust.SlipNote = setMsg;

            return stockAdjust;
        }

        /// <summary>
        /// 在庫調整明細データ変換
        /// </summary>
        /// <param name="dataRow"></param>
        /// <returns></returns>
        private static StockAdjustDtl DataRowToStockAdjustDtl(DataRow dataRow, int mode, int rowCnt)
        {
            StockAdjustDtl stockAdjustDtl = new StockAdjustDtl();

            // 作成日時
            stockAdjustDtl.CreateDateTime = (dataRow[ctCOL_CreateDateTime] != DBNull.Value) ? (DateTime)dataRow[ctCOL_CreateDateTime] : DateTime.MinValue;
            // 更新日時
            stockAdjustDtl.UpdateDateTime = (dataRow[ctCOL_UpdateDateTime] != DBNull.Value) ? (DateTime)dataRow[ctCOL_UpdateDateTime] : DateTime.MinValue;
            // 企業コード
            stockAdjustDtl.EnterpriseCode = (dataRow[ctCOL_EnterpriseCode] != DBNull.Value) ? (string)dataRow[ctCOL_EnterpriseCode] : "";
            // GUID
            stockAdjustDtl.FileHeaderGuid = (dataRow[ctCOL_FileHeaderGuid] != DBNull.Value) ? (Guid)dataRow[ctCOL_FileHeaderGuid] : Guid.Empty;
            // 更新従業員コード
            stockAdjustDtl.UpdEmployeeCode = (dataRow[ctCOL_UpdEmployeeCode] != DBNull.Value) ? (string)dataRow[ctCOL_UpdEmployeeCode] : "";
            // 更新アセンブリID1
            stockAdjustDtl.UpdAssemblyId1 = (dataRow[ctCOL_UpdAssemblyId1] != DBNull.Value) ? (string)dataRow[ctCOL_UpdAssemblyId1] : "";
            // 更新アセンブリID2
            stockAdjustDtl.UpdAssemblyId2 = (dataRow[ctCOL_UpdAssemblyId2] != DBNull.Value) ? (string)dataRow[ctCOL_UpdAssemblyId2] : "";
            // 論理削除区分
            stockAdjustDtl.LogicalDeleteCode = (dataRow[ctCOL_LogicalDeleteCode] != DBNull.Value) ? (Int32)dataRow[ctCOL_LogicalDeleteCode] : 0;
            // 拠点コード
            stockAdjustDtl.SectionCode = GetSection();
            // 在庫調整伝票番号
            stockAdjustDtl.StockAdjustSlipNo = 0;
            // 在庫調整行番号
            stockAdjustDtl.StockAdjustRowNo = rowCnt;
            // 受払元伝票区分
            stockAdjustDtl.AcPaySlipCd = 40;
            // 受払元取引区分
            switch (mode)
            {
                case ctMode_StockAdjust:
                    {
                        //仕入調整
                        stockAdjustDtl.AcPayTransCd = 30;
                        break;
                    }
                // 2008.01.17 削除 >>>>>>>>>>>>>>>>>>>>
                //case ctMode_TrustAdjust:
                //    {
                //        //受託調整
                //        stockAdjustDtl.AcPayTransCd = 30;
                //        break;
                //    }
                // 2008.01.17 削除 <<<<<<<<<<<<<<<<<<<<

                // 2007.10.11 修正 >>>>>>>>>>>>>>>>>>>>
                //case ctMode_ProductReEdit:
                //    {
                //        //製番訂正
                //        stockAdjustDtl.AcPayTransCd = 32;
                //        break;
                //    }
                // 2007.10.11 修正 <<<<<<<<<<<<<<<<<<<<
                case ctMode_UnitPriceReEdit:
                    {
                        //原価調整
                        stockAdjustDtl.AcPayTransCd = 31;
                        break;
                    }
                // 2007.10.11 修正 >>>>>>>>>>>>>>>>>>>>
                //case ctMode_GoodsCodeStatus:
                //    {
                //        //不良品
                //        stockAdjustDtl.AcPayTransCd = 33;
                //        break;
                //    }
                // 2007.10.11 修正 <<<<<<<<<<<<<<<<<<<<
                // 2007.10.11 追加 >>>>>>>>>>>>>>>>>>>>
                case ctMode_ShelfNoReEdit:
                    {
                        //棚番
                        stockAdjustDtl.AcPayTransCd = 40;
                        break;
                    }
                // 2007.10.11 追加 <<<<<<<<<<<<<<<<<<<<
            }

            // 調整日付
            stockAdjustDtl.AdjustDate = GetDate();
            // メーカーコード
            // 2007.10.11 修正 >>>>>>>>>>>>>>>>>>>>
            //stockAdjustDtl.MakerCode = (dataRow[ctCOL_MakerCode] != DBNull.Value) ? (Int32)dataRow[ctCOL_MakerCode] : 0;
            stockAdjustDtl.GoodsMakerCd = (dataRow[ctCOL_GoodsMakerCd] != DBNull.Value) ? (Int32)dataRow[ctCOL_GoodsMakerCd] : 0;
            // 2007.10.11 修正 <<<<<<<<<<<<<<<<<<<<
            // メーカー名称
            stockAdjustDtl.MakerName = (dataRow[ctCOL_MakerName] != DBNull.Value) ? (string)dataRow[ctCOL_MakerName] : "";
            // 商品コード
            // 2007.10.11 修正 >>>>>>>>>>>>>>>>>>>>
            //stockAdjustDtl.GoodsCode = (dataRow[ctCOL_GoodsCode] != DBNull.Value) ? (string)dataRow[ctCOL_GoodsCode] : "";
            stockAdjustDtl.GoodsNo = (dataRow[ctCOL_GoodsNo] != DBNull.Value) ? (string)dataRow[ctCOL_GoodsNo] : "";
            // 2007.10.11 修正 <<<<<<<<<<<<<<<<<<<<
            // 商品名称
            stockAdjustDtl.GoodsName = (dataRow[ctCOL_GoodsName] != DBNull.Value) ? (string)dataRow[ctCOL_GoodsName] : "";
            // 2007.10.11 削除 >>>>>>>>>>>>>>>>>>>>
            //// 製番管理区分                        
            //stockAdjustDtl.PrdNumMngDiv = (dataRow[ctCOL_PrdNumMngDiv] != DBNull.Value) ? (Int32)dataRow[ctCOL_PrdNumMngDiv] : 0 ;　//在庫マスタの製番管理区分に従う
            //// 製造番号
            //stockAdjustDtl.ProductNumber = (dataRow[ctCOL_ProductNumber] != DBNull.Value) ? (string)dataRow[ctCOL_ProductNumber] : "";
            //// 変更前製造番号            
            //stockAdjustDtl.BfProductNumber = (dataRow[ctCOL_BfProductNumber] != DBNull.Value) ? (string)dataRow[ctCOL_BfProductNumber] : "";
            // 2007.10.11 削除 <<<<<<<<<<<<<<<<<<<<
            // 2008.01.17 修正 >>>>>>>>>>>>>>>>>>>>
            //if (mode != ctMode_TrustAdjust)
            //{
            //    // 2007.10.11 修正 >>>>>>>>>>>>>>>>>>>>
            //    //// 仕入単価 → 修正単価(原価訂正時のみ)
            //    //stockAdjustDtl.StockUnitPrice = (dataRow[ctCOL_StockUnitPrice] != DBNull.Value) ? (Int64)dataRow[ctCOL_StockUnitPrice] : 0;
            //    //// 変更前仕入単価
            //    //stockAdjustDtl.BfStockUnitPrice = (dataRow[ctCOL_BfStockUnitPrice] != DBNull.Value) ? (Int64)dataRow[ctCOL_BfStockUnitPrice] : 0;
            //    // 仕入単価 → 修正単価(原価訂正時のみ)
            //    stockAdjustDtl.StockUnitPriceFl = (dataRow[ctCOL_StockUnitPrice] != DBNull.Value) ? (Int64)dataRow[ctCOL_StockUnitPrice] : 0;
            //    // 変更前仕入単価
            //    stockAdjustDtl.BfStockUnitPriceFl = (dataRow[ctCOL_BfStockUnitPrice] != DBNull.Value) ? (Int64)dataRow[ctCOL_BfStockUnitPrice] : 0;
            //    // 2007.10.11 修正 <<<<<<<<<<<<<<<<<<<<
            //}
            // 仕入単価 → 修正単価(原価訂正時のみ)
            stockAdjustDtl.StockUnitPriceFl = (dataRow[ctCOL_StockUnitPrice] != DBNull.Value) ? (Double)dataRow[ctCOL_StockUnitPrice] : 0;
            // 変更前仕入単価
            stockAdjustDtl.BfStockUnitPriceFl = (dataRow[ctCOL_BfStockUnitPrice] != DBNull.Value) ? (Double)dataRow[ctCOL_BfStockUnitPrice] : 0;
            // 2008.01.17 修正 <<<<<<<<<<<<<<<<<<<<
            // 2007.10.11 削除 >>>>>>>>>>>>>>>>>>>>
            //// 商品電話番号1
            //stockAdjustDtl.StockTelNo1 = (dataRow[ctCOL_StockTelNo1] != DBNull.Value) ? (string)dataRow[ctCOL_StockTelNo1] : "";
            //// 変更前商品電話番号1 変更なし
            //
            //// 商品電話番号2
            //stockAdjustDtl.StockTelNo2 = (dataRow[ctCOL_StockTelNo2] != DBNull.Value) ? (string)dataRow[ctCOL_StockTelNo2] : "";
            //// 変更前商品伝票番号2 変更なし
            // 2007.10.11 削除 <<<<<<<<<<<<<<<<<<<<

            // 仕入在庫数
            if (mode == ctMode_StockAdjust)
            {
                if (dataRow[ctCOL_AdjustCount] != DBNull.Value)
                {
                    stockAdjustDtl.SupplierStock = (dataRow[ctCOL_SupplierStock] != DBNull.Value) ?
                                                   (double)dataRow[ctCOL_SupplierStock] + (double)dataRow[ctCOL_AdjustCount] : 0;
                    stockAdjustDtl.TrustCount = (dataRow[ctCOL_TrustCount]) != DBNull.Value ? (double)dataRow[ctCOL_TrustCount] : 0;
                }
                else
                {
                    stockAdjustDtl.SupplierStock = (dataRow[ctCOL_SupplierStock] != DBNull.Value) ?
                                                   (double)dataRow[ctCOL_SupplierStock] : 0;
                    stockAdjustDtl.TrustCount = (dataRow[ctCOL_TrustCount]) != DBNull.Value ? (double)dataRow[ctCOL_TrustCount] : 0;
                }

                // 2007.10.11 削除 >>>>>>>>>>>>>>>>>>>>
                //// 在庫状態
                //stockAdjustDtl.StockState = (int)ConstantManagement_Mobile.ct_StockState.Deletion;
                // 2007.10.11 削除 <<<<<<<<<<<<<<<<<<<<

                // 在庫区分
                stockAdjustDtl.StockDiv = (int)ConstantManagement_Mobile.ct_StockDiv.Company;
            }
            // 2008.01.17 削除 >>>>>>>>>>>>>>>>>>>>
            //else if (mode == ctMode_TrustAdjust)
            //{
            //    if (dataRow[ctCOL_AdjustCount] != DBNull.Value)
            //    {
            //        //調整を加味
            //        stockAdjustDtl.SupplierStock = (dataRow[ctCOL_SupplierStock] != DBNull.Value) ? (double)dataRow[ctCOL_SupplierStock] : 0;
            //        stockAdjustDtl.TrustCount = (dataRow[ctCOL_TrustCount] != DBNull.Value) ?
            //            (double)dataRow[ctCOL_TrustCount] + (double)dataRow[ctCOL_AdjustCount] : 0;
            //    }
            //    else
            //    {
            //        stockAdjustDtl.SupplierStock = (dataRow[ctCOL_SupplierStock] != DBNull.Value) ?
            //                                       (double)dataRow[ctCOL_SupplierStock] : 0;
            //        stockAdjustDtl.TrustCount = (dataRow[ctCOL_TrustCount]) != DBNull.Value ? (double)dataRow[ctCOL_TrustCount] : 0;
            //    }
            //    // 2007.10.11 削除 >>>>>>>>>>>>>>>>>>>>
            //    //// 在庫状態
            //    //stockAdjustDtl.StockState = (int)ConstantManagement_Mobile.ct_StockState.Deletion;
            //    // 2007.10.11 削除 <<<<<<<<<<<<<<<<<<<<

            //    // 在庫区分
            //    stockAdjustDtl.StockDiv = (int)ConstantManagement_Mobile.ct_StockDiv.Trust;

            //}
            // 2008.01.17 削除 <<<<<<<<<<<<<<<<<<<<
            else if (mode == ctMode_UnitPriceReEdit) //原価調整
            {
                if (dataRow[ctCOL_AdjustCount] != DBNull.Value)
                {
                    stockAdjustDtl.TrustCount = (dataRow[ctCOL_TrustCount] != DBNull.Value) ?
                                                   (double)dataRow[ctCOL_TrustCount] + (double)dataRow[ctCOL_AdjustCount] : 0;
                    stockAdjustDtl.SupplierStock = (dataRow[ctCOL_SupplierStock]) != DBNull.Value ? (double)dataRow[ctCOL_SupplierStock] : 0;
                }
                else
                {
                    stockAdjustDtl.TrustCount = (dataRow[ctCOL_TrustCount] != DBNull.Value) ?
                                                   (double)dataRow[ctCOL_TrustCount] : 0;
                    stockAdjustDtl.SupplierStock = (dataRow[ctCOL_SupplierStock]) != DBNull.Value ? (double)dataRow[ctCOL_SupplierStock] : 0;
                }
                // 2007.10.11 削除 >>>>>>>>>>>>>>>>>>>>
                //// 在庫状態
                //stockAdjustDtl.StockState = (dataRow[ctCOL_StockState] != DBNull.Value) ? (Int32)dataRow[ctCOL_StockState] : 0;
                // 2007.10.11 削除 <<<<<<<<<<<<<<<<<<<<

                // 在庫区分 (受託は原価調整できない)
                stockAdjustDtl.StockDiv = (dataRow[ctCOL_StockDiv] != DBNull.Value) ? (Int32)dataRow[ctCOL_StockDiv] : 0;

            }
            else
            {
                stockAdjustDtl.SupplierStock = (dataRow[ctCOL_SupplierStock]) != DBNull.Value ? (double)dataRow[ctCOL_SupplierStock] : 0;
                stockAdjustDtl.TrustCount = (dataRow[ctCOL_TrustCount]) != DBNull.Value ? (double)dataRow[ctCOL_TrustCount] : 0;
                // 2007.10.11 削除 >>>>>>>>>>>>>>>>>>>>
                //// 在庫状態
                //stockAdjustDtl.StockState = (dataRow[ctCOL_StockState] != DBNull.Value) ? (Int32)dataRow[ctCOL_StockState] : 0;
                // 2007.10.11 削除 <<<<<<<<<<<<<<<<<<<<

                // 在庫区分
                stockAdjustDtl.StockDiv = (dataRow[ctCOL_StockDiv] != DBNull.Value) ? (Int32)dataRow[ctCOL_StockDiv] : 0;
            }

            // 調整数
            stockAdjustDtl.AdjustCount = (dataRow[ctCOL_AdjustCount] != DBNull.Value) ? (double)dataRow[ctCOL_AdjustCount] : 0;
            // 2007.10.11 削除 >>>>>>>>>>>>>>>>>>>>
            //// 変更前在庫状態
            //stockAdjustDtl.BfStockState = (dataRow[ctCOL_StockState] != DBNull.Value) ? (Int32)dataRow[ctCOL_StockState] : 0;
            //// 商品状態
            //stockAdjustDtl.GoodsCodeStatus = (dataRow[ctCOL_GoodsCodeStatus] != DBNull.Value) ? (Int32)dataRow[ctCOL_GoodsCodeStatus] : 0;
            //// 製造番号マスタGUID
            //stockAdjustDtl.ProductStockGuid = (dataRow[ctCOL_ProductStockGuid] != DBNull.Value) ? (Guid)dataRow[ctCOL_ProductStockGuid] : Guid.Empty;
            // 2007.10.11 削除 <<<<<<<<<<<<<<<<<<<<
            // 明細備考
            // 2008.01.17 追加 >>>>>>>>>>>>>>>>>>>>
            stockAdjustDtl.DtlNote = (dataRow[ctCOL_DtlNote] != DBNull.Value) ? (string)dataRow[ctCOL_DtlNote] : "";
            // 2008.01.17 追加 <<<<<<<<<<<<<<<<<<<<

            // 2007.10.11 追加 >>>>>>>>>>>>>>>>>>>>
            // 倉庫コード
            stockAdjustDtl.WarehouseCode = (dataRow[ctCOL_WarehouseCode] != DBNull.Value) ? (string)dataRow[ctCOL_WarehouseCode] : "";
            // 倉庫名称
            stockAdjustDtl.WarehouseName = (dataRow[ctCOL_WarehouseName] != DBNull.Value) ? (string)dataRow[ctCOL_WarehouseName] : "";
            // 倉庫棚番
            stockAdjustDtl.WarehouseShelfNo = (dataRow[ctCOL_WarehouseShelfNo] != DBNull.Value) ? (string)dataRow[ctCOL_WarehouseShelfNo] : "";
            // ＢＬ商品コード
            stockAdjustDtl.BLGoodsCode = (dataRow[ctCOL_BLGoodsCode] != DBNull.Value) ? (Int32)dataRow[ctCOL_BLGoodsCode] : 0;
            // 2007.10.11 追加 <<<<<<<<<<<<<<<<<<<<

            // 2008.02.15 追加 >>>>>>>>>>>>>>>>>>>>
            // 定価
            stockAdjustDtl.ListPriceFl = GetGoodsListPrice(stockAdjustDtl.EnterpriseCode, stockAdjustDtl.GoodsMakerCd, stockAdjustDtl.GoodsNo, stockAdjustDtl.AdjustDate);
            // 2008.02.15 追加 <<<<<<<<<<<<<<<<<<<<

            return stockAdjustDtl;
        }
           --- DEL 2008/07/24 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/07/24 Partsman用に変更

        #region 2007.10.11 削除
        // 2007.10.11 削除 >>>>>>>>>>>>>>>>>>>>
        #region 製番在庫データ変換処理(DataRow→ワーク)
        /*
		/// <summary>
		/// 製番在庫データ変換処理(DataRow→ワーク)
		/// </summary>
		/// <param name="dataRow"></param>
		/// <returns></returns>
		private static ProductStockWork DataRowToSlipDtlWork(DataRow dataRow)
		{
			ProductStockWork productStockWork = new ProductStockWork();

			// 作成日時
			productStockWork.CreateDateTime = (dataRow[ctCOL_CreateDateTime] != DBNull.Value) ? (DateTime)dataRow[ctCOL_CreateDateTime] : DateTime.MinValue;
			// 更新日時
			productStockWork.UpdateDateTime = (dataRow[ctCOL_UpdateDateTime] != DBNull.Value) ? (DateTime)dataRow[ctCOL_UpdateDateTime] : DateTime.MinValue;
			// 企業コード
			productStockWork.EnterpriseCode = (dataRow[ctCOL_EnterpriseCode] != DBNull.Value) ? (string)dataRow[ctCOL_EnterpriseCode] : "";
			// GUID
			productStockWork.FileHeaderGuid = (dataRow[ctCOL_FileHeaderGuid] != DBNull.Value) ? (Guid)dataRow[ctCOL_FileHeaderGuid] : Guid.Empty;
			// 更新従業員コード
			productStockWork.UpdEmployeeCode = (dataRow[ctCOL_UpdEmployeeCode] != DBNull.Value) ? (string)dataRow[ctCOL_UpdEmployeeCode] : "";
			// 更新アセンブリID1
			productStockWork.UpdAssemblyId1 = (dataRow[ctCOL_UpdAssemblyId1] != DBNull.Value) ? (string)dataRow[ctCOL_UpdAssemblyId1] : "";
			// 更新アセンブリID2
			productStockWork.UpdAssemblyId2 = (dataRow[ctCOL_UpdAssemblyId2] != DBNull.Value) ? (string)dataRow[ctCOL_UpdAssemblyId2] : "";
			// 論理削除区分
			productStockWork.LogicalDeleteCode = (dataRow[ctCOL_LogicalDeleteCode] != DBNull.Value) ? (Int32)dataRow[ctCOL_LogicalDeleteCode] : 0;
            // 拠点コード
            productStockWork.SectionCode = (dataRow[ctCOL_SectionCode] != DBNull.Value) ? (string)dataRow[ctCOL_SectionCode] : "";
            // メーカーコード
            productStockWork.MakerCode = (dataRow[ctCOL_MakerCode] != DBNull.Value) ? (Int32)dataRow[ctCOL_MakerCode] : 0;
            // 商品コード
            productStockWork.GoodsCode = (dataRow[ctCOL_GoodsCode] != DBNull.Value) ? (string)dataRow[ctCOL_GoodsCode] : "";
            // 商品名称
            productStockWork.GoodsName = (dataRow[ctCOL_GoodsName] != DBNull.Value) ? (string)dataRow[ctCOL_GoodsName] : "";
            // 製造番号
            productStockWork.ProductNumber = (dataRow[ctCOL_ProductNumber] != DBNull.Value) ? (string)dataRow[ctCOL_ProductNumber] : "";
            // 製造番号マスタGUID
            productStockWork.ProductStockGuid = (dataRow[ctCOL_ProductStockGuid] != DBNull.Value) ? (Guid)dataRow[ctCOL_ProductNumber] : Guid.Empty;
            // 在庫区分
            productStockWork.StockDiv = (dataRow[ctCOL_StockDiv] != DBNull.Value) ? (Int32)dataRow[ctCOL_StockDiv] : 0;
            // 倉庫コード
            productStockWork.WarehouseCode = (dataRow[ctCOL_WarehouseCode] != DBNull.Value) ? (string)dataRow[ctCOL_WarehouseCode] : "";
            // 倉庫名称
            productStockWork.WarehouseName = (dataRow[ctCOL_WarehouseName] != DBNull.Value) ? (string)dataRow[ctCOL_WarehouseName] : "";
            // 事業者コード
            productStockWork.CarrierEpCode = (dataRow[ctCOL_CarrierEpCode] != DBNull.Value) ? (Int32)dataRow[ctCOL_CarrierEpCode] : 0;
            // 事業者名称
            productStockWork.CarrierEpName = (dataRow[ctCOL_CarrierEpName] != DBNull.Value) ? (string)dataRow[ctCOL_CarrierEpName] : "";
            // 得意先コード
            productStockWork.CustomerCode = (dataRow[ctCOL_CustomerCode] != DBNull.Value) ? (Int32)dataRow[ctCOL_CustomerCode] : 0;
            // 得意先名称
            productStockWork.CustomerName = (dataRow[ctCOL_CustomerName] != DBNull.Value) ? (string)dataRow[ctCOL_CustomerName] : "";
            // 得意先名称2
            productStockWork.CustomerName2 = (dataRow[ctCOL_CustomerName2] != DBNull.Value) ? (string)dataRow[ctCOL_CustomerName2] : "";
            // 仕入日
            productStockWork.StockDate = (dataRow[ctCOL_StockDate] != DBNull.Value) ? (DateTime)dataRow[ctCOL_StockDate] : DateTime.MinValue;
            // 入荷日
            productStockWork.ArrivalGoodsDay = (dataRow[ctCOL_ArrivalGoodsDay] != DBNull.Value) ? (DateTime)dataRow[ctCOL_ArrivalGoodsDay] : DateTime.MinValue;
            // 仕入単価
            productStockWork.StockUnitPrice = (dataRow[ctCOL_StockUnitPrice] != DBNull.Value) ? (Int64)dataRow[ctCOL_StockUnitPrice] : 0;
            // 課税区分
            productStockWork.TaxationCode = (dataRow[ctCOL_TaxationCode] != DBNull.Value) ? (Int32)dataRow[ctCOL_TaxationCode] : 0;
            // 在庫状態
            productStockWork.StockState = (dataRow[ctCOL_StockState] != DBNull.Value) ? (Int32)dataRow[ctCOL_StockState] : 0;
            // 移動状態
            productStockWork.MoveStatus = (dataRow[ctCOL_MoveStatus] != DBNull.Value) ? (Int32)dataRow[ctCOL_MoveStatus] : 0;
            // 商品状態
            productStockWork.GoodsCodeStatus = (dataRow[ctCOL_GoodsCodeStatus] != DBNull.Value) ? (Int32)dataRow[ctCOL_GoodsCodeStatus] : 0;
            // 商品電話番号1
            productStockWork.StockTelNo1 = (dataRow[ctCOL_StockTelNo1] != DBNull.Value) ? (string)dataRow[ctCOL_StockTelNo1] : "";
            // 商品電話番号2
            productStockWork.StockTelNo2 = (dataRow[ctCOL_StockTelNo2] != DBNull.Value) ? (string)dataRow[ctCOL_StockTelNo2] : "";
            // ロム区分
            productStockWork.RomDiv = (dataRow[ctCOL_RomDiv] != DBNull.Value) ? (Int32)dataRow[ctCOL_RomDiv] : 0;
            // 機種コード
            productStockWork.CellphoneModelCode = (dataRow[ctCOL_CellphoneModelCode] != DBNull.Value) ? (string)dataRow[ctCOL_CellphoneModelCode] : "";
            // 機種名称
            productStockWork.CellphoneModelName = (dataRow[ctCOL_CellphoneModelName] != DBNull.Value) ? (string)dataRow[ctCOL_CellphoneModelName] : "";
            // キャリアコード
            productStockWork.CarrierCode = (dataRow[ctCOL_CarrierCode] != DBNull.Value) ? (Int32)dataRow[ctCOL_CarrierCode] : 0;
            // キャリア名称
            productStockWork.CarrierName = (dataRow[ctCOL_CarrierName] != DBNull.Value) ? (string)dataRow[ctCOL_CarrierName] : "";
            // メーカー名称
            productStockWork.MakerName = (dataRow[ctCOL_MakerName] != DBNull.Value) ? (string)dataRow[ctCOL_MakerName] : "";
            // 系統色コード
            productStockWork.SystematicColorCd = (dataRow[ctCOL_SystematicColorCd] != DBNull.Value) ? (Int32)dataRow[ctCOL_SystematicColorCd] : 0;
            // 系統色名称
            productStockWork.SystematicColorNm = (dataRow[ctCOL_SystematicColorNm] != DBNull.Value) ? (string)dataRow[ctCOL_SystematicColorNm] : "";
            // 商品大分類コード
            productStockWork.LargeGoodsGanreCode = (dataRow[ctCOL_LargeGoodsGanreCode] != DBNull.Value) ? (string)dataRow[ctCOL_LargeGoodsGanreCode] : "";
            // 商品中分類コード
            productStockWork.MediumGoodsGanreCode = (dataRow[ctCOL_MediumGoodsGanreCode] != DBNull.Value) ? (string)dataRow[ctCOL_MediumGoodsGanreCode] : "";
            // 出荷先得意先コード
            productStockWork.ShipCustomerCode = (dataRow[ctCOL_ShipCustomerCode] != DBNull.Value) ? (Int32)dataRow[ctCOL_ShipCustomerCode] : 0;
            // 出荷先得意先名称
            productStockWork.ShipCustomerName = (dataRow[ctCOL_ShipCustomerName] != DBNull.Value) ? (string)dataRow[ctCOL_ShipCustomerName] : "";
            // 出荷先得意先名称2
            productStockWork.ShipCustomerName2 = (dataRow[ctCOL_ShipCustomerName2] != DBNull.Value) ? (string)dataRow[ctCOL_ShipCustomerName2] : "";
			return productStockWork;
		}
        */
		#endregion
        // 2007.10.11 削除 <<<<<<<<<<<<<<<<<<<<
        #endregion

        #region DEL 2008/07/24 Partsman用に変更
        /* --- DEL 2008/07/24 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// 在庫データ変換処理(ワーク→UIデータ)
        /// </summary>
        /// <param name="ptSuplSlipWork"></param>
        private static Stock CopyToStockDataFromStockWork(StockWork stockWork)
        {
            // 在庫データクラスを宣言
            Stock stock = null;

            // 在庫ワークオブジェクトが存在するか？
            if (stockWork != null)
            {
                // 在庫データクラスをインスタンス化
                stock = new Stock();

                stock.CreateDateTime = stockWork.CreateDateTime;
                stock.UpdateDateTime = stockWork.UpdateDateTime;
                stock.EnterpriseCode = stockWork.EnterpriseCode;
                stock.FileHeaderGuid = stockWork.FileHeaderGuid;
                stock.UpdEmployeeCode = stockWork.UpdEmployeeCode;
                stock.UpdAssemblyId1 = stockWork.UpdAssemblyId1;
                stock.UpdAssemblyId2 = stockWork.UpdAssemblyId2;
                stock.LogicalDeleteCode = stockWork.LogicalDeleteCode;

                stock.LogicalDeleteCode = stockWork.LogicalDeleteCode;
                stock.SectionCode = stockWork.SectionCode;
                // 2007.10.11 修正 >>>>>>>>>>>>>>>>>>>>
                //stock.MakerCode = stockWork.MakerCode;
                //stock.GoodsCode = stockWork.GoodsCode;
                stock.GoodsMakerCd = stockWork.GoodsMakerCd;
                stock.GoodsNo = stockWork.GoodsNo;
                // 2007.10.11 修正 <<<<<<<<<<<<<<<<<<<<
                stock.GoodsName = stockWork.GoodsName;
                // 2007.10.11 修正 >>>>>>>>>>>>>>>>>>>>
                //stock.StockUnitPrice = stockWork.StockUnitPrice;
                //stock.CellphoneModelCode = stockWork.CellphoneModelCode;
                //stock.CellphoneModelName = stockWork.CellphoneModelName;
                //stock.CarrierCode = stockWork.CarrierCode;
                //stock.CarrierName = stockWork.CarrierName;
                //stock.MakerName = stockWork.MakerName;
                //stock.SystematicColorCd = stockWork.SystematicColorCd;
                //stock.SystematicColorNm = stockWork.SystematicColorNm;
                //stock.LargeGoodsGanreCode = stockWork.LargeGoodsGanreCode;
                //stock.MediumGoodsGanreCode = stockWork.MediumGoodsGanreCode;

                stock.StockUnitPriceFl = stockWork.StockUnitPriceFl;
                stock.MakerName = stockWork.MakerName;
                //                stock.LargeGoodsGanreCode = stockWork.LargeGoodsGanreCode;
                //                stock.MediumGoodsGanreCode = stockWork.MediumGoodsGanreCode;
                // 2007.10.11 修正 <<<<<<<<<<<<<<<<<<<<
            }

            return stock;
        }
           --- DEL 2008/07/24 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/07/24 Partsman用に変更

        #region DEL 2008/07/24 使用していないのでコメントアウト
        #region 在庫データ変換処理(UIデータ→ワーク)
        /* --- DEL 2008/07/24 --------------------------------------------------------------------->>>>>
        /// <summary>
		/// 在庫データ変換処理(UIデータ→ワーク)
		/// </summary>
		/// <param name="productStock"></param>
		/// <returns></returns>
        // 2007.10.11 修正 >>>>>>>>>>>>>>>>>>>>
        //private StockWork CopyToStockWorkFromStock(StockEachWarehouse stock,int mode)
        private StockWork CopyToStockWorkFromStock(StockExpansion stock, int mode)
        // 2007.10.11 修正 <<<<<<<<<<<<<<<<<<<<
        {
			// 在庫ワーククラスを宣言
			StockWork stockWork = null;

			// 在庫データオブジェクトが存在するか？
			if (stock != null)
			{
				// 在庫データクラスをインスタンス化
				stockWork = new StockWork();

                stockWork.CreateDateTime = stock.CreateDateTime;
                stockWork.UpdateDateTime = stock.UpdateDateTime;                
                stockWork.EnterpriseCode = stock.EnterpriseCode;
                stockWork.FileHeaderGuid = stock.FileHeaderGuid;
                stockWork.UpdEmployeeCode = stock.UpdEmployeeCode;
                stockWork.UpdAssemblyId1 = stock.UpdAssemblyId1;
                stockWork.UpdAssemblyId2 = stock.UpdAssemblyId2;
                stockWork.LogicalDeleteCode = stock.LogicalDeleteCode;
                stockWork.SectionCode = stock.SectionCode;
                // 2007.10.11 修正 >>>>>>>>>>>>>>>>>>>>
                //stockWork.MakerCode = stock.MakerCode;
                //stockWork.GoodsCode = stock.GoodsCode;
                stockWork.GoodsMakerCd = stock.GoodsMakerCd;
                stockWork.GoodsNo = stock.GoodsNo;
                // 2007.10.11 修正 <<<<<<<<<<<<<<<<<<<<
                stockWork.GoodsName = stock.GoodsName;

                // 2007.10.11 修正 >>>>>>>>>>>>>>>>>>>>
                //調整・調整金額を反映
                //画面から、GUIDを参照して調整数・調整金額を引当
                double setCount = stock.SupplierStock;
                double setTrust = stock.TrustCount;
                double setEnable = stock.ShipmentPosCnt;
                // 2007.10.11 修正 <<<<<<<<<<<<<<<<<<<<

                // 2007.10.11 修正 >>>>>>>>>>>>>>>>>>>>
                //Int64 setPrice;
                double setPrice;
                // 2007.10.11 修正 <<<<<<<<<<<<<<<<<<<<
                Int64 setMinusPrice = 0;
                Int64 setBfPrice = 0;
                if ((GetStockPointWay() == 3) && ((mode == ctMode_StockAdjust) || (mode == ctMode_UnitPriceReEdit)))
                {
                    // 個別単価法の在庫調整/原価調整の時金額を集計する。
                     setPrice = 0;
                     setMinusPrice = 0;
                }
                else
                {
                    // 2007.10.11 修正 >>>>>>>>>>>>>>>>>>>>
                    //setPrice = stock.StockUnitPrice;
                    setPrice = stock.StockUnitPriceFl;
                    // 2007.10.11 修正 <<<<<<<<<<<<<<<<<<<<
                }

                for (int i = 0; i < _mainProductStock.Rows.Count; i++)
                {
                    if (_mainProductStock.Rows[i][ctCOL_FileHeaderGuid] == DBNull.Value)
                    {
                        continue;
                    }
                    if (((System.Guid)_mainProductStock.Rows[i][ctCOL_FileHeaderGuid] == null) || (System.Guid)_mainProductStock.Rows[i][ctCOL_FileHeaderGuid] ==(Guid.Empty))
                    {
                        continue;
                    }

                    // 商品グロス時はGuid一致
                    // 2007.10.11 削除 >>>>>>>>>>>>>>>>>>>>
                    //if (stock.FileHeaderGuid == (System.Guid)_mainProductStock.Rows[i][ctCOL_FileHeaderGuid])
                    //{
                    // 2007.10.11 削除 <<<<<<<<<<<<<<<<<<<<

                        // 2008.01.17 修正 >>>>>>>>>>>>>>>>>>>>
                        //if ((mode == ctMode_StockAdjust) || (mode == ctMode_TrustAdjust))
                        if (mode == ctMode_StockAdjust)
                        // 2008.01.17 修正 <<<<<<<<<<<<<<<<<<<<
                        {
                            if (_mainProductStock.Rows[i][ctCOL_AdjustCount] != DBNull.Value)
                            {
                                if (mode == ctMode_StockAdjust)
                                {
                                    // 2008.01.17 修正 >>>>>>>>>>>>>>>>>>>>
                                    //setCount = setCount + (double)_mainProductStock.Rows[i][ctCOL_AdjustCount];
                                    //setEnable = setEnable + (double)_mainProductStock.Rows[i][ctCOL_AdjustCount];
                                    setCount = (double)_mainProductStock.Rows[i][ctCOL_AdjustCount];
                                    setEnable = setEnable + (double)_mainProductStock.Rows[i][ctCOL_AdjustCount];
                                    // 2008.01.17 修正 <<<<<<<<<<<<<<<<<<<<
                                }
                                // 2008.01.17 削除 >>>>>>>>>>>>>>>>>>>>
                                //else if (mode == ctMode_TrustAdjust)
                                //{
                                //    setTrust = setTrust + (double)_mainProductStock.Rows[i][ctCOL_AdjustCount];
                                //    setEnable = setEnable + (double)_mainProductStock.Rows[i][ctCOL_AdjustCount];
                                //}
                                // 2008.01.17 削除 <<<<<<<<<<<<<<<<<<<<
                            }
                            else
                            {
                                //値が入っていない=変更しない
                                setCount = stock.SupplierStock;
                                setTrust = stock.TrustCount;
                                setEnable = stock.SupplierStock;
                            }
                        }

                        //仕入単価
                        // 2008.01.17 修正 >>>>>>>>>>>>>>>>>>>>
                        //setPrice = (Int64)_mainProductStock.Rows[i][ctCOL_StockUnitPrice];
                        setPrice = (Double)_mainProductStock.Rows[i][ctCOL_StockUnitPrice];
                        // 2008.01.17 修正 <<<<<<<<<<<<<<<<<<<<

                    // 2007.10.11 削除 >>>>>>>>>>>>>>>>>>>>
                    //}
                    //else
                    //// 製番単位
                    //{
                    //    if ((mode == ctMode_StockAdjust) || (mode == ctMode_TrustAdjust))
                    //    {
                    //        if (_mainProductStock.Rows[i][ctCOL_AdjustCount] != DBNull.Value)
                    //        {
                    //            if (mode == ctMode_StockAdjust)
                    //            {
                    //                setCount = setCount + (double)_mainProductStock.Rows[i][ctCOL_AdjustCount];
                    //                setEnable = setEnable + (double)_mainProductStock.Rows[i][ctCOL_AdjustCount];
                    //            }
                    //            else if (mode == ctMode_TrustAdjust)
                    //            {
                    //                setTrust = setTrust + (double)_mainProductStock.Rows[i][ctCOL_AdjustCount];
                    //                setEnable = setEnable + (double)_mainProductStock.Rows[i][ctCOL_AdjustCount];
                    //            }
                    //        }
                    //        else
                    //        {
                    //            //値が入っていない=変更しない
                    //            setCount = stock.SupplierStock;
                    //            setTrust = stock.TrustCount;
                    //            setEnable = stock.SupplierStock;
                    //        }
                    //    }
                    //    //個別単価法で仕入調整/原価調整(製番単位)は減算する金額分集計
                    //    if ((GetStockPointWay() == 3) && ((mode == ctMode_StockAdjust)||(mode == ctMode_UnitPriceReEdit)))
                    //    {
                    //        if ((stock.GoodsCode == (string)_mainProductStock.Rows[i][ctCOL_GoodsCode]) &&
                    //            (stock.MakerCode == (int)_mainProductStock.Rows[i][ctCOL_MakerCode]))
                    //        {
                    //            setPrice = setPrice + (Int64)_mainProductStock.Rows[i][ctCOL_StockUnitPrice];
                    //            setMinusPrice = setMinusPrice + (Int64)_mainProductStock.Rows[i][ctCOL_StockUnitPrice];
                    //            setBfPrice = setBfPrice + (Int64)_mainProductStock.Rows[i][ctCOL_BfStockUnitPrice];
                    //        }
                    //    }
                    //    else
                    //    {
                    //        if ((stock.GoodsCode == (string)_mainProductStock.Rows[i][ctCOL_GoodsCode]) &&
                    //            (stock.MakerCode == (int)_mainProductStock.Rows[i][ctCOL_MakerCode]))
                    //        {
                    //            //仕入単価
                    //            setPrice = (Int64)_mainProductStock.Rows[i][ctCOL_StockUnitPrice];
                    //        }
                    //    }
                    //}
                    // 2007.10.11 削除 <<<<<<<<<<<<<<<<<<<<
                }
                
                stockWork.SupplierStock = setCount; //仕入在庫数
                stockWork.TrustCount = setTrust;　　//受託在庫数　

                //------------------------------
                // 在庫総額計算 / 仕入単価設定
                //------------------------------
                #region
                if ((mode == ctMode_StockAdjust) || (mode == ctMode_UnitPriceReEdit))//在庫調整もしくは原価調整のみ
                {
                    // 2007.10.11 修正 >>>>>>>>>>>>>>>>>>>>
                    //Stock chkStock = new Stock();
                    ////在庫情報呼出
                    //GetStockInf(out chkStock, stock.GoodsCode, stock.MakerCode, mode);
                    StockExpansion chkStock = new StockExpansion();
                    //在庫情報呼出
                    GetStockInf(out chkStock, stock.GoodsNo, stock.GoodsMakerCd, stock.WarehouseCode, mode);
                    // 2007.10.11 修正 <<<<<<<<<<<<<<<<<<<<

                    double totalPrice = 0;

                    if (GetStockPointWay() == 1)
                    //----------------
                    // 最終仕入法
                    //----------------
                    {                        
                        //--- 仕入単価 ---//
                        if ((chkStock.LastStockDate <= GetDate()) && (mode == ctMode_UnitPriceReEdit))
                        {                            
                            // 単価変更せず
                            // 2007.10.11 修正 >>>>>>>>>>>>>>>>>>>>
                            //stockWork.StockUnitPrice = setPrice;
                            stockWork.StockUnitPriceFl = setPrice;
                            // 2007.10.11 修正 <<<<<<<<<<<<<<<<<<<<
                        }
                        else
                        {
                            // 単価変更せず
                            // 2007.10.11 修正 >>>>>>>>>>>>>>>>>>>>
                            //stockWork.StockUnitPrice = chkStock.StockUnitPrice;
                            stockWork.StockUnitPriceFl = chkStock.StockUnitPriceFl;
                            // 2007.10.11 修正 <<<<<<<<<<<<<<<<<<<<
                        }

                        //--- 総額 ---//
                        
                        // 最終仕入法時、在庫総額=仕入単価*在庫数(調整後)
                        // 2007.10.11 修正 >>>>>>>>>>>>>>>>>>>>
                        //totalPrice = (stockWork.StockUnitPrice * stockWork.SupplierStock);
                        totalPrice = (stockWork.StockUnitPriceFl * stockWork.SupplierStock);
                        // 2007.10.11 修正 <<<<<<<<<<<<<<<<<<<<
                        stockWork.StockTotalPrice = (long)totalPrice;
                    }
                    else if (GetStockPointWay() == 3)
                    //--------------
                    // 個別単価法
                    //--------------
                    {
                        if (mode == ctMode_UnitPriceReEdit)
                        //原価調整
                        {                                                
                            //--- 総額 ---//
                            double tgtPrice = chkStock.StockTotalPrice;//元の総額
                            totalPrice = tgtPrice - (setBfPrice - setMinusPrice);//元の総保有額-減額分(製番単位の総計)

                            stockWork.StockTotalPrice = (long)totalPrice; //新在庫総額
                            
                            //--- 仕入単価 ---//
                            if ((totalPrice != 0) && (stockWork.SupplierStock != 0))
                            {
                                // 単価 = (新在庫総額) / 調整後数量
                                double calcRslt = totalPrice / stockWork.SupplierStock;
                                if (calcRslt != 0)
                                {
                                    // 2007.10.11 修正 >>>>>>>>>>>>>>>>>>>>
                                    //stockWork.StockUnitPrice = (Int64)CalculateConsTax.Fraction(calcRslt, GetFractionProcCd());
                                    stockWork.StockUnitPriceFl = (Int64)CalculateConsTax.Fraction(calcRslt, GetFractionProcCd());
                                    // 2007.10.11 修正 <<<<<<<<<<<<<<<<<<<<
                                }
                                else
                                {
                                    // 2007.10.11 修正 >>>>>>>>>>>>>>>>>>>>
                                    //stockWork.StockUnitPrice = 0;
                                    stockWork.StockUnitPriceFl = 0;
                                    // 2007.10.11 修正 <<<<<<<<<<<<<<<<<<<<
                                }
                            }
                            else
                            {
                                // 2007.10.11 修正 >>>>>>>>>>>>>>>>>>>>
                                //stockWork.StockUnitPrice = 0;
                                stockWork.StockUnitPriceFl = 0;
                                // 2007.10.11 修正 <<<<<<<<<<<<<<<<<<<<
                            }                            
                        }
                        else if (mode == ctMode_StockAdjust)
                        // 仕入在庫調整
                        {
                            //--- 在庫総額 ---//
                            double tgtPrice = chkStock.StockTotalPrice;
                            totalPrice = tgtPrice - setMinusPrice;
                            stockWork.StockTotalPrice = (long)totalPrice;

                            //--- 仕入単価 ---//
                            if ((totalPrice != 0) && (stockWork.SupplierStock) != 0)
                            {
                                double calcRslt = totalPrice / stockWork.SupplierStock;
                                if (calcRslt != 0)
                                {
                                    // 2007.10.11 修正 >>>>>>>>>>>>>>>>>>>>
                                    //stockWork.StockUnitPrice = (Int64)CalculateConsTax.Fraction(calcRslt, GetFractionProcCd());
                                    stockWork.StockUnitPriceFl = (Int64)CalculateConsTax.Fraction(calcRslt, GetFractionProcCd());
                                    // 2007.10.11 修正 <<<<<<<<<<<<<<<<<<<<
                                }
                            }
                            else
                            {
                                // 2007.10.11 修正 >>>>>>>>>>>>>>>>>>>>
                                //stockWork.StockUnitPrice = 0;
                                stockWork.StockUnitPriceFl = 0;
                                // 2007.10.11 修正 <<<<<<<<<<<<<<<<<<<<
                            }                        
                        }
                    }
                    else if (GetStockPointWay() == 2)
                    //---------------
                    // 移動平均法
                    //---------------
                    {   
                        // 保有総額に変更分を加味
                        double stockCount = 0;

                        if (mode == ctMode_StockAdjust) //在庫調整
                        {
                            //--- 総額 ---//
                            // 調整数= 現在の仕入在庫数 - 調整後数量 
                            stockCount = chkStock.SupplierStock - setCount;

                            // 移動平均法 在庫総額 = 現在の在庫総額 - (仕入単価 * 調整数)
                            // 2007.10.11 修正 >>>>>>>>>>>>>>>>>>>>
                            //totalPrice = chkStock.StockTotalPrice - (chkStock.StockUnitPrice * stockCount);
                            totalPrice = chkStock.StockTotalPrice - (chkStock.StockUnitPriceFl * stockCount);
                            // 2007.10.11 修正 <<<<<<<<<<<<<<<<<<<<
                            stockWork.StockTotalPrice = (long)totalPrice;

                            //--- 仕入金額 ---//　変更なし
                            // 2007.10.11 修正 >>>>>>>>>>>>>>>>>>>>
                            //stockWork.StockUnitPrice = chkStock.StockUnitPrice;
                            stockWork.StockUnitPriceFl = chkStock.StockUnitPriceFl;
                            // 2007.10.11 修正 <<<<<<<<<<<<<<<<<<<<
                        }
                        else if (mode == ctMode_UnitPriceReEdit) // 原価調整
                        {
                            //--- 総額 ---//
                            // 原価調整した金額の集計を総計からマイナス = 修正後総計
                            totalPrice = chkStock.StockTotalPrice - setMinusPrice;
                            stockWork.StockTotalPrice = (long)totalPrice;

                            //--- 仕入単価 ---//
                            if ((totalPrice != 0) && (stockWork.SupplierStock != 0)) //総計/個数
                            {
                                double calcRslt = totalPrice / chkStock.SupplierStock; //修正後総計 / 仕入在庫数 = 単価
                                // 2007.10.11 修正 >>>>>>>>>>>>>>>>>>>>
                                //stockWork.StockUnitPrice = (Int64)CalculateConsTax.Fraction(calcRslt, GetFractionProcCd());
                                stockWork.StockUnitPriceFl = (Int64)CalculateConsTax.Fraction(calcRslt, GetFractionProcCd());
                                // 2007.10.11 修正 <<<<<<<<<<<<<<<<<<<<
                            }
                            else
                            {
                                totalPrice = 0;
                                // 2007.10.11 修正 >>>>>>>>>>>>>>>>>>>>
                                //stockWork.StockUnitPrice = 0;
                                stockWork.StockUnitPriceFl = 0;
                                // 2007.10.11 修正 <<<<<<<<<<<<<<<<<<<<
                            }
                        }
                    }
                }
                else
                {
                    // 在庫調整・原価調整以外は元の値
                    // 2007.10.11 修正 >>>>>>>>>>>>>>>>>>>>
                    //stockWork.StockUnitPrice = stock.StockUnitPrice;
                    stockWork.StockUnitPriceFl = stock.StockUnitPriceFl;
                    // 2007.10.11 修正 <<<<<<<<<<<<<<<<<<<<
                    stockWork.StockTotalPrice = stock.StockTotalPrice;
                }
                #endregion

                // 2007.10.11 削除 >>>>>>>>>>>>>>>>>>>>
                //stockWork.ReservedCount = stock.ReservedCount;
                //stockWork.AllowStockCnt = stock.AllowStockCnt;
                // 2007.10.11 削除 <<<<<<<<<<<<<<<<<<<<
                stockWork.AcpOdrCount = stock.AcpOdrCount;
                stockWork.SalesOrderCount = stock.SalesOrderCount;
                stockWork.EntrustCnt = stock.EntrustCnt;
                stockWork.SoldCnt = stock.SoldCnt;
                stockWork.MovingSupliStock = stock.MovingSupliStock;
                stockWork.MovingTrustStock = stock.MovingTrustStock;
                
                stockWork.ShipmentPosCnt = setEnable;//調整数分SET

                // 2007.10.11 削除 >>>>>>>>>>>>>>>>>>>>
                //stockWork.PrdNumMngDiv = stock.PrdNumMngDiv;
                // 2007.10.11 削除 <<<<<<<<<<<<<<<<<<<<
                stockWork.LastStockDate = stock.LastStockDate;
                stockWork.LastSalesDate = stock.LastSalesDate;
                stockWork.LastInventoryUpdate = stock.LastInventoryUpdate;
                // 2007.10.11 削除 >>>>>>>>>>>>>>>>>>>>
                //stockWork.CellphoneModelCode = stock.CellphoneModelCode;
                //stockWork.CellphoneModelName = stock.CellphoneModelName;
                //stockWork.CarrierCode = stock.CarrierCode;
                //stockWork.CarrierName = stock.CarrierName;
                // 2007.10.11 削除 <<<<<<<<<<<<<<<<<<<<
                stockWork.MakerName = stock.MakerName;
                // 2007.10.11 削除 >>>>>>>>>>>>>>>>>>>>
                //stockWork.SystematicColorCd = stock.SystematicColorCd;
                //stockWork.SystematicColorNm = stock.SystematicColorNm;
                // 2007.10.11 削除 <<<<<<<<<<<<<<<<<<<<
                stockWork.LargeGoodsGanreCode = stock.LargeGoodsGanreCode;
                stockWork.MediumGoodsGanreCode = stock.MediumGoodsGanreCode;
                stockWork.MinimumStockCnt = stock.MinimumStockCnt;
                stockWork.MaximumStockCnt = stock.MaximumStockCnt;
                stockWork.NmlSalOdrCount = stock.NmlSalOdrCount;
                // 2007.10.11 削除 >>>>>>>>>>>>>>>>>>>>
                //stockWork.SalOdrLot = stock.SalOdrLot;
                // 2007.10.11 削除 <<<<<<<<<<<<<<<<<<<<

                // 2007.10.11 追加 >>>>>>>>>>>>>>>>>>>>
                stockWork.SalesOrderUnit = stock.SalesOrderUnit;

                stockWork.WarehouseCode = stock.WarehouseCode;
                stockWork.WarehouseName = stock.WarehouseName;
                stockWork.GoodsNoNoneHyphen = stock.GoodsNoNoneHyphen;
                stockWork.StockAssessmentRate = stock.StockAssessmentRate;

                //棚番調整
                stockWork.WarehouseShelfNo = stock.WarehouseShelfNo;
                if (mode == ctMode_ShelfNoReEdit)
                {
                    for (int i = 0; i < _mainProductStock.Rows.Count; i++)
                    {
                        if (_mainProductStock.Rows[i][ctCOL_FileHeaderGuid] == DBNull.Value) continue;
                        if ((System.Guid)_mainProductStock.Rows[i][ctCOL_FileHeaderGuid] == (System.Guid)stock.FileHeaderGuid)
                        {
                            // 2008.03.28 修正 >>>>>>>>>>>>>>>>>>>>
                            //stockWork.WarehouseShelfNo = (string)_mainProductStock.Rows[i][ctCOL_WarehouseShelfNo];
                            if ((_mainProductStock.Rows[i][ctCOL_WarehouseShelfNo] == null) ||
                                ((string)_mainProductStock.Rows[i][ctCOL_WarehouseShelfNo].ToString().Trim() == string.Empty))
                            {
                                stockWork.WarehouseShelfNo = string.Empty;
                            }
                            else
                            {
                                stockWork.WarehouseShelfNo = (string)_mainProductStock.Rows[i][ctCOL_WarehouseShelfNo];
                            }
                            // 2008.03.28 修正 <<<<<<<<<<<<<<<<<<<<
                        }
                    }
                }
                stockWork.DuplicationShelfNo1 = stock.DuplicationShelfNo1;
                stockWork.DuplicationShelfNo2 = stock.DuplicationShelfNo2;
                stockWork.PartsManagementDivide1 = stock.PartsManagementDivide1;
                stockWork.PartsManagementDivide2 = stock.PartsManagementDivide2;
                stockWork.StockNote1 = stock.StockNote1;
                stockWork.StockNote2 = stock.StockNote2;
                stockWork.ShipmentCnt = stock.ShipmentCnt;
                stockWork.ArrivalCnt = stock.ArrivalCnt;
                stockWork.StockCreateDate = stock.StockCreateDate;

                stockWork.LargeGoodsGanreName = stock.LargeGoodsGanreName;
                stockWork.MediumGoodsGanreName = stock.MediumGoodsGanreName;
                stockWork.DetailGoodsGanreCode = stock.DetailGoodsGanreCode;
                stockWork.DetailGoodsGanreName = stock.DetailGoodsGanreName;
                stockWork.BLGoodsCode = stock.BLGoodsCode;
                stockWork.BLGoodsFullName = stock.BLGoodsFullName;
//                stockWork.GoodsShortName = stock.GoodsShortName;
//                stockWork.GoodsNameKana = stock.GoodsNameKana;
                stockWork.EnterpriseGanreCode = stock.EnterpriseGanreCode;
                stockWork.EnterpriseGanreName = stock.EnterpriseGanreName;
//                stockWork.Jan = stock.Jan;
                // 2007.10.11 追加 <<<<<<<<<<<<<<<<<<<<
            }

            return stockWork;
		}

        // 2007.10.11 修正 >>>>>>>>>>>>>>>>>>>>
        //private static void GetStockInf(out Stock chkStock, string goodsCode, int makerCode, int mode)
        private static void GetStockInf(out StockExpansion chkStock, string goodsNo, int makerCode, string warehouseCode, int mode)
        // 2007.10.11 修正 <<<<<<<<<<<<<<<<<<<<
        {
            // 商品検索ガイド画面のインスタンスを生成
            SearchStockAcs searchStochAch = new SearchStockAcs();
            
            // 商品検索ガイド検索条件データ
            StockSearchPara stockSearchPara = new StockSearchPara();
            stockSearchPara.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            stockSearchPara.SectionCode = GetSection();
            // 2007.10.11 削除 >>>>>>>>>>>>>>>>>>>>
            #region 2007.10.11 削除
            //// 在庫状態                    
            //if (mode == 0)
            //{
            //    // 0:在庫,10:受託中,20:委託中,30:売切,50:売上計上済,60:予約中,70:返品,80:抜出,81:消去
            //    int[] stockState = { (int)ConstantManagement_Mobile.ct_StockState.SupplierStock,
            //                 (int)ConstantManagement_Mobile.ct_StockState.Reserving,
            //                 (int)ConstantManagement_Mobile.ct_StockState.PullingOut};
            //    stockSearchPara.StockState = stockState;
            //}
            //else if (mode == 1)
            //{
            //    // 0:在庫,10:受託中,20:委託中,30:売切,50:売上計上済,60:予約中,70:返品,80:抜出,81:消去
            //    int[] stockState = { (int)ConstantManagement_Mobile.ct_StockState.Entrusting,
            //                 (int)ConstantManagement_Mobile.ct_StockState.Reserving,
            //                 (int)ConstantManagement_Mobile.ct_StockState.PullingOut};
            //    stockSearchPara.StockState = stockState;
            //}
            //else
            //{
            //    int[] stockState = { (int)ConstantManagement_Mobile.ct_StockState.SupplierStock,
            //                 (int)ConstantManagement_Mobile.ct_StockState.Entrusting,
            //                 (int)ConstantManagement_Mobile.ct_StockState.Reserving,
            //                 (int)ConstantManagement_Mobile.ct_StockState.PullingOut};
            //    stockSearchPara.StockState = stockState;
            //}
            //// 移動状態
            //// 0:移動対象外,1:未出荷状態,2:移動中,9:入荷済
            //int[] moveStatus = { 0 };
            //stockSearchPara.MoveStatus = moveStatus;
            #endregion
            // 2007.10.11 削除 <<<<<<<<<<<<<<<<<<<<

            // ゼロ在庫表示(0:表示する 1:表示しない)
            // 2008.03.21 修正 >>>>>>>>>>>>>>>>>>>>
            //stockSearchPara.ZeroStckDsp = 1;
            stockSearchPara.ZeroStckDsp = 0;
            // 2008.03.21 修正 <<<<<<<<<<<<<<<<<<<<

            // 2007.10.11 修正 >>>>>>>>>>>>>>>>>>>>
            //stockSearchPara.GoodsCodeSrchTyp = 0; //完全一致のみ
            stockSearchPara.GoodsNoSrchTyp = 0; //完全一致のみ
            // 2007.10.11 修正 <<<<<<<<<<<<<<<<<<<<
            // 2007.10.11 削除 >>>>>>>>>>>>>>>>>>>>
            //if (mode == ctMode_ProductReEdit)
            //{
            //    //                    stockSearchPara.ProductNumberSrchDivCd = 1; //製番ありのみ検索
            //}
            // 2007.10.11 削除 <<<<<<<<<<<<<<<<<<<<
            // 商品コード
            // 2007.10.11 修正 >>>>>>>>>>>>>>>>>>>>
            //stockSearchPara.GoodsCode = goodsCode;
            //stockSearchPara.MakerCode = makerCode;
            stockSearchPara.GoodsNo = goodsNo;
            stockSearchPara.GoodsMakerCd = makerCode;
            stockSearchPara.WarehouseCode = warehouseCode;
            // 2007.10.11 修正 <<<<<<<<<<<<<<<<<<<<

            // 2007.10.11 修正 >>>>>>>>>>>>>>>>>>>>
            //List<Stock> stockSearchRetList = new List<Stock>();
            //List<ProductStock> productStockSearchRetList = new List<ProductStock>();
            List<StockExpansion> stockSearchRetList = new List<StockExpansion>();
            // 2007.10.11 修正 <<<<<<<<<<<<<<<<<<<<
            string msg = "";

            // 2007.10.11 修正 >>>>>>>>>>>>>>>>>>>>
            //int st = searchStochAch.Search(stockSearchPara, out stockSearchRetList, out productStockSearchRetList, out msg);
            int st = searchStochAch.Search(stockSearchPara, out stockSearchRetList, out msg);
            // 2007.10.11 修正 <<<<<<<<<<<<<<<<<<<<

            if (stockSearchRetList.Count > 1)
            {
                chkStock = null;
                return;
            }
            else if (stockSearchRetList.Count == 0)
            {
                chkStock = null;
                return;
            }
            chkStock = stockSearchRetList[0];
        }
           --- DEL 2008/07/24 ---------------------------------------------------------------------<<<<<*/
        #endregion
        #endregion DEL 2008/07/24 使用していないのでコメントアウト

        #region 2007.10.11 削除
        // 2007.10.11 削除 >>>>>>>>>>>>>>>>>>>>
        #region 製番在庫データ変換処理(UIデータ→ワーク)
        /*
        /// <summary>
        /// 製番在庫データ変換処理(UIデータ→ワーク)
        /// </summary>
        /// <param name="productStock"></param>
        /// <returns></returns>
        private static ProductStockWork CopyToProductWorkFromProductStock(ProductStock productStock)
        {
            // 製番在庫ワーククラス宣言
            ProductStockWork ptProductStockWork = null;

            // 製番在庫オブジェクトが存在するか？
            if (productStock != null)
            {
                // 製番在庫データクラスをインスタンス化
                ptProductStockWork = new ProductStockWork();
                ptProductStockWork.CreateDateTime = productStock.CreateDateTime;
                ptProductStockWork.UpdateDateTime = productStock.UpdateDateTime;
                ptProductStockWork.EnterpriseCode = productStock.EnterpriseCode;
                ptProductStockWork.FileHeaderGuid = productStock.FileHeaderGuid;
                ptProductStockWork.UpdEmployeeCode = productStock.UpdEmployeeCode;
                ptProductStockWork.UpdAssemblyId1 = productStock.UpdAssemblyId1;
                ptProductStockWork.UpdAssemblyId2 = productStock.UpdAssemblyId2;
                ptProductStockWork.LogicalDeleteCode = productStock.LogicalDeleteCode;

                ptProductStockWork.SectionCode = productStock.SectionCode;
                ptProductStockWork.MakerCode = productStock.MakerCode;
                ptProductStockWork.GoodsCode = productStock.GoodsCode;
                ptProductStockWork.GoodsName = productStock.GoodsName;
                ptProductStockWork.ProductNumber = productStock.ProductNumber;
                ptProductStockWork.ProductStockGuid = productStock.ProductStockGuid;
                ptProductStockWork.StockDiv = productStock.StockDiv;
                ptProductStockWork.WarehouseCode = productStock.WarehouseCode;
                ptProductStockWork.WarehouseName = productStock.WarehouseName;
                ptProductStockWork.CarrierEpCode = productStock.CarrierEpCode;
                ptProductStockWork.CarrierEpName = productStock.CarrierEpName;
                ptProductStockWork.CustomerCode = productStock.CustomerCode;
                ptProductStockWork.CustomerName = productStock.CustomerName;
                ptProductStockWork.CustomerName2 = productStock.CustomerName2;
                ptProductStockWork.StockDate = productStock.StockDate;
                ptProductStockWork.ArrivalGoodsDay = productStock.ArrivalGoodsDay;
                ptProductStockWork.StockUnitPrice = productStock.StockUnitPrice;
                ptProductStockWork.TaxationCode = productStock.TaxationCode;
                ptProductStockWork.StockState = productStock.StockState;
                ptProductStockWork.MoveStatus = productStock.MoveStatus;
                ptProductStockWork.GoodsCodeStatus = productStock.GoodsCodeStatus;
                ptProductStockWork.StockTelNo1 = productStock.StockTelNo1;
                ptProductStockWork.StockTelNo2 = productStock.StockTelNo2;
                ptProductStockWork.RomDiv = productStock.RomDiv;
                ptProductStockWork.CellphoneModelCode = productStock.CellphoneModelCode;
                ptProductStockWork.CellphoneModelName = productStock.CellphoneModelName;
                ptProductStockWork.CarrierCode = productStock.CarrierCode;
                ptProductStockWork.CarrierName = productStock.CarrierName;
                ptProductStockWork.MakerName = productStock.MakerName;
                ptProductStockWork.SystematicColorCd = productStock.SystematicColorCd;
                ptProductStockWork.SystematicColorNm = productStock.SystematicColorNm;
                ptProductStockWork.LargeGoodsGanreCode = productStock.LargeGoodsGanreCode;
                ptProductStockWork.MediumGoodsGanreCode = productStock.MediumGoodsGanreCode;
                ptProductStockWork.ShipCustomerCode = productStock.ShipCustomerCode;
                ptProductStockWork.ShipCustomerName = productStock.ShipCustomerName;
                ptProductStockWork.ShipCustomerName2 = productStock.ShipCustomerName2;                                
            }            

            return ptProductStockWork;
        }
        */
        #endregion
        // 2007.10.11 削除 <<<<<<<<<<<<<<<<<<<<
        #endregion

        #region DEL 2008/07/24 使用していないのでコメントアウト
        /* --- DEL 2008/07/24 --------------------------------------------------------------------->>>>>
        #region 在庫調整データ変換処理(UIデータ→ワーク)
        /// <summary>
        /// 在庫調整データ変換処理(UIデータ→ワーク)
        /// </summary>
        /// <param name="productStock"></param>
        /// <returns></returns>
        private static StockAdjustWork CopyToStockAdjustWorkFromStockAdjust(StockAdjust stockAdjust)
        {
            // 在庫調整ワーククラス宣言
            StockAdjustWork ptStockAdjustWork = null;

            // 在庫調整オブジェクトが存在するか？
            if (stockAdjust != null)
            {
                // 在庫調整データクラスをインスタンス化
                ptStockAdjustWork = new StockAdjustWork();

                ptStockAdjustWork.EnterpriseCode = stockAdjust.EnterpriseCode;      // 企業コード
                ptStockAdjustWork.SectionCode = stockAdjust.SectionCode;            // 拠点コード
                ptStockAdjustWork.AcPaySlipCd = stockAdjust.AcPaySlipCd;            // 受払元伝票区分
                ptStockAdjustWork.AcPayTransCd = stockAdjust.AcPayTransCd;          // 受払元取引区分
                ptStockAdjustWork.AdjustDate = stockAdjust.AdjustDate;              // 調整日付
                ptStockAdjustWork.InputAgenCd = stockAdjust.InputAgenCd;
                ptStockAdjustWork.InputAgenNm = stockAdjust.InputAgenNm;
                ptStockAdjustWork.UpdEmployeeCode = stockAdjust.UpdEmployeeCode;    // 更新従業員コード
                ptStockAdjustWork.SlipNote = stockAdjust.SlipNote;                  // 伝票備考
            }

            return ptStockAdjustWork;
        }
        #endregion

        /// <summary>
        /// 在庫調整明細データ変換処理(UIデータ→ワーク)
        /// </summary>
        /// <param name="productStock"></param>
        /// <returns></returns>
        //        private static StockAdjustDtlWork CopyToStockAdjustDtlWorkFromStockAdjustDtl(StockAdjustDtl stockAdjustDtl,string warehouseCode,string warehouseName,int mode)
        private static EachWarehouseStockAdjustDtlWork CopyToStockAdjustDtlWorkFromStockAdjustDtl(StockAdjustDtl stockAdjustDtl, string warehouseCode, string warehouseName, int mode)
        {
            // 在庫調整明細ワーククラス宣言
            //            StockAdjustDtlWork ptStockAdjustDtlWork = new StockAdjustDtlWork();
            EachWarehouseStockAdjustDtlWork ptStockAdjustDtlWork = new EachWarehouseStockAdjustDtlWork();

            // 在庫調整明細オブジェクトが存在するか？
            if (stockAdjustDtl != null)
            {
                ptStockAdjustDtlWork.EnterpriseCode = stockAdjustDtl.EnterpriseCode;
                ptStockAdjustDtlWork.SectionCode = stockAdjustDtl.SectionCode;
                ptStockAdjustDtlWork.StockAdjustSlipNo = stockAdjustDtl.StockAdjustSlipNo;
                ptStockAdjustDtlWork.StockAdjustRowNo = stockAdjustDtl.StockAdjustRowNo;
                ptStockAdjustDtlWork.AcPaySlipCd = stockAdjustDtl.AcPaySlipCd;
                ptStockAdjustDtlWork.AcPayTransCd = stockAdjustDtl.AcPayTransCd;
                ptStockAdjustDtlWork.AdjustDate = stockAdjustDtl.AdjustDate;
                // 2007.10.11 修正 >>>>>>>>>>>>>>>>>>>>
                //ptStockAdjustDtlWork.MakerCode = stockAdjustDtl.MakerCode;
                ptStockAdjustDtlWork.GoodsMakerCd = stockAdjustDtl.GoodsMakerCd;
                // 2007.10.11 修正 <<<<<<<<<<<<<<<<<<<<
                ptStockAdjustDtlWork.MakerName = stockAdjustDtl.MakerName;
                // 2007.10.11 修正 >>>>>>>>>>>>>>>>>>>>
                //ptStockAdjustDtlWork.GoodsCode = stockAdjustDtl.GoodsCode;
                ptStockAdjustDtlWork.GoodsNo = stockAdjustDtl.GoodsNo;
                // 2007.10.11 修正 <<<<<<<<<<<<<<<<<<<<
                ptStockAdjustDtlWork.GoodsName = stockAdjustDtl.GoodsName;
                // 2007.10.11 修正 >>>>>>>>>>>>>>>>>>>>
                //ptStockAdjustDtlWork.PrdNumMngDiv = stockAdjustDtl.PrdNumMngDiv;
                //ptStockAdjustDtlWork.ProductNumber = stockAdjustDtl.ProductNumber;
                //ptStockAdjustDtlWork.BfProductNumber = stockAdjustDtl.BfProductNumber; //変更前
                //ptStockAdjustDtlWork.StockUnitPrice = stockAdjustDtl.StockUnitPrice;
                //ptStockAdjustDtlWork.BfStockUnitPrice = stockAdjustDtl.BfStockUnitPrice;
                //ptStockAdjustDtlWork.StockTelNo1 = stockAdjustDtl.StockTelNo1;
                //ptStockAdjustDtlWork.BfStockTelNo1 = stockAdjustDtl.BfStockTelNo1;
                //ptStockAdjustDtlWork.StockTelNo2 = stockAdjustDtl.StockTelNo2;
                //ptStockAdjustDtlWork.BfStockTelNo2 = stockAdjustDtl.BfStockTelNo2;
                ptStockAdjustDtlWork.StockUnitPriceFl = stockAdjustDtl.StockUnitPriceFl;
                ptStockAdjustDtlWork.BfStockUnitPriceFl = stockAdjustDtl.BfStockUnitPriceFl;
                // 2007.10.11 修正 <<<<<<<<<<<<<<<<<<<<
                ptStockAdjustDtlWork.SupplierStock = stockAdjustDtl.SupplierStock;
                ptStockAdjustDtlWork.TrustCount = stockAdjustDtl.TrustCount;
                ptStockAdjustDtlWork.UpdEmployeeCode = stockAdjustDtl.UpdEmployeeCode;
                // 2007.10.11 削除 >>>>>>>>>>>>>>>>>>>>
                //// 調整数変換 正なら負に
                //if (stockAdjustDtl.AdjustCount > 0)
                //{
                //    stockAdjustDtl.AdjustCount = stockAdjustDtl.AdjustCount * -1;
                //}
                // 2007.10.11 削除 <<<<<<<<<<<<<<<<<<<<
                ptStockAdjustDtlWork.AdjustCount = stockAdjustDtl.AdjustCount;
                // 2007.10.11 削除 >>>>>>>>>>>>>>>>>>>>
                //ptStockAdjustDtlWork.StockState = stockAdjustDtl.StockState;
                // 2007.10.11 削除 <<<<<<<<<<<<<<<<<<<<
                ptStockAdjustDtlWork.BfStockState = stockAdjustDtl.BfStockState;
                ptStockAdjustDtlWork.StockDiv = stockAdjustDtl.StockDiv;
                // 2007.10.11 削除 >>>>>>>>>>>>>>>>>>>>
                //ptStockAdjustDtlWork.GoodsCodeStatus = stockAdjustDtl.GoodsCodeStatus;
                //ptStockAdjustDtlWork.ProductStockGuid = stockAdjustDtl.ProductStockGuid;
                // 2007.10.11 削除 <<<<<<<<<<<<<<<<<<<<
                ptStockAdjustDtlWork.DtlNote = stockAdjustDtl.DtlNote;

                // 2007.10.11 削除 >>>>>>>>>>>>>>>>>>>>
                //if (((mode == ctMode_StockAdjust) || (mode == ctMode_TrustAdjust) || (mode == ctMode_UnitPriceReEdit)) &&
                //    (stockAdjustDtl.ProductStockGuid == Guid.Empty))
                //{
                //    ptStockAdjustDtlWork.AutoProductStockDrawingDiv = 1; //自動割当
                //}
                //else
                //{
                //    ptStockAdjustDtlWork.AutoProductStockDrawingDiv = 0; //自動割当                    
                //}
                // 2007.10.11 削除 <<<<<<<<<<<<<<<<<<<<

                //倉庫 takahiro                                
                ptStockAdjustDtlWork.WarehouseCode = warehouseCode;
                ptStockAdjustDtlWork.WarehouseName = warehouseName;
                // 2008.01.17 削除 >>>>>>>>>>>>>>>>>>>>
                //ptStockAdjustDtlWork.DtlNote = warehouseName;
                // 2008.01.17 削除 <<<<<<<<<<<<<<<<<<<<

                // 2007.10.11 追加 >>>>>>>>>>>>>>>>>>>>
                ptStockAdjustDtlWork.BLGoodsCode = stockAdjustDtl.BLGoodsCode;
                ptStockAdjustDtlWork.BLGoodsCdDerivedNo = stockAdjustDtl.BLGoodsCdDerivedNo;
                ptStockAdjustDtlWork.WarehouseShelfNo = stockAdjustDtl.WarehouseShelfNo;
                ptStockAdjustDtlWork.ListPriceFl = stockAdjustDtl.ListPriceFl;
                // 2007.10.11 追加 <<<<<<<<<<<<<<<<<<<<
            }
            return ptStockAdjustDtlWork;
        }
           --- DEL 2008/07/24 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/07/24 使用していないのでコメントアウト

        #region 2007.10.11 削除
        // 2007.10.11 削除 >>>>>>>>>>>>>>>>>>>>
		#region 製番在庫データ変換処理(ワーク→UIデータ)
        /*
		/// <summary>
		/// 製番在庫データ変換処理(ワーク→UIデータ)[ArrayList版]
		/// </summary>
		/// <param name="sauceList"></param>
		private static ArrayList CopyToDtlDataFromDtlWork(ArrayList sauceList)
		{
			ArrayList retList = null;

			if (sauceList != null)
			{
				// UIデータリスト生成
				retList = new ArrayList();

				// ワークリストよりUIデータリストを作成
				foreach (ProductStockWork wkObj in sauceList)
				{
					// 1クラスづつコピーを行う
					retList.Add(CopyToDtlDataFromDtlWork(wkObj));
				}
			}

			return retList;
		}

		/// <summary>
		/// 製番在庫データ変換処理(ワーク→UIデータ)
		/// </summary>
		/// <param name="productStockWork"></param>
		private static ProductStock CopyToDtlDataFromDtlWork(ProductStockWork productStockWork)
		{
			ProductStock productStock = null;

			if (productStockWork != null)
			{
				// UIデータクラスをインスタンス化
				productStock = new ProductStock();

				// 各項目をワークよりコピー(自動生成)
				productStock.CreateDateTime = productStockWork.CreateDateTime;
				productStock.UpdateDateTime = productStockWork.UpdateDateTime;
				productStock.EnterpriseCode = productStockWork.EnterpriseCode;
				productStock.FileHeaderGuid = productStockWork.FileHeaderGuid;
				productStock.UpdEmployeeCode = productStockWork.UpdEmployeeCode;
				productStock.UpdAssemblyId1 = productStockWork.UpdAssemblyId1;
				productStock.UpdAssemblyId2 = productStockWork.UpdAssemblyId2;
				productStock.LogicalDeleteCode = productStockWork.LogicalDeleteCode;
				productStock.SectionCode = productStockWork.SectionCode;
				productStock.MakerCode = productStockWork.MakerCode;
				productStock.GoodsCode = productStockWork.GoodsCode;
				productStock.GoodsName = productStockWork.GoodsName;
				productStock.ProductNumber = productStockWork.ProductNumber;
				productStock.ProductStockGuid = productStockWork.ProductStockGuid;
				productStock.StockDiv = productStockWork.StockDiv;
				productStock.WarehouseCode = productStockWork.WarehouseCode;
				productStock.WarehouseName = productStockWork.WarehouseName;
				productStock.CarrierEpCode = productStockWork.CarrierEpCode;
				productStock.CarrierEpName = productStockWork.CarrierEpName;
				productStock.CustomerCode = productStockWork.CustomerCode;
				productStock.CustomerName = productStockWork.CustomerName;
				productStock.CustomerName2 = productStockWork.CustomerName2;
				productStock.StockDate = productStockWork.StockDate;
				productStock.ArrivalGoodsDay = productStockWork.ArrivalGoodsDay;
				productStock.StockUnitPrice = productStockWork.StockUnitPrice;
				productStock.TaxationCode = productStockWork.TaxationCode;
				productStock.StockState = productStockWork.StockState;
				productStock.MoveStatus = productStockWork.MoveStatus;
				productStock.GoodsCodeStatus = productStockWork.GoodsCodeStatus;
				productStock.StockTelNo1 = productStockWork.StockTelNo1;
                productStock.StockTelNo2 = productStockWork.StockTelNo2;
                productStock.RomDiv = productStockWork.RomDiv;
                productStock.CellphoneModelCode = productStockWork.CellphoneModelCode;
                productStock.CellphoneModelName = productStockWork.CellphoneModelName;
                productStock.CarrierCode = productStockWork.CarrierCode;
                productStock.CarrierName = productStockWork.CarrierName;
                productStock.MakerName = productStockWork.MakerName;
                productStock.SystematicColorCd = productStockWork.SystematicColorCd;
                productStock.SystematicColorNm = productStockWork.SystematicColorNm;
                productStock.LargeGoodsGanreCode = productStockWork.LargeGoodsGanreCode;
                productStock.MediumGoodsGanreCode = productStockWork.MediumGoodsGanreCode;
                productStock.ShipCustomerCode = productStockWork.ShipCustomerCode;
                productStock.ShipCustomerName = productStockWork.ShipCustomerName;
                productStock.ShipCustomerName2 = productStockWork.ShipCustomerName2;
                productStock.SectionCode = productStockWork.SectionCode;
                productStock.MakerCode = productStockWork.MakerCode;
                productStock.GoodsCode = productStockWork.GoodsCode;
                productStock.GoodsName = productStockWork.GoodsName;
                productStock.ProductNumber = productStockWork.ProductNumber;
                productStock.ProductStockGuid = productStockWork.ProductStockGuid;
                productStock.StockDiv = productStockWork.StockDiv;
                productStock.WarehouseCode = productStockWork.WarehouseCode;
                productStock.WarehouseName = productStockWork.WarehouseName;
                productStock.CarrierEpCode = productStockWork.CarrierEpCode;
                productStock.CarrierEpName = productStockWork.CarrierEpName;
                productStock.CustomerCode = productStockWork.CustomerCode;
                productStock.CustomerName = productStockWork.CustomerName;
                productStock.CustomerName2 = productStockWork.CustomerName2;
                productStock.StockDate = productStockWork.StockDate;
                productStock.ArrivalGoodsDay = productStockWork.ArrivalGoodsDay;
                productStock.StockUnitPrice = productStockWork.StockUnitPrice;
                productStock.TaxationCode = productStockWork.TaxationCode;
                productStock.StockState = productStockWork.StockState;
                productStock.MoveStatus = productStockWork.MoveStatus;
                productStock.GoodsCodeStatus = productStockWork.GoodsCodeStatus;
                productStock.StockTelNo1 = productStockWork.StockTelNo1;
                productStock.StockTelNo2 = productStockWork.StockTelNo2;
                productStock.RomDiv = productStockWork.RomDiv;
                productStock.CellphoneModelCode = productStockWork.CellphoneModelCode;
                productStock.CellphoneModelName = productStockWork.CellphoneModelName;
                productStock.CarrierCode = productStockWork.CarrierCode;
                productStock.CarrierName = productStockWork.CarrierName;
                productStock.MakerName = productStockWork.MakerName;
                productStock.SystematicColorCd = productStockWork.SystematicColorCd;
                productStock.SystematicColorNm = productStockWork.SystematicColorNm;
                productStock.LargeGoodsGanreCode = productStockWork.LargeGoodsGanreCode;
                productStock.MediumGoodsGanreCode = productStockWork.MediumGoodsGanreCode;
                productStock.ShipCustomerCode = productStockWork.ShipCustomerCode;
                productStock.ShipCustomerName = productStockWork.ShipCustomerName;
                productStock.ShipCustomerName2 = productStockWork.ShipCustomerName2;
                
			}


			return productStock;
		}
        */
		#endregion
        // 2007.10.11 削除 <<<<<<<<<<<<<<<<<<<<
        #endregion

        #region 2007.10.11 削除
        // 2007.10.11 削除 >>>>>>>>>>>>>>>>>>>>
        #region 明細データ変換処理(UIデータ→ワーク)
        /*
		/// <summary>
		/// 明細データ変換処理(UIデータ→ワーク)[ArrayList版]
		/// </summary>
		/// <param name="sauceList"></param>
		private static ArrayList CopyToDtlWorkFromDtlData(ArrayList sauceList)
		{
			ArrayList retList = null;

			if (sauceList != null)
			{
				// ワークリスト生成
				retList = new ArrayList();

				// UIデータリストよりワークリストを作成
				foreach (ProductStock wkObj in sauceList)
				{
					// 1クラスづつコピーを行う
					retList.Add(CopyToDtlWorkFromDtlData(wkObj));
				}
			}

			return retList;
		}

		/// <summary>
		/// 製番在庫データ変換処理(UIデータ→ワーク)
		/// </summary>
		/// <param name="productStock"></param>
		private static ProductStockWork CopyToDtlWorkFromDtlData(ProductStock productStock)
		{
			ProductStockWork productStockWork = null;

			if (productStock != null)
			{
				// ワーククラスをインスタンス化
				productStockWork = new ProductStockWork();

				// 各項目をUIデータよりコピー(自動生成)
				productStockWork.CreateDateTime = productStock.CreateDateTime;
				productStockWork.UpdateDateTime = productStock.UpdateDateTime;
				productStockWork.EnterpriseCode = productStock.EnterpriseCode;
				productStockWork.FileHeaderGuid = productStock.FileHeaderGuid;
				productStockWork.UpdEmployeeCode = productStock.UpdEmployeeCode;
				productStockWork.UpdAssemblyId1 = productStock.UpdAssemblyId1;
				productStockWork.UpdAssemblyId2 = productStock.UpdAssemblyId2;
				productStockWork.LogicalDeleteCode = productStock.LogicalDeleteCode;


            }

			return productStockWork;
		}
        */
		#endregion
        // 2007.10.11 削除 <<<<<<<<<<<<<<<<<<<<
        #endregion

        #region DEL 2008/07/24 Partsman用に変更
        /* --- DEL 2008/07/24 --------------------------------------------------------------------->>>>>
        // 2008.02.15 追加 >>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// 価格検索（定価取得処理）
        /// </summary>
        /// <param name="setStockExpansion"></param>
        //private double GetGoodsListPrice(StockAdjustDtl stockAdjustDtl)
        private static double GetGoodsListPrice(string enterpriseCode, int goodsMakerCd, string goodsNo, DateTime adjustDate)
        {
            double goodsListPriceFl = 0.00;

            // 価格検索
            GoodsPriceUAcs goodsPriceUAcs = new GoodsPriceUAcs();
            GoodsPriceU goodsPriceU;
            //int ret = goodsPriceUAcs.Read(out goodsPriceU, stockAdjustDtl.EnterpriseCode, stockAdjustDtl.GoodsMakerCd, stockAdjustDtl.GoodsNo);
            int ret = goodsPriceUAcs.Read(out goodsPriceU, enterpriseCode, goodsMakerCd, goodsNo);
            if ((ret == 0) && (goodsPriceU != null) && (goodsPriceU.LogicalDeleteCode == 0))
            {
                //if (stockAdjustDtl.AdjustDate < goodsPriceU.NewPriceStartDate)
                if (adjustDate < goodsPriceU.NewPriceStartDate)
                {
                    goodsListPriceFl = goodsPriceU.OldPrice;
                }
                else
                {
                    goodsListPriceFl = goodsPriceU.NewPrice;
                }
            }

            return goodsListPriceFl;
        }
        // 2008.02.15 追加 <<<<<<<<<<<<<<<<<<<<
           --- DEL 2008/07/24 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/07/24 Partsman用に変更
    }
}

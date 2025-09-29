//****************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : 商品アクセス
// プログラム概要   : 商品アクセスクラス(在庫情報)のアクセス制御を行います。
//----------------------------------------------------------------------------//
//                (c)Copyright  2007 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 對馬 大輔
// 作 成 日  2008/06/18  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 忍 幸史
// 修 正 日  2009/01/13  修正内容 : 障害ID:9867対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 忍 幸史
// 修 正 日  2009/01/20  修正内容 : 障害ID:10217対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 忍 幸史
// 修 正 日  2009/01/26  修正内容 : 障害ID:9618対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 上野 俊治
// 修 正 日  2009/03/10  修正内容 : 障害ID:12337対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田 貴志
// 修 正 日  2009/04/22  修正内容 : 不具合対応[13091]
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田 貴志
// 修 正 日  2009/06/24  修正内容 : 不具合対応[13582]
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 工藤 恵優
// 修 正 日  2009/12/10  修正内容 : 不具合対応[14593]
//----------------------------------------------------------------------------//
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
    /// <br>Note       : 商品アクセスクラス(在庫情報)のアクセス制御を行います。</br>
    /// <br>Programmer : 20056 對馬 大輔</br>
    /// <br>Date       : 2008.06.18</br>
    /// <br>Update Note: 2009/01/13 30414 忍 幸史 障害ID:9867対応</br>
    /// <br>Update Note: 2009/01/20 30414 忍 幸史 障害ID:10217対応</br>
    /// <br>Update Note: 2009/01/26 30414 忍 幸史 障害ID:9618対応</br>
    /// <br>Update Note: 2009/03/10 30452 上野 俊治 障害ID:12337対応</br>
    /// <br>           : 2009/04/22       照田 貴志 不具合対応[13091]</br>
    /// <br>           : 2009/06/24       照田 貴志 不具合対応[13582]</br>
    /// <br>           : 2010/04/06 22008 長内 数馬 速度チューニング</br>
    /// </remarks>
    public partial class GoodsAcs
    {
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/09/10 ADD
        /// <summary>
        /// 在庫情報データオブジェクトリスト取得処理
        /// </summary>
        /// <param name="stockWorkList"></param>
        /// <param name="stockList"></param>
        private void GetStockListFromStockWorkList( ArrayList stockWorkList, out List<Stock> stockList )
        {
            stockList = new List<Stock>();
            foreach ( StockWork stockWork in stockWorkList )
            {
                if ( stockWork.LogicalDeleteCode == 3 ) continue;
                Stock stock = new Stock();

                stock.CreateDateTime = stockWork.CreateDateTime; // 作成日時
                stock.UpdateDateTime = stockWork.UpdateDateTime; // 更新日時
                stock.EnterpriseCode = stockWork.EnterpriseCode; // 企業コード
                stock.FileHeaderGuid = stockWork.FileHeaderGuid; // GUID
                stock.UpdEmployeeCode = stockWork.UpdEmployeeCode; // 更新従業員コード
                stock.UpdAssemblyId1 = stockWork.UpdAssemblyId1; // 更新アセンブリID1
                stock.UpdAssemblyId2 = stockWork.UpdAssemblyId2; // 更新アセンブリID2
                stock.LogicalDeleteCode = stockWork.LogicalDeleteCode; // 論理削除区分
                stock.SectionCode = stockWork.SectionCode.TrimEnd(); // 拠点コード
                stock.WarehouseCode = stockWork.WarehouseCode.TrimEnd(); // 倉庫コード
                // 2008.11.04 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                stock.WarehouseName = stockWork.WarehouseName.TrimEnd(); // 倉庫名称
                // 2008.11.04 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                stock.GoodsMakerCd = stockWork.GoodsMakerCd; // 商品メーカーコード
                stock.GoodsNo = stockWork.GoodsNo.TrimEnd(); // 商品番号
                stock.StockUnitPriceFl = stockWork.StockUnitPriceFl; // 仕入単価（税抜,浮動）
                stock.SupplierStock = stockWork.SupplierStock; // 仕入在庫数
                stock.AcpOdrCount = stockWork.AcpOdrCount; // 受注数
                stock.MonthOrderCount = stockWork.MonthOrderCount; // M/O発注数
                stock.SalesOrderCount = stockWork.SalesOrderCount; // 発注数
                stock.StockDiv = stockWork.StockDiv; // 在庫区分
                stock.MovingSupliStock = stockWork.MovingSupliStock; // 移動中仕入在庫数
                stock.ShipmentPosCnt = stockWork.ShipmentPosCnt; // 出荷可能数
                stock.StockTotalPrice = stockWork.StockTotalPrice; // 在庫保有総額
                stock.LastStockDate = stockWork.LastStockDate; // 最終仕入年月日
                stock.LastSalesDate = stockWork.LastSalesDate; // 最終売上日
                stock.LastInventoryUpdate = stockWork.LastInventoryUpdate; // 最終棚卸更新日
                stock.MinimumStockCnt = stockWork.MinimumStockCnt; // 最低在庫数
                stock.MaximumStockCnt = stockWork.MaximumStockCnt; // 最高在庫数
                stock.NmlSalOdrCount = stockWork.NmlSalOdrCount; // 基準発注数
                stock.SalesOrderUnit = stockWork.SalesOrderUnit; // 発注単位
                stock.StockSupplierCode = stockWork.StockSupplierCode; // 在庫発注先コード
                stock.GoodsNoNoneHyphen = stockWork.GoodsNoNoneHyphen.TrimEnd(); // ハイフン無商品番号
                stock.WarehouseShelfNo = stockWork.WarehouseShelfNo.TrimEnd(); // 倉庫棚番
                stock.DuplicationShelfNo1 = stockWork.DuplicationShelfNo1.TrimEnd(); // 重複棚番１
                stock.DuplicationShelfNo2 = stockWork.DuplicationShelfNo2.TrimEnd(); // 重複棚番２
                stock.PartsManagementDivide1 = stockWork.PartsManagementDivide1.TrimEnd(); // 部品管理区分１
                stock.PartsManagementDivide2 = stockWork.PartsManagementDivide2.TrimEnd(); // 部品管理区分２
                stock.StockNote1 = stockWork.StockNote1.TrimEnd(); // 在庫備考１
                stock.StockNote2 = stockWork.StockNote2.TrimEnd(); // 在庫備考２
                stock.ShipmentCnt = stockWork.ShipmentCnt; // 出荷数（未計上）
                stock.ArrivalCnt = stockWork.ArrivalCnt; // 入荷数（未計上）
                stock.StockCreateDate = stockWork.StockCreateDate; // 在庫登録日
                stock.UpdateDate = stockWork.UpdateDate; // 更新年月日

                stockList.Add( stock );
            }
        }
        /// <summary>
        /// 在庫情報データワークオブジェクトリスト取得処理
        /// </summary>
        /// <param name="stockList"></param>
        /// <param name="stockWorkList"></param>
        private void GetStockWorkListFromStockList( List<Stock> stockList, out ArrayList stockWorkList )
        {
            stockWorkList = new ArrayList();
            foreach ( Stock stock in stockList )
            {
                StockWork stockWork = new StockWork();

                stockWork.CreateDateTime = stock.CreateDateTime; // 作成日時
                stockWork.UpdateDateTime = stock.UpdateDateTime; // 更新日時
                stockWork.EnterpriseCode = stock.EnterpriseCode; // 企業コード
                stockWork.FileHeaderGuid = stock.FileHeaderGuid; // GUID
                stockWork.UpdEmployeeCode = stock.UpdEmployeeCode; // 更新従業員コード
                stockWork.UpdAssemblyId1 = stock.UpdAssemblyId1; // 更新アセンブリID1
                stockWork.UpdAssemblyId2 = stock.UpdAssemblyId2; // 更新アセンブリID2
                stockWork.LogicalDeleteCode = stock.LogicalDeleteCode; // 論理削除区分
                stockWork.SectionCode = stock.SectionCode.TrimEnd(); // 拠点コード
                stockWork.WarehouseCode = stock.WarehouseCode.TrimEnd(); // 倉庫コード
                stockWork.GoodsMakerCd = stock.GoodsMakerCd; // 商品メーカーコード
                stockWork.GoodsNo = stock.GoodsNo.TrimEnd(); // 商品番号
                stockWork.StockUnitPriceFl = stock.StockUnitPriceFl; // 仕入単価（税抜,浮動）
                stockWork.SupplierStock = stock.SupplierStock; // 仕入在庫数
                stockWork.AcpOdrCount = stock.AcpOdrCount; // 受注数
                stockWork.MonthOrderCount = stock.MonthOrderCount; // M/O発注数
                stockWork.SalesOrderCount = stock.SalesOrderCount; // 発注数
                stockWork.StockDiv = stock.StockDiv; // 在庫区分
                stockWork.MovingSupliStock = stock.MovingSupliStock; // 移動中仕入在庫数
                stockWork.ShipmentPosCnt = stock.ShipmentPosCnt; // 出荷可能数
                stockWork.StockTotalPrice = stock.StockTotalPrice; // 在庫保有総額
                stockWork.LastStockDate = stock.LastStockDate; // 最終仕入年月日
                stockWork.LastSalesDate = stock.LastSalesDate; // 最終売上日
                stockWork.LastInventoryUpdate = stock.LastInventoryUpdate; // 最終棚卸更新日
                stockWork.MinimumStockCnt = stock.MinimumStockCnt; // 最低在庫数
                stockWork.MaximumStockCnt = stock.MaximumStockCnt; // 最高在庫数
                stockWork.NmlSalOdrCount = stock.NmlSalOdrCount; // 基準発注数
                stockWork.SalesOrderUnit = stock.SalesOrderUnit; // 発注単位
                stockWork.StockSupplierCode = stock.StockSupplierCode; // 在庫発注先コード
                stockWork.GoodsNoNoneHyphen = stock.GoodsNoNoneHyphen.TrimEnd(); // ハイフン無商品番号
                stockWork.WarehouseShelfNo = stock.WarehouseShelfNo.TrimEnd(); // 倉庫棚番
                stockWork.DuplicationShelfNo1 = stock.DuplicationShelfNo1.TrimEnd(); // 重複棚番１
                stockWork.DuplicationShelfNo2 = stock.DuplicationShelfNo2.TrimEnd(); // 重複棚番２
                stockWork.PartsManagementDivide1 = stock.PartsManagementDivide1.TrimEnd(); // 部品管理区分１
                stockWork.PartsManagementDivide2 = stock.PartsManagementDivide2.TrimEnd(); // 部品管理区分２
                stockWork.StockNote1 = stock.StockNote1.TrimEnd(); // 在庫備考１
                stockWork.StockNote2 = stock.StockNote2.TrimEnd(); // 在庫備考２
                stockWork.ShipmentCnt = stock.ShipmentCnt; // 出荷数（未計上）
                stockWork.ArrivalCnt = stock.ArrivalCnt; // 入荷数（未計上）
                stockWork.StockCreateDate = stock.StockCreateDate; // 在庫登録日
                stockWork.UpdateDate = stock.UpdateDate; // 更新年月日                

                stockWorkList.Add( stockWork );
            }
        }
        /// <summary>
        /// 在庫情報データワークオブジェクトリスト取得処理
        /// </summary>
        /// <param name="stock"></param>
        /// <param name="stockWork"></param>
        private void GetStockWorkFromStock(Stock stock, out StockWork stockWork)
        {
            stockWork = new StockWork();

            stockWork.CreateDateTime = stock.CreateDateTime; // 作成日時
            stockWork.UpdateDateTime = stock.UpdateDateTime; // 更新日時
            stockWork.EnterpriseCode = stock.EnterpriseCode; // 企業コード
            stockWork.FileHeaderGuid = stock.FileHeaderGuid; // GUID
            stockWork.UpdEmployeeCode = stock.UpdEmployeeCode; // 更新従業員コード
            stockWork.UpdAssemblyId1 = stock.UpdAssemblyId1; // 更新アセンブリID1
            stockWork.UpdAssemblyId2 = stock.UpdAssemblyId2; // 更新アセンブリID2
            stockWork.LogicalDeleteCode = stock.LogicalDeleteCode; // 論理削除区分
            stockWork.SectionCode = stock.SectionCode.TrimEnd(); // 拠点コード
            stockWork.WarehouseCode = stock.WarehouseCode.TrimEnd(); // 倉庫コード
            stockWork.GoodsMakerCd = stock.GoodsMakerCd; // 商品メーカーコード
            stockWork.GoodsNo = stock.GoodsNo.TrimEnd(); // 商品番号
            stockWork.StockUnitPriceFl = stock.StockUnitPriceFl; // 仕入単価（税抜,浮動）
            stockWork.SupplierStock = stock.SupplierStock; // 仕入在庫数
            stockWork.AcpOdrCount = stock.AcpOdrCount; // 受注数
            stockWork.MonthOrderCount = stock.MonthOrderCount; // M/O発注数
            stockWork.SalesOrderCount = stock.SalesOrderCount; // 発注数
            stockWork.StockDiv = stock.StockDiv; // 在庫区分
            stockWork.MovingSupliStock = stock.MovingSupliStock; // 移動中仕入在庫数
            stockWork.ShipmentPosCnt = stock.ShipmentPosCnt; // 出荷可能数
            stockWork.StockTotalPrice = stock.StockTotalPrice; // 在庫保有総額
            stockWork.LastStockDate = stock.LastStockDate; // 最終仕入年月日
            stockWork.LastSalesDate = stock.LastSalesDate; // 最終売上日
            stockWork.LastInventoryUpdate = stock.LastInventoryUpdate; // 最終棚卸更新日
            stockWork.MinimumStockCnt = stock.MinimumStockCnt; // 最低在庫数
            stockWork.MaximumStockCnt = stock.MaximumStockCnt; // 最高在庫数
            stockWork.NmlSalOdrCount = stock.NmlSalOdrCount; // 基準発注数
            stockWork.SalesOrderUnit = stock.SalesOrderUnit; // 発注単位
            stockWork.StockSupplierCode = stock.StockSupplierCode; // 在庫発注先コード
            stockWork.GoodsNoNoneHyphen = stock.GoodsNoNoneHyphen.TrimEnd(); // ハイフン無商品番号
            stockWork.WarehouseShelfNo = stock.WarehouseShelfNo.TrimEnd(); // 倉庫棚番
            stockWork.DuplicationShelfNo1 = stock.DuplicationShelfNo1.TrimEnd(); // 重複棚番１
            stockWork.DuplicationShelfNo2 = stock.DuplicationShelfNo2.TrimEnd(); // 重複棚番２
            stockWork.PartsManagementDivide1 = stock.PartsManagementDivide1.TrimEnd(); // 部品管理区分１
            stockWork.PartsManagementDivide2 = stock.PartsManagementDivide2.TrimEnd(); // 部品管理区分２
            stockWork.StockNote1 = stock.StockNote1.TrimEnd(); // 在庫備考１
            stockWork.StockNote2 = stock.StockNote2.TrimEnd(); // 在庫備考２
            stockWork.ShipmentCnt = stock.ShipmentCnt; // 出荷数（未計上）
            stockWork.ArrivalCnt = stock.ArrivalCnt; // 入荷数（未計上）
            stockWork.StockCreateDate = stock.StockCreateDate; // 在庫登録日
            stockWork.UpdateDate = stock.UpdateDate; // 更新年月日
        }
        /// <summary>
        /// 在庫差分適用処理（ 変更後＆変更前 → 差分＆変更前 ）
        /// </summary>
        /// <param name="goodsUnitData"></param>
        /// <param name="prevStockList"></param>
        private void ReflectStockDifference( ref GoodsUnitData goodsUnitData, List<Stock> prevStockList )
        {
            //----------------------------------------------------------------
            // goodsUnitData(変更後)の内容を、変更前からの差分に変換します。
            //
            // 変更後　変更前
            // ○　　　○　　　→　【更新】数量＝（変更後－変更前）
            // ○　　　×　　　→　【追加】数量＝＋変更後
            // △　　　○　　　→　【削除】数量＝－変更前
            // 
            // < ○：有、×：無、△：有かつLogicalDeleteCode≠0 >
            //----------------------------------------------------------------

            foreach ( Stock stock in goodsUnitData.StockList )
            {
                // 対応する変更前在庫オブジェクトを取得
                Stock prevStock = GetStockFromStockList( stock.WarehouseCode, stock.GoodsMakerCd, stock.GoodsNo, prevStockList );

                if ( prevStock != null )
                {
                    if ( stock.LogicalDeleteCode == 0 )
                    {
                        // 【更新】
                        # region [更新]
                        // 在庫マスタ更新時に差分になっていなければならない「数量」(※在庫リモートMAZAI04134Rより)
                        stock.SupplierStock -= prevStock.SupplierStock; // 仕入在庫数
                        stock.AcpOdrCount -= prevStock.AcpOdrCount; // 受注数
                        stock.SalesOrderCount -= prevStock.SalesOrderCount; // 発注数
                        stock.MovingSupliStock -= prevStock.MovingSupliStock; // 移動中仕入在庫数
                        stock.ShipmentCnt -= prevStock.ShipmentCnt; // 出荷数（未計上）
                        stock.ArrivalCnt -= prevStock.ArrivalCnt; // 入荷数（未計上）
                        # endregion
                    }
                    else
                    {
                        // 【削除or論理削除】
                        # region [削除]
                        // 在庫マスタ更新時に差分になっていなければならない「数量」(※在庫リモートMAZAI04134Rより)
                        stock.SupplierStock = -prevStock.SupplierStock; // 仕入在庫数
                        stock.AcpOdrCount = -prevStock.AcpOdrCount; // 受注数
                        stock.SalesOrderCount = -prevStock.SalesOrderCount; // 発注数
                        stock.MovingSupliStock = -prevStock.MovingSupliStock; // 移動中仕入在庫数
                        stock.ShipmentCnt = -prevStock.ShipmentCnt; // 出荷数（未計上）
                        stock.ArrivalCnt = -prevStock.ArrivalCnt; // 入荷数（未計上）
                        # endregion
                    }
                }
                else
                {
                    // 【追加】→変更後在庫オブジェクトの内容のままで良いので処理不要。
                }
            }
        }

        /// <summary>
        /// 更新後在庫差分適用処理（ 更新結果＆更新前＆変更後 → 更新結果(差異なし追加)＆更新前＆変更後 ）
        /// </summary>
        /// <param name="goodsUnitData"></param>
        /// <param name="prevStockList"></param>
        /// <param name="bakGoodsUnitData"></param>
        private void ReflectStockDifferenceOnAfterUpdate(ref GoodsUnitData goodsUnitData, List<Stock> prevStockList, GoodsUnitData bakGoodsUnitData)
        {
            foreach (Stock stock in bakGoodsUnitData.StockList)
            {
                // 2009.04.01 30413 論理削除時も在庫差分適用処理は行わない >>>>>>START
                //if (stock.LogicalDeleteCode == 3)
                if (stock.LogicalDeleteCode != 0)
                {
                    // 論理削除／完全削除
                    continue;
                }
                // 2009.04.01 30413 論理削除時も在庫差分適用処理は行わない <<<<<<END
                
                // 変更後の在庫オブジェクトを取得
                Stock updStock = GetStockFromStockList(stock.WarehouseCode, stock.GoodsMakerCd, stock.GoodsNo, goodsUnitData.StockList);

                if (updStock == null)
                {
                    // 対応する変更前在庫オブジェクトを取得
                    // ※prevStockListは画面表示時の値、bakGoodsUnitDataは更新直前の値
                    //Stock prevStock = GetStockFromStockList(stock.WarehouseCode, stock.GoodsMakerCd, stock.GoodsNo, prevStockList);                       //DEL 2009/06/24 不具合対応[13582]　更新直前の値を使用する
                    Stock prevStock = GetStockFromStockList(stock.WarehouseCode, stock.GoodsMakerCd, stock.GoodsNo, bakGoodsUnitData.StockList);            //ADD 2009/06/24 不具合対応[13582]  更新直前の値を使用する

                    if (prevStock != null)
                    {
                        // 変更前在庫を更新結果へ追加
                        # region [差分なし分]
                        stock.SupplierStock = prevStock.SupplierStock;          // 仕入在庫数
                        stock.AcpOdrCount = prevStock.AcpOdrCount;              // 受注数
                        stock.SalesOrderCount = prevStock.SalesOrderCount;      // 発注数
                        stock.MovingSupliStock = prevStock.MovingSupliStock;    // 移動中仕入在庫数
                        stock.ShipmentCnt = prevStock.ShipmentCnt;              // 出荷数（未計上）
                        stock.ArrivalCnt = prevStock.ArrivalCnt;                // 入荷数（未計上）
                        # endregion

                        // 差分なし在庫
                        goodsUnitData.StockList.Add(stock);
                    }
                }
                else
                {
                    // 対応する変更前在庫オブジェクトを取得
                    // ※prevStockListは画面表示時の値、bakGoodsUnitDataは更新直前の値
                    //Stock prevStock = GetStockFromStockList(updStock.WarehouseCode, updStock.GoodsMakerCd, updStock.GoodsNo, prevStockList);              //DEL 2009/06/24 不具合対応[13582]　更新直前の値を使用する
                    Stock prevStock = GetStockFromStockList(updStock.WarehouseCode, updStock.GoodsMakerCd, updStock.GoodsNo, bakGoodsUnitData.StockList);   //ADD 2009/06/24 不具合対応[13582]  更新直前の値を使用する

                    if ((prevStock != null) && (!CheckUpdateStock(updStock)))
                    {
                        // 変更前在庫で更新結果を修正
                        # region [差分なし分]
                        int idx = goodsUnitData.StockList.IndexOf(updStock);
                        goodsUnitData.StockList[idx].SupplierStock = prevStock.SupplierStock;          // 仕入在庫数
                        goodsUnitData.StockList[idx].AcpOdrCount = prevStock.AcpOdrCount;              // 受注数
                        goodsUnitData.StockList[idx].SalesOrderCount = prevStock.SalesOrderCount;      // 発注数
                        goodsUnitData.StockList[idx].MovingSupliStock = prevStock.MovingSupliStock;    // 移動中仕入在庫数
                        goodsUnitData.StockList[idx].ShipmentCnt = prevStock.ShipmentCnt;              // 出荷数（未計上）
                        goodsUnitData.StockList[idx].ArrivalCnt = prevStock.ArrivalCnt;                // 入荷数（未計上）
                        # endregion
                    }
                }
            }
        }

        /// <summary>
        /// 在庫調整データの生成（商品連結データより）
        /// </summary>
        /// <param name="stockAdjustList">在庫調整データリスト</param>
        /// <param name="stockAdjustDtlList">在庫調整明細データリスト</param>
        /// <param name="goodsUnitData">商品連結データ</param>
        /// <param name="prevStockList">変更前在庫リスト</param>
        private void CreateStockAdjustWorkFromGoodsUnitData( ref ArrayList stockAdjustList, ref ArrayList stockAdjustDtlList, GoodsUnitData goodsUnitData, List<Stock> prevStockList )
        {
            // 在庫情報が無い場合は迂回
            if ( goodsUnitData.StockList == null || goodsUnitData.StockList.Count == 0 ) return;


            //---------------------------------------------------------------
            // 登録用各種設定値取得
            //---------------------------------------------------------------

            // 受払元伝票区分=42:マスタメンテ
            const int ct_AcPaySlipCd = 42;

            // 受払元取引区分=30:在庫数調整
            const int ct_AcPayTransCd = 30;

            // 作成日時(共通)
            DateTime createDateTime = DateTime.Now;

            // (ﾛｸﾞｲﾝ)従業員コード
            string stockInputCode = LoginInfoAcquisition.Employee.EmployeeCode;
            
            // (ﾛｸﾞｲﾝ)従業員名称
            string stockInputName = LoginInfoAcquisition.Employee.Name;

            // 2009.06.15 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            SecInfoAcs secInfoAcs = new SecInfoAcs();
            // 2009.06.15 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

            // --- ADD 2009/01/20 障害ID:10217対応------------------------------------------------------>>>>>
            Dictionary<string, SecInfoSet> secInfoSetDic = new Dictionary<string, SecInfoSet>();
            // 2009.06.15 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //foreach (SecInfoSet secInfoSet in this._secInfoAcs.SecInfoSetList)
            foreach ( SecInfoSet secInfoSet in secInfoAcs.SecInfoSetList )
            // 2009.06.15 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
            {
                if (secInfoSet.LogicalDeleteCode == 0)
                {
                    secInfoSetDic.Add(secInfoSet.SectionCode.Trim(), secInfoSet);
                }
            }
            // --- ADD 2009/01/20 障害ID:10217対応------------------------------------------------------<<<<<

            //---------------------------------------------------------------
            // 在庫調整データ
            //---------------------------------------------------------------
            StockAdjustWork stockAdjustWork = new StockAdjustWork();

            # region [在庫調整]
            stockAdjustWork.CreateDateTime = createDateTime; // 作成日時
            stockAdjustWork.UpdateDateTime = DateTime.MinValue; // 更新日時
            stockAdjustWork.EnterpriseCode = _enterpriseCode; // 企業コード
            stockAdjustWork.FileHeaderGuid = Guid.Empty; // GUID
            //stockAdjustWork.UpdEmployeeCode = default( string ); // 更新従業員コード
            //stockAdjustWork.UpdAssemblyId1 = default( string ); // 更新アセンブリID1
            //stockAdjustWork.UpdAssemblyId2 = default( string ); // 更新アセンブリID2
            stockAdjustWork.LogicalDeleteCode = 0; // 論理削除区分
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/11/07 DEL
            //stockAdjustWork.SectionCode = goodsUnitData.SectionCode; // 拠点コード
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/11/07 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/11/07 ADD
            stockAdjustWork.SectionCode = _loginSectionCode; // 拠点コード
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/11/07 ADD
            stockAdjustWork.StockAdjustSlipNo = 0; // 在庫調整伝票番号
            stockAdjustWork.AcPaySlipCd = ct_AcPaySlipCd; // 受払元伝票区分
            stockAdjustWork.AcPayTransCd = ct_AcPayTransCd; // 受払元取引区分
            stockAdjustWork.AdjustDate = createDateTime; // 調整日付
            stockAdjustWork.InputDay = createDateTime; // 入力日付
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/11/07 DEL
            //stockAdjustWork.StockSectionCd = goodsUnitData.SectionCode; // 仕入拠点コード
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/11/07 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/11/07 ADD
            stockAdjustWork.StockSectionCd = _loginSectionCode; // 仕入拠点コード
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/11/07 ADD
            stockAdjustWork.StockInputCode = stockInputCode; // 仕入入力者コード
            stockAdjustWork.StockInputName = stockInputName; // 仕入入力者名称
            stockAdjustWork.StockAgentCode = stockInputCode; // 仕入担当者コード
            stockAdjustWork.StockAgentName = stockInputName; // 仕入担当者名称
            stockAdjustWork.StockSubttlPrice = 0; // 仕入金額小計（←※ここでは初期値として0をセットする）
            stockAdjustWork.SlipNote = string.Empty; // 伝票備考
            //---------------------------------
            // ※仕入金額小計は
            //   全明細分を合算する必要があるので
            //   後で書き換える。
            //---------------------------------
            // --- ADD 2009/01/20 障害ID:10217対応------------------------------------------------------>>>>>
            if (secInfoSetDic.ContainsKey(_loginSectionCode.Trim()))
            {
                stockAdjustWork.SectionGuideNm = secInfoSetDic[_loginSectionCode.Trim()].SectionGuideNm.Trim();
                stockAdjustWork.StockSectionGuideNm = stockAdjustWork.SectionGuideNm;
            }
            // --- ADD 2009/01/20 障害ID:10217対応------------------------------------------------------<<<<<
            # endregion

            //---------------------------------------------------------------
            // 在庫調整明細データ
            //---------------------------------------------------------------
            for(int index=0;index < goodsUnitData.StockList.Count;index++)
            {
                StockAdjustDtlWork stockAdjustDtlWork = new StockAdjustDtlWork();

                //---------------------------------------------------------------
                // 在庫オブジェクト取得
                //---------------------------------------------------------------
                // 更新差分在庫(ReflectStockDifferenceで書き変えている為)
                Stock stock = goodsUnitData.StockList[index];
                // 数量関係(の差分)がゼロならば在庫調整明細データは不要なので迂回
                if ( !CheckUpdateStock( stock ) ) continue;
                

                // 対応する更新前在庫
                Stock prevStock = GetStockFromStockList( stock.WarehouseCode, stock.GoodsMakerCd, stock.GoodsNo, prevStockList );

                //---------------------------------------------------------------
                // セット値算出
                //---------------------------------------------------------------

                // 標準価格・オープン価格区分
                double listPriceFl;
                int openPriceDiv;
                this.GetListPrice( out listPriceFl, out openPriceDiv, goodsUnitData.GoodsPriceList, createDateTime );

                // --- ADD 2009/01/13 障害ID:9867対応------------------------------------------------------>>>>>
                // 仕入単価
                double stockUnitPriceFl;
                GetStockUnitPriceFl(out stockUnitPriceFl, goodsUnitData.GoodsPriceList, createDateTime);
                stock.StockUnitPriceFl = stockUnitPriceFl;
                // --- ADD 2009/01/13 障害ID:9867対応------------------------------------------------------<<<<<

                // 仕入金額算出
                Int64 stockPriceTaxExc;
                this.GetStockPriceTaxExc( out stockPriceTaxExc, stock );

                // 調整数
                // （※注意！在庫マスタ更新用に仕入在庫数は差分に書き換えた前提(this.ReflectStockDifference)）
                double adjustCount = stock.SupplierStock;


                // 変更前仕入単価（浮動）
                double bfStockUnitPriceFl = 0;
                if ( prevStock != null )
                {
                    // 変更前オブジェクトがあれば「仕入単価（浮動）」をセットする
                    bfStockUnitPriceFl = prevStock.StockUnitPriceFl;
                }

                //---------------------------------------------------------------
                // 在庫調整明細生成
                //---------------------------------------------------------------

                # region [在庫調整明細]
                stockAdjustDtlWork.CreateDateTime = createDateTime; // 作成日時
                stockAdjustDtlWork.UpdateDateTime = DateTime.MinValue; // 更新日時
                stockAdjustDtlWork.EnterpriseCode = _enterpriseCode; // 企業コード
                stockAdjustDtlWork.FileHeaderGuid = Guid.Empty; // GUID
                //stockAdjustDtlWork.UpdEmployeeCode = default( string ); // 更新従業員コード
                //stockAdjustDtlWork.UpdAssemblyId1 = default( string ); // 更新アセンブリID1
                //stockAdjustDtlWork.UpdAssemblyId2 = default( string ); // 更新アセンブリID2
                stockAdjustDtlWork.LogicalDeleteCode = 0; // 論理削除区分
                stockAdjustDtlWork.SectionCode = stockAdjustWork.SectionCode; // 拠点コード
                stockAdjustDtlWork.StockAdjustSlipNo = stockAdjustWork.StockAdjustSlipNo; // 在庫調整伝票番号
                stockAdjustDtlWork.StockAdjustRowNo = (index + 1); // 在庫調整行番号
                stockAdjustDtlWork.SupplierFormalSrc = 0; // 仕入形式（元）
                stockAdjustDtlWork.StockSlipDtlNumSrc = 0; // 仕入明細通番（元）
                stockAdjustDtlWork.AcPaySlipCd = stockAdjustWork.AcPaySlipCd; // 受払元伝票区分
                stockAdjustDtlWork.AcPayTransCd = stockAdjustWork.AcPayTransCd; // 受払元取引区分
                stockAdjustDtlWork.AdjustDate = createDateTime; // 調整日付
                stockAdjustDtlWork.InputDay = createDateTime; // 入力日付
                stockAdjustDtlWork.GoodsMakerCd = stock.GoodsMakerCd; // 商品メーカーコード
                stockAdjustDtlWork.MakerName = stock.MakerName; // メーカー名称
                stockAdjustDtlWork.GoodsNo = stock.GoodsNo; // 商品番号
                stockAdjustDtlWork.GoodsName = stock.GoodsName; // 商品名称
                stockAdjustDtlWork.StockUnitPriceFl = stock.StockUnitPriceFl; // 仕入単価（税抜,浮動）
                stockAdjustDtlWork.BfStockUnitPriceFl = bfStockUnitPriceFl; // 変更前仕入単価（浮動）
                stockAdjustDtlWork.AdjustCount = adjustCount; // 調整数
                stockAdjustDtlWork.DtlNote = string.Empty; // 明細備考
                stockAdjustDtlWork.WarehouseCode = stock.WarehouseCode; // 倉庫コード
                stockAdjustDtlWork.WarehouseName = stock.WarehouseName; // 倉庫名称
                stockAdjustDtlWork.BLGoodsCode = goodsUnitData.BLGoodsCode; // BL商品コード
                stockAdjustDtlWork.BLGoodsFullName = goodsUnitData.BLGoodsFullName; // BL商品コード名称（全角）
                stockAdjustDtlWork.WarehouseShelfNo = stock.WarehouseShelfNo; // 倉庫棚番
                stockAdjustDtlWork.ListPriceFl = listPriceFl; // 定価（浮動）
                stockAdjustDtlWork.OpenPriceDiv = openPriceDiv; // オープン価格区分
                stockAdjustDtlWork.StockPriceTaxExc = stockPriceTaxExc; // 仕入金額（税抜き）
                // --- ADD 2009/01/26 障害ID:9618対応------------------------------------------------------>>>>>
                stockAdjustDtlWork.GoodsName = goodsUnitData.GoodsName.Trim();  // 品名
                // --- ADD 2009/01/26 障害ID:9618対応------------------------------------------------------<<<<<

                // --- ADD 2009/01/20 障害ID:10217対応------------------------------------------------------>>>>>
                stockAdjustDtlWork.SectionGuideNm = stockAdjustWork.SectionGuideNm;
                MakerUMnt makerUMnt;
                int status = GetMaker(_enterpriseCode, stock.GoodsMakerCd, out makerUMnt);
                if (status == 0)
                {
                    stockAdjustDtlWork.MakerName = makerUMnt.MakerName.Trim();
                }
                // 2010/04/06 Del >>>
                //string goodsName;
                //status = GetGoodsName(stock.GoodsMakerCd, stock.GoodsNo, out goodsName);
                //if (status == 0)
                //{
                //    stockAdjustDtlWork.GoodsName = goodsName.Trim();
                //}
                // 2010/04/06 Del <<<
                // --- ADD 2009/01/20 障害ID:10217対応------------------------------------------------------<<<<<
                # endregion

                // 在庫調整明細データリストに追加
                stockAdjustDtlList.Add( stockAdjustDtlWork );

                //---------------------------------------------------------------
                // 金額計に合算
                //---------------------------------------------------------------
                stockAdjustWork.StockSubttlPrice += stockAdjustDtlWork.StockPriceTaxExc; // 仕入金額小計に合算
            }

            // 在庫調整データリストに追加
            // （※結果的に明細がゼロ件になった場合は不要）
            if ( stockAdjustDtlList.Count > 0 )
            {
                stockAdjustList.Add( stockAdjustWork );
            }
        }

        /// <summary>
        /// 在庫調整データの生成（商品連結データより）
        /// </summary>
        /// <param name="stockAdjustCsList">在庫調整データリスト</param>
        /// <param name="goodsUnitData">商品連結データ</param>
        /// <param name="prevStockList">変更前在庫リスト</param>
        private void CreateStockAdjustWorkFromGoodsUnitData(ref CustomSerializeArrayList stockAdjustCsList, GoodsUnitData goodsUnitData, List<Stock> prevStockList)
        {
            // 在庫情報が無い場合は迂回
            if (goodsUnitData.StockList == null || goodsUnitData.StockList.Count == 0) return;

            //---------------------------------------------------------------
            // 登録用各種設定値取得
            //---------------------------------------------------------------

            // 受払元伝票区分=42:マスタメンテ
            const int ct_AcPaySlipCd = 42;

            // 受払元取引区分=30:在庫数調整
            const int ct_AcPayTransCd = 30;

            // 作成日時(共通)
            DateTime createDateTime = DateTime.Now;

            // (ﾛｸﾞｲﾝ)従業員コード
            string stockInputCode = LoginInfoAcquisition.Employee.EmployeeCode;

            // (ﾛｸﾞｲﾝ)従業員名称
            string stockInputName = LoginInfoAcquisition.Employee.Name;
            // 2009.02.27 30413 犬飼 在庫調整データは名称16桁まで >>>>>>START
            if (stockInputName.Length > 16)
            {
                // 16桁で切り捨て
                stockInputName = stockInputName.Substring(0, 16);
            }
            // 2009.02.27 30413 犬飼 在庫調整データは名称16桁まで <<<<<<END
            // 2009.06.15 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            SecInfoAcs secInfoAcs = new SecInfoAcs();
            // 2009.06.15 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

            Dictionary<string, SecInfoSet> secInfoSetDic = new Dictionary<string, SecInfoSet>();
            // 2009.06.15 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //foreach (SecInfoSet secInfoSet in this._secInfoAcs.SecInfoSetList)
            foreach ( SecInfoSet secInfoSet in secInfoAcs.SecInfoSetList )
            // 2009.06.15 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
            {
                if (secInfoSet.LogicalDeleteCode == 0)
                {
                    secInfoSetDic.Add(secInfoSet.SectionCode.Trim(), secInfoSet);
                }
            }
            
            for (int index = 0; index < goodsUnitData.StockList.Count; index++)
            {
                //---------------------------------------------------------------
                // 在庫調整データ
                //---------------------------------------------------------------
                StockAdjustWork stockAdjustWork = new StockAdjustWork();

                # region [在庫調整]
                stockAdjustWork.CreateDateTime = createDateTime; // 作成日時
                stockAdjustWork.UpdateDateTime = DateTime.MinValue; // 更新日時
                stockAdjustWork.EnterpriseCode = _enterpriseCode; // 企業コード
                stockAdjustWork.FileHeaderGuid = Guid.Empty; // GUID
                stockAdjustWork.LogicalDeleteCode = 0; // 論理削除区分
                stockAdjustWork.SectionCode = _loginSectionCode; // 拠点コード
                stockAdjustWork.StockAdjustSlipNo = 0; // 在庫調整伝票番号
                stockAdjustWork.AcPaySlipCd = ct_AcPaySlipCd; // 受払元伝票区分
                stockAdjustWork.AcPayTransCd = ct_AcPayTransCd; // 受払元取引区分
                stockAdjustWork.AdjustDate = createDateTime; // 調整日付
                stockAdjustWork.InputDay = createDateTime; // 入力日付
                //stockAdjustWork.StockSectionCd = _loginSectionCode; // 仕入拠点コード         //DEL 2009/04/22 不具合対応[13091]
                stockAdjustWork.StockInputCode = stockInputCode; // 仕入入力者コード
                stockAdjustWork.StockInputName = stockInputName; // 仕入入力者名称
                stockAdjustWork.StockAgentCode = stockInputCode; // 仕入担当者コード
                stockAdjustWork.StockAgentName = stockInputName; // 仕入担当者名称
                stockAdjustWork.StockSubttlPrice = 0; // 仕入金額小計（←※ここでは初期値として0をセットする）
                stockAdjustWork.SlipNote = string.Empty; // 伝票備考
                //---------------------------------
                // ※仕入金額小計は
                //   全明細分を合算する必要があるので
                //   後で書き換える。
                //---------------------------------
                if (secInfoSetDic.ContainsKey(_loginSectionCode.Trim()))
                {
                    stockAdjustWork.SectionGuideNm = secInfoSetDic[_loginSectionCode.Trim()].SectionGuideNm.Trim();
                    //stockAdjustWork.StockSectionGuideNm = stockAdjustWork.SectionGuideNm;     //DEL 2009/04/22 不具合対応[13091]
                }
                # endregion


                //---------------------------------------------------------------
                // 在庫調整明細データ
                //---------------------------------------------------------------
                StockAdjustDtlWork stockAdjustDtlWork = new StockAdjustDtlWork();

                //---------------------------------------------------------------
                // 在庫オブジェクト取得
                //---------------------------------------------------------------
                // 更新差分在庫(ReflectStockDifferenceで書き変えている為)
                Stock stock = goodsUnitData.StockList[index];
                // 数量関係(の差分)がゼロならば在庫調整明細データは不要なので迂回
                //if (!CheckUpdateStock(stock)) continue;
                

                // 対応する更新前在庫
                Stock prevStock = GetStockFromStockList(stock.WarehouseCode, stock.GoodsMakerCd, stock.GoodsNo, prevStockList);

                // ---ADD 2009/04/22 不具合対応[13091] ----------------------------------------------------------->>>>>
                // 仕入先拠点コード、名称取得
                stockAdjustWork.StockSectionCd = stock.SectionCode;
                if (secInfoSetDic.ContainsKey(stockAdjustWork.StockSectionCd.Trim()))
                {
                    stockAdjustWork.StockSectionGuideNm = secInfoSetDic[stockAdjustWork.StockSectionCd.Trim()].SectionGuideNm.Trim();
                }
                // ---ADD 2009/04/22 不具合対応[13091] -----------------------------------------------------------<<<<<


                // 2009.03.17 30413 犬飼 更新在庫処理を変更 >>>>>>START
                // 2009.03.09 30413 犬飼 更新在庫のチェックを変更 >>>>>>START
                // 数量関係(の差分)がゼロならば在庫調整明細データは不要なので迂回
                //if (!CheckUpdateStockDiff(stock, prevStock)) continue;
                if (!CheckUpdateStockDiff(stock, prevStock))
                {
                    // 数量関係の差分がゼロの場合は、在庫情報のみ設定
                    CustomSerializeArrayList csListOnly = new CustomSerializeArrayList();
                    ArrayList stockWorkListOnly = new ArrayList();
                    StockWork stockWorkOnly;
                    GetStockWorkFromStock(stock, out stockWorkOnly);

                    stockWorkListOnly.Add(stockWorkOnly);
                    csListOnly.Add(stockWorkListOnly);
                    stockAdjustCsList.Add(csListOnly);
                    continue;
                }
                // 2009.03.09 30413 犬飼 更新在庫のチェックを変更 <<<<<<END
                // 2009.03.17 30413 犬飼 更新在庫処理を変更 <<<<<<END
                                
                //---------------------------------------------------------------
                // セット値算出
                //---------------------------------------------------------------

                // 標準価格・オープン価格区分
                double listPriceFl;
                int openPriceDiv;
                this.GetListPrice(out listPriceFl, out openPriceDiv, goodsUnitData.GoodsPriceList, createDateTime);

                // DEL 2009/12/10 MANTIS対応[14593]：在庫仕入数を変更して保存すると棚卸評価単価が変わる ---------->>>>>
                // FIXME:仕入単価
                //double stockUnitPriceFl;
                //GetStockUnitPriceFl(out stockUnitPriceFl, goodsUnitData.GoodsPriceList, createDateTime);
                //stock.StockUnitPriceFl = stockUnitPriceFl;
                // DEL 2009/12/10 MANTIS対応[14593]：在庫仕入数を変更して保存すると棚卸評価単価が変わる ----------<<<<<
                
                // 仕入金額算出
                Int64 stockPriceTaxExc;
                this.GetStockPriceTaxExc(out stockPriceTaxExc, stock);

                // 調整数
                // （※注意！在庫マスタ更新用に仕入在庫数は差分に書き換えた前提(this.ReflectStockDifference)）
                double adjustCount = stock.SupplierStock;


                // 変更前仕入単価（浮動）
                double bfStockUnitPriceFl = 0;
                if (prevStock != null)
                {
                    // 変更前オブジェクトがあれば「仕入単価（浮動）」をセットする
                    bfStockUnitPriceFl = prevStock.StockUnitPriceFl;
                }

                //---------------------------------------------------------------
                // 在庫調整明細生成
                //---------------------------------------------------------------

                # region [在庫調整明細]
                stockAdjustDtlWork.CreateDateTime = createDateTime; // 作成日時
                stockAdjustDtlWork.UpdateDateTime = DateTime.MinValue; // 更新日時
                stockAdjustDtlWork.EnterpriseCode = _enterpriseCode; // 企業コード
                stockAdjustDtlWork.FileHeaderGuid = Guid.Empty; // GUID
                stockAdjustDtlWork.LogicalDeleteCode = 0; // 論理削除区分
                stockAdjustDtlWork.SectionCode = stockAdjustWork.SectionCode; // 拠点コード
                stockAdjustDtlWork.StockAdjustSlipNo = stockAdjustWork.StockAdjustSlipNo; // 在庫調整伝票番号
                stockAdjustDtlWork.StockAdjustRowNo = (index + 1); // 在庫調整行番号
                stockAdjustDtlWork.SupplierFormalSrc = 0; // 仕入形式（元）
                stockAdjustDtlWork.StockSlipDtlNumSrc = 0; // 仕入明細通番（元）
                stockAdjustDtlWork.AcPaySlipCd = stockAdjustWork.AcPaySlipCd; // 受払元伝票区分
                stockAdjustDtlWork.AcPayTransCd = stockAdjustWork.AcPayTransCd; // 受払元取引区分
                stockAdjustDtlWork.AdjustDate = createDateTime; // 調整日付
                stockAdjustDtlWork.InputDay = createDateTime; // 入力日付
                stockAdjustDtlWork.GoodsMakerCd = stock.GoodsMakerCd; // 商品メーカーコード
                stockAdjustDtlWork.MakerName = stock.MakerName; // メーカー名称
                stockAdjustDtlWork.GoodsNo = stock.GoodsNo; // 商品番号
                stockAdjustDtlWork.GoodsName = stock.GoodsName; // 商品名称
                stockAdjustDtlWork.StockUnitPriceFl = stock.StockUnitPriceFl; // 仕入単価（税抜,浮動）
                stockAdjustDtlWork.BfStockUnitPriceFl = bfStockUnitPriceFl; // 変更前仕入単価（浮動）
                stockAdjustDtlWork.AdjustCount = adjustCount; // 調整数
                stockAdjustDtlWork.DtlNote = string.Empty; // 明細備考
                stockAdjustDtlWork.WarehouseCode = stock.WarehouseCode; // 倉庫コード
                stockAdjustDtlWork.WarehouseName = stock.WarehouseName; // 倉庫名称
                stockAdjustDtlWork.BLGoodsCode = goodsUnitData.BLGoodsCode; // BL商品コード
                stockAdjustDtlWork.BLGoodsFullName = goodsUnitData.BLGoodsFullName; // BL商品コード名称（全角）
                stockAdjustDtlWork.WarehouseShelfNo = stock.WarehouseShelfNo; // 倉庫棚番
                stockAdjustDtlWork.ListPriceFl = listPriceFl; // 定価（浮動）
                stockAdjustDtlWork.OpenPriceDiv = openPriceDiv; // オープン価格区分
                stockAdjustDtlWork.StockPriceTaxExc = stockPriceTaxExc; // 仕入金額（税抜き）
                stockAdjustDtlWork.GoodsName = goodsUnitData.GoodsName.Trim();  // 品名
                
                stockAdjustDtlWork.SectionGuideNm = stockAdjustWork.SectionGuideNm;
                MakerUMnt makerUMnt;
                int status = GetMaker(_enterpriseCode, stock.GoodsMakerCd, out makerUMnt);
                if (status == 0)
                {
                    stockAdjustDtlWork.MakerName = makerUMnt.MakerName.Trim();
                }
                // 2010/04/06 Del >>>
                //string goodsName;
                //status = GetGoodsName(stock.GoodsMakerCd, stock.GoodsNo, out goodsName);
                //if (status == 0)
                //{
                //    stockAdjustDtlWork.GoodsName = goodsName.Trim();
                //}
                // 2010/04/06 Del <<<
                # endregion

                //---------------------------------------------------------------
                // 金額計に合算
                //---------------------------------------------------------------
                stockAdjustWork.StockSubttlPrice += stockAdjustDtlWork.StockPriceTaxExc; // 仕入金額小計に合算

                // 伝票と明細を1対1で関連付ける
                CustomSerializeArrayList csList = new CustomSerializeArrayList();
                ArrayList stockAdjustWorkList = new ArrayList();
                ArrayList stockAdjustDtlWorkList = new ArrayList();
                ArrayList stockWorkList = new ArrayList();
                StockWork stockWork;
                GetStockWorkFromStock(stock, out stockWork);

                stockAdjustWorkList.Add(stockAdjustWork);
                stockAdjustDtlWorkList.Add(stockAdjustDtlWork);
                stockWorkList.Add(stockWork);

                csList.Add(stockAdjustWorkList);
                csList.Add(stockAdjustDtlWorkList);
                csList.Add(stockWorkList);

                stockAdjustCsList.Add(csList);
            }
        }

        /// <summary>
        /// 在庫数量更新チェック処理
        /// </summary>
        /// <param name="stockDifference"></param>
        /// <returns></returns>
        private bool CheckUpdateStock( Stock stockDifference )
        {
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/11/07 DEL
            //if ( stockDifference.SupplierStock > 0 ) return true; // 仕入在庫数
            //if ( stockDifference.AcpOdrCount > 0 ) return true; // 受注数
            //if ( stockDifference.SalesOrderCount > 0 ) return true; // 発注数
            //if ( stockDifference.MovingSupliStock > 0 ) return true; // 移動中仕入在庫数
            //if ( stockDifference.ShipmentCnt > 0 ) return true; // 出荷数（未計上）
            //if ( stockDifference.ArrivalCnt > 0 ) return true; // 入荷数（未計上）
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/11/07 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/11/07 ADD
            if ( stockDifference.SupplierStock != 0 ) return true; // 仕入在庫数
            if ( stockDifference.AcpOdrCount != 0 ) return true; // 受注数
            if ( stockDifference.SalesOrderCount != 0 ) return true; // 発注数
            if ( stockDifference.MovingSupliStock != 0 ) return true; // 移動中仕入在庫数
            if ( stockDifference.ShipmentCnt != 0 ) return true; // 出荷数（未計上）
            if ( stockDifference.ArrivalCnt != 0 ) return true; // 入荷数（未計上）
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/11/07 ADD

            // 上記項目全て(差分が)ゼロならばfalse
            return false;
        }

        /// <summary>
        /// 在庫数量更新チェック処理
        /// </summary>
        /// <param name="stockDifference"></param>
        /// <param name="prevStock"></param>
        /// <returns></returns>
        private bool CheckUpdateStockDiff(Stock stockDifference, Stock prevStock)
        {
            if (stockDifference.SupplierStock != 0) return true; // 仕入在庫数
            if (stockDifference.AcpOdrCount != 0) return true; // 受注数
            if (stockDifference.SalesOrderCount != 0) return true; // 発注数
            if (stockDifference.MovingSupliStock != 0) return true; // 移動中仕入在庫数
            if (stockDifference.ShipmentCnt != 0) return true; // 出荷数（未計上）
            if (stockDifference.ArrivalCnt != 0) return true; // 入荷数（未計上）

            // 2009.04.02 30413 犬飼 新規作成時、在庫数未入力だと調整データは作成しない >>>>>>START
            //if (prevStock == null) return true; // ADD 2009/03/10
            if (prevStock == null) return false;

            //if ((prevStock.LogicalDeleteCode != 0) || (stockDifference.LogicalDeleteCode != 0)) return true;  // 変更前後の論理削除コード
            // 2009.04.02 30413 犬飼 新規作成時、在庫数未入力だと調整データは作成しない <<<<<<END
            
            // 上記項目全て(差分が)ゼロならばfalse
            return false;
        }

        /// <summary>
        /// 商品標準価格取得処理
        /// </summary>
        /// <param name="listPriceFl"></param>
        /// <param name="openPriceDiv"></param>
        /// <param name="goodsPriceList"></param>
        /// <param name="priceDate"></param>
        private void GetListPrice( out double listPriceFl, out int openPriceDiv, List<GoodsPrice> goodsPriceList, DateTime priceDate )
        {
            listPriceFl = 0;
            openPriceDiv = 0;
            if ( goodsPriceList == null || goodsPriceList.Count == 0 ) return;

            // --- CHG 2009/01/13 障害ID:9867対応------------------------------------------------------>>>>>
            //goodsPriceList.Sort(); // メーカー(降順)・品番(降順)・価格開始日(昇順)
            goodsPriceList.Sort(delegate(GoodsPrice x, GoodsPrice y)
            {
                int targetX = TDateTime.DateTimeToLongDate(x.PriceStartDate);
                int targetY = TDateTime.DateTimeToLongDate(y.PriceStartDate);

                return targetX - targetY;
            });
            // --- CHG 2009/01/13 障害ID:9867対応------------------------------------------------------<<<<<

            int activePriceIndex = -1;
            for ( int index = goodsPriceList.Count - 1; index >= 0; index-- )
            {
                if ( goodsPriceList[index].PriceStartDate <= priceDate )
                {
                    activePriceIndex = index;
                    break;
                }
            }
            if ( activePriceIndex >= 0 )
            {
                listPriceFl = goodsPriceList[activePriceIndex].ListPrice;
                openPriceDiv = goodsPriceList[activePriceIndex].OpenPriceDiv;
            }
        }
        /// <summary>
        /// 商品仕入単価取得処理
        /// </summary>
        /// <param name="stockUnitPriceFl"></param>
        /// <param name="goodsPriceList"></param>
        /// <param name="priceDate"></param>
        private void GetStockUnitPriceFl(out double stockUnitPriceFl, List<GoodsPrice> goodsPriceList, DateTime priceDate)
        {
            stockUnitPriceFl = 0;
            if (goodsPriceList == null || goodsPriceList.Count == 0) return;

            // メーカー(降順)・品番(降順)・価格開始日(昇順)
            goodsPriceList.Sort(delegate(GoodsPrice x, GoodsPrice y)
            {
                int targetX = TDateTime.DateTimeToLongDate(x.PriceStartDate);
                int targetY = TDateTime.DateTimeToLongDate(y.PriceStartDate);

                return targetX - targetY;
            });

            int activePriceIndex = -1;
            for (int index = goodsPriceList.Count - 1; index >= 0; index--)
            {
                if (goodsPriceList[index].PriceStartDate <= priceDate)
                {
                    activePriceIndex = index;
                    break;
                }
            }
            if (activePriceIndex >= 0)
            {
                stockUnitPriceFl = goodsPriceList[activePriceIndex].SalesUnitCost;
            }
        }
        /// <summary>
        /// 仕入金額算出処理
        /// </summary>
        /// <param name="stockPriceTaxExc"></param>
        /// <param name="stock"></param>
        private void GetStockPriceTaxExc( out long stockPriceTaxExc, Stock stock )
        {
            stockPriceTaxExc = (Int64)Round((decimal)stock.StockUnitPriceFl * (decimal)stock.SupplierStock);

            // --- ADD 2009/03/19 障害ID:12231対応------------------------------------------------------>>>>>
            ArrayList retList;
            StockMngTtlSt stockMngTtlSt = new StockMngTtlSt();

            int status = this._stockMngTtlStAcs.SearchAll(out retList, LoginInfoAcquisition.EnterpriseCode);
            if (status == 0)
            {
                foreach (StockMngTtlSt result in retList)
                {
                    if ((result.LogicalDeleteCode == 0) && (result.SectionCode.Trim() == "00"))
                    {
                        stockMngTtlSt = result.Clone();
                        break;
                    }
                }
            }
            else
            {
                stockMngTtlSt = new StockMngTtlSt();
            }

            switch (stockMngTtlSt.FractionProcCd)
            {
                case 1: // 切捨て
                    {
                        stockPriceTaxExc = (Int64)Math.Floor((decimal)stock.StockUnitPriceFl * (decimal)stock.SupplierStock);
                        break;
                    }
                case 2: // 四捨五入
                    {
                        stockPriceTaxExc = (Int64)Round((decimal)stock.StockUnitPriceFl * (decimal)stock.SupplierStock);
                        break;
                    }
                case 3: // 切上げ
                    {
                        stockPriceTaxExc = (Int64)Math.Ceiling((decimal)stock.StockUnitPriceFl * (decimal)stock.SupplierStock);
                        break;
                    }
            }
            // --- ADD 2009/03/19 障害ID:12231対応------------------------------------------------------<<<<<
        }
        /// <summary>
        /// 四捨五入処理
        /// </summary>
        /// <param name="parameter">端数処理するdecimal値</param>
        /// <returns>四捨五入されたdecimal</returns>
        private static decimal Round( decimal parameter )
        {
            // 四捨五入
            return Round( parameter, 0, 5 );
        }
        /// <summary>
        /// 四捨五入処理
        /// </summary>
        /// <param name="parameter">端数処理するDouble値</param>
        /// <param name="digits">小数点以下の有効桁数</param>
        /// <param name="divide">切り上げる境界の値 1～9　(ex. 5→四捨五入)</param>
        /// <returns>四捨五入されたdecimal</returns>
        private static decimal Round( decimal parameter, int digits, int divide )
        {
            decimal dCoef = (decimal)Math.Pow( 10, digits );
            decimal dDiv = 1.0m - ((decimal)divide / 10);

            if ( parameter > 0 )
            {
                // 0.5を足して「＋のときの切り捨て」（ゼロに近づける）
                return Math.Floor( (parameter * dCoef) + dDiv ) / dCoef;
            }
            else
            {
                // -0.5を足して「－のときの切り捨て」（ゼロに近づける）
                return Math.Ceiling( (parameter * dCoef) - dDiv ) / dCoef;
            }
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/09/10 ADD

        /// <summary>
        /// 指定条件該当在庫情報データオブジェクト取得処理
        /// </summary>
        /// <param name="warehouseCode">倉庫コード</param>
        /// <param name="goodsMakerCd">メーカーコード</param>
        /// <param name="goodsNo">品番</param>
        /// <param name="stockList">在庫データオブジェクトリスト</param>
        /// <returns>在庫データオブジェクト</returns>
        public Stock GetStockFromStockList( string warehouseCode, int goodsMakerCd, string goodsNo, List<Stock> stockList )
        {
            Stock retStock = null;
            foreach ( Stock stock in stockList )
            {
                if ( (stock.WarehouseCode.Trim() == warehouseCode.Trim()) &&
                    (stock.GoodsMakerCd == goodsMakerCd) &&
                    (stock.GoodsNo == goodsNo) )
                {
                    retStock = stock;
                }
            }
            return retStock;
        }
    }
}

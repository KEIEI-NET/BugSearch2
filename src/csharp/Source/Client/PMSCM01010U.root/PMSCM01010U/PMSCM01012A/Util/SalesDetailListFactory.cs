//****************************************************************************//
// システム         : 自働回答処理
// プログラム名称   : 自働回答処理アクセス
// プログラム概要   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 工藤 恵優
// 作 成 日  2009/06/29  修正内容 : 新規作成
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;

using Broadleaf.Application.Controller.Agent;
using Broadleaf.Application.UIData;
using Broadleaf.Application.UIData.Util;

namespace Broadleaf.Application.Controller.Util
{
    using SalesTtlStServer = SingletonInstance<SalesTtlStAgent>;    // 売上全体設定マスタ

    /// <summary>
    /// ソート済み売上明細データリストの生成クラス
    /// </summary>
    public static class SortedSalesDetailListFactory
    {
        /// <summary>
        /// ソート済み売上明細データリストを生成します。
        /// </summary>
        /// <remarks>
        /// MAHNB01012AA.cs SalesSlipInputAcs.MakeSalesSlipSort() 14278行目より移植
        /// </remarks>
        /// <param name="salesSlip">売上データ</param>
        /// <param name="sourceSalesDetailList">元となる売上明細データのリスト</param>
        /// <returns>ソート済み売上明細データリスト</returns>
        public static IList<SalesDetail> CreateSortedSalesDetailList(
            SalesSlip salesSlip,
            IList<SalesDetail> sourceSalesDetailList
        )
        {
            SalesTtlSt salesTotalSetting = SalesTtlStServer.Singleton.Instance.Find(
                salesSlip.EnterpriseCode,
                salesSlip.SectionCode
            );
            if (salesTotalSetting == null) return sourceSalesDetailList;

            switch (salesTotalSetting.SlipCreateProcess)
            {
                case 0: // 入力順(行番号順)
                    return sourceSalesDetailList;

                case 1: // 在庫・取寄順(在庫取寄区分(0:取寄 1:在庫)・行番号順)
                    return OrderBySalesOrderDivCd(sourceSalesDetailList);

                case 2: // 倉庫順(倉庫・行番号順)
                case 3: // 出力先別(倉庫・行番号順)
                    return OrderByWarehouseCode(sourceSalesDetailList);
            }

            return sourceSalesDetailList;
        }

        #region <在庫・取寄順(在庫取寄区分(0:取寄 1:在庫)・行番号順)>

        /// <summary>
        /// 在庫・取寄順(在庫取寄区分(0:取寄 1:在庫)・行番号順)でソートします。
        /// </summary>
        /// <remarks>
        /// MAHNB01012AA.cs SalesSlipInputAcs.MakeSalesSlipSort() 14278行目より移植
        /// </remarks>
        /// <param name="sourceSalesDetailList">元となる売上明細データのリスト</param>
        /// <returns>
        /// 在庫・取寄順(在庫取寄区分(0:取寄 1:在庫)・行番号順)でソートした売上明細データのリスト
        /// </returns>
        private static IList<SalesDetail> OrderBySalesOrderDivCd(IList<SalesDetail> sourceSalesDetailList)
        {
            SortedList<string, SalesDetail> sortedList = new SortedList<string, SalesDetail>();
            for (int i = 0; i < sourceSalesDetailList.Count; i++)
            {
                string sortKey = GetKeyOfOrderBySalesOrderDivCd(sourceSalesDetailList[i], i);
                sortedList.Add(sortKey, sourceSalesDetailList[i]);
            }

            IList<SalesDetail> orderBySalesOrderDivCdList = ConvertSalesDetailList(sortedList);
            return orderBySalesOrderDivCdList.Count > 0 ? orderBySalesOrderDivCdList : sourceSalesDetailList;
        }

        /// <summary>
        /// 在庫・取寄順(在庫取寄区分(0:取寄 1:在庫)・行番号順)のソートキーを取得します。
        /// </summary>
        /// <param name="salesDetail">売上明細データ</param>
        /// <param name="salesRowNo">行番号</param>
        /// <returns></returns>
        private static string GetKeyOfOrderBySalesOrderDivCd(
            SalesDetail salesDetail,
            int salesRowNo
        )
        {
            //sortString = string.Format("{0} DESC,{1}",
            //    salesDetailDataTable.SalesOrderDivCdColumn.ColumnName,
            //    salesDetailDataTable.SalesRowNoColumn.ColumnName
            //);
            return Math.Abs(salesDetail.SalesOrderDivCd - 1).ToString() + salesRowNo.ToString("0000");
        }

        #endregion // </在庫・取寄順(在庫取寄区分(0:取寄 1:在庫)・行番号順)>

        #region <倉庫順(倉庫・行番号順)／出力先別(倉庫・行番号順)>

        /// <summary>
        /// 倉庫順(倉庫・行番号順)でソートします。
        /// </summary>
        /// <remarks>
        /// MAHNB01012AA.cs SalesSlipInputAcs.MakeSalesSlipSort() 14278行目より移植
        /// </remarks>
        /// <param name="sourceSalesDetailList">元となる売上明細データのリスト</param>
        /// <returns>
        /// 倉庫順(倉庫・行番号順)でソートした売上明細データのリスト
        /// </returns>
        private static IList<SalesDetail> OrderByWarehouseCode(IList<SalesDetail> sourceSalesDetailList)
        {
            SortedList<string, SalesDetail> sortedList = new SortedList<string, SalesDetail>();
            for (int i = 0; i < sourceSalesDetailList.Count; i++)
            {
                string sortKey = GetKeyOfOrderByWarehouseCode(sourceSalesDetailList[i], i);
                sortedList.Add(sortKey, sourceSalesDetailList[i]);
            }

            IList<SalesDetail> orderByWarehouseCodeList = ConvertSalesDetailList(sortedList);
            return orderByWarehouseCodeList.Count > 0 ? orderByWarehouseCodeList : sourceSalesDetailList;
        }

        /// <summary>
        /// 倉庫順(倉庫・行番号順)のソートキーを取得します。
        /// </summary>
        /// <param name="salesDetail">売上明細データ</param>
        /// <param name="salesRowNo">行番号</param>
        /// <returns></returns>
        private static string GetKeyOfOrderByWarehouseCode(
            SalesDetail salesDetail,
            int salesRowNo
        )
        {
            //sortString = string.Format("{0},{1}",
            //    salesDetailDataTable.WarehouseCodeColumn.ColumnName,
            //    salesDetailDataTable.SalesRowNoColumn.ColumnName
            //);
            return SCMEntityUtil.ConvertNumber(salesDetail.WarehouseCode).ToString("000000") + salesRowNo.ToString("0000");
        }

        #endregion // </倉庫順(倉庫・行番号順)／出力先別(倉庫・行番号順)>

        /// <summary>
        /// 売上明細データリストに変換します。
        /// </summary>
        /// <param name="sortedList">あるソートキーでソートされた売上明細データリスト</param>
        /// <returns>売上明細データリスト</returns>
        private static IList<SalesDetail> ConvertSalesDetailList(SortedList<string, SalesDetail> sortedList)
        {
            IList<SalesDetail> sortedSalesDetailList = new List<SalesDetail>();
            {
                foreach (KeyValuePair<string, SalesDetail> sortedSalesDetail in sortedList)
                {
                    sortedSalesDetailList.Add(sortedSalesDetail.Value);
                }
            }
            return sortedSalesDetailList;
        }
    }
}

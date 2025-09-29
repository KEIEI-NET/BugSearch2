//**********************************************************************//
// システム         ：.NSシリーズ
// プログラム名称   ：在庫マスタ一覧印刷
// プログラム概要   ：在庫マスタ一覧の印刷を行う
// ---------------------------------------------------------------------//
//					Copyright(c) 2008 Broadleaf Co.,Ltd.				//
// =====================================================================//
// 履歴
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：30413 犬飼
// 修正日    2009/01/13     修正内容：新規作成
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：30413 犬飼
// 修正日    2009/04/20     修正内容：Mantis【12127】速度アップ対応
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：照田
// 修正日    2009/06/02     修正内容：不具合対応[13368]
// ---------------------------------------------------------------------//

using System;
using System.IO;
using System.Text;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;

using Broadleaf.Library.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Text;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 在庫マスタ一覧印刷 アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 在庫マスタ一覧の印刷を行う。</br>
    /// <br>Programmer : 30413 犬飼</br>
    /// <br>Date       : 2009/01/13</br>
    /// <br></br>
    /// <br>UpdateNote : 2009/04/20 30413 犬飼　　　 Mantis【12127】速度アップ対応</br>
    /// <br>           : 2009/06/02 　　　照田 貴志　不具合対応[13368]</br>
    /// </remarks>
    public class PMZAI02029AB
    {
        # region [DataSetに格納するテーブルの名称]
        /// <summary>在庫マスタ一覧テーブル</summary>
        public const string CT_Tbl_StockList = "StockList";
        # endregion

        # region [private const]
        private const string ct_DateFormat = "YYYY/MM/DD";
        private const string ct_TimeFormat = "HH:MM";
        # endregion

        # region [データテーブル生成]
        /// <summary>
        /// データテーブル生成処理（請求書リストテーブルスキーマ定義）
        /// </summary>
        /// <returns></returns>
        public static DataTable CreateBillListTable()
        {
            DataTable table = new DataTable( CT_Tbl_StockList );

            // 印刷情報
            table.Columns.Add(new DataColumn("STOCKRF.SECTIONCODERF", typeof(String)));             // 拠点コード
            table.Columns.Add(new DataColumn("STOCKRF.WAREHOUSECODERF", typeof(String)));           // 倉庫コード
            table.Columns.Add(new DataColumn("STOCKRF.GOODSMAKERCDRF", typeof(Int32)));             // 商品メーカーコード
            table.Columns.Add(new DataColumn("STOCKRF.GOODSNORF", typeof(String)));                 // 商品番号
            table.Columns.Add(new DataColumn("STOCKRF.STOCKUNITPRICEFLRF", typeof(Double)));        // 仕入単価（税抜,浮動）
            table.Columns.Add(new DataColumn("STOCKRF.SUPPLIERSTOCKRF", typeof(Double)));           // 仕入在庫数
            table.Columns.Add(new DataColumn("STOCKRF.ACPODRCOUNTRF", typeof(Double)));             // 受注数
            table.Columns.Add(new DataColumn("STOCKRF.MONTHORDERCOUNTRF", typeof(Double)));         // M/O発注数
            table.Columns.Add(new DataColumn("STOCKRF.SALESORDERCOUNTRF", typeof(Double)));         // 発注数
            table.Columns.Add(new DataColumn("STOCKRF.STOCKDIVRF", typeof(String)));                // 在庫区分
            table.Columns.Add(new DataColumn("STOCKRF.MOVINGSUPLISTOCKRF", typeof(Double)));        // 移動中仕入在庫数
            table.Columns.Add(new DataColumn("STOCKRF.SHIPMENTPOSCNTRF", typeof(Double)));          // 出荷可能数
            table.Columns.Add(new DataColumn("STOCKRF.STOCKTOTALPRICERF", typeof(Int64)));          // 在庫保有総額
            table.Columns.Add(new DataColumn("STOCKRF.LASTSTOCKDATERF", typeof(String)));           // 最終仕入年月日
            table.Columns.Add(new DataColumn("STOCKRF.LASTSALESDATERF", typeof(String)));           // 最終売上日
            table.Columns.Add(new DataColumn("STOCKRF.LASTINVENTORYUPDATERF", typeof(String)));     // 最終棚卸更新日
            table.Columns.Add(new DataColumn("STOCKRF.MINIMUMSTOCKCNTRF", typeof(Double)));         // 最低在庫数
            table.Columns.Add(new DataColumn("STOCKRF.MAXIMUMSTOCKCNTRF", typeof(Double)));         // 最高在庫数
            table.Columns.Add(new DataColumn("STOCKRF.NMLSALODRCOUNTRF", typeof(Double)));          // 基準発注数
            table.Columns.Add(new DataColumn("STOCKRF.SALESORDERUNITRF", typeof(Int32)));           // 発注単位
            table.Columns.Add(new DataColumn("STOCKRF.STOCKSUPPLIERCODERF", typeof(Int32)));        // 在庫発注先コード
            table.Columns.Add(new DataColumn("STOCKRF.WAREHOUSESHELFNORF", typeof(String)));        // 倉庫棚番
            table.Columns.Add(new DataColumn("STOCKRF.DUPLICATIONSHELFNO1RF", typeof(String)));     // 重複棚番１
            table.Columns.Add(new DataColumn("STOCKRF.DUPLICATIONSHELFNO2RF", typeof(String)));     // 重複棚番２
            table.Columns.Add(new DataColumn("STOCKRF.PARTSMANAGEMENTDIVIDE1RF", typeof(String)));  // 部品管理区分１
            table.Columns.Add(new DataColumn("STOCKRF.PARTSMANAGEMENTDIVIDE2RF", typeof(String)));  // 部品管理区分２
            table.Columns.Add(new DataColumn("STOCKRF.STOCKNOTE1RF", typeof(String)));              // 在庫備考１
            table.Columns.Add(new DataColumn("STOCKRF.STOCKNOTE2RF", typeof(String)));              // 在庫備考２
            table.Columns.Add(new DataColumn("STOCKRF.SHIPMENTCNTRF", typeof(Double)));             // 出荷数（未計上）
            table.Columns.Add(new DataColumn("STOCKRF.ARRIVALCNTRF", typeof(Double)));              // 入荷数（未計上）
            table.Columns.Add(new DataColumn("STOCKRF.STOCKCREATEDATERF", typeof(String)));         // 在庫登録日
            table.Columns.Add(new DataColumn("STOCKRF.UPDATEDATERF", typeof(String)));              // 更新年月日
            table.Columns.Add(new DataColumn("STOCKRF.SECTIONGUIDESNMRF", typeof(String)));         // 拠点ガイド略称
            table.Columns.Add(new DataColumn("STOCKRF.WAREHOUSENAMERF", typeof(String)));           // 倉庫名称
            table.Columns.Add(new DataColumn("STOCKRF.MAKERSHORTNAMERF", typeof(String)));          // メーカー略称
            table.Columns.Add(new DataColumn("STOCKRF.STOCKSUPPLIERSNMRF", typeof(String)));        // 在庫発注先名称
            table.Columns.Add(new DataColumn("STOCKRF.GOODSNAMERF", typeof(String)));               // 商品名称
            table.Columns.Add(new DataColumn("STOCKRF.BLGOODSCODERF", typeof(Int32)));              // BL商品コード
            table.Columns.Add(new DataColumn("STOCKRF.BLGOODSHALFNAMERF", typeof(String)));         // BL商品コード名称（半角）
            table.Columns.Add(new DataColumn("STOCKRF.GOODSLGROUPRF", typeof(Int32)));              // 商品大分類コード
            table.Columns.Add(new DataColumn("STOCKRF.GOODSMGROUPRF", typeof(Int32)));              // 商品中分類コード
            table.Columns.Add(new DataColumn("STOCKRF.BLGROUPCODERF", typeof(Int32)));              // BLグループコード
            table.Columns.Add(new DataColumn("STOCKRF.BLGROUPKANANAMERF", typeof(String)));         // BLグループコードカナ名称
            table.Columns.Add(new DataColumn("STOCKRF.GOODSLGROUPNAMERF", typeof(String)));         // 商品大分類名称
            table.Columns.Add(new DataColumn("STOCKRF.GOODSMGROUPNAMERF", typeof(String)));         // 商品中分類名称
            table.Columns.Add(new DataColumn("STOCKRF.SUPPLIERCDRF", typeof(Int32)));               // 仕入先コード
            table.Columns.Add(new DataColumn("STOCKRF.SUPPLIERSNMRF", typeof(String)));             // 仕入先略称
            table.Columns.Add(new DataColumn("STOCKRF.LISTPRICERF", typeof(Double)));               // 定価（浮動）
            table.Columns.Add(new DataColumn("STOCKRF.SALESUNITCOSTRF", typeof(Double)));           // 原価単価
            table.Columns.Add(new DataColumn("STOCKRF.COSTUNPRCRATEMARKRF", typeof(String)));       // 原価単価掛率マーク
            table.Columns.Add(new DataColumn("STOCKRF.PRINTDATERF", typeof(String)));               // 作成日
            table.Columns.Add(new DataColumn("STOCKRF.PRINTTIMERF", typeof(String)));               // 作成時間
            table.Columns.Add(new DataColumn("STOCKRF.PRINTPAGERF", typeof(Int32)));                // ページ数
            table.Columns.Add(new DataColumn("STOCKRF.PRINTRANGERF", typeof(String)));              // 抽出範囲

            return table;
        }
        # endregion

        # region [データ移行（DataClass→DataTable）]
        /// <summary>
        /// データ移行処理（在庫マスタ一覧　全件コピー）
        /// </summary>
        /// <param name="table"></param>
        /// <param name="paraWork"></param>
        /// <param name="printBillList"></param>
        /// <param name="regNo"></param>
        /// <param name="sectionCode"></param>
        public static void CopyToBillListTable(ref DataTable table, ExtrInfo_StockMasterTbl paraWork, ArrayList printList, int regNo, string sectionCode, Dictionary<string, string> costUnPrcRateMarkDic)
        {
            string enterpriseCode = paraWork.EnterpriseCode;

            // 現在日付時刻を取得
            DateTime nowDate = DateTime.Now;
            string printDate = TDateTime.DateTimeToString(ct_DateFormat, nowDate);
            string printTime = TDateTime.DateTimeToString(ct_TimeFormat, nowDate);
            
            // 倉庫のグループサプレス対応
            string cmpWareCode = string.Empty;

            // 在庫マスタ一覧展開
            for (int index = 0; index < printList.Count; index++)
            {
                DataRow row = table.NewRow();

                //--------------------------------------------------------
                // 印刷情報の格納
                //--------------------------------------------------------
                
                // ※このタイミングでは完全には展開せず、データクラスのまま印刷(P)に渡します。
                //   並び替えや、空白行制御、サプレス制御など、
                //   印刷に必要な残りの処理はすべて印刷(P)に任せます。

                RsltInfo_StockMasterTblWork rsltInfo_StockMasterTblWork = null;
                rsltInfo_StockMasterTblWork = (RsltInfo_StockMasterTblWork)printList[index];

                // 印刷情報
                row["STOCKRF.SECTIONCODERF"] = rsltInfo_StockMasterTblWork.SectionCode;                         // 拠点コード
                row["STOCKRF.WAREHOUSECODERF"] = rsltInfo_StockMasterTblWork.WarehouseCode;                     // 倉庫コード
                row["STOCKRF.GOODSMAKERCDRF"] = rsltInfo_StockMasterTblWork.GoodsMakerCd;                       // 商品メーカーコード
                row["STOCKRF.GOODSNORF"] = rsltInfo_StockMasterTblWork.GoodsNo;                                 // 品番
                row["STOCKRF.STOCKUNITPRICEFLRF"] = rsltInfo_StockMasterTblWork.StockUnitPriceFl;               // 仕入単価（税抜,浮動）
                row["STOCKRF.SUPPLIERSTOCKRF"] = rsltInfo_StockMasterTblWork.SupplierStock;                     // 仕入在庫数
                row["STOCKRF.ACPODRCOUNTRF"] = rsltInfo_StockMasterTblWork.AcpOdrCount;                         // 受注数
                row["STOCKRF.MONTHORDERCOUNTRF"] = rsltInfo_StockMasterTblWork.MonthOrderCount;                 // M/O発注数
                row["STOCKRF.SALESORDERCOUNTRF"] = rsltInfo_StockMasterTblWork.SalesOrderCount;                 // 発注数
                row["STOCKRF.MOVINGSUPLISTOCKRF"] = rsltInfo_StockMasterTblWork.MovingSupliStock;               // 移動中仕入在庫数
                row["STOCKRF.SHIPMENTPOSCNTRF"] = rsltInfo_StockMasterTblWork.ShipmentPosCnt;                   // 出荷可能数
                row["STOCKRF.STOCKTOTALPRICERF"] = rsltInfo_StockMasterTblWork.StockTotalPrice;                 // 在庫保有総額
                row["STOCKRF.MINIMUMSTOCKCNTRF"] = rsltInfo_StockMasterTblWork.MinimumStockCnt;                 // 最低在庫数
                row["STOCKRF.MAXIMUMSTOCKCNTRF"] = rsltInfo_StockMasterTblWork.MaximumStockCnt;                 // 最高在庫数
                row["STOCKRF.NMLSALODRCOUNTRF"] = rsltInfo_StockMasterTblWork.NmlSalOdrCount;                   // 基準発注数
                row["STOCKRF.SALESORDERUNITRF"] = rsltInfo_StockMasterTblWork.SalesOrderUnit;                   // 発注単位
                row["STOCKRF.STOCKSUPPLIERCODERF"] = rsltInfo_StockMasterTblWork.StockSupplierCode;             // 在庫発注先コード
                row["STOCKRF.WAREHOUSESHELFNORF"] = rsltInfo_StockMasterTblWork.WarehouseShelfNo;               // 倉庫棚番
                row["STOCKRF.DUPLICATIONSHELFNO1RF"] = rsltInfo_StockMasterTblWork.DuplicationShelfNo1;         // 重複棚番１
                row["STOCKRF.DUPLICATIONSHELFNO2RF"] = rsltInfo_StockMasterTblWork.DuplicationShelfNo2;         // 重複棚番２
                row["STOCKRF.PARTSMANAGEMENTDIVIDE1RF"] = rsltInfo_StockMasterTblWork.PartsManagementDivide1;   // 部品管理区分１
                row["STOCKRF.PARTSMANAGEMENTDIVIDE2RF"] = rsltInfo_StockMasterTblWork.PartsManagementDivide2;   // 部品管理区分２
                row["STOCKRF.STOCKNOTE1RF"] = rsltInfo_StockMasterTblWork.StockNote1;                           // 在庫備考１
                row["STOCKRF.STOCKNOTE2RF"] = rsltInfo_StockMasterTblWork.StockNote2;                           // 在庫備考２
                row["STOCKRF.SHIPMENTCNTRF"] = rsltInfo_StockMasterTblWork.ShipmentCnt;                         // 出荷数（未計上）
                row["STOCKRF.ARRIVALCNTRF"] = rsltInfo_StockMasterTblWork.ArrivalCnt;                           // 入荷数（未計上）
                row["STOCKRF.SECTIONGUIDESNMRF"] = rsltInfo_StockMasterTblWork.SectionGuideSnm;                 // 拠点ガイド略称
                row["STOCKRF.WAREHOUSENAMERF"] = rsltInfo_StockMasterTblWork.WarehouseName;                     // 倉庫名称
                //row["STOCKRF.MAKERSHORTNAMERF"] = rsltInfo_StockMasterTblWork.MakerShortName;                   // メーカー略称       //DEL 2009/06/02 不具合対応[13368]
                row["STOCKRF.MAKERSHORTNAMERF"] = rsltInfo_StockMasterTblWork.MakerName;                        // メーカー名称         //ADD 2009/06/02 不具合対応[13368]
                row["STOCKRF.STOCKSUPPLIERSNMRF"] = rsltInfo_StockMasterTblWork.StockSupplierSnm;               // 在庫発注先名称
                row["STOCKRF.GOODSNAMERF"] = rsltInfo_StockMasterTblWork.GoodsName;                             // 商品名称
                row["STOCKRF.BLGOODSCODERF"] = rsltInfo_StockMasterTblWork.BLGoodsCode;                         // BL商品コード
                row["STOCKRF.BLGOODSHALFNAMERF"] = rsltInfo_StockMasterTblWork.BLGoodsHalfName;                 // BL商品コード名称（半角）
                row["STOCKRF.GOODSLGROUPRF"] = rsltInfo_StockMasterTblWork.GoodsLGroup;                         // 商品大分類コード
                row["STOCKRF.GOODSMGROUPRF"] = rsltInfo_StockMasterTblWork.GoodsMGroup;                         // 商品中分類コード
                row["STOCKRF.BLGROUPCODERF"] = rsltInfo_StockMasterTblWork.BLGroupCode;                         // BLグループコード
                row["STOCKRF.BLGROUPKANANAMERF"] = rsltInfo_StockMasterTblWork.BLGroupKanaName;                 // BLグループコードカナ名称
                row["STOCKRF.GOODSLGROUPNAMERF"] = rsltInfo_StockMasterTblWork.GoodsLGroupName;                 // 商品大分類名称
                row["STOCKRF.GOODSMGROUPNAMERF"] = rsltInfo_StockMasterTblWork.GoodsMGroupName;                 // 商品中分類名称
                row["STOCKRF.SUPPLIERCDRF"] = rsltInfo_StockMasterTblWork.SupplierCd;                           // 仕入先コード
                row["STOCKRF.SUPPLIERSNMRF"] = rsltInfo_StockMasterTblWork.SupplierSnm;                         // 仕入先略称
                row["STOCKRF.LISTPRICERF"] = rsltInfo_StockMasterTblWork.ListPrice;                             // 定価（浮動）
                row["STOCKRF.SALESUNITCOSTRF"] = rsltInfo_StockMasterTblWork.SalesUnitCost;                     // 原価単価
                row["STOCKRF.PRINTDATERF"] = printDate;                                                         // 作成日
                row["STOCKRF.PRINTTIMERF"] = printTime;                                                         // 作成時間
                //row["STOCKRF.PRINTRANGERF"] = extarCondition;                                                   // 抽出範囲

                // 未設定時 非印字コード
                # region [未設定]
                if (IsZero(rsltInfo_StockMasterTblWork.SectionCode)) row["STOCKRF.SECTIONCODERF"] = DBNull.Value;               // 拠点コード
                if (IsZero(rsltInfo_StockMasterTblWork.WarehouseCode)) row["STOCKRF.WAREHOUSECODERF"] = DBNull.Value;           // 倉庫コード
                if (IsZero(rsltInfo_StockMasterTblWork.GoodsMakerCd)) row["STOCKRF.GOODSMAKERCDRF"] = DBNull.Value;             // メーカーコード
                if (IsZero(rsltInfo_StockMasterTblWork.StockSupplierCode)) row["STOCKRF.STOCKSUPPLIERCODERF"] = DBNull.Value;   // 在庫発注先コード
                if (IsZero(rsltInfo_StockMasterTblWork.BLGoodsCode)) row["STOCKRF.BLGOODSCODERF"] = DBNull.Value;               // BL商品コード
                if (IsZero(rsltInfo_StockMasterTblWork.GoodsLGroup)) row["STOCKRF.GOODSLGROUPRF"] = DBNull.Value;               // 商品大分類コード
                if (IsZero(rsltInfo_StockMasterTblWork.GoodsMGroup)) row["STOCKRF.GOODSMGROUPRF"] = DBNull.Value;               // 商品中分類コード
                if (IsZero(rsltInfo_StockMasterTblWork.BLGroupCode)) row["STOCKRF.BLGROUPCODERF"] = DBNull.Value;               // BLグループコード
                if (IsZero(rsltInfo_StockMasterTblWork.SupplierCd)) row["STOCKRF.SUPPLIERCDRF"] = DBNull.Value;                 // 仕入先コード
                # endregion

                // 日付フォーマット変更
                row["STOCKRF.LASTSTOCKDATERF"] = TDateTime.DateTimeToString(ct_DateFormat, rsltInfo_StockMasterTblWork.LastStockDate);                  // 最終仕入年月日
                row["STOCKRF.LASTSALESDATERF"] = TDateTime.DateTimeToString(ct_DateFormat, rsltInfo_StockMasterTblWork.LastSalesDate);                  // 最終売上日
                row["STOCKRF.LASTINVENTORYUPDATERF"] = TDateTime.DateTimeToString(ct_DateFormat, rsltInfo_StockMasterTblWork.LastInventoryUpdate);      // 最終棚卸更新日
                row["STOCKRF.STOCKCREATEDATERF"] = TDateTime.DateTimeToString(ct_DateFormat, rsltInfo_StockMasterTblWork.StockCreateDate);              // 在庫登録日
                row["STOCKRF.UPDATEDATERF"] = TDateTime.DateTimeToString(ct_DateFormat, rsltInfo_StockMasterTblWork.UpdateDate);                        // 更新年月日
                
                // 区分設定
                if (rsltInfo_StockMasterTblWork.StockDiv == 0)
                {
                    // 自社
                    row["STOCKRF.STOCKDIVRF"] = "自社";                                                         // 在庫区分
                }
                else
                {
                    // 受託
                    row["STOCKRF.STOCKDIVRF"] = "受託";                                                         // 在庫区分
                }

                // 原価単価掛率マーク
                string key = CreateKey(rsltInfo_StockMasterTblWork);
                if (costUnPrcRateMarkDic.ContainsKey(key))
                {
                    row["STOCKRF.COSTUNPRCRATEMARKRF"] = costUnPrcRateMarkDic[key];
                }
                else
                {
                    row["STOCKRF.COSTUNPRCRATEMARKRF"] = "";
                }

                // 行追加
                table.Rows.Add( row );
            }
        }
        # endregion

        #region 原価単価掛率マーク用キー作成
        /// <summary>
        /// 原価単価掛率マークのキャッシュ用キー作成
        /// </summary>
        /// <param name="rsltInfo_StockMasterTblWork">抽出結果</param>
        /// <returns>key</returns>
        /// <remarks>
        /// <br>Note       : 原価単価掛率マークのキャッシュ用のキーを作成します。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2009.03.09</br>
        /// </remarks>
        public static string CreateKey(RsltInfo_StockMasterTblWork rsltInfo_StockMasterTblWork)
        {
            // 拠点＋倉庫＋メーカーコード＋品番
            string key = rsltInfo_StockMasterTblWork.SectionCode.TrimEnd() + "-"
                       + rsltInfo_StockMasterTblWork.WarehouseCode.TrimEnd() + "-"
                       + rsltInfo_StockMasterTblWork.GoodsMakerCd.ToString("d04") + "-"
                       + rsltInfo_StockMasterTblWork.GoodsNo;
            return key;
        }
        #endregion

        # region [データゼロ判定]
        /// <summary>
        /// 文字列コードのゼロ判定
        /// </summary>
        /// <param name="textValue"></param>
        /// <returns></returns>
        private static bool IsZero(string textValue)
        {
            if (textValue == null || textValue.Trim() == string.Empty) return true;

            try
            {
                return (Int32.Parse(textValue) == 0);
            }
            catch
            {
                return true;
            }
        }
        /// <summary>
        /// 数値コードのゼロ判定
        /// </summary>
        /// <param name="intValue"></param>
        /// <returns></returns>
        private static bool IsZero(int intValue)
        {
            return (intValue == 0);
        }
        # endregion
    }
}

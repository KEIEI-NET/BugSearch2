//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 棚卸マスタ（エクスポート）
// プログラム概要   : 棚卸マスタ（エクスポート）を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 朱宝軍
// 作 成 日  2009/05/13  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 朱宝軍
// 修 正 日  2009/06/26  修正内容 : PVCS277 棚卸過不足更新
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;

using Broadleaf.Library.Globarization;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 棚卸マスタ（エクスポート）クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 棚卸マスタ（エクスポート）インスタンスの作成を行う。</br>
    /// <br>Programmer : 朱宝軍</br>
    /// <br>Date       : 2009.05.12</br>
    /// </remarks>
    public class InventoryExportAcs
    {
        #region ■ Private Member
        private const string PRINTSET_TABLE = "InventoryExp";
        private IInventInputSearchDB _iInventInputSearchDB;
        #endregion

        # region ■Constracter
        /// <summary>
        /// 棚卸マスタ（エクスポート）アクセスクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 棚卸マスタ（エクスポート）アクセスクラス。</br>
        /// <br>Programmer : 朱宝軍</br>
        /// <br>Date       : 2009.05.12</br>
        /// </remarks>
        public InventoryExportAcs()
        {
            _iInventInputSearchDB = (IInventInputSearchDB)MediationInventInputSearchDB.GetInventInputSearchDB();
        }
        #endregion

        #region ■ 棚卸マスタ情報検索
        /// <summary>
        /// 棚卸マスタデータ取得処理
        /// </summary>
        /// <param name="condition">検索条件</param>
        /// <param name="dataTable">検索データ</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : 棚卸マスタデータ取得処理を行う。</br>
        /// <br>Programmer : 朱宝軍</br>
        /// <br>Date       : 2009.05.12</br>
        /// </remarks>
        public int Search(InventoryExportWork condition, out DataTable dataTable)
        {
            string message = "";
            int status = 0;
            dataTable = new DataTable(PRINTSET_TABLE);
            // DataTableのColumnsを追加する
            CreateDataTable(ref dataTable);
            // 検索条件を設定
            InventInputSearchCndtnWork iisCndtnWork = new InventInputSearchCndtnWork();
            iisCndtnWork.EnterpriseCode = condition.EnterpriseCode;
            iisCndtnWork.St_InventorySeqNo = condition.InventorySeqNoSt;
            iisCndtnWork.Ed_InventorySeqNo = condition.InventorySeqNoEd;
            // ADD 2009/06/26 --->>>
            // 棚卸過不足更新
            iisCndtnWork.SelectedPaperKind = -1;
            // ADD 2009/06/19 ---<<<

            // 棚卸データ取得
            object retObj = null;
            try
            {
                status = _iInventInputSearchDB.Search(out retObj, (object)iisCndtnWork, 1, ConstantManagement.LogicalMode.GetData0);
            }
            catch (Exception ex)
            {
                message = ex.Message;
                status = 1000;
            }
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                ConverToDataSetCustomerInf((ArrayList)retObj, ref dataTable);
            }
            if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND || status == (int)ConstantManagement.DB_Status.ctDB_EOF)
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            }
            return status;
        }
        #endregion

        #region ■ Private Methods

        /// <summary>
        /// DataTableのColumnsを追加する
        /// </summary>
        /// <param name="dataTable">結果DataTable</param>
        /// <remarks>
        /// <br>Note       : DataTableのColumnsを追加する。</br>
        /// <br>Programmer : 朱宝軍</br>
        /// <br>Date       : 2009.05.12</br>
        /// </remarks>
        private void CreateDataTable(ref DataTable dataTable)
        {
            dataTable.Columns.Add("InventorySeqNoRF", typeof(Int32));           // 棚卸通番
            dataTable.Columns.Add("WarehouseCodeRF", typeof(string));           //  倉庫コード
            dataTable.Columns.Add("GoodsNoRF", typeof(string));                 // 品番
            dataTable.Columns.Add("GoodsMakerCdRF", typeof(string));             //  メーカー
            dataTable.Columns.Add("SectionCodeRF", typeof(string));             // 管理拠点
            dataTable.Columns.Add("SupplierCdRF", typeof(string));               //  仕入先
            dataTable.Columns.Add("GoodsLGroupRF", typeof(string));              // 商品大分類
            dataTable.Columns.Add("GoodsMGroupRF", typeof(string));              //  商品中分類
            dataTable.Columns.Add("BLGroupCodeRF", typeof(string));              // グループコード
            dataTable.Columns.Add("BLGoodsCodeRF", typeof(string));              //  BL商品コード
            dataTable.Columns.Add("InventoryDayRF", typeof(string));            // 棚卸実施日
            dataTable.Columns.Add("InventoryDateRF", typeof(string));           //  棚卸日
            dataTable.Columns.Add("InventoryStockCntRF", typeof(string));       // 棚卸数
            dataTable.Columns.Add("WarehouseShelfNoRF", typeof(string));        //  棚番
            dataTable.Columns.Add("DuplicationShelfNo1RF", typeof(string));     // 重複棚番１
            dataTable.Columns.Add("DuplicationShelfNo2RF", typeof(string));     //  重複棚番２
            dataTable.Columns.Add("BfStockUnitPriceFlRF", typeof(string));      // 変更前在庫単価
            dataTable.Columns.Add("StockTotalRF", typeof(string));              //  現在庫数
            dataTable.Columns.Add("StockMashinePriceRF", typeof(string));       // 現在庫額
            dataTable.Columns.Add("StockUnitPriceFlRF", typeof(string));        // 在庫単価
            dataTable.Columns.Add("InventoryStockPriceRF", typeof(long));       //  棚卸金額
            dataTable.Columns.Add("InventoryTolerancCntRF", typeof(string));    //  過不足数
            dataTable.Columns.Add("InventoryTlrncPriceRF", typeof(long));       // 過不足額
            dataTable.Columns.Add("StockDivRF", typeof(Int32));                 //  在庫区分
        }

        /// <summary>
        /// 検索結果をConvertToDataTable
        /// </summary>
        /// <param name="inventoryList">検索条件</param>
        /// <param name="dataTable">結果</param>
        /// <remarks>
        /// <br>Note       : 検索結果をConvertToDataTableに行う。</br>
        /// <br>Programmer : 朱宝軍</br>
        /// <br>Date       : 2009.05.12</br>
        /// </remarks>
        private void ConverToDataSetCustomerInf(ArrayList inventoryList, ref DataTable dataTable)
        {
            foreach (ArrayList retArray in inventoryList)
            {
                foreach (InventoryDataUpdateWork retWork in retArray)
                {
                    DataRow dataRow = dataTable.NewRow();
                    dataRow["InventorySeqNoRF"] = retWork.InventorySeqNo;
                    dataRow["WarehouseCodeRF"] = AppendStrZero(retWork.WarehouseCode, 4);
                    dataRow["GoodsNoRF"] = GetSubString(retWork.GoodsNo, 24);
                    dataRow["GoodsMakerCdRF"] = AppendZero(retWork.GoodsMakerCd.ToString(), 4);

                    dataRow["SectionCodeRF"] = AppendStrZero(retWork.SectionCode, 2);
                    dataRow["SupplierCdRF"] = AppendZero(retWork.SupplierCd.ToString(), 6);

                    dataRow["GoodsLGroupRF"] = AppendZero(retWork.GoodsLGroup.ToString(), 4);
                    dataRow["GoodsMGroupRF"] = AppendZero(retWork.GoodsMGroup.ToString(), 4);
                    dataRow["BLGroupCodeRF"] = AppendZero(retWork.BLGroupCode.ToString(), 5);

                    dataRow["BLGoodsCodeRF"] = AppendZero(retWork.BLGoodsCode.ToString(), 5);

                    if (retWork.InventoryDay == DateTime.MinValue)
                    {
                        dataRow["InventoryDayRF"] = string.Empty;
                    }
                    else
                    {
                        dataRow["InventoryDayRF"] = TDateTime.DateTimeToLongDate("YYYYMMDD", retWork.InventoryDay).ToString();
                    }
                    if (retWork.InventoryDate == DateTime.MinValue)
                    {
                        dataRow["InventoryDateRF"] = string.Empty;
                    }
                    else
                    {
                        dataRow["InventoryDateRF"] = TDateTime.DateTimeToLongDate("YYYYMMDD", retWork.InventoryDate).ToString();
                    }
                    dataRow["InventoryStockCntRF"] = retWork.InventoryStockCnt.ToString("##0.00");
                    dataRow["WarehouseShelfNoRF"] = GetSubString(retWork.WarehouseShelfNo, 8);

                    dataRow["DuplicationShelfNo1RF"] = GetSubString(retWork.DuplicationShelfNo1, 8);
                    dataRow["DuplicationShelfNo2RF"] = GetSubString(retWork.DuplicationShelfNo2, 8);

                    dataRow["BfStockUnitPriceFlRF"] = retWork.BfStockUnitPriceFl.ToString("##0.00");
                    dataRow["StockTotalRF"] = retWork.StockTotal.ToString("##0.00");

                    dataRow["StockMashinePriceRF"] = retWork.StockMashinePrice;
                    dataRow["StockUnitPriceFlRF"] = retWork.StockUnitPriceFl.ToString("##0.00");
                    dataRow["InventoryStockPriceRF"] = retWork.InventoryStockPrice;

                    dataRow["InventoryTolerancCntRF"] = retWork.InventoryTolerancCnt.ToString("##0.00");
                    dataRow["InventoryTlrncPriceRF"] = retWork.InventoryTlrncPrice;
                    dataRow["StockDivRF"] = retWork.StockDiv;
                    dataTable.Rows.Add(dataRow);

                }
            }
        }

        /// <summary>
        /// AppendZero
        /// </summary>
        /// <param name="bfString">bfString</param>
        /// <param name="maxSize">桁</param>
        /// <remarks>
        /// <br>Note       : AppendZero行う。</br>
        /// <br>Programmer : 朱宝軍</br>
        /// <br>Date       : 2009.05.12</br>
        /// </remarks>
        private string AppendZero(string bfString, int maxSize)
        {
            bfString = bfString.Trim();

            StringBuilder tempBuild = new StringBuilder();
            if (bfString != "0")
            {
                if (!String.IsNullOrEmpty(bfString.Trim()) && !bfString.Trim().Equals("0"))
                {
                    for (int i = bfString.Length; i < maxSize; i++)
                    {
                        tempBuild.Append("0");
                    }
                    tempBuild.Append(bfString);
                }
            }
            else
            {
                tempBuild.Append("0");
            }
            return tempBuild.ToString().Trim();
        }

        /// <summary>
        /// GetSubString
        /// </summary>
        /// <param name="bfString">bfString</param>
        /// <param name="length">桁</param>
        /// <remarks>
        /// <br>Note       : 検索結果をConvertToDataSetに行う。</br>
        /// <br>Programmer : 朱宝軍</br>
        /// <br>Date       : 2009.05.12</br>
        /// </remarks>
        private string GetSubString(string bfString, int length)
        {
            string afString = "";
            if (bfString.Length > length)
            {
                afString = bfString.Substring(0, length);
            }
            else
            {
                afString = bfString;
            }
            return afString.Trim();
        }

        /// <summary>
        /// AppendZero
        /// </summary>
        /// <param name="bfString">bfString</param>
        /// <param name="maxSize">桁</param>
        /// <remarks>
        /// <br>Note       : AppendZero行う。</br>
        /// <br>Programmer : 朱宝軍</br>
        /// <br>Date       : 2009.05.12</br>
        /// </remarks>
        private string AppendStrZero(string bfString, int maxSize)
        {
            StringBuilder tempBuild = new StringBuilder();
            if (String.IsNullOrEmpty(bfString.Trim()) || bfString.Trim().Length == 0)
            {
                for (int i = 0; i < maxSize; i++)
                {
                    tempBuild.Append("0");
                }
            }
            else
            {
                for (int i = bfString.Length; i < maxSize; i++)
                {
                    tempBuild.Append("0");
                }
                tempBuild.Append(bfString);
            }
            return tempBuild.ToString().Trim();
        }
        #endregion
    }
}

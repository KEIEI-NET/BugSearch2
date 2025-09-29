//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 商品マスタ（エクスポート）
// プログラム概要   : 商品マスタ（エクスポート）を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 朱宝軍
// 作 成 日  2009/05/13  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 朱宝軍
// 作 成 日  2009/06/24  修正内容 : PVCS265 出力仕様の修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30517 夏野 駿希
// 作 成 日  2010/05/12  修正内容 : Mantis.15352　処理速度が遅い件の修正（新規リモート使用）
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 22008 長内 数馬
// 作 成 日  2011/05/17  修正内容 : 抽出時の提供区分での判定を削除
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;

using Broadleaf.Library.Globarization;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;

// 2010/05/12 Add >>>
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;
// 2010/05/12 Add <<<

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 商品マスタ（エクスポート）クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 商品マスタ（エクスポート）インスタンスの作成を行う。</br>
    /// <br>Programmer : 朱宝軍</br>
    /// <br>Date       : 2009.05.12</br>
    /// </remarks>
    public class GoodsExportAcs
    {
        #region ■ Private Member
        private const string PRINTSET_TABLE = "GoodsExp";
        private IGoodsExportDB _iGoodsExportDB = null;
        #endregion

        # region ■Constracter
        /// <summary>
        /// 商品マスタ（エクスポート）アクセスクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 商品マスタ（エクスポート）アクセスクラス。</br>
        /// <br>Programmer : 朱宝軍</br>
        /// <br>Date       : 2009.05.12</br>
        /// </remarks>
        public GoodsExportAcs()
        {
        }
        #endregion

        #region ■ 商品マスタ情報検索
        /// <summary>
        /// 商品マスタデータ取得処理
        /// </summary>
        /// <param name="condition">検索条件</param>
        /// <param name="dataTable">検索データ</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : 商品マスタデータ取得処理を行う。</br>
        /// <br>Programmer : 朱宝軍</br>
        /// <br>Date       : 2009.05.12</br>
        /// </remarks>
        // 2010/05/12 Del >>>
        #region [Del]
        //public int Search(GoodsExportWork condition, out DataTable dataTable)
        //{
        //    int status = 0;
        //    int checkStatus = 0;
        //    dataTable = new DataTable(PRINTSET_TABLE);
        //    CreateDataTable(ref dataTable);

        //    // ADD 2009/06/24 --->>>
        //    // 出力仕様の修正
        //    PriceChgSetAcs priceChgSetAcs = new PriceChgSetAcs();

        //    ArrayList priceChgSets = null;
        //    status = priceChgSetAcs.Search(
        //                    out priceChgSets,
        //                    condition.EnterpriseCode, PriceChgSetAcs.SearchMode.Remote);

        //    if (status == 0)
        //    {
        //        int priceMngCnt = 0;
        //        foreach (PriceChgSet prevPriceChgSet in priceChgSets)
        //        {
        //            priceMngCnt = prevPriceChgSet.PriceMngCnt;
        //        }
        //        // ADD 2009/06/24 ---<<<
        //        ConstantManagement.LogicalMode logicalMode = ConstantManagement.LogicalMode.GetData0;
        //        GoodsAcs goodsAcs = new GoodsAcs();
        //        GoodsCndtn goodsCndtn = new GoodsCndtn();
        //        goodsCndtn.EnterpriseCode = condition.EnterpriseCode;
        //        goodsCndtn.GoodsKindCode = 9;
        //        List<GoodsUnitData> al = new List<GoodsUnitData>();
        //        string msg = null;
        //        status = goodsAcs.Search(goodsCndtn, logicalMode, out al, out msg);

        //        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
        //        {
        //            foreach (GoodsUnitData goodsUnitData in al)
        //            {
        //                checkStatus = DataCheck(condition, goodsUnitData);
        //                if (checkStatus == 0)
        //                {
        //                    // MODIFY 2009/06/24 --->>>
        //                    // 出力仕様の修正
        //                    //ConverToDataSetCustomerInf(goodsUnitData, ref dataTable);
        //                    ConverToDataSetCustomerInf(goodsUnitData, ref dataTable, priceMngCnt);
        //                    // MODIFY 2009/06/24 ---<<<
        //                }
        //            }
        //        }
        //        // ADD 2009/06/24 --->>>
        //        // 出力仕様の修正
        //    }
        //    // ADD 2009/06/24 ---<<<
        //    if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND || status == (int)ConstantManagement.DB_Status.ctDB_EOF)
        //    {
        //        status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
        //    }

        //    return status;
        //}
        #endregion [Del]
        // 2010/05/12 Del <<<
        // 2010/05/12 Add >>>
        public int Search(GoodsExportWork condition, out DataTable dataTable)
        {
            int status = 0;
            int checkStatus = 0;
            dataTable = new DataTable(PRINTSET_TABLE);
            CreateDataTable(ref dataTable);

            if (_iGoodsExportDB == null)
                _iGoodsExportDB = (IGoodsExportDB)MediationGoodsExportDB.GetGoodsExportDB();
            try
            {
                GoodsExportParamWork goodsExportParamWork = new GoodsExportParamWork();
                object retReadList = null;

                // 抽出条件セット
                goodsExportParamWork.EnterpriseCode = condition.EnterpriseCode;

                if (condition.BLGoodsCodeSt > 0)
                    goodsExportParamWork.BLGoodsCodeSt = condition.BLGoodsCodeSt;
                if (condition.BLGoodsCodeEd > 0)
                    goodsExportParamWork.BLGoodsCodeEd = condition.BLGoodsCodeEd;
                else
                    goodsExportParamWork.BLGoodsCodeEd = 99999;

                if (condition.GoodsMakerCdSt > 0)
                    goodsExportParamWork.GoodsMakerCdSt = condition.GoodsMakerCdSt;
                if (condition.GoodsMakerCdEd > 0)
                    goodsExportParamWork.GoodsMakerCdEd = condition.GoodsMakerCdEd;
                else
                    goodsExportParamWork.GoodsMakerCdEd = 9999;

                if (!string.IsNullOrEmpty(condition.GoodsNoSt))
                    goodsExportParamWork.GoodsNoSt = condition.GoodsNoSt;
                if (!string.IsNullOrEmpty(condition.GoodsNoEd))
                    goodsExportParamWork.GoodsNoEd = condition.GoodsNoEd;

                status = _iGoodsExportDB.Search(out retReadList, goodsExportParamWork, ConstantManagement.LogicalMode.GetData0);

                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        // データ展開処理
                        ArrayList retArrayList = new ArrayList();
                        retArrayList = (ArrayList)retReadList;
                        List<GoodsExportResultWork> goodsUnitDataList = new List<GoodsExportResultWork>();
                        string workGoodsNo = string.Empty;
                        int workMakerCode = 0;
                        foreach (GoodsExportResultWork goodsUnitData in retArrayList)
                        {
                            if (goodsUnitData.GoodsNo != workGoodsNo || goodsUnitData.GoodsMakerCd != workMakerCode)
                            {
                                if (goodsUnitDataList.Count > 0)
                                {
                                    // データテーブルに追加処理
                                    ConverToDataSetCustomerInf(goodsUnitDataList, ref dataTable);
                                }
                                goodsUnitDataList.Clear();
                                workGoodsNo = goodsUnitData.GoodsNo;
                                workMakerCode = goodsUnitData.GoodsMakerCd;
                            }
                            checkStatus = DataCheck(condition, goodsUnitData);
                            if (checkStatus == 0)
                            {
                                goodsUnitDataList.Add(goodsUnitData);
                            }
                        }
                        if (goodsUnitDataList.Count > 0)
                        {
                            // データテーブルに追加処理
                            ConverToDataSetCustomerInf(goodsUnitDataList, ref dataTable);
                        }
                        if (dataTable.Rows.Count == 0)
                        {
                            status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                        }
                        else
                        {
                            status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                        }
                        break;
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                        break;
                    default:
                        break;
                }
            }
            catch
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }
            finally
            {
                
            }
            return status;
        }
        // 2010/05/12 Add <<<
        #endregion

        #region ■ Private Methods
        /// <summary>
        /// 抽出処理
        /// </summary>
        /// <param name="condition">検索条件</param>
        /// <param name="goodsUnitData">商品データ</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 抽出処理を行う。</br>
        /// <br>Programmer : 朱宝軍</br>
        /// <br>Date       : 2009.04.01</br>
        /// </remarks>
        // 2010/05/12 >>>
        //private int DataCheck(GoodsExportWork condition, GoodsUnitData goodsUnitData)
        private int DataCheck(GoodsExportWork condition, GoodsExportResultWork goodsUnitData)
        // 2010/05/12 <<<
        {
            int status = 0;

            // -- DEL 2011/05/17 -------------------->>>
            //if (goodsUnitData.OfferDataDiv != 0)
            //{
            //    status = -1;
            //    return status;
            //}
            // -- DEL 2011/05/17 --------------------<<<

            // 2010/05/12 Del >>>
            #region [Del]
            //if (!String.IsNullOrEmpty(condition.GoodsNoSt.Trim()) && !String.IsNullOrEmpty(goodsUnitData.GoodsNo.Trim())
            //    && condition.GoodsNoSt.Trim().CompareTo(goodsUnitData.GoodsNo.Trim()) == 1)
            //{
            //    status = -1;
            //    return status;
            //}

            //if (!String.IsNullOrEmpty(condition.GoodsNoEd.Trim()) && !String.IsNullOrEmpty(goodsUnitData.GoodsNo.Trim())
            //    && condition.GoodsNoEd.Trim().CompareTo(goodsUnitData.GoodsNo.Trim()) == -1)
            //{
            //    status = -1;
            //    return status;
            //}

            //if (condition.GoodsMakerCdSt != 0 && goodsUnitData.GoodsMakerCd < condition.GoodsMakerCdSt)
            //{
            //    status = -1;
            //    return status;
            //}
            //if (condition.GoodsMakerCdEd != 0 && goodsUnitData.GoodsMakerCd > condition.GoodsMakerCdEd)
            //{
            //    status = -1;
            //    return status;
            //}

            //if (condition.BLGoodsCodeSt != 0 && goodsUnitData.BLGoodsCode < condition.BLGoodsCodeSt)
            //{
            //    status = -1;
            //    return status;
            //}
            //if (condition.BLGoodsCodeEd != 0 && goodsUnitData.BLGoodsCode > condition.BLGoodsCodeEd)
            //{
            //    status = -1;
            //    return status;
            //}
            #endregion [Del]
            // 2010/05/12 Del <<<

            return status;

        }

        /// <summary>
        /// 検索結果をConvertToDataTable
        /// </summary>
        /// <param name="goodsUnitDataList">検索条件</param>
        /// <param name="dataTable">結果</param>
        /// <remarks>
        /// <br>Note       : 検索結果をConvertToDataTableに行う。</br>
        /// <br>Programmer : 朱宝軍</br>
        /// <br>Date       : 2009.05.12</br>
        /// </remarks>
        // MODIFY 2009/06/24 --->>>
        // 出力仕様の修正
        //private void ConverToDataSetCustomerInf(GoodsUnitData goodsUnitData, ref DataTable dataTable)
        // 2010/05/12 >>>
        //private void ConverToDataSetCustomerInf(GoodsUnitData goodsUnitData, ref DataTable dataTable, int priceMngCnt)
        private void ConverToDataSetCustomerInf(List<GoodsExportResultWork> goodsUnitDataList, ref DataTable dataTable)
        // 2010/05/12 <<<
        // MODIFY 2009/06/24 ---<<<
        {
            DataRow dataRow = dataTable.NewRow();
            // 2010/05/12 Add >>>
            GoodsExportResultWork goodsUnitData = new GoodsExportResultWork();
            goodsUnitData = goodsUnitDataList[0];
            // 2010/05/12 Add <<<
            dataRow["GoodsNoRF"] = GetSubString(goodsUnitData.GoodsNo, 24);
            dataRow["GoodsMakerCdRF"] = AppendZero(goodsUnitData.GoodsMakerCd.ToString(), 4);
            dataRow["GoodsNameRF"] = GetSubString(goodsUnitData.GoodsName, 40);
            dataRow["GoodsNameKanaRF"] = GetSubString(goodsUnitData.GoodsNameKana, 40);
            dataRow["JanRF"] = goodsUnitData.Jan;
            dataRow["BLGoodsCodeRF"] = AppendZero(goodsUnitData.BLGoodsCode.ToString(), 5);
            dataRow["EnterpriseGanreCodeRF"] = AppendZero(goodsUnitData.EnterpriseGanreCode.ToString(), 4);
            dataRow["GoodsRateRankRF"] = GetSubString(goodsUnitData.GoodsRateRank, 2);
            dataRow["GoodsKindCodeRF"] = goodsUnitData.GoodsKindCode;
            dataRow["TaxationDivCdRF"] = goodsUnitData.TaxationDivCd;
            dataRow["GoodsNote1RF"] = GetSubString(goodsUnitData.GoodsNote1, 40);
            dataRow["GoodsNote2RF"] = GetSubString(goodsUnitData.GoodsNote2, 40);
            dataRow["GoodsSpecialNoteRF"] = GetSubString(goodsUnitData.GoodsSpecialNote, 40);
            int index = 0;
            // 2010/05/12 Add >>>
            int priceMngCnt = goodsUnitDataList.Count;
            int startIndex = 0;
            // 2010/05/12 Add <<<
            // 2010/05/12 Del >>>
            //if (goodsUnitData.GoodsPriceList.Count > 0)
            //{
            // 2010/05/12 Del <<<
            // 2010/05/12 >>>
            //foreach (GoodsPrice goodsPrice in goodsUnitData.GoodsPriceList)
            foreach (GoodsExportResultWork goodsPrice in goodsUnitDataList)
            // 2010/05/12 <<<
            {
                // ADD 2009/06/24 --->>>
                // 出力仕様の修正
                if (index == priceMngCnt)
                {
                    break;
                }
                else
                {
                    // ADD 2009/06/24 ---<<<
                    if (index == 0)
                    {
                        if (goodsPrice.PriceStartDate == DateTime.MinValue)
                        {
                            // MODIFY 2009/06/24 --->>>
                            // 出力仕様の修正
                            //dataRow["PriceStartDateRF1"] = DBNull.Value;
                            dataRow["PriceStartDateRF1"] = 0;
                            // MODIFY 2009/06/24 ---<<<
                        }
                        else
                        {
                            dataRow["PriceStartDateRF1"] = TDateTime.DateTimeToLongDate("YYYYMMDD", goodsPrice.PriceStartDate);
                            startIndex++;   // 2010/05/12 Add
                        }
                        dataRow["ListPriceRF1"] = goodsPrice.ListPrice;
                        dataRow["OpenPriceDivRF1"] = goodsPrice.OpenPriceDiv;
                        dataRow["StockRateRF1"] = goodsPrice.StockRate.ToString("##0.00");
                        dataRow["SalesUnitCostRF1"] = goodsPrice.SalesUnitCost.ToString("##0.00");
                    }
                    else if (index == 1)
                    {
                        if (goodsPrice.PriceStartDate == DateTime.MinValue)
                        {
                            // MODIFY 2009/06/24 --->>>
                            // 出力仕様の修正
                            //dataRow["PriceStartDateRF2"] = DBNull.Value;
                            dataRow["PriceStartDateRF2"] = 0;
                            // MODIFY 2009/06/24 ---<<<
                        }
                        else
                        {
                            dataRow["PriceStartDateRF2"] = TDateTime.DateTimeToLongDate("YYYYMMDD", goodsPrice.PriceStartDate);
                            startIndex++;   // 2010/05/12 Add
                        }
                        dataRow["ListPriceRF2"] = goodsPrice.ListPrice;
                        dataRow["OpenPriceDivRF2"] = goodsPrice.OpenPriceDiv;
                        dataRow["StockRateRF2"] = goodsPrice.StockRate.ToString("##0.00");
                        dataRow["SalesUnitCostRF2"] = goodsPrice.SalesUnitCost.ToString("##0.00");
                    }
                    else if (index == 2)
                    {
                        if (goodsPrice.PriceStartDate == DateTime.MinValue)
                        {
                            // MODIFY 2009/06/24 --->>>
                            // 出力仕様の修正
                            //dataRow["PriceStartDateRF3"] = DBNull.Value;
                            dataRow["PriceStartDateRF3"] = 0;
                            // MODIFY 2009/06/24 ---<<<
                        }
                        else
                        {
                            dataRow["PriceStartDateRF3"] = TDateTime.DateTimeToLongDate("YYYYMMDD", goodsPrice.PriceStartDate);
                            startIndex++;   // 2010/05/12 Add
                        }
                        dataRow["ListPriceRF3"] = goodsPrice.ListPrice;
                        dataRow["OpenPriceDivRF3"] = goodsPrice.OpenPriceDiv;
                        dataRow["StockRateRF3"] = goodsPrice.StockRate.ToString("##0.00");
                        dataRow["SalesUnitCostRF3"] = goodsPrice.SalesUnitCost.ToString("##0.00");
                    }
                    // ADD 2009/06/24 --->>>
                    // 出力仕様の修正
                    else if (index == 3)
                    {
                        if (goodsPrice.PriceStartDate == DateTime.MinValue)
                        {
                            dataRow["PriceStartDateRF4"] = 0;
                        }
                        else
                        {
                            dataRow["PriceStartDateRF4"] = TDateTime.DateTimeToLongDate("YYYYMMDD", goodsPrice.PriceStartDate);
                            startIndex++;   // 2010/05/12 Add
                        }
                        dataRow["ListPriceRF4"] = goodsPrice.ListPrice;
                        dataRow["OpenPriceDivRF4"] = goodsPrice.OpenPriceDiv;
                        dataRow["StockRateRF4"] = goodsPrice.StockRate.ToString("##0.00");
                        dataRow["SalesUnitCostRF4"] = goodsPrice.SalesUnitCost.ToString("##0.00");
                    }
                    else if (index == 4)
                    {
                        if (goodsPrice.PriceStartDate == DateTime.MinValue)
                        {
                            dataRow["PriceStartDateRF5"] = 0;
                        }
                        else
                        {
                            dataRow["PriceStartDateRF5"] = TDateTime.DateTimeToLongDate("YYYYMMDD", goodsPrice.PriceStartDate);
                            startIndex++;   // 2010/05/12 Add
                        }
                        dataRow["ListPriceRF5"] = goodsPrice.ListPrice;
                        dataRow["OpenPriceDivRF5"] = goodsPrice.OpenPriceDiv;
                        dataRow["StockRateRF5"] = goodsPrice.StockRate.ToString("##0.00");
                        dataRow["SalesUnitCostRF5"] = goodsPrice.SalesUnitCost.ToString("##0.00");
                    }
                    // ADD 2009/06/24 ---<<<
                }
                index++;
            }
            //}   // 2010/05/12 Del

            // ADD 2009/06/24 --->>>
            // 出力仕様の修正
            string PriceStartDateRF = "";
            string ListPriceRF = "";
            string OpenPriceDivRF = "";
            string StockRateRF = "";
            string SalesUnitCostRF = "";
            // 2010/05/12 Del >>>
            //int startIndex = 0;
            //if (goodsUnitData.GoodsPriceList.Count > priceMngCnt)
            //{
            //    startIndex = priceMngCnt;
            //}
            //else
            //{
            //    startIndex = goodsUnitData.GoodsPriceList.Count;
            //}
            // 2010/05/12 Del <<<
            for (int i = startIndex; i < 5; i++)
            {
                PriceStartDateRF = "PriceStartDateRF";
                ListPriceRF = "ListPriceRF";
                OpenPriceDivRF = "OpenPriceDivRF";
                StockRateRF = "StockRateRF";
                SalesUnitCostRF = "SalesUnitCostRF";

                PriceStartDateRF += (i + 1);
                ListPriceRF += (i + 1);
                OpenPriceDivRF += (i + 1);
                StockRateRF += (i + 1);
                SalesUnitCostRF += (i + 1);

                dataRow[PriceStartDateRF] = 0;
                dataRow[ListPriceRF] = 0;
                dataRow[OpenPriceDivRF] = 0;
                dataRow[StockRateRF] = "0.00";
                dataRow[SalesUnitCostRF] = "0.00";
            }
            // ADD 2009/06/24 ---<<<
            dataTable.Rows.Add(dataRow);
        }

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
            dataTable.Columns.Add("GoodsNoRF", typeof(string));                  //  商品番号
            dataTable.Columns.Add("GoodsMakerCdRF", typeof(string));             //  商品メーカーコード
            dataTable.Columns.Add("GoodsNameRF", typeof(string));                //  商品名称
            dataTable.Columns.Add("GoodsNameKanaRF", typeof(string));            //  商品名称カナ
            dataTable.Columns.Add("JanRF", typeof(string));                      //  JANコード

            dataTable.Columns.Add("BLGoodsCodeRF", typeof(string));              //  BL商品コード
            dataTable.Columns.Add("EnterpriseGanreCodeRF", typeof(string));      // 自社分類コード
            dataTable.Columns.Add("GoodsRateRankRF", typeof(string));            //  商品掛率ランク
            dataTable.Columns.Add("GoodsKindCodeRF", typeof(Int32));            //  商品属性
            dataTable.Columns.Add("TaxationDivCdRF", typeof(Int32));            //  課税区分
            dataTable.Columns.Add("GoodsNote1RF", typeof(string));               //  商品備考１
            dataTable.Columns.Add("GoodsNote2RF", typeof(string));               //  商品備考２
            dataTable.Columns.Add("GoodsSpecialNoteRF", typeof(string));         //  商品規格・特記事項

            dataTable.Columns.Add("PriceStartDateRF1", typeof(Int32));           //  価格開始日１
            dataTable.Columns.Add("ListPriceRF1", typeof(Double));                //  定価（浮動）１
            dataTable.Columns.Add("OpenPriceDivRF1", typeof(Int32));             //  オープン価格区分１
            dataTable.Columns.Add("StockRateRF1", typeof(string));                //  仕入率１
            dataTable.Columns.Add("SalesUnitCostRF1", typeof(string));            //  原価単価１

            dataTable.Columns.Add("PriceStartDateRF2", typeof(Int32));           //  価格開始日２
            dataTable.Columns.Add("ListPriceRF2", typeof(Double));                //  定価（浮動）２
            dataTable.Columns.Add("OpenPriceDivRF2", typeof(Int32));             //  オープン価格区分２
            dataTable.Columns.Add("StockRateRF2", typeof(string));                //  仕入率２
            dataTable.Columns.Add("SalesUnitCostRF2", typeof(string));            //  原価単価２

            dataTable.Columns.Add("PriceStartDateRF3", typeof(Int32));           //  価格開始日３
            dataTable.Columns.Add("ListPriceRF3", typeof(Double));                //  定価（浮動）３
            dataTable.Columns.Add("OpenPriceDivRF3", typeof(Int32));             //  オープン価格区分３
            dataTable.Columns.Add("StockRateRF3", typeof(string));                //  仕入率３
            dataTable.Columns.Add("SalesUnitCostRF3", typeof(string));            //  原価単価３
            // ADD 2009/06/24 --->>>
            // 出力仕様の修正
            dataTable.Columns.Add("PriceStartDateRF4", typeof(Int32));           //  価格開始日４
            dataTable.Columns.Add("ListPriceRF4", typeof(Double));                //  定価（浮動）４
            dataTable.Columns.Add("OpenPriceDivRF4", typeof(Int32));             //  オープン価格区分４
            dataTable.Columns.Add("StockRateRF4", typeof(string));                //  仕入率４
            dataTable.Columns.Add("SalesUnitCostRF4", typeof(string));            //  原価単価４

            dataTable.Columns.Add("PriceStartDateRF5", typeof(Int32));           //  価格開始日５
            dataTable.Columns.Add("ListPriceRF5", typeof(Double));                //  定価（浮動）５
            dataTable.Columns.Add("OpenPriceDivRF5", typeof(Int32));             //  オープン価格区分５
            dataTable.Columns.Add("StockRateRF5", typeof(string));                //  仕入率５
            dataTable.Columns.Add("SalesUnitCostRF5", typeof(string));            //  原価単価５
            // ADD 2009/06/24 ---<<<
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
            bfString = bfString.Trim();
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

        #endregion
    }
}

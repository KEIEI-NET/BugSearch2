using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Globarization;
using Broadleaf.Application.Common; // ADD 2010/07/20

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 得意先過年度実績照会データ取得アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 得意先過年度実績照会のアクセスクラスです。</br>
    /// <br>Programmer : 30418 徳永</br>
    /// <br>Date       : 2008.11.18</br>
    /// <br>UpdateNote : 2010/07/20 姜凱</br>
    /// <br>                Excel、テキスト出力対応（６次改良追加依頼分）</br>
    /// <br>UpdateNote : 2010/08/02 chenyd</br>
    /// <br>                Excel、テキスト出力対応（６次改良追加依頼分）</br>
    /// <br>UpdateNote : 2010/10/13 yanmgj</br>
    /// <br>             テキスト出力対応</br>
    /// <br></br>
    /// </remarks>
    public partial class CustPastExperienceAcs
    {
        #region プライベート変数

        /// <summary>得意先過年度実績照会リモートクラス</summary>
        private ICustomInqOrderWorkDB _customInqOrderWorkDB = null;

        /// <summary>得意先過年度実績照会リモート検索条件ワーククラス</summary>
        private CustomInqOrderCndtnWork _customInqOrderCndtnWork = null;

        /// <summary>得意先過年度実績照会一覧データセット</summary>
        private CustomInqOrderDataSet _dataSet = null;

        /// <summary>得意先</summary>
        private CustomerSearchRet[] customerSearchRet;// ADD 2010/08/02

        /// <summary>会計年度（今年度）</summary>
        private int _fiscalYear = 0;

        #endregion // プライベート変数

        #region 定数

        /// <summary>会計年度列の基本単位</summary>
        private const string CT_FISCALYEAR_MEASURE = "年度";

        #endregion // 定数

        #region コンストラクタ

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public CustPastExperienceAcs()
        {
            // リモートDB取得
            _customInqOrderWorkDB = MediationCustomInqOrderWorkDB.GetCustomInqOrderWorkDB();

            // 検索条件クラス作成
            _customInqOrderCndtnWork = new CustomInqOrderCndtnWork();

            // データセット作成
            this._dataSet = new CustomInqOrderDataSet();

            // コンストラクタよりインスタンスを作成した時点で、データセットが有効になる

        }

        #endregion // コンストラクタ

        #region パブリックオブジェクト

        /// <summary>
        /// 得意先過年度実績照会一覧データセット
        /// </summary>
        public CustomInqOrderDataSet DataSet
        {
            get { return this._dataSet; }
            set { this._dataSet = value; }
        }

        /// <summary>
        /// 会計年度
        /// </summary>
        public int FiscalYear
        {
            get { return this._fiscalYear; }
            set { this._fiscalYear = value; }
        }

        #endregion // パブリックオブジェクト

        #region 検索実行

        /// <summary>
        /// 検索実行
        /// </summary>
        public int Search(CustomInqOrderCndtn customInqOrderCndtn)
        {
            // 検索条件クラスからリモート検索条件ワーククラスへコピー
            CopyParamater2RemoteParameterWork(customInqOrderCndtn);

            // 検索実行
            object result;
            int status = _customInqOrderWorkDB.Search(out result, (object)this._customInqOrderCndtnWork, 0, ConstantManagement.LogicalMode.GetData0);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // データセットへ読み込んだ情報をセット
                if (result is ArrayList)
                {
                    // 会計年度（今年度：フォームクラスからセットされる）
                    int fiscalYear = this._fiscalYear;

                    foreach (CustomInqResultWork resultWork in (ArrayList)result)
                    {
                        // --- CHG 2009/03/09 障害ID:11994対応------------------------------------------------------>>>>>
                        //AddRowData(resultWork, customInqOrderCndtn, fiscalYear - 1);
                        AddRowData(resultWork, customInqOrderCndtn, fiscalYear);
                        // --- CHG 2009/03/09 障害ID11994:対応------------------------------------------------------<<<<<
                        fiscalYear--;
                    }
                }
            }
            else
            {
                return status;
            }

            return status;
        }

        // ---------------------- ADD 2010/07/20 --------------------------------->>>>>
        /// <summary>
        /// 売上実績照会データを検索し、検索結果をデータテーブルにキャッシュします。
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="selectionCodeInt">選択項目コード（数値）</param>
        /// <param name="selectionCodeStr">選択項目コード（文字）</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>UpdateNote  : 2010/08/02 chenyd</br>
        /// <br>             ・Excel、テキスト出力対応</br>
        /// <br>UpdateNote  : 2010/09/14 高峰</br>
        /// <br>             ・readmine #14434の３対応</br>
        /// </remarks>
        public int SearchAll(string enterpriseCode, List<string[]> sectionCodeList, List<string[]> selectionCodeList)
        {

            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            CustomInqOrderCndtn customInqOrderCndtn = null;
            // ---------------------- ADD 2010/08/02 --------------------------------->>>>>
            // 会計年度情報取得
            int startDate;
            int endDate;
            int fiscalYear = 0;
            ArrayList CndtnWorkList = new ArrayList();
            // ---------------------- ADD 2010/08/02 ---------------------------------<<<<<
            // クリア処理
            this._dataSet.CustomInqResult.Clear();

            foreach (string[] sectionCode in sectionCodeList)
            {
                if (selectionCodeList.Count != 0)
                {
                    foreach (string[] selectionCode in selectionCodeList)
                    {
                        customInqOrderCndtn = new CustomInqOrderCndtn();

                        customInqOrderCndtn.EnterpriseCode = enterpriseCode;
                        customInqOrderCndtn.AddUpSecCode = sectionCode[0];
                        customInqOrderCndtn.AddUpSecName = sectionCode[1];
                        if (!String.IsNullOrEmpty(selectionCode[0]))
                        {
                            customInqOrderCndtn.CustomerCode = Int32.Parse(selectionCode[0]);
                            customInqOrderCndtn.CustomerName = selectionCode[1];
                        }
                        // ---------------------- DEL 2010/08/02 --------------------------------->>>>>
                        // 会計年度情報取得
                        //int startDate;
                        //int endDate;
                        //int fiscalYear;
                        // ---------------------- DEL 2010/08/02 ---------------------------------<<<<<
                        status = GetFinancialYearInfo(customInqOrderCndtn.AddUpSecCode, out fiscalYear, out startDate, out endDate);
                        if (status == 0)
                        {
                            customInqOrderCndtn.St_AddUpYearMonth = startDate;
                            customInqOrderCndtn.Ed_AddUpYearMonth = endDate;
                        }
                        if (CheckParameter(customInqOrderCndtn))
                        {
                            // 検索条件クラスからリモート検索条件ワーククラスへコピー
                            CustomInqOrderCndtnWork customInqOrderCndtnWork = this.CopyParamaterRemoteParameterWork(customInqOrderCndtn);

                            CndtnWorkList.Add(customInqOrderCndtnWork);

                            // ---------------------- DEL 2010/08/02 --------------------------------->>>>>
                            //object paraObj = (object)customInqOrderCndtnWork;
                            //object retObj;

                            //status = this._customInqOrderWorkDB.Search(out retObj, paraObj, 0, ConstantManagement.LogicalMode.GetData0);

                            //if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) || (status == (int)ConstantManagement.DB_Status.ctDB_EOF))
                            //{
                            //    // データセットへ読み込んだ情報をセット
                            //    if (retObj is ArrayList)
                            //    {
                            //        ArrayList resultList = (ArrayList)retObj;
                            //        int tempFiscalYear = fiscalYear;
                            //        this._fiscalYear = fiscalYear;

                            //        if (resultList.Count == 8)
                            //        {
                            //            DataRow row = this._dataSet.CustomInqResult.NewRow();
                            //            bool canAddFlg = false;
                            //            for (int index = 0; index < resultList.Count; index++)
                            //            {
                            //                CustomInqResultWork resultWork = (CustomInqResultWork)resultList[index];
                            //                AddOutputRowData(row, resultWork, customInqOrderCndtn, tempFiscalYear, index, ref canAddFlg);
                            //                tempFiscalYear--;
                            //            }
                            //            if (canAddFlg)
                            //                this._dataSet.CustomInqResult.Rows.Add(row);
                            //        }
                            //    }
                            //}
                            // ---------------------- DEL 2010/08/02 ---------------------------------<<<<<
                        }
                    }
                }
                else
                {

                    customInqOrderCndtn = new CustomInqOrderCndtn();

                    customInqOrderCndtn.EnterpriseCode = enterpriseCode;
                    customInqOrderCndtn.AddUpSecCode = sectionCode[0];
                    customInqOrderCndtn.AddUpSecName = sectionCode[1];
                    customInqOrderCndtn.CustomerCode = 0;
                    // ---------------------- DEL 2010/08/02 --------------------------------->>>>>
                    // 会計年度情報取得
                    //int startDate;
                    //int endDate;
                    //int fiscalYear;
                    // ---------------------- DEL 2010/08/02 ---------------------------------<<<<<
                    status = GetFinancialYearInfo(customInqOrderCndtn.AddUpSecCode, out fiscalYear, out startDate, out endDate);
                    if (status == 0)
                    {
                        customInqOrderCndtn.St_AddUpYearMonth = startDate;
                        customInqOrderCndtn.Ed_AddUpYearMonth = endDate;
                    }
                    if (CheckParameter(customInqOrderCndtn))
                    {

                        CustomInqOrderCndtnWork customInqOrderCndtnWork = this.CopyParamaterRemoteParameterWork(customInqOrderCndtn);

                        CndtnWorkList.Add(customInqOrderCndtnWork);
                        // ---------------------- DEL 2010/08/02 --------------------------------->>>>>
                        //object paraObj = (object)customInqOrderCndtnWork;
                        //object retObj;

                        //status = this._customInqOrderWorkDB.Search(out retObj, paraObj, 0, ConstantManagement.LogicalMode.GetData0);

                        //if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) || (status == (int)ConstantManagement.DB_Status.ctDB_EOF))
                        //{
                        //    // データセットへ読み込んだ情報をセット
                        //    if (retObj is ArrayList)
                        //    {
                        //        ArrayList resultList = (ArrayList)retObj;
                        //        int tempFiscalYear = fiscalYear;

                        //        if (resultList.Count == 8)
                        //        {
                        //            DataRow row = this._dataSet.CustomInqResult.NewRow();
                        //            bool canAddFlg = false;
                        //            for (int index = 0; index < resultList.Count; index++)
                        //            {
                        //                CustomInqResultWork resultWork = (CustomInqResultWork)resultList[index];
                        //                AddOutputRowData(row, resultWork, customInqOrderCndtn, tempFiscalYear, index, ref canAddFlg);
                        //                tempFiscalYear--;
                        //            }
                        //            if (canAddFlg)
                        //                this._dataSet.CustomInqResult.Rows.Add(row);
                        //        }
                        //    }
                        //}
                        // ---------------------- DEL 2010/08/02 --------------------------------->>>>>
                    }
                }
            }
            // ---------------------- DEL 2010/08/02 --------------------------------->>>>>
            // 得意先
            CustomerSearchPara customerSearchPara = new CustomerSearchPara();
            CustomerSearchAcs customerSearchAcs = new CustomerSearchAcs();
            customerSearchPara.EnterpriseCode = enterpriseCode;
            customerSearchAcs.Serch(out customerSearchRet, customerSearchPara);

            object paraObj = (object)CndtnWorkList;
            object retObj;

            status = this._customInqOrderWorkDB.SearchAll(out retObj, paraObj, 0, ConstantManagement.LogicalMode.GetData0);

            if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) || (status == (int)ConstantManagement.DB_Status.ctDB_EOF))
            {
                // データセットへ読み込んだ情報をセット
                if (retObj is ArrayList)
                {
                    ArrayList resultList = (ArrayList)retObj;
                    foreach (ArrayList array in resultList)
                    {
                        int tempFiscalYear = fiscalYear;
                        this._fiscalYear = fiscalYear;

                        if (array.Count == 8)
                        {
                            DataRow row = this._dataSet.CustomInqResult.NewRow();
                            bool canAddFlg = false;
                            for (int index = 0; index < array.Count; index++)
                            {
                                CustomInqResultWork resultWork = (CustomInqResultWork)array[index];
                                AddOutputRowData(row, resultWork, customInqOrderCndtn, tempFiscalYear, index, ref canAddFlg);
                                tempFiscalYear--;
                            }
                            // --- ADD 2010/09/14 ---------->>>>>
                            canAddFlg = canAddFlg
                                    && ((Int64)row[this._dataSet.CustomInqResult.NetSales1Column.ColumnName] != 0
                                    || (Int64)row[this._dataSet.CustomInqResult.GrossProfit1Column.ColumnName] != 0
                                    || (Int64)row[this._dataSet.CustomInqResult.NetSales2Column.ColumnName] != 0
                                    || (Int64)row[this._dataSet.CustomInqResult.GrossProfit2Column.ColumnName] != 0
                                    || (Int64)row[this._dataSet.CustomInqResult.NetSales3Column.ColumnName] != 0
                                    || (Int64)row[this._dataSet.CustomInqResult.GrossProfit3Column.ColumnName] != 0
                                    || (Int64)row[this._dataSet.CustomInqResult.NetSales4Column.ColumnName] != 0
                                    || (Int64)row[this._dataSet.CustomInqResult.GrossProfit4Column.ColumnName] != 0
                                    || (Int64)row[this._dataSet.CustomInqResult.NetSales5Column.ColumnName] != 0
                                    || (Int64)row[this._dataSet.CustomInqResult.GrossProfit5Column.ColumnName] != 0
                                    || (Int64)row[this._dataSet.CustomInqResult.NetSales6Column.ColumnName] != 0
                                    || (Int64)row[this._dataSet.CustomInqResult.GrossProfit6Column.ColumnName] != 0
                                    || (Int64)row[this._dataSet.CustomInqResult.NetSales7Column.ColumnName] != 0
                                    || (Int64)row[this._dataSet.CustomInqResult.GrossProfit7Column.ColumnName] != 0
                                    || (Int64)row[this._dataSet.CustomInqResult.NetSales8Column.ColumnName] != 0
                                    || (Int64)row[this._dataSet.CustomInqResult.GrossProfit8Column.ColumnName] != 0);
                            // --- ADD 2010/09/14 ----------<<<<<
                            if (canAddFlg)
                                this._dataSet.CustomInqResult.Rows.Add(row);
                        }
                    }
                }
            }
            // ---------------------- ADD 2010/08/02 ---------------------------------<<<<<
            return status;
        }
        // ---------------------- ADD 2010/07/20 -----------------------------------<<<<<
        #endregion // 検索実行

        #region データセット結果コピー

        /// <summary>
        /// リモート検索条件ワーククラスを元にデータセットに行を作成
        /// </summary>
        /// <param name="customInqOrderCndtnWork">検索結果ワーク</param>
        /// <param name="fiscalYear">会計年度</param>
        private void AddRowData(CustomInqResultWork customInqResultWork, CustomInqOrderCndtn customInqOrderCndtn, int fiscalYear)
        {
            DataRow row = this._dataSet.CustomInqResult.NewRow();

            row[this._dataSet.CustomInqResult.FiscalYearColumn.ColumnName] = fiscalYear;
            row[this._dataSet.CustomInqResult.FiscalYearStringColumn.ColumnName] = fiscalYear.ToString() + CT_FISCALYEAR_MEASURE;
            row[this._dataSet.CustomInqResult.EnterpriseCodeColumn.ColumnName] = customInqResultWork.EnterpriseCode;
            row[this._dataSet.CustomInqResult.AddUpSecCodeColumn.ColumnName] = customInqResultWork.AddUpSecCode;
            row[this._dataSet.CustomInqResult.AddUpSecNameColumn.ColumnName] = customInqOrderCndtn.AddUpSecName;
            row[this._dataSet.CustomInqResult.CustomerCodeColumn.ColumnName] = customInqResultWork.CustomerCode;
            row[this._dataSet.CustomInqResult.SalesMoneyColumn.ColumnName] = customInqResultWork.SalesMoney;
            row[this._dataSet.CustomInqResult.SalesRetGoodsPriceColumn.ColumnName] = customInqResultWork.SalesRetGoodsPrice;
            row[this._dataSet.CustomInqResult.DiscountPriceColumn.ColumnName] = customInqResultWork.DiscountPrice;
            row[this._dataSet.CustomInqResult.GrossProfitColumn.ColumnName] = customInqResultWork.GrossProfit;
            row[this._dataSet.CustomInqResult.NetSalesColumn.ColumnName] = customInqResultWork.SalesMoney +
                                                                           customInqResultWork.SalesRetGoodsPrice +
                                                                           customInqResultWork.DiscountPrice;

            this._dataSet.CustomInqResult.Rows.Add(row);

        }

        // ---------------------- ADD 2010/07/20 --------------------------------->>>>>
        /// <summary>
        /// リモート検索条件ワーククラスを元にデータセットに行を作成
        /// </summary>
        /// <param name="row">Row</param>
        /// <param name="customInqOrderCndtnWork">検索結果ワーク</param>
        /// <param name="customInqOrderCndtn">得意先過年度実績照会抽出条件クラス</param>
        /// <param name="fiscalYear">会計年度</param>
        /// <param name="index">Index</param>
        /// <param name="retFlg">AddFlag</param>
        /// <remarks>
        /// <br>UpdateNote  : 2010/08/02 chenyd</br>
        /// <br>             ・Excel、テキスト出力対応</br>
        /// <br>UpdateNote  : 2010/09/09 tianjw</br>
        /// <br>             ・readmine #14434対応</br>
        /// </remarks>
        private void AddOutputRowData(DataRow row, CustomInqResultWork customInqResultWork, CustomInqOrderCndtn customInqOrderCndtn, int fiscalYear, int index, ref bool retFlg)
        {
            if (!string.Empty.Equals(customInqResultWork.EnterpriseCode))
                retFlg = true;

            if (index == 0)
            {
                row[this._dataSet.CustomInqResult.FiscalYearColumn.ColumnName] = fiscalYear;
                row[this._dataSet.CustomInqResult.EnterpriseCodeColumn.ColumnName] = customInqOrderCndtn.EnterpriseCode;
                // ---------------------- DEL 2010/08/02 --------------------------------->>>>>
                //row[this._dataSet.CustomInqResult.AddUpSecCodeColumn.ColumnName] = customInqOrderCndtn.AddUpSecCode;
                //row[this._dataSet.CustomInqResult.AddUpSecNameColumn.ColumnName] = customInqOrderCndtn.AddUpSecName;
                //row[this._dataSet.CustomInqResult.CustomerCodeColumn.ColumnName] = customInqOrderCndtn.CustomerCode.ToString().PadLeft(8, '0');
                //row[this._dataSet.CustomInqResult.CustomerNameColumn.ColumnName] = customInqOrderCndtn.CustomerName;
                // ---------------------- DEL 2010/08/02 ---------------------------------<<<<<
                // ---------------------- ADD 2010/08/02 --------------------------------->>>>>
                if (customInqResultWork.CustomerCode != 0)
                {
                    //row[this._dataSet.CustomInqResult.AddUpSecCodeColumn.ColumnName] = customInqResultWork.AddUpSecCode; // DEL 2010/09/09
                    row[this._dataSet.CustomInqResult.AddUpSecCodeColumn.ColumnName] = customInqResultWork.AddUpSecCode.Trim(); // ADD 2010/09/09
                    row[this._dataSet.CustomInqResult.CustomerCodeColumn.ColumnName] = customInqResultWork.CustomerCode.ToString().PadLeft(8, '0');
                    foreach (CustomerSearchRet ret in customerSearchRet)
                    {
                        if (ret.CustomerCode == customInqResultWork.CustomerCode)
                        {
                            //----- UPD 2010/10/13 ----->>>>>
                            //row[this._dataSet.CustomInqResult.CustomerNameColumn.ColumnName] = ret.Name;
                            row[this._dataSet.CustomInqResult.CustomerNameColumn.ColumnName] = ret.Snm;
                            //----- UPD 2010/10/13 -----<<<<<
                            break;
                        }
                    }
                }
                // ---------------------- ADD 2010/08/02 ---------------------------------<<<<<
                row[this._dataSet.CustomInqResult.NetSales8Column.ColumnName] = customInqResultWork.SalesMoney +
                                                                               customInqResultWork.SalesRetGoodsPrice +
                                                                               customInqResultWork.DiscountPrice;
                row[this._dataSet.CustomInqResult.GrossProfit8Column.ColumnName] = customInqResultWork.GrossProfit;
            }
            else if (index == 1)
            {
                // ---------------------- ADD 2010/08/02 --------------------------------->>>>>
                if (customInqResultWork.CustomerCode != 0)
                {
                    //row[this._dataSet.CustomInqResult.AddUpSecCodeColumn.ColumnName] = customInqResultWork.AddUpSecCode; // DEL 2010/09/09
                    row[this._dataSet.CustomInqResult.AddUpSecCodeColumn.ColumnName] = customInqResultWork.AddUpSecCode.Trim(); // ADD 2010/09/09
                    row[this._dataSet.CustomInqResult.CustomerCodeColumn.ColumnName] = customInqResultWork.CustomerCode.ToString().PadLeft(8, '0');
                    foreach (CustomerSearchRet ret in customerSearchRet)
                    {
                        if (ret.CustomerCode == customInqResultWork.CustomerCode)
                        {
                            //----- UPD 2010/10/13 ----->>>>>
                            //row[this._dataSet.CustomInqResult.CustomerNameColumn.ColumnName] = ret.Name;
                            row[this._dataSet.CustomInqResult.CustomerNameColumn.ColumnName] = ret.Snm;
                            //----- UPD 2010/10/13 -----<<<<<

                            break;

                        }
                    }
                }
                // ---------------------- ADD 2010/08/02 ---------------------------------<<<<<
                row[this._dataSet.CustomInqResult.NetSales7Column.ColumnName] = customInqResultWork.SalesMoney +
                                                                               customInqResultWork.SalesRetGoodsPrice +
                                                                               customInqResultWork.DiscountPrice;
                row[this._dataSet.CustomInqResult.GrossProfit7Column.ColumnName] = customInqResultWork.GrossProfit;
            }
            else if (index == 2)
            {
                // ---------------------- ADD 2010/08/02 --------------------------------->>>>>
                if (customInqResultWork.CustomerCode != 0)
                {
                    //row[this._dataSet.CustomInqResult.AddUpSecCodeColumn.ColumnName] = customInqResultWork.AddUpSecCode; // DEL 2010/09/09
                    row[this._dataSet.CustomInqResult.AddUpSecCodeColumn.ColumnName] = customInqResultWork.AddUpSecCode.Trim(); // ADD 2010/09/09
                    row[this._dataSet.CustomInqResult.CustomerCodeColumn.ColumnName] = customInqResultWork.CustomerCode.ToString().PadLeft(8, '0');
                    foreach (CustomerSearchRet ret in customerSearchRet)
                    {
                        if (ret.CustomerCode == customInqResultWork.CustomerCode)
                        {
                            //----- UPD 2010/10/13 ----->>>>>
                            //row[this._dataSet.CustomInqResult.CustomerNameColumn.ColumnName] = ret.Name;
                            row[this._dataSet.CustomInqResult.CustomerNameColumn.ColumnName] = ret.Snm;
                            //----- UPD 2010/10/13 -----<<<<<
                            break;

                        }
                    }
                }
                // ---------------------- ADD 2010/08/02 ---------------------------------<<<<<
                row[this._dataSet.CustomInqResult.NetSales6Column.ColumnName] = customInqResultWork.SalesMoney +
                                                                               customInqResultWork.SalesRetGoodsPrice +
                                                                               customInqResultWork.DiscountPrice;
                row[this._dataSet.CustomInqResult.GrossProfit6Column.ColumnName] = customInqResultWork.GrossProfit;
            }
            else if (index == 3)
            {
                // ---------------------- ADD 2010/08/02 --------------------------------->>>>>
                if (customInqResultWork.CustomerCode != 0)
                {
                    //row[this._dataSet.CustomInqResult.AddUpSecCodeColumn.ColumnName] = customInqResultWork.AddUpSecCode; // DEL 2010/09/09
                    row[this._dataSet.CustomInqResult.AddUpSecCodeColumn.ColumnName] = customInqResultWork.AddUpSecCode.Trim(); // ADD 2010/09/09
                    row[this._dataSet.CustomInqResult.CustomerCodeColumn.ColumnName] = customInqResultWork.CustomerCode.ToString().PadLeft(8, '0');
                    foreach (CustomerSearchRet ret in customerSearchRet)
                    {
                        if (ret.CustomerCode == customInqResultWork.CustomerCode)
                        {
                            //----- UPD 2010/10/13 ----->>>>>
                            //row[this._dataSet.CustomInqResult.CustomerNameColumn.ColumnName] = ret.Name;
                            row[this._dataSet.CustomInqResult.CustomerNameColumn.ColumnName] = ret.Snm;
                            //----- UPD 2010/10/13 -----<<<<<
                            break;

                        }
                    }
                }
                // ---------------------- ADD 2010/08/02 ---------------------------------<<<<<
                row[this._dataSet.CustomInqResult.NetSales5Column.ColumnName] = customInqResultWork.SalesMoney +
                                                                               customInqResultWork.SalesRetGoodsPrice +
                                                                               customInqResultWork.DiscountPrice;
                row[this._dataSet.CustomInqResult.GrossProfit5Column.ColumnName] = customInqResultWork.GrossProfit;
            }
            else if (index == 4)
            {
                // ---------------------- ADD 2010/08/02 --------------------------------->>>>>
                if (customInqResultWork.CustomerCode != 0)
                {
                    //row[this._dataSet.CustomInqResult.AddUpSecCodeColumn.ColumnName] = customInqResultWork.AddUpSecCode; // DEL 2010/09/09
                    row[this._dataSet.CustomInqResult.AddUpSecCodeColumn.ColumnName] = customInqResultWork.AddUpSecCode.Trim(); // ADD 2010/09/09
                    row[this._dataSet.CustomInqResult.CustomerCodeColumn.ColumnName] = customInqResultWork.CustomerCode.ToString().PadLeft(8, '0');
                    foreach (CustomerSearchRet ret in customerSearchRet)
                    {
                        if (ret.CustomerCode == customInqResultWork.CustomerCode)
                        {
                            //----- UPD 2010/10/13 ----->>>>>
                            //row[this._dataSet.CustomInqResult.CustomerNameColumn.ColumnName] = ret.Name;
                            row[this._dataSet.CustomInqResult.CustomerNameColumn.ColumnName] = ret.Snm;
                            //----- UPD 2010/10/13 -----<<<<<
                            break;

                        }
                    }
                }
                // ---------------------- ADD 2010/08/02 ---------------------------------<<<<<
                row[this._dataSet.CustomInqResult.NetSales4Column.ColumnName] = customInqResultWork.SalesMoney +
                                                                               customInqResultWork.SalesRetGoodsPrice +
                                                                               customInqResultWork.DiscountPrice;
                row[this._dataSet.CustomInqResult.GrossProfit4Column.ColumnName] = customInqResultWork.GrossProfit;
            }
            else if (index == 5)
            {
                // ---------------------- ADD 2010/08/02 --------------------------------->>>>>
                if (customInqResultWork.CustomerCode != 0)
                {
                    //row[this._dataSet.CustomInqResult.AddUpSecCodeColumn.ColumnName] = customInqResultWork.AddUpSecCode; // DEL 2010/09/09
                    row[this._dataSet.CustomInqResult.AddUpSecCodeColumn.ColumnName] = customInqResultWork.AddUpSecCode.Trim(); // ADD 2010/09/09
                    row[this._dataSet.CustomInqResult.CustomerCodeColumn.ColumnName] = customInqResultWork.CustomerCode.ToString().PadLeft(8, '0');
                    foreach (CustomerSearchRet ret in customerSearchRet)
                    {
                        if (ret.CustomerCode == customInqResultWork.CustomerCode)
                        {
                            //----- UPD 2010/10/13 ----->>>>>
                            //row[this._dataSet.CustomInqResult.CustomerNameColumn.ColumnName] = ret.Name;
                            row[this._dataSet.CustomInqResult.CustomerNameColumn.ColumnName] = ret.Snm;
                            //----- UPD 2010/10/13 -----<<<<<
                            break;

                        }
                    }
                }
                // ---------------------- ADD 2010/08/02 --------------------------------->>>>>
                row[this._dataSet.CustomInqResult.NetSales3Column.ColumnName] = customInqResultWork.SalesMoney +
                                                                               customInqResultWork.SalesRetGoodsPrice +
                                                                               customInqResultWork.DiscountPrice;
                row[this._dataSet.CustomInqResult.GrossProfit3Column.ColumnName] = customInqResultWork.GrossProfit;
            }
            else if (index == 6)
            {
                // ---------------------- ADD 2010/08/02 ---------------------------------<<<<<
                if (customInqResultWork.CustomerCode != 0)
                {
                    //row[this._dataSet.CustomInqResult.AddUpSecCodeColumn.ColumnName] = customInqResultWork.AddUpSecCode; // DEL 2010/09/09
                    row[this._dataSet.CustomInqResult.AddUpSecCodeColumn.ColumnName] = customInqResultWork.AddUpSecCode.Trim(); // ADD 2010/09/09
                    row[this._dataSet.CustomInqResult.CustomerCodeColumn.ColumnName] = customInqResultWork.CustomerCode.ToString().PadLeft(8, '0');
                    foreach (CustomerSearchRet ret in customerSearchRet)
                    {
                        if (ret.CustomerCode == customInqResultWork.CustomerCode)
                        {
                            //----- UPD 2010/10/13 ----->>>>>
                            //row[this._dataSet.CustomInqResult.CustomerNameColumn.ColumnName] = ret.Name;
                            row[this._dataSet.CustomInqResult.CustomerNameColumn.ColumnName] = ret.Snm;
                            //----- UPD 2010/10/13 -----<<<<<
                            break;

                        }
                    }
                }
                // ---------------------- ADD 2010/08/02 --------------------------------->>>>>
                row[this._dataSet.CustomInqResult.NetSales2Column.ColumnName] = customInqResultWork.SalesMoney +
                                                                               customInqResultWork.SalesRetGoodsPrice +
                                                                               customInqResultWork.DiscountPrice;
                row[this._dataSet.CustomInqResult.GrossProfit2Column.ColumnName] = customInqResultWork.GrossProfit;
            }
            else if (index == 7)
            {
                // ---------------------- ADD 2010/08/02 ---------------------------------<<<<<
                if (customInqResultWork.CustomerCode != 0)
                {
                    //row[this._dataSet.CustomInqResult.AddUpSecCodeColumn.ColumnName] = customInqResultWork.AddUpSecCode; // DEL 2010/09/09
                    row[this._dataSet.CustomInqResult.AddUpSecCodeColumn.ColumnName] = customInqResultWork.AddUpSecCode.Trim(); // ADD 2010/09/09
                    row[this._dataSet.CustomInqResult.CustomerCodeColumn.ColumnName] = customInqResultWork.CustomerCode.ToString().PadLeft(8, '0');
                    foreach (CustomerSearchRet ret in customerSearchRet)
                    {
                        if (ret.CustomerCode == customInqResultWork.CustomerCode)
                        {
                            //----- UPD 2010/10/13 ----->>>>>
                            //row[this._dataSet.CustomInqResult.CustomerNameColumn.ColumnName] = ret.Name;
                            row[this._dataSet.CustomInqResult.CustomerNameColumn.ColumnName] = ret.Snm;
                            //----- UPD 2010/10/13 -----<<<<<
                            break;

                        }
                    }
                }
                // ---------------------- ADD 2010/08/02 --------------------------------->>>>>
                row[this._dataSet.CustomInqResult.NetSales1Column.ColumnName] = customInqResultWork.SalesMoney +
                                                                               customInqResultWork.SalesRetGoodsPrice +
                                                                               customInqResultWork.DiscountPrice;
                row[this._dataSet.CustomInqResult.GrossProfit1Column.ColumnName] = customInqResultWork.GrossProfit;
            }

        }
        // ---------------------- ADD 2010/07/20 -----------------------------------<<<<<

        #endregion // データセット結果コピー

        #region 検索条件クラス→リモート検索条件ワーククラス　データコピー

        /// <summary>
        /// 検索条件クラス→リモート検索条件ワーククラス　データコピー
        /// </summary>
        /// <param name="customInqOrderCndtn">得意先過年度実績照会抽出条件クラス</param>
        private void CopyParamater2RemoteParameterWork(CustomInqOrderCndtn customInqOrderCndtn)
        {
            this._customInqOrderCndtnWork.AddUpSecCode = customInqOrderCndtn.AddUpSecCode;
            this._customInqOrderCndtnWork.CustomerCode = customInqOrderCndtn.CustomerCode;
            this._customInqOrderCndtnWork.EnterpriseCode = customInqOrderCndtn.EnterpriseCode;
            this._customInqOrderCndtnWork.St_AddUpYearMonth = TDateTime.LongDateToDateTime(customInqOrderCndtn.St_AddUpYearMonth);
            this._customInqOrderCndtnWork.Ed_AddUpYearMonth = TDateTime.LongDateToDateTime(customInqOrderCndtn.Ed_AddUpYearMonth);
        }

        // ---------------------- ADD 2010/07/20 --------------------------------->>>>>
        /// <summary>
        /// 検索条件クラス→リモート検索条件ワーククラス　データコピー
        /// </summary>
        /// <param name="customInqOrderCndtn">得意先過年度実績照会抽出条件クラス</param>
        /// <returns>検索結果ワーク</returns>
        private CustomInqOrderCndtnWork CopyParamaterRemoteParameterWork(CustomInqOrderCndtn customInqOrderCndtn)
        {
            CustomInqOrderCndtnWork customInqOrderCndtnWork = new CustomInqOrderCndtnWork();
            customInqOrderCndtnWork.AddUpSecCode = customInqOrderCndtn.AddUpSecCode;
            customInqOrderCndtnWork.CustomerCode = customInqOrderCndtn.CustomerCode;
            customInqOrderCndtnWork.EnterpriseCode = customInqOrderCndtn.EnterpriseCode;
            customInqOrderCndtnWork.St_AddUpYearMonth = TDateTime.LongDateToDateTime(customInqOrderCndtn.St_AddUpYearMonth);
            customInqOrderCndtnWork.Ed_AddUpYearMonth = TDateTime.LongDateToDateTime(customInqOrderCndtn.Ed_AddUpYearMonth);

            return customInqOrderCndtnWork;
        }
        // ---------------------- ADD 2010/07/20 -----------------------------------<<<<<

        #endregion // 検索条件クラス→リモート検索条件ワーククラス　データコピー

        // ---------------------- ADD 2010/07/20 --------------------------------->>>>>
        #region 会計年度取得(今回月次処理日より算出)
        /// <summary>
        /// 会計年度情報取得処理
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="financialYear">会計年度</param>
        /// <param name="startDate">年度開始日</param>
        /// <param name="endDate">年度終了日</param>
        /// <returns>ステータス</returns>
        private int GetFinancialYearInfo(string sectionCode, out int financialYear, out int startDate, out int endDate)
        {
            //----------------------------------------------------------------------------------------------
            // 会計年度  ：今回月次処理日を含む年度(=日付取得部品より取得)をセット
            // 年度開始日：対象の会計年度の開始日(=日付取得部品より取得)をセット
            // 年度終了日：対象の会計年度の終了日(=日付取得部品より取得)をセット
            //----------------------------------------------------------------------------------------------

            financialYear = 0;
            startDate = 0;
            endDate = 0;

            DateTime dummyDate;
            DateTime startYearDate;
            DateTime endYearDate;
            DateGetAcs dateGetAcs = DateGetAcs.GetInstance();        // 会計年度取得

            int status;

            // 自社設定マスタの会計年度を取得
            CompanyInf companyInf = dateGetAcs.GetCompanyInf();
            status = -1;
            if (companyInf != null)
            {
                // 自社設定マスタの期首年月日で年度開始／終了日を取得
                DateTime dateTime = TDateTime.LongDateToDateTime(companyInf.CompanyBiginDate);
                dateGetAcs.GetYearMonth(dateTime, out dummyDate, out financialYear, out dummyDate, out dummyDate, out startYearDate, out endYearDate);
                startDate = TDateTime.DateTimeToLongDate(startYearDate);
                endDate = TDateTime.DateTimeToLongDate(endYearDate);
                status = 0;
            }

            return (status);
        }
        #endregion 会計年度取得(今回月次処理日より算出)

        #region
        /// <summary>
        /// パラメータチェック関数
        /// </summary>
        /// <param name="customInqOrderCndtn">得意先過年度実績照会抽出条件クラス</param>
        /// <returns></returns>
        private bool CheckParameter(CustomInqOrderCndtn customInqOrderCndtn)
        {

            // パラメータが必須のものをチェック

            // 年度開始日
            if (customInqOrderCndtn.St_AddUpYearMonth == 0)
            {
                return false;
            }

            // 年度終了日
            if (customInqOrderCndtn.Ed_AddUpYearMonth == 0)
            {
                return false;
            }

            // 得意先コード
            if (customInqOrderCndtn.CustomerCode == 0)
            {
                return false;
            }

            // 企業コード
            if (String.IsNullOrEmpty(customInqOrderCndtn.EnterpriseCode))
            {
                return false;
            }

            return true;
        }
        #endregion
        // ---------------------- ADD 2010/07/20 -----------------------------------<<<<<
    }
}

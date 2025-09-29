//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : 売上実績照会
// プログラム概要   : 売上実績照会アクセスクラス
//----------------------------------------------------------------------------//
//                (c)Copyright  2007 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 行澤　仁美
// 作 成 日  2008/12/01  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 忍 幸史
// 修 正 日  2009/01/15  修正内容 : 障害ID:10075対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 忍 幸史
// 修 正 日  2009/02/04  修正内容 : バグ対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 忍 幸史
// 修 正 日  2009/02/12  修正内容 : 障害ID:11013対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 忍 幸史
// 修 正 日  2009/02/25  修正内容 : 障害ID:11918対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 上野 俊治
// 修 正 日  2009/04/14  修正内容 : 障害ID:12401対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30413 犬飼
// 修 正 日  2009/04/14  修正内容 : 障害ID:12994対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30413 犬飼
// 修 正 日  2009/05/12  修正内容 : 集計区分：得意先の場合、請求拠点コードを設定するように修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30413 犬飼
// 修 正 日  2009/05/25  修正内容 : MANTIS【13331】純正／優良の返品値引符号を反転修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30413 犬飼
// 修 正 日  2009/05/27  修正内容 : MANTIS【13335】対象年度の初期値を自社設定の会計年度に戻す
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30413 犬飼
// 修 正 日  2009/06/17  修正内容 : MANTIS【13396】システム日付によって対象年度の実績が異なるのを修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 22008 長内
// 修 正 日  2009/09/07  修正内容 : MANTIS【14011】粗利算出の不具合を修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 徐後継
// 修 正 日  2010/07/20  修正内容 : テキスト出力対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 徐後継
// 修 正 日  2010/08/02  修正内容 : テキスト出力対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : chenyd
// 修 正 日  2010/08/12  修正内容 : 障害ID:12998 テキスト出力対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : chenyd
// 修 正 日  2010/08/18  修正内容 : 障害ID:13214 テキスト出力対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : chenyd
// 修 正 日  2010/08/19  修正内容 : 障害ID:13278 テキスト出力対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : liyp
// 修 正 日  2011/03/23  修正内容 : テキスト出力対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : yangmj
// 修 正 日  2011/09/30  修正内容 : redmine#25727の対応
//----------------------------------------------------------------------------//
// 管理番号  11100068-00 作成担当 : 河原林 一生
// 修 正 日  2015/07/23  修正内容 : 東海自動車工業課題一覧No.4(テキスト出力で実績が出力されない)
//----------------------------------------------------------------------------//
// 管理番号  11170129-00 作成担当 : 田思春
// 修 正 日  2015/08/18  修正内容 : redmine#47035の対応 伝票枚数の集計結果の不具合を修正
//----------------------------------------------------------------------------//

using System;
using System.Data;
using System.Collections;
using System.Windows.Forms;

using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Common;
using System.Collections.Generic;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 売上実績照会アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 売上実績照会のアクセスクラスです。</br>
    /// <br>Programmer : 30462 行澤　仁美</br>
    /// <br>Date       : 2008.12.01</br>
    /// <br>Update Note: 2009/01/15 30414 忍 幸史　障害ID:10075対応</br>
    /// <br>Update Note: 2009/02/04 30414 忍 幸史　バグ対応</br>
    /// <br>Update Note: 2009/02/12 30414 忍 幸史　障害ID:11013対応</br>
    /// <br>Update Note: 2009/02/25 30414 忍 幸史　障害ID:11918対応</br>
    /// <br>Update Note: 2009/04/14 30452 上野 俊治　障害ID:12401対応</br>
    /// <br>Update Note: 2010/07/20 徐後継  テキスト出力対応</br>
    /// <br>Update Note: 2010/08/02 徐後継  テキスト出力対応</br>
    /// <br>Update Note: 2010/08/12 chenyd  障害ID:12998対応</br>
    /// <br>Update Note: 2010/08/18 chenyd 障害ID:13214 テキスト出力対応</br>
    /// <br>Update Note: 2010/08/19、2010/08/21 chenyd テキスト出力対応13278</br>
    /// <br>Update Note: 2010/08/25  chenyd  テキスト出力対応13278</br>
    /// <br>Update Note: 2011/03/23 liyp   テキスト出力対応</br>
    /// <br>Update Note: 2011/09/30 yangmj redmine#25727 売上年間実績照会の修正対応</br>
    /// </remarks>
    public partial class SelesAnnualDataAcs
    {
        public SelesAnnualDataAcs()
        {
            this._iSalesAnnualDataSelectResultDB = MediationSalesAnnualDataSelectResultDB.GetSalesAnnualDataSelectResultDB();

            this._dataSet = new InventoryUpdateDataSet();
            this._companyInfAcs = new CompanyInfAcs();

            // 日付取得部品
            _dateGet = DateGetAcs.GetInstance();

            _totalDayCalculator = TotalDayCalculator.GetInstance();

        }

        ISalesAnnualDataSelectResultDB _iSalesAnnualDataSelectResultDB;

        private InventoryUpdateDataSet _dataSet;
        private CompanyInfAcs _companyInfAcs;
        private CompanyInf _companyInf;
        // 日付取得部品
        private DateGetAcs _dateGet;
        private TotalDayCalculator _totalDayCalculator;
        private bool _excOrtxtDiv = false;                      // テキスト出力orExcel出力区分  // ADD 2011/03/23
        private int _companyBiginDate;
        private int _companyEndDate;
        private int _companyNowDate;
        private DateTime _companyNowDateTime;

        private int beforeMonth = 0;
        public InventoryUpdateDataSet DataSet
        {
            get { return _dataSet; }
        }

        public DataView DataView
        {
            get
            {
                return this._dataSet.MonthResult.DefaultView;
            }
        }

        // ---------------ADD 2011/03/23 ------------------->>>>>
        // テキスト出力orExcel出力区分
        public bool ExcOrtxtDiv
        {
            get { return this._excOrtxtDiv; }
            set { _excOrtxtDiv = value; }
        }
        // ---------------ADD 2011/03/23 -------------------<<<<<

        public DataView ErrorDataView
        {
            get
            {
                return this._dataSet.StockResult.DefaultView;
            }
        }

        //---ADD 2010/07/20--------------------------------------->>>>>
        /// <summary>
        /// SalesAnnualDataViewのデータビューの取得
        /// </summary>
        /// <returns>DefaultView</returns>
        public DataView SalesAnnualDataView
        {
            get
            {
                return this._dataSet.MonthResult.DefaultView;
            }
        }
        //---ADD 2010/07/20---------------------------------------<<<<<

        public void GetCompanyInf(string enterpriseCode, out int financialYear, out int CompanyBiginMonth)
        {
            financialYear = System.DateTime.Now.Year;
            CompanyBiginMonth = 0;

            /// 自社情報読み込み
            int status = this._companyInfAcs.Read(out this._companyInf, enterpriseCode);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // --- DEL 2009/02/25 障害ID:11918対応------------------------------------------------------>>>>>
                //financialYear = this._companyInf.FinancialYear;
                // --- DEL 2009/02/25 障害ID:11918対応------------------------------------------------------<<<<<
                financialYear = this._companyInf.FinancialYear;     // ADD 2009/05/27
                CompanyBiginMonth = this._companyInf.CompanyBiginMonth;
            }

            // DEL 2009/05/27 ------>>>
            //// --- ADD 2009/02/25 障害ID:11918対応------------------------------------------------------>>>>>
            //int addYearsFormThis;
            //this._dateGet.GetYearFromMonth(DateTime.Now, out financialYear, out addYearsFormThis);
            //// --- ADD 2009/02/25 障害ID:11918対応------------------------------------------------------<<<<<
            // DEL 2009/05/27 ------<<<
        }

        public void ViewGrid(int financialYear, int totalDiv)
        {
            int companyBiginMonth = this._companyInf.CompanyBiginMonth;
            int nowFinancialYear = this._companyInf.FinancialYear;
            List<DateTime> startMonthDate;
            List<DateTime> endMonthDate;
            List<DateTime> yearMonth;
            int year;

             _dateGet.GetFinancialYearTable((nowFinancialYear - financialYear) * -1, out startMonthDate, out endMonthDate, out yearMonth, out year);

            // 今期開始年月
            _companyBiginDate = Int32.Parse(yearMonth[0].ToString("yyyyMM"));

            // 今期終了年月
            _companyEndDate = Int32.Parse(yearMonth[11].ToString("yyyyMM"));
            
            // 現在処理年月
            DateTime nowyearMonth;
            // DEL 2009/06/17 ------>>>
            //_dateGet.GetThisYearMonth(out nowyearMonth);
            //_companyNowDate = Int32.Parse(nowyearMonth.ToString("yyyyMM"));
            //_companyNowDateTime = nowyearMonth;
            // DEL 2009/06/17 ------<<<

            // ADD 2009/06/17 ------>>>
            // 現在処理年月を今回月次更新年月とする
            DateTime prevTotalDay;
            DateTime currentTotalDay;
            DateTime prevTotalMonth;
            DateTime currentTotalMonth;
            _totalDayCalculator.InitializeHisMonthly();
            _totalDayCalculator.GetHisTotalDayMonthly("", out prevTotalDay, out currentTotalDay, out prevTotalMonth, out currentTotalMonth);
            if (currentTotalMonth != DateTime.MinValue)
            {
                _companyNowDate = Int32.Parse(currentTotalMonth.ToString("yyyyMM"));
                _companyNowDateTime = currentTotalMonth;
            }
            else
            {
                _dateGet.GetThisYearMonth(out nowyearMonth);
                _companyNowDate = Int32.Parse(nowyearMonth.ToString("yyyyMM"));
                _companyNowDateTime = nowyearMonth;
            }
            // ADD 2009/06/17 ------<<<
            
            for (int ix = 0; ix < 14; ix++)
            {
                InventoryUpdateDataSet.MonthResultRow row = _dataSet.MonthResult.NewMonthResultRow();
                if (ix < 12)
                {
                    int biginMonth = companyBiginMonth + ix;
                    if (biginMonth > 12) { biginMonth = biginMonth - 12; }
                    row.RowTitle = biginMonth.ToString() + "月";
                    row.RowMonth = biginMonth;
                }
                if (ix == 12) { row.RowTitle = "合計"; }
                if (ix == 13) { row.RowTitle = "平均"; }

                row.RowNo = ix;
                row.RowSetFlg = 0;
                _dataSet.MonthResult.AddMonthResultRow(row);
            }
            if (totalDiv == 1)
            {
                for (int ix = 0; ix < 9; ix++)
                {
                    InventoryUpdateDataSet.StockResultRow row = _dataSet.StockResult.NewStockResultRow();

                    if (ix == 0) { row.RowTitle = "在庫"; row.Title = " 純正"; }
                    if (ix == 1) { row.RowTitle = "取寄"; row.Title = " 純正"; }
                    if (ix == 2) { row.RowTitle = "合計"; row.Title = " 純正"; }
                    if (ix == 3) { row.RowTitle = "在庫"; row.Title = " 優良"; }
                    if (ix == 4) { row.RowTitle = "取寄"; row.Title = " 優良"; }
                    if (ix == 5) { row.RowTitle = "合計"; row.Title = " 優良"; }
                    if (ix == 6) { row.RowTitle = "在庫"; row.Title = " 合計"; }
                    if (ix == 7) { row.RowTitle = "取寄"; row.Title = " 合計"; }
                    if (ix == 8) { row.RowTitle = "合計"; row.Title = " 合計"; }
                    row.RowNo = ix;
                    _dataSet.StockResult.AddStockResultRow(row);
                }
            }
            else
            {
                for (int ix = 0; ix < 6; ix++)
                {
                    InventoryUpdateDataSet.StockResultRow row = _dataSet.StockResult.NewStockResultRow();


                    if (ix == 0) { row.RowTitle = "純正"; }
                    if (ix == 1) { row.RowTitle = "優良"; }
                    if (ix == 2) { row.RowTitle = "合計"; }
                    if (ix == 3) { row.RowTitle = "在庫"; }
                    if (ix == 4) { row.RowTitle = "取寄"; }
                    if (ix == 5) { row.RowTitle = "合計"; }

                    row.RowNo = ix;
                    _dataSet.StockResult.AddStockResultRow(row);
                }
            }
            // 出荷履歴照会用設定
            for (int ix = 0; ix < 12; ix++)
            {
                InventoryUpdateDataSet.ShipmentResultRow row = _dataSet.ShipmentResult.NewShipmentResultRow();

                if (ix < 12)
                {
                    int biginMonth = companyBiginMonth + ix;
                    if (biginMonth > 12) { biginMonth = biginMonth - 12; }
                    row.RowMonth = biginMonth;
                }

                row.RowNo = ix;
                _dataSet.ShipmentResult.AddShipmentResultRow(row);
            }

            InventoryUpdateDataSet.StockOrderResultRow row_so = _dataSet.StockOrderResult.NewStockOrderResultRow();

            row_so.RowNo = 0;
            _dataSet.StockOrderResult.AddStockOrderResultRow(row_so);
        }

        // --- ADD 2010/07/20 -------------------------------->>>>>
        /// <summary>
        /// 売上実績照会データを検索し、検索結果をデータテーブルにキャッシュします。
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCodeList">拠点コード</param>
        /// <param name="selectionCodeList">選択項目コード</param>
        /// <param name="totalDiv">0:拠点 1:得意先 2:担当者 3:受注者 4:発行者 5:地区 6:業種</param>
        /// <param name="financialYear">対象年度</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note		: 売上実績照会データを検索し、検索結果をデータテーブルにキャッシュします。</br>
        /// <br>Programmer	: 徐後継</br>
        /// <br>Date		: 2010/07/20</br>
        /// <br>Update Note: 2010/08/19、2010/08/25、2010/09/10 chenyd</br>
        /// <br>            ・テキスト出力対応13278</br>
        /// </remarks>
        //public int SearchAll(string enterpriseCode, List<string[]> sectionCodeList, List<string[]> selectionCodeList, int totalDiv, int financialYear)　// DEL 2010/08/25
        public int SearchAll(string enterpriseCode, List<string[]> sectionCodeList, string st_selectionCode, string ed_selectionCode, int searDiv, int totalDiv, int financialYear)// DEL 2010/08/25
        {

            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            // クリア処理

            this._dataSet.MonthResult.Clear();

            // ループの統計
            int cnt = 0;

            // --- DEL 2010/08/02 -------------------------------->>>>>
            //foreach (string[] sectionCode in sectionCodeList)
            //{
            //    if (selectionCodeList.Count != 0)
            //    {
            //        foreach (string[] selectionCode in selectionCodeList)
            //        {
            //            this.SalesAnnualViewGrid(financialYear, totalDiv, sectionCode[0], sectionCode[1], selectionCode[0], selectionCode[1], cnt);

            //            SalesAnnualDataSelectParamWork salesAnnualDataSelectParamWork = this.SetSalesAnnualDataSelectParamWork(enterpriseCode, financialYear, totalDiv, sectionCode[0], selectionCode[0]);


            //            object paraObj = (object)salesAnnualDataSelectParamWork;
            //            object retObj;

            //            status = this._iSalesAnnualDataSelectResultDB.Search(out retObj, paraObj);

            //            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            //            {
            //                // 戻りリストの要素の型がSalesAnnualDataSelectResultWorkならばデータ展開
            //                ArrayList retList = (ArrayList)retObj;
            //                if ((retList.Count > 0) && (retList[0] is SalesAnnualDataSelectResultWork))
            //                {
            //                    foreach (SalesAnnualDataSelectResultWork data in retList)
            //                    {
            //                        this.SalesAnnualCache(data, totalDiv, cnt);
            //                    }
            //                }

            //                // 率算出
            //                SetSalesAnnualResultRowFromUIData_Average(cnt);

            //                this._dataSet.MonthResult.DefaultView.Sort = this._dataSet.MonthResult.RowNoColumn.ColumnName;
            //            }
            //            cnt++;
            //        }
            //    }
            //    else
            //    {
            //        this.SalesAnnualViewGrid(financialYear, totalDiv, sectionCode[0], sectionCode[1], "", "", cnt);

            //        SalesAnnualDataSelectParamWork salesAnnualDataSelectParamWork = this.SetSalesAnnualDataSelectParamWork(enterpriseCode, financialYear, totalDiv, sectionCode[0], "");

            //        object paraObj = (object)salesAnnualDataSelectParamWork;
            //        object retObj;

            //        status = this._iSalesAnnualDataSelectResultDB.Search(out retObj, paraObj);

            //        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            //        {
            //            // 戻りリストの要素の型がSalesAnnualDataSelectResultWorkならばデータ展開
            //            ArrayList retList = (ArrayList)retObj;
            //            if ((retList.Count > 0) && (retList[0] is SalesAnnualDataSelectResultWork))
            //            {
            //                foreach (SalesAnnualDataSelectResultWork data in retList)
            //                {
            //                    this.SalesAnnualCache(data, totalDiv, cnt);
            //                }
            //            }

            //            // 率算出
            //            SetSalesAnnualResultRowFromUIData_Average(cnt);

            //            this._dataSet.MonthResult.DefaultView.Sort = this._dataSet.MonthResult.RowNoColumn.ColumnName;
            //        }
            //        cnt++;
            //    }
            //}
            // --- DEL 2010/08/02 --------------------------------<<<<<

            // --- ADD 2010/08/02 -------------------------------->>>>>
            ArrayList paramWorkList = new ArrayList();
            this.SalesAnnualViewGrid(financialYear, totalDiv); // ADD 2010/08/19

            // --- DEL 2010/08/25 -------------------------------->>>>>
            //foreach (string[] sectionCode in sectionCodeList)
            //{
            //    if (selectionCodeList.Count != 0)
            //    {
            //        foreach (string[] selectionCode in selectionCodeList)
            //        {

            //            SalesAnnualDataSelectParamWork salesAnnualDataSelectParamWork = this.SetSalesAnnualDataSelectParamWork(enterpriseCode, financialYear, totalDiv, sectionCode, selectionCode);
            //            paramWorkList.Add(salesAnnualDataSelectParamWork);
            //        }
            //    }
            //    else
            //    {

            //        SalesAnnualDataSelectParamWork salesAnnualDataSelectParamWork = this.SetSalesAnnualDataSelectParamWork(enterpriseCode, financialYear, totalDiv, sectionCode, new string[] { });
            //        paramWorkList.Add(salesAnnualDataSelectParamWork);
            //    }
            //}
            // --- DEL 2010/08/25 --------------------------------<<<<<

            SalesAnnualDataSelectParamWork salesAnnualDataSelectParamWork = this.SetSalesAnnualDataSelectParamWork(enterpriseCode, financialYear, totalDiv, sectionCodeList, st_selectionCode, ed_selectionCode, searDiv);
            object paraObj = (object)salesAnnualDataSelectParamWork;
            object retObj;

            status = this._iSalesAnnualDataSelectResultDB.SearchAll(out retObj, paraObj);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                //this.SalesAnnualViewGrid(financialYear, totalDiv); // DEL 2010/08/19
                // 戻りリストの要素の型がSalesAnnualDataSelectResultWorkならばデータ展開
                ArrayList retList = (ArrayList)retObj;

                if ((retList.Count > 0))
                {
                    foreach (ArrayList array in retList)
                    {
                        if (array.Count > 0 && (array[0] is SalesAnnualDataSelectResultWork))
                        {
                            string customerCode = string.Empty; // ADD 2010/08/25
                            bool isFirstFlg = true;  // ADD 2010/08/25

                            foreach (SalesAnnualDataSelectResultWork data in array)
                            {
                                // --- ADD 2010/09/10 -------------------------------->>>>>
                                data.SectionCode = data.SectionCode.Trim();
                                // --- ADD 2010/09/10 --------------------------------<<<<<

                                // --- ADD 2010/08/25 -------------------------------->>>>>
                                if (2 == totalDiv || 3 == totalDiv || 4 == totalDiv)
                                {
                                    // --- ADD 2010/09/10 -------------------------------->>>>>
                                    data.SelectionCode = data.SelectionCode.Trim();
                                    // --- ADD 2010/09/10 --------------------------------<<<<<
                                    EmployeeAcs employeeAcs = new EmployeeAcs();
                                    Employee employee;
                                    status = employeeAcs.Read(out employee, enterpriseCode, data.SelectionCode);
                                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                    {
                                        data.SelectionName = employee.Name;
                                    }
                                }
                                // --- ADD 2010/09/02 -------------------------------->>>>>
                                if ((totalDiv == 5) || (totalDiv == 6))
                                {
                                    // 地区・業種
                                    UserGuideAcs _userGuideAcs = new UserGuideAcs();
                                    UserGdBd userGdBd = new UserGdBd();
                                    ArrayList userGdBdList = new ArrayList();
                                    int userGuideDivCd;
                                    if (totalDiv == 5)  // 地区（販売エリア）
                                    {
                                        userGuideDivCd = 21;
                                    }
                                    else // 業種
                                    {
                                        userGuideDivCd = 33;
                                    }
                                    int code = -1;
                                    if (!string.IsNullOrEmpty(data.SelectionCode))
                                    {
                                        code = Int32.Parse(data.SelectionCode);
                                    }
                                    UserGuideAcsData userGuideAcsData = UserGuideAcsData.UserBodyData;
                                    int statusUser = _userGuideAcs.ReadBody(out userGdBd, enterpriseCode, userGuideDivCd, code, ref userGuideAcsData);
                                    if (statusUser == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                    {
                                        data.SelectionName = userGdBd.GuideName;
                                    }
                                }
                                // --- ADD 2010/09/02 --------------------------------<<<<<
                                if (totalDiv != 0)
                                {
                                    if (isFirstFlg)
                                    {
                                        customerCode = data.SelectionCode;
                                // --- ADD 2010/08/25 --------------------------------<<<<<
                                        this.SalesAnnualCache(data, totalDiv, cnt);
                                // --- ADD 2010/08/25 -------------------------------->>>>>
                                    }
                                    else
                                    {
                                        if (customerCode.Equals(data.SelectionCode))
                                        {
                                            this.SalesAnnualCache(data, totalDiv, cnt);
                                        }
                                        else
                                        {
                                            customerCode = data.SelectionCode;

                                            // 率算出
                                            SetSalesAnnualResultRowFromUIData_Average(cnt);

                                            cnt++;

                                            this.SalesAnnualCache(data, totalDiv, cnt);
                                        }
                                    }
                                    isFirstFlg = false;
                                }
                                else
                                {
                                    this.SalesAnnualCache(data, totalDiv, cnt);
                                }
                                
                            }
                            // --- ADD 2010/08/25 --------------------------------<<<<<
                            // 率算出
                            SetSalesAnnualResultRowFromUIData_Average(cnt);

                            cnt++;
                        }
                    }
                }

                this._dataSet.MonthResult.DefaultView.Sort = this._dataSet.MonthResult.RowNoColumn.ColumnName;
            }
            // --- ADD 2010/08/02 --------------------------------<<<<<
            
            return status;
        }

        /// <summary>
        /// SetSalesAnnualDataSelectParamWorkの設定
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="financialYear">対象年度</param>
        /// <param name="totalDiv">0:拠点 1:得意先 2:担当者 3:受注者 4:発行者 5:地区 6:業種</param>
        /// <param name="sectionCodeArr">拠点コード</param>
        /// <param name="selectionCodeArr">選択項目コード</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note		: SetSalesAnnualDataSelectParamWorkの設定します。</br>
        /// <br>Programmer	: 徐後継</br>
        /// <br>Date		: 2010/07/20</br>
        /// <br>Update Note : 2011/09/30</br>
        /// <br>Programmer	: yangmj</br>
        /// <br>Date		: redmine#25727 売上年間実績照会の修正対応</br>
        /// </remarks>
        //private SalesAnnualDataSelectParamWork SetSalesAnnualDataSelectParamWork(string enterpriseCode, int financialYear, int totalDiv, string sectionCode, string selectionCode) // DEL 2010/08/02
        //private SalesAnnualDataSelectParamWork SetSalesAnnualDataSelectParamWork(string enterpriseCode, int financialYear, int totalDiv, string[] sectionCodeArr, string[] selectionCodeArr) // ADD 2010/08/02
        private SalesAnnualDataSelectParamWork SetSalesAnnualDataSelectParamWork(string enterpriseCode, int financialYear, int totalDiv, List<string[]> sectionCodeList, string st_selectionCode, string ed_selectionCode, int searDiv)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            SalesAnnualDataSelectParamWork salesAnnualDataSelectParamWork = new SalesAnnualDataSelectParamWork();
            salesAnnualDataSelectParamWork.EnterpriseCode = enterpriseCode;
            //salesAnnualDataSelectParamWork.SectionCode = sectionCode; // DEL 2010/08/02
            // --- ADD 2010/08/02 -------------------------------->>>>>
            // 拠点コード、名称
            //if (null != sectionCodeArr && sectionCodeArr.Length > 1)
            //{
            //    salesAnnualDataSelectParamWork.SectionCode = sectionCodeArr[0];
            //    salesAnnualDataSelectParamWork.SectionName = sectionCodeArr[1];
            //}
            //// 選択項目コード、名称
            //if (null != selectionCodeArr && selectionCodeArr.Length > 1)
            //{
            //    salesAnnualDataSelectParamWork.SelectionCode = selectionCodeArr[0];
            //    salesAnnualDataSelectParamWork.SelectionName = selectionCodeArr[1];
            //}
            //string sectionCode = string.Empty;
            //string selectionCode = string.Empty;
            //if (null != sectionCodeArr && sectionCodeArr.Length > 0)
            //    sectionCode = sectionCodeArr[0];
            //if (null != selectionCodeArr && selectionCodeArr.Length > 0)
            //    selectionCode = selectionCodeArr[0];
            // --- ADD 2010/08/02 --------------------------------<<<<<
            // --- ADD 2010/08/25 -------------------------------->>>>>
            salesAnnualDataSelectParamWork.SectionCodeList = sectionCodeList;
            salesAnnualDataSelectParamWork.SearDiv = searDiv;
            salesAnnualDataSelectParamWork.St_SelectionCode = st_selectionCode;
            salesAnnualDataSelectParamWork.Ed_SelectionCode = ed_selectionCode;
            // --- ADD 2010/08/25 --------------------------------<<<<<

            // 集計区分
            switch (totalDiv)
            {
                case 0: // 拠点
                case 1: // 得意先
                    salesAnnualDataSelectParamWork.TotalDiv = totalDiv;
                    break;
                case 2: // 担当者
                case 3: // 受注者
                case 4: // 発行者
                    salesAnnualDataSelectParamWork.TotalDiv = 2;
                    break;
                case 5: // 地区（販売エリアコード）
                    salesAnnualDataSelectParamWork.TotalDiv = 3;
                    break;
                case 6: // 業種
                    salesAnnualDataSelectParamWork.TotalDiv = 4;
                    break;

            }

            // 抽出区分
            salesAnnualDataSelectParamWork.SearchDiv = 0;
            switch (totalDiv)
            {
                case 0: // 拠点
                    {
                        salesAnnualDataSelectParamWork.EmployeeDivCd = 10;
                        break;
                    }
                case 1: // 得意先
                    {
                        // --- DEL 2010/08/25 -------------------------------->>>>>
                        //if (string.IsNullOrEmpty(selectionCode))
                        //{
                        //    salesAnnualDataSelectParamWork.CustomerCode = 0;
                        //}
                        //else
                        //{
                        //    salesAnnualDataSelectParamWork.CustomerCode = Convert.ToInt32(selectionCode);
                        //}
                        // --- DEL 2010/08/25 --------------------------------<<<<<
                        salesAnnualDataSelectParamWork.EmployeeDivCd = 10;
                        break;
                    }
                case 2: // 担当者
                case 3: // 受注者
                case 4: // 発行者
                    {
                        //salesAnnualDataSelectParamWork.EmployeeCode = selectionCode; // DEL 2010/08/25

                        if (totalDiv == 2)
                        {
                            // 従業員区分
                            salesAnnualDataSelectParamWork.EmployeeDivCd = 10;
                        }
                        else if (totalDiv == 3)
                        {
                            // 従業員区分
                            salesAnnualDataSelectParamWork.EmployeeDivCd = 20;
                        }
                        else if (totalDiv == 4)
                        {
                            // 従業員区分
                            salesAnnualDataSelectParamWork.EmployeeDivCd = 30;
                        }
                        break;
                    }
                case 5: // 地区（販売エリアコード）
                    {
                        // --- DEL 2010/08/25 -------------------------------->>>>>
                        //if (string.IsNullOrEmpty(selectionCode))
                        //{
                        //    salesAnnualDataSelectParamWork.SalesAreaCode = 0;
                        //}
                        //else
                        //{
                        //    salesAnnualDataSelectParamWork.SalesAreaCode = Convert.ToInt32(selectionCode);
                        //}
                        // --- DEL 2010/08/25 --------------------------------<<<<<
                        salesAnnualDataSelectParamWork.EmployeeDivCd = 10;
                        break;
                    }
                case 6: // 業種
                    {
                        // --- DEL 2010/08/25 -------------------------------->>>>>
                        //if (string.IsNullOrEmpty(selectionCode))
                        //{
                        //    salesAnnualDataSelectParamWork.BusinessTypeCode = 0;
                        //}
                        //else
                        //{
                        //    salesAnnualDataSelectParamWork.BusinessTypeCode = Convert.ToInt32(selectionCode);
                        //}
                        // --- DEL 2010/08/25 --------------------------------<<<<<
                        salesAnnualDataSelectParamWork.EmployeeDivCd = 10;
                        break;
                    }
            }

            // 前期の開始年月を設定しないと、前期の取得が出来ないので修正前に戻す
            //salesAnnualDataSelectParamWork.YearMonthSt = _companyBiginDate - 100;//DEL 2011/09/30
            salesAnnualDataSelectParamWork.YearMonthSt = _companyBiginDate;//ADD 2011/09/30

            // 終了年月（当月）
            salesAnnualDataSelectParamWork.YearMonthEd = _companyEndDate;

            DateTime prevTotalDay = DateTime.MinValue;
            DateTime currentTotalDay = DateTime.MinValue;
            // --- DEL 2010/08/25 -------------------------------->>>>>
            //switch (totalDiv)
            //{
            //    case 0:     // 集計区分が拠点
            //        {
            //            // 計上年月
            //            salesAnnualDataSelectParamWork.AddUpYearMonth = DateTime.MinValue;
            //            // 開始集計年月日(得意先)　得意先前回締日(開始)をセット
            //            salesAnnualDataSelectParamWork.StAddUpDate = 0;
            //            // 終了集計年月日(得意先)　得意先前回締日(終了)をセット
            //            salesAnnualDataSelectParamWork.EdAddUpDate = 0;
            //            // 集計得意先締日(年月日)　得意先今回締日(終了)をセット
            //            salesAnnualDataSelectParamWork.CustTotalDay = 0;

            //            status = _totalDayCalculator.GetHisTotalDayDmdC(sectionCode, out prevTotalDay, out currentTotalDay);
            //            if (status == 0)
            //            {
            //                // 開始集計年月日(拠点)　拠点前回締日(開始)をセット
            //                if (prevTotalDay != DateTime.MinValue)
            //                {
            //                    DateTime stDate = prevTotalDay.AddDays(1);
            //                    stDate = stDate.AddMonths(-1);
            //                    salesAnnualDataSelectParamWork.StSecAddUpDate = Int32.Parse(stDate.ToString("yyyyMMdd"));
            //                }
            //                else
            //                {
            //                    salesAnnualDataSelectParamWork.StSecAddUpDate = 0;
            //                }
            //                // 終了集計年月日(拠点)　拠点前回締日(終了)をセット
            //                salesAnnualDataSelectParamWork.EdSecAddUpDate = Int32.Parse(prevTotalDay.ToString("yyyyMMdd"));
            //                // 集計拠点締日(年月日)　拠点今回締日(終了)をセット
            //                salesAnnualDataSelectParamWork.SecTotalDay = Int32.Parse(currentTotalDay.ToString("yyyyMMdd"));
            //            }
            //            else
            //            {
            //                // 開始集計年月日(拠点)　拠点前回締日(開始)をセット
            //                salesAnnualDataSelectParamWork.StSecAddUpDate = 0;
            //                // 終了集計年月日(拠点)　拠点前回締日(終了)をセット
            //                salesAnnualDataSelectParamWork.EdSecAddUpDate = 0;
            //                // 集計拠点締日(年月日)　拠点今回締日(終了)をセット
            //                salesAnnualDataSelectParamWork.SecTotalDay = 0;
            //            }

            //            break;
            //        }
            //    case 1:     // 集計区分が得意先
            //        {
            //            // 請求計上拠点
            //            salesAnnualDataSelectParamWork.ClaimSectionCode = selectionCode;

            //            // 計上年月
            //            salesAnnualDataSelectParamWork.AddUpYearMonth = _companyNowDateTime;

            //            status = _totalDayCalculator.GetTotalDayDmdC(selectionCode, Convert.ToInt32(selectionCode), out prevTotalDay, out currentTotalDay);
            //            if (status == 0)
            //            {
            //                // 開始集計年月日(得意先)　得意先前回締日(開始)をセット
            //                if (prevTotalDay != DateTime.MinValue)
            //                {
            //                    DateTime stDate = prevTotalDay.AddDays(1);
            //                    stDate = stDate.AddMonths(-1);
            //                    salesAnnualDataSelectParamWork.StAddUpDate = Int32.Parse(stDate.ToString("yyyyMMdd"));
            //                }
            //                else
            //                {
            //                    salesAnnualDataSelectParamWork.StAddUpDate = 0;
            //                }
            //                // 終了集計年月日(得意先)　得意先前回締日(終了)をセット
            //                salesAnnualDataSelectParamWork.EdAddUpDate = Int32.Parse(prevTotalDay.ToString("yyyyMMdd"));
            //                // 集計得意先締日(年月日)　得意先今回締日(終了)をセット
            //                salesAnnualDataSelectParamWork.CustTotalDay = Int32.Parse(currentTotalDay.ToString("yyyyMMdd"));
            //            }
            //            else
            //            {
            //                // 開始集計年月日(得意先)　得意先前回締日(開始)をセット
            //                salesAnnualDataSelectParamWork.StAddUpDate = 0;
            //                // 終了集計年月日(得意先)　得意先前回締日(終了)をセット
            //                salesAnnualDataSelectParamWork.EdAddUpDate = 0;
            //                // 集計得意先締日(年月日)　得意先今回締日(終了)をセット
            //                salesAnnualDataSelectParamWork.CustTotalDay = 0;
            //            }

            //            status = _totalDayCalculator.GetTotalDayMonthlyAccRec(Convert.ToInt32(selectionCode), out prevTotalDay, out currentTotalDay);

            //            if (status == 0)
            //            {
            //                // 開始集計年月日(拠点)　拠点前回締日(開始)をセット
            //                if (prevTotalDay != DateTime.MinValue)
            //                {
            //                    //末日の取得方法の修正
            //                    DateTime stDate = prevTotalDay.AddDays(1);
            //                    stDate = stDate.AddMonths(-1);
            //                    salesAnnualDataSelectParamWork.StSecAddUpDate = Int32.Parse(stDate.ToString("yyyyMMdd"));
            //                }
            //                else
            //                {
            //                    salesAnnualDataSelectParamWork.StSecAddUpDate = 0;
            //                }
            //                // 終了集計年月日(拠点)　拠点前回締日(終了)をセット
            //                salesAnnualDataSelectParamWork.EdSecAddUpDate = Int32.Parse(prevTotalDay.ToString("yyyyMMdd"));
            //                // 集計拠点締日(年月日)　拠点今回締日(終了)をセット
            //                salesAnnualDataSelectParamWork.SecTotalDay = Int32.Parse(currentTotalDay.ToString("yyyyMMdd"));
            //            }
            //            else
            //            {
            //                // 開始集計年月日(拠点)　拠点前回締日(開始)をセット
            //                salesAnnualDataSelectParamWork.StSecAddUpDate = 0;
            //                // 終了集計年月日(拠点)　拠点前回締日(終了)をセット
            //                salesAnnualDataSelectParamWork.EdSecAddUpDate = 0;
            //                // 集計拠点締日(年月日)　拠点今回締日(終了)をセット
            //                salesAnnualDataSelectParamWork.SecTotalDay = 0;
            //            }

            //            break;
            //        }
            //    default:    // その他
            //        {
            //            // 計上年月
            //            salesAnnualDataSelectParamWork.AddUpYearMonth = DateTime.MinValue;
            //            // 開始集計年月日(得意先)　得意先前回締日(開始)をセット
            //            salesAnnualDataSelectParamWork.StAddUpDate = 0;
            //            // 終了集計年月日(得意先)　得意先前回締日(終了)をセット
            //            salesAnnualDataSelectParamWork.EdAddUpDate = 0;
            //            // 集計得意先締日(年月日)　得意先今回締日(終了)をセット
            //            salesAnnualDataSelectParamWork.CustTotalDay = 0;
            //            // 開始集計年月日(拠点)　拠点前回締日(開始)をセット
            //            salesAnnualDataSelectParamWork.StSecAddUpDate = 0;
            //            // 終了集計年月日(拠点)　拠点前回締日(終了)をセット
            //            salesAnnualDataSelectParamWork.EdSecAddUpDate = 0;
            //            // 集計拠点締日(年月日)　拠点今回締日(終了)をセット
            //            salesAnnualDataSelectParamWork.SecTotalDay = 0;
            //            break;
            //        }
            //}

            ////次回月次締日を含む年月度を現在処理中年月とする
            //if (prevTotalDay != DateTime.MinValue)
            //{
            //    DateTime dtYearMonth;
            //    _dateGet.GetYearMonth(currentTotalDay, out dtYearMonth);
            //    _companyNowDate = Int32.Parse(dtYearMonth.ToString("yyyyMM"));
            //}

            // 請求拠点コード
            //switch (totalDiv)
            //{
            //    case 1:     // 集計区分：得意先
            //        {
            //            CustomerInfo customerInfo;
            //            CustomerInfoAcs customerInfoAcs = new CustomerInfoAcs();

            //            status = customerInfoAcs.ReadDBData(ConstantManagement.LogicalMode.GetData0, enterpriseCode, Convert.ToInt32(selectionCode), true, out customerInfo);
            //            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            //            {
            //                salesAnnualDataSelectParamWork.ClaimSectionCode = customerInfo.ClaimSectionCode.TrimEnd();
            //            }
            //            break;
            //        }
            //    default:
            //        {
            //            salesAnnualDataSelectParamWork.ClaimSectionCode = string.Empty;
            //            break;
            //        }
            //}
            // --- DEL 2010/08/25 --------------------------------<<<<<
            return salesAnnualDataSelectParamWork;
        }

        /// <summary>
        /// 売上実績照会データ検索結果オブジェクトをデータテーブルにキャッシュします。
        /// </summary>
        /// <param name="financialYear">対象年度</param>
        /// <param name="totalDiv">集計区分</param>
        /// <remarks>
        /// <br>Note		: 売上実績照会データ検索結果オブジェクトをデータテーブルにキャッシュします。</br>
        /// <br>Programmer	: 徐後継</br>
        /// <br>Date		: 2010/07/20</br>
        /// </remarks>
        //private void SalesAnnualViewGrid(int financialYear, int totalDiv, string sectionCode, string sectionName, string selectionCode, string selectionName, int cnt) // DEL 2010/08/02
        private void SalesAnnualViewGrid(int financialYear, int totalDiv) // ADD 2010/08/02
        {
            int companyBiginMonth = this._companyInf.CompanyBiginMonth;
            int nowFinancialYear = this._companyInf.FinancialYear;
            List<DateTime> startMonthDate;
            List<DateTime> endMonthDate;
            List<DateTime> yearMonth;
            int year;

            _dateGet.GetFinancialYearTable((nowFinancialYear - financialYear) * -1, out startMonthDate, out endMonthDate, out yearMonth, out year);
            
            // 今期開始年月
            _companyBiginDate = Int32.Parse(yearMonth[0].ToString("yyyyMM"));

            // 今期終了年月
            _companyEndDate = Int32.Parse(yearMonth[11].ToString("yyyyMM"));

            // 現在処理年月
            DateTime nowyearMonth;

            // 現在処理年月を今回月次更新年月とする
            DateTime prevTotalDay;
            DateTime currentTotalDay;
            DateTime prevTotalMonth;
            DateTime currentTotalMonth;
            _totalDayCalculator.InitializeHisMonthly();
            _totalDayCalculator.GetHisTotalDayMonthly("", out prevTotalDay, out currentTotalDay, out prevTotalMonth, out currentTotalMonth);
            if (currentTotalMonth != DateTime.MinValue)
            {
                _companyNowDate = Int32.Parse(currentTotalMonth.ToString("yyyyMM"));
                _companyNowDateTime = currentTotalMonth;
            }
            else
            {
                _dateGet.GetThisYearMonth(out nowyearMonth);
                _companyNowDate = Int32.Parse(nowyearMonth.ToString("yyyyMM"));
                _companyNowDateTime = nowyearMonth;
            }
            // --- DEL 2010/08/02 -------------------------------->>>>>
            //InventoryUpdateDataSet.MonthResultRow row = _dataSet.MonthResult.NewMonthResultRow();
            //row.SectionCode = sectionCode;
            //row.SectionName = sectionName;
            //row.SelectionCode = selectionCode;
            //row.SelectionName = selectionName;

            //row.SalesMoney = (long)0;
            //row.ReturnedGoodsPrice = (long)0;
            //row.DiscountPrice = (long)0;
            //row.GenuineSalesMoney = (long)0;
            //row.TargetMoney = (long)0;
            //row.AchievementRate = (double)0;
            //row.GrossProfitMoney = (long)0;
            //row.GrossProfitTargetMoney = (long)0;
            //row.GrossProfitAchievRate = (double)0;

            //row.SalesMoney1 = (long)0;
            //row.ReturnedGoodsPrice1 = (long)0;
            //row.DiscountPrice1 = (long)0;
            //row.GenuineSalesMoney1 = (long)0;
            //row.TargetMoney1 = (long)0;
            //row.AchievementRate1 = (double)0;
            //row.GrossProfitMoney1 = (long)0;
            //row.GrossProfitTargetMoney1 = (long)0;
            //row.GrossProfitAchievRate1 = (double)0;

            //row.SalesMoney2 = (long)0;
            //row.ReturnedGoodsPrice2 = (long)0;
            //row.DiscountPrice2 = (long)0;
            //row.GenuineSalesMoney2 = (long)0;
            //row.TargetMoney2 = (long)0;
            //row.AchievementRate2 = (double)0;
            //row.GrossProfitMoney2 = (long)0;
            //row.GrossProfitTargetMoney2 = (long)0;
            //row.GrossProfitAchievRate2 = (double)0;

            //row.SalesMoney3 = (long)0;
            //row.ReturnedGoodsPrice3 = (long)0;
            //row.DiscountPrice3 = (long)0;
            //row.GenuineSalesMoney3 = (long)0;
            //row.TargetMoney3 = (long)0;
            //row.AchievementRate3 = (double)0;
            //row.GrossProfitMoney3 = (long)0;
            //row.GrossProfitTargetMoney3 = (long)0;
            //row.GrossProfitAchievRate3 = (double)0;

            //row.SalesMoney4 = (long)0;
            //row.ReturnedGoodsPrice4 = (long)0;
            //row.DiscountPrice4 = (long)0;
            //row.GenuineSalesMoney4 = (long)0;
            //row.TargetMoney4 = (long)0;
            //row.AchievementRate4 = (double)0;
            //row.GrossProfitMoney4 = (long)0;
            //row.GrossProfitTargetMoney4 = (long)0;
            //row.GrossProfitAchievRate4 = (double)0;

            //row.SalesMoney5 = (long)0;
            //row.ReturnedGoodsPrice5 = (long)0;
            //row.DiscountPrice5 = (long)0;
            //row.GenuineSalesMoney5 = (long)0;
            //row.TargetMoney5 = (long)0;
            //row.AchievementRate5 = (double)0;
            //row.GrossProfitMoney5 = (long)0;
            //row.GrossProfitTargetMoney5 = (long)0;
            //row.GrossProfitAchievRate5 = (double)0;

            //row.SalesMoney6 = (long)0;
            //row.ReturnedGoodsPrice6 = (long)0;
            //row.DiscountPrice6 = (long)0;
            //row.GenuineSalesMoney6 = (long)0;
            //row.TargetMoney6 = (long)0;
            //row.AchievementRate6 = (double)0;
            //row.GrossProfitMoney6 = (long)0;
            //row.GrossProfitTargetMoney6 = (long)0;
            //row.GrossProfitAchievRate6 = (double)0;

            //row.SalesMoney7 = (long)0;
            //row.ReturnedGoodsPrice7 = (long)0;
            //row.DiscountPrice7 = (long)0;
            //row.GenuineSalesMoney7 = (long)0;
            //row.TargetMoney7 = (long)0;
            //row.AchievementRate7 = (double)0;
            //row.GrossProfitMoney7 = (long)0;
            //row.GrossProfitTargetMoney7 = (long)0;
            //row.GrossProfitAchievRate7 = (double)0;

            //row.SalesMoney8 = (long)0;
            //row.ReturnedGoodsPrice8 = (long)0;
            //row.DiscountPrice8 = (long)0;
            //row.GenuineSalesMoney8 = (long)0;
            //row.TargetMoney8 = (long)0;
            //row.AchievementRate8 = (double)0;
            //row.GrossProfitMoney8 = (long)0;
            //row.GrossProfitTargetMoney8 = (long)0;
            //row.GrossProfitAchievRate8 = (double)0;

            //row.SalesMoney9 = (long)0;
            //row.ReturnedGoodsPrice9 = (long)0;
            //row.DiscountPrice9 = (long)0;
            //row.GenuineSalesMoney9 = (long)0;
            //row.TargetMoney9 = (long)0;
            //row.AchievementRate9 = (double)0;
            //row.GrossProfitMoney9 = (long)0;
            //row.GrossProfitTargetMoney9 = (long)0;
            //row.GrossProfitAchievRate9 = (double)0;

            //row.SalesMoney10 = (long)0;
            //row.ReturnedGoodsPrice10 = (long)0;
            //row.DiscountPrice10 = (long)0;
            //row.GenuineSalesMoney10 = (long)0;
            //row.TargetMoney10 = (long)0;
            //row.AchievementRate10 = (double)0;
            //row.GrossProfitMoney10 = (long)0;
            //row.GrossProfitTargetMoney10 = (long)0;
            //row.GrossProfitAchievRate10 = (double)0;

            //row.SalesMoney11 = (long)0;
            //row.ReturnedGoodsPrice11 = (long)0;
            //row.DiscountPrice11 = (long)0;
            //row.GenuineSalesMoney11 = (long)0;
            //row.TargetMoney11 = (long)0;
            //row.AchievementRate11 = (double)0;
            //row.GrossProfitMoney11 = (long)0;
            //row.GrossProfitTargetMoney11 = (long)0;
            //row.GrossProfitAchievRate11 = (double)0;

            //row.StockGenuineSalesMoney = (long)0;
            //row.StockGrossProfitMoney = (long)0;
            //row.StockDummySum = (long)0;

            //row.OrderGenuineSalesMoney = (long)0;
            //row.OrderGrossProfitMoney = (long)0;
            //row.OrderDummySum = (long)0;

            //row.StockDummy = (long)0;
            //row.OrderDummy = (long)0;

            //row.StockDummy1 = (long)0;
            //row.OrderDummy1 = (long)0;

            //row.StockDummy2 = (long)0;
            //row.OrderDummy2 = (long)0;

            //row.StockDummy3 = (long)0;
            //row.OrderDummy3 = (long)0;

            //row.StockDummy4 = (long)0;
            //row.OrderDummy4 = (long)0;

            //row.StockDummy5 = (long)0;
            //row.OrderDummy5 = (long)0;

            //row.StockDummy6 = (long)0;
            //row.OrderDummy6 = (long)0;

            //row.StockDummy7 = (long)0;
            //row.OrderDummy7 = (long)0;

            //row.StockDummy8 = (long)0;
            //row.OrderDummy8 = (long)0;

            //row.StockDummy9 = (long)0;
            //row.OrderDummy9 = (long)0;

            //row.StockDummy10 = (long)0;
            //row.OrderDummy10 = (long)0;

            //row.StockDummy11 = (long)0;
            //row.OrderDummy11 = (long)0;
            //_dataSet.MonthResult.AddMonthResultRow(row);
            // --- DEL 2010/08/02 --------------------------------<<<<<

        }

        /// <summary>
        /// 売上実績照会データ検索結果オブジェクトをデータテーブルにキャッシュします。
        /// </summary>
        /// <param name="data">売上実績照会データ検索結果オブジェクト</param>
        /// <param name="totalDiv">集計区分</param>
        /// <param name="cnt">ループの統計</param>
        /// <remarks>
        /// <br>Note		: 売上実績照会データ検索結果オブジェクトをデータテーブルにキャッシュします。</br>
        /// <br>Programmer	: 徐後継</br>
        /// <br>Date		: 2010/07/20</br>
        /// <br>Update Note: 2010/08/12 chenyd</br>
        /// <br>            ・障害ID:12998 テキスト出力対応</br>
        /// <br>Update Note: 2010/08/18 chenyd</br>
        /// <br>            ・障害ID:13214 テキスト出力対応</br>
        /// <br>Update Note: 2011/03/23 liyp</br>
        /// <br>            ・テキスト出力対応</br>
        /// <br>Update Note: 2015/07/23 河原林 一生</br>
        /// <br>            ・東海自動車工業課題一覧No.4</br>
        /// </remarks>
        private void SalesAnnualCache(SalesAnnualDataSelectResultWork data, int totalDiv, int cnt)
        {

            // --- ADD 2010/08/02 -------------------------------->>>>>
            if (cnt == _dataSet.MonthResult.Rows.Count)
            {
                InventoryUpdateDataSet.MonthResultRow row = _dataSet.MonthResult.NewMonthResultRow();
                row.SectionCode = data.SectionCode;
                row.SectionName = data.SectionName;
                row.SelectionCode = data.SelectionCode;
                // --------ADD 2011/03/23 ----------->>>>>
                if (this._excOrtxtDiv && totalDiv == 1)
                {
                    row.SelectionCode = data.SelectionCode.PadLeft (8,'0');
                }
                if (this._excOrtxtDiv &&  (totalDiv == 5 || totalDiv == 6))
                {
                    row.SelectionCode = data.SelectionCode.PadLeft(4, '0');
                }
                // --------ADD 2011/03/23 -----------<<<<<
                row.SelectionName = data.SelectionName;

                row.SalesMoney = (long)0;
                row.ReturnedGoodsPrice = (long)0;
                row.DiscountPrice = (long)0;
                row.GenuineSalesMoney = (long)0;
                row.TargetMoney = (long)0;
                row.AchievementRate = (double)0;
                row.GrossProfitMoney = (long)0;
                row.GrossProfitTargetMoney = (long)0;
                row.GrossProfitAchievRate = (double)0;

                row.SalesMoney1 = (long)0;
                row.ReturnedGoodsPrice1 = (long)0;
                row.DiscountPrice1 = (long)0;
                row.GenuineSalesMoney1 = (long)0;
                row.TargetMoney1 = (long)0;
                row.AchievementRate1 = (double)0;
                row.GrossProfitMoney1 = (long)0;
                row.GrossProfitTargetMoney1 = (long)0;
                row.GrossProfitAchievRate1 = (double)0;

                row.SalesMoney2 = (long)0;
                row.ReturnedGoodsPrice2 = (long)0;
                row.DiscountPrice2 = (long)0;
                row.GenuineSalesMoney2 = (long)0;
                row.TargetMoney2 = (long)0;
                row.AchievementRate2 = (double)0;
                row.GrossProfitMoney2 = (long)0;
                row.GrossProfitTargetMoney2 = (long)0;
                row.GrossProfitAchievRate2 = (double)0;

                row.SalesMoney3 = (long)0;
                row.ReturnedGoodsPrice3 = (long)0;
                row.DiscountPrice3 = (long)0;
                row.GenuineSalesMoney3 = (long)0;
                row.TargetMoney3 = (long)0;
                row.AchievementRate3 = (double)0;
                row.GrossProfitMoney3 = (long)0;
                row.GrossProfitTargetMoney3 = (long)0;
                row.GrossProfitAchievRate3 = (double)0;

                row.SalesMoney4 = (long)0;
                row.ReturnedGoodsPrice4 = (long)0;
                row.DiscountPrice4 = (long)0;
                row.GenuineSalesMoney4 = (long)0;
                row.TargetMoney4 = (long)0;
                row.AchievementRate4 = (double)0;
                row.GrossProfitMoney4 = (long)0;
                row.GrossProfitTargetMoney4 = (long)0;
                row.GrossProfitAchievRate4 = (double)0;

                row.SalesMoney5 = (long)0;
                row.ReturnedGoodsPrice5 = (long)0;
                row.DiscountPrice5 = (long)0;
                row.GenuineSalesMoney5 = (long)0;
                row.TargetMoney5 = (long)0;
                row.AchievementRate5 = (double)0;
                row.GrossProfitMoney5 = (long)0;
                row.GrossProfitTargetMoney5 = (long)0;
                row.GrossProfitAchievRate5 = (double)0;

                row.SalesMoney6 = (long)0;
                row.ReturnedGoodsPrice6 = (long)0;
                row.DiscountPrice6 = (long)0;
                row.GenuineSalesMoney6 = (long)0;
                row.TargetMoney6 = (long)0;
                row.AchievementRate6 = (double)0;
                row.GrossProfitMoney6 = (long)0;
                row.GrossProfitTargetMoney6 = (long)0;
                row.GrossProfitAchievRate6 = (double)0;

                row.SalesMoney7 = (long)0;
                row.ReturnedGoodsPrice7 = (long)0;
                row.DiscountPrice7 = (long)0;
                row.GenuineSalesMoney7 = (long)0;
                row.TargetMoney7 = (long)0;
                row.AchievementRate7 = (double)0;
                row.GrossProfitMoney7 = (long)0;
                row.GrossProfitTargetMoney7 = (long)0;
                row.GrossProfitAchievRate7 = (double)0;

                row.SalesMoney8 = (long)0;
                row.ReturnedGoodsPrice8 = (long)0;
                row.DiscountPrice8 = (long)0;
                row.GenuineSalesMoney8 = (long)0;
                row.TargetMoney8 = (long)0;
                row.AchievementRate8 = (double)0;
                row.GrossProfitMoney8 = (long)0;
                row.GrossProfitTargetMoney8 = (long)0;
                row.GrossProfitAchievRate8 = (double)0;

                row.SalesMoney9 = (long)0;
                row.ReturnedGoodsPrice9 = (long)0;
                row.DiscountPrice9 = (long)0;
                row.GenuineSalesMoney9 = (long)0;
                row.TargetMoney9 = (long)0;
                row.AchievementRate9 = (double)0;
                row.GrossProfitMoney9 = (long)0;
                row.GrossProfitTargetMoney9 = (long)0;
                row.GrossProfitAchievRate9 = (double)0;

                row.SalesMoney10 = (long)0;
                row.ReturnedGoodsPrice10 = (long)0;
                row.DiscountPrice10 = (long)0;
                row.GenuineSalesMoney10 = (long)0;
                row.TargetMoney10 = (long)0;
                row.AchievementRate10 = (double)0;
                row.GrossProfitMoney10 = (long)0;
                row.GrossProfitTargetMoney10 = (long)0;
                row.GrossProfitAchievRate10 = (double)0;

                row.SalesMoney11 = (long)0;
                row.ReturnedGoodsPrice11 = (long)0;
                row.DiscountPrice11 = (long)0;
                row.GenuineSalesMoney11 = (long)0;
                row.TargetMoney11 = (long)0;
                row.AchievementRate11 = (double)0;
                row.GrossProfitMoney11 = (long)0;
                row.GrossProfitTargetMoney11 = (long)0;
                row.GrossProfitAchievRate11 = (double)0;

                row.StockGenuineSalesMoney = (long)0;
                row.StockGrossProfitMoney = (long)0;
                row.StockDummySum = (long)0;

                row.OrderGenuineSalesMoney = (long)0;
                row.OrderGrossProfitMoney = (long)0;
                row.OrderDummySum = (long)0;

                row.StockDummy = (long)0;
                row.OrderDummy = (long)0;

                row.StockDummy1 = (long)0;
                row.OrderDummy1 = (long)0;

                row.StockDummy2 = (long)0;
                row.OrderDummy2 = (long)0;

                row.StockDummy3 = (long)0;
                row.OrderDummy3 = (long)0;

                row.StockDummy4 = (long)0;
                row.OrderDummy4 = (long)0;

                row.StockDummy5 = (long)0;
                row.OrderDummy5 = (long)0;

                row.StockDummy6 = (long)0;
                row.OrderDummy6 = (long)0;

                row.StockDummy7 = (long)0;
                row.OrderDummy7 = (long)0;

                row.StockDummy8 = (long)0;
                row.OrderDummy8 = (long)0;

                row.StockDummy9 = (long)0;
                row.OrderDummy9 = (long)0;

                row.StockDummy10 = (long)0;
                row.OrderDummy10 = (long)0;

                row.StockDummy11 = (long)0;
                row.OrderDummy11 = (long)0;
                _dataSet.MonthResult.AddMonthResultRow(row);
                DateTime prevTotalDay = DateTime.MinValue;
                DateTime currentTotalDay = DateTime.MinValue;
                if (0 == totalDiv)
                {
                    _totalDayCalculator.GetHisTotalDayDmdC(data.SectionCode, out prevTotalDay, out currentTotalDay);
                }
                else if (1 == totalDiv)
                {
                    //_totalDayCalculator.GetTotalDayMonthlyAccRec(Convert.ToInt16(data.SelectionCode), out prevTotalDay, out currentTotalDay);// DEL 2010/08/12 障害ID:13214対応
                    _totalDayCalculator.GetTotalDayMonthlyAccRec(Convert.ToInt32(data.SelectionCode), out prevTotalDay, out currentTotalDay);  // ADD 2010/08/12 障害ID:13214対応
                }
                //次回月次締日を含む年月度を現在処理中年月とする
                if (prevTotalDay != DateTime.MinValue)
                {
                    DateTime dtYearMonth;
                    _dateGet.GetYearMonth(currentTotalDay, out dtYearMonth);
                    _companyNowDate = Int32.Parse(dtYearMonth.ToString("yyyyMM"));
                }
                // --- ADD 2015/07/23 m.kawarabayashi 東海自動車工業課題一覧No.4 ------------------>>>>>
                else
                {
                    // 前回月次更新年月が無い場合はシステム日付を現在処理年月とする
                    DateTime nowyearMonth = DateTime.MinValue;
                    _dateGet.GetThisYearMonth(out nowyearMonth);
                    _companyNowDate = Int32.Parse(nowyearMonth.ToString("yyyyMM"));
                }
                // --- ADD 2015/07/23 m.kawarabayashi 東海自動車工業課題一覧No.4 ------------------<<<<<
            }
            // --- ADD 2010/08/02 --------------------------------<<<<<

            // 月単位
            int index = 0;
            int companyBiginMonth = this._companyInf.CompanyBiginMonth;
            if ((data.AUPYearMonth % 100 - companyBiginMonth) >= 0)
            {
                index = data.AUPYearMonth % 100 - companyBiginMonth;
            }
            else
            {
                index = (data.AUPYearMonth % 100 - companyBiginMonth) + 12;
            }
            // --- DEl 2010/08/02 -------------------------------->>>>>
            //// 在庫・出荷回数
            //_dataSet.MonthResult[cnt].StockDummySum = 0;
            //// 取寄・出荷回数
            //_dataSet.MonthResult[cnt].OrderDummySum = 0;
            // --- DEl 2010/08/02 --------------------------------<<<<<
            switch (index)
            {
                case 0:
                    {
                        if (data.AUPYearMonth >= _companyBiginDate && data.AUPYearMonth <= _companyNowDate)
                        {
                            if (data.RsltTtlDivCd == 0)
                            {
                                _dataSet.MonthResult[cnt].RowSetFlg = data.AUPYearMonth;

                                // 返品値引の符号を反転させる
                                // 売上金額
                                _dataSet.MonthResult[cnt].SalesMoney = _dataSet.MonthResult[cnt].SalesMoney + data.SalesMoney;
                                _dataSet.MonthResult[cnt].ReturnedGoodsPrice = _dataSet.MonthResult[cnt].ReturnedGoodsPrice - data.SalesRetGoodsPrice;
                                _dataSet.MonthResult[cnt].DiscountPrice = _dataSet.MonthResult[cnt].DiscountPrice - data.DiscountPrice;

                                // 純売上金額
                                _dataSet.MonthResult[cnt].GenuineSalesMoney = _dataSet.MonthResult[cnt].GenuineSalesMoney + data.SalesMoney + data.SalesRetGoodsPrice + data.DiscountPrice;
                                _dataSet.MonthResult[cnt].TargetMoney = data.SalesTargetMoney;

                                // 粗利
                                _dataSet.MonthResult[cnt].GrossProfitMoney = _dataSet.MonthResult[cnt].GrossProfitMoney + data.GrossProfit;
                                _dataSet.MonthResult[cnt].GrossProfitTargetMoney = data.SalesTargetProfit;
                                _dataSet.MonthResult[cnt].OrderDummy = _dataSet.MonthResult[cnt].OrderDummy + data.SalesTimes;
                            }
                            // 出荷回数
                            if (data.RsltTtlDivCd == 1)
                            {
                                _dataSet.MonthResult[cnt].StockDummy = _dataSet.MonthResult[cnt].StockDummy + data.SalesTimes;
                                _dataSet.MonthResult[cnt].OrderDummy = _dataSet.MonthResult[cnt].OrderDummy - data.SalesTimes;

                            }
                            // --- DEl 2010/08/02 -------------------------------->>>>>
                            //_dataSet.MonthResult[cnt].StockDummySum = _dataSet.MonthResult[cnt].StockDummySum + _dataSet.MonthResult[cnt].StockDummy;
                            //_dataSet.MonthResult[cnt].OrderDummySum = _dataSet.MonthResult[cnt].OrderDummySum + _dataSet.MonthResult[cnt].OrderDummy;
                            // --- DEl 2010/08/02 --------------------------------<<<<<
                        }
                        break;
                    }
                case 1:
                    {
                        if (data.AUPYearMonth >= _companyBiginDate && data.AUPYearMonth <= _companyNowDate)
                        {
                            if (data.RsltTtlDivCd == 0)
                            {
                                _dataSet.MonthResult[cnt].RowSetFlg = data.AUPYearMonth;

                                // 返品値引の符号を反転させる
                                // 売上金額
                                _dataSet.MonthResult[cnt].SalesMoney1 = _dataSet.MonthResult[cnt].SalesMoney1 + data.SalesMoney;
                                _dataSet.MonthResult[cnt].ReturnedGoodsPrice1 = _dataSet.MonthResult[cnt].ReturnedGoodsPrice1 - data.SalesRetGoodsPrice;
                                _dataSet.MonthResult[cnt].DiscountPrice1 = _dataSet.MonthResult[cnt].DiscountPrice1 - data.DiscountPrice;

                                // 純売上金額
                                _dataSet.MonthResult[cnt].GenuineSalesMoney1 = _dataSet.MonthResult[cnt].GenuineSalesMoney1 + data.SalesMoney + data.SalesRetGoodsPrice + data.DiscountPrice;
                                _dataSet.MonthResult[cnt].TargetMoney1 = data.SalesTargetMoney;

                                // 粗利
                                _dataSet.MonthResult[cnt].GrossProfitMoney1 = _dataSet.MonthResult[cnt].GrossProfitMoney1 + data.GrossProfit;
                                _dataSet.MonthResult[cnt].GrossProfitTargetMoney1 = data.SalesTargetProfit;
                                _dataSet.MonthResult[cnt].OrderDummy1 = _dataSet.MonthResult[cnt].OrderDummy1 + data.SalesTimes;
                            }
                            // 出荷回数
                            if (data.RsltTtlDivCd == 1)
                            {
                                _dataSet.MonthResult[cnt].StockDummy1 = _dataSet.MonthResult[cnt].StockDummy1 + data.SalesTimes;
                                _dataSet.MonthResult[cnt].OrderDummy1 = _dataSet.MonthResult[cnt].OrderDummy1 - data.SalesTimes;
                            }
                            // --- DEl 2010/08/02 -------------------------------->>>>>
                                //_dataSet.MonthResult[cnt].StockDummySum = _dataSet.MonthResult[cnt].StockDummySum + _dataSet.MonthResult[cnt].StockDummy1;
                                //_dataSet.MonthResult[cnt].OrderDummySum = _dataSet.MonthResult[cnt].OrderDummySum + _dataSet.MonthResult[cnt].OrderDummy1;
                            // --- DEl 2010/08/02 --------------------------------<<<<<
                        }
                        break;
                    }
                case 2:
                    {
                        if (data.AUPYearMonth >= _companyBiginDate && data.AUPYearMonth <= _companyNowDate)
                        {
                            if (data.RsltTtlDivCd == 0)
                            {
                                _dataSet.MonthResult[cnt].RowSetFlg = data.AUPYearMonth;

                                // 返品値引の符号を反転させる
                                // 売上金額
                                _dataSet.MonthResult[cnt].SalesMoney2 = _dataSet.MonthResult[cnt].SalesMoney2 + data.SalesMoney;
                                _dataSet.MonthResult[cnt].ReturnedGoodsPrice2 = _dataSet.MonthResult[cnt].ReturnedGoodsPrice2 - data.SalesRetGoodsPrice;
                                _dataSet.MonthResult[cnt].DiscountPrice2 = _dataSet.MonthResult[cnt].DiscountPrice2 - data.DiscountPrice;

                                // 純売上金額
                                _dataSet.MonthResult[cnt].GenuineSalesMoney2 = _dataSet.MonthResult[cnt].GenuineSalesMoney2 + data.SalesMoney + data.SalesRetGoodsPrice + data.DiscountPrice;
                                _dataSet.MonthResult[cnt].TargetMoney2 = data.SalesTargetMoney;

                                // 粗利
                                _dataSet.MonthResult[cnt].GrossProfitMoney2 = _dataSet.MonthResult[cnt].GrossProfitMoney2 + data.GrossProfit;
                                _dataSet.MonthResult[cnt].GrossProfitTargetMoney2 = data.SalesTargetProfit;
                                _dataSet.MonthResult[cnt].OrderDummy2 = _dataSet.MonthResult[cnt].OrderDummy2 + data.SalesTimes;
                            }
                            // 出荷回数
                            if (data.RsltTtlDivCd == 1)
                            {
                                _dataSet.MonthResult[cnt].StockDummy2 = _dataSet.MonthResult[cnt].StockDummy2 + data.SalesTimes;
                                _dataSet.MonthResult[cnt].OrderDummy2 = _dataSet.MonthResult[cnt].OrderDummy2 - data.SalesTimes;
                            }
                            // --- DEl 2010/08/02 -------------------------------->>>>>
                            //_dataSet.MonthResult[cnt].StockDummySum = _dataSet.MonthResult[cnt].StockDummySum + _dataSet.MonthResult[cnt].StockDummy2;
                            //_dataSet.MonthResult[cnt].OrderDummySum = _dataSet.MonthResult[cnt].OrderDummySum + _dataSet.MonthResult[cnt].OrderDummy2;
                            // --- DEl 2010/08/02 --------------------------------<<<<<
                        }
                        break;
                    }
                case 3:
                    {
                        if (data.AUPYearMonth >= _companyBiginDate && data.AUPYearMonth <= _companyNowDate)
                        {
                            if (data.RsltTtlDivCd == 0)
                            {
                                _dataSet.MonthResult[cnt].RowSetFlg = data.AUPYearMonth;

                                // 返品値引の符号を反転させる
                                // 売上金額
                                _dataSet.MonthResult[cnt].SalesMoney3 = _dataSet.MonthResult[cnt].SalesMoney3 + data.SalesMoney;
                                _dataSet.MonthResult[cnt].ReturnedGoodsPrice3 = _dataSet.MonthResult[cnt].ReturnedGoodsPrice3 - data.SalesRetGoodsPrice;
                                _dataSet.MonthResult[cnt].DiscountPrice3 = _dataSet.MonthResult[cnt].DiscountPrice3 - data.DiscountPrice;

                                // 純売上金額
                                _dataSet.MonthResult[cnt].GenuineSalesMoney3 = _dataSet.MonthResult[cnt].GenuineSalesMoney3 + data.SalesMoney + data.SalesRetGoodsPrice + data.DiscountPrice;
                                _dataSet.MonthResult[cnt].TargetMoney3 = data.SalesTargetMoney;

                                // 粗利
                                _dataSet.MonthResult[cnt].GrossProfitMoney3 = _dataSet.MonthResult[cnt].GrossProfitMoney3 + data.GrossProfit;
                                _dataSet.MonthResult[cnt].GrossProfitTargetMoney3 = data.SalesTargetProfit;
                                _dataSet.MonthResult[cnt].OrderDummy3 = _dataSet.MonthResult[cnt].OrderDummy3 + data.SalesTimes;
                            }
                            // 出荷回数
                            if (data.RsltTtlDivCd == 1)
                            {
                                _dataSet.MonthResult[cnt].StockDummy3 = _dataSet.MonthResult[cnt].StockDummy3 + data.SalesTimes;
                                _dataSet.MonthResult[cnt].OrderDummy3 = _dataSet.MonthResult[cnt].OrderDummy3 - data.SalesTimes;
                            }
                            // --- DEl 2010/08/02 -------------------------------->>>>>
                            //_dataSet.MonthResult[cnt].StockDummySum = _dataSet.MonthResult[cnt].StockDummySum + _dataSet.MonthResult[cnt].StockDummy3;
                            //_dataSet.MonthResult[cnt].OrderDummySum = _dataSet.MonthResult[cnt].OrderDummySum + _dataSet.MonthResult[cnt].OrderDummy3;
                            // --- DEl 2010/08/02 --------------------------------<<<<<
                        }
                        break;
                    }
                case 4:
                    {
                        if (data.AUPYearMonth >= _companyBiginDate && data.AUPYearMonth <= _companyNowDate)
                        {
                            if (data.RsltTtlDivCd == 0)
                            {
                                _dataSet.MonthResult[cnt].RowSetFlg = data.AUPYearMonth;

                                // 返品値引の符号を反転させる
                                // 売上金額
                                _dataSet.MonthResult[cnt].SalesMoney4 = _dataSet.MonthResult[cnt].SalesMoney4 + data.SalesMoney;
                                _dataSet.MonthResult[cnt].ReturnedGoodsPrice4 = _dataSet.MonthResult[cnt].ReturnedGoodsPrice4 - data.SalesRetGoodsPrice;
                                _dataSet.MonthResult[cnt].DiscountPrice4 = _dataSet.MonthResult[cnt].DiscountPrice4 - data.DiscountPrice;

                                // 純売上金額
                                _dataSet.MonthResult[cnt].GenuineSalesMoney4 = _dataSet.MonthResult[cnt].GenuineSalesMoney4 + data.SalesMoney + data.SalesRetGoodsPrice + data.DiscountPrice;
                                _dataSet.MonthResult[cnt].TargetMoney4 = data.SalesTargetMoney;

                                // 粗利
                                _dataSet.MonthResult[cnt].GrossProfitMoney4 = _dataSet.MonthResult[cnt].GrossProfitMoney4 + data.GrossProfit;
                                _dataSet.MonthResult[cnt].GrossProfitTargetMoney4 = data.SalesTargetProfit;
                                _dataSet.MonthResult[cnt].OrderDummy4 = _dataSet.MonthResult[cnt].OrderDummy4 + data.SalesTimes;
                            }
                            // 出荷回数
                            if (data.RsltTtlDivCd == 1)
                            {
                                // --- DEL 2010/08/12 障害ID:12998対応-------------------------------->>>>>
                                //_dataSet.MonthResult[cnt].StockDummy4 = _dataSet.MonthResult[cnt].StockDummy + data.SalesTimes;
                                //_dataSet.MonthResult[cnt].OrderDummy4 = _dataSet.MonthResult[cnt].OrderDummy - data.SalesTimes;
                                // --- DEL 2010/08/12 障害ID:12998対応--------------------------------<<<<<
                                // --- ADD 2010/08/12 障害ID:12998対応-------------------------------->>>>>
                                _dataSet.MonthResult[cnt].StockDummy4 = _dataSet.MonthResult[cnt].StockDummy4 + data.SalesTimes;
                                _dataSet.MonthResult[cnt].OrderDummy4 = _dataSet.MonthResult[cnt].OrderDummy4 - data.SalesTimes;
                                // --- ADD 2010/08/12 障害ID:12998対応--------------------------------<<<<<
                            }
                            // --- DEl 2010/08/02 -------------------------------->>>>>
                            //_dataSet.MonthResult[cnt].StockDummySum = _dataSet.MonthResult[cnt].StockDummySum + _dataSet.MonthResult[cnt].StockDummy4;
                            //_dataSet.MonthResult[cnt].OrderDummySum = _dataSet.MonthResult[cnt].OrderDummySum + _dataSet.MonthResult[cnt].OrderDummy4;
                            // --- DEl 2010/08/02 --------------------------------<<<<<
                        }
                        break;
                    }
                case 5:
                    {
                        if (data.AUPYearMonth >= _companyBiginDate && data.AUPYearMonth <= _companyNowDate)
                        {
                            if (data.RsltTtlDivCd == 0)
                            {
                                _dataSet.MonthResult[cnt].RowSetFlg = data.AUPYearMonth;

                                // 返品値引の符号を反転させる
                                // 売上金額
                                _dataSet.MonthResult[cnt].SalesMoney5 = _dataSet.MonthResult[cnt].SalesMoney5 + data.SalesMoney;
                                _dataSet.MonthResult[cnt].ReturnedGoodsPrice5 = _dataSet.MonthResult[cnt].ReturnedGoodsPrice5 - data.SalesRetGoodsPrice;
                                _dataSet.MonthResult[cnt].DiscountPrice5 = _dataSet.MonthResult[cnt].DiscountPrice5 - data.DiscountPrice;

                                // 純売上金額
                                _dataSet.MonthResult[cnt].GenuineSalesMoney5 = _dataSet.MonthResult[cnt].GenuineSalesMoney5 + data.SalesMoney + data.SalesRetGoodsPrice + data.DiscountPrice;
                                _dataSet.MonthResult[cnt].TargetMoney5 = data.SalesTargetMoney;

                                // 粗利
                                _dataSet.MonthResult[cnt].GrossProfitMoney5 = _dataSet.MonthResult[cnt].GrossProfitMoney5 + data.GrossProfit;
                                _dataSet.MonthResult[cnt].GrossProfitTargetMoney5 = data.SalesTargetProfit;
                                _dataSet.MonthResult[cnt].OrderDummy5 = _dataSet.MonthResult[cnt].OrderDummy5 + data.SalesTimes;
                            }
                            // 出荷回数
                            if (data.RsltTtlDivCd == 1)
                            {
                                _dataSet.MonthResult[cnt].StockDummy5 = _dataSet.MonthResult[cnt].StockDummy5 + data.SalesTimes;
                                _dataSet.MonthResult[cnt].OrderDummy5 = _dataSet.MonthResult[cnt].OrderDummy5 - data.SalesTimes;
                            }
                            // --- DEl 2010/08/02 -------------------------------->>>>>
                            //_dataSet.MonthResult[cnt].StockDummySum = _dataSet.MonthResult[cnt].StockDummySum + _dataSet.MonthResult[cnt].StockDummy5;
                            //_dataSet.MonthResult[cnt].OrderDummySum = _dataSet.MonthResult[cnt].OrderDummySum + _dataSet.MonthResult[cnt].OrderDummy5;
                            // --- DEl 2010/08/02 --------------------------------<<<<<
                        }
                        break;
                    }
                case 6:
                    {
                        if (data.AUPYearMonth >= _companyBiginDate && data.AUPYearMonth <= _companyNowDate)
                        {
                            if (data.RsltTtlDivCd == 0)
                            {
                                _dataSet.MonthResult[cnt].RowSetFlg = data.AUPYearMonth;

                                // 返品値引の符号を反転させる
                                // 売上金額
                                _dataSet.MonthResult[cnt].SalesMoney6 = _dataSet.MonthResult[cnt].SalesMoney6 + data.SalesMoney;
                                _dataSet.MonthResult[cnt].ReturnedGoodsPrice6 = _dataSet.MonthResult[cnt].ReturnedGoodsPrice6 - data.SalesRetGoodsPrice;
                                _dataSet.MonthResult[cnt].DiscountPrice6 = _dataSet.MonthResult[cnt].DiscountPrice6 - data.DiscountPrice;

                                // 純売上金額
                                _dataSet.MonthResult[cnt].GenuineSalesMoney6 = _dataSet.MonthResult[cnt].GenuineSalesMoney6 + data.SalesMoney + data.SalesRetGoodsPrice + data.DiscountPrice;
                                _dataSet.MonthResult[cnt].TargetMoney6 = data.SalesTargetMoney;

                                // 粗利
                                _dataSet.MonthResult[cnt].GrossProfitMoney6 = _dataSet.MonthResult[cnt].GrossProfitMoney6 + data.GrossProfit;
                                _dataSet.MonthResult[cnt].GrossProfitTargetMoney6 = data.SalesTargetProfit;
                                _dataSet.MonthResult[cnt].OrderDummy6 = _dataSet.MonthResult[cnt].OrderDummy6 + data.SalesTimes;
                            }
                            // 出荷回数
                            if (data.RsltTtlDivCd == 1)
                            {
                                _dataSet.MonthResult[cnt].StockDummy6 = _dataSet.MonthResult[cnt].StockDummy6 + data.SalesTimes;
                                _dataSet.MonthResult[cnt].OrderDummy6 = _dataSet.MonthResult[cnt].OrderDummy6 - data.SalesTimes;
                            }
                            // --- DEl 2010/08/02 -------------------------------->>>>>
                            //_dataSet.MonthResult[cnt].StockDummySum = _dataSet.MonthResult[cnt].StockDummySum + _dataSet.MonthResult[cnt].StockDummy6;
                            //_dataSet.MonthResult[cnt].OrderDummySum = _dataSet.MonthResult[cnt].OrderDummySum + _dataSet.MonthResult[cnt].OrderDummy6;
                            // --- DEl 2010/08/02 --------------------------------<<<<<
                        }
                        break;
                    }
                case 7:
                    {
                        if (data.AUPYearMonth >= _companyBiginDate && data.AUPYearMonth <= _companyNowDate)
                        {
                            if (data.RsltTtlDivCd == 0)
                            {
                                _dataSet.MonthResult[cnt].RowSetFlg = data.AUPYearMonth;

                                // 返品値引の符号を反転させる
                                // 売上金額
                                _dataSet.MonthResult[cnt].SalesMoney7 = _dataSet.MonthResult[cnt].SalesMoney7 + data.SalesMoney;
                                _dataSet.MonthResult[cnt].ReturnedGoodsPrice7 = _dataSet.MonthResult[cnt].ReturnedGoodsPrice7 - data.SalesRetGoodsPrice;
                                _dataSet.MonthResult[cnt].DiscountPrice7 = _dataSet.MonthResult[cnt].DiscountPrice7 - data.DiscountPrice;

                                // 純売上金額
                                _dataSet.MonthResult[cnt].GenuineSalesMoney7 = _dataSet.MonthResult[cnt].GenuineSalesMoney7 + data.SalesMoney + data.SalesRetGoodsPrice + data.DiscountPrice;
                                _dataSet.MonthResult[cnt].TargetMoney7 = data.SalesTargetMoney;

                                //粗利 
                                _dataSet.MonthResult[cnt].GrossProfitMoney7 = _dataSet.MonthResult[cnt].GrossProfitMoney7 + data.GrossProfit;
                                _dataSet.MonthResult[cnt].GrossProfitTargetMoney7 = data.SalesTargetProfit;

                                _dataSet.MonthResult[cnt].OrderDummy7 = _dataSet.MonthResult[cnt].OrderDummy7 + data.SalesTimes;
                            }
                            // 出荷回数
                            if (data.RsltTtlDivCd == 1)
                            {
                                _dataSet.MonthResult[cnt].StockDummy7 = _dataSet.MonthResult[cnt].StockDummy7 + data.SalesTimes;
                                _dataSet.MonthResult[cnt].OrderDummy7 = _dataSet.MonthResult[cnt].OrderDummy7 - data.SalesTimes;
                            }
                            // --- DEl 2010/08/02 -------------------------------->>>>>
                            //_dataSet.MonthResult[cnt].StockDummySum = _dataSet.MonthResult[cnt].StockDummySum + _dataSet.MonthResult[cnt].StockDummy7;
                            //_dataSet.MonthResult[cnt].OrderDummySum = _dataSet.MonthResult[cnt].OrderDummySum + _dataSet.MonthResult[cnt].OrderDummy7;
                            // --- DEl 2010/08/02 --------------------------------<<<<<
                        }
                        break;
                    }
                case 8:
                    {
                        if (data.AUPYearMonth >= _companyBiginDate && data.AUPYearMonth <= _companyNowDate)
                        {
                            if (data.RsltTtlDivCd == 0)
                            {
                                _dataSet.MonthResult[cnt].RowSetFlg = data.AUPYearMonth;

                                // 返品値引の符号を反転させる
                                // 売上金額
                                _dataSet.MonthResult[cnt].SalesMoney8 = _dataSet.MonthResult[cnt].SalesMoney8 + data.SalesMoney;
                                _dataSet.MonthResult[cnt].ReturnedGoodsPrice8 = _dataSet.MonthResult[cnt].ReturnedGoodsPrice8 - data.SalesRetGoodsPrice;
                                _dataSet.MonthResult[cnt].DiscountPrice8 = _dataSet.MonthResult[cnt].DiscountPrice8 - data.DiscountPrice;

                                // 純売上金額
                                _dataSet.MonthResult[cnt].GenuineSalesMoney8 = _dataSet.MonthResult[cnt].GenuineSalesMoney8 + data.SalesMoney + data.SalesRetGoodsPrice + data.DiscountPrice;
                                _dataSet.MonthResult[cnt].TargetMoney8 = data.SalesTargetMoney;

                                // 粗利
                                _dataSet.MonthResult[cnt].GrossProfitMoney8 = _dataSet.MonthResult[cnt].GrossProfitMoney8 + data.GrossProfit;
                                _dataSet.MonthResult[cnt].GrossProfitTargetMoney8 = data.SalesTargetProfit;
                                _dataSet.MonthResult[cnt].OrderDummy8 = _dataSet.MonthResult[cnt].OrderDummy8 + data.SalesTimes;
                            }
                            // 出荷回数
                            //if (data.AUPYearMonth >= _companyBiginDate && data.AUPYearMonth <= _companyNowDate) // DEL 2010/08/02
                            if (data.RsltTtlDivCd == 1) // ADD 2010/08/02
                            {
                                _dataSet.MonthResult[cnt].StockDummy8 = _dataSet.MonthResult[cnt].StockDummy8 + data.SalesTimes;
                                _dataSet.MonthResult[cnt].OrderDummy8 = _dataSet.MonthResult[cnt].OrderDummy8 - data.SalesTimes;
                            }
                            // --- DEl 2010/08/02 -------------------------------->>>>>
                            //_dataSet.MonthResult[cnt].StockDummySum = _dataSet.MonthResult[cnt].StockDummySum + _dataSet.MonthResult[cnt].StockDummy8;
                            //_dataSet.MonthResult[cnt].OrderDummySum = _dataSet.MonthResult[cnt].OrderDummySum + _dataSet.MonthResult[cnt].OrderDummy8;
                            // --- DEl 2010/08/02 --------------------------------<<<<<
                        }
                        break;
                    }
                case 9:
                    {
                        if (data.AUPYearMonth >= _companyBiginDate && data.AUPYearMonth <= _companyNowDate)
                        {
                            if (data.RsltTtlDivCd == 0)
                            {
                                _dataSet.MonthResult[cnt].RowSetFlg = data.AUPYearMonth;

                                // 返品値引の符号を反転させる
                                // 売上金額
                                _dataSet.MonthResult[cnt].SalesMoney9 = _dataSet.MonthResult[cnt].SalesMoney9 + data.SalesMoney;
                                _dataSet.MonthResult[cnt].ReturnedGoodsPrice9 = _dataSet.MonthResult[cnt].ReturnedGoodsPrice9 - data.SalesRetGoodsPrice;
                                _dataSet.MonthResult[cnt].DiscountPrice9 = _dataSet.MonthResult[cnt].DiscountPrice9 - data.DiscountPrice;

                                // 純売上金額
                                _dataSet.MonthResult[cnt].GenuineSalesMoney9 = _dataSet.MonthResult[cnt].GenuineSalesMoney9 + data.SalesMoney + data.SalesRetGoodsPrice + data.DiscountPrice;
                                _dataSet.MonthResult[cnt].TargetMoney9 = data.SalesTargetMoney;

                                // 粗利
                                _dataSet.MonthResult[cnt].GrossProfitMoney9 = _dataSet.MonthResult[cnt].GrossProfitMoney9 + data.GrossProfit;
                                _dataSet.MonthResult[cnt].GrossProfitTargetMoney9 = data.SalesTargetProfit;
                                _dataSet.MonthResult[cnt].OrderDummy9 = _dataSet.MonthResult[cnt].OrderDummy9 + data.SalesTimes;
                            }
                            // 出荷回数
                            if (data.RsltTtlDivCd == 1)
                            {
                                _dataSet.MonthResult[cnt].StockDummy9 = _dataSet.MonthResult[cnt].StockDummy9 + data.SalesTimes;
                                _dataSet.MonthResult[cnt].OrderDummy9 = _dataSet.MonthResult[cnt].OrderDummy9 - data.SalesTimes;
                            }
                            // --- DEl 2010/08/02 -------------------------------->>>>>
                            //_dataSet.MonthResult[cnt].StockDummySum = _dataSet.MonthResult[cnt].StockDummySum + _dataSet.MonthResult[cnt].StockDummy9;
                            //_dataSet.MonthResult[cnt].OrderDummySum = _dataSet.MonthResult[cnt].OrderDummySum + _dataSet.MonthResult[cnt].OrderDummy9;
                            // --- DEl 2010/08/02 --------------------------------<<<<<
                        }
                        break;
                    }
                case 10:
                    {
                        if (data.AUPYearMonth >= _companyBiginDate && data.AUPYearMonth <= _companyNowDate)
                        {
                            if (data.RsltTtlDivCd == 0)
                            {
                                _dataSet.MonthResult[cnt].RowSetFlg = data.AUPYearMonth;

                                // 返品値引の符号を反転させる
                                // 売上金額
                                _dataSet.MonthResult[cnt].SalesMoney10 = _dataSet.MonthResult[cnt].SalesMoney10 + data.SalesMoney;
                                _dataSet.MonthResult[cnt].ReturnedGoodsPrice10 = _dataSet.MonthResult[cnt].ReturnedGoodsPrice10 - data.SalesRetGoodsPrice;
                                _dataSet.MonthResult[cnt].DiscountPrice10 = _dataSet.MonthResult[cnt].DiscountPrice10 - data.DiscountPrice;

                                // 純売上金額
                                _dataSet.MonthResult[cnt].GenuineSalesMoney10 = _dataSet.MonthResult[cnt].GenuineSalesMoney10 + data.SalesMoney + data.SalesRetGoodsPrice + data.DiscountPrice;
                                _dataSet.MonthResult[cnt].TargetMoney10 = data.SalesTargetMoney;

                                // 粗利
                                _dataSet.MonthResult[cnt].GrossProfitMoney10 = _dataSet.MonthResult[cnt].GrossProfitMoney10 + data.GrossProfit;
                                _dataSet.MonthResult[cnt].GrossProfitTargetMoney10 = data.SalesTargetProfit;

                                _dataSet.MonthResult[cnt].OrderDummy10 = _dataSet.MonthResult[cnt].OrderDummy10 + data.SalesTimes;
                            }
                            // 出荷回数
                            if (data.RsltTtlDivCd == 1)
                            {
                                _dataSet.MonthResult[cnt].StockDummy10 = _dataSet.MonthResult[cnt].StockDummy10 + data.SalesTimes;
                                _dataSet.MonthResult[cnt].OrderDummy10 = _dataSet.MonthResult[cnt].OrderDummy10 - data.SalesTimes;
                            }
                            // --- DEl 2010/08/02 -------------------------------->>>>>
                            //_dataSet.MonthResult[cnt].StockDummySum = _dataSet.MonthResult[cnt].StockDummySum + _dataSet.MonthResult[cnt].StockDummy10;
                            //_dataSet.MonthResult[cnt].OrderDummySum = _dataSet.MonthResult[cnt].OrderDummySum + _dataSet.MonthResult[cnt].OrderDummy10;
                            // --- DEl 2010/08/02 --------------------------------<<<<<
                        }
                        break;
                    }
                case 11:
                    {
                        if (data.AUPYearMonth >= _companyBiginDate && data.AUPYearMonth <= _companyNowDate)
                        {
                            if (data.RsltTtlDivCd == 0)
                            {
                                _dataSet.MonthResult[cnt].RowSetFlg = data.AUPYearMonth;

                                // 返品値引の符号を反転させる
                                // 売上金額
                                _dataSet.MonthResult[cnt].SalesMoney11 = _dataSet.MonthResult[cnt].SalesMoney11 + data.SalesMoney;
                                _dataSet.MonthResult[cnt].ReturnedGoodsPrice11 = _dataSet.MonthResult[cnt].ReturnedGoodsPrice11 - data.SalesRetGoodsPrice;
                                _dataSet.MonthResult[cnt].DiscountPrice11 = _dataSet.MonthResult[cnt].DiscountPrice11 - data.DiscountPrice;

                                // 純売上金額
                                _dataSet.MonthResult[cnt].GenuineSalesMoney11 = _dataSet.MonthResult[cnt].GenuineSalesMoney11 + data.SalesMoney + data.SalesRetGoodsPrice + data.DiscountPrice;
                                _dataSet.MonthResult[cnt].TargetMoney11 = data.SalesTargetMoney;

                                // 粗利
                                _dataSet.MonthResult[cnt].GrossProfitMoney11 = _dataSet.MonthResult[cnt].GrossProfitMoney11 + data.GrossProfit;
                                _dataSet.MonthResult[cnt].GrossProfitTargetMoney11 = data.SalesTargetProfit;
                                _dataSet.MonthResult[cnt].OrderDummy11 = _dataSet.MonthResult[cnt].OrderDummy11 + data.SalesTimes;
                            }
                            // 出荷回数
                            if (data.RsltTtlDivCd == 1)
                            {
                                _dataSet.MonthResult[cnt].StockDummy11 = _dataSet.MonthResult[cnt].StockDummy11 + data.SalesTimes;
                                _dataSet.MonthResult[cnt].OrderDummy11 = _dataSet.MonthResult[cnt].OrderDummy11 - data.SalesTimes;
                            }
                            // --- DEl 2010/08/02 -------------------------------->>>>>
                            //_dataSet.MonthResult[cnt].StockDummySum = _dataSet.MonthResult[cnt].StockDummySum + _dataSet.MonthResult[cnt].StockDummy11;
                            //_dataSet.MonthResult[cnt].OrderDummySum = _dataSet.MonthResult[cnt].OrderDummySum + _dataSet.MonthResult[cnt].OrderDummy11;
                            // --- DEl 2010/08/02 --------------------------------<<<<<
                        }
                        break;
                    }
            }

            // 在庫・取寄
            if (data.AUPYearMonth >= _companyBiginDate &&
                data.AUPYearMonth <= _companyNowDate)
            {
                // --- DEl 2010/08/02 -------------------------------->>>>>
                //// 在庫
                //this.SetRowFromUIData_MonStock(0, data, cnt);
                //// 取寄
                //this.SetRowFromUIData_MonStock(1, data, cnt);
                // --- DEl 2010/08/02 --------------------------------<<<<<
                // --- ADD 2010/08/02 -------------------------------->>>>>
                // 得意先
                if (totalDiv == 1)
                {
                    // 合計 - 在庫
                    this.SetRowFromUIData_MonStock(2, data, cnt);
                    // 合計 - 取寄
                    this.SetRowFromUIData_MonStock(3, data, cnt);
                }
                else
                {
                    // 在庫
                    this.SetRowFromUIData_MonStock(0, data, cnt);
                    // 取寄
                    this.SetRowFromUIData_MonStock(1, data, cnt);

                }
                // --- ADD 2010/08/02 --------------------------------<<<<<
            }
        }

        /// <summary>
        /// 売上実績照会データ検索結果ワーク→売上実績照会データ行クラス設定処理（在庫）
        /// </summary>
        /// <param name="ix">売上実績照会データ行番号</param>
        /// <param name="data">売上実績照会データ検索結果ワークオブジェクト</param>
        /// <param name="cnt">ループの統計</param>
        /// <remarks>
        /// <br>Note		: 売上実績照会データ検索結果ワーク→売上実績照会データ行クラス設定処理（在庫）します。</br>
        /// <br>Programmer	: 徐後継</br>
        /// <br>Date		: 2010/07/20</br>
        /// </remarks>
        private void SetRowFromUIData_MonStock(int ix, SalesAnnualDataSelectResultWork data, int cnt)
        {
            switch (ix)
            {
                case 0:
                    // 在庫
                    if (data.RsltTtlDivCd == 1)
                    {
                        // 純売上金額
                        _dataSet.MonthResult[cnt].StockGenuineSalesMoney = _dataSet.MonthResult[cnt].StockGenuineSalesMoney + data.SalesMoney + data.SalesRetGoodsPrice + data.DiscountPrice;

                        // 粗利金額
                        _dataSet.MonthResult[cnt].StockGrossProfitMoney = _dataSet.MonthResult[cnt].StockGrossProfitMoney + data.GrossProfit;
                    }
                    break;
                case 1:
                    //　取寄
                    if (data.RsltTtlDivCd == 1)
                    {
                        // 純売上金額
                        _dataSet.MonthResult[cnt].OrderGenuineSalesMoney = _dataSet.MonthResult[cnt].OrderGenuineSalesMoney - (data.SalesMoney + data.SalesRetGoodsPrice + data.DiscountPrice);

                        // 粗利金額
                        _dataSet.MonthResult[cnt].OrderGrossProfitMoney = _dataSet.MonthResult[cnt].OrderGrossProfitMoney - data.GrossProfit;
                    }
                    else if (data.RsltTtlDivCd == 0)
                    {
                        // 純売上金額
                        _dataSet.MonthResult[cnt].OrderGenuineSalesMoney = _dataSet.MonthResult[cnt].OrderGenuineSalesMoney + data.SalesMoney + data.SalesRetGoodsPrice + data.DiscountPrice;

                        // 粗利金額
                        _dataSet.MonthResult[cnt].OrderGrossProfitMoney = _dataSet.MonthResult[cnt].OrderGrossProfitMoney + data.GrossProfit;
                    }
                    break;
                // --- ADD 2010/08/02 -------------------------------->>>>>
                case 2:
                    // 在庫
                    if (data.SalesOrderDivCd == 1)
                    {
                        // 純売上金額
                        _dataSet.MonthResult[cnt].StockGenuineSalesMoney = _dataSet.MonthResult[cnt].StockGenuineSalesMoney + data.SalesMoney + data.SalesRetGoodsPrice + data.DiscountPrice;

                        // 粗利金額
                        _dataSet.MonthResult[cnt].StockGrossProfitMoney = _dataSet.MonthResult[cnt].StockGrossProfitMoney + data.GrossProfit;
                    }
                    break;
                case 3:
                    // 在庫
                    if (data.SalesOrderDivCd == 0)
                    {
                        // 純売上金額
                        _dataSet.MonthResult[cnt].OrderGenuineSalesMoney = _dataSet.MonthResult[cnt].OrderGenuineSalesMoney + data.SalesMoney + data.SalesRetGoodsPrice + data.DiscountPrice;

                        // 粗利金額
                        _dataSet.MonthResult[cnt].OrderGrossProfitMoney = _dataSet.MonthResult[cnt].OrderGrossProfitMoney + data.GrossProfit;
                    }
                    break;

                // --- ADD 2010/08/02 --------------------------------<<<<<
            }
        }

        /// <summary>
        /// 売上実績照会データ行クラス設定処理（合計/平均）
        /// </summary>
        /// <param name="cnt">売上実績照会データ合計行番号</param>
        /// <remarks>
        /// <br>Note		: 売上実績照会データ行クラス設定処理（合計/平均）します。</br>
        /// <br>Programmer	: 徐後継</br>
        /// <br>Date		: 2010/07/20</br>
        /// </remarks>
        private void SetSalesAnnualResultRowFromUIData_Average(int cnt)
        {
            // --- ADD 2010/08/02 -------------------------------->>>>>
            _dataSet.MonthResult[cnt].StockDummySum = _dataSet.MonthResult[cnt].StockDummy1 + _dataSet.MonthResult[cnt].StockDummy2 +
                _dataSet.MonthResult[cnt].StockDummy3 + _dataSet.MonthResult[cnt].StockDummy4 +
                _dataSet.MonthResult[cnt].StockDummy5 + _dataSet.MonthResult[cnt].StockDummy6 +
                _dataSet.MonthResult[cnt].StockDummy7 + _dataSet.MonthResult[cnt].StockDummy8 +
                _dataSet.MonthResult[cnt].StockDummy9 + _dataSet.MonthResult[cnt].StockDummy10 +
                _dataSet.MonthResult[cnt].StockDummy11 + _dataSet.MonthResult[cnt].StockDummy;
            _dataSet.MonthResult[cnt].OrderDummySum = _dataSet.MonthResult[cnt].OrderDummy + _dataSet.MonthResult[cnt].OrderDummy1 +
                _dataSet.MonthResult[cnt].OrderDummy2 + _dataSet.MonthResult[cnt].OrderDummy3 +
                _dataSet.MonthResult[cnt].OrderDummy4 + _dataSet.MonthResult[cnt].OrderDummy5 +
                _dataSet.MonthResult[cnt].OrderDummy6 + _dataSet.MonthResult[cnt].OrderDummy7 +
                _dataSet.MonthResult[cnt].OrderDummy8 + _dataSet.MonthResult[cnt].OrderDummy9 +
                _dataSet.MonthResult[cnt].OrderDummy10 + _dataSet.MonthResult[cnt].OrderDummy11;
            // --- ADD 2010/08/02 -------------------------------->>>>>

            double rate;

            // 合計純売上達成率
            if (_dataSet.MonthResult[cnt].TargetMoney == 0)
            {
                rate = 0;
                _dataSet.MonthResult[cnt].AchievementRate = rate;
            }
            else
            {
                //四捨五入
                rate = this.FracCalcMoneyD((double)_dataSet.MonthResult[cnt].GenuineSalesMoney / (double)_dataSet.MonthResult[cnt].TargetMoney, 0.0001, 2) * 100;
                _dataSet.MonthResult[cnt].AchievementRate = rate;
            }
            // 合計純売上達成率
            if (_dataSet.MonthResult[cnt].TargetMoney1 == 0)
            {
                rate = 0;
                _dataSet.MonthResult[cnt].AchievementRate1 = rate;
            }
            else
            {
                //四捨五入
                rate = this.FracCalcMoneyD((double)_dataSet.MonthResult[cnt].GenuineSalesMoney1 / (double)_dataSet.MonthResult[cnt].TargetMoney1, 0.0001, 2) * 100;
                _dataSet.MonthResult[cnt].AchievementRate1 = rate;
            }
            // 合計純売上達成率
            if (_dataSet.MonthResult[cnt].TargetMoney2 == 0)
            {
                rate = 0;
                _dataSet.MonthResult[cnt].AchievementRate2 = rate;
            }
            else
            {
                //四捨五入
                rate = this.FracCalcMoneyD((double)_dataSet.MonthResult[cnt].GenuineSalesMoney2 / (double)_dataSet.MonthResult[cnt].TargetMoney2, 0.0001, 2) * 100;
                _dataSet.MonthResult[cnt].AchievementRate2 = rate;
            }
            // 合計純売上達成率
            if (_dataSet.MonthResult[cnt].TargetMoney3 == 0)
            {
                rate = 0;
                _dataSet.MonthResult[cnt].AchievementRate3 = rate;
            }
            else
            {
                //四捨五入
                rate = this.FracCalcMoneyD((double)_dataSet.MonthResult[cnt].GenuineSalesMoney3 / (double)_dataSet.MonthResult[cnt].TargetMoney3, 0.0001, 2) * 100;
                _dataSet.MonthResult[cnt].AchievementRate3 = rate;
            }
            // 合計純売上達成率
            if (_dataSet.MonthResult[cnt].TargetMoney4 == 0)
            {
                rate = 0;
                _dataSet.MonthResult[cnt].AchievementRate4 = rate;
            }
            else
            {
                //四捨五入
                rate = this.FracCalcMoneyD((double)_dataSet.MonthResult[cnt].GenuineSalesMoney4 / (double)_dataSet.MonthResult[cnt].TargetMoney4, 0.0001, 2) * 100;
                _dataSet.MonthResult[cnt].AchievementRate4 = rate;
            }
            // 合計純売上達成率
            if (_dataSet.MonthResult[cnt].TargetMoney5 == 0)
            {
                rate = 0;
                _dataSet.MonthResult[cnt].AchievementRate5 = rate;
            }
            else
            {
                //四捨五入
                rate = this.FracCalcMoneyD((double)_dataSet.MonthResult[cnt].GenuineSalesMoney5 / (double)_dataSet.MonthResult[cnt].TargetMoney5, 0.0001, 2) * 100;
                _dataSet.MonthResult[cnt].AchievementRate5 = rate;
            }
            // 合計純売上達成率
            if (_dataSet.MonthResult[cnt].TargetMoney6 == 0)
            {
                rate = 0;
                _dataSet.MonthResult[cnt].AchievementRate6 = rate;
            }
            else
            {
                //四捨五入
                rate = this.FracCalcMoneyD((double)_dataSet.MonthResult[cnt].GenuineSalesMoney6 / (double)_dataSet.MonthResult[cnt].TargetMoney6, 0.0001, 2) * 100;
                _dataSet.MonthResult[cnt].AchievementRate6 = rate;
            }
            // 合計純売上達成率
            if (_dataSet.MonthResult[cnt].TargetMoney7 == 0)
            {
                rate = 0;
                _dataSet.MonthResult[cnt].AchievementRate7 = rate;
            }
            else
            {
                //四捨五入
                rate = this.FracCalcMoneyD((double)_dataSet.MonthResult[cnt].GenuineSalesMoney7 / (double)_dataSet.MonthResult[cnt].TargetMoney7, 0.0001, 2) * 100;
                _dataSet.MonthResult[cnt].AchievementRate7 = rate;
            }
            // 合計純売上達成率
            if (_dataSet.MonthResult[cnt].TargetMoney8 == 0)
            {
                rate = 0;
                _dataSet.MonthResult[cnt].AchievementRate8 = rate;
            }
            else
            {
                //四捨五入
                rate = this.FracCalcMoneyD((double)_dataSet.MonthResult[cnt].GenuineSalesMoney8 / (double)_dataSet.MonthResult[cnt].TargetMoney8, 0.0001, 2) * 100;
                _dataSet.MonthResult[cnt].AchievementRate8 = rate;
            }
            // 合計純売上達成率
            if (_dataSet.MonthResult[cnt].TargetMoney9 == 0)
            {
                rate = 0;
                _dataSet.MonthResult[cnt].AchievementRate9 = rate;
            }
            else
            {
                //四捨五入
                rate = this.FracCalcMoneyD((double)_dataSet.MonthResult[cnt].GenuineSalesMoney9 / (double)_dataSet.MonthResult[cnt].TargetMoney9, 0.0001, 2) * 100;
                _dataSet.MonthResult[cnt].AchievementRate9 = rate;
            }
            // 合計純売上達成率
            if (_dataSet.MonthResult[cnt].TargetMoney10 == 0)
            {
                rate = 0;
                _dataSet.MonthResult[cnt].AchievementRate10 = rate;
            }
            else
            {
                //四捨五入
                rate = this.FracCalcMoneyD((double)_dataSet.MonthResult[cnt].GenuineSalesMoney10 / (double)_dataSet.MonthResult[cnt].TargetMoney10, 0.0001, 2) * 100;
                _dataSet.MonthResult[cnt].AchievementRate10 = rate;
            }
            // 合計純売上達成率
            if (_dataSet.MonthResult[cnt].TargetMoney11 == 0)
            {
                rate = 0;
                _dataSet.MonthResult[cnt].AchievementRate11 = rate;
            }
            else
            {
                //四捨五入
                rate = this.FracCalcMoneyD((double)_dataSet.MonthResult[cnt].GenuineSalesMoney11 / (double)_dataSet.MonthResult[cnt].TargetMoney11, 0.0001, 2) * 100;
                _dataSet.MonthResult[cnt].AchievementRate11 = rate;
            }


            // 合計粗利達成率
            if (_dataSet.MonthResult[cnt].GrossProfitTargetMoney == 0)
            {
                rate = 0;
                _dataSet.MonthResult[cnt].GrossProfitAchievRate = rate;
            }
            else
            {
                //四捨五入
                rate = this.FracCalcMoneyD((double)_dataSet.MonthResult[cnt].GrossProfitMoney / (double)_dataSet.MonthResult[cnt].GrossProfitTargetMoney, 0.0001, 2) * 100;
                _dataSet.MonthResult[cnt].GrossProfitAchievRate = rate;
            }
            // 合計粗利達成率
            if (_dataSet.MonthResult[cnt].GrossProfitTargetMoney1 == 0)
            {
                rate = 0;
                _dataSet.MonthResult[cnt].GrossProfitAchievRate1 = rate;
            }
            else
            {
                //四捨五入
                rate = this.FracCalcMoneyD((double)_dataSet.MonthResult[cnt].GrossProfitMoney1 / (double)_dataSet.MonthResult[cnt].GrossProfitTargetMoney1, 0.0001, 2) * 100;
                _dataSet.MonthResult[cnt].GrossProfitAchievRate1 = rate;
            }
            // 合計粗利達成率
            if (_dataSet.MonthResult[cnt].GrossProfitTargetMoney2 == 0)
            {
                rate = 0;
                _dataSet.MonthResult[cnt].GrossProfitAchievRate2 = rate;
            }
            else
            {
                //四捨五入
                //rate = this.FracCalcMoneyD((double)_dataSet.MonthResult[cnt].GrossProfitMoney / (double)_dataSet.MonthResult[cnt].GrossProfitTargetMoney2, 0.0001, 2) * 100; //DEL 2010/08/21
                rate = this.FracCalcMoneyD((double)_dataSet.MonthResult[cnt].GrossProfitMoney2 / (double)_dataSet.MonthResult[cnt].GrossProfitTargetMoney2, 0.0001, 2) * 100;  //ADD 2010/08/21
                _dataSet.MonthResult[cnt].GrossProfitAchievRate2 = rate;
            }
            // 合計粗利達成率
            if (_dataSet.MonthResult[cnt].GrossProfitTargetMoney3 == 0)
            {
                rate = 0;
                _dataSet.MonthResult[cnt].GrossProfitAchievRate3 = rate;
            }
            else
            {
                //四捨五入
                rate = this.FracCalcMoneyD((double)_dataSet.MonthResult[cnt].GrossProfitMoney3 / (double)_dataSet.MonthResult[cnt].GrossProfitTargetMoney3, 0.0001, 2) * 100;
                _dataSet.MonthResult[cnt].GrossProfitAchievRate3 = rate;
            }
            // 合計粗利達成率
            if (_dataSet.MonthResult[cnt].GrossProfitTargetMoney4 == 0)
            {
                rate = 0;
                _dataSet.MonthResult[cnt].GrossProfitAchievRate4 = rate;
            }
            else
            {
                //四捨五入
                rate = this.FracCalcMoneyD((double)_dataSet.MonthResult[cnt].GrossProfitMoney4 / (double)_dataSet.MonthResult[cnt].GrossProfitTargetMoney4, 0.0001, 2) * 100;
                _dataSet.MonthResult[cnt].GrossProfitAchievRate4 = rate;
            }
            // 合計粗利達成率
            if (_dataSet.MonthResult[cnt].GrossProfitTargetMoney5 == 0)
            {
                rate = 0;
                _dataSet.MonthResult[cnt].GrossProfitAchievRate5 = rate;
            }
            else
            {
                //四捨五入
                rate = this.FracCalcMoneyD((double)_dataSet.MonthResult[cnt].GrossProfitMoney5 / (double)_dataSet.MonthResult[cnt].GrossProfitTargetMoney5, 0.0001, 2) * 100;
                _dataSet.MonthResult[cnt].GrossProfitAchievRate5 = rate;
            }
            // 合計粗利達成率
            if (_dataSet.MonthResult[cnt].GrossProfitTargetMoney6 == 0)
            {
                rate = 0;
                _dataSet.MonthResult[cnt].GrossProfitAchievRate6 = rate;
            }
            else
            {
                //四捨五入
                rate = this.FracCalcMoneyD((double)_dataSet.MonthResult[cnt].GrossProfitMoney6 / (double)_dataSet.MonthResult[cnt].GrossProfitTargetMoney6, 0.0001, 2) * 100;
                _dataSet.MonthResult[cnt].GrossProfitAchievRate6 = rate;
            }
            // 合計粗利達成率
            if (_dataSet.MonthResult[cnt].GrossProfitTargetMoney7 == 0)
            {
                rate = 0;
                _dataSet.MonthResult[cnt].GrossProfitAchievRate7 = rate;
            }
            else
            {
                //四捨五入
                rate = this.FracCalcMoneyD((double)_dataSet.MonthResult[cnt].GrossProfitMoney7 / (double)_dataSet.MonthResult[cnt].GrossProfitTargetMoney7, 0.0001, 2) * 100;
                _dataSet.MonthResult[cnt].GrossProfitAchievRate7 = rate;
            }
            // 合計粗利達成率
            if (_dataSet.MonthResult[cnt].GrossProfitTargetMoney8 == 0)
            {
                rate = 0;
                _dataSet.MonthResult[cnt].GrossProfitAchievRate8 = rate;
            }
            else
            {
                //四捨五入
                rate = this.FracCalcMoneyD((double)_dataSet.MonthResult[cnt].GrossProfitMoney8 / (double)_dataSet.MonthResult[cnt].GrossProfitTargetMoney8, 0.0001, 2) * 100;
                _dataSet.MonthResult[cnt].GrossProfitAchievRate8 = rate;
            }
            // 合計粗利達成率
            if (_dataSet.MonthResult[cnt].GrossProfitTargetMoney9 == 0)
            {
                rate = 0;
                _dataSet.MonthResult[cnt].GrossProfitAchievRate9 = rate;
            }
            else
            {
                //四捨五入
                rate = this.FracCalcMoneyD((double)_dataSet.MonthResult[cnt].GrossProfitMoney9 / (double)_dataSet.MonthResult[cnt].GrossProfitTargetMoney9, 0.0001, 2) * 100;
                _dataSet.MonthResult[cnt].GrossProfitAchievRate9 = rate;
            }
            // 合計粗利達成率
            if (_dataSet.MonthResult[cnt].GrossProfitTargetMoney10 == 0)
            {
                rate = 0;
                _dataSet.MonthResult[cnt].GrossProfitAchievRate10 = rate;
            }
            else
            {
                //四捨五入
                rate = this.FracCalcMoneyD((double)_dataSet.MonthResult[cnt].GrossProfitMoney10 / (double)_dataSet.MonthResult[cnt].GrossProfitTargetMoney10, 0.0001, 2) * 100;
                _dataSet.MonthResult[cnt].GrossProfitAchievRate10 = rate;
            }
            // 合計粗利達成率
            if (_dataSet.MonthResult[cnt].GrossProfitTargetMoney11 == 0)
            {
                rate = 0;
                _dataSet.MonthResult[cnt].GrossProfitAchievRate11 = rate;
            }
            else
            {
                //四捨五入
                rate = this.FracCalcMoneyD((double)_dataSet.MonthResult[cnt].GrossProfitMoney11 / (double)_dataSet.MonthResult[cnt].GrossProfitTargetMoney11, 0.0001, 2) * 100;
                _dataSet.MonthResult[cnt].GrossProfitAchievRate11 = rate;
            }
        }
        // --- ADD 2010/07/20 --------------------------------<<<<<

        /// <summary>
        /// 売上実績照会データを検索し、検索結果をデータテーブルにキャッシュします。
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="selectionCodeInt">選択項目コード（数値）</param>
        /// <param name="selectionCodeStr">選択項目コード（文字）</param>
        /// <param name="totalDiv">0:拠点 1:得意先 2:担当者 3:受注者 4:発行者 5:地区 6:業種</param>
        /// <returns>STATUS</returns>
        public int Search(string enterpriseCode, string sectionCode,  int selectionCodeInt, string selectionCodeStr, int totalDiv, out InventoryUpdateDataSet resultData)
        {
            int status;

            this.ClrRowFromUIData_Month();
            this.ClrRowFromUIData_Stock();
            this.ClrRowFromUIData_Shipment();
            this.ClrRowFromUIData_StockOrder();

            SalesAnnualDataSelectParamWork salesAnnualDataSelectParamWork = new SalesAnnualDataSelectParamWork();
            salesAnnualDataSelectParamWork.EnterpriseCode = enterpriseCode;
            salesAnnualDataSelectParamWork.SectionCode = sectionCode;
            
            // 集計区分
            switch (totalDiv)
            {
                case 0: // 拠点
                case 1: // 得意先
                    salesAnnualDataSelectParamWork.TotalDiv = totalDiv;
                    break;
                case 2: // 担当者
                case 3: // 受注者
                case 4: // 発行者
                    salesAnnualDataSelectParamWork.TotalDiv = 2;
                    break;
                case 5: // 地区（販売エリアコード）
                    salesAnnualDataSelectParamWork.TotalDiv = 3;
                    break;
                case 6: // 業種
                    salesAnnualDataSelectParamWork.TotalDiv = 4;
                    break;

            }

            // 抽出区分
            salesAnnualDataSelectParamWork.SearchDiv = 0;
            switch (totalDiv)
            {
                case 0: // 拠点
                    {
                        salesAnnualDataSelectParamWork.EmployeeDivCd = 10;
                        break;
                    }
                case 1: // 得意先
                    {
                        salesAnnualDataSelectParamWork.CustomerCode = selectionCodeInt;
                        salesAnnualDataSelectParamWork.EmployeeDivCd = 10;
                        break;
                    }
                case 2: // 担当者
                case 3: // 受注者
                case 4: // 発行者
                    {
                        salesAnnualDataSelectParamWork.EmployeeCode = selectionCodeStr;

                        if (totalDiv == 2)
                        {
                            // 従業員区分
                            salesAnnualDataSelectParamWork.EmployeeDivCd = 10;
                        }
                        else if (totalDiv == 3)
                        {
                            // 従業員区分
                            salesAnnualDataSelectParamWork.EmployeeDivCd = 20;
                        }
                        else if (totalDiv == 4)
                        {
                            // 従業員区分
                            salesAnnualDataSelectParamWork.EmployeeDivCd = 30;
                        }
                        break;
                    }
                case 5: // 地区（販売エリアコード）
                    {
                        salesAnnualDataSelectParamWork.SalesAreaCode = selectionCodeInt;
                        salesAnnualDataSelectParamWork.EmployeeDivCd = 10;
                        break;
                    }
                case 6: // 業種
                    {
                        salesAnnualDataSelectParamWork.BusinessTypeCode = selectionCodeInt;
                        salesAnnualDataSelectParamWork.EmployeeDivCd = 10;
                        break;
                    }
            }

            // 開始年月（前期の開始年月）
            //salesAnnualDataSelectParamWork.YearMonthSt = _companyBiginDate - 100;
            //salesAnnualDataSelectParamWork.YearMonthSt = _companyBiginDate;       // DEL 2009/04/14
            // 前期の開始年月を設定しないと、前期の取得が出来ないので修正前に戻す
            salesAnnualDataSelectParamWork.YearMonthSt = _companyBiginDate - 100;   // ADD 2009/04/14

            // 終了年月（当月）
            salesAnnualDataSelectParamWork.YearMonthEd = _companyEndDate;

            #region DEL
            // --- CHG 2009/02/04 --------------------------------------------------------------------->>>>>
            //if (totalDiv == 1)
            //{
            //    // 得意先別用条件
            //    DateTime prevTotalDay;
            //    DateTime prevTotalDay_sec;
            //    // 計上年月
            //    salesAnnualDataSelectParamWork.AddUpYearMonth = _companyNowDateTime;
            //    // 開始集計年月日＆終了集計年月日＆集計得意先締日（年月日）
            //    _totalDayCalculator.GetTotalDayDmdC(sectionCode,selectionCodeInt, out prevTotalDay);
            //    if (prevTotalDay == DateTime.MinValue)
            //    {
            //        salesAnnualDataSelectParamWork.StAddUpDate = 19000101;
            //        salesAnnualDataSelectParamWork.EdAddUpDate = Int32.Parse(DateTime.Now.ToString("yyyyMMdd"));

            //        salesAnnualDataSelectParamWork.CustTotalDay = 19000101;
            //    }
            //    else
            //    {
            //        //暫定的に、１か月前の翌日を開始日とする
            //        salesAnnualDataSelectParamWork.StAddUpDate = Int32.Parse(prevTotalDay.AddMonths(-1).AddDays(1).ToString("yyyyMMdd"));
            //        salesAnnualDataSelectParamWork.EdAddUpDate = Int32.Parse(prevTotalDay.ToString("yyyyMMdd"));

            //        salesAnnualDataSelectParamWork.CustTotalDay = Int32.Parse(prevTotalDay.ToString("yyyyMMdd"));
            //    }
                                
            //    // 集計拠点締日（年月日）
            //    _totalDayCalculator.GetHisTotalDayMonthlyAccRec(sectionCode, out prevTotalDay_sec);
            //    if (prevTotalDay_sec == DateTime.MinValue)
            //    {
            //        salesAnnualDataSelectParamWork.SecTotalDay = 19000101;
            //    }
            //    else
            //    {
            //        salesAnnualDataSelectParamWork.SecTotalDay = Int32.Parse(prevTotalDay_sec.ToString("yyyyMMdd")); ;
            //    }
            //}
            //else
            //{
            //    salesAnnualDataSelectParamWork.AddUpYearMonth = DateTime.MinValue;
            //    salesAnnualDataSelectParamWork.StAddUpDate = 0;
            //    salesAnnualDataSelectParamWork.EdAddUpDate = 0;
            //    salesAnnualDataSelectParamWork.CustTotalDay = 0;
            //    salesAnnualDataSelectParamWork.SecTotalDay = 0;
            //}
            #endregion

            // -- UPD 2009/09/07 ------------------------->>>
            //DateTime prevTotalDay;
            //DateTime currentTotalDay;
            DateTime prevTotalDay = DateTime.MinValue;
            DateTime currentTotalDay = DateTime.MinValue;
            // -- UPD 2009/09/07 -------------------------<<<

            switch (totalDiv)
            {
                case 0:     // 集計区分が拠点
                    {
                        // 計上年月
                        salesAnnualDataSelectParamWork.AddUpYearMonth = DateTime.MinValue;
                        // 開始集計年月日(得意先)　得意先前回締日(開始)をセット
                        salesAnnualDataSelectParamWork.StAddUpDate = 0;
                        // 終了集計年月日(得意先)　得意先前回締日(終了)をセット
                        salesAnnualDataSelectParamWork.EdAddUpDate = 0;
                        // 集計得意先締日(年月日)　得意先今回締日(終了)をセット
                        salesAnnualDataSelectParamWork.CustTotalDay = 0;

                        status = _totalDayCalculator.GetHisTotalDayDmdC(sectionCode, out prevTotalDay, out currentTotalDay);
                        if (status == 0)
                        {
                            // 開始集計年月日(拠点)　拠点前回締日(開始)をセット
                            if (prevTotalDay != DateTime.MinValue)
                            {
                                // -- UPD 2009/09/07 ---------------------------------->>>
                                //salesAnnualDataSelectParamWork.StSecAddUpDate = Int32.Parse(prevTotalDay.AddMonths(-1).AddDays(1).ToString("yyyyMMdd"));

                                DateTime stDate = prevTotalDay.AddDays(1);
                                stDate = stDate.AddMonths(-1);
                                salesAnnualDataSelectParamWork.StSecAddUpDate = Int32.Parse(stDate.ToString("yyyyMMdd"));
                                // -- UPD 2009/09/07 ----------------------------------<<<
                            }
                            else
                            {
                                salesAnnualDataSelectParamWork.StSecAddUpDate = 0;
                            }
                            // 終了集計年月日(拠点)　拠点前回締日(終了)をセット
                            salesAnnualDataSelectParamWork.EdSecAddUpDate = Int32.Parse(prevTotalDay.ToString("yyyyMMdd"));
                            // 集計拠点締日(年月日)　拠点今回締日(終了)をセット
                            salesAnnualDataSelectParamWork.SecTotalDay = Int32.Parse(currentTotalDay.ToString("yyyyMMdd"));
                        }
                        else
                        {
                            // 開始集計年月日(拠点)　拠点前回締日(開始)をセット
                            salesAnnualDataSelectParamWork.StSecAddUpDate = 0;
                            // 終了集計年月日(拠点)　拠点前回締日(終了)をセット
                            salesAnnualDataSelectParamWork.EdSecAddUpDate = 0;
                            // 集計拠点締日(年月日)　拠点今回締日(終了)をセット
                            salesAnnualDataSelectParamWork.SecTotalDay = 0;
                        }

                        break;
                    }
                case 1:     // 集計区分が得意先
                    {
                        // 請求計上拠点
                        salesAnnualDataSelectParamWork.ClaimSectionCode = selectionCodeStr;

                        // 計上年月
                        salesAnnualDataSelectParamWork.AddUpYearMonth = _companyNowDateTime;
                        
                        status = _totalDayCalculator.GetTotalDayDmdC(selectionCodeStr, selectionCodeInt, out prevTotalDay, out currentTotalDay);
                        if (status == 0)
                        {
                            // 開始集計年月日(得意先)　得意先前回締日(開始)をセット
                            if (prevTotalDay != DateTime.MinValue)
                            {
                                // -- UPD 2009/09/07 ---------------------------------->>>
                                //salesAnnualDataSelectParamWork.StAddUpDate = Int32.Parse(prevTotalDay.AddMonths(-1).AddDays(1).ToString("yyyyMMdd"));

                                DateTime stDate = prevTotalDay.AddDays(1);
                                stDate = stDate.AddMonths(-1);
                                salesAnnualDataSelectParamWork.StAddUpDate = Int32.Parse(stDate.ToString("yyyyMMdd"));
                                // -- UPD 2009/09/07 ----------------------------------<<<
                            }
                            else
                            {
                                salesAnnualDataSelectParamWork.StAddUpDate = 0;
                            }
                            // 終了集計年月日(得意先)　得意先前回締日(終了)をセット
                            salesAnnualDataSelectParamWork.EdAddUpDate = Int32.Parse(prevTotalDay.ToString("yyyyMMdd"));
                            // 集計得意先締日(年月日)　得意先今回締日(終了)をセット
                            salesAnnualDataSelectParamWork.CustTotalDay = Int32.Parse(currentTotalDay.ToString("yyyyMMdd"));
                        }
                        else
                        {
                            // 開始集計年月日(得意先)　得意先前回締日(開始)をセット
                            salesAnnualDataSelectParamWork.StAddUpDate = 0;
                            // 終了集計年月日(得意先)　得意先前回締日(終了)をセット
                            salesAnnualDataSelectParamWork.EdAddUpDate = 0;
                            // 集計得意先締日(年月日)　得意先今回締日(終了)をセット
                            salesAnnualDataSelectParamWork.CustTotalDay = 0;
                        }

                        //status = _totalDayCalculator.GetHisTotalDayDmdC(selectionCodeStr, out prevTotalDay, out currentTotalDay); // DEL 2009/09/07
                        status = _totalDayCalculator.GetTotalDayMonthlyAccRec(selectionCodeInt, out prevTotalDay, out currentTotalDay); // ADD 2009/09/07 月次の締日取得メソッドに変更

                        if (status == 0)
                        {
                            // 開始集計年月日(拠点)　拠点前回締日(開始)をセット
                            if (prevTotalDay != DateTime.MinValue)
                            {
                                // -- UPD 2009/09/07 ---------------------------------------------->>>
                                //salesAnnualDataSelectParamWork.StSecAddUpDate = Int32.Parse(prevTotalDay.AddMonths(-1).AddDays(1).ToString("yyyyMMdd"));

                                //末日の取得方法の修正
                                DateTime stDate = prevTotalDay.AddDays(1);
                                stDate = stDate.AddMonths(-1);
                                salesAnnualDataSelectParamWork.StSecAddUpDate = Int32.Parse(stDate.ToString("yyyyMMdd"));
                                // -- UPD 2009/09/07 ----------------------------------------------<<<
                            }
                            else
                            {
                                salesAnnualDataSelectParamWork.StSecAddUpDate = 0;
                            }
                            // 終了集計年月日(拠点)　拠点前回締日(終了)をセット
                            salesAnnualDataSelectParamWork.EdSecAddUpDate = Int32.Parse(prevTotalDay.ToString("yyyyMMdd"));
                            // 集計拠点締日(年月日)　拠点今回締日(終了)をセット
                            salesAnnualDataSelectParamWork.SecTotalDay = Int32.Parse(currentTotalDay.ToString("yyyyMMdd"));
                        }
                        else
                        {
                            // 開始集計年月日(拠点)　拠点前回締日(開始)をセット
                            salesAnnualDataSelectParamWork.StSecAddUpDate = 0;
                            // 終了集計年月日(拠点)　拠点前回締日(終了)をセット
                            salesAnnualDataSelectParamWork.EdSecAddUpDate = 0;
                            // 集計拠点締日(年月日)　拠点今回締日(終了)をセット
                            salesAnnualDataSelectParamWork.SecTotalDay = 0;
                        }

                        break;
                    }
                default:    // その他
                    {
                        // 計上年月
                        salesAnnualDataSelectParamWork.AddUpYearMonth = DateTime.MinValue;
                        // 開始集計年月日(得意先)　得意先前回締日(開始)をセット
                        salesAnnualDataSelectParamWork.StAddUpDate = 0;
                        // 終了集計年月日(得意先)　得意先前回締日(終了)をセット
                        salesAnnualDataSelectParamWork.EdAddUpDate = 0;
                        // 集計得意先締日(年月日)　得意先今回締日(終了)をセット
                        salesAnnualDataSelectParamWork.CustTotalDay = 0;
                        // 開始集計年月日(拠点)　拠点前回締日(開始)をセット
                        salesAnnualDataSelectParamWork.StSecAddUpDate = 0;
                        // 終了集計年月日(拠点)　拠点前回締日(終了)をセット
                        salesAnnualDataSelectParamWork.EdSecAddUpDate = 0;
                        // 集計拠点締日(年月日)　拠点今回締日(終了)をセット
                        salesAnnualDataSelectParamWork.SecTotalDay = 0;
                        break;
                    }
            }
            // --- CHG 2009/02/04 ---------------------------------------------------------------------<<<<<

            // -- ADD 2009/09/07 ------------------------------------>>>
            //次回月次締日を含む年月度を現在処理中年月とする
            if (prevTotalDay != DateTime.MinValue)
            {
                DateTime dtYearMonth;
                _dateGet.GetYearMonth(currentTotalDay, out dtYearMonth);
                _companyNowDate = Int32.Parse(dtYearMonth.ToString("yyyyMM"));
            }
            // -- ADD 2009/09/07 ------------------------------------<<<

            // ADD 2009/05/12 ------>>>
            // 請求拠点コード
            switch (totalDiv)
            {
                case 1:     // 集計区分：得意先
                    {
                        CustomerInfo customerInfo;
                        CustomerInfoAcs customerInfoAcs = new CustomerInfoAcs();

                        status = customerInfoAcs.ReadDBData(ConstantManagement.LogicalMode.GetData0, enterpriseCode, selectionCodeInt, true, out customerInfo);
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            salesAnnualDataSelectParamWork.ClaimSectionCode = customerInfo.ClaimSectionCode.TrimEnd();
                        }
                        break;
                    }
                default:
                    {
                        salesAnnualDataSelectParamWork.ClaimSectionCode = string.Empty;
                        break;
                    }
            }
            // ADD 2009/05/12 ------<<<

            object paraObj = (object)salesAnnualDataSelectParamWork;
            object retObj;

            status = this._iSalesAnnualDataSelectResultDB.Search(out retObj, paraObj);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // 戻りリストの要素の型がSalesAnnualDataSelectResultWorkならばデータ展開
                ArrayList retList = (ArrayList)retObj;
                if ((retList.Count > 0) && (retList[0] is SalesAnnualDataSelectResultWork))
                {
                    foreach (SalesAnnualDataSelectResultWork data in retList)
                    {
                        this.Cache(data, totalDiv);
                    }
                }

                // 率算出
                for (int ix = 0; ix < 12; ix++)
                {
                    SetRowFromUIData_Average(ix, 0, 0);
                }

                // 集計対象外月は空白
                for (int ix = 0; ix < 12; ix++)
                {
                    SetRowFromUIData_Null(ix, 0, 0);
                }

                // 合計・平均算出
                int count = 0;
                for (int ix = 0; ix < 12; ix++)
                {
                    if (!_dataSet.MonthResult[ix].IsSalesMoneyNull()) count++;
                }
                SetRowFromUIData_Average(12, 13, count);

                this._dataSet.MonthResult.DefaultView.Sort = this._dataSet.MonthResult.RowNoColumn.ColumnName;
            }

            resultData = _dataSet;

            int status1 = -1;
            int status2 = -1;

            if (totalDiv == 1)
            {
                // 抽出区分
                salesAnnualDataSelectParamWork.SearchDiv = 1;
                object paraObj1 = (object)salesAnnualDataSelectParamWork;
                object retObj1;

                status1 = this._iSalesAnnualDataSelectResultDB.CustSearch(out retObj1, paraObj1);

                if (status1 == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // 入金情報
                    // 戻りリストの要素の型がCustSalesAnnualDataSelectResultWorkならばデータ展開
                    ArrayList retList = (ArrayList)retObj1;
                    if ((retList.Count > 0) && (retList[0] is CustSalesAnnualDataSelectResultWork))
                    {
                        foreach (CustSalesAnnualDataSelectResultWork data in retList)
                        {
                            this.SetData_StockOrderResult_Deposit(data);
                        }
                    }
                }

                // 抽出区分
                salesAnnualDataSelectParamWork.SearchDiv = 2;
                object paraObj2 = (object)salesAnnualDataSelectParamWork;
                object retObj2;

                status2 = this._iSalesAnnualDataSelectResultDB.CustSearch(out retObj2, paraObj2);

                if (status2 == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // 請求＆当月
                    // 戻りリストの要素の型がCustSalesAnnualDataSelectResultWorkならばデータ展開
                    ArrayList retList = (ArrayList)retObj2;
                    if ((retList.Count > 0) && (retList[0] is CustSalesAnnualDataSelectResultWork))
                    {
                        foreach (CustSalesAnnualDataSelectResultWork data in retList)
                        {
                            SetData_StockOrderResult_PureSuperior(data);
                        }
                    }
                }
            }

            if (totalDiv == 1)
            {
                if ((status == 0) || (status1 == 0) || (status2 == 0))
                {
                    return 0;
                }
                else
                {
                    return status;
                }
            }
            else
            {
                return status;
            }
        }

        /// <summary>
        /// 売上実績照会データテーブルの行を初期化します。
        /// </summary>
        public void Clear()
        {
            this._dataSet.MonthResult.Rows.Clear();
            this._dataSet.StockResult.Rows.Clear();
            this._dataSet.ShipmentResult.Rows.Clear();
            this._dataSet.StockOrderResult.Rows.Clear();
        }

        /// <summary>
        /// 売上実績照会データ検索結果オブジェクトをデータテーブルにキャッシュします。
        /// </summary>
        /// <param name="data">売上実績照会データ検索結果オブジェクト</param>
        private void Cache(SalesAnnualDataSelectResultWork data, int totalDiv)
        {
            // 月単位
            for (int ix = 0; ix < _dataSet.MonthResult.Count; ix++)
            {
                if (data.AUPYearMonth % 100 == _dataSet.MonthResult[ix].RowMonth)
                {
                    // 集計対象外月は空白
                    // --- CHG 2009/02/25 障害ID:11918対応------------------------------------------------------>>>>>
                    //if (data.AUPYearMonth >= _companyNowDate)
                    if (data.AUPYearMonth > _companyNowDate)
                    // --- CHG 2009/02/25 障害ID:11918対応------------------------------------------------------<<<<<
                    {
                        _dataSet.MonthResult[ix].SetSalesMoneyNull();
                        _dataSet.MonthResult[ix].SetReturnedGoodsPriceNull();
                        _dataSet.MonthResult[ix].SetDiscountPriceNull();
                        _dataSet.MonthResult[ix].SetGenuineSalesMoneyNull();
                        _dataSet.MonthResult[ix].SetTargetMoneyNull();
                        _dataSet.MonthResult[ix].SetGrossProfitMoneyNull();
                        _dataSet.MonthResult[ix].SetGrossProfitTargetMoneyNull();
                    }
                    else
                    {
                        this.SetRowFromUIData_Month(ix, data);
                    }
                    break;
                }
            }
            // --- CHG 2009/02/25 障害ID:11918対応------------------------------------------------------>>>>>
            //if (data.AUPYearMonth < _companyNowDate)
            if (data.AUPYearMonth <= _companyNowDate)
            // --- CHG 2009/02/25 障害ID:11918対応------------------------------------------------------<<<<<
            {
                this.SetRowFromUIData_Total(12, data);
            }

            // 在庫・取寄
            if (data.AUPYearMonth >= _companyBiginDate &&
                // --- CHG 2009/02/25 障害ID:11918対応------------------------------------------------------>>>>>
                //data.AUPYearMonth < _companyNowDate)
                data.AUPYearMonth <= _companyNowDate)
            // --- CHG 2009/02/25 障害ID:11918対応------------------------------------------------------<<<<<
            {
                if (totalDiv == 1)
                {
                    // 純正 - 在庫
                    this.SetRowFromUIData_StockOrder(0, data);
                    // 純正 - 取寄
                    this.SetRowFromUIData_StockOrder(1, data);
                    // 純正 - 合計
                    this.SetRowFromUIData_StockOrder(2, data);
                    // 優良 - 在庫
                    this.SetRowFromUIData_StockOrder(3, data);
                    // 優良 - 取寄
                    this.SetRowFromUIData_StockOrder(4, data);
                    // 優良 - 合計
                    this.SetRowFromUIData_StockOrder(5, data);
                    // 合計 - 在庫
                    this.SetRowFromUIData_StockOrder(6, data);
                    // 合計 - 取寄
                    this.SetRowFromUIData_StockOrder(7, data);
                    // 合計 - 合計
                    this.SetRowFromUIData_StockOrder(8, data);
                }
                else
                {
                    // 純正
                    this.SetRowFromUIData_Stock(0, data);
                    // 優良
                    this.SetRowFromUIData_Stock(1, data);
                    // 合計
                    this.SetRowFromUIData_Stock(2, data);

                    // 在庫
                    this.SetRowFromUIData_Stock(3, data);
                    // 取寄
                    this.SetRowFromUIData_Stock(4, data);
                    this.SetRowFromUIData_Stock(5, data);
                }

            }

            // 出荷実績照会用
            if (data.AUPYearMonth >= _companyBiginDate)
            {
                for (int ix = 0; ix < _dataSet.ShipmentResult.Count; ix++)
                {
                    if (data.AUPYearMonth % 100 == _dataSet.ShipmentResult[ix].RowMonth)
                    {
                        // 集計対象外月は空白
                        // --- CHG 2009/02/25 障害ID:11918対応------------------------------------------------------>>>>>
                        //if (data.AUPYearMonth >= _companyNowDate)
                        if (data.AUPYearMonth > _companyNowDate)
                        // --- CHG 2009/02/25 障害ID:11918対応------------------------------------------------------<<<<<
                        {
                            _dataSet.ShipmentResult[ix].SetStockNull();
                            _dataSet.ShipmentResult[ix].SetOrderNull();
                            _dataSet.ShipmentResult[ix].SetSumNull();
                            _dataSet.ShipmentResult[ix].SetSlipNull();
                        }
                        else
                        {
                            //this.SetRowFromUIData_ShipmentMonth(ix, data); //DEL 2015/08/18 田思春 For Redmine#47035 伝票枚数の集計修正
                            this.SetRowFromUIData_ShipmentMonth(ix, data, totalDiv);//ADD 2015/08/18 田思春 For Redmine#47035 伝票枚数の集計修正
                        }
                    }
                }
            }

        }

        /// <summary>
        /// 売上実績照会データ行クラスクリア処理（月次）
        /// </summary>
        private void ClrRowFromUIData_Month()
        {
            for (int ix = 0; ix < _dataSet.MonthResult.Count; ix++)
            {
                // 売上金額
                _dataSet.MonthResult[ix].SalesMoney = 0;
                _dataSet.MonthResult[ix].ReturnedGoodsPrice = 0;
                _dataSet.MonthResult[ix].DiscountPrice = 0;

                // 純売上金額
                _dataSet.MonthResult[ix].GenuineSalesMoney = 0;
                _dataSet.MonthResult[ix].TargetMoney = 0;
                _dataSet.MonthResult[ix].AchievementRate = 0;

                // 粗利金額
                _dataSet.MonthResult[ix].GrossProfitMoney = 0;
                _dataSet.MonthResult[ix].GrossProfitTargetMoney = 0;
                _dataSet.MonthResult[ix].GrossProfitAchievRate = 0;
            }

            for (int ix = 0; ix < _dataSet.MonthResult.Count; ix++)
            {
                // 純売上金額（前期）
                _dataSet.MonthResult[ix].BeforeGenuineSalesMoney = 0;
                // 粗利金額（前期）
                _dataSet.MonthResult[ix].BeforeGrossProfitMoney = 0;
            }
        }

        /// <summary>
        /// 売上実績照会データ行クラスクリア処理（在庫）
        /// </summary>
        private void ClrRowFromUIData_Stock()
        {
            for (int ix = 0; ix < _dataSet.StockResult.Count; ix++)
            {
                // 売上金額
                _dataSet.StockResult[ix].SalesMoney = 0;
                _dataSet.StockResult[ix].ReturnedGoodsPrice = 0;
                _dataSet.StockResult[ix].DiscountPrice = 0;

                // 純売上金額
                _dataSet.StockResult[ix].GenuineSalesMoney = 0;
                // 粗利金額
                _dataSet.StockResult[ix].GrossProfitMoney = 0;
            }
        }

        /// <summary>
        /// 売上実績照会データ行クラスクリア処理（出荷実績照会）
        /// </summary>
        private void ClrRowFromUIData_Shipment()
        {
            for (int ix = 0; ix < _dataSet.ShipmentResult.Count; ix++)
            {
                _dataSet.ShipmentResult[ix].Stock = 0;
                _dataSet.ShipmentResult[ix].Order = 0;
                _dataSet.ShipmentResult[ix].Sum = 0;
                _dataSet.ShipmentResult[ix].Slip = 0;
            }
        }

        /// <summary>
        /// 売上実績照会データ行クラスクリア処理（残高照会）
        /// </summary>
        private void ClrRowFromUIData_StockOrder()
        {
            _dataSet.StockOrderResult[0].AcpOdrTtl3TmBfBlDmd = 0;
            _dataSet.StockOrderResult[0].AcpOdrTtl2TmBfBlDmd = 0;
            _dataSet.StockOrderResult[0].LastTimeDemand = 0;
            _dataSet.StockOrderResult[0].LastTimeAccRec = 0;
            _dataSet.StockOrderResult[0].DepositDemand01 = 0;
            _dataSet.StockOrderResult[0].DepositMonth01 = 0;
            _dataSet.StockOrderResult[0].DepositDemand02 = 0;
            _dataSet.StockOrderResult[0].DepositMonth02 = 0;
            _dataSet.StockOrderResult[0].DepositDemand03 = 0;
            _dataSet.StockOrderResult[0].DepositMonth03 = 0;
            _dataSet.StockOrderResult[0].DepositDemand04 = 0;
            _dataSet.StockOrderResult[0].DepositMonth04 = 0;
            _dataSet.StockOrderResult[0].DepositDemand05 = 0;
            _dataSet.StockOrderResult[0].DepositMonth05 = 0;
            _dataSet.StockOrderResult[0].DepositDemand06 = 0;
            _dataSet.StockOrderResult[0].DepositMonth06 = 0;
            _dataSet.StockOrderResult[0].DepositDemand07 = 0;
            _dataSet.StockOrderResult[0].DepositMonth07 = 0;
            _dataSet.StockOrderResult[0].DepositDemand08 = 0;
            _dataSet.StockOrderResult[0].DepositMonth08 = 0;
            _dataSet.StockOrderResult[0].ThisTimeFeeDmdNrml = 0;
            _dataSet.StockOrderResult[0].ThisMThisTimeFeeDmdNrml = 0;
            _dataSet.StockOrderResult[0].ThisTimeDisDmdNrml = 0;
            _dataSet.StockOrderResult[0].ThisMThisTimeDisDmdNrml = 0;
            _dataSet.StockOrderResult[0].ThisTimeSumDmdNrml = 0;
            _dataSet.StockOrderResult[0].ThisMThisTimeSumDmdNrml = 0;
            _dataSet.StockOrderResult[0].SlipDemand = 0;
            _dataSet.StockOrderResult[0].SlipMonth = 0;
            _dataSet.StockOrderResult[0].PureSalesDemand = 0;
            _dataSet.StockOrderResult[0].PureSalesMonth = 0;
            _dataSet.StockOrderResult[0].PureReturnedDemand = 0;
            _dataSet.StockOrderResult[0].PureReturnedMonth = 0;
            _dataSet.StockOrderResult[0].PureDiscountDemand = 0;
            _dataSet.StockOrderResult[0].PureDiscountMonth = 0;
            _dataSet.StockOrderResult[0].PureGenuineSalesDemand = 0;
            _dataSet.StockOrderResult[0].PureGenuineSalesMonth = 0;
            _dataSet.StockOrderResult[0].PureGrossMonth = 0;
            _dataSet.StockOrderResult[0].SuperiorSalesDemand = 0;
            _dataSet.StockOrderResult[0].SuperiorSalesMonth = 0;
            _dataSet.StockOrderResult[0].SuperiorReturnedDemand = 0;
            _dataSet.StockOrderResult[0].SuperiorReturnedMonth = 0;
            _dataSet.StockOrderResult[0].SuperiorDiscountDemand = 0;
            _dataSet.StockOrderResult[0].SuperiorDiscountMonth = 0;
            _dataSet.StockOrderResult[0].SuperiorGenuineSalesDemand = 0;
            _dataSet.StockOrderResult[0].SuperiorGenuineSalesMonth = 0;
            _dataSet.StockOrderResult[0].SuperiorGrossMonth = 0;
            _dataSet.StockOrderResult[0].SumSalesDemand = 0;
            _dataSet.StockOrderResult[0].SumSalesMonth = 0;
            _dataSet.StockOrderResult[0].SumReturnedDemand = 0;
            _dataSet.StockOrderResult[0].SumReturnedMonth = 0;
            _dataSet.StockOrderResult[0].SumDiscountDemand = 0;
            _dataSet.StockOrderResult[0].SumDiscountMonth = 0;
            _dataSet.StockOrderResult[0].SumGenuineSalesDemand = 0;
            _dataSet.StockOrderResult[0].SumGenuineSalesMonth = 0;
            _dataSet.StockOrderResult[0].SumGrossMonth = 0;
            _dataSet.StockOrderResult[0].OfsThisSalesTax = 0;
            _dataSet.StockOrderResult[0].ThisMOfsThisSalesTax = 0;
            _dataSet.StockOrderResult[0].BalanceDemand = 0;
            _dataSet.StockOrderResult[0].BalanceMonth = 0;
        }

        /// <summary>
        /// 売上実績照会データ検索結果ワーク→売上実績照会データ行クラス設定処理（月次）
        /// </summary>
        /// <param name="ix">売上実績照会データ行番号</param>
        /// <param name="data">売上実績照会データ検索結果ワークオブジェクト</param>
        private void SetRowFromUIData_Month(int ix, SalesAnnualDataSelectResultWork data)
        {
            if (data.AUPYearMonth >= _companyBiginDate)
            {
                // --- ADD 2009/02/12 障害ID:11013対応------------------------------------------------------>>>>>
                if (data.RsltTtlDivCd == 0)
                // --- ADD 2009/02/12 障害ID:11013対応------------------------------------------------------<<<<<
                {
                    _dataSet.MonthResult[ix].RowSetFlg = data.AUPYearMonth;

                    // 2009.03.02 30413 犬飼 返品値引の符号を反転させる >>>>>>START
                    // 売上金額
                    _dataSet.MonthResult[ix].SalesMoney = _dataSet.MonthResult[ix].SalesMoney + data.SalesMoney;
                    //_dataSet.MonthResult[ix].ReturnedGoodsPrice = _dataSet.MonthResult[ix].ReturnedGoodsPrice + data.SalesRetGoodsPrice;
                    //_dataSet.MonthResult[ix].DiscountPrice = _dataSet.MonthResult[ix].DiscountPrice + data.DiscountPrice;
                    _dataSet.MonthResult[ix].ReturnedGoodsPrice = _dataSet.MonthResult[ix].ReturnedGoodsPrice - data.SalesRetGoodsPrice;
                    _dataSet.MonthResult[ix].DiscountPrice = _dataSet.MonthResult[ix].DiscountPrice - data.DiscountPrice;
                    // 2009.03.02 30413 犬飼 返品値引の符号を反転させる <<<<<<END
            
                    // 純売上金額
                    _dataSet.MonthResult[ix].GenuineSalesMoney = _dataSet.MonthResult[ix].GenuineSalesMoney + data.SalesMoney + data.SalesRetGoodsPrice + data.DiscountPrice;
                    _dataSet.MonthResult[ix].TargetMoney = data.SalesTargetMoney;

                    // 粗利金額
                    //_dataSet.MonthResult[ix].GrossProfitMoney = _dataSet.MonthResult[ix].GrossProfitMoney + data.GrossProfit; // DEL 2009/04/14
                    //_dataSet.MonthResult[ix].GrossProfitMoney = _dataSet.MonthResult[ix].GrossProfitMoney + data.SalesMoney - data.Cost; // ADD 2009/04/14 DEL 2009/09/07

                    _dataSet.MonthResult[ix].GrossProfitMoney = _dataSet.MonthResult[ix].GrossProfitMoney + data.GrossProfit; // ADD 2009/09/07

                    _dataSet.MonthResult[ix].GrossProfitTargetMoney = data.SalesTargetProfit;
                }
            }
            else if ((data.AUPYearMonth < _companyBiginDate) &&
                     (data.AUPYearMonth >= _companyBiginDate - 100))
            {
                // --- UPD 2009/09/07 ------------------------------------------------------>>>>>
                //// 純売上金額（前期）
                //_dataSet.MonthResult[ix].BeforeGenuineSalesMoney = _dataSet.MonthResult[ix].BeforeGenuineSalesMoney + data.SalesMoney + data.SalesRetGoodsPrice + data.DiscountPrice;
                //// 粗利金額（前期）
                ////_dataSet.MonthResult[ix].BeforeGrossProfitMoney = _dataSet.MonthResult[ix].BeforeGrossProfitMoney + data.GrossProfit; // DEL 2009/04/14
                //_dataSet.MonthResult[ix].BeforeGrossProfitMoney = _dataSet.MonthResult[ix].BeforeGrossProfitMoney + data.SalesMoney - data.Cost; // ADD 2009/04/14

                if (data.RsltTtlDivCd == 0)
                {
                    // 純売上金額（前期）
                    _dataSet.MonthResult[ix].BeforeGenuineSalesMoney = _dataSet.MonthResult[ix].BeforeGenuineSalesMoney + data.SalesMoney + data.SalesRetGoodsPrice + data.DiscountPrice;
                    // 粗利金額（前期）
                    _dataSet.MonthResult[ix].BeforeGrossProfitMoney = _dataSet.MonthResult[ix].BeforeGrossProfitMoney + data.GrossProfit;
                }
                // --- UPD 2009/09/07 ------------------------------------------------------<<<<<


            }
        }

        /// <summary>
        /// 売上実績照会データ検索結果ワーク→売上実績照会データ行クラス設定処理（合計）
        /// </summary>
        /// <param name="ix">売上実績照会データ行番号</param>
        /// <param name="data">売上実績照会データ検索結果ワークオブジェクト</param>
        private void SetRowFromUIData_Total(int ix, SalesAnnualDataSelectResultWork data)
        {
            if (data.AUPYearMonth >= _companyBiginDate)
            {
                // 2009.03.02 30413 犬飼 返品値引の符号を反転させる >>>>>>START
                if (data.RsltTtlDivCd == 0)
                {
                    // 売上金額
                    _dataSet.MonthResult[ix].SalesMoney = _dataSet.MonthResult[ix].SalesMoney + data.SalesMoney;
                    //_dataSet.MonthResult[ix].ReturnedGoodsPrice = _dataSet.MonthResult[ix].ReturnedGoodsPrice + data.SalesRetGoodsPrice;
                    //_dataSet.MonthResult[ix].DiscountPrice = _dataSet.MonthResult[ix].DiscountPrice + data.DiscountPrice;
                    _dataSet.MonthResult[ix].ReturnedGoodsPrice = _dataSet.MonthResult[ix].ReturnedGoodsPrice - data.SalesRetGoodsPrice;
                    _dataSet.MonthResult[ix].DiscountPrice = _dataSet.MonthResult[ix].DiscountPrice - data.DiscountPrice;

                    // 純売上金額
                    _dataSet.MonthResult[ix].GenuineSalesMoney = _dataSet.MonthResult[ix].GenuineSalesMoney + data.SalesMoney + data.SalesRetGoodsPrice + data.DiscountPrice;

                    // 粗利金額
                    //_dataSet.MonthResult[ix].GrossProfitMoney = _dataSet.MonthResult[ix].GrossProfitMoney + data.GrossProfit; // DEL 2009/04/14
                    //_dataSet.MonthResult[ix].GrossProfitMoney = _dataSet.MonthResult[ix].GrossProfitMoney + data.SalesMoney - data.Cost; // ADD 2009/04/14 DEL 2009/09/07

                    _dataSet.MonthResult[ix].GrossProfitMoney = _dataSet.MonthResult[ix].GrossProfitMoney + data.GrossProfit; // ADD 2009/09/07

                    // 目標値設定
                    if (beforeMonth != Int32.Parse(data.AUPYearMonth.ToString().Substring(4, 2)))
                    {
                        _dataSet.MonthResult[ix].TargetMoney = _dataSet.MonthResult[ix].TargetMoney + data.SalesTargetMoney;
                        _dataSet.MonthResult[ix].GrossProfitTargetMoney = _dataSet.MonthResult[ix].GrossProfitTargetMoney + data.SalesTargetProfit;
                        beforeMonth = Int32.Parse(data.AUPYearMonth.ToString().Substring(4, 2));
                    }
                }
                // 2009.03.02 30413 犬飼 返品値引の符号を反転させる <<<<<<END
            }
            else if ((data.AUPYearMonth < _companyBiginDate) &&
                     (data.AUPYearMonth >= _companyBiginDate - 100))
            {
                // --- UPD 2009/09/07 ------------------------------------------------------>>>>>
                //// 純売上金額（前期）
                //_dataSet.MonthResult[ix].BeforeGenuineSalesMoney    = _dataSet.MonthResult[ix].BeforeGenuineSalesMoney + data.SalesMoney + data.SalesRetGoodsPrice + data.DiscountPrice;
                //// 粗利金額（前期）
                ////_dataSet.MonthResult[ix].BeforeGrossProfitMoney     = _dataSet.MonthResult[ix].BeforeGrossProfitMoney + data.GrossProfit; // DEL 2009/04/14
                //_dataSet.MonthResult[ix].BeforeGrossProfitMoney = _dataSet.MonthResult[ix].BeforeGrossProfitMoney + data.SalesMoney - data.Cost; // ADD 2009/04/14 DEL 2009/09/07

                if (data.RsltTtlDivCd == 0)
                {
                    // 純売上金額（前期）
                    _dataSet.MonthResult[ix].BeforeGenuineSalesMoney = _dataSet.MonthResult[ix].BeforeGenuineSalesMoney + data.SalesMoney + data.SalesRetGoodsPrice + data.DiscountPrice;
                    // 粗利金額（前期）
                    _dataSet.MonthResult[ix].BeforeGrossProfitMoney = _dataSet.MonthResult[ix].BeforeGrossProfitMoney + data.GrossProfit;
                }
                // --- UPD 2009/09/07 ------------------------------------------------------<<<<<

            }
        }

        /// <summary>
        /// 売上実績照会データ検索結果ワーク→売上実績照会データ行クラス設定処理（在庫）
        /// </summary>
        /// <param name="ix">売上実績照会データ行番号</param>
        /// <param name="data">売上実績照会データ検索結果ワークオブジェクト</param>
        private void SetRowFromUIData_Stock(int ix, SalesAnnualDataSelectResultWork data)
        {
            // 2009.03.02 30413 犬飼 返品値引の符号を反転させる >>>>>>START
            switch (ix)
            {
                case 0:
                    if (data.RsltTtlDivCd == 2)
                    {
                        // 売上金額
                        _dataSet.StockResult[ix].SalesMoney = _dataSet.StockResult[ix].SalesMoney + data.SalesMoney;
                        //_dataSet.StockResult[ix].ReturnedGoodsPrice = _dataSet.StockResult[ix].ReturnedGoodsPrice + data.SalesRetGoodsPrice;
                        //_dataSet.StockResult[ix].DiscountPrice = _dataSet.StockResult[ix].DiscountPrice + data.DiscountPrice;
                        _dataSet.StockResult[ix].ReturnedGoodsPrice = _dataSet.StockResult[ix].ReturnedGoodsPrice - data.SalesRetGoodsPrice;
                        _dataSet.StockResult[ix].DiscountPrice = _dataSet.StockResult[ix].DiscountPrice - data.DiscountPrice;


                        // 純売上金額
                        _dataSet.StockResult[ix].GenuineSalesMoney = _dataSet.StockResult[ix].GenuineSalesMoney + data.SalesMoney + data.SalesRetGoodsPrice + data.DiscountPrice;

                        // 粗利金額
                        //_dataSet.StockResult[ix].GrossProfitMoney = _dataSet.StockResult[ix].GrossProfitMoney + data.GrossProfit; // DEL 2009/04/14
                        //_dataSet.StockResult[ix].GrossProfitMoney = _dataSet.StockResult[ix].GrossProfitMoney + data.SalesMoney - data.Cost; // ADD 2009/04/14 DEL 2009/09/07

                        _dataSet.StockResult[ix].GrossProfitMoney = _dataSet.StockResult[ix].GrossProfitMoney + data.GrossProfit; // ADD 2009/09/07
                    }
                    // 純正
                    break;
                case 1:
                    // 優良
                    if (data.RsltTtlDivCd == 2)
                    {
                        // 売上金額
                        _dataSet.StockResult[ix].SalesMoney = _dataSet.StockResult[ix].SalesMoney - data.SalesMoney;
                        //_dataSet.StockResult[ix].ReturnedGoodsPrice = _dataSet.StockResult[ix].ReturnedGoodsPrice - data.SalesRetGoodsPrice;
                        //_dataSet.StockResult[ix].DiscountPrice = _dataSet.StockResult[ix].DiscountPrice - data.DiscountPrice;
                        _dataSet.StockResult[ix].ReturnedGoodsPrice = _dataSet.StockResult[ix].ReturnedGoodsPrice + data.SalesRetGoodsPrice;
                        _dataSet.StockResult[ix].DiscountPrice = _dataSet.StockResult[ix].DiscountPrice + data.DiscountPrice;


                        // 純売上金額
                        _dataSet.StockResult[ix].GenuineSalesMoney = _dataSet.StockResult[ix].GenuineSalesMoney - (data.SalesMoney + data.SalesRetGoodsPrice + data.DiscountPrice);

                        // 粗利金額
                        //_dataSet.StockResult[ix].GrossProfitMoney = _dataSet.StockResult[ix].GrossProfitMoney - data.GrossProfit; // DEL 2009/04/14
                        //_dataSet.StockResult[ix].GrossProfitMoney = _dataSet.StockResult[ix].GrossProfitMoney - (data.SalesMoney - data.Cost); // ADD 2009/04/14 DEL 2009/09/07

                        _dataSet.StockResult[ix].GrossProfitMoney = _dataSet.StockResult[ix].GrossProfitMoney - data.GrossProfit; // ADD 2009/09/07
                    }
                    else if (data.RsltTtlDivCd == 0)
                    {
                        // 売上金額
                        _dataSet.StockResult[ix].SalesMoney = _dataSet.StockResult[ix].SalesMoney + data.SalesMoney;
                        //_dataSet.StockResult[ix].ReturnedGoodsPrice = _dataSet.StockResult[ix].ReturnedGoodsPrice + data.SalesRetGoodsPrice;
                        //_dataSet.StockResult[ix].DiscountPrice = _dataSet.StockResult[ix].DiscountPrice + data.DiscountPrice;
                        _dataSet.StockResult[ix].ReturnedGoodsPrice = _dataSet.StockResult[ix].ReturnedGoodsPrice - data.SalesRetGoodsPrice;
                        _dataSet.StockResult[ix].DiscountPrice = _dataSet.StockResult[ix].DiscountPrice - data.DiscountPrice;


                        // 純売上金額
                        _dataSet.StockResult[ix].GenuineSalesMoney = _dataSet.StockResult[ix].GenuineSalesMoney + data.SalesMoney + data.SalesRetGoodsPrice + data.DiscountPrice;

                        // 粗利金額
                        //_dataSet.StockResult[ix].GrossProfitMoney = _dataSet.StockResult[ix].GrossProfitMoney + data.GrossProfit; // DEL 2009/04/14
                        //_dataSet.StockResult[ix].GrossProfitMoney = _dataSet.StockResult[ix].GrossProfitMoney + data.SalesMoney - data.Cost; // ADD 2009/04/14 DEL 2009/09/07

                        _dataSet.StockResult[ix].GrossProfitMoney = _dataSet.StockResult[ix].GrossProfitMoney + data.GrossProfit; // ADD 2009/09/07
                    }
                    break;
                case 2:
                    // 合計
                    if (data.RsltTtlDivCd == 0)
                    {
                        // 売上金額
                        _dataSet.StockResult[ix].SalesMoney = _dataSet.StockResult[ix].SalesMoney + data.SalesMoney;
                        //_dataSet.StockResult[ix].ReturnedGoodsPrice = _dataSet.StockResult[ix].ReturnedGoodsPrice + data.SalesRetGoodsPrice;
                        //_dataSet.StockResult[ix].DiscountPrice = _dataSet.StockResult[ix].DiscountPrice + data.DiscountPrice;
                        _dataSet.StockResult[ix].ReturnedGoodsPrice = _dataSet.StockResult[ix].ReturnedGoodsPrice - data.SalesRetGoodsPrice;
                        _dataSet.StockResult[ix].DiscountPrice = _dataSet.StockResult[ix].DiscountPrice - data.DiscountPrice;


                        // 純売上金額
                        _dataSet.StockResult[ix].GenuineSalesMoney = _dataSet.StockResult[ix].GenuineSalesMoney + data.SalesMoney + data.SalesRetGoodsPrice + data.DiscountPrice;

                        // 粗利金額
                        //_dataSet.StockResult[ix].GrossProfitMoney = _dataSet.StockResult[ix].GrossProfitMoney + data.GrossProfit; // DEL 2009/04/14
                        //_dataSet.StockResult[ix].GrossProfitMoney = _dataSet.StockResult[ix].GrossProfitMoney + data.SalesMoney - data.Cost; // ADD 2009/04/14 DEL 2009/09/07
                        
                        _dataSet.StockResult[ix].GrossProfitMoney = _dataSet.StockResult[ix].GrossProfitMoney + data.GrossProfit; // ADD 2009/09/07
                    }
                    break;

                case 3:
                    // 在庫
                    if (data.RsltTtlDivCd == 1)
                    {
                        // 売上金額
                        _dataSet.StockResult[ix].SalesMoney = _dataSet.StockResult[ix].SalesMoney + data.SalesMoney;
                        //_dataSet.StockResult[ix].ReturnedGoodsPrice = _dataSet.StockResult[ix].ReturnedGoodsPrice + data.SalesRetGoodsPrice;
                        //_dataSet.StockResult[ix].DiscountPrice = _dataSet.StockResult[ix].DiscountPrice + data.DiscountPrice;
                        _dataSet.StockResult[ix].ReturnedGoodsPrice = _dataSet.StockResult[ix].ReturnedGoodsPrice - data.SalesRetGoodsPrice;
                        _dataSet.StockResult[ix].DiscountPrice = _dataSet.StockResult[ix].DiscountPrice - data.DiscountPrice;


                        // 純売上金額
                        _dataSet.StockResult[ix].GenuineSalesMoney = _dataSet.StockResult[ix].GenuineSalesMoney + data.SalesMoney + data.SalesRetGoodsPrice + data.DiscountPrice;

                        // 粗利金額
                        //_dataSet.StockResult[ix].GrossProfitMoney = _dataSet.StockResult[ix].GrossProfitMoney + data.GrossProfit; // DEL 2009/04/14
                        //_dataSet.StockResult[ix].GrossProfitMoney = _dataSet.StockResult[ix].GrossProfitMoney + data.SalesMoney - data.Cost; // ADD 2009/04/14 DEL 2009/09/07

                        _dataSet.StockResult[ix].GrossProfitMoney = _dataSet.StockResult[ix].GrossProfitMoney + data.GrossProfit; // ADD 2009/09/07
                    }
                    break;
                case 4:
                    //　取寄
                    if (data.RsltTtlDivCd == 1)
                    {
                        // 売上金額
                        _dataSet.StockResult[ix].SalesMoney = _dataSet.StockResult[ix].SalesMoney - data.SalesMoney;
                        //_dataSet.StockResult[ix].ReturnedGoodsPrice = _dataSet.StockResult[ix].ReturnedGoodsPrice - data.SalesRetGoodsPrice;
                        //_dataSet.StockResult[ix].DiscountPrice = _dataSet.StockResult[ix].DiscountPrice - data.DiscountPrice;
                        _dataSet.StockResult[ix].ReturnedGoodsPrice = _dataSet.StockResult[ix].ReturnedGoodsPrice + data.SalesRetGoodsPrice;
                        _dataSet.StockResult[ix].DiscountPrice = _dataSet.StockResult[ix].DiscountPrice + data.DiscountPrice;


                        // 純売上金額
                        _dataSet.StockResult[ix].GenuineSalesMoney = _dataSet.StockResult[ix].GenuineSalesMoney - (data.SalesMoney + data.SalesRetGoodsPrice + data.DiscountPrice);

                        // 粗利金額
                        //_dataSet.StockResult[ix].GrossProfitMoney = _dataSet.StockResult[ix].GrossProfitMoney - data.GrossProfit; // DEL 2009/04/14
                        //_dataSet.StockResult[ix].GrossProfitMoney = _dataSet.StockResult[ix].GrossProfitMoney - (data.SalesMoney - data.Cost); // ADD 2009/04/14 DEL 2009/09/07

                        _dataSet.StockResult[ix].GrossProfitMoney = _dataSet.StockResult[ix].GrossProfitMoney - data.GrossProfit; // ADD 2009/09/07
                    }
                    else if (data.RsltTtlDivCd == 0)
                    {
                        // 売上金額
                        _dataSet.StockResult[ix].SalesMoney = _dataSet.StockResult[ix].SalesMoney + data.SalesMoney;
                        //_dataSet.StockResult[ix].ReturnedGoodsPrice = _dataSet.StockResult[ix].ReturnedGoodsPrice + data.SalesRetGoodsPrice;
                        //_dataSet.StockResult[ix].DiscountPrice = _dataSet.StockResult[ix].DiscountPrice + data.DiscountPrice;
                        _dataSet.StockResult[ix].ReturnedGoodsPrice = _dataSet.StockResult[ix].ReturnedGoodsPrice - data.SalesRetGoodsPrice;
                        _dataSet.StockResult[ix].DiscountPrice = _dataSet.StockResult[ix].DiscountPrice - data.DiscountPrice;


                        // 純売上金額
                        _dataSet.StockResult[ix].GenuineSalesMoney = _dataSet.StockResult[ix].GenuineSalesMoney + data.SalesMoney + data.SalesRetGoodsPrice + data.DiscountPrice;

                        // 粗利金額
                        //_dataSet.StockResult[ix].GrossProfitMoney = _dataSet.StockResult[ix].GrossProfitMoney + data.GrossProfit; // DEL 2009/04/14
                        //_dataSet.StockResult[ix].GrossProfitMoney = _dataSet.StockResult[ix].GrossProfitMoney + data.SalesMoney - data.Cost; // ADD 2009/04/14 DEL 2009/09/07

                        _dataSet.StockResult[ix].GrossProfitMoney = _dataSet.StockResult[ix].GrossProfitMoney + data.GrossProfit; // ADD 2009/09/07
                    }
                    break;
                case 5:
                    // 合計
                    if (data.RsltTtlDivCd == 0)
                    {
                        // 売上金額
                        _dataSet.StockResult[ix].SalesMoney = _dataSet.StockResult[ix].SalesMoney + data.SalesMoney;
                        //_dataSet.StockResult[ix].ReturnedGoodsPrice = _dataSet.StockResult[ix].ReturnedGoodsPrice + data.SalesRetGoodsPrice;
                        //_dataSet.StockResult[ix].DiscountPrice = _dataSet.StockResult[ix].DiscountPrice + data.DiscountPrice;
                        _dataSet.StockResult[ix].ReturnedGoodsPrice = _dataSet.StockResult[ix].ReturnedGoodsPrice - data.SalesRetGoodsPrice;
                        _dataSet.StockResult[ix].DiscountPrice = _dataSet.StockResult[ix].DiscountPrice - data.DiscountPrice;


                        // 純売上金額
                        _dataSet.StockResult[ix].GenuineSalesMoney = _dataSet.StockResult[ix].GenuineSalesMoney + data.SalesMoney + data.SalesRetGoodsPrice + data.DiscountPrice;

                        // 粗利金額
                        //_dataSet.StockResult[ix].GrossProfitMoney = _dataSet.StockResult[ix].GrossProfitMoney + data.GrossProfit; // DEL 2009/04/14
                        //_dataSet.StockResult[ix].GrossProfitMoney = _dataSet.StockResult[ix].GrossProfitMoney + data.SalesMoney - data.Cost; // ADD 2009/04/14 DEL 2009/09/07

                        _dataSet.StockResult[ix].GrossProfitMoney = _dataSet.StockResult[ix].GrossProfitMoney + data.GrossProfit; // ADD 2009/09/07
                    }
                    break;
            }
            // 2009.03.02 30413 犬飼 返品値引の符号を反転させる <<<<<<END
        }

        /// <summary>
        /// 売上実績照会データ行クラス設定処理（合計/平均）
        /// </summary>
        /// <param name="ix">売上実績照会データ合計行番号</param>
        /// <param name="target">売上実績照会データ平均行番号</param>
        /// <param name="data">対象行件数</param>
        private void SetRowFromUIData_Average(int ix, int target, int count)
        {
            double rate;

            // 合計純売上達成率
            if (_dataSet.MonthResult[ix].IsTargetMoneyNull())
            {
                _dataSet.MonthResult[ix].SetAchievementRateNull();
            }
            else if (_dataSet.MonthResult[ix].TargetMoney == 0)
            {
                rate = 0;
                _dataSet.MonthResult[ix].AchievementRate = rate;
            }
            else
            {
                // -- UPD 2009/09/07 ------------------------------------>>>
                //四捨五入するように変更
                //rate = ((double)_dataSet.MonthResult[ix].GenuineSalesMoney / (double)_dataSet.MonthResult[ix].TargetMoney) * 100;
                rate = this.FracCalcMoneyD((double)_dataSet.MonthResult[ix].GenuineSalesMoney / (double)_dataSet.MonthResult[ix].TargetMoney, 0.0001, 2) * 100;
                // -- UPD 2009/09/07 ------------------------------------<<<
                _dataSet.MonthResult[ix].AchievementRate = rate;
            }
            

            // 合計粗利達成率
            if (_dataSet.MonthResult[ix].IsGrossProfitTargetMoneyNull())
            {
                _dataSet.MonthResult[ix].SetGrossProfitAchievRateNull();
            }
            else if (_dataSet.MonthResult[ix].GrossProfitTargetMoney == 0)
            {
                rate = 0;
                _dataSet.MonthResult[ix].GrossProfitAchievRate = rate;
            }
            else
            {
                // -- UPD 2009/09/07 ------------------------------------>>>
                //四捨五入するように変更
                rate = this.FracCalcMoneyD((double)_dataSet.MonthResult[ix].GrossProfitMoney / (double)_dataSet.MonthResult[ix].GrossProfitTargetMoney, 0.0001, 2) * 100;
                // -- UPD 2009/09/07 ------------------------------------<<<
                _dataSet.MonthResult[ix].GrossProfitAchievRate = rate;
            }
            

            if (count > 0)
            {
                // -- UPD 2009/09/07 --------------------------------->>>
                //四捨五入するように変更
                //// 平均売上金額
                //_dataSet.MonthResult[target].SalesMoney = _dataSet.MonthResult[ix].SalesMoney / count;
                //_dataSet.MonthResult[target].ReturnedGoodsPrice = _dataSet.MonthResult[ix].ReturnedGoodsPrice / count;
                //_dataSet.MonthResult[target].DiscountPrice = _dataSet.MonthResult[ix].DiscountPrice / count;

                //// 平均純売上金額
                //_dataSet.MonthResult[target].GenuineSalesMoney = _dataSet.MonthResult[ix].GenuineSalesMoney / count;
                //_dataSet.MonthResult[target].TargetMoney = _dataSet.MonthResult[ix].TargetMoney / count;
                //if (_dataSet.MonthResult[target].TargetMoney == 0)
                //{
                //    rate = 0;
                //}
                //else
                //{
                //    rate = ((double)_dataSet.MonthResult[target].GenuineSalesMoney / (double)_dataSet.MonthResult[target].TargetMoney) * 100;
                //}
                //_dataSet.MonthResult[target].AchievementRate = rate;

                //// 平均粗利金額
                //_dataSet.MonthResult[target].GrossProfitMoney = _dataSet.MonthResult[ix].GrossProfitMoney / count;
                //_dataSet.MonthResult[target].GrossProfitTargetMoney = _dataSet.MonthResult[ix].GrossProfitTargetMoney / count;
                //if (_dataSet.MonthResult[target].GrossProfitTargetMoney == 0)
                //{
                //    rate = 0;
                //}
                //else
                //{
                //    rate = ((double)_dataSet.MonthResult[target].GrossProfitMoney / (double)_dataSet.MonthResult[target].GrossProfitTargetMoney) * 100;
                //}
                //_dataSet.MonthResult[target].GrossProfitAchievRate = rate;

                //// 平均純売上金額（前期）
                // _dataSet.MonthResult[target].BeforeGenuineSalesMoney = _dataSet.MonthResult[ix].BeforeGenuineSalesMoney / 12;

                //// 平均粗利金額（前期）
                //_dataSet.MonthResult[target].BeforeGrossProfitMoney = _dataSet.MonthResult[ix].BeforeGrossProfitMoney / 12;

                // 平均売上金額
                _dataSet.MonthResult[target].SalesMoney = this.FracCalcMoney((double)_dataSet.MonthResult[ix].SalesMoney / (double)count, 1.00, 2);
                _dataSet.MonthResult[target].ReturnedGoodsPrice = this.FracCalcMoney((double)_dataSet.MonthResult[ix].ReturnedGoodsPrice / (double)count, 1.00, 2);
                _dataSet.MonthResult[target].DiscountPrice = this.FracCalcMoney((double)_dataSet.MonthResult[ix].DiscountPrice / (double)count, 1.00, 2);

                // 平均純売上金額
                _dataSet.MonthResult[target].GenuineSalesMoney = this.FracCalcMoney((double)_dataSet.MonthResult[ix].GenuineSalesMoney / (double)count, 1.00, 2);
                _dataSet.MonthResult[target].TargetMoney = this.FracCalcMoney((double)_dataSet.MonthResult[ix].TargetMoney / (double)count, 1.00, 2);
                if (_dataSet.MonthResult[target].TargetMoney == 0)
                {
                    rate = 0;
                }
                else
                {
                    rate = this.FracCalcMoneyD((double)_dataSet.MonthResult[target].GenuineSalesMoney / (double)_dataSet.MonthResult[target].TargetMoney, 0.0001, 2) * 100;
                }
                _dataSet.MonthResult[target].AchievementRate = rate;

                // 平均粗利金額
                _dataSet.MonthResult[target].GrossProfitMoney = this.FracCalcMoney((double)_dataSet.MonthResult[ix].GrossProfitMoney / (double)count, 1.00, 2);
                _dataSet.MonthResult[target].GrossProfitTargetMoney = this.FracCalcMoney((double)_dataSet.MonthResult[ix].GrossProfitTargetMoney / (double)count, 1.00, 2);
                if (_dataSet.MonthResult[target].GrossProfitTargetMoney == 0)
                {
                    rate = 0;
                }
                else
                {
                    rate = this.FracCalcMoneyD((double)_dataSet.MonthResult[target].GrossProfitMoney / (double)_dataSet.MonthResult[target].GrossProfitTargetMoney, 0.0001, 2) * 100;
                }
                _dataSet.MonthResult[target].GrossProfitAchievRate = rate;

                // 平均純売上金額（前期）
                _dataSet.MonthResult[target].BeforeGenuineSalesMoney = this.FracCalcMoney((double)_dataSet.MonthResult[ix].BeforeGenuineSalesMoney / 12.00, 1.00, 2);

                // 平均粗利金額（前期）
                _dataSet.MonthResult[target].BeforeGrossProfitMoney = this.FracCalcMoney((double)_dataSet.MonthResult[ix].BeforeGrossProfitMoney / 12.00, 1.00, 2);
                // -- UPD 2009/09/07 ---------------------------------<<<
            }
        }

        /// <summary>
        /// 売上実績照会データ行クラス設定処理（在庫・取寄・合計）
        /// </summary>
        /// <param name="ix">売上実績照会データ在庫行番号</param>
        /// <param name="target">売上実績照会データ取寄行番号</param>
        /// <param name="totalRow">売上実績照会データ合計行番号</param>
        /// <param name="data">売上実績照会データ行クラス</param>
        private void SetRowFromUIData_Order(int ix, int target, int totalRow, InventoryUpdateDataSet.MonthResultRow row)
        {
            // 取寄売上金額
            _dataSet.StockResult[target].SalesMoney = row.SalesMoney - _dataSet.StockResult[ix].SalesMoney;
            _dataSet.StockResult[target].ReturnedGoodsPrice = row.ReturnedGoodsPrice - _dataSet.StockResult[ix].ReturnedGoodsPrice;
            _dataSet.StockResult[target].DiscountPrice = row.DiscountPrice - _dataSet.StockResult[ix].DiscountPrice;

            // 取寄純売上金額
            _dataSet.StockResult[target].GenuineSalesMoney = row.GenuineSalesMoney - _dataSet.StockResult[ix].GenuineSalesMoney;
            // 取寄粗利金額
            _dataSet.StockResult[target].GrossProfitMoney = row.GrossProfitMoney - _dataSet.StockResult[ix].GrossProfitMoney;

            // 合計売上金額
            _dataSet.StockResult[totalRow].SalesMoney = row.SalesMoney;
            _dataSet.StockResult[totalRow].ReturnedGoodsPrice = row.ReturnedGoodsPrice;
            _dataSet.StockResult[totalRow].DiscountPrice = row.DiscountPrice;

            // 合計純売上金額
            _dataSet.StockResult[totalRow].GenuineSalesMoney = row.GenuineSalesMoney;
            // 合計粗利金額
            _dataSet.StockResult[totalRow].GrossProfitMoney = row.GrossProfitMoney;
        }

        /// <summary>
        /// 売上実績照会データ行クラス設定処理（集計対象外月を空白に）
        /// </summary>
        /// <param name="ix">売上実績照会データ合計行番号</param>
        /// <param name="target">売上実績照会データ平均行番号</param>
        /// <param name="data">対象行件数</param>
        private void SetRowFromUIData_Null(int ix, int target, int count)
        {
            int year = (int)_companyBiginDate / 100;

            int companyBiginMonth = this._companyInf.CompanyBiginMonth;
            int biginMonth = companyBiginMonth + ix;
            if (biginMonth > 12) { year = year + 1; }
            year = year * 100;

            year = year + _dataSet.MonthResult[ix].RowMonth;
            // 集計対象外月は空白
            // --- CHG 2009/02/25 障害ID:11918対応------------------------------------------------------>>>>>
            //if (year >= _companyNowDate)
            if (year > _companyNowDate)
            // --- CHG 2009/02/25 障害ID:11918対応------------------------------------------------------<<<<<
            {
                _dataSet.MonthResult[ix].SetSalesMoneyNull();
                _dataSet.MonthResult[ix].SetReturnedGoodsPriceNull();
                _dataSet.MonthResult[ix].SetDiscountPriceNull();
                _dataSet.MonthResult[ix].SetGenuineSalesMoneyNull();
                _dataSet.MonthResult[ix].SetTargetMoneyNull();
                _dataSet.MonthResult[ix].SetGrossProfitMoneyNull();
                _dataSet.MonthResult[ix].SetGrossProfitTargetMoneyNull();
                _dataSet.MonthResult[ix].SetAchievementRateNull();
                _dataSet.MonthResult[ix].SetGrossProfitAchievRateNull();

                _dataSet.ShipmentResult[ix].SetStockNull();
                _dataSet.ShipmentResult[ix].SetOrderNull();
                _dataSet.ShipmentResult[ix].SetSumNull();
                _dataSet.ShipmentResult[ix].SetSlipNull();
            }
            
        }
        
        /// <summary>
        /// 売上実績照会データ検索結果ワーク→売上実績照会データ行クラス設定処理（出荷実績照会用）
        /// </summary>
        /// <param name="ix">売上実績照会データ行番号</param>
        /// <param name="data">売上実績照会データ検索結果ワークオブジェクト</param>
        /// <param name="totalDiv">0:拠点 1:得意先 2:担当者 3:受注者 4:発行者 5:地区 6:業種</param>
        /// <br>Note       : Redmine#47035 売上年間実績照会の出荷実績照会を開いた場合の伝票枚数の集計が不正の対応</br>
        /// <br>Programmer : 田思春</br>
        /// <br>Date       : 2015/08/18</br>
        //private void SetRowFromUIData_ShipmentMonth(int ix, SalesAnnualDataSelectResultWork data) //DEL 2015/08/18 田思春 For Redmine#47035 伝票枚数の集計修正
        private void SetRowFromUIData_ShipmentMonth(int ix, SalesAnnualDataSelectResultWork data, int totalDiv) // ADD 2015/08/18 田思春 For Redmine#47035 伝票枚数の集計修正
        {
            if (data.AUPYearMonth >= _companyBiginDate)
            {
                // 出荷回数
                if (data.RsltTtlDivCd == 1)
                {
                    _dataSet.ShipmentResult[ix].Stock = _dataSet.ShipmentResult[ix].Stock + data.SalesTimes;
                    _dataSet.ShipmentResult[ix].Order = _dataSet.ShipmentResult[ix].Order - data.SalesTimes;
                }
                else if (data.RsltTtlDivCd == 0)
                {
                    _dataSet.ShipmentResult[ix].Order = _dataSet.ShipmentResult[ix].Order + data.SalesTimes;
                    _dataSet.ShipmentResult[ix].Sum = _dataSet.ShipmentResult[ix].Sum + data.SalesTimes;
                }

                // 伝票枚数
                //_dataSet.ShipmentResult[ix].Slip = data.TermSalesSlipCount; // DEL 2009/09/07
                // --- ADD 2015/08/18 田思春 For Redmine#47035 伝票枚数の集計修正  -------------------------------->>>>>
                if (totalDiv == 0)
                {
                    // 集計区分は「拠点」の場合、伝票枚数は、月度毎に最後の１レコードの伝票枚数を使用する。
                    _dataSet.ShipmentResult[ix].Slip = data.TermSalesSlipCount;
                }
                else
                {
                // --- ADD 2015/08/18 田思春 For Redmine#47035 伝票枚数の集計修正 --------------------------------<<<<<
                    _dataSet.ShipmentResult[ix].Slip = _dataSet.ShipmentResult[ix].Slip + data.TermSalesSlipCount; // ADD 2009/09/07
                }//　ADD 2015/08/18 田思春 For Redmine#47035 伝票枚数の集計修正
                           
            }
        }

        /// <summary>
        /// 売上実績照会データ検索結果ワーク→売上実績照会データ行クラス設定処理（在庫）
        /// </summary>
        /// <param name="ix">売上実績照会データ行番号</param>
        /// <param name="data">売上実績照会データ検索結果ワークオブジェクト</param>
        private void SetRowFromUIData_StockOrder(int ix, SalesAnnualDataSelectResultWork data)
        {
            switch (ix)
            {
                // 純正 - 在庫
                case 0:
                    if (data.GoodsKindCode == 0 && data.SalesOrderDivCd == 1)
                    {
                        SetData_StockOrder(ix, data);
                    }
                    // 純正
                    break;
                // 純正 - 取寄
                case 1:
                    if (data.GoodsKindCode == 0 && data.SalesOrderDivCd == 0)
                    {
                        SetData_StockOrder(ix, data);
                    }
                    break;
                // 純正 - 合計
                case 2:
                    if (data.GoodsKindCode == 0)
                    {
                        SetData_StockOrder(ix, data);
                    }
                    break;
                // 優良 - 在庫
                case 3:
                    if (data.GoodsKindCode == 1 && data.SalesOrderDivCd == 1)
                    {
                        SetData_StockOrder(ix, data);
                    }
                    break;
                // 優良 - 取寄
                case 4:
                    if (data.GoodsKindCode == 1 && data.SalesOrderDivCd == 0)
                    {
                        SetData_StockOrder(ix, data);
                    }
                    break;
                // 優良 - 合計
                case 5:
                    if (data.GoodsKindCode == 1)
                    {
                        SetData_StockOrder(ix, data);
                    }
                    break;
                // 合計 - 在庫
                case 6:
                    if (data.SalesOrderDivCd == 1)
                    {
                        SetData_StockOrder(ix, data);
                    }
                    break;
                // 合計 - 取寄
                case 7:
                    if (data.SalesOrderDivCd == 0)
                    {
                        SetData_StockOrder(ix, data);
                    }
                    break;
                // 合計 - 合計
                case 8:
                    SetData_StockOrder(ix, data);
                    break;
            }

        }

        /// <summary>
        /// 売上実績照会データ検索結果ワーク→売上実績照会データ行クラス設定処理（在庫）
        /// データRowにセット
        /// </summary>
        /// <param name="ix"></param>
        /// <param name="data"></param>
        private void SetData_StockOrder(int ix, SalesAnnualDataSelectResultWork data)
        {

            //　売上
            _dataSet.StockResult[ix].SalesMoney = _dataSet.StockResult[ix].SalesMoney + data.SalesMoney;
            // 返品
            //_dataSet.StockResult[ix].ReturnedGoodsPrice = _dataSet.StockResult[ix].ReturnedGoodsPrice + data.SalesRetGoodsPrice;  // DEL 2009/05/25
            _dataSet.StockResult[ix].ReturnedGoodsPrice = _dataSet.StockResult[ix].ReturnedGoodsPrice - data.SalesRetGoodsPrice;    // ADD 2009/05/25 符号反転
            // 値引
            //_dataSet.StockResult[ix].DiscountPrice = _dataSet.StockResult[ix].DiscountPrice + data.DiscountPrice;                 // DEL 2009/05/25
            _dataSet.StockResult[ix].DiscountPrice = _dataSet.StockResult[ix].DiscountPrice - data.DiscountPrice;                   // ADD 2009/05/25 符号反転
            // 純売上金額
            // --- CHG 2009/01/15 障害ID:10075対応------------------------------------------------------>>>>>
            //_dataSet.StockResult[ix].GenuineSalesMoney = _dataSet.StockResult[ix].GenuineSalesMoney + data.SalesMoney + data.SalesRetGoodsPrice + data.DiscountPrice;
            //_dataSet.StockResult[ix].GenuineSalesMoney = _dataSet.StockResult[ix].GenuineSalesMoney + data.SalesMoney - data.SalesRetGoodsPrice - data.DiscountPrice;     // DEL 2009/05/25
            _dataSet.StockResult[ix].GenuineSalesMoney = _dataSet.StockResult[ix].GenuineSalesMoney + data.SalesMoney + data.SalesRetGoodsPrice + data.DiscountPrice;       // ADD 2009/05/25 返品値引の符号反転
            // --- CHG 2009/01/15 障害ID:10075対応------------------------------------------------------<<<<<
            // 粗利金額
            //_dataSet.StockResult[ix].GrossProfitMoney = _dataSet.StockResult[ix].GrossProfitMoney + data.GrossProfit; // DEL 2009/04/14
            //_dataSet.StockResult[ix].GrossProfitMoney = _dataSet.StockResult[ix].GrossProfitMoney + data.SalesMoney - data.Cost; // ADD 2009/04/14 DEL 2009/09/07

            _dataSet.StockResult[ix].GrossProfitMoney = _dataSet.StockResult[ix].GrossProfitMoney + data.GrossProfit; // ADD 2009/09/07
            
        }

        /// <summary>
        /// 得意先別売上年間実績照会結果ワーク→売上実績照会データ行クラス設定処理（入金）
        /// データRowにセット
        /// </summary>
        /// <param name="data"></param>
        private void SetData_StockOrderResult_Deposit(CustSalesAnnualDataSelectResultWork data)
        {
            _dataSet.StockOrderResult[0].AcpOdrTtl3TmBfBlDmd = data.AcpOdrTtl3TmBfBlDmd;
            _dataSet.StockOrderResult[0].AcpOdrTtl2TmBfBlDmd = data.AcpOdrTtl2TmBfBlDmd;
            _dataSet.StockOrderResult[0].LastTimeDemand = data.LastTimeDemand;
            _dataSet.StockOrderResult[0].LastTimeAccRec = data.LastTimeAccRec;
            _dataSet.StockOrderResult[0].DepositDemand01 = data.CasheDeposit;
            _dataSet.StockOrderResult[0].DepositMonth01 = data.ThisMCasheDeposit;
            _dataSet.StockOrderResult[0].DepositDemand02 = data.TrfrDeposit;
            _dataSet.StockOrderResult[0].DepositMonth02 = data.ThisMhTrfrDeposit;
            _dataSet.StockOrderResult[0].DepositDemand03 = data.CheckKDeposit;
            _dataSet.StockOrderResult[0].DepositMonth03 = data.ThisMCheckKDeposit;
            _dataSet.StockOrderResult[0].DepositDemand04 = data.DraftDeposit;
            _dataSet.StockOrderResult[0].DepositMonth04 = data.ThisMDraftDeposit;
            _dataSet.StockOrderResult[0].DepositDemand05 = data.OffsetDeposit;
            _dataSet.StockOrderResult[0].DepositMonth05 = data.ThisMOffsetDeposit;
            _dataSet.StockOrderResult[0].DepositDemand06 = data.FundtransferDeposit;
            _dataSet.StockOrderResult[0].DepositMonth06 = data.ThisMFundtransferDeposit;
            _dataSet.StockOrderResult[0].DepositDemand07 = data.EmoneyDeposit;
            _dataSet.StockOrderResult[0].DepositMonth07 = data.ThisMEmoneyDeposit;
            _dataSet.StockOrderResult[0].DepositDemand08 = data.OtherDeposit;
            _dataSet.StockOrderResult[0].DepositMonth08 = data.ThisMOtherDeposit;
            _dataSet.StockOrderResult[0].ThisTimeFeeDmdNrml = data.ThisTimeFeeDmdNrml;
            _dataSet.StockOrderResult[0].ThisMThisTimeFeeDmdNrml = data.ThisMThisTimeFeeDmdNrml;
            _dataSet.StockOrderResult[0].ThisTimeDisDmdNrml = data.ThisTimeDisDmdNrml;
            _dataSet.StockOrderResult[0].ThisMThisTimeDisDmdNrml = data.ThisMThisTimeDisDmdNrml;
            _dataSet.StockOrderResult[0].ThisTimeSumDmdNrml = data.CasheDeposit +
                                                            data.TrfrDeposit +
                                                            data.CheckKDeposit +
                                                            data.DraftDeposit +
                                                            data.OffsetDeposit +
                                                            data.FundtransferDeposit +
                                                            data.EmoneyDeposit +
                                                            data.OtherDeposit +
                                                            data.ThisTimeFeeDmdNrml +
                                                            data.ThisTimeDisDmdNrml;
            _dataSet.StockOrderResult[0].ThisMThisTimeSumDmdNrml = data.ThisMCasheDeposit +
                                                                data.ThisMhTrfrDeposit +
                                                                data.ThisMCheckKDeposit +
                                                                data.ThisMDraftDeposit +
                                                                data.ThisMOffsetDeposit +
                                                                data.ThisMFundtransferDeposit +
                                                                data.ThisMEmoneyDeposit +
                                                                data.ThisMOtherDeposit +
                                                                data.ThisMThisTimeFeeDmdNrml +
                                                                data.ThisMThisTimeDisDmdNrml;

            _dataSet.StockOrderResult[0].OfsThisSalesTax = data.OfsThisSalesTax;
            _dataSet.StockOrderResult[0].ThisMOfsThisSalesTax = data.ThisMOfsThisSalesTax;

            _dataSet.StockOrderResult[0].BalanceDemand = data.AcpOdrTtl3TmBfBlDmd + data.AcpOdrTtl2TmBfBlDmd + data.LastTimeDemand - (data.CasheDeposit +
                                                            data.TrfrDeposit +
                                                            data.CheckKDeposit +
                                                            data.DraftDeposit +
                                                            data.OffsetDeposit +
                                                            data.FundtransferDeposit +
                                                            data.EmoneyDeposit +
                                                            data.OtherDeposit +
                                                            data.ThisTimeFeeDmdNrml +
                                                            data.ThisTimeDisDmdNrml) + data.OfsThisSalesTax;
            _dataSet.StockOrderResult[0].BalanceMonth = data.LastTimeAccRec - (data.ThisMCasheDeposit +
                                                                data.ThisMhTrfrDeposit +
                                                                data.ThisMCheckKDeposit +
                                                                data.ThisMDraftDeposit +
                                                                data.ThisMOffsetDeposit +
                                                                data.ThisMFundtransferDeposit +
                                                                data.ThisMEmoneyDeposit +
                                                                data.ThisMOtherDeposit +
                                                                data.ThisMThisTimeFeeDmdNrml +
                                                                data.ThisMThisTimeDisDmdNrml) + data.ThisMOfsThisSalesTax;
        }

        /// <summary>
        /// 得意先別売上年間実績照会結果ワーク→売上実績照会データ行クラス設定処理（純正＆優良）
        /// データRowにセット
        /// </summary>
        /// <param name="data"></param>
        private void SetData_StockOrderResult_PureSuperior(CustSalesAnnualDataSelectResultWork data)
        {
            if (data.claimDiv == 1)
            {
                //　請求
                _dataSet.StockOrderResult[0].SlipDemand = data.TermSalesSlipCount;
                _dataSet.StockOrderResult[0].PureSalesDemand = data.SalesMoneyTaxExc;
                _dataSet.StockOrderResult[0].PureReturnedDemand = data.SalesRetGoodsPrice;
                _dataSet.StockOrderResult[0].PureDiscountDemand = data.DiscountPrice;
                _dataSet.StockOrderResult[0].PureGenuineSalesDemand = data.SalesMoneyTaxExc + data.SalesRetGoodsPrice + data.DiscountPrice;
                _dataSet.StockOrderResult[0].SuperiorSalesDemand = data.ExSalesMoneyTaxExc;
                _dataSet.StockOrderResult[0].SuperiorReturnedDemand = data.ExSalesRetGoodsPrice;
                _dataSet.StockOrderResult[0].SuperiorDiscountDemand = data.ExDiscountPrice;
                _dataSet.StockOrderResult[0].SuperiorGenuineSalesDemand = data.ExSalesMoneyTaxExc + data.ExSalesRetGoodsPrice + data.ExDiscountPrice;
                _dataSet.StockOrderResult[0].SumSalesDemand = data.SalesMoneyTaxExc + data.ExSalesMoneyTaxExc;
                _dataSet.StockOrderResult[0].SumReturnedDemand = data.SalesRetGoodsPrice + data.ExSalesRetGoodsPrice;
                _dataSet.StockOrderResult[0].SumDiscountDemand = data.DiscountPrice + data.ExDiscountPrice;
                _dataSet.StockOrderResult[0].SumGenuineSalesDemand = data.SalesMoneyTaxExc + data.SalesRetGoodsPrice + data.DiscountPrice + data.ExSalesMoneyTaxExc + data.ExSalesRetGoodsPrice + data.ExDiscountPrice;

                _dataSet.StockOrderResult[0].BalanceDemand += data.SalesMoneyTaxExc + data.SalesRetGoodsPrice + data.DiscountPrice + data.ExSalesMoneyTaxExc + data.ExSalesRetGoodsPrice + data.ExDiscountPrice;
            }
            else if (data.claimDiv == 2)
            {
                // 当月

                _dataSet.StockOrderResult[0].SlipMonth = data.TermSalesSlipCount;
                _dataSet.StockOrderResult[0].PureSalesMonth = data.SalesMoneyTaxExc;
                _dataSet.StockOrderResult[0].PureReturnedMonth = data.SalesRetGoodsPrice;
                _dataSet.StockOrderResult[0].PureDiscountMonth = data.DiscountPrice;
                _dataSet.StockOrderResult[0].PureGenuineSalesMonth = data.SalesMoneyTaxExc + data.SalesRetGoodsPrice + data.DiscountPrice;
                _dataSet.StockOrderResult[0].PureGrossMonth = data.GrossProfit;
                _dataSet.StockOrderResult[0].SuperiorSalesMonth = data.ExSalesMoneyTaxExc;
                _dataSet.StockOrderResult[0].SuperiorReturnedMonth = data.ExSalesRetGoodsPrice;
                _dataSet.StockOrderResult[0].SuperiorDiscountMonth = data.ExDiscountPrice;
                _dataSet.StockOrderResult[0].SuperiorGenuineSalesMonth = data.ExSalesMoneyTaxExc + data.ExSalesRetGoodsPrice + data.ExDiscountPrice;
                _dataSet.StockOrderResult[0].SuperiorGrossMonth = data.ExGrossProfit;
                _dataSet.StockOrderResult[0].SumSalesMonth = data.SalesMoneyTaxExc + data.ExSalesMoneyTaxExc;
                _dataSet.StockOrderResult[0].SumReturnedMonth = data.SalesRetGoodsPrice + data.ExSalesRetGoodsPrice;
                _dataSet.StockOrderResult[0].SumDiscountMonth = data.DiscountPrice + data.ExDiscountPrice;
                _dataSet.StockOrderResult[0].SumGenuineSalesMonth = data.SalesMoneyTaxExc + data.SalesRetGoodsPrice + data.DiscountPrice + data.ExSalesMoneyTaxExc + data.ExSalesRetGoodsPrice + data.ExDiscountPrice;
                _dataSet.StockOrderResult[0].SumGrossMonth = data.GrossProfit + data.ExGrossProfit;

                _dataSet.StockOrderResult[0].BalanceMonth += data.SalesMoneyTaxExc + data.SalesRetGoodsPrice + data.DiscountPrice + data.ExSalesMoneyTaxExc + data.ExSalesRetGoodsPrice + data.ExDiscountPrice;
            }

        }

        // -- ADD 2009/09/07 --------------------------------------->>>
        /// <summary>
        /// 端数処理(金額用)
        /// </summary>
        /// <param name="inputMoney">端数処理前の金額</param>
        /// <param name="fractionunit">端数処理単位</param>
        /// <param name="procDiv">端数処理区分（1:切捨/2:四捨五入/3:切上）</param>
        /// <returns>端数処理後の金額</returns>
        private long FracCalcMoney(double inputMoney, double fractionunit, int procDiv)
        {
            long retMoney;

            FractionCalculate.FracCalcMoney(inputMoney, fractionunit, procDiv, out retMoney);

            return retMoney;
        }

        /// <summary>
        /// 端数処理(率用)
        /// </summary>
        /// <param name="inputMoney">端数処理前の金額</param>
        /// <param name="fractionunit">端数処理単位</param>
        /// <param name="procDiv">端数処理区分（1:切捨/2:四捨五入/3:切上）</param>
        /// <returns>端数処理後の金額</returns>
        private double FracCalcMoneyD(double inputMoney, double fractionunit, int procDiv)
        {
            double retMoney;

            FractionCalculate.FracCalcMoney(inputMoney, fractionunit, procDiv, out retMoney);

            return retMoney;
        }
        // -- ADD 2009/09/07 ---------------------------------------<<<
    }
}

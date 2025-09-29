
using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Data;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Globarization;
using System.Collections.Generic;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Library.Collections;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 在庫分析順位表DBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 在庫分析順位表の実データ操作を行うクラスです。</br>
    /// <br>Programmer : 22008 長内 数馬</br>
    /// <br>Date       : 2007.09.13</br>
    /// <br></br>
    /// <br>Update Note: 2008.07.16 森本 大輝</br>
    /// <br>           : PM.NS対応</br>
    /// <br>Update Note: 2011/08/23  連番806 梁森東</br>
    /// <br>          : 「対象月を指定しても当月分しか集計していないようです」の対応</br>
    /// <br>Update Note: 2011/09/07 田建委</br>
    /// <br>          : redmine#23884の対応</br>
    /// <br>Update Note: 2012/12/24 王君</br>
    /// <br>           : redmine#33977の対応</br>
    /// <br>Update Note: 2015/11/24 譚洪</br>
    /// <br>           : 管理番号 : 11170204-00</br>
    /// <br>           : redmine#47489の対応</br>
    /// <br>           : 月次更新リモートの原価取得処理がないのメソッドをコールします。</br>
    /// <br>Update Note: 2018/07/24 31622 脇田靖之</br>
    /// <br>管理番号   : 11400020-00</br>
    /// <br>             対象データが抽出できない障害対応</br>
    /// </remarks>
    [Serializable]
    public class StockAnalysisOrderListWorkDB : RemoteDB, IStockAnalysisOrderListWorkDB
    {
        /// <summary>
        /// 在庫分析順位表DBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : DBサーバーコネクション情報を取得します。</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2007.09.13</br>
        /// </remarks>
        public StockAnalysisOrderListWorkDB()
            :
        base("DCZAI02153D", "Broadleaf.Application.Remoting.ParamData.StockAnalysisOrderListWork", "STOCKHISTORYRF") //基底クラスのコンストラクタ
        {
        }

        private MonthlyAddUpDB _monthlyAddUpDB = new MonthlyAddUpDB();
        private TtlDayCalcDB _ttlDayCalcDB = new TtlDayCalcDB();
        private CompanyInfDB _companyInfDB = new CompanyInfDB();

        #region 在庫分析順位表
        /// <summary>
        /// 指定された企業コードの在庫分析順位表LISTを全て戻します（論理削除除く）
        /// </summary>
        /// <param name="stockMoveListResultWork">検索結果</param>
        /// <param name="stockMoveListCndtnWork">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された企業コードの在庫分析順位表LISTを全て戻します（論理削除除く）</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2007.09.13</br>
        public int Search(out object stockAnalysisOrderListWork, object stockAnalysisOrderListCndtnWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            stockAnalysisOrderListWork = null;

            StockAnalysisOrderListCndtnWork _stockAnalysisOrderListCndtnWork = stockAnalysisOrderListCndtnWork as StockAnalysisOrderListCndtnWork;

            try
            {
                status = SearchProc(out stockAnalysisOrderListWork, _stockAnalysisOrderListCndtnWork, readMode, logicalMode);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "StockAnalysisOrderListWorkDB.Search Exception=" + ex.Message);
                stockAnalysisOrderListWork = new ArrayList();
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            return status;
        }

        /// <summary>
        /// 指定された企業コードの在庫分析順位表LISTを全て戻します
        /// </summary>
        /// <param name="stockMoveListResultWork">検索結果</param>
        /// <param name="_stockMoveListCndtnWork">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された企業コードの在庫分析順位表LISTを全て戻します</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2007.09.13</br>
        /// <br></br>
        /// <br>Update Note: 2007.09.11 長内 DC.NS用に修正</br>
        /// <br>Update Note: 23015 森本 大輝</br>
        /// <br>Date       : 2008.07.16</br>
        /// <br>Update Note: 2011/09/07 田建委</br>
        /// <br>           : redmine#23884の対応</br>
        /// <br>Update Note: 2015/11/24 譚洪</br>
        /// <br>           : 管理番号 : 11170204-00</br>
        /// <br>           : redmine#47489の対応</br>
        /// <br>           : 月次更新リモートの原価取得処理がないのメソッドをコールします。</br>
        private int SearchProc(out object stockAnalysisOrderListWork, StockAnalysisOrderListCndtnWork _stockAnalysisOrderListCndtnWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection
                sqlConnection = null;

            stockAnalysisOrderListWork = null;

            ArrayList resultList = new ArrayList();
            ArrayList shipCntList = new ArrayList();
            ArrayList lastKey = new ArrayList();

            StockAnalysisOrderListWork resultwork = new StockAnalysisOrderListWork();
            int month = 0;
            bool FirstFlg = false; // 在庫履歴は1回のみ

            Dictionary<string, StockAnalysisOrderListWork> dic = new Dictionary<string, StockAnalysisOrderListWork>();

            try
            {
                //メソッド開始時にコネクション文字列を取得(SFCMN00615Cの定義からユーザーDB[IndexCode_UserDB]を指定してコネクション文字列を取得)
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "") return status;

                //SQL文生成
                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();

                // 在庫マスタから結果抽出
                ArrayList stockHistoryList = new ArrayList();
                Dictionary<string, StockAnalysisOrderListWork> dictionary = new Dictionary<string, StockAnalysisOrderListWork>();

                #region 全社設定
                //if ((_stockAnalysisOrderListCndtnWork.SectionCodes.Length == 0) ||
                //    (_stockAnalysisOrderListCndtnWork.SectionCodes[0] == ""))
                //{
                //    // 全社共通の場合
                //    CustomSerializeArrayList sectionList = new CustomSerializeArrayList();
                //    SectionInfo sectionInfo = new SectionInfo();
                //    SecInfoSetWork sectionInfoSetWork = new SecInfoSetWork();
                //    sectionInfoSetWork.EnterpriseCode = _stockAnalysisOrderListCndtnWork.EnterpriseCode;
                //    sectionInfoSetWork.LogicalDeleteCode = 0;

                //    sectionInfo.Search(out sectionList, sectionInfoSetWork, ref sqlConnection, readMode, logicalMode);
                //    ArrayList paraList = ListUtils.Find(sectionList, typeof(SecInfoSetWork), ListUtils.FindType.Array) as ArrayList;
                //    string[] str = new string[paraList.Count];
                //    int i = 0;
                //    foreach (SecInfoSetWork sec in paraList)
                //    {
                //        // ArrayListから文字列に代入
                //        str[i] = sec.SectionCode;
                //        i++;
                //    }
                //    if (str.Length != 0)
                //    {
                //        _stockAnalysisOrderListCndtnWork.SectionCodes = str;
                //    }
                //}
                #endregion

                if (_stockAnalysisOrderListCndtnWork.Ed_AddUpYearMonth.Month < _stockAnalysisOrderListCndtnWork.St_AddUpYearMonth.Month)
                {
                    month = 12 - _stockAnalysisOrderListCndtnWork.St_AddUpYearMonth.Month + _stockAnalysisOrderListCndtnWork.Ed_AddUpYearMonth.Month;
                }
                else
                {
                    month = _stockAnalysisOrderListCndtnWork.Ed_AddUpYearMonth.Month - _stockAnalysisOrderListCndtnWork.St_AddUpYearMonth.Month;
                }
                //foreach (string sectionCode in _stockAnalysisOrderListCndtnWork.SectionCodes)
                //{
                    DateTime stAddupYearMonth = _stockAnalysisOrderListCndtnWork.St_AddUpYearMonth;
                    //Dictionary<string, StockAnalysisOrderListWork> dicStock = new Dictionary<string, StockAnalysisOrderListWork>();//ADD by Liangsd     2011/08/23 //DEL by tianjw 2011/09/07
                    for (int i = 0; i <= month; i++)
                    {
                        Dictionary<string, StockAnalysisOrderListWork> dicStock = new Dictionary<string, StockAnalysisOrderListWork>();//ADD by tianjw 2011/09/07
                        Dictionary<string, StockAnalysisOrderListWork> dicHist = new Dictionary<string, StockAnalysisOrderListWork>();
                        //Dictionary<string, StockAnalysisOrderListWork> dicStock = new Dictionary<string, StockAnalysisOrderListWork>();//DEL by Liangsd     2011/08/23

                        ArrayList keyStockList = new ArrayList();
                        ArrayList histKey = new ArrayList();
                        List<StockHistoryWork> stockHistoryWorkList = new List<StockHistoryWork>();

                        // 締日チェック処理
                        List<TtlDayCalcRetWork> retList = new List<TtlDayCalcRetWork>();
                        TtlDayCalcParaWork para = new TtlDayCalcParaWork();

                        DateTime stMonth = new DateTime();
                        DateTime edMonth = new DateTime();

                        para.EnterpriseCode = _stockAnalysisOrderListCndtnWork.EnterpriseCode;
                        //para.SectionCode = sectionCode.Trim();
                        Int32 iAddUpDate = Int32.Parse(stAddupYearMonth.ToString("yyyyMMdd")); //計上年月日

                        bool sale = false, buy = false;
                        // MAX締め日付
                        int MaxAddUpDate =0;

                        // 売掛
                        status = _ttlDayCalcDB.SearchHisMonthlyAccRec(out retList, para, ref sqlConnection);
                        foreach (TtlDayCalcRetWork ttlDayWork in retList)
                        {
                            if (MaxAddUpDate < ttlDayWork.TotalDay)
                            {
                                MaxAddUpDate = ttlDayWork.TotalDay;
                            }
                        }

                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL || MaxAddUpDate < iAddUpDate)
                        {
                            sale = true;
                        }
                        retList.Clear();
                        MaxAddUpDate = 0;
                        // 買掛
                        status = _ttlDayCalcDB.SearchHisMonthlyAccPay(out retList, para, ref sqlConnection);
                        foreach (TtlDayCalcRetWork ttlDayWork in retList)
                        {
                            if (MaxAddUpDate < ttlDayWork.TotalDay)
                            {
                                MaxAddUpDate = ttlDayWork.TotalDay;
                            }
                        }

                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL || MaxAddUpDate < iAddUpDate)
                        {
                            buy = true;
                        }
                        if (sale == true || buy == true)
                        {
                            if (stockHistoryList.Count == 0)
                            {

                                ArrayList list = new ArrayList();
                                CompanyInfWork companyInfWork = new CompanyInfWork();

                                //締め範囲日付取得
                                companyInfWork.EnterpriseCode = _stockAnalysisOrderListCndtnWork.EnterpriseCode;
                                status = _companyInfDB.Search(out list, companyInfWork, ref sqlConnection);

                                companyInfWork = list[0] as CompanyInfWork;

                                FinYearTableGenerator fin = new FinYearTableGenerator(companyInfWork);

                                fin.GetDaysFromMonth(stAddupYearMonth, out stMonth, out edMonth);
                                if (dic.Count == 0)
                                {
                                    // 在庫マスタ Search
                                    status = SearchStockProc(ref dic, ref sqlConnection, _stockAnalysisOrderListCndtnWork, logicalMode);
                                    if ((status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND) ||
                                        (status == (int)ConstantManagement.DB_Status.ctDB_EOF))
                                    {
                                        //該当データなし
                                        return status;
                                    }
                                    else if (status != 0)
                                    {
                                        //取得失敗
                                        throw new Exception("在庫マスタ読込失敗。");
                                    }
                                    if (dic.Count == 0)
                                    {
                                        //該当データなし
                                        return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                                    }
                                }
                            }

                            StockHistoryWork stockHistoryWork = new StockHistoryWork();
                            MonthlyAddUpWork monthlyAddUpWork = new MonthlyAddUpWork();

                            //売掛金・買掛金集計モジュールパラメータセット
                            monthlyAddUpWork.EnterpriseCode = _stockAnalysisOrderListCndtnWork.EnterpriseCode;
                            monthlyAddUpWork.AddUpDateSt = stMonth;
                            monthlyAddUpWork.AddUpDateEd = edMonth;
                            //monthlyAddUpWork.AddUpSecCode = sectionCode;
                            monthlyAddUpWork.AddUpDate = edMonth;
                            monthlyAddUpWork.LstMonAddUpProcDay = stAddupYearMonth.AddMonths(-1);
                            monthlyAddUpWork.AddUpYearMonth = stAddupYearMonth.AddMonths(-1);

                            string retMsg = null;
                            bool msgDiv = true;

                            // 月次更新リモート在庫集計メソッド呼び出し
                            //status = _monthlyAddUpDB.MakeStockHistoryParameters(ref monthlyAddUpWork, ref stockHistoryWorkList, out msgDiv, out retMsg, ref sqlConnection); // DEL 2015/11/24 譚洪 Redmine#47489
                            status = _monthlyAddUpDB.MakeStockHistoryNotGetCost(ref monthlyAddUpWork, ref stockHistoryWorkList, out msgDiv, out retMsg, ref sqlConnection); // ADD 2015/11/24 譚洪 Redmine#47489
                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                // クラス格納メソッド
                                status = StockStorage(ref dicStock, ref dic, ref keyStockList, ref lastKey, ref stockHistoryWorkList, _stockAnalysisOrderListCndtnWork);
                                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                            }
                            else if ((status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND) ||
                             (status == (int)ConstantManagement.DB_Status.ctDB_EOF))
                            {
                                //NOT_FOUND,EOFの場合は次へ
                            }
                            else
                            {
                                //取得失敗
                                throw new Exception("売掛金・買掛金集計モジュールからの取得に失敗。");
                            }
                        }
                        // 締め処理されている
                        else
                        {
                            if (FirstFlg == false)
                            {
                                status = SearchStockAnalysisOrderProc(ref dicHist, ref histKey, ref lastKey, ref sqlConnection, _stockAnalysisOrderListCndtnWork, logicalMode);
                                FirstFlg = true;
                            }
                        }
                        #region 結果集計
                        if (dicHist.Count != 0)
                        {
                            foreach (string k in histKey)
                            {
                                if (dictionary.ContainsKey(k) == true)
                                {
                                    dictionary[k].SalesMoneyTaxExc += dicHist[k].SalesMoneyTaxExc;
                                    dictionary[k].GrossProfit += dicHist[k].GrossProfit;
                                    dictionary[k].ShipmentCnt += dicHist[k].ShipmentCnt;
                                }
                                else
                                {
                                    dictionary[k] = dicHist[k];
                                }
                            }
                        }
                        else if (dicStock.Count != 0)//ADD by Liangsd    2011/08/30
                        //if (dicStock.Count != 0)//DEL by Liangsd    2011/08/30
                        {
                            // ----- UPD tianjw 2011/09/07 ---------->>>>>
                            //foreach (string k2 in keyStockList)
                            foreach (string k2 in dicStock.Keys)
                            // ----- UPD tianjw 2011/09/07 ----------<<<<<
                            {
                                if (dictionary.ContainsKey(k2) == true)
                                {
                                    dictionary[k2].SalesMoneyTaxExc += dicStock[k2].SalesMoneyTaxExc;
                                    dictionary[k2].GrossProfit += dicStock[k2].GrossProfit;
                                    dictionary[k2].ShipmentCnt += dicStock[k2].ShipmentCnt;
                                }
                                else
                                {
                                    dictionary[k2] = dicStock[k2];
                                }
                            }
                        }
                        #endregion

                        stAddupYearMonth = stAddupYearMonth.AddMonths(1);
                    }
                //}
                for (int j = 0; j < lastKey.Count; j++)
                {
                    string key3 = lastKey[j] as string;
                    if (dictionary.ContainsKey(key3) == true)
                    {
                        dictionary.TryGetValue(key3, out resultwork);
                        resultList.Add(resultwork);
                    }
                }
                // 最後に出庫数チェック
                foreach (StockAnalysisOrderListWork shipCntWork in resultList)
                {
                    if (_stockAnalysisOrderListCndtnWork.St_ShipmentCnt <= shipCntWork.ShipmentCnt && shipCntWork.ShipmentCnt <= _stockAnalysisOrderListCndtnWork.Ed_ShipmentCnt)
                    {
                        shipCntList.Add(shipCntWork);
                    }
                }


            }

            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "StockAnalysisOrderListWorkDB.SearchProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            stockAnalysisOrderListWork = shipCntList;
            return status;
        }

        #region [クラス格納処理]
        /// <summary>
        /// 検索結果クラス格納処理
        /// </summary>
        /// <param name="al">結果格納ArrayList</param>
        /// <param name="stockHistoryWorkList">月次更新リスト</param>
        /// <br>Update Note: 2011/08/23  連番806 梁森東</br>
        /// </br>            : 「対象月を指定しても当月分しか集計していないようです」の対応</br>
        private int StockStorage(ref Dictionary<string, StockAnalysisOrderListWork> dicStock, ref Dictionary<string, StockAnalysisOrderListWork> dic, ref ArrayList keyStockList, ref ArrayList lastKey , ref List<StockHistoryWork> stockHistoryWorkList, StockAnalysisOrderListCndtnWork _stockAnalysisOrderListCndtnWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            string key = string.Empty;
            string key2 = string.Empty;

            foreach (StockHistoryWork st in stockHistoryWorkList)
            {
                StockAnalysisOrderListWork stockAnalysisOrderListWork = new StockAnalysisOrderListWork();

                // 拠点コード
                //if (_stockAnalysisOrderListCndtnWork.SectionCodes != null)
                //{
                //    string Sec = "";
                //    foreach (string Secstr in _stockAnalysisOrderListCndtnWork.SectionCodes)
                //    {
                //        if (Sec != "")
                //        {
                //            Sec += ",";
                //        }
                //        Sec += "'" + Secstr + "'";
                //    }

                //    if (Sec != "")
                //    {
                //        if (Sec.Contains(st.SectionCode.Trim()))
                //        {
                //            stockAnalysisOrderListWork.SectionCode = st.SectionCode.Trim();
                //        }
                //        else
                //        {
                //            continue;
                //        }
                //    }
                //    else
                //    {
                //        continue;
                //    }
                //}

                // 倉庫コード・名称
                if (_stockAnalysisOrderListCndtnWork.St_WarehouseCode != "")
                {
                    if (_stockAnalysisOrderListCndtnWork.St_WarehouseCode.CompareTo(st.WarehouseCode.Trim()) == 0 ||
                        _stockAnalysisOrderListCndtnWork.St_WarehouseCode.CompareTo(st.WarehouseCode.Trim()) < 0)
                    {
                        stockAnalysisOrderListWork.WarehouseCode = st.WarehouseCode;
                        stockAnalysisOrderListWork.WarehouseName = st.WarehouseName;
                    }
                    else
                    {
                        continue;
                    }
                }
                if (_stockAnalysisOrderListCndtnWork.Ed_WarehouseCode != "")
                {
                    if (_stockAnalysisOrderListCndtnWork.Ed_WarehouseCode.CompareTo(st.WarehouseCode.Trim()) == 0 ||
                        _stockAnalysisOrderListCndtnWork.Ed_WarehouseCode.CompareTo(st.WarehouseCode.Trim()) > 0)
                    {
                        stockAnalysisOrderListWork.WarehouseCode = st.WarehouseCode;
                        stockAnalysisOrderListWork.WarehouseName = st.WarehouseName;
                    }
                    else
                    {
                        continue;
                    }
                }
                if (_stockAnalysisOrderListCndtnWork.St_WarehouseCode == "" && _stockAnalysisOrderListCndtnWork.Ed_WarehouseCode == "")
                {
                    stockAnalysisOrderListWork.WarehouseCode = st.WarehouseCode;
                    stockAnalysisOrderListWork.WarehouseName = st.WarehouseName;
                }

                // メーカーコード
                if (_stockAnalysisOrderListCndtnWork.St_GoodsMakerCd != 0)
                {
                    if (_stockAnalysisOrderListCndtnWork.St_GoodsMakerCd == st.GoodsMakerCd ||
                        _stockAnalysisOrderListCndtnWork.St_GoodsMakerCd < st.GoodsMakerCd) 
                    {
                        stockAnalysisOrderListWork.GoodsMakerCd = st.GoodsMakerCd;
                    }
                    else
                    {
                        continue;
                    }
                }
                if (_stockAnalysisOrderListCndtnWork.Ed_GoodsMakerCd != 0)
                {
                    if (_stockAnalysisOrderListCndtnWork.Ed_GoodsMakerCd == st.GoodsMakerCd ||
                        _stockAnalysisOrderListCndtnWork.Ed_GoodsMakerCd > st.GoodsMakerCd) 
                    {
                        stockAnalysisOrderListWork.GoodsMakerCd = st.GoodsMakerCd;
                    }
                    else
                    {
                        continue;
                    }
                }

                // 品番
                if (_stockAnalysisOrderListCndtnWork.St_GoodsNo != "")
                {
                    if (_stockAnalysisOrderListCndtnWork.St_GoodsNo.CompareTo(st.GoodsNo) == 0 ||
                        _stockAnalysisOrderListCndtnWork.St_GoodsNo.CompareTo(st.GoodsNo) < 0)
                    {
                        stockAnalysisOrderListWork.GoodsNo = st.GoodsNo;
                    }
                    else
                    {
                        continue;
                    }
                }
                if (_stockAnalysisOrderListCndtnWork.Ed_GoodsNo != "")
                {
                    if (_stockAnalysisOrderListCndtnWork.Ed_GoodsNo.CompareTo(st.GoodsNo) == 0 ||
                        _stockAnalysisOrderListCndtnWork.Ed_GoodsNo.CompareTo(st.GoodsNo) > 0)
                    {
                        stockAnalysisOrderListWork.GoodsNo = st.GoodsNo;
                    }
                    else
                    {
                        continue;
                    }
                }
                if (_stockAnalysisOrderListCndtnWork.St_GoodsNo == "" && _stockAnalysisOrderListCndtnWork.Ed_GoodsNo == "")
                {
                    stockAnalysisOrderListWork.GoodsNo = st.GoodsNo;
                }

                // 品名
                stockAnalysisOrderListWork.GoodsName = st.GoodsName;

                key = st.WarehouseCode + st.GoodsNo + st.GoodsMakerCd.ToString("0000");


                if (dic.ContainsKey(key) == true)
                {
                    StockAnalysisOrderListWork stockWork = dic[key] as StockAnalysisOrderListWork;

                    //棚番
                    if (_stockAnalysisOrderListCndtnWork.St_WarehouseShelfNo != "")
                    {
                        if (_stockAnalysisOrderListCndtnWork.St_WarehouseShelfNo.CompareTo(stockWork.WarehouseShelfNo) == 0 ||
                            _stockAnalysisOrderListCndtnWork.St_WarehouseShelfNo.CompareTo(stockWork.WarehouseShelfNo) < 0)
                        {
                            stockAnalysisOrderListWork.WarehouseShelfNo = stockWork.WarehouseShelfNo;
                        }
                        else
                        {
                            continue;
                        }
                    }
                    if (_stockAnalysisOrderListCndtnWork.Ed_WarehouseShelfNo != "")
                    {
                        if (_stockAnalysisOrderListCndtnWork.Ed_WarehouseShelfNo.CompareTo(stockWork.WarehouseShelfNo) == 0 ||
                            _stockAnalysisOrderListCndtnWork.Ed_WarehouseShelfNo.CompareTo(stockWork.WarehouseShelfNo) > 0)
                        {
                            stockAnalysisOrderListWork.WarehouseShelfNo = stockWork.WarehouseShelfNo;
                        }
                        else
                        {
                            continue;
                        }
                    }
                    if (_stockAnalysisOrderListCndtnWork.St_WarehouseShelfNo == "" && _stockAnalysisOrderListCndtnWork.Ed_WarehouseShelfNo == "")
                    {
                        stockAnalysisOrderListWork.WarehouseShelfNo = stockWork.WarehouseShelfNo;
                    }

                    //仕入先コード
                    //if (_stockAnalysisOrderListCndtnWork.St_SupplierCd != 0)
                    //{
                    //    if (_stockAnalysisOrderListCndtnWork.St_SupplierCd == stockWork.SupplierCd ||
                    //        _stockAnalysisOrderListCndtnWork.St_SupplierCd < stockWork.SupplierCd)
                    //    {
                    //        stockAnalysisOrderListWork.SupplierCd = stockWork.SupplierCd;
                    //    }
                    //    else
                    //    {
                    //        continue;
                    //    }
                    //}
                    //if (_stockAnalysisOrderListCndtnWork.Ed_SupplierCd != 0)
                    //{
                    //    if (_stockAnalysisOrderListCndtnWork.Ed_SupplierCd == stockWork.SupplierCd ||
                    //        _stockAnalysisOrderListCndtnWork.Ed_SupplierCd > stockWork.SupplierCd)
                    //    {
                    //        stockAnalysisOrderListWork.SupplierCd = stockWork.SupplierCd;
                    //    }
                    //    else
                    //    {
                    //        continue;
                    //    }
                    //}
                    //if (_stockAnalysisOrderListCndtnWork.St_SupplierCd == 0 && _stockAnalysisOrderListCndtnWork.Ed_SupplierCd == 0)
                    //{
                    //    stockAnalysisOrderListWork.SupplierCd = stockWork.SupplierCd;
                    //}

                    // 最高在庫数
                    stockAnalysisOrderListWork.MaximumStockCnt = stockWork.MaximumStockCnt;
                    
                    // 最低在庫数
                    stockAnalysisOrderListWork.MinimumStockCnt = stockWork.MinimumStockCnt;
                    
                    // BLコード
                    if (_stockAnalysisOrderListCndtnWork.St_BLGoodsCode != 0)
                    {
                        if (_stockAnalysisOrderListCndtnWork.St_BLGoodsCode == stockWork.BLGoodsCode ||
                            _stockAnalysisOrderListCndtnWork.St_BLGoodsCode < stockWork.BLGoodsCode)
                        {
                            stockAnalysisOrderListWork.BLGoodsCode = stockWork.BLGoodsCode;
                        }
                        else
                        {
                            continue;
                        }
                    }
                    if (_stockAnalysisOrderListCndtnWork.Ed_BLGoodsCode != 0)
                    {
                        if (_stockAnalysisOrderListCndtnWork.Ed_BLGoodsCode == stockWork.BLGoodsCode ||
                            _stockAnalysisOrderListCndtnWork.Ed_BLGoodsCode > stockWork.BLGoodsCode)
                        {
                            stockAnalysisOrderListWork.BLGoodsCode = stockWork.BLGoodsCode;
                        }
                        else
                        {
                            continue;
                        }
                    }
                    if (_stockAnalysisOrderListCndtnWork.St_BLGoodsCode == 0 && _stockAnalysisOrderListCndtnWork.Ed_BLGoodsCode == 0)
                    {
                        stockAnalysisOrderListWork.BLGoodsCode = stockWork.BLGoodsCode;
                    }
                    
                    // 仕入先略称
                    stockAnalysisOrderListWork.SupplierSnm = stockWork.SupplierSnm;

                    // 商品大分類
                    if (_stockAnalysisOrderListCndtnWork.St_GoodsLGroup != 0)
                    {
                        if (_stockAnalysisOrderListCndtnWork.St_GoodsLGroup == stockWork.GoodsLGroup ||
                            _stockAnalysisOrderListCndtnWork.St_GoodsLGroup < stockWork.GoodsLGroup)
                        {
                            stockAnalysisOrderListWork.GoodsLGroup = stockWork.GoodsLGroup;
                        }
                        else
                        {
                            continue;
                        }

                    }
                    if (_stockAnalysisOrderListCndtnWork.Ed_GoodsLGroup != 0)
                    {
                        if (_stockAnalysisOrderListCndtnWork.Ed_GoodsLGroup == stockWork.GoodsLGroup ||
                            _stockAnalysisOrderListCndtnWork.Ed_GoodsLGroup > stockWork.GoodsLGroup)
                        {
                            stockAnalysisOrderListWork.GoodsLGroup = stockWork.GoodsLGroup;
                        }
                        else
                        {
                            continue;
                        }
                    }
                    if (_stockAnalysisOrderListCndtnWork.St_GoodsLGroup == 0 && _stockAnalysisOrderListCndtnWork.Ed_GoodsLGroup == 0)
                    {
                        stockAnalysisOrderListWork.GoodsLGroup = stockWork.GoodsLGroup;
                    }

                    // 商品中分類
                    if (_stockAnalysisOrderListCndtnWork.St_GoodsMGroup != 0)
                    {
                        if (_stockAnalysisOrderListCndtnWork.St_GoodsMGroup == stockWork.GoodsMGroup ||
                            _stockAnalysisOrderListCndtnWork.St_GoodsMGroup < stockWork.GoodsMGroup)
                        {
                            stockAnalysisOrderListWork.GoodsMGroup = stockWork.GoodsMGroup;
                        }
                        else
                        {
                            continue;
                        }
                    }
                    if (_stockAnalysisOrderListCndtnWork.Ed_GoodsMGroup != 0)
                    {
                        if (_stockAnalysisOrderListCndtnWork.Ed_GoodsMGroup == stockWork.GoodsMGroup ||
                            _stockAnalysisOrderListCndtnWork.Ed_GoodsMGroup > stockWork.GoodsMGroup)
                        {
                            stockAnalysisOrderListWork.GoodsMGroup = stockWork.GoodsMGroup;
                        }
                        else
                        {
                            continue;
                        }
                    }
                    if (_stockAnalysisOrderListCndtnWork.St_GoodsMGroup == 0 && _stockAnalysisOrderListCndtnWork.Ed_GoodsMGroup == 0)
                    {
                        stockAnalysisOrderListWork.GoodsMGroup = stockWork.GoodsMGroup;
                    }

                    // グループコード
                    if (_stockAnalysisOrderListCndtnWork.St_BLGroupCode != 0)
                    {
                        if (_stockAnalysisOrderListCndtnWork.St_BLGroupCode == stockWork.BLGroupCode ||
                            _stockAnalysisOrderListCndtnWork.St_BLGroupCode < stockWork.BLGroupCode)
                        {
                            stockAnalysisOrderListWork.BLGroupCode = stockWork.BLGroupCode;
                        }
                        else
                        {
                            continue;
                        }
                    }
                    if (_stockAnalysisOrderListCndtnWork.Ed_BLGroupCode != 0)
                    {
                        if (_stockAnalysisOrderListCndtnWork.Ed_BLGroupCode == stockWork.BLGroupCode ||
                            _stockAnalysisOrderListCndtnWork.Ed_BLGroupCode > stockWork.BLGroupCode)
                        {
                            stockAnalysisOrderListWork.BLGroupCode = stockWork.BLGroupCode;
                        }
                        else
                        {
                            continue;
                        }
                    }
                    if (_stockAnalysisOrderListCndtnWork.St_BLGroupCode == 0 && _stockAnalysisOrderListCndtnWork.Ed_BLGroupCode == 0)
                    {
                        stockAnalysisOrderListWork.BLGroupCode = stockWork.BLGroupCode;
                    }

                    // 拠点名称
                    //stockAnalysisOrderListWork.SectionGuideNm = stockWork.SectionGuideNm;

                    // 出荷可能数
                    stockAnalysisOrderListWork.ShipmentPosCnt = stockWork.ShipmentPosCnt;

                    // 在庫登録日
                    if (_stockAnalysisOrderListCndtnWork.StockCreateDate != DateTime.MinValue)
                    {
                        if (_stockAnalysisOrderListCndtnWork.StockCreateDateDiv == 0 && (_stockAnalysisOrderListCndtnWork.StockCreateDate == stockWork.StockCreateDate ||
                            _stockAnalysisOrderListCndtnWork.StockCreateDate > stockWork.StockCreateDate))
                        {
                            stockAnalysisOrderListWork.StockCreateDate = stockWork.StockCreateDate;
                        }
                        else if (_stockAnalysisOrderListCndtnWork.StockCreateDateDiv == 1 && (_stockAnalysisOrderListCndtnWork.StockCreateDate == stockWork.StockCreateDate ||
                            _stockAnalysisOrderListCndtnWork.StockCreateDate < stockWork.StockCreateDate))
                        {
                            stockAnalysisOrderListWork.StockCreateDate = stockWork.StockCreateDate;
                        }
                        else
                        {
                            continue;
                        }
                    }
                    else
                    {
                        stockAnalysisOrderListWork.StockCreateDate = stockWork.StockCreateDate;
                    }
                    
                    // 仕入先略称
                    stockAnalysisOrderListWork.SupplierSnm = stockWork.SupplierSnm;

                    // 部品管理区分１
                    if (_stockAnalysisOrderListCndtnWork.PartsManagementDivide1 != null)
                    {
                        string Divied1 = "";
                        foreach (string Divide1str in _stockAnalysisOrderListCndtnWork.PartsManagementDivide1)
                        {
                            if (Divied1 != "")
                            {
                                Divied1 += ",";
                            }
                            Divied1 += "'" + Divide1str + "'";
                        }

                        if (Divied1 != "")
                        {
                            if (stockWork.PartsManagementDivide1.Trim() == "") continue;
                            if (Divied1.Contains(stockWork.PartsManagementDivide1.Trim()))
                            {
                                stockAnalysisOrderListWork.PartsManagementDivide1 = stockWork.PartsManagementDivide1;
                            }
                            else
                            {
                                continue;
                            }
                        }
                        else
                        {
                            stockAnalysisOrderListWork.PartsManagementDivide1 = stockWork.PartsManagementDivide1;
                        }
                    }

                    
                    // 部品管理区分２
                    if (_stockAnalysisOrderListCndtnWork.PartsManagementDivide2 != null)
                    {
                        string Divied2 = "";
                        foreach (string Divide2str in _stockAnalysisOrderListCndtnWork.PartsManagementDivide2)
                        {
                            if (Divied2 != "")
                            {
                                Divied2 += ",";
                            }
                            Divied2 += "'" + Divide2str + "'";
                        }

                        if (Divied2 != "")
                        {
                            if (stockWork.PartsManagementDivide2.Trim() == "") continue;
                            if (Divied2.Contains(stockWork.PartsManagementDivide2.Trim()))
                            {
                                stockAnalysisOrderListWork.PartsManagementDivide2 = stockWork.PartsManagementDivide2;
                            }
                            else
                            {
                                continue;
                            }
                        }
                        else
                        {
                            stockAnalysisOrderListWork.PartsManagementDivide2 = stockWork.PartsManagementDivide2;
                        }
                    }


                    // 合計値の計算
                    //key2 = st.SectionCode + st.WarehouseCode + st.GoodsNo + st.GoodsMakerCd.ToString("0000"); //DEL by Liangsd     2011/08/30
                    key2 = st.WarehouseCode + st.GoodsNo + st.GoodsMakerCd.ToString("0000");//ADD by Liangsd    2011/08/30
                    if (dicStock.ContainsKey(key2) == true)
                    {
                        dicStock[key2].SalesMoneyTaxExc += (st.SalesMoneyTaxExc + st.SalesRetGoodsPrice);
                        dicStock[key2].GrossProfit += st.GrossProfit;
                        dicStock[key2].ShipmentCnt += (st.SalesCount + st.SalesRetGoodsCnt);
                    }
                    else
                    {
                        stockAnalysisOrderListWork.SalesMoneyTaxExc = (st.SalesMoneyTaxExc + st.SalesRetGoodsPrice);
                        stockAnalysisOrderListWork.GrossProfit = st.GrossProfit;
                        stockAnalysisOrderListWork.ShipmentCnt = (st.SalesCount + st.SalesRetGoodsCnt);

                        if (keyStockList.Contains(key2) == false)
                        {
                            keyStockList.Add(key2);
                            if (!lastKey.Contains(key2))
                            {
                                lastKey.Add(key2);
                            }
                            dicStock.Add(key2, stockAnalysisOrderListWork);
                        }

                    }
                }
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            return status;

        }
        #endregion

        /// <summary>
        /// 検索条件文字列生成＋条件値設定
        /// </summary>
        /// <param name="al">検索結果ArrayList</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="_stockMoveListCndtnWork">検索条件格納クラス</param>
        /// <param name="_productNumberOutPutDiv">製番抽出区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Update Note: 2011/09/07 田建委</br>
        /// <br>           : redmine#23884の対応</br>
        /// <br>Update Note: 2018/07/24 31622 脇田靖之</br>
        /// <br>管理番号   : 11400020-00</br>
        /// <br>             対象データが抽出できない障害対応</br>
        private int SearchStockAnalysisOrderProc(ref Dictionary<string, StockAnalysisOrderListWork> dicHist, ref ArrayList histKey, ref ArrayList lastKey, ref SqlConnection sqlConnection, StockAnalysisOrderListCndtnWork _stockAnalysisOrderListCndtnWork, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            string hKey = string.Empty;

            try
            {
                string selectDm = "";

                // 対象テーブル
                // STOCKHISTORYRF STHIS  在庫履歴データ
                // STOCKRF        STOCK  在庫マスタ
                // SECINFOSETRF   SECI   拠点情報設定マスタ
                // GOODSMNGRF     GOODSM 商品管理情報マスタ
                // SUPPLIERRF     SUP    仕入先マスタ
                // GOODSURF       GDSU   商品マスタ
                // BLGOODSCDURF   BLGDCU BL商品コードマスタ
                // BLGROUPURF     BLGRPU BLグループマスタ

                #region Select文作成
                selectDm += "SELECT" + Environment.NewLine;
                //selectDm += "  STHIS.SECTIONCODERF" + Environment.NewLine;
                //selectDm += " ,SECI.SECTIONGUIDENMRF" + Environment.NewLine;
                selectDm += "  STHIS.WAREHOUSECODERF" + Environment.NewLine;
                selectDm += " ,STHIS.WAREHOUSENAMERF" + Environment.NewLine;
                //selectDm += " ,GOODSM.SUPPLIERCDRF" + Environment.NewLine;
                //selectDm += " ,SUP.SUPPLIERSNMRF" + Environment.NewLine;
                selectDm += " ,BLGRPU.GOODSLGROUPRF" + Environment.NewLine;
                selectDm += " ,BLGRPU.GOODSMGROUPRF" + Environment.NewLine;
                selectDm += " ,BLGDCU.BLGROUPCODERF" + Environment.NewLine;
                selectDm += " ,STHIS.GOODSNORF" + Environment.NewLine;
                selectDm += " ,GDSU.GOODSNAMERF" + Environment.NewLine;
                selectDm += " ,STOCK.WAREHOUSESHELFNORF" + Environment.NewLine;
                selectDm += " ,STHIS.SUMSALESMONEYTAXEXC" + Environment.NewLine;
                selectDm += " ,STHIS.SUMGROSSPROFIT" + Environment.NewLine;
                selectDm += " ,STHIS.SUMSHIPMENTCNT" + Environment.NewLine;
                selectDm += " ,STOCK.STOCKCREATEDATERF" + Environment.NewLine;
                selectDm += " ,STOCK.SHIPMENTPOSCNTRF" + Environment.NewLine;
                selectDm += " ,STOCK.MINIMUMSTOCKCNTRF" + Environment.NewLine;
                selectDm += " ,STOCK.MAXIMUMSTOCKCNTRF" + Environment.NewLine;
                selectDm += " ,GDSU.BLGOODSCODERF" + Environment.NewLine;
                selectDm += " ,STHIS.GOODSMAKERCDRF" + Environment.NewLine;
                selectDm += " ,STOCK.PARTSMANAGEMENTDIVIDE1RF" + Environment.NewLine;
                selectDm += " ,STOCK.PARTSMANAGEMENTDIVIDE2RF" + Environment.NewLine;
                selectDm += " FROM (" + Environment.NewLine;
                selectDm += " SELECT" + Environment.NewLine;
                selectDm += "  STHIS2.ENTERPRISECODERF" + Environment.NewLine;
                selectDm += " ,STHIS2.LOGICALDELETECODERF" + Environment.NewLine;
                //selectDm += " ,STHIS2.SECTIONCODERF" + Environment.NewLine;
                selectDm += " ,STHIS2.GOODSMAKERCDRF" + Environment.NewLine;
                selectDm += " ,STHIS2.WAREHOUSECODERF" + Environment.NewLine;
                selectDm += " ,STHIS2.GOODSNORF" + Environment.NewLine;
                selectDm += " ,STHIS2.WAREHOUSENAMERF" + Environment.NewLine;
                // --- DEL 2018/07/24 Y.Wakita ---------->>>>>
                //selectDm += " ,STHIS2.GOODSNAMERF" + Environment.NewLine;
                // --- DEL 2018/07/24 Y.Wakita ----------<<<<<
                selectDm += " ,SUM(CASE WHEN STHIS2.ADDUPYEARMONTHRF BETWEEN @STADDUPYEARMONTH AND @EDADDUPYEARMONTH " + Environment.NewLine;
                selectDm += "      THEN (STHIS2.SALESMONEYTAXEXCRF + STHIS2.SALESRETGOODSPRICERF) ELSE 0 END) AS SUMSALESMONEYTAXEXC" + Environment.NewLine;
                selectDm += " ,SUM(CASE WHEN STHIS2.ADDUPYEARMONTHRF BETWEEN @STADDUPYEARMONTH AND @EDADDUPYEARMONTH " + Environment.NewLine;
                selectDm += "      THEN STHIS2.GROSSPROFITRF ELSE 0 END) AS SUMGROSSPROFIT" + Environment.NewLine;
                selectDm += " ,SUM(CASE WHEN STHIS2.ADDUPYEARMONTHRF BETWEEN @STADDUPYEARMONTH AND @EDADDUPYEARMONTH " + Environment.NewLine;
                selectDm += "      THEN (STHIS2.SALESCOUNTRF + STHIS2.SALESRETGOODSCNTRF) ELSE 0 END) AS SUMSHIPMENTCNT" + Environment.NewLine;
                selectDm += " FROM STOCKHISTORYRF AS STHIS2" + Environment.NewLine;
                selectDm += " GROUP BY" + Environment.NewLine;
                selectDm += "  STHIS2.ENTERPRISECODERF" + Environment.NewLine;
                selectDm += " ,STHIS2.LOGICALDELETECODERF" + Environment.NewLine;
                //selectDm += " ,STHIS2.SECTIONCODERF" + Environment.NewLine;
                selectDm += " ,STHIS2.GOODSMAKERCDRF" + Environment.NewLine;
                selectDm += " ,STHIS2.WAREHOUSECODERF" + Environment.NewLine;
                selectDm += " ,STHIS2.GOODSNORF" + Environment.NewLine;
                selectDm += " ,STHIS2.WAREHOUSENAMERF" + Environment.NewLine;
                // --- DEL 2018/07/24 Y.Wakita ---------->>>>>
                //selectDm += " ,STHIS2.GOODSNAMERF" + Environment.NewLine;
                // --- DEL 2018/07/24 Y.Wakita ----------<<<<<
                selectDm += " ) AS STHIS" + Environment.NewLine;

                //在庫マスタ
                selectDm += " LEFT JOIN STOCKRF AS STOCK" + Environment.NewLine;
                selectDm += " ON  STOCK.ENTERPRISECODERF=STHIS.ENTERPRISECODERF" + Environment.NewLine;
                //selectDm += " AND STOCK.SECTIONCODERF=STHIS.SECTIONCODERF" + Environment.NewLine;
                selectDm += " AND STOCK.GOODSMAKERCDRF=STHIS.GOODSMAKERCDRF" + Environment.NewLine;
                selectDm += " AND STOCK.GOODSNORF=STHIS.GOODSNORF" + Environment.NewLine;
                selectDm += " AND STOCK.WAREHOUSECODERF=STHIS.WAREHOUSECODERF" + Environment.NewLine;

                //拠点情報設定マスタ
                //selectDm += " LEFT JOIN SECINFOSETRF SECI" + Environment.NewLine;
                //selectDm += " ON  SECI.ENTERPRISECODERF = STOCK.ENTERPRISECODERF" + Environment.NewLine;
                //selectDm += " AND SECI.SECTIONCODERF = STOCK.SECTIONCODERF" + Environment.NewLine;

                //商品管理情報マスタ
                //selectDm += " LEFT JOIN GOODSMNGRF GOODSM" + Environment.NewLine;
                //selectDm += " ON  GOODSM.ENTERPRISECODERF = STOCK.ENTERPRISECODERF" + Environment.NewLine;
                ////selectDm += " AND GOODSM.SECTIONCODERF = STOCK.SECTIONCODERF" + Environment.NewLine;
                //selectDm += " AND GOODSM.GOODSMAKERCDRF = STOCK.GOODSMAKERCDRF" + Environment.NewLine;
                //selectDm += " AND GOODSM.GOODSNORF = STOCK.GOODSNORF" + Environment.NewLine;

                ////仕入先マスタ
                //selectDm += " LEFT JOIN SUPPLIERRF SUP" + Environment.NewLine;
                //selectDm += " ON  SUP.ENTERPRISECODERF = STOCK.ENTERPRISECODERF" + Environment.NewLine;
                //selectDm += " AND SUP.SUPPLIERCDRF = STOCK.STOCKSUPPLIERCODERF" + Environment.NewLine;

                //商品マスタ
                selectDm += " LEFT JOIN GOODSURF GDSU" + Environment.NewLine;
                selectDm += " ON  GDSU.ENTERPRISECODERF = STOCK.ENTERPRISECODERF" + Environment.NewLine;
                selectDm += " AND GDSU.GOODSMAKERCDRF = STOCK.GOODSMAKERCDRF" + Environment.NewLine;
                selectDm += " AND GDSU.GOODSNORF = STOCK.GOODSNORF" + Environment.NewLine;

                //BL商品コードマスタ(商品マスタのBL商品コードをキーに取得)
                selectDm += " LEFT JOIN BLGOODSCDURF BLGDCU" + Environment.NewLine;
                selectDm += " ON  BLGDCU.ENTERPRISECODERF = GDSU.ENTERPRISECODERF" + Environment.NewLine;
                selectDm += " AND BLGDCU.BLGOODSCODERF = GDSU.BLGOODSCODERF" + Environment.NewLine;

                //BLグループマスタ(BL商品コードマスタのBLグループコードをキーに取得)
                selectDm += " LEFT JOIN BLGROUPURF BLGRPU" + Environment.NewLine;
                selectDm += " ON  BLGRPU.ENTERPRISECODERF = BLGDCU.ENTERPRISECODERF" + Environment.NewLine;
                selectDm += " AND BLGRPU.BLGROUPCODERF = BLGDCU.BLGROUPCODERF" + Environment.NewLine;

                #endregion

                sqlCommand = new SqlCommand(selectDm, sqlConnection);

                //WHERE文の作成
                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, _stockAnalysisOrderListCndtnWork, logicalMode);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    #region 抽出結果-値セット
                    StockAnalysisOrderListWork wkStockAnalysisOrderListWork = new StockAnalysisOrderListWork();

                    //在庫履歴格納項目
                    //wkStockAnalysisOrderListWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
                    //wkStockAnalysisOrderListWork.SectionGuideNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDENMRF"));
                    wkStockAnalysisOrderListWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSECODERF"));
                    wkStockAnalysisOrderListWork.WarehouseName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSENAMERF"));
                    //wkStockAnalysisOrderListWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
                    //wkStockAnalysisOrderListWork.SupplierSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSNMRF"));
                    wkStockAnalysisOrderListWork.GoodsLGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSLGROUPRF"));
                    wkStockAnalysisOrderListWork.GoodsMGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMGROUPRF"));
                    wkStockAnalysisOrderListWork.BLGroupCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGROUPCODERF"));
                    wkStockAnalysisOrderListWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
                    wkStockAnalysisOrderListWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMERF"));
                    wkStockAnalysisOrderListWork.WarehouseShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSESHELFNORF"));
                    wkStockAnalysisOrderListWork.SalesMoneyTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SUMSALESMONEYTAXEXC"));
                    wkStockAnalysisOrderListWork.GrossProfit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SUMGROSSPROFIT"));
                    wkStockAnalysisOrderListWork.ShipmentCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SUMSHIPMENTCNT"));
                    wkStockAnalysisOrderListWork.StockCreateDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("STOCKCREATEDATERF"));
                    wkStockAnalysisOrderListWork.ShipmentPosCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SHIPMENTPOSCNTRF"));
                    wkStockAnalysisOrderListWork.MinimumStockCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("MINIMUMSTOCKCNTRF"));
                    wkStockAnalysisOrderListWork.MaximumStockCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("MAXIMUMSTOCKCNTRF"));
                    wkStockAnalysisOrderListWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));

                    wkStockAnalysisOrderListWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
                    wkStockAnalysisOrderListWork.PartsManagementDivide1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTSMANAGEMENTDIVIDE1RF"));
                    wkStockAnalysisOrderListWork.PartsManagementDivide2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTSMANAGEMENTDIVIDE2RF"));
                    #endregion
                    // ----- UPD 2011/09/07 --------------------------------------->>>>>
                    //hKey = /*wkStockAnalysisOrderListWork.SectionCode +*/ wkStockAnalysisOrderListWork.WarehouseCode + wkStockAnalysisOrderListWork.GoodsNo + wkStockAnalysisOrderListWork.GoodsMakerCd;
                    hKey = wkStockAnalysisOrderListWork.WarehouseCode + wkStockAnalysisOrderListWork.GoodsNo + wkStockAnalysisOrderListWork.GoodsMakerCd.ToString("0000");
                    // ----- UPD 2011/09/07 ---------------------------------------<<<<<
                    histKey.Add(hKey);
                    if (dicHist.ContainsKey(hKey) == false)
                    {
                        dicHist.Add(hKey, wkStockAnalysisOrderListWork);
                        
                        if (lastKey.Contains(hKey) == false)
                        {
                            lastKey.Add(hKey);
                        }
                    }
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "StockAnalysisOrderListWorkDB.SearchStockAnalysisOrderProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (!myReader.IsClosed) myReader.Close();
            }

            return status;
        }
        #endregion

        #region SearchStockProc
        /// <summary>
        /// 検索条件文字列生成＋条件値設定
        /// </summary>
        /// <param name="stockHistoryList">検索結果ArrayList</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="_stockMonthYearReportWork">検索条件格納クラス</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        private int SearchStockProc(ref Dictionary<string, StockAnalysisOrderListWork> dic, ref SqlConnection sqlConnection, StockAnalysisOrderListCndtnWork _stockNoShipmentListCndtnWork, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            string key = string.Empty;

            try
            {
                string selectTxt = "";
                sqlCommand = new SqlCommand(selectTxt, sqlConnection);

                #region SELECT文
                selectTxt += "SELECT " + Environment.NewLine;
                selectTxt += "	       STOCK.CREATEDATETIMERF" + Environment.NewLine;
                selectTxt += "        ,STOCK.UPDATEDATETIMERF" + Environment.NewLine;
                selectTxt += "        ,STOCK.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "        ,STOCK.FILEHEADERGUIDRF" + Environment.NewLine;
                selectTxt += "        ,STOCK.UPDEMPLOYEECODERF" + Environment.NewLine;
                selectTxt += "        ,STOCK.UPDASSEMBLYID1RF" + Environment.NewLine;
                selectTxt += "        ,STOCK.UPDASSEMBLYID2RF" + Environment.NewLine;
                selectTxt += "        ,STOCK.LOGICALDELETECODERF" + Environment.NewLine;
                selectTxt += "        ,STOCK.SECTIONCODERF" + Environment.NewLine;
                selectTxt += "        ,STOCK.WAREHOUSECODERF" + Environment.NewLine;
                selectTxt += "        ,STOCK.GOODSMAKERCDRF" + Environment.NewLine;
                selectTxt += "        ,STOCK.GOODSNORF" + Environment.NewLine;
                selectTxt += "        ,STOCK.STOCKUNITPRICEFLRF" + Environment.NewLine;
                selectTxt += "        ,STOCK.SUPPLIERSTOCKRF" + Environment.NewLine;
                selectTxt += "        ,STOCK.ACPODRCOUNTRF" + Environment.NewLine;
                selectTxt += "        ,STOCK.MONTHORDERCOUNTRF" + Environment.NewLine;
                selectTxt += "        ,STOCK.SALESORDERCOUNTRF" + Environment.NewLine;
                selectTxt += "        ,STOCK.STOCKDIVRF" + Environment.NewLine;
                selectTxt += "        ,STOCK.MOVINGSUPLISTOCKRF" + Environment.NewLine;
                selectTxt += "        ,STOCK.SHIPMENTPOSCNTRF" + Environment.NewLine;
                selectTxt += "        ,STOCK.STOCKTOTALPRICERF" + Environment.NewLine;
                selectTxt += "        ,STOCK.LASTSTOCKDATERF" + Environment.NewLine;
                selectTxt += "        ,STOCK.LASTSALESDATERF" + Environment.NewLine;
                selectTxt += "        ,STOCK.LASTINVENTORYUPDATERF" + Environment.NewLine;
                selectTxt += "        ,STOCK.MINIMUMSTOCKCNTRF" + Environment.NewLine;
                selectTxt += "        ,STOCK.MAXIMUMSTOCKCNTRF" + Environment.NewLine;
                selectTxt += "        ,STOCK.NMLSALODRCOUNTRF" + Environment.NewLine;
                selectTxt += "        ,STOCK.SALESORDERUNITRF" + Environment.NewLine;
                selectTxt += "        ,STOCK.STOCKSUPPLIERCODERF" + Environment.NewLine;
                selectTxt += "        ,STOCK.GOODSNONONEHYPHENRF" + Environment.NewLine;
                selectTxt += "        ,STOCK.WAREHOUSESHELFNORF" + Environment.NewLine;
                selectTxt += "        ,STOCK.DUPLICATIONSHELFNO1RF" + Environment.NewLine;
                selectTxt += "        ,STOCK.DUPLICATIONSHELFNO2RF" + Environment.NewLine;
                selectTxt += "        ,STOCK.PARTSMANAGEMENTDIVIDE1RF" + Environment.NewLine;
                selectTxt += "        ,STOCK.PARTSMANAGEMENTDIVIDE2RF" + Environment.NewLine;
                selectTxt += "        ,STOCK.STOCKNOTE1RF" + Environment.NewLine;
                selectTxt += "        ,STOCK.STOCKNOTE2RF" + Environment.NewLine;
                selectTxt += "        ,STOCK.SHIPMENTCNTRF" + Environment.NewLine;
                selectTxt += "        ,STOCK.ARRIVALCNTRF" + Environment.NewLine;
                selectTxt += "        ,STOCK.STOCKCREATEDATERF" + Environment.NewLine;
                selectTxt += "        ,STOCK.UPDATEDATERF" + Environment.NewLine;
                selectTxt += "        ,GOODS.BLGOODSCODERF" + Environment.NewLine;
                selectTxt += "        ,MAKER.MAKERNAMERF" + Environment.NewLine;
                selectTxt += "        ,SECI.SECTIONGUIDENMRF" + Environment.NewLine;
                selectTxt += "        ,GOODS.GOODSNAMERF" + Environment.NewLine;
                selectTxt += "        ,GOODSM.SUPPLIERCDRF" + Environment.NewLine;
                selectTxt += "        ,SUPP.SUPPLIERSNMRF" + Environment.NewLine;
                selectTxt += "        ,WARE.WAREHOUSENAMERF" + Environment.NewLine;
                selectTxt += "        ,BLGO.BLGROUPCODERF" + Environment.NewLine;
                selectTxt += "        ,GROU.GOODSLGROUPRF" + Environment.NewLine;
                selectTxt += "        ,GROU.GOODSMGROUPRF" + Environment.NewLine;
                selectTxt += "FROM STOCKRF AS STOCK" + Environment.NewLine;
                selectTxt += "LEFT JOIN GOODSURF AS GOODS" + Environment.NewLine;
                selectTxt += " ON" + Environment.NewLine;
                selectTxt += "      GOODS.ENTERPRISECODERF=STOCK.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "  AND GOODS.GOODSMAKERCDRF=STOCK.GOODSMAKERCDRF" + Environment.NewLine;
                selectTxt += "  AND GOODS.GOODSNORF=STOCK.GOODSNORF" + Environment.NewLine;
                selectTxt += "LEFT JOIN MAKERURF AS MAKER" + Environment.NewLine;
                selectTxt += " ON" + Environment.NewLine;
                selectTxt += "      MAKER.ENTERPRISECODERF=STOCK.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "  AND MAKER.GOODSMAKERCDRF=STOCK.GOODSMAKERCDRF" + Environment.NewLine;
                selectTxt += "LEFT JOIN SECINFOSETRF SECI" + Environment.NewLine;
                selectTxt += " ON" + Environment.NewLine;
                selectTxt += "      SECI.ENTERPRISECODERF = STOCK.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "  AND SECI.SECTIONCODERF = STOCK.SECTIONCODERF" + Environment.NewLine;
                selectTxt += " LEFT JOIN GOODSMNGRF AS GOODSM" + Environment.NewLine;
                selectTxt += " ON" + Environment.NewLine;
                selectTxt += "      GOODSM.ENTERPRISECODERF=STOCK.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "  AND GOODSM.SECTIONCODERF=STOCK.SECTIONCODERF" + Environment.NewLine;
                selectTxt += "  AND GOODSM.GOODSMAKERCDRF=STOCK.GOODSMAKERCDRF" + Environment.NewLine;
                selectTxt += "  AND GOODSM.GOODSNORF=STOCK.GOODSNORF" + Environment.NewLine;
                selectTxt += "LEFT JOIN SUPPLIERRF AS SUPP" + Environment.NewLine;
                selectTxt += " ON" + Environment.NewLine;
                selectTxt += "      SUPP.ENTERPRISECODERF=GOODSM.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "  AND SUPP.SUPPLIERCDRF=GOODSM.SUPPLIERCDRF" + Environment.NewLine;
                selectTxt += "LEFT JOIN WAREHOUSERF AS WARE" + Environment.NewLine;
                selectTxt += " ON" + Environment.NewLine;
                selectTxt += "      WARE.ENTERPRISECODERF=STOCK.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "  AND WARE.WAREHOUSECODERF=STOCK.WAREHOUSECODERF" + Environment.NewLine;
                selectTxt += "LEFT JOIN BLGOODSCDURF AS BLGO" + Environment.NewLine;
                selectTxt += " ON" + Environment.NewLine;
                selectTxt += "      BLGO.ENTERPRISECODERF=GOODS.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "  AND BLGO.BLGOODSCODERF=GOODS.BLGOODSCODERF" + Environment.NewLine;
                selectTxt += "LEFT JOIN BLGROUPURF AS GROU" + Environment.NewLine;
                selectTxt += " ON" + Environment.NewLine;
                selectTxt += "      GROU.ENTERPRISECODERF=BLGO.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "  AND GROU.BLGROUPCODERF=BLGO.BLGROUPCODERF" + Environment.NewLine;

                selectTxt += MakeWhereStockString(ref sqlCommand, _stockNoShipmentListCndtnWork, logicalMode);

                sqlCommand.CommandText = selectTxt;

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {

                    StockAnalysisOrderListWork wkstockWork = new StockAnalysisOrderListWork();

                    // 格納処理
                    #region 抽出結果格納処理
                    wkstockWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
                    wkstockWork.SectionGuideNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDENMRF"));
                    wkstockWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSECODERF"));
                    wkstockWork.WarehouseName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSENAMERF"));
                    wkstockWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
                    wkstockWork.WarehouseShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSESHELFNORF"));
                    wkstockWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
                    wkstockWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
                    wkstockWork.PartsManagementDivide1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTSMANAGEMENTDIVIDE1RF"));
                    wkstockWork.PartsManagementDivide2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTSMANAGEMENTDIVIDE2RF"));
                    wkstockWork.StockCreateDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("STOCKCREATEDATERF"));
                    wkstockWork.SectionGuideNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDENMRF"));
                    wkstockWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMERF"));
                    wkstockWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
                    wkstockWork.SupplierSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSNMRF"));
                    wkstockWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
                    wkstockWork.ShipmentPosCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SHIPMENTPOSCNTRF"));
                    wkstockWork.MinimumStockCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("MINIMUMSTOCKCNTRF"));
                    wkstockWork.MaximumStockCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("MAXIMUMSTOCKCNTRF"));
                    wkstockWork.BLGroupCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGROUPCODERF"));
                    wkstockWork.GoodsLGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSLGROUPRF"));
                    wkstockWork.GoodsMGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMGROUPRF"));
                    wkstockWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
                    #endregion

                    key = wkstockWork.WarehouseCode + wkstockWork.GoodsNo + wkstockWork.GoodsMakerCd.ToString("0000");

                    dic.Add(key, wkstockWork);
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                #endregion
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "StockMonthYearReportWorkDB.SearchHistoryProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null)
                    sqlCommand.Dispose();

                if (myReader != null)
                {
                    if (!myReader.IsClosed)
                        myReader.Close();
                }
            }

            return status;
        }
        #endregion

        #region 在庫履歴 WHERE句
        /// <summary>
        /// 検索条件文字列生成＋条件値設定
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="_stockMoveListCndtnWork">検索条件格納クラス</param>
        /// <param name="_productNumberOutPutDiv">製番抽出区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>Where条件文字列</returns>
        /// <br>Update Note: 2012/12/24 王君</br>
        /// <br>           : redmine#33977の対応</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, StockAnalysisOrderListCndtnWork _stockAnalysisOrderListCndtnWork, ConstantManagement.LogicalMode logicalMode)
        {
            #region WHERE文作成
            string retstring = "WHERE" + Environment.NewLine;

            //企業コード
            retstring += " STHIS.ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(_stockAnalysisOrderListCndtnWork.EnterpriseCode);

            // 論理削除
            if ((logicalMode == ConstantManagement.LogicalMode.GetData0) || (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData2) || (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                retstring += " AND STHIS.LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + Environment.NewLine; 
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
            }
            else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) || (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                retstring += " AND STHIS.LOGICALDELETECODERF<@FINDLOGICALDELETECODE" + Environment.NewLine;
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                if (logicalMode == ConstantManagement.LogicalMode.GetData01) paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
                else paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
            }

            retstring += " AND STOCK.LOGICALDELETECODERF =0" + Environment.NewLine;

            retstring += " AND GDSU.LOGICALDELETECODERF =0" + Environment.NewLine;

            //年月度設定
            SqlParameter paraStAddUpYearMonth = sqlCommand.Parameters.Add("@STADDUPYEARMONTH", SqlDbType.Int);
            paraStAddUpYearMonth.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(_stockAnalysisOrderListCndtnWork.St_AddUpYearMonth);

            SqlParameter paraEdAddUpYearMonth = sqlCommand.Parameters.Add("@EDADDUPYEARMONTH", SqlDbType.Int);
            paraEdAddUpYearMonth.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(_stockAnalysisOrderListCndtnWork.Ed_AddUpYearMonth);

            //拠点コード
            //if (_stockAnalysisOrderListCndtnWork.SectionCodes != null)
            //{
            //    string sectionCodestr = "";
            //    foreach (string seccdstr in _stockAnalysisOrderListCndtnWork.SectionCodes)
            //    {
            //        if (sectionCodestr != "")
            //        {
            //            sectionCodestr += ",";
            //        }
            //        sectionCodestr += "'" + seccdstr + "'";
            //    }
            //    if (sectionCodestr != "")
            //    {
            //        retstring += " AND STHIS.SECTIONCODERF IN (" + sectionCodestr + ") ";
            //    }
            //    retstring += Environment.NewLine;
            //}

            //倉庫コード設定
            if (_stockAnalysisOrderListCndtnWork.St_WarehouseCode != "")
            {
                retstring += " AND STHIS.WAREHOUSECODERF>=@STWAREHOUSECODE" + Environment.NewLine;
                SqlParameter paraStWarehouseCode = sqlCommand.Parameters.Add("@STWAREHOUSECODE", SqlDbType.NChar);
                paraStWarehouseCode.Value = SqlDataMediator.SqlSetString(_stockAnalysisOrderListCndtnWork.St_WarehouseCode);
            }
            if (_stockAnalysisOrderListCndtnWork.Ed_WarehouseCode != "")
            {
                retstring += " AND (STHIS.WAREHOUSECODERF<=@EDWAREHOUSECODE OR STHIS.WAREHOUSECODERF LIKE @EDWAREHOUSECODE)" + Environment.NewLine;
                SqlParameter paraEdWarehouseCode = sqlCommand.Parameters.Add("@EDWAREHOUSECODE", SqlDbType.NChar);
                paraEdWarehouseCode.Value = SqlDataMediator.SqlSetString(_stockAnalysisOrderListCndtnWork.Ed_WarehouseCode + "%");
            }

            //仕入先コード設定
            //if (_stockAnalysisOrderListCndtnWork.St_SupplierCd != 0)
            //{
            //    retstring += " AND SUP.SUPPLIERCDRF>=@STSUPPLIERCD" + Environment.NewLine;
            //    SqlParameter paraStSupplierCd = sqlCommand.Parameters.Add("@STSUPPLIERCD", SqlDbType.Int);
            //    paraStSupplierCd.Value = SqlDataMediator.SqlSetInt32(_stockAnalysisOrderListCndtnWork.St_SupplierCd);
            //}
            //if (_stockAnalysisOrderListCndtnWork.Ed_SupplierCd != 999999)
            //{
            //    retstring += " AND SUP.SUPPLIERCDRF<=@EDSUPPLIERCD" + Environment.NewLine;
            //    SqlParameter paraEdSupplierCd = sqlCommand.Parameters.Add("@EDSUPPLIERCD", SqlDbType.Int);
            //    paraEdSupplierCd.Value = SqlDataMediator.SqlSetInt32(_stockAnalysisOrderListCndtnWork.Ed_SupplierCd);
            //}


            //メーカーコード設定
            if (_stockAnalysisOrderListCndtnWork.St_GoodsMakerCd != 0)
            {
                retstring += " AND STHIS.GOODSMAKERCDRF>=@STGOODSMAKERCD" + Environment.NewLine;
                SqlParameter paraStGoodsMakerCd = sqlCommand.Parameters.Add("@STGOODSMAKERCD", SqlDbType.Int);
                paraStGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(_stockAnalysisOrderListCndtnWork.St_GoodsMakerCd);
            }
            if (_stockAnalysisOrderListCndtnWork.Ed_GoodsMakerCd != 9999)
            {
                retstring += " AND STHIS.GOODSMAKERCDRF<=@EDGOODSMAKERCD" + Environment.NewLine;
                SqlParameter paraEdGoodsMakerCd = sqlCommand.Parameters.Add("@EDGOODSMAKERCD", SqlDbType.Int);
                paraEdGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(_stockAnalysisOrderListCndtnWork.Ed_GoodsMakerCd);
            }

            //BLコード設定
            if (_stockAnalysisOrderListCndtnWork.St_BLGoodsCode != 0)
            {
                retstring += " AND GDSU.BLGOODSCODERF>=@STBLGOODSCODE" + Environment.NewLine;
                SqlParameter paraStBLGoodsCode = sqlCommand.Parameters.Add("@STBLGOODSCODE", SqlDbType.Int);
                paraStBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(_stockAnalysisOrderListCndtnWork.St_BLGoodsCode);
            }
            if (_stockAnalysisOrderListCndtnWork.Ed_BLGoodsCode != 99999)
            {
                retstring += " AND GDSU.BLGOODSCODERF<=@EDBLGOODSCODE" + Environment.NewLine;
                SqlParameter paraEdBLGoodsCode = sqlCommand.Parameters.Add("@EDBLGOODSCODE", SqlDbType.Int);
                paraEdBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(_stockAnalysisOrderListCndtnWork.Ed_BLGoodsCode);
            }

            //商品番号設定
            if (_stockAnalysisOrderListCndtnWork.St_GoodsNo != "")
            {
                retstring += " AND STHIS.GOODSNORF>=@STGOODSNO" + Environment.NewLine;
                SqlParameter paraStGoodsCd = sqlCommand.Parameters.Add("@STGOODSNO", SqlDbType.NVarChar);
                paraStGoodsCd.Value = SqlDataMediator.SqlSetString(_stockAnalysisOrderListCndtnWork.St_GoodsNo);
            }
            if (_stockAnalysisOrderListCndtnWork.Ed_GoodsNo != "")
            {
                retstring += " AND (STHIS.GOODSNORF<=@EDGOODSNO OR STHIS.GOODSNORF LIKE @EDGOODSNO)" + Environment.NewLine;
                SqlParameter paraEdGoodsNo = sqlCommand.Parameters.Add("@EDGOODSNO", SqlDbType.NVarChar);
                paraEdGoodsNo.Value = SqlDataMediator.SqlSetString(_stockAnalysisOrderListCndtnWork.Ed_GoodsNo + "%");
            }

            //棚番設定
            if (_stockAnalysisOrderListCndtnWork.St_WarehouseShelfNo != "")
            {
                retstring += " AND STOCK.WAREHOUSESHELFNORF>=@STWAREHOUSESHELFNO" + Environment.NewLine;
                SqlParameter paraStWarehouseShelfNo = sqlCommand.Parameters.Add("@STWAREHOUSESHELFNO", SqlDbType.NVarChar);
                paraStWarehouseShelfNo.Value = SqlDataMediator.SqlSetString(_stockAnalysisOrderListCndtnWork.St_WarehouseShelfNo);
            }
            if (_stockAnalysisOrderListCndtnWork.Ed_WarehouseShelfNo != "")
            {
                retstring += " AND (STOCK.WAREHOUSESHELFNORF<=@EDWAREHOUSESHELFNO OR STOCK.WAREHOUSESHELFNORF LIKE @EDWAREHOUSESHELFNO)" + Environment.NewLine;
                SqlParameter paraEdWarehouseShelfNo = sqlCommand.Parameters.Add("@EDWAREHOUSESHELFNO", SqlDbType.NVarChar);
                paraEdWarehouseShelfNo.Value = SqlDataMediator.SqlSetString(_stockAnalysisOrderListCndtnWork.Ed_WarehouseShelfNo + "%");
            }

            //在庫登録日
            if (_stockAnalysisOrderListCndtnWork.StockCreateDate != DateTime.MinValue)
            {
                if (_stockAnalysisOrderListCndtnWork.StockCreateDateDiv == 0)
                {
                    //retstring += " AND STOCK.STOCKCREATEDATERF<=@STOCKCREATEDATE" + Environment.NewLine;// DEL 2012/12/24 王君 Redmine#33977
                    retstring += " AND ISNULL(STOCK.STOCKCREATEDATERF, 0)<=@STOCKCREATEDATE" + Environment.NewLine;// ADD 2012/12/24 王君 Redmine#33977
                }
                else
                {
                    retstring += " AND STOCK.STOCKCREATEDATERF>=@STOCKCREATEDATE" + Environment.NewLine;
                }
                SqlParameter paraStockCreateDate = sqlCommand.Parameters.Add("@STOCKCREATEDATE", SqlDbType.Int);
                paraStockCreateDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(_stockAnalysisOrderListCndtnWork.StockCreateDate);
            }

            ////出荷数
            //if (_stockAnalysisOrderListCndtnWork.St_ShipmentCnt != 0)
            //{
            //    retstring += " AND STHIS.SUMSHIPMENTCNT>=@STSHIPMENTCNT" + Environment.NewLine;
            //    SqlParameter paraStShipmentCnt = sqlCommand.Parameters.Add("@STSHIPMENTCNT", SqlDbType.Float);
            //    paraStShipmentCnt.Value = SqlDataMediator.SqlSetDouble(_stockAnalysisOrderListCndtnWork.St_ShipmentCnt);
            //}
            //if (_stockAnalysisOrderListCndtnWork.Ed_ShipmentCnt != 999999999)
            //{
            //    retstring += " AND STHIS.SUMSHIPMENTCNT<=@EDSHIPMENTCNT" + Environment.NewLine;
            //    SqlParameter paraEdShipmentCnt = sqlCommand.Parameters.Add("@EDSHIPMENTCNT", SqlDbType.Float);
            //    paraEdShipmentCnt.Value = SqlDataMediator.SqlSetDouble(_stockAnalysisOrderListCndtnWork.Ed_ShipmentCnt);
            //}

            //部品管理区分１  ※配列で複数指定される
            if (_stockAnalysisOrderListCndtnWork.PartsManagementDivide1 != null)
            {
                string Divied1 = "";
                foreach (string Divide1str in _stockAnalysisOrderListCndtnWork.PartsManagementDivide1)
                {
                    if (Divied1 != "")
                    {
                        Divied1 += ",";
                    }
                    Divied1 += "'" + Divide1str + "'";
                }

                if (Divied1 != "")
                {
                    retstring += " AND STOCK.PARTSMANAGEMENTDIVIDE1RF IN (" + Divied1 + ") ";
                }
            }

            //部品管理区分２  ※配列で複数指定される
            if (_stockAnalysisOrderListCndtnWork.PartsManagementDivide2 != null)
            {
                string Divied2 = "";
                foreach (string Divide2str in _stockAnalysisOrderListCndtnWork.PartsManagementDivide2)
                {
                    if (Divied2 != "")
                    {
                        Divied2 += ",";
                    }
                    Divied2 += "'" + Divide2str + "'";
                }

                if (Divied2 != "")
                {
                    retstring += " AND STOCK.PARTSMANAGEMENTDIVIDE2RF IN (" + Divied2 + ") ";
                }
            }

            #endregion
            return retstring;
        }
        #endregion

        #region [在庫マスタ WHERE句]
        /// <summary>
        /// 検索条件文字列生成＋条件値設定
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="_stockMoveListCndtnWork">検索条件格納クラス</param>
        /// <param name="_productNumberOutPutDiv">製番抽出区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>Where条件文字列</returns>
        private string MakeWhereStockString(ref SqlCommand sqlCommand, StockAnalysisOrderListCndtnWork _stockAnalysisOrderListCndtnWork, ConstantManagement.LogicalMode logicalMode)
        {
            string retstring = "WHERE" + Environment.NewLine;

            // 企業コード
            retstring += " STOCK.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(_stockAnalysisOrderListCndtnWork.EnterpriseCode);

            // 論理削除区分
            if ((logicalMode == ConstantManagement.LogicalMode.GetData0) || (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
               (logicalMode == ConstantManagement.LogicalMode.GetData2) || (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                retstring += " AND STOCK.LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + Environment.NewLine;
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
            }
            else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) || (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {

                retstring += " AND STOCK.LOGICALDELETECODERF<@FINDLOGICALDELETECODE" + Environment.NewLine;
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                if (logicalMode == ConstantManagement.LogicalMode.GetData01) paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
                else paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
            }

            //倉庫コード設定
            if (_stockAnalysisOrderListCndtnWork.St_WarehouseCode != "")
            {
                retstring += " AND STOCK.WAREHOUSECODERF>=@STWAREHOUSECODE" + Environment.NewLine;
                SqlParameter paraStWarehouseCode = sqlCommand.Parameters.Add("@STWAREHOUSECODE", SqlDbType.NChar);
                paraStWarehouseCode.Value = SqlDataMediator.SqlSetString(_stockAnalysisOrderListCndtnWork.St_WarehouseCode);
            }
            if (_stockAnalysisOrderListCndtnWork.Ed_WarehouseCode != "")
            {
                retstring += " AND STOCK.WAREHOUSECODERF<=@EDWAREHOUSECODE" + Environment.NewLine;
                SqlParameter paraEdWarehouseCode = sqlCommand.Parameters.Add("@EDWAREHOUSECODE", SqlDbType.NChar);
                paraEdWarehouseCode.Value = SqlDataMediator.SqlSetString(_stockAnalysisOrderListCndtnWork.Ed_WarehouseCode);
            }

            //メーカーコード設定
            if (_stockAnalysisOrderListCndtnWork.St_GoodsMakerCd != 0)
            {
                retstring += " AND STOCK.GOODSMAKERCDRF>=@STGOODSMAKERCD" + Environment.NewLine;
                SqlParameter paraStGoodsMakerCd = sqlCommand.Parameters.Add("@STGOODSMAKERCD", SqlDbType.Int);
                paraStGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(_stockAnalysisOrderListCndtnWork.St_GoodsMakerCd);
            }
            if (_stockAnalysisOrderListCndtnWork.Ed_GoodsMakerCd != 9999)
            {
                retstring += " AND STOCK.GOODSMAKERCDRF<=@EDGOODSMAKERCD" + Environment.NewLine;
                SqlParameter paraEdGoodsMakerCd = sqlCommand.Parameters.Add("@EDGOODSMAKERCD", SqlDbType.Int);
                paraEdGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(_stockAnalysisOrderListCndtnWork.Ed_GoodsMakerCd);
            }

            //商品番号設定
            if (_stockAnalysisOrderListCndtnWork.St_GoodsNo != "")
            {
                retstring += " AND STOCK.GOODSNORF>=@STGOODSNO" + Environment.NewLine;
                SqlParameter paraStGoodsCd = sqlCommand.Parameters.Add("@STGOODSNO", SqlDbType.NVarChar);
                paraStGoodsCd.Value = SqlDataMediator.SqlSetString(_stockAnalysisOrderListCndtnWork.St_GoodsNo);
            }
            if (_stockAnalysisOrderListCndtnWork.Ed_GoodsNo != "")
            {
                retstring += " AND STOCK.GOODSNORF<=@EDGOODSNO" + Environment.NewLine;
                SqlParameter paraEdGoodsNo = sqlCommand.Parameters.Add("@EDGOODSNO", SqlDbType.NVarChar);
                paraEdGoodsNo.Value = SqlDataMediator.SqlSetString(_stockAnalysisOrderListCndtnWork.Ed_GoodsNo);
            }

            return retstring;
        }
        #endregion

    }
}

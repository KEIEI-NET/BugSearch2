
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
using Broadleaf.Library.Collections;
using Broadleaf.Application.Common;
using System.Collections.Generic;
using Broadleaf.Application.Remoting;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 在庫入出荷一覧表DBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 在庫入出荷一覧表の実データ操作を行うクラスです。</br>
    /// <br>Programmer : 22008 長内 数馬</br>
    /// <br>Date       : 2007.09.14</br>
    /// <br></br>
	/// <br>Update Note: 2008.03.26 佐々木 健</br>
	/// <br>           : 商品コード、自社分類コードの絞り込みを修正</br>
    /// <br>Update Note: 2008.07.14 森本 大輝</br>
    /// <br>           : PM.NS対応</br>
    /// <br>Update Note: 2010/06/08 高峰</br>
    /// <br>           : 障害・改良対応（７月リリース案件）</br>
    /// <br></br>
    /// <br>Update Note: 2010/07/13 30517 夏野 駿希</br>
    /// <br>           : ①月次範囲をまたいで出力するとレコードが二つになる不具合修正</br>
    /// <br>           : ②月次範囲外で複数月を対象にすると最終月に全て集計されて出力される不具合修正</br>
    /// <br>           : ③月次範囲内で返品数を加算して出力している不具合修正</br>
    /// <br>Update Note: 2012/12/24 王君</br>
    /// <br>           : Redmine#33977の対応</br>
    /// <br>Update Note: 2015/11/24 譚洪</br>
    /// <br>           : 管理番号 : 11170204-00</br>
    /// <br>           : redmine#47489の対応</br>
    /// <br>           : 月次更新リモートの原価取得処理がないのメソッドをコールします。</br>
    /// <br>Update Note: 2016/01/06 陳ショウ</br>
    /// <br>           : 管理番号 : 11170204-00</br>
    /// <br>           : redmine#47489  #49の対応</br>
    /// <br>           : 末日の入出荷分が翌月にも出力されるの障害改修を対応します。</br>
    /// <br>Update Note: 2018/10/26 田建委</br>
    /// <br>           : 管理番号 : 11370033-00</br>
    /// <br>           : redmine#49771の対応</br>
    /// <br>           : 在庫入出荷一覧表の集計方法の変更</br>
    /// </remarks>
    [Serializable]
    public class StockShipArrivalListWorkDB : RemoteWithAppLockDB, IStockShipArrivalListWorkDB
    {

        private Int32 dateCnt = 0;

        /// <summary>
        /// 在庫入出荷一覧表DBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : DBサーバーコネクション情報を取得します。</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2007.09.14</br>
        /// </remarks>
        public StockShipArrivalListWorkDB()
            :
        base("DCZAI02133D", "Broadleaf.Application.Remoting.ParamData.StockShipArrivalListWork", "STOCKHISTORYRF") //基底クラスのコンストラクタ
        {
        }

        /// <summary>売掛/買掛金額マスタ更新リモートオブジェクト</summary>
        private MonthlyAddUpDB _monthlyAddUpDB = new MonthlyAddUpDB();
        private TtlDayCalcDB ttlDayCalcDB = new TtlDayCalcDB();
        private CompanyInfDB _companyInfDB = new CompanyInfDB();


        #region 在庫入出荷一覧表
        /// <summary>
        /// 指定された企業コードの在庫入出荷一覧表LISTを全て戻します（論理削除除く）
        /// </summary>
        /// <param name="stockMoveListResultWork">検索結果</param>
        /// <param name="stockMoveListCndtnWork">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された企業コードの在庫入出荷一覧表LISTを全て戻します（論理削除除く）</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2007.09.14</br>
        public int Search(out object stockShipArrivalListWork, object stockShipArrivalListCndtnWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            stockShipArrivalListWork = null;

            StockShipArrivalListCndtnWork _stockShipArrivalListCndtnWork = stockShipArrivalListCndtnWork as StockShipArrivalListCndtnWork;

            try
            {
                status = SearchProc(out stockShipArrivalListWork, _stockShipArrivalListCndtnWork, readMode, logicalMode);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "StockShipArrivalListWorkDB.Search Exception=" + ex.Message);
                stockShipArrivalListWork = new ArrayList();
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            return status;
        }

        /// <summary>
        /// 指定された企業コードの在庫入出荷一覧表LISTを全て戻します
        /// </summary>
        /// <param name="stockMoveListResultWork">検索結果</param>
        /// <param name="_stockMoveListCndtnWork">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された企業コードの在庫入出荷一覧表LISTを全て戻します</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2007.09.14</br>
        /// <br></br>
        /// <br>Update Note: 2007.09.11 長内 DC.NS用に修正</br>
        /// <br>Update Note: 23015 森本 大輝</br>
        /// <br>Date       : 2008.07.14</br>
        /// <br>Update Note: 2015/11/24 譚洪</br>
        /// <br>           : 管理番号 : 11170204-00</br>
        /// <br>           : redmine#47489の対応</br>
        /// <br>           : 月次更新リモートの原価取得処理がないのメソッドをコールします。</br>
        /// <br>Update Note: 2016/01/06 陳ショウ</br>
        /// <br>           : 管理番号 : 11170204-00</br>
        /// <br>           : redmine#47489 #49の対応</br>
        /// <br>           : 末日の入出荷分が翌月にも出力されるの障害改修を対応します。</br>
        private int SearchProc(out object stockShipArrivalListWork, StockShipArrivalListCndtnWork _stockShipArrivalListCndtnWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;

            stockShipArrivalListWork = null;

            // 結果クラス用
            StockShipArrivalListWork resultwork = new StockShipArrivalListWork();
            ArrayList resultList = new ArrayList();
            ArrayList lastKey = new ArrayList();
            ArrayList CountRetList = new ArrayList();

            int month = 0;
            bool Firstflg = false; // 在庫履歴は1回だけでいいので

            Dictionary<string, StockShipArrivalListWork> dic = new Dictionary<string, StockShipArrivalListWork>();            
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
                ArrayList lastList = new ArrayList();
                Dictionary<string, StockShipArrivalListWork> dictionary = new Dictionary<string, StockShipArrivalListWork>(); 

                #region 全社設定
                //if ((_stockShipArrivalListCndtnWork.SectionCodes.Length == 0) ||
                //    (_stockShipArrivalListCndtnWork.SectionCodes[0] == "")) 
                //{
                //    // 全社共通の場合
                //    CustomSerializeArrayList sectionList = new CustomSerializeArrayList();
                //    SectionInfo sectionInfo = new SectionInfo();
                //    SecInfoSetWork sectionInfoSetWork = new SecInfoSetWork();
                //    sectionInfoSetWork.EnterpriseCode = _stockShipArrivalListCndtnWork.EnterpriseCode;
                //    sectionInfoSetWork.LogicalDeleteCode = 0;

                //    sectionInfo.Search(out sectionList, sectionInfoSetWork, ref sqlConnection, readMode, logicalMode);
                //    ArrayList paraList = ListUtils.Find(sectionList, typeof(SecInfoSetWork), ListUtils.FindType.Array) as ArrayList;
                //    string[] str = new string[paraList.Count];
                //    int num = 0;
                //    foreach (SecInfoSetWork sec in paraList)
                //    {
                //        // ArrayListから文字列に代入
                //        str[num] = sec.SectionCode;
                //        num++;
                //    }
                //    if (str.Length != 0)
                //    {
                //        _stockShipArrivalListCndtnWork.SectionCodes = str;
                //    }
                //}
                #endregion

                if (_stockShipArrivalListCndtnWork.Ed_AddUpYearMonth.Month < _stockShipArrivalListCndtnWork.St_AddUpYearMonth.Month)
                {
                    month = 12 - _stockShipArrivalListCndtnWork.St_AddUpYearMonth.Month + _stockShipArrivalListCndtnWork.Ed_AddUpYearMonth.Month;
                }
                else
                {
                    month = _stockShipArrivalListCndtnWork.Ed_AddUpYearMonth.Month - _stockShipArrivalListCndtnWork.St_AddUpYearMonth.Month;
                }
                //foreach (string sectionCode in _stockShipArrivalListCndtnWork.SectionCodes)
                //{
                    DateTime AddUpYear = _stockShipArrivalListCndtnWork.St_AddUpYearMonth; 

                    for (int i = 0; i <= month; i++)
                    {
                        Dictionary<string, StockShipArrivalListWork> dicStock = new Dictionary<string,StockShipArrivalListWork>();

                        ArrayList keyHistList = new ArrayList();
                        ArrayList keystockList = new ArrayList();

                        List<StockHistoryWork> stockHistoryWorkList = new List<StockHistoryWork>();
                        List<TtlDayCalcRetWork> retList = new List<TtlDayCalcRetWork>();
                        TtlDayCalcParaWork para = new TtlDayCalcParaWork();

                        DateTime stMonth = new DateTime();
                        DateTime edMonth = new DateTime();

                        // 締日チェック処理
                        para.EnterpriseCode = _stockShipArrivalListCndtnWork.EnterpriseCode;
                        //para.SectionCode = sectionCode;
                        Int32 iAddUpDate = Int32.Parse(AddUpYear.ToString("yyyyMMdd")); //計上年月日

                        bool sale = false, buy = false;

                        // 売掛
                        status = ttlDayCalcDB.SearchHisMonthlyAccRec(out retList, para, ref sqlConnection);
                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL || retList[0].TotalDay < iAddUpDate)
                        {
                            sale = true;
                        }
                        retList.Clear();
                        // 買掛
                        status = ttlDayCalcDB.SearchHisMonthlyAccPay(out retList, para, ref sqlConnection);
                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL || retList[0].TotalDay < iAddUpDate)
                        {
                            buy = true;
                        }
                        if (sale == true || buy == true)
                        {

                            if (stockHistoryList.Count == 0)
                            {
                                // 締日範囲日付取得で使用
                                ArrayList list = new ArrayList();
                                CompanyInfWork companyinfWork = new CompanyInfWork();

                                //締め範囲日付取得
                                companyinfWork.EnterpriseCode = _stockShipArrivalListCndtnWork.EnterpriseCode;
                                status = _companyInfDB.Search(out list, companyinfWork, ref sqlConnection);

                                companyinfWork = list[0] as CompanyInfWork;
                                FinYearTableGenerator fin = new FinYearTableGenerator(companyinfWork);

                                fin.GetDaysFromMonth(AddUpYear, out stMonth, out edMonth);
                                if (dic.Count == 0)
                                {
                                    // 在庫マスタ Search
                                    status = SearchStockProc(ref dic, ref sqlConnection, _stockShipArrivalListCndtnWork, logicalMode);
                                    if ((status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND) || (status == (int)ConstantManagement.DB_Status.ctDB_EOF))
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

                            // 月次更新リモートSearchに使用
                            StockHistoryWork stockHistoryWork = new StockHistoryWork();
                            MonthlyAddUpWork monthlyAddUpWork = new MonthlyAddUpWork();

                            //売掛金・買掛金集計モジュールパラメータセット
                            monthlyAddUpWork.EnterpriseCode = _stockShipArrivalListCndtnWork.EnterpriseCode;
                            //monthlyAddUpWork.AddUpDateSt = stMonth.AddDays(-1);//DEL 陳ショウ 2016/01/06 Remine#47489
                            monthlyAddUpWork.AddUpDateSt = stMonth;　//ADD 陳ショウ 2016/01/06 Remine#47489
                            monthlyAddUpWork.AddUpDateEd = edMonth;
                            //monthlyAddUpWork.AddUpSecCode = sectionCode;
                            monthlyAddUpWork.AddUpDate = edMonth;
                            monthlyAddUpWork.LstMonAddUpProcDay = AddUpYear.AddMonths(-1);
                            monthlyAddUpWork.AddUpYearMonth = AddUpYear.AddMonths(-1);

                            string retMsg = null;
                            bool msgDiv = true;

                            // 月次更新リモート在庫集計メソッド呼び出し
                            // status = _monthlyAddUpDB.MakeStockHistoryParameters(ref monthlyAddUpWork, ref stockHistoryWorkList, out msgDiv, out retMsg, ref sqlConnection); // DEL 2015/11/24 譚洪 Redmine#47489
                            status = _monthlyAddUpDB.MakeStockHistoryNotGetCost(ref monthlyAddUpWork, ref stockHistoryWorkList, out msgDiv, out retMsg, ref sqlConnection); // ADD 2015/11/24 譚洪 Redmine#47489
                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                // クラス格納メソッド
                                // 2010/07/13 >>>
                                //status = StockStorage(ref dicStock, ref dic, ref stockHistoryWorkList, _stockShipArrivalListCndtnWork, month, ref keystockList, ref lastKey);
                                status = StockStorage(ref dicStock, ref dic, ref stockHistoryWorkList, _stockShipArrivalListCndtnWork, i, ref keystockList, ref lastKey);
                                // 2010/07/13 <<<
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
                            if (Firstflg == false)
                            {
                                Dictionary<string, StockShipArrivalListWork> al = new Dictionary<string, StockShipArrivalListWork>();
                                status = SearchStockShipArrivalProc(ref al, ref sqlConnection, _stockShipArrivalListCndtnWork, logicalMode, ref keyHistList, ref lastKey);
                                if (al.Count != 0)
                                {
                                    for (int a = 0; a < keyHistList.Count; a++)
                                    {
                                        double sum2_ship;
                                        double sum2_arrival;
                                        string k = keyHistList[a] as string;
                                        if (dictionary.ContainsKey(k) == true)
                                        {
                                            #region データ格納
                                            dictionary[k].ShipmentCnt1 += al[k].ShipmentCnt1;
                                            dictionary[k].ShipmentCnt2 += al[k].ShipmentCnt2;
                                            dictionary[k].ShipmentCnt3 += al[k].ShipmentCnt3;
                                            dictionary[k].ShipmentCnt4 += al[k].ShipmentCnt4;
                                            dictionary[k].ShipmentCnt5 += al[k].ShipmentCnt5;
                                            dictionary[k].ShipmentCnt6 += al[k].ShipmentCnt6;
                                            dictionary[k].ShipmentCnt7 += al[k].ShipmentCnt7;
                                            dictionary[k].ShipmentCnt8 += al[k].ShipmentCnt8;
                                            dictionary[k].ShipmentCnt9 += al[k].ShipmentCnt9;
                                            dictionary[k].ShipmentCnt10 += al[k].ShipmentCnt10;
                                            dictionary[k].ShipmentCnt11 += al[k].ShipmentCnt11;
                                            dictionary[k].ShipmentCnt12 += al[k].ShipmentCnt12;
                                            dictionary[k].ArrivalCnt1 += al[k].ArrivalCnt1;
                                            dictionary[k].ArrivalCnt2 += al[k].ArrivalCnt2;
                                            dictionary[k].ArrivalCnt3 += al[k].ArrivalCnt3;
                                            dictionary[k].ArrivalCnt4 += al[k].ArrivalCnt4;
                                            dictionary[k].ArrivalCnt5 += al[k].ArrivalCnt5;
                                            dictionary[k].ArrivalCnt6 += al[k].ArrivalCnt6;
                                            dictionary[k].ArrivalCnt7 += al[k].ArrivalCnt7;
                                            dictionary[k].ArrivalCnt8 += al[k].ArrivalCnt8;
                                            dictionary[k].ArrivalCnt9 += al[k].ArrivalCnt9;
                                            dictionary[k].ArrivalCnt10 += al[k].ArrivalCnt10;
                                            dictionary[k].ArrivalCnt11 += al[k].ArrivalCnt11;
                                            dictionary[k].ArrivalCnt12 += al[k].ArrivalCnt12;

                                            sum2_ship = dictionary[k].ShipmentCnt1 + dictionary[k].ShipmentCnt2
                                                + dictionary[k].ShipmentCnt3 + dictionary[k].ShipmentCnt4
                                                + dictionary[k].ShipmentCnt5 + dictionary[k].ShipmentCnt6
                                                + dictionary[k].ShipmentCnt7 + dictionary[k].ShipmentCnt8
                                                + dictionary[k].ShipmentCnt9 + dictionary[k].ShipmentCnt10
                                                + dictionary[k].ShipmentCnt11 + dictionary[k].ShipmentCnt12;
                                            sum2_arrival = dictionary[k].ArrivalCnt1 + dictionary[k].ArrivalCnt2
                                                + dictionary[k].ArrivalCnt3 + dictionary[k].ArrivalCnt4
                                                + dictionary[k].ArrivalCnt5 + dictionary[k].ArrivalCnt6
                                                + dictionary[k].ArrivalCnt7 + dictionary[k].ArrivalCnt8
                                                + dictionary[k].ArrivalCnt9 + dictionary[k].ArrivalCnt10
                                                + dictionary[k].ArrivalCnt11 + dictionary[k].ArrivalCnt12;

                                            dictionary[k].SUM_ShipmentCnt = sum2_ship;
                                            dictionary[k].SUM_ArrivalCnt = sum2_arrival;
                                            dictionary[k].AVG_ShipmentCnt = sum2_ship / (month + 1);
                                            dictionary[k].AVG_ArrivalCnt = sum2_arrival / (month + 1);
                                        }
                                        else
                                        {
                                            dictionary[k] = al[k];
                                        }
                                            #endregion
                                    }
                                }
                                Firstflg = true;
                            }
                        }
                        if (dicStock.Count != 0)
                        {
                            for (int j = 0; j < keystockList.Count; j++)
                            {
                                double sum3_ship = 0;
                                double sum3_arrival = 0;
                                string k2 = keystockList[j] as string;
                                if (dictionary.ContainsKey(k2) == true)
                                {
                                    #region　データ格納
                                    dictionary[k2].ShipmentCnt1 += dicStock[k2].ShipmentCnt1;
                                    dictionary[k2].ShipmentCnt2 += dicStock[k2].ShipmentCnt2;
                                    dictionary[k2].ShipmentCnt3 += dicStock[k2].ShipmentCnt3;
                                    dictionary[k2].ShipmentCnt4 += dicStock[k2].ShipmentCnt4;
                                    dictionary[k2].ShipmentCnt5 += dicStock[k2].ShipmentCnt5;
                                    dictionary[k2].ShipmentCnt6 += dicStock[k2].ShipmentCnt6;
                                    dictionary[k2].ShipmentCnt7 += dicStock[k2].ShipmentCnt7;
                                    dictionary[k2].ShipmentCnt8 += dicStock[k2].ShipmentCnt8;
                                    dictionary[k2].ShipmentCnt9 += dicStock[k2].ShipmentCnt9;
                                    dictionary[k2].ShipmentCnt10 += dicStock[k2].ShipmentCnt10;
                                    dictionary[k2].ShipmentCnt11 += dicStock[k2].ShipmentCnt11;
                                    dictionary[k2].ShipmentCnt12 += dicStock[k2].ShipmentCnt12;
                                    dictionary[k2].ArrivalCnt1 += dicStock[k2].ArrivalCnt1;
                                    dictionary[k2].ArrivalCnt2 += dicStock[k2].ArrivalCnt2;
                                    dictionary[k2].ArrivalCnt3 += dicStock[k2].ArrivalCnt3;
                                    dictionary[k2].ArrivalCnt4 += dicStock[k2].ArrivalCnt4;
                                    dictionary[k2].ArrivalCnt5 += dicStock[k2].ArrivalCnt5;
                                    dictionary[k2].ArrivalCnt6 += dicStock[k2].ArrivalCnt6;
                                    dictionary[k2].ArrivalCnt7 += dicStock[k2].ArrivalCnt7;
                                    dictionary[k2].ArrivalCnt8 += dicStock[k2].ArrivalCnt8;
                                    dictionary[k2].ArrivalCnt9 += dicStock[k2].ArrivalCnt9;
                                    dictionary[k2].ArrivalCnt10 += dicStock[k2].ArrivalCnt10;
                                    dictionary[k2].ArrivalCnt11 += dicStock[k2].ArrivalCnt11;
                                    dictionary[k2].ArrivalCnt12 += dicStock[k2].ArrivalCnt12;

                                    sum3_ship = dictionary[k2].ShipmentCnt1 + dictionary[k2].ShipmentCnt2
                                        + dictionary[k2].ShipmentCnt3 + dictionary[k2].ShipmentCnt4
                                        + dictionary[k2].ShipmentCnt5 + dictionary[k2].ShipmentCnt6
                                        + dictionary[k2].ShipmentCnt7 + dictionary[k2].ShipmentCnt8
                                        + dictionary[k2].ShipmentCnt9 + dictionary[k2].ShipmentCnt10
                                        + dictionary[k2].ShipmentCnt11 + dictionary[k2].ShipmentCnt12;
                                    sum3_arrival = dictionary[k2].ArrivalCnt1 + dictionary[k2].ArrivalCnt2
                                        + dictionary[k2].ArrivalCnt3 + dictionary[k2].ArrivalCnt4
                                        + dictionary[k2].ArrivalCnt5 + dictionary[k2].ArrivalCnt6
                                        + dictionary[k2].ArrivalCnt7 + dictionary[k2].ArrivalCnt8
                                        + dictionary[k2].ArrivalCnt9 + dictionary[k2].ArrivalCnt10
                                        + dictionary[k2].ArrivalCnt11 + dictionary[k2].ArrivalCnt12;

                                    dictionary[k2].SUM_ShipmentCnt = sum3_ship;
                                    dictionary[k2].SUM_ArrivalCnt = sum3_arrival;
                                    dictionary[k2].AVG_ShipmentCnt = sum3_ship / (month + 1);
                                    dictionary[k2].AVG_ArrivalCnt = sum3_arrival / (month + 1);
                                }
                                else
                                {
                                    dictionary[k2] = dicStock[k2];
                                }
                                    #endregion
                            }
                        }

                        AddUpYear = AddUpYear.AddMonths(1);
                    }
                //}
                for (int j = 0; j < lastKey.Count; j++)
                {
                    string key3 = lastKey[j] as string;
                    dictionary.TryGetValue(key3, out resultwork);
                    resultList.Add(resultwork);

                }
                // 最後に個数指定チェック
                foreach (StockShipArrivalListWork CntWork in resultList)
                {
                    // 出荷&入荷
                    if (_stockShipArrivalListCndtnWork.ShipArrivalCntDiv == 0)
                    {
                        // 合計入荷or合計出荷が開始終了範囲内だったら
                        if (((double)_stockShipArrivalListCndtnWork.St_ShipArrivalCnt <= CntWork.SUM_ArrivalCnt && CntWork.SUM_ArrivalCnt <= (double)_stockShipArrivalListCndtnWork.Ed_ShipArrivalCnt) 
                            || ((double)_stockShipArrivalListCndtnWork.St_ShipArrivalCnt <= CntWork.SUM_ShipmentCnt && CntWork.SUM_ShipmentCnt <= (double)_stockShipArrivalListCndtnWork.Ed_ShipArrivalCnt))
                        {
                            //// 合計出荷が開始終了範囲内だったら
                            //if ((double)_stockShipArrivalListCndtnWork.St_ShipArrivalCnt <= CntWork.SUM_ShipmentCnt && CntWork.SUM_ShipmentCnt <= (double)_stockShipArrivalListCndtnWork.Ed_ShipArrivalCnt)
                            //{
                                // 格納
                                CountRetList.Add(CntWork);
                            //}
                        }
                    }
                    // 出荷
                    else if (_stockShipArrivalListCndtnWork.ShipArrivalCntDiv == 1)
                    {
                        // 合計出荷が開始終了範囲内だったら
                        if ((double)_stockShipArrivalListCndtnWork.St_ShipArrivalCnt <= CntWork.SUM_ShipmentCnt && CntWork.SUM_ShipmentCnt <= (double)_stockShipArrivalListCndtnWork.Ed_ShipArrivalCnt)
                        {
                            // 格納
                            CountRetList.Add(CntWork);
                        }
                    }
                    // 入荷
                    else
                    {
                        // 合計入荷が開始終了範囲内だったら
                        if ((double)_stockShipArrivalListCndtnWork.St_ShipArrivalCnt <= CntWork.SUM_ArrivalCnt && CntWork.SUM_ArrivalCnt <= (double)_stockShipArrivalListCndtnWork.Ed_ShipArrivalCnt)
                        {
                            // 格納
                            CountRetList.Add(CntWork);
                        }
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
                base.WriteErrorLog(ex, "StockShipArrivalListWorkDB.SearchProc Exception=" + ex.Message);
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
            if (resultList.Count > 0)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            stockShipArrivalListWork = CountRetList;
            return status;
        }

        #region [クラス格納処理]
        /// <summary>
        /// 検索結果クラス格納処理
        /// </summary>
        /// <param name="al">結果格納ArrayList</param>
        /// <param name="stockHistoryWorkList">月次更新リスト</param>
        /// <remarks>
        /// <br>UpdateNote   : 2010/06/08 高峰 障害・改良対応（７月リリース案件）</br>
        /// </remarks>
        private int StockStorage(ref Dictionary<string, StockShipArrivalListWork> dicStock, ref Dictionary<string, StockShipArrivalListWork> dic, ref List<StockHistoryWork> stockHistoryWorkList, StockShipArrivalListCndtnWork _stockShipArrivalListCndtnWork, int i, ref ArrayList keystockList,ref ArrayList lastKey)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            string key = string.Empty;
            string key2 = string.Empty;
            double sum_ship;
            double sum_arrival;

            //在庫履歴格納項目
            foreach (StockHistoryWork st in stockHistoryWorkList)
            {
                StockShipArrivalListWork stockShipResultWork = new StockShipArrivalListWork();

                // 拠点コード
                //if (_stockShipArrivalListCndtnWork.SectionCodes != null)
                //{
                //    string Sec = "";
                //    foreach (string Secstr in _stockShipArrivalListCndtnWork.SectionCodes)
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
                //            //stockShipResultWork.SectionCode = st.SectionCode.Trim();
                //            stockShipResultWork.SectionCode = "";
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
                if (_stockShipArrivalListCndtnWork.St_WarehouseCode != "")
                {
                    // --- UPD 2010/06/08 ---------->>>>>
                    //if (_stockShipArrivalListCndtnWork.St_WarehouseCode.CompareTo(st.WarehouseCode) == 0 ||
                    //    _stockShipArrivalListCndtnWork.St_WarehouseCode.CompareTo(st.WarehouseCode) < 0)
                    if (_stockShipArrivalListCndtnWork.St_WarehouseCode.CompareTo(st.WarehouseCode.Trim()) == 0 ||
                        _stockShipArrivalListCndtnWork.St_WarehouseCode.CompareTo(st.WarehouseCode.Trim()) < 0)
                    // --- UPD 2010/06/08 ----------<<<<<
                    {
                        stockShipResultWork.WarehouseCode = st.WarehouseCode;
                        stockShipResultWork.WarehouseName = st.WarehouseName;
                    }
                    else
                    {
                        continue;
                    }
                }
                if (_stockShipArrivalListCndtnWork.Ed_WarehouseCode != "")
                {
                    // --- UPD 2010/06/08 ---------->>>>>
                    //if (_stockShipArrivalListCndtnWork.Ed_WarehouseCode.CompareTo(st.WarehouseCode) == 0 ||
                    //    _stockShipArrivalListCndtnWork.Ed_WarehouseCode.CompareTo(st.WarehouseCode) > 0)
                    if (_stockShipArrivalListCndtnWork.Ed_WarehouseCode.CompareTo(st.WarehouseCode.Trim()) == 0 ||
                        _stockShipArrivalListCndtnWork.Ed_WarehouseCode.CompareTo(st.WarehouseCode.Trim()) > 0)
                    // --- UPD 2010/06/08 ----------<<<<<
                    {
                        stockShipResultWork.WarehouseCode = st.WarehouseCode;
                        stockShipResultWork.WarehouseName = st.WarehouseName;
                    }
                    else
                    {
                        continue;
                    }
                }
                if (_stockShipArrivalListCndtnWork.St_WarehouseCode == "" && _stockShipArrivalListCndtnWork.Ed_WarehouseCode == "")
                {
                    stockShipResultWork.WarehouseCode = st.WarehouseCode;
                    stockShipResultWork.WarehouseName = st.WarehouseName;
                }

                // メーカーコード
                if (_stockShipArrivalListCndtnWork.St_GoodsMakerCd != 0)
                {
                    if (_stockShipArrivalListCndtnWork.St_GoodsMakerCd == st.GoodsMakerCd ||
                        _stockShipArrivalListCndtnWork.St_GoodsMakerCd < st.GoodsMakerCd)
                    {
                        stockShipResultWork.GoodsMakerCd = st.GoodsMakerCd;
                    }
                    else
                    {
                        continue;
                    }
                }
                if (_stockShipArrivalListCndtnWork.Ed_GoodsMakerCd != 0)
                {
                    if (_stockShipArrivalListCndtnWork.Ed_GoodsMakerCd == st.GoodsMakerCd ||
                        _stockShipArrivalListCndtnWork.Ed_GoodsMakerCd > st.GoodsMakerCd)
                    {
                        stockShipResultWork.GoodsMakerCd = st.GoodsMakerCd;
                    }
                    else
                    {
                        continue;
                    }
                }
                if (_stockShipArrivalListCndtnWork.St_GoodsMakerCd == 0 && _stockShipArrivalListCndtnWork.Ed_GoodsMakerCd == 0)
                {
                    stockShipResultWork.GoodsMakerCd = st.GoodsMakerCd;
                }

                // メーカー名称
                stockShipResultWork.MakerName = st.MakerName;

                // 品番
                if (_stockShipArrivalListCndtnWork.St_GoodsNo != "")
                {
                    if (_stockShipArrivalListCndtnWork.St_GoodsNo.CompareTo(st.GoodsNo) == 0 ||
                        _stockShipArrivalListCndtnWork.St_GoodsNo.CompareTo(st.GoodsNo) < 0)
                    {
                        stockShipResultWork.GoodsNo = st.GoodsNo;
                    }
                    else
                    {
                        continue;
                    }
                }
                if (_stockShipArrivalListCndtnWork.Ed_GoodsNo != "")
                {
                    if (_stockShipArrivalListCndtnWork.Ed_GoodsNo.CompareTo(st.GoodsNo) == 0 ||
                        _stockShipArrivalListCndtnWork.Ed_GoodsNo.CompareTo(st.GoodsNo) > 0)
                    {
                        stockShipResultWork.GoodsNo = st.GoodsNo;
                    }
                    else
                    {
                        continue;
                    }
                }
                if (_stockShipArrivalListCndtnWork.St_GoodsNo == "" && _stockShipArrivalListCndtnWork.Ed_GoodsNo == "")
                {
                    stockShipResultWork.GoodsNo = st.GoodsNo;
                }

                // 品名
                stockShipResultWork.GoodsName = st.GoodsName;

                key2 = /*st.SectionCode +*/ st.WarehouseCode + st.GoodsMakerCd.ToString("0000") + st.GoodsNo; 

                if (st.GoodsNo == "kawashima0005")
                {
                    string a;
                    a = "";
                }

                if (dicStock.ContainsKey(key2) == true)
                {
                    dicStock.TryGetValue(key2, out stockShipResultWork);
                    dicStock.Remove(key2);
                }
                //if (i == 0)
                //{
                //    stockShipResultWork.ShipmentCnt1 = st.ShipmentCnt;
                //    stockShipResultWork.ArrivalCnt1 = st.ArrivalCnt;
                //}

                // 2010/07/14 >>>
                //if (st.SalesCount == 0 && st.StockCount == 0)
                if (st.SalesCount + st.SalesRetGoodsCnt == 0 && st.StockCount + st.StockRetGoodsCnt == 0)
                // 2010/07/14 <<<
                {
                    continue;
                }

                if (i == 0)
                {
                    stockShipResultWork.ShipmentCnt1 = (st.SalesCount + st.SalesRetGoodsCnt);
                    stockShipResultWork.ArrivalCnt1 = (st.StockCount + st.StockRetGoodsCnt);
                }
                
                #region 合計・平均
                switch (i)
                {
                    case 1:
                        stockShipResultWork.ShipmentCnt2 = (st.SalesCount + st.SalesRetGoodsCnt);
                        stockShipResultWork.ArrivalCnt2 = (st.StockCount + st.StockRetGoodsCnt);
                        break;
                    case 2:
                        stockShipResultWork.ShipmentCnt3 = (st.SalesCount + st.SalesRetGoodsCnt);
                        stockShipResultWork.ArrivalCnt3 = (st.StockCount + st.StockRetGoodsCnt);;
                        break;
                    case 3:
                        stockShipResultWork.ShipmentCnt4 = (st.SalesCount + st.SalesRetGoodsCnt);
                        stockShipResultWork.ArrivalCnt4 = (st.StockCount + st.StockRetGoodsCnt);;
                        break;
                    case 4:
                        stockShipResultWork.ShipmentCnt5 = (st.SalesCount + st.SalesRetGoodsCnt);
                        stockShipResultWork.ArrivalCnt5 = (st.StockCount + st.StockRetGoodsCnt);;
                        break;
                    case 5:
                        stockShipResultWork.ShipmentCnt6 = (st.SalesCount + st.SalesRetGoodsCnt);
                        stockShipResultWork.ArrivalCnt6 = (st.StockCount + st.StockRetGoodsCnt);;
                        break;
                    case 6:
                        stockShipResultWork.ShipmentCnt7 = (st.SalesCount + st.SalesRetGoodsCnt);
                        stockShipResultWork.ArrivalCnt7 = (st.StockCount + st.StockRetGoodsCnt);;
                        break;
                    case 7:
                        stockShipResultWork.ShipmentCnt8 = (st.SalesCount + st.SalesRetGoodsCnt);
                        stockShipResultWork.ArrivalCnt8 = (st.StockCount + st.StockRetGoodsCnt);;
                        break;
                    case 8:
                        stockShipResultWork.ShipmentCnt9 = (st.SalesCount + st.SalesRetGoodsCnt);
                        stockShipResultWork.ArrivalCnt9 = (st.StockCount + st.StockRetGoodsCnt);;
                        break;
                    case 9:
                        stockShipResultWork.ShipmentCnt10 = (st.SalesCount + st.SalesRetGoodsCnt);
                        stockShipResultWork.ArrivalCnt10 = (st.StockCount + st.StockRetGoodsCnt);;
                        break;
                    case 10:
                        stockShipResultWork.ShipmentCnt11 = (st.SalesCount + st.SalesRetGoodsCnt);
                        stockShipResultWork.ArrivalCnt11 = (st.StockCount + st.StockRetGoodsCnt);;
                        break;
                    case 11:
                        stockShipResultWork.ShipmentCnt12 = (st.SalesCount + st.SalesRetGoodsCnt);
                        stockShipResultWork.ArrivalCnt12 = (st.StockCount + st.StockRetGoodsCnt); ;
                        break;
                }

                sum_ship = stockShipResultWork.ShipmentCnt1 + stockShipResultWork.ShipmentCnt2
                            + stockShipResultWork.ShipmentCnt3 + stockShipResultWork.ShipmentCnt4
                            + stockShipResultWork.ShipmentCnt5 + stockShipResultWork.ShipmentCnt6
                            + stockShipResultWork.ShipmentCnt7 + stockShipResultWork.ShipmentCnt8
                            + stockShipResultWork.ShipmentCnt9 + stockShipResultWork.ShipmentCnt10
                            + stockShipResultWork.ShipmentCnt11 + stockShipResultWork.ShipmentCnt12;
                sum_arrival = stockShipResultWork.ArrivalCnt1 + stockShipResultWork.ArrivalCnt2
                            + stockShipResultWork.ArrivalCnt3 + stockShipResultWork.ArrivalCnt4
                            + stockShipResultWork.ArrivalCnt5 + stockShipResultWork.ArrivalCnt6
                            + stockShipResultWork.ArrivalCnt7 + stockShipResultWork.ArrivalCnt8
                            + stockShipResultWork.ArrivalCnt9 + stockShipResultWork.ArrivalCnt10
                            + stockShipResultWork.ArrivalCnt11 + stockShipResultWork.ArrivalCnt12;
                #endregion
                stockShipResultWork.SUM_ShipmentCnt = sum_ship;
                stockShipResultWork.SUM_ArrivalCnt = sum_arrival;
                stockShipResultWork.AVG_ShipmentCnt = sum_ship / (i + 1);
                stockShipResultWork.AVG_ArrivalCnt = sum_arrival / (i + 1);

                key = st.WarehouseCode + st.GoodsNo + st.GoodsMakerCd.ToString("0000");
                if (dic.ContainsKey(key) == true)
                {
                    StockShipArrivalListWork stockWork = dic[key] as StockShipArrivalListWork;

                    //棚番
                    stockShipResultWork.WarehouseShelfNo = stockWork.WarehouseShelfNo;
                    
                    //仕入先コード
                    //if (_stockShipArrivalListCndtnWork.St_SupplierCd != 0)
                    //{
                    //    if (_stockShipArrivalListCndtnWork.St_SupplierCd == stockWork.StockSupplierCode ||
                    //        _stockShipArrivalListCndtnWork.St_SupplierCd < stockWork.StockSupplierCode)
                    //    {
                    //        stockShipResultWork.StockSupplierCode = 0;
                    //    }
                    //    else
                    //    {
                    //        continue;
                    //    }
                    //}
                    //if (_stockShipArrivalListCndtnWork.Ed_SupplierCd != 0)
                    //{
                    //    if (_stockShipArrivalListCndtnWork.Ed_SupplierCd == stockWork.StockSupplierCode ||
                    //        _stockShipArrivalListCndtnWork.Ed_SupplierCd > stockWork.StockSupplierCode)
                    //    {
                    //        stockShipResultWork.StockSupplierCode = 0;
                    //    }
                    //    else
                    //    {
                    //        continue;
                    //    }
                    //}

                    if (_stockShipArrivalListCndtnWork.St_SupplierCd == 0 && _stockShipArrivalListCndtnWork.Ed_SupplierCd == 0)
                    {
                        stockShipResultWork.StockSupplierCode = 0;
                    }

                    // BLコード
                    if (_stockShipArrivalListCndtnWork.St_BLGoodsCode != 0)
                    {
                        if (_stockShipArrivalListCndtnWork.St_BLGoodsCode == stockWork.BLGoodsCode ||
                            _stockShipArrivalListCndtnWork.St_BLGoodsCode < stockWork.BLGoodsCode)
                        {
                            stockShipResultWork.BLGoodsCode = stockWork.BLGoodsCode;
                        }
                        else
                        {
                            continue;
                        }
                    }
                    if (_stockShipArrivalListCndtnWork.Ed_BLGoodsCode != 0)
                    {
                        if (_stockShipArrivalListCndtnWork.Ed_BLGoodsCode == stockWork.BLGoodsCode ||
                            _stockShipArrivalListCndtnWork.Ed_BLGoodsCode > stockWork.BLGoodsCode)
                        {
                            stockShipResultWork.BLGoodsCode = stockWork.BLGoodsCode;
                        }
                        else
                        {
                            continue;
                        }
                    }
                    if (_stockShipArrivalListCndtnWork.St_BLGoodsCode == 0 && _stockShipArrivalListCndtnWork.Ed_BLGoodsCode == 0)
                    {
                        stockShipResultWork.BLGoodsCode = stockWork.BLGoodsCode;
                    }

                    // 拠点名称
                    stockShipResultWork.SectionGuideNm = stockWork.SectionGuideNm;


                    // 在庫登録日
                    if (_stockShipArrivalListCndtnWork.StockCreateDate != DateTime.MinValue)
                    {
                        if (_stockShipArrivalListCndtnWork.StockCreateDateDiv == 0 && (_stockShipArrivalListCndtnWork.StockCreateDate == stockWork.StockCreateDate ||
                            _stockShipArrivalListCndtnWork.StockCreateDate > stockWork.StockCreateDate))
                        {
                            stockShipResultWork.StockCreateDate = stockWork.StockCreateDate;
                        }
                        else if (_stockShipArrivalListCndtnWork.StockCreateDateDiv == 1 && (_stockShipArrivalListCndtnWork.StockCreateDate == stockWork.StockCreateDate ||
                            _stockShipArrivalListCndtnWork.StockCreateDate < stockWork.StockCreateDate))
                        {
                            stockShipResultWork.StockCreateDate = stockWork.StockCreateDate;
                        }
                        else
                        {
                            continue;
                        }
                    }
                    else
                    {
                        stockShipResultWork.StockCreateDate = stockWork.StockCreateDate;
                    }

                    // 商品区分
                    if (_stockShipArrivalListCndtnWork.St_EnterpriseGanreCode != 0)
                    {
                        if (_stockShipArrivalListCndtnWork.St_EnterpriseGanreCode == stockWork.EnterpriseGanreCode ||
                            _stockShipArrivalListCndtnWork.St_EnterpriseGanreCode < stockWork.EnterpriseGanreCode)
                        {
                            stockShipResultWork.EnterpriseGanreCode = stockWork.EnterpriseGanreCode;
                        }
                        else
                        {
                            continue;
                        }
                    }
                    if (_stockShipArrivalListCndtnWork.Ed_EnterpriseGanreCode != 0)
                    {
                        if (_stockShipArrivalListCndtnWork.Ed_EnterpriseGanreCode == stockWork.EnterpriseGanreCode ||
                            _stockShipArrivalListCndtnWork.Ed_EnterpriseGanreCode > stockWork.EnterpriseGanreCode)
                        {
                            stockShipResultWork.EnterpriseGanreCode = stockWork.EnterpriseGanreCode;
                        }
                        else
                        {
                            continue;
                        }
                    }
                    if (_stockShipArrivalListCndtnWork.St_EnterpriseGanreCode == 0 && _stockShipArrivalListCndtnWork.Ed_EnterpriseGanreCode == 0)
                    {
                        stockShipResultWork.EnterpriseGanreCode = stockWork.EnterpriseGanreCode;
                    }

                    // 商品大分類
                    if (_stockShipArrivalListCndtnWork.St_GoodsLGroup != 0)
                    {
                        if (_stockShipArrivalListCndtnWork.St_GoodsLGroup == stockWork.GoodsLGroup ||
                            _stockShipArrivalListCndtnWork.St_GoodsLGroup < stockWork.GoodsLGroup)
                        {
                            stockShipResultWork.GoodsLGroup = stockWork.GoodsLGroup;
                        }
                        else
                        {
                            continue;
                        }

                    }
                    if (_stockShipArrivalListCndtnWork.Ed_GoodsLGroup != 0)
                    {
                        if (_stockShipArrivalListCndtnWork.Ed_GoodsLGroup == stockWork.GoodsLGroup ||
                            _stockShipArrivalListCndtnWork.Ed_GoodsLGroup > stockWork.GoodsLGroup)
                        {
                            stockShipResultWork.GoodsLGroup = stockWork.GoodsLGroup;
                        }
                        else
                        {
                            continue;
                        }
                    }
                    if (_stockShipArrivalListCndtnWork.St_GoodsLGroup == 0 && _stockShipArrivalListCndtnWork.Ed_GoodsLGroup == 0)
                    {
                        stockShipResultWork.GoodsLGroup = stockWork.GoodsLGroup;
                    }

                    // 商品中分類
                    if (_stockShipArrivalListCndtnWork.St_GoodsMGroup != 0)
                    {
                        if (_stockShipArrivalListCndtnWork.St_GoodsMGroup == stockWork.GoodsMGroup ||
                            _stockShipArrivalListCndtnWork.St_GoodsMGroup < stockWork.GoodsMGroup)
                        {
                            stockShipResultWork.GoodsMGroup = stockWork.GoodsMGroup;
                        }
                        else
                        {
                            continue;
                        }
                    }
                    if (_stockShipArrivalListCndtnWork.Ed_GoodsMGroup != 0)
                    {
                        if (_stockShipArrivalListCndtnWork.Ed_GoodsMGroup == stockWork.GoodsMGroup ||
                            _stockShipArrivalListCndtnWork.Ed_GoodsMGroup > stockWork.GoodsMGroup)
                        {
                            stockShipResultWork.GoodsMGroup = stockWork.GoodsMGroup;
                        }
                        else
                        {
                            continue;
                        }
                    }
                    if (_stockShipArrivalListCndtnWork.St_GoodsMGroup == 0 && _stockShipArrivalListCndtnWork.Ed_GoodsMGroup == 0)
                    {
                        stockShipResultWork.GoodsMGroup = stockWork.GoodsMGroup;
                    }

                    // グループコード
                    if (_stockShipArrivalListCndtnWork.St_BLGroupCode != 0)
                    {
                        if (_stockShipArrivalListCndtnWork.St_BLGroupCode == stockWork.BLGroupCode ||
                            _stockShipArrivalListCndtnWork.St_BLGroupCode < stockWork.BLGroupCode)
                        {
                            stockShipResultWork.BLGroupCode = stockWork.BLGroupCode;
                        }
                        else
                        {
                            continue;
                        }
                    }
                    if (_stockShipArrivalListCndtnWork.Ed_BLGroupCode != 0)
                    {
                        if (_stockShipArrivalListCndtnWork.Ed_BLGroupCode == stockWork.BLGroupCode ||
                            _stockShipArrivalListCndtnWork.Ed_BLGroupCode > stockWork.BLGroupCode)
                        {
                            stockShipResultWork.BLGroupCode = stockWork.BLGroupCode;
                        }
                        else
                        {
                            continue;
                        }
                    }
                    if (_stockShipArrivalListCndtnWork.St_BLGroupCode == 0 && _stockShipArrivalListCndtnWork.Ed_BLGroupCode == 0)
                    {
                        stockShipResultWork.BLGroupCode = stockWork.BLGroupCode;
                    }

                    // 2010/07/13 Del >>>
                    //keystockList.Add(key2);
                    //if (lastKey.Contains(key2) == false)
                    //{
                    //    lastKey.Add(key2);
                    //}
                    //dicStock.Add(key2, stockShipResultWork);
                    // 2010/07/13 Del <<<
                    // 2010/07/13 Add >>>
                    keystockList.Add(key);
                    if (lastKey.Contains(key) == false)
                    {
                        lastKey.Add(key);
                    }
                    dicStock.Add(key, stockShipResultWork);
                    // 2010/07/13 Add <<<
                }

            }
            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
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
        /// <remarks>
        /// <br>Update Note: 2018/10/26 田建委</br>
        /// <br>　　　　　 : Redmine#49771の障害対応</br>
        /// </remarks>
        private int SearchStockShipArrivalProc(ref Dictionary<string, StockShipArrivalListWork> al, ref SqlConnection sqlConnection, StockShipArrivalListCndtnWork _stockShipArrivalListCndtnWork, ConstantManagement.LogicalMode logicalMode, ref ArrayList keyHistList, ref ArrayList lastKey)
        {
            
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            string keyHist = string.Empty;

            try
            {
                string selectTxt = "";
                sqlCommand = new SqlCommand(selectTxt, sqlConnection);

                // 対象テーブル
                // STOCKHISTORYRF STHIS  在庫履歴データ
                // STOCKRF        STOCK  在庫マスタ
                // SECINFOSETRF   SECI   拠点情報設定マスタ
                // GOODSURF       GDSU   商品マスタ

                #region Select文作成
                //結果取得
                //selectTxt += "SELECT STHIS.SECTIONCODERF" + Environment.NewLine;
                selectTxt += "SELECT " + Environment.NewLine;
                //selectTxt += " ,SECI.SECTIONGUIDENMRF" + Environment.NewLine;
                selectTxt += "  STHIS.WAREHOUSECODERF" + Environment.NewLine;
                // --- UPD 田建委 2018/10/26 Redmine＃49771の対応---------->>>>>
                //selectTxt += " ,STHIS.WAREHOUSENAMERF" + Environment.NewLine;
                selectTxt += " ,WH.WAREHOUSENAMERF" + Environment.NewLine;
                // --- UPD 田建委 2018/10/26 Redmine＃49771の対応----------<<<<<
                selectTxt += " ,STHIS.GOODSMAKERCDRF" + Environment.NewLine;
                // --- UPD 田建委 2018/10/26 Redmine＃49771の対応---------->>>>>
                //selectTxt += " ,STHIS.MAKERNAMERF" + Environment.NewLine;
                selectTxt += " ,MAK.MAKERNAMERF" + Environment.NewLine;
                // --- UPD 田建委 2018/10/26 Redmine＃49771の対応----------<<<<<
                selectTxt += " ,STHIS.GOODSNORF" + Environment.NewLine;
                // --- UPD 田建委 2018/10/26 Redmine＃49771の対応---------->>>>>
                //selectTxt += " ,STHIS.GOODSNAMERF" + Environment.NewLine;
                selectTxt += " ,GDSU.GOODSNAMERF" + Environment.NewLine;
                // --- UPD 田建委 2018/10/26 Redmine＃49771の対応----------<<<<<
                selectTxt += " ,STOCK.WAREHOUSESHELFNORF" + Environment.NewLine;
                selectTxt += " ,STOCK.STOCKCREATEDATERF" + Environment.NewLine;
                selectTxt += " ,GDSU.BLGOODSCODERF" + Environment.NewLine;
                //selectTxt += " ,STOCK.STOCKSUPPLIERCODERF" + Environment.NewLine;
                selectTxt += " ,SUM(M_SHIPMENTCNT1) AS SHIPMENTCNT1" + Environment.NewLine;
                selectTxt += " ,SUM(M_ARRIVALCNT1) AS ARRIVALCNT1" + Environment.NewLine;
                selectTxt += " ,SUM(M_SHIPMENTCNT2) AS SHIPMENTCNT2" + Environment.NewLine;
                selectTxt += " ,SUM(M_ARRIVALCNT2) AS ARRIVALCNT2" + Environment.NewLine;
                selectTxt += " ,SUM(M_SHIPMENTCNT3) AS SHIPMENTCNT3" + Environment.NewLine;
                selectTxt += " ,SUM(M_ARRIVALCNT3) AS ARRIVALCNT3" + Environment.NewLine;
                selectTxt += " ,SUM(M_SHIPMENTCNT4) AS SHIPMENTCNT4" + Environment.NewLine;
                selectTxt += " ,SUM(M_ARRIVALCNT4) AS ARRIVALCNT4" + Environment.NewLine;
                selectTxt += " ,SUM(M_SHIPMENTCNT5) AS SHIPMENTCNT5" + Environment.NewLine;
                selectTxt += " ,SUM(M_ARRIVALCNT5) AS ARRIVALCNT5" + Environment.NewLine;
                selectTxt += " ,SUM(M_SHIPMENTCNT6) AS SHIPMENTCNT6" + Environment.NewLine;
                selectTxt += " ,SUM(M_ARRIVALCNT6) AS ARRIVALCNT6" + Environment.NewLine;
                selectTxt += " ,SUM(M_SHIPMENTCNT7) AS SHIPMENTCNT7" + Environment.NewLine;
                selectTxt += " ,SUM(M_ARRIVALCNT7) AS ARRIVALCNT7" + Environment.NewLine;
                selectTxt += " ,SUM(M_SHIPMENTCNT8) AS SHIPMENTCNT8" + Environment.NewLine;
                selectTxt += " ,SUM(M_ARRIVALCNT8) AS ARRIVALCNT8" + Environment.NewLine;
                selectTxt += " ,SUM(M_SHIPMENTCNT9) AS SHIPMENTCNT9" + Environment.NewLine;
                selectTxt += " ,SUM(M_ARRIVALCNT9) AS ARRIVALCNT9" + Environment.NewLine;
                selectTxt += " ,SUM(M_SHIPMENTCNT10) AS SHIPMENTCNT10" + Environment.NewLine;
                selectTxt += " ,SUM(M_ARRIVALCNT10) AS ARRIVALCNT10" + Environment.NewLine;
                selectTxt += " ,SUM(M_SHIPMENTCNT11) AS SHIPMENTCNT11" + Environment.NewLine;
                selectTxt += " ,SUM(M_ARRIVALCNT11) AS ARRIVALCNT11" + Environment.NewLine;
                selectTxt += " ,SUM(M_ARRIVALCNT12) AS ARRIVALCNT12" + Environment.NewLine;
                selectTxt += " ,SUM(M_SHIPMENTCNT12) AS SHIPMENTCNT12" + Environment.NewLine;
                selectTxt += " ,BLGO.BLGROUPCODERF" + Environment.NewLine;
                selectTxt += " ,GROU.GOODSLGROUPRF" + Environment.NewLine;
                selectTxt += " ,GROU.GOODSMGROUPRF" + Environment.NewLine;
                selectTxt += " ,GDSU.ENTERPRISEGANRECODERF" + Environment.NewLine;


                //FROM
                selectTxt += "FROM" + Environment.NewLine;
                selectTxt += MakeSubSelectString(_stockShipArrivalListCndtnWork);

                #region [JOIN]
                //拠点情報設定マスタ
                //selectTxt += " LEFT JOIN SECINFOSETRF SECI" + Environment.NewLine;
                //selectTxt += " ON  SECI.ENTERPRISECODERF = STHIS.ENTERPRISECODERF" + Environment.NewLine;
                //selectTxt += " AND SECI.SECTIONCODERF = STHIS.SECTIONCODERF" + Environment.NewLine;

                //在庫マスタ
                selectTxt += " LEFT JOIN STOCKRF STOCK" + Environment.NewLine;
                selectTxt += " ON  STOCK.ENTERPRISECODERF = STHIS.ENTERPRISECODERF" + Environment.NewLine;
                //selectTxt += " AND STOCK.SECTIONCODERF = STHIS.SECTIONCODERF" + Environment.NewLine;
                selectTxt += " AND STOCK.WAREHOUSECODERF = STHIS.WAREHOUSECODERF" + Environment.NewLine;
                selectTxt += " AND STOCK.GOODSMAKERCDRF = STHIS.GOODSMAKERCDRF" + Environment.NewLine;
                selectTxt += " AND STOCK.GOODSNORF = STHIS.GOODSNORF" + Environment.NewLine;

                //商品マスタ
                selectTxt += " LEFT JOIN GOODSURF GDSU" + Environment.NewLine;
                selectTxt += " ON  GDSU.ENTERPRISECODERF = STHIS.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND GDSU.GOODSMAKERCDRF = STHIS.GOODSMAKERCDRF" + Environment.NewLine;
                selectTxt += " AND GDSU.GOODSNORF = STHIS.GOODSNORF" + Environment.NewLine;

                // --- ADD 田建委 2018/10/26 Redmine＃49771の対応---------->>>>>
                // 倉庫マスタ
                selectTxt += " LEFT JOIN WAREHOUSERF AS WH" + Environment.NewLine;
                selectTxt += " ON  WH.ENTERPRISECODERF=STHIS.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND WH.WAREHOUSECODERF=STHIS.WAREHOUSECODERF" + Environment.NewLine;

                // メーカーマスタ
                selectTxt += " LEFT JOIN MAKERURF AS MAK" + Environment.NewLine;
                selectTxt += " ON  MAK.ENTERPRISECODERF=STHIS.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND MAK.GOODSMAKERCDRF=STHIS.GOODSMAKERCDRF" + Environment.NewLine;
                // --- ADD 田建委 2018/10/26 Redmine＃49771の対応----------<<<<<

                //BLコードマスタ
                selectTxt += " LEFT JOIN BLGOODSCDURF AS BLGO" + Environment.NewLine;
                selectTxt += " ON  BLGO.ENTERPRISECODERF=GDSU.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND BLGO.BLGOODSCODERF=GDSU.BLGOODSCODERF" + Environment.NewLine;

                //グループコードマスタ
                selectTxt += "LEFT JOIN BLGROUPURF AS GROU" + Environment.NewLine;
                selectTxt += " ON" + Environment.NewLine;
                selectTxt += "      GROU.ENTERPRISECODERF=BLGO.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "  AND GROU.BLGROUPCODERF=BLGO.BLGROUPCODERF" + Environment.NewLine;
                #endregion  //[JOIN]

                //WHERE文の作成
                selectTxt += MakeWhereString(ref sqlCommand, _stockShipArrivalListCndtnWork, logicalMode);

                #region [GROUP BY]
                selectTxt += "GROUP BY" + Environment.NewLine;
                //selectTxt += "  SECI.SECTIONGUIDENMRF" + Environment.NewLine;
                //selectTxt += " ,STHIS.SECTIONCODERF" + Environment.NewLine;
                selectTxt += " STHIS.GOODSMAKERCDRF" + Environment.NewLine;
                // --- UPD 田建委 2018/10/26 Redmine＃49771の対応---------->>>>>
                //selectTxt += " ,STHIS.MAKERNAMERF" + Environment.NewLine;
                selectTxt += " ,MAK.MAKERNAMERF" + Environment.NewLine;
                // --- UPD 田建委 2018/10/26 Redmine＃49771の対応----------<<<<<
                selectTxt += " ,STHIS.WAREHOUSECODERF" + Environment.NewLine;
                // --- UPD 田建委 2018/10/26 Redmine＃49771の対応---------->>>>>
                //selectTxt += " ,STHIS.WAREHOUSENAMERF" + Environment.NewLine;
                selectTxt += " ,WH.WAREHOUSENAMERF" + Environment.NewLine;
                // --- UPD 田建委 2018/10/26 Redmine＃49771の対応----------<<<<<
                selectTxt += " ,STHIS.GOODSNORF" + Environment.NewLine;
                // --- UPD 田建委 2018/10/26 Redmine＃49771の対応---------->>>>>
                //selectTxt += " ,STHIS.GOODSNAMERF" + Environment.NewLine;
                selectTxt += " ,GDSU.GOODSNAMERF" + Environment.NewLine;
                // --- UPD 田建委 2018/10/26 Redmine＃49771の対応----------<<<<<
                selectTxt += " ,STOCK.WAREHOUSESHELFNORF" + Environment.NewLine;
                selectTxt += " ,STOCK.STOCKCREATEDATERF" + Environment.NewLine;
                selectTxt += " ,GDSU.BLGOODSCODERF" + Environment.NewLine;
                //selectTxt += " ,STOCK.STOCKSUPPLIERCODERF" + Environment.NewLine;
                selectTxt += " ,BLGO.BLGROUPCODERF" + Environment.NewLine;
                selectTxt += " ,GROU.GOODSLGROUPRF" + Environment.NewLine;
                selectTxt += " ,GROU.GOODSMGROUPRF" + Environment.NewLine;
                selectTxt += " ,GDSU.ENTERPRISEGANRECODERF" + Environment.NewLine;
                #endregion  //[GROUP BY]

                #endregion  //Select文作成

                sqlCommand.CommandText = selectTxt;

                myReader = sqlCommand.ExecuteReader();

                Double sum_ShipmentCnt = 0;
                Double sum_ArrivalCnt = 0;

                while (myReader.Read())
                {
                    #region 抽出結果-値セット
                    StockShipArrivalListWork wkStockShipArrivalListWork = new StockShipArrivalListWork();

                    //在庫履歴格納項目
                    //wkStockShipArrivalListWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
                    //wkStockShipArrivalListWork.SectionGuideNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDENMRF"));
                    wkStockShipArrivalListWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSECODERF"));
                    wkStockShipArrivalListWork.WarehouseName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSENAMERF"));
                    wkStockShipArrivalListWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
                    wkStockShipArrivalListWork.MakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERNAMERF"));
                    wkStockShipArrivalListWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
                    wkStockShipArrivalListWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMERF"));
                    wkStockShipArrivalListWork.WarehouseShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSESHELFNORF"));
                    wkStockShipArrivalListWork.StockCreateDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("STOCKCREATEDATERF"));
                    wkStockShipArrivalListWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
                    //wkStockShipArrivalListWork.StockSupplierCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKSUPPLIERCODERF"));
                    wkStockShipArrivalListWork.ShipmentCnt1 = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SHIPMENTCNT1"));
                    wkStockShipArrivalListWork.ArrivalCnt1 = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ARRIVALCNT1"));
                    wkStockShipArrivalListWork.ShipmentCnt2 = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SHIPMENTCNT2"));
                    wkStockShipArrivalListWork.ArrivalCnt2 = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ARRIVALCNT2"));
                    wkStockShipArrivalListWork.ShipmentCnt3 = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SHIPMENTCNT3"));
                    wkStockShipArrivalListWork.ArrivalCnt3 = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ARRIVALCNT3"));
                    wkStockShipArrivalListWork.ShipmentCnt4 = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SHIPMENTCNT4"));
                    wkStockShipArrivalListWork.ArrivalCnt4 = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ARRIVALCNT4"));
                    wkStockShipArrivalListWork.ShipmentCnt5 = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SHIPMENTCNT5"));
                    wkStockShipArrivalListWork.ArrivalCnt5 = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ARRIVALCNT5"));
                    wkStockShipArrivalListWork.ShipmentCnt6 = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SHIPMENTCNT6"));
                    wkStockShipArrivalListWork.ArrivalCnt6 = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ARRIVALCNT6"));
                    wkStockShipArrivalListWork.ShipmentCnt7 = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SHIPMENTCNT7"));
                    wkStockShipArrivalListWork.ArrivalCnt7 = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ARRIVALCNT7"));
                    wkStockShipArrivalListWork.ShipmentCnt8 = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SHIPMENTCNT8"));
                    wkStockShipArrivalListWork.ArrivalCnt8 = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ARRIVALCNT8"));
                    wkStockShipArrivalListWork.ShipmentCnt9 = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SHIPMENTCNT9"));
                    wkStockShipArrivalListWork.ArrivalCnt9 = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ARRIVALCNT9"));
                    wkStockShipArrivalListWork.ShipmentCnt10 = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SHIPMENTCNT10"));
                    wkStockShipArrivalListWork.ArrivalCnt10 = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ARRIVALCNT10"));
                    wkStockShipArrivalListWork.ShipmentCnt11 = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SHIPMENTCNT11"));
                    wkStockShipArrivalListWork.ArrivalCnt11 = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ARRIVALCNT11"));
                    wkStockShipArrivalListWork.ShipmentCnt12 = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SHIPMENTCNT12"));
                    wkStockShipArrivalListWork.ArrivalCnt12 = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ARRIVALCNT12"));
                    wkStockShipArrivalListWork.BLGroupCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGROUPCODERF"));
                    wkStockShipArrivalListWork.GoodsLGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSLGROUPRF"));
                    wkStockShipArrivalListWork.GoodsMGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMGROUPRF"));
                    wkStockShipArrivalListWork.EnterpriseGanreCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ENTERPRISEGANRECODERF"));                    

                    sum_ShipmentCnt = 0;
                    sum_ArrivalCnt = 0;

                    for (int i = 1; i <= dateCnt; i++)
                    {
                        sum_ShipmentCnt += SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SHIPMENTCNT" + i.ToString()));
                        sum_ArrivalCnt += SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ARRIVALCNT" + i.ToString())); ;
                    }

                    wkStockShipArrivalListWork.AVG_ShipmentCnt = sum_ShipmentCnt / dateCnt;
                    wkStockShipArrivalListWork.AVG_ArrivalCnt = sum_ArrivalCnt / dateCnt;
                    wkStockShipArrivalListWork.SUM_ShipmentCnt = sum_ShipmentCnt;
                    wkStockShipArrivalListWork.SUM_ArrivalCnt = sum_ArrivalCnt;

                    #endregion

                    keyHist = /*wkStockShipArrivalListWork.SectionCode +*/ wkStockShipArrivalListWork.WarehouseCode + wkStockShipArrivalListWork.GoodsNo + wkStockShipArrivalListWork.GoodsMakerCd.ToString("0000");
                    keyHistList.Add(keyHist);
                    if (lastKey.Contains(keyHist) == false)
                    {
                        lastKey.Add(keyHist);
                    }   
                    al.Add(keyHist, wkStockShipArrivalListWork);

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
                base.WriteErrorLog(ex, "StockShipArrivalListWorkDB.SearchStockShipArrivalProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (!myReader.IsClosed) myReader.Close();
            }

            return status;
        }
        #endregion  //在庫入出荷一覧表

        #region [MakeSubSelectString]
        /// <summary>
        /// 検索条件文字列生成＋条件値設定
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="_stockMoveListCndtnWork">検索条件格納クラス</param>
        /// <param name="_productNumberOutPutDiv">製番抽出区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>Where条件文字列</returns>
        private string MakeSubSelectString(StockShipArrivalListCndtnWork _stockShipArrivalListCndtnWork)
        {
            string retstring = "";
            DateTime stDate = _stockShipArrivalListCndtnWork.St_AddUpYearMonth;
            DateTime edDate = _stockShipArrivalListCndtnWork.Ed_AddUpYearMonth;
            Int32 setDate = stDate.Year * 100 + stDate.Month;

            dateCnt = 0;

            retstring += "(" + Environment.NewLine;
            retstring += "SELECT" + Environment.NewLine;
            retstring += "  ENTERPRISECODERF" + Environment.NewLine;
            retstring += " ,LOGICALDELETECODERF" + Environment.NewLine;
            retstring += " ,ADDUPYEARMONTHRF" + Environment.NewLine;
            //retstring += " ,SECTIONCODERF" + Environment.NewLine;
            retstring += " ,GOODSMAKERCDRF" + Environment.NewLine;
            retstring += " ,GOODSNAMERF" + Environment.NewLine;
            retstring += " ,MAKERNAMERF" + Environment.NewLine;
            retstring += " ,WAREHOUSECODERF" + Environment.NewLine;
            retstring += " ,WAREHOUSENAMERF" + Environment.NewLine;
            retstring += " ,GOODSNORF" + Environment.NewLine;

            for (int i = 1; i <= 12; i++)
            {

                //終了年月を超えたら強制的に０
                if (setDate > edDate.Year * 100 + edDate.Month)
                {
                    // Mantis 11773対応にて修正 2009/02/26 sakurai
                    //retstring += " ,CASE WHEN ADDUPYEARMONTHRF = " + setDate.ToString() +
                    //             "    THEN SHIPMENTCNTRF ELSE 0.0 END AS M_SHIPMENTCNT" + i.ToString() + Environment.NewLine;
                    //retstring += " ,CASE WHEN ADDUPYEARMONTHRF = " + setDate.ToString() +
                    //             "    THEN ARRIVALCNTRF ELSE 0.0 END AS M_ARRIVALCNT" + i.ToString() + Environment.NewLine;
                    // 2010/07/13 Del >>>
                    //retstring += " ,CASE WHEN ADDUPYEARMONTHRF = " + setDate.ToString() +
                    //             "    THEN (SALESCOUNTRF-SALESRETGOODSCNTRF) ELSE 0.0 END AS M_SHIPMENTCNT" + i.ToString() + Environment.NewLine;
                    //retstring += " ,CASE WHEN ADDUPYEARMONTHRF = " + setDate.ToString() +
                    //             "    THEN (STOCKCOUNTRF-STOCKRETGOODSCNTRF) ELSE 0.0 END AS M_ARRIVALCNT" + i.ToString() + Environment.NewLine;
                    // 2010/07/13 Del <<<
                    // 2010/07/13 Add -を+へ変更 >>>
                    retstring += " ,CASE WHEN ADDUPYEARMONTHRF = " + setDate.ToString() +
                                 "    THEN (SALESCOUNTRF+SALESRETGOODSCNTRF) ELSE 0.0 END AS M_SHIPMENTCNT" + i.ToString() + Environment.NewLine;
                    retstring += " ,CASE WHEN ADDUPYEARMONTHRF = " + setDate.ToString() +
                                 "    THEN (STOCKCOUNTRF+STOCKRETGOODSCNTRF) ELSE 0.0 END AS M_ARRIVALCNT" + i.ToString() + Environment.NewLine;
                    // 2010/07/13 Add <<<
                }
                else
                {
                    // Mantis 11773対応にて修正 2009/02/26 sakurai
                    //retstring += " ,CASE WHEN ADDUPYEARMONTHRF = " + setDate.ToString() +
                    //             "    THEN SHIPMENTCNTRF ELSE 0 END AS M_SHIPMENTCNT" + i.ToString() + Environment.NewLine;
                    //retstring += " ,CASE WHEN ADDUPYEARMONTHRF = " + setDate.ToString() +
                    //             "    THEN ARRIVALCNTRF ELSE 0 END AS M_ARRIVALCNT" + i.ToString() + Environment.NewLine;
                    // 2010/07/13 Del >>>
                    //retstring += " ,CASE WHEN ADDUPYEARMONTHRF = " + setDate.ToString() +
                    //             "    THEN (SALESCOUNTRF-SALESRETGOODSCNTRF) ELSE 0 END AS M_SHIPMENTCNT" + i.ToString() + Environment.NewLine;
                    //retstring += " ,CASE WHEN ADDUPYEARMONTHRF = " + setDate.ToString() +
                    //             "    THEN (STOCKCOUNTRF-STOCKRETGOODSCNTRF) ELSE 0 END AS M_ARRIVALCNT" + i.ToString() + Environment.NewLine;
                    // 2010/07/13 Del <<<
                    // 2010/07/13 Add -を+へ変更 >>>
                    retstring += " ,CASE WHEN ADDUPYEARMONTHRF = " + setDate.ToString() +
                                 "    THEN (SALESCOUNTRF+SALESRETGOODSCNTRF) ELSE 0 END AS M_SHIPMENTCNT" + i.ToString() + Environment.NewLine;
                    retstring += " ,CASE WHEN ADDUPYEARMONTHRF = " + setDate.ToString() +
                                 "    THEN (STOCKCOUNTRF+STOCKRETGOODSCNTRF) ELSE 0 END AS M_ARRIVALCNT" + i.ToString() + Environment.NewLine;
                    // 2010/07/13 Add <<<

                    dateCnt += 1;
                }

                if (setDate % 100 >= 12)
                {
                    setDate = (setDate + 100) / 100 * 100 + 1;
                }
                else
                {
                    setDate = setDate + 1;
                }
            }

            retstring += "FROM" + Environment.NewLine;
            retstring += "STOCKHISTORYRF" + Environment.NewLine;
            retstring += ") AS STHIS" + Environment.NewLine;

            return retstring;
        }
        #endregion  //[MakeSubSelectString]

        #region SearchStockProc
        /// <summary>
        /// 検索条件文字列生成＋条件値設定
        /// </summary>
        /// <param name="stockHistoryList">検索結果ArrayList</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="_stockMonthYearReportWork">検索条件格納クラス</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        private int SearchStockProc(ref Dictionary<string, StockShipArrivalListWork> dic, ref SqlConnection sqlConnection, StockShipArrivalListCndtnWork _stockShipArrivalListCndtnWork, ConstantManagement.LogicalMode logicalMode)
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
                selectTxt += "        ,BLGO.BLGROUPCODERF" + Environment.NewLine;
                selectTxt += "        ,GROU.GOODSLGROUPRF" + Environment.NewLine;
                selectTxt += "        ,GROU.GOODSMGROUPRF" + Environment.NewLine;
                selectTxt += "        ,GOODS.ENTERPRISEGANRECODERF" + Environment.NewLine;
                selectTxt += " FROM STOCKRF AS STOCK" + Environment.NewLine;
                selectTxt += "LEFT JOIN GOODSURF AS GOODS" + Environment.NewLine;
                selectTxt += " ON" + Environment.NewLine;
                selectTxt += "      GOODS.ENTERPRISECODERF=STOCK.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "  AND GOODS.GOODSMAKERCDRF=STOCK.GOODSMAKERCDRF" + Environment.NewLine;
                selectTxt += "  AND GOODS.GOODSNORF=STOCK.GOODSNORF" + Environment.NewLine;
                selectTxt += "LEFT JOIN MAKERURF AS MAKER" + Environment.NewLine;
                selectTxt += " ON" + Environment.NewLine;
                selectTxt += "      MAKER.ENTERPRISECODERF=STOCK.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "  AND MAKER.GOODSMAKERCDRF=STOCK.GOODSMAKERCDRF" + Environment.NewLine;
                selectTxt += "LEFT JOIN SECINFOSETRF AS SECI" + Environment.NewLine;
                selectTxt += " ON" + Environment.NewLine;
                selectTxt += "      SECI.ENTERPRISECODERF = STOCK.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "  AND SECI.SECTIONCODERF = STOCK.SECTIONCODERF" + Environment.NewLine;
                selectTxt += "LEFT JOIN BLGOODSCDURF AS BLGO" + Environment.NewLine;
                selectTxt += " ON" + Environment.NewLine;
                selectTxt += "      BLGO.ENTERPRISECODERF=GOODS.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "  AND BLGO.BLGOODSCODERF=GOODS.BLGOODSCODERF" + Environment.NewLine;
                selectTxt += "LEFT JOIN BLGROUPURF AS GROU" + Environment.NewLine;
                selectTxt += " ON" + Environment.NewLine;
                selectTxt += "      GROU.ENTERPRISECODERF=BLGO.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "  AND GROU.BLGROUPCODERF=BLGO.BLGROUPCODERF" + Environment.NewLine; 

                selectTxt += MakeWhereStockString(ref sqlCommand, _stockShipArrivalListCndtnWork, logicalMode);

                sqlCommand.CommandText = selectTxt;

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {

                    StockShipArrivalListWork wkstockWork = new StockShipArrivalListWork();

                    // 格納処理
                    #region 抽出結果格納処理

                    wkstockWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSECODERF"));
                    wkstockWork.StockSupplierCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKSUPPLIERCODERF"));
                    wkstockWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
                    wkstockWork.WarehouseShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSESHELFNORF"));
                    wkstockWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
                    wkstockWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
                    wkstockWork.MakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERNAMERF"));
                    wkstockWork.StockCreateDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("STOCKCREATEDATERF"));
                    wkstockWork.SectionGuideNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDENMRF"));
                    wkstockWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMERF"));
                    wkstockWork.BLGroupCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGROUPCODERF"));
                    wkstockWork.GoodsLGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSLGROUPRF"));
                    wkstockWork.GoodsMGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMGROUPRF"));
                    wkstockWork.EnterpriseGanreCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ENTERPRISEGANRECODERF"));    
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

        #region [在庫履歴 WHERE句]
        /// <summary>
        /// 検索条件文字列生成＋条件値設定
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="_stockMoveListCndtnWork">検索条件格納クラス</param>
        /// <param name="_productNumberOutPutDiv">製番抽出区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>Where条件文字列</returns>
        /// <br>Update Note: 2012/12/24 王君</br>
        /// <br>           : Redmine#33977の対応</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, StockShipArrivalListCndtnWork _stockShipArrivalListCndtnWork, ConstantManagement.LogicalMode logicalMode)
        {
            #region WHERE文作成
            string retstring = "WHERE" + Environment.NewLine;

            //企業コード
            retstring += " STHIS.ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(_stockShipArrivalListCndtnWork.EnterpriseCode);

            //if ((logicalMode == ConstantManagement.LogicalMode.GetData0) || (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
            //    (logicalMode == ConstantManagement.LogicalMode.GetData2) || (logicalMode == ConstantManagement.LogicalMode.GetData3))
            //{
            //    retstring += " AND STHIS.LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + Environment.NewLine; 
            //    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
            //    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
            //}
            //else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) || (logicalMode == ConstantManagement.LogicalMode.GetData012))
            //{
            //    retstring += " AND STHIS.LOGICALDELETECODERF<@FINDLOGICALDELETECODE" + Environment.NewLine;
            //    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
            //    if (logicalMode == ConstantManagement.LogicalMode.GetData01) paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
            //    else paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
            //}

            retstring += " AND STHIS.LOGICALDELETECODERF=0" + Environment.NewLine;
            retstring += " AND STOCK.LOGICALDELETECODERF=0" + Environment.NewLine;

            //年月度設定
            if (_stockShipArrivalListCndtnWork.St_AddUpYearMonth != DateTime.MinValue) 
            {
                retstring += " AND STHIS.ADDUPYEARMONTHRF>=@STADDUPYEARMONTH" + Environment.NewLine;
                SqlParameter paraStAddUpYearMonth = sqlCommand.Parameters.Add("@STADDUPYEARMONTH", SqlDbType.Int);
                paraStAddUpYearMonth.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(_stockShipArrivalListCndtnWork.St_AddUpYearMonth);
            }
            if (_stockShipArrivalListCndtnWork.Ed_AddUpYearMonth != DateTime.MinValue)
            {
                retstring += " AND STHIS.ADDUPYEARMONTHRF<=@EDADDUPYEARMONTH" + Environment.NewLine;
                SqlParameter paraEdAddUpYearMonth = sqlCommand.Parameters.Add("@EDADDUPYEARMONTH", SqlDbType.Int);
                paraEdAddUpYearMonth.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(_stockShipArrivalListCndtnWork.Ed_AddUpYearMonth);
            }

            ////拠点コード
            //if (_stockShipArrivalListCndtnWork.SectionCodes != null)
            //{
            //    string sectionCodestr = "";
            //    foreach (string seccdstr in _stockShipArrivalListCndtnWork.SectionCodes)
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
            if (_stockShipArrivalListCndtnWork.St_WarehouseCode != "")
            {
                retstring += " AND STHIS.WAREHOUSECODERF>=@STWAREHOUSECODE" + Environment.NewLine;
                SqlParameter paraStWarehouseCode = sqlCommand.Parameters.Add("@STWAREHOUSECODE", SqlDbType.NChar);
                paraStWarehouseCode.Value = SqlDataMediator.SqlSetString(_stockShipArrivalListCndtnWork.St_WarehouseCode);
            }
            if (_stockShipArrivalListCndtnWork.Ed_WarehouseCode != "")
            {
                retstring += " AND STHIS.WAREHOUSECODERF<=@EDWAREHOUSECODE" + Environment.NewLine;
                SqlParameter paraEdWarehouseCode = sqlCommand.Parameters.Add("@EDWAREHOUSECODE", SqlDbType.NChar);
                paraEdWarehouseCode.Value = SqlDataMediator.SqlSetString(_stockShipArrivalListCndtnWork.Ed_WarehouseCode);
            }

            ////仕入先コード設定
            //if (_stockShipArrivalListCndtnWork.St_SupplierCd != 0)
            //{
            //    retstring += " AND STOCK.STOCKSUPPLIERCODERF>=@STSUPPLIERCD" + Environment.NewLine;
            //    SqlParameter paraStSupplierCd = sqlCommand.Parameters.Add("@STSUPPLIERCD", SqlDbType.Int);
            //    paraStSupplierCd.Value = SqlDataMediator.SqlSetInt32(_stockShipArrivalListCndtnWork.St_SupplierCd);
            //}
            //if (_stockShipArrivalListCndtnWork.Ed_SupplierCd != 99999999)
            //{
            //    retstring += " AND STOCK.STOCKSUPPLIERCODERF<=@EDSUPPLIERCD" + Environment.NewLine;
            //    SqlParameter paraEdSupplierCd = sqlCommand.Parameters.Add("@EDSUPPLIERCD", SqlDbType.Int);
            //    paraEdSupplierCd.Value = SqlDataMediator.SqlSetInt32(_stockShipArrivalListCndtnWork.Ed_SupplierCd);
            //}

            //メーカーコード設定
            if (_stockShipArrivalListCndtnWork.St_GoodsMakerCd != 0)
            {
                retstring += " AND STHIS.GOODSMAKERCDRF>=@STGOODSMAKERCD" + Environment.NewLine;
                SqlParameter paraStGoodsMakerCd = sqlCommand.Parameters.Add("@STGOODSMAKERCD", SqlDbType.Int);
                paraStGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(_stockShipArrivalListCndtnWork.St_GoodsMakerCd);
            }
            if (_stockShipArrivalListCndtnWork.Ed_GoodsMakerCd != 999999)
            {
                retstring += " AND STHIS.GOODSMAKERCDRF<=@EDGOODSMAKERCD" + Environment.NewLine;
                SqlParameter paraEdGoodsMakerCd = sqlCommand.Parameters.Add("@EDGOODSMAKERCD", SqlDbType.Int);
                paraEdGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(_stockShipArrivalListCndtnWork.Ed_GoodsMakerCd);
            }

            //自社商品区分
            if (_stockShipArrivalListCndtnWork.St_EnterpriseGanreCode != 0)
            {
                retstring += " AND GDSU.ENTERPRISEGANRECODERF>=@STENTERPRISEGANRECODE" + Environment.NewLine;
				SqlParameter paraStEnterpriseGanreCode = sqlCommand.Parameters.Add("@STENTERPRISEGANRECODE", SqlDbType.Int);
				paraStEnterpriseGanreCode.Value = SqlDataMediator.SqlSetInt32(_stockShipArrivalListCndtnWork.St_EnterpriseGanreCode);
            }
            if (_stockShipArrivalListCndtnWork.Ed_EnterpriseGanreCode != 99999)
            {
                retstring += " AND GDSU.ENTERPRISEGANRECODERF<=@EDENTERPRISEGANRECODE" + Environment.NewLine;
                SqlParameter paraEdEnterpriseGanreCode = sqlCommand.Parameters.Add("@EDENTERPRISEGANRECODE", SqlDbType.Int);
                paraEdEnterpriseGanreCode.Value = SqlDataMediator.SqlSetInt32(_stockShipArrivalListCndtnWork.Ed_EnterpriseGanreCode);
            }

            //グループコード設定
            if (_stockShipArrivalListCndtnWork.St_BLGroupCode != 0)
            {
                retstring += " AND BLGO.BLGROUPCODERF>=@STBLGROUPCODE" + Environment.NewLine;
                SqlParameter paraStBLGroupCode = sqlCommand.Parameters.Add("@STBLGROUPCODE", SqlDbType.Int);
                paraStBLGroupCode.Value = SqlDataMediator.SqlSetInt32(_stockShipArrivalListCndtnWork.St_BLGroupCode);
            }
            if (_stockShipArrivalListCndtnWork.Ed_BLGroupCode != 0)
            {
                retstring += " AND BLGO.BLGROUPCODERF<=@EDBLGROUPCODE" + Environment.NewLine;
                SqlParameter paraEdBLGroupCode = sqlCommand.Parameters.Add("@EDBLGROUPCODE", SqlDbType.Int);
                paraEdBLGroupCode.Value = SqlDataMediator.SqlSetInt32(_stockShipArrivalListCndtnWork.Ed_BLGroupCode);
            }

            //商品大分類
            if (_stockShipArrivalListCndtnWork.St_GoodsLGroup != 0)
            {
                retstring += " AND GROU.GOODSLGROUPRF>=@STGOODSLGROUP" + Environment.NewLine;
                SqlParameter paraStGoodsLGroup = sqlCommand.Parameters.Add("@STGOODSLGROUP", SqlDbType.Int);
                paraStGoodsLGroup.Value = SqlDataMediator.SqlSetInt32(_stockShipArrivalListCndtnWork.St_GoodsLGroup);
            }
            if (_stockShipArrivalListCndtnWork.Ed_GoodsLGroup != 0)
            {
                retstring += " AND GROU.GOODSLGROUPRF<=@EDGOODSLGROUP" + Environment.NewLine;
                SqlParameter paraEdGoodsLGroup = sqlCommand.Parameters.Add("@EDGOODSLGROUP", SqlDbType.Int);
                paraEdGoodsLGroup.Value = SqlDataMediator.SqlSetInt32(_stockShipArrivalListCndtnWork.Ed_GoodsLGroup);
            }

            //商品中分類
            if (_stockShipArrivalListCndtnWork.St_GoodsMGroup != 0)
            {
                retstring += " AND GROU.GOODSMGROUPRF>=@STGOODSMGROUP" + Environment.NewLine;
                SqlParameter paraStGoodsMGroup = sqlCommand.Parameters.Add("@STGOODSMGROUP", SqlDbType.Int);
                paraStGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(_stockShipArrivalListCndtnWork.St_GoodsMGroup);
            }
            if (_stockShipArrivalListCndtnWork.Ed_GoodsMGroup != 0)
            {
                retstring += " AND GROU.GOODSMGROUPRF<=@EDGOODSMGROUP" + Environment.NewLine;
                SqlParameter paraEdGoodsMGroup = sqlCommand.Parameters.Add("@EDGOODSMGROUP", SqlDbType.Int);
                paraEdGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(_stockShipArrivalListCndtnWork.Ed_GoodsMGroup);
            }

            //BLコード設定
            if (_stockShipArrivalListCndtnWork.St_BLGoodsCode != 0)
            {
                retstring += " AND GDSU.BLGOODSCODERF>=@STBLGOODSCODE" + Environment.NewLine;
                SqlParameter paraStBLGoodsCode = sqlCommand.Parameters.Add("@STBLGOODSCODE", SqlDbType.Int);
                paraStBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(_stockShipArrivalListCndtnWork.St_BLGoodsCode);
            }
            if (_stockShipArrivalListCndtnWork.Ed_BLGoodsCode != 99999999)
            {
                retstring += " AND GDSU.BLGOODSCODERF<=@EDBLGOODSCODE" + Environment.NewLine;
                SqlParameter paraEdBLGoodsCode = sqlCommand.Parameters.Add("@EDBLGOODSCODE", SqlDbType.Int);
                paraEdBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(_stockShipArrivalListCndtnWork.Ed_BLGoodsCode);
            }

            //商品番号設定
            if (_stockShipArrivalListCndtnWork.St_GoodsNo != "")
            {
                retstring += " AND STHIS.GOODSNORF>=@STGOODSNO" + Environment.NewLine;
                SqlParameter paraStGoodsCd = sqlCommand.Parameters.Add("@STGOODSNO", SqlDbType.NVarChar);
                paraStGoodsCd.Value = SqlDataMediator.SqlSetString(_stockShipArrivalListCndtnWork.St_GoodsNo);
            }
            if (_stockShipArrivalListCndtnWork.Ed_GoodsNo != "")
            {
                retstring += " AND STHIS.GOODSNORF<=@EDGOODSNO" + Environment.NewLine;
                SqlParameter paraEdGoodsNo = sqlCommand.Parameters.Add("@EDGOODSNO", SqlDbType.NVarChar);
				paraEdGoodsNo.Value = SqlDataMediator.SqlSetString(_stockShipArrivalListCndtnWork.Ed_GoodsNo);
			}

            //在庫登録日
            if (_stockShipArrivalListCndtnWork.StockCreateDate != DateTime.MinValue)
            {
                if (_stockShipArrivalListCndtnWork.StockCreateDateDiv == 0)
                {
                    //retstring += " AND STOCK.STOCKCREATEDATERF<=@STOCKCREATEDATE" + Environment.NewLine;// DEL 2012/12/24 王君 Redmine#33977
                    retstring += " AND ISNULL(STOCK.STOCKCREATEDATERF, 0) <=@STOCKCREATEDATE" + Environment.NewLine; // ADD 2012/12/24 王君 Redmine#33977
                }
                else
                {
                    retstring += " AND STOCK.STOCKCREATEDATERF>=@STOCKCREATEDATE" + Environment.NewLine;
                }
                SqlParameter paraStockCreateDate = sqlCommand.Parameters.Add("@STOCKCREATEDATE", SqlDbType.Int);
                paraStockCreateDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(_stockShipArrivalListCndtnWork.StockCreateDate);
            }

            ////出荷数
            //if (_stockShipArrivalListCndtnWork.St_ShipArrivalCnt != 0)
            //{
            //    if (_stockShipArrivalListCndtnWork.ShipArrivalCntDiv == 0)
            //    {
            //        retstring += " AND (";
            //        for (int i = 1; i <= 12; i++)
            //        {
            //            retstring += "(M_SHIPMENTCNT" + i.ToString() + ">=@STSHIPMENTCNT" + Environment.NewLine;
            //            retstring += " OR M_ARRIVALCNT" + i.ToString() + ">=@STSHIPMENTCNT)" + Environment.NewLine;

            //            if (i < 12) retstring += " OR ";
            //        }

            //        retstring += ")";
            //    }
            //    else if (_stockShipArrivalListCndtnWork.ShipArrivalCntDiv == 1)
            //    {
            //        retstring += " AND (";
            //        for (int i = 1; i <= 12; i++)
            //        {
            //            retstring += "M_SHIPMENTCNT" + i.ToString() + ">=@STSHIPMENTCNT" + Environment.NewLine;

            //            if (i < 12) retstring += " OR ";
            //        }

            //        retstring += ")";
            //    }
            //    else if (_stockShipArrivalListCndtnWork.ShipArrivalCntDiv == 2)
            //    {
            //        retstring += " AND (";
            //        for (int i = 1; i <= 12; i++)
            //        {
            //            retstring += "M_ARRIVALCNT" + i.ToString() + ">=@STSHIPMENTCNT" + Environment.NewLine;

            //            if (i < 12) retstring += " OR ";
            //        }

            //        retstring += ")";
            //    }
            //    SqlParameter paraStShipmentCnt = sqlCommand.Parameters.Add("@STSHIPMENTCNT", SqlDbType.Int);
            //    paraStShipmentCnt.Value = SqlDataMediator.SqlSetInt32(_stockShipArrivalListCndtnWork.St_ShipArrivalCnt);
            //}

            ////入荷数
            //if (_stockShipArrivalListCndtnWork.Ed_ShipArrivalCnt != 999999999)
            //{
            //    if (_stockShipArrivalListCndtnWork.ShipArrivalCntDiv == 0)
            //    {
            //        retstring += " AND (";
            //        for (int i = 1; i <= 12; i++)
            //        {
            //            retstring += "(M_SHIPMENTCNT" + i.ToString() + "<=@EDSHIPMENTCNT" + Environment.NewLine;
            //            retstring += " OR M_ARRIVALCNT" + i.ToString() + "<=@EDSHIPMENTCNT)" + Environment.NewLine;

            //            if (i < 12) retstring += " OR ";
            //        }

            //        retstring += ")";
            //    }
            //    else if (_stockShipArrivalListCndtnWork.ShipArrivalCntDiv == 1)
            //    {
            //        retstring += " AND (";
            //        for (int i = 1; i <= 12; i++)
            //        {
            //            retstring += "M_SHIPMENTCNT" + i.ToString() + "<=@EDSHIPMENTCNT" + Environment.NewLine;

            //            if (i < 12) retstring += " OR ";
            //        }

            //        retstring += ")";
            //    }
            //    else if (_stockShipArrivalListCndtnWork.ShipArrivalCntDiv == 2)
            //    {
            //        retstring += " AND (";
            //        for (int i = 1; i <= 12; i++)
            //        {
            //            retstring += "M_ARRIVALCNT" + i.ToString() + "<=@EDSHIPMENTCNT" + Environment.NewLine;

            //            if (i < 12) retstring += " OR ";
            //        }

            //        retstring += ")";
            //    }
            //    SqlParameter paraEdShipmentCnt = sqlCommand.Parameters.Add("@EDSHIPMENTCNT", SqlDbType.Int);
            //    paraEdShipmentCnt.Value = SqlDataMediator.SqlSetInt32(_stockShipArrivalListCndtnWork.Ed_ShipArrivalCnt);
            //}

            #endregion
            return retstring;
        }
        #endregion  //[WHERE文生成]

        #region [在庫マスタ WHERE句]
        /// <summary>
        /// 検索条件文字列生成＋条件値設定
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="_stockMoveListCndtnWork">検索条件格納クラス</param>
        /// <param name="_productNumberOutPutDiv">製番抽出区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>Where条件文字列</returns>
        private string MakeWhereStockString(ref SqlCommand sqlCommand, StockShipArrivalListCndtnWork _stockShipArrivalListCndtnWork, ConstantManagement.LogicalMode logicalMode)
        {
            string retstring = "WHERE" + Environment.NewLine;

            // 企業コード
            retstring += " STOCK.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(_stockShipArrivalListCndtnWork.EnterpriseCode);

            // 論理削除区分
            //if ((logicalMode == ConstantManagement.LogicalMode.GetData0) || (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
            //   (logicalMode == ConstantManagement.LogicalMode.GetData2) || (logicalMode == ConstantManagement.LogicalMode.GetData3))
            //{
            //    retstring += " AND STOCK.LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + Environment.NewLine;
            //    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
            //    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
            //}
            //else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) || (logicalMode == ConstantManagement.LogicalMode.GetData012))
            //{

            //    retstring += " AND STOCK.LOGICALDELETECODERF<@FINDLOGICALDELETECODE" + Environment.NewLine;
            //    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
            //    if (logicalMode == ConstantManagement.LogicalMode.GetData01) paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
            //    else paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
            //}

            retstring += " AND STOCK.LOGICALDELETECODERF=0" + Environment.NewLine;

            //倉庫コード設定
            if (_stockShipArrivalListCndtnWork.St_WarehouseCode != "")
            {
                retstring += " AND STOCK.WAREHOUSECODERF>=@STWAREHOUSECODE" + Environment.NewLine;
                SqlParameter paraStWarehouseCode = sqlCommand.Parameters.Add("@STWAREHOUSECODE", SqlDbType.NChar);
                paraStWarehouseCode.Value = SqlDataMediator.SqlSetString(_stockShipArrivalListCndtnWork.St_WarehouseCode);
            }
            if (_stockShipArrivalListCndtnWork.Ed_WarehouseCode != "")
            {
                retstring += " AND STOCK.WAREHOUSECODERF<=@EDWAREHOUSECODE" + Environment.NewLine;
                SqlParameter paraEdWarehouseCode = sqlCommand.Parameters.Add("@EDWAREHOUSECODE", SqlDbType.NChar);
                paraEdWarehouseCode.Value = SqlDataMediator.SqlSetString(_stockShipArrivalListCndtnWork.Ed_WarehouseCode);
            }

            //メーカーコード設定
            if (_stockShipArrivalListCndtnWork.St_GoodsMakerCd != 0)
            {
                retstring += " AND STOCK.GOODSMAKERCDRF>=@STGOODSMAKERCD" + Environment.NewLine;
                SqlParameter paraStGoodsMakerCd = sqlCommand.Parameters.Add("@STGOODSMAKERCD", SqlDbType.Int);
                paraStGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(_stockShipArrivalListCndtnWork.St_GoodsMakerCd);
            }
            if (_stockShipArrivalListCndtnWork.Ed_GoodsMakerCd != 9999)
            {
                retstring += " AND STOCK.GOODSMAKERCDRF<=@EDGOODSMAKERCD" + Environment.NewLine;
                SqlParameter paraEdGoodsMakerCd = sqlCommand.Parameters.Add("@EDGOODSMAKERCD", SqlDbType.Int);
                paraEdGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(_stockShipArrivalListCndtnWork.Ed_GoodsMakerCd);
            }

            //商品番号設定
            if (_stockShipArrivalListCndtnWork.St_GoodsNo != "")
            {
                retstring += " AND STOCK.GOODSNORF>=@STGOODSNO" + Environment.NewLine;
                SqlParameter paraStGoodsCd = sqlCommand.Parameters.Add("@STGOODSNO", SqlDbType.NVarChar);
                paraStGoodsCd.Value = SqlDataMediator.SqlSetString(_stockShipArrivalListCndtnWork.St_GoodsNo);
            }
            if (_stockShipArrivalListCndtnWork.Ed_GoodsNo != "")
            {
                retstring += " AND STOCK.GOODSNORF<=@EDGOODSNO" + Environment.NewLine;
                SqlParameter paraEdGoodsNo = sqlCommand.Parameters.Add("@EDGOODSNO", SqlDbType.NVarChar);
                paraEdGoodsNo.Value = SqlDataMediator.SqlSetString(_stockShipArrivalListCndtnWork.Ed_GoodsNo);
            }
            return retstring;
        }
        #endregion

    }
}

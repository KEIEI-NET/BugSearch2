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

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 売掛残高一覧表(総括)DBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 売掛残高一覧表(総括)の実データ操作を行うクラスです。</br>
    /// <br>Programmer : 30350 櫻井 亮太</br>
    /// <br>Date       : 2009/04/20</br>
    /// -----------------------------------------------------------------------------------
    /// <br>UpdateNote : Maintis.15088 請求拠点ではなく管理拠点で集計されている件の修正</br>
    /// <br>UpdateNote : Maintis.15090 集金担当で抽出しようとするとエラーになる件の修正</br>
    /// <br>Programmer : 30517 夏野 駿希</br>
    /// <br>Date	   : 2010/03/10</br>
    /// <br></br>
    /// <br>UpdateNote : 不具合修正</br>
    /// <br>Programmer : 22008 長内 数馬</br>
    /// <br>Date	   : 2010/06/06</br>
    /// <br>UpdateNote : 11570208-00 軽減税率対応</br>
    /// <br>Programmer : 3H 劉星光</br>
    /// <br>Date	   : 2020/04/10</br>
    /// <br>UpdateNote : 11800255-00　インボイス対応（税率別合計金額不具合修正）</br>
    /// <br>Programmer : 陳艶丹</br>
    /// <br>Date       : 2022/10/13</br>
    /// </remarks>
    [Serializable]
    public class SumBillBalanceTableDB : RemoteDB, ISumBillBalanceTableDB
    {
        private int _timeOut = 3600;//ADD 2020/02/28 石崎　軽減税率対応
        /// <summary>
        /// 売掛残高一覧表(総括)DBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 30350 櫻井 亮太</br>
        /// <br>Date       : 2009/04/20</br>
        /// </remarks>
        public SumBillBalanceTableDB()
            :
            base("PMHNB02279D", "Broadleaf.Application.Remoting.ParamData.SumRsltInfo_BillBalanceWork", "CUSTACCRECRF")
        {
        }

        /// <summary>売掛/買掛金額マスタ更新リモートオブジェクト</summary>
        private MonthlyAddUpDB _monthlyAddUpDB;

        #region [Search]
        /// <summary>
        /// 指定された条件の売掛残高一覧表(総括)を戻します
        /// </summary>
        /// <param name="retObj">検索結果</param>
        /// <param name="paraObj">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の売掛残高一覧表を戻します</br>
        /// <br>Programmer : 30350 櫻井 亮太</br>
        /// <br>Date       : 2009/04/20</br>
        public int Search(out object sumrsltInfo_BillBalanceWork, object sumextrInfo_BillBalanceWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            sumrsltInfo_BillBalanceWork = null;

            ArrayList _extrInfo_BillBalanceWorkList = sumextrInfo_BillBalanceWork as ArrayList;
            SumExtrInfo_BillBalanceWork _extrInfo_BillBalanceWork = null;

            if (_extrInfo_BillBalanceWorkList == null)
            {
                _extrInfo_BillBalanceWork = sumextrInfo_BillBalanceWork as SumExtrInfo_BillBalanceWork;
            }
            else
            {
                if (_extrInfo_BillBalanceWorkList.Count > 0)
                    _extrInfo_BillBalanceWork = _extrInfo_BillBalanceWorkList[0] as SumExtrInfo_BillBalanceWork;
            }

            try
            {
                status = SearchProc(out sumrsltInfo_BillBalanceWork, _extrInfo_BillBalanceWork, readMode, logicalMode);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "BillBalanceTableDB.Search Exception=" + ex.Message);
                sumrsltInfo_BillBalanceWork = new ArrayList();
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }

            return status;
        }
        #endregion  //[Search]

        #region [SearchProc]
        /// <summary>
        /// 指定された企業コードの売掛残高一覧表(総括)LISTを全て戻します
        /// </summary>
        /// <param name="accPaymentListResultWork">検索結果</param>
        /// <param name="_extrInfo_BillBalanceWork">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された企業コードの売掛残高一覧表LISTを全て戻します</br>
        /// <br>Programmer : 30350 櫻井 亮太</br>
        /// <br>Date       : 2009/04/20</br>
        /// <br>UpdateNote : 11570208-00 軽減税率対応</br>
        /// <br>Programmer : 3H 劉星光</br>
        /// <br>Date	   : 2020/04/10</br>
        private int SearchProc(out object sumrsltInfo_BillBalanceWork, SumExtrInfo_BillBalanceWork _sumextrInfo_BillBalanceWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;

            sumrsltInfo_BillBalanceWork = null;
            // --- ADD START 3H 劉星光 2020/04/10 ---------->>>>>
            // 締次フラッグ
            bool isCheckOut = true;
            // 請求先前回月次更新年月日
            Dictionary<int, DateTime> claimDateDic = new Dictionary<int, DateTime>();
            // --- ADD END 3H 劉星光 2020/04/10 ----------<<<<<
            ArrayList al = new ArrayList();   //抽出結果

            try
            {
                //SQL文生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                
                //初期処理
                TtlDayCalcDB ttlDayCalcDB = new TtlDayCalcDB();
                List<TtlDayCalcRetWork> retList = new List<TtlDayCalcRetWork>();
                TtlDayCalcParaWork para = new TtlDayCalcParaWork();

                ArrayList customerList = new ArrayList();
                SumRsltInfo_BillBalanceWork customerListWork = new SumRsltInfo_BillBalanceWork();

                //得意先マスタリスト作成
                status = SearchCustProc(ref customerList, _sumextrInfo_BillBalanceWork, ref sqlConnection, logicalMode);
                if ((status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND) || (status == (int)ConstantManagement.DB_Status.ctDB_EOF))
                {
                    //該当データなし
                    return status;
                }
                else if (status != 0)
                {
                    //取得失敗
                    throw new Exception("得意先マスタ読込失敗。");
                }
                if (customerList.Count == 0)
                {
                    //該当データなし
                    return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }
                    
                for (int i = 0; i < customerList.Count; i++)
                {
                    #region [締処理チェック]
                    retList = new List<TtlDayCalcRetWork>();
                    para = new TtlDayCalcParaWork();
                    para.EnterpriseCode = _sumextrInfo_BillBalanceWork.EnterpriseCode.Trim();               // 企業コード
                    para.SectionCode = ((SumRsltInfo_BillBalanceWork)customerList[i]).AddUpSecCode.Trim();  // 拠点コード
                    status = ttlDayCalcDB.SearchHisMonthlyAccRec(out retList, para, ref sqlConnection);
                    
                    // 締日をMax値にする処理必要
                    int MaxTotalDay = 0;
                    foreach (TtlDayCalcRetWork _ttlDayCalcRetWork in retList)
                    {
                        if (MaxTotalDay < _ttlDayCalcRetWork.TotalDay)
                        {
                            MaxTotalDay = _ttlDayCalcRetWork.TotalDay;
                        }
                    }
                    #endregion

                    //日付変換
                    Int32 iAddUpDate = Int32.Parse(_sumextrInfo_BillBalanceWork.AddUpDate.ToString("yyyyMMdd"));
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL || MaxTotalDay < iAddUpDate)
                    {
                        #region 未締取得処理
                        //売掛金・買掛金集計モジュールパラメータセット
                        this._monthlyAddUpDB = new MonthlyAddUpDB();
                        CustAccRecWork custAccRecWork = new CustAccRecWork();
                        custAccRecWork.EnterpriseCode = _sumextrInfo_BillBalanceWork.EnterpriseCode;                //企業コード
                        custAccRecWork.AddUpDate = _sumextrInfo_BillBalanceWork.AddUpDate;                          //計上年月日
                        custAccRecWork.AddUpYearMonth = _sumextrInfo_BillBalanceWork.AddUpYearMonth;                //計上年月
                        custAccRecWork.AddUpSecCode = ((SumRsltInfo_BillBalanceWork)customerList[i]).AddUpSecCode;  //計上拠点コード ※得意先マスタリストから
                        custAccRecWork.CustomerCode = ((SumRsltInfo_BillBalanceWork)customerList[i]).CustomerCode;     //得意先コード   ※得意先マスタリストから
                        object paraObj2 = (object)custAccRecWork;
                        string retMsg = null;

                        //売掛金・買掛金集計モジュール呼出
                        status = _monthlyAddUpDB.ReadCustAccRec(ref paraObj2, out retMsg);
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            //取得成功
                            //取得結果キャスト
                            ArrayList custAccRecResult = new ArrayList();
                            custAccRecResult.Add((CustAccRecWork)paraObj2);

                            //取得結果セット
                            for (int j = 0; j < custAccRecResult.Count; j++)
                            {
                                #region [抽出結果-値セット]
                                SumRsltInfo_BillBalanceWork ResultWork = new SumRsltInfo_BillBalanceWork();

                                //拠点コード ※得意先マスタから
                                // -- UPD 2010/06/06 ------------------------------------------->>>
                                //ResultWork.AddUpSecCode = ((SumRsltInfo_BillBalanceWork)customerList[i]).AddUpSecCode;
                                ResultWork.AddUpSecCode = ((SumRsltInfo_BillBalanceWork)customerList[i]).SumSecCode;  //総括得意先の請求拠点で上書き
                                // -- UPD 2010/06/06 -------------------------------------------<<<
                                //拠点名称 ※拠点情報設定マスタから
                                ResultWork.SectionGuideSnm = ((SumRsltInfo_BillBalanceWork)customerList[i]).SectionGuideSnm;
                                //総括請求先コード ※得意先マスタから
                                ResultWork.ClaimCode = ((SumRsltInfo_BillBalanceWork)customerList[i]).ClaimCode;
                                //総括請求先略称 ※得意先マスタから
                                ResultWork.ClaimSnm = ((SumRsltInfo_BillBalanceWork)customerList[i]).ClaimSnm;
                                //総括得意先コード
                                ResultWork.CustomerCode = ((SumRsltInfo_BillBalanceWork)customerList[i]).CustomerCode;
                                //総括得意先名称
                                ResultWork.Customersnm = ((SumRsltInfo_BillBalanceWork)customerList[i]).Customersnm;
                                //担当者コード ※得意先マスタから
                                ResultWork.AgentCd = ((SumRsltInfo_BillBalanceWork)customerList[i]).AgentCd;
                                //担当者名 ※従業員マスタから
                                ResultWork.Name = ((SumRsltInfo_BillBalanceWork)customerList[i]).Name;
                                //地区コード ※得意先マスタから
                                ResultWork.SalesAreaCode = ((SumRsltInfo_BillBalanceWork)customerList[i]).SalesAreaCode;
                                //地区名 ※ユーザーガイドマスタ(ボディ)(ユーザ変更分)から
                                ResultWork.SalesAreaName = ((SumRsltInfo_BillBalanceWork)customerList[i]).SalesAreaName;
                                //前月末残高
                                ResultWork.LastTimeAccRec = ((CustAccRecWork)custAccRecResult[j]).LastTimeAccRec;
                                //当月入金
                                ResultWork.ThisTimeDmdNrml = ((CustAccRecWork)custAccRecResult[j]).ThisTimeDmdNrml;
                                //繰越額
                                ResultWork.ThisTimeTtlBlcAcc = ((CustAccRecWork)custAccRecResult[j]).ThisTimeTtlBlcAcc;
                                //売上額
                                ResultWork.OfsThisTimeSales = ((CustAccRecWork)custAccRecResult[j]).OfsThisTimeSales;
                                ResultWork.ThisTimeSales = ((CustAccRecWork)custAccRecResult[j]).ThisTimeSales;
                                //返品値引
                                ResultWork.ThisRgdsDisPric = ((CustAccRecWork)custAccRecResult[j]).ThisSalesPricRgds + ((CustAccRecWork)custAccRecResult[j]).ThisSalesPricDis;
                                //消費税
                                ResultWork.OfsThisSalesTax = ((CustAccRecWork)custAccRecResult[j]).OfsThisSalesTax;
                                //当月末残高
                                ResultWork.AfCalTMonthAccRec = ((CustAccRecWork)custAccRecResult[j]).AfCalTMonthAccRec;
                                //枚数
                                ResultWork.SalesSlipCount = ((CustAccRecWork)custAccRecResult[j]).SalesSlipCount;
                                //手数料
                                ResultWork.ThisTimeFeeDmdNrml = ((CustAccRecWork)custAccRecResult[j]).ThisTimeFeeDmdNrml;
                                //値引
                                ResultWork.ThisTimeDisDmdNrml = ((CustAccRecWork)custAccRecResult[j]).ThisTimeDisDmdNrml;

                                // --- ADD START 3H 劉星光 2020/04/10 ---------->>>>>
                                if (_sumextrInfo_BillBalanceWork.TaxPrintDiv == (int)TaxTotalDiv.TaxTotalON)
                                {
                                    // 締次フラッグ
                                    isCheckOut = false;

                                    // 請求先コード
                                    int claimCode = ((CustAccRecWork)custAccRecResult[j]).ClaimCode;

                                    // 前回月次更新年月日
                                    DateTime laMonCAddUpUpdDate = ((CustAccRecWork)custAccRecResult[j]).LaMonCAddUpUpdDate;

                                    // 請求先前回月次更新年月日
                                    if (!claimDateDic.ContainsKey(claimCode))
                                    {
                                        claimDateDic.Add(claimCode, laMonCAddUpUpdDate);
                                    }
                                }
                                // --- ADD END 3H 劉星光 2020/04/10 ----------<<<<<

                                // 0実績チェック
                                if (ResultWork.LastTimeAccRec == 0 && ResultWork.ThisTimeFeeDmdNrml == 0 &&
                                    ResultWork.ThisTimeDisDmdNrml == 0 && ResultWork.ThisTimeDmdNrml == 0 &&
                                    ResultWork.OfsThisTimeSales == 0 && ResultWork.OfsThisSalesTax == 0 &&
                                    ResultWork.SalesSlipCount == 0)
                                {
                                    continue;
                                }

                                if (_sumextrInfo_BillBalanceWork.DepoDtlDiv == (int)DepoDtlDiv.DepoDtlON)
                                {
                                    //入金データ取得
                                    ArrayList DepsitList = new ArrayList();
                                    status = SearchDepsitProc(ref DepsitList, custAccRecResult, ref sqlConnection, logicalMode);
                                    if ((status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND) ||
                                        (status == (int)ConstantManagement.DB_Status.ctDB_EOF))
                                    {
                                        //該当データなし statusをクリアし次へ
                                        al.Add(ResultWork);
                                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                                        continue;
                                    }
                                    else if (status != 0)
                                    {
                                        //取得失敗
                                        throw new Exception("入金データ取得失敗。");
                                    }
                                    if (DepsitList.Count == 0)
                                    {
                                        //該当データなし statusをクリアし次へ
                                        al.Add(ResultWork);
                                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                                        continue;
                                    }

                                    //現金
                                    ResultWork.CashDeposit = ((SumRsltInfo_BillBalanceWork)DepsitList[0]).CashDeposit;
                                    //振込
                                    ResultWork.TrfrDeposit = ((SumRsltInfo_BillBalanceWork)DepsitList[0]).TrfrDeposit;
                                    //小切手
                                    ResultWork.CheckDeposit = ((SumRsltInfo_BillBalanceWork)DepsitList[0]).CheckDeposit;
                                    //手形
                                    ResultWork.DraftDeposit = ((SumRsltInfo_BillBalanceWork)DepsitList[0]).DraftDeposit;
                                    //相殺
                                    ResultWork.OffsetDeposit = ((SumRsltInfo_BillBalanceWork)DepsitList[0]).OffsetDeposit;
                                    //口座振替
                                    ResultWork.FundTransferDeposit = ((SumRsltInfo_BillBalanceWork)DepsitList[0]).FundTransferDeposit;
                                    //その他
                                    ResultWork.OthsDeposit = ((SumRsltInfo_BillBalanceWork)DepsitList[0]).OthsDeposit;

                                }
                                #endregion  //[抽出結果-値セット]

                                al.Add(ResultWork);
                                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                            }
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
                        #endregion
                    }
                    else
                    {
                        customerListWork = customerList[i] as SumRsltInfo_BillBalanceWork;
                        //締め済 -> 得意先売掛金額マスタから取得
                        //検索実行
                        status = SearchBillBalanceTableProc(ref al, _sumextrInfo_BillBalanceWork, customerListWork, ref sqlConnection, logicalMode);
                    }
                }

                // --- ADD START 3H 劉星光 2020/04/10 ---------->>>>>
                // 消費税別内訳印字する
                if (_sumextrInfo_BillBalanceWork.TaxPrintDiv == (int)TaxTotalDiv.TaxTotalON)
                {
                    Dictionary<int, CustAccRecDateInfo> custAccRecDateDic = new Dictionary<int, CustAccRecDateInfo>();
                    // 月次更新を行った場合
                    if (isCheckOut)
                    {
                        // 月次更新処理日取得を行う
                        status = SearchCustAccRecDate(_sumextrInfo_BillBalanceWork, ref custAccRecDateDic, ref sqlConnection);

                        if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                        {
                            // 該当データなし
                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                        }
                        else if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            // 取得失敗
                            throw new Exception("月次更新処理日取得失敗。");
                        }
                    }

                    for (int i = 0; i < al.Count; i++)
                    {

                        SumRsltInfo_BillBalanceWork billBalanceWork = (SumRsltInfo_BillBalanceWork)al[i];

                        // 前回月次更新年月日
                        DateTime laMonCAddUpUpdDate = DateTime.MinValue;

                        if (!isCheckOut)
                        {
                            // 前回月次更新年月日取得
                            claimDateDic.TryGetValue(billBalanceWork.ClaimCode, out laMonCAddUpUpdDate);
                        }

                        // 売上データ取得
                        status = SearchSalesProc(ref billBalanceWork, ref sqlConnection, _sumextrInfo_BillBalanceWork, isCheckOut, laMonCAddUpUpdDate, custAccRecDateDic);

                        if ((status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND) ||
                            (status == (int)ConstantManagement.DB_Status.ctDB_EOF))
                        {
                            //該当データなし statusをクリアし次へ
                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                            continue;
                        }
                        else if (status != 0)
                        {
                            //取得失敗
                            throw new Exception("売上データ取得失敗。");
                        }

                    }
                }
                // --- ADD END 3H 劉星光 2020/04/10 ----------<<<<<
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "BillBalanceTableDB.SearchProc Exception=" + ex.Message);
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

            sumrsltInfo_BillBalanceWork = al;
            // --- UPD START 3H 劉星光 2020/04/10 ---------->>>>>
            //if (al.Count > 0)
            //{
            //    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            //}
            if (_sumextrInfo_BillBalanceWork.TaxPrintDiv == (int)TaxTotalDiv.TaxTotalOFF)
            {
                if (al.Count > 0)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            // --- UPD END 3H 劉星光 2020/04/10 ----------<<<<<
            return status;
        }
        #endregion  //[SearchProc]

        #region [SearchCustProc]
        /// <summary>
        /// 得意先マスタから条件に該当する得意先リストを抽出します。
        /// </summary>
        /// <param name="al">検索結果</param>
        /// <param name="_extrInfo_BillBalanceWork">検索パラメータ</param>
        /// <param name="sqlConnection">コネクション情報</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の得意先リストを戻します</br>
        /// <br>Programmer : 23015 森本 大輝</br>
        /// <br>Date       : 2008.09.22</br>
        private int SearchCustProc(ref ArrayList al, SumExtrInfo_BillBalanceWork _extrInfo_BillBalanceWork, ref SqlConnection sqlConnection, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                string selectTxt = "";
                sqlCommand = new SqlCommand(selectTxt, sqlConnection);

                // 対象テーブル
                // CUSTOMERRF        CSTMER 得意先マスタ
                // EMPLOYEERF        EMPLYE 従業員マスタ
                // USERGDBDURF       USGDBD ユーザーガイドマスタ(ボディ)(ユーザ変更分)
                // SECINFOSETRF      SCINST 拠点情報設定マスタ

                // 来週使う得意先総括検索

                #region SELECT文
                selectTxt += "  SELECT  " + Environment.NewLine;
                selectTxt += "   SUMCST.ENTERPRISECODERF  " + Environment.NewLine;
                selectTxt += "  ,SUMCST.CUSTOMERCODERF " + Environment.NewLine;
                selectTxt += "  ,CUSTOM.CUSTOMERSNMRF " + Environment.NewLine;
                selectTxt += "  ,SUMCST.SUMCLAIMCUSTCODERF " + Environment.NewLine;
                selectTxt += "  ,CUSTCL.CUSTOMERSNMRF AS SUMCUSTOMERSNMRF " + Environment.NewLine;
                selectTxt += "  ,CUSTCL.MNGSECTIONCODERF " + Environment.NewLine;
                // -- UPD 2010/06/06 --------------------------->>>
                //// 2010/03/10 Add >>>
                //selectTxt += "  ,CUSTCL.CLAIMSECTIONCODERF " + Environment.NewLine;
                //// 2010/03/10 Add <<<
                selectTxt += "  ,CUSTCL.CLAIMSECTIONCODERF AS SUMSECCODERF" + Environment.NewLine;   //総括得意先の請求拠点
                selectTxt += "  ,CUSTOM.CLAIMSECTIONCODERF" + Environment.NewLine;                   //請求先の請求拠点を追加
                // -- UPD 2010/06/06 ---------------------------<<<
                selectTxt += "  ,SECINF.SECTIONGUIDENMRF " + Environment.NewLine;
                selectTxt += "  ,CUSTCL.SALESAREACODERF  " + Environment.NewLine;
                selectTxt += IFBy(_extrInfo_BillBalanceWork.EmployeeKindDiv == (int)EmployeeKindDiv.CustomerAgentCd,
                             "  ,CUSTCL.CUSTOMERAGENTCDRF AS AGENTCD  ");
                selectTxt += IFBy(_extrInfo_BillBalanceWork.EmployeeKindDiv == (int)EmployeeKindDiv.BillCollecterCd,
                             "  ,CUSTCL.BILLCOLLECTERCDRF AS AGENTCD" + Environment.NewLine);
                selectTxt += "  ,USERGD.GUIDENAMERF AS SALESAREANAME  " + Environment.NewLine;
                selectTxt += "  ,EMPLOY.NAMERF  " + Environment.NewLine;
                selectTxt += "  FROM SUMCUSTSTRF AS SUMCST  " + Environment.NewLine;
                selectTxt += "  LEFT JOIN CUSTOMERRF AS CUSTOM   " + Environment.NewLine;
                selectTxt += "   ON  CUSTOM.ENTERPRISECODERF = SUMCST.ENTERPRISECODERF   " + Environment.NewLine;
                selectTxt += "   AND CUSTOM.CUSTOMERCODERF = SUMCST.CUSTOMERCODERF   " + Environment.NewLine;
                //selectTxt += "   AND CUSTOM.MNGSECTIONCODERF = SUMCST.DEMANDADDUPSECCDRF   " + Environment.NewLine;
                selectTxt += "  LEFT JOIN CUSTOMERRF AS CUSTCL  " + Environment.NewLine;
                selectTxt += "   ON  CUSTCL.ENTERPRISECODERF = SUMCST.ENTERPRISECODERF  " + Environment.NewLine;
                selectTxt += "   AND CUSTCL.CUSTOMERCODERF = SUMCST.SUMCLAIMCUSTCODERF  " + Environment.NewLine;
                //selectTxt += "   AND CUSTCL.MNGSECTIONCODERF = SUMCST.DEMANDADDUPSECCDRF  " + Environment.NewLine;
                selectTxt += "  LEFT JOIN SECINFOSETRF AS SECINF  " + Environment.NewLine;
                selectTxt += "   ON  SECINF.ENTERPRISECODERF = SUMCST.ENTERPRISECODERF  " + Environment.NewLine;
                // 2010/03/10 >>>
                //selectTxt += "   AND SECINF.SECTIONCODERF = CUSTCL.MNGSECTIONCODERF  " + Environment.NewLine;
                selectTxt += "   AND SECINF.SECTIONCODERF = CUSTCL.CLAIMSECTIONCODERF  " + Environment.NewLine;
                // 2010/03/10 <<<
                selectTxt += "  LEFT JOIN USERGDBDURF AS USERGD  " + Environment.NewLine;
                selectTxt += "   ON  USERGD.ENTERPRISECODERF = SUMCST.ENTERPRISECODERF  " + Environment.NewLine;
                selectTxt += "   AND USERGD.GUIDECODERF=CUSTCL.SALESAREACODERF  " + Environment.NewLine;
                selectTxt += "   AND USERGD.USERGUIDEDIVCDRF=21  " + Environment.NewLine;
                selectTxt += "  LEFT JOIN EMPLOYEERF AS EMPLOY  " + Environment.NewLine;
                selectTxt += "   ON  EMPLOY.ENTERPRISECODERF = SUMCST.ENTERPRISECODERF  " + Environment.NewLine;
                selectTxt += IFBy(_extrInfo_BillBalanceWork.EmployeeKindDiv == (int)EmployeeKindDiv.CustomerAgentCd,
                             "   AND EMPLOY.EMPLOYEECODERF = CUSTCL.CUSTOMERAGENTCDRF" + Environment.NewLine);
                // 2010/03/10 >>>
                //selectTxt += IFBy(_extrInfo_BillBalanceWork.EmployeeKindDiv == (int)EmployeeKindDiv.BillCollecterCd,
                //             "   AND EMPLYE.EMPLOYEECODERF=CUSTCL.BILLCOLLECTERCDRF" + Environment.NewLine);
                selectTxt += IFBy(_extrInfo_BillBalanceWork.EmployeeKindDiv == (int)EmployeeKindDiv.BillCollecterCd,
                             "   AND EMPLOY.EMPLOYEECODERF=CUSTCL.BILLCOLLECTERCDRF" + Environment.NewLine);
                // 2010/03/10 <<<
                #endregion



                #region [Select文作成]
                //selectTxt += "SELECT" + Environment.NewLine;
                //selectTxt += "  CSTMER.CLAIMCODERF" + Environment.NewLine;
                //selectTxt += " ,CSTMER.CLAIMSECTIONCODERF" + Environment.NewLine;
                //selectTxt += " ,CSTMER.CUSTOMERSNMRF" + Environment.NewLine;
                //selectTxt += " ,SCINST.SECTIONGUIDESNMRF" + Environment.NewLine;
                //selectTxt += IFBy(_extrInfo_BillBalanceWork.EmployeeKindDiv == (int)EmployeeKindDiv.CustomerAgentCd,
                //             " ,CSTMER.CUSTOMERAGENTCDRF AS AGENTCD" + Environment.NewLine);
                //selectTxt += IFBy(_extrInfo_BillBalanceWork.EmployeeKindDiv == (int)EmployeeKindDiv.BillCollecterCd,
                //             " ,CSTMER.BILLCOLLECTERCDRF AS AGENTCD" + Environment.NewLine);
                //selectTxt += " ,EMPLYE.NAMERF" + Environment.NewLine;
                //selectTxt += " ,CSTMER.SALESAREACODERF" + Environment.NewLine;
                //selectTxt += " ,USGDBD.GUIDENAMERF AS SALESAREANAME" + Environment.NewLine;
                ////FROM
                //selectTxt += " FROM CUSTOMERRF AS CSTMER" + Environment.NewLine;

                #region [JOIN]
                ////従業員マスタ
                //selectTxt += " LEFT JOIN EMPLOYEERF EMPLYE" + Environment.NewLine;
                //selectTxt += " ON  EMPLYE.ENTERPRISECODERF=CSTMER.ENTERPRISECODERF" + Environment.NewLine;
                //selectTxt += IFBy(_extrInfo_BillBalanceWork.EmployeeKindDiv == (int)EmployeeKindDiv.CustomerAgentCd,
                //             " AND EMPLYE.EMPLOYEECODERF=CSTMER.CUSTOMERAGENTCDRF" + Environment.NewLine);
                //selectTxt += IFBy(_extrInfo_BillBalanceWork.EmployeeKindDiv == (int)EmployeeKindDiv.BillCollecterCd,
                //             " AND EMPLYE.EMPLOYEECODERF=CSTMER.BILLCOLLECTERCDRF" + Environment.NewLine);

                ////ユーザーガイドマスタ(ボディ)(ユーザ変更分)
                //selectTxt += " LEFT JOIN USERGDBDURF USGDBD" + Environment.NewLine;
                //selectTxt += " ON  USGDBD.ENTERPRISECODERF=CSTMER.ENTERPRISECODERF" + Environment.NewLine;
                //selectTxt += " AND USGDBD.GUIDECODERF=CSTMER.SALESAREACODERF" + Environment.NewLine;
                //selectTxt += " AND USGDBD.USERGUIDEDIVCDRF=21" + Environment.NewLine;

                ////拠点情報設定マスタ
                //selectTxt += " LEFT JOIN SECINFOSETRF SCINST" + Environment.NewLine;
                //selectTxt += " ON  SCINST.ENTERPRISECODERF=CSTMER.ENTERPRISECODERF" + Environment.NewLine;
                //selectTxt += " AND SCINST.SECTIONCODERF=CSTMER.CLAIMSECTIONCODERF" + Environment.NewLine;
                #endregion  //[JOIN]

                #region [WHERE句]
                selectTxt += " WHERE" + Environment.NewLine;

                //企業コード
                selectTxt += " SUMCST.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(_extrInfo_BillBalanceWork.EnterpriseCode);

                //論理削除区分
                if ((logicalMode == ConstantManagement.LogicalMode.GetData0) || (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData2) || (logicalMode == ConstantManagement.LogicalMode.GetData3))
                {
                    selectTxt += " AND SUMCST.LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + Environment.NewLine;
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
                }
                else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) || (logicalMode == ConstantManagement.LogicalMode.GetData012))
                {
                    selectTxt += " AND SUMCST.LOGICALDELETECODERF<@FINDLOGICALDELETECODE" + Environment.NewLine;
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                    if (logicalMode == ConstantManagement.LogicalMode.GetData01) paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
                    else paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
                }

                //拠点コード
                if (_extrInfo_BillBalanceWork.SectionCodes != null)
                {
                    string sectionCodestr = "";
                    foreach (string seccdstr in _extrInfo_BillBalanceWork.SectionCodes)
                    {
                        if (sectionCodestr != "")
                        {
                            sectionCodestr += ",";
                        }
                        sectionCodestr += "'" + seccdstr + "'";
                    }
                    if (sectionCodestr != "")
                    {
                        // 2010/03/10 >>>
                        //selectTxt += " AND CUSTCL.MNGSECTIONCODERF IN (" + sectionCodestr + ") ";
                        selectTxt += " AND CUSTCL.CLAIMSECTIONCODERF IN (" + sectionCodestr + ") ";
                        // 2010/03/10 <<<
                    }
                    selectTxt += Environment.NewLine;
                }

                //得意先コード
                if (_extrInfo_BillBalanceWork.St_ClaimCode != 0)
                {
                    // -- UPD 20101/06/06 ---------------------------------------->>>
                    //selectTxt += " AND SUMCST.CUSTOMERCODERF>=@ST_CUSTOMERCOD" + Environment.NewLine;
                    selectTxt += " AND SUMCST.SUMCLAIMCUSTCODERF>=@ST_CUSTOMERCOD" + Environment.NewLine;
                    // -- UPD 20101/06/06 ----------------------------------------<<<
                    SqlParameter paraSt_CustomerCode = sqlCommand.Parameters.Add("@ST_CUSTOMERCOD", SqlDbType.Int);
                    paraSt_CustomerCode.Value = SqlDataMediator.SqlSetInt32(_extrInfo_BillBalanceWork.St_ClaimCode);
                }

                if (_extrInfo_BillBalanceWork.Ed_ClaimCode != 999999999)
                {
                    // -- UPD 20101/06/06 ---------------------------------------->>>
                    //selectTxt += " AND SUMCST.CUSTOMERCODERF<=@ED_CUSTOMERCOD" + Environment.NewLine;
                    selectTxt += " AND SUMCST.SUMCLAIMCUSTCODERF<=@ED_CUSTOMERCOD" + Environment.NewLine;
                    // -- UPD 20101/06/06 ----------------------------------------<<<
                    SqlParameter paraEd_CustomerCode = sqlCommand.Parameters.Add("@ED_CUSTOMERCOD", SqlDbType.Int);
                    paraEd_CustomerCode.Value = SqlDataMediator.SqlSetInt32(_extrInfo_BillBalanceWork.Ed_ClaimCode);
                }

                //販売エリアコード
                if (_extrInfo_BillBalanceWork.St_SalesAreaCode != 0)
                {
                    selectTxt += " AND CUSTCL.SALESAREACODERF>=@ST_SALESAREACODE" + Environment.NewLine;
                    SqlParameter paraSt_SalesAreaCode = sqlCommand.Parameters.Add("@ST_SALESAREACODE", SqlDbType.Int);
                    paraSt_SalesAreaCode.Value = SqlDataMediator.SqlSetInt32(_extrInfo_BillBalanceWork.St_SalesAreaCode);
                }

                // -- UPD 20101/06/06 ---------------------------------------->>>
                //if (_extrInfo_BillBalanceWork.Ed_SalesAreaCode != 99)
                if (_extrInfo_BillBalanceWork.Ed_SalesAreaCode != 9999)
                // -- UPD 20101/06/06 ----------------------------------------<<<
                {
                    selectTxt += " AND CUSTCL.SALESAREACODERF<=@ED_SALESAREACODE" + Environment.NewLine;
                    SqlParameter paraEd_SalesAreaCode = sqlCommand.Parameters.Add("@ED_SALESAREACODE", SqlDbType.Int);
                    paraEd_SalesAreaCode.Value = SqlDataMediator.SqlSetInt32(_extrInfo_BillBalanceWork.Ed_SalesAreaCode);
                }

                //担当者コード
                if (_extrInfo_BillBalanceWork.St_EmployeeCode != "")
                {
                    if (_extrInfo_BillBalanceWork.EmployeeKindDiv == (int)EmployeeKindDiv.CustomerAgentCd)
                        selectTxt += " AND CUSTCL.CUSTOMERAGENTCDRF>=@ST_AGENTCD" + Environment.NewLine;
                    else if (_extrInfo_BillBalanceWork.EmployeeKindDiv == (int)EmployeeKindDiv.BillCollecterCd)
                        selectTxt += " AND CUSTCL.BILLCOLLECTERCDRF>=@ST_AGENTCD" + Environment.NewLine;
                    SqlParameter paraSt_EmployeeCode = sqlCommand.Parameters.Add("@ST_AGENTCD", SqlDbType.NChar);
                    paraSt_EmployeeCode.Value = SqlDataMediator.SqlSetString(_extrInfo_BillBalanceWork.St_EmployeeCode);
                }
                if (_extrInfo_BillBalanceWork.Ed_EmployeeCode != "")
                {
                    if (_extrInfo_BillBalanceWork.EmployeeKindDiv == (int)EmployeeKindDiv.CustomerAgentCd)
                        selectTxt += " AND ( CUSTCL.CUSTOMERAGENTCDRF<=@ED_AGENTCD OR CUSTCL.CUSTOMERAGENTCDRF IS NULL )" + Environment.NewLine;
                    else if (_extrInfo_BillBalanceWork.EmployeeKindDiv == (int)EmployeeKindDiv.BillCollecterCd)
                        selectTxt += " AND ( CUSTCL.BILLCOLLECTERCDRF<=@ED_AGENTCD OR CUSTCL.BILLCOLLECTERCDRF IS NULL )" + Environment.NewLine;
                    SqlParameter paraEd_EmployeeCode = sqlCommand.Parameters.Add("@ED_AGENTCD", SqlDbType.NChar);
                    paraEd_EmployeeCode.Value = SqlDataMediator.SqlSetString(_extrInfo_BillBalanceWork.Ed_EmployeeCode);
                }
                // ADD 2008.11.13 >>>
                //selectTxt += "AND CUSTCL.CUSTOMERCODERF IS NOT Null" + Environment.NewLine;
                //selectTxt += "AND CUSTCL.CUSTOMERCODERF !=0" + Environment.NewLine;
                //selectTxt += "AND CUSTCL.CUSTOMERCODERF =CUSTCL.CLAIMCODERF" + Environment.NewLine;
                // ADD 2008.11.13 <<<

                #endregion  //[WHERE句]

                #region [ORDER BY]
                //出力順 0:得意先順 1:担当者順 2:地区順
                switch (_extrInfo_BillBalanceWork.SortOrderDiv)
                {
                    // -- UPD 2010/06/06 ------------------------->>>
                    //case 0:  //0:得意先順 -> 拠点－得意先順
                    //    selectTxt += " ORDER BY SUMCST.DEMANDADDUPSECCDRF, SUMCST.SUMCLAIMCUSTCODERF, SUMCST.CUSTOMERCODERF ";
                    //    break;
                    //case 1:  //1:担当者順 -> 拠点－担当者－得意先順
                    //    if (_extrInfo_BillBalanceWork.EmployeeKindDiv == (int)EmployeeKindDiv.CustomerAgentCd)
                    //        selectTxt += " ORDER BY SUMCST.DEMANDADDUPSECCDRF, CUSTCL.CUSTOMERAGENTCDRF, CUSTCL.CUSTOMERCODERF";
                    //    else if (_extrInfo_BillBalanceWork.EmployeeKindDiv == (int)EmployeeKindDiv.BillCollecterCd)
                    //        selectTxt += " ORDER BY SUMCST.DEMANDADDUPSECCDRF, CUSTCL.BILLCOLLECTERCDRF, CUSTCL.CUSTOMERCODERF";
                    //    break;
                    //case 2:  //2:地区順 -> 拠点－地区－得意先順
                    //    selectTxt += " ORDER BY SUMCST.DEMANDADDUPSECCDRF, CUSTCL.SALESAREACODERF, CUSTCL.CUSTOMERCODERF";
                    //    break;

                    case 1:  //1:得意先順 -> 拠点－得意先順
                        selectTxt += " ORDER BY CUSTCL.CLAIMSECTIONCODERF, SUMCST.SUMCLAIMCUSTCODERF, SUMCST.CUSTOMERCODERF ";
                        break;
                    case 2:  //2:担当者順 -> 拠点－担当者－得意先順
                        if (_extrInfo_BillBalanceWork.EmployeeKindDiv == (int)EmployeeKindDiv.CustomerAgentCd)
                            selectTxt += " ORDER BY CUSTCL.CLAIMSECTIONCODERF, CUSTCL.CUSTOMERAGENTCDRF, CUSTCL.CUSTOMERCODERF";
                        else if (_extrInfo_BillBalanceWork.EmployeeKindDiv == (int)EmployeeKindDiv.BillCollecterCd)
                            selectTxt += " ORDER BY CUSTCL.CLAIMSECTIONCODERF, CUSTCL.BILLCOLLECTERCDRF, CUSTCL.CUSTOMERCODERF";
                        break;
                    case 3:  //3:地区順 -> 拠点－地区－得意先順
                        selectTxt += " ORDER BY CUSTCL.CLAIMSECTIONCODERF, CUSTCL.SALESAREACODERF, CUSTCL.CUSTOMERCODERF";
                        break;
                    // -- UPD 2010/06/06 -------------------------<<<
                }
                #endregion  //[ORDER BY]

                #endregion  //[Select文作成]

                sqlCommand.CommandText = selectTxt;

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    SumRsltInfo_BillBalanceWork ResultWork = new SumRsltInfo_BillBalanceWork();

                    #region [抽出結果-値セット]

                    // 2010/03/10 >>>
                    //ResultWork.AddUpSecCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MNGSECTIONCODERF"));　 // 総括請求拠点
                    ResultWork.AddUpSecCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CLAIMSECTIONCODERF"));　 // 請求先請求拠点
                    // 2010/03/10 <<<
                    ResultWork.SumSecCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUMSECCODERF"));　         // 総括請求拠点  // ADD 2010/06/06
                    ResultWork.SectionGuideSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDENMRF")); // 総括請求拠点名称
                    ResultWork.ClaimCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUMCLAIMCUSTCODERF")); 　　　// 総括請求先コード
                    ResultWork.ClaimSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUMCUSTOMERSNMRF"));         // 総括請求先名称
                    ResultWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));           // 総括得意先コード
                    ResultWork.Customersnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERSNMRF"));            // 総括得意先名称
                    ResultWork.AgentCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("AGENTCD"));                   // 従業員区分
                    ResultWork.Name = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NAMERF"));                       // 名称
                    ResultWork.SalesAreaCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESAREACODERF"));      // 地区区分
                    ResultWork.SalesAreaName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESAREANAME"));       // 地区名称
                    #endregion

                    al.Add(ResultWork);
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
                base.WriteErrorLog(ex, "BillBalanceTableDB.SearchCustProc Exception=" + ex.Message);
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
        #endregion  //[SearchCustProc]

        #region [SearchDepsitProc]
        /// <summary>
        /// 未締めの入金データを取得します。
        /// </summary>
        /// <param name="al">検索結果</param>
        /// <param name="custAccRecWork">検索パラメータ</param>
        /// <param name="sqlConnection">コネクション情報</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 未締めの入金データを取得します</br>
        /// <br>Programmer : 23015 森本 大輝</br>
        /// <br>Date       : 2008.09.22</br>
        private int SearchDepsitProc(ref ArrayList al, ArrayList custAccRecWork, ref SqlConnection sqlConnection, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                string selectTxt = "";
                sqlCommand = new SqlCommand(selectTxt, sqlConnection);

                // 対象テーブル
                // DEPSITMAINRF      DEPMIN 入金マスタ
                // DEPSITDTLRF       DEPDTL 入金明細データ

                #region [Select文作成]
                selectTxt += "SELECT" + Environment.NewLine;
                selectTxt += "   DEPMIN.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "  ,DEPMIN.ADDUPSECCODERF" + Environment.NewLine;
                selectTxt += "  ,DEPMIN.CUSTOMERCODERF" + Environment.NewLine;
                selectTxt += "  ,DEPMIN.CLAIMCODERF" + Environment.NewLine;
                selectTxt += "  ,SUM((CASE WHEN DEPDTL.MONEYKINDCODERF=51 THEN DEPDTL.DEPOSITRF ELSE 0 END)) AS CASHDEPOSIT" + Environment.NewLine;
                selectTxt += "  ,SUM((CASE WHEN DEPDTL.MONEYKINDCODERF=52 THEN DEPDTL.DEPOSITRF ELSE 0 END)) AS TRFRDEPOSIT" + Environment.NewLine;
                selectTxt += "  ,SUM((CASE WHEN DEPDTL.MONEYKINDCODERF=53 THEN DEPDTL.DEPOSITRF ELSE 0 END)) AS CHECKDEPOSIT" + Environment.NewLine;
                selectTxt += "  ,SUM((CASE WHEN DEPDTL.MONEYKINDCODERF=54 THEN DEPDTL.DEPOSITRF ELSE 0 END)) AS DRAFTDEPOSIT" + Environment.NewLine;
                selectTxt += "  ,SUM((CASE WHEN DEPDTL.MONEYKINDCODERF=56 THEN DEPDTL.DEPOSITRF ELSE 0 END)) AS OFFSETDEPOSIT" + Environment.NewLine;
                selectTxt += "  ,SUM((CASE WHEN DEPDTL.MONEYKINDCODERF=59 THEN DEPDTL.DEPOSITRF ELSE 0 END)) AS FUNDTRANSFERDEPOSIT" + Environment.NewLine;
                selectTxt += "  ,(SUM(DEPDTL.DEPOSITRF)" + Environment.NewLine;
                selectTxt += "   -SUM((CASE WHEN DEPDTL.MONEYKINDCODERF=51 THEN DEPDTL.DEPOSITRF ELSE 0 END))" + Environment.NewLine;
                selectTxt += "   -SUM((CASE WHEN DEPDTL.MONEYKINDCODERF=52 THEN DEPDTL.DEPOSITRF ELSE 0 END))" + Environment.NewLine;
                selectTxt += "   -SUM((CASE WHEN DEPDTL.MONEYKINDCODERF=53 THEN DEPDTL.DEPOSITRF ELSE 0 END))" + Environment.NewLine;
                selectTxt += "   -SUM((CASE WHEN DEPDTL.MONEYKINDCODERF=54 THEN DEPDTL.DEPOSITRF ELSE 0 END))" + Environment.NewLine;
                selectTxt += "   -SUM((CASE WHEN DEPDTL.MONEYKINDCODERF=56 THEN DEPDTL.DEPOSITRF ELSE 0 END))" + Environment.NewLine;
                selectTxt += "   -SUM((CASE WHEN DEPDTL.MONEYKINDCODERF=59 THEN DEPDTL.DEPOSITRF ELSE 0 END))" + Environment.NewLine;
                selectTxt += "   ) AS OTHSDEPOSIT" + Environment.NewLine;
                //FROM
                selectTxt += " FROM DEPSITMAINRF AS DEPMIN" + Environment.NewLine;
                //JOIN
                selectTxt += " INNER JOIN DEPSITDTLRF DEPDTL" + Environment.NewLine;
                selectTxt += " ON  DEPDTL.ENTERPRISECODERF=DEPMIN.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND DEPDTL.ACPTANODRSTATUSRF=DEPMIN.ACPTANODRSTATUSRF" + Environment.NewLine;
                selectTxt += " AND DEPDTL.DEPOSITSLIPNORF=DEPMIN.DEPOSITSLIPNORF" + Environment.NewLine;
                //WHERE
                selectTxt += " WHERE" + Environment.NewLine;
                selectTxt += "      DEPMIN.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                selectTxt += "  AND DEPMIN.DEPOSITDEBITNOTECDRF = 0" + Environment.NewLine;
                selectTxt += "  AND DEPMIN.CUSTOMERCODERF=@FINDCUSTOMERCODE" + Environment.NewLine;
                selectTxt += "  AND DEPMIN.CLAIMCODERF=@FINDCLAIMCODE" + Environment.NewLine;
                selectTxt += "  AND DEPMIN.ADDUPSECCODERF=@FINDADDUPSECCODE" + Environment.NewLine;
                selectTxt += "  AND (DEPMIN.ADDUPADATERF<=@FINDADDUPDATE AND DEPMIN.ADDUPADATERF>@FINDLASTTIMEADDUPDATE)" + Environment.NewLine;
                //GROU BY
                selectTxt += " GROUP BY" + Environment.NewLine;
                selectTxt += "   DEPMIN.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "  ,DEPMIN.ADDUPSECCODERF" + Environment.NewLine;
                selectTxt += "  ,DEPMIN.CUSTOMERCODERF" + Environment.NewLine;
                selectTxt += "  ,DEPMIN.CLAIMCODERF" + Environment.NewLine;
                #endregion  //[Select文作成]

                sqlCommand.CommandText = selectTxt;

                //Prameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
                SqlParameter findParaClaimCode = sqlCommand.Parameters.Add("@FINDCLAIMCODE", SqlDbType.Int);
                SqlParameter findParaAddUpSecCode = sqlCommand.Parameters.Add("@FINDADDUPSECCODE", SqlDbType.NChar);
                SqlParameter findParaAddUpDate = sqlCommand.Parameters.Add("@FINDADDUPDATE", SqlDbType.Int);
                SqlParameter findParaLastTimeAddUpDate = sqlCommand.Parameters.Add("@FINDLASTTIMEADDUPDATE", SqlDbType.Int);

                //Parameterオブジェクトへ値設定
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(((CustAccRecWork)custAccRecWork[0]).EnterpriseCode);
                findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(((CustAccRecWork)custAccRecWork[0]).CustomerCode);
                findParaClaimCode.Value = SqlDataMediator.SqlSetInt32(((CustAccRecWork)custAccRecWork[0]).ClaimCode);
                findParaAddUpSecCode.Value = SqlDataMediator.SqlSetString(((CustAccRecWork)custAccRecWork[0]).AddUpSecCode);
                findParaAddUpDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(((CustAccRecWork)custAccRecWork[0]).AddUpDate);
                if (((CustAccRecWork)custAccRecWork[0]).LaMonCAddUpUpdDate == DateTime.MinValue)
                    findParaLastTimeAddUpDate.Value = 20000101;
                else
                    findParaLastTimeAddUpDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(((CustAccRecWork)custAccRecWork[0]).LaMonCAddUpUpdDate);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    SumRsltInfo_BillBalanceWork ResultWork = new SumRsltInfo_BillBalanceWork();

                    #region [抽出結果-値セット]
                    ResultWork.CashDeposit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("CASHDEPOSIT"));
                    ResultWork.TrfrDeposit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TRFRDEPOSIT"));
                    ResultWork.CheckDeposit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("CHECKDEPOSIT"));
                    ResultWork.DraftDeposit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DRAFTDEPOSIT"));
                    ResultWork.OffsetDeposit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("OFFSETDEPOSIT"));
                    ResultWork.FundTransferDeposit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("FUNDTRANSFERDEPOSIT"));
                    ResultWork.OthsDeposit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("OTHSDEPOSIT"));
                    #endregion

                    al.Add(ResultWork);
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
                base.WriteErrorLog(ex, "BillBalanceTableDB.SearchDepsitProc Exception=" + ex.Message);
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
        #endregion  //[SearchDepsitProc]

        #region [SearchBillBalanceTableProc]
        /// <summary>
        /// 指定された条件の売掛残高一覧表を戻します
        /// </summary>
        /// <param name="al">検索結果</param>
        /// <param name="_extrInfo_BillBalanceWork">検索パラメータ</param>
        /// <param name="sqlConnection">コネクション情報</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の売掛残高一覧表を戻します</br>
        /// <br>Programmer : 23015 森本 大輝</br>
        /// <br>Date       : 2008.09.22</br>
        //private int SearchBillBalanceTableProc(ref ArrayList al, ExtrInfo_BillBalanceWork _extrInfo_BillBalanceWork, ref SqlConnection sqlConnection, ConstantManagement.LogicalMode logicalMode)
        private int SearchBillBalanceTableProc(ref ArrayList al, SumExtrInfo_BillBalanceWork _sumextrInfo_BillBalanceWork, SumRsltInfo_BillBalanceWork customerListWork, ref SqlConnection sqlConnection, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                string selectTxt = "";
                sqlCommand = new SqlCommand(selectTxt, sqlConnection);

                // 対象テーブル
                // CUSTACCRECRF      CSTREC 得意先売掛金額マスタ
                // ACCRECDEPOTOTALRF ACCDEP 売掛入金集計データ
                // CUSTOMERRF        CSTMER 得意先マスタ
                // EMPLOYEERF        EMPLYE 従業員マスタ
                // USERGDBDURF       USGDBD ユーザーガイドマスタ(ボディ)(ユーザ変更分)
                // SECINFOSETRF      SCINST 拠点情報設定マスタ

                #region [Select文作成]
                selectTxt += "SELECT" + Environment.NewLine;
                selectTxt += "   CSTREC.ADDUPSECCODERF" + Environment.NewLine;
                selectTxt += "  ,SCINST.SECTIONGUIDESNMRF" + Environment.NewLine;
                selectTxt += "  ,CSTREC.CLAIMCODERF" + Environment.NewLine;
                selectTxt += "  ,CSTREC.CLAIMSNMRF" + Environment.NewLine;
                selectTxt += "  ,CSTREC.LASTTIMEACCRECRF" + Environment.NewLine;
                selectTxt += "  ,CSTREC.THISTIMEDMDNRMLRF" + Environment.NewLine;
                selectTxt += "  ,CSTREC.THISTIMETTLBLCACCRF" + Environment.NewLine;
                selectTxt += "  ,CSTREC.OFSTHISTIMESALESRF" + Environment.NewLine;
                selectTxt += "  ,CSTREC.THISTIMESALESRF" + Environment.NewLine;
                selectTxt += "  ,(CSTREC.THISSALESPRICRGDSRF+CSTREC.THISSALESPRICDISRF)" + Environment.NewLine;
                selectTxt += "   AS THISRGDSDISPRIC" + Environment.NewLine;
                selectTxt += "  ,CSTREC.OFSTHISSALESTAXRF" + Environment.NewLine;
                selectTxt += "  ,CSTREC.AFCALTMONTHACCRECRF" + Environment.NewLine;
                selectTxt += "  ,CSTREC.SALESSLIPCOUNTRF" + Environment.NewLine;
                selectTxt += IFBy(_sumextrInfo_BillBalanceWork.EmployeeKindDiv == (int)EmployeeKindDiv.CustomerAgentCd,
                             "  ,CSTMER.CUSTOMERAGENTCDRF AS AGENTCD" + Environment.NewLine);
                selectTxt += IFBy(_sumextrInfo_BillBalanceWork.EmployeeKindDiv == (int)EmployeeKindDiv.BillCollecterCd,
                             "  ,CSTMER.BILLCOLLECTERCDRF AS AGENTCD" + Environment.NewLine);
                selectTxt += "  ,EMPLYE.NAMERF" + Environment.NewLine;
                selectTxt += "  ,CSTMER.SALESAREACODERF" + Environment.NewLine;
                selectTxt += "  ,USGDBD.GUIDENAMERF AS SALESAREANAME" + Environment.NewLine;
                selectTxt += "  ,CSTREC.THISTIMEFEEDMDNRMLRF" + Environment.NewLine;
                selectTxt += "  ,CSTREC.THISTIMEDISDMDNRMLRF" + Environment.NewLine;
                selectTxt += "  ,CSTREC.CASHDEPOSIT" + Environment.NewLine;
                selectTxt += "  ,CSTREC.TRFRDEPOSIT" + Environment.NewLine;
                selectTxt += "  ,CSTREC.CHECKDEPOSIT" + Environment.NewLine;
                selectTxt += "  ,CSTREC.DRAFTDEPOSIT" + Environment.NewLine;
                selectTxt += "  ,CSTREC.OFFSETDEPOSIT" + Environment.NewLine;
                selectTxt += "  ,CSTREC.OTHSDEPOSIT" + Environment.NewLine;
                selectTxt += "  ,CSTREC.FUNDTRANSFERDEPOSIT" + Environment.NewLine;

                selectTxt += "  ,SUMCST.SUMCLAIMCUSTCODERF" + Environment.NewLine;
                selectTxt += "  ,CUSTSU.CUSTOMERSNMRF" + Environment.NewLine;
                // -- UPD 2010/06/06 -------------------------------->>>
                //selectTxt += "  ,SUMCST.DEMANDADDUPSECCDRF" + Environment.NewLine;
                selectTxt += "  ,CUSTSU.CLAIMSECTIONCODERF AS DEMANDADDUPSECCDRF" + Environment.NewLine;
                // -- UPD 2010/06/06 --------------------------------<<<

                //FROM
                selectTxt += " FROM" + Environment.NewLine;
                selectTxt += " (" + Environment.NewLine;

                #region [データ抽出メインQuery]
                //得意先売掛金額マスタ
                selectTxt += "  SELECT" + Environment.NewLine;
                selectTxt += "    CSTRECSUB.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "   ,CSTRECSUB.ADDUPSECCODERF" + Environment.NewLine;
                selectTxt += "   ,CSTRECSUB.CLAIMCODERF" + Environment.NewLine;
                selectTxt += "   ,CSTRECSUB.CLAIMSNMRF" + Environment.NewLine;
                selectTxt += "   ,CSTRECSUB.LASTTIMEACCRECRF" + Environment.NewLine;
                selectTxt += "   ,CSTRECSUB.THISTIMEDMDNRMLRF" + Environment.NewLine;
                selectTxt += "   ,CSTRECSUB.THISTIMETTLBLCACCRF" + Environment.NewLine;
                selectTxt += "   ,CSTRECSUB.OFSTHISTIMESALESRF" + Environment.NewLine;
                selectTxt += "   ,CSTRECSUB.THISTIMESALESRF" + Environment.NewLine;
                selectTxt += "   ,CSTRECSUB.THISSALESPRICRGDSRF" + Environment.NewLine;
                selectTxt += "   ,CSTRECSUB.THISSALESPRICDISRF" + Environment.NewLine;
                selectTxt += "   ,CSTRECSUB.OFSTHISSALESTAXRF" + Environment.NewLine;
                selectTxt += "   ,CSTRECSUB.AFCALTMONTHACCRECRF" + Environment.NewLine;
                selectTxt += "   ,CSTRECSUB.SALESSLIPCOUNTRF" + Environment.NewLine;
                selectTxt += "   ,CSTRECSUB.THISTIMEFEEDMDNRMLRF" + Environment.NewLine;
                selectTxt += "   ,CSTRECSUB.THISTIMEDISDMDNRMLRF" + Environment.NewLine;
                selectTxt += "   ,CSTRECSUB.LOGICALDELETECODERF" + Environment.NewLine;
                selectTxt += "   ,CSTRECSUB.CUSTOMERCODERF" + Environment.NewLine;
                selectTxt += "   ,CSTRECSUB.ADDUPYEARMONTHRF  " + Environment.NewLine;
                selectTxt += "   ,CSTRECSUB.ADDUPDATERF" + Environment.NewLine;
                selectTxt += "   ,ACCDEP.CASHDEPOSIT" + Environment.NewLine;
                selectTxt += "   ,ACCDEP.TRFRDEPOSIT" + Environment.NewLine;
                selectTxt += "   ,ACCDEP.CHECKDEPOSIT" + Environment.NewLine;
                selectTxt += "   ,ACCDEP.DRAFTDEPOSIT" + Environment.NewLine;
                selectTxt += "   ,ACCDEP.OFFSETDEPOSIT" + Environment.NewLine;
                selectTxt += "   ,ACCDEP.FUNDTRANSFERDEPOSIT" + Environment.NewLine;
                selectTxt += "   ,(ACCDEP.OTHSDEPOSIT" + Environment.NewLine;
                selectTxt += "    -ACCDEP.CASHDEPOSIT" + Environment.NewLine;
                selectTxt += "    -ACCDEP.TRFRDEPOSIT" + Environment.NewLine;
                selectTxt += "    -ACCDEP.CHECKDEPOSIT" + Environment.NewLine;
                selectTxt += "    -ACCDEP.DRAFTDEPOSIT" + Environment.NewLine;
                selectTxt += "    -ACCDEP.OFFSETDEPOSIT" + Environment.NewLine;
                selectTxt += "    -ACCDEP.FUNDTRANSFERDEPOSIT" + Environment.NewLine;
                selectTxt += "    ) AS OTHSDEPOSIT" + Environment.NewLine;
                selectTxt += "  FROM CUSTACCRECRF AS CSTRECSUB" + Environment.NewLine;
                
                //売掛入金集計データ
                selectTxt += "  LEFT JOIN" + Environment.NewLine;
                selectTxt += "  (" + Environment.NewLine;
                selectTxt += "   SELECT" + Environment.NewLine;
                selectTxt += "     ACCDEPSUB.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "    ,ACCDEPSUB.ADDUPSECCODERF" + Environment.NewLine;
                selectTxt += "    ,ACCDEPSUB.CLAIMCODERF" + Environment.NewLine;
                selectTxt += "    ,ACCDEPSUB.CUSTOMERCODERF" + Environment.NewLine;
                selectTxt += "    ,ACCDEPSUB.ADDUPDATERF" + Environment.NewLine;
                selectTxt += "    ,SUM((CASE WHEN ACCDEPSUB.MONEYKINDCODERF=51 THEN ACCDEPSUB.DEPOSITRF ELSE 0 END)) AS CASHDEPOSIT" + Environment.NewLine;
                selectTxt += "    ,SUM((CASE WHEN ACCDEPSUB.MONEYKINDCODERF=52 THEN ACCDEPSUB.DEPOSITRF ELSE 0 END)) AS TRFRDEPOSIT" + Environment.NewLine;
                selectTxt += "    ,SUM((CASE WHEN ACCDEPSUB.MONEYKINDCODERF=53 THEN ACCDEPSUB.DEPOSITRF ELSE 0 END)) AS CHECKDEPOSIT" + Environment.NewLine;
                selectTxt += "    ,SUM((CASE WHEN ACCDEPSUB.MONEYKINDCODERF=54 THEN ACCDEPSUB.DEPOSITRF ELSE 0 END)) AS DRAFTDEPOSIT" + Environment.NewLine;
                selectTxt += "    ,SUM((CASE WHEN ACCDEPSUB.MONEYKINDCODERF=56 THEN ACCDEPSUB.DEPOSITRF ELSE 0 END)) AS OFFSETDEPOSIT" + Environment.NewLine;
                selectTxt += "    ,SUM((CASE WHEN ACCDEPSUB.MONEYKINDCODERF=59 THEN ACCDEPSUB.DEPOSITRF ELSE 0 END)) AS FUNDTRANSFERDEPOSIT" + Environment.NewLine;
                selectTxt += "    ,SUM(ACCDEPSUB.DEPOSITRF) AS OTHSDEPOSIT" + Environment.NewLine;
                selectTxt += "   FROM ACCRECDEPOTOTALRF AS ACCDEPSUB" + Environment.NewLine;
                selectTxt += "   GROUP BY" + Environment.NewLine;
                selectTxt += "     ACCDEPSUB.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "    ,ACCDEPSUB.ADDUPSECCODERF" + Environment.NewLine;
                selectTxt += "    ,ACCDEPSUB.CLAIMCODERF" + Environment.NewLine;
                selectTxt += "    ,ACCDEPSUB.CUSTOMERCODERF" + Environment.NewLine;
                selectTxt += "    ,ACCDEPSUB.ADDUPDATERF" + Environment.NewLine;
                selectTxt += "  ) AS ACCDEP" + Environment.NewLine;
                selectTxt += "  ON  ACCDEP.ENTERPRISECODERF=CSTRECSUB.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "  AND ACCDEP.ADDUPSECCODERF=CSTRECSUB.ADDUPSECCODERF" + Environment.NewLine;
                selectTxt += "  AND ACCDEP.CLAIMCODERF=CSTRECSUB.CLAIMCODERF" + Environment.NewLine;
                selectTxt += "  AND ACCDEP.CUSTOMERCODERF=CSTRECSUB.CLAIMCODERF" + Environment.NewLine;
                selectTxt += "  AND ACCDEP.ADDUPDATERF=CSTRECSUB.ADDUPDATERF" + Environment.NewLine;

                //WHERE文の作成
                //selectTxt += MakeWhereString(ref sqlCommand, _extrInfo_BillBalanceWork, logicalMode);
                selectTxt += MakeWhereString(ref sqlCommand, _sumextrInfo_BillBalanceWork, customerListWork, logicalMode);
                #endregion  //[データ抽出メインQuery]

                selectTxt += " ) AS CSTREC" + Environment.NewLine;

                #region [JOIN]
                //得意先マスタ
                selectTxt += " LEFT JOIN CUSTOMERRF CSTMER" + Environment.NewLine;
                selectTxt += " ON  CSTMER.ENTERPRISECODERF=CSTREC.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND CSTMER.CUSTOMERCODERF=CSTREC.CLAIMCODERF" + Environment.NewLine;

                //従業員マスタ
                selectTxt += " LEFT JOIN EMPLOYEERF EMPLYE" + Environment.NewLine;
                selectTxt += " ON  EMPLYE.ENTERPRISECODERF=CSTMER.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += IFBy(_sumextrInfo_BillBalanceWork.EmployeeKindDiv == (int)EmployeeKindDiv.CustomerAgentCd,
                             " AND EMPLYE.EMPLOYEECODERF=CSTMER.CUSTOMERAGENTCDRF" + Environment.NewLine);
                selectTxt += IFBy(_sumextrInfo_BillBalanceWork.EmployeeKindDiv == (int)EmployeeKindDiv.BillCollecterCd,
                             " AND EMPLYE.EMPLOYEECODERF=CSTMER.BILLCOLLECTERCDRF" + Environment.NewLine);

                //ユーザーガイドマスタ(ボディ)(ユーザ変更分)
                selectTxt += " LEFT JOIN USERGDBDURF USGDBD" + Environment.NewLine;
                selectTxt += " ON  USGDBD.ENTERPRISECODERF=CSTMER.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND USGDBD.GUIDECODERF=CSTMER.SALESAREACODERF" + Environment.NewLine;
                selectTxt += " AND USGDBD.USERGUIDEDIVCDRF=21" + Environment.NewLine;
                
                //総括得意先マスタ
                selectTxt += " RIGHT JOIN SUMCUSTSTRF SUMCST" + Environment.NewLine;
                selectTxt += " ON  SUMCST.ENTERPRISECODERF = CSTREC.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND SUMCST.CUSTOMERCODERF = CSTREC.CLAIMCODERF" + Environment.NewLine;
                //selectTxt += " AND SUMCST.DEMANDADDUPSECCDRF= CSTREC.ADDUPSECCODERF" + Environment.NewLine;  //DEL 2010/06/06

                //得意先マスタ(総括得意先用)
                selectTxt += " LEFT JOIN CUSTOMERRF CUSTSU" + Environment.NewLine;
                selectTxt += " ON  CUSTSU.ENTERPRISECODERF = SUMCST.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND CUSTSU.CUSTOMERCODERF = SUMCST.SUMCLAIMCUSTCODERF" + Environment.NewLine;

                //拠点情報設定マスタ
                selectTxt += " LEFT JOIN SECINFOSETRF SCINST" + Environment.NewLine;
                selectTxt += " ON  SCINST.ENTERPRISECODERF=CSTREC.ENTERPRISECODERF" + Environment.NewLine;
                // -- UPD 2010/06/06 ------------------------------------>>>
                //selectTxt += " AND SCINST.SECTIONCODERF=CSTREC.ADDUPSECCODERF" + Environment.NewLine;
                selectTxt += " AND SCINST.SECTIONCODERF=SUMCST.DEMANDADDUPSECCDRF" + Environment.NewLine;
                // -- UPD 2010/06/06 ------------------------------------<<<

                #endregion  //[JOIN]

                #region [WHERE句]
                selectTxt += " WHERE" + Environment.NewLine;

                //企業コード
                selectTxt += " SUMCST.ENTERPRISECODERF=@CSTRECENTERPRISECODE" + Environment.NewLine;
                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@CSTRECENTERPRISECODE", SqlDbType.NChar);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(_sumextrInfo_BillBalanceWork.EnterpriseCode);

                //販売エリアコード
                if (_sumextrInfo_BillBalanceWork.St_SalesAreaCode != 0)
                {
                    selectTxt += " AND CSTMER.SALESAREACODERF>=@ST_SALESAREACODE" + Environment.NewLine;
                    SqlParameter paraSt_SalesAreaCode = sqlCommand.Parameters.Add("@ST_SALESAREACODE", SqlDbType.Int);
                    paraSt_SalesAreaCode.Value = SqlDataMediator.SqlSetInt32(_sumextrInfo_BillBalanceWork.St_SalesAreaCode);
                }

                // -- UPD 2010/06/06 ---------------------------------------->>>
                //if (_sumextrInfo_BillBalanceWork.Ed_SalesAreaCode != 99)
                if (_sumextrInfo_BillBalanceWork.Ed_SalesAreaCode != 9999)
                // -- UPD 2010/06/06 ----------------------------------------<<<
                {
                    selectTxt += " AND CSTMER.SALESAREACODERF<=@ED_SALESAREACODE" + Environment.NewLine;
                    SqlParameter paraEd_SalesAreaCode = sqlCommand.Parameters.Add("@ED_SALESAREACODE", SqlDbType.Int);
                    paraEd_SalesAreaCode.Value = SqlDataMediator.SqlSetInt32(_sumextrInfo_BillBalanceWork.Ed_SalesAreaCode);
                }

                //担当者コード
                if (_sumextrInfo_BillBalanceWork.St_EmployeeCode != "")
                {
                    if (_sumextrInfo_BillBalanceWork.EmployeeKindDiv == (int)EmployeeKindDiv.CustomerAgentCd)
                        selectTxt += " AND CSTMER.CUSTOMERAGENTCDRF>=@ST_AGENTCD" + Environment.NewLine;
                    else if (_sumextrInfo_BillBalanceWork.EmployeeKindDiv == (int)EmployeeKindDiv.BillCollecterCd)
                        selectTxt += " AND CSTMER.BILLCOLLECTERCDRF>=@ST_AGENTCD" + Environment.NewLine;
                    SqlParameter paraSt_EmployeeCode = sqlCommand.Parameters.Add("@ST_AGENTCD", SqlDbType.NChar);
                    paraSt_EmployeeCode.Value = SqlDataMediator.SqlSetString(_sumextrInfo_BillBalanceWork.St_EmployeeCode);
                }
                if (_sumextrInfo_BillBalanceWork.Ed_EmployeeCode != "")
                {
                    if (_sumextrInfo_BillBalanceWork.EmployeeKindDiv == (int)EmployeeKindDiv.CustomerAgentCd)
                        selectTxt += " AND ( CSTMER.CUSTOMERAGENTCDRF<=@ED_AGENTCD OR CSTMER.CUSTOMERAGENTCDRF IS NULL )" + Environment.NewLine;
                    else if (_sumextrInfo_BillBalanceWork.EmployeeKindDiv == (int)EmployeeKindDiv.BillCollecterCd)
                        selectTxt += " AND ( CSTMER.BILLCOLLECTERCDRF<=@ED_AGENTCD OR CSTMER.BILLCOLLECTERCDRF IS NULL )" + Environment.NewLine;
                    SqlParameter paraEd_EmployeeCode = sqlCommand.Parameters.Add("@ED_AGENTCD", SqlDbType.NChar);
                    paraEd_EmployeeCode.Value = SqlDataMediator.SqlSetString(_sumextrInfo_BillBalanceWork.Ed_EmployeeCode);
                }
                // DEL UI側で処理するように修正
                ////0:全て 1:0とﾌﾟﾗｽ 2:ﾌﾟﾗｽのみ 3:0のみ 4:ﾌﾟﾗｽとﾏｲﾅｽ 5:0とﾏｲﾅｽ 6:ﾏｲﾅｽのみ
                //switch (_extrInfo_BillBalanceWork.OutMoneyDiv)
                //{
                //    case 0:
                //        break;
                //    case 1:
                //        selectTxt += " AND CSTREC.AFCALTMONTHACCRECRF>=0" + Environment.NewLine;
                //        break;
                //    case 2:
                //        selectTxt += " AND CSTREC.AFCALTMONTHACCRECRF>0" + Environment.NewLine;
                //        break;
                //    case 3:
                //        selectTxt += " AND CSTREC.AFCALTMONTHACCRECRF=0" + Environment.NewLine;
                //        break;
                //    case 4:
                //        selectTxt += " AND CSTREC.AFCALTMONTHACCRECRF!=0" + Environment.NewLine;
                //        break;
                //    case 5:
                //        selectTxt += " AND CSTREC.AFCALTMONTHACCRECRF<=0" + Environment.NewLine;
                //        break;
                //    case 6:
                //        selectTxt += " AND CSTREC.AFCALTMONTHACCRECRF<0" + Environment.NewLine;
                //        break;
                //}

                // ADD 2009.02.10 >>>
                selectTxt += " AND (CSTREC.LASTTIMEACCRECRF!=0" + Environment.NewLine;
                selectTxt += "      OR CSTREC.THISTIMEFEEDMDNRMLRF!=0" + Environment.NewLine;
                selectTxt += "      OR CSTREC.THISTIMEDISDMDNRMLRF!=0" + Environment.NewLine;
                selectTxt += "      OR CSTREC.THISTIMEDMDNRMLRF!=0" + Environment.NewLine;
                selectTxt += "      OR CSTREC.OFSTHISTIMESALESRF!=0" + Environment.NewLine;
                selectTxt += "      OR CSTREC.OFSTHISSALESTAXRF!=0" + Environment.NewLine;
                selectTxt += "      OR CSTREC.SALESSLIPCOUNTRF!=0)" + Environment.NewLine;
                // ADD 2009.02.10 <<<
                #endregion  //[WHERE句]

                #region [ORDER BY]
                //出力順 0:得意先順 1:担当者順 2:地区順
                switch (_sumextrInfo_BillBalanceWork.SortOrderDiv)
                {
                    case 0:  //0:得意先順 -> 拠点－得意先順
                        selectTxt += " ORDER BY SUMCST.DEMANDADDUPSECCDRF, SUMCST.SUMCLAIMCUSTCODERF";
                        break;
                    case 1:  //1:担当者順 -> 拠点－担当者－得意先順
                        if (_sumextrInfo_BillBalanceWork.EmployeeKindDiv == (int)EmployeeKindDiv.CustomerAgentCd)
                            selectTxt += " ORDER BY SUMCST.DEMANDADDUPSECCDRF, CSTMER.CUSTOMERAGENTCDRF, SUMCST.SUMCLAIMCUSTCODERF";
                        else if (_sumextrInfo_BillBalanceWork.EmployeeKindDiv == (int)EmployeeKindDiv.BillCollecterCd)
                            selectTxt += " ORDER BY SUMCST.DEMANDADDUPSECCDRF, CSTMER.BILLCOLLECTERCDRF, SUMCST.SUMCLAIMCUSTCODERF";
                        break;
                    case 2:  //2:地区順 -> 拠点－地区－得意先順
                        selectTxt += " ORDER BY SUMCST.DEMANDADDUPSECCDRF, CSTMER.SALESAREACODERF, SUMCST.SUMCLAIMCUSTCODERF";
                        break;
                }
                #endregion  //[ORDER BY]

                #endregion  //[Select文作成]

                sqlCommand.CommandText = selectTxt;

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    al.Add(CopyToRsltWork(ref myReader, _sumextrInfo_BillBalanceWork));
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
                base.WriteErrorLog(ex, "BillBalanceTableDB.SearchBillBalanceTableProc Exception=" + ex.Message);
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
        #endregion  //[SearchBillBalanceTableProc]

        #region [WHERE句生成処理]
        /// <summary>
        /// WHERE句生成処理
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="_extrInfo_BillBalanceWork">検索条件格納クラス</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns></returns>
        /// <br>Note       : WHERE句生成処理</br>
        /// <br>Programmer : 23015 森本 大輝</br>
        /// <br>Date       : 2008.09.22</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, SumExtrInfo_BillBalanceWork _sumextrInfo_BillBalanceWork, SumRsltInfo_BillBalanceWork customerListWork, ConstantManagement.LogicalMode logicalMode)
        {
            #region WHERE文作成
            string retstring = "";
            retstring += " WHERE" + Environment.NewLine;

            //企業コード
            retstring += " CSTRECSUB.ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(_sumextrInfo_BillBalanceWork.EnterpriseCode);

            //論理削除区分
            if ((logicalMode == ConstantManagement.LogicalMode.GetData0) || (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData2) || (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                retstring += " AND CSTRECSUB.LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + Environment.NewLine;
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
            }
            else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) || (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                retstring += " AND CSTRECSUB.LOGICALDELETECODERF<@FINDLOGICALDELETECODE" + Environment.NewLine;
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                if (logicalMode == ConstantManagement.LogicalMode.GetData01) paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
                else paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
            }

            //親レコードのみを対象とする(得意先コード=0のみ対象)
            retstring += " AND CSTRECSUB.CUSTOMERCODERF=0" + Environment.NewLine;
            // 修正 2009.01.27 >>>
            ////拠点コード
            //if (_extrInfo_BillBalanceWork.SectionCodes != null)
            //{
            //    string sectionCodestr = "";
            //    foreach (string seccdstr in _extrInfo_BillBalanceWork.SectionCodes)
            //    {
            //        if (sectionCodestr != "")
            //        {
            //            sectionCodestr += ",";
            //        }
            //        sectionCodestr += "'" + seccdstr + "'";
            //    }
            //    if (sectionCodestr != "")
            //    {
            //        retstring += " AND CSTRECSUB.ADDUPSECCODERF IN (" + sectionCodestr + ") ";
            //    }
            //    retstring += Environment.NewLine;
            //}

            // -- UPD 2010/06/06 ----------------------------------->>>
            //請求得意先の売掛抽出時に画面の拠点コードを条件にしない

            //if (customerListWork.AddUpSecCode != null)
            //{
            //    retstring += " AND CSTRECSUB.ADDUPSECCODERF=@ADDUPSECCODE" + Environment.NewLine;
            //    SqlParameter paraAddupsecCode = sqlCommand.Parameters.Add("@ADDUPSECCODE", SqlDbType.NChar);
            //    paraAddupsecCode.Value = SqlDataMediator.SqlSetString(customerListWork.AddUpSecCode);

            //}
            // -- UPD 2010/06/06 -----------------------------------<<<

            // 修正 2009.01.27 <<<
            //対象年月
            if (_sumextrInfo_BillBalanceWork.AddUpYearMonth != DateTime.MinValue)
            {
                retstring += " AND CSTRECSUB.ADDUPYEARMONTHRF=@ADDUPYEARMONTH" + Environment.NewLine;
                SqlParameter paraSt_AddUpYearMonth = sqlCommand.Parameters.Add("@ADDUPYEARMONTH", SqlDbType.Int);
                paraSt_AddUpYearMonth.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(_sumextrInfo_BillBalanceWork.AddUpYearMonth);
            }

            //請求先コード
            //if (_extrInfo_BillBalanceWork.St_ClaimCode != 0)
            //{
            //    retstring += " AND CSTRECSUB.CLAIMCODERF>=@ST_CLAIMCODE" + Environment.NewLine;
            //    SqlParameter paraSt_ClaimCode = sqlCommand.Parameters.Add("@ST_CLAIMCODE", SqlDbType.Int);
            //    paraSt_ClaimCode.Value = SqlDataMediator.SqlSetInt32(_extrInfo_BillBalanceWork.St_ClaimCode);
            //}
            //if (_extrInfo_BillBalanceWork.Ed_ClaimCode != 999999999)
            //{
            //    retstring += " AND CSTRECSUB.CLAIMCODERF<=@ED_CLAIMCODE" + Environment.NewLine;
            //    SqlParameter paraEd_ClaimCode = sqlCommand.Parameters.Add("@ED_CLAIMCODE", SqlDbType.Int);
            //    paraEd_ClaimCode.Value = SqlDataMediator.SqlSetInt32(_extrInfo_BillBalanceWork.Ed_ClaimCode);
            //}
            if (customerListWork.ClaimCode != 0)
            {
                retstring += " AND CSTRECSUB.CLAIMCODERF=@CLAIMCODE" + Environment.NewLine;
                SqlParameter paraClaimCode = sqlCommand.Parameters.Add("@CLAIMCODE", SqlDbType.Int);
                paraClaimCode.Value = SqlDataMediator.SqlSetInt32(customerListWork.CustomerCode);
            }
            #endregion  //WHERE文作成

            return retstring.ToString();
        }
        #endregion  //[WHERE句生成処理]

        #region [売掛残高一覧表抽出結果クラス格納処理]
        /// <summary>
        /// 売掛残高一覧表抽出結果クラス格納処理 Reader → RsltInfo_BillBalanceWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="extrInfo_BillBalanceWork">extrInfo_BillBalanceWork</param>
        /// <returns>RsltInfo_BillBalanceWork</returns>
        /// <remarks>
        /// <br>Programmer : 23015 森本 大輝</br>
        /// <br>Date       : 2008.09.22</br>
        /// </remarks>
        private SumRsltInfo_BillBalanceWork CopyToRsltWork(ref SqlDataReader myReader, SumExtrInfo_BillBalanceWork _sumextrInfo_BillBalanceWork)
        {
            SumRsltInfo_BillBalanceWork ResultWork = new SumRsltInfo_BillBalanceWork();

            #region [抽出結果-値セット]
            ResultWork.AddUpSecCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DEMANDADDUPSECCDRF"));
            ResultWork.SectionGuideSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDESNMRF"));
            ResultWork.ClaimCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUMCLAIMCUSTCODERF"));
            ResultWork.ClaimSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERSNMRF"));
            ResultWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CLAIMCODERF"));
            ResultWork.Customersnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CLAIMSNMRF"));
            ResultWork.LastTimeAccRec = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("LASTTIMEACCRECRF"));
            ResultWork.ThisTimeDmdNrml = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISTIMEDMDNRMLRF"));
            ResultWork.ThisTimeTtlBlcAcc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISTIMETTLBLCACCRF"));
            ResultWork.OfsThisTimeSales = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("OFSTHISTIMESALESRF"));
            ResultWork.ThisTimeSales = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISTIMESALESRF"));
            ResultWork.ThisRgdsDisPric = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISRGDSDISPRIC"));
            ResultWork.OfsThisSalesTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("OFSTHISSALESTAXRF"));
            ResultWork.AfCalTMonthAccRec = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("AFCALTMONTHACCRECRF"));
            ResultWork.SalesSlipCount = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESSLIPCOUNTRF"));
            ResultWork.AgentCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("AGENTCD"));
            ResultWork.Name = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NAMERF"));
            ResultWork.SalesAreaCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESAREACODERF"));
            ResultWork.SalesAreaName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESAREANAME"));
            ResultWork.ThisTimeFeeDmdNrml = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISTIMEFEEDMDNRMLRF"));
            ResultWork.ThisTimeDisDmdNrml = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISTIMEDISDMDNRMLRF"));


            if (_sumextrInfo_BillBalanceWork.DepoDtlDiv == (int)DepoDtlDiv.DepoDtlON)
            {
                ResultWork.CashDeposit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("CASHDEPOSIT"));
                ResultWork.TrfrDeposit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TRFRDEPOSIT"));
                ResultWork.CheckDeposit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("CHECKDEPOSIT"));
                ResultWork.DraftDeposit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DRAFTDEPOSIT"));
                ResultWork.OffsetDeposit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("OFFSETDEPOSIT"));
                ResultWork.FundTransferDeposit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("FUNDTRANSFERDEPOSIT"));
                ResultWork.OthsDeposit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("OTHSDEPOSIT"));
            }
            #endregion  //[抽出結果-値セット]

            return ResultWork;
        }
        #endregion  //[売掛残高一覧表抽出結果クラス格納処理]

        #region [コネクション生成処理]
        /// <summary>
        /// SqlConnection生成処理
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Programmer : 980081 山田 明友</br>
        /// <br>Date       : 2007.11.15</br>
        /// </remarks>
        private SqlConnection CreateSqlConnection()
        {
            SqlConnection retSqlConnection = null;

            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
            string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
            if (connectionText == null || connectionText == "") return null;

            retSqlConnection = new SqlConnection(connectionText);

            return retSqlConnection;
        }
        #endregion  //[コネクション生成処理]

        // --- ADD START 3H 劉星光 2020/04/10 ---------->>>>>
        #region [SearchCustAccRecDate]
        /// <summary>
        /// 計上年月日取得
        /// </summary>
        /// <param name="extrInfo_BillBalanceWork">売掛残高一覧表抽出条件</param>
        /// <param name="custAccRecDateDic">請求先毎の月次更新処理日ディクショナリ</param>
        /// <param name="sqlConnection">コネクション情報</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 11570208-00 軽減税率対応</br>
        /// <br>Programmer : 3H 劉星光</br>
        /// <br>Date       : 2020/04/10</br>
        /// </remarks>
        private int SearchCustAccRecDate(SumExtrInfo_BillBalanceWork extrInfo_BillBalanceWork, ref Dictionary<int, CustAccRecDateInfo> custAccRecDateDic, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;

            try
            {
                string sqlText = string.Empty;

                using (SqlCommand sqlCommand = new SqlCommand(sqlText, sqlConnection))
                {
                    sqlText += "SELECT" + Environment.NewLine;
                    sqlText += "  CLAIMCODERF," + Environment.NewLine;
                    sqlText += "  ADDUPDATERF," + Environment.NewLine;
                    sqlText += "  LAMONCADDUPUPDDATERF" + Environment.NewLine;
                    sqlText += " FROM CUSTACCRECRF AS ACCREC WITH (READUNCOMMITTED)" + Environment.NewLine;
                    sqlText += " RIGHT JOIN SUMCUSTSTRF SUMCST" + Environment.NewLine;
                    sqlText += " ON  SUMCST.ENTERPRISECODERF = ACCREC.ENTERPRISECODERF" + Environment.NewLine;
                    sqlText += " AND SUMCST.CUSTOMERCODERF = ACCREC.CLAIMCODERF" + Environment.NewLine;
                    sqlText += " WHERE ACCREC.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    sqlText += "    AND ACCREC.ADDUPYEARMONTHRF=@FINDADDUPYEARMONTH" + Environment.NewLine;
                    sqlText += "    AND ACCREC.CUSTOMERCODERF=0" + Environment.NewLine;
                    // 請求先コード(開始)
                    if (extrInfo_BillBalanceWork.St_ClaimCode != 0)
                    {
                        sqlText += " AND SUMCST.SUMCLAIMCUSTCODERF>=@ST_CUSTOMERCOD" + Environment.NewLine;
                        SqlParameter paraSt_CustomerCode = sqlCommand.Parameters.Add("@ST_CUSTOMERCOD", SqlDbType.Int);
                        paraSt_CustomerCode.Value = SqlDataMediator.SqlSetInt32(extrInfo_BillBalanceWork.St_ClaimCode);
                    }
                    // 請求先コード(終了)
                    if (extrInfo_BillBalanceWork.Ed_ClaimCode != 999999999)
                    {
                        sqlText += " AND SUMCST.SUMCLAIMCUSTCODERF<=@ED_CUSTOMERCOD" + Environment.NewLine;
                        SqlParameter paraEd_CustomerCode = sqlCommand.Parameters.Add("@ED_CUSTOMERCOD", SqlDbType.Int);
                        paraEd_CustomerCode.Value = SqlDataMediator.SqlSetInt32(extrInfo_BillBalanceWork.Ed_ClaimCode);
                    }
                    sqlText += " ORDER BY CLAIMCODERF" + Environment.NewLine;

                    // Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaAddUpYearMonth = sqlCommand.Parameters.Add("@FINDADDUPYEARMONTH", SqlDbType.Int);

                    // Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(extrInfo_BillBalanceWork.EnterpriseCode);
                    findParaAddUpYearMonth.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(extrInfo_BillBalanceWork.AddUpYearMonth);

                    sqlCommand.CommandText = sqlText;
                    myReader = sqlCommand.ExecuteReader();
                    int claimCd;

                    while (myReader.Read())
                    {
                        CustAccRecDateInfo custAccRecDateInfo = new CustAccRecDateInfo();
                        // 請求先コード
                        claimCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CLAIMCODERF"));
                        // 前回月次更新年月日
                        custAccRecDateInfo.LaMonCAddUpUpdDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LAMONCADDUPUPDDATERF"));
                        // 今回月次更新年月日
                        custAccRecDateInfo.AddUpDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ADDUPDATERF"));
                        
                        if (!custAccRecDateDic.ContainsKey(claimCd))
                        {
                            custAccRecDateDic.Add(claimCd, custAccRecDateInfo);
                        }

                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
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
                base.WriteErrorLog(ex, "BillBalanceTableDB.SearchCustAccRecDate Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                myReader.Dispose();
            }

            return status;
        }
        #endregion

        #region [SearchSalesProc]
        /// <summary>
        /// 売上データを取得します。
        /// </summary>
        /// <param name="billBalanceWork">検索結果</param>
        /// <param name="sqlConnection">コネクション情報</param>
        /// <param name="extrInfo_BillBalanceWork">売掛残高一覧表(総括)抽出条件</param>
        /// <param name="isCheckOut">締次フラッグ</param>
        /// <param name="laMonCAddUpUpdDate">前回月次更新年月日</param>
        /// <param name="custAccRecDateDic">請求先毎の月次更新処理日ディクショナリ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 11570208-00 軽減税率対応</br>
        /// <br>Programmer : 3H 劉星光</br>
        /// <br>Date       : 2020/04/10</br>
        private int SearchSalesProc(ref SumRsltInfo_BillBalanceWork billBalanceWork, ref SqlConnection sqlConnection, SumExtrInfo_BillBalanceWork extrInfo_BillBalanceWork, bool isCheckOut, DateTime laMonCAddUpUpdDate, Dictionary<int, CustAccRecDateInfo> custAccRecDateDic)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            SqlDataReader myReader = null;

            CustAccRecWork custAccRecWork = new CustAccRecWork();

            // 企業コード
            string enterpriseCode = extrInfo_BillBalanceWork.EnterpriseCode;

            // 税率1
            double taxRate1 = extrInfo_BillBalanceWork.TaxRate1;

            // 税率2
            double taxRate2 = extrInfo_BillBalanceWork.TaxRate2;

            // 計上年月日
            int addUpDate = Convert.ToInt32(extrInfo_BillBalanceWork.AddUpDate.ToString("yyyyMMdd"));

            // 前回月次更新年月日
            int laMonCAddUpDate = 0;

            // 期首年月日取得フラグ
            bool getFirstDateFlag = false;

            // 自社情報.期首年月日
            int per2yearAddUpdate = 0;

            // 消費税転嫁方式リスト
            List<int> consTaxLayMethodList = new List<int>();

            #region 自社情報.期首年月日取得
            // 自社情報取得
            CompanyInfWork paraCompanyInfWork = new CompanyInfWork();
            CompanyInfDB companyInfDB = new CompanyInfDB();
            ArrayList arrayList = new ArrayList();

            paraCompanyInfWork.EnterpriseCode = enterpriseCode;

            status = companyInfDB.Search(out arrayList, paraCompanyInfWork, ref sqlConnection);

            if ((status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND) ||
                (status == (int)ConstantManagement.DB_Status.ctDB_EOF))
            {
                //該当データなし statusをクリアし次へ
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            else if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                throw new Exception("自社情報取得失敗。");
            }

            paraCompanyInfWork = (CompanyInfWork)arrayList[0];

            // 自社情報.期首年月日の1年前の日の設定
            if (paraCompanyInfWork.CompanyBiginDate != 0)
            {
                DateTime dt = DateTime.ParseExact(paraCompanyInfWork.CompanyBiginDate.ToString(), "yyyyMMdd", null);
                DateTime dt1YearBefore = dt.AddYears(-1);
                DateTime dt1DayBefore = dt1YearBefore.AddDays(-1);
                getFirstDateFlag = Int32.TryParse(dt1DayBefore.ToString("yyyyMMdd"), out per2yearAddUpdate);
            }
            #endregion

            string sqlText = string.Empty;

            // 月次更新を行った場合
            if (isCheckOut)
            {
                if (custAccRecDateDic.ContainsKey(billBalanceWork.CustomerCode))
                {
                    laMonCAddUpDate = custAccRecDateDic[billBalanceWork.CustomerCode].LaMonCAddUpUpdDate;
                    addUpDate = custAccRecDateDic[billBalanceWork.CustomerCode].AddUpDate;
                }
            }
            // 月次更新を行わない場合
            else
            {
                laMonCAddUpDate = Convert.ToInt32(laMonCAddUpUpdDate.ToString("yyyyMMdd"));
            }

            try
            {
                status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

                using (SqlCommand sqlCommand = new SqlCommand())
                {
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandTimeout = _timeOut;
                    #region ■ 集計レコード集計処理
                    sqlText = string.Empty;
                    #region SELECT文作成
                    #region SELECT
                    sqlText += "SELECT" + Environment.NewLine;
                    sqlText += "ACCREC.FRACTIONPROCCDRF,--端数処理区分" + Environment.NewLine;
                    sqlText += "ACCREC.FRACTIONPROCUNITRF,--端数処理単位" + Environment.NewLine;
                    sqlText += "ACCREC.SALESNETPRICERF + ACCREC.RETSALESNETPRICERF + ACCREC.SALESDISTTLTAXEXCRF AS OFSTHISTIMESALESRF,    -- 相殺後今回売上金額" + Environment.NewLine;
                    sqlText += "-- ■ ■ 売上" + Environment.NewLine;
                    sqlText += "ACCREC.SALESNETPRICERF AS THISTIMESALESRF," + Environment.NewLine;
                    sqlText += "-- ■ ■ 返品" + Environment.NewLine;
                    sqlText += "ACCREC.RETSALESNETPRICERF AS THISSALESPRICRGDSRF," + Environment.NewLine;
                    sqlText += "-- ■ ■ 値引" + Environment.NewLine;
                    sqlText += "ACCREC.SALESDISTTLTAXEXCRF AS THISSALESPRICDISRF," + Environment.NewLine;
                    sqlText += "ACCREC.SALESSLIPCOUNT AS SALESSLIPCOUNTRF,             --売上伝票枚数" + Environment.NewLine;
                    sqlText += "ACCREC.SALESCNSTAXFRCPROCCDRF AS FRACTIONPROCCDRF,     --端数処理区分" + Environment.NewLine;
                    sqlText += "ACCREC.SLIPSALESPRICECONSTAX AS SLIPSALESPRICECONSTAX, --伝票転嫁消費税額" + Environment.NewLine;
                    sqlText += "ACCREC.DTLSALESPRICECONSTAX AS DTLSALESPRICECONSTAX,   --明細転嫁消費税額" + Environment.NewLine;
                    sqlText += "ACCREC.CONSTAXLAYMETHODRF," + Environment.NewLine;
                    //--- DEL 2022/10/13 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） --->>>>>
                    //sqlText += "ACCREC.CONSTAXRATERF" + Environment.NewLine;
                    //--- DEL 2022/10/13 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） ---<<<<<
                    //--- ADD 2022/10/13 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） --->>>>>
                    sqlText += "ACCREC.CONSTAXRATERF," + Environment.NewLine;
                    sqlText += "ACCREC.TAXATIONDIVCDRF --課税区分" + Environment.NewLine;
                    //--- ADD 2022/10/13 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） ---<<<<<
                    sqlText += "FROM" + Environment.NewLine;
                    sqlText += "(" + Environment.NewLine;
                    #endregion

                    #region SUBクエリ
                    sqlText += "  SELECT" + Environment.NewLine;
                    sqlText += "   CLAIM.SALESCNSTAXFRCPROCCDRF AS SALESCNSTAXFRCPROCCDRF," + Environment.NewLine;
                    sqlText += "   SALESPROC.FRACTIONPROCCDRF," + Environment.NewLine;
                    sqlText += "   SALESPROC.FRACTIONPROCUNITRF," + Environment.NewLine;
                    sqlText += "   COUNT(SALE.SALESSLIPNUMRF) SALESSLIPCOUNT," + Environment.NewLine;
                    sqlText += "   -- ■ ■ 売上" + Environment.NewLine;
                    sqlText += "   SUM((CASE WHEN SALE.SALESSLIPCDRF =0 THEN SALE.SALESNETPRICERF ELSE 0 END)) AS SALESNETPRICERF," + Environment.NewLine;
                    sqlText += "   -- ■ ■ 返品" + Environment.NewLine;
                    sqlText += "   SUM((CASE WHEN SALE.SALESSLIPCDRF =1 THEN SALE.SALESNETPRICERF ELSE 0 END)) AS RETSALESNETPRICERF,              --返品正価金額" + Environment.NewLine;
                    sqlText += "   -- ■ ■ 値引" + Environment.NewLine;
                    sqlText += "   SUM(SALE.SALESDISTTLTAXEXCRF) AS SALESDISTTLTAXEXCRF,      --値引金額計（税抜き）" + Environment.NewLine;
                    sqlText += "   SUM(SALE.SLIPSALESPRICECONSTAX) AS SLIPSALESPRICECONSTAX,  --伝票転嫁消費税額" + Environment.NewLine;
                    sqlText += "   SUM(SALE.DTLSALESPRICECONSTAX) AS DTLSALESPRICECONSTAX,    --明細転嫁消費税額" + Environment.NewLine;
                    sqlText += "   SALE.CONSTAXLAYMETHODRF," + Environment.NewLine;
                    //--- DEL 2022/10/13 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） --->>>>>
                    // sqlText += "   SALE.CONSTAXRATERF" + Environment.NewLine;
                    //--- DEL 2022/10/13 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） ---<<<<<
                    //--- ADD 2022/10/13 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） --->>>>>
                    sqlText += "   SALE.CONSTAXRATERF," + Environment.NewLine;
                    sqlText += "   SALE.TAXATIONDIVCDRF --課税区分" + Environment.NewLine;
                    //--- ADD 2022/10/13 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） ---<<<<<
                    sqlText += "  FROM" + Environment.NewLine;
                    sqlText += "  (" + Environment.NewLine;
                    sqlText += "     SELECT" + Environment.NewLine;
                    sqlText += "      SUBSALE.ENTERPRISECODERF," + Environment.NewLine;
                    sqlText += "      (CASE WHEN (SEARCHCUST.CLAIMCODERF IS NOT NULL) THEN SEARCHCUST.CLAIMCODERF ELSE SUBSALE.CLAIMCODERF END) AS CLAIMCODERF," + Environment.NewLine;
                    sqlText += "      SUBSALE.CUSTOMERCODERF," + Environment.NewLine;
                    sqlText += "      SUBSALE.ADDUPADATERF," + Environment.NewLine;
                    sqlText += "      SUBSALE.LOGICALDELETECODERF," + Environment.NewLine;
                    sqlText += "      SUBSALE.CONSTAXLAYMETHODRF," + Environment.NewLine;
                    sqlText += "      SUBSALE.ACPTANODRSTATUSRF," + Environment.NewLine;
                    sqlText += "      SUBSALE.DEBITNOTEDIVRF," + Environment.NewLine;
                    sqlText += "      SUBSALE.SALESSLIPCDRF," + Environment.NewLine;
                    sqlText += "      SUBSALE.SALESSLIPNUMRF," + Environment.NewLine;
                    sqlText += "      SUBSALE.RESULTSADDUPSECCDRF," + Environment.NewLine;
                    sqlText += "      SUBSALE.DEMANDADDUPSECCDRF," + Environment.NewLine;
                    //--- DEL 2022/10/13 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） --->>>>>
                    //sqlText += "      SUBSALE.SALESNETPRICERF + SALESDTL.DISSALESTAXEXCGYO AS SALESNETPRICERF," + Environment.NewLine;
                    //sqlText += "      SUBSALE.SALESDISTTLTAXEXCRF -  SALESDTL.DISSALESTAXEXCGYO AS SALESDISTTLTAXEXCRF," + Environment.NewLine;
                    //sqlText += "      (CASE WHEN (SUBSALE.CONSTAXLAYMETHODRF =0 ) THEN (SUBSALE.SALESTOTALTAXINCRF - SUBSALE.SALESTOTALTAXEXCRF) ELSE 0 END) AS SLIPSALESPRICECONSTAX," + Environment.NewLine;
                    //--- DEL 2022/10/13 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） ---<<<<<
                    //--- ADD 2022/10/13 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） --->>>>>
                    sqlText += "      (CASE WHEN (SALESDTL.SALESSLIPCDRF =0) THEN SALESDTL.SALESMONEY + SALESDTL.DISSALESTAXEXCGYO WHEN (SALESDTL.SALESSLIPCDRF =1) THEN SALESDTL.RETSALESMONEY + SALESDTL.DISSALESTAXEXCGYO ELSE 0 END) AS SALESNETPRICERF," + Environment.NewLine;
                    sqlText += "      SALESDTL.DISGOODSSTAXEXCGYO AS SALESDISTTLTAXEXCRF," + Environment.NewLine;
                    sqlText += "      SALESDTL.TAXATIONDIVCDRF AS TAXATIONDIVCDRF, --課税区分" + Environment.NewLine;
                    sqlText += "      (CASE WHEN (SUBSALE.CONSTAXLAYMETHODRF =0 AND SALESDTL.TAXATIONDIVCDRF = 0) THEN (SUBSALE.SALESTOTALTAXINCRF - SUBSALE.SALESTOTALTAXEXCRF) ELSE 0 END) AS SLIPSALESPRICECONSTAX," + Environment.NewLine;
                    //--- ADD 2022/10/13 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） ---<<<<<
                    sqlText += "      (CASE WHEN (SUBSALE.CONSTAXLAYMETHODRF =1 ) THEN DTLSALESPRICECONSTAX ELSE 0 END) AS DTLSALESPRICECONSTAX," + Environment.NewLine;
                    sqlText += "      SUBSALE.CONSTAXRATERF" + Environment.NewLine;
                    sqlText += "     FROM" + Environment.NewLine;
                    sqlText += "      SALESSLIPRF AS SUBSALE WITH(READUNCOMMITTED)" + Environment.NewLine;
                    sqlText += "    LEFT JOIN CUSTOMERRF AS SEARCHCUST WITH (READUNCOMMITTED)" + Environment.NewLine;
                    sqlText += "     ON  SUBSALE.ENTERPRISECODERF = SEARCHCUST.ENTERPRISECODERF " + Environment.NewLine;
                    sqlText += "     AND SUBSALE.CUSTOMERCODERF = SEARCHCUST.CUSTOMERCODERF " + Environment.NewLine;
                    sqlText += "    LEFT JOIN" + Environment.NewLine;
                    sqlText += "    (" + Environment.NewLine;
                    sqlText += "      SELECT" + Environment.NewLine;
                    sqlText += "       SALES.ENTERPRISECODERF," + Environment.NewLine;
                    sqlText += "       SALES.ACPTANODRSTATUSRF," + Environment.NewLine;
                    sqlText += "       SALES.SALESSLIPNUMRF," + Environment.NewLine;
                    sqlText += "       SALES.SALESSLIPCDRF," + Environment.NewLine;
                    //--- ADD 2022/10/13 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） --->>>>>
                    sqlText += "       DTL.TAXATIONDIVCDRF,--課税区分" + Environment.NewLine;
                    //--- ADD 2022/10/13 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） ---<<<<<
                    sqlText += "       --明細転嫁消費税額" + Environment.NewLine;
                    sqlText += "       SUM(DTL.SALESPRICECONSTAXRF) AS DTLSALESPRICECONSTAX,-- 明細転嫁消費税額" + Environment.NewLine;
                    sqlText += "       --行値引" + Environment.NewLine;

                    //--- DEL 2022/10/13 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） --->>>>>
                    //sqlText += "       SUM(CASE WHEN (DTL.SALESSLIPCDDTLRF = 2 AND DTL.SHIPMENTCNTRF =0 ) THEN DTL.SALESMONEYTAXEXCRF ELSE 0 END) AS DISSALESTAXEXCGYO-- 税抜値引金額(行値引)" + Environment.NewLine;
                    //--- DEL 2022/10/13 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） ---<<<<<
                    //--- ADD 2022/10/13 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） --->>>>>
                    sqlText += "       SUM(CASE WHEN (DTL.SALESSLIPCDDTLRF = 2 AND DTL.SHIPMENTCNTRF =0 ) THEN DTL.SALESMONEYTAXEXCRF ELSE 0 END) AS DISSALESTAXEXCGYO,-- 税抜値引金額(行値引)" + Environment.NewLine;
                    sqlText += "       --商品値引金額" + Environment.NewLine;
                    sqlText += "       SUM(CASE WHEN (DTL.SALESSLIPCDDTLRF = 2 AND DTL.SHIPMENTCNTRF <>0 ) THEN DTL.SALESMONEYTAXEXCRF ELSE 0 END) AS DISGOODSSTAXEXCGYO,-- 税抜値引金額(商品値引)" + Environment.NewLine;
                    sqlText += "       --売上金額" + Environment.NewLine;
                    sqlText += "       SUM(CASE WHEN (DTL.SALESSLIPCDDTLRF = 0 ) THEN DTL.SALESMONEYTAXEXCRF ELSE 0 END) AS SALESMONEY,-- 売上金額" + Environment.NewLine;
                    sqlText += "       --返品金額" + Environment.NewLine;
                    sqlText += "       SUM(CASE WHEN (DTL.SALESSLIPCDDTLRF = 1 ) THEN DTL.SALESMONEYTAXEXCRF ELSE 0 END) AS RETSALESMONEY-- 返品金額" + Environment.NewLine;
                    //--- ADD 2022/10/13 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） ---<<<<<
                    sqlText += "      FROM" + Environment.NewLine;
                    sqlText += "       SALESDETAILRF AS DTL WITH (READUNCOMMITTED)" + Environment.NewLine;
                    sqlText += "      LEFT JOIN SALESSLIPRF AS SALES WITH (READUNCOMMITTED)" + Environment.NewLine;
                    sqlText += "       ON  SALES.ENTERPRISECODERF = DTL.ENTERPRISECODERF" + Environment.NewLine;
                    sqlText += "       AND SALES.ACPTANODRSTATUSRF = DTL.ACPTANODRSTATUSRF" + Environment.NewLine;
                    sqlText += "       AND SALES.SALESSLIPNUMRF = DTL.SALESSLIPNUMRF" + Environment.NewLine;
                    sqlText += "      GROUP BY" + Environment.NewLine;
                    sqlText += "       SALES.ENTERPRISECODERF," + Environment.NewLine;
                    sqlText += "       SALES.ACPTANODRSTATUSRF," + Environment.NewLine;
                    sqlText += "       SALES.SALESSLIPNUMRF," + Environment.NewLine;

                    //--- DEL 2022/10/13 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） --->>>>>
                    // sqlText += "       SALES.SALESSLIPCDRF" + Environment.NewLine;
                    //--- DEL 2022/10/13 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） ---<<<<<
                    //--- ADD 2022/10/13 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） --->>>>>
                    sqlText += "       SALES.SALESSLIPCDRF," + Environment.NewLine;
                    sqlText += "       DTL.TAXATIONDIVCDRF --課税区分" + Environment.NewLine;
                    //--- ADD 2022/10/13 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） ---<<<<<
                    sqlText += "    ) AS SALESDTL" + Environment.NewLine;
                    sqlText += "     ON  SUBSALE.ENTERPRISECODERF = SALESDTL.ENTERPRISECODERF" + Environment.NewLine;
                    sqlText += "     AND SUBSALE.ACPTANODRSTATUSRF = SALESDTL.ACPTANODRSTATUSRF" + Environment.NewLine;
                    sqlText += "     AND SUBSALE.SALESSLIPNUMRF = SALESDTL.SALESSLIPNUMRF" + Environment.NewLine;
                    sqlText += "  ) AS SALE" + Environment.NewLine;
                    #endregion

                    #region JOIN句
                    sqlText += "LEFT JOIN CUSTOMERRF AS CUST WITH(READUNCOMMITTED)" + Environment.NewLine;
                    sqlText += " ON SALE.ENTERPRISECODERF = CUST.ENTERPRISECODERF" + Environment.NewLine;
                    sqlText += " AND SALE.CUSTOMERCODERF = CUST.CUSTOMERCODERF" + Environment.NewLine;
                    sqlText += "LEFT JOIN CUSTOMERRF AS CLAIM WITH(READUNCOMMITTED)" + Environment.NewLine;
                    sqlText += " ON SALE.ENTERPRISECODERF = CLAIM.ENTERPRISECODERF" + Environment.NewLine;
                    sqlText += " AND SALE.CLAIMCODERF = CLAIM.CUSTOMERCODERF" + Environment.NewLine;
                    sqlText += "LEFT JOIN SALESPROCMONEYRF AS SALESPROC WITH(READUNCOMMITTED)" + Environment.NewLine;
                    sqlText += " ON  CLAIM.ENTERPRISECODERF=SALESPROC.ENTERPRISECODERF" + Environment.NewLine;
                    sqlText += " AND SALESPROC.FRACPROCMONEYDIVRF=1" + Environment.NewLine;
                    sqlText += " AND CLAIM.SALESCNSTAXFRCPROCCDRF=SALESPROC.FRACTIONPROCCODERF" + Environment.NewLine;
                    sqlText += "LEFT JOIN SUMCUSTSTRF AS SUMCST" + Environment.NewLine;
                    sqlText += " ON  SUMCST.ENTERPRISECODERF = SALE.ENTERPRISECODERF" + Environment.NewLine;
                    sqlText += " AND SUMCST.CUSTOMERCODERF = SALE.CLAIMCODERF" + Environment.NewLine;
                    sqlText += "LEFT JOIN CUSTOMERRF AS CUSTSU" + Environment.NewLine;
                    sqlText += " ON  CUSTSU.ENTERPRISECODERF = SUMCST.ENTERPRISECODERF" + Environment.NewLine;
                    sqlText += " AND CUSTSU.CUSTOMERCODERF = SUMCST.SUMCLAIMCUSTCODERF" + Environment.NewLine;
                    #endregion

                    #region WHERE句
                    sqlText += "WHERE SALE.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    sqlText += "   AND SALE.CLAIMCODERF=@FINDCUSTOMERCODE" + Environment.NewLine;
                    sqlText += "   AND(SALE.ADDUPADATERF<=@FINDADDUPDATE AND SALE.ADDUPADATERF>@FINDLASTTIMEADDUPDATE)" + Environment.NewLine;
                    sqlText += "   AND SALE.LOGICALDELETECODERF=0" + Environment.NewLine;
                    sqlText += "   AND SALE.ACPTANODRSTATUSRF=30" + Environment.NewLine;
                    sqlText += "   AND SALE.DEBITNOTEDIVRF=0" + Environment.NewLine;

                    #region 販売エリアコード
                    if (extrInfo_BillBalanceWork.St_SalesAreaCode != 0)
                    {
                        sqlText += "   AND CUSTSU.SALESAREACODERF>=@ST_SALESAREACODE" + Environment.NewLine;
                        SqlParameter paraSt_SalesAreaCode = sqlCommand.Parameters.Add("@ST_SALESAREACODE", SqlDbType.Int);
                        paraSt_SalesAreaCode.Value = SqlDataMediator.SqlSetInt32(extrInfo_BillBalanceWork.St_SalesAreaCode);
                    }
                    if (extrInfo_BillBalanceWork.Ed_SalesAreaCode != 9999)
                    {
                        sqlText += "   AND CUSTSU.SALESAREACODERF<=@ED_SALESAREACODE" + Environment.NewLine;
                        SqlParameter paraEd_SalesAreaCode = sqlCommand.Parameters.Add("@ED_SALESAREACODE", SqlDbType.Int);
                        paraEd_SalesAreaCode.Value = SqlDataMediator.SqlSetInt32(extrInfo_BillBalanceWork.Ed_SalesAreaCode);
                    }
                    #endregion

                    #region 担当者コード
                    if (extrInfo_BillBalanceWork.St_EmployeeCode != "")
                    {
                        if (extrInfo_BillBalanceWork.EmployeeKindDiv == (int)EmployeeKindDiv.CustomerAgentCd)
                            sqlText += "   AND CUSTSU.CUSTOMERAGENTCDRF>=@ST_AGENTCD" + Environment.NewLine;
                        else if (extrInfo_BillBalanceWork.EmployeeKindDiv == (int)EmployeeKindDiv.BillCollecterCd)
                            sqlText += "   AND CUSTSU.BILLCOLLECTERCDRF>=@ST_AGENTCD" + Environment.NewLine;
                        SqlParameter paraSt_EmployeeCode = sqlCommand.Parameters.Add("@ST_AGENTCD", SqlDbType.NChar);
                        paraSt_EmployeeCode.Value = SqlDataMediator.SqlSetString(extrInfo_BillBalanceWork.St_EmployeeCode);
                    }

                    if (extrInfo_BillBalanceWork.Ed_EmployeeCode != "")
                    {
                        if (extrInfo_BillBalanceWork.EmployeeKindDiv == (int)EmployeeKindDiv.CustomerAgentCd)
                            sqlText += "   AND ( CUSTSU.CUSTOMERAGENTCDRF<=@ED_AGENTCD OR CUSTSU.CUSTOMERAGENTCDRF IS NULL )" + Environment.NewLine;
                        else if (extrInfo_BillBalanceWork.EmployeeKindDiv == (int)EmployeeKindDiv.BillCollecterCd)
                            sqlText += "   AND ( CUSTSU.BILLCOLLECTERCDRF<=@ED_AGENTCD OR CUSTSU.BILLCOLLECTERCDRF IS NULL )" + Environment.NewLine;
                        SqlParameter paraEd_EmployeeCode = sqlCommand.Parameters.Add("@ED_AGENTCD", SqlDbType.NChar);
                        paraEd_EmployeeCode.Value = SqlDataMediator.SqlSetString(extrInfo_BillBalanceWork.Ed_EmployeeCode);
                    }
                    #endregion
                    #endregion

                    #region GROUP BY句
                    sqlText += "GROUP BY" + Environment.NewLine;
                    sqlText += " CLAIM.SALESCNSTAXFRCPROCCDRF,--売上消費税端数処理コード" + Environment.NewLine;
                    sqlText += " SALESPROC.FRACTIONPROCUNITRF,--端数処理単位" + Environment.NewLine;
                    sqlText += " SALESPROC.FRACTIONPROCCDRF,  --端数処理区分" + Environment.NewLine;
                    sqlText += " SALE.CONSTAXLAYMETHODRF," + Environment.NewLine;

                    //--- DEL 2022/10/13 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） --->>>>>
                    // sqlText += " SALE.CONSTAXRATERF" + Environment.NewLine;
                    //--- DEL 2022/10/13 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） ---<<<<<
                    //--- ADD 2022/10/13 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） ---<<<<<
                    sqlText += " SALE.CONSTAXRATERF," + Environment.NewLine;
                    sqlText += " SALE.TAXATIONDIVCDRF" + Environment.NewLine;
                    //--- ADD 2022/10/13 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） ---<<<<<
                    sqlText += ") AS ACCREC" + Environment.NewLine;
                    #endregion
                    #endregion

                    sqlCommand.CommandText = sqlText;

                    #region Prameterオブジェクトの作成
                    //Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
                    SqlParameter findParaAddUpDate = sqlCommand.Parameters.Add("@FINDADDUPDATE", SqlDbType.Int);
                    SqlParameter findParaLastCAddUpUpdDate = sqlCommand.Parameters.Add("@FINDLASTTIMEADDUPDATE", SqlDbType.Int);
                    #endregion

                    #region Parameterオブジェクトへ値設定
                    //Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCode);
                    findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(billBalanceWork.CustomerCode);
                    findParaAddUpDate.Value = SqlDataMediator.SqlSetInt32(addUpDate);

                    if (getFirstDateFlag && (per2yearAddUpdate > 20000101))
                    {
                        if (laMonCAddUpDate < per2yearAddUpdate)
                        {
                            findParaLastCAddUpUpdDate.Value = per2yearAddUpdate;
                        }
                        else
                        {
                            findParaLastCAddUpUpdDate.Value = laMonCAddUpDate;
                        }
                    }
                    else
                    {
                        if (laMonCAddUpDate < 20000101)
                        {
                            findParaLastCAddUpUpdDate.Value = per2yearAddUpdate;
                        }
                        else
                        {
                            findParaLastCAddUpUpdDate.Value = laMonCAddUpDate;
                        }
                    }
                    #endregion

                    myReader = sqlCommand.ExecuteReader();
                    // 端数処理単位
                    double fractionProcUnit = 0;
                    // 伝票転嫁・明細転嫁消費税
                    long totalSalesPricTax = 0;

                    while (myReader.Read())
                    {
                        #region 集計レコードセット
                        custAccRecWork.FractionProcCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FRACTIONPROCCDRF")); //端数処理区分
                        fractionProcUnit = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("FRACTIONPROCUNITRF")); // 端数処理単位
                        custAccRecWork.ConsTaxLayMethod = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CONSTAXLAYMETHODRF"));// 消費税転嫁方式
                        custAccRecWork.ConsTaxRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("CONSTAXRATERF"));         // 税率

                        // ■消費税額
                        if (custAccRecWork.ConsTaxLayMethod == 0)
                        {
                            totalSalesPricTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SLIPSALESPRICECONSTAX"));
                        }
                        else if (custAccRecWork.ConsTaxLayMethod == 1)
                        {
                            totalSalesPricTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DTLSALESPRICECONSTAX"));
                        }
                        else
                        {
                            totalSalesPricTax = 0;
                        }
                        // ■相殺
                        custAccRecWork.OfsThisTimeSales = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("OFSTHISTIMESALESRF"));     // 相殺後今回売上金額

                        // ■売上
                        custAccRecWork.ThisTimeSales = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISTIMESALESRF"));            // 今回売上金額 

                        // ■返品
                        custAccRecWork.ThisSalesPricRgds = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISSALESPRICRGDSRF"));    // 今回返品金額

                        // ■値引
                        custAccRecWork.ThisSalesPricDis = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISSALESPRICDISRF"));      // 今回売上値引金額

                        // 売上伝票枚数
                        custAccRecWork.SalesSlipCount = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESSLIPCOUNTRF"));
                        //---ADD 2022/10/13 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）--->>>>>
                        // 課税区分
                        int taxationDivCdRF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TAXATIONDIVCDRF"));
                        //---ADD 2022/10/13 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）---<<<<<
                        #endregion

                        #region 税別内訳印字
                        // 税率1
                        //--- DEL 2022/10/13 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） --->>>>>
                        //if (custAccRecWork.ConsTaxLayMethod != 9 && custAccRecWork.ConsTaxRate == taxRate1)
                        //--- DEL 2022/10/13 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） ---<<<<<
                        //--- ADD 2022/10/13 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） --->>>>>
                        if ((custAccRecWork.ConsTaxLayMethod != 9 && taxationDivCdRF != 1) && custAccRecWork.ConsTaxRate == taxRate1)
                        //--- ADD 2022/10/13 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） ---<<<<<
                        {
                            // 売上額(計税率1)
                            billBalanceWork.TotalThisTimeSalesTaxRate1 += custAccRecWork.ThisTimeSales;
                            // 返品値引(計税率1)
                            billBalanceWork.TotalThisRgdsDisPricTaxRate1 -= custAccRecWork.ThisSalesPricRgds + custAccRecWork.ThisSalesPricDis;
                            // 純売上額(計税率1)
                            billBalanceWork.TotalPureSalesTaxRate1 += custAccRecWork.OfsThisTimeSales;
                            // 消費税(計税率1)
                            if (custAccRecWork.ConsTaxLayMethod == 0 || custAccRecWork.ConsTaxLayMethod == 1)
                            {
                                billBalanceWork.TotalSalesPricTaxTaxRate1 += totalSalesPricTax;
                            }
                            // 枚数(計税率1)
                            billBalanceWork.TotalSalesSlipCountTaxRate1 += custAccRecWork.SalesSlipCount;
                        }
                        // 税率2
                        //--- DEL 2022/10/13 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） --->>>>>
                        //else if (custAccRecWork.ConsTaxLayMethod != 9 && custAccRecWork.ConsTaxRate == taxRate2)
                        //--- DEL 2022/10/13 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） ---<<<<<
                        //--- ADD 2022/10/13 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） --->>>>>
                        else if ((custAccRecWork.ConsTaxLayMethod != 9 && taxationDivCdRF != 1) && custAccRecWork.ConsTaxRate == taxRate2)
                        //--- ADD 2022/10/13 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） ---<<<<<
                        {
                            // 売上額(計税率2)
                            billBalanceWork.TotalThisTimeSalesTaxRate2 += custAccRecWork.ThisTimeSales;
                            // 返品値引(計税率2)
                            billBalanceWork.TotalThisRgdsDisPricTaxRate2 -= custAccRecWork.ThisSalesPricRgds + custAccRecWork.ThisSalesPricDis;
                            // 純売上額(計税率2)
                            billBalanceWork.TotalPureSalesTaxRate2 += custAccRecWork.OfsThisTimeSales;
                            // 消費税(計税率2)
                            if (custAccRecWork.ConsTaxLayMethod == 0 || custAccRecWork.ConsTaxLayMethod == 1)
                            {
                                billBalanceWork.TotalSalesPricTaxTaxRate2 += totalSalesPricTax;
                            }
                            // 枚数(計税率2)
                            billBalanceWork.TotalSalesSlipCountTaxRate2 += custAccRecWork.SalesSlipCount;
                        }
                        //--- ADD 2022/10/13 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） --->>>>>
                        else if (custAccRecWork.ConsTaxLayMethod == 9 || taxationDivCdRF == 1)
                        {
                            // 売上額(計非課税)
                            billBalanceWork.TotalThisTimeSalesTaxFree += custAccRecWork.ThisTimeSales;
                            // 返品値引(計非課税)
                            billBalanceWork.TotalThisRgdsDisPricTaxFree -= custAccRecWork.ThisSalesPricRgds + custAccRecWork.ThisSalesPricDis;
                            // 純売上額(計非課税)
                            billBalanceWork.TotalPureSalesTaxFree += custAccRecWork.OfsThisTimeSales;
                            // 消費税(計非課税)
                            billBalanceWork.TotalSalesPricTaxTaxFree = 0;
                            // 枚数(計非課税)
                            billBalanceWork.TotalSalesSlipCountTaxFree += custAccRecWork.SalesSlipCount;
                        }
                        //--- ADD 2022/10/13 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） ---<<<<<
                        // その他
                        else
                        {
                            // 売上額(計その他)
                            billBalanceWork.TotalThisTimeSalesOther += custAccRecWork.ThisTimeSales;
                            // 返品値引(計その他)
                            billBalanceWork.TotalThisRgdsDisPricOther -= custAccRecWork.ThisSalesPricRgds + custAccRecWork.ThisSalesPricDis;
                            // 純売上額(計その他)
                            billBalanceWork.TotalPureSalesOther += custAccRecWork.OfsThisTimeSales;
                            // 消費税(計その他)
                            if (custAccRecWork.ConsTaxLayMethod == 0 || custAccRecWork.ConsTaxLayMethod == 1)
                            {
                                billBalanceWork.TotalSalesPricTaxOther += totalSalesPricTax;
                            }
                            // 枚数(計その他)
                            billBalanceWork.TotalSalesSlipCountOther += custAccRecWork.SalesSlipCount;
                        }
                        #endregion

                        if (!consTaxLayMethodList.Contains(custAccRecWork.ConsTaxLayMethod))
                        {
                            consTaxLayMethodList.Add(custAccRecWork.ConsTaxLayMethod);
                        }

                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }

                    if (!myReader.IsClosed) myReader.Close();
                    sqlCommand.CommandText = string.Empty;
                    sqlText = string.Empty;

                    #region 消費税と当月合計算出
                    foreach (int consTaxLayMethod in consTaxLayMethodList)
                    {
                        // 伝票転嫁・明細転嫁・非課税
                        if (consTaxLayMethod == 0 || consTaxLayMethod == 1 || consTaxLayMethod == 9)
                        {
                            continue;
                        }

                        switch (consTaxLayMethod)
                        {
                            // 請求親
                            case 2:
                                sqlText += "SELECT" + Environment.NewLine;
                                sqlText += "  SUM(SALESTOTALTAXEXCRF) AS SALESTOTALTAXEXCRF," + Environment.NewLine;
                                sqlText += "  CONSTAXRATERF" + Environment.NewLine;
                                sqlText += "FROM (" + Environment.NewLine;
                                sqlText += "	SELECT" + Environment.NewLine;
                                sqlText += "		SUBSALE.ENTERPRISECODERF," + Environment.NewLine;
                                //--- ADD 2022/10/13 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） --->>>>>
                                sqlText += "	 (SELECT SUM(SALESMONEYTAXEXCRF) AS SALESTOTALTAXEXCRF FROM SALESDETAILRF AS DTL WITH (READUNCOMMITTED) WHERE " + Environment.NewLine;
                                sqlText += "       SUBSALE.ENTERPRISECODERF = DTL.ENTERPRISECODERF" + Environment.NewLine;
                                sqlText += "       AND SUBSALE.ACPTANODRSTATUSRF = DTL.ACPTANODRSTATUSRF" + Environment.NewLine;
                                sqlText += "       AND SUBSALE.SALESSLIPNUMRF = DTL.SALESSLIPNUMRF" + Environment.NewLine;
                                sqlText += "       AND DTL.TAXATIONDIVCDRF = 0) AS SALESTOTALTAXEXCRF, " + Environment.NewLine;
                                //--- ADD 2022/10/13 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） ---<<<<<
                                //--- DEL 2022/10/13 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） --->>>>>
                                //sqlText += "	    SUBSALE.SALESTOTALTAXEXCRF," + Environment.NewLine;
                                //--- DEL 2022/10/13 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） ---<<<<<
                                
                                sqlText += "	    (CASE WHEN (CLAIM.CLAIMCODERF IS NOT NULL) THEN CLAIM.CLAIMCODERF ELSE SUBSALE.CLAIMCODERF END) AS CLAIMCODERF," + Environment.NewLine;
                                sqlText += "	    CASE WHEN (SUBSALE.ADDUPADATERF >= TAX.TAXRATESTARTDATERF) AND (SUBSALE.ADDUPADATERF <= TAX.TAXRATEENDDATERF) THEN TAX.TAXRATERF" + Environment.NewLine;
                                sqlText += "	    WHEN (SUBSALE.ADDUPADATERF >= TAX.TAXRATESTARTDATE2RF) AND (SUBSALE.ADDUPADATERF <= TAX.TAXRATEENDDATE2RF) THEN TAX.TAXRATE2RF" + Environment.NewLine;
                                sqlText += "	    WHEN (SUBSALE.ADDUPADATERF >= TAX.TAXRATESTARTDATE3RF) AND (SUBSALE.ADDUPADATERF <= TAX.TAXRATEENDDATE3RF) THEN TAX.TAXRATE3RF ELSE 0 END AS CONSTAXRATERF" + Environment.NewLine;
                                sqlText += "	FROM SALESSLIPRF AS SUBSALE WITH(READUNCOMMITTED)" + Environment.NewLine;
                                sqlText += "	LEFT JOIN TAXRATESETRF AS TAX WITH(READUNCOMMITTED)" + Environment.NewLine;
                                sqlText += "	ON TAX.ENTERPRISECODERF = SUBSALE.ENTERPRISECODERF" + Environment.NewLine;
                                sqlText += "    LEFT JOIN CUSTOMERRF AS CLAIM WITH(READUNCOMMITTED)" + Environment.NewLine;
                                sqlText += "    ON SUBSALE.ENTERPRISECODERF = CLAIM.ENTERPRISECODERF" + Environment.NewLine;
                                sqlText += "    AND SUBSALE.CUSTOMERCODERF = CLAIM.CUSTOMERCODERF" + Environment.NewLine;
                                sqlText += "    WHERE SUBSALE.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                                sqlText += "        AND(SUBSALE.ADDUPADATERF<=@FINDADDUPDATE AND SUBSALE.ADDUPADATERF>@FINDLASTTIMEADDUPDATE)" + Environment.NewLine;
                                sqlText += "        AND SUBSALE.LOGICALDELETECODERF=0" + Environment.NewLine;
                                sqlText += "        AND SUBSALE.ACPTANODRSTATUSRF=30" + Environment.NewLine;
                                sqlText += "        AND SUBSALE.CONSTAXLAYMETHODRF=2" + Environment.NewLine;
                                sqlText += "        AND SUBSALE.DEBITNOTEDIVRF=0" + Environment.NewLine;
                                sqlText += ") AS SALE" + Environment.NewLine;
                                sqlText += " LEFT JOIN SUMCUSTSTRF AS SUMCST" + Environment.NewLine;
                                sqlText += "  ON  SUMCST.ENTERPRISECODERF = SALE.ENTERPRISECODERF" + Environment.NewLine;
                                sqlText += "  AND SUMCST.CUSTOMERCODERF = SALE.CLAIMCODERF" + Environment.NewLine;
                                sqlText += " LEFT JOIN CUSTOMERRF AS CUSTSU" + Environment.NewLine;
                                sqlText += "  ON  CUSTSU.ENTERPRISECODERF = SUMCST.ENTERPRISECODERF" + Environment.NewLine;
                                sqlText += "  AND CUSTSU.CUSTOMERCODERF = SUMCST.SUMCLAIMCUSTCODERF" + Environment.NewLine;
                                sqlText += "WHERE SALE.CLAIMCODERF=@FINDCUSTOMERCODE" + Environment.NewLine;
                                #region 販売エリアコード
                                if (extrInfo_BillBalanceWork.St_SalesAreaCode != 0)
                                {
                                    sqlText += "  AND CUSTSU.SALESAREACODERF>=@ST_SALESAREACODE" + Environment.NewLine;
                                }
                                if (extrInfo_BillBalanceWork.Ed_SalesAreaCode != 9999)
                                {
                                    sqlText += "  AND CUSTSU.SALESAREACODERF<=@ED_SALESAREACODE" + Environment.NewLine;
                                }
                                #endregion

                                #region 担当者コード
                                if (extrInfo_BillBalanceWork.St_EmployeeCode != "")
                                {
                                    if (extrInfo_BillBalanceWork.EmployeeKindDiv == (int)EmployeeKindDiv.CustomerAgentCd)
                                        sqlText += "  AND CUSTSU.CUSTOMERAGENTCDRF>=@ST_AGENTCD" + Environment.NewLine;
                                    else if (extrInfo_BillBalanceWork.EmployeeKindDiv == (int)EmployeeKindDiv.BillCollecterCd)
                                        sqlText += "  AND CUSTSU.BILLCOLLECTERCDRF>=@ST_AGENTCD" + Environment.NewLine;
                                }

                                if (extrInfo_BillBalanceWork.Ed_EmployeeCode != "")
                                {
                                    if (extrInfo_BillBalanceWork.EmployeeKindDiv == (int)EmployeeKindDiv.CustomerAgentCd)
                                        sqlText += "  AND ( CUSTSU.CUSTOMERAGENTCDRF<=@ED_AGENTCD OR CUSTSU.CUSTOMERAGENTCDRF IS NULL )" + Environment.NewLine;
                                    else if (extrInfo_BillBalanceWork.EmployeeKindDiv == (int)EmployeeKindDiv.BillCollecterCd)
                                        sqlText += "  AND ( CUSTSU.BILLCOLLECTERCDRF<=@ED_AGENTCD OR CUSTSU.BILLCOLLECTERCDRF IS NULL )" + Environment.NewLine;
                                }
                                #endregion
                                sqlText += "GROUP BY" + Environment.NewLine;
                                sqlText += "   CONSTAXRATERF" + Environment.NewLine;
                                break;
                            // 請求子
                            case 3:
                                sqlText += "SELECT" + Environment.NewLine;
                                sqlText += "  SUM(SALE.SALESTOTALTAXEXCRF) AS SALESTOTALTAXEXCRF," + Environment.NewLine;
                                sqlText += "  SALE.RESULTSADDUPSECCDRF," + Environment.NewLine;
                                sqlText += "  SALE.CUSTOMERCODERF," + Environment.NewLine;
                                sqlText += "  SALE.CONSTAXRATERF" + Environment.NewLine;
                                sqlText += "FROM (" + Environment.NewLine;
                                sqlText += "	SELECT" + Environment.NewLine;
                                //--- ADD 2022/10/13 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） --->>>>>
                                sqlText += "	 (SELECT SUM(SALESMONEYTAXEXCRF) AS SALESTOTALTAXEXCRF FROM SALESDETAILRF AS DTL WITH (READUNCOMMITTED) WHERE " + Environment.NewLine;
                                sqlText += "       SUBSALE.ENTERPRISECODERF = DTL.ENTERPRISECODERF" + Environment.NewLine;
                                sqlText += "       AND SUBSALE.ACPTANODRSTATUSRF = DTL.ACPTANODRSTATUSRF" + Environment.NewLine;
                                sqlText += "       AND SUBSALE.SALESSLIPNUMRF = DTL.SALESSLIPNUMRF" + Environment.NewLine;
                                sqlText += "       AND DTL.TAXATIONDIVCDRF = 0) AS SALESTOTALTAXEXCRF, " + Environment.NewLine;
                                //--- ADD 2022/10/13 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） ---<<<<<
                                sqlText += "		SUBSALE.ENTERPRISECODERF," + Environment.NewLine;
                                sqlText += "		SUBSALE.RESULTSADDUPSECCDRF," + Environment.NewLine;
                                //--- DEL 2022/10/13 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） --->>>>>
                                //sqlText += "		SUBSALE.SALESTOTALTAXEXCRF," + Environment.NewLine;
                                //--- DEL 2022/10/13 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） ---<<<<<
                                
                                sqlText += "		SUBSALE.CUSTOMERCODERF," + Environment.NewLine;
                                sqlText += "	    (CASE WHEN (CLAIM.CLAIMCODERF IS NOT NULL) THEN CLAIM.CLAIMCODERF ELSE SUBSALE.CLAIMCODERF END) AS CLAIMCODERF," + Environment.NewLine;
                                sqlText += "	    CASE WHEN (SUBSALE.ADDUPADATERF >= TAX.TAXRATESTARTDATERF) AND (SUBSALE.ADDUPADATERF <= TAX.TAXRATEENDDATERF) THEN TAX.TAXRATERF" + Environment.NewLine;
                                sqlText += "	    WHEN (SUBSALE.ADDUPADATERF >= TAX.TAXRATESTARTDATE2RF) AND (SUBSALE.ADDUPADATERF <= TAX.TAXRATEENDDATE2RF) THEN TAX.TAXRATE2RF" + Environment.NewLine;
                                sqlText += "	    WHEN (SUBSALE.ADDUPADATERF >= TAX.TAXRATESTARTDATE3RF) AND (SUBSALE.ADDUPADATERF <= TAX.TAXRATEENDDATE3RF) THEN TAX.TAXRATE3RF ELSE 0 END AS CONSTAXRATERF" + Environment.NewLine;
                                sqlText += "	FROM SALESSLIPRF AS SUBSALE WITH(READUNCOMMITTED)" + Environment.NewLine;
                                sqlText += "	LEFT JOIN TAXRATESETRF AS TAX WITH(READUNCOMMITTED)" + Environment.NewLine;
                                sqlText += "	ON TAX.ENTERPRISECODERF = SUBSALE.ENTERPRISECODERF" + Environment.NewLine;
                                sqlText += "    LEFT JOIN CUSTOMERRF AS CLAIM WITH(READUNCOMMITTED)" + Environment.NewLine;
                                sqlText += "    ON SUBSALE.ENTERPRISECODERF = CLAIM.ENTERPRISECODERF" + Environment.NewLine;
                                sqlText += "    AND SUBSALE.CUSTOMERCODERF = CLAIM.CUSTOMERCODERF" + Environment.NewLine;
                                sqlText += "    WHERE SUBSALE.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                                sqlText += "        AND(SUBSALE.ADDUPADATERF<=@FINDADDUPDATE AND SUBSALE.ADDUPADATERF>@FINDLASTTIMEADDUPDATE)" + Environment.NewLine;
                                sqlText += "        AND SUBSALE.LOGICALDELETECODERF=0" + Environment.NewLine;
                                sqlText += "        AND SUBSALE.ACPTANODRSTATUSRF=30" + Environment.NewLine;
                                sqlText += "        AND SUBSALE.CONSTAXLAYMETHODRF=3" + Environment.NewLine;
                                sqlText += "        AND SUBSALE.DEBITNOTEDIVRF=0" + Environment.NewLine;
                                sqlText += ") AS SALE" + Environment.NewLine;
                                sqlText += " LEFT JOIN SUMCUSTSTRF AS SUMCST" + Environment.NewLine;
                                sqlText += "  ON  SUMCST.ENTERPRISECODERF = SALE.ENTERPRISECODERF" + Environment.NewLine;
                                sqlText += "  AND SUMCST.CUSTOMERCODERF = SALE.CLAIMCODERF" + Environment.NewLine;
                                sqlText += " LEFT JOIN CUSTOMERRF AS CUSTSU" + Environment.NewLine;
                                sqlText += "  ON  CUSTSU.ENTERPRISECODERF = SUMCST.ENTERPRISECODERF" + Environment.NewLine;
                                sqlText += "  AND CUSTSU.CUSTOMERCODERF = SUMCST.SUMCLAIMCUSTCODERF" + Environment.NewLine;
                                sqlText += "WHERE SALE.CLAIMCODERF=@FINDCUSTOMERCODE" + Environment.NewLine;
                                #region 販売エリアコード
                                if (extrInfo_BillBalanceWork.St_SalesAreaCode != 0)
                                {
                                    sqlText += "  AND CUSTSU.SALESAREACODERF>=@ST_SALESAREACODE" + Environment.NewLine;
                                }
                                if (extrInfo_BillBalanceWork.Ed_SalesAreaCode != 9999)
                                {
                                    sqlText += "  AND CUSTSU.SALESAREACODERF<=@ED_SALESAREACODE" + Environment.NewLine;
                                }
                                #endregion

                                #region 担当者コード
                                if (extrInfo_BillBalanceWork.St_EmployeeCode != "")
                                {
                                    if (extrInfo_BillBalanceWork.EmployeeKindDiv == (int)EmployeeKindDiv.CustomerAgentCd)
                                        sqlText += "  AND CUSTSU.CUSTOMERAGENTCDRF>=@ST_AGENTCD" + Environment.NewLine;
                                    else if (extrInfo_BillBalanceWork.EmployeeKindDiv == (int)EmployeeKindDiv.BillCollecterCd)
                                        sqlText += "  AND CUSTSU.BILLCOLLECTERCDRF>=@ST_AGENTCD" + Environment.NewLine;
                                }

                                if (extrInfo_BillBalanceWork.Ed_EmployeeCode != "")
                                {
                                    if (extrInfo_BillBalanceWork.EmployeeKindDiv == (int)EmployeeKindDiv.CustomerAgentCd)
                                        sqlText += "  AND ( CUSTSU.CUSTOMERAGENTCDRF<=@ED_AGENTCD OR CUSTSU.CUSTOMERAGENTCDRF IS NULL )" + Environment.NewLine;
                                    else if (extrInfo_BillBalanceWork.EmployeeKindDiv == (int)EmployeeKindDiv.BillCollecterCd)
                                        sqlText += "  AND ( CUSTSU.BILLCOLLECTERCDRF<=@ED_AGENTCD OR CUSTSU.BILLCOLLECTERCDRF IS NULL )" + Environment.NewLine;
                                }
                                #endregion
                                sqlText += "GROUP BY" + Environment.NewLine;
                                sqlText += "   SALE.RESULTSADDUPSECCDRF," + Environment.NewLine;
                                sqlText += "   SALE.CUSTOMERCODERF," + Environment.NewLine;
                                sqlText += "   SALE.CONSTAXRATERF" + Environment.NewLine;
                                break;
                        }

                        // 請求転嫁のみの場合、消費税子検索を行う
                        if (!string.IsNullOrEmpty(sqlText))
                        {
                            sqlCommand.CommandText = sqlText;
                            myReader = sqlCommand.ExecuteReader();
                        }

                        // 売上伝票合計（税抜き）
                        long salesTotal = 0;
                        // 消費税税率
                        double consTaxRate = 0.0;
                        // 消費税(端数処理後)
                        long tempTax = 0;

                        while (myReader.Read())
                        {
                            switch (consTaxLayMethod)
                            {
                                // 請求親
                                case 2:
                                // 請求子
                                case 3:
                                    salesTotal = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTOTALTAXEXCRF"));
                                    consTaxRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("CONSTAXRATERF"));
                                    // 税率1
                                    if (consTaxRate == taxRate1)
                                    {
                                        FracCalc(salesTotal * consTaxRate, fractionProcUnit, custAccRecWork.FractionProcCd, out tempTax);
                                        billBalanceWork.TotalSalesPricTaxTaxRate1 += tempTax;
                                    }
                                    // 税率2
                                    else if (consTaxRate == taxRate2)
                                    {
                                        FracCalc(salesTotal * consTaxRate, fractionProcUnit, custAccRecWork.FractionProcCd, out tempTax);
                                        billBalanceWork.TotalSalesPricTaxTaxRate2 += tempTax;
                                    }
                                    // その他
                                    else
                                    {
                                        FracCalc(salesTotal * consTaxRate, fractionProcUnit, custAccRecWork.FractionProcCd, out tempTax);
                                        billBalanceWork.TotalSalesPricTaxOther += tempTax;
                                    }
                                    break;
                            }
                        }

                        // クエリ初期化
                        sqlText = string.Empty;
                        if (!myReader.IsClosed) myReader.Close();
                    }

                    billBalanceWork.TotalAfCalTMonthAccRecTaxRate1 = billBalanceWork.TotalPureSalesTaxRate1 + billBalanceWork.TotalSalesPricTaxTaxRate1;
                    billBalanceWork.TotalAfCalTMonthAccRecTaxRate2 = billBalanceWork.TotalPureSalesTaxRate2 + billBalanceWork.TotalSalesPricTaxTaxRate2;
                    billBalanceWork.TotalAfCalTMonthAccRecTaxFree = billBalanceWork.TotalPureSalesTaxFree + billBalanceWork.TotalSalesPricTaxTaxFree;// ADD 2022/10/13 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）
                    billBalanceWork.TotalAfCalTMonthAccRecOther = billBalanceWork.TotalPureSalesOther + billBalanceWork.TotalSalesPricTaxOther;
                    #endregion

                    #endregion
                }

                billBalanceWork.TitleTaxRate1 = Convert.ToInt32(taxRate1 * 100) + "%";
                billBalanceWork.TitleTaxRate2 = Convert.ToInt32(taxRate2 * 100) + "%";
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "BillBalanceTableDB.SearchSalesProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (!myReader.IsClosed) myReader.Close();
                myReader.Dispose();
            }

            return status;
        }
        #endregion

        #region [FracCalc 消費税端数処理]
        /// <summary>
        /// 端数処理
        /// </summary>
        /// <param name="inputNumerical">数値</param>
        /// <param name="fractionUnit">端数処理単位</param>
        /// <param name="fractionProcess">端数処理（1:切捨 2:四捨五入 3:切上）</param>
        /// <param name="resultNumerical">算出金額</param>
        /// <br>Note       : 11570208-00 軽減税率対応</br>
        /// <br>Programmer : 3H 劉星光</br>
        /// <br>Date       : 2020/04/10</br>
        private void FracCalc(double inputNumerical, double fractionUnit, Int32 fractionProcess, out Int64 resultNumerical)
        {
            // 初期値セット
            resultNumerical = (Int64)inputNumerical;

            inputNumerical = (double)((decimal)inputNumerical - ((decimal)inputNumerical % (decimal)0.000001));	// 小数点6桁以下切捨
            fractionUnit = (double)((decimal)fractionUnit - ((decimal)fractionUnit % (decimal)0.000001));		// 小数点6桁以下切捨

            // ゼロ除算防止
            if (((decimal)fractionUnit) == 0)
            {
                fractionUnit = 1;
            }
            // 端数単位で除算
            decimal tmpKin = (decimal)inputNumerical / (decimal)fractionUnit;

            // マイナス補正
            bool sign = false;
            if (tmpKin < 0)
            {
                sign = true;
                tmpKin = tmpKin * (-1);
            }

            // 小数部1桁取得
            decimal tmpDecimal = (tmpKin - (decimal)((long)tmpKin)) * 10;

            // tmpKin 端数指定
            bool wRoundFlg = true; // 切捨
            switch (fractionProcess)
            {
                //--------------------------------------
                // 1:切捨
                //--------------------------------------
                case 1:
                    {
                        wRoundFlg = true; // 切捨
                        break;
                    }
                //--------------------------------------
                // 2:四捨五入
                //--------------------------------------
                case 2: // 四捨五入
                    {
                        if (tmpDecimal >= 5)
                        {
                            wRoundFlg = false; // 切上
                        }
                        break;
                    }
                //--------------------------------------
                // 3:切上
                //--------------------------------------
                case 3: // 切上
                    {
                        if (tmpDecimal > 0)
                        {
                            wRoundFlg = false; // 切上
                        }
                        break;
                    }
            }

            // 端数処理
            if (wRoundFlg == false)
            {
                tmpKin = tmpKin + 1;
            }

            // 小数部切捨
            tmpKin = (decimal)(long)tmpKin;

            // マイナス補正
            if (sign == true)
            {
                tmpKin = tmpKin * (-1);
            }

            decimal a = tmpKin * (decimal)fractionUnit;

            // 算出値セット
            resultNumerical = (Int64)((decimal)tmpKin * (decimal)fractionUnit);

        }
        #endregion

        /// <summary>
        /// 消費税別内訳区分を列挙します。
        /// </summary>
        enum TaxTotalDiv
        {
            TaxTotalON = 0,  //0:印字する
            TaxTotalOFF = 1  //1:印字しない
        }
        // --- ADD END 3H 劉星光 2020/04/10 ----------<<<<<

        /// <summary>
        /// 引数文字列の表示/非表示を判定します。
        /// </summary>
        /// <param name="bCondition">条件式</param>
        /// <param name="Text">文字列</param>
        /// <returns></returns>
        private string IFBy(Boolean bCondition, string Text)
        {
            if (bCondition) return Text;
            else return "";
        }

        /// <summary>
        /// 担当者区分を列挙します。
        /// </summary>
        enum EmployeeKindDiv
        {
            CustomerAgentCd = 0,  //0:顧客担当従業員コード
            BillCollecterCd = 1   //1:集金担当従業員コード
        }

        /// <summary>
        /// 入金内訳区分を列挙します。
        /// </summary>
        enum DepoDtlDiv
        {
            DepoDtlON = 0,  //0:印字する
            DepoDtlOFF = 1  //1:印字しない
        }
    }

    // --- ADD START 3H 劉星光 2020/04/10 ---------->>>>>
    # region [月次更新・月次処理日情報]
    /// <summary>
    /// 月次処理日情報
    /// </summary>
    /// <remarks>
    /// <br>Note       : 11570208-00 軽減税率対応</br>
    /// <br>Programmer : 3H 劉星光</br>
    /// <br>Date       : 2020/04/10</br>
    /// </remarks>
    public class CustAccRecDateInfo
    {
        /// <summary>今回月次更新年月日</summary>
        private int _addUpDate;

        /// <summary>前回月次更新年月日</summary>
        private int _laMonCAddUpUpdDate;

        /// <summary>今回月次更新年月日</summary>
        public int AddUpDate
        {
            get { return _addUpDate; }
            set { _addUpDate = value; }
        }

        /// <summary>前回月次更新年月日</summary>
        public int LaMonCAddUpUpdDate
        {
            get { return _laMonCAddUpUpdDate; }
            set { _laMonCAddUpUpdDate = value; }
        }
    }
    #endregion
    // --- ADD END 3H 劉星光 2020/04/10 ----------<<<<<
}

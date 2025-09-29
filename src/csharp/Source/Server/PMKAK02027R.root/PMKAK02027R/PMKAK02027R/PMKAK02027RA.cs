//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 買掛残高一覧表（総括）DBリモートオブジェクト
// プログラム概要   : 買掛残高一覧表（総括）の実データ操作を行うクラス
//----------------------------------------------------------------------------//
//                (c)Copyright  2012 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号 　　　　　   作成担当 : FSI冨樫 紗由里
// 作 成 日  2012/09/14  修正内容 : 新規作成、仕入総括機能対応
//----------------------------------------------------------------------------//
// 管理番号               作成担当 : 
// 修 正 日               修正内容 : 
//----------------------------------------------------------------------------//
// 管理番号  11570208-00 作成担当 : 3H 劉星光
// 修 正 日  2020/04/10  修正内容 : 軽減税率対応
//----------------------------------------------------------------------------//
// 管理番号  11870141-00 作成担当 : 3H 仰亮亮
// 修 正 日  2022/10/20  修正内容 : インボイス対応（税率別合計金額不具合修正）
//----------------------------------------------------------------------------//

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
using System.Collections.Generic;
using Broadleaf.Application.Common;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 買掛残高一覧表（総括）DBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 買掛残高一覧表（総括）の実データ操作を行うクラスです。</br>
    /// <br>Programmer : FSI冨樫 紗由里</br>
    /// <br>Date       : 2012/09/14</br>
    /// <br>UpdateNote : 11570208-00 軽減税率対応</br>
    /// <br>Programmer : 3H 劉星光</br>
    /// <br>Date	   : 2020/04/10</br>
    /// <br>UpdateNote : 11870141-00 インボイス対応（税率別合計金額不具合修正）</br>
    /// <br>Programmer : 3H 仰亮亮</br>
    /// <br>Date       : 2022/10/20</br>
    /// </remarks>
    [Serializable]
    public class SumAccPaymentListWorkDB : RemoteDB, ISumAccPaymentListWorkDB
    {
        private int _timeOut = 3600;//ADD 2020/04/10 石崎　軽減税率対応
        /// <summary>
        /// 買掛残高一覧表（総括）DBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : FSI冨樫 紗由里</br>
        /// <br>Date       : 2012/09/14</br>
        /// </remarks>
        public SumAccPaymentListWorkDB()
            :
            base("PMKAK02029D", "Broadleaf.Application.Remoting.ParamData.SumAccPaymentListResultWork", "SUPLACCPAYRF")
        {
        }

        /// <summary>売掛/買掛金額マスタ更新リモートオブジェクト</summary>
        private MonthlyAddUpDB _monthlyAddUpDB;

        #region [Search]
        /// <summary>
        /// 指定された条件の買掛残高一覧表（総括）を戻します
        /// </summary>
        /// <param name="sumAccPaymentListResultWork">検索結果</param>
        /// <param name="sumAccPaymentListCndtnWork">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の買掛残高一覧表（総括）を戻します</br>
        /// <br>Programmer : FSI冨樫 紗由里</br>
        /// <br>Date       : 2012/09/14</br>
        public int Search(out object sumAccPaymentListResultWork, object sumAccPaymentListCndtnWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            sumAccPaymentListResultWork = null;

            ArrayList _sumAccPaymentListCndtnWorkList = sumAccPaymentListCndtnWork as ArrayList;
            SumAccPaymentListCndtnWork _sumAccPaymentListCndtnWork = null;

            if (_sumAccPaymentListCndtnWorkList == null)
            {
                _sumAccPaymentListCndtnWork = sumAccPaymentListCndtnWork as SumAccPaymentListCndtnWork;
            }
            else
            {
                if (_sumAccPaymentListCndtnWorkList.Count > 0)
                    _sumAccPaymentListCndtnWork = _sumAccPaymentListCndtnWorkList[0] as SumAccPaymentListCndtnWork;
            }

            try
            {
                status = SearchProc(out sumAccPaymentListResultWork, _sumAccPaymentListCndtnWork, readMode, logicalMode);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SumAccPaymentListWorkDB.Search Exception=" + ex.Message);
                sumAccPaymentListResultWork = new ArrayList();
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }

            return status;
        }
        #endregion  //[Search]

        #region [SearchProc]
        /// <summary>
        /// 指定された企業コードの買掛残高一覧表（総括）LISTを全て戻します
        /// </summary>
        /// <param name="sumAccPaymentListResultWork">検索結果</param>
        /// <param name="_sumAccPaymentListCndtnWork">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された企業コードの買掛残高一覧表（総括）LISTを全て戻します</br>
        /// <br>Programmer : FSI冨樫 紗由里</br>
        /// <br>Date       : 2012/09/14</br>
        /// <br>UpdateNote : 11570208-00 軽減税率対応</br>
        /// <br>Programmer : 3H 劉星光</br>
        /// <br>Date	   : 2020/04/10</br>
        private int SearchProc(out object sumAccPaymentListResultWork, SumAccPaymentListCndtnWork _sumAccPaymentListCndtnWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;

            sumAccPaymentListResultWork = null;
            // --- ADD START 3H 劉星光 2020/04/10 ---------->>>>>
            // 締次フラッグ
            bool isCheckOut = true;
            // 支払先前回月次更新年月日
            Dictionary<string, DateTime> payeeDateDic = new Dictionary<string, DateTime>();
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
                ArrayList SupplierList = new ArrayList();
                SumAccPaymentListResultWork SupplierListWork = new SumAccPaymentListResultWork();

                //総括仕入先マスタリスト作成
                status = this.SearchSuppProc(ref SupplierList, _sumAccPaymentListCndtnWork, ref sqlConnection, logicalMode);
                if ((status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND) ||
                    (status == (int)ConstantManagement.DB_Status.ctDB_EOF))
                {
                    //該当データなし
                    return status;
                }
                else if (status != 0)
                {
                    //取得失敗
                    throw new Exception("仕入先マスタ読込失敗。");
                }

                if (SupplierList.Count == 0)
                {
                    //該当データなし
                    return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }

                for (int i = 0; i < SupplierList.Count; i++)
                {
                    // 締日チェック
                    para.EnterpriseCode = _sumAccPaymentListCndtnWork.EnterpriseCode;  //企業コード
                    para.SectionCode = ((SumAccPaymentListResultWork)SupplierList[i]).AddUpSecCode; // (子)拠点コード
                    status = ttlDayCalcDB.SearchHisMonthlyAccPay(out retList, para, ref sqlConnection);
                    Int32 iAddUpDate = Int32.Parse(_sumAccPaymentListCndtnWork.AddUpDate.ToString("yyyyMMdd"));
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL || retList[0].TotalDay < iAddUpDate)
                    {
                        #region 未締処理

                        DateTime AddUpDate;

                        //今回月次処理日を取得
                        if (status == 9)
                        {
                            AddUpDate = _sumAccPaymentListCndtnWork.AddUpDate;
                        }
                        else
                        {
                            AddUpDate = DateTime.ParseExact(retList[0].TotalDay.ToString(), "yyyyMMdd", System.Globalization.DateTimeFormatInfo.InvariantInfo);
                            AddUpDate = AddUpDate.AddDays(1);
                        }
                        //売掛金・買掛金集計モジュールパラメータセット(今回月次処理日+1カ月)
                        this._monthlyAddUpDB = new MonthlyAddUpDB();
                        SuplAccPayWork suplAccPayWork2 = new SuplAccPayWork();
                        suplAccPayWork2.EnterpriseCode = _sumAccPaymentListCndtnWork.EnterpriseCode;                //企業コード
                        // --- UPD START 3H 劉星光 2020/03/02 ---------->>>>>
                        //suplAccPayWork2.AddUpDate = _sumAccPaymentListCndtnWork.AddUpDate.AddMonths(-1);            //計上年月日
                        // 期首年月日の日が一日の場合
                        if (_sumAccPaymentListCndtnWork.AddUpDate.Day > 27)
                        {
                            // 前月の末日を設定する
                            suplAccPayWork2.AddUpDate = _sumAccPaymentListCndtnWork.AddUpDate.AddDays(1 - _sumAccPaymentListCndtnWork.AddUpDate.Day).AddDays(-1);
                        }
                        // 上記以外の場合
                        else
                        {
                            // 既存のままで前月を設定する
                            suplAccPayWork2.AddUpDate = _sumAccPaymentListCndtnWork.AddUpDate.AddMonths(-1);
                        }
                        // --- UPD END 3H 劉星光 2020/03/02 ----------<<<<<
                        suplAccPayWork2.AddUpYearMonth = _sumAccPaymentListCndtnWork.AddUpYearMonth.AddMonths(-1);  //計上年月
                        suplAccPayWork2.AddUpSecCode = ((SumAccPaymentListResultWork)SupplierList[i]).AddUpSecCode; //計上拠点コード ※仕入先マスタ(総括設定)リストから
                        suplAccPayWork2.SupplierCd = ((SumAccPaymentListResultWork)SupplierList[i]).PayeeCode;      //仕入先コード   ※仕入先マスタ(総括設定)リストから
                        object paraObj3 = (object)suplAccPayWork2;
                        string retMsg1 = null;

                        //売掛金・買掛金集計モジュール呼出
                        status = _monthlyAddUpDB.ReadSuplAccPayByAddUpSecCode(ref paraObj3, out retMsg1);

                        //取得結果キャスト
                        ArrayList SuplAccRecResult2 = new ArrayList();
                        SuplAccRecResult2.Add((SuplAccPayWork)paraObj3);

                        //売掛金・買掛金集計モジュールパラメータセット
                        this._monthlyAddUpDB = new MonthlyAddUpDB();
                        SuplAccPayWork suplAccPayWork = new SuplAccPayWork();
                        suplAccPayWork.EnterpriseCode = _sumAccPaymentListCndtnWork.EnterpriseCode;                 //企業コード
                        suplAccPayWork.AddUpDate = _sumAccPaymentListCndtnWork.AddUpDate;                           //計上年月日
                        suplAccPayWork.AddUpYearMonth = _sumAccPaymentListCndtnWork.AddUpYearMonth;                 //計上年月
                        suplAccPayWork.AddUpSecCode = ((SumAccPaymentListResultWork)SupplierList[i]).AddUpSecCode;  //計上拠点コード ※仕入先マスタ(総括設定)リストから
                        suplAccPayWork.SupplierCd = ((SumAccPaymentListResultWork)SupplierList[i]).PayeeCode;       //仕入先コード   ※仕入先マスタ(総括設定)リストから

                        if (AddUpDate != _sumAccPaymentListCndtnWork.AddUpYearMonth)
                        {
                            DateTime StMonthDate = DateTime.MinValue;
                            DateTime EdMonthDate = DateTime.MinValue;
                            DateTime AddUpYearMonth = _sumAccPaymentListCndtnWork.AddUpYearMonth;
                            //■集計対象期間取得
                            //自社情報取得
                            CompanyInfWork paraCompanyInfWork = new CompanyInfWork();
                            CompanyInfDB companyInfDB = new CompanyInfDB();
                            ArrayList arrayList;

                            paraCompanyInfWork.EnterpriseCode = para.EnterpriseCode;
                            companyInfDB.Search(out arrayList, paraCompanyInfWork, ref sqlConnection);
                            paraCompanyInfWork = (CompanyInfWork)arrayList[0];
                            FinYearTableGenerator parafinYearTableGenerator = new FinYearTableGenerator(paraCompanyInfWork);

                            parafinYearTableGenerator.GetDaysFromMonth(AddUpYearMonth, out StMonthDate, out EdMonthDate);

                            suplAccPayWork.StMonCAddUpUpdDate = StMonthDate;             // 計上年月日(開始)
                            suplAccPayWork.LaMonCAddUpUpdDate = StMonthDate.AddDays(-1); // 計上年月日(前回締日)
                        }

                        object paraObj2 = (object)suplAccPayWork;
                        string retMsg = null;

                        //売掛金・買掛金集計モジュール呼出
                        status = _monthlyAddUpDB.ReadSuplAccPayByAddUpSecCode(ref paraObj2, out retMsg);

                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            //取得成功
                            //取得結果キャスト
                            ArrayList SuplAccRecResult = new ArrayList();
                            SuplAccRecResult.Add((SuplAccPayWork)paraObj2);

                            //取得結果セット
                            for (int j = 0; j < SuplAccRecResult.Count; j++)
                            {
                                //0:全て 1:0とﾌﾟﾗｽ 2:ﾌﾟﾗｽのみ 3:0のみ 4:ﾌﾟﾗｽとﾏｲﾅｽ 5:0とﾏｲﾅｽ 6:ﾏｲﾅｽのみ
                                switch (_sumAccPaymentListCndtnWork.OutMoneyDiv)
                                {
                                    case 0:  //0:全て
                                        break;
                                    case 1:  //1:0とﾌﾟﾗｽ -> 0以下の場合はcontinue
                                        if (((SuplAccPayWork)SuplAccRecResult[j]).StckTtlAccPayBalance < 0) continue;
                                        break;
                                    case 2:  //2:ﾌﾟﾗｽのみ -> 0未満の場合はcontinue
                                        if (((SuplAccPayWork)SuplAccRecResult[j]).StckTtlAccPayBalance <= 0) continue;
                                        break;
                                    case 3:  //3:0のみ -> 0以外の場合はcontinue
                                        if (((SuplAccPayWork)SuplAccRecResult[j]).StckTtlAccPayBalance != 0) continue;
                                        break;
                                    case 4:  //4:ﾌﾟﾗｽとﾏｲﾅｽ -> 0の場合はcontinue
                                        if (((SuplAccPayWork)SuplAccRecResult[j]).StckTtlAccPayBalance == 0) continue;
                                        break;
                                    case 5:  //0とﾏｲﾅｽ -> 1以上の場合はcontinue
                                        if (((SuplAccPayWork)SuplAccRecResult[j]).StckTtlAccPayBalance > 0) continue;
                                        break;
                                    case 6:  //6:ﾏｲﾅｽのみ -> 0以上の場合はcontinue
                                        if (((SuplAccPayWork)SuplAccRecResult[j]).StckTtlAccPayBalance >= 0) continue;
                                        break;
                                }

                                #region [抽出結果-値セット]
                                SumAccPaymentListResultWork ResultWork = new SumAccPaymentListResultWork();


                                //拠点コード(親) ※仕入先(総括)マスタから
                                ResultWork.SumAddUpSecCode = ((SumAccPaymentListResultWork)SupplierList[i]).SumAddUpSecCode;
                                //拠点名称(親) ※拠点情報設定マスタから
                                ResultWork.SumSectionGuideSnm = ((SumAccPaymentListResultWork)SupplierList[i]).SumSectionGuideSnm;
                                //請求先コード(親) ※仕入先(総括)マスタから
                                ResultWork.SumPayeeCode = ((SumAccPaymentListResultWork)SupplierList[i]).SumPayeeCode;
                                //請求先略称(親) ※仕入先(総括)マスタから
                                ResultWork.SumPayeeSnm = ((SumAccPaymentListResultWork)SupplierList[i]).SumPayeeSnm;

                                //拠点コード(子) ※仕入先(総括)マスタから
                                ResultWork.AddUpSecCode = ((SumAccPaymentListResultWork)SupplierList[i]).AddUpSecCode;
                                //拠点名称(子) ※拠点情報設定マスタから
                                ResultWork.SectionGuideSnm = ((SumAccPaymentListResultWork)SupplierList[i]).SectionGuideSnm;
                                //請求先コード(子) ※仕入先(総括)マスタから
                                ResultWork.PayeeCode = ((SumAccPaymentListResultWork)SupplierList[i]).PayeeCode;
                                //請求先略称(子) ※仕入先(総括)マスタから
                                ResultWork.PayeeSnm = ((SumAccPaymentListResultWork)SupplierList[i]).PayeeSnm;

                                //前月買掛残
                                ResultWork.LastTimeAccPay = ((SuplAccPayWork)SuplAccRecResult[j]).LastTimeAccPay;
                                //当月支払
                                ResultWork.ThisTimePayNrml = ((SuplAccPayWork)SuplAccRecResult[j]).ThisTimePayNrml;
                                //繰越額
                                ResultWork.ThisTimeTtlBlcAcPay = ((SuplAccPayWork)SuplAccRecResult[j]).ThisTimeTtlBlcAcPay;
                                //仕入額
                                ResultWork.OfsThisTimeStock = ((SuplAccPayWork)SuplAccRecResult[j]).OfsThisTimeStock;
                                ResultWork.ThisTimeStockPrice = ((SuplAccPayWork)SuplAccRecResult[j]).ThisTimeStockPrice;
                                //返品値引
                                ResultWork.ThisRgdsDisPric = ((SuplAccPayWork)SuplAccRecResult[j]).ThisStckPricRgds + ((SuplAccPayWork)SuplAccRecResult[j]).ThisStckPricDis;
                                //消費税
                                ResultWork.OfsThisStockTax = ((SuplAccPayWork)SuplAccRecResult[j]).OfsThisStockTax;
                                //当月末残高
                                ResultWork.StckTtlAccPayBalance = ((SuplAccPayWork)SuplAccRecResult[j]).StckTtlAccPayBalance;
                                //枚数
                                ResultWork.StockSlipCount = ((SuplAccPayWork)SuplAccRecResult[j]).StockSlipCount;
                                //手数料
                                ResultWork.ThisTimeFeePayNrml = ((SuplAccPayWork)SuplAccRecResult[j]).ThisTimeFeePayNrml;
                                //値引
                                ResultWork.ThisTimeDisPayNrml = ((SuplAccPayWork)SuplAccRecResult[j]).ThisTimeDisPayNrml;

                                // 0実績チェック
                                if (ResultWork.LastTimeAccPay == 0 && ResultWork.ThisTimeFeePayNrml ==0 &&
                                    ResultWork.ThisTimeDisPayNrml == 0 && ResultWork.OfsThisTimeStock == 0 &&
                                    ResultWork.OfsThisStockTax == 0 && ResultWork.StockSlipCount == 0 &&
                                    ResultWork.ThisTimePayNrml == 0)
                                {
                                    continue;
                                }

                                // --- ADD START 3H 劉星光 2020/04/10 ---------->>>>>
                                // 消費税別内訳印字する
                                if (_sumAccPaymentListCndtnWork.TaxPrintDiv == (int)TaxTotalDiv.TaxTotalON)
                                {
                                    // 締次フラッグ
                                    isCheckOut = false;

                                    // 前回月次更新年月日
                                    DateTime laMonCAddUpUpdDate = ((SuplAccPayWork)SuplAccRecResult[j]).LaMonCAddUpUpdDate;

                                    // 計上拠点コード
                                    string addUpSecCode = ((SuplAccPayWork)SuplAccRecResult[j]).AddUpSecCode.Trim();

                                    // 支払先コード
                                    int payeeCode = ResultWork.PayeeCode;

                                    string payeeKey = addUpSecCode + "_" + payeeCode.ToString("000000");

                                    // 支払先前回月次更新年月日
                                    if (!payeeDateDic.ContainsKey(payeeKey))
                                    {
                                        payeeDateDic.Add(payeeKey, laMonCAddUpUpdDate);
                                    }
                                }
                                // --- ADD END 3H 劉星光 2020/04/10 ----------<<<<<

                                if (AddUpDate != _sumAccPaymentListCndtnWork.AddUpYearMonth)
                                {
                                    //処理月が今回月次処理日+1カ月の場合は、今回月次処理日から当月残高を取得して再計算する
                                    if ((((SuplAccPayWork)SuplAccRecResult2[0]).AddUpSecCode == ResultWork.AddUpSecCode) &&
                                        (((SuplAccPayWork)SuplAccRecResult2[0]).PayeeCode == ResultWork.PayeeCode))
                                    {
                                        ResultWork.LastTimeAccPay = ((SuplAccPayWork)SuplAccRecResult2[0]).StckTtlAccPayBalance; // 前月残高

                                        // 繰越額 = 前回残高 - 今回支払金額
                                        ResultWork.ThisTimeTtlBlcAcPay = (ResultWork.LastTimeAccPay) - ResultWork.ThisTimePayNrml; // 繰越額

                                        // 当月末残高 = 今回繰越残高 + (相殺後今回仕入金額 + 相殺後今回仕入消費税)
                                        ResultWork.StckTtlAccPayBalance = ResultWork.ThisTimeTtlBlcAcPay + (ResultWork.OfsThisTimeStock + ResultWork.OfsThisStockTax); // 当月末残高
                                    }
                                }

                                if (_sumAccPaymentListCndtnWork.PayDtlDiv == (int)PayDtlDiv.PayDtlON)
                                {
                                    //支払データ取得
                                    ArrayList PaymentList = new ArrayList();
                                    status = SearchPaymentProc(ref PaymentList, SuplAccRecResult, ref sqlConnection, logicalMode);
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
                                        throw new Exception("支払データ取得失敗。");
                                    }
                                    if (PaymentList.Count == 0)
                                    {
                                        //該当データなし statusをクリアし次へ
                                        al.Add(ResultWork);
                                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                                        continue;
                                    }
                                    //現金
                                    ResultWork.CashPayment = ((SumAccPaymentListResultWork)PaymentList[0]).CashPayment;
                                    //振込
                                    ResultWork.TrfrPayment = ((SumAccPaymentListResultWork)PaymentList[0]).TrfrPayment;
                                    //小切手
                                    ResultWork.CheckPayment = ((SumAccPaymentListResultWork)PaymentList[0]).CheckPayment;
                                    //手形
                                    ResultWork.DraftPayment = ((SumAccPaymentListResultWork)PaymentList[0]).DraftPayment;
                                    //相殺
                                    ResultWork.OffsetPayment = ((SumAccPaymentListResultWork)PaymentList[0]).OffsetPayment;
                                    //口座振替
                                    ResultWork.FundTransferPayment = ((SumAccPaymentListResultWork)PaymentList[0]).FundTransferPayment;
                                    //その他
                                    ResultWork.OthsPayment = ((SumAccPaymentListResultWork)PaymentList[0]).OthsPayment;

                                    //リアル集計から「当月支払」を取得すると手数料分差が発生することがあるので再チェックを行う
                                    long ThisTimePayNrmlchek;

                                    ThisTimePayNrmlchek = ResultWork.CashPayment + ResultWork.TrfrPayment + ResultWork.CheckPayment
                                                          + ResultWork.DraftPayment + ResultWork.OffsetPayment + ResultWork.FundTransferPayment
                                                          + ResultWork.OthsPayment + ResultWork.ThisTimeFeePayNrml + ResultWork.ThisTimeDisPayNrml;

                                    if (ThisTimePayNrmlchek != ResultWork.ThisTimePayNrml)
                                    {
                                        //当月支払を再セット
                                        ResultWork.ThisTimePayNrml = ThisTimePayNrmlchek;

                                        //繰越額を再セット
                                        ResultWork.ThisTimeTtlBlcAcPay = ResultWork.LastTimeAccPay - ResultWork.ThisTimePayNrml;

                                        //当月未残高を再セット
                                        ResultWork.StckTtlAccPayBalance = ResultWork.ThisTimeTtlBlcAcPay + ResultWork.OfsThisTimeStock + ResultWork.OfsThisStockTax;
                                    }
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
                        SupplierListWork = SupplierList[i] as SumAccPaymentListResultWork;
                        //締め済 -> 仕入先買掛金額マスタから取得
                        //検索実行
                        status = this.SearchAccPaymentProc(ref al, _sumAccPaymentListCndtnWork, SupplierListWork,  ref sqlConnection, logicalMode);
                    }
                }

                // --- ADD START 3H 劉星光 2020/04/10 ---------->>>>>
                if (_sumAccPaymentListCndtnWork.TaxPrintDiv == (int)TaxTotalDiv.TaxTotalON)
                {
                    Dictionary<string, SuplAccPayDateInfo> suplAccPayDateDic = new Dictionary<string, SuplAccPayDateInfo>();
                    // 月次更新を行った場合
                    if (isCheckOut)
                    {
                        // 月次更新処理日取得を行う
                        status = SearchSuplAccPayDate(_sumAccPaymentListCndtnWork, ref suplAccPayDateDic, ref sqlConnection);

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

                    for (int k = 0; k < al.Count; k++)
                    {
                        SumAccPaymentListResultWork sumAccPaymentWork = (SumAccPaymentListResultWork)al[k];

                        // 前回月次更新年月日
                        DateTime laMonCAddUpUpdDate = DateTime.MinValue;

                        if (!isCheckOut)
                        {
                            // 前回月次更新年月日取得
                            payeeDateDic.TryGetValue(sumAccPaymentWork.AddUpSecCode.Trim() + "_" + sumAccPaymentWork.PayeeCode.ToString("000000"), out laMonCAddUpUpdDate);
                        }

                        //仕入データ取得
                        status = SearchStockProc(ref sumAccPaymentWork, ref sqlConnection, _sumAccPaymentListCndtnWork, isCheckOut, laMonCAddUpUpdDate, suplAccPayDateDic);

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
                            throw new Exception("仕入データ取得失敗。");
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
                base.WriteErrorLog(ex, "SumAccPaymentListWorkDB.SearchProc Exception=" + ex.Message);
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

            // --- UPD START 3H 劉星光 2020/04/10 ---------->>>>>
            //if (al.Count > 0)
            //{
            //    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            //}
            if (_sumAccPaymentListCndtnWork.TaxPrintDiv == (int)TaxTotalDiv.TaxTotalOFF)
            {
                if (al.Count > 0)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            // --- UPD END 3H 劉星光 2020/04/10 ----------<<<<<

            sumAccPaymentListResultWork = al;

            return status;
        }
        #endregion  //[SearchProc]

        #region [SearchSuppProc]
        /// <summary>
        /// 仕入先マスタ(総括設定)から条件に該当する総括仕入先(親)を検索し、仕入先(子)を抽出します。
        /// </summary>
        /// <param name="al">検索結果</param>
        /// <param name="_sumAccPaymentListCndtnWork">検索パラメータ</param>
        /// <param name="sqlConnection">コネクション情報</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の総括仕入先リストを戻します</br>
        /// <br>Programmer : FSI冨樫 紗由里</br>
        /// <br>Date       : 2012/09/14</br>
        private int SearchSuppProc(ref ArrayList al, SumAccPaymentListCndtnWork _sumAccPaymentListCndtnWork, ref SqlConnection sqlConnection, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                StringBuilder sqlStr = new StringBuilder();
                sqlCommand = new SqlCommand("", sqlConnection);

                // 対象テーブル
                // SUMSUPPSTRF       SUM_SUP 仕入先マスタ(総括設定)
                // SUPPLIERRF        SUPLER 仕入先マスタ
                // SECINFOSETRF      SCINST 拠点情報設定マスタ

                #region [Select文作成]
                sqlStr.Append("SELECT" + Environment.NewLine);
                sqlStr.Append("  SUM_LIST.SUMSECTIONCDRF AS SUMSECTIONCDRF" + Environment.NewLine);          //(総括)拠点コード
                sqlStr.Append(" ,SUM_LIST.SECTIONGUIDESNMRF AS SUMSECTIONGUIDESNMRF" + Environment.NewLine); //(総括)拠点略称
                sqlStr.Append(" ,SUM_LIST.SUMSUPPLIERCDRF AS SUMPAYEECODERF" + Environment.NewLine);         //(総括)仕入先コード
                sqlStr.Append(" ,SUM_LIST.SUPPLIERSNMRF AS SUMPAYEESNMRF" + Environment.NewLine);            //(総括)仕入先略称
                sqlStr.Append(" ,SUM_LIST.SECTIONCODERF AS SECTIONCODERF" + Environment.NewLine);            //(子)拠点コード
                sqlStr.Append(" ,SUM_LIST.SUPPLIERCDRF AS PAYEECODERF" + Environment.NewLine);               //(子)仕入先コード
                sqlStr.Append(" ,SECINFOSET.SECTIONGUIDESNMRF AS SECTIONGUIDESNMRF" + Environment.NewLine);  //(子)拠点略称
                sqlStr.Append(" ,SUPPLIER.SUPPLIERSNMRF AS PAYEESNMRF" + Environment.NewLine);               //(子)仕入先略称
                //FROM
                sqlStr.Append(" FROM" + Environment.NewLine);
                sqlStr.Append(" (" + Environment.NewLine);
                sqlStr.Append("     SELECT" + Environment.NewLine);
                sqlStr.Append("          SUM_SUP.ENTERPRISECODERF" + Environment.NewLine);
                sqlStr.Append("         ,SUM_SUP.SUMSECTIONCDRF" + Environment.NewLine);
                sqlStr.Append("         ,SECINFOSET.SECTIONGUIDESNMRF" + Environment.NewLine);
                sqlStr.Append("         ,SUM_SUP.SUMSUPPLIERCDRF" + Environment.NewLine);
                sqlStr.Append("         ,SUM_SUP.SECTIONCODERF" + Environment.NewLine);
                sqlStr.Append("         ,SUM_SUP.SUPPLIERCDRF" + Environment.NewLine);
                sqlStr.Append("         ,SUPPLIER.SUPPLIERSNMRF" + Environment.NewLine);
                sqlStr.Append("         FROM" + Environment.NewLine);
                sqlStr.Append("             SUMSUPPSTRF AS SUM_SUP" + Environment.NewLine);
                sqlStr.Append("             LEFT JOIN" + Environment.NewLine);
                sqlStr.Append("             (" + Environment.NewLine);
                sqlStr.Append("                 SELECT" + Environment.NewLine);
                sqlStr.Append("                      SCINST.ENTERPRISECODERF" + Environment.NewLine);
                sqlStr.Append("                     ,SCINST.SECTIONGUIDESNMRF" + Environment.NewLine);
                sqlStr.Append("                     ,SCINST.SECTIONCODERF" + Environment.NewLine);
                sqlStr.Append("                 FROM" + Environment.NewLine);
                sqlStr.Append("                     SECINFOSETRF AS SCINST" + Environment.NewLine);
                sqlStr.Append("                 GROUP BY" + Environment.NewLine);
                sqlStr.Append("                      SCINST.ENTERPRISECODERF" + Environment.NewLine);
                sqlStr.Append("                     ,SCINST.SECTIONGUIDESNMRF" + Environment.NewLine);
                sqlStr.Append("                     ,SCINST.SECTIONCODERF" + Environment.NewLine);
                sqlStr.Append("             ) AS SECINFOSET" + Environment.NewLine);
                sqlStr.Append("             ON   SECINFOSET.ENTERPRISECODERF = SUM_SUP.ENTERPRISECODERF" + Environment.NewLine);
                sqlStr.Append("             AND  SECINFOSET.SECTIONCODERF = SUM_SUP.SUMSECTIONCDRF" + Environment.NewLine);
                sqlStr.Append("             LEFT JOIN" + Environment.NewLine);
                sqlStr.Append("             (" + Environment.NewLine);
                sqlStr.Append("                 SELECT" + Environment.NewLine);
                sqlStr.Append("                      PARENT_SUP.ENTERPRISECODERF" + Environment.NewLine);
                sqlStr.Append("                     ,PARENT_SUP.SUPPLIERSNMRF" + Environment.NewLine);
                sqlStr.Append("                     ,PARENT_SUP.SUPPLIERCDRF" + Environment.NewLine);
                sqlStr.Append("                 FROM" + Environment.NewLine);
                sqlStr.Append("                     SUPPLIERRF AS PARENT_SUP" + Environment.NewLine);
                sqlStr.Append("                 GROUP BY" + Environment.NewLine);
                sqlStr.Append("                      PARENT_SUP.ENTERPRISECODERF" + Environment.NewLine);
                sqlStr.Append("                     ,PARENT_SUP.SUPPLIERSNMRF" + Environment.NewLine);
                sqlStr.Append("                     ,PARENT_SUP.SUPPLIERCDRF" + Environment.NewLine);
                sqlStr.Append("             ) AS SUPPLIER" + Environment.NewLine);
                sqlStr.Append("             ON	SUPPLIER.ENTERPRISECODERF = SUM_SUP.ENTERPRISECODERF" + Environment.NewLine);
                sqlStr.Append("             AND	SUPPLIER.SUPPLIERCDRF = SUM_SUP.SUMSUPPLIERCDRF" + Environment.NewLine);

                #region [WHERE句]
                sqlStr.Append(" WHERE" + Environment.NewLine);

                //企業コード
                sqlStr.Append(" SUM_SUP.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine);
                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(_sumAccPaymentListCndtnWork.EnterpriseCode);

                //論理削除区分
                if ((logicalMode == ConstantManagement.LogicalMode.GetData0) || (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData2) || (logicalMode == ConstantManagement.LogicalMode.GetData3))
                {
                    sqlStr.Append(" AND SUM_SUP.LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + Environment.NewLine);
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
                }
                else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) || (logicalMode == ConstantManagement.LogicalMode.GetData012))
                {
                    sqlStr.Append(" AND SUM_SUP.LOGICALDELETECODERF<@FINDLOGICALDELETECODE" + Environment.NewLine);
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                    if (logicalMode == ConstantManagement.LogicalMode.GetData01) paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
                    else paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
                }

                //総括拠点コード
                if (_sumAccPaymentListCndtnWork.SectionCodes != null)
                {
                    string sectionCodestr = "";
                    foreach (string seccdstr in _sumAccPaymentListCndtnWork.SectionCodes)
                    {
                        if (sectionCodestr != "")
                        {
                            sectionCodestr += ",";
                        }
                        sectionCodestr += "'" + seccdstr + "'";
                    }
                    if (sectionCodestr != "")
                    {
                        sqlStr.Append(" AND SUM_SUP.SUMSECTIONCDRF IN (" + sectionCodestr + ") ");
                    }
                    sqlStr.Append(Environment.NewLine);
                }

                //総括仕入先コード
                if (_sumAccPaymentListCndtnWork.St_PayeeCode != 0)
                {
                    sqlStr.Append(" AND SUM_SUP.SUMSUPPLIERCDRF>=@ST_SUPPLIERCD" + Environment.NewLine);
                    SqlParameter paraSt_SupplierCd = sqlCommand.Parameters.Add("@ST_SUPPLIERCD", SqlDbType.Int);
                    paraSt_SupplierCd.Value = SqlDataMediator.SqlSetInt32(_sumAccPaymentListCndtnWork.St_PayeeCode);
                }
                if (_sumAccPaymentListCndtnWork.St_PayeeCode != 999999)
                {
                    sqlStr.Append(" AND SUM_SUP.SUMSUPPLIERCDRF<=@ED_SUPPLIERCD" + Environment.NewLine);
                    SqlParameter paraEd_PayeeCode = sqlCommand.Parameters.Add("@ED_SUPPLIERCD", SqlDbType.Int);
                    paraEd_PayeeCode.Value = SqlDataMediator.SqlSetInt32(_sumAccPaymentListCndtnWork.Ed_PayeeCode);
                }
                #endregion  //[WHERE句]

                sqlStr.Append(" ) AS SUM_LIST" + Environment.NewLine);

                //JOIN
                // 仕入先マスタ(総括用)
                sqlStr.Append(" LEFT JOIN SUPPLIERRF AS SUPPLIER" + Environment.NewLine);
                sqlStr.Append(" ON  SUPPLIER.ENTERPRISECODERF = SUM_LIST.ENTERPRISECODERF" + Environment.NewLine);
                sqlStr.Append(" AND SUPPLIER.SUPPLIERCDRF = SUM_LIST.SUPPLIERCDRF" + Environment.NewLine);

                //拠点情報設定マスタ(総括用)
                sqlStr.Append(" LEFT JOIN SECINFOSETRF SECINFOSET" + Environment.NewLine);
                sqlStr.Append(" ON  SECINFOSET.ENTERPRISECODERF = SUM_LIST.ENTERPRISECODERF" + Environment.NewLine);
                sqlStr.Append(" AND SECINFOSET.SECTIONCODERF = SUM_LIST.SECTIONCODERF" + Environment.NewLine);

                #endregion  //[Select文作成]

                sqlCommand.CommandText = sqlStr.ToString();

                sqlCommand.CommandTimeout = 600;

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    SumAccPaymentListResultWork ResultWork = new SumAccPaymentListResultWork();

                    #region [抽出結果-値セット]
                    ResultWork.SumAddUpSecCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUMSECTIONCDRF"));
                    ResultWork.SumSectionGuideSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUMSECTIONGUIDESNMRF"));
                    ResultWork.SumPayeeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUMPAYEECODERF"));
                    ResultWork.SumPayeeSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUMPAYEESNMRF"));
                    ResultWork.AddUpSecCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
                    ResultWork.PayeeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYEECODERF"));
                    ResultWork.SectionGuideSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDESNMRF"));
                    ResultWork.PayeeSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYEESNMRF"));
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
                base.WriteErrorLog(ex, "SumAccPaymentListWorkDB.SearchSuppProc Exception=" + ex.Message);
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
        #endregion  //[SearchSuppProc]

        #region [SearchPaymentProc]
        /// <summary>
        /// 未締めの支払データを取得します。
        /// </summary>
        /// <param name="al">検索結果</param>
        /// <param name="suplAccPayWork">検索パラメータ</param>
        /// <param name="sqlConnection">コネクション情報</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 未締めの支払データを取得します</br>
        /// <br>Programmer : FSI菅原 庸平</br>
        /// <br>Date       : 2012/11/07</br>
        private int SearchPaymentProc(ref ArrayList al, ArrayList suplAccPayWork, ref SqlConnection sqlConnection, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                string selectTxt = "";
                sqlCommand = new SqlCommand(selectTxt, sqlConnection);

                // 対象テーブル
                // PAYMENTSLPRF      PAYSLP 支払伝票マスタ
                // PAYMENTDTLRF      PAYDTL 支払明細データ

                #region [Select文作成]
                selectTxt += "SELECT" + Environment.NewLine;
                selectTxt += "   PAYSLP.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "  ,PAYSLP.ADDUPSECCODERF" + Environment.NewLine;
                selectTxt += "  ,PAYSLP.SUPPLIERCDRF" + Environment.NewLine;
                selectTxt += "  ,PAYSLP.PAYEECODERF" + Environment.NewLine;
                selectTxt += "  ,SUM((CASE WHEN PAYDTL.MONEYKINDCODERF=51 THEN PAYDTL.PAYMENTRF ELSE 0 END)) AS CASHPAYMENT" + Environment.NewLine;
                selectTxt += "  ,SUM((CASE WHEN PAYDTL.MONEYKINDCODERF=52 THEN PAYDTL.PAYMENTRF ELSE 0 END)) AS TRFRPAYMENT" + Environment.NewLine;
                selectTxt += "  ,SUM((CASE WHEN PAYDTL.MONEYKINDCODERF=53 THEN PAYDTL.PAYMENTRF ELSE 0 END)) AS CHECKPAYMENT" + Environment.NewLine;
                selectTxt += "  ,SUM((CASE WHEN PAYDTL.MONEYKINDCODERF=54 THEN PAYDTL.PAYMENTRF ELSE 0 END)) AS DRAFTPAYMENT" + Environment.NewLine;
                selectTxt += "  ,SUM((CASE WHEN PAYDTL.MONEYKINDCODERF=56 THEN PAYDTL.PAYMENTRF ELSE 0 END)) AS OFFSETPAYMENT" + Environment.NewLine;
                selectTxt += "  ,SUM((CASE WHEN PAYDTL.MONEYKINDCODERF=59 THEN PAYDTL.PAYMENTRF ELSE 0 END)) AS FUNDTRANSFERPAYMENT" + Environment.NewLine;
                selectTxt += "  ,(SUM(PAYDTL.PAYMENTRF)" + Environment.NewLine;
                selectTxt += "   -SUM((CASE WHEN PAYDTL.MONEYKINDCODERF=51 THEN PAYDTL.PAYMENTRF ELSE 0 END))" + Environment.NewLine;
                selectTxt += "   -SUM((CASE WHEN PAYDTL.MONEYKINDCODERF=52 THEN PAYDTL.PAYMENTRF ELSE 0 END))" + Environment.NewLine;
                selectTxt += "   -SUM((CASE WHEN PAYDTL.MONEYKINDCODERF=53 THEN PAYDTL.PAYMENTRF ELSE 0 END))" + Environment.NewLine;
                selectTxt += "   -SUM((CASE WHEN PAYDTL.MONEYKINDCODERF=54 THEN PAYDTL.PAYMENTRF ELSE 0 END))" + Environment.NewLine;
                selectTxt += "   -SUM((CASE WHEN PAYDTL.MONEYKINDCODERF=56 THEN PAYDTL.PAYMENTRF ELSE 0 END))" + Environment.NewLine;
                selectTxt += "   -SUM((CASE WHEN PAYDTL.MONEYKINDCODERF=59 THEN PAYDTL.PAYMENTRF ELSE 0 END))" + Environment.NewLine;
                selectTxt += "   ) AS OTHSPAYMENT" + Environment.NewLine;
                //FROM
                selectTxt += " FROM PAYMENTSLPRF AS PAYSLP" + Environment.NewLine;
                //JOIN
                selectTxt += " INNER JOIN PAYMENTDTLRF AS PAYDTL" + Environment.NewLine;
                selectTxt += " ON  PAYDTL.ENTERPRISECODERF=PAYSLP.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND PAYDTL.SUPPLIERFORMALRF=PAYSLP.SUPPLIERFORMALRF" + Environment.NewLine;
                selectTxt += " AND PAYDTL.PAYMENTSLIPNORF=PAYSLP.PAYMENTSLIPNORF" + Environment.NewLine;
                selectTxt += " AND PAYDTL.LOGICALDELETECODERF=0" + Environment.NewLine;
                //WHERE
                selectTxt += " WHERE" + Environment.NewLine;
                selectTxt += "      PAYSLP.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                selectTxt += "  AND PAYSLP.DEBITNOTEDIVRF=0" + Environment.NewLine;
                selectTxt += "  AND PAYSLP.SUPPLIERCDRF=@FINDSUPPLIERCD" + Environment.NewLine;
                selectTxt += "  AND PAYSLP.PAYEECODERF=@FINDPAYEECODE" + Environment.NewLine;
                selectTxt += "  AND PAYSLP.ADDUPSECCODERF=@FINDADDUPSECCODE" + Environment.NewLine;
                selectTxt += "  AND PAYSLP.LOGICALDELETECODERF=0" + Environment.NewLine;
                selectTxt += "  AND (PAYSLP.ADDUPADATERF<=@FINDADDUPDATE AND PAYSLP.ADDUPADATERF>@FINDLASTTIMEADDUPDATE)" + Environment.NewLine;
                //GROUP BY
                selectTxt += " GROUP BY" + Environment.NewLine;
                selectTxt += "   PAYSLP.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "  ,PAYSLP.ADDUPSECCODERF" + Environment.NewLine;
                selectTxt += "  ,PAYSLP.SUPPLIERCDRF" + Environment.NewLine;
                selectTxt += "  ,PAYSLP.PAYEECODERF" + Environment.NewLine;
                #endregion  //[Select文作成]

                sqlCommand.CommandText = selectTxt;

                //Prameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaSupplierCd = sqlCommand.Parameters.Add("@FINDSUPPLIERCD", SqlDbType.Int);
                SqlParameter findParaPayeeCode = sqlCommand.Parameters.Add("@FINDPAYEECODE", SqlDbType.Int);
                SqlParameter findParaAddUpSecCode = sqlCommand.Parameters.Add("@FINDADDUPSECCODE", SqlDbType.NChar);
                SqlParameter findParaAddUpDate = sqlCommand.Parameters.Add("@FINDADDUPDATE", SqlDbType.Int);
                SqlParameter findParaLastTimeAddUpDate = sqlCommand.Parameters.Add("@FINDLASTTIMEADDUPDATE", SqlDbType.Int);

                //Parameterオブジェクトへ値設定
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(((SuplAccPayWork)suplAccPayWork[0]).EnterpriseCode);
                findParaSupplierCd.Value = SqlDataMediator.SqlSetInt32(((SuplAccPayWork)suplAccPayWork[0]).SupplierCd);
                findParaPayeeCode.Value = SqlDataMediator.SqlSetInt32(((SuplAccPayWork)suplAccPayWork[0]).PayeeCode);
                findParaAddUpSecCode.Value = SqlDataMediator.SqlSetString(((SuplAccPayWork)suplAccPayWork[0]).AddUpSecCode);
                findParaAddUpDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(((SuplAccPayWork)suplAccPayWork[0]).AddUpDate);
                if (((SuplAccPayWork)suplAccPayWork[0]).LaMonCAddUpUpdDate == DateTime.MinValue)
                    findParaLastTimeAddUpDate.Value = 20000101;
                else
                    findParaLastTimeAddUpDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(((SuplAccPayWork)suplAccPayWork[0]).LaMonCAddUpUpdDate);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    SumAccPaymentListResultWork ResultWork = new SumAccPaymentListResultWork();

                    #region [抽出結果-値セット]
                    ResultWork.CashPayment = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("CASHPAYMENT"));
                    ResultWork.TrfrPayment = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TRFRPAYMENT"));
                    ResultWork.CheckPayment = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("CHECKPAYMENT"));
                    ResultWork.DraftPayment = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DRAFTPAYMENT"));
                    ResultWork.OffsetPayment = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("OFFSETPAYMENT"));
                    ResultWork.FundTransferPayment = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("FUNDTRANSFERPAYMENT"));
                    ResultWork.OthsPayment = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("OTHSPAYMENT"));
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
                base.WriteErrorLog(ex, "AccPaymentListWorkDB.SearchPaymentProc Exception=" + ex.Message);
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
        #endregion  //[SearchPaymentProc]

        #region [SearchAccPaymentProc]
        /// <summary>
        /// 指定された条件の買掛残高一覧表（総括）を戻します
        /// </summary>
        /// <param name="al">検索結果</param>
        /// <param name="_sumAccPaymentListCndtnWork">検索パラメータ</param>
        /// <param name="SupplierListWork">SupplierListWork</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の売掛残高一覧表を戻します</br>
        /// <br>Programmer : FSI冨樫 紗由里</br>
        /// <br>Date       : 2012/09/14</br>
        private int SearchAccPaymentProc(ref ArrayList al, SumAccPaymentListCndtnWork _sumAccPaymentListCndtnWork, SumAccPaymentListResultWork SupplierListWork, ref SqlConnection sqlConnection, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                StringBuilder sqlStr = new StringBuilder();
                sqlCommand = new SqlCommand("", sqlConnection);

                // 対象テーブル
                // SUPLACCPAYRF      SUPPAY 仕入先買掛金額マスタ
                // ACALCPAYTOTALRF   ACAPAY 買掛支払集計データ
                // SECINFOSETRF      SCINST 拠点情報設定マスタ

                #region [Select文作成]
                sqlStr.Append("SELECT" + Environment.NewLine);
                sqlStr.Append("   SUPPAY.ADDUPSECCODERF" + Environment.NewLine);
                sqlStr.Append("  ,SCINST.SECTIONGUIDESNMRF" + Environment.NewLine);
                sqlStr.Append("  ,SUPPAY.PAYEECODERF" + Environment.NewLine);
                sqlStr.Append("  ,SUPPAY.PAYEESNMRF" + Environment.NewLine);
                sqlStr.Append("  ,SUPPAY.LASTTIMEACCPAYRF" + Environment.NewLine);
                sqlStr.Append("  ,SUPPAY.THISTIMEPAYNRMLRF" + Environment.NewLine);
                sqlStr.Append("  ,SUPPAY.THISTIMETTLBLCACPAYRF" + Environment.NewLine);
                sqlStr.Append("  ,SUPPAY.OFSTHISTIMESTOCKRF" + Environment.NewLine);
                sqlStr.Append("  ,(SUPPAY.THISSTCKPRICRGDSRF+SUPPAY.THISSTCKPRICDISRF)" + Environment.NewLine);
                sqlStr.Append("   AS THISRGDSDISPRIC" + Environment.NewLine);
                sqlStr.Append("  ,SUPPAY.OFSTHISSTOCKTAXRF" + Environment.NewLine);
                sqlStr.Append("  ,SUPPAY.STCKTTLACCPAYBALANCERF" + Environment.NewLine);
                sqlStr.Append("  ,SUPPAY.STOCKSLIPCOUNTRF" + Environment.NewLine);
                sqlStr.Append("  ,SUPPAY.THISTIMEFEEPAYNRMLRF" + Environment.NewLine);
                sqlStr.Append("  ,SUPPAY.THISTIMEDISPAYNRMLRF" + Environment.NewLine);
                sqlStr.Append("  ,SUPPAY.CASHPAYMENT" + Environment.NewLine);
                sqlStr.Append("  ,SUPPAY.TRFRPAYMENT" + Environment.NewLine);
                sqlStr.Append("  ,SUPPAY.CHECKPAYMENT" + Environment.NewLine);
                sqlStr.Append("  ,SUPPAY.DRAFTPAYMENT" + Environment.NewLine);
                sqlStr.Append("  ,SUPPAY.OFFSETPAYMENT" + Environment.NewLine);
                sqlStr.Append("  ,SUPPAY.FUNDTRANSFERPAYMENT" + Environment.NewLine);
                sqlStr.Append("  ,SUPPAY.OTHSPAYMENT" + Environment.NewLine);
                sqlStr.Append("  ,SUPPAY.THISTIMESTOCKPRICERF" + Environment.NewLine);
                //FROM
                sqlStr.Append(" FROM" + Environment.NewLine);
                sqlStr.Append(" (" + Environment.NewLine);

                #region [データ抽出メインQuery]
                //仕入先買掛金額マスタ
                sqlStr.Append("  SELECT" + Environment.NewLine);
                sqlStr.Append("    SUPPAYSUB.ENTERPRISECODERF" + Environment.NewLine);
                sqlStr.Append("   ,SUPPAYSUB.ADDUPSECCODERF" + Environment.NewLine);
                sqlStr.Append("   ,SUPPAYSUB.PAYEECODERF" + Environment.NewLine);
                sqlStr.Append("   ,SUPPAYSUB.PAYEESNMRF" + Environment.NewLine);
                sqlStr.Append("   ,SUPPAYSUB.LASTTIMEACCPAYRF" + Environment.NewLine);
                sqlStr.Append("   ,SUPPAYSUB.THISTIMEPAYNRMLRF" + Environment.NewLine);
                sqlStr.Append("   ,SUPPAYSUB.THISTIMETTLBLCACPAYRF" + Environment.NewLine);
                sqlStr.Append("   ,SUPPAYSUB.OFSTHISTIMESTOCKRF" + Environment.NewLine);
                sqlStr.Append("   ,SUPPAYSUB.THISSTCKPRICRGDSRF" + Environment.NewLine);
                sqlStr.Append("   ,SUPPAYSUB.THISSTCKPRICDISRF" + Environment.NewLine);
                sqlStr.Append("   ,SUPPAYSUB.OFSTHISSTOCKTAXRF" + Environment.NewLine);
                sqlStr.Append("   ,SUPPAYSUB.STCKTTLACCPAYBALANCERF" + Environment.NewLine);
                sqlStr.Append("   ,SUPPAYSUB.STOCKSLIPCOUNTRF" + Environment.NewLine);
                sqlStr.Append("   ,SUPPAYSUB.THISTIMEFEEPAYNRMLRF" + Environment.NewLine);
                sqlStr.Append("   ,SUPPAYSUB.THISTIMEDISPAYNRMLRF" + Environment.NewLine);
                sqlStr.Append("   ,SUPPAYSUB.THISTIMESTOCKPRICERF" + Environment.NewLine);
                sqlStr.Append("   ,ACAPAY.CASHPAYMENT" + Environment.NewLine);
                sqlStr.Append("   ,ACAPAY.TRFRPAYMENT" + Environment.NewLine);
                sqlStr.Append("   ,ACAPAY.CHECKPAYMENT" + Environment.NewLine);
                sqlStr.Append("   ,ACAPAY.DRAFTPAYMENT" + Environment.NewLine);
                sqlStr.Append("   ,ACAPAY.OFFSETPAYMENT" + Environment.NewLine);
                sqlStr.Append("   ,ACAPAY.FUNDTRANSFERPAYMENT" + Environment.NewLine);
                sqlStr.Append("   ,(ACAPAY.OTHSPAYMENT" + Environment.NewLine);
                sqlStr.Append("    -ACAPAY.CASHPAYMENT" + Environment.NewLine);
                sqlStr.Append("    -ACAPAY.TRFRPAYMENT" + Environment.NewLine);
                sqlStr.Append("    -ACAPAY.CHECKPAYMENT" + Environment.NewLine);
                sqlStr.Append("    -ACAPAY.DRAFTPAYMENT" + Environment.NewLine);
                sqlStr.Append("    -ACAPAY.OFFSETPAYMENT" + Environment.NewLine);
                sqlStr.Append("    -ACAPAY.FUNDTRANSFERPAYMENT" + Environment.NewLine);
                sqlStr.Append("    ) AS OTHSPAYMENT" + Environment.NewLine);
                sqlStr.Append(" FROM SUPLACCPAYRF AS SUPPAYSUB" + Environment.NewLine);

                //買掛支払集計データ
                sqlStr.Append("  LEFT JOIN" + Environment.NewLine);
                sqlStr.Append("  (" + Environment.NewLine);
                sqlStr.Append("   SELECT" + Environment.NewLine);
                sqlStr.Append("     ACAPAYSUB.ENTERPRISECODERF" + Environment.NewLine);
                sqlStr.Append("    ,ACAPAYSUB.ADDUPSECCODERF" + Environment.NewLine);
                sqlStr.Append("    ,ACAPAYSUB.PAYEECODERF" + Environment.NewLine);
                sqlStr.Append("    ,ACAPAYSUB.SUPPLIERCDRF" + Environment.NewLine);
                sqlStr.Append("    ,ACAPAYSUB.ADDUPDATERF" + Environment.NewLine);
                sqlStr.Append("    ,SUM((CASE WHEN ACAPAYSUB.MONEYKINDCODERF=51 THEN ACAPAYSUB.PAYMENTRF ELSE 0 END)) AS CASHPAYMENT" + Environment.NewLine);
                sqlStr.Append("    ,SUM((CASE WHEN ACAPAYSUB.MONEYKINDCODERF=52 THEN ACAPAYSUB.PAYMENTRF ELSE 0 END)) AS TRFRPAYMENT" + Environment.NewLine);
                sqlStr.Append("    ,SUM((CASE WHEN ACAPAYSUB.MONEYKINDCODERF=53 THEN ACAPAYSUB.PAYMENTRF ELSE 0 END)) AS CHECKPAYMENT" + Environment.NewLine);
                sqlStr.Append("    ,SUM((CASE WHEN ACAPAYSUB.MONEYKINDCODERF=54 THEN ACAPAYSUB.PAYMENTRF ELSE 0 END)) AS DRAFTPAYMENT" + Environment.NewLine);
                sqlStr.Append("    ,SUM((CASE WHEN ACAPAYSUB.MONEYKINDCODERF=56 THEN ACAPAYSUB.PAYMENTRF ELSE 0 END)) AS OFFSETPAYMENT" + Environment.NewLine);
                sqlStr.Append("    ,SUM((CASE WHEN ACAPAYSUB.MONEYKINDCODERF=59 THEN ACAPAYSUB.PAYMENTRF ELSE 0 END)) AS FUNDTRANSFERPAYMENT" + Environment.NewLine);
                sqlStr.Append("    ,SUM(ACAPAYSUB.PAYMENTRF) AS OTHSPAYMENT" + Environment.NewLine);
                sqlStr.Append("   FROM ACALCPAYTOTALRF AS ACAPAYSUB" + Environment.NewLine);
                sqlStr.Append("   GROUP BY" + Environment.NewLine);
                sqlStr.Append("     ACAPAYSUB.ENTERPRISECODERF" + Environment.NewLine);
                sqlStr.Append("    ,ACAPAYSUB.ADDUPSECCODERF" + Environment.NewLine);
                sqlStr.Append("    ,ACAPAYSUB.PAYEECODERF" + Environment.NewLine);
                sqlStr.Append("    ,ACAPAYSUB.SUPPLIERCDRF" + Environment.NewLine);
                sqlStr.Append("    ,ACAPAYSUB.ADDUPDATERF" + Environment.NewLine);
                sqlStr.Append("  ) AS ACAPAY" + Environment.NewLine);
                sqlStr.Append("  ON  ACAPAY.ENTERPRISECODERF=SUPPAYSUB.ENTERPRISECODERF" + Environment.NewLine);
                sqlStr.Append("  AND ACAPAY.ADDUPSECCODERF=SUPPAYSUB.ADDUPSECCODERF" + Environment.NewLine);
                sqlStr.Append("  AND ACAPAY.PAYEECODERF=SUPPAYSUB.PAYEECODERF" + Environment.NewLine);
                sqlStr.Append("  AND ACAPAY.ADDUPDATERF=SUPPAYSUB.ADDUPDATERF" + Environment.NewLine);

                //WHERE文の作成
                sqlStr.Append(MakeWhereString(ref sqlCommand, _sumAccPaymentListCndtnWork, SupplierListWork, logicalMode));
                #endregion  //[データ抽出メインQuery]

                sqlStr.Append(" ) AS SUPPAY" + Environment.NewLine);

                #region [JOIN]
                //拠点情報設定マスタ(子)
                sqlStr.Append(" LEFT JOIN SECINFOSETRF SCINST ON" + Environment.NewLine);
                sqlStr.Append(" (SCINST.ENTERPRISECODERF=SUPPAY.ENTERPRISECODERF" + Environment.NewLine);
                sqlStr.Append("    AND SCINST.SECTIONCODERF=SUPPAY.ADDUPSECCODERF" + Environment.NewLine);
                sqlStr.Append(" )" + Environment.NewLine);
                #endregion  //[JOIN]

                #endregion  //[Select文作成]

                sqlCommand.CommandText = sqlStr.ToString();

                sqlCommand.CommandTimeout = 600;

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    al.Add(CopyToRsltWork(ref myReader, _sumAccPaymentListCndtnWork, SupplierListWork));
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
                base.WriteErrorLog(ex, "SumAccPaymentListWorkDB.SearchAccPaymentProc Exception=" + ex.Message);
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
        #endregion  //[SearchAccPaymentProc]

        #region [WHERE句生成処理]
        /// <summary>
        /// WHERE句生成処理
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="_sumAccPaymentListCndtnWork">検索条件格納クラス</param>
        /// <param name="SupplierListWork">SupplierListWork</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>買掛残高元帳抽出のSQL文字列</returns>
        /// <br>Note       : WHERE句生成処理</br>
        /// <br>Programmer : FSI冨樫 紗由里</br>
        /// <br>Date       : 2012/09/14</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, SumAccPaymentListCndtnWork _sumAccPaymentListCndtnWork, SumAccPaymentListResultWork SupplierListWork,  ConstantManagement.LogicalMode logicalMode)
        {
            #region WHERE文作成
            StringBuilder retString = new StringBuilder();
            retString.Append(" WHERE" + Environment.NewLine);

            //企業コード
            retString.Append(" SUPPAYSUB.ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine);
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(_sumAccPaymentListCndtnWork.EnterpriseCode);

            //論理削除区分
            if ((logicalMode == ConstantManagement.LogicalMode.GetData0) || (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData2) || (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                retString.Append(" AND SUPPAYSUB.LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + Environment.NewLine);
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
            }
            else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) || (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                retString.Append(" AND SUPPAYSUB.LOGICALDELETECODERF<@FINDLOGICALDELETECODE" + Environment.NewLine);
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                if (logicalMode == ConstantManagement.LogicalMode.GetData01) paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
                else paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
            }

            //集計レコードのみを対象とする(仕入先コード=0のみ対象)
            retString.Append(" AND SUPPAYSUB.SUPPLIERCDRF=0" + Environment.NewLine);

            //拠点コード
           if (SupplierListWork.AddUpSecCode != null)
            {
                retString.Append(" AND SUPPAYSUB.ADDUPSECCODERF = @ADDUPSECCODE");
                SqlParameter paraAddupsecCode = sqlCommand.Parameters.Add("@ADDUPSECCODE", SqlDbType.NChar);
                paraAddupsecCode.Value = SqlDataMediator.SqlSetString(SupplierListWork.AddUpSecCode);
            }

            //対象年月
            if (_sumAccPaymentListCndtnWork.AddUpYearMonth != DateTime.MinValue)
            {
                retString.Append(" AND SUPPAYSUB.ADDUPYEARMONTHRF=@ADDUPYEARMONTH" + Environment.NewLine);
                SqlParameter paraSt_AddUpYearMonth = sqlCommand.Parameters.Add("@ADDUPYEARMONTH", SqlDbType.Int);
                paraSt_AddUpYearMonth.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(_sumAccPaymentListCndtnWork.AddUpYearMonth);
            }

            //支払先コード
           if (SupplierListWork.PayeeCode != 0)
            {
                retString.Append(" AND SUPPAYSUB.PAYEECODERF=@PAYEECODE" + Environment.NewLine);
                SqlParameter paraPayeeCode = sqlCommand.Parameters.Add("@PAYEECODE", SqlDbType.Int);
                paraPayeeCode.Value = SqlDataMediator.SqlSetInt32(SupplierListWork.PayeeCode);
            }

            //0:全て 1:0とﾌﾟﾗｽ 2:ﾌﾟﾗｽのみ 3:0のみ 4:ﾌﾟﾗｽとﾏｲﾅｽ 5:0とﾏｲﾅｽ 6:ﾏｲﾅｽのみ
            switch (_sumAccPaymentListCndtnWork.OutMoneyDiv)
            {
                case 0:
                    break;
                case 1:
                    retString.Append(" AND SUPPAYSUB.STCKTTLACCPAYBALANCERF>=0" + Environment.NewLine);
                    break;
                case 2:
                    retString.Append(" AND SUPPAYSUB.STCKTTLACCPAYBALANCERF>0" + Environment.NewLine);
                    break;
                case 3:
                    retString.Append(" AND SUPPAYSUB.STCKTTLACCPAYBALANCERF=0" + Environment.NewLine);
                    break;
                case 4:
                    retString.Append(" AND SUPPAYSUB.STCKTTLACCPAYBALANCERF!=0" + Environment.NewLine);
                    break;
                case 5:
                    retString.Append(" AND SUPPAYSUB.STCKTTLACCPAYBALANCERF<=0" + Environment.NewLine);
                    break;
                case 6:
                    retString.Append(" AND SUPPAYSUB.STCKTTLACCPAYBALANCERF<0" + Environment.NewLine);
                    break;
            }
            retString.Append("AND ( SUPPAYSUB.LASTTIMEACCPAYRF != 0" + Environment.NewLine);
            retString.Append("      OR SUPPAYSUB.THISTIMEFEEPAYNRMLRF != 0" + Environment.NewLine);
            retString.Append("      OR SUPPAYSUB.THISTIMEDISPAYNRMLRF != 0" + Environment.NewLine);
            retString.Append("      OR SUPPAYSUB.OFSTHISTIMESTOCKRF != 0" + Environment.NewLine);
            retString.Append("      OR SUPPAYSUB.OFSTHISSTOCKTAXRF != 0" + Environment.NewLine);
            retString.Append("      OR SUPPAYSUB.STOCKSLIPCOUNTRF != 0" + Environment.NewLine);
            retString.Append("      OR SUPPAYSUB.THISTIMEPAYNRMLRF != 0)" + Environment.NewLine);
            #endregion  //WHERE文作成

            return retString.ToString();
        }
        #endregion  //[WHERE句生成処理]

        #region [買掛残高一覧表（総括）抽出結果クラス格納処理]
        /// <summary>
        /// 買掛残高一覧表（総括）抽出結果クラス格納処理 Reader → SumAccPaymentListResultWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="_sumAccPaymentListCndtnWork">SumAccPaymentListResultWork</param>
        /// <param name="SupplierListWork">SupplierListWork</param>
        /// <returns>SumAccPaymentListResultWork</returns>
        /// <remarks>
        /// <br>Programmer : FSI冨樫 紗由里</br>
        /// <br>Date       : 2012/09/14</br>
        /// </remarks>
        private SumAccPaymentListResultWork CopyToRsltWork(ref SqlDataReader myReader, SumAccPaymentListCndtnWork _sumAccPaymentListCndtnWork, SumAccPaymentListResultWork SupplierListWork)
        {
            SumAccPaymentListResultWork ResultWork = new SumAccPaymentListResultWork();

            #region [抽出結果-値セット]
            //総括拠点・総括支払先は総括仕入先マスタ絞り込み時に検索した値をセット
            ResultWork.SumAddUpSecCode = SupplierListWork.SumAddUpSecCode;
            ResultWork.SumSectionGuideSnm = SupplierListWork.SumSectionGuideSnm;
            ResultWork.AddUpSecCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDUPSECCODERF"));
            ResultWork.SectionGuideSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDESNMRF"));
            ResultWork.SumPayeeCode = SupplierListWork.SumPayeeCode;
            ResultWork.SumPayeeSnm = SupplierListWork.SumPayeeSnm;
            ResultWork.PayeeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYEECODERF"));
            ResultWork.PayeeSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYEESNMRF"));
            ResultWork.LastTimeAccPay = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("LASTTIMEACCPAYRF"));
            ResultWork.ThisTimePayNrml = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISTIMEPAYNRMLRF"));
            ResultWork.ThisTimeTtlBlcAcPay = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISTIMETTLBLCACPAYRF"));
            ResultWork.OfsThisTimeStock = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("OFSTHISTIMESTOCKRF"));
            ResultWork.ThisRgdsDisPric = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISRGDSDISPRIC"));
            ResultWork.OfsThisStockTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("OFSTHISSTOCKTAXRF"));
            ResultWork.StckTtlAccPayBalance = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STCKTTLACCPAYBALANCERF"));
            ResultWork.StockSlipCount = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKSLIPCOUNTRF"));
            ResultWork.ThisTimeFeePayNrml = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISTIMEFEEPAYNRMLRF"));
            ResultWork.ThisTimeDisPayNrml = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISTIMEDISPAYNRMLRF"));
            ResultWork.ThisTimeStockPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISTIMESTOCKPRICERF"));
            if (_sumAccPaymentListCndtnWork.PayDtlDiv == (int)PayDtlDiv.PayDtlON)
            {
                ResultWork.CashPayment = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("CASHPAYMENT"));
                ResultWork.TrfrPayment = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TRFRPAYMENT"));
                ResultWork.CheckPayment = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("CHECKPAYMENT"));
                ResultWork.DraftPayment = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DRAFTPAYMENT"));
                ResultWork.OffsetPayment = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("OFFSETPAYMENT"));
                ResultWork.FundTransferPayment = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("FUNDTRANSFERPAYMENT"));
                ResultWork.OthsPayment = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("OTHSPAYMENT"));
            }
            #endregion  //[抽出結果-値セット]

            return ResultWork;
        }
        #endregion  //[買掛残高一覧表（総括）抽出結果クラス格納処理]

        #region [コネクション生成処理]
        /// <summary>
        /// SqlConnection生成処理
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Programmer : FSI冨樫 紗由里</br>
        /// <br>Date       : 2012/09/14</br>
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
        #endregion

        // --- ADD START 3H 劉星光 2020/04/10 ---------->>>>>
        #region [SearchSuplAccPayDate]
        /// <summary>
        /// 計上年月日取得
        /// </summary>
        /// <param name="accPaymentListCndtnWork">買掛残高一覧表抽出条件</param>
        /// <param name="suplAccPayDateDic">支払先毎の月次更新処理日ディクショナリ</param>
        /// <param name="sqlConnection">コネクション情報</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 11570208-00 軽減税率対応</br>
        /// <br>Programmer : 3H 劉星光</br>
        /// <br>Date       : 2020/04/10</br>
        /// </remarks>
        private int SearchSuplAccPayDate(SumAccPaymentListCndtnWork accPaymentListCndtnWork, ref Dictionary<string, SuplAccPayDateInfo> suplAccPayDateDic, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;

            try
            {
                string sqlText = string.Empty;

                using (SqlCommand sqlCommand = new SqlCommand(sqlText, sqlConnection))
                {
                    sqlText += "SELECT" + Environment.NewLine;
                    sqlText += "  ACCPAY.ADDUPSECCODERF," + Environment.NewLine;
                    sqlText += "  ACCPAY.PAYEECODERF," + Environment.NewLine;
                    sqlText += "  ACCPAY.ADDUPDATERF," + Environment.NewLine;
                    sqlText += "  ACCPAY.LAMONCADDUPUPDDATERF" + Environment.NewLine;
                    sqlText += " FROM SUPLACCPAYRF AS ACCPAY WITH (READUNCOMMITTED)" + Environment.NewLine;
                    sqlText += " LEFT JOIN SUMSUPPSTRF AS SUMSUPP WITH (READUNCOMMITTED)" + Environment.NewLine;
                    sqlText += " ON ACCPAY.PAYEECODERF = SUMSUPP.SUPPLIERCDRF" + Environment.NewLine;
                    sqlText += " AND ACCPAY.ENTERPRISECODERF = SUMSUPP.ENTERPRISECODERF" + Environment.NewLine;
                    sqlText += " WHERE ACCPAY.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    sqlText += "    AND ACCPAY.ADDUPYEARMONTHRF=@FINDADDUPYEARMONTH" + Environment.NewLine;
                    sqlText += "    AND ACCPAY.SUPPLIERCDRF=0" + Environment.NewLine;

                    //支払先コード
                    if (accPaymentListCndtnWork.St_PayeeCode != 0)
                    {
                        sqlText += " AND SUMSUPP.SUMSUPPLIERCDRF>=@ST_PAYEECODECD" + Environment.NewLine;
                        SqlParameter paraSt_SupplierCd = sqlCommand.Parameters.Add("@ST_PAYEECODECD", SqlDbType.Int);
                        paraSt_SupplierCd.Value = SqlDataMediator.SqlSetInt32(accPaymentListCndtnWork.St_PayeeCode);
                    }
                    if (accPaymentListCndtnWork.Ed_PayeeCode != 999999)
                    {
                        sqlText += " AND SUMSUPP.SUMSUPPLIERCDRF<=@ED_PAYEECODECD" + Environment.NewLine;
                        SqlParameter paraEd_PayeeCode = sqlCommand.Parameters.Add("@ED_PAYEECODECD", SqlDbType.Int);
                        paraEd_PayeeCode.Value = SqlDataMediator.SqlSetInt32(accPaymentListCndtnWork.Ed_PayeeCode);
                    }
                    sqlText += " ORDER BY ACCPAY.PAYEECODERF" + Environment.NewLine;

                    // Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaAddUpYearMonth = sqlCommand.Parameters.Add("@FINDADDUPYEARMONTH", SqlDbType.Int);

                    // Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(accPaymentListCndtnWork.EnterpriseCode);
                    findParaAddUpYearMonth.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(accPaymentListCndtnWork.AddUpYearMonth);

                    sqlCommand.CommandText = sqlText;
                    myReader = sqlCommand.ExecuteReader();
                    // 拠点コード
                    string addUpSecCd;
                    // 支払先コード
                    int payeeCode;

                    while (myReader.Read())
                    {
                        SuplAccPayDateInfo suplAccPayDateInfo = new SuplAccPayDateInfo();
                        // 拠点コード
                        addUpSecCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDUPSECCODERF")).Trim();
                        // 支払先コード
                        payeeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYEECODERF"));
                        // 前回月次更新年月日
                        suplAccPayDateInfo.LaMonCAddUpUpdDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LAMONCADDUPUPDDATERF"));
                        // 今回月次更新年月日
                        suplAccPayDateInfo.AddUpDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ADDUPDATERF"));

                        if (!suplAccPayDateDic.ContainsKey(addUpSecCd + "-" + payeeCode.ToString("000000")))
                        {
                            suplAccPayDateDic.Add(addUpSecCd + "-" + payeeCode.ToString("000000"), suplAccPayDateInfo);
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
                base.WriteErrorLog(ex, "AccPaymentListWorkDB.SearchSuplAccPayDate Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                myReader.Dispose();
            }

            return status;
        }
        #endregion

        #region [SearchStockProc]
        /// <summary>
        /// 仕入データを取得します。
        /// </summary>
        /// <param name="accPaymentWork">検索結果</param>
        /// <param name="sqlConnection">コネクション情報</param>
        /// <param name="accPaymentListCndtnWork">買掛残高一覧表（総括）抽出条件</param>
        /// <param name="isCheckOut">締次フラッグ</param>
        /// <param name="laMonCAddUpUpdDate">前回月次更新年月日</param>
        /// <param name="suplAccPayDateDic">支払先毎の月次更新処理日ディクショナリ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 11570208-00 軽減税率対応</br>
        /// <br>Programmer : 3H 劉星光</br>
        /// <br>Date       : 2020/04/10</br>
        /// <br>Note       : 11870141-00 インボイス対応（税率別合計金額不具合修正）</br>
        /// <br>Programmer : 3H 仰亮亮</br>
        /// <br>Date       : 2022/10/20</br>
        private int SearchStockProc(ref SumAccPaymentListResultWork accPaymentWork, ref SqlConnection sqlConnection, SumAccPaymentListCndtnWork accPaymentListCndtnWork, bool isCheckOut, DateTime laMonCAddUpUpdDate, Dictionary<string, SuplAccPayDateInfo> suplAccPayDateDic)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            SqlDataReader myReader = null;

            SuplAccPayWork suplAccPayWork = new SuplAccPayWork();

            // 企業コード
            string enterpriseCode = accPaymentListCndtnWork.EnterpriseCode;

            // 計上年月日
            int addUpDate = Convert.ToInt32(accPaymentListCndtnWork.AddUpDate.ToString("yyyyMMdd"));

            // 税率2
            int laMonCAddUpDate = 0;

            // 消費税転嫁方式リスト
            List<int> consTaxLayMethodList = new List<int>();

            #region 自社情報.期首年月日取得
            bool getFirstDateFlag = false;
            int per2yearAddUpdate = 0;

            //自社情報取得
            CompanyInfWork paraCompanyInfWork = new CompanyInfWork();
            CompanyInfDB companyInfDB = new CompanyInfDB();
            ArrayList arrayList = new ArrayList();

            paraCompanyInfWork.EnterpriseCode = enterpriseCode;

            status = companyInfDB.Search(out arrayList, paraCompanyInfWork, ref sqlConnection);

            if ((status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND) ||
                (status == (int)ConstantManagement.DB_Status.ctDB_EOF))
            {
                // 該当データなし statusをクリアし次へ
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            else if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                throw new Exception("自社情報取得失敗。");
            }

            paraCompanyInfWork = (CompanyInfWork)arrayList[0];

            //自社情報.期首年月日の1年前の日の設定
            if (paraCompanyInfWork.CompanyBiginDate != 0)
            {
                DateTime dt = DateTime.ParseExact(paraCompanyInfWork.CompanyBiginDate.ToString(), "yyyyMMdd", null);
                DateTime dt1YearBefore = dt.AddYears(-1);
                DateTime dt1DayBefore = dt1YearBefore.AddDays(-1);
                getFirstDateFlag = Int32.TryParse(dt1DayBefore.ToString("yyyyMMdd"), out per2yearAddUpdate);
            }
            #endregion

            string sqlText = string.Empty;
            string suplAccPayDateKey = string.Empty;

            if (isCheckOut)
            {
                suplAccPayDateKey = accPaymentWork.AddUpSecCode.Trim() + "-" + accPaymentWork.PayeeCode.ToString("000000");
                if (suplAccPayDateDic.ContainsKey(suplAccPayDateKey))
                {
                    laMonCAddUpDate = suplAccPayDateDic[suplAccPayDateKey].LaMonCAddUpUpdDate;
                    addUpDate = suplAccPayDateDic[suplAccPayDateKey].AddUpDate;
                }
            }
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
                    sqlText = string.Empty;

                    #region [●集計レコード作成処理]

                    #region SELECT文作成
                    sqlText = string.Empty;
                    sqlText += "SELECT" + Environment.NewLine;
                    sqlText += " SUPLIERPAY.FRACTIONPROCUNITRF," + Environment.NewLine;
                    sqlText += " SUPLIERPAY.FRACTIONPROCCDRF,  " + Environment.NewLine;
                    sqlText += " SUPLIERPAY.STOCKSLIPCOUNT," + Environment.NewLine;
                    sqlText += " SUPLIERPAY.THISTIMESTOCKPRICERF + SUPLIERPAY.THISSTCKPRICRGDSRF + SUPLIERPAY.THISSTCKPRICDISRF AS OFSTHISTIMESTOCKRF," + Environment.NewLine;
                    // 仕入
                    sqlText += " SUPLIERPAY.THISTIMESTOCKPRICERF AS THISTIMESTOCKPRICERF," + Environment.NewLine;
                    // 返品
                    sqlText += " SUPLIERPAY.THISSTCKPRICRGDSRF AS THISSTCKPRICRGDSRF," + Environment.NewLine;
                    // 値引
                    sqlText += " SUPLIERPAY.THISSTCKPRICDISRF AS THISSTCKPRICDISRF," + Environment.NewLine;
                    sqlText += " SUPLIERPAY.SLIPSTOCKPRICECONSTAX AS SLIPSTOCKPRICECONSTAX, --伝票転嫁消費税額" + Environment.NewLine;
                    sqlText += " SUPLIERPAY.DTLSTOCKPRICECONSTAX AS DTLSTOCKPRICECONSTAX,   --明細転嫁消費税額" + Environment.NewLine;
                    sqlText += " SUPLIERPAY.SUPPCTAXLAYCDRF," + Environment.NewLine;
                    // --- ADD START 3H 仰亮亮 2022/10/20 ----->>>>>
                    sqlText += " SUPLIERPAY.TAXATIONCODERF, --課税区分" + Environment.NewLine;
                    // --- ADD END 3H 仰亮亮 2022/10/20 -----<<<<<
                    sqlText += " SUPLIERPAY.SUPPLIERCONSTAXRATERF" + Environment.NewLine;
                    sqlText += " FROM" + Environment.NewLine;
                    sqlText += "(" + Environment.NewLine;
                    #region [SUBクエリ]
                    sqlText += " SELECT" + Environment.NewLine;
                    sqlText += "  SUPPLIER.STOCKCNSTAXFRCPROCCDRF," + Environment.NewLine;
                    sqlText += "  PROCMONEY.FRACTIONPROCUNITRF," + Environment.NewLine;
                    sqlText += "  PROCMONEY.FRACTIONPROCCDRF, " + Environment.NewLine;
                    sqlText += "  COUNT(STOCK.SUPPLIERSLIPNORF) STOCKSLIPCOUNT, --伝票枚数" + Environment.NewLine;
                    sqlText += "  SUM((CASE WHEN STOCK.SUPPLIERSLIPCDRF =10 THEN STOCK.STOCKNETPRICERF ELSE 0 END)) AS THISTIMESTOCKPRICERF,       --仕入正価金額" + Environment.NewLine;
                    sqlText += "  SUM((CASE WHEN STOCK.SUPPLIERSLIPCDRF =20 THEN STOCK.STOCKNETPRICERF ELSE 0 END)) AS THISSTCKPRICRGDSRF,       --返品正価金額" + Environment.NewLine;
                    sqlText += "  SUM(STOCK.STCKDISTTLTAXEXCRF) AS THISSTCKPRICDISRF,         --値引金額計（税抜き）" + Environment.NewLine;
                    sqlText += "  SUM(STOCK.SLIPSTOCKPRICECONSTAX) AS SLIPSTOCKPRICECONSTAX,  --伝票転嫁消費税額" + Environment.NewLine;
                    sqlText += "  SUM(STOCK.DTLSTOCKPRICECONSTAX) AS DTLSTOCKPRICECONSTAX,    --明細転嫁消費税額" + Environment.NewLine;
                    sqlText += "  STOCK.SUPPCTAXLAYCDRF," + Environment.NewLine;
                    // --- ADD START 3H 仰亮亮 2022/10/20 ----->>>>>
                    sqlText += " STOCK.TAXATIONCODERF, --課税区分" + Environment.NewLine;
                    // --- ADD END 3H 仰亮亮 2022/10/20 -----<<<<<
                    sqlText += "  STOCK.SUPPLIERCONSTAXRATERF" + Environment.NewLine;
                    sqlText += "  FROM" + Environment.NewLine;
                    sqlText += "  (" + Environment.NewLine;
                    #region SUBSUBクエリ
                    sqlText += "   SELECT" + Environment.NewLine;
                    sqlText += "    SUBSTOCK.LOGICALDELETECODERF," + Environment.NewLine;
                    sqlText += "    SUBSTOCK.ENTERPRISECODERF," + Environment.NewLine;
                    sqlText += "    SUBSTOCK.STOCKSECTIONCDRF," + Environment.NewLine;
                    sqlText += "    SUBSTOCK.SUPPCTAXLAYCDRF, --消費税転嫁方式(仕入データ) " + Environment.NewLine;
                    sqlText += "    SUBSTOCK.SUPPLIERFORMALRF,--仕入形式" + Environment.NewLine;
                    sqlText += "    SUBSTOCK.DEBITNOTEDIVRF,  --赤伝区分" + Environment.NewLine;
                    sqlText += "    SUBSTOCK.SUPPLIERSLIPCDRF,--仕入伝票区分" + Environment.NewLine;
                    sqlText += "    SUBSTOCK.STOCKGOODSCDRF,  --仕入商品区分" + Environment.NewLine;
                    sqlText += "    SUBSTOCK.SUPPLIERSLIPNORF," + Environment.NewLine;
                    sqlText += "    SUBSTOCK.STOCKADDUPADATERF," + Environment.NewLine;
                    sqlText += "   (CASE WHEN (SEARCHSUPPLIER.SUPPLIERCDRF IS NOT NULL) THEN SEARCHSUPPLIER.SUPPLIERCDRF ELSE SUBSTOCK.SUPPLIERCDRF END)  AS SUPPLIERCDRF," + Environment.NewLine;
                    sqlText += "    (CASE WHEN (SEARCHSUPPLIER.PAYEECODERF IS NOT NULL) THEN SEARCHSUPPLIER.PAYEECODERF ELSE SUBSTOCK.PAYEECODERF END) AS PAYEECODERF," + Environment.NewLine;
                    // --- DEL START 3H 仰亮亮 2022/10/20 ----->>>>>
                    //sqlText += "    SUBSTOCK.STOCKNETPRICERF + SUBSTOCKDTL.DISSTOCKPRICETAXEXCGYO AS STOCKNETPRICERF," + Environment.NewLine;
                    //sqlText += "    SUBSTOCK.STCKDISTTLTAXEXCRF - SUBSTOCKDTL.DISSTOCKPRICETAXEXCGYO AS STCKDISTTLTAXEXCRF," + Environment.NewLine;
                    //sqlText += "    (CASE WHEN (SUBSTOCK.SUPPCTAXLAYCDRF =0 ) THEN (SUBSTOCK.STOCKTTLPRICTAXINCRF - SUBSTOCK.STOCKTTLPRICTAXEXCRF) ELSE 0 END) AS SLIPSTOCKPRICECONSTAX," + Environment.NewLine;
                    // --- DEL END 3H 仰亮亮 2022/10/20 -----<<<<<
                    // --- ADD START 3H 仰亮亮 2022/10/20 ----->>>>>
                    sqlText += "      (CASE WHEN (SUBSTOCKDTL.SUPPLIERSLIPCDRF =10) THEN SUBSTOCKDTL.STOCKPRICE + SUBSTOCKDTL.DISSTOCKPRICETAXEXCGYO WHEN (SUBSTOCKDTL.SUPPLIERSLIPCDRF =20) THEN SUBSTOCKDTL.RETSTOCKPRICE + SUBSTOCKDTL.DISSTOCKPRICETAXEXCGYO ELSE 0 END) AS STOCKNETPRICERF," + Environment.NewLine;
                    sqlText += "      SUBSTOCKDTL.DISGOODSSTAXEXCGYO AS STCKDISTTLTAXEXCRF," + Environment.NewLine;
                    sqlText += "      SUBSTOCKDTL.TAXATIONCODERF AS TAXATIONCODERF, --課税区分" + Environment.NewLine;
                    sqlText += "      (CASE WHEN (SUBSTOCK.SUPPCTAXLAYCDRF =0 AND SUBSTOCKDTL.TAXATIONCODERF = 0) THEN (SUBSTOCK.STOCKTTLPRICTAXINCRF - SUBSTOCK.STOCKTTLPRICTAXEXCRF) ELSE 0 END) AS SLIPSTOCKPRICECONSTAX," + Environment.NewLine;
                    // --- ADD END 3H 仰亮亮 2022/10/20 -----<<<<<
                    sqlText += "    (CASE WHEN (SUBSTOCK.SUPPCTAXLAYCDRF =1 ) THEN DTLSTOCKPRICECONSTAX ELSE 0 END) AS DTLSTOCKPRICECONSTAX," + Environment.NewLine;
                    sqlText += "    SUBSTOCK.SUPPLIERCONSTAXRATERF" + Environment.NewLine;
                    sqlText += "   FROM" + Environment.NewLine;
                    sqlText += "    STOCKSLIPRF AS SUBSTOCK WITH (READUNCOMMITTED)" + Environment.NewLine;
                    sqlText += "    LEFT JOIN SUPPLIERRF AS SEARCHSUPPLIER WITH (READUNCOMMITTED)" + Environment.NewLine;
                    sqlText += "     ON SUBSTOCK.ENTERPRISECODERF = SEARCHSUPPLIER.ENTERPRISECODERF" + Environment.NewLine;
                    sqlText += "     AND SUBSTOCK.SUPPLIERCDRF = SEARCHSUPPLIER.SUPPLIERCDRF" + Environment.NewLine;
                    sqlText += "    LEFT JOIN" + Environment.NewLine;
                    sqlText += "    ( " + Environment.NewLine;
                    sqlText += "      SELECT" + Environment.NewLine;
                    sqlText += "       STOCK.ENTERPRISECODERF," + Environment.NewLine;
                    sqlText += "       STOCK.SUPPLIERFORMALRF, --受注ステータス" + Environment.NewLine;
                    sqlText += "       STOCK.SUPPLIERSLIPCDRF, --仕入伝票区分" + Environment.NewLine;
                    sqlText += "       STOCK.SUPPLIERSLIPNORF, --仕入伝票番号 " + Environment.NewLine;
                    // --- ADD START 3H 仰亮亮 2022/10/20 ----->>>>>
                    sqlText += "       DTL.TAXATIONCODERF, --課税区分 " + Environment.NewLine;
                    // --- ADD END 3H 仰亮亮 2022/10/20 -----<<<<<
                    sqlText += "       --明細転嫁消費税額" + Environment.NewLine;
                    sqlText += "       SUM(DTL.STOCKPRICECONSTAXRF) AS DTLSTOCKPRICECONSTAX,-- 明細転嫁消費税額" + Environment.NewLine;
                    sqlText += "       -- 行値引" + Environment.NewLine;
                    //sqlText += "       SUM(CASE WHEN (DTL.STOCKSLIPCDDTLRF = 2 AND DTL.STOCKCOUNTRF = 0 ) THEN DTL.STOCKPRICETAXEXCRF ELSE 0 END) AS DISSTOCKPRICETAXEXCGYO" + Environment.NewLine; // DEL 3H 仰亮亮 2022/10/09
                    // --- ADD START 3H 仰亮亮 2022/10/09 ----->>>>>
                    sqlText += "       SUM(CASE WHEN (DTL.STOCKSLIPCDDTLRF = 2 AND DTL.STOCKCOUNTRF =0 ) THEN DTL.STOCKPRICETAXEXCRF ELSE 0 END) AS DISSTOCKPRICETAXEXCGYO,-- 税抜値引金額(行値引)" + Environment.NewLine;
                    sqlText += "       --商品値引金額" + Environment.NewLine;
                    sqlText += "       SUM(CASE WHEN (DTL.STOCKSLIPCDDTLRF = 2 AND DTL.STOCKCOUNTRF <>0 ) THEN DTL.STOCKPRICETAXEXCRF ELSE 0 END) AS DISGOODSSTAXEXCGYO,-- 税抜値引金額(商品値引)" + Environment.NewLine;
                    sqlText += "       --仕入金額" + Environment.NewLine;
                    sqlText += "       SUM(CASE WHEN (DTL.STOCKSLIPCDDTLRF = 0 ) THEN DTL.STOCKPRICETAXEXCRF ELSE 0 END) AS STOCKPRICE,-- 仕入金額" + Environment.NewLine;
                    sqlText += "       --返品金額" + Environment.NewLine;
                    sqlText += "       SUM(CASE WHEN (DTL.STOCKSLIPCDDTLRF = 1 ) THEN DTL.STOCKPRICETAXEXCRF ELSE 0 END) AS RETSTOCKPRICE-- 返品金額" + Environment.NewLine;
                    // --- ADD END 3H 仰亮亮 2022/10/09 -----<<<<<
                    sqlText += "      FROM" + Environment.NewLine;
                    sqlText += "       STOCKDETAILRF AS DTL WITH (READUNCOMMITTED)" + Environment.NewLine;
                    sqlText += "      LEFT JOIN STOCKSLIPRF AS STOCK WITH (READUNCOMMITTED)" + Environment.NewLine;
                    sqlText += "       ON DTL.ENTERPRISECODERF = STOCK.ENTERPRISECODERF" + Environment.NewLine;
                    sqlText += "       AND DTL.SUPPLIERFORMALRF = STOCK.SUPPLIERFORMALRF" + Environment.NewLine;
                    sqlText += "       AND DTL.SUPPLIERSLIPNORF = STOCK.SUPPLIERSLIPNORF" + Environment.NewLine;
                    sqlText += "      GROUP BY" + Environment.NewLine;
                    sqlText += "       STOCK.ENTERPRISECODERF," + Environment.NewLine;
                    sqlText += "       STOCK.SUPPLIERFORMALRF, --受注ステータス" + Environment.NewLine;
                    sqlText += "       STOCK.SUPPLIERSLIPCDRF, --仕入伝票区分" + Environment.NewLine;
                    //sqlText += "       STOCK.SUPPLIERSLIPNORF --仕入伝票番号 " + Environment.NewLine; // DEL 3H 仰亮亮 2022/10/20
                    // --- ADD START 3H 仰亮亮 2022/10/20 ----->>>>>
                    sqlText += "       STOCK.SUPPLIERSLIPNORF, --仕入伝票番号 " + Environment.NewLine;
                    sqlText += "       DTL.TAXATIONCODERF --課税区分 " + Environment.NewLine;
                    // --- ADD END 3H 仰亮亮 2022/10/20 -----<<<<<
                    sqlText += "    ) AS SUBSTOCKDTL" + Environment.NewLine;
                    sqlText += "    ON  SUBSTOCK.ENTERPRISECODERF = SUBSTOCKDTL.ENTERPRISECODERF" + Environment.NewLine;
                    sqlText += "    AND SUBSTOCK.SUPPLIERFORMALRF = SUBSTOCKDTL.SUPPLIERFORMALRF" + Environment.NewLine;
                    sqlText += "    AND SUBSTOCK.SUPPLIERSLIPNORF = SUBSTOCKDTL.SUPPLIERSLIPNORF" + Environment.NewLine;
                    #endregion

                    #region [ JOIN ]
                    sqlText += "   ) AS STOCK" + Environment.NewLine;
                    sqlText += "   INNER JOIN SUPPLIERRF AS SUPPLIER WITH (READUNCOMMITTED)" + Environment.NewLine;
                    sqlText += "    ON SUPPLIER.ENTERPRISECODERF = STOCK.ENTERPRISECODERF" + Environment.NewLine;
                    sqlText += "    AND SUPPLIER.SUPPLIERCDRF = STOCK.PAYEECODERF" + Environment.NewLine;
                    sqlText += "   LEFT JOIN STOCKPROCMONEYRF AS PROCMONEY WITH (READUNCOMMITTED)" + Environment.NewLine;
                    sqlText += "    ON PROCMONEY.ENTERPRISECODERF = STOCK.ENTERPRISECODERF" + Environment.NewLine;
                    sqlText += "    AND PROCMONEY.FRACPROCMONEYDIVRF = 1" + Environment.NewLine;
                    sqlText += "    AND PROCMONEY.FRACTIONPROCCODERF = SUPPLIER.STOCKCNSTAXFRCPROCCDRF" + Environment.NewLine;
                    #endregion

                    #region [ WHERE ]
                    sqlText += "   WHERE STOCK.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    sqlText += "    AND STOCK.SUPPLIERCDRF =@FINDPAYEECODE" + Environment.NewLine;
                    sqlText += "    AND STOCK.STOCKSECTIONCDRF = @FINDADDUPSECCODE" + Environment.NewLine;
                    sqlText += "    AND (STOCK.STOCKADDUPADATERF<=@FINDADDUPDATE AND STOCK.STOCKADDUPADATERF>@FINDLASTTIMEADDUPDATE)" + Environment.NewLine;
                    sqlText += "    AND  STOCK.LOGICALDELETECODERF=0" + Environment.NewLine;
                    sqlText += "    AND  STOCK.SUPPLIERFORMALRF=0" + Environment.NewLine;
                    sqlText += "    AND  STOCK.DEBITNOTEDIVRF=0" + Environment.NewLine;
                    sqlText += "    AND (STOCK.SUPPLIERSLIPCDRF = 10 OR STOCK.SUPPLIERSLIPCDRF = 20)" + Environment.NewLine;
                    sqlText += "    AND (STOCK.STOCKGOODSCDRF=0 OR STOCK.STOCKGOODSCDRF = 6)" + Environment.NewLine;
                    #endregion 

                    #region [ GROUP BY ]
                    sqlText += "   GROUP BY" + Environment.NewLine;
                    sqlText += "    SUPPLIER.STOCKCNSTAXFRCPROCCDRF," + Environment.NewLine;
                    sqlText += "    PROCMONEY.FRACTIONPROCUNITRF," + Environment.NewLine;
                    sqlText += "    PROCMONEY.FRACTIONPROCCDRF, " + Environment.NewLine;
                    sqlText += "    STOCK.SUPPCTAXLAYCDRF," + Environment.NewLine;
                    //sqlText += "    STOCK.SUPPLIERCONSTAXRATERF" + Environment.NewLine;// DEL 3H 仰亮亮 2022/10/20
                    // --- ADD START 3H 仰亮亮 2022/10/20 ----->>>>>
                    sqlText += "    STOCK.SUPPLIERCONSTAXRATERF," + Environment.NewLine;
                    sqlText += "    STOCK.TAXATIONCODERF" + Environment.NewLine;
                    // --- ADD END 3H 仰亮亮 2022/10/20 -----<<<<<
                    sqlText += ") AS SUPLIERPAY" + Environment.NewLine;
                    #endregion

                    #endregion

                    sqlCommand.CommandText = sqlText;

                    #region  Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaPayeeCode = sqlCommand.Parameters.Add("@FINDPAYEECODE", SqlDbType.Int);
                    SqlParameter findParaAddUpDate = sqlCommand.Parameters.Add("@FINDADDUPDATE", SqlDbType.Int);
                    SqlParameter findParaLastTimeAddUpDate = sqlCommand.Parameters.Add("@FINDLASTTIMEADDUPDATE", SqlDbType.Int);
                    SqlParameter findParaAddUpSecCode = sqlCommand.Parameters.Add("@FINDADDUPSECCODE", SqlDbType.NChar);
                    #endregion

                    #region Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCode);
                    findParaPayeeCode.Value = SqlDataMediator.SqlSetInt32(accPaymentWork.PayeeCode);
                    findParaAddUpDate.Value = SqlDataMediator.SqlSetInt32(addUpDate);
                    findParaAddUpSecCode.Value = SqlDataMediator.SqlSetString(accPaymentWork.AddUpSecCode);

                    if (getFirstDateFlag && (per2yearAddUpdate > 20000101))
                    {
                        if (laMonCAddUpDate < per2yearAddUpdate)
                        {
                            findParaLastTimeAddUpDate.Value = per2yearAddUpdate;
                        }
                        else
                        {
                            findParaLastTimeAddUpDate.Value = laMonCAddUpDate;
                        }
                    }
                    else
                    {
                        if (laMonCAddUpDate < 20000101)
                        {
                            findParaLastTimeAddUpDate.Value = per2yearAddUpdate;
                        }
                        else
                        {
                            findParaLastTimeAddUpDate.Value = laMonCAddUpDate;
                        }
                    }
                    #endregion

                    myReader = sqlCommand.ExecuteReader();
                    // 端数処理単位
                    double fractionProcUnit = 0;
                    // 伝票転嫁・明細転嫁消費税
                    long totalStockPricTax = 0;

                    while (myReader.Read())
                    {
                        #region 結果セット
                        suplAccPayWork.FractionProcCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FRACTIONPROCCDRF")); //端数処理区分
                        fractionProcUnit = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("FRACTIONPROCUNITRF"));           // 端数処理単位

                        suplAccPayWork.SuppCTaxLayCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPCTAXLAYCDRF"));
                        suplAccPayWork.SupplierConsTaxRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SUPPLIERCONSTAXRATERF"));

                        // ■消費税額
                        if (suplAccPayWork.SuppCTaxLayCd == 0)
                        {
                            totalStockPricTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SLIPSTOCKPRICECONSTAX"));
                        }
                        else if (suplAccPayWork.SuppCTaxLayCd == 1)
                        {
                            totalStockPricTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DTLSTOCKPRICECONSTAX"));
                        }
                        else
                        {
                            totalStockPricTax = 0;
                        }

                        //■相殺
                        suplAccPayWork.OfsThisTimeStock = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("OFSTHISTIMESTOCKRF"));

                        // ■仕入
                        suplAccPayWork.ThisTimeStockPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISTIMESTOCKPRICERF"));

                        // ■返品
                        suplAccPayWork.ThisStckPricRgds = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISSTCKPRICRGDSRF"));

                        // ■値引
                        suplAccPayWork.ThisStckPricDis = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISSTCKPRICDISRF"));

                        // 伝票枚数
                        suplAccPayWork.StockSlipCount = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKSLIPCOUNT"));

                        // --- ADD START 3H 仰亮亮 2022/10/20 ----->>>>>
                        // 課税区分
                        int taxAtionCodeRF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TAXATIONCODERF"));
                        // --- ADD END 3H 仰亮亮 2022/10/20 -----<<<<<

                        #endregion

                        #region 税別内訳印字
                        //if (suplAccPayWork.SuppCTaxLayCd != 9 && suplAccPayWork.SupplierConsTaxRate == accPaymentListCndtnWork.TaxRate1) // DEL 3H 仰亮亮 2022/10/20
                        if ((suplAccPayWork.SuppCTaxLayCd != 9 && taxAtionCodeRF != 1) && suplAccPayWork.SupplierConsTaxRate == accPaymentListCndtnWork.TaxRate1) // ADD 3H 仰亮亮 2022/10/20
                        {
                            // 仕入額(計税率1)
                            accPaymentWork.TotalThisTimeStockPriceTaxRate1 += suplAccPayWork.ThisTimeStockPrice;
                            // 返品値引(計税率1)
                            accPaymentWork.TotalThisRgdsDisPricTaxRate1 -= suplAccPayWork.ThisStckPricRgds + suplAccPayWork.ThisStckPricDis;
                            // 純仕入額(計税率1)
                            accPaymentWork.TotalPureStockTaxRate1 += suplAccPayWork.OfsThisTimeStock;
                            // 消費税(計税率1)
                            if (suplAccPayWork.SuppCTaxLayCd == 0 || suplAccPayWork.SuppCTaxLayCd == 1)
                            {
                                accPaymentWork.TotalStockPricTaxTaxRate1 += totalStockPricTax;
                            }
                            // 枚数(計税率1)
                            accPaymentWork.TotalStockSlipCountTaxRate1 += suplAccPayWork.StockSlipCount;
                        }
                        //else if (suplAccPayWork.SuppCTaxLayCd != 9 && suplAccPayWork.SupplierConsTaxRate == accPaymentListCndtnWork.TaxRate2)// DEL 3H 仰亮亮 2022/10/20
                        else if ((suplAccPayWork.SuppCTaxLayCd != 9 && taxAtionCodeRF != 1) && suplAccPayWork.SupplierConsTaxRate == accPaymentListCndtnWork.TaxRate2)// ADD 3H 仰亮亮 2022/10/20
                        {
                            // 仕入額(計税率2)
                            accPaymentWork.TotalThisTimeStockPriceTaxRate2 += suplAccPayWork.ThisTimeStockPrice;
                            // 返品値引(計税率2)
                            accPaymentWork.TotalThisRgdsDisPricTaxRate2 -= suplAccPayWork.ThisStckPricRgds + suplAccPayWork.ThisStckPricDis;
                            // 純仕入額(計税率2)
                            accPaymentWork.TotalPureStockTaxRate2 += suplAccPayWork.OfsThisTimeStock;
                            // 消費税(計税率2)
                            if (suplAccPayWork.SuppCTaxLayCd == 0 || suplAccPayWork.SuppCTaxLayCd == 1)
                            {
                                accPaymentWork.TotalStockPricTaxTaxRate2 += totalStockPricTax;
                            }
                            // 枚数(計税率2)
                            accPaymentWork.TotalStockSlipCountTaxRate2 += suplAccPayWork.StockSlipCount;
                        }
                        // --- ADD START 3H 仰亮亮 2022/10/20 ----->>>>>
                        // 非課税
                        else if (suplAccPayWork.SuppCTaxLayCd == 9 || taxAtionCodeRF == 1)
                        {
                            // 仕入額(計非課税)
                            accPaymentWork.TotalThisTimeStockPriceTaxFree += suplAccPayWork.ThisTimeStockPrice;
                            // 返品値引(計非課税)
                            accPaymentWork.TotalThisRgdsDisPricTaxFree -= suplAccPayWork.ThisStckPricRgds + suplAccPayWork.ThisStckPricDis;
                            // 純仕入額(計非課税)
                            accPaymentWork.TotalPureStockTaxFree += suplAccPayWork.OfsThisTimeStock;
                            // 消費税(計非課税)
                            accPaymentWork.TotalStockPricTaxTaxFree = 0;
                            // 枚数(計非課税)
                            accPaymentWork.TotalStockSlipCountTaxFree += suplAccPayWork.StockSlipCount;
                        }
                        // --- ADD END 3H 仰亮亮 2022/10/20 -----<<<<<
                        else
                        {
                            // 仕入額(計その他)
                            accPaymentWork.TotalThisTimeStockPriceOther += suplAccPayWork.ThisTimeStockPrice;
                            // 返品値引(計その他)
                            accPaymentWork.TotalThisRgdsDisPricOther -= suplAccPayWork.ThisStckPricRgds + suplAccPayWork.ThisStckPricDis;
                            // 純仕入額(計その他)
                            accPaymentWork.TotalPureStockOther += suplAccPayWork.OfsThisTimeStock;
                            // 消費税(計その他)
                            if (suplAccPayWork.SuppCTaxLayCd == 0 || suplAccPayWork.SuppCTaxLayCd == 1)
                            {
                                accPaymentWork.TotalStockPricTaxOther += totalStockPricTax;
                            }
                            // 枚数(計その他)
                            accPaymentWork.TotalStockSlipCountOther += suplAccPayWork.StockSlipCount;
                        }

                        if (!consTaxLayMethodList.Contains(suplAccPayWork.SuppCTaxLayCd))
                        {
                            consTaxLayMethodList.Add(suplAccPayWork.SuppCTaxLayCd);
                        }

                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                        #endregion
                    }
                    #endregion

                    // 初期化
                    if (!myReader.IsClosed) myReader.Close();
                    sqlCommand.CommandText = string.Empty;
                    sqlText = string.Empty;

                    #region 消費税と当月合計算出
                    foreach (int suppCTaxLayCd in consTaxLayMethodList)
                    {
                        // 伝票転嫁・明細転嫁・非課税
                        if (suppCTaxLayCd == 0 || suppCTaxLayCd == 1 || suppCTaxLayCd == 9)
                        {
                            continue;
                        }

                        switch (suppCTaxLayCd)
                        {
                            // 請求親
                            case 2:
                                sqlText += "SELECT" + Environment.NewLine;
                                sqlText += "  SUM(STOCK.STOCKTTLPRICTAXEXCRF) AS STOCKTTLPRICTAXEXCRF," + Environment.NewLine;
                                sqlText += "  STOCK.SUPPLIERCONSTAXRATERF" + Environment.NewLine;
                                sqlText += "FROM (" + Environment.NewLine;
                                sqlText += "	SELECT" + Environment.NewLine;
                                //sqlText += "	    SUBSTOCK.STOCKTTLPRICTAXEXCRF," + Environment.NewLine; // DEL 3H 仰亮亮 2022/10/20
                                // --- ADD START 3H 仰亮亮 2022/10/20 ----->>>>>
                                sqlText += "	 (SELECT SUM(STOCKPRICETAXEXCRF) AS STOCKTTLPRICTAXEXCRF  FROM STOCKDETAILRF AS DTL WITH (READUNCOMMITTED) WHERE " + Environment.NewLine;
                                sqlText += "       SUBSTOCK.ENTERPRISECODERF = DTL.ENTERPRISECODERF" + Environment.NewLine;
                                sqlText += "       AND SUBSTOCK.SUPPLIERFORMALRF = DTL.SUPPLIERFORMALRF" + Environment.NewLine;
                                sqlText += "       AND SUBSTOCK.SUPPLIERSLIPNORF  = DTL.SUPPLIERSLIPNORF " + Environment.NewLine;
                                sqlText += "       AND DTL.TAXATIONCODERF = 0) AS STOCKTTLPRICTAXEXCRF, " + Environment.NewLine;
                                // --- ADD END 3H 仰亮亮 2022/10/20 -----<<<<<
                                sqlText += "	    SUBSTOCK.SUPPLIERCDRF," + Environment.NewLine;
                                sqlText += "	    SUBSTOCK.STOCKSECTIONCDRF," + Environment.NewLine;
                                sqlText += "	    (CASE WHEN (SUPPLIER.PAYEECODERF IS NOT NULL) THEN SUPPLIER.PAYEECODERF ELSE SUBSTOCK.PAYEECODERF END) AS PAYEECODERF," + Environment.NewLine;
                                sqlText += "	    CASE WHEN (SUBSTOCK.STOCKADDUPADATERF >= TAX.TAXRATESTARTDATERF) AND (SUBSTOCK.STOCKADDUPADATERF <= TAX.TAXRATEENDDATERF) THEN TAX.TAXRATERF" + Environment.NewLine;
                                sqlText += "	    WHEN (SUBSTOCK.STOCKADDUPADATERF >= TAX.TAXRATESTARTDATE2RF) AND (SUBSTOCK.STOCKADDUPADATERF <= TAX.TAXRATEENDDATE2RF) THEN TAX.TAXRATE2RF" + Environment.NewLine;
                                sqlText += "	    WHEN (SUBSTOCK.STOCKADDUPADATERF >= TAX.TAXRATESTARTDATE3RF) AND (SUBSTOCK.STOCKADDUPADATERF <= TAX.TAXRATEENDDATE3RF) THEN TAX.TAXRATE3RF ELSE 0 END AS SUPPLIERCONSTAXRATERF" + Environment.NewLine;
                                sqlText += "	FROM STOCKSLIPRF AS SUBSTOCK WITH(READUNCOMMITTED)" + Environment.NewLine;
                                sqlText += "	LEFT JOIN TAXRATESETRF AS TAX WITH(READUNCOMMITTED)" + Environment.NewLine;
                                sqlText += "	ON TAX.ENTERPRISECODERF = SUBSTOCK.ENTERPRISECODERF" + Environment.NewLine;
                                sqlText += "    LEFT JOIN SUPPLIERRF AS SUPPLIER WITH (READUNCOMMITTED)" + Environment.NewLine;
                                sqlText += "    ON SUBSTOCK.ENTERPRISECODERF = SUPPLIER.ENTERPRISECODERF" + Environment.NewLine;
                                sqlText += "    AND SUBSTOCK.SUPPLIERCDRF = SUPPLIER.SUPPLIERCDRF" + Environment.NewLine;
                                sqlText += "    WHERE SUBSTOCK.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                                sqlText += "        AND (SUBSTOCK.STOCKADDUPADATERF<=@FINDADDUPDATE AND SUBSTOCK.STOCKADDUPADATERF>@FINDLASTTIMEADDUPDATE)" + Environment.NewLine;
                                sqlText += "        AND  SUBSTOCK.LOGICALDELETECODERF=0" + Environment.NewLine;
                                sqlText += "        AND  SUBSTOCK.SUPPLIERFORMALRF=0" + Environment.NewLine;
                                sqlText += "        AND  SUBSTOCK.DEBITNOTEDIVRF=0" + Environment.NewLine;
                                sqlText += "        AND  SUBSTOCK.SUPPCTAXLAYCDRF=2" + Environment.NewLine;
                                sqlText += "        AND  SUBSTOCK.STOCKSECTIONCDRF = @FINDADDUPSECCODE" + Environment.NewLine;
                                sqlText += "        AND (SUBSTOCK.SUPPLIERSLIPCDRF = 10 OR SUBSTOCK.SUPPLIERSLIPCDRF = 20)" + Environment.NewLine;
                                sqlText += "        AND (SUBSTOCK.STOCKGOODSCDRF=0 OR SUBSTOCK.STOCKGOODSCDRF = 6)" + Environment.NewLine;
                                sqlText += ") AS STOCK" + Environment.NewLine;
                                sqlText += "WHERE STOCK.SUPPLIERCDRF=@FINDPAYEECODE" + Environment.NewLine;
                                sqlText += "  AND STOCK.STOCKSECTIONCDRF=@FINDADDUPSECCODE" + Environment.NewLine;
                                sqlText += "GROUP BY" + Environment.NewLine;
                                sqlText += "   SUPPLIERCONSTAXRATERF" + Environment.NewLine;
                                break;
                            // 請求子
                            case 3:
                                sqlText += "SELECT" + Environment.NewLine;
                                sqlText += "  SUM(STOCK.STOCKTTLPRICTAXEXCRF) AS STOCKTTLPRICTAXEXCRF," + Environment.NewLine;
                                sqlText += "  STOCK.STOCKSECTIONCDRF," + Environment.NewLine;
                                sqlText += "  STOCK.SUPPLIERCDRF," + Environment.NewLine;
                                sqlText += "  STOCK.SUPPLIERCONSTAXRATERF" + Environment.NewLine;
                                sqlText += "FROM (" + Environment.NewLine;
                                sqlText += "	SELECT" + Environment.NewLine;
                                sqlText += "	    SUBSTOCK.STOCKSECTIONCDRF," + Environment.NewLine;
                                //sqlText += "	    SUBSTOCK.STOCKTTLPRICTAXEXCRF," + Environment.NewLine; // DEL 3H 仰亮亮 2022/10/20
                                // --- ADD START 3H 仰亮亮 2022/10/20 ----->>>>>
                                sqlText += "	 (SELECT SUM(STOCKPRICETAXEXCRF) AS STOCKTTLPRICTAXEXCRF  FROM STOCKDETAILRF AS DTL WITH (READUNCOMMITTED) WHERE " + Environment.NewLine;
                                sqlText += "       SUBSTOCK.ENTERPRISECODERF = DTL.ENTERPRISECODERF" + Environment.NewLine;
                                sqlText += "       AND SUBSTOCK.SUPPLIERFORMALRF = DTL.SUPPLIERFORMALRF" + Environment.NewLine;
                                sqlText += "       AND SUBSTOCK.SUPPLIERSLIPNORF  = DTL.SUPPLIERSLIPNORF " + Environment.NewLine;
                                sqlText += "       AND DTL.TAXATIONCODERF = 0) AS STOCKTTLPRICTAXEXCRF, " + Environment.NewLine;
                                // --- ADD END 3H 仰亮亮 2022/10/20 -----<<<<<
                                sqlText += "	    SUBSTOCK.SUPPLIERCDRF," + Environment.NewLine;
                                sqlText += "	    (CASE WHEN (SUPPLIER.PAYEECODERF IS NOT NULL) THEN SUPPLIER.PAYEECODERF ELSE SUBSTOCK.PAYEECODERF END) AS PAYEECODERF," + Environment.NewLine;
                                sqlText += "	    CASE WHEN (SUBSTOCK.STOCKADDUPADATERF >= TAX.TAXRATESTARTDATERF) AND (SUBSTOCK.STOCKADDUPADATERF <= TAX.TAXRATEENDDATERF) THEN TAX.TAXRATERF" + Environment.NewLine;
                                sqlText += "	    WHEN (SUBSTOCK.STOCKADDUPADATERF >= TAX.TAXRATESTARTDATE2RF) AND (SUBSTOCK.STOCKADDUPADATERF <= TAX.TAXRATEENDDATE2RF) THEN TAX.TAXRATE2RF" + Environment.NewLine;
                                sqlText += "	    WHEN (SUBSTOCK.STOCKADDUPADATERF >= TAX.TAXRATESTARTDATE3RF) AND (SUBSTOCK.STOCKADDUPADATERF <= TAX.TAXRATEENDDATE3RF) THEN TAX.TAXRATE3RF ELSE 0 END AS SUPPLIERCONSTAXRATERF" + Environment.NewLine;
                                sqlText += "	FROM STOCKSLIPRF AS SUBSTOCK WITH(READUNCOMMITTED)" + Environment.NewLine;
                                sqlText += "	LEFT JOIN TAXRATESETRF AS TAX WITH(READUNCOMMITTED)" + Environment.NewLine;
                                sqlText += "	ON TAX.ENTERPRISECODERF = SUBSTOCK.ENTERPRISECODERF" + Environment.NewLine;
                                sqlText += "    LEFT JOIN SUPPLIERRF AS SUPPLIER WITH (READUNCOMMITTED)" + Environment.NewLine;
                                sqlText += "    ON SUBSTOCK.ENTERPRISECODERF = SUPPLIER.ENTERPRISECODERF" + Environment.NewLine;
                                sqlText += "    AND SUBSTOCK.SUPPLIERCDRF = SUPPLIER.SUPPLIERCDRF" + Environment.NewLine;
                                sqlText += "    WHERE SUBSTOCK.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                                sqlText += "        AND (SUBSTOCK.STOCKADDUPADATERF<=@FINDADDUPDATE AND SUBSTOCK.STOCKADDUPADATERF>@FINDLASTTIMEADDUPDATE)" + Environment.NewLine;
                                sqlText += "        AND  SUBSTOCK.LOGICALDELETECODERF=0" + Environment.NewLine;
                                sqlText += "        AND  SUBSTOCK.SUPPLIERFORMALRF=0" + Environment.NewLine;
                                sqlText += "        AND  SUBSTOCK.DEBITNOTEDIVRF=0" + Environment.NewLine;
                                sqlText += "        AND  SUBSTOCK.SUPPCTAXLAYCDRF=3" + Environment.NewLine;
                                sqlText += "        AND  SUBSTOCK.STOCKSECTIONCDRF = @FINDADDUPSECCODE" + Environment.NewLine;
                                sqlText += "        AND (SUBSTOCK.SUPPLIERSLIPCDRF = 10 OR SUBSTOCK.SUPPLIERSLIPCDRF = 20)" + Environment.NewLine;
                                sqlText += "        AND (SUBSTOCK.STOCKGOODSCDRF=0 OR SUBSTOCK.STOCKGOODSCDRF = 6)" + Environment.NewLine;
                                sqlText += ") AS STOCK" + Environment.NewLine;
                                sqlText += "WHERE STOCK.SUPPLIERCDRF=@FINDPAYEECODE" + Environment.NewLine;
                                sqlText += "  AND STOCK.STOCKSECTIONCDRF=@FINDADDUPSECCODE" + Environment.NewLine;
                                sqlText += "GROUP BY" + Environment.NewLine;
                                sqlText += "   STOCK.STOCKSECTIONCDRF," + Environment.NewLine;
                                sqlText += "   STOCK.SUPPLIERCDRF," + Environment.NewLine;
                                sqlText += "   STOCK.SUPPLIERCONSTAXRATERF" + Environment.NewLine;
                                break;
                        }

                        // 請求転嫁のみの場合、消費税子検索を行う
                        if (!string.IsNullOrEmpty(sqlText))
                        {
                            sqlCommand.CommandText = sqlText;
                            myReader = sqlCommand.ExecuteReader();
                        }

                        // 仕入伝票合計（税抜き）
                        long stockTotal = 0;
                        // 消費税税率
                        double supplierConsTaxRate = 0.0;
                        // 消費税(端数処理後)
                        long tempTax = 0;

                        while (myReader.Read())
                        {
                            switch (suppCTaxLayCd)
                            {
                                // 請求親
                                case 2:
                                // 請求子
                                case 3:
                                    stockTotal = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKTTLPRICTAXEXCRF"));
                                    supplierConsTaxRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SUPPLIERCONSTAXRATERF"));

                                    if (supplierConsTaxRate == accPaymentListCndtnWork.TaxRate1)
                                    {
                                        FracCalc(stockTotal * supplierConsTaxRate, fractionProcUnit, suplAccPayWork.FractionProcCd, out tempTax);
                                        accPaymentWork.TotalStockPricTaxTaxRate1 += tempTax;
                                    }
                                    else if (supplierConsTaxRate == accPaymentListCndtnWork.TaxRate2)
                                    {
                                        FracCalc(stockTotal * supplierConsTaxRate, fractionProcUnit, suplAccPayWork.FractionProcCd, out tempTax);
                                        accPaymentWork.TotalStockPricTaxTaxRate2 += tempTax;
                                    }
                                    else
                                    {
                                        FracCalc(stockTotal * supplierConsTaxRate, fractionProcUnit, suplAccPayWork.FractionProcCd, out tempTax);
                                        accPaymentWork.TotalStockPricTaxOther += tempTax;
                                    }
                                    break;
                            }
                        }

                        sqlText = string.Empty;
                        if (!myReader.IsClosed) myReader.Close();
                    }

                    accPaymentWork.TotalStckTtlAccPayBalanceTaxRate1 = accPaymentWork.TotalPureStockTaxRate1 + accPaymentWork.TotalStockPricTaxTaxRate1;
                    accPaymentWork.TotalStckTtlAccPayBalanceTaxRate2 = accPaymentWork.TotalPureStockTaxRate2 + accPaymentWork.TotalStockPricTaxTaxRate2;
                    // --- ADD START 3H 仰亮亮 2022/10/20 ----->>>>>
                    // 当月合計(計非課税)
                    accPaymentWork.TotalStckTtlAccPayBalanceTaxFree = accPaymentWork.TotalPureStockTaxFree + accPaymentWork.TotalStockPricTaxTaxFree;
                    // --- ADD END 3H 仰亮亮 2022/10/20 -----<<<<<
                    accPaymentWork.TotalStckTtlAccPayBalanceOther = accPaymentWork.TotalPureStockOther + accPaymentWork.TotalStockPricTaxOther;
                    #endregion

                    #endregion
                }

                accPaymentWork.TitleTaxRate1 = Convert.ToInt32(accPaymentListCndtnWork.TaxRate1 * 100) + "%";
                accPaymentWork.TitleTaxRate2 = Convert.ToInt32(accPaymentListCndtnWork.TaxRate2 * 100) + "%";
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "AccPaymentListWorkDB.SearchStockProc Exception=" + ex.Message);
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
        /// 支払内訳区分を列挙します。
        /// </summary>
        enum PayDtlDiv
        {
            PayDtlON = 0,  //0:印字する
            PayDtlOFF = 1  //1:印字しない
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
    public class SuplAccPayDateInfo
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

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
// --- ADD 2012/11/20 ---------->>>>>
using Broadleaf.Application.Common;
// --- ADD 2012/11/20 ----------<<<<<

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 買掛残高一覧表DBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 買掛残高一覧表の実データ操作を行うクラスです。</br>
    /// <br>Programmer : 22008 長内 数馬</br>
    /// <br>Date       : 2007.11.15</br>
    /// <br></br>
    /// <br>Note       : ＰＭ.ＮＳ用に修正</br>
    /// <br>Programmer : 23015  森本 大輝</br>
    /// <br>Date       : 2008.09.22</br>
    /// <br></br>
    /// <br>Note       : 不具合修正</br>
    /// <br>Programmer : 23012  畠中 啓次朗</br>
    /// <br>Date       : 2008.10.18</br>
    /// <br></br>
    /// <br>Note       : 論理削除対応</br>
    /// <br>Programmer : 22008  長内 数馬</br>
    /// <br>Date       : 2009.04.30</br>
    /// <br></br>
    /// <br>Note       : 不具合修正</br>
    /// <br>Programmer : 23012  畠中 啓次朗</br>
    /// <br>Date       : 2009.06.02</br>
    /// <br></br>
    /// <br>Note       : 仕入先総括対応に伴う対応</br>
    /// <br>Programmer : 30755 FSI菅原(庸)</br>
    /// <br>Date       : 2012/10/01</br>   
    /// <br></br>
    /// <br>Note       : 手数料と値引き以外の支払伝票の場合、印字されない対応</br>
    /// <br>Programmer : 30755 FSI菅原(庸)</br>
    /// <br>Date       : 2012/11/07</br>
    /// <br></br>
    /// <br>Note       : 当月支払が手数料分合わない対応</br>
    /// <br>Programmer : 30755 FSI菅原(庸)</br>
    /// <br>Date       : 2012/11/13</br>
    /// <br></br>
    /// <br>Note       : 仕入総括オプション無→有の対応</br>
    /// <br>Programmer : 30755 FSI菅原(庸)</br>
    /// <br>Date       : 2012/11/14</br>
    /// <br></br>
    /// <br>Note       : 今回月次処理日+1カ月が正しく印字されない対応</br>
    /// <br>Programmer : 30755 FSI菅原(庸)</br>
    /// <br>Date       : 2012/11/20</br>
    /// <br>UpdateNote : 11570208-00 軽減税率対応</br>
    /// <br>Programmer : 3H 劉星光</br>
    /// <br>Date       : 2020/03/02</br>
    /// <br>UpdateNote : 11870141-00 インボイス対応（税率別合計金額不具合修正）</br>
    /// <br>Programmer : 3H 仰亮亮</br>
    /// <br>Date       : 2022/10/09</br>
    /// </remarks>
    [Serializable]
    public class AccPaymentListWorkDB : RemoteDB, IAccPaymentListWorkDB
    {
        private int _timeOut = 3600;//ADD 2020/03/02 石崎　軽減税率対応
        /// <summary>
        /// 買掛残高一覧表DBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2007.11.15</br>
        /// </remarks>
        public AccPaymentListWorkDB()
            :
            base("DCKAK02636D", "Broadleaf.Application.Remoting.ParamData.AccPaymentListResultWork", "SUPLACCPAYRF")
        {
        }

        /// <summary>売掛/買掛金額マスタ更新リモートオブジェクト</summary>
        private MonthlyAddUpDB _monthlyAddUpDB;

        #region [Search]
        /// <summary>
        /// 指定された条件の買掛残高一覧表を戻します
        /// </summary>
        /// <param name="accPaymentListResultWork">検索結果</param>
        /// <param name="accPaymentListCndtnWork">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の買掛残高一覧表を戻します</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2007.11.15</br>
        public int Search(out object accPaymentListResultWork, object accPaymentListCndtnWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            accPaymentListResultWork = null;

            ArrayList _accPaymentListCndtnWorkList = accPaymentListCndtnWork as ArrayList;
            AccPaymentListCndtnWork _accPaymentListCndtnWork = null;

            if (_accPaymentListCndtnWorkList == null)
            {
                _accPaymentListCndtnWork = accPaymentListCndtnWork as AccPaymentListCndtnWork;
            }
            else
            {
                if (_accPaymentListCndtnWorkList.Count > 0)
                    _accPaymentListCndtnWork = _accPaymentListCndtnWorkList[0] as AccPaymentListCndtnWork;
            }

            try
            {
                status = SearchProc(out accPaymentListResultWork, _accPaymentListCndtnWork, readMode, logicalMode);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "AccPaymentListWorkDB.Search Exception=" + ex.Message);
                accPaymentListResultWork = new ArrayList();
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }

            return status;
        }
        #endregion  //[Search]

        #region [SearchProc]
        /// <summary>
        /// 指定された企業コードの買掛残高一覧表LISTを全て戻します
        /// </summary>
        /// <param name="accPaymentListResultWork">検索結果</param>
        /// <param name="_accPaymentListCndtnWork">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された企業コードの買掛残高一覧表LISTを全て戻します</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2007.11.15</br>
        /// <br></br>
        /// <br>Update Note: 2007.11.15 長内 DC.NS用に修正</br>
        /// <br></br>
        /// <br>Update Note: PM.NS用に修正</br>
        /// <br>Programmer : 23015 森本 大輝</br>
        /// <br>Date       : 2008.09.22</br>
        /// <br></br>
        /// <br>Update Note: 不具合修正</br>
        /// <br>Programmer : 23012 畠中 啓次朗</br>
        /// <br>Date       : 2008.10.18</br>
        /// <br></br>
        /// <br>Update Note: 仕入先総括対応に伴う対応</br>
        /// <br>Programmer : FSI菅原(庸)</br>
        /// <br>Date       : 2012/10/01</br>
        /// <br></br>
        /// <br>Note       : 手数料と値引き以外の支払伝票の場合、印字されない対応</br>
        /// <br>Programmer : 30755 FSI菅原(庸)</br>
        /// <br>Date       : 2012/11/07</br>
        /// <br></br>
        /// <br>Note       : 当月支払が手数料分合わない対応</br>
        /// <br>Programmer : 30755 FSI菅原(庸)</br>
        /// <br>Date       : 2012/11/13</br>
        /// <br></br>
        /// <br>Note       : 仕入総括オプション無→有の対応</br>
        /// <br>Programmer : 30755 FSI菅原(庸)</br>
        /// <br>Date       : 2012/11/14</br>
        /// <br></br>
        /// <br>Note       : 今回月次処理日+1カ月が正しく印字されない対応</br>
        /// <br>Programmer : 30755 FSI菅原(庸)</br>
        /// <br>Date       : 2012/11/20</br>
        /// <br>UpdateNote : 11570208-00 軽減税率対応</br>
        /// <br>Programmer : 3H 劉星光</br>
        /// <br>Date	   : 2020/03/02</br>
        private int SearchProc(out object accPaymentListResultWork, AccPaymentListCndtnWork _accPaymentListCndtnWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;

            accPaymentListResultWork = null;
            // --- ADD START 3H 劉星光 2020/03/02 ---------->>>>>
            // 締次フラッグ
            bool isCheckOut = true;
            // 支払先前回月次更新年月日
            Dictionary<string, DateTime> payeeDateDic = new Dictionary<string, DateTime>();
            // --- ADD END 3H 劉星光 2020/03/02 ----------<<<<<
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
// 修正 2009.01.27 >>>
                #region DEL 2009.01.27   
                /*
                para.EnterpriseCode = _accPaymentListCndtnWork.EnterpriseCode;  //企業コード
                status = ttlDayCalcDB.SearchHisMonthlyAccPay(out retList, para, ref sqlConnection);
                //日付変換
                Int32 iAddUpDate = Int32.Parse(_accPaymentListCndtnWork.AddUpDate.ToString("yyyyMMdd"));

                // ADD 2008.10.18 >>>            
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    #region [未締め -> 売掛金・買掛金集計モジュールから取得]
                    ArrayList SupplierList = new ArrayList();

                    //仕入先マスタリスト作成
                    status = SearchSuppProc(ref SupplierList, _accPaymentListCndtnWork, ref sqlConnection, logicalMode);
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

                    //売掛金・買掛金集計モジュール呼出
                    for (int i = 0; i < SupplierList.Count; i++)
                    {
                        //売掛金・買掛金集計モジュールパラメータセット
                        this._monthlyAddUpDB = new MonthlyAddUpDB();
                        SuplAccPayWork suplAccPayWork = new SuplAccPayWork();
                        suplAccPayWork.EnterpriseCode = _accPaymentListCndtnWork.EnterpriseCode;                 //企業コード
                        suplAccPayWork.AddUpDate = _accPaymentListCndtnWork.AddUpDate;                           //計上年月日
                        suplAccPayWork.AddUpYearMonth = _accPaymentListCndtnWork.AddUpYearMonth;                 //計上年月
                        suplAccPayWork.AddUpSecCode = ((AccPaymentListResultWork)SupplierList[i]).AddUpSecCode;  //計上拠点コード ※仕入先マスタリストから
                        suplAccPayWork.SupplierCd = ((AccPaymentListResultWork)SupplierList[i]).PayeeCode;       //仕入先コード   ※仕入先マスタリストから
                        object paraObj2 = (object)suplAccPayWork;
                        string retMsg = null;

                        //売掛金・買掛金集計モジュール呼出
                        status = _monthlyAddUpDB.ReadSuplAccPay(ref paraObj2, out retMsg);
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
                                switch (_accPaymentListCndtnWork.OutMoneyDiv)
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
                                AccPaymentListResultWork ResultWork = new AccPaymentListResultWork();

                                //拠点コード ※仕入先マスタから
                                ResultWork.AddUpSecCode = ((AccPaymentListResultWork)SupplierList[i]).AddUpSecCode;
                                //拠点名称 ※拠点情報設定マスタから
                                ResultWork.SectionGuideSnm = ((AccPaymentListResultWork)SupplierList[i]).SectionGuideSnm;
                                //請求先コード ※仕入先マスタから
                                ResultWork.PayeeCode = ((AccPaymentListResultWork)SupplierList[i]).PayeeCode;
                                //請求先略称 ※仕入先マスタから
                                ResultWork.PayeeSnm = ((AccPaymentListResultWork)SupplierList[i]).PayeeSnm;
                                //前月買掛残
                                ResultWork.LastTimeAccPay = ((SuplAccPayWork)SuplAccRecResult[j]).LastTimeAccPay;
                                //当月支払
                                ResultWork.ThisTimePayNrml = ((SuplAccPayWork)SuplAccRecResult[j]).ThisTimePayNrml;
                                //繰越額
                                ResultWork.ThisTimeTtlBlcAcPay = ((SuplAccPayWork)SuplAccRecResult[j]).ThisTimeTtlBlcAcPay;
                                //仕入額
                                ResultWork.OfsThisTimeStock = ((SuplAccPayWork)SuplAccRecResult[j]).OfsThisTimeStock;
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

                                if (_accPaymentListCndtnWork.PayDtlDiv == (int)PayDtlDiv.PayDtlON)
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
                                    ResultWork.CashPayment = ((AccPaymentListResultWork)PaymentList[0]).CashPayment;
                                    //振込
                                    ResultWork.TrfrPayment = ((AccPaymentListResultWork)PaymentList[0]).TrfrPayment;
                                    //小切手
                                    ResultWork.CheckPayment = ((AccPaymentListResultWork)PaymentList[0]).CheckPayment;
                                    //手形
                                    ResultWork.DraftPayment = ((AccPaymentListResultWork)PaymentList[0]).DraftPayment;
                                    //相殺
                                    ResultWork.OffsetPayment = ((AccPaymentListResultWork)PaymentList[0]).OffsetPayment;
                                    //口座振替
                                    ResultWork.FundTransferPayment = ((AccPaymentListResultWork)PaymentList[0]).FundTransferPayment;
                                    //その他
                                    ResultWork.OthsPayment = ((AccPaymentListResultWork)PaymentList[0]).OthsPayment;
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
                    }
                    #endregion  //[未締め -> 売掛金・買掛金集計モジュールから取得]
                }
                else
                // ADD 2008.10.18 <<<

                //日付比較
                if (retList[0].TotalDay < iAddUpDate)
                {
                    #region [未締め -> 売掛金・買掛金集計モジュールから取得]
                    ArrayList SupplierList = new ArrayList();

                    //仕入先マスタリスト作成
                    status = SearchSuppProc(ref SupplierList, _accPaymentListCndtnWork, ref sqlConnection, logicalMode);
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

                    //売掛金・買掛金集計モジュール呼出
                    for (int i = 0; i < SupplierList.Count; i++)
                    {
                        //売掛金・買掛金集計モジュールパラメータセット
                        this._monthlyAddUpDB = new MonthlyAddUpDB();
                        SuplAccPayWork suplAccPayWork = new SuplAccPayWork();
                        suplAccPayWork.EnterpriseCode = _accPaymentListCndtnWork.EnterpriseCode;                 //企業コード
                        suplAccPayWork.AddUpDate = _accPaymentListCndtnWork.AddUpDate;                           //計上年月日
                        suplAccPayWork.AddUpYearMonth = _accPaymentListCndtnWork.AddUpYearMonth;                 //計上年月
                        suplAccPayWork.AddUpSecCode = ((AccPaymentListResultWork)SupplierList[i]).AddUpSecCode;  //計上拠点コード ※仕入先マスタリストから
                        suplAccPayWork.SupplierCd = ((AccPaymentListResultWork)SupplierList[i]).PayeeCode;       //仕入先コード   ※仕入先マスタリストから
                        object paraObj2 = (object)suplAccPayWork;
                        string retMsg = null;

                        //売掛金・買掛金集計モジュール呼出
                        status = _monthlyAddUpDB.ReadSuplAccPay(ref paraObj2, out retMsg);
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
                                switch (_accPaymentListCndtnWork.OutMoneyDiv)
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
                                AccPaymentListResultWork ResultWork = new AccPaymentListResultWork();

                                //拠点コード ※仕入先マスタから
                                ResultWork.AddUpSecCode = ((AccPaymentListResultWork)SupplierList[i]).AddUpSecCode;
                                //拠点名称 ※拠点情報設定マスタから
                                ResultWork.SectionGuideSnm = ((AccPaymentListResultWork)SupplierList[i]).SectionGuideSnm;
                                //請求先コード ※仕入先マスタから
                                ResultWork.PayeeCode = ((AccPaymentListResultWork)SupplierList[i]).PayeeCode;
                                //請求先略称 ※仕入先マスタから
                                ResultWork.PayeeSnm = ((AccPaymentListResultWork)SupplierList[i]).PayeeSnm;
                                //前月買掛残
                                ResultWork.LastTimeAccPay = ((SuplAccPayWork)SuplAccRecResult[j]).LastTimeAccPay;
                                //当月支払
                                ResultWork.ThisTimePayNrml = ((SuplAccPayWork)SuplAccRecResult[j]).ThisTimePayNrml;
                                //繰越額
                                ResultWork.ThisTimeTtlBlcAcPay = ((SuplAccPayWork)SuplAccRecResult[j]).ThisTimeTtlBlcAcPay;
                                //仕入額
                                ResultWork.OfsThisTimeStock = ((SuplAccPayWork)SuplAccRecResult[j]).OfsThisTimeStock;
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

                                if (_accPaymentListCndtnWork.PayDtlDiv == (int)PayDtlDiv.PayDtlON)
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
                                    ResultWork.CashPayment = ((AccPaymentListResultWork)PaymentList[0]).CashPayment;
                                    //振込
                                    ResultWork.TrfrPayment = ((AccPaymentListResultWork)PaymentList[0]).TrfrPayment;
                                    //小切手
                                    ResultWork.CheckPayment = ((AccPaymentListResultWork)PaymentList[0]).CheckPayment;
                                    //手形
                                    ResultWork.DraftPayment = ((AccPaymentListResultWork)PaymentList[0]).DraftPayment;
                                    //相殺
                                    ResultWork.OffsetPayment = ((AccPaymentListResultWork)PaymentList[0]).OffsetPayment;
                                    //口座振替
                                    ResultWork.FundTransferPayment = ((AccPaymentListResultWork)PaymentList[0]).FundTransferPayment;
                                    //その他
                                    ResultWork.OthsPayment = ((AccPaymentListResultWork)PaymentList[0]).OthsPayment;
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
                    }
                    #endregion  //[未締め -> 売掛金・買掛金集計モジュールから取得]
                }
                else
                {
                    //締め済 -> 得意先売掛金額マスタから取得
                    //検索実行
                    status = SearchAccPaymentProc(ref al, _accPaymentListCndtnWork, ref sqlConnection, logicalMode);
                }
                */
                #endregion
                ArrayList SupplierList = new ArrayList();
                AccPaymentListResultWork SupplierListWork = new AccPaymentListResultWork();

                //仕入先マスタリスト作成
                // --- DEL 2012/10/01 ---------->>>>>
                //status = SearchSuppProc(ref SupplierList, _accPaymentListCndtnWork, ref sqlConnection, logicalMode);
                // --- DEL 2012/10/01 ----------<<<<<
                // --- ADD 2012/10/01 ---------->>>>>
                //仕入総括オプションが無効の場合
                if (_accPaymentListCndtnWork.OptSuppEnable == 1)
                {
                    status = SearchSuppProc(ref SupplierList, _accPaymentListCndtnWork, ref sqlConnection, logicalMode);
                }
                //仕入総括オプションが有効の場合
                else
                {
                    status = SearchSuppGeneralProc(ref SupplierList, _accPaymentListCndtnWork, ref sqlConnection, logicalMode);
                }
                // --- ADD 2012/10/01 ----------<<<<<
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

                // --- ADD 2012/11/14 ---------->>>>>
                //仕入総括オプションが有効の場合
                if (_accPaymentListCndtnWork.OptSuppEnable == 2)
                {
                    ArrayList MonAddUpCAddUpHisList = new ArrayList();

                    //月次締更新履歴マスタからリストを取得する。
                    status = SearchMonAddUpProc(ref MonAddUpCAddUpHisList, _accPaymentListCndtnWork, ref sqlConnection);

                    //該当データチェック
                    if (MonAddUpCAddUpHisList.Count != 0)
                    {
                        //締状態チェック
                        for (int k = 0; k < MonAddUpCAddUpHisList.Count; k++)
                        {
                            //履歴制御区分が確定の場合
                            if (((MonAddUpCAddUpHisResultWork)MonAddUpCAddUpHisList[k]).HistCtlCd == 0)
                            {
                                //他の計上拠点を再度チェックする
                                for (int l = 0; l < MonAddUpCAddUpHisList.Count; l++)
                                {
                                    //履歴制御区分が未確定の場合
                                    if (((MonAddUpCAddUpHisResultWork)MonAddUpCAddUpHisList[l]).HistCtlCd == 1)
                                    {
                                        //前レコード数を取得
                                        int m = l;
                                        m--;

                                        //親は履歴制御区分0と1があるので、前レコードと現レコードの計上拠点コードを見る。
                                        if (((MonAddUpCAddUpHisResultWork)MonAddUpCAddUpHisList[m]).AddUpSecCode == ((MonAddUpCAddUpHisResultWork)MonAddUpCAddUpHisList[l]).AddUpSecCode)
                                        {
                                            continue;
                                        }
                                        else
                                        {
                                            //月次締更新履歴UPDATEモジュールパラメータセット
                                            MonAddUpCAddUpHisResultWork monAddUpCAddUpHisWork = new MonAddUpCAddUpHisResultWork();
                                            monAddUpCAddUpHisWork.MonthlyAddUpDate = _accPaymentListCndtnWork.AddUpYearMonth;
                                            monAddUpCAddUpHisWork.AddUpSecCode = ((MonAddUpCAddUpHisResultWork)MonAddUpCAddUpHisList[l]).AddUpSecCode;
                                            _accPaymentListCndtnWork.AddUpSecCode = ((MonAddUpCAddUpHisResultWork)MonAddUpCAddUpHisList[l]).AddUpSecCode;
                                            _accPaymentListCndtnWork.MonAddUpEnable = 1;

                                            ArrayList MonAddDataUpTimeList = new ArrayList();

                                            //最後に更新した月次締更新履歴データの履歴制御区分が未確定のデータ更新日時を1件取得する。(ナノ秒)
                                            SearchMonAddDataUpTimeProc(ref MonAddDataUpTimeList, _accPaymentListCndtnWork, ref sqlConnection);

                                            monAddUpCAddUpHisWork.DataUpdateDateTime = ((MonAddUpCAddUpHisResultWork)MonAddDataUpTimeList[0]).DataUpdateDateTime;

                                            //履歴制御区分を確定にする
                                            SearchMonAddUpDateProc(ref monAddUpCAddUpHisWork, ref sqlConnection);

                                            continue;
                                        }
                                    }
                                    else
                                    {
                                        //履歴制御区分が確定なので次のレコード
                                        continue;
                                    }
                                }
                                k = MonAddUpCAddUpHisList.Count;
                            }
                            else
                            {
                                //履歴制御区分が未確定の場合は次のレコード
                                continue;
                            }
                        }

                        int o = 0;
                        string iAddUpSecCode = null;
                        string jAddUpSecCode = null;

                        for (int n = 0; n < SupplierList.Count; n++)
                        {
                            //リストを再取得する。
                            ArrayList MonAddUpCAddUpHisList2 = new ArrayList();
                            SearchMonAddUpProc(ref MonAddUpCAddUpHisList2, _accPaymentListCndtnWork, ref sqlConnection);

                            //月次締更新履歴リストから重複している計上拠点を削除する。
                            for (int p = 0; p < MonAddUpCAddUpHisList2.Count; p++)
                            {
                                if (((MonAddUpCAddUpHisResultWork)MonAddUpCAddUpHisList2[p]).AddUpSecCode == ((MonAddUpCAddUpHisResultWork)MonAddUpCAddUpHisList2[p]).AddUpSecCode)
                                {
                                    if (((MonAddUpCAddUpHisResultWork)MonAddUpCAddUpHisList2[p]).HistCtlCd == 1)
                                    {
                                        int i = p;
                                        i++;
                                        if (MonAddUpCAddUpHisList2.Count < i)
                                        {
                                            //何もしない
                                        }
                                        else
                                        {
                                            MonAddUpCAddUpHisList2.RemoveAt(p);
                                            p--;
                                        }
                                    }
                                    else
                                    {
                                        continue;
                                    }
                                }
                                else
                                {
                                    continue;
                                }
                            }

                            if (MonAddUpCAddUpHisList2.Count != 0)
                            {
                                if (((AccPaymentListResultWork)SupplierList[n]).AddUpSecCode != ((MonAddUpCAddUpHisResultWork)MonAddUpCAddUpHisList2[o]).AddUpSecCode)
                                {
                                    int g = o;
                                    g++;
                                    if (MonAddUpCAddUpHisList2.Count <= g)
                                    {
                                        //何もしない
                                    }
                                    else
                                    {
                                        o++;
                                    }

                                    if (((AccPaymentListResultWork)SupplierList[n]).AddUpSecCode != ((MonAddUpCAddUpHisResultWork)MonAddUpCAddUpHisList2[o]).AddUpSecCode)
                                    {
                                        //前回と同じ拠点番号かチェックする。
                                        if (jAddUpSecCode != ((AccPaymentListResultWork)SupplierList[n]).AddUpSecCode)
                                        {
                                            iAddUpSecCode = ((MonAddUpCAddUpHisResultWork)MonAddUpCAddUpHisList2[o]).AddUpSecCode;
                                            jAddUpSecCode = ((AccPaymentListResultWork)SupplierList[n]).AddUpSecCode;

                                            //月次締更新履歴INSERTモジュールパラメータセット
                                            MonAddUpCAddUpHisResultWork monAddUpCAddUpHisWork = new MonAddUpCAddUpHisResultWork();
                                            monAddUpCAddUpHisWork.MonthlyAddUpDate = _accPaymentListCndtnWork.AddUpYearMonth;
                                            monAddUpCAddUpHisWork.AddUpSecCode = iAddUpSecCode;
                                            _accPaymentListCndtnWork.AddUpSecCode = iAddUpSecCode;
                                            _accPaymentListCndtnWork.MonAddUpEnable = 2;

                                            ArrayList MonAddDataUpTimeList = new ArrayList();

                                            //最後に更新した月次締更新履歴データの履歴制御区分が未確定のデータ更新日時を1件取得する。(ナノ秒)
                                            SearchMonAddDataUpTimeProc(ref MonAddDataUpTimeList, _accPaymentListCndtnWork, ref sqlConnection);

                                            monAddUpCAddUpHisWork.CreateDateTime = ((MonAddUpCAddUpHisResultWork)MonAddDataUpTimeList[0]).CreateDateTime;
                                            monAddUpCAddUpHisWork.UpdateDateTime = ((MonAddUpCAddUpHisResultWork)MonAddDataUpTimeList[0]).UpdateDateTime;
                                            monAddUpCAddUpHisWork.EnterpriseCode = ((MonAddUpCAddUpHisResultWork)MonAddDataUpTimeList[0]).EnterpriseCode;
                                            monAddUpCAddUpHisWork.FileHeaderGuid = ((MonAddUpCAddUpHisResultWork)MonAddDataUpTimeList[0]).FileHeaderGuid;
                                            monAddUpCAddUpHisWork.UpdEmployeeCode = ((MonAddUpCAddUpHisResultWork)MonAddDataUpTimeList[0]).UpdEmployeeCode;
                                            monAddUpCAddUpHisWork.UpdAssemblyId1 = ((MonAddUpCAddUpHisResultWork)MonAddDataUpTimeList[0]).UpdAssemblyId1;
                                            monAddUpCAddUpHisWork.UpdAssemblyId2 = ((MonAddUpCAddUpHisResultWork)MonAddDataUpTimeList[0]).UpdAssemblyId2;
                                            monAddUpCAddUpHisWork.LogicalDeleteCode = ((MonAddUpCAddUpHisResultWork)MonAddDataUpTimeList[0]).LogicalDeleteCode;
                                            monAddUpCAddUpHisWork.AccRecAccPayDiv = ((MonAddUpCAddUpHisResultWork)MonAddDataUpTimeList[0]).AccRecAccPayDiv;
                                            monAddUpCAddUpHisWork.AddUpSecCode = jAddUpSecCode;
                                            monAddUpCAddUpHisWork.StMonCAddUpUpdDate = ((MonAddUpCAddUpHisResultWork)MonAddDataUpTimeList[0]).StMonCAddUpUpdDate;
                                            monAddUpCAddUpHisWork.MonthlyAddUpDate = ((MonAddUpCAddUpHisResultWork)MonAddDataUpTimeList[0]).MonthlyAddUpDate;
                                            monAddUpCAddUpHisWork.MonthAddUpYearMonth = ((MonAddUpCAddUpHisResultWork)MonAddDataUpTimeList[0]).MonthAddUpYearMonth;
                                            monAddUpCAddUpHisWork.MonthAddUpExpDate = ((MonAddUpCAddUpHisResultWork)MonAddDataUpTimeList[0]).MonthAddUpExpDate;
                                            monAddUpCAddUpHisWork.LaMonCAddUpUpdDate = ((MonAddUpCAddUpHisResultWork)MonAddDataUpTimeList[0]).LaMonCAddUpUpdDate;
                                            monAddUpCAddUpHisWork.DataUpdateDateTime = ((MonAddUpCAddUpHisResultWork)MonAddDataUpTimeList[0]).DataUpdateDateTime;
                                            monAddUpCAddUpHisWork.ProcDivCd = ((MonAddUpCAddUpHisResultWork)MonAddDataUpTimeList[0]).ProcDivCd;
                                            monAddUpCAddUpHisWork.ErrorStatus = ((MonAddUpCAddUpHisResultWork)MonAddDataUpTimeList[0]).ErrorStatus;
                                            monAddUpCAddUpHisWork.HistCtlCd = ((MonAddUpCAddUpHisResultWork)MonAddDataUpTimeList[0]).HistCtlCd;
                                            monAddUpCAddUpHisWork.ProcResult = ((MonAddUpCAddUpHisResultWork)MonAddDataUpTimeList[0]).ProcResult;
                                            monAddUpCAddUpHisWork.ConvertProcessDivCd = ((MonAddUpCAddUpHisResultWork)MonAddDataUpTimeList[0]).ConvertProcessDivCd;

                                            //締済みデータとしてレコードに追加する
                                            SearchMonAddDataInsertProc(ref monAddUpCAddUpHisWork, ref sqlConnection);

                                        }
                                        else
                                        {
                                            continue;
                                        }
                                    }
                                }
                                else
                                {
                                    continue;
                                }
                            }
                        }
                    }
                }
                // --- ADD 2012/11/14 ----------<<<<<

                for (int i = 0; i < SupplierList.Count; i++)
                {
                    // 締日チェック
                    para.EnterpriseCode = _accPaymentListCndtnWork.EnterpriseCode;  //企業コード
                    para.SectionCode = ((AccPaymentListResultWork)SupplierList[i]).AddUpSecCode; // 拠点コード
                    status = ttlDayCalcDB.SearchHisMonthlyAccPay(out retList, para, ref sqlConnection);
                    Int32 iAddUpDate = Int32.Parse(_accPaymentListCndtnWork.AddUpDate.ToString("yyyyMMdd"));
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL || retList[0].TotalDay < iAddUpDate)
                    {
                        #region 未締処理
                        // --- ADD 2012/11/20 ---------->>>>>
                        DateTime AddUpDate;

                        //今回月次処理日を取得
                        if (status == 9)
                        {
                            AddUpDate = _accPaymentListCndtnWork.AddUpDate;
                        }
                        else
                        {
                            AddUpDate = DateTime.ParseExact(retList[0].TotalDay.ToString(), "yyyyMMdd", System.Globalization.DateTimeFormatInfo.InvariantInfo);
                            AddUpDate = AddUpDate.AddDays(1);
                        }
                        //売掛金・買掛金集計モジュールパラメータセット(今回月次処理日+1カ月)
                        this._monthlyAddUpDB = new MonthlyAddUpDB();
                        SuplAccPayWork suplAccPayWork2 = new SuplAccPayWork();
                        suplAccPayWork2.EnterpriseCode = _accPaymentListCndtnWork.EnterpriseCode;                 //企業コード
                        // --- UPD START 3H 劉星光 2020/03/02 ---------->>>>>
                        //suplAccPayWork2.AddUpDate = _accPaymentListCndtnWork.AddUpDate.AddMonths(-1);             //計上年月日
                        // 期首年月日の日が一日の場合
                        if (_accPaymentListCndtnWork.AddUpDate.Day > 27)
                        {     
                            // 前月の末日を設定する
                            suplAccPayWork2.AddUpDate = _accPaymentListCndtnWork.AddUpDate.AddDays(1 - _accPaymentListCndtnWork.AddUpDate.Day).AddDays(-1);
                        }
                        // 上記以外の場合
                        else
                        {     
                            // 既存のままで前月を設定する
                            suplAccPayWork2.AddUpDate = _accPaymentListCndtnWork.AddUpDate.AddMonths(-1);
                        }
                        // --- UPD END 3H 劉星光 2020/03/02 ----------<<<<<
                        suplAccPayWork2.AddUpYearMonth = _accPaymentListCndtnWork.AddUpYearMonth.AddMonths(-1);   //計上年月
                        suplAccPayWork2.AddUpSecCode = ((AccPaymentListResultWork)SupplierList[i]).AddUpSecCode;  //計上拠点コード ※仕入先マスタリストから
                        suplAccPayWork2.SupplierCd = ((AccPaymentListResultWork)SupplierList[i]).PayeeCode;       //仕入先コード   ※仕入先マスタリストから
                        object paraObj3 = (object)suplAccPayWork2;
                        string retMsg1 = null;

                        //仕入総括オプションが無効の場合
                        if (_accPaymentListCndtnWork.OptSuppEnable == 1)
                        {
                            //売掛金・買掛金集計モジュール呼出
                            status = _monthlyAddUpDB.ReadSuplAccPay(ref paraObj3, out retMsg1);
                        }
                        //仕入総括オプションが有効の場合
                        else
                        {
                            //売掛金・買掛金集計モジュール呼出
                            status = _monthlyAddUpDB.ReadSuplAccPayByAddUpSecCode(ref paraObj3, out retMsg1);
                        }

                        //取得結果キャスト
                        ArrayList SuplAccRecResult2 = new ArrayList();
                        SuplAccRecResult2.Add((SuplAccPayWork)paraObj3);
                        // --- ADD 2012/11/20 ----------<<<<<

                        //売掛金・買掛金集計モジュールパラメータセット(今回月次処理日)
                        this._monthlyAddUpDB = new MonthlyAddUpDB();
                        SuplAccPayWork suplAccPayWork = new SuplAccPayWork();
                        suplAccPayWork.EnterpriseCode = _accPaymentListCndtnWork.EnterpriseCode;                 //企業コード
                        suplAccPayWork.AddUpDate = _accPaymentListCndtnWork.AddUpDate;                           //計上年月日
                        suplAccPayWork.AddUpYearMonth = _accPaymentListCndtnWork.AddUpYearMonth;                 //計上年月
                        suplAccPayWork.AddUpSecCode = ((AccPaymentListResultWork)SupplierList[i]).AddUpSecCode;  //計上拠点コード ※仕入先マスタリストから
                        suplAccPayWork.SupplierCd = ((AccPaymentListResultWork)SupplierList[i]).PayeeCode;       //仕入先コード   ※仕入先マスタリストから
                        // --- ADD 2012/11/20 ---------->>>>>
                        if (AddUpDate != _accPaymentListCndtnWork.AddUpYearMonth)
                        {
                            DateTime StMonthDate = DateTime.MinValue;
                            DateTime EdMonthDate = DateTime.MinValue;
                            DateTime AddUpYearMonth = _accPaymentListCndtnWork.AddUpYearMonth;
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
                        // --- ADD 2012/11/20 ----------<<<<<
                        object paraObj2 = (object)suplAccPayWork;
                        string retMsg = null;

                        // --- DEL 2012/10/01 ---------->>>>>
                        //売掛金・買掛金集計モジュール呼出
                        //status = _monthlyAddUpDB.ReadSuplAccPay(ref paraObj2, out retMsg);
                        // --- DEL 2012/10/01 ----------<<<<<

                        // --- ADD 2012/10/01 ---------->>>>>
                        //仕入総括オプションが無効の場合
                        if (_accPaymentListCndtnWork.OptSuppEnable == 1)
                        {
                            //売掛金・買掛金集計モジュール呼出
                            status = _monthlyAddUpDB.ReadSuplAccPay(ref paraObj2, out retMsg);
                        }
                        //仕入総括オプションが有効の場合
                        else
                        {
                            //売掛金・買掛金集計モジュール呼出
                            status = _monthlyAddUpDB.ReadSuplAccPayByAddUpSecCode(ref paraObj2, out retMsg);
                        }
                        // --- ADD 2012/10/01 ----------<<<<<
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
                                switch (_accPaymentListCndtnWork.OutMoneyDiv)
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
                                AccPaymentListResultWork ResultWork = new AccPaymentListResultWork();

                                //拠点コード ※仕入先マスタから
                                ResultWork.AddUpSecCode = ((AccPaymentListResultWork)SupplierList[i]).AddUpSecCode;
                                //拠点名称 ※拠点情報設定マスタから
                                ResultWork.SectionGuideSnm = ((AccPaymentListResultWork)SupplierList[i]).SectionGuideSnm;
                                //請求先コード ※仕入先マスタから
                                ResultWork.PayeeCode = ((AccPaymentListResultWork)SupplierList[i]).PayeeCode;
                                //請求先略称 ※仕入先マスタから
                                ResultWork.PayeeSnm = ((AccPaymentListResultWork)SupplierList[i]).PayeeSnm;
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

                                // --- DEL 2012/11/07 ---------->>>>>
                                // 0実績チェック
                                //if (ResultWork.LastTimeAccPay == 0 && ResultWork.ThisTimeFeePayNrml ==0 &&
                                //    ResultWork.ThisTimeDisPayNrml == 0 && ResultWork.OfsThisTimeStock == 0 &&
                                //    ResultWork.OfsThisStockTax == 0 && ResultWork.StockSlipCount == 0)
                                // --- DEL 2012/11/07 ----------<<<<<
                                // --- ADD 2012/11/07 ---------->>>>>
                                // 0実績チェック
                                if (ResultWork.LastTimeAccPay == 0 && ResultWork.ThisTimeFeePayNrml ==0 &&
                                    ResultWork.ThisTimeDisPayNrml == 0 && ResultWork.OfsThisTimeStock == 0 &&
                                    ResultWork.OfsThisStockTax == 0 && ResultWork.StockSlipCount == 0 &&
                                    ResultWork.ThisTimePayNrml == 0)
                                // --- ADD 2012/11/07 ----------<<<<<
                                {
                                    continue;
                                }
                                // --- ADD 2012/11/20 ---------->>>>>
                                if (AddUpDate != _accPaymentListCndtnWork.AddUpYearMonth)
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
                                // --- ADD 2012/11/20 ----------<<<<<

                                // --- ADD START 3H 劉星光 2020/03/02 ---------->>>>>
                                // 消費税別内訳印字する
                                if (_accPaymentListCndtnWork.TaxPrintDiv == (int)TaxTotalDiv.TaxTotalON)
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
                                // --- ADD END 3H 劉星光 2020/03/02 ----------<<<<<

                                if (_accPaymentListCndtnWork.PayDtlDiv == (int)PayDtlDiv.PayDtlON)
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
                                    ResultWork.CashPayment = ((AccPaymentListResultWork)PaymentList[0]).CashPayment;
                                    //振込
                                    ResultWork.TrfrPayment = ((AccPaymentListResultWork)PaymentList[0]).TrfrPayment;
                                    //小切手
                                    ResultWork.CheckPayment = ((AccPaymentListResultWork)PaymentList[0]).CheckPayment;
                                    //手形
                                    ResultWork.DraftPayment = ((AccPaymentListResultWork)PaymentList[0]).DraftPayment;
                                    //相殺
                                    ResultWork.OffsetPayment = ((AccPaymentListResultWork)PaymentList[0]).OffsetPayment;
                                    //口座振替
                                    ResultWork.FundTransferPayment = ((AccPaymentListResultWork)PaymentList[0]).FundTransferPayment;
                                    //その他
                                    ResultWork.OthsPayment = ((AccPaymentListResultWork)PaymentList[0]).OthsPayment;

                                    // --- ADD 2012/11/13 ---------->>>>>
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
                                    // --- ADD 2012/11/13 ----------<<<<<
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
                        SupplierListWork = SupplierList[i] as AccPaymentListResultWork;
                        //締め済 -> 得意先売掛金額マスタから取得
                        //検索実行
                        status = SearchAccPaymentProc(ref al, _accPaymentListCndtnWork, SupplierListWork,  ref sqlConnection, logicalMode);
                    }
                }

                // --- ADD START 3H 劉星光 2020/03/02 ---------->>>>>
                // 消費税別内訳印字する
                if (_accPaymentListCndtnWork.TaxPrintDiv == (int)TaxTotalDiv.TaxTotalON)
                {
                    Dictionary<string, SuplAccPayDateInfo> suplAccPayDateDic = new Dictionary<string, SuplAccPayDateInfo>();
                    // 月次更新を行った場合
                    if (isCheckOut)
                    {
                        // 月次更新処理日取得を行う
                        status = SearchSuplAccPayDate(_accPaymentListCndtnWork, ref suplAccPayDateDic, ref sqlConnection);

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
                        AccPaymentListResultWork accPaymentWork = (AccPaymentListResultWork)al[k];

                        // 前回月次更新年月日
                        DateTime laMonCAddUpUpdDate = DateTime.MinValue;

                        if (!isCheckOut)
                        {
                            // 前回月次更新年月日取得
                            payeeDateDic.TryGetValue(accPaymentWork.AddUpSecCode.Trim() + "_" + accPaymentWork.PayeeCode.ToString("000000"), out laMonCAddUpUpdDate);
                        }

                        //仕入データ取得
                        status = SearchStockProc(ref accPaymentWork, ref sqlConnection, _accPaymentListCndtnWork, isCheckOut, laMonCAddUpUpdDate, suplAccPayDateDic);

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
                // --- ADD END 3H 劉星光 2020/03/02 ----------<<<<<
// 修正 2009.01.27 <<<
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "AccPaymentListWorkDB.SearchProc Exception=" + ex.Message);
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

            // --- UPD START 3H 劉星光 2020/02/28 ---------->>>>>
            //if (al.Count > 0)
            //{
            //    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            //}
            if (_accPaymentListCndtnWork.TaxPrintDiv == (int)TaxTotalDiv.TaxTotalOFF)
            {
                if (al.Count > 0)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            // --- UPD END 3H 劉星光 2020/02/28 ----------<<<<<

            accPaymentListResultWork = al;

            return status;
        }
        #endregion  //[SearchProc]

        #region [SearchSuppProc]
        /// <summary>
        /// 仕入先マスタから条件に該当する仕入先リストを抽出します。
        /// </summary>
        /// <param name="al">検索結果</param>
        /// <param name="_accPaymentListCndtnWork">検索パラメータ</param>
        /// <param name="sqlConnection">コネクション情報</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の得意先リストを戻します</br>
        /// <br>Programmer : 23015 森本 大輝</br>
        /// <br>Date       : 2008.09.22</br>
        private int SearchSuppProc(ref ArrayList al, AccPaymentListCndtnWork _accPaymentListCndtnWork, ref SqlConnection sqlConnection, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                string selectTxt = "";
                sqlCommand = new SqlCommand(selectTxt, sqlConnection);

                // 対象テーブル
                // SUPPLIERRF        SUPLER 仕入先マスタ
                // SECINFOSETRF      SCINST 拠点情報設定マスタ

                #region [Select文作成]
                selectTxt += "SELECT" + Environment.NewLine;
                selectTxt += "  SUPLER.PAYEECODERF" + Environment.NewLine;
                // 修正 2009.01.27 >>>
                //selectTxt += " ,SUPLER.MNGSECTIONCODERF" + Environment.NewLine;
                selectTxt += " ,SUPLER.PAYMENTSECTIONCODERF" + Environment.NewLine;
                // 修正 2009.01.27 <<<
                selectTxt += " ,SUPLER.SUPPLIERSNMRF" + Environment.NewLine;
                selectTxt += " ,SCINST.SECTIONGUIDESNMRF" + Environment.NewLine;
                //FROM
                selectTxt += " FROM SUPPLIERRF AS SUPLER" + Environment.NewLine;

                //JOIN
                //拠点情報設定マスタ
                selectTxt += " LEFT JOIN SECINFOSETRF SCINST" + Environment.NewLine;
                selectTxt += " ON  SCINST.ENTERPRISECODERF=SUPLER.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND SCINST.SECTIONCODERF=SUPLER.PAYMENTSECTIONCODERF" + Environment.NewLine;

                #region [WHERE句]
                selectTxt += " WHERE" + Environment.NewLine;

                //企業コード
                selectTxt += " SUPLER.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(_accPaymentListCndtnWork.EnterpriseCode);

                //論理削除区分
                if ((logicalMode == ConstantManagement.LogicalMode.GetData0) || (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData2) || (logicalMode == ConstantManagement.LogicalMode.GetData3))
                {
                    selectTxt += " AND SUPLER.LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + Environment.NewLine;
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
                }
                else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) || (logicalMode == ConstantManagement.LogicalMode.GetData012))
                {
                    selectTxt += " AND SUPLER.LOGICALDELETECODERF<@FINDLOGICALDELETECODE" + Environment.NewLine;
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                    if (logicalMode == ConstantManagement.LogicalMode.GetData01) paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
                    else paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
                }

                //拠点コード
                if (_accPaymentListCndtnWork.SectionCodes != null)
                {
                    string sectionCodestr = "";
                    foreach (string seccdstr in _accPaymentListCndtnWork.SectionCodes)
                    {
                        if (sectionCodestr != "")
                        {
                            sectionCodestr += ",";
                        }
                        sectionCodestr += "'" + seccdstr + "'";
                    }
                    if (sectionCodestr != "")
                    {
                        // 修正 2009.01.27 >>>
                        //selectTxt += " AND SUPLER.MNGSECTIONCODERF IN (" + sectionCodestr + ") ";                        
                        selectTxt += " AND SUPLER.PAYMENTSECTIONCODERF IN (" + sectionCodestr + ") ";
                        // 修正 2009.01.27 <<<
                    }
                    selectTxt += Environment.NewLine;
                }

                //支払先コード
                if (_accPaymentListCndtnWork.St_PayeeCode != 0)
                {
                    selectTxt += " AND SUPLER.SUPPLIERCDRF>=@ST_SUPPLIERCD" + Environment.NewLine;
                    SqlParameter paraSt_SupplierCd = sqlCommand.Parameters.Add("@ST_SUPPLIERCD", SqlDbType.Int);
                    paraSt_SupplierCd.Value = SqlDataMediator.SqlSetInt32(_accPaymentListCndtnWork.St_PayeeCode);
                }
                if (_accPaymentListCndtnWork.St_PayeeCode != 999999)
                {
                    selectTxt += " AND SUPLER.SUPPLIERCDRF<=@ED_SUPPLIERCD" + Environment.NewLine;
                    SqlParameter paraEd_PayeeCode = sqlCommand.Parameters.Add("@ED_SUPPLIERCD", SqlDbType.Int);
                    paraEd_PayeeCode.Value = SqlDataMediator.SqlSetInt32(_accPaymentListCndtnWork.Ed_PayeeCode);
                }
                // ADD 2008.11.13 >>>
                selectTxt += " AND SUPLER.SUPPLIERCDRF IS NOT null" + Environment.NewLine;
                selectTxt += " AND SUPLER.SUPPLIERCDRF != 0" + Environment.NewLine;
                selectTxt += " AND SUPLER.SUPPLIERCDRF = SUPLER.PAYEECODERF" + Environment.NewLine;
                // ADD 2008.11.13 <<<
                #endregion  //[WHERE句]

                #endregion  //[Select文作成]

                sqlCommand.CommandText = selectTxt;

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    AccPaymentListResultWork ResultWork = new AccPaymentListResultWork();

                    #region [抽出結果-値セット]
                    ResultWork.AddUpSecCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYMENTSECTIONCODERF"));
                    ResultWork.SectionGuideSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDESNMRF"));
                    ResultWork.PayeeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYEECODERF"));
                    ResultWork.PayeeSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSNMRF"));
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
                base.WriteErrorLog(ex, "AccPaymentListWorkDB.SearchSuppProc Exception=" + ex.Message);
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

        // --- ADD 2012/10/01 ---------->>>>>
        #region [SearchSuppGeneralProc]
        /// <summary>
        /// 仕入データから条件に該当する仕入先リストを抽出します。
        /// </summary>
        /// <param name="al">検索結果</param>
        /// <param name="_accPaymentListCndtnWork">検索パラメータ</param>
        /// <param name="sqlConnection">コネクション情報</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の得意先リストを戻します</br>
        /// <br>Programmer : FSI菅原(庸)</br>
        /// <br>Date       : 2012/10/01</br>
        private int SearchSuppGeneralProc(ref ArrayList al, AccPaymentListCndtnWork _accPaymentListCndtnWork, ref SqlConnection sqlConnection, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                string selectTxt = "";
                sqlCommand = new SqlCommand(selectTxt, sqlConnection);

                // 対象テーブル
                // SUPPLIERRF        SUPPLIER  仕入先マスタ
                // SECINFOSETRF      SCINST    拠点情報設定マスタ

                #region [Select文作成]
                selectTxt += "SELECT" + Environment.NewLine;
                selectTxt += "  SUPLER.PAYEECODERF" + Environment.NewLine;
                selectTxt += " ,SCINST.SECTIONCODERF AS PAYMENTSECTIONCODERF" + Environment.NewLine;
                selectTxt += " ,SUPLER.SUPPLIERSNMRF" + Environment.NewLine;
                selectTxt += " ,SCINST.SECTIONGUIDESNMRF" + Environment.NewLine;
                //FROM
                selectTxt += " FROM SUPPLIERRF AS SUPLER" + Environment.NewLine;

                //JOIN
                //拠点情報設定マスタ
                selectTxt += " LEFT JOIN SECINFOSETRF SCINST" + Environment.NewLine;
                selectTxt += " ON  SCINST.ENTERPRISECODERF = SUPLER.ENTERPRISECODERF" + Environment.NewLine;
                #region [WHERE句]
                selectTxt += " WHERE" + Environment.NewLine;

                //企業コード
                selectTxt += " SUPLER.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(_accPaymentListCndtnWork.EnterpriseCode);

                //論理削除区分
                if ((logicalMode == ConstantManagement.LogicalMode.GetData0) || (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData2) || (logicalMode == ConstantManagement.LogicalMode.GetData3))
                {
                    selectTxt += " AND SUPLER.LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + Environment.NewLine;
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
                }
                else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) || (logicalMode == ConstantManagement.LogicalMode.GetData012))
                {
                    selectTxt += " AND SUPLER.LOGICALDELETECODERF<@FINDLOGICALDELETECODE" + Environment.NewLine;
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                    if (logicalMode == ConstantManagement.LogicalMode.GetData01) paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
                    else paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
                }

                //拠点コード
                if (_accPaymentListCndtnWork.SectionCodes != null)
                {
                    string sectionCodestr = "";
                    foreach (string seccdstr in _accPaymentListCndtnWork.SectionCodes)
                    {
                        if (sectionCodestr != "")
                        {
                            sectionCodestr += ",";
                        }
                        sectionCodestr += "'" + seccdstr + "'";
                    }
                    if (sectionCodestr != "")
                    {
                        selectTxt += " AND SCINST.SECTIONCODERF IN (" + sectionCodestr + ") ";
                    }
                    selectTxt += Environment.NewLine;
                }

                //支払先コード
                if (_accPaymentListCndtnWork.St_PayeeCode != 0)
                {
                    selectTxt += " AND SUPLER.SUPPLIERCDRF>=@ST_SUPPLIERCD" + Environment.NewLine;
                    SqlParameter paraSt_SupplierCd = sqlCommand.Parameters.Add("@ST_SUPPLIERCD", SqlDbType.Int);
                    paraSt_SupplierCd.Value = SqlDataMediator.SqlSetInt32(_accPaymentListCndtnWork.St_PayeeCode);
                }
                if (_accPaymentListCndtnWork.St_PayeeCode != 999999)
                {
                    selectTxt += " AND SUPLER.SUPPLIERCDRF<=@ED_SUPPLIERCD" + Environment.NewLine;
                    SqlParameter paraEd_PayeeCode = sqlCommand.Parameters.Add("@ED_SUPPLIERCD", SqlDbType.Int);
                    paraEd_PayeeCode.Value = SqlDataMediator.SqlSetInt32(_accPaymentListCndtnWork.Ed_PayeeCode);
                }
                selectTxt += " AND SUPLER.SUPPLIERCDRF IS NOT null" + Environment.NewLine;
                selectTxt += " AND SUPLER.SUPPLIERCDRF != 0" + Environment.NewLine;
                selectTxt += " AND SUPLER.SUPPLIERCDRF = SUPLER.PAYEECODERF" + Environment.NewLine;

                selectTxt += "ORDER BY" + Environment.NewLine;
                selectTxt += "PAYMENTSECTIONCODERF" + Environment.NewLine;

                #endregion  //[WHERE句]

                #endregion  //[Select文作成]

                sqlCommand.CommandText = selectTxt;

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    AccPaymentListResultWork ResultWork = new AccPaymentListResultWork();

                    #region [抽出結果-値セット]
                    ResultWork.AddUpSecCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYMENTSECTIONCODERF"));
                    ResultWork.SectionGuideSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDESNMRF"));
                    ResultWork.PayeeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYEECODERF"));
                    ResultWork.PayeeSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSNMRF"));
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
                base.WriteErrorLog(ex, "AccPaymentListWorkDB.SearchSuppGeneralProc Exception=" + ex.Message);
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
        #endregion  //[SearchSuppGeneralProc]
        // --- ADD 2012/10/01 ----------<<<<<

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
        /// <br>Programmer : 23015 森本 大輝</br>
        /// <br>Date       : 2008.09.22</br>
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
                selectTxt += " AND PAYDTL.LOGICALDELETECODERF=0" + Environment.NewLine;  // 2009/04/30
                //WHERE
                selectTxt += " WHERE" + Environment.NewLine;
                selectTxt += "      PAYSLP.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                selectTxt += "  AND PAYSLP.DEBITNOTEDIVRF=0" + Environment.NewLine;
                selectTxt += "  AND PAYSLP.SUPPLIERCDRF=@FINDSUPPLIERCD" + Environment.NewLine;
                selectTxt += "  AND PAYSLP.PAYEECODERF=@FINDPAYEECODE" + Environment.NewLine;
                selectTxt += "  AND PAYSLP.ADDUPSECCODERF=@FINDADDUPSECCODE" + Environment.NewLine;
                selectTxt += "  AND PAYSLP.LOGICALDELETECODERF=0" + Environment.NewLine;  // 2009/04/30
                selectTxt += "  AND (PAYSLP.ADDUPADATERF<=@FINDADDUPDATE AND PAYSLP.ADDUPADATERF>@FINDLASTTIMEADDUPDATE)" + Environment.NewLine;
                //GROU BY
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
                    AccPaymentListResultWork ResultWork = new AccPaymentListResultWork();

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
        /// 指定された条件の買掛残高一覧表を戻します
        /// </summary>
        /// <param name="al">検索結果</param>
        /// <param name="_accPaymentListCndtnWork">検索パラメータ</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の売掛残高一覧表を戻します</br>
        /// <br>Programmer : 23015 森本 大輝</br>
        /// <br>Date       : 2008.09.22</br>
        private int SearchAccPaymentProc(ref ArrayList al, AccPaymentListCndtnWork _accPaymentListCndtnWork, AccPaymentListResultWork SupplierListWork, ref SqlConnection sqlConnection, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                string selectTxt = "";
                sqlCommand = new SqlCommand(selectTxt, sqlConnection);

                // SUPLACCPAYRF      SUPPAY 仕入先買掛金額マスタ
                // ACALCPAYTOTALRF   ACAPAY 買掛支払集計データ
                // SECINFOSETRF      SCINST 拠点情報設定マスタ

                #region [Select文作成]
                selectTxt += "SELECT" + Environment.NewLine;
                selectTxt += "   SUPPAY.ADDUPSECCODERF" + Environment.NewLine;
                selectTxt += "  ,SCINST.SECTIONGUIDESNMRF" + Environment.NewLine;
                selectTxt += "  ,SUPPAY.PAYEECODERF" + Environment.NewLine;
                selectTxt += "  ,SUPPAY.PAYEESNMRF" + Environment.NewLine;
                selectTxt += "  ,SUPPAY.LASTTIMEACCPAYRF" + Environment.NewLine;
                selectTxt += "  ,SUPPAY.THISTIMEPAYNRMLRF" + Environment.NewLine;
                selectTxt += "  ,SUPPAY.THISTIMETTLBLCACPAYRF" + Environment.NewLine;
                selectTxt += "  ,SUPPAY.OFSTHISTIMESTOCKRF" + Environment.NewLine;
                selectTxt += "  ,(SUPPAY.THISSTCKPRICRGDSRF+SUPPAY.THISSTCKPRICDISRF)" + Environment.NewLine;
                selectTxt += "   AS THISRGDSDISPRIC" + Environment.NewLine;
                selectTxt += "  ,SUPPAY.OFSTHISSTOCKTAXRF" + Environment.NewLine;
                selectTxt += "  ,SUPPAY.STCKTTLACCPAYBALANCERF" + Environment.NewLine;
                selectTxt += "  ,SUPPAY.STOCKSLIPCOUNTRF" + Environment.NewLine;
                selectTxt += "  ,SUPPAY.THISTIMEFEEPAYNRMLRF" + Environment.NewLine;
                selectTxt += "  ,SUPPAY.THISTIMEDISPAYNRMLRF" + Environment.NewLine;
                selectTxt += "  ,SUPPAY.CASHPAYMENT" + Environment.NewLine;
                selectTxt += "  ,SUPPAY.TRFRPAYMENT" + Environment.NewLine;
                selectTxt += "  ,SUPPAY.CHECKPAYMENT" + Environment.NewLine;
                selectTxt += "  ,SUPPAY.DRAFTPAYMENT" + Environment.NewLine;
                selectTxt += "  ,SUPPAY.OFFSETPAYMENT" + Environment.NewLine;
                selectTxt += "  ,SUPPAY.FUNDTRANSFERPAYMENT" + Environment.NewLine;
                selectTxt += "  ,SUPPAY.OTHSPAYMENT" + Environment.NewLine;
                selectTxt += "  ,SUPPAY.THISTIMESTOCKPRICERF" + Environment.NewLine; // ADD 2009.02.09
                //FROM
                selectTxt += " FROM" + Environment.NewLine;
                selectTxt += " (" + Environment.NewLine;

                #region [データ抽出メインQuery]
                //仕入先買掛金額マスタ
                selectTxt += "  SELECT" + Environment.NewLine;
                selectTxt += "    SUPPAYSUB.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "   ,SUPPAYSUB.ADDUPSECCODERF" + Environment.NewLine;
                selectTxt += "   ,SUPPAYSUB.PAYEECODERF" + Environment.NewLine;
                selectTxt += "   ,SUPPAYSUB.PAYEESNMRF" + Environment.NewLine;
                selectTxt += "   ,SUPPAYSUB.LASTTIMEACCPAYRF" + Environment.NewLine;
                selectTxt += "   ,SUPPAYSUB.THISTIMEPAYNRMLRF" + Environment.NewLine;
                selectTxt += "   ,SUPPAYSUB.THISTIMETTLBLCACPAYRF" + Environment.NewLine;
                selectTxt += "   ,SUPPAYSUB.OFSTHISTIMESTOCKRF" + Environment.NewLine;
                selectTxt += "   ,SUPPAYSUB.THISSTCKPRICRGDSRF" + Environment.NewLine;
                selectTxt += "   ,SUPPAYSUB.THISSTCKPRICDISRF" + Environment.NewLine;
                selectTxt += "   ,SUPPAYSUB.OFSTHISSTOCKTAXRF" + Environment.NewLine;
                selectTxt += "   ,SUPPAYSUB.STCKTTLACCPAYBALANCERF" + Environment.NewLine;
                selectTxt += "   ,SUPPAYSUB.STOCKSLIPCOUNTRF" + Environment.NewLine;
                selectTxt += "   ,SUPPAYSUB.THISTIMEFEEPAYNRMLRF" + Environment.NewLine;
                selectTxt += "   ,SUPPAYSUB.THISTIMEDISPAYNRMLRF" + Environment.NewLine;
                selectTxt += "   ,SUPPAYSUB.THISTIMESTOCKPRICERF" + Environment.NewLine; // ADD 2009.02.09
                selectTxt += "   ,ACAPAY.CASHPAYMENT" + Environment.NewLine;
                selectTxt += "   ,ACAPAY.TRFRPAYMENT" + Environment.NewLine;
                selectTxt += "   ,ACAPAY.CHECKPAYMENT" + Environment.NewLine;
                selectTxt += "   ,ACAPAY.DRAFTPAYMENT" + Environment.NewLine;
                selectTxt += "   ,ACAPAY.OFFSETPAYMENT" + Environment.NewLine;
                selectTxt += "   ,ACAPAY.FUNDTRANSFERPAYMENT" + Environment.NewLine;
                selectTxt += "   ,(ACAPAY.OTHSPAYMENT" + Environment.NewLine;
                selectTxt += "    -ACAPAY.CASHPAYMENT" + Environment.NewLine;
                selectTxt += "    -ACAPAY.TRFRPAYMENT" + Environment.NewLine;
                selectTxt += "    -ACAPAY.CHECKPAYMENT" + Environment.NewLine;
                selectTxt += "    -ACAPAY.DRAFTPAYMENT" + Environment.NewLine;
                selectTxt += "    -ACAPAY.OFFSETPAYMENT" + Environment.NewLine;
                selectTxt += "    -ACAPAY.FUNDTRANSFERPAYMENT" + Environment.NewLine;
                selectTxt += "    ) AS OTHSPAYMENT" + Environment.NewLine;
                selectTxt += " FROM SUPLACCPAYRF AS SUPPAYSUB" + Environment.NewLine;

                //買掛支払集計データ
                selectTxt += "  LEFT JOIN" + Environment.NewLine;
                selectTxt += "  (" + Environment.NewLine;
                selectTxt += "   SELECT" + Environment.NewLine;
                selectTxt += "     ACAPAYSUB.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "    ,ACAPAYSUB.ADDUPSECCODERF" + Environment.NewLine;
                selectTxt += "    ,ACAPAYSUB.PAYEECODERF" + Environment.NewLine;
                selectTxt += "    ,ACAPAYSUB.SUPPLIERCDRF" + Environment.NewLine;
                selectTxt += "    ,ACAPAYSUB.ADDUPDATERF" + Environment.NewLine;
                selectTxt += "    ,SUM((CASE WHEN ACAPAYSUB.MONEYKINDCODERF=51 THEN ACAPAYSUB.PAYMENTRF ELSE 0 END)) AS CASHPAYMENT" + Environment.NewLine;
                selectTxt += "    ,SUM((CASE WHEN ACAPAYSUB.MONEYKINDCODERF=52 THEN ACAPAYSUB.PAYMENTRF ELSE 0 END)) AS TRFRPAYMENT" + Environment.NewLine;
                selectTxt += "    ,SUM((CASE WHEN ACAPAYSUB.MONEYKINDCODERF=53 THEN ACAPAYSUB.PAYMENTRF ELSE 0 END)) AS CHECKPAYMENT" + Environment.NewLine;
                selectTxt += "    ,SUM((CASE WHEN ACAPAYSUB.MONEYKINDCODERF=54 THEN ACAPAYSUB.PAYMENTRF ELSE 0 END)) AS DRAFTPAYMENT" + Environment.NewLine;
                selectTxt += "    ,SUM((CASE WHEN ACAPAYSUB.MONEYKINDCODERF=56 THEN ACAPAYSUB.PAYMENTRF ELSE 0 END)) AS OFFSETPAYMENT" + Environment.NewLine;
                selectTxt += "    ,SUM((CASE WHEN ACAPAYSUB.MONEYKINDCODERF=59 THEN ACAPAYSUB.PAYMENTRF ELSE 0 END)) AS FUNDTRANSFERPAYMENT" + Environment.NewLine;
                selectTxt += "    ,SUM(ACAPAYSUB.PAYMENTRF) AS OTHSPAYMENT" + Environment.NewLine;
                selectTxt += "   FROM ACALCPAYTOTALRF AS ACAPAYSUB" + Environment.NewLine;                              
                selectTxt += "   GROUP BY" + Environment.NewLine;
                selectTxt += "     ACAPAYSUB.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "    ,ACAPAYSUB.ADDUPSECCODERF" + Environment.NewLine;
                selectTxt += "    ,ACAPAYSUB.PAYEECODERF" + Environment.NewLine;
                selectTxt += "    ,ACAPAYSUB.SUPPLIERCDRF" + Environment.NewLine;
                selectTxt += "    ,ACAPAYSUB.ADDUPDATERF" + Environment.NewLine;
                selectTxt += "  ) AS ACAPAY" + Environment.NewLine;
                selectTxt += "  ON  ACAPAY.ENTERPRISECODERF=SUPPAYSUB.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "  AND ACAPAY.ADDUPSECCODERF=SUPPAYSUB.ADDUPSECCODERF" + Environment.NewLine;
                selectTxt += "  AND ACAPAY.PAYEECODERF=SUPPAYSUB.PAYEECODERF" + Environment.NewLine;
                //selectTxt += "  AND ACAPAY.SUPPLIERCDRF=SUPPAYSUB.SUPPLIERCDRF" + Environment.NewLine; // DEL 2009/06/02
                selectTxt += "  AND ACAPAY.ADDUPDATERF=SUPPAYSUB.ADDUPDATERF" + Environment.NewLine;

                //WHERE文の作成
                selectTxt += MakeWhereString(ref sqlCommand, _accPaymentListCndtnWork, SupplierListWork, logicalMode);
                #endregion  //[データ抽出メインQuery]

                selectTxt += " ) AS SUPPAY" + Environment.NewLine;

                #region [JOIN]
                //拠点情報設定マスタ
                selectTxt += " LEFT JOIN SECINFOSETRF SCINST" + Environment.NewLine;
                selectTxt += " ON  SCINST.ENTERPRISECODERF=SUPPAY.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND SCINST.SECTIONCODERF=SUPPAY.ADDUPSECCODERF" + Environment.NewLine;
                #endregion  //[JOIN]

                #endregion  //[Select文作成]

                sqlCommand.CommandText = selectTxt;

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    al.Add(CopyToRsltWork(ref myReader, _accPaymentListCndtnWork));
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
                base.WriteErrorLog(ex, "AccPaymentListWorkDB.SearchAccPaymentProc Exception=" + ex.Message);
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
        /// <param name="_accPaymentListCndtnWork">検索条件格納クラス</param>
        /// <param name="SupplierListWork">検索条件格納クラス</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>買掛残高元帳抽出のSQL文字列</returns>
        /// <br>Note       : WHERE句生成処理</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2007.11.09</br>
        /// <br></br>
        /// <br>Note       : 手数料と値引き以外の支払伝票の場合、印字されない対応</br>
        /// <br>Programmer : 30755 FSI菅原(庸)</br>
        /// <br>Date       : 2012/11/07</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, AccPaymentListCndtnWork _accPaymentListCndtnWork, AccPaymentListResultWork SupplierListWork,  ConstantManagement.LogicalMode logicalMode)
        {
            #region WHERE文作成
            string retstring = "";
            retstring += " WHERE" + Environment.NewLine;

            //企業コード
            retstring += " SUPPAYSUB.ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(_accPaymentListCndtnWork.EnterpriseCode);

            //論理削除区分
            if ((logicalMode == ConstantManagement.LogicalMode.GetData0) || (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData2) || (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                retstring += " AND SUPPAYSUB.LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + Environment.NewLine;
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
            }
            else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) || (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                retstring += " AND SUPPAYSUB.LOGICALDELETECODERF<@FINDLOGICALDELETECODE" + Environment.NewLine;
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                if (logicalMode == ConstantManagement.LogicalMode.GetData01) paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
                else paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
            }

            //親レコードのみを対象とする(仕入先コード=0のみ対象)
            retstring += " AND SUPPAYSUB.SUPPLIERCDRF=0" + Environment.NewLine;

            //拠点コード
            // 修正 2009.01.27 >>>
            //if (_accPaymentListCndtnWork.SectionCodes != null)
            //{
            //    string sectionCodestr = "";
            //    foreach (string seccdstr in _accPaymentListCndtnWork.SectionCodes)
            //    {
            //        if (sectionCodestr != "")
            //        {
            //            sectionCodestr += ",";
            //        }
            //        sectionCodestr += "'" + seccdstr + "'";
            //    }
            //    if (sectionCodestr != "")
            //    {
            //        retstring += " AND SUPPAYSUB.ADDUPSECCODERF IN (" + sectionCodestr + ") ";
            //    }
            //    retstring += Environment.NewLine;
            //}
            if (SupplierListWork.AddUpSecCode != null)
            {
                retstring += " AND SUPPAYSUB.ADDUPSECCODERF = @ADDUPSECCODE";
                SqlParameter paraAddupsecCode = sqlCommand.Parameters.Add("@ADDUPSECCODE", SqlDbType.NChar);
                paraAddupsecCode.Value = SqlDataMediator.SqlSetString(SupplierListWork.AddUpSecCode);
            }
            // 修正 2009.01.27 <<<

            //対象年月
            if (_accPaymentListCndtnWork.AddUpYearMonth != DateTime.MinValue)
            {
                retstring += " AND SUPPAYSUB.ADDUPYEARMONTHRF=@ADDUPYEARMONTH" + Environment.NewLine;
                SqlParameter paraSt_AddUpYearMonth = sqlCommand.Parameters.Add("@ADDUPYEARMONTH", SqlDbType.Int);
                paraSt_AddUpYearMonth.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(_accPaymentListCndtnWork.AddUpYearMonth);
            }

            //支払先コード
            // 修正 2009.01.27 >>>
            //if (_accPaymentListCndtnWork.St_PayeeCode != 0)
            //{
            //    retstring += " AND SUPPAYSUB.PAYEECODERF>=@ST_PAYEECODE" + Environment.NewLine;
            //    SqlParameter paraSt_PayeeCode = sqlCommand.Parameters.Add("@ST_PAYEECODE", SqlDbType.Int);
            //    paraSt_PayeeCode.Value = SqlDataMediator.SqlSetInt32(_accPaymentListCndtnWork.St_PayeeCode);
            //}
            //if (_accPaymentListCndtnWork.St_PayeeCode != 999999999)
            //{
            //    retstring += " AND SUPPAYSUB.PAYEECODERF<=@ED_PAYEECODE" + Environment.NewLine;
            //    SqlParameter paraEd_PayeeCode = sqlCommand.Parameters.Add("@ED_PAYEECODE", SqlDbType.Int);
            //    paraEd_PayeeCode.Value = SqlDataMediator.SqlSetInt32(_accPaymentListCndtnWork.Ed_PayeeCode);
            //}
            if (SupplierListWork.PayeeCode != 0)
            {
                retstring += " AND SUPPAYSUB.PAYEECODERF=@PAYEECODE" + Environment.NewLine;
                SqlParameter paraPayeeCode = sqlCommand.Parameters.Add("@PAYEECODE", SqlDbType.Int);
                paraPayeeCode.Value = SqlDataMediator.SqlSetInt32(SupplierListWork.PayeeCode);

            }
            // 修正 2009.01.27 <<<

            //0:全て 1:0とﾌﾟﾗｽ 2:ﾌﾟﾗｽのみ 3:0のみ 4:ﾌﾟﾗｽとﾏｲﾅｽ 5:0とﾏｲﾅｽ 6:ﾏｲﾅｽのみ
            switch (_accPaymentListCndtnWork.OutMoneyDiv)
            {
                case 0:
                    break;
                case 1:
                    retstring += " AND SUPPAYSUB.STCKTTLACCPAYBALANCERF>=0" + Environment.NewLine;
                    break;
                case 2:
                    retstring += " AND SUPPAYSUB.STCKTTLACCPAYBALANCERF>0" + Environment.NewLine;
                    break;
                case 3:
                    retstring += " AND SUPPAYSUB.STCKTTLACCPAYBALANCERF=0" + Environment.NewLine;
                    break;
                case 4:
                    retstring += " AND SUPPAYSUB.STCKTTLACCPAYBALANCERF!=0" + Environment.NewLine;
                    break;
                case 5:
                    retstring += " AND SUPPAYSUB.STCKTTLACCPAYBALANCERF<=0" + Environment.NewLine;
                    break;
                case 6:
                    retstring += " AND SUPPAYSUB.STCKTTLACCPAYBALANCERF<0" + Environment.NewLine;
                    break;
            }
            // ADD 2009.02.13 >>>
            retstring += "AND ( SUPPAYSUB.LASTTIMEACCPAYRF != 0" + Environment.NewLine;
            retstring += "      OR SUPPAYSUB.THISTIMEFEEPAYNRMLRF != 0" + Environment.NewLine;
            retstring += "      OR SUPPAYSUB.THISTIMEDISPAYNRMLRF != 0" + Environment.NewLine;
            retstring += "      OR SUPPAYSUB.OFSTHISTIMESTOCKRF != 0" + Environment.NewLine;
            retstring += "      OR SUPPAYSUB.OFSTHISSTOCKTAXRF != 0" + Environment.NewLine;
            // --- DEL 2012/11/07 ---------->>>>>
            //retstring += "      OR SUPPAYSUB.STOCKSLIPCOUNTRF != 0)" + Environment.NewLine;
            // --- DEL 2012/11/07 ----------<<<<<
            // --- ADD 2012/11/07 ---------->>>>>
            retstring += "      OR SUPPAYSUB.STOCKSLIPCOUNTRF != 0" + Environment.NewLine;
            retstring += "      OR SUPPAYSUB.THISTIMEPAYNRMLRF != 0)" + Environment.NewLine;
            // --- ADD 2012/11/07 ----------<<<<<
            // ADD 2009.02.13 <<<
            #endregion  //WHERE文作成

            return retstring.ToString();
        }
        #endregion  //[WHERE句生成処理]

        #region [買掛残高一覧表抽出結果クラス格納処理]
        /// <summary>
        /// 買掛残高一覧表抽出結果クラス格納処理 Reader → AccPaymentListResultWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="_accPaymentListCndtnWork">AccPaymentListResultWork</param>
        /// <returns>AccPaymentListResultWork</returns>
        /// <remarks>
        /// <br>Programmer : 23015 森本 大輝</br>
        /// <br>Date       : 2008.09.22</br>
        /// </remarks>
        private AccPaymentListResultWork CopyToRsltWork(ref SqlDataReader myReader, AccPaymentListCndtnWork _accPaymentListCndtnWork)
        {
            AccPaymentListResultWork ResultWork = new AccPaymentListResultWork();

            #region [抽出結果-値セット]
            ResultWork.AddUpSecCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDUPSECCODERF"));
            ResultWork.SectionGuideSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDESNMRF"));
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
            if (_accPaymentListCndtnWork.PayDtlDiv == (int)PayDtlDiv.PayDtlON)
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
        #endregion  //[買掛残高一覧表抽出結果クラス格納処理]

        // --- ADD 2012/11/14 ---------->>>>>
        #region [SearchMonAddUpProc]
        /// <summary>
        /// 月次締更新履歴マスタから条件に該当する月次締更新履歴リストを抽出します。
        /// </summary>
        /// <param name="al">検索結果</param>
        /// <param name="_accPaymentListCndtnWork">検索パラメータ</param>
        /// <param name="sqlConnection">コネクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の月次締更新履歴リストを戻します</br>
        /// <br>Programmer : FSI 菅原 庸平</br>
        /// <br>Date       : 2012/11/14</br>
        private int SearchMonAddUpProc(ref ArrayList al, AccPaymentListCndtnWork _accPaymentListCndtnWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                string selectTxt = "";
                sqlCommand = new SqlCommand(selectTxt, sqlConnection);

                // 対象テーブル
                // MONTHLYADDUPHISRF RES 月次締更新履歴マスタ

                #region [Select文作成]
                selectTxt += "SELECT DISTINCT" + Environment.NewLine;
                selectTxt += "  RES.ADDUPSECCODERF" + Environment.NewLine; // 計上拠点コード
                selectTxt += " ,RES.HISTCTLCDRF" + Environment.NewLine;    // 履歴制御区分(0:確定 1:未確定(履歴情報))
                //FROM
                selectTxt += "FROM(" + Environment.NewLine;
                selectTxt += " 	SELECT" + Environment.NewLine;
                selectTxt += " 	  ENTERPRISECODERF" + Environment.NewLine;      // 企業コード
                selectTxt += " 	 ,ACCRECACCPAYDIVRF" + Environment.NewLine;     // 売掛買掛区分(0:売掛 1:買掛)
                selectTxt += " 	 ,ADDUPSECCODERF" + Environment.NewLine;        // 計上拠点コード
                selectTxt += " 	 ,MONTHADDUPYEARMONTHRF" + Environment.NewLine; // 月次更新年月
                selectTxt += " 	 ,HISTCTLCDRF" + Environment.NewLine;           // 履歴制御区分(0:確定 1:未確定(履歴情報))
                selectTxt += " 	FROM MONTHLYADDUPHISRF" + Environment.NewLine;
                #region [WHERE句]
                selectTxt += " 	WHERE" + Environment.NewLine;
                // 企業コード
                selectTxt += " 	 ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(_accPaymentListCndtnWork.EnterpriseCode);

                // 売掛買掛区分
                selectTxt += "   AND ACCRECACCPAYDIVRF = 1" + Environment.NewLine;

                // 論理削除区分
                selectTxt += "   AND LOGICALDELETECODERF = 0" + Environment.NewLine;

                // 月次更新年月
                selectTxt += "   AND MONTHADDUPYEARMONTHRF = @ADDUPYEARMONTH" + Environment.NewLine;
                SqlParameter paraMonthAddUpYearMonth = sqlCommand.Parameters.Add("@ADDUPYEARMONTH", SqlDbType.Int);
                paraMonthAddUpYearMonth.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(_accPaymentListCndtnWork.AddUpYearMonth);

                // エラーステータス
                selectTxt += "   AND ERRORSTATUSRF = 0" + Environment.NewLine;
                #endregion  //[WHERE句]

                selectTxt += " 	GROUP BY" + Environment.NewLine;
                selectTxt += "    ENTERPRISECODERF" + Environment.NewLine;      // 企業コード
                selectTxt += "   ,ACCRECACCPAYDIVRF" + Environment.NewLine;     // 売掛買掛区分(0:売掛 1:買掛))
                selectTxt += "   ,ADDUPSECCODERF" + Environment.NewLine;        // 計上拠点コード
                selectTxt += "   ,HISTCTLCDRF" + Environment.NewLine;           // 履歴制御区分(0:確定 1:未確定(履歴情報))
                selectTxt += "   ,MONTHADDUPYEARMONTHRF" + Environment.NewLine; // 月次更新年月

                selectTxt += ") AS RES" + Environment.NewLine;
                selectTxt += "ORDER BY" + Environment.NewLine;
                selectTxt += " RES.ADDUPSECCODERF" + Environment.NewLine;
                #endregion  //[Select文作成]

                sqlCommand.CommandText = selectTxt;

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    MonAddUpCAddUpHisResultWork ResultWork = new MonAddUpCAddUpHisResultWork();

                    #region [抽出結果-値セット]
                    ResultWork.AddUpSecCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDUPSECCODERF"));
                    ResultWork.HistCtlCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("HISTCTLCDRF"));
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
                base.WriteErrorLog(ex, "MonAddUpCAddUpHisResultWork.SearchMonAddUpProc Exception=" + ex.Message);
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
        #endregion  //[SearchMonAddUpProc]

        #region [SearchMonAddDataUpTimeProc]
        /// <summary>
        /// 月次締更新履歴マスタから最後に更新した履歴制御区分が未確定のデータ更新日時を1件取得し月次締更新履歴リストを抽出します。
        /// </summary>
        /// <param name="al">検索結果</param>
        /// <param name="_accPaymentListCndtnWork">検索パラメータ</param>
        /// <param name="sqlConnection">コネクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 最後に更新した履歴制御区分が未確定のデータ更新日時を1件取得します</br>
        /// <br>Programmer : FSI 菅原 庸平</br>
        /// <br>Date       : 2012/11/14</br>
        private int SearchMonAddDataUpTimeProc(ref ArrayList al, AccPaymentListCndtnWork _accPaymentListCndtnWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                string selectTxt = "";
                sqlCommand = new SqlCommand(selectTxt, sqlConnection);

                // 対象テーブル
                // MONTHLYADDUPHISRF RES 月次締更新履歴マスタ

                #region [Select文作成]
                selectTxt += "SELECT TOP 1" + Environment.NewLine;
                selectTxt += "  RES.CREATEDATETIMERF" + Environment.NewLine;      // 作成日時
                selectTxt += " ,RES.UPDATEDATETIMERF" + Environment.NewLine;      // 更新日時
                selectTxt += " ,RES.ENTERPRISECODERF" + Environment.NewLine;      // 企業コード
                selectTxt += " ,RES.FILEHEADERGUIDRF" + Environment.NewLine;      // GUID
                selectTxt += " ,RES.UPDEMPLOYEECODERF" + Environment.NewLine;     // 更新従業員コード
                selectTxt += " ,RES.UPDASSEMBLYID1RF" + Environment.NewLine;      // 更新アセンブリID1
                selectTxt += " ,RES.UPDASSEMBLYID2RF" + Environment.NewLine;      // 更新アセンブリID2
                selectTxt += " ,RES.LOGICALDELETECODERF" + Environment.NewLine;   // 論理削除区分
                selectTxt += " ,RES.ACCRECACCPAYDIVRF" + Environment.NewLine;     // 売掛買掛区分
                selectTxt += " ,RES.ADDUPSECCODERF" + Environment.NewLine;        // 計上拠点コード
                selectTxt += " ,RES.STMONCADDUPUPDDATERF" + Environment.NewLine;  // 月次更新開始年月日
                selectTxt += " ,RES.MONTHLYADDUPDATERF" + Environment.NewLine;    // 月次更新年月日
                selectTxt += " ,RES.MONTHADDUPYEARMONTHRF" + Environment.NewLine; // 月次更新年月
                selectTxt += " ,RES.MONTHADDUPEXPDATERF" + Environment.NewLine;   // 月次更新実行年月日
                selectTxt += " ,RES.LAMONCADDUPUPDDATERF" + Environment.NewLine;  // 前回月次更新年月日
                selectTxt += " ,RES.DATAUPDATEDATETIMERF" + Environment.NewLine;  // データ更新日時
                selectTxt += " ,RES.PROCDIVCDRF" + Environment.NewLine;           // 処理区分
                selectTxt += " ,RES.ERRORSTATUSRF" + Environment.NewLine;         // エラーステータス
                selectTxt += " ,RES.HISTCTLCDRF" + Environment.NewLine;           // 履歴制御区分
                selectTxt += " ,RES.PROCRESULTRF" + Environment.NewLine;          // 処理結果
                selectTxt += " ,RES.CONVERTPROCESSDIVCDRF" + Environment.NewLine; // コンバート処理区分
                //FROM
                selectTxt += "FROM(" + Environment.NewLine;
                selectTxt += " 	SELECT" + Environment.NewLine;
                selectTxt += "    CREATEDATETIMERF" + Environment.NewLine;      // 作成日時
                selectTxt += " 	 ,UPDATEDATETIMERF" + Environment.NewLine;      // 更新日時
                selectTxt += "   ,ENTERPRISECODERF" + Environment.NewLine;      // 企業コード
                selectTxt += "   ,FILEHEADERGUIDRF" + Environment.NewLine;      // GUID
                selectTxt += "   ,UPDEMPLOYEECODERF" + Environment.NewLine;     // 更新従業員コード
                selectTxt += "   ,UPDASSEMBLYID1RF" + Environment.NewLine;      // 更新アセンブリID1
                selectTxt += "   ,UPDASSEMBLYID2RF" + Environment.NewLine;      // 更新アセンブリID2
                selectTxt += "   ,LOGICALDELETECODERF" + Environment.NewLine;   // 論理削除区分
                selectTxt += "   ,ACCRECACCPAYDIVRF" + Environment.NewLine;     // 売掛買掛区分
                selectTxt += "   ,ADDUPSECCODERF" + Environment.NewLine;        // 計上拠点コード
                selectTxt += "   ,STMONCADDUPUPDDATERF" + Environment.NewLine;  // 月次更新開始年月日
                selectTxt += "   ,MONTHLYADDUPDATERF" + Environment.NewLine;    // 月次更新年月日
                selectTxt += "   ,MONTHADDUPYEARMONTHRF" + Environment.NewLine; // 月次更新年月
                selectTxt += "   ,MONTHADDUPEXPDATERF" + Environment.NewLine;   // 月次更新実行年月日
                selectTxt += "   ,LAMONCADDUPUPDDATERF" + Environment.NewLine;  // 前回月次更新年月日
                selectTxt += "   ,DATAUPDATEDATETIMERF" + Environment.NewLine;  // データ更新日時
                selectTxt += "   ,PROCDIVCDRF" + Environment.NewLine;           // 処理区分
                selectTxt += "   ,ERRORSTATUSRF" + Environment.NewLine;         // エラーステータス
                selectTxt += "   ,HISTCTLCDRF" + Environment.NewLine;           // 履歴制御区分
                selectTxt += "   ,PROCRESULTRF" + Environment.NewLine;          // 処理結果
                selectTxt += "   ,CONVERTPROCESSDIVCDRF" + Environment.NewLine; // コンバート処理区分

                selectTxt += " 	FROM MONTHLYADDUPHISRF" + Environment.NewLine;
                #region [WHERE句]
                selectTxt += " 	WHERE" + Environment.NewLine;
                // 企業コード
                selectTxt += " 	 ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(_accPaymentListCndtnWork.EnterpriseCode);

                // 売掛買掛区分
                selectTxt += "   AND ACCRECACCPAYDIVRF = 1" + Environment.NewLine;

                // 論理削除区分
                selectTxt += "   AND LOGICALDELETECODERF = 0" + Environment.NewLine;

                // 月次更新年月
                selectTxt += "   AND MONTHADDUPYEARMONTHRF = @ADDUPYEARMONTH" + Environment.NewLine;
                SqlParameter paraMonthAddUpYearMonth = sqlCommand.Parameters.Add("@ADDUPYEARMONTH", SqlDbType.Int);
                paraMonthAddUpYearMonth.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(_accPaymentListCndtnWork.AddUpYearMonth);

                // エラーステータス
                selectTxt += "   AND ERRORSTATUSRF = 0" + Environment.NewLine;

                // 計上拠点コード
                selectTxt += "   AND ADDUPSECCODERF = @ADDUPSECCODE" + Environment.NewLine;
                SqlParameter paraAddupsecCode = sqlCommand.Parameters.Add("@ADDUPSECCODE", SqlDbType.NChar);
                paraAddupsecCode.Value = SqlDataMediator.SqlSetString(_accPaymentListCndtnWork.AddUpSecCode);

                // 処理区分(0:更新処理 1:解除処理)
                selectTxt += "   AND PROCDIVCDRF = 0" + Environment.NewLine;

                // 履歴制御区分(0:確定 1:未確定(履歴情報))
                if (_accPaymentListCndtnWork.MonAddUpEnable == 1)
                {
                    selectTxt += "   AND HISTCTLCDRF = 1" + Environment.NewLine;
                }
                else
                {
                    selectTxt += "   AND HISTCTLCDRF = 0" + Environment.NewLine;
                }

                #endregion  //[WHERE句]

                selectTxt += " 	GROUP BY" + Environment.NewLine;
                selectTxt += "    CREATEDATETIMERF" + Environment.NewLine;      // 作成日時
                selectTxt += " 	 ,UPDATEDATETIMERF" + Environment.NewLine;      // 更新日時
                selectTxt += "   ,ENTERPRISECODERF" + Environment.NewLine;      // 企業コード
                selectTxt += "   ,FILEHEADERGUIDRF" + Environment.NewLine;      // GUID
                selectTxt += "   ,UPDEMPLOYEECODERF" + Environment.NewLine;     // 更新従業員コード
                selectTxt += "   ,UPDASSEMBLYID1RF" + Environment.NewLine;      // 更新アセンブリID1
                selectTxt += "   ,UPDASSEMBLYID2RF" + Environment.NewLine;      // 更新アセンブリID2
                selectTxt += "   ,LOGICALDELETECODERF" + Environment.NewLine;   // 論理削除区分
                selectTxt += "   ,ACCRECACCPAYDIVRF" + Environment.NewLine;     // 売掛買掛区分
                selectTxt += "   ,ADDUPSECCODERF" + Environment.NewLine;        // 計上拠点コード
                selectTxt += "   ,STMONCADDUPUPDDATERF" + Environment.NewLine;  // 月次更新開始年月日
                selectTxt += "   ,MONTHLYADDUPDATERF" + Environment.NewLine;    // 月次更新年月日
                selectTxt += "   ,MONTHADDUPYEARMONTHRF" + Environment.NewLine; // 月次更新年月
                selectTxt += "   ,MONTHADDUPEXPDATERF" + Environment.NewLine;   // 月次更新実行年月日
                selectTxt += "   ,LAMONCADDUPUPDDATERF" + Environment.NewLine;  // 前回月次更新年月日
                selectTxt += "   ,DATAUPDATEDATETIMERF" + Environment.NewLine;  // データ更新日時
                selectTxt += "   ,PROCDIVCDRF" + Environment.NewLine;           // 処理区分
                selectTxt += "   ,ERRORSTATUSRF" + Environment.NewLine;         // エラーステータス
                selectTxt += "   ,HISTCTLCDRF" + Environment.NewLine;           // 履歴制御区分
                selectTxt += "   ,PROCRESULTRF" + Environment.NewLine;          // 処理結果
                selectTxt += "   ,CONVERTPROCESSDIVCDRF" + Environment.NewLine; // コンバート処理区分

                selectTxt += ") AS RES" + Environment.NewLine;
                selectTxt += "ORDER BY" + Environment.NewLine;
                selectTxt += " RES.DATAUPDATEDATETIMERF" + Environment.NewLine;
                #endregion  //[Select文作成]

                sqlCommand.CommandText = selectTxt;

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    MonAddUpCAddUpHisResultWork ResultWork = new MonAddUpCAddUpHisResultWork();

                    #region [抽出結果-値セット]
                    ResultWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                    ResultWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                    ResultWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                    ResultWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                    ResultWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                    ResultWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                    ResultWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                    ResultWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                    ResultWork.AccRecAccPayDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACCRECACCPAYDIVRF"));
                    ResultWork.AddUpSecCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDUPSECCODERF"));
                    ResultWork.StMonCAddUpUpdDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STMONCADDUPUPDDATERF"));
                    ResultWork.MonthlyAddUpDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("MONTHLYADDUPDATERF"));
                    ResultWork.MonthAddUpYearMonth = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MONTHADDUPYEARMONTHRF"));
                    ResultWork.MonthAddUpExpDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MONTHADDUPEXPDATERF"));
                    ResultWork.LaMonCAddUpUpdDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LAMONCADDUPUPDDATERF"));
                    ResultWork.DataUpdateDateTime = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DATAUPDATEDATETIMERF"));
                    ResultWork.ProcDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PROCDIVCDRF"));
                    ResultWork.ErrorStatus = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ERRORSTATUSRF"));
                    ResultWork.HistCtlCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("HISTCTLCDRF"));
                    ResultWork.ProcResult = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PROCRESULTRF"));
                    ResultWork.ConvertProcessDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CONVERTPROCESSDIVCDRF"));
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
                base.WriteErrorLog(ex, "MonAddUpCAddUpHisResultWork.SearchMonAddDataUpTimeProc Exception=" + ex.Message);
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
        #endregion  //[SearchMonAddDataUpTimeProc]

        #region [SearchMonAddUpDateProc]
        /// <summary>
        /// 月次締更新履歴マスタの履歴制御区分を確定にします。
        /// </summary>
        /// <param name="_monAddUpCAddUpHisResultWork">検索パラメータ</param>
        /// <param name="sqlConnection">コネクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 月次締更新履歴マスタの履歴制御区分を確定にします</br>
        /// <br>Programmer : FSI菅原(庸)</br>
        /// <br>Date       : 2012/11/14</br>
        private int SearchMonAddUpDateProc(ref MonAddUpCAddUpHisResultWork _monAddUpCAddUpHisResultWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                string selectTxt = "";
                sqlCommand = new SqlCommand(selectTxt, sqlConnection);

                // 対象テーブル
                // MONTHLYADDUPHISRF  月次締更新履歴データ

                #region [Update文作成]
                selectTxt += "UPDATE MONTHLYADDUPHISRF" + Environment.NewLine; //月次締更新履歴データ
                selectTxt += "SET HISTCTLCDRF = 0" + Environment.NewLine;      //履歴制御区分(0:確定 1:未確定(履歴情報))

                #region [WHERE句]
                selectTxt += " WHERE" + Environment.NewLine;

                //処理区分(0:更新処理 1:解除処理)
                selectTxt += "      PROCDIVCDRF = 0" + Environment.NewLine;

                //履歴制御区分(0:確定 1:未確定(履歴情報))
                selectTxt += "  AND HISTCTLCDRF = 1" + Environment.NewLine;

                //月次更新年月
                selectTxt += "  AND MONTHADDUPYEARMONTHRF = @MONTHADDUPYEARMONTH" + Environment.NewLine;
                SqlParameter paraMonthAddUpYearMonth = sqlCommand.Parameters.Add("@MONTHADDUPYEARMONTH", SqlDbType.Int);
                paraMonthAddUpYearMonth.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(_monAddUpCAddUpHisResultWork.MonthlyAddUpDate);

                //計上拠点コード
                selectTxt += "  AND ADDUPSECCODERF = @ADDUPSECCODE" + Environment.NewLine;
                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ADDUPSECCODE", SqlDbType.NChar);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(_monAddUpCAddUpHisResultWork.AddUpSecCode);

                //売掛買掛区分
                selectTxt += "  AND ACCRECACCPAYDIVRF = 1" + Environment.NewLine;

                //論理削除区分
                selectTxt += "  AND LOGICALDELETECODERF = 0" + Environment.NewLine;

                //エラーステータス
                selectTxt += "  AND ERRORSTATUSRF = 0" + Environment.NewLine;

                //月次更新実行年月日
                selectTxt += "  AND DATAUPDATEDATETIMERF = @DATAUPDATEDATETIME" + Environment.NewLine;
                SqlParameter paraDataUpdateDateTime = sqlCommand.Parameters.Add("@DATAUPDATEDATETIME", SqlDbType.BigInt);
                paraDataUpdateDateTime.Value = SqlDataMediator.SqlSetInt64(_monAddUpCAddUpHisResultWork.DataUpdateDateTime);

                #endregion  //[WHERE句]
                #endregion  //[Update文作成]

                sqlCommand.CommandText = selectTxt;

                myReader = sqlCommand.ExecuteReader();

            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "AccPaymentListWorkDB.SearchMonAddUpDateProc Exception=" + ex.Message);
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
        #endregion  //[SearchMonAddUpDateProc]

        #region [SearchMonAddDataInsertProc]
        /// <summary>
        /// 月次締更新履歴マスタにレコードを追加します。
        /// </summary>
        /// <param name="_monAddUpCAddUpHisResultWork">検索パラメータ</param>
        /// <param name="sqlConnection">コネクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 月次締更新履歴マスタにレコードを追加します</br>
        /// <br>Programmer : FSI菅原(庸)</br>
        /// <br>Date       : 2012/11/14</br>
        private int SearchMonAddDataInsertProc(ref MonAddUpCAddUpHisResultWork _monAddUpCAddUpHisResultWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                string selectTxt = "";
                sqlCommand = new SqlCommand(selectTxt, sqlConnection);

                // 対象テーブル
                // MONTHLYADDUPHISRF  月次締更新履歴データ

                #region [Insert文作成]
                selectTxt += "INSERT INTO MONTHLYADDUPHISRF" + Environment.NewLine;
                selectTxt += " (CREATEDATETIMERF" + Environment.NewLine;
                selectTxt += " ,UPDATEDATETIMERF" + Environment.NewLine;
                selectTxt += " ,ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " ,FILEHEADERGUIDRF" + Environment.NewLine;
                selectTxt += " ,UPDEMPLOYEECODERF" + Environment.NewLine;
                selectTxt += " ,UPDASSEMBLYID1RF" + Environment.NewLine;
                selectTxt += " ,UPDASSEMBLYID2RF" + Environment.NewLine;
                selectTxt += " ,LOGICALDELETECODERF" + Environment.NewLine;
                selectTxt += " ,ACCRECACCPAYDIVRF" + Environment.NewLine;
                selectTxt += " ,ADDUPSECCODERF" + Environment.NewLine;
                selectTxt += " ,STMONCADDUPUPDDATERF" + Environment.NewLine;
                selectTxt += " ,MONTHLYADDUPDATERF" + Environment.NewLine;
                selectTxt += " ,MONTHADDUPYEARMONTHRF" + Environment.NewLine;
                selectTxt += " ,MONTHADDUPEXPDATERF" + Environment.NewLine;
                selectTxt += " ,LAMONCADDUPUPDDATERF" + Environment.NewLine;
                selectTxt += " ,DATAUPDATEDATETIMERF" + Environment.NewLine;
                selectTxt += " ,PROCDIVCDRF" + Environment.NewLine;
                selectTxt += " ,ERRORSTATUSRF" + Environment.NewLine;
                selectTxt += " ,HISTCTLCDRF" + Environment.NewLine;
                selectTxt += " ,PROCRESULTRF" + Environment.NewLine;
                selectTxt += " ,CONVERTPROCESSDIVCDRF" + Environment.NewLine;
                selectTxt += " )" + Environment.NewLine;
                selectTxt += " VALUES" + Environment.NewLine;
                selectTxt += " (@CREATEDATETIME" + Environment.NewLine;
                selectTxt += " ,@UPDATEDATETIME" + Environment.NewLine;
                selectTxt += " ,@ENTERPRISECODE" + Environment.NewLine;
                selectTxt += " ,@FILEHEADERGUID" + Environment.NewLine;
                selectTxt += " ,@UPDEMPLOYEECODE" + Environment.NewLine;
                selectTxt += " ,@UPDASSEMBLYID1" + Environment.NewLine;
                selectTxt += " ,@UPDASSEMBLYID2" + Environment.NewLine;
                selectTxt += " ,@LOGICALDELETECODE" + Environment.NewLine;
                selectTxt += " ,@ACCRECACCPAYDIV" + Environment.NewLine;
                selectTxt += " ,@ADDUPSECCODE" + Environment.NewLine;
                selectTxt += " ,@STMONCADDUPUPDDATE" + Environment.NewLine;
                selectTxt += " ,@MONTHLYADDUPDATE" + Environment.NewLine;
                selectTxt += " ,@MONTHADDUPYEARMONTH" + Environment.NewLine;
                selectTxt += " ,@MONTHADDUPEXPDATE" + Environment.NewLine;
                selectTxt += " ,@LAMONCADDUPUPDDATE" + Environment.NewLine;
                selectTxt += " ,@DATAUPDATEDATETIME" + Environment.NewLine;
                selectTxt += " ,@PROCDIVCD" + Environment.NewLine;
                selectTxt += " ,@ERRORSTATUS" + Environment.NewLine;
                selectTxt += " ,@HISTCTLCD" + Environment.NewLine;
                selectTxt += " ,@PROCRESULT" + Environment.NewLine;
                selectTxt += " ,@CONVERTPROCESSDIVCD" + Environment.NewLine;
                selectTxt += " )" + Environment.NewLine;
                #endregion  //[Insert文作成]

                #region Parameterオブジェクト作成
                SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(_monAddUpCAddUpHisResultWork.CreateDateTime);

                SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(_monAddUpCAddUpHisResultWork.UpdateDateTime);

                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(_monAddUpCAddUpHisResultWork.EnterpriseCode);

                SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(_monAddUpCAddUpHisResultWork.FileHeaderGuid);

                SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(_monAddUpCAddUpHisResultWork.UpdEmployeeCode);

                SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(_monAddUpCAddUpHisResultWork.UpdAssemblyId1);

                SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(_monAddUpCAddUpHisResultWork.UpdAssemblyId2);

                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(_monAddUpCAddUpHisResultWork.LogicalDeleteCode);

                SqlParameter paraAddUpSecCode = sqlCommand.Parameters.Add("@ADDUPSECCODE", SqlDbType.NChar);
                paraAddUpSecCode.Value = SqlDataMediator.SqlSetString(_monAddUpCAddUpHisResultWork.AddUpSecCode);

                SqlParameter paraStMonCAddUpUpdDate = sqlCommand.Parameters.Add("@STMONCADDUPUPDDATE", SqlDbType.Int);
                paraStMonCAddUpUpdDate.Value = SqlDataMediator.SqlSetInt32(_monAddUpCAddUpHisResultWork.StMonCAddUpUpdDate);

                SqlParameter paraMonthlyAddUpDate = sqlCommand.Parameters.Add("@MONTHLYADDUPDATE", SqlDbType.Int);
                paraMonthlyAddUpDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(_monAddUpCAddUpHisResultWork.MonthlyAddUpDate);

                SqlParameter paraMonthAddUpYearMonth = sqlCommand.Parameters.Add("@MONTHADDUPYEARMONTH", SqlDbType.Int);
                paraMonthAddUpYearMonth.Value = SqlDataMediator.SqlSetInt32(_monAddUpCAddUpHisResultWork.MonthAddUpYearMonth);

                SqlParameter paraMonthAddUpExpDate = sqlCommand.Parameters.Add("@MONTHADDUPEXPDATE", SqlDbType.Int);
                paraMonthAddUpExpDate.Value = SqlDataMediator.SqlSetInt32(_monAddUpCAddUpHisResultWork.MonthAddUpExpDate);

                SqlParameter paraDataUpdateDateTime = sqlCommand.Parameters.Add("@DATAUPDATEDATETIME", SqlDbType.BigInt);
                paraDataUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(_monAddUpCAddUpHisResultWork.CreateDateTime);

                SqlParameter paraLaMonCAddUpUpdDate = sqlCommand.Parameters.Add("@LAMONCADDUPUPDDATE", SqlDbType.Int);
                paraLaMonCAddUpUpdDate.Value = SqlDataMediator.SqlSetInt32(_monAddUpCAddUpHisResultWork.LaMonCAddUpUpdDate);

                SqlParameter paraAccRecAccPayDiv = sqlCommand.Parameters.Add("@ACCRECACCPAYDIV", SqlDbType.Int);
                paraAccRecAccPayDiv.Value = SqlDataMediator.SqlSetInt32(_monAddUpCAddUpHisResultWork.AccRecAccPayDiv);

                SqlParameter paraProcDivCd = sqlCommand.Parameters.Add("@PROCDIVCD", SqlDbType.Int);
                paraProcDivCd.Value = SqlDataMediator.SqlSetInt32(_monAddUpCAddUpHisResultWork.ProcDivCd);

                SqlParameter paraErrorStatus = sqlCommand.Parameters.Add("@ERRORSTATUS", SqlDbType.Int);
                paraErrorStatus.Value = SqlDataMediator.SqlSetInt32(_monAddUpCAddUpHisResultWork.ErrorStatus);

                SqlParameter paraHistCtlCd = sqlCommand.Parameters.Add("@HISTCTLCD", SqlDbType.Int);
                paraHistCtlCd.Value = SqlDataMediator.SqlSetInt32(_monAddUpCAddUpHisResultWork.HistCtlCd);

                SqlParameter paraProcResult = sqlCommand.Parameters.Add("@PROCRESULT", SqlDbType.NVarChar);
                paraProcResult.Value = SqlDataMediator.SqlSetString(_monAddUpCAddUpHisResultWork.ProcResult);

                SqlParameter paraConvertProcessDivCd = sqlCommand.Parameters.Add("@CONVERTPROCESSDIVCD", SqlDbType.Int);
                paraConvertProcessDivCd.Value = SqlDataMediator.SqlSetInt32(_monAddUpCAddUpHisResultWork.ConvertProcessDivCd);
                #endregion
                  
                sqlCommand.CommandText = selectTxt;

                myReader = sqlCommand.ExecuteReader();

            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "AccPaymentListWorkDB.SearchMonAddDataInsertProc Exception=" + ex.Message);
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
        #endregion  //[SearchMonAddDataInsertProc]
        // --- ADD 2012/11/14 ----------<<<<<

        #region [コネクション生成処理]
        /// <summary>
        /// SqlConnection生成処理
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Programmer : 23015 森本 大輝</br>
        /// <br>Date       : 2008.09.22</br>
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

        // --- ADD START 3H 劉星光 2020/03/02 ---------->>>>>
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
        /// <br>Date       : 2020/02/28</br>
        /// </remarks>
        private int SearchSuplAccPayDate(AccPaymentListCndtnWork accPaymentListCndtnWork, ref Dictionary<string, SuplAccPayDateInfo> suplAccPayDateDic, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;

            try
            {
                string sqlText = string.Empty;

                using (SqlCommand sqlCommand = new SqlCommand(sqlText, sqlConnection))
                {
                    sqlText += "SELECT" + Environment.NewLine;
                    sqlText += "  ADDUPSECCODERF," + Environment.NewLine;
                    sqlText += "  PAYEECODERF," + Environment.NewLine;
                    sqlText += "  ADDUPDATERF," + Environment.NewLine;
                    sqlText += "  LAMONCADDUPUPDDATERF" + Environment.NewLine;
                    sqlText += " FROM SUPLACCPAYRF WITH (READUNCOMMITTED)" + Environment.NewLine;
                    sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    sqlText += "    AND ADDUPYEARMONTHRF=@FINDADDUPYEARMONTH" + Environment.NewLine;
                    sqlText += "    AND SUPPLIERCDRF=0" + Environment.NewLine;

                    //支払先コード
                    if (accPaymentListCndtnWork.St_PayeeCode != 0)
                    {
                        sqlText += " AND PAYEECODERF>=@ST_PAYEECODECD" + Environment.NewLine;
                        SqlParameter paraSt_SupplierCd = sqlCommand.Parameters.Add("@ST_PAYEECODECD", SqlDbType.Int);
                        paraSt_SupplierCd.Value = SqlDataMediator.SqlSetInt32(accPaymentListCndtnWork.St_PayeeCode);
                    }
                    if (accPaymentListCndtnWork.Ed_PayeeCode != 999999)
                    {
                        sqlText += " AND PAYEECODERF<=@ED_PAYEECODECD" + Environment.NewLine;
                        SqlParameter paraEd_PayeeCode = sqlCommand.Parameters.Add("@ED_PAYEECODECD", SqlDbType.Int);
                        paraEd_PayeeCode.Value = SqlDataMediator.SqlSetInt32(accPaymentListCndtnWork.Ed_PayeeCode);
                    }
                    sqlText += " ORDER BY PAYEECODERF" + Environment.NewLine;

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
        /// <param name="accPaymentListCndtnWork">買掛残高一覧表抽出条件</param>
        /// <param name="isCheckOut">締次フラッグ</param>
        /// <param name="laMonCAddUpUpdDate">前回月次更新年月日</param>
        /// <param name="suplAccPayDateDic">支払先毎の月次更新処理日ディクショナリ</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 11570208-00 軽減税率対応</br>
        /// <br>Programmer : 3H 劉星光</br>
        /// <br>Date       : 2020/03/02</br>
        /// <br>Note       : 11870141-00 インボイス対応（税率別合計金額不具合修正）</br>
        /// <br>Programmer : 3H 仰亮亮</br>
        /// <br>Date       : 2022/10/09</br>
        /// </remarks>
        private int SearchStockProc(ref AccPaymentListResultWork accPaymentWork, ref SqlConnection sqlConnection, AccPaymentListCndtnWork accPaymentListCndtnWork, bool isCheckOut, DateTime laMonCAddUpUpdDate, Dictionary<string, SuplAccPayDateInfo> suplAccPayDateDic)
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
                    // --- ADD START 3H 仰亮亮 2022/10/09 ----->>>>>
                    sqlText += " SUPLIERPAY.TAXATIONCODERF, --課税区分" + Environment.NewLine;
                    // --- ADD END 3H 仰亮亮 2022/10/09 -----<<<<<
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
                    // --- ADD START 3H 仰亮亮 2022/10/09 ----->>>>>
                    sqlText += " STOCK.TAXATIONCODERF, --課税区分" + Environment.NewLine;
                    // --- ADD END 3H 仰亮亮 2022/10/09 -----<<<<<
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
                    // --- DEL START 3H 仰亮亮 2022/10/09 ----->>>>>
                    //sqlText += "    SUBSTOCK.STOCKNETPRICERF + SUBSTOCKDTL.DISSTOCKPRICETAXEXCGYO AS STOCKNETPRICERF," + Environment.NewLine;
                    //sqlText += "    SUBSTOCK.STCKDISTTLTAXEXCRF - SUBSTOCKDTL.DISSTOCKPRICETAXEXCGYO AS STCKDISTTLTAXEXCRF," + Environment.NewLine;
                    //sqlText += "    (CASE WHEN (SUBSTOCK.SUPPCTAXLAYCDRF =0 ) THEN (SUBSTOCK.STOCKTTLPRICTAXINCRF - SUBSTOCK.STOCKTTLPRICTAXEXCRF) ELSE 0 END) AS SLIPSTOCKPRICECONSTAX," + Environment.NewLine;
                    // --- DEL END 3H 仰亮亮 2022/10/09 -----<<<<<
                    // --- ADD START 3H 仰亮亮 2022/10/09 ----->>>>>
                    sqlText += "      (CASE WHEN (SUBSTOCKDTL.SUPPLIERSLIPCDRF =10) THEN SUBSTOCKDTL.STOCKPRICE + SUBSTOCKDTL.DISSTOCKPRICETAXEXCGYO WHEN (SUBSTOCKDTL.SUPPLIERSLIPCDRF =20) THEN SUBSTOCKDTL.RETSTOCKPRICE + SUBSTOCKDTL.DISSTOCKPRICETAXEXCGYO ELSE 0 END) AS STOCKNETPRICERF," + Environment.NewLine;
                    sqlText += "      SUBSTOCKDTL.DISGOODSSTAXEXCGYO AS STCKDISTTLTAXEXCRF," + Environment.NewLine;
                    sqlText += "      SUBSTOCKDTL.TAXATIONCODERF AS TAXATIONCODERF, --課税区分" + Environment.NewLine;
                    sqlText += "      (CASE WHEN (SUBSTOCK.SUPPCTAXLAYCDRF =0 AND SUBSTOCKDTL.TAXATIONCODERF = 0) THEN (SUBSTOCK.STOCKTTLPRICTAXINCRF - SUBSTOCK.STOCKTTLPRICTAXEXCRF) ELSE 0 END) AS SLIPSTOCKPRICECONSTAX," + Environment.NewLine;
                    // --- ADD END 3H 仰亮亮 2022/10/09 -----<<<<<
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
                    // --- ADD START 3H 仰亮亮 2022/10/09 ----->>>>>
                    sqlText += "       DTL.TAXATIONCODERF, --課税区分 " + Environment.NewLine;
                    // --- ADD END 3H 仰亮亮 2022/10/09 -----<<<<<
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
                    //sqlText += "       STOCK.SUPPLIERSLIPNORF --仕入伝票番号 " + Environment.NewLine; // DEL 3H 仰亮亮 2022/10/09
                    // --- ADD START 3H 仰亮亮 2022/10/09 ----->>>>>
                    sqlText += "       STOCK.SUPPLIERSLIPNORF, --仕入伝票番号 " + Environment.NewLine;
                    sqlText += "       DTL.TAXATIONCODERF --課税区分 " + Environment.NewLine;
                    // --- ADD END 3H 仰亮亮 2022/10/09 -----<<<<<
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
                    // 仕入総括オプションが無効の場合
                    if (accPaymentListCndtnWork.OptSuppEnable == 1)
                    {
                        sqlText += "    AND  STOCK.PAYEECODERF =@FINDPAYEECODE" + Environment.NewLine;
                    }
                    // 仕入総括オプションが有効の場合
                    else
                    {
                        sqlText += "    AND STOCK.SUPPLIERCDRF =@FINDPAYEECODE" + Environment.NewLine;
                        sqlText += "    AND STOCK.STOCKSECTIONCDRF = @FINDADDUPSECCODE" + Environment.NewLine;
                    }
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
                    //sqlText += "    STOCK.SUPPLIERCONSTAXRATERF" + Environment.NewLine; // DEL 3H 仰亮亮 2022/10/09
                    // --- ADD START 3H 仰亮亮 2022/10/09 ----->>>>>
                    sqlText += "    STOCK.SUPPLIERCONSTAXRATERF," + Environment.NewLine;
                    sqlText += "    STOCK.TAXATIONCODERF" + Environment.NewLine;
                    // --- ADD END 3H 仰亮亮 2022/10/09 -----<<<<<
                    sqlText += ") AS SUPLIERPAY" + Environment.NewLine;
                    #endregion

                    #endregion

                    sqlCommand.CommandText = sqlText;

                    #region  Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaPayeeCode = sqlCommand.Parameters.Add("@FINDPAYEECODE", SqlDbType.Int);
                    SqlParameter findParaAddUpDate = sqlCommand.Parameters.Add("@FINDADDUPDATE", SqlDbType.Int);
                    SqlParameter findParaLastTimeAddUpDate = sqlCommand.Parameters.Add("@FINDLASTTIMEADDUPDATE", SqlDbType.Int);
                    SqlParameter findParaAddUpSecCode = null;
                    // 仕入総括オプションが有効の場合
                    if (accPaymentListCndtnWork.OptSuppEnable != 1)
                    {
                        findParaAddUpSecCode = sqlCommand.Parameters.Add("@FINDADDUPSECCODE", SqlDbType.NChar);
                    }
                    #endregion

                    #region Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCode);
                    findParaPayeeCode.Value = SqlDataMediator.SqlSetInt32(accPaymentWork.PayeeCode);
                    findParaAddUpDate.Value = SqlDataMediator.SqlSetInt32(addUpDate);
                    // 仕入総括オプションが有効の場合
                    if (accPaymentListCndtnWork.OptSuppEnable != 1)
                    {
                        findParaAddUpSecCode.Value = SqlDataMediator.SqlSetString(accPaymentWork.AddUpSecCode);
                    }

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

                        // --- ADD START 3H 仰亮亮 2022/10/09 ----->>>>>
                        // 課税区分
                        int taxAtionCodeRF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TAXATIONCODERF"));
                        // --- ADD END 3H 仰亮亮 2022/10/09 -----<<<<<

                        #endregion
                        
                        #region 税別内訳印字
                        //if (suplAccPayWork.SuppCTaxLayCd != 9 && suplAccPayWork.SupplierConsTaxRate == accPaymentListCndtnWork.TaxRate1) // DEL 3H 仰亮亮 2022/10/09
                        if ((suplAccPayWork.SuppCTaxLayCd != 9 && taxAtionCodeRF != 1) && suplAccPayWork.SupplierConsTaxRate == accPaymentListCndtnWork.TaxRate1) // ADD 3H 仰亮亮 2022/10/09
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
                        //else if (suplAccPayWork.SuppCTaxLayCd != 9 && suplAccPayWork.SupplierConsTaxRate == accPaymentListCndtnWork.TaxRate2) // DEL 3H 仰亮亮 2022/10/09
                        else if ((suplAccPayWork.SuppCTaxLayCd != 9 && taxAtionCodeRF != 1) && suplAccPayWork.SupplierConsTaxRate == accPaymentListCndtnWork.TaxRate2)// ADD 3H 仰亮亮 2022/10/09
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
                        // --- ADD START 3H 仰亮亮 2022/10/09 ----->>>>>
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
                        // --- ADD END 3H 仰亮亮 2022/10/09 -----<<<<<
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
                                // sqlText += "	    SUBSTOCK.STOCKTTLPRICTAXEXCRF," + Environment.NewLine; // DEL 3H 仰亮亮 2022/10/09
                                // --- ADD START 3H 仰亮亮 2022/10/09 ----->>>>>
                                sqlText += "	 (SELECT SUM(STOCKPRICETAXEXCRF) AS STOCKTTLPRICTAXEXCRF  FROM STOCKDETAILRF AS DTL WITH (READUNCOMMITTED) WHERE " + Environment.NewLine;
                                sqlText += "       SUBSTOCK.ENTERPRISECODERF = DTL.ENTERPRISECODERF" + Environment.NewLine;
                                sqlText += "       AND SUBSTOCK.SUPPLIERFORMALRF = DTL.SUPPLIERFORMALRF" + Environment.NewLine;
                                sqlText += "       AND SUBSTOCK.SUPPLIERSLIPNORF  = DTL.SUPPLIERSLIPNORF " + Environment.NewLine;
                                sqlText += "       AND DTL.TAXATIONCODERF = 0) AS STOCKTTLPRICTAXEXCRF, " + Environment.NewLine;
                                // --- ADD END 3H 仰亮亮 2022/10/09 -----<<<<<
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
                                sqlText += "        AND (SUBSTOCK.SUPPLIERSLIPCDRF = 10 OR SUBSTOCK.SUPPLIERSLIPCDRF = 20)" + Environment.NewLine;
                                sqlText += "        AND (SUBSTOCK.STOCKGOODSCDRF=0 OR SUBSTOCK.STOCKGOODSCDRF = 6)" + Environment.NewLine;
                                sqlText += ") AS STOCK" + Environment.NewLine;
                                // 仕入総括オプションが無効の場合
                                if (accPaymentListCndtnWork.OptSuppEnable == 1)
                                {
                                    sqlText += "    WHERE  STOCK.PAYEECODERF=@FINDPAYEECODE" + Environment.NewLine;
                                }
                                // 仕入総括オプションが有効の場合
                                else
                                {
                                    sqlText += "    WHERE STOCK.SUPPLIERCDRF=@FINDPAYEECODE" + Environment.NewLine;
                                    sqlText += "    AND STOCK.STOCKSECTIONCDRF = @FINDADDUPSECCODE" + Environment.NewLine;
                                }
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
                                // sqlText += "	    SUBSTOCK.STOCKTTLPRICTAXEXCRF," + Environment.NewLine; // DEL 3H 仰亮亮 2022/10/09
                                // --- ADD START 3H 仰亮亮 2022/10/09 ----->>>>>
                                sqlText += "	 (SELECT SUM(STOCKPRICETAXEXCRF) AS STOCKTTLPRICTAXEXCRF  FROM STOCKDETAILRF AS DTL WITH (READUNCOMMITTED) WHERE " + Environment.NewLine;
                                sqlText += "       SUBSTOCK.ENTERPRISECODERF = DTL.ENTERPRISECODERF" + Environment.NewLine;
                                sqlText += "       AND SUBSTOCK.SUPPLIERFORMALRF = DTL.SUPPLIERFORMALRF" + Environment.NewLine;
                                sqlText += "       AND SUBSTOCK.SUPPLIERSLIPNORF  = DTL.SUPPLIERSLIPNORF " + Environment.NewLine;
                                sqlText += "       AND DTL.TAXATIONCODERF = 0) AS STOCKTTLPRICTAXEXCRF, " + Environment.NewLine;
                                // --- ADD END 3H 仰亮亮 2022/10/09 -----<<<<<
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
                                sqlText += "        AND (SUBSTOCK.SUPPLIERSLIPCDRF = 10 OR SUBSTOCK.SUPPLIERSLIPCDRF = 20)" + Environment.NewLine;
                                sqlText += "        AND (SUBSTOCK.STOCKGOODSCDRF=0 OR SUBSTOCK.STOCKGOODSCDRF = 6)" + Environment.NewLine;
                                sqlText += ") AS STOCK" + Environment.NewLine;
                                // 仕入総括オプションが無効の場合
                                if (accPaymentListCndtnWork.OptSuppEnable == 1)
                                {
                                    sqlText += "    WHERE  STOCK.PAYEECODERF=@FINDPAYEECODE" + Environment.NewLine;
                                }
                                // 仕入総括オプションが有効の場合
                                else
                                {
                                    sqlText += "    WHERE STOCK.SUPPLIERCDRF=@FINDPAYEECODE" + Environment.NewLine;
                                    sqlText += "    AND STOCK.STOCKSECTIONCDRF = @FINDADDUPSECCODE" + Environment.NewLine;
                                }
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
                    // --- ADD START 3H 仰亮亮 2022/10/09 ----->>>>>
                    // 当月合計(計非課税)
                    accPaymentWork.TotalStckTtlAccPayBalanceTaxFree = accPaymentWork.TotalPureStockTaxFree + accPaymentWork.TotalStockPricTaxTaxFree;
                    // --- ADD END 3H 仰亮亮 2022/10/09 -----<<<<<
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
        /// <br>Date       : 2020/03/02</br>
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
        // --- ADD END 3H 劉星光 2020/03/02 ----------<<<<<

        /// <summary>
        /// 支払内訳区分を列挙します。
        /// </summary>
        enum PayDtlDiv
        {
            PayDtlON = 0,  //0:印字する
            PayDtlOFF = 1  //1:印字しない
        }
    }

    // --- ADD START 3H 劉星光 2020/02/28 ---------->>>>>
    # region [月次更新・月次処理日情報]
    /// <summary>
    /// 月次処理日情報
    /// </summary>
    /// <remarks>
    /// <br>Note       : 11570208-00 軽減税率対応</br>
    /// <br>Programmer : 3H 劉星光</br>
    /// <br>Date       : 2020/02/28</br>
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
    // --- ADD END 3H 劉星光 2020/02/28 ----------<<<<<
}

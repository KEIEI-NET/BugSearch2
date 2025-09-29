//****************************************************************************//
// システム         : 自働回答処理
// プログラム名称   : 自働回答処理アクセス
// プログラム概要   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 工藤 恵優
// 作 成 日  2009/06/17  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 工藤 恵優
// 作 成 日  2010/04/05  修正内容 : 以前に見積伝票データを作成している発注の場合、作成する回答データおよび売上伝票データは見積伝票データを元に作成する
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 脇田 靖之
// 作 成 日  2013/08/07  修正内容 : PM-SCM仕掛一覧№10556対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 吉岡
// 作 成 日  2013/08/07  修正内容 : PM-SCM仕掛一覧№10556対応時の修正
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;

using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Controller.Agent;
using Broadleaf.Application.Controller.Util;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Collections;
using Broadleaf.Library.Resources;

namespace Broadleaf.Application.Controller.Other
{
    using SalesTtlStServer      = SingletonInstance<SalesTtlStAgent>;       // 売上全体設定マスタ
    using SalesProcMoneyServer  = SingletonInstance<SalesProcMoneyAgent>;   // 売上金額処理区分マスタ
    // ADD 2010/04/05 以前に見積伝票データを作成している発注の場合、作成する回答データおよび売上伝票データは見積伝票データを元に作成する ---------->>>>>
    using SalesDetailTuple = Tuple<
        List<SalesDetailWork>,  // 売上明細データ
        List<AcceptOdrCarWork>, // 
        List<StockSlipWork>,    // 仕入データ
        List<StockDetailWork>,  // 仕入明細データ
        List<UOEOrderDtlWork>,  // UOE受注データ
        NullObject,
        NullObject,
        NullObject,
        NullObject,
        NullObject
    >;
    // ADD 2010/04/05 以前に見積伝票データを作成している発注の場合、作成する回答データおよび売上伝票データは見積伝票データを元に作成する ----------<<<<<

    /// <summary>
    /// 売上伝票入力、検索見積発行からの移植クラス
    /// </summary>
    public sealed class OtherAppComponent
    {
        #region <企業コード>

        /// <summary>企業コード</summary>
        private readonly string _enterpriseCode;
        /// <summary>企業コード取得します。</summary>
        private string EnterpriseCode { get { return _enterpriseCode; } }

        #endregion // </企業コード>

        #region <拠点コード>

        /// <summary>拠点コード</summary>
        private readonly string _sectionCode;
        /// <summary>拠点コードを取得します。</summary>
        private string SectionCode { get { return _sectionCode; } }

        #endregion // </拠点コード>

        #region <Constructor>

        /// <summary>
        /// カスタムコンストラクタ
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点コード</param>
        public OtherAppComponent(
            string enterpriseCode,
            string sectionCode
        )
        {
            _enterpriseCode = enterpriseCode;
            _sectionCode    = sectionCode;
        }

        #endregion // </Constructor>

        #region <売伝 I/O Writer の入金系パラメータ関連>

        #region <Const>

        /// <summary>
        /// 受注ステータス
        /// </summary>
        public enum AcptAnOdrStatusState : int
        {
            /// <summary>見積</summary>
            Estimate = 10,
            /// <summary>単価見積</summary>
            UnitPriceEstimate = 15,
            /// <summary>検索見積</summary>
            SearchEstimate = 16,
            /// <summary>受注</summary>
            AcceptAnOrder = 20,
            /// <summary>売上</summary>
            Sales = 30,
            /// <summary>貸出</summary>
            Shipment = 40,
        }

        /// <summary>
        /// 売掛区分
        /// </summary>
        public enum AccRecDivCd : int
        {
            /// <summary>売掛なし</summary>
            NonAccRec = 0,
            /// <summary>売掛</summary>
            AccRec = 1,
        }

        /// <summary>
        /// 商品区分
        /// </summary>
        public enum SalesGoodsCd : int
        {
            /// <summary>商品</summary>
            Goods = 0,
            /// <summary>商品外</summary>
            NonGoods = 1,
            /// <summary>消費税調整</summary>
            ConsTaxAdjust = 2,
            /// <summary>残高調整</summary>
            BalanceAdjust = 3,
            /// <summary>売掛用消費税調整</summary>
            AccRecConsTaxAdjust = 4,
            /// <summary>売掛用残高調整</summary>
            AccRecBalanceAdjust = 5,
        }

        /// <summary>売上伝票番号初期値</summary>
        public static readonly string ctDefaultSalesSlipNum = string.Empty.PadLeft(9, '0');

        #endregion // </Const>

        /// <summary>
        /// 売上全体設定を取得します。
        /// </summary>
        /// <returns>売上全体設定</returns>
        private SalesTtlSt GetSalesTtlSt()
        {
            return SalesTtlStServer.Singleton.Instance.Find(EnterpriseCode, SectionCode) ?? new SalesTtlSt();
        }

        /// <summary>入金データ</summary>
        private SearchDepsitMain _depsitMain = new SearchDepsitMain();
        /// <summary>入金引当データ</summary>
        private SearchDepositAlw _depositAlw = new SearchDepositAlw();

        // MAHNB01012AA 8755行目
        #region ●入金データオブジェクト取得

        /// <summary>
        /// 現在の売上データオブジェクトから入金データオブジェクトを取得します。
        /// </summary>
        /// <param name="salesSlip">売上データオブジェクト</param>
        /// <param name="depsitMain">入金データオブジェクト</param>
        /// <param name="depositAlw">入金引当データオブジェクト</param>
        public void GetCurrentDepsitMain(
            ref SalesSlip salesSlip,
            out SearchDepsitMain depsitMain,
            out SearchDepositAlw depositAlw
        )
        {
            depsitMain = new SearchDepsitMain();

            //-----------------------------------------------------------------------------
            // 対象金額算出
            //-----------------------------------------------------------------------------
            long totalPrice = salesSlip.SalesTotalTaxInc;
            if (salesSlip.TotalAmountDispWayCd == (int)SalesSlipInputAcs.TotalAmountDispWayCd.NoTotalAmount)
            {
                // 総額表示しない
                switch (salesSlip.ConsTaxLayMethod)
                {
                    case 0: // 伝票転嫁
                    case 1: // 明細転嫁
                        break;
                    case 2: // 請求親
                    case 3: // 請求子
                    case 9: // 非課税
                        // 総合計
                        totalPrice = salesSlip.ItdedSalesInTax + salesSlip.ItdedSalesOutTax + salesSlip.SalSubttlSubToTaxFre +
                                     salesSlip.ItdedSalesDisOutTax + salesSlip.ItdedSalesDisInTax + salesSlip.ItdedSalesDisTaxFre +
                                     salesSlip.SalAmntConsTaxInclu + salesSlip.SalesDisTtlTaxInclu;
                        break;
                }
            }

            //-----------------------------------------------------------------------------
            // 売上形式「売上荷」、「売掛無し」、商品区分「商品」、自動入金区分「する」の場合は自動入金作成
            //-----------------------------------------------------------------------------
            if ((salesSlip.AcptAnOdrStatusDisplay == (int)AcptAnOdrStatusState.Sales) &&
                (salesSlip.AccRecDivCd == (int)AccRecDivCd.NonAccRec) &&
                (salesSlip.SalesGoodsCd == (int)SalesGoodsCd.Goods) &&
                (GetSalesTtlSt().AutoDepositCd == (int)SalesSlipInputAcs.AutoDepositCd.Write))
            {
                // 修正伝票の場合はキャッシュしているデータから取得する
                if (salesSlip.SalesSlipNum.PadLeft(9, '0') != ctDefaultSalesSlipNum)
                {
                    // 自動入金データ作成分の売上データは修正不可。
                    // 既存
                    depsitMain = this._depsitMain.Clone();
                    depositAlw = this._depositAlw.Clone();
                }
                else
                {
                    // 新規
                    depsitMain = new SearchDepsitMain();
                    depositAlw = new SearchDepositAlw();

                    depsitMain.DepositRowNo[0] = 1; // 入金行番号
                    depsitMain.MoneyKindCode[0] = GetSalesTtlSt().AutoDepoKindCode; // 入金金種コード
                    depsitMain.MoneyKindName[0] = GetSalesTtlSt().AutoDepoKindName; // 入金金種名称
                    depsitMain.MoneyKindDiv[0] = GetSalesTtlSt().AutoDepoKindDivCd; // 入金金種区分

                    depsitMain.ClaimName = salesSlip.ClaimName; // 請求先名称
                    depsitMain.ClaimName2 = salesSlip.ClaimName2; // 請求先名称２
                    salesSlip.AutoDepositCd = 1; // 自動入金区分(1:自動入金)
                    salesSlip.DepositAlwcBlnce = totalPrice; // 入金引当残高
                    salesSlip.DepositAllowanceTtl = 0; // 入金引当合計額
                }
            }
            else
            {
                depsitMain = new SearchDepsitMain();
                depositAlw = new SearchDepositAlw();

                salesSlip.DepositAlwcBlnce = totalPrice; // 入金引当残高
                salesSlip.DepositAllowanceTtl = 0; // 入金引当合計額
            }

        }

        #endregion

        /// <summary>
        /// PramData→UIData移項処理
        /// </summary>
        /// <param name="searchDepsitMain">入金データオブジェクト</param>
        /// <param name="work"></param>
        /// <returns>入金ワークオブジェクト</returns>
        public static DepsitDataWork ParamDataFromUIDataProc(SearchDepsitMain searchDepsitMain, out DepsitMainWork work)
        {
            DepsitDataWork depsitDataWork = new DepsitDataWork();
            DepsitMainWork depsitMainWork = new DepsitMainWork();
            DepsitDtlWork[] depsitDtlWorkArray = new DepsitDtlWork[searchDepsitMain.DepositRowNo.Length];

            depsitMainWork.CreateDateTime = searchDepsitMain.CreateDateTime; // 作成日時
            depsitMainWork.UpdateDateTime = searchDepsitMain.UpdateDateTime; // 更新日時
            depsitMainWork.EnterpriseCode = searchDepsitMain.EnterpriseCode; // 企業コード
            depsitMainWork.FileHeaderGuid = searchDepsitMain.FileHeaderGuid; // GUID
            depsitMainWork.UpdEmployeeCode = searchDepsitMain.UpdEmployeeCode; // 更新従業員コード
            depsitMainWork.UpdAssemblyId1 = searchDepsitMain.UpdAssemblyId1; // 更新アセンブリID1
            depsitMainWork.UpdAssemblyId2 = searchDepsitMain.UpdAssemblyId2; // 更新アセンブリID2
            depsitMainWork.LogicalDeleteCode = searchDepsitMain.LogicalDeleteCode; // 論理削除区分
            depsitMainWork.AcptAnOdrStatus = searchDepsitMain.AcptAnOdrStatus; // 受注ステータス
            depsitMainWork.DepositDebitNoteCd = searchDepsitMain.DepositDebitNoteCd; // 入金赤黒区分
            depsitMainWork.DepositSlipNo = searchDepsitMain.DepositSlipNo; // 入金伝票番号
            depsitMainWork.SalesSlipNum = searchDepsitMain.SalesSlipNum; // 売上伝票番号
            depsitMainWork.InputDepositSecCd = searchDepsitMain.InputDepositSecCd; // 入金入力拠点コード
            depsitMainWork.AddUpSecCode = searchDepsitMain.AddUpSecCode; // 計上拠点コード
            depsitMainWork.UpdateSecCd = searchDepsitMain.UpdateSecCd; // 更新拠点コード
            depsitMainWork.SubSectionCode = searchDepsitMain.SubSectionCode; // 部門コード
            depsitMainWork.DepositDate = searchDepsitMain.DepositDate; // 入金日付
            depsitMainWork.AddUpADate = searchDepsitMain.AddUpADate; // 計上日付
            depsitMainWork.DepositTotal = searchDepsitMain.DepositTotal; // 入金計
            depsitMainWork.Deposit = searchDepsitMain.Deposit; // 入金金額
            depsitMainWork.FeeDeposit = searchDepsitMain.FeeDeposit; // 手数料入金額
            depsitMainWork.DiscountDeposit = searchDepsitMain.DiscountDeposit; // 値引入金額
            depsitMainWork.AutoDepositCd = searchDepsitMain.AutoDepositCd; // 自動入金区分
            depsitMainWork.DraftDrawingDate = searchDepsitMain.DraftDrawingDate; // 手形振出日
            depsitMainWork.DraftKind = searchDepsitMain.DraftKind; // 手形種類
            depsitMainWork.DraftKindName = searchDepsitMain.DraftKindName; // 手形種類名称
            depsitMainWork.DraftDivide = searchDepsitMain.DraftDivide; // 手形区分
            depsitMainWork.DraftDivideName = searchDepsitMain.DraftDivideName; // 手形区分名称
            depsitMainWork.DraftNo = searchDepsitMain.DraftNo; // 手形番号
            depsitMainWork.DepositAllowance = searchDepsitMain.DepositAllowance; // 入金引当額
            depsitMainWork.DepositAlwcBlnce = searchDepsitMain.DepositAlwcBlnce; // 入金引当残高
            depsitMainWork.DebitNoteLinkDepoNo = searchDepsitMain.DebitNoteLinkDepoNo; // 赤黒入金連結番号
            depsitMainWork.LastReconcileAddUpDt = searchDepsitMain.LastReconcileAddUpDt; // 最終消し込み計上日
            depsitMainWork.DepositAgentCode = searchDepsitMain.DepositAgentCode; // 入金担当者コード
            depsitMainWork.DepositAgentNm = searchDepsitMain.DepositAgentNm; // 入金担当者名称
            depsitMainWork.DepositInputAgentCd = searchDepsitMain.DepositInputAgentCd; // 入金入力者コード
            depsitMainWork.DepositInputAgentNm = searchDepsitMain.DepositInputAgentNm; // 入金入力者名称
            depsitMainWork.CustomerCode = searchDepsitMain.CustomerCode; // 得意先コード
            depsitMainWork.CustomerName = searchDepsitMain.CustomerName; // 得意先名称
            depsitMainWork.CustomerName2 = searchDepsitMain.CustomerName2; // 得意先名称2
            depsitMainWork.CustomerSnm = searchDepsitMain.CustomerSnm; // 得意先略称
            depsitMainWork.ClaimCode = searchDepsitMain.ClaimCode; // 請求先コード
            depsitMainWork.ClaimName = searchDepsitMain.ClaimName; // 請求先名称
            depsitMainWork.ClaimName2 = searchDepsitMain.ClaimName2; // 請求先名称2
            depsitMainWork.ClaimSnm = searchDepsitMain.ClaimSnm; // 請求先略称
            depsitMainWork.Outline = searchDepsitMain.Outline; // 伝票摘要
            depsitMainWork.BankCode = searchDepsitMain.BankCode; // 銀行コード
            depsitMainWork.BankName = searchDepsitMain.BankName; // 銀行名称

            work = depsitMainWork;

            for (int i = 0; i < searchDepsitMain.DepositRowNo.Length; i++)
            {
                DepsitDtlWork depsitDtlWork = new DepsitDtlWork();
                depsitDtlWork.DepositRowNo = searchDepsitMain.DepositRowNo[i]; // 入金行番号
                depsitDtlWork.MoneyKindCode = searchDepsitMain.MoneyKindCode[i]; // 金種コード
                depsitDtlWork.MoneyKindName = searchDepsitMain.MoneyKindName[i]; // 金種名称
                depsitDtlWork.MoneyKindDiv = searchDepsitMain.MoneyKindDiv[i]; // 金種区分
                depsitDtlWork.Deposit = searchDepsitMain.DepositDtl[i]; // 入金金額
                depsitDtlWork.ValidityTerm = searchDepsitMain.ValidityTerm[i]; // 有効期限
                depsitDtlWorkArray[i] = depsitDtlWork;
            }

            DepsitDataUtil.Union(out depsitDataWork, depsitMainWork, depsitDtlWorkArray);

            return depsitDataWork;
        }

        /// <summary>
        /// 入金引当データのワーク型へ変換します。
        /// </summary>
        /// <param name="src">入金引当データ</param>
        /// <returns>入金引当データのワーク型</returns>
        public static DepositAlwWork ConvertWork(SearchDepositAlw src)
        {
            DepositAlwWork work = new DepositAlwWork();
            {
                work.AcptAnOdrStatus = src.AcptAnOdrStatus;
                work.AddUpSecCode = src.AddUpSecCode;
                work.CustomerCode = src.CustomerCode;
                work.CustomerName = src.CustomerName;
                work.CustomerName2 = src.CustomerName2;
                work.DebitNoteOffSetCd = src.DebitNoteOffSetCd;
                work.DepositAgentCode = src.DepositAgentCode;
                work.DepositAgentNm = src.DepositAgentNm;
                work.DepositAllowance = src.DepositAllowance;
                work.DepositSlipNo = src.DepositSlipNo;
                work.EnterpriseCode = src.EnterpriseCode;
                work.FileHeaderGuid = src.FileHeaderGuid;
                work.InputDepositSecCd = src.InputDepositSecCd;
                work.LogicalDeleteCode = src.LogicalDeleteCode;
                work.ReconcileAddUpDate = src.ReconcileAddUpDate;
                work.ReconcileDate = src.ReconcileDate;
                work.SalesSlipNum = src.SalesSlipNum;
                work.UpdAssemblyId1 = src.UpdAssemblyId1;
                work.UpdAssemblyId2 = src.UpdAssemblyId2;
                work.UpdateDateTime = src.UpdateDateTime;
                work.UpdEmployeeCode = src.UpdEmployeeCode;
            }
            return work;
        }

        #endregion // </売伝 I/O Writer の入金系パラメータ関連>

        #region <売上データの算出関連>

        // PMMIT01012AC.cs
        /// <summary>
        /// 検索見積用初期値取得アクセスクラスのレプリカ
        /// </summary>
        private class EstimateInputInitDataAcs
        {

            #region <企業コード>

            /// <summary>企業コード</summary>
            private readonly string _enterpriseCode;
            /// <summary>企業コードを取得します。</summary>
            private string EnterpriseCode { get { return _enterpriseCode; } }

            #endregion // </企業コード>

            #region <拠点コード>

            /// <summary>拠点コード</summary>
            private readonly string _sectionCode;
            /// <summary>拠点コードを取得します。</summary>
            public string SectionCode { get { return _sectionCode; } }

            #endregion // </拠点コード>

            #region <Constructor>

            /// <summary>
            /// カスタムコンストラクタ
            /// </summary>
            /// <param name="enterpriseCode">企業コード</param>
            /// <param name="sectionCode">拠点コード</param>
            public EstimateInputInitDataAcs(
                string enterpriseCode,
                string sectionCode
            )
            {
                _enterpriseCode = enterpriseCode;
                _sectionCode    = sectionCode;
            }

            #endregion // </Constructor>

            /// <summary>端数処理対象金額区分（消費税）</summary>
            public const int ctFracProcMoneyDiv_Tax = 1;
            /// <summary>端数処理対象金額区分（単価）</summary>
            public const int ctFracProcMoneyDiv_UnitPrice = 2;

            /// <summary>売上金額処理区分設定リスト</summary>
            private List<SalesProcMoney> _salesProcMoneyList;
            /// <summary>売上金額処理区分設定リストのレプリカを取得します。</summary>
            private List<SalesProcMoney> SalesProcMoneyList
            {
                get
                {
                    if (_salesProcMoneyList == null)
                    {
                        _salesProcMoneyList = (List<SalesProcMoney>)SalesProcMoneyServer.Singleton.Instance.Find(
                            EnterpriseCode
                        );
                    }
                    return _salesProcMoneyList;
                }
            }

            // PMMIT01012AC.cs 1314行目
            #region ■売上金額処理区分設定マスタ データ取得処理関連

            /// <summary>
            /// 売上金額処理区分設定マスタより、対象金額に該当する端数処理単位、端数処理コードを取得します。
            /// </summary>
            /// <param name="fracProcMoneyDiv">端数処理対象金額区分</param>
            /// <param name="fractionProcCode">端数処理コード</param>
            /// <param name="price">対象金額</param>
            /// <param name="fractionProcUnit">端数処理単位</param>
            /// <param name="fractionProcCd">端数処理区分</param>
            public void GetSalesFractionProcInfo(
                int fracProcMoneyDiv,
                int fractionProcCode,
                double price,
                out double fractionProcUnit,
                out int fractionProcCd
            )
            {
                //デフォルト
                switch (fracProcMoneyDiv)
                {
                    case ctFracProcMoneyDiv_UnitPrice:	// 単価
                        fractionProcUnit = 0.01;
                        break;
                    default:
                        fractionProcUnit = 1;			// 単価以外は1円単位
                        break;
                }
                fractionProcCd = 1;     // 切捨て

                if (SalesProcMoneyList == null || SalesProcMoneyList.Count == 0) return;

                List<SalesProcMoney> salesProcMoneyList = SalesProcMoneyList.FindAll(
                                            delegate(SalesProcMoney salesProcMoney)
                                            {
                                                if ((salesProcMoney.FracProcMoneyDiv == fracProcMoneyDiv) &&
                                                    (salesProcMoney.FractionProcCode == fractionProcCode) &&
                                                    (salesProcMoney.UpperLimitPrice >= price))
                                                {
                                                    return true;
                                                }
                                                else
                                                {
                                                    return false;
                                                }
                                            });
                if (salesProcMoneyList != null && salesProcMoneyList.Count > 0)
                {
                    fractionProcUnit = salesProcMoneyList[0].FractionProcUnit;
                    fractionProcCd = salesProcMoneyList[0].FractionProcCd;
                }
            }

            #endregion
        }

        /// <summary>検索見積用初期値取得アクセスクラス</summary>
        private EstimateInputInitDataAcs _estimateInputInitDataAcs;
        /// <summary>検索見積用初期値取得アクセスクラスのレプリカを取得します。</summary>
        private EstimateInputInitDataAcs EstimateInputInitDataAcsReplica
        {
            get
            {
                if (_estimateInputInitDataAcs == null)
                {
                    _estimateInputInitDataAcs = new EstimateInputInitDataAcs(EnterpriseCode, SectionCode);
                }
                return _estimateInputInitDataAcs;
            }
        }

        // PMMIT01012AA.cs 6202行目 EstimateInputAcs.CalculationSalesTotalPrice()
        /// <summary>
        /// 売上金額の合計を計算します。
        /// </summary>
        /// <param name="salesDetailList">売上明細データリスト</param>
        /// <param name="consTaxRate">消費税税率</param>
        /// <param name="fractionProcCd">消費税端数処理コード</param>
        /// <param name="totalAmountDispWayCd">総額表示方法区分</param>
        /// <param name="consTaxLayMethod">消費税転嫁方式</param>
        /// 
        /// <param name="salesTotalTaxInc">売上伝票合計（税込）</param>
        /// <param name="salesTotalTaxExc">売上伝票合計（税抜）</param>
        /// <param name="salesSubtotalTax">売上小計（税）</param>
        /// <param name="itdedSalesOutTax">売上外税対象額</param>
        /// <param name="itdedSalesInTax">売上内税対象額</param>
        /// <param name="salSubttlSubToTaxFre">売上小計非課税対象額</param>
        /// <param name="salesOutTax">売上金額消費税額（外税）</param>
        /// <param name="salAmntConsTaxInclu">売上金額消費税額（内税）</param>
        /// <param name="salesDisTtlTaxExc">売上値引金額計（税抜）</param>
        /// <param name="itdedSalesDisOutTax">売上値引外税対象額合計</param>
        /// <param name="itdedSalesDisInTax">売上値引内税対象額合計</param>
        /// <param name="itdedSalesDisTaxFre">売上値引非課税対象額合計</param>
        /// <param name="salesDisOutTax">売上値引消費税額（外税）</param>
        /// <param name="salesDisTtlTaxInclu">売上値引消費税額（内税）</param>
        /// <param name="totalCost">原価金額計</param>
        /// 
        /// <param name="stockGoodsTtlTaxExc">在庫商品合計金額(税抜)</param>
        /// <param name="pureGoodsTtlTaxExc">純正商品合計金額(税抜)</param>
        /// <param name="balanceAdjust">消費税調整額</param>
        /// <param name="taxAdjust">残高調整額</param>
        /// 
        /// <param name="salesPrtSubttlInc">売上部品小計（税込）</param>
        /// <param name="salesPrtSubttlExc">売上部品小計（税抜）</param>
        /// <param name="salesWorkSubttlInc">売上作業小計（税込）</param>
        /// <param name="salesWorkSubttlExc">売上作業小計（税抜）</param>
        /// <param name="itdedPartsDisInTax">部品値引対象額合計（税込）</param>
        /// <param name="itdedPartsDisOutTax">部品値引対象額合計（税抜）</param>
        /// <param name="itdedWorkDisInTax">作業値引対象額合計（税込）</param>
        /// <param name="itdedWorkDisOutTax">作業値引対象額合計（税抜）</param>
        /// 
        /// <param name="totalMoneyForGrossProfit">粗利計算用売上金額</param>
        public void CalculationSalesTotalPrice(
            List<SalesDetail> salesDetailList,
            double consTaxRate,
            int fractionProcCd,
            int totalAmountDispWayCd,
            int consTaxLayMethod,
            // --- DEL 2013/08/07 T.Yoshioka №10556 ---------->>>>>
            #region 旧ソース
            //// --- ADD 2013/08/07 Y.Wakita ---------->>>>>
            //string enterpriseCode,
            //int customerCode,

            //out int taxFracProcCd,
            //// --- ADD 2013/08/07 Y.Wakita ----------<<<<<
            #endregion
            // --- DEL 2013/08/07 T.Yoshioka №10556 ----------<<<<<
            out long salesTotalTaxInc,
            out long salesTotalTaxExc,
            out long salesSubtotalTax,
            out long itdedSalesOutTax,
            out long itdedSalesInTax,
            out long salSubttlSubToTaxFre,
            out long salesOutTax,
            out long salAmntConsTaxInclu,
            out long salesDisTtlTaxExc,
            out long itdedSalesDisOutTax,
            out long itdedSalesDisInTax,
            out long itdedSalesDisTaxFre,
            out long salesDisOutTax,
            out long salesDisTtlTaxInclu,
            out long totalCost,

            out long stockGoodsTtlTaxExc,
            out long pureGoodsTtlTaxExc,
            out long balanceAdjust,
            out long taxAdjust,

            out long salesPrtSubttlInc,
            out long salesPrtSubttlExc,
            out long salesWorkSubttlInc,
            out long salesWorkSubttlExc,
            out long itdedPartsDisInTax,
            out long itdedPartsDisOutTax,
            out long itdedWorkDisInTax,
            out long itdedWorkDisOutTax,

            out long totalMoneyForGrossProfit
        )
        {
            // --- DEL 2013/08/07 T.Yoshioka №10556 ---------->>>>>
            #region 旧ソース
            //// --- ADD 2013/08/07 Y.Wakita ---------->>>>>
            //// 得意先マスタから消費税端数処理情報を取得
            //CustomerInfoAcs customerInfoAcs = new CustomerInfoAcs();
            //// 消費税端数処理
            //int salesCnsTaxFrcProcCd = customerInfoAcs.GetSalesFractionProcCd(
            //    enterpriseCode,
            //    customerCode,
            //    CustomerInfoAcs.FracProcMoneyDiv.CnsTaxFrcProcCd
            //);
            //// --- ADD 2013/08/07 Y.Wakita ----------<<<<<
            #endregion
            // --- DEL 2013/08/07 T.Yoshioka №10556 ----------<<<<<

            // 消費税端数処理単位、端数処理区分を取得
            // --- UPD 2013/08/07 T.Yoshioka №10556 ---------->>>>>
            #region 旧ソース
            //// --- DEL 2013/08/07 Y.Wakita ---------->>>>>
            ////int taxFracProcCd = 0;
            //// --- DEL 2013/08/07 Y.Wakita ----------<<<<<
            //double taxFracProcUnit = 0;
            //EstimateInputInitDataAcsReplica.GetSalesFractionProcInfo(
            //    EstimateInputInitDataAcs.ctFracProcMoneyDiv_Tax,
            //    // --- ADD 2013/08/07 Y.Wakita ---------->>>>>
            //    //fractionProcCd,
            //    salesCnsTaxFrcProcCd,
            //    // --- ADD 2013/08/07 Y.Wakita ----------<<<<<
            //    0,
            //    out taxFracProcUnit,
            //    out taxFracProcCd
            //);
            int taxFracProcCd = 0;
            double taxFracProcUnit = 0;
            EstimateInputInitDataAcsReplica.GetSalesFractionProcInfo(
                EstimateInputInitDataAcs.ctFracProcMoneyDiv_Tax,
                fractionProcCd,
                0,
                out taxFracProcUnit,
                out taxFracProcCd
            );
            #endregion
            // --- UPD 2013/08/07 T.Yoshioka №10556 ----------<<<<<

            salesTotalTaxInc = 0;       // 売上伝票合計（税込）
            salesTotalTaxExc = 0;       // 売上伝票合計（税抜）
            salesSubtotalTax = 0;       // 売上小計（税）
            itdedSalesOutTax = 0;       // 売上外税対象額
            itdedSalesInTax = 0;        // 売上内税対象額
            salSubttlSubToTaxFre = 0;   // 売上小計非課税対象額
            salesOutTax = 0;            // 売上金額消費税額（外税）
            salAmntConsTaxInclu = 0;    // 売上金額消費税額（内税）
            salesDisTtlTaxExc = 0;      // 売上値引金額計（税抜）
            itdedSalesDisOutTax = 0;    // 売上値引外税対象額合計
            itdedSalesDisInTax = 0;     // 売上値引内税対象額合計
            itdedSalesDisTaxFre = 0;    // 売上値引非課税対象額合計
            salesDisOutTax = 0;         // 売上値引消費税額（外税）
            salesDisTtlTaxInclu = 0;    // 売上値引消費税額（内税）
            stockGoodsTtlTaxExc = 0;    // 在庫商品合計金額（税抜）
            pureGoodsTtlTaxExc = 0;     // 純正商品合計金額（税抜）
            totalCost = 0;              // 原価金額計
            taxAdjust = 0;              // 消費税調整額
            balanceAdjust = 0;          // 残高調整額
            salesPrtSubttlInc = 0;      // 売上部品小計（税込）
            salesPrtSubttlExc = 0;      // 売上部品小計（税抜）
            salesWorkSubttlInc = 0;     // 売上作業小計（税込）
            salesWorkSubttlExc = 0;     // 売上作業小計（税抜）
            itdedPartsDisInTax = 0;     // 部品値引対象額合計（税込）
            itdedPartsDisOutTax = 0;    // 部品値引対象額合計（税抜）
            itdedWorkDisInTax = 0;      // 作業値引対象額合計（税込）
            itdedWorkDisOutTax = 0;     // 作業値引対象額合計（税抜）
            totalMoneyForGrossProfit = 0; // 粗利計算用売上金額

            long itdedSalesInTax_TaxInc = 0;    // 売上内税対象額（税込）
            long itdedSalesDisInTax_TaxInc = 0; // 売上値引内税対象額合計（税込）
            long totalMoney_TaxInc_ForGrossProfitMoney = 0;     // 粗利計算用売上金額計（内税商品分）
            long totalMoney_TaxExc_ForGrossProfitMoney = 0;     // 粗利計算用売上金額計（外税商品分）
            long totalMoney_TaxNone_ForGrossProfitMoney = 0;    // 粗利計算用売上金額計（非課税商品分）
            long stockGoodsTtlTaxExc_TaxInc = 0;                // 在庫商品合計金額（税抜）（内税商品分）
            long stockGoodsTtlTaxExc_TaxExc = 0;                // 在庫商品合計金額（税抜）（外税商品分）
            long stockGoodsTtlTaxExc_TaxNone = 0;               // 在庫商品合計金額（税抜）（非課税商品分）
            long pureGoodsTtlTaxExc_TaxInc = 0;                 // 純正商品合計金額（税抜）（内税商品分）
            long pureGoodsTtlTaxExc_TaxExc = 0;                 // 純正商品合計金額（税抜）（外税商品分）
            long pureGoodsTtlTaxExc_TaxNone = 0;                // 純正商品合計金額（税抜）（非課税商品分）

            //-----------------------------------------------------------------------------
            // 計算に必要な金額の計算
            //-----------------------------------------------------------------------------
            #region ●計算に必要な金額の計算

            foreach (SalesDetail salesDetail in salesDetailList)
            {
                // 売上伝票区分（明細）によって集計方法が変わる分
                switch (salesDetail.SalesSlipCdDtl)
                {
                    // 売上、返品
                    case (int)SalesSlipInputAcs.SalesSlipCdDtl.Sales:
                    case (int)SalesSlipInputAcs.SalesSlipCdDtl.RetGoods:
                        {
                            // 税区分：外税
                            if (salesDetail.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxExc)
                            {
                                // 売上外税対象額
                                itdedSalesOutTax += salesDetail.SalesMoneyTaxExc;

                                // 売上金額消費税額（外税）
                                salesOutTax += salesDetail.SalesPriceConsTax;

                                // 在庫商品合計金額（税抜）（外税商品分）
                                if (salesDetail.SalesOrderDivCd == (int)SalesSlipInputAcs.SalesOrderDivCd.Stock)
                                    stockGoodsTtlTaxExc_TaxExc += salesDetail.SalesMoneyTaxExc;

                                // 純正商品合計金額（税抜）（外税商品分）
                                if (salesDetail.GoodsKindCode == 0)
                                    pureGoodsTtlTaxExc_TaxExc += salesDetail.SalesMoneyTaxExc;
                            }
                            // 税区分：内税
                            if (salesDetail.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxInc)
                            {
                                // 売上内税対象額
                                itdedSalesInTax += salesDetail.SalesMoneyTaxExc;

                                // 売上内税対象額（税込）
                                itdedSalesInTax_TaxInc += salesDetail.SalesMoneyTaxInc;

                                // 売上金額消費税額（内税）
                                salAmntConsTaxInclu += salesDetail.SalesPriceConsTax;

                                // 在庫商品合計金額（税抜）（内税商品分）
                                if (salesDetail.SalesOrderDivCd == (int)SalesSlipInputAcs.SalesOrderDivCd.Stock)
                                    stockGoodsTtlTaxExc_TaxInc += salesDetail.SalesMoneyTaxExc;

                                // 純正商品合計金額（税抜）（内税商品分）
                                if (salesDetail.GoodsKindCode == 0)
                                    pureGoodsTtlTaxExc_TaxInc += salesDetail.SalesMoneyTaxExc;

                            }
                            // 税区分：非課税
                            if (salesDetail.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxNone)
                            {
                                // 売上小計非課税対象額
                                salSubttlSubToTaxFre += salesDetail.SalesMoneyTaxInc;

                                // 在庫商品合計金額（税抜）（非課税商品分）
                                if (salesDetail.SalesOrderDivCd == (int)SalesSlipInputAcs.SalesOrderDivCd.Stock)
                                    stockGoodsTtlTaxExc_TaxNone += salesDetail.SalesMoneyTaxExc;

                                // 純正商品合計金額（税抜）（非課税商品分）
                                if (salesDetail.GoodsKindCode == 0)
                                    pureGoodsTtlTaxExc_TaxNone += salesDetail.SalesMoneyTaxExc;
                            }

                            // 売上部品小計（税込）
                            salesPrtSubttlInc += salesDetail.SalesMoneyTaxInc;
                            // 売上部品小計（税抜）
                            salesPrtSubttlExc += salesDetail.SalesMoneyTaxExc;

                            // 原価金額計
                            totalCost += salesDetail.Cost;

                            // 粗利計算用売上金額計（内税商品分）
                            if (salesDetail.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxInc)
                            {
                                totalMoney_TaxInc_ForGrossProfitMoney += salesDetail.SalesMoneyTaxInc;
                            }

                            // 粗利計算用売上金額計（外税商品分）
                            if (salesDetail.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxExc)
                            {
                                totalMoney_TaxExc_ForGrossProfitMoney += salesDetail.SalesMoneyTaxExc;
                            }

                            // 粗利計算用売上金額計（非課税商品分）
                            if (salesDetail.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxNone)
                            {
                                totalMoney_TaxNone_ForGrossProfitMoney += salesDetail.SalesMoneyTaxExc;
                            }

                            break;
                        }
                    // 値引き
                    case (int)SalesSlipInputAcs.SalesSlipCdDtl.Discount:
                        {
                            // 税区分：外税
                            if (salesDetail.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxExc)
                            {
                                // 売上値引外税対象額合計
                                itdedSalesDisOutTax += salesDetail.SalesMoneyTaxExc;
                                // 売上値引消費税額（外税）
                                salesDisOutTax += salesDetail.SalesPriceConsTax;

                                // 商品値引きの場合
                                if (salesDetail.ShipmentCnt != 0)
                                {
                                    // 在庫商品合計金額（税抜）（外税商品分）
                                    if (salesDetail.SalesOrderDivCd == (int)SalesSlipInputAcs.SalesOrderDivCd.Stock)
                                        stockGoodsTtlTaxExc_TaxExc += salesDetail.SalesMoneyTaxExc;

                                    // 純正商品合計金額（税抜）（外税商品分）
                                    if (salesDetail.GoodsKindCode == 0)
                                        pureGoodsTtlTaxExc_TaxExc += salesDetail.SalesMoneyTaxExc;
                                }
                            }
                            // 税区分：内税
                            if (salesDetail.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxInc)
                            {
                                // 売上値引内税対象額合計
                                itdedSalesDisInTax += salesDetail.SalesMoneyTaxExc;
                                // 売上値引内税対象額合計（税込）
                                itdedSalesDisInTax_TaxInc += salesDetail.SalesMoneyTaxInc;
                                // 売上値引消費税額（内税）
                                salesDisTtlTaxInclu += salesDetail.SalesPriceConsTax;

                                // 商品値引きの場合
                                if (salesDetail.ShipmentCnt != 0)
                                {
                                    // 在庫商品合計金額（税抜）（内税商品分）
                                    if (salesDetail.SalesOrderDivCd == (int)SalesSlipInputAcs.SalesOrderDivCd.Stock)
                                        stockGoodsTtlTaxExc_TaxInc += salesDetail.SalesMoneyTaxExc;

                                    // 純正商品合計金額（税抜）（内税商品分）
                                    if (salesDetail.GoodsKindCode == 0)
                                        pureGoodsTtlTaxExc_TaxInc += salesDetail.SalesMoneyTaxExc;
                                }
                            }
                            // 税区分：非課税
                            if (salesDetail.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxNone)
                            {
                                // 売上値引非課税対象額合計
                                itdedSalesDisTaxFre += salesDetail.SalesMoneyTaxInc;

                                // 商品値引きの場合
                                if (salesDetail.ShipmentCnt != 0)
                                {
                                    // 在庫商品合計金額（税抜）（非課税商品分）
                                    if (salesDetail.SalesOrderDivCd == (int)SalesSlipInputAcs.SalesOrderDivCd.Stock)
                                        stockGoodsTtlTaxExc_TaxNone += salesDetail.SalesMoneyTaxExc;

                                    // 純正商品合計金額（税抜）（非課税商品分）
                                    if (salesDetail.GoodsKindCode == 0)
                                        pureGoodsTtlTaxExc_TaxNone += salesDetail.SalesMoneyTaxExc;

                                }
                            }

                            // 部品値引対象額合計（税込）
                            itdedPartsDisInTax += salesDetail.SalesMoneyTaxInc;

                            // 部品値引対象額合計（税抜）
                            itdedPartsDisOutTax += salesDetail.SalesMoneyTaxExc;

                            // 原価金額計
                            totalCost += salesDetail.Cost;

                            // 粗利計算用売上金額計（内税商品分）
                            if (salesDetail.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxInc)
                            {
                                totalMoney_TaxInc_ForGrossProfitMoney += salesDetail.SalesMoneyTaxInc;
                            }

                            // 粗利計算用売上金額計（外税商品分）
                            if (salesDetail.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxExc)
                            {
                                totalMoney_TaxExc_ForGrossProfitMoney += salesDetail.SalesMoneyTaxExc;
                            }

                            // 粗利計算用売上金額計（非課税商品分）
                            if (salesDetail.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxNone)
                            {
                                totalMoney_TaxNone_ForGrossProfitMoney += salesDetail.SalesMoneyTaxExc;
                            }

                            break;
                        }
                    // 注釈
                    case (int)SalesSlipInputAcs.SalesSlipCdDtl.Annotation:
                        {
                            break;
                        }
                    // 作業
                    case (int)SalesSlipInputAcs.SalesSlipCdDtl.Work:
                        {
                            // 原価金額計
                            totalCost += salesDetail.Cost;

                            // 粗利計算用売上金額計（内税商品分）
                            if (salesDetail.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxInc)
                            {
                                totalMoney_TaxInc_ForGrossProfitMoney += salesDetail.SalesMoneyTaxInc;
                            }

                            // 粗利計算用売上金額計（外税商品分）
                            if (salesDetail.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxExc)
                            {
                                totalMoney_TaxExc_ForGrossProfitMoney += salesDetail.SalesMoneyTaxExc;
                            }

                            // 粗利計算用売上金額計（非課税商品分）
                            if (salesDetail.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxNone)
                            {
                                totalMoney_TaxNone_ForGrossProfitMoney += salesDetail.SalesMoneyTaxExc;
                            }
                            break;
                        }
                    // 小計
                    case (int)SalesSlipInputAcs.SalesSlipCdDtl.Subtotal:
                        {
                            break;
                        }
                }

                if (salesDetail.SalesSlipCdDtl != (int)SalesSlipInputAcs.SalesSlipCdDtl.Subtotal)
                {
                    // 残高調整額
                    if ((salesDetail.SalesGoodsCd == (int)SalesSlipInputAcs.SalesGoodsCd.BalanceAdjust) ||
                        (salesDetail.SalesGoodsCd == (int)SalesSlipInputAcs.SalesGoodsCd.AccRecBalanceAdjust))
                    {
                        balanceAdjust += salesDetail.SalesMoneyTaxInc;
                    }

                    // 消費税調整額
                    if ((salesDetail.SalesGoodsCd == (int)SalesSlipInputAcs.SalesGoodsCd.ConsTaxAdjust) ||
                        (salesDetail.SalesGoodsCd == (int)SalesSlipInputAcs.SalesGoodsCd.AccRecConsTaxAdjust))
                    {
                        taxAdjust += salesDetail.SalesPriceConsTax;
                    }
                }
            }

            // 売上値引金額計（税抜）
            salesDisTtlTaxExc = itdedSalesDisOutTax + itdedSalesDisInTax + itdedSalesDisTaxFre;

            // 粗利計算用売上金額計
            totalMoneyForGrossProfit = totalMoney_TaxExc_ForGrossProfitMoney + totalMoney_TaxInc_ForGrossProfitMoney + totalMoney_TaxNone_ForGrossProfitMoney;

            // 在庫商品合計金額（税抜）
            stockGoodsTtlTaxExc = stockGoodsTtlTaxExc_TaxInc + stockGoodsTtlTaxExc_TaxExc + stockGoodsTtlTaxExc_TaxNone;

            // 純正商品合計金額（税抜）
            pureGoodsTtlTaxExc = pureGoodsTtlTaxExc_TaxInc + pureGoodsTtlTaxExc_TaxExc + pureGoodsTtlTaxExc_TaxNone;

            #endregion

            #region ●転嫁方式：非課税の場合に金額を調整する
            //-----------------------------------------------------------------------------
            // 転嫁方式：非課税の場合に金額を調整する
            //-----------------------------------------------------------------------------
            if (consTaxLayMethod == 9)
            {
                // 売上金額消費税額（外税）
                salesOutTax = 0;

                // 売上金額消費税額（内税）
                salAmntConsTaxInclu = 0;

                // 売上小計非課税対象額
                salSubttlSubToTaxFre += itdedSalesOutTax + itdedSalesInTax;

                // 売上外税対象額
                itdedSalesOutTax = 0;

                // 売上内税対象額
                itdedSalesInTax = 0;

                // 売上内税対象額（税込）
                itdedSalesInTax_TaxInc = 0;

                // 売上値引消費税額（外税）
                salesDisOutTax = 0;

                // 売上値引消費税額（内税）
                salesDisTtlTaxInclu = 0;

                // 売上値引非課税対象額合計
                itdedSalesDisTaxFre += itdedSalesDisOutTax + itdedSalesDisInTax;

                // 売上値引外税対象額合計
                itdedSalesDisOutTax = 0;

                // 売上値引内税対象額合計
                itdedSalesDisInTax = 0;

                // 売上値引内税対象額合計（税込）
                itdedSalesDisInTax_TaxInc = 0;

                // 売上値引金額計（税抜）
                salesDisTtlTaxExc = itdedSalesDisOutTax + itdedSalesDisInTax + itdedSalesDisTaxFre;
            }
            #endregion

            #region ●各種金額算出
            //-----------------------------------------------------------------------------
            // 各種金額算出
            //-----------------------------------------------------------------------------

            // 明細転嫁以外
            if (consTaxLayMethod != 1)
            {
                //-----------------------------------------------------------------------------
                // ① 売上伝票合計（税抜）：売上外税対象額 + 売上内税対象額 + 売上値引外税対象額合計 + 売上値引内税対象額合計 + 売上値引非課税対象額合計
                //-----------------------------------------------------------------------------
                salesTotalTaxExc = itdedSalesOutTax + itdedSalesInTax + itdedSalesDisOutTax + itdedSalesDisInTax + itdedSalesDisTaxFre;

                //-----------------------------------------------------------------------------
                // ② 売上伝票合計（税込）： 売上内税対象額（税込） + 売上外税対象額 + 売上値引内税対象額合計（税込） + 売上値引外税対象額合計 + 売上値引非課税対象額合計 + (売上外税対象額 + 売上値引外税対象額合計)×税率)
                //-----------------------------------------------------------------------------
                salesTotalTaxInc = itdedSalesInTax_TaxInc + itdedSalesOutTax + itdedSalesDisInTax_TaxInc + itdedSalesDisOutTax + itdedSalesDisTaxFre + CalculateTax.GetTaxFromPriceExc(consTaxRate, taxFracProcUnit, taxFracProcCd, itdedSalesOutTax + itdedSalesDisOutTax);

                //-----------------------------------------------------------------------------
                // ③ 売上小計（税）：② - ①
                //-----------------------------------------------------------------------------
                salesSubtotalTax = salesTotalTaxInc - salesTotalTaxExc;

                //-----------------------------------------------------------------------------
                // ④ 売上金額消費税額（外税）：売上外税対象額 × 税率
                //-----------------------------------------------------------------------------
                salesOutTax = CalculateTax.GetTaxFromPriceExc(consTaxRate, taxFracProcUnit, taxFracProcCd, itdedSalesOutTax);

                //-----------------------------------------------------------------------------
                // ⑤ 売上金額消費税額（外税）(税抜、値引き含む) ：(売上外税対象額 + 売上値引外税対象額合計) × 税率
                //-----------------------------------------------------------------------------
                long salesOutTax_All = CalculateTax.GetTaxFromPriceExc(consTaxRate, taxFracProcUnit, taxFracProcCd, itdedSalesOutTax + itdedSalesDisOutTax);

                //-----------------------------------------------------------------------------
                // ⑥ 売上値引消費税額（外税）：④ - ⑤
                //-----------------------------------------------------------------------------
                salesDisOutTax = salesOutTax_All - salesOutTax;

                // 2009.03.25 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                //-----------------------------------------------------------------------------
                // ⑦ 売上部品小計（税込）：(売上部品小計（税抜）+ 部品値引対象額合計（税抜）) × 税率
                //-----------------------------------------------------------------------------
                salesPrtSubttlInc = salesPrtSubttlExc + itdedPartsDisOutTax + CalculateTax.GetTaxFromPriceExc(consTaxRate, taxFracProcUnit, taxFracProcCd, salesPrtSubttlExc + itdedPartsDisOutTax);

                //-----------------------------------------------------------------------------
                // ⑧ 部品値引対象額合計（税込）：部品値引対象額合計（税抜）× 税率
                //-----------------------------------------------------------------------------
                itdedPartsDisInTax = itdedPartsDisOutTax + CalculateTax.GetTaxFromPriceExc(consTaxRate, taxFracProcUnit, taxFracProcCd, itdedPartsDisOutTax);
                // 2009.03.25 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
            }
            // 明細転嫁
            else
            {
                //-----------------------------------------------------------------------------
                // ① 売上小計（税）：売上金額消費税額（外税） + 売上金額消費税額（内税） +  売上値引消費税額（外税） + 売上値引消費税額（内税）
                //-----------------------------------------------------------------------------
                salesSubtotalTax = salesOutTax + salAmntConsTaxInclu + salesDisOutTax + salesDisTtlTaxInclu;

                //-----------------------------------------------------------------------------
                // ② 売上伝票合計（税抜）：売上外税対象額 + 売上内税対象額 + 売上値引外税対象額合計 + 売上値引内税対象額合計
                //-----------------------------------------------------------------------------
                salesTotalTaxExc = itdedSalesOutTax + itdedSalesInTax + itdedSalesDisOutTax + itdedSalesDisInTax;

                //-----------------------------------------------------------------------------
                // ③ 売上伝票合計（税込）：① + ②
                //-----------------------------------------------------------------------------
                salesTotalTaxInc = salesTotalTaxExc + salesSubtotalTax;
            }
            #endregion
        }

        #endregion // </売上データの算出関連>

        // MAHNB01012AB.cs 1310行目より移植
        /// <summary>
        /// 倉庫リスト位置指定追加処理
        /// </summary>
        /// <param name="sectWarehouseCdList"></param>
        /// <param name="targetCode"></param>
        /// <param name="index"></param>
        /// <remarks>indexがリスト件数を超える場合、最終に追加</remarks>
        public static List<string> AddWarehouseList(List<string> sectWarehouseCdList, string targetCode, int index)
        {
            // 設定コード不正な場合
            if ((targetCode == null) || (targetCode.Trim() == string.Empty)) return sectWarehouseCdList;

            List<string> warehouseList = new List<string>();

            // 指定Indexがリスト件数を超えた場合
            if (sectWarehouseCdList.Count - 1 < index)
            {
                warehouseList.AddRange(sectWarehouseCdList);
                warehouseList.Add(targetCode.Trim());
                return warehouseList;
            }

            int sectIndex = 0;

            for (int i = 0; i < sectWarehouseCdList.Count + 1; i++)
            {
                if (i == index)
                {
                    warehouseList.Add(targetCode.Trim());
                }
                else
                {
                    warehouseList.Add(sectWarehouseCdList[sectIndex]);
                    sectIndex++;
                }
            }
            return warehouseList;
        }

        // ADD 2010/04/05 以前に見積伝票データを作成している発注の場合、作成する回答データおよび売上伝票データは見積伝票データを元に作成する ---------->>>>>
        #region <見積計上関連>

        /// <summary>固定売上明細通番</summary>
        private const long SALES_SLIP_DTL_NUM = 0;

        // MAHNB01012AA.cs 7789行目(public int SalesDetailRowSettingFromSalHisRefResultParamWorkList(...))より移植
        /// <summary>
        /// 売上明細データを検索します。
        /// </summary>
        /// <param name="acptAnOdrStatus">受注ステータス</param>
        /// <param name="salesSlipNum">売上伝票番号</param>
        /// <param name="salesRowNo">行番号</param>
        /// <returns>売上明細データ(第1メンバ)など</returns>
        public SalesDetailTuple SearchSalesDetail(
            int acptAnOdrStatus,
            string salesSlipNum,
            int salesRowNo
        )
        {
            //---------------------------------------------------
            // 売上データ読込パラメータセット
            //---------------------------------------------------
            CustomSerializeArrayList paraList = new CustomSerializeArrayList();
            {
                SalesDetailWork salesDetailWork = new SalesDetailWork();
                {
                    salesDetailWork.EnterpriseCode  = EnterpriseCode;       // 企業コード
                    salesDetailWork.AcptAnOdrStatus = acptAnOdrStatus;      // 受注ステータス
                    salesDetailWork.SalesSlipNum    = salesSlipNum;         // 売上伝票番号
                    salesDetailWork.SalesSlipDtlNum = SALES_SLIP_DTL_NUM;   // 売上明細通番
                    salesDetailWork.SalesRowNo = salesRowNo;                // 売上行番号

                    paraList.Add(salesDetailWork);
                }
            }

            #region ●リモート参照用パラメータ
            //------------------------------------------------------
            // リモート参照用パラメータ
            //------------------------------------------------------
            IOWriteCtrlOptWork iOWriteCtrlOptWork = new IOWriteCtrlOptWork();           // リモート参照用パラメータ
            SettingIOWriteCtrlOptWork(OptWorkSettingType.Read, out iOWriteCtrlOptWork); // リモート参照用パラメータ設定処理
            paraList.Add(iOWriteCtrlOptWork);
            #endregion

            object paraObj = (object)paraList;
            object retObj = null;
            object retObj2 = null;

            //---------------------------------------------------
            // 売上データ再読込
            //---------------------------------------------------
            IIOWriteControlDB ioWriteControlDB = (IIOWriteControlDB)MediationIOWriteControlDB.GetIOWriteControlDB();
            int status = ioWriteControlDB.ReadDetail(ref paraObj, out retObj, out retObj2);

            CustomSerializeArrayList retList = (CustomSerializeArrayList)retObj;
            CustomSerializeArrayList retList2= (CustomSerializeArrayList)retObj2;
            if (retList != null) status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                //---------------------------------------------------
                // データリスト分割
                //---------------------------------------------------
                SalesDetailWork[] salesDetailWorkArray;
                AcceptOdrCarWork[] acceptOdrCarWorkArray;
                StockSlipWork[] stockSlipWorkArray;
                StockDetailWork[] stockDetailWorkArray;
                UOEOrderDtlWork[] uoeOrderDtlWorkArray;
                DivisionSalesSlipCustomSerializeArrayList.DivisionCustomSerializeArrayListForDetailsReading(
                    retList,
                    retList2,
                    out salesDetailWorkArray,
                    out acceptOdrCarWorkArray,
                    out stockSlipWorkArray,
                    out stockDetailWorkArray,
                    out uoeOrderDtlWorkArray
                );
                return new SalesDetailTuple(
                    new List<SalesDetailWork>(salesDetailWorkArray ?? new SalesDetailWork[0]),
                    new List<AcceptOdrCarWork>(acceptOdrCarWorkArray ?? new AcceptOdrCarWork[0]),
                    new List<StockSlipWork>(stockSlipWorkArray ?? new StockSlipWork[0]),
                    new List<StockDetailWork>(stockDetailWorkArray ?? new StockDetailWork[0]),
                    new List<UOEOrderDtlWork>(uoeOrderDtlWorkArray ?? new UOEOrderDtlWork[0]),
                    new NullObject(),
                    new NullObject(),
                    new NullObject(),
                    new NullObject(),
                    new NullObject()
                );
            }

            return new SalesDetailTuple(
                new List<SalesDetailWork>(new SalesDetailWork[0]),
                new List<AcceptOdrCarWork>(new AcceptOdrCarWork[0]),
                new List<StockSlipWork>(new StockSlipWork[0]),
                new List<StockDetailWork>(new StockDetailWork[0]),
                new List<UOEOrderDtlWork>(new UOEOrderDtlWork[0]),
                new NullObject(),
                new NullObject(),
                new NullObject(),
                new NullObject(),
                new NullObject()
            );
        }

        // MAHNB01012AA.cs 611行目より移植
        /// <summary>
        /// リモート参照用パラメータ設定処理
        /// </summary>
        private enum OptWorkSettingType : int
        {
            /// <summary>登録</summary>
            Write = 0,
            /// <summary>読込</summary>
            Read = 1,
            /// <summary>削除</summary>
            Delete = 2,
        }

        // MAHNB01012AA.cs 17154行目より移植
        /// <summary>
        /// リモート参照用パラメータ設定処理
        /// </summary>
        /// <param name="optWorkSettinType"></param>
        /// <param name="iOWriteCtrlOptWork"></param>
        private void SettingIOWriteCtrlOptWork(OptWorkSettingType optWorkSettinType, out IOWriteCtrlOptWork iOWriteCtrlOptWork)
        {
            iOWriteCtrlOptWork = new IOWriteCtrlOptWork();
            {
                SalesTtlSt salesTtlSt = SalesTtlStServer.Singleton.Instance.Find(EnterpriseCode, SectionCode);
                if (salesTtlSt == null) return;

                iOWriteCtrlOptWork.CtrlStartingPoint = (int)IOWriteCtrlOptCtrlStartingPoint.Sales;                              // 制御起点(0:売上 1:仕入 2:仕入売上同時計上)
                iOWriteCtrlOptWork.AcpOdrrAddUpRemDiv = salesTtlSt.AcpOdrrAddUpRemDiv;  // 受注データ計上残区分(0:残す 1:残さない)
                iOWriteCtrlOptWork.ShipmAddUpRemDiv = salesTtlSt.ShipmAddUpRemDiv;      // 出荷データ計上残区分(0:残す 1:残さない)
                iOWriteCtrlOptWork.EstimateAddUpRemDiv = salesTtlSt.EstmateAddUpRemDiv; // 見積データ計上残区分(0:残す 1:残さない)
                iOWriteCtrlOptWork.RetGoodsStockEtyDiv = salesTtlSt.RetGoodsStockEtyDiv;// 返品時在庫登録区分
                iOWriteCtrlOptWork.RemainCntMngDiv = 0;                                                                         // 残数管理区分(0:する 固定とする)
                iOWriteCtrlOptWork.SupplierSlipDelDiv = salesTtlSt.SupplierSlipDelDiv;  // 仕入伝票削除区分
                iOWriteCtrlOptWork.CarMngDivCd = 0;                                     // 車両管理マスタ登録区分(0:登録しない 1:登録する)
            }
            switch (optWorkSettinType)
            {
                case OptWorkSettingType.Read:
                    break;
                default:
                    throw new NotSupportedException("売上伝票データの書込および削除処理は未サポートです。");
            }
        }

        #endregion // </見積計上関連>
        // ADD 2010/04/05 以前に見積伝票データを作成している発注の場合、作成する回答データおよび売上伝票データは見積伝票データを元に作成する ----------<<<<<
    }
}

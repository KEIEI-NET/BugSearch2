//****************************************************************************//
// システム         : 卸商仕入受信処理
// プログラム名称   : 卸商仕入受信処理Controller
// プログラム概要   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 工藤 恵優
// 作 成 日  2008/11/17  修正内容 : 新規作成
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Diagnostics;

using Broadleaf.Application.Common;
using Broadleaf.Application.Controller.Agent;
using Broadleaf.Application.Controller.Util;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Application.Controller
{
    using LoginWorkerAcs    = SingletonPolicy<LoginWorker>;
    using StockDB           = SingletonPolicy<StockDBAgent>;
    using OrderStockDataPair= KeyValuePair<ReceivedText>;
    using SupplierDB        = SingletonPolicy<SupplierDBAgent>;
    using AllDefSetDB       = SingletonPolicy<AllDefSetDBAgent>;
    using TaxRateSetDB      = SingletonPolicy<TaxRateSetDBAgent>;

    /// <summary>
    /// 発注情報の仕入データの構築者クラス
    /// </summary>
    public class OrderStockDataBuilder : OrderInformationBuilder
    {
        #region <進捗情報/>

        /// <summary>処理中のメッセージ</summary>
        protected const string NOW_RUNNING = "仕入データ(発注情報)を作成中";    // LITERAL:

        /// <summary>進捗情報</summary>
        private readonly UpdateProgressEventArgs _progressInfo = new UpdateProgressEventArgs(NOW_RUNNING, 0, 0);
        /// <summary>
        /// 進捗情報を取得します。
        /// </summary>
        protected UpdateProgressEventArgs ProgressInfo { get { return _progressInfo; } }

        #endregion  // <進捗情報/>

        #region <現在の発注情報の仕入データのレコード/>

        /// <summary>現在のUOE発注データのレコード</summary>
        private StockSlipWork _currentStockSlipRecord;
        /// <summary>
        /// 現在のUOE発注データのレコードのアクセサ
        /// </summary>
        /// <value>現在のUOE発注データのレコード</value>
        private StockSlipWork CurrentStockSlipRecord
        {
            get { return _currentStockSlipRecord; }
            set { _currentStockSlipRecord = value; }
        }

        #endregion  // <現在の発注情報の仕入データのレコード/>

        #region <Constructor/>

        /// <summary>
        /// カスタムコンストラクタ
        /// </summary>
        /// <param name="uoeSupplier">UOE発注先</param>
        /// <param name="receivedTelegramAgreegate">受信電文の集合体</param>
        /// <param name="observer">簡易オブザーバー</param>
        public OrderStockDataBuilder(
            UOESupplierHelper uoeSupplier,
            IAgreegate<ReceivedText> receivedTelegramAgreegate,
            IProgressUpdatable observer
        ) : base(uoeSupplier, receivedTelegramAgreegate, observer)
        { }

        #endregion  // <Constructor/>

        #region <Override/>

        /// <summary>
        /// 発注情報の仕入データに受信電文およびUOE発注データの内容をマージします。
        /// </summary>
        /// <remarks>
        /// 発注情報の仕入データの構築における明治産業による場合分けは
        /// MergeStockDate()：023.仕入日
        /// のみです。
        /// 上記メソッド以外でも場合分けが多く発生する場合、明治産業用のサブクラス化を検討すること。
        /// </remarks>
        public override void Merge()
        {
            ProgressInfo.IsRunning = true;

            foreach (IList<ReceivedText> uoeSlip in ReceivedTelegramAgreegate.GroupedListMap.Values)
            {
                ProgressInfo.Max += uoeSlip.Count;
            }

            // 出荷伝票番号のループ
            foreach (IList<ReceivedText> uoeSlip in ReceivedTelegramAgreegate.GroupedListMap.Values)
            {
                List<StockDetailWork> stockDetailWorkList = new List<StockDetailWork>();

                // ある出荷伝票番号における受信テキスト（明細）のループ
                foreach (ReceivedText receivedTelegram in uoeSlip)
                {
                    Observer.Update(ProgressInfo);

                    bool isNewRecord = false;

                    CurrentStockSlipRecord = StockDB.Instance.Policy.FindStockSlipWork(receivedTelegram);
                    if (CurrentStockSlipRecord == null)
                    {
                        CurrentStockSlipRecord = new StockSlipWork();
                        isNewRecord = true;
                    }
                    Debug.Assert(!isNewRecord, "仕入データに新たなレコードを強制的に挿入しようとしています。");

                    OrderStockDataPair stockDataWithSlipNo = new OrderStockDataPair(
                        StockDB.Instance.Policy.FindSupplierSlipNo(receivedTelegram),
                        receivedTelegram
                    );

                    // 登録済みの発注情報は基本的にそのまま
                    if (!receivedTelegram.IsTelephoneOrder())
                    {
                        MergeStockSectionCd(stockDataWithSlipNo);   // 018.仕入拠点コード
                        MergeStockDate(stockDataWithSlipNo);        // 023.仕入日　※026.支払先コードと019.仕入計上拠点コードを参照するため、これらより後にマージ
                        MergePartySaleSlipNum(stockDataWithSlipNo); // 069.相手先伝票番号
                        continue;
                    }

                    // 仕入明細データの内容をマージ
                    MergeEnterpriseCode(stockDataWithSlipNo);       // 003.企業コード
                    MergeSupplierFormal(stockDataWithSlipNo);       // 009.仕入形式
                    MergeSupplierSlipNo(stockDataWithSlipNo);       // 010.仕入伝票番号
                    MergeSectionCode(stockDataWithSlipNo);          // 011.拠点コード
                    MergeSubSectionCode(stockDataWithSlipNo);       // 012.部門コード
                    MergeDebitNoteNo(stockDataWithSlipNo);          // 013.赤伝区分
                    MergeSupplierSlipCd(stockDataWithSlipNo);       // 015.仕入伝票区分
                    MergeStockGoodsCd(stockDataWithSlipNo);         // 016.仕入商品区分
                    MergeAccPayDivCd(stockDataWithSlipNo);          // 017.買掛区分
                    MergeStockSectionCd(stockDataWithSlipNo);       // 018.仕入拠点コード
                    MergeStockAddUpSectionCd(stockDataWithSlipNo);  // 019.仕入計上拠点コード
                    MergeStockSlipUpdateCd(stockDataWithSlipNo);    // 020.仕入伝票更新区分
                    MergeInputDay(stockDataWithSlipNo);             // 021.入力日
                    MergeDelayPaymentDiv(stockDataWithSlipNo);      // 025.来勘区分
                    MergePayeeCode(stockDataWithSlipNo);            // 026.支払先コード
                    MergePayeeSnm(stockDataWithSlipNo);             // 027.支払先略称
                    MergeStockDate(stockDataWithSlipNo);            // 023.仕入日　※026.支払先コードと019.仕入計上拠点コードを参照するため、これらより後にマージ
                    {
                        MergeSupplierCd(stockDataWithSlipNo);       // 028.仕入先コード
                    }
                    MergeSupplierNm1(stockDataWithSlipNo);          // 029.仕入先名1
                    MergeSupplierNm2(stockDataWithSlipNo);          // 030.仕入先名2
                    MergeSupplierSnm(stockDataWithSlipNo);          // 031.仕入先略称
                    MergeBuisinessTypeCode(stockDataWithSlipNo);    // 032.業種コード
                    MergeBuisinessTypeName(stockDataWithSlipNo);    // 033.業種名称
                    MergeSalesAreaCode(stockDataWithSlipNo);        // 034.販売エリアコード
                    MergeSalesAreaName(stockDataWithSlipNo);        // 035.販売エリア名称
                    MergeStockInputCode(stockDataWithSlipNo);       // 036.仕入入力者コード
                    MergeStockInputName(stockDataWithSlipNo);       // 037.仕入入力者名称
                    {
                        MergeStockAgentCode(stockDataWithSlipNo);   // 038.仕入担当者コード
                        MergeStockAgentName(stockDataWithSlipNo);   // 039.仕入担当者名称
                    }
                    MergeSuppTtlAmntDspWayCd(stockDataWithSlipNo);  // 040.仕入先総額表示方法区分
                    MergeTtlAmntDispRateApy(stockDataWithSlipNo);   // 041.総額表示掛率適用区分
                    MergeStockTotalPrice(stockDataWithSlipNo);      // 042.仕入金額合計
                    MergeStockSubttlPrice(stockDataWithSlipNo);     // 043.仕入金額小計
                    MergeSuppCTaxLayCd(stockDataWithSlipNo);        // 061.仕入先消費税転嫁方式コード
                    MergeSupplierConsTaxRate(stockDataWithSlipNo);  // 062.仕入先消費税税率
                    MergeStockFractionProcCd(stockDataWithSlipNo);  // 064.仕入端数処理区分
                    MergeAutoPayment(stockDataWithSlipNo);          // 065.自動支払区分
                    MergePartySaleSlipNum(stockDataWithSlipNo);     // 069.相手先伝票番号
                    MergeDetailRowCount(stockDataWithSlipNo);       // 072.明細行数
                    {
                        MergeUoeRemark1(stockDataWithSlipNo);       // 075.UOEリマーク1
                        MergeUoeRemark2(stockDataWithSlipNo);       // 076.UOEリマーク2
                    }

                    // 対応する仕入明細データを保持
                    StockDetailWork foundStockDetailWork = StockDB.Instance.Policy.FindStockDetailWork(receivedTelegram);
                    if (foundStockDetailWork != null)
                    {
                        stockDetailWorkList.Add(foundStockDetailWork);
                    }

                    ProgressInfo.Count++;
                }   // foreach (ReceivedText receivedTelegram in uoeSlip)

                // 仕入データの情報算出
                if (stockDetailWorkList.Count > 0)
                {
                    SetCalculatedStockSlipWork(stockDetailWorkList);
                }
            }   // foreach (IList<ReceivedText> uoeSlip in ReceivedTelegramAgreegate.GroupedListMap.Values)

            ProgressInfo.IsRunning = false;
        }

        #endregion  // <Override/>

        #region <003.企業コード/>

        /// <summary>
        /// 企業コードをマージします。
        /// </summary>
        /// <param name="stockDataWithSlipNo">伝票番号と受信電文</param>
        protected void MergeEnterpriseCode(OrderStockDataPair stockDataWithSlipNo)
        {
            string enterpriseCode = LoginWorkerAcs.Instance.Policy.EnterpriseProfile.Code;
            CurrentStockSlipRecord.EnterpriseCode = enterpriseCode;
        }

        #endregion  // <003.企業コード/>

        #region <009.仕入形式/>

        /// <summary>
        /// 仕入形式をマージします。
        /// </summary>
        /// <remarks>
        /// 2:発注
        /// </remarks>
        /// <param name="stockDataWithSlipNo">伝票番号と受信電文</param>
        protected void MergeSupplierFormal(OrderStockDataPair stockDataWithSlipNo)
        {
            const int ORDER = 2;    // 2:発注
            CurrentStockSlipRecord.SupplierFormal = ORDER;
        }

        #endregion  // <009.仕入形式/>

        #region <010.仕入伝票番号/>

        /// <summary>
        /// 仕入伝票番号をマージします。
        /// </summary>
        /// <remarks>
        /// 採番　※UOE発注データの仕入伝票番号を設定しています。
        /// </remarks>
        /// <param name="stockDataWithSlipNo">伝票番号と受信電文</param>
        protected void MergeSupplierSlipNo(OrderStockDataPair stockDataWithSlipNo)
        {
            int supplierSlipNo = int.Parse(stockDataWithSlipNo.Key);
            CurrentStockSlipRecord.SupplierSlipNo = supplierSlipNo;
        }

        #endregion  // <010.仕入伝票番号/>

        #region <011.拠点コード/>

        /// <summary>
        /// 拠点コードをマージします。
        /// </summary>
        /// <remarks>
        /// ログイン担当者の所属拠点コード
        /// </remarks>
        /// <param name="stockDataWithSlipNo">伝票番号と受信電文</param>
        protected void MergeSectionCode(OrderStockDataPair stockDataWithSlipNo)
        {
            string sectionCode = LoginWorkerAcs.Instance.Policy.SectionProfile.Code;
            CurrentStockSlipRecord.SectionCode = sectionCode;
        }

        #endregion  // <011.拠点コード/>

        #region <012.部門コード/>

        /// <summary>
        /// 部門コードをマージします。
        /// </summary>
        /// <remarks>
        /// 担当者の所属部門コード
        /// </remarks>
        /// <param name="stockDataWithSlipNo">伝票番号と受信電文</param>
        protected void MergeSubSectionCode(OrderStockDataPair stockDataWithSlipNo)
        {
            int subSectionCode = LoginWorkerAcs.Instance.Policy.Detail.BelongSubSectionCode;
            CurrentStockSlipRecord.SubSectionCode = subSectionCode;
        }

        #endregion  // <012.部門コード/>

        #region <013.赤伝区分/>

        /// <summary>
        /// 赤伝区分をマージします。
        /// </summary>
        /// <remarks>
        /// 0:黒伝
        /// </remarks>
        /// <param name="stockDataWithSlipNo">伝票番号と受信電文</param>
        protected void MergeDebitNoteNo(OrderStockDataPair stockDataWithSlipNo)
        {
            const int BLACK = 0;    // 0:黒伝
            CurrentStockSlipRecord.DebitNoteDiv = BLACK;
        }

        #endregion  // <013.赤伝区分/>

        #region <015.仕入伝票区分/>

        /// <summary>
        /// 仕入伝票区分をマージします。
        /// </summary>
        /// <remarks>
        /// 10:仕入
        /// </remarks>
        /// <param name="stockDataWithSlipNo">伝票番号と受信電文</param>
        protected void MergeSupplierSlipCd(OrderStockDataPair stockDataWithSlipNo)
        {
            const int STOCK = 10;   // 10:仕入
            CurrentStockSlipRecord.SupplierSlipCd = STOCK;
        }

        #endregion  // <015.仕入伝票区分/>

        #region <016.仕入商品区分/>

        /// <summary>
        /// 仕入商品区分をマージします。
        /// </summary>
        /// <remarks>
        /// 0:商品
        /// </remarks>
        /// <param name="stockDataWithSlipNo">伝票番号と受信電文</param>
        protected void MergeStockGoodsCd(OrderStockDataPair stockDataWithSlipNo)
        {
            const int GOODS = 0;    // 0:商品
            CurrentStockSlipRecord.StockGoodsCd = GOODS;
        }

        #endregion  // <016.仕入商品区分/>

        #region <017.買掛区分/>

        /// <summary>
        /// 買掛区分をマージします。
        /// </summary>
        /// <remarks>
        /// 1:買掛
        /// </remarks>
        /// <param name="stockDataWithSlipNo">伝票番号と受信電文</param>
        protected void MergeAccPayDivCd(OrderStockDataPair stockDataWithSlipNo)
        {
            const int PAYABLE_PRICE = 1;    // 1:買掛
            CurrentStockSlipRecord.AccPayDivCd = PAYABLE_PRICE;
        }

        #endregion  // <017.買掛区分/>

        #region <018.仕入拠点コード/>

        /// <summary>
        /// 仕入拠点コードをマージします。
        /// </summary>
        /// <remarks>
        /// UOE自社設定マスタの卸商拠点設定区分に従う
        /// </remarks>
        /// <param name="stockDataWithSlipNo">伝票番号と受信電文</param>
        protected void MergeStockSectionCd(OrderStockDataPair stockDataWithSlipNo)
        {
            // 仕入拠点コードをマージ
            string stockSectionCd = GetStockSectionCd(stockDataWithSlipNo.Value);
            if (!string.IsNullOrEmpty(stockSectionCd))
            {
                CurrentStockSlipRecord.StockSectionCd = stockSectionCd;
            }
        }

        /// <summary>
        /// 仕入拠点コードを取得します。
        /// </summary>
        /// <param name="receivedTelegram">受信テキスト</param>
        /// <returns>仕入拠点コード</returns>
        protected string GetStockSectionCd(ReceivedText receivedTelegram)
        {
            string stockSectionCd = string.Empty;

            int distSectionSetDiv = LoginWorkerAcs.Instance.Policy.UOESetting.DistSectionSetDiv;
            switch (distSectionSetDiv)
            {
                // 仕入マスタ
                case (int)LoginWorker.OroshishoDistSectionSetDiv.SupplierMaster:
                {
                    Supplier supplier = SupplierDB.Instance.Policy.Find(UoeSupplier);
                    if (supplier != null)
                    {
                        stockSectionCd = supplier.MngSectionCode;
                    }
                    break;
                }
                // 発注データ
                case (int)LoginWorker.OroshishoDistSectionSetDiv.OrderData:
                {
                    UOEOrderDtlWork uoeOrderDetail = StockDB.Instance.Policy.FindUOEOrderDtlWork(receivedTelegram);
                    if (uoeOrderDetail != null)
                    {
                        stockSectionCd = uoeOrderDetail.SectionCode;
                    }
                    break;
                }
                // UOE自社マスタ
                case (int)LoginWorker.OroshishoDistSectionSetDiv.UOESettingMaster:
                {
                    stockSectionCd = LoginWorkerAcs.Instance.Policy.UOESetting.SectionCode;
                    break;
                }
            }

            return stockSectionCd;
        }

        #endregion  // <018.仕入拠点コード/>

        #region <019.仕入計上拠点コード/>

        /// <summary>
        /// 仕入計上拠点コードをマージします。
        /// </summary>
        /// <remarks>
        /// 仕入先マスタの支払拠点コードをセット
        /// </remarks>
        /// <param name="stockDataWithSlipNo">伝票番号と受信電文</param>
        protected void MergeStockAddUpSectionCd(OrderStockDataPair stockDataWithSlipNo)
        {
            Supplier supplier = SupplierDB.Instance.Policy.Find(UoeSupplier);
            if (supplier != null)
            {
                string stockAddUpSectionCd = supplier.PaymentSectionCode;
                CurrentStockSlipRecord.StockAddUpSectionCd = stockAddUpSectionCd;
            }
        }

        #endregion  // <019.仕入計上拠点コード/>

        #region <020.仕入伝票更新区分/>

        /// <summary>
        /// 仕入伝票更新区分をマージします。
        /// </summary>
        /// <remarks>
        /// 0:未更新
        /// </remarks>
        /// <param name="stockDataWithSlipNo">伝票番号と受信電文</param>
        protected void MergeStockSlipUpdateCd(OrderStockDataPair stockDataWithSlipNo)
        {
            const int NOT_UPDATE = 0;   // 0:未更新
            CurrentStockSlipRecord.StockSlipUpdateCd = NOT_UPDATE;
        }

        #endregion  // <020.仕入伝票更新区分/>

        #region <021.入力日/>

        /// <summary>
        /// 入力日をマージします。
        /// </summary>
        /// <remarks>
        /// YYYYMMDD（更新年月日）
        /// </remarks>
        /// <param name="stockDataWithSlipNo">伝票番号と受信電文</param>
        protected void MergeInputDay(OrderStockDataPair stockDataWithSlipNo)
        {
            DateTime inputDay = DateTime.Now;
            CurrentStockSlipRecord.InputDay = inputDay;
        }

        #endregion  // <021.入力日/>

        #region <023.仕入日/>

        /// <summary>
        /// 仕入日をマージします。
        /// </summary>
        /// <remarks>
        /// 明治産業の場合、受信電文の分類コードより算出
        /// 締済みの場合、
        /// ※026.支払先コードと019.仕入計上拠点コードを参照するため、これらより後にマージ
        /// </remarks>
        /// <param name="stockDataWithSlipNo">伝票番号と受信電文</param>
        protected void MergeStockDate(OrderStockDataPair stockDataWithSlipNo)
        {
            if (stockDataWithSlipNo.Value.IsTelephoneOrder()) return;   // 電話発注の場合、未設定

            DateTime stockDate = CurrentStockSlipRecord.StockDate;

            if (UoeSupplier is UOEMeijiDecorator)
            {
                ReceivedDate receivedDate = new ReceivedDate(stockDataWithSlipNo.Value.ClassifiedCode.Trim());
                stockDate = receivedDate.ToDateTime();
            }
            else
            {
                if (stockDate.Equals(DateTime.MinValue))
                {
                    UOEOrderDtlWork uoeOrderDetailRecord = StockDB.Instance.Policy.FindUOEOrderDtlWork(
                        stockDataWithSlipNo.Value.DtlRelationGuid
                    );
                    if (uoeOrderDetailRecord != null)
                    {
                        stockDate = uoeOrderDetailRecord.ReceiveDate;
                    }
                    else
                    {
                        stockDate = DateTime.Now;
                    }
                }
            }

            // 締日チェック
            stockDate = GetDayPayment(stockDate, CurrentStockSlipRecord);
            CurrentStockSlipRecord.StockDate = stockDate;
        }

        #region <締日チェック/>

        /// <summary>
        /// 締日を考慮した仕入日を取得します。
        /// </summary>
        /// <remarks>
        /// 買掛オプションありの場合、仕入データの仕入先コードにて、仕入月次と仕入締次の締日チェック
        /// 買掛オプションなしの場合、仕入データの仕入計上拠点コードにて、売上月次の締日チェック
        /// </remarks>
        /// <param name="stockDate">仕入日</param>
        /// <param name="stockSlipWork">仕入データ</param>
        /// <returns>
        /// 締済みの場合、前回締処理日+1日
        /// </returns>
        public static DateTime GetDayPayment(
            DateTime stockDate,
            StockSlipWork stockSlipWork
        )
        {
            // 締日算出モジュール
            TotalDayCalculator totalDayCalculator = TotalDayCalculator.GetInstance();
            DateTime previousTotalDay= DateTime.MinValue;
            DateTime currentTotalDay = DateTime.MinValue;
            {
                // 買掛オプションあり
                if (LoginWorkerAcs.Instance.Policy.HasStockingPaymentOption)
                {
                    // 仕入月次の締日取得
                    if (totalDayCalculator.CheckMonthlyAccPay(
                        stockSlipWork.StockAddUpSectionCd,
                        stockSlipWork.PayeeCode,
                        stockDate
                    ))
                    {
                        if (totalDayCalculator.GetTotalDayMonthlyAccPay(
                            stockSlipWork.StockAddUpSectionCd,
                            stockSlipWork.PayeeCode,
                            out previousTotalDay,
                            out currentTotalDay
                        ).Equals(0))
                        {
                            return previousTotalDay.AddDays(1);
                        }
                    }

                    // 仕入締次の締日取得
                    if (totalDayCalculator.CheckPayment(
                        stockSlipWork.StockAddUpSectionCd,
                        stockSlipWork.PayeeCode,
                        stockDate
                    ))
                    {
                        if (totalDayCalculator.GetTotalDayPayment(
                            stockSlipWork.StockAddUpSectionCd,
                            stockSlipWork.PayeeCode,
                            out previousTotalDay,
                            out currentTotalDay
                        ).Equals(0))
                        {
                            return previousTotalDay.AddDays(1);
                        }
                    }
                }
                // 買掛オプションなし
                else
                {
                    totalDayCalculator.InitializeHisMonthlyAccPay();

                    // 売上月次の締日取得
                    if (totalDayCalculator.CheckMonthlyAccRec(
                        stockSlipWork.StockAddUpSectionCd,
                        stockSlipWork.PayeeCode,
                        stockDate
                    ))
                    {
                        if (totalDayCalculator.GetHisTotalDayMonthly(
                            stockSlipWork.StockAddUpSectionCd,
                            out previousTotalDay,
                            out currentTotalDay
                        ).Equals(0))
                        {
                            return previousTotalDay.AddDays(1);
                        }
                    }
                }
            }

            return stockDate;
        }

        #endregion  // <締日チェック/>

        #endregion  // <023.仕入日/>

        #region <025.来勘区分/>

        /// <summary>
        /// 来勘区分をマージします。
        /// </summary>
        /// <remarks>
        /// 0:当月
        /// </remarks>
        /// <param name="stockDataWithSlipNo">伝票番号と受信電文</param>
        protected void MergeDelayPaymentDiv(OrderStockDataPair stockDataWithSlipNo)
        {
            const int THIS_MONTH = 0;   // 0:当月
            CurrentStockSlipRecord.DelayPaymentDiv = THIS_MONTH;
        }

        #endregion  // <025.来勘区分/>

        #region <026.支払先コード/>

        /// <summary>
        /// 支払先コードをマージします。
        /// </summary>
        /// <remarks>
        /// 仕入先マスタの支払先コード
        /// </remarks>
        /// <param name="stockDataWithSlipNo">伝票番号と受信電文</param>
        protected void MergePayeeCode(OrderStockDataPair stockDataWithSlipNo)
        {
            Supplier supplier = SupplierDB.Instance.Policy.Find(UoeSupplier);
            if (supplier != null)
            {
                int payeeCode = supplier.PayeeCode;
                CurrentStockSlipRecord.PayeeCode = payeeCode;
            }
        }

        #endregion  // <026.支払先コード/>

        #region <027.支払先略称/>

        /// <summary>
        /// 支払先略称をマージします。
        /// </summary>
        /// <remarks>
        /// 仕入先マスタの支払先に対する略称
        /// </remarks>
        /// <param name="stockDataWithSlipNo">伝票番号と受信電文</param>
        protected void MergePayeeSnm(OrderStockDataPair stockDataWithSlipNo)
        {
            Supplier supplier = SupplierDB.Instance.Policy.Find(UoeSupplier);
            if (supplier != null)
            {
                string payeeSnm = supplier.PayeeSnm;
                CurrentStockSlipRecord.PayeeSnm = payeeSnm;
            }
        }

        #endregion  // <027.支払先略称/>

        #region <028.仕入先コード/>

        /// <summary>
        /// 仕入先コードをマージします。
        /// </summary>
        /// <remarks>
        /// UOE発注データの仕入先コード（= UOE発注先マスタの仕入先コード）
        /// </remarks>
        /// <param name="stockDataWithSlipNo">伝票番号と受信電文</param>
        protected void MergeSupplierCd(OrderStockDataPair stockDataWithSlipNo)
        {
            UOEOrderDtlWork uoeOrderRecord = StockDB.Instance.Policy.FindUOEOrderDtlWork(stockDataWithSlipNo.Value);
            if (uoeOrderRecord != null)
            {
                int supplierCd = uoeOrderRecord.SupplierCd;
                CurrentStockSlipRecord.SupplierCd = supplierCd;
            }
        }

        #endregion  // <028.仕入先コード/>

        #region <029.仕入先名1/>

        /// <summary>
        /// 仕入先名1をマージします。
        /// </summary>
        /// <remarks>
        /// 仕入先マスタの仕入先名1
        /// </remarks>
        /// <param name="stockDataWithSlipNo">伝票番号と受信電文</param>
        protected void MergeSupplierNm1(OrderStockDataPair stockDataWithSlipNo)
        {
            Supplier supplier = SupplierDB.Instance.Policy.Find(UoeSupplier);
            if (supplier != null)
            {
                string supplierNm1 = supplier.SupplierNm1;
                CurrentStockSlipRecord.SupplierNm1 = supplierNm1;
            }
        }

        #endregion  // <029.仕入先名1/>

        #region <030.仕入先名2/>

        /// <summary>
        /// 仕入先名2をマージします。
        /// </summary>
        /// <remarks>
        /// 仕入先マスタの仕入先名2
        /// </remarks>
        /// <param name="stockDataWithSlipNo">伝票番号と受信電文</param>
        protected void MergeSupplierNm2(OrderStockDataPair stockDataWithSlipNo)
        {
            Supplier supplier = SupplierDB.Instance.Policy.Find(UoeSupplier);
            if (supplier != null)
            {
                string supplierNm2 = supplier.SupplierNm2;
                CurrentStockSlipRecord.SupplierNm2 = supplierNm2;
            }
        }

        #endregion  // <030.仕入先名2/>

        #region <031.仕入先略称/>

        /// <summary>
        /// 仕入先略称をマージします。
        /// </summary>
        /// <remarks>
        /// 仕入先マスタの仕入先略称
        /// </remarks>
        /// <param name="stockDataWithSlipNo">伝票番号と受信電文</param>
        protected void MergeSupplierSnm(OrderStockDataPair stockDataWithSlipNo)
        {
            Supplier supplier = SupplierDB.Instance.Policy.Find(UoeSupplier);
            if (supplier != null)
            {
                string supplierSnm = supplier.SupplierSnm;
                CurrentStockSlipRecord.SupplierSnm = supplierSnm;
            }
        }

        #endregion  // <031.仕入先略称/>

        #region <032.業種コード/>

        /// <summary>
        /// 業種コードをマージします。
        /// </summary>
        /// <remarks>
        /// 仕入先マスタの業種コード
        /// </remarks>
        /// <param name="stockDataWithSlipNo">伝票番号と受信電文</param>
        protected void MergeBuisinessTypeCode(OrderStockDataPair stockDataWithSlipNo)
        {
            Supplier supplier = SupplierDB.Instance.Policy.Find(UoeSupplier);
            if (supplier != null)
            {
                int businessTypeCode = supplier.BusinessTypeCode;
                CurrentStockSlipRecord.BusinessTypeCode = businessTypeCode;
            }
        }

        #endregion  // <032.業種コード/>

        #region <033.業種名称/>

        /// <summary>
        /// 業種名称をマージします。
        /// </summary>
        /// <remarks>
        /// 業種名称
        /// </remarks>
        /// <param name="stockDataWithSlipNo">伝票番号と受信電文</param>
        protected void MergeBuisinessTypeName(OrderStockDataPair stockDataWithSlipNo)
        {
            Supplier supplier = SupplierDB.Instance.Policy.Find(UoeSupplier);
            if (supplier != null)
            {
                string businessTypeName = supplier.BusinessTypeName;
                CurrentStockSlipRecord.BusinessTypeName = businessTypeName;
            }
        }

        #endregion  // <033.業種名称/>

        #region <034.販売エリアコード/>

        /// <summary>
        /// 販売エリアコードをマージします。
        /// </summary>
        /// <remarks>
        /// 仕入先マスタの地区コード
        /// </remarks>
        /// <param name="stockDataWithSlipNo">伝票番号と受信電文</param>
        protected void MergeSalesAreaCode(OrderStockDataPair stockDataWithSlipNo)
        {
            Supplier supplier = SupplierDB.Instance.Policy.Find(UoeSupplier);
            if (supplier != null)
            {
                int salesAreaCode = supplier.SalesAreaCode;
                CurrentStockSlipRecord.SalesAreaCode = salesAreaCode;
            }
        }

        #endregion  // <034.販売エリアコード/>

        #region <035.販売エリア名称/>

        /// <summary>
        /// 販売エリア名称をマージします。
        /// </summary>
        /// <remarks>
        /// 地区名称
        /// </remarks>
        /// <param name="stockDataWithSlipNo">伝票番号と受信電文</param>
        protected void MergeSalesAreaName(OrderStockDataPair stockDataWithSlipNo)
        {
            Supplier supplier = SupplierDB.Instance.Policy.Find(UoeSupplier);
            if (supplier != null)
            {
                string salesAreaName = supplier.SalesAreaName;
                CurrentStockSlipRecord.SalesAreaName = salesAreaName;
            }
        }

        #endregion  // <035.販売エリア名称/>

        #region <036.仕入入力者コード/>

        /// <summary>
        /// 仕入入力者コードをマージします。
        /// </summary>
        /// <remarks>
        /// ログイン担当者
        /// </remarks>
        /// <param name="stockDataWithSlipNo">伝票番号と受信電文</param>
        protected void MergeStockInputCode(OrderStockDataPair stockDataWithSlipNo)
        {
            string stockInputCode = LoginWorkerAcs.Instance.Policy.Profile.EmployeeCode;
            CurrentStockSlipRecord.StockInputCode = stockInputCode;
        }

        #endregion  // <036.仕入入力者コード/>

        #region <037.仕入入力者名称/>

        /// <summary>
        /// 仕入入力者名称をマージします。
        /// </summary>
        /// <remarks>
        /// ログイン担当者の名称
        /// </remarks>
        /// <param name="stockDataWithSlipNo">伝票番号と受信電文</param>
        protected void MergeStockInputName(OrderStockDataPair stockDataWithSlipNo)
        {
            string stockInputName = LoginWorkerAcs.Instance.Policy.Profile.Name;
            CurrentStockSlipRecord.StockInputName = stockInputName;
        }

        #endregion  // <037.仕入入力者名称/>

        #region <038.仕入担当者コード/>

        /// <summary>
        /// 仕入担当者コードをマージします。
        /// </summary>
        /// <remarks>
        /// UOE発注データの従業員コード
        /// </remarks>
        /// <param name="stockDataWithSlipNo">伝票番号と受信電文</param>
        protected void MergeStockAgentCode(OrderStockDataPair stockDataWithSlipNo)
        {
            UOEOrderDtlWork uoeOrderRecord = StockDB.Instance.Policy.FindUOEOrderDtlWork(stockDataWithSlipNo.Value);
            if (uoeOrderRecord != null)
            {
                string stockAgentCode = uoeOrderRecord.EmployeeCode;
                CurrentStockSlipRecord.StockAgentCode = stockAgentCode;
            }
        }

        #endregion  // <038.仕入担当者コード/>

        #region <039.仕入担当者名称/>

        /// <summary>
        /// 仕入担当者名称をマージします。
        /// </summary>
        /// <remarks>
        /// UOE発注データの従業員名称
        /// </remarks>
        /// <param name="stockDataWithSlipNo">伝票番号と受信電文</param>
        protected void MergeStockAgentName(OrderStockDataPair stockDataWithSlipNo)
        {
            UOEOrderDtlWork uoeOrderRecord = StockDB.Instance.Policy.FindUOEOrderDtlWork(stockDataWithSlipNo.Value);
            if (uoeOrderRecord != null)
            {
                string stockAgentName = uoeOrderRecord.EmployeeName;
                CurrentStockSlipRecord.StockAgentName = stockAgentName;
            }
        }

        #endregion  // <039.仕入担当者名称/>

        #region <040.仕入先総額表示方法区分/>

        /// <summary>
        /// 仕入先総額表示方法区分をマージします。
        /// </summary>
        /// <remarks>
        /// 仕入先マスタの仕入先総額表示方法区分
        /// </remarks>
        /// <param name="stockDataWithSlipNo">伝票番号と受信電文</param>
        protected void MergeSuppTtlAmntDspWayCd(OrderStockDataPair stockDataWithSlipNo)
        {
            Supplier supplier = SupplierDB.Instance.Policy.Find(UoeSupplier);
            if (supplier != null)
            {
                int suppTtlAmntDspWayCd = supplier.SuppTtlAmntDspWayCd;
                CurrentStockSlipRecord.SuppTtlAmntDspWayCd = suppTtlAmntDspWayCd;
            }
        }

        #endregion  // <040.仕入先総額表示方法区分/>

        #region <041.総額表示掛率適用区分/>

        /// <summary>
        /// 総額表示掛率適用区分をマージします。
        /// </summary>
        /// <remarks>
        /// 全体初期設定マスタの総額表示掛率適用区分
        /// </remarks>
        /// <param name="stockDataWithSlipNo">伝票番号と受信電文</param>
        protected void MergeTtlAmntDispRateApy(OrderStockDataPair stockDataWithSlipNo)
        {
            int ttlAmntDispRateApy = AllDefSetDB.Instance.Policy.AllDefSet.TtlAmntDspRateDivCd;
            CurrentStockSlipRecord.TtlAmntDispRateApy = ttlAmntDispRateApy;
        }

        #endregion  // <041.総額表示掛率適用区分/>

        #region <042.仕入金額合計/>

        /// <summary>
        /// 仕入金額合計をマージします。
        /// </summary>
        /// <remarks>
        /// 仕入明細データの仕入金額（税抜き）合計
        /// </remarks>
        /// <param name="stockDataWithSlipNo">伝票番号と受信電文</param>
        protected void MergeStockTotalPrice(OrderStockDataPair stockDataWithSlipNo)
        {
            long stockTotalPrice = StockDB.Instance.Policy.GetStockTotalPrice(stockDataWithSlipNo.Value);
            CurrentStockSlipRecord.StockTotalPrice = stockTotalPrice;
        }

        #endregion  // <042.仕入金額合計/>

        #region <043.仕入金額小計/>

        /// <summary>
        /// 仕入金額小計をマージします。
        /// </summary>
        /// <remarks>
        /// 仕入明細データの仕入金額（税込み）合計
        /// </remarks>
        /// <param name="stockDataWithSlipNo">伝票番号と受信電文</param>
        protected void MergeStockSubttlPrice(OrderStockDataPair stockDataWithSlipNo)
        {
            long stockSubttlPrice = StockDB.Instance.Policy.GetStockSubttlPrice(stockDataWithSlipNo.Value);
            CurrentStockSlipRecord.StockSubttlPrice = stockSubttlPrice;
        }

        #endregion  // <043.仕入金額小計/>

        #region <044.仕入金額計（税込み）/>

        /// <summary>
        /// 仕入金額計（税込み）をマージします。
        /// </summary>
        /// <remarks>
        /// 仕入明細データの仕入金額（税込み）合計
        /// （仕入金額小計も同じ値）
        /// </remarks>
        /// <param name="stockDataWithSlipNo">伝票番号と受信電文</param>
        protected void MergeStockTtlPricTaxInc(OrderStockDataPair stockDataWithSlipNo)
        {
            long stockTtlPricTaxInc = CurrentStockSlipRecord.StockSubttlPrice;
            CurrentStockSlipRecord.StockTtlPricTaxInc = stockTtlPricTaxInc;
        }

        #endregion  // <044.仕入金額計（税込み）/>

        #region <045.仕入金額計（税抜き）/>

        /// <summary>
        /// 仕入金額計（税抜き）をマージします。
        /// </summary>
        /// <remarks>
        /// 仕入明細データの仕入金額（税抜き）合計
        /// （仕入金額合計も同じ値）
        /// </remarks>
        /// <param name="stockDataWithSlipNo">伝票番号と受信電文</param>
        protected void MergeStockTtlPricTaxExc(OrderStockDataPair stockDataWithSlipNo)
        {
            long stockTtlPricTaxExc = CurrentStockSlipRecord.StockTotalPrice;
            CurrentStockSlipRecord.StockTtlPricTaxExc = stockTtlPricTaxExc;
        }

        #endregion  // <044.仕入金額計（税込み）/>

        #region <061.仕入先消費税転嫁方式コード/>

        /// <summary>
        /// 仕入先消費税転嫁方式コードをマージします。
        /// </summary>
        /// <remarks>
        /// 仕入先マスタの仕入先消費税転嫁方式コード
        /// </remarks>
        /// <param name="stockDataWithSlipNo">伝票番号と受信電文</param>
        protected void MergeSuppCTaxLayCd(OrderStockDataPair stockDataWithSlipNo)
        {
            Supplier supplier = SupplierDB.Instance.Policy.Find(UoeSupplier);
            if (supplier != null)
            {
                int suppCTaxLayCd = supplier.SuppCTaxLayCd;
                CurrentStockSlipRecord.SuppCTaxLayCd = suppCTaxLayCd;
            }
        }

        #endregion  // <061.仕入先消費税転嫁方式コード/>

        #region <062.仕入先消費税税率/>

        /// <summary>
        /// 仕入先消費税税率をマージします。
        /// </summary>
        /// <remarks>
        /// 税率設定マスタより
        /// </remarks>
        /// <param name="stockDataWithSlipNo">伝票番号と受信電文</param>
        protected void MergeSupplierConsTaxRate(OrderStockDataPair stockDataWithSlipNo)
        {
            double supplierConsTaxRate = TaxRateSetDB.Instance.Policy.TaxRateOfNow;
            CurrentStockSlipRecord.SupplierConsTaxRate = supplierConsTaxRate;
        }

        #endregion  // <062.仕入先消費税税率/>

        #region <064.仕入端数処理区分/>

        /// <summary>
        /// 仕入端数処理区分をマージします。
        /// </summary>
        /// <remarks>
        /// 1:切捨て, 2:四捨五入, 3:切上げ（消費税）
        /// </remarks>
        /// <param name="stockDataWithSlipNo">伝票番号と受信電文</param>
        protected void MergeStockFractionProcCd(OrderStockDataPair stockDataWithSlipNo)
        {
            Supplier supplier = SupplierDB.Instance.Policy.Find(UoeSupplier);
            if (supplier == null) return;

            UOESendReceiveComponent component = new UOESendReceiveComponent();
            {
                StockProcMoney stockProcMoney = component.GetStockProcMoney(supplier.StockCnsTaxFrcProcCd);
                {
                    if (stockProcMoney == null) return;

                    CurrentStockSlipRecord.StockFractionProcCd = stockProcMoney.FractionProcCd;
                }
            }
        }

        #endregion  // <064.仕入端数処理区分/>

        #region <065.自動支払区分/>

        /// <summary>
        /// 自動支払区分をマージします。
        /// </summary>
        /// <remarks>
        /// 0:通常支払
        /// </remarks>
        /// <param name="stockDataWithSlipNo">伝票番号と受信電文</param>
        protected void MergeAutoPayment(OrderStockDataPair stockDataWithSlipNo)
        {
            const int NORMAL = 0;   // 0:通常支払
            CurrentStockSlipRecord.AutoPayment = NORMAL;
        }

        #endregion  // <065.自動支払区分/>

        #region <069.相手先伝票番号/>

        /// <summary>
        /// 相手先伝票番号をマージします。
        /// </summary>
        /// <remarks>
        /// 受信電文の出荷伝票番号
        /// </remarks>
        /// <param name="stockDataWithSlipNo">伝票番号と受信電文</param>
        protected void MergePartySaleSlipNum(OrderStockDataPair stockDataWithSlipNo)
        {
            string partySaleSlipNum = stockDataWithSlipNo.Value.UOESectionSlipNo;
            CurrentStockSlipRecord.PartySaleSlipNum = partySaleSlipNum;
        }

        #endregion  // <069.相手先伝票番号/>

        #region <072.明細行数/>

        /// <summary>
        /// 明細行数をマージします。
        /// </summary>
        /// <remarks>
        /// 明細行数
        /// </remarks>
        /// <param name="stockDataWithSlipNo">伝票番号と受信電文</param>
        protected void MergeDetailRowCount(OrderStockDataPair stockDataWithSlipNo)
        {
            int detailRowCount = StockDB.Instance.Policy.GetDetailRowCount(stockDataWithSlipNo.Value);
            CurrentStockSlipRecord.DetailRowCount = detailRowCount;
        }

        #endregion  // <072.明細行数/>

        #region <075.UOEリマーク1/>

        /// <summary>
        /// UOEリマーク1をマージします。
        /// </summary>
        /// <remarks>
        /// UOE発注データのUOEリマーク1
        /// </remarks>
        /// <param name="stockDataWithSlipNo">伝票番号と受信電文</param>
        protected void MergeUoeRemark1(OrderStockDataPair stockDataWithSlipNo)
        {
            UOEOrderDtlWork uoeOrderRecord = StockDB.Instance.Policy.FindUOEOrderDtlWork(stockDataWithSlipNo.Value);
            if (uoeOrderRecord != null)
            {
                string uoeRemark1 = uoeOrderRecord.UoeRemark1;
                CurrentStockSlipRecord.UoeRemark1 = uoeRemark1;
            }
        }

        #endregion  // <075.UOEリマーク1/>

        #region <076.UOEリマーク2/>

        /// <summary>
        /// UOEリマーク2をマージします。
        /// </summary>
        /// <remarks>
        /// UOE発注データのUOEリマーク2
        /// </remarks>
        /// <param name="stockDataWithSlipNo">伝票番号と受信電文</param>
        protected void MergeUoeRemark2(OrderStockDataPair stockDataWithSlipNo)
        {
            UOEOrderDtlWork uoeOrderRecord = StockDB.Instance.Policy.FindUOEOrderDtlWork(stockDataWithSlipNo.Value);
            if (uoeOrderRecord != null)
            {
                string uoeRemark2 = uoeOrderRecord.UoeRemark2;
                CurrentStockSlipRecord.UoeRemark2 = uoeRemark2;
            }
        }

        #endregion  // <076.UOEリマーク2/>

        /// <summary>
        /// 仕入データの情報を算出し、設定します。
        /// </summary>
        /// <param name="uoeStockDetailWorkList"></param>
        protected void SetCalculatedStockSlipWork(List<StockDetailWork> uoeStockDetailWorkList)
        {
            Supplier supplier = SupplierDB.Instance.Policy.Find(UoeSupplier);
            if (supplier == null) return;

            UOESendReceiveComponent component = new UOESendReceiveComponent();
            StockProcMoney stockProcMoney = component.GetStockProcMoney(supplier.StockCnsTaxFrcProcCd);
            if (stockProcMoney == null) return;
            
            StockSlipPriceCalculator.TotalPriceSetting(
                ref _currentStockSlipRecord,
                uoeStockDetailWorkList,
                stockProcMoney.FractionProcUnit,
                supplier.StockCnsTaxFrcProcCd
            );
        }
    }
}

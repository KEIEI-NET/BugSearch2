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
// 管理番号              作成担当 : 21024　佐々木 健
// 作 成 日  2009/10/15  修正内容 : 在庫調整データの合計金額を再集計するように修正(MANTIS[0014424])
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;

using Broadleaf.Application.Common;
using Broadleaf.Application.Controller.Agent;
using Broadleaf.Application.Controller.Util;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Application.Controller
{
    using StockDB               = SingletonPolicy<StockDBAgent>;
    using SupplierDB            = SingletonPolicy<SupplierDBAgent>;
    using SumUpStockAdjustPair  = KeyValuePair<IList<StockAdjustDtlWork>>;

    /// <summary>
    /// 計上情報の在庫調整データの構築者クラス
    /// </summary>
    public class SumUpStockAdjustBuilder : SumUpInformationBuilder
    {
        #region <現在の計上情報の在庫調整データのレコード/>

        /// <summary>現在の計上情報の在庫調整データのレコード</summary>
        private StockAdjustWork _currentStockAdjustRecord;
        /// <summary>
        /// 現在の計上情報の在庫調整データのレコードのアクセサ
        /// </summary>
        private StockAdjustWork CurrentStockAdjustRecord
        {
            get { return _currentStockAdjustRecord; }
            set { _currentStockAdjustRecord = value; }
        }

        #endregion  // <現在の計上情報の在庫調整データのレコード/>

        #region <Constructor/>

        /// <summary>
        /// カスタムコンストラクタ
        /// </summary>
        /// <param name="uoeSupplier">UOE発注先</param>
        public SumUpStockAdjustBuilder(UOESupplierHelper uoeSupplier) : base(uoeSupplier) { }

        #endregion  // <Constructor/>

        #region <Override/>

        /// <summary>
        /// 計上情報の在庫調整データに発注情報の仕入データの内容をマージします。
        /// </summary>
        public override void Merge()
        {
            foreach (int supplierSlipNo in StockDB.Instance.Policy.SumUpStockAdjustDetailRecordMap.Keys)
            {
                string slipNo = supplierSlipNo.ToString();
                SumUpStockAdjustPair stockAdjustWithSlipNo = new SumUpStockAdjustPair(
                    slipNo,
                    StockDB.Instance.Policy.SumUpStockAdjustDetailRecordMap[supplierSlipNo]
                );

                CurrentStockAdjustRecord = StockDB.Instance.Policy.SumUpAdjustRecordMap[supplierSlipNo];

                // 仕入データの内容をマージ
                MergeAcPaySlipCd(stockAdjustWithSlipNo);        // 011.受払元伝票区分
                MergeAcPayTransCd(stockAdjustWithSlipNo);       // 012.受払元取引区分
                MergeAdjustDate(stockAdjustWithSlipNo);         // 013.調整日付
                MergeInputDay(stockAdjustWithSlipNo);           // 014.入力日付
                // 2009/10/15 Add >>>
                MergeStockSubttlPrice(stockAdjustWithSlipNo);   // 020.仕入金額小計
                // 2009/10/15 Add <<<
            }
        }

        #endregion  // <Override/>

        #region <011.受払元伝票区分/>

        /// <summary>
        /// 受払元伝票区分をマージします。
        /// </summary>
        /// <remarks>
        /// 13:在庫仕入　※2009/02/05 計上元の伝票区分に変更？
        /// </remarks>
        /// <param name="stockAdjustWithSlipNo">出荷伝票番号と発注情報の在庫調整データ</param>
        protected void MergeAcPaySlipCd(SumUpStockAdjustPair stockAdjustWithSlipNo)
        {
            const int STOCK_STOCK = 13; // 13:在庫仕入
            CurrentStockAdjustRecord.AcPaySlipCd = STOCK_STOCK;
        }

        #endregion  // <011.受払元伝票区分/>

        #region <012.受払元取引区分/>

        /// <summary>
        /// 受払元取引区分をマージします。
        /// </summary>
        /// <remarks>
        /// 30:在庫数調整
        /// </remarks>
        /// <param name="stockAdjustWithSlipNo">出荷伝票番号と発注情報の在庫調整データ</param>
        protected void MergeAcPayTransCd(SumUpStockAdjustPair stockAdjustWithSlipNo)
        {
            const int STOCK_ADJUST= 30; // 30:在庫数調整
            const int NORMAL_SLIP = 10; // 10:通常伝票
            CurrentStockAdjustRecord.AcPayTransCd = STOCK_ADJUST;
        }

        #endregion  // <012.受払元取引区分/>

        #region <013.調整日付/>

        /// <summary>
        /// 調整日付をマージします。
        /// </summary>
        /// <remarks>
        /// システム日付（締日のチェック）
        /// </remarks>
        /// <param name="stockAdjustWithSlipNo">出荷伝票番号と発注情報の在庫調整データ</param>
        protected void MergeAdjustDate(SumUpStockAdjustPair stockAdjustWithSlipNo)
        {
            DateTime adjustDate = DateTime.Now;

            // 締日チェック
            adjustDate = GetDayPayment(adjustDate, UoeSupplier);

            CurrentStockAdjustRecord.AdjustDate = adjustDate;
        }

        #region <締日チェック/>

        /// <summary>
        /// 締日を考慮した調整日付を取得します。
        /// </summary>
        /// <remarks>
        /// 仕入データの仕入計上拠点コードにて、売上月次の締日チェック
        /// </remarks>
        /// <param name="adjustDate">調整日付</param>
        /// <param name="uoeSupplier">UOE発注先</param>
        /// <returns>
        /// 締済みの場合、前回締処理日+1日
        /// </returns>
        public static DateTime GetDayPayment(
            DateTime adjustDate,
            UOESupplierHelper uoeSupplier
        )
        {
            string stockAddUpSectionCd = string.Empty;  // 仕入計上拠点コード
            int payeeCode = 0;                          // 支払先コード
            {
                Supplier supplier = SupplierDB.Instance.Policy.Find(uoeSupplier);
                if (supplier == null) return adjustDate;

                stockAddUpSectionCd = supplier.PaymentSectionCode;
                payeeCode = supplier.PayeeCode;
            }

            // 締日算出モジュール
            TotalDayCalculator totalDayCalculator = TotalDayCalculator.GetInstance();
            DateTime previousTotalDay= DateTime.MinValue;
            DateTime currentTotalDay = DateTime.MinValue;
            {
                totalDayCalculator.InitializeHisMonthlyAccPay();

                // 売上月次の締日取得
                if (totalDayCalculator.CheckMonthlyAccRec(
                    stockAddUpSectionCd,
                    payeeCode,
                    adjustDate
                ))
                {
                    if (totalDayCalculator.GetHisTotalDayMonthly(
                        stockAddUpSectionCd,
                        out previousTotalDay,
                        out currentTotalDay
                    ).Equals(0))
                    {
                        return previousTotalDay.AddDays(1);
                    }
                }
            }

            return adjustDate;
        }

        #endregion  // <締日チェック/>

        #endregion  // <013.調整日付/>

        #region <014.入力日付/>

        /// <summary>
        /// 入力日付をマージします。
        /// </summary>
        /// <remarks>
        /// システム日付
        /// </remarks>
        /// <param name="stockAdjustWithSlipNo">出荷伝票番号と発注情報の在庫調整データ</param>
        protected void MergeInputDay(SumUpStockAdjustPair stockAdjustWithSlipNo)
        {
            DateTime inputDay = DateTime.Now;
            CurrentStockAdjustRecord.InputDay = inputDay;
        }

        #endregion  // <014.入力日付/>

        // 2009/10/15 Add >>>
        #region <020.仕入金額小計>
        /// <summary>
        /// 仕入金額小計をマージします。
        /// </summary>
        /// <remarks>
        /// 明細の在庫調整金額を集計
        /// </remarks>
        /// <param name="stockAdjustWithSlipNo">出荷伝票番号と発注情報の在庫調整データ</param>
        protected void MergeStockSubttlPrice(SumUpStockAdjustPair stockAdjustWithSlipNo)
        {
            long sum = 0;
            foreach (StockAdjustDtlWork stockAdjustDtlWork in stockAdjustWithSlipNo.Value)
            {
                sum += stockAdjustDtlWork.StockPriceTaxExc;
            }
            CurrentStockAdjustRecord.StockSubttlPrice = sum;
        }
        #endregion
        // 2009/10/15 Add <<<
    }
}

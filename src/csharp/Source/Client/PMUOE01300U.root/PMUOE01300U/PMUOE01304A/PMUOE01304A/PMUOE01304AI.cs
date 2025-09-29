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

using Broadleaf.Application.Controller.Agent;
using Broadleaf.Application.Controller.Util;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.UIData;

namespace Broadleaf.Application.Controller
{
    using StockDB               = SingletonPolicy<StockDBAgent>;
    using StockAdjustDetailPair = KeyValuePair<StockAdjustDtlWork>;

    /// <summary>
    /// 計上情報の在庫調整明細データの構築者クラス
    /// </summary>
    public class SumUpStockAdjustDetailBuilder : SumUpInformationBuilder
    {
        #region <現在の計上情報の在庫調整明細データのレコード/>

        /// <summary>現在の計上情報の在庫調整明細データのレコード</summary>
        private StockAdjustDtlWork _currentStockAdjustDtlRecord;
        /// <summary>
        /// 現在の計上情報の在庫調整明細データのレコードのアクセサ
        /// </summary>
        private StockAdjustDtlWork CurrentStockAdjustDtlRecord
        {
            get { return _currentStockAdjustDtlRecord; }
            set { _currentStockAdjustDtlRecord = value; }
        }

        #endregion  // <現在の計上情報の在庫調整明細データのレコード/>

        /// <summary>在庫調整行番号のカウンタ</summary>
        private int _stockAdjustRowNoCount;

        #region <Constructor/>

        /// <summary>
        /// カスタムコンストラクタ
        /// </summary>
        /// <param name="uoeSupplier">UOE発注先</param>
        public SumUpStockAdjustDetailBuilder(UOESupplierHelper uoeSupplier) : base(uoeSupplier) { }

        #endregion  // <Constructor/>

        #region <Override/>

        /// <summary>
        /// 計上情報の在庫調整明細データに発注情報の仕入明細データをマージします。
        /// </summary>
        public override void Merge()
        {
            // 発注情報から在庫調整データを初期化
            StockDB.Instance.Policy.InitializeSumUpAdjustInformation();

            foreach (int supplierSlipNo in StockDB.Instance.Policy.SumUpStockAdjustDetailRecordMap.Keys)
            {
                _stockAdjustRowNoCount = 0; // 在庫調整行番号のカウンタをリセット

                foreach (StockAdjustDtlWork stockAdjustDtlWork in StockDB.Instance.Policy.SumUpStockAdjustDetailRecordMap[supplierSlipNo])
                {
                    _stockAdjustRowNoCount++;

                    string slipNo = supplierSlipNo.ToString();
                    CurrentStockAdjustDtlRecord = stockAdjustDtlWork;
                    StockAdjustDetailPair stockAdjustDetailRecordWithSlipNo = new StockAdjustDetailPair(
                        slipNo,
                        CurrentStockAdjustDtlRecord
                    );
                    // 発注情報の仕入明細データの内容をマージ
                    MergeStockAdjustRowNo(stockAdjustDetailRecordWithSlipNo);       // 011.在庫調整行番号
                    MergeSupplierFormalSrc(stockAdjustDetailRecordWithSlipNo);      // 012.仕入形式（元）
                    MergeAcPaySlipCd(stockAdjustDetailRecordWithSlipNo);            // 014.受払元伝票区分
                    MergeAcPayTransCd(stockAdjustDetailRecordWithSlipNo);           // 015.受払元取引区分
                    MergeAdjustDate(stockAdjustDetailRecordWithSlipNo);             // 016.調整日付
                    MergeInputDay(stockAdjustDetailRecordWithSlipNo);               // 017.入力日付
                    MergeOpenPriceDiv(stockAdjustDetailRecordWithSlipNo);           // 032.オープン価格区分
                    MergeStockPriceTaxExc(stockAdjustDetailRecordWithSlipNo);       // 033.仕入金額（税抜き）
                }
            }
        }

        #endregion  // <Override/>

        #region <011.在庫調整行番号/>

        /// <summary>
        /// 在庫調整行番号をマージします。
        /// </summary>
        /// <remarks>
        /// 採番
        /// </remarks>
        /// <param name="stockAdjustDetailRecordWithSlipNo">出荷伝票番号と発注情報の在庫調整明細データ</param>
        protected void MergeStockAdjustRowNo(StockAdjustDetailPair stockAdjustDetailRecordWithSlipNo)
        {
            int stockAdjustRowNo = _stockAdjustRowNoCount;
            CurrentStockAdjustDtlRecord.StockAdjustRowNo = stockAdjustRowNo;
        }

        #endregion  // <011.在庫調整行番号/>

        #region <012.仕入形式（元）/>

        /// <summary>
        /// 仕入形式（元）をマージします。
        /// </summary>
        /// <remarks>
        /// 2:発注
        /// </remarks>
        /// <param name="stockAdjustDetailRecordWithSlipNo">出荷伝票番号と発注情報の在庫調整明細データ</param>
        protected void MergeSupplierFormalSrc(StockAdjustDetailPair stockAdjustDetailRecordWithSlipNo)
        {
            int supplierFormalSrc = 2;  // 発注
            CurrentStockAdjustDtlRecord.SupplierFormalSrc = supplierFormalSrc;
        }

        #endregion  // <012.仕入形式（元）/>

        #region <014.受払元伝票区分/>

        /// <summary>
        /// 受払元伝票区分をマージします。
        /// </summary>
        /// <param name="stockAdjustDetailRecordWithSlipNo">出荷伝票番号と発注情報の在庫調整明細データ</param>
        protected void MergeAcPaySlipCd(StockAdjustDetailPair stockAdjustDetailRecordWithSlipNo)
        {
            const int STOCK_STOCK = 13; // 13:在庫仕入
            CurrentStockAdjustDtlRecord.AcPaySlipCd = STOCK_STOCK;
        }

        #endregion  // <014.受払元伝票区分/>

        #region <015.受払元取引区分/>

        /// <summary>
        /// 受払元取引区分をマージします。
        /// </summary>
        /// <remarks>
        /// 10:通常伝票
        /// </remarks>
        /// <param name="stockAdjustDetailRecordWithSlipNo">出荷伝票番号と発注情報の在庫調整明細データ</param>
        protected void MergeAcPayTransCd(StockAdjustDetailPair stockAdjustDetailRecordWithSlipNo)
        {
            const int NORMAL_SLIP = 10; // 10:通常伝票
            const int STOCK_ADJUST= 30; // 30:在庫数調整
            CurrentStockAdjustDtlRecord.AcPayTransCd = STOCK_ADJUST;
        }

        #endregion  // <015.受払元取引区分/>

        #region <016.調整日付/>

        /// <summary>
        /// 調整日付をマージします。
        /// </summary>
        /// <remarks>
        /// システム日付
        /// </remarks>
        /// <param name="stockAdjustDetailRecordWithSlipNo">出荷伝票番号と発注情報の在庫調整明細データ</param>
        protected void MergeAdjustDate(StockAdjustDetailPair stockAdjustDetailRecordWithSlipNo)
        {
            DateTime adjustDate = DateTime.Now;

            // 締日チェック
            adjustDate = SumUpStockAdjustBuilder.GetDayPayment(adjustDate, UoeSupplier);

            CurrentStockAdjustDtlRecord.AdjustDate = adjustDate;
        }

        #endregion  // <016.調整日付/>

        #region <017.入力日付/>

        /// <summary>
        /// 調整日付をマージします。
        /// </summary>
        /// <remarks>
        /// システム日付
        /// </remarks>
        /// <param name="stockAdjustDetailRecordWithSlipNo">出荷伝票番号と発注情報の在庫調整明細データ</param>
        protected void MergeInputDay(StockAdjustDetailPair stockAdjustDetailRecordWithSlipNo)
        {
            DateTime inputDay = DateTime.Now;
            CurrentStockAdjustDtlRecord.InputDay = inputDay;
        }

        #endregion  // <017.入力日付/>

        #region <032.オープン価格区分/>

        /// <summary>
        /// オープン価格区分をマージします。
        /// </summary>
        /// <remarks>
        /// 0:通常
        /// </remarks>
        /// <param name="stockAdjustDetailRecordWithSlipNo">出荷伝票番号と発注情報の在庫調整明細データ</param>
        protected void MergeOpenPriceDiv(StockAdjustDetailPair stockAdjustDetailRecordWithSlipNo)
        {
            const int NORMAL = 0;   // 0:通常
            CurrentStockAdjustDtlRecord.OpenPriceDiv = NORMAL;
        }

        #endregion  // <032.オープン価格区分/>

        #region <033.仕入金額（税抜き）/>

        /// <summary>
        /// 仕入金額（税抜き）をマージします。
        /// </summary>
        /// <remarks>
        /// 回答原価（=仕入単価（税抜, 浮動））×回答数（=調整数）
        /// </remarks>
        /// <param name="stockAdjustDetailRecordWithSlipNo">出荷伝票番号と発注情報の在庫調整明細データ</param>
        protected void MergeStockPriceTaxExc(StockAdjustDetailPair stockAdjustDetailRecordWithSlipNo)
        {
            double answerCostPrice  = CurrentStockAdjustDtlRecord.StockUnitPriceFl;
            double answerCount      = CurrentStockAdjustDtlRecord.AdjustCount;
            CurrentStockAdjustDtlRecord.StockPriceTaxExc = (long)(answerCostPrice * answerCount);
        }

        #endregion  // <033.仕入金額（税抜き）/>
    }
}

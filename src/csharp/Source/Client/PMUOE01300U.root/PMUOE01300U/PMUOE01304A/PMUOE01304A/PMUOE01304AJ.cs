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
// 管理番号              作成担当 : 21024  佐々木 健 
// 作 成 日  2010/10/19  修正内容 : 発注番号をまたがった同一仕入伝票の対応(MANTIS[0015563])
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

using Broadleaf.Application.Controller.Agent;
using Broadleaf.Application.Controller.Util;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Application.Controller
{
    using LoginWorkerAcs    = SingletonPolicy<LoginWorker>;
    using StockDB           = SingletonPolicy<StockDBAgent>;
    using SumUpStockDataPair= KeyValuePair<IList<StockDetailWork>>;
    using SupplierDB        = SingletonPolicy<SupplierDBAgent>;
    // 2010/10/19 Add >>>
    using AllDefSetDB = SingletonPolicy<AllDefSetDBAgent>;
    using TaxRateSetDB = SingletonPolicy<TaxRateSetDBAgent>;
    // 2010/10/19 Add <<<

    /// <summary>
    /// 計上情報の仕入データの構築者クラス
    /// </summary>
    public class SumUpStockDataBuilder : SumUpInformationBuilder
    {
        #region <現在の計上情報の仕入データのレコード/>

        /// <summary>現在の計上情報の仕入データのレコード</summary>
        private StockSlipWork _currentStockSlipRecord;
        /// <summary>
        /// 現在の計上情報の仕入データのレコードのアクセサ
        /// </summary>
        private StockSlipWork CurrentStockSlipRecord
        {
            get { return _currentStockSlipRecord; }
            set { _currentStockSlipRecord = value; }
        }

        #endregion  // <現在の計上情報の仕入データのレコード/>

        #region <Constructor/>

        /// <summary>
        /// カスタムコンストラクタ
        /// </summary>
        /// <param name="uoeSupplier">UOE発注先</param>
        public SumUpStockDataBuilder(UOESupplierHelper uoeSupplier) : base(uoeSupplier) { }

        #endregion  // <Constructor/>

        #region <Override/>

        /// <summary>
        /// 計上情報の仕入データに発注情報の仕入データをマージします。
        /// </summary>
        public override void Merge()
        {
            foreach (int supplierSlipNo in StockDB.Instance.Policy.SumUpStockSlipDetailRecordMap.Keys)
            {
                string slipNo = supplierSlipNo.ToString();
                SumUpStockDataPair stockDataWithSlipNo = new SumUpStockDataPair(
                    slipNo,
                    StockDB.Instance.Policy.SumUpStockSlipDetailRecordMap[supplierSlipNo]
                );

                CurrentStockSlipRecord = StockDB.Instance.Policy.SumUpStockSlipRecordMap[supplierSlipNo];

                // 仕入明細データの内容をマージ
                // 2010/10/19 Add >>>
                MergeEnterpriseCode(stockDataWithSlipNo);	// 003.企業コード
                MergeSubSectionCode(stockDataWithSlipNo);	// 012.部門コード
                MergeDebitNoteNo(stockDataWithSlipNo);		// 013.赤伝区分
                MergeSupplierSlipCd(stockDataWithSlipNo);	// 015.仕入伝票区分
                MergeStockGoodsCd(stockDataWithSlipNo);	// 016.仕入商品区分
                MergeAccPayDivCd(stockDataWithSlipNo);		// 017.買掛区分
                MergeStockSectionCd(stockDataWithSlipNo);	// 018.仕入拠点コード
                MergeStockAddUpSectionCd(stockDataWithSlipNo);	// 019.仕入計上拠点コード
                MergeStockSlipUpdateCd(stockDataWithSlipNo);	// 020.仕入伝票更新区分
                MergeDelayPaymentDiv(stockDataWithSlipNo);	// 025.来勘区分
                MergePayeeCode(stockDataWithSlipNo);		// 026.支払先コード
                MergePayeeSnm(stockDataWithSlipNo);		// 027.支払先略称
                MergeSupplierCd(stockDataWithSlipNo);		// 028.仕入先コード
                MergeSupplierNm1(stockDataWithSlipNo);		// 029.仕入先名1
                MergeSupplierNm2(stockDataWithSlipNo);		// 030.仕入先名2
                MergeSupplierSnm(stockDataWithSlipNo);		// 031.仕入先略称
                MergeBuisinessTypeCode(stockDataWithSlipNo);	// 032.業種コード
                MergeBuisinessTypeName(stockDataWithSlipNo);	// 033.業種名称
                MergeSalesAreaCode(stockDataWithSlipNo);	// 034.販売エリアコード
                MergeSalesAreaName(stockDataWithSlipNo);	// 035.販売エリア名称
                MergeStockInputCode(stockDataWithSlipNo);	// 036.仕入入力者コード
                MergeStockInputName(stockDataWithSlipNo);	// 037.仕入入力者名称
                MergeStockAgentCode(stockDataWithSlipNo);	// 038.仕入担当者コード
                MergeStockAgentName(stockDataWithSlipNo);	// 039.仕入担当者名称
                MergeSuppTtlAmntDspWayCd(stockDataWithSlipNo);	// 040.仕入先総額表示方法区分
                MergeTtlAmntDispRateApy(stockDataWithSlipNo);	// 041.総額表示掛率適用区分
                MergeSuppCTaxLayCd(stockDataWithSlipNo);	// 061.仕入先消費税転嫁方式コード
                MergeSupplierConsTaxRate(stockDataWithSlipNo);	// 062.仕入先消費税税率
                MergeStockFractionProcCd(stockDataWithSlipNo); // 064.仕入端数処理区分
                MergeAutoPayment(stockDataWithSlipNo);		// 065.自動支払区分
                MergePartySaleSlipNum(stockDataWithSlipNo);	// 069.相手先伝票番号
                MergeDetailRowCount(stockDataWithSlipNo);	// 072.明細行数
                MergeUoeRemark1(stockDataWithSlipNo);		// 075.UOEリマーク1
                MergeUoeRemark2(stockDataWithSlipNo);		// 076.UOEリマーク2
                // 2010/10/19 Add <<<

                MergeSupplierFormal(stockDataWithSlipNo);   // 009.仕入形式
                MergeSectionCode(stockDataWithSlipNo);      // 011.拠点コード
                MergeInputDay(stockDataWithSlipNo);         // 021.入力日
                MergeArrivalGoodsDay(stockDataWithSlipNo);  // 022.入荷日
                MergeStockDate(stockDataWithSlipNo);        // 023.仕入日
                MergeStockAddUpADate(stockDataWithSlipNo);  // 024.仕入計上日付
                {
                    // 2010/10/19 Del 発注情報がまたがる事もあるので、必ず集計し直す>>>
                    //// 登録済みの発注情報をベースとする計上情報はそのまま
                    //if (supplierSlipNo > 0)
                    //{
                    //    continue;
                    //}
                    // 2010/10/19 Del <<<

                    // 044.仕入金額（税込み）
                    // 045.仕入金額（税抜き）
                    // 046.仕入正価金額
                    // 047.仕入金額消費税額
                    // 048.仕入外税対象額合計
                    // 049.仕入内税対象額合計
                    // 050.仕入非課税対象額合計
                    // 051.仕入金額消費税額（外税）
                    // 052.仕入金額消費税額（内税）
                    // 053.仕入値引金額計（税抜き）
                    // 054.仕入値引外税対象額合計
                    // 055.仕入値引内税対象額合計
                    // 056.仕入値引非課税対象額合計
                    // 057.仕入値引消費税額（外税）
                    // 058.仕入値引消費税額（内税）
                    CalculateTotalPrice(stockDataWithSlipNo);
                }
            }
        }

        #endregion  // <Override/>

        #region <009.仕入形式/>

        /// <summary>
        /// 仕入形式をマージします。
        /// </summary>
        /// <remarks>
        /// 0:仕入
        /// </remarks>
        /// <param name="stockDataWithSlipNo">伝票番号と仕入データ</param>
        protected void MergeSupplierFormal(SumUpStockDataPair stockDataWithSlipNo)
        {
            const int STOCK = 0;    // 0:仕入
            CurrentStockSlipRecord.SupplierFormal = STOCK;
        }

        #endregion  // <009.仕入形式/>

        #region <011.拠点コード/>

        /// <summary>
        /// 入力日をマージします。
        /// </summary>
        /// <remarks>
        /// ログイン担当者の拠点コード
        /// </remarks>
        /// <param name="stockDataWithSlipNo">伝票番号と仕入データ</param>
        protected void MergeSectionCode(SumUpStockDataPair stockDataWithSlipNo)
        {
            string sectionCode = LoginWorkerAcs.Instance.Policy.SectionProfile.Code;
            CurrentStockSlipRecord.SectionCode = sectionCode;
        }

        #endregion  // <011.拠点コード/>

        #region <021.入力日/>

        /// <summary>
        /// 入力日をマージします。
        /// </summary>
        /// <remarks>
        /// システム日付
        /// </remarks>
        /// <param name="stockDataWithSlipNo">伝票番号と仕入データ</param>
        protected void MergeInputDay(SumUpStockDataPair stockDataWithSlipNo)
        {
            DateTime inputDay = DateTime.Now;
            CurrentStockSlipRecord.InputDay = inputDay;
        }

        #endregion  // <021.入力日/>

        #region <022.出荷日/>

        /// <summary>
        /// 出荷日をマージします。
        /// </summary>
        /// <remarks>
        /// システム日付
        /// </remarks>
        /// <param name="stockDataWithSlipNo">伝票番号と仕入データ</param>
        protected void MergeArrivalGoodsDay(SumUpStockDataPair stockDataWithSlipNo)
        {
            DateTime arrivalGoodsDay = DateTime.Now;
            CurrentStockSlipRecord.ArrivalGoodsDay = arrivalGoodsDay;
        }

        #endregion  // <022.出荷日/>

        #region <023.仕入日/>

        /// <summary>
        /// 仕入日をマージします。
        /// </summary>
        /// <remarks>
        /// 受信日付をセット（2.UOE発注データの受信日付）
        /// </remarks>
        /// <param name="stockDataWithSlipNo">伝票番号と仕入データ</param>
        protected void MergeStockDate(SumUpStockDataPair stockDataWithSlipNo)
        {
            DateTime stockDate = DateTime.Now;
            {
                UOEOrderDtlWork uoeOrderDataRecord = StockDB.Instance.Policy.FindUOEOrderDtlWork(
                    stockDataWithSlipNo.Value[0].DtlRelationGuid
                );
                if (uoeOrderDataRecord != null)
                {
                    stockDate = uoeOrderDataRecord.ReceiveDate;
                }
            }

            stockDate = OrderStockDataBuilder.GetDayPayment(stockDate, CurrentStockSlipRecord);
            CurrentStockSlipRecord.StockDate = stockDate;
        }

        #endregion  // <023.仕入日/>

        #region <024.仕入計上日付/>

        /// <summary>
        /// 仕入計上日付をマージします。
        /// </summary>
        /// <remarks>
        /// 仕入日をセット
        /// </remarks>
        /// <param name="stockDataWithSlipNo">伝票番号と仕入データ</param>
        protected void MergeStockAddUpADate(SumUpStockDataPair stockDataWithSlipNo)
        {
            DateTime stockAddUpADate = CurrentStockSlipRecord.StockDate;
            CurrentStockSlipRecord.StockAddUpADate = stockAddUpADate;
        }

        #endregion  // <024.仕入計上日付/>

        #region <044～058.仕入データの情報算出/>

        /// <summary>
        /// 総合表示区分セット部を算出します。
        /// </summary>
        /// <remarks>
        /// ※別紙　総合表示区分セット仕様を参照
        /// </remarks>
        /// <param name="stockDataWithSlipNo">伝票番号と仕入データ</param>
        protected void CalculateTotalPrice(SumUpStockDataPair stockDataWithSlipNo)
        {
            Supplier supplier = SupplierDB.Instance.Policy.Find(UoeSupplier);
            if (supplier == null) return;

            List<StockDetailWork> stockDetailWorkList = (List<StockDetailWork>)stockDataWithSlipNo.Value;

            PrintTotalPrice(CurrentStockSlipRecord);

            UoeSndRcvComponent.CalculateTotalPrice(
                ref _currentStockSlipRecord,
                stockDetailWorkList,
                supplier.StockCnsTaxFrcProcCd
            );

            PrintTotalPrice(CurrentStockSlipRecord);
        }

        /// <summary>
        /// 総合表示区分セット部を表示します。
        /// </summary>
        /// <param name="stockSlipWork">仕入データ</param>
        [Conditional("DEBUG")]
        private static void PrintTotalPrice(StockSlipWork stockSlipWork)
        {
            StringBuilder str = new StringBuilder();
            {
                str.Append("仕入金額計（税込み）：").Append(stockSlipWork.StockTtlPricTaxInc).Append(Environment.NewLine);
                str.Append("仕入金額計（税抜き）：").Append(stockSlipWork.StockTtlPricTaxExc).Append(Environment.NewLine);
                str.Append("仕入正価金額：").Append(stockSlipWork.StockNetPrice).Append(Environment.NewLine);
                str.Append("仕入金額消費税額：").Append(stockSlipWork.StockPriceConsTax).Append(Environment.NewLine);
                str.Append("仕入外税対象額合計：").Append(stockSlipWork.TtlItdedStcOutTax).Append(Environment.NewLine);
                str.Append("仕入内税対象額合計：").Append(stockSlipWork.TtlItdedStcInTax).Append(Environment.NewLine);
                str.Append("仕入非課税対象額合計：").Append(stockSlipWork.TtlItdedStcTaxFree).Append(Environment.NewLine);
                str.Append("仕入金額消費税額（外税）：").Append(stockSlipWork.StockOutTax).Append(Environment.NewLine);
                str.Append("仕入金額消費税額（内税）：").Append(stockSlipWork.StckPrcConsTaxInclu).Append(Environment.NewLine);
                str.Append("仕入金額消費税額（税抜き）：").Append(stockSlipWork.StckDisTtlTaxExc).Append(Environment.NewLine);
                str.Append("仕入値引外税対象額合計：").Append(stockSlipWork.ItdedStockDisOutTax).Append(Environment.NewLine);
                str.Append("仕入値引内税対象額合計：").Append(stockSlipWork.ItdedStockDisInTax).Append(Environment.NewLine);
                str.Append("仕入値引非課税対象額合計：").Append(stockSlipWork.ItdedStockDisTaxFre).Append(Environment.NewLine);
                str.Append("仕入値引消費税額（外税）：").Append(stockSlipWork.StockDisOutTax).Append(Environment.NewLine);
                str.Append("仕入値引消費税額（内税）：").Append(stockSlipWork.StckDisTtlTaxInclu).Append(Environment.NewLine);
            }
            Debug.WriteLine(str.ToString());
        }

        #endregion  // <044～058.仕入データの情報算出/>

        // 2010/10/19 Add >>>

        #region <003.企業コード/>

        /// <summary>
        /// 企業コードをマージします。
        /// </summary>
        /// <param name="stockDataWithSlipNo">伝票番号と受信電文</param>
        protected void MergeEnterpriseCode(SumUpStockDataPair stockDataWithSlipNo)
        {
            string enterpriseCode = LoginWorkerAcs.Instance.Policy.EnterpriseProfile.Code;
            CurrentStockSlipRecord.EnterpriseCode = enterpriseCode;
        }

        #endregion

        #region <012.部門コード/>

        /// <summary>
        /// 部門コードをマージします。
        /// </summary>
        /// <remarks>
        /// 担当者の所属部門コード
        /// </remarks>
        /// <param name="stockDataWithSlipNo">伝票番号と受信電文</param>
        protected void MergeSubSectionCode(SumUpStockDataPair stockDataWithSlipNo)
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
        protected void MergeDebitNoteNo(SumUpStockDataPair stockDataWithSlipNo)
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
        protected void MergeSupplierSlipCd(SumUpStockDataPair stockDataWithSlipNo)
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
        protected void MergeStockGoodsCd(SumUpStockDataPair stockDataWithSlipNo)
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
        protected void MergeAccPayDivCd(SumUpStockDataPair stockDataWithSlipNo)
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
        protected void MergeStockSectionCd(SumUpStockDataPair stockDataWithSlipNo)
        {
            // 仕入拠点コードをマージ
            string stockSectionCd = GetStockSectionCd(stockDataWithSlipNo);
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
        protected string GetStockSectionCd(SumUpStockDataPair stockDataWithSlipNo)
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
                        UOEOrderDtlWork uoeOrderDetail = StockDB.Instance.Policy.FindUOEOrderDtlWork(stockDataWithSlipNo.Value[0].DtlRelationGuid);
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
        protected void MergeStockAddUpSectionCd(SumUpStockDataPair stockDataWithSlipNo)
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
        protected void MergeStockSlipUpdateCd(SumUpStockDataPair stockDataWithSlipNo)
        {
            // TODO1
            const int NOT_UPDATE = 0;   // 0:未更新
            CurrentStockSlipRecord.StockSlipUpdateCd = NOT_UPDATE;
        }

        #endregion  // <020.仕入伝票更新区分/>

        #region <025.来勘区分/>

        /// <summary>
        /// 来勘区分をマージします。
        /// </summary>
        /// <remarks>
        /// 0:当月
        /// </remarks>
        /// <param name="stockDataWithSlipNo">伝票番号と受信電文</param>
        protected void MergeDelayPaymentDiv(SumUpStockDataPair stockDataWithSlipNo)
        {
            // TODO1
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
        protected void MergePayeeCode(SumUpStockDataPair stockDataWithSlipNo)
        {
            // TODO1
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
        protected void MergePayeeSnm(SumUpStockDataPair stockDataWithSlipNo)
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
        protected void MergeSupplierCd(SumUpStockDataPair stockDataWithSlipNo)
        {
            UOEOrderDtlWork uoeOrderRecord = StockDB.Instance.Policy.FindUOEOrderDtlWork(stockDataWithSlipNo.Value[0].DtlRelationGuid);
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
        protected void MergeSupplierNm1(SumUpStockDataPair stockDataWithSlipNo)
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
        protected void MergeSupplierNm2(SumUpStockDataPair stockDataWithSlipNo)
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
        protected void MergeSupplierSnm(SumUpStockDataPair stockDataWithSlipNo)
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
        protected void MergeBuisinessTypeCode(SumUpStockDataPair stockDataWithSlipNo)
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
        protected void MergeBuisinessTypeName(SumUpStockDataPair stockDataWithSlipNo)
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
        protected void MergeSalesAreaCode(SumUpStockDataPair stockDataWithSlipNo)
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
        protected void MergeSalesAreaName(SumUpStockDataPair stockDataWithSlipNo)
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
        protected void MergeStockInputCode(SumUpStockDataPair stockDataWithSlipNo)
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
        protected void MergeStockInputName(SumUpStockDataPair stockDataWithSlipNo)
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
        protected void MergeStockAgentCode(SumUpStockDataPair stockDataWithSlipNo)
        {
            UOEOrderDtlWork uoeOrderRecord = StockDB.Instance.Policy.FindUOEOrderDtlWork(stockDataWithSlipNo.Value[0].DtlRelationGuid);
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
        protected void MergeStockAgentName(SumUpStockDataPair stockDataWithSlipNo)
        {
            UOEOrderDtlWork uoeOrderRecord = StockDB.Instance.Policy.FindUOEOrderDtlWork(stockDataWithSlipNo.Value[0].DtlRelationGuid);
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
        protected void MergeSuppTtlAmntDspWayCd(SumUpStockDataPair stockDataWithSlipNo)
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
        protected void MergeTtlAmntDispRateApy(SumUpStockDataPair stockDataWithSlipNo)
        {
            int ttlAmntDispRateApy = AllDefSetDB.Instance.Policy.AllDefSet.TtlAmntDspRateDivCd;
            CurrentStockSlipRecord.TtlAmntDispRateApy = ttlAmntDispRateApy;
        }

        #endregion  // <041.総額表示掛率適用区分/>

        #region <061.仕入先消費税転嫁方式コード/>

        /// <summary>
        /// 仕入先消費税転嫁方式コードをマージします。
        /// </summary>
        /// <remarks>
        /// 仕入先マスタの仕入先消費税転嫁方式コード
        /// </remarks>
        /// <param name="stockDataWithSlipNo">伝票番号と受信電文</param>
        protected void MergeSuppCTaxLayCd(SumUpStockDataPair stockDataWithSlipNo)
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
        protected void MergeSupplierConsTaxRate(SumUpStockDataPair stockDataWithSlipNo)
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
        protected void MergeStockFractionProcCd(SumUpStockDataPair stockDataWithSlipNo)
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
        protected void MergeAutoPayment(SumUpStockDataPair stockDataWithSlipNo)
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
        protected void MergePartySaleSlipNum(SumUpStockDataPair stockDataWithSlipNo)
        {
            // TODO
            UOEOrderDtlWork uoeOrderRecord = StockDB.Instance.Policy.FindUOEOrderDtlWork(stockDataWithSlipNo.Value[0].DtlRelationGuid);

            if (uoeOrderRecord != null)
            {
                string partySaleSlipNum = uoeOrderRecord.UOESectionSlipNo;
                CurrentStockSlipRecord.PartySaleSlipNum = partySaleSlipNum;
            }
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
        protected void MergeDetailRowCount(SumUpStockDataPair stockDataWithSlipNo)
        {
            int detailRowCount = stockDataWithSlipNo.Value.Count;
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
        protected void MergeUoeRemark1(SumUpStockDataPair stockDataWithSlipNo)
        {
            UOEOrderDtlWork uoeOrderRecord = StockDB.Instance.Policy.FindUOEOrderDtlWork(stockDataWithSlipNo.Value[0].DtlRelationGuid);
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
        protected void MergeUoeRemark2(SumUpStockDataPair stockDataWithSlipNo)
        {
            UOEOrderDtlWork uoeOrderRecord = StockDB.Instance.Policy.FindUOEOrderDtlWork(stockDataWithSlipNo.Value[0].DtlRelationGuid);
            if (uoeOrderRecord != null)
            {
                string uoeRemark2 = uoeOrderRecord.UoeRemark2;
                CurrentStockSlipRecord.UoeRemark2 = uoeRemark2;
            }
        }

        #endregion  // <076.UOEリマーク2/>

        // 2010/10/19 Add <<<
    }
}

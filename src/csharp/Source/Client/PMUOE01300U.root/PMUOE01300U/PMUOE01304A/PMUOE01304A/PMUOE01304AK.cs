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
using System.Diagnostics;

using Broadleaf.Application.Controller.Agent;
using Broadleaf.Application.Controller.Util;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.UIData;

namespace Broadleaf.Application.Controller
{
    using StockDB           = SingletonPolicy<StockDBAgent>;
    using LoginWorkerAcs    = SingletonPolicy<LoginWorker>;
    using StockDetailPair   = KeyValuePair<StockDetailWork>; 

    /// <summary>
    /// 計上情報の仕入明細データの構築者クラス
    /// </summary>
    public class SumUpStockDetailDataBuilder : SumUpInformationBuilder
    {
        #region <現在の計上情報の仕入明細データのレコード/>

        /// <summary>現在の計上情報の仕入明細データのレコード</summary>
        private StockDetailWork _currentStockDetailRecord;
        /// <summary>
        /// 現在の計上情報の仕入明細データのレコードのアクセサ
        /// </summary>
        private StockDetailWork CurrentStockDetailRecord
        {
            get { return _currentStockDetailRecord; }
            set { _currentStockDetailRecord = value; }
        }

        #endregion  // <現在の計上情報の仕入明細データのレコード/>

        #region <Constructor/>

        /// <summary>
        /// カスタムコンストラクタ
        /// </summary>
        /// <param name="uoeSupplier">UOE発注先</param>
        public SumUpStockDetailDataBuilder(UOESupplierHelper uoeSupplier) : base(uoeSupplier) { }

        #endregion  // <Constructor/>

        #region <Override/>

        /// <summary>
        /// 計上情報の仕入明細データに発注情報の仕入明細データをマージします。
        /// </summary>
        public override void Merge()
        {
            // 発注情報から仕入データ（計上）を初期化
            StockDB.Instance.Policy.InitializeSumUpStockInformation();

            foreach (int supplierSlipNo in StockDB.Instance.Policy.SumUpStockSlipDetailRecordMap.Keys)
            {
                int rowNo = 1;  // 2010/10/19 Add
                foreach (StockDetailWork stockDetailWork in StockDB.Instance.Policy.SumUpStockSlipDetailRecordMap[supplierSlipNo])
                {
                    string slipNo = supplierSlipNo.ToString();
                    CurrentStockDetailRecord = stockDetailWork;
                    StockDetailPair stockDetailRecordWithSlipNo = new StockDetailPair(slipNo, CurrentStockDetailRecord);

                    //// 登録済みの発注情報をベースとする計上情報はそのまま
                    //if (supplierSlipNo > 0)
                    //{
                    //    MergeSupplierFormalSrc(stockDetailRecordWithSlipNo);// 017.仕入形式（元）
                    //    continue;
                    //}

                    // 発注情報の仕入明細データの内容をマージ
                    MergeSupplierFormal(stockDetailRecordWithSlipNo);       // 010.仕入形式
                    MergeSectionCode(stockDetailRecordWithSlipNo);          // 013.拠点コード
                    MergeSupplierFormalSrc(stockDetailRecordWithSlipNo);    // 017.仕入形式（元）
                    MergeStockSlipDtlNumSrc(stockDetailRecordWithSlipNo);   // 018.仕入明細通番（元）
                    MergeAcptAnOdrStatusSync(stockDetailRecordWithSlipNo);  // 019.受注ステータス（同時）
                    MergeSalesSlipDtlNumSync(stockDetailRecordWithSlipNo);  // 020.売上明細通番（同時）
                    {
                        MergeStockCount(stockDetailRecordWithSlipNo);       // 073.仕入数
                    }
                    MergeOrderCnt(stockDetailRecordWithSlipNo);             // 074.発注数量
                    MergeOrderAdjustCnt(stockDetailRecordWithSlipNo);       // 075.発注調整数
                    MergeOrderRemainCnt(stockDetailRecordWithSlipNo);       // 076.発注残数
                    MergeStockPriceConsTax(stockDetailRecordWithSlipNo);    // 081.仕入金額消費税額

                    CurrentStockDetailRecord.StockRowNo = rowNo++;          // 2010/10/19 Add
                }
            }
        }

        #endregion  // <Override/>

        #region <010.仕入形式/>

        /// <summary>
        /// 仕入形式をマージします。
        /// </summary>
        /// <remarks>
        /// 0:仕入
        /// </remarks>
        /// <param name="stockDetailRecordWithSlipNo">出荷伝票番号と発注情報の仕入明細データ</param>
        protected void MergeSupplierFormal(StockDetailPair stockDetailRecordWithSlipNo)
        {
            const int STOCK = 0;    // 0:仕入
            CurrentStockDetailRecord.SupplierFormal = STOCK;
        }

        #endregion  // <010.仕入形式/>

        #region <013.拠点コード/>

        /// <summary>
        /// 拠点コードをマージします。
        /// </summary>
        /// <remarks>
        /// UOE自社設定マスタの卸商拠点設定区分に従いセット
        /// </remarks>
        /// <param name="stockDetailRecordWithSlipNo">出荷伝票番号と発注情報の仕入明細データ</param>
        protected void MergeSectionCode(StockDetailPair stockDetailRecordWithSlipNo)
        {
            string sectionCode = GetSectionCodeFromUOESetting();
            if (!string.IsNullOrEmpty(sectionCode))
            {
                CurrentStockDetailRecord.SectionCode = sectionCode;
            }
        }

        #endregion  // <013.拠点コード/>

        #region <017.仕入形式（元）/>

        /// <summary>
        /// 仕入形式（元）をマージします。
        /// </summary>
        /// <remarks>
        /// 計上元の仕入形式
        /// </remarks>
        /// <param name="stockDetailRecordWithSlipNo">出荷伝票番号と発注情報の仕入明細データ</param>
        protected void MergeSupplierFormalSrc(StockDetailPair stockDetailRecordWithSlipNo)
        {
            const int ORDER = 2;    // 発注
            int supplierFormalSrc = ORDER;
            CurrentStockDetailRecord.SupplierFormalSrc = supplierFormalSrc;
        }

        #endregion  // <017.仕入形式（元）/>

        #region <018.仕入明細通番（元）/>

        /// <summary>
        /// 仕入明細通番（元）をマージします。
        /// </summary>
        /// <remarks>
        /// 計上元の仕入明細通番
        /// </remarks>
        /// <param name="stockDetailRecordWithSlipNo">出荷伝票番号と発注情報の仕入明細データ</param>
        protected void MergeStockSlipDtlNumSrc(StockDetailPair stockDetailRecordWithSlipNo)
        {
            long stockSlipDtlNumSrc = stockDetailRecordWithSlipNo.Value.StockSlipDtlNum;
            CurrentStockDetailRecord.StockSlipDtlNumSrc = stockSlipDtlNumSrc;
        }

        #endregion  // <018.仕入明細通番（元）/>

        #region <019.受注ステータス（同時）/>

        /// <summary>
        /// 受注ステータス（同時）をマージします。
        /// </summary>
        /// <remarks>
        /// 未設定とする
        /// </remarks>
        /// <param name="stockDetailRecordWithSlipNo">出荷伝票番号と発注情報の仕入明細データ</param>
        protected void MergeAcptAnOdrStatusSync(StockDetailPair stockDetailRecordWithSlipNo)
        {
            int acptAnOdrStatusSync = 0;
            CurrentStockDetailRecord.AcptAnOdrStatusSync = acptAnOdrStatusSync;
        }

        #endregion  // <019.受注ステータス（同時）/>

        #region <020.売上明細通番（同時）/>

        /// <summary>
        /// 売上明細通番（同時）をマージします。
        /// </summary>
        /// <remarks>
        /// 未設定とする
        /// </remarks>
        /// <param name="stockDetailRecordWithSlipNo">出荷伝票番号と発注情報の仕入明細データ</param>
        protected void MergeSalesSlipDtlNumSync(StockDetailPair stockDetailRecordWithSlipNo)
        {
            long salesSlipDtlNumSync = 0;
            CurrentStockDetailRecord.SalesSlipDtlNumSync = salesSlipDtlNumSync;
        }

        #endregion  // <020.売上明細通番（同時）/>

        #region <073.仕入数/>

        /// <summary>
        /// 仕入数をマージします。
        /// </summary>
        /// <remarks>
        /// UOE発注データのUOE拠点出庫数
        /// </remarks>
        /// <param name="stockDetailRecordWithSlipNo">出荷伝票番号と発注情報の仕入明細データ</param>
        protected void MergeStockCount(StockDetailPair stockDetailRecordWithSlipNo)
        {
            UOEOrderDtlWork uoeOrderDataRecord = StockDB.Instance.Policy.FindUOEOrderDtlWork(
                stockDetailRecordWithSlipNo.Value.DtlRelationGuid
            );
            double stockCount = 0.0;
            if (uoeOrderDataRecord != null)
            {
                stockCount = (double)uoeOrderDataRecord.UOESectOutGoodsCnt;
            }
            else
            {
                stockCount = stockDetailRecordWithSlipNo.Value.OrderRemainCnt;
            }
            CurrentStockDetailRecord.StockCount = stockCount;
        }

        #endregion  // <073.仕入数/>

        #region <074.発注数量/>

        /// <summary>
        /// 発注数量をマージします。
        /// </summary>
        /// <remarks>
        /// 仕入数と同じ
        /// </remarks>
        /// <param name="stockDetailRecordWithSlipNo">出荷伝票番号と発注情報の仕入明細データ</param>
        protected void MergeOrderCnt(StockDetailPair stockDetailRecordWithSlipNo)
        {
            double orderCnt = CurrentStockDetailRecord.StockCount;
            CurrentStockDetailRecord.OrderCnt = orderCnt;
        }

        #endregion  // <074.発注数量/>

        #region <075.発注調整数/>

        /// <summary>
        /// 発注調整数をマージします。
        /// </summary>
        /// <remarks>
        /// 0
        /// </remarks>
        /// <param name="stockDetailRecordWithSlipNo">出荷伝票番号と発注情報の仕入明細データ</param>
        protected void MergeOrderAdjustCnt(StockDetailPair stockDetailRecordWithSlipNo)
        {
            CurrentStockDetailRecord.OrderAdjustCnt = 0;
        }

        #endregion  // <075.発注調整数/>

        #region <076.発注残数/>

        /// <summary>
        /// 発注残数をマージします。
        /// </summary>
        /// <remarks>
        /// 仕入数と同じ
        /// </remarks>
        /// <param name="stockDetailRecordWithSlipNo">出荷伝票番号と発注情報の仕入明細データ</param>
        protected void MergeOrderRemainCnt(StockDetailPair stockDetailRecordWithSlipNo)
        {
            double orderRemainCnt = CurrentStockDetailRecord.StockCount;
            CurrentStockDetailRecord.OrderRemainCnt = orderRemainCnt;
        }

        #endregion  // <076.発注残数/>

        #region <081.仕入金額消費税額/>

        /// <summary>
        /// 仕入金額消費税額をマージします。
        /// </summary>
        /// <remarks>
        /// 仕入金額（税込み） - 仕入金額（税抜き）
        /// </remarks>
        /// <param name="stockDetailRecordWithSlipNo">出荷伝票番号と発注情報の仕入明細データ</param>
        protected void MergeStockPriceConsTax(StockDetailPair stockDetailRecordWithSlipNo)
        {
            long stockPriceConsTax = CurrentStockDetailRecord.StockPriceTaxInc - CurrentStockDetailRecord.StockPriceTaxExc;
            CurrentStockDetailRecord.StockPriceConsTax = stockPriceConsTax;
        }

        #endregion  // <081.仕入金額消費税額/>
    }
}

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

using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.UIData;

namespace Broadleaf.Application.Controller.Agent
{
    /// <summary>
    /// UOE送受信処理の再利用部品クラス
    /// </summary>
    public sealed class UOESendReceiveComponent
    {
        #region <UOE発注データアクセス/>

        /// <summary>UOE発注データアクセス</summary>
        /// <remarks>送信処理のクラスの再利用</remarks>
        private readonly UOEOrderDtlAcs _uoeOoderDtlAcs;
        /// <summary>
        /// UOE発注データアクセスを取得します。
        /// </summary>
        /// <value>UOE発注データアクセス</value>
        private UOEOrderDtlAcs UoeOoderDtlAcs { get { return _uoeOoderDtlAcs; } }

        #endregion  // <UOE発注データアクセス/>

        #region <Constructor/>

        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        public UOESendReceiveComponent()
        {
            _uoeOoderDtlAcs = new UOEOrderDtlAcs();
        }

        #endregion  // <Constructor/>

        #region <送受信/>

        /// <summary>
        /// 仕入要求電文の応答（受信テキスト）を受信します。
        /// </summary>
        /// <param name="uoeSndRcvCtlPara">UOE送受信制御パラメータ</param>
        /// <param name="uoeSndHedList">送信電文のリスト</param>
        /// <param name="receivingUOESupplier">受信するUOE発注先</param>
        /// <param name="uoeRecHed">応答</param>
        /// <param name="errorMessage">エラーメッセージ</param>
        /// <returns>ステータス</returns>
        public static int ReceiveUOEStockRequestText(
            UoeSndRcvCtlPara uoeSndRcvCtlPara,
            List<UoeSndHed> uoeSndHedList,
            EnumUoeConst.ReceivingUOESupplier receivingUOESupplier,
            out UoeRecHed uoeRecHed,
            out string errorMessage
        )
        {
            UoeSndRcvCtlAcs realSendReceiveControlAcs = new UoeSndRcvCtlAcs();
            int status = realSendReceiveControlAcs.ReceiveUOEStockRequestTextAndInsertJNL(
                uoeSndRcvCtlPara,
                uoeSndHedList,
                receivingUOESupplier,
                out uoeRecHed,
                out errorMessage
            );
            // JNLのDataSetをインスタンス化していないため、UoeSndRcvCtlAcs.ReceiveUOEStockRequestTextAndInsertJNL()は 4 を返す
            if (status.Equals((int)Result.RemoteStatus.NotFound))
            {
                status = (int)Result.RemoteStatus.Normal;
            }
            // 送受信クラス側でメッセージを出力するため、戻り値を加工
            if (!status.Equals((int)Result.RemoteStatus.Normal) || uoeRecHed == null || uoeRecHed.UoeRecDtlList.Count.Equals(0))
            {
                status = (int)Result.Code.Abort;
            }
            else
            {
                status = (int)Result.Code.Normal;
            }

            return status;
        }

        #endregion  // <送受信/>

        #region <税込金額の取得/>

        /// <summary>
        /// 仕入税込金額を取得します。
        /// </summary>
        /// <remarks>
        /// [再利用元]<br/>
        /// PMUOE01046AA.cs::UOEOrderDtlAcs.GetStockPriceTaxInc()
        /// </remarks>
        /// <param name="targetPrice">対象金額</param>
        /// <param name="taxationCode">課税区分</param>
        /// <param name="stockCnsTaxFrcProcCd">仕入消費税端数処理コード</param>
        /// <returns>税込み金額</returns>
        public double GetStockPriceTaxInc(
            double targetPrice,
            int taxationCode,
            int stockCnsTaxFrcProcCd
        )
        {
            return UoeOoderDtlAcs.GetStockPriceTaxInc(targetPrice, taxationCode, stockCnsTaxFrcProcCd);
        }

        /// <summary>
        /// 仕入金額を計算します。
        /// </summary>
        /// <remarks>
        /// [再利用元]<br/>
        /// PMUOE01046AA.cs::UOEOrderDtlAcs.CalculationStockPrice()
        /// </remarks>
        /// <param name="stockCount">仕入数</param>
        /// <param name="stockUnitPrice">仕入単価</param>
        /// <param name="taxationCode">課税区分</param>
        /// <param name="stockMoneyFrcProcCd">仕入金額端数処理コード</param>
        /// <param name="taxFracProcCode">消費税端数処理区分</param>
        /// <param name="stockPriceTaxInc">仕入金額（税込み）</param>
        /// <param name="stockPriceTaxExc">仕入金額（税抜き）</param>
        /// <param name="stockPriceConsTax">仕入消費税</param>
        /// <returns>
        /// <c>true</c> :成功<br/>
        /// <c>false</c>:失敗
        /// </returns>
        public bool CalculationStockPrice(
            double stockCount,
            double stockUnitPrice,
            int taxationCode,
            int stockMoneyFrcProcCd,
            int taxFracProcCode,
            out long stockPriceTaxInc,
            out long stockPriceTaxExc,
            out long stockPriceConsTax
        )
        {
            return UoeOoderDtlAcs.CalculationStockPrice(
                stockCount,
                stockUnitPrice,
                taxationCode,
                stockMoneyFrcProcCd,
                taxFracProcCode,
                out stockPriceTaxInc,
                out stockPriceTaxExc,
                out stockPriceConsTax
            );
        }

        #endregion  // <税込金額の取得/>

        #region <総額表示区分セット/>

        /// <summary>
        /// 仕入データの合計情報を算出します。
        /// </summary>
        /// <remarks>
        /// [再利用元]<br/>
        /// PMUOE01048AA.cs::UOESalesStockAcs.uoeStockSlipCreate()
        /// </remarks>
        /// <param name="stockSlipWork">仕入データのレコード</param>
        /// <param name="stockDetailWorkList">仕入明細データのリスト</param>
        /// <param name="stockCnsTaxFrcProcCd">仕入消費税端数処理コード</param>
        public void CalculateTotalPrice(
            ref StockSlipWork stockSlipWork,
            List<StockDetailWork> stockDetailWorkList,
            int stockCnsTaxFrcProcCd
        )
        {
            // 端数処理単位
            StockProcMoney stockProcMoney = UoeOoderDtlAcs.GetStockProcMoney(
                1,  // TODO:Magic Number
                stockCnsTaxFrcProcCd,
                999999999.0
            );

            // 仕入データの情報算出
            StockSlipPriceCalculator.TotalPriceSetting(
                ref stockSlipWork,
                stockDetailWorkList,
                stockProcMoney.FractionProcUnit,
                stockCnsTaxFrcProcCd
            ); // TODO:044～058?
        }

        #endregion  // <総額表示区分セット/>

        #region <仕入データの情報算出/>

        /// <summary>
        /// 仕入金額処理区分設定マスタのレコードを取得します。
        /// </summary>
        /// <remarks>
        /// [再利用元]<br/>
        /// PMUOE01046AA.cs::UOEOrderDtlAcs.GetStockProcMoney()<br/>
        /// PMUOE01047AA.cs::UOEAnswerAcs.GetStockSlipWorkFromStockDetailDataTable()
        /// </remarks>
        /// <param name="fractionProcCode">端数処理コード</param>
        /// <returns>仕入金額処理区分設定マスタのレコード</returns>
        public StockProcMoney GetStockProcMoney(int fractionProcCode)
        {
            return UoeOoderDtlAcs.GetStockProcMoney(1, fractionProcCode, 999999999);
        }

        #endregion  // <仕入データの情報算出/>
    }
}

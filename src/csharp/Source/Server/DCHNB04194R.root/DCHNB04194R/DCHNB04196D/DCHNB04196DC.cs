using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   CustSalesAnnualDataSelectResultWork
    /// <summary>
    ///                      得意先別売上年間実績照会抽出結果クラスワークワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   得意先別売上年間実績照会抽出結果クラスワークワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/12/17  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class CustSalesAnnualDataSelectResultWork 
    {
        /// <summary>計上年月</summary>
        /// <remarks>YYYYMM</remarks>
        private Int32 _aUPYearMonth;

        /// <summary>売上伝票区分</summary>
        /// <remarks>0:売上,1:返品,2:値引,3:注釈,4:小計,5:作業　※得意先別のみ使用</remarks>
        private Int32 _salesSlipCdDtl;

        /// <summary>売上在庫取寄区分 </summary>
        /// <remarks>0:取寄、1:在庫　※得意先別のみ使用</remarks>
        private Int32 _salesOrderDivCd;

        /// <summary>商品属性</summary>
        /// <remarks>0:純正、1:その他　※得意先別のみ使用</remarks>
        private Int32 _goodsKindCode;

        /// <summary>売上金額（税抜き）(純正,基本)</summary>
        /// <remarks>売上金額（税抜き）</remarks>
        private Int64 _salesMoneyTaxExc;

        /// <summary>返品額(純正,基本)</summary>
        private Int64 _salesRetGoodsPrice;

        /// <summary>値引金額(純正,基本)</summary>
        private Int64 _discountPrice;

        /// <summary>粗利額(純正,基本)</summary>
        private Int64 _grossProfit;

        /// <summary>売上目標額</summary>
        /// <remarks>※同一計上年月のレコードには同じ値がセットされます</remarks>
        private Int64 _salesTargetMoney;

        /// <summary>粗利目標額</summary>
        /// <remarks>※同一計上年月のレコードには同じ値がセットされます</remarks>
        private Int64 _salesTargetProfit;

        /// <summary>売上回数</summary>
        /// <remarks>出荷回数(売上時のみ）</remarks>
        private Int32 _salesTimes;

        /// <summary>期間伝票枚数</summary>
        /// <remarks>※同一計上年月のレコードには同じ値がセットされます</remarks>
        private Int32 _termSalesSlipCount;

        /// <summary>原価</summary>
        private Int64 _cost;

        /// <summary>前回請求金額</summary>
        private Int64 _lastTimeDemand;

        /// <summary>前回売掛金額</summary>
        private Int64 _lastTimeAccRec;

        /// <summary>受注2回前残高（請求計）</summary>
        private Int64 _acpOdrTtl2TmBfBlDmd;

        /// <summary>受注3回前残高（請求計）</summary>
        private Int64 _acpOdrTtl3TmBfBlDmd;

        /// <summary>売上伝票枚数</summary>
        /// <remarks>掛売の伝票枚数</remarks>
        private Int32 _salesSlipCount;

        /// <summary>請求入金情報(現金)</summary>
        private Int64 _casheDeposit;

        /// <summary>請求入金情報(振込)</summary>
        private Int64 _trfrDeposit;

        /// <summary>請求入金情報(小切手)</summary>
        private Int64 _checkKDeposit;

        /// <summary>請求入金情報(手形)</summary>
        private Int64 _draftDeposit;

        /// <summary>請求入金情報(相殺)</summary>
        private Int64 _offsetDeposit;

        /// <summary>請求入金情報(口座振替)</summary>
        private Int64 _fundtransferDeposit;

        /// <summary>請求入金情報(E-Money)</summary>
        private Int64 _emoneyDeposit;

        /// <summary>請求入金情報(その他)</summary>
        private Int64 _otherDeposit;

        /// <summary>請求入金情報(手数料)</summary>
        private Int64 _thisTimeFeeDmdNrml;

        /// <summary>請求入金情報(値引)</summary>
        private Int64 _thisTimeDisDmdNrml;

        /// <summary>請求消費税</summary>
        private Int64 _ofsThisSalesTax;

        /// <summary>当月入金情報(現金)</summary>
        private Int64 _thisMCasheDeposit;

        /// <summary>当月入金情報(振込)</summary>
        private Int64 _thisMhTrfrDeposit;

        /// <summary>当月入金情報(小切手)</summary>
        private Int64 _thisMCheckKDeposit;

        /// <summary>当月入金情報(手形)</summary>
        private Int64 _thisMDraftDeposit;

        /// <summary>当月入金情報(相殺)</summary>
        private Int64 _thisMOffsetDeposit;

        /// <summary>当月入金情報(口座振替)</summary>
        private Int64 _thisMFundtransferDeposit;

        /// <summary>当月入金情報(E-Money)</summary>
        private Int64 _thisMEmoneyDeposit;

        /// <summary>当月入金情報(その他)</summary>
        private Int64 _thisMOtherDeposit;

        /// <summary>当月入金情報(手数料)</summary>
        private Int64 _thisMThisTimeFeeDmdNrml;

        /// <summary>当月入金情報(値引)</summary>
        private Int64 _thisMThisTimeDisDmdNrml;

        /// <summary>当月消費税</summary>
        private Int64 _thisMOfsThisSalesTax;

        /// <summary>請求区分</summary>
        private Int32 _claimDiv;

        /// <summary>売上金額（税抜き)(優良)</summary>
        /// <remarks>売上金額（税抜き）</remarks>
        private Int64 _exSalesMoneyTaxExc;

        /// <summary>返品額(優良)</summary>
        private Int64 _exSalesRetGoodsPrice;

        /// <summary>値引金額(優良)</summary>
        private Int64 _exDiscountPrice;

        /// <summary>粗利額(優良)</summary>
        private Int64 _exGrossProfit;


        /// public propaty name  :  AUPYearMonth
        /// <summary>計上年月プロパティ</summary>
        /// <value>YYYYMM</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   計上年月プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 AUPYearMonth
        {
            get { return _aUPYearMonth; }
            set { _aUPYearMonth = value; }
        }

        /// public propaty name  :  SalesSlipCdDtl
        /// <summary>売上伝票区分プロパティ</summary>
        /// <value>0:売上,1:返品,2:値引,3:注釈,4:小計,5:作業　※得意先別のみ使用</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上伝票区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SalesSlipCdDtl
        {
            get { return _salesSlipCdDtl; }
            set { _salesSlipCdDtl = value; }
        }

        /// public propaty name  :  SalesOrderDivCd
        /// <summary>売上在庫取寄区分 プロパティ</summary>
        /// <value>0:取寄、1:在庫　※得意先別のみ使用</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上在庫取寄区分 プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SalesOrderDivCd
        {
            get { return _salesOrderDivCd; }
            set { _salesOrderDivCd = value; }
        }

        /// public propaty name  :  GoodsKindCode
        /// <summary>商品属性プロパティ</summary>
        /// <value>0:純正、1:その他　※得意先別のみ使用</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品属性プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsKindCode
        {
            get { return _goodsKindCode; }
            set { _goodsKindCode = value; }
        }

        /// public propaty name  :  SalesMoneyTaxExc
        /// <summary>売上金額（税抜き）(純正,基本)プロパティ</summary>
        /// <value>売上金額（税抜き）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上金額（税抜き）(純正,基本)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesMoneyTaxExc
        {
            get { return _salesMoneyTaxExc; }
            set { _salesMoneyTaxExc = value; }
        }

        /// public propaty name  :  SalesRetGoodsPrice
        /// <summary>返品額(純正,基本)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   返品額(純正,基本)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesRetGoodsPrice
        {
            get { return _salesRetGoodsPrice; }
            set { _salesRetGoodsPrice = value; }
        }

        /// public propaty name  :  DiscountPrice
        /// <summary>値引金額(純正,基本)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   値引金額(純正,基本)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 DiscountPrice
        {
            get { return _discountPrice; }
            set { _discountPrice = value; }
        }

        /// public propaty name  :  GrossProfit
        /// <summary>粗利額(純正,基本)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   粗利額(純正,基本)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 GrossProfit
        {
            get { return _grossProfit; }
            set { _grossProfit = value; }
        }

        /// public propaty name  :  SalesTargetMoney
        /// <summary>売上目標額プロパティ</summary>
        /// <value>※同一計上年月のレコードには同じ値がセットされます</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上目標額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesTargetMoney
        {
            get { return _salesTargetMoney; }
            set { _salesTargetMoney = value; }
        }

        /// public propaty name  :  SalesTargetProfit
        /// <summary>粗利目標額プロパティ</summary>
        /// <value>※同一計上年月のレコードには同じ値がセットされます</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   粗利目標額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesTargetProfit
        {
            get { return _salesTargetProfit; }
            set { _salesTargetProfit = value; }
        }

        /// public propaty name  :  SalesTimes
        /// <summary>売上回数プロパティ</summary>
        /// <value>出荷回数(売上時のみ）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上回数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SalesTimes
        {
            get { return _salesTimes; }
            set { _salesTimes = value; }
        }

        /// public propaty name  :  TermSalesSlipCount
        /// <summary>期間伝票枚数プロパティ</summary>
        /// <value>※同一計上年月のレコードには同じ値がセットされます</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   期間伝票枚数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 TermSalesSlipCount
        {
            get { return _termSalesSlipCount; }
            set { _termSalesSlipCount = value; }
        }

        /// public propaty name  :  Cost
        /// <summary>原価プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   原価プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 Cost
        {
            get { return _cost; }
            set { _cost = value; }
        }

        /// public propaty name  :  LastTimeDemand
        /// <summary>前回請求金額プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   前回請求金額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 LastTimeDemand
        {
            get { return _lastTimeDemand; }
            set { _lastTimeDemand = value; }
        }

        /// public propaty name  :  LastTimeAccRec
        /// <summary>前回売掛金額プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   前回売掛金額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 LastTimeAccRec
        {
            get { return _lastTimeAccRec; }
            set { _lastTimeAccRec = value; }
        }

        /// public propaty name  :  AcpOdrTtl2TmBfBlDmd
        /// <summary>受注2回前残高（請求計）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   受注2回前残高（請求計）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 AcpOdrTtl2TmBfBlDmd
        {
            get { return _acpOdrTtl2TmBfBlDmd; }
            set { _acpOdrTtl2TmBfBlDmd = value; }
        }

        /// public propaty name  :  AcpOdrTtl3TmBfBlDmd
        /// <summary>受注3回前残高（請求計）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   受注3回前残高（請求計）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 AcpOdrTtl3TmBfBlDmd
        {
            get { return _acpOdrTtl3TmBfBlDmd; }
            set { _acpOdrTtl3TmBfBlDmd = value; }
        }

        /// public propaty name  :  SalesSlipCount
        /// <summary>売上伝票枚数プロパティ</summary>
        /// <value>掛売の伝票枚数</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上伝票枚数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SalesSlipCount
        {
            get { return _salesSlipCount; }
            set { _salesSlipCount = value; }
        }

        /// public propaty name  :  CasheDeposit
        /// <summary>請求入金情報(現金)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   請求入金情報(現金)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 CasheDeposit
        {
            get { return _casheDeposit; }
            set { _casheDeposit = value; }
        }

        /// public propaty name  :  TrfrDeposit
        /// <summary>請求入金情報(振込)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   請求入金情報(振込)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 TrfrDeposit
        {
            get { return _trfrDeposit; }
            set { _trfrDeposit = value; }
        }

        /// public propaty name  :  CheckKDeposit
        /// <summary>請求入金情報(小切手)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   請求入金情報(小切手)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 CheckKDeposit
        {
            get { return _checkKDeposit; }
            set { _checkKDeposit = value; }
        }

        /// public propaty name  :  DraftDeposit
        /// <summary>請求入金情報(手形)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   請求入金情報(手形)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 DraftDeposit
        {
            get { return _draftDeposit; }
            set { _draftDeposit = value; }
        }

        /// public propaty name  :  OffsetDeposit
        /// <summary>請求入金情報(相殺)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   請求入金情報(相殺)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 OffsetDeposit
        {
            get { return _offsetDeposit; }
            set { _offsetDeposit = value; }
        }

        /// public propaty name  :  FundtransferDeposit
        /// <summary>請求入金情報(口座振替)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   請求入金情報(口座振替)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 FundtransferDeposit
        {
            get { return _fundtransferDeposit; }
            set { _fundtransferDeposit = value; }
        }

        /// public propaty name  :  EmoneyDeposit
        /// <summary>請求入金情報(E-Money)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   請求入金情報(E-Money)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 EmoneyDeposit
        {
            get { return _emoneyDeposit; }
            set { _emoneyDeposit = value; }
        }

        /// public propaty name  :  OtherDeposit
        /// <summary>請求入金情報(その他)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   請求入金情報(その他)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 OtherDeposit
        {
            get { return _otherDeposit; }
            set { _otherDeposit = value; }
        }

        /// public propaty name  :  ThisTimeFeeDmdNrml
        /// <summary>請求入金情報(手数料)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   請求入金情報(手数料)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 ThisTimeFeeDmdNrml
        {
            get { return _thisTimeFeeDmdNrml; }
            set { _thisTimeFeeDmdNrml = value; }
        }

        /// public propaty name  :  ThisTimeDisDmdNrml
        /// <summary>請求入金情報(値引)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   請求入金情報(値引)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 ThisTimeDisDmdNrml
        {
            get { return _thisTimeDisDmdNrml; }
            set { _thisTimeDisDmdNrml = value; }
        }

        /// public propaty name  :  OfsThisSalesTax
        /// <summary>請求消費税プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   請求消費税プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 OfsThisSalesTax
        {
            get { return _ofsThisSalesTax; }
            set { _ofsThisSalesTax = value; }
        }

        /// public propaty name  :  ThisMCasheDeposit
        /// <summary>当月入金情報(現金)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   当月入金情報(現金)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 ThisMCasheDeposit
        {
            get { return _thisMCasheDeposit; }
            set { _thisMCasheDeposit = value; }
        }

        /// public propaty name  :  ThisMhTrfrDeposit
        /// <summary>当月入金情報(振込)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   当月入金情報(振込)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 ThisMhTrfrDeposit
        {
            get { return _thisMhTrfrDeposit; }
            set { _thisMhTrfrDeposit = value; }
        }

        /// public propaty name  :  ThisMCheckKDeposit
        /// <summary>当月入金情報(小切手)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   当月入金情報(小切手)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 ThisMCheckKDeposit
        {
            get { return _thisMCheckKDeposit; }
            set { _thisMCheckKDeposit = value; }
        }

        /// public propaty name  :  ThisMDraftDeposit
        /// <summary>当月入金情報(手形)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   当月入金情報(手形)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 ThisMDraftDeposit
        {
            get { return _thisMDraftDeposit; }
            set { _thisMDraftDeposit = value; }
        }

        /// public propaty name  :  ThisMOffsetDeposit
        /// <summary>当月入金情報(相殺)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   当月入金情報(相殺)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 ThisMOffsetDeposit
        {
            get { return _thisMOffsetDeposit; }
            set { _thisMOffsetDeposit = value; }
        }

        /// public propaty name  :  ThisMFundtransferDeposit
        /// <summary>当月入金情報(口座振替)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   当月入金情報(口座振替)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 ThisMFundtransferDeposit
        {
            get { return _thisMFundtransferDeposit; }
            set { _thisMFundtransferDeposit = value; }
        }

        /// public propaty name  :  ThisMEmoneyDeposit
        /// <summary>当月入金情報(E-Money)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   当月入金情報(E-Money)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 ThisMEmoneyDeposit
        {
            get { return _thisMEmoneyDeposit; }
            set { _thisMEmoneyDeposit = value; }
        }

        /// public propaty name  :  ThisMOtherDeposit
        /// <summary>当月入金情報(その他)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   当月入金情報(その他)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 ThisMOtherDeposit
        {
            get { return _thisMOtherDeposit; }
            set { _thisMOtherDeposit = value; }
        }

        /// public propaty name  :  ThisMThisTimeFeeDmdNrml
        /// <summary>当月入金情報(手数料)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   当月入金情報(手数料)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 ThisMThisTimeFeeDmdNrml
        {
            get { return _thisMThisTimeFeeDmdNrml; }
            set { _thisMThisTimeFeeDmdNrml = value; }
        }

        /// public propaty name  :  ThisMThisTimeDisDmdNrml
        /// <summary>当月入金情報(値引)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   当月入金情報(値引)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 ThisMThisTimeDisDmdNrml
        {
            get { return _thisMThisTimeDisDmdNrml; }
            set { _thisMThisTimeDisDmdNrml = value; }
        }

        /// public propaty name  :  ThisMOfsThisSalesTax
        /// <summary>当月消費税プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   当月消費税プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 ThisMOfsThisSalesTax
        {
            get { return _thisMOfsThisSalesTax; }
            set { _thisMOfsThisSalesTax = value; }
        }

        /// public propaty name  :  claimDiv
        /// <summary>請求区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   請求区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 claimDiv
        {
            get { return _claimDiv; }
            set { _claimDiv = value; }
        }

        /// public propaty name  :  ExSalesMoneyTaxExc
        /// <summary>売上金額（税抜き)(優良)プロパティ</summary>
        /// <value>売上金額（税抜き）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上金額（税抜き)(優良)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 ExSalesMoneyTaxExc
        {
            get { return _exSalesMoneyTaxExc; }
            set { _exSalesMoneyTaxExc = value; }
        }

        /// public propaty name  :  ExSalesRetGoodsPrice
        /// <summary>返品額(優良)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   返品額(優良)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 ExSalesRetGoodsPrice
        {
            get { return _exSalesRetGoodsPrice; }
            set { _exSalesRetGoodsPrice = value; }
        }

        /// public propaty name  :  ExDiscountPrice
        /// <summary>値引金額(優良)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   値引金額(優良)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 ExDiscountPrice
        {
            get { return _exDiscountPrice; }
            set { _exDiscountPrice = value; }
        }

        /// public propaty name  :  ExGrossProfit
        /// <summary>粗利額(優良)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   粗利額(優良)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 ExGrossProfit
        {
            get { return _exGrossProfit; }
            set { _exGrossProfit = value; }
        }


        /// <summary>
        /// 得意先別売上年間実績照会抽出結果クラスワークワークコンストラクタ
        /// </summary>
        /// <returns>CustSalesAnnualDataSelectResultWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   CustSalesAnnualDataSelectResultWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public CustSalesAnnualDataSelectResultWork()
        {
        }

    }


    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>CustSalesAnnualDataSelectResultWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   CustSalesAnnualDataSelectResultWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class CustSalesAnnualDataSelectResultWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   CustSalesAnnualDataSelectResultWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  CustSalesAnnualDataSelectResultWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is CustSalesAnnualDataSelectResultWork || graph is ArrayList || graph is CustSalesAnnualDataSelectResultWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(CustSalesAnnualDataSelectResultWork).FullName));

            if (graph != null && graph is CustSalesAnnualDataSelectResultWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.CustSalesAnnualDataSelectResultWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is CustSalesAnnualDataSelectResultWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((CustSalesAnnualDataSelectResultWork[])graph).Length;
            }
            else if (graph is CustSalesAnnualDataSelectResultWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //繰り返し数	

            //計上年月
            serInfo.MemberInfo.Add(typeof(Int32)); //AUPYearMonth
            //売上伝票区分
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesSlipCdDtl
            //売上在庫取寄区分 
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesOrderDivCd
            //商品属性
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsKindCode
            //売上金額（税抜き）(純正,基本)
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesMoneyTaxExc
            //返品額(純正,基本)
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesRetGoodsPrice
            //値引金額(純正,基本)
            serInfo.MemberInfo.Add(typeof(Int64)); //DiscountPrice
            //粗利額(純正,基本)
            serInfo.MemberInfo.Add(typeof(Int64)); //GrossProfit
            //売上目標額
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesTargetMoney
            //粗利目標額
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesTargetProfit
            //売上回数
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesTimes
            //期間伝票枚数
            serInfo.MemberInfo.Add(typeof(Int32)); //TermSalesSlipCount
            //原価
            serInfo.MemberInfo.Add(typeof(Int64)); //Cost
            //前回請求金額
            serInfo.MemberInfo.Add(typeof(Int64)); //LastTimeDemand
            //前回売掛金額
            serInfo.MemberInfo.Add(typeof(Int64)); //LastTimeAccRec
            //受注2回前残高（請求計）
            serInfo.MemberInfo.Add(typeof(Int64)); //AcpOdrTtl2TmBfBlDmd
            //受注3回前残高（請求計）
            serInfo.MemberInfo.Add(typeof(Int64)); //AcpOdrTtl3TmBfBlDmd
            //売上伝票枚数
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesSlipCount
            //請求入金情報(現金)
            serInfo.MemberInfo.Add(typeof(Int64)); //CasheDeposit
            //請求入金情報(振込)
            serInfo.MemberInfo.Add(typeof(Int64)); //TrfrDeposit
            //請求入金情報(小切手)
            serInfo.MemberInfo.Add(typeof(Int64)); //CheckKDeposit
            //請求入金情報(手形)
            serInfo.MemberInfo.Add(typeof(Int64)); //DraftDeposit
            //請求入金情報(相殺)
            serInfo.MemberInfo.Add(typeof(Int64)); //OffsetDeposit
            //請求入金情報(口座振替)
            serInfo.MemberInfo.Add(typeof(Int64)); //FundtransferDeposit
            //請求入金情報(E-Money)
            serInfo.MemberInfo.Add(typeof(Int64)); //EmoneyDeposit
            //請求入金情報(その他)
            serInfo.MemberInfo.Add(typeof(Int64)); //OtherDeposit
            //請求入金情報(手数料)
            serInfo.MemberInfo.Add(typeof(Int64)); //ThisTimeFeeDmdNrml
            //請求入金情報(値引)
            serInfo.MemberInfo.Add(typeof(Int64)); //ThisTimeDisDmdNrml
            //請求消費税
            serInfo.MemberInfo.Add(typeof(Int64)); //OfsThisSalesTax
            //当月入金情報(現金)
            serInfo.MemberInfo.Add(typeof(Int64)); //ThisMCasheDeposit
            //当月入金情報(振込)
            serInfo.MemberInfo.Add(typeof(Int64)); //ThisMhTrfrDeposit
            //当月入金情報(小切手)
            serInfo.MemberInfo.Add(typeof(Int64)); //ThisMCheckKDeposit
            //当月入金情報(手形)
            serInfo.MemberInfo.Add(typeof(Int64)); //ThisMDraftDeposit
            //当月入金情報(相殺)
            serInfo.MemberInfo.Add(typeof(Int64)); //ThisMOffsetDeposit
            //当月入金情報(口座振替)
            serInfo.MemberInfo.Add(typeof(Int64)); //ThisMFundtransferDeposit
            //当月入金情報(E-Money)
            serInfo.MemberInfo.Add(typeof(Int64)); //ThisMEmoneyDeposit
            //当月入金情報(その他)
            serInfo.MemberInfo.Add(typeof(Int64)); //ThisMOtherDeposit
            //当月入金情報(手数料)
            serInfo.MemberInfo.Add(typeof(Int64)); //ThisMThisTimeFeeDmdNrml
            //当月入金情報(値引)
            serInfo.MemberInfo.Add(typeof(Int64)); //ThisMThisTimeDisDmdNrml
            //当月消費税
            serInfo.MemberInfo.Add(typeof(Int64)); //ThisMOfsThisSalesTax
            //請求区分
            serInfo.MemberInfo.Add(typeof(Int32)); //claimDiv
            //売上金額（税抜き)(優良)
            serInfo.MemberInfo.Add(typeof(Int64)); //ExSalesMoneyTaxExc
            //返品額(優良)
            serInfo.MemberInfo.Add(typeof(Int64)); //ExSalesRetGoodsPrice
            //値引金額(優良)
            serInfo.MemberInfo.Add(typeof(Int64)); //ExDiscountPrice
            //粗利額(優良)
            serInfo.MemberInfo.Add(typeof(Int64)); //ExGrossProfit


            serInfo.Serialize(writer, serInfo);
            if (graph is CustSalesAnnualDataSelectResultWork)
            {
                CustSalesAnnualDataSelectResultWork temp = (CustSalesAnnualDataSelectResultWork)graph;

                SetCustSalesAnnualDataSelectResultWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is CustSalesAnnualDataSelectResultWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((CustSalesAnnualDataSelectResultWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (CustSalesAnnualDataSelectResultWork temp in lst)
                {
                    SetCustSalesAnnualDataSelectResultWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// CustSalesAnnualDataSelectResultWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 45;

        /// <summary>
        ///  CustSalesAnnualDataSelectResultWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   CustSalesAnnualDataSelectResultWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetCustSalesAnnualDataSelectResultWork(System.IO.BinaryWriter writer, CustSalesAnnualDataSelectResultWork temp)
        {
            //計上年月
            writer.Write(temp.AUPYearMonth);
            //売上伝票区分
            writer.Write(temp.SalesSlipCdDtl);
            //売上在庫取寄区分 
            writer.Write(temp.SalesOrderDivCd);
            //商品属性
            writer.Write(temp.GoodsKindCode);
            //売上金額（税抜き）(純正,基本)
            writer.Write(temp.SalesMoneyTaxExc);
            //返品額(純正,基本)
            writer.Write(temp.SalesRetGoodsPrice);
            //値引金額(純正,基本)
            writer.Write(temp.DiscountPrice);
            //粗利額(純正,基本)
            writer.Write(temp.GrossProfit);
            //売上目標額
            writer.Write(temp.SalesTargetMoney);
            //粗利目標額
            writer.Write(temp.SalesTargetProfit);
            //売上回数
            writer.Write(temp.SalesTimes);
            //期間伝票枚数
            writer.Write(temp.TermSalesSlipCount);
            //原価
            writer.Write(temp.Cost);
            //前回請求金額
            writer.Write(temp.LastTimeDemand);
            //前回売掛金額
            writer.Write(temp.LastTimeAccRec);
            //受注2回前残高（請求計）
            writer.Write(temp.AcpOdrTtl2TmBfBlDmd);
            //受注3回前残高（請求計）
            writer.Write(temp.AcpOdrTtl3TmBfBlDmd);
            //売上伝票枚数
            writer.Write(temp.SalesSlipCount);
            //請求入金情報(現金)
            writer.Write(temp.CasheDeposit);
            //請求入金情報(振込)
            writer.Write(temp.TrfrDeposit);
            //請求入金情報(小切手)
            writer.Write(temp.CheckKDeposit);
            //請求入金情報(手形)
            writer.Write(temp.DraftDeposit);
            //請求入金情報(相殺)
            writer.Write(temp.OffsetDeposit);
            //請求入金情報(口座振替)
            writer.Write(temp.FundtransferDeposit);
            //請求入金情報(E-Money)
            writer.Write(temp.EmoneyDeposit);
            //請求入金情報(その他)
            writer.Write(temp.OtherDeposit);
            //請求入金情報(手数料)
            writer.Write(temp.ThisTimeFeeDmdNrml);
            //請求入金情報(値引)
            writer.Write(temp.ThisTimeDisDmdNrml);
            //請求消費税
            writer.Write(temp.OfsThisSalesTax);
            //当月入金情報(現金)
            writer.Write(temp.ThisMCasheDeposit);
            //当月入金情報(振込)
            writer.Write(temp.ThisMhTrfrDeposit);
            //当月入金情報(小切手)
            writer.Write(temp.ThisMCheckKDeposit);
            //当月入金情報(手形)
            writer.Write(temp.ThisMDraftDeposit);
            //当月入金情報(相殺)
            writer.Write(temp.ThisMOffsetDeposit);
            //当月入金情報(口座振替)
            writer.Write(temp.ThisMFundtransferDeposit);
            //当月入金情報(E-Money)
            writer.Write(temp.ThisMEmoneyDeposit);
            //当月入金情報(その他)
            writer.Write(temp.ThisMOtherDeposit);
            //当月入金情報(手数料)
            writer.Write(temp.ThisMThisTimeFeeDmdNrml);
            //当月入金情報(値引)
            writer.Write(temp.ThisMThisTimeDisDmdNrml);
            //当月消費税
            writer.Write(temp.ThisMOfsThisSalesTax);
            //請求区分
            writer.Write(temp.claimDiv);
            //売上金額（税抜き)(優良)
            writer.Write(temp.ExSalesMoneyTaxExc);
            //返品額(優良)
            writer.Write(temp.ExSalesRetGoodsPrice);
            //値引金額(優良)
            writer.Write(temp.ExDiscountPrice);
            //粗利額(優良)
            writer.Write(temp.ExGrossProfit);

        }

        /// <summary>
        ///  CustSalesAnnualDataSelectResultWorkインスタンス取得
        /// </summary>
        /// <returns>CustSalesAnnualDataSelectResultWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   CustSalesAnnualDataSelectResultWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private CustSalesAnnualDataSelectResultWork GetCustSalesAnnualDataSelectResultWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            CustSalesAnnualDataSelectResultWork temp = new CustSalesAnnualDataSelectResultWork();

            //計上年月
            temp.AUPYearMonth = reader.ReadInt32();
            //売上伝票区分
            temp.SalesSlipCdDtl = reader.ReadInt32();
            //売上在庫取寄区分 
            temp.SalesOrderDivCd = reader.ReadInt32();
            //商品属性
            temp.GoodsKindCode = reader.ReadInt32();
            //売上金額（税抜き）(純正,基本)
            temp.SalesMoneyTaxExc = reader.ReadInt64();
            //返品額(純正,基本)
            temp.SalesRetGoodsPrice = reader.ReadInt64();
            //値引金額(純正,基本)
            temp.DiscountPrice = reader.ReadInt64();
            //粗利額(純正,基本)
            temp.GrossProfit = reader.ReadInt64();
            //売上目標額
            temp.SalesTargetMoney = reader.ReadInt64();
            //粗利目標額
            temp.SalesTargetProfit = reader.ReadInt64();
            //売上回数
            temp.SalesTimes = reader.ReadInt32();
            //期間伝票枚数
            temp.TermSalesSlipCount = reader.ReadInt32();
            //原価
            temp.Cost = reader.ReadInt64();
            //前回請求金額
            temp.LastTimeDemand = reader.ReadInt64();
            //前回売掛金額
            temp.LastTimeAccRec = reader.ReadInt64();
            //受注2回前残高（請求計）
            temp.AcpOdrTtl2TmBfBlDmd = reader.ReadInt64();
            //受注3回前残高（請求計）
            temp.AcpOdrTtl3TmBfBlDmd = reader.ReadInt64();
            //売上伝票枚数
            temp.SalesSlipCount = reader.ReadInt32();
            //請求入金情報(現金)
            temp.CasheDeposit = reader.ReadInt64();
            //請求入金情報(振込)
            temp.TrfrDeposit = reader.ReadInt64();
            //請求入金情報(小切手)
            temp.CheckKDeposit = reader.ReadInt64();
            //請求入金情報(手形)
            temp.DraftDeposit = reader.ReadInt64();
            //請求入金情報(相殺)
            temp.OffsetDeposit = reader.ReadInt64();
            //請求入金情報(口座振替)
            temp.FundtransferDeposit = reader.ReadInt64();
            //請求入金情報(E-Money)
            temp.EmoneyDeposit = reader.ReadInt64();
            //請求入金情報(その他)
            temp.OtherDeposit = reader.ReadInt64();
            //請求入金情報(手数料)
            temp.ThisTimeFeeDmdNrml = reader.ReadInt64();
            //請求入金情報(値引)
            temp.ThisTimeDisDmdNrml = reader.ReadInt64();
            //請求消費税
            temp.OfsThisSalesTax = reader.ReadInt64();
            //当月入金情報(現金)
            temp.ThisMCasheDeposit = reader.ReadInt64();
            //当月入金情報(振込)
            temp.ThisMhTrfrDeposit = reader.ReadInt64();
            //当月入金情報(小切手)
            temp.ThisMCheckKDeposit = reader.ReadInt64();
            //当月入金情報(手形)
            temp.ThisMDraftDeposit = reader.ReadInt64();
            //当月入金情報(相殺)
            temp.ThisMOffsetDeposit = reader.ReadInt64();
            //当月入金情報(口座振替)
            temp.ThisMFundtransferDeposit = reader.ReadInt64();
            //当月入金情報(E-Money)
            temp.ThisMEmoneyDeposit = reader.ReadInt64();
            //当月入金情報(その他)
            temp.ThisMOtherDeposit = reader.ReadInt64();
            //当月入金情報(手数料)
            temp.ThisMThisTimeFeeDmdNrml = reader.ReadInt64();
            //当月入金情報(値引)
            temp.ThisMThisTimeDisDmdNrml = reader.ReadInt64();
            //当月消費税
            temp.ThisMOfsThisSalesTax = reader.ReadInt64();
            //請求区分
            temp.claimDiv = reader.ReadInt32();
            //売上金額（税抜き)(優良)
            temp.ExSalesMoneyTaxExc = reader.ReadInt64();
            //返品額(優良)
            temp.ExSalesRetGoodsPrice = reader.ReadInt64();
            //値引金額(優良)
            temp.ExDiscountPrice = reader.ReadInt64();
            //粗利額(優良)
            temp.ExGrossProfit = reader.ReadInt64();


            //以下は読み飛ばしです。このバージョンが想定する EmployeeWork型以降のバージョンの
            //データをデシリアライズする場合、シリアライズしたフォーマッタが記述した
            //型情報にしたがって、ストリームから情報を読み出します...といっても
            //読み出して捨てることになります。
            for (int k = currentMemberCount; k < serInfo.MemberInfo.Count; ++k)
            {
                //byte[],char[]をデシリアライズする直前に、そのlengthが
                //デシリアライズされているケースがある、byte[],char[]の
                //デシリアライズにはlengthが必要なのでint型のデータをデ
                //シリアライズした場合は、この値をこの変数に退避します。
                int optCount = 0;
                object oMemberType = serInfo.MemberInfo[k];
                if (oMemberType is Type)
                {
                    Type t = (Type)oMemberType;
                    object oData = TypeDeserializer.DeserializePrimitiveType(reader, t, optCount);
                    if (t.Equals(typeof(int)))
                    {
                        optCount = Convert.ToInt32(oData);
                    }
                    else
                    {
                        optCount = 0;
                    }
                }
                else if (oMemberType is string)
                {
                    Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate formatter = CustomFormatterServices.GetSurrogate((string)oMemberType);
                    object userData = formatter.Deserialize(reader);  //読み飛ばし
                }
            }
            return temp;
        }

        /// <summary>
        ///  Ver5.10.1.0用のカスタムデシリアライザです
        /// </summary>
        /// <returns>CustSalesAnnualDataSelectResultWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   CustSalesAnnualDataSelectResultWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                CustSalesAnnualDataSelectResultWork temp = GetCustSalesAnnualDataSelectResultWork(reader, serInfo);
                lst.Add(temp);
            }
            switch (serInfo.RetTypeInfo)
            {
                case 0:
                    retValue = lst;
                    break;
                case 1:
                    retValue = lst[0];
                    break;
                case 2:
                    retValue = (CustSalesAnnualDataSelectResultWork[])lst.ToArray(typeof(CustSalesAnnualDataSelectResultWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }

}

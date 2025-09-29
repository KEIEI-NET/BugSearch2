using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   SuppYearResultAccPayWork
    /// <summary>
    ///                      仕入年間実績照会(残高照会)抽出結果クラスワークワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   仕入年間実績照会(残高照会)抽出結果クラスワークワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/11/20  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class SuppYearResultAccPayWork
    {
        /// <summary>仕入3回前残高（支払計）</summary>
        /// <remarks>支払情報用</remarks>
        private Int64 _stockTtl3TmBfBlPay;

        /// <summary>仕入2回前残高（支払計）</summary>
        /// <remarks>支払情報用</remarks>
        private Int64 _stockTtl2TmBfBlPay;

        /// <summary>前回支払金額</summary>
        /// <remarks>支払情報用</remarks>
        private Int64 _lastTimePayment;

        /// <summary>支払情報(現金)</summary>
        /// <remarks>支払情報用</remarks>
        private Int64 _cashePayment;

        /// <summary>支払情報(振込)</summary>
        /// <remarks>支払情報用</remarks>
        private Int64 _trfrPayment;

        /// <summary>支払情報(小切手)</summary>
        /// <remarks>支払情報用</remarks>
        private Int64 _checkKPayment;

        /// <summary>支払情報(手形)</summary>
        /// <remarks>支払情報用</remarks>
        private Int64 _draftPayment;

        /// <summary>支払情報(相殺)</summary>
        /// <remarks>支払情報用</remarks>
        private Int64 _offsetPayment;

        /// <summary>支払情報(口座振替)</summary>
        /// <remarks>支払情報用</remarks>
        private Int64 _fundtransferPayment;

        /// <summary>支払情報(E-Money)</summary>
        /// <remarks>支払情報用</remarks>
        private Int64 _emoneyPayment;

        /// <summary>支払情報(その他)</summary>
        /// <remarks>支払情報用</remarks>
        private Int64 _otherPayment;

        /// <summary>支払情報(手数料)</summary>
        /// <remarks>支払情報用</remarks>
        private Int64 _thisTimeFeePayNrml;

        /// <summary>支払情報(値引)</summary>
        /// <remarks>支払情報用</remarks>
        private Int64 _thisTimeDisPayNrml;

        /// <summary>仕入伝票枚数</summary>
        /// <remarks>支払情報用</remarks>
        private Int32 _stockSlipCount;

        /// <summary>今回仕入金額</summary>
        /// <remarks>支払情報用</remarks>
        private Int64 _thisTimeStockPrice;

        /// <summary>今回返品金額</summary>
        /// <remarks>支払情報用</remarks>
        private Int64 _thisStckPricRgds;

        /// <summary>今回値引金額</summary>
        /// <remarks>支払情報用</remarks>
        private Int64 _thisStckPricDis;

        /// <summary>相殺後今回仕入金額</summary>
        /// <remarks>支払情報用</remarks>
        private Int64 _ofsThisTimeStock;

        /// <summary>相殺後今回仕入消費税</summary>
        /// <remarks>支払情報用</remarks>
        private Int64 _ofsThisStockTax;

        /// <summary>仕入合計残高（支払計）</summary>
        /// <remarks>支払情報用</remarks>
        private Int64 _stockTotalPayBalance;

        /// <summary>前回買掛金額</summary>
        /// <remarks>当月用　前月末残</remarks>
        private Int64 _monthLastTimeAccPay;

        /// <summary>当月情報(現金)</summary>
        /// <remarks>当月用</remarks>
        private Int64 _monthCashePayment;

        /// <summary>当月情報(振込)</summary>
        /// <remarks>当月用</remarks>
        private Int64 _monthTrfrPayment;

        /// <summary>当月情報(小切手)</summary>
        /// <remarks>当月用</remarks>
        private Int64 _monthCheckKPayment;

        /// <summary>当月情報(手形)</summary>
        /// <remarks>当月用</remarks>
        private Int64 _monthDraftPayment;

        /// <summary>当月情報(相殺)</summary>
        /// <remarks>当月用</remarks>
        private Int64 _monthOffsetPayment;

        /// <summary>当月情報(口座振替)</summary>
        /// <remarks>当月用</remarks>
        private Int64 _monthFundtransferPayment;

        /// <summary>当月情報(E-Money)</summary>
        /// <remarks>当月用</remarks>
        private Int64 _monthEmoneyPayment;

        /// <summary>当月情報(その他)</summary>
        /// <remarks>当月用</remarks>
        private Int64 _monthOtherPayment;

        /// <summary>当月情報(手数料)</summary>
        /// <remarks>当月用</remarks>
        private Int64 _monthThisTimeFeePayNrml;

        /// <summary>当月情報(値引)</summary>
        /// <remarks>当月用</remarks>
        private Int64 _monthThisTimeDisPayNrml;

        /// <summary>当月仕入伝票枚数</summary>
        /// <remarks>当月用</remarks>
        private Int32 _monthStockSlipCount;

        /// <summary>当月今回仕入金額</summary>
        /// <remarks>当月用</remarks>
        private Int64 _monthThisTimeStockPrice;

        /// <summary>当月今回返品金額</summary>
        /// <remarks>当月用</remarks>
        private Int64 _monthThisStckPricRgds;

        /// <summary>当月今回値引金額</summary>
        /// <remarks>当月用</remarks>
        private Int64 _monthThisStckPricDis;

        /// <summary>当月相殺後今回仕入金額</summary>
        /// <remarks>当月用</remarks>
        private Int64 _monthOfsThisTimeStock;

        /// <summary>当月相殺後今回仕入消費税</summary>
        /// <remarks>当月用</remarks>
        private Int64 _monthOfsThisStockTax;

        /// <summary>当月仕入合計残高（買掛計）</summary>
        /// <remarks>当月用　現在売掛残高</remarks>
        private Int64 _monthStckTtlAccPayBalance;

        /// <summary>当期仕入伝票枚数</summary>
        /// <remarks>当期用</remarks>
        private Int32 _yearStockSlipCount;

        /// <summary>当期今回仕入金額</summary>
        /// <remarks>当期用</remarks>
        private Int64 _yearThisTimeStockPrice;

        /// <summary>当期今回返品金額</summary>
        /// <remarks>当期用</remarks>
        private Int64 _yearThisStckPricRgds;

        /// <summary>当期今回値引金額</summary>
        /// <remarks>当期用</remarks>
        private Int64 _yearThisStckPricDis;

        /// <summary>当期相殺後今回仕入金額</summary>
        /// <remarks>当期用</remarks>
        private Int64 _yearOfsThisTimeStock;

        /// <summary>当期相殺後今回仕入消費税</summary>
        /// <remarks>当期用</remarks>
        private Int64 _yearOfsThisStockTax;


        /// public propaty name  :  StockTtl3TmBfBlPay
        /// <summary>仕入3回前残高（支払計）プロパティ</summary>
        /// <value>支払情報用</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入3回前残高（支払計）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 StockTtl3TmBfBlPay
        {
            get { return _stockTtl3TmBfBlPay; }
            set { _stockTtl3TmBfBlPay = value; }
        }

        /// public propaty name  :  StockTtl2TmBfBlPay
        /// <summary>仕入2回前残高（支払計）プロパティ</summary>
        /// <value>支払情報用</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入2回前残高（支払計）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 StockTtl2TmBfBlPay
        {
            get { return _stockTtl2TmBfBlPay; }
            set { _stockTtl2TmBfBlPay = value; }
        }

        /// public propaty name  :  LastTimePayment
        /// <summary>前回支払金額プロパティ</summary>
        /// <value>支払情報用</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   前回支払金額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 LastTimePayment
        {
            get { return _lastTimePayment; }
            set { _lastTimePayment = value; }
        }

        /// public propaty name  :  CashePayment
        /// <summary>支払情報(現金)プロパティ</summary>
        /// <value>支払情報用</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   支払情報(現金)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 CashePayment
        {
            get { return _cashePayment; }
            set { _cashePayment = value; }
        }

        /// public propaty name  :  TrfrPayment
        /// <summary>支払情報(振込)プロパティ</summary>
        /// <value>支払情報用</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   支払情報(振込)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 TrfrPayment
        {
            get { return _trfrPayment; }
            set { _trfrPayment = value; }
        }

        /// public propaty name  :  CheckKPayment
        /// <summary>支払情報(小切手)プロパティ</summary>
        /// <value>支払情報用</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   支払情報(小切手)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 CheckKPayment
        {
            get { return _checkKPayment; }
            set { _checkKPayment = value; }
        }

        /// public propaty name  :  DraftPayment
        /// <summary>支払情報(手形)プロパティ</summary>
        /// <value>支払情報用</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   支払情報(手形)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 DraftPayment
        {
            get { return _draftPayment; }
            set { _draftPayment = value; }
        }

        /// public propaty name  :  OffsetPayment
        /// <summary>支払情報(相殺)プロパティ</summary>
        /// <value>支払情報用</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   支払情報(相殺)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 OffsetPayment
        {
            get { return _offsetPayment; }
            set { _offsetPayment = value; }
        }

        /// public propaty name  :  FundtransferPayment
        /// <summary>支払情報(口座振替)プロパティ</summary>
        /// <value>支払情報用</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   支払情報(口座振替)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 FundtransferPayment
        {
            get { return _fundtransferPayment; }
            set { _fundtransferPayment = value; }
        }

        /// public propaty name  :  EmoneyPayment
        /// <summary>支払情報(E-Money)プロパティ</summary>
        /// <value>支払情報用</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   支払情報(E-Money)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 EmoneyPayment
        {
            get { return _emoneyPayment; }
            set { _emoneyPayment = value; }
        }

        /// public propaty name  :  OtherPayment
        /// <summary>支払情報(その他)プロパティ</summary>
        /// <value>支払情報用</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   支払情報(その他)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 OtherPayment
        {
            get { return _otherPayment; }
            set { _otherPayment = value; }
        }

        /// public propaty name  :  ThisTimeFeePayNrml
        /// <summary>支払情報(手数料)プロパティ</summary>
        /// <value>支払情報用</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   支払情報(手数料)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 ThisTimeFeePayNrml
        {
            get { return _thisTimeFeePayNrml; }
            set { _thisTimeFeePayNrml = value; }
        }

        /// public propaty name  :  ThisTimeDisPayNrml
        /// <summary>支払情報(値引)プロパティ</summary>
        /// <value>支払情報用</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   支払情報(値引)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 ThisTimeDisPayNrml
        {
            get { return _thisTimeDisPayNrml; }
            set { _thisTimeDisPayNrml = value; }
        }

        /// public propaty name  :  StockSlipCount
        /// <summary>仕入伝票枚数プロパティ</summary>
        /// <value>支払情報用</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入伝票枚数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 StockSlipCount
        {
            get { return _stockSlipCount; }
            set { _stockSlipCount = value; }
        }

        /// public propaty name  :  ThisTimeStockPrice
        /// <summary>今回仕入金額プロパティ</summary>
        /// <value>支払情報用</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   今回仕入金額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 ThisTimeStockPrice
        {
            get { return _thisTimeStockPrice; }
            set { _thisTimeStockPrice = value; }
        }

        /// public propaty name  :  ThisStckPricRgds
        /// <summary>今回返品金額プロパティ</summary>
        /// <value>支払情報用</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   今回返品金額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 ThisStckPricRgds
        {
            get { return _thisStckPricRgds; }
            set { _thisStckPricRgds = value; }
        }

        /// public propaty name  :  ThisStckPricDis
        /// <summary>今回値引金額プロパティ</summary>
        /// <value>支払情報用</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   今回値引金額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 ThisStckPricDis
        {
            get { return _thisStckPricDis; }
            set { _thisStckPricDis = value; }
        }

        /// public propaty name  :  OfsThisTimeStock
        /// <summary>相殺後今回仕入金額プロパティ</summary>
        /// <value>支払情報用</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   相殺後今回仕入金額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 OfsThisTimeStock
        {
            get { return _ofsThisTimeStock; }
            set { _ofsThisTimeStock = value; }
        }

        /// public propaty name  :  OfsThisStockTax
        /// <summary>相殺後今回仕入消費税プロパティ</summary>
        /// <value>支払情報用</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   相殺後今回仕入消費税プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 OfsThisStockTax
        {
            get { return _ofsThisStockTax; }
            set { _ofsThisStockTax = value; }
        }

        /// public propaty name  :  StockTotalPayBalance
        /// <summary>仕入合計残高（支払計）プロパティ</summary>
        /// <value>支払情報用</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入合計残高（支払計）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 StockTotalPayBalance
        {
            get { return _stockTotalPayBalance; }
            set { _stockTotalPayBalance = value; }
        }

        /// public propaty name  :  MonthLastTimeAccPay
        /// <summary>前回買掛金額プロパティ</summary>
        /// <value>当月用　前月末残</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   前回買掛金額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 MonthLastTimeAccPay
        {
            get { return _monthLastTimeAccPay; }
            set { _monthLastTimeAccPay = value; }
        }

        /// public propaty name  :  MonthCashePayment
        /// <summary>当月情報(現金)プロパティ</summary>
        /// <value>当月用</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   当月情報(現金)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 MonthCashePayment
        {
            get { return _monthCashePayment; }
            set { _monthCashePayment = value; }
        }

        /// public propaty name  :  MonthTrfrPayment
        /// <summary>当月情報(振込)プロパティ</summary>
        /// <value>当月用</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   当月情報(振込)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 MonthTrfrPayment
        {
            get { return _monthTrfrPayment; }
            set { _monthTrfrPayment = value; }
        }

        /// public propaty name  :  MonthCheckKPayment
        /// <summary>当月情報(小切手)プロパティ</summary>
        /// <value>当月用</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   当月情報(小切手)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 MonthCheckKPayment
        {
            get { return _monthCheckKPayment; }
            set { _monthCheckKPayment = value; }
        }

        /// public propaty name  :  MonthDraftPayment
        /// <summary>当月情報(手形)プロパティ</summary>
        /// <value>当月用</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   当月情報(手形)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 MonthDraftPayment
        {
            get { return _monthDraftPayment; }
            set { _monthDraftPayment = value; }
        }

        /// public propaty name  :  MonthOffsetPayment
        /// <summary>当月情報(相殺)プロパティ</summary>
        /// <value>当月用</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   当月情報(相殺)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 MonthOffsetPayment
        {
            get { return _monthOffsetPayment; }
            set { _monthOffsetPayment = value; }
        }

        /// public propaty name  :  MonthFundtransferPayment
        /// <summary>当月情報(口座振替)プロパティ</summary>
        /// <value>当月用</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   当月情報(口座振替)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 MonthFundtransferPayment
        {
            get { return _monthFundtransferPayment; }
            set { _monthFundtransferPayment = value; }
        }

        /// public propaty name  :  MonthEmoneyPayment
        /// <summary>当月情報(E-Money)プロパティ</summary>
        /// <value>当月用</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   当月情報(E-Money)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 MonthEmoneyPayment
        {
            get { return _monthEmoneyPayment; }
            set { _monthEmoneyPayment = value; }
        }

        /// public propaty name  :  MonthOtherPayment
        /// <summary>当月情報(その他)プロパティ</summary>
        /// <value>当月用</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   当月情報(その他)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 MonthOtherPayment
        {
            get { return _monthOtherPayment; }
            set { _monthOtherPayment = value; }
        }

        /// public propaty name  :  MonthThisTimeFeePayNrml
        /// <summary>当月情報(手数料)プロパティ</summary>
        /// <value>当月用</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   当月情報(手数料)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 MonthThisTimeFeePayNrml
        {
            get { return _monthThisTimeFeePayNrml; }
            set { _monthThisTimeFeePayNrml = value; }
        }

        /// public propaty name  :  MonthThisTimeDisPayNrml
        /// <summary>当月情報(値引)プロパティ</summary>
        /// <value>当月用</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   当月情報(値引)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 MonthThisTimeDisPayNrml
        {
            get { return _monthThisTimeDisPayNrml; }
            set { _monthThisTimeDisPayNrml = value; }
        }

        /// public propaty name  :  MonthStockSlipCount
        /// <summary>当月仕入伝票枚数プロパティ</summary>
        /// <value>当月用</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   当月仕入伝票枚数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 MonthStockSlipCount
        {
            get { return _monthStockSlipCount; }
            set { _monthStockSlipCount = value; }
        }

        /// public propaty name  :  MonthThisTimeStockPrice
        /// <summary>当月今回仕入金額プロパティ</summary>
        /// <value>当月用</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   当月今回仕入金額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 MonthThisTimeStockPrice
        {
            get { return _monthThisTimeStockPrice; }
            set { _monthThisTimeStockPrice = value; }
        }

        /// public propaty name  :  MonthThisStckPricRgds
        /// <summary>当月今回返品金額プロパティ</summary>
        /// <value>当月用</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   当月今回返品金額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 MonthThisStckPricRgds
        {
            get { return _monthThisStckPricRgds; }
            set { _monthThisStckPricRgds = value; }
        }

        /// public propaty name  :  MonthThisStckPricDis
        /// <summary>当月今回値引金額プロパティ</summary>
        /// <value>当月用</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   当月今回値引金額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 MonthThisStckPricDis
        {
            get { return _monthThisStckPricDis; }
            set { _monthThisStckPricDis = value; }
        }

        /// public propaty name  :  MonthOfsThisTimeStock
        /// <summary>当月相殺後今回仕入金額プロパティ</summary>
        /// <value>当月用</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   当月相殺後今回仕入金額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 MonthOfsThisTimeStock
        {
            get { return _monthOfsThisTimeStock; }
            set { _monthOfsThisTimeStock = value; }
        }

        /// public propaty name  :  MonthOfsThisStockTax
        /// <summary>当月相殺後今回仕入消費税プロパティ</summary>
        /// <value>当月用</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   当月相殺後今回仕入消費税プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 MonthOfsThisStockTax
        {
            get { return _monthOfsThisStockTax; }
            set { _monthOfsThisStockTax = value; }
        }

        /// public propaty name  :  MonthStckTtlAccPayBalance
        /// <summary>当月仕入合計残高（買掛計）プロパティ</summary>
        /// <value>当月用　現在売掛残高</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   当月仕入合計残高（買掛計）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 MonthStckTtlAccPayBalance
        {
            get { return _monthStckTtlAccPayBalance; }
            set { _monthStckTtlAccPayBalance = value; }
        }

        /// public propaty name  :  YearStockSlipCount
        /// <summary>当期仕入伝票枚数プロパティ</summary>
        /// <value>当期用</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   当期仕入伝票枚数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 YearStockSlipCount
        {
            get { return _yearStockSlipCount; }
            set { _yearStockSlipCount = value; }
        }

        /// public propaty name  :  YearThisTimeStockPrice
        /// <summary>当期今回仕入金額プロパティ</summary>
        /// <value>当期用</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   当期今回仕入金額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 YearThisTimeStockPrice
        {
            get { return _yearThisTimeStockPrice; }
            set { _yearThisTimeStockPrice = value; }
        }

        /// public propaty name  :  YearThisStckPricRgds
        /// <summary>当期今回返品金額プロパティ</summary>
        /// <value>当期用</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   当期今回返品金額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 YearThisStckPricRgds
        {
            get { return _yearThisStckPricRgds; }
            set { _yearThisStckPricRgds = value; }
        }

        /// public propaty name  :  YearThisStckPricDis
        /// <summary>当期今回値引金額プロパティ</summary>
        /// <value>当期用</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   当期今回値引金額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 YearThisStckPricDis
        {
            get { return _yearThisStckPricDis; }
            set { _yearThisStckPricDis = value; }
        }

        /// public propaty name  :  YearOfsThisTimeStock
        /// <summary>当期相殺後今回仕入金額プロパティ</summary>
        /// <value>当期用</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   当期相殺後今回仕入金額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 YearOfsThisTimeStock
        {
            get { return _yearOfsThisTimeStock; }
            set { _yearOfsThisTimeStock = value; }
        }

        /// public propaty name  :  YearOfsThisStockTax
        /// <summary>当期相殺後今回仕入消費税プロパティ</summary>
        /// <value>当期用</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   当期相殺後今回仕入消費税プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 YearOfsThisStockTax
        {
            get { return _yearOfsThisStockTax; }
            set { _yearOfsThisStockTax = value; }
        }


        /// <summary>
        /// 仕入年間実績照会(残高照会)抽出結果クラスワークワークコンストラクタ
        /// </summary>
        /// <returns>SuppYearResultAccPayWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SuppYearResultAccPayWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public SuppYearResultAccPayWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>SuppYearResultAccPayWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   SuppYearResultAccPayWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class SuppYearResultAccPayWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   SuppYearResultAccPayWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  SuppYearResultAccPayWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is SuppYearResultAccPayWork || graph is ArrayList || graph is SuppYearResultAccPayWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(SuppYearResultAccPayWork).FullName));

            if (graph != null && graph is SuppYearResultAccPayWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.SuppYearResultAccPayWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is SuppYearResultAccPayWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((SuppYearResultAccPayWork[])graph).Length;
            }
            else if (graph is SuppYearResultAccPayWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //繰り返し数	

            //仕入3回前残高（支払計）
            serInfo.MemberInfo.Add(typeof(Int64)); //StockTtl3TmBfBlPay
            //仕入2回前残高（支払計）
            serInfo.MemberInfo.Add(typeof(Int64)); //StockTtl2TmBfBlPay
            //前回支払金額
            serInfo.MemberInfo.Add(typeof(Int64)); //LastTimePayment
            //支払情報(現金)
            serInfo.MemberInfo.Add(typeof(Int64)); //CashePayment
            //支払情報(振込)
            serInfo.MemberInfo.Add(typeof(Int64)); //TrfrPayment
            //支払情報(小切手)
            serInfo.MemberInfo.Add(typeof(Int64)); //CheckKPayment
            //支払情報(手形)
            serInfo.MemberInfo.Add(typeof(Int64)); //DraftPayment
            //支払情報(相殺)
            serInfo.MemberInfo.Add(typeof(Int64)); //OffsetPayment
            //支払情報(口座振替)
            serInfo.MemberInfo.Add(typeof(Int64)); //FundtransferPayment
            //支払情報(E-Money)
            serInfo.MemberInfo.Add(typeof(Int64)); //EmoneyPayment
            //支払情報(その他)
            serInfo.MemberInfo.Add(typeof(Int64)); //OtherPayment
            //支払情報(手数料)
            serInfo.MemberInfo.Add(typeof(Int64)); //ThisTimeFeePayNrml
            //支払情報(値引)
            serInfo.MemberInfo.Add(typeof(Int64)); //ThisTimeDisPayNrml
            //仕入伝票枚数
            serInfo.MemberInfo.Add(typeof(Int32)); //StockSlipCount
            //今回仕入金額
            serInfo.MemberInfo.Add(typeof(Int64)); //ThisTimeStockPrice
            //今回返品金額
            serInfo.MemberInfo.Add(typeof(Int64)); //ThisStckPricRgds
            //今回値引金額
            serInfo.MemberInfo.Add(typeof(Int64)); //ThisStckPricDis
            //相殺後今回仕入金額
            serInfo.MemberInfo.Add(typeof(Int64)); //OfsThisTimeStock
            //相殺後今回仕入消費税
            serInfo.MemberInfo.Add(typeof(Int64)); //OfsThisStockTax
            //仕入合計残高（支払計）
            serInfo.MemberInfo.Add(typeof(Int64)); //StockTotalPayBalance
            //前回買掛金額
            serInfo.MemberInfo.Add(typeof(Int64)); //MonthLastTimeAccPay
            //当月情報(現金)
            serInfo.MemberInfo.Add(typeof(Int64)); //MonthCashePayment
            //当月情報(振込)
            serInfo.MemberInfo.Add(typeof(Int64)); //MonthTrfrPayment
            //当月情報(小切手)
            serInfo.MemberInfo.Add(typeof(Int64)); //MonthCheckKPayment
            //当月情報(手形)
            serInfo.MemberInfo.Add(typeof(Int64)); //MonthDraftPayment
            //当月情報(相殺)
            serInfo.MemberInfo.Add(typeof(Int64)); //MonthOffsetPayment
            //当月情報(口座振替)
            serInfo.MemberInfo.Add(typeof(Int64)); //MonthFundtransferPayment
            //当月情報(E-Money)
            serInfo.MemberInfo.Add(typeof(Int64)); //MonthEmoneyPayment
            //当月情報(その他)
            serInfo.MemberInfo.Add(typeof(Int64)); //MonthOtherPayment
            //当月情報(手数料)
            serInfo.MemberInfo.Add(typeof(Int64)); //MonthThisTimeFeePayNrml
            //当月情報(値引)
            serInfo.MemberInfo.Add(typeof(Int64)); //MonthThisTimeDisPayNrml
            //当月仕入伝票枚数
            serInfo.MemberInfo.Add(typeof(Int32)); //MonthStockSlipCount
            //当月今回仕入金額
            serInfo.MemberInfo.Add(typeof(Int64)); //MonthThisTimeStockPrice
            //当月今回返品金額
            serInfo.MemberInfo.Add(typeof(Int64)); //MonthThisStckPricRgds
            //当月今回値引金額
            serInfo.MemberInfo.Add(typeof(Int64)); //MonthThisStckPricDis
            //当月相殺後今回仕入金額
            serInfo.MemberInfo.Add(typeof(Int64)); //MonthOfsThisTimeStock
            //当月相殺後今回仕入消費税
            serInfo.MemberInfo.Add(typeof(Int64)); //MonthOfsThisStockTax
            //当月仕入合計残高（買掛計）
            serInfo.MemberInfo.Add(typeof(Int64)); //MonthStckTtlAccPayBalance
            //当期仕入伝票枚数
            serInfo.MemberInfo.Add(typeof(Int32)); //YearStockSlipCount
            //当期今回仕入金額
            serInfo.MemberInfo.Add(typeof(Int64)); //YearThisTimeStockPrice
            //当期今回返品金額
            serInfo.MemberInfo.Add(typeof(Int64)); //YearThisStckPricRgds
            //当期今回値引金額
            serInfo.MemberInfo.Add(typeof(Int64)); //YearThisStckPricDis
            //当期相殺後今回仕入金額
            serInfo.MemberInfo.Add(typeof(Int64)); //YearOfsThisTimeStock
            //当期相殺後今回仕入消費税
            serInfo.MemberInfo.Add(typeof(Int64)); //YearOfsThisStockTax


            serInfo.Serialize(writer, serInfo);
            if (graph is SuppYearResultAccPayWork)
            {
                SuppYearResultAccPayWork temp = (SuppYearResultAccPayWork)graph;

                SetSuppYearResultAccPayWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is SuppYearResultAccPayWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((SuppYearResultAccPayWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (SuppYearResultAccPayWork temp in lst)
                {
                    SetSuppYearResultAccPayWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// SuppYearResultAccPayWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 44;

        /// <summary>
        ///  SuppYearResultAccPayWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   SuppYearResultAccPayWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetSuppYearResultAccPayWork(System.IO.BinaryWriter writer, SuppYearResultAccPayWork temp)
        {
            //仕入3回前残高（支払計）
            writer.Write(temp.StockTtl3TmBfBlPay);
            //仕入2回前残高（支払計）
            writer.Write(temp.StockTtl2TmBfBlPay);
            //前回支払金額
            writer.Write(temp.LastTimePayment);
            //支払情報(現金)
            writer.Write(temp.CashePayment);
            //支払情報(振込)
            writer.Write(temp.TrfrPayment);
            //支払情報(小切手)
            writer.Write(temp.CheckKPayment);
            //支払情報(手形)
            writer.Write(temp.DraftPayment);
            //支払情報(相殺)
            writer.Write(temp.OffsetPayment);
            //支払情報(口座振替)
            writer.Write(temp.FundtransferPayment);
            //支払情報(E-Money)
            writer.Write(temp.EmoneyPayment);
            //支払情報(その他)
            writer.Write(temp.OtherPayment);
            //支払情報(手数料)
            writer.Write(temp.ThisTimeFeePayNrml);
            //支払情報(値引)
            writer.Write(temp.ThisTimeDisPayNrml);
            //仕入伝票枚数
            writer.Write(temp.StockSlipCount);
            //今回仕入金額
            writer.Write(temp.ThisTimeStockPrice);
            //今回返品金額
            writer.Write(temp.ThisStckPricRgds);
            //今回値引金額
            writer.Write(temp.ThisStckPricDis);
            //相殺後今回仕入金額
            writer.Write(temp.OfsThisTimeStock);
            //相殺後今回仕入消費税
            writer.Write(temp.OfsThisStockTax);
            //仕入合計残高（支払計）
            writer.Write(temp.StockTotalPayBalance);
            //前回買掛金額
            writer.Write(temp.MonthLastTimeAccPay);
            //当月情報(現金)
            writer.Write(temp.MonthCashePayment);
            //当月情報(振込)
            writer.Write(temp.MonthTrfrPayment);
            //当月情報(小切手)
            writer.Write(temp.MonthCheckKPayment);
            //当月情報(手形)
            writer.Write(temp.MonthDraftPayment);
            //当月情報(相殺)
            writer.Write(temp.MonthOffsetPayment);
            //当月情報(口座振替)
            writer.Write(temp.MonthFundtransferPayment);
            //当月情報(E-Money)
            writer.Write(temp.MonthEmoneyPayment);
            //当月情報(その他)
            writer.Write(temp.MonthOtherPayment);
            //当月情報(手数料)
            writer.Write(temp.MonthThisTimeFeePayNrml);
            //当月情報(値引)
            writer.Write(temp.MonthThisTimeDisPayNrml);
            //当月仕入伝票枚数
            writer.Write(temp.MonthStockSlipCount);
            //当月今回仕入金額
            writer.Write(temp.MonthThisTimeStockPrice);
            //当月今回返品金額
            writer.Write(temp.MonthThisStckPricRgds);
            //当月今回値引金額
            writer.Write(temp.MonthThisStckPricDis);
            //当月相殺後今回仕入金額
            writer.Write(temp.MonthOfsThisTimeStock);
            //当月相殺後今回仕入消費税
            writer.Write(temp.MonthOfsThisStockTax);
            //当月仕入合計残高（買掛計）
            writer.Write(temp.MonthStckTtlAccPayBalance);
            //当期仕入伝票枚数
            writer.Write(temp.YearStockSlipCount);
            //当期今回仕入金額
            writer.Write(temp.YearThisTimeStockPrice);
            //当期今回返品金額
            writer.Write(temp.YearThisStckPricRgds);
            //当期今回値引金額
            writer.Write(temp.YearThisStckPricDis);
            //当期相殺後今回仕入金額
            writer.Write(temp.YearOfsThisTimeStock);
            //当期相殺後今回仕入消費税
            writer.Write(temp.YearOfsThisStockTax);

        }

        /// <summary>
        ///  SuppYearResultAccPayWorkインスタンス取得
        /// </summary>
        /// <returns>SuppYearResultAccPayWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SuppYearResultAccPayWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private SuppYearResultAccPayWork GetSuppYearResultAccPayWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            SuppYearResultAccPayWork temp = new SuppYearResultAccPayWork();

            //仕入3回前残高（支払計）
            temp.StockTtl3TmBfBlPay = reader.ReadInt64();
            //仕入2回前残高（支払計）
            temp.StockTtl2TmBfBlPay = reader.ReadInt64();
            //前回支払金額
            temp.LastTimePayment = reader.ReadInt64();
            //支払情報(現金)
            temp.CashePayment = reader.ReadInt64();
            //支払情報(振込)
            temp.TrfrPayment = reader.ReadInt64();
            //支払情報(小切手)
            temp.CheckKPayment = reader.ReadInt64();
            //支払情報(手形)
            temp.DraftPayment = reader.ReadInt64();
            //支払情報(相殺)
            temp.OffsetPayment = reader.ReadInt64();
            //支払情報(口座振替)
            temp.FundtransferPayment = reader.ReadInt64();
            //支払情報(E-Money)
            temp.EmoneyPayment = reader.ReadInt64();
            //支払情報(その他)
            temp.OtherPayment = reader.ReadInt64();
            //支払情報(手数料)
            temp.ThisTimeFeePayNrml = reader.ReadInt64();
            //支払情報(値引)
            temp.ThisTimeDisPayNrml = reader.ReadInt64();
            //仕入伝票枚数
            temp.StockSlipCount = reader.ReadInt32();
            //今回仕入金額
            temp.ThisTimeStockPrice = reader.ReadInt64();
            //今回返品金額
            temp.ThisStckPricRgds = reader.ReadInt64();
            //今回値引金額
            temp.ThisStckPricDis = reader.ReadInt64();
            //相殺後今回仕入金額
            temp.OfsThisTimeStock = reader.ReadInt64();
            //相殺後今回仕入消費税
            temp.OfsThisStockTax = reader.ReadInt64();
            //仕入合計残高（支払計）
            temp.StockTotalPayBalance = reader.ReadInt64();
            //前回買掛金額
            temp.MonthLastTimeAccPay = reader.ReadInt64();
            //当月情報(現金)
            temp.MonthCashePayment = reader.ReadInt64();
            //当月情報(振込)
            temp.MonthTrfrPayment = reader.ReadInt64();
            //当月情報(小切手)
            temp.MonthCheckKPayment = reader.ReadInt64();
            //当月情報(手形)
            temp.MonthDraftPayment = reader.ReadInt64();
            //当月情報(相殺)
            temp.MonthOffsetPayment = reader.ReadInt64();
            //当月情報(口座振替)
            temp.MonthFundtransferPayment = reader.ReadInt64();
            //当月情報(E-Money)
            temp.MonthEmoneyPayment = reader.ReadInt64();
            //当月情報(その他)
            temp.MonthOtherPayment = reader.ReadInt64();
            //当月情報(手数料)
            temp.MonthThisTimeFeePayNrml = reader.ReadInt64();
            //当月情報(値引)
            temp.MonthThisTimeDisPayNrml = reader.ReadInt64();
            //当月仕入伝票枚数
            temp.MonthStockSlipCount = reader.ReadInt32();
            //当月今回仕入金額
            temp.MonthThisTimeStockPrice = reader.ReadInt64();
            //当月今回返品金額
            temp.MonthThisStckPricRgds = reader.ReadInt64();
            //当月今回値引金額
            temp.MonthThisStckPricDis = reader.ReadInt64();
            //当月相殺後今回仕入金額
            temp.MonthOfsThisTimeStock = reader.ReadInt64();
            //当月相殺後今回仕入消費税
            temp.MonthOfsThisStockTax = reader.ReadInt64();
            //当月仕入合計残高（買掛計）
            temp.MonthStckTtlAccPayBalance = reader.ReadInt64();
            //当期仕入伝票枚数
            temp.YearStockSlipCount = reader.ReadInt32();
            //当期今回仕入金額
            temp.YearThisTimeStockPrice = reader.ReadInt64();
            //当期今回返品金額
            temp.YearThisStckPricRgds = reader.ReadInt64();
            //当期今回値引金額
            temp.YearThisStckPricDis = reader.ReadInt64();
            //当期相殺後今回仕入金額
            temp.YearOfsThisTimeStock = reader.ReadInt64();
            //当期相殺後今回仕入消費税
            temp.YearOfsThisStockTax = reader.ReadInt64();


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
        /// <returns>SuppYearResultAccPayWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SuppYearResultAccPayWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                SuppYearResultAccPayWork temp = GetSuppYearResultAccPayWork(reader, serInfo);
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
                    retValue = (SuppYearResultAccPayWork[])lst.ToArray(typeof(SuppYearResultAccPayWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }



}

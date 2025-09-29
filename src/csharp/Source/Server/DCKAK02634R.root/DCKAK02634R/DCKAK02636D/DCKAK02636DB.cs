using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   AccPaymentListResultWork
    /// <summary>
    ///                      買掛残高一覧表抽出結果クラスワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   買掛残高一覧表抽出結果クラスワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/09/25  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// <br>UpdateNote       :   11570208-00 軽減税率対応</br>
    /// <br>Programmer       :   3H 劉星光</br>
    /// <br>Date	         :   2020/03/02</br>
    /// <br>Update Note      :   11870141-00 インボイス対応（税率別合計金額不具合修正）</br>
    /// <br>Programmer       :   3H 仰亮亮</br>
    /// <br>Date             :   2022/10/09</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class AccPaymentListResultWork
    {
        /// <summary>拠点コード</summary>
        /// <remarks>計上拠点コード</remarks>
        private string _addUpSecCode = "";

        /// <summary>拠点名称</summary>
        /// <remarks>拠点ガイド略称</remarks>
        private string _sectionGuideSnm = "";

        /// <summary>支払先コード</summary>
        private Int32 _payeeCode;

        /// <summary>支払先略称</summary>
        private string _payeeSnm = "";

        /// <summary>前月買掛残</summary>
        /// <remarks>前回買掛金額</remarks>
        private Int64 _lastTimeAccPay;

        /// <summary>当月支払</summary>
        /// <remarks>今回支払金額（通常支払）</remarks>
        private Int64 _thisTimePayNrml;

        /// <summary>繰越額</summary>
        /// <remarks>今回繰越残高（買掛計）</remarks>
        private Int64 _thisTimeTtlBlcAcPay;

        /// <summary>仕入額</summary>
        /// <remarks>相殺後今回仕入金額</remarks>
        private Int64 _ofsThisTimeStock;

        /// <summary>返品値引</summary>
        /// <remarks>今回返品金額+今回値引金額</remarks>
        private Int64 _thisRgdsDisPric;

        /// <summary>消費税</summary>
        /// <remarks>相殺後今回仕入消費税</remarks>
        private Int64 _ofsThisStockTax;

        /// <summary>当月末残高</summary>
        /// <remarks>仕入合計残高</remarks>
        private Int64 _stckTtlAccPayBalance;

        /// <summary>枚数</summary>
        /// <remarks>仕入伝票枚数</remarks>
        private Int32 _stockSlipCount;

        /// <summary>手数料</summary>
        /// <remarks>今回手数料額（通常支払）</remarks>
        private Int64 _thisTimeFeePayNrml;

        /// <summary>値引</summary>
        /// <remarks>今回値引額（通常支払）</remarks>
        private Int64 _thisTimeDisPayNrml;

        /// <summary>現金</summary>
        /// <remarks>金種コード：現金の支払金額</remarks>
        private Int64 _cashPayment;

        /// <summary>振込</summary>
        /// <remarks>金種コード：振込の支払金額</remarks>
        private Int64 _trfrPayment;

        /// <summary>小切手</summary>
        /// <remarks>金種コード：小切手の支払金額</remarks>
        private Int64 _checkPayment;

        /// <summary>手形</summary>
        /// <remarks>金種コード：手形の支払金額</remarks>
        private Int64 _draftPayment;

        /// <summary>相殺</summary>
        /// <remarks>金種コード：相殺の支払金額</remarks>
        private Int64 _offsetPayment;

        /// <summary>口座振替</summary>
        /// <remarks>金種コード：口座振替の支払金額</remarks>
        private Int64 _fundTransferPayment;

        /// <summary>その他</summary>
        /// <remarks>金種コード：その他の支払金額</remarks>
        private Int64 _othsPayment;

        /// <summary>今回仕入金額</summary>
        /// <remarks>値引、返品を含まない 税抜きの仕入金額</remarks>
        private Int64 _thisTimeStockPrice;

        // --- ADD START 3H 劉星光 2020/03/02 ---------->>>>>
        /// <summary>税率1タイトル</summary>
        /// <remarks>税率1タイトル</remarks>
        private string _titleTaxRate1 = string.Empty;

        /// <summary>税率2タイトル</summary>
        /// <remarks>税率2タイトル</remarks>
        private string _titleTaxRate2 = string.Empty;

        /// <summary>仕入額(計税率1)</summary>
        /// <remarks>仕入額(計税率1)</remarks>
        private Int64 _totalThisTimeStockPriceTaxRate1;

        /// <summary>仕入額(計税率2)</summary>
        /// <remarks>仕入額(計税率2)</remarks>
        private Int64 _totalThisTimeStockPriceTaxRate2;

        /// <summary>仕入額(計その他)</summary>
        /// <remarks>仕入額(計その他)</remarks>
        private Int64 _totalThisTimeStockPriceOther;

        /// <summary>返品値引(計税率1)</summary>
        /// <remarks>返品値引(計税率1)</remarks>
        private Int64 _totalThisRgdsDisPricTaxRate1;

        /// <summary>返品値引(計税率2)</summary>
        /// <remarks>返品値引(計税率2)</remarks>
        private Int64 _totalThisRgdsDisPricTaxRate2;

        /// <summary>返品値引(計その他)</summary>
        /// <remarks>返品値引(計その他)</remarks>
        private Int64 _totalThisRgdsDisPricOther;

        /// <summary>純仕入額(計税率1)</summary>
        /// <remarks>純仕入額(計税率1)</remarks>
        private Int64 _totalPureStockTaxRate1;

        /// <summary>純仕入額(計税率2)</summary>
        /// <remarks>純仕入額(計税率2)</remarks>
        private Int64 _totalPureStockTaxRate2;

        /// <summary>純仕入額(計その他)</summary>
        /// <remarks>純仕入額(計その他)</remarks>
        private Int64 _totalPureStockOther;

        /// <summary>消費税(計税率1)</summary>
        /// <remarks>消費税(計税率1)</remarks>
        private Int64 _totalStockPricTaxTaxRate1;

        /// <summary>消費税(計税率2)</summary>
        /// <remarks>消費税(計税率2)</remarks>
        private Int64 _totalStockPricTaxTaxRate2;

        /// <summary>消費税(計その他)</summary>
        /// <remarks>消費税(計その他)</remarks>
        private Int64 _totalStockPricTaxOther;

        /// <summary>当月合計(計税率1)</summary>
        /// <remarks>当月合計(計税率1)</remarks>
        private Int64 _totalStckTtlAccPayBalanceTaxRate1;

        /// <summary>当月合計(計税率2)</summary>
        /// <remarks>当月合計(計税率2)</remarks>
        private Int64 _totalStckTtlAccPayBalanceTaxRate2;

        /// <summary>当月合計(計その他)</summary>
        /// <remarks>当月合計(計その他)</remarks>
        private Int64 _totalStckTtlAccPayBalanceOther;

        /// <summary>枚数(計税率1)</summary>
        /// <remarks>枚数(計税率1)</remarks>
        private Int32 _totalStockSlipCountTaxRate1;

        /// <summary>枚数(計税率2)</summary>
        /// <remarks>枚数(計税率2)</remarks>
        private Int32 _totalStockSlipCountTaxRate2;

        /// <summary>枚数(計その他)</summary>
        /// <remarks>枚数(計その他)</remarks>
        private Int32 _totalStockSlipCountOther;
        // --- ADD END 3H 劉星光 2020/03/02 ----------<<<<<

        // --- ADD START 3H 仰亮亮 2022/10/09 ----->>>>>
        /// <summary>仕入額(計非課税)</summary>
        /// <remarks>仕入額(計非課税)</remarks>
        private Int64 _totalThisTimeStockPriceTaxFree;

        /// <summary>返品値引(計非課税)</summary>
        /// <remarks>返品値引(計非課税)</remarks>
        private Int64 _totalThisRgdsDisPricTaxFree;

        /// <summary>純仕入額(計非課税)</summary>
        /// <remarks>純仕入額(計非課税)</remarks>
        private Int64 _totalPureStockTaxFree;

        /// <summary>消費税(計非課税)</summary>
        /// <remarks>消費税(計非課税)</remarks>
        private Int64 _totalStockPricTaxTaxFree;

        /// <summary>当月合計(計非課税)</summary>
        /// <remarks>当月合計(計非課税)</remarks>
        private Int64 _totalStckTtlAccPayBalanceTaxFree;

        /// <summary>枚数(計非課税)</summary>
        /// <remarks>枚数(計非課税)</remarks>
        private Int32 _totalStockSlipCountTaxFree;
        // --- ADD END 3H 仰亮亮 2022/10/09 -----<<<<<

        /// public propaty name  :  AddUpSecCode
        /// <summary>拠点コードプロパティ</summary>
        /// <value>計上拠点コード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string AddUpSecCode
        {
            get { return _addUpSecCode; }
            set { _addUpSecCode = value; }
        }

        /// public propaty name  :  SectionGuideSnm
        /// <summary>拠点名称プロパティ</summary>
        /// <value>拠点ガイド略称</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SectionGuideSnm
        {
            get { return _sectionGuideSnm; }
            set { _sectionGuideSnm = value; }
        }

        /// public propaty name  :  PayeeCode
        /// <summary>支払先コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   支払先コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PayeeCode
        {
            get { return _payeeCode; }
            set { _payeeCode = value; }
        }

        /// public propaty name  :  PayeeSnm
        /// <summary>支払先略称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   支払先略称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PayeeSnm
        {
            get { return _payeeSnm; }
            set { _payeeSnm = value; }
        }

        /// public propaty name  :  LastTimeAccPay
        /// <summary>前月買掛残プロパティ</summary>
        /// <value>前回買掛金額</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   前月買掛残プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 LastTimeAccPay
        {
            get { return _lastTimeAccPay; }
            set { _lastTimeAccPay = value; }
        }

        /// public propaty name  :  ThisTimePayNrml
        /// <summary>当月支払プロパティ</summary>
        /// <value>今回支払金額（通常支払）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   当月支払プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 ThisTimePayNrml
        {
            get { return _thisTimePayNrml; }
            set { _thisTimePayNrml = value; }
        }

        /// public propaty name  :  ThisTimeTtlBlcAcPay
        /// <summary>繰越額プロパティ</summary>
        /// <value>今回繰越残高（買掛計）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   繰越額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 ThisTimeTtlBlcAcPay
        {
            get { return _thisTimeTtlBlcAcPay; }
            set { _thisTimeTtlBlcAcPay = value; }
        }

        /// public propaty name  :  OfsThisTimeStock
        /// <summary>仕入額プロパティ</summary>
        /// <value>相殺後今回仕入金額</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 OfsThisTimeStock
        {
            get { return _ofsThisTimeStock; }
            set { _ofsThisTimeStock = value; }
        }

        /// public propaty name  :  ThisRgdsDisPric
        /// <summary>返品値引プロパティ</summary>
        /// <value>今回返品金額+今回値引金額</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   返品値引プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 ThisRgdsDisPric
        {
            get { return _thisRgdsDisPric; }
            set { _thisRgdsDisPric = value; }
        }

        /// public propaty name  :  OfsThisStockTax
        /// <summary>消費税プロパティ</summary>
        /// <value>相殺後今回仕入消費税</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   消費税プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 OfsThisStockTax
        {
            get { return _ofsThisStockTax; }
            set { _ofsThisStockTax = value; }
        }

        /// public propaty name  :  StckTtlAccPayBalance
        /// <summary>当月末残高プロパティ</summary>
        /// <value>仕入合計残高</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   当月末残高プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 StckTtlAccPayBalance
        {
            get { return _stckTtlAccPayBalance; }
            set { _stckTtlAccPayBalance = value; }
        }

        /// public propaty name  :  StockSlipCount
        /// <summary>枚数プロパティ</summary>
        /// <value>仕入伝票枚数</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   枚数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 StockSlipCount
        {
            get { return _stockSlipCount; }
            set { _stockSlipCount = value; }
        }

        /// public propaty name  :  ThisTimeFeePayNrml
        /// <summary>手数料プロパティ</summary>
        /// <value>今回手数料額（通常支払）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   手数料プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 ThisTimeFeePayNrml
        {
            get { return _thisTimeFeePayNrml; }
            set { _thisTimeFeePayNrml = value; }
        }

        /// public propaty name  :  ThisTimeDisPayNrml
        /// <summary>値引プロパティ</summary>
        /// <value>今回値引額（通常支払）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   値引プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 ThisTimeDisPayNrml
        {
            get { return _thisTimeDisPayNrml; }
            set { _thisTimeDisPayNrml = value; }
        }

        /// public propaty name  :  CashPayment
        /// <summary>現金プロパティ</summary>
        /// <value>金種コード：現金の支払金額</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   現金プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 CashPayment
        {
            get { return _cashPayment; }
            set { _cashPayment = value; }
        }

        /// public propaty name  :  TrfrPayment
        /// <summary>振込プロパティ</summary>
        /// <value>金種コード：振込の支払金額</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   振込プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 TrfrPayment
        {
            get { return _trfrPayment; }
            set { _trfrPayment = value; }
        }

        /// public propaty name  :  CheckPayment
        /// <summary>小切手プロパティ</summary>
        /// <value>金種コード：小切手の支払金額</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   小切手プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 CheckPayment
        {
            get { return _checkPayment; }
            set { _checkPayment = value; }
        }

        /// public propaty name  :  DraftPayment
        /// <summary>手形プロパティ</summary>
        /// <value>金種コード：手形の支払金額</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   手形プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 DraftPayment
        {
            get { return _draftPayment; }
            set { _draftPayment = value; }
        }

        /// public propaty name  :  OffsetPayment
        /// <summary>相殺プロパティ</summary>
        /// <value>金種コード：相殺の支払金額</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   相殺プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 OffsetPayment
        {
            get { return _offsetPayment; }
            set { _offsetPayment = value; }
        }

        /// public propaty name  :  FundTransferPayment
        /// <summary>口座振替プロパティ</summary>
        /// <value>金種コード：口座振替の支払金額</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   口座振替プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 FundTransferPayment
        {
            get { return _fundTransferPayment; }
            set { _fundTransferPayment = value; }
        }

        /// public propaty name  :  OthsPayment
        /// <summary>その他プロパティ</summary>
        /// <value>金種コード：その他の支払金額</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   その他プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 OthsPayment
        {
            get { return _othsPayment; }
            set { _othsPayment = value; }
        }

        /// public propaty name  :  ThisTimeStockPrice
        /// <summary>今回仕入金額プロパティ</summary>
        /// <value>値引、返品を含まない 税抜きの仕入金額</value>
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

        // --- ADD START 3H 劉星光 2020/03/02 ---------->>>>>
        /// public propaty name  :  TitleTaxRate1
        /// <summary>税率1タイトル</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   税率1タイトル</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string TitleTaxRate1
        {
            get { return _titleTaxRate1; }
            set { _titleTaxRate1 = value; }
        }

        /// public propaty name  :  TitleTaxRate2
        /// <summary>税率2タイトル</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   税率2タイトル</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string TitleTaxRate2
        {
            get { return _titleTaxRate2; }
            set { _titleTaxRate2 = value; }
        }

        /// public propaty name  :  TotalThisTimeStockPriceTaxRate1
        /// <summary>仕入額(計税率1) </summary>
        /// <value>仕入額(計税率1) </value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入額(計税率1) プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 TotalThisTimeStockPriceTaxRate1
        {
            get { return _totalThisTimeStockPriceTaxRate1; }
            set { _totalThisTimeStockPriceTaxRate1 = value; }
        }

        /// public propaty name  :  TotalThisTimeStockPriceTaxRate2
        /// <summary>仕入額(計税率2) </summary>
        /// <value>仕入額(計税率2) </value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入額(計税率2) プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 TotalThisTimeStockPriceTaxRate2
        {
            get { return _totalThisTimeStockPriceTaxRate2; }
            set { _totalThisTimeStockPriceTaxRate2 = value; }
        }

        /// public propaty name  :  TotalThisTimeStockPriceOther
        /// <summary>仕入額(計その他) </summary>
        /// <value>仕入額(計その他) </value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入額(計その他) プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 TotalThisTimeStockPriceOther
        {
            get { return _totalThisTimeStockPriceOther; }
            set { _totalThisTimeStockPriceOther = value; }
        }

        /// public propaty name  :  TotalThisRgdsDisPricTaxRate1
        /// <summary>返品値引(計税率1) </summary>
        /// <value>返品値引(計税率1) </value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   返品値引(計税率1) プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 TotalThisRgdsDisPricTaxRate1
        {
            get { return _totalThisRgdsDisPricTaxRate1; }
            set { _totalThisRgdsDisPricTaxRate1 = value; }
        }

        /// public propaty name  :  TotalThisRgdsDisPricTaxRate2
        /// <summary>返品値引(計税率2) </summary>
        /// <value>返品値引(計税率2) </value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   返品値引(計税率2) プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 TotalThisRgdsDisPricTaxRate2
        {
            get { return _totalThisRgdsDisPricTaxRate2; }
            set { _totalThisRgdsDisPricTaxRate2 = value; }
        }

        /// public propaty name  :  TotalThisRgdsDisPricOther
        /// <summary>返品値引(計その他) </summary>
        /// <value>返品値引(計その他) </value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   返品値引(計その他) プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 TotalThisRgdsDisPricOther
        {
            get { return _totalThisRgdsDisPricOther; }
            set { _totalThisRgdsDisPricOther = value; }
        }

        /// public propaty name  :  TotalPureStockTaxRate1
        /// <summary>純仕入額(計税率1) </summary>
        /// <value>純仕入額(計税率1) </value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   純仕入額(計税率1) プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 TotalPureStockTaxRate1
        {
            get { return _totalPureStockTaxRate1; }
            set { _totalPureStockTaxRate1 = value; }
        }

        /// public propaty name  :  TotalPureStockTaxRate2
        /// <summary>純仕入額(計税率2) </summary>
        /// <value>純仕入額(計税率2) </value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   純仕入額(計税率2) プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 TotalPureStockTaxRate2
        {
            get { return _totalPureStockTaxRate2; }
            set { _totalPureStockTaxRate2 = value; }
        }

        /// public propaty name  :  TotalPureStockOther
        /// <summary>純仕入額(計その他) </summary>
        /// <value>純仕入額(計その他) </value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   純仕入額(計その他) プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 TotalPureStockOther
        {
            get { return _totalPureStockOther; }
            set { _totalPureStockOther = value; }
        }

        /// public propaty name  :  TotalStockPricTaxTaxRate1
        /// <summary>消費税(計税率1) </summary>
        /// <value>消費税(計税率1) </value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   消費税(計税率1) プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 TotalStockPricTaxTaxRate1
        {
            get { return _totalStockPricTaxTaxRate1; }
            set { _totalStockPricTaxTaxRate1 = value; }
        }

        /// public propaty name  :  TotalStockPricTaxTaxRate2
        /// <summary>消費税(計税率2) </summary>
        /// <value>消費税(計税率2) </value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   消費税(計税率2) プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 TotalStockPricTaxTaxRate2
        {
            get { return _totalStockPricTaxTaxRate2; }
            set { _totalStockPricTaxTaxRate2 = value; }
        }

        /// public propaty name  :  TotalStockPricTaxOther
        /// <summary>消費税(計その他) </summary>
        /// <value>消費税(計その他) </value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   消費税(計その他) プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 TotalStockPricTaxOther
        {
            get { return _totalStockPricTaxOther; }
            set { _totalStockPricTaxOther = value; }
        }

        /// public propaty name  :  TotalStckTtlAccPayBalanceTaxRate1
        /// <summary>当月合計(計税率1) </summary>
        /// <value>当月合計(計税率1) </value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   当月合計(計税率1) プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 TotalStckTtlAccPayBalanceTaxRate1
        {
            get { return _totalStckTtlAccPayBalanceTaxRate1; }
            set { _totalStckTtlAccPayBalanceTaxRate1 = value; }
        }

        /// public propaty name  :  TotalStckTtlAccPayBalanceTaxRate2
        /// <summary>当月合計(計税率2) </summary>
        /// <value>当月合計(計税率2) </value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   当月合計(計税率2) プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 TotalStckTtlAccPayBalanceTaxRate2
        {
            get { return _totalStckTtlAccPayBalanceTaxRate2; }
            set { _totalStckTtlAccPayBalanceTaxRate2 = value; }
        }

        /// public propaty name  :  TotalStckTtlAccPayBalanceOther
        /// <summary>当月合計(計その他) </summary>
        /// <value>当月合計(計その他) </value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   当月合計(計その他) プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 TotalStckTtlAccPayBalanceOther
        {
            get { return _totalStckTtlAccPayBalanceOther; }
            set { _totalStckTtlAccPayBalanceOther = value; }
        }

        /// public propaty name  :  TotalStockSlipCountTaxRate1
        /// <summary>枚数(計税率1) </summary>
        /// <value>枚数(計税率1) </value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   枚数(計税率1) プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 TotalStockSlipCountTaxRate1
        {
            get { return _totalStockSlipCountTaxRate1; }
            set { _totalStockSlipCountTaxRate1 = value; }
        }

        /// public propaty name  :  TotalSalesSlipCountTaxRate2
        /// <summary>枚数(計税率2) </summary>
        /// <value>枚数(計税率2) </value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   枚数(計税率2) プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 TotalStockSlipCountTaxRate2
        {
            get { return _totalStockSlipCountTaxRate2; }
            set { _totalStockSlipCountTaxRate2 = value; }
        }

        /// public propaty name  :  TotalStockSlipCountOther
        /// <summary>枚数(計その他) </summary>
        /// <value>枚数(計その他) </value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   枚数(計その他) プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 TotalStockSlipCountOther
        {
            get { return _totalStockSlipCountOther; }
            set { _totalStockSlipCountOther = value; }
        }
        // --- ADD END 3H 劉星光 2020/03/02 ----------<<<<<

        // --- ADD START 3H 仰亮亮 2022/10/09 ----->>>>>
        /// public propaty name  :  TotalThisTimeStockPriceTaxFree
        /// <summary>仕入額(計非課税) </summary>
        /// <value>仕入額(計非課税) </value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入額(計非課税) プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 TotalThisTimeStockPriceTaxFree
        {
            get { return _totalThisTimeStockPriceTaxFree; }
            set { _totalThisTimeStockPriceTaxFree = value; }
        }

        /// public propaty name  :  TotalThisRgdsDisPricTaxFree
        /// <summary>返品値引(計非課税) </summary>
        /// <value>返品値引(計非課税) </value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   返品値引(計非課税) プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 TotalThisRgdsDisPricTaxFree
        {
            get { return _totalThisRgdsDisPricTaxFree; }
            set { _totalThisRgdsDisPricTaxFree = value; }
        }

        /// public propaty name  :  TotalPureStockTaxFree
        /// <summary>純仕入額(計非課税) </summary>
        /// <value>純仕入額(計非課税) </value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   純仕入額(計非課税) プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 TotalPureStockTaxFree
        {
            get { return _totalPureStockTaxFree; }
            set { _totalPureStockTaxFree = value; }
        }

        /// public propaty name  :  TotalStockPricTaxTaxFree
        /// <summary>消費税(計非課税) </summary>
        /// <value>消費税(計非課税) </value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   消費税(計非課税) プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 TotalStockPricTaxTaxFree
        {
            get { return _totalStockPricTaxTaxFree; }
            set { _totalStockPricTaxTaxFree = value; }
        }

        /// public propaty name  :  TotalStckTtlAccPayBalanceTaxFree
        /// <summary>当月合計(計非課税) </summary>
        /// <value>当月合計(計非課税) </value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   当月合計(計非課税) プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 TotalStckTtlAccPayBalanceTaxFree
        {
            get { return _totalStckTtlAccPayBalanceTaxFree; }
            set { _totalStckTtlAccPayBalanceTaxFree = value; }
        }

        /// public propaty name  :  TotalStockSlipCountTaxFree
        /// <summary>枚数(計非課税) </summary>
        /// <value>枚数(計非課税) </value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   枚数(計非課税) プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 TotalStockSlipCountTaxFree
        {
            get { return _totalStockSlipCountTaxFree; }
            set { _totalStockSlipCountTaxFree = value; }
        }
        // --- ADD END 3H 仰亮亮 2022/10/09 -----<<<<<

        /// <summary>
        /// 買掛残高一覧表抽出結果クラスワークコンストラクタ
        /// </summary>
        /// <returns>AccPaymentListResultWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   AccPaymentListResultWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public AccPaymentListResultWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>AccPaymentListResultWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   AccPaymentListResultWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// <br>UpdateNote       :   11570208-00 軽減税率対応</br>
    /// <br>Programmer       :   3H 劉星光</br>
    /// <br>Date	         :   2020/03/02</br>
    /// <br>UpdateNote       :   11870141-00 インボイス対応（税率別合計金額不具合修正）</br>
    /// <br>Programmer       :   3H 仰亮亮</br>
    /// <br>Date             :   2022/10/09</br>
    /// </remarks>
    public class AccPaymentListResultWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   AccPaymentListResultWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// <br>UpdateNote       :   11570208-00 軽減税率対応</br>
        /// <br>Programmer       :   3H 劉星光</br>
        /// <br>Date	         :   2020/03/02</br>
        /// <br>UpdateNote       :   11870141-00 インボイス対応（税率別合計金額不具合修正）</br>
        /// <br>Programmer       :   3H 仰亮亮</br>
        /// <br>Date             :   2022/10/09</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  AccPaymentListResultWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is AccPaymentListResultWork || graph is ArrayList || graph is AccPaymentListResultWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(AccPaymentListResultWork).FullName));

            if (graph != null && graph is AccPaymentListResultWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.AccPaymentListResultWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is AccPaymentListResultWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((AccPaymentListResultWork[])graph).Length;
            }
            else if (graph is AccPaymentListResultWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //繰り返し数	

            //拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //AddUpSecCode
            //拠点名称
            serInfo.MemberInfo.Add(typeof(string)); //SectionGuideSnm
            //支払先コード
            serInfo.MemberInfo.Add(typeof(Int32)); //PayeeCode
            //支払先略称
            serInfo.MemberInfo.Add(typeof(string)); //PayeeSnm
            //前月買掛残
            serInfo.MemberInfo.Add(typeof(Int64)); //LastTimeAccPay
            //当月支払
            serInfo.MemberInfo.Add(typeof(Int64)); //ThisTimePayNrml
            //繰越額
            serInfo.MemberInfo.Add(typeof(Int64)); //ThisTimeTtlBlcAcPay
            //仕入額
            serInfo.MemberInfo.Add(typeof(Int64)); //OfsThisTimeStock
            //返品値引
            serInfo.MemberInfo.Add(typeof(Int64)); //ThisRgdsDisPric
            //消費税
            serInfo.MemberInfo.Add(typeof(Int64)); //OfsThisStockTax
            //当月末残高
            serInfo.MemberInfo.Add(typeof(Int64)); //StckTtlAccPayBalance
            //枚数
            serInfo.MemberInfo.Add(typeof(Int32)); //StockSlipCount
            //手数料
            serInfo.MemberInfo.Add(typeof(Int64)); //ThisTimeFeePayNrml
            //値引
            serInfo.MemberInfo.Add(typeof(Int64)); //ThisTimeDisPayNrml
            //現金
            serInfo.MemberInfo.Add(typeof(Int64)); //CashPayment
            //振込
            serInfo.MemberInfo.Add(typeof(Int64)); //TrfrPayment
            //小切手
            serInfo.MemberInfo.Add(typeof(Int64)); //CheckPayment
            //手形
            serInfo.MemberInfo.Add(typeof(Int64)); //DraftPayment
            //相殺
            serInfo.MemberInfo.Add(typeof(Int64)); //OffsetPayment
            //口座振替
            serInfo.MemberInfo.Add(typeof(Int64)); //FundTransferPayment
            //その他
            serInfo.MemberInfo.Add(typeof(Int64)); //OthsPayment
            //今回仕入金額
            serInfo.MemberInfo.Add(typeof(Int64)); //ThisTimeStockPrice

            // --- ADD START 3H 劉星光 2020/03/02 ---------->>>>>
            // 仕入額(計税率1)
            serInfo.MemberInfo.Add(typeof(Int64)); //TotalThisTimeStockPriceTaxRate1
            // 仕入額(計税率2)
            serInfo.MemberInfo.Add(typeof(Int64)); //TotalThisTimeStockPriceTaxRate2
            // 仕入額(計その他)
            serInfo.MemberInfo.Add(typeof(Int64)); //TotalThisTimeStockPriceOther
            // 返品値引(計税率1)
            serInfo.MemberInfo.Add(typeof(Int64)); //TotalThisRgdsDisPricTaxRate1
            // 返品値引(計税率2)
            serInfo.MemberInfo.Add(typeof(Int64)); //TotalThisRgdsDisPricTaxRate2
            // 返品値引(計その他)
            serInfo.MemberInfo.Add(typeof(Int64)); //TotalThisRgdsDisPricOther
            // 純仕入額(計税率1)
            serInfo.MemberInfo.Add(typeof(Int64)); //TotalPureStockTaxRate1
            // 純仕入額(計税率2)
            serInfo.MemberInfo.Add(typeof(Int64)); //TotalPureStockTaxRate2
            // 純仕入額(計その他)
            serInfo.MemberInfo.Add(typeof(Int64)); //TotalPureStockOther
            // 消費税(計税率1)
            serInfo.MemberInfo.Add(typeof(Int64)); //TotalStockPricTaxTaxRate1
            // 消費税(計税率2)
            serInfo.MemberInfo.Add(typeof(Int64)); //TotalStockPricTaxTaxRate2
            // 消費税(計その他)
            serInfo.MemberInfo.Add(typeof(Int64)); //TotalStockPricTaxOther
            // 当月合計(計税率1)
            serInfo.MemberInfo.Add(typeof(Int64)); //TotalStckTtlAccPayBalanceTaxRate1
            // 当月合計(計税率2)
            serInfo.MemberInfo.Add(typeof(Int64)); //TotalStckTtlAccPayBalanceTaxRate2
            // 当月合計(計その他)
            serInfo.MemberInfo.Add(typeof(Int64)); //TotalStckTtlAccPayBalanceOther
            // 枚数(計税率1)
            serInfo.MemberInfo.Add(typeof(Int32)); //TotalStockSlipCountTaxRate1
            // 枚数(計税率2)
            serInfo.MemberInfo.Add(typeof(Int32)); //TotalStockSlipCountTaxRate2
            // 枚数(計その他)
            serInfo.MemberInfo.Add(typeof(Int32)); //TotalStockSlipCountOther
            // 税率1タイトル
            serInfo.MemberInfo.Add(typeof(string)); //TtitleTaxRate1
            // 税率2タイトル
            serInfo.MemberInfo.Add(typeof(string)); //TtitleTaxRate2
            // --- ADD END 3H 劉星光 2020/03/02 ----------<<<<<

            // --- ADD START 3H 仰亮亮 2022/10/09 ----->>>>>
            // 仕入額(計非課税)
            serInfo.MemberInfo.Add(typeof(Int64)); //TotalThisTimeStockPriceTaxFree
            // 返品値引(計非課税)
            serInfo.MemberInfo.Add(typeof(Int64)); //TotalThisRgdsDisPricTaxFree
            // 純仕入額(計非課税)
            serInfo.MemberInfo.Add(typeof(Int64)); //TotalPureStockTaxFree
            // 消費税(計非課税)
            serInfo.MemberInfo.Add(typeof(Int64)); //TotalStockPricTaxTaxFree
            // 当月合計(計非課税)
            serInfo.MemberInfo.Add(typeof(Int64)); //TotalStckTtlAccPayBalanceTaxFree
            // 枚数(計非課税)
            serInfo.MemberInfo.Add(typeof(Int32)); //TotalStockSlipCountTaxFree
            // --- ADD END 3H 仰亮亮 2022/10/09 -----<<<<<

            serInfo.Serialize(writer, serInfo);
            if (graph is AccPaymentListResultWork)
            {
                AccPaymentListResultWork temp = (AccPaymentListResultWork)graph;

                SetAccPaymentListResultWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is AccPaymentListResultWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((AccPaymentListResultWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (AccPaymentListResultWork temp in lst)
                {
                    SetAccPaymentListResultWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// AccPaymentListResultWorkメンバ数(publicプロパティ数)
        /// </summary>
        //private const int currentMemberCount = 22; // DEL 3H 劉星光 2020/03/02
        //private const int currentMemberCount = 42; // ADD 3H 劉星光 2020/03/02 // DEL 3H 仰亮亮 2022/10/09
        private const int currentMemberCount = 48;   // ADD 3H 仰亮亮 2022/10/09

        /// <summary>
        ///  AccPaymentListResultWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   AccPaymentListResultWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// <br>UpdateNote       :   11570208-00 軽減税率対応</br>
        /// <br>Programmer       :   3H 劉星光</br>
        /// <br>Date	         :   2020/03/02</br>
        /// <br>UpdateNote       :   11870141-00 インボイス対応（税率別合計金額不具合修正）</br>
        /// <br>Programmer       :   3H 仰亮亮</br>
        /// <br>Date             :   2022/10/09</br>
        /// </remarks>
        private void SetAccPaymentListResultWork(System.IO.BinaryWriter writer, AccPaymentListResultWork temp)
        {
            //拠点コード
            writer.Write(temp.AddUpSecCode);
            //拠点名称
            writer.Write(temp.SectionGuideSnm);
            //支払先コード
            writer.Write(temp.PayeeCode);
            //支払先略称
            writer.Write(temp.PayeeSnm);
            //前月買掛残
            writer.Write(temp.LastTimeAccPay);
            //当月支払
            writer.Write(temp.ThisTimePayNrml);
            //繰越額
            writer.Write(temp.ThisTimeTtlBlcAcPay);
            //仕入額
            writer.Write(temp.OfsThisTimeStock);
            //返品値引
            writer.Write(temp.ThisRgdsDisPric);
            //消費税
            writer.Write(temp.OfsThisStockTax);
            //当月末残高
            writer.Write(temp.StckTtlAccPayBalance);
            //枚数
            writer.Write(temp.StockSlipCount);
            //手数料
            writer.Write(temp.ThisTimeFeePayNrml);
            //値引
            writer.Write(temp.ThisTimeDisPayNrml);
            //現金
            writer.Write(temp.CashPayment);
            //振込
            writer.Write(temp.TrfrPayment);
            //小切手
            writer.Write(temp.CheckPayment);
            //手形
            writer.Write(temp.DraftPayment);
            //相殺
            writer.Write(temp.OffsetPayment);
            //口座振替
            writer.Write(temp.FundTransferPayment);
            //その他
            writer.Write(temp.OthsPayment);
            //今回仕入金額
            writer.Write(temp.ThisTimeStockPrice);
            // --- ADD START 3H 劉星光 2020/03/02 ---------->>>>>
            //仕入額(計税率1)
            writer.Write(temp.TotalThisTimeStockPriceTaxRate1);
            //仕入額(計税率2)
            writer.Write(temp.TotalThisTimeStockPriceTaxRate2);
            //仕入額(計その他)
            writer.Write(temp.TotalThisTimeStockPriceOther);
            //返品値引(計税率1)
            writer.Write(temp.TotalThisRgdsDisPricTaxRate1);
            //返品値引(計税率2)
            writer.Write(temp.TotalThisRgdsDisPricTaxRate2);
            //返品値引(計その他)
            writer.Write(temp.TotalThisRgdsDisPricOther);
            //純仕入額(計税率1)
            writer.Write(temp.TotalPureStockTaxRate1);
            //純仕入額(計税率2)
            writer.Write(temp.TotalPureStockTaxRate2);
            //純仕入額(計その他)
            writer.Write(temp.TotalPureStockOther);
            //消費税(計税率1)
            writer.Write(temp.TotalStockPricTaxTaxRate1);
            //消費税(計税率2)
            writer.Write(temp.TotalStockPricTaxTaxRate2);
            //消費税(計その他)
            writer.Write(temp.TotalStockPricTaxOther);
            //当月合計(計税率1)
            writer.Write(temp.TotalStckTtlAccPayBalanceTaxRate1);
            //当月合計(計税率2)
            writer.Write(temp.TotalStckTtlAccPayBalanceTaxRate2);
            //当月合計(計その他)
            writer.Write(temp.TotalStckTtlAccPayBalanceOther);
            //枚数(計税率1)
            writer.Write(temp.TotalStockSlipCountTaxRate1);
            //枚数(計税率2)
            writer.Write(temp.TotalStockSlipCountTaxRate2);
            //枚数(計その他)
            writer.Write(temp.TotalStockSlipCountOther);
            //税率1タイトル
            writer.Write(temp.TitleTaxRate1);
            //税率2タイトル
            writer.Write(temp.TitleTaxRate2);
            // --- ADD END 3H 劉星光 2020/03/02 ----------<<<<<
            // --- ADD START 3H 仰亮亮 2022/10/09 ----->>>>>
            // 仕入額(計非課税)
            writer.Write(temp.TotalThisTimeStockPriceTaxFree);
            // 返品値引(計非課税)
            writer.Write(temp.TotalThisRgdsDisPricTaxFree);
            // 純仕入額(計非課税)
            writer.Write(temp.TotalPureStockTaxFree);
            // 消費税(計非課税)
            writer.Write(temp.TotalStockPricTaxTaxFree);
            // 当月合計(計非課税)
            writer.Write(temp.TotalStckTtlAccPayBalanceTaxFree);
            // 枚数(計非課税)
            writer.Write(temp.TotalStockSlipCountTaxFree);
            // --- ADD END 3H 仰亮亮 2022/10/09 -----<<<<<

        }

        /// <summary>
        ///  AccPaymentListResultWorkインスタンス取得
        /// </summary>
        /// <returns>AccPaymentListResultWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   AccPaymentListResultWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// <br>UpdateNote       :   11870141-00 インボイス対応（税率別合計金額不具合修正）</br>
        /// <br>Programmer       :   3H 仰亮亮</br>
        /// <br>Date             :   2022/10/09</br>
        /// </remarks>
        private AccPaymentListResultWork GetAccPaymentListResultWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            AccPaymentListResultWork temp = new AccPaymentListResultWork();

            //拠点コード
            temp.AddUpSecCode = reader.ReadString();
            //拠点名称
            temp.SectionGuideSnm = reader.ReadString();
            //支払先コード
            temp.PayeeCode = reader.ReadInt32();
            //支払先略称
            temp.PayeeSnm = reader.ReadString();
            //前月買掛残
            temp.LastTimeAccPay = reader.ReadInt64();
            //当月支払
            temp.ThisTimePayNrml = reader.ReadInt64();
            //繰越額
            temp.ThisTimeTtlBlcAcPay = reader.ReadInt64();
            //仕入額
            temp.OfsThisTimeStock = reader.ReadInt64();
            //返品値引
            temp.ThisRgdsDisPric = reader.ReadInt64();
            //消費税
            temp.OfsThisStockTax = reader.ReadInt64();
            //当月末残高
            temp.StckTtlAccPayBalance = reader.ReadInt64();
            //枚数
            temp.StockSlipCount = reader.ReadInt32();
            //手数料
            temp.ThisTimeFeePayNrml = reader.ReadInt64();
            //値引
            temp.ThisTimeDisPayNrml = reader.ReadInt64();
            //現金
            temp.CashPayment = reader.ReadInt64();
            //振込
            temp.TrfrPayment = reader.ReadInt64();
            //小切手
            temp.CheckPayment = reader.ReadInt64();
            //手形
            temp.DraftPayment = reader.ReadInt64();
            //相殺
            temp.OffsetPayment = reader.ReadInt64();
            //口座振替
            temp.FundTransferPayment = reader.ReadInt64();
            //その他
            temp.OthsPayment = reader.ReadInt64();
            //今回仕入金額
            temp.ThisTimeStockPrice = reader.ReadInt64();
            // --- ADD START 3H 劉星光 2020/03/02 ---------->>>>>
            //仕入額(計税率1)
            temp.TotalThisTimeStockPriceTaxRate1 = reader.ReadInt64();
            //仕入額(計税率2)
            temp.TotalThisTimeStockPriceTaxRate2 = reader.ReadInt64();
            //仕入額(計その他)
            temp.TotalThisTimeStockPriceOther = reader.ReadInt64();
            //返品値引(計税率1)
            temp.TotalThisRgdsDisPricTaxRate1 = reader.ReadInt64();
            //返品値引(計税率2)
            temp.TotalThisRgdsDisPricTaxRate2 = reader.ReadInt64();
            //返品値引(計その他)
            temp.TotalThisRgdsDisPricOther = reader.ReadInt64();
            //純仕入額(計税率1)
            temp.TotalPureStockTaxRate1 = reader.ReadInt64();
            //純仕入額(計税率2)
            temp.TotalPureStockTaxRate2 = reader.ReadInt64();
            //純仕入額(計その他)
            temp.TotalPureStockOther = reader.ReadInt64();
            //消費税(計税率1)
            temp.TotalStockPricTaxTaxRate1 = reader.ReadInt64();
            //消費税(計税率2)
            temp.TotalStockPricTaxTaxRate2 = reader.ReadInt64();
            //消費税(計その他)
            temp.TotalStockPricTaxOther = reader.ReadInt64();
            //当月合計(計税率1)
            temp.TotalStckTtlAccPayBalanceTaxRate1 = reader.ReadInt64();
            //当月合計(計税率2)
            temp.TotalStckTtlAccPayBalanceTaxRate2 = reader.ReadInt64();
            //当月合計(計その他)
            temp.TotalStckTtlAccPayBalanceOther = reader.ReadInt64();
            //枚数(計税率1)
            temp.TotalStockSlipCountTaxRate1 = reader.ReadInt32();
            //枚数(計税率2)
            temp.TotalStockSlipCountTaxRate2 = reader.ReadInt32();
            //枚数(計その他)
            temp.TotalStockSlipCountOther = reader.ReadInt32();
            //税率1タイトル
            temp.TitleTaxRate1 = reader.ReadString();
            //税率2タイトル
            temp.TitleTaxRate2 = reader.ReadString();
            // --- ADD END 3H 劉星光 2020/03/02 ----------<<<<<
            // --- ADD START 3H 仰亮亮 2022/10/09 ----->>>>>
            // 仕入額(計非課税)
            temp.TotalThisTimeStockPriceTaxFree = reader.ReadInt64();
            // 返品値引(計非課税)
            temp.TotalThisRgdsDisPricTaxFree = reader.ReadInt64();
            // 純仕入額(計非課税)
            temp.TotalPureStockTaxFree = reader.ReadInt64();
            // 消費税(計非課税)
            temp.TotalStockPricTaxTaxFree = reader.ReadInt64();
            // 当月合計(計非課税)
            temp.TotalStckTtlAccPayBalanceTaxFree = reader.ReadInt64();
            // 枚数(計非課税)
            temp.TotalStockSlipCountTaxFree = reader.ReadInt32();
            // --- ADD END 3H 仰亮亮 2022/10/09 -----<<<<<

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
        /// <returns>AccPaymentListResultWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   AccPaymentListResultWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                AccPaymentListResultWork temp = GetAccPaymentListResultWork(reader, serInfo);
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
                    retValue = (AccPaymentListResultWork[])lst.ToArray(typeof(AccPaymentListResultWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}

using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   FrePEstFmDetail
    /// <summary>
    ///                      自由帳票見積書明細データ
    /// </summary>
    /// <remarks>
    /// <br>note             :   自由帳票見積書明細データヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2008/3/25</br>
    /// <br>Genarated Date   :   2008/10/02  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class FrePEstFmDetail
    {
        /// <summary>売上伝票番号</summary>
        /// <remarks>見積伝票番号,受注伝票番号,出荷伝票番号,売上伝票番号を兼ねる。</remarks>
        private string _sALESDETAILRF_SALESSLIPNUMRF = "";

        /// <summary>売上行番号</summary>
        private Int32 _sALESDETAILRF_SALESROWNORF;

        /// <summary>純正商品メーカーコード</summary>
        private Int32 _dPURE_GOODSMAKERCDRF;

        /// <summary>純正メーカー名称</summary>
        private string _dPURE_MAKERNAMERF = "";

        /// <summary>純正メーカーカナ名称</summary>
        private string _dPURE_MAKERKANANAMERF = "";

        /// <summary>純正商品番号</summary>
        private string _dPURE_GOODSNORF = "";

        /// <summary>純正商品名称</summary>
        private string _dPURE_GOODSNAMERF = "";

        /// <summary>純正商品名称カナ</summary>
        private string _dPURE_GOODSNAMEKANARF = "";

        /// <summary>純正BL商品コード</summary>
        private Int32 _dPURE_BLGOODSCODERF;

        /// <summary>純正売上単価（税込，浮動）</summary>
        private Double _dPURE_SALESUNPRCTAXINCFLRF;

        /// <summary>純正売上単価（税抜，浮動）</summary>
        private Double _dPURE_SALESUNPRCTAXEXCFLRF;

        /// <summary>純正定価（税込，浮動）</summary>
        /// <remarks>税抜き</remarks>
        private Double _dPURE_LISTPRICETAXINCFLRF;

        /// <summary>純正定価（税抜，浮動）</summary>
        /// <remarks>税込み</remarks>
        private Double _dPURE_LISTPRICETAXEXCFLRF;

        /// <summary>純正売上金額（税込み）</summary>
        private Int64 _dPURE_SALESMONEYTAXINCRF;

        /// <summary>純正売上金額（税抜き）</summary>
        private Int64 _dPURE_SALESMONEYTAXEXCRF;

        /// <summary>純正課税区分</summary>
        /// <remarks>0:課税,1:非課税,2:課税（内税）</remarks>
        private Int32 _dPURE_TAXATIONDIVCDRF;

        /// <summary>純正売上単価</summary>
        /// <remarks>印刷制御用</remarks>
        private Double _dPURE_SALESUNPRCFLRF;

        /// <summary>純正定価</summary>
        /// <remarks>印刷制御用</remarks>
        private Double _dPURE_LISTPRICERF;

        /// <summary>純正出荷数</summary>
        /// <remarks>印刷制御用</remarks>
        private Double _dPURE_SHIPMENTCNTRF;

        /// <summary>純正売上金額</summary>
        /// <remarks>印刷制御用</remarks>
        private Int64 _dPURE_SALESMONEYRF;

        /// <summary>優良商品メーカーコード</summary>
        private Int32 _dPRIM_GOODSMAKERCDRF;

        /// <summary>優良メーカー名称</summary>
        private string _dPRIM_MAKERNAMERF = "";

        /// <summary>優良メーカーカナ名称</summary>
        private string _dPRIM_MAKERKANANAMERF = "";

        /// <summary>優良商品番号</summary>
        private string _dPRIM_GOODSNORF = "";

        /// <summary>優良商品名称</summary>
        private string _dPRIM_GOODSNAMERF = "";

        /// <summary>優良商品名称カナ</summary>
        private string _dPRIM_GOODSNAMEKANARF = "";

        /// <summary>優良BL商品コード</summary>
        private Int32 _dPRIM_BLGOODSCODERF;

        /// <summary>優良売上単価（税込，浮動）</summary>
        private Double _dPRIM_SALESUNPRCTAXINCFLRF;

        /// <summary>優良売上単価（税抜，浮動）</summary>
        private Double _dPRIM_SALESUNPRCTAXEXCFLRF;

        /// <summary>優良定価（税込，浮動）</summary>
        /// <remarks>税抜き</remarks>
        private Double _dPRIM_LISTPRICETAXINCFLRF;

        /// <summary>優良定価（税抜，浮動）</summary>
        /// <remarks>税込み</remarks>
        private Double _dPRIM_LISTPRICETAXEXCFLRF;

        /// <summary>優良売上金額（税込み）</summary>
        private Int64 _dPRIM_SALESMONEYTAXINCRF;

        /// <summary>優良売上金額（税抜き）</summary>
        private Int64 _dPRIM_SALESMONEYTAXEXCRF;

        /// <summary>優良課税区分</summary>
        /// <remarks>0:課税,1:非課税,2:課税（内税）</remarks>
        private Int32 _dPRIM_TAXATIONDIVCDRF;

        /// <summary>優良売上単価</summary>
        /// <remarks>印刷制御用</remarks>
        private Double _dPRIM_SALESUNPRCFLRF;

        /// <summary>優良定価</summary>
        /// <remarks>印刷制御用</remarks>
        private Double _dPRIM_LISTPRICERF;

        /// <summary>優良出荷数</summary>
        /// <remarks>印刷制御用</remarks>
        private Double _dPRIM_SHIPMENTCNTRF;

        /// <summary>優良売上金額</summary>
        /// <remarks>印刷制御用</remarks>
        private Int64 _dPRIM_SALESMONEYRF;

        /// <summary>オプション・規格情報</summary>
        private string _dADD_SPECIALNOTE = "";


        /// public propaty name  :  SALESDETAILRF_SALESSLIPNUMRF
        /// <summary>売上伝票番号プロパティ</summary>
        /// <value>見積伝票番号,受注伝票番号,出荷伝票番号,売上伝票番号を兼ねる。</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上伝票番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SALESDETAILRF_SALESSLIPNUMRF
        {
            get { return _sALESDETAILRF_SALESSLIPNUMRF; }
            set { _sALESDETAILRF_SALESSLIPNUMRF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_SALESROWNORF
        /// <summary>売上行番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上行番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SALESDETAILRF_SALESROWNORF
        {
            get { return _sALESDETAILRF_SALESROWNORF; }
            set { _sALESDETAILRF_SALESROWNORF = value; }
        }

        /// public propaty name  :  DPURE_GOODSMAKERCDRF
        /// <summary>純正商品メーカーコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   純正商品メーカーコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DPURE_GOODSMAKERCDRF
        {
            get { return _dPURE_GOODSMAKERCDRF; }
            set { _dPURE_GOODSMAKERCDRF = value; }
        }

        /// public propaty name  :  DPURE_MAKERNAMERF
        /// <summary>純正メーカー名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   純正メーカー名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DPURE_MAKERNAMERF
        {
            get { return _dPURE_MAKERNAMERF; }
            set { _dPURE_MAKERNAMERF = value; }
        }

        /// public propaty name  :  DPURE_MAKERKANANAMERF
        /// <summary>純正メーカーカナ名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   純正メーカーカナ名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DPURE_MAKERKANANAMERF
        {
            get { return _dPURE_MAKERKANANAMERF; }
            set { _dPURE_MAKERKANANAMERF = value; }
        }

        /// public propaty name  :  DPURE_GOODSNORF
        /// <summary>純正商品番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   純正商品番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DPURE_GOODSNORF
        {
            get { return _dPURE_GOODSNORF; }
            set { _dPURE_GOODSNORF = value; }
        }

        /// public propaty name  :  DPURE_GOODSNAMERF
        /// <summary>純正商品名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   純正商品名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DPURE_GOODSNAMERF
        {
            get { return _dPURE_GOODSNAMERF; }
            set { _dPURE_GOODSNAMERF = value; }
        }

        /// public propaty name  :  DPURE_GOODSNAMEKANARF
        /// <summary>純正商品名称カナプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   純正商品名称カナプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DPURE_GOODSNAMEKANARF
        {
            get { return _dPURE_GOODSNAMEKANARF; }
            set { _dPURE_GOODSNAMEKANARF = value; }
        }

        /// public propaty name  :  DPURE_BLGOODSCODERF
        /// <summary>純正BL商品コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   純正BL商品コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DPURE_BLGOODSCODERF
        {
            get { return _dPURE_BLGOODSCODERF; }
            set { _dPURE_BLGOODSCODERF = value; }
        }

        /// public propaty name  :  DPURE_SALESUNPRCTAXINCFLRF
        /// <summary>純正売上単価（税込，浮動）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   純正売上単価（税込，浮動）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double DPURE_SALESUNPRCTAXINCFLRF
        {
            get { return _dPURE_SALESUNPRCTAXINCFLRF; }
            set { _dPURE_SALESUNPRCTAXINCFLRF = value; }
        }

        /// public propaty name  :  DPURE_SALESUNPRCTAXEXCFLRF
        /// <summary>純正売上単価（税抜，浮動）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   純正売上単価（税抜，浮動）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double DPURE_SALESUNPRCTAXEXCFLRF
        {
            get { return _dPURE_SALESUNPRCTAXEXCFLRF; }
            set { _dPURE_SALESUNPRCTAXEXCFLRF = value; }
        }

        /// public propaty name  :  DPURE_LISTPRICETAXINCFLRF
        /// <summary>純正定価（税込，浮動）プロパティ</summary>
        /// <value>税抜き</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   純正定価（税込，浮動）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double DPURE_LISTPRICETAXINCFLRF
        {
            get { return _dPURE_LISTPRICETAXINCFLRF; }
            set { _dPURE_LISTPRICETAXINCFLRF = value; }
        }

        /// public propaty name  :  DPURE_LISTPRICETAXEXCFLRF
        /// <summary>純正定価（税抜，浮動）プロパティ</summary>
        /// <value>税込み</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   純正定価（税抜，浮動）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double DPURE_LISTPRICETAXEXCFLRF
        {
            get { return _dPURE_LISTPRICETAXEXCFLRF; }
            set { _dPURE_LISTPRICETAXEXCFLRF = value; }
        }

        /// public propaty name  :  DPURE_SALESMONEYTAXINCRF
        /// <summary>純正売上金額（税込み）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   純正売上金額（税込み）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 DPURE_SALESMONEYTAXINCRF
        {
            get { return _dPURE_SALESMONEYTAXINCRF; }
            set { _dPURE_SALESMONEYTAXINCRF = value; }
        }

        /// public propaty name  :  DPURE_SALESMONEYTAXEXCRF
        /// <summary>純正売上金額（税抜き）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   純正売上金額（税抜き）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 DPURE_SALESMONEYTAXEXCRF
        {
            get { return _dPURE_SALESMONEYTAXEXCRF; }
            set { _dPURE_SALESMONEYTAXEXCRF = value; }
        }

        /// public propaty name  :  DPURE_TAXATIONDIVCDRF
        /// <summary>純正課税区分プロパティ</summary>
        /// <value>0:課税,1:非課税,2:課税（内税）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   純正課税区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DPURE_TAXATIONDIVCDRF
        {
            get { return _dPURE_TAXATIONDIVCDRF; }
            set { _dPURE_TAXATIONDIVCDRF = value; }
        }

        /// public propaty name  :  DPURE_SALESUNPRCFLRF
        /// <summary>純正売上単価プロパティ</summary>
        /// <value>印刷制御用</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   純正売上単価プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double DPURE_SALESUNPRCFLRF
        {
            get { return _dPURE_SALESUNPRCFLRF; }
            set { _dPURE_SALESUNPRCFLRF = value; }
        }

        /// public propaty name  :  DPURE_LISTPRICERF
        /// <summary>純正定価プロパティ</summary>
        /// <value>印刷制御用</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   純正定価プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double DPURE_LISTPRICERF
        {
            get { return _dPURE_LISTPRICERF; }
            set { _dPURE_LISTPRICERF = value; }
        }

        /// public propaty name  :  DPURE_SHIPMENTCNTRF
        /// <summary>純正出荷数プロパティ</summary>
        /// <value>印刷制御用</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   純正出荷数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double DPURE_SHIPMENTCNTRF
        {
            get { return _dPURE_SHIPMENTCNTRF; }
            set { _dPURE_SHIPMENTCNTRF = value; }
        }

        /// public propaty name  :  DPURE_SALESMONEYRF
        /// <summary>純正売上金額プロパティ</summary>
        /// <value>印刷制御用</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   純正売上金額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 DPURE_SALESMONEYRF
        {
            get { return _dPURE_SALESMONEYRF; }
            set { _dPURE_SALESMONEYRF = value; }
        }

        /// public propaty name  :  DPRIM_GOODSMAKERCDRF
        /// <summary>優良商品メーカーコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   優良商品メーカーコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DPRIM_GOODSMAKERCDRF
        {
            get { return _dPRIM_GOODSMAKERCDRF; }
            set { _dPRIM_GOODSMAKERCDRF = value; }
        }

        /// public propaty name  :  DPRIM_MAKERNAMERF
        /// <summary>優良メーカー名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   優良メーカー名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DPRIM_MAKERNAMERF
        {
            get { return _dPRIM_MAKERNAMERF; }
            set { _dPRIM_MAKERNAMERF = value; }
        }

        /// public propaty name  :  DPRIM_MAKERKANANAMERF
        /// <summary>優良メーカーカナ名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   優良メーカーカナ名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DPRIM_MAKERKANANAMERF
        {
            get { return _dPRIM_MAKERKANANAMERF; }
            set { _dPRIM_MAKERKANANAMERF = value; }
        }

        /// public propaty name  :  DPRIM_GOODSNORF
        /// <summary>優良商品番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   優良商品番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DPRIM_GOODSNORF
        {
            get { return _dPRIM_GOODSNORF; }
            set { _dPRIM_GOODSNORF = value; }
        }

        /// public propaty name  :  DPRIM_GOODSNAMERF
        /// <summary>優良商品名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   優良商品名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DPRIM_GOODSNAMERF
        {
            get { return _dPRIM_GOODSNAMERF; }
            set { _dPRIM_GOODSNAMERF = value; }
        }

        /// public propaty name  :  DPRIM_GOODSNAMEKANARF
        /// <summary>優良商品名称カナプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   優良商品名称カナプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DPRIM_GOODSNAMEKANARF
        {
            get { return _dPRIM_GOODSNAMEKANARF; }
            set { _dPRIM_GOODSNAMEKANARF = value; }
        }

        /// public propaty name  :  DPRIM_BLGOODSCODERF
        /// <summary>優良BL商品コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   優良BL商品コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DPRIM_BLGOODSCODERF
        {
            get { return _dPRIM_BLGOODSCODERF; }
            set { _dPRIM_BLGOODSCODERF = value; }
        }

        /// public propaty name  :  DPRIM_SALESUNPRCTAXINCFLRF
        /// <summary>優良売上単価（税込，浮動）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   優良売上単価（税込，浮動）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double DPRIM_SALESUNPRCTAXINCFLRF
        {
            get { return _dPRIM_SALESUNPRCTAXINCFLRF; }
            set { _dPRIM_SALESUNPRCTAXINCFLRF = value; }
        }

        /// public propaty name  :  DPRIM_SALESUNPRCTAXEXCFLRF
        /// <summary>優良売上単価（税抜，浮動）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   優良売上単価（税抜，浮動）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double DPRIM_SALESUNPRCTAXEXCFLRF
        {
            get { return _dPRIM_SALESUNPRCTAXEXCFLRF; }
            set { _dPRIM_SALESUNPRCTAXEXCFLRF = value; }
        }

        /// public propaty name  :  DPRIM_LISTPRICETAXINCFLRF
        /// <summary>優良定価（税込，浮動）プロパティ</summary>
        /// <value>税抜き</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   優良定価（税込，浮動）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double DPRIM_LISTPRICETAXINCFLRF
        {
            get { return _dPRIM_LISTPRICETAXINCFLRF; }
            set { _dPRIM_LISTPRICETAXINCFLRF = value; }
        }

        /// public propaty name  :  DPRIM_LISTPRICETAXEXCFLRF
        /// <summary>優良定価（税抜，浮動）プロパティ</summary>
        /// <value>税込み</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   優良定価（税抜，浮動）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double DPRIM_LISTPRICETAXEXCFLRF
        {
            get { return _dPRIM_LISTPRICETAXEXCFLRF; }
            set { _dPRIM_LISTPRICETAXEXCFLRF = value; }
        }

        /// public propaty name  :  DPRIM_SALESMONEYTAXINCRF
        /// <summary>優良売上金額（税込み）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   優良売上金額（税込み）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 DPRIM_SALESMONEYTAXINCRF
        {
            get { return _dPRIM_SALESMONEYTAXINCRF; }
            set { _dPRIM_SALESMONEYTAXINCRF = value; }
        }

        /// public propaty name  :  DPRIM_SALESMONEYTAXEXCRF
        /// <summary>優良売上金額（税抜き）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   優良売上金額（税抜き）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 DPRIM_SALESMONEYTAXEXCRF
        {
            get { return _dPRIM_SALESMONEYTAXEXCRF; }
            set { _dPRIM_SALESMONEYTAXEXCRF = value; }
        }

        /// public propaty name  :  DPRIM_TAXATIONDIVCDRF
        /// <summary>優良課税区分プロパティ</summary>
        /// <value>0:課税,1:非課税,2:課税（内税）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   優良課税区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DPRIM_TAXATIONDIVCDRF
        {
            get { return _dPRIM_TAXATIONDIVCDRF; }
            set { _dPRIM_TAXATIONDIVCDRF = value; }
        }

        /// public propaty name  :  DPRIM_SALESUNPRCFLRF
        /// <summary>優良売上単価プロパティ</summary>
        /// <value>印刷制御用</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   優良売上単価プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double DPRIM_SALESUNPRCFLRF
        {
            get { return _dPRIM_SALESUNPRCFLRF; }
            set { _dPRIM_SALESUNPRCFLRF = value; }
        }

        /// public propaty name  :  DPRIM_LISTPRICERF
        /// <summary>優良定価プロパティ</summary>
        /// <value>印刷制御用</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   優良定価プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double DPRIM_LISTPRICERF
        {
            get { return _dPRIM_LISTPRICERF; }
            set { _dPRIM_LISTPRICERF = value; }
        }

        /// public propaty name  :  DPRIM_SHIPMENTCNTRF
        /// <summary>優良出荷数プロパティ</summary>
        /// <value>印刷制御用</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   優良出荷数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double DPRIM_SHIPMENTCNTRF
        {
            get { return _dPRIM_SHIPMENTCNTRF; }
            set { _dPRIM_SHIPMENTCNTRF = value; }
        }

        /// public propaty name  :  DPRIM_SALESMONEYRF
        /// <summary>優良売上金額プロパティ</summary>
        /// <value>印刷制御用</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   優良売上金額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 DPRIM_SALESMONEYRF
        {
            get { return _dPRIM_SALESMONEYRF; }
            set { _dPRIM_SALESMONEYRF = value; }
        }

        /// public propaty name  :  DADD_SPECIALNOTE
        /// <summary>オプション・規格情報プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   オプション・規格情報プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DADD_SPECIALNOTE
        {
            get { return _dADD_SPECIALNOTE; }
            set { _dADD_SPECIALNOTE = value; }
        }


        /// <summary>
        /// 自由帳票見積書明細データコンストラクタ
        /// </summary>
        /// <returns>FrePEstFmDetailクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   FrePEstFmDetailクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public FrePEstFmDetail()
        {
        }

        /// <summary>
        /// 自由帳票見積書明細データコンストラクタ
        /// </summary>
        /// <param name="sALESDETAILRF_SALESSLIPNUMRF">売上伝票番号(見積伝票番号,受注伝票番号,出荷伝票番号,売上伝票番号を兼ねる。)</param>
        /// <param name="sALESDETAILRF_SALESROWNORF">売上行番号</param>
        /// <param name="dPURE_GOODSMAKERCDRF">純正商品メーカーコード</param>
        /// <param name="dPURE_MAKERNAMERF">純正メーカー名称</param>
        /// <param name="dPURE_MAKERKANANAMERF">純正メーカーカナ名称</param>
        /// <param name="dPURE_GOODSNORF">純正商品番号</param>
        /// <param name="dPURE_GOODSNAMERF">純正商品名称</param>
        /// <param name="dPURE_GOODSNAMEKANARF">純正商品名称カナ</param>
        /// <param name="dPURE_BLGOODSCODERF">純正BL商品コード</param>
        /// <param name="dPURE_SALESUNPRCTAXINCFLRF">純正売上単価（税込，浮動）</param>
        /// <param name="dPURE_SALESUNPRCTAXEXCFLRF">純正売上単価（税抜，浮動）</param>
        /// <param name="dPURE_LISTPRICETAXINCFLRF">純正定価（税込，浮動）(税抜き)</param>
        /// <param name="dPURE_LISTPRICETAXEXCFLRF">純正定価（税抜，浮動）(税込み)</param>
        /// <param name="dPURE_SALESMONEYTAXINCRF">純正売上金額（税込み）</param>
        /// <param name="dPURE_SALESMONEYTAXEXCRF">純正売上金額（税抜き）</param>
        /// <param name="dPURE_TAXATIONDIVCDRF">純正課税区分(0:課税,1:非課税,2:課税（内税）)</param>
        /// <param name="dPURE_SALESUNPRCFLRF">純正売上単価(印刷制御用)</param>
        /// <param name="dPURE_LISTPRICERF">純正定価(印刷制御用)</param>
        /// <param name="dPURE_SHIPMENTCNTRF">純正出荷数(印刷制御用)</param>
        /// <param name="dPURE_SALESMONEYRF">純正売上金額(印刷制御用)</param>
        /// <param name="dPRIM_GOODSMAKERCDRF">優良商品メーカーコード</param>
        /// <param name="dPRIM_MAKERNAMERF">優良メーカー名称</param>
        /// <param name="dPRIM_MAKERKANANAMERF">優良メーカーカナ名称</param>
        /// <param name="dPRIM_GOODSNORF">優良商品番号</param>
        /// <param name="dPRIM_GOODSNAMERF">優良商品名称</param>
        /// <param name="dPRIM_GOODSNAMEKANARF">優良商品名称カナ</param>
        /// <param name="dPRIM_BLGOODSCODERF">優良BL商品コード</param>
        /// <param name="dPRIM_SALESUNPRCTAXINCFLRF">優良売上単価（税込，浮動）</param>
        /// <param name="dPRIM_SALESUNPRCTAXEXCFLRF">優良売上単価（税抜，浮動）</param>
        /// <param name="dPRIM_LISTPRICETAXINCFLRF">優良定価（税込，浮動）(税抜き)</param>
        /// <param name="dPRIM_LISTPRICETAXEXCFLRF">優良定価（税抜，浮動）(税込み)</param>
        /// <param name="dPRIM_SALESMONEYTAXINCRF">優良売上金額（税込み）</param>
        /// <param name="dPRIM_SALESMONEYTAXEXCRF">優良売上金額（税抜き）</param>
        /// <param name="dPRIM_TAXATIONDIVCDRF">優良課税区分(0:課税,1:非課税,2:課税（内税）)</param>
        /// <param name="dPRIM_SALESUNPRCFLRF">優良売上単価(印刷制御用)</param>
        /// <param name="dPRIM_LISTPRICERF">優良定価(印刷制御用)</param>
        /// <param name="dPRIM_SHIPMENTCNTRF">優良出荷数(印刷制御用)</param>
        /// <param name="dPRIM_SALESMONEYRF">優良売上金額(印刷制御用)</param>
        /// <param name="dADD_SPECIALNOTE">オプション・規格情報</param>
        /// <returns>FrePEstFmDetailクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   FrePEstFmDetailクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public FrePEstFmDetail( string sALESDETAILRF_SALESSLIPNUMRF, Int32 sALESDETAILRF_SALESROWNORF, Int32 dPURE_GOODSMAKERCDRF, string dPURE_MAKERNAMERF, string dPURE_MAKERKANANAMERF, string dPURE_GOODSNORF, string dPURE_GOODSNAMERF, string dPURE_GOODSNAMEKANARF, Int32 dPURE_BLGOODSCODERF, Double dPURE_SALESUNPRCTAXINCFLRF, Double dPURE_SALESUNPRCTAXEXCFLRF, Double dPURE_LISTPRICETAXINCFLRF, Double dPURE_LISTPRICETAXEXCFLRF, Int64 dPURE_SALESMONEYTAXINCRF, Int64 dPURE_SALESMONEYTAXEXCRF, Int32 dPURE_TAXATIONDIVCDRF, Double dPURE_SALESUNPRCFLRF, Double dPURE_LISTPRICERF, Double dPURE_SHIPMENTCNTRF, Int64 dPURE_SALESMONEYRF, Int32 dPRIM_GOODSMAKERCDRF, string dPRIM_MAKERNAMERF, string dPRIM_MAKERKANANAMERF, string dPRIM_GOODSNORF, string dPRIM_GOODSNAMERF, string dPRIM_GOODSNAMEKANARF, Int32 dPRIM_BLGOODSCODERF, Double dPRIM_SALESUNPRCTAXINCFLRF, Double dPRIM_SALESUNPRCTAXEXCFLRF, Double dPRIM_LISTPRICETAXINCFLRF, Double dPRIM_LISTPRICETAXEXCFLRF, Int64 dPRIM_SALESMONEYTAXINCRF, Int64 dPRIM_SALESMONEYTAXEXCRF, Int32 dPRIM_TAXATIONDIVCDRF, Double dPRIM_SALESUNPRCFLRF, Double dPRIM_LISTPRICERF, Double dPRIM_SHIPMENTCNTRF, Int64 dPRIM_SALESMONEYRF, string dADD_SPECIALNOTE )
        {
            this._sALESDETAILRF_SALESSLIPNUMRF = sALESDETAILRF_SALESSLIPNUMRF;
            this._sALESDETAILRF_SALESROWNORF = sALESDETAILRF_SALESROWNORF;
            this._dPURE_GOODSMAKERCDRF = dPURE_GOODSMAKERCDRF;
            this._dPURE_MAKERNAMERF = dPURE_MAKERNAMERF;
            this._dPURE_MAKERKANANAMERF = dPURE_MAKERKANANAMERF;
            this._dPURE_GOODSNORF = dPURE_GOODSNORF;
            this._dPURE_GOODSNAMERF = dPURE_GOODSNAMERF;
            this._dPURE_GOODSNAMEKANARF = dPURE_GOODSNAMEKANARF;
            this._dPURE_BLGOODSCODERF = dPURE_BLGOODSCODERF;
            this._dPURE_SALESUNPRCTAXINCFLRF = dPURE_SALESUNPRCTAXINCFLRF;
            this._dPURE_SALESUNPRCTAXEXCFLRF = dPURE_SALESUNPRCTAXEXCFLRF;
            this._dPURE_LISTPRICETAXINCFLRF = dPURE_LISTPRICETAXINCFLRF;
            this._dPURE_LISTPRICETAXEXCFLRF = dPURE_LISTPRICETAXEXCFLRF;
            this._dPURE_SALESMONEYTAXINCRF = dPURE_SALESMONEYTAXINCRF;
            this._dPURE_SALESMONEYTAXEXCRF = dPURE_SALESMONEYTAXEXCRF;
            this._dPURE_TAXATIONDIVCDRF = dPURE_TAXATIONDIVCDRF;
            this._dPURE_SALESUNPRCFLRF = dPURE_SALESUNPRCFLRF;
            this._dPURE_LISTPRICERF = dPURE_LISTPRICERF;
            this._dPURE_SHIPMENTCNTRF = dPURE_SHIPMENTCNTRF;
            this._dPURE_SALESMONEYRF = dPURE_SALESMONEYRF;
            this._dPRIM_GOODSMAKERCDRF = dPRIM_GOODSMAKERCDRF;
            this._dPRIM_MAKERNAMERF = dPRIM_MAKERNAMERF;
            this._dPRIM_MAKERKANANAMERF = dPRIM_MAKERKANANAMERF;
            this._dPRIM_GOODSNORF = dPRIM_GOODSNORF;
            this._dPRIM_GOODSNAMERF = dPRIM_GOODSNAMERF;
            this._dPRIM_GOODSNAMEKANARF = dPRIM_GOODSNAMEKANARF;
            this._dPRIM_BLGOODSCODERF = dPRIM_BLGOODSCODERF;
            this._dPRIM_SALESUNPRCTAXINCFLRF = dPRIM_SALESUNPRCTAXINCFLRF;
            this._dPRIM_SALESUNPRCTAXEXCFLRF = dPRIM_SALESUNPRCTAXEXCFLRF;
            this._dPRIM_LISTPRICETAXINCFLRF = dPRIM_LISTPRICETAXINCFLRF;
            this._dPRIM_LISTPRICETAXEXCFLRF = dPRIM_LISTPRICETAXEXCFLRF;
            this._dPRIM_SALESMONEYTAXINCRF = dPRIM_SALESMONEYTAXINCRF;
            this._dPRIM_SALESMONEYTAXEXCRF = dPRIM_SALESMONEYTAXEXCRF;
            this._dPRIM_TAXATIONDIVCDRF = dPRIM_TAXATIONDIVCDRF;
            this._dPRIM_SALESUNPRCFLRF = dPRIM_SALESUNPRCFLRF;
            this._dPRIM_LISTPRICERF = dPRIM_LISTPRICERF;
            this._dPRIM_SHIPMENTCNTRF = dPRIM_SHIPMENTCNTRF;
            this._dPRIM_SALESMONEYRF = dPRIM_SALESMONEYRF;
            this._dADD_SPECIALNOTE = dADD_SPECIALNOTE;

        }

        /// <summary>
        /// 自由帳票見積書明細データ複製処理
        /// </summary>
        /// <returns>FrePEstFmDetailクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいFrePEstFmDetailクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public FrePEstFmDetail Clone()
        {
            return new FrePEstFmDetail( this._sALESDETAILRF_SALESSLIPNUMRF, this._sALESDETAILRF_SALESROWNORF, this._dPURE_GOODSMAKERCDRF, this._dPURE_MAKERNAMERF, this._dPURE_MAKERKANANAMERF, this._dPURE_GOODSNORF, this._dPURE_GOODSNAMERF, this._dPURE_GOODSNAMEKANARF, this._dPURE_BLGOODSCODERF, this._dPURE_SALESUNPRCTAXINCFLRF, this._dPURE_SALESUNPRCTAXEXCFLRF, this._dPURE_LISTPRICETAXINCFLRF, this._dPURE_LISTPRICETAXEXCFLRF, this._dPURE_SALESMONEYTAXINCRF, this._dPURE_SALESMONEYTAXEXCRF, this._dPURE_TAXATIONDIVCDRF, this._dPURE_SALESUNPRCFLRF, this._dPURE_LISTPRICERF, this._dPURE_SHIPMENTCNTRF, this._dPURE_SALESMONEYRF, this._dPRIM_GOODSMAKERCDRF, this._dPRIM_MAKERNAMERF, this._dPRIM_MAKERKANANAMERF, this._dPRIM_GOODSNORF, this._dPRIM_GOODSNAMERF, this._dPRIM_GOODSNAMEKANARF, this._dPRIM_BLGOODSCODERF, this._dPRIM_SALESUNPRCTAXINCFLRF, this._dPRIM_SALESUNPRCTAXEXCFLRF, this._dPRIM_LISTPRICETAXINCFLRF, this._dPRIM_LISTPRICETAXEXCFLRF, this._dPRIM_SALESMONEYTAXINCRF, this._dPRIM_SALESMONEYTAXEXCRF, this._dPRIM_TAXATIONDIVCDRF, this._dPRIM_SALESUNPRCFLRF, this._dPRIM_LISTPRICERF, this._dPRIM_SHIPMENTCNTRF, this._dPRIM_SALESMONEYRF, this._dADD_SPECIALNOTE );
        }

        /// <summary>
        /// 自由帳票見積書明細データ比較処理
        /// </summary>
        /// <param name="target">比較対象のFrePEstFmDetailクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   FrePEstFmDetailクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool Equals( FrePEstFmDetail target )
        {
            return ((this.SALESDETAILRF_SALESSLIPNUMRF == target.SALESDETAILRF_SALESSLIPNUMRF)
                 && (this.SALESDETAILRF_SALESROWNORF == target.SALESDETAILRF_SALESROWNORF)
                 && (this.DPURE_GOODSMAKERCDRF == target.DPURE_GOODSMAKERCDRF)
                 && (this.DPURE_MAKERNAMERF == target.DPURE_MAKERNAMERF)
                 && (this.DPURE_MAKERKANANAMERF == target.DPURE_MAKERKANANAMERF)
                 && (this.DPURE_GOODSNORF == target.DPURE_GOODSNORF)
                 && (this.DPURE_GOODSNAMERF == target.DPURE_GOODSNAMERF)
                 && (this.DPURE_GOODSNAMEKANARF == target.DPURE_GOODSNAMEKANARF)
                 && (this.DPURE_BLGOODSCODERF == target.DPURE_BLGOODSCODERF)
                 && (this.DPURE_SALESUNPRCTAXINCFLRF == target.DPURE_SALESUNPRCTAXINCFLRF)
                 && (this.DPURE_SALESUNPRCTAXEXCFLRF == target.DPURE_SALESUNPRCTAXEXCFLRF)
                 && (this.DPURE_LISTPRICETAXINCFLRF == target.DPURE_LISTPRICETAXINCFLRF)
                 && (this.DPURE_LISTPRICETAXEXCFLRF == target.DPURE_LISTPRICETAXEXCFLRF)
                 && (this.DPURE_SALESMONEYTAXINCRF == target.DPURE_SALESMONEYTAXINCRF)
                 && (this.DPURE_SALESMONEYTAXEXCRF == target.DPURE_SALESMONEYTAXEXCRF)
                 && (this.DPURE_TAXATIONDIVCDRF == target.DPURE_TAXATIONDIVCDRF)
                 && (this.DPURE_SALESUNPRCFLRF == target.DPURE_SALESUNPRCFLRF)
                 && (this.DPURE_LISTPRICERF == target.DPURE_LISTPRICERF)
                 && (this.DPURE_SHIPMENTCNTRF == target.DPURE_SHIPMENTCNTRF)
                 && (this.DPURE_SALESMONEYRF == target.DPURE_SALESMONEYRF)
                 && (this.DPRIM_GOODSMAKERCDRF == target.DPRIM_GOODSMAKERCDRF)
                 && (this.DPRIM_MAKERNAMERF == target.DPRIM_MAKERNAMERF)
                 && (this.DPRIM_MAKERKANANAMERF == target.DPRIM_MAKERKANANAMERF)
                 && (this.DPRIM_GOODSNORF == target.DPRIM_GOODSNORF)
                 && (this.DPRIM_GOODSNAMERF == target.DPRIM_GOODSNAMERF)
                 && (this.DPRIM_GOODSNAMEKANARF == target.DPRIM_GOODSNAMEKANARF)
                 && (this.DPRIM_BLGOODSCODERF == target.DPRIM_BLGOODSCODERF)
                 && (this.DPRIM_SALESUNPRCTAXINCFLRF == target.DPRIM_SALESUNPRCTAXINCFLRF)
                 && (this.DPRIM_SALESUNPRCTAXEXCFLRF == target.DPRIM_SALESUNPRCTAXEXCFLRF)
                 && (this.DPRIM_LISTPRICETAXINCFLRF == target.DPRIM_LISTPRICETAXINCFLRF)
                 && (this.DPRIM_LISTPRICETAXEXCFLRF == target.DPRIM_LISTPRICETAXEXCFLRF)
                 && (this.DPRIM_SALESMONEYTAXINCRF == target.DPRIM_SALESMONEYTAXINCRF)
                 && (this.DPRIM_SALESMONEYTAXEXCRF == target.DPRIM_SALESMONEYTAXEXCRF)
                 && (this.DPRIM_TAXATIONDIVCDRF == target.DPRIM_TAXATIONDIVCDRF)
                 && (this.DPRIM_SALESUNPRCFLRF == target.DPRIM_SALESUNPRCFLRF)
                 && (this.DPRIM_LISTPRICERF == target.DPRIM_LISTPRICERF)
                 && (this.DPRIM_SHIPMENTCNTRF == target.DPRIM_SHIPMENTCNTRF)
                 && (this.DPRIM_SALESMONEYRF == target.DPRIM_SALESMONEYRF)
                 && (this.DADD_SPECIALNOTE == target.DADD_SPECIALNOTE));
        }

        /// <summary>
        /// 自由帳票見積書明細データ比較処理
        /// </summary>
        /// <param name="frePEstFmDetail1">
        ///                    比較するFrePEstFmDetailクラスのインスタンス
        /// </param>
        /// <param name="frePEstFmDetail2">比較するFrePEstFmDetailクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   FrePEstFmDetailクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static bool Equals( FrePEstFmDetail frePEstFmDetail1, FrePEstFmDetail frePEstFmDetail2 )
        {
            return ((frePEstFmDetail1.SALESDETAILRF_SALESSLIPNUMRF == frePEstFmDetail2.SALESDETAILRF_SALESSLIPNUMRF)
                 && (frePEstFmDetail1.SALESDETAILRF_SALESROWNORF == frePEstFmDetail2.SALESDETAILRF_SALESROWNORF)
                 && (frePEstFmDetail1.DPURE_GOODSMAKERCDRF == frePEstFmDetail2.DPURE_GOODSMAKERCDRF)
                 && (frePEstFmDetail1.DPURE_MAKERNAMERF == frePEstFmDetail2.DPURE_MAKERNAMERF)
                 && (frePEstFmDetail1.DPURE_MAKERKANANAMERF == frePEstFmDetail2.DPURE_MAKERKANANAMERF)
                 && (frePEstFmDetail1.DPURE_GOODSNORF == frePEstFmDetail2.DPURE_GOODSNORF)
                 && (frePEstFmDetail1.DPURE_GOODSNAMERF == frePEstFmDetail2.DPURE_GOODSNAMERF)
                 && (frePEstFmDetail1.DPURE_GOODSNAMEKANARF == frePEstFmDetail2.DPURE_GOODSNAMEKANARF)
                 && (frePEstFmDetail1.DPURE_BLGOODSCODERF == frePEstFmDetail2.DPURE_BLGOODSCODERF)
                 && (frePEstFmDetail1.DPURE_SALESUNPRCTAXINCFLRF == frePEstFmDetail2.DPURE_SALESUNPRCTAXINCFLRF)
                 && (frePEstFmDetail1.DPURE_SALESUNPRCTAXEXCFLRF == frePEstFmDetail2.DPURE_SALESUNPRCTAXEXCFLRF)
                 && (frePEstFmDetail1.DPURE_LISTPRICETAXINCFLRF == frePEstFmDetail2.DPURE_LISTPRICETAXINCFLRF)
                 && (frePEstFmDetail1.DPURE_LISTPRICETAXEXCFLRF == frePEstFmDetail2.DPURE_LISTPRICETAXEXCFLRF)
                 && (frePEstFmDetail1.DPURE_SALESMONEYTAXINCRF == frePEstFmDetail2.DPURE_SALESMONEYTAXINCRF)
                 && (frePEstFmDetail1.DPURE_SALESMONEYTAXEXCRF == frePEstFmDetail2.DPURE_SALESMONEYTAXEXCRF)
                 && (frePEstFmDetail1.DPURE_TAXATIONDIVCDRF == frePEstFmDetail2.DPURE_TAXATIONDIVCDRF)
                 && (frePEstFmDetail1.DPURE_SALESUNPRCFLRF == frePEstFmDetail2.DPURE_SALESUNPRCFLRF)
                 && (frePEstFmDetail1.DPURE_LISTPRICERF == frePEstFmDetail2.DPURE_LISTPRICERF)
                 && (frePEstFmDetail1.DPURE_SHIPMENTCNTRF == frePEstFmDetail2.DPURE_SHIPMENTCNTRF)
                 && (frePEstFmDetail1.DPURE_SALESMONEYRF == frePEstFmDetail2.DPURE_SALESMONEYRF)
                 && (frePEstFmDetail1.DPRIM_GOODSMAKERCDRF == frePEstFmDetail2.DPRIM_GOODSMAKERCDRF)
                 && (frePEstFmDetail1.DPRIM_MAKERNAMERF == frePEstFmDetail2.DPRIM_MAKERNAMERF)
                 && (frePEstFmDetail1.DPRIM_MAKERKANANAMERF == frePEstFmDetail2.DPRIM_MAKERKANANAMERF)
                 && (frePEstFmDetail1.DPRIM_GOODSNORF == frePEstFmDetail2.DPRIM_GOODSNORF)
                 && (frePEstFmDetail1.DPRIM_GOODSNAMERF == frePEstFmDetail2.DPRIM_GOODSNAMERF)
                 && (frePEstFmDetail1.DPRIM_GOODSNAMEKANARF == frePEstFmDetail2.DPRIM_GOODSNAMEKANARF)
                 && (frePEstFmDetail1.DPRIM_BLGOODSCODERF == frePEstFmDetail2.DPRIM_BLGOODSCODERF)
                 && (frePEstFmDetail1.DPRIM_SALESUNPRCTAXINCFLRF == frePEstFmDetail2.DPRIM_SALESUNPRCTAXINCFLRF)
                 && (frePEstFmDetail1.DPRIM_SALESUNPRCTAXEXCFLRF == frePEstFmDetail2.DPRIM_SALESUNPRCTAXEXCFLRF)
                 && (frePEstFmDetail1.DPRIM_LISTPRICETAXINCFLRF == frePEstFmDetail2.DPRIM_LISTPRICETAXINCFLRF)
                 && (frePEstFmDetail1.DPRIM_LISTPRICETAXEXCFLRF == frePEstFmDetail2.DPRIM_LISTPRICETAXEXCFLRF)
                 && (frePEstFmDetail1.DPRIM_SALESMONEYTAXINCRF == frePEstFmDetail2.DPRIM_SALESMONEYTAXINCRF)
                 && (frePEstFmDetail1.DPRIM_SALESMONEYTAXEXCRF == frePEstFmDetail2.DPRIM_SALESMONEYTAXEXCRF)
                 && (frePEstFmDetail1.DPRIM_TAXATIONDIVCDRF == frePEstFmDetail2.DPRIM_TAXATIONDIVCDRF)
                 && (frePEstFmDetail1.DPRIM_SALESUNPRCFLRF == frePEstFmDetail2.DPRIM_SALESUNPRCFLRF)
                 && (frePEstFmDetail1.DPRIM_LISTPRICERF == frePEstFmDetail2.DPRIM_LISTPRICERF)
                 && (frePEstFmDetail1.DPRIM_SHIPMENTCNTRF == frePEstFmDetail2.DPRIM_SHIPMENTCNTRF)
                 && (frePEstFmDetail1.DPRIM_SALESMONEYRF == frePEstFmDetail2.DPRIM_SALESMONEYRF)
                 && (frePEstFmDetail1.DADD_SPECIALNOTE == frePEstFmDetail2.DADD_SPECIALNOTE));
        }
        /// <summary>
        /// 自由帳票見積書明細データ比較処理
        /// </summary>
        /// <param name="target">比較対象のFrePEstFmDetailクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   FrePEstFmDetailクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ArrayList Compare( FrePEstFmDetail target )
        {
            ArrayList resList = new ArrayList();
            if ( this.SALESDETAILRF_SALESSLIPNUMRF != target.SALESDETAILRF_SALESSLIPNUMRF ) resList.Add( "SALESDETAILRF_SALESSLIPNUMRF" );
            if ( this.SALESDETAILRF_SALESROWNORF != target.SALESDETAILRF_SALESROWNORF ) resList.Add( "SALESDETAILRF_SALESROWNORF" );
            if ( this.DPURE_GOODSMAKERCDRF != target.DPURE_GOODSMAKERCDRF ) resList.Add( "DPURE_GOODSMAKERCDRF" );
            if ( this.DPURE_MAKERNAMERF != target.DPURE_MAKERNAMERF ) resList.Add( "DPURE_MAKERNAMERF" );
            if ( this.DPURE_MAKERKANANAMERF != target.DPURE_MAKERKANANAMERF ) resList.Add( "DPURE_MAKERKANANAMERF" );
            if ( this.DPURE_GOODSNORF != target.DPURE_GOODSNORF ) resList.Add( "DPURE_GOODSNORF" );
            if ( this.DPURE_GOODSNAMERF != target.DPURE_GOODSNAMERF ) resList.Add( "DPURE_GOODSNAMERF" );
            if ( this.DPURE_GOODSNAMEKANARF != target.DPURE_GOODSNAMEKANARF ) resList.Add( "DPURE_GOODSNAMEKANARF" );
            if ( this.DPURE_BLGOODSCODERF != target.DPURE_BLGOODSCODERF ) resList.Add( "DPURE_BLGOODSCODERF" );
            if ( this.DPURE_SALESUNPRCTAXINCFLRF != target.DPURE_SALESUNPRCTAXINCFLRF ) resList.Add( "DPURE_SALESUNPRCTAXINCFLRF" );
            if ( this.DPURE_SALESUNPRCTAXEXCFLRF != target.DPURE_SALESUNPRCTAXEXCFLRF ) resList.Add( "DPURE_SALESUNPRCTAXEXCFLRF" );
            if ( this.DPURE_LISTPRICETAXINCFLRF != target.DPURE_LISTPRICETAXINCFLRF ) resList.Add( "DPURE_LISTPRICETAXINCFLRF" );
            if ( this.DPURE_LISTPRICETAXEXCFLRF != target.DPURE_LISTPRICETAXEXCFLRF ) resList.Add( "DPURE_LISTPRICETAXEXCFLRF" );
            if ( this.DPURE_SALESMONEYTAXINCRF != target.DPURE_SALESMONEYTAXINCRF ) resList.Add( "DPURE_SALESMONEYTAXINCRF" );
            if ( this.DPURE_SALESMONEYTAXEXCRF != target.DPURE_SALESMONEYTAXEXCRF ) resList.Add( "DPURE_SALESMONEYTAXEXCRF" );
            if ( this.DPURE_TAXATIONDIVCDRF != target.DPURE_TAXATIONDIVCDRF ) resList.Add( "DPURE_TAXATIONDIVCDRF" );
            if ( this.DPURE_SALESUNPRCFLRF != target.DPURE_SALESUNPRCFLRF ) resList.Add( "DPURE_SALESUNPRCFLRF" );
            if ( this.DPURE_LISTPRICERF != target.DPURE_LISTPRICERF ) resList.Add( "DPURE_LISTPRICERF" );
            if ( this.DPURE_SHIPMENTCNTRF != target.DPURE_SHIPMENTCNTRF ) resList.Add( "DPURE_SHIPMENTCNTRF" );
            if ( this.DPURE_SALESMONEYRF != target.DPURE_SALESMONEYRF ) resList.Add( "DPURE_SALESMONEYRF" );
            if ( this.DPRIM_GOODSMAKERCDRF != target.DPRIM_GOODSMAKERCDRF ) resList.Add( "DPRIM_GOODSMAKERCDRF" );
            if ( this.DPRIM_MAKERNAMERF != target.DPRIM_MAKERNAMERF ) resList.Add( "DPRIM_MAKERNAMERF" );
            if ( this.DPRIM_MAKERKANANAMERF != target.DPRIM_MAKERKANANAMERF ) resList.Add( "DPRIM_MAKERKANANAMERF" );
            if ( this.DPRIM_GOODSNORF != target.DPRIM_GOODSNORF ) resList.Add( "DPRIM_GOODSNORF" );
            if ( this.DPRIM_GOODSNAMERF != target.DPRIM_GOODSNAMERF ) resList.Add( "DPRIM_GOODSNAMERF" );
            if ( this.DPRIM_GOODSNAMEKANARF != target.DPRIM_GOODSNAMEKANARF ) resList.Add( "DPRIM_GOODSNAMEKANARF" );
            if ( this.DPRIM_BLGOODSCODERF != target.DPRIM_BLGOODSCODERF ) resList.Add( "DPRIM_BLGOODSCODERF" );
            if ( this.DPRIM_SALESUNPRCTAXINCFLRF != target.DPRIM_SALESUNPRCTAXINCFLRF ) resList.Add( "DPRIM_SALESUNPRCTAXINCFLRF" );
            if ( this.DPRIM_SALESUNPRCTAXEXCFLRF != target.DPRIM_SALESUNPRCTAXEXCFLRF ) resList.Add( "DPRIM_SALESUNPRCTAXEXCFLRF" );
            if ( this.DPRIM_LISTPRICETAXINCFLRF != target.DPRIM_LISTPRICETAXINCFLRF ) resList.Add( "DPRIM_LISTPRICETAXINCFLRF" );
            if ( this.DPRIM_LISTPRICETAXEXCFLRF != target.DPRIM_LISTPRICETAXEXCFLRF ) resList.Add( "DPRIM_LISTPRICETAXEXCFLRF" );
            if ( this.DPRIM_SALESMONEYTAXINCRF != target.DPRIM_SALESMONEYTAXINCRF ) resList.Add( "DPRIM_SALESMONEYTAXINCRF" );
            if ( this.DPRIM_SALESMONEYTAXEXCRF != target.DPRIM_SALESMONEYTAXEXCRF ) resList.Add( "DPRIM_SALESMONEYTAXEXCRF" );
            if ( this.DPRIM_TAXATIONDIVCDRF != target.DPRIM_TAXATIONDIVCDRF ) resList.Add( "DPRIM_TAXATIONDIVCDRF" );
            if ( this.DPRIM_SALESUNPRCFLRF != target.DPRIM_SALESUNPRCFLRF ) resList.Add( "DPRIM_SALESUNPRCFLRF" );
            if ( this.DPRIM_LISTPRICERF != target.DPRIM_LISTPRICERF ) resList.Add( "DPRIM_LISTPRICERF" );
            if ( this.DPRIM_SHIPMENTCNTRF != target.DPRIM_SHIPMENTCNTRF ) resList.Add( "DPRIM_SHIPMENTCNTRF" );
            if ( this.DPRIM_SALESMONEYRF != target.DPRIM_SALESMONEYRF ) resList.Add( "DPRIM_SALESMONEYRF" );
            if ( this.DADD_SPECIALNOTE != target.DADD_SPECIALNOTE ) resList.Add( "DADD_SPECIALNOTE" );

            return resList;
        }

        /// <summary>
        /// 自由帳票見積書明細データ比較処理
        /// </summary>
        /// <param name="frePEstFmDetail1">比較するFrePEstFmDetailクラスのインスタンス</param>
        /// <param name="frePEstFmDetail2">比較するFrePEstFmDetailクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   FrePEstFmDetailクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static ArrayList Compare( FrePEstFmDetail frePEstFmDetail1, FrePEstFmDetail frePEstFmDetail2 )
        {
            ArrayList resList = new ArrayList();
            if ( frePEstFmDetail1.SALESDETAILRF_SALESSLIPNUMRF != frePEstFmDetail2.SALESDETAILRF_SALESSLIPNUMRF ) resList.Add( "SALESDETAILRF_SALESSLIPNUMRF" );
            if ( frePEstFmDetail1.SALESDETAILRF_SALESROWNORF != frePEstFmDetail2.SALESDETAILRF_SALESROWNORF ) resList.Add( "SALESDETAILRF_SALESROWNORF" );
            if ( frePEstFmDetail1.DPURE_GOODSMAKERCDRF != frePEstFmDetail2.DPURE_GOODSMAKERCDRF ) resList.Add( "DPURE_GOODSMAKERCDRF" );
            if ( frePEstFmDetail1.DPURE_MAKERNAMERF != frePEstFmDetail2.DPURE_MAKERNAMERF ) resList.Add( "DPURE_MAKERNAMERF" );
            if ( frePEstFmDetail1.DPURE_MAKERKANANAMERF != frePEstFmDetail2.DPURE_MAKERKANANAMERF ) resList.Add( "DPURE_MAKERKANANAMERF" );
            if ( frePEstFmDetail1.DPURE_GOODSNORF != frePEstFmDetail2.DPURE_GOODSNORF ) resList.Add( "DPURE_GOODSNORF" );
            if ( frePEstFmDetail1.DPURE_GOODSNAMERF != frePEstFmDetail2.DPURE_GOODSNAMERF ) resList.Add( "DPURE_GOODSNAMERF" );
            if ( frePEstFmDetail1.DPURE_GOODSNAMEKANARF != frePEstFmDetail2.DPURE_GOODSNAMEKANARF ) resList.Add( "DPURE_GOODSNAMEKANARF" );
            if ( frePEstFmDetail1.DPURE_BLGOODSCODERF != frePEstFmDetail2.DPURE_BLGOODSCODERF ) resList.Add( "DPURE_BLGOODSCODERF" );
            if ( frePEstFmDetail1.DPURE_SALESUNPRCTAXINCFLRF != frePEstFmDetail2.DPURE_SALESUNPRCTAXINCFLRF ) resList.Add( "DPURE_SALESUNPRCTAXINCFLRF" );
            if ( frePEstFmDetail1.DPURE_SALESUNPRCTAXEXCFLRF != frePEstFmDetail2.DPURE_SALESUNPRCTAXEXCFLRF ) resList.Add( "DPURE_SALESUNPRCTAXEXCFLRF" );
            if ( frePEstFmDetail1.DPURE_LISTPRICETAXINCFLRF != frePEstFmDetail2.DPURE_LISTPRICETAXINCFLRF ) resList.Add( "DPURE_LISTPRICETAXINCFLRF" );
            if ( frePEstFmDetail1.DPURE_LISTPRICETAXEXCFLRF != frePEstFmDetail2.DPURE_LISTPRICETAXEXCFLRF ) resList.Add( "DPURE_LISTPRICETAXEXCFLRF" );
            if ( frePEstFmDetail1.DPURE_SALESMONEYTAXINCRF != frePEstFmDetail2.DPURE_SALESMONEYTAXINCRF ) resList.Add( "DPURE_SALESMONEYTAXINCRF" );
            if ( frePEstFmDetail1.DPURE_SALESMONEYTAXEXCRF != frePEstFmDetail2.DPURE_SALESMONEYTAXEXCRF ) resList.Add( "DPURE_SALESMONEYTAXEXCRF" );
            if ( frePEstFmDetail1.DPURE_TAXATIONDIVCDRF != frePEstFmDetail2.DPURE_TAXATIONDIVCDRF ) resList.Add( "DPURE_TAXATIONDIVCDRF" );
            if ( frePEstFmDetail1.DPURE_SALESUNPRCFLRF != frePEstFmDetail2.DPURE_SALESUNPRCFLRF ) resList.Add( "DPURE_SALESUNPRCFLRF" );
            if ( frePEstFmDetail1.DPURE_LISTPRICERF != frePEstFmDetail2.DPURE_LISTPRICERF ) resList.Add( "DPURE_LISTPRICERF" );
            if ( frePEstFmDetail1.DPURE_SHIPMENTCNTRF != frePEstFmDetail2.DPURE_SHIPMENTCNTRF ) resList.Add( "DPURE_SHIPMENTCNTRF" );
            if ( frePEstFmDetail1.DPURE_SALESMONEYRF != frePEstFmDetail2.DPURE_SALESMONEYRF ) resList.Add( "DPURE_SALESMONEYRF" );
            if ( frePEstFmDetail1.DPRIM_GOODSMAKERCDRF != frePEstFmDetail2.DPRIM_GOODSMAKERCDRF ) resList.Add( "DPRIM_GOODSMAKERCDRF" );
            if ( frePEstFmDetail1.DPRIM_MAKERNAMERF != frePEstFmDetail2.DPRIM_MAKERNAMERF ) resList.Add( "DPRIM_MAKERNAMERF" );
            if ( frePEstFmDetail1.DPRIM_MAKERKANANAMERF != frePEstFmDetail2.DPRIM_MAKERKANANAMERF ) resList.Add( "DPRIM_MAKERKANANAMERF" );
            if ( frePEstFmDetail1.DPRIM_GOODSNORF != frePEstFmDetail2.DPRIM_GOODSNORF ) resList.Add( "DPRIM_GOODSNORF" );
            if ( frePEstFmDetail1.DPRIM_GOODSNAMERF != frePEstFmDetail2.DPRIM_GOODSNAMERF ) resList.Add( "DPRIM_GOODSNAMERF" );
            if ( frePEstFmDetail1.DPRIM_GOODSNAMEKANARF != frePEstFmDetail2.DPRIM_GOODSNAMEKANARF ) resList.Add( "DPRIM_GOODSNAMEKANARF" );
            if ( frePEstFmDetail1.DPRIM_BLGOODSCODERF != frePEstFmDetail2.DPRIM_BLGOODSCODERF ) resList.Add( "DPRIM_BLGOODSCODERF" );
            if ( frePEstFmDetail1.DPRIM_SALESUNPRCTAXINCFLRF != frePEstFmDetail2.DPRIM_SALESUNPRCTAXINCFLRF ) resList.Add( "DPRIM_SALESUNPRCTAXINCFLRF" );
            if ( frePEstFmDetail1.DPRIM_SALESUNPRCTAXEXCFLRF != frePEstFmDetail2.DPRIM_SALESUNPRCTAXEXCFLRF ) resList.Add( "DPRIM_SALESUNPRCTAXEXCFLRF" );
            if ( frePEstFmDetail1.DPRIM_LISTPRICETAXINCFLRF != frePEstFmDetail2.DPRIM_LISTPRICETAXINCFLRF ) resList.Add( "DPRIM_LISTPRICETAXINCFLRF" );
            if ( frePEstFmDetail1.DPRIM_LISTPRICETAXEXCFLRF != frePEstFmDetail2.DPRIM_LISTPRICETAXEXCFLRF ) resList.Add( "DPRIM_LISTPRICETAXEXCFLRF" );
            if ( frePEstFmDetail1.DPRIM_SALESMONEYTAXINCRF != frePEstFmDetail2.DPRIM_SALESMONEYTAXINCRF ) resList.Add( "DPRIM_SALESMONEYTAXINCRF" );
            if ( frePEstFmDetail1.DPRIM_SALESMONEYTAXEXCRF != frePEstFmDetail2.DPRIM_SALESMONEYTAXEXCRF ) resList.Add( "DPRIM_SALESMONEYTAXEXCRF" );
            if ( frePEstFmDetail1.DPRIM_TAXATIONDIVCDRF != frePEstFmDetail2.DPRIM_TAXATIONDIVCDRF ) resList.Add( "DPRIM_TAXATIONDIVCDRF" );
            if ( frePEstFmDetail1.DPRIM_SALESUNPRCFLRF != frePEstFmDetail2.DPRIM_SALESUNPRCFLRF ) resList.Add( "DPRIM_SALESUNPRCFLRF" );
            if ( frePEstFmDetail1.DPRIM_LISTPRICERF != frePEstFmDetail2.DPRIM_LISTPRICERF ) resList.Add( "DPRIM_LISTPRICERF" );
            if ( frePEstFmDetail1.DPRIM_SHIPMENTCNTRF != frePEstFmDetail2.DPRIM_SHIPMENTCNTRF ) resList.Add( "DPRIM_SHIPMENTCNTRF" );
            if ( frePEstFmDetail1.DPRIM_SALESMONEYRF != frePEstFmDetail2.DPRIM_SALESMONEYRF ) resList.Add( "DPRIM_SALESMONEYRF" );
            if ( frePEstFmDetail1.DADD_SPECIALNOTE != frePEstFmDetail2.DADD_SPECIALNOTE ) resList.Add( "DADD_SPECIALNOTE" );

            return resList;
        }
    }
}

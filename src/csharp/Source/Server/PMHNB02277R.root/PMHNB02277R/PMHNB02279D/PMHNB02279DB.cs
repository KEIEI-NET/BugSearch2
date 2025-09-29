using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   SumRsltInfo_BillBalanceWork
    /// <summary>
    ///                      売掛残高一覧表(総括)抽出結果クラスワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   売掛残高一覧表(総括)抽出結果クラスワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2010/06/06  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// <br>UpdateNote       :   11570208-00 軽減税率対応</br>
    /// <br>Programmer       :   3H 劉星光</br>
    /// <br>Date	         :   2020/04/10</br>
    /// <br>UpdateNote       : 11800255-00　インボイス対応（税率別合計金額不具合修正）</br>
    /// <br>Programmer       : 陳艶丹</br>
    /// <br>Date             : 2022/10/13</br>  
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class SumRsltInfo_BillBalanceWork
    {
        /// <summary>計上拠点コード</summary>
        /// <remarks>計上拠点コード</remarks>
        private string _addUpSecCode = "";

        /// <summary>拠点ガイド略称</summary>
        /// <remarks>拠点ガイド略称</remarks>
        private string _sectionGuideSnm = "";

        /// <summary>請求先コード</summary>
        private Int32 _claimCode;

        /// <summary>請求先略称</summary>
        private string _claimSnm = "";

        /// <summary>前回売掛金額</summary>
        /// <remarks>前回売掛金額</remarks>
        private Int64 _lastTimeAccRec;

        /// <summary>今回入金金額（通常入金）</summary>
        /// <remarks>今回入金金額（通常入金）</remarks>
        private Int64 _thisTimeDmdNrml;

        /// <summary>今回繰越残高（売掛計）</summary>
        /// <remarks>今回繰越残高（売掛計）</remarks>
        private Int64 _thisTimeTtlBlcAcc;

        /// <summary>相殺後今回売上金額</summary>
        /// <remarks>相殺後今回売上金額</remarks>
        private Int64 _ofsThisTimeSales;

        /// <summary>返品値引</summary>
        /// <remarks>今回売上返品金額+今回売上値引金額</remarks>
        private Int64 _thisRgdsDisPric;

        /// <summary>相殺後今回売上消費税</summary>
        /// <remarks>相殺後今回売上消費税</remarks>
        private Int64 _ofsThisSalesTax;

        /// <summary>計算後当月売掛金額</summary>
        /// <remarks>計算後当月売掛金額</remarks>
        private Int64 _afCalTMonthAccRec;

        /// <summary>売上伝票枚数</summary>
        /// <remarks>売上伝票枚数</remarks>
        private Int32 _salesSlipCount;

        /// <summary>担当者コード</summary>
        /// <remarks>顧客担当従業員コード or 集金担当従業員コード</remarks>
        private string _agentCd = "";

        /// <summary>名称</summary>
        /// <remarks>名称</remarks>
        private string _name = "";

        /// <summary>販売エリアコード</summary>
        /// <remarks>販売エリアコード</remarks>
        private Int32 _salesAreaCode;

        /// <summary>販売エリア名称</summary>
        /// <remarks>ガイド名称</remarks>
        private string _salesAreaName = "";

        /// <summary>今回手数料額（通常入金）</summary>
        /// <remarks>今回手数料額（通常入金）</remarks>
        private Int64 _thisTimeFeeDmdNrml;

        /// <summary>今回値引額（通常入金）</summary>
        /// <remarks>今回値引額（通常入金）</remarks>
        private Int64 _thisTimeDisDmdNrml;

        /// <summary>現金入金</summary>
        /// <remarks>金種コード：現金の入金金額</remarks>
        private Int64 _cashDeposit;

        /// <summary>振込</summary>
        /// <remarks>金種コード：振込の入金金額</remarks>
        private Int64 _trfrDeposit;

        /// <summary>小切手</summary>
        /// <remarks>金種コード：小切手の入金金額</remarks>
        private Int64 _checkDeposit;

        /// <summary>手形</summary>
        /// <remarks>金種コード：手形の入金金額</remarks>
        private Int64 _draftDeposit;

        /// <summary>相殺</summary>
        /// <remarks>金種コード：相殺の入金金額</remarks>
        private Int64 _offsetDeposit;

        /// <summary>口座振替</summary>
        /// <remarks>金種コード：口座振替の入金金額</remarks>
        private Int64 _fundTransferDeposit;

        /// <summary>その他</summary>
        /// <remarks>金種コード：その他の入金金額</remarks>
        private Int64 _othsDeposit;

        /// <summary>今回売上金額</summary>
        /// <remarks>今回売上金額</remarks>
        private Int64 _thisTimeSales;

        /// <summary>得意先コード</summary>
        private Int32 _customerCode;

        /// <summary>得意先略称</summary>
        private string _customersnm = "";

        /// <summary>総括請求拠点コード</summary>
        private string _sumSecCode = "";

        // --- ADD START 3H 劉星光 2020/04/10 ---------->>>>>
        /// <summary>税率1タイトル</summary>
        /// <remarks>税率1タイトル</remarks>
        private string _titleTaxRate1 = string.Empty;

        /// <summary>税率2タイトル</summary>
        /// <remarks>税率2タイトル</remarks>
        private string _titleTaxRate2 = string.Empty;

        /// <summary>売上額(計税率1)</summary>
        /// <remarks>売上額(計税率1)</remarks>
        private Int64 _totalThisTimeSalesTaxRate1;

        /// <summary>売上額(計税率2)</summary>
        /// <remarks>売上額(計税率2)</remarks>
        private Int64 _totalThisTimeSalesTaxRate2;

        /// <summary>売上額(計その他)</summary>
        /// <remarks>売上額(計その他)</remarks>
        private Int64 _totalThisTimeSalesOther;

        /// <summary>返品値引(計税率1)</summary>
        /// <remarks>返品値引(計税率1)</remarks>
        private Int64 _totalThisRgdsDisPricTaxRate1;

        /// <summary>返品値引(計税率2)</summary>
        /// <remarks>返品値引(計税率2)</remarks>
        private Int64 _totalThisRgdsDisPricTaxRate2;

        /// <summary>返品値引(計その他)</summary>
        /// <remarks>返品値引(計その他)</remarks>
        private Int64 _totalThisRgdsDisPricOther;

        /// <summary>純売上額(計税率1)</summary>
        /// <remarks>純売上額(計税率1)</remarks>
        private Int64 _totalPureSalesTaxRate1;

        /// <summary>純売上額(計税率2)</summary>
        /// <remarks>純売上額(計税率2)</remarks>
        private Int64 _totalPureSalesTaxRate2;

        /// <summary>純売上額(計その他)</summary>
        /// <remarks>純売上額(計その他)</remarks>
        private Int64 _totalPureSalesOther;

        /// <summary>消費税(計税率1)</summary>
        /// <remarks>消費税(計税率1)</remarks>
        private Int64 _totalSalesPricTaxTaxRate1;

        /// <summary>消費税(計税率2)</summary>
        /// <remarks>消費税(計税率2)</remarks>
        private Int64 _totalSalesPricTaxTaxRate2;

        /// <summary>消費税(計その他)</summary>
        /// <remarks>消費税(計その他)</remarks>
        private Int64 _totalSalesPricTaxOther;

        /// <summary>当月合計(計税率1)</summary>
        /// <remarks>当月合計(計税率1)</remarks>
        private Int64 _totalAfCalTMonthAccRecTaxRate1;

        /// <summary>当月合計(計税率2)</summary>
        /// <remarks>当月合計(計税率2)</remarks>
        private Int64 _totalAfCalTMonthAccRecTaxRate2;

        /// <summary>当月合計(計その他)</summary>
        /// <remarks>当月合計(計その他)</remarks>
        private Int64 _totalAfCalTMonthAccRecOther;

        /// <summary>枚数(計税率1)</summary>
        /// <remarks>枚数(計税率1)</remarks>
        private Int32 _totalSalesSlipCountTaxRate1;

        /// <summary>枚数(計税率2)</summary>
        /// <remarks>枚数(計税率2)</remarks>
        private Int32 _totalSalesSlipCountTaxRate2;

        /// <summary>枚数(計その他)</summary>
        /// <remarks>枚数(計その他)</remarks>
        private Int32 _totalSalesSlipCountOther;
        // --- ADD END 3H 劉星光 2020/04/10 ----------<<<<<

        // --- ADD 2022/10/13 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） ----->>>>>
        /// <summary>売上額(非課税)</summary>
        /// <remarks>売上額(非課税)</remarks>
        private Int64 _totalThisTimeSalesTaxFree;

        /// <summary>返品値引(非課税)</summary>
        /// <remarks>返品値引(非課税)</remarks>
        private Int64 _totalThisRgdsDisPricTaxFree;

        /// <summary>純売上額(非課税)</summary>
        /// <remarks>純売上額(非課税)</remarks>
        private Int64 _totalPureSalesTaxFree;

        /// <summary>消費税(非課税)</summary>
        /// <remarks>消費税(非課税)</remarks>
        private Int64 _totalSalesPricTaxTaxFree;

        /// <summary>当月合計(非課税)</summary>
        /// <remarks>当月合計(非課税)</remarks>
        private Int64 _totalAfCalTMonthAccRecTaxFree;

        /// <summary>枚数(非課税)</summary>
        /// <remarks>枚数(非課税)</remarks>
        private Int32 _totalSalesSlipCountTaxFree;
        // --- ADD 2022/10/13 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） -----<<<<<

        /// public propaty name  :  AddUpSecCode
        /// <summary>計上拠点コードプロパティ</summary>
        /// <value>計上拠点コード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   計上拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string AddUpSecCode
        {
            get { return _addUpSecCode; }
            set { _addUpSecCode = value; }
        }

        /// public propaty name  :  SectionGuideSnm
        /// <summary>拠点ガイド略称プロパティ</summary>
        /// <value>拠点ガイド略称</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点ガイド略称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SectionGuideSnm
        {
            get { return _sectionGuideSnm; }
            set { _sectionGuideSnm = value; }
        }

        /// public propaty name  :  ClaimCode
        /// <summary>請求先コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   請求先コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ClaimCode
        {
            get { return _claimCode; }
            set { _claimCode = value; }
        }

        /// public propaty name  :  ClaimSnm
        /// <summary>請求先略称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   請求先略称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ClaimSnm
        {
            get { return _claimSnm; }
            set { _claimSnm = value; }
        }

        /// public propaty name  :  LastTimeAccRec
        /// <summary>前回売掛金額プロパティ</summary>
        /// <value>前回売掛金額</value>
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

        /// public propaty name  :  ThisTimeDmdNrml
        /// <summary>今回入金金額（通常入金）プロパティ</summary>
        /// <value>今回入金金額（通常入金）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   今回入金金額（通常入金）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 ThisTimeDmdNrml
        {
            get { return _thisTimeDmdNrml; }
            set { _thisTimeDmdNrml = value; }
        }

        /// public propaty name  :  ThisTimeTtlBlcAcc
        /// <summary>今回繰越残高（売掛計）プロパティ</summary>
        /// <value>今回繰越残高（売掛計）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   今回繰越残高（売掛計）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 ThisTimeTtlBlcAcc
        {
            get { return _thisTimeTtlBlcAcc; }
            set { _thisTimeTtlBlcAcc = value; }
        }

        /// public propaty name  :  OfsThisTimeSales
        /// <summary>相殺後今回売上金額プロパティ</summary>
        /// <value>相殺後今回売上金額</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   相殺後今回売上金額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 OfsThisTimeSales
        {
            get { return _ofsThisTimeSales; }
            set { _ofsThisTimeSales = value; }
        }

        /// public propaty name  :  ThisRgdsDisPric
        /// <summary>返品値引プロパティ</summary>
        /// <value>今回売上返品金額+今回売上値引金額</value>
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

        /// public propaty name  :  OfsThisSalesTax
        /// <summary>相殺後今回売上消費税プロパティ</summary>
        /// <value>相殺後今回売上消費税</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   相殺後今回売上消費税プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 OfsThisSalesTax
        {
            get { return _ofsThisSalesTax; }
            set { _ofsThisSalesTax = value; }
        }

        /// public propaty name  :  AfCalTMonthAccRec
        /// <summary>計算後当月売掛金額プロパティ</summary>
        /// <value>計算後当月売掛金額</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   計算後当月売掛金額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 AfCalTMonthAccRec
        {
            get { return _afCalTMonthAccRec; }
            set { _afCalTMonthAccRec = value; }
        }

        /// public propaty name  :  SalesSlipCount
        /// <summary>売上伝票枚数プロパティ</summary>
        /// <value>売上伝票枚数</value>
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

        /// public propaty name  :  AgentCd
        /// <summary>担当者コードプロパティ</summary>
        /// <value>顧客担当従業員コード or 集金担当従業員コード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   担当者コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string AgentCd
        {
            get { return _agentCd; }
            set { _agentCd = value; }
        }

        /// public propaty name  :  Name
        /// <summary>名称プロパティ</summary>
        /// <value>名称</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        /// public propaty name  :  SalesAreaCode
        /// <summary>販売エリアコードプロパティ</summary>
        /// <value>販売エリアコード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   販売エリアコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SalesAreaCode
        {
            get { return _salesAreaCode; }
            set { _salesAreaCode = value; }
        }

        /// public propaty name  :  SalesAreaName
        /// <summary>販売エリア名称プロパティ</summary>
        /// <value>ガイド名称</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   販売エリア名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SalesAreaName
        {
            get { return _salesAreaName; }
            set { _salesAreaName = value; }
        }

        /// public propaty name  :  ThisTimeFeeDmdNrml
        /// <summary>今回手数料額（通常入金）プロパティ</summary>
        /// <value>今回手数料額（通常入金）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   今回手数料額（通常入金）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 ThisTimeFeeDmdNrml
        {
            get { return _thisTimeFeeDmdNrml; }
            set { _thisTimeFeeDmdNrml = value; }
        }

        /// public propaty name  :  ThisTimeDisDmdNrml
        /// <summary>今回値引額（通常入金）プロパティ</summary>
        /// <value>今回値引額（通常入金）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   今回値引額（通常入金）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 ThisTimeDisDmdNrml
        {
            get { return _thisTimeDisDmdNrml; }
            set { _thisTimeDisDmdNrml = value; }
        }

        /// public propaty name  :  CashDeposit
        /// <summary>現金入金プロパティ</summary>
        /// <value>金種コード：現金の入金金額</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   現金入金プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 CashDeposit
        {
            get { return _cashDeposit; }
            set { _cashDeposit = value; }
        }

        /// public propaty name  :  TrfrDeposit
        /// <summary>振込プロパティ</summary>
        /// <value>金種コード：振込の入金金額</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   振込プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 TrfrDeposit
        {
            get { return _trfrDeposit; }
            set { _trfrDeposit = value; }
        }

        /// public propaty name  :  CheckDeposit
        /// <summary>小切手プロパティ</summary>
        /// <value>金種コード：小切手の入金金額</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   小切手プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 CheckDeposit
        {
            get { return _checkDeposit; }
            set { _checkDeposit = value; }
        }

        /// public propaty name  :  DraftDeposit
        /// <summary>手形プロパティ</summary>
        /// <value>金種コード：手形の入金金額</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   手形プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 DraftDeposit
        {
            get { return _draftDeposit; }
            set { _draftDeposit = value; }
        }

        /// public propaty name  :  OffsetDeposit
        /// <summary>相殺プロパティ</summary>
        /// <value>金種コード：相殺の入金金額</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   相殺プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 OffsetDeposit
        {
            get { return _offsetDeposit; }
            set { _offsetDeposit = value; }
        }

        /// public propaty name  :  FundTransferDeposit
        /// <summary>口座振替プロパティ</summary>
        /// <value>金種コード：口座振替の入金金額</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   口座振替プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 FundTransferDeposit
        {
            get { return _fundTransferDeposit; }
            set { _fundTransferDeposit = value; }
        }

        /// public propaty name  :  OthsDeposit
        /// <summary>その他プロパティ</summary>
        /// <value>金種コード：その他の入金金額</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   その他プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 OthsDeposit
        {
            get { return _othsDeposit; }
            set { _othsDeposit = value; }
        }

        /// public propaty name  :  ThisTimeSales
        /// <summary>今回売上金額プロパティ</summary>
        /// <value>今回売上金額</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   今回売上金額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 ThisTimeSales
        {
            get { return _thisTimeSales; }
            set { _thisTimeSales = value; }
        }

        /// public propaty name  :  CustomerCode
        /// <summary>得意先コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CustomerCode
        {
            get { return _customerCode; }
            set { _customerCode = value; }
        }

        /// public propaty name  :  Customersnm
        /// <summary>得意先略称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先略称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string Customersnm
        {
            get { return _customersnm; }
            set { _customersnm = value; }
        }

        /// public propaty name  :  SumSecCode
        /// <summary>総括請求拠点コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   総括請求拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SumSecCode
        {
            get { return _sumSecCode; }
            set { _sumSecCode = value; }
        }

        // --- ADD START 3H 劉星光 2020/04/10 ---------->>>>>
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

        /// public propaty name  :  TotalThisTimeSalesTaxRate1
        /// <summary>売上額(計税率1) </summary>
        /// <value>売上額(計税率1) </value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上額(計税率1) プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 TotalThisTimeSalesTaxRate1
        {
            get { return _totalThisTimeSalesTaxRate1; }
            set { _totalThisTimeSalesTaxRate1 = value; }
        }

        /// public propaty name  :  TotalThisTimeSalesTaxRate2
        /// <summary>売上額(計税率2) </summary>
        /// <value>売上額(計税率2) </value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上額(計税率2) プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 TotalThisTimeSalesTaxRate2
        {
            get { return _totalThisTimeSalesTaxRate2; }
            set { _totalThisTimeSalesTaxRate2 = value; }
        }

        /// public propaty name  :  TotalThisTimeSalesOther
        /// <summary>売上額(計その他) </summary>
        /// <value>売上額(計その他) </value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上額(計その他) プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 TotalThisTimeSalesOther
        {
            get { return _totalThisTimeSalesOther; }
            set { _totalThisTimeSalesOther = value; }
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

        /// public propaty name  :  TotalPureSalesTaxRate1
        /// <summary>純売上額(計税率1) </summary>
        /// <value>純売上額(計税率1) </value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   純売上額(計税率1) プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 TotalPureSalesTaxRate1
        {
            get { return _totalPureSalesTaxRate1; }
            set { _totalPureSalesTaxRate1 = value; }
        }

        /// public propaty name  :  TotalPureSalesTaxRate2
        /// <summary>純売上額(計税率2) </summary>
        /// <value>純売上額(計税率2) </value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   純売上額(計税率2) プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 TotalPureSalesTaxRate2
        {
            get { return _totalPureSalesTaxRate2; }
            set { _totalPureSalesTaxRate2 = value; }
        }

        /// public propaty name  :  TotalPureSalesOther
        /// <summary>純売上額(計その他) </summary>
        /// <value>純売上額(計その他) </value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   純売上額(計その他) プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 TotalPureSalesOther
        {
            get { return _totalPureSalesOther; }
            set { _totalPureSalesOther = value; }
        }

        /// public propaty name  :  TotalSalesPricTaxTaxRate1
        /// <summary>消費税(計税率1) </summary>
        /// <value>消費税(計税率1) </value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   消費税(計税率1) プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 TotalSalesPricTaxTaxRate1
        {
            get { return _totalSalesPricTaxTaxRate1; }
            set { _totalSalesPricTaxTaxRate1 = value; }
        }

        /// public propaty name  :  TotalSalesPricTaxTaxRate2
        /// <summary>消費税(計税率2) </summary>
        /// <value>消費税(計税率2) </value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   消費税(計税率2) プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 TotalSalesPricTaxTaxRate2
        {
            get { return _totalSalesPricTaxTaxRate2; }
            set { _totalSalesPricTaxTaxRate2 = value; }
        }

        /// public propaty name  :  TotalSalesPricTaxOther
        /// <summary>消費税(計その他) </summary>
        /// <value>消費税(計その他) </value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   消費税(計その他) プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 TotalSalesPricTaxOther
        {
            get { return _totalSalesPricTaxOther; }
            set { _totalSalesPricTaxOther = value; }
        }

        /// public propaty name  :  TotalAfCalTMonthAccRecTaxRate1
        /// <summary>当月合計(計税率1) </summary>
        /// <value>当月合計(計税率1) </value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   当月合計(計税率1) プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 TotalAfCalTMonthAccRecTaxRate1
        {
            get { return _totalAfCalTMonthAccRecTaxRate1; }
            set { _totalAfCalTMonthAccRecTaxRate1 = value; }
        }

        /// public propaty name  :  TotalAfCalTMonthAccRecTaxRate2
        /// <summary>当月合計(計税率2) </summary>
        /// <value>当月合計(計税率2) </value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   当月合計(計税率2) プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 TotalAfCalTMonthAccRecTaxRate2
        {
            get { return _totalAfCalTMonthAccRecTaxRate2; }
            set { _totalAfCalTMonthAccRecTaxRate2 = value; }
        }

        /// public propaty name  :  TotalAfCalTMonthAccRecOther
        /// <summary>当月合計(計その他) </summary>
        /// <value>当月合計(計その他) </value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   当月合計(計その他) プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 TotalAfCalTMonthAccRecOther
        {
            get { return _totalAfCalTMonthAccRecOther; }
            set { _totalAfCalTMonthAccRecOther = value; }
        }

        /// public propaty name  :  TotalSalesSlipCountTaxRate1
        /// <summary>枚数(計税率1) </summary>
        /// <value>枚数(計税率1) </value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   枚数(計税率1) プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 TotalSalesSlipCountTaxRate1
        {
            get { return _totalSalesSlipCountTaxRate1; }
            set { _totalSalesSlipCountTaxRate1 = value; }
        }

        /// public propaty name  :  TotalSalesSlipCountTaxRate2
        /// <summary>枚数(計税率2) </summary>
        /// <value>枚数(計税率2) </value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   枚数(計税率2) プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 TotalSalesSlipCountTaxRate2
        {
            get { return _totalSalesSlipCountTaxRate2; }
            set { _totalSalesSlipCountTaxRate2 = value; }
        }

        /// public propaty name  :  TotalSalesSlipCountOther
        /// <summary>枚数(計その他) </summary>
        /// <value>枚数(計その他) </value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   枚数(計その他) プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 TotalSalesSlipCountOther
        {
            get { return _totalSalesSlipCountOther; }
            set { _totalSalesSlipCountOther = value; }
        }
        // --- ADD END 3H 劉星光 2020/04/10 ----------<<<<<

        // --- ADD 2022/10/13 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） ----->>>>>
        /// public propaty name  :  TotalThisTimeSalesTaxFree
        /// <summary>売上額(非課税)プロパティ</summary>
        /// <value>売上額(非課税)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上額(非課税)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 TotalThisTimeSalesTaxFree
        {
            get { return _totalThisTimeSalesTaxFree; }
            set { _totalThisTimeSalesTaxFree = value; }
        }
        /// public propaty name  :  TotalThisRgdsDisPricTaxFree
        /// <summary>返品値引(非課税)プロパティ</summary>
        /// <value>返品値引(非課税)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   返品値引(非課税)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 TotalThisRgdsDisPricTaxFree
        {
            get { return _totalThisRgdsDisPricTaxFree; }
            set { _totalThisRgdsDisPricTaxFree = value; }
        }
        /// public propaty name  :  TotalPureSalesTaxFree
        /// <summary>純売上額(非課税)プロパティ</summary>
        /// <value>純売上額(非課税)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :  純売上額(非課税)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 TotalPureSalesTaxFree
        {
            get { return _totalPureSalesTaxFree; }
            set { _totalPureSalesTaxFree = value; }
        }
        /// public propaty name  :  TotalSalesPricTaxTaxFree
        /// <summary>消費税(非課税)プロパティ</summary>
        /// <value>消費税(非課税)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :  消費税(非課税)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 TotalSalesPricTaxTaxFree
        {
            get { return _totalSalesPricTaxTaxFree; }
            set { _totalSalesPricTaxTaxFree = value; }
        }

        /// public propaty name  :  TotalAfCalTMonthAccRecTaxFree
        /// <summary>当月合計(非課税)プロパティ</summary>
        /// <value>当月合計(非課税)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :  当月合計(非課税)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 TotalAfCalTMonthAccRecTaxFree
        {
            get { return _totalAfCalTMonthAccRecTaxFree; }
            set { _totalAfCalTMonthAccRecTaxFree = value; }
        }

        /// public propaty name  :  TotalSalesSlipCountTaxFree
        /// <summary>枚数(非課税)プロパティ</summary>
        /// <value>枚数(非課税)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :  枚数(非課税)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 TotalSalesSlipCountTaxFree
        {
            get { return _totalSalesSlipCountTaxFree; }
            set { _totalSalesSlipCountTaxFree = value; }
        }

        // --- ADD 2022/10/13 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） -----<<<<<

        /// <summary>
        /// 売掛残高一覧表(総括)抽出結果クラスワークコンストラクタ
        /// </summary>
        /// <returns>SumRsltInfo_BillBalanceWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SumRsltInfo_BillBalanceWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public SumRsltInfo_BillBalanceWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>SumRsltInfo_BillBalanceWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   SumRsltInfo_BillBalanceWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// <br>UpdateNote       :   11570208-00 軽減税率対応</br>
    /// <br>Programmer       :   3H 劉星光</br>
    /// <br>Date	         :   2020/04/10</br>
    /// </remarks>
    public class SumRsltInfo_BillBalanceWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   SumRsltInfo_BillBalanceWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// <br>UpdateNote       :   11570208-00 軽減税率対応</br>
        /// <br>Programmer       :   3H 劉星光</br>
        /// <br>Date	         :   2020/04/10</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  SumRsltInfo_BillBalanceWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is SumRsltInfo_BillBalanceWork || graph is ArrayList || graph is SumRsltInfo_BillBalanceWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(SumRsltInfo_BillBalanceWork).FullName));

            if (graph != null && graph is SumRsltInfo_BillBalanceWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.SumRsltInfo_BillBalanceWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is SumRsltInfo_BillBalanceWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((SumRsltInfo_BillBalanceWork[])graph).Length;
            }
            else if (graph is SumRsltInfo_BillBalanceWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //繰り返し数	

            //計上拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //AddUpSecCode
            //拠点ガイド略称
            serInfo.MemberInfo.Add(typeof(string)); //SectionGuideSnm
            //請求先コード
            serInfo.MemberInfo.Add(typeof(Int32)); //ClaimCode
            //請求先略称
            serInfo.MemberInfo.Add(typeof(string)); //ClaimSnm
            //前回売掛金額
            serInfo.MemberInfo.Add(typeof(Int64)); //LastTimeAccRec
            //今回入金金額（通常入金）
            serInfo.MemberInfo.Add(typeof(Int64)); //ThisTimeDmdNrml
            //今回繰越残高（売掛計）
            serInfo.MemberInfo.Add(typeof(Int64)); //ThisTimeTtlBlcAcc
            //相殺後今回売上金額
            serInfo.MemberInfo.Add(typeof(Int64)); //OfsThisTimeSales
            //返品値引
            serInfo.MemberInfo.Add(typeof(Int64)); //ThisRgdsDisPric
            //相殺後今回売上消費税
            serInfo.MemberInfo.Add(typeof(Int64)); //OfsThisSalesTax
            //計算後当月売掛金額
            serInfo.MemberInfo.Add(typeof(Int64)); //AfCalTMonthAccRec
            //売上伝票枚数
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesSlipCount
            //担当者コード
            serInfo.MemberInfo.Add(typeof(string)); //AgentCd
            //名称
            serInfo.MemberInfo.Add(typeof(string)); //Name
            //販売エリアコード
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesAreaCode
            //販売エリア名称
            serInfo.MemberInfo.Add(typeof(string)); //SalesAreaName
            //今回手数料額（通常入金）
            serInfo.MemberInfo.Add(typeof(Int64)); //ThisTimeFeeDmdNrml
            //今回値引額（通常入金）
            serInfo.MemberInfo.Add(typeof(Int64)); //ThisTimeDisDmdNrml
            //現金入金
            serInfo.MemberInfo.Add(typeof(Int64)); //CashDeposit
            //振込
            serInfo.MemberInfo.Add(typeof(Int64)); //TrfrDeposit
            //小切手
            serInfo.MemberInfo.Add(typeof(Int64)); //CheckDeposit
            //手形
            serInfo.MemberInfo.Add(typeof(Int64)); //DraftDeposit
            //相殺
            serInfo.MemberInfo.Add(typeof(Int64)); //OffsetDeposit
            //口座振替
            serInfo.MemberInfo.Add(typeof(Int64)); //FundTransferDeposit
            //その他
            serInfo.MemberInfo.Add(typeof(Int64)); //OthsDeposit
            //今回売上金額
            serInfo.MemberInfo.Add(typeof(Int64)); //ThisTimeSales
            //得意先コード
            serInfo.MemberInfo.Add(typeof(Int32)); //CustomerCode
            //得意先略称
            serInfo.MemberInfo.Add(typeof(string)); //Customersnm
            //総括請求拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //SumSecCode
            // --- ADD START 3H 劉星光 2020/04/10 ---------->>>>>
            // 売上額(計税率1)
            serInfo.MemberInfo.Add(typeof(Int64)); //TotalThisTimeSalesTaxRate1
            // 売上額(計税率2)
            serInfo.MemberInfo.Add(typeof(Int64)); //TotalThisTimeSalesTaxRate2
            // 売上額(計その他)
            serInfo.MemberInfo.Add(typeof(Int64)); //TotalThisTimeSalesOther
            // 返品値引(計税率1)
            serInfo.MemberInfo.Add(typeof(Int64)); //TotalThisRgdsDisPricTaxRate1
            // 返品値引(計税率2)
            serInfo.MemberInfo.Add(typeof(Int64)); //TotalThisRgdsDisPricTaxRate2
            // 返品値引(計その他)
            serInfo.MemberInfo.Add(typeof(Int64)); //TotalThisRgdsDisPricOther
            // 純売上額(計税率1)
            serInfo.MemberInfo.Add(typeof(Int64)); //TotalPureSalesTaxRate1
            // 純売上額(計税率2)
            serInfo.MemberInfo.Add(typeof(Int64)); //TotalPureSalesTaxRate2
            // 純売上額(計その他)
            serInfo.MemberInfo.Add(typeof(Int64)); //TotalPureSalesOther
            // 消費税(計税率1)
            serInfo.MemberInfo.Add(typeof(Int64)); //TotalSalesPricTaxTaxRate1
            // 消費税(計税率2)
            serInfo.MemberInfo.Add(typeof(Int64)); //TotalSalesPricTaxTaxRate2
            // 消費税(計その他)
            serInfo.MemberInfo.Add(typeof(Int64)); //TotalSalesPricTax_Other
            // 当月合計(計税率1)
            serInfo.MemberInfo.Add(typeof(Int64)); //TotalAfCalTMonthAccRecTaxRate1
            // 当月合計(計税率2)
            serInfo.MemberInfo.Add(typeof(Int64)); //TotalAfCalTMonthAccRecTaxRate2
            // 当月合計(計その他)
            serInfo.MemberInfo.Add(typeof(Int64)); //TotalAfCalTMonthAccRecOther
            // 枚数(計税率1)
            serInfo.MemberInfo.Add(typeof(Int32)); //TotalSalesSlipCountTaxRate1
            // 枚数(計税率2)
            serInfo.MemberInfo.Add(typeof(Int32)); //TotalSalesSlipCountTaxRate2
            // 枚数(計その他)
            serInfo.MemberInfo.Add(typeof(Int32)); //TotalSalesSlipCountOther
            // 税率1タイトル
            serInfo.MemberInfo.Add(typeof(string)); //TtitleTaxRate1
            // 税率2タイトル
            serInfo.MemberInfo.Add(typeof(string)); //TtitleTaxRate2
            // --- ADD END 3H 劉星光 2020/04/10 ----------<<<<<

            // --- ADD 2022/10/13 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） ----->>>>>
            // 売上額(非課税)
            serInfo.MemberInfo.Add(typeof(Int64)); //TotalThisTimeSalesTaxFree
            // 返品値引(非課税)
            serInfo.MemberInfo.Add(typeof(Int64)); //TotalThisRgdsDisPricTaxFree
            // 純売上額(非課税)
            serInfo.MemberInfo.Add(typeof(Int64)); //TotalPureSalesTaxFree
            // 消費税(非課税)
            serInfo.MemberInfo.Add(typeof(Int64)); //TotalSalesPricTaxTaxFree
            // 当月合計(非課税)
            serInfo.MemberInfo.Add(typeof(Int64)); //TotalAfCalTMonthAccRecTaxFree
            // 枚数(非課税)
            serInfo.MemberInfo.Add(typeof(Int32)); //TotalSalesSlipCountTaxFree
            // --- ADD 2022/10/13 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） -----<<<<<

            serInfo.Serialize(writer, serInfo);
            if (graph is SumRsltInfo_BillBalanceWork)
            {
                SumRsltInfo_BillBalanceWork temp = (SumRsltInfo_BillBalanceWork)graph;

                SetSumRsltInfo_BillBalanceWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is SumRsltInfo_BillBalanceWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((SumRsltInfo_BillBalanceWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (SumRsltInfo_BillBalanceWork temp in lst)
                {
                    SetSumRsltInfo_BillBalanceWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// SumRsltInfo_BillBalanceWorkメンバ数(publicプロパティ数)
        /// </summary>
        //private const int currentMemberCount = 29; // DEL 3H 劉星光 2020/04/10
        // --- DEL 2022/10/13 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） ----->>>>>
        //private const int currentMemberCount = 49; // ADD 3H 劉星光 2020/04/10
        // --- DEL 2022/10/13 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） ----->>>>>
        private const int currentMemberCount = 55; // ADD 2022/09/19 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）

        /// <summary>
        ///  SumRsltInfo_BillBalanceWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   SumRsltInfo_BillBalanceWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// <br>UpdateNote       :   11570208-00 軽減税率対応</br>
        /// <br>Programmer       :   3H 劉星光</br>
        /// <br>Date	         :   2020/04/10</br>
        /// </remarks>
        private void SetSumRsltInfo_BillBalanceWork(System.IO.BinaryWriter writer, SumRsltInfo_BillBalanceWork temp)
        {
            //計上拠点コード
            writer.Write(temp.AddUpSecCode);
            //拠点ガイド略称
            writer.Write(temp.SectionGuideSnm);
            //請求先コード
            writer.Write(temp.ClaimCode);
            //請求先略称
            writer.Write(temp.ClaimSnm);
            //前回売掛金額
            writer.Write(temp.LastTimeAccRec);
            //今回入金金額（通常入金）
            writer.Write(temp.ThisTimeDmdNrml);
            //今回繰越残高（売掛計）
            writer.Write(temp.ThisTimeTtlBlcAcc);
            //相殺後今回売上金額
            writer.Write(temp.OfsThisTimeSales);
            //返品値引
            writer.Write(temp.ThisRgdsDisPric);
            //相殺後今回売上消費税
            writer.Write(temp.OfsThisSalesTax);
            //計算後当月売掛金額
            writer.Write(temp.AfCalTMonthAccRec);
            //売上伝票枚数
            writer.Write(temp.SalesSlipCount);
            //担当者コード
            writer.Write(temp.AgentCd);
            //名称
            writer.Write(temp.Name);
            //販売エリアコード
            writer.Write(temp.SalesAreaCode);
            //販売エリア名称
            writer.Write(temp.SalesAreaName);
            //今回手数料額（通常入金）
            writer.Write(temp.ThisTimeFeeDmdNrml);
            //今回値引額（通常入金）
            writer.Write(temp.ThisTimeDisDmdNrml);
            //現金入金
            writer.Write(temp.CashDeposit);
            //振込
            writer.Write(temp.TrfrDeposit);
            //小切手
            writer.Write(temp.CheckDeposit);
            //手形
            writer.Write(temp.DraftDeposit);
            //相殺
            writer.Write(temp.OffsetDeposit);
            //口座振替
            writer.Write(temp.FundTransferDeposit);
            //その他
            writer.Write(temp.OthsDeposit);
            //今回売上金額
            writer.Write(temp.ThisTimeSales);
            //得意先コード
            writer.Write(temp.CustomerCode);
            //得意先略称
            writer.Write(temp.Customersnm);
            //総括請求拠点コード
            writer.Write(temp.SumSecCode);
            // --- ADD START 3H 劉星光 2020/04/10 ---------->>>>>
            //売上額(計税率1)
            writer.Write(temp.TotalThisTimeSalesTaxRate1);
            //売上額(計税率2)
            writer.Write(temp.TotalThisTimeSalesTaxRate2);
            //売上額(計その他)
            writer.Write(temp.TotalThisTimeSalesOther);
            //返品値引(計税率1)
            writer.Write(temp.TotalThisRgdsDisPricTaxRate1);
            //返品値引(計税率2)
            writer.Write(temp.TotalThisRgdsDisPricTaxRate2);
            //返品値引(計その他)
            writer.Write(temp.TotalThisRgdsDisPricOther);
            //純売上額(計税率1)
            writer.Write(temp.TotalPureSalesTaxRate1);
            //純売上額(計税率2)
            writer.Write(temp.TotalPureSalesTaxRate2);
            //純売上額(計その他)
            writer.Write(temp.TotalPureSalesOther);
            //消費税(計税率1)
            writer.Write(temp.TotalSalesPricTaxTaxRate1);
            //消費税(計税率2)
            writer.Write(temp.TotalSalesPricTaxTaxRate2);
            //消費税(計その他)
            writer.Write(temp.TotalSalesPricTaxOther);
            //当月合計(計税率1)
            writer.Write(temp.TotalAfCalTMonthAccRecTaxRate1);
            //当月合計(計税率2)
            writer.Write(temp.TotalAfCalTMonthAccRecTaxRate2);
            //当月合計(計その他)
            writer.Write(temp.TotalAfCalTMonthAccRecOther);
            //枚数(計税率1)
            writer.Write(temp.TotalSalesSlipCountTaxRate1);
            //枚数(計税率2)
            writer.Write(temp.TotalSalesSlipCountTaxRate2);
            //枚数(計その他)
            writer.Write(temp.TotalSalesSlipCountOther);
            //税率1タイトル
            writer.Write(temp.TitleTaxRate1);
            //税率2タイトル
            writer.Write(temp.TitleTaxRate2);
            // --- ADD END 3H 劉星光 2020/04/10 ----------<<<<<

            // --- ADD 2022/10/13 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） ----->>>>>
            // 売上額(非課税)
            writer.Write(temp.TotalThisTimeSalesTaxFree);
            // 返品値引(非課税)
            writer.Write(temp.TotalThisRgdsDisPricTaxFree);
            // 純売上額(非課税)
            writer.Write(temp.TotalPureSalesTaxFree);
            // 消費税(非課税)
            writer.Write(temp.TotalSalesPricTaxTaxFree);
            // 当月合計(非課税)
            writer.Write(temp.TotalAfCalTMonthAccRecTaxFree);
            // 枚数(非課税)
            writer.Write(temp.TotalSalesSlipCountTaxFree);
            // --- ADD 2022/10/13 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） -----<<<<<
        }

        /// <summary>
        ///  SumRsltInfo_BillBalanceWorkインスタンス取得
        /// </summary>
        /// <returns>SumRsltInfo_BillBalanceWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SumRsltInfo_BillBalanceWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// <br>UpdateNote       :   11570208-00 軽減税率対応</br>
        /// <br>Programmer       :   3H 劉星光</br>
        /// <br>Date	         :   2020/04/10</br>
        /// </remarks>
        private SumRsltInfo_BillBalanceWork GetSumRsltInfo_BillBalanceWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            SumRsltInfo_BillBalanceWork temp = new SumRsltInfo_BillBalanceWork();

            //計上拠点コード
            temp.AddUpSecCode = reader.ReadString();
            //拠点ガイド略称
            temp.SectionGuideSnm = reader.ReadString();
            //請求先コード
            temp.ClaimCode = reader.ReadInt32();
            //請求先略称
            temp.ClaimSnm = reader.ReadString();
            //前回売掛金額
            temp.LastTimeAccRec = reader.ReadInt64();
            //今回入金金額（通常入金）
            temp.ThisTimeDmdNrml = reader.ReadInt64();
            //今回繰越残高（売掛計）
            temp.ThisTimeTtlBlcAcc = reader.ReadInt64();
            //相殺後今回売上金額
            temp.OfsThisTimeSales = reader.ReadInt64();
            //返品値引
            temp.ThisRgdsDisPric = reader.ReadInt64();
            //相殺後今回売上消費税
            temp.OfsThisSalesTax = reader.ReadInt64();
            //計算後当月売掛金額
            temp.AfCalTMonthAccRec = reader.ReadInt64();
            //売上伝票枚数
            temp.SalesSlipCount = reader.ReadInt32();
            //担当者コード
            temp.AgentCd = reader.ReadString();
            //名称
            temp.Name = reader.ReadString();
            //販売エリアコード
            temp.SalesAreaCode = reader.ReadInt32();
            //販売エリア名称
            temp.SalesAreaName = reader.ReadString();
            //今回手数料額（通常入金）
            temp.ThisTimeFeeDmdNrml = reader.ReadInt64();
            //今回値引額（通常入金）
            temp.ThisTimeDisDmdNrml = reader.ReadInt64();
            //現金入金
            temp.CashDeposit = reader.ReadInt64();
            //振込
            temp.TrfrDeposit = reader.ReadInt64();
            //小切手
            temp.CheckDeposit = reader.ReadInt64();
            //手形
            temp.DraftDeposit = reader.ReadInt64();
            //相殺
            temp.OffsetDeposit = reader.ReadInt64();
            //口座振替
            temp.FundTransferDeposit = reader.ReadInt64();
            //その他
            temp.OthsDeposit = reader.ReadInt64();
            //今回売上金額
            temp.ThisTimeSales = reader.ReadInt64();
            //得意先コード
            temp.CustomerCode = reader.ReadInt32();
            //得意先略称
            temp.Customersnm = reader.ReadString();
            //総括請求拠点コード
            temp.SumSecCode = reader.ReadString();
            // --- ADD START 3H 劉星光 2020/04/10 ---------->>>>>
            //売上額(計税率1)
            temp.TotalThisTimeSalesTaxRate1 = reader.ReadInt64();
            //売上額(計税率2)
            temp.TotalThisTimeSalesTaxRate2 = reader.ReadInt64();
            //売上額(計その他)
            temp.TotalThisTimeSalesOther = reader.ReadInt64();
            //返品値引(計税率1)
            temp.TotalThisRgdsDisPricTaxRate1 = reader.ReadInt64();
            //返品値引(計税率2)
            temp.TotalThisRgdsDisPricTaxRate2 = reader.ReadInt64();
            //返品値引(計その他)
            temp.TotalThisRgdsDisPricOther = reader.ReadInt64();
            //純売上額(計税率1)
            temp.TotalPureSalesTaxRate1 = reader.ReadInt64();
            //純売上額(計税率2)
            temp.TotalPureSalesTaxRate2 = reader.ReadInt64();
            //純売上額(計その他)
            temp.TotalPureSalesOther = reader.ReadInt64();
            //消費税(計税率1)
            temp.TotalSalesPricTaxTaxRate1 = reader.ReadInt64();
            //消費税(計税率2)
            temp.TotalSalesPricTaxTaxRate2 = reader.ReadInt64();
            //消費税(計その他)
            temp.TotalSalesPricTaxOther = reader.ReadInt64();
            //当月合計(計税率1)
            temp.TotalAfCalTMonthAccRecTaxRate1 = reader.ReadInt64();
            //当月合計(計税率2)
            temp.TotalAfCalTMonthAccRecTaxRate2 = reader.ReadInt64();
            //当月合計(計その他)
            temp.TotalAfCalTMonthAccRecOther = reader.ReadInt64();
            //枚数(計税率1)
            temp.TotalSalesSlipCountTaxRate1 = reader.ReadInt32();
            //枚数(計税率2)
            temp.TotalSalesSlipCountTaxRate2 = reader.ReadInt32();
            //枚数(計その他)
            temp.TotalSalesSlipCountOther = reader.ReadInt32();
            //税率1タイトル
            temp.TitleTaxRate1 = reader.ReadString();
            //税率2タイトル
            temp.TitleTaxRate2 = reader.ReadString();
            // --- ADD END 3H 劉星光 2020/04/10 ----------<<<<<

            // --- ADD 2022/10/13 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） ----->>>>>
            // 売上額(非課税)
            temp.TotalThisTimeSalesTaxFree = reader.ReadInt64();
            // 返品値引(非課税)
            temp.TotalThisRgdsDisPricTaxFree = reader.ReadInt64();
            // 純売上額(非課税)
            temp.TotalPureSalesTaxFree = reader.ReadInt64();
            // 消費税(非課税)
            temp.TotalSalesPricTaxTaxFree = reader.ReadInt64();
            // 当月合計(非課税)
            temp.TotalAfCalTMonthAccRecTaxFree = reader.ReadInt64();
            // 枚数(非課税)
            temp.TotalSalesSlipCountTaxFree = reader.ReadInt32();
            // --- ADD 2022/10/13 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） -----<<<<<

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
        /// <returns>SumRsltInfo_BillBalanceWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SumRsltInfo_BillBalanceWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                SumRsltInfo_BillBalanceWork temp = GetSumRsltInfo_BillBalanceWork(reader, serInfo);
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
                    retValue = (SumRsltInfo_BillBalanceWork[])lst.ToArray(typeof(SumRsltInfo_BillBalanceWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}

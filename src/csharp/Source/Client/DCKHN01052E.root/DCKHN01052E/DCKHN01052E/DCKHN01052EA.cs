using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
    /// public class name:   UnPrcInfoConf
    /// <summary>
    ///                      単価情報確認
    /// </summary>
    /// <remarks>
    /// <br>note             :   単価情報確認ヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/07/23  (CSharp File Generated Date)</br>
    /// <br>Update Note      : K2014/02/09 yangyi</br>
    /// <br>管理番号         : 10970681-00 前橋京和商会個別個別対応</br>
    /// <br>                 : 売上伝票入力の改良対応</br>
    /// </remarks>
    public class UnPrcInfoConf
    {
        /// <summary>掛率設定区分</summary>
        private string _rateSettingDivide = "";

        /// <summary>拠点コード</summary>
        private string _sectionCode = "";

        /// <summary>得意先コード</summary>
        private Int32 _customerCode;

        /// <summary>得意先略称</summary>
        private string _customerSnm = "";

        /// <summary>仕入先コード</summary>
        private Int32 _supplierCd;

        /// <summary>仕入先略称</summary>
        private string _supplierSnm = "";

        /// <summary>得意先掛率グループコード</summary>
        private Int32 _custRateGrpCode;

        /// <summary>商品メーカーコード</summary>
        private Int32 _goodsMakerCd;

        /// <summary>メーカー名称</summary>
        private string _makerName = "";

        /// <summary>商品番号</summary>
        private string _goodsNo = "";

        /// <summary>商品名称</summary>
        private string _goodsName = "";

        /// <summary>商品掛率ランク</summary>
        /// <remarks>層別</remarks>
        private string _goodsRateRank = "";

        /// <summary>商品掛率グループコード</summary>
        /// <remarks>中分類を使用</remarks>
        private Int32 _goodsRateGrpCode;

        /// <summary>商品掛率グループコード名称</summary>
        /// <remarks>中分類を使用</remarks>
        private string _goodsRateGrpCodeNm = "";

        /// <summary>BLグループコード</summary>
        private Int32 _bLGroupCode;

        /// <summary>BLグループコード名称</summary>
        private string _bLGroupName = "";

        /// <summary>BL商品コード</summary>
        private Int32 _bLGoodsCode;

        /// <summary>BL商品コード名称（全角）</summary>
        private string _bLGoodsFullName = "";

        /// <summary>価格適用日</summary>
        private DateTime _priceApplyDate;

        /// <summary>数量</summary>
        private Double _countFl;

        /// <summary>単価算出区分</summary>
        /// <remarks>1:掛率,2:原価ＵＰ率,3:粗利率</remarks>
        private Int32 _unitPrcCalcDiv;

        /// <summary>掛率</summary>
        /// <remarks>掛率</remarks>
        private Double _rateVal;

        /// <summary>単価端数処理単位</summary>
        private Double _unPrcFracProcUnit;

        /// <summary>単価端数処理区分</summary>
        private Int32 _unPrcFracProcDiv;

        /// <summary>基準単価</summary>
        private Double _stdUnitPrice;

        /// <summary>単価（税抜，浮動）</summary>
        private Double _unitPriceTaxExcFl;

        /// <summary>単価（税込，浮動）</summary>
        private Double _unitPriceTaxIncFl;

        /// <summary>定価（税込，浮動）</summary>
        /// <remarks>税抜き</remarks>
        private Double _listPriceTaxIncFl;

        /// <summary>定価（税抜，浮動）</summary>
        /// <remarks>税込み</remarks>
        private Double _listPriceTaxExcFl;

        /// <summary>原価単価（税込，浮動）</summary>
        private Double _salesUnitCostTaxIncFl;

        /// <summary>原価単価（税抜，浮動）</summary>
        private Double _salesUnitCostTaxExcFl;

        /// <summary>課税区分</summary>
        private Int32 _taxationDivCd;

        /// <summary>消費税端数処理単位</summary>
        private Double _taxFractionProcUnit;

        /// <summary>消費税端数処理区分</summary>
        private Int32 _taxFractionProcCd;

        /// <summary>税率</summary>
        private Double _taxRate;

        /// <summary>総額表示方法区分</summary>
        private Int32 _totalAmountDispWayCd;

        /// <summary>総額表示掛率適用区分</summary>
        private Int32 _ttlAmntDspRateDivCd;

        /// <summary>BL商品コード名称</summary>
        private string _bLGoodsName = "";

        // ----ADD 2013/01/24 鄧潘ハン REDMINE#34605---- >>>>>
        /// <summary>標準価格選択区分</summary>
        /// <remarks>0:優良,1:純正,2:高い方(1:N),,3:高い方(1:1)</remarks>
        private Int32 _priceSelectDiv;

        /// <summary>ガイド名称</summary>
        private string _sectionGuideNm = "";
        // ----ADD 2013/01/24 鄧潘ハン REDMINE#34605---- <<<<<

        // --- ADD yangyi K2014/02/09 ------->>>>>>>>>>>
        /// <summary>掛率更新日</summary>
        private string _rateUpdateTimeSales = "";

        /// <summary>掛率更新日</summary>
        private string _rateUpdateTimeUnit = "";
        // --- ADD yangyi K2014/02/09 -------<<<<<<<<<<<

        /// public propaty name  :  RateSettingDivide
        /// <summary>掛率設定区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   掛率設定区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string RateSettingDivide
        {
            get { return _rateSettingDivide; }
            set { _rateSettingDivide = value; }
        }

        /// public propaty name  :  SectionCode
        /// <summary>拠点コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SectionCode
        {
            get { return _sectionCode; }
            set { _sectionCode = value; }
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

        /// public propaty name  :  CustomerSnm
        /// <summary>得意先略称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先略称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CustomerSnm
        {
            get { return _customerSnm; }
            set { _customerSnm = value; }
        }

        /// public propaty name  :  SupplierCd
        /// <summary>仕入先コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SupplierCd
        {
            get { return _supplierCd; }
            set { _supplierCd = value; }
        }

        /// public propaty name  :  SupplierSnm
        /// <summary>仕入先略称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先略称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SupplierSnm
        {
            get { return _supplierSnm; }
            set { _supplierSnm = value; }
        }

        /// public propaty name  :  CustRateGrpCode
        /// <summary>得意先掛率グループコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先掛率グループコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CustRateGrpCode
        {
            get { return _custRateGrpCode; }
            set { _custRateGrpCode = value; }
        }

        /// public propaty name  :  GoodsMakerCd
        /// <summary>商品メーカーコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品メーカーコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsMakerCd
        {
            get { return _goodsMakerCd; }
            set { _goodsMakerCd = value; }
        }

        /// public propaty name  :  MakerName
        /// <summary>メーカー名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   メーカー名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string MakerName
        {
            get { return _makerName; }
            set { _makerName = value; }
        }

        /// public propaty name  :  GoodsNo
        /// <summary>商品番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsNo
        {
            get { return _goodsNo; }
            set { _goodsNo = value; }
        }

        /// public propaty name  :  GoodsName
        /// <summary>商品名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsName
        {
            get { return _goodsName; }
            set { _goodsName = value; }
        }

        /// public propaty name  :  GoodsRateRank
        /// <summary>商品掛率ランクプロパティ</summary>
        /// <value>層別</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品掛率ランクプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsRateRank
        {
            get { return _goodsRateRank; }
            set { _goodsRateRank = value; }
        }

        /// public propaty name  :  GoodsRateGrpCode
        /// <summary>商品掛率グループコードプロパティ</summary>
        /// <value>中分類を使用</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品掛率グループコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsRateGrpCode
        {
            get { return _goodsRateGrpCode; }
            set { _goodsRateGrpCode = value; }
        }

        /// public propaty name  :  GoodsRateGrpCodeNm
        /// <summary>商品掛率グループコード名称プロパティ</summary>
        /// <value>中分類を使用</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品掛率グループコード名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsRateGrpCodeNm
        {
            get { return _goodsRateGrpCodeNm; }
            set { _goodsRateGrpCodeNm = value; }
        }

        /// public propaty name  :  BLGroupCode
        /// <summary>BLグループコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BLグループコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BLGroupCode
        {
            get { return _bLGroupCode; }
            set { _bLGroupCode = value; }
        }

        /// public propaty name  :  BLGroupName
        /// <summary>BLグループコード名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BLグループコード名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string BLGroupName
        {
            get { return _bLGroupName; }
            set { _bLGroupName = value; }
        }

        /// public propaty name  :  BLGoodsCode
        /// <summary>BL商品コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL商品コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BLGoodsCode
        {
            get { return _bLGoodsCode; }
            set { _bLGoodsCode = value; }
        }

        /// public propaty name  :  BLGoodsFullName
        /// <summary>BL商品コード名称（全角）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL商品コード名称（全角）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string BLGoodsFullName
        {
            get { return _bLGoodsFullName; }
            set { _bLGoodsFullName = value; }
        }

        /// public propaty name  :  PriceApplyDate
        /// <summary>価格適用日プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   価格適用日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime PriceApplyDate
        {
            get { return _priceApplyDate; }
            set { _priceApplyDate = value; }
        }

        /// public propaty name  :  CountFl
        /// <summary>数量プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   数量プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double CountFl
        {
            get { return _countFl; }
            set { _countFl = value; }
        }

        /// public propaty name  :  UnitPrcCalcDiv
        /// <summary>単価算出区分プロパティ</summary>
        /// <value>1:掛率,2:原価ＵＰ率,3:粗利率</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   単価算出区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 UnitPrcCalcDiv
        {
            get { return _unitPrcCalcDiv; }
            set { _unitPrcCalcDiv = value; }
        }

        /// public propaty name  :  RateVal
        /// <summary>掛率プロパティ</summary>
        /// <value>掛率</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   掛率プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double RateVal
        {
            get { return _rateVal; }
            set { _rateVal = value; }
        }

        /// public propaty name  :  UnPrcFracProcUnit
        /// <summary>単価端数処理単位プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   単価端数処理単位プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double UnPrcFracProcUnit
        {
            get { return _unPrcFracProcUnit; }
            set { _unPrcFracProcUnit = value; }
        }

        /// public propaty name  :  UnPrcFracProcDiv
        /// <summary>単価端数処理区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   単価端数処理区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 UnPrcFracProcDiv
        {
            get { return _unPrcFracProcDiv; }
            set { _unPrcFracProcDiv = value; }
        }

        /// public propaty name  :  StdUnitPrice
        /// <summary>基準単価プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   基準単価プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double StdUnitPrice
        {
            get { return _stdUnitPrice; }
            set { _stdUnitPrice = value; }
        }

        /// public propaty name  :  UnitPriceTaxExcFl
        /// <summary>単価（税抜，浮動）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   単価（税抜，浮動）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double UnitPriceTaxExcFl
        {
            get { return _unitPriceTaxExcFl; }
            set { _unitPriceTaxExcFl = value; }
        }

        /// public propaty name  :  UnitPriceTaxIncFl
        /// <summary>単価（税込，浮動）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   単価（税込，浮動）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double UnitPriceTaxIncFl
        {
            get { return _unitPriceTaxIncFl; }
            set { _unitPriceTaxIncFl = value; }
        }

        /// public propaty name  :  ListPriceTaxIncFl
        /// <summary>定価（税込，浮動）プロパティ</summary>
        /// <value>税抜き</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   定価（税込，浮動）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double ListPriceTaxIncFl
        {
            get { return _listPriceTaxIncFl; }
            set { _listPriceTaxIncFl = value; }
        }

        /// public propaty name  :  ListPriceTaxExcFl
        /// <summary>定価（税抜，浮動）プロパティ</summary>
        /// <value>税込み</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   定価（税抜，浮動）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double ListPriceTaxExcFl
        {
            get { return _listPriceTaxExcFl; }
            set { _listPriceTaxExcFl = value; }
        }

        /// public propaty name  :  SalesUnitCostTaxIncFl
        /// <summary>原価単価（税込，浮動）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   原価単価（税込，浮動）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double SalesUnitCostTaxIncFl
        {
            get { return _salesUnitCostTaxIncFl; }
            set { _salesUnitCostTaxIncFl = value; }
        }

        /// public propaty name  :  SalesUnitCostTaxExcFl
        /// <summary>原価単価（税抜，浮動）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   原価単価（税抜，浮動）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double SalesUnitCostTaxExcFl
        {
            get { return _salesUnitCostTaxExcFl; }
            set { _salesUnitCostTaxExcFl = value; }
        }

        /// public propaty name  :  TaxationDivCd
        /// <summary>課税区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   課税区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 TaxationDivCd
        {
            get { return _taxationDivCd; }
            set { _taxationDivCd = value; }
        }

        /// public propaty name  :  TaxFractionProcUnit
        /// <summary>消費税端数処理単位プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   消費税端数処理単位プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double TaxFractionProcUnit
        {
            get { return _taxFractionProcUnit; }
            set { _taxFractionProcUnit = value; }
        }

        /// public propaty name  :  TaxFractionProcCd
        /// <summary>消費税端数処理区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   消費税端数処理区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 TaxFractionProcCd
        {
            get { return _taxFractionProcCd; }
            set { _taxFractionProcCd = value; }
        }

        /// public propaty name  :  TaxRate
        /// <summary>税率プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   税率プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double TaxRate
        {
            get { return _taxRate; }
            set { _taxRate = value; }
        }

        /// public propaty name  :  TotalAmountDispWayCd
        /// <summary>総額表示方法区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   総額表示方法区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 TotalAmountDispWayCd
        {
            get { return _totalAmountDispWayCd; }
            set { _totalAmountDispWayCd = value; }
        }

        /// public propaty name  :  TtlAmntDspRateDivCd
        /// <summary>総額表示掛率適用区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   総額表示掛率適用区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 TtlAmntDspRateDivCd
        {
            get { return _ttlAmntDspRateDivCd; }
            set { _ttlAmntDspRateDivCd = value; }
        }

        /// public propaty name  :  BLGoodsName
        /// <summary>BL商品コード名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL商品コード名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string BLGoodsName
        {
            get { return _bLGoodsName; }
            set { _bLGoodsName = value; }
        }

        // ----ADD 2013/01/24 鄧潘ハン REDMINE#34605---- >>>>>
        /// public propaty name  :  PriceSelectDiv
        /// <summary>標準価格選択区分プロパティ</summary>
        /// <value>0:優良,1:純正,2:高い方(1:N),,3:高い方(1:1)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   標準価格選択区分プロパティ</br>
        /// <br>Programer        :   鄧潘ハン</br>
        /// </remarks>
        public Int32 PriceSelectDiv
        {
            get { return _priceSelectDiv; }
            set { _priceSelectDiv = value; }
        }

        /// public propaty name  :  SectionGuideNm 
        /// <summary>ガイド名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ガイド名称プロパティ</br>
        /// <br>Programer        :   鄧潘ハン</br>
        /// </remarks>
        public string SectionGuideNm
        {
            get { return _sectionGuideNm; }
            set { _sectionGuideNm = value; }
        }
        // ----ADD 2013/01/24 鄧潘ハン REDMINE#34605---- <<<<<

        // --- ADD yangyi K2014/02/09 ------->>>>>>>>>>>
        /// public propaty name  :  RateUpdateTimeSales 
        /// <summary>掛率更新日（原単価）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ガイド名称プロパティ</br>
        /// <br>Programer        :   鄧潘ハン</br>
        /// </remarks>
        public string RateUpdateTimeSales
        {
            get { return _rateUpdateTimeSales; }
            set { _rateUpdateTimeSales = value; }
        }

        /// public propaty name  :  RateUpdateTimeUnit 
        /// <summary>掛率更新日（売単価）</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ガイド名称プロパティ</br>
        /// <br>Programer        :   鄧潘ハン</br>
        /// </remarks>
        public string RateUpdateTimeUnit
        {
            get { return _rateUpdateTimeUnit; }
            set { _rateUpdateTimeUnit = value; }
        }
        // --- ADD yangyi K2014/02/09 -------<<<<<<<<<<<

        /// <summary>
        /// 単価情報確認コンストラクタ
        /// </summary>
        /// <returns>UnPrcInfoConfクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   UnPrcInfoConfクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public UnPrcInfoConf()
        {
        }

        /// <summary>
        /// 単価情報確認コンストラクタ
        /// </summary>
        /// <param name="rateSettingDivide">掛率設定区分</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="customerCode">得意先コード</param>
        /// <param name="customerSnm">得意先略称</param>
        /// <param name="supplierCd">仕入先コード</param>
        /// <param name="supplierSnm">仕入先略称</param>
        /// <param name="custRateGrpCode">得意先掛率グループコード</param>
        /// <param name="goodsMakerCd">商品メーカーコード</param>
        /// <param name="makerName">メーカー名称</param>
        /// <param name="goodsNo">商品番号</param>
        /// <param name="goodsName">商品名称</param>
        /// <param name="goodsRateRank">商品掛率ランク(層別)</param>
        /// <param name="goodsRateGrpCode">商品掛率グループコード(中分類を使用)</param>
        /// <param name="goodsRateGrpCodeNm">商品掛率グループコード名称(中分類を使用)</param>
        /// <param name="bLGroupCode">BLグループコード</param>
        /// <param name="bLGroupName">BLグループコード名称</param>
        /// <param name="bLGoodsCode">BL商品コード</param>
        /// <param name="bLGoodsFullName">BL商品コード名称（全角）</param>
        /// <param name="priceApplyDate">価格適用日</param>
        /// <param name="countFl">数量</param>
        /// <param name="unitPrcCalcDiv">単価算出区分(1:掛率,2:原価ＵＰ率,3:粗利率)</param>
        /// <param name="rateVal">掛率(掛率)</param>
        /// <param name="unPrcFracProcUnit">単価端数処理単位</param>
        /// <param name="unPrcFracProcDiv">単価端数処理区分</param>
        /// <param name="stdUnitPrice">基準単価</param>
        /// <param name="unitPriceTaxExcFl">単価（税抜，浮動）</param>
        /// <param name="unitPriceTaxIncFl">単価（税込，浮動）</param>
        /// <param name="listPriceTaxIncFl">定価（税込，浮動）(税抜き)</param>
        /// <param name="listPriceTaxExcFl">定価（税抜，浮動）(税込み)</param>
        /// <param name="salesUnitCostTaxIncFl">原価単価（税込，浮動）</param>
        /// <param name="salesUnitCostTaxExcFl">原価単価（税抜，浮動）</param>
        /// <param name="taxationDivCd">課税区分</param>
        /// <param name="taxFractionProcUnit">消費税端数処理単位</param>
        /// <param name="taxFractionProcCd">消費税端数処理区分</param>
        /// <param name="taxRate">税率</param>
        /// <param name="totalAmountDispWayCd">総額表示方法区分</param>
        /// <param name="ttlAmntDspRateDivCd">総額表示掛率適用区分</param>
        /// <param name="bLGoodsName">BL商品コード名称</param>
        /// <param name="priceSelectDiv">標準価格選択区分</param>// ADD 2013/01/24 鄧潘ハン REDMINE#34605
        /// <param name="sectionGuideNm">ガイド名称</param>// ADD 2013/01/24 鄧潘ハン REDMINE#34605
        /// <param name="rateUpdateTimeSales">掛率更新日（原単価）</param>//ADD yangyi K2014/02/09
        /// <param name="rateUpdateTimeUnit">掛率更新日（売単価）</param>//ADD yangyi K2014/02/09 
        /// <returns>UnPrcInfoConfクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   UnPrcInfoConfクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        //public UnPrcInfoConf( string rateSettingDivide, string sectionCode, Int32 customerCode, string customerSnm, Int32 supplierCd, string supplierSnm, Int32 custRateGrpCode, Int32 goodsMakerCd, string makerName, string goodsNo, string goodsName, string goodsRateRank, Int32 goodsRateGrpCode, string goodsRateGrpCodeNm, Int32 bLGroupCode, string bLGroupName, Int32 bLGoodsCode, string bLGoodsFullName, DateTime priceApplyDate, Double countFl, Int32 unitPrcCalcDiv, Double rateVal, Double unPrcFracProcUnit, Int32 unPrcFracProcDiv, Double stdUnitPrice, Double unitPriceTaxExcFl, Double unitPriceTaxIncFl, Double listPriceTaxIncFl, Double listPriceTaxExcFl, Double salesUnitCostTaxIncFl, Double salesUnitCostTaxExcFl, Int32 taxationDivCd, Double taxFractionProcUnit, Int32 taxFractionProcCd, Double taxRate, Int32 totalAmountDispWayCd, Int32 ttlAmntDspRateDivCd, string bLGoodsName )// DEL 2013/01/24 鄧潘ハン REDMINE#34605  
        //public UnPrcInfoConf(string rateSettingDivide, string sectionCode, Int32 customerCode, string customerSnm, Int32 supplierCd, string supplierSnm, Int32 custRateGrpCode, Int32 goodsMakerCd, string makerName, string goodsNo, string goodsName, string goodsRateRank, Int32 goodsRateGrpCode, string goodsRateGrpCodeNm, Int32 bLGroupCode, string bLGroupName, Int32 bLGoodsCode, string bLGoodsFullName, DateTime priceApplyDate, Double countFl, Int32 unitPrcCalcDiv, Double rateVal, Double unPrcFracProcUnit, Int32 unPrcFracProcDiv, Double stdUnitPrice, Double unitPriceTaxExcFl, Double unitPriceTaxIncFl, Double listPriceTaxIncFl, Double listPriceTaxExcFl, Double salesUnitCostTaxIncFl, Double salesUnitCostTaxExcFl, Int32 taxationDivCd, Double taxFractionProcUnit, Int32 taxFractionProcCd, Double taxRate, Int32 totalAmountDispWayCd, Int32 ttlAmntDspRateDivCd, string bLGoodsName, Int32 priceSelectDiv, string sectionGuideNm)// ADD 2013/01/24 鄧潘ハン REDMINE#34605    //DEL yangyi K2014/02/09 
        public UnPrcInfoConf(string rateSettingDivide, string sectionCode, Int32 customerCode, string customerSnm, Int32 supplierCd, string supplierSnm, Int32 custRateGrpCode, Int32 goodsMakerCd, string makerName, string goodsNo, string goodsName, string goodsRateRank, Int32 goodsRateGrpCode, string goodsRateGrpCodeNm, Int32 bLGroupCode, string bLGroupName, Int32 bLGoodsCode, string bLGoodsFullName, DateTime priceApplyDate, Double countFl, Int32 unitPrcCalcDiv, Double rateVal, Double unPrcFracProcUnit, Int32 unPrcFracProcDiv, Double stdUnitPrice, Double unitPriceTaxExcFl, Double unitPriceTaxIncFl, Double listPriceTaxIncFl, Double listPriceTaxExcFl, Double salesUnitCostTaxIncFl, Double salesUnitCostTaxExcFl, Int32 taxationDivCd, Double taxFractionProcUnit, Int32 taxFractionProcCd, Double taxRate, Int32 totalAmountDispWayCd, Int32 ttlAmntDspRateDivCd, string bLGoodsName, Int32 priceSelectDiv, string sectionGuideNm, string rateUpdateTimeSales, string rateUpdateTimeUnit)// ADD 2013/01/24 鄧潘ハン REDMINE#34605   //ADD yangyi K2014/02/09   
       {
            this._rateSettingDivide = rateSettingDivide;
            this._sectionCode = sectionCode;
            this._customerCode = customerCode;
            this._customerSnm = customerSnm;
            this._supplierCd = supplierCd;
            this._supplierSnm = supplierSnm;
            this._custRateGrpCode = custRateGrpCode;
            this._goodsMakerCd = goodsMakerCd;
            this._makerName = makerName;
            this._goodsNo = goodsNo;
            this._goodsName = goodsName;
            this._goodsRateRank = goodsRateRank;
            this._goodsRateGrpCode = goodsRateGrpCode;
            this._goodsRateGrpCodeNm = goodsRateGrpCodeNm;
            this._bLGroupCode = bLGroupCode;
            this._bLGroupName = bLGroupName;
            this._bLGoodsCode = bLGoodsCode;
            this._bLGoodsFullName = bLGoodsFullName;
            this._priceApplyDate = priceApplyDate;
            this._countFl = countFl;
            this._unitPrcCalcDiv = unitPrcCalcDiv;
            this._rateVal = rateVal;
            this._unPrcFracProcUnit = unPrcFracProcUnit;
            this._unPrcFracProcDiv = unPrcFracProcDiv;
            this._stdUnitPrice = stdUnitPrice;
            this._unitPriceTaxExcFl = unitPriceTaxExcFl;
            this._unitPriceTaxIncFl = unitPriceTaxIncFl;
            this._listPriceTaxIncFl = listPriceTaxIncFl;
            this._listPriceTaxExcFl = listPriceTaxExcFl;
            this._salesUnitCostTaxIncFl = salesUnitCostTaxIncFl;
            this._salesUnitCostTaxExcFl = salesUnitCostTaxExcFl;
            this._taxationDivCd = taxationDivCd;
            this._taxFractionProcUnit = taxFractionProcUnit;
            this._taxFractionProcCd = taxFractionProcCd;
            this._taxRate = taxRate;
            this._totalAmountDispWayCd = totalAmountDispWayCd;
            this._ttlAmntDspRateDivCd = ttlAmntDspRateDivCd;
            this._bLGoodsName = bLGoodsName;
            // ----ADD 2013/01/24 鄧潘ハン REDMINE#34605-------- >>>>>
            this._priceSelectDiv = priceSelectDiv;
            this._sectionGuideNm = sectionGuideNm;
            // ----ADD 2013/01/24 鄧潘ハン REDMINE#34605-------- <<<<<
            this._rateUpdateTimeSales = rateUpdateTimeSales;
            this._rateUpdateTimeUnit = rateUpdateTimeUnit;

        }

        /// <summary>
        /// 単価情報確認複製処理
        /// </summary>
        /// <returns>UnPrcInfoConfクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいUnPrcInfoConfクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public UnPrcInfoConf Clone()
        {
            //return new UnPrcInfoConf(this._rateSettingDivide, this._sectionCode, this._customerCode, this._customerSnm, this._supplierCd, this._supplierSnm, this._custRateGrpCode, this._goodsMakerCd, this._makerName, this._goodsNo, this._goodsName, this._goodsRateRank, this._goodsRateGrpCode, this._goodsRateGrpCodeNm, this._bLGroupCode, this._bLGroupName, this._bLGoodsCode, this._bLGoodsFullName, this._priceApplyDate, this._countFl, this._unitPrcCalcDiv, this._rateVal, this._unPrcFracProcUnit, this._unPrcFracProcDiv, this._stdUnitPrice, this._unitPriceTaxExcFl, this._unitPriceTaxIncFl, this._listPriceTaxIncFl, this._listPriceTaxExcFl, this._salesUnitCostTaxIncFl, this._salesUnitCostTaxExcFl, this._taxationDivCd, this._taxFractionProcUnit, this._taxFractionProcCd, this._taxRate, this._totalAmountDispWayCd, this._ttlAmntDspRateDivCd, this._bLGoodsName);// DEL 2013/01/24 鄧潘ハン REDMINE#34605
            //return new UnPrcInfoConf(this._rateSettingDivide, this._sectionCode, this._customerCode, this._customerSnm, this._supplierCd, this._supplierSnm, this._custRateGrpCode, this._goodsMakerCd, this._makerName, this._goodsNo, this._goodsName, this._goodsRateRank, this._goodsRateGrpCode, this._goodsRateGrpCodeNm, this._bLGroupCode, this._bLGroupName, this._bLGoodsCode, this._bLGoodsFullName, this._priceApplyDate, this._countFl, this._unitPrcCalcDiv, this._rateVal, this._unPrcFracProcUnit, this._unPrcFracProcDiv, this._stdUnitPrice, this._unitPriceTaxExcFl, this._unitPriceTaxIncFl, this._listPriceTaxIncFl, this._listPriceTaxExcFl, this._salesUnitCostTaxIncFl, this._salesUnitCostTaxExcFl, this._taxationDivCd, this._taxFractionProcUnit, this._taxFractionProcCd, this._taxRate, this._totalAmountDispWayCd, this._ttlAmntDspRateDivCd, this._bLGoodsName, this._priceSelectDiv, this._sectionGuideNm);// ADD 2013/01/24 鄧潘ハン REDMINE#34605                 //DEL yangyi K2014/02/09 
            return new UnPrcInfoConf(this._rateSettingDivide, this._sectionCode, this._customerCode, this._customerSnm, this._supplierCd, this._supplierSnm, this._custRateGrpCode, this._goodsMakerCd, this._makerName, this._goodsNo, this._goodsName, this._goodsRateRank, this._goodsRateGrpCode, this._goodsRateGrpCodeNm, this._bLGroupCode, this._bLGroupName, this._bLGoodsCode, this._bLGoodsFullName, this._priceApplyDate, this._countFl, this._unitPrcCalcDiv, this._rateVal, this._unPrcFracProcUnit, this._unPrcFracProcDiv, this._stdUnitPrice, this._unitPriceTaxExcFl, this._unitPriceTaxIncFl, this._listPriceTaxIncFl, this._listPriceTaxExcFl, this._salesUnitCostTaxIncFl, this._salesUnitCostTaxExcFl, this._taxationDivCd, this._taxFractionProcUnit, this._taxFractionProcCd, this._taxRate, this._totalAmountDispWayCd, this._ttlAmntDspRateDivCd, this._bLGoodsName, this._priceSelectDiv, this._sectionGuideNm, this._rateUpdateTimeSales, this._rateUpdateTimeUnit);// ADD 2013/01/24 鄧潘ハン REDMINE#34605  //ADD yangyi K2014/02/09 

        }

        /// <summary>
        /// 単価情報確認比較処理
        /// </summary>
        /// <param name="target">比較対象のUnPrcInfoConfクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   UnPrcInfoConfクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool Equals( UnPrcInfoConf target )
        {
            return ( ( this.RateSettingDivide == target.RateSettingDivide )
                 && ( this.SectionCode == target.SectionCode )
                 && ( this.CustomerCode == target.CustomerCode )
                 && ( this.CustomerSnm == target.CustomerSnm )
                 && ( this.SupplierCd == target.SupplierCd )
                 && ( this.SupplierSnm == target.SupplierSnm )
                 && ( this.CustRateGrpCode == target.CustRateGrpCode )
                 && ( this.GoodsMakerCd == target.GoodsMakerCd )
                 && ( this.MakerName == target.MakerName )
                 && ( this.GoodsNo == target.GoodsNo )
                 && ( this.GoodsName == target.GoodsName )
                 && ( this.GoodsRateRank == target.GoodsRateRank )
                 && ( this.GoodsRateGrpCode == target.GoodsRateGrpCode )
                 && ( this.GoodsRateGrpCodeNm == target.GoodsRateGrpCodeNm )
                 && ( this.BLGroupCode == target.BLGroupCode )
                 && ( this.BLGroupName == target.BLGroupName )
                 && ( this.BLGoodsCode == target.BLGoodsCode )
                 && ( this.BLGoodsFullName == target.BLGoodsFullName )
                 && ( this.PriceApplyDate == target.PriceApplyDate )
                 && ( this.CountFl == target.CountFl )
                 && ( this.UnitPrcCalcDiv == target.UnitPrcCalcDiv )
                 && ( this.RateVal == target.RateVal )
                 && ( this.UnPrcFracProcUnit == target.UnPrcFracProcUnit )
                 && ( this.UnPrcFracProcDiv == target.UnPrcFracProcDiv )
                 && ( this.StdUnitPrice == target.StdUnitPrice )
                 && ( this.UnitPriceTaxExcFl == target.UnitPriceTaxExcFl )
                 && ( this.UnitPriceTaxIncFl == target.UnitPriceTaxIncFl )
                 && ( this.ListPriceTaxIncFl == target.ListPriceTaxIncFl )
                 && ( this.ListPriceTaxExcFl == target.ListPriceTaxExcFl )
                 && ( this.SalesUnitCostTaxIncFl == target.SalesUnitCostTaxIncFl )
                 && ( this.SalesUnitCostTaxExcFl == target.SalesUnitCostTaxExcFl )
                 && ( this.TaxationDivCd == target.TaxationDivCd )
                 && ( this.TaxFractionProcUnit == target.TaxFractionProcUnit )
                 && ( this.TaxFractionProcCd == target.TaxFractionProcCd )
                 && ( this.TaxRate == target.TaxRate )
                 && ( this.TotalAmountDispWayCd == target.TotalAmountDispWayCd )
                 && ( this.TtlAmntDspRateDivCd == target.TtlAmntDspRateDivCd )
                 && ( this.BLGoodsName == target.BLGoodsName )
                 // ----ADD 2013/01/24 鄧潘ハン REDMINE#34605-------- >>>>>
                 && ( this.PriceSelectDiv == target.PriceSelectDiv)
                 && ( this.SectionGuideNm == target.SectionGuideNm)
                 // ----ADD 2013/01/24 鄧潘ハン REDMINE#34605-------- <<<<<
                 && (this.RateUpdateTimeSales == target.RateUpdateTimeSales)  //ADD yangyi K2014/02/09
                 && (this.RateUpdateTimeUnit == target.RateUpdateTimeUnit));  //ADD yangyi K2014/02/09
        }

        /// <summary>
        /// 単価情報確認比較処理
        /// </summary>
        /// <param name="unPrcInfoConf1">
        ///                    比較するUnPrcInfoConfクラスのインスタンス
        /// </param>
        /// <param name="unPrcInfoConf2">比較するUnPrcInfoConfクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   UnPrcInfoConfクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static bool Equals( UnPrcInfoConf unPrcInfoConf1, UnPrcInfoConf unPrcInfoConf2 )
        {
            return ( ( unPrcInfoConf1.RateSettingDivide == unPrcInfoConf2.RateSettingDivide )
                 && ( unPrcInfoConf1.SectionCode == unPrcInfoConf2.SectionCode )
                 && ( unPrcInfoConf1.CustomerCode == unPrcInfoConf2.CustomerCode )
                 && ( unPrcInfoConf1.CustomerSnm == unPrcInfoConf2.CustomerSnm )
                 && ( unPrcInfoConf1.SupplierCd == unPrcInfoConf2.SupplierCd )
                 && ( unPrcInfoConf1.SupplierSnm == unPrcInfoConf2.SupplierSnm )
                 && ( unPrcInfoConf1.CustRateGrpCode == unPrcInfoConf2.CustRateGrpCode )
                 && ( unPrcInfoConf1.GoodsMakerCd == unPrcInfoConf2.GoodsMakerCd )
                 && ( unPrcInfoConf1.MakerName == unPrcInfoConf2.MakerName )
                 && ( unPrcInfoConf1.GoodsNo == unPrcInfoConf2.GoodsNo )
                 && ( unPrcInfoConf1.GoodsName == unPrcInfoConf2.GoodsName )
                 && ( unPrcInfoConf1.GoodsRateRank == unPrcInfoConf2.GoodsRateRank )
                 && ( unPrcInfoConf1.GoodsRateGrpCode == unPrcInfoConf2.GoodsRateGrpCode )
                 && ( unPrcInfoConf1.GoodsRateGrpCodeNm == unPrcInfoConf2.GoodsRateGrpCodeNm )
                 && ( unPrcInfoConf1.BLGroupCode == unPrcInfoConf2.BLGroupCode )
                 && ( unPrcInfoConf1.BLGroupName == unPrcInfoConf2.BLGroupName )
                 && ( unPrcInfoConf1.BLGoodsCode == unPrcInfoConf2.BLGoodsCode )
                 && ( unPrcInfoConf1.BLGoodsFullName == unPrcInfoConf2.BLGoodsFullName )
                 && ( unPrcInfoConf1.PriceApplyDate == unPrcInfoConf2.PriceApplyDate )
                 && ( unPrcInfoConf1.CountFl == unPrcInfoConf2.CountFl )
                 && ( unPrcInfoConf1.UnitPrcCalcDiv == unPrcInfoConf2.UnitPrcCalcDiv )
                 && ( unPrcInfoConf1.RateVal == unPrcInfoConf2.RateVal )
                 && ( unPrcInfoConf1.UnPrcFracProcUnit == unPrcInfoConf2.UnPrcFracProcUnit )
                 && ( unPrcInfoConf1.UnPrcFracProcDiv == unPrcInfoConf2.UnPrcFracProcDiv )
                 && ( unPrcInfoConf1.StdUnitPrice == unPrcInfoConf2.StdUnitPrice )
                 && ( unPrcInfoConf1.UnitPriceTaxExcFl == unPrcInfoConf2.UnitPriceTaxExcFl )
                 && ( unPrcInfoConf1.UnitPriceTaxIncFl == unPrcInfoConf2.UnitPriceTaxIncFl )
                 && ( unPrcInfoConf1.ListPriceTaxIncFl == unPrcInfoConf2.ListPriceTaxIncFl )
                 && ( unPrcInfoConf1.ListPriceTaxExcFl == unPrcInfoConf2.ListPriceTaxExcFl )
                 && ( unPrcInfoConf1.SalesUnitCostTaxIncFl == unPrcInfoConf2.SalesUnitCostTaxIncFl )
                 && ( unPrcInfoConf1.SalesUnitCostTaxExcFl == unPrcInfoConf2.SalesUnitCostTaxExcFl )
                 && ( unPrcInfoConf1.TaxationDivCd == unPrcInfoConf2.TaxationDivCd )
                 && ( unPrcInfoConf1.TaxFractionProcUnit == unPrcInfoConf2.TaxFractionProcUnit )
                 && ( unPrcInfoConf1.TaxFractionProcCd == unPrcInfoConf2.TaxFractionProcCd )
                 && ( unPrcInfoConf1.TaxRate == unPrcInfoConf2.TaxRate )
                 && ( unPrcInfoConf1.TotalAmountDispWayCd == unPrcInfoConf2.TotalAmountDispWayCd )
                 && ( unPrcInfoConf1.TtlAmntDspRateDivCd == unPrcInfoConf2.TtlAmntDspRateDivCd )
                 && ( unPrcInfoConf1.BLGoodsName == unPrcInfoConf2.BLGoodsName )
                 // ----ADD 2013/01/24 鄧潘ハン REDMINE#34605-------- >>>>>
                 && (unPrcInfoConf1.PriceSelectDiv == unPrcInfoConf2.PriceSelectDiv)
                 && (unPrcInfoConf1.SectionGuideNm == unPrcInfoConf2.SectionGuideNm)
                 // ----ADD 2013/01/24 鄧潘ハン REDMINE#34605-------- <<<<<
                 && (unPrcInfoConf1.RateUpdateTimeSales == unPrcInfoConf2.RateUpdateTimeSales) //ADD yangyi K2014/02/09
                 && (unPrcInfoConf1.RateUpdateTimeUnit == unPrcInfoConf2.RateUpdateTimeUnit)); //ADD yangyi K2014/02/09
        }
        /// <summary>
        /// 単価情報確認比較処理
        /// </summary>
        /// <param name="target">比較対象のUnPrcInfoConfクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   UnPrcInfoConfクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ArrayList Compare( UnPrcInfoConf target )
        {
            ArrayList resList = new ArrayList();
            if (this.RateSettingDivide != target.RateSettingDivide) resList.Add("RateSettingDivide");
            if (this.SectionCode != target.SectionCode) resList.Add("SectionCode");
            if (this.CustomerCode != target.CustomerCode) resList.Add("CustomerCode");
            if (this.CustomerSnm != target.CustomerSnm) resList.Add("CustomerSnm");
            if (this.SupplierCd != target.SupplierCd) resList.Add("SupplierCd");
            if (this.SupplierSnm != target.SupplierSnm) resList.Add("SupplierSnm");
            if (this.CustRateGrpCode != target.CustRateGrpCode) resList.Add("CustRateGrpCode");
            if (this.GoodsMakerCd != target.GoodsMakerCd) resList.Add("GoodsMakerCd");
            if (this.MakerName != target.MakerName) resList.Add("MakerName");
            if (this.GoodsNo != target.GoodsNo) resList.Add("GoodsNo");
            if (this.GoodsName != target.GoodsName) resList.Add("GoodsName");
            if (this.GoodsRateRank != target.GoodsRateRank) resList.Add("GoodsRateRank");
            if (this.GoodsRateGrpCode != target.GoodsRateGrpCode) resList.Add("GoodsRateGrpCode");
            if (this.GoodsRateGrpCodeNm != target.GoodsRateGrpCodeNm) resList.Add("GoodsRateGrpCodeNm");
            if (this.BLGroupCode != target.BLGroupCode) resList.Add("BLGroupCode");
            if (this.BLGroupName != target.BLGroupName) resList.Add("BLGroupName");
            if (this.BLGoodsCode != target.BLGoodsCode) resList.Add("BLGoodsCode");
            if (this.BLGoodsFullName != target.BLGoodsFullName) resList.Add("BLGoodsFullName");
            if (this.PriceApplyDate != target.PriceApplyDate) resList.Add("PriceApplyDate");
            if (this.CountFl != target.CountFl) resList.Add("CountFl");
            if (this.UnitPrcCalcDiv != target.UnitPrcCalcDiv) resList.Add("UnitPrcCalcDiv");
            if (this.RateVal != target.RateVal) resList.Add("RateVal");
            if (this.UnPrcFracProcUnit != target.UnPrcFracProcUnit) resList.Add("UnPrcFracProcUnit");
            if (this.UnPrcFracProcDiv != target.UnPrcFracProcDiv) resList.Add("UnPrcFracProcDiv");
            if (this.StdUnitPrice != target.StdUnitPrice) resList.Add("StdUnitPrice");
            if (this.UnitPriceTaxExcFl != target.UnitPriceTaxExcFl) resList.Add("UnitPriceTaxExcFl");
            if (this.UnitPriceTaxIncFl != target.UnitPriceTaxIncFl) resList.Add("UnitPriceTaxIncFl");
            if (this.ListPriceTaxIncFl != target.ListPriceTaxIncFl) resList.Add("ListPriceTaxIncFl");
            if (this.ListPriceTaxExcFl != target.ListPriceTaxExcFl) resList.Add("ListPriceTaxExcFl");
            if (this.SalesUnitCostTaxIncFl != target.SalesUnitCostTaxIncFl) resList.Add("SalesUnitCostTaxIncFl");
            if (this.SalesUnitCostTaxExcFl != target.SalesUnitCostTaxExcFl) resList.Add("SalesUnitCostTaxExcFl");
            if (this.TaxationDivCd != target.TaxationDivCd) resList.Add("TaxationDivCd");
            if (this.TaxFractionProcUnit != target.TaxFractionProcUnit) resList.Add("TaxFractionProcUnit");
            if (this.TaxFractionProcCd != target.TaxFractionProcCd) resList.Add("TaxFractionProcCd");
            if (this.TaxRate != target.TaxRate) resList.Add("TaxRate");
            if (this.TotalAmountDispWayCd != target.TotalAmountDispWayCd) resList.Add("TotalAmountDispWayCd");
            if (this.TtlAmntDspRateDivCd != target.TtlAmntDspRateDivCd) resList.Add("TtlAmntDspRateDivCd");
            if (this.BLGoodsName != target.BLGoodsName) resList.Add("BLGoodsName");
            // ----ADD 2013/01/24 鄧潘ハン REDMINE#34605-------- >>>>>
            if (this.PriceSelectDiv != target.PriceSelectDiv) resList.Add("PriceSelectDiv");
            if (this.SectionGuideNm != target.SectionGuideNm) resList.Add("SectionGuideNm");
            // ----ADD 2013/01/24 鄧潘ハン REDMINE#34605-------- <<<<<
            if (this.RateUpdateTimeSales != target.RateUpdateTimeSales) resList.Add("RateUpdateTimeSales"); //ADD yangyi K2014/02/09
            if (this.RateUpdateTimeUnit != target.RateUpdateTimeUnit) resList.Add("RateUpdateTimeUnit"); //ADD yangyi K2014/02/09

            return resList;
        }

        /// <summary>
        /// 単価情報確認比較処理
        /// </summary>
        /// <param name="unPrcInfoConf1">比較するUnPrcInfoConfクラスのインスタンス</param>
        /// <param name="unPrcInfoConf2">比較するUnPrcInfoConfクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   UnPrcInfoConfクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static ArrayList Compare( UnPrcInfoConf unPrcInfoConf1, UnPrcInfoConf unPrcInfoConf2 )
        {
            ArrayList resList = new ArrayList();
            if (unPrcInfoConf1.RateSettingDivide != unPrcInfoConf2.RateSettingDivide) resList.Add("RateSettingDivide");
            if (unPrcInfoConf1.SectionCode != unPrcInfoConf2.SectionCode) resList.Add("SectionCode");
            if (unPrcInfoConf1.CustomerCode != unPrcInfoConf2.CustomerCode) resList.Add("CustomerCode");
            if (unPrcInfoConf1.CustomerSnm != unPrcInfoConf2.CustomerSnm) resList.Add("CustomerSnm");
            if (unPrcInfoConf1.SupplierCd != unPrcInfoConf2.SupplierCd) resList.Add("SupplierCd");
            if (unPrcInfoConf1.SupplierSnm != unPrcInfoConf2.SupplierSnm) resList.Add("SupplierSnm");
            if (unPrcInfoConf1.CustRateGrpCode != unPrcInfoConf2.CustRateGrpCode) resList.Add("CustRateGrpCode");
            if (unPrcInfoConf1.GoodsMakerCd != unPrcInfoConf2.GoodsMakerCd) resList.Add("GoodsMakerCd");
            if (unPrcInfoConf1.MakerName != unPrcInfoConf2.MakerName) resList.Add("MakerName");
            if (unPrcInfoConf1.GoodsNo != unPrcInfoConf2.GoodsNo) resList.Add("GoodsNo");
            if (unPrcInfoConf1.GoodsName != unPrcInfoConf2.GoodsName) resList.Add("GoodsName");
            if (unPrcInfoConf1.GoodsRateRank != unPrcInfoConf2.GoodsRateRank) resList.Add("GoodsRateRank");
            if (unPrcInfoConf1.GoodsRateGrpCode != unPrcInfoConf2.GoodsRateGrpCode) resList.Add("GoodsRateGrpCode");
            if (unPrcInfoConf1.GoodsRateGrpCodeNm != unPrcInfoConf2.GoodsRateGrpCodeNm) resList.Add("GoodsRateGrpCodeNm");
            if (unPrcInfoConf1.BLGroupCode != unPrcInfoConf2.BLGroupCode) resList.Add("BLGroupCode");
            if (unPrcInfoConf1.BLGroupName != unPrcInfoConf2.BLGroupName) resList.Add("BLGroupName");
            if (unPrcInfoConf1.BLGoodsCode != unPrcInfoConf2.BLGoodsCode) resList.Add("BLGoodsCode");
            if (unPrcInfoConf1.BLGoodsFullName != unPrcInfoConf2.BLGoodsFullName) resList.Add("BLGoodsFullName");
            if (unPrcInfoConf1.PriceApplyDate != unPrcInfoConf2.PriceApplyDate) resList.Add("PriceApplyDate");
            if (unPrcInfoConf1.CountFl != unPrcInfoConf2.CountFl) resList.Add("CountFl");
            if (unPrcInfoConf1.UnitPrcCalcDiv != unPrcInfoConf2.UnitPrcCalcDiv) resList.Add("UnitPrcCalcDiv");
            if (unPrcInfoConf1.RateVal != unPrcInfoConf2.RateVal) resList.Add("RateVal");
            if (unPrcInfoConf1.UnPrcFracProcUnit != unPrcInfoConf2.UnPrcFracProcUnit) resList.Add("UnPrcFracProcUnit");
            if (unPrcInfoConf1.UnPrcFracProcDiv != unPrcInfoConf2.UnPrcFracProcDiv) resList.Add("UnPrcFracProcDiv");
            if (unPrcInfoConf1.StdUnitPrice != unPrcInfoConf2.StdUnitPrice) resList.Add("StdUnitPrice");
            if (unPrcInfoConf1.UnitPriceTaxExcFl != unPrcInfoConf2.UnitPriceTaxExcFl) resList.Add("UnitPriceTaxExcFl");
            if (unPrcInfoConf1.UnitPriceTaxIncFl != unPrcInfoConf2.UnitPriceTaxIncFl) resList.Add("UnitPriceTaxIncFl");
            if (unPrcInfoConf1.ListPriceTaxIncFl != unPrcInfoConf2.ListPriceTaxIncFl) resList.Add("ListPriceTaxIncFl");
            if (unPrcInfoConf1.ListPriceTaxExcFl != unPrcInfoConf2.ListPriceTaxExcFl) resList.Add("ListPriceTaxExcFl");
            if (unPrcInfoConf1.SalesUnitCostTaxIncFl != unPrcInfoConf2.SalesUnitCostTaxIncFl) resList.Add("SalesUnitCostTaxIncFl");
            if (unPrcInfoConf1.SalesUnitCostTaxExcFl != unPrcInfoConf2.SalesUnitCostTaxExcFl) resList.Add("SalesUnitCostTaxExcFl");
            if (unPrcInfoConf1.TaxationDivCd != unPrcInfoConf2.TaxationDivCd) resList.Add("TaxationDivCd");
            if (unPrcInfoConf1.TaxFractionProcUnit != unPrcInfoConf2.TaxFractionProcUnit) resList.Add("TaxFractionProcUnit");
            if (unPrcInfoConf1.TaxFractionProcCd != unPrcInfoConf2.TaxFractionProcCd) resList.Add("TaxFractionProcCd");
            if (unPrcInfoConf1.TaxRate != unPrcInfoConf2.TaxRate) resList.Add("TaxRate");
            if (unPrcInfoConf1.TotalAmountDispWayCd != unPrcInfoConf2.TotalAmountDispWayCd) resList.Add("TotalAmountDispWayCd");
            if (unPrcInfoConf1.TtlAmntDspRateDivCd != unPrcInfoConf2.TtlAmntDspRateDivCd) resList.Add("TtlAmntDspRateDivCd");
            if (unPrcInfoConf1.BLGoodsName != unPrcInfoConf2.BLGoodsName) resList.Add("BLGoodsName");
            // ----ADD 2013/01/24 鄧潘ハン REDMINE#34605-------- >>>>>
            if (unPrcInfoConf1.PriceSelectDiv != unPrcInfoConf2.PriceSelectDiv) resList.Add("PriceSelectDiv");
            if (unPrcInfoConf1.SectionGuideNm != unPrcInfoConf2.SectionGuideNm) resList.Add("SectionGuideNm");
            // ----ADD 2013/01/24 鄧潘ハン REDMINE#34605-------- <<<<<
            if (unPrcInfoConf1.RateUpdateTimeSales != unPrcInfoConf2.RateUpdateTimeSales) resList.Add("RateUpdateTimeSales"); //ADD yangyi K2014/02/09
            if (unPrcInfoConf1.RateUpdateTimeUnit != unPrcInfoConf2.RateUpdateTimeUnit) resList.Add("RateUpdateTimeUnit"); //ADD yangyi K2014/02/09

            return resList;
        }
    }
}

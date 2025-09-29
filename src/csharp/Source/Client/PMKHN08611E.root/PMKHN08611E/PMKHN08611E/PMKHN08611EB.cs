using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
    /// public class name:   GoodsSet
    /// <summary>
    ///                      商品マスタ（印刷）結果クラスワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   商品マスタ（印刷）結果クラスワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/10/24  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks> 
    public class GoodsSet 
    {
        /// <summary>更新日時</summary>
        /// <remarks>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</remarks>
        private DateTime _updateDateTime;

        /// <summary>商品メーカーコード</summary>
        private Int32 _goodsMakerCd;

        /// <summary>メーカー略称</summary>
        private string _makerShortName = "";

        /// <summary>商品番号</summary>
        private string _goodsNo = "";

        /// <summary>BL商品コード</summary>
        private Int32 _bLGoodsCode;

        /// <summary>商品名称</summary>
        private string _goodsName = "";

        /// <summary>仕入先コード</summary>
        private Int32 _supplierCd;

        /// <summary>仕入先略称</summary>
        private string _supplierSnm = "";

        /// <summary>標準価格</summary>
        /// <remarks>定価（浮動）</remarks>
        private Double _listPrice;

        /// <summary>仕入率</summary>
        private Double _stockRate;

        /// <summary>原価単価</summary>
        private Double _salesUnitCost;

        /// <summary>層別</summary>
        /// <remarks>商品掛率ランク</remarks>
        private string _goodsRateRank = "";

        /// <summary>発注ロット</summary>
        private Int32 _supplierLot;

        /// <summary>商品規格・特記事項</summary>
        private string _goodsSpecialNote = "";

        /// <summary>商品備考１</summary>
        private string _goodsNote1 = "";

        /// <summary>商品備考２</summary>
        private string _goodsNote2 = "";

        /// <summary>適用日</summary>
        /// <remarks>価格開始日 YYYYMMDD</remarks>
        private DateTime _priceStartDate;

        /// <summary>新適用価格</summary>
        /// <remarks>定価（浮動）</remarks>
        private Double _newListPrice;

        /// <summary>純優区分</summary>
        /// <remarks>商品属性 0:純正 1:その他</remarks>
        private Int32 _goodsKindCode;

        /// <summary>課税区分</summary>
        /// <remarks>0:課税 1:非課税 2:課税（内税）</remarks>
        private Int32 _taxationDivCd;

        /// <summary>商品区分</summary>
        /// <remarks>自社分類コード</remarks>
        private Int32 _enterpriseGanreCode;

        /// <summary>商品区分名称</summary>
        /// <remarks>ユーザーガイド区分名称(自社分類コード)</remarks>
        private string _enterpriseGanreCodeName = "";

        /// <summary>提供データ区分</summary>
        /// <remarks>0:ユーザデータ 1:提供データ</remarks>
        private Int32 _offerDataDiv;

        /// public propaty name  :  UpdateDateTime
        /// <summary>更新日時プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新日時プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime UpdateDateTime
        {
            get { return _updateDateTime; }
            set { _updateDateTime = value; }
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

        /// public propaty name  :  MakerShortName
        /// <summary>メーカー略称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   メーカー略称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string MakerShortName
        {
            get { return _makerShortName; }
            set { _makerShortName = value; }
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

        /// public propaty name  :  ListPrice
        /// <summary>標準価格プロパティ</summary>
        /// <value>定価（浮動）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   標準価格プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double ListPrice
        {
            get { return _listPrice; }
            set { _listPrice = value; }
        }

        /// public propaty name  :  StockRate
        /// <summary>仕入率プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入率プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double StockRate
        {
            get { return _stockRate; }
            set { _stockRate = value; }
        }

        /// public propaty name  :  SalesUnitCost
        /// <summary>原価単価プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   原価単価プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double SalesUnitCost
        {
            get { return _salesUnitCost; }
            set { _salesUnitCost = value; }
        }

        /// public propaty name  :  GoodsRateRank
        /// <summary>層別プロパティ</summary>
        /// <value>商品掛率ランク</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   層別プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsRateRank
        {
            get { return _goodsRateRank; }
            set { _goodsRateRank = value; }
        }

        /// public propaty name  :  SupplierLot
        /// <summary>発注ロットプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   発注ロットプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SupplierLot
        {
            get { return _supplierLot; }
            set { _supplierLot = value; }
        }

        /// public propaty name  :  GoodsSpecialNote
        /// <summary>商品規格・特記事項プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品規格・特記事項プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsSpecialNote
        {
            get { return _goodsSpecialNote; }
            set { _goodsSpecialNote = value; }
        }

        /// public propaty name  :  GoodsNote1
        /// <summary>商品備考１プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品備考１プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsNote1
        {
            get { return _goodsNote1; }
            set { _goodsNote1 = value; }
        }

        /// public propaty name  :  GoodsNote2
        /// <summary>商品備考２プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品備考２プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsNote2
        {
            get { return _goodsNote2; }
            set { _goodsNote2 = value; }
        }

        /// public propaty name  :  PriceStartDate
        /// <summary>適用日プロパティ</summary>
        /// <value>価格開始日 YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   適用日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime PriceStartDate
        {
            get { return _priceStartDate; }
            set { _priceStartDate = value; }
        }

        /// public propaty name  :  NewListPrice
        /// <summary>新適用価格プロパティ</summary>
        /// <value>定価（浮動）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   新適用価格プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double NewListPrice
        {
            get { return _newListPrice; }
            set { _newListPrice = value; }
        }

        /// public propaty name  :  GoodsKindCode
        /// <summary>純優区分プロパティ</summary>
        /// <value>商品属性 0:純正 1:その他</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   純優区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsKindCode
        {
            get { return _goodsKindCode; }
            set { _goodsKindCode = value; }
        }

        /// public propaty name  :  TaxationDivCd
        /// <summary>課税区分プロパティ</summary>
        /// <value>0:課税 1:非課税 2:課税（内税）</value>
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

        /// public propaty name  :  EnterpriseGanreCode
        /// <summary>商品区分プロパティ</summary>
        /// <value>自社分類コード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 EnterpriseGanreCode
        {
            get { return _enterpriseGanreCode; }
            set { _enterpriseGanreCode = value; }
        }

        /// public propaty name  :  EnterpriseGanreCodeName
        /// <summary>商品区分名称プロパティ</summary>
        /// <value>ユーザーガイド区分名称(自社分類コード)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品区分名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EnterpriseGanreCodeName
        {
            get { return _enterpriseGanreCodeName; }
            set { _enterpriseGanreCodeName = value; }
        }

        /// public propaty name  :  OfferDataDiv
        /// <summary>提供データ区分プロパティ</summary>
        /// <value>0:ユーザデータ 1:提供データ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   提供データ区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 OfferDataDiv
        {
            get { return _offerDataDiv; }
            set { _offerDataDiv = value; }
        }

        /// <summary>
        /// 商品（印刷）データクラス複製処理
        /// </summary>
        /// <returns>SecInfoSetクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいSecInfoSetクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public GoodsSet Clone()
        {
            return new GoodsSet(this._updateDateTime, this._goodsMakerCd, this._makerShortName, this._goodsNo, this._bLGoodsCode, this._goodsName, this._supplierCd, this._supplierSnm, this._listPrice, this._stockRate, this._salesUnitCost, this._goodsRateRank, this._supplierLot, this._goodsSpecialNote, this._goodsNote1, this._goodsNote2, this._priceStartDate, this._newListPrice, this._goodsKindCode, this._taxationDivCd, this._enterpriseGanreCode, this._enterpriseGanreCodeName, this._offerDataDiv);
        }

        /// <summary>
		/// 商品（印刷）データクラスワークコンストラクタ
		/// </summary>
		/// <returns>EmployeeSetWorkクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   EmployeeSetWorkクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public GoodsSet()
		{
		}

        
        /// <summary>
        /// 商品（印刷）データクラスワークコンストラクタ
        /// </summary>
        /// <param name="UpdateDateTime"></param>
        /// <param name="GoodsMakerCd"></param>
        /// <param name="MakerShortName"></param>
        /// <param name="GoodsNo"></param>
        /// <param name="BLGoodsCode"></param>
        /// <param name="GoodsName"></param>
        /// <param name="SupplierCd"></param>
        /// <param name="SupplierSnm"></param>
        /// <param name="ListPrice"></param>
        /// <param name="StockRate"></param>
        /// <param name="SalesUnitCost"></param>
        /// <param name="GoodsRateRank"></param>
        /// <param name="SupplierLot"></param>
        /// <param name="GoodsSpecialNote"></param>
        /// <param name="GoodsNote1"></param>
        /// <param name="GoodsNote2"></param>
        /// <param name="PriceStartDate"></param>
        /// <param name="NewListPrice"></param>
        /// <param name="GoodsKindCode"></param>
        /// <param name="TaxationDivCd"></param>
        /// <param name="EnterpriseGanreCode"></param>
        /// <param name="EnterpriseGanreCodeName"></param>
        /// <param name="OfferDataDiv"></param>
        public GoodsSet(DateTime UpdateDateTime, Int32 GoodsMakerCd, string MakerShortName, string GoodsNo, Int32 BLGoodsCode, string GoodsName, Int32 SupplierCd, string SupplierSnm, Double ListPrice, Double StockRate, Double SalesUnitCost, string GoodsRateRank, Int32 SupplierLot, string GoodsSpecialNote, string GoodsNote1, string GoodsNote2, DateTime PriceStartDate, Double NewListPrice, Int32 GoodsKindCode, Int32 TaxationDivCd, Int32 EnterpriseGanreCode, string EnterpriseGanreCodeName, Int32 OfferDataDiv)
        {
            this._updateDateTime = UpdateDateTime;
            this._goodsMakerCd = GoodsMakerCd;
            this._makerShortName = MakerShortName;
            this._goodsNo = GoodsNo;
            this._bLGoodsCode = BLGoodsCode;
            this._goodsName = GoodsName;
            this._supplierCd = SupplierCd;
            this._supplierSnm = SupplierSnm;
            this._listPrice = ListPrice;
            this._stockRate = StockRate;
            this._salesUnitCost = SalesUnitCost;
            this._goodsRateRank = GoodsRateRank;
            this._supplierLot = SupplierLot;
            this._goodsSpecialNote = GoodsSpecialNote;
            this._goodsNote1 = GoodsNote1;
            this._goodsNote2 = GoodsNote2;
            this._priceStartDate = PriceStartDate;
            this._newListPrice = NewListPrice;
            this._goodsKindCode = GoodsKindCode;
            this._taxationDivCd = TaxationDivCd;
            this._enterpriseGanreCode = EnterpriseGanreCode;
            this._enterpriseGanreCodeName = EnterpriseGanreCodeName;
            this._offerDataDiv = OfferDataDiv;
        }
    }
}

using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   OrderListResultWork
    /// <summary>
    ///                      発注残照会リモート抽出結果クラスワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   発注残照会リモート抽出結果クラスワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/10/27  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class OrderListResultWork
    {
        /// <summary>赤伝区分</summary>
        /// <remarks>仕入</remarks>
        private Int32 _debitNoteDiv;

        /// <summary>仕入伝票区分</summary>
        /// <remarks>仕入</remarks>
        private Int32 _supplierSlipCd;

        /// <summary>相手先伝票番号</summary>
        /// <remarks>仕入</remarks>
        private string _partySaleSlipNum = "";

        /// <summary>入力日</summary>
        /// <remarks>仕入</remarks>
        private DateTime _inputDay;

        /// <summary>受注番号</summary>
        /// <remarks>仕入明細</remarks>
        private Int32 _acceptAnOrderNo;

        /// <summary>仕入形式</summary>
        /// <remarks>仕入明細</remarks>
        private Int32 _supplierFormal;

        /// <summary>仕入伝票番号</summary>
        /// <remarks>仕入明細</remarks>
        private Int32 _supplierSlipNo;

        /// <summary>仕入行番号</summary>
        /// <remarks>仕入明細</remarks>
        private Int32 _stockRowNo;

        /// <summary>拠点コード</summary>
        /// <remarks>仕入明細</remarks>
        private string _sectionCode = "";

        /// <summary>拠点ガイド名称</summary>
        /// <remarks>拠点情報設定</remarks>
        private string _sectionGuideNm = "";

        /// <summary>拠点ガイド略称</summary>
        /// <remarks>拠点情報設定</remarks>
        private string _sectionGuideSnm = "";

        /// <summary>仕入担当者コード</summary>
        /// <remarks>仕入明細</remarks>
        private string _stockAgentCode = "";

        /// <summary>仕入担当者名称</summary>
        /// <remarks>仕入明細</remarks>
        private string _stockAgentName = "";

        /// <summary>仕入入力者コード</summary>
        /// <remarks>仕入明細</remarks>
        private string _stockInputCode = "";

        /// <summary>仕入入力者名称</summary>
        /// <remarks>仕入明細</remarks>
        private string _stockInputName = "";

        /// <summary>商品メーカーコード</summary>
        /// <remarks>仕入明細</remarks>
        private Int32 _goodsMakerCd;

        /// <summary>メーカー名称</summary>
        /// <remarks>仕入明細</remarks>
        private string _makerName = "";

        /// <summary>商品番号</summary>
        /// <remarks>仕入明細</remarks>
        private string _goodsNo = "";

        /// <summary>商品名称</summary>
        /// <remarks>仕入明細</remarks>
        private string _goodsName = "";

        /// <summary>商品名称カナ</summary>
        /// <remarks>仕入明細</remarks>
        private string _goodsNameKana = "";

        /// <summary>BL商品コード</summary>
        /// <remarks>仕入明細</remarks>
        private Int32 _bLGoodsCode;

        /// <summary>BL商品コード名称（全角）</summary>
        /// <remarks>仕入明細</remarks>
        private string _bLGoodsFullName = "";

        /// <summary>倉庫コード</summary>
        /// <remarks>仕入明細</remarks>
        private string _warehouseCode = "";

        /// <summary>倉庫名称</summary>
        /// <remarks>仕入明細</remarks>
        private string _warehouseName = "";

        /// <summary>倉庫棚番</summary>
        /// <remarks>仕入明細</remarks>
        private string _warehouseShelfNo = "";

        /// <summary>仕入在庫取寄せ区分</summary>
        /// <remarks>仕入明細</remarks>
        private Int32 _stockOrderDivCd;

        /// <summary>定価（税抜，浮動）</summary>
        /// <remarks>仕入明細</remarks>
        private Double _listPriceTaxExcFl;

        /// <summary>定価（税込，浮動）</summary>
        /// <remarks>仕入明細</remarks>
        private Double _listPriceTaxIncFl;

        /// <summary>仕入単価（税抜，浮動）</summary>
        /// <remarks>仕入明細</remarks>
        private Double _stockUnitPriceFl;

        /// <summary>仕入単価（税込，浮動）</summary>
        /// <remarks>仕入明細</remarks>
        private Double _stockUnitTaxPriceFl;

        /// <summary>仕入金額消費税額</summary>
        /// <remarks>仕入明細</remarks>
        private Int64 _stockPriceConsTax;

        /// <summary>仕入数</summary>
        /// <remarks>仕入明細</remarks>
        private Double _stockCount;

        /// <summary>仕入金額（税抜き）</summary>
        /// <remarks>仕入明細</remarks>
        private Int64 _stockPriceTaxExc;

        /// <summary>仕入金額（税込み）</summary>
        /// <remarks>仕入明細</remarks>
        private Int64 _stockPriceTaxInc;

        /// <summary>仕入伝票明細備考1</summary>
        /// <remarks>仕入明細</remarks>
        private string _stockDtiSlipNote1 = "";

        /// <summary>販売先コード</summary>
        /// <remarks>仕入明細</remarks>
        private Int32 _salesCustomerCode;

        /// <summary>販売先略称</summary>
        /// <remarks>仕入明細</remarks>
        private string _salesCustomerSnm = "";

        /// <summary>仕入先コード</summary>
        /// <remarks>仕入明細</remarks>
        private Int32 _supplierCd;

        /// <summary>仕入先略称</summary>
        /// <remarks>仕入明細</remarks>
        private string _supplierSnm = "";

        /// <summary>納品先コード</summary>
        /// <remarks>仕入明細</remarks>
        private Int32 _addresseeCode;

        /// <summary>納品先名称</summary>
        /// <remarks>仕入明細</remarks>
        private string _addresseeName = "";

        /// <summary>残数更新日</summary>
        /// <remarks>仕入明細</remarks>
        private DateTime _remainCntUpdDate;

        /// <summary>直送区分</summary>
        /// <remarks>仕入明細</remarks>
        private Int32 _directSendingCd;

        /// <summary>発注番号</summary>
        /// <remarks>仕入明細</remarks>
        private string _orderNumber = "";

        /// <summary>注文方法</summary>
        /// <remarks>仕入明細</remarks>
        private Int32 _wayToOrder;

        /// <summary>納品完了予定日</summary>
        /// <remarks>仕入明細</remarks>
        private DateTime _deliGdsCmpltDueDate;

        /// <summary>希望納期</summary>
        /// <remarks>仕入明細</remarks>
        private DateTime _expectDeliveryDate;

        /// <summary>発注数量</summary>
        /// <remarks>仕入明細</remarks>
        private Double _orderCnt;

        /// <summary>発注調整数</summary>
        /// <remarks>仕入明細</remarks>
        private Double _orderAdjustCnt;

        /// <summary>発注残数</summary>
        /// <remarks>仕入明細</remarks>
        private Double _orderRemainCnt;

        /// <summary>発注書発行済区分</summary>
        /// <remarks>仕入明細</remarks>
        private Int32 _orderFormIssuedDiv;

        /// <summary>発注データ作成日</summary>
        /// <remarks>仕入明細</remarks>
        private DateTime _orderDataCreateDate;

        /// <summary>伝票メモ１</summary>
        /// <remarks>仕入明細</remarks>
        private string _slipMemo1 = "";

        /// <summary>伝票メモ２</summary>
        /// <remarks>仕入明細</remarks>
        private string _slipMemo2 = "";

        /// <summary>伝票メモ３</summary>
        /// <remarks>仕入明細</remarks>
        private string _slipMemo3 = "";

        /// <summary>社内メモ１</summary>
        /// <remarks>仕入明細</remarks>
        private string _insideMemo1 = "";

        /// <summary>社内メモ２</summary>
        /// <remarks>仕入明細</remarks>
        private string _insideMemo2 = "";

        /// <summary>社内メモ３</summary>
        /// <remarks>仕入明細</remarks>
        private string _insideMemo3 = "";

        /// <summary>仕入明細通番</summary>
        /// <remarks>仕入明細</remarks>
        private Int64 _stockSlipDtlNum;

        /// <summary>仕入先消費税転嫁方式コード</summary>
        /// <remarks>0:伝票単位1:明細単位2:支払親 3:支払子 9:非課税  仕入</remarks>
        private Int32 _suppCTaxLayCd;

        /// <summary>仕入先総額表示方法区分</summary>
        /// <remarks>0:総額表示しない（税抜き）,1:総額表示する（税込み）</remarks>
        private Int32 _suppTtlAmntDspWayCd;

        /// <summary>課税区分</summary>
        /// <remarks>0:課税,1:非課税,2:課税（内税）  仕入明細</remarks>
        private Int32 _taxationCode;


        /// public propaty name  :  DebitNoteDiv
        /// <summary>赤伝区分プロパティ</summary>
        /// <value>仕入</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   赤伝区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DebitNoteDiv
        {
            get { return _debitNoteDiv; }
            set { _debitNoteDiv = value; }
        }

        /// public propaty name  :  SupplierSlipCd
        /// <summary>仕入伝票区分プロパティ</summary>
        /// <value>仕入</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入伝票区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SupplierSlipCd
        {
            get { return _supplierSlipCd; }
            set { _supplierSlipCd = value; }
        }

        /// public propaty name  :  PartySaleSlipNum
        /// <summary>相手先伝票番号プロパティ</summary>
        /// <value>仕入</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   相手先伝票番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PartySaleSlipNum
        {
            get { return _partySaleSlipNum; }
            set { _partySaleSlipNum = value; }
        }

        /// public propaty name  :  InputDay
        /// <summary>入力日プロパティ</summary>
        /// <value>仕入</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入力日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime InputDay
        {
            get { return _inputDay; }
            set { _inputDay = value; }
        }

        /// public propaty name  :  AcceptAnOrderNo
        /// <summary>受注番号プロパティ</summary>
        /// <value>仕入明細</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   受注番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 AcceptAnOrderNo
        {
            get { return _acceptAnOrderNo; }
            set { _acceptAnOrderNo = value; }
        }

        /// public propaty name  :  SupplierFormal
        /// <summary>仕入形式プロパティ</summary>
        /// <value>仕入明細</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入形式プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SupplierFormal
        {
            get { return _supplierFormal; }
            set { _supplierFormal = value; }
        }

        /// public propaty name  :  SupplierSlipNo
        /// <summary>仕入伝票番号プロパティ</summary>
        /// <value>仕入明細</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入伝票番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SupplierSlipNo
        {
            get { return _supplierSlipNo; }
            set { _supplierSlipNo = value; }
        }

        /// public propaty name  :  StockRowNo
        /// <summary>仕入行番号プロパティ</summary>
        /// <value>仕入明細</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入行番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 StockRowNo
        {
            get { return _stockRowNo; }
            set { _stockRowNo = value; }
        }

        /// public propaty name  :  SectionCode
        /// <summary>拠点コードプロパティ</summary>
        /// <value>仕入明細</value>
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

        /// public propaty name  :  SectionGuideNm
        /// <summary>拠点ガイド名称プロパティ</summary>
        /// <value>拠点情報設定</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点ガイド名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SectionGuideNm
        {
            get { return _sectionGuideNm; }
            set { _sectionGuideNm = value; }
        }

        /// public propaty name  :  SectionGuideSnm
        /// <summary>拠点ガイド略称プロパティ</summary>
        /// <value>拠点情報設定</value>
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

        /// public propaty name  :  StockAgentCode
        /// <summary>仕入担当者コードプロパティ</summary>
        /// <value>仕入明細</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入担当者コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string StockAgentCode
        {
            get { return _stockAgentCode; }
            set { _stockAgentCode = value; }
        }

        /// public propaty name  :  StockAgentName
        /// <summary>仕入担当者名称プロパティ</summary>
        /// <value>仕入明細</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入担当者名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string StockAgentName
        {
            get { return _stockAgentName; }
            set { _stockAgentName = value; }
        }

        /// public propaty name  :  StockInputCode
        /// <summary>仕入入力者コードプロパティ</summary>
        /// <value>仕入明細</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入入力者コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string StockInputCode
        {
            get { return _stockInputCode; }
            set { _stockInputCode = value; }
        }

        /// public propaty name  :  StockInputName
        /// <summary>仕入入力者名称プロパティ</summary>
        /// <value>仕入明細</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入入力者名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string StockInputName
        {
            get { return _stockInputName; }
            set { _stockInputName = value; }
        }

        /// public propaty name  :  GoodsMakerCd
        /// <summary>商品メーカーコードプロパティ</summary>
        /// <value>仕入明細</value>
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
        /// <value>仕入明細</value>
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
        /// <value>仕入明細</value>
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
        /// <value>仕入明細</value>
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

        /// public propaty name  :  GoodsNameKana
        /// <summary>商品名称カナプロパティ</summary>
        /// <value>仕入明細</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品名称カナプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsNameKana
        {
            get { return _goodsNameKana; }
            set { _goodsNameKana = value; }
        }

        /// public propaty name  :  BLGoodsCode
        /// <summary>BL商品コードプロパティ</summary>
        /// <value>仕入明細</value>
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
        /// <value>仕入明細</value>
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

        /// public propaty name  :  WarehouseCode
        /// <summary>倉庫コードプロパティ</summary>
        /// <value>仕入明細</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   倉庫コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string WarehouseCode
        {
            get { return _warehouseCode; }
            set { _warehouseCode = value; }
        }

        /// public propaty name  :  WarehouseName
        /// <summary>倉庫名称プロパティ</summary>
        /// <value>仕入明細</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   倉庫名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string WarehouseName
        {
            get { return _warehouseName; }
            set { _warehouseName = value; }
        }

        /// public propaty name  :  WarehouseShelfNo
        /// <summary>倉庫棚番プロパティ</summary>
        /// <value>仕入明細</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   倉庫棚番プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string WarehouseShelfNo
        {
            get { return _warehouseShelfNo; }
            set { _warehouseShelfNo = value; }
        }

        /// public propaty name  :  StockOrderDivCd
        /// <summary>仕入在庫取寄せ区分プロパティ</summary>
        /// <value>仕入明細</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入在庫取寄せ区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 StockOrderDivCd
        {
            get { return _stockOrderDivCd; }
            set { _stockOrderDivCd = value; }
        }

        /// public propaty name  :  ListPriceTaxExcFl
        /// <summary>定価（税抜，浮動）プロパティ</summary>
        /// <value>仕入明細</value>
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

        /// public propaty name  :  ListPriceTaxIncFl
        /// <summary>定価（税込，浮動）プロパティ</summary>
        /// <value>仕入明細</value>
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

        /// public propaty name  :  StockUnitPriceFl
        /// <summary>仕入単価（税抜，浮動）プロパティ</summary>
        /// <value>仕入明細</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入単価（税抜，浮動）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double StockUnitPriceFl
        {
            get { return _stockUnitPriceFl; }
            set { _stockUnitPriceFl = value; }
        }

        /// public propaty name  :  StockUnitTaxPriceFl
        /// <summary>仕入単価（税込，浮動）プロパティ</summary>
        /// <value>仕入明細</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入単価（税込，浮動）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double StockUnitTaxPriceFl
        {
            get { return _stockUnitTaxPriceFl; }
            set { _stockUnitTaxPriceFl = value; }
        }

        /// public propaty name  :  StockPriceConsTax
        /// <summary>仕入金額消費税額プロパティ</summary>
        /// <value>仕入明細</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入金額消費税額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 StockPriceConsTax
        {
            get { return _stockPriceConsTax; }
            set { _stockPriceConsTax = value; }
        }

        /// public propaty name  :  StockCount
        /// <summary>仕入数プロパティ</summary>
        /// <value>仕入明細</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double StockCount
        {
            get { return _stockCount; }
            set { _stockCount = value; }
        }

        /// public propaty name  :  StockPriceTaxExc
        /// <summary>仕入金額（税抜き）プロパティ</summary>
        /// <value>仕入明細</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入金額（税抜き）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 StockPriceTaxExc
        {
            get { return _stockPriceTaxExc; }
            set { _stockPriceTaxExc = value; }
        }

        /// public propaty name  :  StockPriceTaxInc
        /// <summary>仕入金額（税込み）プロパティ</summary>
        /// <value>仕入明細</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入金額（税込み）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 StockPriceTaxInc
        {
            get { return _stockPriceTaxInc; }
            set { _stockPriceTaxInc = value; }
        }

        /// public propaty name  :  StockDtiSlipNote1
        /// <summary>仕入伝票明細備考1プロパティ</summary>
        /// <value>仕入明細</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入伝票明細備考1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string StockDtiSlipNote1
        {
            get { return _stockDtiSlipNote1; }
            set { _stockDtiSlipNote1 = value; }
        }

        /// public propaty name  :  SalesCustomerCode
        /// <summary>販売先コードプロパティ</summary>
        /// <value>仕入明細</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   販売先コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SalesCustomerCode
        {
            get { return _salesCustomerCode; }
            set { _salesCustomerCode = value; }
        }

        /// public propaty name  :  SalesCustomerSnm
        /// <summary>販売先略称プロパティ</summary>
        /// <value>仕入明細</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   販売先略称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SalesCustomerSnm
        {
            get { return _salesCustomerSnm; }
            set { _salesCustomerSnm = value; }
        }

        /// public propaty name  :  SupplierCd
        /// <summary>仕入先コードプロパティ</summary>
        /// <value>仕入明細</value>
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
        /// <value>仕入明細</value>
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

        /// public propaty name  :  AddresseeCode
        /// <summary>納品先コードプロパティ</summary>
        /// <value>仕入明細</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   納品先コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 AddresseeCode
        {
            get { return _addresseeCode; }
            set { _addresseeCode = value; }
        }

        /// public propaty name  :  AddresseeName
        /// <summary>納品先名称プロパティ</summary>
        /// <value>仕入明細</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   納品先名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string AddresseeName
        {
            get { return _addresseeName; }
            set { _addresseeName = value; }
        }

        /// public propaty name  :  RemainCntUpdDate
        /// <summary>残数更新日プロパティ</summary>
        /// <value>仕入明細</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   残数更新日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime RemainCntUpdDate
        {
            get { return _remainCntUpdDate; }
            set { _remainCntUpdDate = value; }
        }

        /// public propaty name  :  DirectSendingCd
        /// <summary>直送区分プロパティ</summary>
        /// <value>仕入明細</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   直送区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DirectSendingCd
        {
            get { return _directSendingCd; }
            set { _directSendingCd = value; }
        }

        /// public propaty name  :  OrderNumber
        /// <summary>発注番号プロパティ</summary>
        /// <value>仕入明細</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   発注番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string OrderNumber
        {
            get { return _orderNumber; }
            set { _orderNumber = value; }
        }

        /// public propaty name  :  WayToOrder
        /// <summary>注文方法プロパティ</summary>
        /// <value>仕入明細</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   注文方法プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 WayToOrder
        {
            get { return _wayToOrder; }
            set { _wayToOrder = value; }
        }

        /// public propaty name  :  DeliGdsCmpltDueDate
        /// <summary>納品完了予定日プロパティ</summary>
        /// <value>仕入明細</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   納品完了予定日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime DeliGdsCmpltDueDate
        {
            get { return _deliGdsCmpltDueDate; }
            set { _deliGdsCmpltDueDate = value; }
        }

        /// public propaty name  :  ExpectDeliveryDate
        /// <summary>希望納期プロパティ</summary>
        /// <value>仕入明細</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   希望納期プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime ExpectDeliveryDate
        {
            get { return _expectDeliveryDate; }
            set { _expectDeliveryDate = value; }
        }

        /// public propaty name  :  OrderCnt
        /// <summary>発注数量プロパティ</summary>
        /// <value>仕入明細</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   発注数量プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double OrderCnt
        {
            get { return _orderCnt; }
            set { _orderCnt = value; }
        }

        /// public propaty name  :  OrderAdjustCnt
        /// <summary>発注調整数プロパティ</summary>
        /// <value>仕入明細</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   発注調整数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double OrderAdjustCnt
        {
            get { return _orderAdjustCnt; }
            set { _orderAdjustCnt = value; }
        }

        /// public propaty name  :  OrderRemainCnt
        /// <summary>発注残数プロパティ</summary>
        /// <value>仕入明細</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   発注残数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double OrderRemainCnt
        {
            get { return _orderRemainCnt; }
            set { _orderRemainCnt = value; }
        }

        /// public propaty name  :  OrderFormIssuedDiv
        /// <summary>発注書発行済区分プロパティ</summary>
        /// <value>仕入明細</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   発注書発行済区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 OrderFormIssuedDiv
        {
            get { return _orderFormIssuedDiv; }
            set { _orderFormIssuedDiv = value; }
        }

        /// public propaty name  :  OrderDataCreateDate
        /// <summary>発注データ作成日プロパティ</summary>
        /// <value>仕入明細</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   発注データ作成日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime OrderDataCreateDate
        {
            get { return _orderDataCreateDate; }
            set { _orderDataCreateDate = value; }
        }

        /// public propaty name  :  SlipMemo1
        /// <summary>伝票メモ１プロパティ</summary>
        /// <value>仕入明細</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   伝票メモ１プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SlipMemo1
        {
            get { return _slipMemo1; }
            set { _slipMemo1 = value; }
        }

        /// public propaty name  :  SlipMemo2
        /// <summary>伝票メモ２プロパティ</summary>
        /// <value>仕入明細</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   伝票メモ２プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SlipMemo2
        {
            get { return _slipMemo2; }
            set { _slipMemo2 = value; }
        }

        /// public propaty name  :  SlipMemo3
        /// <summary>伝票メモ３プロパティ</summary>
        /// <value>仕入明細</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   伝票メモ３プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SlipMemo3
        {
            get { return _slipMemo3; }
            set { _slipMemo3 = value; }
        }

        /// public propaty name  :  InsideMemo1
        /// <summary>社内メモ１プロパティ</summary>
        /// <value>仕入明細</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   社内メモ１プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string InsideMemo1
        {
            get { return _insideMemo1; }
            set { _insideMemo1 = value; }
        }

        /// public propaty name  :  InsideMemo2
        /// <summary>社内メモ２プロパティ</summary>
        /// <value>仕入明細</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   社内メモ２プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string InsideMemo2
        {
            get { return _insideMemo2; }
            set { _insideMemo2 = value; }
        }

        /// public propaty name  :  InsideMemo3
        /// <summary>社内メモ３プロパティ</summary>
        /// <value>仕入明細</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   社内メモ３プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string InsideMemo3
        {
            get { return _insideMemo3; }
            set { _insideMemo3 = value; }
        }

        /// public propaty name  :  StockSlipDtlNum
        /// <summary>仕入明細通番プロパティ</summary>
        /// <value>仕入明細</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入明細通番プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 StockSlipDtlNum
        {
            get { return _stockSlipDtlNum; }
            set { _stockSlipDtlNum = value; }
        }

        /// public propaty name  :  SuppCTaxLayCd
        /// <summary>仕入先消費税転嫁方式コードプロパティ</summary>
        /// <value>0:伝票単位1:明細単位2:支払親 3:支払子 9:非課税  仕入</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先消費税転嫁方式コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SuppCTaxLayCd
        {
            get { return _suppCTaxLayCd; }
            set { _suppCTaxLayCd = value; }
        }

        /// public propaty name  :  SuppTtlAmntDspWayCd
        /// <summary>仕入先総額表示方法区分プロパティ</summary>
        /// <value>0:総額表示しない（税抜き）,1:総額表示する（税込み）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先総額表示方法区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SuppTtlAmntDspWayCd
        {
            get { return _suppTtlAmntDspWayCd; }
            set { _suppTtlAmntDspWayCd = value; }
        }

        /// public propaty name  :  TaxationCode
        /// <summary>課税区分プロパティ</summary>
        /// <value>0:課税,1:非課税,2:課税（内税）  仕入明細</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   課税区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 TaxationCode
        {
            get { return _taxationCode; }
            set { _taxationCode = value; }
        }


        /// <summary>
        /// 発注残照会リモート抽出結果クラスワークコンストラクタ
        /// </summary>
        /// <returns>OrderListResultWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   OrderListResultWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public OrderListResultWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>OrderListResultWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   OrderListResultWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class OrderListResultWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   OrderListResultWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  OrderListResultWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is OrderListResultWork || graph is ArrayList || graph is OrderListResultWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(OrderListResultWork).FullName));

            if (graph != null && graph is OrderListResultWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.OrderListResultWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is OrderListResultWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((OrderListResultWork[])graph).Length;
            }
            else if (graph is OrderListResultWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //繰り返し数	

            //赤伝区分
            serInfo.MemberInfo.Add(typeof(Int32)); //DebitNoteDiv
            //仕入伝票区分
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierSlipCd
            //相手先伝票番号
            serInfo.MemberInfo.Add(typeof(string)); //PartySaleSlipNum
            //入力日
            serInfo.MemberInfo.Add(typeof(Int32)); //InputDay
            //受注番号
            serInfo.MemberInfo.Add(typeof(Int32)); //AcceptAnOrderNo
            //仕入形式
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierFormal
            //仕入伝票番号
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierSlipNo
            //仕入行番号
            serInfo.MemberInfo.Add(typeof(Int32)); //StockRowNo
            //拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //SectionCode
            //拠点ガイド名称
            serInfo.MemberInfo.Add(typeof(string)); //SectionGuideNm
            //拠点ガイド略称
            serInfo.MemberInfo.Add(typeof(string)); //SectionGuideSnm
            //仕入担当者コード
            serInfo.MemberInfo.Add(typeof(string)); //StockAgentCode
            //仕入担当者名称
            serInfo.MemberInfo.Add(typeof(string)); //StockAgentName
            //仕入入力者コード
            serInfo.MemberInfo.Add(typeof(string)); //StockInputCode
            //仕入入力者名称
            serInfo.MemberInfo.Add(typeof(string)); //StockInputName
            //商品メーカーコード
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMakerCd
            //メーカー名称
            serInfo.MemberInfo.Add(typeof(string)); //MakerName
            //商品番号
            serInfo.MemberInfo.Add(typeof(string)); //GoodsNo
            //商品名称
            serInfo.MemberInfo.Add(typeof(string)); //GoodsName
            //商品名称カナ
            serInfo.MemberInfo.Add(typeof(string)); //GoodsNameKana
            //BL商品コード
            serInfo.MemberInfo.Add(typeof(Int32)); //BLGoodsCode
            //BL商品コード名称（全角）
            serInfo.MemberInfo.Add(typeof(string)); //BLGoodsFullName
            //倉庫コード
            serInfo.MemberInfo.Add(typeof(string)); //WarehouseCode
            //倉庫名称
            serInfo.MemberInfo.Add(typeof(string)); //WarehouseName
            //倉庫棚番
            serInfo.MemberInfo.Add(typeof(string)); //WarehouseShelfNo
            //仕入在庫取寄せ区分
            serInfo.MemberInfo.Add(typeof(Int32)); //StockOrderDivCd
            //定価（税抜，浮動）
            serInfo.MemberInfo.Add(typeof(Double)); //ListPriceTaxExcFl
            //定価（税込，浮動）
            serInfo.MemberInfo.Add(typeof(Double)); //ListPriceTaxIncFl
            //仕入単価（税抜，浮動）
            serInfo.MemberInfo.Add(typeof(Double)); //StockUnitPriceFl
            //仕入単価（税込，浮動）
            serInfo.MemberInfo.Add(typeof(Double)); //StockUnitTaxPriceFl
            //仕入金額消費税額
            serInfo.MemberInfo.Add(typeof(Int64)); //StockPriceConsTax
            //仕入数
            serInfo.MemberInfo.Add(typeof(Double)); //StockCount
            //仕入金額（税抜き）
            serInfo.MemberInfo.Add(typeof(Int64)); //StockPriceTaxExc
            //仕入金額（税込み）
            serInfo.MemberInfo.Add(typeof(Int64)); //StockPriceTaxInc
            //仕入伝票明細備考1
            serInfo.MemberInfo.Add(typeof(string)); //StockDtiSlipNote1
            //販売先コード
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesCustomerCode
            //販売先略称
            serInfo.MemberInfo.Add(typeof(string)); //SalesCustomerSnm
            //仕入先コード
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierCd
            //仕入先略称
            serInfo.MemberInfo.Add(typeof(string)); //SupplierSnm
            //納品先コード
            serInfo.MemberInfo.Add(typeof(Int32)); //AddresseeCode
            //納品先名称
            serInfo.MemberInfo.Add(typeof(string)); //AddresseeName
            //残数更新日
            serInfo.MemberInfo.Add(typeof(Int32)); //RemainCntUpdDate
            //直送区分
            serInfo.MemberInfo.Add(typeof(Int32)); //DirectSendingCd
            //発注番号
            serInfo.MemberInfo.Add(typeof(string)); //OrderNumber
            //注文方法
            serInfo.MemberInfo.Add(typeof(Int32)); //WayToOrder
            //納品完了予定日
            serInfo.MemberInfo.Add(typeof(Int32)); //DeliGdsCmpltDueDate
            //希望納期
            serInfo.MemberInfo.Add(typeof(Int32)); //ExpectDeliveryDate
            //発注数量
            serInfo.MemberInfo.Add(typeof(Double)); //OrderCnt
            //発注調整数
            serInfo.MemberInfo.Add(typeof(Double)); //OrderAdjustCnt
            //発注残数
            serInfo.MemberInfo.Add(typeof(Double)); //OrderRemainCnt
            //発注書発行済区分
            serInfo.MemberInfo.Add(typeof(Int32)); //OrderFormIssuedDiv
            //発注データ作成日
            serInfo.MemberInfo.Add(typeof(Int32)); //OrderDataCreateDate
            //伝票メモ１
            serInfo.MemberInfo.Add(typeof(string)); //SlipMemo1
            //伝票メモ２
            serInfo.MemberInfo.Add(typeof(string)); //SlipMemo2
            //伝票メモ３
            serInfo.MemberInfo.Add(typeof(string)); //SlipMemo3
            //社内メモ１
            serInfo.MemberInfo.Add(typeof(string)); //InsideMemo1
            //社内メモ２
            serInfo.MemberInfo.Add(typeof(string)); //InsideMemo2
            //社内メモ３
            serInfo.MemberInfo.Add(typeof(string)); //InsideMemo3
            //仕入明細通番
            serInfo.MemberInfo.Add(typeof(Int64)); //StockSlipDtlNum
            //仕入先消費税転嫁方式コード
            serInfo.MemberInfo.Add(typeof(Int32)); //SuppCTaxLayCd
            //仕入先総額表示方法区分
            serInfo.MemberInfo.Add(typeof(Int32)); //SuppTtlAmntDspWayCd
            //課税区分
            serInfo.MemberInfo.Add(typeof(Int32)); //TaxationCode


            serInfo.Serialize(writer, serInfo);
            if (graph is OrderListResultWork)
            {
                OrderListResultWork temp = (OrderListResultWork)graph;

                SetOrderListResultWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is OrderListResultWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((OrderListResultWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (OrderListResultWork temp in lst)
                {
                    SetOrderListResultWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// OrderListResultWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 62;

        /// <summary>
        ///  OrderListResultWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   OrderListResultWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetOrderListResultWork(System.IO.BinaryWriter writer, OrderListResultWork temp)
        {
            //赤伝区分
            writer.Write(temp.DebitNoteDiv);
            //仕入伝票区分
            writer.Write(temp.SupplierSlipCd);
            //相手先伝票番号
            writer.Write(temp.PartySaleSlipNum);
            //入力日
            writer.Write((Int64)temp.InputDay.Ticks);
            //受注番号
            writer.Write(temp.AcceptAnOrderNo);
            //仕入形式
            writer.Write(temp.SupplierFormal);
            //仕入伝票番号
            writer.Write(temp.SupplierSlipNo);
            //仕入行番号
            writer.Write(temp.StockRowNo);
            //拠点コード
            writer.Write(temp.SectionCode);
            //拠点ガイド名称
            writer.Write(temp.SectionGuideNm);
            //拠点ガイド略称
            writer.Write(temp.SectionGuideSnm);
            //仕入担当者コード
            writer.Write(temp.StockAgentCode);
            //仕入担当者名称
            writer.Write(temp.StockAgentName);
            //仕入入力者コード
            writer.Write(temp.StockInputCode);
            //仕入入力者名称
            writer.Write(temp.StockInputName);
            //商品メーカーコード
            writer.Write(temp.GoodsMakerCd);
            //メーカー名称
            writer.Write(temp.MakerName);
            //商品番号
            writer.Write(temp.GoodsNo);
            //商品名称
            writer.Write(temp.GoodsName);
            //商品名称カナ
            writer.Write(temp.GoodsNameKana);
            //BL商品コード
            writer.Write(temp.BLGoodsCode);
            //BL商品コード名称（全角）
            writer.Write(temp.BLGoodsFullName);
            //倉庫コード
            writer.Write(temp.WarehouseCode);
            //倉庫名称
            writer.Write(temp.WarehouseName);
            //倉庫棚番
            writer.Write(temp.WarehouseShelfNo);
            //仕入在庫取寄せ区分
            writer.Write(temp.StockOrderDivCd);
            //定価（税抜，浮動）
            writer.Write(temp.ListPriceTaxExcFl);
            //定価（税込，浮動）
            writer.Write(temp.ListPriceTaxIncFl);
            //仕入単価（税抜，浮動）
            writer.Write(temp.StockUnitPriceFl);
            //仕入単価（税込，浮動）
            writer.Write(temp.StockUnitTaxPriceFl);
            //仕入金額消費税額
            writer.Write(temp.StockPriceConsTax);
            //仕入数
            writer.Write(temp.StockCount);
            //仕入金額（税抜き）
            writer.Write(temp.StockPriceTaxExc);
            //仕入金額（税込み）
            writer.Write(temp.StockPriceTaxInc);
            //仕入伝票明細備考1
            writer.Write(temp.StockDtiSlipNote1);
            //販売先コード
            writer.Write(temp.SalesCustomerCode);
            //販売先略称
            writer.Write(temp.SalesCustomerSnm);
            //仕入先コード
            writer.Write(temp.SupplierCd);
            //仕入先略称
            writer.Write(temp.SupplierSnm);
            //納品先コード
            writer.Write(temp.AddresseeCode);
            //納品先名称
            writer.Write(temp.AddresseeName);
            //残数更新日
            writer.Write((Int64)temp.RemainCntUpdDate.Ticks);
            //直送区分
            writer.Write(temp.DirectSendingCd);
            //発注番号
            writer.Write(temp.OrderNumber);
            //注文方法
            writer.Write(temp.WayToOrder);
            //納品完了予定日
            writer.Write((Int64)temp.DeliGdsCmpltDueDate.Ticks);
            //希望納期
            writer.Write((Int64)temp.ExpectDeliveryDate.Ticks);
            //発注数量
            writer.Write(temp.OrderCnt);
            //発注調整数
            writer.Write(temp.OrderAdjustCnt);
            //発注残数
            writer.Write(temp.OrderRemainCnt);
            //発注書発行済区分
            writer.Write(temp.OrderFormIssuedDiv);
            //発注データ作成日
            writer.Write((Int64)temp.OrderDataCreateDate.Ticks);
            //伝票メモ１
            writer.Write(temp.SlipMemo1);
            //伝票メモ２
            writer.Write(temp.SlipMemo2);
            //伝票メモ３
            writer.Write(temp.SlipMemo3);
            //社内メモ１
            writer.Write(temp.InsideMemo1);
            //社内メモ２
            writer.Write(temp.InsideMemo2);
            //社内メモ３
            writer.Write(temp.InsideMemo3);
            //仕入明細通番
            writer.Write(temp.StockSlipDtlNum);
            //仕入先消費税転嫁方式コード
            writer.Write(temp.SuppCTaxLayCd);
            //仕入先総額表示方法区分
            writer.Write(temp.SuppTtlAmntDspWayCd);
            //課税区分
            writer.Write(temp.TaxationCode);

        }

        /// <summary>
        ///  OrderListResultWorkインスタンス取得
        /// </summary>
        /// <returns>OrderListResultWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   OrderListResultWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private OrderListResultWork GetOrderListResultWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            OrderListResultWork temp = new OrderListResultWork();

            //赤伝区分
            temp.DebitNoteDiv = reader.ReadInt32();
            //仕入伝票区分
            temp.SupplierSlipCd = reader.ReadInt32();
            //相手先伝票番号
            temp.PartySaleSlipNum = reader.ReadString();
            //入力日
            temp.InputDay = new DateTime(reader.ReadInt64());
            //受注番号
            temp.AcceptAnOrderNo = reader.ReadInt32();
            //仕入形式
            temp.SupplierFormal = reader.ReadInt32();
            //仕入伝票番号
            temp.SupplierSlipNo = reader.ReadInt32();
            //仕入行番号
            temp.StockRowNo = reader.ReadInt32();
            //拠点コード
            temp.SectionCode = reader.ReadString();
            //拠点ガイド名称
            temp.SectionGuideNm = reader.ReadString();
            //拠点ガイド略称
            temp.SectionGuideSnm = reader.ReadString();
            //仕入担当者コード
            temp.StockAgentCode = reader.ReadString();
            //仕入担当者名称
            temp.StockAgentName = reader.ReadString();
            //仕入入力者コード
            temp.StockInputCode = reader.ReadString();
            //仕入入力者名称
            temp.StockInputName = reader.ReadString();
            //商品メーカーコード
            temp.GoodsMakerCd = reader.ReadInt32();
            //メーカー名称
            temp.MakerName = reader.ReadString();
            //商品番号
            temp.GoodsNo = reader.ReadString();
            //商品名称
            temp.GoodsName = reader.ReadString();
            //商品名称カナ
            temp.GoodsNameKana = reader.ReadString();
            //BL商品コード
            temp.BLGoodsCode = reader.ReadInt32();
            //BL商品コード名称（全角）
            temp.BLGoodsFullName = reader.ReadString();
            //倉庫コード
            temp.WarehouseCode = reader.ReadString();
            //倉庫名称
            temp.WarehouseName = reader.ReadString();
            //倉庫棚番
            temp.WarehouseShelfNo = reader.ReadString();
            //仕入在庫取寄せ区分
            temp.StockOrderDivCd = reader.ReadInt32();
            //定価（税抜，浮動）
            temp.ListPriceTaxExcFl = reader.ReadDouble();
            //定価（税込，浮動）
            temp.ListPriceTaxIncFl = reader.ReadDouble();
            //仕入単価（税抜，浮動）
            temp.StockUnitPriceFl = reader.ReadDouble();
            //仕入単価（税込，浮動）
            temp.StockUnitTaxPriceFl = reader.ReadDouble();
            //仕入金額消費税額
            temp.StockPriceConsTax = reader.ReadInt64();
            //仕入数
            temp.StockCount = reader.ReadDouble();
            //仕入金額（税抜き）
            temp.StockPriceTaxExc = reader.ReadInt64();
            //仕入金額（税込み）
            temp.StockPriceTaxInc = reader.ReadInt64();
            //仕入伝票明細備考1
            temp.StockDtiSlipNote1 = reader.ReadString();
            //販売先コード
            temp.SalesCustomerCode = reader.ReadInt32();
            //販売先略称
            temp.SalesCustomerSnm = reader.ReadString();
            //仕入先コード
            temp.SupplierCd = reader.ReadInt32();
            //仕入先略称
            temp.SupplierSnm = reader.ReadString();
            //納品先コード
            temp.AddresseeCode = reader.ReadInt32();
            //納品先名称
            temp.AddresseeName = reader.ReadString();
            //残数更新日
            temp.RemainCntUpdDate = new DateTime(reader.ReadInt64());
            //直送区分
            temp.DirectSendingCd = reader.ReadInt32();
            //発注番号
            temp.OrderNumber = reader.ReadString();
            //注文方法
            temp.WayToOrder = reader.ReadInt32();
            //納品完了予定日
            temp.DeliGdsCmpltDueDate = new DateTime(reader.ReadInt64());
            //希望納期
            temp.ExpectDeliveryDate = new DateTime(reader.ReadInt64());
            //発注数量
            temp.OrderCnt = reader.ReadDouble();
            //発注調整数
            temp.OrderAdjustCnt = reader.ReadDouble();
            //発注残数
            temp.OrderRemainCnt = reader.ReadDouble();
            //発注書発行済区分
            temp.OrderFormIssuedDiv = reader.ReadInt32();
            //発注データ作成日
            temp.OrderDataCreateDate = new DateTime(reader.ReadInt64());
            //伝票メモ１
            temp.SlipMemo1 = reader.ReadString();
            //伝票メモ２
            temp.SlipMemo2 = reader.ReadString();
            //伝票メモ３
            temp.SlipMemo3 = reader.ReadString();
            //社内メモ１
            temp.InsideMemo1 = reader.ReadString();
            //社内メモ２
            temp.InsideMemo2 = reader.ReadString();
            //社内メモ３
            temp.InsideMemo3 = reader.ReadString();
            //仕入明細通番
            temp.StockSlipDtlNum = reader.ReadInt64();
            //仕入先消費税転嫁方式コード
            temp.SuppCTaxLayCd = reader.ReadInt32();
            //仕入先総額表示方法区分
            temp.SuppTtlAmntDspWayCd = reader.ReadInt32();
            //課税区分
            temp.TaxationCode = reader.ReadInt32();


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
        /// <returns>OrderListResultWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   OrderListResultWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                OrderListResultWork temp = GetOrderListResultWork(reader, serInfo);
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
                    retValue = (OrderListResultWork[])lst.ToArray(typeof(OrderListResultWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}
